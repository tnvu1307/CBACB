Imports AppCore
Imports CommonLibrary
Imports System.Xml.XmlNode
Imports System.Xml
Imports TestBase64
Imports ZetaCompressionLibrary
Imports System.IO

Public Class frmCFMAST_bk
    Inherits AppCore.frmMaintenance
    Const STAFF_ISSUER_EMPLOYEE = "004"
    Private mv_arrAUTOID As String()
    Private mv_arrSIGNATURE As String()
    Private mv_arrCUSTID As String()
    Private mv_arrVALDATE As String()
    Private mv_arrEXPDATE As String()

    Private mv_intCurrImageIndex As Integer = 0
    Private mv_ImageViewer As New ImageViewer
    Public v_strBranchID As String
    Private v_strSender As String
    Private mv_COUNTRYTable As New DataTable
    Private mv_PROVINCETable As New DataTable

    Public mv_OLAUTOID As String = String.Empty
    Public mv_CustomerType As String = String.Empty
    Public mv_CustomerName As String = String.Empty
    Public mv_CustomerBirth As String = String.Empty
    Public mv_IDType As String = String.Empty
    Public mv_IDCode As String = String.Empty
    Public mv_Iddate As String = String.Empty
    Public mv_Idplace As String = String.Empty
    Public mv_Expiredate As String = String.Empty
    Public mv_Address As String = String.Empty
    Public mv_Taxcode As String = String.Empty
    Public mv_PrivatePhone As String = String.Empty
    Public mv_Mobile As String = String.Empty
    Public mv_Fax As String = String.Empty
    Public mv_Email As String = String.Empty
    Public mv_Office As String = String.Empty
    Public mv_Position As String = String.Empty
    Public mv_Country As String = String.Empty
    Public mv_CustomerCity As String = String.Empty
    Public mv_TKTGTT As String = String.Empty
    Public IsOnlineRegister As Boolean = False

#Region " Declare constants and variables "
    Public ContactsGrid As GridEx
    Public SignaturesGrid As GridEx
    Public AccountsGrid As GridEx
    Public RelationGrid As GridEx
    Public MemberGrid As GridEx
    Public LimitGrid As GridEx
    Public LoanGrid As GridEx
    Public LNLimitBankingGrid As GridEx
    Public MessageData As String
    Private mv_blnAcctEntry As Boolean = False
    Private mv_arrObjFldVals() As CFieldVal
    Private mv_strIpAddress As String
    Private mv_strWsName As String
    Private mv_blnComboCountryLoad As Boolean = False


    Const ISSUER_MEMBER_AUTOID_EN = "Auto Id"
    Const ISSUER_MEMBER_CUSTID_EN = "Cust Id"
    Const ISSUER_MEMBER_FULLNAME_EN = "Full name"
    Const ISSUER_MEMBER_ROLECD_EN = "Role cd"
    Const ISSUER_MEMBER_LICENSENO_EN = "Licenseno"
    Const ISSUER_MEMBER_IDDATE_EN = "Id date"
    Const ISSUER_MEMBER_IDEXPIRED_EN = "Id exprired"
    Const ISSUER_MEMBER_IDPLACE_EN = "Id Place"
    Const ISSUER_MEMBER_DESCRIPTION_EN = "Description"


    Const ISSUER_MEMBER_AUTOID_VN = "MÃ£ tá»± tÄƒng"
    Const ISSUER_MEMBER_CUSTID_VN = "MÃ£ khÃ¡ch hÃ ng"
    Const ISSUER_MEMBER_FULLNAME_VN = "TÃªn khÃ¡ch hÃ ng"
    Const ISSUER_MEMBER_ROLECD_VN = "Vai trÃ²"
    Const ISSUER_MEMBER_LICENSENO_VN = "Sá»‘ Ä‘Äƒng kÃ½"
    Const ISSUER_MEMBER_IDDATE_VN = "NgÃ y Ä‘Äƒng kÃ½"
    Const ISSUER_MEMBER_IDEXPIRED_VN = "NgÃ y háº¿t háº¡n"
    Const ISSUER_MEMBER_IDPLACE_VN = "NÆ¡i Ä‘Äƒng kÃ½"
    Const ISSUER_MEMBER_DESCRIPTION_VN = "MÃ´ táº£"

    Const CONTACT_AUTOID_EN = "ID"
    Const CONTACT_TYPE_EN = "Type"
    Const CONTACT_PERSON_EN = "Person"
    Const CONTACT_ADDRESS_EN = "Address"
    Const CONTACT_PHONE_EN = "Phone"
    Const CONTACT_FAX_EN = "Fax"
    Const CONTACT_EMAIL_EN = "Email"
    Const CONTACT_DESCRIPTION_EN = "Description"

    Const CONTACT_AUTOID_VN = "ID"
    Const CONTACT_TYPE_VN = "Loáº¡i"
    Const CONTACT_PERSON_VN = "TÃªn"
    Const CONTACT_ADDRESS_VN = "Ä?á»‹a chá»‰"
    Const CONTACT_PHONE_VN = "Ä?iá»‡n thoáº¡i"
    Const CONTACT_FAX_VN = "Fax"
    Const CONTACT_EMAIL_VN = "Email"
    Const CONTACT_DESCRIPTION_VN = "Ghi chÃº"

    Const SIGNATURE_AUTOID_EN = "ID"
    Const SIGNATURE_IMAGE_EN = "Image"
    Const SIGNATURE_AUTOID_VN = "ID"
    Const SIGNATURE_IMAGE_VN = "Chá»¯ kÃ½"

    Const ACCOUNT_AFACCTNO_EN = "Contract number"
    Const ACCOUNT_AFROLE_EN = "Contract role"
    Const ACCOUNT_MODULE_EN = "Account type"
    Const ACCOUNT_SYMBOL_EN = "Symbol"
    Const ACCOUNT_ACCTNO_EN = "Account number"
    Const ACCOUNT_BALANCE_EN = "Balance"
    Const ACCOUNT_AFTYPE_EN = "Actype"
    Const ACCOUNT_AFTYPE_NAME_EN = "Actype name"

    Const ACCOUNT_AFACCTNO_VN = ""
    Const ACCOUNT_AFROLE_VN = ""
    Const ACCOUNT_MODULE_VN = ""
    Const ACCOUNT_SYMBOL_VN = ""
    Const ACCOUNT_ACCTNO_VN = ""
    Const ACCOUNT_BALANCE_VN = ""
    Const ACCOUNT_AFTYPE_VN = "Actype"
    Friend WithEvents lblRISKLEVEL As System.Windows.Forms.Label
    Friend WithEvents cboRISKLEVEL As AppCore.ComboBoxEx
    Friend WithEvents lblVALDATE As System.Windows.Forms.Label
    Friend WithEvents dtpVALDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEXPDATE As System.Windows.Forms.Label
    Friend WithEvents dtpEXPDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtTRADINGCODE As System.Windows.Forms.TextBox
    Friend WithEvents lblTRADINGCODE As System.Windows.Forms.Label
    Friend WithEvents dtpTRADINGCODEDT As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblTRADINGCODEDT As System.Windows.Forms.Label
    Friend WithEvents txtBRID As System.Windows.Forms.TextBox
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents txtTLID As System.Windows.Forms.TextBox
    Friend WithEvents lblUsername As System.Windows.Forms.Label
    Friend WithEvents dtpOPNDATE As System.Windows.Forms.TextBox
    Friend WithEvents lblOPNDATE As System.Windows.Forms.Label
    Friend WithEvents cboCONTRACTCHK As AppCore.ComboBoxEx
    Friend WithEvents lblCONTRACTCHK As System.Windows.Forms.Label
    Friend WithEvents lblMARGINALLOW As System.Windows.Forms.Label
    Friend WithEvents cboMARGINALLOW As AppCore.ComboBoxEx
    Friend WithEvents tabLNLIMITMAX As System.Windows.Forms.TabPage
    Friend WithEvents pnLNLIMITMAX As System.Windows.Forms.Panel
    Const ACCOUNT_AFTYPE_NAME_VN = "Actype name"

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

    Public Property COUNTRYTable() As DataTable
        Get
            Return mv_COUNTRYTable
        End Get
        Set(ByVal Value As DataTable)
            mv_COUNTRYTable = Value
        End Set
    End Property
    Public Property PROVINCETable() As DataTable
        Get
            Return mv_PROVINCETable
        End Get
        Set(ByVal Value As DataTable)
            mv_PROVINCETable = Value
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
    Friend WithEvents txtCUSTID As System.Windows.Forms.TextBox
    'Friend WithEvents cboIDTYPE As System.Windows.Forms.ComboBox
    ''Friend WithEvents cboCOUNTRY As System.Windows.Forms.ComboBox
    'Friend WithEvents cboPROVINCE As System.Windows.Forms.ComboBox
    'Friend WithEvents cboSEX As System.Windows.Forms.ComboBox
    'Friend WithEvents cboRESIDENT As System.Windows.Forms.ComboBox
    'Friend WithEvents cboCLASS As System.Windows.Forms.ComboBox
    'Friend WithEvents cboGRINVESTOR As System.Windows.Forms.ComboBox
    'Friend WithEvents cboINVESTRANGE As System.Windows.Forms.ComboBox
    'Friend WithEvents cboTIMETOJOIN As System.Windows.Forms.ComboBox
    'Friend WithEvents cboSTAFF As System.Windows.Forms.ComboBox
    'Friend WithEvents cboPOSITION As System.Windows.Forms.ComboBox
    'Friend WithEvents cboSECTOR As System.Windows.Forms.ComboBox
    'Friend WithEvents cboEXPERIENCETYPE As System.Windows.Forms.ComboBox
    'Friend WithEvents cboINVESTTYPE As System.Windows.Forms.ComboBox
    'Friend WithEvents cboBUSINESSTYPE As System.Windows.Forms.ComboBox
    'Friend WithEvents cboASSETRANGE As System.Windows.Forms.ComboBox
    'Friend WithEvents cboINCOMERANGE As System.Windows.Forms.ComboBox
    'Friend WithEvents cboFOCUSTYPE As System.Windows.Forms.ComboBox
    'Friend WithEvents cboLANGUAGE As System.Windows.Forms.ComboBox
    'Friend WithEvents cboBANKCODE As System.Windows.Forms.ComboBox
    'Friend WithEvents txtCAREBY As System.Windows.Forms.TextBox
    Friend WithEvents tabIDENTIFICATION As System.Windows.Forms.TabPage
    Friend WithEvents dtpIDEXPIRED As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpIDDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDATEOFBIRTH As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblIDTYPE As System.Windows.Forms.Label
    Friend WithEvents cboIDTYPE As AppCore.ComboBoxEx
    Friend WithEvents txtSHORTNAME As System.Windows.Forms.TextBox
    Friend WithEvents lblSHORTNAME As System.Windows.Forms.Label
    Friend WithEvents lblFULLNAME As System.Windows.Forms.Label
    Friend WithEvents txtFULLNAME As System.Windows.Forms.TextBox
    Friend WithEvents txtMNEMONIC As System.Windows.Forms.TextBox
    Friend WithEvents lblMNEMONIC As System.Windows.Forms.Label
    Friend WithEvents lblIDDATE As System.Windows.Forms.Label
    Friend WithEvents txtIDPLACE As System.Windows.Forms.TextBox
    Friend WithEvents lblIDPLACE As System.Windows.Forms.Label
    Friend WithEvents txtFAX As System.Windows.Forms.TextBox
    Friend WithEvents lblFAX As System.Windows.Forms.Label
    Friend WithEvents lblADDRESS As System.Windows.Forms.Label
    Friend WithEvents txtADDRESS As System.Windows.Forms.TextBox
    Friend WithEvents lblPHONE As System.Windows.Forms.Label
    Friend WithEvents txtPHONE As System.Windows.Forms.TextBox
    Friend WithEvents cboCOUNTRY As AppCore.ComboBoxEx
    Friend WithEvents lblCOUNTRY As System.Windows.Forms.Label
    Friend WithEvents cboPROVINCE As AppCore.ComboBoxEx
    Friend WithEvents lblPROVINCE As System.Windows.Forms.Label
    Friend WithEvents lblSEX As System.Windows.Forms.Label
    Friend WithEvents cboSEX As AppCore.ComboBoxEx
    Friend WithEvents txtDESCRIPTION As System.Windows.Forms.TextBox
    Friend WithEvents lblDESCRIPTION As System.Windows.Forms.Label
    Friend WithEvents lblIDEXPIRED As System.Windows.Forms.Label
    Friend WithEvents lblDATEOFBIRTH As System.Windows.Forms.Label
    Friend WithEvents lblMOBILE As System.Windows.Forms.Label
    Friend WithEvents txtMOBILE As System.Windows.Forms.TextBox
    Friend WithEvents txtEMAIL As System.Windows.Forms.TextBox
    Friend WithEvents lblEMAIL As System.Windows.Forms.Label
    Friend WithEvents lblIDCODE As System.Windows.Forms.Label
    Friend WithEvents tabCLASSIFICATION As System.Windows.Forms.TabPage
    Friend WithEvents txtISSUERID As System.Windows.Forms.TextBox
    Friend WithEvents lblISSUERID As System.Windows.Forms.Label
    Friend WithEvents lblGRINVESTOR As System.Windows.Forms.Label
    Friend WithEvents cboCLASS As AppCore.ComboBoxEx
    Friend WithEvents lblCLASS As System.Windows.Forms.Label
    Friend WithEvents cboGRINVESTOR As AppCore.ComboBoxEx
    Friend WithEvents cboINVESTRANGE As AppCore.ComboBoxEx
    Friend WithEvents lblINVESTRANGE As System.Windows.Forms.Label
    Friend WithEvents lblSTAFF As System.Windows.Forms.Label
    Friend WithEvents cboTIMETOJOIN As AppCore.ComboBoxEx
    Friend WithEvents lblTIMETOJOIN As System.Windows.Forms.Label
    Friend WithEvents txtCOMPANYID As System.Windows.Forms.TextBox
    Friend WithEvents lblCOMPANYID As System.Windows.Forms.Label
    Friend WithEvents cboSTAFF As AppCore.ComboBoxEx
    Friend WithEvents lblSECTOR As System.Windows.Forms.Label
    Friend WithEvents lblPOSITION As System.Windows.Forms.Label
    Friend WithEvents cboPOSITION As AppCore.ComboBoxEx
    Friend WithEvents cboSECTOR As AppCore.ComboBoxEx
    Friend WithEvents lblINVESTTYPE As System.Windows.Forms.Label
    Friend WithEvents lblBUSINESSTYPE As System.Windows.Forms.Label
    Friend WithEvents lblEXPERIENCETYPE As System.Windows.Forms.Label
    Friend WithEvents cboEXPERIENCETYPE As AppCore.ComboBoxEx
    Friend WithEvents cboINVESTTYPE As AppCore.ComboBoxEx
    Friend WithEvents cboBUSINESSTYPE As AppCore.ComboBoxEx
    Friend WithEvents lblASSETRANGE As System.Windows.Forms.Label
    Friend WithEvents lblINCOMERANGE As System.Windows.Forms.Label
    Friend WithEvents cboINCOMERANGE As AppCore.ComboBoxEx
    Friend WithEvents cboFOCUSTYPE As AppCore.ComboBoxEx
    Friend WithEvents lblFOCUSTYPE As System.Windows.Forms.Label
    Friend WithEvents tabSERVICES As System.Windows.Forms.TabPage
    Friend WithEvents lblLANGUAGE As System.Windows.Forms.Label
    Friend WithEvents cboLANGUAGE As AppCore.ComboBoxEx
    Friend WithEvents lblCUSTODYCD As System.Windows.Forms.Label
    Friend WithEvents lblBANKACCTNO As System.Windows.Forms.Label
    Friend WithEvents txtBANKACCTNO As System.Windows.Forms.TextBox
    Friend WithEvents lblBANKCODE As System.Windows.Forms.Label
    Friend WithEvents cboBANKCODE As AppCore.ComboBoxEx
    Friend WithEvents lblMARGINLIMIT As System.Windows.Forms.Label
    Friend WithEvents txtMARGINLIMIT As System.Windows.Forms.TextBox
    Friend WithEvents lblTRADELIMIT As System.Windows.Forms.Label
    Friend WithEvents txtTRADELIMIT As System.Windows.Forms.TextBox
    Friend WithEvents lblADVANCELIMIT As System.Windows.Forms.Label
    Friend WithEvents txtADVANCELIMIT As System.Windows.Forms.TextBox
    Friend WithEvents txtREPOLIMIT As System.Windows.Forms.TextBox
    Friend WithEvents lblREPOLIMIT As System.Windows.Forms.Label
    Friend WithEvents txtDEPOSITLIMIT As System.Windows.Forms.TextBox
    Friend WithEvents lblDEPOSITLIMIT As System.Windows.Forms.Label
    Friend WithEvents lblMORTAGERATE As System.Windows.Forms.Label
    Friend WithEvents txtMORTAGERATE As System.Windows.Forms.TextBox
    Friend WithEvents tabCONTACTS As System.Windows.Forms.TabPage
    Friend WithEvents btnCEDIT As System.Windows.Forms.Button
    Friend WithEvents btnCDEL As System.Windows.Forms.Button
    Friend WithEvents btnCVIEW As System.Windows.Forms.Button
    Friend WithEvents tabSIGNATURES As System.Windows.Forms.TabPage
    Friend WithEvents btnSADD As System.Windows.Forms.Button
    Friend WithEvents btnSEDIT As System.Windows.Forms.Button
    Friend WithEvents btnSDEL As System.Windows.Forms.Button
    Friend WithEvents btnSVIEW As System.Windows.Forms.Button
    Friend WithEvents tabCONTRACTS As System.Windows.Forms.TabPage
    Friend WithEvents txtIDCODE As System.Windows.Forms.TextBox
    Friend WithEvents txtCUSTODYCD As System.Windows.Forms.TextBox
    Friend WithEvents pnSignatures As System.Windows.Forms.Panel
    Friend WithEvents pnContacts As System.Windows.Forms.Panel
    Friend WithEvents btnCADD As System.Windows.Forms.Button
    Friend WithEvents cboMARRIED As AppCore.ComboBoxEx
    Friend WithEvents lblMARRIED As System.Windows.Forms.Label
    Friend WithEvents lblREFNAME As System.Windows.Forms.Label
    Friend WithEvents txtREFNAME As AppCore.FlexMaskEditBox
    Friend WithEvents tabRELATION As System.Windows.Forms.TabControl
    Friend WithEvents tabRELATION1 As System.Windows.Forms.TabPage
    Friend WithEvents pnRelation As System.Windows.Forms.Panel
    Friend WithEvents btnRADD As System.Windows.Forms.Button
    Friend WithEvents btnREDIT As System.Windows.Forms.Button
    Friend WithEvents btnRDEL As System.Windows.Forms.Button
    Friend WithEvents btnRVIEW As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblTAXCODE As System.Windows.Forms.Label
    Friend WithEvents txtTAXCODE As System.Windows.Forms.TextBox
    Friend WithEvents cboEDUCATION As ComboBoxEx
    Friend WithEvents lblEDUCATION As System.Windows.Forms.Label
    Friend WithEvents cboOCCUPATION As ComboBoxEx
    Friend WithEvents lblOCCUPATION As System.Windows.Forms.Label
    Friend WithEvents btnPREVIOUS As System.Windows.Forms.Button
    Friend WithEvents btnNEXT As System.Windows.Forms.Button
    Friend WithEvents lblCUSTID As System.Windows.Forms.Label
    Friend WithEvents lblCUSTTYPE As System.Windows.Forms.Label
    Friend WithEvents cboCUSTTYPE As AppCore.ComboBoxEx
    Friend WithEvents btnGETCUSTID As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblINTERNATION As System.Windows.Forms.Label
    Friend WithEvents txtINTERNATION As System.Windows.Forms.TextBox
    Friend WithEvents tabISSUER As System.Windows.Forms.TabPage
    Friend WithEvents pnISSUER As System.Windows.Forms.Panel
    Friend WithEvents btnADDISSUER As System.Windows.Forms.Button
    Friend WithEvents btnVIEWISSUER As System.Windows.Forms.Button
    Friend WithEvents btnEDITISSUER As System.Windows.Forms.Button
    Friend WithEvents btnDELISSUER As System.Windows.Forms.Button
    Friend WithEvents txtEXPERIENCECD As System.Windows.Forms.TextBox
    Friend WithEvents chkEQUITIES As System.Windows.Forms.CheckBox
    Friend WithEvents chkBOND As System.Windows.Forms.CheckBox
    Friend WithEvents chkFOREX As System.Windows.Forms.CheckBox
    Friend WithEvents chkOTHERS As System.Windows.Forms.CheckBox
    Friend WithEvents chkREALESTATE As System.Windows.Forms.CheckBox
    Friend WithEvents lblSTATUS As System.Windows.Forms.Label
    Friend WithEvents cboSTATUS As AppCore.ComboBoxEx
    Friend WithEvents ss As AppCore.ComboBoxEx
    Friend WithEvents grbEXPERIENCES As System.Windows.Forms.GroupBox
    Friend WithEvents lblEXPERIENCECD As System.Windows.Forms.Label
    Friend WithEvents cboCAREBY As AppCore.ComboBoxEx
    Friend WithEvents lblCAREBY As System.Windows.Forms.Label
    Friend WithEvents txtORGINF As System.Windows.Forms.TextBox
    Friend WithEvents lblORGINF As System.Windows.Forms.Label
    Friend WithEvents lblISBANKING As System.Windows.Forms.Label
    Friend WithEvents cboISBANKING As AppCore.ComboBoxEx
    Friend WithEvents txtMRLOANLIMIT As System.Windows.Forms.TextBox
    Friend WithEvents lblMRLOANLIMIT As System.Windows.Forms.Label
    Friend WithEvents tabLMMAST As System.Windows.Forms.TabPage
    Friend WithEvents btnLMVIEW As System.Windows.Forms.Button
    Friend WithEvents pnLMMAST As System.Windows.Forms.Panel
    Friend WithEvents tabLNMAST As System.Windows.Forms.TabPage
    Friend WithEvents btnLNVIEW As System.Windows.Forms.Button
    Friend WithEvents pnLNMAST As System.Windows.Forms.Panel

    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCFMAST_bk))
        Me.txtCUSTID = New System.Windows.Forms.TextBox
        Me.tabIDENTIFICATION = New System.Windows.Forms.TabPage
        Me.cboCONTRACTCHK = New AppCore.ComboBoxEx
        Me.cboPROVINCE = New AppCore.ComboBoxEx
        Me.lblPROVINCE = New System.Windows.Forms.Label
        Me.lblCONTRACTCHK = New System.Windows.Forms.Label
        Me.dtpOPNDATE = New System.Windows.Forms.TextBox
        Me.lblOPNDATE = New System.Windows.Forms.Label
        Me.txtTRADINGCODE = New System.Windows.Forms.TextBox
        Me.lblMARGINALLOW = New System.Windows.Forms.Label
        Me.lblTRADINGCODE = New System.Windows.Forms.Label
        Me.dtpTRADINGCODEDT = New System.Windows.Forms.DateTimePicker
        Me.lblTRADINGCODEDT = New System.Windows.Forms.Label
        Me.cboRISKLEVEL = New AppCore.ComboBoxEx
        Me.lblRISKLEVEL = New System.Windows.Forms.Label
        Me.lblISBANKING = New System.Windows.Forms.Label
        Me.cboISBANKING = New AppCore.ComboBoxEx
        Me.txtORGINF = New System.Windows.Forms.TextBox
        Me.lblORGINF = New System.Windows.Forms.Label
        Me.lblSTATUS = New System.Windows.Forms.Label
        Me.cboSTATUS = New AppCore.ComboBoxEx
        Me.txtINTERNATION = New System.Windows.Forms.TextBox
        Me.lblOCCUPATION = New System.Windows.Forms.Label
        Me.cboOCCUPATION = New AppCore.ComboBoxEx
        Me.lblEDUCATION = New System.Windows.Forms.Label
        Me.cboEDUCATION = New AppCore.ComboBoxEx
        Me.txtTAXCODE = New System.Windows.Forms.TextBox
        Me.lblTAXCODE = New System.Windows.Forms.Label
        Me.lblINTERNATION = New System.Windows.Forms.Label
        Me.cboMARRIED = New AppCore.ComboBoxEx
        Me.lblMARRIED = New System.Windows.Forms.Label
        Me.txtIDCODE = New System.Windows.Forms.TextBox
        Me.dtpIDDATE = New System.Windows.Forms.DateTimePicker
        Me.dtpDATEOFBIRTH = New System.Windows.Forms.DateTimePicker
        Me.lblIDTYPE = New System.Windows.Forms.Label
        Me.txtSHORTNAME = New System.Windows.Forms.TextBox
        Me.lblSHORTNAME = New System.Windows.Forms.Label
        Me.lblFULLNAME = New System.Windows.Forms.Label
        Me.txtFULLNAME = New System.Windows.Forms.TextBox
        Me.txtMNEMONIC = New System.Windows.Forms.TextBox
        Me.lblMNEMONIC = New System.Windows.Forms.Label
        Me.lblIDDATE = New System.Windows.Forms.Label
        Me.txtIDPLACE = New System.Windows.Forms.TextBox
        Me.lblIDPLACE = New System.Windows.Forms.Label
        Me.txtFAX = New System.Windows.Forms.TextBox
        Me.lblFAX = New System.Windows.Forms.Label
        Me.lblADDRESS = New System.Windows.Forms.Label
        Me.txtADDRESS = New System.Windows.Forms.TextBox
        Me.lblPHONE = New System.Windows.Forms.Label
        Me.txtPHONE = New System.Windows.Forms.TextBox
        Me.cboCOUNTRY = New AppCore.ComboBoxEx
        Me.lblCOUNTRY = New System.Windows.Forms.Label
        Me.lblSEX = New System.Windows.Forms.Label
        Me.cboSEX = New AppCore.ComboBoxEx
        Me.txtDESCRIPTION = New System.Windows.Forms.TextBox
        Me.lblDESCRIPTION = New System.Windows.Forms.Label
        Me.lblDATEOFBIRTH = New System.Windows.Forms.Label
        Me.lblMOBILE = New System.Windows.Forms.Label
        Me.txtMOBILE = New System.Windows.Forms.TextBox
        Me.txtEMAIL = New System.Windows.Forms.TextBox
        Me.lblEMAIL = New System.Windows.Forms.Label
        Me.lblIDCODE = New System.Windows.Forms.Label
        Me.cboMARGINALLOW = New AppCore.ComboBoxEx
        Me.cboIDTYPE = New AppCore.ComboBoxEx
        Me.lblIDEXPIRED = New System.Windows.Forms.Label
        Me.dtpIDEXPIRED = New System.Windows.Forms.DateTimePicker
        Me.lblCUSTTYPE = New System.Windows.Forms.Label
        Me.cboCUSTTYPE = New AppCore.ComboBoxEx
        Me.tabCLASSIFICATION = New System.Windows.Forms.TabPage
        Me.grbEXPERIENCES = New System.Windows.Forms.GroupBox
        Me.lblEXPERIENCECD = New System.Windows.Forms.Label
        Me.chkREALESTATE = New System.Windows.Forms.CheckBox
        Me.chkOTHERS = New System.Windows.Forms.CheckBox
        Me.chkFOREX = New System.Windows.Forms.CheckBox
        Me.chkBOND = New System.Windows.Forms.CheckBox
        Me.chkEQUITIES = New System.Windows.Forms.CheckBox
        Me.txtEXPERIENCECD = New System.Windows.Forms.TextBox
        Me.lblEXPERIENCETYPE = New System.Windows.Forms.Label
        Me.cboEXPERIENCETYPE = New AppCore.ComboBoxEx
        Me.cboFOCUSTYPE = New AppCore.ComboBoxEx
        Me.lblFOCUSTYPE = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lblUsername = New System.Windows.Forms.Label
        Me.txtTLID = New System.Windows.Forms.TextBox
        Me.lblUser = New System.Windows.Forms.Label
        Me.lblCAREBY = New System.Windows.Forms.Label
        Me.cboCAREBY = New AppCore.ComboBoxEx
        Me.lblSTAFF = New System.Windows.Forms.Label
        Me.txtCOMPANYID = New System.Windows.Forms.TextBox
        Me.lblCOMPANYID = New System.Windows.Forms.Label
        Me.cboSTAFF = New AppCore.ComboBoxEx
        Me.lblPOSITION = New System.Windows.Forms.Label
        Me.cboPOSITION = New AppCore.ComboBoxEx
        Me.lblISSUERID = New System.Windows.Forms.Label
        Me.lblSECTOR = New System.Windows.Forms.Label
        Me.cboSECTOR = New AppCore.ComboBoxEx
        Me.lblBUSINESSTYPE = New System.Windows.Forms.Label
        Me.cboBUSINESSTYPE = New AppCore.ComboBoxEx
        Me.cboINVESTRANGE = New AppCore.ComboBoxEx
        Me.lblINVESTRANGE = New System.Windows.Forms.Label
        Me.lblINVESTTYPE = New System.Windows.Forms.Label
        Me.cboINVESTTYPE = New AppCore.ComboBoxEx
        Me.lblGRINVESTOR = New System.Windows.Forms.Label
        Me.cboGRINVESTOR = New AppCore.ComboBoxEx
        Me.cboTIMETOJOIN = New AppCore.ComboBoxEx
        Me.lblTIMETOJOIN = New System.Windows.Forms.Label
        Me.lblINCOMERANGE = New System.Windows.Forms.Label
        Me.cboINCOMERANGE = New AppCore.ComboBoxEx
        Me.lblASSETRANGE = New System.Windows.Forms.Label
        Me.ss = New AppCore.ComboBoxEx
        Me.txtREFNAME = New AppCore.FlexMaskEditBox
        Me.lblREFNAME = New System.Windows.Forms.Label
        Me.cboCLASS = New AppCore.ComboBoxEx
        Me.lblCLASS = New System.Windows.Forms.Label
        Me.txtISSUERID = New System.Windows.Forms.TextBox
        Me.tabSERVICES = New System.Windows.Forms.TabPage
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblMRLOANLIMIT = New System.Windows.Forms.Label
        Me.txtMRLOANLIMIT = New System.Windows.Forms.TextBox
        Me.lblADVANCELIMIT = New System.Windows.Forms.Label
        Me.txtADVANCELIMIT = New System.Windows.Forms.TextBox
        Me.lblMORTAGERATE = New System.Windows.Forms.Label
        Me.txtMORTAGERATE = New System.Windows.Forms.TextBox
        Me.lblDEPOSITLIMIT = New System.Windows.Forms.Label
        Me.lblTRADELIMIT = New System.Windows.Forms.Label
        Me.txtTRADELIMIT = New System.Windows.Forms.TextBox
        Me.lblMARGINLIMIT = New System.Windows.Forms.Label
        Me.txtMARGINLIMIT = New System.Windows.Forms.TextBox
        Me.txtREPOLIMIT = New System.Windows.Forms.TextBox
        Me.lblREPOLIMIT = New System.Windows.Forms.Label
        Me.txtDEPOSITLIMIT = New System.Windows.Forms.TextBox
        Me.lblLANGUAGE = New System.Windows.Forms.Label
        Me.cboLANGUAGE = New AppCore.ComboBoxEx
        Me.lblCUSTODYCD = New System.Windows.Forms.Label
        Me.lblBANKACCTNO = New System.Windows.Forms.Label
        Me.txtBANKACCTNO = New System.Windows.Forms.TextBox
        Me.lblBANKCODE = New System.Windows.Forms.Label
        Me.cboBANKCODE = New AppCore.ComboBoxEx
        Me.txtCUSTODYCD = New System.Windows.Forms.TextBox
        Me.tabCONTACTS = New System.Windows.Forms.TabPage
        Me.pnContacts = New System.Windows.Forms.Panel
        Me.btnCADD = New System.Windows.Forms.Button
        Me.btnCEDIT = New System.Windows.Forms.Button
        Me.btnCDEL = New System.Windows.Forms.Button
        Me.btnCVIEW = New System.Windows.Forms.Button
        Me.tabSIGNATURES = New System.Windows.Forms.TabPage
        Me.lblEXPDATE = New System.Windows.Forms.Label
        Me.dtpEXPDATE = New System.Windows.Forms.DateTimePicker
        Me.lblVALDATE = New System.Windows.Forms.Label
        Me.dtpVALDATE = New System.Windows.Forms.DateTimePicker
        Me.btnNEXT = New System.Windows.Forms.Button
        Me.btnPREVIOUS = New System.Windows.Forms.Button
        Me.pnSignatures = New System.Windows.Forms.Panel
        Me.btnSADD = New System.Windows.Forms.Button
        Me.btnSEDIT = New System.Windows.Forms.Button
        Me.btnSDEL = New System.Windows.Forms.Button
        Me.btnSVIEW = New System.Windows.Forms.Button
        Me.tabCONTRACTS = New System.Windows.Forms.TabPage
        Me.tabRELATION = New System.Windows.Forms.TabControl
        Me.tabRELATION1 = New System.Windows.Forms.TabPage
        Me.pnRelation = New System.Windows.Forms.Panel
        Me.btnRADD = New System.Windows.Forms.Button
        Me.btnREDIT = New System.Windows.Forms.Button
        Me.btnRDEL = New System.Windows.Forms.Button
        Me.btnRVIEW = New System.Windows.Forms.Button
        Me.tabISSUER = New System.Windows.Forms.TabPage
        Me.btnADDISSUER = New System.Windows.Forms.Button
        Me.btnEDITISSUER = New System.Windows.Forms.Button
        Me.btnDELISSUER = New System.Windows.Forms.Button
        Me.btnVIEWISSUER = New System.Windows.Forms.Button
        Me.pnISSUER = New System.Windows.Forms.Panel
        Me.tabLMMAST = New System.Windows.Forms.TabPage
        Me.pnLMMAST = New System.Windows.Forms.Panel
        Me.btnLMVIEW = New System.Windows.Forms.Button
        Me.tabLNMAST = New System.Windows.Forms.TabPage
        Me.pnLNMAST = New System.Windows.Forms.Panel
        Me.btnLNVIEW = New System.Windows.Forms.Button
        Me.tabLNLIMITMAX = New System.Windows.Forms.TabPage
        Me.pnLNLIMITMAX = New System.Windows.Forms.Panel
        Me.lblCUSTID = New System.Windows.Forms.Label
        Me.btnGETCUSTID = New System.Windows.Forms.Button
        Me.txtBRID = New System.Windows.Forms.TextBox
        Me.Panel1.SuspendLayout()
        Me.tabIDENTIFICATION.SuspendLayout()
        Me.tabCLASSIFICATION.SuspendLayout()
        Me.grbEXPERIENCES.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.tabSERVICES.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tabCONTACTS.SuspendLayout()
        Me.tabSIGNATURES.SuspendLayout()
        Me.tabRELATION.SuspendLayout()
        Me.tabRELATION1.SuspendLayout()
        Me.tabISSUER.SuspendLayout()
        Me.tabLMMAST.SuspendLayout()
        Me.tabLNMAST.SuspendLayout()
        Me.tabLNLIMITMAX.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(551, 437)
        Me.btnOK.TabIndex = 58
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(632, 437)
        Me.btnCancel.TabIndex = 59
        '
        'btnApply
        '
        Me.btnApply.Location = New System.Drawing.Point(713, 437)
        Me.btnApply.TabIndex = 60
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(794, 50)
        '
        'btnApprv
        '
        Me.btnApprv.Location = New System.Drawing.Point(470, 437)
        Me.btnApprv.TabIndex = 57
        '
        'cboLink
        '
        Me.cboLink.Location = New System.Drawing.Point(4, 476)
        '
        'txtCUSTID
        '
        Me.txtCUSTID.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCUSTID.ForeColor = System.Drawing.Color.Red
        Me.txtCUSTID.Location = New System.Drawing.Point(190, 55)
        Me.txtCUSTID.MaxLength = 10
        Me.txtCUSTID.Name = "txtCUSTID"
        Me.txtCUSTID.Size = New System.Drawing.Size(152, 21)
        Me.txtCUSTID.TabIndex = 1
        Me.txtCUSTID.Tag = "CUSTID"
        Me.txtCUSTID.Text = "txtCUSTID"
        '
        'tabIDENTIFICATION
        '
        Me.tabIDENTIFICATION.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tabIDENTIFICATION.Controls.Add(Me.cboCONTRACTCHK)
        Me.tabIDENTIFICATION.Controls.Add(Me.cboPROVINCE)
        Me.tabIDENTIFICATION.Controls.Add(Me.lblPROVINCE)
        Me.tabIDENTIFICATION.Controls.Add(Me.lblCONTRACTCHK)
        Me.tabIDENTIFICATION.Controls.Add(Me.dtpOPNDATE)
        Me.tabIDENTIFICATION.Controls.Add(Me.lblOPNDATE)
        Me.tabIDENTIFICATION.Controls.Add(Me.txtTRADINGCODE)
        Me.tabIDENTIFICATION.Controls.Add(Me.lblMARGINALLOW)
        Me.tabIDENTIFICATION.Controls.Add(Me.lblTRADINGCODE)
        Me.tabIDENTIFICATION.Controls.Add(Me.dtpTRADINGCODEDT)
        Me.tabIDENTIFICATION.Controls.Add(Me.lblTRADINGCODEDT)
        Me.tabIDENTIFICATION.Controls.Add(Me.cboRISKLEVEL)
        Me.tabIDENTIFICATION.Controls.Add(Me.lblRISKLEVEL)
        Me.tabIDENTIFICATION.Controls.Add(Me.lblISBANKING)
        Me.tabIDENTIFICATION.Controls.Add(Me.cboISBANKING)
        Me.tabIDENTIFICATION.Controls.Add(Me.txtORGINF)
        Me.tabIDENTIFICATION.Controls.Add(Me.lblORGINF)
        Me.tabIDENTIFICATION.Controls.Add(Me.lblSTATUS)
        Me.tabIDENTIFICATION.Controls.Add(Me.cboSTATUS)
        Me.tabIDENTIFICATION.Controls.Add(Me.txtINTERNATION)
        Me.tabIDENTIFICATION.Controls.Add(Me.lblOCCUPATION)
        Me.tabIDENTIFICATION.Controls.Add(Me.cboOCCUPATION)
        Me.tabIDENTIFICATION.Controls.Add(Me.lblEDUCATION)
        Me.tabIDENTIFICATION.Controls.Add(Me.cboEDUCATION)
        Me.tabIDENTIFICATION.Controls.Add(Me.txtTAXCODE)
        Me.tabIDENTIFICATION.Controls.Add(Me.lblTAXCODE)
        Me.tabIDENTIFICATION.Controls.Add(Me.lblINTERNATION)
        Me.tabIDENTIFICATION.Controls.Add(Me.cboMARRIED)
        Me.tabIDENTIFICATION.Controls.Add(Me.lblMARRIED)
        Me.tabIDENTIFICATION.Controls.Add(Me.txtIDCODE)
        Me.tabIDENTIFICATION.Controls.Add(Me.dtpIDDATE)
        Me.tabIDENTIFICATION.Controls.Add(Me.dtpDATEOFBIRTH)
        Me.tabIDENTIFICATION.Controls.Add(Me.lblIDTYPE)
        Me.tabIDENTIFICATION.Controls.Add(Me.txtSHORTNAME)
        Me.tabIDENTIFICATION.Controls.Add(Me.lblSHORTNAME)
        Me.tabIDENTIFICATION.Controls.Add(Me.lblFULLNAME)
        Me.tabIDENTIFICATION.Controls.Add(Me.txtFULLNAME)
        Me.tabIDENTIFICATION.Controls.Add(Me.txtMNEMONIC)
        Me.tabIDENTIFICATION.Controls.Add(Me.lblMNEMONIC)
        Me.tabIDENTIFICATION.Controls.Add(Me.lblIDDATE)
        Me.tabIDENTIFICATION.Controls.Add(Me.txtIDPLACE)
        Me.tabIDENTIFICATION.Controls.Add(Me.lblIDPLACE)
        Me.tabIDENTIFICATION.Controls.Add(Me.txtFAX)
        Me.tabIDENTIFICATION.Controls.Add(Me.lblFAX)
        Me.tabIDENTIFICATION.Controls.Add(Me.lblADDRESS)
        Me.tabIDENTIFICATION.Controls.Add(Me.txtADDRESS)
        Me.tabIDENTIFICATION.Controls.Add(Me.lblPHONE)
        Me.tabIDENTIFICATION.Controls.Add(Me.txtPHONE)
        Me.tabIDENTIFICATION.Controls.Add(Me.cboCOUNTRY)
        Me.tabIDENTIFICATION.Controls.Add(Me.lblCOUNTRY)
        Me.tabIDENTIFICATION.Controls.Add(Me.lblSEX)
        Me.tabIDENTIFICATION.Controls.Add(Me.cboSEX)
        Me.tabIDENTIFICATION.Controls.Add(Me.txtDESCRIPTION)
        Me.tabIDENTIFICATION.Controls.Add(Me.lblDESCRIPTION)
        Me.tabIDENTIFICATION.Controls.Add(Me.lblDATEOFBIRTH)
        Me.tabIDENTIFICATION.Controls.Add(Me.lblMOBILE)
        Me.tabIDENTIFICATION.Controls.Add(Me.txtMOBILE)
        Me.tabIDENTIFICATION.Controls.Add(Me.txtEMAIL)
        Me.tabIDENTIFICATION.Controls.Add(Me.lblEMAIL)
        Me.tabIDENTIFICATION.Controls.Add(Me.lblIDCODE)
        Me.tabIDENTIFICATION.Controls.Add(Me.cboMARGINALLOW)
        Me.tabIDENTIFICATION.Controls.Add(Me.cboIDTYPE)
        Me.tabIDENTIFICATION.Controls.Add(Me.lblIDEXPIRED)
        Me.tabIDENTIFICATION.Controls.Add(Me.dtpIDEXPIRED)
        Me.tabIDENTIFICATION.Controls.Add(Me.lblCUSTTYPE)
        Me.tabIDENTIFICATION.Controls.Add(Me.cboCUSTTYPE)
        Me.tabIDENTIFICATION.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabIDENTIFICATION.Location = New System.Drawing.Point(4, 22)
        Me.tabIDENTIFICATION.Name = "tabIDENTIFICATION"
        Me.tabIDENTIFICATION.Size = New System.Drawing.Size(784, 320)
        Me.tabIDENTIFICATION.TabIndex = 0
        Me.tabIDENTIFICATION.Tag = "IDENTIFICATION"
        Me.tabIDENTIFICATION.Text = "tabIDENTIFICATION"
        '
        'cboCONTRACTCHK
        '
        Me.cboCONTRACTCHK.DisplayMember = "DISPLAY"
        Me.cboCONTRACTCHK.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCONTRACTCHK.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCONTRACTCHK.ItemHeight = 13
        Me.cboCONTRACTCHK.Location = New System.Drawing.Point(376, 294)
        Me.cboCONTRACTCHK.Name = "cboCONTRACTCHK"
        Me.cboCONTRACTCHK.Size = New System.Drawing.Size(136, 21)
        Me.cboCONTRACTCHK.TabIndex = 62
        Me.cboCONTRACTCHK.Tag = "CONTRACTCHK"
        Me.cboCONTRACTCHK.ValueMember = "VALUE"
        '
        'cboPROVINCE
        '
        Me.cboPROVINCE.DisplayMember = "DISPLAY"
        Me.cboPROVINCE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPROVINCE.ItemHeight = 13
        Me.cboPROVINCE.Location = New System.Drawing.Point(674, 177)
        Me.cboPROVINCE.MaxLength = 3
        Me.cboPROVINCE.Name = "cboPROVINCE"
        Me.cboPROVINCE.Size = New System.Drawing.Size(102, 21)
        Me.cboPROVINCE.TabIndex = 37
        Me.cboPROVINCE.Tag = "PROVINCE"
        Me.cboPROVINCE.ValueMember = "VALUE"
        '
        'lblPROVINCE
        '
        Me.lblPROVINCE.ForeColor = System.Drawing.Color.Red
        Me.lblPROVINCE.Location = New System.Drawing.Point(616, 178)
        Me.lblPROVINCE.Name = "lblPROVINCE"
        Me.lblPROVINCE.Size = New System.Drawing.Size(60, 21)
        Me.lblPROVINCE.TabIndex = 36
        Me.lblPROVINCE.Tag = "PROVINCE"
        Me.lblPROVINCE.Text = "lblPROVINCE"
        Me.lblPROVINCE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCONTRACTCHK
        '
        Me.lblCONTRACTCHK.AutoSize = True
        Me.lblCONTRACTCHK.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCONTRACTCHK.Location = New System.Drawing.Point(264, 297)
        Me.lblCONTRACTCHK.Name = "lblCONTRACTCHK"
        Me.lblCONTRACTCHK.Size = New System.Drawing.Size(92, 13)
        Me.lblCONTRACTCHK.TabIndex = 62
        Me.lblCONTRACTCHK.Tag = "CONTRACTCHK"
        Me.lblCONTRACTCHK.Text = "lblCONTRACTCHK"
        Me.lblCONTRACTCHK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpOPNDATE
        '
        Me.dtpOPNDATE.Location = New System.Drawing.Point(640, 294)
        Me.dtpOPNDATE.Name = "dtpOPNDATE"
        Me.dtpOPNDATE.Size = New System.Drawing.Size(136, 21)
        Me.dtpOPNDATE.TabIndex = 63
        Me.dtpOPNDATE.Tag = "OPNDATE"
        '
        'lblOPNDATE
        '
        Me.lblOPNDATE.Location = New System.Drawing.Point(536, 294)
        Me.lblOPNDATE.Name = "lblOPNDATE"
        Me.lblOPNDATE.Size = New System.Drawing.Size(100, 21)
        Me.lblOPNDATE.TabIndex = 59
        Me.lblOPNDATE.Tag = "OPNDATE"
        Me.lblOPNDATE.Text = "lblOPNDATE"
        Me.lblOPNDATE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTRADINGCODE
        '
        Me.txtTRADINGCODE.Location = New System.Drawing.Point(112, 263)
        Me.txtTRADINGCODE.MaxLength = 100
        Me.txtTRADINGCODE.Name = "txtTRADINGCODE"
        Me.txtTRADINGCODE.Size = New System.Drawing.Size(136, 21)
        Me.txtTRADINGCODE.TabIndex = 52
        Me.txtTRADINGCODE.Tag = "TRADINGCODE"
        Me.txtTRADINGCODE.Text = "txtTRADINGCODE"
        '
        'lblMARGINALLOW
        '
        Me.lblMARGINALLOW.Location = New System.Drawing.Point(8, 289)
        Me.lblMARGINALLOW.Name = "lblMARGINALLOW"
        Me.lblMARGINALLOW.Size = New System.Drawing.Size(104, 21)
        Me.lblMARGINALLOW.TabIndex = 58
        Me.lblMARGINALLOW.Tag = "MARGINALLOW"
        Me.lblMARGINALLOW.Text = "lblMARGINALLOW"
        Me.lblMARGINALLOW.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTRADINGCODE
        '
        Me.lblTRADINGCODE.Location = New System.Drawing.Point(8, 263)
        Me.lblTRADINGCODE.Name = "lblTRADINGCODE"
        Me.lblTRADINGCODE.Size = New System.Drawing.Size(104, 21)
        Me.lblTRADINGCODE.TabIndex = 58
        Me.lblTRADINGCODE.Tag = "TRADINGCODE"
        Me.lblTRADINGCODE.Text = "lblTRADINGCODE"
        Me.lblTRADINGCODE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpTRADINGCODEDT
        '
        Me.dtpTRADINGCODEDT.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTRADINGCODEDT.Location = New System.Drawing.Point(376, 263)
        Me.dtpTRADINGCODEDT.Name = "dtpTRADINGCODEDT"
        Me.dtpTRADINGCODEDT.Size = New System.Drawing.Size(136, 21)
        Me.dtpTRADINGCODEDT.TabIndex = 53
        Me.dtpTRADINGCODEDT.Tag = "TRADINGCODEDT"
        Me.dtpTRADINGCODEDT.Value = New Date(2006, 8, 28, 13, 36, 3, 671)
        '
        'lblTRADINGCODEDT
        '
        Me.lblTRADINGCODEDT.Location = New System.Drawing.Point(264, 263)
        Me.lblTRADINGCODEDT.Name = "lblTRADINGCODEDT"
        Me.lblTRADINGCODEDT.Size = New System.Drawing.Size(100, 21)
        Me.lblTRADINGCODEDT.TabIndex = 56
        Me.lblTRADINGCODEDT.Tag = "TRADINGCODEDT"
        Me.lblTRADINGCODEDT.Text = "lblTRADINGCODEDT"
        Me.lblTRADINGCODEDT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboRISKLEVEL
        '
        Me.cboRISKLEVEL.DisplayMember = "DISPLAY"
        Me.cboRISKLEVEL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRISKLEVEL.ItemHeight = 13
        Me.cboRISKLEVEL.Location = New System.Drawing.Point(640, 265)
        Me.cboRISKLEVEL.MaxLength = 3
        Me.cboRISKLEVEL.Name = "cboRISKLEVEL"
        Me.cboRISKLEVEL.Size = New System.Drawing.Size(136, 21)
        Me.cboRISKLEVEL.TabIndex = 54
        Me.cboRISKLEVEL.Tag = "RISKLEVEL"
        Me.cboRISKLEVEL.ValueMember = "VALUE"
        '
        'lblRISKLEVEL
        '
        Me.lblRISKLEVEL.Location = New System.Drawing.Point(536, 265)
        Me.lblRISKLEVEL.Name = "lblRISKLEVEL"
        Me.lblRISKLEVEL.Size = New System.Drawing.Size(100, 21)
        Me.lblRISKLEVEL.TabIndex = 52
        Me.lblRISKLEVEL.Tag = "RISKLEVEL"
        Me.lblRISKLEVEL.Text = "lblRISKLEVEL"
        Me.lblRISKLEVEL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblISBANKING
        '
        Me.lblISBANKING.Location = New System.Drawing.Point(536, 234)
        Me.lblISBANKING.Name = "lblISBANKING"
        Me.lblISBANKING.Size = New System.Drawing.Size(80, 21)
        Me.lblISBANKING.TabIndex = 48
        Me.lblISBANKING.Tag = "ISBANKING"
        Me.lblISBANKING.Text = "lblISBANKING"
        Me.lblISBANKING.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboISBANKING
        '
        Me.cboISBANKING.DisplayMember = "DISPLAY"
        Me.cboISBANKING.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboISBANKING.ItemHeight = 13
        Me.cboISBANKING.Location = New System.Drawing.Point(640, 235)
        Me.cboISBANKING.MaxLength = 3
        Me.cboISBANKING.Name = "cboISBANKING"
        Me.cboISBANKING.Size = New System.Drawing.Size(136, 21)
        Me.cboISBANKING.TabIndex = 49
        Me.cboISBANKING.Tag = "ISBANKING"
        Me.cboISBANKING.ValueMember = "VALUE"
        '
        'txtORGINF
        '
        Me.txtORGINF.Location = New System.Drawing.Point(376, 263)
        Me.txtORGINF.MaxLength = 250
        Me.txtORGINF.Name = "txtORGINF"
        Me.txtORGINF.Size = New System.Drawing.Size(136, 21)
        Me.txtORGINF.TabIndex = 51
        Me.txtORGINF.Tag = "ORGINF"
        Me.txtORGINF.Text = "txtORGINF"
        '
        'lblORGINF
        '
        Me.lblORGINF.Location = New System.Drawing.Point(264, 261)
        Me.lblORGINF.Name = "lblORGINF"
        Me.lblORGINF.Size = New System.Drawing.Size(96, 21)
        Me.lblORGINF.TabIndex = 50
        Me.lblORGINF.Tag = "ORGINF"
        Me.lblORGINF.Text = "lblORGINF"
        Me.lblORGINF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSTATUS
        '
        Me.lblSTATUS.Location = New System.Drawing.Point(616, 8)
        Me.lblSTATUS.Name = "lblSTATUS"
        Me.lblSTATUS.Size = New System.Drawing.Size(80, 21)
        Me.lblSTATUS.TabIndex = 4
        Me.lblSTATUS.Tag = "STATUS"
        Me.lblSTATUS.Text = "lblSTATUS"
        Me.lblSTATUS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSTATUS
        '
        Me.cboSTATUS.DisplayMember = "DISPLAY"
        Me.cboSTATUS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSTATUS.ItemHeight = 13
        Me.cboSTATUS.Location = New System.Drawing.Point(696, 8)
        Me.cboSTATUS.MaxLength = 3
        Me.cboSTATUS.Name = "cboSTATUS"
        Me.cboSTATUS.Size = New System.Drawing.Size(80, 21)
        Me.cboSTATUS.TabIndex = 5
        Me.cboSTATUS.Tag = "STATUS"
        Me.cboSTATUS.ValueMember = "VALUE"
        '
        'txtINTERNATION
        '
        Me.txtINTERNATION.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtINTERNATION.Location = New System.Drawing.Point(112, 38)
        Me.txtINTERNATION.Name = "txtINTERNATION"
        Me.txtINTERNATION.Size = New System.Drawing.Size(400, 21)
        Me.txtINTERNATION.TabIndex = 7
        Me.txtINTERNATION.Tag = "INTERNATION"
        Me.txtINTERNATION.Text = "txtINTERNATION"
        '
        'lblOCCUPATION
        '
        Me.lblOCCUPATION.Location = New System.Drawing.Point(536, 152)
        Me.lblOCCUPATION.Name = "lblOCCUPATION"
        Me.lblOCCUPATION.Size = New System.Drawing.Size(100, 21)
        Me.lblOCCUPATION.TabIndex = 32
        Me.lblOCCUPATION.Tag = "OCCUPATION"
        Me.lblOCCUPATION.Text = "lblOCCUPATION"
        Me.lblOCCUPATION.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboOCCUPATION
        '
        Me.cboOCCUPATION.DisplayMember = "DISPLAY"
        Me.cboOCCUPATION.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOCCUPATION.Location = New System.Drawing.Point(640, 152)
        Me.cboOCCUPATION.Name = "cboOCCUPATION"
        Me.cboOCCUPATION.Size = New System.Drawing.Size(136, 21)
        Me.cboOCCUPATION.TabIndex = 33
        Me.cboOCCUPATION.Tag = "OCCUPATION"
        Me.cboOCCUPATION.ValueMember = "VALUE"
        '
        'lblEDUCATION
        '
        Me.lblEDUCATION.Location = New System.Drawing.Point(264, 150)
        Me.lblEDUCATION.Name = "lblEDUCATION"
        Me.lblEDUCATION.Size = New System.Drawing.Size(100, 21)
        Me.lblEDUCATION.TabIndex = 30
        Me.lblEDUCATION.Tag = "EDUCATION"
        Me.lblEDUCATION.Text = "lblEDUCATION"
        Me.lblEDUCATION.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboEDUCATION
        '
        Me.cboEDUCATION.DisplayMember = "DISPLAY"
        Me.cboEDUCATION.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEDUCATION.Location = New System.Drawing.Point(376, 150)
        Me.cboEDUCATION.Name = "cboEDUCATION"
        Me.cboEDUCATION.Size = New System.Drawing.Size(136, 21)
        Me.cboEDUCATION.TabIndex = 31
        Me.cboEDUCATION.Tag = "EDUCATION"
        Me.cboEDUCATION.ValueMember = "VALUE"
        '
        'txtTAXCODE
        '
        Me.txtTAXCODE.Location = New System.Drawing.Point(640, 120)
        Me.txtTAXCODE.Name = "txtTAXCODE"
        Me.txtTAXCODE.Size = New System.Drawing.Size(136, 21)
        Me.txtTAXCODE.TabIndex = 27
        Me.txtTAXCODE.Tag = "TAXCODE"
        Me.txtTAXCODE.Text = "txtTAXCODE"
        '
        'lblTAXCODE
        '
        Me.lblTAXCODE.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTAXCODE.Location = New System.Drawing.Point(536, 120)
        Me.lblTAXCODE.Name = "lblTAXCODE"
        Me.lblTAXCODE.Size = New System.Drawing.Size(100, 21)
        Me.lblTAXCODE.TabIndex = 26
        Me.lblTAXCODE.Tag = "TAXCODE"
        Me.lblTAXCODE.Text = "lblTAXCODE"
        Me.lblTAXCODE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblINTERNATION
        '
        Me.lblINTERNATION.Location = New System.Drawing.Point(8, 38)
        Me.lblINTERNATION.Name = "lblINTERNATION"
        Me.lblINTERNATION.Size = New System.Drawing.Size(100, 21)
        Me.lblINTERNATION.TabIndex = 6
        Me.lblINTERNATION.Tag = "INTERNATION"
        Me.lblINTERNATION.Text = "lblINTERNATIONAL"
        Me.lblINTERNATION.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboMARRIED
        '
        Me.cboMARRIED.DisplayMember = "DISPLAY"
        Me.cboMARRIED.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMARRIED.ItemHeight = 13
        Me.cboMARRIED.Location = New System.Drawing.Point(112, 150)
        Me.cboMARRIED.MaxLength = 3
        Me.cboMARRIED.Name = "cboMARRIED"
        Me.cboMARRIED.Size = New System.Drawing.Size(136, 21)
        Me.cboMARRIED.TabIndex = 29
        Me.cboMARRIED.Tag = "MARRIED"
        Me.cboMARRIED.ValueMember = "VALUE"
        '
        'lblMARRIED
        '
        Me.lblMARRIED.Location = New System.Drawing.Point(8, 150)
        Me.lblMARRIED.Name = "lblMARRIED"
        Me.lblMARRIED.Size = New System.Drawing.Size(100, 21)
        Me.lblMARRIED.TabIndex = 28
        Me.lblMARRIED.Tag = "MARRIED"
        Me.lblMARRIED.Text = "lblMARRIED"
        Me.lblMARRIED.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtIDCODE
        '
        Me.txtIDCODE.Location = New System.Drawing.Point(376, 94)
        Me.txtIDCODE.MaxLength = 30
        Me.txtIDCODE.Name = "txtIDCODE"
        Me.txtIDCODE.Size = New System.Drawing.Size(136, 21)
        Me.txtIDCODE.TabIndex = 19
        Me.txtIDCODE.Tag = "IDCODE"
        Me.txtIDCODE.Text = "txtIDCODE"
        '
        'dtpIDDATE
        '
        Me.dtpIDDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpIDDATE.Location = New System.Drawing.Point(640, 94)
        Me.dtpIDDATE.Name = "dtpIDDATE"
        Me.dtpIDDATE.Size = New System.Drawing.Size(136, 21)
        Me.dtpIDDATE.TabIndex = 21
        Me.dtpIDDATE.Tag = "IDDATE"
        Me.dtpIDDATE.Value = New Date(2006, 8, 28, 13, 36, 3, 671)
        '
        'dtpDATEOFBIRTH
        '
        Me.dtpDATEOFBIRTH.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDATEOFBIRTH.Location = New System.Drawing.Point(376, 66)
        Me.dtpDATEOFBIRTH.Name = "dtpDATEOFBIRTH"
        Me.dtpDATEOFBIRTH.Size = New System.Drawing.Size(136, 21)
        Me.dtpDATEOFBIRTH.TabIndex = 13
        Me.dtpDATEOFBIRTH.Tag = "DATEOFBIRTH"
        Me.dtpDATEOFBIRTH.Value = New Date(2006, 8, 28, 13, 36, 3, 687)
        '
        'lblIDTYPE
        '
        Me.lblIDTYPE.Location = New System.Drawing.Point(8, 94)
        Me.lblIDTYPE.Name = "lblIDTYPE"
        Me.lblIDTYPE.Size = New System.Drawing.Size(104, 21)
        Me.lblIDTYPE.TabIndex = 16
        Me.lblIDTYPE.Tag = "IDTYPE"
        Me.lblIDTYPE.Text = "lblIDTYPE"
        Me.lblIDTYPE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSHORTNAME
        '
        Me.txtSHORTNAME.Location = New System.Drawing.Point(112, 10)
        Me.txtSHORTNAME.MaxLength = 100
        Me.txtSHORTNAME.Name = "txtSHORTNAME"
        Me.txtSHORTNAME.Size = New System.Drawing.Size(136, 21)
        Me.txtSHORTNAME.TabIndex = 1
        Me.txtSHORTNAME.Tag = "SHORTNAME"
        Me.txtSHORTNAME.Text = "txtSHORTNAME"
        '
        'lblSHORTNAME
        '
        Me.lblSHORTNAME.Location = New System.Drawing.Point(8, 10)
        Me.lblSHORTNAME.Name = "lblSHORTNAME"
        Me.lblSHORTNAME.Size = New System.Drawing.Size(100, 21)
        Me.lblSHORTNAME.TabIndex = 0
        Me.lblSHORTNAME.Tag = "SHORTNAME"
        Me.lblSHORTNAME.Text = "lblSHORTNAME"
        Me.lblSHORTNAME.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFULLNAME
        '
        Me.lblFULLNAME.Location = New System.Drawing.Point(264, 10)
        Me.lblFULLNAME.Name = "lblFULLNAME"
        Me.lblFULLNAME.Size = New System.Drawing.Size(100, 21)
        Me.lblFULLNAME.TabIndex = 2
        Me.lblFULLNAME.Tag = "FULLNAME"
        Me.lblFULLNAME.Text = "lblFULLNAME"
        Me.lblFULLNAME.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFULLNAME
        '
        Me.txtFULLNAME.Location = New System.Drawing.Point(376, 10)
        Me.txtFULLNAME.MaxLength = 255
        Me.txtFULLNAME.Name = "txtFULLNAME"
        Me.txtFULLNAME.Size = New System.Drawing.Size(208, 21)
        Me.txtFULLNAME.TabIndex = 3
        Me.txtFULLNAME.Tag = "FULLNAME"
        Me.txtFULLNAME.Text = "txtFULLNAME"
        '
        'txtMNEMONIC
        '
        Me.txtMNEMONIC.Location = New System.Drawing.Point(112, 66)
        Me.txtMNEMONIC.MaxLength = 2
        Me.txtMNEMONIC.Name = "txtMNEMONIC"
        Me.txtMNEMONIC.Size = New System.Drawing.Size(136, 21)
        Me.txtMNEMONIC.TabIndex = 11
        Me.txtMNEMONIC.Tag = "MNEMONIC"
        Me.txtMNEMONIC.Text = "txtMNEMONIC"
        '
        'lblMNEMONIC
        '
        Me.lblMNEMONIC.Location = New System.Drawing.Point(8, 66)
        Me.lblMNEMONIC.Name = "lblMNEMONIC"
        Me.lblMNEMONIC.Size = New System.Drawing.Size(100, 21)
        Me.lblMNEMONIC.TabIndex = 10
        Me.lblMNEMONIC.Tag = "MNEMONIC"
        Me.lblMNEMONIC.Text = "lblMNEMONIC"
        Me.lblMNEMONIC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIDDATE
        '
        Me.lblIDDATE.Location = New System.Drawing.Point(536, 94)
        Me.lblIDDATE.Name = "lblIDDATE"
        Me.lblIDDATE.Size = New System.Drawing.Size(100, 21)
        Me.lblIDDATE.TabIndex = 20
        Me.lblIDDATE.Tag = "IDDATE"
        Me.lblIDDATE.Text = "lblIDDATE"
        Me.lblIDDATE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtIDPLACE
        '
        Me.txtIDPLACE.Location = New System.Drawing.Point(376, 122)
        Me.txtIDPLACE.MaxLength = 100
        Me.txtIDPLACE.Name = "txtIDPLACE"
        Me.txtIDPLACE.Size = New System.Drawing.Size(136, 21)
        Me.txtIDPLACE.TabIndex = 25
        Me.txtIDPLACE.Tag = "IDPLACE"
        Me.txtIDPLACE.Text = "txtIDPLACE"
        '
        'lblIDPLACE
        '
        Me.lblIDPLACE.Location = New System.Drawing.Point(264, 122)
        Me.lblIDPLACE.Name = "lblIDPLACE"
        Me.lblIDPLACE.Size = New System.Drawing.Size(104, 21)
        Me.lblIDPLACE.TabIndex = 24
        Me.lblIDPLACE.Tag = "IDPLACE"
        Me.lblIDPLACE.Text = "lblIDPLACE"
        Me.lblIDPLACE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFAX
        '
        Me.txtFAX.Location = New System.Drawing.Point(376, 206)
        Me.txtFAX.MaxLength = 20
        Me.txtFAX.Name = "txtFAX"
        Me.txtFAX.Size = New System.Drawing.Size(136, 21)
        Me.txtFAX.TabIndex = 41
        Me.txtFAX.Tag = "FAX"
        Me.txtFAX.Text = "txtFAX"
        '
        'lblFAX
        '
        Me.lblFAX.Location = New System.Drawing.Point(264, 206)
        Me.lblFAX.Name = "lblFAX"
        Me.lblFAX.Size = New System.Drawing.Size(100, 21)
        Me.lblFAX.TabIndex = 40
        Me.lblFAX.Tag = "FAX"
        Me.lblFAX.Text = "lblFAX"
        Me.lblFAX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblADDRESS
        '
        Me.lblADDRESS.Location = New System.Drawing.Point(8, 176)
        Me.lblADDRESS.Name = "lblADDRESS"
        Me.lblADDRESS.Size = New System.Drawing.Size(100, 21)
        Me.lblADDRESS.TabIndex = 34
        Me.lblADDRESS.Tag = "ADDRESS"
        Me.lblADDRESS.Text = "lblADDRESS"
        Me.lblADDRESS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtADDRESS
        '
        Me.txtADDRESS.Location = New System.Drawing.Point(112, 178)
        Me.txtADDRESS.MaxLength = 5
        Me.txtADDRESS.Name = "txtADDRESS"
        Me.txtADDRESS.Size = New System.Drawing.Size(498, 21)
        Me.txtADDRESS.TabIndex = 35
        Me.txtADDRESS.Tag = "ADDRESS"
        Me.txtADDRESS.Text = "txtADDRESS"
        '
        'lblPHONE
        '
        Me.lblPHONE.Location = New System.Drawing.Point(8, 206)
        Me.lblPHONE.Name = "lblPHONE"
        Me.lblPHONE.Size = New System.Drawing.Size(100, 21)
        Me.lblPHONE.TabIndex = 38
        Me.lblPHONE.Tag = "PHONE"
        Me.lblPHONE.Text = "lblPHONE"
        Me.lblPHONE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPHONE
        '
        Me.txtPHONE.Location = New System.Drawing.Point(112, 206)
        Me.txtPHONE.MaxLength = 20
        Me.txtPHONE.Name = "txtPHONE"
        Me.txtPHONE.Size = New System.Drawing.Size(136, 21)
        Me.txtPHONE.TabIndex = 39
        Me.txtPHONE.Tag = "PHONE"
        Me.txtPHONE.Text = "txtPHONE"
        '
        'cboCOUNTRY
        '
        Me.cboCOUNTRY.DisplayMember = "DISPLAY"
        Me.cboCOUNTRY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCOUNTRY.ItemHeight = 13
        Me.cboCOUNTRY.Location = New System.Drawing.Point(376, 234)
        Me.cboCOUNTRY.MaxLength = 3
        Me.cboCOUNTRY.Name = "cboCOUNTRY"
        Me.cboCOUNTRY.Size = New System.Drawing.Size(136, 21)
        Me.cboCOUNTRY.TabIndex = 47
        Me.cboCOUNTRY.Tag = "COUNTRY"
        Me.cboCOUNTRY.ValueMember = "VALUE"
        '
        'lblCOUNTRY
        '
        Me.lblCOUNTRY.Location = New System.Drawing.Point(264, 232)
        Me.lblCOUNTRY.Name = "lblCOUNTRY"
        Me.lblCOUNTRY.Size = New System.Drawing.Size(100, 21)
        Me.lblCOUNTRY.TabIndex = 46
        Me.lblCOUNTRY.Tag = "COUNTRY"
        Me.lblCOUNTRY.Text = "lblCOUNTRY"
        Me.lblCOUNTRY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSEX
        '

        Me.lblSEX.Location = New System.Drawing.Point(536, 66)
        Me.lblSEX.Name = "lblSEX"
        Me.lblSEX.Size = New System.Drawing.Size(100, 21)
        Me.lblSEX.TabIndex = 14
        Me.lblSEX.Tag = "SEX"
        Me.lblSEX.Text = "lblSEX"
        Me.lblSEX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSEX
        '
        Me.cboSEX.DisplayMember = "DISPLAY"
        Me.cboSEX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSEX.ItemHeight = 13
        Me.cboSEX.Location = New System.Drawing.Point(640, 66)
        Me.cboSEX.MaxLength = 3
        Me.cboSEX.Name = "cboSEX"
        Me.cboSEX.Size = New System.Drawing.Size(136, 21)
        Me.cboSEX.TabIndex = 15
        Me.cboSEX.Tag = "SEX"
        Me.cboSEX.ValueMember = "VALUE"
        '
        'txtDESCRIPTION
        '
        Me.txtDESCRIPTION.Location = New System.Drawing.Point(332, 322)
        Me.txtDESCRIPTION.MaxLength = 250
        Me.txtDESCRIPTION.Name = "txtDESCRIPTION"
        Me.txtDESCRIPTION.Size = New System.Drawing.Size(400, 21)
        Me.txtDESCRIPTION.TabIndex = 55
        Me.txtDESCRIPTION.Tag = "DESCRIPTION"
        Me.txtDESCRIPTION.Text = "txtDESCRIPTION"
        '
        'lblDESCRIPTION
        '
        Me.lblDESCRIPTION.Location = New System.Drawing.Point(220, 322)
        Me.lblDESCRIPTION.Name = "lblDESCRIPTION"
        Me.lblDESCRIPTION.Size = New System.Drawing.Size(97, 21)
        Me.lblDESCRIPTION.TabIndex = 54
        Me.lblDESCRIPTION.Tag = "DESCRIPTION"
        Me.lblDESCRIPTION.Text = "lblDESCRIPTION"
        Me.lblDESCRIPTION.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDATEOFBIRTH
        '
        Me.lblDATEOFBIRTH.Location = New System.Drawing.Point(264, 66)
        Me.lblDATEOFBIRTH.Name = "lblDATEOFBIRTH"
        Me.lblDATEOFBIRTH.Size = New System.Drawing.Size(104, 30)
        Me.lblDATEOFBIRTH.TabIndex = 12
        Me.lblDATEOFBIRTH.Tag = "DATEOFBIRTH"
        Me.lblDATEOFBIRTH.Text = "lblDATEOFBIRTH"
        Me.lblDATEOFBIRTH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMOBILE
        '
        Me.lblMOBILE.Location = New System.Drawing.Point(536, 206)
        Me.lblMOBILE.Name = "lblMOBILE"
        Me.lblMOBILE.Size = New System.Drawing.Size(100, 21)
        Me.lblMOBILE.TabIndex = 42
        Me.lblMOBILE.Tag = "MOBILE"
        Me.lblMOBILE.Text = "lblMOBILE"
        Me.lblMOBILE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMOBILE
        '
        Me.txtMOBILE.Location = New System.Drawing.Point(640, 206)
        Me.txtMOBILE.MaxLength = 20
        Me.txtMOBILE.Name = "txtMOBILE"
        Me.txtMOBILE.Size = New System.Drawing.Size(136, 21)
        Me.txtMOBILE.TabIndex = 43
        Me.txtMOBILE.Tag = "MOBILE"
        Me.txtMOBILE.Text = "txtMOBILE"
        '
        'txtEMAIL
        '
        Me.txtEMAIL.Location = New System.Drawing.Point(112, 234)
        Me.txtEMAIL.MaxLength = 50
        Me.txtEMAIL.Name = "txtEMAIL"
        Me.txtEMAIL.Size = New System.Drawing.Size(136, 21)
        Me.txtEMAIL.TabIndex = 45
        Me.txtEMAIL.Tag = "EMAIL"
        Me.txtEMAIL.Text = "txtEMAIL"
        '
        'lblEMAIL
        '
        Me.lblEMAIL.Location = New System.Drawing.Point(8, 232)
        Me.lblEMAIL.Name = "lblEMAIL"
        Me.lblEMAIL.Size = New System.Drawing.Size(96, 21)
        Me.lblEMAIL.TabIndex = 44
        Me.lblEMAIL.Tag = "EMAIL"
        Me.lblEMAIL.Text = "lblEMAIL"
        Me.lblEMAIL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIDCODE
        '
        Me.lblIDCODE.Location = New System.Drawing.Point(264, 94)
        Me.lblIDCODE.Name = "lblIDCODE"
        Me.lblIDCODE.Size = New System.Drawing.Size(110, 24)
        Me.lblIDCODE.TabIndex = 18
        Me.lblIDCODE.Tag = "IDCODE"
        Me.lblIDCODE.Text = "lblIDCODE"
        Me.lblIDCODE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboMARGINALLOW
        '
        Me.cboMARGINALLOW.DisplayMember = "DISPLAY"
        Me.cboMARGINALLOW.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMARGINALLOW.ItemHeight = 13
        Me.cboMARGINALLOW.Location = New System.Drawing.Point(112, 290)
        Me.cboMARGINALLOW.MaxLength = 3
        Me.cboMARGINALLOW.Name = "cboMARGINALLOW"
        Me.cboMARGINALLOW.Size = New System.Drawing.Size(136, 21)
        Me.cboMARGINALLOW.TabIndex = 61
        Me.cboMARGINALLOW.Tag = "MARGINALLOW"
        Me.cboMARGINALLOW.ValueMember = "VALUE"
        '
        'cboIDTYPE
        '
        Me.cboIDTYPE.DisplayMember = "DISPLAY"
        Me.cboIDTYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboIDTYPE.ItemHeight = 13
        Me.cboIDTYPE.Location = New System.Drawing.Point(112, 94)
        Me.cboIDTYPE.MaxLength = 3
        Me.cboIDTYPE.Name = "cboIDTYPE"
        Me.cboIDTYPE.Size = New System.Drawing.Size(136, 21)
        Me.cboIDTYPE.TabIndex = 17
        Me.cboIDTYPE.Tag = "IDTYPE"
        Me.cboIDTYPE.ValueMember = "VALUE"
        '
        'lblIDEXPIRED
        '
        Me.lblIDEXPIRED.Location = New System.Drawing.Point(8, 122)
        Me.lblIDEXPIRED.Name = "lblIDEXPIRED"
        Me.lblIDEXPIRED.Size = New System.Drawing.Size(100, 21)
        Me.lblIDEXPIRED.TabIndex = 22
        Me.lblIDEXPIRED.Tag = "IDEXPIRED"
        Me.lblIDEXPIRED.Text = "lblIDEXPIRED"
        Me.lblIDEXPIRED.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpIDEXPIRED
        '
        Me.dtpIDEXPIRED.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpIDEXPIRED.Location = New System.Drawing.Point(112, 122)
        Me.dtpIDEXPIRED.Name = "dtpIDEXPIRED"
        Me.dtpIDEXPIRED.Size = New System.Drawing.Size(136, 21)
        Me.dtpIDEXPIRED.TabIndex = 23
        Me.dtpIDEXPIRED.Tag = "IDEXPIRED"
        Me.dtpIDEXPIRED.Value = New Date(2006, 8, 28, 13, 36, 3, 671)
        '
        'lblCUSTTYPE
        '
        Me.lblCUSTTYPE.Location = New System.Drawing.Point(536, 40)
        Me.lblCUSTTYPE.Name = "lblCUSTTYPE"
        Me.lblCUSTTYPE.Size = New System.Drawing.Size(100, 21)
        Me.lblCUSTTYPE.TabIndex = 8
        Me.lblCUSTTYPE.Tag = "CUSTTYPE"
        Me.lblCUSTTYPE.Text = "lblCUSTTYPE"
        Me.lblCUSTTYPE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCUSTTYPE
        '
        Me.cboCUSTTYPE.DisplayMember = "DISPLAY"
        Me.cboCUSTTYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCUSTTYPE.ItemHeight = 13
        Me.cboCUSTTYPE.Location = New System.Drawing.Point(640, 40)
        Me.cboCUSTTYPE.MaxLength = 3
        Me.cboCUSTTYPE.Name = "cboCUSTTYPE"
        Me.cboCUSTTYPE.Size = New System.Drawing.Size(136, 21)
        Me.cboCUSTTYPE.TabIndex = 9
        Me.cboCUSTTYPE.Tag = "CUSTTYPE"
        Me.cboCUSTTYPE.ValueMember = "VALUE"
        '
        'tabCLASSIFICATION
        '
        Me.tabCLASSIFICATION.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tabCLASSIFICATION.Controls.Add(Me.grbEXPERIENCES)
        Me.tabCLASSIFICATION.Controls.Add(Me.GroupBox2)
        Me.tabCLASSIFICATION.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabCLASSIFICATION.Location = New System.Drawing.Point(4, 22)
        Me.tabCLASSIFICATION.Name = "tabCLASSIFICATION"
        Me.tabCLASSIFICATION.Size = New System.Drawing.Size(784, 320)
        Me.tabCLASSIFICATION.TabIndex = 6
        Me.tabCLASSIFICATION.Tag = "CLASSIFICATION"
        Me.tabCLASSIFICATION.Text = "tabCLASSIFICATION"
        '
        'grbEXPERIENCES
        '
        Me.grbEXPERIENCES.Controls.Add(Me.lblEXPERIENCECD)
        Me.grbEXPERIENCES.Controls.Add(Me.chkREALESTATE)
        Me.grbEXPERIENCES.Controls.Add(Me.chkOTHERS)
        Me.grbEXPERIENCES.Controls.Add(Me.chkFOREX)
        Me.grbEXPERIENCES.Controls.Add(Me.chkBOND)
        Me.grbEXPERIENCES.Controls.Add(Me.chkEQUITIES)
        Me.grbEXPERIENCES.Controls.Add(Me.txtEXPERIENCECD)
        Me.grbEXPERIENCES.Controls.Add(Me.lblEXPERIENCETYPE)
        Me.grbEXPERIENCES.Controls.Add(Me.cboEXPERIENCETYPE)
        Me.grbEXPERIENCES.Controls.Add(Me.cboFOCUSTYPE)
        Me.grbEXPERIENCES.Controls.Add(Me.lblFOCUSTYPE)
        Me.grbEXPERIENCES.Location = New System.Drawing.Point(8, 243)
        Me.grbEXPERIENCES.Name = "grbEXPERIENCES"
        Me.grbEXPERIENCES.Size = New System.Drawing.Size(768, 72)
        Me.grbEXPERIENCES.TabIndex = 1
        Me.grbEXPERIENCES.TabStop = False
        Me.grbEXPERIENCES.Tag = "grbEXPERIENCES"
        Me.grbEXPERIENCES.Text = "grbEXPERIENCES"
        '
        'lblEXPERIENCECD
        '
        Me.lblEXPERIENCECD.Location = New System.Drawing.Point(283, 11)
        Me.lblEXPERIENCECD.Name = "lblEXPERIENCECD"
        Me.lblEXPERIENCECD.Size = New System.Drawing.Size(130, 27)
        Me.lblEXPERIENCECD.TabIndex = 4
        Me.lblEXPERIENCECD.Tag = "EXPERIENCECD"
        Me.lblEXPERIENCECD.Text = "lblEXPERIENCECD"
        Me.lblEXPERIENCECD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkREALESTATE
        '
        Me.chkREALESTATE.Location = New System.Drawing.Point(629, 16)
        Me.chkREALESTATE.Name = "chkREALESTATE"
        Me.chkREALESTATE.Size = New System.Drawing.Size(65, 16)
        Me.chkREALESTATE.TabIndex = 8
        Me.chkREALESTATE.Tag = "chkREALESTATE"
        Me.chkREALESTATE.Text = "chkREALESTATE"
        '
        'chkOTHERS
        '
        Me.chkOTHERS.Location = New System.Drawing.Point(699, 16)
        Me.chkOTHERS.Name = "chkOTHERS"
        Me.chkOTHERS.Size = New System.Drawing.Size(65, 16)
        Me.chkOTHERS.TabIndex = 9
        Me.chkOTHERS.Tag = "chkOTHERS"
        Me.chkOTHERS.Text = "chkOTHERS"
        '
        'chkFOREX
        '
        Me.chkFOREX.Location = New System.Drawing.Point(559, 16)
        Me.chkFOREX.Name = "chkFOREX"
        Me.chkFOREX.Size = New System.Drawing.Size(65, 16)
        Me.chkFOREX.TabIndex = 7
        Me.chkFOREX.Tag = "chkFOREX"
        Me.chkFOREX.Text = "chkFOREX"
        '
        'chkBOND
        '
        Me.chkBOND.Location = New System.Drawing.Point(489, 16)
        Me.chkBOND.Name = "chkBOND"
        Me.chkBOND.Size = New System.Drawing.Size(65, 16)
        Me.chkBOND.TabIndex = 6
        Me.chkBOND.Tag = "chkBOND"
        Me.chkBOND.Text = "chkBOND"
        '
        'chkEQUITIES
        '
        Me.chkEQUITIES.Location = New System.Drawing.Point(419, 16)
        Me.chkEQUITIES.Name = "chkEQUITIES"
        Me.chkEQUITIES.Size = New System.Drawing.Size(65, 16)
        Me.chkEQUITIES.TabIndex = 5
        Me.chkEQUITIES.Tag = "chkEQUITIES"
        Me.chkEQUITIES.Text = "chkEQUITIES"
        '
        'txtEXPERIENCECD
        '
        Me.txtEXPERIENCECD.Location = New System.Drawing.Point(327, 41)
        Me.txtEXPERIENCECD.MaxLength = 10
        Me.txtEXPERIENCECD.Name = "txtEXPERIENCECD"
        Me.txtEXPERIENCECD.Size = New System.Drawing.Size(104, 21)
        Me.txtEXPERIENCECD.TabIndex = 1
        Me.txtEXPERIENCECD.Tag = "EXPERIENCECD"
        Me.txtEXPERIENCECD.Text = "txtEXPERIENCECD"
        '
        'lblEXPERIENCETYPE
        '
        Me.lblEXPERIENCETYPE.Location = New System.Drawing.Point(8, 16)
        Me.lblEXPERIENCETYPE.Name = "lblEXPERIENCETYPE"
        Me.lblEXPERIENCETYPE.Size = New System.Drawing.Size(112, 21)
        Me.lblEXPERIENCETYPE.TabIndex = 2
        Me.lblEXPERIENCETYPE.Tag = "EXPERIENCETYPE"
        Me.lblEXPERIENCETYPE.Text = "lblEXPERIENCETYPE"
        Me.lblEXPERIENCETYPE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboEXPERIENCETYPE
        '
        Me.cboEXPERIENCETYPE.DisplayMember = "DISPLAY"
        Me.cboEXPERIENCETYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEXPERIENCETYPE.ItemHeight = 13
        Me.cboEXPERIENCETYPE.Location = New System.Drawing.Point(144, 16)
        Me.cboEXPERIENCETYPE.MaxLength = 3
        Me.cboEXPERIENCETYPE.Name = "cboEXPERIENCETYPE"
        Me.cboEXPERIENCETYPE.Size = New System.Drawing.Size(136, 21)
        Me.cboEXPERIENCETYPE.TabIndex = 3
        Me.cboEXPERIENCETYPE.Tag = "EXPERIENCETYPE"
        Me.cboEXPERIENCETYPE.ValueMember = "VALUE"
        '
        'cboFOCUSTYPE
        '
        Me.cboFOCUSTYPE.DisplayMember = "DISPLAY"
        Me.cboFOCUSTYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFOCUSTYPE.ItemHeight = 13
        Me.cboFOCUSTYPE.Location = New System.Drawing.Point(144, 42)
        Me.cboFOCUSTYPE.MaxLength = 3
        Me.cboFOCUSTYPE.Name = "cboFOCUSTYPE"
        Me.cboFOCUSTYPE.Size = New System.Drawing.Size(136, 21)
        Me.cboFOCUSTYPE.TabIndex = 0
        Me.cboFOCUSTYPE.Tag = "FOCUSTYPE"
        Me.cboFOCUSTYPE.ValueMember = "VALUE"
        '
        'lblFOCUSTYPE
        '
        Me.lblFOCUSTYPE.Location = New System.Drawing.Point(8, 40)
        Me.lblFOCUSTYPE.Name = "lblFOCUSTYPE"
        Me.lblFOCUSTYPE.Size = New System.Drawing.Size(112, 21)
        Me.lblFOCUSTYPE.TabIndex = 10
        Me.lblFOCUSTYPE.Tag = "FOCUSTYPE"
        Me.lblFOCUSTYPE.Text = "lblFOCUSTYPE"
        Me.lblFOCUSTYPE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblUsername)
        Me.GroupBox2.Controls.Add(Me.txtTLID)
        Me.GroupBox2.Controls.Add(Me.lblUser)
        Me.GroupBox2.Controls.Add(Me.lblCAREBY)
        Me.GroupBox2.Controls.Add(Me.cboCAREBY)
        Me.GroupBox2.Controls.Add(Me.lblSTAFF)
        Me.GroupBox2.Controls.Add(Me.txtCOMPANYID)
        Me.GroupBox2.Controls.Add(Me.lblCOMPANYID)
        Me.GroupBox2.Controls.Add(Me.cboSTAFF)
        Me.GroupBox2.Controls.Add(Me.lblPOSITION)
        Me.GroupBox2.Controls.Add(Me.cboPOSITION)
        Me.GroupBox2.Controls.Add(Me.lblISSUERID)
        Me.GroupBox2.Controls.Add(Me.lblSECTOR)
        Me.GroupBox2.Controls.Add(Me.cboSECTOR)
        Me.GroupBox2.Controls.Add(Me.lblBUSINESSTYPE)
        Me.GroupBox2.Controls.Add(Me.cboBUSINESSTYPE)
        Me.GroupBox2.Controls.Add(Me.cboINVESTRANGE)
        Me.GroupBox2.Controls.Add(Me.lblINVESTRANGE)
        Me.GroupBox2.Controls.Add(Me.lblINVESTTYPE)
        Me.GroupBox2.Controls.Add(Me.cboINVESTTYPE)
        Me.GroupBox2.Controls.Add(Me.lblGRINVESTOR)
        Me.GroupBox2.Controls.Add(Me.cboGRINVESTOR)
        Me.GroupBox2.Controls.Add(Me.cboTIMETOJOIN)
        Me.GroupBox2.Controls.Add(Me.lblTIMETOJOIN)
        Me.GroupBox2.Controls.Add(Me.lblINCOMERANGE)
        Me.GroupBox2.Controls.Add(Me.cboINCOMERANGE)
        Me.GroupBox2.Controls.Add(Me.lblASSETRANGE)
        Me.GroupBox2.Controls.Add(Me.ss)
        Me.GroupBox2.Controls.Add(Me.txtREFNAME)
        Me.GroupBox2.Controls.Add(Me.lblREFNAME)
        Me.GroupBox2.Controls.Add(Me.cboCLASS)
        Me.GroupBox2.Controls.Add(Me.lblCLASS)
        Me.GroupBox2.Controls.Add(Me.txtISSUERID)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(768, 227)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Tag = "GroupBox2"
        Me.GroupBox2.Text = "GroupBox2"
        '
        'lblUsername
        '
        Me.lblUsername.Location = New System.Drawing.Point(615, 199)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(145, 21)
        Me.lblUsername.TabIndex = 32
        Me.lblUsername.Tag = "lblUsername"
        Me.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTLID
        '
        Me.txtTLID.Location = New System.Drawing.Point(537, 200)
        Me.txtTLID.MaxLength = 10
        Me.txtTLID.Name = "txtTLID"
        Me.txtTLID.Size = New System.Drawing.Size(69, 21)
        Me.txtTLID.TabIndex = 31
        Me.txtTLID.Tag = "TLID"
        Me.txtTLID.Text = "txtTLID"
        Me.txtTLID.Visible = False
        '
        'lblUser
        '
        Me.lblUser.Location = New System.Drawing.Point(401, 200)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(126, 21)
        Me.lblUser.TabIndex = 30
        Me.lblUser.Tag = "TLID"
        Me.lblUser.Text = "lblUser"
        Me.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCAREBY
        '
        Me.lblCAREBY.ForeColor = System.Drawing.Color.Red
        Me.lblCAREBY.Location = New System.Drawing.Point(16, 200)
        Me.lblCAREBY.Name = "lblCAREBY"
        Me.lblCAREBY.Size = New System.Drawing.Size(120, 21)
        Me.lblCAREBY.TabIndex = 26
        Me.lblCAREBY.Tag = "CAREBY"
        Me.lblCAREBY.Text = "lblCAREBY"
        Me.lblCAREBY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCAREBY
        '
        Me.cboCAREBY.DisplayMember = "DISPLAY"
        Me.cboCAREBY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCAREBY.ItemHeight = 13
        Me.cboCAREBY.Location = New System.Drawing.Point(144, 201)
        Me.cboCAREBY.MaxLength = 3
        Me.cboCAREBY.Name = "cboCAREBY"
        Me.cboCAREBY.Size = New System.Drawing.Size(224, 21)
        Me.cboCAREBY.TabIndex = 27
        Me.cboCAREBY.Tag = "CAREBY"
        Me.cboCAREBY.ValueMember = "VALUE"
        '
        'lblSTAFF
        '
        Me.lblSTAFF.Location = New System.Drawing.Point(16, 17)
        Me.lblSTAFF.Name = "lblSTAFF"
        Me.lblSTAFF.Size = New System.Drawing.Size(120, 21)
        Me.lblSTAFF.TabIndex = 0
        Me.lblSTAFF.Tag = "STAFF"
        Me.lblSTAFF.Text = "lblSTAFF"
        Me.lblSTAFF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCOMPANYID
        '
        Me.txtCOMPANYID.Location = New System.Drawing.Point(536, 43)
        Me.txtCOMPANYID.MaxLength = 20
        Me.txtCOMPANYID.Name = "txtCOMPANYID"
        Me.txtCOMPANYID.Size = New System.Drawing.Size(224, 21)
        Me.txtCOMPANYID.TabIndex = 7
        Me.txtCOMPANYID.Tag = "COMPANYID"
        Me.txtCOMPANYID.Text = "txtCOMPANYID"
        '
        'lblCOMPANYID
        '
        Me.lblCOMPANYID.Location = New System.Drawing.Point(400, 43)
        Me.lblCOMPANYID.Name = "lblCOMPANYID"
        Me.lblCOMPANYID.Size = New System.Drawing.Size(126, 21)
        Me.lblCOMPANYID.TabIndex = 6
        Me.lblCOMPANYID.Tag = "COMPANYID"
        Me.lblCOMPANYID.Text = "lblCOMPANYID"
        Me.lblCOMPANYID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSTAFF
        '
        Me.cboSTAFF.DisplayMember = "DISPLAY"
        Me.cboSTAFF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSTAFF.ItemHeight = 13
        Me.cboSTAFF.Location = New System.Drawing.Point(144, 17)
        Me.cboSTAFF.MaxLength = 3
        Me.cboSTAFF.Name = "cboSTAFF"
        Me.cboSTAFF.Size = New System.Drawing.Size(224, 21)
        Me.cboSTAFF.TabIndex = 1
        Me.cboSTAFF.Tag = "STAFF"
        Me.cboSTAFF.ValueMember = "VALUE"
        '
        'lblPOSITION
        '
        Me.lblPOSITION.Location = New System.Drawing.Point(16, 43)
        Me.lblPOSITION.Name = "lblPOSITION"
        Me.lblPOSITION.Size = New System.Drawing.Size(120, 21)
        Me.lblPOSITION.TabIndex = 4
        Me.lblPOSITION.Tag = "POSITION"
        Me.lblPOSITION.Text = "lblPOSITION"
        Me.lblPOSITION.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPOSITION
        '
        Me.cboPOSITION.DisplayMember = "DISPLAY"
        Me.cboPOSITION.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPOSITION.ItemHeight = 13
        Me.cboPOSITION.Location = New System.Drawing.Point(144, 43)
        Me.cboPOSITION.MaxLength = 3
        Me.cboPOSITION.Name = "cboPOSITION"
        Me.cboPOSITION.Size = New System.Drawing.Size(224, 21)
        Me.cboPOSITION.TabIndex = 5
        Me.cboPOSITION.Tag = "POSITION"
        Me.cboPOSITION.ValueMember = "VALUE"
        '
        'lblISSUERID
        '
        Me.lblISSUERID.Location = New System.Drawing.Point(400, 17)
        Me.lblISSUERID.Name = "lblISSUERID"
        Me.lblISSUERID.Size = New System.Drawing.Size(126, 21)
        Me.lblISSUERID.TabIndex = 2
        Me.lblISSUERID.Tag = "ISSUERID"
        Me.lblISSUERID.Text = "lblISSUERID"
        Me.lblISSUERID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSECTOR
        '
        Me.lblSECTOR.Location = New System.Drawing.Point(402, 69)
        Me.lblSECTOR.Name = "lblSECTOR"
        Me.lblSECTOR.Size = New System.Drawing.Size(126, 21)
        Me.lblSECTOR.TabIndex = 10
        Me.lblSECTOR.Tag = "SECTOR"
        Me.lblSECTOR.Text = "lblSECTOR"
        Me.lblSECTOR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSECTOR
        '
        Me.cboSECTOR.DisplayMember = "DISPLAY"
        Me.cboSECTOR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSECTOR.ItemHeight = 13
        Me.cboSECTOR.Location = New System.Drawing.Point(536, 69)
        Me.cboSECTOR.MaxLength = 3
        Me.cboSECTOR.Name = "cboSECTOR"
        Me.cboSECTOR.Size = New System.Drawing.Size(224, 21)
        Me.cboSECTOR.TabIndex = 11
        Me.cboSECTOR.Tag = "SECTOR"
        Me.cboSECTOR.ValueMember = "VALUE"
        '
        'lblBUSINESSTYPE
        '
        Me.lblBUSINESSTYPE.Location = New System.Drawing.Point(16, 69)
        Me.lblBUSINESSTYPE.Name = "lblBUSINESSTYPE"
        Me.lblBUSINESSTYPE.Size = New System.Drawing.Size(120, 21)
        Me.lblBUSINESSTYPE.TabIndex = 8
        Me.lblBUSINESSTYPE.Tag = "BUSINESSTYPE"
        Me.lblBUSINESSTYPE.Text = "lblBUSINESSTYPE"
        Me.lblBUSINESSTYPE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboBUSINESSTYPE
        '
        Me.cboBUSINESSTYPE.DisplayMember = "DISPLAY"
        Me.cboBUSINESSTYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBUSINESSTYPE.ItemHeight = 13
        Me.cboBUSINESSTYPE.Location = New System.Drawing.Point(144, 69)
        Me.cboBUSINESSTYPE.MaxLength = 3
        Me.cboBUSINESSTYPE.Name = "cboBUSINESSTYPE"
        Me.cboBUSINESSTYPE.Size = New System.Drawing.Size(224, 21)
        Me.cboBUSINESSTYPE.TabIndex = 9
        Me.cboBUSINESSTYPE.Tag = "BUSINESSTYPE"
        Me.cboBUSINESSTYPE.ValueMember = "VALUE"
        '
        'cboINVESTRANGE
        '
        Me.cboINVESTRANGE.DisplayMember = "DISPLAY"
        Me.cboINVESTRANGE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboINVESTRANGE.ItemHeight = 13
        Me.cboINVESTRANGE.Location = New System.Drawing.Point(536, 95)
        Me.cboINVESTRANGE.MaxLength = 3
        Me.cboINVESTRANGE.Name = "cboINVESTRANGE"
        Me.cboINVESTRANGE.Size = New System.Drawing.Size(224, 21)
        Me.cboINVESTRANGE.TabIndex = 15
        Me.cboINVESTRANGE.Tag = "INVESTRANGE"
        Me.cboINVESTRANGE.ValueMember = "VALUE"
        '
        'lblINVESTRANGE
        '
        Me.lblINVESTRANGE.Location = New System.Drawing.Point(402, 95)
        Me.lblINVESTRANGE.Name = "lblINVESTRANGE"
        Me.lblINVESTRANGE.Size = New System.Drawing.Size(126, 21)
        Me.lblINVESTRANGE.TabIndex = 14
        Me.lblINVESTRANGE.Tag = "INVESTRANGE"
        Me.lblINVESTRANGE.Text = "lblINVESTRANGE"
        Me.lblINVESTRANGE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblINVESTTYPE
        '
        Me.lblINVESTTYPE.Location = New System.Drawing.Point(16, 95)
        Me.lblINVESTTYPE.Name = "lblINVESTTYPE"
        Me.lblINVESTTYPE.Size = New System.Drawing.Size(120, 21)
        Me.lblINVESTTYPE.TabIndex = 12
        Me.lblINVESTTYPE.Tag = "INVESTTYPE"
        Me.lblINVESTTYPE.Text = "lblINVESTTYPE"
        Me.lblINVESTTYPE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboINVESTTYPE
        '
        Me.cboINVESTTYPE.DisplayMember = "DISPLAY"
        Me.cboINVESTTYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboINVESTTYPE.ItemHeight = 13
        Me.cboINVESTTYPE.Location = New System.Drawing.Point(144, 95)
        Me.cboINVESTTYPE.MaxLength = 3
        Me.cboINVESTTYPE.Name = "cboINVESTTYPE"
        Me.cboINVESTTYPE.Size = New System.Drawing.Size(224, 21)
        Me.cboINVESTTYPE.TabIndex = 13
        Me.cboINVESTTYPE.Tag = "INVESTTYPE"
        Me.cboINVESTTYPE.ValueMember = "VALUE"
        '
        'lblGRINVESTOR
        '
        Me.lblGRINVESTOR.Location = New System.Drawing.Point(16, 121)
        Me.lblGRINVESTOR.Name = "lblGRINVESTOR"
        Me.lblGRINVESTOR.Size = New System.Drawing.Size(120, 21)
        Me.lblGRINVESTOR.TabIndex = 16
        Me.lblGRINVESTOR.Tag = "GRINVESTOR"
        Me.lblGRINVESTOR.Text = "lblGRINVESTOR"
        Me.lblGRINVESTOR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboGRINVESTOR
        '
        Me.cboGRINVESTOR.DisplayMember = "DISPLAY"
        Me.cboGRINVESTOR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGRINVESTOR.ItemHeight = 13
        Me.cboGRINVESTOR.Location = New System.Drawing.Point(144, 121)
        Me.cboGRINVESTOR.MaxLength = 3
        Me.cboGRINVESTOR.Name = "cboGRINVESTOR"
        Me.cboGRINVESTOR.Size = New System.Drawing.Size(224, 21)
        Me.cboGRINVESTOR.TabIndex = 17
        Me.cboGRINVESTOR.Tag = "GRINVESTOR"
        Me.cboGRINVESTOR.ValueMember = "VALUE"
        '
        'cboTIMETOJOIN
        '
        Me.cboTIMETOJOIN.DisplayMember = "DISPLAY"
        Me.cboTIMETOJOIN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTIMETOJOIN.ItemHeight = 13
        Me.cboTIMETOJOIN.Location = New System.Drawing.Point(536, 121)
        Me.cboTIMETOJOIN.MaxLength = 3
        Me.cboTIMETOJOIN.Name = "cboTIMETOJOIN"
        Me.cboTIMETOJOIN.Size = New System.Drawing.Size(224, 21)
        Me.cboTIMETOJOIN.TabIndex = 19
        Me.cboTIMETOJOIN.Tag = "TIMETOJOIN"
        Me.cboTIMETOJOIN.ValueMember = "VALUE"
        '
        'lblTIMETOJOIN
        '
        Me.lblTIMETOJOIN.Location = New System.Drawing.Point(402, 121)
        Me.lblTIMETOJOIN.Name = "lblTIMETOJOIN"
        Me.lblTIMETOJOIN.Size = New System.Drawing.Size(126, 21)
        Me.lblTIMETOJOIN.TabIndex = 18
        Me.lblTIMETOJOIN.Tag = "TIMETOJOIN"
        Me.lblTIMETOJOIN.Text = "lblTIMETOJOIN"
        Me.lblTIMETOJOIN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblINCOMERANGE
        '
        Me.lblINCOMERANGE.Location = New System.Drawing.Point(16, 147)
        Me.lblINCOMERANGE.Name = "lblINCOMERANGE"
        Me.lblINCOMERANGE.Size = New System.Drawing.Size(120, 21)
        Me.lblINCOMERANGE.TabIndex = 20
        Me.lblINCOMERANGE.Tag = "INCOMERANGE"
        Me.lblINCOMERANGE.Text = "lblINCOMERANGE"
        Me.lblINCOMERANGE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboINCOMERANGE
        '
        Me.cboINCOMERANGE.DisplayMember = "DISPLAY"
        Me.cboINCOMERANGE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboINCOMERANGE.ItemHeight = 13
        Me.cboINCOMERANGE.Location = New System.Drawing.Point(144, 147)
        Me.cboINCOMERANGE.MaxLength = 3
        Me.cboINCOMERANGE.Name = "cboINCOMERANGE"
        Me.cboINCOMERANGE.Size = New System.Drawing.Size(224, 21)
        Me.cboINCOMERANGE.TabIndex = 21
        Me.cboINCOMERANGE.Tag = "INCOMERANGE"
        Me.cboINCOMERANGE.ValueMember = "VALUE"
        '
        'lblASSETRANGE
        '
        Me.lblASSETRANGE.Location = New System.Drawing.Point(402, 147)
        Me.lblASSETRANGE.Name = "lblASSETRANGE"
        Me.lblASSETRANGE.Size = New System.Drawing.Size(126, 21)
        Me.lblASSETRANGE.TabIndex = 22
        Me.lblASSETRANGE.Tag = "ASSETRANGE"
        Me.lblASSETRANGE.Text = "lblASSETRANGE"
        Me.lblASSETRANGE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ss
        '
        Me.ss.DisplayMember = "DISPLAY"
        Me.ss.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ss.ItemHeight = 13
        Me.ss.Location = New System.Drawing.Point(536, 147)
        Me.ss.MaxLength = 3
        Me.ss.Name = "ss"
        Me.ss.Size = New System.Drawing.Size(224, 21)
        Me.ss.TabIndex = 23
        Me.ss.Tag = "ASSETRANGE"
        Me.ss.ValueMember = "VALUE"
        '
        'txtREFNAME
        '
        Me.txtREFNAME.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtREFNAME.Location = New System.Drawing.Point(144, 174)
        Me.txtREFNAME.Name = "txtREFNAME"
        Me.txtREFNAME.Size = New System.Drawing.Size(224, 21)
        Me.txtREFNAME.TabIndex = 25
        Me.txtREFNAME.Tag = "REFNAME"
        Me.txtREFNAME.Text = "txtREFNAME"
        '
        'lblREFNAME
        '
        Me.lblREFNAME.Location = New System.Drawing.Point(16, 173)
        Me.lblREFNAME.Name = "lblREFNAME"
        Me.lblREFNAME.Size = New System.Drawing.Size(120, 21)
        Me.lblREFNAME.TabIndex = 24
        Me.lblREFNAME.Tag = "REFNAME"
        Me.lblREFNAME.Text = "lblREFNAME"
        Me.lblREFNAME.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCLASS
        '
        Me.cboCLASS.DisplayMember = "DISPLAY"
        Me.cboCLASS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCLASS.ItemHeight = 13
        Me.cboCLASS.Location = New System.Drawing.Point(536, 174)
        Me.cboCLASS.MaxLength = 3
        Me.cboCLASS.Name = "cboCLASS"
        Me.cboCLASS.Size = New System.Drawing.Size(224, 21)
        Me.cboCLASS.TabIndex = 29
        Me.cboCLASS.Tag = "CLASS"
        Me.cboCLASS.ValueMember = "VALUE"
        '
        'lblCLASS
        '
        Me.lblCLASS.Location = New System.Drawing.Point(401, 173)
        Me.lblCLASS.Name = "lblCLASS"
        Me.lblCLASS.Size = New System.Drawing.Size(80, 21)
        Me.lblCLASS.TabIndex = 28
        Me.lblCLASS.Tag = "CLASS"
        Me.lblCLASS.Text = "lblCLASS"
        Me.lblCLASS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtISSUERID
        '
        Me.txtISSUERID.Location = New System.Drawing.Point(536, 17)
        Me.txtISSUERID.MaxLength = 10
        Me.txtISSUERID.Name = "txtISSUERID"
        Me.txtISSUERID.Size = New System.Drawing.Size(224, 21)
        Me.txtISSUERID.TabIndex = 3
        Me.txtISSUERID.Tag = "ISSUERID"
        Me.txtISSUERID.Text = "txtISSUERID"
        Me.txtISSUERID.Visible = False
        '
        'tabSERVICES
        '
        Me.tabSERVICES.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tabSERVICES.Controls.Add(Me.GroupBox1)
        Me.tabSERVICES.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabSERVICES.Location = New System.Drawing.Point(4, 22)
        Me.tabSERVICES.Name = "tabSERVICES"
        Me.tabSERVICES.Size = New System.Drawing.Size(784, 320)
        Me.tabSERVICES.TabIndex = 2
        Me.tabSERVICES.Tag = "SERVICES"
        Me.tabSERVICES.Text = "tabSERVICES"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblMRLOANLIMIT)
        Me.GroupBox1.Controls.Add(Me.txtMRLOANLIMIT)
        Me.GroupBox1.Controls.Add(Me.lblADVANCELIMIT)
        Me.GroupBox1.Controls.Add(Me.txtADVANCELIMIT)
        Me.GroupBox1.Controls.Add(Me.lblMORTAGERATE)
        Me.GroupBox1.Controls.Add(Me.txtMORTAGERATE)
        Me.GroupBox1.Controls.Add(Me.lblDEPOSITLIMIT)
        Me.GroupBox1.Controls.Add(Me.lblTRADELIMIT)
        Me.GroupBox1.Controls.Add(Me.txtTRADELIMIT)
        Me.GroupBox1.Controls.Add(Me.lblMARGINLIMIT)
        Me.GroupBox1.Controls.Add(Me.txtMARGINLIMIT)
        Me.GroupBox1.Controls.Add(Me.txtREPOLIMIT)
        Me.GroupBox1.Controls.Add(Me.lblREPOLIMIT)
        Me.GroupBox1.Controls.Add(Me.txtDEPOSITLIMIT)
        Me.GroupBox1.Controls.Add(Me.lblLANGUAGE)
        Me.GroupBox1.Controls.Add(Me.cboLANGUAGE)
        Me.GroupBox1.Controls.Add(Me.lblCUSTODYCD)
        Me.GroupBox1.Controls.Add(Me.lblBANKACCTNO)
        Me.GroupBox1.Controls.Add(Me.txtBANKACCTNO)
        Me.GroupBox1.Controls.Add(Me.lblBANKCODE)
        Me.GroupBox1.Controls.Add(Me.cboBANKCODE)
        Me.GroupBox1.Controls.Add(Me.txtCUSTODYCD)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(768, 299)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Tag = "GroupBox1"
        Me.GroupBox1.Text = "GroupBox1"
        '
        'lblMRLOANLIMIT
        '
        Me.lblMRLOANLIMIT.Location = New System.Drawing.Point(12, 178)
        Me.lblMRLOANLIMIT.Name = "lblMRLOANLIMIT"
        Me.lblMRLOANLIMIT.Size = New System.Drawing.Size(150, 21)
        Me.lblMRLOANLIMIT.TabIndex = 20
        Me.lblMRLOANLIMIT.Tag = "MRLOANLIMIT"
        Me.lblMRLOANLIMIT.Text = "lblMRLOANLIMIT"
        Me.lblMRLOANLIMIT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMRLOANLIMIT
        '
        Me.txtMRLOANLIMIT.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMRLOANLIMIT.Location = New System.Drawing.Point(162, 178)
        Me.txtMRLOANLIMIT.Name = "txtMRLOANLIMIT"
        Me.txtMRLOANLIMIT.Size = New System.Drawing.Size(200, 21)
        Me.txtMRLOANLIMIT.TabIndex = 21
        Me.txtMRLOANLIMIT.Tag = "MRLOANLIMIT"
        Me.txtMRLOANLIMIT.Text = "txtMRLOANLIMIT"
        '
        'lblADVANCELIMIT
        '
        Me.lblADVANCELIMIT.Location = New System.Drawing.Point(12, 147)
        Me.lblADVANCELIMIT.Name = "lblADVANCELIMIT"
        Me.lblADVANCELIMIT.Size = New System.Drawing.Size(150, 21)
        Me.lblADVANCELIMIT.TabIndex = 16
        Me.lblADVANCELIMIT.Tag = "ADVANCELIMIT"
        Me.lblADVANCELIMIT.Text = "lblADVANCELIMIT"
        Me.lblADVANCELIMIT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtADVANCELIMIT
        '
        Me.txtADVANCELIMIT.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtADVANCELIMIT.Location = New System.Drawing.Point(162, 147)
        Me.txtADVANCELIMIT.Name = "txtADVANCELIMIT"
        Me.txtADVANCELIMIT.Size = New System.Drawing.Size(200, 21)
        Me.txtADVANCELIMIT.TabIndex = 17
        Me.txtADVANCELIMIT.Tag = "ADVANCELIMIT"
        Me.txtADVANCELIMIT.Text = "txtADVANCELIMIT"
        '
        'lblMORTAGERATE
        '
        Me.lblMORTAGERATE.Location = New System.Drawing.Point(397, 147)
        Me.lblMORTAGERATE.Name = "lblMORTAGERATE"
        Me.lblMORTAGERATE.Size = New System.Drawing.Size(150, 21)
        Me.lblMORTAGERATE.TabIndex = 18
        Me.lblMORTAGERATE.Tag = "MORTAGERATE"
        Me.lblMORTAGERATE.Text = "lblMORTAGERATE"
        Me.lblMORTAGERATE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMORTAGERATE
        '
        Me.txtMORTAGERATE.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMORTAGERATE.Location = New System.Drawing.Point(558, 147)
        Me.txtMORTAGERATE.Name = "txtMORTAGERATE"
        Me.txtMORTAGERATE.Size = New System.Drawing.Size(200, 21)
        Me.txtMORTAGERATE.TabIndex = 19
        Me.txtMORTAGERATE.Tag = "MORTAGERATE"
        Me.txtMORTAGERATE.Text = "txtMORTAGERATE"
        '
        'lblDEPOSITLIMIT
        '
        Me.lblDEPOSITLIMIT.Location = New System.Drawing.Point(397, 117)
        Me.lblDEPOSITLIMIT.Name = "lblDEPOSITLIMIT"
        Me.lblDEPOSITLIMIT.Size = New System.Drawing.Size(150, 21)
        Me.lblDEPOSITLIMIT.TabIndex = 14
        Me.lblDEPOSITLIMIT.Tag = "DEPOSITLIMIT"
        Me.lblDEPOSITLIMIT.Text = "lblDEPOSITLIMIT"
        Me.lblDEPOSITLIMIT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTRADELIMIT
        '
        Me.lblTRADELIMIT.Location = New System.Drawing.Point(12, 87)
        Me.lblTRADELIMIT.Name = "lblTRADELIMIT"
        Me.lblTRADELIMIT.Size = New System.Drawing.Size(150, 21)
        Me.lblTRADELIMIT.TabIndex = 8
        Me.lblTRADELIMIT.Tag = "TRADELIMIT"
        Me.lblTRADELIMIT.Text = "lblTRADELIMIT"
        Me.lblTRADELIMIT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTRADELIMIT
        '
        Me.txtTRADELIMIT.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtTRADELIMIT.Location = New System.Drawing.Point(162, 87)
        Me.txtTRADELIMIT.Name = "txtTRADELIMIT"
        Me.txtTRADELIMIT.Size = New System.Drawing.Size(200, 21)
        Me.txtTRADELIMIT.TabIndex = 9
        Me.txtTRADELIMIT.Tag = "TRADELIMIT"
        Me.txtTRADELIMIT.Text = "txtTRADELIMIT"
        '
        'lblMARGINLIMIT
        '
        Me.lblMARGINLIMIT.Location = New System.Drawing.Point(12, 117)
        Me.lblMARGINLIMIT.Name = "lblMARGINLIMIT"
        Me.lblMARGINLIMIT.Size = New System.Drawing.Size(150, 21)
        Me.lblMARGINLIMIT.TabIndex = 12
        Me.lblMARGINLIMIT.Tag = "MARGINLIMIT"
        Me.lblMARGINLIMIT.Text = "lblMARGINLIMIT"
        Me.lblMARGINLIMIT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMARGINLIMIT
        '
        Me.txtMARGINLIMIT.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMARGINLIMIT.Location = New System.Drawing.Point(162, 117)
        Me.txtMARGINLIMIT.Name = "txtMARGINLIMIT"
        Me.txtMARGINLIMIT.Size = New System.Drawing.Size(200, 21)
        Me.txtMARGINLIMIT.TabIndex = 13
        Me.txtMARGINLIMIT.Tag = "MARGINLIMIT"
        Me.txtMARGINLIMIT.Text = "txtMARGINLIMIT"
        '
        'txtREPOLIMIT
        '
        Me.txtREPOLIMIT.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtREPOLIMIT.Location = New System.Drawing.Point(558, 87)
        Me.txtREPOLIMIT.Name = "txtREPOLIMIT"
        Me.txtREPOLIMIT.Size = New System.Drawing.Size(200, 21)
        Me.txtREPOLIMIT.TabIndex = 11
        Me.txtREPOLIMIT.Tag = "REPOLIMIT"
        Me.txtREPOLIMIT.Text = "txtREPOLIMIT"
        '
        'lblREPOLIMIT
        '
        Me.lblREPOLIMIT.Location = New System.Drawing.Point(397, 87)
        Me.lblREPOLIMIT.Name = "lblREPOLIMIT"
        Me.lblREPOLIMIT.Size = New System.Drawing.Size(150, 21)
        Me.lblREPOLIMIT.TabIndex = 10
        Me.lblREPOLIMIT.Tag = "REPOLIMIT"
        Me.lblREPOLIMIT.Text = "lblREPOLIMIT"
        Me.lblREPOLIMIT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDEPOSITLIMIT
        '
        Me.txtDEPOSITLIMIT.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDEPOSITLIMIT.Location = New System.Drawing.Point(558, 117)
        Me.txtDEPOSITLIMIT.Name = "txtDEPOSITLIMIT"
        Me.txtDEPOSITLIMIT.Size = New System.Drawing.Size(200, 21)
        Me.txtDEPOSITLIMIT.TabIndex = 15
        Me.txtDEPOSITLIMIT.Tag = "DEPOSITLIMIT"
        Me.txtDEPOSITLIMIT.Text = "txtDEPOSITLIMIT"
        '
        'lblLANGUAGE
        '
        Me.lblLANGUAGE.Location = New System.Drawing.Point(397, 27)
        Me.lblLANGUAGE.Name = "lblLANGUAGE"
        Me.lblLANGUAGE.Size = New System.Drawing.Size(150, 21)
        Me.lblLANGUAGE.TabIndex = 2
        Me.lblLANGUAGE.Tag = "LANGUAGE"
        Me.lblLANGUAGE.Text = "lblLANGUAGE"
        Me.lblLANGUAGE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboLANGUAGE
        '
        Me.cboLANGUAGE.DisplayMember = "DISPLAY"
        Me.cboLANGUAGE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLANGUAGE.ItemHeight = 13
        Me.cboLANGUAGE.Location = New System.Drawing.Point(558, 27)
        Me.cboLANGUAGE.MaxLength = 3
        Me.cboLANGUAGE.Name = "cboLANGUAGE"
        Me.cboLANGUAGE.Size = New System.Drawing.Size(200, 21)
        Me.cboLANGUAGE.TabIndex = 3
        Me.cboLANGUAGE.Tag = "LANGUAGE"
        Me.cboLANGUAGE.ValueMember = "VALUE"
        '
        'lblCUSTODYCD
        '
        Me.lblCUSTODYCD.Location = New System.Drawing.Point(12, 27)
        Me.lblCUSTODYCD.Name = "lblCUSTODYCD"
        Me.lblCUSTODYCD.Size = New System.Drawing.Size(150, 21)
        Me.lblCUSTODYCD.TabIndex = 0
        Me.lblCUSTODYCD.Tag = "CUSTODYCD"
        Me.lblCUSTODYCD.Text = "lblCUSTODYCD"
        Me.lblCUSTODYCD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBANKACCTNO
        '
        Me.lblBANKACCTNO.Location = New System.Drawing.Point(12, 57)
        Me.lblBANKACCTNO.Name = "lblBANKACCTNO"
        Me.lblBANKACCTNO.Size = New System.Drawing.Size(150, 21)
        Me.lblBANKACCTNO.TabIndex = 4
        Me.lblBANKACCTNO.Tag = "BANKACCTNO"
        Me.lblBANKACCTNO.Text = "lblBANKACCTNO"
        Me.lblBANKACCTNO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBANKACCTNO
        '
        Me.txtBANKACCTNO.Location = New System.Drawing.Point(162, 57)
        Me.txtBANKACCTNO.MaxLength = 20
        Me.txtBANKACCTNO.Name = "txtBANKACCTNO"
        Me.txtBANKACCTNO.Size = New System.Drawing.Size(200, 21)
        Me.txtBANKACCTNO.TabIndex = 5
        Me.txtBANKACCTNO.Tag = "BANKACCTNO"
        Me.txtBANKACCTNO.Text = "txtBANKACCTNO"
        '
        'lblBANKCODE
        '
        Me.lblBANKCODE.Location = New System.Drawing.Point(397, 57)
        Me.lblBANKCODE.Name = "lblBANKCODE"
        Me.lblBANKCODE.Size = New System.Drawing.Size(150, 21)
        Me.lblBANKCODE.TabIndex = 6
        Me.lblBANKCODE.Tag = "BANKCODE"
        Me.lblBANKCODE.Text = "lblBANKCODE"
        Me.lblBANKCODE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboBANKCODE
        '
        Me.cboBANKCODE.DisplayMember = "DISPLAY"
        Me.cboBANKCODE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBANKCODE.ItemHeight = 13
        Me.cboBANKCODE.Location = New System.Drawing.Point(558, 57)
        Me.cboBANKCODE.MaxLength = 3
        Me.cboBANKCODE.Name = "cboBANKCODE"
        Me.cboBANKCODE.Size = New System.Drawing.Size(200, 21)
        Me.cboBANKCODE.TabIndex = 7
        Me.cboBANKCODE.Tag = "BANKCODE"
        Me.cboBANKCODE.ValueMember = "VALUE"
        '
        'txtCUSTODYCD
        '
        Me.txtCUSTODYCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCUSTODYCD.Location = New System.Drawing.Point(162, 27)
        Me.txtCUSTODYCD.Name = "txtCUSTODYCD"
        Me.txtCUSTODYCD.Size = New System.Drawing.Size(200, 21)
        Me.txtCUSTODYCD.TabIndex = 1
        Me.txtCUSTODYCD.Tag = "CUSTODYCD"
        Me.txtCUSTODYCD.Text = "TXTCUSTODYCD"
        '
        'tabCONTACTS
        '
        Me.tabCONTACTS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tabCONTACTS.Controls.Add(Me.pnContacts)
        Me.tabCONTACTS.Controls.Add(Me.btnCADD)
        Me.tabCONTACTS.Controls.Add(Me.btnCEDIT)
        Me.tabCONTACTS.Controls.Add(Me.btnCDEL)
        Me.tabCONTACTS.Controls.Add(Me.btnCVIEW)
        Me.tabCONTACTS.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabCONTACTS.Location = New System.Drawing.Point(4, 22)
        Me.tabCONTACTS.Name = "tabCONTACTS"
        Me.tabCONTACTS.Size = New System.Drawing.Size(784, 320)
        Me.tabCONTACTS.TabIndex = 3
        Me.tabCONTACTS.Tag = "CONTACTS"
        Me.tabCONTACTS.Text = "tabCONTACTS"
        '
        'pnContacts
        '
        Me.pnContacts.Location = New System.Drawing.Point(8, 40)
        Me.pnContacts.Name = "pnContacts"
        Me.pnContacts.Size = New System.Drawing.Size(768, 240)
        Me.pnContacts.TabIndex = 4
        '
        'btnCADD
        '
        Me.btnCADD.Location = New System.Drawing.Point(10, 10)
        Me.btnCADD.Name = "btnCADD"
        Me.btnCADD.Size = New System.Drawing.Size(75, 23)
        Me.btnCADD.TabIndex = 0
        Me.btnCADD.Tag = "btnCADD"
        Me.btnCADD.Text = "btnCADD"
        '
        'btnCEDIT
        '
        Me.btnCEDIT.Location = New System.Drawing.Point(170, 10)
        Me.btnCEDIT.Name = "btnCEDIT"
        Me.btnCEDIT.Size = New System.Drawing.Size(75, 23)
        Me.btnCEDIT.TabIndex = 2
        Me.btnCEDIT.Tag = "btnCEDIT"
        Me.btnCEDIT.Text = "btnCEDIT"
        '
        'btnCDEL
        '
        Me.btnCDEL.Location = New System.Drawing.Point(250, 10)
        Me.btnCDEL.Name = "btnCDEL"
        Me.btnCDEL.Size = New System.Drawing.Size(75, 23)
        Me.btnCDEL.TabIndex = 3
        Me.btnCDEL.Tag = "btnCDEL"
        Me.btnCDEL.Text = "btnCDEL"
        '
        'btnCVIEW
        '
        Me.btnCVIEW.Location = New System.Drawing.Point(90, 10)
        Me.btnCVIEW.Name = "btnCVIEW"
        Me.btnCVIEW.Size = New System.Drawing.Size(75, 23)
        Me.btnCVIEW.TabIndex = 1
        Me.btnCVIEW.Tag = "btnCVIEW"
        Me.btnCVIEW.Text = "btnCVIEW"
        '
        'tabSIGNATURES
        '
        Me.tabSIGNATURES.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tabSIGNATURES.Controls.Add(Me.lblEXPDATE)
        Me.tabSIGNATURES.Controls.Add(Me.dtpEXPDATE)
        Me.tabSIGNATURES.Controls.Add(Me.lblVALDATE)
        Me.tabSIGNATURES.Controls.Add(Me.dtpVALDATE)
        Me.tabSIGNATURES.Controls.Add(Me.btnNEXT)
        Me.tabSIGNATURES.Controls.Add(Me.btnPREVIOUS)
        Me.tabSIGNATURES.Controls.Add(Me.pnSignatures)
        Me.tabSIGNATURES.Controls.Add(Me.btnSADD)
        Me.tabSIGNATURES.Controls.Add(Me.btnSEDIT)
        Me.tabSIGNATURES.Controls.Add(Me.btnSDEL)
        Me.tabSIGNATURES.Controls.Add(Me.btnSVIEW)
        Me.tabSIGNATURES.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabSIGNATURES.Location = New System.Drawing.Point(4, 22)
        Me.tabSIGNATURES.Name = "tabSIGNATURES"
        Me.tabSIGNATURES.Size = New System.Drawing.Size(784, 320)
        Me.tabSIGNATURES.TabIndex = 4
        Me.tabSIGNATURES.Tag = "SIGNATURES"
        Me.tabSIGNATURES.Text = "tabSIGNATURES"
        '
        'lblEXPDATE
        '
        Me.lblEXPDATE.AutoSize = True
        Me.lblEXPDATE.Location = New System.Drawing.Point(307, 50)
        Me.lblEXPDATE.Name = "lblEXPDATE"
        Me.lblEXPDATE.Size = New System.Drawing.Size(61, 13)
        Me.lblEXPDATE.TabIndex = 6
        Me.lblEXPDATE.Tag = "EXPDATE"
        Me.lblEXPDATE.Text = "lblEXPDATE"
        '
        'dtpEXPDATE
        '
        Me.dtpEXPDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEXPDATE.Location = New System.Drawing.Point(404, 42)
        Me.dtpEXPDATE.Name = "dtpEXPDATE"
        Me.dtpEXPDATE.Size = New System.Drawing.Size(136, 21)
        Me.dtpEXPDATE.TabIndex = 7
        Me.dtpEXPDATE.Tag = "EXPDATE"
        Me.dtpEXPDATE.Value = New Date(2006, 8, 28, 13, 36, 3, 671)
        '
        'lblVALDATE
        '
        Me.lblVALDATE.AutoSize = True
        Me.lblVALDATE.Location = New System.Drawing.Point(14, 46)
        Me.lblVALDATE.Name = "lblVALDATE"
        Me.lblVALDATE.Size = New System.Drawing.Size(61, 13)
        Me.lblVALDATE.TabIndex = 4
        Me.lblVALDATE.Tag = "VALDATE"
        Me.lblVALDATE.Text = "lblVALDATE"
        '
        'dtpVALDATE
        '
        Me.dtpVALDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpVALDATE.Location = New System.Drawing.Point(111, 42)
        Me.dtpVALDATE.Name = "dtpVALDATE"
        Me.dtpVALDATE.Size = New System.Drawing.Size(136, 21)
        Me.dtpVALDATE.TabIndex = 5
        Me.dtpVALDATE.Tag = "VALDATE"
        Me.dtpVALDATE.Value = New Date(2006, 8, 28, 13, 36, 3, 671)
        '
        'btnNEXT
        '
        Me.btnNEXT.Location = New System.Drawing.Point(701, 10)
        Me.btnNEXT.Name = "btnNEXT"
        Me.btnNEXT.Size = New System.Drawing.Size(75, 23)
        Me.btnNEXT.TabIndex = 9
        Me.btnNEXT.Tag = "btnNEXT"
        Me.btnNEXT.Text = "btnNEXT"
        '
        'btnPREVIOUS
        '
        Me.btnPREVIOUS.Location = New System.Drawing.Point(616, 10)
        Me.btnPREVIOUS.Name = "btnPREVIOUS"
        Me.btnPREVIOUS.Size = New System.Drawing.Size(75, 23)
        Me.btnPREVIOUS.TabIndex = 8
        Me.btnPREVIOUS.Tag = "btnPREVIOUS"
        Me.btnPREVIOUS.Text = "btnPREVIOUS"
        '
        'pnSignatures
        '
        Me.pnSignatures.AutoScroll = True
        Me.pnSignatures.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnSignatures.Location = New System.Drawing.Point(8, 73)
        Me.pnSignatures.Name = "pnSignatures"
        Me.pnSignatures.Size = New System.Drawing.Size(768, 224)
        Me.pnSignatures.TabIndex = 104
        '
        'btnSADD
        '
        Me.btnSADD.Location = New System.Drawing.Point(8, 10)
        Me.btnSADD.Name = "btnSADD"
        Me.btnSADD.Size = New System.Drawing.Size(75, 23)
        Me.btnSADD.TabIndex = 0
        Me.btnSADD.Tag = "btnSADD"
        Me.btnSADD.Text = "btnSADD"
        '
        'btnSEDIT
        '
        Me.btnSEDIT.Location = New System.Drawing.Point(88, 10)
        Me.btnSEDIT.Name = "btnSEDIT"
        Me.btnSEDIT.Size = New System.Drawing.Size(75, 23)
        Me.btnSEDIT.TabIndex = 1
        Me.btnSEDIT.Tag = "btnSEDIT"
        Me.btnSEDIT.Text = "btnSEDIT"
        '
        'btnSDEL
        '
        Me.btnSDEL.Location = New System.Drawing.Point(168, 10)
        Me.btnSDEL.Name = "btnSDEL"
        Me.btnSDEL.Size = New System.Drawing.Size(75, 23)
        Me.btnSDEL.TabIndex = 2
        Me.btnSDEL.Tag = "btnSDEL"
        Me.btnSDEL.Text = "btnSDEL"
        '
        'btnSVIEW
        '
        Me.btnSVIEW.Location = New System.Drawing.Point(248, 10)
        Me.btnSVIEW.Name = "btnSVIEW"
        Me.btnSVIEW.Size = New System.Drawing.Size(75, 23)
        Me.btnSVIEW.TabIndex = 3
        Me.btnSVIEW.Tag = "btnSVIEW"
        Me.btnSVIEW.Text = "btnSVIEW"
        'Me.btnSVIEW.Visible = False
        '
        'tabCONTRACTS
        '
        Me.tabCONTRACTS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tabCONTRACTS.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabCONTRACTS.Location = New System.Drawing.Point(4, 22)
        Me.tabCONTRACTS.Name = "tabCONTRACTS"
        Me.tabCONTRACTS.Size = New System.Drawing.Size(784, 320)
        Me.tabCONTRACTS.TabIndex = 5
        Me.tabCONTRACTS.Tag = "CONTRACTS"
        Me.tabCONTRACTS.Text = "tabCONTRACTS"
        '
        'tabRELATION
        '
        Me.tabRELATION.Controls.Add(Me.tabIDENTIFICATION)
        Me.tabRELATION.Controls.Add(Me.tabSERVICES)
        Me.tabRELATION.Controls.Add(Me.tabCONTRACTS)
        Me.tabRELATION.Controls.Add(Me.tabCLASSIFICATION)
        Me.tabRELATION.Controls.Add(Me.tabSIGNATURES)
        Me.tabRELATION.Controls.Add(Me.tabRELATION1)
        Me.tabRELATION.Controls.Add(Me.tabCONTACTS)
        Me.tabRELATION.Controls.Add(Me.tabISSUER)
        Me.tabRELATION.Controls.Add(Me.tabLMMAST)
        Me.tabRELATION.Controls.Add(Me.tabLNMAST)
        Me.tabRELATION.Controls.Add(Me.tabLNLIMITMAX)
        Me.tabRELATION.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabRELATION.ItemSize = New System.Drawing.Size(111, 18)
        Me.tabRELATION.Location = New System.Drawing.Point(0, 80)
        Me.tabRELATION.Name = "tabRELATION"
        Me.tabRELATION.SelectedIndex = 0
        Me.tabRELATION.Size = New System.Drawing.Size(792, 346)
        Me.tabRELATION.TabIndex = 0
        Me.tabRELATION.Tag = "RELATION"
        '
        'tabRELATION1
        '
        Me.tabRELATION1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tabRELATION1.Controls.Add(Me.pnRelation)
        Me.tabRELATION1.Controls.Add(Me.btnRADD)
        Me.tabRELATION1.Controls.Add(Me.btnREDIT)
        Me.tabRELATION1.Controls.Add(Me.btnRDEL)
        Me.tabRELATION1.Controls.Add(Me.btnRVIEW)
        Me.tabRELATION1.Location = New System.Drawing.Point(4, 22)
        Me.tabRELATION1.Name = "tabRELATION1"
        Me.tabRELATION1.Size = New System.Drawing.Size(784, 320)
        Me.tabRELATION1.TabIndex = 7
        Me.tabRELATION1.Tag = "RELATION"
        Me.tabRELATION1.Text = "tabRELATION"
        '
        'pnRelation
        '
        Me.pnRelation.Location = New System.Drawing.Point(8, 48)
        Me.pnRelation.Name = "pnRelation"
        Me.pnRelation.Size = New System.Drawing.Size(768, 240)
        Me.pnRelation.TabIndex = 0
        Me.pnRelation.Tag = "pnRelation"
        '
        'btnRADD
        '
        Me.btnRADD.Location = New System.Drawing.Point(8, 8)
        Me.btnRADD.Name = "btnRADD"
        Me.btnRADD.Size = New System.Drawing.Size(75, 23)
        Me.btnRADD.TabIndex = 1
        Me.btnRADD.Tag = "btnRADD"
        Me.btnRADD.Text = "btnRADD"
        '
        'btnREDIT
        '
        Me.btnREDIT.Location = New System.Drawing.Point(168, 8)
        Me.btnREDIT.Name = "btnREDIT"
        Me.btnREDIT.Size = New System.Drawing.Size(75, 23)
        Me.btnREDIT.TabIndex = 3
        Me.btnREDIT.Tag = "btnREDIT"
        Me.btnREDIT.Text = "btnREDIT"
        '
        'btnRDEL
        '
        Me.btnRDEL.Location = New System.Drawing.Point(248, 8)
        Me.btnRDEL.Name = "btnRDEL"
        Me.btnRDEL.Size = New System.Drawing.Size(75, 23)
        Me.btnRDEL.TabIndex = 4
        Me.btnRDEL.Tag = "btnRDEL"
        Me.btnRDEL.Text = "btnRDEL"
        '
        'btnRVIEW
        '
        Me.btnRVIEW.Location = New System.Drawing.Point(88, 8)
        Me.btnRVIEW.Name = "btnRVIEW"
        Me.btnRVIEW.Size = New System.Drawing.Size(75, 23)
        Me.btnRVIEW.TabIndex = 2
        Me.btnRVIEW.Tag = "btnRVIEW"
        Me.btnRVIEW.Text = "btnRVIEW"
        '
        'tabISSUER
        '
        Me.tabISSUER.Controls.Add(Me.btnADDISSUER)
        Me.tabISSUER.Controls.Add(Me.btnEDITISSUER)
        Me.tabISSUER.Controls.Add(Me.btnDELISSUER)
        Me.tabISSUER.Controls.Add(Me.btnVIEWISSUER)
        Me.tabISSUER.Controls.Add(Me.pnISSUER)
        Me.tabISSUER.Location = New System.Drawing.Point(4, 22)
        Me.tabISSUER.Name = "tabISSUER"
        Me.tabISSUER.Size = New System.Drawing.Size(784, 320)
        Me.tabISSUER.TabIndex = 8
        Me.tabISSUER.Tag = "tabISSUER"
        Me.tabISSUER.Text = "tabISSUER"
        '
        'btnADDISSUER
        '
        Me.btnADDISSUER.Enabled = False
        Me.btnADDISSUER.Location = New System.Drawing.Point(8, 11)
        Me.btnADDISSUER.Name = "btnADDISSUER"
        Me.btnADDISSUER.Size = New System.Drawing.Size(75, 23)
        Me.btnADDISSUER.TabIndex = 0
        Me.btnADDISSUER.Tag = "btnADDISSUER"
        Me.btnADDISSUER.Text = "btnADDISSUER"
        '
        'btnEDITISSUER
        '
        Me.btnEDITISSUER.Enabled = False
        Me.btnEDITISSUER.Location = New System.Drawing.Point(168, 11)
        Me.btnEDITISSUER.Name = "btnEDITISSUER"
        Me.btnEDITISSUER.Size = New System.Drawing.Size(75, 23)
        Me.btnEDITISSUER.TabIndex = 2
        Me.btnEDITISSUER.Tag = "btnEDITISSUER"
        Me.btnEDITISSUER.Text = "btnEDITISSUER"
        '
        'btnDELISSUER
        '
        Me.btnDELISSUER.Enabled = False
        Me.btnDELISSUER.Location = New System.Drawing.Point(248, 11)
        Me.btnDELISSUER.Name = "btnDELISSUER"
        Me.btnDELISSUER.Size = New System.Drawing.Size(75, 23)
        Me.btnDELISSUER.TabIndex = 3
        Me.btnDELISSUER.Tag = "btnDELISSUER"
        Me.btnDELISSUER.Text = "btnDELISSUER"
        '
        'btnVIEWISSUER
        '
        Me.btnVIEWISSUER.Location = New System.Drawing.Point(88, 11)
        Me.btnVIEWISSUER.Name = "btnVIEWISSUER"
        Me.btnVIEWISSUER.Size = New System.Drawing.Size(75, 23)
        Me.btnVIEWISSUER.TabIndex = 1
        Me.btnVIEWISSUER.Tag = "btnVIEWISSUER"
        Me.btnVIEWISSUER.Text = "btnVIEWISSUER"
        '
        'pnISSUER
        '
        Me.pnISSUER.Location = New System.Drawing.Point(8, 47)
        Me.pnISSUER.Name = "pnISSUER"
        Me.pnISSUER.Size = New System.Drawing.Size(768, 248)
        Me.pnISSUER.TabIndex = 4
        Me.pnISSUER.Tag = "pnISSUER"
        '
        'tabLMMAST
        '
        Me.tabLMMAST.Controls.Add(Me.pnLMMAST)
        Me.tabLMMAST.Controls.Add(Me.btnLMVIEW)
        Me.tabLMMAST.Location = New System.Drawing.Point(4, 22)
        Me.tabLMMAST.Name = "tabLMMAST"
        Me.tabLMMAST.Size = New System.Drawing.Size(784, 320)
        Me.tabLMMAST.TabIndex = 9
        Me.tabLMMAST.Tag = "tabLMMAST"
        Me.tabLMMAST.Text = "tabLMMAST"
        '
        'pnLMMAST
        '
        Me.pnLMMAST.Location = New System.Drawing.Point(0, 48)
        Me.pnLMMAST.Name = "pnLMMAST"
        Me.pnLMMAST.Size = New System.Drawing.Size(776, 248)
        Me.pnLMMAST.TabIndex = 1
        Me.pnLMMAST.Tag = "pnLMMAST"
        '
        'btnLMVIEW
        '
        Me.btnLMVIEW.Location = New System.Drawing.Point(8, 16)
        Me.btnLMVIEW.Name = "btnLMVIEW"
        Me.btnLMVIEW.Size = New System.Drawing.Size(75, 23)
        Me.btnLMVIEW.TabIndex = 0
        Me.btnLMVIEW.Tag = "btnLMVIEW"
        Me.btnLMVIEW.Text = "btnLMVIEW"
        '
        'tabLNMAST
        '
        Me.tabLNMAST.Controls.Add(Me.pnLNMAST)
        Me.tabLNMAST.Controls.Add(Me.btnLNVIEW)
        Me.tabLNMAST.Location = New System.Drawing.Point(4, 22)
        Me.tabLNMAST.Name = "tabLNMAST"
        Me.tabLNMAST.Size = New System.Drawing.Size(784, 320)
        Me.tabLNMAST.TabIndex = 10
        Me.tabLNMAST.Tag = "tabLNMAST"
        Me.tabLNMAST.Text = "tabLNMAST"
        '
        'pnLNMAST
        '
        Me.pnLNMAST.Location = New System.Drawing.Point(0, 56)
        Me.pnLNMAST.Name = "pnLNMAST"
        Me.pnLNMAST.Size = New System.Drawing.Size(784, 240)
        Me.pnLNMAST.TabIndex = 1
        Me.pnLNMAST.Tag = "pnLNMAST"
        '
        'btnLNVIEW
        '
        Me.btnLNVIEW.Location = New System.Drawing.Point(8, 16)
        Me.btnLNVIEW.Name = "btnLNVIEW"
        Me.btnLNVIEW.Size = New System.Drawing.Size(75, 23)
        Me.btnLNVIEW.TabIndex = 0
        Me.btnLNVIEW.Tag = "btnLNVIEW"
        Me.btnLNVIEW.Text = "btnLNVIEW"
        '
        'tabLNLIMITMAX
        '
        Me.tabLNLIMITMAX.Controls.Add(Me.pnLNLIMITMAX)
        Me.tabLNLIMITMAX.Location = New System.Drawing.Point(4, 22)
        Me.tabLNLIMITMAX.Name = "tabLNLIMITMAX"
        Me.tabLNLIMITMAX.Padding = New System.Windows.Forms.Padding(3)
        Me.tabLNLIMITMAX.Size = New System.Drawing.Size(784, 320)
        Me.tabLNLIMITMAX.TabIndex = 11
        Me.tabLNLIMITMAX.Tag = "tabLNLIMITMAX"
        Me.tabLNLIMITMAX.Text = "tabLNLIMITMAX"
        Me.tabLNLIMITMAX.UseVisualStyleBackColor = True
        '
        'pnLNLIMITMAX
        '
        Me.pnLNLIMITMAX.Location = New System.Drawing.Point(0, 17)
        Me.pnLNLIMITMAX.Name = "pnLNLIMITMAX"
        Me.pnLNLIMITMAX.Size = New System.Drawing.Size(784, 244)
        Me.pnLNLIMITMAX.TabIndex = 2
        Me.pnLNLIMITMAX.Tag = "pnLNLIMITMAX"
        '
        'lblCUSTID
        '
        Me.lblCUSTID.Location = New System.Drawing.Point(90, 55)
        Me.lblCUSTID.Name = "lblCUSTID"
        Me.lblCUSTID.Size = New System.Drawing.Size(100, 21)
        Me.lblCUSTID.TabIndex = 106
        Me.lblCUSTID.Tag = "CUSTID"
        Me.lblCUSTID.Text = "lblCUSTID"
        Me.lblCUSTID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnGETCUSTID
        '
        Me.btnGETCUSTID.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnGETCUSTID.Location = New System.Drawing.Point(5, 55)
        Me.btnGETCUSTID.Name = "btnGETCUSTID"
        Me.btnGETCUSTID.Size = New System.Drawing.Size(75, 23)
        Me.btnGETCUSTID.TabIndex = 0
        Me.btnGETCUSTID.Tag = "btnGETCUSTID"
        Me.btnGETCUSTID.Text = "btnGETCUSTID"
        '
        'txtBRID
        '
        Me.txtBRID.Location = New System.Drawing.Point(10, 469)
        Me.txtBRID.MaxLength = 100
        Me.txtBRID.Name = "txtBRID"
        Me.txtBRID.Size = New System.Drawing.Size(80, 21)
        Me.txtBRID.TabIndex = 56
        Me.txtBRID.Tag = "BRID"
        Me.txtBRID.Visible = False
        '
        'frmCFMAST
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(794, 466)
        Me.Controls.Add(Me.txtBRID)
        Me.Controls.Add(Me.btnGETCUSTID)
        Me.Controls.Add(Me.lblCUSTID)
        Me.Controls.Add(Me.txtCUSTID)
        Me.Controls.Add(Me.tabRELATION)
        Me.Name = "frmCFMAST"
        Me.Text = "s"
        Me.Controls.SetChildIndex(Me.tabRELATION, 0)
        Me.Controls.SetChildIndex(Me.txtCUSTID, 0)
        Me.Controls.SetChildIndex(Me.lblCUSTID, 0)
        Me.Controls.SetChildIndex(Me.btnGETCUSTID, 0)
        Me.Controls.SetChildIndex(Me.txtBRID, 0)
        Me.Controls.SetChildIndex(Me.btnApprv, 0)
        Me.Controls.SetChildIndex(Me.cboLink, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.btnApply, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.tabIDENTIFICATION.ResumeLayout(False)
        Me.tabIDENTIFICATION.PerformLayout()
        Me.tabCLASSIFICATION.ResumeLayout(False)
        Me.grbEXPERIENCES.ResumeLayout(False)
        Me.grbEXPERIENCES.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.tabSERVICES.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tabCONTACTS.ResumeLayout(False)
        Me.tabSIGNATURES.ResumeLayout(False)
        Me.tabSIGNATURES.PerformLayout()
        Me.tabRELATION.ResumeLayout(False)
        Me.tabRELATION1.ResumeLayout(False)
        Me.tabISSUER.ResumeLayout(False)
        Me.tabLMMAST.ResumeLayout(False)
        Me.tabLNMAST.ResumeLayout(False)
        Me.tabLNLIMITMAX.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region " Overrides Methods "

    Public Overrides Sub OnInit()
        Dim v_ctrl As Windows.Forms.Control

        Try

            'Fill du lieu vao combobox Country va Province
            cboCOUNTRY.DataSource = mv_COUNTRYTable
            cboCOUNTRY.DisplayMember = "DISPLAY"
            cboCOUNTRY.ValueMember = "VALUE"

            cboPROVINCE.DataSource = mv_PROVINCETable
            cboPROVINCE.DisplayMember = "DISPLAY"
            cboPROVINCE.ValueMember = "VALUE"

            'MyBase.OnInitCFMAST()
            MyBase.OnInit()

            'Load Resource Manager
            ResourceManager = New Resources.ResourceManager(gc_RootNamespace & "." & Me.Name & "-" & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())

            'Fill group care by of customer
            'If TellerId <> ADMIN_ID Then

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
            'End If

            'Load interface
            LoadUserInterface(Me)
            'Load username theo ma TLID
            LoadUsernameCareby()

            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strFLDNAME, v_strVALUE As String
            Dim v_strObjMsg As String = String.Empty
            Dim v_strMaxNumber As String = String.Empty
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery

            Dim v_strCmdInquiry As String = "SELECT VARVALUE MAX_NUMBER_VALUE FROM SYSVAR S WHERE S.VARNAME='MAX_NUMBER_VALUE'"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_SEARCHFLD, gc_ActionInquiry, v_strCmdInquiry, , )
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Count - 1
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strVALUE = .InnerText.ToString
                        Select Case Trim(v_strFLDNAME)
                            Case "MAX_NUMBER_VALUE"
                                v_strMaxNumber = Trim(v_strVALUE)
                        End Select
                    End With
                Next
            Next

            '--------------------------------------------------------------------------------
            'Xá»­ lÃ½ Ä‘áº·c biá»‡t cho riÃªng form frmCFMAST
            '--------------------------------------------------------------------------------
            'Bá»• sung Ä‘iá»?u kiá»‡n lookup cho trÆ°á»?ng CAREBY
            For i As Integer = 0 To mv_arrObjFields.Length - 1
            Next

            'Khá»Ÿi táº¡o cÃ¡c Tabs phá»¥
            InitExternal()

            If (ExeFlag = ExecuteFlag.Edit) Or (ExeFlag = ExecuteFlag.View) Then
                LoadCFContacts(Me.txtCUSTID.Text)
                LoadCFContracts(Me.txtCUSTID.Text)
                LoadCFRelation(Me.txtCUSTID.Text)
                LoadCFIssuer(Me.txtCUSTID.Text)
                LoadLMMAST(Me.txtCUSTID.Text)
                LoadLNMAST(Me.txtCUSTID.Text)
                LoadCFSign(Me.txtCUSTID.Text)
                LoadLNLimitMax(Me.txtCUSTID.Text)
                'AnhVT Changed - Maintenance retroed
            ElseIf (ExeFlag = ExecuteFlag.Approve) Then
                LoadCFContacts(Me.txtCUSTID.Text)
                LoadCFContracts(Me.txtCUSTID.Text)
                LoadCFRelation(Me.txtCUSTID.Text)
                LoadCFSign(Me.txtCUSTID.Text)
                LoadCFIssuer(Me.txtCUSTID.Text)
                LoadLMMAST(Me.txtCUSTID.Text)
                LoadLNMAST(Me.txtCUSTID.Text)
                LoadLNLimitMax(Me.txtCUSTID.Text)
                'Disable cac button trong cac tab
                btnSADD.Enabled = False
                btnSDEL.Enabled = False
                btnSEDIT.Enabled = False

                btnRADD.Enabled = False
                btnRDEL.Enabled = False
                btnREDIT.Enabled = False

                btnCADD.Enabled = False
                btnCEDIT.Enabled = False
                btnCDEL.Enabled = False

                btnADDISSUER.Enabled = False
                btnDELISSUER.Enabled = False
                btnEDITISSUER.Enabled = False

                Me.cboCONTRACTCHK.Enabled = False
            Else
                Me.txtCUSTID.Text = BranchId
                txtMARGINLIMIT.Text = v_strMaxNumber
                txtTRADELIMIT.Text = v_strMaxNumber
                txtADVANCELIMIT.Text = v_strMaxNumber
                txtREPOLIMIT.Text = v_strMaxNumber
                txtDEPOSITLIMIT.Text = v_strMaxNumber
                txtBRID.Text = BranchId

            End If

            If (ExeFlag = ExecuteFlag.Edit) Then
                btnADDISSUER.Enabled = True
                btnDELISSUER.Enabled = True
                btnEDITISSUER.Enabled = True
            End If

            Me.chkBOND.Text = ResourceManager.GetString("chkBOND")
            Me.chkEQUITIES.Text = ResourceManager.GetString("chkEQUITIES")
            Me.chkFOREX.Text = ResourceManager.GetString("chkFOREX")
            Me.chkOTHERS.Text = ResourceManager.GetString("chkOTHERS")
            Me.chkREALESTATE.Text = ResourceManager.GetString("chkREALESTATE")

            ' Neu la khach hang to chuc thi disable thong tin vi tri cua tab phan loai khach hang.
            If (Me.cboCUSTTYPE.SelectedValue.ToString = "B") Then
                Me.cboPOSITION.Visible = False
                Me.lblPOSITION.Visible = False

                Me.lblTAXCODE.ForeColor = Color.Blue
            Else
                Me.cboPOSITION.Visible = True
                Me.lblPOSITION.Visible = True
                Me.lblTAXCODE.ForeColor = Color.Blue
            End If

            tabRELATION.TabPages.Remove(tabLMMAST)
            tabRELATION.TabPages.Remove(tabLNMAST)

            'Phuong Added 
            If ExeFlag = ExecuteFlag.View Then
                Me.btnSEDIT.Enabled = False
                Me.cboCONTRACTCHK.Enabled = False
            ElseIf ExeFlag = ExecuteFlag.Edit Then
                Me.btnSEDIT.Enabled = True
                Me.cboCONTRACTCHK.Enabled = True
            End If
            Me.dtpEXPDATE.Enabled = False
            Me.dtpVALDATE.Enabled = False
            'Me.btnSEDIT.Enabled = False
            'Phuong end

            Me.btnSDEL.Enabled = False

            'Disable some tab if current user not care this customer - TungNT modified
            If (ExeFlag = ExecuteFlag.View Or ExeFlag = ExecuteFlag.Edit) And TellerId <> ADMIN_ID Then
                Dim v_strCareBy As String
                If Trim(GroupCareBy) <> String.Empty Then
                    'v_arrGroupCareBy = GroupCareBy.Split("#")
                    If (Not cboCAREBY.SelectedValue Is Nothing) And (Not cboCAREBY.SelectedValue Is DBNull.Value) Then
                        v_strCareBy = CStr(cboCAREBY.SelectedValue).Trim
                    End If

                    If ExeFlag = ExecuteFlag.View Then
                        cboCAREBY.Enabled = False
                    End If

                    If GroupCareBy.IndexOf(v_strCareBy) = -1 Then
                        tabRELATION.TabPages.Remove(tabCONTRACTS)
                    Else
                        tabCONTRACTS.Enabled = True
                    End If
                Else
                    tabRELATION.TabPages.Remove(tabCONTRACTS)
                End If
                tabRELATION.Update()
            End If
            'End Modified
            Me.txtBRID.Enabled = False
            Me.txtBRID.Visible = True

            If ExeFlag <> ExecuteFlag.AddNew Then
                Me.txtTLID.Enabled = False
            Else
                Me.txtTLID.Enabled = True
            End If
            'Binhpt add
            If (IsOnlineRegister) Then
                Me.Text = ResourceManager.GetString("frmCFMAST")
                SetValueOnlineRegister()
                btnGETCUSTID.PerformClick()
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ResourceManager.GetString("InitDialogFailed"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub
    'Binhpt add
    Public Sub SetValueOnlineRegister()
        Try
            cboCUSTTYPE.SelectedValue = mv_CustomerType
            txtFULLNAME.Text = mv_CustomerName
            dtpDATEOFBIRTH.Value = Date.Parse(mv_CustomerBirth)
            cboIDTYPE.SelectedValue = mv_IDType
            txtIDCODE.Text = mv_IDCode
            dtpIDDATE.Value = Date.Parse(mv_Iddate)
            txtIDPLACE.Text = mv_Idplace
            dtpIDEXPIRED.Value = Date.Parse(mv_Expiredate)
            txtADDRESS.Text = mv_Address
            txtTAXCODE.Text = mv_Taxcode
            txtPHONE.Text = mv_PrivatePhone
            txtMOBILE.Text = mv_Mobile
            txtFAX.Text = mv_Fax
            txtEMAIL.Text = mv_Email
            cboCOUNTRY.SelectedValue = mv_Country
            cboPROVINCE.SelectedValue = mv_CustomerCity
            txtBANKACCTNO.Text = mv_TKTGTT
            cboEDUCATION.SelectedIndex = 3
            cboMARRIED.SelectedIndex = 3
            cboOCCUPATION.SelectedIndex = 4
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Public Sub OnSubmit()
        Dim v_strTxMsg As String, v_xmlDocument As New Xml.XmlDocument, v_attrColl As Xml.XmlAttributeCollection
        Dim v_intNOSUBMIT As Integer, v_strNEXTTX As String = String.Empty
        Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Try
            'Control Validate
            If Not ControlValidation() Then
                Exit Sub
            End If
            'Ä?Ã£ nháº­p thÃ´ng tin trÃªn mÃ n hÃ¬nh vÃ  submit gá»­i lÃªn APP-SERVER Ä‘á»ƒ xá»­ lÃ½
            'Khá»Ÿi táº¡o Ä‘iá»‡n giao dá»‹ch
            MessageData = vbNullString
            'Verify vÃ  táº¡o Ä‘iá»‡n giao dá»‹ch

            If Not VerifyCFRules(v_strTxMsg) Then
                Exit Sub
            Else
                MessageData = v_strTxMsg
            End If
            'Ä?áº©y Ä‘iá»‡n giao dá»‹ch lÃªn APP-SERVER
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
                    GetReasonFromMessage(v_strTxMsg, v_strErrorMessage)
                    MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                End If
            Else
                'Thong bao approve thanh cong
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
        End Try
    End Sub

    Private Function VerifyCFRules(ByRef v_strTxMsg As String) As Boolean
        Try
            Dim v_strMessage As String = String.Empty
            Dim v_xmlDocument As New Xml.XmlDocument, v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
            Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode, v_intIndex As Long, i, v_intCount As Integer
            Dim v_strFLDNAME As String, v_strFLDDEFNAME As String, v_strDATATYPE As String, v_strFLDVALUE As String
            Dim v_strERRMSG, v_strENERRMSG, v_strOPERATOR, v_strVALEXP, v_strVALEXP2 As String, v_strACTYPE, v_strDESC As String
            Dim v_dtVALEXP, v_dtVALEXP2, v_dtFLDVALUE As Date, v_strCMDSQL As String
            Dim v_ctl As Control, v_attrFLDNAME As Xml.XmlAttribute, v_attrDATATYPE As Xml.XmlAttribute, v_objEval As New Evaluator

            'Táº¡o Ä‘iá»‡n giao dá»‹ch

            'Tạo điện giao dịch
            Select Case v_strSender
                Case "btnREFUSE"
                    v_strMessage = "Refuse customer profile:"
                    LoadScreen(gc_CF_REFUSEPROFILE)
                    v_strTxMsg = BuildXMLTxMsg(gc_MsgTypeTrans, gc_IsLocalMsg, gc_CF_REFUSEPROFILE, Me.BranchId, Me.TellerId, Me.IpAddress, Me.WsName, , , , , , , , , , , , , , , , , Me.BusDate)
                Case "btnREJECT"
                    v_strMessage = "Reject customer profile:"
                    LoadScreen(gc_CF_REJECTPROFILE)
                    v_strTxMsg = BuildXMLTxMsg(gc_MsgTypeTrans, gc_IsLocalMsg, gc_CF_REJECTPROFILE, Me.BranchId, Me.TellerId, Me.IpAddress, Me.WsName, , , , , , , , , , , , , , , , , Me.BusDate)
                Case "btnAPPROVE"
                    v_strMessage = "Approve customer profile:"
                    LoadScreen(gc_CF_APPROVEPROFILE)
                    v_strTxMsg = BuildXMLTxMsg(gc_MsgTypeTrans, gc_IsLocalMsg, gc_CF_APPROVEPROFILE, Me.BranchId, Me.TellerId, Me.IpAddress, Me.WsName, , , , , , , , , , , , , , , , , Me.BusDate)
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
                                v_strFLDVALUE = Trim(Strings.Replace(Me.txtCUSTID.Text, ".", String.Empty))
                            Case "30" 'DESC                                              
                                v_strFLDVALUE = v_strMessage & Me.txtCUSTID.Text & ":" & Me.txtFULLNAME.Text
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
        End Try
    End Function

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

        Try
            'Create message to inquiry object fields
            Dim v_strSQL, v_strClause, v_strObjMsg As String
            Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument
            Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
            If Len(v_strXML) > 0 Then
                v_xmlDocumentData.LoadXml(v_strXML)
            End If

            'Láº¥y thÃ´ng tin chung vá»? giao dá»‹ch
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
                'Náº¿u khÃ´ng tá»“n táº¡i mÃ£ giao dá»‹ch
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

            'Láº¥y thÃ´ng tin chi tiáº¿t cÃ¡c trÆ°á»?ng cá»§a giao dá»‹ch
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
                        'Xá»­ lÃ½ cho trÆ°á»?ng Description
                        v_strDefVal = Me.Text
                    ElseIf v_strDefVal = "<$BUSDATE>" Then
                        'Láº¥y ngÃ y lÃ m viá»‡c hiá»‡n táº¡i
                        v_strDefVal = Me.BusDate
                    End If
                    If v_blnChain Then
                        'Náº¿u giao dá»‹ch Ä‘Æ°á»£c náº¡p qua giao dá»‹ch tra cá»©u
                        If Len(v_strChainName) > 0 Then
                            'Náº¿u trÆ°á»?ng nÃ y cÃ³ sá»­ dá»¥ng CHAINNAME Ä‘á»ƒ láº¥y giÃ¡ trá»‹ tá»« mÃ n hÃ¬nh tra cá»©u
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

            'Láº¥y cÃ¡c luáº­t kiá»ƒm tra cá»§a cÃ¡c trÆ°á»?ng giao dá»‹ch
            v_strClause = "SELECT FLDNAME, VALTYPE, OPERATOR, VALEXP, VALEXP2, ERRMSG, EN_ERRMSG FROM FLDVAL " & _
                "WHERE upper(OBJNAME) = '" & strTLTXCD & "' ORDER BY VALTYPE, FLDNAME, ODRNUM" 'Thá»© tá»± order by lÃ  quan trá»?ng khÃ´ng sá»­a
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
                        'Ghi nháº­n thuáº­t toÃ¡n Ä‘á»ƒ kiá»ƒm tra vÃ  tÃ­nh toÃ¡n cho tá»«ng trÆ°á»?ng cá»§a giao dá»‹ch
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

                'Ä?iá»?u kiá»‡n xá»­ lÃ½
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
        End Try
    End Sub

    Public Overrides Sub DoShowScreen()
        Me.tabCONTRACTS.Dispose()
        Me.tabSERVICES.Dispose()
    End Sub


    Public Overrides Sub OnSave()
        Dim v_strObjMsg As String
        Dim v_strSQL As String

        Try
            Select Case ExeFlag
                Case ExecuteFlag.Edit
                    If Me.cboSTATUS.SelectedValue = "E" Then
                        Me.cboSTATUS.SelectedValue = "P"
                    End If
            End Select

            'Update mouse pointer
            Cursor.Current = Cursors.WaitCursor
            If Not ControlValidation(True) Then
                Exit Sub
            End If

            'Neu co NH mo TK: So TK NH phai la bat buoc
            If Me.cboBANKCODE.SelectedValue <> "000" AndAlso Me.txtBANKACCTNO.Text.Trim = "" Then
                Me.tabRELATION.SelectTab(Me.tabSERVICES)
                MsgBox(ResourceManager.GetString("MsgNOTNULLBANKACC"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                Me.txtBANKACCTNO.Focus()
                Exit Sub
            End If

            ''Neu la khach hang to chuc thi phai dien ma so thue
            'If Me.cboCUSTTYPE.SelectedValue = "B" AndAlso Me.txtTAXCODE.Text.Trim = "" Then
            '    MsgBox(ResourceManager.GetString("MsgNOTNULLTAXCODE"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
            '    Me.txtTAXCODE.Focus()
            '    Exit Sub
            'End If

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


            If CheckExistsMarginAccount(txtCUSTID.Text.Replace(".", "").Replace(",", "")) Then
                If MsgBox(ResourceManager.GetString("msgCHECKEXISTSMARGINACCOUNT"), MsgBoxStyle.OkCancel, Me.Text) <> MsgBoxResult.Ok Then
                    Exit Sub
                End If
            End If

            Select Case ExeFlag
                Case ExecuteFlag.AddNew
                    Me.txtEXPERIENCECD.Text = GetExperiencecd()
                Case ExecuteFlag.Edit
                    Me.txtEXPERIENCECD.Text = GetExperiencecd()
            End Select
            MyBase.OnSave()
            If Not DoDataExchange(True) Then
                Exit Sub
            End If

            Select Case ExeFlag
                Case ExecuteFlag.AddNew
                    'AnhVT Retro - Maintenance Approval
                    'v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionAdd, , , , gc_AutoIdUsed)
                    Dim v_strClause As String = KeyFieldName & " = '" & txtCUSTID.Text & "'"
                    v_strObjMsg = BuildXMLObjMsg(Me.BusDate, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionAdd, , v_strClause, , gc_AutoIdUnused)
                    If (IsOnlineRegister) Then
                        Dim v_dc As DataColumn
                        v_dc = New DataColumn("OPENVIA")
                        v_dc.DataType = GetType(String)
                        mv_dsInput.Tables(0).Columns.Add(v_dc)
                        mv_dsInput.Tables(0).Rows(0)("OPENVIA") = "O"
                        v_dc = New DataColumn("OLAUTOID")
                        v_dc.DataType = GetType(String)
                        mv_dsInput.Tables(0).Columns.Add(v_dc)
                        mv_dsInput.Tables(0).Rows(0)("OLAUTOID") = mv_OLAUTOID
                        'v_strClause = v_strClause & ",OPENVIA='T'" & ",OLAUTOIT='" + mv_OLAUTOID + "'"
                    End If
                    BuildXMLObjData(mv_dsInput, v_strObjMsg)
                    Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                    Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)

                    'Kiá»ƒm tra thÃ´ng tin vÃ  xá»­ lÃ½ lá»—i (náº¿u cÃ³) tá»« message tráº£ vá»?
                    Dim v_strErrorSource, v_strErrorMessage As String

                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                    If v_lngErrorCode <> 0 Then
                        'Update mouse pointer
                        Cursor.Current = Cursors.Default
                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Exit Sub
                    End If
                    MsgBox(ResourceManager.GetString("AddnewSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    If v_strSender <> "btnApply" Then
                        Me.DialogResult = DialogResult.OK
                        MyBase.OnClose()
                    Else
                        v_strSender = ""
                        Me.btnADDISSUER.Enabled = True
                        Me.btnCADD.Enabled = True
                        Me.btnCDEL.Enabled = True
                        Me.btnCEDIT.Enabled = True
                        Me.btnCVIEW.Enabled = True
                        Me.btnRADD.Enabled = True
                        Me.btnRVIEW.Enabled = True
                        Me.btnREDIT.Enabled = True
                        Me.btnRDEL.Enabled = True
                        Me.btnSADD.Enabled = True
                        Me.btnSVIEW.Enabled = True
                        Me.btnSDEL.Enabled = True
                        Me.btnSEDIT.Enabled = True
                        KeyFieldValue = GetControlValueByName(KeyFieldName, Me)
                        ExeFlag = ExecuteFlag.Edit
                        LoadUserInterface(Me)
                        mv_dsOldInput = mv_dsInput
                    End If
                Case ExecuteFlag.Edit
                    Dim v_strClause As String

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

                    Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                    Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)

                    'Kiá»ƒm tra thÃ´ng tin vÃ  xá»­ lÃ½ lá»—i (náº¿u cÃ³) tá»« message tráº£ vá»?
                    Dim v_strErrorSource, v_strErrorMessage As String

                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                    If v_lngErrorCode <> 0 Then
                        'Update mouse pointer
                        Cursor.Current = Cursors.Default
                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Exit Sub
                    Else 'Cap nhat thanh cong thi thuc hien cap nhat mot so thong tin lien quan tai cac bang khac
                        ExternalUpdate()
                    End If

                    MsgBox(ResourceManager.GetString("EditSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    'Me.DialogResult = DialogResult.OK
                    'MyBase.OnClose()
                    If v_strSender <> "btnApply" Then
                        Me.DialogResult = DialogResult.OK
                        MyBase.OnClose()
                    End If
            End Select

            'Update mouse pointer
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ResourceManager.GetString("SavingFailed"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Public Overrides Function DoDataExchange(Optional ByVal pv_blnSaved As Boolean = False) As Boolean
        Try
            'If Not ControlValidation(pv_blnSaved) Then
            '    Return False
            'End If

            Return MyBase.DoDataExchange(pv_blnSaved)
        Catch ex As Exception
            Throw ex
            Return False
        End Try
    End Function

    Overrides Sub LoadUserInterface(ByRef pv_ctrl As Windows.Forms.Control)
        MyBase.LoadUserInterface(pv_ctrl)
        Me.tabIDENTIFICATION.Text = ResourceManager.GetString(Me.tabIDENTIFICATION.Tag)
        Me.tabCLASSIFICATION.Text = ResourceManager.GetString(Me.tabCLASSIFICATION.Tag)
        Me.tabCONTACTS.Text = ResourceManager.GetString(Me.tabCONTACTS.Tag)
        Me.tabCONTRACTS.Text = ResourceManager.GetString(Me.tabCONTRACTS.Tag)
        Me.tabSERVICES.Text = ResourceManager.GetString(Me.tabSERVICES.Tag)
        Me.tabSIGNATURES.Text = ResourceManager.GetString(Me.tabSIGNATURES.Tag)
        Me.tabLNLIMITMAX.Text = ResourceManager.GetString(Me.tabLNLIMITMAX.Tag)
        'Sá»­a chá»— nÃ y cho tá»«ng form maintenance khÃ¡c nhau
        If (ExeFlag = ExecuteFlag.AddNew) Then
            txtCUSTID.Visible = True
            'btnAPPROVE.Visible = False
            'Me.btnREFUSE.Visible = False
            'Me.btnREJECT.Visible = False
            ' disable mot so tab khi add moi
            Me.btnSADD.Enabled = False
            Me.btnSEDIT.Enabled = False
            Me.btnSVIEW.Enabled = False
            Me.btnSDEL.Enabled = False

            Me.btnRADD.Enabled = False
            Me.btnREDIT.Enabled = False
            Me.btnRVIEW.Enabled = False
            Me.btnRDEL.Enabled = False

            Me.btnCADD.Enabled = False
            Me.btnCEDIT.Enabled = False
            Me.btnCVIEW.Enabled = False
            Me.btnCDEL.Enabled = False

            Me.btnADDISSUER.Enabled = False
            Me.btnVIEWISSUER.Enabled = False
            Me.btnDELISSUER.Enabled = False
            Me.btnEDITISSUER.Enabled = False


        ElseIf (ExeFlag = ExecuteFlag.Edit) Then
            'Kiem tra truong status 
            ' disable mot so tab khi add moi
            Me.btnSADD.Enabled = True
            Me.btnSEDIT.Enabled = True
            Me.btnSVIEW.Enabled = True
            Me.btnSDEL.Enabled = True

            Me.btnRADD.Enabled = True
            Me.btnREDIT.Enabled = True
            Me.btnRVIEW.Enabled = True
            Me.btnRDEL.Enabled = True

            Me.btnCADD.Enabled = True
            Me.btnCEDIT.Enabled = True
            Me.btnCVIEW.Enabled = True
            Me.btnCDEL.Enabled = True

            Me.btnADDISSUER.Enabled = True
            Me.btnVIEWISSUER.Enabled = True
            Me.btnDELISSUER.Enabled = True
            Me.btnEDITISSUER.Enabled = True

            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strFLDNAME, v_strVALUE As String
            Dim v_strObjMsg As String = String.Empty
            Dim v_strSTATUS As String = String.Empty
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
            Dim v_strCmdInquiry As String = "SELECT STATUS FROM CFMAST WHERE CUSTID='" & Me.txtCUSTID.Text & "'"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, "CF.CFCONTACT", gc_ActionInquiry, v_strCmdInquiry, , )
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Count - 1
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strVALUE = .InnerText.ToString
                        Select Case Trim(v_strFLDNAME)
                            Case "STATUS"
                                v_strSTATUS = Trim(v_strVALUE)
                        End Select
                    End With
                Next
            Next
            'Khong cho phep thay doi Han muc vay Margin. Bat buoc phai qua giao dich
            Me.txtMRLOANLIMIT.Enabled = False
            If v_strSTATUS = "A" Then
                'Me.btnAPPROVE.Visible = False
                'Me.btnREJECT.Visible = False
                'Me.btnREFUSE.Visible = False

                Me.txtTRADELIMIT.Enabled = False
                Me.txtREPOLIMIT.Enabled = False
                Me.txtMARGINLIMIT.Enabled = False
                Me.txtDEPOSITLIMIT.Enabled = False
                Me.txtADVANCELIMIT.Enabled = False
                'Me.txtIDCODE.Enabled = False
                'Theo ma loi SNGP124 cua SBS yeu cau phai cho sua nguoi gioi thieu.
                'Me.txtREFNAME.Enabled = False
                'SGN167
                'Me.cboCLASS.Enabled = False
                'Me.cboCUSTTYPE.Enabled = False
                'Me.cboSTAFF.Enabled = False
                'Me.txtORGINF.Enabled = False
                Me.cboFOCUSTYPE.Enabled = False
            End If






            SetExperiencecd(Me.txtEXPERIENCECD.Text)
            Me.cboSTATUS.Enabled = False
            txtCUSTID.Visible = True
            txtCUSTID.Enabled = False
            Me.btnGETCUSTID.Visible = False

            Me.btnCDEL.Enabled = True
            Me.btnCEDIT.Enabled = True
            Me.btnCADD.Enabled = True

            Me.btnSDEL.Enabled = True
            Me.btnSEDIT.Enabled = True
            Me.btnSADD.Enabled = True

            Me.btnRDEL.Enabled = True
            Me.btnREDIT.Enabled = True
            Me.btnRADD.Enabled = True
            Me.btnOK.Enabled = True

            'Dim v_strGroupCareBy As String
            'v_strGroupCareBy = cboCAREBY.SelectedValue
            'cboCAREBY.Clears()
            'FillGroupCareBy()
            'cboCAREBY.SelectedValue = v_strGroupCareBy

            If Me.cboSTATUS.SelectedValue = "R" Then
                Me.btnOK.Enabled = False
                'Me.btnREFUSE.Enabled = False
                'Me.btnREJECT.Enabled = False
                Me.btnApply.Enabled = False
                'Me.btnAPPROVE.Enabled = False
            End If
            If Me.cboSTATUS.SelectedValue = "A" Then
                'Me.btnREFUSE.Enabled = False
                'Me.btnREJECT.Enabled = False
                'Me.btnAPPROVE.Enabled = False
            End If


        ElseIf (ExeFlag = ExecuteFlag.View Or ExeFlag = ExecuteFlag.Approve) Then
            'Me.btnAPPROVE.Visible = False
            'Me.btnREJECT.Visible = False
            'Me.btnREFUSE.Visible = False

            SetExperiencecd(Me.txtEXPERIENCECD.Text)
            Me.chkBOND.Enabled = False
            Me.chkEQUITIES.Enabled = False
            Me.chkFOREX.Enabled = False
            Me.chkOTHERS.Enabled = False
            Me.chkREALESTATE.Enabled = False

            txtCUSTID.Visible = True
            txtCUSTID.Enabled = False
            Me.btnGETCUSTID.Visible = False
            Me.btnCDEL.Enabled = False
            Me.btnCEDIT.Enabled = False
            Me.btnCADD.Enabled = False
            Me.btnSDEL.Enabled = False
            Me.btnSEDIT.Enabled = False
            Me.btnSADD.Enabled = False
            Me.btnRDEL.Enabled = False
            Me.btnREDIT.Enabled = False
            Me.btnRADD.Enabled = False
            btnADDISSUER.Enabled = False
            btnEDITISSUER.Enabled = False
            btnDELISSUER.Enabled = False
            Me.cboOCCUPATION.Enabled = False
            Me.cboISBANKING.Enabled = False
            Me.cboCOUNTRY.Enabled = False
            Me.cboPROVINCE.Enabled = False
            Me.cboIDTYPE.Enabled = False
            Me.cboSEX.Enabled = False
            Me.cboMARRIED.Enabled = False
            Me.cboEDUCATION.Enabled = False
            Me.cboCUSTTYPE.Enabled = False
            Me.cboSTAFF.Enabled = False

            Me.cboMARGINALLOW.Enabled = False


        Else
            'Me.btnAPPROVE.Visible = False
            'Me.btnREFUSE.Visible = False
            'Me.btnREJECT.Visible = False
            'Me.cboSTATUS.SelectedValue = "A"
            Me.cboSTATUS.Enabled = False
            Me.txtCUSTID.Visible = True
            Me.txtCUSTID.Enabled = True
            Me.btnCDEL.Enabled = False
            Me.btnCEDIT.Enabled = False
            Me.btnCADD.Enabled = False

            Me.btnSDEL.Enabled = False
            Me.btnSEDIT.Enabled = False
            Me.btnSADD.Enabled = False
            Me.btnSADD.Enabled = False

            Me.btnRDEL.Enabled = False
            Me.btnREDIT.Enabled = False
            Me.btnRADD.Enabled = False

        End If
        If ExeFlag <> ExecuteFlag.AddNew Then
            Me.btnCVIEW.Enabled = True
            Me.btnSVIEW.Enabled = True
        End If
        cboSTATUS.Enabled = False

        Me.lblORGINF.Visible = False
        Me.txtORGINF.Visible = False
        Me.lblDESCRIPTION.Visible = False
        Me.txtDESCRIPTION.Visible = False
    End Sub

    Private Function FillGroupCareBy() As Boolean
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
                    'If v_arrGroupCareBy.Length > 1 Then
                    '    For i As Integer = 0 To v_arrGroupCareBy.Length - 2
                    '        v_arrGroup = CStr(v_arrGroupCareBy(i)).Split("|")
                    '        v_strGroupId = v_arrGroup(0)
                    '        'If Trim(v_strCareBy) = Trim(v_strGroupId) Then
                    '        '    'Exit For
                    '        '    Return True
                    '        'End If
                    '    Next
                    '    Return False
                    'Else
                    '    Return False
                    'End If

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

    Private Sub InitExternal()
        'Khoi tao Grid ISSUER
        MemberGrid = New GridEx '("ISSUER_MEMBER", "")
        Dim v_cmrMemberHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrMemberHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrMemberHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        MemberGrid.FixedHeaderRows.Add(v_cmrMemberHeader)

        MemberGrid.Columns.Add(New Xceed.Grid.Column("AUTOID", GetType(Integer)))
        MemberGrid.Columns.Add(New Xceed.Grid.Column("CUSTID", GetType(System.String)))
        MemberGrid.Columns.Add(New Xceed.Grid.Column("FULLNAME", GetType(System.String)))
        MemberGrid.Columns.Add(New Xceed.Grid.Column("ROLECD", GetType(System.String)))
        MemberGrid.Columns.Add(New Xceed.Grid.Column("LICENSENO", GetType(System.String)))
        MemberGrid.Columns.Add(New Xceed.Grid.Column("IDDATE", GetType(System.String)))
        MemberGrid.Columns.Add(New Xceed.Grid.Column("IDEXPIRED", GetType(System.String)))
        MemberGrid.Columns.Add(New Xceed.Grid.Column("IDPLACE", GetType(System.String)))
        MemberGrid.Columns.Add(New Xceed.Grid.Column("DESCRIPTION", GetType(System.String)))



        MemberGrid.Columns("AUTOID").Title = ResourceManager.GetString("grid.AUTOID")
        MemberGrid.Columns("CUSTID").Title = ResourceManager.GetString("grid.CUSTID")
        MemberGrid.Columns("FULLNAME").Title = ResourceManager.GetString("grid.ISS_FULLNAME")
        MemberGrid.Columns("ROLECD").Title = ResourceManager.GetString("grid.ROLECD")
        MemberGrid.Columns("LICENSENO").Title = ResourceManager.GetString("grid.LICENSENO")
        MemberGrid.Columns("IDDATE").Title = ResourceManager.GetString("grid.IDDATE")
        MemberGrid.Columns("IDEXPIRED").Title = ResourceManager.GetString("grid.IDEXPIRED")
        MemberGrid.Columns("IDPLACE").Title = ResourceManager.GetString("grid.IDPLACE")
        MemberGrid.Columns("DESCRIPTION").Title = ResourceManager.GetString("grid.DESCRIPTION")


        MemberGrid.Columns("AUTOID").Width = 0
        MemberGrid.Columns("CUSTID").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        MemberGrid.Columns("FULLNAME").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        MemberGrid.Columns("ROLECD").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        MemberGrid.Columns("LICENSENO").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        MemberGrid.Columns("IDDATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        MemberGrid.Columns("IDEXPIRED").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        MemberGrid.Columns("IDPLACE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        MemberGrid.Columns("DESCRIPTION").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        Me.pnISSUER.Controls.Clear()
        Me.pnISSUER.Controls.Add(MemberGrid)
        MemberGrid.Dock = Windows.Forms.DockStyle.Fill
        'Khá»Ÿi táº¡o Grid contacts
        ContactsGrid = New GridEx
        Dim v_cmrContactsHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrContactsHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrContactsHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        ContactsGrid.FixedHeaderRows.Add(v_cmrContactsHeader)
        ContactsGrid.Columns.Add(New Xceed.Grid.Column("AUTOID", GetType(Integer)))
        ContactsGrid.Columns.Add(New Xceed.Grid.Column("CONTACTTYPE", GetType(System.String)))
        ContactsGrid.Columns.Add(New Xceed.Grid.Column("PERSON", GetType(System.String)))
        ContactsGrid.Columns.Add(New Xceed.Grid.Column("ADDRESS", GetType(System.String)))
        ContactsGrid.Columns.Add(New Xceed.Grid.Column("PHONE", GetType(System.String)))
        ContactsGrid.Columns.Add(New Xceed.Grid.Column("FAX", GetType(System.String)))
        ContactsGrid.Columns.Add(New Xceed.Grid.Column("EMAIL", GetType(System.String)))
        ContactsGrid.Columns.Add(New Xceed.Grid.Column("DESCRIPTION", GetType(System.String)))

        ContactsGrid.Columns("AUTOID").Title = ResourceManager.GetString("CONTACT_AUTOID_EN")
        ContactsGrid.Columns("CONTACTTYPE").Title = ResourceManager.GetString("CONTACT_TYPE_EN")
        ContactsGrid.Columns("PERSON").Title = ResourceManager.GetString("CONTACT_PERSON_EN")
        ContactsGrid.Columns("ADDRESS").Title = ResourceManager.GetString("CONTACT_ADDRESS_EN")
        ContactsGrid.Columns("PHONE").Title = ResourceManager.GetString("CONTACT_PHONE_EN")
        ContactsGrid.Columns("FAX").Title = ResourceManager.GetString("CONTACT_FAX_EN")
        ContactsGrid.Columns("EMAIL").Title = ResourceManager.GetString("CONTACT_EMAIL_EN")
        ContactsGrid.Columns("DESCRIPTION").Title = ResourceManager.GetString("CONTACT_DESCRIPTION_EN")

        ContactsGrid.Columns("AUTOID").Width = 0
        ContactsGrid.Columns("AUTOID").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        ContactsGrid.Columns("CONTACTTYPE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ContactsGrid.Columns("PERSON").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ContactsGrid.Columns("ADDRESS").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ContactsGrid.Columns("PHONE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ContactsGrid.Columns("FAX").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ContactsGrid.Columns("EMAIL").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ContactsGrid.Columns("DESCRIPTION").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left

        Me.pnContacts.Controls.Clear()
        Me.pnContacts.Controls.Add(ContactsGrid)
        ContactsGrid.Dock = Windows.Forms.DockStyle.Fill

        AccountsGrid = New GridEx
        Dim v_cmrAccountsHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrAccountsHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrAccountsHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        AccountsGrid.FixedHeaderRows.Add(v_cmrAccountsHeader)
        AccountsGrid.Columns.Add(New Xceed.Grid.Column("AFACCTNO", GetType(System.String)))
        AccountsGrid.Columns.Add(New Xceed.Grid.Column("LINKTYPE", GetType(System.String)))
        AccountsGrid.Columns.Add(New Xceed.Grid.Column("MODCODE", GetType(System.String)))
        AccountsGrid.Columns.Add(New Xceed.Grid.Column("SYMBOL", GetType(System.String)))
        'AccountsGrid.Columns.Add(New Xceed.Grid.Column("ACCTNO", GetType(System.String)))
        AccountsGrid.Columns.Add(New Xceed.Grid.Column("AVLBAL", GetType(System.Double)))
        AccountsGrid.Columns("AVLBAL").FormatSpecifier = "#,##0"
        AccountsGrid.Columns.Add(New Xceed.Grid.Column("AFTYPE", GetType(System.String)))
        AccountsGrid.Columns.Add(New Xceed.Grid.Column("AFTYPE_NAME", GetType(System.String)))

        AccountsGrid.Columns("AFACCTNO").Title = ResourceManager.GetString("ACCOUNT_AFACCTNO_EN")
        AccountsGrid.Columns("LINKTYPE").Title = ResourceManager.GetString("ACCOUNT_AFROLE_EN")
        AccountsGrid.Columns("MODCODE").Title = ResourceManager.GetString("ACCOUNT_MODULE_EN")
        AccountsGrid.Columns("SYMBOL").Title = ResourceManager.GetString("ACCOUNT_SYMBOL_EN")
        AccountsGrid.Columns("AVLBAL").Title = ResourceManager.GetString("ACCOUNT_BALANCE_EN")
        AccountsGrid.Columns("AFTYPE").Title = ResourceManager.GetString("ACCOUNT_AFTYPE_EN")
        AccountsGrid.Columns("AFTYPE_NAME").Title = ResourceManager.GetString("ACCOUNT_AFTYPE_NAME_EN")

        Me.tabCONTRACTS.Controls.Clear()
        Me.tabCONTRACTS.Controls.Add(AccountsGrid)
        AccountsGrid.Dock = Windows.Forms.DockStyle.Fill

        '  Khá»Ÿi táº¡o Grid Relation
        RelationGrid = New GridEx
        Dim v_cmrRelationHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrRelationHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrRelationHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        RelationGrid.FixedHeaderRows.Add(v_cmrRelationHeader)
        RelationGrid.Columns.Add(New Xceed.Grid.Column("AUTOID", GetType(Integer)))
        RelationGrid.Columns.Add(New Xceed.Grid.Column("RETYPE", GetType(System.String)))
        'RelationGrid.Columns.Add(New Xceed.Grid.Column("NAME", GetType(System.String)))
        RelationGrid.Columns.Add(New Xceed.Grid.Column("RECUSTID", GetType(System.String)))

        RelationGrid.Columns.Add(New Xceed.Grid.Column("FULLNAME", GetType(System.String)))
        RelationGrid.Columns.Add(New Xceed.Grid.Column("LICENSENO", GetType(System.String)))
        RelationGrid.Columns.Add(New Xceed.Grid.Column("ADDRESS", GetType(System.String)))
        RelationGrid.Columns.Add(New Xceed.Grid.Column("TELEPHONE", GetType(System.String)))
        RelationGrid.Columns.Add(New Xceed.Grid.Column("LNPLACE", GetType(System.String)))
        RelationGrid.Columns.Add(New Xceed.Grid.Column("LNIDDATE", GetType(System.String)))

        RelationGrid.Columns.Add(New Xceed.Grid.Column("DESCRIPTION", GetType(System.String)))


        RelationGrid.Columns("AUTOID").Title = ResourceManager.GetString("grid.AUTOID")
        RelationGrid.Columns("RETYPE").Title = ResourceManager.GetString("grid.RETYPE")
        'RelationGrid.Columns("NAME").Title = ResourceManager.GetString("grid.NAME")
        RelationGrid.Columns("RECUSTID").Title = ResourceManager.GetString("grid.RECUSTID")
        RelationGrid.Columns("DESCRIPTION").Title = ResourceManager.GetString("grid.DESCRIPTION")

        RelationGrid.Columns("FULLNAME").Title = ResourceManager.GetString("grid.FULLNAME")
        RelationGrid.Columns("LICENSENO").Title = ResourceManager.GetString("grid.LICENSENO")
        RelationGrid.Columns("ADDRESS").Title = ResourceManager.GetString("grid.ADDRESS")
        RelationGrid.Columns("TELEPHONE").Title = ResourceManager.GetString("grid.TELEPHONE")
        RelationGrid.Columns("LNPLACE").Title = ResourceManager.GetString("grid.LNPLACE")
        RelationGrid.Columns("LNIDDATE").Title = ResourceManager.GetString("grid.LNIDDATE")


        RelationGrid.Columns("AUTOID").Width = 0
        RelationGrid.Columns("AUTOID").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        RelationGrid.Columns("RETYPE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        'RelationGrid.Columns("NAME").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        RelationGrid.Columns("RECUSTID").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        RelationGrid.Columns("DESCRIPTION").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left

        RelationGrid.Columns("FULLNAME").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        RelationGrid.Columns("LICENSENO").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        RelationGrid.Columns("ADDRESS").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        RelationGrid.Columns("TELEPHONE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        RelationGrid.Columns("LNIDDATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        RelationGrid.Columns("LNPLACE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left

        Me.pnRelation.Controls.Clear()
        Me.pnRelation.Controls.Add(RelationGrid)
        RelationGrid.Dock = Windows.Forms.DockStyle.Fill



        '  Khoi tao LimitGrid
        LimitGrid = New GridEx
        Dim v_cmrLimitHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrLimitHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrLimitHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        LimitGrid.FixedHeaderRows.Add(v_cmrLimitHeader)

        LimitGrid.Columns.Add(New Xceed.Grid.Column("ACCTNO", GetType(System.String)))
        LimitGrid.Columns.Add(New Xceed.Grid.Column("SHORTCD", GetType(System.String)))
        LimitGrid.Columns.Add(New Xceed.Grid.Column("APPRLIMIT", GetType(System.Double)))
        LimitGrid.Columns.Add(New Xceed.Grid.Column("OPERLIMIT", GetType(System.Double)))

        LimitGrid.Columns("ACCTNO").Title = ResourceManager.GetString("grid.ACCTNO")
        LimitGrid.Columns("SHORTCD").Title = ResourceManager.GetString("grid.CCYCD")
        LimitGrid.Columns("APPRLIMIT").Title = ResourceManager.GetString("grid.APPRLIMIT")
        LimitGrid.Columns("OPERLIMIT").Title = ResourceManager.GetString("grid.OPERLIMIT")

        LimitGrid.Columns("ACCTNO").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        LimitGrid.Columns("SHORTCD").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        LimitGrid.Columns("APPRLIMIT").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        LimitGrid.Columns("OPERLIMIT").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left

        Me.pnLMMAST.Controls.Clear()
        Me.pnLMMAST.Controls.Add(LimitGrid)
        LimitGrid.Dock = Windows.Forms.DockStyle.Fill


        '  Khoi tao LimitGrid
        LoanGrid = New GridEx
        Dim v_cmrLoanHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrLoanHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrLoanHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        LoanGrid.FixedHeaderRows.Add(v_cmrLoanHeader)

        LoanGrid.Columns.Add(New Xceed.Grid.Column("APPLID", GetType(System.String)))
        LoanGrid.Columns.Add(New Xceed.Grid.Column("ACCTNO", GetType(System.String)))
        LoanGrid.Columns.Add(New Xceed.Grid.Column("APRLIMIT", GetType(System.Double)))
        LoanGrid.Columns.Add(New Xceed.Grid.Column("RLSAMT", GetType(System.Double)))
        LoanGrid.Columns.Add(New Xceed.Grid.Column("PRINNML", GetType(System.Double)))
        LoanGrid.Columns.Add(New Xceed.Grid.Column("PRINPAID", GetType(System.Double)))
        LoanGrid.Columns.Add(New Xceed.Grid.Column("PRINOVD", GetType(System.Double)))

        LoanGrid.Columns("APPLID").Title = ResourceManager.GetString("grid.APPLID")
        LoanGrid.Columns("ACCTNO").Title = ResourceManager.GetString("grid.LNACCTNO")
        LoanGrid.Columns("APRLIMIT").Title = ResourceManager.GetString("grid.APRLIMIT")
        LoanGrid.Columns("RLSAMT").Title = ResourceManager.GetString("grid.RLSAMT")
        LoanGrid.Columns("PRINNML").Title = ResourceManager.GetString("grid.PRINNML")
        LoanGrid.Columns("PRINPAID").Title = ResourceManager.GetString("grid.PRINPAID")
        LoanGrid.Columns("PRINOVD").Title = ResourceManager.GetString("grid.PRINOVD")

        LoanGrid.Columns("APPLID").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        LoanGrid.Columns("ACCTNO").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        LoanGrid.Columns("APRLIMIT").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        LoanGrid.Columns("RLSAMT").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        LoanGrid.Columns("PRINNML").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        LoanGrid.Columns("PRINPAID").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        LoanGrid.Columns("PRINOVD").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left

        Me.pnLNMAST.Controls.Clear()
        Me.pnLNMAST.Controls.Add(LoanGrid)
        LoanGrid.Dock = Windows.Forms.DockStyle.Fill

        ' LNLIMITBANKING GRID
        '--CUSTID,LMTYP,LMSUBTYPE,LMCHKTYP,LMAMT
        LNLimitBankingGrid = New GridEx
        Dim v_cmrLNLimitBankingHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrLNLimitBankingHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrLNLimitBankingHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        LNLimitBankingGrid.FixedHeaderRows.Add(v_cmrLNLimitBankingHeader)
        LNLimitBankingGrid.Columns.Add(New Xceed.Grid.Column("CFCUSTID", GetType(System.String)))
        LNLimitBankingGrid.Columns.Add(New Xceed.Grid.Column("CFFULLNAME", GetType(System.String)))
        LNLimitBankingGrid.Columns.Add(New Xceed.Grid.Column("CFLMTYP", GetType(System.String)))
        LNLimitBankingGrid.Columns.Add(New Xceed.Grid.Column("CFLMSUBTYPE", GetType(System.String)))
        LNLimitBankingGrid.Columns.Add(New Xceed.Grid.Column("CFLMCHKTYP", GetType(System.String)))
        LNLimitBankingGrid.Columns.Add(New Xceed.Grid.Column("CFLIMIT", GetType(System.Double)))

        LNLimitBankingGrid.Columns("CFCUSTID").Title = ResourceManager.GetString("CFCUSTID")
        LNLimitBankingGrid.Columns("CFFULLNAME").Title = ResourceManager.GetString("CFFULLNAME")
        LNLimitBankingGrid.Columns("CFLIMIT").Title = ResourceManager.GetString("CFLIMIT")
        LNLimitBankingGrid.Columns("CFLMSUBTYPE").Title = ResourceManager.GetString("CFLMSUBTYPE")
        LNLimitBankingGrid.Columns("CFLMCHKTYP").Title = ResourceManager.GetString("CFLMCHKTYP")
        LNLimitBankingGrid.Columns("CFLMTYP").Title = ResourceManager.GetString("CFLMTYP")
        LNLimitBankingGrid.Columns("CFLIMIT").FormatSpecifier = "#,##0"
        LNLimitBankingGrid.Columns("CFLIMIT").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        Me.tabLNLIMITMAX.Controls.Clear()
        Me.tabLNLIMITMAX.Controls.Add(LNLimitBankingGrid)
        LNLimitBankingGrid.Dock = Windows.Forms.DockStyle.Fill

        Me.pnSignatures.Controls.Clear()
        Me.pnSignatures.Controls.Add(mv_ImageViewer)
        mv_ImageViewer.Dock = DockStyle.Fill
        'mv_ImageViewer.Anchor = AnchorStyles.Bottom
        mv_ImageViewer.PanButton = MouseButtons.Middle

        AddHandler mv_ImageViewer.Click, AddressOf Me.ImageViewer_Click

    End Sub

    Private Sub ImageViewer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        mv_ImageViewer.ZoomFactor = mv_ImageViewer.ZoomFactor * 0.9 'ZommOut
        'mv_ImageViewer.ZoomFactor = mv_ImageViewer.ZoomFactor * 1.1 'Zomm in
    End Sub

    Private Sub FillComboBoxEx(ByRef pv_cboObject As ComboBoxEx, ByVal pv_strMsg As String)
        Dim v_XmlDocument As New Xml.XmlDocument
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strFLDNAME, v_strValue, v_strVALUECD, v_strDISPLAY As String
            v_XmlDocument.LoadXml(pv_strMsg)
            v_nodeList = v_XmlDocument.SelectNodes("/ObjectMessage/ObjData")
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
                    pv_cboObject.AddItems(v_strDISPLAY, v_strVALUECD)
                Next
            End If
        Catch ex As Exception

        Finally
            v_XmlDocument = Nothing
        End Try
    End Sub
    Private Sub LoadCFContacts(ByVal pv_strCUSTID As String)
        Try
            If Not ContactsGrid Is Nothing And Len(pv_strCUSTID) > 0 Then
                'Remove cÃ¡c báº£n ghi cÅ©
                ContactsGrid.DataRows.Clear()
                Dim v_strSQL As String = "SELECT MST.AUTOID, CD.CDCONTENT CONTACTTYPE, MST.PERSON, MST.ADDRESS, MST.PHONE, MST.FAX, MST.EMAIL, MST.DESCRIPTION " & _
                    "FROM CFCONTACT MST, ALLCODE CD WHERE " & _
                    "CD.CDTYPE='CF' AND CD.CDNAME='CONTACTTYPE' AND CD.CDVAL=MST.TYPE AND TRIM(MST.CUSTID)='" & pv_strCUSTID & "'"
                Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, MyBase.LocalObject, gc_MsgTypeObj, "CF.CFCONTACT", _
                    gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                'FillDataGrid(ContactsGrid, v_strObjMsg, gc_RootNamespace & "." & Me.Name & "-" & UserLanguage)
                Dim v_strResourceManager As String
                v_strResourceManager = gc_RootNamespace & "." & Me.Name & "-" & UserLanguage

                FillDataGrid(ContactsGrid, v_strObjMsg, v_strResourceManager)
            End If
        Catch ex As Exception
            'MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Sub
    Private Sub LoadCFContracts(ByVal pv_strCUSTID As String)
        Try
            If Not ContactsGrid Is Nothing And Len(pv_strCUSTID) > 0 Then
                'Remove cÃ¡c báº£n ghi cÅ©
                AccountsGrid.DataRows.Clear()
                Dim v_strSQL As String = "SELECT DISTINCT AFACCTNO, CD.CDCONTENT LINKTYPE, MST.MODCODE, MST.SYMBOL, MST.ACCTNO, MST.AFTYPE AFTYPE, AFT.TYPENAME AFTYPE_NAME, Round(MST.AVLBAL)AVLBAL " & _
                    " FROM V_CFCONTRACT MST, ALLCODE CD , AFTYPE AFT  WHERE " & _
                    " AFT.ACTYPE = MST.ACTYPE AND " & _
                    "((MST.AVLBAL >'0' AND MODCODE <> 'CI') OR (MODCODE = 'CI')) AND CD.CDTYPE='CF' AND CD.CDNAME='LINKTYPE' AND CD.CDVAL=MST.LINKTYPE AND TRIM(MST.CUSTID)='" & pv_strCUSTID & "' " & _
                    "ORDER BY AFACCTNO, MODCODE "
                Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, MyBase.LocalObject, gc_MsgTypeObj, "CF.CFMAST", _
                    gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                'FillDataGrid(ContactsGrid, v_strObjMsg, gc_RootNamespace & "." & Me.Name & "-" & UserLanguage)
                FillDataGrid(AccountsGrid, v_strObjMsg, "")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub
    Private Sub LoadLNLimitMax(ByVal pv_strCUSTID As String)
        Try
            If Not LNLimitBankingGrid Is Nothing And Len(pv_strCUSTID) > 0 Then
                'Remove cÃ¡c báº£n ghi cÅ©
                LNLimitBankingGrid.DataRows.Clear()
                Dim v_strSQL As String = "SELECT CFL.CUSTID CFCUSTID, CF.FULLNAME CFFULLNAME, CFL.LMAMT CFLIMIT, c1.cdcontent CFLMCHKTYP, c2.cdcontent CFLMSUBTYPE, c3.cdcontent CFLMTYP " & ControlChars.CrLf _
                        & "FROM CFMAST CF,CFLIMITEXT CFL, ALLCODE C1, ALLCODE C2, ALLCODE C3 " & ControlChars.CrLf _
                        & "WHERE CF.CUSTID=CFL.CUSTID AND TRIM(CFL.BANKID)='" & pv_strCUSTID & "'  " & ControlChars.CrLf _
                        & "and c1.cdtype = 'CF' and c1.cdname = 'LMCHKTYP' and c1.cdval = CFL.LMCHKTYP " & ControlChars.CrLf _
                        & "and c2.cdtype = 'CF' and c2.cdname = 'LMSUBTYPE' and c2.cdval = CFL.LMSUBTYPE " & ControlChars.CrLf _
                        & "and c3.cdtype = 'CF' and c3.cdname = 'LMTYP' and c3.cdval = CFL.LMTYP " & ControlChars.CrLf _
                        & "ORDER BY CF.CUSTID "
                Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, "CF.CFMAST", _
                    gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                'FillDataGrid(ContactsGrid, v_strObjMsg, gc_RootNamespace & "." & Me.Name & "-" & UserLanguage)
                FillDataGrid(LNLimitBankingGrid, v_strObjMsg, "")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub
    Private Sub LoadCFIssuer(ByVal pv_strCUSTID As String)
        Try
            If Not ContactsGrid Is Nothing And Len(pv_strCUSTID) > 0 Then
                'Remove cÃ¡c báº£n ghi cÅ©
                MemberGrid.DataRows.Clear()
                Dim v_strSQL As String = "SELECT I.AUTOID,I.ISSUERID ,I.CUSTID ,ISS.FULLNAME,A0.CDCONTENT ROLECD,I.IDPLACE ,I.IDDATE ,I.IDEXPIRED ,I.LICENSENO,I.DESCRIPTION   FROM ISSUER_MEMBER I ,ALLCODE A0 ,ISSUERS ISS WHERE ISS.ISSUERID =I.ISSUERID AND A0.CDTYPE = 'SA' AND A0.CDNAME = 'ROLECD' AND A0.CDVAL= ROLECD and I.CUSTID = '" & pv_strCUSTID & "'"
                Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, MyBase.LocalObject, gc_MsgTypeObj, "CF.CFMAST", _
                    gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                'FillDataGrid(ContactsGrid, v_strObjMsg, gc_RootNamespace & "." & Me.Name & "-" & UserLanguage)
                FillDataGrid(MemberGrid, v_strObjMsg, "")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LoadCFSign(ByVal pv_strCUSTID As String)
        Try
            Cursor.Current = Cursors.WaitCursor

            Dim v_strSQL As String = "SELECT SIG.AUTOID,SIG.CUSTID,SIG.SIGNATURE,SIG.VALDATE,SIG.EXPDATE FROM CFSIGN SIG, SYSVAR SYS WHERE TRIM(SIG.CUSTID)='" & pv_strCUSTID & "'" _
            & " AND sys.varname = 'CURRDATE' AND grname = 'SYSTEM' " _
            & "  order by autoid desc"
            Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, MyBase.LocalObject, gc_MsgTypeObj, "CF.CFSIGN", _
                gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)

            Dim v_xmlDoc As New XmlDocument
            v_xmlDoc.LoadXml(v_strObjMsg)
            Dim v_xmlNodeList As XmlNodeList = v_xmlDoc.SelectNodes("/ObjectMessage/ObjData")
            Dim v_xmlEntry As XmlNode

            ReDim mv_arrAUTOID(v_xmlNodeList.Count - 1)
            ReDim mv_arrSIGNATURE(v_xmlNodeList.Count - 1)
            ReDim mv_arrCUSTID(v_xmlNodeList.Count - 1)
            ReDim mv_arrVALDATE(v_xmlNodeList.Count - 1)
            ReDim mv_arrEXPDATE(v_xmlNodeList.Count - 1)

            Dim v_strFLDNAME As String = String.Empty
            Dim v_strValue As String = String.Empty

            For i As Integer = 0 To v_xmlNodeList.Count - 1
                For j As Integer = 0 To v_xmlNodeList.Item(i).ChildNodes.Count - 1
                    With v_xmlNodeList.Item(i).ChildNodes(j)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strValue = .InnerText.ToString
                        Select Case Trim(v_strFLDNAME)
                            Case "AUTOID"
                                mv_arrAUTOID(i) = Trim(v_strValue)
                            Case "CUSTID"
                                mv_arrCUSTID(i) = Trim(v_strValue)
                            Case "SIGNATURE"
                                mv_arrSIGNATURE(i) = Trim(v_strValue)
                            Case "VALDATE"
                                mv_arrVALDATE(i) = Trim(v_strValue)
                            Case "EXPDATE"
                                mv_arrEXPDATE(i) = Trim(v_strValue)
                        End Select
                    End With
                Next
            Next

            'dtpVALDATE.Text = mv_arrVALDATE(mv_intCurrImageIndex)
            'dtpEXPDATE.Text = mv_arrEXPDATE(mv_intCurrImageIndex)

            If mv_arrSIGNATURE.Length > 0 Then
                CType(dtpVALDATE, DateTimePicker).Checked = True
                CType(dtpVALDATE, DateTimePicker).Value = mv_arrVALDATE(mv_intCurrImageIndex)
                CType(dtpVALDATE, DateTimePicker).Text = mv_arrVALDATE(mv_intCurrImageIndex)
                CType(dtpEXPDATE, DateTimePicker).Checked = True
                CType(dtpEXPDATE, DateTimePicker).Value = mv_arrEXPDATE(mv_intCurrImageIndex)
                CType(dtpEXPDATE, DateTimePicker).Text = mv_arrEXPDATE(mv_intCurrImageIndex)
                'dtpVALDATE.Value = CDate(mv_arrVALDATE(mv_intCurrImageIndex))
                'dtpEXPDATE.Value = CDate(mv_arrEXPDATE(mv_intCurrImageIndex))

                'CType(dtpVALDATE, DateTimePicker).Checked = True
                'CType(dtpVALDATE, DateTimePicker).Value = CDate(Trim(mv_arrVALDATE(mv_intCurrImageIndex)))

                'CType(dtpEXPDATE, DateTimePicker).Checked = True
                'CType(dtpEXPDATE, DateTimePicker).Value = CDate(Trim(mv_arrEXPDATE(mv_intCurrImageIndex)))

                mv_ImageViewer.Image = GetImageFromString(mv_arrSIGNATURE(mv_intCurrImageIndex))
            Else
                mv_ImageViewer.Image = Nothing
                mv_ImageViewer.Refresh()
            End If
            Cursor.Current = Cursors.Default

        Catch ex As Exception
            'MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub LoadCFRelation(ByVal pv_strCUSTID As String)
        Try
            If Not RelationGrid Is Nothing And Len(pv_strCUSTID) > 0 Then
                'Remove cÃ¡c báº£n ghi cÅ©
                RelationGrid.DataRows.Clear()
                Dim v_strSQL As String = "SELECT RE.AUTOID,RE.CUSTID,RE.RECUSTID, CD.CDCONTENT RETYPE,RE.DESCRIPTION, " & _
                    " CFRE.FULLNAME,CFRE.IDCODE LICENSENO , CFRE.ADDRESS,CFRE.PHONE TELEPHONE,CFRE.IDPLACE LNPLACE , CFRE.IDDATE LNIDDATE " & _
                    " FROM CFRELATION RE, ALLCODE CD,CFMAST CFRE WHERE TRIM(RE.recustid)= CFRE.CUSTID " & _
                    " AND CD.CDTYPE='CF' AND CD.CDNAME='RETYPE' AND trim(CD.CDVAL)=trim(RE.RETYPE) AND TRIM(RE.CUSTID)='" & pv_strCUSTID & "'"
                Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, MyBase.LocalObject, gc_MsgTypeObj, "CF.CFCONTACT", _
                    gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                'FillDataGrid(ContactsGrid, v_strObjMsg, gc_RootNamespace & "." & Me.Name & "-" & UserLanguage)
                FillDataGrid(RelationGrid, v_strObjMsg, "")
            End If
        Catch ex As Exception
            'MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub LoadLMMAST(ByVal pv_strCUSTID As String)
        Try
            If Not LimitGrid Is Nothing And Len(pv_strCUSTID) > 0 Then
                'Remove cac ban ghi cu
                LimitGrid.DataRows.Clear()
                Dim v_strSQL As String = "SELECT ACCTNO, SHORTCD, APPRLIMIT, OPERLIMIT FROM LMMAST LM, SBCURRENCY SB " & _
                                    "WHERE LM.CCYCD = SB.CCYCD AND CUSTID = '" & pv_strCUSTID & "'"
                Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, MyBase.LocalObject, gc_MsgTypeObj, "LM.LMMAST", _
                    gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                'FillDataGrid(ContactsGrid, v_strObjMsg, gc_RootNamespace & "." & Me.Name & "-" & UserLanguage)
                FillDataGrid(LimitGrid, v_strObjMsg, "")
            End If
        Catch ex As Exception
            'MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub LoadLNMAST(ByVal pv_strCUSTID As String)
        Try
            If Not LoanGrid Is Nothing And Len(pv_strCUSTID) > 0 Then
                'Remove cac ban ghi cu
                LoanGrid.DataRows.Clear()
                Dim v_strSQL As String = "SELECT LN.APPLID, ACCTNO, LN.APRLIMIT, RLSAMT, PRINNML, PRINPAID, PRINOVD " & _
                                    "FROM LNAPPL LA, LNMAST LN WHERE LA.CUSTID = '" & pv_strCUSTID & "' AND LA.APPLID = LN.APPLID"
                Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, MyBase.LocalObject, gc_MsgTypeObj, "LN.LNMAST", _
                    gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                'FillDataGrid(ContactsGrid, v_strObjMsg, gc_RootNamespace & "." & Me.Name & "-" & UserLanguage)
                FillDataGrid(LoanGrid, v_strObjMsg, "")
            End If
        Catch ex As Exception
            'MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub ShowContactEvent(ByVal sender As System.Object)

        Try
            Dim v_objCFCONTACT As New frmCFCONTACT
            'Assign properties to CFCONTACT form
            v_objCFCONTACT.ObjectName = OBJNAME_CF_CFCONTACT
            v_objCFCONTACT.TellerId = TellerId
            v_objCFCONTACT.BranchId = BranchId
            v_objCFCONTACT.CustomerId = Trim(txtCUSTID.Text)
            v_objCFCONTACT.LocalObject = LocalObject
            v_objCFCONTACT.UserLanguage = UserLanguage
            v_objCFCONTACT.ModuleCode = ModuleCode

            If Not (sender Is btnCADD) Then
                v_objCFCONTACT.KeyFieldName = "AUTOID"
                v_objCFCONTACT.KeyFieldType = "N"
                v_objCFCONTACT.KeyFieldValue = Trim(CType(ContactsGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value)
                v_objCFCONTACT.TableName = "CFCONTACT"
            End If

            If (sender Is btnCADD) Then
                v_objCFCONTACT.ExeFlag = ExecuteFlag.AddNew
            ElseIf (sender Is btnCVIEW) Then
                v_objCFCONTACT.ExeFlag = ExecuteFlag.View

            ElseIf (sender Is btnCEDIT) Then
                v_objCFCONTACT.ExeFlag = ExecuteFlag.Edit


            ElseIf (sender Is btnCDEL) Then
                v_objCFCONTACT.ExeFlag = ExecuteFlag.Delete


            End If

            'AnhVT Added - Maintenance Retroed
            v_objCFCONTACT.ParentObjName = Me.ObjectName
            v_objCFCONTACT.ParentClause = KeyFieldName & " = '" & txtCUSTID.Text & "'"
            v_objCFCONTACT.TellerId = TellerId
            'AnhVT Ended
            'Show CFCONTACT form
            v_objCFCONTACT.ShowDialog()

        Catch ex As Exception

        End Try
    End Sub

    Protected Overridable Function OnSearchContact(Optional ByVal pv_strIsLocal As String = "", Optional ByVal pv_strModule As String = "") As Int32
        Try
            'Update mouse pointer
            Cursor.Current = Cursors.WaitCursor

            If (pv_strIsLocal <> "") And (pv_strModule <> "") Then
                Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, pv_strIsLocal, gc_MsgTypeObj, pv_strModule, _
                    gc_ActionInquiry)

                v_ws.Message(v_strObjMsg)

                'Fill data into search grid
                Dim v_strResourceManager As String
                v_strResourceManager = gc_RootNamespace & "." & Me.Name & "-" & UserLanguage
                FillDataGrid(ContactsGrid, v_strObjMsg, v_strResourceManager, TableName)
            End If

            'Update mouse pointer
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function

    Protected Overridable Function OnDeleteContact(Optional ByVal pv_strIsLocal As String = "", Optional ByVal pv_strModule As String = "") As Int32
        Dim v_strKeyFieldName, v_strKeyFieldValue As String
        Dim v_strClause As String

        'AnhVT Added - Maintenance Retroed
        Dim ParentObjName As String = Me.ObjectName
        Dim ParentClause As String = KeyFieldName & " = '" & txtCUSTID.Text & "'"
        'AnhVT Ended

        Try
            If MsgBox(ResourceManager.GetString("DelConfirm"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                'Update mouse pointer
                Cursor.Current = Cursors.WaitCursor

                If (pv_strIsLocal <> "") And (pv_strModule <> "") Then
                    If Not (ContactsGrid.CurrentRow Is Nothing) Then
                        'If Not (ContactsGrid.CurrentRow Is ContactsGrid.FixedFooterRows.Item(0)) Then
                        v_strKeyFieldName = CType(ContactsGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").FieldName
                        v_strKeyFieldValue = CType(ContactsGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value

                        v_strClause = v_strKeyFieldName & " = " & v_strKeyFieldValue

                        Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, pv_strIsLocal, gc_MsgTypeObj, pv_strModule, gc_ActionDelete, , v_strClause, , , , , , , , ParentObjName, ParentClause)
                        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                        Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)

                        'Kiá»ƒm tra thÃ´ng tin vÃ  xá»­ lÃ½ lá»—i (náº¿u cÃ³) tá»« message tráº£ vá»?
                        Dim v_strErrorSource, v_strErrorMessage As String

                        GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                        If v_lngErrorCode <> 0 Then
                            'Update mouse pointer
                            Cursor.Current = Cursors.Default
                            MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                            Exit Function
                        End If

                        'Remove dÃ²ng dá»¯ liá»‡u Ä‘Ã£ xoÃ¡ khá»?i grid
                        ContactsGrid.CurrentRow.Remove()
                    Else
                        'Update mouse pointer
                        Cursor.Current = Cursors.Default
                        MsgBox(ResourceManager.GetString("frmSearch.NotSelected"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
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
        End Try
    End Function
    Protected Overridable Function OnDeleteIssuer(Optional ByVal pv_strIsLocal As String = "", Optional ByVal pv_strModule As String = "") As Int32
        Dim v_strKeyFieldName, v_strKeyFieldValue As String
        Dim v_strClause As String

        'AnhVT Added - Maintenance Retroed
        Dim ParentObjName As String = Me.ObjectName
        Dim ParentClause As String = KeyFieldName & " = '" & txtCUSTID.Text & "'"
        'AnhVT Ended

        Try
            If MsgBox(ResourceManager.GetString("DelConfirm"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                'Update mouse pointer
                Cursor.Current = Cursors.WaitCursor

                If (pv_strIsLocal <> "") And (pv_strModule <> "") Then
                    If Not (MemberGrid.CurrentRow Is Nothing) Then
                        'If Not (ContactsGrid.CurrentRow Is ContactsGrid.FixedFooterRows.Item(0)) Then
                        v_strKeyFieldName = CType(MemberGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").FieldName
                        v_strKeyFieldValue = CType(MemberGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value

                        v_strClause = v_strKeyFieldName & " = " & v_strKeyFieldValue

                        Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, pv_strIsLocal, gc_MsgTypeObj, pv_strModule, gc_ActionDelete, , v_strClause, , , , , , , , ParentObjName, ParentClause)
                        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                        Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)

                        'Kiá»ƒm tra thÃ´ng tin vÃ  xá»­ lÃ½ lá»—i (náº¿u cÃ³) tá»« message tráº£ vá»?
                        Dim v_strErrorSource, v_strErrorMessage As String

                        GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                        If v_lngErrorCode <> 0 Then
                            'Update mouse pointer
                            Cursor.Current = Cursors.Default
                            MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                            Exit Function
                        End If

                        'Remove dÃ²ng dá»¯ liá»‡u Ä‘Ã£ xoÃ¡ khá»?i grid
                        MemberGrid.CurrentRow.Remove()
                    Else
                        'Update mouse pointer
                        Cursor.Current = Cursors.Default
                        '  MsgBox(ResourceManager.GetString("frmSearch.NotSelected"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, Me.Text)
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
        End Try
    End Function


    Protected Overridable Function OnDeleterelation(Optional ByVal pv_strIsLocal As String = "", Optional ByVal pv_strModule As String = "") As Int32
        Dim v_strKeyFieldName, v_strKeyFieldValue As String
        Dim v_strClause As String

        'AnhVT Added - Maintenance Retroed
        Dim ParentObjName As String = Me.ObjectName
        Dim ParentClause As String = KeyFieldName & " = '" & txtCUSTID.Text & "'"
        'AnhVT Ended

        Try
            If MsgBox(ResourceManager.GetString("DelConfirm"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                'Update mouse pointer
                Cursor.Current = Cursors.WaitCursor

                If (pv_strIsLocal <> "") And (pv_strModule <> "") Then
                    If Not (RelationGrid.CurrentRow Is Nothing) Then
                        'If Not (ContactsGrid.CurrentRow Is ContactsGrid.FixedFooterRows.Item(0)) Then
                        v_strKeyFieldName = CType(RelationGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").FieldName
                        v_strKeyFieldValue = CType(RelationGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value

                        v_strClause = v_strKeyFieldName & " = " & v_strKeyFieldValue

                        Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, pv_strIsLocal, gc_MsgTypeObj, pv_strModule, gc_ActionDelete, , v_strClause, , , , , , , , ParentObjName, ParentClause)
                        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                        Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)

                        'Kiá»ƒm tra thÃ´ng tin vÃ  xá»­ lÃ½ lá»—i (náº¿u cÃ³) tá»« message tráº£ vá»?
                        Dim v_strErrorSource, v_strErrorMessage As String

                        GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                        If v_lngErrorCode <> 0 Then
                            'Update mouse pointer
                            Cursor.Current = Cursors.Default
                            MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                            Exit Function
                        End If
                        'Remove dÃ²ng dá»¯ liá»‡u Ä‘Ã£ xoÃ¡ khá»?i grid
                        RelationGrid.CurrentRow.Remove()
                    Else
                        'Update mouse pointer
                        Cursor.Current = Cursors.Default
                        MsgBox(ResourceManager.GetString("frmSearch.NotSelected"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
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
        End Try
    End Function


    'Xoa Sign tuong ung voi KH
    Public Sub showFormRELATION(ByVal pv_intExecFlag As Integer)
        Try
            Dim v_frm As Object
            v_frm = New frmCFRELATION
            v_frm.BranchId = BranchId
            v_frm.ExeFlag = pv_intExecFlag
            v_frm.UserLanguage = UserLanguage
            v_frm.ModuleCode = ModuleCode
            v_frm.ObjectName = "CF.CFRELATION"
            v_frm.TableName = "CFRELATION"
            v_frm.LocalObject = "N"
            v_frm.Text = "" 'Lay tu resource
            v_frm.CustomerId = Trim(Me.txtCUSTID.Text)
            v_frm.busdate = Me.BusDate
            'v_strKeyFieldName = CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells(mv_strKeyColumn).FieldName
            'v_strKeyFieldValue = CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells(mv_strKeyColumn).Value
            If Not (pv_intExecFlag = ExecuteFlag.AddNew) Then
                v_frm.KeyFieldName = "AUTOID"
                v_frm.KeyFieldType = "N"
                v_frm.KeyFieldValue = Trim(CType(RelationGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value)
                ' v_frm.mv_CustomerName = Trim(CType(RelationGrid.CurrentRow, Xceed.Grid.DataRow).Cells("NAME").Value)
            End If

            If (pv_intExecFlag = ExecuteFlag.AddNew) Then
                v_frm.ExeFlag = ExecuteFlag.AddNew
            ElseIf (pv_intExecFlag = ExecuteFlag.View) Then
                v_frm.ExeFlag = ExecuteFlag.View

            ElseIf (pv_intExecFlag = ExecuteFlag.Edit) Then
                v_frm.ExeFlag = ExecuteFlag.Edit

            ElseIf (pv_intExecFlag = ExecuteFlag.Delete) Then
                v_frm.ExeFlag = ExecuteFlag.Delete
            End If

            'AnhVT Added - Maintenance Retroed
            v_frm.ParentObjName = Me.ObjectName
            v_frm.ParentClause = KeyFieldName & " = '" & txtCUSTID.Text & "'"
            v_frm.TellerId = TellerId
            'AnhVT Ended
            v_frm.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Public Sub showFormLMMAST(ByVal pv_intExecFlag As Integer)
        Try
            Dim v_strKeyValue As String = Trim(CType(LimitGrid.CurrentRow, Xceed.Grid.DataRow).Cells("ACCTNO").Value)
            Dim v_strTableName As String = "LMMAST"
            Dim v_strModuleCode As String = "LM"
            Dim v_strObjName As String = "LM.LMMAST"

            Dim v_frm As New frmMaster(v_strTableName, pv_intExecFlag, UserLanguage, v_strModuleCode, v_strObjName, gc_IsNotLocalMsg, _
                                        "", TellerId, TellerRight, GroupCareBy, AuthString, BranchId, BusDate, "ACCTNO", _
                                        KeyFieldType, v_strKeyValue, LinkValue, Me.LinkField, "", Me.ObjectName, Me.ModuleCode, Me.mv_arrObjFields)
            Dim frmResult As DialogResult = v_frm.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Public Sub showFormLNMAST(ByVal pv_intExecFlag As Integer)
        Try
            Dim v_strKeyValue As String = Trim(CType(LoanGrid.CurrentRow, Xceed.Grid.DataRow).Cells("ACCTNO").Value)
            Dim v_strTableName As String = "LNMAST"
            Dim v_strModuleCode As String = "LN"
            Dim v_strObjName As String = "LN.LNMAST"

            Dim v_frm As New frmMaster(v_strTableName, pv_intExecFlag, UserLanguage, v_strModuleCode, v_strObjName, gc_IsNotLocalMsg, _
                                        "", TellerId, TellerRight, GroupCareBy, AuthString, BranchId, BusDate, "ACCTNO", _
                                        KeyFieldType, v_strKeyValue, LinkValue, Me.LinkField, "", Me.ObjectName, Me.ModuleCode, Me.mv_arrObjFields)
            Dim frmResult As DialogResult = v_frm.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Public Sub showFormISSUER(ByVal pv_intExecFlag As Integer)
        Try
            Dim v_frm As frmISSUER_MEMBER
            v_frm = New frmISSUER_MEMBER
            v_frm.ExeFlag = pv_intExecFlag
            v_frm.UserLanguage = UserLanguage
            v_frm.ModuleCode = "SA"
            v_frm.ObjectName = "SA.ISSUER_MEMBER"
            v_frm.TableName = "ISSUER_MEMBER"
            v_frm.LocalObject = "N"
            v_frm.BusDate = Me.BusDate
            v_frm.Text = "" 'Lay tu resource
            v_frm.CUSTID = Trim(Me.txtCUSTID.Text)
            'v_strKeyFieldName = CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells(mv_strKeyColumn).FieldName
            'v_strKeyFieldValue = CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells(mv_strKeyColumn).Value
            If Not (pv_intExecFlag = ExecuteFlag.AddNew) Then
                v_frm.KeyFieldName = "AUTOID"
                v_frm.KeyFieldType = "N"
                v_frm.KeyFieldValue = Trim(CType(MemberGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value)
            End If

            If (pv_intExecFlag = ExecuteFlag.AddNew) Then
                v_frm.ExeFlag = ExecuteFlag.AddNew
                'v_frm.v_strSYMBOL = Me.txtSYMBOL.Text
                'v_frm.v_strCODEID = Me.txtCODEID.Text

            ElseIf (pv_intExecFlag = ExecuteFlag.View) Then
                v_frm.ExeFlag = ExecuteFlag.View

            ElseIf (pv_intExecFlag = ExecuteFlag.Edit) Then
                v_frm.ExeFlag = ExecuteFlag.Edit

            ElseIf (pv_intExecFlag = ExecuteFlag.Delete) Then
                v_frm.ExeFlag = ExecuteFlag.Delete
            End If

            'AnhVT Added - Maintenance Retroed
            v_frm.ParentObjName = Me.ObjectName
            v_frm.ParentClause = KeyFieldName & " = '" & txtCUSTID.Text & "'"
            v_frm.TellerId = TellerId
            'AnhVT Ended
            v_frm.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " Control validations "
    Private Function ControlValidation(Optional ByVal pv_blnSaved As Boolean = False) As Boolean
        Try
            If pv_blnSaved Then
                If Me.cboSTAFF.SelectedValue = STAFF_ISSUER_EMPLOYEE Then
                    If (txtISSUERID.Text.Trim() = "") Then
                        MessageBox.Show(ResourceManager.GetString("ISSUERIDEMPTY"))
                        Return False
                    End If
                End If

                If DDMMYYYY_SystemDate(Me.dtpIDDATE.Text.Trim) > DDMMYYYY_SystemDate(BusDate) Then
                    MessageBox.Show(ResourceManager.GetString("IDDATEOVERBUSDATE"))
                    Return False
                End If

                If DDMMYYYY_SystemDate(Me.dtpIDEXPIRED.Text.Trim) <= DDMMYYYY_SystemDate(BusDate) Then
                    If MessageBox.Show(ResourceManager.GetString("IDEXPIREDLESSTHANBUSDATE"), Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) <> Windows.Forms.DialogResult.OK Then
                        Return False
                    End If
                End If

                Return MyBase.VerifyRules
            End If

            Return True
        Catch ex As Exception
            Throw ex
            Return False
        End Try
    End Function
#End Region

#Region " Form events "
    Private Sub btnADDISSUER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnADDISSUER.Click
        showFormISSUER(ExecuteFlag.AddNew)
        LoadCFIssuer(Me.txtCUSTID.Text)
    End Sub
    Private Sub btnVIEWISSUER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVIEWISSUER.Click
        showFormISSUER(ExecuteFlag.View)
        LoadCFIssuer(Me.txtCUSTID.Text)
    End Sub
    Private Sub btnEDITISSUER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEDITISSUER.Click
        showFormISSUER(ExecuteFlag.Edit)
        LoadCFIssuer(Me.txtCUSTID.Text)
    End Sub
    Private Sub btnDELISSUER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDELISSUER.Click
        OnDeleteIssuer(gc_IsNotLocalMsg, "SA.ISSUER_MEMBER")
        LoadCFIssuer(Me.txtCUSTID.Text)
    End Sub
    Private Sub btnCADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCADD.Click
        ShowContactEvent(btnCADD)
        LoadCFContacts(CStr(txtCUSTID.Text))
        'OnSearchContact(gc_IsLocalMsg, ModuleCode & ".CFCONTACT")
    End Sub


    Private Sub btnCVIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCVIEW.Click
        ShowContactEvent(btnCVIEW)
        LoadCFContacts(CStr(txtCUSTID.Text))
    End Sub

    Private Sub btnCEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCEDIT.Click
        ShowContactEvent(btnCEDIT)
        LoadCFContacts(CStr(txtCUSTID.Text))
    End Sub

    Private Sub btnCDEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCDEL.Click
        OnDeleteContact(gc_IsNotLocalMsg, ModuleCode & ".CFCONTACT")
    End Sub
    Private Sub btnRADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRADD.Click
        showFormRELATION(ExecuteFlag.AddNew)
        LoadCFRelation(CStr(txtCUSTID.Text))
    End Sub

    Private Sub btnRVIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRVIEW.Click
        showFormRELATION(ExecuteFlag.View)
        LoadCFRelation(CStr(txtCUSTID.Text))
    End Sub
    Private Sub btnREDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnREDIT.Click
        showFormRELATION(ExecuteFlag.Edit)
        LoadCFRelation(CStr(txtCUSTID.Text))
    End Sub
    Private Sub btnRDEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRDEL.Click
        OnDeleterelation(gc_IsNotLocalMsg, ModuleCode & ".CFRELATION")
        LoadCFRelation(CStr(txtCUSTID.Text))
    End Sub
    Private Sub btnLMVIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLMVIEW.Click
        showFormLMMAST(ExecuteFlag.View)
        LoadLMMAST(CStr(txtCUSTID.Text))
    End Sub
    Private Sub btnLNVIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLNVIEW.Click
        showFormLNMAST(ExecuteFlag.View)
        LoadLNMAST(CStr(txtCUSTID.Text))
    End Sub

    Private Sub btnGETCUSTID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGETCUSTID.Click
        Select Case ExeFlag
            Case ExecuteFlag.AddNew
                'Kiem tra xem ma tu sinh
                While (1 = 1)
                    Dim v_strCustIDTemp = getCustID(BranchId)
                    If CheckCustID(v_strCustIDTemp) Then
                        Me.txtCUSTID.Text = v_strCustIDTemp
                        Exit While
                    End If
                End While
        End Select

    End Sub
    Private Sub ShowSignEvent(ByVal pv_intExecFlag As Integer)
        Try
            Dim v_objCustSign As New frmCFSIGN
            v_objCustSign.TableName = "CFSIGN"
            v_objCustSign.ObjectName = OBJNAME_CF_CFSIGN
            v_objCustSign.TellerId = TellerId
            v_objCustSign.BranchId = BranchId
            v_objCustSign.LocalObject = MyBase.LocalObject
            v_objCustSign.UserLanguage = UserLanguage
            v_objCustSign.ModuleCode = ModuleCode
            v_objCustSign.BusDate = Me.BusDate
            v_objCustSign.CustID = txtCUSTID.Text
            'AnhVT Added - Maintenance Retroed
            v_objCustSign.ParentObjName = Me.ObjectName
            v_objCustSign.ParentClause = KeyFieldName & " = '" & txtCUSTID.Text & "'"
            v_objCustSign.TellerId = TellerId
            'AnhVT Ended

            If Not (pv_intExecFlag = ExecuteFlag.AddNew) Then
                v_objCustSign.KeyFieldName = "AUTOID"
                v_objCustSign.KeyFieldType = "N"
                v_objCustSign.KeyFieldValue = mv_arrAUTOID(mv_intCurrImageIndex)
                v_objCustSign.AUTOID = mv_arrAUTOID(mv_intCurrImageIndex)

                'Phuong Added
                v_objCustSign.txtBROWSER.Enabled = False
                v_objCustSign.btnBROWSER.Enabled = False
                'Phuong End

            End If

            If (pv_intExecFlag = ExecuteFlag.AddNew) Then
                v_objCustSign.ExeFlag = ExecuteFlag.AddNew
            ElseIf (pv_intExecFlag = ExecuteFlag.View) Then
                v_objCustSign.ExeFlag = ExecuteFlag.View
            ElseIf (pv_intExecFlag = ExecuteFlag.Edit) Then
                v_objCustSign.ExeFlag = ExecuteFlag.Edit
            ElseIf (pv_intExecFlag = ExecuteFlag.Delete) Then
                v_objCustSign.ExeFlag = ExecuteFlag.Delete
            End If


            v_objCustSign.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSADD.Click
        ' Neu thong tin khach hang da duoc ghi vao CFMAST thi moi cho phep them chu ky.
        If Not (CheckCustID(Me.txtCUSTID.Text.Trim)) Then
            ShowSignEvent(ExecuteFlag.AddNew)
            LoadCFSign(CStr(txtCUSTID.Text))
        Else
            MsgBox(ResourceManager.GetString("msgCANNOTADDSIGN"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
            Exit Sub
        End If

    End Sub

    Protected Overridable Function OnDeleteSignature(Optional ByVal pv_strIsLocal As String = "", Optional ByVal pv_strModule As String = "") As Int32
        Dim v_strKeyFieldName, v_strKeyFieldValue As String
        Dim v_strClause As String

        'AnhVT Added - Maintenance Retroed
        Dim ParentObjName As String = Me.ObjectName
        Dim ParentClause As String = KeyFieldName & " = '" & txtCUSTID.Text & "'"
        'AnhVT Ended

        Try
            If MsgBox(ResourceManager.GetString("DelConfirm"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                'Update mouse pointer
                Cursor.Current = Cursors.WaitCursor

                If (pv_strIsLocal <> "") And (pv_strModule <> "") Then
                    If (mv_arrAUTOID.Length > 0) Then

                        v_strKeyFieldName = "AUTOID"
                        v_strKeyFieldValue = mv_arrAUTOID(mv_intCurrImageIndex)
                        v_strClause = v_strKeyFieldName & " = " & v_strKeyFieldValue

                        Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, pv_strIsLocal, gc_MsgTypeObj, pv_strModule, gc_ActionDelete, , v_strClause, , , , , , , , ParentObjName, ParentClause)
                        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                        Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)

                        'Kiá»ƒm tra thÃ´ng tin vÃ  xá»­ lÃ½ lá»—i (náº¿u cÃ³) tá»« message tráº£ vá»?
                        Dim v_strErrorSource, v_strErrorMessage As String

                        GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                        If v_lngErrorCode <> 0 Then
                            Cursor.Current = Cursors.Default
                            MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                            Exit Function
                        End If
                        mv_intCurrImageIndex = 0 'Tro ve ban dau
                    End If
                End If
                Cursor.Current = Cursors.Default
                MsgBox(ResourceManager.GetString("DelSuccess"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function

    Private Sub btnSDEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSDEL.Click
        OnDeleteSignature(gc_IsNotLocalMsg, ModuleCode & ".CFSIGN")
        LoadCFSign(CStr(txtCUSTID.Text))
    End Sub

    Private Sub btnSVIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSVIEW.Click
        ShowSignEvent(ExecuteFlag.View)
    End Sub

    Private Sub btnSEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSEDIT.Click
        ShowSignEvent(ExecuteFlag.Edit)
        LoadCFSign(CStr(txtCUSTID.Text))
    End Sub

    Private Sub btnNEXT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNEXT.Click
        If mv_intCurrImageIndex < mv_arrSIGNATURE.Length - 1 Then
            mv_intCurrImageIndex += 1
            LoadCFSign(CStr(txtCUSTID.Text))
        End If
    End Sub

    Private Sub btnPREVIOUS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPREVIOUS.Click
        If mv_intCurrImageIndex > 0 Then
            mv_intCurrImageIndex -= 1

            LoadCFSign(CStr(txtCUSTID.Text))
        End If
    End Sub
    Private Function getCustID(ByVal BranchID As String) As String
        Dim v_strClause, v_strAutoID As String
        Dim v_int, v_intCount As Integer
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strFLDNAME, v_strVALUE As String
        'Láº¥y ra sá»‘ tá»± tÄƒng
        'v_strClause = "SEQ_CFMAST"
        v_strClause = "CUSTID"
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_wsBDS As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        'Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchID, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_strClause, "GetInventory")
        Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchID, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_strClause, "GetInventory")
        v_wsBDS.Message(v_strObjMsg)
        v_xmlDocument.LoadXml(v_strObjMsg)
        v_strAutoID = v_xmlDocument.DocumentElement.Attributes("CLAUSE").Value
        v_strAutoID = Me.BranchId & Strings.Right("000000" & CStr(v_strAutoID), Len("000000"))
        Return v_strAutoID
    End Function

    Private Function CheckCustID(ByVal strCustID As String) As Boolean
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_int, v_intCount As Integer
        Dim v_strCDCONTENT, v_strCCUSTID As String
        Dim v_strFLDNAME, v_strVALUE As String
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Dim v_strCmdInquiry As String = "Select count(CUSTID) CCUSTID  from CFMAST where CUSTID = '" & strCustID & "'"
        Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, "SA.ALLCODE", gc_ActionInquiry, v_strCmdInquiry)
        v_ws.Message(v_strObjMsg)
        v_xmlDocument.LoadXml(v_strObjMsg)
        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
        For v_intCount = 0 To v_nodeList.Count - 1
            For v_int = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                    v_strFLDNAME = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("fldname").Value.Trim()
                    v_strVALUE = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("oldval").Value.Trim()

                    Select Case v_strFLDNAME
                        Case "CCUSTID"
                            v_strCCUSTID = v_strVALUE
                    End Select
                End With
            Next
        Next
        If CDbl(v_strCCUSTID) > 0 Then
            Return False
        Else
            Return True
        End If

    End Function

    Private Function CheckExistsMarginAccount(ByVal strCustID As String) As Boolean
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_int, v_intCount As Integer
        Dim v_strEXISTSVAL As String
        Dim v_strFLDNAME, v_strVALUE As String
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Dim v_strSQL As String
        v_strSQL = "select count(1) EXISTSVAL from afmast af " & ControlChars.CrLf _
            & "where af.status in ('A','B','P') and af.custid = '" & strCustID.Replace(".", "").Replace(",", "") & "' " & ControlChars.CrLf _
            & "and (exists (select 1 from afidtype a, lntype l where af.actype = a.aftype and a.objname = 'LN.LNTYPE' and a.actype = l.actype and l.chksysctrl = 'Y') " & ControlChars.CrLf _
            & "or exists (select 1 from lnmast ln, lntype lnt where ln.trfacctno = af.acctno and ln.actype = lnt.actype and lnt.chksysctrl = 'Y' and prinnml + prinovd > 0) " & ControlChars.CrLf _
            & "or exists (select 1 from aftype aft, lntype lnt where aft.lntype = lnt.actype and af.actype = aft.actype and lnt.chksysctrl = 'Y')) "

        Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_ALLCODE, gc_ActionInquiry, v_strSQL)
        v_ws.Message(v_strObjMsg)
        v_xmlDocument.LoadXml(v_strObjMsg)
        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
        For v_intCount = 0 To v_nodeList.Count - 1
            For v_int = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                    v_strFLDNAME = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("fldname").Value.Trim()
                    v_strVALUE = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("oldval").Value.Trim()

                    Select Case v_strFLDNAME
                        Case "EXISTSVAL"
                            v_strEXISTSVAL = v_strVALUE
                    End Select
                End With
            Next
        Next
        If CDbl(v_strEXISTSVAL) > 0 AndAlso Me.cboMARGINALLOW.SelectedValue = "N" Then
            Return True
        Else
            Return False
        End If

    End Function

    Function GetExperiencecd() As String
        Dim str_Experiencecd As String

        If Me.chkEQUITIES.Checked = True Then
            str_Experiencecd &= 1
        Else
            str_Experiencecd &= 0
        End If

        If Me.chkBOND.Checked = True Then
            str_Experiencecd &= 1
        Else
            str_Experiencecd &= 0
        End If

        If Me.chkFOREX.Checked = True Then
            str_Experiencecd &= 1
        Else
            str_Experiencecd &= 0
        End If

        If Me.chkOTHERS.Checked = True Then
            str_Experiencecd &= 1
        Else
            str_Experiencecd &= 0
        End If

        If Me.chkREALESTATE.Checked = True Then
            str_Experiencecd &= 1
        Else
            str_Experiencecd &= 0
        End If
        Return str_Experiencecd
    End Function

    Private Sub SetExperiencecd(ByVal strExperiencecd As String)
        If strExperiencecd = "" Then
            Exit Sub
        Else
            If strExperiencecd.Length <> 5 Then
                Exit Sub
            Else
                If (Strings.Mid(strExperiencecd, 1, 1)) = 1 Then
                    Me.chkEQUITIES.Checked = True
                Else
                    Me.chkEQUITIES.Checked = False
                End If
                If (Strings.Mid(strExperiencecd, 2, 1)) = 1 Then
                    Me.chkBOND.Checked = True
                Else
                    Me.chkBOND.Checked = False
                End If
                If (Strings.Mid(strExperiencecd, 3, 1)) = 1 Then
                    Me.chkFOREX.Checked = True
                Else
                    Me.chkFOREX.Checked = False
                End If
                If (Strings.Mid(strExperiencecd, 4, 1)) = 1 Then
                    Me.chkOTHERS.Checked = True
                Else
                    Me.chkOTHERS.Checked = False
                End If
                If (Strings.Mid(strExperiencecd, 5, 1)) = 1 Then
                    Me.chkREALESTATE.Checked = True
                Else
                    Me.chkREALESTATE.Checked = False
                End If
            End If
        End If
    End Sub

    'Private Sub frmCFMAST_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
    '    If (Control.ModifierKeys And Keys.Shift) AndAlso e.KeyChar = CChar("I") Then
    '        e.Handled = True
    '        Me.tabRELATION.SelectedTab = Me.tabIDENTIFICATION
    '    End If

    'End Sub
    'Private Sub frmCFMAST_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
    '    If (Control.ModifierKeys And Keys.Control) AndAlso Keys.Tab Then
    '        e.Handled = True
    '        Me.tabRELATION.SelectedTab = Me.tabIDENTIFICATION
    '    End If
    'End Sub

    'Private Sub btnAPPROVE_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    v_strSender = "btnAPPROVE"
    '    OnSubmit()
    '    v_strSender = String.Empty
    '    Me.btnAPPROVE.Enabled = False
    'End Sub
    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click

        v_strSender = "btnApply"
    End Sub

#End Region




    'Private Sub btnREFUSE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    v_strSender = "btnREFUSE"
    '    OnSubmit()
    '    v_strSender = String.Empty
    '    Me.btnREFUSE.Enabled = False
    'End Sub

    'Private Sub btnREJECT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    v_strSender = "btnREJECT"
    '    OnSubmit()
    '    v_strSender = String.Empty
    '    Me.btnREJECT.Enabled = False
    'End Sub

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

    'Private Sub txtMOBILE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtMOBILE.Validating
    '    If (Not IsNumeric(txtMOBILE.Text)) Then
    '        MsgBox(ResourceManager.GetString("MobileNotValid"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
    '        txtMOBILE.Focus()
    '    End If
    'End Sub

    'Private Sub txtPHONE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPHONE.Validating
    '    If (Not IsNumeric(txtPHONE.Text)) Then
    '        MsgBox(ResourceManager.GetString("PhoneNotValid"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
    '        txtPHONE.Focus()
    '    End If
    'End Sub

    Private Sub cboCUSTTYPE_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCUSTTYPE.SelectedValueChanged
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_strCMDSQL, v_strObjMsg, v_strOldIDTYPE As String
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Try
            'Neu la khach hang to chuc thi disbale 
            If (Me.cboCUSTTYPE.SelectedValue.ToString = "B") Then
                Me.cboPOSITION.Visible = False
                Me.lblPOSITION.Visible = False
                Me.cboSEX.Enabled = False
                Me.cboEDUCATION.Enabled = False
                Me.cboMARRIED.Enabled = False
                Me.cboOCCUPATION.Enabled = False
                Me.dtpDATEOFBIRTH.Enabled = False
                Me.lblTAXCODE.ForeColor = Color.Blue
                v_strCMDSQL = "SELECT  A.CDVAL VALUECD, A.CDVAL VALUE, A.CDCONTENT DISPLAY, A.CDCONTENT EN_DISPLAY, A.CDCONTENT DESCRIPTION FROM ALLCODE A WHERE A.CDTYPE='CF' AND A.CDNAME='IDTYPEBUS' ORDER BY A.LSTODR"
            Else
                Me.cboPOSITION.Visible = True
                Me.lblPOSITION.Visible = True
                Me.cboSEX.Enabled = True
                Me.cboEDUCATION.Enabled = True
                Me.cboMARRIED.Enabled = True
                Me.cboOCCUPATION.Enabled = True
                Me.dtpDATEOFBIRTH.Enabled = True
                Me.lblTAXCODE.ForeColor = Color.Blue


                v_strCMDSQL = "SELECT  A.CDVAL VALUECD, A.CDVAL VALUE, A.CDCONTENT DISPLAY, A.CDCONTENT EN_DISPLAY, A.CDCONTENT DESCRIPTION FROM ALLCODE A WHERE A.CDTYPE='CF' AND A.CDNAME='IDTYPEIDV' ORDER BY A.LSTODR"
            End If
            If Me.cboIDTYPE.SelectedValue Is Nothing Then Exit Sub
            v_strOldIDTYPE = Me.cboIDTYPE.SelectedValue.ToString
            'Lay du lieu
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCMDSQL)
            v_ws.Message(v_strObjMsg)
            FillComboEx(v_strObjMsg, Me.cboIDTYPE, "", Me.UserLanguage)
            Me.cboIDTYPE.SelectedValue = v_strOldIDTYPE
            If cboIDTYPE.Items.Count > 0 AndAlso Me.cboIDTYPE.Text = "" Then
                Me.cboIDTYPE.SelectedIndex = 0
            End If
        Catch ex As Exception
            Throw ex
        Finally
            v_ws = Nothing
            v_xmlDocument = Nothing
        End Try
    End Sub


    Private Sub lblTAXCODE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblTAXCODE.Click

    End Sub

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

    Private Sub ExternalUpdate()
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQL, v_strObjMsg, v_strValue, v_strFLDNAME As String
            Dim v_strClause As String = v_strSQL
            v_strObjMsg = BuildXMLObjMsg(Me.BusDate, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionAdhoc, , Replace(Me.txtCUSTID.Text, ".", ""), "ExternalUpdateCFMAST")
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

    Private Sub txtTLID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTLID.LostFocus
        LoadUsernameCareby()
    End Sub

    Private Sub dtpIDDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpIDDATE.Validating
        ' Dim aDate As New Date(Me.dtpIDDATE.Value.Year + 15, Me.dtpIDDATE.Value.Month, Me.dtpIDDATE.Value.Day)
        Dim aDate As Date
        aDate = (Me.dtpIDDATE.Value.AddYears(15))
        Me.dtpIDEXPIRED.Value = aDate
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
End Class

