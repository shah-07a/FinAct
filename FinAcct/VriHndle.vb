Module VriHndle
    Public MeHeight As Integer 'Mdi form's height
    Public MeWidth As Integer  'Mdi form's width
    Public Show_FrmCsC As Boolean ' Form Csc Show close 
    Public Altr_FrmCogate As Boolean = True
    Public Add_Allow As Boolean = True
    Public Edit_Allow As Boolean = False
    Public Delete_Allow As Boolean = False
    Public SetCaptions As Boolean = False
    Public Current_UsrId As Integer = 0
    Public Current_UserName As String = ""
    Public Current_UserDesi As String = ""
    Public AcessRight As String = ""
    Public FinStartDt As Date
    Public FinEnddt As Date
    Public Selected_xOrdr_xId As Integer
    Public Selected_xInvoice_xId As Integer
    Public Selected_xSelectedOrdr_xId As Integer()
    Public Process_Name As String
    Public Process_id() As Integer
    Public Process_ItemId() As Integer
    Public Processed_Qnty As Double
    Public Process_Allow_NxtTask As Boolean
    Public SplrID_Editx As Integer = 0
    Public ItmId_for_Alter As Integer = 0
    Public BomId_for_Alter As Integer = 0
    Public CurrBOMname As String = ""
    Public CurrActType As String = ""
    Public xCurrActType As String = ""
    Public xMrpCurBomId As Integer = 0
    Public xMrpQnty As Double = 0
    Public SBRqnty As Double = 0
    Public SBRItmId As Integer = 0
    Public SBRCurrId As Integer = 0
    Public SBRType As String = ""
    Public SBRBillNo As String = ""
    Public SBRid As Integer = 0
    Public ServerCurrentDate As Date
    Public MMdate As DateTime
    Public MMbatNox As String
    Public MMbomidx As Integer
    Public x_SBillNo_x As String
    Public x_SBill_Type As Integer
    Public x_PBillNO_x As String
    Public x_OrdrStatus As String 'Purchase Order
    Public x_OrdrStatus1 As String 'Sale Order
    Public xCrptFlag As Boolean 'Flag used in BoM Costing
    Public xPurEntFlag As Boolean
    Public xUsrRol_Add, xUsrRol_Edit, xUsrRol_Del, xUsrRol_Prnt As Integer
    Public xMdi_LnkName As String = ""
    Public xSalePurCatType As String = ""
    Public xCrRptSale As Boolean = False
    Public xCrRptPurchase As Boolean = False
    Public xCBedtmode_RecId As Integer = 0
    Public xCBedtmode_Vno As Integer = 0
    Public xCBedtmode_splttype As Boolean = False
    Public xCBedtmode_Mode As String = ""
    Public xSetSaleBillCate As Integer = 0
    Public xItmMstrOptn As Integer = 0 '== 0 for FINISHED ITEMS (SALES) and 1 for TRADING ITEMS
    Public xItmStokOptn As Integer = 0 '== 0 for FINISHED ITEMS (SALES) STOCKS  and 1 for TRADING ITEMS STOCKS
    Public xItmStokSumry As Integer = 0 '== 0 for Detailed and 1 for Summary
    '==Global use variables for dynamic settings 

    Public Db_FinAct As String = ""
    Public BacUp As String = ""
    Public Const xCoType As String = "FACTORY/INDUSTRIES"
    Public Const xBaKupDrive As String = "D:\"
  
    Public xSalxPurxType As String = ""
    Public VATCST As Double = 0
    Public xCustId_EditMode As Integer = 0
    Public Const xIniCshRecptNo As Integer = 511 'set 1 or more than 1  if user wants to start seperate series for cash receipt no. else SET 0
    Public Const xIniCrNoteSrNo As Integer = 1 'set 1 or more than 1  if user wants to start seperate series for CREDIT NOTE NO. else SET  0
    Public Const xIniDrNoteSrNo As Integer = 1 'set 1 or more than 1  if user wants to start seperate series for DEBIT NOTE No. else SET 0

    Public xPackNoteNO As Integer = 0   '===To be Used in Packing Note Printing Mode
    Public xPackNoteDt As Date = Nothing '===To be Used in Packing Note Printing Mode
    Public xPackNoteFlag As Boolean = False  '===To be Used in Packing Note Printing Mode ==TRUE for Run Time Printing
    Public xSaleBillId As Integer = 0            'To be Used in Sale Bill Printing at Run time. 
    Public xSaleBillSplrid As Integer = 0   'To be used in Sale bill printing at run time
    Public xSaleBillSpcatid As Integer = 0   'To be used in Sale bill printing at run time

    Public Const xSaleVATvNo As Integer = 0  'don't change it
    Public xMACH_xBILLING As Boolean = False
    Public xMACH_xPurxBILLING As Boolean = False
    Public xMACH_xSALERATELIST As Boolean = False
    Public xxRptNetAmt As Double = 0
    Public xxRptAdnlDisAmt As Double = 0
    Public xWrkContRate As Double = 0 '==LABOUR % ON PURCHASE
    Public xWrkContRate1 As Double = 0 '==LABOUR % ON SALE
    Public xWrkContTDSRate As Double = 0
    Public xTDSminLmt As Double = 0
    Public xWrkContrct_Flag As Boolean = False
    Public xWrkContrctSale_Flag As Boolean = False
    Public xSndryDrRptFlag As Boolean = False
    Public xSndryCrRptFlag As Boolean = False

    Public xDrCrNoteAmt As Double = 0  '===Debit\Credit Note
    Public xDrCrNoteDt As Date = Nothing '==IT IS USED IN NOTE PRINTING WHILE MAKING ENTRY
    Public xDrCrNoteFlag As Boolean = False '==IT IS USED IN NOTE PRINTING WHILE MAKING ENTRY 
    Public xDrCrNo As Integer = 0
    '------------------------------------------------------
    '==AUTHENTICATION VARIABLES 
    Public xCust_Vend As Boolean = False ' True mean Selection would be Common. 
    '-------------------------
    'priya
    Public pack As Double              'packing charges
    Public freight As Double           'freight charges
    Public other As Double             'other charges
    Public rate1 As Double = 0.0
    Public dscntprcnt As Double
    Public rebate As Double
    Public discount As Double
    Public grsprice As Double
    Public netprice As Double = 0.0
    Public calcvat As Double
    Public txblesale As Double
    Public charges As Double = 0.0
    Public qnty As Double = 0.0
    Public rate As Double = 0.0
    Public totalprice As Double = 0
    Public price As Double = 0
    Public qntyfordscnt As Integer
    Public ratefordscnt As Double = 0.0
    Public pricefordscnt As Double = 0.0
    Public vatonprice As Double = 0.0
    Public amtfordscnt As Double = 0.0
    Public finalamount As Double = 0.0
    Public finaldiscount As Double = 0.0

    Public splr_name As String = ""
    Public salecharges As Double = 0.0
    Public ordrflag As Integer = 0
    Public editchrgflag As Integer = 0
    Public Final_Slry As Boolean

    'Purchase entery variables
    Public Pkgchrgs As Double = 0 'PurChrg Form's Packing Chrgs
    Public Frtchrgs As Double = 0 'PurChrg Form's Freight Chrgs
    Public Anychrgs As Double = 0 'PurChrg Form's Any Chrgs
    Public Disperc As Double = 0 'PurChrg Form's Discount%
    Public DisReb As Double = 0 'PurChrg Form's Discount/Rebate
    Public Totchrgs As Double = 0 'PurChrg Form's Total charges
    Public vatcalc As Double = 0 'Purentry Form's vat calculation
    Public Taxpurch As Double = 0
    Public Dis As Double = 0
    Public myvar As Double
   
    Public pur_totalprice As Double = 0.0
    Public purcharges As Double = 0.0
    Public pur_discount As Double = 0.0
    Public pur_grsprice As Double
    Public pur_netprice As Double = 0.0
    Public pur_dscntprcnt As Double
    Public pur_amtfordscnt As Double = 0.0
    Public pur_price As Double = 0.0
    Public pur_qnty As Integer = 0
    Public pur_rate As Double = 0.0
    Public pur_finalprice As Double = 0.0
    Public SaleOrdrname As String
    Public PurOrdrname As String

    Public primary_flag As Boolean = False
    Public edit_flag As Boolean = False

    Public FrmShow_flag() As Boolean   'last used indx=24
    Public FrmShow_flag1 As Boolean = False
    Public StrUndrgrup As String = ""
    Public IntHtCmMm() As String    'last used index =13
    Public ChkCoStatus As String = ""
    Public StrCmbxAgent As String
    Public SplrID4Shpid As Integer
    Public SplrName4Shp As String = ""
    Public SplrSurfix4Shp As Integer = 0
    Public SplrStatus4Shp As Boolean = False
    Public Surfix4Cmbx() As String
    Public Rbstatus(1) As Integer
    Public ItmCurId As Integer = 0
    Public BomCurType As String = ""

    '====
    
    Public App_Str_dt As Date
    Public attd_flag As Boolean = False
    Public SrtLev_dt As Date
    Public SrtLev_Shift As String
    Public SrtLev_Empnm As String
    Public SrtLev_RepTm As String
    Public SrtLev_Type As String
    Public SrtLevMark_flag As Boolean = False
    Public SrtLev_Empid As Integer
    Public MatrntyLev_flag As Boolean = False

    Public FDayLev_dt As Date
    Public FDayLev_Shift As String
    Public FDayLev_Empnm As String
    Public FdayLev_Empid As Integer

    Public Attd_Type As Integer
    Public Attd_Date As Date
    Public Attd_Shift As String
    Public Leve_flag As Integer
    Public Attd_StrTm As Date
    Public Type_Lev As String
    Public Final_AutoSlry As Boolean
    Public Emname As String
    Public Fetch_PFId As Integer = 0
    Public DtColmn_Flag As Boolean = False
    '===

End Module
