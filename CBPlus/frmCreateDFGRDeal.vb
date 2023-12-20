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
Public Class frmCreateDFGRDeal
    Inherits System.Windows.Forms.Form
    Private mv_intCurrImageIndex As Integer = 0
    Private mv_arrSIGNATURE As String()
    Private mv_arrAUTOID As String()
    Private mv_arrCUSTID As String()
    Public mv_blnIsDelete As Boolean = False
    Public mv_blnAmendment As Boolean
    Private mv_blnShowOfficerFunction As Boolean = False
    Private mv_blnComboSymboLoad As Boolean = False
    Private mv_strTXSTATUS As String
    Private mv_strDELETE As String
    Private mv_intFeeMax As Decimal = 0
    Private mv_intFeeMin As Decimal = 0
    Private mv_feeamt As Decimal = 0

    'Sonlt Added for check block CA
    Private mv_blnIsBlockCA As Boolean = False
    Private mv_desc As String
    'End
    'TungNT Added for check user auth
    Private mv_strAuthRights As String = ""
    'End
    Const BTN_GAP = 7
    Const BTN_WIDTH = 80
    Const BTN_ROOT_LEFT = 631

    Friend WithEvents MemberGrid As New GridEx
    Friend WithEvents DFGRGrid As New GridEx
    Friend WithEvents mskACTYPE As AppCore.FlexMaskEditBox
    Friend WithEvents txtREF As System.Windows.Forms.TextBox
    Friend WithEvents lblREF As System.Windows.Forms.Label
    Friend WithEvents txtLRATE As System.Windows.Forms.TextBox
    Friend WithEvents lblLRATE As System.Windows.Forms.Label
    Friend WithEvents txtMRATE As System.Windows.Forms.TextBox
    Friend WithEvents lblMRATE As System.Windows.Forms.Label
    Friend WithEvents txtIRATE As System.Windows.Forms.TextBox
    Friend WithEvents lblIRATE As System.Windows.Forms.Label
    Friend WithEvents txtTRIGPRICE As System.Windows.Forms.TextBox
    Friend WithEvents lblTRIGPRICE As System.Windows.Forms.Label
    Friend WithEvents txtRefPrice As System.Windows.Forms.TextBox
    Friend WithEvents btnApprove As System.Windows.Forms.Button
    Friend WithEvents txtQuantity As System.Windows.Forms.TextBox
    Friend WithEvents lblQuantity As System.Windows.Forms.Label
    Friend WithEvents btnGetDeal As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkAUTODRAWNDOWN As System.Windows.Forms.CheckBox
    Friend WithEvents cboAFACCCBO As ComboBoxEx
    'Friend WithEvents cboAFACCTNODRD As ComboBoxEx
    Friend WithEvents lblAFACCCBO As System.Windows.Forms.Label
    Friend WithEvents mskCUSTODYCD As AppCore.FlexMaskEditBox
    Friend WithEvents lblCUSTODYCD As System.Windows.Forms.Label
    'Friend WithEvents cboRefPrice As System.Windows.Forms.ComboBox
    Friend WithEvents cboRefPrice As AppCore.ComboBoxEx
    Friend WithEvents txtMATVAL As System.Windows.Forms.TextBox
    Friend WithEvents lblMATVAL As System.Windows.Forms.Label
    Friend WithEvents txtDFAMT As System.Windows.Forms.TextBox
    Friend WithEvents lblDFAMT As System.Windows.Forms.Label
    Friend WithEvents chkENDNEWDEAL As System.Windows.Forms.CheckBox
    Friend WithEvents txtOLDDEALNO As System.Windows.Forms.TextBox
    Friend WithEvents lblOLDDEALNO As System.Windows.Forms.Label
    Friend WithEvents txtOLDDFQTTY As System.Windows.Forms.TextBox
    Friend WithEvents lblOLDDFQTTY As System.Windows.Forms.Label
    Friend WithEvents txtREMAINBAL As System.Windows.Forms.TextBox
    Friend WithEvents lblREMAINBAL As System.Windows.Forms.Label
    Friend WithEvents txtREMAINADVLINE As System.Windows.Forms.TextBox
    Friend WithEvents lblREMAINADVLINE As System.Windows.Forms.Label
    Friend WithEvents txtNETBALANCE As System.Windows.Forms.TextBox
    Friend WithEvents lblNETBALANCE As System.Windows.Forms.Label
    Friend WithEvents btnAdjust As System.Windows.Forms.Button
    Friend WithEvents chkOPTIONSTOCK As System.Windows.Forms.CheckBox
    Friend WithEvents txtOLDACTYPE As System.Windows.Forms.TextBox
    Friend WithEvents lblOLDACTYPE As System.Windows.Forms.Label
    Friend WithEvents txtOLDDFRATE As System.Windows.Forms.TextBox
    Friend WithEvents lblOLDDFRATE As System.Windows.Forms.Label
    Friend WithEvents txtBALDEFOVD As System.Windows.Forms.TextBox
    Friend WithEvents lblBALDEFOVD As System.Windows.Forms.Label
    Friend WithEvents txtBALADDOPT As System.Windows.Forms.TextBox
    Friend WithEvents lblBALADDOPT As System.Windows.Forms.Label
    Friend WithEvents pnDFGR As System.Windows.Forms.Panel
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents cboAFACCTNODRD As AppCore.ComboBoxEx
    Friend WithEvents LBLAFACCTNODRD As System.Windows.Forms.Label
    Friend WithEvents chkisapprove As System.Windows.Forms.CheckBox
    Friend WithEvents btnDEL As System.Windows.Forms.Button
    Friend WithEvents txtTOLAMT As System.Windows.Forms.TextBox
    Friend WithEvents lblTOLAMT As System.Windows.Forms.Label
    Friend WithEvents btnReject As System.Windows.Forms.Button
    Friend WithEvents txtDFLRATE As System.Windows.Forms.TextBox
    Friend WithEvents txtDFMRATE As System.Windows.Forms.TextBox
    Friend WithEvents txtDFIRATE As System.Windows.Forms.TextBox
    Friend WithEvents txtREFTXNUM As System.Windows.Forms.TextBox
    Friend WithEvents lblREFTXNUM As System.Windows.Forms.Label
    Friend WithEvents dtpREFTXDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblREFTXDATE As System.Windows.Forms.Label
    Friend WithEvents lblDFFeemap As System.Windows.Forms.Label
    Friend WithEvents mskDFFeeMap As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtFeeRate As System.Windows.Forms.TextBox
    Friend WithEvents lblFeeRate As System.Windows.Forms.Label
    Friend WithEvents txtFeeAmt As System.Windows.Forms.TextBox
    Friend WithEvents lblFeeAmt As System.Windows.Forms.Label
    Friend WithEvents txtRefSide As System.Windows.Forms.TextBox
    Friend WithEvents lblRefSide As System.Windows.Forms.Label
    Friend WithEvents SEMemberGrid As New GridEx

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

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
    Friend WithEvents lblDFPrice As System.Windows.Forms.Label
    Friend WithEvents txtDFPrice As System.Windows.Forms.TextBox
    Friend WithEvents lblRefPrice As System.Windows.Forms.Label
    Friend WithEvents pnContractInfo As System.Windows.Forms.Panel
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCANCEL As System.Windows.Forms.Button
    Friend WithEvents picSignature As System.Windows.Forms.PictureBox
    Friend WithEvents pnOrder As System.Windows.Forms.Panel
    Friend WithEvents chkDetail As System.Windows.Forms.CheckBox
    Friend WithEvents txtDFRATE As System.Windows.Forms.TextBox
    Friend WithEvents lblAFACCTNO As System.Windows.Forms.Label
    Friend WithEvents lblAcType As System.Windows.Forms.Label
    Friend WithEvents mskAFACCTNO As FlexMaskEditBox
    Friend WithEvents lblAFNAME As System.Windows.Forms.Label
    Friend WithEvents pnlMember As System.Windows.Forms.Panel
    Friend WithEvents lblAFINFO As System.Windows.Forms.Label
    Friend WithEvents pnBalance As System.Windows.Forms.Panel
    Friend WithEvents lblCI As System.Windows.Forms.Label
    Friend WithEvents lblCIBalance As System.Windows.Forms.Label
    Friend WithEvents lblSEBalance As System.Windows.Forms.Label
    Friend WithEvents lblSE As System.Windows.Forms.Label
    Friend WithEvents lblDFRATE As System.Windows.Forms.Label
    Friend WithEvents VScrollBarSign As System.Windows.Forms.VScrollBar
    Friend WithEvents cboCODEID As AppCore.ComboBoxEx
    'Public cboCODEID As AppCore.ComboBoxEx
    Friend WithEvents pnSEInfo As System.Windows.Forms.Panel
    Friend WithEvents lblSymbol As System.Windows.Forms.Label
    Friend WithEvents lblAAMT As System.Windows.Forms.Label
    Friend WithEvents lblCIAdvance As System.Windows.Forms.Label
    Friend WithEvents lblTotalAmout As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents cboPriceTime As AppCore.ComboBoxEx
    Friend WithEvents tmrOrder As System.Windows.Forms.Timer
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblMortage As System.Windows.Forms.Label
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCreateDFGRDeal))
        Me.pnlTitle = New System.Windows.Forms.Panel
        Me.cboAFACCCBO = New AppCore.ComboBoxEx
        Me.lblAFACCCBO = New System.Windows.Forms.Label
        Me.mskCUSTODYCD = New AppCore.FlexMaskEditBox
        Me.lblCUSTODYCD = New System.Windows.Forms.Label
        Me.lblAFINFO = New System.Windows.Forms.Label
        Me.lblAFNAME = New System.Windows.Forms.Label
        Me.mskAFACCTNO = New AppCore.FlexMaskEditBox
        Me.lblAFACCTNO = New System.Windows.Forms.Label
        Me.chkDetail = New System.Windows.Forms.CheckBox
        Me.pnOrder = New System.Windows.Forms.Panel
        Me.pnUpcomInfo = New System.Windows.Forms.Panel
        Me.lblContraFirm = New System.Windows.Forms.Label
        Me.txtContraFirm = New System.Windows.Forms.TextBox
        Me.lblContraCusInfo = New System.Windows.Forms.Label
        Me.lblContraCus = New System.Windows.Forms.Label
        Me.txtContraCus = New AppCore.FlexMaskEditBox
        Me.lblPutType = New System.Windows.Forms.Label
        Me.cboPutType = New AppCore.ComboBoxEx
        Me.pnMainInfo = New System.Windows.Forms.Panel
        Me.txtFeeAmt = New System.Windows.Forms.TextBox
        Me.lblFeeAmt = New System.Windows.Forms.Label
        Me.txtRefSide = New System.Windows.Forms.TextBox
        Me.lblRefSide = New System.Windows.Forms.Label
        Me.txtFeeRate = New System.Windows.Forms.TextBox
        Me.lblFeeRate = New System.Windows.Forms.Label
        Me.lblDFFeemap = New System.Windows.Forms.Label
        Me.mskDFFeeMap = New System.Windows.Forms.MaskedTextBox
        Me.txtDFLRATE = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtDFMRATE = New System.Windows.Forms.TextBox
        Me.cboRefPrice = New AppCore.ComboBoxEx
        Me.txtDFIRATE = New System.Windows.Forms.TextBox
        Me.lblRefPrice = New System.Windows.Forms.Label
        Me.txtTOLAMT = New System.Windows.Forms.TextBox
        Me.lblTOLAMT = New System.Windows.Forms.Label
        Me.txtDFAMT = New System.Windows.Forms.TextBox
        Me.lblDFAMT = New System.Windows.Forms.Label
        Me.lblMATVAL = New System.Windows.Forms.Label
        Me.txtQuantity = New System.Windows.Forms.TextBox
        Me.lblQuantity = New System.Windows.Forms.Label
        Me.txtRefPrice = New System.Windows.Forms.TextBox
        Me.mskACTYPE = New AppCore.FlexMaskEditBox
        Me.txtLRATE = New System.Windows.Forms.TextBox
        Me.lblLRATE = New System.Windows.Forms.Label
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.lblDescription = New System.Windows.Forms.Label
        Me.txtMRATE = New System.Windows.Forms.TextBox
        Me.lblMRATE = New System.Windows.Forms.Label
        Me.txtIRATE = New System.Windows.Forms.TextBox
        Me.lblIRATE = New System.Windows.Forms.Label
        Me.txtTRIGPRICE = New System.Windows.Forms.TextBox
        Me.lblTRIGPRICE = New System.Windows.Forms.Label
        Me.lblDFPrice = New System.Windows.Forms.Label
        Me.lblAcType = New System.Windows.Forms.Label
        Me.lblSymbol = New System.Windows.Forms.Label
        Me.cboCODEID = New AppCore.ComboBoxEx
        Me.txtDFPrice = New System.Windows.Forms.TextBox
        Me.txtDFRATE = New System.Windows.Forms.TextBox
        Me.lblDFRATE = New System.Windows.Forms.Label
        Me.txtBALDEFOVD = New System.Windows.Forms.TextBox
        Me.lblBALDEFOVD = New System.Windows.Forms.Label
        Me.txtMATVAL = New System.Windows.Forms.TextBox
        Me.lblBALADDOPT = New System.Windows.Forms.Label
        Me.txtBALADDOPT = New System.Windows.Forms.TextBox
        Me.chkAUTODRAWNDOWN = New System.Windows.Forms.CheckBox
        Me.chkisapprove = New System.Windows.Forms.CheckBox
        Me.LBLAFACCTNODRD = New System.Windows.Forms.Label
        Me.txtOLDDFRATE = New System.Windows.Forms.TextBox
        Me.lblOLDDFRATE = New System.Windows.Forms.Label
        Me.txtOLDACTYPE = New System.Windows.Forms.TextBox
        Me.lblOLDACTYPE = New System.Windows.Forms.Label
        Me.chkOPTIONSTOCK = New System.Windows.Forms.CheckBox
        Me.txtNETBALANCE = New System.Windows.Forms.TextBox
        Me.lblNETBALANCE = New System.Windows.Forms.Label
        Me.txtREMAINBAL = New System.Windows.Forms.TextBox
        Me.lblREMAINBAL = New System.Windows.Forms.Label
        Me.txtREMAINADVLINE = New System.Windows.Forms.TextBox
        Me.lblREMAINADVLINE = New System.Windows.Forms.Label
        Me.lblOLDDFQTTY = New System.Windows.Forms.Label
        Me.btnGetDeal = New System.Windows.Forms.Button
        Me.txtREF = New System.Windows.Forms.TextBox
        Me.lblREF = New System.Windows.Forms.Label
        Me.txtOLDDFQTTY = New System.Windows.Forms.TextBox
        Me.dtpREFTXDATE = New System.Windows.Forms.DateTimePicker
        Me.lblREFTXDATE = New System.Windows.Forms.Label
        Me.txtREFTXNUM = New System.Windows.Forms.TextBox
        Me.lblREFTXNUM = New System.Windows.Forms.Label
        Me.cboAFACCTNODRD = New AppCore.ComboBoxEx
        Me.txtOLDDEALNO = New System.Windows.Forms.TextBox
        Me.lblOLDDEALNO = New System.Windows.Forms.Label
        Me.chkENDNEWDEAL = New System.Windows.Forms.CheckBox
        Me.btnAdd = New System.Windows.Forms.Button
        Me.pnContractInfo = New System.Windows.Forms.Panel
        Me.pnlMember = New System.Windows.Forms.Panel
        Me.picSignature = New System.Windows.Forms.PictureBox
        Me.VScrollBarSign = New System.Windows.Forms.VScrollBar
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCANCEL = New System.Windows.Forms.Button
        Me.pnBalance = New System.Windows.Forms.Panel
        Me.pnSEInfo = New System.Windows.Forms.Panel
        Me.lblMortage = New System.Windows.Forms.Label
        Me.lblSEBalance = New System.Windows.Forms.Label
        Me.lblSE = New System.Windows.Forms.Label
        Me.lblAAMT = New System.Windows.Forms.Label
        Me.lblPPSE = New System.Windows.Forms.Label
        Me.lblPurchasingPower = New System.Windows.Forms.Label
        Me.lblTotal = New System.Windows.Forms.Label
        Me.lblTotalAmout = New System.Windows.Forms.Label
        Me.lblCIAdvance = New System.Windows.Forms.Label
        Me.lblCI = New System.Windows.Forms.Label
        Me.lblCIBalance = New System.Windows.Forms.Label
        Me.cboPriceTime = New AppCore.ComboBoxEx
        Me.tmrOrder = New System.Windows.Forms.Timer(Me.components)
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.btnApprove = New System.Windows.Forms.Button
        Me.btnAdjust = New System.Windows.Forms.Button
        Me.pnDFGR = New System.Windows.Forms.Panel
        Me.btnDEL = New System.Windows.Forms.Button
        Me.btnReject = New System.Windows.Forms.Button
        Me.pnlTitle.SuspendLayout()
        Me.pnOrder.SuspendLayout()
        Me.pnUpcomInfo.SuspendLayout()
        Me.pnMainInfo.SuspendLayout()
        Me.pnContractInfo.SuspendLayout()
        CType(Me.picSignature, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnBalance.SuspendLayout()
        Me.pnSEInfo.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlTitle
        '
        Me.pnlTitle.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlTitle.Controls.Add(Me.cboAFACCCBO)
        Me.pnlTitle.Controls.Add(Me.lblAFACCCBO)
        Me.pnlTitle.Controls.Add(Me.mskCUSTODYCD)
        Me.pnlTitle.Controls.Add(Me.lblCUSTODYCD)
        Me.pnlTitle.Controls.Add(Me.lblAFINFO)
        Me.pnlTitle.Controls.Add(Me.lblAFNAME)
        Me.pnlTitle.Controls.Add(Me.mskAFACCTNO)
        Me.pnlTitle.Controls.Add(Me.lblAFACCTNO)
        Me.pnlTitle.Controls.Add(Me.chkDetail)
        Me.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTitle.Location = New System.Drawing.Point(0, 0)
        Me.pnlTitle.Name = "pnlTitle"
        Me.pnlTitle.Size = New System.Drawing.Size(712, 68)
        Me.pnlTitle.TabIndex = 0
        '
        'cboAFACCCBO
        '
        Me.cboAFACCCBO.DisplayMember = "DISPLAY"
        Me.cboAFACCCBO.FormattingEnabled = True
        Me.cboAFACCCBO.Location = New System.Drawing.Point(243, 11)
        Me.cboAFACCCBO.Name = "cboAFACCCBO"
        Me.cboAFACCCBO.Size = New System.Drawing.Size(366, 21)
        Me.cboAFACCCBO.TabIndex = 3
        Me.cboAFACCCBO.Tag = "89"
        Me.cboAFACCCBO.ValueMember = "VALUE"
        '
        'lblAFACCCBO
        '
        Me.lblAFACCCBO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAFACCCBO.Location = New System.Drawing.Point(172, 14)
        Me.lblAFACCCBO.Name = "lblAFACCCBO"
        Me.lblAFACCCBO.Size = New System.Drawing.Size(74, 20)
        Me.lblAFACCCBO.TabIndex = 2
        Me.lblAFACCCBO.Tag = "AFACCCBO"
        Me.lblAFACCCBO.Text = "lblAFACCCBO"
        '
        'mskCUSTODYCD
        '
        Me.mskCUSTODYCD.Location = New System.Drawing.Point(77, 12)
        Me.mskCUSTODYCD.Name = "mskCUSTODYCD"
        Me.mskCUSTODYCD.Size = New System.Drawing.Size(80, 20)
        Me.mskCUSTODYCD.TabIndex = 1
        Me.mskCUSTODYCD.Tag = "88"
        Me.mskCUSTODYCD.Text = "mskCUSTODYCD"
        '
        'lblCUSTODYCD
        '
        Me.lblCUSTODYCD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCUSTODYCD.Location = New System.Drawing.Point(5, 13)
        Me.lblCUSTODYCD.Name = "lblCUSTODYCD"
        Me.lblCUSTODYCD.Size = New System.Drawing.Size(88, 20)
        Me.lblCUSTODYCD.TabIndex = 0
        Me.lblCUSTODYCD.Tag = "CUSTODYCD"
        Me.lblCUSTODYCD.Text = "lblCUSTODYCD"
        '
        'lblAFINFO
        '
        Me.lblAFINFO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAFINFO.ForeColor = System.Drawing.Color.Black
        Me.lblAFINFO.Location = New System.Drawing.Point(8, 39)
        Me.lblAFINFO.Name = "lblAFINFO"
        Me.lblAFINFO.Size = New System.Drawing.Size(703, 20)
        Me.lblAFINFO.TabIndex = 6
        Me.lblAFINFO.Text = "lblAFINFO"
        Me.lblAFINFO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblAFNAME
        '
        Me.lblAFNAME.Location = New System.Drawing.Point(232, 37)
        Me.lblAFNAME.Name = "lblAFNAME"
        Me.lblAFNAME.Size = New System.Drawing.Size(216, 23)
        Me.lblAFNAME.TabIndex = 7
        Me.lblAFNAME.Text = "lblAFNAME"
        '
        'mskAFACCTNO
        '
        Me.mskAFACCTNO.ForeColor = System.Drawing.SystemColors.WindowText
        Me.mskAFACCTNO.Location = New System.Drawing.Point(635, 11)
        Me.mskAFACCTNO.Name = "mskAFACCTNO"
        Me.mskAFACCTNO.Size = New System.Drawing.Size(80, 20)
        Me.mskAFACCTNO.TabIndex = 5
        Me.mskAFACCTNO.Tag = "03"
        Me.mskAFACCTNO.Text = "mskAFACCTNO"
        Me.mskAFACCTNO.Visible = False
        '
        'lblAFACCTNO
        '
        Me.lblAFACCTNO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAFACCTNO.Location = New System.Drawing.Point(574, 11)
        Me.lblAFACCTNO.Name = "lblAFACCTNO"
        Me.lblAFACCTNO.Size = New System.Drawing.Size(55, 20)
        Me.lblAFACCTNO.TabIndex = 4
        Me.lblAFACCTNO.Tag = "AFACCTNO"
        Me.lblAFACCTNO.Text = "lblAFACCTNO"
        Me.lblAFACCTNO.Visible = False
        '
        'chkDetail
        '
        Me.chkDetail.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkDetail.Checked = True
        Me.chkDetail.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDetail.Location = New System.Drawing.Point(448, 37)
        Me.chkDetail.Name = "chkDetail"
        Me.chkDetail.Size = New System.Drawing.Size(48, 21)
        Me.chkDetail.TabIndex = 8
        Me.chkDetail.Text = ">>"
        Me.chkDetail.Visible = False
        '
        'pnOrder
        '
        Me.pnOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnOrder.Controls.Add(Me.pnUpcomInfo)
        Me.pnOrder.Controls.Add(Me.pnMainInfo)
        Me.pnOrder.Location = New System.Drawing.Point(2, 72)
        Me.pnOrder.Name = "pnOrder"
        Me.pnOrder.Size = New System.Drawing.Size(707, 210)
        Me.pnOrder.TabIndex = 1
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
        Me.pnUpcomInfo.Location = New System.Drawing.Point(0, 267)
        Me.pnUpcomInfo.Name = "pnUpcomInfo"
        Me.pnUpcomInfo.Size = New System.Drawing.Size(616, 72)
        Me.pnUpcomInfo.TabIndex = 2
        '
        'lblContraFirm
        '
        Me.lblContraFirm.Location = New System.Drawing.Point(248, 8)
        Me.lblContraFirm.Name = "lblContraFirm"
        Me.lblContraFirm.Size = New System.Drawing.Size(88, 23)
        Me.lblContraFirm.TabIndex = 0
        Me.lblContraFirm.Text = "lblContraFirm"
        '
        'txtContraFirm
        '
        Me.txtContraFirm.Location = New System.Drawing.Point(337, 9)
        Me.txtContraFirm.Name = "txtContraFirm"
        Me.txtContraFirm.Size = New System.Drawing.Size(100, 20)
        Me.txtContraFirm.TabIndex = 1
        Me.txtContraFirm.Text = "txtContraFirm"
        '
        'lblContraCusInfo
        '
        Me.lblContraCusInfo.Location = New System.Drawing.Point(248, 36)
        Me.lblContraCusInfo.Name = "lblContraCusInfo"
        Me.lblContraCusInfo.Size = New System.Drawing.Size(360, 23)
        Me.lblContraCusInfo.TabIndex = 2
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
        Me.pnMainInfo.Controls.Add(Me.txtFeeAmt)
        Me.pnMainInfo.Controls.Add(Me.lblFeeAmt)
        Me.pnMainInfo.Controls.Add(Me.txtRefSide)
        Me.pnMainInfo.Controls.Add(Me.lblRefSide)
        Me.pnMainInfo.Controls.Add(Me.txtFeeRate)
        Me.pnMainInfo.Controls.Add(Me.lblFeeRate)
        Me.pnMainInfo.Controls.Add(Me.lblDFFeemap)
        Me.pnMainInfo.Controls.Add(Me.mskDFFeeMap)
        Me.pnMainInfo.Controls.Add(Me.txtDFLRATE)
        Me.pnMainInfo.Controls.Add(Me.Label1)
        Me.pnMainInfo.Controls.Add(Me.txtDFMRATE)
        Me.pnMainInfo.Controls.Add(Me.cboRefPrice)
        Me.pnMainInfo.Controls.Add(Me.txtDFIRATE)
        Me.pnMainInfo.Controls.Add(Me.lblRefPrice)
        Me.pnMainInfo.Controls.Add(Me.txtTOLAMT)
        Me.pnMainInfo.Controls.Add(Me.lblTOLAMT)
        Me.pnMainInfo.Controls.Add(Me.txtDFAMT)
        Me.pnMainInfo.Controls.Add(Me.lblDFAMT)
        Me.pnMainInfo.Controls.Add(Me.lblMATVAL)
        Me.pnMainInfo.Controls.Add(Me.txtQuantity)
        Me.pnMainInfo.Controls.Add(Me.lblQuantity)
        Me.pnMainInfo.Controls.Add(Me.txtRefPrice)
        Me.pnMainInfo.Controls.Add(Me.mskACTYPE)
        Me.pnMainInfo.Controls.Add(Me.txtLRATE)
        Me.pnMainInfo.Controls.Add(Me.lblLRATE)
        Me.pnMainInfo.Controls.Add(Me.txtDescription)
        Me.pnMainInfo.Controls.Add(Me.lblDescription)
        Me.pnMainInfo.Controls.Add(Me.txtMRATE)
        Me.pnMainInfo.Controls.Add(Me.lblMRATE)
        Me.pnMainInfo.Controls.Add(Me.txtIRATE)
        Me.pnMainInfo.Controls.Add(Me.lblIRATE)
        Me.pnMainInfo.Controls.Add(Me.txtTRIGPRICE)
        Me.pnMainInfo.Controls.Add(Me.lblTRIGPRICE)
        Me.pnMainInfo.Controls.Add(Me.lblDFPrice)
        Me.pnMainInfo.Controls.Add(Me.lblAcType)
        Me.pnMainInfo.Controls.Add(Me.lblSymbol)
        Me.pnMainInfo.Controls.Add(Me.cboCODEID)
        Me.pnMainInfo.Controls.Add(Me.txtDFPrice)
        Me.pnMainInfo.Controls.Add(Me.txtDFRATE)
        Me.pnMainInfo.Controls.Add(Me.lblDFRATE)
        Me.pnMainInfo.Controls.Add(Me.txtBALDEFOVD)
        Me.pnMainInfo.Controls.Add(Me.lblBALDEFOVD)
        Me.pnMainInfo.Controls.Add(Me.txtMATVAL)
        Me.pnMainInfo.Controls.Add(Me.lblBALADDOPT)
        Me.pnMainInfo.Controls.Add(Me.txtBALADDOPT)
        Me.pnMainInfo.Controls.Add(Me.chkAUTODRAWNDOWN)
        Me.pnMainInfo.Controls.Add(Me.chkisapprove)
        Me.pnMainInfo.Controls.Add(Me.LBLAFACCTNODRD)
        Me.pnMainInfo.Controls.Add(Me.txtOLDDFRATE)
        Me.pnMainInfo.Controls.Add(Me.lblOLDDFRATE)
        Me.pnMainInfo.Controls.Add(Me.txtOLDACTYPE)
        Me.pnMainInfo.Controls.Add(Me.lblOLDACTYPE)
        Me.pnMainInfo.Controls.Add(Me.chkOPTIONSTOCK)
        Me.pnMainInfo.Controls.Add(Me.txtNETBALANCE)
        Me.pnMainInfo.Controls.Add(Me.lblNETBALANCE)
        Me.pnMainInfo.Controls.Add(Me.txtREMAINBAL)
        Me.pnMainInfo.Controls.Add(Me.lblREMAINBAL)
        Me.pnMainInfo.Controls.Add(Me.txtREMAINADVLINE)
        Me.pnMainInfo.Controls.Add(Me.lblREMAINADVLINE)
        Me.pnMainInfo.Controls.Add(Me.lblOLDDFQTTY)
        Me.pnMainInfo.Controls.Add(Me.btnGetDeal)
        Me.pnMainInfo.Controls.Add(Me.txtREF)
        Me.pnMainInfo.Controls.Add(Me.lblREF)
        Me.pnMainInfo.Controls.Add(Me.txtOLDDFQTTY)
        Me.pnMainInfo.Controls.Add(Me.dtpREFTXDATE)
        Me.pnMainInfo.Controls.Add(Me.lblREFTXDATE)
        Me.pnMainInfo.Controls.Add(Me.txtREFTXNUM)
        Me.pnMainInfo.Controls.Add(Me.lblREFTXNUM)
        Me.pnMainInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnMainInfo.Location = New System.Drawing.Point(1, 1)
        Me.pnMainInfo.Name = "pnMainInfo"
        Me.pnMainInfo.Size = New System.Drawing.Size(703, 204)
        Me.pnMainInfo.TabIndex = 0
        '
        'txtFeeAmt
        '
        Me.txtFeeAmt.Enabled = False
        Me.txtFeeAmt.Location = New System.Drawing.Point(448, 141)
        Me.txtFeeAmt.Name = "txtFeeAmt"
        Me.txtFeeAmt.Size = New System.Drawing.Size(90, 20)
        Me.txtFeeAmt.TabIndex = 67
        '
        'lblFeeAmt
        '
        Me.lblFeeAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFeeAmt.Location = New System.Drawing.Point(368, 141)
        Me.lblFeeAmt.Name = "lblFeeAmt"
        Me.lblFeeAmt.Size = New System.Drawing.Size(102, 20)
        Me.lblFeeAmt.TabIndex = 66
        Me.lblFeeAmt.Tag = "lblFeeAmt"
        Me.lblFeeAmt.Text = "lblFeeAmt"
        '
        'txtRefSide
        '
        Me.txtRefSide.Location = New System.Drawing.Point(282, 8)
        Me.txtRefSide.Name = "txtRefSide"
        Me.txtRefSide.Size = New System.Drawing.Size(80, 20)
        Me.txtRefSide.TabIndex = 67
        '
        'lblRefSide
        '
        Me.lblRefSide.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRefSide.Location = New System.Drawing.Point(188, 11)
        Me.lblRefSide.Name = "lblRefSide"
        Me.lblRefSide.Size = New System.Drawing.Size(88, 20)
        Me.lblRefSide.TabIndex = 66
        Me.lblRefSide.Tag = "lblRefSide"
        Me.lblRefSide.Text = "lblRefSide"
        '
        'txtFeeRate
        '
        Me.txtFeeRate.Enabled = False
        Me.txtFeeRate.Location = New System.Drawing.Point(448, 115)
        Me.txtFeeRate.Name = "txtFeeRate"
        Me.txtFeeRate.Size = New System.Drawing.Size(90, 20)
        Me.txtFeeRate.TabIndex = 67
        '
        'lblFeeRate
        '
        Me.lblFeeRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFeeRate.Location = New System.Drawing.Point(368, 115)
        Me.lblFeeRate.Name = "lblFeeRate"
        Me.lblFeeRate.Size = New System.Drawing.Size(102, 20)
        Me.lblFeeRate.TabIndex = 66
        Me.lblFeeRate.Tag = "lblFeeRate"
        Me.lblFeeRate.Text = "lblFeeRate"
        '
        'lblDFFeemap
        '
        Me.lblDFFeemap.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDFFeemap.Location = New System.Drawing.Point(368, 12)
        Me.lblDFFeemap.Name = "lblDFFeemap"
        Me.lblDFFeemap.Size = New System.Drawing.Size(78, 21)
        Me.lblDFFeemap.TabIndex = 66
        Me.lblDFFeemap.Tag = "lblDFFeemap"
        Me.lblDFFeemap.Text = "lblDFFeemap"
        '
        'mskDFFeeMap
        '
        Me.mskDFFeeMap.Location = New System.Drawing.Point(448, 11)
        Me.mskDFFeeMap.Name = "mskDFFeeMap"
        Me.mskDFFeeMap.Size = New System.Drawing.Size(90, 20)
        Me.mskDFFeeMap.TabIndex = 65
        '
        'txtDFLRATE
        '
        Me.txtDFLRATE.Enabled = False
        Me.txtDFLRATE.Location = New System.Drawing.Point(448, 91)
        Me.txtDFLRATE.Name = "txtDFLRATE"
        Me.txtDFLRATE.Size = New System.Drawing.Size(90, 20)
        Me.txtDFLRATE.TabIndex = 60
        Me.txtDFLRATE.Tag = "txtDFLRATE"
        Me.txtDFLRATE.Text = "txtDFLRATE"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Orchid
        Me.Label1.Location = New System.Drawing.Point(551, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(140, 196)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Label1"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDFMRATE
        '
        Me.txtDFMRATE.Enabled = False
        Me.txtDFMRATE.Location = New System.Drawing.Point(282, 91)
        Me.txtDFMRATE.Name = "txtDFMRATE"
        Me.txtDFMRATE.Size = New System.Drawing.Size(80, 20)
        Me.txtDFMRATE.TabIndex = 58
        Me.txtDFMRATE.Tag = "txtDFMRATE"
        Me.txtDFMRATE.Text = "txtDFMRATE"
        '
        'cboRefPrice
        '
        Me.cboRefPrice.DisplayMember = "DISPLAY"
        Me.cboRefPrice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRefPrice.FormattingEnabled = True
        Me.cboRefPrice.Location = New System.Drawing.Point(448, 37)
        Me.cboRefPrice.Name = "cboRefPrice"
        Me.cboRefPrice.Size = New System.Drawing.Size(90, 21)
        Me.cboRefPrice.TabIndex = 22
        Me.cboRefPrice.ValueMember = "VALUE"
        '
        'txtDFIRATE
        '
        Me.txtDFIRATE.Enabled = False
        Me.txtDFIRATE.Location = New System.Drawing.Point(102, 91)
        Me.txtDFIRATE.Name = "txtDFIRATE"
        Me.txtDFIRATE.Size = New System.Drawing.Size(80, 20)
        Me.txtDFIRATE.TabIndex = 56
        Me.txtDFIRATE.Tag = "txtDFIRATE"
        Me.txtDFIRATE.Text = "txtDFIRATE"
        '
        'lblRefPrice
        '
        Me.lblRefPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRefPrice.Location = New System.Drawing.Point(368, 37)
        Me.lblRefPrice.Name = "lblRefPrice"
        Me.lblRefPrice.Size = New System.Drawing.Size(78, 21)
        Me.lblRefPrice.TabIndex = 21
        Me.lblRefPrice.Tag = "REFPRICE"
        Me.lblRefPrice.Text = "lblRefPrice"
        '
        'txtTOLAMT
        '
        Me.txtTOLAMT.Enabled = False
        Me.txtTOLAMT.Location = New System.Drawing.Point(102, 141)
        Me.txtTOLAMT.Name = "txtTOLAMT"
        Me.txtTOLAMT.ReadOnly = True
        Me.txtTOLAMT.Size = New System.Drawing.Size(179, 20)
        Me.txtTOLAMT.TabIndex = 53
        Me.txtTOLAMT.Tag = "DFAMT"
        Me.txtTOLAMT.Text = "0"
        '
        'lblTOLAMT
        '
        Me.lblTOLAMT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTOLAMT.Location = New System.Drawing.Point(5, 141)
        Me.lblTOLAMT.Name = "lblTOLAMT"
        Me.lblTOLAMT.Size = New System.Drawing.Size(75, 20)
        Me.lblTOLAMT.TabIndex = 52
        Me.lblTOLAMT.Tag = "TOLAMT"
        Me.lblTOLAMT.Text = "lblTOLAMT"
        '
        'txtDFAMT
        '
        Me.txtDFAMT.Enabled = False
        Me.txtDFAMT.Location = New System.Drawing.Point(102, 116)
        Me.txtDFAMT.Name = "txtDFAMT"
        Me.txtDFAMT.ReadOnly = True
        Me.txtDFAMT.Size = New System.Drawing.Size(179, 20)
        Me.txtDFAMT.TabIndex = 39
        Me.txtDFAMT.Tag = "DFAMT"
        Me.txtDFAMT.Text = "0"
        '
        'lblDFAMT
        '
        Me.lblDFAMT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDFAMT.Location = New System.Drawing.Point(5, 116)
        Me.lblDFAMT.Name = "lblDFAMT"
        Me.lblDFAMT.Size = New System.Drawing.Size(75, 20)
        Me.lblDFAMT.TabIndex = 38
        Me.lblDFAMT.Tag = "DFAMT"
        Me.lblDFAMT.Text = "lblDFAMT"
        '
        'lblMATVAL
        '
        Me.lblMATVAL.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMATVAL.Location = New System.Drawing.Point(5, 116)
        Me.lblMATVAL.Name = "lblMATVAL"
        Me.lblMATVAL.Size = New System.Drawing.Size(211, 20)
        Me.lblMATVAL.TabIndex = 36
        Me.lblMATVAL.Tag = "MATVAL"
        Me.lblMATVAL.Text = "lblMATVAL"
        Me.lblMATVAL.Visible = False
        '
        'txtQuantity
        '
        Me.txtQuantity.Location = New System.Drawing.Point(282, 37)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(80, 20)
        Me.txtQuantity.TabIndex = 20
        Me.txtQuantity.Tag = "txtQuantity"
        Me.txtQuantity.Text = "txtQuantity"
        '
        'lblQuantity
        '
        Me.lblQuantity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQuantity.Location = New System.Drawing.Point(188, 37)
        Me.lblQuantity.Name = "lblQuantity"
        Me.lblQuantity.Size = New System.Drawing.Size(88, 20)
        Me.lblQuantity.TabIndex = 19
        Me.lblQuantity.Tag = "lblQuantity"
        Me.lblQuantity.Text = "lblQuantity"
        '
        'txtRefPrice
        '
        Me.txtRefPrice.Location = New System.Drawing.Point(409, 39)
        Me.txtRefPrice.Name = "txtRefPrice"
        Me.txtRefPrice.Size = New System.Drawing.Size(80, 20)
        Me.txtRefPrice.TabIndex = 7
        Me.txtRefPrice.Tag = "txtRefPrice"
        Me.txtRefPrice.Text = "txtRefPrice"
        Me.txtRefPrice.Visible = False
        '
        'mskACTYPE
        '
        Me.mskACTYPE.Location = New System.Drawing.Point(102, 11)
        Me.mskACTYPE.Name = "mskACTYPE"
        Me.mskACTYPE.Size = New System.Drawing.Size(80, 20)
        Me.mskACTYPE.TabIndex = 12
        Me.mskACTYPE.Tag = "mskACTYPE"
        Me.mskACTYPE.Text = "mskACTYPE"
        '
        'txtLRATE
        '
        Me.txtLRATE.Enabled = False
        Me.txtLRATE.Location = New System.Drawing.Point(448, 91)
        Me.txtLRATE.Name = "txtLRATE"
        Me.txtLRATE.Size = New System.Drawing.Size(90, 20)
        Me.txtLRATE.TabIndex = 35
        Me.txtLRATE.Tag = "txtLRATE"
        Me.txtLRATE.Text = "txtLRATE"
        '
        'lblLRATE
        '
        Me.lblLRATE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLRATE.Location = New System.Drawing.Point(368, 92)
        Me.lblLRATE.Name = "lblLRATE"
        Me.lblLRATE.Size = New System.Drawing.Size(102, 20)
        Me.lblLRATE.TabIndex = 34
        Me.lblLRATE.Tag = "LRATE"
        Me.lblLRATE.Text = "lblLRATE"
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(102, 175)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(436, 20)
        Me.txtDescription.TabIndex = 41
        Me.txtDescription.Tag = "txtDescription"
        Me.txtDescription.Text = "txtDescription"
        '
        'lblDescription
        '
        Me.lblDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescription.Location = New System.Drawing.Point(5, 175)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(88, 20)
        Me.lblDescription.TabIndex = 40
        Me.lblDescription.Tag = "DESCRIPTION"
        Me.lblDescription.Text = "lblDescription"
        '
        'txtMRATE
        '
        Me.txtMRATE.Enabled = False
        Me.txtMRATE.Location = New System.Drawing.Point(282, 91)
        Me.txtMRATE.Name = "txtMRATE"
        Me.txtMRATE.Size = New System.Drawing.Size(80, 20)
        Me.txtMRATE.TabIndex = 33
        Me.txtMRATE.Tag = "txtMRATE"
        Me.txtMRATE.Text = "txtMRATE"
        '
        'lblMRATE
        '
        Me.lblMRATE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMRATE.Location = New System.Drawing.Point(188, 92)
        Me.lblMRATE.Name = "lblMRATE"
        Me.lblMRATE.Size = New System.Drawing.Size(88, 20)
        Me.lblMRATE.TabIndex = 32
        Me.lblMRATE.Tag = "MRATE"
        Me.lblMRATE.Text = "lblMRATE"
        '
        'txtIRATE
        '
        Me.txtIRATE.Enabled = False
        Me.txtIRATE.Location = New System.Drawing.Point(102, 91)
        Me.txtIRATE.Name = "txtIRATE"
        Me.txtIRATE.Size = New System.Drawing.Size(80, 20)
        Me.txtIRATE.TabIndex = 31
        Me.txtIRATE.Text = "txtIRATE"
        '
        'lblIRATE
        '
        Me.lblIRATE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIRATE.Location = New System.Drawing.Point(5, 92)
        Me.lblIRATE.Name = "lblIRATE"
        Me.lblIRATE.Size = New System.Drawing.Size(88, 20)
        Me.lblIRATE.TabIndex = 30
        Me.lblIRATE.Tag = "IRATE"
        Me.lblIRATE.Text = "lblIRATE"
        '
        'txtTRIGPRICE
        '
        Me.txtTRIGPRICE.Location = New System.Drawing.Point(448, 66)
        Me.txtTRIGPRICE.Name = "txtTRIGPRICE"
        Me.txtTRIGPRICE.Size = New System.Drawing.Size(90, 20)
        Me.txtTRIGPRICE.TabIndex = 29
        Me.txtTRIGPRICE.Text = "txtTRIGPRICE"
        '
        'lblTRIGPRICE
        '
        Me.lblTRIGPRICE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTRIGPRICE.Location = New System.Drawing.Point(368, 66)
        Me.lblTRIGPRICE.Name = "lblTRIGPRICE"
        Me.lblTRIGPRICE.Size = New System.Drawing.Size(102, 20)
        Me.lblTRIGPRICE.TabIndex = 28
        Me.lblTRIGPRICE.Tag = "TRIGPRICE"
        Me.lblTRIGPRICE.Text = "lblTRIGPRICE"
        '
        'lblDFPrice
        '
        Me.lblDFPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDFPrice.Location = New System.Drawing.Point(188, 66)
        Me.lblDFPrice.Name = "lblDFPrice"
        Me.lblDFPrice.Size = New System.Drawing.Size(88, 20)
        Me.lblDFPrice.TabIndex = 26
        Me.lblDFPrice.Tag = "DFPRICE"
        Me.lblDFPrice.Text = "lblDFPrice"
        '
        'lblAcType
        '
        Me.lblAcType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAcType.Location = New System.Drawing.Point(5, 11)
        Me.lblAcType.Name = "lblAcType"
        Me.lblAcType.Size = New System.Drawing.Size(94, 20)
        Me.lblAcType.TabIndex = 11
        Me.lblAcType.Tag = "ACTYPE"
        Me.lblAcType.Text = "lblAcType"
        '
        'lblSymbol
        '
        Me.lblSymbol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSymbol.Location = New System.Drawing.Point(5, 37)
        Me.lblSymbol.Name = "lblSymbol"
        Me.lblSymbol.Size = New System.Drawing.Size(88, 20)
        Me.lblSymbol.TabIndex = 17
        Me.lblSymbol.Tag = "SYMBOL"
        Me.lblSymbol.Text = "lblSymbol"
        '
        'cboCODEID
        '
        Me.cboCODEID.DisplayMember = "DISPLAY"
        Me.cboCODEID.Enabled = False
        Me.cboCODEID.ItemHeight = 13
        Me.cboCODEID.Location = New System.Drawing.Point(102, 37)
        Me.cboCODEID.MaxLength = 10
        Me.cboCODEID.Name = "cboCODEID"
        Me.cboCODEID.Size = New System.Drawing.Size(80, 21)
        Me.cboCODEID.TabIndex = 18
        Me.cboCODEID.Tag = "01"
        Me.cboCODEID.ValueMember = "VALUE"
        '
        'txtDFPrice
        '
        Me.txtDFPrice.Location = New System.Drawing.Point(282, 66)
        Me.txtDFPrice.Name = "txtDFPrice"
        Me.txtDFPrice.Size = New System.Drawing.Size(80, 20)
        Me.txtDFPrice.TabIndex = 27
        Me.txtDFPrice.Text = "txtDFPrice"
        '
        'txtDFRATE
        '
        Me.txtDFRATE.Enabled = False
        Me.txtDFRATE.Location = New System.Drawing.Point(102, 66)
        Me.txtDFRATE.Name = "txtDFRATE"
        Me.txtDFRATE.Size = New System.Drawing.Size(80, 20)
        Me.txtDFRATE.TabIndex = 25
        Me.txtDFRATE.Text = "txtDFRATE"
        '
        'lblDFRATE
        '
        Me.lblDFRATE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDFRATE.Location = New System.Drawing.Point(5, 66)
        Me.lblDFRATE.Name = "lblDFRATE"
        Me.lblDFRATE.Size = New System.Drawing.Size(88, 20)
        Me.lblDFRATE.TabIndex = 24
        Me.lblDFRATE.Tag = "DFRATE"
        Me.lblDFRATE.Text = "lblDFRATE"
        '
        'txtBALDEFOVD
        '
        Me.txtBALDEFOVD.Enabled = False
        Me.txtBALDEFOVD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBALDEFOVD.ForeColor = System.Drawing.Color.DarkViolet
        Me.txtBALDEFOVD.Location = New System.Drawing.Point(100, 116)
        Me.txtBALDEFOVD.Name = "txtBALDEFOVD"
        Me.txtBALDEFOVD.ReadOnly = True
        Me.txtBALDEFOVD.Size = New System.Drawing.Size(80, 20)
        Me.txtBALDEFOVD.TabIndex = 48
        Me.txtBALDEFOVD.Tag = "BALDEFOVD"
        Me.txtBALDEFOVD.Text = "txtBALDEFOVD"
        Me.txtBALDEFOVD.Visible = False
        '
        'lblBALDEFOVD
        '
        Me.lblBALDEFOVD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBALDEFOVD.ForeColor = System.Drawing.Color.DarkViolet
        Me.lblBALDEFOVD.Location = New System.Drawing.Point(6, 116)
        Me.lblBALDEFOVD.Name = "lblBALDEFOVD"
        Me.lblBALDEFOVD.Size = New System.Drawing.Size(88, 20)
        Me.lblBALDEFOVD.TabIndex = 47
        Me.lblBALDEFOVD.Tag = "BALDEFOVD"
        Me.lblBALDEFOVD.Text = "lblBALDEFOVD"
        Me.lblBALDEFOVD.Visible = False
        '
        'txtMATVAL
        '
        Me.txtMATVAL.Location = New System.Drawing.Point(551, 138)
        Me.txtMATVAL.Name = "txtMATVAL"
        Me.txtMATVAL.ReadOnly = True
        Me.txtMATVAL.Size = New System.Drawing.Size(140, 20)
        Me.txtMATVAL.TabIndex = 37
        Me.txtMATVAL.Tag = "txtMATVAL"
        Me.txtMATVAL.Text = "txtMATVAL"
        Me.txtMATVAL.Visible = False
        '
        'lblBALADDOPT
        '
        Me.lblBALADDOPT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBALADDOPT.ForeColor = System.Drawing.Color.DarkViolet
        Me.lblBALADDOPT.Location = New System.Drawing.Point(548, 138)
        Me.lblBALADDOPT.Name = "lblBALADDOPT"
        Me.lblBALADDOPT.Size = New System.Drawing.Size(88, 20)
        Me.lblBALADDOPT.TabIndex = 49
        Me.lblBALADDOPT.Tag = "BALADDOPT"
        Me.lblBALADDOPT.Text = "lblBALADDOPT"
        Me.lblBALADDOPT.Visible = False
        '
        'txtBALADDOPT
        '
        Me.txtBALADDOPT.Enabled = False
        Me.txtBALADDOPT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBALADDOPT.ForeColor = System.Drawing.Color.DarkViolet
        Me.txtBALADDOPT.Location = New System.Drawing.Point(551, 138)
        Me.txtBALADDOPT.Name = "txtBALADDOPT"
        Me.txtBALADDOPT.ReadOnly = True
        Me.txtBALADDOPT.Size = New System.Drawing.Size(80, 20)
        Me.txtBALADDOPT.TabIndex = 50
        Me.txtBALADDOPT.Tag = "BALADDOPT"
        Me.txtBALADDOPT.Text = "txtBALADDOPT"
        Me.txtBALADDOPT.Visible = False
        '
        'chkAUTODRAWNDOWN
        '
        Me.chkAUTODRAWNDOWN.AutoSize = True
        Me.chkAUTODRAWNDOWN.Location = New System.Drawing.Point(551, 140)
        Me.chkAUTODRAWNDOWN.Name = "chkAUTODRAWNDOWN"
        Me.chkAUTODRAWNDOWN.Size = New System.Drawing.Size(130, 17)
        Me.chkAUTODRAWNDOWN.TabIndex = 16
        Me.chkAUTODRAWNDOWN.Tag = "chkAUTODRAWNDOWN"
        Me.chkAUTODRAWNDOWN.Text = "Tự động giải ngân"
        Me.chkAUTODRAWNDOWN.UseVisualStyleBackColor = True
        Me.chkAUTODRAWNDOWN.Visible = False
        '
        'chkisapprove
        '
        Me.chkisapprove.AutoSize = True
        Me.chkisapprove.Location = New System.Drawing.Point(551, 141)
        Me.chkisapprove.Name = "chkisapprove"
        Me.chkisapprove.Size = New System.Drawing.Size(147, 17)
        Me.chkisapprove.TabIndex = 51
        Me.chkisapprove.Tag = "chkisapprove"
        Me.chkisapprove.Text = "Có cần duyệt không?"
        Me.chkisapprove.UseVisualStyleBackColor = True
        Me.chkisapprove.Visible = False
        '
        'LBLAFACCTNODRD
        '
        Me.LBLAFACCTNODRD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLAFACCTNODRD.Location = New System.Drawing.Point(5, 4)
        Me.LBLAFACCTNODRD.Name = "LBLAFACCTNODRD"
        Me.LBLAFACCTNODRD.Size = New System.Drawing.Size(135, 20)
        Me.LBLAFACCTNODRD.TabIndex = 43
        Me.LBLAFACCTNODRD.Tag = "AFACCTNODRD"
        Me.LBLAFACCTNODRD.Text = "LBLAFACCTNODRD"
        Me.LBLAFACCTNODRD.Visible = False
        '
        'txtOLDDFRATE
        '
        Me.txtOLDDFRATE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOLDDFRATE.ForeColor = System.Drawing.Color.Firebrick
        Me.txtOLDDFRATE.Location = New System.Drawing.Point(418, 58)
        Me.txtOLDDFRATE.Name = "txtOLDDFRATE"
        Me.txtOLDDFRATE.ReadOnly = True
        Me.txtOLDDFRATE.Size = New System.Drawing.Size(71, 20)
        Me.txtOLDDFRATE.TabIndex = 46
        Me.txtOLDDFRATE.Tag = "OLDDFRATE"
        Me.txtOLDDFRATE.Text = "txtOLDDFRATE"
        Me.txtOLDDFRATE.Visible = False
        '
        'lblOLDDFRATE
        '
        Me.lblOLDDFRATE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOLDDFRATE.ForeColor = System.Drawing.Color.Firebrick
        Me.lblOLDDFRATE.Location = New System.Drawing.Point(366, 58)
        Me.lblOLDDFRATE.Name = "lblOLDDFRATE"
        Me.lblOLDDFRATE.Size = New System.Drawing.Size(123, 20)
        Me.lblOLDDFRATE.TabIndex = 45
        Me.lblOLDDFRATE.Tag = "OLDDFRATE"
        Me.lblOLDDFRATE.Text = "lblOLDDFRATE"
        Me.lblOLDDFRATE.Visible = False
        '
        'txtOLDACTYPE
        '
        Me.txtOLDACTYPE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOLDACTYPE.ForeColor = System.Drawing.Color.Firebrick
        Me.txtOLDACTYPE.Location = New System.Drawing.Point(282, 58)
        Me.txtOLDACTYPE.Name = "txtOLDACTYPE"
        Me.txtOLDACTYPE.ReadOnly = True
        Me.txtOLDACTYPE.Size = New System.Drawing.Size(80, 20)
        Me.txtOLDACTYPE.TabIndex = 44
        Me.txtOLDACTYPE.Tag = "OLDACTYPE"
        Me.txtOLDACTYPE.Text = "txtOLDACTYPE"
        Me.txtOLDACTYPE.Visible = False
        '
        'lblOLDACTYPE
        '
        Me.lblOLDACTYPE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOLDACTYPE.ForeColor = System.Drawing.Color.Firebrick
        Me.lblOLDACTYPE.Location = New System.Drawing.Point(188, 58)
        Me.lblOLDACTYPE.Name = "lblOLDACTYPE"
        Me.lblOLDACTYPE.Size = New System.Drawing.Size(88, 20)
        Me.lblOLDACTYPE.TabIndex = 43
        Me.lblOLDACTYPE.Tag = "OLDACTYPE"
        Me.lblOLDACTYPE.Text = "lblOLDACTYPE"
        Me.lblOLDACTYPE.Visible = False
        '
        'chkOPTIONSTOCK
        '
        Me.chkOPTIONSTOCK.AutoSize = True
        Me.chkOPTIONSTOCK.ForeColor = System.Drawing.Color.DarkViolet
        Me.chkOPTIONSTOCK.Location = New System.Drawing.Point(8, 32)
        Me.chkOPTIONSTOCK.Name = "chkOPTIONSTOCK"
        Me.chkOPTIONSTOCK.Size = New System.Drawing.Size(85, 17)
        Me.chkOPTIONSTOCK.TabIndex = 42
        Me.chkOPTIONSTOCK.Tag = "chkOPTIONSTOCK"
        Me.chkOPTIONSTOCK.Text = "Vay quyền"
        Me.chkOPTIONSTOCK.UseVisualStyleBackColor = True
        Me.chkOPTIONSTOCK.Visible = False
        '
        'txtNETBALANCE
        '
        Me.txtNETBALANCE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNETBALANCE.ForeColor = System.Drawing.Color.Firebrick
        Me.txtNETBALANCE.Location = New System.Drawing.Point(551, 137)
        Me.txtNETBALANCE.Name = "txtNETBALANCE"
        Me.txtNETBALANCE.ReadOnly = True
        Me.txtNETBALANCE.Size = New System.Drawing.Size(124, 20)
        Me.txtNETBALANCE.TabIndex = 10
        Me.txtNETBALANCE.Tag = "NETBALANCE"
        Me.txtNETBALANCE.Text = "0"
        Me.txtNETBALANCE.Visible = False
        '
        'lblNETBALANCE
        '
        Me.lblNETBALANCE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNETBALANCE.ForeColor = System.Drawing.Color.Firebrick
        Me.lblNETBALANCE.Location = New System.Drawing.Point(526, 140)
        Me.lblNETBALANCE.Name = "lblNETBALANCE"
        Me.lblNETBALANCE.Size = New System.Drawing.Size(174, 21)
        Me.lblNETBALANCE.TabIndex = 9
        Me.lblNETBALANCE.Tag = "NETBALANCE"
        Me.lblNETBALANCE.Text = "lblNETBALANCE"
        Me.lblNETBALANCE.Visible = False
        '
        'txtREMAINBAL
        '
        Me.txtREMAINBAL.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREMAINBAL.ForeColor = System.Drawing.Color.Firebrick
        Me.txtREMAINBAL.Location = New System.Drawing.Point(102, 31)
        Me.txtREMAINBAL.Name = "txtREMAINBAL"
        Me.txtREMAINBAL.ReadOnly = True
        Me.txtREMAINBAL.Size = New System.Drawing.Size(114, 20)
        Me.txtREMAINBAL.TabIndex = 6
        Me.txtREMAINBAL.Tag = "REMAINBAL"
        Me.txtREMAINBAL.Text = "0"
        Me.txtREMAINBAL.Visible = False
        '
        'lblREMAINBAL
        '
        Me.lblREMAINBAL.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblREMAINBAL.ForeColor = System.Drawing.Color.Firebrick
        Me.lblREMAINBAL.Location = New System.Drawing.Point(5, 34)
        Me.lblREMAINBAL.Name = "lblREMAINBAL"
        Me.lblREMAINBAL.Size = New System.Drawing.Size(88, 20)
        Me.lblREMAINBAL.TabIndex = 5
        Me.lblREMAINBAL.Tag = "REMAINBAL"
        Me.lblREMAINBAL.Text = "lblREMAINBAL"
        Me.lblREMAINBAL.Visible = False
        '
        'txtREMAINADVLINE
        '
        Me.txtREMAINADVLINE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREMAINADVLINE.ForeColor = System.Drawing.Color.Firebrick
        Me.txtREMAINADVLINE.Location = New System.Drawing.Point(282, 31)
        Me.txtREMAINADVLINE.Name = "txtREMAINADVLINE"
        Me.txtREMAINADVLINE.ReadOnly = True
        Me.txtREMAINADVLINE.Size = New System.Drawing.Size(110, 20)
        Me.txtREMAINADVLINE.TabIndex = 8
        Me.txtREMAINADVLINE.Tag = "REMAINADVLINE"
        Me.txtREMAINADVLINE.Text = "0"
        Me.txtREMAINADVLINE.Visible = False
        '
        'lblREMAINADVLINE
        '
        Me.lblREMAINADVLINE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblREMAINADVLINE.ForeColor = System.Drawing.Color.Firebrick
        Me.lblREMAINADVLINE.Location = New System.Drawing.Point(215, 34)
        Me.lblREMAINADVLINE.Name = "lblREMAINADVLINE"
        Me.lblREMAINADVLINE.Size = New System.Drawing.Size(66, 20)
        Me.lblREMAINADVLINE.TabIndex = 7
        Me.lblREMAINADVLINE.Tag = "REMAINADVLINE"
        Me.lblREMAINADVLINE.Text = "lblREMAINADVLINE"
        Me.lblREMAINADVLINE.Visible = False
        '
        'lblOLDDFQTTY
        '
        Me.lblOLDDFQTTY.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOLDDFQTTY.ForeColor = System.Drawing.Color.Firebrick
        Me.lblOLDDFQTTY.Location = New System.Drawing.Point(548, 137)
        Me.lblOLDDFQTTY.Name = "lblOLDDFQTTY"
        Me.lblOLDDFQTTY.Size = New System.Drawing.Size(109, 20)
        Me.lblOLDDFQTTY.TabIndex = 3
        Me.lblOLDDFQTTY.Tag = "OLDDFQTTY"
        Me.lblOLDDFQTTY.Text = "lblOLDDFQTTY"
        Me.lblOLDDFQTTY.Visible = False
        '
        'btnGetDeal
        '
        Me.btnGetDeal.Location = New System.Drawing.Point(473, 58)
        Me.btnGetDeal.Name = "btnGetDeal"
        Me.btnGetDeal.Size = New System.Drawing.Size(26, 23)
        Me.btnGetDeal.TabIndex = 15
        Me.btnGetDeal.Tag = "btnGetDeal"
        Me.btnGetDeal.Text = "?"
        Me.btnGetDeal.UseVisualStyleBackColor = True
        Me.btnGetDeal.Visible = False
        '
        'txtREF
        '
        Me.txtREF.BackColor = System.Drawing.Color.LightSalmon
        Me.txtREF.Enabled = False
        Me.txtREF.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREF.Location = New System.Drawing.Point(282, 59)
        Me.txtREF.Name = "txtREF"
        Me.txtREF.ReadOnly = True
        Me.txtREF.Size = New System.Drawing.Size(191, 20)
        Me.txtREF.TabIndex = 14
        Me.txtREF.Text = "txtREF"
        Me.txtREF.Visible = False
        '
        'lblREF
        '
        Me.lblREF.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblREF.Location = New System.Drawing.Point(188, 59)
        Me.lblREF.Name = "lblREF"
        Me.lblREF.Size = New System.Drawing.Size(88, 20)
        Me.lblREF.TabIndex = 13
        Me.lblREF.Tag = "LBLREF"
        Me.lblREF.Text = "lblREF"
        Me.lblREF.Visible = False
        '
        'txtOLDDFQTTY
        '
        Me.txtOLDDFQTTY.ForeColor = System.Drawing.Color.Firebrick
        Me.txtOLDDFQTTY.Location = New System.Drawing.Point(551, 137)
        Me.txtOLDDFQTTY.Name = "txtOLDDFQTTY"
        Me.txtOLDDFQTTY.ReadOnly = True
        Me.txtOLDDFQTTY.Size = New System.Drawing.Size(124, 20)
        Me.txtOLDDFQTTY.TabIndex = 4
        Me.txtOLDDFQTTY.Tag = "OLDDFQTTY"
        Me.txtOLDDFQTTY.Text = "txtOLDDFQTTY"
        Me.txtOLDDFQTTY.Visible = False
        '
        'dtpREFTXDATE
        '
        Me.dtpREFTXDATE.CustomFormat = "dd/MM/yyyy"
        Me.dtpREFTXDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpREFTXDATE.Location = New System.Drawing.Point(551, 141)
        Me.dtpREFTXDATE.Name = "dtpREFTXDATE"
        Me.dtpREFTXDATE.Size = New System.Drawing.Size(92, 20)
        Me.dtpREFTXDATE.TabIndex = 64
        Me.dtpREFTXDATE.Tag = "dtpREFTXDATE"
        Me.dtpREFTXDATE.Visible = False
        '
        'lblREFTXDATE
        '
        Me.lblREFTXDATE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblREFTXDATE.Location = New System.Drawing.Point(548, 141)
        Me.lblREFTXDATE.Name = "lblREFTXDATE"
        Me.lblREFTXDATE.Size = New System.Drawing.Size(126, 20)
        Me.lblREFTXDATE.TabIndex = 63
        Me.lblREFTXDATE.Tag = "REFTXDATE"
        Me.lblREFTXDATE.Text = "lblREFTXDATE"
        '
        'txtREFTXNUM
        '
        Me.txtREFTXNUM.Location = New System.Drawing.Point(572, 163)
        Me.txtREFTXNUM.Name = "txtREFTXNUM"
        Me.txtREFTXNUM.Size = New System.Drawing.Size(127, 20)
        Me.txtREFTXNUM.TabIndex = 62
        Me.txtREFTXNUM.Tag = "txtREFTXNUM"
        Me.txtREFTXNUM.Text = "txtREFTXNUM"
        Me.txtREFTXNUM.Visible = False
        '
        'lblREFTXNUM
        '
        Me.lblREFTXNUM.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblREFTXNUM.Location = New System.Drawing.Point(569, 157)
        Me.lblREFTXNUM.Name = "lblREFTXNUM"
        Me.lblREFTXNUM.Size = New System.Drawing.Size(94, 33)
        Me.lblREFTXNUM.TabIndex = 61
        Me.lblREFTXNUM.Tag = "REFTXNUM"
        Me.lblREFTXNUM.Text = "lblREFTXNUM"
        '
        'cboAFACCTNODRD
        '
        Me.cboAFACCTNODRD.DisplayMember = "DISPLAY"
        Me.cboAFACCTNODRD.FormattingEnabled = True
        Me.cboAFACCTNODRD.Location = New System.Drawing.Point(729, 152)
        Me.cboAFACCTNODRD.Name = "cboAFACCTNODRD"
        Me.cboAFACCTNODRD.Size = New System.Drawing.Size(342, 21)
        Me.cboAFACCTNODRD.TabIndex = 44
        Me.cboAFACCTNODRD.Tag = "890"
        Me.cboAFACCTNODRD.ValueMember = "VALUE"
        Me.cboAFACCTNODRD.Visible = False
        '
        'txtOLDDEALNO
        '
        Me.txtOLDDEALNO.BackColor = System.Drawing.Color.LightSalmon
        Me.txtOLDDEALNO.ForeColor = System.Drawing.Color.Firebrick
        Me.txtOLDDEALNO.Location = New System.Drawing.Point(252, 8)
        Me.txtOLDDEALNO.Name = "txtOLDDEALNO"
        Me.txtOLDDEALNO.ReadOnly = True
        Me.txtOLDDEALNO.Size = New System.Drawing.Size(174, 20)
        Me.txtOLDDEALNO.TabIndex = 2
        Me.txtOLDDEALNO.Tag = "txtOLDDEALNO"
        Me.txtOLDDEALNO.Text = "txtOLDDEALNO"
        Me.txtOLDDEALNO.Visible = False
        '
        'lblOLDDEALNO
        '
        Me.lblOLDDEALNO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOLDDEALNO.ForeColor = System.Drawing.Color.Firebrick
        Me.lblOLDDEALNO.Location = New System.Drawing.Point(132, 10)
        Me.lblOLDDEALNO.Name = "lblOLDDEALNO"
        Me.lblOLDDEALNO.Size = New System.Drawing.Size(109, 20)
        Me.lblOLDDEALNO.TabIndex = 1
        Me.lblOLDDEALNO.Tag = "OLDDEALNO"
        Me.lblOLDDEALNO.Text = "lblOLDDEALNO"
        Me.lblOLDDEALNO.Visible = False
        '
        'chkENDNEWDEAL
        '
        Me.chkENDNEWDEAL.AutoSize = True
        Me.chkENDNEWDEAL.ForeColor = System.Drawing.Color.Firebrick
        Me.chkENDNEWDEAL.Location = New System.Drawing.Point(3, 9)
        Me.chkENDNEWDEAL.Name = "chkENDNEWDEAL"
        Me.chkENDNEWDEAL.Size = New System.Drawing.Size(95, 17)
        Me.chkENDNEWDEAL.TabIndex = 0
        Me.chkENDNEWDEAL.Tag = "chkENDNEWDEAL"
        Me.chkENDNEWDEAL.Text = "Thanh lý tái ký"
        Me.chkENDNEWDEAL.UseVisualStyleBackColor = True
        Me.chkENDNEWDEAL.Visible = False
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(300, 606)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(80, 25)
        Me.btnAdd.TabIndex = 51
        Me.btnAdd.Tag = "Add"
        Me.btnAdd.Text = "btnAdd"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'pnContractInfo
        '
        Me.pnContractInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnContractInfo.Controls.Add(Me.pnlMember)
        Me.pnContractInfo.Controls.Add(Me.picSignature)
        Me.pnContractInfo.Controls.Add(Me.VScrollBarSign)
        Me.pnContractInfo.Location = New System.Drawing.Point(2, 497)
        Me.pnContractInfo.Name = "pnContractInfo"
        Me.pnContractInfo.Size = New System.Drawing.Size(707, 103)
        Me.pnContractInfo.TabIndex = 3
        '
        'pnlMember
        '
        Me.pnlMember.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMember.Location = New System.Drawing.Point(2, 3)
        Me.pnlMember.Name = "pnlMember"
        Me.pnlMember.Size = New System.Drawing.Size(540, 121)
        Me.pnlMember.TabIndex = 8
        Me.pnlMember.Tag = "Member"
        '
        'picSignature
        '
        Me.picSignature.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picSignature.Location = New System.Drawing.Point(548, 5)
        Me.picSignature.Name = "picSignature"
        Me.picSignature.Size = New System.Drawing.Size(135, 120)
        Me.picSignature.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picSignature.TabIndex = 5
        Me.picSignature.TabStop = False
        Me.picSignature.Tag = "Signature"
        '
        'VScrollBarSign
        '
        Me.VScrollBarSign.LargeChange = 1
        Me.VScrollBarSign.Location = New System.Drawing.Point(684, 3)
        Me.VScrollBarSign.Name = "VScrollBarSign"
        Me.VScrollBarSign.Size = New System.Drawing.Size(17, 120)
        Me.VScrollBarSign.TabIndex = 6
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(549, 606)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(80, 25)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Tag = "btnOK"
        Me.btnOK.Text = "btnOK"
        '
        'btnCANCEL
        '
        Me.btnCANCEL.Location = New System.Drawing.Point(631, 606)
        Me.btnCANCEL.Name = "btnCANCEL"
        Me.btnCANCEL.Size = New System.Drawing.Size(80, 25)
        Me.btnCANCEL.TabIndex = 4
        Me.btnCANCEL.Tag = "btnCANCEL"
        Me.btnCANCEL.Text = "btnCANCEL"
        '
        'pnBalance
        '
        Me.pnBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnBalance.Controls.Add(Me.pnSEInfo)
        Me.pnBalance.Controls.Add(Me.lblPPSE)
        Me.pnBalance.Controls.Add(Me.lblPurchasingPower)
        Me.pnBalance.Controls.Add(Me.lblTotal)
        Me.pnBalance.Controls.Add(Me.lblTotalAmout)
        Me.pnBalance.Controls.Add(Me.lblCIAdvance)
        Me.pnBalance.Controls.Add(Me.lblCI)
        Me.pnBalance.Controls.Add(Me.lblCIBalance)
        Me.pnBalance.Location = New System.Drawing.Point(2, 288)
        Me.pnBalance.Name = "pnBalance"
        Me.pnBalance.Size = New System.Drawing.Size(707, 95)
        Me.pnBalance.TabIndex = 10
        '
        'pnSEInfo
        '
        Me.pnSEInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnSEInfo.Controls.Add(Me.lblMortage)
        Me.pnSEInfo.Controls.Add(Me.lblSEBalance)
        Me.pnSEInfo.Controls.Add(Me.lblSE)
        Me.pnSEInfo.Controls.Add(Me.lblAAMT)
        Me.pnSEInfo.Controls.Add(Me.txtOLDDEALNO)
        Me.pnSEInfo.Controls.Add(Me.lblOLDDEALNO)
        Me.pnSEInfo.Controls.Add(Me.chkENDNEWDEAL)
        Me.pnSEInfo.Location = New System.Drawing.Point(1, -1)
        Me.pnSEInfo.Name = "pnSEInfo"
        Me.pnSEInfo.Size = New System.Drawing.Size(706, 95)
        Me.pnSEInfo.TabIndex = 0
        '
        'lblMortage
        '
        Me.lblMortage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMortage.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMortage.Location = New System.Drawing.Point(439, 37)
        Me.lblMortage.Name = "lblMortage"
        Me.lblMortage.Size = New System.Drawing.Size(120, 23)
        Me.lblMortage.TabIndex = 2
        Me.lblMortage.Text = "lblMortage"
        Me.lblMortage.Visible = False
        '
        'lblSEBalance
        '
        Me.lblSEBalance.Location = New System.Drawing.Point(28, 36)
        Me.lblSEBalance.Name = "lblSEBalance"
        Me.lblSEBalance.Size = New System.Drawing.Size(80, 23)
        Me.lblSEBalance.TabIndex = 0
        Me.lblSEBalance.Text = "lblSEBalance"
        '
        'lblSE
        '
        Me.lblSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSE.Location = New System.Drawing.Point(313, 37)
        Me.lblSE.Name = "lblSE"
        Me.lblSE.Size = New System.Drawing.Size(120, 23)
        Me.lblSE.TabIndex = 1
        Me.lblSE.Text = "`"
        '
        'lblAAMT
        '
        Me.lblAAMT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAAMT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAAMT.Location = New System.Drawing.Point(112, 33)
        Me.lblAAMT.Name = "lblAAMT"
        Me.lblAAMT.Size = New System.Drawing.Size(120, 23)
        Me.lblAAMT.TabIndex = 0
        Me.lblAAMT.Text = "lblAAMT"
        Me.lblAAMT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPPSE
        '
        Me.lblPPSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPPSE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPPSE.Location = New System.Drawing.Point(112, 92)
        Me.lblPPSE.Name = "lblPPSE"
        Me.lblPPSE.Size = New System.Drawing.Size(120, 23)
        Me.lblPPSE.TabIndex = 6
        Me.lblPPSE.Text = "lblPPSE"
        Me.lblPPSE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPurchasingPower
        '
        Me.lblPurchasingPower.Location = New System.Drawing.Point(8, 92)
        Me.lblPurchasingPower.Name = "lblPurchasingPower"
        Me.lblPurchasingPower.Size = New System.Drawing.Size(104, 23)
        Me.lblPurchasingPower.TabIndex = 5
        Me.lblPurchasingPower.Text = "lblPurchasingPower"
        '
        'lblTotal
        '
        Me.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(112, 63)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(120, 23)
        Me.lblTotal.TabIndex = 4
        Me.lblTotal.Text = "lblTotal"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalAmout
        '
        Me.lblTotalAmout.Location = New System.Drawing.Point(8, 63)
        Me.lblTotalAmout.Name = "lblTotalAmout"
        Me.lblTotalAmout.Size = New System.Drawing.Size(104, 23)
        Me.lblTotalAmout.TabIndex = 3
        Me.lblTotalAmout.Text = "lblTotalAmout"
        '
        'lblCIAdvance
        '
        Me.lblCIAdvance.Location = New System.Drawing.Point(8, 34)
        Me.lblCIAdvance.Name = "lblCIAdvance"
        Me.lblCIAdvance.Size = New System.Drawing.Size(104, 23)
        Me.lblCIAdvance.TabIndex = 2
        Me.lblCIAdvance.Text = "lblCIAdvance"
        '
        'lblCI
        '
        Me.lblCI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCI.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCI.Location = New System.Drawing.Point(112, 5)
        Me.lblCI.Name = "lblCI"
        Me.lblCI.Size = New System.Drawing.Size(120, 23)
        Me.lblCI.TabIndex = 1
        Me.lblCI.Text = "lblCI"
        Me.lblCI.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCIBalance
        '
        Me.lblCIBalance.Location = New System.Drawing.Point(8, 5)
        Me.lblCIBalance.Name = "lblCIBalance"
        Me.lblCIBalance.Size = New System.Drawing.Size(104, 23)
        Me.lblCIBalance.TabIndex = 1
        Me.lblCIBalance.Text = "lblCIBalance"
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
        'btnApprove
        '
        Me.btnApprove.Location = New System.Drawing.Point(389, 606)
        Me.btnApprove.Name = "btnApprove"
        Me.btnApprove.Size = New System.Drawing.Size(80, 25)
        Me.btnApprove.TabIndex = 2
        Me.btnApprove.Tag = "btnApprove"
        Me.btnApprove.Text = "btnApprove"
        Me.btnApprove.Visible = False
        '
        'btnAdjust
        '
        Me.btnAdjust.Location = New System.Drawing.Point(471, 606)
        Me.btnAdjust.Name = "btnAdjust"
        Me.btnAdjust.Size = New System.Drawing.Size(80, 25)
        Me.btnAdjust.TabIndex = 11
        Me.btnAdjust.Tag = "btnAdjust"
        Me.btnAdjust.Text = "btnAdjust"
        Me.btnAdjust.Visible = False
        '
        'pnDFGR
        '
        Me.pnDFGR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnDFGR.Location = New System.Drawing.Point(2, 384)
        Me.pnDFGR.Name = "pnDFGR"
        Me.pnDFGR.Size = New System.Drawing.Size(707, 111)
        Me.pnDFGR.TabIndex = 12
        '
        'btnDEL
        '
        Me.btnDEL.Location = New System.Drawing.Point(216, 606)
        Me.btnDEL.Name = "btnDEL"
        Me.btnDEL.Size = New System.Drawing.Size(80, 25)
        Me.btnDEL.TabIndex = 53
        Me.btnDEL.Tag = "DEL"
        Me.btnDEL.Text = "btnDEL"
        Me.btnDEL.UseVisualStyleBackColor = True
        '
        'btnReject
        '
        Me.btnReject.Location = New System.Drawing.Point(471, 606)
        Me.btnReject.Name = "btnReject"
        Me.btnReject.Size = New System.Drawing.Size(80, 25)
        Me.btnReject.TabIndex = 54
        Me.btnReject.Tag = "btnReject"
        Me.btnReject.Text = "btnReject"
        Me.btnReject.Visible = False
        '
        'frmCreateDFGRDeal
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.ClientSize = New System.Drawing.Size(712, 636)
        Me.Controls.Add(Me.btnReject)
        Me.Controls.Add(Me.btnDEL)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.pnBalance)
        Me.Controls.Add(Me.pnDFGR)
        Me.Controls.Add(Me.btnAdjust)
        Me.Controls.Add(Me.btnApprove)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCANCEL)
        Me.Controls.Add(Me.pnContractInfo)
        Me.Controls.Add(Me.pnOrder)
        Me.Controls.Add(Me.pnlTitle)
        Me.Controls.Add(Me.cboAFACCTNODRD)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(200, 10)
        Me.MaximizeBox = False
        Me.Name = "frmCreateDFGRDeal"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Tag = "frmCreateDFGRDeal"
        Me.Text = "frmCreateDFGRDeal"
        Me.pnlTitle.ResumeLayout(False)
        Me.pnlTitle.PerformLayout()
        Me.pnOrder.ResumeLayout(False)
        Me.pnUpcomInfo.ResumeLayout(False)
        Me.pnUpcomInfo.PerformLayout()
        Me.pnMainInfo.ResumeLayout(False)
        Me.pnMainInfo.PerformLayout()
        Me.pnContractInfo.ResumeLayout(False)
        CType(Me.picSignature, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnBalance.ResumeLayout(False)
        Me.pnSEInfo.ResumeLayout(False)
        Me.pnSEInfo.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Declare constant and variables "
    Const c_ResourceManager = "_DIRECT.frmCreateDFGRDeal-"
    Dim mv_strMarginType As String = "N"
    Dim mv_dblMarginRatioRate As Double = 0
    Dim mv_dblSecMarginPrice As Double = 0
    Dim mv_dblIsPPUsed As Double = 1
    Dim mv_strAFACCTNO As String
    Dim mv_strAuthCustID As String = String.Empty
    Dim mv_strKeyFieldValue As String = String.Empty
    Dim mv_strLastAFACCTNO As String = String.Empty
    Dim mv_blnisClosed As Boolean = False
    Dim mv_dblFloorPrice As Double
    Dim mv_dblMarginPrice As Double
    Dim mv_dblBasicPrice As Double
    Dim mv_dblCeilingPrice As Double
    Dim mv_dblTradeLot As Double
    Dim mv_dblTradeUnit As Double
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
    Dim mv_strADDRESS As String = String.Empty
    Dim mv_strLICENCE As String = String.Empty
    Dim mv_strACTYPE As String = String.Empty
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
    Dim mv_dblOldStopPrice As Double
    Dim mv_strHOPriceTypeMessage As String = ""
    Dim mv_strHAPriceTypeMessage As String = ""
    Dim mv_strObjFullExectypeMessage As String = ""
    Dim mv_strODStatus As String = ""
    Dim mv_strTableName As String = ""
    Dim mv_intExecFlag As String = ""
    Dim mv_strTellerRight As String = ""
    Dim mv_strGroupCareBy As String = ""
    Dim mv_strAuthString As String = ""
    Dim mv_strKeyFieldName As String = ""
    Dim mv_strLinkValue As String = ""
    Dim mv_strLinkFIeld As String = ""
    Dim mv_strDFTYPE As String
    Private mv_strSYMBOLLIST As String = ""
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
    Private mv_blnAdvanceOrder As Boolean = True
    Private mv_blnUPCOMOrder As Boolean
    Private mv_blnViewMode As Boolean = False
    Private mv_strTranStatus As String
    Private mv_strDeltd As String

    'Public Bien chung cho phan DFDEAL
    Private mv_strRRNAME As String = ""
    Private mv_strCUSTBANK As String = ""
    Private mv_strCIACCTNO As String = ""
    Private mv_strRRTYPE As String = ""
    Private mv_strLIMITCHK As String = ""
    Private mv_strOPTPRICE As String = ""
    Private mv_strCALLTYPE As String = ""
    Private mv_strDEALACTYPE As String = ""
    Private mv_strISVSD As String = ""
    Private mv_strOLDISVSD As String = ""
    Private mv_strTypeCondition As String = "('N','R','P','B','T')"
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
    Private mv_arrSYMBOL As Hashtable

    'Thong tin chung khoan cho deal
    Private mv_strDFTYPENAME As String
    Private mv_strISAPPROVE As String
    Private mv_strDEALTYPE As String

    Private mv_strBASICPRICE As String
    Private mv_strLRATE As String
    Private mv_strDFPRICE As String
    Private mv_strTRIGGERPRICE As String
    Private mv_dblFEEAMT As Double = 0
    Private mv_dblEXECQTTY As Double = 0
    Private mv_dblDFTRADELOT As Double = 0
    Private mv_dblMATCHPRICE As Double = 0
    'Nhung bien danh cho phan Thanh ly tai ky
    Private mv_dblPRINOVD As Double = 0    'Gốc QH
    Private mv_dblDEALPRINAMT As Double = 0    'Tổng gốc
    Private mv_dblPRINNML As Double = 0    'Gốc TH
    Private mv_dblDEALFEE As Double = 0    'Tổng lãi
    Private mv_dblINTNMLOVD As Double = 0  'Tổng lãi QH
    Private mv_dblINTOVDACR As Double = 0  'Tổng lãi trên gốc QH
    Private mv_dblINTDUE As Double = 0     'Tổng lãi ĐH
    Private mv_dblINTNMLACR As Double = 0  'Tổng lãi TH
    Private mv_dblFEEPAID As Double = 0    'Tổng phí của deal
    Private mv_dblDFQTTY As Double = 0     'Số chứng khoán có thể bán
    Private mv_dblRCVQTTY As Double = 0    'Số chứng khoán chờ về
    Private mv_dblCARCVQTTY As Double = 0  'Số chứng khoán quyền chờ về
    Private mv_dblBLOCKQTTY As Double = 0  'Số chứng khoán hạn chế chuyển nhượng     
    Private mv_dblBQTTY As Double = 0       'Số chứng khoán đang bán     
    Private mv_dblSECURED As Double = 0       'Số chứng khoán ký quỹ bán     
    Private mv_dblREMAINQTTY As Double = 0       'Số chứng khoán hiện đang vay
    Private mv_dblLIMITCHECK As Double = 0  'Kiểm tra hạn mức    
    Private mv_dblBALANCE As Double = 0  'Số dư có thể sử dụng
    Private mv_dblAPMT As Double = 0  'Số dư có thể ứng trước
    Private mv_dblADVANCELINE As Double = 0  'Bảo lãnh thấu chi    
    Private mv_dblODAMT As Double = 0  'Số dư thấu chi   
    Private mv_dblTOTALPAID As Double = 0 'Tổng số tiền phải trả
    Private mv_dblTOTALSECURITIES As Double = 0 'Tổng số chứng khoán release
    Private mv_dblPP As Double = 0 'Sức mua
    Private mv_dblORGDFQTTY As Double = 0     'Số chứng khoán có thể bán lúc lấy lên ban đầu
    Private mv_dblORGRCVQTTY As Double = 0
    Private mv_dblORGCARCVQTTY As Double = 0
    Private mv_dblORGBLOCKQTTY As Double = 0
    Private mv_dblREALBALWITHDRAWN As Double = 0
    Private mv_dblRLSAMT As Double = 0
    Private mv_dblRLSQTTY As Double = 0
    Private mv_dblISCOREBANK As Double = 0
    Private mv_dblBALADDOPT As Double = 0
    Private mv_dblEXPRICE As Double = 0
    Private mv_dblMAXDFOPTION As Double = 0

    Private mv_strCIDRAWNDOWN As String = String.Empty 'Giải ngân qua CI
    Private mv_strRRID As String = String.Empty 'Mã giải ngân
    Private mv_strOLDDFACCTNO As String = String.Empty 'So hieu deal cu
    Private mv_strLNACCTNO As String = String.Empty 'So hop dong vay cu
    Private mv_strOLDDFAFACCTNO As String = String.Empty
    Private mv_strDFAFACCTNO As String = String.Empty
    Private mv_strOLDBANKDRAWNDOWN As String = String.Empty
    Private mv_strOLDCMPDRAWNDOWN As String = String.Empty
    Private mv_strOLDDFRATE As String = String.Empty
    Private mv_strOLDDESC As String = String.Empty
    Private mv_strCAMASTID As String = String.Empty
    Private mv_strDUEDATE As String = String.Empty
    Private mv_strREPORTDATE As String = String.Empty


    Private Const BASICPRICE = "BASICPRICE" 'Gia theo ro
    Private Const MATCHPRICE = "MATCHPRICE" 'Gia khop
    Private Const OPTIONPRICE = "OPTIONPRICE" 'Gia mua CK quyen
    Private Const OTHERS = "OTHERS" 'Gia tri vay can cu theo gia tri khac.

    Private Const CONTROL_PNL_BALANCE_TOP = 302 '302 '330 '230
    Private Const CONTROL_PNL_CONTRACT_TOP = 520 '400 '460 '265 '200
    Private Const CONTROL_PNL_DFGRP_TOP = 400 '400 '460 '265 '200
    Private Const CONTROL_PNL_EXTENDINFO_TOP = 135 '135
    Private Const CONTROL_BUTTON_TOP = 518 '518 '620 '400
    Private Const FRM_DEFAULT_HEIGHT = 580 '580 '630 '420
    Private Const FRM_EXTEND_HEIGHT = 720 '592 '650 '455
    'Private Const MISS_HIGHT = 120

    Private mv_strTellerName As String
    Private mv_strPrevPriceType As String = "NOTALL"
    Private mv_strOldPriceType As String

    Private Const c_HA_TRADEPLACE As String = "002"

    Private Const c_HO_TRADEPLACE As String = "001"
    Private mv_strCurrentTime As String = String.Empty
    Private mv_arrHoPriceTypeInfo() As HoPriceType

    Private mv_strIsIssuer As String = "N"
    Private mv_strIsAdjust As String = "N"
    Private Const mv_strSETYPE = "006"

    'TungNT added
    Private mv_GroupCareBy As String = ""
    Private mv_InitParam As String = ""
    Private mv_CloseOnFinish As Boolean = False
    Private mv_ReturnValue As String = ""
    Private mv_AFCarebyGrp As String = ""
    'End
    Private mv_strIsADVCASH As String = "N" '16/11/2017 DieuNDA: Co phai loai hình DFTYPE Ung truoc tien co tuc hay khong

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

    Public Property TableName() As String
        Get
            Return mv_strTableName
        End Get
        Set(ByVal Value As String)
            mv_strTableName = Value
        End Set
    End Property

    Public Property ExeFlag() As Integer
        Get
            Return mv_intExecFlag
        End Get
        Set(ByVal Value As Integer)
            mv_intExecFlag = Value
        End Set
    End Property

    Public Property TellerRight() As String
        Get
            Return mv_strTellerRight
        End Get
        Set(ByVal Value As String)
            mv_strTellerRight = Value
        End Set
    End Property

    Public Property GroupCareBy() As String
        Get
            Return mv_strGroupCareBy
        End Get
        Set(ByVal Value As String)
            mv_strGroupCareBy = Value
        End Set
    End Property

    Public Property AuthString() As String
        Get
            Return mv_strAuthString
        End Get
        Set(ByVal Value As String)
            mv_strAuthString = Value
        End Set
    End Property

    Public Property KeyFieldName() As String
        Get
            Return mv_strKeyFieldName
        End Get
        Set(ByVal Value As String)
            mv_strKeyFieldName = Value
        End Set
    End Property
    Public Property KeyFieldValue() As String
        Get
            Return mv_strKeyFieldValue
        End Get
        Set(ByVal Value As String)
            mv_strKeyFieldValue = Value
        End Set
    End Property

    Public Property LinkValue() As String
        Get
            Return mv_strLinkValue
        End Get
        Set(ByVal Value As String)
            mv_strLinkValue = Value
        End Set
    End Property

    Public Property LinkFIeld() As String
        Get
            Return mv_strLinkFIeld
        End Get
        Set(ByVal Value As String)
            mv_strLinkFIeld = Value
        End Set
    End Property

    Public Property CALLTYPE() As String
        Get
            Return mv_strCALLTYPE
        End Get
        Set(ByVal Value As String)
            mv_strCALLTYPE = Value
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

        'SEMemberGrid = New GridEx
        'SEMemberGrid.FixedHeaderRows.Add(v_cmrSEMemberHeader)
        'SEMemberGrid.Columns.Add(New Xceed.Grid.Column("SYMBOL", GetType(System.String)))
        'SEMemberGrid.Columns.Add(New Xceed.Grid.Column("TRADE", GetType(System.Decimal)))
        'SEMemberGrid.Columns.Add(New Xceed.Grid.Column("MORTAGE", GetType(System.Decimal)))
        'SEMemberGrid.Columns.Add(New Xceed.Grid.Column("COSTPRICE", GetType(System.Decimal)))
        'SEMemberGrid.Columns.Add(New Xceed.Grid.Column("BASICPRICE", GetType(System.Decimal)))

        'SEMemberGrid.Columns("SYMBOL").Title = mv_ResourceManager.GetString("MEMBER_SYMBOL")
        'SEMemberGrid.Columns("TRADE").Title = mv_ResourceManager.GetString("MEMBER_TRADE")
        'SEMemberGrid.Columns("MORTAGE").Title = mv_ResourceManager.GetString("MEMBER_MORTAGE")
        'SEMemberGrid.Columns("COSTPRICE").Title = mv_ResourceManager.GetString("MEMBER_COSTPRICE")
        'SEMemberGrid.Columns("BASICPRICE").Title = mv_ResourceManager.GetString("MEMBER_BASICPRICE")

        'SEMemberGrid.Columns("TRADE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        'SEMemberGrid.Columns("MORTAGE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        'SEMemberGrid.Columns("COSTPRICE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        'SEMemberGrid.Columns("BASICPRICE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right

        'SEMemberGrid.Columns("TRADE").FormatSpecifier = "#,##0"
        'SEMemberGrid.Columns("MORTAGE").FormatSpecifier = "#,##0"
        'SEMemberGrid.Columns("COSTPRICE").FormatSpecifier = "#,##0"
        'SEMemberGrid.Columns("BASICPRICE").FormatSpecifier = "#,##0"

        'SEMemberGrid.Columns("SYMBOL").Width = 60
        'SEMemberGrid.Columns("TRADE").Width = 70
        'SEMemberGrid.Columns("MORTAGE").Width = 70
        'SEMemberGrid.Columns("COSTPRICE").Width = 70
        'SEMemberGrid.Columns("BASICPRICE").Width = 70

        SEMemberGrid = New GridEx
        SEMemberGrid.FixedHeaderRows.Add(v_cmrSEMemberHeader)
        SEMemberGrid.Columns.Add(New Xceed.Grid.Column("SYMBOL", GetType(System.String)))
        SEMemberGrid.Columns.Add(New Xceed.Grid.Column("QTTY", GetType(System.Double)))
        SEMemberGrid.Columns.Add(New Xceed.Grid.Column("AUTOID", GetType(System.String)))
        SEMemberGrid.Columns.Add(New Xceed.Grid.Column("TYPENAME", GetType(System.String)))
        SEMemberGrid.Columns.Add(New Xceed.Grid.Column("DTYPE", GetType(System.String)))
        SEMemberGrid.Columns.Add(New Xceed.Grid.Column("PRICE", GetType(System.Decimal)))
        SEMemberGrid.Columns.Add(New Xceed.Grid.Column("TXDATE", GetType(System.String)))
        SEMemberGrid.Columns.Add(New Xceed.Grid.Column("CLEARDATE", GetType(System.String)))
        SEMemberGrid.Columns.Add(New Xceed.Grid.Column("BALDEFOVD", GetType(System.Decimal)))
        SEMemberGrid.Columns.Add(New Xceed.Grid.Column("CAMASTID", GetType(System.String)))
        SEMemberGrid.Columns.Add(New Xceed.Grid.Column("AVLWITHDRAW", GetType(System.Double)))

        SEMemberGrid.Columns("SYMBOL").Title = mv_ResourceManager.GetString("MEMBER_SYMBOL")
        SEMemberGrid.Columns("QTTY").Title = mv_ResourceManager.GetString("MEMBER_QTTY")
        SEMemberGrid.Columns("AUTOID").Title = mv_ResourceManager.GetString("MEMBER_AUTOID")
        SEMemberGrid.Columns("TYPENAME").Title = mv_ResourceManager.GetString("MEMBER_TYPENAME")
        SEMemberGrid.Columns("DTYPE").Title = mv_ResourceManager.GetString("MEMBER_DTYPE")
        SEMemberGrid.Columns("PRICE").Title = "PRICE"
        SEMemberGrid.Columns("TXDATE").Title = mv_ResourceManager.GetString("TXDATE")
        SEMemberGrid.Columns("CLEARDATE").Title = mv_ResourceManager.GetString("CLEARDATE")
        SEMemberGrid.Columns("AVLWITHDRAW").Title = mv_ResourceManager.GetString("AVLWITHDRAW")


        SEMemberGrid.Columns("QTTY").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        SEMemberGrid.Columns("QTTY").FormatSpecifier = "#,##0"
        SEMemberGrid.Columns("BALDEFOVD").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        SEMemberGrid.Columns("BALDEFOVD").FormatSpecifier = "#,##0"
        SEMemberGrid.Columns("PRICE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        SEMemberGrid.Columns("PRICE").FormatSpecifier = "#,##0"

        SEMemberGrid.Columns("AVLWITHDRAW").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        SEMemberGrid.Columns("AVLWITHDRAW").FormatSpecifier = "#,##0"

        SEMemberGrid.Columns("SYMBOL").Width = 100
        SEMemberGrid.Columns("QTTY").Width = 80
        SEMemberGrid.Columns("AVLWITHDRAW").Width = 80
        SEMemberGrid.Columns("TYPENAME").Width = 150
        SEMemberGrid.Columns("TXDATE").Width = 100
        SEMemberGrid.Columns("CLEARDATE").Width = 120
        SEMemberGrid.Columns("PRICE").Width = 80
        SEMemberGrid.Columns("BALDEFOVD").Width = 100
        SEMemberGrid.Columns("CAMASTID").Width = 100
        SEMemberGrid.Width = pnSEInfo.Width
        SEMemberGrid.Height = pnSEInfo.Height
        SEMemberGrid.Columns("AUTOID").Visible = False
        SEMemberGrid.Columns("DTYPE").Visible = False
        SEMemberGrid.Columns("PRICE").Visible = False
        SEMemberGrid.Columns("BALDEFOVD").Visible = False
        SEMemberGrid.Columns("CAMASTID").Visible = False

        Me.pnSEInfo.Controls.Clear()
        Me.pnSEInfo.Controls.Add(SEMemberGrid)

        AddHandler SEMemberGrid.DoubleClick, AddressOf Me.SEMemberGrid_DoubleClick
        If Me.SEMemberGrid.DataRowTemplate.Cells.Count >= 0 Then
            For i As Integer = 0 To Me.SEMemberGrid.DataRowTemplate.Cells.Count - 1
                AddHandler SEMemberGrid.DataRowTemplate.Cells(i).DoubleClick, AddressOf SEMemberGrid_DoubleClick
            Next
        End If


        'Khởi tạo DFGR Grid
        Dim v_cmrDFGRHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrDFGRHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrDFGRHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)

        DFGRGrid = New GridEx
        DFGRGrid.FixedHeaderRows.Add(v_cmrDFGRHeader)
        DFGRGrid.Columns.Add(New Xceed.Grid.Column("AFACCTNO", GetType(System.String)))
        DFGRGrid.Columns.Add(New Xceed.Grid.Column("DTYPE", GetType(System.String)))
        DFGRGrid.Columns.Add(New Xceed.Grid.Column("SYMBOL", GetType(System.String)))
        DFGRGrid.Columns.Add(New Xceed.Grid.Column("CODEID", GetType(System.String)))
        DFGRGrid.Columns.Add(New Xceed.Grid.Column("QTTY", GetType(System.Double)))
        DFGRGrid.Columns.Add(New Xceed.Grid.Column("DFRATE", GetType(System.Double)))
        DFGRGrid.Columns.Add(New Xceed.Grid.Column("DFPRICE", GetType(System.Double)))
        DFGRGrid.Columns.Add(New Xceed.Grid.Column("AMT", GetType(System.Double)))
        DFGRGrid.Columns.Add(New Xceed.Grid.Column("REF", GetType(System.String)))

        DFGRGrid.Columns("AFACCTNO").Title = mv_ResourceManager.GetString("DFGR_AFACCTNO")
        DFGRGrid.Columns("SYMBOL").Title = mv_ResourceManager.GetString("DFGR_SYMBOL")
        DFGRGrid.Columns("CODEID").Title = mv_ResourceManager.GetString("DFGR_CODEID")
        DFGRGrid.Columns("QTTY").Title = mv_ResourceManager.GetString("DFGR_QTTY")
        DFGRGrid.Columns("DTYPE").Title = mv_ResourceManager.GetString("DFGR_DTYPE")
        DFGRGrid.Columns("DFPRICE").Title = mv_ResourceManager.GetString("DFGR_DFPRICE")
        DFGRGrid.Columns("DFRATE").Title = mv_ResourceManager.GetString("DFGR_DFRATE")
        DFGRGrid.Columns("AMT").Title = mv_ResourceManager.GetString("DFGR_AMT")
        DFGRGrid.Columns("REF").Title = mv_ResourceManager.GetString("DFGR_REF")

        DFGRGrid.Columns("QTTY").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        DFGRGrid.Columns("QTTY").FormatSpecifier = "#,##0"
        DFGRGrid.Columns("DFPRICE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        DFGRGrid.Columns("DFPRICE").FormatSpecifier = "#,##0.00"
        DFGRGrid.Columns("AMT").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        DFGRGrid.Columns("AMT").FormatSpecifier = "#,##0"
        DFGRGrid.Columns("DFRATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        DFGRGrid.Columns("DFRATE").FormatSpecifier = "#,##0"

        DFGRGrid.Columns("AFACCTNO").Width = 80
        DFGRGrid.Columns("DTYPE").Width = 100
        DFGRGrid.Columns("SYMBOL").Width = 50
        DFGRGrid.Columns("CODEID").Width = 0
        DFGRGrid.Columns("QTTY").Width = 70
        DFGRGrid.Columns("DFPRICE").Width = 70
        DFGRGrid.Columns("DFRATE").Width = 70
        DFGRGrid.Columns("AMT").Width = 70
        DFGRGrid.Columns("REF").Width = 70
        DFGRGrid.Width = SEMemberGrid.Width
        DFGRGrid.Height = SEMemberGrid.Height

        'DFGRGrid.ReadOnly = False


        Me.pnDFGR.Controls.Clear()
        Me.pnDFGR.Controls.Add(DFGRGrid)

        'AddHandler DFGRGrid.DoubleClick, AddressOf Me.SEMemberGrid_DoubleClick
        'If Me.DFGRGrid.DataRowTemplate.Cells.Count >= 0 Then
        '    For i As Integer = 0 To Me.DFGRGrid.DataRowTemplate.Cells.Count - 1
        '        AddHandler DFGRGrid.DataRowTemplate.Cells(i).DoubleClick, AddressOf SEMemberGrid_DoubleClick
        '    Next
        'End If

    End Sub
#End Region

#Region " Other method "
    Private Function GetDealAccount() As String
        Dim v_strClause, v_strAutoID As String
        Dim v_int, v_intCount As Integer
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strFLDNAME, v_strVALUE As String
        'Lấy ra số tự tăng
        v_strClause = "SEQ_DFMAST"
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_wsBDS As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_strClause, "GetInventory")
        v_wsBDS.Message(v_strObjMsg)
        v_xmlDocument.LoadXml(v_strObjMsg)
        v_strAutoID = v_xmlDocument.DocumentElement.Attributes("CLAUSE").Value
        'Tạo số hiệu lệnh = Mã chi nhánh + Ngày hệ thống + Số tự tăng
        Dim v_strDealAccount As String
        v_strDealAccount = Me.BranchId & Mid(Replace(Me.BusDate, "/", vbNullString), 1, 4) & Mid(Replace(Me.BusDate, "/", vbNullString), 7, 2) & Strings.Right(gc_FORMAT_ODAUTOID & CStr(v_strAutoID), Len(gc_FORMAT_ODAUTOID))
        Return v_strDealAccount
    End Function
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
            For Each ctl As Control In pnUpcomInfo.Controls
                ctl.Enabled = False
            Next

            pnBalance.Enabled = Not blnIsDelete
            pnContractInfo.Enabled = Not blnIsDelete
            pnSEInfo.Enabled = Not blnIsDelete
            mskAFACCTNO.Enabled = blnIsDelete

            btnOK.Visible = False
            btnOK.Enabled = False
            'txtQuantity.Enabled = True
            txtDFPrice.Enabled = False
            txtDFRATE.Enabled = True

            btnCANCEL.Text = mv_ResourceManager.GetString("btnExit")

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
            Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode, v_intIndex As Long, v_intCount As Integer
            Dim v_strFLDNAME As String, v_strFLDDEFNAME As String, v_strDATATYPE As String, v_strFLDVALUE As String
            Dim v_strERRMSG, v_strENERRMSG, v_strOPERATOR, v_strVALEXP, v_strVALEXP2 As String, v_strACTYPE, v_strDESC As String
            Dim v_dtVALEXP, v_dtVALEXP2, v_dtFLDVALUE As Date
            Dim v_ctl As Control, v_attrFLDNAME As Xml.XmlAttribute, v_attrDATATYPE As Xml.XmlAttribute, v_objEval As New Evaluator

            Dim v_TradeQtty, v_BlockQtty, v_PendingQtty, v_PendingCAQtty, v_seacctno, v_RLSAMT As String
            Dim v_strObjMsg, v_strSQL, v_strValue As String
            Dim v_ws As New BDSDeliveryManagement
            Dim x, y As Integer

            Dim v_strAFACCTNO, V_strREF, v_strDFTYPE, v_strSYMBOL, v_strCODEID, v_strDTYPE, str_add, v_strAUTODRAWNDOWN, v_strisapprove, v_strAFACCTNODRD, str As String

            Dim v_QTTY, v_AMT, v_DFPRICE, v_ORGAMT, V_DFRATE As Decimal
            Dim str_DealGRAccount As String
            str_DealGRAccount = GetDealAccount()
            If chkAUTODRAWNDOWN.Checked Then
                v_strAUTODRAWNDOWN = "1"
            Else
                v_strAUTODRAWNDOWN = "0"
            End If

            If chkisapprove.Checked Then
                v_strisapprove = "Y"
            Else
                v_strisapprove = "N"
            End If

            v_strAFACCTNODRD = Me.cboAFACCTNODRD.Text
            v_strAFACCTNODRD = Mid(Me.cboAFACCCBO.Text, 1, 10)

            If v_strAFACCTNODRD <> Mid(Me.cboAFACCCBO.Text, 1, 10) Then
                MsgBox(mv_ResourceManager.GetString("ERR_INVALID_DIS_ACCOUNT"), MsgBoxStyle.Information, Me.Text)
                Return False
            End If

            For i As Integer = 0 To DFGRGrid.DataRows.Count - 1
                With DFGRGrid.DataRows(i)
                    If (Not .Cells("AMT").Value Is Nothing) Then
                        If v_strAFACCTNODRD <> gf_CorrectStringField(.Cells("AFACCTNO").Value.ToString().Trim()) Then
                            MsgBox(mv_ResourceManager.GetString("ERR_INVALID_STK_ACCOUNT"), MsgBoxStyle.Information, Me.Text)
                            Return False
                        End If
                        v_AMT = gf_CorrectNumericField(.Cells("AMT").Value.ToString().Trim())
                        v_ORGAMT = v_ORGAMT + v_AMT
                    Else
                        v_AMT = 0
                    End If

                End With
            Next

            If v_ORGAMT = 0 Then
                MsgBox(mv_ResourceManager.GetString("ERR_NULL_STOCK"), MsgBoxStyle.Information, Me.Text)
                Return False
            End If

            For i As Integer = 0 To DFGRGrid.DataRows.Count - 1
                With DFGRGrid.DataRows(i)



                    If (Not .Cells("AFACCTNO").Value Is Nothing) Then
                        v_strAFACCTNO = .Cells("AFACCTNO").Value.ToString().Trim()
                    Else
                        v_strAFACCTNO = vbNullString
                    End If

                    If (Not .Cells("REF").Value Is Nothing) Then
                        V_strREF = .Cells("REF").Value.ToString().Trim()
                    Else
                        V_strREF = vbNullString
                    End If

                    If (Not .Cells("DTYPE").Value Is Nothing) Then
                        v_strDTYPE = .Cells("DTYPE").Value.ToString().Trim()
                    Else
                        v_strDTYPE = vbNullString
                    End If
                    If (Not .Cells("SYMBOL").Value Is Nothing) Then
                        v_strSYMBOL = .Cells("SYMBOL").Value.ToString().Trim()
                    Else
                        v_strSYMBOL = vbNullString
                    End If
                    If (Not .Cells("CODEID").Value Is Nothing) Then
                        v_strCODEID = gf_CorrectNumericField(.Cells("CODEID").Value.ToString().Trim())
                    Else
                        v_strCODEID = vbNullString
                    End If

                    If (Not .Cells("QTTY").Value Is Nothing) Then
                        v_QTTY = gf_CorrectNumericField(.Cells("QTTY").Value.ToString().Trim())
                    Else
                        v_QTTY = 0
                    End If
                    If (Not .Cells("DFPRICE").Value Is Nothing) Then
                        v_DFPRICE = gf_CorrectNumericField(.Cells("DFPRICE").Value.ToString().Trim())
                    Else
                        v_DFPRICE = 0
                    End If

                    If (Not .Cells("DFRATE").Value Is Nothing) Then
                        V_DFRATE = gf_CorrectNumericField(.Cells("DFRATE").Value.ToString().Trim())
                    Else
                        V_DFRATE = 0
                    End If
                    If (Not .Cells("AMT").Value Is Nothing) Then
                        v_AMT = gf_CorrectNumericField(.Cells("AMT").Value.ToString().Trim())

                    Else
                        v_AMT = 0
                    End If

                    If v_AMT > v_QTTY * v_DFPRICE Then
                        MsgBox(mv_ResourceManager.GetString("ERR_INV_AMOUNT"), MsgBoxStyle.Information, Me.Text)
                        Return False
                    End If

                    ' tblDFGRLOG.Rows.Add(Trim(mskACTYPE.Text), mv_strDFTYPE, 0, CurrentTime, CurrentTime, "9900111111", "0001", CDbl(Me.txtIRATE.Text), CDbl(Me.txtMRATE.Text), CDbl(Me.txtLRATE.Text), "1", "Y", Me.txtDescription.Text, v_strAFACCTNO, v_strDTYPE, v_strSYMBOL, v_strCODEID, v_QTTY, v_DFPRICE, v_AMT)
                    str_add = str_add & Trim(mskACTYPE.Text) & "|" & mv_strDFTYPE & "|" & v_ORGAMT & "|" & CurrentTime & "|" & Me.BusDate & "|" & "9900111111" & "|" & "0001" & "|" & CDbl(Me.txtIRATE.Text) & "|" & CDbl(Me.txtMRATE.Text) & "|" & CDbl(Me.txtLRATE.Text) & "|" & "1" & "|" & "Y" & "|" & Me.txtDescription.Text & "|" & v_strAFACCTNO & "|" & v_strDTYPE & "|" & v_strSYMBOL & "|" & v_strCODEID & "|" & v_QTTY & "|" & v_DFPRICE & "|" & V_DFRATE & "|" & v_AMT & "|" & str_DealGRAccount & "|" & v_strAUTODRAWNDOWN & "|" & v_strisapprove & "|" & v_strAFACCTNODRD & "|" & V_strREF & "|" & txtFeeAmt.Text & "|" & txtRefSide.Text & "|$"
                End With
            Next


            'Tạo điện giao dịch 2676- dung de tao deal tong giao dich
            LoadScreen("2676")
            v_strTxMsg = BuildXMLTxMsg(gc_MsgTypeTrans, gc_IsLocalMsg, "2676", Me.BranchId, Me.TellerId, Me.IpAddress, Me.WsName, , , , , , , , , , , , , , , , , Me.BusDate)
            v_xmlDocument.LoadXml(v_strTxMsg)
            v_dataElement = v_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "fields", "")
            If mv_arrObjFields.GetLength(0) > 0 Then
                For v_intIndex = 0 To mv_arrObjFields.GetLength(0) - 1 Step 1
                    If Not mv_arrObjFields(v_intIndex) Is Nothing Then
                        v_strFLDNAME = mv_arrObjFields(v_intIndex).FieldName
                        v_strDATATYPE = mv_arrObjFields(v_intIndex).DataType
                        Select Case Trim(v_strFLDNAME)
                            Case "03" 'AFACCTNO
                                v_strFLDVALUE = Me.mskAFACCTNO.Text.Replace(".", "")
                            Case "10"
                                v_strFLDVALUE = v_ORGAMT
                            Case "21"
                                v_strFLDVALUE = Trim(mskACTYPE.Text)
                            Case "20" 'GROUPID
                                v_strFLDVALUE = str_DealGRAccount
                            Case "06" 'STRDATA
                                v_strFLDVALUE = str_add
                            Case "30" 'DESC
                                v_strFLDVALUE = Me.txtDescription.Text
                                ' Me.txtDescription.Text = v_strDESC
                            Case "88"
                                v_strFLDVALUE = Me.mskCUSTODYCD.Text.Replace(".", "")
                            Case "90"
                                v_strFLDVALUE = mv_strFULLNAME
                            Case "91"
                                v_strFLDVALUE = Me.txtREFTXNUM.Text
                            Case "92"
                                v_strFLDVALUE = Me.dtpREFTXDATE.Value.ToString("dd/MM/yyyy")
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
        v_strCareByList = String.Empty

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

        If v_strCareByList.Length > 0 Then
            mv_GroupCareBy = v_strCareByList
        End If
    End Sub

    Protected Overridable Function InitDialog()
        'Thiết lập các thuộc tính ban đầu cho form
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strCmdSQL As String, v_strObjMsg As String
        Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode

        Dim v_strValue, v_strFLDNAME, v_strTXSTATUS, v_strDELTD As String

        Dim i, j As Integer
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

            Me.mskAFACCTNO.BackColor = System.Drawing.Color.GreenYellow
            Me.mskAFACCTNO.Mask = "9999.999999"
            Me.mskAFACCTNO.MaskCharInclude = False

            Me.mskACTYPE.BackColor = System.Drawing.Color.GreenYellow
            Me.mskACTYPE.Mask = "9999"
            Me.mskACTYPE.MaskCharInclude = False

            Me.mskCUSTODYCD.BackColor = System.Drawing.Color.GreenYellow
            Me.mskCUSTODYCD.Mask = "cccc.cccccc"
            Me.mskCUSTODYCD.MaskCharInclude = False

            Me.mskDFFeeMap.BackColor = System.Drawing.Color.GreenYellow
            Me.mskACTYPE.Mask = "9999"
            Me.mskACTYPE.MaskCharInclude = False

            Me.txtContraCus.BackColor = System.Drawing.Color.GreenYellow
            Me.txtContraCus.Mask = "9999.999999.999999"
            'If UpcomOrder Then
            '    v_strCmdSQL = "SELECT CODEID VALUE, SYMBOL DISPLAY FROM SBSECURITIES where HALT <> 'Y' AND  SECTYPE <>'004' AND TRADEPLACE='005'  ORDER BY DISPLAY"
            '    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            '    v_ws.Message(v_strObjMsg)
            '    SYMBOLLIST = v_strObjMsg
            'Else
            '    If SYMBOLLIST.Length <= 0 Then
            '        v_strCmdSQL = "SELECT CODEID VALUE, SYMBOL DISPLAY FROM SBSECURITIES where HALT <> 'Y' AND  SECTYPE <>'004'  ORDER BY DISPLAY"
            '        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            '        v_ws.Message(v_strObjMsg)
            '        SYMBOLLIST = v_strObjMsg
            '    End If
            'End If

            'FillComboEx(SYMBOLLIST, cboCODEID)
            'If cboCODEID.Items.Count > 0 Then cboCODEID.SelectedIndex = 0

            'Hiển thị mặc định cho Description
            Me.txtDescription.Text = mv_ResourceManager.GetString("txtDescription")

            If Me.TxDate.Length > 0 And Me.TxNum.Length > 0 Then
                'Me.AllowViewCF = False
                'ViewBalance(mv_blnAdvanceOrder)

                v_strCmdSQL = "SELECT TLTX.VOUCHERID,TLTX.TLTXCD, TLTX.TXDESC, TLTX.EN_TXDESC, TLTX.BGCOLOR, TLTX.BKDATE, TLTX.ACCTENTRY, TLLOG.TXSTATUS, TLLOG.BUSDATE, TLLOG.TXDESC LOGDESC,TLLOG.DELTD FROM TLTX, TLLOG " & ControlChars.CrLf _
                                           & "WHERE TLTX.TLTXCD=TLLOG.TLTXCD AND TXNUM='" & Me.TxNum & "' AND TXDATE=TO_DATE('" & Me.TxDate & "', '" & gc_FORMAT_DATE & "')"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLTX, gc_ActionInquiry, v_strCmdSQL)

                v_ws.Message(v_strObjMsg)
                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                For i = 0 To v_nodeList.Count - 1
                    For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            v_strValue = .InnerText.ToString
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME)
                                Case "TXSTATUS"
                                    mv_strTXSTATUS = Trim(v_strValue)
                                Case "DELTD"
                                    mv_strDELETE = Trim(v_strValue)
                            End Select
                        End With
                    Next
                Next

                ShowOfficerFunction()
                Viewgrpdeal(TxDate, TxNum)
                Me.lblAAMT.Visible = False
                Me.lblCIAdvance.Visible = False
                Me.lblTotalAmout.Visible = False
                Me.lblPPSE.Visible = False
                Me.lblTotal.Visible = False
                Me.lblPurchasingPower.Visible = False
                mv_dblOnload = False
                'Call DisplayConfirm()
                Exit Function
            End If


            If Me.KeyFieldName.Length > 0 Then

                'Me.AllowViewCF = False
                'ViewBalance(mv_blnAdvanceOrder)
                ShowOfficerFunction()

                Viewgrpdeal(KeyFieldValue.Substring(0, 9), KeyFieldValue.Substring(10, 10))
                Me.btnApprove.Visible = True
                Me.btnReject.Visible = True
                Me.lblAAMT.Visible = False
                Me.lblCIAdvance.Visible = False
                Me.lblTotalAmout.Visible = False
                Me.lblPPSE.Visible = False
                Me.lblTotal.Visible = False
                Me.lblPurchasingPower.Visible = False
                mv_dblOnload = False
                'Call DisplayConfirm()
                If Me.ExeFlag = ExecuteFlag.Edit Then
                    Dim v_ctl2 As Control
                    For Each v_ctl2 In Me.Controls
                        If TypeOf (v_ctl2) Is Button Then
                            v_ctl2.Enabled = True
                        Else
                            v_ctl2.Enabled = False
                        End If
                    Next
                End If
                Exit Function
            End If


            'Nếu là màn hình đặt lệnh AdvanceOrder (có tư vấn)
            If mv_blnAdvanceOrder Then
                'Khởi tạo màn hình đặt lệnh AdvanceOrder (có tư vấn)
                Call AdvanceOrderMode()
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
            End If

            If InitParam.Length > 0 Then
                BindInitParam()
            End If
            Me.lblREF.Visible = False
            Me.txtREF.Visible = False
            Me.btnGetDeal.Visible = False
            Me.txtREF.ReadOnly = True

            Me.lblAAMT.Visible = False
            Me.lblCIAdvance.Visible = False
            Me.lblTotalAmout.Visible = False
            Me.lblPPSE.Visible = False
            Me.lblTotal.Visible = False
            Me.lblPurchasingPower.Visible = False
            mv_dblOnload = False
            Me.ActiveControl = Me.mskCUSTODYCD
            If Me.TxDate.Length > 0 And Me.TxNum.Length > 0 Then
                'Me.AllowViewCF = False
                Viewgrpdeal(TxDate, TxNum)
            End If



        Catch ex As Exception

        End Try
    End Function
    Private Sub Viewgrpdeal(ByVal TxDate As String, ByVal TxNum As String)
        DFGRGrid.DataRows.Clear()
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_strValue, v_strFLDNAME, V_STRDT, l_ACTYPE, l_DFTYPE, l_AUTODRAWNDOWN, l_ISAPPROVE, l_DESCRIPTION, l_GROUPID, l_AFACCTNODRD, l_ref, l_custodycd As String
        Dim l_AFACCTNO, l_DTYPE, l_SYMBOL, l_CODEID, v_strSQL As String
        Dim l_IRATE, l_MRATE, l_LRATE, l_QTTY, l_DFPRICE, l_DFRATE, l_AMT, l_ORGAMT As Double


        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strCmdSQL As String, v_strObjMsg As String


        v_strCmdSQL = "SELECT max(decode(fldcd,'91',cvalue,null)) REFTXNUM,  max(decode(fldcd,'92',cvalue,null)) REFTXDATE FROM tllogfld WHERE TXNUM  = '" & TxNum & "' AND fldcd in ('91','92')"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
        v_ws.Message(v_strObjMsg)
        v_xmlDocument.LoadXml(v_strObjMsg)
        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

        For i As Integer = 0 To v_nodeList.Count - 1
            V_STRDT = String.Empty
            For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                With v_nodeList.Item(i).ChildNodes(j)
                    v_strValue = Trim(.InnerText.ToString)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    Select Case Trim(v_strFLDNAME)
                        Case "REFTXNUM"
                            Me.txtREFTXNUM.Text = Trim(v_strValue)
                        Case "REFTXDATE"
                            Me.dtpREFTXDATE.Value = CDate(v_strValue)
                    End Select
                End With
            Next
        Next


        v_strCmdSQL = "SELECT cvalue  STRDT FROM tllogfld WHERE TXNUM  = '" & TxNum & "' AND fldcd='06'"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
        v_ws.Message(v_strObjMsg)
        v_xmlDocument.LoadXml(v_strObjMsg)
        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

        For i As Integer = 0 To v_nodeList.Count - 1
            V_STRDT = String.Empty
            For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                With v_nodeList.Item(i).ChildNodes(j)
                    v_strValue = Trim(.InnerText.ToString)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    Select Case Trim(v_strFLDNAME)
                        Case "STRDT"
                            V_STRDT = v_strValue

                    End Select
                End With
            Next
        Next

        Dim v_arrGrp(), v_arrdeal(), v_strAftype As String
        v_arrGrp = V_STRDT.Split("$")
        v_arrdeal = V_STRDT.Split("|")

        For i As Integer = 0 To v_arrGrp.Length - 2
            v_arrdeal = v_arrGrp(i).Split("|")
            'Update database
            ' For j As Integer = 1 To v_arrdeal.Length - 2

            l_ACTYPE = CStr(v_arrdeal(0)).Trim
            l_DFTYPE = CStr(v_arrdeal(1)).Trim
            l_ORGAMT = CDbl(v_arrdeal(2))
            l_IRATE = CDbl(v_arrdeal(7))
            l_MRATE = CDbl(v_arrdeal(8))
            l_LRATE = CDbl(v_arrdeal(9))
            l_AUTODRAWNDOWN = CStr(v_arrdeal(10)).Trim
            l_ISAPPROVE = CStr(v_arrdeal(11)).Trim
            l_DESCRIPTION = CStr(v_arrdeal(12)).Trim
            l_AFACCTNO = CStr(v_arrdeal(13)).Trim
            l_DTYPE = CStr(v_arrdeal(14)).Trim
            l_SYMBOL = CStr(v_arrdeal(15)).Trim
            l_QTTY = CDbl(v_arrdeal(17))
            l_DFPRICE = CDbl(v_arrdeal(18))
            l_DFRATE = CDbl(v_arrdeal(19))
            l_AMT = CDbl(v_arrdeal(20))
            l_GROUPID = CStr(v_arrdeal(21)).Trim
            l_AUTODRAWNDOWN = CStr(v_arrdeal(22)).Trim
            l_ISAPPROVE = CStr(v_arrdeal(23)).Trim
            l_AFACCTNODRD = CStr(v_arrdeal(25)).Trim
            'l_ref = CStr(v_arrdeal(26)).Trim
            ' GAN GIA TRI
            Me.mskACTYPE.Text = l_ACTYPE
            Me.mskAFACCTNO.Text = l_AFACCTNO
            Me.cboAFACCTNODRD.Text = l_AFACCTNODRD
            Me.cboAFACCCBO.Text = l_AFACCTNO
            Me.cboCODEID.Text = l_SYMBOL
            Me.txtTOLAMT.Text = FormatNumber(l_ORGAMT, 0)
            Me.txtIRATE.Text = l_IRATE
            Me.txtLRATE.Text = l_LRATE
            Me.txtMRATE.Text = l_MRATE
            Me.txtDescription.Text = l_DESCRIPTION

            Dim v_xDataRow As Xceed.Grid.DataRow = DFGRGrid.DataRows.AddNew()
            v_xDataRow.Cells("AFACCTNO").Value = l_AFACCTNO
            ' v_xDataRow.Cells("REF").Value = Trim(Me.txtREF.Text)
            v_xDataRow.Cells("SYMBOL").Value = cboCODEID.Text
            v_xDataRow.Cells("CODEID").Value = l_CODEID
            v_xDataRow.Cells("QTTY").Value = l_QTTY
            v_xDataRow.Cells("DFPRICE").Value = l_DFPRICE
            v_xDataRow.Cells("AMT").Value = l_AMT
            v_xDataRow.Cells("DFRATE").Value = l_DFRATE
            v_xDataRow.EndEdit()
            DFGRGrid.EndInit()

        Next

        If l_AUTODRAWNDOWN = 1 Then
            Me.chkAUTODRAWNDOWN.Checked = True
        Else
            Me.chkAUTODRAWNDOWN.Checked = False
        End If

        'If l_ISAPPROVE = "Y" Then
        'Me.chkisapprove.Checked = True
        'Else
        Me.chkisapprove.Checked = False
        ' End If
        Me.btnAdd.Visible = False
        Me.btnDEL.Visible = False




        v_strSQL = "SELECT CF.CUSTODYCD FROM CFMAST CF, AFMAST AF WHERE AF.CUSTID= CF.CUSTID AND  AF.ACCTNO = '" & Me.mskAFACCTNO.Text.Replace(".", "") & "'"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SE_SEMAST, gc_ActionInquiry, v_strSQL)
        v_ws.Message(v_strObjMsg)
        v_xmlDocument.LoadXml(v_strObjMsg)
        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

        For i As Integer = 0 To v_nodeList.Count - 1
            For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                With v_nodeList.Item(i).ChildNodes(j)
                    v_strValue = .InnerText.ToString
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    Select Case Trim(v_strFLDNAME)
                        Case "CUSTODYCD"
                            l_custodycd = Trim(v_strValue)

                    End Select
                End With
            Next
        Next

        Me.mskCUSTODYCD.Text = l_custodycd





    End Sub

    Private Sub BindInitParam()
        Dim v_arrParam As String() = mv_InitParam.Split("|".ToCharArray())
        Dim v_arrParamVal As String()
        If v_arrParam.GetLength(0) > 0 Then
            Try
                For i As Integer = 0 To v_arrParam.GetLength(0) - 1
                    v_arrParamVal = v_arrParam(i).Split("#".ToCharArray())
                    If v_arrParamVal.GetLength(0) = 2 Then
                        If v_arrParam(i).IndexOf("CONTRACTNO") >= 0 Then
                            mskAFACCTNO.Text = v_arrParamVal(1).Replace(".", "")
                        ElseIf v_arrParam(i).IndexOf("SYMBOL") >= 0 Then
                            Dim v_ds As DataTable = cboCODEID.ComboSource
                            Dim v_CodeID As String = ""
                            For j As Integer = 0 To v_ds.Rows.Count - 1
                                If CStr(v_ds.Rows(j)("DISPLAY")).ToUpper().Trim() = v_arrParamVal(1).ToUpper().Trim() Then
                                    v_CodeID = CStr(v_ds.Rows(j)("VALUE"))
                                    Exit For
                                End If
                            Next
                            cboCODEID.SelectedValue = v_CodeID
                        ElseIf v_arrParam(i).IndexOf("QUANTITY") >= 0 Then
                            txtDFPrice.Text = v_arrParamVal(1).Replace(",", "")
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
            v_strCmdSQL = " SELECT MR.MRTYPE,MR.ISPPUSED, NVL(RSK.MRRATIOLOAN,0) MRRATIOLOAN, NVL(MRPRICELOAN,0) MRPRICELOAN FROM AFMAST MST, AFTYPE AF, MRTYPE MR, (SELECT * FROM AFSERISK WHERE CODEID='" & v_strCODEID & "' ) RSK WHERE MST.ACCTNO ='" & v_strAFACCTNO & "' AND MST.ACTYPE=AF.ACTYPE AND AF.MRTYPE =MR.ACTYPE AND AF.ACTYPE =RSK.ACTYPE(+) "
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
                            Case "MRRATIOLOAN"
                                mv_dblMarginRatioRate = CDec(Trim(v_strValue))
                            Case "MRPRICELOAN"
                                mv_dblSecMarginPrice = CDec(Trim(v_strValue))
                            Case "ISPPUSED" '1: PPSE   0: PP0
                                mv_dblIsPPUsed = CDec(Trim(v_strValue))
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

    Private Sub AdvanceOrderMode()
        'Khởi tạo màn hình đặt lệnh Advance Order (có tư vấn)
        ViewBalance(AllowViewCF)

        txtDescription.Enabled = True

    End Sub

    Private Sub DisplayButton()
        Dim v_btn() As Button
        Dim i As Integer
        Dim v_intLeft As Integer
        ReDim v_btn(2)
        v_btn(0) = btnCANCEL
        v_btn(1) = btnOK
        v_btn(2) = btnAdjust
        v_intLeft = BTN_ROOT_LEFT
        For i = 0 To 2
            v_btn(i).Left = v_intLeft
            v_intLeft = v_intLeft - (BTN_WIDTH + BTN_GAP)
        Next

    End Sub

    Private Sub ShowAdjustButton(ByVal pv_Enable As Boolean)
        DisplayButton()
        If pv_Enable Then
            mskAFACCTNO.Enabled = False
            mskCUSTODYCD.Enabled = False
            mskACTYPE.Enabled = False
            cboCODEID.Enabled = False
            txtQuantity.Enabled = False
            txtRefPrice.Enabled = False
            txtDFPrice.Enabled = False
            txtTRIGPRICE.Enabled = False
            txtDFRATE.Enabled = False
            txtIRATE.Enabled = False
            txtLRATE.Enabled = False
            txtMRATE.Enabled = False
            txtREF.Enabled = False
            txtDescription.Enabled = False
            'chkAUTODRAWNDOWN.Enabled = True
            'chkisapprove.Enabled = False
            txtDFAMT.Enabled = False
            cboRefPrice.Enabled = False
            cboAFACCCBO.Enabled = False
            chkENDNEWDEAL.Enabled = False
            btnAdjust.Visible = True
            btnAdjust.Enabled = True
        Else
            btnOK.Visible = True
            btnOK.Enabled = True
            btnAdjust.Visible = False
            btnAdjust.Enabled = False
            mskCUSTODYCD.Enabled = True
            mskAFACCTNO.Enabled = True
            'mskAFACCTNO.Focus()
            mskAFACCTNO.SelectAll()
            mskACTYPE.Enabled = True
            'cboCODEID.Enabled = True
            txtQuantity.Enabled = True
            txtRefPrice.Enabled = True
            txtDFPrice.Enabled = True
            txtTRIGPRICE.Enabled = True
            txtDescription.Enabled = True
            'chkAUTODRAWNDOWN.Enabled = True
            'chkisapprove.Enabled = False
            txtDFAMT.Enabled = True
            cboRefPrice.Enabled = True
            cboAFACCCBO.Enabled = True
            chkENDNEWDEAL.Enabled = True
        End If
    End Sub

    Private Sub ResetDeleteButton()

        btnOK.Top = btnCANCEL.Top
        btnOK.Left = btnCANCEL.Left - btnCANCEL.Width - 10
        btnOK.Visible = True
        btnOK.Enabled = True

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
            'pnBalance.Top = CONTROL_PNL_BALANCE_TOP
            'pnContractInfo.Top = CONTROL_PNL_CONTRACT_TOP
            'pnDFGR.Top = CONTROL_PNL_DFGRP_TOP
            'btnOK.Top = pnContractInfo.Bottom + 5 'CONTROL_BUTTON_TOP
            'btnCANCEL.Top = btnOK.Top
            'Me.Height = FRM_EXTEND_HEIGHT

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
                pnUpcomInfo.Visible = True
                pnUpcomInfo.Top = CONTROL_PNL_EXTENDINFO_TOP
            Else
                pnUpcomInfo.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ResetControl(ByRef pv_ctrl As Windows.Forms.Control)
        Dim v_ctrl As Windows.Forms.Control
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
        'Hiển thị mặc định cho Description
        'Me.txtDescription.Text = "Orders making"
        'Me.btnDelete.Text = "&Correct"
        picSignature.Image = Nothing
        mv_strDEALACTYPE = ""
        mv_strDEALTYPE = ""

        MemberGrid.DataRows.Clear()
        SEMemberGrid.DataRows.Clear()
        DFGRGrid.DataRows.Clear()
        GetSecuritiesInfo(Me.cboCODEID.SelectedValue)


        If IIf(IsDBNull(Len(AccountNumber)), 0, Len(AccountNumber)) > 0 Then
            Me.mskAFACCTNO.Text = Me.AccountNumber
            Me.mskAFACCTNO.ReadOnly = True
        End If
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
            If mv_strTXSTATUS = TransactStatus.Pending And mv_strDELETE <> "Y" Then
                btnApprove.Top = btnOK.Top
                btnApprove.Left = btnOK.Left


                btnApprove.Visible = True
                btnApprove.Enabled = True

                btnApprove.Focus()
            ElseIf mv_strTXSTATUS = TransactStatus.Rejected Then

                '  pnOrder.Enabled = True
                pnOrder.Enabled = False
                pnOrder.Enabled = True



                mskAFACCTNO.Enabled = True
            End If

            mv_blnShowOfficerFunction = True
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

            Dim v_strSQL As String = "SELECT SIG.AUTOID,SIG.CUSTID,SIG.SIGNATURE FROM CFSIGN SIG WHERE SIG.CUSTID='" & pv_strCUSTID & "'"
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
                Me.txtDescription.Text = mv_ResourceManager.GetString("txtDescription")
            End If

            If mv_strLastAFACCTNO <> v_strAFACCTNO Then
                Dim v_nodeList As Xml.XmlNodeList
                Dim v_xmlDocument As New Xml.XmlDocument
                Dim v_strValue, v_strFLDNAME, v_strTEXT As String, i, j As Integer
                Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                Dim v_strCmdSQL, v_strClause As String, v_strObjMsg As String
                'Chuyen sang dung procedure
                v_strCmdSQL = "GETACCOUNTINFO"
                v_strClause = "AFACCTNO!" & v_strAFACCTNO & "!varchar2!20^INDATE!" & mv_strBusDate & "!varchar2!20"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strCmdSQL, v_strClause, , , , , , , gc_CommandProcedure)
                v_ws.Message(v_strObjMsg)
                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

                v_strTEXT = v_strAFACCTNO

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
                                    mv_strLICENCE = v_strValue
                                Case "FULLNAME"
                                    If Len(v_strTEXT) = 0 Then
                                        v_strTEXT = v_strValue
                                    Else
                                        v_strTEXT = v_strTEXT & ", " & v_strValue
                                    End If
                                    mv_strFULLNAME = v_strValue
                                Case "ADDRESS"
                                    mv_strADDRESS = v_strValue
                                    'Case "TERM"
                                    '    If Len(v_strTEXT) = 0 Then
                                    '        v_strTEXT = v_strValue
                                    '    Else
                                    '        v_strTEXT = v_strTEXT & ", " & v_strValue
                                    '    End If
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
                                    If Len(Trim(v_strValue)) = 0 Or v_strValue = "0" Then
                                        mv_dblAvlLimit = 0
                                    Else
                                        mv_dblAvlLimit = CDbl(v_strValue)
                                    End If
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
                'GetSecuritiesInfo(Me.cboCODEID.SelectedValue)
                SetPPSE()

                'Fill dữ liệu vào Grid
                If v_nodeList.Count > 0 Then
                    'Lấy thông tin chữ ký, uy quyen voi lenh tai Floor
                    If mskAFACCTNO.ReadOnly = False Then
                        LoadCFSign(mv_strCUSTID)
                        GetAFLinkAuth(v_strAFACCTNO)
                    End If

                    If mv_blnAdvanceOrder Then
                        GetSEMemberGrid(v_strAFACCTNO, Trim(Me.mskACTYPE.Text))
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

    Private Sub setValueByCalltype()
        If mv_strCALLTYPE = "R" Then

            If mv_strIsADVCASH = "Y" Then
                Me.txtDFPrice.Text = CDbl(Me.txtDFRATE.Text) / 100 * CDbl(Me.txtRefPrice.Text)
                Me.txtTRIGPRICE.Text = CDbl(Me.txtLRATE.Text) / 100 * CDbl(Me.txtRefPrice.Text)
            Else
                Me.txtDFPrice.Text = FRound(CDbl(Me.txtDFRATE.Text) / 100 * CDbl(Me.txtRefPrice.Text))
                Me.txtTRIGPRICE.Text = FRound(CDbl(Me.txtLRATE.Text) / 100 * CDbl(Me.txtRefPrice.Text))
            End If
            
        End If
    End Sub

    Private Sub GetDFType(ByVal v_strACTYPE As String)
        Dim v_strCODEID As String = Me.cboCODEID.Text
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_strValue, v_strFLDNAME, v_strTEXT As String, i, j As Integer
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strCmdSQL, v_strObjMsg As String
        Try
            'Chỉ nạp lại nếu nhập loại hình mới            
            If mv_strDEALACTYPE <> v_strACTYPE Then
                txtFeeRate.Text = "0"
                txtFeeAmt.Text = "0"
                mv_feeamt = 0
                mskDFFeeMap.Text = ""
                mv_strDEALACTYPE = v_strACTYPE
                Me.Label1.Text = ""

                mv_blnComboSymboLoad = True
                v_strCmdSQL = " SELECT  A.CODEID VALUE, A.SYMBOL DISPLAY FROM SBSECURITIES A, DFTYPE B, DFBASKET C " & ControlChars.CrLf _
                            & " WHERE   A.HALT <> 'Y' AND  A.SECTYPE <>'004' AND A.SYMBOL = C.SYMBOL AND B.BASKETID = C.BASKETID " & ControlChars.CrLf _
                            & " AND B.ACTYPE = '" & v_strACTYPE & "' AND B.STATUS <>'N' AND APPRV_STS = 'A'" & ControlChars.CrLf _
                            & " ORDER BY DISPLAY"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strCmdSQL)
                v_ws.Message(v_strObjMsg)

                'FillComboEx(v_strObjMsg, cboCODEID)
                FillComboDataSource(v_strObjMsg, cboCODEID)
                If cboCODEID.Items.Count > 0 Then
                    cboCODEID.SelectedIndex = 0
                Else
                    MsgBox(mv_ResourceManager.GetString("DFTYPEINVALID"), MsgBoxStyle.Information, Me.Text)
                    Me.ActiveControl = Me.mskACTYPE
                    Me.mskACTYPE.Text = ""
                    Exit Sub
                End If


                If cboCODEID.SelectedIndex >= 0 Then
                    v_strCmdSQL = "  SELECT a.BASKETID,a.SYMBOL,  " & ControlChars.CrLf _
                            & "  (case when a.REFPRICE<=0 then inf.DFRLSPRICE else a.REFPRICE end) REFPRICE,  " & ControlChars.CrLf _
                            & "  (case when a.DFPRICE <=0 then round((case when a.REFPRICE<=0 then inf.DFRLSPRICE else a.REFPRICE end)* a.dfrate/100,0) else a.DFPRICE end) DFPRICE ,  " & ControlChars.CrLf _
                            & "  (case when a.TRIGGERPRICE<=0 then round((case when a.REFPRICE<=0 then inf.DFRLSPRICE else a.REFPRICE end)* a.lrate/100,0) else a.TRIGGERPRICE end) TRIGGERPRICE ,  " & ControlChars.CrLf _
                            & "  a.DFRATE,  " & ControlChars.CrLf _
                            & "  b.IRATE,  " & ControlChars.CrLf _
                            & "  b.MRATE,  " & ControlChars.CrLf _
                            & "  b.LRATE,  " & ControlChars.CrLf _
                            & "  a.CALLTYPE,  " & ControlChars.CrLf _
                            & "  lnt.RRTYPE, b.OPTPRICE, b.LIMITCHK, lnt.CUSTBANK, lnt.CIACCTNO,  " & ControlChars.CrLf _
                            & "  a.IMPORTDT, B.TYPENAME, B.DFTYPE,B.AUTODRAWNDOWN ,B.isapprove,CD.CDCONTENT DFNAME,CD3.CDCONTENT CALLTYPENAME, B.ISVSD,  " & ControlChars.CrLf _
                            & "  b.ISADVCASH " & ControlChars.CrLf _
                            & "  FROM DFBASKET A, DFTYPE B, LNTYPE lnt, securities_info inf ,ALLCODE CD, ALLCODE CD3    " & ControlChars.CrLf _
                            & "  WHERE A.BASKETID = B.BASKETID AND B.ACTYPE = '" & Me.mskACTYPE.Text.ToString.Trim & "' AND B.STATUS <>'N' AND A.SYMBOL = '" & Me.cboCODEID.Text & "'  " & ControlChars.CrLf _
                            & " AND CD.CDTYPE ='DF' AND CD.CDNAME ='DFTYPE' AND CD.CDVAL =B.DFTYPE" & ControlChars.CrLf _
                            & " AND CD3.CDTYPE ='DF' AND CD3.CDNAME ='CALLTYPE' AND CD3.CDVAL =a.CALLTYPE" & ControlChars.CrLf _
                            & " and a.symbol = inf.symbol and b.lntype = lnt.actype and rownum=1"
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strCmdSQL)
                    v_ws.Message(v_strObjMsg)
                    v_xmlDocument.LoadXml(v_strObjMsg)
                    v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

                    For i = 0 To v_nodeList.Count - 1
                        For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                            With v_nodeList.Item(i).ChildNodes(j)
                                v_strValue = Trim(.InnerText.ToString)
                                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                Select Case Trim(v_strFLDNAME)
                                    Case "REFPRICE"
                                        mv_strBASICPRICE = v_strValue
                                        Me.txtRefPrice.Text = v_strValue.ToString()
                                    Case "DFPRICE"
                                        Me.txtDFPrice.Text = v_strValue.ToString()
                                        mv_strDFPRICE = v_strValue.ToString()
                                    Case "TRIGGERPRICE"
                                        Me.txtTRIGPRICE.Text = v_strValue.ToString()
                                        mv_strTRIGGERPRICE = v_strValue.ToString()
                                    Case "DFRATE" '"BALANCE"
                                        Me.txtDFRATE.Text = v_strValue.ToString()
                                    Case "IRATE"
                                        Me.txtIRATE.Text = v_strValue.ToString()
                                        Me.txtDFIRATE.Text = v_strValue.ToString()
                                    Case "MRATE"
                                        Me.txtMRATE.Text = v_strValue.ToString()
                                        Me.txtDFMRATE.Text = v_strValue.ToString()
                                    Case "LRATE"
                                        Me.txtLRATE.Text = v_strValue.ToString()
                                        Me.txtDFLRATE.Text = v_strValue.ToString()
                                    Case "CALLTYPE"
                                        mv_strCALLTYPE = v_strValue.ToString()
                                    Case "DFTYPE"
                                        mv_strDFTYPE = v_strValue.ToString()
                                    Case "TYPENAME"
                                        mv_strDFTYPENAME = v_strValue
                                        Me.Label1.Text = Me.Label1.Text & v_strValue.ToString() & ControlChars.CrLf
                                        Me.txtDescription.Text = v_strValue
                                        mv_desc = v_strValue
                                    Case "DFNAME"
                                        Me.Label1.Text = Me.Label1.Text & v_strValue.ToString() & ControlChars.CrLf
                                    Case "CALLTYPENAME"
                                        Me.Label1.Text = Me.Label1.Text & v_strValue.ToString() & ControlChars.CrLf
                                    Case "RRNAME"
                                        Me.Label1.Text = Me.Label1.Text & v_strValue.ToString() & ControlChars.CrLf
                                        mv_strRRNAME = v_strValue.ToString
                                    Case "CUSTBANK"
                                        mv_strCUSTBANK = v_strValue.ToString
                                    Case "CIACCTNO"
                                        mv_strCIACCTNO = v_strValue.ToString
                                    Case "RRTYPE"
                                        mv_strRRTYPE = v_strValue.ToString
                                    Case "LIMITCHK"
                                        mv_strLIMITCHK = v_strValue.ToString
                                    Case "OPTPRICE"
                                        mv_strOPTPRICE = v_strValue.ToString
                                    Case "AUTODRAWNDOWN"
                                        Me.chkAUTODRAWNDOWN.Checked = True
                                    Case "ISAPPROVE"
                                        Me.chkisapprove.Checked = False
                                    Case "ISVSD"
                                        mv_strOLDISVSD = mv_strISVSD
                                        mv_strISVSD = v_strValue.ToString
                                    Case "ISADVCASH" '16/11/2017 DieuNDA: them bien co phai loai hinh UTCT hay khong 
                                        mv_strIsADVCASH = v_strValue.ToString
                                End Select
                            End With
                        Next
                    Next

                    If mv_strOLDISVSD <> mv_strISVSD Then
                        DFGRGrid.DataRows.Clear()
                    End If

                    If mv_strDFTYPE = "L" And mv_strMarginType = "N" Then
                        'Neu la tai khoan thuong thi khong cho lam margin loan
                        MsgBox(mv_ResourceManager.GetString("NOMAL_CANNOT_MAKE_ML"), MsgBoxStyle.Information, Me.Text)
                        Me.mskACTYPE.Clear()
                        Me.mskACTYPE.Focus()
                        Exit Sub
                    End If

                    'Lấy mặc định giá theo rổ
                    Me.cboRefPrice.Clears()
                    Me.cboRefPrice.AddItems(mv_strBASICPRICE, BASICPRICE)
                    Me.cboRefPrice.SelectedIndex = 0
                    SetDealInfoByRefPrice()
                    Me.txtREF.Text = ""
                    Me.txtQuantity.Text = ""
                    If mv_strDFTYPE = "B" Or mv_strDFTYPE = "F" Or mv_strDFTYPE = "L" Then
                        Me.btnGetDeal.Visible = False
                        Me.lblREF.Visible = False
                        Me.txtREF.Visible = False
                        If mv_strDFTYPE <> "F" Then
                            Me.cboCODEID.Enabled = False
                        Else
                            'Chỉ enabled cho chọn CK nếu loại hình là Forward ck giao dịch/cầm cố
                            'Trường giá tham chiếu bị disabled cho phải theo QĐ chung
                            'Me.cboCODEID.Enabled = True
                        End If
                    Else
                        'Thực hiện cầm cố: trường giá tham chiếu bị disabled cho phải theo QĐ chung
                        Me.btnGetDeal.Visible = False
                        Me.lblREF.Visible = False
                        Me.txtREF.Visible = False
                        'Me.cboCODEID.Enabled = True
                    End If

                    If mv_strDFTYPE = "M" Then
                        'Hop dong cam co thi khong giai ngan ngay
                        Me.chkAUTODRAWNDOWN.Checked = True
                        'Me.chkAUTODRAWNDOWN.Visible = False
                    Else
                        'Me.chkAUTODRAWNDOWN.Visible = True
                    End If
                    If mv_strLIMITCHK = "N" Then
                        'Neu khong check han muc thi khong cho thay doi thonag tin Tu dong giai ngan
                        'Me.chkAUTODRAWNDOWN.Enabled = True
                    End If

                    Select Case mv_strDFTYPE
                        Case "F" ' 	Forward
                            mv_strTypeCondition = " ('N','R') "
                        Case "B" ' 	Block forward
                            mv_strTypeCondition = " ('B','P') "
                        Case "M" ' Mortgage
                            mv_strTypeCondition = " ('N') "
                        Case "L" 'Margin loan
                            mv_strTypeCondition = " ('R') "
                        Case Else
                            mv_strTypeCondition = " ('N','R','P','B','T') "
                    End Select

                    'Nguồn giải ngân
                    If mv_strRRTYPE <> "C" Then
                        Me.txtDFRATE.Enabled = False
                        Me.txtIRATE.Enabled = False
                        Me.txtMRATE.Enabled = False
                        Me.txtLRATE.Enabled = False
                    Else
                        If mv_strCALLTYPE = "P" Then
                            Me.txtDFRATE.Enabled = False
                            Me.txtIRATE.Enabled = False
                            Me.txtMRATE.Enabled = False
                            Me.txtLRATE.Enabled = False
                        Else
                            Me.txtDFRATE.Enabled = True
                            Me.txtIRATE.Enabled = True
                            Me.txtMRATE.Enabled = True
                            Me.txtLRATE.Enabled = True
                            If mv_strIsADVCASH = "Y" Then
                                '16/11/2017 DieuNDA: Neu la UTCT thi khong cho sua ty le 
                                txtDFRATE.Enabled = False
                            Else
                                txtDFRATE.Enabled = True
                            End If
                        End If
                    End If
                    GetSEMemberGrid(Trim(mskAFACCTNO.Text), Trim(Me.mskACTYPE.Text))
                End If
            End If
            mv_blnComboSymboLoad = False
        Catch ex As Exception
            'MsgBox(ex.Message, MsgBoxStyle.Information, Me.Text)
        Finally
            mv_blnComboSymboLoad = False
        End Try
    End Sub
    'Them Interface trong truong hop co them ma chung khoan
    Private Sub GetDFType(ByVal v_strACTYPE As String, ByVal v_strCODEID As String)
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_strValue, v_strFLDNAME, v_strTEXT As String, i, j As Integer
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strCmdSQL, v_strObjMsg As String
        Try
            'Chỉ nạp lại nếu nhập loại hình mới
            'If mv_strDEALACTYPE <> v_strACTYPE Then
            mv_strDEALACTYPE = v_strACTYPE
            Me.Label1.Text = ""

            'reset khoi luong
            mv_dblDFQTTY = mv_dblORGDFQTTY
            mv_dblBLOCKQTTY = mv_dblORGBLOCKQTTY
            mv_dblCARCVQTTY = mv_dblORGCARCVQTTY
            mv_dblRCVQTTY = mv_dblORGRCVQTTY

            mv_blnComboSymboLoad = True

            v_strCmdSQL = " SELECT  A.CODEID VALUE, A.SYMBOL DISPLAY FROM SBSECURITIES A, DFTYPE B, DFBASKET C " & ControlChars.CrLf _
                        & " WHERE   A.HALT <> 'Y' AND  A.SECTYPE <>'004' AND A.SYMBOL = C.SYMBOL AND B.BASKETID = C.BASKETID " & ControlChars.CrLf _
                        & " AND B.ACTYPE = '" & v_strACTYPE & "' AND B.STATUS <>'N' AND A.CODEID = '" & v_strCODEID & "'" & ControlChars.CrLf _
                        & " ORDER BY DISPLAY"

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)

            'FillComboEx(v_strObjMsg, cboCODEID)
            FillComboDataSource(v_strObjMsg, cboCODEID)
            If cboCODEID.Items.Count > 0 Then
                cboCODEID.SelectedIndex = 0
            Else
                'Loi do ko link duoc vao dfbasket & do la thanh ly tai ky. Chon symbol mac dinh.
                If chkENDNEWDEAL.Checked Then
                    v_strCmdSQL = " SELECT  A.CODEID VALUE, A.SYMBOL DISPLAY FROM SBSECURITIES A " & ControlChars.CrLf _
                            & " WHERE   A.HALT <> 'Y' AND  A.SECTYPE <>'004' " & ControlChars.CrLf _
                            & " AND A.CODEID = '" & v_strCODEID & "'" & ControlChars.CrLf _
                            & " ORDER BY DISPLAY"
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strCmdSQL)
                    v_ws.Message(v_strObjMsg)
                    FillComboDataSource(v_strObjMsg, cboCODEID)
                Else
                    MsgBox(mv_ResourceManager.GetString("DFTYPEINVALID"), MsgBoxStyle.Information, Me.Text)
                End If
                Me.ActiveControl = Me.mskACTYPE
                Me.mskACTYPE.Text = ""
                Exit Sub
            End If


            If cboCODEID.SelectedIndex >= 0 Then
                v_strCmdSQL = "  SELECT a.BASKETID,a.SYMBOL,  " & ControlChars.CrLf _
                        & "  (case when a.REFPRICE<=0 then inf.DFRLSPRICE else a.REFPRICE end) REFPRICE,  " & ControlChars.CrLf _
                        & "  (case when a.DFPRICE <=0 then round((case when a.REFPRICE<=0 then inf.DFRLSPRICE else a.REFPRICE end)* a.dfrate/100,0) else a.DFPRICE end) DFPRICE ,  " & ControlChars.CrLf _
                        & "  (case when a.TRIGGERPRICE<=0 then round((case when a.REFPRICE<=0 then inf.DFRLSPRICE else a.REFPRICE end)* a.lrate/100,0) else a.TRIGGERPRICE end) TRIGGERPRICE ,  " & ControlChars.CrLf _
                        & "  a.DFRATE,  " & ControlChars.CrLf _
                        & "  a.IRATE,  " & ControlChars.CrLf _
                        & "  a.MRATE,  " & ControlChars.CrLf _
                        & "  a.LRATE,  " & ControlChars.CrLf _
                        & "  a.CALLTYPE,  " & ControlChars.CrLf _
                        & "  lnt.RRTYPE, b.OPTPRICE, b.LIMITCHK, lnt.CUSTBANK, lnt.CIACCTNO,  " & ControlChars.CrLf _
                        & "  a.IMPORTDT, B.TYPENAME, B.DFTYPE,B.AUTODRAWNDOWN,B.ISAPPROVE,CD.CDCONTENT DFNAME,CD3.CDCONTENT CALLTYPENAME, CD2.CDCONTENT RRNAME, B.ISVSD,   " & ControlChars.CrLf _
                        & "  b.ISADVCASH " & ControlChars.CrLf _
                        & "  FROM DFBASKET A, DFTYPE B, LNTYPE lnt, securities_info inf ,ALLCODE CD,ALLCODE CD2, ALLCODE CD3    " & ControlChars.CrLf _
                        & "  WHERE A.BASKETID = B.BASKETID AND B.ACTYPE = '" & Me.mskACTYPE.Text.ToString.Trim & "' AND B.STATUS <>'N' AND A.SYMBOL = '" & Me.cboCODEID.Text & "'  " & ControlChars.CrLf _
                        & " AND CD.CDTYPE ='DF' AND CD.CDNAME ='DFTYPE' AND CD.CDVAL =B.DFTYPE" & ControlChars.CrLf _
                        & " AND CD3.CDTYPE ='DF' AND CD3.CDNAME ='CALLTYPE' AND CD3.CDVAL =a.CALLTYPE" & ControlChars.CrLf _
                        & " AND CD2.CDTYPE ='DF' AND CD2.CDNAME ='RRTYPE' AND CD2.CDVAL =B.RRTYPE " & ControlChars.CrLf _
                        & " and a.symbol = inf.symbol and b.lntype = lnt.actype "
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strCmdSQL)
                v_ws.Message(v_strObjMsg)
                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

                For i = 0 To v_nodeList.Count - 1
                    For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            v_strValue = Trim(.InnerText.ToString)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME)
                                Case "REFPRICE"
                                    mv_strBASICPRICE = v_strValue
                                    Me.txtRefPrice.Text = v_strValue.ToString()
                                Case "DFPRICE"
                                    Me.txtDFPrice.Text = v_strValue.ToString()
                                    mv_strDFPRICE = v_strValue.ToString()
                                Case "TRIGGERPRICE"
                                    Me.txtTRIGPRICE.Text = v_strValue.ToString()
                                    mv_strTRIGGERPRICE = v_strValue.ToString()
                                Case "DFRATE" '"BALANCE"
                                    Me.txtDFRATE.Text = v_strValue.ToString()
                                Case "IRATE"
                                    Me.txtIRATE.Text = v_strValue.ToString()
                                Case "MRATE"
                                    Me.txtMRATE.Text = v_strValue.ToString()
                                Case "LRATE"
                                    Me.txtLRATE.Text = v_strValue.ToString()
                                Case "CALLTYPE"
                                    mv_strCALLTYPE = v_strValue.ToString()
                                Case "DFTYPE"
                                    mv_strDFTYPE = v_strValue.ToString()
                                Case "TYPENAME"
                                    mv_strDFTYPENAME = v_strValue
                                    Me.Label1.Text = Me.Label1.Text & v_strValue.ToString() & ControlChars.CrLf
                                    Me.txtDescription.Text = v_strValue
                                    mv_desc = v_strValue
                                Case "DFNAME"
                                    Me.Label1.Text = Me.Label1.Text & v_strValue.ToString() & ControlChars.CrLf
                                Case "CALLTYPENAME"
                                    Me.Label1.Text = Me.Label1.Text & v_strValue.ToString() & ControlChars.CrLf
                                Case "RRNAME"
                                    Me.Label1.Text = Me.Label1.Text & v_strValue.ToString() & ControlChars.CrLf
                                    mv_strRRNAME = v_strValue.ToString
                                Case "CUSTBANK"
                                    mv_strCUSTBANK = v_strValue.ToString
                                Case "CIACCTNO"
                                    mv_strCIACCTNO = v_strValue.ToString
                                Case "RRTYPE"
                                    mv_strRRTYPE = v_strValue.ToString
                                Case "LIMITCHK"
                                    mv_strLIMITCHK = v_strValue.ToString
                                Case "OPTPRICE"
                                    mv_strOPTPRICE = v_strValue.ToString
                                Case "AUTODRAWNDOWN"
                                    Me.chkAUTODRAWNDOWN.Checked = True
                                Case "ISAPPROVE"
                                    Me.chkisapprove.Checked = False
                                Case "ISVSD"
                                    mv_strISVSD = v_strValue.ToString
                                Case "ISADVCASH" '16/11/2017 DieuNDA: them bien co phai loai hinh UTCT hay khong 
                                    mv_strIsADVCASH = v_strValue.ToString
                            End Select
                        End With
                    Next
                Next


                If mv_strDFTYPE = "L" And mv_strMarginType = "N" Then
                    'Neu la tai khoan thuong thi khong cho lam margin loan
                    MsgBox(mv_ResourceManager.GetString("NOMAL_CANNOT_MAKE_ML"), MsgBoxStyle.Information, Me.Text)
                    Me.mskACTYPE.Clear()
                    Me.mskACTYPE.Focus()
                    Exit Sub
                End If


                Me.cboRefPrice.Clears()
                If mv_dblRCVQTTY <> 0 Then
                    Me.cboRefPrice.AddItems(mv_dblMATCHPRICE.ToString(), MATCHPRICE)
                End If
                Me.cboRefPrice.AddItems(mv_strBASICPRICE, BASICPRICE)
                If mv_strOPTPRICE = "O" OrElse mv_strOPTPRICE = "A" Then
                    Me.cboRefPrice.AddItems(mv_ResourceManager.GetString(OTHERS), OTHERS)
                End If
                Me.cboRefPrice.SelectedIndex = 0
                SetDealInfoByRefPrice()
                'Me.txtREF.Text = ""
                'Me.txtQuantity.Text = ""
                'If mv_strDFTYPE = "B" Or mv_strDFTYPE = "F" Or mv_strDFTYPE = "L" Then
                '    Me.btnGetDeal.Visible = True
                '    Me.lblREF.Visible = True
                '    Me.txtREF.Visible = True
                '    If mv_strDFTYPE <> "F" Then
                '        Me.cboCODEID.Enabled = False
                '    Else
                '        'Chỉ enabled cho chọn CK nếu loại hình là Forward ck giao dịch/cầm cố
                '        'Trường giá tham chiếu bị disabled cho phải theo QĐ chung
                '        Me.cboCODEID.Enabled = True
                '    End If
                'Else
                '    'Thực hiện cầm cố: trường giá tham chiếu bị disabled cho phải theo QĐ chung
                '    Me.btnGetDeal.Visible = False
                '    Me.lblREF.Visible = False
                '    Me.txtREF.Visible = False
                '    Me.cboCODEID.Enabled = True
                'End If

                'If mv_strDFTYPE = "M" Then
                '    'Hop dong cam co thi khong giai ngan ngay
                '    Me.chkAUTODRAWNDOWN.Checked = False
                '    Me.chkAUTODRAWNDOWN.Visible = False
                'Else
                '    Me.chkAUTODRAWNDOWN.Visible = True
                'End If
                'If mv_strLIMITCHK = "N" Then
                '    'Neu khong check han muc thi khong cho thay doi thonag tin Tu dong giai ngan
                '    Me.chkAUTODRAWNDOWN.Enabled = False
                'End If

                Select Case mv_strDFTYPE
                    Case "F" ' 	Forward
                        mv_strTypeCondition = " ('N','R') "
                    Case "B" ' 	Block forward
                        mv_strTypeCondition = " ('B','P') "
                    Case "M" ' Mortgage
                        mv_strTypeCondition = " ('N') "
                    Case "L" 'Margin loan
                        mv_strTypeCondition = " ('R') "
                    Case Else
                        mv_strTypeCondition = " ('N','R','P','B') "
                End Select

                'Nguồn giải ngân
                If mv_strRRTYPE <> "C" Then
                    Me.txtDFRATE.Enabled = False
                    Me.txtIRATE.Enabled = False
                    Me.txtMRATE.Enabled = False
                    Me.txtLRATE.Enabled = False
                Else
                    If mv_strCALLTYPE = "P" Then
                        Me.txtDFRATE.Enabled = False
                        Me.txtIRATE.Enabled = False
                        Me.txtMRATE.Enabled = False
                        Me.txtLRATE.Enabled = False
                    Else
                        Me.txtDFRATE.Enabled = True
                        Me.txtIRATE.Enabled = True
                        Me.txtMRATE.Enabled = True
                        Me.txtLRATE.Enabled = True
                        If mv_strIsADVCASH = "Y" Then
                            '16/11/2017 DieuNDA: Neu la UTCT thi khong cho sua ty le 
                            txtDFRATE.Enabled = False
                        Else
                            txtDFRATE.Enabled = True
                        End If
                    End If
                End If
                GetSEMemberGrid(Trim(mskAFACCTNO.Text), Trim(Me.mskACTYPE.Text))
            End If
            'End If
            mv_blnComboSymboLoad = False
        Catch ex As Exception
            'MsgBox(ex.Message, MsgBoxStyle.Information, Me.Text)
        Finally
            mv_blnComboSymboLoad = False
        End Try
    End Sub
    Private Sub SetDealInfoByRefPrice()
        If mskACTYPE.Text.Trim <> String.Empty Then
            If cboRefPrice.SelectedValue.ToString() = MATCHPRICE Then
                calcDFAmount()
                Me.txtTRIGPRICE.Text = FRound(CDbl(Me.txtRefPrice.Text) * CDbl(mv_strLRATE) / 100)
            ElseIf cboRefPrice.SelectedValue.ToString() = OTHERS Then
                If Me.txtMATVAL.Text.Length <> 0 Then
                    If mv_dblEXECQTTY <> 0 AndAlso (CDbl(Me.txtDFAMT.Text) > CDbl(Me.txtMATVAL.Text) / mv_dblEXECQTTY * CDbl(Me.txtQuantity.Text) * CDbl(Me.txtDFRATE.Text) / 100 OrElse Me.ActiveControl Is Me.cboRefPrice) Then
                        'Ducnv formatnumber
                        Me.txtDFAMT.Text = FormatNumber((FRound(CDbl(Me.txtMATVAL.Text) / mv_dblEXECQTTY * CDbl(Me.txtQuantity.Text) * CDbl(Me.txtDFRATE.Text) / 100)), 0)
                    Else
                        Me.txtDFAMT.Text = FormatNumber(mv_dblEXPRICE * CDbl(Me.txtQuantity.Text) * (CDbl(Me.txtDFRATE.Text) / 100), 0)
                        mv_dblMAXDFOPTION = mv_dblEXPRICE * CDbl(Me.txtQuantity.Text) * (CDbl(Me.txtDFRATE.Text) / 100)
                    End If
                Else
                    If Me.chkOPTIONSTOCK.Checked Then
                        Me.txtDFAMT.Text = FormatNumber(mv_dblEXPRICE * CDbl(Me.txtQuantity.Text) * (CDbl(Me.txtDFRATE.Text) / 100), 0)
                        mv_dblMAXDFOPTION = mv_dblEXPRICE * CDbl(Me.txtQuantity.Text) * (CDbl(Me.txtDFRATE.Text) / 100)
                    Else
                        If CDbl(IIf(Me.txtDFAMT.Text = String.Empty, "0", Me.txtDFAMT.Text)) > CDbl(mv_strBASICPRICE) * CDbl(Me.txtQuantity.Text) * CDbl(Me.txtDFRATE.Text) / 100 OrElse Me.txtDFAMT.Text = String.Empty OrElse Me.ActiveControl Is Me.cboRefPrice Then
                            Me.txtDFAMT.Text = FormatNumber(CDbl(mv_strBASICPRICE) * CDbl(Me.txtQuantity.Text) * CDbl(Me.txtDFRATE.Text) / 100, 0)
                        End If
                    End If
                End If
                Me.txtDFPrice.Text = FRound(CDbl(Me.txtDFAMT.Text) / CDbl(Me.txtQuantity.Text), 4)

                'If Me.ActiveControl Is Me.cboRefPrice AndAlso Me.txtTRIGPRICE.Text.Trim.Length = 0 Then
                '    Me.txtTRIGPRICE.Text = FRound(CDbl(Me.txtDFPrice.Text) * CDbl(Me.txtLRATE.Text) / 100)
                'End If
                Me.txtTRIGPRICE.Text = "0"
            Else
                If Me.txtQuantity.Text <> String.Empty Then
                    Me.txtDFAMT.Text = FormatNumber(CDbl(Me.txtRefPrice.Text) * CDbl(Me.txtQuantity.Text) * CDbl(Me.txtDFRATE.Text) / 100, 0)
                End If
                If mv_strDEALTYPE = "T" Then
                    Me.txtDFPrice.Text = FRound(CDbl(Me.txtRefPrice.Text) * CDbl(Me.txtDFRATE.Text) / 100, 2)
                    Me.txtTRIGPRICE.Text = FRound(CDbl(Me.txtRefPrice.Text) * CDbl(mv_strLRATE) / 100, 2)
                Else
                    Me.txtDFPrice.Text = FRound(CDbl(Me.txtRefPrice.Text) * CDbl(Me.txtDFRATE.Text) / 100)
                    Me.txtTRIGPRICE.Text = FRound(CDbl(Me.txtRefPrice.Text) * CDbl(mv_strLRATE) / 100)
                End If

            End If
        End If

    End Sub
    Private Sub SetPPSE()
        If mv_dblIsPPUsed <> 0 And mv_strMarginType <> "N" Then
            If Me.lblCI.Text.Length = 0 Or lblCI.Text = "0" Then
                Me.lblPPSE.Text = Me.lblCI.Text
            Else
                Try
                    Dim v_dblPPSE As Double
                    Dim v_dblQP As Double
                    If IsNumeric(Me.txtDFRATE.Text) Then
                        v_dblQP = CDbl(Me.txtDFRATE.Text) * mv_dblTradeUnit
                        If v_dblQP < mv_dblFloorPrice Then
                            v_dblQP = mv_dblFloorPrice
                        End If
                    Else
                        v_dblQP = mv_dblFloorPrice
                    End If
                    v_dblPPSE = FRound(CDbl(Me.lblCI.Text) / (1 - mv_dblMarginRatioRate / 100 * mv_dblSecMarginPrice / v_dblQP), 0)
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

            pv_PosAuth = 5
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
                & "SELECT CFAUTH.AUTOID, 'A' TYP, AF.CUSTID, LICENSENO IDCODE, FULLNAME, ADDRESS REF,CFCUSTID ACCTNO " & ControlChars.CrLf _
                & "     FROM CFAUTH , AFMAST AF" & ControlChars.CrLf _
                & "     WHERE AF.CUSTID = CFCUSTID AND AF.ACCTNO='" & pv_strAFACCTNO & "' AND SUBSTR(LINKAUTH, " & pv_PosAuth & ", 1) = 'Y' AND CFAUTH.EXPDATE >= TO_DATE('" & Me.BusDate & "','DD/MM/YYYY')"

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            FillDataGrid(MemberGrid, v_strObjMsg, "")
        Catch ex As Exception
            'MsgBox(ex.Message, MsgBoxStyle.Information, Me.Text)
        End Try
    End Sub
    Private Sub GetSEMemberGrid(ByVal v_strAFACCTNO As String, ByVal v_strDFTYPE As String)
        Dim v_strCmdSQL, v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strSQLDFGR As String = String.Empty
        If Not Me.chkOPTIONSTOCK.Checked Then
            If mv_strISVSD = "Y" Then
                mv_strTypeCondition = "('N')"
            End If

            '' Lay thong tin chung khoan da add
            For i As Integer = 0 To DFGRGrid.DataRows.Count - 1
                If v_strSQLDFGR.Length > 0 Then
                    v_strSQLDFGR = v_strSQLDFGR & " union all "
                End If
                v_strSQLDFGR = v_strSQLDFGR & " select '" & DFGRGrid.DataRows(i).Cells("SYMBOL").Value & "' SYMBOL,'" & DFGRGrid.DataRows(i).Cells("DTYPE").Value & "' DTYPE," & DFGRGrid.DataRows(i).Cells("QTTY").Value & " QTTY  from dual " & ControlChars.CrLf
            Next
            If v_strSQLDFGR.Length = 0 Then
                v_strSQLDFGR = " select null SYMBOL, null DTYPE, 0 QTTY from dual "
            End If

            If v_strDFTYPE = "" Then 'SONLT 20141208: Cong thuc lay so luong dc phep lam deal cu: MST.QTTY - NVL(DFGR.QTTY,0) QTTY
                v_strCmdSQL = "select MST.AUTOID, MST.DTYPE, MST.SYMBOL, MST.QTTY - NVL(DFGR.QTTY,0) QTTY, MST.TYPENAME, MST.PRICE, MST.TXDATE, MST.CLEARDATE, MST.AVLWITHDRAW - NVL(DFGR.QTTY,0) AVLWITHDRAW, MST.CAMASTID from   " & ControlChars.CrLf _
                            & "  (SELECT '' AUTOID,'N' DTYPE, B.SYMBOL, A.TRADE-nvl(D.SECUREAMT,0)+nvl(D.SERECEIVING,0) QTTY, cd.cdcontent TYPENAME,0 PRICE, null TXDATE, null CLEARDATE, fn_get_semast_avl_withdraw('" & v_strAFACCTNO & "',c.codeid) AVLWITHDRAW, '' CAMASTID, c.codeid   " & ControlChars.CrLf _
                            & "    FROM SEMAST A, SBSECURITIES B,   " & ControlChars.CrLf _
                            & "      (SELECT CODEID, DFRLSPRICE BASICPRICE, TXDATE FROM SECURITIES_INFO) C,    " & ControlChars.CrLf _
                            & "    v_getsellorderinfo D,  " & ControlChars.CrLf _
                            & "           allcode cd   " & ControlChars.CrLf _
                            & "    WHERE A.CODEID = B.CODEID AND A.CODEID = C.CODEID (+) AND A.ACCTNO=D.SEACCTNO(+)   " & ControlChars.CrLf _
                            & "    AND A.AFACCTNO = '" & v_strAFACCTNO & "'   " & ControlChars.CrLf _
                            & "    AND A.TRADE + A.MORTAGE-nvl(D.SECUREMTG,0)-nvl(D.SECUREAMT,0)+nvl(D.SERECEIVING,0) <> 0   " & ControlChars.CrLf _
                            & "    AND  B.SECTYPE <>'004' and cd.cdtype ='DF'  and cd.cdname ='DEALTYPE' and cd.cdval ='N'  " & ControlChars.CrLf _
                            & "    union  " & ControlChars.CrLf _
                            & "    select AUTOID, DTYPE,SYMBOL, QTTY ,TYPENAME,PRICE, v.TXDATE, v.CLEARDATE, fn_get_semast_avl_withdraw('" & v_strAFACCTNO & "',c.codeid) AVLWITHDRAW, V.CAMASTID, c.codeid from v_getCreateDeal v,  " & ControlChars.CrLf _
                            & "    (SELECT CODEID, DFRLSPRICE BASICPRICE, TXDATE FROM SECURITIES_INFO ) C  " & ControlChars.CrLf _
                            & "    where v.codeid = c.codeid and v.AFACCTNO = '" & v_strAFACCTNO & "' ) MST, ( " & v_strSQLDFGR & " ) DFGR where MST.SYMBOL = DFGR.SYMBOL(+) and MST.DTYPE = DFGR.DTYPE(+) AND MST.QTTY - NVL(DFGR.QTTY,0) > 0  " & ControlChars.CrLf _
                            & "     and MST.DTYPE in " & mv_strTypeCondition & " and MST.symbol in (select symbol from dfbasket bk, dftype dft where bk.dfrate > 0 and bk.basketid = dft.basketid and dft.actype like nvl('" & v_strDFTYPE & "','%')) " & ControlChars.CrLf _
                            & "  order by MST.DTYPE"
            Else
                v_strCmdSQL = "select MST.AUTOID, MST.DTYPE, MST.SYMBOL, MST.QTTY - NVL(DFGR.QTTY,0) QTTY, MST.TYPENAME, MST.PRICE, MST.TXDATE, MST.CLEARDATE, MST.AVLWITHDRAW - NVL(DFGR.QTTY,0) AVLWITHDRAW, MST.CAMASTID from  " & ControlChars.CrLf _
                            & "  (SELECT '' AUTOID,'N' DTYPE, B.SYMBOL, A.TRADE-nvl(D.SECUREAMT,0)+nvl(D.SERECEIVING,0) QTTY, cd.cdcontent TYPENAME,0 PRICE, null TXDATE, null CLEARDATE, fn_get_semast_avl_withdraw('" & v_strAFACCTNO & "',c.codeid) AVLWITHDRAW, '' CAMASTID, c.codeid,ISSELLALLOW  " & ControlChars.CrLf _
                            & "    FROM SEMAST A, SBSECURITIES B,   " & ControlChars.CrLf _
                            & "      (SELECT CODEID, DFRLSPRICE BASICPRICE, TXDATE FROM SECURITIES_INFO) C,    " & ControlChars.CrLf _
                            & "    v_getsellorderinfo D,  " & ControlChars.CrLf _
                            & "           allcode cd  ,DFBASKET DFB, DFTYPE DFT   " & ControlChars.CrLf _
                            & "    WHERE dfb.dfrate > 0 and A.CODEID = B.CODEID AND A.CODEID = C.CODEID (+) AND A.ACCTNO=D.SEACCTNO(+)   " & ControlChars.CrLf _
                            & "    AND A.AFACCTNO = '" & v_strAFACCTNO & "'   " & ControlChars.CrLf _
                            & "    AND DFB.BASKETID=DFT.BASKETID AND DFT.ACTYPE ='" & v_strDFTYPE & "' AND DFB.DEALTYPE='N' AND B.SYMBOL=DFB.SYMBOL AND A.TRADE + A.MORTAGE-nvl(D.SECUREMTG,0)-nvl(D.SECUREAMT,0)+nvl(D.SERECEIVING,0) <> 0   " & ControlChars.CrLf _
                            & "    AND  B.SECTYPE <>'004' and cd.cdtype ='DF'  and cd.cdname ='DEALTYPE' and cd.cdval ='N' and  B.HALT <> 'Y'" & ControlChars.CrLf _
                            & "    union  " & ControlChars.CrLf _
                            & "    select v.AUTOID, DTYPE,v.SYMBOL, QTTY ,v.TYPENAME,PRICE, v.TXDATE, v.CLEARDATE, fn_get_semast_avl_withdraw('" & v_strAFACCTNO & "',c.codeid) AVLWITHDRAW, V.CAMASTID, c.codeid, ISSELLALLOW " & ControlChars.CrLf _
                            & "    from v_getCreateDeal v, (SELECT CODEID, DFRLSPRICE BASICPRICE, TXDATE FROM SECURITIES_INFO ) C , dfbasket bk," & ControlChars.CrLf _
                            & "    dftype dft where bk.dfrate > 0 and bk.basketid = dft.basketid and dft.actype like nvl('" & v_strDFTYPE & "','%') " & ControlChars.CrLf _
                            & "    and v.codeid = c.codeid and v.status not in ('W') and v.AFACCTNO = '" & v_strAFACCTNO & "' and bk.symbol=v.symbol and bk.dealtype=v.dtype ) MST, ( " & v_strSQLDFGR & " ) DFGR where MST.SYMBOL = DFGR.SYMBOL(+) and MST.DTYPE = DFGR.DTYPE(+) AND MST.QTTY - NVL(DFGR.QTTY,0) > 0  " & ControlChars.CrLf _
                            & "    and mst.DTYPE in " & mv_strTypeCondition & " " & ControlChars.CrLf _
                            & "  order by MST.DTYPE"
            End If
        Else
            v_strCmdSQL = "select * from   " & ControlChars.CrLf _
                            & "  (select AUTOID, DTYPE,SYMBOL, QTTY ,TYPENAME,PRICE, v.TXDATE, v.CLEARDATE, v.BALDEFOVD, v.CAMASTID, fn_get_semast_avl_withdraw('" & v_strAFACCTNO & "',c.codeid) AVLWITHDRAW from v_getCreateDeal v,  " & ControlChars.CrLf _
                            & "    (SELECT CODEID, DFRLSPRICE BASICPRICE, TXDATE FROM SECURITIES_INFO ) C  " & ControlChars.CrLf _
                            & "    where v.codeid = c.codeid and v.status = 'W' and v.AFACCTNO = '" & v_strAFACCTNO & "' ) MST, ( " & v_strSQLDFGR & " ) DFGR where MST.SYMBOL = DFGR.SYMBOL(+) and MST.DTYPE = DFGR.DTYPE(+) AND MST.QTTY - NVL(DFGR.QTTY,0) > 0  " & ControlChars.CrLf _
                            & "     and MST.DTYPE in " & mv_strTypeCondition & " and MST.symbol in (select symbol from dfbasket bk, dftype dft where bk.dfrate > 0 and bk.basketid = dft.basketid and dft.actype like nvl('" & v_strDFTYPE & "','%')) " & ControlChars.CrLf _
                            & "  order by MST.DTYPE"
        End If

        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strCmdSQL)
        v_ws.Message(v_strObjMsg)
        FillDataGrid(SEMemberGrid, v_strObjMsg, "")
    End Sub
    Private Sub GetSETrade(ByVal v_strCODEID As String)
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_strValue, v_strFLDNAME, v_strTEXT As String, i, j As Integer
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strCmdSQL As String, v_strObjMsg As String
        Try
            If cboCODEID.SelectedIndex >= 0 Then
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
            'Lấy thông tin về giá chứng khoán
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_strValue, v_strFLDNAME, v_strTEXT As String
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_strCmdSQL As String, v_strObjMsg As String
            v_strCmdSQL = " SELECT SEINF.BASICPRICE, SEINF.FLOORPRICE,SEINF.MARGINPRICE, SEINF.CEILINGPRICE, SEINF.SECUREDRATIOMAX, SEINF.SECUREDRATIOMIN, SEINF.TRADELOT, " & ControlChars.CrLf _
                                & " SEINF.TRADEUNIT, SEINF.TRADEBUYSELL , SE.PARVALUE, A.CDCONTENT TRADING_CYCLE, B.FULLNAME, SE.TRADEPLACE, SE.SECTYPE, " & ControlChars.CrLf _
                                & " (CASE WHEN (TO_DATE(SEINF.LISTTINGDATE)=(SELECT TO_DATE(VARVALUE,'DD/MM/YYYY') CURRDATE FROM SYSVAR WHERE VARNAME='CURRDATE' " & ControlChars.CrLf _
                                & " AND GRNAME='SYSTEM') AND SE.TRADEPLACE='001') THEN 'Y' ELSE 'N' END ) FIRSTLISTTING ,NVL(RSK.MRRATIOLOAN,0) MRRATIOLOAN, NVL(RSK.MRPRICELOAN,0) MRPRICELOAN " & ControlChars.CrLf _
                                & " FROM SECURITIES_INFO SEINF,SBSECURITIES SE,ALLCODE A, ISSUERS B,(SELECT codeid,MRRATIOLOAN,MRPRICELOAN  FROM AFSERISK WHERE   ACTYPE= '" & mv_strACTYPE & "') RSK " & ControlChars.CrLf _
                                & " WHERE SEINF.CODEID=SE.CODEID AND SEINF.CODEID='" & v_strCODEID & "' AND A.CDVAL=SE.TRADEPLACE " & ControlChars.CrLf _
                                & " AND SE.ISSUERID = B.ISSUERID AND A.CDTYPE='SA' AND A.CDNAME='TRADING_CYCLE'  AND SE.CODEID= RSK.CODEID(+)" & ControlChars.CrLf

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
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
                            Case "CEILINGPRICE"
                                mv_dblCeilingPrice = CDbl(v_strValue)
                            Case "TRADELOT"
                                mv_dblTradeLot = CDbl(v_strValue)
                            Case "TRADEUNIT"
                                mv_dblTradeUnit = CDbl(v_strValue)
                            Case "PARVALUE"
                                mv_dbdParvalue = CDbl(v_strValue)
                            Case "SECUREDRATIOMIN"
                                mv_dblSecureBratioMin = CDbl(v_strValue)
                            Case "SECUREDRATIOMAX"
                                mv_dblSecureBratioMax = CDbl(v_strValue)
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
                'Me.lblSymbolInfo.Text = v_strTEXT

            Next
            'LAY RA THONG TIN MARGIN
            If mv_dblMarginRatioRate >= 100 Or mv_dblMarginRatioRate < 0 Then mv_dblMarginRatioRate = 0
            mv_dblSecMarginPrice = IIf(mv_dblMarginPrice > mv_dblSecMarginPrice, mv_dblSecMarginPrice, mv_dblMarginPrice)
            'HIEN THI LAI THONG TIN PPSE
            SetPPSE()
            If Len(Trim(Me.mskAFACCTNO.Text)) > 0 Then
                GetSETrade(cboCODEID.SelectedValue)
            End If

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
        Try
            'Control Validate
            'If Not ControlValidation() Then
            '    Exit Sub
            'End If

            'Ma nhập thông tin trên màn hình và submit gửi lên APP-SERVER để xử lý
            If mskAFACCTNO.Enabled Then 'Submit lần đầu tiên
                'Khởi tạo điện giao dịch
                MessageData = vbNullString
                'Lay thong tin Margin cua tai khoan
                'GetMarginInfo(Me.mskAFACCTNO.Text.Trim, cboCODEID.SelectedValue)
                'Verify và tạo điện giao dịch
                If Not VerifyRules(v_strTxMsg) Then
                    Exit Sub
                Else
                    v_lngError = v_ws.Message(v_strTxMsg)
                    If v_lngError <> ERR_SYSTEM_OK Then
                        'Thông báo lỗi
                        GetErrorFromMessage(v_strTxMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                        Cursor.Current = Cursors.Default
                        If v_lngError <> ERR_SA_CHECKER1_OVR And v_lngError <> ERR_SA_CHECKER2_OVR Then
                            'Reset lai Description

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
                ShowAdjustButton(True)
            Else 'Submit lần thứ hai (confirm)
                '?ẩy điện giao dịch lên APP-SERVER
                v_xmlDocument.LoadXml(MessageData)

                v_strLate = CType(v_xmlDocument.DocumentElement.Attributes.GetNamedItem(gc_AtributeLATE), Xml.XmlAttribute).Value
                If String.Compare(v_strLate, "0") = 0 Then
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

    End Sub

    Private Sub OnApprove(ByVal TxDate As String, ByVal TxNum As String)
        Try
            Dim v_strTxMsg As String
            Dim v_xmlDocument As New Xml.XmlDocument, v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
            Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode, v_intIndex As Long, v_intCount As Integer
            Dim v_strFLDNAME As String, v_strFLDDEFNAME As String, v_strDATATYPE As String, v_strFLDVALUE As String
            Dim v_strERRMSG, v_strENERRMSG, v_strOPERATOR, v_strVALEXP, v_strVALEXP2 As String, v_strACTYPE, v_strDESC As String
            Dim v_dtVALEXP, v_dtVALEXP2, v_dtFLDVALUE As Date
            Dim v_ctl As Control, v_attrFLDNAME As Xml.XmlAttribute, v_attrDATATYPE As Xml.XmlAttribute, v_objEval As New Evaluator

            Dim v_TradeQtty, v_BlockQtty, v_PendingQtty, v_PendingCAQtty, v_seacctno, v_RLSAMT As String
            Dim v_strObjMsg, v_strSQL, v_strValue As String
            Dim v_ws As New BDSDeliveryManagement
            Dim x, y As Integer
            Dim v_lngError As Long
            Dim v_strCmdSQL, V_STRDT, V_STRGROUPID As String
            Dim v_strErrorSource, v_strErrorMessage As String

            Dim v_strAFACCTNO, V_strREF, v_strDFTYPE, v_strSYMBOL, v_strCODEID, v_strDTYPE, str_add, v_strAUTODRAWNDOWN, v_strisapprove, v_strAFACCTNODRD, str As String

            If MsgBox(mv_ResourceManager.GetString("ApproveConfirm"), MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Me.Text) = MsgBoxResult.Yes Then

                v_strObjMsg = String.Empty
                v_strObjMsg = BuildXMLObjMsg(TxDate, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , TellerType, "ApproveMessage", , TxNum)
                v_lngError = v_ws.Message(v_strObjMsg)
                If v_lngError <> ERR_SYSTEM_OK Then
                    'Thông báo lỗi
                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                    Cursor.Current = Cursors.Default
                    MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                    Exit Sub
                Else
                    MessageBox.Show(mv_ResourceManager.GetString("SuccessConfirm"), mv_ResourceManager.GetString("SuccessConfirm"), MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                '    v_strCmdSQL = "SELECT MSGACCT  GROUPID FROM vw_tllog_all WHERE TXNUM  = '" & TxNum & "' AND TXDATE = TO_DATE('" & TxNum & "','DD/MM/YYYY')"
                '    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
                '    v_ws.Message(v_strObjMsg)
                '    v_xmlDocument.LoadXml(v_strObjMsg)
                '    v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

                '    For i As Integer = 0 To v_nodeList.Count - 1
                '        V_STRDT = String.Empty
                '        For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                '            With v_nodeList.Item(i).ChildNodes(j)
                '                v_strValue = Trim(.InnerText.ToString)
                '                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                '                Select Case Trim(v_strFLDNAME)
                '                    Case "GROUPID"
                '                        V_STRGROUPID = v_strValue

                '                End Select
                '            End With
                '        Next
                '    Next


                '    'Tạo điện giao dịch 2687- dung de tao deal tong giao dich
                '    LoadScreen("2687")
                '    v_strTxMsg = BuildXMLTxMsg(gc_MsgTypeTrans, gc_IsLocalMsg, "2687", Me.BranchId, Me.TellerId, Me.IpAddress, Me.WsName, , , , , , , , , , , , , , , , , Me.BusDate)
                '    v_xmlDocument.LoadXml(v_strTxMsg)
                '    v_dataElement = v_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "fields", "")
                '    If mv_arrObjFields.GetLength(0) > 0 Then
                '        For v_intIndex = 0 To mv_arrObjFields.GetLength(0) - 1 Step 1
                '            If Not mv_arrObjFields(v_intIndex) Is Nothing Then
                '                v_strFLDNAME = mv_arrObjFields(v_intIndex).FieldName
                '                v_strDATATYPE = mv_arrObjFields(v_intIndex).DataType
                '                Select Case Trim(v_strFLDNAME)
                '                    Case "20" 'GROUPID
                '                        v_strFLDVALUE = V_STRGROUPID
                '                    Case "06" 'STRDATA
                '                        v_strFLDVALUE = V_STRGROUPID
                '                    Case "08" 'STATUS
                '                        v_strFLDVALUE = "N"
                '                    Case "30" 'DESC
                '                        v_strFLDVALUE = "Duyet giao dich"
                '                        ' Me.txtDescription.Text = v_strDESC
                '                End Select

                '                'Append entry to data node
                '                v_entryNode = v_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "entry", "")

                '                'Add field name
                '                v_attrFLDNAME = v_xmlDocument.CreateAttribute(gc_AtributeFLDNAME)
                '                v_attrFLDNAME.Value = v_strFLDNAME
                '                v_entryNode.Attributes.Append(v_attrFLDNAME)

                '                'Add field type
                '                v_attrDATATYPE = v_xmlDocument.CreateAttribute(gc_AtributeFLDTYPE)
                '                v_attrDATATYPE.Value = v_strDATATYPE
                '                v_entryNode.Attributes.Append(v_attrDATATYPE)

                '                'Set value
                '                v_entryNode.InnerText = v_strFLDVALUE

                '                v_dataElement.AppendChild(v_entryNode)


                '                v_xmlDocument.DocumentElement.AppendChild(v_dataElement)
                '            End If
                '        Next
                '    End If
                '    v_strTxMsg = v_xmlDocument.InnerXml

                '    '?�ẩy điện giao dịch lên APP-SERVER
                '    '   v_strTxMsg = MessageData
                '    v_lngError = v_ws.Message(v_strTxMsg)

                '    If v_lngError = ERR_SYSTEM_OK Then
                '        MessageBox.Show(mv_ResourceManager.GetString("SuccessConfirm"), mv_ResourceManager.GetString("SuccessConfirm"), MessageBoxButtons.OK, MessageBoxIcon.Warning)
                '        Exit Sub
                '    Else
                '        'Lấy thêm nguyên nhân duyệt
                '        GetReasonFromMessage(v_strTxMsg, v_lngError)
                '        MessageBox.Show(v_lngError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                '    End If

                '    'If v_lngError <> ERR_SYSTEM_OK Then
                '    '    Me.ReturnValue = ""
                '    '    'Thông báo lỗi
                '    '    GetErrorFromMessage(v_strTxMsg, v_lngError, v_lngError, v_lngError)
                '    '    Cursor.Current = Cursors.Default
                '    '    If v_lngError <> ERR_SA_CHECKER1_OVR And v_lngError <> ERR_SA_CHECKER2_OVR Then
                '    '        MessageBox.Show(v_lngError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                '    '        Exit Sub
                '    '    Else
                '    '        'Lấy thêm nguyên nhân duyệt
                '    '        GetReasonFromMessage(v_strTxMsg, v_lngError)
                '    '        MessageBox.Show(v_lngError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                '    '    End If
                '    'Else
                '    '    'Get OrderID
                '    '    Dim v_node As XmlNode = v_xmlDocument.SelectSingleNode("TransactMessage/fields/entry[@fldname='04']")
                '    '    If Not v_node Is Nothing Then
                '    '        Me.ReturnValue = v_node.InnerXml
                '    '    End If
                '    '    'End
                '    'End If
            End If


        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try

    End Sub

    Private Sub OnDelete(ByVal isAmendment As Boolean)

    End Sub

    Private Sub OnRefuse()

    End Sub

    Private Sub OnReject(ByVal TxDate As String, ByVal TxNum As String)
        Try
            Dim v_strTxMsg As String
            Dim v_xmlDocument As New Xml.XmlDocument, v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
            Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode, v_intIndex As Long, v_intCount As Integer
            Dim v_strFLDNAME As String, v_strFLDDEFNAME As String, v_strDATATYPE As String, v_strFLDVALUE As String
            Dim v_strERRMSG, v_strENERRMSG, v_strOPERATOR, v_strVALEXP, v_strVALEXP2 As String, v_strACTYPE, v_strDESC As String
            Dim v_dtVALEXP, v_dtVALEXP2, v_dtFLDVALUE As Date
            Dim v_ctl As Control, v_attrFLDNAME As Xml.XmlAttribute, v_attrDATATYPE As Xml.XmlAttribute, v_objEval As New Evaluator

            Dim v_TradeQtty, v_BlockQtty, v_PendingQtty, v_PendingCAQtty, v_seacctno, v_RLSAMT As String
            Dim v_strObjMsg, v_strSQL, v_strValue As String
            Dim v_ws As New BDSDeliveryManagement
            Dim x, y As Integer
            Dim v_lngError As Long
            Dim v_strCmdSQL, V_STRDT, V_STRGROUPID As String


            Dim v_strAFACCTNO, V_strREF, v_strDFTYPE, v_strSYMBOL, v_strCODEID, v_strDTYPE, str_add, v_strAUTODRAWNDOWN, v_strisapprove, v_strAFACCTNODRD, str As String

            If MsgBox(mv_ResourceManager.GetString("Reject"), MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Me.Text) = MsgBoxResult.Yes Then


                v_strCmdSQL = "SELECT MSGACCT  GROUPID FROM vw_tllog_all WHERE TXNUM  = '" & KeyFieldValue.Substring(10, 10) & "' AND TXDATE = TO_DATE('" & KeyFieldValue.Substring(0, 10) & "','DD/MM/YYYY')"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
                v_ws.Message(v_strObjMsg)
                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

                For i As Integer = 0 To v_nodeList.Count - 1
                    V_STRDT = String.Empty
                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            v_strValue = Trim(.InnerText.ToString)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME)
                                Case "GROUPID"
                                    V_STRGROUPID = v_strValue

                            End Select
                        End With
                    Next
                Next


                'Tạo điện giao dịch 2687- dung de tao deal tong giao dich
                LoadScreen("2687")
                v_strTxMsg = BuildXMLTxMsg(gc_MsgTypeTrans, gc_IsLocalMsg, "2687", Me.BranchId, Me.TellerId, Me.IpAddress, Me.WsName, , , , , , , , , , , , , , , , , Me.BusDate)
                v_xmlDocument.LoadXml(v_strTxMsg)
                v_dataElement = v_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "fields", "")
                If mv_arrObjFields.GetLength(0) > 0 Then
                    For v_intIndex = 0 To mv_arrObjFields.GetLength(0) - 1 Step 1
                        If Not mv_arrObjFields(v_intIndex) Is Nothing Then
                            v_strFLDNAME = mv_arrObjFields(v_intIndex).FieldName
                            v_strDATATYPE = mv_arrObjFields(v_intIndex).DataType
                            Select Case Trim(v_strFLDNAME)
                                Case "20" 'GROUPID
                                    v_strFLDVALUE = V_STRGROUPID
                                Case "06" 'STRDATA
                                    v_strFLDVALUE = V_STRGROUPID
                                Case "08" 'STATUS
                                    v_strFLDVALUE = "R"
                                Case "30" 'DESC
                                    v_strFLDVALUE = "Duyet giao dich"
                                    ' Me.txtDescription.Text = v_strDESC
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


                            v_xmlDocument.DocumentElement.AppendChild(v_dataElement)
                        End If
                    Next
                End If
                v_strTxMsg = v_xmlDocument.InnerXml

                '?�ẩy điện giao dịch lên APP-SERVER
                '   v_strTxMsg = MessageData
                v_lngError = v_ws.Message(v_strTxMsg)

                If v_lngError = ERR_SYSTEM_OK Then
                    MessageBox.Show(mv_ResourceManager.GetString("SuccessReject"), mv_ResourceManager.GetString("SuccessReject"), MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                Else
                    'Lấy thêm nguyên nhân duyệt
                    GetReasonFromMessage(v_strTxMsg, v_lngError, Me.UserLanguage)
                    MessageBox.Show(v_lngError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

                'If v_lngError <> ERR_SYSTEM_OK Then
                '    Me.ReturnValue = ""
                '    'Thông báo lỗi
                '    GetErrorFromMessage(v_strTxMsg, v_lngError, v_lngError, v_lngError)
                '    Cursor.Current = Cursors.Default
                '    If v_lngError <> ERR_SA_CHECKER1_OVR And v_lngError <> ERR_SA_CHECKER2_OVR Then
                '        MessageBox.Show(v_lngError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                '        Exit Sub
                '    Else
                '        'Lấy thêm nguyên nhân duyệt
                '        GetReasonFromMessage(v_strTxMsg, v_lngError)
                '        MessageBox.Show(v_lngError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                '    End If
                'Else
                '    'Get OrderID
                '    Dim v_node As XmlNode = v_xmlDocument.SelectSingleNode("TransactMessage/fields/entry[@fldname='04']")
                '    If Not v_node Is Nothing Then
                '        Me.ReturnValue = v_node.InnerXml
                '    End If
                '    'End
                'End If
            End If

        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub OnClose()
        mv_blnisClosed = True
        Me.Dispose()
    End Sub


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
                v_color = System.Drawing.Color.LightBlue
            Case "NS" 'Honeydew
                'v_color = System.Drawing.Color.Honeydew
                v_color = System.Drawing.Color.LightCoral
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

    '= Max(Min(tỷ lệ ký quỹ trong H? * tr?ng số ký quỹ theo order type, 100%), tỷ lệ ký quỹ của sys) 
    '        + Max (phí giao dịch theo loại hình lệnh của KH)
    Private Function GetSecureRatio() As Decimal
        Dim v_dblSecureRatio, v_dblFeeSecureRatioMin As Double
        If Me.mv_strMarginType = "N" Then
            v_dblSecureRatio = Math.Max(Math.Min(mv_dblTyp_Bratio + mv_dblAF_Bratio, 100), mv_dblSecureBratioMin)
            v_dblSecureRatio = CDec(IIf(v_dblSecureRatio > mv_dblSecureBratioMax, mv_dblSecureBratioMax, v_dblSecureRatio))
        Else
            'Neu la tai khoan Margin thi ky quy 100%
            v_dblSecureRatio = 100
        End If

        'Cộng thêm ký quỹ cho phí giao dịch theo loại hình lệnh
        '1.Phí tối thiểu. Nếu phí tối thiểu
        '2. Giá trị giao dịch

        v_dblFeeSecureRatioMin = mv_dblFeeAmountMin * 100 / (CDbl(txtDFPrice.Text) * CDbl(txtDFRATE.Text) * mv_dblTradeUnit)
        If v_dblFeeSecureRatioMin > mv_dblFeeRate Then
            v_dblSecureRatio += v_dblFeeSecureRatioMin
            mv_dblFeeAmount = mv_dblFeeAmountMin
        Else
            v_dblSecureRatio += mv_dblFeeRate
            mv_dblFeeAmount = mv_dblFeeRate * (CDbl(txtDFPrice.Text) * CDbl(txtDFRATE.Text) * mv_dblTradeUnit) / 100
        End If

        GetSecureRatio = Math.Min(mv_dblSecureBratioSYSMax, Math.Max(mv_dblSecureBratioSYSMin, v_dblSecureRatio))

    End Function

    Private Function ControlValidation() As Boolean
        If Len(Me.mskAFACCTNO.Text) = 0 Then
            MsgBox(mv_ResourceManager.GetString("ERR_FIELD_NULL"), MsgBoxStyle.Information, Me.Text)
            Me.ActiveControl = mskAFACCTNO
            Return False
        End If
        If Len(Me.mskACTYPE.Text) = 0 Then
            MsgBox(mv_ResourceManager.GetString("ERR_FIELD_NULL"), MsgBoxStyle.Information, Me.Text)
            Me.ActiveControl = mskACTYPE
            Return False
        End If
        If Len(Me.txtRefPrice.Text) = 0 Then
            MsgBox(mv_ResourceManager.GetString("ERR_FIELD_NULL"), MsgBoxStyle.Information, Me.Text)
            Me.ActiveControl = txtRefPrice
            Return False
        End If

        If Len(Me.txtDFPrice.Text) = 0 Then
            MsgBox(mv_ResourceManager.GetString("ERR_FIELD_NULL"), MsgBoxStyle.Information, Me.Text)
            Me.ActiveControl = txtDFPrice
            Return False
        End If

        If Len(Me.txtTRIGPRICE.Text) = 0 Then
            MsgBox(mv_ResourceManager.GetString("ERR_FIELD_NULL"), MsgBoxStyle.Information, Me.Text)
            Me.ActiveControl = txtTRIGPRICE
            Return False
        End If

        If Not IsNumeric(txtTRIGPRICE.Text) OrElse CDbl(txtTRIGPRICE.Text) < 0 Then
            MsgBox(mv_ResourceManager.GetString("PRICEISNOTNUMBER"), MsgBoxStyle.Information, Me.Text)
            Me.ActiveControl = txtTRIGPRICE
            Return False
        End If

        If Len(Me.txtDFRATE.Text) = 0 Then
            MsgBox(mv_ResourceManager.GetString("ERR_FIELD_NULL"), MsgBoxStyle.Information, Me.Text)
            Me.ActiveControl = txtDFRATE
            Return False
        End If
        If CDbl(Trim(Me.txtDFRATE.Text)) = 0 Then
            MsgBox(mv_ResourceManager.GetString("ERR_INV_RATE"), MsgBoxStyle.Information, Me.Text)
            'Me.ActiveControl = txtDFRATE
            Return False
        End If

        If Len(Me.txtIRATE.Text) = 0 Then
            MsgBox(mv_ResourceManager.GetString("ERR_FIELD_NULL"), MsgBoxStyle.Information, Me.Text)
            Me.ActiveControl = txtIRATE
            Return False
        End If

        If Len(Me.txtMRATE.Text) = 0 Then
            MsgBox(mv_ResourceManager.GetString("ERR_FIELD_NULL"), MsgBoxStyle.Information, Me.Text)
            Me.ActiveControl = txtMRATE
            Return False
        End If

        If Len(Me.txtLRATE.Text) = 0 Then
            MsgBox(mv_ResourceManager.GetString("ERR_FIELD_NULL"), MsgBoxStyle.Information, Me.Text)
            Me.ActiveControl = txtLRATE
            Return False
        End If

        If Len(Me.txtQuantity.Text) = 0 Then
            MsgBox(mv_ResourceManager.GetString("ERR_FIELD_NULL"), MsgBoxStyle.Information, Me.Text)
            Me.ActiveControl = txtQuantity
            Return False
        ElseIf mv_dblTradeLot > 0 AndAlso CDbl(Me.txtQuantity.Text) Mod mv_dblTradeLot <> 0 Then
            MsgBox(mv_ResourceManager.GetString("ERR_QTTY_NOT_TRADELOT"), MsgBoxStyle.Information, Me.Text)
            Me.ActiveControl = txtQuantity
            Return False
        ElseIf mv_dblDFTRADELOT > 0 AndAlso CDbl(Me.txtQuantity.Text) Mod mv_dblDFTRADELOT <> 0 Then
            MsgBox(mv_ResourceManager.GetString("ERR_QTTY_NOT_TRADELOT"), MsgBoxStyle.Information, Me.Text)
            Me.ActiveControl = txtQuantity
            Return False
        End If
        If cboRefPrice.SelectedValue.ToString() <> OTHERS AndAlso CDbl(txtTRIGPRICE.Text) > CDbl(txtRefPrice.Text) Then
            MsgBox(mv_ResourceManager.GetString("TRIGGERPRICE_OVER_REFPRICE"), MsgBoxStyle.Information, Me.Text)
            Me.ActiveControl = txtTRIGPRICE
            Return False
        End If
        'If CDbl(txtDFPrice.Text) > CDbl(txtRefPrice.Text) Then
        '    MsgBox(mv_ResourceManager.GetString("DFPRICE_OVER_REFPRICE"), MsgBoxStyle.Information, Me.Text)
        '    Me.ActiveControl = txtDFPrice
        '    Return False
        'End If

        ''Tinh ra gia tri vay tu so luong vay va so luong khop
        'calcDFAmount()
        ''Tinh ra so tien can tra cho khoan chenh lech
        'calcCashtopay()

        If Me.chkENDNEWDEAL.Checked = True AndAlso CDbl(Me.txtQuantity.Text) > CDbl(Me.txtOLDDFQTTY.Text) Then
            MsgBox(mv_ResourceManager.GetString("NEWQTTYABOVEOLDQTTY"), MsgBoxStyle.Information, Me.Text)
            Me.ActiveControl = txtQuantity
            Return False
        End If

        If Me.chkENDNEWDEAL.Checked = True AndAlso CDbl(Me.txtNETBALANCE.Text.Trim) > 0 AndAlso (CDbl(Me.txtNETBALANCE.Text.Trim) > Math.Max(mv_dblPP, 0)) Then
            MsgBox(mv_ResourceManager.GetString("NOTENOUGHMONEY"), MsgBoxStyle.Information, Me.Text)
            Me.ActiveControl = txtQuantity
            Return False
        End If

        'If Me.chkENDNEWDEAL.Checked = True AndAlso Me.chkAUTODRAWNDOWN.Checked = False Then
        '    MsgBox(mv_ResourceManager.GetString("HASTOAUTODRAWNDOWN"), MsgBoxStyle.Information, Me.Text)
        '    Me.ActiveControl = Me.chkAUTODRAWNDOWN
        '    Return False
        'End If

        If cboRefPrice.SelectedValue.ToString() = OTHERS OrElse cboRefPrice.SelectedValue.ToString() = MATCHPRICE Then
            If (Not IsNumeric(txtDFAMT.Text)) OrElse (IsNumeric(txtDFAMT.Text) AndAlso CDbl(txtDFAMT.Text) <= 0) Then
                MsgBox(mv_ResourceManager.GetString("NUMBER_IS_INVALID"), MsgBoxStyle.Information, Me.Text)
                Me.ActiveControl = Me.txtDFAMT
                Return False
            End If
        End If

        'Check cho TH Thanh ly tai ky.
        If chkENDNEWDEAL.Checked Then
            'if stk giao dich <> stk deal cu.
            If mv_strOLDDFAFACCTNO <> Trim(mskAFACCTNO.Text) Then
                MsgBox(mv_ResourceManager.GetString("AFACCTNO_IS_NOT_MATCHING"), MsgBoxStyle.Information, Me.Text)
                Me.ActiveControl = Me.txtOLDDEALNO
                Return False
            End If
        End If
        If Not chkENDNEWDEAL.Checked AndAlso Me.txtREF.Text.Trim <> String.Empty Then
            If mv_strDFAFACCTNO <> Trim(mskAFACCTNO.Text) Then
                MsgBox(mv_ResourceManager.GetString("AFACCTNO_IS_NOT_MATCHING2"), MsgBoxStyle.Information, Me.Text)
                Me.ActiveControl = Me.txtREF
                Return False
            End If
        End If

        Return True
    End Function

    ''' <summary>
    ''' Hàm này tạo lại CreateFeemap trên cơ sở tham số định nghĩa trong bảng FEEMAP
    ''' </summary>
    ''' <param name="pv_xmlDocument"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
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


    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        OnDelete(False)
    End Sub

    Private Sub VScrollBarSign_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs)
        'If Not mv_arrSIGNATURE Is Nothing Then
        '    If mv_arrSIGNATURE.Length > 0 Then
        '        picSignature.Image = GetImageFromString(mv_arrSIGNATURE(Me.VScrollBarSign.Value))
        '    Else
        '        picSignature.Image = Nothing
        '        picSignature.Refresh()
        '    End If
        'End If
    End Sub


    Private Sub VScrollBarSign_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not mv_arrSIGNATURE Is Nothing Then
            If mv_arrSIGNATURE.Length > 0 Then
                picSignature.Image = GetImageFromString(mv_arrSIGNATURE(Me.VScrollBarSign.Value))
            Else
                picSignature.Image = Nothing
                picSignature.Refresh()
            End If
        End If
    End Sub

    Private Sub chkDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If chkDetail.Checked And AllowViewCF Then
            'Show chi tiết hợp đồng
            pnBalance.Visible = True
            pnBalance.Top = CONTROL_PNL_BALANCE_TOP
            pnContractInfo.Top = CONTROL_PNL_CONTRACT_TOP
            btnOK.Top = CONTROL_BUTTON_TOP
            btnCANCEL.Top = btnOK.Top
            Me.Height = FRM_EXTEND_HEIGHT
        Else
            'Không Show chi tiết hợp đồng
            pnBalance.Visible = False
            'pnBalance.Top = CONTROL_PNL_BALANCE_TOP
            pnContractInfo.Top = CONTROL_PNL_BALANCE_TOP
            btnOK.Top = CONTROL_BUTTON_TOP - pnBalance.Height - 10
            btnCANCEL.Top = btnOK.Top
            Me.Height = FRM_EXTEND_HEIGHT - pnBalance.Height - 10
        End If
    End Sub
    Private Sub SEMemberGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles SEMemberGrid.DoubleClick
        Dim v_strSYMBOL As String
        Try
            If mskACTYPE.Text.Trim.Length = 4 AndAlso mskAFACCTNO.Enabled Then
                'Chỉ double click sau khi chọn loại hình
                v_strSYMBOL = Trim(CType(SEMemberGrid.CurrentRow, Xceed.Grid.DataRow).Cells("SYMBOL").Value)
                mv_strDEALTYPE = Trim(CType(SEMemberGrid.CurrentRow, Xceed.Grid.DataRow).Cells("DTYPE").Value)
                Me.cboCODEID.Text = v_strSYMBOL
                'Cập nhật thông tin chứng khoán
                ShowScreenBasedOnCodeID(v_strSYMBOL)
                Me.txtREF.Text = Trim(CType(SEMemberGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value)
                Me.txtQuantity.Text = Trim(CType(SEMemberGrid.CurrentRow, Xceed.Grid.DataRow).Cells("QTTY").Value)

                If Me.chkOPTIONSTOCK.Checked Then
                    Me.txtBALDEFOVD.Text = Trim(CType(SEMemberGrid.CurrentRow, Xceed.Grid.DataRow).Cells("BALDEFOVD").Value)
                    mv_strCAMASTID = Trim(CType(SEMemberGrid.CurrentRow, Xceed.Grid.DataRow).Cells("CAMASTID").Value)
                    mv_strDUEDATE = Trim(CType(SEMemberGrid.CurrentRow, Xceed.Grid.DataRow).Cells("CLEARDATE").Value)
                    mv_strREPORTDATE = Trim(CType(SEMemberGrid.CurrentRow, Xceed.Grid.DataRow).Cells("TXDATE").Value)
                    mv_dblEXPRICE = Trim(CType(SEMemberGrid.CurrentRow, Xceed.Grid.DataRow).Cells("PRICE").Value)
                End If

                If (Me.mv_strDFTYPE = "B" Or Me.mv_strDFTYPE = "F" Or Me.mv_strDFTYPE = "A") And Me.txtREF.Text.Trim.Length > 0 Then
                    GetDealInfo(Trim(CType(SEMemberGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value))
                ElseIf Me.mv_strDFTYPE = "L" And Trim(CType(SEMemberGrid.CurrentRow, Xceed.Grid.DataRow).Cells("DTYPE").Value) = "R" Then
                    'Neu margin loan tren chung khoan cho ve thi lay theo gia khop binh quan cua deal
                    If Trim(CType(SEMemberGrid.CurrentRow, Xceed.Grid.DataRow).Cells("PRICE").Value) > 0 Then
                        Me.txtRefPrice.Text = Trim(CType(SEMemberGrid.CurrentRow, Xceed.Grid.DataRow).Cells("PRICE").Value)
                        SetDealInfoByRefPrice()
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
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


    Private Sub CreateDefaultCondition(ByVal pv_strDisplay As String, ByVal pv_strValue As String)
        Try
            Dim v_strObjMsg As String, v_strDefVal As String = String.Empty
            Dim v_strUserProfiles As String = Application.LocalUserAppDataPath & "\" & Me.BranchId & Me.TellerId & ".xml"
            Dim v_strSection As String = Me.ModuleCode & "." & "ODMAST" 'Me.ObjectName

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

            'Order status.
            '------------------------------------
            v_entryNodeTmp = v_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "DataElement", "")

            'Add checked attribute
            v_attrChecked = v_xmlDocument.CreateAttribute("CHECKED")
            v_attrChecked.Value = "N"
            v_entryNodeTmp.Attributes.Append(v_attrChecked)

            'Add value attribute
            v_attrValue = v_xmlDocument.CreateAttribute("VALUE")
            v_attrValue.Value = "REPLACE (UPPER( Trim (T.ORSTATUS)),'.','') = UPPER ('Pending to Send')"
            v_entryNodeTmp.Attributes.Append(v_attrValue)

            'Add display attribute
            v_attrDisplay = v_xmlDocument.CreateAttribute("DISPLAY")
            v_attrDisplay.Value = "Order status = 'Pending to Send'"
            v_entryNodeTmp.Attributes.Append(v_attrDisplay)

            v_entryNode.AppendChild(v_entryNodeTmp)

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


    Private Sub frmCreateDFGRDeal_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
                'Dien comment 05-10-2010
                'v_strSQL = "SELECT CF.CAREBY FROM CFMAST CF, AFMAST AF WHERE AF.CUSTID=CF.CUSTID AND AF.ACCTNO='" & pv_strCheck & "'"
                v_strSQL = "SELECT AF.CAREBY FROM AFMAST AF, TLGRPUSERS TL WHERE AF.CAREBY=TL.GRPID AND TL.TLID='" & Me.TellerId & "' AND AF.ACCTNO='" & pv_strCheck & "'"
                'end comment Dien
            Case "ODCANCEL"
                'Dien comment 05-10-2010
                'v_strSQL = "SELECT CAREBY FROM CFMAST WHERE CUSTODYCD IN (SELECT CUSTODYCD FROM ODCANCEL WHERE ORGORDERID = '" & pv_strCheck & "')"
                v_strSQL = "SELECT AF.CAREBY FROM AFMAST AF, CFMAST CF, TLGRPUSERS TL WHERE AF.CAREBY=TL.GRPID AND TL.TLID ='" & Me.TellerId & "' AND AF.CUSTID=CF.CUSTID and EXISTS (SELECT CUSTODYCD FROM ODCANCEL WHERE CF.CUSTODYCD= ODCANCEL.CUSTODYCD and ORGORDERID = '" & pv_strCheck & "')"
                'End comment Dien
            Case "ODMAST"
                'Dien comment 5-10-2010
                'v_strSQL = "SELECT CF.careby FROM CFMAST CF,ODMAST OD,AFMAST AF WHERE CF.custid = AF.custid AND AF.acctno = OD.afacctno AND OD.orderid ='" & pv_strCheck & "'" & _
                '           "UNION ALL SELECT CF.careby FROM CFMAST CF,FOMAST FO,AFMAST AF WHERE CF.custid = AF.custid AND AF.acctno = FO.afacctno AND FO.acctno='" & pv_strCheck & "'"
                v_strSQL = "SELECT AF.CAREBY FROM ODMAST OD, AFMAST AF, TLGRPUSERS TL WHERE AF.CAREBY=TL.GRPID AND TL.TLID='" & Me.TellerId & "' AND AF.acctno = OD.afacctno AND OD.orderid ='" & pv_strCheck & "'" & _
                           "UNION ALL SELECT AF.careby FROM FOMAST FO, AFMAST AF, TLGRPUSERS TL WHERE AF.CAREBY=TL.GRPID AND TL.TLID='" & Me.TellerId & "' AND AF.acctno = FO.afacctno AND FO.acctno='" & pv_strCheck & "'"
                'end comment Dien
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

        If Not AuthCustomer Is Nothing Then
            If AuthCustomer <> String.Empty Then
                v_blRet = True
            End If
        Else
            If Not mv_AFCarebyGrp Is Nothing Then
                If mv_AFCarebyGrp <> "" Then
                    If mv_AFCarebyGrp <> "" Then
                        If mv_GroupCareBy.IndexOf(mv_AFCarebyGrp) > -1 Then
                            v_blRet = True
                        Else
                            MsgBox(mv_ResourceManager.GetString("ERR_CF_NOT_CAREBY"), MsgBoxStyle.Information, Me.Text)
                        End If
                    End If
                End If
            End If
        End If

        'If AuthCustomer <> String.Empty Then
        '    'Neu la uy quyen (dat lenh qua kenh tele) thi khong check careby
        '    v_blRet = True
        'Else

        '    If mv_AFCarebyGrp <> "" Then
        '        If mv_GroupCareBy.IndexOf(mv_AFCarebyGrp) > -1 Then
        '            v_blRet = True
        '        Else
        '            MsgBox(mv_ResourceManager.GetString("ERR_CF_NOT_CAREBY"), MsgBoxStyle.Information, Me.Text)
        '        End If
        '    End If
        'End If
        Return v_blRet
    End Function

    Private Sub frmCreateDFGRDeal_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Dim v_intPos As Int16, ctl As Control, strFLDNAME As String, v_intIndex As Integer
        Select Case e.KeyCode
            Case Keys.Escape
                OnClose()
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

                    If Len(Trim(frm.ReturnValue)) > 0 Then
                        'Check if contract no is caredby by user or not - TungNT added
                        If VerifyCaredBy(frm.ReturnValue.Replace(".", ""), "AFMAST") = True Then
                            Me.ActiveControl.Text = Trim(frm.ReturnValue)
                            lblAFNAME.Text = Trim(frm.RefValue)
                            'Nạp thông tin tài khoản mới
                            GetAFContractInfo(Me.ActiveControl.Text)
                        Else
                            Exit Sub
                        End If
                    End If
                    frm.Dispose()
                    'End
                ElseIf Me.ActiveControl.Name = "mskACTYPE" And Me.mskACTYPE.ReadOnly = False Then
                    Dim frm As New frmSearch(Me.UserLanguage)
                    frm.TableName = "DFTYPETOCREATEDEAL"
                    frm.ModuleCode = "DF"
                    frm.AuthCode = "NNNNYYNNNN" 'Không cho phép thực hiện chức năng nào 
                    frm.IsLocalSearch = gc_IsNotLocalMsg
                    frm.IsLookup = "Y"
                    frm.SearchOnInit = False
                    frm.BranchId = Me.BranchId
                    frm.TellerId = Me.TellerId
                    frm.GroupCareBy = True
                    frm.CareByFilter = True
                    frm.ShowDialog()
                    Me.ActiveControl.Text = Trim(frm.ReturnValue)

                    'Nạp thông tin cho loai hinh DF nay.
                    If Len(Trim(frm.ReturnValue)) > 0 Then
                        If Me.chkENDNEWDEAL.Checked = True AndAlso Me.txtOLDDEALNO.Text.Trim.Length > 0 AndAlso Me.cboCODEID.Text.Trim.Length > 0 Then
                            GetDFType(frm.ReturnValue, Me.cboCODEID.SelectedValue)
                        Else
                            GetDFType(frm.ReturnValue)
                        End If
                    End If

                    frm.Dispose()
                    'End
                ElseIf Me.ActiveControl.Name = "mskCUSTODYCD" And Me.mskCUSTODYCD.ReadOnly = False Then
                    Dim frm As New frmSearch(Me.UserLanguage)
                    frm.TableName = "CUSTODYCD_TX"
                    frm.ModuleCode = "CF"
                    frm.AuthCode = "NNNNYYNNNN" 'Không cho phép thực hiện chức năng nào 
                    frm.IsLocalSearch = gc_IsNotLocalMsg
                    frm.IsLookup = "Y"
                    frm.SearchOnInit = False
                    frm.BranchId = Me.BranchId
                    frm.TellerId = Me.TellerId
                    frm.GroupCareBy = True
                    frm.CareByFilter = True
                    frm.ShowDialog()
                    Me.ActiveControl.Text = Trim(frm.ReturnValue)
                    frm.Dispose()

                    'End
                ElseIf Me.ActiveControl.Name = "txtREF" And Me.mskACTYPE.ReadOnly = False Then
                    Dim frm As New frmSearch(Me.UserLanguage)
                    frm.TableName = "DFCREATEDEAL"
                    frm.ModuleCode = "DF"
                    frm.AuthCode = "NNNNYYNNNN" 'Không cho phép thực hiện chức năng nào 
                    frm.IsLocalSearch = gc_IsNotLocalMsg
                    frm.IsLookup = "Y"
                    frm.SearchOnInit = False
                    frm.BranchId = Me.BranchId
                    frm.TellerId = Me.TellerId
                    frm.AFACCTNO = Trim(mskAFACCTNO.Text)
                    frm.LinkValue = Trim(Me.mskACTYPE.Text)
                    frm.CUSTID = mv_strTypeCondition
                    frm.ShowDialog()
                    If Trim(frm.ReturnValue).Length > 0 Then
                        ResetVariables()
                        Me.ActiveControl.Text = Trim(frm.ReturnValue)
                        GetDealInfo(frm.ReturnValue)
                    End If
                    frm.Dispose()
                ElseIf Me.ActiveControl.Name = "txtOLDDEALNO" And Me.mskCUSTODYCD.Text <> "" Then
                    Dim frm As New frmSearch(Me.UserLanguage)
                    frm.TableName = "DFDEALLIQUID"
                    frm.ModuleCode = "DF"
                    frm.AuthCode = "NNNNYYNNNN" 'Không cho phép thực hiện chức năng nào 
                    frm.IsLocalSearch = gc_IsNotLocalMsg
                    frm.IsLookup = "Y"
                    frm.SearchOnInit = False
                    frm.BranchId = Me.BranchId
                    frm.TellerId = Me.TellerId
                    frm.AFACCTNO = Trim(mskAFACCTNO.Text)
                    frm.LinkValue = Trim(Me.mskACTYPE.Text)
                    frm.CUSTID = mv_strTypeCondition
                    frm.ShowDialog()
                    If Trim(frm.ReturnValue).Length > 0 Then
                        ResetVariables()
                        Me.ActiveControl.Text = Trim(frm.ReturnValue)
                        getDealInfoByAcctno(frm.ReturnValue)
                        getCIInfo(mskAFACCTNO.Text.Trim)
                    End If
                    frm.Dispose()
                ElseIf Me.ActiveControl.Name = "mskDFFeeMap" Then
                    Dim frm As New frmSearch(Me.UserLanguage)
                    frm.TableName = "FEEMAP2676"
                    frm.ModuleCode = "DF"
                    frm.AuthCode = "NNNNYYNNNN" 'Không cho phép thực hiện chức năng nào 
                    frm.IsLocalSearch = gc_IsNotLocalMsg
                    frm.IsLookup = "Y"
                    frm.SearchOnInit = False
                    frm.BranchId = Me.BranchId
                    frm.TellerId = Me.TellerId
                    frm.AFACCTNO = Trim(mskAFACCTNO.Text)
                    frm.LinkValue = Trim(Me.mskACTYPE.Text)
                    frm.CUSTID = mv_strTypeCondition
                    frm.ShowDialog()
                    If Trim(frm.ReturnValue).Length > 0 Then
                        GetFeeInfo(frm.ReturnValue)
                    End If
                    frm.Dispose()
                End If
            Case Keys.Enter
                If Not TypeOf (Me.ActiveControl) Is Button Then
                    SendKeys.Send("{Tab}")
                    e.Handled = True
                End If
        End Select
    End Sub
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        OnSubmit()
    End Sub

    Private Sub btnCANCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCANCEL.Click
        OnClose()
    End Sub

    Private Sub cboCODEID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCODEID.SelectedIndexChanged
        If mv_blnComboSymboLoad Then Return
        Dim v_strCodeID, v_strSYMBOL As String
        v_strSYMBOL = Convert.ToString(Me.cboCODEID.Text)
        ShowScreenBasedOnCodeID(v_strSYMBOL)
    End Sub

    Private Sub mskAFACCTNO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mskAFACCTNO.Validating
        Try
            If Len(mskAFACCTNO.Text) = 10 Then
                If VerifyCaredBy(mskAFACCTNO.Text.Replace(".", ""), "AFMAST") Then
                    GetAFContractInfo(mskAFACCTNO.Text)
                Else
                    mskAFACCTNO.Text = ""
                    Exit Sub
                End If
                'End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub mskAFACCTNO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskAFACCTNO.GotFocus
        Me.mskAFACCTNO.SelectAll()
    End Sub
    Private Sub btnApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApprove.Click
        OnApprove(TxDate, TxNum)
        Me.Close()
    End Sub
    Private Sub btnRefuse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        OnRefuse()
    End Sub
    Private Sub btnReject_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReject.Click
        OnReject(TxDate, TxNum)
    End Sub




#Region "TimerProcess"

    Private Sub frmCreateDFGRDeal_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        Me.tmrOrder.Dispose()
        Me.tmrOrder.Stop()
        Me.tmrOrder.Enabled = False
    End Sub


#End Region

#End Region

#Region "PrivateUtilFunction"
    Private Sub ShowScreenBasedOnCodeID(ByVal v_strSYMBOL As String)
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_strCmdSQL, v_strObjMsg As String
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strValue, v_strFLDNAME, v_strTEXT As String, i, j As Integer
        Try
            If v_strSYMBOL.Length >= 0 Then
                v_strCmdSQL = "  SELECT a.BASKETID,a.SYMBOL,  inf.TRADELOT, " & ControlChars.CrLf _
                            & "  (case when a.REFPRICE<=0 then inf.DFRLSPRICE else a.REFPRICE end) REFPRICE,  " & ControlChars.CrLf _
                            & "   case when dealtype='T' then 1*dfrate/100 else (case when a.DFPRICE <=0 then round((case when a.REFPRICE<=0 then inf.DFRLSPRICE else a.REFPRICE end)* a.dfrate/100,0) else a.DFPRICE end) end DFPRICE ,  " & ControlChars.CrLf _
                            & "  (case when a.TRIGGERPRICE<=0 then round((case when a.REFPRICE<=0 then inf.DFRLSPRICE else a.REFPRICE end)* a.lrate/100,0) else a.TRIGGERPRICE end) TRIGGERPRICE ,  " & ControlChars.CrLf _
                            & "  a.DFRATE,  " & ControlChars.CrLf _
                            & "  a.IRATE,  " & ControlChars.CrLf _
                            & "  a.MRATE,  " & ControlChars.CrLf _
                            & "  a.LRATE,  " & ControlChars.CrLf _
                            & "  a.CALLTYPE,  " & ControlChars.CrLf _
                            & "  a.IMPORTDT   " & ControlChars.CrLf _
                            & "  FROM DFBASKET A, DFTYPE B, securities_info inf   " & ControlChars.CrLf _
                            & "  WHERE A.BASKETID = B.BASKETID AND B.ACTYPE = '" & Me.mskACTYPE.Text.ToString.Trim & "' AND A.SYMBOL = '" & v_strSYMBOL & "'  " & ControlChars.CrLf _
                            & "  and a.symbol = inf.symbol  AND A.DEALTYPE= '" & mv_strDEALTYPE & "'"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strCmdSQL)
                v_ws.Message(v_strObjMsg)
                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

                For i = 0 To v_nodeList.Count - 1
                    For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            v_strValue = Trim(.InnerText.ToString)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME)
                                Case "REFPRICE"
                                    mv_strBASICPRICE = v_strValue
                                    Me.txtRefPrice.Text = v_strValue
                                Case "DFPRICE"
                                    Me.txtDFPrice.Text = v_strValue
                                    mv_strDFPRICE = v_strValue
                                Case "TRIGGERPRICE"
                                    Me.txtTRIGPRICE.Text = v_strValue
                                    mv_strTRIGGERPRICE = v_strValue
                                Case "DFRATE" '"BALANCE"
                                    Me.txtDFRATE.Text = v_strValue

                                    'Case "IRATE"
                                    '    Me.txtIRATE.Text = v_strValue
                                    'Case "MRATE"
                                    '    Me.txtMRATE.Text = v_strValue
                                Case "LRATE"
                                    mv_strLRATE = v_strValue
                                    Me.txtLRATE.Text = v_strValue
                                Case "MRATE"
                                    Me.txtMRATE.Text = v_strValue
                                Case "CALLTYPE"
                                    mv_strCALLTYPE = v_strValue
                                Case "TRADELOT"
                                    mv_dblTradeLot = CDbl(v_strValue)
                            End Select
                        End With
                    Next
                Next

                Me.cboRefPrice.Clears()
                Me.cboRefPrice.AddItems(mv_strBASICPRICE, BASICPRICE)
                If mv_strOPTPRICE = "O" OrElse mv_strOPTPRICE = "A" Then
                    Me.cboRefPrice.AddItems(mv_ResourceManager.GetString(OTHERS), OTHERS)
                End If
                Me.cboRefPrice.SelectedIndex = 0
                'Reset lại màn hình
                SetDealInfoByRefPrice()
                txtREF.Text = ""
                txtQuantity.Text = ""
                If mv_strRRTYPE <> "C" Then
                    Me.txtDFRATE.Enabled = False
                    Me.txtIRATE.Enabled = False
                    Me.txtMRATE.Enabled = False
                    Me.txtLRATE.Enabled = False
                Else
                    If mv_strCALLTYPE = "P" Then
                        Me.txtDFRATE.Enabled = False
                        Me.txtIRATE.Enabled = False
                        Me.txtMRATE.Enabled = False
                        Me.txtLRATE.Enabled = False
                    Else
                        Me.txtDFRATE.Enabled = True
                        Me.txtIRATE.Enabled = True
                        Me.txtMRATE.Enabled = True
                        Me.txtLRATE.Enabled = True
                        If mv_strIsADVCASH = "Y" Then
                            '16/11/2017 DieuNDA: Neu la UTCT thi khong cho sua ty le 
                            txtDFRATE.Enabled = False
                        Else
                            txtDFRATE.Enabled = True
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        Finally
            v_xmlDocument = Nothing
            v_ws = Nothing
        End Try
    End Sub

    Private Sub ResetVariables()
        'reset form
        Me.txtQuantity.Text = String.Empty
        Me.txtDFAMT.Text = String.Empty
        Me.txtDFPrice.Text = String.Empty
        Me.txtDFRATE.Text = String.Empty
        Me.txtIRATE.Text = String.Empty
        Me.txtLRATE.Text = String.Empty
        Me.txtMATVAL.Text = String.Empty
        Me.txtMRATE.Text = String.Empty
        Me.txtRefPrice.Text = String.Empty
        Me.txtTRIGPRICE.Text = String.Empty
        'reset variables

        'Thong tin chung khoan cho deal
        mv_strDFTYPENAME = String.Empty
        mv_strBASICPRICE = String.Empty
        mv_strDFPRICE = String.Empty
        mv_strTRIGGERPRICE = String.Empty
        mv_dblFEEAMT = 0
        mv_dblEXECQTTY = 0
        mv_dblDFTRADELOT = 0
        mv_dblMATCHPRICE = 0
        'Nhung bien danh cho phan Thanh ly tai ky
        mv_dblPRINOVD = 0
        mv_dblDEALPRINAMT = 0
        mv_dblPRINNML = 0
        mv_dblDEALFEE = 0
        mv_dblINTNMLOVD = 0
        mv_dblINTOVDACR = 0  'Tổng lãi trên gốc QH
        mv_dblINTDUE = 0     'Tổng lãi ĐH
        mv_dblINTNMLACR = 0  'Tổng lãi TH
        mv_dblFEEPAID = 0    'Tổng phí của deal
        mv_dblDFQTTY = 0     'Số chứng khoán có thể bán
        mv_dblRCVQTTY = 0    'Số chứng khoán chờ về
        mv_dblCARCVQTTY = 0  'Số chứng khoán quyền chờ về
        mv_dblBLOCKQTTY = 0  'Số chứng khoán hạn chế chuyển nhượng     
        mv_dblBQTTY = 0       'Số chứng khoán đang bán     
        mv_dblSECURED = 0       'Số chứng khoán ký quỹ bán     
        mv_dblREMAINQTTY = 0       'Số chứng khoán hiện đang vay
        mv_dblLIMITCHECK = 0  'Kiểm tra hạn mức    
        mv_dblBALANCE = 0  'Số dư có thể sử dụng
        mv_dblAPMT = 0  'Số dư có thể ứng trước
        mv_dblADVANCELINE = 0  'Bảo lãnh thấu chi    
        mv_dblODAMT = 0  'Số dư thấu chi   
        mv_dblTOTALPAID = 0 'Tổng số tiền phải trả
        mv_dblTOTALSECURITIES = 0 'Tổng số chứng khoán release
        mv_dblPP = 0 'Sức mua
        mv_dblORGDFQTTY = 0     'Số chứng khoán có thể bán lúc lấy lên ban đầu
        mv_dblORGRCVQTTY = 0
        mv_dblORGCARCVQTTY = 0
        mv_dblORGBLOCKQTTY = 0
        mv_dblREALBALWITHDRAWN = 0
        mv_dblRLSAMT = 0
        mv_dblRLSQTTY = 0
    End Sub
    Private Sub GetFeeInfo(ByVal v_strFeeCD As String)
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strCmdSQL As String, v_strObjMsg As String
        Dim v_strValue, v_strFLDNAME As String
        Dim i, j As Integer

        Try
            txtFeeRate.Text = "0"
            txtFeeAmt.Text = "0"
            mv_feeamt = 0
            mskDFFeeMap.Text = v_strFeeCD
            v_strCmdSQL = "SELECT * FROM FEEMASTER WHERE FEECD = " & v_strFeeCD
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_AFMAST, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            If v_nodeList.Count > 0 Then
                For i = 0 To v_nodeList.Count - 1
                    For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            v_strValue = .InnerText.ToString
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME)
                                Case "FEERATE"
                                    txtFeeRate.Text = Trim(v_strValue)
                                Case "MAXVAL"
                                    mv_intFeeMax = FormatNumber(CDbl(v_strValue), 4)
                                Case "MINVAL"
                                    mv_intFeeMin = FormatNumber(CDbl(v_strValue), 4)
                            End Select
                        End With
                    Next
                Next
            End If
            mv_feeamt = Math.Max(mv_intFeeMin, Math.Min((CDbl(IIf((txtFeeRate.Text.Length > 0), txtFeeRate.Text, 0)) / 100) * (CDbl(mv_strBASICPRICE) * CDbl(IIf((txtQuantity.Text.Length > 0), txtQuantity.Text, 0))), mv_intFeeMax))
            txtFeeAmt.Text = mv_feeamt.ToString()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub GetDealInfo(ByVal v_strDealID As String)
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_strValue, v_strFLDNAME, v_strTEXT, v_strMINBRATIO, v_strMAXBRATIO As String, i, j As Integer
        Dim v_dblPrice As Double
        Dim v_strDTYPE, v_strCODEID, v_strSYMBOL, v_strQTTY, v_strTXDATE As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strCmdSQL As String, v_strObjMsg As String

        Try
            v_strTXDATE = String.Empty
            If Me.chkOPTIONSTOCK.Checked Then
                v_strCmdSQL = "SELECT * FROM v_getCreateDeal A WHERE A.STATUS = 'W' and A.AUTOID ='" & v_strDealID & "' AND A.QTTY>0 and symbol in (select symbol from dfbasket bk, dftype dft where bk.basketid = dft.basketid and dft.actype = '" & Trim(Me.mskACTYPE.Text) & "') and DTYPE in " & mv_strTypeCondition
            Else
                v_strCmdSQL = "SELECT * FROM v_getCreateDeal A WHERE A.STATUS <> 'W' and A.AUTOID ='" & v_strDealID & "' AND A.QTTY>0 and symbol in (select symbol from dfbasket bk, dftype dft where bk.basketid = dft.basketid and dft.actype = '" & Trim(Me.mskACTYPE.Text) & "') and DTYPE in " & mv_strTypeCondition
            End If
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_AFMAST, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            If v_nodeList.Count > 0 Then
                For i = 0 To v_nodeList.Count - 1
                    For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            v_strValue = .InnerText.ToString
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME)
                                Case "QTTY"
                                    v_strQTTY = Trim(v_strValue)
                                Case "CODEID"
                                    v_strCODEID = Trim(v_strValue)
                                Case "SYMBOL"
                                    v_strSYMBOL = Trim(v_strValue)
                                Case "AFACCTNO"
                                    mv_strDFAFACCTNO = Trim(v_strValue)
                                    Me.mskAFACCTNO.Text = Trim(v_strValue)
                                Case "PRICE"
                                    v_dblPrice = CDbl(IIf(IsNumeric(v_strValue), v_strValue, 0))
                                    mv_dblMATCHPRICE = v_dblPrice
                                Case "DTYPE"
                                    v_strDTYPE = Trim(v_strValue)
                                Case "TXDATE"
                                    v_strTXDATE = Trim(v_strValue)
                            End Select
                        End With
                    Next
                Next

                Me.cboCODEID.SelectedValue = v_strCODEID
                Me.txtREF.Text = v_strDealID
                Me.txtREF.Tag = v_strTXDATE
                'Me.txtQuantity.Text = v_strQTTY 'SONLT 20141220 Khong can thiet phai gan lai
                'Margin Loan chứng khoán chờ về sẽ lấy theo giá deal
                'Forward chứng khoán mua chờ về sẽ theo tham số loại hình
                If (mv_strDFTYPE = "L" And v_strDTYPE = "R" And v_dblPrice > 0) Or _
                    (mv_strOPTPRICE = "D" And mv_strDFTYPE = "F" And v_strDTYPE = "R" And v_dblPrice > 0) Then
                    Me.cboRefPrice.Clears()
                    Me.cboRefPrice.AddItems(v_dblPrice.ToString, MATCHPRICE)
                    'Me.cboRefPrice.Items.Add(v_dblPrice.ToString)
                    Me.cboRefPrice.SelectedIndex = 0

                ElseIf (mv_strOPTPRICE = "A" And mv_strDFTYPE = "F" And v_strDTYPE = "R" And v_dblPrice > 0) Then 'Or (mv_strOPTPRICE = "A" And mv_strDFTYPE = "A" And v_strDTYPE = "P" And v_dblPrice > 0) Then
                    'Me.cboRefPrice.Items.Clear()
                    'Me.cboRefPrice.Items.Add(v_dblPrice.ToString)
                    'Me.cboRefPrice.Items.Add(mv_strBASICPRICE)
                    Me.cboRefPrice.Clears()
                    Me.cboRefPrice.AddItems(v_dblPrice.ToString, MATCHPRICE)
                    Me.cboRefPrice.AddItems(mv_strBASICPRICE, BASICPRICE)
                    Me.cboRefPrice.SelectedIndex = 0
                    'Neu la vay de mua chung khoan quyen mua thi them gia quyen mua vao
                ElseIf mv_strDFTYPE = "B" AndAlso v_strDTYPE = "P" AndAlso v_dblPrice > 0 Then
                    Me.cboRefPrice.Clears()
                    Me.cboRefPrice.AddItems(v_dblPrice.ToString, OPTIONPRICE)
                    Me.cboRefPrice.AddItems(mv_strBASICPRICE, BASICPRICE)
                    Me.cboRefPrice.SelectedIndex = 0
                ElseIf v_strDTYPE = "T" Then
                    'Me.cboRefPrice.Items.Add(mv_strBASICPRICE)
                    Me.cboRefPrice.Clears()
                    Me.cboRefPrice.AddItems(1, "CA")
                    Me.cboRefPrice.SelectedIndex = 0
                Else
                    'Mặc định là giá theo rổ
                    'Me.cboRefPrice.Items.Clear()
                    'Me.cboRefPrice.Items.Add(mv_strBASICPRICE)
                    Me.cboRefPrice.Clears()
                    Me.cboRefPrice.AddItems(mv_strBASICPRICE, BASICPRICE)
                    Me.cboRefPrice.SelectedIndex = 0
                End If

                If mv_strOPTPRICE = "O" OrElse mv_strOPTPRICE = "A" Then
                    Me.cboRefPrice.AddItems(mv_ResourceManager.GetString(OTHERS), OTHERS)
                End If
                'Me.txtRefPrice.Text = v_dblPrice
                SetDealInfoByRefPrice()

                'Linh gop deal chung khoan cho ve.
                'v_strCmdSQL = "select od.execamt matval, od.execamt*(ot.deffeerate/100) feeamt, od.execqtty, seinf.tradelot from stschd sts, odmast od, odtype ot, SECURITIES_INFO seinf where sts.orgorderid = od.orderid and duetype = 'RS' and od.actype = ot.actype and od.codeid = seinf.codeid and sts.autoid = '" & v_strDealID & "'"
                v_strCmdSQL = "select sum(od.execamt) matval, sum(od.execamt*(ot.deffeerate/100)) feeamt, sum(od.execqtty) execqtty, seinf.tradelot , sts.codeid, sts.afacctno " & ControlChars.CrLf _
                            & " from stschd sts, odmast od, odtype ot, SECURITIES_INFO seinf  " & ControlChars.CrLf _
                            & " where sts.orgorderid = od.orderid and duetype = 'RS' and od.actype = ot.actype  " & ControlChars.CrLf _
                            & " and od.codeid = seinf.codeid and (to_char(sts.txdate,'DD/MM/YYYY') || sts.afacctno || sts.codeid || to_char(sts.clearday)) = '" & v_strDealID & "'  " & ControlChars.CrLf _
                            & " GROUP BY sts.txdate, (to_char(sts.txdate,'DD/MM/YYYY') || sts.afacctno || to_char(sts.clearday)), sts.afacctno, sts.codeid,seinf.tradelot "

                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_AFMAST, gc_ActionInquiry, v_strCmdSQL)
                v_ws.Message(v_strObjMsg)
                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                If v_nodeList.Count > 0 Then
                    For i = 0 To v_nodeList.Count - 1
                        For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                            With v_nodeList.Item(i).ChildNodes(j)
                                v_strValue = .InnerText.ToString
                                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                Select Case Trim(v_strFLDNAME)
                                    Case "MATVAL"
                                        Me.txtMATVAL.Text = FormatNumber(v_strValue, 0)
                                        'Ducnv formatnumber
                                        Me.txtDFAMT.Text = FormatNumber(CStr(CDbl(Me.txtQuantity.Text) * CDbl(Me.txtRefPrice.Text) * (CDbl(Me.txtDFRATE.Text) / 100)), 0)
                                    Case "FEEAMT"
                                        mv_dblFEEAMT = CDbl(IIf(IsNumeric(v_strValue), v_strValue, 0))
                                    Case "EXECQTTY"
                                        mv_dblEXECQTTY = CDbl(IIf(IsNumeric(v_strValue), v_strValue, 0))
                                    Case "TRADELOT"
                                        mv_dblDFTRADELOT = CDbl(IIf(IsNumeric(v_strValue), v_strValue, 0))

                                End Select
                            End With
                        Next
                    Next
                Else
                    Me.txtMATVAL.Text = CStr(CDbl(Me.txtQuantity.Text) * CDbl(Me.cboRefPrice.Text))
                    Me.txtDFAMT.Text = FormatNumber(CStr(CDbl(Me.txtQuantity.Text) * CDbl(Me.cboRefPrice.Text) * (CDbl(Me.txtDFRATE.Text) / 100)), 0)
                End If

                v_strCmdSQL = "SELECT a.CAMASTID, decode(b.corebank, 'N', 1,0) ISCOREBANK FROM caschd A, cimast b WHERE a.afacctno = b.afacctno and A.AUTOID ='" & v_strDealID & "'"

                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_AFMAST, gc_ActionInquiry, v_strCmdSQL)
                v_ws.Message(v_strObjMsg)
                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                If v_nodeList.Count > 0 Then
                    For i = 0 To v_nodeList.Count - 1
                        For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                            With v_nodeList.Item(i).ChildNodes(j)
                                v_strValue = .InnerText.ToString
                                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                Select Case Trim(v_strFLDNAME)
                                    Case "CAMASTID"
                                        mv_strCAMASTID = v_strValue
                                    Case "ISCOREBANK"
                                        mv_dblISCOREBANK = CDbl(IIf(IsNumeric(v_strValue), v_strValue, 0))
                                End Select
                            End With
                        Next
                    Next
                End If
            Else
                MsgBox(mv_ResourceManager.GetString("DEALINVALID"), MsgBoxStyle.Information, Me.Text)
                Me.ActiveControl = Me.btnGetDeal
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub ShowSENormalMode(ByVal pv_strCodeID As String)
        Try
            Dim v_strCmdSQL, v_strAFACCTNO, v_strObjMsg As String
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            If mskAFACCTNO.Text.Length > 0 Then
                v_strAFACCTNO = Me.mskAFACCTNO.Text.Trim
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
                'End If
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
            Dim v_strTellerName As String = String.Empty
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

    Private Sub mskACTYPE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskACTYPE.GotFocus
        Me.mskACTYPE.SelectAll()
    End Sub

    Private Sub mskACTYPE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mskACTYPE.Validating
        Try
            If Len(mskACTYPE.Text) = 4 Then
                'Lấy thông tin loại sản phẩm
                If Me.chkENDNEWDEAL.Checked = True AndAlso Me.txtOLDDEALNO.Text.Trim.Length > 0 AndAlso Me.cboCODEID.Text.Trim.Length > 0 Then
                    GetDFType(mskACTYPE.Text, Me.cboCODEID.SelectedValue)
                Else
                    GetDFType(mskACTYPE.Text)
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtQuantity_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtQuantity.Validating
        If Me.txtQuantity.Text.Length > 0 Then
            If Not IsNumeric(txtQuantity.Text) Then
                MsgBox(mv_ResourceManager.GetString("QTTYISNOTNUMBER"), MsgBoxStyle.Information, Me.Text)
                e.Cancel = True
                Return
            ElseIf Math.Floor(CDbl(txtQuantity.Text)) <= 0 Then
                MsgBox(mv_ResourceManager.GetString("QTTYISNOTNUMBER"), MsgBoxStyle.Information, Me.Text)
                e.Cancel = True
                Return
            Else
                If cboRefPrice.SelectedValue.ToString = MATCHPRICE Then
                    'ducnv FormatNumber(
                    Me.txtDFAMT.Text = FormatNumber((FRound(CDbl(Me.txtMATVAL.Text) / mv_dblEXECQTTY * CDbl(Me.txtQuantity.Text) * CDbl(Me.txtDFRATE.Text) / 100)), 0)
                ElseIf cboRefPrice.SelectedValue.ToString = OTHERS Then
                    If Me.txtMATVAL.Text.Length <> 0 AndAlso Me.txtQuantity.Text.Length > 0 AndAlso Me.txtDFRATE.Text.Length > 0 Then
                        Me.txtDFAMT.Text = FormatNumber((FRound(CDbl(Me.txtMATVAL.Text) / mv_dblEXECQTTY * CDbl(Me.txtQuantity.Text) * CDbl(Me.txtDFRATE.Text) / 100)), 0)
                    Else
                        If CDbl(IIf(Me.txtDFAMT.Text = String.Empty, "0", Me.txtDFAMT.Text)) > CDbl(mv_strBASICPRICE) * CDbl(Me.txtQuantity.Text) * CDbl(Me.txtDFRATE.Text) / 100 OrElse Me.txtDFAMT.Text = String.Empty Then
                            Me.txtDFAMT.Text = FormatNumber(CDbl(mv_strBASICPRICE) * CDbl(Me.txtQuantity.Text) * CDbl(Me.txtDFRATE.Text) / 100, 0)
                        End If
                    End If
                End If
                txtQuantity.Text = FormatNumber(Math.Floor(CDbl(txtQuantity.Text)), 0)
                SetDealInfoByRefPrice()

                calcCashtopay()

            End If
            mv_feeamt = Math.Max(mv_intFeeMin, Math.Min((CDbl(IIf((txtFeeRate.Text.Length > 0), txtFeeRate.Text, 0)) / 100) * (CDbl(mv_strBASICPRICE) * CDbl(IIf((txtQuantity.Text.Length > 0), txtQuantity.Text, 0))), mv_intFeeMax))
            txtFeeAmt.Text = mv_feeamt.ToString()
        End If
    End Sub
    Private Sub txtRefPrice_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtRefPrice.Validating
        If Not IsNumeric(txtRefPrice.Text) Then
            MsgBox(mv_ResourceManager.GetString("PRICEISNOTNUMBER"), MsgBoxStyle.Information, Me.Text)
            e.Cancel = True
            Return
            'ElseIf CDbl(txtRefPrice.Text) < 0 Then
            '    MsgBox(mv_ResourceManager.GetString("PRICEISNOTNUMBER"), MsgBoxStyle.Information, Me.Text)
            '    e.Cancel = True
            '    Return
        End If
    End Sub

    Private Sub txtDFPrice_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDFPrice.Validating
        If Not IsNumeric(txtDFPrice.Text) Then
            MsgBox(mv_ResourceManager.GetString("PRICEISNOTNUMBER"), MsgBoxStyle.Information, Me.Text)
            e.Cancel = True
            Return
        ElseIf CDbl(txtDFPrice.Text) <= 0 Then
            MsgBox(mv_ResourceManager.GetString("PRICEISNOTNUMBER"), MsgBoxStyle.Information, Me.Text)
            e.Cancel = True
            Return
        End If
        'If CDbl(txtDFPrice.Text) > CDbl(txtRefPrice.Text) Then
        '    MsgBox(mv_ResourceManager.GetString("DFPRICE_OVER_REFPRICE"), MsgBoxStyle.Information, Me.Text)
        '    e.Cancel = True
        '    Return
        'End If
        mv_feeamt = Math.Max(mv_intFeeMin, Math.Min((CDbl(IIf((txtFeeRate.Text.Length > 0), txtFeeRate.Text, 0)) / 100) * (CDbl(mv_strBASICPRICE) * CDbl(IIf((txtQuantity.Text.Length > 0), txtQuantity.Text, 0))), mv_intFeeMax))
        txtFeeAmt.Text = mv_feeamt.ToString()
    End Sub

    Private Sub txtTRIGPRICE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTRIGPRICE.Validating
        If Not IsNumeric(txtTRIGPRICE.Text) Then
            MsgBox(mv_ResourceManager.GetString("PRICEISNOTNUMBER"), MsgBoxStyle.Information, Me.Text)
            e.Cancel = True
            Return
        ElseIf CDbl(txtTRIGPRICE.Text) < 0 Then
            MsgBox(mv_ResourceManager.GetString("PRICEISNOTNUMBER"), MsgBoxStyle.Information, Me.Text)
            e.Cancel = True
            Return
        End If
        If CDbl(txtTRIGPRICE.Text) > CDbl(txtRefPrice.Text) Then
            MsgBox(mv_ResourceManager.GetString("TRIGGERPRICE_OVER_REFPRICE"), MsgBoxStyle.Information, Me.Text)
            e.Cancel = True
            Return
        End If
    End Sub

    Private Sub txtDFRATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDFRATE.Validating
        If Not IsNumeric(txtDFRATE.Text) Then
            MsgBox(mv_ResourceManager.GetString("RATENONUMBER"), MsgBoxStyle.Information, Me.Text)
            e.Cancel = True
            Return
        ElseIf CDbl(txtDFRATE.Text) <= 0 Then
            MsgBox(mv_ResourceManager.GetString("RATENONUMBER"), MsgBoxStyle.Information, Me.Text)
            e.Cancel = True
            Return
        Else
            setValueByCalltype()
            SetDealInfoByRefPrice()
            calcCashtopay()
        End If
    End Sub

    Private Sub txtIRATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtIRATE.Validating
        If Not IsNumeric(txtIRATE.Text) Then
            MsgBox(mv_ResourceManager.GetString("RATENONUMBER"), MsgBoxStyle.Information, Me.Text)
            e.Cancel = True
            Return
        ElseIf CDbl(txtIRATE.Text) <= 0 Then
            MsgBox(mv_ResourceManager.GetString("RATENONUMBER"), MsgBoxStyle.Information, Me.Text)
            e.Cancel = True
            Return
        End If
    End Sub

    Private Sub txtMRATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtMRATE.Validating
        If Not IsNumeric(txtMRATE.Text) Then
            MsgBox(mv_ResourceManager.GetString("RATENONUMBER"), MsgBoxStyle.Information, Me.Text)
            e.Cancel = True
            Return
        ElseIf CDbl(txtMRATE.Text) <= 0 Then
            MsgBox(mv_ResourceManager.GetString("RATENONUMBER"), MsgBoxStyle.Information, Me.Text)
            e.Cancel = True
            Return
        End If
    End Sub

    Private Sub txtLRATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLRATE.Validating
        If Not IsNumeric(txtLRATE.Text) Then
            MsgBox(mv_ResourceManager.GetString("RATENONUMBER"), MsgBoxStyle.Information, Me.Text)
            e.Cancel = True
            Return
        ElseIf CDbl(txtLRATE.Text) <= 0 Then
            MsgBox(mv_ResourceManager.GetString("RATENONUMBER"), MsgBoxStyle.Information, Me.Text)
            e.Cancel = True
            Return
        End If
    End Sub
    Private Sub DisplayConfirm()

    End Sub


    Private Sub btnGetDeal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetDeal.Click
        Dim frm As New frmSearch(Me.UserLanguage)
        frm.TableName = "DFCREATEDEAL"
        frm.ModuleCode = "DF"
        frm.AuthCode = "NNNNYYNNNN" 'Không cho phép thực hiện chức năng nào 
        frm.IsLocalSearch = gc_IsNotLocalMsg
        frm.IsLookup = "Y"
        frm.SearchOnInit = False
        frm.BranchId = Me.BranchId
        frm.TellerId = Me.TellerId
        frm.AFACCTNO = Trim(mskAFACCTNO.Text)
        frm.LinkValue = Trim(Me.mskACTYPE.Text)
        frm.CUSTID = mv_strTypeCondition
        frm.ShowDialog()
        Me.txtREF.Text = Trim(frm.ReturnValue)
        If Trim(frm.ReturnValue).Length > 0 Then
            GetDealInfo(frm.ReturnValue)
        End If
        frm.Dispose()
    End Sub

    Private Sub cboAFACCCBO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAFACCCBO.SelectedIndexChanged
        If Not Me.cboAFACCCBO.SelectedValue Is Nothing Then
            If Len(Trim(Me.cboAFACCCBO.SelectedValue.ToString())) > 0 Then
                'Me.ActiveControl.Text = Trim(Me.cboAFACCCBO.SelectedValue.ToString())
                'lblAFNAME.Text = Trim(Me.cboAFACCCBO.SelectedText)
                'Nạp thông tin tài khoản mới
                Me.mskAFACCTNO.Text = Trim(Me.cboAFACCCBO.SelectedValue.ToString().Replace(".", ""))
                GetAFContractInfo(Me.mskAFACCTNO.Text)
                Me.cboAFACCTNODRD.Text = Me.mskAFACCTNO.Text
            End If
        End If
    End Sub

    Private Sub mskCUSTODYCD_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mskCUSTODYCD.Validating
        Dim v_strCMDSQL, v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Me.mskCUSTODYCD.Text = Me.mskCUSTODYCD.Text.ToUpper()
        v_strCMDSQL = "SELECT FILTERCD, VALUE, VALUECD, DISPLAY, EN_DISPLAY, DESCRIPTION FROM VW_CUSTODYCD_SUBACCOUNT WHERE FILTERCD='" & Trim(Me.mskCUSTODYCD.Text) & "' ORDER BY VALUE"
        'v_strCMDSQL = "SELECT MST.FILTERCD, MST.VALUE, MST.VALUECD, MST.DISPLAY, MST.EN_DISPLAY, MST.DESCRIPTION " _
        '    & "FROM VW_CUSTODYCD_SUBACCOUNT_ACTIVE MST," _ 
        '    & "tlgrpusers TL, AFTYPE AFT, MRTYPE MR, AFMAST AFM " _
        '    & "WHERE MST.FILTERCD='" & Trim(Me.mskCUSTODYCD.Text) & "' AND MST.CAREBY=TL.GRPID " _
        '    & "AND MST.VALUE = AFM.ACCTNO AND AFM.ACTYPE = AFT.ACTYPE AND AFT.MRTYPE = MR.ACTYPE " _
        '    & "ORDER BY MST.VALUE"
        '& "AND TL.BRID='" & Me.BranchId _ 'sonlt 20141104 Khong can lay danh sach usser theo chi nhanh nua
        '& "' AND TL.TLID='" & Me.TellerId _ 'sonlt 20141104 Khong can lay danh sach usser theo care by nua


        '& "AND TL.BRID='" & Me.BranchId & "' AND TL.TLID='" & Me.TellerId & "' ORDER BY MST.VALUE"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCMDSQL)
        v_ws.Message(v_strObjMsg)
        FillComboEx(v_strObjMsg, Me.cboAFACCCBO, "", Me.UserLanguage)
        FillComboEx(v_strObjMsg, Me.cboAFACCTNODRD, "", Me.UserLanguage)
        If Me.cboAFACCCBO.Items.Count > 0 Then
            Me.cboAFACCCBO.SelectedIndex = 0
            'Lấy thông tin
            GetAFContractInfo(cboAFACCCBO.SelectedValue.ToString().Replace(".", ""))
        Else
            MsgBox(mv_ResourceManager.GetString("ERR_CF_CONTRACT_NOT_FOUND"), MsgBoxStyle.Information, Me.Text)
            mskCUSTODYCD.Focus()
        End If
    End Sub

    Private Sub cboRefPrice_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRefPrice.SelectedIndexChanged
        If cboRefPrice.SelectedIndex <> -1 Then
            If cboRefPrice.SelectedValue.ToString = OTHERS Then
                If Trim(Me.txtREF.Text).Length <> 0 AndAlso (Me.mv_strDFTYPE = "F" OrElse Me.mv_strDFTYPE = "L") AndAlso Me.txtMATVAL.Text.Length > 0 AndAlso mv_dblEXECQTTY <> 0 Then
                    Me.txtRefPrice.Text = FRound(CDbl(Me.txtMATVAL.Text) / mv_dblEXECQTTY, 4)
                Else
                    Me.txtRefPrice.Text = CDbl(mv_strBASICPRICE)
                End If
            Else
                Me.txtRefPrice.Text = Me.cboRefPrice.Text
            End If

            If cboRefPrice.SelectedValue.ToString() = MATCHPRICE Then
                Me.lblMATVAL.Visible = True
                Me.txtMATVAL.Visible = True

                Me.txtDFAMT.ReadOnly = True
                Me.txtDFAMT.Enabled = False

                Me.txtDFPrice.ReadOnly = True
                Me.txtDFPrice.Enabled = False

                Me.txtTRIGPRICE.ReadOnly = True
                Me.txtTRIGPRICE.Enabled = False
            ElseIf cboRefPrice.SelectedValue.ToString() = OTHERS Then
                Me.lblMATVAL.Visible = False
                Me.txtMATVAL.Visible = False

                Me.txtDFAMT.ReadOnly = False
                Me.txtDFAMT.Enabled = True

                Me.txtDFPrice.ReadOnly = True
                Me.txtDFPrice.Enabled = False

                Me.txtTRIGPRICE.ReadOnly = False
                Me.txtTRIGPRICE.Enabled = True
            Else
                Me.lblMATVAL.Visible = False
                Me.txtMATVAL.Visible = False
                Me.txtDFAMT.ReadOnly = True
                If cboRefPrice.SelectedValue.ToString() = BASICPRICE Then
                    Me.txtDFPrice.ReadOnly = True
                    Me.txtDFPrice.Enabled = False
                Else
                    Me.txtDFPrice.ReadOnly = False
                    Me.txtDFPrice.Enabled = True
                    If mv_strIsADVCASH = "Y" Then
                        '16/11/2017 DieuNDA: Neu la UTCT thi khong cho sua ty le 
                        txtDFPrice.Enabled = False
                    End If
                End If
                    Me.txtTRIGPRICE.ReadOnly = True
                    Me.txtTRIGPRICE.Enabled = False
            End If
            'Reset lại màn hình
            SetDealInfoByRefPrice()
            If chkENDNEWDEAL.Checked AndAlso Me.txtQuantity.Text.Trim.Length > 0 Then
                calcCashtopay()
            End If
        End If
    End Sub

    'Private Sub txtDFAMT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDFAMT.Validating
    '    Dim v_dblDfamt, v_dblDfprice, v_dblDfQtty As Double

    '    If IsNumeric(Me.txtDFAMT.Text) Then
    '        If Me.txtMATVAL.Text <> "" AndAlso CDbl(Me.txtMATVAL.Text) <> 0 Then
    '            v_dblDfamt = CDbl(Me.txtDFAMT.Text)
    '            'v_dblDfQtty = Math.Ceiling((CDbl(Me.txtDFAMT.Text) / CDbl(Me.txtMATVAL.Text)) * mv_dblEXECQTTY * CDbl(Me.txtDFRATE.Text) / 100)
    '            v_dblDfQtty = Math.Ceiling((CDbl(Me.txtDFAMT.Text) / CDbl(Me.txtMATVAL.Text)) * mv_dblEXECQTTY)
    '            v_dblDfprice = FRound(v_dblDfamt / ((CDbl(Me.txtDFAMT.Text) / CDbl(Me.txtMATVAL.Text)) * mv_dblEXECQTTY * CDbl(Me.txtDFRATE.Text) / 100), 4)
    '            Me.txtDFPrice.Text = CStr(v_dblDfprice)
    '            Me.txtQuantity.Text = CStr(roundTradelot(v_dblDfQtty))
    '        End If
    '    End If
    'End Sub

    Private Function roundTradelot(ByVal aDbl As Double) As Double
        Dim result, temp1, temp2 As Double
        temp1 = aDbl Mod mv_dblDFTRADELOT
        temp2 = aDbl - temp1
        If temp1 < mv_dblDFTRADELOT / 2 Then
            result = temp2
        Else
            result = temp2 + mv_dblDFTRADELOT
        End If
        Return result
    End Function

    Private Sub calcDFAmount()
        'Tinh ra gia tri vay tu so luong vay va so luong khop
        If Me.cboRefPrice.SelectedValue.ToString = MATCHPRICE AndAlso IsNumeric(Me.txtQuantity.Text) AndAlso CDbl(Me.txtQuantity.Text) <> 0 AndAlso Me.txtMATVAL.Text <> "" Then
            Dim v_dblDfamt, v_dblDfprice, v_dblDfQtty As Double

            v_dblDfQtty = CDbl(Me.txtQuantity.Text)
            v_dblDfamt = (v_dblDfQtty / mv_dblEXECQTTY) * CDbl(Me.txtMATVAL.Text) * (CDbl(Me.txtDFRATE.Text) / 100)
            v_dblDfprice = FRound(v_dblDfamt / v_dblDfQtty, 4)
            'Ducnv FormatNumber(
            Me.txtDFAMT.Text = FormatNumber(CStr(FRound(v_dblDfamt)), 0)
            Me.txtDFPrice.Text = CStr(v_dblDfprice)
        ElseIf Me.cboRefPrice.SelectedValue.ToString = OTHERS AndAlso IsNumeric(Me.txtQuantity.Text) AndAlso CDbl(Me.txtQuantity.Text) <> 0 Then
            Dim v_dblDfamt, v_dblDfprice, v_dblDfQtty As Double

            v_dblDfQtty = CDbl(Me.txtQuantity.Text)
            If Me.txtMATVAL.Text.Length <> 0 Then
                If CDbl(Me.txtDFAMT.Text) > CDbl(Me.txtMATVAL.Text) / mv_dblEXECQTTY * CDbl(Me.txtQuantity.Text) * CDbl(Me.txtDFRATE.Text) / 100 Then
                    Me.txtDFAMT.Text = FormatNumber((FRound(CDbl(Me.txtMATVAL.Text) / mv_dblEXECQTTY * CDbl(Me.txtQuantity.Text) * CDbl(Me.txtDFRATE.Text) / 100)), 0)
                End If
            Else
                If CDbl(IIf(Me.txtDFAMT.Text = String.Empty, "0", Me.txtDFAMT.Text)) > CDbl(mv_strBASICPRICE) * CDbl(Me.txtQuantity.Text) * CDbl(Me.txtDFRATE.Text) / 100 OrElse Me.txtDFAMT.Text = String.Empty Then
                    Me.txtDFAMT.Text = FormatNumber(CDbl(mv_strBASICPRICE) * CDbl(Me.txtQuantity.Text) * CDbl(Me.txtDFRATE.Text) / 100, 0)
                End If
            End If
            v_dblDfamt = CDbl(Me.txtDFAMT.Text)
            v_dblDfprice = FRound(v_dblDfamt / v_dblDfQtty, 4)
            Me.txtDFPrice.Text = CStr(v_dblDfprice)
            'Me.txtTRIGPRICE.Text = FRound(CDbl(Me.txtDFPrice.Text) * CDbl(Me.txtLRATE.Text) / 100)
        Else
            Me.txtDFPrice.Text = FRound(CDbl(Me.txtRefPrice.Text) * CDbl(Me.txtDFRATE.Text) / 100)
        End If
    End Sub

    'Lay thong tin cua deal tu so hieu Deal DFMAST
    Private Sub getDealInfoByAcctno(ByVal v_strDFAcctno As String)
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_strValue, v_strFLDNAME, v_strTEXT, v_strMINBRATIO, v_strMAXBRATIO As String, i, j As Integer
        Dim v_dblPrice As Double
        Dim v_strDTYPE, v_strCODEID, v_strSYMBOL, v_strQTTY, v_strTXDATE, v_strACTYPE, v_strDFREF, v_strMATCHPRICE As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strCmdSQL As String, v_strObjMsg As String

        Try
            v_strTXDATE = String.Empty
            v_strCmdSQL = "select v.*,cd.cdcontent DEALTYPE, sb.tradelot, " _
                        & "v.PRINNML+v.INTNMLACR+v.INTDUE+v.OPRINNML+v.OINTNMLACR+v.OINTDUE+v.FEE+v.FEEDUE -nvl(sts.NML,0) INDUEAMT, " _
                        & "nvl(sts.NML,0) DUEAMT, v.PRINOVD+v.INTOVDACR+v.INTNMLOVD+v.OPRINOVD+v.OINTOVDACR+v.OINTNMLOVD+v.FEEOVD OVERDUEAMT, " _
                        & "mst.EXPDATE, (CASE WHEN TYP.NINTCD='000' THEN 1 ELSE 0 END) FLAGINTACR, " _
                        & "0 INTDAY, 0 INTOVDDAY, " _
                        & "v.INTNMLACR+ v.OINTNMLACR + v.OINTOVDACR + v.INTOVDACR INTACR, greatest(v.INTAMTACR+v.feeamt,v.FEEMIN-v.RLSFEEAMT) DEALFEEAMT " _
                        & "from v_getDealInfo v, allcode cd, securities_info sb, " _
                        & " (SELECT S.ACCTNO, SUM(NML) NML, M.TRFACCTNO FROM LNSCHD S, LNMAST M " _
                        & "        WHERE S.OVERDUEDATE = TO_DATE((select varvalue from sysvar where grname ='SYSTEM' and varname ='CURRDATE'),'DD/MM/RRRR') AND S.NML > 0 AND S.REFTYPE IN ('P') " _
                        & "            AND S.ACCTNO = M.ACCTNO AND M.STATUS NOT IN ('P','R','C') " _
                        & "        GROUP BY S.ACCTNO, M.TRFACCTNO " _
                        & "        ORDER BY S.ACCTNO) sts, lnmast mst, lntype typ, (select TO_DATE(VARVALUE,'DD/MM/RRRR') currdate from sysvar where varname='CURRDATE') dt " _
                        & "where v.status='A' and v.lnacctno = sts.acctno (+) and v.codeid=sb.codeid " _
                        & "and mst.actype=typ.actype and v.lnacctno=mst.acctno " _
                        & "and cd.cdname='DFTYPE' and cd.cdtype='DF' and cd.cdval=v.dftype " _
                        & "and v.acctno = '" & v_strDFAcctno & "'"

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_AFMAST, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            If v_nodeList.Count > 0 Then
                For i = 0 To v_nodeList.Count - 1
                    For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            v_strValue = .InnerText.ToString
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME)
                                Case "PRINOVD"
                                    mv_dblPRINOVD = CDbl(IIf(IsNumeric(v_strValue), v_strValue, 0))
                                Case "DEALPRINAMT"
                                    mv_dblDEALPRINAMT = CDbl(IIf(IsNumeric(v_strValue), v_strValue, 0))
                                Case "PRINNML"
                                    mv_dblPRINNML = CDbl(IIf(IsNumeric(v_strValue), v_strValue, 0))
                                Case "DEALFEE"
                                    mv_dblDEALFEE = CDbl(IIf(IsNumeric(v_strValue), v_strValue, 0))
                                Case "INTNMLOVD"
                                    mv_dblINTNMLOVD = CDbl(IIf(IsNumeric(v_strValue), v_strValue, 0))
                                Case "INTOVDACR"
                                    mv_dblINTOVDACR = CDbl(IIf(IsNumeric(v_strValue), v_strValue, 0))
                                Case "INTDUE"
                                    mv_dblINTDUE = CDbl(IIf(IsNumeric(v_strValue), v_strValue, 0))
                                Case "INTNMLACR"
                                    mv_dblINTNMLACR = CDbl(IIf(IsNumeric(v_strValue), v_strValue, 0))
                                Case "FEEPAID"
                                    mv_dblFEEPAID = CDbl(IIf(IsNumeric(v_strValue), v_strValue, 0))
                                Case "DFQTTY"
                                    mv_dblDFQTTY = CDbl(IIf(IsNumeric(v_strValue), v_strValue, 0))
                                Case "RCVQTTY"
                                    mv_dblRCVQTTY = CDbl(IIf(IsNumeric(v_strValue), v_strValue, 0))
                                Case "CARCVQTTY"
                                    mv_dblCARCVQTTY = CDbl(IIf(IsNumeric(v_strValue), v_strValue, 0))
                                Case "BLOCKQTTY"
                                    mv_dblBLOCKQTTY = CDbl(IIf(IsNumeric(v_strValue), v_strValue, 0))
                                Case "BQTTY"
                                    mv_dblBQTTY = CDbl(IIf(IsNumeric(v_strValue), v_strValue, 0))
                                Case "SECURED"
                                    mv_dblSECURED = CDbl(IIf(IsNumeric(v_strValue), v_strValue, 0))
                                Case "REMAINQTTY"
                                    mv_dblREMAINQTTY = CDbl(IIf(IsNumeric(v_strValue), v_strValue, 0))
                                Case "LIMITCHECK"
                                    mv_dblLIMITCHECK = CDbl(IIf(IsNumeric(v_strValue), v_strValue, 0))
                                Case "CIDRAWNDOWN"
                                    mv_strCIDRAWNDOWN = v_strValue.Trim
                                Case "CODEID"
                                    v_strCODEID = v_strValue.Trim
                                Case "SYMBOL"
                                    v_strSYMBOL = v_strValue.Trim
                                Case "ACTYPE"
                                    v_strACTYPE = v_strValue.Trim
                                Case "DFREF"
                                    v_strDFREF = v_strValue.Trim
                                Case "TRADELOT"
                                    mv_dblDFTRADELOT = CDbl(IIf(IsNumeric(v_strValue), v_strValue, 0))
                                Case "RRID"
                                    mv_strRRID = v_strValue.Trim
                                Case "ACCTNO"
                                    mv_strOLDDFACCTNO = v_strValue.Trim
                                Case "LNACCTNO"
                                    mv_strLNACCTNO = v_strValue.Trim
                                Case "AFACCTNO"
                                    mv_strOLDDFAFACCTNO = v_strValue.Trim
                                Case "BANKDRAWNDOWN"
                                    mv_strOLDBANKDRAWNDOWN = v_strValue.Trim
                                Case "CMPDRAWNDOWN"
                                    mv_strOLDCMPDRAWNDOWN = v_strValue.Trim
                                Case "RLSQTTY"
                                    mv_dblRLSQTTY = CDbl(v_strValue)
                                Case "RLSAMT"
                                    mv_dblRLSAMT = CDbl(v_strValue)
                                Case "DFRATE"
                                    mv_strOLDDFRATE = v_strValue.Trim
                                Case "DESCRIPTION"
                                    mv_strOLDDESC = v_strValue.Trim
                            End Select
                        End With
                    Next
                Next
                Me.mskACTYPE.Text = v_strACTYPE
                Me.txtOLDACTYPE.Text = v_strACTYPE
                Me.txtOLDDFRATE.Text = mv_strOLDDFRATE

                mv_dblORGDFQTTY = mv_dblDFQTTY
                mv_dblORGBLOCKQTTY = mv_dblBLOCKQTTY
                mv_dblORGRCVQTTY = mv_dblRCVQTTY
                mv_dblORGCARCVQTTY = mv_dblCARCVQTTY
                GetDFType(v_strACTYPE, v_strCODEID)

                mv_dblTOTALSECURITIES = mv_dblDFQTTY + mv_dblRCVQTTY + mv_dblCARCVQTTY + mv_dblBLOCKQTTY - mv_dblSECURED
                mv_dblDFQTTY = mv_dblTOTALSECURITIES - (mv_dblRCVQTTY + mv_dblCARCVQTTY + mv_dblBLOCKQTTY)
                mv_dblBLOCKQTTY = mv_dblTOTALSECURITIES - (mv_dblDFQTTY + mv_dblRCVQTTY + mv_dblCARCVQTTY)
                mv_dblRCVQTTY = mv_dblTOTALSECURITIES - (mv_dblDFQTTY + mv_dblCARCVQTTY + mv_dblBLOCKQTTY)
                mv_dblCARCVQTTY = mv_dblTOTALSECURITIES - (mv_dblDFQTTY + mv_dblRCVQTTY + mv_dblBLOCKQTTY)
                mv_dblORGDFQTTY = mv_dblDFQTTY
                mv_dblORGBLOCKQTTY = mv_dblBLOCKQTTY
                mv_dblORGRCVQTTY = mv_dblRCVQTTY
                mv_dblORGCARCVQTTY = mv_dblCARCVQTTY

                Me.txtQuantity.Text = mv_dblTOTALSECURITIES.ToString
                Me.txtOLDDFQTTY.Text = mv_dblTOTALSECURITIES.ToString
                Me.txtREF.Text = v_strDFREF

                If mv_dblRCVQTTY > 0 Then
                    v_strCmdSQL = "select sum(amt) MATCHAMT, sum(qtty) MATCHQTTY, round(sum(amt)/sum(qtty)) MATCHPRICE from stschd where duetype = 'RS' and to_char(txdate,'DD/MM/RRRR') || acctno || clearday = '" & v_strDFREF & "'"
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_AFMAST, gc_ActionInquiry, v_strCmdSQL)
                    v_ws.Message(v_strObjMsg)
                    v_xmlDocument.LoadXml(v_strObjMsg)
                    v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                    If v_nodeList.Count > 0 Then
                        For i = 0 To v_nodeList.Count - 1
                            For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                                With v_nodeList.Item(i).ChildNodes(j)
                                    v_strValue = .InnerText.ToString
                                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                    Select Case Trim(v_strFLDNAME)
                                        Case "MATCHAMT"
                                            Me.txtMATVAL.Text = FormatNumber(v_strValue, 0)
                                            Me.txtDFAMT.Text = FormatNumber(v_strValue, 0)
                                        Case "MATCHQTTY"
                                            mv_dblEXECQTTY = CDbl(IIf(IsNumeric(v_strValue), v_strValue, 0))
                                        Case "MATCHPRICE"
                                            v_strMATCHPRICE = v_strValue
                                            mv_dblMATCHPRICE = CDbl(IIf(IsNumeric(v_strValue), v_strValue, 0))
                                    End Select
                                End With
                            Next
                        Next
                        Me.cboRefPrice.Clears()
                        Me.cboRefPrice.AddItems(mv_dblMATCHPRICE, MATCHPRICE)
                        Me.cboRefPrice.AddItems(mv_strBASICPRICE, BASICPRICE)
                        If mv_strOPTPRICE = "O" OrElse mv_strOPTPRICE = "A" Then
                            Me.cboRefPrice.AddItems(mv_ResourceManager.GetString(OTHERS), OTHERS)
                        End If
                        Me.cboRefPrice.SelectedIndex = 0
                    End If
                Else
                    Me.cboRefPrice.Clears()
                    Me.cboRefPrice.AddItems(mv_strBASICPRICE, BASICPRICE)
                    If mv_strOPTPRICE = "O" OrElse mv_strOPTPRICE = "A" Then
                        Me.cboRefPrice.AddItems(mv_ResourceManager.GetString(OTHERS), OTHERS)
                    End If
                    Me.cboRefPrice.SelectedIndex = 0
                End If

                mv_dblTOTALPAID = mv_dblPRINOVD + mv_dblPRINNML + mv_dblINTNMLOVD + mv_dblINTOVDACR + mv_dblINTDUE + mv_dblINTNMLACR + mv_dblFEEPAID

            Else
                MsgBox(mv_ResourceManager.GetString("DEALINVALID"), MsgBoxStyle.Information, Me.Text)
                Me.ActiveControl = Me.btnGetDeal
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Lay thong tin ve so du tien, so tien cho ve, han muc thau chi
    Private Sub getCIInfo(ByVal v_strAFacctno As String)
        Dim v_xmlDocument As New Xml.XmlDocument, v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
        Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode
        Dim v_attrFLDNAME As Xml.XmlAttribute, v_attrDATATYPE As Xml.XmlAttribute, v_attrDEFNAME As Xml.XmlAttribute
        Dim v_strTxMsg, v_strFLDNAME, v_strFLDDEFNAME, v_strDATATYPE, v_strDEFNAME, v_strFLDVALUE, v_strValue As String
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Dim v_lngError As Long
        Dim i, j As Integer

        Try
            v_strDATATYPE = "C"

            v_strTxMsg = BuildXMLTxMsg("T", "Y", "1171", Me.BranchId, Me.TellerId, Me.IpAddress, Me.WsName)
            v_xmlDocument.LoadXml(v_strTxMsg)
            v_dataElement = v_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "fields", "")

            'CUSTODYCD
            v_entryNode = v_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "entry", "")
            'Add field name
            v_attrFLDNAME = v_xmlDocument.CreateAttribute(gc_AtributeFLDNAME)
            v_attrFLDNAME.Value = "88"
            v_entryNode.Attributes.Append(v_attrFLDNAME)
            'Add field type
            v_attrDATATYPE = v_xmlDocument.CreateAttribute(gc_AtributeFLDTYPE)
            v_attrDATATYPE.Value = v_strDATATYPE
            v_entryNode.Attributes.Append(v_attrDATATYPE)
            'Add coloum name
            v_attrDEFNAME = v_xmlDocument.CreateAttribute(gc_AtributeDEFNAME)
            v_attrDEFNAME.Value = "CUSTODYCD"
            v_entryNode.Attributes.Append(v_attrDEFNAME)
            'Set value
            v_entryNode.InnerText = Me.mskCUSTODYCD.Text.Trim
            v_dataElement.AppendChild(v_entryNode)
            v_xmlDocument.DocumentElement.AppendChild(v_dataElement)

            'ACCTNO
            v_entryNode = v_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "entry", "")
            'Add field name
            v_attrFLDNAME = v_xmlDocument.CreateAttribute(gc_AtributeFLDNAME)
            v_attrFLDNAME.Value = "03"
            v_entryNode.Attributes.Append(v_attrFLDNAME)
            'Add field type
            v_attrDATATYPE = v_xmlDocument.CreateAttribute(gc_AtributeFLDTYPE)
            v_attrDATATYPE.Value = v_strDATATYPE
            v_entryNode.Attributes.Append(v_attrDATATYPE)
            'Add coloum name
            v_attrDEFNAME = v_xmlDocument.CreateAttribute(gc_AtributeDEFNAME)
            v_attrDEFNAME.Value = "ACCTNO"
            v_entryNode.Attributes.Append(v_attrDEFNAME)
            'Set value
            v_entryNode.InnerText = Me.mskAFACCTNO.Text.Trim
            v_dataElement.AppendChild(v_entryNode)
            v_xmlDocument.DocumentElement.AppendChild(v_dataElement)

            'TYPE
            v_entryNode = v_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "entry", "")
            'Add field name
            v_attrFLDNAME = v_xmlDocument.CreateAttribute(gc_AtributeFLDNAME)
            v_attrFLDNAME.Value = "01"
            v_entryNode.Attributes.Append(v_attrFLDNAME)
            'Add field type
            v_attrDATATYPE = v_xmlDocument.CreateAttribute(gc_AtributeFLDTYPE)
            v_attrDATATYPE.Value = v_strDATATYPE
            v_entryNode.Attributes.Append(v_attrDATATYPE)
            'Add coloum name
            v_attrDEFNAME = v_xmlDocument.CreateAttribute(gc_AtributeDEFNAME)
            v_attrDEFNAME.Value = "TYPE"
            v_entryNode.Attributes.Append(v_attrDEFNAME)
            'Set value
            v_entryNode.InnerText = "U"
            v_dataElement.AppendChild(v_entryNode)
            v_xmlDocument.DocumentElement.AppendChild(v_dataElement)

            'NEXTTX
            v_entryNode = v_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "entry", "")
            'Add field name
            v_attrFLDNAME = v_xmlDocument.CreateAttribute(gc_AtributeFLDNAME)
            v_attrFLDNAME.Value = "04"
            v_entryNode.Attributes.Append(v_attrFLDNAME)
            'Add field type
            v_attrDATATYPE = v_xmlDocument.CreateAttribute(gc_AtributeFLDTYPE)
            v_attrDATATYPE.Value = v_strDATATYPE
            v_entryNode.Attributes.Append(v_attrDATATYPE)
            'Add coloum name
            v_attrDEFNAME = v_xmlDocument.CreateAttribute(gc_AtributeDEFNAME)
            v_attrDEFNAME.Value = "NEXTTX"
            v_entryNode.Attributes.Append(v_attrDEFNAME)
            'Set value
            v_entryNode.InnerText = ""
            v_dataElement.AppendChild(v_entryNode)
            v_xmlDocument.DocumentElement.AppendChild(v_dataElement)

            'CAREBY
            v_entryNode = v_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "entry", "")
            'Add field name
            v_attrFLDNAME = v_xmlDocument.CreateAttribute(gc_AtributeFLDNAME)
            v_attrFLDNAME.Value = "05"
            v_entryNode.Attributes.Append(v_attrFLDNAME)
            'Add field type
            v_attrDATATYPE = v_xmlDocument.CreateAttribute(gc_AtributeFLDTYPE)
            v_attrDATATYPE.Value = v_strDATATYPE
            v_entryNode.Attributes.Append(v_attrDATATYPE)
            'Add coloum name
            v_attrDEFNAME = v_xmlDocument.CreateAttribute(gc_AtributeDEFNAME)
            v_attrDEFNAME.Value = "CAREBY"
            v_entryNode.Attributes.Append(v_attrDEFNAME)
            'Set value
            v_entryNode.InnerText = ""
            v_dataElement.AppendChild(v_entryNode)
            v_xmlDocument.DocumentElement.AppendChild(v_dataElement)

            v_strTxMsg = v_xmlDocument.InnerXml

            v_lngError = v_ws.Message(v_strTxMsg)
            v_xmlDocument.LoadXml(v_strTxMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/TransactMessage/ObjData")

            If v_nodeList.Count > 0 Then
                For i = 0 To v_nodeList.Count - 1
                    For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            v_strValue = .InnerText.ToString
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME)
                                Case "ADVANCELINE"
                                    mv_dblADVANCELINE = CDbl(IIf(IsNumeric(v_strValue), v_strValue, 0))
                                Case "ODAMT"
                                    mv_dblODAMT = CDbl(IIf(IsNumeric(v_strValue), v_strValue, 0))
                                Case "BALANCE"
                                    mv_dblBALANCE = CDbl(IIf(IsNumeric(v_strValue), v_strValue, 0))
                                Case "APMT"
                                    mv_dblAPMT = CDbl(IIf(IsNumeric(v_strValue), v_strValue, 0))
                                Case "PP"
                                    mv_dblPP = CDbl(IIf(IsNumeric(v_strValue), v_strValue, 0))
                                Case "REALBALWITHDRAWN"
                                    mv_dblREALBALWITHDRAWN = CDbl(IIf(IsNumeric(v_strValue), v_strValue, 0))
                            End Select
                        End With
                    Next
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtDFAMT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDFAMT.Validating
        If Trim(Me.txtDFAMT.Text).Length > 0 Then
            If Not IsNumeric(txtDFAMT.Text) OrElse (IsNumeric(txtDFAMT.Text) And CDbl(txtDFAMT.Text) <= 0) Then
                MsgBox(mv_ResourceManager.GetString("NUMBER_IS_INVALID"), MsgBoxStyle.Information, Me.Text)
                Me.txtDFAMT.Focus()
                Exit Sub
            End If
            'ducnv FormatNumber(
            Me.txtDFAMT.Text = FormatNumber(Math.Round(CDbl(IIf(Me.txtDFAMT.Text = String.Empty, "0", Me.txtDFAMT.Text)), 0), 0)
            If Me.txtMATVAL.Text.Length <> 0 Then
                If cboRefPrice.SelectedValue.ToString() = OTHERS AndAlso CDbl(Me.txtDFAMT.Text) > CDbl(Me.txtMATVAL.Text) / mv_dblEXECQTTY * CDbl(Me.txtQuantity.Text) * CDbl(Me.txtDFRATE.Text) / 100 Then
                    Me.txtDFAMT.Text = FormatNumber((FRound(CDbl(Me.txtMATVAL.Text) / mv_dblEXECQTTY * CDbl(Me.txtQuantity.Text) * CDbl(Me.txtDFRATE.Text) / 100)), 0)
                End If
            Else
                If CDbl(IIf(Me.txtDFAMT.Text = String.Empty, "0", Me.txtDFAMT.Text)) > CDbl(mv_strBASICPRICE) * CDbl(Me.txtQuantity.Text) * CDbl(Me.txtDFRATE.Text) / 100 OrElse Me.txtDFAMT.Text = String.Empty Then
                    Me.txtDFAMT.Text = FormatNumber(CDbl(mv_strBASICPRICE) * CDbl(Me.txtQuantity.Text) * CDbl(Me.txtDFRATE.Text) / 100, 0)
                End If
            End If
            Me.txtDFPrice.Text = FRound(CDbl(Me.txtDFAMT.Text) / CDbl(Me.txtQuantity.Text), 4)
            If Me.cboRefPrice.SelectedValue.ToString <> OTHERS Then
                Me.txtTRIGPRICE.Text = FRound(CDbl(Me.txtRefPrice.Text) * CDbl(Me.txtLRATE.Text) / 100)
            Else
                calcCashtopay()
            End If
            If Not IsNumeric(txtDFAMT.Text) OrElse (IsNumeric(txtDFAMT.Text) And CDbl(txtDFAMT.Text) <= 0) Then
                MsgBox(mv_ResourceManager.GetString("NUMBER_IS_INVALID"), MsgBoxStyle.Information, Me.Text)
                Me.txtDFAMT.Focus()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub chkENDNEWDEAL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkENDNEWDEAL.CheckedChanged

        If chkENDNEWDEAL.Checked = True Then
            Me.lblOLDDEALNO.Visible = True
            Me.txtOLDDEALNO.Visible = True
            Me.lblOLDDFQTTY.Visible = True
            Me.txtOLDDFQTTY.Visible = True
            Me.lblREMAINBAL.Visible = True
            Me.txtREMAINBAL.Visible = True
            Me.lblREMAINADVLINE.Visible = True
            Me.txtREMAINADVLINE.Visible = True
            Me.lblNETBALANCE.Visible = True
            Me.txtNETBALANCE.Visible = True
            Me.chkAUTODRAWNDOWN.Checked = True 'Bat buoc tu dong giai ngan
            Me.chkAUTODRAWNDOWN.Enabled = False
            Me.cboCODEID.Enabled = False
            SEMemberGrid.Enabled = False
            Me.btnGetDeal.Visible = False
            Me.lblREF.Visible = False
            Me.txtREF.Visible = False
            Me.lblOLDACTYPE.Visible = True
            Me.lblOLDDFRATE.Visible = True
            Me.txtOLDACTYPE.Visible = True
            Me.txtOLDDFRATE.Visible = True

            'Phan nay them vao danh cho su kien quyen mua
            Me.chkOPTIONSTOCK.Checked = False
            Me.chkOPTIONSTOCK.Visible = False
        Else
            Me.lblOLDDEALNO.Visible = False
            Me.txtOLDDEALNO.Visible = False
            Me.lblOLDDFQTTY.Visible = False
            Me.txtOLDDFQTTY.Visible = False
            Me.lblREMAINBAL.Visible = False
            Me.txtREMAINBAL.Visible = False
            Me.lblREMAINADVLINE.Visible = False
            Me.txtREMAINADVLINE.Visible = False
            Me.lblNETBALANCE.Visible = False
            Me.txtNETBALANCE.Visible = False
            'Me.chkAUTODRAWNDOWN.Enabled = True
            Me.chkAUTODRAWNDOWN.Checked = True
            'Me.cboCODEID.Enabled = True
            SEMemberGrid.Enabled = True
            Me.btnGetDeal.Visible = False
            Me.lblREF.Visible = False
            Me.txtREF.Visible = False
            Me.lblOLDACTYPE.Visible = False
            Me.lblOLDDFRATE.Visible = False
            Me.txtOLDACTYPE.Visible = False
            Me.txtOLDDFRATE.Visible = False

            'Phan nay them vao danh cho su kien quyen mua
            Me.chkOPTIONSTOCK.Visible = True
        End If

    End Sub

    Private Sub calcCashtopay()
        If Me.chkENDNEWDEAL.Checked = True Then
            Dim v_dblOLDDFAMT As Double = 0
            'Goc so tien goc giai toa = min (GT giai toa can tu tren goc, max(goc vay thuc te con lai - GT vay con lai can cu tren goc))
            'LCPRINOVD
            v_dblOLDDFAMT += FRound(Math.Min((mv_dblPRINOVD + mv_dblRLSAMT) / (mv_dblTOTALSECURITIES + mv_dblSECURED + mv_dblRLSQTTY) * CDbl(Me.txtQuantity.Text.Trim) _
                                        , Math.Max(mv_dblPRINOVD - ((mv_dblPRINOVD + mv_dblRLSAMT) / (mv_dblTOTALSECURITIES + mv_dblSECURED + mv_dblRLSQTTY) * (mv_dblTOTALSECURITIES + mv_dblSECURED - CDbl(Me.txtQuantity.Text.Trim))) _
                                                   , 0)), 0)
            'LCPRINNML
            v_dblOLDDFAMT += FRound(Math.Min((mv_dblPRINNML + mv_dblRLSAMT) / (mv_dblTOTALSECURITIES + mv_dblSECURED + mv_dblRLSQTTY) * CDbl(Me.txtQuantity.Text.Trim) _
                                        , Math.Max(mv_dblPRINNML - ((mv_dblPRINNML + mv_dblRLSAMT) / (mv_dblTOTALSECURITIES + mv_dblSECURED + mv_dblRLSQTTY) * (mv_dblTOTALSECURITIES + mv_dblSECURED - CDbl(Me.txtQuantity.Text.Trim))) _
                                                    , 0)), 0)
            'LCINTNMLOVD
            v_dblOLDDFAMT += FRound(mv_dblINTNMLOVD * (CDbl(Me.txtQuantity.Text.Trim) / (mv_dblTOTALSECURITIES + mv_dblSECURED)), 0)
            'LCINTOVDACR
            v_dblOLDDFAMT += FRound(mv_dblINTOVDACR * (CDbl(Me.txtQuantity.Text.Trim) / (mv_dblTOTALSECURITIES + mv_dblSECURED)), 0)
            'LCINTDUE
            v_dblOLDDFAMT += FRound(mv_dblINTDUE * (CDbl(Me.txtQuantity.Text.Trim) / (mv_dblTOTALSECURITIES + mv_dblSECURED)), 0)
            'LCINTNMLACR
            v_dblOLDDFAMT += FRound(mv_dblINTNMLACR * (CDbl(Me.txtQuantity.Text.Trim) / (mv_dblTOTALSECURITIES + mv_dblSECURED)), 0)
            'LCFEEPAID
            v_dblOLDDFAMT += FRound(mv_dblFEEPAID * (CDbl(Me.txtQuantity.Text.Trim) / (mv_dblTOTALSECURITIES + mv_dblSECURED)), 0)

            v_dblOLDDFAMT = Math.Ceiling(v_dblOLDDFAMT)
            If cboRefPrice.SelectedValue.ToString = MATCHPRICE OrElse cboRefPrice.SelectedValue.ToString = OTHERS Then


                Me.txtNETBALANCE.Text = FormatNumber(CStr(FRound(v_dblOLDDFAMT - IIf(Me.txtDFAMT.Text.Trim.Length > 0, CDbl(Me.txtDFAMT.Text.Trim), 0), 0)), 0)
                Me.txtREMAINBAL.Text = FormatNumber(CStr(Math.Max(Math.Min(CDbl(Me.txtNETBALANCE.Text.Trim), mv_dblREALBALWITHDRAWN), 0)), 0)
                Me.txtREMAINADVLINE.Text = FormatNumber(CStr(Math.Max(Math.Min(Math.Min(mv_dblADVANCELINE, mv_dblPP), CDbl(Me.txtNETBALANCE.Text.Trim) - IIf(Me.txtREMAINBAL.Text.Trim.Length > 0, CDbl(Me.txtREMAINBAL.Text.Trim), 0)), 0)), 0)
            Else
                If IsNumeric(Me.txtDFRATE.Text.Trim) Then
                    Me.txtNETBALANCE.Text = FormatNumber(CStr(FRound(v_dblOLDDFAMT - CDbl(mv_strBASICPRICE) * CDbl(Me.txtQuantity.Text) * IIf(Me.txtDFRATE.Text.Trim.Length > 0, CDbl(Me.txtDFRATE.Text.Trim), 0) / 100, 0)), 0)
                    Me.txtREMAINBAL.Text = FormatNumber(CStr(Math.Max(Math.Min(CDbl(Me.txtNETBALANCE.Text.Trim), mv_dblREALBALWITHDRAWN), 0)), 0)
                    Me.txtREMAINADVLINE.Text = FormatNumber(CStr(Math.Max(Math.Min(Math.Min(mv_dblADVANCELINE, mv_dblPP), CDbl(Me.txtNETBALANCE.Text.Trim) - IIf(Me.txtREMAINBAL.Text.Trim.Length > 0, CDbl(Me.txtREMAINBAL.Text.Trim), 0)), 0)), 0)
                Else
                    MsgBox(mv_ResourceManager.GetString("DFTYPEINVALID"), MsgBoxStyle.Information, Me.Text)
                    Me.mskACTYPE.Focus()
                End If
            End If

            If Me.txtREMAINBAL.Text.Trim.Length > 0 AndAlso CDbl(Me.txtREMAINBAL.Text.Trim) < 0 Then
                Me.txtREMAINBAL.Text = "0"
            End If
            If Me.txtREMAINADVLINE.Text.Trim.Length > 0 AndAlso CDbl(Me.txtREMAINADVLINE.Text.Trim) < 0 Then
                Me.txtREMAINADVLINE.Text = "0"
            End If
            'Tinh lai khoi luong vi co the la thanh ly tai ky mot phan.
            If mv_strDFTYPE = "F" OrElse mv_strDFTYPE = "L" Then
                mv_dblDFQTTY = Math.Min(CDbl(Me.txtQuantity.Text.Trim), mv_dblORGDFQTTY)
            End If
            If mv_strDFTYPE = "B" Then
                mv_dblBLOCKQTTY = Math.Min(CDbl(Me.txtQuantity.Text.Trim), mv_dblORGBLOCKQTTY)
            End If
            If mv_strDFTYPE = "F" OrElse mv_strDFTYPE = "L" Then
                mv_dblRCVQTTY = Math.Min(Math.Max(CDbl(Me.txtQuantity.Text.Trim) - mv_dblDFQTTY, 0), mv_dblORGRCVQTTY)
            End If
            If mv_strDFTYPE = "B" Then
                mv_dblCARCVQTTY = Math.Min(Math.Max(CDbl(Me.txtQuantity.Text.Trim) - mv_dblBLOCKQTTY, 0), mv_dblORGCARCVQTTY)
            End If
        End If
    End Sub

    Private Sub btnAdjust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdjust.Click
        ShowAdjustButton(False)
    End Sub

    Private Sub chkOPTIONSTOCK_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkOPTIONSTOCK.CheckedChanged
        If chkOPTIONSTOCK.Checked = True Then
            Me.chkENDNEWDEAL.Checked = False
            Me.chkENDNEWDEAL.Visible = False
            Me.chkAUTODRAWNDOWN.Checked = True
            'Me.chkAUTODRAWNDOWN.Enabled = False
            Me.txtREF.Enabled = False
            Me.btnGetDeal.Enabled = False
            Me.lblBALDEFOVD.Visible = True
            Me.txtBALDEFOVD.Visible = True
            Me.lblBALADDOPT.Visible = True
            Me.txtBALADDOPT.Visible = True

            SEMemberGrid.Columns("PRICE").Title = mv_ResourceManager.GetString("MEMBER_PRICE")
            SEMemberGrid.Columns("CLEARDATE").Title = mv_ResourceManager.GetString("MEMBER_DUEDATE")
            SEMemberGrid.Columns("CAMASTID").Title = mv_ResourceManager.GetString("MEMBER_CAMASTID")
            SEMemberGrid.Columns("TXDATE").Title = mv_ResourceManager.GetString("MEMBER_REPORTDATE")
            SEMemberGrid.Columns("BALDEFOVD").Title = mv_ResourceManager.GetString("MEMBER_BALDEFOVD")

            SEMemberGrid.Columns("PRICE").Visible = True
            SEMemberGrid.Columns("CAMASTID").Visible = True
            SEMemberGrid.Columns("BALDEFOVD").Visible = True
        Else
            Me.chkENDNEWDEAL.Visible = True
            'Me.chkAUTODRAWNDOWN.Enabled = True
            Me.txtREF.Enabled = True
            Me.btnGetDeal.Enabled = True
            Me.lblBALDEFOVD.Visible = False
            Me.txtBALDEFOVD.Visible = False
            Me.lblBALADDOPT.Visible = False
            Me.txtBALADDOPT.Visible = False

            SEMemberGrid.Columns("PRICE").Title = "PRICE"
            SEMemberGrid.Columns("CLEARDATE").Title = mv_ResourceManager.GetString("CLEARDATE")
            SEMemberGrid.Columns("CAMASTID").Title = "CAMASTID"
            SEMemberGrid.Columns("TXDATE").Title = mv_ResourceManager.GetString("TXDATE")
            SEMemberGrid.Columns("BALDEFOVD").Title = mv_ResourceManager.GetString("MEMBER_BALDEFOVD")
            SEMemberGrid.Columns("PRICE").Visible = False
            SEMemberGrid.Columns("CAMASTID").Visible = False
            SEMemberGrid.Columns("BALDEFOVD").Visible = False
        End If
        Me.mskACTYPE.Text = ""
        mv_strDEALACTYPE = ""
        Me.txtQuantity.Text = ""
        Me.txtDFPrice.Text = "0"
        Me.txtDFAMT.Text = "0"

        GetSEMemberGrid(Trim(mskAFACCTNO.Text), Trim(Me.mskACTYPE.Text))
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        Dim v_xmlDocument As New Xml.XmlDocument, v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
        Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode, v_intIndex As Long, i, v_intCount As Integer
        Dim v_strFLDNAME As String, v_strFLDDEFNAME As String, v_strDATATYPE As String, v_strFLDVALUE As String
        Dim v_strERRMSG, v_strENERRMSG, v_strOPERATOR, v_strVALEXP, v_strVALEXP2 As String, v_strACTYPE, v_strDESC As String
        Dim v_dtVALEXP, v_dtVALEXP2, v_dtFLDVALUE As Date
        Dim v_ctl As Control, v_attrFLDNAME As Xml.XmlAttribute, v_attrDATATYPE As Xml.XmlAttribute, v_objEval As New Evaluator

        Dim v_TradeQtty, v_BlockQtty, v_PendingQtty, v_PendingCAQtty, v_seacctno, v_RLSAMT, v_CACashQtty As String
        Dim v_strObjMsg, v_strSQL, v_strValue As String
        Dim v_ws As New BDSDeliveryManagement
        Dim x, y As Integer
        If DFGRGrid.DataRows.Count = 0 Then
            mv_blnIsBlockCA = False
            txtDescription.ReadOnly = False
        End If
        'SONLT: Xu ly khi lam cam co voi tien ca ve, chi dc lam 1 deal duy nhat
        If mv_blnIsBlockCA Or (DFGRGrid.DataRows.Count > 0 And mv_strDEALTYPE = "T") Then
            MsgBox(mv_ResourceManager.GetString("ERR_BLOCK_CA_ONLYONE"), MsgBoxStyle.OkOnly + MsgBoxStyle.ApplicationModal)
            Exit Sub
        End If

        If mv_strDEALTYPE = "T" And Not mv_blnIsBlockCA Then
            mv_blnIsBlockCA = True
        End If

        'END SONLT
        'Control Validate
        If Not ControlValidation() Then
            Exit Sub
        End If
        'HaiLT bo doan check loai hinh VSD moi cho sua gia tien, gio` loai hinh nao cung cho sua
        'If mv_strISVSD = "Y" Then
        DFGRGrid.Columns("AMT").ReadOnly = False
        'Else
        'DFGRGrid.Columns("AMT").ReadOnly = True
        'End If
        v_TradeQtty = "0"
        v_BlockQtty = "0"
        v_PendingQtty = "0"
        v_PendingCAQtty = "0"
        v_RLSAMT = "0"
        v_CACashQtty = "0"
        v_seacctno = ""
        If Trim(Me.txtREF.Text).Length = 0 Then
            v_strSQL = "SELECT TRADE, ACCTNO FROM SEMAST WHERE AFACCTNO = '" & Me.mskAFACCTNO.Text.Replace(".", "") & "' AND CODEID = '" & Me.cboCODEID.SelectedValue.ToString() & "'"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SE_SEMAST, gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            If v_nodeList.Count = 0 Then
                MsgBox(mv_ResourceManager.GetString("INVALID_SYMBOL"), MsgBoxStyle.Information, Me.Text)
                Exit Sub
            End If

            For x = 0 To v_nodeList.Count - 1
                For y = 0 To v_nodeList.Item(x).ChildNodes.Count - 1
                    With v_nodeList.Item(x).ChildNodes(y)
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "TRADE"
                                v_TradeQtty = Trim(v_strValue)
                            Case "ACCTNO"
                                v_seacctno = Trim(v_strValue)
                        End Select
                    End With
                Next
            Next
        Else
            'If Me.mv_strDFTYPE = "F" Or Me.mv_strDFTYPE = "L" Then
            If Me.mv_strDFTYPE = "F" Or Me.mv_strDFTYPE = "L" Or Me.mv_strDEALTYPE = "R" Then
                'forward hoac margin loan se duoc lam tren chung khoan cho ve
                'v_strSQL = "SELECT NVL((QTTY-AQTTY),'0') PENDINGTRADE,greatest((1-b.BRATIO/100) * (a.QTTY-a.AQTTY)/a.QTTY * a.AMT,0) RLSAMT FROM STSCHD a, ODMAST b WHERE a.ORGORDERID=b.ORDERID AND  a.DUETYPE = 'RS' AND a.AUTOID = " & CDbl(Me.txtREF.Text) & ""
                v_strSQL = "  SELECT distinct NVL((QTTY-AQTTY),'0') PENDINGTRADE, " & ControlChars.CrLf _
                        & "  CASE WHEN MRT.MRTYPE IN ('L','N') THEN " & ControlChars.CrLf _
                        & "  LEAST( " & ControlChars.CrLf _
                        & "  greatest((1-b.BRATIO/100) * (a.QTTY-a.AQTTY)/a.QTTY * a.AMT,0), " & ControlChars.CrLf _
                        & "  GREATEST(AF.MRCRLIMITMAX-CI.DFODAMT-CI.ODAMT,0) ) " & ControlChars.CrLf _
                        & "  ELSE " & ControlChars.CrLf _
                        & "  (A.QTTY-A.AQTTY) *  nvl(rsk.mrratioloan,0)/100 * least(NVL(RSK.MARGINPRICE,0),nvl(rsk.mrpriceloan,0)) " & ControlChars.CrLf _
                        & "  END RLSAMT  " & ControlChars.CrLf _
                        & "  FROM vw_stschd_dealgroup a, (SELECT afacctno, codeid, bratio FROM odmast ) b, AFMAST AF,CIMAST CI, AFTYPE AFT, MRTYPE MRT, " & ControlChars.CrLf _
                        & "  (SELECT RSK.ACTYPE,RSK.MRRATIOLOAN,RSK.MRPRICELOAN ,SB.MARGINPRICE FROM AFSERISK RSK,SECURITIES_INFO SB  " & ControlChars.CrLf _
                        & "  WHERE RSK.CODEID= SB.CODEID AND RSK.CODEID=(SELECT CODEID FROM vw_stschd_dealgroup WHERE AUTOID ='" & Me.txtREF.Text.Trim & "')) RSK " & ControlChars.CrLf _
                        & "   WHERE a.afacctno=b.afacctno AND a.codeid = b.codeid AND a.DUETYPE = 'RS' " & ControlChars.CrLf _
                        & "  AND B.AFACCTNO = AF.ACCTNO  AND AF.ACCTNO = CI.ACCTNO AND AF.ACTYPE = AFT.ACTYPE AND AFT.MRTYPE = MRT.ACTYPE " & ControlChars.CrLf _
                        & "  AND AFT.ACTYPE = RSK.ACTYPE (+) AND a.AUTOID = '" & Me.txtREF.Text.Trim & "'"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SE_SEMAST, gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                For x = 0 To v_nodeList.Count - 1
                    For y = 0 To v_nodeList.Item(x).ChildNodes.Count - 1
                        With v_nodeList.Item(x).ChildNodes(y)
                            v_strValue = .InnerText.ToString
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME)
                                Case "PENDINGTRADE"
                                    If Not (v_strValue Is Nothing) Then
                                        v_PendingQtty = Trim(v_strValue)
                                    End If
                                Case "RLSAMT"
                                    v_RLSAMT = Trim(v_strValue)
                            End Select
                        End With
                    Next
                Next
            End If
            If Me.mv_strDFTYPE = "B" Or Me.mv_strDEALTYPE = "B" Or Me.mv_strDEALTYPE = "P" Then
                If InStr(Me.txtREF.Text, "/") > 0 Then
                    'lam tren chung khoan han che chuyen nhuong
                    v_strSQL = "SELECT  NVL((QTTY-DFQTTY),'0') BLOCKQTTY FROM SEMASTDTL WHERE DELTD<>'Y' AND txnum || to_char(txdate,'DD/MM/YYYY') = '" & (Me.txtREF.Text) & "'"
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SE_SEMAST, gc_ActionInquiry, v_strSQL)
                    v_ws.Message(v_strObjMsg)
                    v_xmlDocument.LoadXml(v_strObjMsg)
                    v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                    For x = 0 To v_nodeList.Count - 1
                        For y = 0 To v_nodeList.Item(x).ChildNodes.Count - 1
                            With v_nodeList.Item(x).ChildNodes(y)
                                v_strValue = .InnerText.ToString
                                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                Select Case Trim(v_strFLDNAME)
                                    Case "BLOCKQTTY"
                                        If Not (v_strValue Is Nothing) Then
                                            v_BlockQtty = Trim(v_strValue)
                                        End If
                                End Select
                            End With
                        Next
                    Next
                Else
                    'lam tren chung khoan quyen cho ve
                    If Me.chkOPTIONSTOCK.Checked Then
                        v_strSQL = "SELECT  NVL((QTTY + PQTTY - DFQTTY),'0') PENDINGCA FROM CASCHD WHERE DELTD<>'Y' AND STATUS in ( 'M','A') AND AUTOID = " & CDbl(Me.txtREF.Text) & ""
                    Else
                        v_strSQL = "SELECT  NVL((QTTY-DFQTTY),'0') PENDINGCA FROM CASCHD WHERE DELTD<>'Y' AND STATUS in ('S','M') AND AUTOID = " & CDbl(Me.txtREF.Text) & ""
                    End If
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SE_SEMAST, gc_ActionInquiry, v_strSQL)
                    v_ws.Message(v_strObjMsg)
                    v_xmlDocument.LoadXml(v_strObjMsg)
                    v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                    For x = 0 To v_nodeList.Count - 1
                        For y = 0 To v_nodeList.Item(x).ChildNodes.Count - 1
                            With v_nodeList.Item(x).ChildNodes(y)
                                v_strValue = .InnerText.ToString
                                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                Select Case Trim(v_strFLDNAME)
                                    Case "PENDINGCA"
                                        If Not (v_strValue Is Nothing) Then
                                            v_PendingCAQtty = Trim(v_strValue)
                                        End If
                                End Select
                            End With
                        Next
                    Next
                End If
                'Block forward se lam tren CA cho ve hoac Phong toa

            End If

        End If
        If Me.chkENDNEWDEAL.Checked = True Then
            'Select Case Trim(mv_strDFTYPE)
            If mv_strDFTYPE = "B" Or mv_strDEALTYPE = "B" Then
                mv_dblDFQTTY = 0
                mv_dblRCVQTTY = 0
                If mv_dblBLOCKQTTY + mv_dblCARCVQTTY < CDbl(Me.txtQuantity.Text.Trim) Then
                    MsgBox(mv_ResourceManager.GetString("BFWQTTYLESSQTTY"), MsgBoxStyle.Information, Me.Text)
                    Me.txtQuantity.Text = FormatNumber(mv_dblBLOCKQTTY + mv_dblCARCVQTTY, 0)
                    Me.ActiveControl = txtQuantity
                    ' Return False

                End If

            End If
            If mv_strDFTYPE = "F" Or mv_strDFTYPE = "L" Or mv_strDEALTYPE = "R" Then
                mv_dblBLOCKQTTY = 0
                mv_dblCARCVQTTY = 0
                If mv_dblDFQTTY + mv_dblRCVQTTY < CDbl(Me.txtQuantity.Text.Trim) Then
                    MsgBox(mv_ResourceManager.GetString("FWQTTYLESSQTTY"), MsgBoxStyle.Information, Me.Text)
                    Me.txtQuantity.Text = FormatNumber(mv_dblDFQTTY + mv_dblRCVQTTY, 0)
                    Me.ActiveControl = txtQuantity
                    'Return False
                End If
            End If
            'End Select
            v_TradeQtty = mv_dblDFQTTY.ToString
            v_PendingQtty = mv_dblRCVQTTY.ToString
            v_PendingCAQtty = mv_dblCARCVQTTY.ToString
            v_BlockQtty = mv_dblBLOCKQTTY.ToString
        Else
            'Select Case Trim(mv_strDFTYPE)
            If mv_strDFTYPE = "M" Then
                If CDbl(Me.txtQuantity.Text) > CDbl(v_TradeQtty) Then
                    MsgBox(mv_ResourceManager.GetString("TRADEQTTYLESSQTTY"), MsgBoxStyle.Information, Me.Text)
                    Me.ActiveControl = txtQuantity
                    '  Return False
                Else
                    v_TradeQtty = Me.txtQuantity.Text
                End If
            End If
            If mv_strDFTYPE = "F" Or mv_strDEALTYPE = "N" Then
                If Trim(Me.txtREF.Text).Length > 0 AndAlso CDbl(v_PendingQtty) > 0 Then
                    If CDbl(Me.txtQuantity.Text) > CDbl(v_PendingQtty) Then
                        MsgBox(mv_ResourceManager.GetString("FWQTTYLESSQTTY"), MsgBoxStyle.Information, Me.Text)
                        Me.ActiveControl = txtQuantity
                        '  Return False
                    Else
                        v_RLSAMT = CStr(FRound(CDbl(v_RLSAMT) * CDbl(Me.txtQuantity.Text) / CDbl(v_PendingQtty)))
                        v_PendingQtty = Me.txtQuantity.Text
                    End If

                Else
                    If CDbl(Me.txtQuantity.Text) > CDbl(v_TradeQtty) Then
                        MsgBox(mv_ResourceManager.GetString("FWQTTYLESSQTTY"), MsgBoxStyle.Information, Me.Text)
                        Me.ActiveControl = txtQuantity
                        '  Return False
                    Else
                        v_TradeQtty = Me.txtQuantity.Text
                    End If

                End If
            End If
            If mv_strDFTYPE = "B" Or mv_strDEALTYPE = "B" Or mv_strDEALTYPE = "P" Then
                If InStr(Me.txtREF.Text, "/") > 0 Then
                    If CDbl(Me.txtQuantity.Text) > CDbl(v_BlockQtty) Then
                        MsgBox(mv_ResourceManager.GetString("BFWQTTYLESSQTTY"), MsgBoxStyle.Information, Me.Text)
                        Me.ActiveControl = txtQuantity
                        '  Return False
                    Else
                        v_BlockQtty = Me.txtQuantity.Text
                    End If
                Else
                    If CDbl(Me.txtQuantity.Text) > CDbl(v_PendingCAQtty) Then
                        MsgBox(mv_ResourceManager.GetString("BFWQTTYLESSQTTY"), MsgBoxStyle.Information, Me.Text)
                        Me.ActiveControl = txtQuantity
                        ' Return False
                    Else
                        v_PendingCAQtty = Me.txtQuantity.Text
                    End If
                End If
            End If
            If mv_strDEALTYPE = "R" Then
                If CDbl(Me.txtQuantity.Text) > CDbl(v_PendingQtty) Then
                    MsgBox(mv_ResourceManager.GetString("FWQTTYLESSQTTY"), MsgBoxStyle.Information, Me.Text)
                    Me.ActiveControl = txtQuantity
                    ' Return False
                Else
                    v_RLSAMT = CStr(FRound(CDbl(v_RLSAMT) * CDbl(Me.txtQuantity.Text) / CDbl(v_PendingQtty)))
                    v_PendingQtty = Me.txtQuantity.Text
                End If
            ElseIf mv_strDEALTYPE = "T" Then
                'lam tien CA cho ve

                'v_strSQL = "SELECT  NVL(AMT-DFAMT,'0') AMT FROM CASCHD WHERE DELTD<>'Y' AND STATUS in ('S','I') AND AUTOID = " & CDbl(Me.txtREF.Text) & ""

                v_strSQL = " SELECT CAS.AFACCTNO, " & ControlChars.CrLf _
                & "    SUM(ROUND(CASE WHEN CAM.STATUS = 'K' AND CAS.STATUS = 'K' THEN ((100-CAM.EXERATE)/100)*CAS.AMT " & ControlChars.CrLf _
                & "              ELSE (CASE WHEN CAS.STATUS NOT IN ('K','J') THEN (CAM.EXERATE/100)*CAS.AMT ELSE 0 END) END " & ControlChars.CrLf _
                & "              )-CAS.DFAMT-(CAS.AMT*CAM.PITRATE/100) -CAS.TRFFEE) AMT  " & ControlChars.CrLf _
                & "FROM CAMAST CAM, CASCHD CAS " & ControlChars.CrLf _
                & "WHERE CAM.CAMASTID=CAS.CAMASTID AND CAS.AMT>0 " & ControlChars.CrLf _
                & "    AND CAS.STATUS IN ('S','I','K') AND CAS.DELTD<>'Y' AND CAS.ISCI <> 'Y' AND CAM.CATYPE = '010' " & ControlChars.CrLf _
                & "    AND CAS.AUTOID = '" & CDbl(Me.txtREF.Text) & "' " & ControlChars.CrLf _
                & "GROUP BY CAS.AFACCTNO "

                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SE_SEMAST, gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                For x = 0 To v_nodeList.Count - 1
                    For y = 0 To v_nodeList.Item(x).ChildNodes.Count - 1
                        With v_nodeList.Item(x).ChildNodes(y)
                            v_strValue = .InnerText.ToString
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME)
                                Case "AMT"
                                    If Not (v_strValue Is Nothing) Then
                                        v_CACashQtty = Trim(v_strValue)
                                    End If
                            End Select
                        End With
                    Next
                Next

                If CDbl(Me.txtQuantity.Text) > CDbl(v_CACashQtty) Then
                    MsgBox(mv_ResourceManager.GetString("FWQTTYLESSQTTY"), MsgBoxStyle.Information, Me.Text)
                    Me.ActiveControl = txtQuantity
                    ' Return False
                Else
                    v_CACashQtty = Me.txtQuantity.Text
                End If

            End If

        End If

        For J As Integer = 0 To DFGRGrid.DataRows.Count - 1
            With DFGRGrid.DataRows(J)
                If .Cells("SYMBOL").Value & .Cells("DTYPE").Value & .Cells("REF").Value = cboCODEID.Text & mv_strDEALTYPE & Trim(txtREF.Text) Then
                    MsgBox(mv_ResourceManager.GetString("QTTYSYMBOL"), MsgBoxStyle.Information, Me.Text)
                    Exit Sub
                End If
            End With
        Next

        Dim v_xDataRow As Xceed.Grid.DataRow = DFGRGrid.DataRows.AddNew()
        v_TradeQtty = IIf(v_TradeQtty Is Nothing, "0", v_TradeQtty)
        v_PendingQtty = IIf(v_PendingQtty Is Nothing, "0", v_PendingQtty)
        v_BlockQtty = IIf(v_BlockQtty Is Nothing, "0", v_BlockQtty)
        v_PendingCAQtty = IIf(v_PendingCAQtty Is Nothing, "0", v_PendingCAQtty)
        v_CACashQtty = IIf(v_CACashQtty Is Nothing, "0", v_CACashQtty)

        If v_TradeQtty > 0 And mv_strDEALTYPE = "N" Then
            v_xDataRow.Cells("DTYPE").Value = "N"
        ElseIf v_CACashQtty > 0 And mv_strDEALTYPE = "T" Then
            v_xDataRow.Cells("DTYPE").Value = "T"
        ElseIf v_BlockQtty > 0 Then
            v_xDataRow.Cells("DTYPE").Value = "B"
        ElseIf v_PendingQtty > 0 Then
            v_xDataRow.Cells("DTYPE").Value = "R"
        ElseIf v_PendingCAQtty > 0 Then
            v_xDataRow.Cells("DTYPE").Value = "P"
        End If
        If CDbl(v_TradeQtty) + CDbl(v_PendingQtty) + CDbl(v_BlockQtty) + CDbl(v_PendingCAQtty) + CDbl(v_CACashQtty) > 0 Then
            v_xDataRow.Cells("AFACCTNO").Value = Trim(mskAFACCTNO.Text)
            v_xDataRow.Cells("REF").Value = Trim(Me.txtREF.Text)
            v_xDataRow.Cells("SYMBOL").Value = cboCODEID.Text
            v_xDataRow.Cells("CODEID").Value = cboCODEID.SelectedValue
            v_xDataRow.Cells("QTTY").Value = CDbl(v_TradeQtty) + CDbl(v_PendingQtty) + CDbl(v_BlockQtty) + CDbl(v_PendingCAQtty) + CDbl(v_CACashQtty)
            v_xDataRow.Cells("DFPRICE").Value = CDbl(Me.txtDFPrice.Text)
            v_xDataRow.Cells("AMT").Value = (v_CACashQtty + CDbl(v_TradeQtty) + CDbl(v_PendingQtty) + CDbl(v_BlockQtty) + CDbl(v_PendingCAQtty)) * CDbl(Me.txtDFPrice.Text)
            v_xDataRow.Cells("DFRATE").Value = CDbl(Me.txtDFRATE.Text)
            v_xDataRow.EndEdit()
            DFGRGrid.EndInit()
        End If

        Dim v_dblamt As Double
        v_dblamt = 0
        For K As Integer = 0 To DFGRGrid.DataRows.Count - 1
            With DFGRGrid.DataRows(K)
                If (Not .Cells("AMT").Value Is Nothing) Then
                    v_dblamt = v_dblamt + gf_CorrectNumericField(.Cells("AMT").Value.ToString().Trim())
                End If

            End With
        Next
        Me.txtTOLAMT.Text = FormatNumber(v_dblamt, 0)
        Me.mskACTYPE.Enabled = False
        'sonlt 20141030 chinh sua dien giai cua giao dich
        If mv_strDEALTYPE = "T" Then
            txtDescription.Text = String.Format(mv_ResourceManager.GetString("DescCACash"), cboCODEID.Text, Me.BusDate)
            txtDescription.Enabled = False
        End If
        'sonlt 20141030
        GetSEMemberGrid(Trim(mskAFACCTNO.Text), Trim(Me.mskACTYPE.Text))
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim v_strObjMsg, v_strAFACCTNO, v_strDFTYPE, v_strSYMBOL, v_strCODEID, v_strDTYPE, str_add, v_strAUTODRAWNDOWN, v_strisapprove, v_strAFACCTNODRD, V_strREF, str As String

        Dim v_QTTY, v_AMT, v_DFPRICE, v_ORGAMT, V_DFRATE As Decimal
        Dim str_DealGRAccount As String
        Try
            Dim a As New DataTable
            a.Columns.Add("ACTYPE")
            a.Columns.Add("DFTYPE")
            a.Rows.Add("T")
            a.Rows.Add("e")
            Dim b As New DataSet

            b.Tables.Add(a)

            Dim table1 As DataTable = New DataTable("patients")
            table1.Columns.Add("name")
            table1.Columns.Add("id")
            table1.Rows.Add("sam", 1)
            table1.Rows.Add("mark", 2)

            Dim set1 As DataSet = New DataSet("office")
            set1.Tables.Add(table1)

            'v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, "DF.CREATEDFGRDEAL", gc_ActionAdhoc, , , "ADDCFLINK", , , , , , , , )
            'BuildXMLObjData(set1, v_strObjMsg)



            'Dim tblDFGRLOG As DataTable = New DataTable
            'tblDFGRLOG.Columns.Add("ACTYPE")
            'tblDFGRLOG.Columns.Add("DFTYPE")
            'tblDFGRLOG.Columns.Add("ORGAMT")
            'tblDFGRLOG.Columns.Add("TXTIME")
            'tblDFGRLOG.Columns.Add("TXDATE")
            'tblDFGRLOG.Columns.Add("TXNUM")
            'tblDFGRLOG.Columns.Add("MAKER")
            'tblDFGRLOG.Columns.Add("IRATE")
            'tblDFGRLOG.Columns.Add("MRATE")
            'tblDFGRLOG.Columns.Add("LRATE")
            'tblDFGRLOG.Columns.Add("AUTODRAWDOWN")
            'tblDFGRLOG.Columns.Add("ISAPPROVE")
            'tblDFGRLOG.Columns.Add("DESCRIPTION")
            'tblDFGRLOG.Columns.Add("AFACCTNO")
            'tblDFGRLOG.Columns.Add("DTYPE")
            'tblDFGRLOG.Columns.Add("SYMBOL")
            'tblDFGRLOG.Columns.Add("CODEID")
            'tblDFGRLOG.Columns.Add("QTTY")
            'tblDFGRLOG.Columns.Add("DFPRICE")
            'tblDFGRLOG.Columns.Add("DFRATE")
            'tblDFGRLOG.Columns.Add("AMT")
            'tblDFGRLOG.Columns.Add("GROUPID")

            str_DealGRAccount = GetDealAccount()
            If chkAUTODRAWNDOWN.Checked Then
                v_strAUTODRAWNDOWN = "1"
            Else
                v_strAUTODRAWNDOWN = "0"
            End If

            If chkisapprove.Checked Then
                v_strisapprove = "Y"
            Else
                v_strisapprove = "N"
            End If

            v_strAFACCTNODRD = Me.cboAFACCTNODRD.SelectedValue.ToString()
            For i As Integer = 0 To DFGRGrid.DataRows.Count - 1
                With DFGRGrid.DataRows(i)
                    If (Not .Cells("AMT").Value Is Nothing) Then
                        v_AMT = gf_CorrectNumericField(.Cells("AMT").Value.ToString().Trim())
                        v_ORGAMT = v_ORGAMT + v_AMT
                    Else
                        v_AMT = 0
                    End If

                End With
            Next

            For i As Integer = 0 To DFGRGrid.DataRows.Count - 1
                With DFGRGrid.DataRows(i)


                    If (Not .Cells("AFACCTNO").Value Is Nothing) Then
                        v_strAFACCTNO = .Cells("AFACCTNO").Value.ToString().Trim()
                    Else
                        v_strAFACCTNO = vbNullString
                    End If
                    If (Not .Cells("REF").Value Is Nothing) Then
                        V_strREF = .Cells("REF").Value.ToString().Trim()
                    Else
                        V_strREF = vbNullString
                    End If
                    If (Not .Cells("DTYPE").Value Is Nothing) Then
                        v_strDTYPE = .Cells("DTYPE").Value.ToString().Trim()
                    Else
                        v_strDTYPE = vbNullString
                    End If
                    If (Not .Cells("SYMBOL").Value Is Nothing) Then
                        v_strSYMBOL = .Cells("SYMBOL").Value.ToString().Trim()
                    Else
                        v_strSYMBOL = vbNullString
                    End If
                    If (Not .Cells("CODEID").Value Is Nothing) Then
                        v_strCODEID = gf_CorrectNumericField(.Cells("CODEID").Value.ToString().Trim())
                    Else
                        v_strCODEID = vbNullString
                    End If

                    If (Not .Cells("QTTY").Value Is Nothing) Then
                        v_QTTY = gf_CorrectNumericField(.Cells("QTTY").Value.ToString().Trim())
                    Else
                        v_QTTY = 0
                    End If
                    If (Not .Cells("DFPRICE").Value Is Nothing) Then
                        v_DFPRICE = gf_CorrectNumericField(.Cells("DFPRICE").Value.ToString().Trim())
                    Else
                        v_DFPRICE = 0
                    End If

                    If (Not .Cells("DFRATE").Value Is Nothing) Then
                        V_DFRATE = gf_CorrectNumericField(.Cells("DFRATE").Value.ToString().Trim())
                    Else
                        V_DFRATE = 0
                    End If
                    If (Not .Cells("AMT").Value Is Nothing) Then
                        v_AMT = gf_CorrectNumericField(.Cells("AMT").Value.ToString().Trim())

                    Else
                        v_AMT = 0
                    End If

                    ' tblDFGRLOG.Rows.Add(Trim(mskACTYPE.Text), mv_strDFTYPE, 0, CurrentTime, CurrentTime, "9900111111", "0001", CDbl(Me.txtIRATE.Text), CDbl(Me.txtMRATE.Text), CDbl(Me.txtLRATE.Text), "1", "Y", Me.txtDescription.Text, v_strAFACCTNO, v_strDTYPE, v_strSYMBOL, v_strCODEID, v_QTTY, v_DFPRICE, v_AMT)
                    str_add = str_add & Trim(mskACTYPE.Text) & "|" & mv_strDFTYPE & "|" & v_ORGAMT & "|" & CurrentTime & "|" & Me.BusDate & "|" & "9900111111" & "|" & "0001" & "|" & CDbl(Me.txtIRATE.Text) & "|" & CDbl(Me.txtMRATE.Text) & "|" & CDbl(Me.txtLRATE.Text) & "|" & "1" & "|" & "Y" & "|" & Me.txtDescription.Text & "|" & v_strAFACCTNO & "|" & v_strDTYPE & "|" & v_strSYMBOL & "|" & v_strCODEID & "|" & v_QTTY & "|" & v_DFPRICE & "|" & V_DFRATE & "|" & v_AMT & "|" & str_DealGRAccount & "|" & v_strAUTODRAWNDOWN & "|" & v_strisapprove & "|" & v_strAFACCTNODRD & "|" & V_strREF & "$"
                End With
            Next
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, "DF.CREATEDFGRDEAL", gc_ActionAdhoc, , str_add, "ADDCFLINK", , , , , , , , )
            BuildXMLObjData(set1, v_strObjMsg)

            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)

            'Dim dsDFGRLOG As DataSet = New DataSet("dsDFGRLOG")
            'dsDFGRLOG.Tables.Add(tblDFGRLOG)

            'v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, "DF.CREATEDFGRDEAL", gc_ActionAdhoc, , , "ADDCFLINK", , , , , , , , )
            'BuildXMLObjData(set1, v_strObjMsg)

            'Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
            'Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)



        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub btnDEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDEL.Click
        If DFGRGrid.DataRows.Count = 0 Then Exit Sub

        For i As Integer = 0 To SEMemberGrid.DataRows.Count - 1
            With SEMemberGrid.DataRows(i)
                If .Cells("SYMBOL").Value = Trim(CType(DFGRGrid.CurrentRow, Xceed.Grid.DataRow).Cells("SYMBOL").Value) And .Cells("DTYPE").Value = Trim(CType(DFGRGrid.CurrentRow, Xceed.Grid.DataRow).Cells("DTYPE").Value) Then
                    .Cells("QTTY").Value = CDbl(.Cells("QTTY").Value) + CDbl(Trim(CType(DFGRGrid.CurrentRow, Xceed.Grid.DataRow).Cells("QTTY").Value))
                    .Cells("AVLWITHDRAW").Value = CDbl(.Cells("AVLWITHDRAW").Value) + CDbl(Trim(CType(DFGRGrid.CurrentRow, Xceed.Grid.DataRow).Cells("QTTY").Value))
                End If
            End With
        Next



        Me.DFGRGrid.CurrentRow.Remove()
        Dim v_dblamt As Double
        v_dblamt = 0
        For K As Integer = 0 To DFGRGrid.DataRows.Count - 1
            With DFGRGrid.DataRows(K)
                If (Not .Cells("AMT").Value Is Nothing) Then
                    v_dblamt = v_dblamt + gf_CorrectNumericField(.Cells("AMT").Value.ToString().Trim())
                End If

            End With
        Next
        Me.txtTOLAMT.Text = FormatNumber(v_dblamt, 0)
        'sonlt 20141030 Xu ly desc
        If DFGRGrid.DataRows.Count = 0 Then
            txtDescription.Enabled = True
            txtDescription.Text = mv_desc
        End If
        'sonlt 20141030 Xu ly desc
    End Sub

    Private Sub DFGRGrid_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DFGRGrid.Validating
        Dim v_dblamt As Double
        v_dblamt = 0
        For i As Integer = 0 To DFGRGrid.DataRows.Count - 1
            With DFGRGrid.DataRows(i)
                If (Not .Cells("AMT").Value Is Nothing) Then
                    v_dblamt = v_dblamt + gf_CorrectNumericField(.Cells("AMT").Value.ToString().Trim())
                End If

            End With
        Next
        Me.txtTOLAMT.Text = FormatNumber(v_dblamt, 0)
    End Sub

End Class
