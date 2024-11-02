Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Windows.Forms
Imports System.IO

Public Class FrmMainMdi
    Inherits System.Windows.Forms.Form
    Dim CmdChkCo As SqlCommand
    Dim RdrChkco As SqlDataReader
    Dim CurrCulture As System.Globalization.CultureInfo = System.Globalization.CultureInfo.CurrentCulture
    Dim CurrDate As Date

    Private Sub FrmMainMdi_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            Me.Cursor = Cursors.WaitCursor
            AutoDataBackup()
            Me.Cursor = Cursors.Default
            'For Each ChildForm As Form In Me.MdiChildren
            '    ChildForm.Close()
            'Next
        Catch ex As Exception

        End Try
    End Sub
    Private Sub FrmMainMdi1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.WindowState = FormWindowState.Maximized
            Cl_Kbl_Settings()
            Me.Height = Screen.PrimaryScreen.WorkingArea.Height
            Me.Width = Screen.PrimaryScreen.WorkingArea.Width
            Me.SplitContainer1.SplitterDistance = 10 ' Me.Width \ 5
            Me.Top = 0
            Me.Left = 0
            ReDim FrmShow_flag(50)
            ReDim IntHtCmMm(50)
            ReDim Surfix4Cmbx(50)
            MeHeight = Me.Height
            MeWidth = Me.Width
            Panel1.Left = (MeWidth \ 2) - (Panel1.Width \ 2)
            Panel1.Top = (MeHeight \ 2) - (Panel1.Height \ 2)
            FinActSqlConn()
            FinActConn.Open()
            FinActConn1.Open()
            FinActConn2.Open()
            FinActConn3.Open()
            'FinactOdbcCon.Open()
            ' FinactOdbcCon1.Open()
            Show_FrmCsC = True
            Altr_FrmCogate = True
            If Chkco() = True Then Me.Close()
            ChkGroupName()
            Date.TryParse(GetServerCurrentDate(), CurrCulture.DateTimeFormat, Globalization.DateTimeStyles.None, CurrDate)
            ServerCurrentDate = CurrDate.Date
            xVATExlFilePath = Application.StartupPath.Trim '===THIS PATH WILL USE IN VAT EXCEL FILE
            'Dim frm As New FrmWelcomeSplashScreen
            'frm.MdiParent = Me
            'Me.SplitContainer1.Panel2.Controls.Add(frm)
            'frm.BringToFront()
            'frm.Show()
            ' frm.Close()
            If Cl_Kbl = True Then
                Me.SALEORDERToolStripMenuItem.Text = "PACKING NOTE"
            Else
                Me.SALEORDERToolStripMenuItem.Text = "SALE ORDER"
            End If
        Catch ex As Exception
            ' MsgBox(ex.ToString)
            MsgBox(ex.Message)
            Me.Close()
        End Try
        '"Finact_Set_InitialValues"
    End Sub
    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        If Progrs01.Value >= 100 Then
            Timer2.Enabled = False
        Else
            Label2.BackColor = Color.Red
        End If

    End Sub

    Private Sub LOGINToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LOGINToolStripMenuItem.Click
        Dim frmlogin As New FrmLogin
        frmlogin.ShowDialog()
    End Sub

    Private Sub LOGOUTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LOGOUTToolStripMenuItem.Click
        MsgBox("You are successfully Loged off ", MsgBoxStyle.Information, "Login info")
        Application.Restart()
        Me.LOGINToolStripMenuItem.Enabled = True
        Me.LOGOUTToolStripMenuItem.Enabled = False

    End Sub

    Private Sub COMPANYPROFILESToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COMPANYPROFILESToolStripMenuItem.Click
        Dim FrmCoGate As New FrmCoGateway
        FrmCoGate.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmCoGate)
        FrmCoGate.BringToFront()
        FrmCoGate.Show()
    End Sub

    Private Sub CREATENEWUSERToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CREATENEWUSERToolStripMenuItem.Click
        Dim FrmNusr As New FrmCreateUsr
        FrmNusr.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmNusr)
        FrmNusr.BringToFront()
        FrmNusr.Show()
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHANGEPASSToolStripMenuItem1.Click
        Dim FrmAltr As New FrmAltrPass
        FrmAltr.ShowDialog()
    End Sub

    Private Sub BACKUPToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BACKUPToolStripMenuItem.Click
        Try
            BackRestoreDB1()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub EXITToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EXITToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ACCOUNTGROUPMASTERToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ACCOUNTGROUPMASTERToolStripMenuItem.Click
        Dim FrmActMstr As New FrmGrupMstr
        FrmActMstr.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmActMstr)
        FrmActMstr.BringToFront()
        FrmActMstr.BringToFront()
        FrmActMstr.Show()
    End Sub

    Private Sub STOCKGROUPMASTERToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles STOCKGROUPMASTERToolStripMenuItem.Click
        Dim FrmItmgrup As New FrmStokgrup
        FrmItmgrup.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmItmgrup)
        FrmItmgrup.BringToFront()
        FrmItmgrup.BringToFront()
        FrmItmgrup.Show()
    End Sub

    Private Sub CREATENEWACCOUNTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CREATENEWACCOUNTToolStripMenuItem.Click
        Dim FrmActMstrOld As New FrmActMstrOld
        FrmActmstr.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmActmstr)
        FrmActmstr.BringToFront()
        FrmActmstr.Show()
    End Sub

    Private Sub FINDEDITACCOUNTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FINDEDITACCOUNTToolStripMenuItem.Click
        Dim frmfind As New FrmActFindEdit
        frmfind.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(frmfind)
        frmfind.BringToFront()
        frmfind.Show()
    End Sub

    Private Sub LISTOFACCOUNTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LISTOFACCOUNTToolStripMenuItem.Click
        Dim FrmActLst As New FrmActlist
        FrmActLst.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmActLst)
        FrmActLst.BringToFront()
        FrmActLst.Show()
    End Sub

    Private Sub PURCHASEITEMRAWMATERIALSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PURCHASEITEMRAWMATERIALSToolStripMenuItem.Click
        Dim FrmstokItm As New FrmStokItm
        FrmstokItm.MdiParent = Me
        FrmstokItm.rBPurchaseOnly.Checked = True
        Me.SplitContainer1.Panel2.Controls.Add(FrmstokItm)
        FrmstokItm.BringToFront()
        FrmstokItm.Show()
    End Sub

    Private Sub PURCHASEITEMSREADYTOUSEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PURCHASEITEMSREADYTOUSEToolStripMenuItem.Click
        xItmMstrOptn = 1 ' Trading item
        Dim FrmstokItm As New FrmStokItm
        FrmstokItm.MdiParent = Me
        FrmstokItm.rBTradingOnly.Checked = True
        Me.SplitContainer1.Panel2.Controls.Add(FrmstokItm)
        FrmstokItm.BringToFront()
        FrmstokItm.Show()

    End Sub

   

    Private Sub HEIGHTMASTERToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HEIGHTMASTERToolStripMenuItem.Click
        Dim frmhght As New FrmHghtMstr
        frmhght.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(frmhght)
        frmhght.BringToFront()
        frmhght.Show()
    End Sub

    Private Sub WIDTHMASTERToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WIDTHMASTERToolStripMenuItem.Click
        Dim frmwdth As New FrmWdthMstr
        frmwdth.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(frmwdth)
        frmwdth.BringToFront()
        frmwdth.Show()
    End Sub

    Private Sub LENGTHMASTERToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LENGTHMASTERToolStripMenuItem.Click
        Dim frmlnth As New FrmLnthMstr
        frmlnth.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(frmlnth)
        frmlnth.BringToFront()
        frmlnth.Show()
    End Sub

    Private Sub MATERIALMASTERToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MATERIALMASTERToolStripMenuItem.Click
        Dim frmmatrl As New FrmMatrlMstr
        frmmatrl.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(frmmatrl)
        frmmatrl.BringToFront()
        frmmatrl.Show()
    End Sub

    Private Sub GRADEMASTERToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GRADEMASTERToolStripMenuItem.Click
        Dim frmgrad As New FrmGradMstr
        frmgrad.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(frmgrad)
        frmgrad.BringToFront()
        frmgrad.Show()
    End Sub

    Private Sub LOCATIONINNERToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LOCATIONINNERToolStripMenuItem.Click

        Dim FrmInrLoc As New FrmInLocat
        FrmInrLoc.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmInrLoc)
        FrmInrLoc.BringToFront()
        FrmInrLoc.Show()
    End Sub

    Private Sub LOCATIONOUTERToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LOCATIONOUTERToolStripMenuItem.Click
        Dim FrmCsC As New FrmCsCMstr
        FrmCsC.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmCsC)
        FrmCsC.BringToFront()
        FrmCsC.Show()
    End Sub

    Private Sub PROCESSMASTERToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PROCESSMASTERToolStripMenuItem.Click
        Dim frmPrcess As New FrmProcessMstr
        frmPrcess.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(frmPrcess)
        frmPrcess.BringToFront()
        frmPrcess.Show()

    End Sub

    Private Sub CARRIERMASTERToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CARRIERMASTERToolStripMenuItem.Click
        Dim FrmCari As New FrmCarriermstr
        FrmCari.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmCari)
        FrmCari.BringToFront()
        FrmCari.Show()
    End Sub

    Private Sub MACHINEMASTERToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MACHINEMASTERToolStripMenuItem.Click
        Dim FrmMchin As New FrmMachineMstr
        FrmMchin.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmMchin)
        FrmMchin.BringToFront()
        FrmMchin.Show()
    End Sub
    Private Sub DIEMASTERToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DIEMASTERToolStripMenuItem.Click
        Dim FrmDie As New FrmDieMaster
        FrmDie.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmDie)
        FrmDie.BringToFront()
        FrmDie.Show()
    End Sub

    Private Sub NARRATIONMASTERToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NARRATIONMASTERToolStripMenuItem.Click
        Dim FrmNrr As New FrmNarrationMstr
        FrmNrr.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmNrr)
        FrmNrr.BringToFront()
        FrmNrr.Show()
    End Sub

    Private Sub DEPARTMENTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DEPARTMENTToolStripMenuItem.Click
        Dim FrmDept As New FrmDeptMstr
        FrmDept.MdiParent = Me
        FrmDept.BringToFront()
        Me.SplitContainer1.Panel2.Controls.Add(FrmDept)
        FrmDept.Show()
    End Sub

    Private Sub BRANCHToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRANCHToolStripMenuItem.Click
        Dim frmbrnch As New FrmBrnch
        frmbrnch.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(frmbrnch)
        frmbrnch.BringToFront()
        frmbrnch.Show()
    End Sub

    Private Sub WORKNAMEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WORKNAMEToolStripMenuItem.Click
        Dim FrmWrk As New FrmWrkName
        FrmWrk.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmWrk)
        FrmWrk.BringToFront()
        FrmWrk.Show()
    End Sub

    Private Sub CATEGORYToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CATEGORYToolStripMenuItem.Click
        Dim Frmcat As New FrmCatgry
        Frmcat.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(Frmcat)
        Frmcat.BringToFront()
        Frmcat.Show()
    End Sub

    Private Sub JOBTITLEDESIToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JOBTITLEDESIToolStripMenuItem.Click
        Dim frmJtitle As New FrmJobTitle
        frmJtitle.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(frmJtitle)
        frmJtitle.BringToFront()
        frmJtitle.Show()
    End Sub

    Private Sub JOINNINGKITToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JOINNINGKITToolStripMenuItem.Click
        Dim FrmPayrol As New FrmPayRoll
        FrmPayrol.MdiParent = FrmMainMdi.ActiveForm
        Me.SplitContainer1.Panel2.Controls.Add(FrmPayrol)
        FrmPayrol.BringToFront()
        FrmPayrol.Show()
    End Sub

    Private Sub PAYHEADSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PAYHEADSToolStripMenuItem.Click
        Dim FrmPayh As New FrmPayhed
        FrmPayh.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmPayh)
        FrmPayh.BringToFront()
        FrmPayh.Show()
    End Sub

    Private Sub SHIFTMASTERToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SHIFTMASTERToolStripMenuItem.Click
        Dim frmsift As New FrmTimeMstr
        frmsift.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(frmsift)
        frmsift.BringToFront()
        frmsift.Show()
    End Sub

    Private Sub LEAVEMASTERToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LEAVEMASTERToolStripMenuItem.Click
        Dim frmlev As New FrmLeaveMstr
        frmlev.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(frmlev)
        frmlev.BringToFront()
        frmlev.Show()
    End Sub

    Private Sub ATTENDENCEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ATTENDENCEToolStripMenuItem.Click
        Dim FrmAtend As New FrmAttend
        FrmAtend.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmAtend)
        FrmAtend.BringToFront()
        FrmAtend.Show()
    End Sub

    Private Sub LOANANDADVANCESToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LOANANDADVANCESToolStripMenuItem.Click
        Dim frmlonadvance As New FrmAdvance
        frmlonadvance.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(frmlonadvance)
        frmlonadvance.BringToFront()
        frmlonadvance.Show()
    End Sub

    Private Sub MANUALToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MANUALToolStripMenuItem.Click
        Dim frmsalry As New FrmSalry
        frmsalry.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(frmsalry)
        frmsalry.BringToFront()
        frmsalry.Show()
    End Sub

    Private Sub AUTOToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AUTOToolStripMenuItem.Click
        Dim FrmAsal As New FrmAutoSalary
        FrmAsal.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmAsal)
        FrmAsal.BringToFront()
        FrmAsal.Show()
    End Sub

    Private Sub FINEPENELITYToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FINEPENELITYToolStripMenuItem.Click
        Dim FrmFn As New FrmFine
        FrmFn.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmFn)
        FrmFn.BringToFront()
        FrmFn.Show()
    End Sub

    Private Sub APPRAISALToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles APPRAISALToolStripMenuItem.Click
        Dim FrmAprSl As New FrmAppraisal
        FrmAprSl.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmAprSl)
        FrmAprSl.BringToFront()
        FrmAprSl.Show()
    End Sub

    Private Sub FULLFINALToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FULLFINALToolStripMenuItem.Click
        Dim FrmSal As New FrmSalry
        FrmSal.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmSal)
        FrmSal.BringToFront()
        FrmSal.Show()
    End Sub

    Private Sub TARGETSETTINGCALCULATIONToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TARGETSETTINGCALCULATIONToolStripMenuItem.Click
        Dim FrmTrgt As New FrmTarget
        FrmTrgt.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmTrgt)
        FrmTrgt.BringToFront()
        FrmTrgt.Show()
    End Sub

    Private Sub BANKRECONCILEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BANKRECONCILEToolStripMenuItem.Click
        Dim frmBnkR As New FrmBnkReconcile
        frmBnkR.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(frmBnkR)
        frmBnkR.BringToFront()
        frmBnkR.Show()
    End Sub

    Private Sub JOURNALToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JOURNALToolStripMenuItem.Click
        Dim frmjrnl As New FrmJrnl
        frmjrnl.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(frmjrnl)
        frmjrnl.BringToFront()
        frmjrnl.Show()
    End Sub

    Private Sub PURCHASEORDERToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PURCHASEORDERToolStripMenuItem.Click
        Dim frmpurordr As New FrmTranPurOrderMain
        frmpurordr.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(frmpurordr)
        frmpurordr.BringToFront()
        frmpurordr.Show()
    End Sub

    Private Sub SALEORDERToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SALEORDERToolStripMenuItem.Click
        Dim frmsaleordr As New FrmTranSaleOrderMain
        frmsaleordr.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(frmsaleordr)
        frmsaleordr.BringToFront()
        frmsaleordr.Show()
    End Sub

    Private Sub PURCHASEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PURCHASEToolStripMenuItem.Click
        xMACH_xPurxBILLING = False
        Dim frmtpm As New FrmTranPurentryMain
        frmtpm.MdiParent = Me
        frmtpm.TopMost = True
        Me.SplitContainer1.Panel2.Controls.Add(frmtpm)
        frmtpm.BringToFront()
        frmtpm.Show()
    End Sub

    Private Sub PURCHASEBILLINGUSINGORDERToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PURCHASEBILLINGUSINGORDERToolStripMenuItem.Click
        Dim FrmPurEnt As New FrmTranPurentryOrderMain
        FrmPurEnt.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmPurEnt)
        FrmPurEnt.BringToFront()
        FrmPurEnt.Show()
    End Sub

    Private Sub SALEBILLINGToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SALEBILLINGToolStripMenuItem.Click
        xMACH_xBILLING = False
        Dim FrmSdM As New FrmTranSaleentryMain
        FrmSdM.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmSdM)
        FrmSdM.BringToFront()
        FrmSdM.Show()
    End Sub

    Private Sub SALEBILLINGUSINGSALEORDERToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SALEBILLINGUSINGSALEORDERToolStripMenuItem.Click
        Dim frmTsom As New FrmTranSaleentryOrderMain
        frmTsom.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(frmTsom)
        frmTsom.BringToFront()
        frmTsom.Show()
    End Sub

    Private Sub RECEIPTBACKNEWToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RECEIPTBACKNEWToolStripMenuItem.Click
        Dim frmDrNote As New FrmTranIssueDrNote
        frmDrNote.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(frmDrNote)
        frmDrNote.BringToFront()
        frmDrNote.Show()
    End Sub

    Private Sub EDITDELETEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EDITDELETEToolStripMenuItem.Click
        Dim frmDrNEdt As New FrmTranIssueDrNoteEditMain
        frmDrNEdt.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(frmDrNEdt)
        frmDrNEdt.BringToFront()
        frmDrNEdt.Show()
    End Sub

    Private Sub RETURNEDBACKNEWToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RETURNEDBACKNEWToolStripMenuItem.Click
        Dim FrmCrNote As New FrmTranIssueCrNote
        FrmCrNote.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmCrNote)
        FrmCrNote.BringToFront()
        FrmCrNote.Show()
    End Sub

    Private Sub EDITDELETEToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EDITDELETEToolStripMenuItem1.Click
        Dim FrmCrNEdt As New FrmTranIssueCrNoteEditMain
        FrmCrNEdt.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmCrNEdt)
        FrmCrNEdt.BringToFront()

        FrmCrNEdt.Show()
    End Sub

    Private Sub DEBITNOTEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DEBITNOTEToolStripMenuItem.Click
        Dim frndrn As New FrmDrNote
        frndrn.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(frndrn)
        frndrn.BringToFront()
        frndrn.Show()
    End Sub

    Private Sub CREDITNOTEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CREDITNOTEToolStripMenuItem.Click
        Dim FrmCrn As New FrmCrNote
        FrmCrn.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmCrn)
        FrmCrn.BringToFront()
        FrmCrn.Show()
    End Sub

    Private Sub WORKORDERToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WORKORDERToolStripMenuItem.Click
        Dim frmwrk As New FrmWorkOrder
        frmwrk.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(frmwrk)
        frmwrk.BringToFront()
        frmwrk.Show()
    End Sub

    Private Sub MATERIALMOVEMENTToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MATERIALMOVEMENTToolStripMenuItem1.Click
        Dim frmmm As New FrmMatrlMove
        frmmm.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(frmmm)
        frmmm.BringToFront()
        frmmm.Show()
    End Sub

    Private Sub PRODUCTIONINPUTToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PRODUCTIONINPUTToolStripMenuItem1.Click
        Dim frmprod As New FrmTranProductionMovment
        frmprod.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(frmprod)
        frmprod.BringToFront()
        frmprod.Show()
    End Sub

    Private Sub MERGEANACCOUNTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MERGEANACCOUNTToolStripMenuItem.Click
        Dim FrmMrg As New FrmActMerge
        FrmMrg.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmMrg)
        FrmMrg.BringToFront()
        FrmMrg.Show()
    End Sub

    Private Sub DAYBOOKToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DAYBOOKToolStripMenuItem.Click
        Dim frmdbook As New FrmRptDBook
        frmdbook.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(frmdbook)
        frmdbook.BringToFront()
        frmdbook.Show()
    End Sub

    Private Sub CASHBOOKToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CASHBOOKToolStripMenuItem.Click
        Dim Frmcbook As New FrmRptCashBook
        Frmcbook.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(Frmcbook)
        Frmcbook.BringToFront()
        Frmcbook.Show()
    End Sub

    Private Sub MULTICOLUMNCASHBOOKToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MULTICOLUMNCASHBOOKToolStripMenuItem.Click
        Try
            MsgBox("Under development", MsgBoxStyle.Information, "Under Development")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub JOURNALToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JOURNALToolStripMenuItem1.Click
        Dim frmjrnl As New FrmRptJrnl
        frmjrnl.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(frmjrnl)
        frmjrnl.BringToFront()
        frmjrnl.Show()
    End Sub

    Private Sub BANKBOOKToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BANKBOOKToolStripMenuItem.Click
        Dim frmbnkbok As New FrmRptBnkBook
        frmbnkbok.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(frmbnkbok)
        frmbnkbok.BringToFront()
        frmbnkbok.Show()
    End Sub

    Private Sub LEDGERCUSTOMERVENDORToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LEDGERCUSTOMERVENDORToolStripMenuItem.Click
        Dim frmRptGL As New FrmRptGenLdgr
        frmRptGL.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(frmRptGL)
        frmRptGL.BringToFront()
        frmRptGL.Show()
    End Sub

    Private Sub GENERALLEDGERToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GENERALLEDGERToolStripMenuItem.Click
        Dim frmGLedger As New FrmRptGenLedger
        frmGLedger.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(frmGLedger)
        frmGLedger.BringToFront()
        frmGLedger.Show()
    End Sub

    Private Sub GROUPSUMMARYToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GROUPSUMMARYToolStripMenuItem.Click
        Dim FrmGrupSumry As New FrmRptGroupSummary
        FrmGrupSumry.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmGrupSumry)
        FrmGrupSumry.BringToFront()
        FrmGrupSumry.Show()
    End Sub

    Private Sub DEBITNOTEREGISTERToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DEBITNOTEREGISTERToolStripMenuItem.Click
        Dim frmdrn1 As New FrmRptDebitNote
        frmdrn1.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(frmdrn1)
        frmdrn1.BringToFront()
        frmdrn1.Show()
    End Sub

    Private Sub CREDITNOTEREGISTERToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CREDITNOTEREGISTERToolStripMenuItem.Click
        Dim frmcrn1 As New FrmRptCreditNote
        frmcrn1.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(frmcrn1)
        frmcrn1.BringToFront()
        frmcrn1.Show()
    End Sub

    Private Sub MEMORANDUMREGISTERToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MEMORANDUMREGISTERToolStripMenuItem.Click
        MsgBox("Under development", MsgBoxStyle.Information, "Under Development")
    End Sub

    Private Sub RECEIPTVOUCHERToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RECEIPTVOUCHERToolStripMenuItem.Click
        Dim FrmRcpt As New FrmRptReceiptVochr
        FrmRcpt.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmRcpt)
        FrmRcpt.BringToFront()
        FrmRcpt.Show()
    End Sub

    Private Sub PAYMENTVOUCHSERToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PAYMENTVOUCHSERToolStripMenuItem.Click
        Dim frmpay As New FrmRptPaymnttVochr
        frmpay.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(frmpay)
        frmpay.BringToFront()
        frmpay.Show()
    End Sub

    Private Sub VERTICALBALANCESHEETToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VERTICALBALANCESHEETToolStripMenuItem.Click
        Dim frmBalVerti As New FrmRptBalanceSheetVERTI
        frmBalVerti.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(frmBalVerti)
        frmBalVerti.BringToFront()
        frmBalVerti.Show()
    End Sub

    Private Sub HORIZONTALBALANCESHEETToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HORIZONTALBALANCESHEETToolStripMenuItem.Click
        Dim frmBal As New FrmRptBalanceSheet
        frmBal.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(frmBal)
        frmBal.BringToFront()
        frmBal.Show()
    End Sub

    Private Sub TRADINGACCOUNTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TRADINGACCOUNTToolStripMenuItem.Click
        Dim Frmtrdng As New FrmRptTrading
        Frmtrdng.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(Frmtrdng)
        Frmtrdng.BringToFront()
        Frmtrdng.Show()
    End Sub

    Private Sub PROFITLOSSACCOUNTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PROFITLOSSACCOUNTToolStripMenuItem.Click
        Dim frmpl As New FrmRptProfitandloss
        frmpl.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(frmpl)
        frmpl.BringToFront()
        frmpl.Show()
    End Sub

    Private Sub TRIALBALANCEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TRIALBALANCEToolStripMenuItem.Click
        Dim frmtrial As New FrmRptTrial
        frmtrial.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(frmtrial)
        frmtrial.BringToFront()
        frmtrial.Show()
    End Sub

    Private Sub RAWMATETIALSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RAWMATETIALSToolStripMenuItem.Click
        Dim FrmSreg As New FrmCrRptStokRegistr
        FrmSreg.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmSreg)
        FrmSreg.BringToFront()
        FrmSreg.Show()
    End Sub

    Private Sub READYTOUSEITEMSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles READYTOUSEITEMSToolStripMenuItem.Click
        Try
            If Cl_TimeIndia = True Or Cl_TimeRubber = True Then
                Dim FrmSreg2 As New FrmCrRptStokRegTrdTrding
                FrmSreg2.MdiParent = Me
                Me.SplitContainer1.Panel2.Controls.Add(FrmSreg2)
                FrmSreg2.BringToFront()
                FrmSreg2.Show()
            Else
                xItmStokOptn = 1
                xItmStokSumry = 0
                Dim FrmSreg2 As New FrmCrRptStokReg_KblType
                FrmSreg2.MdiParent = Me
                Me.SplitContainer1.Panel2.Controls.Add(FrmSreg2)
                FrmSreg2.BringToFront()
                FrmSreg2.Show()
            End If
        Catch ex As Exception

        End Try
     
    End Sub

    Private Sub FINISHEDSALEITEMSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FINISHEDSALEITEMSToolStripMenuItem.Click
        Try
            If Cl_TimeIndia = True Or Cl_TimeRubber = True Then
                Dim FrmSreg6 As New FrmCrRptStokRegFinishedItmDetailed
                FrmSreg6.MdiParent = Me
                Me.SplitContainer1.Panel2.Controls.Add(FrmSreg6)
                FrmSreg6.BringToFront()
                FrmSreg6.Show()
            Else
                xItmStokOptn = 0
                xItmStokSumry = 0
                Dim FrmSreg6 As New FrmCrRptStokReg_KblType
                FrmSreg6.MdiParent = Me
                Me.SplitContainer1.Panel2.Controls.Add(FrmSreg6)
                FrmSreg6.BringToFront()
                FrmSreg6.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PRODUCTIONSEMIFINISHEDITEMSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PRODUCTIONSEMIFINISHEDITEMSToolStripMenuItem.Click
        Dim FrmSreg4 As New FrmCrRptStokProdSemiProdSemiDetailed
        FrmSreg4.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmSreg4)
        FrmSreg4.BringToFront()
        FrmSreg4.Show()
    End Sub

    Private Sub RAWMATERIALSITEMSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RAWMATERIALSITEMSToolStripMenuItem.Click
        Dim FrmSreg1 As New FrmCrRptStokRegSumristrSummary
        FrmSreg1.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmSreg1)
        FrmSreg1.BringToFront()
        FrmSreg1.Show()
    End Sub

    Private Sub READYTOUSEITEMSToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles READYTOUSEITEMSToolStripMenuItem1.Click
        Try
            If Cl_TimeIndia = True Or Cl_TimeRubber = True Then
                Dim FrmSreg3 As New FrmCrRptStokRegTrdsumrTrdingSummry
                FrmSreg3.MdiParent = Me
                Me.SplitContainer1.Panel2.Controls.Add(FrmSreg3)
                FrmSreg3.BringToFront()
                FrmSreg3.Show()
            Else
                xItmStokSumry = 1
                xItmStokOptn = 1
                Dim FrmSreg3 As New FrmCrRptStokReg_KblType
                FrmSreg3.MdiParent = Me
                Me.SplitContainer1.Panel2.Controls.Add(FrmSreg3)
                FrmSreg3.BringToFront()
                FrmSreg3.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FINISHEDSALEITEMSToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FINISHEDSALEITEMSToolStripMenuItem1.Click
        If Cl_TimeIndia = True Or Cl_TimeRubber = True Then
            Dim FrmSreg7 As New FrmCrRptStokRegFinishdItmSummry
            FrmSreg7.MdiParent = Me
            Me.SplitContainer1.Panel2.Controls.Add(FrmSreg7)
            FrmSreg7.BringToFront()
            FrmSreg7.Show()
        Else
            xItmStokOptn = 0
            xItmStokSumry = 1
            Dim FrmSreg7 As New FrmCrRptStokReg_KblType
            FrmSreg7.MdiParent = Me
            Me.SplitContainer1.Panel2.Controls.Add(FrmSreg7)
            FrmSreg7.BringToFront()
            FrmSreg7.Show()
        End If
    End Sub

    Private Sub PRODUCTIONSEMIFINISHEDITEMSToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PRODUCTIONSEMIFINISHEDITEMSToolStripMenuItem1.Click
        Dim FrmSreg5 As New FrmCrRptStokProdSemiProdSemiSummary
        FrmSreg5.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmSreg5)
        FrmSreg5.BringToFront()
        FrmSreg5.Show()
    End Sub

    Private Sub STOCKAGEINGANYLISToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles STOCKAGEINGANYLISToolStripMenuItem.Click
        MsgBox("Under Development")
    End Sub

    Private Sub REORDERSTATUSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles REORDERSTATUSToolStripMenuItem.Click
        MsgBox("Under Development")
    End Sub

    Private Sub NAGETIVESTOCKToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NAGETIVESTOCKToolStripMenuItem.Click
        MsgBox("Under Development")
    End Sub

    Private Sub PURCHASEORDERToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PURCHASEORDERToolStripMenuItem1.Click
        Dim FrmPurOr1 As New FrmCrRptPurOrdr
        FrmPurOr1.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmPurOr1)
        FrmPurOr1.BringToFront()
        FrmPurOr1.Show()
    End Sub

    Private Sub PURCHASEToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PURCHASEToolStripMenuItem2.Click
        Dim FrmPurOr2 As New FrmCrRptPurOrderBook
        FrmPurOr2.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmPurOr2)
        FrmPurOr2.BringToFront()
        FrmPurOr2.Show()
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        xCrRptPurchase = False
        Dim FrmPur2 As New FrmCrRptPurRegstr
        FrmPur2.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmPur2)
        FrmPur2.Show()
    End Sub

    Private Sub PURCHASEBILLPENDINGToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PURCHASEBILLPENDINGToolStripMenuItem.Click
        MsgBox("Under Development")
    End Sub

    Private Sub RECEIPTNOTEVOUCHERToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RECEIPTNOTEVOUCHERToolStripMenuItem.Click
        Dim FrmPur1 As New FrmCrRptPurRegBill
        FrmPur1.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmPur1)
        FrmPur1.BringToFront()
        FrmPur1.Show()
    End Sub

    Private Sub SALEORDERToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SALEORDERToolStripMenuItem1.Click
        Dim FrmSaleOr As New frmcrrptsaleorder
        FrmSaleOr.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmSaleOr)
        FrmSaleOr.BringToFront()
        FrmSaleOr.Show()
    End Sub

    Private Sub SALEORDERBOOKToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SALEORDERBOOKToolStripMenuItem.Click
        Dim FrmSaleOr1 As New FrmCrRptSaleOrderBook
        FrmSaleOr1.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmSaleOr1)
        FrmSaleOr1.BringToFront()
        FrmSaleOr1.Show()
    End Sub

    Private Sub SALEREGISTERToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SALEREGISTERToolStripMenuItem.Click
        xCrRptSale = False
        Dim frmsale As New FrmCrRptSaleRegstr
        frmsale.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(frmsale)
        frmsale.BringToFront()
        frmsale.Show()
    End Sub

    Private Sub SALEINVOICEDETAILEDToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SALEINVOICEDETAILEDToolStripMenuItem.Click
        Dim FrmSale2 As Form
        If Cl_Kbl = True Then
            FrmSale2 = New FrmCrRpt_KBL_SaleBillPrinting
        Else
            FrmSale2 = New FrmCrRptSaleBill
        End If
        FrmSale2.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmSale2)
        FrmSale2.BringToFront()
        FrmSale2.Show()
    End Sub

    Private Sub SALEINVOICESIMPLEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SALEINVOICESIMPLEToolStripMenuItem.Click
        Dim FrmSale3 As New FrmCrRptSaleBillWithoutInfo
        FrmSale3.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmSale3)
        FrmSale3.BringToFront()
        FrmSale3.Show()
    End Sub

    Private Sub DELIVERYPACKINGNOTEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DELIVERYPACKINGNOTEToolStripMenuItem.Click
        Dim FrmPn As New FrmCrRptPackNote
        FrmPn.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmPn)
        FrmPn.BringToFront()
        FrmPn.Show()
    End Sub

    Private Sub SALEPRICELISTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SALEPRICELISTToolStripMenuItem.Click
        Dim FrmSpl As New FrmCrRptSplPriceLst
        FrmSpl.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmSpl)
        FrmSpl.BringToFront()
        FrmSpl.Show()
    End Sub


    Private Sub DEPARTMENTToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DEPARTMENTToolStripMenuItem1.Click
        Dim FrmCrd As New FrmCrRptDept
        FrmCrd.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmCrd)
        FrmCrd.BringToFront()
        FrmCrd.Show()
    End Sub

    Private Sub OUTERToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OUTERToolStripMenuItem.Click
        Dim FrmCLoc As New FrmCrRptlocatn
        FrmCLoc.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmCLoc)
        FrmCLoc.BringToFront()
        FrmCLoc.Show()
    End Sub

    Private Sub INNERToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles INNERToolStripMenuItem.Click
        Dim FrmCrInr As New FrmCrRptcsciner
        FrmCrInr.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmCrInr)
        FrmCrInr.BringToFront()
        FrmCrInr.Show()
    End Sub

    Private Sub BRANCHToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRANCHToolStripMenuItem1.Click
        Dim FrmCrBrn As New FrmCrRptbrnch
        FrmCrBrn.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmCrBrn)
        FrmCrBrn.BringToFront()
        FrmCrBrn.Show()
    End Sub

    Private Sub WORKNAMEToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WORKNAMEToolStripMenuItem1.Click
        Dim FrmCrWrkN As New FrmCrRptwrkname
        FrmCrWrkN.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmCrWrkN)
        FrmCrWrkN.BringToFront()
        FrmCrWrkN.Show()
    End Sub

    Private Sub CATEGORYGRADEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CATEGORYGRADEToolStripMenuItem.Click
        Dim FrmCrCat As New FrmCrRptCatgri
        FrmCrCat.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmCrCat)
        FrmCrCat.BringToFront()
        FrmCrCat.Show()
    End Sub

    Private Sub DESIGNATIONJOBTITLEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DESIGNATIONJOBTITLEToolStripMenuItem.Click
        Dim FrmCrDesi As New FrmCrRptdesi
        FrmCrDesi.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmCrDesi)
        FrmCrDesi.BringToFront()
        FrmCrDesi.Show()
    End Sub

    Private Sub EMPLOYEESINFOToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EMPLOYEESINFOToolStripMenuItem.Click
        Dim FrmCrEmpIn As New FrmCrRptEmpInfo
        FrmCrEmpIn.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmCrEmpIn)
        FrmCrEmpIn.BringToFront()
        FrmCrEmpIn.Show()
    End Sub

    Private Sub MONTHLYATTENDANCEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MONTHLYATTENDANCEToolStripMenuItem.Click
        Dim FrmCrEmpAtnd As New FrmCrRptEmpAttend
        FrmCrEmpAtnd.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmCrEmpAtnd)
        FrmCrEmpAtnd.BringToFront()
        FrmCrEmpAtnd.Show()
    End Sub

    Private Sub SALARYSLIPToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SALARYSLIPToolStripMenuItem.Click
        Dim FrmCrEmpSalslp As New FrmCrRptEmpSalSlip
        FrmCrEmpSalslp.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmCrEmpSalslp)
        FrmCrEmpSalslp.BringToFront()
        FrmCrEmpSalslp.Show()
    End Sub

    Private Sub SALARYWAGESREGISTERToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SALARYWAGESREGISTERToolStripMenuItem.Click
        Dim FrmCrSmr As New FrmCrRptSumrySalWag
        FrmCrSmr.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmCrSmr)
        FrmCrSmr.BringToFront()
        FrmCrSmr.Show()
    End Sub

    Private Sub SALARTWAGESSUMMARYToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SALARTWAGESSUMMARYToolStripMenuItem.Click
        Dim FrmCrSal As New FrmCrRptSalSumry
        FrmCrSal.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmCrSal)
        FrmCrSal.BringToFront()
        FrmCrSal.Show()
    End Sub

    Private Sub BONUSDETAILSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BONUSDETAILSToolStripMenuItem.Click
        Dim FrmCrBons As New FrmCrRptbonus
        FrmCrBons.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmCrBons)
        FrmCrBons.BringToFront()
        FrmCrBons.Show()
    End Sub

    Private Sub LEAVEWITHWAGESToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LEAVEWITHWAGESToolStripMenuItem.Click
        Dim FrmCrLevSmr As New FrmCrRptLevSumary
        FrmCrLevSmr.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmCrLevSmr)
        FrmCrLevSmr.BringToFront()
        FrmCrLevSmr.Show()
    End Sub

    Private Sub FORMNO6ESIToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FORMNO6ESIToolStripMenuItem.Click
        Dim FrmCrF6 As New FrmCrRptEsiForm6
        FrmCrF6.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmCrF6)
        FrmCrF6.BringToFront()
        FrmCrF6.Show()
    End Sub

    Private Sub FORMNO1ESIToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FORMNO1ESIToolStripMenuItem.Click
        Dim FrmCrF1 As New FrmCrRptEsiForm1
        FrmCrF1.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmCrF1)
        FrmCrF1.BringToFront()
        FrmCrF1.Show()
    End Sub

    Private Sub ANNEXUREHESIBANKCHALLANToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ANNEXUREHESIBANKCHALLANToolStripMenuItem.Click
        Dim FrmCrBnk As New FrmCrRptEsiBnkChlan
        FrmCrBnk.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmCrBnk)
        FrmCrBnk.BringToFront()
        FrmCrBnk.Show()
    End Sub

    Private Sub RETURNToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RETURNToolStripMenuItem.Click
        Dim FrmCrContri As New FrmCrRptRoContri
        FrmCrContri.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmCrContri)
        FrmCrContri.BringToFront()
        FrmCrContri.Show()
    End Sub

    Private Sub FORMNO7ESIToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FORMNO7ESIToolStripMenuItem.Click
        Dim FrmCrCCrd As New FrmCrRptEsiContriCard
        FrmCrCCrd.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmCrCCrd)
        FrmCrCCrd.BringToFront()
        FrmCrCCrd.Show()
    End Sub

    Private Sub EPFFORMNO6ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EPFFORMNO6ToolStripMenuItem.Click
        Dim FrmCrF2 As New FrmCrRptEpfFrm2
        FrmCrF2.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmCrF2)
        FrmCrF2.BringToFront()
        FrmCrF2.Show()
    End Sub

    Private Sub EPFFORMNO5ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EPFFORMNO5ToolStripMenuItem.Click
        Dim FrmEpfF5 As New FrmCrRptEPFfrm5
        FrmEpfF5.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmEpfF5)
        FrmEpfF5.BringToFront()
        FrmEpfF5.Show()
    End Sub

    Private Sub EPFMONTHLYRETURNCOVERLETTERToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EPFMONTHLYRETURNCOVERLETTERToolStripMenuItem.Click
        Dim Frm7Pf As New FrmCrRptActSec7PF
        Frm7Pf.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(Frm7Pf)
        Frm7Pf.BringToFront()
        Frm7Pf.Show()
    End Sub

    Private Sub EPFANNUALRETURNCOVERLETTERToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EPFANNUALRETURNCOVERLETTERToolStripMenuItem.Click
        Dim FrmCrEpfaltr As New FrmCrRptEpfAnlrtrncvrltr
        FrmCrEpfaltr.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmCrEpfaltr)
        FrmCrEpfaltr.BringToFront()
        FrmCrEpfaltr.Show()
    End Sub

    Private Sub EPFFORMNO6AToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EPFFORMNO6AToolStripMenuItem.Click
        Dim FrmCrEpf6 As New FrmCrRptEPFfrm6A
        FrmCrEpf6.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmCrEpf6)
        FrmCrEpf6.BringToFront()
        FrmCrEpf6.Show()
    End Sub

    Private Sub EPFFORM3AToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EPFFORM3AToolStripMenuItem.Click
        Dim FrmCrEpf3a As New FrmCrRptEPF_Frm3A
        FrmCrEpf3a.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmCrEpf3a)
        FrmCrEpf3a.BringToFront()
        FrmCrEpf3a.Show()
    End Sub

    Private Sub EPFCONTRIBUTIONCARDToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EPFCONTRIBUTIONCARDToolStripMenuItem.Click
        Dim FrmCrEpfCc As New FrmCrRptEpFcntriCard
        FrmCrEpfCc.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmCrEpfCc)
        FrmCrEpfCc.BringToFront()
        FrmCrEpfCc.Show()
    End Sub

    Private Sub EPFFORM13AToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EPFFORM13AToolStripMenuItem.Click
        Dim FrmCr13a As New FrmCrRptForm13A
        FrmCr13a.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmCr13a)
        FrmCr13a.BringToFront()
        FrmCr13a.Show()
    End Sub

    Private Sub EPFFORMNO10ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EPFFORMNO10ToolStripMenuItem.Click
        Dim FrmCrF10 As New FrmCrRptForm10
        FrmCrF10.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmCrF10)
        FrmCrF10.BringToFront()
        FrmCrF10.Show()
    End Sub

    Private Sub EPFFORM12AToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EPFFORM12AToolStripMenuItem.Click
        Dim FrmF12a As New FrmCrRptFrm12A
        FrmF12a.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmF12a)
        FrmF12a.BringToFront()
        FrmF12a.Show()
    End Sub
    Private Sub EPFCOMBINEDToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EPFCOMBINEDToolStripMenuItem.Click
        Dim FrmBnkChln As New FrmCrRptEPFBnkChlan
        FrmBnkChln.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmBnkChln)
        FrmBnkChln.BringToFront()
        FrmBnkChln.Show()
    End Sub
    Private Function Chkco() As Boolean

        Dim DcrypConame As New EnCryp_DeCryp_String
        Dim Fdate As Date
        CmdChkCo = New SqlCommand("select * from finactcogatemstr", FinActConn)
        Try
            RdrChkco = CmdChkCo.ExecuteReader
            While RdrChkco.Read
                If RdrChkco.HasRows = True Then

                    For Each Tls As ToolStripMenuItem In Me.Ms1.Items
                        Tls.Enabled = False
                        Tls.Visible = False
                    Next

                    Me.ADMINISTRATORToolStripMenuItem.Visible = True
                    Me.ADMINISTRATORToolStripMenuItem.Enabled = True

                    Me.ABOUTUSToolStripMenuItem.Visible = True
                    Me.ABOUTUSToolStripMenuItem.Enabled = True

                    Me.LOGINToolStripMenuItem.Enabled = True
                    Me.CREATENEWUSERToolStripMenuItem.Visible = False
                    Me.COMPANYPROFILESToolStripMenuItem.Visible = False
                    Me.BACKUPToolStripMenuItem.Visible = False
                    Me.RESTOREToolStripMenuItem.Visible = False
                    Me.CHANGEPASSToolStripMenuItem1.Visible = False
                    Me.ToolStripMenuItem4.Visible = False
                    Fdate = RdrChkco("costrtdt")
                    If CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy" Then
                        Fdate = Format(Fdate.Date, "MM/dd/yyyy")
                    ElseIf CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern = "M/d/yyyy" Then
                        Fdate = Format(Fdate.Date, "MM/dd/yyyy")
                    ElseIf CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern = "dd-MM-yyyy" Then
                        Fdate = Format(Fdate.Date, "MM/dd/yyyy")
                    ElseIf CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern = "MM/dd/yyyy" Then
                        Fdate = Format(Fdate, "dd/MM/yyyy")
                    Else
                        MsgBox("Invalid Date Format! It should be 'MM/dd/yyyy' or  'dd/MM/yyyy' ", MsgBoxStyle.Critical, "INVALID DATE FORMAT")
                        Return True
                    End If
                ElseIf RdrChkco.HasRows = False Then
                    For Each Tsmi As ToolStripMenuItem In Me.Ms1.Items
                        Tsmi.Visible = False
                        Tsmi.Enabled = False
                    Next
                    Me.ADMINISTRATORToolStripMenuItem.Visible = True
                    Me.ADMINISTRATORToolStripMenuItem.Enabled = True
                    Me.ABOUTUSToolStripMenuItem.Visible = True
                    Me.ABOUTUSToolStripMenuItem.Enabled = True
                    Me.LOGINToolStripMenuItem.Enabled = False
                    Me.CREATENEWUSERToolStripMenuItem.Visible = False
                    Me.COMPANYPROFILESToolStripMenuItem.Visible = True
                    Me.BACKUPToolStripMenuItem.Visible = False
                    Me.RESTOREToolStripMenuItem.Visible = False
                    Me.CHANGEPASSToolStripMenuItem1.Visible = False
                    Me.ToolStripMenuItem4.Visible = False
                    Me.COMPANYPROFILESToolStripMenuItem.Enabled = True

                End If
            End While

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Company Profile")
        Finally
            If RdrChkco.HasRows = True Then
                Set_Max_Min_Date(Fdate)
            Else
                For Each Tsmi As ToolStripMenuItem In Me.Ms1.Items
                    Tsmi.Visible = False
                    Tsmi.Enabled = False
                Next
                Me.ADMINISTRATORToolStripMenuItem.Visible = True
                Me.ADMINISTRATORToolStripMenuItem.Enabled = True
                Me.ABOUTUSToolStripMenuItem.Visible = True
                Me.ABOUTUSToolStripMenuItem.Enabled = True
                Me.LOGINToolStripMenuItem.Enabled = False
                Me.COMPANYPROFILESToolStripMenuItem.Enabled = True
                Me.CREATENEWUSERToolStripMenuItem.Visible = False
                Me.COMPANYPROFILESToolStripMenuItem.Visible = True
                Me.BACKUPToolStripMenuItem.Visible = False
                Me.RESTOREToolStripMenuItem.Visible = False
                Me.CHANGEPASSToolStripMenuItem1.Visible = False
                Me.ToolStripMenuItem4.Visible = False
                Me.MASTERToolStripMenuItem1.Enabled = True
            End If
            RdrChkco.Close()
            CmdChkCo = Nothing
        End Try

    End Function

    Private Sub TESTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TESTToolStripMenuItem.Click
        Dim frmmatrl As New FrmTest
        frmmatrl.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(frmmatrl)
        frmmatrl.BringToFront()
        frmmatrl.Show()
    End Sub


    Private Sub ABOUTUSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ABOUTUSToolStripMenuItem.Click
        Dim frmabt As New FrmAbout
        frmabt.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(frmabt)
        frmabt.BringToFront()
        frmabt.Show()
    End Sub

    Private Sub ToolStripMenuItem1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Dim frmabt1 As New FrmRptLedgerWithBillInfo
        frmabt1.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(frmabt1)
        frmabt1.BringToFront()
        frmabt1.Show()
    End Sub

    Private Sub SALESAGENTWISEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SALESAGENTWISEToolStripMenuItem.Click
        Dim FrmCagt As New FrmCrRptCustAgnt
        FrmCagt.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmCagt)
        FrmCagt.BringToFront()
        FrmCagt.Show()
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        Dim FrmAgntSale As New FrmRptLedgerWithBillInfoAgntWse
        FrmAgntSale.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmAgntSale)
        FrmAgntSale.BringToFront()
        FrmAgntSale.Show()
    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        Dim FrmUR As New FrmCreatUserRole
        FrmUR.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmUR)
        FrmUR.BringToFront()
        FrmUR.Show()
    End Sub

    Private Sub BOMDETAILSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOMDETAILSToolStripMenuItem.Click
        Dim FrmBd As New FrmCrRptBOMDetails
        FrmBd.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmBd)
        FrmBd.BringToFront()
        FrmBd.Show()
    End Sub

    Private Sub BOMCOSTESTIMATEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOMCOSTESTIMATEToolStripMenuItem.Click
        Dim FrmBc As New FrmCrRptBOMCosting
        FrmBc.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmBc)
        FrmBc.BringToFront()
        FrmBc.Show()
    End Sub

 
    Private Sub ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem6.Click
        Dim FrmPDEL As New FrmDelProdEntry
        FrmPDEL.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmPDEL)
        FrmPDEL.BringToFront()
        FrmPDEL.Show()
    End Sub

    Private Sub MaterialRequirementPlannerMRPToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaterialRequirementPlannerMRPToolStripMenuItem.Click
        Dim FrmMrp As New FrmDlyProdMatrlChck
        FrmMrp.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmMrp)
        FrmMrp.BringToFront()
        FrmMrp.Show()
    End Sub

    Private Sub MATERIALREQUIRMENTPLANNERToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MATERIALREQUIRMENTPLANNERToolStripMenuItem.Click
        Dim FrmDpmc As New FrmDlyProdMatrlChck
        FrmDpmc.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmDpmc)
        FrmDpmc.BringToFront()
        FrmDpmc.Show()
    End Sub

 
    Private Sub WORKORDERToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WORKORDERToolStripMenuItem1.Click
        Try
            MsgBox("Access Denied!", MsgBoxStyle.Exclamation, Me.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub COSTOVERHEADMASTERToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COSTOVERHEADMASTERToolStripMenuItem.Click
        Dim FrmCOH As New FrmCostOvrHeds
        FrmCOH.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmCOH)
        FrmCOH.BringToFront()
        FrmCOH.Show()
    End Sub

    Private Sub OUTSOURCINGINWARDSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OUTSOURCINGINWARDSToolStripMenuItem.Click
        Dim FrmOs As New FrmTranOutSourceIn
        FrmOs.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmOs)
        FrmOs.BringToFront()
        FrmOs.Show()
    End Sub

    Private Sub SALEPURCHASETAXCATEGORYToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SALEPURCHASETAXCATEGORYToolStripMenuItem.Click
        Dim FrmSpv As New FrmSalePurCatgry
        FrmSpv.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmSpv)
        FrmSpv.BringToFront()
        FrmSpv.Show()
    End Sub

    Private Sub CREATENEWPRICELISTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CREATENEWPRICELISTToolStripMenuItem.Click
        xMACH_xSALERATELIST = False
        Dim frmSLP As New FrmSalePriclstMstr
        frmSLP.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(frmSLP)
        frmSLP.BringToFront()
        frmSLP.Show()
    End Sub

    Private Sub ADDNEWITEMTOEXISTINGPRICELISTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ADDNEWITEMTOEXISTINGPRICELISTToolStripMenuItem.Click
        Dim frmSLP1 As New FrmPricelst1
        frmSLP1.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(frmSLP1)
        frmSLP1.BringToFront()
        frmSLP1.Show()
    End Sub

    Private Sub CONFIGURESAPPLICATIONToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CONFIGURESAPPLICATIONToolStripMenuItem.Click
        Dim frmCP As New FrmControlPanel
        frmCP.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(frmCP)
        frmCP.BringToFront()
        frmCP.Show()

    End Sub
  
  
    Private Sub SALEBILLINGWITHOUTINVENTRYToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SALEBILLINGWITHOUTINVENTRYToolStripMenuItem.Click
        xWrkContrctSale_Flag = False
        Dim FrmSwInv As New FrmTranSalEntryWithOtInvntry
        FrmSwInv.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmSwInv)
        FrmSwInv.BringToFront()
        FrmSwInv.Show()
    End Sub


    Private Sub PURCHASEBILLINGWITHOUTINVENTORYToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PURCHASEBILLINGWITHOUTINVENTORYToolStripMenuItem.Click
        xWrkContrct_Flag = False
        Dim FrmPwInv As New FrmTranPurEntryWithOtInvntry
        FrmPwInv.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmPwInv)
        FrmPwInv.BringToFront()
        FrmPwInv.Show()
    End Sub


    Private Sub ToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem7.Click
        Dim FrmPr As New FrmCrRptPurRegstr
        FrmPr.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmPr)
        FrmPr.BringToFront()
        FrmPr.Show()
    End Sub

    Private Sub ToolStripMenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem8.Click
        Dim FrmSr As New FrmCrRptSaleRegstr
        FrmSr.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmSr)
        FrmSr.BringToFront()
        FrmSr.Show()
    End Sub

    Private Sub ToolStripMenuItem10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem10.Click
        xCrRptPurchase = True
        Dim FrmPur2a As New FrmCrRptPurRegstr
        FrmPur2a.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmPur2a)
        FrmPur2a.Show()
    End Sub

    Private Sub ToolStripMenuItem9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem9.Click
        xCrRptSale = True
        Dim frmsalea As New FrmCrRptSaleRegstr
        frmsalea.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(frmsalea)
        frmsalea.BringToFront()
        frmsalea.Show()
    End Sub

    Private Sub PERIODMASTERToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PERIODMASTERToolStripMenuItem.Click
        Dim FrmPm As New FrmPirdMstr
        FrmPm.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmPm)
        FrmPm.BringToFront()
        FrmPm.Show()
    End Sub

    Private Sub LISTOFRECEIVABLESToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LISTOFRECEIVABLESToolStripMenuItem.Click
        xSndryDrRptFlag = True
        Dim FrmPA As New FrmRptPayAble
        FrmPA.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmPA)
        FrmPA.BringToFront()
        FrmPA.Show()
    End Sub

    Private Sub ToolStripMenuItem11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem11.Click
        xSndryCrRptFlag = True
        Dim FrmRA As New FrmRptRecvAble
        FrmRA.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmRA)
        FrmRA.BringToFront()
        FrmRA.Show()
    End Sub

  
    Private Sub BILLSRECEIVABLESToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BILLSRECEIVABLESToolStripMenuItem.Click
        Dim FrmRABILLS As New FrmCrRptRecvablBill
        FrmRABILLS.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmRABILLS)
        FrmRABILLS.BringToFront()
        FrmRABILLS.Show()
    End Sub

    Private Sub BILLSPAYABLESToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BILLSPAYABLESToolStripMenuItem.Click
        Dim FrmPABILLS As New FrmCrRptPayablBill
        FrmPABILLS.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmPABILLS)
        FrmPABILLS.BringToFront()
        FrmPABILLS.Show()
    End Sub

    Private Sub ONOVERDUERECEIVABLEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ONOVERDUERECEIVABLEToolStripMenuItem.Click
        Dim FrmRODintt As New FrmCrRptInttOnOvrDue
        FrmRODintt.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmRODintt)
        FrmRODintt.BringToFront()
        FrmRODintt.Show()
    End Sub

    Private Sub ONOVERDUEPAYABLESToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ONOVERDUEPAYABLESToolStripMenuItem.Click
        Dim FrmPODintt As New FrmCrRptInttOnOvrDuePayable
        FrmPODintt.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmPODintt)
        FrmPODintt.BringToFront()
        FrmPODintt.Show()
    End Sub


    Private Sub INTERESTCALCULATIONONOVERDUERECEIVABLESToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles INTERESTCALCULATIONONOVERDUERECEIVABLESToolStripMenuItem.Click
        Dim FrmRODintta As New FrmCrRptInttOnOvrDue
        FrmRODintta.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmRODintta)
        FrmRODintta.BringToFront()
        FrmRODintta.Show()
    End Sub

    Private Sub INTERESTCALCULATIONONOVERDUEPAYABLESToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles INTERESTCALCULATIONONOVERDUEPAYABLESToolStripMenuItem1.Click
        Dim FrmPODintta As New FrmCrRptInttOnOvrDuePayable
        FrmPODintta.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmPODintta)
        FrmPODintta.BringToFront()
        FrmPODintta.Show()
    End Sub

    Private Sub BALANCECONFIRMATIONLETTERToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BALANCECONFIRMATIONLETTERToolStripMenuItem.Click
        Dim FrmBalConfrm As New FrmCrRptBalConfrm
        FrmBalConfrm.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmBalConfrm)
        FrmBalConfrm.BringToFront()
        FrmBalConfrm.Show()
    End Sub

    Private Sub LETTERFORCFORMToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LETTERFORCFORMToolStripMenuItem.Click
        Dim FrmCF As New FrmCrRptCformRecveivable
        FrmCF.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmCF)
        FrmCF.BringToFront()
        FrmCF.Show()
    End Sub

    Private Sub INSERTMODEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles INSERTMODEToolStripMenuItem.Click
        Dim FrmCFR As New FrmCformRecveived
        FrmCFR.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmCFR)
        FrmCFR.BringToFront()
        FrmCFR.Show()
    End Sub

    Private Sub ALTERMODEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ALTERMODEToolStripMenuItem.Click
        Dim FrmCFRe As New FrmCformRecveivedEdit
        FrmCFRe.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmCFRe)
        FrmCFRe.BringToFront()
        FrmCFRe.Show()
    End Sub

    Private Sub INSERTMODEToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles INSERTMODEToolStripMenuItem1.Click
        Dim FrmCFI As New FrmCformIssU
        FrmCFI.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmCFI)
        FrmCFI.BringToFront()
        FrmCFI.Show()
    End Sub

    Private Sub ALTERMODEToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ALTERMODEToolStripMenuItem1.Click
        Dim FrmCFIe As New FrmCformIssUEdit
        FrmCFIe.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmCFIe)
        FrmCFIe.BringToFront()
        FrmCFIe.Show()
    End Sub

    Private Sub EXCELFORMVAT15ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EXCELFORMVAT15ToolStripMenuItem.Click
        Dim frmVAT As New FrmVATforms
        frmVAT.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(frmVAT)
        frmVAT.BringToFront()
        frmVAT.Show()
    End Sub

    Private Sub VAT15ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VAT15ToolStripMenuItem.Click
        Dim frmV15 As New FrmVAT_vat15_PriodSel
        frmV15.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(frmV15)
        frmV15.BringToFront()
        frmV15.Show()
        'Dim FrmWrkCon As New FrmVAT_vat15_WrkContrct
        'FrmWrkCon.MdiParent = Me
        'Me.SplitContainer1.Panel2.Controls.Add(FrmWrkCon)
        'FrmWrkCon.BringToFront()
        'FrmWrkCon.Show()
    End Sub

    Private Sub ToolStripMenuItem12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem12.Click
        Dim FrmV16 As New FrmVAT_vat16
        FrmV16.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmV16)
        FrmV16.BringToFront()
        FrmV16.Show()
    End Sub

    Private Sub ToolStripMenuItem13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem13.Click
        Dim FrmV18 As New FrmVAT_vat18
        FrmV18.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmV18)
        FrmV18.BringToFront()
        FrmV18.Show()
    End Sub

    Private Sub ToolStripMenuItem14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem14.Click
        Dim FrmV19 As New FrmVAT_vat19
        FrmV19.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmV19)
        FrmV19.BringToFront()
        FrmV19.Show()
    End Sub

    Private Sub ToolStripMenuItem15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem15.Click
        Dim FrmV23 As New FrmVAT_vat23
        FrmV23.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmV23)
        FrmV23.BringToFront()
        FrmV23.Show()
    End Sub

    Private Sub ToolStripMenuItem16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem16.Click
        Dim FrmV24 As New FrmVAT_vat24
        FrmV24.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmV24)
        FrmV24.BringToFront()
        FrmV24.Show()
    End Sub

    Private Sub SALEPRICELISTEDITMODEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SALEPRICELISTEDITMODEToolStripMenuItem.Click
        Dim FrmSpE As New FrmSalePricelstEdit
        FrmSpE.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmSpE)
        FrmSpE.BringToFront()
        FrmSpE.Show()
    End Sub

    Private Sub STOCKVALUATIONMETHODSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles STOCKVALUATIONMETHODSToolStripMenuItem.Click
        Dim FrmSV As Form
        If Cl_TimeIndia = True Then
            FrmSV = New FrmCrRptStokValuationTIME
        Else
            FrmSV = New FrmCrRptStokValuation
        End If
        FrmSV.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmSV)
        FrmSV.BringToFront()
        FrmSV.Show()
    End Sub

    Private Sub FORSALEITEMSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FORSALEITEMSToolStripMenuItem.Click
        FrmShow_flag(22) = False
        Dim frmbom As New FrmItemBoM
        frmbom.MdiParent = Me
        frmbom.rBSaleOnly.Checked = True
        Me.SplitContainer1.Panel2.Controls.Add(frmbom)
        frmbom.BringToFront()
        frmbom.Show()
    End Sub

    Private Sub FORPRODUCTIONSITEMSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FORPRODUCTIONSITEMSToolStripMenuItem.Click
        FrmShow_flag(22) = False
        Dim frmbom As New FrmItemBoM
        frmbom.MdiParent = Me
        frmbom.rBPurchaseOnly.Checked = True
        Me.SplitContainer1.Panel2.Controls.Add(frmbom)
        frmbom.BringToFront()
        frmbom.Show()
    End Sub

    Private Sub CHECKITEMDEPENDENCYToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHECKITEMDEPENDENCYToolStripMenuItem.Click
        Dim frmItmVewDepen As New FrmVewPrnt_ItmDependencies
        frmItmVewDepen.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(frmItmVewDepen)
        frmItmVewDepen.BringToFront()
        frmItmVewDepen.Show()
    End Sub

   
    Private Sub ALTERTRANSPORTATIONDETAILSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ALTERTRANSPORTATIONDETAILSToolStripMenuItem.Click
        Try
            Dim FrmTpt As New FrmTranAltrTptDtails
            FrmTpt.MdiParent = Me
            Me.SplitContainer1.Panel2.Controls.Add(FrmTpt)
            FrmTpt.BringToFront()
            FrmTpt.Show()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SALEORDERPACKINGNOTEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SALEORDERPACKINGNOTEToolStripMenuItem.Click
        Dim FrmUtl1 As New FrmUtlpckOrdr
        FrmUtl1.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmUtl1)
        FrmUtl1.BringToFront()
        FrmUtl1.Show()
    End Sub

    Private Sub ToolStripMenuItem18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem18.Click
        xMACH_xBILLING = True
        Dim FrmSdM As New FrmTranSaleentryMain
        FrmSdM.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmSdM)
        FrmSdM.BringToFront()
        FrmSdM.Show()
    End Sub

    Private Sub ToolStripMenuItem19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem19.Click
        xMACH_xSALERATELIST = True
        Dim frmSLP As New FrmSalePriclstMstr
        frmSLP.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(frmSLP)
        frmSLP.BringToFront()
        frmSLP.Show()
    End Sub

    Private Sub PRODUCTIONENTRYDIRECTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PRODUCTIONENTRYDIRECTToolStripMenuItem.Click
        Dim FrmDrct As New FrmTran_KblTypeDrctProdn
        FrmDrct.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmDrct)
        FrmDrct.BringToFront()
        FrmDrct.Show()
    End Sub

    Private Sub BILLOFMATERIALBOMToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BILLOFMATERIALBOMToolStripMenuItem.Click

    End Sub

    Private Sub DrawnOnMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DrawnOnMasterToolStripMenuItem.Click
        Dim FrmDrw As New FrmDrawnNameMstr
        FrmDrw.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmDrw)
        FrmDrw.BringToFront()
        FrmDrw.Show()

    End Sub

    Private Sub ToolStripMenuItem20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem20.Click
        xMACH_xPurxBILLING = True
        Dim frmtpm As New FrmTranPurentryMain
        frmtpm.MdiParent = Me
        frmtpm.TopMost = True
        Me.SplitContainer1.Panel2.Controls.Add(frmtpm)
        frmtpm.BringToFront()
        frmtpm.Show()
    End Sub

    Private Sub CHALLANENTRYToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHALLANENTRYToolStripMenuItem.Click
        Dim FrmPChln As New FrmTranPurEntryThruChln
        FrmPChln.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmPChln)
        FrmPChln.BringToFront()
        FrmPChln.Show()
    End Sub

    Private Sub BILLINGUSINGCHALLANSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BILLINGUSINGCHALLANSToolStripMenuItem.Click
        Dim FrmPbillChln As New FrmTranPurEntryBlngUsingChln
        FrmPbillChln.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmPbillChln)
        FrmPbillChln.BringToFront()
        FrmPbillChln.Show()
    End Sub
    Private Sub ADDNEWToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ADDNEWToolStripMenuItem.Click
        xMdi_LnkName = Trim("CASHBANKToolStripMenuItem")
        Dim frmCbnk As New FrmCshBnk
        frmCbnk.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(frmCbnk)
        frmCbnk.BringToFront()
        frmCbnk.Show()
    End Sub

    Private Sub DISPLAYToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DISPLAYToolStripMenuItem.Click
        Dim FrmCedt As New FrmCshBnkEditMode1
        FrmCedt.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmCedt)

        FrmCedt.BringToFront()
        FrmCedt.Show()
    End Sub

    Private Sub DELETESALEINVOICEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DELETESALEINVOICEToolStripMenuItem.Click
        Dim FrmSaleDele As New FrmUtlBillDele
        FrmSaleDele.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmSaleDele)
        FrmSaleDele.BringToFront()
        FrmSaleDele.Show()
    End Sub

    Private Sub PURCHASEWORKCONTRACTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PURCHASEWORKCONTRACTToolStripMenuItem.Click
        xWrkContrct_Flag = True
        Dim FrmPwInv As New FrmTranPurEntryWithOtInvntry
        FrmPwInv.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmPwInv)
        FrmPwInv.BringToFront()
        FrmPwInv.Show()
    End Sub

    Private Sub ToolStripMenuItem22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem22.Click
        xWrkContrctSale_Flag = True
        Dim FrmSwInv As New FrmTranSalEntryWithOtInvntry
        FrmSwInv.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmSwInv)
        FrmSwInv.BringToFront()
        FrmSwInv.Show()
    End Sub

    Private Sub ToolStripMenuItem24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem24.Click
        MsgBox("Under Development.............")
        Exit Sub
        Dim FrmSChln As New FrmTranSaleEntryThruChln
        FrmSChln.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmSChln)
        FrmSChln.BringToFront()
        FrmSChln.Show()
    End Sub

    Private Sub ToolStripMenuItem25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem25.Click
        MsgBox("Under Development..................")
        Exit Sub
        Dim FrmSbillChln As New FrmTranSaleEntryBlngUsingChln
        FrmSbillChln.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmSbillChln)
        FrmSbillChln.BringToFront()
        FrmSbillChln.Show()
    End Sub

    Private Sub ToolStripMenuItem26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem26.Click
        Dim FrmScw As New FrmCrRptSaleRegstrCategorywise
        FrmScw.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmScw)
        FrmScw.BringToFront()
        FrmScw.Show()
    End Sub

    Private Sub ToolStripMenuItem27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem27.Click
        Dim FrmPcw As New FrmCrRptPurRegstrCategorywise
        FrmPcw.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmPcw)
        FrmPcw.BringToFront()
        FrmPcw.Show()
    End Sub

    Private Sub STATEMENTOFSALESAGENTCOMMISSIONToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles STATEMENTOFSALESAGENTCOMMISSIONToolStripMenuItem.Click
        Dim FrmAc As New FrmCrRptAgntCommCal
        FrmAc.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmAc)
        FrmAc.BringToFront()
        FrmAc.Show()
    End Sub

    Private Sub TDSCHECKLISTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TDSCHECKLISTToolStripMenuItem.Click
        Dim FrmTdsChk As New FrmCrRptTdsChkList
        FrmTdsChk.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmTdsChk)
        FrmTdsChk.BringToFront()
        FrmTdsChk.Show()
    End Sub

    Private Sub DEACTIVATEACTIVATEANACCOUNTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DEACTIVATEACTIVATEANACCOUNTToolStripMenuItem.Click
        Dim FrmDeAct As New FrmAcctSuspend
        FrmDeAct.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmDeAct)
        FrmDeAct.BringToFront()
        FrmDeAct.Show()
    End Sub

    Private Sub ToolStripMenuItem28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem28.Click
        Dim FrmAw As New FrmCrRptAgntWiseRecvablBill
        FrmAw.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmAw)
        FrmAw.BringToFront()
        FrmAw.Show()
    End Sub

    Private Sub CREDITNOTEToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CREDITNOTEToolStripMenuItem1.Click
        xDrCrNoteFlag = False
        Dim FrmCrN As New FrmCrRptCrNote
        FrmCrN.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmCrN)
        FrmCrN.BringToFront()
        FrmCrN.Show()
    End Sub

    Private Sub DEBITNOTEToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DEBITNOTEToolStripMenuItem1.Click
        xDrCrNoteFlag = False
        Dim FrmDrN As New FrmCrRptDrNote
        FrmDrN.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmDrN)
        FrmDrN.BringToFront()
        FrmDrN.Show()
    End Sub

    Private Sub ALTERTRANSPORTGRNOToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ALTERTRANSPORTGRNOToolStripMenuItem.Click
        Dim FrmGr As New FrmTranAltrTptGrNo
        FrmGr.MdiParent = Me
        Me.SplitContainer1.Panel2.Controls.Add(FrmGr)
        FrmGr.BringToFront()
        FrmGr.Show()
    End Sub

    Private Sub ToolStripMenuItem29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem29.Click
        xItmMstrOptn = 0 ' FINISHED ITEMS SALES
        Dim FrmstokItm As New FrmStokItm
        FrmstokItm.MdiParent = Me
        FrmstokItm.rBTradingOnly.Checked = True
        Me.SplitContainer1.Panel2.Controls.Add(FrmstokItm)
        FrmstokItm.BringToFront()
        FrmstokItm.Show()
    End Sub

   
    Private Sub STOCKREGISTERSUMMARYToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles STOCKREGISTERSUMMARYToolStripMenuItem.Click

    End Sub
End Class
