Module FinActSettings
    Public Const Cl_Kbl As Boolean = True 'Kbl sales
    Public Const Cl_TimeIndia As Boolean = False 'Time India
    Public Const Cl_TimeRubber As Boolean = False ' Time Rubber
    Public Const Cl_Ltg As Boolean = False ' Leisure Time Garments
    Public Const Cl_Master As Boolean = False ' Master Copy
    '====KBL SALES BILL SERIES SETTINGS
    ''Public Const xSaleRetailVno As Integer = 5000 'don't change it (For Kbl Sales)
    '' Public Const xSaleRetailVno As Integer = 4000 'don't change it (For Kb Fabrics) 'THIS SERIES APPLIED FROM 01-04-2012 IN FABRIC
    Public Const xSaleRetailVno As Integer = 2000 'don't change it (For Kb Fabrics)
    '===========================================================
    Public Const RETAIL_INV_CST As Integer = 1000
    Public Const DIRCTEXPRT_INV As Integer = 0
    Public Const RETAILINV_LOCAL As Integer = 5000
    Public Const VAT_INV As Integer = 0
    Public Const RETAILINV_TXFREE As Integer = 9000
    '===LTG SALES BILL SERIES SETTINGS
    '===========================================================
    Public Sub Cl_Kbl_Settings()
        Try
            Select Case True
                Case Cl_Kbl
                    ''==YEAR 2010-11===
                    ''SqlServerName = "GR_SERVER\EZEESQLEXP" '== NAME OF KBL SERVER
                    ''SqlServerName = "203.134.217.254\192.168.0.102\EZEESQLEXP,1042" '==NAME OF QIFAR SERVER
                    '' SqlServerName = "192.168.1.1\GR_SERVER\EZEESQLEXP" '==NAME OF QIFAR SERVER
                    ''SqlServerName = "HOMEOFFICE\EZEESQLEXP" '== NAME OF KBL SERVER AT HOME
                    ''SqlServerName = "QIFARINFOTECH\QIFARSQLEXP08" '==NAME OF QIFAR SERVER
                    '' SqlServerName = "RANJEEVSERVER\EZEESQLEXP" '==NAME OF QIFAR SERVER
                    ''Db_FinAct = "Finact10"  'Name of Database in use for KBL SALES
                    ''Db_FinAct = "TempKblFinact10"  'Name of Database in use for KBL SALES
                    ''Db_FinAct = "TempKblFinact10FAB"  'Name of Database in use for KBL FABRIC
                    '' Db_FinAct = "Finact10FAB"  'Name of Database in use for KBL FABRICS
                    ''BacUp = "D:"  ' Name of Drive where Backup will be kept.
                    '' FrmMainMdi.Text = "Qifar ERP V-9 Licensee Name Kay Bee Ell Sales  [SESSION 2010-2011]"
                    '' FrmMainMdi.Text = "Qifar ERP V-9 Licensee Name Kay Bee Fabrics   [SESSION 2010-2011]"
                    ''FrmMainMdi.Text = "Qifar ERP V-9 Licensee Name NIRMAL COMPUTER COMPANY"
                    ''==YEAR 2011-12===
                    ''SqlServerName = "QIFARINFOTECH\QIFARSQLEXP08" '==NAME OF QIFAR SERVER
                    ''SqlServerName = "GR_SERVER\EZEESQLEXP" '== NAME OF KBL SERVER
                    ''BacUp = "D:"  ' Name of Drive where Backup will be kept.

                    ''Db_FinAct = "Finact12"  'Name of Database in use for KBL SALES
                    '' FrmMainMdi.Text = "Qifar ERP V-9 Licensee Name Kay Bee Ell Sales  [SESSION 2011-2012]"

                    ''FrmMainMdi.Text = "Qifar ERP V-9 Licensee Name Kay Bee Fabrics   [SESSION 2011-2012]"
                    ''Db_FinAct = "Finact11FAB"  'Name of Database in use for KBL FABRICS

                    ''==YEAR 2012-13===
                    ''SqlServerName = "QIFARINFOTECH\QIFARSQLEXP08" '==NAME OF QIFAR SERVER

                    '' SqlServerName = "GR_SERVER\EZEESQLEXP" '== NAME OF KBL SERVER
                    ''BacUp = "D:"  ' Name of Drive where Backup will be kept.

                    ''Db_FinAct = "Finact12"  'Name of Database in use for KBL SALES
                    ''FrmMainMdi.Text = "Qifar ERP V-9 Licensee Name Kay Bee Ell Sales  [SESSION 2012-2013]"

                    ''FrmMainMdi.Text = "Qifar ERP V-9 Licensee Name Kay Bee Fabrics   [SESSION 2012-2013]"
                    ''Db_FinAct = "Finact12FAB"  'Name of Database in use for KBL FABRICS

                    ''==YEAR 2013-14===

                    ''SqlServerName = "QIFARINFOTECH\QIFARSQLEXP08" '==NAME OF QIFAR SERVER
                    ''SqlServerName = "GR_SERVER\EZEESQLEXP" '== NAME OF KBL SERVER
                    '' BacUp = "D:"  ' Name of Drive where Backup will be kept.
                    ''Db_FinAct = "Finact13"  'Name of Database in use for KBL SALES
                    ''FrmMainMdi.Text = "Qifar ERP V-9 Licensee Name Kay Bee Ell Sales  [SESSION 2013-2014]"

                    ''FrmMainMdi.Text = "Qifar ERP V-9 Licensee Name Kay Bee Fabrics   [SESSION 2013-2014]"
                    ''Db_FinAct = "Finact13FAB"  'Name of Database in use for KBL FABRICS


                    ''==YEAR 2014-15===

                    ''SqlServerName = "QIFARINFOTECH\QIFARSQLEXP08" '==NAME OF QIFAR SERVER
                    SqlServerName = "STAR" '== NAME OF KBL SERVER
                    BacUp = "D:"  ' Name of Drive where Backup will be kept.
                    ''Db_FinAct = "Finact14"  'Name of Database in use for KBL SALES
                    ''FrmMainMdi.Text = "Qifar ERP V-9 Licensee Name Kay Bee Ell Sales  [SESSION 2014-2015]"

                    FrmMainMdi.Text = "Qifar ERP V-9 Licensee Name Kay Bee Fabrics   [SESSION 2014-2015]"
                    Db_FinAct = "FinAct20"

                    ''==========================================================

                    FrmMainMdi.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    FrmMainMdi.ForeColor = System.Drawing.Color.Black
                    FrmMainMdi.Ms1.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                Case Cl_TimeIndia
                    ''SqlServerName = ".\sqlexpress"
                    ''SqlServerName = "MARY\SQLEXPRESS"
                    SqlServerName = "STAR\MSSQLSERVER"
                    '' Db_FinAct = "Finact10"  'Name of Database in use
                    Db_FinAct = "FinAct09"  'Name of Database in use
                    '' Db_FinAct = "Temp07" '---"MsSql08_Finact07"  'Name of Database in use
                    BacUp = "D:"  ' Name of Drive where Backup will be kept.
                    FrmMainMdi.Text = "Qifar ERP V-9 Licensee Name Time India."
                    '==================================================================
                    '==Do not delete it '(Setting of TIME INDIA Sql  Login Name 'sa' and pass 'mohd@786sqltime'
                    ''==================================================================
                Case Cl_TimeRubber
                    SqlServerName = ".\sqlexpress"
                    Db_FinAct = "FinAct09"  'Name of Database in use
                    BacUp = "D:"  ' Name of Drive where Backup will be kept.
                    FrmMainMdi.Text = "Qifar ERP V-9 Licensee Name Time Rubber"
                Case Cl_Ltg
                    'SqlServerName = ".\sqlexpress"
                    SqlServerName = "STAR\MSSQLSERVER" '==NAME OF QIFAR SERVER
                    '' SqlServerName = "SERVER\SQLEXPRESS" ' & 1030 '==NAME OF LTG SERVER
                    Db_FinAct = "Finact10"  'Name of Database in use
                    BacUp = "G:"  ' Name of Drive where Backup will be kept.
                    FrmMainMdi.Text = "Qifar ERP V-9 Licensee Name Leisure Time Garments"
                    FrmMainMdi.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    FrmMainMdi.ForeColor = System.Drawing.Color.Black
                    FrmMainMdi.Ms1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    ''==================================================================
                Case Cl_Master
                    Db_FinAct = "Finact09"  'Name of Database in use
                    SqlServerName = "STAR\MSSQLSERVER"
                    BacUp = "D:"  ' Name of Drive where Backup will be kept.
                    FrmMainMdi.Text = "Qifar ERP V-9 Licensee Name Master Version"
            End Select

        Catch ex As Exception

        End Try

    End Sub
End Module
