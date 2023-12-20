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

Public Class frmODTransact
    Inherits System.Windows.Forms.Form
    Private mv_intCurrImageIndex As Integer = 0
    Private mv_arrSIGNATURE As String()
    Private mv_arrAUTOID As String()
    Private mv_arrCUSTID As String()
    Friend WithEvents MemberGrid As New GridEx

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
    Friend WithEvents lblSymbol As System.Windows.Forms.Label
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
    Friend WithEvents txtQuotePrice As System.Windows.Forms.TextBox
    Friend WithEvents txtLimitPrice As System.Windows.Forms.TextBox
    Friend WithEvents lblAFACCTNO As System.Windows.Forms.Label
    Friend WithEvents lblTimeType As System.Windows.Forms.Label
    Friend WithEvents lblExecType As System.Windows.Forms.Label
    Friend WithEvents lblMatchType As System.Windows.Forms.Label
    Friend WithEvents mskAFACCTNO As FlexMaskEditBox
    Friend WithEvents cboExecType As ComboBoxEx
    Friend WithEvents cboMatchType As ComboBoxEx
    Friend WithEvents cboTimeType As ComboBoxEx
    Friend WithEvents cboCODEID As ComboBoxEx
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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.pnlTitle = New System.Windows.Forms.Panel
        Me.lblAFINFO = New System.Windows.Forms.Label
        Me.lblAFNAME = New System.Windows.Forms.Label
        Me.mskAFACCTNO = New AppCore.FlexMaskEditBox
        Me.lblAFACCTNO = New System.Windows.Forms.Label
        Me.chkDetail = New System.Windows.Forms.CheckBox
        Me.pnOrder = New System.Windows.Forms.Panel
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.lblDescription = New System.Windows.Forms.Label
        Me.cboVoucher = New AppCore.ComboBoxEx
        Me.dtpExpiredDate = New System.Windows.Forms.DateTimePicker
        Me.cboCODEID = New AppCore.ComboBoxEx
        Me.chkAllorNone = New System.Windows.Forms.CheckBox
        Me.lblExpiredDate = New System.Windows.Forms.Label
        Me.cboTimeType = New AppCore.ComboBoxEx
        Me.lblTimeType = New System.Windows.Forms.Label
        Me.cboPriceType = New AppCore.ComboBoxEx
        Me.lblPriceType = New System.Windows.Forms.Label
        Me.txtQuantity = New System.Windows.Forms.TextBox
        Me.lblQuantity = New System.Windows.Forms.Label
        Me.lblSymbol = New System.Windows.Forms.Label
        Me.cboExecType = New AppCore.ComboBoxEx
        Me.lblExecType = New System.Windows.Forms.Label
        Me.lblMatchType = New System.Windows.Forms.Label
        Me.cboMatchType = New AppCore.ComboBoxEx
        Me.lblStopPrice = New System.Windows.Forms.Label
        Me.txtLimitPrice = New System.Windows.Forms.TextBox
        Me.lblVoucher = New System.Windows.Forms.Label
        Me.cboCalendar = New AppCore.ComboBoxEx
        Me.lblCalendar = New System.Windows.Forms.Label
        Me.cboConsultant = New AppCore.ComboBoxEx
        Me.lblConsultant = New System.Windows.Forms.Label
        Me.txtClearingDay = New System.Windows.Forms.TextBox
        Me.lblClearingDay = New System.Windows.Forms.Label
        Me.txtQuotePrice = New System.Windows.Forms.TextBox
        Me.txtBRATIO = New System.Windows.Forms.TextBox
        Me.txtVIA = New System.Windows.Forms.TextBox
        Me.lblSymbolInfo = New System.Windows.Forms.Label
        Me.lblLimitPrice = New System.Windows.Forms.Label
        Me.txtACTYPE = New System.Windows.Forms.TextBox
        Me.txtTRADELIMIT = New System.Windows.Forms.TextBox
        Me.lblOrderID = New System.Windows.Forms.Label
        Me.pnContractInfo = New System.Windows.Forms.Panel
        Me.pnlMember = New System.Windows.Forms.Panel
        Me.picSignature = New System.Windows.Forms.PictureBox
        Me.VScrollBarSign = New System.Windows.Forms.VScrollBar
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCANCEL = New System.Windows.Forms.Button
        Me.pnBalance = New System.Windows.Forms.Panel
        Me.lblCI = New System.Windows.Forms.Label
        Me.lblCIBalance = New System.Windows.Forms.Label
        Me.lblSEBalance = New System.Windows.Forms.Label
        Me.lblSE = New System.Windows.Forms.Label
        Me.pnlTitle.SuspendLayout()
        Me.pnOrder.SuspendLayout()
        Me.pnContractInfo.SuspendLayout()
        Me.pnBalance.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlTitle
        '
        Me.pnlTitle.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlTitle.Controls.Add(Me.lblAFINFO)
        Me.pnlTitle.Controls.Add(Me.lblAFNAME)
        Me.pnlTitle.Controls.Add(Me.mskAFACCTNO)
        Me.pnlTitle.Controls.Add(Me.lblAFACCTNO)
        Me.pnlTitle.Controls.Add(Me.chkDetail)
        Me.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTitle.Location = New System.Drawing.Point(0, 0)
        Me.pnlTitle.Name = "pnlTitle"
        Me.pnlTitle.Size = New System.Drawing.Size(632, 50)
        Me.pnlTitle.TabIndex = 0
        '
        'lblAFINFO
        '
        Me.lblAFINFO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAFINFO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAFINFO.ForeColor = System.Drawing.Color.Black
        Me.lblAFINFO.Location = New System.Drawing.Point(152, 16)
        Me.lblAFINFO.Name = "lblAFINFO"
        Me.lblAFINFO.Size = New System.Drawing.Size(472, 20)
        Me.lblAFINFO.TabIndex = 4
        Me.lblAFINFO.Text = "lblAFINFO"
        '
        'lblAFNAME
        '
        Me.lblAFNAME.Location = New System.Drawing.Point(232, 16)
        Me.lblAFNAME.Name = "lblAFNAME"
        Me.lblAFNAME.Size = New System.Drawing.Size(336, 23)
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
        '
        'lblAFACCTNO
        '
        Me.lblAFACCTNO.Location = New System.Drawing.Point(8, 16)
        Me.lblAFACCTNO.Name = "lblAFACCTNO"
        Me.lblAFACCTNO.Size = New System.Drawing.Size(72, 20)
        Me.lblAFACCTNO.TabIndex = 0
        Me.lblAFACCTNO.Text = "lblAFACCTNO"
        '
        'chkDetail
        '
        Me.chkDetail.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkDetail.Checked = True
        Me.chkDetail.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDetail.Location = New System.Drawing.Point(577, 16)
        Me.chkDetail.Name = "chkDetail"
        Me.chkDetail.Size = New System.Drawing.Size(48, 21)
        Me.chkDetail.TabIndex = 3
        Me.chkDetail.Tag = ""
        Me.chkDetail.Text = ">>"
        Me.chkDetail.Visible = False
        '
        'pnOrder
        '
        Me.pnOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnOrder.Controls.Add(Me.txtDescription)
        Me.pnOrder.Controls.Add(Me.lblDescription)
        Me.pnOrder.Controls.Add(Me.cboVoucher)
        Me.pnOrder.Controls.Add(Me.dtpExpiredDate)
        Me.pnOrder.Controls.Add(Me.cboCODEID)
        Me.pnOrder.Controls.Add(Me.chkAllorNone)
        Me.pnOrder.Controls.Add(Me.lblExpiredDate)
        Me.pnOrder.Controls.Add(Me.cboTimeType)
        Me.pnOrder.Controls.Add(Me.lblTimeType)
        Me.pnOrder.Controls.Add(Me.cboPriceType)
        Me.pnOrder.Controls.Add(Me.lblPriceType)
        Me.pnOrder.Controls.Add(Me.txtQuantity)
        Me.pnOrder.Controls.Add(Me.lblQuantity)
        Me.pnOrder.Controls.Add(Me.lblSymbol)
        Me.pnOrder.Controls.Add(Me.cboExecType)
        Me.pnOrder.Controls.Add(Me.lblExecType)
        Me.pnOrder.Controls.Add(Me.lblMatchType)
        Me.pnOrder.Controls.Add(Me.cboMatchType)
        Me.pnOrder.Controls.Add(Me.lblStopPrice)
        Me.pnOrder.Controls.Add(Me.txtLimitPrice)
        Me.pnOrder.Controls.Add(Me.lblVoucher)
        Me.pnOrder.Controls.Add(Me.cboCalendar)
        Me.pnOrder.Controls.Add(Me.lblCalendar)
        Me.pnOrder.Controls.Add(Me.cboConsultant)
        Me.pnOrder.Controls.Add(Me.lblConsultant)
        Me.pnOrder.Controls.Add(Me.txtClearingDay)
        Me.pnOrder.Controls.Add(Me.lblClearingDay)
        Me.pnOrder.Controls.Add(Me.txtQuotePrice)
        Me.pnOrder.Controls.Add(Me.txtBRATIO)
        Me.pnOrder.Controls.Add(Me.txtVIA)
        Me.pnOrder.Controls.Add(Me.lblSymbolInfo)
        Me.pnOrder.Controls.Add(Me.lblLimitPrice)
        Me.pnOrder.Controls.Add(Me.txtACTYPE)
        Me.pnOrder.Controls.Add(Me.txtTRADELIMIT)
        Me.pnOrder.Location = New System.Drawing.Point(8, 50)
        Me.pnOrder.Name = "pnOrder"
        Me.pnOrder.Size = New System.Drawing.Size(616, 174)
        Me.pnOrder.TabIndex = 1
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(98, 143)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(506, 20)
        Me.txtDescription.TabIndex = 14
        Me.txtDescription.Text = ""
        '
        'lblDescription
        '
        Me.lblDescription.Location = New System.Drawing.Point(8, 143)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(80, 23)
        Me.lblDescription.TabIndex = 26
        Me.lblDescription.Text = "lblDescription"
        '
        'cboVoucher
        '
        Me.cboVoucher.DisplayMember = "DISPLAY"
        Me.cboVoucher.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVoucher.Location = New System.Drawing.Point(98, 116)
        Me.cboVoucher.Name = "cboVoucher"
        Me.cboVoucher.Size = New System.Drawing.Size(100, 21)
        Me.cboVoucher.TabIndex = 11
        Me.cboVoucher.ValueMember = "VALUE"
        '
        'dtpExpiredDate
        '
        Me.dtpExpiredDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpExpiredDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpExpiredDate.Location = New System.Drawing.Point(296, 89)
        Me.dtpExpiredDate.Name = "dtpExpiredDate"
        Me.dtpExpiredDate.Size = New System.Drawing.Size(96, 20)
        Me.dtpExpiredDate.TabIndex = 8
        Me.dtpExpiredDate.Tag = "21"
        Me.dtpExpiredDate.Value = New Date(2006, 10, 30, 0, 0, 0, 0)
        '
        'cboCODEID
        '
        Me.cboCODEID.DisplayMember = "DISPLAY"
        Me.cboCODEID.Location = New System.Drawing.Point(296, 8)
        Me.cboCODEID.Name = "cboCODEID"
        Me.cboCODEID.Size = New System.Drawing.Size(96, 21)
        Me.cboCODEID.TabIndex = 1
        Me.cboCODEID.Tag = "01"
        Me.cboCODEID.ValueMember = "VALUE"
        '
        'chkAllorNone
        '
        Me.chkAllorNone.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkAllorNone.Location = New System.Drawing.Point(548, 89)
        Me.chkAllorNone.Name = "chkAllorNone"
        Me.chkAllorNone.Size = New System.Drawing.Size(56, 20)
        Me.chkAllorNone.TabIndex = 10
        Me.chkAllorNone.Tag = "23"
        Me.chkAllorNone.Text = "AON"
        '
        'lblExpiredDate
        '
        Me.lblExpiredDate.Location = New System.Drawing.Point(209, 89)
        Me.lblExpiredDate.Name = "lblExpiredDate"
        Me.lblExpiredDate.Size = New System.Drawing.Size(88, 21)
        Me.lblExpiredDate.TabIndex = 17
        Me.lblExpiredDate.Text = "lblExpiredDate"
        '
        'cboTimeType
        '
        Me.cboTimeType.DisplayMember = "DISPLAY"
        Me.cboTimeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTimeType.Location = New System.Drawing.Point(98, 89)
        Me.cboTimeType.Name = "cboTimeType"
        Me.cboTimeType.Size = New System.Drawing.Size(100, 21)
        Me.cboTimeType.TabIndex = 7
        Me.cboTimeType.Tag = "20"
        Me.cboTimeType.ValueMember = "VALUE"
        '
        'lblTimeType
        '
        Me.lblTimeType.Location = New System.Drawing.Point(8, 89)
        Me.lblTimeType.Name = "lblTimeType"
        Me.lblTimeType.Size = New System.Drawing.Size(80, 21)
        Me.lblTimeType.TabIndex = 15
        Me.lblTimeType.Tag = "TIMETYPE"
        Me.lblTimeType.Text = "lblTimeType"
        '
        'cboPriceType
        '
        Me.cboPriceType.DisplayMember = "DISPLAY"
        Me.cboPriceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPriceType.Location = New System.Drawing.Point(504, 8)
        Me.cboPriceType.Name = "cboPriceType"
        Me.cboPriceType.Size = New System.Drawing.Size(100, 21)
        Me.cboPriceType.TabIndex = 2
        Me.cboPriceType.Tag = "27"
        Me.cboPriceType.ValueMember = "VALUE"
        '
        'lblPriceType
        '
        Me.lblPriceType.AutoSize = True
        Me.lblPriceType.Location = New System.Drawing.Point(408, 8)
        Me.lblPriceType.Name = "lblPriceType"
        Me.lblPriceType.Size = New System.Drawing.Size(67, 16)
        Me.lblPriceType.TabIndex = 9
        Me.lblPriceType.Tag = "PRICETYPE"
        Me.lblPriceType.Text = "lblPriceType"
        '
        'txtQuantity
        '
        Me.txtQuantity.Location = New System.Drawing.Point(98, 62)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.TabIndex = 4
        Me.txtQuantity.Tag = "12"
        Me.txtQuantity.Text = "txtQuantity"
        '
        'lblQuantity
        '
        Me.lblQuantity.Location = New System.Drawing.Point(8, 62)
        Me.lblQuantity.Name = "lblQuantity"
        Me.lblQuantity.Size = New System.Drawing.Size(88, 21)
        Me.lblQuantity.TabIndex = 4
        Me.lblQuantity.Text = "lblQuantity"
        '
        'lblSymbol
        '
        Me.lblSymbol.AutoSize = True
        Me.lblSymbol.Location = New System.Drawing.Point(209, 8)
        Me.lblSymbol.Name = "lblSymbol"
        Me.lblSymbol.Size = New System.Drawing.Size(53, 16)
        Me.lblSymbol.TabIndex = 6
        Me.lblSymbol.Text = "lblSymbol"
        '
        'cboExecType
        '
        Me.cboExecType.DisplayMember = "DISPLAY"
        Me.cboExecType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboExecType.Location = New System.Drawing.Point(98, 8)
        Me.cboExecType.Name = "cboExecType"
        Me.cboExecType.Size = New System.Drawing.Size(100, 21)
        Me.cboExecType.TabIndex = 0
        Me.cboExecType.Tag = "22"
        Me.cboExecType.ValueMember = "VALUE"
        '
        'lblExecType
        '
        Me.lblExecType.Location = New System.Drawing.Point(8, 8)
        Me.lblExecType.Name = "lblExecType"
        Me.lblExecType.Size = New System.Drawing.Size(80, 21)
        Me.lblExecType.TabIndex = 2
        Me.lblExecType.Tag = "EXECTYPE"
        Me.lblExecType.Text = "lblExecType"
        '
        'lblMatchType
        '
        Me.lblMatchType.Location = New System.Drawing.Point(209, 62)
        Me.lblMatchType.Name = "lblMatchType"
        Me.lblMatchType.Size = New System.Drawing.Size(88, 21)
        Me.lblMatchType.TabIndex = 2
        Me.lblMatchType.Tag = "MATCHTYPE"
        Me.lblMatchType.Text = "lblMatchType"
        '
        'cboMatchType
        '
        Me.cboMatchType.DisplayMember = "DISPLAY"
        Me.cboMatchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMatchType.Location = New System.Drawing.Point(296, 62)
        Me.cboMatchType.Name = "cboMatchType"
        Me.cboMatchType.Size = New System.Drawing.Size(96, 21)
        Me.cboMatchType.TabIndex = 5
        Me.cboMatchType.Tag = "24"
        Me.cboMatchType.ValueMember = "VALUE"
        '
        'lblStopPrice
        '
        Me.lblStopPrice.AutoSize = True
        Me.lblStopPrice.Location = New System.Drawing.Point(408, 62)
        Me.lblStopPrice.Name = "lblStopPrice"
        Me.lblStopPrice.Size = New System.Drawing.Size(65, 16)
        Me.lblStopPrice.TabIndex = 13
        Me.lblStopPrice.Text = "lblStopPrice"
        '
        'txtLimitPrice
        '
        Me.txtLimitPrice.Location = New System.Drawing.Point(504, 62)
        Me.txtLimitPrice.Name = "txtLimitPrice"
        Me.txtLimitPrice.TabIndex = 6
        Me.txtLimitPrice.Tag = "14"
        Me.txtLimitPrice.Text = "txtLimitPrice"
        '
        'lblVoucher
        '
        Me.lblVoucher.Location = New System.Drawing.Point(8, 116)
        Me.lblVoucher.Name = "lblVoucher"
        Me.lblVoucher.Size = New System.Drawing.Size(80, 21)
        Me.lblVoucher.TabIndex = 21
        Me.lblVoucher.Tag = "TIMETYPE"
        Me.lblVoucher.Text = "lblVoucher"
        '
        'cboCalendar
        '
        Me.cboCalendar.DisplayMember = "DISPLAY"
        Me.cboCalendar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCalendar.Location = New System.Drawing.Point(296, 116)
        Me.cboCalendar.Name = "cboCalendar"
        Me.cboCalendar.Size = New System.Drawing.Size(96, 21)
        Me.cboCalendar.TabIndex = 12
        Me.cboCalendar.ValueMember = "VALUE"
        '
        'lblCalendar
        '
        Me.lblCalendar.Location = New System.Drawing.Point(209, 116)
        Me.lblCalendar.Name = "lblCalendar"
        Me.lblCalendar.Size = New System.Drawing.Size(80, 21)
        Me.lblCalendar.TabIndex = 23
        Me.lblCalendar.Tag = "TIMETYPE"
        Me.lblCalendar.Text = "lblCalendar"
        '
        'cboConsultant
        '
        Me.cboConsultant.DisplayMember = "DISPLAY"
        Me.cboConsultant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboConsultant.Location = New System.Drawing.Point(504, 116)
        Me.cboConsultant.Name = "cboConsultant"
        Me.cboConsultant.Size = New System.Drawing.Size(100, 21)
        Me.cboConsultant.TabIndex = 13
        Me.cboConsultant.ValueMember = "VALUE"
        '
        'lblConsultant
        '
        Me.lblConsultant.Location = New System.Drawing.Point(407, 116)
        Me.lblConsultant.Name = "lblConsultant"
        Me.lblConsultant.Size = New System.Drawing.Size(88, 21)
        Me.lblConsultant.TabIndex = 19
        Me.lblConsultant.Tag = "TIMETYPE"
        Me.lblConsultant.Text = "lblConsultant"
        '
        'txtClearingDay
        '
        Me.txtClearingDay.Location = New System.Drawing.Point(504, 89)
        Me.txtClearingDay.Name = "txtClearingDay"
        Me.txtClearingDay.Size = New System.Drawing.Size(32, 20)
        Me.txtClearingDay.TabIndex = 9
        Me.txtClearingDay.Tag = "10"
        Me.txtClearingDay.Text = "txtClearingDay"
        '
        'lblClearingDay
        '
        Me.lblClearingDay.AutoSize = True
        Me.lblClearingDay.Location = New System.Drawing.Point(408, 89)
        Me.lblClearingDay.Name = "lblClearingDay"
        Me.lblClearingDay.Size = New System.Drawing.Size(78, 16)
        Me.lblClearingDay.TabIndex = 25
        Me.lblClearingDay.Text = "lblClearingDay"
        '
        'txtQuotePrice
        '
        Me.txtQuotePrice.Location = New System.Drawing.Point(98, 35)
        Me.txtQuotePrice.Name = "txtQuotePrice"
        Me.txtQuotePrice.TabIndex = 3
        Me.txtQuotePrice.Tag = "11"
        Me.txtQuotePrice.Text = "txtQuotePrice"
        '
        'txtBRATIO
        '
        Me.txtBRATIO.Location = New System.Drawing.Point(408, 35)
        Me.txtBRATIO.Name = "txtBRATIO"
        Me.txtBRATIO.Size = New System.Drawing.Size(32, 20)
        Me.txtBRATIO.TabIndex = 5
        Me.txtBRATIO.Tag = "13"
        Me.txtBRATIO.Text = "0"
        Me.txtBRATIO.Visible = False
        '
        'txtVIA
        '
        Me.txtVIA.Location = New System.Drawing.Point(440, 35)
        Me.txtVIA.Name = "txtVIA"
        Me.txtVIA.Size = New System.Drawing.Size(16, 20)
        Me.txtVIA.TabIndex = 6
        Me.txtVIA.Tag = "22"
        Me.txtVIA.Text = "F"
        Me.txtVIA.Visible = False
        '
        'lblSymbolInfo
        '
        Me.lblSymbolInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSymbolInfo.Location = New System.Drawing.Point(200, 35)
        Me.lblSymbolInfo.Name = "lblSymbolInfo"
        Me.lblSymbolInfo.Size = New System.Drawing.Size(400, 21)
        Me.lblSymbolInfo.TabIndex = 8
        Me.lblSymbolInfo.Text = "lblSymbolInfo"
        '
        'lblLimitPrice
        '
        Me.lblLimitPrice.Location = New System.Drawing.Point(8, 35)
        Me.lblLimitPrice.Name = "lblLimitPrice"
        Me.lblLimitPrice.Size = New System.Drawing.Size(88, 21)
        Me.lblLimitPrice.TabIndex = 11
        Me.lblLimitPrice.Text = "lblLimitPrice"
        '
        'txtACTYPE
        '
        Me.txtACTYPE.Location = New System.Drawing.Point(464, 35)
        Me.txtACTYPE.Name = "txtACTYPE"
        Me.txtACTYPE.Size = New System.Drawing.Size(56, 20)
        Me.txtACTYPE.TabIndex = 7
        Me.txtACTYPE.Tag = "02"
        Me.txtACTYPE.Text = "ACTYPE"
        Me.txtACTYPE.Visible = False
        '
        'txtTRADELIMIT
        '
        Me.txtTRADELIMIT.Location = New System.Drawing.Point(368, 35)
        Me.txtTRADELIMIT.Name = "txtTRADELIMIT"
        Me.txtTRADELIMIT.Size = New System.Drawing.Size(32, 20)
        Me.txtTRADELIMIT.TabIndex = 4
        Me.txtTRADELIMIT.Tag = "13"
        Me.txtTRADELIMIT.Text = "0"
        Me.txtTRADELIMIT.Visible = False
        '
        'lblOrderID
        '
        Me.lblOrderID.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me.lblOrderID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblOrderID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrderID.ForeColor = System.Drawing.Color.Red
        Me.lblOrderID.Location = New System.Drawing.Point(8, 400)
        Me.lblOrderID.Name = "lblOrderID"
        Me.lblOrderID.Size = New System.Drawing.Size(184, 23)
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
        Me.pnContractInfo.Location = New System.Drawing.Point(8, 264)
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
        Me.VScrollBarSign.Location = New System.Drawing.Point(592, 3)
        Me.VScrollBarSign.Name = "VScrollBarSign"
        Me.VScrollBarSign.Size = New System.Drawing.Size(17, 120)
        Me.VScrollBarSign.TabIndex = 6
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(456, 400)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(80, 24)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "btnOK"
        '
        'btnCANCEL
        '
        Me.btnCANCEL.Location = New System.Drawing.Point(544, 400)
        Me.btnCANCEL.Name = "btnCANCEL"
        Me.btnCANCEL.Size = New System.Drawing.Size(80, 24)
        Me.btnCANCEL.TabIndex = 5
        Me.btnCANCEL.Text = "btnCANCEL"
        '
        'pnBalance
        '
        Me.pnBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnBalance.Controls.Add(Me.lblCI)
        Me.pnBalance.Controls.Add(Me.lblCIBalance)
        Me.pnBalance.Controls.Add(Me.lblSEBalance)
        Me.pnBalance.Controls.Add(Me.lblSE)
        Me.pnBalance.Location = New System.Drawing.Point(8, 230)
        Me.pnBalance.Name = "pnBalance"
        Me.pnBalance.Size = New System.Drawing.Size(616, 30)
        Me.pnBalance.TabIndex = 2
        '
        'lblCI
        '
        Me.lblCI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCI.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCI.Location = New System.Drawing.Point(180, 4)
        Me.lblCI.Name = "lblCI"
        Me.lblCI.Size = New System.Drawing.Size(120, 23)
        Me.lblCI.TabIndex = 7
        Me.lblCI.Text = "lblCI"
        '
        'lblCIBalance
        '
        Me.lblCIBalance.Location = New System.Drawing.Point(92, 4)
        Me.lblCIBalance.Name = "lblCIBalance"
        Me.lblCIBalance.Size = New System.Drawing.Size(80, 23)
        Me.lblCIBalance.TabIndex = 6
        Me.lblCIBalance.Text = "lblCIBalance"
        '
        'lblSEBalance
        '
        Me.lblSEBalance.Location = New System.Drawing.Point(316, 4)
        Me.lblSEBalance.Name = "lblSEBalance"
        Me.lblSEBalance.Size = New System.Drawing.Size(80, 23)
        Me.lblSEBalance.TabIndex = 8
        Me.lblSEBalance.Text = "lblSEBalance"
        '
        'lblSE
        '
        Me.lblSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSE.Location = New System.Drawing.Point(404, 4)
        Me.lblSE.Name = "lblSE"
        Me.lblSE.Size = New System.Drawing.Size(120, 23)
        Me.lblSE.TabIndex = 9
        Me.lblSE.Text = "lblSE"
        '
        'frmODTransact
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.ClientSize = New System.Drawing.Size(632, 431)
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
        Me.Name = "frmODTransact"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmODTransact"
        Me.pnlTitle.ResumeLayout(False)
        Me.pnOrder.ResumeLayout(False)
        Me.pnContractInfo.ResumeLayout(False)
        Me.pnBalance.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Declare constant and variables "
    Const c_ResourceManager = "_DIRECT.frmODTransact-"
    Dim mv_strLastAFACCTNO As String = String.Empty
    Dim mv_dblFloorPrice As Double
    Dim mv_dblCeilingPrice As Double
    Dim mv_dblTradeLot As Double
    Dim mv_dblTradeUnit As Double
    Dim mv_dbdParvalue As Double
    Dim mv_dblAF_Bratio As Double
    Dim mv_dblTyp_Bratio As Double
    Dim mv_dblSecureBratioMax As Double
    Dim mv_dblSecureBratioMin As Double
    Dim mv_dblSecureRatio As Double
    Dim mv_strOrderID As String
    Dim mv_strCUSTID As String = String.Empty
    Dim mv_strFULLNAME As String = String.Empty
    Dim mv_strACTYPE As String = String.Empty
    Dim mv_strIsDisposal As String = "N"

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

    Private Const CONTROL_PNL_BALANCE_TOP = 230
    Private Const CONTROL_PNL_CONTRACT_TOP = 265 '200
    Private Const CONTROL_BUTTON_TOP = 400
    Private Const FRM_DEFAULT_HEIGHT = 420
    Private Const FRM_EXTEND_HEIGHT = 455
    Private Const MISS_HIGHT = 35
#End Region

#Region " Properties "
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


    Public Property IsDisposal() As String
        Get
            Return mv_strIsDisposal
        End Get
        Set(ByVal Value As String)
            mv_strIsDisposal = Value
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
#End Region

#Region " InitEtrnal"
    Private Sub InitExternal()
        'Khởi tạo Grid MemberGrid
        MemberGrid = New GridEx

        Dim v_cmrMemberHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrMemberHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrMemberHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)

        MemberGrid.FixedHeaderRows.Add(v_cmrMemberHeader)
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

        MemberGrid.Columns("AUTOID").Width = 0
        MemberGrid.Columns("TYP").Width = 100
        MemberGrid.Columns("TYP").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        MemberGrid.Columns("CUSTID").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        MemberGrid.Columns("IDCODE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        MemberGrid.Columns("FULLNAME").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        MemberGrid.Columns("REF").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left

        Me.pnlMember.Controls.Clear()
        Me.pnlMember.Controls.Add(MemberGrid)
        MemberGrid.Dock = Windows.Forms.DockStyle.Fill
        AddHandler MemberGrid.DoubleClick, AddressOf Me.MemberGrid_Click
        If Me.MemberGrid.DataRowTemplate.Cells.Count >= 0 Then
            For i As Integer = 0 To Me.MemberGrid.DataRowTemplate.Cells.Count - 1
                AddHandler MemberGrid.DataRowTemplate.Cells(i).DoubleClick, AddressOf MemberGrid_Click
            Next
        End If
    End Sub
#End Region

#Region " Other method "

    '---------------------------------------------------------------------------------------------------------
    'Hàm này được sử dụng điền các thông tin giá trị Lookup được.
    'Biến vào 
    '   v_strFLDNAME Là mã trường thực hiện Lookup
    '   v_strRETURNDATA  Là giá trị Value được chọn
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
                If "BRATIO" = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) Then
                    txtBRATIO.Text = Trim(.InnerText.ToString)
                    mv_dblTyp_Bratio = Trim(.InnerText.ToString)
                ElseIf "TRADELIMIT" = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) Then
                    txtTRADELIMIT.Text = Trim(.InnerText.ToString)
                End If
            End With
        Next
    End Sub
    '---------------------------------------------------------------------------------------------------------
    'Hàm này được sử dụng để nạp màn hình.
    'Biến vào 
    '   strTLTXCD là mã giao dịch, dùng để xác định các trường trong giao dịch
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

            'Lấy thông tin chung về giao dịch
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

            'Lấy thông tin chi tiết các trường của giao dịch
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
                        'Xử lý cho trường Description
                        v_strDefVal = Me.Text
                    ElseIf v_strDefVal = "<$BUSDATE>" Then
                        'Lấy ngày làm việc hiện tại
                        v_strDefVal = Me.BusDate
                    End If
                    If v_blnChain Then
                        'Nếu giao dịch được nạp qua giao dịch tra cứu
                        If Len(v_strChainName) > 0 Then
                            'Nếu trường này có sử dụng CHAINNAME để lấy giá trị từ màn hình tra cứu
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

            'Lấy các luật kiểm tra của các trường giao dịch
            v_strClause = "SELECT FLDNAME, VALTYPE, OPERATOR, VALEXP, VALEXP2, ERRMSG, EN_ERRMSG FROM FLDVAL " & _
                "WHERE upper(OBJNAME) = '" & strTLTXCD & "' ORDER BY VALTYPE, FLDNAME, ODRNUM" 'Thứ tự order by là quan trọng không sửa
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
                        'Ghi nhận thuật toán để kiểm tra và tính toán cho từng trường của giao dịch
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

                'Điều kiện xử lý
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
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Sub
    'Verify rules của giao dịch, trả về điện giao dịch đã được tạo
    Private Function VerifyRules(ByRef v_strTxMsg As String) As Boolean
        Try
            Dim v_xmlDocument As New Xml.XmlDocument, v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
            Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode, v_intIndex As Long, i, v_intCount As Integer
            Dim v_strFLDNAME As String, v_strFLDDEFNAME As String, v_strDATATYPE As String, v_strFLDVALUE As String
            Dim v_strERRMSG, v_strENERRMSG, v_strOPERATOR, v_strVALEXP, v_strVALEXP2 As String, v_strACTYPE, v_strDESC As String
            Dim v_dtVALEXP, v_dtVALEXP2, v_dtFLDVALUE As Date, v_strCMDSQL As String
            Dim v_ctl As Control, v_attrFLDNAME As Xml.XmlAttribute, v_attrDATATYPE As Xml.XmlAttribute, v_objEval As New Evaluator

            'Xác định mã loại hình của hợp đồng: Hiển thị form lookup để chọn
            v_strCMDSQL = "SELECT ACTYPE,ACTYPE VALUECD,ACTYPE VALUE, TYPENAME DISPLAY,TYPENAME EN_DISPLAY,TYPENAME DESCRIPTION, TRADELIMIT, BRATIO FROM ODTYPE " & ControlChars.CrLf _
                & "WHERE STATUS='Y' AND VIA='F' " & ControlChars.CrLf _
                & "AND CLEARCD='" & cboCalendar.SelectedValue & "' " & ControlChars.CrLf _
                & "AND EXECTYPE='" & cboExecType.SelectedValue & "' " & ControlChars.CrLf _
                & "AND TIMETYPE='" & cboTimeType.SelectedValue & "' " & ControlChars.CrLf _
                & "AND PRICETYPE='" & cboPriceType.SelectedValue & "' " & ControlChars.CrLf _
                & "AND MATCHTYPE='" & cboMatchType.SelectedValue & "' " & ControlChars.CrLf _
                & "AND NORK='" & IIf(chkAllorNone.Checked, "Y", "N") & "'" & ControlChars.CrLf _
                & " AND ACTYPE IN (SELECT ACTYPE FROM REGTYPE WHERE AFTYPE = '" & mv_strACTYPE & "')"
            Dim frm As New frmLookUp(UserLanguage)
            frm.SQLCMD = v_strCMDSQL
            frm.AutoClosed = True
            frm.ShowDialog()
            v_intIndex = InStr(frm.RETURNDATA, vbTab)
            If v_intIndex > 0 Then
                v_strACTYPE = Mid(frm.RETURNDATA, 1, v_intIndex - 1)
                v_strDESC = Mid(frm.RETURNDATA, v_intIndex + 1)
                'Lấy giá trị BRATIO và TRADELIMIT để kiểm tra hạn mức
                FillLookupData(Mid(frm.RETURNDATA, 1, v_intIndex - 1), frm.FULLDATA)
            End If
            frm.Dispose()

            If Len(v_strACTYPE) = 0 Then
                'Không lựa chọn loại hình nào
                If Me.UserLanguage = gc_LANG_ENGLISH Then
                    MsgBox("Product type not found", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, Me.Text)
                Else
                    MsgBox("Không tìm thấy loại hình đặt lệnh", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, Me.Text)
                End If
                Return False
            End If

            'Kiểm tra expired date không nhỏ hơn ngày làm việc hiện tại
            If Me.dtpExpiredDate.Value < DDMMYYYY_SystemDate(Me.BusDate) Then
                If Me.UserLanguage = gc_LANG_ENGLISH Then
                    MsgBox("Expired date is invalid", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, Me.Text)
                Else
                    MsgBox("Ngày hết hạn không hợp lệ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, Me.Text)
                End If
                Return False
            End If

            'Tạo điện giao dịch
            If cboExecType.SelectedValue = "NB" And cboTimeType.SelectedValue = "T" Then
                If chkDetail.Checked Then
                    'Nếu là Màn hình nhập lệnh Advanced thì tự động đẩy lệnh luôn không cần Officer duyệt
                    LoadScreen(gc_OD_PLACENORMALBUYORDER_ADVANCED)
                    v_strTxMsg = BuildXMLTxMsg(gc_MsgTypeTrans, gc_IsLocalMsg, gc_OD_PLACENORMALBUYORDER_ADVANCED, Me.BranchId, Me.TellerId, Me.IpAddress, Me.WsName, , , , , , , , , , , , , , , , , Me.BusDate)
                Else
                    'Nếu là lệnh mua/bán thông thường thì tự động đẩy lệnh luôn & ký quỹ.
                    LoadScreen(gc_OD_PLACENORMALBUYORDER)
                    v_strTxMsg = BuildXMLTxMsg(gc_MsgTypeTrans, gc_IsLocalMsg, gc_OD_PLACENORMALBUYORDER, Me.BranchId, Me.TellerId, Me.IpAddress, Me.WsName, , , , , , , , , , , , , , , , , Me.BusDate)
                End If

            ElseIf cboExecType.SelectedValue = "NS" And cboTimeType.SelectedValue = "T" Then
                If chkDetail.Checked Then
                    'Nếu là Màn hình nhập lệnh Advanced thì tự động đẩy lệnh luôn không cần Officer duyệt
                    LoadScreen(gc_OD_PLACENORMALSELLORDER_ADVANCED)
                    v_strTxMsg = BuildXMLTxMsg(gc_MsgTypeTrans, gc_IsLocalMsg, gc_OD_PLACENORMALSELLORDER_ADVANCED, Me.BranchId, Me.TellerId, Me.IpAddress, Me.WsName, , , , , , , , , , , , , , , , , Me.BusDate)
                Else
                    'Nếu là lệnh mua/bán thông thường thì tự động đẩy lệnh luôn & ký quỹ.
                    LoadScreen(gc_OD_PLACENORMALSELLORDER)
                    v_strTxMsg = BuildXMLTxMsg(gc_MsgTypeTrans, gc_IsLocalMsg, gc_OD_PLACENORMALSELLORDER, Me.BranchId, Me.TellerId, Me.IpAddress, Me.WsName, , , , , , , , , , , , , , , , , Me.BusDate)
                End If
            Else
                'Nếu là lệnh khác thì tạo giao dịch 8870
                LoadScreen(gc_OD_PLACEORDER)
                v_strTxMsg = BuildXMLTxMsg(gc_MsgTypeTrans, gc_IsLocalMsg, gc_OD_PLACEORDER, Me.BranchId, Me.TellerId, Me.IpAddress, Me.WsName, , , , , , , , , , , , , , , , , Me.BusDate)
            End If

            v_xmlDocument.LoadXml(v_strTxMsg)
            v_dataElement = v_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "fields", "")
            If mv_arrObjFields.GetLength(0) > 0 Then
                For v_intIndex = 0 To mv_arrObjFields.GetLength(0) - 1 Step 1
                    If Not mv_arrObjFields(v_intIndex) Is Nothing Then
                        v_strFLDNAME = mv_arrObjFields(v_intIndex).FieldName
                        v_strDATATYPE = mv_arrObjFields(v_intIndex).DataType
                        Select Case Trim(v_strFLDNAME)
                            Case "01" 'CODEID
                                v_strFLDVALUE = cboCODEID.SelectedValue
                            Case "02" 'ACTYPE
                                v_strFLDVALUE = v_strACTYPE
                            Case "03" 'AFACCTNO
                                v_strFLDVALUE = Trim(mskAFACCTNO.Text)
                            Case "50" 'CUSTNAME
                                v_strFLDVALUE = Trim(mv_strFULLNAME)
                            Case "05" 'CIACCTNO
                                v_strFLDVALUE = Trim(mskAFACCTNO.Text)
                            Case "06" 'SEACCTNO
                                v_strFLDVALUE = Trim(mskAFACCTNO.Text) & cboCODEID.SelectedValue
                            Case "20" 'TIMETYPE                                       
                                v_strFLDVALUE = cboTimeType.SelectedValue
                            Case "21" 'EXPDATE                                       
                                v_strFLDVALUE = dtpExpiredDate.Value
                            Case "22" 'EXECTYPE                                       
                                v_strFLDVALUE = cboExecType.SelectedValue
                            Case "23" 'NORK                                       
                                v_strFLDVALUE = IIf(chkAllorNone.Checked, "Y", "N")
                            Case "24" 'MATCHTYPE                                       
                                v_strFLDVALUE = cboMatchType.SelectedValue
                            Case "25" 'VIA                                       
                                v_strFLDVALUE = "F"
                            Case "26" 'CLEARCD                                       
                                v_strFLDVALUE = cboCalendar.SelectedValue
                            Case "27" 'PRICETYPE                                       
                                v_strFLDVALUE = cboPriceType.SelectedValue
                            Case "10" 'CLEARDAY
                                v_strFLDVALUE = txtClearingDay.Text
                            Case "11" 'QUOTEPRICE    
                                If cboPriceType.SelectedValue = "MO" Then 'Lenh ATO then
                                    v_strFLDVALUE = mv_dblCeilingPrice / mv_dblTradeUnit
                                Else
                                    v_strFLDVALUE = txtQuotePrice.Text
                                End If
                            Case "12" 'ORDERQTTY                                      
                                v_strFLDVALUE = txtQuantity.Text
                            Case "13" 'BRATIO                                      
                                'v_strFLDVALUE = txtBRATIO.Text
                                'Tính toán tỷ lệ ký quỹ của lệnh
                                If IsNumeric(mv_dblSecureBratioMin) And IsNumeric(mv_dblSecureBratioMax) _
                                     And IsNumeric(mv_dblTyp_Bratio) And IsNumeric(mv_dblAF_Bratio) Then
                                    'Lấy theo tham số mức hệ thống
                                    mv_dblSecureRatio = CDbl(mv_dblSecureBratioMin)
                                    'So sánh với tham số loại hình
                                    mv_dblSecureRatio = IIf(mv_dblSecureRatio > CDbl(mv_dblTyp_Bratio), mv_dblSecureRatio, CDbl(mv_dblTyp_Bratio))
                                    'So sánh với tham số hợp đồng
                                    mv_dblSecureRatio = IIf(mv_dblSecureRatio > CDbl(mv_dblAF_Bratio), mv_dblSecureRatio, CDbl(mv_dblAF_Bratio))
                                    'Không vượt qua Max của tham số hệ thống
                                    mv_dblSecureRatio = IIf(mv_dblSecureRatio > CDbl(mv_dblSecureBratioMax), CDbl(mv_dblSecureBratioMax), mv_dblSecureRatio)
                                Else
                                    'Mặc định là ký quỹ 100%
                                    mv_dblSecureRatio = 100
                                End If
                                v_strFLDVALUE = mv_dblSecureRatio
                            Case "14" 'LIMITPRICE
                                v_strFLDVALUE = txtLimitPrice.Text
                            Case "15" 'PARVALUE
                                v_strFLDVALUE = mv_dbdParvalue
                            Case "28" 'VOUCHER
                                v_strFLDVALUE = Trim(cboVoucher.SelectedValue)
                            Case "29" 'CONSULTANT
                                v_strFLDVALUE = Trim(cboConsultant.SelectedValue)
                            Case "04" 'ORDERID
                                v_strFLDVALUE = getOrderID()
                                Me.lblOrderID.Text = Strings.Left(v_strFLDVALUE, 4) & "." & Strings.Mid(v_strFLDVALUE, 5, 6) & "." & Strings.Right(v_strFLDVALUE, 6)
                            Case "30" 'DESC 
                                If Me.txtDescription.Text.Trim = "Orders making" Then
                                    v_strFLDVALUE = Trim(mskAFACCTNO.Text) & "." & Trim(mv_strFULLNAME) & "." & cboExecType.SelectedValue & "." & cboCODEID.Text & "." & txtQuantity.Text & "." & txtQuotePrice.Text
                                Else
                                    v_strFLDVALUE = Me.txtDescription.Text
                                End If
                            Case "50" 'SYMBOL
                                v_strFLDVALUE = cboCODEID.Text
                            Case "99" 'gia tri 100
                                v_strFLDVALUE = "100"
                            Case "98" 'TradeUnit
                                v_strFLDVALUE = mv_dblTradeUnit
                            Case "74" 'IsDisposal
                                v_strFLDVALUE = mv_strIsDisposal
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
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Function

    'Hàm này được dùng để hiển thị lại điện giao dịch trả về từ trên HOST đối với giao dịch Submit 02 lần
    Private Function DisplayConfirm(ByVal v_xmlDocument As Xml.XmlDocument) As Boolean
        Try
            Dim v_dataElement As Xml.XmlElement, v_nodetxData As Xml.XmlNode, v_ctl As Control, v_objAccount As CAccountEntry
            Dim v_strPRINTINFO, v_strPRINTNAME, v_strPRINTVALUE, v_strFLDNAME As String, i, j, v_intIndex As Integer
            'Hiển thị lại màn hình
            Me.mskAFACCTNO.Enabled = False
            Me.pnOrder.Enabled = False
            Me.lblOrderID.ForeColor = System.Drawing.Color.Red
            Return True
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Function

    Protected Overridable Function InitDialog()
        'Khởi tạo kích thước form và load resource
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        LoadResource(Me)
        DoResizeForm()
        ResetScreen(Me)

        'Khởi tạo Grid Member
        InitExternal()

        Me.mskAFACCTNO.BackColor = System.Drawing.Color.GreenYellow
        Me.mskAFACCTNO.Mask = "9999.999999"
        Me.mskAFACCTNO.MaskCharInclude = False
        'Thiết lập các thuộc tính ban đầu cho form
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strCmdSQL As String, v_strObjMsg As String
        v_strCmdSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, LSTODR FROM ALLCODE WHERE CDTYPE='OD' AND TRIM(CDNAME)='EXECTYPE' ORDER BY LSTODR"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
        v_ws.Message(v_strObjMsg)
        FillComboEx(v_strObjMsg, cboExecType, "", Me.UserLanguage)

        v_strCmdSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, LSTODR FROM ALLCODE WHERE CDTYPE='OD' AND TRIM(CDNAME)='MATCHTYPE' ORDER BY LSTODR"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
        v_ws.Message(v_strObjMsg)
        FillComboEx(v_strObjMsg, cboMatchType, "", Me.UserLanguage)

        v_strCmdSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, LSTODR FROM ALLCODE WHERE CDTYPE='OD' AND TRIM(CDNAME)='PRICETYPE' ORDER BY LSTODR"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
        v_ws.Message(v_strObjMsg)
        FillComboEx(v_strObjMsg, cboPriceType, "", Me.UserLanguage)

        v_strCmdSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, LSTODR FROM ALLCODE WHERE CDTYPE='OD' AND TRIM(CDNAME)='TIMETYPE' ORDER BY LSTODR"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
        v_ws.Message(v_strObjMsg)
        FillComboEx(v_strObjMsg, cboTimeType, "", Me.UserLanguage)

        v_strCmdSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, LSTODR FROM ALLCODE WHERE CDTYPE='OD' AND TRIM(CDNAME)='VOUCHER' ORDER BY LSTODR"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
        v_ws.Message(v_strObjMsg)
        FillComboEx(v_strObjMsg, cboVoucher, "", Me.UserLanguage)

        v_strCmdSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, LSTODR FROM ALLCODE WHERE CDTYPE='OD' AND TRIM(CDNAME)='CLEARCD' ORDER BY LSTODR"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
        v_ws.Message(v_strObjMsg)
        FillComboEx(v_strObjMsg, cboCalendar, "", Me.UserLanguage)

        v_strCmdSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, LSTODR FROM ALLCODE WHERE CDTYPE='OD' AND TRIM(CDNAME)='CONSULTANT' ORDER BY LSTODR"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
        v_ws.Message(v_strObjMsg)
        FillComboEx(v_strObjMsg, cboConsultant, "", Me.UserLanguage)

        v_strCmdSQL = "SELECT CODEID VALUE, SYMBOL DISPLAY, SYMBOL EN_DISPLAY FROM SBSECURITIES ORDER BY DISPLAY"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
        v_ws.Message(v_strObjMsg)
        FillComboEx(v_strObjMsg, cboCODEID, "", Me.UserLanguage)

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
            Me.AllowViewCF = False
            ViewOrderMessage(TxDate, TxNum)
        End If
        'Xem có cho hiển thị chi tiết hợp đồng không
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
            pnBalance.Top = CONTROL_PNL_BALANCE_TOP
            pnContractInfo.Top = CONTROL_PNL_BALANCE_TOP
            btnOK.Top = CONTROL_BUTTON_TOP - MISS_HIGHT
            btnCANCEL.Top = btnOK.Top
            lblOrderID.Top = btnOK.Top
            Me.Height = FRM_DEFAULT_HEIGHT
        End If
    End Function

    Private Sub ResetScreen(ByRef pv_ctrl As Windows.Forms.Control)
        Dim v_ctrl As Windows.Forms.Control
        For Each v_ctrl In pv_ctrl.Controls
            If TypeOf (v_ctrl) Is TextBox Then
                CType(v_ctrl, TextBox).Text = String.Empty
                CType(v_ctrl, TextBox).Enabled = True
            ElseIf TypeOf (v_ctrl) Is GroupBox Then
                ResetScreen(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is Button Then
            ElseIf TypeOf (v_ctrl) Is Panel Then
                v_ctrl.Enabled = True
                ResetScreen(v_ctrl)
            End If
        Next
        txtLimitPrice.Text = "0"
        txtBRATIO.Text = "0"
        txtTRADELIMIT.Text = "0"
        mv_strLastAFACCTNO = String.Empty
        mv_strFULLNAME = String.Empty
        Me.mskAFACCTNO.Enabled = True
        Me.ActiveControl = mskAFACCTNO
        Me.lblAFINFO.Text = String.Empty
        Me.lblCI.Text = String.Empty
        Me.lblSE.Text = String.Empty
        Me.picSignature.Text = String.Empty
        Me.lblOrderID.Text = String.Empty
        'Hiển thị mặc định cho Description
        Me.txtDescription.Text = "Orders making"
        picSignature.Image = Nothing
        MemberGrid.DataRows.Clear()
        Select Case Trim(cboPriceType.SelectedValue)
            Case "LO"
                txtQuotePrice.Enabled = True
                txtLimitPrice.Enabled = False
                txtLimitPrice.Text = "0"
            Case "MO"
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

            'Lấy thông tin chung về giao dịch
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
                            Case "BUSDATE"
                                mv_strBusDate = Trim(v_strValue)
                        End Select
                    End With
                Next
            Next
            mv_isBackDate = False 'Không cho phép sửa lại posting date

            'Lấy thông tin chi tiết các trường của giao dịch
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
                    If CDbl(v_strNValue) <> 0 Then
                        v_strDefVal = v_strNValue
                    Else
                        v_strDefVal = v_strCValue
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
                                GetAFContractInfo(v_strFLDVALUE)
                            Case "50" 'CUSTNAME
                                mv_strFULLNAME = v_strFLDVALUE
                            Case "05" 'CIACCTNO
                                'mskAFACCTNO.Text = v_strFLDVALUE
                            Case "06" 'SEACCTNO
                                'v_strFLDVALUE = Trim(mskAFACCTNO.Text) & cboCODEID.SelectedValue
                            Case "20" 'TIMETYPE                                       
                                cboTimeType.SelectedValue = v_strFLDVALUE
                            Case "21" 'EXPDATE                                       
                                dtpExpiredDate.Value = v_strFLDVALUE
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
                            Case "28" 'VOUCHER
                                cboVoucher.SelectedValue = v_strFLDVALUE
                            Case "29" 'CONSULTANT
                                cboConsultant.SelectedValue = v_strFLDVALUE
                            Case "04" 'ORDERID
                                Me.lblOrderID.Text = Strings.Left(v_strFLDVALUE, 4) & "." & Strings.Mid(v_strFLDVALUE, 5, 6) & "." & Strings.Right(v_strFLDVALUE, 6)
                            Case "30" 'DESC                                              
                                txtDescription.Text = Trim(mskAFACCTNO.Text) & "." & Trim(mv_strFULLNAME) & "." & cboExecType.SelectedValue & "." & cboCODEID.Text & "." & txtQuantity.Text & "." & txtQuotePrice.Text
                            Case "50" 'SYMBOL
                                'cboCODEID.Text = v_strFLDVALUE
                            Case "99" 'gia tri 100
                                v_strFLDVALUE = "100"
                            Case "98" 'TradeUnit
                                'v_strFLDVALUE = mv_dblTradeUnit
                        End Select
                    End If
                Next
            End If
            Dim v_ctrl As Windows.Forms.Control
            For Each v_ctrl In Me.pnOrder.Controls
                If TypeOf (v_ctrl) Is TextBox Then
                    CType(v_ctrl, TextBox).ReadOnly = True
                ElseIf TypeOf (v_ctrl) Is ComboBox Then
                    CType(v_ctrl, ComboBox).Enabled = False
                ElseIf TypeOf (v_ctrl) Is Button Then
                ElseIf TypeOf (v_ctrl) Is Panel Then
                End If
            Next
            Me.mskAFACCTNO.ReadOnly = True
            Me.btnOK.Visible = False
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
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

            Dim v_strSQL As String = "SELECT SIG.AUTOID,SIG.CUSTID,SIG.SIGNATURE FROM CFSIGN SIG WHERE  SIG.EXPDATE>=to_date('" & Me.BusDate & "','DD/MM/YYYY') AND TRIM(SIG.CUSTID)='" & pv_strCUSTID & "'"
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
            Me.VScrollBarSign.Minimum = 0
            Me.VScrollBarSign.Maximum = mv_arrSIGNATURE.Length - 1
            Me.VScrollBarSign.Value = 0
            If mv_arrSIGNATURE.Length > 0 Then
                picSignature.Image = GetImageFromString(mv_arrSIGNATURE(Me.VScrollBarSign.Value))
            Else
                picSignature.Image = Nothing
                picSignature.Refresh()
            End If
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            'MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Sub


    Private Sub GetAFContractInfo(ByVal v_strAFACCTNO As String)
        Try
            If cboCODEID.SelectedIndex >= 0 And mv_strLastAFACCTNO <> v_strAFACCTNO Then
                Dim v_strCODEID As String = Me.cboCODEID.SelectedValue
                Dim v_nodeList As Xml.XmlNodeList
                Dim v_xmlDocument As New Xml.XmlDocument
                Dim v_strValue, v_strFLDNAME, v_strTEXT As String, i, j As Integer
                Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                Dim v_strCmdSQL As String, v_strObjMsg As String
                'Lấy thông tin về khách hàng 
                v_strCmdSQL = "SELECT CF.IDCODE LICENSE,CF.CUSTID, CF.CUSTODYCD, CF.FULLNAME, CD.CDCONTENT TERM, CI.BALANCE, AF.BRATIO , AF.ACTYPE " & ControlChars.CrLf _
                    & "FROM CFMAST CF, AFMAST AF, CIMAST CI, ALLCODE CD " & ControlChars.CrLf _
                    & "WHERE TRIM(CF.CUSTID)=TRIM(AF.CUSTID) AND TRIM(AF.ACCTNO)=TRIM(CI.AFACCTNO) " & ControlChars.CrLf _
                    & "AND TRIM(CD.CDVAL)=TRIM(AF.TERMOFUSE) AND TRIM(CD.CDTYPE)='CF' AND TRIM(CD.CDNAME)='TERMOFUSE' " & ControlChars.CrLf _
                    & "AND TRIM(AF.ACCTNO)='" & v_strAFACCTNO & "'"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strCmdSQL)
                v_ws.Message(v_strObjMsg)
                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                For i = 0 To v_nodeList.Count - 1
                    v_strTEXT = String.Empty
                    For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            v_strValue = Trim(.InnerText.ToString)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME)
                                Case "ACTYPE"
                                    mv_strACTYPE = v_strValue
                                Case "FULLNAME"
                                    If Len(v_strTEXT) = 0 Then
                                        v_strTEXT = v_strValue
                                    Else
                                        v_strTEXT = v_strTEXT & ", " & v_strValue
                                    End If
                                    mv_strFULLNAME = v_strValue
                                Case "CUSTODYCD"
                                    v_strTEXT = v_strTEXT & " [" & mv_ResourceManager.GetString("CUSTODYCD") & v_strValue & "] "
                                Case "TERM"
                                    If Len(v_strTEXT) = 0 Then
                                        v_strTEXT = v_strValue
                                    Else
                                        v_strTEXT = v_strTEXT & ", " & v_strValue
                                    End If
                                Case "BALANCE"
                                    If Len(Trim(v_strValue)) = 0 Or v_strValue = "0" Then
                                        lblCI.Text = "0"
                                    Else
                                        lblCI.Text = Format(CDbl(v_strValue), "#,###.##")
                                    End If
                                    'Case "TRADE"
                                    '    If Len(Trim(v_strValue)) = 0 Or v_strValue = "0" Then
                                    '        lblSE.Text = "0"
                                    '    Else
                                    '        lblSE.Text = Format(CDbl(v_strValue), "#,###.##")
                                    '    End If
                                Case "CUSTID"
                                    mv_strCUSTID = v_strValue
                                Case "BRATIO"
                                    If Len(Trim(v_strValue)) = 0 Or v_strValue = "0" Then
                                        mv_dblAF_Bratio = 0
                                    Else
                                        mv_dblAF_Bratio = CDbl(v_strValue)
                                    End If
                            End Select
                        End With
                    Next
                    lblAFINFO.Text = v_strTEXT
                Next
                'Fill dữ liệu vào Grid
                If Len(v_strAFACCTNO) > 0 Then
                    'Lấy thông tin chữ ký
                    LoadCFSign(mv_strCUSTID)

                    'Remove các bản ghi cũ
                    MemberGrid.DataRows.Clear()
                    'Lấy thông tin về thành viên hợp đồng va thông tin về người được ủy quyền
                    v_strCmdSQL = "SELECT 0 AUTOID, 'M' TYP, CF.CUSTID, CF.IDCODE, CF.FULLNAME, CD.CDCONTENT REF, LNK.ACCTNO " & ControlChars.CrLf _
                       & "FROM CFMAST CF, CFLINK LNK, ALLCODE CD " & ControlChars.CrLf _
                       & "WHERE TRIM(CF.CUSTID)=TRIM(LNK.CUSTID) AND TRIM(LNK.LINKTYPE)=CD.CDVAL AND CD.CDTYPE='CF' AND CD.CDNAME='LINKTYPE' AND CD.CDVAL='" & gc_LINKTYPE_AUTHORIZE & "' " & ControlChars.CrLf _
                       & "AND TRIM(LNK.ACCTNO)='" & v_strAFACCTNO & "' UNION ALL " & "SELECT CFAUTH.AUTOID, 'A' TYP, CUSTID, LICENSENO IDCODE, FULLNAME, ADDRESS REF, ACCTNO FROM CFAUTH " & ControlChars.CrLf _
                    & "WHERE TRIM(ACCTNO)='" & v_strAFACCTNO & "'"

                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strCmdSQL)
                    v_ws.Message(v_strObjMsg)
                    FillDataGrid(MemberGrid, v_strObjMsg, "")

                End If
                mv_strLastAFACCTNO = v_strAFACCTNO
            End If
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

                'Lấy thông tin về khách hàng
                v_strCmdSQL = "Select SE.TRADE from SEMAST SE where SE.ACCTNO='" & Me.mskAFACCTNO.Text & v_strCODEID & "'"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strCmdSQL)
                v_ws.Message(v_strObjMsg)
                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                If v_nodeList.Count < 1 Then
                    Exit Sub
                End If
                For i = 0 To v_nodeList.Count - 1
                    For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            v_strValue = Trim(.InnerText.ToString)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME)
                                Case "TRADE"
                                    If Len(Trim(v_strValue)) = 0 Or v_strValue = "0" Then
                                        lblSE.Text = "0"
                                    Else
                                        lblSE.Text = Format(CDbl(v_strValue), "#,###.##")
                                    End If
                            End Select
                        End With
                    Next
                Next
            End If
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
            v_strCmdSQL = "SELECT SEINF.FLOORPRICE, SEINF.CEILINGPRICE,SEINF.SECUREDRATIOMAX,SEINF.SECUREDRATIOMIN, SEINF.TRADELOT," & ControlChars.CrLf _
             & "SEINF.TRADEUNIT,SE.PARVALUE,A.CDCONTENT TRADING_CYCLE  FROM SECURITIES_INFO SEINF,SBSECURITIES SE,ALLCODE A " & ControlChars.CrLf _
             & "WHERE SEINF.CODEID=SE.CODEID AND SEINF.CODEID='" & v_strCODEID & "' AND A.CDVAL=SE.TRADEPLACE AND A.CDTYPE='SA' AND A.CDNAME='TRADING_CYCLE'"
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
                            Case "FLOORPRICE"
                                v_strTEXT = v_strTEXT & " [" & mv_ResourceManager.GetString("FLOORPRICE") & v_strValue & "] "
                                mv_dblFloorPrice = CDbl(v_strValue)
                            Case "CEILINGPRICE"
                                v_strTEXT = v_strTEXT & " [" & mv_ResourceManager.GetString("CEILINGPRICE") & v_strValue & "] "
                                mv_dblCeilingPrice = CDbl(v_strValue)
                            Case "TRADELOT"
                                v_strTEXT = v_strTEXT & " [" & mv_ResourceManager.GetString("TRADELOT") & v_strValue & "] "
                                mv_dblTradeLot = CDbl(v_strValue)
                            Case "TRADEUNIT"
                                v_strTEXT = v_strTEXT & " [" & mv_ResourceManager.GetString("TRADEUNIT") & v_strValue & "] "
                                mv_dblTradeUnit = CDbl(v_strValue)
                            Case "PARVALUE"
                                mv_dbdParvalue = CDbl(v_strValue)
                            Case "TRADING_CYCLE"
                                Me.txtClearingDay.Text = v_strValue
                            Case "SECUREDRATIOMIN"
                                mv_dblSecureBratioMin = CDbl(v_strValue)
                            Case "SECUREDRATIOMAX"
                                mv_dblSecureBratioMax = CDbl(v_strValue)
                        End Select
                    End With
                Next
                Me.lblSymbolInfo.Text = v_strTEXT
            Next
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
        Try
            'Control Validate
            If Not ControlValidation() Then
                Exit Sub
            End If
            'Đã nhập thông tin trên màn hình và submit gửi lên APP-SERVER để xử lý
            If mskAFACCTNO.Enabled Then 'Submit lần đầu tiên
                'Khởi tạo điện giao dịch
                MessageData = vbNullString
                'Verify và tạo điện giao dịch
                If Not VerifyRules(v_strTxMsg) Then
                    Exit Sub
                Else
                    MessageData = v_strTxMsg
                    'Nếu giao dịch cần 02 lần SUBMIT thì Disable mskTransCode và hiển thị lại thông tin trả về
                    DisplayConfirm(v_xmlDocument)
                End If
            Else 'Submit lần thứ hai (confirm)
                'Đẩy điện giao dịch lên APP-SERVER
                v_strTxMsg = MessageData
                v_lngError = v_ws.Message(v_strTxMsg)
                If v_lngError <> ERR_SYSTEM_OK Then
                    'Thông báo lỗi
                    GetErrorFromMessage(v_strTxMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                    Cursor.Current = Cursors.Default
                    If v_lngError <> ERR_SA_CHECKER1_OVR And v_lngError <> ERR_SA_CHECKER2_OVR Then
                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, Me.Text)
                        Exit Sub
                    Else
                        'Lấy thêm nguyên nhân duyệt
                        GetReasonFromMessage(v_strTxMsg, v_strErrorMessage, Me.UserLanguage)
                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, Me.Text)
                    End If
                End If
                ResetScreen(Me)
            End If

        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub OnClose()
        Me.Dispose()
    End Sub

    Private Sub DoResizeForm()

    End Sub

    Private Function getOrderID() As String
        Dim v_strClause, v_strAutoID As String
        Dim v_int, v_intCount As Integer
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strFLDNAME, v_strVALUE As String
        'Lấy ra số tự tăng
        v_strClause = "SEQ_ODMAST"
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_wsBDS As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_strClause, "GetInventory")
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
    End Sub

    Private Function getTransBGColor(ByVal pv_intColor As Integer) As System.Drawing.Color
        Dim v_color As New System.Drawing.Color
        Select Case pv_intColor
            Case 0 'Default color
                v_color = System.Drawing.SystemColors.InactiveCaptionText
            Case 1 'Honeydew
                v_color = System.Drawing.Color.Honeydew
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
        End Select
        Return v_color
    End Function

    Private Function ControlValidation() As Boolean
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
        If Len(Me.txtQuotePrice.Text) = 0 Then
            MsgBox(mv_ResourceManager.GetString("ERR_FIELD_NULL"), MsgBoxStyle.Information, Me.Text)
            Me.ActiveControl = txtQuotePrice
            Return False
        End If
        If mv_dblTradeUnit <= 0 Or mv_dblFloorPrice <= 0 Or mv_dblCeilingPrice <= 0 Then
            MsgBox(mv_ResourceManager.GetString("ERR_SEC_INFO"), MsgBoxStyle.Information, Me.Text)
            Return False
        End If
        Return True
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

    Private Sub VScrollBarSign_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles VScrollBarSign.Scroll
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
            pnBalance.Top = CONTROL_PNL_BALANCE_TOP
            pnContractInfo.Top = CONTROL_PNL_BALANCE_TOP
            btnOK.Top = CONTROL_BUTTON_TOP - MISS_HIGHT
            btnCANCEL.Top = btnOK.Top
            lblOrderID.Top = btnOK.Top
            Me.Height = FRM_DEFAULT_HEIGHT
        End If
    End Sub
    Private Sub MemberGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MemberGrid.DoubleClick
        Try
            Dim v_strTYP, v_strCUSTID, v_strAUTOID As String
            If Not (MemberGrid.CurrentRow Is Nothing) Then
                v_strTYP = Trim(CType(MemberGrid.CurrentRow, Xceed.Grid.DataRow).Cells("TYP").Value)
                If v_strTYP = "M" Then 'Hiển thị thông tin trong CFMAST
                    v_strCUSTID = Trim(CType(MemberGrid.CurrentRow, Xceed.Grid.DataRow).Cells("CUSTID").Value)
                    Dim v_frm As New frmCFMAST_bk
                    v_frm.ExeFlag = ExecuteFlag.View
                    v_frm.UserLanguage = UserLanguage
                    v_frm.ModuleCode = "CF"
                    v_frm.ObjectName = "CF.CFMAST"
                    v_frm.TableName = "CFMAST"
                    v_frm.LocalObject = "N"
                    v_frm.Text = mv_ResourceManager.GetString("frm_CFMAST")
                    v_frm.KeyFieldName = "CUSTID"
                    v_frm.KeyFieldType = "C"
                    v_frm.KeyFieldValue = Trim(CType(MemberGrid.CurrentRow, Xceed.Grid.DataRow).Cells("CUSTID").Value)
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
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmODTransact_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitDialog()
    End Sub

    Private Sub frmODTransact_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        DoResizeForm()
    End Sub

    Private Sub frmODTransact_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Dim v_intPos As Int16, ctl As Control, strFLDNAME As String, v_intIndex As Integer
        Select Case e.KeyCode
            Case Keys.Escape
                OnClose()
            Case Keys.F5
                If Me.ActiveControl.Name = "mskAFACCTNO" Then
                    Dim frm As New frmSearch(Me.UserLanguage)
                    frm.TableName = "AFMAST"
                    frm.ModuleCode = "CF"
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
                    'Nạp thông tin tài khoản mới
                    GetAFContractInfo(ActiveControl.Text)
                End If
            Case Keys.Enter
                If Me.ActiveControl.Name = "mskAFACCTNO" Then
                    'Nạp thông tin tài khoản mới
                    If Len(Trim(ActiveControl.Text)) = 10 Then
                        GetAFContractInfo(ActiveControl.Text)
                        SendKeys.Send("{Tab}")
                        e.Handled = True
                    End If
                ElseIf Not TypeOf (Me.ActiveControl) Is Button Then
                    'Nếu là các trường của giao dịch thì chuyển đến control kế tiếp
                    SendKeys.Send("{Tab}")
                    e.Handled = True
                Else
                End If
        End Select
    End Sub
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        OnSubmit()
        Me.btnOK.Focus()
    End Sub

    Private Sub btnCANCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCANCEL.Click
        If Me.mskAFACCTNO.Enabled Then
            OnClose()
        Else
            ResetScreen(Me)
        End If
    End Sub

    Private Sub cboCODEID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCODEID.SelectedIndexChanged
        Dim v_strCodeID As String
        v_strCodeID = Me.cboCODEID.SelectedValue
        GetSecuritiesInfo(v_strCodeID)
    End Sub

    Private Sub cboExecType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboExecType.SelectedIndexChanged
        Try
            If cboExecType.SelectedIndex <> -1 Then
                Me.pnOrder.BackColor = getTransBGColor(cboExecType.SelectedIndex)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub mskAFACCTNO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mskAFACCTNO.Validating
        Try
            If Len(mskAFACCTNO.Text) = 10 Then
                'Lấy thông tin về hợp đồng
                GetAFContractInfo(mskAFACCTNO.Text)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtQuantity_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtQuantity.Validating
        If mv_dblTradeLot <= 0 Then
            MsgBox(mv_ResourceManager.GetString("ERR_SEC_INFO"), MsgBoxStyle.Information, Me.Text)
            e.Cancel = True
        End If
        If Not IsNumeric(txtQuantity.Text) Then
            MsgBox(mv_ResourceManager.GetString("QTTYISNOTNUMBER"), MsgBoxStyle.Information, Me.Text)
            e.Cancel = True
        ElseIf CDbl(txtQuantity.Text) < 0 Then
            MsgBox(mv_ResourceManager.GetString("PRICEISNOTNUMBER"), MsgBoxStyle.Information, Me.Text)
            e.Cancel = True
        Else
            If mv_dblTradeLot > 0 Then
                If CDbl(txtQuantity.Text) Mod mv_dblTradeLot > 0 Then
                    MsgBox(mv_ResourceManager.GetString("TRADELOTINVALID"), MsgBoxStyle.Information, Me.Text)
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub txtQuotePrice_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtQuotePrice.Validating
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
        Else
            If Trim(Me.cboPriceType.SelectedValue) = "LO" Then
                If CDbl(txtQuotePrice.Text) * mv_dblTradeUnit > mv_dblCeilingPrice Then
                    MsgBox(mv_ResourceManager.GetString("CEILINGINVALID"), MsgBoxStyle.Information, Me.Text)
                    e.Cancel = True
                ElseIf CDbl(txtQuotePrice.Text) * mv_dblTradeUnit < mv_dblFloorPrice Then
                    MsgBox(mv_ResourceManager.GetString("FLOORINVALID"), MsgBoxStyle.Information, Me.Text)
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub txtLimitPrice_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLimitPrice.Validating
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
        ElseIf CDbl(txtClearingDay.Text) < 0 Then
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
        Select Case Trim(cboPriceType.SelectedValue)
            Case "LO"
                txtQuotePrice.Enabled = True
                txtLimitPrice.Enabled = False
                txtLimitPrice.Text = "0"
            Case "MO"
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
    End Sub

    Private Sub cboTimeType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTimeType.SelectedIndexChanged
        Select Case Trim(cboTimeType.SelectedValue)
            Case "G"
                Me.dtpExpiredDate.Enabled = True
            Case "T"
                Me.dtpExpiredDate.Enabled = False
                Me.dtpExpiredDate.Value = Me.BusDate
            Case "I"
                Me.dtpExpiredDate.Enabled = False
                Me.dtpExpiredDate.Value = Me.BusDate
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
    End Sub
#End Region

End Class
