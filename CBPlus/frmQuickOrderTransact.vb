Imports AppCore
Imports CommonLibrary
Imports System.Xml.XmlNode
Imports System.Xml
Imports TestBase64
Imports ZetaCompressionLibrary
Imports System.IO
Imports System.Windows.Forms
Imports Xceed.SmartUI.Controls
Imports System.Collections
Public Class frmQuickOrderTransact
    Inherits System.Windows.Forms.Form
    Private mv_intCurrImageIndex As Integer = 0
    Private mv_arrSIGNATURE As String()
    Private mv_arrAUTOID As String()
    Private mv_arrCUSTID As String()
    Public mv_blnIsDelete As Boolean = False
    Public mv_blnAmendment As Boolean
    Private mv_blnShowOfficerFunction As Boolean = False
    Public mv_blnIsPTRepo As Boolean = False
    Private mv_strOldRefOrderID As String = String.Empty
    Private mv_strCUSTODYCD As String = String.Empty
    Private mv_dblView_TradeUnit As Double = 1
    'TungNT Added for check user auth
    Private mv_strAuthRights As String = ""

    'End

    Private mv_dblSYSClearday As Double = 3
    Private mv_strPTQTTY100TO5000 As String '03/06/2016 DieuNDA: Them danh sach cac loai CK duoc dat lenh tu 100 den 5000
    Private mv_dblHOMINPTQTTY As Double '11/07/2016 DieuNDA: Them tham so check so luong CK toi thieu cho san HO
    Private mv_dblHAMINPTQTTY As Double '11/07/2016 DieuNDA: Them tham so check so luong CK toi thieu cho san HA
    Private mv_dblHAMAXPTLOTQTTY As Double '11/07/2016 DieuNDA: Them tham so check so luong CK toi da cho phep dat lenh lo le thoa thuan cho san HA
    Private mv_dblHAMINPTBONDQTTY As Double '11/07/2016 DieuNDA: Them tham so check SL dat lenh trai phieu san HA toi thieu
    Private mv_dblHOSE_MAX_QUANTITY As Double '11/07/2016 DieuNDA: Them tham so check che lenh
    Friend WithEvents MemberGrid As New GridEx
    Friend WithEvents lblDealNo As System.Windows.Forms.Label
    Friend WithEvents btnGetDeal As System.Windows.Forms.Button
    Friend WithEvents txtDealNO As System.Windows.Forms.TextBox
    Friend WithEvents mskREFORDERID As FlexMaskEditBox
    Friend WithEvents chkPTRepo As System.Windows.Forms.CheckBox
    Friend WithEvents lblREFORDERID As System.Windows.Forms.Label
    Friend WithEvents txtEXPTPRICE As System.Windows.Forms.TextBox
    Friend WithEvents lblEXPTPRICE As System.Windows.Forms.Label
    Friend WithEvents dtpEXPTDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEXPTDATE As System.Windows.Forms.Label
    Friend WithEvents lblExecQtty As System.Windows.Forms.Label
    Friend WithEvents txtExecQtty As System.Windows.Forms.TextBox
    Friend WithEvents mskCustodycd As System.Windows.Forms.TextBox
    Friend WithEvents fcbAfacctno As AppCore.ComboBoxEx
    Friend WithEvents txtQuotePrice As System.Windows.Forms.TextBox
    Friend WithEvents SEMemberGrid As New GridEx

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal pv_strLanguage As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        mv_strLanguage = pv_strLanguage
        mv_xmlDocumentInquiryData = New Xml.XmlDocument
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
    Friend WithEvents pnlTitle As System.Windows.Forms.Panel
    Friend WithEvents lblQuantity As System.Windows.Forms.Label
    Friend WithEvents txtQuantity As System.Windows.Forms.TextBox
    Friend WithEvents lblPriceType As System.Windows.Forms.Label

    Friend WithEvents cboPriceType As ComboBoxEx
    Friend WithEvents lblExpiredDate As System.Windows.Forms.Label
    Friend WithEvents chkAllorNone As System.Windows.Forms.CheckBox
    Friend WithEvents lblSymbolInfo As System.Windows.Forms.Label
    Friend WithEvents pnContractInfo As System.Windows.Forms.Panel
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCANCEL As System.Windows.Forms.Button
    Friend WithEvents picSignature As System.Windows.Forms.PictureBox
    Friend WithEvents pnOrder As System.Windows.Forms.Panel
    Friend WithEvents lblOrderID As System.Windows.Forms.Label
    Friend WithEvents chkDetail As System.Windows.Forms.CheckBox
    Friend WithEvents txtClearingDay As System.Windows.Forms.TextBox
    Friend WithEvents lblClearingDay As System.Windows.Forms.Label
    Friend WithEvents txtLimitPrice As System.Windows.Forms.TextBox
    Friend WithEvents lblAFACCTNO As System.Windows.Forms.Label
    Friend WithEvents lblTimeType As System.Windows.Forms.Label
    Friend WithEvents lblExecType As System.Windows.Forms.Label
    Friend WithEvents lblMatchType As System.Windows.Forms.Label
    Friend WithEvents mskAFACCTNO As FlexMaskEditBox
    Friend WithEvents cboExecType As ComboBoxEx
    Friend WithEvents cboMatchType As ComboBoxEx
    Friend WithEvents cboTimeType As ComboBoxEx
    Friend WithEvents lblAFNAME As System.Windows.Forms.Label
    Friend WithEvents dtpExpiredDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtACTYPE As System.Windows.Forms.TextBox
    Friend WithEvents txtVIA As System.Windows.Forms.TextBox
    Friend WithEvents txtBRATIO As System.Windows.Forms.TextBox
    Friend WithEvents lblVoucher As System.Windows.Forms.Label
    Friend WithEvents cboVoucher As ComboBoxEx
    Friend WithEvents cboCalendar As ComboBoxEx
    Friend WithEvents lblCalendar As System.Windows.Forms.Label
    Friend WithEvents cboConsultant As ComboBoxEx
    Friend WithEvents lblConsultant As System.Windows.Forms.Label
    Friend WithEvents txtTRADELIMIT As System.Windows.Forms.TextBox
    Friend WithEvents pnlMember As System.Windows.Forms.Panel
    Friend WithEvents lblAFINFO As System.Windows.Forms.Label
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents pnBalance As System.Windows.Forms.Panel
    Friend WithEvents lblCI As System.Windows.Forms.Label
    Friend WithEvents lblCIBalance As System.Windows.Forms.Label
    Friend WithEvents lblSEBalance As System.Windows.Forms.Label
    Friend WithEvents lblSE As System.Windows.Forms.Label
    Friend WithEvents lblLimitPrice As System.Windows.Forms.Label
    Friend WithEvents lblStopPrice As System.Windows.Forms.Label
    Friend WithEvents VScrollBarSign As System.Windows.Forms.VScrollBar
    Friend WithEvents lblSEName As System.Windows.Forms.Label
    Friend WithEvents cboCODEID As AppCore.ComboBoxEx
    'Public cboCODEID As AppCore.ComboBoxEx
    Friend WithEvents pnSEInfo As System.Windows.Forms.Panel
    Friend WithEvents pnOrderConfirm As System.Windows.Forms.Panel
    Friend WithEvents lblConfirm As System.Windows.Forms.Label
    Friend WithEvents lblSymbol As System.Windows.Forms.Label
    Friend WithEvents lblConfirmName As System.Windows.Forms.Label
    Friend WithEvents lblConfirmSEName As System.Windows.Forms.Label
    Friend WithEvents btnAdjust As System.Windows.Forms.Button
    Friend WithEvents lblAAMT As System.Windows.Forms.Label
    Friend WithEvents lblCIAdvance As System.Windows.Forms.Label
    Friend WithEvents btnApprove As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents mskOrderID As AppCore.FlexMaskEditBox
    Friend WithEvents lblDelete As System.Windows.Forms.Label
    Friend WithEvents txtOrStatus As System.Windows.Forms.TextBox
    Friend WithEvents btnRefuse As System.Windows.Forms.Button
    Friend WithEvents btnReject As System.Windows.Forms.Button
    Friend WithEvents lblTotalAmout As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents txtCustodyCode As System.Windows.Forms.TextBox
    Friend WithEvents txtTradePalce As System.Windows.Forms.TextBox
    Friend WithEvents txtSecType As System.Windows.Forms.TextBox
    Friend WithEvents cboPriceTime As AppCore.ComboBoxEx
    Friend WithEvents lblConfirmClear As System.Windows.Forms.Label
    Friend WithEvents lblConfirmDes As System.Windows.Forms.Label
    Friend WithEvents lblTimer As System.Windows.Forms.Label
    Friend WithEvents tmrOrder As System.Windows.Forms.Timer
    Friend WithEvents lblVia As System.Windows.Forms.Label
    Friend WithEvents cboVia As AppCore.ComboBoxEx
    Friend WithEvents txtMkStatus As System.Windows.Forms.TextBox
    Friend WithEvents txtFirstListting As System.Windows.Forms.TextBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents btnAmendment As System.Windows.Forms.Button
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents lblOriginalConfirm As System.Windows.Forms.Label
    Friend WithEvents lblMortage As System.Windows.Forms.Label
    Friend WithEvents dtpEffectiveDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEffDate As System.Windows.Forms.Label
    Friend WithEvents chkOUTPRICEALLOW As System.Windows.Forms.CheckBox
    Friend WithEvents pnExtentInfo As System.Windows.Forms.Panel
    Friend WithEvents pnMainInfo As System.Windows.Forms.Panel
    Friend WithEvents pnUpcomInfo As System.Windows.Forms.Panel
    Friend WithEvents lblContraFirm As System.Windows.Forms.Label
    Friend WithEvents txtContraFirm As System.Windows.Forms.TextBox
    Friend WithEvents lblContraCusInfo As System.Windows.Forms.Label
    Friend WithEvents lblContraCus As System.Windows.Forms.Label
    Friend WithEvents txtContraCus As FlexMaskEditBox
    Friend WithEvents lblPutType As System.Windows.Forms.Label
    Friend WithEvents cboPutType As ComboBoxEx
    Friend WithEvents lblPPSE As System.Windows.Forms.Label
    Friend WithEvents lblPurchasingPower As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmQuickOrderTransact))
        Me.pnlTitle = New System.Windows.Forms.Panel
        Me.fcbAfacctno = New AppCore.ComboBoxEx
        Me.mskCustodycd = New System.Windows.Forms.TextBox
        Me.lblTimer = New System.Windows.Forms.Label
        Me.lblAFINFO = New System.Windows.Forms.Label
        Me.lblAFNAME = New System.Windows.Forms.Label
        Me.mskAFACCTNO = New AppCore.FlexMaskEditBox
        Me.lblAFACCTNO = New System.Windows.Forms.Label
        Me.chkDetail = New System.Windows.Forms.CheckBox
        Me.mskOrderID = New AppCore.FlexMaskEditBox
        Me.pnOrder = New System.Windows.Forms.Panel
        Me.lblDealNo = New System.Windows.Forms.Label
        Me.btnGetDeal = New System.Windows.Forms.Button
        Me.txtDealNO = New System.Windows.Forms.TextBox
        Me.pnUpcomInfo = New System.Windows.Forms.Panel
        Me.lblContraFirm = New System.Windows.Forms.Label
        Me.txtContraFirm = New System.Windows.Forms.TextBox
        Me.lblContraCusInfo = New System.Windows.Forms.Label
        Me.lblContraCus = New System.Windows.Forms.Label
        Me.txtContraCus = New AppCore.FlexMaskEditBox
        Me.lblPutType = New System.Windows.Forms.Label
        Me.cboPutType = New AppCore.ComboBoxEx
        Me.pnMainInfo = New System.Windows.Forms.Panel
        Me.txtExecQtty = New System.Windows.Forms.TextBox
        Me.lblExecQtty = New System.Windows.Forms.Label
        Me.lblQuantity = New System.Windows.Forms.Label
        Me.lblSymbolInfo = New System.Windows.Forms.Label
        Me.txtMkStatus = New System.Windows.Forms.TextBox
        Me.lblConsultant = New System.Windows.Forms.Label
        Me.txtSecType = New System.Windows.Forms.TextBox
        Me.txtTradePalce = New System.Windows.Forms.TextBox
        Me.txtCustodyCode = New System.Windows.Forms.TextBox
        Me.cboConsultant = New AppCore.ComboBoxEx
        Me.txtOrStatus = New System.Windows.Forms.TextBox
        Me.lblSymbol = New System.Windows.Forms.Label
        Me.txtBRATIO = New System.Windows.Forms.TextBox
        Me.lblSEName = New System.Windows.Forms.Label
        Me.txtVIA = New System.Windows.Forms.TextBox
        Me.txtACTYPE = New System.Windows.Forms.TextBox
        Me.txtTRADELIMIT = New System.Windows.Forms.TextBox
        Me.cboCODEID = New AppCore.ComboBoxEx
        Me.cboPriceType = New AppCore.ComboBoxEx
        Me.lblPriceType = New System.Windows.Forms.Label
        Me.txtFirstListting = New System.Windows.Forms.TextBox
        Me.txtQuantity = New System.Windows.Forms.TextBox
        Me.txtQuotePrice = New System.Windows.Forms.TextBox
        Me.lblLimitPrice = New System.Windows.Forms.Label
        Me.cboExecType = New AppCore.ComboBoxEx
        Me.lblExecType = New System.Windows.Forms.Label
        Me.pnExtentInfo = New System.Windows.Forms.Panel
        Me.txtEXPTPRICE = New System.Windows.Forms.TextBox
        Me.lblEXPTPRICE = New System.Windows.Forms.Label
        Me.dtpEXPTDATE = New System.Windows.Forms.DateTimePicker
        Me.lblEXPTDATE = New System.Windows.Forms.Label
        Me.lblREFORDERID = New System.Windows.Forms.Label
        Me.chkOUTPRICEALLOW = New System.Windows.Forms.CheckBox
        Me.mskREFORDERID = New AppCore.FlexMaskEditBox
        Me.chkPTRepo = New System.Windows.Forms.CheckBox
        Me.dtpEffectiveDate = New System.Windows.Forms.DateTimePicker
        Me.lblEffDate = New System.Windows.Forms.Label
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.lblMatchType = New System.Windows.Forms.Label
        Me.lblDescription = New System.Windows.Forms.Label
        Me.cboMatchType = New AppCore.ComboBoxEx
        Me.lblStopPrice = New System.Windows.Forms.Label
        Me.txtLimitPrice = New System.Windows.Forms.TextBox
        Me.txtClearingDay = New System.Windows.Forms.TextBox
        Me.lblVoucher = New System.Windows.Forms.Label
        Me.cboCalendar = New AppCore.ComboBoxEx
        Me.lblCalendar = New System.Windows.Forms.Label
        Me.lblClearingDay = New System.Windows.Forms.Label
        Me.cboVoucher = New AppCore.ComboBoxEx
        Me.dtpExpiredDate = New System.Windows.Forms.DateTimePicker
        Me.chkAllorNone = New System.Windows.Forms.CheckBox
        Me.lblExpiredDate = New System.Windows.Forms.Label
        Me.cboTimeType = New AppCore.ComboBoxEx
        Me.lblTimeType = New System.Windows.Forms.Label
        Me.cboVia = New AppCore.ComboBoxEx
        Me.lblVia = New System.Windows.Forms.Label
        Me.lblOrderID = New System.Windows.Forms.Label
        Me.pnContractInfo = New System.Windows.Forms.Panel
        Me.pnlMember = New System.Windows.Forms.Panel
        Me.picSignature = New System.Windows.Forms.PictureBox
        Me.VScrollBarSign = New System.Windows.Forms.VScrollBar
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCANCEL = New System.Windows.Forms.Button
        Me.pnBalance = New System.Windows.Forms.Panel
        Me.lblPPSE = New System.Windows.Forms.Label
        Me.lblPurchasingPower = New System.Windows.Forms.Label
        Me.lblTotal = New System.Windows.Forms.Label
        Me.lblTotalAmout = New System.Windows.Forms.Label
        Me.lblCIAdvance = New System.Windows.Forms.Label
        Me.lblAAMT = New System.Windows.Forms.Label
        Me.pnSEInfo = New System.Windows.Forms.Panel
        Me.lblMortage = New System.Windows.Forms.Label
        Me.lblSEBalance = New System.Windows.Forms.Label
        Me.lblSE = New System.Windows.Forms.Label
        Me.lblCI = New System.Windows.Forms.Label
        Me.lblCIBalance = New System.Windows.Forms.Label
        Me.pnOrderConfirm = New System.Windows.Forms.Panel
        Me.lblOriginalConfirm = New System.Windows.Forms.Label
        Me.lblConfirmDes = New System.Windows.Forms.Label
        Me.lblConfirmClear = New System.Windows.Forms.Label
        Me.lblDelete = New System.Windows.Forms.Label
        Me.lblConfirmSEName = New System.Windows.Forms.Label
        Me.lblConfirmName = New System.Windows.Forms.Label
        Me.lblConfirm = New System.Windows.Forms.Label
        Me.btnAdjust = New System.Windows.Forms.Button
        Me.btnApprove = New System.Windows.Forms.Button
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnRefuse = New System.Windows.Forms.Button
        Me.btnReject = New System.Windows.Forms.Button
        Me.cboPriceTime = New AppCore.ComboBoxEx
        Me.tmrOrder = New System.Windows.Forms.Timer(Me.components)
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.btnAmendment = New System.Windows.Forms.Button
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.pnlTitle.SuspendLayout()
        Me.pnOrder.SuspendLayout()
        Me.pnUpcomInfo.SuspendLayout()
        Me.pnMainInfo.SuspendLayout()
        Me.pnExtentInfo.SuspendLayout()
        Me.pnContractInfo.SuspendLayout()
        CType(Me.picSignature, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnBalance.SuspendLayout()
        Me.pnSEInfo.SuspendLayout()
        Me.pnOrderConfirm.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlTitle
        '
        Me.pnlTitle.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlTitle.Controls.Add(Me.fcbAfacctno)
        Me.pnlTitle.Controls.Add(Me.mskCustodycd)
        Me.pnlTitle.Controls.Add(Me.lblTimer)
        Me.pnlTitle.Controls.Add(Me.lblAFINFO)
        Me.pnlTitle.Controls.Add(Me.lblAFNAME)
        Me.pnlTitle.Controls.Add(Me.mskAFACCTNO)
        Me.pnlTitle.Controls.Add(Me.lblAFACCTNO)
        Me.pnlTitle.Controls.Add(Me.chkDetail)
        Me.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTitle.Location = New System.Drawing.Point(0, 0)
        Me.pnlTitle.Name = "pnlTitle"
        Me.pnlTitle.Size = New System.Drawing.Size(628, 50)
        Me.pnlTitle.TabIndex = 0
        '
        'fcbAfacctno
        '
        Me.fcbAfacctno.DisplayMember = "DISPLAY"
        Me.fcbAfacctno.FormattingEnabled = True
        Me.fcbAfacctno.Location = New System.Drawing.Point(152, 16)
        Me.fcbAfacctno.Name = "fcbAfacctno"
        Me.fcbAfacctno.Size = New System.Drawing.Size(392, 21)
        Me.fcbAfacctno.TabIndex = 7
        Me.fcbAfacctno.ValueMember = "VALUE"
        '
        'mskCustodycd
        '
        Me.mskCustodycd.Location = New System.Drawing.Point(75, 16)
        Me.mskCustodycd.Name = "mskCustodycd"
        Me.mskCustodycd.Size = New System.Drawing.Size(72, 20)
        Me.mskCustodycd.TabIndex = 0
        Me.mskCustodycd.Tag = "88"
        '
        'lblTimer
        '
        Me.lblTimer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTimer.Location = New System.Drawing.Point(544, 16)
        Me.lblTimer.Name = "lblTimer"
        Me.lblTimer.Size = New System.Drawing.Size(80, 20)
        Me.lblTimer.TabIndex = 5
        Me.lblTimer.Text = "lblTimer"
        '
        'lblAFINFO
        '
        Me.lblAFINFO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAFINFO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAFINFO.ForeColor = System.Drawing.Color.Black
        Me.lblAFINFO.Location = New System.Drawing.Point(152, 16)
        Me.lblAFINFO.Name = "lblAFINFO"
        Me.lblAFINFO.Size = New System.Drawing.Size(392, 20)
        Me.lblAFINFO.TabIndex = 4
        Me.lblAFINFO.Text = "lblAFINFO"
        Me.lblAFINFO.Visible = False
        '
        'lblAFNAME
        '
        Me.lblAFNAME.Location = New System.Drawing.Point(232, 16)
        Me.lblAFNAME.Name = "lblAFNAME"
        Me.lblAFNAME.Size = New System.Drawing.Size(216, 23)
        Me.lblAFNAME.TabIndex = 2
        Me.lblAFNAME.Text = "lblAFNAME"
        '
        'mskAFACCTNO
        '
        Me.mskAFACCTNO.ForeColor = System.Drawing.SystemColors.WindowText
        Me.mskAFACCTNO.Location = New System.Drawing.Point(75, 16)
        Me.mskAFACCTNO.Name = "mskAFACCTNO"
        Me.mskAFACCTNO.Size = New System.Drawing.Size(72, 20)
        Me.mskAFACCTNO.TabIndex = 0
        Me.mskAFACCTNO.Tag = "03"
        Me.mskAFACCTNO.Text = "mskAFACCTNO"
        Me.mskAFACCTNO.Visible = False
        Me.mskAFACCTNO.WordWrap = False
        '
        'lblAFACCTNO
        '
        Me.lblAFACCTNO.Location = New System.Drawing.Point(3, 19)
        Me.lblAFACCTNO.Name = "lblAFACCTNO"
        Me.lblAFACCTNO.Size = New System.Drawing.Size(72, 20)
        Me.lblAFACCTNO.TabIndex = 0
        Me.lblAFACCTNO.Tag = "AFACCTNO"
        Me.lblAFACCTNO.Text = "lblAFACCTNO"
        '
        'chkDetail
        '
        Me.chkDetail.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkDetail.Checked = True
        Me.chkDetail.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDetail.Location = New System.Drawing.Point(448, 16)
        Me.chkDetail.Name = "chkDetail"
        Me.chkDetail.Size = New System.Drawing.Size(48, 21)
        Me.chkDetail.TabIndex = 3
        Me.chkDetail.Tag = "chkDetail"
        Me.chkDetail.Text = ">>"
        Me.chkDetail.Visible = False
        '
        'mskOrderID
        '
        Me.mskOrderID.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.mskOrderID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskOrderID.ForeColor = System.Drawing.Color.Red
        Me.mskOrderID.Location = New System.Drawing.Point(8, 756)
        Me.mskOrderID.Name = "mskOrderID"
        Me.mskOrderID.ReadOnly = True
        Me.mskOrderID.Size = New System.Drawing.Size(184, 22)
        Me.mskOrderID.TabIndex = 2
        Me.mskOrderID.Text = "mskOrderID"
        Me.mskOrderID.Visible = False
        '
        'pnOrder
        '
        Me.pnOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnOrder.Controls.Add(Me.lblDealNo)
        Me.pnOrder.Controls.Add(Me.btnGetDeal)
        Me.pnOrder.Controls.Add(Me.txtDealNO)
        Me.pnOrder.Controls.Add(Me.pnUpcomInfo)
        Me.pnOrder.Controls.Add(Me.pnMainInfo)
        Me.pnOrder.Controls.Add(Me.cboExecType)
        Me.pnOrder.Controls.Add(Me.lblExecType)
        Me.pnOrder.Controls.Add(Me.pnExtentInfo)
        Me.pnOrder.Location = New System.Drawing.Point(8, 50)
        Me.pnOrder.Name = "pnOrder"
        Me.pnOrder.Size = New System.Drawing.Size(616, 286)
        Me.pnOrder.TabIndex = 1
        '
        'lblDealNo
        '
        Me.lblDealNo.Location = New System.Drawing.Point(211, 4)
        Me.lblDealNo.Name = "lblDealNo"
        Me.lblDealNo.Size = New System.Drawing.Size(88, 20)
        Me.lblDealNo.TabIndex = 2
        Me.lblDealNo.Tag = "lblDealNo"
        Me.lblDealNo.Text = "lblDealNo"
        '
        'btnGetDeal
        '
        Me.btnGetDeal.Location = New System.Drawing.Point(411, 2)
        Me.btnGetDeal.Name = "btnGetDeal"
        Me.btnGetDeal.Size = New System.Drawing.Size(30, 23)
        Me.btnGetDeal.TabIndex = 4
        Me.btnGetDeal.Tag = "btnGetDeal"
        Me.btnGetDeal.Text = "?"
        Me.btnGetDeal.UseVisualStyleBackColor = True
        '
        'txtDealNO
        '
        Me.txtDealNO.Location = New System.Drawing.Point(305, 4)
        Me.txtDealNO.Name = "txtDealNO"
        Me.txtDealNO.Size = New System.Drawing.Size(100, 20)
        Me.txtDealNO.TabIndex = 3
        Me.txtDealNO.Tag = "txtDealNO"
        '
        'pnUpcomInfo
        '
        Me.pnUpcomInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnUpcomInfo.Controls.Add(Me.lblContraFirm)
        Me.pnUpcomInfo.Controls.Add(Me.txtContraFirm)
        Me.pnUpcomInfo.Controls.Add(Me.lblContraCusInfo)
        Me.pnUpcomInfo.Controls.Add(Me.lblContraCus)
        Me.pnUpcomInfo.Controls.Add(Me.txtContraCus)
        Me.pnUpcomInfo.Controls.Add(Me.lblPutType)
        Me.pnUpcomInfo.Controls.Add(Me.cboPutType)
        Me.pnUpcomInfo.Location = New System.Drawing.Point(0, 287)
        Me.pnUpcomInfo.Name = "pnUpcomInfo"
        Me.pnUpcomInfo.Size = New System.Drawing.Size(616, 63)
        Me.pnUpcomInfo.TabIndex = 2
        '
        'lblContraFirm
        '
        Me.lblContraFirm.Location = New System.Drawing.Point(248, 8)
        Me.lblContraFirm.Name = "lblContraFirm"
        Me.lblContraFirm.Size = New System.Drawing.Size(88, 23)
        Me.lblContraFirm.TabIndex = 6
        Me.lblContraFirm.Text = "lblContraFirm"
        '
        'txtContraFirm
        '
        Me.txtContraFirm.Location = New System.Drawing.Point(337, 9)
        Me.txtContraFirm.Name = "txtContraFirm"
        Me.txtContraFirm.Size = New System.Drawing.Size(100, 20)
        Me.txtContraFirm.TabIndex = 5
        Me.txtContraFirm.Text = "txtContraFirm"
        '
        'lblContraCusInfo
        '
        Me.lblContraCusInfo.Location = New System.Drawing.Point(248, 36)
        Me.lblContraCusInfo.Name = "lblContraCusInfo"
        Me.lblContraCusInfo.Size = New System.Drawing.Size(360, 23)
        Me.lblContraCusInfo.TabIndex = 4
        Me.lblContraCusInfo.Text = "lblContraCusInfo"
        '
        'lblContraCus
        '
        Me.lblContraCus.Location = New System.Drawing.Point(12, 36)
        Me.lblContraCus.Name = "lblContraCus"
        Me.lblContraCus.Size = New System.Drawing.Size(88, 23)
        Me.lblContraCus.TabIndex = 3
        Me.lblContraCus.Text = "lblContraCus"
        '
        'txtContraCus
        '
        Me.txtContraCus.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtContraCus.Location = New System.Drawing.Point(100, 36)
        Me.txtContraCus.Name = "txtContraCus"
        Me.txtContraCus.Size = New System.Drawing.Size(140, 20)
        Me.txtContraCus.TabIndex = 7
        Me.txtContraCus.Text = "txtContraCus"
        '
        'lblPutType
        '
        Me.lblPutType.Location = New System.Drawing.Point(12, 8)
        Me.lblPutType.Name = "lblPutType"
        Me.lblPutType.Size = New System.Drawing.Size(88, 23)
        Me.lblPutType.TabIndex = 1
        Me.lblPutType.Text = "lblPutType"
        '
        'cboPutType
        '
        Me.cboPutType.DisplayMember = "DISPLAY"
        Me.cboPutType.Location = New System.Drawing.Point(100, 9)
        Me.cboPutType.Name = "cboPutType"
        Me.cboPutType.Size = New System.Drawing.Size(100, 21)
        Me.cboPutType.TabIndex = 1
        Me.cboPutType.ValueMember = "VALUE"
        '
        'pnMainInfo
        '
        Me.pnMainInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnMainInfo.Controls.Add(Me.txtExecQtty)
        Me.pnMainInfo.Controls.Add(Me.lblExecQtty)
        Me.pnMainInfo.Controls.Add(Me.lblQuantity)
        Me.pnMainInfo.Controls.Add(Me.lblSymbolInfo)
        Me.pnMainInfo.Controls.Add(Me.txtMkStatus)
        Me.pnMainInfo.Controls.Add(Me.lblConsultant)
        Me.pnMainInfo.Controls.Add(Me.txtSecType)
        Me.pnMainInfo.Controls.Add(Me.txtTradePalce)
        Me.pnMainInfo.Controls.Add(Me.txtCustodyCode)
        Me.pnMainInfo.Controls.Add(Me.cboConsultant)
        Me.pnMainInfo.Controls.Add(Me.txtOrStatus)
        Me.pnMainInfo.Controls.Add(Me.lblSymbol)
        Me.pnMainInfo.Controls.Add(Me.txtBRATIO)
        Me.pnMainInfo.Controls.Add(Me.lblSEName)
        Me.pnMainInfo.Controls.Add(Me.txtVIA)
        Me.pnMainInfo.Controls.Add(Me.txtACTYPE)
        Me.pnMainInfo.Controls.Add(Me.txtTRADELIMIT)
        Me.pnMainInfo.Controls.Add(Me.cboCODEID)
        Me.pnMainInfo.Controls.Add(Me.cboPriceType)
        Me.pnMainInfo.Controls.Add(Me.lblPriceType)
        Me.pnMainInfo.Controls.Add(Me.txtFirstListting)
        Me.pnMainInfo.Controls.Add(Me.txtQuantity)
        Me.pnMainInfo.Controls.Add(Me.txtQuotePrice)
        Me.pnMainInfo.Controls.Add(Me.lblLimitPrice)
        Me.pnMainInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnMainInfo.Location = New System.Drawing.Point(0, 32)
        Me.pnMainInfo.Name = "pnMainInfo"
        Me.pnMainInfo.Size = New System.Drawing.Size(616, 106)
        Me.pnMainInfo.TabIndex = 4
        '
        'txtExecQtty
        '
        Me.txtExecQtty.Enabled = False
        Me.txtExecQtty.Location = New System.Drawing.Point(496, 13)
        Me.txtExecQtty.Name = "txtExecQtty"
        Me.txtExecQtty.Size = New System.Drawing.Size(100, 20)
        Me.txtExecQtty.TabIndex = 19
        Me.txtExecQtty.Tag = "12"
        Me.txtExecQtty.Text = "txtExecQtty"
        '
        'lblExecQtty
        '
        Me.lblExecQtty.Location = New System.Drawing.Point(417, 12)
        Me.lblExecQtty.Name = "lblExecQtty"
        Me.lblExecQtty.Size = New System.Drawing.Size(73, 20)
        Me.lblExecQtty.TabIndex = 18
        Me.lblExecQtty.Text = "lblExecQtty"
        '
        'lblQuantity
        '
        Me.lblQuantity.Location = New System.Drawing.Point(216, 12)
        Me.lblQuantity.Name = "lblQuantity"
        Me.lblQuantity.Size = New System.Drawing.Size(88, 20)
        Me.lblQuantity.TabIndex = 1
        Me.lblQuantity.Text = "lblQuantity"
        '
        'lblSymbolInfo
        '
        Me.lblSymbolInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSymbolInfo.Location = New System.Drawing.Point(212, 44)
        Me.lblSymbolInfo.Name = "lblSymbolInfo"
        Me.lblSymbolInfo.Size = New System.Drawing.Size(396, 21)
        Me.lblSymbolInfo.TabIndex = 4
        Me.lblSymbolInfo.Text = "lblSymbolInfo"
        '
        'txtMkStatus
        '
        Me.txtMkStatus.Location = New System.Drawing.Point(552, 44)
        Me.txtMkStatus.Name = "txtMkStatus"
        Me.txtMkStatus.Size = New System.Drawing.Size(48, 20)
        Me.txtMkStatus.TabIndex = 10
        Me.txtMkStatus.Text = "ALL"
        Me.txtMkStatus.Visible = False
        '
        'lblConsultant
        '
        Me.lblConsultant.Location = New System.Drawing.Point(404, 76)
        Me.lblConsultant.Name = "lblConsultant"
        Me.lblConsultant.Size = New System.Drawing.Size(100, 20)
        Me.lblConsultant.TabIndex = 15
        Me.lblConsultant.Tag = "TIMETYPE"
        Me.lblConsultant.Text = "lblConsultant"
        '
        'txtSecType
        '
        Me.txtSecType.Location = New System.Drawing.Point(364, 76)
        Me.txtSecType.Name = "txtSecType"
        Me.txtSecType.Size = New System.Drawing.Size(56, 20)
        Me.txtSecType.TabIndex = 14
        Me.txtSecType.Tag = "txtSecType"
        Me.txtSecType.Text = "txtSecType"
        Me.txtSecType.Visible = False
        '
        'txtTradePalce
        '
        Me.txtTradePalce.Location = New System.Drawing.Point(420, 76)
        Me.txtTradePalce.Name = "txtTradePalce"
        Me.txtTradePalce.Size = New System.Drawing.Size(56, 20)
        Me.txtTradePalce.TabIndex = 14
        Me.txtTradePalce.Tag = "txtTradePalce"
        Me.txtTradePalce.Text = "txtTradePalce"
        Me.txtTradePalce.Visible = False
        '
        'txtCustodyCode
        '
        Me.txtCustodyCode.Location = New System.Drawing.Point(304, 76)
        Me.txtCustodyCode.Name = "txtCustodyCode"
        Me.txtCustodyCode.Size = New System.Drawing.Size(56, 20)
        Me.txtCustodyCode.TabIndex = 13
        Me.txtCustodyCode.Tag = "txtCustodyCode"
        Me.txtCustodyCode.Text = "txtCustodyCode"
        Me.txtCustodyCode.Visible = False
        '
        'cboConsultant
        '
        Me.cboConsultant.DisplayMember = "DISPLAY"
        Me.cboConsultant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboConsultant.Location = New System.Drawing.Point(508, 76)
        Me.cboConsultant.Name = "cboConsultant"
        Me.cboConsultant.Size = New System.Drawing.Size(100, 21)
        Me.cboConsultant.TabIndex = 17
        Me.cboConsultant.ValueMember = "VALUE"
        '
        'txtOrStatus
        '
        Me.txtOrStatus.Location = New System.Drawing.Point(476, 76)
        Me.txtOrStatus.Name = "txtOrStatus"
        Me.txtOrStatus.Size = New System.Drawing.Size(56, 20)
        Me.txtOrStatus.TabIndex = 16
        Me.txtOrStatus.Tag = "txtOrStatus"
        Me.txtOrStatus.Text = "txtOrStatus"
        Me.txtOrStatus.Visible = False
        '
        'lblSymbol
        '
        Me.lblSymbol.Location = New System.Drawing.Point(12, 12)
        Me.lblSymbol.Name = "lblSymbol"
        Me.lblSymbol.Size = New System.Drawing.Size(88, 20)
        Me.lblSymbol.TabIndex = 2
        Me.lblSymbol.Tag = "SYMBOL"
        Me.lblSymbol.Text = "lblSymbol"
        '
        'txtBRATIO
        '
        Me.txtBRATIO.Location = New System.Drawing.Point(408, 44)
        Me.txtBRATIO.Name = "txtBRATIO"
        Me.txtBRATIO.Size = New System.Drawing.Size(32, 20)
        Me.txtBRATIO.TabIndex = 7
        Me.txtBRATIO.Tag = "13"
        Me.txtBRATIO.Text = "0"
        Me.txtBRATIO.Visible = False
        '
        'lblSEName
        '
        Me.lblSEName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSEName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSEName.Location = New System.Drawing.Point(212, 76)
        Me.lblSEName.Name = "lblSEName"
        Me.lblSEName.Size = New System.Drawing.Size(396, 21)
        Me.lblSEName.TabIndex = 12
        Me.lblSEName.Text = "lblSEName"
        '
        'txtVIA
        '
        Me.txtVIA.Location = New System.Drawing.Point(456, 44)
        Me.txtVIA.Name = "txtVIA"
        Me.txtVIA.Size = New System.Drawing.Size(16, 20)
        Me.txtVIA.TabIndex = 8
        Me.txtVIA.Tag = "22"
        Me.txtVIA.Text = "F"
        Me.txtVIA.Visible = False
        '
        'txtACTYPE
        '
        Me.txtACTYPE.Location = New System.Drawing.Point(484, 44)
        Me.txtACTYPE.Name = "txtACTYPE"
        Me.txtACTYPE.Size = New System.Drawing.Size(56, 20)
        Me.txtACTYPE.TabIndex = 9
        Me.txtACTYPE.Tag = "02"
        Me.txtACTYPE.Text = "ACTYPE"
        Me.txtACTYPE.Visible = False
        '
        'txtTRADELIMIT
        '
        Me.txtTRADELIMIT.Location = New System.Drawing.Point(348, 44)
        Me.txtTRADELIMIT.Name = "txtTRADELIMIT"
        Me.txtTRADELIMIT.Size = New System.Drawing.Size(32, 20)
        Me.txtTRADELIMIT.TabIndex = 6
        Me.txtTRADELIMIT.Tag = "13"
        Me.txtTRADELIMIT.Text = "0"
        Me.txtTRADELIMIT.Visible = False
        '
        'cboCODEID
        '
        Me.cboCODEID.DisplayMember = "DISPLAY"
        Me.cboCODEID.ItemHeight = 13
        Me.cboCODEID.Location = New System.Drawing.Point(100, 12)
        Me.cboCODEID.MaxLength = 10
        Me.cboCODEID.Name = "cboCODEID"
        Me.cboCODEID.Size = New System.Drawing.Size(100, 21)
        Me.cboCODEID.TabIndex = 0
        Me.cboCODEID.Tag = "01"
        Me.cboCODEID.ValueMember = "VALUE"
        '
        'cboPriceType
        '
        Me.cboPriceType.DisplayMember = "DISPLAY"
        Me.cboPriceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPriceType.Location = New System.Drawing.Point(100, 44)
        Me.cboPriceType.Name = "cboPriceType"
        Me.cboPriceType.Size = New System.Drawing.Size(100, 21)
        Me.cboPriceType.TabIndex = 3
        Me.cboPriceType.Tag = "27"
        Me.cboPriceType.ValueMember = "VALUE"
        '
        'lblPriceType
        '
        Me.lblPriceType.Location = New System.Drawing.Point(12, 44)
        Me.lblPriceType.Name = "lblPriceType"
        Me.lblPriceType.Size = New System.Drawing.Size(88, 20)
        Me.lblPriceType.TabIndex = 12
        Me.lblPriceType.Tag = "PRICETYPE"
        Me.lblPriceType.Text = "lblPriceType"
        '
        'txtFirstListting
        '
        Me.txtFirstListting.Location = New System.Drawing.Point(256, 44)
        Me.txtFirstListting.Name = "txtFirstListting"
        Me.txtFirstListting.Size = New System.Drawing.Size(72, 20)
        Me.txtFirstListting.TabIndex = 5
        Me.txtFirstListting.Text = "txtFirstListting"
        Me.txtFirstListting.Visible = False
        '
        'txtQuantity
        '
        Me.txtQuantity.Location = New System.Drawing.Point(305, 12)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(100, 20)
        Me.txtQuantity.TabIndex = 2
        Me.txtQuantity.Tag = "12"
        Me.txtQuantity.Text = "txtQuantity"
        '
        'txtQuotePrice
        '
        Me.txtQuotePrice.Location = New System.Drawing.Point(100, 76)
        Me.txtQuotePrice.Name = "txtQuotePrice"
        Me.txtQuotePrice.Size = New System.Drawing.Size(100, 20)
        Me.txtQuotePrice.TabIndex = 11
        Me.txtQuotePrice.Tag = "11"
        Me.txtQuotePrice.Text = "txtQuotePrice"
        '
        'lblLimitPrice
        '
        Me.lblLimitPrice.Location = New System.Drawing.Point(12, 76)
        Me.lblLimitPrice.Name = "lblLimitPrice"
        Me.lblLimitPrice.Size = New System.Drawing.Size(88, 20)
        Me.lblLimitPrice.TabIndex = 6
        Me.lblLimitPrice.Text = "lblLimitPrice"
        '
        'cboExecType
        '
        Me.cboExecType.DisplayMember = "DISPLAY"
        Me.cboExecType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboExecType.Location = New System.Drawing.Point(101, 5)
        Me.cboExecType.Name = "cboExecType"
        Me.cboExecType.Size = New System.Drawing.Size(100, 21)
        Me.cboExecType.TabIndex = 1
        Me.cboExecType.Tag = "22"
        Me.cboExecType.ValueMember = "VALUE"
        '
        'lblExecType
        '
        Me.lblExecType.Location = New System.Drawing.Point(13, 5)
        Me.lblExecType.Name = "lblExecType"
        Me.lblExecType.Size = New System.Drawing.Size(88, 20)
        Me.lblExecType.TabIndex = 0
        Me.lblExecType.Tag = "EXECTYPE"
        Me.lblExecType.Text = "lblExecType"
        '
        'pnExtentInfo
        '
        Me.pnExtentInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnExtentInfo.Controls.Add(Me.txtEXPTPRICE)
        Me.pnExtentInfo.Controls.Add(Me.lblEXPTPRICE)
        Me.pnExtentInfo.Controls.Add(Me.dtpEXPTDATE)
        Me.pnExtentInfo.Controls.Add(Me.lblEXPTDATE)
        Me.pnExtentInfo.Controls.Add(Me.lblREFORDERID)
        Me.pnExtentInfo.Controls.Add(Me.chkOUTPRICEALLOW)
        Me.pnExtentInfo.Controls.Add(Me.mskREFORDERID)
        Me.pnExtentInfo.Controls.Add(Me.chkPTRepo)
        Me.pnExtentInfo.Controls.Add(Me.dtpEffectiveDate)
        Me.pnExtentInfo.Controls.Add(Me.lblEffDate)
        Me.pnExtentInfo.Controls.Add(Me.txtDescription)
        Me.pnExtentInfo.Controls.Add(Me.lblMatchType)
        Me.pnExtentInfo.Controls.Add(Me.lblDescription)
        Me.pnExtentInfo.Controls.Add(Me.cboMatchType)
        Me.pnExtentInfo.Controls.Add(Me.lblStopPrice)
        Me.pnExtentInfo.Controls.Add(Me.txtLimitPrice)
        Me.pnExtentInfo.Controls.Add(Me.txtClearingDay)
        Me.pnExtentInfo.Controls.Add(Me.lblVoucher)
        Me.pnExtentInfo.Controls.Add(Me.cboCalendar)
        Me.pnExtentInfo.Controls.Add(Me.lblCalendar)
        Me.pnExtentInfo.Controls.Add(Me.lblClearingDay)
        Me.pnExtentInfo.Controls.Add(Me.cboVoucher)
        Me.pnExtentInfo.Controls.Add(Me.dtpExpiredDate)
        Me.pnExtentInfo.Controls.Add(Me.chkAllorNone)
        Me.pnExtentInfo.Controls.Add(Me.lblExpiredDate)
        Me.pnExtentInfo.Controls.Add(Me.cboTimeType)
        Me.pnExtentInfo.Controls.Add(Me.lblTimeType)
        Me.pnExtentInfo.Controls.Add(Me.cboVia)
        Me.pnExtentInfo.Controls.Add(Me.lblVia)
        Me.pnExtentInfo.Location = New System.Drawing.Point(0, 137)
        Me.pnExtentInfo.Name = "pnExtentInfo"
        Me.pnExtentInfo.Size = New System.Drawing.Size(616, 150)
        Me.pnExtentInfo.TabIndex = 5
        '
        'txtEXPTPRICE
        '
        Me.txtEXPTPRICE.Location = New System.Drawing.Point(539, 118)
        Me.txtEXPTPRICE.Name = "txtEXPTPRICE"
        Me.txtEXPTPRICE.Size = New System.Drawing.Size(69, 20)
        Me.txtEXPTPRICE.TabIndex = 24
        Me.txtEXPTPRICE.Tag = "11"
        Me.txtEXPTPRICE.Text = "txtEXPTPRICE"
        '
        'lblEXPTPRICE
        '
        Me.lblEXPTPRICE.Location = New System.Drawing.Point(453, 118)
        Me.lblEXPTPRICE.Name = "lblEXPTPRICE"
        Me.lblEXPTPRICE.Size = New System.Drawing.Size(87, 20)
        Me.lblEXPTPRICE.TabIndex = 23
        Me.lblEXPTPRICE.Tag = "lblEXPTPRICE"
        Me.lblEXPTPRICE.Text = "lblEXPTPRICE"
        Me.lblEXPTPRICE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpEXPTDATE
        '
        Me.dtpEXPTDATE.CustomFormat = "dd/MM/yyyy"
        Me.dtpEXPTDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEXPTDATE.Location = New System.Drawing.Point(367, 118)
        Me.dtpEXPTDATE.Name = "dtpEXPTDATE"
        Me.dtpEXPTDATE.Size = New System.Drawing.Size(80, 20)
        Me.dtpEXPTDATE.TabIndex = 22
        Me.dtpEXPTDATE.Tag = "21"
        Me.dtpEXPTDATE.Value = New Date(2006, 10, 30, 0, 0, 0, 0)
        '
        'lblEXPTDATE
        '
        Me.lblEXPTDATE.Location = New System.Drawing.Point(285, 118)
        Me.lblEXPTDATE.Name = "lblEXPTDATE"
        Me.lblEXPTDATE.Size = New System.Drawing.Size(83, 20)
        Me.lblEXPTDATE.TabIndex = 20
        Me.lblEXPTDATE.Tag = "lblEXPTDATE"
        Me.lblEXPTDATE.Text = "lblEXPTDATE"
        Me.lblEXPTDATE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblREFORDERID
        '
        Me.lblREFORDERID.Location = New System.Drawing.Point(103, 118)
        Me.lblREFORDERID.Name = "lblREFORDERID"
        Me.lblREFORDERID.Size = New System.Drawing.Size(79, 20)
        Me.lblREFORDERID.TabIndex = 15
        Me.lblREFORDERID.Tag = "lblREFORDERID"
        Me.lblREFORDERID.Text = "lblREFORDERID"
        Me.lblREFORDERID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkOUTPRICEALLOW
        '
        Me.chkOUTPRICEALLOW.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkOUTPRICEALLOW.Checked = True
        Me.chkOUTPRICEALLOW.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkOUTPRICEALLOW.Location = New System.Drawing.Point(456, 6)
        Me.chkOUTPRICEALLOW.Name = "chkOUTPRICEALLOW"
        Me.chkOUTPRICEALLOW.Size = New System.Drawing.Size(152, 20)
        Me.chkOUTPRICEALLOW.TabIndex = 1
        Me.chkOUTPRICEALLOW.Tag = "23"
        Me.chkOUTPRICEALLOW.Text = "Accept out amplitute price"
        Me.chkOUTPRICEALLOW.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mskREFORDERID
        '
        Me.mskREFORDERID.BackColor = System.Drawing.Color.GreenYellow
        Me.mskREFORDERID.Location = New System.Drawing.Point(181, 118)
        Me.mskREFORDERID.Name = "mskREFORDERID"
        Me.mskREFORDERID.Size = New System.Drawing.Size(100, 20)
        Me.mskREFORDERID.TabIndex = 19
        Me.mskREFORDERID.Tag = "mskREFORDERID"
        Me.mskREFORDERID.Text = "mskREFORDERID"
        '
        'chkPTRepo
        '
        Me.chkPTRepo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkPTRepo.Location = New System.Drawing.Point(7, 118)
        Me.chkPTRepo.Name = "chkPTRepo"
        Me.chkPTRepo.Size = New System.Drawing.Size(93, 20)
        Me.chkPTRepo.TabIndex = 17
        Me.chkPTRepo.Text = "chkPTRepo"
        '
        'dtpEffectiveDate
        '
        Me.dtpEffectiveDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpEffectiveDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEffectiveDate.Location = New System.Drawing.Point(300, 62)
        Me.dtpEffectiveDate.Name = "dtpEffectiveDate"
        Me.dtpEffectiveDate.Size = New System.Drawing.Size(96, 20)
        Me.dtpEffectiveDate.TabIndex = 10
        Me.dtpEffectiveDate.Tag = "21"
        Me.dtpEffectiveDate.Value = New Date(2006, 10, 30, 0, 0, 0, 0)
        '
        'lblEffDate
        '
        Me.lblEffDate.Location = New System.Drawing.Point(212, 62)
        Me.lblEffDate.Name = "lblEffDate"
        Me.lblEffDate.Size = New System.Drawing.Size(88, 20)
        Me.lblEffDate.TabIndex = 9
        Me.lblEffDate.Text = "lblEffDate"
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(100, 6)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(296, 20)
        Me.txtDescription.TabIndex = 0
        '
        'lblMatchType
        '
        Me.lblMatchType.Location = New System.Drawing.Point(212, 34)
        Me.lblMatchType.Name = "lblMatchType"
        Me.lblMatchType.Size = New System.Drawing.Size(88, 20)
        Me.lblMatchType.TabIndex = 3
        Me.lblMatchType.Tag = "MATCHTYPE"
        Me.lblMatchType.Text = "lblMatchType"
        '
        'lblDescription
        '
        Me.lblDescription.Location = New System.Drawing.Point(4, 6)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(93, 20)
        Me.lblDescription.TabIndex = 27
        Me.lblDescription.Text = "lblDescription"
        '
        'cboMatchType
        '
        Me.cboMatchType.DisplayMember = "DISPLAY"
        Me.cboMatchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMatchType.Location = New System.Drawing.Point(300, 34)
        Me.cboMatchType.Name = "cboMatchType"
        Me.cboMatchType.Size = New System.Drawing.Size(96, 21)
        Me.cboMatchType.TabIndex = 4
        Me.cboMatchType.Tag = "24"
        Me.cboMatchType.ValueMember = "VALUE"
        '
        'lblStopPrice
        '
        Me.lblStopPrice.Location = New System.Drawing.Point(12, 34)
        Me.lblStopPrice.Name = "lblStopPrice"
        Me.lblStopPrice.Size = New System.Drawing.Size(88, 20)
        Me.lblStopPrice.TabIndex = 12
        Me.lblStopPrice.Text = "lblStopPrice"
        '
        'txtLimitPrice
        '
        Me.txtLimitPrice.Location = New System.Drawing.Point(100, 34)
        Me.txtLimitPrice.Name = "txtLimitPrice"
        Me.txtLimitPrice.Size = New System.Drawing.Size(100, 20)
        Me.txtLimitPrice.TabIndex = 2
        Me.txtLimitPrice.Tag = "14"
        Me.txtLimitPrice.Text = "txtLimitPrice"
        '
        'txtClearingDay
        '
        Me.txtClearingDay.Location = New System.Drawing.Point(508, 90)
        Me.txtClearingDay.Name = "txtClearingDay"
        Me.txtClearingDay.Size = New System.Drawing.Size(32, 20)
        Me.txtClearingDay.TabIndex = 15
        Me.txtClearingDay.Tag = "10"
        Me.txtClearingDay.Text = "txtClearingDay"
        '
        'lblVoucher
        '
        Me.lblVoucher.Location = New System.Drawing.Point(12, 90)
        Me.lblVoucher.Name = "lblVoucher"
        Me.lblVoucher.Size = New System.Drawing.Size(88, 20)
        Me.lblVoucher.TabIndex = 21
        Me.lblVoucher.Tag = "TIMETYPE"
        Me.lblVoucher.Text = "lblVoucher"
        '
        'cboCalendar
        '
        Me.cboCalendar.DisplayMember = "DISPLAY"
        Me.cboCalendar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCalendar.Location = New System.Drawing.Point(300, 90)
        Me.cboCalendar.Name = "cboCalendar"
        Me.cboCalendar.Size = New System.Drawing.Size(96, 21)
        Me.cboCalendar.TabIndex = 14
        Me.cboCalendar.ValueMember = "VALUE"
        '
        'lblCalendar
        '
        Me.lblCalendar.Location = New System.Drawing.Point(212, 90)
        Me.lblCalendar.Name = "lblCalendar"
        Me.lblCalendar.Size = New System.Drawing.Size(88, 20)
        Me.lblCalendar.TabIndex = 23
        Me.lblCalendar.Tag = "TIMETYPE"
        Me.lblCalendar.Text = "lblCalendar"
        '
        'lblClearingDay
        '
        Me.lblClearingDay.Location = New System.Drawing.Point(404, 90)
        Me.lblClearingDay.Name = "lblClearingDay"
        Me.lblClearingDay.Size = New System.Drawing.Size(100, 20)
        Me.lblClearingDay.TabIndex = 18
        Me.lblClearingDay.Text = "lblClearingDay"
        '
        'cboVoucher
        '
        Me.cboVoucher.DisplayMember = "DISPLAY"
        Me.cboVoucher.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVoucher.Location = New System.Drawing.Point(100, 90)
        Me.cboVoucher.Name = "cboVoucher"
        Me.cboVoucher.Size = New System.Drawing.Size(100, 21)
        Me.cboVoucher.TabIndex = 13
        Me.cboVoucher.ValueMember = "VALUE"
        '
        'dtpExpiredDate
        '
        Me.dtpExpiredDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpExpiredDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpExpiredDate.Location = New System.Drawing.Point(508, 62)
        Me.dtpExpiredDate.Name = "dtpExpiredDate"
        Me.dtpExpiredDate.Size = New System.Drawing.Size(100, 20)
        Me.dtpExpiredDate.TabIndex = 12
        Me.dtpExpiredDate.Tag = "21"
        Me.dtpExpiredDate.Value = New Date(2006, 10, 30, 0, 0, 0, 0)
        '
        'chkAllorNone
        '
        Me.chkAllorNone.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkAllorNone.Location = New System.Drawing.Point(552, 90)
        Me.chkAllorNone.Name = "chkAllorNone"
        Me.chkAllorNone.Size = New System.Drawing.Size(56, 20)
        Me.chkAllorNone.TabIndex = 16
        Me.chkAllorNone.Tag = "23"
        Me.chkAllorNone.Text = "AON"
        '
        'lblExpiredDate
        '
        Me.lblExpiredDate.Location = New System.Drawing.Point(404, 62)
        Me.lblExpiredDate.Name = "lblExpiredDate"
        Me.lblExpiredDate.Size = New System.Drawing.Size(100, 20)
        Me.lblExpiredDate.TabIndex = 11
        Me.lblExpiredDate.Text = "lblExpiredDate"
        '
        'cboTimeType
        '
        Me.cboTimeType.DisplayMember = "DISPLAY"
        Me.cboTimeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTimeType.Location = New System.Drawing.Point(100, 62)
        Me.cboTimeType.Name = "cboTimeType"
        Me.cboTimeType.Size = New System.Drawing.Size(100, 21)
        Me.cboTimeType.TabIndex = 8
        Me.cboTimeType.Tag = "20"
        Me.cboTimeType.ValueMember = "VALUE"
        '
        'lblTimeType
        '
        Me.lblTimeType.Location = New System.Drawing.Point(12, 62)
        Me.lblTimeType.Name = "lblTimeType"
        Me.lblTimeType.Size = New System.Drawing.Size(88, 20)
        Me.lblTimeType.TabIndex = 14
        Me.lblTimeType.Tag = "TIMETYPE"
        Me.lblTimeType.Text = "lblTimeType"
        '
        'cboVia
        '
        Me.cboVia.DisplayMember = "DISPLAY"
        Me.cboVia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVia.ItemHeight = 13
        Me.cboVia.Location = New System.Drawing.Point(508, 34)
        Me.cboVia.MaxLength = 10
        Me.cboVia.Name = "cboVia"
        Me.cboVia.Size = New System.Drawing.Size(100, 21)
        Me.cboVia.TabIndex = 7
        Me.cboVia.Tag = "01"
        Me.cboVia.ValueMember = "VALUE"
        '
        'lblVia
        '
        Me.lblVia.Location = New System.Drawing.Point(404, 34)
        Me.lblVia.Name = "lblVia"
        Me.lblVia.Size = New System.Drawing.Size(100, 20)
        Me.lblVia.TabIndex = 6
        Me.lblVia.Text = "lblVia"
        '
        'lblOrderID
        '
        Me.lblOrderID.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblOrderID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblOrderID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrderID.ForeColor = System.Drawing.Color.Red
        Me.lblOrderID.Location = New System.Drawing.Point(8, 752)
        Me.lblOrderID.Name = "lblOrderID"
        Me.lblOrderID.Size = New System.Drawing.Size(184, 24)
        Me.lblOrderID.TabIndex = 6
        Me.lblOrderID.Text = "lblOrderID"
        Me.lblOrderID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnContractInfo
        '
        Me.pnContractInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnContractInfo.Controls.Add(Me.pnlMember)
        Me.pnContractInfo.Controls.Add(Me.picSignature)
        Me.pnContractInfo.Controls.Add(Me.VScrollBarSign)
        Me.pnContractInfo.Location = New System.Drawing.Point(8, 616)
        Me.pnContractInfo.Name = "pnContractInfo"
        Me.pnContractInfo.Size = New System.Drawing.Size(616, 130)
        Me.pnContractInfo.TabIndex = 3
        '
        'pnlMember
        '
        Me.pnlMember.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMember.Location = New System.Drawing.Point(8, 4)
        Me.pnlMember.Name = "pnlMember"
        Me.pnlMember.Size = New System.Drawing.Size(432, 120)
        Me.pnlMember.TabIndex = 8
        Me.pnlMember.Tag = "Member"
        '
        'picSignature
        '
        Me.picSignature.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picSignature.Location = New System.Drawing.Point(446, 3)
        Me.picSignature.Name = "picSignature"
        Me.picSignature.Size = New System.Drawing.Size(146, 120)
        Me.picSignature.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picSignature.TabIndex = 5
        Me.picSignature.TabStop = False
        Me.picSignature.Tag = "Signature"
        '
        'VScrollBarSign
        '
        Me.VScrollBarSign.LargeChange = 1
        Me.VScrollBarSign.Location = New System.Drawing.Point(592, 3)
        Me.VScrollBarSign.Name = "VScrollBarSign"
        Me.VScrollBarSign.Size = New System.Drawing.Size(17, 120)
        Me.VScrollBarSign.TabIndex = 6
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(456, 752)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(80, 25)
        Me.btnOK.TabIndex = 6
        Me.btnOK.Tag = "btnOK"
        Me.btnOK.Text = "btnOK"
        '
        'btnCANCEL
        '
        Me.btnCANCEL.Location = New System.Drawing.Point(542, 752)
        Me.btnCANCEL.Name = "btnCANCEL"
        Me.btnCANCEL.Size = New System.Drawing.Size(80, 25)
        Me.btnCANCEL.TabIndex = 16
        Me.btnCANCEL.Tag = "btnCANCEL"
        Me.btnCANCEL.Text = "btnCANCEL"
        '
        'pnBalance
        '
        Me.pnBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnBalance.Controls.Add(Me.lblPPSE)
        Me.pnBalance.Controls.Add(Me.lblPurchasingPower)
        Me.pnBalance.Controls.Add(Me.lblTotal)
        Me.pnBalance.Controls.Add(Me.lblTotalAmout)
        Me.pnBalance.Controls.Add(Me.lblCIAdvance)
        Me.pnBalance.Controls.Add(Me.lblAAMT)
        Me.pnBalance.Controls.Add(Me.pnSEInfo)
        Me.pnBalance.Controls.Add(Me.lblCI)
        Me.pnBalance.Controls.Add(Me.lblCIBalance)
        Me.pnBalance.Location = New System.Drawing.Point(8, 488)
        Me.pnBalance.Name = "pnBalance"
        Me.pnBalance.Size = New System.Drawing.Size(616, 124)
        Me.pnBalance.TabIndex = 10
        '
        'lblPPSE
        '
        Me.lblPPSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPPSE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPPSE.Location = New System.Drawing.Point(112, 92)
        Me.lblPPSE.Name = "lblPPSE"
        Me.lblPPSE.Size = New System.Drawing.Size(120, 23)
        Me.lblPPSE.TabIndex = 14
        Me.lblPPSE.Text = "lblPPSE"
        Me.lblPPSE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPurchasingPower
        '
        Me.lblPurchasingPower.Location = New System.Drawing.Point(8, 92)
        Me.lblPurchasingPower.Name = "lblPurchasingPower"
        Me.lblPurchasingPower.Size = New System.Drawing.Size(104, 23)
        Me.lblPurchasingPower.TabIndex = 13
        Me.lblPurchasingPower.Text = "lblPurchasingPower"
        '
        'lblTotal
        '
        Me.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(112, 63)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(120, 23)
        Me.lblTotal.TabIndex = 12
        Me.lblTotal.Text = "lblTotal"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalAmout
        '
        Me.lblTotalAmout.Location = New System.Drawing.Point(8, 63)
        Me.lblTotalAmout.Name = "lblTotalAmout"
        Me.lblTotalAmout.Size = New System.Drawing.Size(104, 23)
        Me.lblTotalAmout.TabIndex = 11
        Me.lblTotalAmout.Text = "lblTotalAmout"
        '
        'lblCIAdvance
        '
        Me.lblCIAdvance.Location = New System.Drawing.Point(8, 34)
        Me.lblCIAdvance.Name = "lblCIAdvance"
        Me.lblCIAdvance.Size = New System.Drawing.Size(104, 23)
        Me.lblCIAdvance.TabIndex = 10
        Me.lblCIAdvance.Text = "lblCIAdvance"
        '
        'lblAAMT
        '
        Me.lblAAMT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAAMT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAAMT.Location = New System.Drawing.Point(112, 34)
        Me.lblAAMT.Name = "lblAAMT"
        Me.lblAAMT.Size = New System.Drawing.Size(120, 23)
        Me.lblAAMT.TabIndex = 9
        Me.lblAAMT.Text = "lblAAMT"
        Me.lblAAMT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnSEInfo
        '
        Me.pnSEInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnSEInfo.Controls.Add(Me.lblMortage)
        Me.pnSEInfo.Controls.Add(Me.lblSEBalance)
        Me.pnSEInfo.Controls.Add(Me.lblSE)
        Me.pnSEInfo.Location = New System.Drawing.Point(240, 0)
        Me.pnSEInfo.Name = "pnSEInfo"
        Me.pnSEInfo.Size = New System.Drawing.Size(376, 128)
        Me.pnSEInfo.TabIndex = 8
        '
        'lblMortage
        '
        Me.lblMortage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMortage.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMortage.Location = New System.Drawing.Point(240, 36)
        Me.lblMortage.Name = "lblMortage"
        Me.lblMortage.Size = New System.Drawing.Size(120, 23)
        Me.lblMortage.TabIndex = 10
        Me.lblMortage.Text = "lblMortage"
        Me.lblMortage.Visible = False
        '
        'lblSEBalance
        '
        Me.lblSEBalance.Location = New System.Drawing.Point(28, 36)
        Me.lblSEBalance.Name = "lblSEBalance"
        Me.lblSEBalance.Size = New System.Drawing.Size(80, 23)
        Me.lblSEBalance.TabIndex = 8
        Me.lblSEBalance.Text = "lblSEBalance"
        '
        'lblSE
        '
        Me.lblSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSE.Location = New System.Drawing.Point(116, 36)
        Me.lblSE.Name = "lblSE"
        Me.lblSE.Size = New System.Drawing.Size(120, 23)
        Me.lblSE.TabIndex = 9
        Me.lblSE.Text = "`"
        '
        'lblCI
        '
        Me.lblCI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCI.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCI.Location = New System.Drawing.Point(112, 5)
        Me.lblCI.Name = "lblCI"
        Me.lblCI.Size = New System.Drawing.Size(120, 23)
        Me.lblCI.TabIndex = 7
        Me.lblCI.Text = "lblCI"
        Me.lblCI.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCIBalance
        '
        Me.lblCIBalance.Location = New System.Drawing.Point(8, 5)
        Me.lblCIBalance.Name = "lblCIBalance"
        Me.lblCIBalance.Size = New System.Drawing.Size(104, 23)
        Me.lblCIBalance.TabIndex = 6
        Me.lblCIBalance.Text = "lblCIBalance"
        '
        'pnOrderConfirm
        '
        Me.pnOrderConfirm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnOrderConfirm.Controls.Add(Me.lblOriginalConfirm)
        Me.pnOrderConfirm.Controls.Add(Me.lblConfirmDes)
        Me.pnOrderConfirm.Controls.Add(Me.lblConfirmClear)
        Me.pnOrderConfirm.Controls.Add(Me.lblDelete)
        Me.pnOrderConfirm.Controls.Add(Me.lblConfirmSEName)
        Me.pnOrderConfirm.Controls.Add(Me.lblConfirmName)
        Me.pnOrderConfirm.Controls.Add(Me.lblConfirm)
        Me.pnOrderConfirm.Location = New System.Drawing.Point(632, 112)
        Me.pnOrderConfirm.Name = "pnOrderConfirm"
        Me.pnOrderConfirm.Size = New System.Drawing.Size(128, 228)
        Me.pnOrderConfirm.TabIndex = 7
        '
        'lblOriginalConfirm
        '
        Me.lblOriginalConfirm.BackColor = System.Drawing.Color.Khaki
        Me.lblOriginalConfirm.Font = New System.Drawing.Font("Tahoma", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOriginalConfirm.Location = New System.Drawing.Point(13, 102)
        Me.lblOriginalConfirm.Name = "lblOriginalConfirm"
        Me.lblOriginalConfirm.Size = New System.Drawing.Size(100, 23)
        Me.lblOriginalConfirm.TabIndex = 39
        Me.lblOriginalConfirm.Text = "lblOriginalConfirm"
        Me.lblOriginalConfirm.Visible = False
        '
        'lblConfirmDes
        '
        Me.lblConfirmDes.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConfirmDes.Location = New System.Drawing.Point(0, 32)
        Me.lblConfirmDes.Name = "lblConfirmDes"
        Me.lblConfirmDes.Size = New System.Drawing.Size(100, 23)
        Me.lblConfirmDes.TabIndex = 5
        Me.lblConfirmDes.Tag = "lblConfirmDes"
        Me.lblConfirmDes.Text = "lblConfirmDes"
        Me.lblConfirmDes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblConfirmClear
        '
        Me.lblConfirmClear.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConfirmClear.Location = New System.Drawing.Point(0, 4)
        Me.lblConfirmClear.Name = "lblConfirmClear"
        Me.lblConfirmClear.Size = New System.Drawing.Size(100, 23)
        Me.lblConfirmClear.TabIndex = 4
        Me.lblConfirmClear.Tag = "lblConfirmClear"
        Me.lblConfirmClear.Text = "lblConfirmClear"
        Me.lblConfirmClear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDelete
        '
        Me.lblDelete.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDelete.Location = New System.Drawing.Point(9, 60)
        Me.lblDelete.Name = "lblDelete"
        Me.lblDelete.Size = New System.Drawing.Size(100, 23)
        Me.lblDelete.TabIndex = 3
        Me.lblDelete.Text = "lblDelete"
        '
        'lblConfirmSEName
        '
        Me.lblConfirmSEName.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConfirmSEName.Location = New System.Drawing.Point(8, 160)
        Me.lblConfirmSEName.Name = "lblConfirmSEName"
        Me.lblConfirmSEName.Size = New System.Drawing.Size(100, 23)
        Me.lblConfirmSEName.TabIndex = 2
        Me.lblConfirmSEName.Text = "lblConfirmSEName"
        '
        'lblConfirmName
        '
        Me.lblConfirmName.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConfirmName.Location = New System.Drawing.Point(12, 96)
        Me.lblConfirmName.Name = "lblConfirmName"
        Me.lblConfirmName.Size = New System.Drawing.Size(100, 23)
        Me.lblConfirmName.TabIndex = 1
        Me.lblConfirmName.Text = "lblConfirmName"
        '
        'lblConfirm
        '
        Me.lblConfirm.Font = New System.Drawing.Font("Tahoma", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConfirm.Location = New System.Drawing.Point(8, 128)
        Me.lblConfirm.Name = "lblConfirm"
        Me.lblConfirm.Size = New System.Drawing.Size(100, 23)
        Me.lblConfirm.TabIndex = 0
        Me.lblConfirm.Text = "lblConfirm"
        '
        'btnAdjust
        '
        Me.btnAdjust.Enabled = False
        Me.btnAdjust.Location = New System.Drawing.Point(656, 288)
        Me.btnAdjust.Name = "btnAdjust"
        Me.btnAdjust.Size = New System.Drawing.Size(80, 24)
        Me.btnAdjust.TabIndex = 5
        Me.btnAdjust.Text = "btnAdjust"
        '
        'btnApprove
        '
        Me.btnApprove.Enabled = False
        Me.btnApprove.Location = New System.Drawing.Point(368, 752)
        Me.btnApprove.Name = "btnApprove"
        Me.btnApprove.Size = New System.Drawing.Size(80, 25)
        Me.btnApprove.TabIndex = 7
        Me.btnApprove.Tag = "btnApprove"
        Me.btnApprove.Text = "btnApprove"
        Me.btnApprove.Visible = False
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(196, 752)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(80, 25)
        Me.btnDelete.TabIndex = 8
        Me.btnDelete.Tag = "btnDelete"
        Me.btnDelete.Text = "btnDelete"
        '
        'btnRefuse
        '
        Me.btnRefuse.Enabled = False
        Me.btnRefuse.Location = New System.Drawing.Point(284, 752)
        Me.btnRefuse.Name = "btnRefuse"
        Me.btnRefuse.Size = New System.Drawing.Size(80, 25)
        Me.btnRefuse.TabIndex = 14
        Me.btnRefuse.Tag = "btnRefuse"
        Me.btnRefuse.Text = "btnRefuse"
        Me.btnRefuse.Visible = False
        '
        'btnReject
        '
        Me.btnReject.Enabled = False
        Me.btnReject.Location = New System.Drawing.Point(112, 752)
        Me.btnReject.Name = "btnReject"
        Me.btnReject.Size = New System.Drawing.Size(80, 25)
        Me.btnReject.TabIndex = 12
        Me.btnReject.Tag = "btnReject"
        Me.btnReject.Text = "btnReject"
        Me.btnReject.Visible = False
        '
        'cboPriceTime
        '
        Me.cboPriceTime.DisplayMember = "DISPLAY"
        Me.cboPriceTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPriceTime.Location = New System.Drawing.Point(336, 48)
        Me.cboPriceTime.Name = "cboPriceTime"
        Me.cboPriceTime.Size = New System.Drawing.Size(120, 21)
        Me.cboPriceTime.TabIndex = 35
        Me.cboPriceTime.Tag = "27"
        Me.cboPriceTime.ValueMember = "VALUE"
        '
        'tmrOrder
        '
        Me.tmrOrder.Interval = 1000
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'btnAmendment
        '
        Me.btnAmendment.Location = New System.Drawing.Point(32, 756)
        Me.btnAmendment.Name = "btnAmendment"
        Me.btnAmendment.Size = New System.Drawing.Size(75, 23)
        Me.btnAmendment.TabIndex = 14
        Me.btnAmendment.Text = "btnAmendment"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(632, 544)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(100, 20)
        Me.TextBox2.TabIndex = 15
        Me.TextBox2.Text = "TextBox2"
        '
        'frmQuickOrderTransact
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.ClientSize = New System.Drawing.Size(628, 752)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.mskOrderID)
        Me.Controls.Add(Me.btnAmendment)
        Me.Controls.Add(Me.btnReject)
        Me.Controls.Add(Me.btnRefuse)
        Me.Controls.Add(Me.pnOrderConfirm)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnApprove)
        Me.Controls.Add(Me.btnAdjust)
        Me.Controls.Add(Me.pnBalance)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCANCEL)
        Me.Controls.Add(Me.pnContractInfo)
        Me.Controls.Add(Me.pnOrder)
        Me.Controls.Add(Me.pnlTitle)
        Me.Controls.Add(Me.lblOrderID)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmQuickOrderTransact"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmODTransact"
        Me.pnlTitle.ResumeLayout(False)
        Me.pnlTitle.PerformLayout()
        Me.pnOrder.ResumeLayout(False)
        Me.pnOrder.PerformLayout()
        Me.pnUpcomInfo.ResumeLayout(False)
        Me.pnUpcomInfo.PerformLayout()
        Me.pnMainInfo.ResumeLayout(False)
        Me.pnMainInfo.PerformLayout()
        Me.pnExtentInfo.ResumeLayout(False)
        Me.pnExtentInfo.PerformLayout()
        Me.pnContractInfo.ResumeLayout(False)
        CType(Me.picSignature, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnBalance.ResumeLayout(False)
        Me.pnSEInfo.ResumeLayout(False)
        Me.pnOrderConfirm.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region " Declare constant and variables "
    Const c_ResourceManager = "_DIRECT.frmQuickOrderTransact-"
    Dim mv_strMarginType As String = "N"
    Dim mv_dblMarginRatioRate As Double = 0
    Dim mv_dblSecMarginPrice As Double = 0
    Dim mv_dblIsPPUsed As Double = 1
    Dim mv_strAFACCTNO As String
    Dim mv_strAuthCustID As String = String.Empty
    Dim mv_strLastAFACCTNO As String = String.Empty
    Dim mv_blnisClosed As Boolean = False
    Dim mv_dblFloorPrice As Double
    Dim mv_dblMarginPrice As Double
    Dim mv_dblBasicPrice As Double
    Dim mv_dblCeilingPrice As Double
    Dim mv_dblTradeLot As Double
    Dim mv_dblTradeUnit As Double
    Dim mv_dblTmpTradeUnit As Double
    Dim mv_dbdParvalue As Double
    Dim mv_dblAF_Bratio As Double
    Dim mv_dblAvlLimit As Double
    Dim mv_dblTyp_Bratio As Double
    Dim mv_dblSecureBratioMax As Double
    Dim mv_dblSecureBratioMin As Double
    Dim mv_dblSecureBratioSYSMax As Double
    Dim mv_dblSecureBratioSYSMin As Double
    Dim mv_dblSecureRatio As Double
    Dim mv_dblFeeAmount As Double
    Dim mv_dblFeeAmountMin As Double
    Dim mv_dblFeeRate As Double
    Dim tickCount As Double
    Dim mv_strOrderID As String
    Dim mv_strCUSTID As String = String.Empty
    Dim mv_strFULLNAME As String = String.Empty
    Dim mv_strACTYPE As String = String.Empty
    'TungNT added
    Dim mv_strCOREBANK As String = String.Empty
    Dim mv_strSubCOREBANK As String = String.Empty
    'Dim mv_dblOrderValue As Double
    Dim mv_strCoreBankSymbol As String
    Dim mv_strCoreBankOdType As String
    Dim mv_dblCoreBankPrice As Double
    Dim mv_dblCoreBankQtty As Double
    'End
    Dim mv_dblAmendmentQtty As Double
    Dim mv_dblAmendmentPrice As Double
    Dim mv_dblCancelQtty As Double
    Dim mv_dblCancelPrice As Double
    Dim mv_dblQtty As Double
    Dim mv_dblPrice As Double
    Dim mv_dblStopPrice As Double
    Dim mv_dblOldBratio As Double
    Dim mv_strNewAFACCTNO As String
    Dim mv_dblOldQtty As Double
    Dim mv_dblOldPrice As Double
    'chaunh
    Dim mv_dblOldQuoteQtty As Double
    Dim mv_blnODConfirmed As String
    Dim mv_blnOODSTATUS As String
    Dim mv_strUPCOMPriceTypeMessage As String = ""
    Dim mv_dblOldMatchType As String
    'PhuongHT
    Dim mv_dblExecQtty As Double

    Dim mv_dblOldStopPrice As Double
    Dim mv_strHOPriceTypeMessage As String = ""
    Dim mv_strHAPriceTypeMessage As String = ""
    Dim mv_strObjFullExectypeMessage As String = ""
    'PhuongHT them mv_strObjFullPricetypeMessage de view lai cac loai lenh
    Dim mv_strObjFullPricetypeMessage As String = ""
    Dim mv_strODStatus As String = ""
    Dim mv_dblRemainQtty As Double
    Dim mv_dblDefFeeRate As Double = 0
    Dim mv_dblISLATETRANSFER As Double = 0
    Dim mv_dblAdvanceLine As Double = 0
    Dim mv_dblTrfT0Amt As Double = 0
    Dim mv_dblT0SecureAmt As Double = 0
    Dim mv_strChkSysCtrl As String = "N"
    Dim mv_strIsMarginAllow As String
    Dim mv_dblMarginRefPrice As String
    Dim mv_dblPRAvlLimit As Double = 0

    'Public mv_cboSYMBOL As New AppCore.ComboBoxEx
    Private mv_strSYMBOLLIST As String = ""
    Public mv_SymbolTalble As New DataTable
    Private mv_dblOnload As Boolean = False
    Private mv_strObjectName As String
    Private mv_strTltxcd As String
    Private mv_strModuleCode As String
    Private mv_strLanguage As String
    Private mv_strKeyFieldType As String
    Private mv_blnAcctEntry As Boolean = False
    Private mv_blnTranAdjust As Boolean = False
    Private mv_blnIsHistoryView As Boolean = False
    Private mv_blnAllowViewCF As Boolean = True
    Private mv_ResourceManager As Resources.ResourceManager
    Private mv_arrObjFields() As CFieldMaster
    Private mv_arrObjFldVals() As CFieldVal
    Private mv_arrObjAccounts() As CAccountEntry
    Private mv_xmlDocumentInquiryData As Xml.XmlDocument
    Private mv_blnAdvanceOrder As Boolean
    Private mv_blnUPCOMOrder As Boolean
    Private mv_blnViewMode As Boolean = False
    Private mv_strTranStatus As String
    Private mv_strDeltd As String
    Private mv_strViaValue As String = String.Empty

    Private mv_strXmlMessageData As String
    Private mv_strLocalObject As String
    Private mv_strBranchId As String
    Private mv_strTellerId As String
    Private mv_strIpAddress As String
    Private mv_strWsName As String
    Private mv_strBusDate As String = String.Empty
    Private mv_strTxDate As String = String.Empty
    Private mv_strTxNum As String = String.Empty
    Private mv_strTellerType As String
    Private mv_isBackDate As Boolean = False
    ''Sua lai cho hop voi TT REPO
    Private Const CONTROL_PNL_BALANCE_TOP = 330 + 10 '230
    Private Const CONTROL_PNL_CONTRACT_TOP = 460 + 10 '265 '200
    Private Const CONTROL_PNL_EXTENDINFO_TOP = 135
    Private Const CONTROL_BUTTON_TOP = 620 '400
    Private Const FRM_DEFAULT_HEIGHT = 630 '420
    Private Const FRM_EXTEND_HEIGHT = 690 '455
    'Private Const MISS_HIGHT = 120

    Private mv_strTellerName As String
    Private mv_strPrevPriceType As String = "NOTALL"
    Private mv_strOldPriceType As String

    Private Const c_HA_TRADEPLACE As String = "002"

    Private Const c_HO_TRADEPLACE As String = "001"
    Private Const c_UPCOM_TRADEPLACE As String = "005"
    Private mv_strCurrentTime As String = String.Empty
    Private mv_arrHoPriceTypeInfo() As HoPriceType

    Private mv_strIsIssuer As String = "N"
    Private mv_strIsAdjust As String = "N"
    Private Const mv_strSETYPE = "006|003"

    'TungNT added
    Private mv_GroupCareBy As String = ""
    Private mv_InitParam As String = ""
    Private mv_CloseOnFinish As Boolean = False
    Private mv_ReturnValue As String = ""
    Private mv_AFCarebyGrp As String = ""
    'End
    Private mv_strIsDisposal As String = "N"


    Private Structure HoPriceType
        Public HoFromTime As String
        Public HoToTime As String
        Public HoPriceType As String
    End Structure

#End Region

#Region " Properties "

    Public Property SYMBOLLIST() As String
        Get
            Return mv_strSYMBOLLIST
        End Get
        Set(ByVal Value As String)
            mv_strSYMBOLLIST = Value
        End Set
    End Property
    Public Property AccountNumber() As String
        Get
            Return mv_strAFACCTNO
        End Get
        Set(ByVal Value As String)
            mv_strAFACCTNO = Value
        End Set
    End Property

    Public Property AuthCustomer() As String
        Get
            Return mv_strAuthCustID
        End Get
        Set(ByVal Value As String)
            mv_strAuthCustID = Value
        End Set
    End Property

    Public Property CurrentTime() As String
        Get
            Return mv_strCurrentTime
        End Get
        Set(ByVal Value As String)
            mv_strCurrentTime = Value
        End Set
    End Property

    Public Property TellerName() As String
        Get
            Return mv_strTellerName
        End Get
        Set(ByVal Value As String)
            mv_strTellerName = Value
        End Set
    End Property
    Public Property TransactionDeleted() As String
        Get
            Return mv_strDeltd
        End Get
        Set(ByVal Value As String)
            mv_strDeltd = Value
        End Set
    End Property
    Public Property TransactionStatus() As String
        Get
            Return mv_strTranStatus
        End Get
        Set(ByVal Value As String)
            mv_strTranStatus = Value
        End Set
    End Property
    Public Property ViewMode() As Boolean
        Get
            Return mv_blnViewMode
        End Get
        Set(ByVal Value As Boolean)
            mv_blnViewMode = Value
        End Set
    End Property
    Public Property TellerType() As String
        Get
            Return mv_strTellerType
        End Get
        Set(ByVal Value As String)
            mv_strTellerType = Value
        End Set
    End Property
    Public Property BusDate() As String
        Get
            Return mv_strBusDate
        End Get
        Set(ByVal Value As String)
            mv_strBusDate = Value
        End Set
    End Property

    Public Property TxDate() As String
        Get
            Return mv_strTxDate
        End Get
        Set(ByVal Value As String)
            mv_strTxDate = Value
        End Set
    End Property

    Public Property TxNum() As String
        Get
            Return mv_strTxNum
        End Get
        Set(ByVal Value As String)
            mv_strTxNum = Value
        End Set
    End Property

    Public Property MessageData() As String
        Get
            Return mv_strXmlMessageData
        End Get
        Set(ByVal Value As String)
            mv_strXmlMessageData = Value
        End Set
    End Property

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
    Public Property KeyFieldType() As String
        Get
            Return mv_strKeyFieldType
        End Get
        Set(ByVal Value As String)
            mv_strKeyFieldType = Value
        End Set
    End Property

    Public Property ModuleCode() As String
        Get
            Return mv_strModuleCode
        End Get
        Set(ByVal Value As String)
            mv_strModuleCode = Value
        End Set
    End Property

    Public Property ObjectName() As String
        Get
            Return mv_strObjectName
        End Get
        Set(ByVal Value As String)
            mv_strObjectName = Value
        End Set
    End Property

    Public Property BranchId() As String
        Get
            Return mv_strBranchId
        End Get
        Set(ByVal Value As String)
            mv_strBranchId = Value
        End Set
    End Property

    Public Property TellerId() As String
        Get
            Return mv_strTellerId
        End Get
        Set(ByVal Value As String)
            mv_strTellerId = Value
        End Set
    End Property

    Public Property LocalObject() As String
        Get
            Return mv_strLocalObject
        End Get
        Set(ByVal Value As String)
            mv_strLocalObject = Value
        End Set
    End Property

    Public Property UserLanguage() As String
        Get
            Return mv_strLanguage
        End Get
        Set(ByVal Value As String)
            mv_strLanguage = Value
        End Set
    End Property

    Public Property Tltxcd() As String
        Get
            Return mv_strTltxcd
        End Get
        Set(ByVal Value As String)
            mv_strTltxcd = Value
        End Set
    End Property
    Public Property IsHistoryView() As Boolean
        Get
            Return mv_blnIsHistoryView
        End Get
        Set(ByVal Value As Boolean)
            mv_blnIsHistoryView = Value
        End Set
    End Property
    Public Property AllowViewCF() As Boolean
        Get
            Return mv_blnAllowViewCF
        End Get
        Set(ByVal Value As Boolean)
            mv_blnAllowViewCF = Value
        End Set
    End Property
    'Public Property ResourceManager() As Resources.ResourceManager
    '    Get
    '        Return mv_resourceManager
    '    End Get
    '    Set(ByVal Value As Resources.ResourceManager)
    '        mv_resourceManager = Value
    '    End Set
    'End Property
    Public Property AdvanceOrder() As Boolean
        Get
            Return mv_blnAdvanceOrder
        End Get
        Set(ByVal Value As Boolean)
            mv_blnAdvanceOrder = Value
        End Set
    End Property
    Public Property UpcomOrder() As Boolean
        Get
            Return mv_blnUPCOMOrder
        End Get
        Set(ByVal Value As Boolean)
            mv_blnUPCOMOrder = Value
        End Set
    End Property


    Public Property InitParam() As String
        Get
            Return mv_InitParam
        End Get
        Set(ByVal Value As String)
            mv_InitParam = Value
        End Set
    End Property
    Public Property IsDisposal() As String
        Get
            Return mv_strIsDisposal
        End Get
        Set(ByVal Value As String)
            mv_strIsDisposal = Value
        End Set
    End Property

    Public Property ReturnValue() As String
        Get
            Return mv_ReturnValue
        End Get
        Set(ByVal Value As String)
            mv_ReturnValue = Value
        End Set
    End Property

    Public Property CloseOnFinish() As Boolean
        Get
            Return mv_CloseOnFinish
        End Get
        Set(ByVal Value As Boolean)
            mv_CloseOnFinish = Value
        End Set
    End Property

#End Region

#Region " InitExternal"
    Private Sub InitExternal()
        'Khởi tạo Grid MemberGrid
        MemberGrid = New GridEx

        Dim v_cmrMemberHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrMemberHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrMemberHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)

        MemberGrid.FixedHeaderRows.Add(v_cmrMemberHeader)
        MemberGrid.Columns.Add(New Xceed.Grid.Column("__TICK", GetType(System.String)))
        MemberGrid.Columns.Add(New Xceed.Grid.Column("AUTOID", GetType(System.String)))
        MemberGrid.Columns.Add(New Xceed.Grid.Column("TYP", GetType(System.String)))
        MemberGrid.Columns.Add(New Xceed.Grid.Column("CUSTID", GetType(System.String)))
        MemberGrid.Columns.Add(New Xceed.Grid.Column("IDCODE", GetType(System.String)))
        MemberGrid.Columns.Add(New Xceed.Grid.Column("FULLNAME", GetType(System.String)))
        MemberGrid.Columns.Add(New Xceed.Grid.Column("REF", GetType(System.String)))

        MemberGrid.Columns("TYP").Title = mv_ResourceManager.GetString("MEMBER_TYP")
        MemberGrid.Columns("CUSTID").Title = mv_ResourceManager.GetString("MEMBER_CUSTID")
        MemberGrid.Columns("IDCODE").Title = mv_ResourceManager.GetString("MEMBER_IDCODE")
        MemberGrid.Columns("FULLNAME").Title = mv_ResourceManager.GetString("MEMBER_FULLNAME")
        MemberGrid.Columns("REF").Title = mv_ResourceManager.GetString("MEMBER_REF")

        MemberGrid.Columns("__TICK").Width = 20
        MemberGrid.Columns("AUTOID").Width = 0
        MemberGrid.Columns("TYP").Width = 100
        MemberGrid.Columns("TYP").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        MemberGrid.Columns("CUSTID").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        MemberGrid.Columns("IDCODE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        MemberGrid.Columns("FULLNAME").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        MemberGrid.Columns("REF").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left

        MemberGrid.Columns("__TICK").CanBeSorted = False

        Me.pnlMember.Controls.Clear()
        Me.pnlMember.Controls.Add(MemberGrid)
        MemberGrid.Dock = Windows.Forms.DockStyle.Fill
        AddHandler MemberGrid.DoubleClick, AddressOf Me.MemberGrid_Click
        If Me.MemberGrid.DataRowTemplate.Cells.Count >= 0 Then
            For i As Integer = 0 To Me.MemberGrid.DataRowTemplate.Cells.Count - 1
                AddHandler MemberGrid.DataRowTemplate.Cells(i).DoubleClick, AddressOf MemberGrid_DoubleClick
                AddHandler MemberGrid.DataRowTemplate.Cells(i).Click, AddressOf MemberGrid_Click
            Next
        End If
        AddHandler MemberGrid.DataRowTemplate.KeyUp, AddressOf MemberGrid_KeyUp

        'Khởi tạo SE Grid
        Dim v_cmrSEMemberHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrSEMemberHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrSEMemberHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)

        SEMemberGrid = New GridEx
        SEMemberGrid.FixedHeaderRows.Add(v_cmrSEMemberHeader)
        SEMemberGrid.Columns.Add(New Xceed.Grid.Column("SYMBOL", GetType(System.String)))
        SEMemberGrid.Columns.Add(New Xceed.Grid.Column("TRADE", GetType(System.Decimal)))
        SEMemberGrid.Columns.Add(New Xceed.Grid.Column("MORTAGE", GetType(System.Decimal)))
        SEMemberGrid.Columns.Add(New Xceed.Grid.Column("COSTPRICE", GetType(System.Decimal)))
        SEMemberGrid.Columns.Add(New Xceed.Grid.Column("BASICPRICE", GetType(System.Decimal)))

        SEMemberGrid.Columns("SYMBOL").Title = mv_ResourceManager.GetString("MEMBER_SYMBOL")
        SEMemberGrid.Columns("TRADE").Title = mv_ResourceManager.GetString("MEMBER_TRADE")
        SEMemberGrid.Columns("MORTAGE").Title = mv_ResourceManager.GetString("MEMBER_MORTAGE")
        SEMemberGrid.Columns("COSTPRICE").Title = mv_ResourceManager.GetString("MEMBER_COSTPRICE")
        SEMemberGrid.Columns("BASICPRICE").Title = mv_ResourceManager.GetString("MEMBER_BASICPRICE")

        SEMemberGrid.Columns("TRADE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        SEMemberGrid.Columns("MORTAGE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        SEMemberGrid.Columns("COSTPRICE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        SEMemberGrid.Columns("BASICPRICE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right

        SEMemberGrid.Columns("TRADE").FormatSpecifier = "#,##0"
        SEMemberGrid.Columns("MORTAGE").FormatSpecifier = "#,##0"
        SEMemberGrid.Columns("COSTPRICE").FormatSpecifier = "#,##0"
        SEMemberGrid.Columns("BASICPRICE").FormatSpecifier = "#,##0"

        SEMemberGrid.Columns("SYMBOL").Width = 60
        SEMemberGrid.Columns("TRADE").Width = 70
        SEMemberGrid.Columns("MORTAGE").Width = 70
        SEMemberGrid.Columns("COSTPRICE").Width = 70
        SEMemberGrid.Columns("BASICPRICE").Width = 70

        SEMemberGrid.Width = pnSEInfo.Width
        SEMemberGrid.Height = pnSEInfo.Height

        Me.pnSEInfo.Controls.Clear()
        Me.pnSEInfo.Controls.Add(SEMemberGrid)
        'SEMemberGrid.Dock = Windows.Forms.DockStyle.Fill
        'AddHandler SEMemberGrid.DoubleClick
        'If Me.SEMemberGrid.DataRowTemplate.Cells.Count >= 0 Then
        'For i As Integer = 0 To Me.MemberGrid.DataRowTemplate.Cells.Count - 1
        'AddHandler MemberGrid.DataRowTemplate.Cells(i).DoubleClick, AddressOf MemberGrid_Click
        'Next
        'End If
    End Sub
#End Region

#Region " Other method "

    'Hàm này được dùng để bind lại các loại lệnh mua - bán tuỳ theo quyền mua/bán của người được uỷ quyền
    Private Sub ReBindExecComboByAuth()
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_xmlDocument As New Xml.XmlDocument, v_nodeList As Xml.XmlNodeList
        Dim v_strSQL, v_strVALUE, v_strFLDNAME, v_strBuyAuth, v_strSellAuth As String
        If mv_strAuthRights.Length = 0 Then
            v_strSQL = "SELECT LINKAUTH FROM CFAUTH WHERE CUSTID='" & AuthCustomer & "' AND ACCTNO='" + mskAFACCTNO.Text.Trim().Replace(".", "") + "' UNION ALL SELECT LINKAUTH FROM CFLINK WHERE CUSTID='" & AuthCustomer & "' AND ACCTNO='" + mskAFACCTNO.Text.Trim().Replace(".", "") + "'"
            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFAUTH, gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)
            If v_strObjMsg.Length > 0 Then
                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                For i As Integer = 0 To v_nodeList.Count - 1
                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            v_strVALUE = .InnerText.ToString
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME)
                                Case "LINKAUTH"
                                    mv_strAuthRights &= v_strVALUE.Trim() & "|"
                            End Select
                        End With
                    Next
                Next
            End If

            If mv_strAuthRights.Length > 0 Then
                If mv_strAuthRights.EndsWith("|") Then
                    mv_strAuthRights = mv_strAuthRights.Substring(0, mv_strAuthRights.Length - 1)
                End If

                Dim v_arrAuthRight As String() = mv_strAuthRights.Split("|".ToCharArray())
                Dim v_strbuytemp, v_strselltemp As String

                v_strbuytemp = ""
                v_strselltemp = ""
                v_strBuyAuth = ""
                v_strSellAuth = ""

                For i As Integer = 0 To v_arrAuthRight.GetLength(0) - 1
                    v_strbuytemp = v_arrAuthRight(i).Substring(3, 1)
                    v_strselltemp = v_arrAuthRight(i).Substring(4, 1)
                    If v_strBuyAuth.Length > 0 Then
                        If v_strbuytemp = "Y" Then
                            v_strBuyAuth = v_strbuytemp
                        End If
                    Else
                        v_strBuyAuth = v_strbuytemp
                    End If

                    If v_strSellAuth.Length > 0 Then
                        If v_strselltemp = "Y" Then
                            v_strSellAuth = v_strselltemp
                        End If
                    Else
                        v_strSellAuth = v_strselltemp
                    End If
                Next

                Dim v_dsSource As DataTable = cboExecType.ComboSource
                Dim count As Integer = v_dsSource.Rows.Count - 1
                For k As Integer = count To 0 Step -1
                    If v_strBuyAuth = "Y" And v_strSellAuth = "N" Then
                        If "NS,SS,MS".IndexOf(CStr(v_dsSource.Rows(k)("VALUE")).ToUpper()) > -1 Then
                            v_dsSource.Rows.RemoveAt(k)
                        End If
                    ElseIf v_strBuyAuth = "N" And v_strSellAuth = "Y" Then
                        If "NB,BC".IndexOf(CStr(v_dsSource.Rows(k)("VALUE")).ToUpper()) > -1 Then
                            v_dsSource.Rows.RemoveAt(k)
                        End If
                    ElseIf v_strBuyAuth = "N" And v_strSellAuth = "N" Then
                        If "NS,SS,MS,NB,BC".IndexOf(CStr(v_dsSource.Rows(k)("VALUE")).ToUpper()) > -1 Then
                            v_dsSource.Rows.RemoveAt(k)
                        End If
                    End If
                Next

                'Rebind
                cboExecType.Clears()
                For i As Integer = 0 To v_dsSource.Rows.Count - 1
                    cboExecType.AddItems(CStr(v_dsSource.Rows(i)("DISPLAY")), CStr(v_dsSource.Rows(i)("VALUE")))
                Next
                cboExecType.Update()
                If cboExecType.Items.Count <= 0 Then
                    cboExecType.Enabled = False
                    btnOK.Enabled = False
                    btnAdjust.Enabled = False
                    btnAmendment.Enabled = False
                    mskOrderID.Enabled = False
                    btnDelete.Enabled = False
                End If
            End If
        End If
    End Sub

    Private Sub DeleteScreen(ByVal blnIsDelete As Boolean)
        Try
            Me.Text = "Modifing order"

            'pnOrder.Enabled = Not blnIsDelete
            For Each ctl As Control In pnOrder.Controls
                If ctl.Name = "pnMainInfo" Or ctl.Name = "pnExtentInfo" Or ctl.Name = "pnUpcomInfo" Then
                    ctl.Enabled = True
                Else
                    ctl.Enabled = False
                End If
            Next
            For Each ctl As Control In pnMainInfo.Controls
                ctl.Enabled = False
            Next
            For Each ctl As Control In pnExtentInfo.Controls
                ctl.Enabled = False
            Next
            For Each ctl As Control In pnUpcomInfo.Controls
                ctl.Enabled = False
            Next

            pnBalance.Enabled = Not blnIsDelete
            pnContractInfo.Enabled = Not blnIsDelete
            pnSEInfo.Enabled = Not blnIsDelete
            mskOrderID.Visible = blnIsDelete
            lblOrderID.Visible = Not blnIsDelete
            mskAFACCTNO.Enabled = blnIsDelete

            btnDelete.Top = btnOK.Top
            btnDelete.Left = btnOK.Left - 60
            btnAmendment.Top = btnOK.Top
            btnAmendment.Left = btnOK.Left - 200
            btnAmendment.Visible = True
            btnAmendment.Width = btnOK.Width
            btnAmendment.Height = btnOK.Height
            btnAmendment.TabIndex = btnCANCEL.TabIndex - 2
            btnDelete.TabIndex = btnCANCEL.TabIndex - 1
            mskOrderID.Top = lblOrderID.Top
            mskOrderID.Left = lblOrderID.Left
            btnOK.Visible = False
            btnOK.Enabled = False
            'txtQuantity.Enabled = True
            'txtQuantity.Enabled = False
            'txtQuotePrice.Enabled = True
            'cboVia.Enabled = True
            'cboPriceType.Enabled = True
            'btnDelete.Text = "&Cancel"
            'btnAmendment.Text = "&Amend"
            'btnCANCEL.Text = "E&xit"
            btnDelete.Text = mv_ResourceManager.GetString("btnCanDel")
            btnAmendment.Text = mv_ResourceManager.GetString("btnAmend")
            btnCANCEL.Text = mv_ResourceManager.GetString("btnExit")

            cboExecType.SelectedIndex = 0
        Catch ex As Exception

        End Try
    End Sub
    '---------------------------------------------------------------------------------------------------------
    'Hàm này được sử dụng đi?n các thông tin giá trị Lookup được.
    'Biến vào 
    '   v_strFLDNAME Là mã trư?ng thực hiện Lookup
    '   v_strRETURNDATA  Là giá trị Value được ch?n
    '   v_strFULLDATA   Là kết quả danh sách tra cứu
    '---------------------------------------------------------------------------------------------------------
    Public Sub FillLookupData(ByVal v_strVALUE As String, ByVal v_strFULLDATA As String)
        Dim v_xmlDocument As New Xml.XmlDocument, v_nodeList As Xml.XmlNodeList, ctl As Control
        Dim v_strLookupName As String, i, j, v_intNodeIndex, v_intCount As Integer

        v_xmlDocument.LoadXml(v_strFULLDATA)
        'v_intCount = mv_arrObjFields.GetLength(0)
        txtBRATIO.Text = "0"
        txtTRADELIMIT.Text = "0"

        'Xác định Node chứa dữ liệu
        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
        For i = 0 To v_nodeList.Count - 1
            For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                With v_nodeList.Item(i).ChildNodes(j)
                    If "VALUE" = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) _
                        And v_strVALUE = Trim(.InnerText.ToString) Then
                        v_intNodeIndex = i
                        Exit For
                    End If
                End With
            Next
        Next
        'Nạp dữ liệu 
        For j = 0 To v_nodeList.Item(v_intNodeIndex).ChildNodes.Count - 1
            With v_nodeList.Item(v_intNodeIndex).ChildNodes(j)
                Select Case CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    Case "BRATIO"
                        txtBRATIO.Text = Trim(.InnerText.ToString)
                        mv_dblTyp_Bratio = Trim(.InnerText.ToString)
                    Case "TRADELIMIT"
                        txtTRADELIMIT.Text = Trim(.InnerText.ToString)
                    Case "MINFEEAMT"
                        mv_dblFeeAmountMin = CDbl(Trim(.InnerText.ToString))
                    Case "DEFFEERATE"
                        mv_dblFeeRate = CDbl(Trim(.InnerText.ToString))
                End Select

                'If "BRATIO" = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) Then
                '    txtBRATIO.Text = Trim(.InnerText.ToString)
                '    mv_dblTyp_Bratio = Trim(.InnerText.ToString)
                'ElseIf "TRADELIMIT" = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) Then
                '    txtTRADELIMIT.Text = Trim(.InnerText.ToString)
                'End If
            End With
        Next
    End Sub
    '---------------------------------------------------------------------------------------------------------
    'Hàm này được sử dụng để nạp màn hình.
    'Biến vào 
    '   strTLTXCD là mã giao dịch, dùng để xác định các trư?ng trong giao dịch
    '   v_blnChain  Xác định xem có phải nạp màn hình sau khi đã tra cứu không
    '   v_blnData   Xác định xem có phải nạp màn hình xem chi tiết giao dịch không
    '   v_strXML    Là nội dung chuỗi XML tương ứng với v_blnChain hoặc v_blnData
    '---------------------------------------------------------------------------------------------------------
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
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            If Len(v_strXML) > 0 Then
                v_xmlDocumentData.LoadXml(v_strXML)
            End If

            'Lấy thông tin chung v? giao d�ịch
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
                'Nếu không tồn tại mã giao dịch
                MessageBox.Show(mv_ResourceManager.GetString("ERR_TLTXCD_NOTFOUND"))
                ResetScreen(Me)
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

            'Lấy thông tin chi tiết các trư?ng c�ủa giao dịch
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
                                v_strPrintInfo = v_strValue 'Không được trim vì độ dài bắt buộc 10 ký tự
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
                        'Xử lý cho trư?ng Description
                        v_strDefVal = Me.Text
                    ElseIf v_strDefVal = "<$BUSDATE>" Then
                        'L�ấy ngày làm việc hiện tại
                        v_strDefVal = Me.BusDate
                    End If
                    If v_blnChain Then
                        'Nếu giao dịch được nạp qua giao dịch tra cứu
                        If Len(v_strChainName) > 0 Then
                            'Nếu trư?ng n�ày có sử dụng CHAINNAME để lấy giá trị từ màn hình tra cứu
                            v_nodetxData = v_xmlDocumentData.SelectSingleNode("TransactMessage/ObjData/entry[@fldname='" & v_strChainName & "']")
                            If Not v_nodetxData Is Nothing Then
                                v_strDefVal = Trim(v_nodetxData.InnerText)
                            End If
                        End If
                    ElseIf v_blnData Then
                        'Nếu giao dịch có dữ liệu (xem chi tiết)
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

            'Lấy các luật kiểm tra của các trư?ng giao d�ịch
            v_strClause = "SELECT FLDNAME, VALTYPE, OPERATOR, VALEXP, VALEXP2, ERRMSG, EN_ERRMSG FROM FLDVAL " & _
                "WHERE upper(OBJNAME) = '" & strTLTXCD & "' ORDER BY VALTYPE, FLDNAME, ODRNUM" 'Thứ tự order by là quan tr?ng kh�ông sửa
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
                        'Ghi nhận thuật toán để kiểm tra và tính toán cho từng trư?ng c�ủa giao dịch
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

                'Xác định index của mảng FldMaster
                For j = 0 To mv_arrObjFields.GetLength(0) - 1 Step 1
                    If Not mv_arrObjFields(j) Is Nothing Then
                        If Trim(mv_arrObjFields(j).FieldName) = Trim(v_strFieldVal_FldName) Then
                            v_intIndex = j
                        End If
                    End If
                Next

                '?i�?u ki�ện xử lý
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
    Private Function CheckDate() As Boolean
        Try
            Dim v_strSQL, v_strTXDATE, v_strObjMsg, v_strValue, v_strFLDNAME As String

            v_strSQL = "SELECT VARVALUE TXDATE FROM SYSVAR WHERE VARNAME = 'CURRDATE' AND GRNAME = 'SYSTEM' "
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_TLLOG, gc_ActionInquiry, v_strSQL)
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            v_ws.Message(v_strObjMsg)

            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_nodeList As Xml.XmlNodeList
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            If v_nodeList.Count = 1 Then
                For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                    With v_nodeList.Item(0).ChildNodes(i)
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "TXDATE"
                                v_strTXDATE = Trim(v_strValue)
                        End Select
                    End With
                Next
            End If

            'me.BusDate
            If Trim(CStr(Me.BusDate)) = Trim(v_strTXDATE) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    'Verify rules của giao dịch, trả ve điện giao dịch đã được tạo
    Private Function VerifyRules(ByRef v_strTxMsg As String) As Boolean
        Try
            Dim v_xmlDocument As New Xml.XmlDocument, v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
            Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode, v_intIndex As Long, i, v_intCount As Integer
            Dim v_strFLDNAME As String, v_strFLDDEFNAME As String, v_strDATATYPE As String, v_strFLDVALUE As String
            Dim v_strERRMSG, v_strENERRMSG, v_strOPERATOR, v_strVALEXP, v_strVALEXP2 As String, v_strACTYPE, v_strDESC As String
            Dim v_dtVALEXP, v_dtVALEXP2, v_dtFLDVALUE As Date, v_strCMDSQL As String
            Dim v_ctl As Control, v_attrFLDNAME As Xml.XmlAttribute, v_attrDATATYPE As Xml.XmlAttribute, v_objEval As New Evaluator
            Dim v_strVIA As String
            Dim v_strExecType As String
			Dim v_strCusHeader As String
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery            
            Dim v_strObjMsg, v_strHALT, v_strValue, v_Error As String
            Dim v_strStatus As String
            v_strExecType = cboExecType.SelectedValue
            If mv_strViaValue.Length > 0 Then
                v_strVIA = mv_strViaValue
            Else
                v_strVIA = CStr(Me.cboVia.SelectedValue)
            End If
            'Xác định mã loại hình của hợp đồng: Hiển thị form lookup để ch?n
            'v_strCMDSQL = "SELECT ACTYPE, ACTYPE VALUECD, ACTYPE VALUE, TYPENAME DISPLAY, TYPENAME EN_DISPLAY, " & ControlChars.CrLf _
            '    & " TYPENAME DESCRIPTION, TRADELIMIT, BRATIO, MINFEEAMT, DEFFEERATE FROM ODTYPE " & ControlChars.CrLf _
            '    & "WHERE STATUS='Y' AND VIA='" & v_strVIA & "' " & ControlChars.CrLf _
            '    & "AND CLEARCD='" & cboCalendar.SelectedValue & "' " & ControlChars.CrLf _
            '    & "AND (EXECTYPE='" & cboExecType.SelectedValue & "' OR EXECTYPE='AA') " & ControlChars.CrLf _
            '    & "AND (TIMETYPE='" & cboTimeType.SelectedValue & "' OR TIMETYPE='A' )" & ControlChars.CrLf _
            '    & "AND (PRICETYPE='" & cboPriceType.SelectedValue & "' OR PRICETYPE='AA') " & ControlChars.CrLf _
            '    & "AND (MATCHTYPE='" & cboMatchType.SelectedValue & "' OR MATCHTYPE='A')" & ControlChars.CrLf _
            '    & "AND (TRADEPLACE='" & txtTradePalce.Text & "' OR TRADEPLACE='000')" & ControlChars.CrLf _
            '    & "AND SECTYPE='" & txtSecType.Text & "' " & ControlChars.CrLf _
            '    & "AND (NORK='" & IIf(chkAllorNone.Checked, "Y", "N") & "' OR NORK ='A')"
            v_strCMDSQL = "SELECT * FROM (SELECT ACTYPE, ACTYPE VALUECD, ACTYPE VALUE, TYPENAME DISPLAY, TYPENAME EN_DISPLAY, " & ControlChars.CrLf _
             & " TYPENAME DESCRIPTION, TRADELIMIT, BRATIO, MINFEEAMT, DEFFEERATE FROM ODTYPE " & ControlChars.CrLf _
             & " WHERE STATUS='Y' AND ( VIA='" & v_strVIA & "'OR VIA = 'A') " & ControlChars.CrLf _
             & " AND CLEARCD='" & cboCalendar.SelectedValue & "' " & ControlChars.CrLf _
             & " AND (EXECTYPE='" & cboExecType.SelectedValue & "' OR EXECTYPE='AA') " & ControlChars.CrLf _
             & " AND (TIMETYPE='" & cboTimeType.SelectedValue & "' OR TIMETYPE='A' )" & ControlChars.CrLf _
             & " AND (PRICETYPE='" & cboPriceType.SelectedValue & "' OR PRICETYPE='AA') " & ControlChars.CrLf _
             & " AND (MATCHTYPE='" & cboMatchType.SelectedValue & "' OR MATCHTYPE='A')" & ControlChars.CrLf _
             & " AND (TRADEPLACE='" & txtTradePalce.Text & "' OR TRADEPLACE='000')" & ControlChars.CrLf _
             & " AND (INSTR(CASE WHEN '" & txtSecType.Text & "' IN ('001','002') THEN '" & txtSecType.Text & "' || ',111,333'" & ControlChars.CrLf _
             & "                 WHEN '" & txtSecType.Text & "' IN ('003','006') THEN '" & txtSecType.Text & "' || ',222,333,444'" & ControlChars.CrLf _
             & "                 WHEN '" & txtSecType.Text & "' IN ('008') THEN '" & txtSecType.Text & "' || ',111,444'" & ControlChars.CrLf _
             & "                 ELSE '" & txtSecType.Text & "' END, SECTYPE) > 0 OR SECTYPE = '000')" & ControlChars.CrLf _
             & " AND (NORK='" & IIf(chkAllorNone.Checked, "Y", "N") & "' OR NORK ='A')" & ControlChars.CrLf _
             & " AND (CASE WHEN CODEID IS NULL THEN '" & cboCODEID.SelectedValue & "' ELSE CODEID END) = '" & cboCODEID.SelectedValue & "'" & ControlChars.CrLf _
             & " AND ACTYPE IN (SELECT ACTYPE FROM AFIDTYPE WHERE OBJNAME='OD.ODTYPE' AND AFTYPE = '" & mv_strACTYPE & "')" & ControlChars.CrLf _
             & " ORDER BY DEFFEERATE)" & ControlChars.CrLf _
             & " WHERE ROWNUM = 1"

            Dim frm As New frmLookUp(UserLanguage)
            frm.SQLCMD = v_strCMDSQL
            frm.AutoClosed = True
            frm.ShowDialog()
            v_intIndex = InStr(frm.RETURNDATA, vbTab)
            If v_intIndex > 0 Then
                v_strACTYPE = Mid(frm.RETURNDATA, 1, v_intIndex - 1)
                'End
                v_strDESC = Mid(frm.RETURNDATA, v_intIndex + 1)
                'Lấy giá trị BRATIO và TRADELIMIT để kiểm tra hạn mức
                FillLookupData(Mid(frm.RETURNDATA, 1, v_intIndex - 1), frm.FULLDATA)
            End If
            frm.Dispose()

            If Len(v_strACTYPE) = 0 Then
                'Không lựa chon loại hình nào
                If Me.UserLanguage = gc_LANG_ENGLISH Then
                    MsgBox("Product type not found", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                Else
                    MsgBox("Không tìm thấy loại hình đặt lệnh", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                End If
                Return False
            End If

            'Kiểm tra expired date không nho hơn ngày làm việc hiện tại
            If Me.dtpExpiredDate.Value < DDMMYYYY_SystemDate(Me.BusDate) Then
                If Me.UserLanguage = gc_LANG_ENGLISH Then
                    MsgBox("Expired date is invalid", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                Else
                    MsgBox("Ngày hết hạn không hợp lệ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                End If
                Return False
            End If


            ''HaiLT - Check chung khoan co bi HALT thoa thuan khong, P la` halt thoa thuan, A la` han Thuong`, H,S ... la`  Halt
            'If txtTradePalce.Text = c_HO_TRADEPLACE Then
            '    v_strCMDSQL = " SELECT HALT_RESUME_FLAG FROM HO_SEC_INFO WHERE TRIM(CODE)= '" & cboCODEID.Text & "'"                
            '    Dim j As Integer
            '    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_AFMAST, gc_ActionInquiry, v_strCMDSQL)
            '    v_ws.Message(v_strObjMsg)
            '    v_xmlDocument.LoadXml(v_strObjMsg)
            '    v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            '    For i = 0 To 0
            '        For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
            '            With v_nodeList.Item(i).ChildNodes(j)
            '                'Ghi nhận thuật toán để kiểm tra và tính toán cho từng trư?ng c�ủa giao dịch
            '                v_strValue = .InnerText.ToString
            '                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
            '                Select Case Trim(v_strFLDNAME)
            '                    Case "HALT_RESUME_FLAG"
            '                        v_strHALT = Trim(v_strValue)
            '                End Select
            '            End With
            '        Next
            '    Next

            '    If (InStr(v_strHALT, "P") > 0 And InStr(CStr(cboMatchType.SelectedValue), "P") > 0) Then
            '        MsgBox(mv_ResourceManager.GetString("ERR_STOCK_HALT_PT"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
            '        Return False
            '    End If
            '    If (InStr(v_strHALT, "A") > 0 And InStr(CStr(cboMatchType.SelectedValue), "P") = 0) Then
            '        MsgBox(mv_ResourceManager.GetString("ERR_STOCK_HALT"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
            '        Return False
            '    End If
            '    If (InStr("H/S/D", IIf(Len(v_strHALT) = 0, "AZ", v_strHALT)) > 0) Then
            '        MsgBox(mv_ResourceManager.GetString("ERR_HALT"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
            '        Return False
            '    End If

            'End If
            ''End of check HALT thoa thuan



            'Tạo điện giao dịch
            'Nếu là giao dịch tele thì cho đi thẳng (Vorcher = Peding)
            '   + Mua : 8876
            '   + Bán : 8877
            'Nếu là giao dịch tại sàn thì phải duyệt (Vorcher = Complete)
            '   + Mua : 8874
            '   + Bán : 8875

            'Kienvt : Sua khong map theo vouche ma map theo kenh dat lenh de tao thanh cac giao dich
            'SONLT 20150408 lenh di thang, ko can qua 8874 nua.
            If Not mv_blnIsDelete Then  'cboVoucher.SelectedValue = "P" And Not mv_blnIsDelete Then
                'Nếu là lệnh thiếu vorcher thì đi thẳng không cần duyệt
                If cboExecType.SelectedValue = "NB" Then
                    LoadScreen(gc_OD_PLACENORMALBUYORDER_ADVANCED)
                    v_strTxMsg = BuildXMLTxMsg(gc_MsgTypeTrans, gc_IsLocalMsg, gc_OD_PLACENORMALBUYORDER_ADVANCED, Me.BranchId, Me.TellerId, Me.IpAddress, Me.WsName, , , , , , , , , , , , , , , , , Me.BusDate)
                Else
                    LoadScreen(gc_OD_PLACENORMALSELLORDER_ADVANCED)
                    v_strTxMsg = BuildXMLTxMsg(gc_MsgTypeTrans, gc_IsLocalMsg, gc_OD_PLACENORMALSELLORDER_ADVANCED, Me.BranchId, Me.TellerId, Me.IpAddress, Me.WsName, , , , , , , , , , , , , , , , , Me.BusDate)
                End If
                'ElseIf cboVia.SelectedValue = "F" And Not mv_blnIsDelete Then 'cboVoucher.SelectedValue = "C" And Not mv_blnIsDelete Then

                '    'Nếu là nhận lệnh tại sàn thì ch? duyệt
                '    If cboExecType.SelectedValue = "NB" Then
                '        LoadScreen(gc_OD_PLACENORMALBUYORDER)
                '        v_strTxMsg = BuildXMLTxMsg(gc_MsgTypeTrans, gc_IsLocalMsg, gc_OD_PLACENORMALBUYORDER, Me.BranchId, Me.TellerId, Me.IpAddress, Me.WsName, , , , , , , , , , , , , , , , , Me.BusDate)
                '    Else
                '        LoadScreen(gc_OD_PLACENORMALSELLORDER)
                '        v_strTxMsg = BuildXMLTxMsg(gc_MsgTypeTrans, gc_IsLocalMsg, gc_OD_PLACENORMALSELLORDER, Me.BranchId, Me.TellerId, Me.IpAddress, Me.WsName, , , , , , , , , , , , , , , , , Me.BusDate)
                '    End If
            ElseIf mv_blnIsDelete Then
                If mv_blnAmendment Then
                    Select Case cboPriceType.Text
                        Case "ATO", "ATC", "MOK", "MAK", "PLO"
                            MsgBox(mv_ResourceManager.GetString("PRICETYPECOULDNOTEDIT"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                            Return False
                    End Select
                    'Ben BSC yeu cau cho sua lenh dang cho gui
                    'If mv_blnOODSTATUS = "N" Then
                    '    MsgBox(mv_ResourceManager.GetString("SYMBOLWAITINGFORSEND"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                    '    Return False
                    'End If
                    If cboExecType.SelectedValue = "NB" Then
                        LoadScreen(gc_OD_AMENDMENTBUYORDER)
                        v_strTxMsg = BuildXMLTxMsg(gc_MsgTypeTrans, gc_IsLocalMsg, gc_OD_AMENDMENTBUYORDER, Me.BranchId, Me.TellerId, Me.IpAddress, Me.WsName, , , , , , , , , , , , , , , , , Me.BusDate)
                        v_strExecType = "AB"
                    Else
                        LoadScreen(gc_OD_AMENDMENTSELLORDER)
                        v_strTxMsg = BuildXMLTxMsg(gc_MsgTypeTrans, gc_IsLocalMsg, gc_OD_AMENDMENTSELLORDER, Me.BranchId, Me.TellerId, Me.IpAddress, Me.WsName, , , , , , , , , , , , , , , , , Me.BusDate)
                        v_strExecType = "AS"
                    End If
                Else
                    If cboExecType.SelectedValue = "NB" Then
                        LoadScreen(gc_OD_CANCELBUYORDER)
                        v_strTxMsg = BuildXMLTxMsg(gc_MsgTypeTrans, gc_IsLocalMsg, gc_OD_CANCELBUYORDER, Me.BranchId, Me.TellerId, Me.IpAddress, Me.WsName, , , , , , , , , , , , , , , , , Me.BusDate)
                        v_strExecType = "CB"
                    Else
                        LoadScreen(gc_OD_CANCELSELLORDER)
                        v_strTxMsg = BuildXMLTxMsg(gc_MsgTypeTrans, gc_IsLocalMsg, gc_OD_CANCELSELLORDER, Me.BranchId, Me.TellerId, Me.IpAddress, Me.WsName, , , , , , , , , , , , , , , , , Me.BusDate)
                        v_strExecType = "CS"
                    End If
                End If
            Else
                'Nếu là lệnh khác thì tạo giao dịch 8870
                LoadScreen(gc_OD_PLACEORDER)
            End If
            Dim v_dblQuotePrice As String
            If cboPriceType.SelectedValue = "ATO" Or cboPriceType.SelectedValue = "ATC" _
            Or cboPriceType.SelectedValue = "MOK" Or cboPriceType.SelectedValue = "MAK" _
            Or cboPriceType.SelectedValue = "OBO" Or cboPriceType.SelectedValue = "SBO" _
            Or cboPriceType.SelectedValue = "MP" Or cboPriceType.SelectedValue = "MTL" _
            Or cboPriceType.SelectedValue = "PLO" Then
                If cboExecType.SelectedValue = "NS" Or cboExecType.SelectedValue = "MS" Then
                    mv_dblPrice = mv_dblFloorPrice / mv_dblTradeUnit
                Else
                    mv_dblPrice = mv_dblCeilingPrice / mv_dblTradeUnit
                End If
            Else
                mv_dblPrice = txtQuotePrice.Text
            End If
            ' neu la sua lenh MTL: gia van lay gia load o man hinh
            If mv_blnAmendment Then
                mv_dblPrice = txtQuotePrice.Text
            End If
            v_dblQuotePrice = mv_dblPrice
            'Tính toán tỷ lệ ký quỹ của lệnh
            If IsNumeric(mv_dblSecureBratioMin) And IsNumeric(mv_dblSecureBratioMax) _
                 And IsNumeric(mv_dblTyp_Bratio) And IsNumeric(mv_dblAF_Bratio) Then

                mv_dblSecureRatio = GetSecureRatio()


                ''Lấy theo tham số mức hệ thống
                'mv_dblSecureRatio = CDbl(mv_dblSecureBratioMin)
                ''So sánh với tham số loại hình
                'mv_dblSecureRatio = IIf(mv_dblSecureRatio > CDbl(mv_dblTyp_Bratio), mv_dblSecureRatio, CDbl(mv_dblTyp_Bratio))
                ''So sánh với tham số hợp đồng
                'mv_dblSecureRatio = IIf(mv_dblSecureRatio > CDbl(mv_dblAF_Bratio), mv_dblSecureRatio, CDbl(mv_dblAF_Bratio))
                ''Không vượt qua Max của tham số hệ thống
                'mv_dblSecureRatio = IIf(mv_dblSecureRatio > CDbl(mv_dblSecureBratioMax), CDbl(mv_dblSecureBratioMax), mv_dblSecureRatio)
            Else
                'Mặc định là ký quỹ 100%
                mv_dblSecureRatio = 100
            End If
            'Dim v_dblQuotePrice As Double
            'If cboPriceType.SelectedValue <> "LO" And cboPriceType.SelectedValue <> "SL" And (cboExecType.SelectedValue = "NS" Or cboExecType.SelectedValue = "MS") Then 'Lenh ATO then
            '    v_dblQuotePrice = mv_dblFloorPrice / mv_dblTradeUnit
            'ElseIf cboPriceType.SelectedValue <> "LO" And cboPriceType.SelectedValue <> "SL" And cboExecType.SelectedValue = "NB" Then 'Lenh ATO then
            '    v_dblQuotePrice = mv_dblCeilingPrice / mv_dblTradeUnit
            'Else
            '    v_dblQuotePrice = txtQuotePrice.Text
            'End If

            If cboExecType.SelectedValue = "NB" Then
                'Caculate topup
                Dim v_dblTopup As Double
                If Me.mv_strMarginType = "S" Or Me.mv_strMarginType = "T" Then 'Margin credit line
                    If mv_dblIsPPUsed = 1 Then
                        v_dblTopup = Convert.ToDouble(100 / (1 - Me.mv_dblMarginRatioRate / 100 * mv_dblSecMarginPrice / v_dblQuotePrice / mv_dblTradeUnit))
                    Else
                        v_dblTopup = 100
                    End If

                Else
                    v_dblTopup = 100
                End If

                'Tungnt added - Chuan bi de hold
                If "NB/AB".IndexOf(cboExecType.SelectedValue.ToString.Trim().ToUpper()) >= 0 Then
                    mv_strCoreBankOdType = v_strACTYPE
                    mv_strCoreBankSymbol = cboCODEID.Text.Trim().ToUpper()
                    mv_dblCoreBankPrice = v_dblQuotePrice * mv_dblTradeUnit
                    mv_dblCoreBankQtty = Convert.ToDouble(txtQuantity.Text.Replace(",", ""))
                End If
                'End
            End If

            v_xmlDocument.LoadXml(v_strTxMsg)
            v_dataElement = v_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "fields", "")
            If mv_arrObjFields.GetLength(0) > 0 Then
                For v_intIndex = 0 To mv_arrObjFields.GetLength(0) - 1 Step 1
                    If Not mv_arrObjFields(v_intIndex) Is Nothing Then
                        v_strFLDNAME = mv_arrObjFields(v_intIndex).FieldName
                        v_strDATATYPE = mv_arrObjFields(v_intIndex).DataType
                        Select Case Trim(v_strFLDNAME)
                            Case "81" 'PTDEAL
                                If cboMatchType.SelectedValue = "P" Then
                                    v_strFLDVALUE = mv_strTellerId & Replace(mv_strCurrentTime, ":", "")
                                End If
                            Case "80" 'QUOTEQTTY
                                v_strFLDVALUE = mv_dblOldQuoteQtty
                            Case "01" 'CODEID
                                v_strFLDVALUE = cboCODEID.SelectedValue
                            Case "07" 'CODEID
                                v_strFLDVALUE = cboCODEID.Text
                            Case "02" 'ACTYPE
                                v_strFLDVALUE = v_strACTYPE
                            Case "03" 'AFACCTNO
                                v_strFLDVALUE = Trim(mskAFACCTNO.Text)
                            Case "50" 'CUSTNAME 'Lay lam thong tin nguoi dat lenh
                                'v_strFLDVALUE = Trim(mv_strFULLNAME)
                                Dim blnMember As Boolean
                                'Dim j As Integer
                                blnMember = False
                                For i = 0 To MemberGrid.DataRows.Count - 1
                                    If MemberGrid.DataRows(i).Cells("__TICK").Value = "X" Then
                                        blnMember = True
                                        'v_strFLDVALUE = MemberGrid.DataRows(i).Cells("TYP").Value & MemberGrid.DataRows(i).Cells("AUTOID").Value
                                        v_strFLDVALUE = MemberGrid.DataRows(i).Cells("IDCODE").Value '& MemberGrid.DataRows(i).Cells("AUTOID").Value
                                        Exit For
                                    Else
                                        v_strFLDVALUE = ""
                                    End If
                                Next
                            Case "05" 'CIACCTNO
                                v_strFLDVALUE = Trim(mskAFACCTNO.Text)
                            Case "06" 'SEACCTNO
                                v_strFLDVALUE = Trim(mskAFACCTNO.Text) & cboCODEID.SelectedValue
                            Case "20" 'TIMETYPE                                       
                                v_strFLDVALUE = cboTimeType.SelectedValue
                            Case "21" 'EXPDATE                                       
                                v_strFLDVALUE = dtpExpiredDate.Value
                            Case "19" 'Effective date
                                v_strFLDVALUE = dtpEffectiveDate.Value
                            Case "22" 'EXECTYPE  
                                v_strFLDVALUE = v_strExecType
                                'v_strFLDVALUE = cboExecType.SelectedValue
                            Case "23" 'NORK                                       
                                v_strFLDVALUE = IIf(chkAllorNone.Checked, "Y", "N")
                            Case "34" 'OUTPRICEALLOW
                                v_strFLDVALUE = IIf(chkOUTPRICEALLOW.Checked, "Y", "N")
                            Case "24" 'MATCHTYPE                                       
                                v_strFLDVALUE = cboMatchType.SelectedValue
                            Case "25" 'VIA                                       
                                v_strFLDVALUE = v_strVIA
                            Case "26" 'CLEARCD                                       
                                v_strFLDVALUE = cboCalendar.SelectedValue
                            Case "27" 'PRICETYPE                                       
                                v_strFLDVALUE = cboPriceType.SelectedValue
                            Case "10" 'CLEARDAY
                                v_strFLDVALUE = txtClearingDay.Text
                            Case "11" 'QUOTEPRICE
                                ''If cboPriceType.SelectedValue = "ATO" Or cboPriceType.SelectedValue = "ATC" Or cboPriceType.SelectedValue = "MO" Then  'Lenh ATO then
                                'If cboPriceType.SelectedValue <> "LO" And cboPriceType.SelectedValue <> "SL" And (cboExecType.SelectedValue = "NS" Or cboExecType.SelectedValue = "MS") Then 'Lenh ATO then
                                '    v_strFLDVALUE = mv_dblFloorPrice / mv_dblTradeUnit
                                'ElseIf cboPriceType.SelectedValue <> "LO" And cboPriceType.SelectedValue <> "SL" And cboExecType.SelectedValue = "NB" Then 'Lenh ATO then
                                '    v_strFLDVALUE = mv_dblCeilingPrice / mv_dblTradeUnit
                                'Else
                                '    v_strFLDVALUE = txtQuotePrice.Text
                                'End If
                                'v_strFLDVALUE = v_dblQuotePrice / mv_dblTmpTradeUnit
                                If cboPriceType.SelectedIndex > 0 And (cboExecType.SelectedValue = "NS" Or cboExecType.SelectedValue = "MS") Then 'Lenh ATO then
                                    v_strFLDVALUE = mv_dblFloorPrice / mv_dblTradeUnit / mv_dblTmpTradeUnit
                                ElseIf cboPriceType.SelectedIndex > 0 And cboExecType.SelectedValue = "NB" Then 'Lenh ATO then
                                    v_strFLDVALUE = mv_dblCeilingPrice / mv_dblTradeUnit / mv_dblTmpTradeUnit
                                Else
                                    v_strFLDVALUE = txtQuotePrice.Text / mv_dblTmpTradeUnit
                                End If

                                If mv_blnIsDelete And Not mv_blnAmendment Then
                                    v_strFLDVALUE = mv_dblOldPrice / mv_dblTradeUnit
                                Else
                                    v_strFLDVALUE = mv_dblPrice / mv_dblTmpTradeUnit
                                End If
                            Case "12" 'ORDERQTTY                                      
                                If mv_blnIsDelete And Not mv_blnAmendment Then
                                    v_strFLDVALUE = mv_dblOldQtty / mv_dblTradeUnit
                                Else
                                    v_strFLDVALUE = txtQuantity.Text
                                End If
                            Case "13" 'BRATIO                                      
                                'v_strFLDVALUE = txtBRATIO.Text

                                ''Tính toán tỷ lệ ký quỹ của lệnh
                                'If IsNumeric(mv_dblSecureBratioMin) And IsNumeric(mv_dblSecureBratioMax) _
                                '     And IsNumeric(mv_dblTyp_Bratio) And IsNumeric(mv_dblAF_Bratio) Then

                                '    mv_dblSecureRatio = GetSecureRatio()


                                '    ''Lấy theo tham số mức hệ thống
                                '    'mv_dblSecureRatio = CDbl(mv_dblSecureBratioMin)
                                '    ''So sánh với tham số loại hình
                                '    'mv_dblSecureRatio = IIf(mv_dblSecureRatio > CDbl(mv_dblTyp_Bratio), mv_dblSecureRatio, CDbl(mv_dblTyp_Bratio))
                                '    ''So sánh với tham số hợp đồng
                                '    'mv_dblSecureRatio = IIf(mv_dblSecureRatio > CDbl(mv_dblAF_Bratio), mv_dblSecureRatio, CDbl(mv_dblAF_Bratio))
                                '    ''Không vượt qua Max của tham số hệ thống
                                '    'mv_dblSecureRatio = IIf(mv_dblSecureRatio > CDbl(mv_dblSecureBratioMax), CDbl(mv_dblSecureBratioMax), mv_dblSecureRatio)
                                'Else
                                '    'Mặc định là ký quỹ 100%
                                '    mv_dblSecureRatio = 100
                                'End If
                                v_strFLDVALUE = mv_dblSecureRatio
                            Case "40" 'Fee amount
                                v_strFLDVALUE = mv_dblFeeAmount
                            Case "14" 'LIMITPRICE
                                If mv_blnIsDelete And Not mv_blnAmendment Then
                                    v_strFLDVALUE = mv_dblOldStopPrice / mv_dblTradeUnit
                                Else
                                    v_strFLDVALUE = txtLimitPrice.Text / mv_dblTmpTradeUnit
                                End If
                            Case "15" 'PARVALUE
                                v_strFLDVALUE = mv_dbdParvalue
                            Case "16" 'Original ORDERQTTY (For Adjust Order Only)
                                v_strFLDVALUE = mv_dblQtty
                            Case "82" 'Original Orderquoteqtty
                                v_strFLDVALUE = mv_dblOldQuoteQtty
                            Case "17" 'Original ORDERPrice (For Adjust Order Only)
                                v_strFLDVALUE = mv_dblOldPrice / mv_dblTmpTradeUnit
                            Case "31" 'Original ORDERStopPrice (For Adjust Order Only)
                                v_strFLDVALUE = mv_dblOldStopPrice / mv_dblTmpTradeUnit
                            Case "18" 'AdvancedAmount= max((CDbl(txtQuantity.Text) * CDbl(txtQuotePrice.Text) - mv_dblPrice * mv_dblQtty),0) (For Adjust Order Only)
                                'Giao dich huy sua thi la truong Advance amount
                                Dim v_dblTempQuotePrice As Double
                                If cboPriceType.SelectedValue <> "LO" And cboPriceType.SelectedValue <> "SL" And (cboExecType.SelectedValue = "NS" Or cboExecType.SelectedValue = "MS") Then 'Lenh ATO then
                                    v_dblTempQuotePrice = mv_dblFloorPrice / mv_dblTradeUnit
                                ElseIf cboPriceType.SelectedValue <> "LO" And cboPriceType.SelectedValue <> "SL" And cboExecType.SelectedValue = "NB" Then 'Lenh ATO then
                                    v_dblTempQuotePrice = mv_dblCeilingPrice / mv_dblTradeUnit
                                Else
                                    v_dblTempQuotePrice = CDbl(txtQuotePrice.Text)
                                End If

                                'If CDbl(txtQuantity.Text) * v_dblTempQuotePrice - mv_dblPrice * mv_dblQtty > 0 Then
                                '    v_strFLDVALUE = (CDbl(txtQuantity.Text) * v_dblTempQuotePrice - mv_dblPrice * mv_dblQtty)
                                'Else
                                '    v_strFLDVALUE = "0"
                                'End If
                                'Neu la lenh sua va phai ky quy them
                                If mv_blnAmendment And CDbl(txtQuantity.Text) * v_dblTempQuotePrice * mv_dblSecureRatio / 100 - mv_dblPrice * mv_dblQtty * mv_dblOldBratio / 100 > 0 Then
                                    v_strFLDVALUE = (CDbl(txtQuantity.Text) * v_dblTempQuotePrice * mv_dblSecureRatio / 100 - mv_dblPrice * mv_dblQtty * mv_dblOldBratio / 100)
                                Else
                                    v_strFLDVALUE = "0"
                                End If
                                If mv_strODStatus.Trim = "Rejected" Or mv_strODStatus.Trim = "Pending" Then
                                    'Lenh huy, sua GTC goc
                                    v_strFLDVALUE = 0
                                End If
                            Case "28" 'VOUCHER
                                v_strFLDVALUE = Trim(cboVoucher.SelectedValue)
                            Case "29" 'CONSULTANT
                                v_strFLDVALUE = Trim(cboConsultant.SelectedValue)
                            Case "04" 'ORDERID
                                If Len(Me.lblOrderID.Text) = 0 Then
                                    v_strFLDVALUE = GetOrderID()
                                    Me.lblOrderID.Text = Strings.Left(v_strFLDVALUE, 4) & "." & Strings.Mid(v_strFLDVALUE, 5, 6) & "." & Strings.Right(v_strFLDVALUE, 6)
                                Else
                                    v_strFLDVALUE = Strings.Left(Me.lblOrderID.Text, 4) & Strings.Mid(Me.lblOrderID.Text, 6, 6) & Strings.Right(Me.lblOrderID.Text, 6)
                                End If
                            Case "08" 'Cancel Order ID
                                v_strFLDVALUE = mskOrderID.Text
                            Case "30" 'DESC 
                                If Me.txtDescription.Text.Trim = "Orders making" And Not mv_blnIsDelete Then
                                    If cboMatchType.SelectedValue = "P" Then
                                        v_strFLDVALUE = Trim(mskAFACCTNO.Text) & "." & Trim(mv_strFULLNAME) & "." & "P" & "" & cboExecType.SelectedValue & "." & cboCODEID.Text & "." & txtQuantity.Text & "." & txtQuotePrice.Text
                                    Else
                                        v_strFLDVALUE = Trim(mskAFACCTNO.Text) & "." & Trim(mv_strFULLNAME) & "." & cboExecType.SelectedValue & "." & cboCODEID.Text & "." & txtQuantity.Text & "." & txtQuotePrice.Text
                                    End If
                                    txtDescription.Text = v_strFLDVALUE
                                ElseIf mv_blnIsDelete Then
                                    Dim v_strDesPrifix As String
                                    If mv_blnAmendment Then
                                        'v_strDesPrifix = "Amendment "
                                        v_strDesPrifix = mv_ResourceManager.GetString("DESC_AMEND_PREFIX")
                                    Else
                                        'v_strDesPrifix = "Cancel "
                                        v_strDesPrifix = mv_ResourceManager.GetString("DESC_CANCEL_PREFIX")
                                    End If
                                    If cboMatchType.SelectedValue = "P" Then
                                        v_strFLDVALUE = v_strDesPrifix & Strings.Left(mskOrderID.Text, 4) & "." & Strings.Mid(mskOrderID.Text, 5, 6) & "." & Strings.Right(mskOrderID.Text, 6) & "." & Trim(mv_strFULLNAME) & "." & "P" & "" & cboExecType.SelectedValue & "." & cboCODEID.Text & "." & txtQuantity.Text & "." & txtQuotePrice.Text
                                    Else
                                        v_strFLDVALUE = v_strDesPrifix & Strings.Left(mskOrderID.Text, 4) & "." & Strings.Mid(mskOrderID.Text, 5, 6) & "." & Strings.Right(mskOrderID.Text, 6) & "." & Trim(mv_strFULLNAME) & "." & cboExecType.SelectedValue & "." & cboCODEID.Text & "." & txtQuantity.Text & "." & txtQuotePrice.Text
                                    End If

                                    txtDescription.Text = v_strFLDVALUE
                                Else
                                    v_strFLDVALUE = Me.txtDescription.Text
                                End If
                                'Case "50" 'SYMBOL
                                '    v_strFLDVALUE = cboCODEID.Text
                            Case "09" 'Custody Code
                                v_strFLDVALUE = txtCustodyCode.Text
                            Case "95" 'Deal ID, cho lenh ban phong toa
                                If Me.cboExecType.SelectedValue = "MS" Then
                                    v_strFLDVALUE = Trim(txtDealNO.Text)
                                Else
                                    'Neu lenh binh thuong thi de trong.
                                    v_strFLDVALUE = ""
                                End If
                            Case "99" 'Topup
                                If Me.mv_strMarginType = "S" Or Me.mv_strMarginType = "T" Then 'Margin credit line
                                    If mv_dblIsPPUsed = 1 Then
                                        v_strFLDVALUE = CStr(100 / (1 - Me.mv_dblMarginRatioRate / 100 * mv_dblSecMarginPrice / v_dblQuotePrice / mv_dblTradeUnit))
                                    Else
                                        v_strFLDVALUE = 100
                                    End If

                                Else
                                    v_strFLDVALUE = "100"
                                End If
                            Case "98" 'TradeUnit
                                v_strFLDVALUE = mv_dblTradeUnit
                                'v_strFLDVALUE = mv_dblTmpTradeUnit
                            Case "97" 'Mode dat lenh
                                v_strFLDVALUE = IIf(Me.mv_blnAdvanceOrder, "A", "N")
                            Case "96" 'Neu GTC thi 0, con lai la 1
                                v_strFLDVALUE = IIf(cboTimeType.SelectedValue = "G", "0", "1")
                            Case "60" 'Is mortage
                                v_strFLDVALUE = IIf(cboExecType.SelectedValue = "MS", "1", "0")
                            Case "73"
                                v_strFLDVALUE = Me.txtContraFirm.Text
                            Case "71"
                                v_strFLDVALUE = Replace(Me.txtContraCus.Text, ".", "")
                            Case "72"
                                If Me.UpcomOrder Then
                                    'Electric or Nomal
                                    v_strFLDVALUE = Me.cboPutType.SelectedValue
                                Else
                                    'Khong loai nao ca None
                                    v_strFLDVALUE = "O"
                                End If
                            Case "74"
                                v_strFLDVALUE = mv_strIsDisposal
                            Case "55"
                                v_strFLDVALUE = "N"
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

            CreateFeemap(v_xmlDocument)

            'Add careby field - MOdified by TungNT
            v_attrFLDNAME = v_xmlDocument.ChildNodes(0).Attributes(gc_AtributeCAREBY)
            If Not v_attrFLDNAME Is Nothing Then
                v_attrFLDNAME.Value = "[" & mv_AFCarebyGrp & "]"
            End If
            'End


            v_strTxMsg = v_xmlDocument.InnerXml

            Return True
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function

    Private Sub LoadOrderInfo(ByVal v_strOrderInfo As String)
        Dim v_xmlDocument As New Xml.XmlDocument, v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
        Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode, i As Integer
        Dim v_strFLDNAME As String
        Dim v_strValue As String
        Dim v_attrFLDNAME As Xml.XmlAttribute, v_attrDATATYPE As Xml.XmlAttribute
        Dim v_strTIMETYPE As String
        Try
            v_xmlDocument.LoadXml(v_strOrderInfo)

            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            Dim v_strExpdate As String = Me.BusDate
            Dim v_strEffective As String = Me.BusDate
            For i = 0 To v_nodeList.Count - 1
                If CStr(CType(v_nodeList.Item(i).ChildNodes(0).Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "ORDERID" And _
                     (Replace(CStr(CType(v_nodeList.Item(i).ChildNodes(0).Attributes.GetNamedItem("oldval"), Xml.XmlAttribute).Value), ".", "") = mskOrderID.Text Or _
                    Replace(Replace(CStr(CType(v_nodeList.Item(i).ChildNodes(0).Attributes.GetNamedItem("oldval"), Xml.XmlAttribute).Value), ".", ""), "/", "") = mskOrderID.Text) Then


                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)

                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            v_strValue = .InnerText.ToString
                            Select Case Trim(v_strFLDNAME)
                                'chaunh 
                                Case "CONFIRMED"
                                    mv_blnODConfirmed = v_strValue
                                Case "OODSTATUS"
                                    mv_blnOODSTATUS = v_strValue
                                Case "AFACCTNO"
                                    mv_strNewAFACCTNO = Replace(v_strValue, ".", "")
                                    If mv_strNewAFACCTNO <> mskAFACCTNO.Text Then
                                        MessageBox.Show(mv_ResourceManager.GetString("INV_ACCNUMBER"))
                                        ResetScreen(Me)
                                        ShowAdjustButton(False)
                                        ResetDeleteButton()
                                        Exit Sub
                                    End If
                                Case "CODEID" 'CODEID
                                    cboCODEID.Text = v_strValue
                                Case "ACTYPE" 'ACTYPE
                                    txtACTYPE.Text = v_strValue
                                Case "ORSTATUS" 'AFACCTNO
                                    txtOrStatus.Text = v_strValue
                                    mv_strODStatus = v_strValue
                                    'Case "CUSTNAME" 'CUSTNAME
                                    '    v_strFLDVALUE = Trim(mv_strFULLNAME)
                                    'Case "05" 'CIACCTNO
                                    '    v_strFLDVALUE = Trim(mskAFACCTNO.Text)
                                    'Case "06" 'SEACCTNO
                                    '    v_strFLDVALUE = Trim(mskAFACCTNO.Text) & cboCODEID.SelectedValue
                                Case "TIMETYPE" 'TIMETYPE        
                                    v_strTIMETYPE = v_strValue
                                    'cboTimeType.Text = v_strValue
                                Case "EXPDATE" 'EXPDATE                                       
                                    v_strExpdate = v_strValue
                                    dtpExpiredDate.Text = v_strValue
                                Case "TXDATE" 'EffectiveDATE                                       
                                    v_strEffective = v_strValue
                                    dtpEffectiveDate.Text = v_strValue
                                Case "EXECTYPE" 'EXECTYPE                                       
                                    cboExecType.Text = v_strValue
                                Case "NORK" 'NORK                                       
                                    chkAllorNone.Checked = IIf(v_strValue = "Y", True, False)
                                Case "MATCHTYPE" 'MATCHTYPE                                       
                                    cboMatchType.Text = v_strValue
                                    mv_dblOldMatchType = v_strValue
                                    'Case "25" 'VIA                                       
                                    '    v_strFLDVALUE = "F"
                                Case "CLEARCD" 'CLEARCD                                       
                                    cboCalendar.Text = v_strValue
                                Case "PRICETYPE" 'PRICETYPE                                       
                                    cboPriceType.Text = v_strValue
                                    mv_strOldPriceType = v_strValue
                                Case "CLEARDAY" 'CLEARDAY
                                    txtClearingDay.Text = v_strValue
                                Case "QUOTEPRICE" 'QUOTEPRICE
                                    txtQuotePrice.Text = v_strValue / mv_dblTradeUnit
                                    mv_dblPrice = v_strValue / mv_dblTradeUnit
                                    mv_dblOldPrice = v_strValue / mv_dblTradeUnit
                                Case "BRATIO"
                                    mv_dblOldBratio = CDbl(v_strValue)
                                Case "ORDERQTTY" 'ORDERQTTY          
                                    'Neu la lenh huy, sua thi chi huy, sua tren khoi luong con lai
                                    If mv_blnIsDelete = False Then
                                        mv_dblQtty = CDbl(v_strValue)
                                        txtQuantity.Text = CDbl(v_strValue)
                                        mv_dblOldQtty = CDbl(v_strValue)
                                    Else
                                        mv_dblQtty = CDbl(v_strValue)
                                        txtQuantity.Text = v_strValue
                                        mv_dblOldQtty = CDbl(v_strValue)
                                    End If
                                    ' PhuongHT uncomment to edit the confirm delete view 
                                Case "REMAINQTTY"
                                    If mv_blnIsDelete Then
                                        mv_dblRemainQtty = CDbl(v_strValue)
                                        'txtQuantity.Text = v_strValue 
                                    End If
                                Case "LIMITPRICE" 'LIMITPRICE
                                    txtLimitPrice.Text = v_strValue / mv_dblTradeUnit
                                    mv_dblStopPrice = v_strValue / mv_dblTradeUnit
                                    'Case "15" 'PARVALUE
                                    '    v_strFLDVALUE = mv_dbdParvalue
                                Case "VOUCHER" 'VOUCHER
                                    cboVoucher.Text = v_strValue
                                Case "CONSULTANT" 'CONSULTANT
                                    cboConsultant.Text = v_strValue
                                Case "ORDERID" 'ORDERID
                                    'lblOrderID.Text = v_strValue
                                    'Case "DESC" 'DESC                                     
                                    '    txtDescription.Text = "Cancel " & Trim(mskAFACCTNO.Text) & "." & Trim(mv_strFULLNAME) & "." & cboExecType.SelectedValue & "." & cboCODEID.Text & "." & txtQuantity.Text & "." & txtQuotePrice.Text
                                Case "50" 'SYMBOL
                                    cboCODEID.Text = v_strValue
                                Case "CUSTODYCD"
                                    txtCustodyCode.Text = v_strValue
                                    'Case "99" 'gia tri 100
                                    '    v_strFLDVALUE = "100"
                                    'Case "98" 'TradeUnit
                                    '    v_strFLDVALUE = mv_dblTradeUnit
                                Case "97" 'Mode dat lenh
                                    mv_blnAdvanceOrder = IIf(v_strValue.Trim = "A", True, False)
                                Case "TXNUM"
                                    mv_strTxNum = v_strValue
                                Case "OUTPRICEALLOW"
                                    Me.chkOUTPRICEALLOW.Checked = IIf(v_strValue = "Y", True, False)
                                Case "PUTTYPE"
                                    Me.cboPutType.SelectedValue = v_strValue
                                Case "CONTRAORDERID"
                                    Me.txtContraCus.Text = v_strValue
                                Case "CONTRAFRM"
                                    Me.txtContraFirm.Text = v_strValue
                                Case "EXECQTTY" 'kl da khop
                                    mv_dblExecQtty = CDbl(v_strValue)
                                    Me.txtExecQtty.Text = mv_dblExecQtty
                                Case "VIAVALUE"
                                    mv_strViaValue = v_strValue

                            End Select

                        End With

                    Next
                    Exit For
                End If
            Next
            'Do timetype events reset dtpExpiredDate nen gan lai
            cboTimeType.Text = v_strTIMETYPE
            dtpExpiredDate.Text = v_strExpdate
            dtpEffectiveDate.Text = v_strEffective
            'chaunh
            If mv_blnIsDelete = True And Me.txtTradePalce.Text <> c_HO_TRADEPLACE Then
                Select Case Trim(cboPriceType.SelectedValue)
                    Case "LO"
                        txtQuotePrice.Enabled = True
                        txtQuantity.Enabled = True
                        txtQuantity.Enabled = True
                        txtLimitPrice.Enabled = False
                        txtLimitPrice.Text = "0"
                    Case "MOK", "MAK", "ATO", "ATC", "MP"
                        txtQuotePrice.Enabled = False
                        txtQuotePrice.Text = "0"
                        txtLimitPrice.Enabled = False
                        txtLimitPrice.Text = "0"
                        txtQuantity.Enabled = False
                    Case "SO>", "SO<"
                        If mv_blnODConfirmed = "Y" Then
                            txtQuotePrice.Enabled = True
                            txtLimitPrice.Enabled = False
                            txtQuantity.Enabled = True
                        Else
                            txtQuotePrice.Enabled = True
                            txtLimitPrice.Enabled = True
                            txtQuantity.Enabled = True
                        End If

                    Case "IO"
                        txtQuotePrice.Enabled = True

                    Case "MTL", "SBO", "OBO"
                        cboCODEID.Enabled = False
                        If mv_blnOODSTATUS = "S" Then
                            txtQuantity.Enabled = True
                            txtQuotePrice.Enabled = True
                        End If
                End Select
                cboCODEID.Enabled = False
            ElseIf mv_blnIsDelete = True And Me.txtTradePalce.Text = c_HO_TRADEPLACE Then
                Select Case Trim(cboPriceType.SelectedValue)
                    Case "ATO", "ATC", "MP"
                        txtQuotePrice.Enabled = False
                        txtQuotePrice.Text = "0"
                        txtLimitPrice.Enabled = False
                        txtLimitPrice.Text = "0"
                        txtQuantity.Enabled = False
                        Me.btnAmendment.Enabled = False
                End Select

            Else
                txtQuantity.Enabled = False
                txtQuotePrice.Enabled = False

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Function CheckPutthought() As Boolean
        CheckPutthought = True
        If cboMatchType.SelectedValue = "P" And InStr(mv_strSETYPE, txtSecType.Text) > 0 Then
            If txtTradePalce.Text = c_HA_TRADEPLACE And IsNumeric(txtQuantity.Text) Then
                If CDec(txtQuantity.Text) < mv_dblHAMINPTBONDQTTY Then
                    MessageBox.Show(String.Format(mv_ResourceManager.GetString("INV_QTTY1000"), mv_dblHAMINPTBONDQTTY), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    CheckPutthought = False
                End If
            End If
        Else
            If txtTradePalce.Text = c_HO_TRADEPLACE And IsNumeric(txtQuantity.Text) Then
                If cboMatchType.SelectedValue = "N" Then
                    If CDec(txtQuantity.Text) > mv_dblHOSE_MAX_QUANTITY Then
                        MessageBox.Show(String.Format(mv_ResourceManager.GetString("INV_QTTYHOLO"), mv_dblHOSE_MAX_QUANTITY), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        CheckPutthought = False
                    End If
                Else
                    If CDec(txtQuantity.Text) < mv_dblHOMINPTQTTY Then
                        MessageBox.Show(String.Format(mv_ResourceManager.GetString("INV_QTTY20000"), mv_dblHOMINPTQTTY), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        CheckPutthought = False
                    End If
                End If
            ElseIf txtTradePalce.Text = c_HA_TRADEPLACE And IsNumeric(txtQuantity.Text) Then
                If cboMatchType.SelectedValue = "N" Then
                Else
                    If CDec(txtQuantity.Text) >= mv_dblHAMAXPTLOTQTTY And CDec(txtQuantity.Text) < mv_dblHAMINPTQTTY Then
                        MessageBox.Show(String.Format(mv_ResourceManager.GetString("INV_QTTY5000"), mv_dblHAMAXPTLOTQTTY, mv_dblHAMINPTQTTY), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        CheckPutthought = False
                    End If
                End If
            End If
        End If
    End Function

    Private Function CheckCIAdjustBalance() As Boolean
        Try
            If (Len(txtQuantity.Text) > 0 And IsNumeric(txtQuantity.Text)) And _
                (Len(txtQuotePrice.Text) >= 0 And IsNumeric(txtQuotePrice.Text)) Then

                If InStr(cboExecType.Text, "Buy") > 0 Then
                    'Tính toán tỷ lệ ký quỹ của lệnh
                    If IsNumeric(mv_dblSecureBratioMin) And IsNumeric(mv_dblSecureBratioMax) _
                         And IsNumeric(mv_dblTyp_Bratio) And IsNumeric(mv_dblAF_Bratio) Then

                        mv_dblSecureRatio = GetSecureRatio()
                        ''Lấy theo tham số mức hệ thống
                        'mv_dblSecureRatio = CDbl(mv_dblSecureBratioMin)
                        ''So sánh với tham số loại hình
                        'mv_dblSecureRatio = IIf(mv_dblSecureRatio > CDbl(mv_dblTyp_Bratio), mv_dblSecureRatio, CDbl(mv_dblTyp_Bratio))
                        ''So sánh với tham số hợp đồng
                        'mv_dblSecureRatio = IIf(mv_dblSecureRatio > CDbl(mv_dblAF_Bratio), mv_dblSecureRatio, CDbl(mv_dblAF_Bratio))
                        ''Không vượt qua Max của tham số hệ thống
                        'mv_dblSecureRatio = IIf(mv_dblSecureRatio > CDbl(mv_dblSecureBratioMax), CDbl(mv_dblSecureBratioMax), mv_dblSecureRatio)
                    Else
                        'Mặc định là ký quỹ 100%
                        mv_dblSecureRatio = 100
                    End If
                    Dim v_dblTempQuotePrice As Double
                    If cboPriceType.SelectedIndex > 0 And cboExecType.SelectedValue = "NS" Then 'Lenh ATO then
                        v_dblTempQuotePrice = mv_dblFloorPrice / mv_dblTradeUnit
                    ElseIf cboPriceType.SelectedIndex > 0 And cboExecType.SelectedValue = "NB" Then 'Lenh ATO then
                        v_dblTempQuotePrice = mv_dblCeilingPrice / mv_dblTradeUnit
                    Else
                        v_dblTempQuotePrice = CDbl(txtQuotePrice.Text)
                    End If
                    If CDbl(txtQuantity.Text) * v_dblTempQuotePrice * mv_dblTradeUnit * (mv_dblSecureRatio / 100) > CDbl(lblCI.Text) + mv_dblPrice * mv_dblQtty * mv_dblTradeUnit * mv_dblOldBratio Then
                        MsgBox(String.Format(mv_ResourceManager.GetString("ERR_NOT_ECI"), lblCI.Text), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
                        txtQuantity.Focus()
                        Return False
                    End If
                End If

            End If
            Return True
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function

    Private Function CheckCIBalance() As Boolean
        Try
            If (Len(txtQuantity.Text) > 0 And IsNumeric(txtQuantity.Text)) And _
                (Len(txtQuotePrice.Text) >= 0 And IsNumeric(txtQuotePrice.Text)) And Me.cboTimeType.SelectedValue <> "G" Then

                If InStr(cboExecType.Text, "Buy") > 0 Then
                    'Tính toán tỷ lệ ký quỹ của lệnh
                    If IsNumeric(mv_dblSecureBratioMin) And IsNumeric(mv_dblSecureBratioMax) _
                         And IsNumeric(mv_dblTyp_Bratio) And IsNumeric(mv_dblAF_Bratio) Then

                        mv_dblSecureRatio = GetSecureRatio()
                        ''Lấy theo tham số mức hệ thống
                        'mv_dblSecureRatio = CDbl(mv_dblSecureBratioMin)
                        ''So sánh với tham số loại hình
                        'mv_dblSecureRatio = IIf(mv_dblSecureRatio > CDbl(mv_dblTyp_Bratio), mv_dblSecureRatio, CDbl(mv_dblTyp_Bratio))
                        ''So sánh với tham số hợp đồng
                        'mv_dblSecureRatio = IIf(mv_dblSecureRatio > CDbl(mv_dblAF_Bratio), mv_dblSecureRatio, CDbl(mv_dblAF_Bratio))
                        ''Không vượt qua Max của tham số hệ thống
                        'mv_dblSecureRatio = IIf(mv_dblSecureRatio > CDbl(mv_dblSecureBratioMax), CDbl(mv_dblSecureBratioMax), mv_dblSecureRatio)
                    Else
                        'Mặc định là ký quỹ 100%
                        mv_dblSecureRatio = 100
                    End If
                    Dim v_dblQuotePrice As Double
                    If cboPriceType.SelectedValue <> "LO" And cboPriceType.SelectedValue <> "SL" And (cboExecType.SelectedValue = "NS" Or cboExecType.SelectedValue = "MS") Then 'Lenh ATO then
                        v_dblQuotePrice = mv_dblFloorPrice / mv_dblTradeUnit
                    ElseIf cboPriceType.SelectedValue <> "LO" And cboPriceType.SelectedValue <> "SL" And cboExecType.SelectedValue = "NB" Then 'Lenh ATO then
                        v_dblQuotePrice = mv_dblCeilingPrice / mv_dblTradeUnit
                    Else
                        v_dblQuotePrice = txtQuotePrice.Text
                    End If

                    If mv_dblSecureRatio > 0 Then 'NEU TY LE KY QUY >0 THI MOI KIEM TRA
                        If CDbl(txtQuantity.Text) * CDbl(txtQuotePrice.Text) * mv_dblTradeUnit * (mv_dblSecureRatio / 100) > CDbl(lblCI.Text) / IIf(mv_strMarginType <> "S" And mv_strMarginType <> "T", 1, 1 - mv_dblIsPPUsed * mv_dblMarginRatioRate / 100 * mv_dblSecMarginPrice / v_dblQuotePrice / mv_dblTradeUnit) Then
                            MsgBox(String.Format(mv_ResourceManager.GetString("ERR_NOT_EPURC"), lblPPSE.Text), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
                            txtQuantity.Focus()
                            Return False
                        End If
                    End If
                ElseIf InStr(cboExecType.Text, "Sell") > 0 Then
                    If InStr(cboExecType.Text, "Mortage Sell") > 0 Then
                        If Len(lblMortage.Text) = 0 Then lblMortage.Text = 0
                        If CDbl(txtQuantity.Text) > CDbl(lblMortage.Text) Then
                            MsgBox(String.Format(mv_ResourceManager.GetString("ERR_NOT_EMT"), lblMortage.Text), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
                            txtQuantity.Focus()
                            Return False
                        End If
                    Else
                        If Len(lblSE.Text) = 0 Then lblSE.Text = 0
                        If CDbl(txtQuantity.Text) > CDbl(lblSE.Text) Then
                            MsgBox(String.Format(mv_ResourceManager.GetString("ERR_NOT_ESE"), lblSE.Text), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
                            txtQuantity.Focus()
                            Return False
                        End If
                    End If
                Else

                End If

            End If
            Return True
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function
    Private Function CheckSEBalance() As Boolean
        Try
            If InStr(cboExecType.Text, "Sell") > 0 And IsNumeric(txtQuantity.Text) Then
                If Me.cboTimeType.SelectedValue <> "G" Then
                    If InStr(cboExecType.Text, "Mortage Sell") > 0 Then
                        'If Len(lblMortage.Text) = 0 Then lblMortage.Text = 0
                        If CDbl(txtQuantity.Text) > CDbl(lblMortage.Text) And (mv_blnIsDelete = False) Then
                            MsgBox(String.Format(mv_ResourceManager.GetString("ERR_NOT_EMT"), lblMortage.Text), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
                            txtQuantity.Focus()
                            Return False
                        End If
                    Else
                        'If Len(lblSE.Text) = 0 Then lblSE.Text = 0
                        If CDbl(txtQuantity.Text) > CDbl(lblSE.Text) And (mv_blnIsDelete = False) Then
                            MsgBox(String.Format(mv_ResourceManager.GetString("ERR_NOT_ESE"), lblSE.Text), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
                            txtQuantity.Focus()
                            Return False
                        End If
                    End If
                End If
                If mv_blnIsDelete And CDbl(Me.txtQuantity.Text) > mv_dblQtty Then
                    MsgBox(String.Format(mv_ResourceManager.GetString("ERR_NOT_ABL"), txtQuantity.Text), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
                    txtQuantity.Focus()
                    Return False
                End If
            End If
        Catch ex As Exception

        End Try
    End Function

    Private Function CheckPTREPO() As Boolean
        Try
            If Me.chkPTRepo.Checked And Me.mskREFORDERID.Text.Length > 0 Then
                Dim v_strObjMsg, v_strSQL, v_strClause, v_strValue As String
                Dim v_ws As New BDSDeliveryManagement
                Dim v_xmlDocument As New Xml.XmlDocument, v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
                Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode, v_intIndex As Long, x, y As Integer
                Dim v_strFLDNAME As String, v_strFLDDEFNAME As String, v_strDATATYPE As String, v_strFLDVALUE As String
                Dim v_strCUSTODYCD, v_strCODEID, v_strEXECTYPE, v_strSTATUS, v_strCONTRAFIRM As String
                Dim v_strGRPORDER As String = "N"
                Dim v_strEXECQTTY As String = "0"
                Dim v_dblORDERQTTY As Double = 0
                Dim v_strREF_CUSTODYCD As String = String.Empty
                'v_strSQL = "select tb.CUSTODYCD,tb.QUOTEPRICE,tb.CODEID,tb.ORDERQTTY,tb.PRICE2," & _
                '           " tb.EXPTDATE,tb.EXECTYPE,tb.STATUS,tb.ORDERID2,tb.REF_CUSTODYCD,tb.REF_AFACCTNO, od.CONTRAFIRM, OD.GRPORDER,OD.EXECQTTY  " & _
                '           " from tbl_odrepo TB, VW_ODMAST_ALL OD  where   tb.orderid = od.orderid and tb.orderid= '" & mskREFORDERID.Text & "'" & _
                '           " AND (CASE WHEN OD.GRPORDER ='Y' THEN 1 ELSE  OD.EXECQTTY END ) >0 " & _
                '           " AND (CASE WHEN OD.GRPORDER ='Y' THEN 'N' ELSE  OD.DELTD END )= 'N' "
                'v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SE_SEMAST, gc_ActionInquiry, v_strSQL)
                'v_ws.Message(v_strObjMsg)
                v_strSQL = "pr_CheckPTREPO"
                v_strClause = "pv_REFORDERID!" & mskREFORDERID.Text & "!varchar2!20^pv_FORM!" & "NML" & "!varchar2!20"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strSQL, v_strClause, , , , , , , gc_CommandProcedure)
                v_ws.Message(v_strObjMsg)
                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                If v_nodeList Is Nothing Or v_nodeList.Count < 1 Then
                    MsgBox(mv_ResourceManager.GetString("INVALID_REFORDERID"), MsgBoxStyle.Information, Me.Text)
                    Me.ActiveControl = Me.mskREFORDERID
                    Return False
                Else

                    ''Lay du lieu
                    For i As Integer = 0 To v_nodeList.Count - 1
                        For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                            With v_nodeList.Item(i).ChildNodes(j)
                                v_strValue = .InnerText.ToString
                                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                Select Case Trim(v_strFLDNAME)
                                    Case "CUSTODYCD"
                                        v_strCUSTODYCD = v_strValue
                                    Case "CODEID"
                                        v_strCODEID = v_strValue
                                    Case "EXECTYPE"
                                        v_strEXECTYPE = v_strValue
                                    Case "STATUS"
                                        v_strSTATUS = v_strValue
                                    Case "CONTRAFIRM"
                                        v_strCONTRAFIRM = v_strValue
                                    Case "GRPORDER"
                                        v_strGRPORDER = v_strValue
                                    Case "EXECQTTY"
                                        v_strEXECQTTY = v_strValue
                                    Case "REF_CUSTODYCD"
                                        v_strREF_CUSTODYCD = v_strValue
                                    Case "ORDERQTTY"
                                        v_dblORDERQTTY = v_strValue


                                End Select
                            End With
                        Next
                    Next

                    'Check so LK    
                    If Me.mv_strCUSTODYCD <> v_strCUSTODYCD Then
                        MsgBox(mv_ResourceManager.GetString("INVALID_CUSTODYCD"), MsgBoxStyle.Information, Me.Text)
                        Me.ActiveControl = Me.mskREFORDERID
                        Return False
                    End If
                    'Chek ma CK
                    If Me.cboCODEID.SelectedValue <> v_strCODEID Then
                        MsgBox(mv_ResourceManager.GetString("INVALID_CODEID"), MsgBoxStyle.Information, Me.Text)
                        Me.ActiveControl = Me.mskREFORDERID
                        Return False
                    End If
                    'Check Lenh nguoc chieu
                    If Me.cboExecType.SelectedValue = v_strEXECTYPE Then
                        MsgBox(mv_ResourceManager.GetString("INVALID_EXECTYPE"), MsgBoxStyle.Information, Me.Text)
                        Me.ActiveControl = Me.mskREFORDERID
                        Return False
                    End If

                    ''Chek chi duoc map vao 2firm
                    If v_strREF_CUSTODYCD.Length > 0 Then
                        MsgBox(mv_ResourceManager.GetString("INVALID_FIRM"), MsgBoxStyle.Information, Me.Text)
                        Me.ActiveControl = Me.mskREFORDERID
                        Return False
                    End If

                    'Chek khoi kuong
                    If txtQuantity.Text.Trim.Replace(",", "") <> v_dblORDERQTTY Then
                        MsgBox(mv_ResourceManager.GetString("INVALID_ORDERQTTY"), MsgBoxStyle.Information, Me.Text)
                        Me.ActiveControl = Me.mskREFORDERID
                        Return False
                    End If
                    ''Check trang thai
                    'If v_strSTATUS = "A" Then
                    '    MsgBox(mv_ResourceManager.GetString("INVALID_STATUS"), MsgBoxStyle.Information, Me.Text)
                    '    Me.ActiveControl = Me.mskREFORDERID
                    '    Return False
                    'End If
                End If
            End If
            Return True
        Catch ex As Exception

        End Try
    End Function
    Private Function CheckPTREPO_Submit2() As Boolean
        Try
            If Me.chkPTRepo.Checked And Me.mskREFORDERID.Text.Length > 0 Then
                Dim v_strObjMsg, v_strSQL, v_strClause, v_strValue As String
                Dim v_ws As New BDSDeliveryManagement
                Dim v_xmlDocument As New Xml.XmlDocument, v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
                Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode, v_intIndex As Long, x, y As Integer
                Dim v_strFLDNAME As String, v_strFLDDEFNAME As String, v_strDATATYPE As String, v_strFLDVALUE As String
                Dim v_strSTATUS, v_strORDERID, v_strDELTD, v_strGRPORDER, v_strGRPORDER2, v_strORSTATUS As String
                Dim v_dblEXECQTTY, v_dblCANCELQTTY, v_dblG_EXECQTTY, v_dblG_CANCELQTTY, v_dblG_EXECQTTY2, v_dblG_CANCELQTTY2, v_dblORDERQTTY2, v_dblADJUSTQTTY, v_dblREJECTQTTY As Double

                'v_strSQL = "SELECT TB.STATUS,OD.ORDERID, NVL(OD2.DELTD,'N') DELTD, NVL(OD2.EXECQTTY,0) EXECQTTY," & _
                '           " NVL(OD2.CANCELQTTY ,0) CANCELQTTY " & _
                '           " FROM VW_ODMAST_ALL OD,  TBL_ODREPO TB, VW_ODMAST_ALL OD2 " & _
                '           " WHERE OD.DELTD='N' AND OD.ORDERID = TB.ORDERID " & _
                '           " AND TB.ORDERID = '" & mskREFORDERID.Text & "' AND OD.EXECQTTY >0 " & _
                '           " AND OD.CANCELQTTY=0 " & _
                '           " AND TB.ORDERID2 = OD2.ORDERID (+) "
                'v_strSQL = "SELECT  tb.STATUS,OD.ORDERID, NVL(OD2.DELTD,' ') DELTD, " & _
                '           "   NVL(OD2.EXECQTTY,-1) EXECQTTY, NVL(OD2.CANCELQTTY ,-1) CANCELQTTY ," & _
                '           "  nvl(od2.orderqtty,-1) orderqtty2, " & _
                '           "  NVL(OD2.ADJUSTQTTY ,-1) ADJUSTQTTY, NVL(OD2.REJECTQTTY ,-1) REJECTQTTY, NVL(OD2.ORSTATUS ,'') ORSTATUS, " & _
                '           "   NVL(OD3.EXECQTTY,-1) G_EXECQTTY, NVL(OD3.CANCELQTTY ,-1) G_CANCELQTTY ,  " & _
                '           "   NVL(OD4.EXECQTTY,-1) G_EXECQTTY2, NVL(OD4.CANCELQTTY ,-1) G_CANCELQTTY2 , " & _
                '           "   TB.orderqtty, OD.GRPORDER,  " & _
                '           "    NVL(OD2.GRPORDER,' ') GRPORDER2   " & _
                '            "  FROM VW_ODMAST_ALL OD,  TBL_ODREPO TB,  " & _
                '            "  VW_ODMAST_ALL OD2,  " & _
                '            "  (SELECT SUM (orderqtty) orderqtty,sum(execqtty) execqtty, " & _
                '             " sum(cancelqtty) cancelqtty ,voucher  " & _
                '            "  FROM VW_ODMAST_ALL WHERE LENGTH(voucher) =16 AND deltd='N' GROUP BY voucher) OD3, " & _
                '             " (SELECT SUM (orderqtty) orderqtty,sum(execqtty) execqtty, " & _
                '             " sum(cancelqtty) cancelqtty ,voucher  " & _
                '           " FROM VW_ODMAST_ALL WHERE LENGTH(voucher) =16 AND deltd='N' GROUP BY voucher) OD4 " & _
                '           " WHERE OD.ORDERID = TB.ORDERID   AND TB.ORDERID = '" & mskREFORDERID.Text & "' " & _
                '           " AND (CASE WHEN OD.GRPORDER ='Y' THEN 1 ELSE  OD.EXECQTTY END ) >0 " & _
                '           " AND (CASE WHEN OD.GRPORDER ='Y' THEN 0 ELSE  OD.CANCELQTTY END )=0  " & _
                '           " AND (CASE WHEN OD.GRPORDER ='Y' THEN 'N' ELSE  OD.DELTD END )= 'N' " & _
                '           " AND TB.ORDERID2 = OD2.ORDERID (+) " & _
                '           " AND tb.orderid =  OD3.voucher (+) " & _
                '           " AND tb.orderid2 =  OD4.voucher (+)"

                'v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SE_SEMAST, gc_ActionInquiry, v_strSQL)
                'v_ws.Message(v_strObjMsg)
                v_strSQL = "pr_CheckPTREPO_Submit2"
                v_strClause = "pv_REFORDERID!" & mskREFORDERID.Text & "!varchar2!20^pv_FORM!" & "NML" & "!varchar2!20"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strSQL, v_strClause, , , , , , , gc_CommandProcedure)
                v_ws.Message(v_strObjMsg)

                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                If v_nodeList Is Nothing Or v_nodeList.Count < 1 Then
                    MsgBox(mv_ResourceManager.GetString("INVALID_REFORDERID"), MsgBoxStyle.Information, Me.Text)
                    Me.ActiveControl = Me.mskREFORDERID
                    Return False
                Else
                    ''Lay du lieu
                    For i As Integer = 0 To v_nodeList.Count - 1
                        For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                            With v_nodeList.Item(i).ChildNodes(j)
                                v_strValue = .InnerText.ToString
                                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                Select Case Trim(v_strFLDNAME)
                                    Case "STATUS"
                                        v_strSTATUS = v_strValue
                                    Case "ORDERID"
                                        v_strORDERID = v_strValue
                                    Case "DELTD"
                                        v_strDELTD = v_strValue
                                    Case "ORSTATUS"
                                        v_strORSTATUS = v_strValue
                                    Case "EXECQTTY"
                                        v_dblEXECQTTY = v_strValue
                                    Case "CANCELQTTY"
                                        v_dblCANCELQTTY = v_strValue
                                    Case "GRPORDER"
                                        v_strGRPORDER = v_strValue
                                    Case "GRPORDER2"
                                        v_strGRPORDER2 = v_strValue
                                    Case "G_EXECQTTY"
                                        v_dblG_EXECQTTY = v_strValue
                                    Case "G_CANCELQTTY"
                                        v_dblG_CANCELQTTY = v_strValue
                                    Case "G_EXECQTTY2"
                                        v_dblG_EXECQTTY2 = v_strValue
                                    Case "G_CANCELQTTY2"
                                        v_dblG_CANCELQTTY2 = v_strValue
                                    Case "ORDERQTTY2"
                                        v_dblORDERQTTY2 = v_strValue
                                    Case "ADJUSTQTTY"
                                        v_dblADJUSTQTTY = v_strValue
                                    Case "REJECTQTTY"
                                        v_dblREJECTQTTY = v_strValue
                                End Select
                            End With
                        Next
                    Next


                    'Check trang thai
                    If v_strGRPORDER = "N" Then
                        'Neu la lenh thuong
                        If v_strSTATUS = "A" Then
                            If v_strDELTD = "N" Then

                                If v_dblCANCELQTTY = 0 And v_strORSTATUS <> "5" Then
                                    MsgBox(mv_ResourceManager.GetString("INVALID_STATUS"), MsgBoxStyle.Information, Me.Text)
                                    Me.ActiveControl = Me.mskREFORDERID
                                    Return False
                                End If
                                'Lenh lan hai da huy 1 phan
                                If v_dblCANCELQTTY + v_dblADJUSTQTTY + v_dblREJECTQTTY > 0 And v_dblCANCELQTTY + v_dblADJUSTQTTY + v_dblREJECTQTTY <> v_dblORDERQTTY2 Then
                                    MsgBox(mv_ResourceManager.GetString("INVALID_STATUS"), MsgBoxStyle.Information, Me.Text)
                                    Me.ActiveControl = Me.mskREFORDERID
                                    Return False
                                End If
                            End If
                        End If
                    Else ''Lenh tong
                        If v_strSTATUS = "A" Then
                            If v_dblCANCELQTTY > 0 Then
                                'Lenh goc da huy
                                If v_dblG_CANCELQTTY2 = 0 Then
                                    MsgBox(mv_ResourceManager.GetString("INVALID_STATUS"), MsgBoxStyle.Information, Me.Text)
                                    Me.ActiveControl = Me.mskREFORDERID
                                    Return False
                                End If
                            Else
                                If v_strDELTD = "N" And v_dblCANCELQTTY = 0 Then
                                    MsgBox(mv_ResourceManager.GetString("INVALID_STATUS"), MsgBoxStyle.Information, Me.Text)
                                    Me.ActiveControl = Me.mskREFORDERID
                                    Return False
                                End If
                            End If
                        End If
                    End If


                End If
            End If
            Return True

        Catch ex As Exception

        End Try
    End Function

    Private Function CheckBlockSellQuantity() As Boolean
        Dim v_strObjMsg, v_strSQL, v_strValue As String
        Dim v_ws As New BDSDeliveryManagement
        Dim v_xmlDocument As New Xml.XmlDocument, v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
        Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode, v_intIndex As Long, x, y As Integer
        Dim v_strFLDNAME As String, v_strFLDDEFNAME As String, v_strDATATYPE As String, v_strFLDVALUE As String
        Dim v_TradingQtty As Double
        If Trim(Me.txtDealNO.Text) Is Nothing Then
            MsgBox(mv_ResourceManager.GetString("INVALIDDEALNO"), MsgBoxStyle.Information, Me.Text)
            Me.ActiveControl = Me.btnGetDeal
            Return False
        End If

        v_strSQL = "select DFTRADING from v_getDealInfo where acctno= '" & (Me.txtDealNO.Text) & "'"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SE_SEMAST, gc_ActionInquiry, v_strSQL)
        v_ws.Message(v_strObjMsg)
        v_xmlDocument.LoadXml(v_strObjMsg)
        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
        If v_nodeList Is Nothing Or v_nodeList.Count < 1 Then
            MsgBox(mv_ResourceManager.GetString("INVALIDDEALNO"), MsgBoxStyle.Information, Me.Text)
            Me.ActiveControl = Me.btnGetDeal
            Return False
        Else
            For x = 0 To v_nodeList.Count - 1
                For y = 0 To v_nodeList.Item(x).ChildNodes.Count - 1
                    With v_nodeList.Item(x).ChildNodes(y)
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "DFTRADING"
                                If Not (v_strValue Is Nothing) Then
                                    v_TradingQtty = Trim(v_strValue)
                                End If
                        End Select
                    End With
                Next
            Next
            If v_TradingQtty < CDbl(Me.txtQuantity.Text) Then
                MsgBox(mv_ResourceManager.GetString("INVALIDDEALQTTY"), MsgBoxStyle.Information, Me.Text)
                Me.ActiveControl = Me.txtQuantity
                Return False
            End If

        End If
        Return True
    End Function

    Private Function CheckTradeBuySell() As Boolean
        Try
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_lngError As Long = ERR_SYSTEM_OK
            Dim v_strObjMsg As String
            Dim v_ds As DataSet
            Dim v_dr As DataRow
            Dim v_dc_1, v_dc_2, v_dc_3 As DataColumn
            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If
            v_ds = New DataSet("INPUT")
            v_ds.Tables.Add("ODMAST")

            If CStr(Me.cboTimeType.SelectedValue).Trim().ToUpper() = "G" Then
                'Lenh good till cancel cho qua
                Return True
            End If

            If Not (cboCODEID Is Nothing Or mskAFACCTNO Is Nothing) Then
                If CStr(cboCODEID.SelectedValue).Length > 0 And mskAFACCTNO.Text.Trim.Length > 0 Then

                    v_strObjMsg = BuildXMLObjMsg(Now.Date, BranchId, Now.Date, TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "CheckTradeBuySell")

                    v_ds.Tables(0).BeginInit()
                    v_dc_1 = New DataColumn("01") 'CODEID
                    v_dc_1.DataType = GetType(String)
                    v_ds.Tables(0).Columns.Add(v_dc_1)

                    v_dc_2 = New DataColumn("03") 'AFACCTNO
                    v_dc_2.DataType = GetType(String)
                    v_ds.Tables(0).Columns.Add(v_dc_2)
                    '

                    v_dc_3 = New DataColumn("22") 'EXECTYPE
                    v_dc_3.DataType = GetType(String)
                    v_ds.Tables(0).Columns.Add(v_dc_3)

                    'Add new row
                    v_dr = v_ds.Tables(0).NewRow()

                    v_dr("01") = cboCODEID.SelectedValue
                    v_dr("03") = mskAFACCTNO.Text.Trim
                    v_dr("22") = cboExecType.SelectedValue

                    v_ds.Tables(0).Rows.Add(v_dr)
                    v_ds.Tables(0).EndInit()

                    BuildXMLObjData(v_ds, v_strObjMsg)
                    v_lngError = v_ws.Message(v_strObjMsg)

                    If v_lngError <> ERR_SYSTEM_OK Then
                        MessageBox.Show(mv_ResourceManager.GetString("INV_TRADEBUYSELL"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.txtDescription.Text = "Orders making"
                        cboExecType.Enabled = True
                        cboExecType.Focus()
                        Return False
                    End If
                End If
            End If
            Return True
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function

    Private Function CheckSETickSize() As Boolean
        Dim v_strObjMsg As String
        Dim v_nodeList As Xml.XmlNodeList
        Dim XmlDocument As New Xml.XmlDocument
        Dim v_int, v_intCount, v_intIndex As Integer
        Dim v_decPrice As Decimal
        Dim v_strSQL As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_lngError As Long
        Dim v_strErrorSource, v_strErrorMessage As String

        Try
            'Lenh putthough khong check ticksize
            If Me.cboMatchType.SelectedValue <> "P" Then 'Or txtTradePalce.Text = gc_TRADEPLACE_UPCOM Then
                v_decPrice = CDec(txtQuotePrice.Text) * mv_dblTradeUnit
                v_strSQL = "SELECT FROMPRICE, TOPRICE, TICKSIZE FROM SECURITIES_TICKSIZE WHERE CODEID = '" & cboCODEID.SelectedValue & "' AND (FROMPRICE<=" & v_decPrice & " AND TOPRICE>=" & v_decPrice & " ) AND MOD(" & v_decPrice & ",TICKSIZE) = 0"

                v_strObjMsg = BuildXMLObjMsg(Now.Date, BranchId, Now.Date, _
                    TellerId, gc_IsLocalMsg, gc_MsgTypeObj, _
                    OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, v_strSQL, , "CheckSETickSize")

                v_lngError = v_ws.Message(v_strObjMsg)

                If v_lngError <> ERR_SYSTEM_OK Then
                    'Thông báo lỗi
                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                    Cursor.Current = Cursors.Default

                    MessageBox.Show(v_strErrorMessage, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtQuotePrice.Focus()
                    Return False
                    Exit Function
                End If
            End If
            Return True
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function
    Private Function CheckSETickSize_1() As Boolean
        Dim v_strObjMsg As String
        Dim v_nodeList As Xml.XmlNodeList
        Dim XmlDocument As New Xml.XmlDocument
        Dim v_int, v_intCount, v_intIndex As Integer
        Dim v_decPrice As Decimal
        Dim v_strSQL As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_lngError As Long
        Dim v_strErrorSource, v_strErrorMessage As String

        Try
            'Lenh putthough khong check ticksize
            If Me.cboMatchType.SelectedValue <> "P" Or txtTradePalce.Text = gc_TRADEPLACE_UPCOM Then
                v_decPrice = CDec(txtLimitPrice.Text) * mv_dblTradeUnit
                v_strSQL = "SELECT FROMPRICE, TOPRICE, TICKSIZE FROM SECURITIES_TICKSIZE WHERE CODEID = '" & cboCODEID.SelectedValue & "' AND (FROMPRICE<=" & v_decPrice & " AND TOPRICE>=" & v_decPrice & " ) AND MOD(" & v_decPrice & ",TICKSIZE) = 0"
                v_strObjMsg = BuildXMLObjMsg(Now.Date, BranchId, Now.Date, _
                    TellerId, gc_IsLocalMsg, gc_MsgTypeObj, _
                    OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, v_strSQL, , "CheckSETickSize")

                v_lngError = v_ws.Message(v_strObjMsg)

                If v_lngError <> ERR_SYSTEM_OK Then
                    'Thông báo lỗi
                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                    Cursor.Current = Cursors.Default

                    MessageBox.Show(v_strErrorMessage, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtLimitPrice.Focus()
                    Return False
                    Exit Function
                End If
            End If
            Return True
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function
    Private Sub GetTellerCareBy()
        Dim v_strObjMsg As String
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strValue, v_strFLDNAME, v_strdsValue, v_strdsName, v_strCareByList As String

        v_strObjMsg = BuildXMLObjMsg(Now.Date, BranchId, Now.Date, _
            TellerId, gc_IsLocalMsg, gc_MsgTypeObj, _
            OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "GetGroupCareBy")
        v_ws.Message(v_strObjMsg)

        v_xmlDocument.LoadXml(v_strObjMsg)
        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
        For i As Integer = 0 To v_nodeList.Count - 1
            For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                With v_nodeList.Item(i).ChildNodes(j)
                    v_strValue = Trim(.InnerText.ToString)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    Select Case Trim(v_strFLDNAME)
                        Case "DISPLAY"
                            v_strdsName = v_strValue
                        Case "VALUE"
                            v_strdsValue = v_strValue
                    End Select
                End With
            Next
            v_strCareByList &= v_strdsValue & "|" & v_strdsName & "#"
        Next

        If Len(v_strCareByList) > 0 Then
            mv_GroupCareBy = v_strCareByList
        End If
    End Sub

    'Hàm này được dùng để hiển thị lại điện giao dịch trả v? t�ừ trên HOST đối với giao dịch Submit 02 lần
    Private Sub DisplayConfirm() '(ByVal v_xmlDocument As Xml.XmlDocument) As Boolean
        Try
            'Dim v_dataElement As Xml.XmlElement, v_nodetxData As Xml.XmlNode, v_ctl As Control, v_objAccount As CAccountEntry
            'Dim v_strPRINTINFO, v_strPRINTNAME, v_strPRINTVALUE, v_strFLDNAME As String, i, j, v_intIndex As Integer
            'Hiển thị lại màn hình
            Me.mskAFACCTNO.Enabled = False
            'Me.pnOrder.Enabled = False
            'Me.lblOrderID.ForeColor = System.Drawing.Color.Red

            Me.pnOrder.Visible = False
            Me.pnOrderConfirm.Visible = True
            Me.pnOrderConfirm.Width = Me.pnOrder.Width
            Me.pnOrderConfirm.Height = Me.pnOrder.Height
            Me.pnOrderConfirm.Top = Me.pnOrder.Top
            Me.pnOrderConfirm.Left = Me.pnOrder.Left

            If mv_blnIsDelete Then
                Me.lblOriginalConfirm.Visible = True
                lblOriginalConfirm.TextAlign = ContentAlignment.MiddleCenter
                lblOriginalConfirm.Top = pnOrderConfirm.Top
                lblOriginalConfirm.Dock = DockStyle.Top
                lblOriginalConfirm.Width = 40
                'If mv_strOldPriceType = "Limit Order" Then
                '    lblOriginalConfirm.Text = "Original (KL:" & mv_dblQtty & " | Giá:" & mv_dblPrice & ")"
                'ElseIf mv_strOldPriceType = "Stop Limit" Then
                '    'lblOriginalConfirm.Text = "Original (Qtty:" & mv_dblOldQtty & " | Price:" & mv_dblOldPrice & ")"
                '    lblOriginalConfirm.Text = "Original (KL:" & mv_dblQtty & " | Giá:" & mv_dblPrice & " | SP:" & mv_dblStopPrice & ")"
                'Else
                '    If Me.cboPriceType.SelectedValue = "SL" Then
                '        lblOriginalConfirm.Text = "Original (Qtty:" & mv_dblOldQtty & " | Price:" & mv_dblOldPrice & " | SP: " & mv_dblOldStopPrice & ")"
                '    Else
                '        lblOriginalConfirm.Text = "Original (Qtty:" & mv_dblOldQtty & " | Price:" & mv_dblOldPrice & ")"
                '    End If

                'End If
                Dim v_tradeplace() As String = {"ATO", "ATC", "MOK", "MP", "MAK", "MTL", "OBO", "SBO"}
                Dim v_isATO As Boolean = False
                For i As Integer = 0 To v_tradeplace.Length() - 1
                    If mv_strOldPriceType = v_tradeplace(i) Then
                        i = v_tradeplace.Length + 1
                        v_isATO = True
                        lblOriginalConfirm.Text = "Original (KL:" & mv_dblOldQtty.ToString("0,0") & " | Giá:" & cboPriceType.Text & ")"
                    End If
                Next
                If Not v_isATO Then
                    lblOriginalConfirm.Text = "Original (KL:" & mv_dblOldQtty.ToString("0,0") & " | Giá:" & mv_dblOldPrice.ToString("0,0") & ")"
                End If




                lblDelete.Width = pnOrderConfirm.Width
                lblDelete.TextAlign = ContentAlignment.MiddleLeft
                If mv_blnAmendment Then
                    lblDelete.Text = "Amend " & Strings.Left(mskOrderID.Text, 4) & "." & Strings.Mid(mskOrderID.Text, 5, 6) & "." & Strings.Right(mskOrderID.Text, 6)
                Else
                    lblDelete.Text = "Cancel " & Strings.Left(mskOrderID.Text, 4) & "." & Strings.Mid(mskOrderID.Text, 5, 6) & "." & Strings.Right(mskOrderID.Text, 6)
                End If
                lblOrderID.Visible = True
                mskOrderID.Visible = False
            Else
                lblDelete.Text = ""
            End If

            'Dim v_strPrice As String = FormatNumber(txtQuotePrice.Text, 1)
            Dim v_strPrice As String = mv_dblPrice
            'Neu lenh thua thuan lay 6 so thap phan
            If InStr(CStr(cboMatchType.SelectedValue), "P") > 0 Then
                If mv_dblView_TradeUnit > 1 Then
                    v_strPrice = FormatNumber(CDbl(txtQuotePrice.Text) * mv_dblView_TradeUnit, 6)
                Else
                    v_strPrice = FormatNumber(txtQuotePrice.Text, 6) '24/05/216 DieuNDA thay 1 thanh 3 sua ETF
                End If

            Else
                v_strPrice = FormatNumber(txtQuotePrice.Text, 6)
            End If
            If cboPriceType.SelectedIndex > 0 Then
                v_strPrice = cboPriceType.SelectedValue
            End If

            If InStr(CStr(cboMatchType.SelectedValue), "P") > 0 Then
                lblConfirmClear.Visible = True
                lblConfirmClear.Text = "Settlement Cycle: " & txtClearingDay.Text
                lblConfirmClear.Width = pnOrderConfirm.Width - 10
                lblConfirmClear.TextAlign = ContentAlignment.MiddleRight
                If Not mv_blnIsDelete Then
                    lblConfirmDes.Visible = True
                    lblConfirmDes.Text = txtDescription.Text
                    lblConfirmDes.Width = pnOrderConfirm.Width - 10
                    lblConfirmDes.TextAlign = ContentAlignment.MiddleRight
                End If
                'lblConfirm.Font = New System.Drawing.Font("Tahoma", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                lblConfirm.Text = "P." & cboExecType.Text & " | " & cboCODEID.Text & " | KL: " & FormatNumber(txtQuantity.Text, 0) & " | Giá: " & v_strPrice
                'lblConfirm.Font = New System.Drawing.Font("Tahoma", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Else
                If Me.cboTimeType.SelectedValue <> "T" Then
                    lblConfirmClear.Visible = True
                    lblConfirmClear.Text = "Hiệu lực: " & cboTimeType.Text & " | " & "ACM:" & IIf(Me.chkOUTPRICEALLOW.Checked, "Yes", "No")
                    lblConfirmClear.Width = pnOrderConfirm.Width - 10
                    lblConfirmClear.TextAlign = ContentAlignment.MiddleRight
                    lblConfirmDes.Visible = True
                    lblConfirmDes.Text = "Effective:" & Me.dtpEffectiveDate.Text & "  Expired:" & Me.dtpExpiredDate.Text
                    lblConfirmDes.Width = pnOrderConfirm.Width - 10
                    lblConfirmDes.TextAlign = ContentAlignment.MiddleRight
                Else
                    lblConfirmClear.Visible = True
                    lblConfirmClear.Text = "Hiệu lực: " & cboTimeType.Text
                    lblConfirmClear.Width = pnOrderConfirm.Width - 10
                    lblConfirmClear.TextAlign = ContentAlignment.MiddleRight
                    lblConfirmDes.Visible = False
                End If
                'If mv_blnIsDelete = False Then
                '    lblConfirm.Text = cboExecType.Text & " | " & cboCODEID.Text & " | KL: " & FormatNumber(txtQuantity.Text, 0) & " | Giá: " & IIf(cboPriceType.SelectedValue = "SL", Me.txtQuotePrice.Text & " | SP: " & Me.txtLimitPrice.Text, v_strPrice)
                'Else
                '    lblConfirm.Text = cboExecType.Text & " | " & cboCODEID.Text & " | KL hủy: " & FormatNumber(mv_dblRemainQtty, 0) & " | Giá: " & IIf(cboPriceType.SelectedValue = "SL", Me.txtQuotePrice.Text & " | SP: " & Me.txtLimitPrice.Text, v_strPrice)
                'End If
                Dim v_tempPricetype As String = ""
                Dim v_tempQuoteQtty As String = ""
                Dim v_tempLimitPrice As String = ""
                Select Case cboPriceType.Text
                    Case "ATO", "ATC", "MP", "MOK", "MAK", "PLO"
                        v_tempPricetype = cboPriceType.Text
                    Case "MTL", "OBO", "SBO"
                        If mv_blnOODSTATUS <> "S" Then
                            v_tempPricetype = cboPriceType.Text
                        ElseIf mv_blnOODSTATUS = "S" Then
                            If mv_blnIsDelete And Not mv_blnAmendment Then
                                v_tempPricetype = cboPriceType.SelectedValue & " - " & FormatNumber(mv_dblOldPrice, 3, TriState.True, TriState.True, TriState.True)
                            Else
                                v_tempPricetype = cboPriceType.SelectedValue & " - " & FormatNumber(txtQuotePrice.Text, 3, TriState.True, TriState.True, TriState.True)
                            End If
                        End If
                    Case Else
                        If mv_blnIsDelete And Not mv_blnAmendment Then
                            v_tempPricetype = cboPriceType.SelectedValue & " - " & FormatNumber(mv_dblOldPrice, 3, TriState.True, TriState.True, TriState.True)
                        Else
                            v_tempPricetype = cboPriceType.SelectedValue & " - " & FormatNumber(txtQuotePrice.Text, 3, TriState.True, TriState.True, TriState.True) '24/05/216 DieuNDA thay 1 thanh 3 sua ETF
                        End If
                End Select

                If Not mv_blnIsDelete Then
                    lblConfirm.Text = cboExecType.Text & " | " & cboCODEID.Text & " | KL: " & FormatNumber(txtQuantity.Text, 0) & " | Giá: " & v_tempPricetype & v_tempLimitPrice & v_tempQuoteQtty
                ElseIf Not mv_blnAmendment Then
                    'lblConfirm.Text = cboExecType.Text & " | " & cboCODEID.Text & " | KL h?y: " & FormatNumber(mv_dblRemainQtty, 0) & " | Giá: " & IIf(cboPriceType.SelectedValue = "SL", Me.txtQuotePrice.Text & " | SP: " & Me.txtLimitPrice.Text, v_strPrice)
                    lblConfirm.Text = cboExecType.Text & " | " & cboCODEID.Text & " | KL hủy: " & FormatNumber(CDbl(mv_dblOldQtty), 0) & " | Giá: " & v_tempPricetype & v_tempLimitPrice & v_tempQuoteQtty
                Else
                    lblConfirm.Text = cboExecType.Text & " | " & cboCODEID.Text & " | KL sửa: " & FormatNumber(CDbl(txtQuantity.Text), 0) & " | Giá: " & v_tempPricetype & v_tempLimitPrice & v_tempQuoteQtty
                End If



            End If

            lblConfirm.Width = pnOrderConfirm.Width
            lblConfirm.TextAlign = ContentAlignment.MiddleCenter

            lblConfirmName.Width = pnOrderConfirm.Width
            lblConfirmName.TextAlign = ContentAlignment.MiddleCenter

            lblConfirmSEName.Text = lblSEName.Text
            lblConfirmSEName.Width = pnOrderConfirm.Width
            lblConfirmSEName.TextAlign = ContentAlignment.MiddleCenter

            If InStr(cboExecType.Text, "Mua") > 0 Then
                lblConfirm.ForeColor = System.Drawing.Color.Blue
                lblConfirmName.ForeColor = System.Drawing.Color.Blue
                lblConfirmSEName.ForeColor = System.Drawing.Color.Blue
                lblDelete.ForeColor = System.Drawing.Color.Red
                lblConfirmClear.ForeColor = System.Drawing.Color.Blue
                lblConfirmDes.ForeColor = System.Drawing.Color.Blue
            Else
                lblConfirm.ForeColor = System.Drawing.Color.Red
                lblConfirmName.ForeColor = System.Drawing.Color.Red
                lblConfirmSEName.ForeColor = System.Drawing.Color.Red
                lblDelete.ForeColor = System.Drawing.Color.Blue
                lblConfirmClear.ForeColor = System.Drawing.Color.Red
                lblConfirmDes.ForeColor = System.Drawing.Color.Red
            End If

            'Return True
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Protected Overridable Function InitDialog()
        Try
            'Khởi tạo kích thước form và load resource
            mv_dblOnload = True
            mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
            LoadResource(Me)
            'TungNT added
            GetTellerCareBy()
            'End

            If UpcomOrder Then
                ViewDetail(False)
            Else
                ViewDetail(True)
            End If
            If Not CheckDate() Then
                MessageBox.Show(mv_ResourceManager.GetString("TxDateBusDate"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                OnClose()
                Exit Function
            End If
            ResetScreen(Me)

            'Khởi tạo Grid Member
            InitExternal()
            Me.btnAmendment.Visible = False
            Me.mskAFACCTNO.BackColor = System.Drawing.Color.GreenYellow
            Me.mskAFACCTNO.Mask = "9999.999999"
            Me.mskAFACCTNO.MaskCharInclude = False

            Me.mskOrderID.BackColor = System.Drawing.Color.GreenYellow
            Me.mskOrderID.Mask = "9999.999999.999999"
            Me.mskOrderID.MaskCharInclude = False
            Me.mskOrderID.Left = Me.lblOrderID.Left
            Me.mskOrderID.Top = Me.lblOrderID.Top
            Me.mskOrderID.Visible = False

            Me.txtContraCus.BackColor = System.Drawing.Color.GreenYellow
            Me.txtContraCus.Mask = "9999.999999.999999"
            'Thiết lập các thuộc tính ban đầu cho form
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_strCmdSQL As String, v_strObjMsg As String
            'PhuongHT edit: full cac loai lenh de view lai message
            v_strCmdSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, LSTODR FROM ALLCODE WHERE CDTYPE='OD' AND CDNAME='PRICETYPE' AND  CDUSER='Y' ORDER BY LSTODR"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            mv_strObjFullPricetypeMessage = v_strObjMsg
            ' end of PhuongHT edit
            v_strCmdSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, LSTODR FROM ALLCODE WHERE CDTYPE='OD' AND CDNAME='EXECTYPE' ORDER BY LSTODR"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            mv_strObjFullExectypeMessage = v_strObjMsg
            v_strCmdSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, LSTODR FROM ALLCODE WHERE CDTYPE='OD' AND CDNAME='EXECTYPE' AND  CDVAL NOT IN ('CB','CS','AB','AS') AND CDUSER='Y' ORDER BY LSTODR"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            FillComboEx(v_strObjMsg, cboExecType, "", Me.UserLanguage)
            If UpcomOrder Then
                v_strCmdSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, LSTODR FROM ALLCODE WHERE CDTYPE='OD' AND CDNAME='MATCHTYPE' AND CDVAL='P' ORDER BY LSTODR"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
                v_ws.Message(v_strObjMsg)
                FillComboEx(v_strObjMsg, cboMatchType, "", Me.UserLanguage)
            Else
                v_strCmdSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, LSTODR FROM ALLCODE WHERE CDTYPE='OD' AND CDNAME='MATCHTYPE' ORDER BY LSTODR"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
                v_ws.Message(v_strObjMsg)
                FillComboEx(v_strObjMsg, cboMatchType, "", Me.UserLanguage)
            End If

            If UpcomOrder Then
                v_strCmdSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, LSTODR FROM ALLCODE WHERE CDTYPE='OD' AND CDNAME='PRICETYPE' AND CDVAL='LO'  ORDER BY LSTODR"
                ' v_strCmdSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, LSTODR FROM ALLCODE WHERE CDTYPE='OD' AND CDNAME='PRICETYPE' AND CDUSER = 'Y' AND CDVAL <> 'MP'  ORDER BY LSTODR"
            Else
                'v_strCmdSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, LSTODR FROM ALLCODE WHERE CDTYPE='OD' AND CDNAME='PRICETYPE' ORDER BY LSTODR"
                v_strCmdSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, LSTODR FROM ALLCODE WHERE CDTYPE='OD' AND CDNAME='PRICETYPE' AND CDUSER = 'Y' AND CDVAL IN ('MP','ATO','ATC','LO','PLO') ORDER BY LSTODR"
            End If

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            mv_strHOPriceTypeMessage = v_strObjMsg
            'v_strCmdSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, LSTODR FROM ALLCODE WHERE CDTYPE='OD' AND CDNAME='PRICETYPE' AND CDVAL IN ('LO','SL') ORDER BY LSTODR"
            If UpcomOrder Then
                v_strCmdSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, LSTODR FROM ALLCODE WHERE CDTYPE='OD' AND CDNAME='PRICETYPE' AND CDVAL='LO'  ORDER BY LSTODR"
                'v_strCmdSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, LSTODR FROM ALLCODE WHERE CDTYPE='OD' AND CDNAME='PRICETYPE' AND CDUSER = 'Y' AND CDVAL <> 'MP'  ORDER BY LSTODR"
            Else
                'v_strCmdSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, LSTODR FROM ALLCODE WHERE CDTYPE='OD' AND CDNAME='PRICETYPE' AND CDVAL IN ('LO','SL') ORDER BY LSTODR"
                v_strCmdSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, LSTODR FROM ALLCODE WHERE CDTYPE='OD' AND CDNAME='PRICETYPE' AND CDUSER = 'Y' AND CDVAL not in  ('MP','ATO') ORDER BY LSTODR"
            End If
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            mv_strHAPriceTypeMessage = v_strObjMsg
            FillComboEx(mv_strHOPriceTypeMessage, cboPriceType, "", Me.UserLanguage)

            v_strCmdSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, LSTODR FROM ALLCODE WHERE CDTYPE='OD' AND CDNAME='TIMETYPE' and cdval <> 'G' ORDER BY LSTODR"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            FillComboEx(v_strObjMsg, cboTimeType, "", Me.UserLanguage)

            v_strCmdSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, LSTODR FROM ALLCODE WHERE CDTYPE='OD' AND CDNAME='VOUCHER' ORDER BY LSTODR"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            FillComboEx(v_strObjMsg, cboVoucher, "", Me.UserLanguage)

            v_strCmdSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, LSTODR FROM ALLCODE WHERE CDTYPE='OD' AND CDNAME='CLEARCD' ORDER BY LSTODR"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            FillComboEx(v_strObjMsg, cboCalendar, "", Me.UserLanguage)

            v_strCmdSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, LSTODR FROM ALLCODE WHERE CDTYPE='OD' AND CDNAME='CONSULTANT' ORDER BY LSTODR"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            FillComboEx(v_strObjMsg, cboConsultant, "", Me.UserLanguage)

            If UpcomOrder Then
                v_strCmdSQL = "SELECT CODEID VALUE, SYMBOL DISPLAY FROM SBSECURITIES where HALT <> 'Y' AND  SECTYPE <>'004' AND TRADEPLACE='005'  ORDER BY DISPLAY"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
                v_ws.Message(v_strObjMsg)
                SYMBOLLIST = v_strObjMsg
                FillComboEx(SYMBOLLIST, cboCODEID, "", Me.UserLanguage)
            Else


                If SYMBOLLIST.Length <= 0 Then

                    Dim v_arrParam As String() = mv_InitParam.Split("|".ToCharArray())
                    Dim v_arrParamVal As String()
                    If v_arrParam.GetLength(0) > 0 Then
                        Try
                            For i As Integer = 0 To v_arrParam.GetLength(0) - 1
                                v_arrParamVal = v_arrParam(i).Split("#".ToCharArray())
                                If v_arrParamVal.GetLength(0) = 2 Then
                                    If v_arrParam(i).IndexOf("SYMBOL") >= 0 Then
                                        'Dim v_ds As DataTable = cboCODEID.ComboSource
                                        Dim v_ds As DataTable = cboCODEID.DataSource
                                        Dim v_CodeID As String = ""
                                        'For j As Integer = 0 To v_ds.Rows.Count - 1
                                        '    If CStr(v_ds.Rows(j)("DISPLAY")).ToUpper().Trim() = v_arrParamVal(1).ToUpper().Trim() Then
                                        '        v_CodeID = CStr(v_ds.Rows(j)("VALUE"))
                                        '        Exit For
                                        '    End If
                                        'Next
                                        'cboCODEID.SelectedValue = v_CodeID
                                        v_strCmdSQL = "SELECT CODEID VALUE, SYMBOL DISPLAY FROM SBSECURITIES where HALT <> 'Y' AND  SECTYPE <>'004' AND TRADEPLACE <>'006'  AND SYMBOL = '" & v_arrParamVal(1).ToUpper().Trim() & "' ORDER BY DISPLAY"
                                        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
                                        v_ws.Message(v_strObjMsg)
                                        SYMBOLLIST = v_strObjMsg
                                        FillComboEx(SYMBOLLIST, cboCODEID, "", Me.UserLanguage)
                                    End If
                                Else
                                    v_strCmdSQL = "SELECT CODEID VALUE, SYMBOL DISPLAY FROM SBSECURITIES where HALT <> 'Y' AND  SECTYPE <>'004' AND TRADEPLACE <>'006'  ORDER BY DISPLAY"
                                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
                                    v_ws.Message(v_strObjMsg)
                                    SYMBOLLIST = v_strObjMsg
                                    FillComboEx(SYMBOLLIST, cboCODEID, "", Me.UserLanguage)
                                End If
                            Next
                        Catch ex As Exception
                            Throw ex
                        End Try

                    Else

                    End If
                Else
                    cboCODEID.DataSource = mv_SymbolTalble
                    cboCODEID.DisplayMember = "DISPLAY"
                    cboCODEID.ValueMember = "VALUE"
                End If

            End If


            v_strCmdSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, LSTODR FROM ALLCODE WHERE CDTYPE='OD' AND CDNAME='VIA'  AND CDVAL IN ('F','T') ORDER BY LSTODR"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            FillComboEx(v_strObjMsg, cboVia, "", Me.UserLanguage)

            If UpcomOrder Then
                v_strCmdSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, LSTODR FROM ALLCODE WHERE CDTYPE='OD' AND CDNAME='PUTTYPE'  ORDER BY LSTODR"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
                v_ws.Message(v_strObjMsg)
                FillComboEx(v_strObjMsg, cboPutType, "", Me.UserLanguage)
            End If

            'Cho hiển thị giá trị mặc định
            If cboExecType.Items.Count > 0 Then cboExecType.SelectedIndex = 0
            If cboMatchType.Items.Count > 0 Then cboMatchType.SelectedIndex = 0
            If cboPriceType.Items.Count > 0 Then cboPriceType.SelectedIndex = 0
            If cboTimeType.Items.Count > 0 Then cboTimeType.SelectedIndex = 0
            If cboVoucher.Items.Count > 0 Then cboVoucher.SelectedIndex = 0
            If cboCalendar.Items.Count > 0 Then cboCalendar.SelectedIndex = 0
            If cboConsultant.Items.Count > 0 Then cboConsultant.SelectedIndex = 0
            If cboCODEID.Items.Count > 0 Then cboCODEID.SelectedIndex = 0

            'Hiển thị mặc định cho Description
            Me.txtDescription.Text = "Orders making"

            If Me.TxDate.Length > 0 And Me.TxNum.Length > 0 Then
                'Me.AllowViewCF = False
                ViewOrderMessage(TxDate, TxNum)
                ViewBalance(mv_blnAdvanceOrder)
                ShowOfficerFunction()
                Call DisplayConfirm()
                Exit Function
            End If

            'Nếu là màn hình đặt lệnh AdvanceOrder (có tư vấn)
            If mv_blnAdvanceOrder Then
                'Khởi tạo màn hình đặt lệnh AdvanceOrder (có tư vấn)
                Call AdvanceOrderMode()
            Else
                'Khởi tạo màn hình đặt lệnh Normal (kô có tư vấn)
                Call NormalOrderMode()
            End If
            If mv_strCurrentTime Is Nothing Or mv_strCurrentTime.Length = 0 Then
                tmrOrder.Enabled = False
            Else
                tickCount = CDec(Strings.Left(mv_strCurrentTime, 2)) * 3600
                tickCount += CDec(Strings.Mid(mv_strCurrentTime, 4, 2)) * 60
                tickCount += CDec(Strings.Right(mv_strCurrentTime, 2))
                tickCount *= 1000
                tmrOrder.Start()
                tmrOrder.Enabled = False
            End If


            SettingHoPriceType()
            GetTellerName()
            Getratiolimit()
            Me.Text = Me.Text & " Maker:" & TellerId & "(" & TellerName & ")"
            'If Me.txtTradePalce.Text = c_HO_TRADEPLACE Then
            '    SettingPriceTypeByTime()
            'End If
            If IIf(IsDBNull(Len(AccountNumber)), 0, Len(AccountNumber)) > 0 Then
                Me.mskAFACCTNO.ReadOnly = True
                Me.mskAFACCTNO.Text = Me.AccountNumber
                Me.cboVia.SelectedValue = "T" 'Mac dinh kenh Tele
                Me.cboVia.Enabled = False
                ReBindExecComboByAuth()
            End If



            Me.lblConsultant.Visible = False
            Me.cboConsultant.Visible = False
            mv_dblOnload = False
            Me.lblDealNo.Visible = False
            Me.txtDealNO.Visible = False
            Me.btnGetDeal.Visible = False

            If InitParam.Length > 0 Then
                BindInitParam()
            End If
            If mv_blnIsPTRepo Then
                Me.chkPTRepo.Visible = True
            Else
                Me.chkPTRepo.Visible = False

            End If

            SetPTScreen(False)
        Catch ex As Exception

        End Try
    End Function

    Private Sub BindInitParam()
        Dim v_arrParam As String() = mv_InitParam.Split("|".ToCharArray())
        Dim v_arrParamVal As String()
        If v_arrParam.GetLength(0) > 0 Then
            Try
                For i As Integer = 0 To v_arrParam.GetLength(0) - 1
                    v_arrParamVal = v_arrParam(i).Split("#".ToCharArray())
                    If v_arrParamVal.GetLength(0) = 2 Then
                        If v_arrParam(i).IndexOf("CUSTODYCD") >= 0 Then
                            mskCustodycd.Text = v_arrParamVal(1).Replace(".", "")
                            LoadAFACCTNO()
                        ElseIf v_arrParam(i).IndexOf("CONTRACTNO") >= 0 Then
                            fcbAfacctno.SelectedValue = v_arrParamVal(1).Replace(".", "")
                            'mskAFACCTNO.Text = v_arrParamVal(1).Replace(".", "")
                        ElseIf v_arrParam(i).IndexOf("EXECTYPE") >= 0 Then
                            cboExecType.SelectedValue = v_arrParamVal(1)
                        ElseIf v_arrParam(i).IndexOf("SYMBOL") >= 0 Then
                            'Dim v_ds As DataTable = cboCODEID.ComboSource
                            Dim v_ds As DataTable = cboCODEID.DataSource
                            Dim v_CodeID As String = ""
                            For j As Integer = 0 To v_ds.Rows.Count - 1
                                If CStr(v_ds.Rows(j)("DISPLAY")).ToUpper().Trim() = v_arrParamVal(1).ToUpper().Trim() Then
                                    v_CodeID = CStr(v_ds.Rows(j)("VALUE"))
                                    Exit For
                                End If
                            Next
                            cboCODEID.SelectedValue = v_CodeID
                        ElseIf v_arrParam(i).IndexOf("DEALNO") >= 0 Then
                            Me.txtDealNO.Text = v_arrParamVal(1).Replace(",", "")
                            Me.txtQuotePrice.Text = CDbl(Me.mv_dblFloorPrice / Me.mv_dblTradeUnit)
                            Me.cboExecType.Enabled = False
                            Me.txtDealNO.Enabled = False
                            Me.btnGetDeal.Enabled = False
                        ElseIf v_arrParam(i).IndexOf("QUANTITY") >= 0 Then
                            txtQuantity.Text = v_arrParamVal(1).Replace(",", "")
                        ElseIf v_arrParam(i).IndexOf("PRICETYPE") >= 0 Then
                            cboPriceType.SelectedValue = v_arrParamVal(1)
                        ElseIf v_arrParam(i).IndexOf("LIMITPRICE") >= 0 Then
                            If txtTradePalce.Text <> c_HA_TRADEPLACE Then
                                txtQuotePrice.Text = v_arrParamVal(1).Replace(",", "") * mv_dblTmpTradeUnit
                            Else
                                txtQuotePrice.Text = v_arrParamVal(1).Replace(",", "")
                            End If
                        ElseIf v_arrParam(i).IndexOf("MATCHTYPE") >= 0 Then
                            cboMatchType.SelectedValue = v_arrParamVal(1)
                        ElseIf v_arrParam(i).IndexOf("VIA") >= 0 Then
                            cboVia.SelectedValue = v_arrParamVal(1)
                        ElseIf v_arrParam(i).IndexOf("AFFECTEDDATE") >= 0 Then
                            dtpEffectiveDate.Value = DateTime.ParseExact(v_arrParamVal(1), gc_FORMAT_DATE, Nothing)
                        ElseIf v_arrParam(i).IndexOf("EXPIREDDATE") >= 0 Then
                            dtpExpiredDate.Value = DateTime.ParseExact(v_arrParamVal(1), gc_FORMAT_DATE, Nothing)
                        ElseIf v_arrParam(i).IndexOf("DISABLEINPUT") >= 0 Then
                            cboExecType.Enabled = False
                            cboCODEID.Enabled = False
                            txtQuantity.Enabled = False
                            cboPriceType.Enabled = False
                            'txtQuotePrice.Enabled = False
                            txtDescription.Enabled = False
                            cboMatchType.Enabled = False
                            cboVia.Enabled = False
                            cboTimeType.Enabled = False
                            dtpEffectiveDate.Enabled = False
                            dtpExpiredDate.Enabled = False
                            cboVoucher.Enabled = False
                            cboCalendar.Enabled = False
                            'txtClearingDay.Enabled = False
                        End If
                    End If
                Next
            Catch ex As Exception
                Throw ex
            End Try
        End If
    End Sub

    Private Sub Getratiolimit()
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_strValue, v_strFLDNAME, v_strTEXT, v_strMINBRATIO, v_strMAXBRATIO As String, i, j As Integer
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_strCmdSQL As String, v_strObjMsg As String
            v_strCmdSQL = " SELECT  SUM (DT.MINBRATIO) MINBRATIO, SUM (DT.MAXBRATIO) MAXBRATIO " & _
                 "FROM ( SELECT   0 MINBRATIO , TO_NUMBER(VARVALUE)  MAXBRATIO  FROM SYSVAR WHERE VARNAME ='MAXBRATIO' UNION ALL " & _
                 " SELECT TO_NUMBER(VARVALUE) MINBRATIO , 0 MAXBRATIO  FROM SYSVAR WHERE VARNAME ='MINBRATIO')DT "
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_AFMAST, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            For i = 0 To v_nodeList.Count - 1
                For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        'Ghi nhận thuật toán để kiểm tra và tính toán cho từng trư?ng c�ủa giao dịch
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "MINBRATIO"
                                mv_dblSecureBratioSYSMin = CDec(Trim(v_strValue))
                            Case "MAXBRATIO"
                                mv_dblSecureBratioSYSMax = CDec(Trim(v_strValue))
                        End Select
                    End With
                Next

            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GetMarginInfo(ByVal v_strAFACCTNO As String, ByVal v_strCODEID As String)
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_strValue, v_strFLDNAME, v_strTEXT, v_strMINBRATIO, v_strMAXBRATIO As String, i, j As Integer
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_strCmdSQL As String, v_strObjMsg As String
            v_strCmdSQL = " SELECT MST.ADVANCELINE, nvl(LNT.CHKSYSCTRL,'N') CHKSYSCTRL, NVL(RSK.ISMARGINALLOW,'N') ISMARGINALLOW, " & ControlChars.CrLf _
                        & " fn_getmaxdeffeerate('" & v_strAFACCTNO & "') DEFFEERATE, MRT.MRTYPE,MRT.ISPPUSED, NVL(RSK.MRRATIOLOAN,0) MRRATIOLOAN, " & ControlChars.CrLf _
                        & " NVL(MRPRICELOAN,0) MRPRICELOAN, fn_getppavlroom(RSK.CODEID,MST.ACCTNO) PRAVLLIMIT, nvl(b.TRFT0AMT,0) TRFT0AMT, nvl(b.buyamt,0)  +  nvl(b.buyfeeacr,0) T0SECUREAMT " & ControlChars.CrLf _
                        & " FROM AFMAST MST, AFTYPE AFT, LNTYPE LNT, MRTYPE MRT,  " & ControlChars.CrLf _
                        & "     (SELECT R.* FROM AFSERISK R,SBSECURITIES SB WHERE R.CODEID=SB.CODEID AND SB.CODEID = '" & v_strCODEID & "' ) RSK,  " & ControlChars.CrLf _
                        & "     v_getbuyorderinfo b  " & ControlChars.CrLf _
                        & " WHERE MST.ACCTNO ='" & v_strAFACCTNO & "' AND MST.ACTYPE=AFT.ACTYPE AND AFT.MRTYPE =MRT.ACTYPE AND AFT.ACTYPE =RSK.ACTYPE(+) AND AFT.LNTYPE = LNT.ACTYPE(+) AND MST.ACCTNO = b.AFACCTNO(+) "

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_AFMAST, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            For i = 0 To v_nodeList.Count - 1
                For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        'Ghi nhận thuật toán để kiểm tra và tính toán cho từng trư?ng c�ủa giao dịch
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "MRTYPE"
                                mv_strMarginType = Trim(v_strValue)
                            Case "CHKSYSCTRL"
                                mv_strChkSysCtrl = Trim(v_strValue)
                            Case "ISMARGINALLOW"
                                mv_strIsMarginAllow = Trim(v_strValue)
                            Case "MRRATIOLOAN"
                                mv_dblMarginRatioRate = CDec(Trim(v_strValue))
                            Case "MRPRICELOAN"
                                mv_dblSecMarginPrice = CDec(Trim(v_strValue))
                            Case "ISPPUSED" '1: PPSE   0: PP0
                                mv_dblIsPPUsed = CDec(Trim(v_strValue))
                            Case "DEFFEERATE"
                                mv_dblDefFeeRate = CDec(Trim(v_strValue))
                            Case "ADVANCELINE"
                                mv_dblAdvanceLine = CDec(Trim(v_strValue))
                            Case "TRFT0AMT"
                                mv_dblTrfT0Amt = CDec(Trim(v_strValue))
                            Case "T0SECUREAMT"
                                mv_dblT0SecureAmt = CDec(Trim(v_strValue))
                            Case "ISLATETRANSFER"
                                mv_dblISLATETRANSFER = CDec(Trim(v_strValue))
                            Case "PRAVLLIMIT"
                                mv_dblPRAvlLimit = CDec(Trim(v_strValue))
                        End Select
                    End With
                Next
            Next
            If mv_dblMarginRatioRate >= 100 Or mv_dblMarginRatioRate < 0 Then mv_dblMarginRatioRate = 0
            mv_dblSecMarginPrice = IIf(mv_dblMarginPrice > mv_dblSecMarginPrice, mv_dblSecMarginPrice, mv_dblMarginPrice)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GetDealInfo(ByVal v_strDealID As String)
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_strValue, v_strFLDNAME, v_strTEXT, v_strMINBRATIO, v_strMAXBRATIO As String, i, j As Integer
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_strCmdSQL As String, v_strObjMsg As String
            v_strCmdSQL = " SELECT * FROM v_getDealInfo A WHERE A.ACCTNO ='" & v_strDealID & "' AND A.DFTRADING>0 AND A.STATUS ='A'"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_AFMAST, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            If v_nodeList.Count > 0 Then
                For i = 0 To v_nodeList.Count - 1
                    For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            'Ghi nhận thuật toán để kiểm tra và tính toán cho từng trư?ng c�ủa giao dịch
                            v_strValue = .InnerText.ToString
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME)
                                Case "DFTRADING"
                                    Me.txtQuantity.Text = Trim(v_strValue)
                                Case "CODEID"
                                    Me.cboCODEID.SelectedValue = Trim(v_strValue)
                                Case "AFACCTNO"
                                    Me.mskAFACCTNO.Text = Trim(v_strValue)
                            End Select
                        End With
                    Next
                Next
            Else
                MsgBox(mv_ResourceManager.GetString("DEALINVALID"), MsgBoxStyle.Information, Me.Text)
                Me.ActiveControl = Me.btnGetDeal
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SettingHoPriceType()
        Try
            'Lấy thông tin v? giá chứng khoán
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_strValue, v_strFLDNAME, v_strTEXT As String
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_strCmdSQL As String, v_strObjMsg, v_strIssuerId As String
            v_strCmdSQL = "SELECT TRADEPLACE,FROMTIME,TOTIME,PRICETYPE FROM STCSE WHERE TRADEPLACE='" & c_HO_TRADEPLACE & "'"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_AFMAST, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            If v_nodeList.Count >= 1 Then
                ReDim mv_arrHoPriceTypeInfo(v_nodeList.Count - 1)
            Else
                ReDim mv_arrHoPriceTypeInfo(0)
            End If

            Dim v_intCnt As Integer = 0
            For i As Integer = 0 To v_nodeList.Count - 1
                v_strTEXT = String.Empty
                Dim v_objTemp As New HoPriceType
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = Trim(.InnerText.ToString)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "FROMTIME"
                                v_objTemp.HoFromTime = v_strValue.Trim
                            Case "TOTIME"
                                v_objTemp.HoToTime = v_strValue.Trim
                            Case "PRICETYPE"
                                v_objTemp.HoPriceType = v_strValue.Trim
                        End Select
                    End With
                Next
                mv_arrHoPriceTypeInfo(v_intCnt) = v_objTemp
                v_intCnt += 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub QuickOrder(ByVal blnEnable As Boolean)
        cboExecType.Enabled = Not blnEnable
        cboTimeType.Enabled = Not blnEnable
        cboMatchType.Enabled = Not blnEnable
        txtClearingDay.Enabled = Not blnEnable
        chkAllorNone.Enabled = Not blnEnable
        cboConsultant.Enabled = Not blnEnable
        cboCalendar.Enabled = Not blnEnable
        txtDescription.Enabled = Not blnEnable
        If IIf(IsDBNull(Len(AccountNumber)), 0, Len(AccountNumber)) = 0 Then
            cboVia.Enabled = True
            If cboVia.SelectedValue = "F" Then
                cboVoucher.SelectedValue = "C"
            Else
                cboVoucher.SelectedValue = "P"
            End If
        End If

        cboVoucher.Enabled = Not blnEnable
    End Sub

    Private Sub NormalOrderMode()
        'Màn hình đặt lệnh Normal (không có tư vấn)
        ViewBalance(False)
        cboExecType.Enabled = True
        cboTimeType.Enabled = True
        cboMatchType.Enabled = True
        txtClearingDay.Enabled = True
        chkAllorNone.Enabled = True
        cboConsultant.Text = "Independent"
        cboConsultant.Enabled = False
        cboCalendar.Enabled = True
        txtDescription.Enabled = True
    End Sub

    Private Sub AdvanceOrderMode()
        'Khởi tạo màn hình đặt lệnh Advance Order (có tư vấn)
        ViewBalance(AllowViewCF)

        cboExecType.Enabled = True
        cboTimeType.Enabled = True
        cboMatchType.Enabled = True
        txtClearingDay.Enabled = True
        chkAllorNone.Enabled = True
        cboConsultant.Text = "Consultant"
        cboConsultant.Enabled = False
        cboCalendar.Enabled = True
        txtDescription.Enabled = True

    End Sub

    Private Sub ShowAdjustButton(ByVal pv_Enable As Boolean)
        If pv_Enable Then
            btnAdjust.Visible = True
            btnAdjust.Enabled = True
            mskAFACCTNO.Enabled = False

            btnAdjust.Width = btnOK.Width
            btnAdjust.Top = btnOK.Top
            btnAdjust.Left = btnOK.Left

            btnOK.Top = btnAdjust.Top
            btnOK.Left = btnAdjust.Left - btnAdjust.Width - 10
            btnDelete.Visible = False
            btnDelete.Enabled = False
        Else
            btnOK.Width = btnAdjust.Width
            btnOK.Top = btnAdjust.Top
            btnOK.Left = btnAdjust.Left
            btnOK.Visible = True
            btnOK.Enabled = True

            btnAdjust.Visible = False
            btnAdjust.Enabled = False

            btnDelete.Visible = True
            btnDelete.Enabled = True

            mskAFACCTNO.Enabled = True
            mskAFACCTNO.Focus()
            mskAFACCTNO.SelectAll()

            Me.txtDescription.Text = "Orders making"
        End If
    End Sub

    Private Sub ResetDeleteButton()

        btnOK.Top = btnCANCEL.Top
        btnOK.Left = btnCANCEL.Left - btnCANCEL.Width - 10
        btnOK.Visible = True
        btnOK.Enabled = True

        btnDelete.Top = btnOK.Top
        btnDelete.Left = btnOK.Left - 250
        btnAmendment.Enabled = True
        btnAmendment.Visible = False

        lblOrderID.Visible = True

        mv_blnIsDelete = False
        Me.Text = ""
    End Sub

    Private Sub ViewBalance(ByVal pv_blnAllow As Boolean)
        'Kiểm tra xem có quyen xem số dư của khách hàng hay không
        Try
            '   If pv_blnAllow Then
            'Kiểm tra xem có quyen xem chi tiết hợp đồng không
            'Show chi tiết hợp đồng
            pnBalance.Visible = True
            pnBalance.Top = CONTROL_PNL_BALANCE_TOP
            pnContractInfo.Top = CONTROL_PNL_CONTRACT_TOP
            btnOK.Top = pnContractInfo.Bottom + 25 'CONTROL_BUTTON_TOP
            btnCANCEL.Top = btnOK.Top
            btnDelete.Top = btnOK.Top
            lblOrderID.Top = btnOK.Top
            Me.Height = FRM_EXTEND_HEIGHT

            'Else

            '    pnBalance.Visible = True
            '    pnBalance.Top = pnOrder.Bottom + 20 'CONTROL_PNL_BALANCE_TOP
            '    pnBalance.Height = 45

            '    Me.lblAAMT.Visible = False
            '    Me.lblCIAdvance.Visible = False
            '    Me.lblTotalAmout.Visible = False
            '    Me.lblTotal.Visible = False

            '    pnContractInfo.Top = pnBalance.Bottom + 20 'CONTROL_PNL_CONTRACT_TOP - pnBalance.Height + 15
            '    btnOK.Top = pnContractInfo.Bottom + 25 'CONTROL_BUTTON_TOP
            '    btnCANCEL.Top = pnContractInfo.Bottom + 25 'btnOK.Top
            '    btnDelete.Top = pnContractInfo.Bottom + 25 'btnOK.Top
            '    lblOrderID.Top = pnContractInfo.Bottom + 25 'btnOK.Top
            '    If btnOK.Visible = True Then
            '        Me.Height = btnOK.Bottom + 50
            '    Else
            '        Me.Height = btnCANCEL.Bottom + 50
            '    End If
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ViewDetail(ByVal pv_blnAllow As Boolean)
        'Kiểm tra xem có quyen xem số dư của khách hàng hay không
        Try
            If Not pv_blnAllow Then
                pnExtentInfo.Visible = False
                pnUpcomInfo.Visible = True
                pnUpcomInfo.Top = CONTROL_PNL_EXTENDINFO_TOP
            Else
                pnExtentInfo.Visible = True
                pnUpcomInfo.Visible = False
                pnExtentInfo.Top = CONTROL_PNL_EXTENDINFO_TOP
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ResetControl(ByRef pv_ctrl As Windows.Forms.Control)
        Dim v_ctrl As Windows.Forms.Control
        pnOrderConfirm.Visible = False
        pnOrder.Visible = True
        For Each v_ctrl In pv_ctrl.Controls
            If TypeOf (v_ctrl) Is TextBox Then
                CType(v_ctrl, TextBox).Text = String.Empty
                'CType(v_ctrl, TextBox).Enabled = True
            ElseIf TypeOf (v_ctrl) Is GroupBox Then
                ResetControl(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is Button Then
            ElseIf TypeOf (v_ctrl) Is Panel Then
                v_ctrl.Enabled = True
                ResetControl(v_ctrl)
            End If
        Next
    End Sub
    Private Sub ResetScreen(ByRef pv_ctrl As Windows.Forms.Control)
        ResetControl(pv_ctrl)
        txtLimitPrice.Text = "0"
        txtBRATIO.Text = "0"
        txtTRADELIMIT.Text = "0"

        mv_strLastAFACCTNO = String.Empty
        'mv_strFULLNAME = String.Empty

        Me.mskAFACCTNO.Enabled = True
        Me.mskAFACCTNO.Text = mv_strLastAFACCTNO
        Me.ActiveControl = mskAFACCTNO
        Me.lblAFINFO.Text = String.Empty
        Me.lblCI.Text = String.Empty
        Me.lblSE.Text = String.Empty
        Me.lblMortage.Text = String.Empty
        Me.lblAAMT.Text = String.Empty
        Me.lblTotal.Text = String.Empty
        Me.picSignature.Text = String.Empty
        Me.lblOrderID.Text = String.Empty
        'Hiển thị mặc định cho Description
        Me.txtDescription.Text = "Orders making"
        'Me.btnDelete.Text = "&Correct"
        picSignature.Image = Nothing
        mskOrderID.Visible = False

        MemberGrid.DataRows.Clear()
        SEMemberGrid.DataRows.Clear()

        Select Case Trim(cboPriceType.SelectedValue)
            Case "LO"
                txtQuotePrice.Enabled = True
                txtLimitPrice.Enabled = False
                txtLimitPrice.Text = "0"
                txtQuantity.Enabled = True
                'Case "MO", "ATO", "ATC", "MP"
            Case "MOK", "MAK", "ATO", "ATC"
                txtQuotePrice.Enabled = False
                txtQuotePrice.Text = "0"
                txtLimitPrice.Enabled = False
                txtLimitPrice.Text = "0"
            Case "SL"
                txtQuotePrice.Enabled = True
                txtLimitPrice.Enabled = True
            Case "SM"
                txtQuotePrice.Enabled = True
                txtLimitPrice.Enabled = False
                txtLimitPrice.Text = "0"
        End Select
        GetSecuritiesInfo(Me.cboCODEID.SelectedValue)

        If IIf(IsDBNull(Len(AccountNumber)), 0, Len(AccountNumber)) > 0 Then
            Me.mskAFACCTNO.Text = Me.AccountNumber
            Me.cboVia.SelectedValue = "T" 'Mac dinh kenh Tele
            Me.mskAFACCTNO.ReadOnly = True
            Me.cboVia.Enabled = False
        End If

        'T10/2015 TTBT T+2. Begin
        '22/10/2015 DieuNDA: Khi chuyen tab mac dinh forcus vao truong custodycd ban
        mskCustodycd.Focus()
        '10/11/2015 DieuNDA: lay chu ky thanh toan khai bao tren sysvar
        Dim v_strCmdSQL1 As String, v_strObjMsg As String
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_strValue, v_strFLDNAME, v_strTEXT As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        v_strCmdSQL1 = "select varvalue from sysvar where grname='OD' and varname='CLEARDAY' and rownum<=1"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_OD_ODMAST, gc_ActionInquiry, v_strCmdSQL1)
        v_ws.Message(v_strObjMsg)
        v_xmlDocument.LoadXml(v_strObjMsg)
        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

        For i As Integer = 0 To v_nodeList.Count - 1
            v_strTEXT = String.Empty
            For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                With v_nodeList.Item(i).ChildNodes(j)
                    v_strValue = Trim(.InnerText.ToString)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    Select Case Trim(v_strFLDNAME)
                        Case "VARVALUE"
                            mv_dblSYSClearday = CDbl(v_strValue)

                    End Select
                End With
            Next
        Next
        txtClearingDay.Text = mv_dblSYSClearday
        'T10/2015 TTBT T+2.End
        '11/07/2016 DieuNDA: ETF HOSE 
        v_strCmdSQL1 = "select max(decode(varname,'PTQTTY100TO5000',varvalue,'')) PTQTTY100TO5000,  " & _
            "    max(decode(varname,'HOMINPTQTTY',varvalue,'0')) HOMINPTQTTY,  " & _
            "    max(decode(varname,'HAMINPTQTTY',varvalue,'0')) HAMINPTQTTY,  " & _
            "    max(decode(varname,'HAMAXPTLOTQTTY',varvalue,'0')) HAMAXPTLOTQTTY,  " & _
            "    max(decode(varname,'HAMINPTBONDQTTY',varvalue,'0')) HAMINPTBONDQTTY,  " & _
            "    max(decode(varname,'HOSE_MAX_QUANTITY',varvalue,'0')) HOSE_MAX_QUANTITY  " & _
            "        from sysvar  " & _
            " where  varname in ('PTQTTY100TO5000','HOMINPTQTTY','HAMINPTQTTY','HAMAXPTLOTQTTY','HAMINPTBONDQTTY','HOSE_MAX_QUANTITY')"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_OD_ODMAST, gc_ActionInquiry, v_strCmdSQL1)
        v_ws.Message(v_strObjMsg)
        v_xmlDocument.LoadXml(v_strObjMsg)
        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

        For i As Integer = 0 To v_nodeList.Count - 1
            v_strTEXT = String.Empty
            For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                With v_nodeList.Item(i).ChildNodes(j)
                    v_strValue = Trim(.InnerText.ToString)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    Select Case Trim(v_strFLDNAME)
                        Case "PTQTTY100TO5000"
                            mv_strPTQTTY100TO5000 = Trim(v_strValue)
                        Case "HOMINPTQTTY"
                            mv_dblHOMINPTQTTY = CDbl(Trim(v_strValue))
                        Case "HAMINPTQTTY"
                            mv_dblHAMINPTQTTY = CDbl(Trim(v_strValue))
                        Case "HAMAXPTLOTQTTY"
                            mv_dblHAMAXPTLOTQTTY = CDbl(Trim(v_strValue))
                        Case "HAMINPTBONDQTTY"
                            mv_dblHAMINPTBONDQTTY = CDbl(Trim(v_strValue))
                        Case "HOSE_MAX_QUANTITY"
                            mv_dblHOSE_MAX_QUANTITY = CDbl(Trim(v_strValue))

                    End Select
                End With
            Next
        Next
        '11/07/2016 DieuNDA
    End Sub

    Public Sub ViewOrderMessage(ByVal v_strTXDATE As String, ByVal v_strTXNUM As String)
        Try
            'Create message to inquiry object fields
            Dim v_strClause, v_strSQL, v_strObjMsg, v_strFLDNAME, v_strValue, v_strTXSTATUS, v_strTXBUSDATE As String, i, j As Integer
            Dim v_xmlDocument As New Xml.XmlDocument, v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_objField As CFieldMaster, v_objAccount As CAccountEntry, v_objVAT As CVATVoucher, v_objFA As CIEFMISEntry
            Dim v_strFieldName, v_strDefName, v_strCaption, v_strFldType, v_strFldMask, v_strFldFormat, _
                v_strLList, v_strLChk, v_strDefVal, v_strAmtExp, v_strValidTag, v_strLookUp, v_strDataType, v_strControlType, _
                v_strChainName, v_strPrintInfo, v_strInvName, v_strFldSource, v_strFldDesc, _
                v_strNValue, v_strCValue As String
            Dim v_intOdrNum, v_intFldLen As Integer
            Dim v_blnVisible, v_blnEnabled, v_blnMandatory As Boolean
            Dim v_strTLTXCD, v_strTXDESC, v_strEN_TXDESC As String

            Dim v_strAuthId As String = String.Empty
            Dim v_strAcctNo As String = String.Empty
            'Lấy thông tin chung ve giao dịch
            If v_strTXDATE = Me.BusDate Then
                v_strSQL = "SELECT TLTX.TLTXCD, TLTX.TXDESC, TLTX.EN_TXDESC, TLTX.BGCOLOR, TLTX.BKDATE, TLTX.ACCTENTRY, TLLOG.TXSTATUS, TLLOG.BUSDATE, TLLOG.TXDESC LOGDESC FROM TLTX, TLLOG " & ControlChars.CrLf _
                        & "WHERE TLTX.TLTXCD=TLLOG.TLTXCD AND TXNUM='" & v_strTXNUM & "' AND TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLTX, gc_ActionInquiry, v_strSQL)
            Else
                v_strSQL = "SELECT TLTX.TLTXCD, TLTX.TXDESC, TLTX.EN_TXDESC, TLTX.BGCOLOR, TLTX.BKDATE, TLTX.ACCTENTRY, TLLOGALL.TXSTATUS, TLLOGALL.BUSDATE, TLLOGALL.TXDESC LOGDESC FROM TLTX, TLLOGALL " & ControlChars.CrLf _
                        & "WHERE TLTX.TLTXCD=TLLOGALL.TLTXCD AND TXNUM='" & v_strTXNUM & "' AND TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_BRGRP, gc_ActionInquiry, v_strSQL)
            End If
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i = 0 To v_nodeList.Count - 1
                For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "TLTXCD"
                                v_strTLTXCD = Trim(v_strValue)
                            Case "TXDESC"
                                If UserLanguage <> "EN" Then
                                    v_strTXDESC = Trim(v_strValue)
                                End If
                            Case "EN_TXDESC"
                                If UserLanguage = "EN" Then
                                    v_strEN_TXDESC = Trim(v_strValue)
                                End If
                            Case "ACCTENTRY"
                                If v_strValue = "Y" Then
                                    mv_blnAcctEntry = True
                                Else
                                    mv_blnAcctEntry = False
                                End If
                            Case "BGCOLOR"
                                pnOrder.BackColor = getTransBGColor(CInt(Trim(v_strValue)))
                            Case "TXSTATUS"
                                v_strTXSTATUS = Trim(v_strValue)
                                Me.TransactionStatus = Trim(v_strValue)
                            Case "BUSDATE"
                                mv_strBusDate = Trim(v_strValue)
                        End Select
                    End With
                Next
            Next
            mv_isBackDate = False 'Không cho phép sửa lại posting date

            'Lấy thông tin chi tiết các trưong của giao dịch
            If v_strTXDATE = Me.BusDate Then
                v_strSQL = "SELECT FLD.*,LGFLD.NVALUE, LGFLD.CVALUE " & ControlChars.CrLf _
                        & "FROM FLDMASTER FLD, TLLOGFLD LGFLD, TLLOG LG " & ControlChars.CrLf _
                        & "WHERE FLD.OBJNAME = LG.TLTXCD And LG.TXNUM = LGFLD.TXNUM And LG.TXDATE = LGFLD.TXDATE AND FLD.FLDNAME=LGFLD.FLDCD " & ControlChars.CrLf _
                        & "AND LG.TXNUM='" & v_strTXNUM & "' AND LG.TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') " & ControlChars.CrLf _
                        & "ORDER BY ODRNUM"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_FLDMASTER, gc_ActionInquiry, v_strSQL)
            Else
                v_strSQL = "SELECT FLD.*,LGFLD.NVALUE, LGFLD.CVALUE " & ControlChars.CrLf _
                        & "FROM FLDMASTER FLD, TLLOGFLDALL LGFLD, TLLOGALL LG " & ControlChars.CrLf _
                        & "WHERE FLD.OBJNAME = LG.TLTXCD And LG.TXNUM = LGFLD.TXNUM And LG.TXDATE = LGFLD.TXDATE AND FLD.FLDNAME=LGFLD.FLDCD " & ControlChars.CrLf _
                        & "AND LG.TXNUM='" & v_strTXNUM & "' AND LG.TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') " & ControlChars.CrLf _
                        & "ORDER BY ODRNUM"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_BRGRP, gc_ActionInquiry, v_strSQL)
            End If

            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            ReDim mv_arrObjFields(v_nodeList.Count)

            For i = 0 To v_nodeList.Count - 1
                v_strNValue = vbNullString
                v_strCValue = vbNullString
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
                            Case "CTLTYPE"
                                v_strControlType = Trim(v_strValue)
                            Case "INVNAME"
                                v_strInvName = Trim(v_strValue)
                            Case "FLDSOURCE"
                                v_strFldSource = Trim(v_strValue)
                            Case "FLDDESC"
                                v_strFldDesc = Trim(v_strValue)
                            Case "CHAINNAME"
                                v_strChainName = Trim(v_strValue)
                            Case "PRINTINFO"
                                v_strPrintInfo = v_strValue 'Không được trim vì độ dài bắt buộc 10 ký tự
                            Case "NVALUE"
                                v_strNValue = v_strValue
                            Case "CVALUE"
                                v_strCValue = v_strValue
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
                    'Xác định giá trị hiển thị trên màn hình
                    If Len(v_strCValue) > 0 Then
                        v_strDefVal = v_strCValue
                    Else
                        v_strDefVal = v_strNValue
                    End If
                    .DefaultValue = v_strDefVal
                    .Visible = v_blnVisible
                    .Enabled = False 'v_blnEnabled
                    .Mandatory = v_blnMandatory
                    .AmtExp = v_strAmtExp
                    .ValidTag = v_strValidTag
                    .LookUp = v_strLookUp
                    .DataType = v_strDataType
                    .ControlType = v_strControlType
                    .InvName = v_strInvName
                    .FldSource = v_strFldSource
                    .FldDesc = v_strFldDesc
                    .PrintInfo = v_strPrintInfo
                    .FieldValue = String.Empty
                End With
                mv_arrObjFields(i) = v_objField
            Next
            ReDim Preserve mv_arrObjFields(v_nodeList.Count)
            'Hiển thị thông tin giao dịch lên màn hình đặt lệnh
            Dim v_intIndex As Integer
            Dim v_strFLDVALUE, v_strACTYPE As String
            FillComboEx(mv_strObjFullExectypeMessage, cboExecType, "", Me.UserLanguage)
            FillComboEx(mv_strObjFullPricetypeMessage, cboPriceType, "", Me.UserLanguage)
            If mv_arrObjFields.GetLength(0) > 0 Then
                For v_intIndex = 0 To mv_arrObjFields.GetLength(0) - 1 Step 1
                    If Not mv_arrObjFields(v_intIndex) Is Nothing Then
                        v_strFLDNAME = mv_arrObjFields(v_intIndex).FieldName
                        v_strDataType = mv_arrObjFields(v_intIndex).DataType
                        v_strFLDVALUE = mv_arrObjFields(v_intIndex).DefaultValue
                        Select Case Trim(v_strFLDNAME)
                            Case "01" 'CODEID
                                cboCODEID.SelectedValue = v_strFLDVALUE
                            Case "02" 'ACTYPE
                                v_strACTYPE = v_strFLDVALUE
                            Case "03" 'AFACCTNO
                                mskAFACCTNO.Text = v_strFLDVALUE
                            Case "50" 'CUSTNAME
                                mv_strFULLNAME = v_strFLDVALUE
                                v_strAuthId = v_strFLDVALUE
                            Case "05" 'CIACCTNO
                                'mskAFACCTNO.Text = v_strFLDVALUE
                            Case "06" 'SEACCTNO
                                'v_strFLDVALUE = Trim(mskAFACCTNO.Text) & cboCODEID.SelectedValue
                            Case "20" 'TIMETYPE                                       
                                cboTimeType.SelectedValue = v_strFLDVALUE
                            Case "21" 'EXPDATE                                       
                                dtpExpiredDate.Value = v_strFLDVALUE
                            Case "19" 'EFFDATE                                       
                                dtpEffectiveDate.Value = v_strFLDVALUE
                            Case "22" 'EXECTYPE                                       
                                cboExecType.SelectedValue = v_strFLDVALUE
                            Case "23" 'NORK                                       
                                'cboExecType.SelectedValue = IIf(v_strFLDVALUE = "Y", True, False)
                            Case "24" 'MATCHTYPE                                       
                                cboMatchType.SelectedValue = v_strFLDVALUE
                            Case "25" 'VIA                                       
                                v_strFLDVALUE = "F"
                            Case "26" 'CLEARCD                                       
                                cboCalendar.SelectedValue = v_strFLDVALUE
                            Case "27" 'PRICETYPE                                       
                                cboPriceType.SelectedValue = v_strFLDVALUE
                            Case "10" 'CLEARDAY
                                txtClearingDay.Text = v_strFLDVALUE
                            Case "11" 'QUOTEPRICE                                         
                                txtQuotePrice.Text = v_strFLDVALUE
                            Case "12" 'ORDERQTTY                                      
                                txtQuantity.Text = v_strFLDVALUE

                            Case "13" 'BRATIO                                      
                                ''v_strFLDVALUE = txtBRATIO.Text
                                ''Tính toán tỷ lệ ký quỹ của lệnh
                                'If IsNumeric(mv_dblSecureBratioMin) And IsNumeric(mv_dblSecureBratioMax) _
                                '     And IsNumeric(mv_dblTyp_Bratio) And IsNumeric(mv_dblAF_Bratio) Then
                                '    'Lấy theo tham số mức hệ thống
                                '    mv_dblSecureRatio = CDbl(mv_dblSecureBratioMin)
                                '    'So sánh với tham số loại hình
                                '    mv_dblSecureRatio = IIf(mv_dblSecureRatio > CDbl(mv_dblTyp_Bratio), mv_dblSecureRatio, CDbl(mv_dblTyp_Bratio))
                                '    'So sánh với tham số hợp đồng
                                '    mv_dblSecureRatio = IIf(mv_dblSecureRatio > CDbl(mv_dblAF_Bratio), mv_dblSecureRatio, CDbl(mv_dblAF_Bratio))
                                '    'Không vượt qua Max của tham số hệ thống
                                '    mv_dblSecureRatio = IIf(mv_dblSecureRatio > CDbl(mv_dblSecureBratioMax), CDbl(mv_dblSecureBratioMax), mv_dblSecureRatio)
                                'Else
                                '    'Mặc định là ký quỹ 100%
                                '    mv_dblSecureRatio = 100
                                'End If
                                'v_strFLDVALUE = mv_dblSecureRatio
                            Case "14" 'LIMITPRICE
                                txtLimitPrice.Text = v_strFLDVALUE
                            Case "15" 'PARVALUE
                                'v_strFLDVALUE = mv_dbdParvalue
                            Case "16" 'ORGORDERQTTY
                                mv_dblOldQtty = v_strFLDVALUE
                            Case "17" 'ORGQUOTEPRICE
                                mv_dblOldPrice = v_strFLDVALUE
                                'Case "31" 'ORGSTOPPRICE
                                '    mv_dblOldStopPrice = v_strFLDVALUE
                            Case "28" 'VOUCHER
                                cboVoucher.SelectedValue = v_strFLDVALUE
                            Case "29" 'CONSULTANT
                                cboConsultant.SelectedValue = v_strFLDVALUE
                            Case "04" 'ORDERID
                                Me.lblOrderID.Text = Strings.Left(v_strFLDVALUE, 4) & "." & Strings.Mid(v_strFLDVALUE, 5, 6) & "." & Strings.Right(v_strFLDVALUE, 6)
                            Case "30" 'DESC                                              
                                txtDescription.Text = v_strFLDVALUE 'Trim(mskAFACCTNO.Text) & "." & Trim(mv_strFULLNAME) & "." & cboExecType.SelectedValue & "." & cboCODEID.Text & "." & txtQuantity.Text & "." & txtQuotePrice.Text
                                'Case "50" 'SYMBOL
                                'cboCODEID.Text = v_strFLDVALUE
                            Case "99" 'gia tri 100
                                v_strFLDVALUE = "100"
                            Case "98" 'TradeUnit
                                mv_dblTradeUnit = v_strFLDVALUE
                                mv_dblView_TradeUnit = v_strFLDVALUE
                            Case "08"
                                mskOrderID.Text = v_strFLDVALUE
                            Case "97" 'Mode dat lenh
                                Me.mv_blnAdvanceOrder = IIf(v_strFLDVALUE = "A", True, False)
                            Case "34" 'OUTPRICEALLOW
                                Me.chkOUTPRICEALLOW.Checked = IIf(v_strFLDVALUE = "Y", True, False)
                        End Select
                    End If
                Next
            End If
            If v_strTLTXCD = gc_OD_CANCELBUYORDER Or v_strTLTXCD = gc_OD_CANCELSELLORDER Then
                mv_dblOldQtty = Me.txtQuantity.Text
                mv_dblOldPrice = Me.txtQuotePrice.Text
            End If


            GetAFContractInfo(mskAFACCTNO.Text)
            'GetSETrade(cboCODEID.SelectedValue)
            Me.mskAFACCTNO.ReadOnly = True
            SetAuthoInfo(v_strAuthId)

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub SetAuthoInfo(ByVal pv_strAuthoInfo As String)
        Dim v_strTyp, v_strAutoId As String
        If pv_strAuthoInfo.Length > 0 Then
            For i As Integer = 0 To MemberGrid.DataRows.Count - 1
                If MemberGrid.DataRows(i).Cells("IDCODE").Value = pv_strAuthoInfo.Trim Then
                    MemberGrid.DataRows(i).Cells("__TICK").Value = "X"
                    Exit Sub
                End If
            Next
        End If
    End Sub

    Private Sub ShowOfficerFunction()
        Try
            btnOK.Visible = False
            btnOK.Enabled = False
            If TransactionStatus = TransactStatus.Pending And TransactionDeleted <> "Y" Then
                btnApprove.Top = btnOK.Top
                btnApprove.Left = btnOK.Left
                btnReject.Top = btnOK.Top
                btnReject.Left = btnOK.Left - btnOK.Width - 10

                btnApprove.Visible = True
                btnApprove.Enabled = True


                btnReject.Visible = True
                btnReject.Enabled = True

                btnRefuse.Top = btnReject.Top
                btnRefuse.Left = btnReject.Left - btnReject.Width - 10
                btnRefuse.Visible = True
                btnRefuse.Enabled = True

                btnApprove.Focus()
            ElseIf TransactionStatus = TransactStatus.Rejected Then
                If btnOK.Visible = True Then
                    btnAdjust.Top = btnOK.Top
                    btnAdjust.Left = btnOK.Left
                Else
                    btnAdjust.Top = btnCANCEL.Top
                    btnAdjust.Left = btnCANCEL.Left
                End If

                btnAdjust.Visible = True
                btnAdjust.Enabled = True

                pnOrder.Enabled = True
                mskAFACCTNO.Enabled = True
            End If

            mv_blnShowOfficerFunction = True
            btnDelete.Visible = False
            btnDelete.Enabled = False
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try

    End Sub

    Private Function GetImageFromString(ByVal pv_strFLDVAL) As System.Drawing.Bitmap
        Dim v_strCompress As String = Trim(pv_strFLDVAL)
        Dim v_Compression As Byte()
        Dim v_Base64Decoder As New Base64Decoder(v_strCompress)
        v_Compression = v_Base64Decoder.GetDecoded()
        Dim v_arrActualSignImage As Byte()
        v_arrActualSignImage = CompressionHelper.DecompressBytes(v_Compression)
        Dim tmpImage As System.Drawing.Bitmap = New System.Drawing.Bitmap(New MemoryStream(v_arrActualSignImage))
        Return tmpImage
    End Function

    Private Sub LoadCFSign(ByVal pv_strCUSTID As String)
        Try
            Cursor.Current = Cursors.WaitCursor

            Dim v_strSQL As String = "SELECT SIG.AUTOID,SIG.CUSTID,SIG.SIGNATURE FROM CFSIGN SIG WHERE EXPDATE >= to_date('" & Me.mv_strBusDate & "','DD/MM/YYYY')  AND SIG.CUSTID='" & pv_strCUSTID & "'"
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, "CF.CFSIGN", _
                gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)

            Dim v_xmlDoc As New XmlDocument
            v_xmlDoc.LoadXml(v_strObjMsg)
            Dim v_xmlNodeList As XmlNodeList = v_xmlDoc.SelectNodes("/ObjectMessage/ObjData")
            Dim v_xmlEntry As XmlNode

            ReDim mv_arrAUTOID(v_xmlNodeList.Count - 1)
            ReDim mv_arrSIGNATURE(v_xmlNodeList.Count - 1)
            ReDim mv_arrCUSTID(v_xmlNodeList.Count - 1)

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
                        End Select
                    End With
                Next
            Next
            If mv_arrSIGNATURE.Length > 0 Then
                Me.VScrollBarSign.Minimum = 0
                Me.VScrollBarSign.Maximum = mv_arrSIGNATURE.Length - 1
                Me.VScrollBarSign.Value = 0
                picSignature.Image = GetImageFromString(mv_arrSIGNATURE(Me.VScrollBarSign.Value))
            Else
                picSignature.Image = Nothing
                picSignature.Refresh()
            End If
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub GetAFContractInfo(ByVal v_strAFACCTNO As String)
        Try
            If mv_strLastAFACCTNO <> v_strAFACCTNO And ViewMode = False Then
                Me.txtDescription.Text = "Orders making"
            End If

            If cboCODEID.SelectedIndex >= 0 And mv_strLastAFACCTNO <> v_strAFACCTNO Then
                Dim v_strCODEID As String = Me.cboCODEID.SelectedValue
                Dim v_nodeList As Xml.XmlNodeList
                Dim v_xmlDocument As New Xml.XmlDocument
                Dim v_strValue, v_strFLDNAME, v_strTEXT As String, i, j As Integer
                Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                Dim v_strCmdSQL, v_strClause As String, v_strObjMsg As String
                'Dim v_strIssuerId As String = String.Empty

                'v_strCmdSQL = " SELECT ACCTNO,LICENSE,CUSTID,CUSTODYCD,FULLNAME,TERM,BALANCE-NVL(ADVAMT,0) BALANCE,BRATIO,ACTYPE,AAMT,TOTAL,NVL(ADVAMT,0) ADVAMT FROM " & ControlChars.CrLf _
                '            & " (SELECT AF.ACCTNO,CF.IDCODE LICENSE,CF.CUSTID, CF.CUSTODYCD, CF.FULLNAME, CD.CDCONTENT TERM, CI.BALANCE - CI.ODAMT BALANCE, AF.BRATIO,AF.ACTYPE, NVL(AP.AAMT,0) AAMT , CI.BALANCE - CI.ODAMT + NVL(AP.AAMT,0) TOTAL " & ControlChars.CrLf _
                '            & " FROM CFMAST CF INNER JOIN AFMAST AF ON CF.CUSTID=AF.CUSTID  " & ControlChars.CrLf _
                '            & " INNER JOIN CIMAST CI ON AF.ACCTNO=CI.AFACCTNO  " & ControlChars.CrLf _
                '            & " INNER JOIN ALLCODE CD ON CD.CDVAL=AF.TERMOFUSE AND CD.CDTYPE='CF' AND CD.CDNAME='TERMOFUSE' " & ControlChars.CrLf _
                '            & " LEFT JOIN (SELECT AFACCTNO ACCTNO, SUM(AMT-AAMT-FAMT+PAIDAMT+PAIDFEEAMT) AAMT FROM STSCHD WHERE DUETYPE = 'RM' AND STATUS='N' AND DELTD <> 'Y' AND AFACCTNO = '" & v_strAFACCTNO & "' GROUP BY AFACCTNO) AP ON TRIM(AF.ACCTNO) = TRIM(AP.ACCTNO)  " & ControlChars.CrLf _
                '            & " WHERE AF.ACCTNO='" & v_strAFACCTNO & "') A,  " & ControlChars.CrLf _
                '            & " (SELECT (CASE " & ControlChars.CrLf _
                '            & "             WHEN   SUM (  quoteprice * remainqtty " & ControlChars.CrLf _
                '            & "                           * (1 + typ.deffeerate / 100) " & ControlChars.CrLf _
                '            & "                         + execamt " & ControlChars.CrLf _
                '            & "                         + rlssecured " & ControlChars.CrLf _
                '            & "                         - securedamt " & ControlChars.CrLf _
                '            & "                        ) " & ControlChars.CrLf _
                '            & "                  - MAX (af.advanceline) > 0 " & ControlChars.CrLf _
                '            & "                THEN   SUM (    quoteprice " & ControlChars.CrLf _
                '            & "                              * remainqtty " & ControlChars.CrLf _
                '            & "                              * (1 + typ.deffeerate / 100) " & ControlChars.CrLf _
                '            & "                            + execamt " & ControlChars.CrLf _
                '            & "                            + rlssecured " & ControlChars.CrLf _
                '            & "                            - securedamt " & ControlChars.CrLf _
                '            & "                           ) " & ControlChars.CrLf _
                '            & "                     - MAX (af.advanceline) " & ControlChars.CrLf _
                '            & "             ELSE 0 " & ControlChars.CrLf _
                '            & "          END " & ControlChars.CrLf _
                '            & "         ) advamt, " & ControlChars.CrLf _
                '            & "         MAX (od.afacctno) afacctno " & ControlChars.CrLf _
                '            & "    FROM odmast od, afmast af, odtype typ " & ControlChars.CrLf _
                '            & "   WHERE od.actype = typ.actype " & ControlChars.CrLf _
                '            & "     AND af.acctno = od.afacctno " & ControlChars.CrLf _
                '            & "     AND TRIM (od.afacctno) = '" & v_strAFACCTNO & "' " & ControlChars.CrLf _
                '            & "     AND od.txdate = TO_DATE ('" & Me.BusDate & "', 'DD/MM/YYYY') " & ControlChars.CrLf _
                '            & "     AND deltd <> 'Y' " & ControlChars.CrLf _
                '            & "     AND od.exectype IN ('NB', 'BC')) B " & ControlChars.CrLf _
                '            & " WHERE A.ACCTNO=B.AFACCTNO (+) "

                'v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strCmdSQL)
                'v_ws.Message(v_strObjMsg)
                'v_xmlDocument.LoadXml(v_strObjMsg)
                'v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                'Chuyen sang dung procedure
                v_strCmdSQL = "GETACCOUNTINFO"
                v_strClause = "AFACCTNO!" & v_strAFACCTNO & "!varchar2!20^INDATE!" & mv_strBusDate & "!varchar2!20"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strCmdSQL, v_strClause, , , , , , , gc_CommandProcedure)
                v_ws.Message(v_strObjMsg)
                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

                v_strTEXT = String.Empty

                For i = 0 To v_nodeList.Count - 1
                    For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            v_strValue = Trim(.InnerText.ToString)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME)
                                Case "ACTYPE"
                                    mv_strACTYPE = v_strValue
                                Case "LICENSE"
                                    If Len(v_strTEXT) = 0 Then
                                        v_strTEXT = v_strValue
                                    Else
                                        v_strTEXT = v_strTEXT & ", " & v_strValue
                                    End If
                                Case "FULLNAME"
                                    If Len(v_strTEXT) = 0 Then
                                        v_strTEXT = v_strValue
                                    Else
                                        v_strTEXT = v_strTEXT & ", " & v_strValue
                                    End If
                                    mv_strFULLNAME = v_strValue
                                Case "CUSTODYCD"
                                    v_strTEXT = v_strTEXT & " [" & mv_ResourceManager.GetString("CUSTODYCD") & v_strValue & "] "
                                    lblConfirmName.Text = "Tiểu khoản: " & Strings.Left(mskAFACCTNO.Text, 4) & "." & Strings.Mid(mskAFACCTNO.Text, 5, 3) & "." & Strings.Right(mskAFACCTNO.Text, 3) & _
                                         " | Tài khoản: " & Strings.Left(v_strValue, 4) & "." & Strings.Mid(v_strValue, 5, 3) & "." & Strings.Right(v_strValue, 3)
                                    mv_strCUSTODYCD = v_strValue
                                Case "TERM"
                                    If Len(v_strTEXT) = 0 Then
                                        v_strTEXT = v_strValue
                                    Else
                                        v_strTEXT = v_strTEXT & ", " & v_strValue
                                    End If
                                Case "COREBANK"
                                    mv_strCOREBANK = v_strValue
                                Case "ALTERNATEACCT"
                                    mv_strSubCOREBANK = v_strValue
                                Case "PP" '"BALANCE"
                                    If Len(Trim(v_strValue)) = 0 Or v_strValue = "0" Then
                                        lblCI.Text = "0"
                                    Else
                                        lblCI.Text = Format(CDbl(v_strValue), "#,###")
                                    End If
                                Case "AAMT"
                                    If Len(Trim(v_strValue)) = 0 Or v_strValue = "0" Then
                                        lblAAMT.Text = "0"
                                    Else
                                        lblAAMT.Text = Format(CDbl(v_strValue), "#,###")
                                    End If
                                Case "TOTAL"
                                    If Len(Trim(v_strValue)) = 0 Or v_strValue = "0" Then
                                        lblTotal.Text = "0"
                                    Else
                                        lblTotal.Text = Format(CDbl(v_strValue), "#,###")
                                    End If
                                Case "AVLLIMIT"
                                    mv_dblAvlLimit = CDbl(v_strValue)
                                Case "CUSTID"
                                    mv_strCUSTID = v_strValue
                                Case "BRATIO"
                                    If Len(Trim(v_strValue)) = 0 Or v_strValue = "0" Then
                                        mv_dblAF_Bratio = 0
                                    Else
                                        mv_dblAF_Bratio = CDbl(v_strValue)
                                    End If
                                Case "MRTYPE"
                                    mv_strMarginType = Trim(v_strValue)
                                Case "ISPPUSED" '1: PPSE   0: PP0
                                    mv_dblIsPPUsed = CDec(Trim(v_strValue))
                            End Select
                        End With
                    Next
                Next

                lblAFINFO.Text = v_strTEXT
                lblAFINFO.ForeColor = Color.Black
                GetSecuritiesInfo(Me.cboCODEID.SelectedValue)
                SetPPSE()

                'Fill dữ liệu vào Grid
                If v_nodeList.Count > 0 Then
                    'Lấy thông tin chữ ký, uy quyen voi lenh tai Floor
                    If mskAFACCTNO.ReadOnly = False Then
                        LoadCFSign(mv_strCUSTID)
                        GetAFLinkAuth(v_strAFACCTNO)
                    Else
                        'Check uy quyen dat lenh neu la lenh tele
                        If CStr(cboVia.SelectedValue).Trim().ToUpper() = "T" Then
                            ReBindExecComboByAuth()
                        End If
                        'End
                    End If

                    If mv_blnAdvanceOrder Then
                        'Lấy thông tin v? các tài khoản SE của khách hàng 
                        'v_strCmdSQL = "SELECT B.SYMBOL, A.TRADE,A.MORTAGE, A.COSTPRICE, NVL(C.BASICPRICE, 0) BASICPRICE " & vbCrLf & _
                        '    "   FROM SEMAST A, SBSECURITIES B, (SELECT CODEID, BASICPRICE, TXDATE FROM SECURITIES_INFO WHERE TXDATE = TO_DATE('" & mv_strBusDate & "','" & gc_FORMAT_DATE & "') )C " & vbCrLf & _
                        '    "   WHERE A.CODEID = B.CODEID AND A.CODEID = C.CODEID (+)" & vbCrLf & _
                        '    "   AND A.AFACCTNO = '" & v_strAFACCTNO & "' AND A.TRADE + A.MORTAGE <> 0 AND  B.SECTYPE <>'004'  ORDER BY B.SYMBOL"
                        'v_strCmdSQL = "SELECT B.SYMBOL, A.TRADE-nvl(D.SECUREAMT,0) TRADE,A.MORTAGE-nvl(D.SECUREMTG,0) MORTAGE, A.COSTPRICE, NVL(C.BASICPRICE, 0) BASICPRICE  " & ControlChars.CrLf _
                        '    & "  FROM SEMAST A, SBSECURITIES B, (SELECT CODEID, BASICPRICE, TXDATE FROM SECURITIES_INFO WHERE TXDATE = TO_DATE('" & mv_strBusDate & "','" & gc_FORMAT_DATE & "') ) C,  " & ControlChars.CrLf _
                        '    & "     (SELECT    SEACCTNO,  SUM (CASE WHEN OD.EXECTYPE IN ('NS', 'SS') THEN REMAINQTTY + EXECQTTY ELSE 0 END)  SECUREAMT, " & ControlChars.CrLf _
                        '    & "              SUM (CASE WHEN OD.EXECTYPE ='MS' THEN REMAINQTTY + EXECQTTY ELSE 0 END)  SECUREMTG " & ControlChars.CrLf _
                        '    & "      FROM ODMAST OD " & ControlChars.CrLf _
                        '    & "      WHERE OD.TXDATE =TO_DATE ('" & mv_strBusDate & "', '" & gc_FORMAT_DATE & "')  " & ControlChars.CrLf _
                        '    & "                AND DELTD <> 'Y'  AND OD.EXECTYPE IN ('NS', 'SS','MS') GROUP BY SEACCTNO) D " & ControlChars.CrLf _
                        '    & "  WHERE A.CODEID = B.CODEID AND A.CODEID = C.CODEID (+) AND A.ACCTNO=D.SEACCTNO(+) " & ControlChars.CrLf _
                        '    & "  AND A.AFACCTNO = '" & v_strAFACCTNO & "' AND A.TRADE + A.MORTAGE-nvl(D.SECUREMTG,0)-nvl(D.SECUREAMT,0) <> 0 AND  B.SECTYPE <>'004'  ORDER BY B.SYMBOL " & ControlChars.CrLf
                        v_strCmdSQL = "SELECT B.SYMBOL, A.TRADE-nvl(D.SECUREAMT,0)+nvl(D.SERECEIVING,0) TRADE,A.MORTAGE-nvl(D.SECUREMTG,0) MORTAGE, A.COSTPRICE, NVL(C.BASICPRICE, 0) BASICPRICE  " & ControlChars.CrLf _
                            & "  FROM SEMAST A, SBSECURITIES B, SECURITIES_INFO C,  " & ControlChars.CrLf _
                            & "  v_getsellorderinfo D " & ControlChars.CrLf _
                            & "  WHERE A.CODEID = B.CODEID AND A.CODEID = C.CODEID (+) AND A.ACCTNO=D.SEACCTNO(+) " & ControlChars.CrLf _
                            & "  AND A.AFACCTNO = '" & v_strAFACCTNO & "' AND A.TRADE + A.MORTAGE-nvl(D.SECUREMTG,0)-nvl(D.SECUREAMT,0)+nvl(D.SERECEIVING,0) <> 0 AND  B.SECTYPE <>'004'  ORDER BY B.SYMBOL " & ControlChars.CrLf
                        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strCmdSQL)
                        v_ws.Message(v_strObjMsg)
                        FillDataGrid(SEMemberGrid, v_strObjMsg, "")
                    ElseIf (Not mv_blnAdvanceOrder) And (cboExecType.SelectedValue.ToString().Trim() = "NS" Or cboExecType.SelectedValue.ToString().Trim() = "NB") Then
                        'Lấy thông tin v? các tài khoản SE của khách hàng 
                        'v_strCmdSQL = "SELECT B.SYMBOL, A.TRADE,A.MORTAGE, A.COSTPRICE, NVL(C.BASICPRICE, 0) BASICPRICE " & vbCrLf & _
                        '    "   FROM SEMAST A, SBSECURITIES B, (SELECT CODEID, BASICPRICE, TXDATE FROM SECURITIES_INFO WHERE TXDATE = TO_DATE('" & mv_strBusDate & "','" & gc_FORMAT_DATE & "') )C " & vbCrLf & _
                        '    "   WHERE A.CODEID = B.CODEID AND A.CODEID = C.CODEID (+)" & vbCrLf & _
                        '    "   AND A.AFACCTNO = '" & v_strAFACCTNO & "' AND A.CODEID='" & v_strCODEID & "' AND A.TRADE + A.MORTAGE <> 0 AND B.SECTYPE <>'004'  ORDER BY B.SYMBOL"
                        'v_strCmdSQL = "SELECT B.SYMBOL, A.TRADE-nvl(D.SECUREAMT,0) TRADE,A.MORTAGE-nvl(D.SECUREMTG,0) MORTAGE, A.COSTPRICE, NVL(C.BASICPRICE, 0) BASICPRICE  " & ControlChars.CrLf _
                        '    & "  FROM SEMAST A, SBSECURITIES B, (SELECT CODEID, BASICPRICE, TXDATE FROM SECURITIES_INFO WHERE TXDATE = TO_DATE('" & mv_strBusDate & "','" & gc_FORMAT_DATE & "') ) C,  " & ControlChars.CrLf _
                        '    & "     (SELECT    SEACCTNO,  SUM (CASE WHEN OD.EXECTYPE IN ('NS', 'SS') THEN REMAINQTTY + EXECQTTY ELSE 0 END)  SECUREAMT, " & ControlChars.CrLf _
                        '    & "              SUM (CASE WHEN OD.EXECTYPE ='MS' THEN REMAINQTTY + EXECQTTY ELSE 0 END)  SECUREMTG " & ControlChars.CrLf _
                        '    & "      FROM ODMAST OD " & ControlChars.CrLf _
                        '    & "      WHERE OD.TXDATE =TO_DATE ('" & mv_strBusDate & "', '" & gc_FORMAT_DATE & "')  " & ControlChars.CrLf _
                        '    & "                AND DELTD <> 'Y'  AND OD.EXECTYPE IN ('NS', 'SS','MS') GROUP BY SEACCTNO) D " & ControlChars.CrLf _
                        '    & "  WHERE A.CODEID = B.CODEID AND A.CODEID = C.CODEID (+) AND A.ACCTNO=D.SEACCTNO(+) " & ControlChars.CrLf _
                        '    & "  AND A.AFACCTNO = '" & v_strAFACCTNO & "'  AND A.CODEID='" & v_strCODEID & "' AND A.TRADE + A.MORTAGE-nvl(D.SECUREMTG,0)-nvl(D.SECUREAMT,0) <> 0 AND  B.SECTYPE <>'004'  ORDER BY B.SYMBOL " & ControlChars.CrLf
                        v_strCmdSQL = "SELECT B.SYMBOL, A.TRADE-nvl(D.SECUREAMT,0)+nvl(D.RECEIVING,0) TRADE,A.MORTAGE-nvl(D.SECUREMTG,0) MORTAGE, A.COSTPRICE, NVL(C.BASICPRICE, 0) BASICPRICE  " & ControlChars.CrLf _
                            & "  FROM SEMAST A, SBSECURITIES B, (SELECT CODEID, BASICPRICE, TXDATE FROM SECURITIES_INFO WHERE TXDATE = TO_DATE('" & mv_strBusDate & "','" & gc_FORMAT_DATE & "') ) C,  " & ControlChars.CrLf _
                            & "  (SELECT SEACCTNO, SUM(SECUREAMT) SECUREAMT, SUM(SECUREMTG) SECUREMTG, SUM(RECEIVING) RECEIVING " & ControlChars.CrLf _
                            & "   FROM (SELECT OD.SEACCTNO, " & ControlChars.CrLf _
                            & "             CASE WHEN OD.EXECTYPE IN ('NS', 'SS') AND OD.TXDATE =TO_DATE ('" & mv_strBusDate & "', '" & gc_FORMAT_DATE & "') THEN REMAINQTTY + EXECQTTY ELSE 0 END SECUREAMT, " & ControlChars.CrLf _
                            & "             CASE WHEN OD.EXECTYPE = 'MS'  AND OD.TXDATE =TO_DATE ('" & mv_strBusDate & "', '" & gc_FORMAT_DATE & "') THEN REMAINQTTY + EXECQTTY ELSE 0 END SECUREMTG, " & ControlChars.CrLf _
                            & "             CASE WHEN OD.EXECTYPE = 'NB' THEN ST.QTTY ELSE 0 END RECEIVING " & ControlChars.CrLf _
                            & "         FROM ODMAST OD, STSCHD ST, ODTYPE TYP " & ControlChars.CrLf _
                            & "         WHERE OD.DELTD <> 'Y'  AND OD.EXECTYPE IN ('NS', 'SS','MS', 'NB') " & ControlChars.CrLf _
                            & "             AND OD.ORDERID = ST.ORGORDERID(+) AND ST.DUETYPE(+) = 'RS' " & ControlChars.CrLf _
                            & "             And OD.ACTYPE = TYP.ACTYPE " & ControlChars.CrLf _
                            & "             AND ((TYP.TRANDAY <= (SELECT SUM(CASE WHEN CLDR.HOLIDAY = 'Y' THEN 0 ELSE 1 END)-1 " & ControlChars.CrLf _
                            & "                                     FROM SBCLDR CLDR " & ControlChars.CrLf _
                            & "                                     WHERE CLDR.CLDRTYPE = '000' AND CLDR.SBDATE >= ST.TXDATE AND CLDR.SBDATE <= TO_DATE ('" & mv_strBusDate & "', '" & gc_FORMAT_DATE & "')) AND OD.EXECTYPE = 'NB') " & ControlChars.CrLf _
                            & "                 OR OD.EXECTYPE IN ('NS','SS','MS'))) GROUP BY SEACCTNO ) D " & ControlChars.CrLf _
                            & "  WHERE A.CODEID = B.CODEID AND A.CODEID = C.CODEID (+) AND A.ACCTNO=D.SEACCTNO(+) " & ControlChars.CrLf _
                            & "  AND A.AFACCTNO = '" & v_strAFACCTNO & "'  AND A.CODEID='" & v_strCODEID & "' AND A.TRADE + A.MORTAGE-nvl(D.SECUREMTG,0)-nvl(D.SECUREAMT,0)+nvl(D.RECEIVING,0) <> 0 AND  B.SECTYPE <>'004'  ORDER BY B.SYMBOL " & ControlChars.CrLf
                        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strCmdSQL)
                        v_ws.Message(v_strObjMsg)
                        FillDataGrid(SEMemberGrid, v_strObjMsg, "")
                    End If


                    'Nếu không có thông tin ngư?i uỷ quy?n thì disable pnMemberGrid
                    If MemberGrid.DataRows.Count > 0 Then
                        pnlMember.Enabled = True
                    Else
                        pnlMember.Enabled = False
                    End If
                    'Disable pnSEInfo 
                    If SEMemberGrid.DataRows.Count > 0 Then
                        pnBalance.Enabled = True
                    Else
                        pnBalance.Enabled = False
                    End If
                    mv_strLastAFACCTNO = v_strAFACCTNO
                    GetSETrade(cboCODEID.SelectedValue)
                    CheckIssuer(cboCODEID.SelectedValue)
                Else
                    mv_strLastAFACCTNO = v_strAFACCTNO
                    'Set lai trang thai form neu acctno khong ton tai
                    'If mv_strIsAdjust = "Y" Then
                    SetAFStatusEmpty()
                    'End If
                End If
            Else
                'Set lai trang thai form neu acctno khong ton tai
                If mv_strIsAdjust = "Y" Then
                    SetAFStatusEmpty()
                End If
            End If
        Catch ex As Exception
            'MsgBox(ex.Message, MsgBoxStyle.Information, Me.Text)
        End Try
    End Sub

    Private Sub SetPPSE()
        If mv_dblIsPPUsed <> 0 And (mv_strMarginType = "S" Or mv_strMarginType = "T") Then
            If Me.lblCI.Text.Length = 0 Or lblCI.Text = "0" Then
                Me.lblPPSE.Text = Me.lblCI.Text
            Else
                Try
                    Dim v_dblPPSE As Double
                    Dim v_dblQP As Double
                    If IsNumeric(Me.txtQuotePrice.Text) Then
                        v_dblQP = CDbl(Me.txtQuotePrice.Text) * mv_dblTradeUnit
                        If v_dblQP < mv_dblFloorPrice Then
                            v_dblQP = mv_dblFloorPrice
                        End If
                    Else
                        v_dblQP = mv_dblFloorPrice
                    End If


                    If mv_strChkSysCtrl = "Y" Then
                        If mv_strIsMarginAllow = "N" Then
                            mv_dblMarginRatioRate = 0
                        Else
                            mv_dblSecMarginPrice = Math.Min(CDec(mv_dblMarginRefPrice), CDec(mv_dblSecMarginPrice)) ' Math.Min(mv_dblMarginRefPrice, mv_dblSecMarginPrice) ' IIf(mv_dblMarginRefPrice > mv_dblSecMarginPrice, mv_dblSecMarginPrice, mv_dblMarginRefPrice)
                        End If
                    Else
                        mv_dblSecMarginPrice = Math.Min(mv_dblMarginPrice, mv_dblSecMarginPrice) 'IIf(mv_dblMarginPrice > mv_dblSecMarginPrice, mv_dblSecMarginPrice, mv_dblMarginPrice)
                    End If


                    If CDbl(Me.lblCI.Text) > 0 AndAlso (1 - (mv_dblMarginRatioRate / 100) * mv_dblSecMarginPrice / v_dblQP * (1 - mv_dblDefFeeRate)) <> 0 AndAlso mv_dblISLATETRANSFER = 0 Then
                        v_dblPPSE = FRound(CDbl(Me.lblCI.Text) / (1 - (mv_dblMarginRatioRate / 100) * mv_dblSecMarginPrice / v_dblQP * (1 - mv_dblDefFeeRate)), 0)
                    Else
                        v_dblPPSE = CDbl(Me.lblCI.Text)
                    End If

                    v_dblPPSE = Math.Min(v_dblPPSE, CDbl(Me.lblCI.Text) + mv_dblPRAvlLimit)


                    If v_dblPPSE > mv_dblAvlLimit Then
                        v_dblPPSE = mv_dblAvlLimit
                    End If
                    Me.lblPPSE.Text = Format(v_dblPPSE, "#,###")
                Catch ex As Exception
                    Me.lblPPSE.Text = Me.lblCI.Text
                Finally

                End Try
            End If
        Else
            Me.lblPPSE.Text = Me.lblCI.Text
        End If
    End Sub
    Private Sub SetAFStatusEmpty()
        picSignature.Image = Nothing
        picSignature.Refresh()
        SEMemberGrid.DataRows.Clear()
        MemberGrid.DataRows.Clear()
        Me.lblAAMT.Text = "0"
        Me.lblCI.Text = "0"
        Me.lblTotal.Text = "0"
    End Sub

    Private Sub GetAFLinkAuth(ByVal pv_strAFACCTNO As String)
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strCmdSQL As String, v_strObjMsg As String
        Dim pv_PosAuth As Integer
        Try

            If Strings.Right(cboExecType.SelectedValue, 1) = "B" Then
                pv_PosAuth = 4
            Else
                pv_PosAuth = 5
            End If

            'Remove các bản ghi cũ
            MemberGrid.DataRows.Clear()
            'AND CD.CDVAL='" & gc_LINKTYPE_MEMBER & "' 
            'Lấy thông tin v? thành viên hợp đồng va thông tin v? ngư?i được ủy quy?n
            v_strCmdSQL = "SELECT LNK.AUTOID, 'M' TYP, CF.CUSTID, CF.IDCODE, CF.FULLNAME, CD.CDCONTENT REF, LNK.ACCTNO " & ControlChars.CrLf _
                & "  FROM CFMAST CF, CFLINK LNK, ALLCODE CD " & ControlChars.CrLf _
                & "  WHERE CF.CUSTID=LNK.CUSTID AND LNK.LINKTYPE=CD.CDVAL " & ControlChars.CrLf _
                & "      AND CD.CDTYPE='CF' AND CD.CDNAME='LINKTYPE' " & ControlChars.CrLf _
                & "      AND LNK.ACCTNO='" & pv_strAFACCTNO & "' AND SUBSTR(LINKAUTH,4,2) IN ('YN','NY','YY') " & ControlChars.CrLf _
                & "UNION ALL " & ControlChars.CrLf _
                & "SELECT CFAUTH.AUTOID, 'A' TYP, CFAUTH.CUSTID, LICENSENO IDCODE, FULLNAME, ADDRESS REF, CFAUTH.CFCUSTID ACCTNO " & ControlChars.CrLf _
                & "     FROM CFAUTH, AFMAST " & ControlChars.CrLf _
                & "     WHERE CFAUTH.CFCUSTID = AFMAST.CUSTID AND AFMAST.ACCTNO='" & pv_strAFACCTNO & "' AND SUBSTR(CFAUTH.LINKAUTH, " & pv_PosAuth & ", 1) = 'Y' AND CFAUTH.EXPDATE >= TO_DATE('" & Me.BusDate & "','DD/MM/YYYY') AND CFAUTH.DELTD<>'Y'"

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            FillDataGrid(MemberGrid, v_strObjMsg, "")
        Catch ex As Exception
            'MsgBox(ex.Message, MsgBoxStyle.Information, Me.Text)
        End Try
    End Sub

    Private Sub GetSETrade(ByVal v_strCODEID As String)
        Try
            If cboCODEID.SelectedIndex >= 0 Then
                Dim v_nodeList As Xml.XmlNodeList
                Dim v_xmlDocument As New Xml.XmlDocument
                Dim v_strValue, v_strFLDNAME, v_strTEXT As String, i, j As Integer
                Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                Dim v_strCmdSQL As String, v_strObjMsg As String

                'Lấy thông tin v? khách hàng
                'v_strCmdSQL = "Select SE.TRADE,SE.MORTAGE from SEMAST SE where SE.ACCTNO='" & Me.mskAFACCTNO.Text & v_strCODEID & "'"
                'v_strCmdSQL = "Select SE.TRADE-NVL(SECUREAMT,0) TRADE,SE.MORTAGE-NVL(SECUREMTG,0) MORTAGE from SEMAST SE, " & ControlChars.CrLf _
                '            & "(SELECT    SEACCTNO,  SUM (CASE WHEN OD.EXECTYPE IN ('NS', 'SS') THEN REMAINQTTY + EXECQTTY ELSE 0 END)  SECUREAMT, " & ControlChars.CrLf _
                '            & "      SUM (CASE WHEN OD.EXECTYPE ='MS' THEN REMAINQTTY + EXECQTTY ELSE 0 END)  SECUREMTG " & ControlChars.CrLf _
                '            & "      FROM ODMAST OD " & ControlChars.CrLf _
                '            & "      WHERE OD.TXDATE =TO_DATE ('" & mv_strBusDate & "', '" & gc_FORMAT_DATE & "')  " & ControlChars.CrLf _
                '            & "      AND OD.SEACCTNO='" & Me.mskAFACCTNO.Text & v_strCODEID & "' " & ControlChars.CrLf _
                '            & "      AND DELTD <> 'Y'  AND OD.EXECTYPE IN ('NS', 'SS','MS') GROUP BY SEACCTNO) D " & ControlChars.CrLf _
                '            & " where  SE.ACCTNO = D.SEACCTNO(+) AND SE.ACCTNO='" & Me.mskAFACCTNO.Text & v_strCODEID & "'"
                v_strCmdSQL = "SELECT SE.TRADE - NVL(SECUREAMT,0) + NVL(D.RECEIVING,0) TRADE, SE.MORTAGE - NVL(SECUREMTG,0) MORTAGE " & ControlChars.CrLf _
                            & "FROM SEMAST SE, " & ControlChars.CrLf _
                            & "(SELECT SEACCTNO, SUM(SECUREAMT) SECUREAMT, SUM(SECUREMTG) SECUREMTG, SUM(RECEIVING) RECEIVING " & ControlChars.CrLf _
                            & "     FROM (SELECT OD.SEACCTNO, " & ControlChars.CrLf _
                            & "             CASE WHEN OD.EXECTYPE IN ('NS', 'SS') AND OD.TXDATE =TO_DATE ('" & mv_strBusDate & "', '" & gc_FORMAT_DATE & "') THEN REMAINQTTY + EXECQTTY ELSE 0 END SECUREAMT, " & ControlChars.CrLf _
                            & "             CASE WHEN OD.EXECTYPE = 'MS'  AND OD.TXDATE =TO_DATE ('" & mv_strBusDate & "', '" & gc_FORMAT_DATE & "') THEN REMAINQTTY + EXECQTTY ELSE 0 END SECUREMTG, " & ControlChars.CrLf _
                            & "             CASE WHEN OD.EXECTYPE = 'NB' THEN ST.QTTY ELSE 0 END RECEIVING " & ControlChars.CrLf _
                            & "                 FROM ODMAST OD, STSCHD ST, ODTYPE TYP " & ControlChars.CrLf _
                            & "                 WHERE OD.SEACCTNO='" & Me.mskAFACCTNO.Text & v_strCODEID & "' " & ControlChars.CrLf _
                            & "                 AND OD.DELTD <> 'Y'  AND OD.EXECTYPE IN ('NS', 'SS','MS', 'NB') " & ControlChars.CrLf _
                            & "                 AND OD.ORDERID = ST.ORGORDERID(+) AND ST.DUETYPE(+) = 'RS' " & ControlChars.CrLf _
                            & "                 AND OD.ACTYPE = TYP.ACTYPE " & ControlChars.CrLf _
                            & "                 AND ((TYP.TRANDAY <= (SELECT SUM(CASE WHEN CLDR.HOLIDAY = 'Y' THEN 0 ELSE 1 END)-1 " & ControlChars.CrLf _
                            & "                                         FROM SBCLDR CLDR " & ControlChars.CrLf _
                            & "                                         WHERE CLDR.CLDRTYPE = '000' AND CLDR.SBDATE >= ST.TXDATE AND CLDR.SBDATE <= TO_DATE ('" & mv_strBusDate & "', '" & gc_FORMAT_DATE & "')) AND OD.EXECTYPE = 'NB') " & ControlChars.CrLf _
                            & "                     OR OD.EXECTYPE IN ('NS','SS','MS'))) GROUP BY SEACCTNO ) D " & ControlChars.CrLf _
                            & "WHERE SE.ACCTNO = D.SEACCTNO(+) AND SE.acctno = '" & Me.mskAFACCTNO.Text & v_strCODEID & "' "
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strCmdSQL)
                v_ws.Message(v_strObjMsg)
                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                If v_nodeList.Count < 1 Then
                    lblSE.Text = "0"
                    lblMortage.Text = "0"
                    Exit Sub
                End If
                For i = 0 To v_nodeList.Count - 1
                    For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            v_strValue = Trim(.InnerText.ToString)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME)
                                Case "TRADE"
                                    If Len(Trim(v_strValue)) > 0 Then
                                        lblSE.Text = Format(CDbl(v_strValue), "#,##0")
                                    Else
                                        lblSE.Text = "0"
                                    End If
                                Case "MORTAGE"
                                    If Len(Trim(v_strValue)) > 0 Then
                                        lblMortage.Text = Format(CDbl(v_strValue), "#,##0")
                                    Else
                                        lblMortage.Text = "0"
                                    End If
                            End Select
                        End With
                    Next
                Next
            End If
            'lblExtraInfo.Text = "SE: " & lblSE.Text & " - CI Bal.: " & lblCI.Text
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, Me.Text)
        End Try
    End Sub

    Private Sub GetSecuritiesInfo(ByVal v_strCODEID As String)
        Try
            'Lấy thông tin v? giá chứng khoán
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_strValue, v_strFLDNAME, v_strTEXT As String
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_strCmdSQL, v_strObjMsg As String
            'T11/2015 TTBT T+2. Begin
            'v_strCmdSQL = " SELECT SEINF.BASICPRICE, SEINF.FLOORPRICE,SEINF.MARGINPRICE, SEINF.CEILINGPRICE, SEINF.SECUREDRATIOMAX, SEINF.SECUREDRATIOMIN, SEINF.TRADELOT, " & ControlChars.CrLf _
            '                    & " SEINF.TRADEUNIT, SEINF.TRADEBUYSELL , SE.PARVALUE, A.CDCONTENT TRADING_CYCLE, B.FULLNAME, SE.TRADEPLACE, SE.SECTYPE, " & ControlChars.CrLf _
            '                    & " (CASE WHEN (TO_DATE(SEINF.LISTTINGDATE)=(SELECT TO_DATE(VARVALUE,'DD/MM/YYYY') CURRDATE FROM SYSVAR WHERE VARNAME='CURRDATE' " & ControlChars.CrLf _
            '                    & " AND GRNAME='SYSTEM') AND SE.TRADEPLACE='001') THEN 'Y' ELSE 'N' END ) FIRSTLISTTING ,NVL(RSK.MRRATIOLOAN,0) MRRATIOLOAN, NVL(RSK.MRPRICELOAN,0) MRPRICELOAN " & ControlChars.CrLf _
            '                    & " FROM SECURITIES_INFO SEINF,SBSECURITIES SE,ALLCODE A, ISSUERS B,(SELECT codeid,MRRATIOLOAN,MRPRICELOAN  FROM AFSERISK WHERE   ACTYPE= NVL('" & mv_strACTYPE & "','----')) RSK " & ControlChars.CrLf _
            '                    & " WHERE SEINF.CODEID=SE.CODEID AND SEINF.CODEID='" & v_strCODEID & "' AND A.CDVAL=SE.TRADEPLACE " & ControlChars.CrLf _
            '                    & " AND SE.ISSUERID = B.ISSUERID AND A.CDTYPE='SA' AND A.CDNAME='TRADING_CYCLE'  AND SE.CODEID= RSK.CODEID(+)" & ControlChars.CrLf

            'v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)

            
            v_strCmdSQL = " SELECT SEINF.BASICPRICE, SEINF.FLOORPRICE,SEINF.MARGINPRICE, SEINF.CEILINGPRICE, SEINF.SECUREDRATIOMAX, SEINF.SECUREDRATIOMIN, SEINF.TRADELOT, " & ControlChars.CrLf _
                    & " SEINF.TRADEUNIT, SEINF.TRADEBUYSELL , SE.PARVALUE,  B.FULLNAME, SE.TRADEPLACE, SE.SECTYPE, " & ControlChars.CrLf _
                    & " (CASE WHEN (TO_DATE(SEINF.LISTTINGDATE)=(SELECT TO_DATE(VARVALUE,'DD/MM/YYYY') CURRDATE FROM SYSVAR WHERE VARNAME='BUSDATE' " & ControlChars.CrLf _
                    & " AND GRNAME='SYSTEM') AND SE.TRADEPLACE='001') THEN 'Y' ELSE 'N' END ) FIRSTLISTTING " & ControlChars.CrLf _
                    & " FROM SECURITIES_INFO SEINF,SBSECURITIES SE, ISSUERS B" & ControlChars.CrLf _
                    & " WHERE SEINF.CODEID=SE.CODEID AND SEINF.CODEID='" & v_strCODEID & "'  " & ControlChars.CrLf _
                    & " AND SE.ISSUERID = B.ISSUERID " & ControlChars.CrLf


            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)

            'T11/2015 TTBT T+2. End
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            For i As Integer = 0 To v_nodeList.Count - 1
                v_strTEXT = String.Empty
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = Trim(.InnerText.ToString)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "BASICPRICE"
                                mv_dblBasicPrice = CDbl(v_strValue)
                            Case "FLOORPRICE"
                                mv_dblFloorPrice = CDbl(v_strValue)
                            Case "MARGINPRICE"
                                mv_dblMarginPrice = CDbl(v_strValue)
                            Case "MARGINREFPRICE"
                                mv_dblMarginRefPrice = CDbl(v_strValue)
                            Case "CEILINGPRICE"
                                mv_dblCeilingPrice = CDbl(v_strValue)
                            Case "TRADELOT"
                                mv_dblTradeLot = CDbl(v_strValue)
                            Case "TRADEUNIT"
                                mv_dblTmpTradeUnit = 1 'CDbl(v_strValue)
                                mv_dblTradeUnit = CDbl(v_strValue)
                            Case "PARVALUE"
                                mv_dbdParvalue = CDbl(v_strValue)
                            Case "SECUREDRATIOMIN"
                                mv_dblSecureBratioMin = CDbl(v_strValue)
                            Case "SECUREDRATIOMAX"
                                mv_dblSecureBratioMax = CDbl(v_strValue)
                            Case "FULLNAME"
                                Me.lblSEName.Text = v_strValue
                            Case "TRADEPLACE"
                                Me.txtTradePalce.Text = v_strValue
                            Case "SECTYPE"
                                Me.txtSecType.Text = v_strValue
                            Case "FIRSTLISTTING"
                                Me.txtFirstListting.Text = v_strValue
                            Case "MRRATIOLOAN"
                                mv_dblMarginRatioRate = CDec(Trim(v_strValue))
                            Case "MRPRICELOAN"
                                mv_dblSecMarginPrice = CDec(Trim(v_strValue))
                        End Select
                    End With
                Next
                v_strTEXT = " [" & mv_ResourceManager.GetString("REFPRICE") & mv_dblBasicPrice / mv_dblTradeUnit & "] " & _
                    "[" & mv_ResourceManager.GetString("FLOORPRICE") & mv_dblFloorPrice / mv_dblTradeUnit & "] " & _
                    "[" & mv_ResourceManager.GetString("CEILINGPRICE") & mv_dblCeilingPrice / mv_dblTradeUnit & "] " & _
                    "[" & mv_ResourceManager.GetString("TRADELOT") & mv_dblTradeLot & "] " & _
                    "[" & mv_ResourceManager.GetString("TRADEUNIT") & mv_dblTradeUnit & "] "
                Me.lblSymbolInfo.Text = v_strTEXT

            Next


            If mskAFACCTNO.Text.Length <> 0 Then
                Dim v_strCmdSQL2 As String
                'T11/2015 TTBT T+2. Begin
                'v_strCmdSQL = " SELECT SEINF.BASICPRICE, SEINF.FLOORPRICE,SEINF.MARGINPRICE, SEINF.CEILINGPRICE, SEINF.SECUREDRATIOMAX, SEINF.SECUREDRATIOMIN, SEINF.TRADELOT, " & ControlChars.CrLf _
                '                    & " SEINF.TRADEUNIT, SEINF.TRADEBUYSELL , SE.PARVALUE, A.CDCONTENT TRADING_CYCLE, B.FULLNAME, SE.TRADEPLACE, SE.SECTYPE, " & ControlChars.CrLf _
                '                    & " (CASE WHEN (TO_DATE(SEINF.LISTTINGDATE)=(SELECT TO_DATE(VARVALUE,'DD/MM/YYYY') CURRDATE FROM SYSVAR WHERE VARNAME='CURRDATE' " & ControlChars.CrLf _
                '                    & " AND GRNAME='SYSTEM') AND SE.TRADEPLACE='001') THEN 'Y' ELSE 'N' END ) FIRSTLISTTING ,NVL(RSK.MRRATIOLOAN,0) MRRATIOLOAN, NVL(RSK.MRPRICELOAN,0) MRPRICELOAN " & ControlChars.CrLf _
                '                    & " FROM SECURITIES_INFO SEINF,SBSECURITIES SE,ALLCODE A, ISSUERS B,(SELECT codeid,MRRATIOLOAN,MRPRICELOAN  FROM AFSERISK WHERE   ACTYPE= NVL('" & mv_strACTYPE & "','----')) RSK " & ControlChars.CrLf _
                '                    & " WHERE SEINF.CODEID=SE.CODEID AND SEINF.CODEID='" & v_strCODEID & "' AND A.CDVAL=SE.TRADEPLACE " & ControlChars.CrLf _
                '                    & " AND SE.ISSUERID = B.ISSUERID AND A.CDTYPE='SA' AND A.CDNAME='TRADING_CYCLE'  AND SE.CODEID= RSK.CODEID(+)" & ControlChars.CrLf

                'v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)

                Dim v_strExectype As String = String.Empty
                If Me.cboExecType.Text.Length <> 0 Then
                    v_strExectype = Me.cboExecType.SelectedValue
                End If

                Dim v_strPricetype As String = String.Empty
                If Me.cboPriceType.Text.Length <> 0 Then
                    v_strPricetype = Me.cboPriceType.SelectedValue
                End If

                Dim v_strVia As String = String.Empty
                If Me.cboVia.Text.Length <> 0 Then
                    v_strVia = Me.cboVia.SelectedValue
                End If
                v_strVia = "F"
                v_strCmdSQL2 = " SELECT  OD.CLEARDAY TRADING_CYCLE " & ControlChars.CrLf _
                        & " FROM SBSECURITIES SE, AFMAST AF, ODTYPE OD " & ControlChars.CrLf _
                        & " WHERE  SE.CODEID='" & v_strCODEID & "'  " & ControlChars.CrLf _
                        & " AND AF.ACCTNO = '" & Trim(mskAFACCTNO.Text) & "' " & ControlChars.CrLf _
                        & " AND OD.ACTYPE = FOPKS_API.FN_GETODACTYPE('" & Trim(mskAFACCTNO.Text) & "',SE.SYMBOL,SE.CODEID, SE.TRADEPLACE,'" & v_strExectype & "', '" & v_strPricetype & "','T', AF.ACTYPE,SE.SECTYPE, '" & v_strVia & "' ) " & ControlChars.CrLf

                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL2)
                v_ws.Message(v_strObjMsg)
                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

                For i As Integer = 0 To v_nodeList.Count - 1
                    'v_strTEXT = String.Empty
                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            v_strValue = Trim(.InnerText.ToString)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME)

                                Case "TRADING_CYCLE"
                                    Me.txtClearingDay.Text = v_strValue

                            End Select
                        End With
                    Next
                    'T11/2015 TTBT T+2. End
                Next
            End If

            'LAY RA THONG TIN MARGIN
            If mv_dblMarginRatioRate >= 100 Or mv_dblMarginRatioRate < 0 Then mv_dblMarginRatioRate = 0
            mv_dblSecMarginPrice = IIf(mv_dblMarginPrice > mv_dblSecMarginPrice, mv_dblSecMarginPrice, mv_dblMarginPrice)
            'HIEN THI LAI THONG TIN PPSE
            SetPPSE()
            If Len(Trim(Me.mskAFACCTNO.Text)) > 0 Then
                GetSETrade(cboCODEID.SelectedValue)
            End If

            'PhuongHT ghep HNX_UPDATE
            ' Dim v_IntIndex As Integer = 0
            Dim v_IntIndex As Integer = IIf(IsNumeric(cboPriceType.SelectedIndex), cboPriceType.SelectedIndex, 0)
            If Me.txtTradePalce.Text = c_HA_TRADEPLACE Then
                v_strCmdSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, LSTODR FROM ALLCODE WHERE CDTYPE='OD' AND CDNAME='PRICETYPE' AND CDUSER = 'Y' AND CDVAL not in  ('MP','ATO') ORDER BY LSTODR"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
                v_ws.Message(v_strObjMsg)
                mv_strHAPriceTypeMessage = v_strObjMsg
                FillComboEx(v_strObjMsg, cboPriceType, "", Me.UserLanguage)
                cboPriceType.SelectedIndex = v_IntIndex

            ElseIf Me.txtTradePalce.Text = c_HO_TRADEPLACE Then
                v_strCmdSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, LSTODR FROM ALLCODE WHERE CDTYPE='OD' AND CDNAME='PRICETYPE' AND CDVAL in ('LO','ATO','ATC','MP') AND CDUSER = 'Y' ORDER BY LSTODR"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
                v_ws.Message(v_strObjMsg)
                mv_strHOPriceTypeMessage = v_strObjMsg
                FillComboEx(v_strObjMsg, cboPriceType, "", Me.UserLanguage)
                cboPriceType.SelectedIndex = v_IntIndex
            ElseIf Me.txtTradePalce.Text = c_UPCOM_TRADEPLACE Then
                v_strCmdSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, LSTODR FROM ALLCODE WHERE CDTYPE='OD' AND CDNAME='PRICETYPE' AND CDVAL ='LO' AND CDUSER = 'Y' ORDER BY LSTODR"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
                v_ws.Message(v_strObjMsg)
                mv_strHOPriceTypeMessage = v_strObjMsg
                FillComboEx(v_strObjMsg, cboPriceType, "", Me.UserLanguage)
                cboPriceType.SelectedIndex = v_IntIndex
            Else
                v_strCmdSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, LSTODR FROM ALLCODE WHERE CDTYPE='OD' AND CDNAME='PRICETYPE' AND CDUSER = 'Y' AND CDVAL not in ('MP','ATO') ORDER BY LSTODR"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
                v_ws.Message(v_strObjMsg)
                mv_strUPCOMPriceTypeMessage = v_strObjMsg
                FillComboEx(v_strObjMsg, cboPriceType, "", Me.UserLanguage)
                cboPriceType.SelectedIndex = v_IntIndex
            End If

            If txtSecType.Text = "003" Or txtSecType.Text = "006" Or txtSecType.Text = "222" Then
                txtClearingDay.Text = "1"
            End If

            ' end of PhuongHT ghep HNX_UPDATE
            'Neu cua san ha noi thi chi co lenh LO

            'If Me.txtTradePalce.Text = c_HA_TRADEPLACE Then
            '    If Not mv_dblOnload Then
            '        If mv_strHAPriceTypeMessage.Length > 0 Then
            '            FillComboEx(mv_strHAPriceTypeMessage, cboPriceType, "", Me.UserLanguage)
            '        Else
            '            'v_strCmdSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, LSTODR FROM ALLCODE WHERE CDTYPE='OD' AND CDNAME='PRICETYPE' AND CDUSER= 'Y' AND CDVAL <> 'MP' ORDER BY LSTODR"
            '            If UpcomOrder Then
            '                v_strCmdSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, LSTODR FROM ALLCODE WHERE CDTYPE='OD' AND CDNAME='PRICETYPE' AND CDUSER='Y' AND CDVAL ='LO'   ORDER BY LSTODR"
            '            Else
            '                v_strCmdSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, LSTODR FROM ALLCODE WHERE CDTYPE='OD' AND CDNAME='PRICETYPE' AND CDUSER='Y' AND CDVAL <>'MP'  ORDER BY LSTODR"
            '            End If
            '            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            '            v_ws.Message(v_strObjMsg)
            '            mv_strHAPriceTypeMessage = v_strObjMsg
            '            FillComboEx(v_strObjMsg, cboPriceType, "", Me.UserLanguage)
            '        End If
            '    End If
            '    'cboPriceType.SelectedValue = "LO"
            '    cboPriceType.Enabled = True
            'Else
            '    'If mv_blnIsDelete Then
            '    '    cboPriceType.Enabled = False
            '    'Else
            '    '    cboPriceType.Enabled = True
            '    'End If
            '    If Not mv_dblOnload Then
            '        If mv_strHOPriceTypeMessage.Length > 0 Then
            '            FillComboEx(mv_strHOPriceTypeMessage, cboPriceType, "", Me.UserLanguage)
            '        Else
            '            ' v_strCmdSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, LSTODR FROM ALLCODE WHERE CDTYPE='OD' AND CDNAME='PRICETYPE' AND CDUSER='Y' AND CDVAL ORDER BY LSTODR"
            '            If UpcomOrder Then
            '                v_strCmdSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, LSTODR FROM ALLCODE WHERE CDTYPE='OD' AND CDNAME='PRICETYPE' AND CDUSER='Y' AND CDVAL IN ('LO') ORDER BY LSTODR"
            '            Else
            '                v_strCmdSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, LSTODR FROM ALLCODE WHERE CDTYPE='OD' AND CDNAME='PRICETYPE' AND CDUSER='Y' AND CDVAL IN ('LO','ATO','ATC','MP')  ORDER BY LSTODR"
            '            End If
            '            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            '            v_ws.Message(v_strObjMsg)
            '            mv_strHOPriceTypeMessage = v_strObjMsg
            '            FillComboEx(v_strObjMsg, cboPriceType, "", Me.UserLanguage)
            '        End If
            '        cboPriceType.SelectedIndex = v_IntIndex
            '    End If
            '    cboPriceType.Enabled = True

            'End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, Me.Text)
        End Try
    End Sub

    Public Overridable Sub OnSubmit()
        Dim v_strTxMsg As String, v_xmlDocument As New Xml.XmlDocument, v_attrColl As Xml.XmlAttributeCollection
        Dim v_intNOSUBMIT As Integer, v_strNEXTTX As String = String.Empty
        Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strLate As String
        Dim v_strObjMsg As String
        Dim v_strSQL As String
        Try
            'Control Validate
            If Not ControlValidation() Then
                Exit Sub
            End If

            'Block sell validate
            If cboExecType.SelectedValue = "MS" Then
                If Not CheckBlockSellQuantity() Then
                    Exit Sub
                End If
            End If
            If mv_strIsIssuer = "Y" And mskAFACCTNO.Enabled Then
                Dim v_strISSUER_MEMBER As String = String.Empty
                v_strISSUER_MEMBER = mv_ResourceManager.GetString("ISSUER_MEMBER")
                If MessageBox.Show(v_strISSUER_MEMBER, Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = DialogResult.Cancel Then
                    Exit Sub
                End If
            End If
            'If Me.txtFirstListting.Text.Length > 0 Then
            '    If txtFirstListting.Text = "Y" Then
            '        If cboPriceType.SelectedValue = "ATO" Then
            '            MessageBox.Show("You can't place ATO order in first listting date of securities !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '            cboPriceType.Focus()
            '        End If
            '    End If
            'End If

            '?ã nhập thông tin trên màn hình và submit gửi lên APP-SERVER để xử lý
            If mskAFACCTNO.Enabled Then 'Submit lần đầu tiên
                'Khởi tạo điện giao dịch
                MessageData = vbNullString
                'Lay thong tin Margin cua tai khoan
                'GetMarginInfo(Me.mskAFACCTNO.Text.Trim, cboCODEID.SelectedValue)
                'Verify và tạo điện giao dịch
                If Not VerifyRules(v_strTxMsg) Or Not CheckCIBalance() Or Not CheckTradeBuySell() Or Not CheckPTREPO() Then
                    Me.txtDescription.Text = "Orders making"
                    Exit Sub
                Else

                    If Not CheckPTREPO_Submit2() Then
                        Me.txtDescription.Text = "Orders making"
                        Exit Sub
                    End If

                    'Nếu giao dịch cần 02 lần SUBMIT thì Disable mskTransCode và hiển thị lại thông tin trả v?
                    'DisplayConfirm(v_xmlDocument)

                    'v_xmlDocument.Load("C:\TEMP\Order.xml")
                    ''v_xmlDocument.Save("D:\XML\BO\Sell_Order.xml")
                    'v_strTxMsg = v_xmlDocument.InnerXml
                    v_lngError = v_ws.Message(v_strTxMsg)

                    If v_lngError <> ERR_SYSTEM_OK Then
                        'Thông báo lỗi
                        GetErrorFromMessage(v_strTxMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                        Cursor.Current = Cursors.Default
                        If v_lngError <> ERR_SA_CHECKER1_OVR And v_lngError <> ERR_SA_CHECKER2_OVR Then
                            'Neu la tk corebank thi bo qua loi vuot qua suc mua, se hold sau
                            If (mv_strCOREBANK = "Y" Or mv_strSubCOREBANK = "Y") And v_lngError = ERR_CI_PP_NOT_ENOUGH_TO_BUY Then
                            Else
                                'Reset lai Description
                                Me.txtDescription.Text = "Orders making"
                                MessageBox.Show(v_strErrorMessage, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If
                        Else
                            'Lấy thêm nguyên nhân duyệt
                            GetReasonFromMessage(v_strTxMsg, v_strErrorMessage, Me.UserLanguage)
                            MessageBox.Show(v_strErrorMessage, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    End If
                    MessageData = v_strTxMsg
                    Call DisplayConfirm()
                End If
                ShowAdjustButton(True)
            Else 'Submit lần thứ hai (confirm)
                '?ẩy điện giao dịch lên APP-SERVER

                'Check trang thai lenh Repo lan 2
                If Not CheckPTREPO_Submit2() Then
                    Exit Sub
                End If

                v_xmlDocument.LoadXml(MessageData)

                v_strLate = CType(v_xmlDocument.DocumentElement.Attributes.GetNamedItem(gc_AtributeLATE), Xml.XmlAttribute).Value
                If String.Compare(v_strLate, "0") = 0 Then
                    'TungNT added - neu truong hop la corebank thi can phai lam giao dich hold truoc da
                    If mv_strCOREBANK = "Y" Or mv_strSubCOREBANK = "Y" Then
                        If "NB/BC/AB".IndexOf(cboExecType.SelectedValue.ToString().Trim().ToUpper()) >= 0 Then
                            Dim v_strRef As String = ""
                            v_strRef = cboExecType.SelectedValue.ToString().Trim().ToUpper() & "|" & _
                                        mskAFACCTNO.Text.Replace(".", "") & "|" & _
                                        mv_strCoreBankOdType & "|" & _
                                        mv_strCoreBankSymbol & "|" & _
                                        mv_dblCoreBankQtty.ToString() & "|" & _
                                        mv_dblCoreBankPrice.ToString()
                            If "AB".IndexOf(cboExecType.SelectedValue.ToString().Trim().ToUpper()) >= 0 Then
                                v_strRef &= "|" & mskOrderID.Text.Replace(".", "")
                            End If

                            v_strObjMsg = BuildXMLObjMsg(Me.TxDate, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "BankHoldDirect", , , v_strRef, Me.WsName, Me.IpAddress)
                            v_lngError = v_ws.Message(v_strObjMsg)
                            If v_lngError <> ERR_SYSTEM_OK Then
                                Me.ReturnValue = ""
                                'Thông báo lỗi
                                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                                Cursor.Current = Cursors.Default
                                MessageBox.Show(v_strErrorMessage, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If
                        End If
                    End If

                    'End
                    v_strTxMsg = MessageData
                    v_lngError = v_ws.Message(v_strTxMsg)
                    If v_lngError <> ERR_SYSTEM_OK Then
                        Me.ReturnValue = ""
                        'Thông báo lỗi
                        GetErrorFromMessage(v_strTxMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                        Cursor.Current = Cursors.Default
                        If v_lngError <> ERR_SA_CHECKER1_OVR And v_lngError <> ERR_SA_CHECKER2_OVR Then
                            MessageBox.Show(v_strErrorMessage, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        Else
                            'Lấy thêm nguyên nhân duyệt
                            GetReasonFromMessage(v_strTxMsg, v_strErrorMessage, Me.UserLanguage)
                            MessageBox.Show(v_strErrorMessage, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    Else
                        'Get OrderID
                        Dim v_node As XmlNode = v_xmlDocument.SelectSingleNode("TransactMessage/fields/entry[@fldname='04']")
                        If Not v_node Is Nothing Then
                            Me.ReturnValue = v_node.InnerXml
                        End If
                        'End


                        ''Ghi log giao dich
                        If Me.chkPTRepo.Checked And Me.mskREFORDERID.Text.Length = 0 Then
                            Dim v_strRef_ODREPO As String = String.Empty
                            ''TXDATE,TXNUM, AFACCTNO,ORDERID, CODEID, QUOTEPRICE, ORDERQTTY,PRICE2,EXPTDATE,EXECTYPE,DELTD,STATUS
                            'Me.mskAFACCTNO.Text.Replace(".", "") & "|" & _
                            v_strRef_ODREPO = Me.BusDate & "|" & _
                                        Me.TxNum.Replace(".", "") & "|" & _
                                        mv_strCUSTODYCD.Replace(".", "") & "|" & _
                                        Me.lblOrderID.Text.Replace(".", "") & "|" & _
                                        Me.cboCODEID.SelectedValue & "|" & _
                                        Me.txtQuotePrice.Text.Replace(",", "") & "|" & _
                                        Me.txtQuantity.Text & "|" & _
                                        Me.txtEXPTPRICE.Text.Replace(",", "") & "|" & _
                                        Me.dtpEXPTDATE.Text & "|" & _
                                        Me.cboExecType.SelectedValue & "|" & "|" & "|"
                            ''& "|N"
                            Dim v_strObj_REPO As String = BuildXMLObjMsg(Me.TxDate, Me.BranchId, , Me.TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_OD_ODMAST, gc_ActionAdhoc, , , "InsertData4LogODPT_REPO", , , v_strRef_ODREPO, Me.WsName, Me.IpAddress)
                            v_lngError = v_ws.Message(v_strObj_REPO)
                            If v_lngError <> ERR_SYSTEM_OK Then
                                'ThÃ´ng bÃ¡o lá»—i
                                GetErrorFromMessage(v_strObj_REPO, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                                Cursor.Current = Cursors.Default
                                MessageBox.Show(v_strErrorMessage, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If
                        ElseIf Me.chkPTRepo.Checked And Me.mskREFORDERID.Text.Length > 0 Then

                            '''Cap nhat trang thai LOG
                            ''Ghi log giao dich
                            Dim v_strRef_ODREPO As String = String.Empty
                            ''TXDATE,TXNUM, AFACCTNO,ORDERID, CODEID, QUOTEPRICE, ORDERQTTY,PRICE2,EXPTDATE,EXECTYPE,DELTD,STATUS
                            v_strRef_ODREPO = Me.mv_strOldRefOrderID & "|" & Me.lblOrderID.Text.Trim.Replace(".", "") & "|"
                            Dim v_strObj_REPO As String = BuildXMLObjMsg(Me.TxDate, Me.BranchId, , Me.TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_OD_ODMAST, gc_ActionAdhoc, , , "UpdateStatusLogODPT_REPO", , , v_strRef_ODREPO, Me.WsName, Me.IpAddress)
                            v_lngError = v_ws.Message(v_strObj_REPO)
                            If v_lngError <> ERR_SYSTEM_OK Then
                                'ThÃ´ng bÃ¡o lá»—i
                                GetErrorFromMessage(v_strObj_REPO, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                                Cursor.Current = Cursors.Default
                                MessageBox.Show(v_strErrorMessage, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub

                            End If
                        End If
                    End If
                End If
                If CloseOnFinish = True Then
                    Me.Close()
                Else
                    ResetScreen(Me)
                    ShowAdjustButton(False)
                End If
            End If
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub OnAdjust()
        Try
            Getratiolimit()
            If Len(MessageData) > 0 Then
                MessageData = vbNullString
            End If

            pnOrderConfirm.Visible = False
            pnOrder.Visible = True

            If mv_blnIsDelete Then
                ResetScreen(Me)
                ResetDeleteButton()
            End If

            If mv_blnShowOfficerFunction Then
                lblOrderID.Text = String.Empty
                mv_blnShowOfficerFunction = False
            End If

            ShowAdjustButton(False)
            If Me.btnAdjust.Visible = True Then
                mv_strIsAdjust = "Y"
            Else
                mv_strIsAdjust = "N"
            End If
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub OnApprove()
        Try
            If MsgBox(mv_ResourceManager.GetString("ApproveConfirm"), MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton1, Me.Text) = MsgBoxResult.Yes Then
                'Lấy TXDATE và TXNUM
                Dim v_strTXNUM, v_strTXDATE, v_strTxMsg As String, v_intSTATUS As Integer, v_strOVRRQS, v_strCHKID, v_strOFFID, v_strDELTD As String
                Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
                v_strTXNUM = Me.TxNum
                v_strTXDATE = Me.TxDate
                'Lấy thông tin chi tiết v? �điện giao dịch
                Dim v_strClause, v_strObjMsg As String
                Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument
                Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery

                'Lấy thông tin chung v? giao d�ịch. Message trả v? s�ẽ là TxMessage
                v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "GetMessage", , v_strTXNUM)
                v_ws.Message(v_strObjMsg)
                v_xmlDocument.LoadXml(v_strObjMsg)
                Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
                v_intSTATUS = CInt(CType(v_attrColl.GetNamedItem(gc_AtributeSTATUS), Xml.XmlAttribute).Value)
                v_strOVRRQS = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOVRRQS), Xml.XmlAttribute).Value)
                v_strCHKID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCHKID), Xml.XmlAttribute).Value)
                v_strOFFID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOFFID), Xml.XmlAttribute).Value)
                v_strDELTD = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeDELTD), Xml.XmlAttribute).Value)
                If v_intSTATUS = TransactStatus.Pending And Trim(v_strDELTD) <> "Y" Then
                    'Chỉ cho phép duyệt đối với những giao dịch chưa hoàn tất và 
                    If (Len(Trim(Replace(v_strOVRRQS, OVRRQS_CHECKER_CONTROL, vbNullString))) > 0 And Len(v_strCHKID) = 0) _
                        Or (InStr(v_strOVRRQS, OVRRQS_CHECKER_CONTROL) > 0 And Len(v_strOFFID) = 0) Then
                        v_strObjMsg = String.Empty
                        v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , TellerType, "ApproveMessage", , v_strTXNUM)
                        v_lngError = v_ws.Message(v_strObjMsg)
                        If v_lngError <> ERR_SYSTEM_OK Then
                            'Thông báo lỗi
                            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                            Cursor.Current = Cursors.Default
                            MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                            Exit Sub
                        End If
                        MessageBox.Show(mv_ResourceManager.GetString("ApproveSuccessful"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

                        'show giao dịch tiếp theo
                        Me.Dispose()
                        'ShowNextTran()
                    End If
                End If
            End If
            OnClose()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub OnDelete(ByVal isAmendment As Boolean)
        Dim v_strTxMsg As String, v_xmlDocument As New Xml.XmlDocument, v_attrColl As Xml.XmlAttributeCollection
        Dim v_intNOSUBMIT As Integer, v_strNEXTTX As String = String.Empty
        Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try

            'Check account
            If Not mv_strNewAFACCTNO Is Nothing And mv_strNewAFACCTNO <> mskAFACCTNO.Text And mskAFACCTNO.Text Is Nothing Then
                MessageBox.Show(mv_ResourceManager.GetString("INV_ACCNUMBER"))
                If Me.mv_blnIsDelete And txtOrStatus.Text = "Pending to Send" Then
                    'Nếu là lệnh huỷ sửa khi cancel thì giải toả trạng thái để cho phép Send
                    OnCancelCorection()
                End If
                ResetScreen(Me)
                ShowAdjustButton(False)
                ResetDeleteButton()
                Exit Sub
            End If

            mv_blnAmendment = isAmendment

            If Not mv_blnAmendment Then
                Me.txtQuantity.Text = mv_dblQtty
                Me.txtQuotePrice.Text = mv_dblPrice
                Me.cboPriceType.Text = mv_strOldPriceType
                Me.txtExecQtty.Text = mv_dblExecQtty

            End If
            If mv_blnIsDelete = False Then
                mv_blnIsDelete = True
                ResetScreen(Me)
                DeleteScreen(mv_blnIsDelete)
            Else
                'Control Validate
                If Not ControlValidation() Then
                    Exit Sub
                End If
                '?ã nhập thông tin trên màn hình và submit gửi lên APP-SERVER để xử lý
                If mskAFACCTNO.Enabled Then 'Submit lần đầu tiên
                    'Khởi tạo điện giao dịch
                    MessageData = vbNullString
                    'Verify và tạo điện giao dịch
                    If Not VerifyRules(v_strTxMsg) Then
                        Exit Sub
                    Else
                        'MessageData = v_strTxMsg
                        ''Nếu giao dịch cần 02 lần SUBMIT thì Disable mskTransCode và hiển thị lại thông tin trả v?
                        ''DisplayConfirm(v_xmlDocument)
                        'Call DisplayConfirm()

                        v_lngError = v_ws.Message(v_strTxMsg)
                        If v_lngError <> ERR_SYSTEM_OK Then
                            'Thông báo lỗi
                            GetErrorFromMessage(v_strTxMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                            Cursor.Current = Cursors.Default
                            If v_lngError <> ERR_SA_CHECKER1_OVR And v_lngError <> ERR_SA_CHECKER2_OVR Then
                                MessageBox.Show(v_strErrorMessage, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            Else
                                'Lấy thêm nguyên nhân duyệt
                                GetReasonFromMessage(v_strTxMsg, v_strErrorMessage, Me.UserLanguage)
                                MessageBox.Show(v_strErrorMessage, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If
                        End If
                        MessageData = v_strTxMsg
                        Call DisplayConfirm()
                    End If
                    'ShowAdjustButton(True)
                Else 'Submit lần thứ hai (confirm)
                    '?ẩy điện giao dịch lên APP-SERVER

                    'TungNT added - neu truong hop la corebank thi can phai lam giao dich hold truoc da
                    If mv_strCOREBANK = "Y" Then
                        If mv_blnAmendment And mv_dblOldQtty * mv_dblOldPrice - CDbl(txtQuotePrice.Text) * CDbl(txtQuantity.Text) < 0 Then
                            'Tinh lai phan can phai hold 
                            Dim x As Double
                            x = CDbl(txtQuotePrice.Text) * CDbl(txtQuantity.Text) - mv_dblOldQtty * mv_dblOldPrice
                            mv_dblCoreBankPrice = Math.Round(x / CDbl(mv_dblCoreBankQtty), 4)
                            'mv_dblCoreBankQtty = Math.Round(x / CDbl(mv_dblCoreBankPrice), 4)
                            If "NB/BC/AB".IndexOf(cboExecType.SelectedValue.ToString().Trim().ToUpper()) >= 0 Then '"AB".IndexOf(cboExecType.SelectedValue.ToString().Trim().ToUpper()) >= 0 Then
                                Dim v_strRef As String = ""
                                v_strRef = cboExecType.SelectedValue.ToString().Trim().ToUpper() & "|" & _
                                        mskAFACCTNO.Text.Replace(".", "") & "|" & _
                                        mv_strCoreBankOdType & "|" & _
                                        mv_strCoreBankSymbol & "|" & _
                                        mv_dblCoreBankQtty.ToString() & "|" & _
                                        mv_dblCoreBankPrice.ToString() & "|" & _
                                        mskOrderID.Text.Replace(".", "")

                                Dim v_strObjMsg As String = BuildXMLObjMsg(Me.TxDate, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "BankHoldDirect", , , v_strRef, Me.WsName, Me.IpAddress)
                                v_lngError = v_ws.Message(v_strObjMsg)
                                If v_lngError <> ERR_SYSTEM_OK Then
                                    Me.ReturnValue = ""
                                    'Thông báo lỗi
                                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                                    Cursor.Current = Cursors.Default
                                    MessageBox.Show(v_strErrorMessage, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    Exit Sub
                                End If
                            End If
                        End If
                    End If
                    'End

                    v_strTxMsg = MessageData
                    v_lngError = v_ws.Message(v_strTxMsg)
                    If v_lngError <> ERR_SYSTEM_OK Then
                        'Thông báo lỗi
                        GetErrorFromMessage(v_strTxMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                        Cursor.Current = Cursors.Default
                        If v_lngError <> ERR_SA_CHECKER1_OVR And v_lngError <> ERR_SA_CHECKER2_OVR Then
                            MessageBox.Show(v_strErrorMessage, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        Else
                            'Lấy thêm nguyên nhân duyệt
                            GetReasonFromMessage(v_strTxMsg, v_strErrorMessage, Me.UserLanguage)
                            MessageBox.Show(v_strErrorMessage, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    End If
                    ResetScreen(Me)
                    ShowAdjustButton(False)
                    ResetDeleteButton()
                End If
            End If
            If Me.mskAFACCTNO.Enabled = False Then
                If mv_blnAmendment Then
                    Me.btnAmendment.Enabled = True
                    Me.btnDelete.Enabled = False
                Else
                    Me.btnAmendment.Enabled = False
                    Me.btnDelete.Enabled = True
                End If
            End If
        Catch ex As Exception
            LogError.Write("Error source: AppCore.frmSearch.SaveLastSearch" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub OnRefuse()
        Try
            'Modified by ChienTD 12/01/2007
            'Purpose: Confirm before action
            If MsgBox(mv_ResourceManager.GetString("RefuseConfirm"), MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Me.Text) = MsgBoxResult.Yes Then
                'Lấy TXDATE và TXNUM
                Dim v_strTXNUM, v_strTXDATE, v_strTxMsg As String, v_intSTATUS As Integer, v_strOVRRQS, v_strCHKID, v_strOFFID, v_strDELTD As String
                Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long

                v_strTXNUM = Me.TxNum 'Trim(CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("TXNUM").Value)
                v_strTXDATE = Me.TxDate 'Trim(CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("TXDATE").Value)
                'Lấy thông tin chi tiết v? �điện giao dịch
                Dim v_strClause, v_strObjMsg As String
                Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument
                Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery

                'Lấy thông tin chung v? giao d�ịch. Message trả v? s�ẽ là TxMessage
                v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "GetMessage", , v_strTXNUM)
                v_ws.Message(v_strObjMsg)
                v_xmlDocument.LoadXml(v_strObjMsg)
                Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
                v_intSTATUS = CInt(CType(v_attrColl.GetNamedItem(gc_AtributeSTATUS), Xml.XmlAttribute).Value)
                v_strOVRRQS = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOVRRQS), Xml.XmlAttribute).Value)
                v_strCHKID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCHKID), Xml.XmlAttribute).Value)
                v_strOFFID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOFFID), Xml.XmlAttribute).Value)
                v_strDELTD = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeDELTD), Xml.XmlAttribute).Value)
                If v_intSTATUS = TransactStatus.Pending And Trim(v_strDELTD) <> "Y" Then
                    'Chỉ cho phép duyệt đối với những giao dịch chưa hoàn tất và 
                    If (Len(Trim(Replace(v_strOVRRQS, OVRRQS_CHECKER_CONTROL, vbNullString))) > 0 And Len(v_strCHKID) = 0) _
                        Or (InStr(v_strOVRRQS, OVRRQS_CHECKER_CONTROL) > 0 And Len(v_strOFFID) = 0) Then
                        v_strObjMsg = String.Empty
                        v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , TellerType, "RefuseMessage", , v_strTXNUM)
                        v_lngError = v_ws.Message(v_strObjMsg)
                        If v_lngError <> ERR_SYSTEM_OK Then
                            'Thông báo lỗi
                            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                            Cursor.Current = Cursors.Default
                            MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                            Exit Sub
                        End If
                        MessageBox.Show(mv_ResourceManager.GetString("RefusedSuccessful"))
                        'OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName)
                        Me.Dispose()
                    End If
                End If
            End If
            OnClose()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub OnReject()
        Try
            'Modified by ChienTD 12/01/2007
            'Purpose: Confirm before action
            If MsgBox(mv_ResourceManager.GetString("RejectConfirm"), MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Me.Text) = MsgBoxResult.Yes Then
                'Lấy TXDATE và TXNUM
                Dim v_strTXNUM, v_strTXDATE, v_strTxMsg As String, v_intSTATUS As Integer, v_strOVRRQS, v_strCHKID, v_strOFFID, v_strDELTD As String
                Dim v_strErrorSource, v_strErrorMessage, v_strCommentMessage As String, v_lngError As Long

                v_strTXNUM = Me.TxNum 'Trim(CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("TXNUM").Value)
                v_strTXDATE = Me.TxDate 'Trim(CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("TXDATE").Value)
                'Lấy thông tin chi tiết v? �điện giao dịch
                Dim v_strClause, v_strObjMsg As String
                Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument
                Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery

                'Lấy thông tin chung v? giao d�ịch. Message trả v? s�ẽ là TxMessage
                v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "GetMessage", , v_strTXNUM)
                v_ws.Message(v_strObjMsg)
                v_xmlDocument.LoadXml(v_strObjMsg)
                Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
                v_intSTATUS = CInt(CType(v_attrColl.GetNamedItem(gc_AtributeSTATUS), Xml.XmlAttribute).Value)
                v_strOVRRQS = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOVRRQS), Xml.XmlAttribute).Value)
                v_strCHKID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCHKID), Xml.XmlAttribute).Value)
                v_strOFFID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOFFID), Xml.XmlAttribute).Value)
                v_strDELTD = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeDELTD), Xml.XmlAttribute).Value)
                v_strCommentMessage = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXDESC), Xml.XmlAttribute).Value)
                If v_intSTATUS = TransactStatus.Pending And Trim(v_strDELTD) <> "Y" Then
                    'Chỉ cho phép duyệt đối với những giao dịch đang ch? duy�ệt và chưa bị xoá
                    If (Len(Trim(Replace(v_strOVRRQS, OVRRQS_CHECKER_CONTROL, vbNullString))) > 0 And Len(v_strCHKID) = 0) _
                        Or (InStr(v_strOVRRQS, OVRRQS_CHECKER_CONTROL) > 0 And Len(v_strOFFID) = 0) Then
                        'Hiển thị InputBox yêu cầu nhập lý do Reject
                        v_strCommentMessage = InputBox(mv_ResourceManager.GetString("ucSearch.RejectComment"), Me.Text, v_strCommentMessage)
                        If Len(Trim(v_strCommentMessage)) > 0 Then
                            v_strObjMsg = String.Empty
                            v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "RejectMessage", , v_strTXNUM, v_strCommentMessage)
                            v_lngError = v_ws.Message(v_strObjMsg)
                            If v_lngError <> ERR_SYSTEM_OK Then
                                'Thông báo lỗi
                                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                                Cursor.Current = Cursors.Default
                                MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                                Exit Sub
                            End If
                            MessageBox.Show(mv_ResourceManager.GetString("RerectedSuccessful"))
                            'OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName)
                            Me.Dispose()
                        End If
                    End If
                End If
            End If
            OnClose()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub OnClose()
        mv_blnisClosed = True
        Me.Dispose()
    End Sub

    Private Function GetOrderID() As String
        Dim v_strClause, v_strAutoID As String
        Dim v_int, v_intCount As Integer
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strFLDNAME, v_strVALUE As String
        'Lấy ra số tự tăng
        v_strClause = "SEQ_ODMAST"
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_wsBDS As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_strClause, "GetInventory")
        v_wsBDS.Message(v_strObjMsg)
        v_xmlDocument.LoadXml(v_strObjMsg)
        v_strAutoID = v_xmlDocument.DocumentElement.Attributes("CLAUSE").Value
        'Tạo số hiệu lệnh = Mã chi nhánh + Ngày hệ thống + Số tự tăng
        Dim v_strOrderID As String
        v_strOrderID = Me.BranchId & Mid(Replace(Me.BusDate, "/", vbNullString), 1, 4) & Mid(Replace(Me.BusDate, "/", vbNullString), 7, 2) & Strings.Right(gc_FORMAT_ODAUTOID & CStr(v_strAutoID), Len(gc_FORMAT_ODAUTOID))
        Return v_strOrderID
    End Function

    Private Sub LoadResource(ByRef pv_ctrl As Windows.Forms.Control)
        Dim v_ctrl As Windows.Forms.Control
        Try
            For Each v_ctrl In pv_ctrl.Controls
                If TypeOf (v_ctrl) Is Label Then
                    CType(v_ctrl, Label).Text = mv_ResourceManager.GetString(v_ctrl.Name)
                ElseIf TypeOf (v_ctrl) Is CheckBox Then
                    CType(v_ctrl, CheckBox).Text = mv_ResourceManager.GetString(v_ctrl.Name)
                ElseIf TypeOf (v_ctrl) Is GroupBox Then
                    CType(v_ctrl, GroupBox).Text = mv_ResourceManager.GetString(v_ctrl.Name)
                    LoadResource(v_ctrl)
                ElseIf TypeOf (v_ctrl) Is Button Then
                    CType(v_ctrl, Button).Text = mv_ResourceManager.GetString(v_ctrl.Name)
                ElseIf TypeOf (v_ctrl) Is Panel Then
                    LoadResource(v_ctrl)
                ElseIf TypeOf (v_ctrl) Is DateTimePicker Then
                    CType(v_ctrl, DateTimePicker).Value = CDate(Me.BusDate)
                End If
            Next
            Me.Text = mv_ResourceManager.GetString(Me.Name)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Function getTransBGColor(ByVal pv_intColor As Integer) As System.Drawing.Color
        Dim v_color As New System.Drawing.Color
        Select Case pv_intColor
            Case 0 'Default color
                'v_color = System.Drawing.SystemColors.InactiveCaptionText
                v_color = System.Drawing.Color.LightBlue
            Case 1 'Honeydew
                'v_color = System.Drawing.Color.Honeydew
                v_color = System.Drawing.Color.LightCoral
            Case 2 'LightGreen
                v_color = System.Drawing.Color.LightGreen
            Case 3 'DarkKhaki
                v_color = System.Drawing.Color.DarkKhaki
            Case 4 'Aquamarine
                v_color = System.Drawing.Color.Aquamarine
            Case 5 'Skyblue
                v_color = System.Drawing.Color.SkyBlue
            Case 6 'Violet
                v_color = System.Drawing.Color.Violet
            Case 7 'Lightpink
                v_color = System.Drawing.Color.LightPink
            Case 8 'LightSalomon
                v_color = System.Drawing.Color.LightSalmon
            Case Else
                v_color = System.Drawing.Color.Aqua
        End Select
        Return v_color
    End Function

    Private Function getTransBGColor(ByVal pv_strColor As String) As System.Drawing.Color
        Dim v_color As New System.Drawing.Color
        Select Case pv_strColor
            Case "NB" 'Default color
                'v_color = System.Drawing.SystemColors.InactiveCaptionText
                v_color = System.Drawing.Color.FromArgb(&HA7, &HCC, &HF0)
            Case "NS" 'Honeydew
                'v_color = System.Drawing.Color.Honeydew
                v_color = System.Drawing.Color.FromArgb(&HF5, &HC5, &HD9)
            Case "SS" 'LightGreen
                v_color = System.Drawing.Color.LightGreen
            Case "BC" 'DarkKhaki
                v_color = System.Drawing.Color.DarkKhaki
            Case "MS" 'Aquamarine
                v_color = System.Drawing.Color.Aquamarine
            Case Else
                v_color = System.Drawing.Color.Aqua
        End Select
        Return v_color
    End Function
    Private Function getMarginLoanSecureRatio(ByVal f_price As Double)
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_strValue, v_strFLDNAME, v_strTEXT As String, i, j As Integer
            Dim v_dblDFRate, v_dblDFPRICE As Double
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_strCmdSQL As String, v_strObjMsg As String
            v_dblDFRate = 0
            v_strCmdSQL = " select nvl(bk.dfrate,0) dfrate,nvl(bk.dfprice,0) dfprice from (select df.* from dfbasket df, sbsecurities sb where df.symbol = sb.symbol and sb.codeid ='" & Me.cboCODEID.SelectedValue & "') bk, aftype aft, dftype dft, afmast af where af.actype = aft.actype and aft.dftype = dft.actype and dft.basketid = bk.basketid (+) and af.acctno ='" & Trim(mskAFACCTNO.Text) & "' "
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_AFMAST, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            For i = 0 To v_nodeList.Count - 1
                For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        'Ghi nhận thuật toán để kiểm tra và tính toán cho từng trư?ng c�ủa giao dịch
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "DFRATE"
                                v_dblDFRate = CDbl(Trim(v_strValue))
                            Case "DFPRICE"
                                v_dblDFPRICE = CDbl(Trim(v_strValue))
                        End Select
                    End With
                Next
            Next
            If v_dblDFPRICE > 0 Then
                'Neu ty le giai ngan lon hon gia chan/ gia dat thi lay theo gia chan/ gia dat
                v_dblDFRate = IIf(v_dblDFRate > v_dblDFPRICE / f_price * 100, FRound(v_dblDFPRICE / f_price * 100, 4), v_dblDFRate)
            End If
            Return v_dblDFRate
        Catch ex As Exception
            Return 0
            Throw ex
        End Try
    End Function
    '= Max(Min(tỷ lệ ký quỹ trong H? * tr?ng số ký quỹ theo order type, 100%), tỷ lệ ký quỹ của sys) 
    '        + Max (phí giao dịch theo loại hình lệnh của KH)
    Private Function GetSecureRatio() As Decimal
        Dim v_dblSecureRatio, v_dblFeeSecureRatioMin As Double
        If Me.mv_strMarginType = "S" Or Me.mv_strMarginType = "T" Or Me.mv_strMarginType = "N" Then
            'Neu la tai khoan Margin thi ky quy 100%, tai khoan binh thuong ky quy 100%
            v_dblSecureRatio = 100
        ElseIf Me.mv_strMarginType = "L" Then
            v_dblSecureRatio = Math.Max(100 - getMarginLoanSecureRatio(mv_dblPrice * mv_dblTradeUnit), 0)
        Else
            v_dblSecureRatio = Math.Max(Math.Min(mv_dblTyp_Bratio + mv_dblAF_Bratio, 100), mv_dblSecureBratioMin)
            v_dblSecureRatio = CDec(IIf(v_dblSecureRatio > mv_dblSecureBratioMax, mv_dblSecureBratioMax, v_dblSecureRatio))
        End If

        'Cộng thêm ký quỹ cho phí giao dịch theo loại hình lệnh
        '1.Phí tối thiểu. Nếu phí tối thiểu
        '2. Giá trị giao dịch

        v_dblFeeSecureRatioMin = mv_dblFeeAmountMin * 100 / (CDbl(txtQuantity.Text) * mv_dblPrice * mv_dblTradeUnit)
        If v_dblFeeSecureRatioMin > mv_dblFeeRate Then
            v_dblSecureRatio += v_dblFeeSecureRatioMin
            mv_dblFeeAmount = mv_dblFeeAmountMin
        Else
            v_dblSecureRatio += mv_dblFeeRate
            mv_dblFeeAmount = mv_dblFeeRate * (CDbl(txtQuantity.Text) * mv_dblPrice * mv_dblTradeUnit) / 100
        End If

        'GetSecureRatio = Math.Min(mv_dblSecureBratioSYSMax, Math.Max(mv_dblSecureBratioSYSMin, v_dblSecureRatio))
        GetSecureRatio = v_dblSecureRatio

    End Function

    Private Function ControlValidation() As Boolean
        If mv_blnAmendment Then


            If mv_strOldPriceType = "LO" Then
                If txtQuotePrice.Text = mv_dblOldPrice And txtQuantity.Text = mv_dblOldQtty And cboMatchType.Text = mv_dblOldMatchType Then
                    MsgBox(mv_ResourceManager.GetString("NOTVALIDTOAMENDED"), MsgBoxStyle.Information, Me.Text)
                    Return False
                End If
            ElseIf (mv_strOldPriceType = "MTL" Or mv_strOldPriceType = "SBO" Or mv_strOldPriceType = "OBO") And txtQuotePrice.Enabled = True And txtQuantity.Enabled = True Then
                If txtQuotePrice.Text = mv_dblOldPrice And txtQuantity.Text = mv_dblOldQtty Then
                    MsgBox(mv_ResourceManager.GetString("NOTVALIDTOAMENDED"), MsgBoxStyle.Information, Me.Text)
                    Return False
                End If
            End If
            If txtQuantity.Enabled Then
                If mv_dblOldQtty - mv_dblRemainQtty >= CDbl(txtQuantity.Text) Then
                    MsgBox(mv_ResourceManager.GetString("INVALIDAMENDEDQTTY") & " " & mv_dblOldQtty - mv_dblRemainQtty, MsgBoxStyle.Information, Me.Text)
                    Me.ActiveControl = txtQuantity
                    Return False
                End If
            End If
        End If
        If cboPriceType.SelectedValue = "MO" And cboMatchType.SelectedValue = "P" Then
            MsgBox(mv_ResourceManager.GetString("ERR_INVALID_PTORDER"), MsgBoxStyle.Information, Me.Text)
            Return False
        End If
        If Len(Me.mskAFACCTNO.Text) = 0 Then
            MsgBox(mv_ResourceManager.GetString("ERR_FIELD_NULL"), MsgBoxStyle.Information, Me.Text)
            Me.ActiveControl = mskAFACCTNO
            Return False
        End If
        If Len(Me.txtQuantity.Text) = 0 Then
            MsgBox(mv_ResourceManager.GetString("ERR_FIELD_NULL"), MsgBoxStyle.Information, Me.Text)
            Me.ActiveControl = txtQuantity
            Return False
        End If
        If Len(Me.txtQuotePrice.Text) = 0 And Me.txtQuotePrice.Enabled = True Then
            MsgBox(mv_ResourceManager.GetString("ERR_FIELD_NULL"), MsgBoxStyle.Information, Me.Text)
            Me.ActiveControl = txtQuotePrice
            Return False
        End If
        If Len(Me.txtLimitPrice.Text) = 0 And Me.txtLimitPrice.Enabled = True Then
            MsgBox(mv_ResourceManager.GetString("ERR_FIELD_NULL"), MsgBoxStyle.Information, Me.Text)
            Me.ActiveControl = txtLimitPrice
            Return False
        End If
        If mv_dblTradeUnit <= 0 Or mv_dblFloorPrice <= 0 Or mv_dblCeilingPrice <= 0 Then
            MsgBox(mv_ResourceManager.GetString("ERR_SEC_INFO"), MsgBoxStyle.Information, Me.Text)
            Return False
        End If
        If Me.dtpExpiredDate.Value < Me.dtpEffectiveDate.Value Then
            MsgBox(mv_ResourceManager.GetString("ERR_EXPIREDDATE_INVALID"), MsgBoxStyle.Information, Me.Text)
            Me.ActiveControl = dtpExpiredDate
            Return False
        End If
        If Trim(Me.cboPriceType.SelectedValue) = "LO" Or Trim(Me.cboPriceType.SelectedValue) = "IO" _
                   Or Trim(Me.cboPriceType.SelectedValue) = "SO>" Or Trim(Me.cboPriceType.SelectedValue) = "SO<" Then
            If CInt(CDbl(txtQuotePrice.Text) * mv_dblTradeUnit) > CInt(mv_dblCeilingPrice) Then
                MsgBox(mv_ResourceManager.GetString("CEILINGINVALID"), MsgBoxStyle.Information, Me.Text)
                Me.ActiveControl = txtQuotePrice
                Return False
            ElseIf CInt(CDbl(txtQuotePrice.Text) * mv_dblTradeUnit) < CInt(mv_dblFloorPrice) Then
                MsgBox(mv_ResourceManager.GetString("FLOORINVALID"), MsgBoxStyle.Information, Me.Text)
                Me.ActiveControl = txtQuotePrice
                Return False
            End If
        End If


        If txtQuotePrice.Text.Trim.Length > 0 Then
            'Kiểm tra bước giá
            If IsNumeric(txtQuotePrice.Text) And _
                    (cboPriceType.SelectedValue = "LO" Or cboPriceType.SelectedValue = "SL") _
                                And (cboMatchType.SelectedValue <> "P" Or Me.txtTradePalce.Text = gc_TRADEPLACE_UPCOM) Then
                If Not CheckSETickSize() Then
                    Return False
                End If
            End If

        End If
        If txtLimitPrice.Enabled Then
            If Not IsNumeric(txtLimitPrice.Text) Then
                MsgBox(mv_ResourceManager.GetString("PRICEISNOTNUMBER"), MsgBoxStyle.Information, Me.Text)
                Return False
            ElseIf CDbl(txtLimitPrice.Text) < 0 Then
                MsgBox(mv_ResourceManager.GetString("PRICEISNOTNUMBER"), MsgBoxStyle.Information, Me.Text)
                Return False
            End If
            If txtLimitPrice.Text.Trim.Length > 0 Then
                'Ki?m tra bu?c giá
                If IsNumeric(txtLimitPrice.Text) And txtLimitPrice.Enabled And _
                        (cboPriceType.SelectedValue = "LO" Or cboPriceType.SelectedValue = "SO>" Or cboPriceType.SelectedValue = "SO<" _
                         Or cboPriceType.SelectedValue = "IO") _
                                    And (cboMatchType.SelectedValue <> "P" Or Me.txtTradePalce.Text = gc_TRADEPLACE_UPCOM) Then
                    If Not CheckSETickSize_1() Then
                        Return False
                    End If
                End If
            End If
        End If
        'Check lenh TT Repo
        If Me.chkPTRepo.Checked Then
            If Me.mskREFORDERID.Text.Length = 0 Then
                If Not IsNumeric(txtEXPTPRICE.Text) Then
                    MessageBox.Show(mv_ResourceManager.GetString("PRICEISNOTNUMBER"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.ActiveControl = txtEXPTPRICE
                    Return False
                ElseIf CDbl(txtEXPTPRICE.Text) <= 0 Then
                    MessageBox.Show(mv_ResourceManager.GetString("PRICEISNOTNUMBER"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.ActiveControl = txtEXPTPRICE
                    Return False
                End If
                If Me.dtpEXPTDATE.Value < Me.BusDate Then
                    MessageBox.Show(mv_ResourceManager.GetString("ERR_EXPIREDDATE_INVALID"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.ActiveControl = dtpEXPTDATE
                    Return False
                End If
            End If

        End If
        Return CheckPutthought()
    End Function

    'Hàm này tạo lại CreateFeemap trên cơ sở tham số định nghĩa trong bảng FEEMAP
    Private Function CreateFeemap(ByRef pv_xmlDocument As Xml.XmlDocument)
        Dim v_feeElement As Xml.XmlElement
        Dim v_entryNode As Xml.XmlNode
        Dim strTLTXCD, v_strFEECD, v_strGLACCTNO, v_strFORP, v_strAMTEXP, v_strVALEXP As String
        Dim v_dblTOTALFEEAMT, v_dblTOTALVATAMT, v_dblFLATAMT, v_dblFEEAMT, v_dblVATAMT, v_dblTXAMT, v_dblFEERATE, v_dblVATRATE, v_dblMINVAL, v_dblMAXVAL As Double

        'Lấy thông tin chung v? giao dịch
        strTLTXCD = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).InnerXml

        Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode, i, j As Integer, v_strValue, v_strFLDNAME As String
        Dim v_objEval As New Evaluator
        Dim v_xmlFeeDocument As New Xml.XmlDocument, v_xmlFeeDocumentData As New Xml.XmlDocument
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strSQL As String = "SELECT FEEMASTER.*,FEEMAP.AMTEXP FROM FEEMAP,FEEMASTER WHERE FEEMASTER.STATUS='Y' AND FEEMASTER.FEECD=FEEMAP.FEECD AND FEEMAP.TLTXCD='" & strTLTXCD & "'"
        Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLTX, gc_ActionInquiry, v_strSQL)
        v_ws.Message(v_strObjMsg)
        v_xmlFeeDocument.LoadXml(v_strObjMsg)
        v_nodeList = v_xmlFeeDocument.SelectNodes("/ObjectMessage/ObjData")
        v_feeElement = pv_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "feemap", "")
        v_dblTOTALFEEAMT = 0
        v_dblTOTALVATAMT = 0
        For i = 0 To v_nodeList.Count - 1
            'Lấy dữ liệu
            For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                With v_nodeList.Item(i).ChildNodes(j)
                    v_strValue = .InnerText.ToString
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    Select Case Trim(v_strFLDNAME)
                        Case "FEECD"
                            v_strFEECD = v_strValue
                        Case "GLACCTNO"
                            v_strGLACCTNO = v_strValue
                        Case "FORP"
                            v_strFORP = v_strValue
                        Case "AMTEXP"
                            v_strAMTEXP = v_strValue
                        Case "FEEAMT"
                            v_dblFLATAMT = v_strValue
                        Case "FEERATE"
                            v_dblFEERATE = v_strValue
                        Case "VATRATE"
                            v_dblVATRATE = v_strValue
                        Case "MINVAL"
                            v_dblMINVAL = v_strValue
                        Case "MAXVAL"
                            v_dblMAXVAL = v_strValue
                    End Select
                End With
            Next
            'Tính toán giá trị phí
            v_strVALEXP = BuildAMTEXP(v_strAMTEXP)
            v_dblTXAMT = v_objEval.Eval(v_strVALEXP)
            If v_strFORP = "F" Then
                'Phí cố định
                v_dblFEEAMT = v_dblFLATAMT
            Else
                'Phí theo tỷ lệ
                v_dblFEEAMT = v_dblFEERATE * v_dblTXAMT / 100
                If v_dblFEEAMT < v_dblMINVAL Then v_dblFEEAMT = v_dblMINVAL
                If v_dblFEEAMT > v_dblMAXVAL Then v_dblFEEAMT = v_dblMAXVAL
            End If
            v_dblVATAMT = v_dblFEEAMT * v_dblVATRATE / 100

            'Tạo các dòng thu phí
            v_entryNode = pv_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "entry", "")

            Dim v_attrFEECD As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("feecd")
            v_attrFEECD.Value = v_strFEECD
            v_entryNode.Attributes.Append(v_attrFEECD)

            Dim v_attrGLACCTNO As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("glacctno")
            v_attrGLACCTNO.Value = v_strGLACCTNO
            v_entryNode.Attributes.Append(v_attrGLACCTNO)

            Dim v_attrFEEAMT As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("feeamt")
            v_attrFEEAMT.Value = v_dblFEEAMT
            v_entryNode.Attributes.Append(v_attrFEEAMT)

            Dim v_attrVATAMT As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("vatamt")
            v_attrVATAMT.Value = v_dblVATAMT
            v_entryNode.Attributes.Append(v_attrVATAMT)

            Dim v_attrVATRATE As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("vatrate")
            v_attrVATRATE.Value = v_dblVATRATE
            v_entryNode.Attributes.Append(v_attrVATRATE)

            Dim v_attrTXAMT As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("txamt")
            v_attrTXAMT.Value = v_dblTXAMT
            v_entryNode.Attributes.Append(v_attrTXAMT)

            Dim v_attFEERATE As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("feerate")
            v_attFEERATE.Value = v_dblFEERATE
            v_entryNode.Attributes.Append(v_attFEERATE)

            v_entryNode.InnerText = v_dblFEEAMT
            v_feeElement.AppendChild(v_entryNode)

            v_dblTOTALFEEAMT = v_dblTOTALFEEAMT + v_dblFEEAMT
            v_dblTOTALVATAMT = v_dblTOTALVATAMT + v_dblVATAMT
        Next
        pv_xmlDocument.DocumentElement.AppendChild(v_feeElement)
        pv_xmlDocument.DocumentElement.Attributes(gc_AtributeFEEAMT).InnerXml = v_dblTOTALFEEAMT
        pv_xmlDocument.DocumentElement.Attributes(gc_AtributeVATAMT).InnerXml = v_dblTOTALVATAMT
    End Function

    Private Function BuildAMTEXP(ByVal strAMTEXP As String) As String
        Try
            Dim v_strEvaluator, v_strElemenent, v_strValue As String
            Dim v_lngIndex As Long, v_ctl As Control

            v_strEvaluator = vbNullString
            v_lngIndex = 1

            While v_lngIndex < Len(strAMTEXP)
                'Get 02 charatacters in AMTEXP
                v_strElemenent = Mid$(strAMTEXP, v_lngIndex, 2)
                Select Case v_strElemenent
                    Case "++", "--", "**", "//", "((", "))"
                        'Operand
                        v_strEvaluator = v_strEvaluator & Mid(v_strElemenent, 1, 1)
                    Case Else
                        ''Operator
                        'For Each v_ctl In Me.pnTransDetail.Controls
                        '    'If InStr(v_ctl.Name, PREFIXED_MSKDATA & v_strElemenent) > 0 And TypeOf (v_ctl) Is FlexMaskEditBox Then
                        '    If InStr(v_ctl.Name, PREFIXED_MSKDATA & v_strElemenent) > 0 Then
                        '        If TypeOf (v_ctl) Is ComboBoxEx Then
                        '            v_strValue = CType(v_ctl, ComboBoxEx).SelectedValue
                        '        Else
                        '            v_strValue = Replace(v_ctl.Text, ",", "")
                        '        End If
                        '        Exit For
                        '    End If
                        'Next
                        'v_strEvaluator = v_strEvaluator & v_strValue
                End Select
                v_lngIndex = v_lngIndex + 2
            End While

            Return v_strEvaluator
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            Throw ex
        End Try
    End Function
#End Region

#Region " Form events "
    'Private Sub chkDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkDetail.Click
    '    If chkDetail.Checked And AllowViewCF Then
    '        'Show chi tiết hợp đồng
    '        pnContractInfo.Visible = True
    '        pnContractInfo.Top = CONTROL_PNL_CONTRACT_TOP
    '        btnOK.Top = CONTROL_BUTTON_TOP
    '        btnCANCEL.Top = btnOK.Top
    '        lblOrderID.Top = btnOK.Top
    '        Me.Height = FRM_EXTEND_HEIGHT
    '    Else
    '        'Không Show chi tiết hợp đồng
    '        pnContractInfo.Visible = False
    '        pnContractInfo.Top = CONTROL_PNL_CONTRACT_TOP
    '        btnOK.Top = CONTROL_PNL_CONTRACT_TOP
    '        btnCANCEL.Top = btnOK.Top
    '        lblOrderID.Top = btnOK.Top
    '        Me.Height = FRM_DEFAULT_HEIGHT
    '    End If
    'End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        OnDelete(False)
    End Sub
    Private Sub btnAmendment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAmendment.Click
        If CheckCIAdjustBalance() Then
            OnDelete(True)
        Else
            Exit Sub
        End If
    End Sub
    Private Sub VScrollBarSign_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles VScrollBarSign.Scroll
        'If Not mv_arrSIGNATURE Is Nothing Then
        '    If mv_arrSIGNATURE.Length > 0 Then
        '        picSignature.Image = GetImageFromString(mv_arrSIGNATURE(Me.VScrollBarSign.Value))
        '    Else
        '        picSignature.Image = Nothing
        '        picSignature.Refresh()
        '    End If
        'End If
    End Sub


    Private Sub VScrollBarSign_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles VScrollBarSign.ValueChanged
        If Not mv_arrSIGNATURE Is Nothing Then
            If mv_arrSIGNATURE.Length > 0 Then
                picSignature.Image = GetImageFromString(mv_arrSIGNATURE(Me.VScrollBarSign.Value))
            Else
                picSignature.Image = Nothing
                picSignature.Refresh()
            End If
        End If
    End Sub

    Private Sub chkDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkDetail.Click
        If chkDetail.Checked And AllowViewCF Then
            'Show chi tiết hợp đồng
            pnBalance.Visible = True
            pnBalance.Top = CONTROL_PNL_BALANCE_TOP
            pnContractInfo.Top = CONTROL_PNL_CONTRACT_TOP
            btnOK.Top = CONTROL_BUTTON_TOP
            btnCANCEL.Top = btnOK.Top
            lblOrderID.Top = btnOK.Top
            Me.Height = FRM_EXTEND_HEIGHT
        Else
            'Không Show chi tiết hợp đồng
            pnBalance.Visible = False
            'pnBalance.Top = CONTROL_PNL_BALANCE_TOP
            pnContractInfo.Top = CONTROL_PNL_BALANCE_TOP
            btnOK.Top = CONTROL_BUTTON_TOP - pnBalance.Height - 10
            btnCANCEL.Top = btnOK.Top
            lblOrderID.Top = btnOK.Top
            Me.Height = FRM_EXTEND_HEIGHT - pnBalance.Height - 10
        End If
    End Sub
    Private Sub MemberGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles MemberGrid.DoubleClick
        Try
            Call ShowCF()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub MemberGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim i As Integer
        Dim v_xColumn As Xceed.Grid.Column
        'MemberGrid.BeginInit()

        If Not MemberGrid.CurrentColumn Is Nothing Then
            If MemberGrid.CurrentColumn.FieldName = "__TICK" Then
                If MemberGrid.CurrentCell.Value = "X" Then
                    MemberGrid.CurrentCell.Value = String.Empty
                Else
                    For i = 0 To MemberGrid.DataRows.Count - 1
                        MemberGrid.DataRows(i).Cells("__TICK").Value = String.Empty
                    Next
                    MemberGrid.CurrentCell.Value = "X"
                End If
            End If
        End If

        'MemberGrid.EndInit()
    End Sub

    Private Sub MemberGrid_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MemberGrid.KeyUp
        Try
            Select Case e.KeyCode
                Case Keys.Alt.V
                    Call ShowCF()
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ShowCF()
        'Hiển thị thông tin ngưoi được uỷ quyen
        Dim v_strTYP, v_strCUSTID, v_strAUTOID As String
        If Not (MemberGrid.CurrentRow Is Nothing) Then
            v_strTYP = Trim(CType(MemberGrid.CurrentRow, Xceed.Grid.DataRow).Cells("TYP").Value)
            If v_strTYP = "M" Then 'Hiển thị thông tin trong CFMAST
                v_strCUSTID = Trim(CType(MemberGrid.CurrentRow, Xceed.Grid.DataRow).Cells("CUSTID").Value)
                'Dim v_frm As New frmCFMAST
                'v_frm.ExeFlag = ExecuteFlag.View
                'v_frm.UserLanguage = UserLanguage
                'v_frm.ModuleCode = "CF"
                'v_frm.ObjectName = "CF.CFMAST"
                'v_frm.TableName = "CFMAST"
                'v_frm.LocalObject = "N"
                'v_frm.Text = mv_ResourceManager.GetString("frm_CFMAST")
                'v_frm.KeyFieldName = "CUSTID"
                'v_frm.KeyFieldType = "C"
                'v_frm.KeyFieldValue = Trim(CType(MemberGrid.CurrentRow, Xceed.Grid.DataRow).Cells("CUSTID").Value)
                'Dim frmResult As DialogResult = v_frm.ShowDialog()
                Dim v_frm As New frmCFLINK
                v_frm.ExeFlag = ExecuteFlag.View
                v_frm.UserLanguage = UserLanguage
                v_frm.ModuleCode = "CF"
                v_frm.ObjectName = "CF.CFLINK"
                v_frm.TableName = "CFLINK"
                v_frm.BranchId = Me.BranchId
                v_frm.LocalObject = "N"
                v_frm.Text = "" 'Lay tu resource
                v_frm.KeyFieldName = "AUTOID"
                v_frm.KeyFieldType = "C"
                v_frm.KeyFieldValue = Trim(CType(MemberGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value)
                Dim frmResult As DialogResult = v_frm.ShowDialog()
            Else
                If v_strTYP = "A" Then 'Hiển thị thông tin trong CFAUTH 
                    v_strAUTOID = Trim(CType(MemberGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value)
                    Dim v_frm As New frmCFAUTH
                    v_frm.ExeFlag = ExecuteFlag.View
                    v_frm.UserLanguage = UserLanguage
                    v_frm.ModuleCode = "CF"
                    v_frm.ObjectName = "CF.CFAUTH"
                    v_frm.TableName = "CFAUTH"
                    v_frm.LocalObject = "N"
                    v_frm.Text = mv_ResourceManager.GetString("frm_CFAUTH") 'Lay tu resource
                    v_frm.KeyFieldName = "AUTOID"
                    v_frm.KeyFieldType = "C"
                    v_frm.KeyFieldValue = Trim(CType(MemberGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value)
                    Dim frmResult As DialogResult = v_frm.ShowDialog()
                End If
            End If
        End If
    End Sub


    Private Sub CreateDefaultCondition(ByVal pv_strDisplay As String, ByVal pv_strValue As String, Optional ByVal pv_strObjName As String = "")
        Try
            Dim v_strObjMsg As String, v_strDefVal As String = String.Empty
            Dim v_strUserProfiles As String = Application.LocalUserAppDataPath & "\" & Me.BranchId & Me.TellerId & ".xml"
            Dim v_strSection As String ''= Me.ModuleCode & "." & "ODMAST" 'Me.ObjectName
            If pv_strObjName.Length > 0 Then

                v_strSection = "OD." & pv_strObjName
            Else
                v_strSection = "OD." & "ODMAST" 'Me.ObjectName
            End If
            Dim v_xmlDocument As New Xml.XmlDocument, v_nodetxData As Xml.XmlNode
            Dim v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode, v_entryNodeTmp As Xml.XmlNode
            Dim v_attrObjName, v_attrChecked, v_attrValue, v_attrDisplay As Xml.XmlAttribute

            If Len(Dir(v_strUserProfiles)) = 0 Then
                'Tạo tệp tin UserProfiles
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, "USER_PROFILES:=" & Me.BranchId & "." & Me.TellerId, , , , )
                v_xmlDocument.LoadXml(v_strObjMsg)
            Else
                v_xmlDocument.Load(v_strUserProfiles)
            End If

            v_strObjMsg = v_xmlDocument.InnerXml
            'Nạp tệp tin UserProfiles
            v_nodetxData = v_xmlDocument.SelectSingleNode("ObjectMessage/ObjData[@OBJNAME='" & v_strSection & "']")
            If Not v_nodetxData Is Nothing Then
                v_xmlDocument.DocumentElement.RemoveChild(v_nodetxData)
            End If
            v_dataElement = v_xmlDocument.DocumentElement

            'Tạo node dữ liệu
            v_entryNode = v_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "ObjData", "")

            'Add object name
            v_attrObjName = v_xmlDocument.CreateAttribute("OBJNAME")
            v_attrObjName.Value = v_strSection
            v_entryNode.Attributes.Append(v_attrObjName)

            'Contract no.
            '-----------------------------------
            v_entryNodeTmp = v_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "DataElement", "")

            'Add checked attribute
            v_attrChecked = v_xmlDocument.CreateAttribute("CHECKED")
            v_attrChecked.Value = "Y"
            v_entryNodeTmp.Attributes.Append(v_attrChecked)

            'Add value attribute
            v_attrValue = v_xmlDocument.CreateAttribute("VALUE")
            v_attrValue.Value = pv_strValue
            v_entryNodeTmp.Attributes.Append(v_attrValue)

            'Add display attribute
            v_attrDisplay = v_xmlDocument.CreateAttribute("DISPLAY")
            v_attrDisplay.Value = pv_strDisplay
            v_entryNodeTmp.Attributes.Append(v_attrDisplay)

            v_entryNode.AppendChild(v_entryNodeTmp)

            ''Order status.
            ''------------------------------------



            v_dataElement.AppendChild(v_entryNode)
            v_xmlDocument.AppendChild(v_dataElement)

            v_xmlDocument.Save(v_strUserProfiles)
        Catch ex As Exception
            LogError.Write("Error source: AppCore.frmSearch.SaveLastSearch" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub


    Private Sub frmODTransact_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitDialog()
    End Sub

    Private Function VerifyCaredBy(ByVal pv_strCheck As String, ByVal pv_strTable As String) As Boolean
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strFLDNAME, v_strVALUE As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_blRet As Boolean = False
        Dim v_strSQL As String = ""
        Dim v_strObjMsg As String = ""
        Dim i, j As Integer
        Dim v_strCareBy As String

        Select Case pv_strTable.ToUpper()

            Case "AFMAST"
                'Dien comment 4-10-2010
                'v_strSQL = "SELECT CF.CAREBY FROM CFMAST CF, AFMAST AF WHERE AF.CUSTID=CF.CUSTID AND AF.ACCTNO='" & pv_strCheck & "'"
                v_strSQL = "SELECT AF.CAREBY FROM AFMAST AF, TLGRPUSERS TL WHERE AF.CAREBY=TL.GRPID AND TL.TLID='" & Me.TellerId & "' AND AF.ACCTNO='" & pv_strCheck & "'"
                'End Comment Dien
            Case "ODCANCEL"
                'Dien Comment4-10-2010
                'v_strSQL = "SELECT CAREBY FROM CFMAST WHERE CUSTODYCD IN (SELECT CUSTODYCD FROM ODCANCEL WHERE ORGORDERID = '" & pv_strCheck & "')"
                v_strSQL = "SELECT AF.CAREBY FROM AFMAST AF, CFMAST CF, TLGRPUSERS TL WHERE AF.CAREBY=TL.GRPID AND TL.TLID ='" & Me.TellerId & "' AND AF.CUSTID=CF.CUSTID and EXISTS (SELECT CUSTODYCD FROM ODCANCEL WHERE CF.CUSTODYCD= ODCANCEL.CUSTODYCD and ORGORDERID = '" & pv_strCheck & "')"
                'End comment DIen

            Case "ODMAST"
                'Dien Comment 4-10-2010
                'v_strSQL = "SELECT CF.careby FROM CFMAST CF,ODMAST OD,AFMAST AF WHERE CF.custid = AF.custid AND AF.acctno = OD.afacctno AND OD.orderid ='" & pv_strCheck & "'" & _
                '           "UNION ALL SELECT CF.careby FROM CFMAST CF,FOMAST FO,AFMAST AF WHERE CF.custid = AF.custid AND AF.acctno = FO.afacctno AND FO.acctno='" & pv_strCheck & "'"
                v_strSQL = "SELECT AF.CAREBY FROM ODMAST OD, AFMAST AF, TLGRPUSERS TL WHERE AF.CAREBY=TL.GRPID AND TL.TLID='" & Me.TellerId & "' AND AF.acctno = OD.afacctno AND OD.orderid ='" & pv_strCheck & "'" & _
                           "UNION ALL SELECT AF.careby FROM FOMAST FO, AFMAST AF, TLGRPUSERS TL WHERE AF.CAREBY=TL.GRPID AND TL.TLID='" & Me.TellerId & "' AND AF.acctno = FO.afacctno AND FO.acctno='" & pv_strCheck & "'"
                'End comment Dien
        End Select

        If v_strSQL.Length > 0 Then
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)

            If v_strObjMsg.Length > 0 Then
                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                For i = 0 To v_nodeList.Count - 1
                    For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            v_strVALUE = .InnerText.ToString
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME)
                                Case "CAREBY"
                                    v_strCareBy = v_strVALUE
                            End Select
                        End With
                    Next
                Next

                If Not v_strCareBy Is Nothing Then
                    mv_AFCarebyGrp = v_strCareBy
                Else
                    MsgBox(mv_ResourceManager.GetString("ERR_CF_CONTRACT_NOT_FOUND"), MsgBoxStyle.Information, Me.Text)
                End If
            End If
        End If

        If AuthCustomer <> String.Empty Then
            'Neu la uy quyen (dat lenh qua kenh tele) thi khong check careby
            v_blRet = True
        Else

            If mv_AFCarebyGrp <> "" Then
                If mv_GroupCareBy.IndexOf(mv_AFCarebyGrp) > -1 Then
                    v_blRet = True
                Else
                    MsgBox(mv_ResourceManager.GetString("ERR_CF_NOT_CAREBY"), MsgBoxStyle.Information, Me.Text)
                End If
            End If
        End If
        Return v_blRet
    End Function

    Private Sub frmODTransact_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Dim v_intPos As Int16, ctl As Control, strFLDNAME, v_strCmdSQL, v_strObjMsg As String, v_intIndex As Integer
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Select Case e.KeyCode
            Case Keys.Escape
                If mskAFACCTNO.Enabled = False And Not mv_blnShowOfficerFunction And Not Me.mv_blnIsDelete Then
                    OnAdjust()
                ElseIf Me.mv_blnIsDelete And txtOrStatus.Text = "Pending to Send" Then
                    'Nếu là lệnh huỷ sửa khi cancel thì giải toả trạng thái để cho phép Send
                    OnCancelCorection()
                    OnClose()
                Else
                    OnClose()
                End If
            Case Keys.F5
                If Me.ActiveControl.Name = "mskAFACCTNO" And Me.mskAFACCTNO.ReadOnly = False Then
                    Dim frm As New frmSearch(Me.UserLanguage)
                    frm.TableName = "AFMAST"
                    frm.ModuleCode = "CF"
                    frm.AuthCode = "NNNNYYNNNN" 'Không cho phép thực hiện chức năng nào 
                    frm.IsLocalSearch = gc_IsNotLocalMsg
                    frm.IsLookup = "Y"
                    frm.SearchOnInit = False
                    frm.BranchId = Me.BranchId
                    frm.TellerId = Me.TellerId
                    If AuthCustomer = String.Empty Then
                        'TungNT added
                        frm.GroupCareBy = mv_GroupCareBy
                        frm.CareByFilter = True
                        'End
                    End If

                    frm.ShowDialog()
                    If Not frm.ReturnValue Is Nothing AndAlso frm.ReturnValue.Length > 0 Then
                        'Check if contract no is caredby by user or not - TungNT added
                        'If VerifyCaredBy(frm.ReturnValue.Replace(".", ""), "AFMAST") = True Then
                        Me.ActiveControl.Text = Trim(frm.ReturnValue)

                        If Len(frm.RefValue) > 0 Then
                            lblAFNAME.Text = Trim(frm.RefValue)
                        End If

                        'Nạp thông tin tài khoản mới
                        GetAFContractInfo(ActiveControl.Text)
                        'Else
                        '    Exit Sub
                        'End If
                    End If
                    frm.Dispose()
                    'End
				ElseIf Me.ActiveControl.Name = "mskCustodycd" Then
                    Dim frm As New frmSearch(Me.UserLanguage)
                    frm.TableName = "CFMAST_EX"
                    frm.ModuleCode = "CF"
                    frm.AuthCode = "NNNNYYNNNN" 'Không cho phép thực hiện chức năng nào 
                    frm.IsLocalSearch = gc_IsNotLocalMsg
                    frm.IsLookup = "Y"
                    frm.SearchOnInit = False
                    frm.BranchId = Me.BranchId
                    frm.TellerId = Me.TellerId
                    frm.ShowDialog()
                    Me.ActiveControl.Text = Trim(frm.ReturnValue)
                    v_strCmdSQL = "SELECT VALUE, DISPLAY, EN_DISPLAY EN_DISPLAY FROM VW_CUSTODYCD_SUBACCOUNT WHERE FILTERCD = '" & Me.ActiveControl.Text & "'"
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_AFMAST, gc_ActionInquiry, v_strCmdSQL)
                    v_ws.Message(v_strObjMsg)
                    FillComboEx(v_strObjMsg, fcbAfacctno, "", Me.UserLanguage)
                ElseIf Me.ActiveControl.Name = "txtContraCus" Then
                    Dim frm As New frmSearch(Me.UserLanguage)
                    frm.TableName = "ODPUTHOUGHT"
                    frm.ModuleCode = "OD"
                    frm.AuthCode = "NNNNYYNNNN" 'Không cho phép thực hiện chức năng nào 
                    frm.IsLocalSearch = gc_IsNotLocalMsg
                    frm.IsLookup = "Y"
                    frm.SearchOnInit = False
                    frm.BranchId = Me.BranchId
                    frm.TellerId = Me.TellerId
                    frm.ShowDialog()
                    Me.ActiveControl.Text = Trim(frm.ReturnValue)
                    If Len(frm.RefValue) > 0 Then
                        lblAFNAME.Text = Trim(frm.RefValue)
                    End If
                    frm.Dispose()
                ElseIf Me.ActiveControl.Name = "mskREFORDERID" Then
                    ''Lay so hieu lenh thoa thuan repo lan 1
                    Dim frm As New frmSearch(Me.UserLanguage)
                    Dim strValue, strDisplay As String
                    frm.TableName = "ODPTREPO"
                    frm.ModuleCode = "OD"
                    'frm.ObjectName = "ODPTREPO"
                    frm.SearchOnInit = True
                    frm.LoadLastFilter = True
                    frm.AuthCode = "NNNNYYNNNN" 'Không cho phép thực hiện chức năng nào 
                    frm.IsLocalSearch = gc_IsNotLocalMsg
                    frm.IsLookup = "Y"
                    frm.BranchId = Me.BranchId
                    frm.TellerId = Me.TellerId
                    frm.LinkValue = IIf(Me.UpcomOrder, "='UPCOM'", "<>'UPCOM'")
                    'Hien thi tieu chi tim kiem khi khoi tao
                    If Len(Me.mskAFACCTNO.Text) > 0 Then
                        Dim v_strEXECTYPE As String = String.Empty
                        If Me.cboExecType.SelectedValue = "NB" Then
                            v_strEXECTYPE = "NS"
                        Else
                            v_strEXECTYPE = "NB"
                        End If

                        strDisplay = "Loai lenh = '" & v_strEXECTYPE & "'"
                        strValue = " T.EXECTYPE = '" & v_strEXECTYPE & "'"
                        CreateDefaultCondition(strDisplay, strValue, "ODPTREPO")
                    End If
                    frm.ShowDialog()

                    If frm.ReturnValue Is Nothing Then
                        frm.Dispose()
                        Exit Sub
                    End If

                    'Check if contract no is caredby by user or not - TungNT added
                    'If VerifyCaredBy(frm.ReturnValue.Replace(".", ""), "ODMAST") = True Then
                    Me.ActiveControl.Text = Trim(frm.ReturnValue)
                    mv_strOldRefOrderID = Trim(frm.ReturnValue)
                    'Me.lblOrderID.Text = Trim(frm.ReturnValue)
                    'If Len(frm.RefValue) > 0 Then
                    '    lblAFNAME.Text = Trim(frm.RefValue)
                    'End If
                    ''LoadODPTInfo(frm.FULLDATA)

                ElseIf Me.ActiveControl.Name = "mskOrderID" Then
                    'Dim frm As New frmSearch(Me.UserLanguage)
                    'Dim strValue, strDisplay As String
                    'frm.TableName = "ODCANCEL"
                    'frm.ModuleCode = "OD"
                    'frm.AuthCode = "NNNNYYNNNN" 'Không cho phép thực hiện chức năng nào 
                    'frm.IsLocalSearch = gc_IsNotLocalMsg
                    'frm.IsLookup = "Y"
                    'frm.SearchOnInit = False
                    'frm.BranchId = Me.BranchId
                    'frm.TellerId = Me.TellerId
                    'If AuthCustomer = String.Empty Then
                    '    'TungNT added
                    '    frm.GroupCareBy = mv_GroupCareBy
                    '    frm.CareByFilter = True
                    '    'End
                    'End If
                    'frm.LinkValue = IIf(Me.UpcomOrder, "='UPCOM'", "<>'UPCOM'")
                    'strDisplay = "Contract no = '" & Strings.Left(mskAFACCTNO.Text, 4) & "." & Strings.Right(mskAFACCTNO.Text, 6) & "'"
                    'strValue = "REPLACE (UPPER( Trim (T." & lblAFACCTNO.Tag & ")),'.','') = UPPER ('" & mskAFACCTNO.Text & "')"

                    'CreateDefaultCondition(strDisplay, strValue)
                    'frm.ShowDialog()

                    ''Check if contract no is caredby by user or not - TungNT added
                    'If VerifyCaredBy(frm.ReturnValue.Replace(".", ""), "ODMAST") = True Then
                    '    Me.ActiveControl.Text = Trim(frm.ReturnValue)
                    '    'Me.lblOrderID.Text = Trim(frm.ReturnValue)
                    '    If Len(frm.RefValue) > 0 Then
                    '        lblAFNAME.Text = Trim(frm.RefValue)
                    '    End If
                    '    LoadOrderInfo(frm.FULLDATA)

                    '    'Kiểm tra nếu trạng thái đang là Sending thì log lại và không cho phép đ?c n�ữa.
                    '    'Nếu trạng thái đã đổi từ Sending thành Send rồi thì báo lỗi lệnh đã Send 
                    '    'và yêu cầu huỷ, sửa lại theo chế độ Send
                    '    Me.cboTimeType.Enabled = False
                    '    Me.dtpEffectiveDate.Enabled = False
                    '    Me.dtpExpiredDate.Enabled = False
                    '    Me.cboPriceType.Enabled = False
                    '    If txtOrStatus.Text = "Pending to Send" Then
                    '        CheckCorrectionOrderStatus()
                    '        'Else
                    '        '    Me.cboPriceType.Enabled = False
                    '    ElseIf mv_strODStatus.Trim = "Rejected" Or mv_strODStatus.Trim = "Pending" Then
                    '        Me.txtQuantity.Enabled = True
                    '        Me.dtpEffectiveDate.Enabled = True
                    '        Me.dtpExpiredDate.Enabled = True
                    '    End If


                    '    Me.ActiveControl = txtQuantity
                    'Else
                    '    Exit Sub
                    'End If
                    'frm.Dispose()
                    ''End
                    Dim frm As New frmSearch(Me.UserLanguage)
                    Dim strValue, strDisplay As String
                    frm.TableName = "ODCANCEL"
                    frm.ModuleCode = "OD"
                    frm.CommandType = gc_CommandProcedure
                    frm.StoreName = "GetCancelOrder"
                    frm.StoreParam = "AFACCTNO!" & UCase(Me.mskAFACCTNO.Text) & "!varchar2!20"
                    frm.SearchOnInit = True
                    frm.LoadLastFilter = True
                    frm.AuthCode = "NNNNYYNNNN" 'Không cho phép thực hiện chức năng nào 
                    frm.IsLocalSearch = gc_IsNotLocalMsg
                    frm.IsLookup = "Y"
                    frm.BranchId = Me.BranchId
                    frm.TellerId = Me.TellerId
                    If AuthCustomer = String.Empty Then
                        'TungNT added
                        frm.GroupCareBy = mv_GroupCareBy
                        frm.CareByFilter = True
                        'End
                    End If
                    frm.LinkValue = IIf(Me.UpcomOrder, "='UPCOM'", "<>'UPCOM'")
                    'Hien thi tieu chi tim kiem khi khoi tao
                    If Len(Me.mskAFACCTNO.Text) > 0 Then

                        strDisplay = "Contract no = '" & Strings.Left(mskAFACCTNO.Text, 4) & "." & Strings.Right(mskAFACCTNO.Text, 6) & "'"
                        strValue = "REPLACE (UPPER( Trim (T." & lblAFACCTNO.Tag & ")),'.','') = UPPER ('" & mskAFACCTNO.Text & "')"

                        CreateDefaultCondition(strDisplay, strValue)
                    End If

                    frm.ShowDialog()
                    If frm.ReturnValue Is Nothing Then
                        frm.Dispose()
                        Exit Sub
                    End If
                    'Check if contract no is caredby by user or not - TungNT added
                    'If VerifyCaredBy(frm.ReturnValue.Replace(".", ""), "ODMAST") = True Then
                    Me.ActiveControl.Text = Trim(frm.ReturnValue)
                    'Me.lblOrderID.Text = Trim(frm.ReturnValue)
                    If Len(frm.RefValue) > 0 Then
                        lblAFNAME.Text = Trim(frm.RefValue)
                    End If
                    LoadOrderInfo(frm.FULLDATA)

                    'Kiểm tra nếu trạng thái đang là Sending thì log lại và không cho phép đ?c n�ữa.
                    'Nếu trạng thái đã đổi từ Sending thành Send rồi thì báo lỗi lệnh đã Send 
                    'và yêu cầu huỷ, sửa lại theo chế độ Send
                    Me.cboTimeType.Enabled = False
                    Me.dtpEffectiveDate.Enabled = False
                    Me.dtpExpiredDate.Enabled = False
                    Me.cboPriceType.Enabled = False
                    If txtOrStatus.Text = "Pending to Send" Then
                        CheckCorrectionOrderStatus()
                        'Else
                        '    Me.cboPriceType.Enabled = False
                    ElseIf mv_strODStatus.Trim = "Rejected" Or mv_strODStatus.Trim = "Pending" Then
                        Me.txtQuantity.Enabled = True
                        Me.dtpEffectiveDate.Enabled = True
                        Me.dtpExpiredDate.Enabled = True
                    End If


                    Me.ActiveControl = txtQuantity
                    'Else
                    '    Exit Sub
                    'End If
                    frm.Dispose()
                    'End
                End If
            Case Keys.F9
                If Me.ActiveControl.Name = "mskAFACCTNO" And mskAFACCTNO.Text.Replace(".", "").Trim.Length = 10 Then
                    Dim frm As New frmSearch(Me.UserLanguage)
                    frm.TableName = "ODMASTVIEW"
                    frm.ModuleCode = "OD"
                    frm.AuthCode = "NNNNYYNNNN" 'Không cho phép thực hiện chức năng nào 
                    frm.IsLocalSearch = gc_IsNotLocalMsg
                    frm.IsLookup = "Y"
                    frm.LoadLastFilter = False
                    frm.SearchOnInit = True
                    frm.BranchId = Me.BranchId
                    frm.TellerId = Me.TellerId
                    frm.AFACCTNO = mskAFACCTNO.Text.Replace(".", "").Trim
                    frm.CUSTID = Me.AuthCustomer

                    If Me.AuthCustomer = String.Empty Then
                        'TungNT added
                        frm.GroupCareBy = mv_GroupCareBy
                        frm.CareByFilter = True
                        'End
                    End If

                    frm.ShowDialog()
                    frm.Dispose()
                End If

            Case Keys.F10
                If Me.ActiveControl.Name = "mskAFACCTNO" And mskAFACCTNO.Text.Replace(".", "").Trim.Length = 10 Then
                    Dim frm As New frmSearch(Me.UserLanguage)
                    frm.TableName = "ODCTCIVIEW"
                    frm.ModuleCode = "OD"
                    frm.AuthCode = "NNNNYYNNNN" 'Không cho phép thực hiện chức năng nào 
                    frm.IsLocalSearch = gc_IsNotLocalMsg
                    frm.IsLookup = "Y"
                    frm.LoadLastFilter = False
                    frm.SearchOnInit = True
                    frm.BranchId = Me.BranchId
                    frm.TellerId = Me.TellerId
                    frm.AFACCTNO = mskAFACCTNO.Text.Replace(".", "").Trim
                    frm.CUSTID = Me.AuthCustomer
                    If Me.AuthCustomer = String.Empty Then
                        'TungNT added
                        frm.GroupCareBy = mv_GroupCareBy
                        frm.CareByFilter = True
                        'End
                    End If

                    frm.ShowDialog()
                    frm.Dispose()
                End If
            Case Keys.Enter
                If Me.ActiveControl.Name = "mskAFACCTNO" Then
                    'Nạp thông tin tài khoản mới
                    If Len(Trim(ActiveControl.Text)) = 10 Then
                        'Check if contract no is caredby by user or not - TungNT added
                        'If VerifyCaredBy(ActiveControl.Text.Replace(".", ""), "AFMAST") = True Then
                        GetAFContractInfo(ActiveControl.Text)
                        SendKeys.Send("{Tab}")
                        e.Handled = True
                        'Else
                        '    Exit Sub
                        'End If
                    End If
                ElseIf Not TypeOf (Me.ActiveControl) Is Button Then
                    SendKeys.Send("{Tab}")
                    e.Handled = True
                Else
                End If
            Case Keys.PageUp
                If Not mv_blnIsDelete Then
                    Me.cboExecType.SelectedValue = "NB"
                    Call QuickOrder(True)
                End If
            Case Keys.PageDown
                If Not mv_blnIsDelete Then
                    Me.cboExecType.SelectedValue = "NS"
                    Call QuickOrder(True)
                End If
            Case Keys.End
                If Not mv_blnIsDelete Then
                    Call QuickOrder(False)
                    mskAFACCTNO.Focus()
                    mskAFACCTNO.SelectAll()
                End If

        End Select
    End Sub
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        OnSubmit()
    End Sub

    Private Sub btnCANCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCANCEL.Click
        If Me.mskAFACCTNO.Enabled Then
            If Me.mv_blnIsDelete And txtOrStatus.Text = "Pending to Send" Then
                'Nếu là lệnh huỷ sửa khi cancel thì giải toả trạng thái để cho phép Send
                OnCancelCorection()
            End If
            OnClose()
        Else
            If mv_blnViewMode = True Then
                OnClose()
            Else
                If Me.mv_blnIsDelete And txtOrStatus.Text = "Pending to Send" Then
                    'Nếu là lệnh huỷ sửa khi cancel thì giải toả trạng thái để cho phép Send
                    OnCancelCorection()
                End If
                ResetScreen(Me)
                ShowAdjustButton(False)
                ResetDeleteButton()
            End If
        End If
    End Sub

    Private Sub cboCODEID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCODEID.SelectedIndexChanged
        Dim v_strCodeID As String
        v_strCodeID = Convert.ToString(Me.cboCODEID.SelectedValue)
        GetSecuritiesInfo(v_strCodeID)
        If (Not mv_blnAdvanceOrder) And (Convert.ToString(cboExecType.SelectedValue) = "NS" Or Convert.ToString(cboExecType.SelectedValue) = "MS") Then
            ShowSENormalMode(v_strCodeID)
        ElseIf Not mv_blnAdvanceOrder Then
            SEMemberGrid.DataRows.Clear()
        End If
        CheckIssuer(v_strCodeID)
        ''Check cho lenh thoa thuan trai phieu repo
        If cboMatchType.SelectedValue = "P" And (Me.txtSecType.Text = "006" Or Me.txtSecType.Text = "003") Then
            Me.chkPTRepo.Visible = True
            If Me.chkPTRepo.Checked Then
                SetPTScreen(True)
            Else
                SetPTScreen(False)
            End If
        Else
            Me.chkPTRepo.Visible = False
            SetPTScreen(False)
        End If
    End Sub

    Private Sub cboExecType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboExecType.SelectedIndexChanged
        Dim v_strCodeID As String
        v_strCodeID = Convert.ToString(cboCODEID.SelectedValue)
        Try
            If cboExecType.SelectedIndex <> -1 Then
                Me.pnOrder.BackColor = getTransBGColor(Convert.ToString(cboExecType.SelectedValue))
                'Me.pnExtentInfo.BackColor = getTransBGColor(cboExecType.SelectedIndex + 3)
                'Me.pnUpcomInfo.BackColor = getTransBGColor(cboExecType.SelectedIndex + 3)
                If (Not mv_blnAdvanceOrder) And (Convert.ToString(cboExecType.SelectedValue) = "NS" Or Convert.ToString(cboExecType.SelectedValue) = "MS") Then
                    ShowSENormalMode(v_strCodeID)
                    'TungNT added
                    GetSETrade(Convert.ToString(cboCODEID.SelectedValue).Trim())
                    'End
                ElseIf Not mv_blnAdvanceOrder Then
                    SEMemberGrid.DataRows.Clear()
                End If
            End If
            If Len(mskAFACCTNO.Text) > 0 And mskAFACCTNO.ReadOnly = False Then
                GetAFLinkAuth(mskAFACCTNO.Text)
            End If
            If Convert.ToString(cboExecType.SelectedValue) = "MS" Then
                Me.lblDealNo.Visible = True
                Me.txtDealNO.Visible = True
                Me.btnGetDeal.Visible = True
                Me.cboCODEID.Enabled = False
            Else
                Me.lblDealNo.Visible = False
                Me.txtDealNO.Visible = False
                Me.btnGetDeal.Visible = False
                Me.cboCODEID.Enabled = True
            End If

            'CheckTradeBuySell()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub SetPTScreen(ByVal pv_bln As Boolean)
        If pv_bln Then
            Me.mskREFORDERID.Visible = True
            Me.lblREFORDERID.Visible = True
            Me.lblEXPTPRICE.Visible = True
            Me.lblEXPTDATE.Visible = True
            Me.txtEXPTPRICE.Visible = True
            Me.dtpEXPTDATE.Visible = True
        Else
            Me.mskREFORDERID.Visible = False
            Me.lblREFORDERID.Visible = False
            Me.lblEXPTPRICE.Visible = False
            Me.lblEXPTDATE.Visible = False
            Me.txtEXPTPRICE.Visible = False
            Me.dtpEXPTDATE.Visible = False
        End If
    End Sub

    Private Sub mskAFACCTNO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mskAFACCTNO.Validating
        Try
            If Len(mskAFACCTNO.Text) = 10 Then
                'If mv_strPreviousAcc.Length > 0 Then
                'If mv_strPreviousAcc = mskAFACCTNO.Text Then
                'Exit Sub
                'Else
                'mv_strPreviousAcc = mskAFACCTNO.Text
                'Lấy thông tin ve hợp đồng
                'GetAFContractInfo(mskAFACCTNO.Text)
                'CheckIssuer(Me, e, Me.cboCODEID.SelectedValue)
                'End If
                'Else
                'mv_strPreviousAcc = mskAFACCTNO.Text
                'Lấy thông tin ve hợp đồng
                'If VerifyCaredBy(mskAFACCTNO.Text.Replace(".", ""), "AFMAST") Then
                GetAFContractInfo(mskAFACCTNO.Text)
                If mv_blnIsDelete Then
                    Me.ActiveControl = mskOrderID
                End If
                'Else
                '    mskAFACCTNO.Text = ""
                '    Exit Sub
                'End If
                'End If
            Else
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtQuantity_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQuantity.Leave
        If mv_blnIsDelete = True Then

            If CDbl(txtQuantity.Text) = CDbl(Me.txtExecQtty.Text) And CDbl(Me.txtExecQtty.Text) > 0 Then
                Me.txtQuotePrice.Enabled = False
            Else
                Me.txtQuotePrice.Enabled = True
            End If
        End If
        'Kiểm tra chứng khoán khi bán, số dư CI khi mua
        If txtQuantity.Text.Trim.Length > 0 Then
            If IsNumeric(txtQuantity.Text) Then
                If txtSecType.Text = "003" Or txtSecType.Text = "006" Or txtSecType.Text = "222" Then
                    txtClearingDay.Text = "1"
                    'Else
                    '    txtClearingDay.Text = "3"
                End If

                If Not CheckSEBalance() Then
                    Exit Sub
                End If
            End If


        End If

    End Sub

    Private Sub txtQuantity_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtQuantity.Validating
        Dim v_dblTempTraLot As Double
        v_dblTempTraLot = mv_dblTradeLot

        If txtQuantity.Text.Trim.Length > 0 Then
            If cboMatchType.SelectedValue = "P" And InStr(mv_strSETYPE, txtSecType.Text) > 0 Then
                mv_dblTradeLot = 1
            End If
            If mv_dblTradeLot <= 0 Then
                MsgBox(mv_ResourceManager.GetString("ERR_SEC_INFO"), MsgBoxStyle.Information, Me.Text)
                e.Cancel = True
                Return
            End If

            If Not IsNumeric(txtQuantity.Text) Then
                MsgBox(mv_ResourceManager.GetString("QTTYISNOTNUMBER"), MsgBoxStyle.Information, Me.Text)
                e.Cancel = True
                Return
            ElseIf CDbl(txtQuantity.Text) <= 0 Then
                MsgBox(mv_ResourceManager.GetString("QTTYISNOTNUMBER"), MsgBoxStyle.Information, Me.Text)
                e.Cancel = True
                Return
            Else
                If mv_dblTradeLot > 0 And Me.cboMatchType.SelectedValue <> "P" Then
                    ' PhuongHT edit
                    ' cho phep dat lenh lo le voi san HNX; lenh LO, <1 lo
                    If CDbl(txtQuantity.Text) Mod mv_dblTradeLot > 0 Then
                        If (txtTradePalce.Text <> c_HA_TRADEPLACE And txtTradePalce.Text <> c_UPCOM_TRADEPLACE) Then ' khong pai san HNX va UPCOM
                            MsgBox(mv_ResourceManager.GetString("TRADELOTINVALID"), MsgBoxStyle.Information, Me.Text)
                            e.Cancel = True
                            Return
                        ElseIf (CDbl(txtQuantity.Text) > mv_dblTradeLot) Or (Me.cboPriceType.SelectedValue <> "LO") Then
                            'la san HNX,UPCOM nhung khong pai lenh LO hoac le > 1 lo
                            MsgBox(mv_ResourceManager.GetString("TRADELOTINVALID"), MsgBoxStyle.Information, Me.Text)
                            e.Cancel = True
                            Return
                        End If

                    End If

                End If
            End If
        End If

        'If mv_blnIsDelete Then
        '    If Me.txtQuantity.Text.Trim = String.Empty OrElse Not IsNumeric(Me.txtQuantity.Text) OrElse CDbl(Convert.ToString(Me.txtQuantity.Text)) > mv_dblQtty Then
        '        MsgBox(mv_ResourceManager.GetString("QTTYISNOTNUMBER"), MsgBoxStyle.Information, Me.Text)
        '        If Me.txtQuantity.Enabled = True Then
        '            e.Cancel = True
        '            Return
        '        End If
        '    End If
        'End If
        If Trim(cboPriceType.SelectedValue) = "LO" Then
            If Me.txtQuantity.Text.Trim = String.Empty OrElse Not IsNumeric(Me.txtQuantity.Text) Then
                MsgBox(mv_ResourceManager.GetString("QTTYISNOTNUMBER"), MsgBoxStyle.Information, Me.Text)
                If Me.txtQuantity.Enabled = True Then
                    e.Cancel = True
                    Return
                End If
            End If
        Else
            If Me.txtQuantity.Text.Trim = String.Empty OrElse Not IsNumeric(Me.txtQuantity.Text) Then ' OrElse CDbl(Convert.ToString(Me.txtQuantity.Text)) > mv_dblQtty Then
                MsgBox(mv_ResourceManager.GetString("QTTYISNOTNUMBER"), MsgBoxStyle.Information, Me.Text)
                If Me.txtQuantity.Enabled = True Then
                    e.Cancel = True
                    Return
                End If
            End If
        End If

        If Me.mskAFACCTNO.Text.Length <> 10 Then
            MsgBox(mv_ResourceManager.GetString("ERR_CF_CONTRACT_NOT_FOUND"), MsgBoxStyle.Information, Me.Text)
            Me.ActiveControl = Me.mskAFACCTNO
            Exit Sub
        End If

        e.Cancel = Not CheckPutthought()
        mv_dblTradeLot = v_dblTempTraLot
    End Sub

    Private Sub txtQuotePrice_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtQuotePrice.Validating
        If Me.mskAFACCTNO.Text.Length <> 10 Then
            MsgBox(mv_ResourceManager.GetString("ERR_CF_CONTRACT_NOT_FOUND"), MsgBoxStyle.Information, Me.Text)
            Me.ActiveControl = Me.mskAFACCTNO
            Exit Sub
        End If
        If txtQuotePrice.Text.Trim.Length > 0 Then
            If mv_dblTradeUnit <= 0 Or mv_dblFloorPrice <= 0 Or mv_dblCeilingPrice <= 0 Then
                MsgBox(mv_ResourceManager.GetString("ERR_SEC_INFO"), MsgBoxStyle.Information, Me.Text)
                e.Cancel = True
            End If
            If Not IsNumeric(txtQuotePrice.Text) Then
                MsgBox(mv_ResourceManager.GetString("PRICEISNOTNUMBER"), MsgBoxStyle.Information, Me.Text)
                e.Cancel = True
            ElseIf CDbl(txtQuotePrice.Text) < 0 Then
                MsgBox(mv_ResourceManager.GetString("PRICEISNOTNUMBER"), MsgBoxStyle.Information, Me.Text)
                e.Cancel = True
            ElseIf txtQuotePrice.Text.ToString.IndexOf(".") >= 0 AndAlso CType(txtQuotePrice.Text.ToString.Split(".").GetValue(1), String).Length > 7 Then
                MsgBox(mv_ResourceManager.GetString("PRICEISINVALID"), MsgBoxStyle.Information, Me.Text)
                e.Cancel = True
            Else
                If Trim(Me.cboPriceType.SelectedValue) = "LO" Then
                    If cboMatchType.SelectedValue = "P" And InStr(mv_strSETYPE, txtSecType.Text) > 0 Then
                        If Me.txtTradePalce.Text = gc_TRADEPLACE_UPCOM Then
                            If CInt(CDbl(txtQuotePrice.Text) * mv_dblTradeUnit) > CInt(mv_dblCeilingPrice) Then
                                MsgBox(mv_ResourceManager.GetString("CEILINGINVALID"), MsgBoxStyle.Information, Me.Text)
                                e.Cancel = True
                            ElseIf CInt(CDbl(txtQuotePrice.Text) * mv_dblTradeUnit) < CInt(mv_dblFloorPrice) Then
                                MsgBox(mv_ResourceManager.GetString("FLOORINVALID"), MsgBoxStyle.Information, Me.Text)
                                e.Cancel = True
                            End If
                        End If
                    Else
                        If Me.cboTimeType.SelectedValue <> "G" Or Me.mv_strTxNum.Length > 0 Then
                            'Neu khong phai lenh Good till cancel 
                            If CInt(CDbl(txtQuotePrice.Text) * mv_dblTradeUnit) > CInt(mv_dblCeilingPrice) Then
                                MsgBox(mv_ResourceManager.GetString("CEILINGINVALID"), MsgBoxStyle.Information, Me.Text)
                                e.Cancel = True
                            ElseIf CInt(CDbl(txtQuotePrice.Text) * mv_dblTradeUnit) < CInt(mv_dblFloorPrice) Then
                                MsgBox(mv_ResourceManager.GetString("FLOORINVALID"), MsgBoxStyle.Information, Me.Text)
                                e.Cancel = True
                            End If
                        End If
                    End If
                End If
            End If
            SetPPSE()
        End If
    End Sub

    Private Sub txtLimitPrice_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLimitPrice.Validating
        If Me.mskAFACCTNO.Text.Length <> 10 Then
            MsgBox(mv_ResourceManager.GetString("ERR_CF_CONTRACT_NOT_FOUND"), MsgBoxStyle.Information, Me.Text)
            Me.ActiveControl = Me.mskAFACCTNO
            Exit Sub
        End If
        If Not IsNumeric(txtLimitPrice.Text) Then
            MsgBox(mv_ResourceManager.GetString("PRICEISNOTNUMBER"), MsgBoxStyle.Information, Me.Text)
            e.Cancel = True
        ElseIf CDbl(txtLimitPrice.Text) < 0 Then
            MsgBox(mv_ResourceManager.GetString("PRICEISNOTNUMBER"), MsgBoxStyle.Information, Me.Text)
            e.Cancel = True
        End If
    End Sub

    Private Sub txtClearingDay_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtClearingDay.Validating
        If Not IsNumeric(txtClearingDay.Text) Then
            MsgBox(mv_ResourceManager.GetString("CLEARINGDAYINVALID"), MsgBoxStyle.Information, Me.Text)
            e.Cancel = True
        ElseIf CDbl(txtClearingDay.Text) <= 0 Or CDbl(txtClearingDay.Text) > mv_dblSYSClearday Then
            MsgBox(mv_ResourceManager.GetString("CLEARINGDAYINVALID"), MsgBoxStyle.Information, Me.Text)
            e.Cancel = True
        End If
    End Sub

    Private Sub txtQuantity_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQuantity.GotFocus
        With txtQuantity
            .SelectionStart = 0
            .SelectionLength = Len(.Text)
        End With
    End Sub
    Private Sub txtQuantity_Validating(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQuantity.Validating
        If Not IsNumeric(txtQuantity.Text) Then
            MsgBox(mv_ResourceManager.GetString("QTTYISNOTNUMBER"), MsgBoxStyle.Information, Me.Text)
            txtQuantity.Focus()
            Return
        End If
        txtQuantity.Text = FormatNumber(Math.Floor(CDbl(txtQuantity.Text)), 0)
    End Sub
    Private Sub txtQuotePrice_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQuotePrice.GotFocus
        With txtQuotePrice
            .SelectionStart = 0
            .SelectionLength = Len(.Text)
        End With
    End Sub

    Private Sub txtLimitPrice_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLimitPrice.GotFocus
        With txtLimitPrice
            .SelectionStart = 0
            .SelectionLength = Len(.Text)
        End With
    End Sub

    Private Sub txtClearingDay_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtClearingDay.GotFocus
        With txtClearingDay
            .SelectionStart = 0
            .SelectionLength = Len(.Text)
        End With
    End Sub

    Private Sub cboPriceType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPriceType.SelectedIndexChanged
        'Neu la lenh pouthrought thi khong cho phep gia MO
        Select Case Trim(Convert.ToString(cboPriceType.SelectedValue))
            Case "LO"
                txtQuotePrice.Enabled = True
                txtLimitPrice.Enabled = False
                txtLimitPrice.Text = "0"
                cboMatchType.Enabled = True
                cboTimeType.SelectedValue = "T"
                cboTimeType.Enabled = True
                chkOUTPRICEALLOW.Enabled = False
                cboTimeType.SelectedValue = "T"
                'chkOUTPRICEALLOW.Checked = True
            Case "ATO", "ATC"
                txtQuotePrice.Enabled = False
                txtQuotePrice.Text = "0"
                txtLimitPrice.Enabled = False
                txtLimitPrice.Text = "0"
                cboMatchType.SelectedValue = "N"
                cboMatchType.Enabled = False
                cboTimeType.SelectedValue = "T"
                cboTimeType.Enabled = True
                chkOUTPRICEALLOW.Enabled = False
                'chkOUTPRICEALLOW.Checked = True
            Case "MO", "MP"
                txtQuotePrice.Enabled = False
                txtQuotePrice.Text = "0"
                txtLimitPrice.Enabled = False
                txtLimitPrice.Text = "0"
                cboMatchType.Enabled = True
                cboMatchType.SelectedValue = "N"
                cboMatchType.Enabled = False
                cboTimeType.SelectedValue = "T"
                cboTimeType.Enabled = True
                chkOUTPRICEALLOW.Enabled = False
                'chkOUTPRICEALLOW.Checked = True
            Case "SL"
                txtQuotePrice.Enabled = True
                txtLimitPrice.Enabled = True
                cboMatchType.Enabled = False
                cboTimeType.SelectedValue = "G"
                cboTimeType.Enabled = False
                chkOUTPRICEALLOW.Enabled = True
                'chkOUTPRICEALLOW.Checked = True

            Case "SM"
                txtQuotePrice.Enabled = True
                txtLimitPrice.Enabled = False
                txtLimitPrice.Text = "0"
                cboMatchType.Enabled = True
                cboTimeType.SelectedValue = "T"
                cboTimeType.Enabled = True
                chkOUTPRICEALLOW.Enabled = False
                'chkOUTPRICEALLOW.Checked = True
            Case "MTL", "MOK", "MAK", "SBO", "OBO", "PLO"
                txtQuotePrice.Enabled = False
                txtLimitPrice.Enabled = False
                txtQuotePrice.Text = "0"
                txtLimitPrice.Text = "0"
                cboMatchType.Enabled = False
                cboMatchType.SelectedValue = "N"
                cboTimeType.SelectedValue = "T"
                cboTimeType.Enabled = True
                chkOUTPRICEALLOW.Enabled = False
        End Select
        If Not (Me.TxDate.Length > 0 And Me.TxNum.Length > 0) Then
            If Me.txtTradePalce.Text = c_HO_TRADEPLACE Then
                Dim v_strSelValue As String = Convert.ToString(cboPriceType.SelectedValue)
                If mv_blnIsDelete = False Then
                    If txtMkStatus.Text.Trim <> "ALL" Then
                        If v_strSelValue <> "LO" AndAlso v_strSelValue <> Me.txtMkStatus.Text Then
                            Me.ErrorProvider1.SetError(cboPriceType, "You should place " & Me.txtMkStatus.Text & " or Limit order !!!")
                            Exit Sub
                        End If
                    Else
                        Me.ErrorProvider1.SetError(cboPriceType, "You should place order in regular trading time !!!")
                        Exit Sub
                    End If
                End If
            End If
        End If
        If mv_dblTradeLot > 0 And Me.cboMatchType.SelectedValue <> "P" And Len(txtQuantity.Text) > 0 Then
            'If CDbl(txtQuantity.Text) Mod mv_dblTradeLot > 0 Then
            '    MsgBox(mv_ResourceManager.GetString("TRADELOTINVALID"), MsgBoxStyle.Information, Me.Text)
            '    txtQuantity.Focus()
            '    Exit Sub
            'End If
            ' PhuongHT edit
            ' cho phep dat lenh lo le voi san HNX; lenh LO, <1 lo
            If Not (Me.cboPriceType.SelectedValue Is Nothing) Then
                If CDbl(txtQuantity.Text) Mod mv_dblTradeLot > 0 Then
                    If (txtTradePalce.Text <> c_HA_TRADEPLACE And txtTradePalce.Text <> c_UPCOM_TRADEPLACE) Then ' khong pai san HNX,UPCOM
                        MsgBox(mv_ResourceManager.GetString("TRADELOTINVALID"), MsgBoxStyle.Information, Me.Text)
                        txtQuantity.Focus()
                        Exit Sub
                    ElseIf (CDbl(txtQuantity.Text) > mv_dblTradeLot) Or (Me.cboPriceType.SelectedValue.ToString <> "LO" And Trim(Me.cboPriceType.SelectedValue.ToString) <> "") Then
                        'la san HNX,UP nhung khong pai lenh LO hoac le > 1 lo
                        MsgBox(mv_ResourceManager.GetString("TRADELOTINVALID"), MsgBoxStyle.Information, Me.Text)
                        txtQuantity.Focus()
                        Exit Sub
                    End If

                End If
                ' end of PhuongHT edit
            End If
        End If

        Me.ErrorProvider1.Dispose()
    End Sub

    Private Sub cboVia_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVia.SelectedIndexChanged
        Select Case Trim(Convert.ToString(cboVia.SelectedValue))
            Case "T", "O"
                cboVoucher.SelectedValue = "P"
                cboVoucher.Enabled = False
            Case "F", "A"
                cboVoucher.SelectedValue = "C"
                cboVoucher.Enabled = False
        End Select
    End Sub

    Private Sub cboTimeType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTimeType.SelectedIndexChanged
        Select Case Trim(Convert.ToString(cboTimeType.SelectedValue))
            Case "G"
                Me.dtpExpiredDate.Enabled = True
                'Me.dtpExpiredDate.Value = Me.BusDate
                Me.dtpEffectiveDate.Enabled = True
                'Me.dtpEffectiveDate.Value = Me.BusDate
                Me.cboMatchType.SelectedValue = "N"
                Me.cboMatchType.Enabled = False
            Case "T"
                Me.dtpExpiredDate.Enabled = False
                Me.dtpExpiredDate.Value = Me.BusDate
                Me.dtpEffectiveDate.Enabled = False
                Me.dtpEffectiveDate.Value = Me.BusDate
                Me.cboMatchType.Enabled = True
            Case "I"
                Me.dtpExpiredDate.Enabled = False
                Me.dtpExpiredDate.Value = Me.BusDate
                Me.dtpEffectiveDate.Enabled = False
                Me.dtpEffectiveDate.Value = Me.BusDate
                Me.cboMatchType.SelectedValue = "N"
                Me.cboMatchType.Enabled = False
        End Select
    End Sub

    'Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If mv_intCurrImageIndex < mv_arrSIGNATURE.Length - 1 Then
    '        mv_intCurrImageIndex += 1
    '        LoadCFSign(mv_strCUSTID)
    '    End If
    'End Sub
    'Private Sub btnPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If mv_intCurrImageIndex > 0 Then
    '        mv_intCurrImageIndex -= 1
    '        LoadCFSign(mv_strCUSTID)
    '    End If
    'End Sub
    Private Sub dtpExpiredDate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpExpiredDate.Validating
        If Me.dtpExpiredDate.Value < Me.BusDate Then
            MsgBox(mv_ResourceManager.GetString("ERR_EXPIREDDATE_INVALID"), MsgBoxStyle.Information, Me.Text)
            e.Cancel = True
        End If
        If Me.dtpExpiredDate.Value < Me.dtpEffectiveDate.Value Then
            MsgBox(mv_ResourceManager.GetString("ERR_EXPIREDDATE_INVALID"), MsgBoxStyle.Information, Me.Text)
            e.Cancel = True
        End If
    End Sub

    Private Sub dtpEffectiveDate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpEffectiveDate.Validating
        If Me.dtpEffectiveDate.Value < Me.BusDate Then
            MsgBox(mv_ResourceManager.GetString("ERR_EFFECTIVEDATE_INVALID"), MsgBoxStyle.Information, Me.Text)
            e.Cancel = True
        End If
    End Sub

    Private Sub btnAdjust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdjust.Click
        Try
            Call OnAdjust()
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try

    End Sub
    Private Sub txtQuotePrice_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQuotePrice.Leave
        Try
            If txtQuotePrice.Text.Trim.Length > 0 Then
                'Kiểm tra bước giá
                If IsNumeric(txtQuotePrice.Text) And _
                        (cboPriceType.SelectedValue = "LO" Or cboPriceType.SelectedValue = "SL") _
                                    And (cboMatchType.SelectedValue <> "P" Or Me.txtTradePalce.Text = gc_TRADEPLACE_UPCOM) Then
                    CheckSETickSize()
                End If
            End If
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub mskAFACCTNO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskAFACCTNO.GotFocus
        Me.mskAFACCTNO.SelectAll()
    End Sub
    Private Sub btnApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApprove.Click
        OnApprove()
    End Sub
    Private Sub btnRefuse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefuse.Click
        OnRefuse()
    End Sub
    Private Sub btnReject_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReject.Click
        OnReject()
    End Sub
    Private Sub cboCODEID_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCODEID.KeyUp
        Select Case e.KeyCode
            Case Keys.PageUp
                Me.cboExecType.Text = "Normal Buy"
                QuickOrder(True)
            Case Keys.PageDown
                Me.cboExecType.Text = "Normal Sell"
                QuickOrder(True)
            Case Keys.End
                QuickOrder(False)
                mskAFACCTNO.Focus()
                mskAFACCTNO.SelectAll()
            Case Keys.Escape
                OnClose()
        End Select
    End Sub
    Private Sub cboMatchType_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMatchType.Validated
        'If cboPriceType.SelectedValue = "MO" And cboMatchType.SelectedValue = "P" Then
        '    MessageBox.Show("Matchtype can't be Putthrough when Pricetype are MO!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    cboPriceType.Focus()
        '    Exit Sub
        'End If
        'If cboMatchType.SelectedValue = "P" Then
        '    If cboPriceType.SelectedValue = "ATC" Or cboPriceType.SelectedValue = "ATO" Then
        '        MessageBox.Show("Matchtype can't be Putthrough when Pricetype are ATO or ATC!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '        cboMatchType.Focus()
        '        Exit Sub
        '    End If
        'End If
        If Not cboPriceType.SelectedValue = "LO" And cboMatchType.SelectedValue = "P" Then
            MessageBox.Show(mv_ResourceManager.GetString("INV_MATYTYPELO"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPriceType.SelectedItem = "LO"
            cboPriceType.Focus()
            Exit Sub
        End If
        If Not CheckPutthought() Then
            txtQuantity.Focus()
            Exit Sub
        End If
        If mv_dblTradeLot > 0 And Me.cboMatchType.SelectedValue <> "P" And Len(txtQuantity.Text) > 0 Then
            'If CDbl(txtQuantity.Text) Mod mv_dblTradeLot > 0 Then
            '    MsgBox(mv_ResourceManager.GetString("TRADELOTINVALID"), MsgBoxStyle.Information, Me.Text)
            '    txtQuantity.Focus()
            '    Exit Sub
            'End If
            ' PhuongHT edit
            ' cho phep dat lenh lo le voi san HNX; lenh LO, <1 lo
            If CDbl(txtQuantity.Text) Mod mv_dblTradeLot > 0 Then
                If (txtTradePalce.Text <> c_HA_TRADEPLACE And txtTradePalce.Text <> c_UPCOM_TRADEPLACE) Then ' khong pai san HNX
                    MsgBox(mv_ResourceManager.GetString("TRADELOTINVALID"), MsgBoxStyle.Information, Me.Text)
                    txtQuantity.Focus()
                    Exit Sub
                ElseIf (CDbl(txtQuantity.Text) > mv_dblTradeLot) Or (Me.cboPriceType.SelectedValue <> "LO") Then
                    'la san HNX nhung khong pai lenh LO hoac le > 1 lo
                    MsgBox(mv_ResourceManager.GetString("TRADELOTINVALID"), MsgBoxStyle.Information, Me.Text)
                    txtQuantity.Focus()
                    Exit Sub
                End If

            End If
            ' end of PhuongHT edit
        End If

        ''Check cho lenh thoa thuan trai phieu repo
        If cboMatchType.SelectedValue = "P" And (Me.txtSecType.Text = "006" Or Me.txtSecType.Text = "003") Then
            Me.chkPTRepo.Visible = True
            If Me.chkPTRepo.Checked Then
                SetPTScreen(True)
            Else
                SetPTScreen(False)
            End If
        Else
            Me.chkPTRepo.Visible = False
            SetPTScreen(False)
        End If

    End Sub



#Region "TimerProcess"

    Private Sub frmQuickOrderTransact_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        If Me.mv_blnIsDelete And txtOrStatus.Text = "Pending to Send" And (mv_blnisClosed = False) Then
            'Nếu là lệnh huỷ sửa khi cancel thì giải toả trạng thái để cho phép Send
            OnCancelCorection()
        End If
        Me.tmrOrder.Dispose()
        Me.tmrOrder.Stop()
        Me.tmrOrder.Enabled = False
    End Sub

    Private Sub tmrOrder_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmrOrder.Tick
        ComputeUpTime()
        ChangeMarketStatus()
    End Sub

    Private Sub ChangeMarketStatus()
        Try
            'Cap nhat trang thai thi truong hien tai
            For i As Integer = 0 To mv_arrHoPriceTypeInfo.Length - 1
                Dim strTimer As String = lblTimer.Text.Trim.Substring(0, 8)
                strTimer = strTimer.Replace(":", "")
                If strTimer < mv_arrHoPriceTypeInfo(i).HoToTime _
                    And strTimer > mv_arrHoPriceTypeInfo(i).HoFromTime Then
                    txtMkStatus.Text = mv_arrHoPriceTypeInfo(i).HoPriceType
                    Exit For
                Else
                    txtMkStatus.Text = "ALL"
                End If
            Next
            'SettingPriceTypeByTime()
        Catch ex As Exception

        End Try

    End Sub

    'Private Sub SettingPriceTypeByTime()
    '    Dim v_strCmdSQL, v_strObjMsg As String
    '    Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
    '    If Me.txtTradePalce.Text = c_HO_TRADEPLACE Then 'Thi truong HCM
    '        If txtMkStatus.Text.Length = 0 Then
    '            txtMkStatus.Text = "ALL"
    '        End If
    '        If txtMkStatus.Text <> mv_strPrevPriceType Then
    '            Dim v_strSelValue As String = cboPriceType.SelectedValue
    '            Select Case txtMkStatus.Text.Trim
    '                Case "ALL"
    '                    v_strCmdSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, LSTODR FROM ALLCODE WHERE CDTYPE='OD' AND TRIM(CDNAME)='ALL_PRICETYPE' ORDER BY LSTODR"
    '                Case "ATO"
    '                    v_strCmdSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, LSTODR FROM ALLCODE WHERE CDTYPE='OD' AND TRIM(CDNAME)='ATO_PRICETYPE' ORDER BY LSTODR"
    '                Case "ATC"
    '                    v_strCmdSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, LSTODR FROM ALLCODE WHERE CDTYPE='OD' AND TRIM(CDNAME)='ATC_PRICETYPE' ORDER BY LSTODR"
    '                Case "MP"
    '                    v_strCmdSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, LSTODR FROM ALLCODE WHERE CDTYPE='OD' AND TRIM(CDNAME)='MP_PRICETYPE' ORDER BY LSTODR"
    '                Case Else
    '                    v_strCmdSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, LSTODR FROM ALLCODE WHERE CDTYPE='OD' AND TRIM(CDNAME)='ALL_PRICETYPE' ORDER BY LSTODR"
    '            End Select
    '            cboPriceType.Clears()
    '            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
    '            v_ws.Message(v_strObjMsg)
    '            FillComboEx(v_strObjMsg, cboPriceType)

    '            If cboPriceType.IsContaints(v_strSelValue) Then
    '                cboPriceType.SelectedValue = v_strSelValue
    '            End If
    '            mv_strPrevPriceType = txtMkStatus.Text
    '        End If
    '    End If
    'End Sub

    Private Sub ComputeUpTime()
        Dim nTicks As Double
        Dim nDays As Integer
        Dim nHours As Integer
        Dim nMin As Integer
        Dim nSec As Integer
        Dim TimeUp As String
        nTicks = tickCount
        nTicks = nTicks / 1000
        nTicks = nTicks - (Int(nTicks / (3600 * 24)) * (3600 * 24))
        nHours = Int(nTicks / 3600)
        nTicks = nTicks - (Int(nTicks / 3600) * 3600)
        nMin = Int(nTicks / 60)
        nTicks = nTicks - (Int(nTicks / 60) * 60)
        nSec = nTicks
        lblTimer.Text = Format$(nHours, "00") & ":" & Format$(nMin, "00") & ":" & Format$(nSec, "00") & "-" & txtMkStatus.Text
        tickCount += 1000
    End Sub

#End Region

#End Region

#Region "PrivateUtilFunction"

    Private Sub OnCancelCorection()
        Dim v_strFilter, v_strClause As String
        Dim v_strFLDNAME, v_strValue As String
        Dim v_strFieldType, v_strDataType As String
        Dim v_ctrl As Windows.Forms.Control
        Dim v_strErrorSource, v_strErrorMessage As String
        Dim v_lngErrorCode As Long
        Try
            Dim v_strCmdInquiry As String
            v_strClause = Trim(mskOrderID.Text)
            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_strClause, "CancelOrderCorrectionSending", , , , IpAddress)
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            v_lngErrorCode = v_ws.Message(v_strObjMsg)
            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
            If v_lngErrorCode <> 0 Then
                'Update mouse pointer
                Cursor.Current = Cursors.Default
                MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                Exit Sub
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Function CheckCorrectionOrderStatus() As Boolean
        Dim v_strFilter As String
        Dim v_strFLDNAME, v_strValue As String
        Dim v_strFieldType, v_strDataType As String
        Dim v_ctrl As Windows.Forms.Control
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_strErrorSource, v_strErrorMessage As String
        Dim v_lngErrorCode As Long

        Try
            Dim v_strClause As String

            v_strClause = Me.mskOrderID.Text
            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_strClause, "CheckCorrectionOrderStatus", , , , IpAddress)
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            v_lngErrorCode = v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)

            If v_lngErrorCode <> ERR_SYSTEM_OK Then
                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                Cursor.Current = Cursors.Default
                MsgBox(v_strErrorMessage, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, Me.Text)
                ResetScreen(Me)
                ShowAdjustButton(False)
                ResetDeleteButton()
                Return False
            End If
            Return True
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function

    Private Sub ShowSENormalMode(ByVal pv_strCodeID As String)
        Try
            Dim v_strCmdSQL, v_strAFACCTNO, v_strObjMsg As String
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            If mskAFACCTNO.Text.Length > 0 Then
                v_strAFACCTNO = Me.mskAFACCTNO.Text.Trim
                If Not mv_blnAdvanceOrder Then
                    'Lấy thông tin v? các tài khoản SE của khách hàng 
                    'v_strCmdSQL = "SELECT B.SYMBOL, A.TRADE,A.MORTAGE, A.COSTPRICE, NVL(C.BASICPRICE, 0) BASICPRICE " & vbCrLf & _
                    '    " FROM SEMAST A, SBSECURITIES B, (SELECT CODEID, BASICPRICE, TXDATE FROM SECURITIES_INFO WHERE TXDATE = TO_DATE('" & mv_strBusDate & "','" & gc_FORMAT_DATE & "') )C " & vbCrLf & _
                    '    " WHERE A.CODEID = B.CODEID AND A.CODEID = C.CODEID (+)" & vbCrLf & _
                    '    " AND A.AFACCTNO = '" & v_strAFACCTNO & "' AND A.CODEID='" & pv_strCodeID & "' AND A.TRADE <> 0 ORDER BY B.SYMBOL"
                    v_strCmdSQL = "SELECT B.SYMBOL, A.TRADE-nvl(D.SECUREAMT,0)+nvl(D.RECEIVING,0) TRADE,A.MORTAGE-nvl(D.SECUREMTG,0) MORTAGE, A.COSTPRICE, NVL(C.BASICPRICE, 0) BASICPRICE  " & ControlChars.CrLf _
                            & "  FROM SEMAST A, SBSECURITIES B, (SELECT CODEID, BASICPRICE, TXDATE FROM SECURITIES_INFO WHERE TXDATE = TO_DATE('" & mv_strBusDate & "','" & gc_FORMAT_DATE & "') ) C,  " & ControlChars.CrLf _
                            & "  (SELECT SEACCTNO, SUM(SECUREAMT) SECUREAMT, SUM(SECUREMTG) SECUREMTG, SUM(RECEIVING) RECEIVING " & ControlChars.CrLf _
                            & "   FROM (SELECT OD.SEACCTNO, " & ControlChars.CrLf _
                            & "             CASE WHEN OD.EXECTYPE IN ('NS', 'SS') AND OD.TXDATE =TO_DATE ('" & mv_strBusDate & "', '" & gc_FORMAT_DATE & "') THEN REMAINQTTY + EXECQTTY ELSE 0 END SECUREAMT, " & ControlChars.CrLf _
                            & "             CASE WHEN OD.EXECTYPE = 'MS'  AND OD.TXDATE =TO_DATE ('" & mv_strBusDate & "', '" & gc_FORMAT_DATE & "') THEN REMAINQTTY + EXECQTTY ELSE 0 END SECUREMTG, " & ControlChars.CrLf _
                            & "             CASE WHEN OD.EXECTYPE = 'NB' THEN ST.QTTY ELSE 0 END RECEIVING " & ControlChars.CrLf _
                            & "         FROM ODMAST OD, STSCHD ST, ODTYPE TYP " & ControlChars.CrLf _
                            & "         WHERE OD.DELTD <> 'Y'  AND OD.EXECTYPE IN ('NS', 'SS','MS', 'NB') " & ControlChars.CrLf _
                            & "             AND OD.ORDERID = ST.ORGORDERID(+) AND ST.DUETYPE(+) = 'RS' " & ControlChars.CrLf _
                            & "             And OD.ACTYPE = TYP.ACTYPE " & ControlChars.CrLf _
                            & "             AND ((TYP.TRANDAY <= (SELECT SUM(CASE WHEN CLDR.HOLIDAY = 'Y' THEN 0 ELSE 1 END)-1 " & ControlChars.CrLf _
                            & "                                     FROM SBCLDR CLDR " & ControlChars.CrLf _
                            & "                                     WHERE CLDR.CLDRTYPE = '000' AND CLDR.SBDATE >= ST.TXDATE AND CLDR.SBDATE <= TO_DATE ('" & mv_strBusDate & "', '" & gc_FORMAT_DATE & "')) AND OD.EXECTYPE = 'NB') " & ControlChars.CrLf _
                            & "                 OR OD.EXECTYPE IN ('NS','SS','MS'))) GROUP BY SEACCTNO ) D " & ControlChars.CrLf _
                            & "  WHERE A.CODEID = B.CODEID AND A.CODEID = C.CODEID (+) AND A.ACCTNO=D.SEACCTNO(+) " & ControlChars.CrLf _
                            & "  AND A.AFACCTNO = '" & v_strAFACCTNO & "'  AND A.CODEID='" & pv_strCodeID & "' AND A.TRADE + A.MORTAGE-nvl(D.SECUREMTG,0)-nvl(D.SECUREAMT,0)+nvl(D.RECEIVING,0) <> 0 AND  B.SECTYPE <>'004'  ORDER BY B.SYMBOL " & ControlChars.CrLf
                End If
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strCmdSQL)
                v_ws.Message(v_strObjMsg)
                FillDataGrid(SEMemberGrid, v_strObjMsg, "")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CheckIssuer(ByVal pv_strCodeID As String)
        Try
            'Lấy thông tin v? giá chứng khoán
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_strValue, v_strFLDNAME, v_strTEXT As String
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_strCmdSQL, v_strAFACCTNO As String, v_strObjMsg, v_strIssuerId As String
            If mskAFACCTNO.Text.Length > 0 Then
                v_strAFACCTNO = Me.mskAFACCTNO.Text.Trim
                v_strCmdSQL = "SELECT MST.* FROM (SELECT IM.ISSUERID FROM CFMAST CF INNER JOIN AFMAST AF ON CF.CUSTID=AF.CUSTID" _
                    & " LEFT JOIN ISSUER_MEMBER IM ON CF.CUSTID=IM.CUSTID WHERE  AF.ACCTNO='" & v_strAFACCTNO & "')MST" _
                    & " RIGHT JOIN(SELECT ISSUERID FROM SBSECURITIES WHERE CODEID='" & pv_strCodeID & "')DTL ON MST.ISSUERID=DTL.ISSUERID"

                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_AFMAST, gc_ActionInquiry, v_strCmdSQL)
                v_ws.Message(v_strObjMsg)
                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                Dim v_strTellerName As String = String.Empty
                For i As Integer = 0 To v_nodeList.Count - 1
                    v_strTEXT = String.Empty
                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            v_strValue = Trim(.InnerText.ToString)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME)
                                Case "ISSUERID"
                                    v_strIssuerId = v_strValue
                            End Select
                        End With
                    Next
                Next

                If v_strIssuerId.Length > 0 Then
                    lblAFINFO.ForeColor = Color.Red
                    mv_strIsIssuer = "Y"
                Else
                    lblAFINFO.ForeColor = Color.Black
                    mv_strIsIssuer = "N"
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Tot hon la lay o MIDMain
    Private Sub GetTellerName()
        Try
            'Da truyen thong tin tu form main roi nen khong can lay lai nua.
            'Tranh tinh trnag query len Host qua nhieu lan
            Exit Sub
            'Lấy thông tin v? giá chứng khoán
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_strValue, v_strFLDNAME, v_strTEXT As String
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_strCmdSQL As String, v_strObjMsg As String
            v_strCmdSQL = "SELECT * FROM TLPROFILES PROF WHERE PROF.TLID='" & TellerId & "'"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            Dim v_strTellerName As String = ""
            For i As Integer = 0 To v_nodeList.Count - 1
                v_strTEXT = String.Empty
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = Trim(.InnerText.ToString)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "TLNAME"
                                v_strTellerName &= v_strValue
                            Case "TLFULLNAME"
                                'v_strTellerName &= v_strValue
                        End Select
                    End With
                Next
            Next
            Me.TellerName = v_strTellerName
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region


    'Private Sub cboTimeType_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboTimeType.Validating
    '    Select Case Trim(cboTimeType.SelectedValue)
    '        Case "G"
    '            Me.dtpExpiredDate.Enabled = True
    '            'Me.dtpExpiredDate.Value = Me.BusDate
    '            Me.dtpEffectiveDate.Enabled = True
    '            'Me.dtpEffectiveDate.Value = Me.BusDate
    '            Me.cboMatchType.SelectedValue = "N"
    '            Me.cboMatchType.Enabled = False
    '        Case "T"
    '            Me.dtpExpiredDate.Enabled = False
    '            Me.dtpExpiredDate.Value = Me.BusDate
    '            Me.dtpEffectiveDate.Enabled = False
    '            Me.dtpEffectiveDate.Value = Me.BusDate
    '            Me.cboMatchType.Enabled = True
    '        Case "I"
    '            Me.dtpExpiredDate.Enabled = False
    '            Me.dtpExpiredDate.Value = Me.BusDate
    '            Me.dtpEffectiveDate.Enabled = False
    '            Me.dtpEffectiveDate.Value = Me.BusDate
    '            Me.cboMatchType.SelectedValue = "N"
    '            Me.cboMatchType.Enabled = False
    '    End Select
    'End Sub

    Private Sub cboPutType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPutType.SelectedIndexChanged
        If Convert.ToString(cboPutType.SelectedValue) = "E" Then
            Me.txtContraCus.Enabled = False
            Me.txtContraFirm.Enabled = False
        Else
            Me.txtContraCus.Enabled = True
            Me.txtContraFirm.Enabled = True
        End If
    End Sub

    Private Sub btnGetDeal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetDeal.Click
        Dim frm As New frmSearch(Me.UserLanguage)
        frm.TableName = "DFSELLDEAL"
        frm.ModuleCode = "DF"
        frm.AuthCode = "NNNNYYNNNN" 'Không cho phép thực hiện chức năng nào 
        frm.IsLocalSearch = gc_IsNotLocalMsg
        frm.IsLookup = "Y"
        frm.SearchOnInit = False
        frm.BranchId = Me.BranchId
        frm.TellerId = Me.TellerId
        frm.AFACCTNO = Trim(mskAFACCTNO.Text)
        'frm.mv_strSearchFilter = " AND DFTRADING>0 "
        frm.ShowDialog()
        Me.txtDealNO.Text = Trim(frm.ReturnValue)
        GetDealInfo(frm.ReturnValue)
        frm.Dispose()
    End Sub

    Private Sub txtDealNO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDealNO.Validating
        GetDealInfo(Me.txtDealNO.Text)
    End Sub

    Private Sub chkPTRepo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPTRepo.CheckedChanged
        If Me.chkPTRepo.Checked Then
            SetPTScreen(True)
        Else
            SetPTScreen(False)
        End If
    End Sub

    Private Sub dtpEXPTDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpEXPTDATE.Validating
        If Me.dtpEXPTDATE.Value < Me.BusDate Then
            MsgBox(mv_ResourceManager.GetString("ERR_EXPIREDDATE_INVALID"), MsgBoxStyle.Information, Me.Text)
            e.Cancel = True
        End If
    End Sub
    Private Sub txtEXPTPRICE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtEXPTPRICE.Validating
        If Me.mskREFORDERID.Text.Length = 0 Then
            If Not IsNumeric(txtEXPTPRICE.Text) Then
                MsgBox(mv_ResourceManager.GetString("PRICEISNOTNUMBER"), MsgBoxStyle.Information, Me.Text)
                e.Cancel = True
            ElseIf CDbl(txtEXPTPRICE.Text) <= 0 Then
                MsgBox(mv_ResourceManager.GetString("PRICEISNOTNUMBER"), MsgBoxStyle.Information, Me.Text)
                e.Cancel = True
            ElseIf txtEXPTPRICE.Text.ToString.IndexOf(".") >= 0 AndAlso CType(txtEXPTPRICE.Text.ToString.Split(".").GetValue(1), String).Length > 6 Then
                MsgBox(mv_ResourceManager.GetString("PRICEISINVALID"), MsgBoxStyle.Information, Me.Text)
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblExecQtty.Click

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
   
Private Sub fcbAfacctno_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fcbAfacctno.SelectedIndexChanged
        If Not fcbAfacctno.SelectedValue() Is DBNull.Value Then
            mskAFACCTNO.Text = fcbAfacctno.SelectedValue()
            GetAFContractInfo(mskAFACCTNO.Text)
        End If
    End Sub

    'Private Sub mskCustodycd_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mskCustodycd.TextChanged
    '    LoadAFACCTNO()
    '    If fcbAfacctno.Items.Count > 0 Then
    '        fcbAfacctno.SelectedIndex = 0
    '    Else
    '        MsgBox(mv_ResourceManager.GetString("CF_NOT_FOUND"), MsgBoxStyle.Information, Me.Text)
    '        Me.ActiveControl = mskCustodycd
    '    End If

    '    If mskCustodycd.Text.Length = 0 Then
    '        MsgBox(mv_ResourceManager.GetString("ERR_CUSTODY_NULL"), MsgBoxStyle.Information, Me.Text)
    '        Me.ActiveControl = mskCustodycd
    '    End If
    'End Sub

    Private Sub LoadAFACCTNO()
        Try
            Dim v_strCmdSQL As String
            Dim v_ws As New BDSDeliveryManagement
            Dim v_strObjMsg As String
            v_strCmdSQL = "SELECT VALUE, DISPLAY, EN_DISPLAY EN_DISPLAY FROM VW_CUSTODYCD_SUBACCOUNT WHERE FILTERCD = '" & Me.mskCustodycd.Text.ToUpper & "'"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_AFMAST, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            FillComboEx(v_strObjMsg, fcbAfacctno, "", Me.UserLanguage)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub mskCustodycd_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mskCustodycd.Leave
        LoadAFACCTNO()
        If fcbAfacctno.Items.Count > 0 Then
            fcbAfacctno.SelectedIndex = 0
        Else
            MsgBox(mv_ResourceManager.GetString("CF_NOT_FOUND"), MsgBoxStyle.Information, Me.Text)
            Me.ActiveControl = mskCustodycd
        End If

        If mskCustodycd.Text.Length = 0 Then
            MsgBox(mv_ResourceManager.GetString("ERR_CUSTODY_NULL"), MsgBoxStyle.Information, Me.Text)
            Me.ActiveControl = mskCustodycd
        End If
    End Sub

   
    Private Sub txtQuotePrice_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQuotePrice.KeyPress
        'Dim v_strKeyChar As String
        'v_strKeyChar = e.KeyChar.ToString

        'If (v_strKeyChar > "9" Or v_strKeyChar < "0") And v_strKeyChar <> "." And Not Char.IsControl(e.KeyChar) Then
        '    e.KeyChar = ""

        'ElseIf v_strKeyChar <= "9" And v_strKeyChar >= "0" And IsNumeric(txtQuotePrice.Text) Then
        '    If (txtQuotePrice.Text & v_strKeyChar).Length - InStr(txtQuotePrice.Text & v_strKeyChar, ".") > 3 And InStr(txtQuotePrice.Text & v_strKeyChar, ".") > 0 Then
        '        e.KeyChar = ""
        '    End If

        'ElseIf v_strKeyChar = "." And InStr(txtQuotePrice.Text, ".") > 0 Then
        '    e.KeyChar = ""

        'End If
        'txtQuotePrice.Select(txtQuotePrice.Text.Length, 0)
    End Sub
End Class
