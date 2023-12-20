Imports AppCore
Imports CommonLibrary
Imports Xceed.Grid.Collections
Imports Xceed.Grid.Editors
Imports System.Xml
Imports System.Configuration.ConfigurationSettings

Public Class frmAFMAST_bk
    Inherits AppCore.frmMaintenance
    Friend WithEvents ExtCIGrid As GridEx
    Friend WithEvents ExtBankAccGrid As GridEx
    Friend WithEvents ICCFTYPEDEF_Grid As GridEx
    Friend WithEvents AnthorizeGrid As GridEx

#Region " Properties and varialble "
    '---------------------------------------------------------------
    'C? d�ùng để xác định xem TabPage đã được tải thông tin chưa
    Private mv_blnRefreshTabPage_MainInfo As Boolean = False
    Private mv_blnRefreshTabPage_Report As Boolean = False
    Private mv_blnRefreshTabPage_Txmap As Boolean = False
    Private mv_blnRefreshTabPage_Services As Boolean = False
    Private mv_blnRefreshTabPage_Members As Boolean = False
    Private mv_blnRefreshTabPage_Accounts As Boolean = False
    Private mv_blnRefreshTabPage_RegisterAcctTrf As Boolean = False
    Private mv_blnRefreshTabPage_Authorized As Boolean = False
    Private mv_blnRefreshTabPage_AFDefICCF As Boolean = False
    Private mv_blnRefreshTabPage_AFSERule As Boolean = False
    Private mv_blnRefreshTabPage_OTRight As Boolean = False
    Private mv_blnRefreshTabPage_Templates As Boolean = False


    Private mv_blnACTYPE_AllowCustomized As Boolean = False
    '---------------------------------------------------------------

    Public ContactsGrid As GridEx
    'Public AnthorizeGrid As GridEx
    Public AccountGrid As GridEx
    Public RepoContractGrid As GridEx
    Public ReportGrid As GridEx
    Public TxmapGrid As GridEx
    Public ExceptionGrid As GridEx
    Public AFSERuleGrid As GridEx
    Public OTRightAuthGrid As GridEx
    Public TemplateGrid As GridEx

    Public v_strCustInfor As String = String.Empty 'Thanh nm khong dat ten khong chuan gi ca
    Public v_strFullNAME As String = String.Empty
    Public v_strAddress As String = String.Empty
    Public v_strEmail As String = String.Empty
    Public v_strPhone1 As String = String.Empty
    Public v_strFax As String = String.Empty
    Public v_strMobile As String = String.Empty
    Public v_strFax1 As String = String.Empty
    Public v_strCUSTODYCD As String = String.Empty
    Public v_strCUSTTYPE As String = String.Empty
    Public v_strCOUNTRY As String = String.Empty
    Public v_strIORB As String = String.Empty
    Public v_strDORF As String = String.Empty
    Public mv_strCUSTID As String = String.Empty
    Private v_strSender As String = String.Empty
    Private v_boolean As Boolean = False
    Private v_strCONTRACTCHK As String = "N"
    Public v_strCUSTATCOM As String = String.Empty
    Public v_strTradingCode As String = String.Empty
    Public mv_strMarginType As String = String.Empty

    'TheNN sua
    Private mv_strCareBy As String
    Private hAftype As New Hashtable
    Private mv_blnLookup As Boolean = False
    Private m_blnGridCI As Boolean = False

    'Private mv_strTlid As String 'dien them

    'TungNT added, check khi them tk ngan hang hoac sua
    Private mv_strBankAcctno As String = ""
    Private mv_strBankCode As String = ""
    'End
    'Binhpt add, tai khoan dang ky qua online
    Private mv_OLAUTOID As String = String.Empty
    Private mv_IsOnlineRegister As Boolean = False
    Private mv_cashinadvanceauto As String = String.Empty
    Private mv_placeorderphone As String = String.Empty
    Private mv_smsphonenumber As String = String.Empty
    Private mv_placeorderonline As String = String.Empty
    Private mv_cashinadvanceonline As String = String.Empty
    Private mv_cashtransferonline As String = String.Empty
    Private mv_additionalsharesonline As String = String.Empty
    Private mv_searchonline As String = String.Empty
    Private mv_bankaccountname1 As String = String.Empty
    Private mv_bankidcode1 As String = String.Empty
    Private mv_bankiddate1 As String = String.Empty
    Private mv_bankidplace1 As String = String.Empty
    Private mv_bankaccountnumber1 As String = String.Empty
    Private mv_bankname1 As String = String.Empty
    Private mv_branch1 As String = String.Empty
    Private mv_bankcity1 As String = String.Empty
    Private mv_bankaccountname2 As String = String.Empty
    Private mv_bankidcode2 As String = String.Empty
    Private mv_bankiddate2 As String = String.Empty
    Private mv_bankidplace2 As String = String.Empty
    Private mv_bankaccountnumber2 As String = String.Empty
    Private mv_bankname2 As String = String.Empty
    Private mv_branch2 As String = String.Empty
    Private mv_bankcity2 As String = String.Empty
    Private mv_bankaccountname3 As String = String.Empty
    Private mv_bankidcode3 As String = String.Empty
    Private mv_bankiddate3 As String = String.Empty
    Private mv_bankidplace3 As String = String.Empty
    Private mv_bankaccountnumber3 As String = String.Empty
    Private mv_bankname3 As String = String.Empty
    Private mv_branch3 As String = String.Empty
    Private mv_bankcity3 As String = String.Empty
    Private mv_IsCreatOtright_CfOtherAcc As Boolean = False
    'End
    Public mv_strCustomerStatus As String = String.Empty

    Public MessageData As String
    Private mv_blnAcctEntry As Boolean = False
    Private mv_strIpAddress As String
    Private mv_strWsName As String
    Friend WithEvents lblETS As System.Windows.Forms.Label
    Friend WithEvents cboETS As AppCore.ComboBoxEx
    Friend WithEvents btnCheckAcc As System.Windows.Forms.Button
    Friend WithEvents txtOPNDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtBRID As System.Windows.Forms.TextBox
    Friend WithEvents cboAUTOADV As AppCore.ComboBoxEx
    Friend WithEvents lblAUTOADV As System.Windows.Forms.Label
    Friend WithEvents txtTLID As System.Windows.Forms.TextBox
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents lblCAREBY As System.Windows.Forms.Label
    Friend WithEvents cboCAREBY As AppCore.ComboBoxEx
    Friend WithEvents lblUsername As System.Windows.Forms.Label
    Friend WithEvents tabTxmap As System.Windows.Forms.TabPage
    Friend WithEvents pnTxmap As System.Windows.Forms.Panel
    Friend WithEvents btnTXDEL As System.Windows.Forms.Button
    Friend WithEvents btnTXEDIT As System.Windows.Forms.Button
    Friend WithEvents btnTXVIEW As System.Windows.Forms.Button
    Friend WithEvents btnTXADD As System.Windows.Forms.Button
    Friend WithEvents tabAFSERULE As System.Windows.Forms.TabPage
    Friend WithEvents btnASDEL As System.Windows.Forms.Button
    Friend WithEvents btnASEDIT As System.Windows.Forms.Button
    Friend WithEvents btnASVIEW As System.Windows.Forms.Button
    Friend WithEvents btnASADD As System.Windows.Forms.Button
    Friend WithEvents pnAFSERULE As System.Windows.Forms.Panel
    Friend WithEvents txtMRMRATIO As System.Windows.Forms.TextBox
    Friend WithEvents lblMRMRATIO As System.Windows.Forms.Label
    Friend WithEvents txtMRLRATIO As System.Windows.Forms.TextBox
    Friend WithEvents lblMRLRATIO As System.Windows.Forms.Label
    Friend WithEvents lblMRIRATIO As System.Windows.Forms.Label
    Friend WithEvents txtMRIRATIO As System.Windows.Forms.TextBox
    Friend WithEvents txtTRFBUYRATE As System.Windows.Forms.TextBox
    Friend WithEvents lblTRFBUYRATE As System.Windows.Forms.Label
    Friend WithEvents txtTRFBUYEXT As System.Windows.Forms.TextBox
    Friend WithEvents lblTRFBUYEXT As System.Windows.Forms.Label
    Friend WithEvents cboBRKFEETYPE As AppCore.ComboBoxEx
    Friend WithEvents lblBRKFEETYPE As System.Windows.Forms.Label
    Friend WithEvents tabOTRIGHT As System.Windows.Forms.TabPage
    Friend WithEvents btnOTADD As System.Windows.Forms.Button
    Friend WithEvents pnOTRightAsgn As System.Windows.Forms.Panel
    Friend WithEvents btnOTDEL As System.Windows.Forms.Button
    Friend WithEvents btnOTEDIT As System.Windows.Forms.Button
    Friend WithEvents btnOTVIEW As System.Windows.Forms.Button
    Friend WithEvents lblCUSTATCOM As System.Windows.Forms.Label
    Friend WithEvents cboCUSTATCOM As AppCore.ComboBoxEx
    Friend WithEvents tabTemplates As System.Windows.Forms.TabPage
    Friend WithEvents btnViewTemplate As System.Windows.Forms.Button
    Friend WithEvents btnDeleteTemplate As System.Windows.Forms.Button
    Friend WithEvents btnEditTemplate As System.Windows.Forms.Button
    Friend WithEvents btnAddTemplate As System.Windows.Forms.Button
    Friend WithEvents pnTemplate As System.Windows.Forms.Panel
    Friend WithEvents lblTRADINGCODE As System.Windows.Forms.Label
    Friend WithEvents txtTRADINGCODE As System.Windows.Forms.TextBox
    Friend WithEvents cboAPPLYPOLICY As System.Windows.Forms.CheckBox
    Friend WithEvents cboAPPLYACCT As AppCore.ComboBoxEx
    Private mv_arrObjFldVals() As CFieldVal

    Public Property IpAddress() As String
        Get
            Return mv_strIpAddress
        End Get
        Set(ByVal Value As String)
            mv_strIpAddress = Value
        End Set
    End Property
    Public Property WsName() As String
        Get
            Return mv_strWsName
        End Get
        Set(ByVal Value As String)
            mv_strWsName = Value
        End Set
    End Property

#End Region

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents txtACCTNO As FlexMaskEditBox
    Friend WithEvents txtDESCRIPTION As System.Windows.Forms.TextBox
    Friend WithEvents lblDESCRIPTION As System.Windows.Forms.Label
    Friend WithEvents lblACTYPE As System.Windows.Forms.Label
    Friend WithEvents lblACCTNO As System.Windows.Forms.Label
    Friend WithEvents lblAFTYPE As System.Windows.Forms.Label
    Friend WithEvents lblLASTDATE As System.Windows.Forms.Label
    Friend WithEvents lblSTATUS As System.Windows.Forms.Label
    Friend WithEvents lblTERMOFUSE As System.Windows.Forms.Label
    Friend WithEvents cboSTATUS As ComboBoxEx
    Friend WithEvents cboTERMOFUSE As ComboBoxEx
    Friend WithEvents txtACTYPE As FlexMaskEditBox
    Friend WithEvents dtpLASTDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents grbMainInfo As System.Windows.Forms.GroupBox
    Friend WithEvents lblCUSTID As System.Windows.Forms.Label
    Friend WithEvents txtCUSTID As FlexMaskEditBox
    Friend WithEvents tabMainInfo As System.Windows.Forms.TabPage
    Friend WithEvents tabMember As System.Windows.Forms.TabPage
    Friend WithEvents pnMember As System.Windows.Forms.Panel
    Friend WithEvents btnCADD As System.Windows.Forms.Button
    Friend WithEvents btnCEDIT As System.Windows.Forms.Button
    Friend WithEvents btnCDEL As System.Windows.Forms.Button
    Friend WithEvents btnCVIEW As System.Windows.Forms.Button
    Friend WithEvents lblCFTELELIMIT As System.Windows.Forms.Label
    Friend WithEvents txtCFTELELIMIT As System.Windows.Forms.TextBox
    Friend WithEvents lblCFONLINELIMIT As System.Windows.Forms.Label
    Friend WithEvents txtCFONLINELIMIT As System.Windows.Forms.TextBox
    Friend WithEvents tabSevice As System.Windows.Forms.TabPage
    Friend WithEvents cboTRADEFLOOR As AppCore.ComboBoxEx
    Friend WithEvents lblTRADEFLOOR As System.Windows.Forms.Label
    Friend WithEvents cboTRADETELEPHONE As AppCore.ComboBoxEx
    Friend WithEvents lblTRADETELEPHONE As System.Windows.Forms.Label
    Friend WithEvents cboTRADEONLINE As AppCore.ComboBoxEx
    Friend WithEvents lblTRADEONLINE As System.Windows.Forms.Label
    Friend WithEvents txtTRADEPHONE As System.Windows.Forms.TextBox
    Friend WithEvents lblTRADEPHONE As System.Windows.Forms.Label
    Friend WithEvents txtPIN As System.Windows.Forms.TextBox
    Friend WithEvents lblPIN As System.Windows.Forms.Label
    Friend WithEvents txtEMAIL As System.Windows.Forms.TextBox
    Friend WithEvents lblEMAIL As System.Windows.Forms.Label
    Friend WithEvents txtFAX As System.Windows.Forms.TextBox
    Friend WithEvents lblFAX As System.Windows.Forms.Label
    Friend WithEvents lblADDRESS As System.Windows.Forms.Label
    Friend WithEvents grbLimit As System.Windows.Forms.GroupBox
    Friend WithEvents lblMARGINLINE As System.Windows.Forms.Label
    Friend WithEvents txtMARGINLINE As System.Windows.Forms.TextBox
    Friend WithEvents txtTRADELINE As System.Windows.Forms.TextBox
    Friend WithEvents lblTRADELINE As System.Windows.Forms.Label
    Friend WithEvents txtADVANCELINE As System.Windows.Forms.TextBox
    Friend WithEvents lblADVANCELINE As System.Windows.Forms.Label
    Friend WithEvents txtREPOLINE As System.Windows.Forms.TextBox
    Friend WithEvents lblREPOLINE As System.Windows.Forms.Label
    Friend WithEvents lblDEPOSITLINE As System.Windows.Forms.Label
    Friend WithEvents txtBRATIO As System.Windows.Forms.TextBox
    Friend WithEvents lblBRATIO As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents tabAnthorize As System.Windows.Forms.TabPage
    Friend WithEvents pnAnthorize As System.Windows.Forms.Panel
    Friend WithEvents btnADEL As System.Windows.Forms.Button
    Friend WithEvents btnAEDIT As System.Windows.Forms.Button
    Friend WithEvents btnAVIEW As System.Windows.Forms.Button
    Friend WithEvents btnAADD As System.Windows.Forms.Button
    Friend WithEvents cboAFTYPE As AppCore.ComboBoxEx
    Friend WithEvents txtDEPOSITLINE As System.Windows.Forms.TextBox
    Friend WithEvents txtMISCRATE As System.Windows.Forms.TextBox
    Friend WithEvents lblMISCRATE As System.Windows.Forms.Label
    Friend WithEvents txtDEPORATE As System.Windows.Forms.TextBox
    Friend WithEvents lblDEPORATE As System.Windows.Forms.Label
    Friend WithEvents txtTRADERATE As System.Windows.Forms.TextBox
    Friend WithEvents lblTRADERATE As System.Windows.Forms.Label
    Friend WithEvents tabACCOUNT As System.Windows.Forms.TabPage
    Friend WithEvents pnACCOUNT As System.Windows.Forms.Panel
    Friend WithEvents lblPHONE1 As System.Windows.Forms.Label
    Friend WithEvents txtPHONE1 As System.Windows.Forms.TextBox
    Friend WithEvents lblISOTC As System.Windows.Forms.Label
    Friend WithEvents cboISOTC As AppCore.ComboBoxEx
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboCONSULTANT As AppCore.ComboBoxEx
    Friend WithEvents btnGenContractNo As System.Windows.Forms.Button
    Friend WithEvents lblCUSTNAME As System.Windows.Forms.Label
    Friend WithEvents lblONLINELIMIT As System.Windows.Forms.Label
    Friend WithEvents txtONLINELIMIT As System.Windows.Forms.TextBox
    Friend WithEvents lblTELELIMIT As System.Windows.Forms.Label
    Friend WithEvents txtTELELIMIT As System.Windows.Forms.TextBox
    Friend WithEvents btnGenCustodyCD As System.Windows.Forms.Button
    Friend WithEvents lblCUSTODYCD As System.Windows.Forms.Label
    Friend WithEvents txtCUSTODYCD As System.Windows.Forms.MaskedTextBox
    Friend WithEvents tabReport As System.Windows.Forms.TabPage
    Friend WithEvents txtFEEBASE As System.Windows.Forms.TextBox
    Friend WithEvents lblFEEBASE As System.Windows.Forms.Label
    Friend WithEvents btnRPTDEL As System.Windows.Forms.Button
    Friend WithEvents btnRPTEDIT As System.Windows.Forms.Button
    Friend WithEvents btnRPTVIEW As System.Windows.Forms.Button
    Friend WithEvents btnRPTADD As System.Windows.Forms.Button
    Friend WithEvents txtADDRESS As System.Windows.Forms.TextBox
    Friend WithEvents lblFAX1 As System.Windows.Forms.Label
    Friend WithEvents txtFAX1 As System.Windows.Forms.TextBox
    Friend WithEvents pnReport As System.Windows.Forms.Panel
    Friend WithEvents grbBankInfo As System.Windows.Forms.GroupBox
    Friend WithEvents txtBANKACCTNOBLOCK As System.Windows.Forms.TextBox
    Friend WithEvents lblBANKACCTNOBLOCK As System.Windows.Forms.Label
    Friend WithEvents cboALLOWDEBIT As AppCore.ComboBoxEx
    Friend WithEvents txtBANKACCTNO As System.Windows.Forms.TextBox
    Friend WithEvents lblALLOWDEBIT As System.Windows.Forms.Label
    Friend WithEvents cboBANKNAME As AppCore.ComboBoxEx
    Friend WithEvents lblBANKNAME As System.Windows.Forms.Label
    Friend WithEvents txtSWIFTCODE As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblSTMCYCLE As System.Windows.Forms.Label
    Friend WithEvents lblLANGUAGE As System.Windows.Forms.Label
    Friend WithEvents lblRECEIVEVIA As System.Windows.Forms.Label
    Friend WithEvents cboSTMCYCLE As AppCore.ComboBoxEx
    Friend WithEvents cboLANGUAGE As AppCore.ComboBoxEx
    Friend WithEvents cboRECEIVEVIA As AppCore.ComboBoxEx
    Friend WithEvents pnMemberContract As System.Windows.Forms.Panel
    Friend WithEvents btnDELCM As System.Windows.Forms.Button
    Friend WithEvents btnEDITCM As System.Windows.Forms.Button
    Friend WithEvents btnVIEWCM As System.Windows.Forms.Button
    Friend WithEvents btnADDCM As System.Windows.Forms.Button
    Friend WithEvents tabContractMember As System.Windows.Forms.TabPage
    Friend WithEvents tabAFMAST As System.Windows.Forms.TabControl
    Friend WithEvents tabEXTREFER As System.Windows.Forms.TabPage
    Friend WithEvents btnEDEL As System.Windows.Forms.Button
    Friend WithEvents btnEEDIT As System.Windows.Forms.Button
    Friend WithEvents btnEVIEW As System.Windows.Forms.Button
    Friend WithEvents btnEADD As System.Windows.Forms.Button
    Friend WithEvents pnExtRefer As System.Windows.Forms.Panel
    Friend WithEvents tabICCF As System.Windows.Forms.TabPage
    Friend WithEvents cboTLMODCODE As AppCore.ComboBoxEx
    Friend WithEvents lblTLMODCODE As System.Windows.Forms.Label
    Friend WithEvents pnICCF As System.Windows.Forms.Panel
    Friend WithEvents cboVIA As AppCore.ComboBoxEx
    Friend WithEvents lblVIA As System.Windows.Forms.Label
    Friend WithEvents cboCOREBANK As AppCore.ComboBoxEx
    Friend WithEvents lblCOREBANK As System.Windows.Forms.Label
    Friend WithEvents lblBANKACCTNO As System.Windows.Forms.Label
    Friend WithEvents grbMRService As System.Windows.Forms.GroupBox
    Friend WithEvents lblMRMRATE As System.Windows.Forms.Label
    Friend WithEvents txtMRMRATE As System.Windows.Forms.TextBox
    Friend WithEvents txtMRIRATE As System.Windows.Forms.TextBox
    Friend WithEvents lblMRIRATE As System.Windows.Forms.Label
    'Friend WithEvents lblMRDUEAY As System.Windows.Forms.Label
    Friend WithEvents txtMRLRATE As System.Windows.Forms.TextBox
    Friend WithEvents lblMRLRATE As System.Windows.Forms.Label
    Friend WithEvents lblMRCLAMT As System.Windows.Forms.Label
    Friend WithEvents txtMRCLAMT As System.Windows.Forms.TextBox
    'Friend WithEvents txtMREXTDAY As System.Windows.Forms.TextBox
    'Friend WithEvents lblMREXTDAY As System.Windows.Forms.Label
    Friend WithEvents lblMRCRLIMITMAX As System.Windows.Forms.Label
    Friend WithEvents txtMRCRLIMITMAX As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtMRCRLIMIT As System.Windows.Forms.TextBox
    Friend WithEvents lblMRCRLIMIT As System.Windows.Forms.Label
    'Friend WithEvents txtMRDUEDAY As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAFMAST_bk))
        Me.txtACTYPE = New AppCore.FlexMaskEditBox
        Me.txtACCTNO = New AppCore.FlexMaskEditBox
        Me.cboSTATUS = New AppCore.ComboBoxEx
        Me.txtDESCRIPTION = New System.Windows.Forms.TextBox
        Me.cboTERMOFUSE = New AppCore.ComboBoxEx
        Me.lblDESCRIPTION = New System.Windows.Forms.Label
        Me.lblACTYPE = New System.Windows.Forms.Label
        Me.lblACCTNO = New System.Windows.Forms.Label
        Me.lblAFTYPE = New System.Windows.Forms.Label
        Me.lblLASTDATE = New System.Windows.Forms.Label
        Me.lblSTATUS = New System.Windows.Forms.Label
        Me.lblTERMOFUSE = New System.Windows.Forms.Label
        Me.dtpLASTDATE = New System.Windows.Forms.DateTimePicker
        Me.grbMainInfo = New System.Windows.Forms.GroupBox
        Me.cboBRKFEETYPE = New AppCore.ComboBoxEx
        Me.lblBRKFEETYPE = New System.Windows.Forms.Label
        Me.txtTRFBUYRATE = New System.Windows.Forms.TextBox
        Me.lblTRFBUYRATE = New System.Windows.Forms.Label
        Me.txtTRFBUYEXT = New System.Windows.Forms.TextBox
        Me.lblTRFBUYEXT = New System.Windows.Forms.Label
        Me.lblUsername = New System.Windows.Forms.Label
        Me.txtTLID = New System.Windows.Forms.TextBox
        Me.lblUser = New System.Windows.Forms.Label
        Me.lblCAREBY = New System.Windows.Forms.Label
        Me.cboCAREBY = New AppCore.ComboBoxEx
        Me.cboAUTOADV = New AppCore.ComboBoxEx
        Me.lblAUTOADV = New System.Windows.Forms.Label
        Me.cboETS = New AppCore.ComboBoxEx
        Me.lblETS = New System.Windows.Forms.Label
        Me.cboVIA = New AppCore.ComboBoxEx
        Me.lblVIA = New System.Windows.Forms.Label
        Me.grbBankInfo = New System.Windows.Forms.GroupBox
        Me.lblCOREBANK = New System.Windows.Forms.Label
        Me.cboCOREBANK = New AppCore.ComboBoxEx
        Me.txtBANKACCTNOBLOCK = New System.Windows.Forms.TextBox
        Me.lblBANKACCTNOBLOCK = New System.Windows.Forms.Label
        Me.cboALLOWDEBIT = New AppCore.ComboBoxEx
        Me.txtBANKACCTNO = New System.Windows.Forms.TextBox
        Me.lblALLOWDEBIT = New System.Windows.Forms.Label
        Me.cboBANKNAME = New AppCore.ComboBoxEx
        Me.lblBANKNAME = New System.Windows.Forms.Label
        Me.txtSWIFTCODE = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblBANKACCTNO = New System.Windows.Forms.Label
        Me.txtADDRESS = New System.Windows.Forms.TextBox
        Me.btnGenCustodyCD = New System.Windows.Forms.Button
        Me.lblCUSTODYCD = New System.Windows.Forms.Label
        Me.txtCUSTODYCD = New System.Windows.Forms.MaskedTextBox
        Me.lblCUSTNAME = New System.Windows.Forms.Label
        Me.cboISOTC = New AppCore.ComboBoxEx
        Me.lblISOTC = New System.Windows.Forms.Label
        Me.cboAFTYPE = New AppCore.ComboBoxEx
        Me.txtCUSTID = New AppCore.FlexMaskEditBox
        Me.lblCUSTID = New System.Windows.Forms.Label
        Me.cboCONSULTANT = New AppCore.ComboBoxEx
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtCFONLINELIMIT = New System.Windows.Forms.TextBox
        Me.lblCFONLINELIMIT = New System.Windows.Forms.Label
        Me.txtCFTELELIMIT = New System.Windows.Forms.TextBox
        Me.lblCFTELELIMIT = New System.Windows.Forms.Label
        Me.cboTRADEONLINE = New AppCore.ComboBoxEx
        Me.lblTRADEONLINE = New System.Windows.Forms.Label
        Me.cboTRADEFLOOR = New AppCore.ComboBoxEx
        Me.lblTRADEFLOOR = New System.Windows.Forms.Label
        Me.cboTRADETELEPHONE = New AppCore.ComboBoxEx
        Me.lblTRADETELEPHONE = New System.Windows.Forms.Label
        Me.txtTRADEPHONE = New System.Windows.Forms.TextBox
        Me.lblTRADEPHONE = New System.Windows.Forms.Label
        Me.txtPHONE1 = New System.Windows.Forms.TextBox
        Me.lblPHONE1 = New System.Windows.Forms.Label
        Me.lblFAX = New System.Windows.Forms.Label
        Me.txtFAX = New System.Windows.Forms.TextBox
        Me.lblFAX1 = New System.Windows.Forms.Label
        Me.txtFAX1 = New System.Windows.Forms.TextBox
        Me.txtEMAIL = New System.Windows.Forms.TextBox
        Me.lblEMAIL = New System.Windows.Forms.Label
        Me.lblADDRESS = New System.Windows.Forms.Label
        Me.txtPIN = New System.Windows.Forms.TextBox
        Me.lblPIN = New System.Windows.Forms.Label
        Me.btnGenContractNo = New System.Windows.Forms.Button
        Me.tabAFMAST = New System.Windows.Forms.TabControl
        Me.tabMainInfo = New System.Windows.Forms.TabPage
        Me.tabSevice = New System.Windows.Forms.TabPage
        Me.grbLimit = New System.Windows.Forms.GroupBox
        Me.grbMRService = New System.Windows.Forms.GroupBox
        Me.lblMRIRATIO = New System.Windows.Forms.Label
        Me.lblMRCRLIMITMAX = New System.Windows.Forms.Label
        Me.txtMRIRATIO = New System.Windows.Forms.TextBox
        Me.txtMRCRLIMITMAX = New System.Windows.Forms.TextBox
        Me.txtMRMRATIO = New System.Windows.Forms.TextBox
        Me.lblMRMRATIO = New System.Windows.Forms.Label
        Me.txtMRLRATIO = New System.Windows.Forms.TextBox
        Me.lblMRLRATIO = New System.Windows.Forms.Label
        Me.txtMRCRLIMIT = New System.Windows.Forms.TextBox
        Me.lblMRCRLIMIT = New System.Windows.Forms.Label
        Me.lblMRCLAMT = New System.Windows.Forms.Label
        Me.txtMRCLAMT = New System.Windows.Forms.TextBox
        Me.txtMRLRATE = New System.Windows.Forms.TextBox
        Me.lblMRLRATE = New System.Windows.Forms.Label
        Me.lblMRMRATE = New System.Windows.Forms.Label
        Me.txtMRMRATE = New System.Windows.Forms.TextBox
        Me.txtMRIRATE = New System.Windows.Forms.TextBox
        Me.lblMRIRATE = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtFEEBASE = New System.Windows.Forms.TextBox
        Me.lblFEEBASE = New System.Windows.Forms.Label
        Me.txtONLINELIMIT = New System.Windows.Forms.TextBox
        Me.lblONLINELIMIT = New System.Windows.Forms.Label
        Me.txtTELELIMIT = New System.Windows.Forms.TextBox
        Me.lblTELELIMIT = New System.Windows.Forms.Label
        Me.txtMISCRATE = New System.Windows.Forms.TextBox
        Me.lblMISCRATE = New System.Windows.Forms.Label
        Me.txtDEPORATE = New System.Windows.Forms.TextBox
        Me.lblDEPORATE = New System.Windows.Forms.Label
        Me.txtTRADERATE = New System.Windows.Forms.TextBox
        Me.lblTRADERATE = New System.Windows.Forms.Label
        Me.txtDEPOSITLINE = New System.Windows.Forms.TextBox
        Me.lblBRATIO = New System.Windows.Forms.Label
        Me.lblDEPOSITLINE = New System.Windows.Forms.Label
        Me.lblREPOLINE = New System.Windows.Forms.Label
        Me.lblADVANCELINE = New System.Windows.Forms.Label
        Me.lblTRADELINE = New System.Windows.Forms.Label
        Me.txtBRATIO = New System.Windows.Forms.TextBox
        Me.txtREPOLINE = New System.Windows.Forms.TextBox
        Me.txtADVANCELINE = New System.Windows.Forms.TextBox
        Me.txtTRADELINE = New System.Windows.Forms.TextBox
        Me.txtMARGINLINE = New System.Windows.Forms.TextBox
        Me.lblMARGINLINE = New System.Windows.Forms.Label
        Me.tabContractMember = New System.Windows.Forms.TabPage
        Me.btnDELCM = New System.Windows.Forms.Button
        Me.btnEDITCM = New System.Windows.Forms.Button
        Me.btnVIEWCM = New System.Windows.Forms.Button
        Me.btnADDCM = New System.Windows.Forms.Button
        Me.pnMemberContract = New System.Windows.Forms.Panel
        Me.tabACCOUNT = New System.Windows.Forms.TabPage
        Me.pnACCOUNT = New System.Windows.Forms.Panel
        Me.tabEXTREFER = New System.Windows.Forms.TabPage
        Me.btnEDEL = New System.Windows.Forms.Button
        Me.btnEEDIT = New System.Windows.Forms.Button
        Me.btnEVIEW = New System.Windows.Forms.Button
        Me.btnEADD = New System.Windows.Forms.Button
        Me.pnExtRefer = New System.Windows.Forms.Panel
        Me.tabAnthorize = New System.Windows.Forms.TabPage
        Me.btnADEL = New System.Windows.Forms.Button
        Me.btnAEDIT = New System.Windows.Forms.Button
        Me.btnAVIEW = New System.Windows.Forms.Button
        Me.btnAADD = New System.Windows.Forms.Button
        Me.pnAnthorize = New System.Windows.Forms.Panel
        Me.tabICCF = New System.Windows.Forms.TabPage
        Me.pnICCF = New System.Windows.Forms.Panel
        Me.cboTLMODCODE = New AppCore.ComboBoxEx
        Me.lblTLMODCODE = New System.Windows.Forms.Label
        Me.tabTxmap = New System.Windows.Forms.TabPage
        Me.pnTxmap = New System.Windows.Forms.Panel
        Me.btnTXDEL = New System.Windows.Forms.Button
        Me.btnTXEDIT = New System.Windows.Forms.Button
        Me.btnTXVIEW = New System.Windows.Forms.Button
        Me.btnTXADD = New System.Windows.Forms.Button
        Me.tabAFSERULE = New System.Windows.Forms.TabPage
        Me.btnASDEL = New System.Windows.Forms.Button
        Me.btnASEDIT = New System.Windows.Forms.Button
        Me.btnASVIEW = New System.Windows.Forms.Button
        Me.btnASADD = New System.Windows.Forms.Button
        Me.pnAFSERULE = New System.Windows.Forms.Panel
        Me.tabOTRIGHT = New System.Windows.Forms.TabPage
        Me.btnOTDEL = New System.Windows.Forms.Button
        Me.btnOTEDIT = New System.Windows.Forms.Button
        Me.btnOTVIEW = New System.Windows.Forms.Button
        Me.btnOTADD = New System.Windows.Forms.Button
        Me.pnOTRightAsgn = New System.Windows.Forms.Panel
        Me.tabTemplates = New System.Windows.Forms.TabPage
        Me.pnTemplate = New System.Windows.Forms.Panel
        Me.btnViewTemplate = New System.Windows.Forms.Button
        Me.btnDeleteTemplate = New System.Windows.Forms.Button
        Me.btnEditTemplate = New System.Windows.Forms.Button
        Me.btnAddTemplate = New System.Windows.Forms.Button
        Me.tabReport = New System.Windows.Forms.TabPage
        Me.cboRECEIVEVIA = New AppCore.ComboBoxEx
        Me.cboLANGUAGE = New AppCore.ComboBoxEx
        Me.lblSTMCYCLE = New System.Windows.Forms.Label
        Me.lblLANGUAGE = New System.Windows.Forms.Label
        Me.lblRECEIVEVIA = New System.Windows.Forms.Label
        Me.pnReport = New System.Windows.Forms.Panel
        Me.btnRPTDEL = New System.Windows.Forms.Button
        Me.btnRPTEDIT = New System.Windows.Forms.Button
        Me.btnRPTVIEW = New System.Windows.Forms.Button
        Me.btnRPTADD = New System.Windows.Forms.Button
        Me.cboSTMCYCLE = New AppCore.ComboBoxEx
        Me.tabMember = New System.Windows.Forms.TabPage
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.btnCDEL = New System.Windows.Forms.Button
        Me.btnCEDIT = New System.Windows.Forms.Button
        Me.btnCVIEW = New System.Windows.Forms.Button
        Me.btnCADD = New System.Windows.Forms.Button
        Me.pnMember = New System.Windows.Forms.Panel
        Me.btnCheckAcc = New System.Windows.Forms.Button
        Me.txtOPNDATE = New System.Windows.Forms.DateTimePicker
        Me.txtBRID = New System.Windows.Forms.TextBox
        Me.lblCUSTATCOM = New System.Windows.Forms.Label
        Me.cboCUSTATCOM = New AppCore.ComboBoxEx
        Me.lblTRADINGCODE = New System.Windows.Forms.Label
        Me.txtTRADINGCODE = New System.Windows.Forms.TextBox
        Me.cboAPPLYPOLICY = New System.Windows.Forms.CheckBox
        Me.cboAPPLYACCT = New AppCore.ComboBoxEx
        Me.Panel1.SuspendLayout()
        Me.grbMainInfo.SuspendLayout()
        Me.grbBankInfo.SuspendLayout()
        Me.tabAFMAST.SuspendLayout()
        Me.tabMainInfo.SuspendLayout()
        Me.tabSevice.SuspendLayout()
        Me.grbLimit.SuspendLayout()
        Me.grbMRService.SuspendLayout()
        Me.tabContractMember.SuspendLayout()
        Me.tabACCOUNT.SuspendLayout()
        Me.tabEXTREFER.SuspendLayout()
        Me.tabAnthorize.SuspendLayout()
        Me.tabICCF.SuspendLayout()
        Me.tabTxmap.SuspendLayout()
        Me.tabAFSERULE.SuspendLayout()
        Me.tabOTRIGHT.SuspendLayout()
        Me.tabTemplates.SuspendLayout()
        Me.tabReport.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(446, 560)
        Me.btnOK.TabIndex = 9
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(526, 560)
        Me.btnCancel.TabIndex = 10
        '
        'btnApply
        '
        Me.btnApply.Location = New System.Drawing.Point(606, 560)
        Me.btnApply.TabIndex = 11
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(689, 50)
        Me.Panel1.TabIndex = 0
        '
        'btnApprv
        '
        Me.btnApprv.Location = New System.Drawing.Point(365, 560)
        Me.btnApprv.TabIndex = 8
        '
        'cboLink
        '
        Me.cboLink.Location = New System.Drawing.Point(13, 559)
        Me.cboLink.Size = New System.Drawing.Size(190, 21)
        '
        'txtACTYPE
        '
        Me.txtACTYPE.BackColor = System.Drawing.Color.GreenYellow
        Me.txtACTYPE.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtACTYPE.Location = New System.Drawing.Point(573, 17)
        Me.txtACTYPE.Name = "txtACTYPE"
        Me.txtACTYPE.Size = New System.Drawing.Size(80, 21)
        Me.txtACTYPE.TabIndex = 3
        Me.txtACTYPE.Tag = "ACTYPE"
        Me.txtACTYPE.Text = "txtACTYPE"
        '
        'txtACCTNO
        '
        Me.txtACCTNO.BackColor = System.Drawing.Color.White
        Me.txtACCTNO.ForeColor = System.Drawing.Color.Red
        Me.txtACCTNO.Location = New System.Drawing.Point(114, 55)
        Me.txtACCTNO.Name = "txtACCTNO"
        Me.txtACCTNO.Size = New System.Drawing.Size(100, 21)
        Me.txtACCTNO.TabIndex = 2
        Me.txtACCTNO.Tag = "ACCTNO"
        Me.txtACCTNO.Text = "txtACCTNO"
        '
        'cboSTATUS
        '
        Me.cboSTATUS.DisplayMember = "DISPLAY"
        Me.cboSTATUS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSTATUS.Location = New System.Drawing.Point(545, 106)
        Me.cboSTATUS.Name = "cboSTATUS"
        Me.cboSTATUS.Size = New System.Drawing.Size(108, 21)
        Me.cboSTATUS.TabIndex = 22
        Me.cboSTATUS.Tag = "STATUS"
        Me.cboSTATUS.ValueMember = "VALUE"
        '
        'txtDESCRIPTION
        '
        Me.txtDESCRIPTION.Location = New System.Drawing.Point(106, 311)
        Me.txtDESCRIPTION.MaxLength = 250
        Me.txtDESCRIPTION.Multiline = True
        Me.txtDESCRIPTION.Name = "txtDESCRIPTION"
        Me.txtDESCRIPTION.Size = New System.Drawing.Size(545, 21)
        Me.txtDESCRIPTION.TabIndex = 51
        Me.txtDESCRIPTION.Tag = "DESCRIPTION"
        Me.txtDESCRIPTION.Text = "txtDESCRIPTION"
        '
        'cboTERMOFUSE
        '
        Me.cboTERMOFUSE.DisplayMember = "DISPLAY"
        Me.cboTERMOFUSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTERMOFUSE.Location = New System.Drawing.Point(333, 80)
        Me.cboTERMOFUSE.Name = "cboTERMOFUSE"
        Me.cboTERMOFUSE.Size = New System.Drawing.Size(149, 21)
        Me.cboTERMOFUSE.TabIndex = 14
        Me.cboTERMOFUSE.Tag = "TERMOFUSE"
        Me.cboTERMOFUSE.ValueMember = "VALUE"
        '
        'lblDESCRIPTION
        '
        Me.lblDESCRIPTION.AutoSize = True
        Me.lblDESCRIPTION.Location = New System.Drawing.Point(6, 312)
        Me.lblDESCRIPTION.Name = "lblDESCRIPTION"
        Me.lblDESCRIPTION.Size = New System.Drawing.Size(85, 13)
        Me.lblDESCRIPTION.TabIndex = 50
        Me.lblDESCRIPTION.Tag = "DESCRIPTION"
        Me.lblDESCRIPTION.Text = "lblDESCRIPTION"
        Me.lblDESCRIPTION.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblACTYPE
        '
        Me.lblACTYPE.Location = New System.Drawing.Point(487, 17)
        Me.lblACTYPE.Name = "lblACTYPE"
        Me.lblACTYPE.Size = New System.Drawing.Size(80, 17)
        Me.lblACTYPE.TabIndex = 2
        Me.lblACTYPE.Tag = "ACTYPE"
        Me.lblACTYPE.Text = "lblACTYPE"
        Me.lblACTYPE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblACCTNO
        '
        Me.lblACCTNO.Location = New System.Drawing.Point(15, 54)
        Me.lblACCTNO.Name = "lblACCTNO"
        Me.lblACCTNO.Size = New System.Drawing.Size(96, 21)
        Me.lblACCTNO.TabIndex = 1
        Me.lblACCTNO.Tag = "ACCTNO"
        Me.lblACCTNO.Text = "lblACCTNO"
        Me.lblACCTNO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAFTYPE
        '
        Me.lblAFTYPE.AutoSize = True
        Me.lblAFTYPE.Location = New System.Drawing.Point(6, 76)
        Me.lblAFTYPE.Name = "lblAFTYPE"
        Me.lblAFTYPE.Size = New System.Drawing.Size(54, 13)
        Me.lblAFTYPE.TabIndex = 11
        Me.lblAFTYPE.Tag = "AFTYPE"
        Me.lblAFTYPE.Text = "lblAFTYPE"
        Me.lblAFTYPE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLASTDATE
        '
        Me.lblLASTDATE.AutoSize = True
        Me.lblLASTDATE.Location = New System.Drawing.Point(450, 136)
        Me.lblLASTDATE.Name = "lblLASTDATE"
        Me.lblLASTDATE.Size = New System.Drawing.Size(67, 13)
        Me.lblLASTDATE.TabIndex = 27
        Me.lblLASTDATE.Tag = "LASTDATE"
        Me.lblLASTDATE.Text = "lblLASTDATE"
        Me.lblLASTDATE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSTATUS
        '
        Me.lblSTATUS.AutoSize = True
        Me.lblSTATUS.Location = New System.Drawing.Point(450, 106)
        Me.lblSTATUS.Name = "lblSTATUS"
        Me.lblSTATUS.Size = New System.Drawing.Size(55, 13)
        Me.lblSTATUS.TabIndex = 21
        Me.lblSTATUS.Tag = "STATUS"
        Me.lblSTATUS.Text = "lblSTATUS"
        Me.lblSTATUS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTERMOFUSE
        '
        Me.lblTERMOFUSE.AutoSize = True
        Me.lblTERMOFUSE.Location = New System.Drawing.Point(214, 80)
        Me.lblTERMOFUSE.Name = "lblTERMOFUSE"
        Me.lblTERMOFUSE.Size = New System.Drawing.Size(77, 13)
        Me.lblTERMOFUSE.TabIndex = 13
        Me.lblTERMOFUSE.Tag = "TERMOFUSE"
        Me.lblTERMOFUSE.Text = "lblTERMOFUSE"
        Me.lblTERMOFUSE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpLASTDATE
        '
        Me.dtpLASTDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpLASTDATE.Location = New System.Drawing.Point(545, 136)
        Me.dtpLASTDATE.Name = "dtpLASTDATE"
        Me.dtpLASTDATE.Size = New System.Drawing.Size(108, 21)
        Me.dtpLASTDATE.TabIndex = 28
        Me.dtpLASTDATE.Tag = "LASTDATE"
        '
        'grbMainInfo
        '
        Me.grbMainInfo.BackColor = System.Drawing.SystemColors.Control
        Me.grbMainInfo.Controls.Add(Me.cboBRKFEETYPE)
        Me.grbMainInfo.Controls.Add(Me.lblBRKFEETYPE)
        Me.grbMainInfo.Controls.Add(Me.txtTRFBUYRATE)
        Me.grbMainInfo.Controls.Add(Me.lblTRFBUYRATE)
        Me.grbMainInfo.Controls.Add(Me.txtTRFBUYEXT)
        Me.grbMainInfo.Controls.Add(Me.lblTRFBUYEXT)
        Me.grbMainInfo.Controls.Add(Me.lblUsername)
        Me.grbMainInfo.Controls.Add(Me.txtTLID)
        Me.grbMainInfo.Controls.Add(Me.lblUser)
        Me.grbMainInfo.Controls.Add(Me.lblCAREBY)
        Me.grbMainInfo.Controls.Add(Me.cboCAREBY)
        Me.grbMainInfo.Controls.Add(Me.cboAUTOADV)
        Me.grbMainInfo.Controls.Add(Me.lblAUTOADV)
        Me.grbMainInfo.Controls.Add(Me.cboETS)
        Me.grbMainInfo.Controls.Add(Me.lblETS)
        Me.grbMainInfo.Controls.Add(Me.cboVIA)
        Me.grbMainInfo.Controls.Add(Me.lblVIA)
        Me.grbMainInfo.Controls.Add(Me.grbBankInfo)
        Me.grbMainInfo.Controls.Add(Me.txtADDRESS)
        Me.grbMainInfo.Controls.Add(Me.btnGenCustodyCD)
        Me.grbMainInfo.Controls.Add(Me.lblCUSTODYCD)
        Me.grbMainInfo.Controls.Add(Me.txtCUSTODYCD)
        Me.grbMainInfo.Controls.Add(Me.lblCUSTNAME)
        Me.grbMainInfo.Controls.Add(Me.cboISOTC)
        Me.grbMainInfo.Controls.Add(Me.lblISOTC)
        Me.grbMainInfo.Controls.Add(Me.cboAFTYPE)
        Me.grbMainInfo.Controls.Add(Me.txtCUSTID)
        Me.grbMainInfo.Controls.Add(Me.lblCUSTID)
        Me.grbMainInfo.Controls.Add(Me.lblACTYPE)
        Me.grbMainInfo.Controls.Add(Me.txtACTYPE)
        Me.grbMainInfo.Controls.Add(Me.lblAFTYPE)
        Me.grbMainInfo.Controls.Add(Me.lblLASTDATE)
        Me.grbMainInfo.Controls.Add(Me.dtpLASTDATE)
        Me.grbMainInfo.Controls.Add(Me.cboSTATUS)
        Me.grbMainInfo.Controls.Add(Me.lblSTATUS)
        Me.grbMainInfo.Controls.Add(Me.txtDESCRIPTION)
        Me.grbMainInfo.Controls.Add(Me.lblDESCRIPTION)
        Me.grbMainInfo.Controls.Add(Me.cboCONSULTANT)
        Me.grbMainInfo.Controls.Add(Me.Label1)
        Me.grbMainInfo.Controls.Add(Me.txtCFONLINELIMIT)
        Me.grbMainInfo.Controls.Add(Me.lblCFONLINELIMIT)
        Me.grbMainInfo.Controls.Add(Me.txtCFTELELIMIT)
        Me.grbMainInfo.Controls.Add(Me.lblCFTELELIMIT)
        Me.grbMainInfo.Controls.Add(Me.cboTRADEONLINE)
        Me.grbMainInfo.Controls.Add(Me.lblTRADEONLINE)
        Me.grbMainInfo.Controls.Add(Me.cboTRADEFLOOR)
        Me.grbMainInfo.Controls.Add(Me.lblTRADEFLOOR)
        Me.grbMainInfo.Controls.Add(Me.cboTRADETELEPHONE)
        Me.grbMainInfo.Controls.Add(Me.lblTRADETELEPHONE)
        Me.grbMainInfo.Controls.Add(Me.txtTRADEPHONE)
        Me.grbMainInfo.Controls.Add(Me.lblTRADEPHONE)
        Me.grbMainInfo.Controls.Add(Me.txtPHONE1)
        Me.grbMainInfo.Controls.Add(Me.lblPHONE1)
        Me.grbMainInfo.Controls.Add(Me.lblFAX)
        Me.grbMainInfo.Controls.Add(Me.txtFAX)
        Me.grbMainInfo.Controls.Add(Me.lblFAX1)
        Me.grbMainInfo.Controls.Add(Me.txtFAX1)
        Me.grbMainInfo.Controls.Add(Me.txtEMAIL)
        Me.grbMainInfo.Controls.Add(Me.lblEMAIL)
        Me.grbMainInfo.Controls.Add(Me.lblADDRESS)
        Me.grbMainInfo.Controls.Add(Me.cboTERMOFUSE)
        Me.grbMainInfo.Controls.Add(Me.lblTERMOFUSE)
        Me.grbMainInfo.Location = New System.Drawing.Point(4, 5)
        Me.grbMainInfo.Name = "grbMainInfo"
        Me.grbMainInfo.Size = New System.Drawing.Size(660, 434)
        Me.grbMainInfo.TabIndex = 0
        Me.grbMainInfo.TabStop = False
        Me.grbMainInfo.Tag = "grbMainInfo"
        Me.grbMainInfo.Text = "grbMainInfo"
        '
        'cboBRKFEETYPE
        '
        Me.cboBRKFEETYPE.DisplayMember = "DISPLAY"
        Me.cboBRKFEETYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBRKFEETYPE.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBRKFEETYPE.ItemHeight = 13
        Me.cboBRKFEETYPE.Location = New System.Drawing.Point(485, 256)
        Me.cboBRKFEETYPE.Name = "cboBRKFEETYPE"
        Me.cboBRKFEETYPE.Size = New System.Drawing.Size(168, 21)
        Me.cboBRKFEETYPE.TabIndex = 57
        Me.cboBRKFEETYPE.Tag = "BRKFEETYPE"
        Me.cboBRKFEETYPE.ValueMember = "VALUE"
        '
        'lblBRKFEETYPE
        '
        Me.lblBRKFEETYPE.AutoSize = True
        Me.lblBRKFEETYPE.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBRKFEETYPE.Location = New System.Drawing.Point(335, 259)
        Me.lblBRKFEETYPE.Name = "lblBRKFEETYPE"
        Me.lblBRKFEETYPE.Size = New System.Drawing.Size(78, 13)
        Me.lblBRKFEETYPE.TabIndex = 58
        Me.lblBRKFEETYPE.Tag = "BRKFEETYPE"
        Me.lblBRKFEETYPE.Text = "lblBRKFEETYPE"
        Me.lblBRKFEETYPE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTRFBUYRATE
        '
        Me.txtTRFBUYRATE.Location = New System.Drawing.Point(333, 285)
        Me.txtTRFBUYRATE.MaxLength = 10
        Me.txtTRFBUYRATE.Name = "txtTRFBUYRATE"
        Me.txtTRFBUYRATE.Size = New System.Drawing.Size(81, 21)
        Me.txtTRFBUYRATE.TabIndex = 56
        Me.txtTRFBUYRATE.Tag = "TRFBUYRATE"
        Me.txtTRFBUYRATE.Text = "txtTRFBUYRATE"
        '
        'lblTRFBUYRATE
        '
        Me.lblTRFBUYRATE.Location = New System.Drawing.Point(214, 284)
        Me.lblTRFBUYRATE.Name = "lblTRFBUYRATE"
        Me.lblTRFBUYRATE.Size = New System.Drawing.Size(94, 21)
        Me.lblTRFBUYRATE.TabIndex = 55
        Me.lblTRFBUYRATE.Tag = "TRFBUYRATE"
        Me.lblTRFBUYRATE.Text = "lblTRFBUYRATE"
        Me.lblTRFBUYRATE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTRFBUYEXT
        '
        Me.txtTRFBUYEXT.Location = New System.Drawing.Point(106, 284)
        Me.txtTRFBUYEXT.MaxLength = 10
        Me.txtTRFBUYEXT.Name = "txtTRFBUYEXT"
        Me.txtTRFBUYEXT.Size = New System.Drawing.Size(81, 21)
        Me.txtTRFBUYEXT.TabIndex = 54
        Me.txtTRFBUYEXT.Tag = "TRFBUYEXT"
        Me.txtTRFBUYEXT.Text = "txtTRFBUYEXT"
        '
        'lblTRFBUYEXT
        '
        Me.lblTRFBUYEXT.Location = New System.Drawing.Point(6, 283)
        Me.lblTRFBUYEXT.Name = "lblTRFBUYEXT"
        Me.lblTRFBUYEXT.Size = New System.Drawing.Size(73, 21)
        Me.lblTRFBUYEXT.TabIndex = 53
        Me.lblTRFBUYEXT.Tag = "TRFBUYEXT"
        Me.lblTRFBUYEXT.Text = "lblTRFBUYEXT"
        Me.lblTRFBUYEXT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUsername
        '
        Me.lblUsername.Location = New System.Drawing.Point(505, 253)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(145, 21)
        Me.lblUsername.TabIndex = 49
        Me.lblUsername.Tag = "Username"
        Me.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTLID
        '
        Me.txtTLID.Location = New System.Drawing.Point(570, 283)
        Me.txtTLID.MaxLength = 10
        Me.txtTLID.Name = "txtTLID"
        Me.txtTLID.Size = New System.Drawing.Size(81, 21)
        Me.txtTLID.TabIndex = 48
        Me.txtTLID.Tag = "TLID"
        Me.txtTLID.Text = "lblBRKFEETYPE"
        '
        'lblUser
        '
        Me.lblUser.Location = New System.Drawing.Point(491, 282)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(73, 21)
        Me.lblUser.TabIndex = 47
        Me.lblUser.Tag = "TLID"
        Me.lblUser.Text = "lblBRKFEETYPE"
        Me.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCAREBY
        '
        Me.lblCAREBY.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCAREBY.Location = New System.Drawing.Point(6, 253)
        Me.lblCAREBY.Name = "lblCAREBY"
        Me.lblCAREBY.Size = New System.Drawing.Size(74, 21)
        Me.lblCAREBY.TabIndex = 45
        Me.lblCAREBY.Tag = "CAREBY"
        Me.lblCAREBY.Text = "lblCAREBY"
        Me.lblCAREBY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCAREBY
        '
        Me.cboCAREBY.DisplayMember = "DISPLAY"
        Me.cboCAREBY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCAREBY.ItemHeight = 13
        Me.cboCAREBY.Location = New System.Drawing.Point(106, 254)
        Me.cboCAREBY.MaxLength = 3
        Me.cboCAREBY.Name = "cboCAREBY"
        Me.cboCAREBY.Size = New System.Drawing.Size(218, 21)
        Me.cboCAREBY.TabIndex = 46
        Me.cboCAREBY.Tag = "CAREBY"
        Me.cboCAREBY.ValueMember = "VALUE"
        '
        'cboAUTOADV
        '
        Me.cboAUTOADV.DisplayMember = "DISPLAY"
        Me.cboAUTOADV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAUTOADV.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAUTOADV.ItemHeight = 13
        Me.cboAUTOADV.Location = New System.Drawing.Point(485, 48)
        Me.cboAUTOADV.Name = "cboAUTOADV"
        Me.cboAUTOADV.Size = New System.Drawing.Size(58, 21)
        Me.cboAUTOADV.TabIndex = 9
        Me.cboAUTOADV.Tag = "AUTOADV"
        Me.cboAUTOADV.ValueMember = "VALUE"
        '
        'lblAUTOADV
        '
        Me.lblAUTOADV.AutoSize = True
        Me.lblAUTOADV.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAUTOADV.Location = New System.Drawing.Point(400, 51)
        Me.lblAUTOADV.Name = "lblAUTOADV"
        Me.lblAUTOADV.Size = New System.Drawing.Size(65, 13)
        Me.lblAUTOADV.TabIndex = 48
        Me.lblAUTOADV.Tag = "AUTOADV"
        Me.lblAUTOADV.Text = "lblAUTOADV"
        Me.lblAUTOADV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboETS
        '
        Me.cboETS.DisplayMember = "DISPLAY"
        Me.cboETS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboETS.Location = New System.Drawing.Point(545, 225)
        Me.cboETS.Name = "cboETS"
        Me.cboETS.Size = New System.Drawing.Size(105, 21)
        Me.cboETS.TabIndex = 44
        Me.cboETS.Tag = "ETS"
        Me.cboETS.ValueMember = "VALUE"
        '
        'lblETS
        '
        Me.lblETS.AutoSize = True
        Me.lblETS.Location = New System.Drawing.Point(458, 228)
        Me.lblETS.Name = "lblETS"
        Me.lblETS.Size = New System.Drawing.Size(35, 13)
        Me.lblETS.TabIndex = 43
        Me.lblETS.Tag = "ETS"
        Me.lblETS.Text = "lblETS"
        '
        'cboVIA
        '
        Me.cboVIA.DisplayMember = "DISPLAY"
        Me.cboVIA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVIA.Location = New System.Drawing.Point(573, 80)
        Me.cboVIA.Name = "cboVIA"
        Me.cboVIA.Size = New System.Drawing.Size(80, 21)
        Me.cboVIA.TabIndex = 16
        Me.cboVIA.Tag = "VIA"
        Me.cboVIA.ValueMember = "VALUE"
        '
        'lblVIA
        '
        Me.lblVIA.Location = New System.Drawing.Point(490, 80)
        Me.lblVIA.Name = "lblVIA"
        Me.lblVIA.Size = New System.Drawing.Size(80, 17)
        Me.lblVIA.TabIndex = 15
        Me.lblVIA.Tag = "VIA"
        Me.lblVIA.Text = "lblVIA"
        '
        'grbBankInfo
        '
        Me.grbBankInfo.BackColor = System.Drawing.Color.Transparent
        Me.grbBankInfo.Controls.Add(Me.lblCOREBANK)
        Me.grbBankInfo.Controls.Add(Me.cboCOREBANK)
        Me.grbBankInfo.Controls.Add(Me.txtBANKACCTNOBLOCK)
        Me.grbBankInfo.Controls.Add(Me.lblBANKACCTNOBLOCK)
        Me.grbBankInfo.Controls.Add(Me.cboALLOWDEBIT)
        Me.grbBankInfo.Controls.Add(Me.txtBANKACCTNO)
        Me.grbBankInfo.Controls.Add(Me.lblALLOWDEBIT)
        Me.grbBankInfo.Controls.Add(Me.cboBANKNAME)
        Me.grbBankInfo.Controls.Add(Me.lblBANKNAME)
        Me.grbBankInfo.Controls.Add(Me.txtSWIFTCODE)
        Me.grbBankInfo.Controls.Add(Me.Label2)
        Me.grbBankInfo.Controls.Add(Me.lblBANKACCTNO)
        Me.grbBankInfo.Location = New System.Drawing.Point(9, 338)
        Me.grbBankInfo.Name = "grbBankInfo"
        Me.grbBankInfo.Size = New System.Drawing.Size(644, 90)
        Me.grbBankInfo.TabIndex = 52
        Me.grbBankInfo.TabStop = False
        Me.grbBankInfo.Tag = "grbBankInfo"
        Me.grbBankInfo.Text = "grbBankInfo"
        '
        'lblCOREBANK
        '
        Me.lblCOREBANK.Location = New System.Drawing.Point(504, 52)
        Me.lblCOREBANK.Name = "lblCOREBANK"
        Me.lblCOREBANK.Size = New System.Drawing.Size(72, 21)
        Me.lblCOREBANK.TabIndex = 10
        Me.lblCOREBANK.Tag = "COREBANK"
        Me.lblCOREBANK.Text = "lblCOREBANK"
        Me.lblCOREBANK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboCOREBANK
        '
        Me.cboCOREBANK.DisplayMember = "DISPLAY"
        Me.cboCOREBANK.Location = New System.Drawing.Point(580, 52)
        Me.cboCOREBANK.Name = "cboCOREBANK"
        Me.cboCOREBANK.Size = New System.Drawing.Size(56, 21)
        Me.cboCOREBANK.TabIndex = 11
        Me.cboCOREBANK.Tag = "COREBANK"
        Me.cboCOREBANK.ValueMember = "VALUE"
        '
        'txtBANKACCTNOBLOCK
        '
        Me.txtBANKACCTNOBLOCK.Location = New System.Drawing.Point(160, 52)
        Me.txtBANKACCTNOBLOCK.MaxLength = 20
        Me.txtBANKACCTNOBLOCK.Name = "txtBANKACCTNOBLOCK"
        Me.txtBANKACCTNOBLOCK.Size = New System.Drawing.Size(104, 21)
        Me.txtBANKACCTNOBLOCK.TabIndex = 7
        Me.txtBANKACCTNOBLOCK.Tag = "BANKACCTNOBLOCK"
        Me.txtBANKACCTNOBLOCK.Text = "txtBANKACCTNOBLOCK"
        '
        'lblBANKACCTNOBLOCK
        '
        Me.lblBANKACCTNOBLOCK.Location = New System.Drawing.Point(4, 52)
        Me.lblBANKACCTNOBLOCK.Name = "lblBANKACCTNOBLOCK"
        Me.lblBANKACCTNOBLOCK.Size = New System.Drawing.Size(152, 21)
        Me.lblBANKACCTNOBLOCK.TabIndex = 6
        Me.lblBANKACCTNOBLOCK.Tag = "BANKACCTNOBLOCK"
        Me.lblBANKACCTNOBLOCK.Text = "lblBANKACCTNOBLOCK"
        Me.lblBANKACCTNOBLOCK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboALLOWDEBIT
        '
        Me.cboALLOWDEBIT.DisplayMember = "DISPLAY"
        Me.cboALLOWDEBIT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboALLOWDEBIT.Location = New System.Drawing.Point(580, 18)
        Me.cboALLOWDEBIT.Name = "cboALLOWDEBIT"
        Me.cboALLOWDEBIT.Size = New System.Drawing.Size(56, 21)
        Me.cboALLOWDEBIT.TabIndex = 5
        Me.cboALLOWDEBIT.Tag = "ALLOWDEBIT"
        Me.cboALLOWDEBIT.ValueMember = "VALUE"
        '
        'txtBANKACCTNO
        '
        Me.txtBANKACCTNO.Location = New System.Drawing.Point(160, 18)
        Me.txtBANKACCTNO.MaxLength = 20
        Me.txtBANKACCTNO.Name = "txtBANKACCTNO"
        Me.txtBANKACCTNO.Size = New System.Drawing.Size(104, 21)
        Me.txtBANKACCTNO.TabIndex = 1
        Me.txtBANKACCTNO.Tag = "BANKACCTNO"
        Me.txtBANKACCTNO.Text = "txtBANKACCTNO"
        '
        'lblALLOWDEBIT
        '
        Me.lblALLOWDEBIT.Location = New System.Drawing.Point(504, 18)
        Me.lblALLOWDEBIT.Name = "lblALLOWDEBIT"
        Me.lblALLOWDEBIT.Size = New System.Drawing.Size(72, 21)
        Me.lblALLOWDEBIT.TabIndex = 4
        Me.lblALLOWDEBIT.Tag = "ALLOWDEBIT"
        Me.lblALLOWDEBIT.Text = "lblALLOWDEBIT"
        Me.lblALLOWDEBIT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboBANKNAME
        '
        Me.cboBANKNAME.DisplayMember = "DISPLAY"
        Me.cboBANKNAME.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBANKNAME.Location = New System.Drawing.Point(362, 18)
        Me.cboBANKNAME.Name = "cboBANKNAME"
        Me.cboBANKNAME.Size = New System.Drawing.Size(136, 21)
        Me.cboBANKNAME.TabIndex = 3
        Me.cboBANKNAME.Tag = "BANKNAME"
        Me.cboBANKNAME.ValueMember = "VALUE"
        '
        'lblBANKNAME
        '
        Me.lblBANKNAME.Location = New System.Drawing.Point(268, 18)
        Me.lblBANKNAME.Name = "lblBANKNAME"
        Me.lblBANKNAME.Size = New System.Drawing.Size(72, 21)
        Me.lblBANKNAME.TabIndex = 2
        Me.lblBANKNAME.Tag = "BANKNAME"
        Me.lblBANKNAME.Text = "lblBANKNAME"
        Me.lblBANKNAME.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSWIFTCODE
        '
        Me.txtSWIFTCODE.Location = New System.Drawing.Point(362, 52)
        Me.txtSWIFTCODE.MaxLength = 20
        Me.txtSWIFTCODE.Name = "txtSWIFTCODE"
        Me.txtSWIFTCODE.Size = New System.Drawing.Size(136, 21)
        Me.txtSWIFTCODE.TabIndex = 9
        Me.txtSWIFTCODE.Tag = "SWIFTCODE"
        Me.txtSWIFTCODE.Text = "txtSWIFTCODE"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(268, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 21)
        Me.Label2.TabIndex = 8
        Me.Label2.Tag = "SWIFTCODE"
        Me.Label2.Text = "lblSWIFTCODE"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBANKACCTNO
        '
        Me.lblBANKACCTNO.Location = New System.Drawing.Point(4, 18)
        Me.lblBANKACCTNO.Name = "lblBANKACCTNO"
        Me.lblBANKACCTNO.Size = New System.Drawing.Size(112, 21)
        Me.lblBANKACCTNO.TabIndex = 0
        Me.lblBANKACCTNO.Tag = "BANKACCTNO"
        Me.lblBANKACCTNO.Text = "lblBANKACCTNO"
        Me.lblBANKACCTNO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtADDRESS
        '
        Me.txtADDRESS.Location = New System.Drawing.Point(333, 195)
        Me.txtADDRESS.MaxLength = 250
        Me.txtADDRESS.Multiline = True
        Me.txtADDRESS.Name = "txtADDRESS"
        Me.txtADDRESS.Size = New System.Drawing.Size(321, 21)
        Me.txtADDRESS.TabIndex = 38
        Me.txtADDRESS.Tag = "ADDRESS"
        Me.txtADDRESS.Text = "txtADDRESS"
        '
        'btnGenCustodyCD
        '
        Me.btnGenCustodyCD.Location = New System.Drawing.Point(216, 17)
        Me.btnGenCustodyCD.Name = "btnGenCustodyCD"
        Me.btnGenCustodyCD.Size = New System.Drawing.Size(24, 21)
        Me.btnGenCustodyCD.TabIndex = 1
        Me.btnGenCustodyCD.Tag = "btnGenCustodycdtNo"
        Me.btnGenCustodyCD.Text = "..."
        '
        'lblCUSTODYCD
        '
        Me.lblCUSTODYCD.AutoSize = True
        Me.lblCUSTODYCD.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblCUSTODYCD.Location = New System.Drawing.Point(6, 21)
        Me.lblCUSTODYCD.Name = "lblCUSTODYCD"
        Me.lblCUSTODYCD.Size = New System.Drawing.Size(78, 13)
        Me.lblCUSTODYCD.TabIndex = 4
        Me.lblCUSTODYCD.Tag = "CUSTODYCD"
        Me.lblCUSTODYCD.Text = "lblCUSTODYCD"
        Me.lblCUSTODYCD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCUSTODYCD
        '
        Me.txtCUSTODYCD.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCUSTODYCD.Location = New System.Drawing.Point(106, 17)
        Me.txtCUSTODYCD.Mask = "CCC>C.CCCCCC"
        Me.txtCUSTODYCD.Name = "txtCUSTODYCD"
        Me.txtCUSTODYCD.Size = New System.Drawing.Size(104, 21)
        Me.txtCUSTODYCD.TabIndex = 0
        Me.txtCUSTODYCD.Tag = "txtCUSTODYCD"
        '
        'lblCUSTNAME
        '
        Me.lblCUSTNAME.BackColor = System.Drawing.Color.LightYellow
        Me.lblCUSTNAME.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCUSTNAME.Location = New System.Drawing.Point(250, 16)
        Me.lblCUSTNAME.Name = "lblCUSTNAME"
        Me.lblCUSTNAME.Size = New System.Drawing.Size(226, 23)
        Me.lblCUSTNAME.TabIndex = 1
        Me.lblCUSTNAME.Tag = "lblCUSTNAME"
        Me.lblCUSTNAME.Text = "lblCUSTNAME"
        Me.lblCUSTNAME.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboISOTC
        '
        Me.cboISOTC.DisplayMember = "DISPLAY"
        Me.cboISOTC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboISOTC.Location = New System.Drawing.Point(602, 46)
        Me.cboISOTC.Name = "cboISOTC"
        Me.cboISOTC.Size = New System.Drawing.Size(51, 21)
        Me.cboISOTC.TabIndex = 10
        Me.cboISOTC.Tag = "ISOTC"
        Me.cboISOTC.ValueMember = "VALUE"
        '
        'lblISOTC
        '
        Me.lblISOTC.Location = New System.Drawing.Point(552, 49)
        Me.lblISOTC.Name = "lblISOTC"
        Me.lblISOTC.Size = New System.Drawing.Size(71, 18)
        Me.lblISOTC.TabIndex = 9
        Me.lblISOTC.Tag = "ISOTC"
        Me.lblISOTC.Text = "lblISOTC"
        '
        'cboAFTYPE
        '
        Me.cboAFTYPE.DisplayMember = "DISPLAY"
        Me.cboAFTYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAFTYPE.Enabled = False
        Me.cboAFTYPE.Location = New System.Drawing.Point(106, 76)
        Me.cboAFTYPE.Name = "cboAFTYPE"
        Me.cboAFTYPE.Size = New System.Drawing.Size(108, 21)
        Me.cboAFTYPE.TabIndex = 12
        Me.cboAFTYPE.Tag = "AFTYPE"
        Me.cboAFTYPE.ValueMember = "VALUE"
        '
        'txtCUSTID
        '
        Me.txtCUSTID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCUSTID.Location = New System.Drawing.Point(106, 46)
        Me.txtCUSTID.Name = "txtCUSTID"
        Me.txtCUSTID.Size = New System.Drawing.Size(104, 21)
        Me.txtCUSTID.TabIndex = 1
        Me.txtCUSTID.Tag = "CUSTID"
        Me.txtCUSTID.Text = "txtCUSTID"
        '
        'lblCUSTID
        '
        Me.lblCUSTID.AutoSize = True
        Me.lblCUSTID.Location = New System.Drawing.Point(6, 46)
        Me.lblCUSTID.Name = "lblCUSTID"
        Me.lblCUSTID.Size = New System.Drawing.Size(54, 13)
        Me.lblCUSTID.TabIndex = 0
        Me.lblCUSTID.Tag = "CUSTID"
        Me.lblCUSTID.Text = "lblCUSTID"
        Me.lblCUSTID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCONSULTANT
        '
        Me.cboCONSULTANT.DisplayMember = "DISPLAY"
        Me.cboCONSULTANT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCONSULTANT.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCONSULTANT.ItemHeight = 13
        Me.cboCONSULTANT.Location = New System.Drawing.Point(333, 48)
        Me.cboCONSULTANT.Name = "cboCONSULTANT"
        Me.cboCONSULTANT.Size = New System.Drawing.Size(58, 21)
        Me.cboCONSULTANT.TabIndex = 8
        Me.cboCONSULTANT.Tag = "CONSULTANT"
        Me.cboCONSULTANT.ValueMember = "VALUE"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(247, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Tag = "CONSULTANT"
        Me.Label1.Text = "lblCONSULTANT"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCFONLINELIMIT
        '
        Me.txtCFONLINELIMIT.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCFONLINELIMIT.Location = New System.Drawing.Point(333, 106)
        Me.txtCFONLINELIMIT.Name = "txtCFONLINELIMIT"
        Me.txtCFONLINELIMIT.Size = New System.Drawing.Size(91, 21)
        Me.txtCFONLINELIMIT.TabIndex = 20
        Me.txtCFONLINELIMIT.Tag = "CFONLINELIMIT"
        Me.txtCFONLINELIMIT.Text = "txtCFONLINELIMIT"
        '
        'lblCFONLINELIMIT
        '
        Me.lblCFONLINELIMIT.AutoSize = True
        Me.lblCFONLINELIMIT.Location = New System.Drawing.Point(214, 104)
        Me.lblCFONLINELIMIT.Name = "lblCFONLINELIMIT"
        Me.lblCFONLINELIMIT.Size = New System.Drawing.Size(94, 13)
        Me.lblCFONLINELIMIT.TabIndex = 19
        Me.lblCFONLINELIMIT.Tag = "CFONLINELIMIT"
        Me.lblCFONLINELIMIT.Text = "lblCFONLINELIMIT"
        Me.lblCFONLINELIMIT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCFTELELIMIT
        '
        Me.txtCFTELELIMIT.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCFTELELIMIT.Location = New System.Drawing.Point(106, 106)
        Me.txtCFTELELIMIT.Name = "txtCFTELELIMIT"
        Me.txtCFTELELIMIT.Size = New System.Drawing.Size(104, 21)
        Me.txtCFTELELIMIT.TabIndex = 18
        Me.txtCFTELELIMIT.Tag = "CFTELELIMIT"
        Me.txtCFTELELIMIT.Text = "txtCFTELELIMIT"
        '
        'lblCFTELELIMIT
        '
        Me.lblCFTELELIMIT.AutoSize = True
        Me.lblCFTELELIMIT.Location = New System.Drawing.Point(6, 106)
        Me.lblCFTELELIMIT.Name = "lblCFTELELIMIT"
        Me.lblCFTELELIMIT.Size = New System.Drawing.Size(80, 13)
        Me.lblCFTELELIMIT.TabIndex = 17
        Me.lblCFTELELIMIT.Tag = "CFTELELIMIT"
        Me.lblCFTELELIMIT.Text = "lblCFTELELIMIT"
        Me.lblCFTELELIMIT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboTRADEONLINE
        '
        Me.cboTRADEONLINE.DisplayMember = "DISPLAY"
        Me.cboTRADEONLINE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTRADEONLINE.Location = New System.Drawing.Point(333, 136)
        Me.cboTRADEONLINE.Name = "cboTRADEONLINE"
        Me.cboTRADEONLINE.Size = New System.Drawing.Size(91, 21)
        Me.cboTRADEONLINE.TabIndex = 26
        Me.cboTRADEONLINE.Tag = "TRADEONLINE"
        Me.cboTRADEONLINE.ValueMember = "VALUE"
        '
        'lblTRADEONLINE
        '
        Me.lblTRADEONLINE.AutoSize = True
        Me.lblTRADEONLINE.Location = New System.Drawing.Point(214, 136)
        Me.lblTRADEONLINE.Name = "lblTRADEONLINE"
        Me.lblTRADEONLINE.Size = New System.Drawing.Size(87, 13)
        Me.lblTRADEONLINE.TabIndex = 25
        Me.lblTRADEONLINE.Tag = "TRADEONLINE"
        Me.lblTRADEONLINE.Text = "lblTRADEONLINE"
        Me.lblTRADEONLINE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboTRADEFLOOR
        '
        Me.cboTRADEFLOOR.DisplayMember = "DISPLAY"
        Me.cboTRADEFLOOR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTRADEFLOOR.Location = New System.Drawing.Point(106, 136)
        Me.cboTRADEFLOOR.Name = "cboTRADEFLOOR"
        Me.cboTRADEFLOOR.Size = New System.Drawing.Size(104, 21)
        Me.cboTRADEFLOOR.TabIndex = 24
        Me.cboTRADEFLOOR.Tag = "TRADEFLOOR"
        Me.cboTRADEFLOOR.ValueMember = "VALUE"
        '
        'lblTRADEFLOOR
        '
        Me.lblTRADEFLOOR.AutoSize = True
        Me.lblTRADEFLOOR.Location = New System.Drawing.Point(6, 136)
        Me.lblTRADEFLOOR.Name = "lblTRADEFLOOR"
        Me.lblTRADEFLOOR.Size = New System.Drawing.Size(84, 13)
        Me.lblTRADEFLOOR.TabIndex = 23
        Me.lblTRADEFLOOR.Tag = "TRADEFLOOR"
        Me.lblTRADEFLOOR.Text = "lblTRADEFLOOR"
        Me.lblTRADEFLOOR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboTRADETELEPHONE
        '
        Me.cboTRADETELEPHONE.DisplayMember = "DISPLAY"
        Me.cboTRADETELEPHONE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTRADETELEPHONE.Location = New System.Drawing.Point(106, 165)
        Me.cboTRADETELEPHONE.Name = "cboTRADETELEPHONE"
        Me.cboTRADETELEPHONE.Size = New System.Drawing.Size(105, 21)
        Me.cboTRADETELEPHONE.TabIndex = 30
        Me.cboTRADETELEPHONE.Tag = "TRADETELEPHONE"
        Me.cboTRADETELEPHONE.ValueMember = "VALUE"
        '
        'lblTRADETELEPHONE
        '
        Me.lblTRADETELEPHONE.AutoSize = True
        Me.lblTRADETELEPHONE.Location = New System.Drawing.Point(6, 165)
        Me.lblTRADETELEPHONE.Name = "lblTRADETELEPHONE"
        Me.lblTRADETELEPHONE.Size = New System.Drawing.Size(107, 13)
        Me.lblTRADETELEPHONE.TabIndex = 29
        Me.lblTRADETELEPHONE.Tag = "TRADETELEPHONE"
        Me.lblTRADETELEPHONE.Text = "lblTRADETELEPHONE"
        Me.lblTRADETELEPHONE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTRADEPHONE
        '
        Me.txtTRADEPHONE.Location = New System.Drawing.Point(333, 166)
        Me.txtTRADEPHONE.MaxLength = 20
        Me.txtTRADEPHONE.Name = "txtTRADEPHONE"
        Me.txtTRADEPHONE.Size = New System.Drawing.Size(93, 21)
        Me.txtTRADEPHONE.TabIndex = 32
        Me.txtTRADEPHONE.Tag = "TRADEPHONE"
        Me.txtTRADEPHONE.Text = "txtTRADEPHONE"
        '
        'lblTRADEPHONE
        '
        Me.lblTRADEPHONE.AutoSize = True
        Me.lblTRADEPHONE.Location = New System.Drawing.Point(214, 166)
        Me.lblTRADEPHONE.Name = "lblTRADEPHONE"
        Me.lblTRADEPHONE.Size = New System.Drawing.Size(84, 13)
        Me.lblTRADEPHONE.TabIndex = 31
        Me.lblTRADEPHONE.Tag = "TRADEPHONE"
        Me.lblTRADEPHONE.Text = "lblTRADEPHONE"
        Me.lblTRADEPHONE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPHONE1
        '
        Me.txtPHONE1.Location = New System.Drawing.Point(545, 166)
        Me.txtPHONE1.MaxLength = 20
        Me.txtPHONE1.Name = "txtPHONE1"
        Me.txtPHONE1.Size = New System.Drawing.Size(108, 21)
        Me.txtPHONE1.TabIndex = 34
        Me.txtPHONE1.Tag = "PHONE1"
        Me.txtPHONE1.Text = "txtPHONE1"
        '
        'lblPHONE1
        '
        Me.lblPHONE1.AutoSize = True
        Me.lblPHONE1.Location = New System.Drawing.Point(450, 166)
        Me.lblPHONE1.Name = "lblPHONE1"
        Me.lblPHONE1.Size = New System.Drawing.Size(57, 13)
        Me.lblPHONE1.TabIndex = 33
        Me.lblPHONE1.Tag = "PHONE1"
        Me.lblPHONE1.Text = "lblPHONE1"
        Me.lblPHONE1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFAX
        '
        Me.lblFAX.AutoSize = True
        Me.lblFAX.Location = New System.Drawing.Point(6, 196)
        Me.lblFAX.Name = "lblFAX"
        Me.lblFAX.Size = New System.Drawing.Size(36, 13)
        Me.lblFAX.TabIndex = 35
        Me.lblFAX.Tag = "FAX"
        Me.lblFAX.Text = "lblFAX"
        Me.lblFAX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFAX
        '
        Me.txtFAX.Location = New System.Drawing.Point(106, 196)
        Me.txtFAX.MaxLength = 20
        Me.txtFAX.Name = "txtFAX"
        Me.txtFAX.Size = New System.Drawing.Size(104, 21)
        Me.txtFAX.TabIndex = 36
        Me.txtFAX.Tag = "FAX"
        Me.txtFAX.Text = "txtFAX"
        '
        'lblFAX1
        '
        Me.lblFAX1.AutoSize = True
        Me.lblFAX1.BackColor = System.Drawing.Color.Transparent
        Me.lblFAX1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.lblFAX1.Location = New System.Drawing.Point(6, 225)
        Me.lblFAX1.Name = "lblFAX1"
        Me.lblFAX1.Size = New System.Drawing.Size(42, 13)
        Me.lblFAX1.TabIndex = 39
        Me.lblFAX1.Tag = "FAX1"
        Me.lblFAX1.Text = "lblFAX1"
        Me.lblFAX1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFAX1
        '
        Me.txtFAX1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.txtFAX1.Location = New System.Drawing.Point(106, 225)
        Me.txtFAX1.MaxLength = 20
        Me.txtFAX1.Name = "txtFAX1"
        Me.txtFAX1.Size = New System.Drawing.Size(104, 21)
        Me.txtFAX1.TabIndex = 40
        Me.txtFAX1.Tag = "FAX1"
        Me.txtFAX1.Text = "txtFAX1"
        '
        'txtEMAIL
        '
        Me.txtEMAIL.Location = New System.Drawing.Point(333, 225)
        Me.txtEMAIL.MaxLength = 100
        Me.txtEMAIL.Name = "txtEMAIL"
        Me.txtEMAIL.Size = New System.Drawing.Size(321, 21)
        Me.txtEMAIL.TabIndex = 42
        Me.txtEMAIL.Tag = "EMAIL"
        Me.txtEMAIL.Text = "txtEMAIL"
        '
        'lblEMAIL
        '
        Me.lblEMAIL.AutoSize = True
        Me.lblEMAIL.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblEMAIL.Location = New System.Drawing.Point(214, 225)
        Me.lblEMAIL.Name = "lblEMAIL"
        Me.lblEMAIL.Size = New System.Drawing.Size(47, 13)
        Me.lblEMAIL.TabIndex = 41
        Me.lblEMAIL.Tag = "EMAIL"
        Me.lblEMAIL.Text = "lblEMAIL"
        Me.lblEMAIL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblADDRESS
        '
        Me.lblADDRESS.AutoSize = True
        Me.lblADDRESS.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblADDRESS.Location = New System.Drawing.Point(214, 195)
        Me.lblADDRESS.Name = "lblADDRESS"
        Me.lblADDRESS.Size = New System.Drawing.Size(63, 13)
        Me.lblADDRESS.TabIndex = 37
        Me.lblADDRESS.Tag = "ADDRESS"
        Me.lblADDRESS.Text = "lblADDRESS"
        Me.lblADDRESS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPIN
        '
        Me.txtPIN.Location = New System.Drawing.Point(255, 561)
        Me.txtPIN.MaxLength = 50
        Me.txtPIN.Name = "txtPIN"
        Me.txtPIN.Size = New System.Drawing.Size(105, 21)
        Me.txtPIN.TabIndex = 7
        Me.txtPIN.Tag = String.Empty
        Me.txtPIN.Text = "txtPIN"
        '
        'lblPIN
        '
        Me.lblPIN.AutoSize = True
        Me.lblPIN.Location = New System.Drawing.Point(10, 556)
        Me.lblPIN.Name = "lblPIN"
        Me.lblPIN.Size = New System.Drawing.Size(34, 13)
        Me.lblPIN.TabIndex = 6
        Me.lblPIN.Tag = "PIN"
        Me.lblPIN.Text = "lblPIN"
        Me.lblPIN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnGenContractNo
        '
        Me.btnGenContractNo.Location = New System.Drawing.Point(218, 55)
        Me.btnGenContractNo.Name = "btnGenContractNo"
        Me.btnGenContractNo.Size = New System.Drawing.Size(24, 21)
        Me.btnGenContractNo.TabIndex = 3
        Me.btnGenContractNo.Tag = "btnGenContractNo"
        Me.btnGenContractNo.Text = "..."
        '
        'tabAFMAST
        '
        Me.tabAFMAST.Controls.Add(Me.tabMainInfo)
        Me.tabAFMAST.Controls.Add(Me.tabSevice)
        Me.tabAFMAST.Controls.Add(Me.tabContractMember)
        Me.tabAFMAST.Controls.Add(Me.tabACCOUNT)
        Me.tabAFMAST.Controls.Add(Me.tabEXTREFER)
        Me.tabAFMAST.Controls.Add(Me.tabAnthorize)
        Me.tabAFMAST.Controls.Add(Me.tabICCF)
        Me.tabAFMAST.Controls.Add(Me.tabTxmap)
        Me.tabAFMAST.Controls.Add(Me.tabAFSERULE)
        Me.tabAFMAST.Controls.Add(Me.tabOTRIGHT)
        Me.tabAFMAST.Controls.Add(Me.tabTemplates)
        Me.tabAFMAST.Controls.Add(Me.tabReport)
        Me.tabAFMAST.Location = New System.Drawing.Point(8, 82)
        Me.tabAFMAST.Name = "tabAFMAST"
        Me.tabAFMAST.SelectedIndex = 0
        Me.tabAFMAST.Size = New System.Drawing.Size(675, 468)
        Me.tabAFMAST.TabIndex = 5
        Me.tabAFMAST.Tag = "EXTREFER"
        '
        'tabMainInfo
        '
        Me.tabMainInfo.Controls.Add(Me.grbMainInfo)
        Me.tabMainInfo.Location = New System.Drawing.Point(4, 22)
        Me.tabMainInfo.Name = "tabMainInfo"
        Me.tabMainInfo.Size = New System.Drawing.Size(667, 442)
        Me.tabMainInfo.TabIndex = 0
        Me.tabMainInfo.Tag = "tabMainInfo"
        Me.tabMainInfo.Text = "tabMainInfo"
        Me.tabMainInfo.UseVisualStyleBackColor = True
        '
        'tabSevice
        '
        Me.tabSevice.Controls.Add(Me.grbLimit)
        Me.tabSevice.Location = New System.Drawing.Point(4, 22)
        Me.tabSevice.Name = "tabSevice"
        Me.tabSevice.Size = New System.Drawing.Size(667, 442)
        Me.tabSevice.TabIndex = 2
        Me.tabSevice.Tag = "tabSevice"
        Me.tabSevice.Text = "tabSevice"
        Me.tabSevice.UseVisualStyleBackColor = True
        '
        'grbLimit
        '
        Me.grbLimit.BackColor = System.Drawing.SystemColors.Control
        Me.grbLimit.Controls.Add(Me.grbMRService)
        Me.grbLimit.Controls.Add(Me.txtFEEBASE)
        Me.grbLimit.Controls.Add(Me.lblFEEBASE)
        Me.grbLimit.Controls.Add(Me.txtONLINELIMIT)
        Me.grbLimit.Controls.Add(Me.lblONLINELIMIT)
        Me.grbLimit.Controls.Add(Me.txtTELELIMIT)
        Me.grbLimit.Controls.Add(Me.lblTELELIMIT)
        Me.grbLimit.Controls.Add(Me.txtMISCRATE)
        Me.grbLimit.Controls.Add(Me.lblMISCRATE)
        Me.grbLimit.Controls.Add(Me.txtDEPORATE)
        Me.grbLimit.Controls.Add(Me.lblDEPORATE)
        Me.grbLimit.Controls.Add(Me.txtTRADERATE)
        Me.grbLimit.Controls.Add(Me.lblTRADERATE)
        Me.grbLimit.Controls.Add(Me.txtDEPOSITLINE)
        Me.grbLimit.Controls.Add(Me.lblBRATIO)
        Me.grbLimit.Controls.Add(Me.lblDEPOSITLINE)
        Me.grbLimit.Controls.Add(Me.lblREPOLINE)
        Me.grbLimit.Controls.Add(Me.lblADVANCELINE)
        Me.grbLimit.Controls.Add(Me.lblTRADELINE)
        Me.grbLimit.Controls.Add(Me.txtBRATIO)
        Me.grbLimit.Controls.Add(Me.txtREPOLINE)
        Me.grbLimit.Controls.Add(Me.txtADVANCELINE)
        Me.grbLimit.Controls.Add(Me.txtTRADELINE)
        Me.grbLimit.Controls.Add(Me.txtMARGINLINE)
        Me.grbLimit.Controls.Add(Me.lblMARGINLINE)
        Me.grbLimit.Location = New System.Drawing.Point(8, 6)
        Me.grbLimit.Name = "grbLimit"
        Me.grbLimit.Size = New System.Drawing.Size(648, 383)
        Me.grbLimit.TabIndex = 1
        Me.grbLimit.TabStop = False
        Me.grbLimit.Tag = "grbLimit"
        Me.grbLimit.Text = "grbLimit"
        '
        'grbMRService
        '
        Me.grbMRService.Controls.Add(Me.lblMRIRATIO)
        Me.grbMRService.Controls.Add(Me.lblMRCRLIMITMAX)
        Me.grbMRService.Controls.Add(Me.txtMRIRATIO)
        Me.grbMRService.Controls.Add(Me.txtMRCRLIMITMAX)
        Me.grbMRService.Controls.Add(Me.txtMRMRATIO)
        Me.grbMRService.Controls.Add(Me.lblMRMRATIO)
        Me.grbMRService.Controls.Add(Me.txtMRLRATIO)
        Me.grbMRService.Controls.Add(Me.lblMRLRATIO)
        Me.grbMRService.Controls.Add(Me.txtMRCRLIMIT)
        Me.grbMRService.Controls.Add(Me.lblMRCRLIMIT)
        Me.grbMRService.Controls.Add(Me.lblMRCLAMT)
        Me.grbMRService.Controls.Add(Me.txtMRCLAMT)
        Me.grbMRService.Controls.Add(Me.txtMRLRATE)
        Me.grbMRService.Controls.Add(Me.lblMRLRATE)
        Me.grbMRService.Controls.Add(Me.lblMRMRATE)
        Me.grbMRService.Controls.Add(Me.txtMRMRATE)
        Me.grbMRService.Controls.Add(Me.txtMRIRATE)
        Me.grbMRService.Controls.Add(Me.lblMRIRATE)
        Me.grbMRService.Controls.Add(Me.Label11)
        Me.grbMRService.Location = New System.Drawing.Point(8, 206)
        Me.grbMRService.Name = "grbMRService"
        Me.grbMRService.Size = New System.Drawing.Size(632, 169)
        Me.grbMRService.TabIndex = 73
        Me.grbMRService.TabStop = False
        Me.grbMRService.Tag = "MRService"
        Me.grbMRService.Text = "grbMRService"
        '
        'lblMRIRATIO
        '
        Me.lblMRIRATIO.Location = New System.Drawing.Point(320, 109)
        Me.lblMRIRATIO.Name = "lblMRIRATIO"
        Me.lblMRIRATIO.Size = New System.Drawing.Size(112, 21)
        Me.lblMRIRATIO.TabIndex = 67
        Me.lblMRIRATIO.Tag = "MRIRATIO"
        Me.lblMRIRATIO.Text = "lblMRIRATIO"
        Me.lblMRIRATIO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMRCRLIMITMAX
        '
        Me.lblMRCRLIMITMAX.Location = New System.Drawing.Point(320, 81)
        Me.lblMRCRLIMITMAX.Name = "lblMRCRLIMITMAX"
        Me.lblMRCRLIMITMAX.Size = New System.Drawing.Size(112, 21)
        Me.lblMRCRLIMITMAX.TabIndex = 67
        Me.lblMRCRLIMITMAX.Tag = "MRCRLIMITMAX"
        Me.lblMRCRLIMITMAX.Text = "lblMRCRLIMITMAX"
        Me.lblMRCRLIMITMAX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMRIRATIO
        '
        Me.txtMRIRATIO.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMRIRATIO.Location = New System.Drawing.Point(440, 109)
        Me.txtMRIRATIO.Name = "txtMRIRATIO"
        Me.txtMRIRATIO.Size = New System.Drawing.Size(184, 21)
        Me.txtMRIRATIO.TabIndex = 65
        Me.txtMRIRATIO.Tag = "MRIRATIO"
        Me.txtMRIRATIO.Text = "txtMRIRATIO"
        '
        'txtMRCRLIMITMAX
        '
        Me.txtMRCRLIMITMAX.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMRCRLIMITMAX.Location = New System.Drawing.Point(440, 81)
        Me.txtMRCRLIMITMAX.Name = "txtMRCRLIMITMAX"
        Me.txtMRCRLIMITMAX.Size = New System.Drawing.Size(184, 21)
        Me.txtMRCRLIMITMAX.TabIndex = 65
        Me.txtMRCRLIMITMAX.Tag = "MRCRLIMITMAX"
        Me.txtMRCRLIMITMAX.Text = "txtMRCRLIMITMAX"
        '
        'txtMRMRATIO
        '
        Me.txtMRMRATIO.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMRMRATIO.Location = New System.Drawing.Point(128, 138)
        Me.txtMRMRATIO.Name = "txtMRMRATIO"
        Me.txtMRMRATIO.Size = New System.Drawing.Size(184, 21)
        Me.txtMRMRATIO.TabIndex = 64
        Me.txtMRMRATIO.Tag = "MRMRATIO"
        Me.txtMRMRATIO.Text = "txtMRMRATIO"
        '
        'lblMRMRATIO
        '
        Me.lblMRMRATIO.Location = New System.Drawing.Point(8, 138)
        Me.lblMRMRATIO.Name = "lblMRMRATIO"
        Me.lblMRMRATIO.Size = New System.Drawing.Size(112, 21)
        Me.lblMRMRATIO.TabIndex = 66
        Me.lblMRMRATIO.Tag = "MRMRATIO"
        Me.lblMRMRATIO.Text = "lblMRMRATIO"
        Me.lblMRMRATIO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMRLRATIO
        '
        Me.txtMRLRATIO.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMRLRATIO.Location = New System.Drawing.Point(128, 108)
        Me.txtMRLRATIO.Name = "txtMRLRATIO"
        Me.txtMRLRATIO.Size = New System.Drawing.Size(184, 21)
        Me.txtMRLRATIO.TabIndex = 64
        Me.txtMRLRATIO.Tag = "MRLRATIO"
        Me.txtMRLRATIO.Text = "txtMRLRATIO"
        '
        'lblMRLRATIO
        '
        Me.lblMRLRATIO.Location = New System.Drawing.Point(8, 108)
        Me.lblMRLRATIO.Name = "lblMRLRATIO"
        Me.lblMRLRATIO.Size = New System.Drawing.Size(112, 21)
        Me.lblMRLRATIO.TabIndex = 66
        Me.lblMRLRATIO.Tag = "MRLRATIO"
        Me.lblMRLRATIO.Text = "lblMRLRATIO"
        Me.lblMRLRATIO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMRCRLIMIT
        '
        Me.txtMRCRLIMIT.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMRCRLIMIT.Location = New System.Drawing.Point(128, 81)
        Me.txtMRCRLIMIT.Name = "txtMRCRLIMIT"
        Me.txtMRCRLIMIT.Size = New System.Drawing.Size(184, 21)
        Me.txtMRCRLIMIT.TabIndex = 64
        Me.txtMRCRLIMIT.Tag = "MRCRLIMIT"
        Me.txtMRCRLIMIT.Text = "txtMRCRLIMIT"
        '
        'lblMRCRLIMIT
        '
        Me.lblMRCRLIMIT.Location = New System.Drawing.Point(8, 81)
        Me.lblMRCRLIMIT.Name = "lblMRCRLIMIT"
        Me.lblMRCRLIMIT.Size = New System.Drawing.Size(112, 21)
        Me.lblMRCRLIMIT.TabIndex = 66
        Me.lblMRCRLIMIT.Tag = "MRCRLIMIT"
        Me.lblMRCRLIMIT.Text = "lblMRCRLIMIT"
        Me.lblMRCRLIMIT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMRCLAMT
        '
        Me.lblMRCLAMT.Location = New System.Drawing.Point(320, 50)
        Me.lblMRCLAMT.Name = "lblMRCLAMT"
        Me.lblMRCLAMT.Size = New System.Drawing.Size(112, 21)
        Me.lblMRCLAMT.TabIndex = 63
        Me.lblMRCLAMT.Tag = "MRCLAMT"
        Me.lblMRCLAMT.Text = "lblMRCLAMT"
        Me.lblMRCLAMT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMRCLAMT
        '
        Me.txtMRCLAMT.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMRCLAMT.Location = New System.Drawing.Point(440, 50)
        Me.txtMRCLAMT.Name = "txtMRCLAMT"
        Me.txtMRCLAMT.Size = New System.Drawing.Size(184, 21)
        Me.txtMRCLAMT.TabIndex = 61
        Me.txtMRCLAMT.Tag = "MRCLAMT"
        Me.txtMRCLAMT.Text = "txtMRCLAMT"
        '
        'txtMRLRATE
        '
        Me.txtMRLRATE.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMRLRATE.Location = New System.Drawing.Point(128, 50)
        Me.txtMRLRATE.Name = "txtMRLRATE"
        Me.txtMRLRATE.Size = New System.Drawing.Size(184, 21)
        Me.txtMRLRATE.TabIndex = 56
        Me.txtMRLRATE.Tag = "MRLRATE"
        Me.txtMRLRATE.Text = "txtMRLRATE"
        '
        'lblMRLRATE
        '
        Me.lblMRLRATE.Location = New System.Drawing.Point(8, 50)
        Me.lblMRLRATE.Name = "lblMRLRATE"
        Me.lblMRLRATE.Size = New System.Drawing.Size(112, 21)
        Me.lblMRLRATE.TabIndex = 58
        Me.lblMRLRATE.Tag = "MRLRATE"
        Me.lblMRLRATE.Text = "lblMRLRATE"
        Me.lblMRLRATE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMRMRATE
        '
        Me.lblMRMRATE.Location = New System.Drawing.Point(320, 19)
        Me.lblMRMRATE.Name = "lblMRMRATE"
        Me.lblMRMRATE.Size = New System.Drawing.Size(112, 21)
        Me.lblMRMRATE.TabIndex = 55
        Me.lblMRMRATE.Tag = "MRMRATE"
        Me.lblMRMRATE.Text = "lblMRMRATE"
        Me.lblMRMRATE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMRMRATE
        '
        Me.txtMRMRATE.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMRMRATE.Location = New System.Drawing.Point(440, 19)
        Me.txtMRMRATE.Name = "txtMRMRATE"
        Me.txtMRMRATE.Size = New System.Drawing.Size(184, 21)
        Me.txtMRMRATE.TabIndex = 53
        Me.txtMRMRATE.Tag = "MRMRATE"
        Me.txtMRMRATE.Text = "txtMRMRATE"
        '
        'txtMRIRATE
        '
        Me.txtMRIRATE.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMRIRATE.Location = New System.Drawing.Point(128, 19)
        Me.txtMRIRATE.Name = "txtMRIRATE"
        Me.txtMRIRATE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMRIRATE.Size = New System.Drawing.Size(184, 21)
        Me.txtMRIRATE.TabIndex = 52
        Me.txtMRIRATE.Tag = "MRIRATE"
        Me.txtMRIRATE.Text = "txtMRIRATE"
        '
        'lblMRIRATE
        '
        Me.lblMRIRATE.Location = New System.Drawing.Point(8, 19)
        Me.lblMRIRATE.Name = "lblMRIRATE"
        Me.lblMRIRATE.Size = New System.Drawing.Size(112, 21)
        Me.lblMRIRATE.TabIndex = 54
        Me.lblMRIRATE.Tag = "MRIRATE"
        Me.lblMRIRATE.Text = "lblMRIRATE"
        Me.lblMRIRATE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(8, 20)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(112, 21)
        Me.Label11.TabIndex = 54
        Me.Label11.Tag = "MARGINLINE"
        Me.Label11.Text = "Label4"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFEEBASE
        '
        Me.txtFEEBASE.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFEEBASE.Location = New System.Drawing.Point(494, 184)
        Me.txtFEEBASE.Name = "txtFEEBASE"
        Me.txtFEEBASE.Size = New System.Drawing.Size(138, 21)
        Me.txtFEEBASE.TabIndex = 71
        Me.txtFEEBASE.Tag = "FEEBASE"
        Me.txtFEEBASE.Text = "txtFEEBASE"
        '
        'lblFEEBASE
        '
        Me.lblFEEBASE.Location = New System.Drawing.Point(330, 184)
        Me.lblFEEBASE.Name = "lblFEEBASE"
        Me.lblFEEBASE.Size = New System.Drawing.Size(140, 21)
        Me.lblFEEBASE.TabIndex = 72
        Me.lblFEEBASE.Tag = "FEEBASE"
        Me.lblFEEBASE.Text = "lblFEEBASE"
        Me.lblFEEBASE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtONLINELIMIT
        '
        Me.txtONLINELIMIT.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtONLINELIMIT.Location = New System.Drawing.Point(136, 120)
        Me.txtONLINELIMIT.Name = "txtONLINELIMIT"
        Me.txtONLINELIMIT.Size = New System.Drawing.Size(130, 21)
        Me.txtONLINELIMIT.TabIndex = 10
        Me.txtONLINELIMIT.Tag = "ONLINELIMIT"
        Me.txtONLINELIMIT.Text = "txtONLINELIMIT"
        '
        'lblONLINELIMIT
        '
        Me.lblONLINELIMIT.Location = New System.Drawing.Point(8, 120)
        Me.lblONLINELIMIT.Name = "lblONLINELIMIT"
        Me.lblONLINELIMIT.Size = New System.Drawing.Size(126, 21)
        Me.lblONLINELIMIT.TabIndex = 70
        Me.lblONLINELIMIT.Tag = "ONLINELIMIT"
        Me.lblONLINELIMIT.Text = "lblONLINELIMIT"
        Me.lblONLINELIMIT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTELELIMIT
        '
        Me.txtTELELIMIT.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtTELELIMIT.Location = New System.Drawing.Point(494, 88)
        Me.txtTELELIMIT.Name = "txtTELELIMIT"
        Me.txtTELELIMIT.Size = New System.Drawing.Size(138, 21)
        Me.txtTELELIMIT.TabIndex = 9
        Me.txtTELELIMIT.Tag = "TELELIMIT"
        Me.txtTELELIMIT.Text = "txtTELELIMIT"
        '
        'lblTELELIMIT
        '
        Me.lblTELELIMIT.Location = New System.Drawing.Point(330, 88)
        Me.lblTELELIMIT.Name = "lblTELELIMIT"
        Me.lblTELELIMIT.Size = New System.Drawing.Size(140, 21)
        Me.lblTELELIMIT.TabIndex = 68
        Me.lblTELELIMIT.Tag = "TELELIMIT"
        Me.lblTELELIMIT.Text = "lblTELELIMIT"
        Me.lblTELELIMIT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMISCRATE
        '
        Me.txtMISCRATE.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMISCRATE.Location = New System.Drawing.Point(494, 152)
        Me.txtMISCRATE.Name = "txtMISCRATE"
        Me.txtMISCRATE.Size = New System.Drawing.Size(138, 21)
        Me.txtMISCRATE.TabIndex = 8
        Me.txtMISCRATE.Tag = "MISCRATE"
        Me.txtMISCRATE.Text = "txtMISCRATE"
        '
        'lblMISCRATE
        '
        Me.lblMISCRATE.Location = New System.Drawing.Point(330, 152)
        Me.lblMISCRATE.Name = "lblMISCRATE"
        Me.lblMISCRATE.Size = New System.Drawing.Size(140, 21)
        Me.lblMISCRATE.TabIndex = 66
        Me.lblMISCRATE.Tag = "MISCRATE"
        Me.lblMISCRATE.Text = "lblMISCRATE"
        Me.lblMISCRATE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDEPORATE
        '
        Me.txtDEPORATE.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDEPORATE.Location = New System.Drawing.Point(136, 152)
        Me.txtDEPORATE.Name = "txtDEPORATE"
        Me.txtDEPORATE.Size = New System.Drawing.Size(130, 21)
        Me.txtDEPORATE.TabIndex = 7
        Me.txtDEPORATE.Tag = "DEPORATE"
        Me.txtDEPORATE.Text = "txtDEPORATE"
        '
        'lblDEPORATE
        '
        Me.lblDEPORATE.Location = New System.Drawing.Point(8, 152)
        Me.lblDEPORATE.Name = "lblDEPORATE"
        Me.lblDEPORATE.Size = New System.Drawing.Size(126, 21)
        Me.lblDEPORATE.TabIndex = 64
        Me.lblDEPORATE.Tag = "DEPORATE"
        Me.lblDEPORATE.Text = "lblDEPORATE"
        Me.lblDEPORATE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTRADERATE
        '
        Me.txtTRADERATE.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtTRADERATE.Location = New System.Drawing.Point(136, 180)
        Me.txtTRADERATE.Name = "txtTRADERATE"
        Me.txtTRADERATE.Size = New System.Drawing.Size(130, 21)
        Me.txtTRADERATE.TabIndex = 6
        Me.txtTRADERATE.Tag = "TRADERATE"
        Me.txtTRADERATE.Text = "txtTRADERATE"
        '
        'lblTRADERATE
        '
        Me.lblTRADERATE.Location = New System.Drawing.Point(8, 180)
        Me.lblTRADERATE.Name = "lblTRADERATE"
        Me.lblTRADERATE.Size = New System.Drawing.Size(126, 21)
        Me.lblTRADERATE.TabIndex = 62
        Me.lblTRADERATE.Tag = "TRADERATE"
        Me.lblTRADERATE.Text = "lblTRADERATE"
        Me.lblTRADERATE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDEPOSITLINE
        '
        Me.txtDEPOSITLINE.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDEPOSITLINE.Location = New System.Drawing.Point(136, 88)
        Me.txtDEPOSITLINE.Name = "txtDEPOSITLINE"
        Me.txtDEPOSITLINE.Size = New System.Drawing.Size(130, 21)
        Me.txtDEPOSITLINE.TabIndex = 4
        Me.txtDEPOSITLINE.Tag = "DEPOSITLINE"
        Me.txtDEPOSITLINE.Text = "txtDEPOSITLINE"
        '
        'lblBRATIO
        '
        Me.lblBRATIO.Location = New System.Drawing.Point(330, 120)
        Me.lblBRATIO.Name = "lblBRATIO"
        Me.lblBRATIO.Size = New System.Drawing.Size(140, 21)
        Me.lblBRATIO.TabIndex = 55
        Me.lblBRATIO.Tag = "BRATIO"
        Me.lblBRATIO.Text = "lblBRATIO"
        Me.lblBRATIO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDEPOSITLINE
        '
        Me.lblDEPOSITLINE.Location = New System.Drawing.Point(8, 88)
        Me.lblDEPOSITLINE.Name = "lblDEPOSITLINE"
        Me.lblDEPOSITLINE.Size = New System.Drawing.Size(126, 21)
        Me.lblDEPOSITLINE.TabIndex = 54
        Me.lblDEPOSITLINE.Tag = "DEPOSITLINE"
        Me.lblDEPOSITLINE.Text = "lblDEPOSITLINE"
        Me.lblDEPOSITLINE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblREPOLINE
        '
        Me.lblREPOLINE.Location = New System.Drawing.Point(330, 56)
        Me.lblREPOLINE.Name = "lblREPOLINE"
        Me.lblREPOLINE.Size = New System.Drawing.Size(140, 21)
        Me.lblREPOLINE.TabIndex = 53
        Me.lblREPOLINE.Tag = "REPOLINE"
        Me.lblREPOLINE.Text = "lblREPOLINE"
        Me.lblREPOLINE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblADVANCELINE
        '
        Me.lblADVANCELINE.Location = New System.Drawing.Point(8, 56)
        Me.lblADVANCELINE.Name = "lblADVANCELINE"
        Me.lblADVANCELINE.Size = New System.Drawing.Size(126, 21)
        Me.lblADVANCELINE.TabIndex = 52
        Me.lblADVANCELINE.Tag = "ADVANCELINE"
        Me.lblADVANCELINE.Text = "lblADVANCELINE"
        Me.lblADVANCELINE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTRADELINE
        '
        Me.lblTRADELINE.Location = New System.Drawing.Point(330, 24)
        Me.lblTRADELINE.Name = "lblTRADELINE"
        Me.lblTRADELINE.Size = New System.Drawing.Size(140, 21)
        Me.lblTRADELINE.TabIndex = 51
        Me.lblTRADELINE.Tag = "TRADELINE"
        Me.lblTRADELINE.Text = "lblTRADELINE"
        Me.lblTRADELINE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBRATIO
        '
        Me.txtBRATIO.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtBRATIO.Location = New System.Drawing.Point(494, 120)
        Me.txtBRATIO.Name = "txtBRATIO"
        Me.txtBRATIO.Size = New System.Drawing.Size(138, 21)
        Me.txtBRATIO.TabIndex = 5
        Me.txtBRATIO.Tag = "BRATIO"
        Me.txtBRATIO.Text = "txtBRATIO"
        Me.txtBRATIO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtREPOLINE
        '
        Me.txtREPOLINE.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtREPOLINE.Location = New System.Drawing.Point(494, 56)
        Me.txtREPOLINE.Name = "txtREPOLINE"
        Me.txtREPOLINE.Size = New System.Drawing.Size(138, 21)
        Me.txtREPOLINE.TabIndex = 3
        Me.txtREPOLINE.Tag = "REPOLINE"
        Me.txtREPOLINE.Text = "txtREPOLINE"
        '
        'txtADVANCELINE
        '
        Me.txtADVANCELINE.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtADVANCELINE.Location = New System.Drawing.Point(136, 56)
        Me.txtADVANCELINE.Name = "txtADVANCELINE"
        Me.txtADVANCELINE.Size = New System.Drawing.Size(130, 21)
        Me.txtADVANCELINE.TabIndex = 2
        Me.txtADVANCELINE.Tag = "ADVANCELINE"
        Me.txtADVANCELINE.Text = "txtADVANCELINE"
        '
        'txtTRADELINE
        '
        Me.txtTRADELINE.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtTRADELINE.Location = New System.Drawing.Point(494, 24)
        Me.txtTRADELINE.Name = "txtTRADELINE"
        Me.txtTRADELINE.Size = New System.Drawing.Size(138, 21)
        Me.txtTRADELINE.TabIndex = 1
        Me.txtTRADELINE.Tag = "TRADELINE"
        Me.txtTRADELINE.Text = "txtTRADELINE"
        '
        'txtMARGINLINE
        '
        Me.txtMARGINLINE.Enabled = False
        Me.txtMARGINLINE.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMARGINLINE.Location = New System.Drawing.Point(136, 24)
        Me.txtMARGINLINE.Name = "txtMARGINLINE"
        Me.txtMARGINLINE.Size = New System.Drawing.Size(130, 21)
        Me.txtMARGINLINE.TabIndex = 0
        Me.txtMARGINLINE.Tag = "MARGINLINE"
        Me.txtMARGINLINE.Text = "txtMARGINLINE"
        '
        'lblMARGINLINE
        '
        Me.lblMARGINLINE.Location = New System.Drawing.Point(8, 24)
        Me.lblMARGINLINE.Name = "lblMARGINLINE"
        Me.lblMARGINLINE.Size = New System.Drawing.Size(126, 21)
        Me.lblMARGINLINE.TabIndex = 44
        Me.lblMARGINLINE.Tag = "MARGINLINE"
        Me.lblMARGINLINE.Text = "lblMARGINLINE"
        Me.lblMARGINLINE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tabContractMember
        '
        Me.tabContractMember.Controls.Add(Me.btnDELCM)
        Me.tabContractMember.Controls.Add(Me.btnEDITCM)
        Me.tabContractMember.Controls.Add(Me.btnVIEWCM)
        Me.tabContractMember.Controls.Add(Me.btnADDCM)
        Me.tabContractMember.Controls.Add(Me.pnMemberContract)
        Me.tabContractMember.Location = New System.Drawing.Point(4, 22)
        Me.tabContractMember.Name = "tabContractMember"
        Me.tabContractMember.Size = New System.Drawing.Size(667, 442)
        Me.tabContractMember.TabIndex = 6
        Me.tabContractMember.Tag = "tabContractMember"
        Me.tabContractMember.Text = "tabContractMember"
        Me.tabContractMember.UseVisualStyleBackColor = True
        '
        'btnDELCM
        '
        Me.btnDELCM.Location = New System.Drawing.Point(248, 8)
        Me.btnDELCM.Name = "btnDELCM"
        Me.btnDELCM.Size = New System.Drawing.Size(75, 24)
        Me.btnDELCM.TabIndex = 113
        Me.btnDELCM.Tag = "btnDELCM"
        Me.btnDELCM.Text = "btnDELCM"
        '
        'btnEDITCM
        '
        Me.btnEDITCM.Location = New System.Drawing.Point(168, 8)
        Me.btnEDITCM.Name = "btnEDITCM"
        Me.btnEDITCM.Size = New System.Drawing.Size(75, 24)
        Me.btnEDITCM.TabIndex = 112
        Me.btnEDITCM.Tag = "btnEDITCM"
        Me.btnEDITCM.Text = "btnEDITCM"
        '
        'btnVIEWCM
        '
        Me.btnVIEWCM.Location = New System.Drawing.Point(88, 8)
        Me.btnVIEWCM.Name = "btnVIEWCM"
        Me.btnVIEWCM.Size = New System.Drawing.Size(75, 24)
        Me.btnVIEWCM.TabIndex = 114
        Me.btnVIEWCM.Tag = "btnVIEWCM"
        Me.btnVIEWCM.Text = "btnVIEWCM"
        '
        'btnADDCM
        '
        Me.btnADDCM.Location = New System.Drawing.Point(8, 8)
        Me.btnADDCM.Name = "btnADDCM"
        Me.btnADDCM.Size = New System.Drawing.Size(75, 24)
        Me.btnADDCM.TabIndex = 111
        Me.btnADDCM.Tag = "btnADDCM"
        Me.btnADDCM.Text = "btnADDCM"
        '
        'pnMemberContract
        '
        Me.pnMemberContract.Location = New System.Drawing.Point(8, 38)
        Me.pnMemberContract.Name = "pnMemberContract"
        Me.pnMemberContract.Size = New System.Drawing.Size(648, 322)
        Me.pnMemberContract.TabIndex = 0
        Me.pnMemberContract.Tag = "pnMemberContract"
        '
        'tabACCOUNT
        '
        Me.tabACCOUNT.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.tabACCOUNT.Controls.Add(Me.pnACCOUNT)
        Me.tabACCOUNT.Location = New System.Drawing.Point(4, 22)
        Me.tabACCOUNT.Name = "tabACCOUNT"
        Me.tabACCOUNT.Size = New System.Drawing.Size(667, 442)
        Me.tabACCOUNT.TabIndex = 4
        Me.tabACCOUNT.Tag = "tabACCOUNT"
        Me.tabACCOUNT.Text = "tabACCOUNT"
        Me.tabACCOUNT.UseVisualStyleBackColor = True
        '
        'pnACCOUNT
        '
        Me.pnACCOUNT.BackColor = System.Drawing.SystemColors.Control
        Me.pnACCOUNT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnACCOUNT.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnACCOUNT.Location = New System.Drawing.Point(0, 59)
        Me.pnACCOUNT.Name = "pnACCOUNT"
        Me.pnACCOUNT.Size = New System.Drawing.Size(667, 383)
        Me.pnACCOUNT.TabIndex = 1
        Me.pnACCOUNT.Tag = "pnACCOUNT"
        '
        'tabEXTREFER
        '
        Me.tabEXTREFER.Controls.Add(Me.btnEDEL)
        Me.tabEXTREFER.Controls.Add(Me.btnEEDIT)
        Me.tabEXTREFER.Controls.Add(Me.btnEVIEW)
        Me.tabEXTREFER.Controls.Add(Me.btnEADD)
        Me.tabEXTREFER.Controls.Add(Me.pnExtRefer)
        Me.tabEXTREFER.Location = New System.Drawing.Point(4, 22)
        Me.tabEXTREFER.Name = "tabEXTREFER"
        Me.tabEXTREFER.Size = New System.Drawing.Size(667, 442)
        Me.tabEXTREFER.TabIndex = 7
        Me.tabEXTREFER.Tag = "tabEXTREFER"
        Me.tabEXTREFER.Text = "tabEXTREFER"
        Me.tabEXTREFER.UseVisualStyleBackColor = True
        '
        'btnEDEL
        '
        Me.btnEDEL.Location = New System.Drawing.Point(244, 6)
        Me.btnEDEL.Name = "btnEDEL"
        Me.btnEDEL.Size = New System.Drawing.Size(75, 23)
        Me.btnEDEL.TabIndex = 114
        Me.btnEDEL.Tag = "btnADEL"
        Me.btnEDEL.Text = "btnEDEL"
        '
        'btnEEDIT
        '
        Me.btnEEDIT.Location = New System.Drawing.Point(164, 6)
        Me.btnEEDIT.Name = "btnEEDIT"
        Me.btnEEDIT.Size = New System.Drawing.Size(75, 23)
        Me.btnEEDIT.TabIndex = 113
        Me.btnEEDIT.Tag = "btnAEDIT"
        Me.btnEEDIT.Text = "btnEEDIT"
        '
        'btnEVIEW
        '
        Me.btnEVIEW.Location = New System.Drawing.Point(84, 6)
        Me.btnEVIEW.Name = "btnEVIEW"
        Me.btnEVIEW.Size = New System.Drawing.Size(75, 23)
        Me.btnEVIEW.TabIndex = 115
        Me.btnEVIEW.Tag = "btnAVIEW"
        Me.btnEVIEW.Text = "btnEVIEW"
        '
        'btnEADD
        '
        Me.btnEADD.Location = New System.Drawing.Point(4, 6)
        Me.btnEADD.Name = "btnEADD"
        Me.btnEADD.Size = New System.Drawing.Size(75, 23)
        Me.btnEADD.TabIndex = 112
        Me.btnEADD.Tag = "btnAADD"
        Me.btnEADD.Text = "btnEADD"
        '
        'pnExtRefer
        '
        Me.pnExtRefer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnExtRefer.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnExtRefer.Location = New System.Drawing.Point(0, 89)
        Me.pnExtRefer.Name = "pnExtRefer"
        Me.pnExtRefer.Size = New System.Drawing.Size(667, 353)
        Me.pnExtRefer.TabIndex = 111
        Me.pnExtRefer.Tag = "pnExtRefer"
        '
        'tabAnthorize
        '
        Me.tabAnthorize.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.tabAnthorize.Controls.Add(Me.btnADEL)
        Me.tabAnthorize.Controls.Add(Me.btnAEDIT)
        Me.tabAnthorize.Controls.Add(Me.btnAVIEW)
        Me.tabAnthorize.Controls.Add(Me.btnAADD)
        Me.tabAnthorize.Controls.Add(Me.pnAnthorize)
        Me.tabAnthorize.Location = New System.Drawing.Point(4, 22)
        Me.tabAnthorize.Name = "tabAnthorize"
        Me.tabAnthorize.Size = New System.Drawing.Size(667, 442)
        Me.tabAnthorize.TabIndex = 3
        Me.tabAnthorize.Tag = "Anthorize"
        Me.tabAnthorize.Text = "tabAnthorize"
        Me.tabAnthorize.UseVisualStyleBackColor = True
        '
        'btnADEL
        '
        Me.btnADEL.BackColor = System.Drawing.Color.Transparent
        Me.btnADEL.Location = New System.Drawing.Point(248, 8)
        Me.btnADEL.Name = "btnADEL"
        Me.btnADEL.Size = New System.Drawing.Size(75, 23)
        Me.btnADEL.TabIndex = 105
        Me.btnADEL.Tag = "btnADEL"
        Me.btnADEL.Text = "btnADEL"
        Me.btnADEL.UseVisualStyleBackColor = False
        '
        'btnAEDIT
        '
        Me.btnAEDIT.BackColor = System.Drawing.Color.Transparent
        Me.btnAEDIT.Location = New System.Drawing.Point(168, 8)
        Me.btnAEDIT.Name = "btnAEDIT"
        Me.btnAEDIT.Size = New System.Drawing.Size(75, 23)
        Me.btnAEDIT.TabIndex = 104
        Me.btnAEDIT.Tag = "btnAEDIT"
        Me.btnAEDIT.Text = "btnAEDIT"
        Me.btnAEDIT.UseVisualStyleBackColor = False
        '
        'btnAVIEW
        '
        Me.btnAVIEW.BackColor = System.Drawing.Color.Transparent
        Me.btnAVIEW.Location = New System.Drawing.Point(88, 8)
        Me.btnAVIEW.Name = "btnAVIEW"
        Me.btnAVIEW.Size = New System.Drawing.Size(75, 23)
        Me.btnAVIEW.TabIndex = 106
        Me.btnAVIEW.Tag = "btnAVIEW"
        Me.btnAVIEW.Text = "btnAVIEW"
        Me.btnAVIEW.UseVisualStyleBackColor = False
        '
        'btnAADD
        '
        Me.btnAADD.BackColor = System.Drawing.Color.Transparent
        Me.btnAADD.Location = New System.Drawing.Point(8, 8)
        Me.btnAADD.Name = "btnAADD"
        Me.btnAADD.Size = New System.Drawing.Size(75, 23)
        Me.btnAADD.TabIndex = 103
        Me.btnAADD.Tag = "btnAADD"
        Me.btnAADD.Text = "btnAADD"
        Me.btnAADD.UseVisualStyleBackColor = False
        '
        'pnAnthorize
        '
        Me.pnAnthorize.BackColor = System.Drawing.SystemColors.Control
        Me.pnAnthorize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnAnthorize.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnAnthorize.Location = New System.Drawing.Point(0, 91)
        Me.pnAnthorize.Name = "pnAnthorize"
        Me.pnAnthorize.Size = New System.Drawing.Size(667, 351)
        Me.pnAnthorize.TabIndex = 1
        Me.pnAnthorize.Tag = "pnAnthorize"
        '
        'tabICCF
        '
        Me.tabICCF.Controls.Add(Me.pnICCF)
        Me.tabICCF.Controls.Add(Me.cboTLMODCODE)
        Me.tabICCF.Controls.Add(Me.lblTLMODCODE)
        Me.tabICCF.Location = New System.Drawing.Point(4, 22)
        Me.tabICCF.Name = "tabICCF"
        Me.tabICCF.Size = New System.Drawing.Size(667, 442)
        Me.tabICCF.TabIndex = 8
        Me.tabICCF.Tag = "ICCF"
        Me.tabICCF.Text = "tabICCF"
        Me.tabICCF.UseVisualStyleBackColor = True
        '
        'pnICCF
        '
        Me.pnICCF.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnICCF.Location = New System.Drawing.Point(0, 89)
        Me.pnICCF.Name = "pnICCF"
        Me.pnICCF.Size = New System.Drawing.Size(667, 353)
        Me.pnICCF.TabIndex = 5
        '
        'cboTLMODCODE
        '
        Me.cboTLMODCODE.DisplayMember = "DISPLAY"
        Me.cboTLMODCODE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTLMODCODE.Location = New System.Drawing.Point(96, 8)
        Me.cboTLMODCODE.Name = "cboTLMODCODE"
        Me.cboTLMODCODE.Size = New System.Drawing.Size(202, 21)
        Me.cboTLMODCODE.TabIndex = 4
        Me.cboTLMODCODE.Tag = String.Empty
        Me.cboTLMODCODE.ValueMember = "VALUE"
        '
        'lblTLMODCODE
        '
        Me.lblTLMODCODE.Location = New System.Drawing.Point(8, 8)
        Me.lblTLMODCODE.Name = "lblTLMODCODE"
        Me.lblTLMODCODE.Size = New System.Drawing.Size(88, 23)
        Me.lblTLMODCODE.TabIndex = 3
        Me.lblTLMODCODE.Tag = "TLMODCODE"
        Me.lblTLMODCODE.Text = "lblTLMODCODE"
        '
        'tabTxmap
        '
        Me.tabTxmap.Controls.Add(Me.pnTxmap)
        Me.tabTxmap.Controls.Add(Me.btnTXDEL)
        Me.tabTxmap.Controls.Add(Me.btnTXEDIT)
        Me.tabTxmap.Controls.Add(Me.btnTXVIEW)
        Me.tabTxmap.Controls.Add(Me.btnTXADD)
        Me.tabTxmap.Location = New System.Drawing.Point(4, 22)
        Me.tabTxmap.Name = "tabTxmap"
        Me.tabTxmap.Size = New System.Drawing.Size(667, 442)
        Me.tabTxmap.TabIndex = 9
        Me.tabTxmap.Tag = "tabTxmap"
        Me.tabTxmap.Text = "tabTxmap"
        Me.tabTxmap.UseVisualStyleBackColor = True
        '
        'pnTxmap
        '
        Me.pnTxmap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnTxmap.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnTxmap.Location = New System.Drawing.Point(0, 82)
        Me.pnTxmap.Name = "pnTxmap"
        Me.pnTxmap.Size = New System.Drawing.Size(667, 360)
        Me.pnTxmap.TabIndex = 116
        Me.pnTxmap.Tag = "pnTxmap"
        '
        'btnTXDEL
        '
        Me.btnTXDEL.Location = New System.Drawing.Point(246, 13)
        Me.btnTXDEL.Name = "btnTXDEL"
        Me.btnTXDEL.Size = New System.Drawing.Size(75, 24)
        Me.btnTXDEL.TabIndex = 114
        Me.btnTXDEL.Tag = "btnTXDEL"
        Me.btnTXDEL.Text = "btnTXDEL"
        '
        'btnTXEDIT
        '
        Me.btnTXEDIT.Location = New System.Drawing.Point(166, 13)
        Me.btnTXEDIT.Name = "btnTXEDIT"
        Me.btnTXEDIT.Size = New System.Drawing.Size(75, 24)
        Me.btnTXEDIT.TabIndex = 113
        Me.btnTXEDIT.Tag = "btnTXEDIT"
        Me.btnTXEDIT.Text = "btnTXEDIT"
        '
        'btnTXVIEW
        '
        Me.btnTXVIEW.Location = New System.Drawing.Point(86, 13)
        Me.btnTXVIEW.Name = "btnTXVIEW"
        Me.btnTXVIEW.Size = New System.Drawing.Size(75, 24)
        Me.btnTXVIEW.TabIndex = 115
        Me.btnTXVIEW.Tag = "btnTXVIEW"
        Me.btnTXVIEW.Text = "btnTXVIEW"
        '
        'btnTXADD
        '
        Me.btnTXADD.Location = New System.Drawing.Point(6, 13)
        Me.btnTXADD.Name = "btnTXADD"
        Me.btnTXADD.Size = New System.Drawing.Size(75, 24)
        Me.btnTXADD.TabIndex = 112
        Me.btnTXADD.Tag = "btnTXADD"
        Me.btnTXADD.Text = "btnTXADD"
        '
        'tabAFSERULE
        '
        Me.tabAFSERULE.Controls.Add(Me.btnASDEL)
        Me.tabAFSERULE.Controls.Add(Me.btnASEDIT)
        Me.tabAFSERULE.Controls.Add(Me.btnASVIEW)
        Me.tabAFSERULE.Controls.Add(Me.btnASADD)
        Me.tabAFSERULE.Controls.Add(Me.pnAFSERULE)
        Me.tabAFSERULE.Location = New System.Drawing.Point(4, 22)
        Me.tabAFSERULE.Name = "tabAFSERULE"
        Me.tabAFSERULE.Padding = New System.Windows.Forms.Padding(3)
        Me.tabAFSERULE.Size = New System.Drawing.Size(667, 442)
        Me.tabAFSERULE.TabIndex = 10
        Me.tabAFSERULE.Tag = "tabAFSERULE"
        Me.tabAFSERULE.Text = "tabAFSERULE"
        Me.tabAFSERULE.UseVisualStyleBackColor = True
        '
        'btnASDEL
        '
        Me.btnASDEL.Location = New System.Drawing.Point(255, 10)
        Me.btnASDEL.Name = "btnASDEL"
        Me.btnASDEL.Size = New System.Drawing.Size(75, 23)
        Me.btnASDEL.TabIndex = 4
        Me.btnASDEL.Tag = "btnASDEL"
        Me.btnASDEL.Text = "btnASDEL"
        Me.btnASDEL.UseVisualStyleBackColor = True
        '
        'btnASEDIT
        '
        Me.btnASEDIT.Location = New System.Drawing.Point(171, 10)
        Me.btnASEDIT.Name = "btnASEDIT"
        Me.btnASEDIT.Size = New System.Drawing.Size(75, 23)
        Me.btnASEDIT.TabIndex = 3
        Me.btnASEDIT.Tag = "btnASEDIT"
        Me.btnASEDIT.Text = "btnASEDIT"
        Me.btnASEDIT.UseVisualStyleBackColor = True
        '
        'btnASVIEW
        '
        Me.btnASVIEW.Location = New System.Drawing.Point(88, 10)
        Me.btnASVIEW.Name = "btnASVIEW"
        Me.btnASVIEW.Size = New System.Drawing.Size(75, 23)
        Me.btnASVIEW.TabIndex = 2
        Me.btnASVIEW.Tag = "btnASVIEW"
        Me.btnASVIEW.Text = "btnASVIEW"
        Me.btnASVIEW.UseVisualStyleBackColor = True
        '
        'btnASADD
        '
        Me.btnASADD.Location = New System.Drawing.Point(6, 10)
        Me.btnASADD.Name = "btnASADD"
        Me.btnASADD.Size = New System.Drawing.Size(75, 23)
        Me.btnASADD.TabIndex = 1
        Me.btnASADD.Tag = "btnASADD"
        Me.btnASADD.Text = "btnASADD"
        Me.btnASADD.UseVisualStyleBackColor = True
        '
        'pnAFSERULE
        '
        Me.pnAFSERULE.Location = New System.Drawing.Point(6, 46)
        Me.pnAFSERULE.Name = "pnAFSERULE"
        Me.pnAFSERULE.Size = New System.Drawing.Size(655, 358)
        Me.pnAFSERULE.TabIndex = 0
        Me.pnAFSERULE.Tag = "pnAFSERULE"
        '
        'tabOTRIGHT
        '
        Me.tabOTRIGHT.Controls.Add(Me.btnOTDEL)
        Me.tabOTRIGHT.Controls.Add(Me.btnOTEDIT)
        Me.tabOTRIGHT.Controls.Add(Me.btnOTVIEW)
        Me.tabOTRIGHT.Controls.Add(Me.btnOTADD)
        Me.tabOTRIGHT.Controls.Add(Me.pnOTRightAsgn)
        Me.tabOTRIGHT.Location = New System.Drawing.Point(4, 22)
        Me.tabOTRIGHT.Name = "tabOTRIGHT"
        Me.tabOTRIGHT.Size = New System.Drawing.Size(667, 442)
        Me.tabOTRIGHT.TabIndex = 11
        Me.tabOTRIGHT.Tag = "tabOTRIGHT"
        Me.tabOTRIGHT.Text = "tabOTRIGHT"
        Me.tabOTRIGHT.UseVisualStyleBackColor = True
        '
        'btnOTDEL
        '
        Me.btnOTDEL.Location = New System.Drawing.Point(273, 18)
        Me.btnOTDEL.Name = "btnOTDEL"
        Me.btnOTDEL.Size = New System.Drawing.Size(75, 23)
        Me.btnOTDEL.TabIndex = 3
        Me.btnOTDEL.Tag = "btnOTDEL"
        Me.btnOTDEL.Text = "btnOTDEL"
        Me.btnOTDEL.UseVisualStyleBackColor = True
        '
        'btnOTEDIT
        '
        Me.btnOTEDIT.Location = New System.Drawing.Point(184, 18)
        Me.btnOTEDIT.Name = "btnOTEDIT"
        Me.btnOTEDIT.Size = New System.Drawing.Size(75, 23)
        Me.btnOTEDIT.TabIndex = 2
        Me.btnOTEDIT.Tag = "btnOTEDIT"
        Me.btnOTEDIT.Text = "btnOTEDIT"
        Me.btnOTEDIT.UseVisualStyleBackColor = True
        '
        'btnOTVIEW
        '
        Me.btnOTVIEW.Location = New System.Drawing.Point(95, 18)
        Me.btnOTVIEW.Name = "btnOTVIEW"
        Me.btnOTVIEW.Size = New System.Drawing.Size(75, 23)
        Me.btnOTVIEW.TabIndex = 1
        Me.btnOTVIEW.Tag = "btnOTVIEW"
        Me.btnOTVIEW.Text = "btnOTVIEW"
        Me.btnOTVIEW.UseVisualStyleBackColor = True
        '
        'btnOTADD
        '
        Me.btnOTADD.Location = New System.Drawing.Point(6, 18)
        Me.btnOTADD.Name = "btnOTADD"
        Me.btnOTADD.Size = New System.Drawing.Size(75, 23)
        Me.btnOTADD.TabIndex = 0
        Me.btnOTADD.Tag = "btnOTADD"
        Me.btnOTADD.Text = "btnOTADD"
        Me.btnOTADD.UseVisualStyleBackColor = True
        '
        'pnOTRightAsgn
        '
        Me.pnOTRightAsgn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnOTRightAsgn.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnOTRightAsgn.Location = New System.Drawing.Point(0, 58)
        Me.pnOTRightAsgn.Name = "pnOTRightAsgn"
        Me.pnOTRightAsgn.Size = New System.Drawing.Size(667, 384)
        Me.pnOTRightAsgn.TabIndex = 0
        Me.pnOTRightAsgn.Tag = "pnOTRightAsgn"
        '
        'tabTemplates
        '
        Me.tabTemplates.Controls.Add(Me.pnTemplate)
        Me.tabTemplates.Controls.Add(Me.btnViewTemplate)
        Me.tabTemplates.Controls.Add(Me.btnDeleteTemplate)
        Me.tabTemplates.Controls.Add(Me.btnEditTemplate)
        Me.tabTemplates.Controls.Add(Me.btnAddTemplate)
        Me.tabTemplates.Location = New System.Drawing.Point(4, 22)
        Me.tabTemplates.Name = "tabTemplates"
        Me.tabTemplates.Padding = New System.Windows.Forms.Padding(3)
        Me.tabTemplates.Size = New System.Drawing.Size(667, 442)
        Me.tabTemplates.TabIndex = 12
        Me.tabTemplates.Tag = "tabTemplates"
        Me.tabTemplates.Text = "tabTemplates"
        Me.tabTemplates.UseVisualStyleBackColor = True
        '
        'pnTemplate
        '
        Me.pnTemplate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnTemplate.Location = New System.Drawing.Point(7, 36)
        Me.pnTemplate.Name = "pnTemplate"
        Me.pnTemplate.Size = New System.Drawing.Size(654, 400)
        Me.pnTemplate.TabIndex = 58
        Me.pnTemplate.Tag = "pnTemplate"
        '
        'btnViewTemplate
        '
        Me.btnViewTemplate.Location = New System.Drawing.Point(87, 6)
        Me.btnViewTemplate.Name = "btnViewTemplate"
        Me.btnViewTemplate.Size = New System.Drawing.Size(75, 23)
        Me.btnViewTemplate.TabIndex = 57
        Me.btnViewTemplate.Tag = "btnViewTemplate"
        Me.btnViewTemplate.Text = "btnViewTemplate"
        Me.btnViewTemplate.UseVisualStyleBackColor = True
        '
        'btnDeleteTemplate
        '
        Me.btnDeleteTemplate.Location = New System.Drawing.Point(249, 6)
        Me.btnDeleteTemplate.Name = "btnDeleteTemplate"
        Me.btnDeleteTemplate.Size = New System.Drawing.Size(75, 23)
        Me.btnDeleteTemplate.TabIndex = 56
        Me.btnDeleteTemplate.Tag = "btnDeleteTemplate"
        Me.btnDeleteTemplate.Text = "btnDeleteTemplate"
        Me.btnDeleteTemplate.UseVisualStyleBackColor = True
        '
        'btnEditTemplate
        '
        Me.btnEditTemplate.Location = New System.Drawing.Point(168, 6)
        Me.btnEditTemplate.Name = "btnEditTemplate"
        Me.btnEditTemplate.Size = New System.Drawing.Size(75, 23)
        Me.btnEditTemplate.TabIndex = 55
        Me.btnEditTemplate.Tag = "btnEditTemplate"
        Me.btnEditTemplate.Text = "btnEditTemplate"
        Me.btnEditTemplate.UseVisualStyleBackColor = True
        '
        'btnAddTemplate
        '
        Me.btnAddTemplate.Location = New System.Drawing.Point(6, 6)
        Me.btnAddTemplate.Name = "btnAddTemplate"
        Me.btnAddTemplate.Size = New System.Drawing.Size(75, 23)
        Me.btnAddTemplate.TabIndex = 2
        Me.btnAddTemplate.Tag = "btnAddTemplates"
        Me.btnAddTemplate.Text = "btnAddTemplates"
        Me.btnAddTemplate.UseVisualStyleBackColor = True
        '
        'tabReport
        '
        Me.tabReport.Controls.Add(Me.cboRECEIVEVIA)
        Me.tabReport.Controls.Add(Me.cboLANGUAGE)
        Me.tabReport.Controls.Add(Me.lblSTMCYCLE)
        Me.tabReport.Controls.Add(Me.lblLANGUAGE)
        Me.tabReport.Controls.Add(Me.lblRECEIVEVIA)
        Me.tabReport.Controls.Add(Me.pnReport)
        Me.tabReport.Controls.Add(Me.btnRPTDEL)
        Me.tabReport.Controls.Add(Me.btnRPTEDIT)
        Me.tabReport.Controls.Add(Me.btnRPTVIEW)
        Me.tabReport.Controls.Add(Me.btnRPTADD)
        Me.tabReport.Controls.Add(Me.cboSTMCYCLE)
        Me.tabReport.Location = New System.Drawing.Point(4, 22)
        Me.tabReport.Name = "tabReport"
        Me.tabReport.Size = New System.Drawing.Size(667, 442)
        Me.tabReport.TabIndex = 5
        Me.tabReport.Tag = "tabReport"
        Me.tabReport.Text = "tabReport"
        Me.tabReport.UseVisualStyleBackColor = True
        '
        'cboRECEIVEVIA
        '
        Me.cboRECEIVEVIA.DisplayMember = "DISPLAY"
        Me.cboRECEIVEVIA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRECEIVEVIA.Location = New System.Drawing.Point(512, 8)
        Me.cboRECEIVEVIA.Name = "cboRECEIVEVIA"
        Me.cboRECEIVEVIA.Size = New System.Drawing.Size(104, 21)
        Me.cboRECEIVEVIA.TabIndex = 162
        Me.cboRECEIVEVIA.Tag = "RECEIVEVIA"
        Me.cboRECEIVEVIA.ValueMember = "VALUE"
        '
        'cboLANGUAGE
        '
        Me.cboLANGUAGE.DisplayMember = "DISPLAY"
        Me.cboLANGUAGE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLANGUAGE.Location = New System.Drawing.Point(296, 8)
        Me.cboLANGUAGE.Name = "cboLANGUAGE"
        Me.cboLANGUAGE.Size = New System.Drawing.Size(128, 21)
        Me.cboLANGUAGE.TabIndex = 161
        Me.cboLANGUAGE.Tag = "LANGUAGE"
        Me.cboLANGUAGE.ValueMember = "VALUE"
        '
        'lblSTMCYCLE
        '
        Me.lblSTMCYCLE.BackColor = System.Drawing.Color.Transparent
        Me.lblSTMCYCLE.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSTMCYCLE.Location = New System.Drawing.Point(6, 8)
        Me.lblSTMCYCLE.Name = "lblSTMCYCLE"
        Me.lblSTMCYCLE.Size = New System.Drawing.Size(88, 21)
        Me.lblSTMCYCLE.TabIndex = 160
        Me.lblSTMCYCLE.Tag = "STMCYCLE"
        Me.lblSTMCYCLE.Text = "lblSTMCYCLE"
        Me.lblSTMCYCLE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLANGUAGE
        '
        Me.lblLANGUAGE.Location = New System.Drawing.Point(208, 8)
        Me.lblLANGUAGE.Name = "lblLANGUAGE"
        Me.lblLANGUAGE.Size = New System.Drawing.Size(80, 21)
        Me.lblLANGUAGE.TabIndex = 159
        Me.lblLANGUAGE.Tag = "LANGUAGE"
        Me.lblLANGUAGE.Text = "lblLANGUAGE"
        Me.lblLANGUAGE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRECEIVEVIA
        '
        Me.lblRECEIVEVIA.Location = New System.Drawing.Point(432, 8)
        Me.lblRECEIVEVIA.Name = "lblRECEIVEVIA"
        Me.lblRECEIVEVIA.Size = New System.Drawing.Size(80, 21)
        Me.lblRECEIVEVIA.TabIndex = 158
        Me.lblRECEIVEVIA.Tag = "RECEIVEVIA"
        Me.lblRECEIVEVIA.Text = "lblRECEIVEVIA"
        Me.lblRECEIVEVIA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnReport
        '
        Me.pnReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnReport.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnReport.Location = New System.Drawing.Point(0, 125)
        Me.pnReport.Name = "pnReport"
        Me.pnReport.Size = New System.Drawing.Size(667, 317)
        Me.pnReport.TabIndex = 111
        Me.pnReport.Tag = "pnReport"
        '
        'btnRPTDEL
        '
        Me.btnRPTDEL.Location = New System.Drawing.Point(246, 40)
        Me.btnRPTDEL.Name = "btnRPTDEL"
        Me.btnRPTDEL.Size = New System.Drawing.Size(75, 24)
        Me.btnRPTDEL.TabIndex = 109
        Me.btnRPTDEL.Tag = "btnRPTDEL"
        Me.btnRPTDEL.Text = "btnRPTDEL"
        '
        'btnRPTEDIT
        '
        Me.btnRPTEDIT.Location = New System.Drawing.Point(166, 40)
        Me.btnRPTEDIT.Name = "btnRPTEDIT"
        Me.btnRPTEDIT.Size = New System.Drawing.Size(75, 24)
        Me.btnRPTEDIT.TabIndex = 108
        Me.btnRPTEDIT.Tag = "btnRPTEDIT"
        Me.btnRPTEDIT.Text = "btnRPTEDIT"
        '
        'btnRPTVIEW
        '
        Me.btnRPTVIEW.Location = New System.Drawing.Point(86, 40)
        Me.btnRPTVIEW.Name = "btnRPTVIEW"
        Me.btnRPTVIEW.Size = New System.Drawing.Size(75, 24)
        Me.btnRPTVIEW.TabIndex = 110
        Me.btnRPTVIEW.Tag = "btnRPTVIEW"
        Me.btnRPTVIEW.Text = "btnRPTVIEW"
        '
        'btnRPTADD
        '
        Me.btnRPTADD.Location = New System.Drawing.Point(6, 40)
        Me.btnRPTADD.Name = "btnRPTADD"
        Me.btnRPTADD.Size = New System.Drawing.Size(75, 24)
        Me.btnRPTADD.TabIndex = 107
        Me.btnRPTADD.Tag = "btnRPTADD"
        Me.btnRPTADD.Text = "btnRPTADD"
        '
        'cboSTMCYCLE
        '
        Me.cboSTMCYCLE.DisplayMember = "DISPLAY"
        Me.cboSTMCYCLE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSTMCYCLE.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSTMCYCLE.ItemHeight = 13
        Me.cboSTMCYCLE.Location = New System.Drawing.Point(96, 8)
        Me.cboSTMCYCLE.Name = "cboSTMCYCLE"
        Me.cboSTMCYCLE.Size = New System.Drawing.Size(106, 21)
        Me.cboSTMCYCLE.TabIndex = 153
        Me.cboSTMCYCLE.Tag = "STMCYCLE"
        Me.cboSTMCYCLE.ValueMember = "VALUE"
        '
        'tabMember
        '
        Me.tabMember.Location = New System.Drawing.Point(0, 0)
        Me.tabMember.Name = "tabMember"
        Me.tabMember.Size = New System.Drawing.Size(200, 100)
        Me.tabMember.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(200, 100)
        Me.Panel2.TabIndex = 0
        '
        'btnCDEL
        '
        Me.btnCDEL.Location = New System.Drawing.Point(0, 0)
        Me.btnCDEL.Name = "btnCDEL"
        Me.btnCDEL.Size = New System.Drawing.Size(75, 23)
        Me.btnCDEL.TabIndex = 0
        '
        'btnCEDIT
        '
        Me.btnCEDIT.Location = New System.Drawing.Point(0, 0)
        Me.btnCEDIT.Name = "btnCEDIT"
        Me.btnCEDIT.Size = New System.Drawing.Size(75, 23)
        Me.btnCEDIT.TabIndex = 0
        '
        'btnCVIEW
        '
        Me.btnCVIEW.Location = New System.Drawing.Point(0, 0)
        Me.btnCVIEW.Name = "btnCVIEW"
        Me.btnCVIEW.Size = New System.Drawing.Size(75, 23)
        Me.btnCVIEW.TabIndex = 0
        '
        'btnCADD
        '
        Me.btnCADD.Location = New System.Drawing.Point(0, 0)
        Me.btnCADD.Name = "btnCADD"
        Me.btnCADD.Size = New System.Drawing.Size(75, 23)
        Me.btnCADD.TabIndex = 0
        '
        'pnMember
        '
        Me.pnMember.Location = New System.Drawing.Point(0, 0)
        Me.pnMember.Name = "pnMember"
        Me.pnMember.Size = New System.Drawing.Size(200, 100)
        Me.pnMember.TabIndex = 0
        '
        'btnCheckAcc
        '
        Me.btnCheckAcc.Location = New System.Drawing.Point(248, 54)
        Me.btnCheckAcc.Name = "btnCheckAcc"
        Me.btnCheckAcc.Size = New System.Drawing.Size(92, 21)
        Me.btnCheckAcc.TabIndex = 4
        Me.btnCheckAcc.Tag = "btnCheckAcc"
        '
        'txtOPNDATE
        '
        Me.txtOPNDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtOPNDATE.Location = New System.Drawing.Point(229, 556)
        Me.txtOPNDATE.Name = "txtOPNDATE"
        Me.txtOPNDATE.Size = New System.Drawing.Size(81, 21)
        Me.txtOPNDATE.TabIndex = 53
        Me.txtOPNDATE.Tag = "OPNDATE"
        Me.txtOPNDATE.Value = New Date(2010, 4, 20, 0, 0, 0, 0)
        '
        'txtBRID
        '
        Me.txtBRID.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.txtBRID.Location = New System.Drawing.Point(161, 556)
        Me.txtBRID.MaxLength = 20
        Me.txtBRID.Name = "txtBRID"
        Me.txtBRID.Size = New System.Drawing.Size(64, 21)
        Me.txtBRID.TabIndex = 48
        Me.txtBRID.Tag = "BRID"
        '
        'lblCUSTATCOM
        '
        Me.lblCUSTATCOM.AutoSize = True
        Me.lblCUSTATCOM.Location = New System.Drawing.Point(532, 58)
        Me.lblCUSTATCOM.Name = "lblCUSTATCOM"
        Me.lblCUSTATCOM.Size = New System.Drawing.Size(79, 13)
        Me.lblCUSTATCOM.TabIndex = 54
        Me.lblCUSTATCOM.Tag = "CUSTATCOM"
        Me.lblCUSTATCOM.Text = "lblCUSTATCOM"
        Me.lblCUSTATCOM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCUSTATCOM
        '
        Me.cboCUSTATCOM.DisplayMember = "DISPLAY"
        Me.cboCUSTATCOM.Location = New System.Drawing.Point(621, 54)
        Me.cboCUSTATCOM.Name = "cboCUSTATCOM"
        Me.cboCUSTATCOM.Size = New System.Drawing.Size(56, 21)
        Me.cboCUSTATCOM.TabIndex = 1
        Me.cboCUSTATCOM.Tag = String.Empty
        Me.cboCUSTATCOM.ValueMember = "VALUE"
        '
        'lblTRADINGCODE
        '
        Me.lblTRADINGCODE.AutoSize = True
        Me.lblTRADINGCODE.Location = New System.Drawing.Point(346, 58)
        Me.lblTRADINGCODE.Name = "lblTRADINGCODE"
        Me.lblTRADINGCODE.Size = New System.Drawing.Size(90, 13)
        Me.lblTRADINGCODE.TabIndex = 55
        Me.lblTRADINGCODE.Tag = "TRADINGCODE"
        Me.lblTRADINGCODE.Text = "lblTRADINGCODE"
        '
        'txtTRADINGCODE
        '
        Me.txtTRADINGCODE.Location = New System.Drawing.Point(441, 56)
        Me.txtTRADINGCODE.Name = "txtTRADINGCODE"
        Me.txtTRADINGCODE.Size = New System.Drawing.Size(86, 21)
        Me.txtTRADINGCODE.TabIndex = 56
        Me.txtTRADINGCODE.Tag = "TRADINGCODE"
        Me.txtTRADINGCODE.Text = "txtTRADINGCODE"
        '
        'cboAPPLYPOLICY
        '
        Me.cboAPPLYPOLICY.AutoSize = True
        Me.cboAPPLYPOLICY.Location = New System.Drawing.Point(29, 558)
        Me.cboAPPLYPOLICY.Name = "cboAPPLYPOLICY"
        Me.cboAPPLYPOLICY.Size = New System.Drawing.Size(109, 17)
        Me.cboAPPLYPOLICY.TabIndex = 57
        Me.cboAPPLYPOLICY.Tag = "cboAPPLYPOLICY"
        Me.cboAPPLYPOLICY.Text = "cboAPPLYPOLICY"
        Me.cboAPPLYPOLICY.UseVisualStyleBackColor = True
        '
        'cboAPPLYACCT
        '
        Me.cboAPPLYACCT.FormattingEnabled = True
        Me.cboAPPLYACCT.Location = New System.Drawing.Point(28, 582)
        Me.cboAPPLYACCT.Name = "cboAPPLYACCT"
        Me.cboAPPLYACCT.Size = New System.Drawing.Size(331, 21)
        Me.cboAPPLYACCT.Tag = String.Empty
        Me.cboAPPLYACCT.TabIndex = 58
        '
        'frmAFMAST
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(689, 608)
        Me.Controls.Add(Me.cboAPPLYACCT)
        Me.Controls.Add(Me.cboAPPLYPOLICY)
        Me.Controls.Add(Me.txtTRADINGCODE)
        Me.Controls.Add(Me.lblTRADINGCODE)
        Me.Controls.Add(Me.txtBRID)
        Me.Controls.Add(Me.txtOPNDATE)
        Me.Controls.Add(Me.btnCheckAcc)
        Me.Controls.Add(Me.btnGenContractNo)
        Me.Controls.Add(Me.lblACCTNO)
        Me.Controls.Add(Me.txtACCTNO)
        Me.Controls.Add(Me.lblPIN)
        Me.Controls.Add(Me.tabAFMAST)
        Me.Controls.Add(Me.txtPIN)
        Me.Controls.Add(Me.cboCUSTATCOM)
        Me.Controls.Add(Me.lblCUSTATCOM)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Name = "frmAFMAST"
        Me.Tag = "AFMAST"
        Me.Text = "frmAFMAST"
        Me.Controls.SetChildIndex(Me.lblCUSTATCOM, 0)
        Me.Controls.SetChildIndex(Me.cboCUSTATCOM, 0)
        Me.Controls.SetChildIndex(Me.txtPIN, 0)
        Me.Controls.SetChildIndex(Me.cboLink, 0)
        Me.Controls.SetChildIndex(Me.btnApprv, 0)
        Me.Controls.SetChildIndex(Me.tabAFMAST, 0)
        Me.Controls.SetChildIndex(Me.lblPIN, 0)
        Me.Controls.SetChildIndex(Me.txtACCTNO, 0)
        Me.Controls.SetChildIndex(Me.lblACCTNO, 0)
        Me.Controls.SetChildIndex(Me.btnGenContractNo, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.btnApply, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.btnCheckAcc, 0)
        Me.Controls.SetChildIndex(Me.txtOPNDATE, 0)
        Me.Controls.SetChildIndex(Me.txtBRID, 0)
        Me.Controls.SetChildIndex(Me.lblTRADINGCODE, 0)
        Me.Controls.SetChildIndex(Me.txtTRADINGCODE, 0)
        Me.Controls.SetChildIndex(Me.cboAPPLYPOLICY, 0)
        Me.Controls.SetChildIndex(Me.cboAPPLYACCT, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.grbMainInfo.ResumeLayout(False)
        Me.grbMainInfo.PerformLayout()
        Me.grbBankInfo.ResumeLayout(False)
        Me.grbBankInfo.PerformLayout()
        Me.tabAFMAST.ResumeLayout(False)
        Me.tabMainInfo.ResumeLayout(False)
        Me.tabSevice.ResumeLayout(False)
        Me.grbLimit.ResumeLayout(False)
        Me.grbLimit.PerformLayout()
        Me.grbMRService.ResumeLayout(False)
        Me.grbMRService.PerformLayout()
        Me.tabContractMember.ResumeLayout(False)
        Me.tabACCOUNT.ResumeLayout(False)
        Me.tabEXTREFER.ResumeLayout(False)
        Me.tabAnthorize.ResumeLayout(False)
        Me.tabICCF.ResumeLayout(False)
        Me.tabTxmap.ResumeLayout(False)
        Me.tabAFSERULE.ResumeLayout(False)
        Me.tabOTRIGHT.ResumeLayout(False)
        Me.tabTemplates.ResumeLayout(False)
        Me.tabReport.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region " Common private functions "
    Private Sub LoadCFAccount(ByVal pv_strACCTNO As String)
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            If Not ContactsGrid Is Nothing And Len(pv_strACCTNO) > 0 Then
                AccountGrid.DataRows.Clear()
                Dim v_strSQL As String = "SELECT DISTINCT AFACCTNO,  MST.MODCODE, MST.SYMBOL, MST.ACCTNO, MST.AVLBAL " & _
                    "FROM V_CFCONTRACT MST, ALLCODE CD WHERE " & _
                    " ((MST.MODCODE = 'SE' AND MST.AVLBAL > 0) OR (MST.MODCODE = 'CI')) AND CD.CDTYPE='CF' AND CD.CDNAME='LINKTYPE' AND CD.CDVAL=MST.LINKTYPE AND TRIM(MST.AFACCTNO)='" & pv_strACCTNO & "' " & _
                    "ORDER BY AFACCTNO, MODCODE "

                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, MyBase.LocalObject, gc_MsgTypeObj, "CF.CFMAST", _
                    gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                FillDataGrid(AccountGrid, v_strObjMsg, "")
                mv_blnRefreshTabPage_Accounts = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_ws = Nothing
        End Try
    End Sub

    Overrides Sub LoadUserInterface(ByRef pv_ctrl As Windows.Forms.Control)
        MyBase.LoadUserInterface(pv_ctrl)

        Dim v_strCmdSQL, v_strObjMsg As String
        Dim v_intIndex As Integer
        Dim v_ws As New BDSDeliveryManagement, v_cboData As ComboBoxEx
        v_strCmdSQL = "SELECT  CDVAL VALUECD, CDVAL VALUE, CDCONTENT DISPLAY FROM ALLCODE WHERE CDTYPE = 'SY' AND CDNAME = 'YESNO' ORDER BY LSTODR"
        If Len(txtCUSTID.Text) = 10 Then
            GetCustomerInfor(txtCUSTID.Text)
            lblCUSTNAME.Text = v_strCustInfor
            Me.txtCUSTODYCD.Text = v_strCUSTODYCD
            ' neu truong luu ki tai dau da co ja tri. Disable truong do
            If (v_strCUSTATCOM.Length > 0) Then
                Me.cboCUSTATCOM.Enabled = False
                v_strCmdSQL = "SELECT  CDVAL VALUECD, CDVAL VALUE, CDCONTENT DISPLAY FROM ALLCODE WHERE CDTYPE = 'SY' AND CDNAME = 'YESNO' AND CDVAL= '" & v_strCUSTATCOM & "'"

            End If
        End If

        ' fill gia tri cho CUSTATCOM
        'Nap du lieu cho ComboBox

        If v_strCmdSQL.Trim.Length > 0 Then
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            FillComboEx(v_strObjMsg, Me.cboCUSTATCOM, "", Me.UserLanguage)
        End If


        'Sï¿½á»­a chá»— nÃ y cho tá»«ng form maintenance khÃ¡c nhau
        Me.cboSTATUS.Enabled = False
        If (ExeFlag = ExecuteFlag.AddNew) Then
            'VanNT
            Me.cboLink.Enabled = False
            Me.txtACCTNO.Text = Me.BranchId

            ' disable cac tab khac khi them moi
            Me.btnADDCM.Enabled = False
            Me.btnVIEWCM.Enabled = False
            Me.btnEDITCM.Enabled = False
            Me.btnDELCM.Enabled = False


            Me.btnEADD.Enabled = False
            Me.btnEVIEW.Enabled = False
            Me.btnEEDIT.Enabled = False
            Me.btnEDEL.Enabled = False

            Me.btnAADD.Enabled = False
            Me.btnAVIEW.Enabled = False
            Me.btnAEDIT.Enabled = False
            Me.btnADEL.Enabled = False


            Me.btnTXADD.Enabled = False
            Me.btnTXVIEW.Enabled = False
            Me.btnTXEDIT.Enabled = False
            Me.btnTXDEL.Enabled = False

            Me.btnASADD.Enabled = False
            Me.btnASVIEW.Enabled = False
            Me.btnASEDIT.Enabled = False
            Me.btnASDEL.Enabled = False

            Me.btnOTADD.Enabled = False
            Me.btnOTVIEW.Enabled = False
            Me.btnOTEDIT.Enabled = False
            Me.btnOTDEL.Enabled = False

            Me.btnAddTemplate.Enabled = False
            Me.btnEditTemplate.Enabled = False
            Me.btnViewTemplate.Enabled = False
            Me.btnDeleteTemplate.Enabled = False

            Me.btnRPTADD.Enabled = False
            Me.btnRPTVIEW.Enabled = False
            Me.btnRPTEDIT.Enabled = False
            Me.btnRPTDEL.Enabled = False



        ElseIf ExeFlag = ExecuteFlag.View Or ExeFlag = ExecuteFlag.Approve Then
            'Disable some tab if current user not care this customer

            If TellerId <> ADMIN_ID Then
                If ExeFlag = ExecuteFlag.View Or ExeFlag = ExecuteFlag.Approve Then
                    Dim v_strCareBy, v_arrGroupCareBy(), v_arrGroup(), v_strGroupId As String
                    If Trim(GroupCareBy) <> String.Empty Then
                        v_arrGroupCareBy = GroupCareBy.Split("#")
                        If v_arrGroupCareBy.Length > 1 Then
                            Dim v_blnOK As Boolean = False
                            For i As Integer = 0 To v_arrGroupCareBy.Length - 2
                                v_arrGroup = CStr(v_arrGroupCareBy(i)).Split("|")
                                v_strGroupId = v_arrGroup(0)
                                If Trim(mv_strCareBy) <> Trim(v_strGroupId) Then
                                    v_blnOK = False
                                Else
                                    v_blnOK = True
                                    Exit For
                                End If
                            Next
                            If v_blnOK = False Then
                                tabSevice.Dispose()
                                tabACCOUNT.Dispose()
                            End If
                        End If
                    Else
                        tabSevice.Dispose()
                        tabACCOUNT.Dispose()
                    End If
                End If
            End If
            btnCADD.Enabled = False
            btnCEDIT.Enabled = False
            btnCDEL.Enabled = False
            btnAADD.Enabled = False
            btnAEDIT.Enabled = False
            'btnADEL.Enabled = False
            Me.btnGenContractNo.Enabled = False

            'Disable mot so items theo y/c
            txtCUSTODYCD.Enabled = False
            cboCONSULTANT.Enabled = False
            cboISOTC.Enabled = False
            cboAFTYPE.Enabled = False
            cboTERMOFUSE.Enabled = False
            cboVIA.Enabled = False
            cboTRADEFLOOR.Enabled = False
            cboTRADEONLINE.Enabled = False
            cboTRADETELEPHONE.Enabled = False
            cboETS.Enabled = False
            btnGenCustodyCD.Enabled = False
            btnGenContractNo.Enabled = False
            cboAUTOADV.Enabled = False

            btnOTADD.Enabled = False
            btnOTEDIT.Enabled = False
            btnOTDEL.Enabled = False

        ElseIf ExeFlag = ExecuteFlag.Edit Then
            ' enable cac tab khi chuyen sang edit

            ' disable cac tab khac khi them moi
            Me.btnADDCM.Enabled = True
            Me.btnVIEWCM.Enabled = True
            Me.btnEDITCM.Enabled = True
            Me.btnDELCM.Enabled = True


            Me.btnEADD.Enabled = True
            Me.btnEVIEW.Enabled = True
            Me.btnEEDIT.Enabled = True
            Me.btnEDEL.Enabled = True

            Me.btnAADD.Enabled = True
            Me.btnAVIEW.Enabled = True
            Me.btnAEDIT.Enabled = True
            Me.btnADEL.Enabled = True


            Me.btnTXADD.Enabled = True
            Me.btnTXVIEW.Enabled = True
            Me.btnTXEDIT.Enabled = True
            Me.btnTXDEL.Enabled = True

            Me.btnASADD.Enabled = True
            Me.btnASVIEW.Enabled = True
            Me.btnASEDIT.Enabled = True
            Me.btnASDEL.Enabled = True

            Me.btnOTADD.Enabled = True
            Me.btnOTVIEW.Enabled = True
            Me.btnOTEDIT.Enabled = True
            Me.btnOTDEL.Enabled = True

            Me.btnAddTemplate.Enabled = True
            Me.btnEditTemplate.Enabled = True
            Me.btnViewTemplate.Enabled = True
            Me.btnDeleteTemplate.Enabled = True

            Me.btnRPTADD.Enabled = True
            Me.btnRPTVIEW.Enabled = True
            Me.btnRPTEDIT.Enabled = True
            Me.btnRPTDEL.Enabled = True


            'SNG257: cho phep sua ma loai hinh khi edit.
            'Me.txtACTYPE.Enabled = False
            Me.cboISOTC.Enabled = False
            If Me.cboSTATUS.SelectedValue = "R" Then
                Me.btnOK.Enabled = False
                Me.btnApply.Enabled = False
            End If
            If Me.cboSTATUS.SelectedValue = "A" Then
                Me.cboCONSULTANT.Enabled = False
                Me.cboTERMOFUSE.Enabled = False
                Me.cboTRADEFLOOR.Enabled = False
                Me.cboTRADEONLINE.Enabled = True
                Me.txtCFTELELIMIT.Enabled = False
                Me.txtCFONLINELIMIT.Enabled = False
                Me.txtTRADEPHONE.Enabled = True
                Me.txtPHONE1.Enabled = True
                Me.txtPIN.Enabled = True
            End If
        End If
        'Tam thoi an tab thong tin dich vu Online Trading
        'tabOTRIGHT.Dispose()
        'LoadOTRightAsgn(txtACCTNO.Text)
    End Sub

    Public Sub LoadScreen(ByVal strTLTXCD As String, _
                  Optional ByVal v_blnChain As Boolean = False, _
                  Optional ByVal v_blnData As Boolean = False, _
                  Optional ByVal v_strXML As String = vbNullString)
        Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode
        Dim v_strValue, v_strFLDNAME As String, i, j, m, n As Integer, v_objField As CFieldMaster, v_objFieldVal As CFieldVal
        Dim v_strFieldName, v_strDefName, v_strCaption, v_strFldType, v_strFldMask, v_strFldFormat, _
            v_strLList, v_strLChk, v_strDefVal, v_strAmtExp, v_strValidTag, v_strLookUp, v_strDataType, _
            v_strChainName, v_strLookupName, v_strPrintInfo, v_strInvName, v_strFldSource, v_strFldDesc, v_strSearchCode, v_strSrModCode As String
        Dim v_intOdrNum, v_intFldLen, v_intIndex As Integer
        Dim v_blnVisible, v_blnEnabled, v_blnMandatory As Boolean
        Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            'Create message to inquiry object fields
            Dim v_strSQL, v_strClause, v_strObjMsg As String
            If Len(v_strXML) > 0 Then
                v_xmlDocumentData.LoadXml(v_strXML)
            End If
            'Lay thong tin chung ve giao dich
            If Len(Me.ModuleCode) > 0 Then
                v_strSQL = "SELECT TX.* FROM TLTX TX, APPMODULES APP WHERE SUBSTR(TX.TLTXCD,1,2)=APP.TXCODE " _
                    & "AND UPPER(TX.TLTXCD) = '" & strTLTXCD & "' " _
                    & "AND UPPER(APP.MODCODE) = '" & Me.ModuleCode & "' "
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLTX, gc_ActionInquiry, v_strSQL)
            Else
                v_strClause = "upper(TLTXCD) = '" & strTLTXCD & "'"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLTX, gc_ActionInquiry, , v_strClause)
            End If
            v_ws.Message(v_strObjMsg)

            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            If v_nodeList.Count = 0 Then
                'Neu khong ton tai ma giao dich
                MessageBox.Show(ResourceManager.GetString("ERR_TLTXCD_NOTFOUND"))
                Exit Sub
            End If
            For i = 0 To v_nodeList.Count - 1
                For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "TXDESC"
                                If UserLanguage <> "EN" Then
                                    Me.Text = Trim(v_strValue)
                                End If
                            Case "EN_TXDESC"
                                If UserLanguage = "EN" Then
                                    Me.Text = Trim(v_strValue)
                                End If
                            Case "ACCTENTRY"
                                If v_strValue = "Y" Then
                                    mv_blnAcctEntry = True
                                Else
                                    mv_blnAcctEntry = False
                                End If
                            Case "BGCOLOR"

                        End Select

                    End With
                Next
            Next

            'Láº¥y thÃ´ng tin chi tiáº¿t cÃ¡c trÆ°?ng cï¿½á»§a giao dá»‹ch
            v_strClause = "upper(OBJNAME) = '" & strTLTXCD & "' ORDER BY ODRNUM"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_FLDMASTER, gc_ActionInquiry, , v_strClause)
            v_ws.Message(v_strObjMsg)

            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            ReDim mv_arrObjFields(v_nodeList.Count)

            For i = 0 To v_nodeList.Count - 1
                For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)

                        Select Case Trim(v_strFLDNAME)
                            Case "FLDNAME"
                                v_strFieldName = Trim(v_strValue)
                            Case "DEFNAME"
                                v_strDefName = Trim(v_strValue)
                            Case "CAPTION"
                                If UserLanguage <> "EN" Then
                                    v_strCaption = Trim(v_strValue)
                                End If
                            Case "EN_CAPTION"
                                If UserLanguage = "EN" Then
                                    v_strCaption = Trim(v_strValue)
                                End If
                            Case "ODRNUM"
                                v_intOdrNum = CInt(Trim(v_strValue))
                            Case "FLDTYPE"
                                v_strFldType = Trim(v_strValue)
                            Case "FLDMASK"
                                v_strFldMask = Trim(v_strValue)
                            Case "FLDFORMAT"
                                v_strFldFormat = Trim(v_strValue)
                            Case "FLDLEN"
                                v_intFldLen = CInt(Trim(v_strValue))
                            Case "LLIST"
                                v_strLList = Trim(v_strValue)
                            Case "LCHK"
                                v_strLChk = Trim(v_strValue)
                            Case "DEFVAL"
                                v_strDefVal = Trim(v_strValue)
                            Case "VISIBLE"
                                v_blnVisible = (Trim(v_strValue) = "Y")
                            Case "DISABLE"
                                v_blnEnabled = (Trim(v_strValue) = "N")
                            Case "MANDATORY"
                                v_blnMandatory = (Trim(v_strValue) = "Y")
                            Case "AMTEXP"
                                v_strAmtExp = Trim(v_strValue)
                            Case "VALIDTAG"
                                v_strValidTag = Trim(v_strValue)
                            Case "LOOKUP"
                                v_strLookUp = Trim(v_strValue)
                            Case "DATATYPE"
                                v_strDataType = Trim(v_strValue)
                            Case "INVNAME"
                                v_strInvName = Trim(v_strValue)
                            Case "FLDSOURCE"
                                v_strFldSource = Trim(v_strValue)
                            Case "FLDDESC"
                                v_strFldDesc = Trim(v_strValue)
                            Case "CHAINNAME"
                                v_strChainName = Trim(v_strValue)
                            Case "LOOKUPNAME"
                                v_strLookupName = Trim(v_strValue)
                            Case "SEARCHCODE"
                                v_strSearchCode = Trim(v_strValue)
                            Case "SRMODCODE"
                                v_strSrModCode = Trim(v_strValue)
                            Case "PRINTINFO"
                                v_strPrintInfo = v_strValue 'KhÃ´ng Ä‘Æ°á»£c trim vÃ¬ Ä‘á»™ dÃ i báº¯t buá»™c 10 kÃ½ tá»±
                        End Select
                    End With
                Next

                v_objField = New CFieldMaster
                With v_objField
                    .FieldName = v_strFieldName
                    .ColumnName = v_strDefName
                    .Caption = v_strCaption
                    .DisplayOrder = v_intOdrNum
                    .FieldType = v_strFldType
                    .InputMask = v_strFldMask
                    .FieldFormat = v_strFldFormat
                    .FieldLength = v_intFldLen
                    .LookupList = v_strLList
                    .LookupCheck = v_strLChk
                    .LookupName = v_strLookupName
                    If v_strDefName = "DESC" And Len(v_strDefVal) = 0 Then
                        'Xá»­ lÃ½ cho trÆ°?ng Description
                        v_strDefVal = Me.Text
                    ElseIf v_strDefVal = "<$BUSDATE>" Then
                        'Lï¿½áº¥y ngÃ y lÃ m viá»‡c hiá»‡n táº¡i
                        v_strDefVal = Me.BusDate
                    End If
                    If v_blnChain Then
                        'Náº¿u giao dá»‹ch Ä‘Æ°á»£c náº¡p qua giao dá»‹ch tra cá»©u
                        If Len(v_strChainName) > 0 Then
                            'Náº¿u trÆ°?ng nï¿½Ã y cÃ³ sá»­ dá»¥ng CHAINNAME Ä‘á»ƒ láº¥y giÃ¡ trá»‹ tá»« mÃ n hÃ¬nh tra cá»©u
                            v_nodetxData = v_xmlDocumentData.SelectSingleNode("TransactMessage/ObjData/entry[@fldname='" & v_strChainName & "']")
                            If Not v_nodetxData Is Nothing Then
                                v_strDefVal = Trim(v_nodetxData.InnerText)
                            End If
                        End If
                    ElseIf v_blnData Then
                        'Náº¿u giao dá»‹ch cÃ³ dá»¯ liá»‡u (xem chi tiáº¿t)
                    End If
                    .DefaultValue = v_strDefVal
                    .Visible = v_blnVisible
                    .Enabled = v_blnEnabled
                    .Mandatory = v_blnMandatory
                    .AmtExp = v_strAmtExp
                    .ValidTag = v_strValidTag
                    .LookUp = v_strLookUp
                    .DataType = v_strDataType
                    .InvName = v_strInvName
                    .FldSource = v_strFldSource
                    .FldDesc = v_strFldDesc
                    .PrintInfo = v_strPrintInfo
                    .SearchCode = v_strSearchCode
                    .SrModCode = v_strSrModCode
                    .FieldValue = String.Empty
                End With
                mv_arrObjFields(i) = v_objField
            Next
            ReDim Preserve mv_arrObjFields(v_nodeList.Count)

            'Láº¥y cÃ¡c luáº­t kiá»ƒm tra cá»§a cÃ¡c trÆ°?ng giao dï¿½á»‹ch
            v_strClause = "SELECT FLDNAME, VALTYPE, OPERATOR, VALEXP, VALEXP2, ERRMSG, EN_ERRMSG FROM FLDVAL " & _
                "WHERE upper(OBJNAME) = '" & strTLTXCD & "' ORDER BY VALTYPE, FLDNAME, ODRNUM" 'Thá»© tá»± order by lÃ  quan tr?ng khï¿½Ã´ng sá»­a
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_FLDVAL, gc_ActionInquiry, v_strClause)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            ReDim mv_arrObjFldVals(v_nodeList.Count)
            Dim v_strFieldVal_ObjName, v_strFieldVal_FldName, v_strFieldVal_ValType, v_strFieldVal_Operator, _
                v_strFieldVal_ValExp, v_strFieldVal_ValExp2, v_strFieldVal_ErrMsg, v_strFieldVal_EnErrMsg As String

            For i = 0 To v_nodeList.Count - 1
                For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        'Ghi nháº­n thuáº­t toÃ¡n Ä‘á»ƒ kiá»ƒm tra vÃ  tÃ­nh toÃ¡n cho tá»«ng trÆ°?ng cï¿½á»§a giao dá»‹ch
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "FLDNAME"
                                v_strFieldVal_FldName = Trim(v_strValue)
                            Case "VALTYPE"
                                v_strFieldVal_ValType = Trim(v_strValue)
                            Case "OPERATOR"
                                v_strFieldVal_Operator = Trim(v_strValue)
                            Case "VALEXP"
                                v_strFieldVal_ValExp = Trim(v_strValue)
                            Case "VALEXP2"
                                v_strFieldVal_ValExp2 = Trim(v_strValue)
                            Case "ERRMSG"
                                v_strFieldVal_ErrMsg = Trim(v_strValue)
                            Case "EN_ERRMSG"
                                v_strFieldVal_EnErrMsg = Trim(v_strValue)
                        End Select
                    End With
                Next

                'XÃ¡c Ä‘á»‹nh index cá»§a máº£ng FldMaster
                For j = 0 To mv_arrObjFields.GetLength(0) - 1 Step 1
                    If Not mv_arrObjFields(j) Is Nothing Then
                        If Trim(mv_arrObjFields(j).FieldName) = Trim(v_strFieldVal_FldName) Then
                            v_intIndex = j
                        End If
                    End If
                Next
                '?iï¿½?u kiï¿½á»‡n xá»­ lÃ½
                v_objFieldVal = New CFieldVal
                With v_objFieldVal
                    .OBJNAME = strTLTXCD
                    .FLDNAME = v_strFieldVal_FldName
                    .VALTYPE = v_strFieldVal_ValType
                    .[OPERATOR] = v_strFieldVal_Operator
                    .VALEXP = v_strFieldVal_ValExp
                    .VALEXP2 = v_strFieldVal_ValExp2
                    .ERRMSG = v_strFieldVal_ErrMsg
                    .EN_ERRMSG = v_strFieldVal_EnErrMsg
                    .IDXFLD = v_intIndex
                End With
                mv_arrObjFldVals(i) = v_objFieldVal
            Next
            ReDim Preserve mv_arrObjFldVals(v_nodeList.Count)

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_xmlDocument = Nothing
            v_xmlDocumentData = Nothing
            v_ws = Nothing
        End Try
    End Sub

    Public Overrides Function DoDataExchange(Optional ByVal pv_blnSaved As Boolean = False) As Boolean
        Try
            If Not ControlValidation(pv_blnSaved) Then
                Return False
            End If
            Return MyBase.DoDataExchange(pv_blnSaved)
        Catch ex As Exception
            Throw ex
            Return False
        End Try
    End Function

    Protected Overrides Sub ShowLinkForm()
        mv_frmSearchScreen = New frmSearchMaster(Me.UserLanguage)
        MyBase.ShowLinkForm()
    End Sub

    Private Sub LoadTLMODCODE()
        Dim XmlDocument As New Xml.XmlDocument
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strFLDNAME, v_strValue, v_strVALUECD, v_strDISPLAY As String
            Dim v_strObjMsg As String
            Dim v_strSQL As String
            v_strSQL = "SELECT MODCODE VALUECD, MODCODE VALUE, MODNAME DISPLAY FROM APPMODULES WHERE MODCODE IN ('RP','DD','SE','OD','CI','CF') ORDER BY MODCODE"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_AFTYPE, gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)

            XmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = XmlDocument.SelectNodes("/ObjectMessage/ObjData")
            If v_nodeList.Count > 0 Then
                For i As Integer = 0 To v_nodeList.Count - 1
                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            v_strValue = .InnerText.ToString
                            Select Case Trim(v_strFLDNAME)
                                Case "VALUECD"
                                    v_strVALUECD = Trim(v_strValue)
                                Case "DISPLAY"
                                    v_strDISPLAY = Trim(v_strValue)
                            End Select
                        End With
                    Next
                    cboTLMODCODE.AddItems(v_strDISPLAY, v_strVALUECD)
                Next
            End If
        Catch ex As Exception
            Throw ex
        Finally
            XmlDocument = Nothing
            v_ws = Nothing
        End Try
    End Sub

    Private Function VerifyCareBy() As Boolean
        Try
            Dim v_strCareBy, v_strGroupId, v_strGroupName, v_arrGroupCareBy(), v_arrGroup() As String
            v_strCareBy = String.Empty
            v_strGroupId = String.Empty
            v_strGroupName = String.Empty

            If GroupCareBy <> String.Empty Then
                v_arrGroupCareBy = GroupCareBy.Split("#")

                If (ExeFlag = ExecuteFlag.AddNew) Then
                    If Not v_arrGroupCareBy Is Nothing Then
                        For i As Integer = 0 To v_arrGroupCareBy.Length - 2
                            v_arrGroup = CStr(v_arrGroupCareBy(i)).Split("|")
                            v_strGroupId = v_arrGroup(0)
                            If Trim(mv_strCareBy) = Trim(v_strGroupId) Then
                                Return True
                            End If
                        Next
                        Return False
                    Else
                        Return False
                    End If
                ElseIf (ExeFlag = ExecuteFlag.Edit) Then
                    GetCustomerInfor(Trim(txtCUSTID.Text))
                    'IIf(IsDBNull(Len(v_strPostingDate)), 0, Len(v_strPostingDate)) > 0
                    If Not v_arrGroupCareBy Is Nothing Then
                        For i As Integer = 0 To v_arrGroupCareBy.Length - 2
                            v_arrGroup = CStr(v_arrGroupCareBy(i)).Split("|")
                            v_strGroupId = v_arrGroup(0)
                            If Trim(mv_strCareBy) = Trim(v_strGroupId) Then
                                Return True
                            End If
                        Next
                        Return False
                    Else
                        Return False
                    End If
                End If
            ElseIf (ExeFlag = ExecuteFlag.View) Or (ExeFlag = ExecuteFlag.Edit) Then
                GetCustomerInfor(Trim(txtCUSTID.Text))
                If Not v_arrGroupCareBy Is Nothing Then
                    For i As Integer = 0 To v_arrGroupCareBy.Length - 2
                        v_arrGroup = CStr(v_arrGroupCareBy(i)).Split("|")
                        v_strGroupId = v_arrGroup(0)
                        If Trim(mv_strCareBy) = Trim(v_strGroupId) Then
                            Return True
                        End If
                    Next
                    Return False
                Else
                    Return False
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'Kiem tra thong tin truoc khi ghi
    Private Function VerifyCFRules(ByRef v_strTxMsg As String) As Boolean
        Dim v_xmlDocument As New Xml.XmlDocument
        Try
            Dim v_strMessage As String = String.Empty
            Dim v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
            Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode, v_intIndex As Long, i, v_intCount As Integer
            Dim v_strFLDNAME As String, v_strFLDDEFNAME As String, v_strDATATYPE As String, v_strFLDVALUE As String
            Dim v_strERRMSG, v_strENERRMSG, v_strOPERATOR, v_strVALEXP, v_strVALEXP2 As String, v_strACTYPE, v_strDESC As String
            Dim v_dtVALEXP, v_dtVALEXP2, v_dtFLDVALUE As Date, v_strCMDSQL As String
            Dim v_ctl As Control, v_attrFLDNAME As Xml.XmlAttribute, v_attrDATATYPE As Xml.XmlAttribute, v_objEval As New Evaluator


            'Táº¡o Ä‘iá»‡n giao dá»‹ch
            Select Case v_strSender
                Case "btnREFUSE"
                    v_strMessage = "Refuse contract:"
                    LoadScreen(gc_CF_REFUSECONTRACT)
                    v_strTxMsg = BuildXMLTxMsg(gc_MsgTypeTrans, gc_IsLocalMsg, gc_CF_REFUSECONTRACT, Me.BranchId, Me.TellerId, Me.IpAddress, Me.WsName, , , , , , , , , , , , , , , , , Me.BusDate)
                Case "btnREJECT"
                    v_strMessage = "Reject contract:"
                    LoadScreen(gc_CF_REJECTCONTRACT)
                    v_strTxMsg = BuildXMLTxMsg(gc_MsgTypeTrans, gc_IsLocalMsg, gc_CF_REJECTCONTRACT, Me.BranchId, Me.TellerId, Me.IpAddress, Me.WsName, , , , , , , , , , , , , , , , , Me.BusDate)
                Case "btnAPPROVE"
                    v_strMessage = "Approve contract:"
                    LoadScreen(gc_CF_APPROVECONTRACT)
                    v_strTxMsg = BuildXMLTxMsg(gc_MsgTypeTrans, gc_IsLocalMsg, gc_CF_APPROVECONTRACT, Me.BranchId, Me.TellerId, Me.IpAddress, Me.WsName, , , , , , , , , , , , , , , , , Me.BusDate)
            End Select
            v_xmlDocument.LoadXml(v_strTxMsg)
            v_dataElement = v_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "fields", "")
            If mv_arrObjFields.GetLength(0) > 0 Then
                For v_intIndex = 0 To mv_arrObjFields.GetLength(0) - 1 Step 1
                    If Not mv_arrObjFields(v_intIndex) Is Nothing Then
                        v_strFLDNAME = mv_arrObjFields(v_intIndex).FieldName
                        v_strDATATYPE = mv_arrObjFields(v_intIndex).DataType
                        Select Case Trim(v_strFLDNAME)

                            Case "03" 'AFACCTNO
                                v_strFLDVALUE = Trim(Strings.Replace(Me.txtACCTNO.Text, ".", String.Empty))
                            Case "02" ' ACTYPE
                                v_strFLDVALUE = Trim(txtACTYPE.Text)
                            Case "01" ' CUSTID
                                v_strFLDVALUE = Trim(Strings.Replace(Me.txtCUSTID.Text, ".", String.Empty))
                            Case "30" 'DESC                                              
                                v_strFLDVALUE = v_strMessage & Me.txtACCTNO.Text & ":" & Me.txtDESCRIPTION.Text
                        End Select

                        'Append entry to data node
                        v_entryNode = v_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "entry", "")

                        'Add field name
                        v_attrFLDNAME = v_xmlDocument.CreateAttribute(gc_AtributeFLDNAME)
                        v_attrFLDNAME.Value = v_strFLDNAME
                        v_entryNode.Attributes.Append(v_attrFLDNAME)

                        'Add field type
                        v_attrDATATYPE = v_xmlDocument.CreateAttribute(gc_AtributeFLDTYPE)
                        v_attrDATATYPE.Value = v_strDATATYPE
                        v_entryNode.Attributes.Append(v_attrDATATYPE)

                        'Set value
                        v_entryNode.InnerText = v_strFLDVALUE

                        v_dataElement.AppendChild(v_entryNode)

                        'Remember account field
                        If UCase(v_strFLDNAME) = "03" Then
                            Clipboard.SetDataObject(v_strFLDVALUE)
                        End If
                        v_xmlDocument.DocumentElement.AppendChild(v_dataElement)
                    End If
                Next
            End If
            v_strTxMsg = v_xmlDocument.InnerXml
            Return True
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_xmlDocument = Nothing
        End Try
    End Function

    'Ghi thong tin hop dong
    Public Sub OnSubmit()
        Dim v_strTxMsg As String, v_xmlDocument As New Xml.XmlDocument, v_attrColl As Xml.XmlAttributeCollection
        Dim v_intNOSUBMIT As Integer, v_strNEXTTX As String = String.Empty
        Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            'Control Validate
            If Not ControlValidation() Then
                Exit Sub
            End If
            MessageData = String.Empty
            If Not VerifyCFRules(v_strTxMsg) Then
                Exit Sub
            Else
                MessageData = v_strTxMsg
            End If

            If preSaveCheck() = -1 Then
                Exit Sub
            End If

            '?ï¿½áº©y Ä‘iá»‡n giao dá»‹ch lÃªn APP-SERVER
            v_strTxMsg = MessageData
            v_lngError = v_ws.Message(v_strTxMsg)
            If v_lngError <> ERR_SYSTEM_OK Then
                'ThÃ´ng bÃ¡o lá»—i
                GetErrorFromMessage(v_strTxMsg, v_strErrorSource, v_lngError, v_strErrorMessage)
                Cursor.Current = Cursors.Default
                If v_lngError <> ERR_SA_CHECKER1_OVR And v_lngError <> ERR_SA_CHECKER2_OVR Then
                    MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                    Exit Sub
                Else
                    'Láº¥y thÃªm nguyÃªn nhÃ¢n duyá»‡t
                    GetReasonFromMessage(v_strTxMsg, v_strErrorMessage, Me.UserLanguage)
                    MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                End If
            Else
                Select Case v_strSender
                    Case "btnREFUSE"
                        MsgBox(ResourceManager.GetString("RefuseSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                        Me.DialogResult = DialogResult.OK
                        MyBase.OnClose()
                    Case "btnREJECT"
                        MsgBox(ResourceManager.GetString("RejectSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                        Me.DialogResult = DialogResult.OK
                        MyBase.OnClose()
                    Case "btnAPPROVE"
                        MsgBox(ResourceManager.GetString("ApproveSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                        Me.DialogResult = DialogResult.OK
                        MyBase.OnClose()
                End Select
            End If
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_xmlDocument = Nothing
            v_ws = Nothing
        End Try
    End Sub

    Public Overrides Sub OnSave()
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strCustAtCom As String
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strClause As String
            Dim v_strErrorSource, v_strErrorMessage As String
            Dim v_lngErrorCode As Long
            Dim v_strObjMsg, v_strSQL, v_strFLDNAME, v_strVALUE, v_strNUM As String
            v_strCUSTODYCD = UCase(Replace(Trim(txtCUSTODYCD.Text), ".", ""))
            v_strNUM = "0"
            'Update mouse pointer
            'gc_ActionEdit
            'Lay thong tin tab thong tin dich vu online trading
            'TheNN, 09-Jan-2012
            'GetOTRIGHT()
            'End: TheNN 09-Jan-2012

            Select Case ExeFlag
                Case ExecuteFlag.Edit
                    If Me.cboSTATUS.SelectedValue = "E" Then
                        Me.cboSTATUS.SelectedValue = "P"
                    End If
            End Select
            Cursor.Current = Cursors.WaitCursor
            MyBase.OnSave()

            'Kiem tra du lieu
            If Not DoDataExchange(True) Then
                Exit Sub
            End If
            If Me.cboISOTC.SelectedValue = "N" Then
                If Not VerifyCustodyCodeBeforeAdd() Then
                    Exit Sub
                End If

            End If
            If (Me.cboISOTC.SelectedValue = "Y" And Trim(txtCUSTODYCD.Text) <> "") Then
                If Not VerifyCustodyCodeBeforeAdd() Then
                    Exit Sub
                End If
            End If
            'dien


            If mv_strMarginType = "T" And cboCUSTATCOM.SelectedValue <> "Y" Then
                MsgBox(ResourceManager.GetString("ACTYPE_INVALID_CUSTATCOM_MARGINTYPE"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                Me.cboCUSTATCOM.Focus()
                Exit Sub
            End If


            'Check 6 ky tu dau tien cua Trading code phai tuong tu nhu 6 ky tu cuoi cua so luu ky.
            If Len(Me.txtTRADINGCODE.Text.Trim) > 0 And Len(Me.txtCUSTODYCD.Text.Trim) > 0 Then
                If Not (Len(Me.txtCUSTODYCD.Text.Trim) >= 6 AndAlso Len(Me.txtTRADINGCODE.Text.Trim) >= 6 AndAlso Me.txtTRADINGCODE.Text.ToUpper.Substring(0, 6) = Me.txtCUSTODYCD.Text.ToUpper.Substring(Len(Me.txtCUSTODYCD.Text.Trim) - 6, 6)) Then
                    MsgBox(ResourceManager.GetString("msgCHECKTRADINGCODE"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                    Me.txtTRADINGCODE.Focus()
                    Exit Sub
                End If
            End If

            'Kiem tra dinh dang Email phai hop le
            If Trim(Me.txtEMAIL.Text).Length > 0 Then
                If InStr(Trim(Me.txtEMAIL.Text), " ") > 0 Or InStr(Trim(Me.txtEMAIL.Text), "@") <= 0 Or InStr(Mid(Trim(Me.txtEMAIL.Text), InStr(Trim(Me.txtEMAIL.Text), "@") + 1), ".") <= 0 Then
                    MsgBox(ResourceManager.GetString("msgINVALIDEMAILFORMAT"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                    Me.txtEMAIL.Focus()
                    Exit Sub
                End If
            End If

            If preSaveCheck() = -1 Then
                Exit Sub
            End If

            Select Case ExeFlag
                Case ExecuteFlag.AddNew
                    'Kiem tra status cá»§a khÃ¡ch hÃ ng
                    'Phuong Comment theo yeu cau cua SBS
                    If mv_strCustomerStatus.Equals("C") Then
                        MsgBox(ResourceManager.GetString("CustomerStatusIsClose"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Exit Sub
                    End If
                    'Phuong end

                    'Anhvt Retro - Maintenance approval
                    'v_strObjMsg = BuildXMLObjMsg(Me.BusDate, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionAdd, , , , gc_AutoIdUnused)
                    v_strClause = KeyFieldName & " = '" & txtACCTNO.Text & "'"
                    v_strObjMsg = BuildXMLObjMsg(Me.BusDate, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionAdd, , v_strClause, , gc_AutoIdUnused)
                    BuildXMLObjData(mv_dsInput, v_strObjMsg)
                    v_lngErrorCode = v_ws.Message(v_strObjMsg)

                    'Kiá»ƒm tra thÃ´ng tin vÃ  xá»­ lÃ½ lá»—i (náº¿u cÃ³) tá»« message tráº£ v?
                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                    If v_lngErrorCode <> 0 Then
                        'Update mouse pointer
                        Cursor.Current = Cursors.Default
                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Exit Sub
                    Else
                        If v_boolean = True Then
                            UPDATECUSTODYCD()
                        End If
                        If Me.cboAPPLYPOLICY.Checked And Not (Me.cboAPPLYACCT.SelectedValue Is Nothing) Then
                            ExternalUpdate()
                        End If
                    End If
                    MsgBox(ResourceManager.GetString("AddnewSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)

                    Select Case MyBase.SaveButtonType
                        Case SaveButtonType.ApplyButton
                            KeyFieldValue = GetControlValueByName(KeyFieldName, Me)
                            ExeFlag = ExecuteFlag.Edit
                            LoadUserInterface(Me)
                            mv_dsOldInput = mv_dsInput
                        Case SaveButtonType.OKButton
                            Me.DialogResult = DialogResult.OK
                            MyBase.OnClose()
                    End Select
                Case ExecuteFlag.Edit
                    Select Case KeyFieldType
                        Case "C"
                            v_strClause = KeyFieldName & " = '" & KeyFieldValue & "'"
                        Case "D"
                            v_strClause = KeyFieldName & " = TO_DATE('" & KeyFieldValue & "', '" & gc_FORMAT_DATE & "')"
                        Case "N"
                            v_strClause = KeyFieldName & " = " & KeyFieldValue.ToString()
                    End Select

                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionEdit, , v_strClause)
                    BuildXMLObjData(mv_dsInput, v_strObjMsg, mv_dsOldInput, ExecuteFlag.Edit)
                    v_lngErrorCode = v_ws.Message(v_strObjMsg)
                    'Update truong CUSTODYCD vao CFMAST
                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                    If v_lngErrorCode <> 0 Then
                        'Update mouse pointer
                        Cursor.Current = Cursors.Default
                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Exit Sub
                    Else
                        UPDATECUSTODYCD()
                    End If

                    MsgBox(ResourceManager.GetString("EditSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    Select Case MyBase.SaveButtonType
                        Case SaveButtonType.ApplyButton
                            KeyFieldValue = GetControlValueByName(KeyFieldName, Me)
                            ExeFlag = ExecuteFlag.Edit
                            LoadUserInterface(Me)
                        Case SaveButtonType.OKButton
                            Me.DialogResult = DialogResult.OK
                            MyBase.OnClose()
                    End Select
            End Select

            'Update mouse pointer
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ResourceManager.GetString("SavingFailed"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_xmlDocument = Nothing
            v_ws = Nothing
        End Try
    End Sub

    Public Overrides Sub OnInit()
        Dim v_ctrl As Windows.Forms.Control
        Try
            MyBase.OnInit()
            ResourceManager = New Resources.ResourceManager(gc_RootNamespace & "." & Me.Name & "-" & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
            Me.txtTRADINGCODE.Text = String.Empty
            'An truong ETS
            Me.lblETS.Visible = False
            Me.cboAPPLYPOLICY.Visible = False
            Me.cboAPPLYACCT.Visible = False
            Me.cboAPPLYACCT.Clears()
            InitExternal()

            'Dien comment 19/10/2010
            If Not FillGroupCareBy() Then
                If ExeFlag = ExecuteFlag.AddNew Then
                    MsgBox(ResourceManager.GetString("NotCareByGroup"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    OnClose()
                    Exit Sub
                ElseIf ExeFlag = ExecuteFlag.Edit Then
                    MsgBox(ResourceManager.GetString("NotCareBy"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    OnClose()
                    Exit Sub
                End If
            End If
            'Dien 3end comment

            If (ExeFlag = ExecuteFlag.Edit) Or (ExeFlag = ExecuteFlag.View) Then
                If TellerId <> ADMIN_ID Then
                    'Disable some tab if user doesnt have careby right - Modified by TungNT
                    If Not GroupCareBy Is Nothing Then
                        If GroupCareBy.Length > 0 Then
                            GetCustomerInfor(txtCUSTID.Text.Trim())
                            If GroupCareBy.IndexOf(mv_strCareBy) = -1 Then
                                tabAFMAST.TabPages.Remove(tabACCOUNT)
                            End If
                        End If
                    End If
                    'End Modified
                End If
            ElseIf ExeFlag = ExecuteFlag.AddNew Then
                If TellerId <> ADMIN_ID Then
                    If Not GroupCareBy Is Nothing Then
                        If Trim(GroupCareBy) = String.Empty Then
                            MsgBox(ResourceManager.GetString("NotCareByGroup"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                            OnClose()
                            Exit Sub
                        End If
                    End If
                End If
                Me.txtOPNDATE.Text = Me.BusDate
                Me.txtBRID.Text = Me.BranchId

                Me.cboAPPLYPOLICY.Visible = True
                Me.cboAPPLYACCT.Visible = True
            End If
            LoadUserInterface(Me)

            'LoadCFContacts(Me.txtACCTNO.Text)
            'LoadCFAUTH(Me.txtACCTNO.Text)
            'LoadCFAccount(Me.txtACCTNO.Text)
            'LoadREPORT(Me.txtACCTNO.Text)
            'LoadAFExtRefer(Me.txtACCTNO.Text)
            LoadTLMODCODE()
            'LoadICCFType(Me.txtACCTNO.Text, Me.cboTLMODCODE.SelectedValue)
            'SetCUSTODYCD(Me.txtCUSTID.Text)
            If cboAFTYPE.SelectedValue = "001" Then
                btnCADD.Enabled = False
            End If

            'AnhVT Changed - Maintenance retroed
            If (ExeFlag = ExecuteFlag.Approve Or ExeFlag = ExecuteFlag.View) Then
                'Disable cac button trong cac tab
                btnAADD.Enabled = False
                btnADEL.Enabled = False
                btnAEDIT.Enabled = False

                btnADDCM.Enabled = False
                btnEDITCM.Enabled = False
                btnDELCM.Enabled = False

                btnEADD.Enabled = False
                btnEEDIT.Enabled = False
                btnEDEL.Enabled = False

                btnRPTADD.Enabled = False
                btnRPTEDIT.Enabled = False
                btnRPTDEL.Enabled = False

                btnTXADD.Enabled = False
                btnTXEDIT.Enabled = False
                btnTXDEL.Enabled = False

                'Disable mot so items theo y/c
                txtCUSTODYCD.Enabled = False
                cboCONSULTANT.Enabled = False
                cboISOTC.Enabled = False
                cboAFTYPE.Enabled = False
                cboTERMOFUSE.Enabled = False
                cboVIA.Enabled = False
                cboTRADEFLOOR.Enabled = False
                cboTRADEONLINE.Enabled = False
                cboTRADETELEPHONE.Enabled = False
                cboETS.Enabled = False
                btnGenCustodyCD.Enabled = False
                btnGenContractNo.Enabled = False
                'dien comment 2-10-2010
                cboCAREBY.Enabled = False

                'end comment
                Me.txtACCTNO.Enabled = False
                Me.txtCUSTID.Enabled = False
                Me.txtACTYPE.Enabled = False

                btnASADD.Enabled = False
                btnASEDIT.Enabled = False
                btnASDEL.Enabled = False

                btnAddTemplate.Enabled = False
                btnEditTemplate.Enabled = False
                btnDeleteTemplate.Enabled = False
            End If
            'Khong hien thi PIN nua, day PIN san CFMAST
            Me.lblPIN.Visible = False
            Me.txtPIN.Visible = False
            Me.txtBRID.Visible = False
            Me.txtOPNDATE.Visible = False

            Me.txtTRADINGCODE.Enabled = False
            Me.lblTRADINGCODE.Visible = False
            Me.txtTRADINGCODE.Visible = False

            txtTLID.Enabled = False 'Dien them

            If cboTRADETELEPHONE.SelectedValue = "Y" Then
                lblTRADEPHONE.ForeColor = System.Drawing.Color.Blue
            End If
            'hien ten user khi edit va view
            'dien them 2-10-2010
            If (ExeFlag = ExecuteFlag.Edit Or ExeFlag = ExecuteFlag.View) Then
                LoadUsernameCareby()
                If Me.cboTRADETELEPHONE.SelectedValue = "Y" Then
                    Me.txtTRADEPHONE.Enabled = True
                    Me.txtPHONE1.Enabled = True
                Else
                    Me.txtTRADEPHONE.Enabled = False
                    Me.txtPHONE1.Enabled = False

                End If
            End If
            'end comment dien
            'Enable tab Account neu sua hop dong
            If (ExeFlag = ExecuteFlag.Edit) Then
                LoadACTYPE(Me.txtACTYPE.Text, False)
                'KHONG DUOC SUA SO LUU KY.
                txtCUSTODYCD.Enabled = False
                btnGenCustodyCD.Enabled = False
            End If

            'TungNT added - Khong cho sua truong nay, se load tu aftype
            cboCOREBANK.Enabled = False
            'End
            'Disable nut xoa OTRIGHT di
            btnOTDEL.Enabled = False
            'End

            'Khong hien thi thong tin ICCF cho HD
            Me.tabICCF.Dispose()
            'Me.tabAFSERULE.Dispose()
            If (ExeFlag = ExecuteFlag.Edit) Then
                mv_strBankAcctno = txtBANKACCTNO.Text.Trim().ToUpper()
                mv_strBankCode = cboBANKNAME.SelectedValue.ToString().Trim().ToUpper()
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ResourceManager.GetString("InitDialogFailed"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    'Khoi tao cac Grid hien thi thong tin
    Private Sub InitExternal()
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            'Khá»Ÿi táº¡o Grid contacts
            ContactsGrid = New GridEx

            Dim v_cmrContactsHeader As New Xceed.Grid.ColumnManagerRow
            v_cmrContactsHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
            v_cmrContactsHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            ContactsGrid.FixedHeaderRows.Add(v_cmrContactsHeader)
            ContactsGrid.Columns.Add(New Xceed.Grid.Column("AUTOID", GetType(Integer)))
            ContactsGrid.Columns.Add(New Xceed.Grid.Column("CUSTID", GetType(System.String)))
            ContactsGrid.Columns.Add(New Xceed.Grid.Column("FULLNAME", GetType(System.String)))
            ContactsGrid.Columns.Add(New Xceed.Grid.Column("LINKTYPE", GetType(System.String)))
            ContactsGrid.Columns.Add(New Xceed.Grid.Column("DESCRIPTION", GetType(System.String)))

            ContactsGrid.Columns("AUTOID").Title = ResourceManager.GetString("grid.AUTOID")
            ContactsGrid.Columns("CUSTID").Title = ResourceManager.GetString("grid.CUSTID")
            ContactsGrid.Columns("FULLNAME").Title = ResourceManager.GetString("grid.FULLNAME")
            ContactsGrid.Columns("LINKTYPE").Title = ResourceManager.GetString("grid.LINKTYPE")
            ContactsGrid.Columns("DESCRIPTION").Title = ResourceManager.GetString("grid.DESCRIPTION")

            ContactsGrid.Columns("AUTOID").Width = 0
            ContactsGrid.Columns("AUTOID").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
            ContactsGrid.Columns("CUSTID").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            ContactsGrid.Columns("FULLNAME").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            ContactsGrid.Columns("LINKTYPE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            ContactsGrid.Columns("DESCRIPTION").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left

            pnMemberContract.Controls.Clear()
            Me.pnMemberContract.Controls.Add(ContactsGrid)
            ContactsGrid.Dock = Windows.Forms.DockStyle.Fill

            'Khá»Ÿi táº¡o Grid contacts ReportGrid 
            ReportGrid = New GridEx
            Dim v_cmrReportHeader As New Xceed.Grid.ColumnManagerRow
            v_cmrReportHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
            v_cmrReportHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            ReportGrid.FixedHeaderRows.Add(v_cmrReportHeader)
            ReportGrid.Columns.Add(New Xceed.Grid.Column("AUTOID", GetType(Integer)))
            ReportGrid.Columns.Add(New Xceed.Grid.Column("CMDCODE", GetType(System.String)))
            ReportGrid.Columns.Add(New Xceed.Grid.Column("CMDTITLE", GetType(System.String)))
            ReportGrid.Columns.Add(New Xceed.Grid.Column("EXCYCLE", GetType(System.String)))
            ReportGrid.Columns.Add(New Xceed.Grid.Column("EXPDATE", GetType(System.String)))
            ReportGrid.Columns.Add(New Xceed.Grid.Column("STATUS", GetType(System.String)))

            ReportGrid.Columns("AUTOID").Title = ResourceManager.GetString("grid.AUTOID")
            ReportGrid.Columns("CMDCODE").Title = ResourceManager.GetString("grid.CMDCODE")
            ReportGrid.Columns("CMDTITLE").Title = ResourceManager.GetString("grid.CMDTITLE")
            ReportGrid.Columns("EXCYCLE").Title = ResourceManager.GetString("grid.EXCYCLE")
            ReportGrid.Columns("EXPDATE").Title = ResourceManager.GetString("grid.EXPDATE")
            ReportGrid.Columns("STATUS").Title = ResourceManager.GetString("grid.STATUS")

            ReportGrid.Columns("AUTOID").Width = 0
            ReportGrid.Columns("CMDTITLE").Width = 250
            ReportGrid.Columns("CMDCODE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            ReportGrid.Columns("CMDTITLE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            ReportGrid.Columns("EXCYCLE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            ReportGrid.Columns("EXPDATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            ReportGrid.Columns("STATUS").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left

            Me.pnReport.Controls.Clear()
            Me.pnReport.Controls.Add(ReportGrid)
            ReportGrid.Dock = Windows.Forms.DockStyle.Fill

            'Khoi tao cho grid txmap
            TxmapGrid = New GridEx
            Dim v_cmrTxmapHeader As New Xceed.Grid.ColumnManagerRow
            v_cmrTxmapHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
            v_cmrTxmapHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            TxmapGrid.FixedHeaderRows.Add(v_cmrTxmapHeader)
            TxmapGrid.Columns.Add(New Xceed.Grid.Column("AUTOID", GetType(Integer)))
            TxmapGrid.Columns.Add(New Xceed.Grid.Column("AFACCTNO", GetType(System.String)))
            TxmapGrid.Columns.Add(New Xceed.Grid.Column("TLTXCD", GetType(System.String)))
            TxmapGrid.Columns.Add(New Xceed.Grid.Column("TXDESC", GetType(System.String)))
            TxmapGrid.Columns.Add(New Xceed.Grid.Column("EFFDATE", GetType(System.String)))
            TxmapGrid.Columns.Add(New Xceed.Grid.Column("EXPDATE", GetType(System.String)))
            TxmapGrid.Columns.Add(New Xceed.Grid.Column("TLID", GetType(System.String)))
            TxmapGrid.Columns.Add(New Xceed.Grid.Column("ACTYPE", GetType(System.String)))
            TxmapGrid.Columns.Add(New Xceed.Grid.Column("TYPENAME", GetType(System.String)))

            TxmapGrid.Columns("AUTOID").Title = ResourceManager.GetString("grid.AUTOID")
            TxmapGrid.Columns("AFACCTNO").Title = ResourceManager.GetString("grid.AFACCTNO")
            TxmapGrid.Columns("TLTXCD").Title = ResourceManager.GetString("grid.TLTXCD")
            TxmapGrid.Columns("TXDESC").Title = ResourceManager.GetString("grid.TXDESC")
            TxmapGrid.Columns("EFFDATE").Title = ResourceManager.GetString("grid.EFFDATE")
            TxmapGrid.Columns("EXPDATE").Title = ResourceManager.GetString("grid.EXPDATE")
            TxmapGrid.Columns("TLID").Title = ResourceManager.GetString("grid.TLID")
            TxmapGrid.Columns("ACTYPE").Title = ResourceManager.GetString("grid.ACTYPE")
            TxmapGrid.Columns("TYPENAME").Title = ResourceManager.GetString("grid.TYPENAME")

            TxmapGrid.Columns("AUTOID").Width = 0
            TxmapGrid.Columns("TXDESC").Width = 250
            TxmapGrid.Columns("TLTXCD").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            TxmapGrid.Columns("AFACCTNO").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            TxmapGrid.Columns("TXDESC").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            TxmapGrid.Columns("EFFDATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            TxmapGrid.Columns("EXPDATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            TxmapGrid.Columns("TLID").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            TxmapGrid.Columns("ACTYPE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            TxmapGrid.Columns("TYPENAME").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left

            Me.pnTxmap.Controls.Clear()
            Me.pnTxmap.Controls.Add(TxmapGrid)
            TxmapGrid.Dock = Windows.Forms.DockStyle.Fill

            ' Khoi tao ACCOUNT
            AccountGrid = New GridEx
            Dim v_cmrAccountsHeader As New Xceed.Grid.ColumnManagerRow
            v_cmrAccountsHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
            v_cmrAccountsHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            AccountGrid.FixedHeaderRows.Add(v_cmrAccountsHeader)
            'AccountGrid.Columns.Add(New Xceed.Grid.Column("AFACCTNO", GetType(System.String)))

            AccountGrid.Columns.Add(New Xceed.Grid.Column("ACCTNO", GetType(System.String)))
            'AccountGrid.Columns.Add(New Xceed.Grid.Column("LINKTYPE", GetType(System.String)))
            AccountGrid.Columns.Add(New Xceed.Grid.Column("MODCODE", GetType(System.String)))
            AccountGrid.Columns.Add(New Xceed.Grid.Column("SYMBOL", GetType(System.String)))
            AccountGrid.Columns.Add(New Xceed.Grid.Column("AVLBAL", GetType(System.Double)))
            AccountGrid.Columns("AVLBAL").FormatSpecifier = "#,##0"

            'AccountGrid.Columns("AFACCTNO").Title = ResourceManager.GetString("grid.AFACCTNO")

            AccountGrid.Columns("ACCTNO").Title = ResourceManager.GetString("grid.ACCTNO")
            'AccountGrid.Columns("LINKTYPE").Title = ResourceManager.GetString("grid.LINKTYPE")
            AccountGrid.Columns("MODCODE").Title = ResourceManager.GetString("grid.MODCODE")
            AccountGrid.Columns("SYMBOL").Title = ResourceManager.GetString("grid.SYMBOL")
            AccountGrid.Columns("AVLBAL").Title = ResourceManager.GetString("grid.AVLBAL")


            pnACCOUNT.Controls.Clear()
            pnACCOUNT.Controls.Add(AccountGrid)
            AccountGrid.Dock = Windows.Forms.DockStyle.Fill
            '--namnt
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_int, v_intCount As Integer
            Dim v_strCDCONTENT, v_strCDVAL As String
            Dim v_strFLDNAME, v_strVALUE As String


            Dim v_strCmdInquiry As String = "select CDVAL,CDCONTENT from allcode where cdname = 'LINKAUTH'  order by LSTODR"
            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, "SA.ALLCODE", gc_ActionInquiry, v_strCmdInquiry)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            ContactsGrid.Dock = Windows.Forms.DockStyle.Fill

            For v_intCount = 0 To v_nodeList.Count - 1
                For v_int = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                    With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                        v_strFLDNAME = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("fldname").Value.Trim()
                        v_strVALUE = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("oldval").Value.Trim()

                        Select Case v_strFLDNAME
                            Case "CDCONTENT"
                                v_strCDCONTENT = v_strVALUE
                            Case "CDVAL"
                                v_strCDVAL = "CKB" & v_strVALUE

                        End Select
                    End With
                Next
                ContactsGrid.Columns.Add(New Xceed.Grid.Column(v_strCDVAL, GetType(System.String)))
                ContactsGrid.Columns(v_strCDVAL).Title = v_strCDCONTENT
            Next

            '  Khá»Ÿi táº¡o Grid AnthorizeGrid
            AnthorizeGrid = New GridEx
            Dim v_cmrRelationHeader As New Xceed.Grid.ColumnManagerRow
            v_cmrRelationHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
            v_cmrRelationHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            AnthorizeGrid.FixedHeaderRows.Add(v_cmrRelationHeader)
            AnthorizeGrid.Columns.Add(New Xceed.Grid.Column("AUTOID", GetType(Integer)))
            AnthorizeGrid.Columns.Add(New Xceed.Grid.Column("CUSTID", GetType(System.String)))
            AnthorizeGrid.Columns.Add(New Xceed.Grid.Column("FULLNAME", GetType(System.String)))
            AnthorizeGrid.Columns.Add(New Xceed.Grid.Column("LICENSENO", GetType(System.String)))
            AnthorizeGrid.Columns.Add(New Xceed.Grid.Column("ADDRESS", GetType(System.String)))
            AnthorizeGrid.Columns.Add(New Xceed.Grid.Column("TELEPHONE", GetType(System.String)))
            AnthorizeGrid.Columns.Add(New Xceed.Grid.Column("VALDATE", GetType(System.String)))
            AnthorizeGrid.Columns.Add(New Xceed.Grid.Column("EXPDATE", GetType(System.String)))
            AnthorizeGrid.Columns.Add(New Xceed.Grid.Column("LNPLACE", GetType(System.String)))
            AnthorizeGrid.Columns.Add(New Xceed.Grid.Column("LNIDDATE", GetType(System.String)))
            AnthorizeGrid.Columns.Add(New Xceed.Grid.Column("DELTDCH", GetType(System.String)))
            AnthorizeGrid.Columns.Add(New Xceed.Grid.Column("DELTD", GetType(System.String)))
            'Tantv thêm trường trạng thái

            AnthorizeGrid.Columns("AUTOID").Title = ResourceManager.GetString("grid.AUTOID")
            AnthorizeGrid.Columns("CUSTID").Title = ResourceManager.GetString("grid.CUSTID")
            AnthorizeGrid.Columns("FULLNAME").Title = ResourceManager.GetString("grid.FULLNAME")
            AnthorizeGrid.Columns("LICENSENO").Title = ResourceManager.GetString("grid.LICENSENO")
            AnthorizeGrid.Columns("ADDRESS").Title = ResourceManager.GetString("grid.ADDRESS")
            AnthorizeGrid.Columns("TELEPHONE").Title = ResourceManager.GetString("grid.TELEPHONE")
            AnthorizeGrid.Columns("VALDATE").Title = ResourceManager.GetString("grid.VALDATE")
            AnthorizeGrid.Columns("EXPDATE").Title = ResourceManager.GetString("grid.EXPDATE")
            AnthorizeGrid.Columns("LNPLACE").Title = ResourceManager.GetString("grid.LNPLACE")
            AnthorizeGrid.Columns("LNIDDATE").Title = ResourceManager.GetString("grid.LNIDDATE")
            AnthorizeGrid.Columns("DELTDCH").Title = ResourceManager.GetString("grid.DELTDCH")
            'Tantv thêm trường trạng thái

            AnthorizeGrid.Columns("AUTOID").Width = 0
            AnthorizeGrid.Columns("CUSTID").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
            AnthorizeGrid.Columns("FULLNAME").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            AnthorizeGrid.Columns("LICENSENO").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            AnthorizeGrid.Columns("ADDRESS").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            AnthorizeGrid.Columns("TELEPHONE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            AnthorizeGrid.Columns("VALDATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            AnthorizeGrid.Columns("EXPDATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            'AnthorizeGrid.Columns("LNDATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            AnthorizeGrid.Columns("LNPLACE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            AnthorizeGrid.Columns("DELTD").Visible = False

            Me.pnAnthorize.Controls.Clear()
            Me.pnAnthorize.Controls.Add(AnthorizeGrid)
            AnthorizeGrid.Dock = Windows.Forms.DockStyle.Fill
            If Me.AnthorizeGrid.DataRowTemplate.Cells.Count >= 0 Then
                For i As Integer = 0 To Me.AnthorizeGrid.DataRowTemplate.Cells.Count - 1
                    AddHandler AnthorizeGrid.DataRowTemplate.Cells(i).Click, AddressOf AnthorizeGrid_Click
                Next
            End If

            ' Khoi tao ExtCIGrid
            ExtCIGrid = New GridEx
            Dim v_cmrExtReferHeader As New Xceed.Grid.ColumnManagerRow
            v_cmrExtReferHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
            v_cmrExtReferHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            ExtCIGrid.FixedHeaderRows.Add(v_cmrExtReferHeader)


            ExtCIGrid.Columns.Add(New Xceed.Grid.Column("AUTOID", GetType(Integer)))
            ExtCIGrid.Columns("AUTOID").Width = 0
            ExtCIGrid.Columns.Add(New Xceed.Grid.Column("CIACCOUNT", GetType(System.String)))
            ExtCIGrid.Columns("CIACCOUNT").Title = ResourceManager.GetString("grid.CIACCOUNT")

            ExtCIGrid.Columns.Add(New Xceed.Grid.Column("CINAME", GetType(System.String)))
            ExtCIGrid.Columns("CINAME").Title = ResourceManager.GetString("grid.CINAME")

            ExtCIGrid.Size = New System.Drawing.Size(220, 167)
            pnExtRefer.Controls.Clear()
            pnExtRefer.Controls.Add(ExtCIGrid)
            ExtCIGrid.Dock = Windows.Forms.DockStyle.Left

            AddHandler ExtCIGrid.DoubleClick, AddressOf ExtCIGrid_Click
            If Me.ExtCIGrid.DataRowTemplate.Cells.Count >= 0 Then
                For i As Integer = 0 To Me.ExtCIGrid.DataRowTemplate.Cells.Count - 1
                    AddHandler ExtCIGrid.DataRowTemplate.Cells(i).DoubleClick, AddressOf ExtCIGrid_Click
                Next
            End If

            'Khoi tao ExtBankAccGrid
            ExtBankAccGrid = New GridEx
            Dim v_cmrExtBankHeader As New Xceed.Grid.ColumnManagerRow
            v_cmrExtBankHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
            v_cmrExtBankHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            ExtBankAccGrid.FixedHeaderRows.Add(v_cmrExtBankHeader)

            ExtBankAccGrid.Columns.Add(New Xceed.Grid.Column("AUTOID", GetType(Integer)))
            ExtBankAccGrid.Columns("AUTOID").Width = 0
            ExtBankAccGrid.Columns.Add(New Xceed.Grid.Column("CUSTID", GetType(System.String)))
            ExtBankAccGrid.Columns.Add(New Xceed.Grid.Column("BANKACC", GetType(System.String)))
            ExtBankAccGrid.Columns.Add(New Xceed.Grid.Column("BANKACNAME", GetType(System.String)))
            ExtBankAccGrid.Columns.Add(New Xceed.Grid.Column("BANKNAME", GetType(System.String)))

            ExtBankAccGrid.Columns.Add(New Xceed.Grid.Column("ACNIDCODE", GetType(System.String)))
            ExtBankAccGrid.Columns.Add(New Xceed.Grid.Column("ACNIDDATE", GetType(System.String)))
            ExtBankAccGrid.Columns.Add(New Xceed.Grid.Column("ACNIDPLACE", GetType(System.String)))
            ExtBankAccGrid.Columns.Add(New Xceed.Grid.Column("CITYEF", GetType(System.String)))
            ExtBankAccGrid.Columns.Add(New Xceed.Grid.Column("CITYBANK", GetType(System.String)))

            ExtBankAccGrid.Columns("CUSTID").Title = ResourceManager.GetString("grid.CUSTID")
            ExtBankAccGrid.Columns("BANKACC").Title = ResourceManager.GetString("grid.BANKACC")
            ExtBankAccGrid.Columns("BANKACNAME").Title = ResourceManager.GetString("grid.BANKACNAME")
            ExtBankAccGrid.Columns("BANKNAME").Title = ResourceManager.GetString("grid.BANKNAME")
            ExtBankAccGrid.Columns("ACNIDCODE").Title = ResourceManager.GetString("grid.ACNIDCODE")
            ExtBankAccGrid.Columns("ACNIDDATE").Title = ResourceManager.GetString("grid.ACNIDDATE")
            ExtBankAccGrid.Columns("ACNIDPLACE").Title = ResourceManager.GetString("grid.ACNIDPLACE")
            ExtBankAccGrid.Columns("CITYEF").Title = ResourceManager.GetString("grid.CITYEF")
            ExtBankAccGrid.Columns("CITYBANK").Title = ResourceManager.GetString("grid.CITYBANK")

            ExtBankAccGrid.Size = New System.Drawing.Size(364, 160)
            'pnExtRefer.Controls.Clear()
            pnExtRefer.Controls.Add(ExtBankAccGrid)
            ExtBankAccGrid.Dock = Windows.Forms.DockStyle.Right

            AddHandler ExtBankAccGrid.DoubleClick, AddressOf ExtBankAccGrid_Click
            If Me.ExtBankAccGrid.DataRowTemplate.Cells.Count >= 0 Then
                For i As Integer = 0 To Me.ExtBankAccGrid.DataRowTemplate.Cells.Count - 1
                    AddHandler ExtBankAccGrid.DataRowTemplate.Cells(i).DoubleClick, AddressOf ExtBankAccGrid_Click
                Next
            End If

            'Khoi tao ICCF Grid
            ICCFTYPEDEF_Grid = New GridEx
            Dim v_cmrMemberHeader_ICCF As New Xceed.Grid.ColumnManagerRow
            v_cmrMemberHeader_ICCF.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
            v_cmrMemberHeader_ICCF.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)

            ICCFTYPEDEF_Grid.FixedHeaderRows.Add(v_cmrMemberHeader_ICCF)
            ICCFTYPEDEF_Grid.Columns.Add(New Xceed.Grid.Column("AUTOID", GetType(System.String)))
            ICCFTYPEDEF_Grid.Columns.Add(New Xceed.Grid.Column("ACTYPE", GetType(System.String)))
            ICCFTYPEDEF_Grid.Columns.Add(New Xceed.Grid.Column("DESC_ICCFSTATUS", GetType(System.String)))
            ICCFTYPEDEF_Grid.Columns.Add(New Xceed.Grid.Column("DESC_RULETYPE", GetType(System.String)))
            ICCFTYPEDEF_Grid.Columns.Add(New Xceed.Grid.Column("APPEVENTNAME", GetType(System.String)))
            ICCFTYPEDEF_Grid.Columns.Add(New Xceed.Grid.Column("DESC_MONTHDAY", GetType(System.String)))
            ICCFTYPEDEF_Grid.Columns.Add(New Xceed.Grid.Column("DESC_YEARDAY", GetType(System.String)))
            ICCFTYPEDEF_Grid.Columns.Add(New Xceed.Grid.Column("DESC_PERIOD", GetType(System.String)))
            ICCFTYPEDEF_Grid.Columns.Add(New Xceed.Grid.Column("PERIODDAY", GetType(System.String)))
            ICCFTYPEDEF_Grid.Columns.Add(New Xceed.Grid.Column("DESC_ICTYPE", GetType(System.String)))
            ICCFTYPEDEF_Grid.Columns.Add(New Xceed.Grid.Column("ICFLAT", GetType(System.String)))
            ICCFTYPEDEF_Grid.Columns.Add(New Xceed.Grid.Column("DESC_ICRATECD", GetType(System.String)))
            ICCFTYPEDEF_Grid.Columns.Add(New Xceed.Grid.Column("ICRATEID", GetType(System.String)))
            ICCFTYPEDEF_Grid.Columns.Add(New Xceed.Grid.Column("ICRATE", GetType(System.String)))
            ICCFTYPEDEF_Grid.Columns.Add(New Xceed.Grid.Column("MINVAL", GetType(System.String)))
            ICCFTYPEDEF_Grid.Columns.Add(New Xceed.Grid.Column("MAXVAL", GetType(System.String)))
            ICCFTYPEDEF_Grid.Columns.Add(New Xceed.Grid.Column("TIERRATEMIN", GetType(System.String)))
            ICCFTYPEDEF_Grid.Columns.Add(New Xceed.Grid.Column("TIERRATEMAX", GetType(System.String)))
            ICCFTYPEDEF_Grid.Columns.Add(New Xceed.Grid.Column("FLOATRATE", GetType(System.String)))
            ICCFTYPEDEF_Grid.Columns.Add(New Xceed.Grid.Column("AFTIERRATEMIN", GetType(System.String)))
            ICCFTYPEDEF_Grid.Columns.Add(New Xceed.Grid.Column("AFTIERRATEMAX", GetType(System.String)))
            ICCFTYPEDEF_Grid.Columns.Add(New Xceed.Grid.Column("SYSFLRRATE", GetType(System.String)))
            ICCFTYPEDEF_Grid.Columns.Add(New Xceed.Grid.Column("SYSCELRATE", GetType(System.String)))
            ICCFTYPEDEF_Grid.Columns.Add(New Xceed.Grid.Column("SYSFLRAMT", GetType(System.String)))
            ICCFTYPEDEF_Grid.Columns.Add(New Xceed.Grid.Column("SYSCELAMT", GetType(System.String)))

            ICCFTYPEDEF_Grid.Columns("DESC_ICCFSTATUS").Title = ResourceManager.GetString("GRID_ICCFSTATUS")
            ICCFTYPEDEF_Grid.Columns("DESC_RULETYPE").Title = ResourceManager.GetString("GRID_RULETYPE")
            ICCFTYPEDEF_Grid.Columns("ACTYPE").Title = ResourceManager.GetString("GRID_ACTYPE")
            ICCFTYPEDEF_Grid.Columns("APPEVENTNAME").Title = ResourceManager.GetString("GRID_EVENTCODE")
            ICCFTYPEDEF_Grid.Columns("DESC_MONTHDAY").Title = ResourceManager.GetString("GRID_MONTHDAY")
            ICCFTYPEDEF_Grid.Columns("DESC_YEARDAY").Title = ResourceManager.GetString("GRID_YEARDAY")
            ICCFTYPEDEF_Grid.Columns("DESC_PERIOD").Title = ResourceManager.GetString("GRID_PERIOD")
            ICCFTYPEDEF_Grid.Columns("PERIODDAY").Title = ResourceManager.GetString("GRID_PERIODDAY")
            ICCFTYPEDEF_Grid.Columns("DESC_ICTYPE").Title = ResourceManager.GetString("GRID_ICTYPE")
            ICCFTYPEDEF_Grid.Columns("ICFLAT").Title = ResourceManager.GetString("GRID_ICFLAT")
            ICCFTYPEDEF_Grid.Columns("DESC_ICRATECD").Title = ResourceManager.GetString("GRID_ICRATECD")
            ICCFTYPEDEF_Grid.Columns("ICRATEID").Title = ResourceManager.GetString("GRID_ICRATEID")
            ICCFTYPEDEF_Grid.Columns("ICRATE").Title = ResourceManager.GetString("GRID_ICRATE")
            ICCFTYPEDEF_Grid.Columns("MINVAL").Title = ResourceManager.GetString("GRID_MINVAL")
            ICCFTYPEDEF_Grid.Columns("MAXVAL").Title = ResourceManager.GetString("GRID_MAXVAL")
            ICCFTYPEDEF_Grid.Columns("TIERRATEMIN").Title = ResourceManager.GetString("TIERRATEMIN")
            ICCFTYPEDEF_Grid.Columns("TIERRATEMAX").Title = ResourceManager.GetString("TIERRATEMAX")
            ICCFTYPEDEF_Grid.Columns("FLOATRATE").Title = ResourceManager.GetString("FLOATRATE")
            ICCFTYPEDEF_Grid.Columns("AFTIERRATEMIN").Title = ResourceManager.GetString("AFTIERRATEMIN")
            ICCFTYPEDEF_Grid.Columns("AFTIERRATEMAX").Title = ResourceManager.GetString("AFTIERRATEMAX")
            ICCFTYPEDEF_Grid.Columns("SYSFLRRATE").Title = ResourceManager.GetString("SYSFLRRATE")
            ICCFTYPEDEF_Grid.Columns("SYSCELRATE").Title = ResourceManager.GetString("SYSCELRATE")
            ICCFTYPEDEF_Grid.Columns("SYSFLRAMT").Title = ResourceManager.GetString("SYSFLRAMT")
            ICCFTYPEDEF_Grid.Columns("SYSCELAMT").Title = ResourceManager.GetString("SYSCELAMT")

            ICCFTYPEDEF_Grid.Columns("AUTOID").Width = 0
            ICCFTYPEDEF_Grid.Columns("DESC_ICCFSTATUS").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
            ICCFTYPEDEF_Grid.Columns("DESC_RULETYPE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            ICCFTYPEDEF_Grid.Columns("ACTYPE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            ICCFTYPEDEF_Grid.Columns("APPEVENTNAME").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            ICCFTYPEDEF_Grid.Columns("DESC_MONTHDAY").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
            ICCFTYPEDEF_Grid.Columns("DESC_YEARDAY").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
            ICCFTYPEDEF_Grid.Columns("DESC_PERIOD").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
            ICCFTYPEDEF_Grid.Columns("PERIODDAY").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
            ICCFTYPEDEF_Grid.Columns("DESC_ICTYPE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            ICCFTYPEDEF_Grid.Columns("ICFLAT").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
            ICCFTYPEDEF_Grid.Columns("DESC_ICRATECD").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            ICCFTYPEDEF_Grid.Columns("ICRATEID").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            ICCFTYPEDEF_Grid.Columns("ICRATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
            ICCFTYPEDEF_Grid.Columns("MINVAL").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
            ICCFTYPEDEF_Grid.Columns("MAXVAL").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
            ICCFTYPEDEF_Grid.Columns("TIERRATEMIN").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
            ICCFTYPEDEF_Grid.Columns("TIERRATEMAX").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
            ICCFTYPEDEF_Grid.Columns("FLOATRATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
            ICCFTYPEDEF_Grid.Columns("AFTIERRATEMIN").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
            ICCFTYPEDEF_Grid.Columns("AFTIERRATEMAX").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
            ICCFTYPEDEF_Grid.Columns("SYSFLRRATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
            ICCFTYPEDEF_Grid.Columns("SYSCELRATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
            ICCFTYPEDEF_Grid.Columns("SYSFLRAMT").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
            ICCFTYPEDEF_Grid.Columns("SYSCELAMT").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right

            Me.pnICCF.Controls.Clear()
            Me.pnICCF.Controls.Add(ICCFTYPEDEF_Grid)
            ICCFTYPEDEF_Grid.Dock = Windows.Forms.DockStyle.Fill

            AFSERuleGrid = New GridEx

            Dim v_cmrAFSERuleHeader As New Xceed.Grid.ColumnManagerRow
            v_cmrAFSERuleHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
            v_cmrAFSERuleHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            AFSERuleGrid.FixedHeaderRows.Add(v_cmrAFSERuleHeader)
            AFSERuleGrid.Columns.Add(New Xceed.Grid.Column("AUTOID", GetType(Integer)))
            AFSERuleGrid.Columns.Add(New Xceed.Grid.Column("TYPORMST", GetType(System.String)))
            AFSERuleGrid.Columns.Add(New Xceed.Grid.Column("TYPORMSTCD", GetType(System.String)))
            AFSERuleGrid.Columns.Add(New Xceed.Grid.Column("REFID", GetType(System.String)))
            AFSERuleGrid.Columns.Add(New Xceed.Grid.Column("CODEID", GetType(System.String)))
            AFSERuleGrid.Columns.Add(New Xceed.Grid.Column("POLICYCD", GetType(System.String)))
            AFSERuleGrid.Columns.Add(New Xceed.Grid.Column("BORS", GetType(System.String)))
            AFSERuleGrid.Columns.Add(New Xceed.Grid.Column("EFFDATE", GetType(System.String)))
            AFSERuleGrid.Columns.Add(New Xceed.Grid.Column("EXPDATE", GetType(System.String)))
            'AFSERuleGrid.Columns.Add(New Xceed.Grid.Column("TERMVAL", GetType(System.Double)))
            'AFSERuleGrid.Columns.Add(New Xceed.Grid.Column("TERMRATIO", GetType(System.Double)))

            AFSERuleGrid.Columns("AUTOID").Title = ResourceManager.GetString("AFSERuleGrid.AUTOID")
            AFSERuleGrid.Columns("TYPORMST").Title = ResourceManager.GetString("AFSERuleGrid.TYPORMST")
            AFSERuleGrid.Columns("REFID").Title = ResourceManager.GetString("AFSERuleGrid.REFID")
            AFSERuleGrid.Columns("CODEID").Title = ResourceManager.GetString("AFSERuleGrid.CODEID")
            AFSERuleGrid.Columns("POLICYCD").Title = ResourceManager.GetString("AFSERuleGrid.FOA")
            AFSERuleGrid.Columns("BORS").Title = ResourceManager.GetString("AFSERuleGrid.BORS")
            AFSERuleGrid.Columns("EFFDATE").Title = ResourceManager.GetString("AFSERuleGrid.EFFDATE")
            AFSERuleGrid.Columns("EXPDATE").Title = ResourceManager.GetString("AFSERuleGrid.EXPDATE")
            'AFSERuleGrid.Columns("TERMVAL").Title = ResourceManager.GetString("AFSERuleGrid.TERMVAL")
            'AFSERuleGrid.Columns("TERMRATIO").Title = ResourceManager.GetString("AFSERuleGrid.TERMRATIO")

            AFSERuleGrid.Columns("AUTOID").Width = 0
            AFSERuleGrid.Columns("TYPORMSTCD").Visible = False
            AFSERuleGrid.Columns("AUTOID").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
            AFSERuleGrid.Columns("TYPORMST").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            AFSERuleGrid.Columns("REFID").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            AFSERuleGrid.Columns("CODEID").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            AFSERuleGrid.Columns("POLICYCD").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            AFSERuleGrid.Columns("BORS").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            AFSERuleGrid.Columns("EFFDATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
            AFSERuleGrid.Columns("EXPDATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
            'AFSERuleGrid.Columns("TERMVAL").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
            'AFSERuleGrid.Columns("TERMRATIO").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right

            'AFSERuleGrid.Columns("TERMVAL").FormatSpecifier = "#,##0.###"
            'AFSERuleGrid.Columns("TERMRATIO").FormatSpecifier = "#,##0.###"

            pnAFSERULE.Controls.Clear()
            Me.pnAFSERULE.Controls.Add(AFSERuleGrid)
            AFSERuleGrid.Dock = Windows.Forms.DockStyle.Fill

            'Dinh nghia grid cho phan quyen online
            OTRightAuthGrid = New GridEx
            Dim v_cmrOTRightAuthGridHeader As New Xceed.Grid.ColumnManagerRow
            v_cmrOTRightAuthGridHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
            v_cmrOTRightAuthGridHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            v_cmrOTRightAuthGridHeader.HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
            OTRightAuthGrid.FixedHeaderRows.Add(v_cmrOTRightAuthGridHeader)
            OTRightAuthGrid.Columns.Add(New Xceed.Grid.Column("AUTOID", GetType(Integer)))
            OTRightAuthGrid.Columns.Add(New Xceed.Grid.Column("AUTHTYPE", GetType(System.String)))
            OTRightAuthGrid.Columns.Add(New Xceed.Grid.Column("AUTHCUSTID", GetType(System.String)))
            'OTRightAuthGrid.Columns.Add(New Xceed.Grid.Column("AUTHAFACCTNO", GetType(System.String)))
            OTRightAuthGrid.Columns.Add(New Xceed.Grid.Column("FULLNAME", GetType(System.String)))
            OTRightAuthGrid.Columns.Add(New Xceed.Grid.Column("IDCODE", GetType(System.String)))
            OTRightAuthGrid.Columns.Add(New Xceed.Grid.Column("ADDRESS", GetType(System.String)))
            OTRightAuthGrid.Columns.Add(New Xceed.Grid.Column("PHONE", GetType(System.String)))
            OTRightAuthGrid.Columns.Add(New Xceed.Grid.Column("VALDATE", GetType(System.String)))
            OTRightAuthGrid.Columns.Add(New Xceed.Grid.Column("EXPDATE", GetType(System.String)))

            OTRightAuthGrid.Columns("AUTOID").Title = ResourceManager.GetString("grid.AUTOID")
            OTRightAuthGrid.Columns("AUTHTYPE").Title = ResourceManager.GetString("grid.AUTHTYPE")
            OTRightAuthGrid.Columns("AUTHCUSTID").Title = ResourceManager.GetString("grid.CUSTID")
            'OTRightAuthGrid.Columns("AUTHAFACCTNO").Title = ResourceManager.GetString("grid.AUTHAFACCTNO")
            OTRightAuthGrid.Columns("FULLNAME").Title = ResourceManager.GetString("grid.FULLNAME")
            OTRightAuthGrid.Columns("IDCODE").Title = ResourceManager.GetString("grid.LICENSENO")
            OTRightAuthGrid.Columns("ADDRESS").Title = ResourceManager.GetString("grid.ADDRESS")
            OTRightAuthGrid.Columns("PHONE").Title = ResourceManager.GetString("grid.TELEPHONE")
            OTRightAuthGrid.Columns("VALDATE").Title = ResourceManager.GetString("grid.VALDATE")
            OTRightAuthGrid.Columns("EXPDATE").Title = ResourceManager.GetString("grid.EXPDATE")

            OTRightAuthGrid.Columns("AUTOID").Visible = False

            'OTRightAuthGrid.Columns("CUSTID").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
            'OTRightAuthGrid.Columns("FULLNAME").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            'OTRightAuthGrid.Columns("LICENSENO").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            'OTRightAuthGrid.Columns("ADDRESS").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            'OTRightAuthGrid.Columns("TELEPHONE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            'OTRightAuthGrid.Columns("VALDATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            'OTRightAuthGrid.Columns("EXPDATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            ''OTRightAuthGrid.Columns("LNDATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            'OTRightAuthGrid.Columns("LNPLACE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left

            Me.pnOTRightAsgn.Controls.Clear()
            Me.pnOTRightAsgn.Controls.Add(OTRightAuthGrid)
            OTRightAuthGrid.Dock = Windows.Forms.DockStyle.Fill

            'Dinh nghia grid cho template SMS/Email
            TemplateGrid = New GridEx

            TemplateGrid.AutoSize = True

            Dim cmrTemplateGridHeader As New Xceed.Grid.ColumnManagerRow
            cmrTemplateGridHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
            cmrTemplateGridHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            cmrTemplateGridHeader.HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center

            TemplateGrid.FixedHeaderRows.Add(cmrTemplateGridHeader)
            TemplateGrid.Columns.Add(New Xceed.Grid.Column("AUTOID", GetType(Integer)))
            TemplateGrid.Columns.Add(New Xceed.Grid.Column("NAME", GetType(System.String)))
            TemplateGrid.Columns.Add(New Xceed.Grid.Column("SUBJECT", GetType(System.String)))

            TemplateGrid.Columns("AUTOID").Title = ResourceManager.GetString("grid.TEMPLATE_AUTOID")
            TemplateGrid.Columns("NAME").Title = ResourceManager.GetString("grid.TEMPLATE_ID")
            TemplateGrid.Columns("SUBJECT").Title = ResourceManager.GetString("grid.TEMPLATE_DESCRIPTION")

            TemplateGrid.Columns("AUTOID").Visible = False

            TemplateGrid.Columns("SUBJECT").Width = 500

            'TemplateGrid.Columns("CUSTID").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
            'TemplateGrid.Columns("FULLNAME").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            'TemplateGrid.Columns("LICENSENO").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            'TemplateGrid.Columns("ADDRESS").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            'TemplateGrid.Columns("TELEPHONE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            'TemplateGrid.Columns("VALDATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            'TemplateGrid.Columns("EXPDATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            ''TemplateGrid.Columns("LNDATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            'TemplateGrid.Columns("LNPLACE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left

            Me.pnTemplate.Controls.Clear()
            Me.pnTemplate.Controls.Add(TemplateGrid)
            TemplateGrid.Dock = Windows.Forms.DockStyle.Fill

        Catch ex As Exception
            Throw ex
        Finally
            v_xmlDocument = Nothing
            v_ws = Nothing
        End Try
    End Sub

    'Xoa mot dong trong grid
    Private Function Delete_TabPage_Row(Optional ByVal pv_strIsLocal As String = "", Optional ByVal pv_strModule As String = "") As Int32
        Dim v_ws As New BDSDeliveryManagement
        Dim v_strKeyFieldName, v_strKeyFieldValue As String
        Dim v_strClause, v_strObjMsg As String
        Dim v_strErrorSource, v_strErrorMessage As String
        Dim v_lngErrorCode As Long

        'AnhVT Added - Maintenance Retroed
        Dim ParentObjName As String = Me.ObjectName
        Dim ParentClause As String = KeyFieldName & " = '" & txtACCTNO.Text & "'"
        'AnhVT Ended

        Try
            '2010/04/22 - Truongld 

            If Me.tabAFMAST.SelectedTab.Name = tabContractMember.Name AndAlso ContactsGrid.CurrentGrid.DataRows.Count = 0 Then
                MsgBox(ResourceManager.GetString("frmAFMAST.Nothing"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                Exit Function
            End If
            If Me.tabAFMAST.SelectedTab.Name = tabContractMember.Name AndAlso (ContactsGrid.CurrentRow Is Nothing) Then
                MsgBox(ResourceManager.GetString("frmAFMAST.NotSelected"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                Exit Function
            End If
            'End Truongld
            If MsgBox(ResourceManager.GetString("DelConfirm"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                'Update mouse pointer
                Cursor.Current = Cursors.WaitCursor

                If (pv_strIsLocal.Length <> 0) And (pv_strModule.Length <> 0) Then
                    If (Not (ContactsGrid.CurrentRow Is Nothing)) Then
                        v_strKeyFieldName = CType(ContactsGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").FieldName
                        v_strKeyFieldValue = CType(ContactsGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value
                        Select Case KeyFieldType
                            Case "D"
                                v_strClause = v_strKeyFieldName & " = TO_DATE('" & v_strKeyFieldValue & "', '" & gc_FORMAT_DATE & "')"
                            Case "N"
                                v_strClause = v_strKeyFieldName & " = " & v_strKeyFieldValue
                            Case "C"
                                v_strClause = v_strKeyFieldName & " = '" & v_strKeyFieldValue & "'"
                        End Select

                        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, pv_strIsLocal, gc_MsgTypeObj, pv_strModule, gc_ActionDelete, , v_strClause, , , , , , , , ParentObjName, ParentClause)
                        v_ws.Message(v_strObjMsg)
                        GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                    End If

                    If (Not (AnthorizeGrid.CurrentRow Is Nothing)) Then
                        v_strKeyFieldName = CType(AnthorizeGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").FieldName
                        v_strKeyFieldValue = CType(AnthorizeGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value
                        Select Case KeyFieldType
                            Case "D"
                                v_strClause = v_strKeyFieldName & " = TO_DATE('" & v_strKeyFieldValue & "', '" & gc_FORMAT_DATE & "')"
                            Case "N"
                                v_strClause = v_strKeyFieldName & " = " & v_strKeyFieldValue
                            Case "C"
                                v_strClause = v_strKeyFieldName & " = '" & v_strKeyFieldValue & "'"
                        End Select

                        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, pv_strIsLocal, gc_MsgTypeObj, pv_strModule, gc_ActionDelete, , v_strClause, , , , , , , , ParentObjName, ParentClause)
                        v_ws.Message(v_strObjMsg)
                        GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                    End If

                    If (Not (ExtCIGrid.CurrentRow Is Nothing)) OrElse (Not (Me.ExtBankAccGrid.CurrentRow Is Nothing)) Then

                        If m_blnGridCI = True Then
                            v_strKeyFieldName = CType(ExtCIGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").FieldName
                            v_strKeyFieldValue = CType(ExtCIGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value
                        Else
                            v_strKeyFieldName = CType(ExtBankAccGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").FieldName
                            v_strKeyFieldValue = CType(ExtBankAccGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value
                        End If

                        Select Case KeyFieldType
                            Case "D"
                                v_strClause = v_strKeyFieldName & " = TO_DATE('" & v_strKeyFieldValue & "', '" & gc_FORMAT_DATE & "')"
                            Case "N"
                                v_strClause = v_strKeyFieldName & " = " & v_strKeyFieldValue
                            Case "C"
                                v_strClause = v_strKeyFieldName & " = '" & v_strKeyFieldValue & "'"
                        End Select

                        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, pv_strIsLocal, gc_MsgTypeObj, pv_strModule, gc_ActionDelete, , v_strClause, , , , , , , , ParentObjName, ParentClause)
                        v_ws.Message(v_strObjMsg)
                        GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                    End If

                    If (Not (ReportGrid.CurrentRow Is Nothing)) Then
                        v_strKeyFieldName = CType(ReportGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").FieldName
                        v_strKeyFieldValue = CType(ReportGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value
                        Select Case KeyFieldType
                            Case "D"
                                v_strClause = v_strKeyFieldName & " = TO_DATE('" & v_strKeyFieldValue & "', '" & gc_FORMAT_DATE & "')"
                            Case "N"
                                v_strClause = v_strKeyFieldName & " = " & v_strKeyFieldValue
                            Case "C"
                                v_strClause = v_strKeyFieldName & " = '" & v_strKeyFieldValue & "'"
                        End Select

                        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, pv_strIsLocal, gc_MsgTypeObj, pv_strModule, gc_ActionDelete, , v_strClause, , , , , , , , ParentObjName, ParentClause)
                        v_ws.Message(v_strObjMsg)
                        GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                    End If

                    If (Not (TxmapGrid.CurrentRow Is Nothing)) Then

                        If Trim(CType(TxmapGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AFACCTNO").Value) = "ALL" Then
                            MsgBox(ResourceManager.GetString("AUTHNOTALLOW"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                            Exit Function
                        End If

                        v_strKeyFieldName = CType(TxmapGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").FieldName
                        v_strKeyFieldValue = CType(TxmapGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value

                        Select Case KeyFieldType
                            Case "D"
                                v_strClause = v_strKeyFieldName & " = TO_DATE('" & v_strKeyFieldValue & "', '" & gc_FORMAT_DATE & "')"
                            Case "N"
                                v_strClause = v_strKeyFieldName & " = " & v_strKeyFieldValue
                            Case "C"
                                v_strClause = v_strKeyFieldName & " = '" & v_strKeyFieldValue & "'"
                        End Select

                        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, pv_strIsLocal, gc_MsgTypeObj, pv_strModule, gc_ActionDelete, , v_strClause, , , , , , , , ParentObjName, ParentClause)
                        v_ws.Message(v_strObjMsg)
                        GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                    End If

                    If v_lngErrorCode <> 0 Then
                        'Update mouse pointer
                        Cursor.Current = Cursors.Default
                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Exit Function
                    End If
                End If
                'Update mouse pointer
                Cursor.Current = Cursors.Default
                MsgBox(ResourceManager.GetString("DelSuccess"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_ws = Nothing
        End Try
    End Function

    'Lay thong tin khach hang
    Private Sub GetCustomerInfor(ByVal pv_strCustID As String)
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQL, v_strObjMsg, v_strValue, v_strFLDNAME As String
            'v_strSQL = "SELECT  FULLNAME || ' - ' || ADDRESS CUSTNAME, ADDRESS, EMAIL, PHONE, MOBILE, FAX, FAX1, STATUS, CAREBY, CUSTODYCD, CUSTTYPE, COUNTRY, " & _
            '           "(CASE WHEN CUSTTYPE='I' THEN 'Y' ELSE 'N' END) IORB, (CASE WHEN COUNTRY='VNM' THEN 'Y' ELSE 'N' END) DORF   FROM CFMAST WHERE CUSTID = '" & pv_strCustID & "'"
            v_strSQL = "SELECT  FULLNAME || ' - ' || ADDRESS CUSTNAME, ADDRESS, EMAIL, PHONE, MOBILE, FAX, FAX1, STATUS, CAREBY,TLID, CUSTODYCD, CUSTTYPE, COUNTRY, CONTRACTCHK, " & _
                       "(CASE WHEN CUSTTYPE='I' THEN 'Y' ELSE 'N' END) IORB, (CASE WHEN COUNTRY='234' THEN 'Y' ELSE 'N' END) DORF, CUSTATCOM,OPENVIA,OLAUTOID,TRADINGCODE   FROM CFMAST WHERE CUSTID = '" & pv_strCustID & "'"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_AFMAST, gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            'PhuongHT add to reset variable
            v_strCustInfor = String.Empty
            v_strAddress = String.Empty
            v_strEmail = String.Empty
            v_strPhone1 = String.Empty
            v_strMobile = String.Empty
            v_strFax = String.Empty
            v_strFax1 = String.Empty
            mv_strCustomerStatus = String.Empty
            mv_strCareBy = String.Empty
            v_strCUSTODYCD = String.Empty
            v_strCUSTTYPE = String.Empty
            v_strCOUNTRY = String.Empty
            v_strIORB = String.Empty
            v_strDORF = String.Empty
            v_strCONTRACTCHK = String.Empty
            v_strCUSTATCOM = String.Empty
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Count - 1
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = Trim(.InnerText.ToString)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "CUSTNAME"
                                v_strCustInfor = v_strValue
                            Case "ADDRESS"
                                v_strAddress = v_strValue
                            Case "EMAIL"
                                v_strEmail = v_strValue
                            Case "PHONE"
                                v_strPhone1 = v_strValue
                            Case "MOBILE"
                                v_strMobile = v_strValue
                            Case "FAX"
                                v_strFax = v_strValue
                            Case "FAX1"
                                v_strFax1 = v_strValue
                            Case "STATUS"
                                mv_strCustomerStatus = v_strValue
                            Case "CAREBY"
                                mv_strCareBy = Trim(v_strValue)
                            Case "CUSTODYCD"
                                v_strCUSTODYCD = Trim(v_strValue)
                            Case "CUSTTYPE"
                                v_strCUSTTYPE = Trim(v_strValue)
                            Case "COUNTRY"
                                v_strCOUNTRY = Trim(v_strValue)
                            Case "IORB"
                                v_strIORB = Trim(v_strValue)
                            Case "DORF"
                                v_strDORF = Trim(v_strValue)
                            Case "CONTRACTCHK"
                                v_strCONTRACTCHK = Trim(v_strValue)
                            Case "CUSTATCOM"
                                v_strCUSTATCOM = Trim(v_strValue)
                            Case "OLAUTOID"
                                mv_OLAUTOID = v_strValue
                            Case "OPENVIA"
                                If (v_strValue = "O" And Not v_strCUSTODYCD.Trim.Length > 0) Then
                                    mv_IsOnlineRegister = True
                                Else
                                    mv_IsOnlineRegister = False
                                End If
                                'Case "TLID" ' dien them
                                '    mv_strTlid = Trim(v_strValue) 'dien them
                            Case "TRADINGCODE"
                                v_strTradingCode = Trim(v_strValue)
                        End Select
                    End With
                Next
            Next
            If (v_strCUSTODYCD <> "") Then
                Me.txtCUSTODYCD.Text = v_strCUSTODYCD
                'If v_strCONTRACTCHK = "Y" AndAlso Me.txtCUSTODYCD.Text.Trim <> String.Empty AndAlso (Me.txtCUSTODYCD.Text.Trim.Substring(0, 4) = "017C" OrElse Me.txtCUSTODYCD.Text.Trim.Substring(0, 4) = "017P") Then
                '    cboAUTOADV.SelectedValue = "Y"
                'Else
                '    cboAUTOADV.SelectedValue = "N"
                'End If
            End If
            If (v_strTradingCode <> "") Then
                Me.lblTRADINGCODE.Visible = True
                Me.txtTRADINGCODE.Visible = True
                Me.txtTRADINGCODE.Text = v_strTradingCode
                Me.txtTRADINGCODE.ForeColor = Color.Red
            Else
                Me.lblTRADINGCODE.Visible = False
                Me.txtTRADINGCODE.Visible = False
            End If

            If (v_strCUSTTYPE = "I") Then
                Me.cboAFTYPE.SelectedValue = "001"
            Else
                Me.cboAFTYPE.SelectedValue = "002"
            End If

            'Fill du lieu vao Combobox apply contract
            Me.cboAPPLYACCT.Clears()
            Dim v_strCMDSQL As String = "SELECT CF.CUSTID FILTERCD, AF.ACCTNO VALUE, AF.ACCTNO VALUECD, AF.ACCTNO || ': ' || AFT.TYPENAME DISPLAY," _
                           & " AF.ACCTNO || ': ' || AFT.TYPENAME EN_DISPLAY, CF.FULLNAME DESCRIPTION,AF.GROUPLEADER, AF.CAREBY " _
                           & " FROM CFMAST CF, AFMAST AF, AFTYPE AFT " _
                           & " WHERE CF.CUSTID=AF.CUSTID AND AF.ACTYPE=AFT.ACTYPE AND AF.STATUS <> 'C' AND CF.CUSTID='" & pv_strCustID & "'"
            'Lay du lieu

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCMDSQL)
            v_ws.Message(v_strObjMsg)
            FillComboEx(v_strObjMsg, Me.cboAPPLYACCT, "", Me.UserLanguage)

            Me.cboAFTYPE.Enabled = False
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                                    & "Error code: System error!" & vbNewLine _
                                    & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ResourceManager.GetString("SavingFailed"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_xmlDocument = Nothing
            v_ws = Nothing
        End Try
    End Sub
    ''' <summary>
    ''' binhpt add, lay thong tin dang ky tu online
    ''' </summary>
    ''' <param name="pv_OLAUTOID">AutoID trong bang registeronline</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetCustomerInforOL(ByVal pv_OLAUTOID As String)
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_ws As New BDSDeliveryManagement
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQL, v_strObjMsg, v_strValue, v_strFLDNAME As String
            v_strSQL = "SELECT CASHINADVANCEAUTO,PLACEORDERPHONE,SMSPHONENUMBER," _
                       & "PLACEORDERONLINE,CASHINADVANCEONLINE,CASHTRANSFERONLINE," _
                       & "ADDITIONALSHARESONLINE,SEARCHONLINE," _
                       & "BANKACCOUNTNAME1,BANKIDCODE1,BANKIDDATE1,BANKIDPLACE1," _
                       & "BANKACCOUNTNUMBER1,BANKNAME1,BRANCH1,BANKCITY1," _
                       & "BANKACCOUNTNAME2,BANKIDCODE2,BANKIDDATE2,BANKIDPLACE2," _
                       & "BANKACCOUNTNUMBER2,BANKNAME2,BRANCH2,BANKCITY2," _
                       & "BANKACCOUNTNAME3,BANKIDCODE3,BANKIDDATE3,BANKIDPLACE3," _
                       & "BANKACCOUNTNUMBER3, BANKNAME3, BRANCH3, BANKCITY3" _
                       & " FROM REGISTERONLINE" _
                       & " WHERE AUTOID= '" & pv_OLAUTOID & "'"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_AFMAST, gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Count - 1
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = Trim(.InnerText.ToString)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "CASHINADVANCEAUTO"
                                mv_cashinadvanceauto = v_strValue
                            Case "PLACEORDERPHONE"
                                mv_placeorderphone = v_strValue
                            Case "SMSPHONENUMBER"
                                mv_smsphonenumber = v_strValue
                            Case "PLACEORDERONLINE"
                                mv_placeorderonline = v_strValue
                            Case "CASHINADVANCEONLINE"
                                mv_cashinadvanceonline = v_strValue
                            Case "CASHTRANSFERONLINE"
                                mv_cashtransferonline = v_strValue
                            Case "ADDITIONALSHARESONLINE"
                                mv_additionalsharesonline = v_strValue
                            Case "SEARCHONLINE"
                                mv_searchonline = v_strValue
                            Case "BANKACCOUNTNAME1"
                                mv_bankaccountname1 = Trim(v_strValue)
                            Case "BANKIDCODE1"
                                mv_bankidcode1 = Trim(v_strValue)
                            Case "BANKIDDATE1"
                                mv_bankiddate1 = Trim(v_strValue)
                            Case "BANKIDPLACE1"
                                mv_bankidplace1 = Trim(v_strValue)
                            Case "BRANCH1"
                                mv_branch1 = Trim(v_strValue)
                            Case "BANKCITY1"
                                mv_bankcity1 = Trim(v_strValue)
                            Case "BANKNAME1"
                                mv_bankname1 = Trim(v_strValue)
                            Case "BANKACCOUNTNUMBER1"
                                mv_bankaccountnumber1 = Trim(v_strValue)

                            Case "BANKACCOUNTNAME2"
                                mv_bankaccountname2 = Trim(v_strValue)
                            Case "BANKIDCODE2"
                                mv_bankidcode2 = Trim(v_strValue)
                            Case "BANKIDDATE2"
                                mv_bankiddate2 = Trim(v_strValue)
                            Case "BANKIDPLACE2"
                                mv_bankidplace2 = Trim(v_strValue)
                            Case "BRANCH2"
                                mv_branch2 = Trim(v_strValue)
                            Case "BANKCITY2"
                                mv_bankcity2 = Trim(v_strValue)
                            Case "BANKNAME2"
                                mv_bankname2 = Trim(v_strValue)
                            Case "BANKACCOUNTNUMBER2"
                                mv_bankaccountnumber2 = Trim(v_strValue)

                            Case "BANKACCOUNTNAME3"
                                mv_bankaccountname3 = Trim(v_strValue)
                            Case "BANKIDCODE3"
                                mv_bankidcode3 = Trim(v_strValue)
                            Case "BANKIDDATE3"
                                mv_bankiddate3 = Trim(v_strValue)
                            Case "BANKIDPLACE3"
                                mv_bankidplace3 = Trim(v_strValue)
                            Case "BRANCH3"
                                mv_branch3 = Trim(v_strValue)
                            Case "BANKCITY3"
                                mv_bankcity3 = Trim(v_strValue)
                            Case "BANKNAME3"
                                mv_bankname3 = Trim(v_strValue)
                            Case "BANKACCOUNTNUMBER3"
                                mv_bankaccountnumber3 = Trim(v_strValue)
                        End Select
                    End With
                Next
            Next
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                                    & "Error code: System error!" & vbNewLine _
                                    & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ResourceManager.GetString("SavingFailed"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_xmlDocument = Nothing
            v_ws = Nothing
        End Try
    End Function
    'Tao so hop dong
    Private Function getContract(ByVal BranchID As String) As String
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_wsBDS As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            Dim v_strClause, v_strAutoID As String
            Dim v_int, v_intCount As Integer
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strFLDNAME, v_strVALUE As String
            v_strClause = "AFACCTNO"
            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchID, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_strClause, "GetInventory")
            v_wsBDS.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_strAutoID = v_xmlDocument.DocumentElement.Attributes("CLAUSE").Value
            v_strAutoID = Me.BranchId & Strings.Right("000000" & CStr(v_strAutoID), Len("000000"))
            Return v_strAutoID
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                                    & "Error code: System error!" & vbNewLine _
                                    & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ResourceManager.GetString("SavingFailed"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_xmlDocument = Nothing
            v_wsBDS = Nothing
        End Try
    End Function

    'Tao so tai khoan luu ky
    Private Function getCustodyCD(ByVal BranchID As String) As String
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            Dim v_strClause, v_strAutoID As String
            Dim v_int, v_intCount As Integer
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strFLDNAME, v_strVALUE As String
            v_strClause = "CUSTODYCD"
            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchID, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_strClause, "GetInventory")
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_strAutoID = v_xmlDocument.DocumentElement.Attributes("CLAUSE").Value


            'For i As Integer = 0 To v_nodeList.Count - 1
            '    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
            '        With v_nodeList.Item(i).ChildNodes(j)
            '            v_strVALUE = Trim(.InnerText.ToString)
            '            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
            '            Select Case Trim(v_strFLDNAME)

            '                Case "CONTRACTCHK"
            '                    v_strCONTRACTCHK = Trim(v_strVALUE)
            '                    'Case "TLID" ' dien them
            '                    '    mv_strTlid = Trim(v_strValue) 'dien them
            '            End Select
            '        End With
            '    Next
            'Next
            'If v_strCOUNTRY <> "VNM" Then

            Dim v_strPrefixCustodyCD As String = AppSettings.Get("PrefixedCustodyCode")
            'If (v_strCOUNTRY <> "234" And v_strCOUNTRY.Trim <> "") Then
            '    v_strAutoID = v_strPrefixCustodyCD & "F" & Strings.Right("000000" & CStr(v_strAutoID), Len("000000"))
            'Else
            '    v_strAutoID = v_strPrefixCustodyCD & "C" & Strings.Right("000000" & CStr(v_strAutoID), Len("000000"))
            'End If
            If (Me.cboCUSTATCOM.SelectedValue = "N") Then
                v_strAutoID = v_strPrefixCustodyCD & "F" & Strings.Right("000000" & CStr(v_strAutoID), Len("000000"))
            Else
                v_strAutoID = v_strPrefixCustodyCD & "C" & Strings.Right("000000" & CStr(v_strAutoID), Len("000000"))
            End If

            Return v_strAutoID
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                                    & "Error code: System error!" & vbNewLine _
                                    & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ResourceManager.GetString("SavingFailed"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_xmlDocument = Nothing
            v_ws = Nothing
        End Try
    End Function

    'Lay thong tin ve loai hinh
    Private Sub GetAFTYPEs()
        Dim XmlDocument As New Xml.XmlDocument
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            Dim v_strObjMsg As String
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_AFMAST, gc_ActionAdhoc, , GroupCareBy, "GetAFtypes")
            v_ws.Message(v_strObjMsg)
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strFLDNAME, v_strValue, v_strActype, v_strDescription As String

            XmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = XmlDocument.SelectNodes("/ObjectMessage/ObjData")
            If v_nodeList.Count > 0 Then
                For i As Integer = 0 To v_nodeList.Count - 1
                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            v_strValue = .InnerText.ToString
                            Select Case Trim(v_strFLDNAME)
                                Case "VALUE"
                                    v_strActype = Trim(v_strValue)
                                Case "DESCRIPTION"
                                    v_strDescription = Trim(v_strValue)
                            End Select
                        End With
                    Next
                    If hAftype(v_strActype) Is Nothing Then
                        hAftype.Add(v_strActype, v_strActype & "|" & v_strDescription)
                    End If
                Next
            End If

            'Lookup AFtypes
            If mv_blnLookup = True Then
                Dim v_frm As New AppCore.frmLookUp(UserLanguage)
                v_frm.AFtypeData = v_strObjMsg

                v_frm.ShowDialog()
                Dim v_intPos As Integer
                v_intPos = InStr(v_frm.RETURNDATA, vbTab)
                If v_intPos > 0 Then
                    CType(txtACTYPE, FlexMaskEditBox).Text = Mid(v_frm.RETURNDATA, 1, v_intPos - 1)
                End If
                v_frm.Dispose()
            End If
        Catch ex As Exception
            Throw ex
        Finally
            XmlDocument = Nothing
            v_ws = Nothing
        End Try
    End Sub

    'Lay thong tin loai hinh hop dong
    Private Sub LoadACTYPE(ByVal pv_strACTYPE As String, Optional ByVal pv_blnIschange As Boolean = True)
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            If Len(Me.txtCUSTID.Text) <> 10 Then
                MsgBox(Replace(ResourceManager.GetString("Mandatory"), "@", ResourceManager.GetString("CUSTID")), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                txtCUSTID.Focus()
                Exit Sub
            End If
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strFLDNAME, v_strVALUE, v_strACTYPE, v_strAFTYPE, v_strLINETIED, v_strIFRULECD, v_strSTMCYCLE, v_strISOTC, v_strCONSULTANT, v_strCUSTID, V_STRCOREBANK, v_strVAT As String
            Dim v_strFLOORLIMIT, v_strTELELIMIT, v_strONLINELIMIT, v_strBRATIO, v_strDEPOSITLINE As Double
            Dim v_strDEPORATE, v_strTRADERATE, v_strMISCRATE, v_strMARGINLINE, v_strREPOLINE, v_strADVANCEDLINE, v_strTIEDFEEBASE As Double
            Dim v_strMRIRATE, v_strMRMRATE, v_strMRLRATE, v_strDUEDAY, v_strEXTDAY, v_strMarginType As String
            Dim v_strMRIRATIO, v_strMRMRATIO, v_strMRLRATIO, v_strTRFBUYRATE, v_strTRFBUYEXT As String
            Dim v_strCmdInquiry As String
            Dim v_strObjMsg As String
            'v_strCmdInquiry = "SELECT AFTYPE.*, MRTYPE.MRIRATE, MRTYPE.MRMRATE, MRTYPE.MRLRATE, MRTYPE.DUEDAY, MRTYPE.EXTDAY, MRTYPE.MRTYPE MARGINTYPE FROM AFTYPE, MRTYPE WHERE TRIM(AFTYPE.ACTYPE) ='" & pv_strACTYPE & "' AND AFTYPE.MRTYPE=MRTYPE.ACTYPE "
            v_strCmdInquiry = "SELECT AFTYPE.*, MRTYPE.MRIRATE, MRTYPE.MRMRATE, MRTYPE.MRLRATE,MRTYPE.MRIRATIO, MRTYPE.MRMRATIO, MRTYPE.MRLRATIO, MRTYPE.DUEDAY, MRTYPE.EXTDAY, MRTYPE.MRTYPE MARGINTYPE FROM AFTYPE, MRTYPE WHERE TRIM(AFTYPE.ACTYPE) ='" & pv_strACTYPE & "' AND AFTYPE.MRTYPE=MRTYPE.ACTYPE "
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_AFTYPE, gc_ActionInquiry, v_strCmdInquiry)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            'Lay thong tin ve loai hinh
            For i As Integer = 0 To v_nodeList.Count - 1
                For j As Integer = 0 To v_nodeList.Item(j).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strFLDNAME = v_nodeList.Item(i).ChildNodes(j).Attributes.GetNamedItem("fldname").Value.Trim()
                        v_strVALUE = v_nodeList.Item(i).ChildNodes(j).Attributes.GetNamedItem("oldval").Value.Trim()
                        Select Case v_strFLDNAME
                            Case "ACTYPE"
                                v_strACTYPE = v_strVALUE
                                'Case "AFTYPE"
                                '    v_strAFTYPE = v_strVALUE
                            Case "IFRULECD"
                                v_strIFRULECD = v_strVALUE
                            Case "LINETIED"
                                v_strLINETIED = v_strVALUE
                            Case "STMCYCLE"
                                v_strSTMCYCLE = v_strVALUE
                            Case "ISOTC"
                                v_strISOTC = v_strVALUE
                            Case "CONSULTANT"
                                v_strCONSULTANT = v_strVALUE
                            Case "FLOORLIMIT"
                                v_strFLOORLIMIT = v_strVALUE
                            Case "TELELIMIT"
                                v_strTELELIMIT = v_strVALUE
                            Case "ONLINELIMIT"
                                v_strONLINELIMIT = v_strVALUE
                            Case "BRATIO"
                                v_strBRATIO = v_strVALUE
                            Case "DEPOSITLINE"
                                v_strDEPOSITLINE = v_strVALUE
                            Case "DEPORATE"
                                v_strDEPORATE = v_strVALUE
                            Case "TRADERATE"
                                v_strTRADERATE = v_strVALUE
                            Case "MISCRATE"
                                v_strMISCRATE = v_strVALUE
                            Case "MARGINLINE"
                                v_strMARGINLINE = v_strVALUE
                            Case "REPOLINE"
                                v_strREPOLINE = v_strVALUE
                            Case "ADVANCEDLINE"
                                v_strADVANCEDLINE = v_strVALUE
                            Case "DEPOSITLINE"
                                v_strDEPOSITLINE = v_strVALUE
                            Case "TIEDFEEBASE"
                                v_strTIEDFEEBASE = v_strVALUE
                            Case "COREBANK"
                                V_STRCOREBANK = v_strVALUE
                            Case "MRIRATE"
                                v_strMRIRATE = v_strVALUE
                            Case "MRMRATE"
                                v_strMRMRATE = v_strVALUE
                            Case "MRLRATE"
                                v_strMRLRATE = v_strVALUE
                            Case "DUEDAY"
                                v_strDUEDAY = v_strVALUE
                            Case "EXTDAY"
                                v_strEXTDAY = v_strVALUE
                            Case "MARGINTYPE"
                                v_strMarginType = v_strVALUE
                            Case "VAT"
                                v_strVAT = v_strVALUE
                            Case "MRIRATIO"
                                v_strMRIRATIO = v_strVALUE
                            Case "MRMRATIO"
                                v_strMRMRATIO = v_strVALUE
                            Case "MRLRATIO"
                                v_strMRLRATIO = v_strVALUE
                            Case "TRFBUYEXT"
                                v_strTRFBUYEXT = v_strVALUE
                            Case "TRFBUYRATE"
                                v_strTRFBUYRATE = v_strVALUE
                        End Select
                    End With
                Next
            Next
            '-------CHECK------------
            mv_strMarginType = v_strMarginType
            If v_strMarginType <> "N" Then
                cboCOREBANK.SelectedValue = "N"
                cboCOREBANK.Enabled = False
            Else
                cboCOREBANK.Enabled = True
            End If

            ' Neu la khach hang ca nhan trong nuoc, khach hang ca nhan nuoc ngoai, khach hang to chuc nuoc ngoai
            ' thi thong tin thu thue VAT phai la Y.
            If v_strCOUNTRY.Trim <> "234" AndAlso v_strVAT <> "Y" And v_strCUSTTYPE = "I" Then
                MsgBox(ResourceManager.GetString("ACTYPE_INVALID_VAT"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                Me.txtACTYPE.Focus()
                Exit Sub
            End If
            If v_strCOUNTRY.Trim = "234" AndAlso v_strCUSTTYPE = "I" AndAlso v_strVAT <> "Y" Then
                MsgBox(ResourceManager.GetString("ACTYPE_INVALID_VAT"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                Me.txtACTYPE.Focus()
                Exit Sub
            End If

            v_strCUSTID = txtCUSTID.Text
            If Len(v_strACTYPE) = 0 Then
                'KhÃ´ng tá»“n táº¡i loáº¡i hÃ¬nh há»£p Ä‘á»“ng nÃ y
                MsgBox(ResourceManager.GetString("ACTYPE_INVALID"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                Me.txtACTYPE.Focus()
                Exit Sub
            Else


                If V_STRCOREBANK = "Y" Then
                    Me.txtBANKACCTNO.Enabled = True
                    Me.lblBANKACCTNO.ForeColor = System.Drawing.Color.Red

                    Me.txtBANKACCTNOBLOCK.Enabled = True
                    Me.cboBANKNAME.Enabled = True
                    Me.lblBANKNAME.ForeColor = System.Drawing.Color.Red

                    Me.txtSWIFTCODE.Enabled = True
                    Me.cboALLOWDEBIT.Enabled = True
                    Me.cboAUTOADV.Enabled = False
                    Me.cboAUTOADV.SelectedValue = "N"
                Else
                    If v_strMarginType = "T" Then
                        cboAUTOADV.SelectedValue = "Y"
                        cboAUTOADV.Enabled = False
                    Else
                        If ExeFlag = ExecuteFlag.AddNew Then
                            cboAUTOADV.Enabled = True
                        End If
                    End If
                    'Me.cboAUTOADV.Enabled = True
                End If



                If v_strLINETIED = "Y" Then
                    mv_blnACTYPE_AllowCustomized = True
                Else
                    mv_blnACTYPE_AllowCustomized = False
                End If

                If pv_blnIschange Then
                    ' Hiá»ƒn thá»‹ cÃ¡c thÃ´ng tin loáº¡i hÃ¬nh
                    'Me.cboAFTYPE.SelectedValue = v_strAFTYPE ' PhuongHT edit: 

                    Me.cboCONSULTANT.SelectedValue = v_strCONSULTANT
                    Me.cboCONSULTANT.Enabled = False
                    Me.cboISOTC.SelectedValue = v_strISOTC
                    Me.cboISOTC.Enabled = False
                    Me.cboCOREBANK.SelectedValue = V_STRCOREBANK
                    If v_strMarginType <> "N" Then
                        cboCOREBANK.SelectedValue = "N"
                        cboCOREBANK.Enabled = False
                    Else
                        cboCOREBANK.Enabled = True
                    End If
                    Me.cboCOREBANK.Enabled = False

                    'Me.txtIFRULECD.Text = v_strIFRULECD
                    'Me.txtIFRULECD.Enabled = False
                    Me.txtREPOLINE.Text = FormatNumber(CStr(v_strREPOLINE), 0)
                    Me.txtMARGINLINE.Text = FormatNumber(CStr(v_strMARGINLINE), 0)
                    'Me.txtADVANCELINE.Text = FormatNumber(CStr(v_strADVANCEDLINE), 0)                    
                    Me.txtTRADERATE.Text = FormatNumber(CStr(v_strTRADERATE), 0)
                    Me.txtMISCRATE.Text = FormatNumber(CStr(v_strMISCRATE), 0)
                    Me.txtBRATIO.Text = FormatNumber(CStr(v_strBRATIO), 2)
                    'Me.txtBRATIO.Text = 0 'Day la delta ty le ky quy. Mac dinh TLKQ lech voi loai hinh la 0% 
                    Me.txtDEPORATE.Text = FormatNumber(CStr(v_strDEPORATE), 0)
                    Me.txtTRADELINE.Text = FormatNumber(CStr(v_strFLOORLIMIT), 0)
                    Me.txtDEPOSITLINE.Text = FormatNumber(CStr(v_strDEPOSITLINE), 0)
                    Me.txtONLINELIMIT.Text = FormatNumber(CStr(v_strONLINELIMIT), 0)
                    Me.txtTELELIMIT.Text = FormatNumber(CStr(v_strTELELIMIT), 0)
                    Me.txtFEEBASE.Text = FormatNumber(CStr(v_strTIEDFEEBASE), 0)
                    Me.txtMRIRATE.Text = FormatNumber(CStr(v_strMRIRATE), 0)
                    Me.txtMRMRATE.Text = FormatNumber(CStr(v_strMRMRATE), 0)
                    Me.txtMRLRATE.Text = FormatNumber(CStr(v_strMRLRATE), 0)
                    'Me.txtMRDUEDAY.Text = FormatNumber(CStr(v_strDUEDAY), 0)
                    'Me.txtMREXTDAY.Text = FormatNumber(CStr(v_strEXTDAY), 0)
                    If (ExeFlag = ExecuteFlag.AddNew) Then
                        Me.txtADVANCELINE.Text = FormatNumber(CStr(v_strADVANCEDLINE), 0)
                    End If

                    Me.txtMRIRATIO.Text = FormatNumber(CStr(v_strMRIRATIO), 0)
                    Me.txtMRMRATIO.Text = FormatNumber(CStr(v_strMRMRATIO), 0)
                    Me.txtMRLRATIO.Text = FormatNumber(CStr(v_strMRLRATIO), 0)

                    Me.txtTRFBUYEXT.Text = FormatNumber(CStr(v_strTRFBUYEXT), 0)
                    Me.txtTRFBUYRATE.Text = FormatNumber(CStr(v_strTRFBUYRATE), 0)

                End If
                'Bo doan check nay vi giai ngan theo tung deal, nen mot khach hang tai mot chi nhanh co the co 2 hop dong cung kieu Margin Loan.
                'If ExeFlag = ExecuteFlag.AddNew Then
                '    If v_strAFTYPE = "001" And v_strACTYPE <> "0000" Then
                '        'KhÃ´ng cho má»Ÿ hai há»£p Ä‘á»“ng Individual trong mot chi nhanh
                '        Dim v_strNum As String
                '        Dim v_strBRID As String
                '        v_strBRID = Me.BranchId
                '        v_strNum = String.Empty
                '        v_strCmdInquiry = "SELECT COUNT(ACCTNO) NUM FROM AFMAST,AFTYPE AFT, MRTYPE MRT WHERE AFMAST.ACTYPE=AFT.ACTYPE AND AFT.MRTYPE=MRT.ACTYPE AND MRT.MRTYPE='" & v_strMarginType & "' AND AFMAST.CUSTID='" & v_strCUSTID & "' AND AFMAST.AFTYPE='" & v_strAFTYPE & "' AND AFMAST.STATUS <> 'C' AND AFMAST.STATUS <>'R' AND SUBSTR(AFMAST.ACCTNO,1,4) ='" & v_strBRID & "'"
                '        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_AFTYPE, gc_ActionInquiry, v_strCmdInquiry)
                '        v_ws.Message(v_strObjMsg)
                '        v_xmlDocument.LoadXml(v_strObjMsg)
                '        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                '        For i As Integer = 0 To v_nodeList.Count - 1
                '            For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                '                With v_nodeList.Item(i).ChildNodes(j)
                '                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                '                    v_strVALUE = CStr(Trim(.InnerText))
                '                    Select Case v_strFLDNAME
                '                        Case "NUM"
                '                            v_strNum = v_strVALUE
                '                    End Select
                '                End With
                '            Next
                '        Next
                '        If v_strNum <> "0" Then
                '            MsgBox(ResourceManager.GetString("CUST_HAS_INDIVIDUAL_CONTRACT"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                '            Exit Sub
                '        End If
                '    End If
                'End If
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                                    & "Error code: System error!" & vbNewLine _
                                    & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ResourceManager.GetString("SavingFailed"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_xmlDocument = Nothing
            v_ws = Nothing
        End Try
    End Sub


    Private Sub LoadAFSERULE(ByVal pv_strAFACCTNO As String, ByVal pv_strACTYPE As String)
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_int, v_intCount As Integer
            Dim v_strCDCONTENT, v_strFLDNAME, v_strVALUE, v_strCmdInquiry, v_strObjMsg As String

            If Not AFSERuleGrid Is Nothing And Len(pv_strAFACCTNO) > 0 Then
                'Clear old data
                AFSERuleGrid.DataRows.Clear()
                v_strCmdInquiry = "SELECT a.autoid, c1.cdcontent bors, c3.cdcontent typormst, a.typormst typormstcd, a.refid, sb.symbol codeid, c2.cdcontent POLICYCD, a.termval, a.termratio, a.effdate, a.expdate " & ControlChars.CrLf _
                                & "FROM aftype aft, afserule a, allcode c1, allcode c2, allcode c3, sbsecurities sb " & ControlChars.CrLf _
                                & "where aft.actype = '" & pv_strACTYPE & "' and a.codeid = sb.codeid and c1.cdtype = 'SA' and c1.cdname = 'BORS' and c1.cdval = a.bors " & ControlChars.CrLf _
                                & "and c2.cdtype = 'CF' and c2.cdname = 'REFPOLICYCD' and c2.cdval = aft.POLICYCD " & ControlChars.CrLf _
                                & "and c3.cdtype = 'SY' and c3.cdname = 'TYPORMST' and c3.cdval = a.typormst and ((a.refid = '" & pv_strAFACCTNO & "' and a.typormst = 'M') or (a.refid = '" & pv_strACTYPE & "' and a.typormst = 'T'))"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, MyBase.LocalObject, gc_MsgTypeObj, "CF.AFSERULE", gc_ActionInquiry, v_strCmdInquiry)
                v_ws.Message(v_strObjMsg)
                FillDataGrid(AFSERuleGrid, v_strObjMsg, "")
                mv_blnRefreshTabPage_AFSERule = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_xmlDocument = Nothing
            v_ws = Nothing
        End Try
    End Sub


    'Lay thong tin duoc dinh nghia tu loai hinh
    Private Sub LoadICCFType(ByVal pv_AFAcctno As String, ByVal pv_strModCode As String)
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            If Not ICCFTYPEDEF_Grid Is Nothing And Len(pv_strModCode) > 0 And Len(pv_AFAcctno) > 0 Then
                'Remove cÃ¡c báº£n ghi cÅ©
                ICCFTYPEDEF_Grid.DataRows.Clear()
                Dim v_strSQL As String
                If pv_strModCode = "CI" Or pv_strModCode = "SE" Then
                    v_strSQL = " SELECT T1.*, " & ControlChars.CrLf _
                        & " (CASE WHEN T2.OPERAND='=' THEN T2.DELTA " & ControlChars.CrLf _
                        & "       WHEN T2.OPERAND='+' THEN T1.TIERRATEMAX + T2.DELTA   " & ControlChars.CrLf _
                        & "       WHEN T2.OPERAND='-' THEN T1.TIERRATEMAX - T2.DELTA  " & ControlChars.CrLf _
                        & "       ELSE T1.TIERRATEMAX END) AFTIERRATEMAX, " & ControlChars.CrLf _
                        & " (CASE WHEN T2.OPERAND='=' THEN T2.DELTA " & ControlChars.CrLf _
                        & "       WHEN T2.OPERAND='+' THEN T1.TIERRATEMIN + T2.DELTA   " & ControlChars.CrLf _
                        & "       WHEN T2.OPERAND='-' THEN T1.TIERRATEMIN - T2.DELTA  " & ControlChars.CrLf _
                        & "       ELSE T1.TIERRATEMIN END) AFTIERRATEMIN " & ControlChars.CrLf _
                        & ",SYS.FLRRATE SYSFLRRATE,SYS.CELRATE SYSCELRATE,SYS.FLRAMT SYSFLRAMT,SYS.CELAMT SYSCELAMT  " & ControlChars.CrLf _
                        & "  FROM  " & ControlChars.CrLf _
                        & " (SELECT C.*,NVL(D.FLOATRATE,0) FLOATRATE,TIERMAX+NVL(D.FLOATRATE,0) TIERRATEMAX,TIERMIN+NVL(D.FLOATRATE,0) TIERRATEMIN  " & ControlChars.CrLf _
                        & " FROM (SELECT A.*,A.ICRATE+NVL(B.MAXDELTA,0) TIERMAX,A.ICRATE+NVL(B.MINDELTA,0) TIERMIN FROM (SELECT IC.*,APP.EVENTNAME APPEVENTNAME, CD0.CDCONTENT DESC_MONTHDAY, CD1.CDCONTENT DESC_YEARDAY, CD2.CDCONTENT DESC_PERIOD,   " & ControlChars.CrLf _
                        & " CD3.CDCONTENT DESC_RULETYPE, CD4.CDCONTENT DESC_ICTYPE, CD5.CDCONTENT DESC_ICRATECD, CD6.CDCONTENT DESC_ICCFSTATUS   " & ControlChars.CrLf _
                        & " FROM AFMAST MST,AFTYPE AFTYP," & pv_strModCode & "TYPE CITYP,ICCFTYPEDEF IC,APPEVENTS APP, ALLCODE CD0, ALLCODE CD1, ALLCODE CD2, ALLCODE CD3, ALLCODE CD4, ALLCODE CD5, ALLCODE CD6   " & ControlChars.CrLf _
                        & " WHERE MST.ACCTNO='" & pv_AFAcctno & "' AND MST.actype=AFTYP.ACTYPE " & ControlChars.CrLf _
                        & " AND CD0.CDTYPE='SA' AND CD0.CDNAME='MONTHDAY' AND TRIM(CD0.CDVAL)=TRIM(IC.MONTHDAY)   " & ControlChars.CrLf _
                        & " AND IC.EVENTCODE=APP.EVENTCODE AND IC.MODCODE=APP.MODCODE   AND AFTYP." & pv_strModCode & "TYPE=CITYP.actype " & ControlChars.CrLf _
                        & " AND CD1.CDTYPE='SA' AND CD1.CDNAME='YEARDAY' AND TRIM(CD1.CDVAL)=TRIM(IC.YEARDAY)   " & ControlChars.CrLf _
                        & " AND CD2.CDTYPE='SA' AND CD2.CDNAME='PERIOD' AND TRIM(CD2.CDVAL)=TRIM(IC.PERIOD)   " & ControlChars.CrLf _
                        & " AND CD3.CDTYPE='SA' AND CD3.CDNAME='RULETYPE' AND TRIM(CD3.CDVAL)=TRIM(IC.RULETYPE)   " & ControlChars.CrLf _
                        & " AND CD4.CDTYPE='SA' AND CD4.CDNAME='ICTYPE' AND TRIM(CD4.CDVAL)=TRIM(IC.ICTYPE)   " & ControlChars.CrLf _
                        & " AND CD5.CDTYPE='SA' AND CD5.CDNAME='ICRATECD' AND TRIM(CD5.CDVAL)=TRIM(IC.ICRATECD)   " & ControlChars.CrLf _
                        & " AND CD6.CDTYPE='SA' AND CD6.CDNAME='ICCFSTATUS' AND TRIM(CD6.CDVAL)=TRIM(IC.ICCFSTATUS) AND IC.DELTD ='N'   " & ControlChars.CrLf _
                        & " AND IC.MODCODE='" & pv_strModCode & "' AND IC.ACTYPE=CITYP.ACTYPE) A  " & ControlChars.CrLf _
                        & " LEFT JOIN  " & ControlChars.CrLf _
                        & " (SELECT MAX(DELTA) MAXDELTA, MIN(DELTA) MINDELTA,MAX(ACTYPE) ACTYPE,MAX(EVENTCODE) EVENTCODE FROM ICCFTIER TIER WHERE TIER.MODCODE='" & pv_strModCode & "' ) B  " & ControlChars.CrLf _
                        & " ON A.EVENTCODE || A.ACTYPE =B.EVENTCODE || B.ACTYPE) C  " & ControlChars.CrLf _
                        & " LEFT JOIN   " & ControlChars.CrLf _
                        & " (SELECT NVL(RATE,0) FLOATRATE,AUTOID FROM (SELECT * FROM ICCFTYPEDEF IC WHERE ICRATECD='F') IC LEFT JOIN IRRATE  " & ControlChars.CrLf _
                        & " ON IC.ICRATEID=IRRATE.RATEID) D  " & ControlChars.CrLf _
                        & " ON C.AUTOID=D.AUTOID ) T1 " & ControlChars.CrLf _
                        & " LEFT JOIN " & ControlChars.CrLf _
                        & " (SELECT * FROM EXAFMAST EX WHERE AFACCTNO='" & pv_AFAcctno & "' AND EX.modcode='" & pv_strModCode & "' AND EX.extype='C') T2 " & ControlChars.CrLf _
                        & " ON T1.EVENTCODE=T2.EVENTCODE " & ControlChars.CrLf _
                        & "LEFT JOIN   " & ControlChars.CrLf _
                        & "(SELECT FLRRATE,CELRATE,FLRAMT,CELAMT,MODCODE,EVENTCODE FROM EVENTSYS SYS  WHERE MODCODE='CF') SYS  " & ControlChars.CrLf _
                        & "ON SYS.EVENTCODE=T1.EVENTCODE  " & ControlChars.CrLf
                ElseIf pv_strModCode = "CF" Then
                    v_strSQL = " SELECT T1.*, " & ControlChars.CrLf _
                        & " (CASE WHEN T2.OPERAND='=' THEN T2.DELTA " & ControlChars.CrLf _
                        & "       WHEN T2.OPERAND='+' THEN T1.TIERRATEMAX + T2.DELTA   " & ControlChars.CrLf _
                        & "       WHEN T2.OPERAND='-' THEN T1.TIERRATEMAX - T2.DELTA  " & ControlChars.CrLf _
                        & "       ELSE T1.TIERRATEMAX END) AFTIERRATEMAX, " & ControlChars.CrLf _
                        & " (CASE WHEN T2.OPERAND='=' THEN T2.DELTA " & ControlChars.CrLf _
                        & "       WHEN T2.OPERAND='+' THEN T1.TIERRATEMIN + T2.DELTA   " & ControlChars.CrLf _
                        & "       WHEN T2.OPERAND='-' THEN T1.TIERRATEMIN - T2.DELTA  " & ControlChars.CrLf _
                        & "       ELSE T1.TIERRATEMIN END) AFTIERRATEMIN " & ControlChars.CrLf _
                        & ",SYS.FLRRATE SYSFLRRATE,SYS.CELRATE SYSCELRATE,SYS.FLRAMT SYSFLRAMT,SYS.CELAMT SYSCELAMT  " & ControlChars.CrLf _
                        & "  FROM  " & ControlChars.CrLf _
                        & " (SELECT C.*,NVL(D.FLOATRATE,0) FLOATRATE,TIERMAX+NVL(D.FLOATRATE,0) TIERRATEMAX,TIERMIN+NVL(D.FLOATRATE,0) TIERRATEMIN  " & ControlChars.CrLf _
                        & " FROM (SELECT A.*,A.ICRATE+NVL(B.MAXDELTA,0) TIERMAX,A.ICRATE+NVL(B.MINDELTA,0) TIERMIN FROM (SELECT IC.*,APP.EVENTNAME APPEVENTNAME, CD0.CDCONTENT DESC_MONTHDAY, CD1.CDCONTENT DESC_YEARDAY, CD2.CDCONTENT DESC_PERIOD,   " & ControlChars.CrLf _
                        & " CD3.CDCONTENT DESC_RULETYPE, CD4.CDCONTENT DESC_ICTYPE, CD5.CDCONTENT DESC_ICRATECD, CD6.CDCONTENT DESC_ICCFSTATUS   " & ControlChars.CrLf _
                        & " FROM AFMAST MST,AFTYPE AFTYP,ICCFTYPEDEF IC,APPEVENTS APP, ALLCODE CD0, ALLCODE CD1, ALLCODE CD2, ALLCODE CD3, ALLCODE CD4, ALLCODE CD5, ALLCODE CD6   " & ControlChars.CrLf _
                        & " WHERE MST.ACCTNO='" & pv_AFAcctno & "' AND MST.actype=AFTYP.ACTYPE " & ControlChars.CrLf _
                        & " AND CD0.CDTYPE='SA' AND CD0.CDNAME='MONTHDAY' AND TRIM(CD0.CDVAL)=TRIM(IC.MONTHDAY)   " & ControlChars.CrLf _
                        & " AND IC.EVENTCODE=APP.EVENTCODE AND IC.MODCODE=APP.MODCODE " & ControlChars.CrLf _
                        & " AND CD1.CDTYPE='SA' AND CD1.CDNAME='YEARDAY' AND TRIM(CD1.CDVAL)=TRIM(IC.YEARDAY)   " & ControlChars.CrLf _
                        & " AND CD2.CDTYPE='SA' AND CD2.CDNAME='PERIOD' AND TRIM(CD2.CDVAL)=TRIM(IC.PERIOD)   " & ControlChars.CrLf _
                        & " AND CD3.CDTYPE='SA' AND CD3.CDNAME='RULETYPE' AND TRIM(CD3.CDVAL)=TRIM(IC.RULETYPE)   " & ControlChars.CrLf _
                        & " AND CD4.CDTYPE='SA' AND CD4.CDNAME='ICTYPE' AND TRIM(CD4.CDVAL)=TRIM(IC.ICTYPE)   " & ControlChars.CrLf _
                        & " AND CD5.CDTYPE='SA' AND CD5.CDNAME='ICRATECD' AND TRIM(CD5.CDVAL)=TRIM(IC.ICRATECD)   " & ControlChars.CrLf _
                        & " AND CD6.CDTYPE='SA' AND CD6.CDNAME='ICCFSTATUS' AND TRIM(CD6.CDVAL)=TRIM(IC.ICCFSTATUS) AND IC.DELTD ='N'   " & ControlChars.CrLf _
                        & " AND IC.MODCODE='" & pv_strModCode & "' AND IC.ACTYPE=AFTYP.ACTYPE ) A  " & ControlChars.CrLf _
                        & " LEFT JOIN  " & ControlChars.CrLf _
                        & " (SELECT MAX(DELTA) MAXDELTA, MIN(DELTA) MINDELTA,MAX(ACTYPE) ACTYPE,MAX(EVENTCODE) EVENTCODE FROM ICCFTIER TIER WHERE TIER.MODCODE='" & pv_strModCode & "' ) B  " & ControlChars.CrLf _
                        & " ON A.EVENTCODE || A.ACTYPE =B.EVENTCODE || B.ACTYPE) C  " & ControlChars.CrLf _
                        & " LEFT JOIN   " & ControlChars.CrLf _
                        & " (SELECT NVL(RATE,0) FLOATRATE,AUTOID FROM (SELECT * FROM ICCFTYPEDEF IC WHERE ICRATECD='F') IC LEFT JOIN IRRATE  " & ControlChars.CrLf _
                        & " ON IC.ICRATEID=IRRATE.RATEID) D  " & ControlChars.CrLf _
                        & " ON C.AUTOID=D.AUTOID ) T1 " & ControlChars.CrLf _
                        & " LEFT JOIN " & ControlChars.CrLf _
                        & " (SELECT * FROM EXAFMAST EX WHERE AFACCTNO='" & pv_AFAcctno & "' AND EX.modcode='" & pv_strModCode & "' AND EX.extype='C') T2 " & ControlChars.CrLf _
                        & " ON T1.EVENTCODE=T2.EVENTCODE " & ControlChars.CrLf _
                        & "LEFT JOIN   " & ControlChars.CrLf _
                        & "(SELECT FLRRATE,CELRATE,FLRAMT,CELAMT,MODCODE,EVENTCODE FROM EVENTSYS SYS  WHERE MODCODE='CF') SYS  " & ControlChars.CrLf _
                        & "ON SYS.EVENTCODE=T1.EVENTCODE  " & ControlChars.CrLf
                Else
                    v_strSQL = " SELECT T1.*, " & ControlChars.CrLf _
                        & " (CASE WHEN T2.OPERAND='=' THEN T2.DELTA " & ControlChars.CrLf _
                        & "       WHEN T2.OPERAND='+' THEN T1.TIERRATEMAX + T2.DELTA   " & ControlChars.CrLf _
                        & "       WHEN T2.OPERAND='-' THEN T1.TIERRATEMAX - T2.DELTA  " & ControlChars.CrLf _
                        & "       ELSE T1.TIERRATEMAX END) AFTIERRATEMAX, " & ControlChars.CrLf _
                        & " (CASE WHEN T2.OPERAND='=' THEN T2.DELTA " & ControlChars.CrLf _
                        & "       WHEN T2.OPERAND='+' THEN T1.TIERRATEMIN + T2.DELTA   " & ControlChars.CrLf _
                        & "       WHEN T2.OPERAND='-' THEN T1.TIERRATEMIN - T2.DELTA  " & ControlChars.CrLf _
                        & "       ELSE T1.TIERRATEMIN END) AFTIERRATEMIN " & ControlChars.CrLf _
                        & ",SYS.FLRRATE SYSFLRRATE,SYS.CELRATE SYSCELRATE,SYS.FLRAMT SYSFLRAMT,SYS.CELAMT SYSCELAMT  " & ControlChars.CrLf _
                        & "  FROM  " & ControlChars.CrLf _
                        & " (SELECT C.*,NVL(D.FLOATRATE,0) FLOATRATE,TIERMAX+NVL(D.FLOATRATE,0) TIERRATEMAX,TIERMIN+NVL(D.FLOATRATE,0) TIERRATEMIN  " & ControlChars.CrLf _
                        & " FROM (SELECT A.*,A.ICRATE+NVL(B.MAXDELTA,0) TIERMAX,A.ICRATE+NVL(B.MINDELTA,0) TIERMIN FROM (SELECT IC.*,APP.EVENTNAME APPEVENTNAME, CD0.CDCONTENT DESC_MONTHDAY, CD1.CDCONTENT DESC_YEARDAY, CD2.CDCONTENT DESC_PERIOD,   " & ControlChars.CrLf _
                        & " CD3.CDCONTENT DESC_RULETYPE, CD4.CDCONTENT DESC_ICTYPE, CD5.CDCONTENT DESC_ICRATECD, CD6.CDCONTENT DESC_ICCFSTATUS   " & ControlChars.CrLf _
                        & " FROM AFMAST MST,AFTYPE AFTYP,REGTYPE REGTYP,ICCFTYPEDEF IC,APPEVENTS APP, ALLCODE CD0, ALLCODE CD1, ALLCODE CD2, ALLCODE CD3, ALLCODE CD4, ALLCODE CD5, ALLCODE CD6   " & ControlChars.CrLf _
                        & " WHERE MST.ACCTNO='" & pv_AFAcctno & "' AND MST.actype=AFTYP.ACTYPE " & ControlChars.CrLf _
                        & " AND CD0.CDTYPE='SA' AND CD0.CDNAME='MONTHDAY' AND TRIM(CD0.CDVAL)=TRIM(IC.MONTHDAY)   " & ControlChars.CrLf _
                        & " AND IC.EVENTCODE=APP.EVENTCODE AND IC.MODCODE=APP.MODCODE   AND AFTYP.ACTYPE=REGTYP.AFTYPE AND REGTYP.MODCODE='" & pv_strModCode & "' " & ControlChars.CrLf _
                        & " AND CD1.CDTYPE='SA' AND CD1.CDNAME='YEARDAY' AND TRIM(CD1.CDVAL)=TRIM(IC.YEARDAY)   " & ControlChars.CrLf _
                        & " AND CD2.CDTYPE='SA' AND CD2.CDNAME='PERIOD' AND TRIM(CD2.CDVAL)=TRIM(IC.PERIOD)   " & ControlChars.CrLf _
                        & " AND CD3.CDTYPE='SA' AND CD3.CDNAME='RULETYPE' AND TRIM(CD3.CDVAL)=TRIM(IC.RULETYPE)   " & ControlChars.CrLf _
                        & " AND CD4.CDTYPE='SA' AND CD4.CDNAME='ICTYPE' AND TRIM(CD4.CDVAL)=TRIM(IC.ICTYPE)   " & ControlChars.CrLf _
                        & " AND CD5.CDTYPE='SA' AND CD5.CDNAME='ICRATECD' AND TRIM(CD5.CDVAL)=TRIM(IC.ICRATECD)   " & ControlChars.CrLf _
                        & " AND CD6.CDTYPE='SA' AND CD6.CDNAME='ICCFSTATUS' AND TRIM(CD6.CDVAL)=TRIM(IC.ICCFSTATUS) AND IC.DELTD ='N'   " & ControlChars.CrLf _
                        & " AND IC.MODCODE='" & pv_strModCode & "' AND IC.ACTYPE=REGTYP.ACTYPE ) A  " & ControlChars.CrLf _
                        & " LEFT JOIN  " & ControlChars.CrLf _
                        & " (SELECT MAX(DELTA) MAXDELTA, MIN(DELTA) MINDELTA,MAX(ACTYPE) ACTYPE,MAX(EVENTCODE) EVENTCODE FROM ICCFTIER TIER WHERE TIER.MODCODE='" & pv_strModCode & "' ) B  " & ControlChars.CrLf _
                        & " ON A.EVENTCODE || A.ACTYPE =B.EVENTCODE || B.ACTYPE) C  " & ControlChars.CrLf _
                        & " LEFT JOIN   " & ControlChars.CrLf _
                        & " (SELECT NVL(RATE,0) FLOATRATE,AUTOID FROM (SELECT * FROM ICCFTYPEDEF IC WHERE ICRATECD='F') IC LEFT JOIN IRRATE  " & ControlChars.CrLf _
                        & " ON IC.ICRATEID=IRRATE.RATEID) D  " & ControlChars.CrLf _
                        & " ON C.AUTOID=D.AUTOID ) T1 " & ControlChars.CrLf _
                        & " LEFT JOIN " & ControlChars.CrLf _
                        & " (SELECT * FROM EXAFMAST EX WHERE AFACCTNO='" & pv_AFAcctno & "' AND EX.modcode='" & pv_strModCode & "' AND EX.extype='C') T2 " & ControlChars.CrLf _
                        & " ON T1.EVENTCODE=T2.EVENTCODE " & ControlChars.CrLf _
                        & "LEFT JOIN   " & ControlChars.CrLf _
                        & "(SELECT FLRRATE,CELRATE,FLRAMT,CELAMT,MODCODE,EVENTCODE FROM EVENTSYS SYS  WHERE MODCODE='CF') SYS  " & ControlChars.CrLf _
                        & "ON SYS.EVENTCODE=T1.EVENTCODE  " & ControlChars.CrLf

                End If
                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, MyBase.LocalObject, gc_MsgTypeObj, OBJNAME_SA_ICCFTYPEDEF, gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                FillDataGrid(ICCFTYPEDEF_Grid, v_strObjMsg, "")
                mv_blnRefreshTabPage_AFDefICCF = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_ws = Nothing
        End Try
    End Sub

    'Kiem tra cac control tren man hinh
    Private Function ControlValidation(Optional ByVal pv_blnSaved As Boolean = False) As Boolean
        Dim v_ws As New BDSDeliveryManagement
        Dim v_xmlDocument As New Xml.XmlDocument
        Try
            If ExeFlag = ExecuteFlag.Edit Then
                'Me.txtPHONE1.Enabled = False
                'Me.txtTRADEPHONE.Enabled = False
                Me.txtPIN.Enabled = False
                Me.txtCFONLINELIMIT.Enabled = False
                Me.txtCFTELELIMIT.Enabled = False
                Me.cboTERMOFUSE.Enabled = False
            End If


            If pv_blnSaved Then
                If Len(Replace(Me.txtACCTNO.Text, ".", "")) <> 10 Then
                    MsgBox(ResourceManager.GetString("ACCTNO_INVALID"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    Me.txtACCTNO.Focus()
                    Return False
                End If
                'If Me.cboTRADETELEPHONE.SelectedValue = "Y" Then
                '    If Me.txtTRADEPHONE.Text = "" Then
                '        MsgBox(Replace(ResourceManager.GetString("Mandatory"), "@", ResourceManager.GetString("TRADETELEPHONE")), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                '        Me.txtTRADEPHONE.Focus()
                '        Return False
                '    End If
                'End If

                If ExeFlag = ExecuteFlag.AddNew Or ExeFlag = ExecuteFlag.Edit Then
                    If Me.cboCAREBY.SelectedValue Is Nothing Then
                        MsgBox(ResourceManager.GetString("CAREBY_IS_NULL"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                        Me.cboCAREBY.Focus()
                        Return False
                    End If
                    Dim v_strSQL, v_strObjMsg, v_strCUSTODY, v_strCUSTID As String
                    v_strCUSTODY = UCase(Replace(Trim(txtCUSTODYCD.Text), ".", ""))
                    v_strCUSTODY = UCase(Replace(Trim(v_strCUSTODY), ",", ""))
                    v_strCUSTID = Replace(Trim(txtCUSTID.Text), ".", "")
                    v_strCUSTID = Replace(Trim(v_strCUSTID), ",", "")

                    'Dien comment  7-10-2010
                    If Me.cboTRADETELEPHONE.SelectedValue = "Y" Then
                        If Me.txtTRADEPHONE.Text = "" Then
                            MsgBox(ResourceManager.GetString("PHONENUMBER_INVALID"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                            Me.txtTRADEPHONE.Focus()
                            Return False
                        End If
                    End If

                    'end comment Dien

                    If (Me.cboISOTC.SelectedValue = "N" Or (Me.cboISOTC.SelectedValue = "Y" And Trim(txtCUSTODYCD.Text) <> "")) Then
                        If Len(v_strCUSTODY) <> 10 Then
                            MsgBox(ResourceManager.GetString("CUSTODYCD_INVALID"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                            Me.txtCUSTODYCD.Focus()
                            Return False
                        Else
                            Dim v_nodeList As Xml.XmlNodeList
                            Dim v_strFLDNAME, v_strVALUE, v_strNum, v_strIDEXPIRED As String
                            'BDSDelivery.BDSDelivery
                            v_strNum = "0"
                            'Check duplicate CUSTODYCD 
                            v_strSQL = "SELECT COUNT(CUSTODYCD) NUM FROM CFMAST WHERE UPPER(CUSTODYCD) ='" & v_strCUSTODYCD & "' AND CUSTID <> '" & v_strCUSTID & "'"
                            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strSQL)
                            v_ws.Message(v_strObjMsg)
                            v_xmlDocument.LoadXml(v_strObjMsg)
                            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                            For i As Integer = 0 To v_nodeList.Count - 1
                                For j As Integer = 0 To v_nodeList.Item(j).ChildNodes.Count - 1
                                    With v_nodeList.Item(j).ChildNodes(i)
                                        v_strFLDNAME = v_nodeList.Item(j).ChildNodes(i).Attributes.GetNamedItem("fldname").Value.Trim()
                                        v_strVALUE = v_nodeList.Item(j).ChildNodes(i).Attributes.GetNamedItem("oldval").Value.Trim()
                                        Select Case v_strFLDNAME
                                            Case "NUM"
                                                v_strNum = v_strVALUE
                                        End Select
                                    End With
                                Next
                            Next
                            If v_strNum <> "0" Then
                                MsgBox(ResourceManager.GetString("CUSTODYCD_INVALID"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                Me.txtCUSTODYCD.Focus()
                                Return False
                            End If

                            v_strSQL = "SELECT COUNT(CUSTID) NUM FROM CFMAST WHERE CUSTID ='" & v_strCUSTID & "'"
                            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strSQL)
                            v_ws.Message(v_strObjMsg)
                            v_xmlDocument.LoadXml(v_strObjMsg)
                            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                            For i As Integer = 0 To v_nodeList.Count - 1
                                For j As Integer = 0 To v_nodeList.Item(j).ChildNodes.Count - 1
                                    With v_nodeList.Item(j).ChildNodes(i)
                                        v_strFLDNAME = v_nodeList.Item(j).ChildNodes(i).Attributes.GetNamedItem("fldname").Value.Trim()
                                        v_strVALUE = v_nodeList.Item(j).ChildNodes(i).Attributes.GetNamedItem("oldval").Value.Trim()
                                        Select Case v_strFLDNAME
                                            Case "NUM"
                                                v_strNum = v_strVALUE
                                        End Select
                                    End With
                                Next
                            Next
                            If v_strNum = "0" Then
                                MsgBox(ResourceManager.GetString("CUST_HAS_INDIVIDUAL_CONTRACT"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                Me.txtCUSTID.Focus()
                                Return False
                            End If

                            v_strSQL = "SELECT to_char(IDEXPIRED,'DD/MM/RRRR') IDEXPIRED FROM CFMAST WHERE CUSTID ='" & v_strCUSTID & "'"
                            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strSQL)
                            v_ws.Message(v_strObjMsg)
                            v_xmlDocument.LoadXml(v_strObjMsg)
                            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                            For i As Integer = 0 To v_nodeList.Count - 1
                                For j As Integer = 0 To v_nodeList.Item(j).ChildNodes.Count - 1
                                    With v_nodeList.Item(j).ChildNodes(i)
                                        v_strFLDNAME = v_nodeList.Item(j).ChildNodes(i).Attributes.GetNamedItem("fldname").Value.Trim()
                                        v_strVALUE = v_nodeList.Item(j).ChildNodes(i).Attributes.GetNamedItem("oldval").Value.Trim()
                                        Select Case v_strFLDNAME
                                            Case "IDEXPIRED"
                                                v_strIDEXPIRED = v_strVALUE
                                        End Select
                                    End With
                                Next
                            Next
                            If DDMMYYYY_SystemDate(v_strIDEXPIRED) <= DDMMYYYY_SystemDate(BusDate) Then
                                If MessageBox.Show(ResourceManager.GetString("IDEXPIREDLESSTHANBUSDATE"), Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) <> Windows.Forms.DialogResult.OK Then
                                    Return False
                                End If
                            End If

                        End If
                    End If
                End If
                Return MyBase.VerifyRules
            End If
            Return True
        Catch ex As Exception
            Throw ex
            Return False
        Finally
            v_xmlDocument = Nothing
            v_ws = Nothing
        End Try
    End Function

    'Kiem tra so hop dong co ton tai khong
    Private Function CheckContracNumber(ByVal pv_strACCTNO As String) As Boolean
        Dim v_ws As New BDSDeliveryManagement
        Dim v_xmlDocument As New Xml.XmlDocument
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strFLDNAME, v_strVALUE, v_strContracNumber As String
            Dim v_strCmdInquiry As String = "Select COUNT(ACCTNO) ACCTNO  from AFMAST where ACCTNO = '" & pv_strACCTNO & "'"
            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_AFMAST, gc_ActionInquiry, v_strCmdInquiry)
            v_strContracNumber = String.Empty
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Count - 1
                For j As Integer = 0 To v_nodeList.Item(j).ChildNodes.Count - 1
                    With v_nodeList.Item(j).ChildNodes(i)
                        v_strFLDNAME = v_nodeList.Item(j).ChildNodes(i).Attributes.GetNamedItem("fldname").Value.Trim()
                        v_strVALUE = v_nodeList.Item(j).ChildNodes(i).Attributes.GetNamedItem("oldval").Value.Trim()
                        Select Case v_strFLDNAME
                            Case "ACCTNO"
                                v_strContracNumber = v_strVALUE
                        End Select
                    End With
                Next
            Next
            If CDbl(v_strContracNumber) > 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                        & "Error code: System error!" & vbNewLine _
                        & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ResourceManager.GetString("SavingFailed"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_xmlDocument = Nothing
            v_ws = Nothing
        End Try
    End Function

    'Kiem tra so TK luu ky co ton tai khong
    Private Function CheckCustodyCD(ByVal pv_strCustodycd As String) As Boolean
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strFLDNAME, v_strVALUE, v_strContracNumber, v_strNum As String
            Dim v_strCmdInquiry As String = "Select COUNT(CUSTODYCD) NUM  from CFMAST where CUSTODYCD = '" & pv_strCustodycd & "'"
            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_AFMAST, gc_ActionInquiry, v_strCmdInquiry)
            v_strContracNumber = String.Empty
            v_strNum = "0"
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Count - 1
                For j As Integer = 0 To v_nodeList.Item(j).ChildNodes.Count - 1
                    With v_nodeList.Item(j).ChildNodes(i)
                        v_strFLDNAME = v_nodeList.Item(j).ChildNodes(i).Attributes.GetNamedItem("fldname").Value.Trim()
                        v_strVALUE = v_nodeList.Item(j).ChildNodes(i).Attributes.GetNamedItem("oldval").Value.Trim()
                        Select Case v_strFLDNAME
                            Case "NUM"
                                v_strNum = v_strVALUE
                        End Select
                    End With
                Next
            Next
            If v_strNum <> "0" Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                        & "Error code: System error!" & vbNewLine _
                        & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ResourceManager.GetString("SavingFailed"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_xmlDocument = Nothing
            v_ws = Nothing
        End Try
    End Function

    'Tao so tai khoan lu ky
    Private Sub UPDATECUSTODYCD()
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQL, v_strObjMsg, v_strValue, v_strFLDNAME As String
            'v_strSQL = "UPDATE CFMAST SET CUSTODYCD ='" & Me.txtCUSTODYCD.Text & "' WHERE CUSTID='" & Me.txtCUSTID.Text & "'"
            If CheckCustodyCD(Me.txtCUSTODYCD.Text.Trim.Replace(".", "")) Then
                Dim v_strClause As String = v_strSQL
                'v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_AFMAST, gc_ActionAdhoc, v_strSQL, v_strClause, "UpdateCFMastCustodycode")
                'Thay không cho phép đẩy lệnh SQL lên HOST
                v_strObjMsg = BuildXMLObjMsg(Me.BusDate, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_AFMAST, gc_ActionAdhoc, , Me.txtCUSTID.Text, "UpdateCFMastCustodycode", , , Me.txtCUSTODYCD.Text.Trim.Replace(".", ""), Me.cboCUSTATCOM.SelectedValue)
                v_ws.Message(v_strObjMsg)
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                                    & "Error code: System error!" & vbNewLine _
                                    & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ResourceManager.GetString("SavingFailed"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_xmlDocument = Nothing
            v_ws = Nothing
        End Try
    End Sub

    Private Sub ExternalUpdate()
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQL, v_strObjMsg, v_strValue, v_strFLDNAME As String
            Dim v_strClause As String = v_strSQL
            v_strObjMsg = BuildXMLObjMsg(Me.BusDate, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_AFMAST, gc_ActionAdhoc, , Replace(Me.txtACCTNO.Text, ".", ""), "ExternalUpdateAFMAST", , , Me.cboAPPLYACCT.SelectedValue)
            v_ws.Message(v_strObjMsg)
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                                    & "Error code: System error!" & vbNewLine _
                                    & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ResourceManager.GetString("SavingFailed"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_xmlDocument = Nothing
            v_ws = Nothing
        End Try
    End Sub


    '----------------------------------------------------------------------------------------------
    'Kiểm tra tính hợp lệ của CustodyCode
    'v_blnDORF=TRUE nhà đầu tư nước ngoài, FALSE là trong nước
    'v_blnIOC=TRUE nhà đầu tư cá nhân, FALSE là tổ chức
    '----------------------------------------------------------------------------------------------
    Private Function VerifyCustodyCodeBeforeAdd() As Boolean
        Dim v_blnDORF, v_blnIOC As Boolean
        Dim v_strReturn As String = String.Empty
        Dim v_strCustAtCom As String
        Dim v_strSQL As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strFLDNAME, v_strVALUE As String
        Try

            'If v_strCOUNTRY.Trim() <> "VNM" Then
            If v_strCOUNTRY.Trim() <> "234" Then
                v_blnDORF = True
            Else
                v_blnDORF = False
            End If

            If v_strCUSTTYPE.Trim() = "I" Then
                v_blnIOC = True
            Else
                v_blnIOC = False
            End If

            Dim v_strPrefixCustodyCD As String = AppSettings.Get("PrefixedCustodyCode")
            v_strCustAtCom = Me.cboCUSTATCOM.SelectedValue

            v_strReturn = VerifyCustodyCode(Me.txtCUSTODYCD.Text.Replace(".", ""), v_blnDORF, v_blnIOC, v_strCustAtCom, v_strPrefixCustodyCD, ExeFlag)

            If Not v_strReturn Is Nothing Then
                MsgBox(ResourceManager.GetString(v_strReturn), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                Me.txtCUSTODYCD.Focus()
                Return False
            End If

            Return True

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                        & "Error code: System error!" & vbNewLine _
                        & "Error message: " & ex.Message, EventLogEntryType.Error)
            Return False
        End Try
    End Function

    Private Function preSaveCheck()
        If Me.cboTRADEFLOOR.SelectedValue = "N" And Me.cboTRADEONLINE.SelectedValue = "N" And Me.cboETS.SelectedValue = "N" And Me.cboTRADETELEPHONE.SelectedValue = "N" Then
            MsgBox(ResourceManager.GetString("TradingWayInvalid"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            Return -1
        End If

        'QuangVD 24/10/2012: check online register
        Dim v_ws
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strSQL As String
        If Not (Me.cboAPPLYPOLICY.Checked) Then
            If mv_blnRefreshTabPage_OTRight = True Then 'Da khoi tao grid tab dang ky dich vu truc tuyen
                If Me.cboTRADEONLINE.SelectedValue = "Y" And OTRightAuthGrid.DataRows.Count = 0 Then
                    MsgBox(ResourceManager.GetString("OnlineRegisterInvalid"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    Return -1
                End If
            Else    'Chua khoi tao grid tab dang ky dich vu truc tuyen   
                If Me.cboTRADEONLINE.SelectedValue = "Y" Then
                    Try
                        v_ws = New BDSDeliveryManagement
                        v_strSQL = "SELECT * FROM (" & ControlChars.CrLf _
                                & " SELECT OT.AUTOID, OT.AFACCTNO, OT.AUTHCUSTID, CF.FULLNAME, CF.IDCODE, CF.ADDRESS, CF.PHONE," & ControlChars.CrLf _
                                & "     TO_CHAR(OT.VALDATE,'DD/MM/YYYY') VALDATE, TO_CHAR(OT.EXPDATE,'DD/MM/YYYY') EXPDATE, A1.CDCONTENT AUTHTYPE" & ControlChars.CrLf _
                                & " FROM OTRIGHT OT, CFMAST CF, ALLCODE A1" & ControlChars.CrLf _
                                & " WHERE CF.CUSTID = OT.AUTHCUSTID" & ControlChars.CrLf _
                                & "     AND OT.DELTD = 'N' " & ControlChars.CrLf _
                                & "     AND A1.CDTYPE = 'CF' AND A1.CDNAME = 'AUTHTYPE' AND A1.CDVAL = CASE WHEN OT.AUTHCUSTID = '" & txtCUSTID.Text.Replace(".", "") & "' THEN 'OWNER' ELSE 'AUTHORIZED' END " & ControlChars.CrLf _
                                & "     AND TRIM(OT.AFACCTNO)='" & Me.txtACCTNO.Text.Trim & "' ) AU " & ControlChars.CrLf _
                                & " ORDER BY AU.AUTOID"
                        Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, MyBase.LocalObject, gc_MsgTypeObj, "CF.CFCONTACT", _
                            gc_ActionInquiry, v_strSQL)
                        v_ws.Message(v_strObjMsg)
                        v_xmlDocument.LoadXml(v_strObjMsg)
                        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                        If v_nodeList.Count = 0 Then
                            MsgBox(ResourceManager.GetString("OnlineRegisterInvalid"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                            Return -1
                        End If
                    Catch ex As Exception
                        Throw ex
                    Finally
                        v_ws = Nothing
                    End Try
                End If
            End If
        Else    'Ap theo tieu khoan mau
            If Not (Me.cboAPPLYACCT.SelectedValue Is Nothing) Then
                Try
                    v_ws = New BDSDeliveryManagement
                    v_strSQL = "SELECT * FROM OTRIGHT OT, AFMAST AF" & ControlChars.CrLf _
                            & " WHERE AF.ACCTNO = OT.AFACCTNO" & ControlChars.CrLf _
                            & " AND AF.TRADEONLINE = 'Y'" & ControlChars.CrLf _
                            & " AND TRIM(AF.ACCTNO)='" & Me.cboAPPLYACCT.SelectedValue.Trim & "'"
                    Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, MyBase.LocalObject, gc_MsgTypeObj, "CF.CFCONTACT", _
                        gc_ActionInquiry, v_strSQL)
                    v_ws.Message(v_strObjMsg)
                    v_xmlDocument.LoadXml(v_strObjMsg)
                    v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                    If v_nodeList.Count = 0 Then
                        MsgBox(ResourceManager.GetString("OnlineRegisterApplyInvalid"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                        Return -1
                    End If
                Catch ex As Exception
                    Throw ex
                Finally
                    v_ws = Nothing
                End Try
            Else    'Check theo tai khoan dang tao moi
                If mv_blnRefreshTabPage_OTRight = True Then 'Da khoi tao grid tab dang ky dich vu truc tuyen
                    If Me.cboTRADEONLINE.SelectedValue = "Y" And OTRightAuthGrid.DataRows.Count = 0 Then
                        MsgBox(ResourceManager.GetString("OnlineRegisterInvalid"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                        Return -1
                    End If
                Else    'Chua khoi tao grid tab dang ky dich vu truc tuyen   
                    If Me.cboTRADEONLINE.SelectedValue = "Y" Then
                        Try
                            v_ws = New BDSDeliveryManagement
                            v_strSQL = "SELECT * FROM (" & ControlChars.CrLf _
                                    & " SELECT OT.AUTOID, OT.AFACCTNO, OT.AUTHCUSTID, CF.FULLNAME, CF.IDCODE, CF.ADDRESS, CF.PHONE," & ControlChars.CrLf _
                                    & "     TO_CHAR(OT.VALDATE,'DD/MM/YYYY') VALDATE, TO_CHAR(OT.EXPDATE,'DD/MM/YYYY') EXPDATE, A1.CDCONTENT AUTHTYPE" & ControlChars.CrLf _
                                    & " FROM OTRIGHT OT, CFMAST CF, ALLCODE A1" & ControlChars.CrLf _
                                    & " WHERE CF.CUSTID = OT.AUTHCUSTID" & ControlChars.CrLf _
                                    & "     AND OT.DELTD = 'N' " & ControlChars.CrLf _
                                    & "     AND A1.CDTYPE = 'CF' AND A1.CDNAME = 'AUTHTYPE' AND A1.CDVAL = CASE WHEN OT.AUTHCUSTID = '" & txtCUSTID.Text.Replace(".", "") & "' THEN 'OWNER' ELSE 'AUTHORIZED' END " & ControlChars.CrLf _
                                    & "     AND TRIM(OT.AFACCTNO)='" & Me.txtACCTNO.Text.Trim & "' ) AU " & ControlChars.CrLf _
                                    & " ORDER BY AU.AUTOID"
                            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, MyBase.LocalObject, gc_MsgTypeObj, "CF.CFCONTACT", _
                                gc_ActionInquiry, v_strSQL)
                            v_ws.Message(v_strObjMsg)
                            v_xmlDocument.LoadXml(v_strObjMsg)
                            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                            If v_nodeList.Count = 0 Then
                                MsgBox(ResourceManager.GetString("OnlineRegisterInvalid"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                Return -1
                            End If
                        Catch ex As Exception
                            Throw ex
                        Finally
                            v_ws = Nothing
                        End Try
                    End If
                End If
            End If
        End If

        'TungNT added - for corebank
        If cboCOREBANK.SelectedValue.ToString() = "Y" Then
            If txtBANKACCTNO.Text.Trim().Length <= 0 Then
                MsgBox(ResourceManager.GetString("BankAcctNoCannotNull"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                Return -1
            End If

            If txtBANKACCTNO.Text.Trim().ToUpper() <> mv_strBankAcctno Or cboBANKNAME.SelectedValue.ToString().Trim.ToUpper() <> mv_strBankCode Then
                'Check authorize
                Dim v_strObjMsg As String = BuildXMLObjMsg(Me.BusDate, BranchId, , TellerId, gc_IsNotLocalMsg, _
                                                           gc_MsgTypeObj, OBJNAME_CF_AFMAST, gc_ActionAdhoc, , _
                                                           Me.txtCUSTID.Text, "CheckBankAcctAuthorize", , , _
                                                           Me.txtCUSTODYCD.Text.Trim.Replace(".", "") & "|" & _
                                                           Me.txtBANKACCTNO.Text.Trim() & "|" & _
                                                           Me.cboBANKNAME.SelectedValue.ToString().Trim())
                v_ws = New BDSDeliveryManagement
                Dim v_strErrorSource, v_strErrorMessage As String
                Dim v_lngError As Long = v_ws.Message(v_strObjMsg)
                If v_lngError <> ERR_SYSTEM_OK Then
                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage)
                    MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                    Return -1
                End If
            End If
        End If
        'End

    End Function

    'Ham nay dung de check xem nguoi uy quyen da duoc duyet hay chua, neu chua duyet thi tra ve TRUE
    Private Function CheckBeforeEditDelCFAuth() As Boolean

        Try
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_ws As New BDSDeliveryManagement
            Dim v_strKeyFieldValue, v_strCMDSQL As String
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strFLDNAME, v_strVALUE, v_strISAPPROVE As String
            v_strKeyFieldValue = CType(AnthorizeGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value

            v_strCMDSQL = "select count(1) ISAPPROVE from maintain_log a, cfauth b  " _
                        & "where a.table_name = 'AFMAST' and a.child_table_name = 'CFAUTH'  " _
                        & "and a.approve_id is null and a.column_name = 'AUTOID' and a.to_value = b.autoid  " _
                        & "and a.record_key = 'ACCTNO = ''' || b.acctno || '''' and b.autoid = '" & v_strKeyFieldValue & "'"

            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_AFMAST, gc_ActionInquiry, v_strCMDSQL)

            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Count - 1
                For j As Integer = 0 To v_nodeList.Item(j).ChildNodes.Count - 1
                    With v_nodeList.Item(j).ChildNodes(i)
                        v_strFLDNAME = v_nodeList.Item(j).ChildNodes(i).Attributes.GetNamedItem("fldname").Value.Trim()
                        v_strVALUE = v_nodeList.Item(j).ChildNodes(i).Attributes.GetNamedItem("oldval").Value.Trim()
                        Select Case v_strFLDNAME
                            Case "ISAPPROVE"
                                v_strISAPPROVE = v_strVALUE
                        End Select
                    End With
                Next
            Next
            If v_strISAPPROVE = "0" Then
                Return False
            Else
                Return True
            End If

            v_xmlDocument = Nothing
            v_ws = Nothing
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                        & "Error code: System error!" & vbNewLine _
                        & "Error message: " & ex.Message, EventLogEntryType.Error)
        End Try
    End Function

    Private Function FillGroupCareBy() As Boolean 'Dien comment 19-10-2010
        Try
            Dim v_strGroupId, v_strGroupName, v_arrGroupCareBy(), v_arrGroup() As String
            Dim v_strCareBy As String
            Dim v_strCareByText As String = ""
            Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery

            If Trim(GroupCareBy) <> String.Empty Then
                v_arrGroupCareBy = GroupCareBy.Split("#")
                If (ExeFlag = ExecuteFlag.AddNew) Then
                    cboCAREBY.Clears()
                    If v_arrGroupCareBy.Length > 1 Then
                        For i As Integer = 0 To v_arrGroupCareBy.Length - 2
                            v_arrGroup = CStr(v_arrGroupCareBy(i)).Split("|")
                            v_strGroupId = v_arrGroup(0)
                            v_strGroupName = v_arrGroup(1)
                            cboCAREBY.AddItems(v_strGroupName, v_strGroupId)
                        Next
                    End If
                ElseIf (ExeFlag = ExecuteFlag.View) Then
                    If (Not cboCAREBY.SelectedValue Is Nothing) And (Not cboCAREBY.SelectedValue Is DBNull.Value) Then
                        v_strCareBy = CStr(cboCAREBY.SelectedValue).Trim
                    End If
                    cboCAREBY.Enabled = False

                ElseIf (ExeFlag = ExecuteFlag.Edit) Then
                    If (Not cboCAREBY.SelectedValue Is Nothing) And (Not cboCAREBY.SelectedValue Is DBNull.Value) Then
                        v_strCareBy = CStr(cboCAREBY.SelectedValue).Trim
                        v_strCareByText = CStr(cboCAREBY.Text).Trim
                    End If
                    cboCAREBY.Clears()
                    cboCAREBY.Enabled = True
                    If v_arrGroupCareBy.Length > 1 Then

                        Dim v_blnOk As Boolean = False
                        For i As Integer = 0 To v_arrGroupCareBy.Length - 2
                            v_arrGroup = CStr(v_arrGroupCareBy(i)).Split("|")
                            v_strGroupId = v_arrGroup(0)
                            v_strGroupName = v_arrGroup(1)
                            cboCAREBY.AddItems(v_strGroupName, v_strGroupId)
                            If Trim(v_strCareBy) = Trim(v_strGroupId) Then
                                v_blnOk = True
                            End If
                        Next
                        If v_blnOk Then
                            cboCAREBY.SelectedValue = v_strCareBy
                            Return True
                        Else
                            'User khong co quyen careby - disable combo
                            cboCAREBY.AddItems(v_strCareByText, v_strCareBy)
                            cboCAREBY.SelectedValue = v_strCareBy
                            cboCAREBY.Enabled = False
                            Return True
                        End If
                    Else
                        Return False
                    End If
                End If
                Return True
            Else
                If (ExeFlag = ExecuteFlag.AddNew) Then
                    Return False
                ElseIf (ExeFlag = ExecuteFlag.View) Then
                    If (Not cboCAREBY.SelectedValue Is Nothing) And (Not cboCAREBY.SelectedValue Is DBNull.Value) Then
                        v_strCareBy = CStr(cboCAREBY.SelectedValue).Trim
                    End If
                    cboCAREBY.Enabled = False
                    Return True
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region " Tab member: CF.CFLINK "
    Private Sub LoadCFLINK(ByVal pv_strCUSTID As String)
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_int, v_intCount As Integer
            Dim v_strCDCONTENT, v_strFLDNAME, v_strVALUE, v_strCmdInquiry, v_strObjMsg As String
            Dim v_strAuth(10) As String
            v_strCmdInquiry = "SELECT CDCONTENT FROM ALLCODE WHERE CDNAME = 'LINKAUTH'  "
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, "SA.ALLCODE", gc_ActionInquiry, v_strCmdInquiry)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            ContactsGrid.Dock = Windows.Forms.DockStyle.Fill
            For v_intCount = 0 To v_nodeList.Count - 1
                For v_int = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                    With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                        v_strFLDNAME = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("fldname").Value.Trim()
                        v_strVALUE = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("oldval").Value.Trim()
                        Select Case v_strFLDNAME
                            Case "CDCONTENT"
                                v_strAuth(v_intCount) = v_strVALUE
                        End Select
                    End With
                Next
            Next

            If Not ContactsGrid Is Nothing And Len(pv_strCUSTID) > 0 Then
                'Clear old data
                ContactsGrid.DataRows.Clear()
                'v_strCmdInquiry = "SELECT LK.AUTOID,LK.CUSTID,CF.fullname, CD.CDCONTENT LINKTYPE,LK.DESCRIPTION ," & _
                '     "SUBSTR(LK.LINKAUTH,1,1)AS " & v_strAuth(0) & ",SUBSTR(LK.LINKAUTH,2,1)AS " & v_strAuth(1) & ",SUBSTR(LK.LINKAUTH,3,1) AS " & v_strAuth(2) & ",   " & _
                '     "SUBSTR(LK.LINKAUTH,4,1)AS " & v_strAuth(3) & ",SUBSTR(LK.LINKAUTH,5,1)AS " & v_strAuth(4) & ",SUBSTR(LK.LINKAUTH,6,1) AS " & v_strAuth(5) & "," & _
                '     "SUBSTR(LK.LINKAUTH,7,1)AS " & v_strAuth(6) & ",SUBSTR(LK.LINKAUTH,8,1)AS " & v_strAuth(7) & ",SUBSTR(LK.LINKAUTH,9,1) AS " & v_strAuth(8) & ",SUBSTR(LK.LINKAUTH,10,1)AS " & v_strAuth(9) & " " & _
                '     " FROM CFLINK LK , CFMAST CF,  ALLCODE CD WHERE " & _
                '    "CD.CDTYPE='CF' AND CD.CDNAME='LINKTYPE' AND CD.CDVAL=LINKTYPE AND LK.custid=CF.custid AND TRIM(LK.ACCTNO)='" & pv_strCUSTID & "'"
                v_strCmdInquiry = "SELECT LK.AUTOID,LK.CUSTID,CF.fullname, CD.CDCONTENT LINKTYPE,LK.DESCRIPTION ," & _
                     "SUBSTR(LK.LINKAUTH,1,1)AS CKB1,SUBSTR(LK.LINKAUTH,2,1)AS CKB2,SUBSTR(LK.LINKAUTH,3,1) AS CKB3,   " & _
                     "SUBSTR(LK.LINKAUTH,4,1)AS CKB4,SUBSTR(LK.LINKAUTH,5,1)AS CKB5,SUBSTR(LK.LINKAUTH,6,1) AS CKB6," & _
                     "SUBSTR(LK.LINKAUTH,7,1)AS CKB7,SUBSTR(LK.LINKAUTH,8,1)AS CKB8,SUBSTR(LK.LINKAUTH,9,1) AS CKB9,SUBSTR(LK.LINKAUTH,10,1)AS CKB10" & _
                     " FROM CFLINK LK , CFMAST CF,  ALLCODE CD WHERE " & _
                    "CD.CDTYPE='CF' AND CD.CDNAME='LINKTYPE' AND CD.CDVAL=LINKTYPE AND LK.custid=CF.custid AND TRIM(LK.ACCTNO)='" & pv_strCUSTID & "'"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, MyBase.LocalObject, gc_MsgTypeObj, "CF.CFLINK", gc_ActionInquiry, v_strCmdInquiry)
                v_ws.Message(v_strObjMsg)
                FillDataGrid(ContactsGrid, v_strObjMsg, "")
                mv_blnRefreshTabPage_Members = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_xmlDocument = Nothing
            v_ws = Nothing
        End Try
    End Sub

    Public Sub showForm_CFLINK(ByVal pv_intExecFlag As Integer)
        Dim v_frm As New frmCFLINK
        Dim v_strAFACCTNO As String
        Try
            v_strAFACCTNO = Me.txtACCTNO.Text.Trim
            v_frm.ExeFlag = pv_intExecFlag
            v_frm.UserLanguage = UserLanguage
            v_frm.ModuleCode = ModuleCode
            v_frm.ObjectName = "CF.CFLINK"
            v_frm.TableName = "CFLINK"
            v_frm.BranchId = Me.BranchId
            v_frm.LocalObject = "N"
            v_frm.Text = String.Empty
            'AnhVT Added - Maintenance Retroed
            v_frm.ParentObjName = Me.ObjectName
            v_frm.ParentClause = KeyFieldName & " = '" & txtACCTNO.Text & "'"
            v_frm.TellerId = TellerId
            'AnhVT Ended
            If pv_intExecFlag <> ExecuteFlag.AddNew Then
                If ContactsGrid.CurrentGrid.DataRows.Count = 0 Then
                    MsgBox(ResourceManager.GetString("frmAFMAST.Nothing"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                    Exit Sub
                End If
                If (ContactsGrid.CurrentRow Is Nothing) Then
                    MsgBox(ResourceManager.GetString("frmAFMAST.NotSelected"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                    Exit Sub
                End If
                v_frm.KeyFieldName = "AUTOID"
                v_frm.KeyFieldType = KeyFieldType
                v_frm.KeyFieldValue = Trim(CType(ContactsGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value)
            End If
            v_frm.mv_StrACCTNO = v_strAFACCTNO
            Dim frmResult As DialogResult = v_frm.ShowDialog()
            If pv_intExecFlag <> ExecuteFlag.View Then
                LoadCFLINK(v_strAFACCTNO)
            End If
        Catch ex As Exception
            Throw ex
        Finally
            v_frm.Dispose()
        End Try
    End Sub

    Private Sub btnADDCM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnADDCM.Click
        If Me.txtACCTNO.Text.Length = 10 Then
            showForm_CFLINK(ExecuteFlag.AddNew)
        Else
            MsgBox(ResourceManager.GetString("ACCTNO_INVALID"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            Me.txtACCTNO.Focus()
        End If
    End Sub

    Private Sub btnVIEWCM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVIEWCM.Click
        showForm_CFLINK(ExecuteFlag.View)
    End Sub

    Private Sub btnEDITCM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEDITCM.Click
        showForm_CFLINK(ExecuteFlag.Edit)
    End Sub

    Private Sub btnDELCM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDELCM.Click
        Delete_TabPage_Row("N", ModuleCode & ".CFLINK")
        LoadCFLINK(Me.txtACCTNO.Text)
    End Sub

    Private Sub btnCVIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCVIEW.Click
        'Me.tabMember.Enabled = False
        showForm_CFLINK(ExecuteFlag.View)
    End Sub

    Private Sub btnCEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCEDIT.Click
        showForm_CFLINK(ExecuteFlag.Edit)
    End Sub

    Private Sub btnCDEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCDEL.Click
        Delete_TabPage_Row("N", ModuleCode & ".CFLINK")
        LoadCFLINK(Me.txtACCTNO.Text)
    End Sub

    Private Sub btnCADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCADD.Click
        showForm_CFLINK(ExecuteFlag.AddNew)
    End Sub

#End Region

#Region " Tab authorize: CF.CFAUTH "
    Private Sub LoadCFAUTH(ByVal pv_strACCTNO As String)
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            If Not AnthorizeGrid Is Nothing And Len(pv_strACCTNO) > 0 Then
                'Clear old data
                AnthorizeGrid.DataRows.Clear()
                Dim v_strSQL As String = "SELECT AU.AUTOID,AU.CUSTID,CF.FULLNAME,AU.ACCTNO, CF.IDCODE LICENSENO, " & _
                    " CF.ADDRESS,CF.PHONE TELEPHONE,AU.VALDATE,AU.EXPDATE,CF.IDPLACE LNPLACE, CF.IDDATE LNIDDATE, cd1.cdcontent DELTDCH, AU.DELTD" & _
                    " FROM CFAUTH AU, CFMAST CF, ALLCODE CD1 WHERE AU.CUSTID= CF.CUSTID AND cd1.cdval = AU.DELTD AND cd1.cdname = 'CANCELED' AND cdtype = 'SY' AND TRIM(AU.ACCTNO)='" & pv_strACCTNO & "'"
                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, MyBase.LocalObject, gc_MsgTypeObj, "CF.CFCONTACT", _
                    gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                FillDataGrid(AnthorizeGrid, v_strObjMsg, "")
                mv_blnRefreshTabPage_Authorized = True
            End If
        Catch ex As Exception
            Throw ex
        Finally
            v_ws = Nothing
        End Try
    End Sub

    Public Sub showForm_CFAUTH(ByVal pv_intExecFlag As Integer)
        Dim v_frm As New frmCFAUTH
        Try
            Dim v_strAFACCTNO As String
            v_strAFACCTNO = Me.txtACCTNO.Text.Trim
            v_frm.ExeFlag = pv_intExecFlag
            v_frm.UserLanguage = UserLanguage
            v_frm.BranchId = BranchId
            v_frm.TellerId = TellerId
            v_frm.TellerRight = TellerRight
            v_frm.GroupCareBy = GroupCareBy
            v_frm.ModuleCode = ModuleCode
            v_frm.ObjectName = "CF.CFAUTH"
            v_frm.TableName = "CFAUTH"
            v_frm.LocalObject = "N"
            v_frm.BusDate = Me.BusDate
            v_frm.Text = String.Empty
            ''v_frm.Acctno = v_strAFACCTNO
            v_frm.orgcustid = Me.txtCUSTID.Text.Trim
            'AnhVT Added - Maintenance Retroed
            v_frm.ParentObjName = Me.ObjectName
            v_frm.ParentClause = KeyFieldName & " = '" & txtACCTNO.Text & "'"
            v_frm.TellerId = TellerId
            'AnhVT Ended

            If Not (AnthorizeGrid.CurrentRow Is Nothing) Then
                If Not (pv_intExecFlag = ExecuteFlag.AddNew) Then
                    v_frm.KeyFieldName = "AUTOID"
                    v_frm.KeyFieldType = "N"
                    v_frm.KeyFieldValue = Trim(CType(AnthorizeGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value)
                    ''v_frm.isNotApprove = CheckBeforeEditDelCFAuth()
                Else
                    ''v_frm.isNotApprove = True
                End If
                If (pv_intExecFlag = ExecuteFlag.View) Then
                    v_frm.ExeFlag = ExecuteFlag.View
                ElseIf (pv_intExecFlag = ExecuteFlag.Edit) Then
                    v_frm.ExeFlag = ExecuteFlag.Edit
                ElseIf (pv_intExecFlag = ExecuteFlag.Delete) Then
                    v_frm.ExeFlag = ExecuteFlag.Delete
                End If
                v_frm.ShowDialog()
            Else
                If (pv_intExecFlag = ExecuteFlag.AddNew) Then
                    v_frm.ExeFlag = ExecuteFlag.AddNew
                    ''v_frm.isNotApprove = True
                    v_frm.ShowDialog()
                End If
            End If
            If (pv_intExecFlag <> ExecuteFlag.View) Then
                LoadCFAUTH(v_strAFACCTNO)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_frm.Dispose()
        End Try
    End Sub

    Public Sub showAFSERULE(ByVal pv_intExecFlag As Integer)
        Dim v_strKeyValue, v_strModuleCode, v_strObjName, v_strTableName, v_strKeyField, v_strKeyFieldType, v_strParentValue As String
        Try
            'Insert
            If (pv_intExecFlag = ExecuteFlag.AddNew) Then
                v_strKeyValue = String.Empty
            ElseIf (pv_intExecFlag = ExecuteFlag.Edit Or pv_intExecFlag = ExecuteFlag.View) Then
                v_strKeyValue = Trim(CType(AFSERuleGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value)
            End If
            v_strModuleCode = "CF"
            v_strObjName = "CF.AFSERULE"
            v_strTableName = "AFSERULE"
            v_strKeyField = "AUTOID"
            v_strKeyFieldType = "N"
            v_strParentValue = Me.txtACCTNO.Text.Replace(".", "")

            Dim v_frm As New frmMaster(v_strTableName, pv_intExecFlag, UserLanguage, v_strModuleCode, v_strObjName, gc_IsNotLocalMsg, _
                                        Me.tabAFSERULE.Text, TellerId, TellerRight, GroupCareBy, AuthString, BranchId, BusDate, v_strKeyField, _
                                        v_strKeyFieldType, v_strKeyValue, LinkValue, Me.LinkField, v_strParentValue, Me.ObjectName, Me.ModuleCode, Me.mv_arrObjFields)
            Dim frmResult As DialogResult = v_frm.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub


    Private Sub btnAADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAADD.Click
        If Me.txtACCTNO.Text.Length = 10 Then
            showForm_CFAUTH(ExecuteFlag.AddNew)
        Else
            MsgBox(ResourceManager.GetString("ACCTNO_INVALID"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            Me.txtACCTNO.Focus()
        End If
    End Sub

    Private Sub btnAVIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAVIEW.Click
        showForm_CFAUTH(ExecuteFlag.View)
    End Sub

    Private Sub btnAEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAEDIT.Click
        showForm_CFAUTH(ExecuteFlag.Edit)
    End Sub

    Private Sub btnADEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnADEL.Click
        'If CheckBeforeEditDelCFAuth() Then
        '    Delete_TabPage_Row("N", ModuleCode & ".CFAUTH")
        '    LoadCFAUTH(Me.txtACCTNO.Text)
        'Else
        '    MsgBox(ResourceManager.GetString("msgCANNOTDELETECFAUTH"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        'End If
        Delete_TabPage_Row("N", ModuleCode & ".CFAUTH")
        LoadCFAUTH(Me.txtACCTNO.Text)

    End Sub

#End Region

#Region " Tab OTRIGHT"
    Public Sub ShowForm_OTRIGHT(ByVal pv_intExecFlag As Integer)
        Dim v_frm As New frmOTRIGHT
        Try
            Dim v_strAFACCTNO As String
            v_strAFACCTNO = Me.txtACCTNO.Text.Trim
            v_frm.ExeFlag = pv_intExecFlag
            v_frm.UserLanguage = UserLanguage
            v_frm.BranchId = BranchId
            v_frm.TellerId = TellerId
            v_frm.TellerRight = TellerRight
            v_frm.GroupCareBy = GroupCareBy
            v_frm.ModuleCode = ModuleCode
            v_frm.ObjectName = "CF.OTRIGHT"
            v_frm.TableName = "OTRIGHT"
            v_frm.LocalObject = "N"
            v_frm.BusDate = Me.BusDate
            v_frm.Text = String.Empty
            'v_frm.Acctno = v_strAFACCTNO
            v_frm.orgcustid = Me.txtCUSTID.Text.Trim
            v_frm.ParentObjName = Me.ObjectName
            v_frm.ParentClause = KeyFieldName & " = '" & txtACCTNO.Text & "'"
            v_frm.TellerId = TellerId

            If Not (OTRightAuthGrid.CurrentRow Is Nothing) Then
                If Not (pv_intExecFlag = ExecuteFlag.AddNew) Then
                    v_frm.KeyFieldName = "AUTOID"
                    v_frm.KeyFieldType = "N"
                    v_frm.KeyFieldValue = Trim(CType(OTRightAuthGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value)
                    v_frm.AuthCustid = Trim(CType(OTRightAuthGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTHCUSTID").Value)
                    'v_frm.isNotApprove = CheckBeforeEditDelCFAuth()
                Else
                    'v_frm.isNotApprove = True
                End If
                If (pv_intExecFlag = ExecuteFlag.View) Then
                    v_frm.ExeFlag = ExecuteFlag.View
                ElseIf (pv_intExecFlag = ExecuteFlag.Edit) Then
                    v_frm.ExeFlag = ExecuteFlag.Edit
                ElseIf (pv_intExecFlag = ExecuteFlag.Delete) Then
                    v_frm.ExeFlag = ExecuteFlag.Delete
                End If
                v_frm.ShowDialog()
            Else
                If (pv_intExecFlag = ExecuteFlag.AddNew) Then
                    v_frm.ExeFlag = ExecuteFlag.AddNew
                    'v_frm.isNotApprove = True
                    v_frm.ShowDialog()
                End If
            End If
            If (pv_intExecFlag <> ExecuteFlag.View) Then
                LoadOTRightAsgn(v_strAFACCTNO)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_frm.Dispose()
        End Try
    End Sub
    ''' <summary>
    ''' binhpt add, tu dong them quyen trong OTRIGHT khi dang ky tu ol
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub OnSaveOTRIGHT()
        Try
            Dim v_dr As DataRow
            Dim v_strAFACCTNO As String
            v_strAFACCTNO = Me.txtACCTNO.Text.Trim
            Dim v_AUTHCUSTID As String
            v_AUTHCUSTID = Me.txtCUSTID.Text.Trim
            Dim v_strRight2Save As String = String.Empty
            Dim v_strObjMsg As String
            Dim v_xmlDocument As New XmlDocument
            Dim v_txDocument As New XmlDocument
            Dim v_ws As New BDSDeliveryManagement
            Dim v_strErrorSource, v_strErrorMessage As String
            Dim v_CashTransfer As String = IIf(mv_cashtransferonline = "Y", "YYYY", "NNNN")
            Dim v_cashinadvance As String = IIf(mv_cashinadvanceonline = "Y", "YYYY", "NNNN")
            Dim v_additionalshare As String = IIf(mv_additionalsharesonline = "Y", "YYYY", "NNNN")
            Dim v_placeorder As String = IIf(mv_placeorderonline = "Y", "YYYY", "NNNN")
            Dim v_search As String = IIf(mv_searchonline = "Y", "YYYY", "NNNN")
            Dim v_ExpiationDate = Date.Parse(BusDate).AddYears(2).ToShortDateString()
            v_strRight2Save = String.Format("{0}|{1}|0|{2}|{3}|CUSTOMIZE#CASHTRANS|{4}NN$ADWINPUT|{5}NN$ISSUEINPUT|{6}NN$MORTGAGE|NNNNNN$ORDINPUT|{7}NN$COND_ORDER|{7}NN$GROUP_ORDER|{7}NN$DEPOSIT|{8}NN$SMARTALERT|NNNNNN$MARKETALERT|NNNNNN$COMPANYALERT|NNNNNN$BONDSTOSHARES|NNNNNN$TERMDEPOSIT|NNNNNN$", v_strAFACCTNO, v_AUTHCUSTID, BusDate, v_ExpiationDate, v_CashTransfer, v_cashinadvance, v_additionalshare, v_placeorder, v_search)
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, "N", gc_MsgTypeObj, "CF.OTRIGHT", gc_ActionAdhoc, , , "OTRIGHT_Addnew", , , v_strRight2Save, , , , "CF.AFMAST", "ACCTNO = '" & Me.txtACCTNO.Text & "'")
            PrepareDataSetForOTRIGHT(mv_dsInput)
            v_dr = mv_dsInput.Tables(0).NewRow()
            '{"AUTOID", "AUTHCUSTID", "AUTHTYPE", "AFACCTNO", "VALDATE", "EXDATE", "DELTD", "LASTDATE", "LASTCHANGE"}
            'v_dr("AFACCTNO") = v_strAFACCTNO
            'v_dr("VALDATE") = BusDate
            'v_dr("EXDATE") = v_ExpiationDate
            'v_dr("AUTHTYPE") = "0"
            'v_dr("DELTD") = String.Empty
            'v_dr("ASGNTYPE") = String.Empty
            'v_dr("CUSTOMIZE") = "CUSTOMIZE"
            mv_dsInput.Tables(0).Rows.Add(v_dr)
            BuildXMLObjData(mv_dsInput, v_strObjMsg)
            Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)
            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
            If v_lngErrorCode <> 0 Then
                MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub PrepareDataSetForOTRIGHT(ByRef pv_ds As DataSet)
        Dim v_dc As DataColumn
        Dim v_DataName() As String = {"AUTOID", "AUTHCUSTID", "AUTHTYPE", "AFACCTNO", "VALDATE", "EXDATE", "DELTD", "LASTDATE", "LASTCHANGE"}
        Try
            If Not (pv_ds Is Nothing) Then
                pv_ds.Dispose()
            End If
            pv_ds = New DataSet("INPUT")
            pv_ds.Tables.Add("OTRIGHT")

            For i As Integer = 0 To v_DataName.Count
                v_dc = New DataColumn(v_DataName(i))
                If (v_DataName(i) <> "VALDATE" And v_DataName(i) <> "EXDATE") Then
                    v_dc.DataType = GetType(String)
                Else
                    v_dc.DataType = GetType(System.DateTime)
                End If
                pv_ds.Tables(0).Columns.Add(v_dc)
            Next
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
        End Try
    End Sub
    Private Sub LoadOTRightAsgn(ByVal pv_strACCTNO As String)
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            If Not OTRightAuthGrid Is Nothing And Len(pv_strACCTNO) > 0 Then
                'Clear old data
                OTRightAuthGrid.DataRows.Clear()
                Dim v_strSQL As String
                'v_strSQL = "SELECT * FROM (" & ControlChars.CrLf _
                '        & " SELECT OT.AUTOID, OT.AFACCTNO, OT.AUTHCUSTID, CF.FULLNAME, CF.IDCODE, CF.ADDRESS, CF.PHONE," & ControlChars.CrLf _
                '        & "     TO_CHAR(OT.VALDATE,'DD/MM/YYYY') VALDATE, TO_CHAR(OT.EXPDATE,'DD/MM/YYYY') EXPDATE, A1.CDCONTENT AUTHTYPE" & ControlChars.CrLf _
                '        & " FROM OTRIGHT OT, CFMAST CF, ALLCODE A1" & ControlChars.CrLf _
                '        & " WHERE CF.CUSTID = OT.AUTHCUSTID" & ControlChars.CrLf _
                '        & "     AND OT.DELTD = 'N' " & ControlChars.CrLf _
                '        & "     AND A1.CDTYPE = 'CF' AND A1.CDNAME = 'AUTHTYPE' AND A1.CDVAL = CASE WHEN OT.AFACCTNO = OT.AUTHAFACCTNO THEN 'OWNER' ELSE 'AUTHORIZED' END " & ControlChars.CrLf _
                '        & "     AND TRIM(OT.AFACCTNO)='" & pv_strACCTNO & "' ) AU " & ControlChars.CrLf _
                '        & " ORDER BY AU.AUTOID"
                v_strSQL = "SELECT * FROM (" & ControlChars.CrLf _
                        & " SELECT OT.AUTOID, OT.AFACCTNO, OT.AUTHCUSTID, CF.FULLNAME, CF.IDCODE, CF.ADDRESS, CF.PHONE," & ControlChars.CrLf _
                        & "     TO_CHAR(OT.VALDATE,'DD/MM/YYYY') VALDATE, TO_CHAR(OT.EXPDATE,'DD/MM/YYYY') EXPDATE, A1.CDCONTENT AUTHTYPE" & ControlChars.CrLf _
                        & " FROM OTRIGHT OT, CFMAST CF, ALLCODE A1" & ControlChars.CrLf _
                        & " WHERE CF.CUSTID = OT.AUTHCUSTID" & ControlChars.CrLf _
                        & "     AND OT.DELTD = 'N' " & ControlChars.CrLf _
                        & "     AND A1.CDTYPE = 'CF' AND A1.CDNAME = 'AUTHTYPE' AND A1.CDVAL = CASE WHEN OT.AUTHCUSTID = '" & txtCUSTID.Text.Replace(".", "") & "' THEN 'OWNER' ELSE 'AUTHORIZED' END " & ControlChars.CrLf _
                        & "     AND TRIM(OT.AFACCTNO)='" & pv_strACCTNO & "' ) AU " & ControlChars.CrLf _
                        & " ORDER BY AU.AUTOID"
                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, MyBase.LocalObject, gc_MsgTypeObj, "CF.CFCONTACT", _
                    gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                FillDataGrid(OTRightAuthGrid, v_strObjMsg, "")
                mv_blnRefreshTabPage_OTRight = True
            End If
        Catch ex As Exception
            Throw ex
        Finally
            v_ws = Nothing
        End Try
    End Sub

    Private Sub OnDeleteOTRIGHT()
        Try
            If Not OTRightAuthGrid.CurrentRow Is Nothing Then
                If MessageBox.Show(ResourceManager.GetString("OTRightDeleteConfirm"), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Dim v_strAFACCTNO, v_strAUTHCUSTID As String
                    v_strAFACCTNO = Replace(txtACCTNO.Text, ".", "").Trim
                    v_strAUTHCUSTID = Trim(CType(OTRightAuthGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTHCUSTID").Value)

                    'Call to delete OTRIGHT
                    Dim v_ws As New BDSDeliveryManagement
                    Dim v_strObjMsg As String
                    Dim v_strErrorSource, v_strErrorMessage As String

                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_OTRIGHT, gc_ActionAdhoc, , v_strAFACCTNO & "|" & v_strAUTHCUSTID, "OTRIGHT_Delete", , , , , , , ParentObjName, ParentClause)

                    Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)
                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)

                    If v_lngErrorCode <> 0 Then
                        'Update mouse pointer
                        Cursor.Current = Cursors.Default
                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Exit Sub
                    End If
                    MsgBox(ResourceManager.GetString("DeleteOTRIGHTSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    LoadOTRightAsgn(txtACCTNO.Text)
                End If
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                        & "Error code: System error!" & vbNewLine _
                        & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub
#End Region

#Region " Tab report: CF.RPTAFMAST "
    Private Sub LoadCFRPTAFMAST(ByVal pv_strACCTNO As String)
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            If Not ReportGrid Is Nothing And Len(pv_strACCTNO) > 0 Then
                'Clear data
                ReportGrid.DataRows.Clear()
                Dim v_strSQL As String = "SELECT RAF.AUTOID, RAF.RPTID  CMDCODE,RPT.DESCRIPTION CMDTITLE, RAF.EXCYCLE EXCYCLE , RAF.EXPDATE EXPDATE, RAF.STATUS STATUS " _
                & " FROM RPTAFMAST RAF , RPTMASTER RPT  WHERE " _
                & " RPT.RPTID=RAF.RPTID AND TRIM(RAF.AFACCTNO)='" & pv_strACCTNO & "'"

                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, MyBase.LocalObject, gc_MsgTypeObj, "CF.CFCONTACT", _
                    gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                FillDataGrid(ReportGrid, v_strObjMsg, "")
                mv_blnRefreshTabPage_Report = True
            End If
        Catch ex As Exception
            Throw ex
        Finally
            v_ws = Nothing
        End Try
    End Sub

    Private Sub LoadAFTXMAP(ByVal pv_strACCTNO As String, ByVal pv_strACTYPE As String)
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            If Not TxmapGrid Is Nothing And Len(pv_strACCTNO) > 0 Then
                'Clear data
                TxmapGrid.DataRows.Clear()

                Dim v_strSQL As String = "Select af.AFACCTNO, af.autoid,af.tltxcd, tx.txdesc, effdate, expdate, tlname tlid, af.actype, null typename " _
                & " from aftxmap af, tltx tx, tlprofiles tl where af.tltxcd= tx.tltxcd and af.deltd='N' " _
                & " and af.tlid= tl.tlid AND TRIM(AF.AFACCTNO)='" & pv_strACCTNO & "' " _
                & " UNION ALL " _
                & " Select af.AFACCTNO, af.autoid,af.tltxcd, tx.txdesc, effdate, expdate, tlname tlid, af.actype, typ.typename " _
                & " from aftxmap af, tltx tx, tlprofiles tl, aftype typ where af.tltxcd= tx.tltxcd and af.deltd='N' " _
                & " and af.tlid= tl.tlid AND af.actype = typ.actype AND TRIM(UPPER(AF.AFACCTNO))='ALL' AND af.actype ='" & pv_strACTYPE & "' AND EXPDATE>to_date('" & Me.BusDate & "','DD/MM/RRRR')"

                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, MyBase.LocalObject, gc_MsgTypeObj, "CF.CFCONTACT", _
                    gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                FillDataGrid(TxmapGrid, v_strObjMsg, "")
                mv_blnRefreshTabPage_Txmap = True
            End If
        Catch ex As Exception
            Throw ex
        Finally
            v_ws = Nothing
        End Try
    End Sub

    'Public Sub showForm_RPTAFMAST(ByVal pv_intExecFlag As Integer)
    '    Dim v_frm As New frmRPTAFMAST
    '    Try
    '        Dim v_strAFACCTNO As String
    '        v_strAFACCTNO = Me.txtACCTNO.Text.Trim
    '        v_frm.ExeFlag = pv_intExecFlag
    '        v_frm.UserLanguage = UserLanguage
    '        v_frm.BranchId = BranchId
    '        v_frm.TellerId = TellerId
    '        v_frm.ModuleCode = ModuleCode
    '        v_frm.ObjectName = "CF.RPTAFMAST"
    '        v_frm.TableName = "RPTAFMAST"
    '        v_frm.LocalObject = "N"
    '        v_frm.BusDate = Me.BusDate
    '        v_frm.Text = String.Empty
    '        'v_frm.acctno = v_strAFACCTNO
    '        'v_frm.custodycd = v_strCUSTODYCD
    '        'AnhVT Added - Maintenance Retroed
    '        v_frm.ParentObjName = Me.ObjectName
    '        v_frm.ParentClause = KeyFieldName & " = '" & txtACCTNO.Text & "'"
    '        v_frm.TellerId = TellerId
    '        'AnhVT Ended
    '        If Not (ReportGrid.CurrentRow Is Nothing) Then
    '            If Not (pv_intExecFlag = ExecuteFlag.AddNew) Then
    '                v_frm.KeyFieldName = "AUTOID"
    '                v_frm.KeyFieldType = "N"
    '                v_frm.KeyFieldValue = Trim(CType(ReportGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value)
    '            End If
    '            If (pv_intExecFlag = ExecuteFlag.View) Then
    '                v_frm.ExeFlag = ExecuteFlag.View
    '            ElseIf (pv_intExecFlag = ExecuteFlag.Edit) Then
    '                v_frm.ExeFlag = ExecuteFlag.Edit
    '            ElseIf (pv_intExecFlag = ExecuteFlag.Delete) Then
    '                v_frm.ExeFlag = ExecuteFlag.Delete
    '            End If
    '            v_frm.ShowDialog()

    '        Else
    '            If (pv_intExecFlag = ExecuteFlag.AddNew) Then
    '                v_frm.ExeFlag = ExecuteFlag.AddNew
    '                v_frm.ShowDialog()
    '            End If
    '        End If
    '        If (pv_intExecFlag <> ExecuteFlag.View) Then
    '            LoadCFRPTAFMAST(v_strAFACCTNO)
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
    '    Finally
    '        v_frm = Nothing
    '    End Try
    'End Sub


    Public Sub showForm_AFTXMAP(ByVal pv_intExecFlag As Integer)
        Dim v_frm As New frmAFTXMAP
        Try
            Dim v_strAFACCTNO As String
            v_strAFACCTNO = Me.txtACCTNO.Text.Trim
            v_frm.ExeFlag = pv_intExecFlag
            v_frm.UserLanguage = UserLanguage
            v_frm.BranchId = BranchId
            v_frm.TellerId = TellerId
            v_frm.ModuleCode = ModuleCode
            v_frm.ObjectName = "CF.AFTXMAP"
            v_frm.TableName = "AFTXMAP"
            v_frm.LocalObject = "N"
            v_frm.BusDate = Me.BusDate
            v_frm.Text = String.Empty
            v_frm.acctno = v_strAFACCTNO
            v_frm.custodycd = v_strCUSTODYCD
            v_frm.Actype = txtACTYPE.Text
            'AnhVT Added - Maintenance Retroed
            v_frm.ParentObjName = Me.ObjectName
            v_frm.ParentClause = KeyFieldName & " = '" & txtACCTNO.Text & "'"
            v_frm.TellerId = TellerId
            'AnhVT Ended
            If Not (TxmapGrid.CurrentRow Is Nothing) Then
                If Not (pv_intExecFlag = ExecuteFlag.AddNew) Then
                    v_frm.KeyFieldName = "AUTOID"
                    v_frm.KeyFieldType = "N"
                    v_frm.KeyFieldValue = Trim(CType(TxmapGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value)
                End If
                If (pv_intExecFlag = ExecuteFlag.View) Then
                    v_frm.ExeFlag = ExecuteFlag.View
                ElseIf (pv_intExecFlag = ExecuteFlag.Edit) Then
                    If Trim(CType(TxmapGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AFACCTNO").Value) = "ALL" Then
                        MsgBox(ResourceManager.GetString("AUTHNOTALLOW"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                        Exit Sub
                    End If
                    v_frm.ExeFlag = ExecuteFlag.Edit
                ElseIf (pv_intExecFlag = ExecuteFlag.Delete) Then
                    v_frm.ExeFlag = ExecuteFlag.Delete
                End If
                v_frm.ShowDialog()

            Else
                If (pv_intExecFlag = ExecuteFlag.AddNew) Then
                    v_frm.ExeFlag = ExecuteFlag.AddNew
                    v_frm.ShowDialog()
                End If
            End If
            If (pv_intExecFlag <> ExecuteFlag.View) Then
                LoadAFTXMAP(v_strAFACCTNO, txtACTYPE.Text)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_frm = Nothing
        End Try
    End Sub

    'Private Sub btnRPTADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRPTADD.Click
    '    If Me.txtACCTNO.Text.Length = 10 Then
    '        showForm_RPTAFMAST(ExecuteFlag.AddNew)
    '    Else
    '        MsgBox(ResourceManager.GetString("ACCTNO_INVALID"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
    '        Me.txtACCTNO.Focus()
    '    End If
    'End Sub

    'Private Sub btnRPTVIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRPTVIEW.Click
    '    showForm_RPTAFMAST(ExecuteFlag.View)
    'End Sub

    'Private Sub btnRPTEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRPTEDIT.Click
    '    showForm_RPTAFMAST(ExecuteFlag.Edit)
    'End Sub

    Private Sub btnRPTDEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRPTDEL.Click
        If ReportGrid.CurrentGrid.DataRows.Count > 0 Then
            Delete_TabPage_Row(gc_IsNotLocalMsg, ModuleCode & ".RPTAFMAST")
            LoadCFRPTAFMAST(Me.txtACCTNO.Text)
        End If
    End Sub

    Private Sub btnTXADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTXADD.Click
        If Me.txtACCTNO.Text.Length = 10 Then
            showForm_AFTXMAP(ExecuteFlag.AddNew)
        Else
            MsgBox(ResourceManager.GetString("ACCTNO_INVALID"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            Me.txtACCTNO.Focus()
        End If
    End Sub

    Private Sub btnTXVIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTXVIEW.Click
        showForm_AFTXMAP(ExecuteFlag.View)
    End Sub

    Private Sub btnTXEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTXEDIT.Click
        showForm_AFTXMAP(ExecuteFlag.Edit)
    End Sub

    Private Sub btnTXDEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTXDEL.Click
        If TxmapGrid.CurrentGrid.DataRows.Count > 0 Then
            Delete_TabPage_Row(gc_IsNotLocalMsg, ModuleCode & ".AFTXMAP")
            LoadAFTXMAP(Me.txtACCTNO.Text, txtACTYPE.Text)
        End If
    End Sub

#End Region

#Region " Tab register bank transfer account: CF.CFOTHERACC "
    Private Sub LoadCFOTHERACC(ByVal pv_strACCTNO As String)
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            If Not ContactsGrid Is Nothing And Len(pv_strACCTNO) > 0 Then
                ExtCIGrid.DataRows.Clear()
                'Type = 0 la CI Acctno,  Type = 1 la Bank Acctno
                Dim v_strSQL As String = "SELECT * FROM CFOTHERACC WHERE AFACCTNO = '" & pv_strACCTNO & "' AND TYPE='0'"


                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, MyBase.LocalObject, gc_MsgTypeObj, "CF.CFMAST", _
                    gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)

                FillDataGrid(ExtCIGrid, v_strObjMsg, "")
                v_strSQL = "SELECT * FROM CFOTHERACC WHERE AFACCTNO = '" & pv_strACCTNO & "' AND TYPE='1'"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, MyBase.LocalObject, gc_MsgTypeObj, "CF.CFMAST", _
                    gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                FillDataGrid(ExtBankAccGrid, v_strObjMsg, "")

                mv_blnRefreshTabPage_RegisterAcctTrf = True
            End If
        Catch ex As Exception
            Throw ex
        Finally
            v_ws = Nothing
        End Try
    End Sub
    ''' <summary>
    ''' Binhpt add them tai khoan ngan hang tu dang ky online
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function OnSaveCFOTHERACC()
        Dim v_dr As DataRow
        Dim v_strObjMsg As String
        Dim v_CFOTHERACC(,) As String = New String(,) {{mv_bankaccountname1, mv_bankaccountnumber1, mv_bankcity1, mv_branch1, mv_bankidcode1, mv_bankiddate1, mv_bankidplace1, mv_bankname1}, _
                                                        {mv_bankaccountname2, mv_bankaccountnumber2, mv_bankcity2, mv_branch2, mv_bankidcode2, mv_bankiddate2, mv_bankidplace2, mv_bankname2}, _
                                                        {mv_bankaccountname3, mv_bankaccountnumber3, mv_bankcity3, mv_branch3, mv_bankidcode3, mv_bankiddate3, mv_bankidplace3, mv_bankname3}}
        Try
            PrepareDataSetForCfOtheracc(mv_dsInput)
            For i As Integer = 0 To 2
                If v_CFOTHERACC(i, 1) <> String.Empty Then
                    mv_dsInput.Tables(0).Clear()
                    v_dr = mv_dsInput.Tables(0).NewRow()
                    v_dr("BANKACNAME") = v_CFOTHERACC(i, 0)
                    v_dr("BANKACC") = v_CFOTHERACC(i, 1)
                    v_dr("CITYEF") = v_CFOTHERACC(i, 2)
                    v_dr("CITYBANK") = v_CFOTHERACC(i, 3)
                    v_dr("ACNIDCODE") = v_CFOTHERACC(i, 4)
                    v_dr("ACNIDDATE") = v_CFOTHERACC(i, 5)
                    v_dr("ACNIDPLACE") = v_CFOTHERACC(i, 6)
                    v_dr("BANKNAME") = v_CFOTHERACC(i, 7)
                    v_dr("AFACCTNO") = Me.txtACCTNO.Text
                    v_dr("CUSTID") = Me.txtCUSTID.Text
                    v_dr("TYPE") = "1"
                    mv_dsInput.Tables(0).Rows.Add(v_dr)
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, "SA.CFOTHERACC", gc_ActionAdd, , , , gc_AutoIdUsed, , , , , , "CF.AFMAST", " ACCTNO= '" & txtACCTNO.Text & "'")
                    BuildXMLObjData(mv_dsInput, v_strObjMsg)
                    Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                    Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)
                    Dim v_strErrorSource, v_strErrorMessage As String
                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                    If v_lngErrorCode <> 0 Then
                        'Update mouse pointer
                        Cursor.Current = Cursors.Default
                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Exit Function
                    End If
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub PrepareDataSetForCfOtheracc(ByRef pv_ds As DataSet)
        Dim v_dc As DataColumn
        Dim v_DataName() As String = {"AUTOID", "AFACCTNO", "CIACCOUNT", "CINAME", "CUSTID", "TYPE", "BANKACC", "BANKACNAME", "CITYEF", "BANKNAME", "CITYBANK", "ACNIDCODE", "ACNIDPLACE", "FEECD", "ACNIDDATE"}
        Try
            If Not (pv_ds Is Nothing) Then
                pv_ds.Dispose()
            End If
            pv_ds = New DataSet("INPUT")
            pv_ds.Tables.Add("CFOTHERACC")

            For i As Integer = 0 To v_DataName.Count
                v_dc = New DataColumn(v_DataName(i))
                If (v_DataName(i) <> "ACNIDDATE") Then
                    v_dc.DataType = GetType(String)
                Else
                    v_dc.DataType = GetType(System.DateTime)
                End If
                pv_ds.Tables(0).Columns.Add(v_dc)
            Next
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
        End Try
    End Sub

    Public Sub showForm_CFOTHERACC(ByVal pv_intExecFlag As Integer)
        Dim v_frm As New frmCFOTHERACC
        Try
            Dim v_strAFACCTNO As String
            v_strAFACCTNO = Me.txtACCTNO.Text.Trim
            v_frm.ExeFlag = pv_intExecFlag
            v_frm.UserLanguage = UserLanguage
            v_frm.BranchId = BranchId
            v_frm.ModuleCode = "SA"
            v_frm.ObjectName = "SA.CFOTHERACC"
            v_frm.TableName = "CFOTHERACC"
            v_frm.LocalObject = "N"
            v_frm.BusDate = Me.BusDate
            v_frm.Text = String.Empty
            'v_frm.Acctno = v_strAFACCTNO
            'AnhVT Added - Maintenance Retroed
            v_frm.ParentObjName = Me.ObjectName
            v_frm.ParentClause = KeyFieldName & " = '" & txtACCTNO.Text & "'"
            v_frm.TellerId = TellerId
            'AnhVT Ended
            If Not (pv_intExecFlag = ExecuteFlag.AddNew) Then
                If m_blnGridCI = True Then
                    v_frm.KeyFieldName = "AUTOID"
                    v_frm.KeyFieldType = "N"
                    v_frm.KeyFieldValue = Trim(CType(ExtCIGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value)
                Else
                    v_frm.KeyFieldName = "AUTOID"
                    v_frm.KeyFieldType = "N"
                    v_frm.KeyFieldValue = Trim(CType(ExtBankAccGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value)
                End If
            End If
            v_frm.ShowDialog()

            If (pv_intExecFlag <> ExecuteFlag.View) Then
                LoadCFOTHERACC(v_strAFACCTNO)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_frm.Dispose()
        End Try
    End Sub

    Private Sub btnEADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEADD.Click
        If Me.txtACCTNO.Text.Length = 10 Then
            showForm_CFOTHERACC(ExecuteFlag.AddNew)
        Else
            MsgBox(ResourceManager.GetString("ACCTNO_INVALID"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            Me.txtACCTNO.Focus()
        End If
    End Sub

    Private Sub btnEEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEEDIT.Click
        If (m_blnGridCI = True AndAlso ExtCIGrid.CurrentGrid.DataRows.Count > 0) OrElse (m_blnGridCI = False AndAlso ExtBankAccGrid.CurrentGrid.DataRows.Count > 0) Then
            showForm_CFOTHERACC(ExecuteFlag.Edit)
        End If
    End Sub

    Private Sub btnEVIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEVIEW.Click
        If (m_blnGridCI = True AndAlso ExtCIGrid.CurrentGrid.DataRows.Count > 0) OrElse (m_blnGridCI = False AndAlso ExtBankAccGrid.CurrentGrid.DataRows.Count > 0) Then
            showForm_CFOTHERACC(ExecuteFlag.View)
        End If
    End Sub

    Private Sub btnEDEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEDEL.Click
        If (m_blnGridCI = True AndAlso ExtCIGrid.CurrentGrid.DataRows.Count > 0) OrElse (m_blnGridCI = False AndAlso ExtBankAccGrid.CurrentGrid.DataRows.Count > 0) Then
            Delete_TabPage_Row(gc_IsNotLocalMsg, "SA.CFOTHERACC")
            LoadCFOTHERACC(Me.txtACCTNO.Text)
        End If
    End Sub

#End Region

#Region " Form events "
    Private Sub ExtBankAccGrid_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ExtBankAccGrid.GotFocus
        m_blnGridCI = False
    End Sub

    Private Sub ExtCIGrid_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ExtCIGrid.GotFocus
        m_blnGridCI = True
    End Sub

    Private Sub txtCUSTID_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCUSTID.Validating
        Try
            If Len(Me.txtCUSTID.Text) = 10 AndAlso ExeFlag <> ExecuteFlag.View Then
                'Lay thong tin ve khach hang
                GetCustomerInfor(txtCUSTID.Text)
                'Modified by TheNN
                If TellerId <> ADMIN_ID Then
                    If Not VerifyCareBy() Then
                        MsgBox(ResourceManager.GetString("NotCareBy"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                        OnClose()
                        Exit Sub
                    End If
                End If
                If (ExeFlag = ExecuteFlag.AddNew And v_strCUSTODYCD.Trim.Length > 0) Then
                    Me.txtCUSTODYCD.Text = v_strCUSTODYCD
                    Me.lblCUSTODYCD.ForeColor = System.Drawing.Color.Blue
                    Me.btnGenCustodyCD.Enabled = False
                    Me.txtCUSTODYCD.Enabled = False
                End If

                If (ExeFlag = ExecuteFlag.AddNew) Then
                    lblCUSTNAME.Text = v_strCustInfor
                    Me.txtEMAIL.Text = v_strEmail
                    Me.txtFAX.Text = v_strFax
                    Me.txtFAX1.Text = v_strFax1
                    Me.txtPHONE1.Text = v_strPhone1
                    Me.txtTRADEPHONE.Text = v_strMobile
                    Me.txtADDRESS.Text = v_strAddress
                    Me.cboCAREBY.SelectedValue = mv_strCareBy  ' Dien them
                    'Me.txtTLID.Text = mv_strTlid               ' Dien them 
                    If v_strCUSTODYCD.Length > 0 Then
                        Me.txtCUSTODYCD.Text = v_strCUSTODYCD
                        Me.lblCUSTODYCD.ForeColor = System.Drawing.Color.Blue
                        Me.btnGenCustodyCD.Enabled = False
                        Me.txtCUSTODYCD.Enabled = False
                    Else
                        v_boolean = True

                        If (Me.txtCUSTODYCD.Text.Trim.Replace(".", "").Length <> 10 Or Me.btnGenCustodyCD.Enabled = False) Then
                            Me.txtCUSTODYCD.Text = String.Empty
                            Me.lblCUSTODYCD.ForeColor = System.Drawing.Color.Blue
                            Me.btnGenCustodyCD.Enabled = True
                            Me.txtCUSTODYCD.Enabled = True
                            Me.btnGenCustodyCD.Focus()
                        End If
                    End If
                    ''Binhpt add
                    If (mv_IsOnlineRegister) Then
                        btnOTDEL.Enabled = True
                        GetCustomerInforOL(mv_OLAUTOID)
                        Me.cboAUTOADV.SelectedValue = mv_cashinadvanceauto
                        Me.cboTRADETELEPHONE.SelectedValue = mv_placeorderphone
                        Me.txtFAX1.Text = mv_smsphonenumber
                        Me.cboVIA.SelectedValue = "O"
                        If (Not mv_IsCreatOtright_CfOtherAcc) Then
                            Me.txtACCTNO.Text = getContract(Me.BranchId)
                            OnSaveOTRIGHT()
                            OnSaveCFOTHERACC()
                            Me.txtACCTNO.Enabled = False
                            mv_IsCreatOtright_CfOtherAcc = True
                        End If
                    End If
                    ''end
                End If
                Dim v_strCmdSQL, v_strObjMsg As String
                Dim v_intIndex As Integer
                Dim v_ws As New BDSDeliveryManagement
                If (v_strCUSTATCOM.Length > 0) Then

                    v_strCmdSQL = "SELECT  CDVAL VALUECD, CDVAL VALUE, CDCONTENT DISPLAY FROM ALLCODE WHERE CDTYPE = 'SY' AND CDNAME = 'YESNO' AND CDVAL = '" & v_strCUSTATCOM & "'"
                    If v_strCmdSQL.Trim.Length > 0 Then
                        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
                        v_ws.Message(v_strObjMsg)
                        FillComboEx(v_strObjMsg, Me.cboCUSTATCOM, "", Me.UserLanguage)
                    End If
                    Me.cboCUSTATCOM.Enabled = False
                Else
                    v_strCmdSQL = "SELECT  CDVAL VALUECD, CDVAL VALUE, CDCONTENT DISPLAY FROM ALLCODE WHERE CDTYPE = 'SY' AND CDNAME = 'YESNO'   ORDER BY LSTODR"
                    If v_strCmdSQL.Trim.Length > 0 Then
                        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
                        v_ws.Message(v_strObjMsg)
                        FillComboEx(v_strObjMsg, Me.cboCUSTATCOM, "", Me.UserLanguage)
                    End If
                    Me.cboCUSTATCOM.Enabled = True
                End If


            Else
                If ExeFlag = ExecuteFlag.AddNew Then
                    lblCUSTNAME.Text = String.Empty
                    Me.txtEMAIL.Text = String.Empty
                    Me.txtFAX.Text = String.Empty
                    Me.txtFAX1.Text = String.Empty
                    Me.txtPHONE1.Text = String.Empty
                    Me.txtTRADEPHONE.Text = String.Empty
                    Me.txtADDRESS.Text = String.Empty
                    Me.cboCAREBY.SelectedValue = String.Empty  ' Dien them
                    'Me.txtTLID.Text = mv_strTlid               ' Dien them 

                    Me.txtCUSTODYCD.Text = String.Empty
                    Me.lblCUSTODYCD.ForeColor = System.Drawing.Color.Blue
                    Me.btnGenCustodyCD.Enabled = True
                    Me.txtCUSTODYCD.Enabled = True
                    v_boolean = True
                End If

            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                        & "Error code: System error!" & vbNewLine _
                        & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub btnGenContractNo_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenContractNo.Click
        If ExeFlag = ExecuteFlag.AddNew Then
            Me.txtACCTNO.Text = getContract(Me.BranchId)
        End If
    End Sub

    Private Sub btnGenCustodyCDNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenCustodyCD.Click
        Dim v_strContract As String = getCustodyCD(Me.BranchId)
        Me.txtCUSTODYCD.Text = v_strContract

    End Sub

    Private Sub txtACTYPE_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtACTYPE.KeyUp
        If e.KeyCode = Keys.F5 Then
            Dim frm As New frmSearchMaster(Me.UserLanguage)
            frm.TableName = "AFTYPE_LIST"
            frm.ModuleCode = "CF"
            frm.AuthCode = "NYNNYYNNNN" 'Không cho phép thực hiện chức năng nào 
            frm.IsLocalSearch = gc_IsNotLocalMsg
            frm.IsLookup = "Y"
            frm.SearchOnInit = False
            frm.BranchId = Me.BranchId
            frm.TellerId = Me.TellerId
            frm.AuthString = "YNNN"
            frm.MenuType = "O"
            frm.ShowDialog()
            Me.ActiveControl.Text = Trim(frm.ReturnValue)
            'Me.txtACTYPE.Text = frm.ReturnValue
            frm.Dispose()

        End If
    End Sub

    Private Sub txtACTYPE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtACTYPE.Validating
        Try
            If Me.ExeFlag <> ExecuteFlag.View Then

                If Trim(Me.txtCUSTID.Text).Length = 0 Then
                    MsgBox(ResourceManager.GetString("CUST_HAS_INDIVIDUAL_CONTRACT"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    Me.txtACTYPE.Clear()
                    Me.txtCUSTID.Focus()
                    Exit Sub
                End If
                If mv_blnLookup = False Then
                    GetAFTYPEs()
                End If
                If Len(Me.txtACTYPE.Text) = 4 Then
                    'Check AFtypes
                    If hAftype(Trim(txtACTYPE.Text)) Is Nothing Then
                        MsgBox(ResourceManager.GetString("ACTYPE_INVALID"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                        Me.txtACTYPE.Focus()
                        Exit Sub
                    Else
                        LoadACTYPE(Me.txtACTYPE.Text)
                        If Me.ExeFlag = ExecuteFlag.AddNew Then
                            Me.txtADVANCELINE.Text = 0
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                                    & "Error code: System error!" & vbNewLine _
                                    & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub


    Private Sub cboTRADETELEPHONE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTRADETELEPHONE.SelectedIndexChanged
        ' If Me.ExeFlag <> ExecuteFlag.Edit Then
        If Convert.ToString(cboTRADETELEPHONE.SelectedValue) = "N" Then
            txtPHONE1.Enabled = False
            'txtPHONE1.Text = String.Empty
            txtTRADEPHONE.Enabled = False
            'txtTRADEPHONE.Text = String.Empty
            txtPIN.Enabled = False
            lblTRADEPHONE.ForeColor = System.Drawing.Color.Blue
        Else
            txtPHONE1.Enabled = True
            txtPHONE1.Text = v_strPhone1
            txtTRADEPHONE.Enabled = True
            txtTRADEPHONE.Text = v_strMobile
            txtPIN.Enabled = True
            lblTRADEPHONE.ForeColor = System.Drawing.Color.Red
        End If
        ' End If
    End Sub

    Private Sub btnAPPROVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        v_strSender = "btnAPPROVE"
        OnSubmit()
        v_strSender = String.Empty
    End Sub

    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
        v_strSender = "btnApply"
    End Sub

    Private Sub ExtCIGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ExtCIGrid.Click
        Cursor.Current = Cursors.WaitCursor
        Cursor.Show()
        If Not (ExtCIGrid.CurrentRow Is Nothing) Then
            m_blnGridCI = True
            showForm_CFOTHERACC(ExecuteFlag.View)
        End If
    End Sub

    Private Sub ExtBankAccGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ExtBankAccGrid.Click
        Cursor.Current = Cursors.WaitCursor
        Cursor.Show()
        If Not (ExtBankAccGrid.CurrentRow Is Nothing) Then
            m_blnGridCI = False
            showForm_CFOTHERACC(ExecuteFlag.View)
        End If
    End Sub

    Private Sub tabRELATION_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabAFMAST.Click
        If (tabSevice.Focus = True) Then
            If Not mv_blnACTYPE_AllowCustomized Then
                'Me.grbLimit.Enabled = False
                Me.txtMARGINLINE.Enabled = False
                Me.txtADVANCELINE.Enabled = False
                Me.txtTRADELINE.Enabled = False
                Me.txtREPOLINE.Enabled = False
                Me.txtDEPOSITLINE.Enabled = False
                Me.txtTELELIMIT.Enabled = False
                Me.txtONLINELIMIT.Enabled = False
                Me.txtBRATIO.Enabled = False
                Me.txtDEPORATE.Enabled = False
                Me.txtFEEBASE.Enabled = False
                Me.txtMISCRATE.Enabled = False
                Me.txtTRADERATE.Enabled = False
            Else
                'Me.grbLimit.Enabled = True
                Me.txtMARGINLINE.Enabled = False
                Me.txtADVANCELINE.Enabled = False
                Me.txtTRADELINE.Enabled = False
                Me.txtREPOLINE.Enabled = False
                Me.txtDEPOSITLINE.Enabled = False
                Me.txtTELELIMIT.Enabled = False
                Me.txtONLINELIMIT.Enabled = False
                Me.txtBRATIO.Enabled = False
                Me.txtDEPORATE.Enabled = False
                Me.txtFEEBASE.Enabled = False
                Me.txtMISCRATE.Enabled = False
                Me.txtTRADERATE.Enabled = False
            End If
            Me.grbMRService.Enabled = False
        End If
    End Sub

    Private Sub cboTLMODCODE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTLMODCODE.SelectedIndexChanged
        LoadICCFType(Me.txtACCTNO.Text, Me.cboTLMODCODE.SelectedValue)
    End Sub

    Private Sub btnApprv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApprv.Click
        v_strSender = "btnApprv"
        Dim v_frm As New frmApprove
        v_frm.ExeFlag = ExeFlag
        v_frm.UserLanguage = UserLanguage
        v_frm.ModuleCode = ModuleCode
        v_frm.ObjectName = ObjectName
        v_frm.TableName = Mid(ObjectName, 4)
        v_frm.LocalObject = LocalObject
        v_frm.Text = Text
        v_frm.TellerId = TellerId
        v_frm.TellerRight = TellerRight
        v_frm.GroupCareBy = GroupCareBy
        v_frm.AuthString = AuthString
        v_frm.BranchId = BranchId
        v_frm.BusDate = Me.BusDate
        v_frm.KeyFieldName = KeyFieldName
        v_frm.KeyFieldType = KeyFieldType
        v_frm.KeyFieldValue = KeyFieldValue

        v_frm.LinkValue = LinkValue
        v_frm.LinkField = LinkField
        v_frm.ShowDialog()
        Me.DialogResult = DialogResult.OK
        MyBase.OnClose()
        v_strSender = String.Empty
    End Sub

    Private Sub btnCheckAcc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCheckAcc.Click
        Dim CkAccount As Boolean
        CkAccount = CheckContracNumber(Me.txtACCTNO.Text)
        If CkAccount = False Then
            MsgBox(ResourceManager.GetString("DUPACCTNO"))
        Else
            MsgBox(ResourceManager.GetString("NODUPACCTNO"))
        End If
    End Sub

    Private Sub tabAFMAST_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabAFMAST.SelectedIndexChanged
        Dim v_strACCTNO, v_strTabPageName As String
        v_strACCTNO = Me.txtACCTNO.Text.Trim
        If v_strACCTNO.Length > 0 Then
            'Lay so hop dong hien tai
            v_strTabPageName = tabAFMAST.TabPages(tabAFMAST.SelectedIndex).Name.ToLower
            If String.Compare(v_strTabPageName, "tabContractMember".ToLower) = 0 _
                And mv_blnRefreshTabPage_Members = False Then
                LoadCFLINK(v_strACCTNO)
            ElseIf String.Compare(v_strTabPageName, "tabAnthorize".ToLower) = 0 _
                And mv_blnRefreshTabPage_Authorized = False Then
                LoadCFAUTH(v_strACCTNO)
            ElseIf String.Compare(v_strTabPageName, "tabACCOUNT".ToLower) = 0 _
                And mv_blnRefreshTabPage_Accounts = False Then
                LoadCFAccount(Me.txtACCTNO.Text)
            ElseIf String.Compare(v_strTabPageName, "tabREPORT".ToLower) = 0 _
                And mv_blnRefreshTabPage_Report = False Then
                LoadCFRPTAFMAST(v_strACCTNO)
            ElseIf String.Compare(v_strTabPageName, "tabTXMAP".ToLower) = 0 _
            And mv_blnRefreshTabPage_Txmap = False Then
                LoadAFTXMAP(v_strACCTNO, txtACTYPE.Text)
            ElseIf String.Compare(v_strTabPageName, "tabEXTREFER".ToLower) = 0 _
                And mv_blnRefreshTabPage_RegisterAcctTrf = False Then
                LoadCFOTHERACC(v_strACCTNO)
            ElseIf String.Compare(v_strTabPageName, "tabICCF".ToLower) = 0 _
                And mv_blnRefreshTabPage_AFDefICCF = False Then
                If Me.cboTLMODCODE.SelectedIndex <> -1 Then
                    LoadICCFType(v_strACCTNO, Me.cboTLMODCODE.SelectedValue)
                End If
            ElseIf String.Compare(v_strTabPageName, "tabAFSERULE".ToLower) = 0 _
                And mv_blnRefreshTabPage_AFSERule = False Then
                LoadAFSERULE(v_strACCTNO, Me.txtACTYPE.Text)
            ElseIf String.Compare(v_strTabPageName, "tabOTRIGHT".ToLower) = 0 _
            And mv_blnRefreshTabPage_OTRight = False Then
                LoadOTRightAsgn(v_strACCTNO)
            ElseIf tabTemplates.Name.ToLower().Equals(v_strTabPageName) And mv_blnRefreshTabPage_Templates = False Then
                LoadTemplates(v_strACCTNO)
            End If
        End If
    End Sub

    Private Function LoadUsernameCareby()
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_strCMDSQL, v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Dim v_nodeList As Xml.XmlNodeList
        Try
            If txtTLID.Text.Length < 1 Then
                Exit Function
            End If
            v_strCMDSQL = "select tlp.tlname USERNAME  from tlprofiles tlp where tlp.tlid = '" & txtTLID.Text & "'"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCMDSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For v_intCount As Integer = 0 To v_nodeList.Count - 1
                For v_int As Integer = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                    With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                        Dim v_strFLDNAME As String = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("fldname").Value.Trim()
                        Dim v_strVALUE As String = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("oldval").Value.Trim()
                        If v_strFLDNAME = "USERNAME" Then
                            Me.lblUsername.Text = v_strVALUE
                            Exit Function
                        End If
                    End With
                Next
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    'Private Function LoadTlidCarebyWhenEdit()
    '    Dim v_xmlDocument As New Xml.XmlDocument
    '    Dim v_strCMDSQL, v_strObjMsg As String
    '    Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
    '    Dim v_nodeList As Xml.XmlNodeList
    '    Try
    '        Dim v_strCareby = cboCAREBY.SelectedValue
    '        v_strCMDSQL = "select tlg.tlid TLID, tlp.tlname username, tlp.tlfullname fullname from tlgrpusers tlg ,tlprofiles tlp where(tlg.tlid = tlp.tlid And rownum=1 and tlg.grpid like nvl('" & v_strCareby & "', '%'))"
    '        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCMDSQL)
    '        v_ws.Message(v_strObjMsg)
    '        v_xmlDocument.LoadXml(v_strObjMsg)
    '        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
    '        For v_intCount As Integer = 0 To v_nodeList.Count - 1
    '            For v_int As Integer = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
    '                With v_nodeList.Item(v_intCount).ChildNodes(v_int)
    '                    Dim v_strFLDNAME As String = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("fldname").Value.Trim()
    '                    Dim v_strVALUE As String = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("oldval").Value.Trim()
    '                    If v_strFLDNAME = "TLID" Then
    '                        Me.txtTLID.Text = v_strVALUE
    '                        Exit Function
    '                    End If
    '                End With
    '            Next
    '        Next
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

    Private Sub txtTLID_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTLID.KeyUp
        If e.KeyCode = Keys.F5 Then
            Dim frm As New frmSearch(Me.UserLanguage)
            frm.TableName = "CF.TLID"
            frm.ModuleCode = "CF"
            frm.AuthCode = "NNNNYYNNNN" 'Không cho phép thực hiện chức năng nào 
            frm.IsLocalSearch = gc_IsNotLocalMsg
            frm.IsLookup = "Y"
            frm.SearchOnInit = False
            frm.BranchId = Me.BranchId
            frm.TellerId = Me.TellerId
            frm.AFACCTNO = Trim(cboCAREBY.SelectedValue)
            frm.ShowDialog()
            'Me.ActiveControl.Text = Trim(frm.ReturnValue)
            Me.txtTLID.Text = frm.ReturnValue
            frm.Dispose()
        End If
    End Sub
    Private Sub txtTLID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTLID.LostFocus
        LoadUsernameCareby()
    End Sub

    Private Sub txtCUSTODYCD_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCUSTODYCD.Validating
        Dim v_strCustID As String
        Dim v_strSQL As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        ' kiem tra xem so luu ky da ton tai hay chua
        v_strSQL = "SELECT CUSTID FROM CFMAST WHERE  CUSTODYCD='" & Me.txtCUSTODYCD.Text.Replace(".", "") & "'"
        Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_AFMAST, gc_ActionInquiry, v_strSQL)
        v_ws.Message(v_strObjMsg)
        v_xmlDocument.LoadXml(v_strObjMsg)
        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
        If v_nodeList.Count = 1 Then
            v_strCustID = v_nodeList.Item(0).ChildNodes(0).InnerText.ToString
        ElseIf (v_nodeList.Count = 0 And (Me.txtCUSTID.Text.Trim.Length <> 10 Or Me.txtCUSTID.Enabled = False)) Then
            If ExeFlag = ExecuteFlag.AddNew Then
                lblCUSTNAME.Text = String.Empty
                Me.txtEMAIL.Text = String.Empty
                Me.txtFAX.Text = String.Empty
                Me.txtFAX1.Text = String.Empty
                Me.txtPHONE1.Text = String.Empty
                Me.txtTRADEPHONE.Text = String.Empty
                Me.txtADDRESS.Text = String.Empty
                Me.cboCAREBY.SelectedValue = String.Empty ' Dien them
                'Me.txtTLID.Text = mv_strTlid               ' Dien them 
                'If v_strCustID.Trim.Length > 0 Then
                Me.txtCUSTID.Text = String.Empty
                Me.lblCUSTID.ForeColor = System.Drawing.Color.Red
                Me.btnGenCustodyCD.Enabled = True
                Me.txtCUSTID.Enabled = True
                Me.cboCUSTATCOM.Enabled = True
                'Else
                'Me.txtCUSTODYCD.Text = String.Empty
                'Me.lblCUSTODYCD.ForeColor = System.Drawing.Color.Blue
                'Me.btnGenCustodyCD.Enabled = True
                'Me.txtCUSTODYCD.Enabled = True
                'v_boolean = True
                'End If
            End If
        End If

        Try
            If Len(v_strCustID) = 10 AndAlso ExeFlag <> ExecuteFlag.View Then
                'Lay thong tin ve khach hang

                GetCustomerInfor(v_strCustID)
                'Modified by TheNN
                If TellerId <> ADMIN_ID Then
                    If Not VerifyCareBy() Then
                        MsgBox(ResourceManager.GetString("NotCareBy"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                        OnClose()
                        Exit Sub
                    End If
                End If
                If ExeFlag = ExecuteFlag.AddNew Then
                    lblCUSTNAME.Text = v_strCustInfor
                    Me.txtEMAIL.Text = v_strEmail
                    Me.txtFAX.Text = v_strFax
                    Me.txtFAX1.Text = v_strFax1
                    Me.txtPHONE1.Text = v_strPhone1
                    Me.txtTRADEPHONE.Text = v_strMobile
                    Me.txtADDRESS.Text = v_strAddress
                    Me.cboCAREBY.SelectedValue = mv_strCareBy  ' Dien them
                    'Me.txtTLID.Text = mv_strTlid               ' Dien them 
                    'If v_strCustID.Trim.Length > 0 Then
                    Me.txtCUSTID.Text = v_strCustID
                    Me.lblCUSTID.ForeColor = System.Drawing.Color.Blue
                    Me.btnGenCustodyCD.Enabled = False
                    Me.txtCUSTID.Enabled = False
                    'Else
                    'Me.txtCUSTODYCD.Text = String.Empty
                    'Me.lblCUSTODYCD.ForeColor = System.Drawing.Color.Blue
                    'Me.btnGenCustodyCD.Enabled = True
                    'Me.txtCUSTODYCD.Enabled = True
                    'v_boolean = True
                    'End If
                    Me.txtACTYPE.Focus()
                End If
                Dim v_strCmdSQL As String
                Dim v_intIndex As Integer
                If (v_strCUSTATCOM.Length > 0) Then


                    v_strCmdSQL = "SELECT  CDVAL VALUECD, CDVAL VALUE, CDCONTENT DISPLAY FROM ALLCODE WHERE CDTYPE = 'SY' AND CDNAME = 'YESNO' AND CDVAL = '" & v_strCUSTATCOM & "'"
                    If v_strCmdSQL.Trim.Length > 0 Then
                        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
                        v_ws.Message(v_strObjMsg)
                        FillComboEx(v_strObjMsg, Me.cboCUSTATCOM, "", Me.UserLanguage)
                    End If
                    Me.cboCUSTATCOM.Enabled = False
                Else
                    v_strCmdSQL = "SELECT  CDVAL VALUECD, CDVAL VALUE, CDCONTENT DISPLAY FROM ALLCODE WHERE CDTYPE = 'SY' AND CDNAME = 'YESNO'   ORDER BY LSTODR"
                    If v_strCmdSQL.Trim.Length > 0 Then
                        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
                        v_ws.Message(v_strObjMsg)
                        FillComboEx(v_strObjMsg, Me.cboCUSTATCOM, "", Me.UserLanguage)
                    End If
                    Me.cboCUSTATCOM.Enabled = True
                End If
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                        & "Error code: System error!" & vbNewLine _
                        & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try

        Try
            If v_strCONTRACTCHK = "Y" AndAlso Me.txtCUSTODYCD.Text.Trim.Replace(".", "") <> String.Empty AndAlso (Me.txtCUSTODYCD.Text.Trim.Replace(".", "").Substring(0, 4) = "017C" OrElse Me.txtCUSTODYCD.Text.Trim.Replace(".", "").Substring(0, 4) = "017P") Then
                cboAUTOADV.SelectedValue = "Y"
            Else
                cboAUTOADV.SelectedValue = "N"
            End If
        Catch ex As Exception

        End Try
    End Sub

    'Private Sub cboCAREBY_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCAREBY.SelectedValueChanged
    '    LoadTlidCarebyWhenEdit()
    'End Sub


    Private Sub btnASADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnASADD.Click
        If Me.txtACCTNO.Text.Length = 10 Then
            showAFSERULE(ExecuteFlag.AddNew)
            LoadAFSERULE(Me.txtACCTNO.Text, Me.txtACTYPE.Text)
        Else
            MsgBox(ResourceManager.GetString("ACCTNO_INVALID"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            Me.txtACCTNO.Focus()
        End If
    End Sub

    Private Sub btnASVIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnASVIEW.Click
        If Me.txtACCTNO.Text.Length = 10 Then
            showAFSERULE(ExecuteFlag.View)
        Else
            MsgBox(ResourceManager.GetString("ACCTNO_INVALID"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            Me.txtACCTNO.Focus()
        End If

    End Sub

    Private Sub btnASEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnASEDIT.Click
        If Trim(CType(AFSERuleGrid.CurrentRow, Xceed.Grid.DataRow).Cells("TYPORMSTCD").Value) <> "M" Then
            MsgBox(ResourceManager.GetString("TYPORMSTCD_INVALID"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Else
            If Me.txtACCTNO.Text.Length = 10 Then
                showAFSERULE(ExecuteFlag.Edit)
                LoadAFSERULE(Me.txtACCTNO.Text, Me.txtACTYPE.Text)
            Else
                MsgBox(ResourceManager.GetString("ACCTNO_INVALID"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                Me.txtACCTNO.Focus()
            End If
        End If

    End Sub

    Private Sub btnASDEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnASDEL.Click
        Dim v_strObjMsg, v_strErrorSource, v_strErrorMessage, v_strClause As String
        Dim v_ws As New BDSDeliveryManagement
        Dim v_lngErrorCode As Long = ERR_SYSTEM_OK
        Try
            If Trim(CType(AFSERuleGrid.CurrentRow, Xceed.Grid.DataRow).Cells("TYPORMSTCD").Value) <> "M" Then
                MsgBox(ResourceManager.GetString("TYPORMSTCD_INVALID"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            Else
                v_strClause = " AUTOID = " & Trim(CType(AFSERuleGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value)
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, "CF.AFSERULE", gc_ActionDelete, , v_strClause, , , , , , , , ParentObjName, ParentClause)
                v_ws.Message(v_strObjMsg)
                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)


                If v_lngErrorCode <> 0 Then
                    'Update mouse pointer
                    Cursor.Current = Cursors.Default
                    MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                    Exit Sub
                Else
                    Cursor.Current = Cursors.Default
                    MsgBox(ResourceManager.GetString("DelSuccess"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                    LoadAFSERULE(Me.txtACCTNO.Text, Me.txtACTYPE.Text)
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnOTADD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOTADD.Click
        If Me.txtACCTNO.Text.Length = 10 Then
            ShowForm_OTRIGHT(ExecuteFlag.AddNew)
        Else
            MsgBox(ResourceManager.GetString("ACCTNO_INVALID"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            Me.txtACCTNO.Focus()
        End If
    End Sub

    Private Sub btnOTEDIT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOTEDIT.Click
        If Me.txtACCTNO.Text.Length = 10 Then
            ShowForm_OTRIGHT(ExecuteFlag.Edit)
        Else
            MsgBox(ResourceManager.GetString("ACCTNO_INVALID"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            Me.txtACCTNO.Focus()
        End If
    End Sub

    Private Sub btnOTVIEW_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOTVIEW.Click
        If Me.txtACCTNO.Text.Length = 10 Then
            ShowForm_OTRIGHT(ExecuteFlag.View)
        Else
            MsgBox(ResourceManager.GetString("ACCTNO_INVALID"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            Me.txtACCTNO.Focus()
        End If
    End Sub

    Private Sub btnOTDEL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOTDEL.Click
        OnDeleteOTRIGHT()
    End Sub

    Private Sub txtEMAIL_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtEMAIL.Validating
        'Kiem tra dinh dang Email phai hop le
        If Trim(Me.txtEMAIL.Text).Length > 0 Then
            If InStr(Trim(Me.txtEMAIL.Text), " ") > 0 Or InStr(Trim(Me.txtEMAIL.Text), "@") <= 0 Or InStr(Mid(Trim(Me.txtEMAIL.Text), InStr(Trim(Me.txtEMAIL.Text), "@") + 1), ".") <= 0 Then
                MsgBox(ResourceManager.GetString("msgINVALIDEMAILFORMAT"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                Me.txtEMAIL.Focus()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub AnthorizeGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AnthorizeGrid.Click
        If CType(AnthorizeGrid.CurrentRow, Xceed.Grid.DataRow).Cells("DELTD").Value = "Y" Then
            btnAEDIT.Enabled = False
            btnADEL.Enabled = False
        Else
            btnAEDIT.Enabled = True
            btnADEL.Enabled = True
        End If
    End Sub

#End Region

    Private Sub btnAddTemplate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddTemplate.Click
        If Me.txtACCTNO.Text.Length = 10 Then
            'ShowTemplate(ExecuteFlag.AddNew)
            Dim frmSearch As New frmSearch(UserLanguage)
            frmSearch.BusDate = Me.BusDate


            frmSearch.TableName = "ADDTEMPLATES"
            frmSearch.ModuleCode = Me.ModuleCode
            '     frmSearch.AuthCode = "NYNNYYYNNN" 'Chỉ cho phép g?i chức năng tạo giao dịch kế tiếp (Choose)
            frmSearch.AuthCode = "NYNNYYYNNN" 'Chỉ cho phép g?i chức năng tạo giao dịch kế tiếp (Choose)
            'frmSearch.AuthCode = frm.AuthCode
            frmSearch.CMDTYPE = "V"
            frmSearch.IsLocalSearch = gc_IsNotLocalMsg
            frmSearch.SearchOnInit = False
            frmSearch.BranchId = Me.BranchId
            frmSearch.TellerId = Me.TellerId
            frmSearch.LinkValue = Me.txtACCTNO.Text
            frmSearch.ShowDialog()
            'LoadDetailData(Me.tabMaster.TabPages(v_idx).Name)
            LoadTemplates(Me.txtACCTNO.Text)
        Else
            MsgBox(ResourceManager.GetString("ACCTNO_INVALID"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            Me.txtACCTNO.Focus()
        End If
    End Sub

    Private Sub btnViewTemplate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewTemplate.Click
        If Me.txtACCTNO.Text.Length = 10 Then
            ShowTemplate(ExecuteFlag.View)
        Else
            MsgBox(ResourceManager.GetString("ACCTNO_INVALID"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            Me.txtACCTNO.Focus()
        End If
    End Sub

    Private Sub btnEditTemplate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditTemplate.Click
        If CType(TemplateGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value = -1 Then
            MsgBox(ResourceManager.GetString("TEMPLATE_AUTOID_INVALID"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Else
            If Me.txtACCTNO.Text.Length = 10 Then
                ShowTemplate(ExecuteFlag.Edit)
                LoadTemplates(Me.txtACCTNO.Text)
            Else
                MsgBox(ResourceManager.GetString("ACCTNO_INVALID"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                Me.txtACCTNO.Focus()
            End If
        End If
    End Sub

    Private Sub btnDeleteTemplate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteTemplate.Click
        Dim v_strObjMsg, v_strErrorSource, v_strErrorMessage, v_strClause As String
        Dim v_ws As New BDSDeliveryManagement
        Dim v_lngErrorCode As Long = ERR_SYSTEM_OK
        Try
            If CType(TemplateGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value = -1 Then
                MsgBox(ResourceManager.GetString("TEMPLATE_AUTOID_INVALID"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            Else
                v_strClause = " AUTOID = " & Trim(CType(TemplateGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value)
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, "SA.AFTEMPLATES", gc_ActionDelete, , v_strClause, , , , , , , , ParentObjName, ParentClause)
                v_ws.Message(v_strObjMsg)
                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)


                If v_lngErrorCode <> 0 Then
                    'Update mouse pointer
                    Cursor.Current = Cursors.Default
                    MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                    Exit Sub
                Else
                    Cursor.Current = Cursors.Default
                    MsgBox(ResourceManager.GetString("DelSuccess"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                    LoadTemplates(Me.txtACCTNO.Text)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub ShowTemplate(ByVal pv_intExecFlag As Integer)
        Dim v_strKeyValue As String = String.Empty
        Dim v_strModuleCode, v_strObjName, v_strTableName, v_strKeyField, v_strKeyFieldType, v_strParentValue As String
        Try
            'Insert
            If (pv_intExecFlag = ExecuteFlag.AddNew) Then
                v_strKeyValue = String.Empty
            ElseIf (pv_intExecFlag = ExecuteFlag.Edit Or pv_intExecFlag = ExecuteFlag.View) Then
                v_strKeyValue = Trim(CType(TemplateGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value)
            End If

            If v_strKeyValue.Equals("-1") Then
                Return
            End If

            v_strModuleCode = "SA"
            v_strObjName = "SA.AFTEMPLATES"
            v_strTableName = "AFTEMPLATES"
            v_strKeyField = "AUTOID"
            v_strKeyFieldType = "N"
            v_strParentValue = Me.txtACCTNO.Text.Replace(".", "")

            Dim v_frm As New frmMaster(v_strTableName, pv_intExecFlag, UserLanguage, v_strModuleCode, v_strObjName, gc_IsNotLocalMsg, _
                                        Me.tabAFSERULE.Text, TellerId, TellerRight, GroupCareBy, AuthString, BranchId, BusDate, v_strKeyField, _
                                        v_strKeyFieldType, v_strKeyValue, LinkValue, Me.LinkField, v_strParentValue, Me.ObjectName, Me.ModuleCode, Me.mv_arrObjFields)
            Dim frmResult As DialogResult = v_frm.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub LoadTemplates(ByVal pv_strAFACCTNO As String)
        Dim v_xmlDocument As New XmlDocument
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            Dim v_strCmdInquiry, v_strObjMsg As String

            If Not AFSERuleGrid Is Nothing And Len(pv_strAFACCTNO) > 0 Then
                'Clear old data
                TemplateGrid.DataRows.Clear()

                v_strCmdInquiry = "SELECT A.AUTOID, T.NAME, T.SUBJECT FROM AFTEMPLATES A, TEMPLATES T WHERE A.TEMPLATE_CODE = T.CODE AND A.AFACCTNO = '{0}' " & ControlChars.CrLf & _
                "UNION SELECT -1 AUTOID, T.NAME, T.SUBJECT FROM TEMPLATES T WHERE T.REQUIRE_REGISTER = 'N'"

                v_strCmdInquiry = String.Format(v_strCmdInquiry, pv_strAFACCTNO)

                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, MyBase.LocalObject, gc_MsgTypeObj, OBJNAME_SA_ALLCODE, gc_ActionInquiry, v_strCmdInquiry)
                v_ws.Message(v_strObjMsg)
                FillDataGrid(TemplateGrid, v_strObjMsg, "")
                mv_blnRefreshTabPage_Templates = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_xmlDocument = Nothing
            v_ws = Nothing
        End Try
    End Sub
End Class
