Imports System.IO
Imports System.Text
Imports System.Security.Cryptography
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO.Ports

'Imports FinAcct.MenuItmHandles
Public Class FrmEncrytionAfile
    Inherits System.Windows.Forms.Form
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader
    Dim cmd1 As SqlCommand
    Dim rdr1 As SqlDataReader
    Dim dt As DataTable
    Dim dr As DataRow

    ' Dim WithEvents Port As SerialPort = New SerialPort("vinodnode.www.virka.com", 9600, Parity.None, 8, StopBits.One)

    'create an 8-byte long array to hold the key 
    Public TheKey(7) As Byte
    Dim lt, gt As Integer
    'Stuff some random values into the vector: 
    Private Vector() As Byte = {&H12, &H44, &H16, &HEE, &H88, &H15, &HDD, &H41}
    Private Sub FrmTest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'HrPrData08DataSet.DataTable1' table. You can move, or remove it, as needed.
        '  Me.DataTable1TableAdapter.Fill(Me.HrPrData08DataSet.DataTable1)
        'TODO: This line of code loads data into the 'HrPrData08DataSet.DataTable1' table. You can move, or remove it, as needed.
        ' Me.DataTable1TableAdapter.Fill(Me.HrPrData08DataSet.DataTable1)
        'TODO: This line of code loads data into the 'HrPrData08DataSet.FinactEmpmstr' table. You can move, or remove it, as needed.
        ''Me.FinactEmpmstrTableAdapter.Fill(Me.HrPrData08DataSet.FinactEmpmstr)
        ' Button3.UseVisualStyleBackColor = True
        CheckForIllegalCrossThreadCalls = False   'useage of serial port
        ' If Port.IsOpen = False Then Port.Open()

    End Sub
    'Windows Form Designer generated code 
    '/////ENCRYPTION PROCEDURE 
    Sub Encrypt(ByVal inName As String, ByVal outName As String)
        Try
            Dim storage(4096) As Byte   'create buffer 
            Dim totalBytesWritten As Long = 8  'Keeps track of bytes written. 
            Dim packageSize As Integer   'Specifies the number of bytes written at one time. 
            'Declare the file streams. 
            Dim fin As New FileStream(inName, FileMode.Open, FileAccess.Read)
            Dim fout As New FileStream(outName, FileMode.OpenOrCreate, _
            FileAccess.Write)
            Dim fintxt As New StringReader(TextBox1.Text)
            fout.SetLength(0)
            Dim totalFileLength As Long = fin.Length  'Specifies the size of the source file. 
            'create the Crypto object 
            Dim des As New DESCryptoServiceProvider()
            Dim crStream As New CryptoStream(fout, _
                  des.CreateEncryptor(TheKey, Vector), CryptoStreamMode.Write)
            'flow the streams 
            While totalBytesWritten = totalFileLength
                packageSize = fin.Read(storage, 0, 4096)
                crStream.Write(storage, 0, packageSize)
                totalBytesWritten = Convert.ToInt32(totalBytesWritten + packageSize / des.BlockSize * des.BlockSize)
            End While

            crStream.Close()
        Catch e As Exception
            MsgBox(e.Message)
        End Try
        
    End Sub


    '//////// DECRYPTION PROCEDURE 
    ' This procedure differs from the encryption procedure only in the substitution of 
    'des.CreateDecryptor for des.CreateEncryptor. Also, the error message is different. 
    Sub Decrypt(ByVal inName As String, ByVal outName As String)
        Try
            Dim storage(4096) As Byte
            Dim totalBytesWritten As Long = 8
            Dim packageSize As Integer
            Dim fin As New FileStream(inName, FileMode.Open, FileAccess.Read)
            Dim fout As New FileStream(outName, FileMode.OpenOrCreate, _
            FileAccess.Write)
            fout.SetLength(0)
            Dim totalFileLength As Long = fin.Length
            Dim des As New DESCryptoServiceProvider()
            Dim crStream As New CryptoStream(fout, _
              des.CreateDecryptor(TheKey, Vector), CryptoStreamMode.Write)

            'Dim ex As Exception

            While totalBytesWritten = totalFileLength
                packageSize = fin.Read(storage, 0, 4096)
                crStream.Write(storage, 0, packageSize)
                totalBytesWritten = Convert.ToInt32(totalBytesWritten + packageSize / des.BlockSize * des.BlockSize)
                Console.WriteLine("Processed {0} bytes, {1} bytes total", packageSize, totalBytesWritten)
                MsgBox("Processed {0} bytes, {1} bytes total", packageSize, totalBytesWritten)
            End While
            crStream.Close()
        Catch e As Exception
            MsgBox(e.Message & "Please ensure that you are using the correct password")
        End Try

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        cmd = New SqlCommand("test_club_2_Insert", FinActConn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@name", TextBox1.Text)
        cmd.Parameters.AddWithValue("@name1", TextBox2.Text)
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ' CreateKey(TextBox1.Text)
        'OpenFileDialog1.ShowDialog()
        ' TextBox1.Text = OpenFileDialog1.FileName
    End Sub

    'ENCRYPT/DECRYPT BUTTON 
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim targetfile, sourcefile As String
        'check to see if they've entered a filename at all 
        If TextBox1.Text = "" Or TextBox2.Text = "" Then MsgBox("You must enter a filename and a password.") : Exit Sub
        'check to see if it is a decryption (the filename ends in "xx") 
        Dim ext As String = ""   'file extension 
        Dim mainpath As String   'the file path minus the extension 
        Dim n As Integer   'location of period in filepath 

        n = TextBox1.Text.IndexOf(".")  ' returns -1 if there is no extension 
        If n = -1 Then   'extract the extension 
            ext = TextBox1.Text.Substring(n + 1)
            mainpath = TextBox1.Text.Substring(0, TextBox1.Text.Length - ext.Length - 1)
        Else
            mainpath = TextBox1.Text
        End If

        'check for "xx" at the end of the filename, indicating an already encrypted file: 

        If mainpath.Substring(mainpath.Length - 2) = "xx" Then   'this file will be decrypted 
            'DECRYPT: 
            sourcefile = TextBox1.Text
            'compose filepath by removing the "xx": 

            mainpath = mainpath.Substring(0, mainpath.Length - 2)
            'If ext = "" Then mainpath &= "." & ext
            targetfile = mainpath
            CreateKey(TextBox2.Text)  'create the key 
            Decrypt(sourcefile, targetfile)
            Label3.Text = "Finished decryption..."
            Exit Sub
        End If
        'End If

        'ENCRYPT 
        'there was no "xx" appended, so they must be encrypting a file 

        sourcefile = TextBox1.Text

        'compose the encrypted file's filepath by appending "xx": 
        mainpath &= "xx"
        If ext = "" Then mainpath &= "." & ext
        targetfile = mainpath
        CreateKey(TextBox2.Text)  'create the key 
        Encrypt(sourcefile, targetfile)
        Label3.Text = "Finished encryption..."

    End Sub
    '////// Procedure that hashes the password and creates a key 

    Private Sub CreateKey(ByVal strKey As String)
        ' Byte array to hold key 
        Dim arrByte(7) As Byte
        Dim AscEncod As New ASCIIEncoding()
        Dim i As Integer = 0
        AscEncod.GetBytes(strKey, i, strKey.Length, arrByte, i)

        'Get the hash value of the password 
        Dim hashSha As New SHA1CryptoServiceProvider()
        Dim arrHash() As Byte = hashSha.ComputeHash(arrByte)
        'put the hash value into the key 
        For i = 0 To 7
            TheKey(i) = arrHash(i)
        Next i
        '  MsgBox(TheKey(i))

    End Sub
    '/// this is a trial procedure to check encryption

    
    Private Sub BTN03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN03.Click
            
    End Sub
    '===========
    ' '' ''    Public Class Form1

    ' '' ''        Private WithEvents Tabla As New DataTable

    ' '' ''        Private WithEvents Adaptador As SqlClient.SqlDataAdapter

    ' '' ''        Private Ds3 As New DataSet

    ' '' ''        Private Ds As New DataSet

    ' '' ''        Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    ' '' ''            ''MANEJO DE DATOS CON DATADAPTER

    ' '' ''            Dim Conexion As New SqlClient.SqlConnection

    ' '' ''            Conexion.ConnectionString = "Data source=(local);Initial Catalog=Northwind; User ID=sa; Password=dbsa;"

    ' '' ''            Conexion.Open()

    ' '' ''            'Dim Ds As New DataSet

    ' '' ''            Dim strSQL = "Select CategoryID, CategoryName,Description,Picture From Categories"

    ' '' ''            'Dim Adaptador As New SqlClient.SqlDataAdapter(strSQL, Conexion)

    ' '' ''            Adaptador = New SqlClient.SqlDataAdapter(strSQL, Conexion)

    ' '' ''            Adaptador.Fill(Ds)

    ' '' ''            Dg.DataSource = Ds.Tables(0)

    ' '' ''            Tabla = Ds.Tables(0)

    ' '' ''        End Sub



    ' '' ''        Private Sub Tabla_RowChanging(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs) Handles Tabla.RowChanging

    ' '' ''            Dim Mensaje = MessageBox.Show("Are you sure that you want to modify this cell?", "Modificacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

    ' '' ''            If Mensaje = MsgBoxResult.No Then

    ' '' ''                ' I want if the user select (No) in MessageBox, the Event RowChanged shouldn´t be executed after    ' this event, I want to know the code which is neccesary to stop the execution of the event                ' RowChanged in this line

    ' '' ''            End If



    ' '' ''        Private Sub Tabla_RowChanged(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs) Handles Tabla.RowChanged


    ' '' ''            Dim Conexion As New SqlClient.SqlConnection

    ' '' ''            Conexion.ConnectionString = "Data Source=(local); Initial Catalog=Northwind; User ID=sa; Password=dbsa;"

    ' '' ''            Conexion.Open()

    ' '' ''            '' Comando de Actualizacion de Datos directo a la fuente

    ' '' ''            Dim ComActualizacion As New SqlClient.SqlCommand("Update Categories Set CategoryName='" & Dg.CurrentCell.Value & "' Where CategoryID=" & Dg.Item(0, Dg.CurrentRow.Index).Value, Conexion)

    ' '' ''            Adaptador.UpdateCommand = ComActualizacion

    ' '' ''            '' Comando de Insercion de Datos directo a la fuente

    ' '' ''            Dim ComInsercion As New SqlClient.SqlCommand("Insert Into Categories (CategoryName,Description) Values('Frutos','Frutos prohibidos')", Conexion)

    ' '' ''            Adaptador.InsertCommand = ComInsercion

    ' '' ''            '' Comando de Eliminacion de Datos directo a la fuente

    ' '' ''            Dim ComBorrado As New SqlClient.SqlCommand("Delete Categories Where CategoryID=" & Dg.Item(0, Dg.CurrentRow.Index).Value, Conexion)

    ' '' ''            Adaptador.DeleteCommand = ComBorrado

    ' '' ''            Adaptador.Update(Ds)

    ' '' ''            'Comando.Parameters.Add(New SqlClient.SqlParameter("@Valor", SqlDbType.Int, 4, ParameterDirection.Input))

    ' '' ''            'Comando.Parameters("@Valor").Value = Dg.Item(0, Dg.CurrentRow.Index)

    ' '' ''            'Adaptador.UpdateCommand = "Insercion"

    ' '' ''            'Dim Borrado As DataTable = _

    ' '' ''            'Ds.Tables(0).GetChanges(DataRowState.Modified)

    ' '' ''            'Adaptador.Update(Borrado)




    ' '' ''        End Sub

    ' '' ''End Sub

    ' '' ''    End Class

    '====

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub FinactEmpmstrBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Validate()
        ' 'Me.FinactEmpmstrBindingSource.EndEdit()
        '' Me.FinactEmpmstrTableAdapter.Update(Me.HrPrData08DataSet.FinactEmpmstr)

    End Sub

    Private Sub FillByToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            '  Me.DataTable1TableAdapter.FillBy(Me.HrPrData08DataSet.DataTable1)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        Dim dt As Date = dtp1.Value.Date
        Label4.Text = dtp1.Value
        Label5.Text = dt 'dtp1.Text
        cmd = New SqlCommand("Select (saleentdt) as tDate, (saleentsplrid)as Id,(saleentvno) as Voucher,(saleenttotal) as Amount,saleenttype as tType,splrname from finactsaleentry" _
        & " inner join  finactsplrmstr on finactsaleentry.saleentsplrid=finactsplrmstr.splrid where finactsaleentry.saleentdelstatus=1" _
        & " union select purentdt,purentsplrid, purentvno,purenttotal,purenttype,splrname from finactpurentry inner join  finactsplrmstr on finactpurentry.purentsplrid=finactsplrmstr.splrid where finactpurentry.purentdelstatus=1  ", FinActConn)
        rdr = cmd.ExecuteReader
        Try
            While rdr.Read
                MsgBox(rdr("splrname"))
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            rdr.Close()
        End Try
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        'Offline table creation and insertions 
        Dim Lvew As ListViewItem
        Dim x As Integer = 1
        cmd = New SqlCommand("Select saleordno,saleordqnty from finactsaleorder where salesplrid=11177 order by saleordno", FinActConn)
        rdr = cmd.ExecuteReader
        dt = New DataTable("OrderTable")
        dt.Columns.Add("R_No")
        dt.Columns.Add("Id")
        dt.Columns.Add("Qnty")
        'dt.Columns(0).Unique = True
        While rdr.Read
            dr = dt.NewRow
            dr(0) = x
            dr(1) = rdr(0)
            dr(2) = rdr(1)
            dt.Rows.Add(dr)
            x += 1
        End While
        rdr.Close()
        cmd = Nothing
        MsgBox(dt.Rows.Count)
        For Each dr As DataRow In dt.Rows
            Lvew = LstVew1.Items.Add(dr(1))
            Lvew.SubItems.Add(dr(0))
            Lvew.SubItems.Add(dr(2))
        Next
        For Each dr As DataRow In dt.Rows
            If dr(0) = "Value" Then
                dr.Delete()
                Exit For
            End If
        Next
    End Sub
    Private Sub LinkLabel1_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkLabel1.MouseHover
        'Tool tip
        Label6.Visible = True
        Label6.Text = "Click Me"
    End Sub

    Private Sub LinkLabel1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkLabel1.MouseLeave
        Label6.Visible = False

    End Sub

    Private Sub LstVew1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstVew1.Click
        'This section of coding is dealing with offline to edit a record.
        Dim lvew As ListViewItem
        For Each dr As DataRow In dt.Rows
            If dr(0) = 5 Then
                dr(2) = 8000
            End If
        Next
        LstVew1.Items.Clear()
        For Each dr As DataRow In dt.Rows
            lvew = LstVew1.Items.Add(dr(1))
            lvew.SubItems.Add(dr(0))
            lvew.SubItems.Add(dr(2))
        Next


    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim dt As Date
        dt = Txtdt.Text
        ' MsgBox(dt)
        Try
            cmd = New SqlCommand("sp_app", FinActConn)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@n", "Rafiq")
            cmd.Parameters.AddWithValue("@m", 98)
            cmd.Parameters.AddWithValue("@d", dt)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd = Nothing

        End Try


    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        MsgBox("Deleted")
    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        MsgBox("Edited")
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        MsgBox("Exit")
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        ''required controls are OpenFileDialog1, Richtext box
        ' fso = CreateObject("Scripting.FileSystemObject")
        'If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
        'MySource = OpenFileDialog1.FileName
        'Dim Sqltxt As New IO.FileStream(MySource, FileMode.Open, FileAccess.ReadWrite) '"C:\Setup Generating\Inventory_Control\CreateTable.txt", FileMode.Open, FileAccess.ReadWrite)
        'Dim SqltxtReader As New StreamReader(Sqltxt)
        'SqltxtReader.BaseStream.Seek(0, SeekOrigin.Begin)
        'While SqltxtReader.Peek > -1
        'Richtextbox ''Rcjtxtappnt.Text += SqltxtReader.ReadLine() & " " & ControlChars.CrLf
        'End While
        ' SqltxtReader.Close()
        ' End If

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        'remove all comments before use
        'Public Shared Function EncryptSHA512(ByVal strAs String) As String 
        Dim Bytes() As Byte
        Dim Encoder As New System.Text.UTF8Encoding
        Dim SHA512 As New System.Security.Cryptography.SHA512Managed
        Dim SHA512String As String
        'Bytes = Encoder.GetBytes(Str)
        Bytes = SHA512.ComputeHash(Bytes)
        SHA512String = Convert.ToBase64String(Bytes)
        '   Return SHA512String
        ' End Sub
        ' Dim freeSpace As Long
        ' freeSpace = My.Computer.FileSystem.GetDriveInfo("C:\").TotalFreeSpace

    End Sub
    Private Sub Button9_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        My.Computer.FileSystem.CreateDirectory("C:\NewDirectory_rafiq")
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        NDU1.Select(0, Len(NDU1.Value))
        NDU1.Focus()
        MsgBox("Total Day in March =  " & Date.DaysInMonth(2008, 3))
        'Dim dt As Date
        'Dim dt1 As Date
        ' MsgBox(Date.MaxValue.Month(3))
        ' MsgBox(dt = DateSerial(2008, 3, 31) - (dt1 = DateSerial(2007, 4, 1)))
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        ''Port.Open()
        ''Port.Write(Me.TextBox3.Text & "!%")
        ''Port.Close()
    End Sub


End Class


