Imports System.Windows.Forms
Imports Xceed.SmartUI.Controls
Imports CommonLibrary
Imports System.Collections
Imports AppCore
Imports AppCore.modCoreLib
Imports System.IO

Public Class frmODReceiveHO
    Inherits System.Windows.Forms.Form


#Region " Windows Form Designer generated code "

    Public Sub New(ByVal pv_strLanguage As String)
        MyBase.New()

        InitializeComponent()
        mv_strLanguage = pv_strLanguage
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        InitializeGrid()
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
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCANCEL As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpgManual As System.Windows.Forms.TabPage
    Friend WithEvents pnOrder As System.Windows.Forms.Panel
    Friend WithEvents lblPrice As System.Windows.Forms.Label
    Friend WithEvents lblQuantity As System.Windows.Forms.Label
    Friend WithEvents txtPrice As System.Windows.Forms.TextBox
    Friend WithEvents txtQuantity As System.Windows.Forms.TextBox
    Friend WithEvents txtExPrice As System.Windows.Forms.TextBox
    Friend WithEvents txtExQuantity As System.Windows.Forms.TextBox
    Friend WithEvents lblExQuantity As System.Windows.Forms.Label
    Friend WithEvents txtRefOrderID As System.Windows.Forms.TextBox
    Friend WithEvents lblRefOrderID As System.Windows.Forms.Label
    Friend WithEvents txtREFCUSTCD As System.Windows.Forms.TextBox
    Friend WithEvents lblREFCUSTCD As System.Windows.Forms.Label
    Friend WithEvents cboClearCD As AppCore.ComboBoxEx
    Friend WithEvents lblClearCD As System.Windows.Forms.Label
    Friend WithEvents txtClearDay As System.Windows.Forms.TextBox
    Friend WithEvents lblClearDay As System.Windows.Forms.Label
    Friend WithEvents pnODReceiveInfo As System.Windows.Forms.Panel
    Friend WithEvents chkAORN As System.Windows.Forms.CheckBox
    Friend WithEvents cboNORP As AppCore.ComboBoxEx
    Friend WithEvents lblNORP As System.Windows.Forms.Label
    Friend WithEvents lblBORS As System.Windows.Forms.Label
    Friend WithEvents cboBORS As AppCore.ComboBoxEx
    Friend WithEvents lblExPrice As System.Windows.Forms.Label
    Friend WithEvents txtREMAINQTTY As System.Windows.Forms.TextBox
    Friend WithEvents lblREMAINQTTY As System.Windows.Forms.Label
    Friend WithEvents txtEXECQTTY As System.Windows.Forms.TextBox
    Friend WithEvents lblEXECQTTY As System.Windows.Forms.Label
    Friend WithEvents tpgAutomatic As System.Windows.Forms.TabPage
    Friend WithEvents pnAutoInfo As System.Windows.Forms.Panel
    Friend WithEvents btnReceiveAll As System.Windows.Forms.Button
    Friend WithEvents btnMatch As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cboCODEID As AppCore.ComboBoxEx
    Friend WithEvents lblSymbol As System.Windows.Forms.Label
    Friend WithEvents cboSCODEID As AppCore.ComboBoxEx
    Friend WithEvents lblSSymbol As System.Windows.Forms.Label
    Friend WithEvents lblSBORS As System.Windows.Forms.Label
    Friend WithEvents cboSBORS As AppCore.ComboBoxEx
    Friend WithEvents btnReceive As System.Windows.Forms.Button
    Friend WithEvents lblDesc As System.Windows.Forms.Label
    Friend WithEvents btnViewTradingResult As System.Windows.Forms.Button
    Friend WithEvents txtTxDesc As System.Windows.Forms.TextBox
    Friend WithEvents lblTxDesc As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.pnlTitle = New System.Windows.Forms.Panel
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCANCEL = New System.Windows.Forms.Button
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tpgManual = New System.Windows.Forms.TabPage
        Me.lblDesc = New System.Windows.Forms.Label
        Me.btnReceive = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblSBORS = New System.Windows.Forms.Label
        Me.cboSBORS = New AppCore.ComboBoxEx
        Me.cboSCODEID = New AppCore.ComboBoxEx
        Me.lblSSymbol = New System.Windows.Forms.Label
        Me.pnODReceiveInfo = New System.Windows.Forms.Panel
        Me.pnOrder = New System.Windows.Forms.Panel
        Me.lblTxDesc = New System.Windows.Forms.Label
        Me.txtTxDesc = New System.Windows.Forms.TextBox
        Me.btnViewTradingResult = New System.Windows.Forms.Button
        Me.txtEXECQTTY = New System.Windows.Forms.TextBox
        Me.lblEXECQTTY = New System.Windows.Forms.Label
        Me.txtREMAINQTTY = New System.Windows.Forms.TextBox
        Me.lblREMAINQTTY = New System.Windows.Forms.Label
        Me.chkAORN = New System.Windows.Forms.CheckBox
        Me.txtClearDay = New System.Windows.Forms.TextBox
        Me.lblClearDay = New System.Windows.Forms.Label
        Me.cboClearCD = New AppCore.ComboBoxEx
        Me.lblClearCD = New System.Windows.Forms.Label
        Me.txtREFCUSTCD = New System.Windows.Forms.TextBox
        Me.lblREFCUSTCD = New System.Windows.Forms.Label
        Me.txtRefOrderID = New System.Windows.Forms.TextBox
        Me.lblRefOrderID = New System.Windows.Forms.Label
        Me.txtExPrice = New System.Windows.Forms.TextBox
        Me.lblExPrice = New System.Windows.Forms.Label
        Me.txtExQuantity = New System.Windows.Forms.TextBox
        Me.lblExQuantity = New System.Windows.Forms.Label
        Me.cboCODEID = New AppCore.ComboBoxEx
        Me.txtPrice = New System.Windows.Forms.TextBox
        Me.lblPrice = New System.Windows.Forms.Label
        Me.txtQuantity = New System.Windows.Forms.TextBox
        Me.lblQuantity = New System.Windows.Forms.Label
        Me.lblSymbol = New System.Windows.Forms.Label
        Me.cboNORP = New AppCore.ComboBoxEx
        Me.lblNORP = New System.Windows.Forms.Label
        Me.lblBORS = New System.Windows.Forms.Label
        Me.cboBORS = New AppCore.ComboBoxEx
        Me.tpgAutomatic = New System.Windows.Forms.TabPage
        Me.btnMatch = New System.Windows.Forms.Button
        Me.pnAutoInfo = New System.Windows.Forms.Panel
        Me.btnReceiveAll = New System.Windows.Forms.Button
        Me.TabControl1.SuspendLayout()
        Me.tpgManual.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnOrder.SuspendLayout()
        Me.tpgAutomatic.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlTitle
        '
        Me.pnlTitle.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTitle.Location = New System.Drawing.Point(0, 0)
        Me.pnlTitle.Name = "pnlTitle"
        Me.pnlTitle.Size = New System.Drawing.Size(794, 50)
        Me.pnlTitle.TabIndex = 0
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(616, 544)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(80, 24)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "btnOK"
        '
        'btnCANCEL
        '
        Me.btnCANCEL.Location = New System.Drawing.Point(704, 544)
        Me.btnCANCEL.Name = "btnCANCEL"
        Me.btnCANCEL.Size = New System.Drawing.Size(80, 24)
        Me.btnCANCEL.TabIndex = 2
        Me.btnCANCEL.Text = "btnCANCEL"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tpgManual)
        Me.TabControl1.Controls.Add(Me.tpgAutomatic)
        Me.TabControl1.Location = New System.Drawing.Point(8, 56)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(776, 480)
        Me.TabControl1.TabIndex = 0
        '
        'tpgManual
        '
        Me.tpgManual.Controls.Add(Me.lblDesc)
        Me.tpgManual.Controls.Add(Me.btnReceive)
        Me.tpgManual.Controls.Add(Me.Panel1)
        Me.tpgManual.Controls.Add(Me.pnODReceiveInfo)
        Me.tpgManual.Controls.Add(Me.pnOrder)
        Me.tpgManual.Location = New System.Drawing.Point(4, 22)
        Me.tpgManual.Name = "tpgManual"
        Me.tpgManual.Size = New System.Drawing.Size(768, 454)
        Me.tpgManual.TabIndex = 0
        Me.tpgManual.Text = "Manual"
        '
        'lblDesc
        '
        Me.lblDesc.AutoSize = True
        Me.lblDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDesc.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblDesc.Location = New System.Drawing.Point(7, 117)
        Me.lblDesc.Name = "lblDesc"
        Me.lblDesc.Size = New System.Drawing.Size(50, 19)
        Me.lblDesc.TabIndex = 7
        Me.lblDesc.Tag = "lblDesc"
        Me.lblDesc.Text = "lblDesc"
        '
        'btnReceive
        '
        Me.btnReceive.Location = New System.Drawing.Point(512, 8)
        Me.btnReceive.Name = "btnReceive"
        Me.btnReceive.Size = New System.Drawing.Size(112, 24)
        Me.btnReceive.TabIndex = 6
        Me.btnReceive.Text = "btnReceive"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lblSBORS)
        Me.Panel1.Controls.Add(Me.cboSBORS)
        Me.Panel1.Controls.Add(Me.cboSCODEID)
        Me.Panel1.Controls.Add(Me.lblSSymbol)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(416, 40)
        Me.Panel1.TabIndex = 1
        '
        'lblSBORS
        '
        Me.lblSBORS.Location = New System.Drawing.Point(215, 8)
        Me.lblSBORS.Name = "lblSBORS"
        Me.lblSBORS.Size = New System.Drawing.Size(72, 21)
        Me.lblSBORS.TabIndex = 26
        Me.lblSBORS.Tag = "BORS"
        Me.lblSBORS.Text = "lblSBORS"
        '
        'cboSBORS
        '
        Me.cboSBORS.DisplayMember = "DISPLAY"
        Me.cboSBORS.Location = New System.Drawing.Point(298, 8)
        Me.cboSBORS.Name = "cboSBORS"
        Me.cboSBORS.Size = New System.Drawing.Size(104, 21)
        Me.cboSBORS.TabIndex = 25
        Me.cboSBORS.Tag = "24"
        Me.cboSBORS.ValueMember = "VALUE"
        '
        'cboSCODEID
        '
        Me.cboSCODEID.DisplayMember = "DISPLAY"
        Me.cboSCODEID.ItemHeight = 13
        Me.cboSCODEID.Location = New System.Drawing.Point(93, 8)
        Me.cboSCODEID.Name = "cboSCODEID"
        Me.cboSCODEID.Size = New System.Drawing.Size(91, 21)
        Me.cboSCODEID.TabIndex = 23
        Me.cboSCODEID.Tag = "01"
        Me.cboSCODEID.ValueMember = "VALUE"
        '
        'lblSSymbol
        '
        Me.lblSSymbol.Location = New System.Drawing.Point(8, 8)
        Me.lblSSymbol.Name = "lblSSymbol"
        Me.lblSSymbol.Size = New System.Drawing.Size(72, 21)
        Me.lblSSymbol.TabIndex = 24
        Me.lblSSymbol.Tag = "lblSSymbol"
        Me.lblSSymbol.Text = "lblSSymbol"
        '
        'pnODReceiveInfo
        '
        Me.pnODReceiveInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnODReceiveInfo.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnODReceiveInfo.Location = New System.Drawing.Point(0, 142)
        Me.pnODReceiveInfo.Name = "pnODReceiveInfo"
        Me.pnODReceiveInfo.Size = New System.Drawing.Size(768, 312)
        Me.pnODReceiveInfo.TabIndex = 0
        '
        'pnOrder
        '
        Me.pnOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnOrder.Controls.Add(Me.lblTxDesc)
        Me.pnOrder.Controls.Add(Me.txtTxDesc)
        Me.pnOrder.Controls.Add(Me.btnViewTradingResult)
        Me.pnOrder.Controls.Add(Me.txtEXECQTTY)
        Me.pnOrder.Controls.Add(Me.lblEXECQTTY)
        Me.pnOrder.Controls.Add(Me.txtREMAINQTTY)
        Me.pnOrder.Controls.Add(Me.lblREMAINQTTY)
        Me.pnOrder.Controls.Add(Me.chkAORN)
        Me.pnOrder.Controls.Add(Me.txtClearDay)
        Me.pnOrder.Controls.Add(Me.lblClearDay)
        Me.pnOrder.Controls.Add(Me.cboClearCD)
        Me.pnOrder.Controls.Add(Me.lblClearCD)
        Me.pnOrder.Controls.Add(Me.txtREFCUSTCD)
        Me.pnOrder.Controls.Add(Me.lblREFCUSTCD)
        Me.pnOrder.Controls.Add(Me.txtRefOrderID)
        Me.pnOrder.Controls.Add(Me.lblRefOrderID)
        Me.pnOrder.Controls.Add(Me.txtExPrice)
        Me.pnOrder.Controls.Add(Me.lblExPrice)
        Me.pnOrder.Controls.Add(Me.txtExQuantity)
        Me.pnOrder.Controls.Add(Me.lblExQuantity)
        Me.pnOrder.Controls.Add(Me.cboCODEID)
        Me.pnOrder.Controls.Add(Me.txtPrice)
        Me.pnOrder.Controls.Add(Me.lblPrice)
        Me.pnOrder.Controls.Add(Me.txtQuantity)
        Me.pnOrder.Controls.Add(Me.lblQuantity)
        Me.pnOrder.Controls.Add(Me.lblSymbol)
        Me.pnOrder.Controls.Add(Me.cboNORP)
        Me.pnOrder.Controls.Add(Me.lblNORP)
        Me.pnOrder.Controls.Add(Me.lblBORS)
        Me.pnOrder.Controls.Add(Me.cboBORS)
        Me.pnOrder.Location = New System.Drawing.Point(0, 43)
        Me.pnOrder.Name = "pnOrder"
        Me.pnOrder.Size = New System.Drawing.Size(768, 69)
        Me.pnOrder.TabIndex = 0
        '
        'lblTxDesc
        '
        Me.lblTxDesc.Location = New System.Drawing.Point(8, 39)
        Me.lblTxDesc.Name = "lblTxDesc"
        Me.lblTxDesc.Size = New System.Drawing.Size(80, 16)
        Me.lblTxDesc.TabIndex = 45
        Me.lblTxDesc.Text = "lblTxDesc"
        '
        'txtTxDesc
        '
        Me.txtTxDesc.Location = New System.Drawing.Point(99, 36)
        Me.txtTxDesc.Name = "txtTxDesc"
        Me.txtTxDesc.Size = New System.Drawing.Size(653, 20)
        Me.txtTxDesc.TabIndex = 44
        Me.txtTxDesc.Text = "txtTxDesc"
        '
        'btnViewTradingResult
        '
        Me.btnViewTradingResult.BackColor = System.Drawing.Color.SkyBlue
        Me.btnViewTradingResult.ForeColor = System.Drawing.Color.Red
        Me.btnViewTradingResult.Location = New System.Drawing.Point(390, 5)
        Me.btnViewTradingResult.Name = "btnViewTradingResult"
        Me.btnViewTradingResult.Size = New System.Drawing.Size(25, 25)
        Me.btnViewTradingResult.TabIndex = 43
        Me.btnViewTradingResult.Text = ">>"
        '
        'txtEXECQTTY
        '
        Me.txtEXECQTTY.Location = New System.Drawing.Point(392, 296)
        Me.txtEXECQTTY.Name = "txtEXECQTTY"
        Me.txtEXECQTTY.Size = New System.Drawing.Size(128, 20)
        Me.txtEXECQTTY.TabIndex = 12
        Me.txtEXECQTTY.Tag = "12"
        Me.txtEXECQTTY.Text = "txtEXECQTTY"
        '
        'lblEXECQTTY
        '
        Me.lblEXECQTTY.Location = New System.Drawing.Point(288, 296)
        Me.lblEXECQTTY.Name = "lblEXECQTTY"
        Me.lblEXECQTTY.Size = New System.Drawing.Size(104, 21)
        Me.lblEXECQTTY.TabIndex = 42
        Me.lblEXECQTTY.Text = "lblEXECQTTY"
        '
        'txtREMAINQTTY
        '
        Me.txtREMAINQTTY.Location = New System.Drawing.Point(152, 136)
        Me.txtREMAINQTTY.Name = "txtREMAINQTTY"
        Me.txtREMAINQTTY.Size = New System.Drawing.Size(128, 20)
        Me.txtREMAINQTTY.TabIndex = 10
        Me.txtREMAINQTTY.Tag = "12"
        Me.txtREMAINQTTY.Text = "txtREMAINQTTY"
        '
        'lblREMAINQTTY
        '
        Me.lblREMAINQTTY.Location = New System.Drawing.Point(32, 136)
        Me.lblREMAINQTTY.Name = "lblREMAINQTTY"
        Me.lblREMAINQTTY.Size = New System.Drawing.Size(104, 21)
        Me.lblREMAINQTTY.TabIndex = 40
        Me.lblREMAINQTTY.Text = "lblREMAINQTTY"
        '
        'chkAORN
        '
        Me.chkAORN.Location = New System.Drawing.Point(536, 296)
        Me.chkAORN.Name = "chkAORN"
        Me.chkAORN.Size = New System.Drawing.Size(80, 24)
        Me.chkAORN.TabIndex = 39
        Me.chkAORN.Text = "chkAORN"
        '
        'txtClearDay
        '
        Me.txtClearDay.Location = New System.Drawing.Point(136, 296)
        Me.txtClearDay.Name = "txtClearDay"
        Me.txtClearDay.Size = New System.Drawing.Size(128, 20)
        Me.txtClearDay.TabIndex = 11
        Me.txtClearDay.Tag = "12"
        Me.txtClearDay.Text = "txtClearDay"
        '
        'lblClearDay
        '
        Me.lblClearDay.Location = New System.Drawing.Point(16, 296)
        Me.lblClearDay.Name = "lblClearDay"
        Me.lblClearDay.Size = New System.Drawing.Size(112, 21)
        Me.lblClearDay.TabIndex = 36
        Me.lblClearDay.Text = "lblClearDay"
        '
        'cboClearCD
        '
        Me.cboClearCD.DisplayMember = "DISPLAY"
        Me.cboClearCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboClearCD.Location = New System.Drawing.Point(136, 264)
        Me.cboClearCD.Name = "cboClearCD"
        Me.cboClearCD.Size = New System.Drawing.Size(128, 21)
        Me.cboClearCD.TabIndex = 9
        Me.cboClearCD.Tag = "01"
        Me.cboClearCD.ValueMember = "VALUE"
        '
        'lblClearCD
        '
        Me.lblClearCD.Location = New System.Drawing.Point(16, 264)
        Me.lblClearCD.Name = "lblClearCD"
        Me.lblClearCD.Size = New System.Drawing.Size(112, 21)
        Me.lblClearCD.TabIndex = 34
        Me.lblClearCD.Text = "lblClearCD"
        '
        'txtREFCUSTCD
        '
        Me.txtREFCUSTCD.Location = New System.Drawing.Point(289, 8)
        Me.txtREFCUSTCD.Name = "txtREFCUSTCD"
        Me.txtREFCUSTCD.Size = New System.Drawing.Size(96, 20)
        Me.txtREFCUSTCD.TabIndex = 2
        Me.txtREFCUSTCD.Tag = "12"
        Me.txtREFCUSTCD.Text = "txtREFCUSTCD"
        '
        'lblREFCUSTCD
        '
        Me.lblREFCUSTCD.Location = New System.Drawing.Point(192, 8)
        Me.lblREFCUSTCD.Name = "lblREFCUSTCD"
        Me.lblREFCUSTCD.Size = New System.Drawing.Size(96, 21)
        Me.lblREFCUSTCD.TabIndex = 32
        Me.lblREFCUSTCD.Text = "lblREFCUSTCD"
        '
        'txtRefOrderID
        '
        Me.txtRefOrderID.Location = New System.Drawing.Point(99, 8)
        Me.txtRefOrderID.Name = "txtRefOrderID"
        Me.txtRefOrderID.Size = New System.Drawing.Size(85, 20)
        Me.txtRefOrderID.TabIndex = 1
        Me.txtRefOrderID.Tag = "12"
        Me.txtRefOrderID.Text = "txtRefOrderID"
        '
        'lblRefOrderID
        '
        Me.lblRefOrderID.Location = New System.Drawing.Point(8, 8)
        Me.lblRefOrderID.Name = "lblRefOrderID"
        Me.lblRefOrderID.Size = New System.Drawing.Size(88, 21)
        Me.lblRefOrderID.TabIndex = 30
        Me.lblRefOrderID.Text = "lblRefOrderID"
        '
        'txtExPrice
        '
        Me.txtExPrice.Location = New System.Drawing.Point(624, 232)
        Me.txtExPrice.Name = "txtExPrice"
        Me.txtExPrice.Size = New System.Drawing.Size(120, 20)
        Me.txtExPrice.TabIndex = 8
        Me.txtExPrice.Tag = "11"
        Me.txtExPrice.Text = "txtExPrice"
        '
        'lblExPrice
        '
        Me.lblExPrice.Location = New System.Drawing.Point(520, 232)
        Me.lblExPrice.Name = "lblExPrice"
        Me.lblExPrice.Size = New System.Drawing.Size(104, 21)
        Me.lblExPrice.TabIndex = 28
        Me.lblExPrice.Text = "lblExPrice"
        '
        'txtExQuantity
        '
        Me.txtExQuantity.Location = New System.Drawing.Point(376, 232)
        Me.txtExQuantity.Name = "txtExQuantity"
        Me.txtExQuantity.Size = New System.Drawing.Size(128, 20)
        Me.txtExQuantity.TabIndex = 7
        Me.txtExQuantity.Tag = "12"
        Me.txtExQuantity.Text = "txtExQuantity"
        '
        'lblExQuantity
        '
        Me.lblExQuantity.Location = New System.Drawing.Point(272, 232)
        Me.lblExQuantity.Name = "lblExQuantity"
        Me.lblExQuantity.Size = New System.Drawing.Size(104, 21)
        Me.lblExQuantity.TabIndex = 26
        Me.lblExQuantity.Text = "lblExQuantity"
        '
        'cboCODEID
        '
        Me.cboCODEID.DisplayMember = "DISPLAY"
        Me.cboCODEID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCODEID.ItemHeight = 13
        Me.cboCODEID.Location = New System.Drawing.Point(432, 136)
        Me.cboCODEID.Name = "cboCODEID"
        Me.cboCODEID.Size = New System.Drawing.Size(128, 21)
        Me.cboCODEID.TabIndex = 6
        Me.cboCODEID.Tag = "01"
        Me.cboCODEID.ValueMember = "VALUE"
        '
        'txtPrice
        '
        Me.txtPrice.Location = New System.Drawing.Point(664, 8)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(88, 20)
        Me.txtPrice.TabIndex = 5
        Me.txtPrice.Tag = "11"
        Me.txtPrice.Text = "txtPrice"
        '
        'lblPrice
        '
        Me.lblPrice.Location = New System.Drawing.Point(608, 8)
        Me.lblPrice.Name = "lblPrice"
        Me.lblPrice.Size = New System.Drawing.Size(48, 21)
        Me.lblPrice.TabIndex = 24
        Me.lblPrice.Text = "lblPrice"
        '
        'txtQuantity
        '
        Me.txtQuantity.Location = New System.Drawing.Point(520, 8)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(72, 20)
        Me.txtQuantity.TabIndex = 4
        Me.txtQuantity.Tag = "12"
        Me.txtQuantity.Text = "txtQuantity"
        '
        'lblQuantity
        '
        Me.lblQuantity.Location = New System.Drawing.Point(440, 8)
        Me.lblQuantity.Name = "lblQuantity"
        Me.lblQuantity.Size = New System.Drawing.Size(80, 21)
        Me.lblQuantity.TabIndex = 19
        Me.lblQuantity.Text = "lblQuantity"
        '
        'lblSymbol
        '
        Me.lblSymbol.Location = New System.Drawing.Point(312, 136)
        Me.lblSymbol.Name = "lblSymbol"
        Me.lblSymbol.Size = New System.Drawing.Size(112, 21)
        Me.lblSymbol.TabIndex = 22
        Me.lblSymbol.Text = "lblSymbol"
        '
        'cboNORP
        '
        Me.cboNORP.DisplayMember = "DISPLAY"
        Me.cboNORP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNORP.Location = New System.Drawing.Point(400, 264)
        Me.cboNORP.Name = "cboNORP"
        Me.cboNORP.Size = New System.Drawing.Size(128, 21)
        Me.cboNORP.TabIndex = 3
        Me.cboNORP.Tag = "22"
        Me.cboNORP.ValueMember = "VALUE"
        '
        'lblNORP
        '
        Me.lblNORP.Location = New System.Drawing.Point(280, 264)
        Me.lblNORP.Name = "lblNORP"
        Me.lblNORP.Size = New System.Drawing.Size(112, 21)
        Me.lblNORP.TabIndex = 13
        Me.lblNORP.Tag = "EXECTYPE"
        Me.lblNORP.Text = "lblNORP"
        '
        'lblBORS
        '
        Me.lblBORS.Location = New System.Drawing.Point(16, 232)
        Me.lblBORS.Name = "lblBORS"
        Me.lblBORS.Size = New System.Drawing.Size(112, 21)
        Me.lblBORS.TabIndex = 17
        Me.lblBORS.Tag = "BORS"
        Me.lblBORS.Text = "lblBORS"
        '
        'cboBORS
        '
        Me.cboBORS.DisplayMember = "DISPLAY"
        Me.cboBORS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBORS.Location = New System.Drawing.Point(136, 232)
        Me.cboBORS.Name = "cboBORS"
        Me.cboBORS.Size = New System.Drawing.Size(128, 21)
        Me.cboBORS.TabIndex = 0
        Me.cboBORS.Tag = "24"
        Me.cboBORS.ValueMember = "VALUE"
        '
        'tpgAutomatic
        '
        Me.tpgAutomatic.Controls.Add(Me.btnMatch)
        Me.tpgAutomatic.Controls.Add(Me.pnAutoInfo)
        Me.tpgAutomatic.Controls.Add(Me.btnReceiveAll)
        Me.tpgAutomatic.Location = New System.Drawing.Point(4, 22)
        Me.tpgAutomatic.Name = "tpgAutomatic"
        Me.tpgAutomatic.Size = New System.Drawing.Size(768, 454)
        Me.tpgAutomatic.TabIndex = 1
        Me.tpgAutomatic.Text = "Automatic"
        '
        'btnMatch
        '
        Me.btnMatch.Location = New System.Drawing.Point(560, 424)
        Me.btnMatch.Name = "btnMatch"
        Me.btnMatch.Size = New System.Drawing.Size(88, 23)
        Me.btnMatch.TabIndex = 6
        Me.btnMatch.Text = "btnMatch"
        '
        'pnAutoInfo
        '
        Me.pnAutoInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnAutoInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnAutoInfo.Location = New System.Drawing.Point(0, 0)
        Me.pnAutoInfo.Name = "pnAutoInfo"
        Me.pnAutoInfo.Size = New System.Drawing.Size(768, 416)
        Me.pnAutoInfo.TabIndex = 2
        '
        'btnReceiveAll
        '
        Me.btnReceiveAll.Location = New System.Drawing.Point(672, 424)
        Me.btnReceiveAll.Name = "btnReceiveAll"
        Me.btnReceiveAll.Size = New System.Drawing.Size(88, 24)
        Me.btnReceiveAll.TabIndex = 5
        Me.btnReceiveAll.Text = "btnReceiveAll"
        '
        'frmODReceiveHO
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.ClientSize = New System.Drawing.Size(794, 575)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCANCEL)
        Me.Controls.Add(Me.pnlTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Name = "frmODReceiveHO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmODReceiveHO"
        Me.TabControl1.ResumeLayout(False)
        Me.tpgManual.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.pnOrder.ResumeLayout(False)
        Me.tpgAutomatic.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Declare constant and variables "
    Const c_ResourceManager = "_DIRECT.frmODReceiveHO-"
    Public ODReceiveGrid As GridEx
    Public ODAutoReceiveGrid As GridEx
    Dim v_objTrading_result As New TRADING_RESULTHO
    Dim mv_strTR_CustodyCD As String = String.Empty
    Dim mv_dblTR_Price As Double = 0
    Dim mv_strTR_Symbol As String = String.Empty
    Dim mv_strTR_RefOrder As String = String.Empty
    Dim mv_strTR_RefCustodycd As String = String.Empty
    Dim mv_strTR_ConfirmNo As String = String.Empty
    Dim mv_dblTR_QTTY As Double = 0

    Dim mv_strORGORDERID, mv_strCODEID, mv_strSYMBOL, mv_strCUSTODYCD, mv_strBORS, mv_strNORP, mv_strAORN, mv_strPRICE, mv_strQTTY As String
    Dim mv_strCLEARDAY, mv_strSECUREDRATIO, mv_strCONFIRM_NO, mv_strMATCH_DATE, mv_strCLEARCD, mv_strSEACCTNO, mv_strCIACCTNO, mv_strAFACCTNO, mv_strPRICETYPE, mv_strTRADELOT As String
    Dim mv_strEXPRICE, mv_strEXQTTY, mv_strREMAINQTTY, mv_strEXECQTTY, mv_strB_ORDER_NO, mv_strS_ORDER_NO, mv_strB_ACCOUNT_NO, mv_strS_ACCOUNT_NO As String
    Dim mv_strREFCUSTCD, mv_strREFORDERID, mv_strTRADEUNIT As String
    Dim mv_strLastAFACCTNO As String = String.Empty
    Dim mv_strFloorPrice As String
    Dim mv_strCeilingPrice As String
    Dim mv_dblTradeLot As Double
    Dim mv_dblTradeUnit As Double
    Dim mv_arrRusult() As TRADING_RESULTHO
    Dim mv_intResult As Integer
    Dim mv_arrOOD() As OODHO
    Dim mv_intOOD As Integer
    Dim mv_arrMatchingOrder() As MatchingOrderHO
    Dim mv_intMatchingOrder As Integer
    Private mv_strTradePlace As String
    Private mv_strCLAUSE As String = String.Empty
    Private mv_str_SQLCMD As String = String.Empty
    Private mv_strSQLCMD As String = String.Empty
    Private mv_strAUTOSQLCMD As String = String.Empty
    Private mv_str_CLAUSE As String = String.Empty
    Private mv_strObjectName As String
    Private mv_strTltxcd As String
    Private mv_strModuleCode As String
    Private mv_strLanguage As String
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
    Private mv_strBusDate As String
    Private mv_strTxDate As String = String.Empty
    Private mv_strTxNum As String = String.Empty

    'Khai bao cac bien cho khop lenh bang tay
    Public mv_RefOrderID As String = String.Empty
    Public mv_RefCustCD As String = String.Empty
    Public mv_ConfirmNo As String = String.Empty
    Public mv_dblPrice As Double = 0
    Public mv_dblQuantity As Double = 0

    Private Const CONTROL_PNL_CONTRACT_TOP = 200
    Private Const CONTROL_BUTTON_TOP = 400
    Private Const FRM_DEFAULT_HEIGHT = 260
    Private Const FRM_EXTEND_HEIGHT = 460
#End Region

#Region " Properties "
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
#End Region

#Region " Other Methods "
    Private Sub InitializeGrid()
        'Khởi tạo Grid Receive
        ODReceiveGrid = New GridEx

        Dim v_grODReceiveGrid As Xceed.Grid.GroupByRow
        v_grODReceiveGrid = New Xceed.Grid.GroupByRow
        v_grODReceiveGrid.NoGroupText = mv_ResourceManager.GetString("GridEx.GroupByRow")

        v_grODReceiveGrid.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(127, Byte), CType(123, Byte), CType(122, Byte))
        v_grODReceiveGrid.CellBackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_grODReceiveGrid.CellFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)

        Dim v_cmrODReceiveGrid As New Xceed.Grid.ColumnManagerRow
        v_cmrODReceiveGrid.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrODReceiveGrid.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)


        ODReceiveGrid.FixedHeaderRows.Add(v_grODReceiveGrid)
        ODReceiveGrid.FixedHeaderRows.Add(v_cmrODReceiveGrid)

        Dim v_frODReceiveGrid As Xceed.Grid.TextRow
        v_frODReceiveGrid = New Xceed.Grid.TextRow(mv_ResourceManager.GetString("GridEx.FooterRow"))
        v_frODReceiveGrid.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_frODReceiveGrid.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic)

        ODReceiveGrid.FixedFooterRows.Clear()
        ODReceiveGrid.FixedFooterRows.Add(v_frODReceiveGrid)


        ODReceiveGrid.Columns.Add(New Xceed.Grid.Column("ORGORDERID", GetType(System.String)))
        ODReceiveGrid.Columns.Add(New Xceed.Grid.Column("CODEID", GetType(System.String)))
        ODReceiveGrid.Columns.Add(New Xceed.Grid.Column("SYMBOL", GetType(System.String)))
        'ODReceiveGrid.Columns.Add(New Xceed.Grid.Column("TXDATE", GetType(System.String)))
        ODReceiveGrid.Columns.Add(New Xceed.Grid.Column("CUSTODYCD", GetType(System.String)))
        ODReceiveGrid.Columns.Add(New Xceed.Grid.Column("BORS", GetType(System.String)))
        ODReceiveGrid.Columns.Add(New Xceed.Grid.Column("NORP", GetType(System.String)))
        ODReceiveGrid.Columns.Add(New Xceed.Grid.Column("AORN", GetType(System.String)))
        ODReceiveGrid.Columns.Add(New Xceed.Grid.Column("PRICE", GetType(System.Double)))
        ODReceiveGrid.Columns.Add(New Xceed.Grid.Column("QTTY", GetType(System.Double)))
        ODReceiveGrid.Columns.Add(New Xceed.Grid.Column("REMAINQTTY", GetType(System.Double)))
        ODReceiveGrid.Columns.Add(New Xceed.Grid.Column("EXECQTTY", GetType(System.Double)))
        ODReceiveGrid.Columns.Add(New Xceed.Grid.Column("CLEARDAY", GetType(System.String)))
        ODReceiveGrid.Columns.Add(New Xceed.Grid.Column("SETTLEDDAY", GetType(System.String)))
        ODReceiveGrid.Columns.Add(New Xceed.Grid.Column("CLEARCD", GetType(System.String)))
        ODReceiveGrid.Columns.Add(New Xceed.Grid.Column("SEACCTNO", GetType(System.String)))
        ODReceiveGrid.Columns.Add(New Xceed.Grid.Column("CIACCTNO", GetType(System.String)))
        ODReceiveGrid.Columns.Add(New Xceed.Grid.Column("AFACCTNO", GetType(System.String)))
        ODReceiveGrid.Columns.Add(New Xceed.Grid.Column("PRICETYPE", GetType(System.String)))
        ODReceiveGrid.Columns.Add(New Xceed.Grid.Column("TRADELOT", GetType(System.String)))
        ODReceiveGrid.Columns.Add(New Xceed.Grid.Column("BRATIO", GetType(System.String)))
        ''Them 2 truong 
        ODReceiveGrid.Columns.Add(New Xceed.Grid.Column("FLOOR_PRICE", GetType(System.String)))
        ODReceiveGrid.Columns.Add(New Xceed.Grid.Column("CEILING_PRICE", GetType(System.String)))
        ODReceiveGrid.Columns.Add(New Xceed.Grid.Column("TRADEPLACE", GetType(System.String)))

        ODReceiveGrid.Columns("ORGORDERID").Title = mv_ResourceManager.GetString("ORGORDERID")
        ODReceiveGrid.Columns("CODEID").Title = mv_ResourceManager.GetString("CODEID")
        ODReceiveGrid.Columns("SYMBOL").Title = mv_ResourceManager.GetString("SYMBOL")
        'ODReceiveGrid.Columns("TXDATE").Title = mv_ResourceManager.GetString("TXDATE")
        ODReceiveGrid.Columns("CUSTODYCD").Title = mv_ResourceManager.GetString("CUSTODYCD")
        ODReceiveGrid.Columns("BORS").Title = mv_ResourceManager.GetString("BORS")
        ODReceiveGrid.Columns("NORP").Title = mv_ResourceManager.GetString("NORP")
        ODReceiveGrid.Columns("AORN").Title = mv_ResourceManager.GetString("AORN")
        ODReceiveGrid.Columns("PRICE").Title = mv_ResourceManager.GetString("PRICE")
        ODReceiveGrid.Columns("PRICE").FormatSpecifier = "#,##0"
        ODReceiveGrid.Columns("QTTY").Title = mv_ResourceManager.GetString("QTTY")
        ODReceiveGrid.Columns("QTTY").FormatSpecifier = "#,##0"
        ODReceiveGrid.Columns("REMAINQTTY").Title = mv_ResourceManager.GetString("REMAINQTTY")
        ODReceiveGrid.Columns("REMAINQTTY").FormatSpecifier = "#,##0"
        ODReceiveGrid.Columns("EXECQTTY").Title = mv_ResourceManager.GetString("EXECQTTY")
        ODReceiveGrid.Columns("EXECQTTY").FormatSpecifier = "#,##0"
        ODReceiveGrid.Columns("CLEARDAY").Title = mv_ResourceManager.GetString("CLEARDAY")
        ODReceiveGrid.Columns("SETTLEDDAY").Title = mv_ResourceManager.GetString("SETTLEDDAY")
        ODReceiveGrid.Columns("CLEARCD").Title = mv_ResourceManager.GetString("CLEARCD")
        ODReceiveGrid.Columns("SEACCTNO").Title = mv_ResourceManager.GetString("SEACCTNO")
        ODReceiveGrid.Columns("CIACCTNO").Title = mv_ResourceManager.GetString("CIACCTNO")
        ODReceiveGrid.Columns("AFACCTNO").Title = mv_ResourceManager.GetString("AFACCTNO")
        ODReceiveGrid.Columns("PRICETYPE").Title = mv_ResourceManager.GetString("PRICETYPE")
        ODReceiveGrid.Columns("TRADELOT").Title = mv_ResourceManager.GetString("TRADELOT")
        ODReceiveGrid.Columns("BRATIO").Title = mv_ResourceManager.GetString("BRATIO")
        '''Them 2 truong
        ODReceiveGrid.Columns("FLOOR_PRICE").Title = "FLOOR_PRICE" 'mv_ResourceManager.GetString("FLOOR_PRICE")
        ODReceiveGrid.Columns("CEILING_PRICE").Title = "CEILING_PRICE" 'mv_ResourceManager.GetString("CEILING_PRICE")
        ODReceiveGrid.Columns("CEILING_PRICE").Title = "TRADEPLACE"

        ODReceiveGrid.Columns("ORGORDERID").Width = 120
        ODReceiveGrid.Columns("ORGORDERID").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODReceiveGrid.Columns("CODEID").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODReceiveGrid.Columns("SYMBOL").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        'ODReceiveGrid.Columns("TXDATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODReceiveGrid.Columns("CUSTODYCD").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODReceiveGrid.Columns("BORS").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODReceiveGrid.Columns("NORP").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODReceiveGrid.Columns("AORN").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODReceiveGrid.Columns("PRICE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODReceiveGrid.Columns("QTTY").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODReceiveGrid.Columns("REMAINQTTY").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODReceiveGrid.Columns("EXECQTTY").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODReceiveGrid.Columns("CLEARDAY").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODReceiveGrid.Columns("SETTLEDDAY").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODReceiveGrid.Columns("CLEARCD").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODReceiveGrid.Columns("SEACCTNO").Width = 120
        ODReceiveGrid.Columns("SEACCTNO").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODReceiveGrid.Columns("CIACCTNO").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODReceiveGrid.Columns("AFACCTNO").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODReceiveGrid.Columns("PRICETYPE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODReceiveGrid.Columns("TRADELOT").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODReceiveGrid.Columns("TRADELOT").Width = 0
        ODReceiveGrid.Columns("BRATIO").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODReceiveGrid.Columns("BRATIO").Width = 0
        '''Them 2 truong 
        ODReceiveGrid.Columns("FLOOR_PRICE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODReceiveGrid.Columns("FLOOR_PRICE").Width = 0
        ODReceiveGrid.Columns("CEILING_PRICE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODReceiveGrid.Columns("CEILING_PRICE").Width = 0
        ODReceiveGrid.Columns("TRADEPLACE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODReceiveGrid.Columns("TRADEPLACE").Width = 0


        ODReceiveGrid.Columns("ORGORDERID").Width = 120
        ODReceiveGrid.Columns("ORGORDERID").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODReceiveGrid.Columns("CODEID").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODReceiveGrid.Columns("SYMBOL").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        'ODReceiveGrid.Columns("TXDATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODReceiveGrid.Columns("CUSTODYCD").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODReceiveGrid.Columns("BORS").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODReceiveGrid.Columns("NORP").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODReceiveGrid.Columns("AORN").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODReceiveGrid.Columns("PRICE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODReceiveGrid.Columns("QTTY").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODReceiveGrid.Columns("REMAINQTTY").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODReceiveGrid.Columns("EXECQTTY").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODReceiveGrid.Columns("CLEARDAY").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODReceiveGrid.Columns("SETTLEDDAY").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODReceiveGrid.Columns("CLEARCD").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODReceiveGrid.Columns("SEACCTNO").Width = 120
        ODReceiveGrid.Columns("SEACCTNO").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODReceiveGrid.Columns("CIACCTNO").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODReceiveGrid.Columns("AFACCTNO").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODReceiveGrid.Columns("PRICETYPE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODReceiveGrid.Columns("TRADELOT").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODReceiveGrid.Columns("TRADELOT").Width = 0
        ODReceiveGrid.Columns("BRATIO").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODReceiveGrid.Columns("BRATIO").Width = 0
        '''Them 2 truong
        ODReceiveGrid.Columns("FLOOR_PRICE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODReceiveGrid.Columns("FLOOR_PRICE").Width = 0
        ODReceiveGrid.Columns("CEILING_PRICE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODReceiveGrid.Columns("CEILING_PRICE").Width = 0
        ODReceiveGrid.Columns("TRADEPLACE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODReceiveGrid.Columns("TRADEPLACE").Width = 0

        Me.pnODReceiveInfo.Controls.Clear()
        Me.pnODReceiveInfo.Controls.Add(ODReceiveGrid)
        ODReceiveGrid.Dock = Windows.Forms.DockStyle.Fill
        AddHandler ODReceiveGrid.SelectedRowsChanged, AddressOf Me.ReceiveSelectedRowChanged


        'Khởi tạo Grid AutoReceive 
        ODAutoReceiveGrid = New GridEx


        Dim v_grAutoReceiveHeader As Xceed.Grid.GroupByRow
        v_grAutoReceiveHeader = New Xceed.Grid.GroupByRow
        v_grAutoReceiveHeader.NoGroupText = mv_ResourceManager.GetString("GridEx.GroupByRow")

        v_grAutoReceiveHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(127, Byte), CType(123, Byte), CType(122, Byte))
        v_grAutoReceiveHeader.CellBackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_grAutoReceiveHeader.CellFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)


        Dim v_cmrAutoReceiveHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrAutoReceiveHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrAutoReceiveHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)

        ODAutoReceiveGrid.FixedHeaderRows.Add(v_grAutoReceiveHeader)
        ODAutoReceiveGrid.FixedHeaderRows.Add(v_cmrAutoReceiveHeader)


        Dim v_frODAutoReceiveGrid As Xceed.Grid.TextRow
        v_frODAutoReceiveGrid = New Xceed.Grid.TextRow(mv_ResourceManager.GetString("GridEx.FooterRow"))

        v_frODAutoReceiveGrid.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_frODAutoReceiveGrid.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic)
        ODAutoReceiveGrid.FixedFooterRows.Clear()
        ODAutoReceiveGrid.FixedFooterRows.Add(v_frODAutoReceiveGrid)

        ODAutoReceiveGrid.Columns.Add(New Xceed.Grid.Column("CONFIRM_NO", GetType(System.String)))
        ODAutoReceiveGrid.Columns.Add(New Xceed.Grid.Column("CUSTODYCD", GetType(System.String)))
        ODAutoReceiveGrid.Columns.Add(New Xceed.Grid.Column("BORS", GetType(System.String)))
        ODAutoReceiveGrid.Columns.Add(New Xceed.Grid.Column("SEC_CODE", GetType(System.String)))
        ODAutoReceiveGrid.Columns.Add(New Xceed.Grid.Column("QUANTITY", GetType(System.String)))
        ODAutoReceiveGrid.Columns.Add(New Xceed.Grid.Column("PRICE", GetType(System.String)))
        ODAutoReceiveGrid.Columns.Add(New Xceed.Grid.Column("TXDATE", GetType(System.String)))
        ODAutoReceiveGrid.Columns.Add(New Xceed.Grid.Column("OODORGORDERID", GetType(System.String)))
        ODAutoReceiveGrid.Columns.Add(New Xceed.Grid.Column("OODCUSTODYCD", GetType(System.String)))
        ODAutoReceiveGrid.Columns.Add(New Xceed.Grid.Column("OODBORS", GetType(System.String)))
        ODAutoReceiveGrid.Columns.Add(New Xceed.Grid.Column("OODSYMBOL", GetType(System.String)))
        ODAutoReceiveGrid.Columns.Add(New Xceed.Grid.Column("OODNORP", GetType(System.String)))
        ODAutoReceiveGrid.Columns.Add(New Xceed.Grid.Column("OODAORN", GetType(System.String)))
        ODAutoReceiveGrid.Columns.Add(New Xceed.Grid.Column("MATCHQTTY", GetType(System.String)))
        'Thêm để lấy biến truy?n v�ào giao dịch
        ODAutoReceiveGrid.Columns.Add(New Xceed.Grid.Column("TRADEUNIT", GetType(System.String)))
        ODAutoReceiveGrid.Columns.Add(New Xceed.Grid.Column("OODCODEID", GetType(System.String)))
        ODAutoReceiveGrid.Columns.Add(New Xceed.Grid.Column("REMAINQTTY", GetType(System.String)))
        ODAutoReceiveGrid.Columns.Add(New Xceed.Grid.Column("EXECQTTY", GetType(System.String)))
        ODAutoReceiveGrid.Columns.Add(New Xceed.Grid.Column("CLEARDAY", GetType(System.String)))
        ODAutoReceiveGrid.Columns.Add(New Xceed.Grid.Column("CLEARCD", GetType(System.String)))
        ODAutoReceiveGrid.Columns.Add(New Xceed.Grid.Column("SEACCTNO", GetType(System.String)))
        ODAutoReceiveGrid.Columns.Add(New Xceed.Grid.Column("CIACCTNO", GetType(System.String)))
        ODAutoReceiveGrid.Columns.Add(New Xceed.Grid.Column("AFACCTNO", GetType(System.String)))
        ODAutoReceiveGrid.Columns.Add(New Xceed.Grid.Column("PRICETYPE", GetType(System.String)))
        ODAutoReceiveGrid.Columns.Add(New Xceed.Grid.Column("S_ORDER_NO", GetType(System.String)))
        ODAutoReceiveGrid.Columns.Add(New Xceed.Grid.Column("B_ORDER_NO", GetType(System.String)))
        ODAutoReceiveGrid.Columns.Add(New Xceed.Grid.Column("S_ACCOUNT_NO", GetType(System.String)))
        ODAutoReceiveGrid.Columns.Add(New Xceed.Grid.Column("B_ACCOUNT_NO", GetType(System.String)))
        ODAutoReceiveGrid.Columns.Add(New Xceed.Grid.Column("EXEC_PRICE", GetType(System.String)))
        ODAutoReceiveGrid.Columns.Add(New Xceed.Grid.Column("TRADELOT", GetType(System.String)))
        ODAutoReceiveGrid.Columns.Add(New Xceed.Grid.Column("SECUREDRATIO", GetType(System.String)))

        ODAutoReceiveGrid.Columns("CONFIRM_NO").Title = mv_ResourceManager.GetString("RESULT_CONFIRM_NO")
        ODAutoReceiveGrid.Columns("CUSTODYCD").Title = mv_ResourceManager.GetString("RESULT_CUSTODYCD")
        ODAutoReceiveGrid.Columns("BORS").Title = mv_ResourceManager.GetString("RESULT_BORS")
        ODAutoReceiveGrid.Columns("SEC_CODE").Title = mv_ResourceManager.GetString("RESULT_SEC_CODE")
        ODAutoReceiveGrid.Columns("QUANTITY").Title = mv_ResourceManager.GetString("RESULT_QUANTITY")
        ODAutoReceiveGrid.Columns("PRICE").Title = mv_ResourceManager.GetString("RESULT_PRICE")
        ODAutoReceiveGrid.Columns("TXDATE").Title = mv_ResourceManager.GetString("TXDATE")
        ODAutoReceiveGrid.Columns("OODORGORDERID").Title = mv_ResourceManager.GetString("OOD_ORGORDERID")
        ODAutoReceiveGrid.Columns("OODCUSTODYCD").Title = mv_ResourceManager.GetString("OOD_CUSTODYCD")
        ODAutoReceiveGrid.Columns("OODBORS").Title = mv_ResourceManager.GetString("OOD_BORS")
        ODAutoReceiveGrid.Columns("OODSYMBOL").Title = mv_ResourceManager.GetString("OOD_SYMBOL")
        ODAutoReceiveGrid.Columns("OODNORP").Title = mv_ResourceManager.GetString("OOD_NORP")
        ODAutoReceiveGrid.Columns("OODAORN").Title = mv_ResourceManager.GetString("OOD_AORN")
        ODAutoReceiveGrid.Columns("MATCHQTTY").Title = mv_ResourceManager.GetString("MATCHQTTY")
        'Thêm để lấy biến truy?n v�ào giao dịch
        ODAutoReceiveGrid.Columns("TRADEUNIT").Title = mv_ResourceManager.GetString("TRADEUNIT")
        ODAutoReceiveGrid.Columns("OODCODEID").Title = mv_ResourceManager.GetString("OOD_CODEID")
        ODAutoReceiveGrid.Columns("REMAINQTTY").Title = mv_ResourceManager.GetString("REMAINQTTY")
        ODAutoReceiveGrid.Columns("EXECQTTY").Title = mv_ResourceManager.GetString("EXECQTTY")
        ODAutoReceiveGrid.Columns("CLEARDAY").Title = mv_ResourceManager.GetString("CLEARDAY")
        ODAutoReceiveGrid.Columns("CLEARCD").Title = mv_ResourceManager.GetString("CLEARCD")
        ODAutoReceiveGrid.Columns("SEACCTNO").Title = mv_ResourceManager.GetString("SEACCTNO")
        ODAutoReceiveGrid.Columns("CIACCTNO").Title = mv_ResourceManager.GetString("CIACCTNO")
        ODAutoReceiveGrid.Columns("AFACCTNO").Title = mv_ResourceManager.GetString("AFACCTNO")
        ODAutoReceiveGrid.Columns("PRICETYPE").Title = mv_ResourceManager.GetString("PRICETYPE")
        ODAutoReceiveGrid.Columns("S_ORDER_NO").Title = mv_ResourceManager.GetString("S_ORDER_NO")
        ODAutoReceiveGrid.Columns("B_ORDER_NO").Title = mv_ResourceManager.GetString("B_ORDER_NO")
        ODAutoReceiveGrid.Columns("S_ACCOUNT_NO").Title = mv_ResourceManager.GetString("S_ACCOUNT_NO")
        ODAutoReceiveGrid.Columns("B_ACCOUNT_NO").Title = mv_ResourceManager.GetString("B_ACCOUNT_NO")
        ODAutoReceiveGrid.Columns("EXEC_PRICE").Title = mv_ResourceManager.GetString("EXEC_PRICE")
        ODAutoReceiveGrid.Columns("TRADELOT").Title = mv_ResourceManager.GetString("TRADELOT")
        ODAutoReceiveGrid.Columns("SECUREDRATIO").Title = mv_ResourceManager.GetString("SECUREDRATIO")
        ODAutoReceiveGrid.Columns("CONFIRM_NO").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODAutoReceiveGrid.Columns("CUSTODYCD").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODAutoReceiveGrid.Columns("BORS").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODAutoReceiveGrid.Columns("SEC_CODE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODAutoReceiveGrid.Columns("QUANTITY").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODAutoReceiveGrid.Columns("PRICE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODAutoReceiveGrid.Columns("TXDATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODAutoReceiveGrid.Columns("OODORGORDERID").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODAutoReceiveGrid.Columns("OODCUSTODYCD").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODAutoReceiveGrid.Columns("OODBORS").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODAutoReceiveGrid.Columns("OODSYMBOL").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODAutoReceiveGrid.Columns("OODNORP").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODAutoReceiveGrid.Columns("OODAORN").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODAutoReceiveGrid.Columns("MATCHQTTY").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODAutoReceiveGrid.Columns("MATCHQTTY").ReadOnly = False
        ODAutoReceiveGrid.Columns("MATCHQTTY").MaxWidth = 150
        ODAutoReceiveGrid.Columns("MATCHQTTY").MinWidth = 50
        'Thêm để lấy biến truy?n v�ào giao dịch
        ODAutoReceiveGrid.Columns("TRADEUNIT").Width = 0
        ODAutoReceiveGrid.Columns("TRADELOT").Width = 0
        ODAutoReceiveGrid.Columns("TRADEUNIT").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODAutoReceiveGrid.Columns("OODCODEID").Width = 0
        ODAutoReceiveGrid.Columns("OODCODEID").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODAutoReceiveGrid.Columns("REMAINQTTY").Width = 0
        ODAutoReceiveGrid.Columns("REMAINQTTY").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODAutoReceiveGrid.Columns("EXECQTTY").Width = 0
        ODAutoReceiveGrid.Columns("EXECQTTY").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODAutoReceiveGrid.Columns("CLEARDAY").Width = 0
        ODAutoReceiveGrid.Columns("CLEARDAY").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODAutoReceiveGrid.Columns("CLEARCD").Width = 0
        ODAutoReceiveGrid.Columns("CLEARCD").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODAutoReceiveGrid.Columns("SEACCTNO").Width = 0
        ODAutoReceiveGrid.Columns("SEACCTNO").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODAutoReceiveGrid.Columns("CIACCTNO").Width = 0
        ODAutoReceiveGrid.Columns("CIACCTNO").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODAutoReceiveGrid.Columns("AFACCTNO").Width = 0
        ODAutoReceiveGrid.Columns("AFACCTNO").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODAutoReceiveGrid.Columns("PRICETYPE").Width = 0
        ODAutoReceiveGrid.Columns("PRICETYPE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODAutoReceiveGrid.Columns("S_ORDER_NO").Width = 0
        ODAutoReceiveGrid.Columns("S_ORDER_NO").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODAutoReceiveGrid.Columns("B_ORDER_NO").Width = 0
        ODAutoReceiveGrid.Columns("B_ORDER_NO").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODAutoReceiveGrid.Columns("S_ACCOUNT_NO").Width = 0
        ODAutoReceiveGrid.Columns("S_ACCOUNT_NO").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODAutoReceiveGrid.Columns("B_ACCOUNT_NO").Width = 0
        ODAutoReceiveGrid.Columns("B_ACCOUNT_NO").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODAutoReceiveGrid.Columns("EXEC_PRICE").Width = 0
        ODAutoReceiveGrid.Columns("EXEC_PRICE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODAutoReceiveGrid.Columns("SECUREDRATIO").Width = 0
        ODAutoReceiveGrid.Columns("SECUREDRATIO").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        Me.pnAutoInfo.Controls.Clear()
        Me.pnAutoInfo.Controls.Add(ODAutoReceiveGrid)
        ODAutoReceiveGrid.Dock = Windows.Forms.DockStyle.Fill
        'AddHandler ODAutoReceiveGrid.SelectedRowsChanged, AddressOf Me.AutoReceiveSelectedRowChanged
        'AddHandler ODAutoReceiveGrid.DataRowTemplate.Cells("MATCHQTTY").ValueChanged, AddressOf Grid_MATCHQTTYValueChange
    End Sub

    Private Sub LoadODReceive(ByVal pv_strSQLCMD As String)
        Try
            If Not ODReceiveGrid Is Nothing And Len(pv_strSQLCMD) > 0 Then
                'Remove các bản ghi cũ
                ODReceiveGrid.DataRows.Clear()
                Dim v_strSQL As String = pv_strSQLCMD
                Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_OD_ODMAST, gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                Dim v_strResourceManager As String

                FillDataGrid(ODReceiveGrid, v_strObjMsg, "")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub LoadODAutoReceive(ByVal pv_strSQLCMD As String)
        Try
            AutoMatching()
            MatchingOrder(mv_intOOD, mv_intResult, mv_intMatchingOrder, mv_arrOOD, mv_arrRusult, mv_arrMatchingOrder)
            ODAutoReceiveGrid.DataRows.Clear()

            'Fill data vào grid
            If mv_intMatchingOrder > 0 Then
                For i As Integer = 0 To mv_intMatchingOrder
                    If Not mv_arrMatchingOrder(i) Is Nothing Then
                        If mv_arrMatchingOrder(i).MATCHING_QTTY > 0 Then
                            Dim v_xDataRow As Xceed.Grid.DataRow = ODAutoReceiveGrid.DataRows.AddNew()
                            v_xDataRow.Cells("MATCHQTTY").Value = CStr(mv_arrMatchingOrder(i).MATCHING_QTTY)
                            v_xDataRow.Cells("OODAORN").Value = mv_arrMatchingOrder(i).OOD_AORN
                            v_xDataRow.Cells("OODBORS").Value = mv_arrMatchingOrder(i).OOD_BORS
                            'v_xDataRow.Cells("OOD_CODEID").Value = mv_arrMatchingOrder(i).OOD_CODEID
                            v_xDataRow.Cells("OODCUSTODYCD").Value = mv_arrMatchingOrder(i).OOD_CUSTODYCD
                            v_xDataRow.Cells("OODNORP").Value = mv_arrMatchingOrder(i).OOD_NORP
                            v_xDataRow.Cells("OODORGORDERID").Value = mv_arrMatchingOrder(i).OOD_ORGORDERID
                            'v_xDataRow.Cells("OOD_QTTY").Value = mv_arrMatchingOrder(i).OOD_QTTY
                            v_xDataRow.Cells("OODSYMBOL").Value = mv_arrMatchingOrder(i).OOD_SYMBOL
                            v_xDataRow.Cells("BORS").Value = mv_arrMatchingOrder(i).RESULT_BORS
                            v_xDataRow.Cells("CONFIRM_NO").Value = mv_arrMatchingOrder(i).RESULT_CONFIRM_NO
                            v_xDataRow.Cells("CUSTODYCD").Value = mv_arrMatchingOrder(i).RESULT_CUSTODYCD
                            v_xDataRow.Cells("TXDATE").Value = mv_arrMatchingOrder(i).RESULT_MATCH_DATE
                            v_xDataRow.Cells("PRICE").Value = CStr(mv_arrMatchingOrder(i).RESULT_PRICE)
                            v_xDataRow.Cells("QUANTITY").Value = CStr(mv_arrMatchingOrder(i).RESULT_QUANTITY)
                            v_xDataRow.Cells("SEC_CODE").Value = mv_arrMatchingOrder(i).RESULT_SEC_CODE

                            'Lay them thong tin
                            v_xDataRow.Cells("TRADEUNIT").Value = mv_arrMatchingOrder(i).v_strTRADEUNIT
                            v_xDataRow.Cells("OODCODEID").Value = mv_arrMatchingOrder(i).OOD_CODEID
                            v_xDataRow.Cells("EXECQTTY").Value = mv_arrMatchingOrder(i).v_strEXECQTTY
                            v_xDataRow.Cells("EXEC_PRICE").Value = CStr(mv_arrMatchingOrder(i).v_strEXECPRICE)
                            v_xDataRow.Cells("CLEARDAY").Value = mv_arrMatchingOrder(i).v_strCLEARDAY
                            v_xDataRow.Cells("CLEARCD").Value = mv_arrMatchingOrder(i).v_strCLEARCD
                            v_xDataRow.Cells("SEACCTNO").Value = mv_arrMatchingOrder(i).v_strSEACCTNO
                            v_xDataRow.Cells("CIACCTNO").Value = mv_arrMatchingOrder(i).v_strCIACCTNO
                            v_xDataRow.Cells("AFACCTNO").Value = mv_arrMatchingOrder(i).v_strAFACCTNO
                            v_xDataRow.Cells("S_ORDER_NO").Value = mv_arrMatchingOrder(i).v_strS_ORDER_NO
                            v_xDataRow.Cells("B_ORDER_NO").Value = mv_arrMatchingOrder(i).v_strB_ORDER_NO
                            v_xDataRow.Cells("S_ACCOUNT_NO").Value = mv_arrMatchingOrder(i).v_strS_ACCOUNT_NO
                            v_xDataRow.Cells("B_ACCOUNT_NO").Value = mv_arrMatchingOrder(i).v_strB_ACCOUNT_NO
                            v_xDataRow.Cells("SECUREDRATIO").Value = mv_arrMatchingOrder(i).v_strSECUREDRATIO
                            v_xDataRow.EndEdit()
                        End If
                    End If
                Next

            End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try

    End Sub

    Private Sub setGridRowValue(ByVal pv_GridRow As Xceed.Grid.DataRow)
        mv_strORGORDERID = Trim(pv_GridRow.Cells("ORGORDERID").Value)
        mv_strCODEID = Trim(pv_GridRow.Cells("CODEID").Value)
        mv_strCUSTODYCD = Trim(pv_GridRow.Cells("CUSTODYCD").Value)
        mv_strSYMBOL = Trim(pv_GridRow.Cells("SYMBOL").Value)
        mv_strBORS = Trim(pv_GridRow.Cells("BORS").Value)
        mv_strEXPRICE = Trim(pv_GridRow.Cells("PRICE").Value)
        mv_strEXQTTY = Trim(pv_GridRow.Cells("QTTY").Value)
        mv_strREMAINQTTY = Trim(pv_GridRow.Cells("REMAINQTTY").Value)
        mv_strEXECQTTY = Trim(pv_GridRow.Cells("EXECQTTY").Value)
        mv_strNORP = Trim(pv_GridRow.Cells("NORP").Value)
        mv_strAORN = Trim(pv_GridRow.Cells("AORN").Value)
        mv_strCLEARDAY = Trim(pv_GridRow.Cells("CLEARDAY").Value)
        mv_strCLEARCD = Trim(pv_GridRow.Cells("CLEARCD").Value)
        mv_strSEACCTNO = Trim(pv_GridRow.Cells("SEACCTNO").Value)
        mv_strCIACCTNO = Trim(pv_GridRow.Cells("CIACCTNO").Value)
        mv_strAFACCTNO = Trim(pv_GridRow.Cells("AFACCTNO").Value)
        mv_strPRICETYPE = Trim(pv_GridRow.Cells("PRICETYPE").Value)
        mv_strTRADELOT = Trim(pv_GridRow.Cells("TRADELOT").Value)
        mv_strSECUREDRATIO = Trim(pv_GridRow.Cells("BRATIO").Value)
        mv_strFloorPrice = Trim(pv_GridRow.Cells("FLOOR_PRICE").Value)
        mv_strCeilingPrice = Trim(pv_GridRow.Cells("CEILING_PRICE").Value)
        mv_strTradePlace = Trim(pv_GridRow.Cells("TRADEPLACE").Value)
        'Cac tham so trading_result reset lai
        v_objTrading_result.CONFIRM_NO = String.Empty
        v_objTrading_result.CUSTODYCD = String.Empty
        v_objTrading_result.BORS = String.Empty
        v_objTrading_result.SEC_CODE = String.Empty
        v_objTrading_result.QUANTITY = 0
        v_objTrading_result.OLDQUANTITY = 0
        v_objTrading_result.PRICE = 0
        v_objTrading_result.MATCH_DATE = String.Empty
        v_objTrading_result.v_strS_ACCOUNT_NO = String.Empty
        v_objTrading_result.v_strB_ACCOUNT_NO = String.Empty
        v_objTrading_result.v_strS_ORDER_NO = String.Empty
        v_objTrading_result.v_strB_ORDER_NO = String.Empty

    End Sub
    Private Sub setAutoGridRowValue(ByVal pv_GridRow As Xceed.Grid.DataRow)
        mv_strORGORDERID = Trim(pv_GridRow.Cells("OODORGORDERID").Value)
        mv_strCODEID = Trim(pv_GridRow.Cells("OODCODEID").Value)
        mv_strCUSTODYCD = Trim(pv_GridRow.Cells("OODCUSTODYCD").Value)
        mv_strSYMBOL = Trim(pv_GridRow.Cells("OODSYMBOL").Value)
        mv_strBORS = Trim(pv_GridRow.Cells("OODBORS").Value)
        mv_strEXPRICE = Trim(pv_GridRow.Cells("EXEC_PRICE").Value)
        mv_strEXQTTY = Trim(pv_GridRow.Cells("EXECQTTY").Value)
        mv_strPRICE = (CDbl(Trim(pv_GridRow.Cells("PRICE").Value)) * CDbl(Trim(pv_GridRow.Cells("TRADEUNIT").Value))).ToString
        mv_strQTTY = Trim(pv_GridRow.Cells("MATCHQTTY").Value)
        mv_strNORP = Trim(pv_GridRow.Cells("OODNORP").Value)
        mv_strAORN = Trim(pv_GridRow.Cells("OODAORN").Value)
        mv_strREMAINQTTY = Trim(pv_GridRow.Cells("REMAINQTTY").Value)
        mv_strEXECQTTY = Trim(pv_GridRow.Cells("EXECQTTY").Value)
        mv_strCLEARDAY = Trim(pv_GridRow.Cells("CLEARDAY").Value)
        mv_strCLEARCD = Trim(pv_GridRow.Cells("CLEARCD").Value)
        mv_strSEACCTNO = Trim(pv_GridRow.Cells("SEACCTNO").Value)
        mv_strCIACCTNO = Trim(pv_GridRow.Cells("CIACCTNO").Value)
        mv_strAFACCTNO = Trim(pv_GridRow.Cells("AFACCTNO").Value)
        mv_strPRICETYPE = Trim(pv_GridRow.Cells("PRICETYPE").Value)
        mv_strB_ACCOUNT_NO = Trim(pv_GridRow.Cells("B_ACCOUNT_NO").Value)
        mv_strS_ACCOUNT_NO = Trim(pv_GridRow.Cells("S_ACCOUNT_NO").Value)
        mv_strB_ORDER_NO = Trim(pv_GridRow.Cells("B_ORDER_NO").Value)
        mv_strS_ORDER_NO = Trim(pv_GridRow.Cells("S_ORDER_NO").Value)
        mv_strTRADEUNIT = Trim(pv_GridRow.Cells("TRADEUNIT").Value)
        mv_strTRADELOT = Trim(pv_GridRow.Cells("TRADELOT").Value)
        mv_strSECUREDRATIO = Trim(pv_GridRow.Cells("SECUREDRATIO").Value)
        mv_strCONFIRM_NO = Trim(pv_GridRow.Cells("CONFIRM_NO").Value)
        mv_strMATCH_DATE = Trim(pv_GridRow.Cells("TXDATE").Value)
    End Sub

    Private Sub setBlankGridRowValue()
        mv_strREFCUSTCD = String.Empty
        mv_strREFORDERID = String.Empty
        mv_strORGORDERID = String.Empty
        mv_strCODEID = String.Empty
        mv_strCUSTODYCD = String.Empty
        mv_strSYMBOL = String.Empty
        mv_strBORS = String.Empty
        mv_strPRICE = String.Empty
        mv_strEXPRICE = String.Empty
        mv_strQTTY = String.Empty
        mv_strEXQTTY = String.Empty
        mv_strREMAINQTTY = String.Empty
        mv_strEXECQTTY = String.Empty
        mv_strNORP = String.Empty
        mv_strAORN = String.Empty
        mv_strCLEARDAY = String.Empty
        mv_strCLEARCD = String.Empty
        mv_strSEACCTNO = String.Empty
        mv_strCIACCTNO = String.Empty
        mv_strAFACCTNO = String.Empty
        mv_strPRICETYPE = String.Empty
        mv_strTRADELOT = String.Empty
        mv_strSECUREDRATIO = String.Empty
        mv_strCONFIRM_NO = String.Empty
        mv_strMATCH_DATE = String.Empty
    End Sub
    Private Sub setControlValue()
        Me.txtExQuantity.Text = mv_strEXQTTY
        Me.txtQuantity.Text = mv_strREMAINQTTY
        Me.txtPrice.Text = mv_strEXPRICE
        Me.txtExPrice.Text = mv_strEXPRICE
        Me.txtClearDay.Text = mv_strCLEARDAY
        Me.txtREMAINQTTY.Text = mv_strREMAINQTTY
        Me.txtEXECQTTY.Text = mv_strEXECQTTY
        Me.cboCODEID.SelectedValue = Trim(mv_strCODEID)
        Me.cboBORS.SelectedValue = Trim(mv_strBORS)
        Me.cboNORP.SelectedValue = Trim(mv_strNORP)
        Me.cboClearCD.SelectedValue = Trim(mv_strCLEARCD)
        Me.txtREFCUSTCD.Text = mv_strREFCUSTCD
        Me.txtRefOrderID.Text = mv_strREFORDERID

        FormatNumericTextbox(Me.txtQuantity)
        FormatNumericTextbox(Me.txtPrice)

        If mv_strAORN = "A" Then
            Me.chkAORN.Checked = True
        Else
            Me.chkAORN.Checked = False
        End If
        Me.lblDesc.Text = "CustodyCD: " & mv_strCUSTODYCD & "(" & mv_strBORS & ")  " & mv_strSYMBOL & ":" & mv_strEXQTTY & "X" & mv_strEXPRICE
        Me.txtTxDesc.Text = mv_strCUSTODYCD & "." & mv_strBORS & "." & mv_strSYMBOL & "." & Me.txtQuantity.Text & "." & Me.txtPrice.Text
    End Sub
#End Region

#Region " Other method "
    '---------------------------------------------------------------------------------------------------------
    'Hàm này được sử dụng để nạp màn hình.
    'Biến vào 
    '   strTLTXCD là mã giao dịch, dùng để xác định các trư?ng trong giao d�ịch
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
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Sub
    'Verify rules của giao dịch, trả v? �điện giao dịch đã được tạo
    Private Function VerifyRules(ByRef v_strTxMsg As String, ByVal v_blAll As Boolean) As Boolean
        Try
            Dim v_xmlDocument As New Xml.XmlDocument, v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
            Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode, v_intIndex As Long, i, v_intCount As Integer
            Dim v_strFLDNAME As String, v_strFLDDEFNAME As String, v_strDATATYPE As String, v_strFLDVALUE As String
            Dim v_strERRMSG, v_strENERRMSG, v_strOPERATOR, v_strVALEXP, v_strVALEXP2 As String, v_strACTYPE, v_strDESC As String
            Dim v_dtVALEXP, v_dtVALEXP2, v_dtFLDVALUE As Date, v_strCMDSQL As String
            Dim v_ctl As Control, v_attrFLDNAME As Xml.XmlAttribute, v_attrDATATYPE As Xml.XmlAttribute, v_objEval As New Evaluator
            Dim v_strTLTXCD As String

            'Tạo điện giao dịch
            If v_blAll = False Then
                v_strTLTXCD = gc_OD_MANUAL_MATCHORDER
            Else
                v_strTLTXCD = gc_OD_MATCHORDER
            End If
            LoadScreen(v_strTLTXCD)
            v_strTxMsg = BuildXMLTxMsg(gc_MsgTypeTrans, gc_IsLocalMsg, v_strTLTXCD, Me.BranchId, Me.TellerId, Me.IpAddress, Me.WsName)
            v_xmlDocument.LoadXml(v_strTxMsg)
            v_dataElement = v_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "fields", "")
            If mv_arrObjFields.GetLength(0) > 0 Then
                For v_intIndex = 0 To mv_arrObjFields.GetLength(0) - 1 Step 1
                    If Not mv_arrObjFields(v_intIndex) Is Nothing Then
                        v_strFLDNAME = mv_arrObjFields(v_intIndex).FieldName
                        v_strDATATYPE = mv_arrObjFields(v_intIndex).DataType
                        Select Case Trim(v_strFLDNAME)
                            Case "03" 'ORGORDERID
                                v_strFLDVALUE = mv_strORGORDERID
                            Case "80" 'CODEID
                                v_strFLDVALUE = mv_strCODEID
                            Case "81" 'SYMBOL
                                v_strFLDVALUE = mv_strSYMBOL
                            Case "82" 'CUSTODYCD
                                v_strFLDVALUE = mv_strCUSTODYCD
                            Case "83" 'BORS
                                v_strFLDVALUE = mv_strBORS
                            Case "84" 'NORP
                                v_strFLDVALUE = mv_strNORP
                            Case "85" 'AORN
                                v_strFLDVALUE = mv_strAORN
                            Case "04" 'AFACCTNO
                                v_strFLDVALUE = mv_strAFACCTNO
                            Case "05" 'CIACCTNO
                                v_strFLDVALUE = mv_strCIACCTNO
                            Case "06" 'SEACCTNO
                                v_strFLDVALUE = mv_strSEACCTNO
                            Case "07" 'REFORDERID
                                If v_blAll Then
                                    Select Case mv_strBORS
                                        Case "B"
                                            v_strFLDVALUE = mv_strS_ORDER_NO
                                        Case "S"
                                            v_strFLDVALUE = mv_strB_ORDER_NO
                                    End Select
                                Else
                                    v_strFLDVALUE = Me.txtRefOrderID.Text
                                End If
                            Case "08" 'REFCUSTCD
                                If v_blAll Then
                                    Select Case mv_strBORS
                                        Case "B"
                                            v_strFLDVALUE = mv_strS_ACCOUNT_NO
                                        Case "S"
                                            v_strFLDVALUE = mv_strB_ACCOUNT_NO
                                    End Select
                                Else
                                    v_strFLDVALUE = Me.txtREFCUSTCD.Text
                                End If
                            Case "09" 'CLEARCD
                                v_strFLDVALUE = mv_strCLEARCD
                            Case "12" 'EXPRICE     
                                If v_blAll = True Then
                                    v_strFLDVALUE = (CDbl(mv_strEXPRICE)).ToString
                                Else
                                    v_strFLDVALUE = mv_strEXPRICE
                                End If
                            Case "13" 'EXQTTY                                       
                                v_strFLDVALUE = mv_strEXQTTY
                            Case "10" 'PRICE                                       
                                If v_blAll Then
                                    v_strFLDVALUE = mv_strPRICE
                                Else
                                    v_strFLDVALUE = Convert.ToDouble(Me.txtPrice.Text).ToString
                                End If
                            Case "11" 'QTTY                                       
                                If v_blAll Then
                                    v_strFLDVALUE = mv_strQTTY
                                Else
                                    v_strFLDVALUE = Convert.ToDouble(Me.txtQuantity.Text).ToString
                                End If
                            Case "14" 'CLEARDAY                                         
                                v_strFLDVALUE = mv_strCLEARDAY
                            Case "15" 'SECUREDRATIO
                                v_strFLDVALUE = mv_strSECUREDRATIO
                            Case "16" 'CONFIRM_NO
                                v_strFLDVALUE = mv_strCONFIRM_NO
                            Case "17" 'MATCH_DATE
                                v_strFLDVALUE = mv_strMATCH_DATE
                            Case "30" 'DESC   
                                If v_blAll Then
                                    v_strFLDVALUE = mv_strCUSTODYCD & "." & mv_strBORS & "." & mv_strSYMBOL & "." & mv_strQTTY & "." & mv_strPRICE
                                Else
                                    ' v_strFLDVALUE = mv_strCUSTODYCD & "." & mv_strBORS & "." & mv_strSYMBOL & "." & Replace(Me.txtQuantity.Text, ",", "") & "." & Replace(Me.txtPrice.Text, ",", "")
                                    v_strFLDVALUE = txtTxDesc.Text
                                End If
                            Case "86" 'DCRAMT dung de tinh gia von trong truong hop khop mua
                                If mv_strBORS = "B" Then
                                    If v_blAll Then
                                        v_strFLDVALUE = CStr(CInt(mv_strPRICE) * CInt(mv_strQTTY))
                                    Else
                                        v_strFLDVALUE = CStr(CInt(Convert.ToDouble(Me.txtPrice.Text).ToString) * CInt(Convert.ToDouble(Me.txtQuantity.Text).ToString))
                                    End If
                                End If
                            Case "87" 'DCRQTTY dung de tinh gia von trong truong hop khop mua
                                If mv_strBORS = "B" Then
                                    If v_blAll Then
                                        v_strFLDVALUE = mv_strQTTY
                                    Else
                                        v_strFLDVALUE = Convert.ToDouble(Me.txtQuantity.Text).ToString
                                    End If
                                End If
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

    'Hàm này được dùng để hiển thị lại điện giao dịch trả v? t�ừ trên HOST đối với giao dịch Submit 02 lần
    Private Function DisplayConfirm(ByVal v_xmlDocument As Xml.XmlDocument) As Boolean

    End Function

    Protected Overridable Function InitDialog()
        'Khởi tạo kích thước form và load resource
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        LoadResource(Me)
        DoResizeForm()
        ResetScreen(Me)

        'Thiết lập các thuộc tính ban đầu cho form
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strCmdSQL As String, v_strObjMsg As String

        v_strCmdSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, LSTODR FROM ALLCODE WHERE CDTYPE='OD' AND TRIM(CDNAME)='NORP' ORDER BY LSTODR"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
        v_ws.Message(v_strObjMsg)
        FillComboEx(v_strObjMsg, cboNORP, "", Me.UserLanguage)

        v_strCmdSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, LSTODR FROM ALLCODE WHERE CDTYPE='OD' AND TRIM(CDNAME)='BORS' ORDER BY LSTODR"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
        v_ws.Message(v_strObjMsg)
        FillComboEx(v_strObjMsg, cboBORS, "", Me.UserLanguage)

        v_strCmdSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, LSTODR FROM ALLCODE WHERE CDTYPE='OD' AND TRIM(CDNAME)='BORS' ORDER BY LSTODR"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
        v_ws.Message(v_strObjMsg)
        FillComboEx(v_strObjMsg, cboSBORS, "", Me.UserLanguage)

        v_strCmdSQL = "SELECT CODEID VALUE, SYMBOL DISPLAY, SYMBOL EN_DISPLAY FROM SBSECURITIES ORDER BY DISPLAY"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
        v_ws.Message(v_strObjMsg)
        FillComboEx(v_strObjMsg, cboSCODEID, "", Me.UserLanguage)

        v_strCmdSQL = "SELECT CODEID VALUE, SYMBOL DISPLAY, SYMBOL EN_DISPLAY FROM SBSECURITIES ORDER BY DISPLAY"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
        v_ws.Message(v_strObjMsg)
        FillComboEx(v_strObjMsg, cboCODEID, "", Me.UserLanguage)

        v_strCmdSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, LSTODR FROM ALLCODE WHERE CDTYPE='OD' AND TRIM(CDNAME)='CLEARCD' ORDER BY LSTODR"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
        v_ws.Message(v_strObjMsg)
        FillComboEx(v_strObjMsg, cboClearCD, "", Me.UserLanguage)
        If cboSBORS.Items.Count > 0 Then cboSBORS.SelectedIndex = -1
        If cboBORS.Items.Count > 0 Then cboBORS.SelectedIndex = 0
        If cboNORP.Items.Count > 0 Then cboNORP.SelectedIndex = 0
        If cboCODEID.Items.Count > 0 Then cboCODEID.SelectedIndex = 0
        If cboSCODEID.Items.Count > 0 Then cboSCODEID.SelectedIndex = -1
        setBlankGridRowValue()
        If Me.ODReceiveGrid.DataRows.Count > 0 Then
            ODReceiveGrid.CurrentRow = Me.ODReceiveGrid.DataRows(0)
            setGridRowValue(ODReceiveGrid.DataRows(0))
        End If

        setControlValue()

        Dim v_ctl As Control
        For Each v_ctl In Me.pnOrder.Controls
            If TypeOf (v_ctl) Is ComboBoxEx Then
                CType(v_ctl, ComboBoxEx).Enabled = False
            End If
            If TypeOf (v_ctl) Is TextBox Then
                CType(v_ctl, TextBox).ReadOnly = True
            End If
        Next
        Me.txtTxDesc.ReadOnly = False
        Me.chkAORN.Enabled = False
        Me.txtPrice.ReadOnly = False
        Me.txtQuantity.ReadOnly = False
        Me.txtREFCUSTCD.ReadOnly = False
        Me.txtRefOrderID.ReadOnly = False
        Me.btnReceive.Enabled = True
        Me.lblREFCUSTCD.ForeColor = System.Drawing.Color.Red
        Me.lblRefOrderID.ForeColor = System.Drawing.Color.Red
        Me.lblQuantity.ForeColor = System.Drawing.Color.Red
        Me.lblPrice.ForeColor = System.Drawing.Color.Red
    End Function

    Private Sub ResetScreen(ByRef pv_ctrl As Windows.Forms.Control)

    End Sub


    Public Overridable Sub OnSubmit(ByVal v_blnAll As Boolean)
        Dim v_strTxMsg As String, v_xmlDocument As New Xml.XmlDocument, v_attrColl As Xml.XmlAttributeCollection
        Dim v_intNOSUBMIT As Integer, v_strNEXTTX As String = String.Empty
        Dim v_strErrorSource, v_strErrorMessage As String, v_lngError, v_lngErr As Long
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_blnPass As Boolean
        Try
            If v_blnAll = False Then
                'Nếu là receive lệnh được ch?n
                If (ODReceiveGrid.CurrentRow Is Nothing) Then
                    Exit Sub
                End If
                MessageData = vbNullString
                'Kh�ởi tạo điện giao dịch
                '0. Check before match
                If Not v_objTrading_result.CONFIRM_NO = String.Empty Then
                    'Neu lenh khop duoc tham chieu den mot ket qua trong trading_result thi check.
                    If Not (v_objTrading_result.CUSTODYCD = mv_strCUSTODYCD And v_objTrading_result.SEC_CODE = mv_strSYMBOL) Then
                        MessageBox.Show("Invalid reference order trading result!")
                        Exit Sub
                    End If
                    If Not (v_objTrading_result.PRICE = CDbl(Me.txtPrice.Text) And v_objTrading_result.QUANTITY >= CDbl(Me.txtQuantity.Text)) Then
                        MessageBox.Show("Price and quantity not matching with reference order trading result!")
                        Exit Sub
                    End If
                End If
                mv_strCONFIRM_NO = v_objTrading_result.CONFIRM_NO
                mv_strMATCH_DATE = v_objTrading_result.MATCH_DATE

                '1. Verify và tạo điện giao dịch
                If Not VerifyRules(v_strTxMsg, v_blnAll) Then
                    Exit Sub
                End If
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
                        'GetReasonFromMessage(v_strTxMsg, v_strErrorMessage, Me.UserLanguage)
                        'MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, Me.Text)
                        MessageBox.Show("Successful!")
                    End If
                End If
                ResetScreen(Me)
                LoadODReceive(mv_strSQLCMD)
                If Me.ODReceiveGrid.DataRows.Count > 0 Then
                    ODReceiveGrid.CurrentRow = Me.ODReceiveGrid.DataRows(0)
                    setGridRowValue(ODReceiveGrid.DataRows(0))
                    setControlValue()
                End If
            Else
                ' Receive tat ca
                If Me.ODAutoReceiveGrid Is Nothing Then
                    Exit Sub
                End If
                If Me.ODAutoReceiveGrid.DataRows.Count = 0 Then
                    Exit Sub
                End If
                If Me.ODAutoReceiveGrid.DataRows.Count > 0 Then
                    Dim i As Integer
                    For i = 0 To Me.ODAutoReceiveGrid.DataRows.Count - 1
                        'Nếu row chưa khởi tạo thì thoát
                        If ODAutoReceiveGrid.DataRows(i) Is Nothing Then
                            'Nếu Match Quantity là trống hoặc bằng 0 thì không nhận
                        ElseIf Trim(ODAutoReceiveGrid.DataRows(i).Cells("MATCHQTTY").Value) = "" Or Trim(ODAutoReceiveGrid.DataRows(i).Cells("MATCHQTTY").Value) = "0" Then
                            'Nếu giá trị nhập vào không phải là số thì 
                        ElseIf Not IsNumeric(Trim(ODAutoReceiveGrid.DataRows(i).Cells("MATCHQTTY").Value)) Then
                            '?�ẩy từng dòng ứng với mỗi giao dịch lên server
                        ElseIf TypeOf (ODAutoReceiveGrid.DataRows(i)) Is Xceed.Grid.DataRow And CDbl(Trim(ODAutoReceiveGrid.DataRows(i).Cells("MATCHQTTY").Value)) > 0 Then
                            setAutoGridRowValue(ODAutoReceiveGrid.DataRows(i))
                            v_blnPass = True
                            'Check xem lenh co bi khop cheo hay khong. Neu lenh bi khop cheo thi khong cho khop nua
                            'If mv_strBORS = "B" Then
                            '    If mv_strEXPRICE < mv_strPRICE Then
                            '        v_blnPass = False
                            '    End If
                            'Else
                            '    If mv_strEXPRICE > mv_strPRICE Then
                            '        v_blnPass = False
                            '    End If
                            'End If
                            'Neu Pass qua dieu kien check thi cho khop tu dong.
                            If v_blnPass = True Then
                                'Khởi tạo điện giao dịch
                                MessageData = vbNullString
                                '1. Verify và tạo điện giao dịch
                                If Not VerifyRules(v_strTxMsg, v_blnAll) Then
                                    'Duyet tiep giao dich tiep theo
                                Else
                                    v_lngError = v_ws.Message(v_strTxMsg)
                                    If v_lngError <> ERR_SYSTEM_OK Then
                                        'Thông báo lỗi
                                        GetErrorFromMessage(v_strTxMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                                        Cursor.Current = Cursors.Default
                                        If v_lngError <> ERR_SA_CHECKER1_OVR And v_lngError <> ERR_SA_CHECKER2_OVR Then
                                            v_lngErr = v_lngError
                                            MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, Me.Text)
                                        Else
                                            'Lấy thêm nguyên nhân duyệt
                                            'GetReasonFromMessage(v_strTxMsg, v_strErrorMessage, Me.UserLanguage)
                                            'MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, Me.Text)
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    Next
                    ResetScreen(Me)
                End If
                If v_lngErr <> 0 Then
                    MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, Me.Text)
                Else
                    MessageBox.Show("Successful!")
                End If
                LoadODAutoReceive(mv_strAUTOSQLCMD)
                LoadODReceive(mv_strSQLCMD)
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
            ElseIf TypeOf (v_ctrl) Is TabPage Then
                LoadResource(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is TabControl Then
                LoadResource(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is DateTimePicker Then
                CType(v_ctrl, DateTimePicker).Value = CDate(Me.BusDate)
            End If
        Next
        Me.Text = mv_ResourceManager.GetString(Me.Name)
        Me.tpgManual.Text = mv_ResourceManager.GetString(Me.tpgManual.Name)
        Me.tpgAutomatic.Text = mv_ResourceManager.GetString(Me.tpgAutomatic.Name)
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

    Private Function Receive_ControlValidation() As Boolean
        If Not IsNumeric(txtPrice.Text) Then
            MsgBox(mv_ResourceManager.GetString("PRICEISNOTNUMBER"), MsgBoxStyle.Information, Me.Text)
            Return False
        ElseIf CDbl(txtPrice.Text) <= 0 Then
            MsgBox(mv_ResourceManager.GetString("PRICEISSHOULDBEGREATERTHANOREQUALZERO"), MsgBoxStyle.Information, Me.Text)
            Return False
        End If

        If Not IsNumeric(txtQuantity.Text) Then
            MsgBox(mv_ResourceManager.GetString("QTTYISNOTNUMBER"), MsgBoxStyle.Information, Me.Text)
            Return False
        ElseIf CDbl(txtQuantity.Text) <= 0 Then
            MsgBox(mv_ResourceManager.GetString("QTTYISSHOULDBEGREATERTHANOREQUALZERO"), MsgBoxStyle.Information, Me.Text)
            Return False
        End If
        Return True
    End Function

#End Region

#Region "Core function"
    '-----------------------------------------------------------------
    'Thực hiện phân bổ khớp lệnh cho một case
    'với 1 custody code
    'N đi ứng với M v?
    'C�ác tham số ảnh hưởng
    'CustodyCD,chứng khoán,mua/bán,số lượng, giá, th?i �điểm đặ lệnh
    'Quy tắc khớp:
    '1: Số lượng khớp tối đa
    '2: ưu tiên giá, mua giá cao, bán giá thấp
    '3: Th?i gian �đặt lệnh
    '4: Khối lượng
    '------------------------------------------------------------------
    Private Function MatchingOrder(ByVal v_intOOD As Integer, ByVal v_intRESULT As Integer, ByRef v_intMatchingOrder As Integer, ByVal v_arrGo() As OODHO, ByVal v_arrBack() As TRADING_RESULTHO, ByRef v_arrMatching() As MatchingOrderHO) As Long
        Dim i, j As Integer
        Dim v_i, v_j, v_k As Integer
        v_i = 0 'Chi so cua v_arrBack
        v_j = 0 'Chi so cua v_arrOOD
        v_k = 0 'Chi so cua v_intMatchingOrder
        ReDim v_arrMatching(v_intRESULT + v_intOOD + 2)
        Do While 1 = 1
            If v_i > v_intRESULT Then
                Exit Do
            End If
            If v_j > v_intOOD Then
                Exit Do
            End If
            If v_arrGo(v_j).QTTY = 0 Then
                v_j = v_j + 1
            End If
            If v_arrBack(v_i).QUANTITY = 0 Then
                v_i = v_i + 1
            End If
            v_arrMatching(v_k) = New MatchingOrderHO
            If v_arrBack(v_i).BORS = v_arrGo(v_j).BORS And v_arrBack(v_i).SEC_CODE = v_arrGo(v_j).SYMBOL And v_arrBack(v_i).CUSTODYCD = v_arrGo(v_j).CUSTODYCD Then
                If v_arrBack(v_i).QUANTITY > v_arrGo(v_j).QTTY Then
                    v_arrMatching(v_k).RESULT_BORS = v_arrBack(v_i).BORS
                    v_arrMatching(v_k).RESULT_CONFIRM_NO = v_arrBack(v_i).CONFIRM_NO
                    v_arrMatching(v_k).RESULT_CUSTODYCD = v_arrBack(v_i).CUSTODYCD
                    v_arrMatching(v_k).RESULT_MATCH_DATE = v_arrBack(v_i).MATCH_DATE
                    v_arrMatching(v_k).RESULT_PRICE = v_arrBack(v_i).PRICE
                    v_arrMatching(v_k).RESULT_QUANTITY = v_arrBack(v_i).OLDQUANTITY
                    v_arrMatching(v_k).RESULT_SEC_CODE = v_arrBack(v_i).SEC_CODE
                    v_arrMatching(v_k).v_strB_ACCOUNT_NO = v_arrBack(v_i).v_strB_ACCOUNT_NO
                    v_arrMatching(v_k).v_strB_ORDER_NO = v_arrBack(v_i).v_strB_ORDER_NO
                    v_arrMatching(v_k).v_strS_ACCOUNT_NO = v_arrBack(v_i).v_strS_ACCOUNT_NO
                    v_arrMatching(v_k).v_strS_ORDER_NO = v_arrBack(v_i).v_strS_ORDER_NO
                    v_arrMatching(v_k).v_strAFACCTNO = v_arrGo(v_j).v_strAFACCTNO
                    v_arrMatching(v_k).v_strCIACCTNO = v_arrGo(v_j).v_strCIACCTNO
                    v_arrMatching(v_k).v_strCLEARCD = v_arrGo(v_j).v_strCLEARCD
                    v_arrMatching(v_k).v_strCLEARDAY = v_arrGo(v_j).v_strCLEARDAY
                    v_arrMatching(v_k).v_strEXECPRICE = v_arrGo(v_j).v_strEXECPRICE
                    v_arrMatching(v_k).v_strEXECQTTY = v_arrGo(v_j).v_strEXECQTTY
                    v_arrMatching(v_k).v_strSEACCTNO = v_arrGo(v_j).v_strSEACCTNO
                    v_arrMatching(v_k).v_strTRADEUNIT = v_arrGo(v_j).v_strTRADEUNIT
                    v_arrMatching(v_k).v_strSECUREDRATIO = v_arrGo(v_j).v_strSECUREDRATIO
                    v_arrMatching(v_k).OOD_AORN = v_arrGo(v_j).AORN
                    v_arrMatching(v_k).OOD_BORS = v_arrGo(v_j).BORS
                    v_arrMatching(v_k).OOD_CODEID = v_arrGo(v_j).CODEID
                    v_arrMatching(v_k).OOD_CUSTODYCD = v_arrGo(v_j).CUSTODYCD
                    v_arrMatching(v_k).OOD_NORP = v_arrGo(j).NORP
                    v_arrMatching(v_k).OOD_ORGORDERID = v_arrGo(v_j).ORGORDERID
                    v_arrMatching(v_k).OOD_QTTY = v_arrGo(v_j).QTTY
                    v_arrMatching(v_k).OOD_SYMBOL = v_arrGo(v_j).SYMBOL
                    v_arrMatching(v_k).MATCHING_QTTY = v_arrGo(v_j).QTTY

                    v_arrBack(v_i).QUANTITY = v_arrBack(v_i).QUANTITY - v_arrGo(v_j).QTTY
                    v_arrGo(v_j).QTTY = 0
                    v_j = v_j + 1
                    v_k = v_k + 1
                ElseIf v_arrBack(v_i).QUANTITY < v_arrGo(v_j).QTTY Then
                    v_arrMatching(v_k).RESULT_BORS = v_arrBack(v_i).BORS
                    v_arrMatching(v_k).RESULT_CONFIRM_NO = v_arrBack(v_i).CONFIRM_NO
                    v_arrMatching(v_k).RESULT_CUSTODYCD = v_arrBack(v_i).CUSTODYCD
                    v_arrMatching(v_k).RESULT_MATCH_DATE = v_arrBack(v_i).MATCH_DATE
                    v_arrMatching(v_k).RESULT_PRICE = v_arrBack(v_i).PRICE
                    v_arrMatching(v_k).RESULT_QUANTITY = v_arrBack(v_i).OLDQUANTITY
                    v_arrMatching(v_k).RESULT_SEC_CODE = v_arrBack(v_i).SEC_CODE
                    v_arrMatching(v_k).v_strB_ACCOUNT_NO = v_arrBack(v_i).v_strB_ACCOUNT_NO
                    v_arrMatching(v_k).v_strB_ORDER_NO = v_arrBack(v_i).v_strB_ORDER_NO
                    v_arrMatching(v_k).v_strS_ACCOUNT_NO = v_arrBack(v_i).v_strS_ACCOUNT_NO
                    v_arrMatching(v_k).v_strS_ORDER_NO = v_arrBack(v_i).v_strS_ORDER_NO
                    v_arrMatching(v_k).v_strAFACCTNO = v_arrGo(v_j).v_strAFACCTNO
                    v_arrMatching(v_k).v_strCIACCTNO = v_arrGo(v_j).v_strCIACCTNO
                    v_arrMatching(v_k).v_strCLEARCD = v_arrGo(v_j).v_strCLEARCD
                    v_arrMatching(v_k).v_strCLEARDAY = v_arrGo(v_j).v_strCLEARDAY
                    v_arrMatching(v_k).v_strEXECPRICE = v_arrGo(v_j).v_strEXECPRICE
                    v_arrMatching(v_k).v_strEXECQTTY = v_arrGo(v_j).v_strEXECQTTY
                    v_arrMatching(v_k).v_strSEACCTNO = v_arrGo(v_j).v_strSEACCTNO
                    v_arrMatching(v_k).v_strTRADEUNIT = v_arrGo(v_j).v_strTRADEUNIT
                    v_arrMatching(v_k).v_strSECUREDRATIO = v_arrGo(v_j).v_strSECUREDRATIO
                    v_arrMatching(v_k).OOD_AORN = v_arrGo(v_j).AORN
                    v_arrMatching(v_k).OOD_BORS = v_arrGo(v_j).BORS
                    v_arrMatching(v_k).OOD_CODEID = v_arrGo(v_j).CODEID
                    v_arrMatching(v_k).OOD_CUSTODYCD = v_arrGo(v_j).CUSTODYCD
                    v_arrMatching(v_k).OOD_NORP = v_arrGo(v_j).NORP
                    v_arrMatching(v_k).OOD_ORGORDERID = v_arrGo(v_j).ORGORDERID
                    v_arrMatching(v_k).OOD_QTTY = v_arrGo(v_j).QTTY
                    v_arrMatching(v_k).OOD_SYMBOL = v_arrGo(v_j).SYMBOL
                    v_arrMatching(v_k).MATCHING_QTTY = v_arrBack(v_i).QUANTITY

                    v_arrGo(v_j).QTTY = v_arrGo(v_j).QTTY - v_arrBack(v_i).QUANTITY
                    v_arrBack(v_i).QUANTITY = 0
                    v_i = v_i + 1
                    v_k = v_k + 1
                ElseIf v_arrBack(v_i).QUANTITY = v_arrGo(v_j).QTTY Then
                    v_arrMatching(v_k).RESULT_BORS = v_arrBack(v_i).BORS
                    v_arrMatching(v_k).RESULT_CONFIRM_NO = v_arrBack(v_i).CONFIRM_NO
                    v_arrMatching(v_k).RESULT_CUSTODYCD = v_arrBack(v_i).CUSTODYCD
                    v_arrMatching(v_k).RESULT_MATCH_DATE = v_arrBack(v_i).MATCH_DATE
                    v_arrMatching(v_k).RESULT_PRICE = v_arrBack(v_i).PRICE
                    v_arrMatching(v_k).RESULT_QUANTITY = v_arrBack(v_i).OLDQUANTITY
                    v_arrMatching(v_k).RESULT_SEC_CODE = v_arrBack(v_i).SEC_CODE
                    v_arrMatching(v_k).v_strB_ACCOUNT_NO = v_arrBack(v_i).v_strB_ACCOUNT_NO
                    v_arrMatching(v_k).v_strB_ORDER_NO = v_arrBack(v_i).v_strB_ORDER_NO
                    v_arrMatching(v_k).v_strS_ACCOUNT_NO = v_arrBack(v_i).v_strS_ACCOUNT_NO
                    v_arrMatching(v_k).v_strS_ORDER_NO = v_arrBack(v_i).v_strS_ORDER_NO
                    v_arrMatching(v_k).v_strAFACCTNO = v_arrGo(v_j).v_strAFACCTNO
                    v_arrMatching(v_k).v_strCIACCTNO = v_arrGo(v_j).v_strCIACCTNO
                    v_arrMatching(v_k).v_strCLEARCD = v_arrGo(v_j).v_strCLEARCD
                    v_arrMatching(v_k).v_strCLEARDAY = v_arrGo(v_j).v_strCLEARDAY
                    v_arrMatching(v_k).v_strEXECPRICE = v_arrGo(v_j).v_strEXECPRICE
                    v_arrMatching(v_k).v_strEXECQTTY = v_arrGo(v_j).v_strEXECQTTY
                    v_arrMatching(v_k).v_strSEACCTNO = v_arrGo(v_j).v_strSEACCTNO
                    v_arrMatching(v_k).v_strTRADEUNIT = v_arrGo(v_j).v_strTRADEUNIT
                    v_arrMatching(v_k).v_strSECUREDRATIO = v_arrGo(v_j).v_strSECUREDRATIO
                    v_arrMatching(v_k).OOD_AORN = v_arrGo(v_j).AORN
                    v_arrMatching(v_k).OOD_BORS = v_arrGo(v_j).BORS
                    v_arrMatching(v_k).OOD_CODEID = v_arrGo(v_j).CODEID
                    v_arrMatching(v_k).OOD_CUSTODYCD = v_arrGo(v_j).CUSTODYCD
                    v_arrMatching(v_k).OOD_NORP = v_arrGo(v_j).NORP
                    v_arrMatching(v_k).OOD_ORGORDERID = v_arrGo(v_j).ORGORDERID
                    v_arrMatching(v_k).OOD_QTTY = v_arrGo(v_j).QTTY
                    v_arrMatching(v_k).OOD_SYMBOL = v_arrGo(v_j).SYMBOL
                    v_arrMatching(v_k).MATCHING_QTTY = v_arrBack(v_i).QUANTITY

                    v_arrGo(v_j).QTTY = 0
                    v_j = v_j + 1
                    v_arrBack(v_i).QUANTITY = 0
                    v_i = v_i + 1
                    v_k = v_k + 1
                End If
            Else
                'v_i = v_i + 1
                'v_j = v_j + 1
                If v_arrBack(v_i).BORS.ToString & v_arrBack(v_i).SEC_CODE.ToString & v_arrBack(v_i).CUSTODYCD.ToString > v_arrGo(v_j).BORS.ToString & v_arrGo(v_j).SYMBOL.ToString & v_arrGo(v_j).CUSTODYCD.ToString Then
                    v_j = v_j + 1
                Else
                    v_i = v_i + 1
                End If
            End If
        Loop
        v_intMatchingOrder = v_k

        'Check dữ liệu trong trading_result
        Dim v_strmessage As String = String.Empty
        For i = 0 To v_intRESULT
            If Not v_arrBack(i) Is Nothing Then
                If v_arrBack(i).QUANTITY > 0 Then
                    v_strmessage = v_strmessage & "[" & v_arrBack(i).SEC_CODE & " :" & v_arrBack(i).CONFIRM_NO & ":" & v_arrBack(i).CUSTODYCD & ":" & v_arrBack(i).BORS & ":" & v_arrBack(i).OLDQUANTITY & "x" & v_arrBack(i).PRICE & "] Remain:" & v_arrBack(i).QUANTITY & ControlChars.CrLf
                End If
            End If
        Next

        If Len(v_strmessage) > 0 Then
            v_strmessage = "Trading result can not be completely allocated!" & ControlChars.CrLf & " Please save files and check errors " & ControlChars.CrLf '& v_strmessage
            MessageBox.Show(v_strmessage)
        End If

        'Export ra file dữ liệu
        If Len(v_strmessage) > 0 Then
            Dim v_dlgSave As New SaveFileDialog
            v_dlgSave.Filter = "Text files (*.txt)|*.txt|Excel files (*.xls)|*.xls|All files (*.*)|*.*"
            v_dlgSave.RestoreDirectory = True
            Dim v_res As DialogResult = v_dlgSave.ShowDialog(Me)
            If v_res = DialogResult.OK Then
                Dim v_strFileName As String = v_dlgSave.FileName '= Me.TellerId & "_" & System.DateTime.Now.Day & System.DateTime.Now.Month & System.DateTime.Now.Year & System.DateTime.Now.Hour & System.DateTime.Now.Minute & System.DateTime.Now.Second & ".csv"
                Dim v_strData As String
                Dim v_streamWriter As New StreamWriter(v_strFileName, False, System.Text.Encoding.Unicode)

                v_strData = "SEC_CODE" & vbTab & "CONFIRM_NO" & vbTab & "CUSTODYCD" & vbTab & "BORS" & vbTab & "RESULT_QUANTITY" & vbTab & "MATCH_PRICE" & vbTab & "" & vbTab & "REMAIN_QUANTITY"
                v_streamWriter.WriteLine(v_strData)
                'Write data
                For i = 0 To v_intRESULT
                    If Not v_arrBack(i) Is Nothing Then
                        If v_arrBack(i).QUANTITY > 0 Then
                            v_strData = v_arrBack(i).SEC_CODE & vbTab & v_arrBack(i).CONFIRM_NO & vbTab & v_arrBack(i).CUSTODYCD & vbTab & v_arrBack(i).BORS & vbTab & v_arrBack(i).OLDQUANTITY & vbTab & v_arrBack(i).PRICE & vbTab & vbTab & v_arrBack(i).QUANTITY & ControlChars.CrLf
                            v_streamWriter.WriteLine(v_strData)
                        End If
                    End If
                Next
                'Close StreamWriter
                v_streamWriter.Close()
            End If
        End If

    End Function


    Private Sub AutoMatching()
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strValue, v_strFLDNAME, v_strTEXT As String
        Try
            'Create message to inquiry object fields
            Dim v_strObjMsg As String
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_strCMD As String

            '?�?c c�ác lệnh trong OOD
            v_strCMD = "SELECT ORGORDERID,CODEID,QTTY,CUSTODYCD,BORS,SYMBOL,NORP,AORN,ODPRICE,TXDATE, TXTIME,AFACCTNO, CIACCTNO, SEACCTNO, CLEARCD, CLEARDAY, TRADEUNIT, EXECQTTY, EXEC_PRICE,SECUREDRATIO,SORTPRICE FROM (SELECT OD.ORGORDERID, OD.CUSTODYCD, OD.BORS, OD.SYMBOL,OD.TXTIME, OD.TXDATE,OD.NORP,OD.CODEID,OD.AORN, " & ControlChars.CrLf _
                    & "OD.PRICE ODPRICE, MST.REMAINQTTY QTTY,OD.SECUREDRATIO , MST.AFACCTNO, MST.CIACCTNO, MST.SEACCTNO, MST.CLEARCD, MST.CLEARDAY, MATCH.TRADEUNIT, MST.EXECQTTY, OD.PRICE EXEC_PRICE, TRADING_DATE, MATCH.CONFIRM_NO, MATCHPRICE, MATCHQTTY,  " & ControlChars.CrLf _
                    & "(CASE WHEN OD.BORS='B' THEN OD.PRICE ELSE -OD.PRICE END) SORTPRICE " & ControlChars.CrLf _
                    & "FROM (SELECT * FROM OOD WHERE OODSTATUS = 'S' AND DELTD <>'Y') OD,ODMAST MST,SECURITIES_INFO SECINFO,  " & ControlChars.CrLf _
                    & "(SELECT TRADING_DATE, CD2.CDCONTENT TRADEUNIT, CONFIRM_NO, B_ACCOUNT_NO CUSTODYCD, 'B' BORS, SEC_CODE SYMBOL, PRICE MATCHPRICE, QUANTITY MATCHQTTY " & ControlChars.CrLf _
                    & "FROM TRADING_RESULT,SYSVAR,SECURITIES_INFO,ALLCODE CD1,ALLCODE CD2,SBSECURITIES SB WHERE TRIM(SEC_CODE)= TRIM(SECURITIES_INFO.SYMBOL) AND GRNAME = 'SYSTEM' AND VARNAME = 'COMPANYCD' AND SUBSTR(B_ACCOUNT_NO,1,3)=VARVALUE " & ControlChars.CrLf _
                    & "AND CD1.CDTYPE='SA' AND CD1.CDNAME='TRADEPLACE' " & ControlChars.CrLf _
                    & "AND CD2.CDTYPE='SA' AND CD2.CDNAME='TRADERATE' " & ControlChars.CrLf _
                    & "AND CD1.CDVAL=CD2.CDVAL AND CD1.CDVAL=SB.TRADEPLACE AND SB.CODEID=SECURITIES_INFO.CODEID AND SB.TRADEPLACE='001' " & ControlChars.CrLf _
                    & "GROUP BY CONFIRM_NO,TRADING_DATE,B_ACCOUNT_NO , SEC_CODE , PRICE , QUANTITY,CD2.CDCONTENT " & ControlChars.CrLf _
                    & "UNION ALL " & ControlChars.CrLf _
                    & "SELECT TRADING_DATE, CD2.CDCONTENT TRADEUNIT, CONFIRM_NO, S_ACCOUNT_NO CUSTODYCD, 'S' BORS, SEC_CODE SYMBOL, PRICE MATCHPRICE, QUANTITY MATCHQTTY " & ControlChars.CrLf _
                    & "FROM TRADING_RESULT,SYSVAR,SECURITIES_INFO,ALLCODE CD1,ALLCODE CD2,SBSECURITIES SB WHERE TRIM(SEC_CODE)= TRIM(SECURITIES_INFO.SYMBOL) AND GRNAME = 'SYSTEM' AND VARNAME = 'COMPANYCD' AND SUBSTR(S_ACCOUNT_NO,1,3)=VARVALUE " & ControlChars.CrLf _
                    & "AND CD1.CDTYPE='SA' AND CD1.CDNAME='TRADEPLACE' " & ControlChars.CrLf _
                    & "AND CD2.CDTYPE='SA' AND CD2.CDNAME='TRADERATE' " & ControlChars.CrLf _
                    & "AND CD1.CDVAL=CD2.CDVAL AND CD1.CDVAL=SB.TRADEPLACE AND SB.CODEID=SECURITIES_INFO.CODEID AND SB.TRADEPLACE='001' " & ControlChars.CrLf _
                    & "GROUP BY CONFIRM_NO,TRADING_DATE,S_ACCOUNT_NO , SEC_CODE , PRICE , QUANTITY,CD2.CDCONTENT ) MATCH " & ControlChars.CrLf _
                    & " " & ControlChars.CrLf _
                    & "WHERE OD.ORGORDERID=MST.ORDERID AND MST.REMAINQTTY>0 AND MST.CODEID=SECINFO.CODEID AND OD.CUSTODYCD=MATCH.CUSTODYCD AND OD.BORS=MATCH.BORS AND OD.SYMBOL=MATCH.SYMBOL " & ControlChars.CrLf _
                    & "AND ((CASE WHEN OD.BORS='B' AND OD.PRICE>=MATCH.MATCHPRICE*MATCH.TRADEUNIT THEN 1 ELSE 0 END)=1 " & ControlChars.CrLf _
                    & "OR (CASE WHEN OD.BORS='S' AND OD.PRICE<=MATCH.MATCHPRICE*MATCH.TRADEUNIT THEN 1 ELSE 0 END)=1) " & ControlChars.CrLf _
                    & "AND MATCH.CONFIRM_NO NOT IN ( SELECT  nvl(substr(CONFIRM_NO,4),'-') FROM IOD WHERE DELTD <>'Y') " & ControlChars.CrLf _
                    & "ORDER BY OD.CUSTODYCD, OD.SYMBOL, OD.BORS, SORTPRICE DESC,OD.TXDATE,OD.TXTIME) GROUP BY ORGORDERID,CODEID,QTTY,CUSTODYCD,BORS,SYMBOL,NORP,AORN,ODPRICE,TXDATE,TXTIME,AFACCTNO, CIACCTNO, SEACCTNO, CLEARCD, CLEARDAY, TRADEUNIT, EXECQTTY, EXEC_PRICE, SECUREDRATIO,SORTPRICE ORDER BY BORS,SYMBOL,CUSTODYCD,SORTPRICE DESC,TXDATE,TXTIME "


            'Lấy thông tin chung v? giao d�ịch

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_OD_ODMAST, gc_ActionInquiry, v_strCMD)
            v_ws.Message(v_strObjMsg)
            'Lưu trữ danh sách tìm kiếm trả v?

            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            mv_intOOD = -1
            If v_nodeList.Count > 0 Then
                ReDim mv_arrOOD(v_nodeList.Count - 1)
            End If
            For i As Integer = 0 To v_nodeList.Count - 1
                mv_intOOD = v_nodeList.Count - 1
                v_strTEXT = vbNullString
                mv_arrOOD(i) = New OODHO
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = Trim(.InnerText.ToString)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "ORGORDERID"
                                mv_arrOOD(i).ORGORDERID = v_strValue
                            Case "CODEID"
                                mv_arrOOD(i).CODEID = v_strValue
                            Case "QTTY"
                                mv_arrOOD(i).QTTY = v_strValue
                            Case "CUSTODYCD"
                                mv_arrOOD(i).CUSTODYCD = v_strValue
                            Case "BORS"
                                mv_arrOOD(i).BORS = v_strValue
                            Case "SYMBOL"
                                mv_arrOOD(i).SYMBOL = v_strValue
                            Case "NORP"
                                mv_arrOOD(i).NORP = v_strValue
                            Case "AORN"
                                mv_arrOOD(i).AORN = v_strValue
                            Case "AFACCTNO"
                                mv_arrOOD(i).v_strAFACCTNO = v_strValue
                            Case "CIACCTNO"
                                mv_arrOOD(i).v_strCIACCTNO = v_strValue
                            Case "SEACCTNO"
                                mv_arrOOD(i).v_strSEACCTNO = v_strValue
                            Case "CLEARCD"
                                mv_arrOOD(i).v_strCLEARCD = v_strValue
                            Case "CLEARDAY"
                                mv_arrOOD(i).v_strCLEARDAY = v_strValue
                            Case "TRADEUNIT"
                                mv_arrOOD(i).v_strTRADEUNIT = v_strValue
                            Case "EXECQTTY"
                                mv_arrOOD(i).v_strEXECQTTY = v_strValue
                            Case "EXEC_PRICE"
                                mv_arrOOD(i).v_strEXECPRICE = v_strValue
                            Case "SECUREDRATIO"
                                mv_arrOOD(i).v_strSECUREDRATIO = v_strValue
                        End Select
                    End With
                Next
            Next

            '�?�?c c�ác lệnh trong TRADING_RESULT

            v_strCMD = "SELECT * FROM (SELECT   MATCH_DATE TXDATE, " & ControlChars.CrLf _
               & "  (CASE WHEN SUBSTR (B_ACCOUNT_NO, 1, 3) = VARVALUE THEN B_ACCOUNT_NO ELSE S_ACCOUNT_NO END) CUSTODYCD, " & ControlChars.CrLf _
               & "  (CASE WHEN SUBSTR (B_ACCOUNT_NO, 1, 3) = VARVALUE THEN 'B' ELSE 'S' END) BORS, " & ControlChars.CrLf _
               & "  SEC_CODE, MATCH_DATE, MATCH_TIME, CONFIRM_NO, QUANTITY-MATCHED_BQTTY QUANTITY, PRICE, " & ControlChars.CrLf _
               & "  (CASE WHEN SUBSTR (B_ACCOUNT_NO, 1, 3) = VARVALUE THEN S_ACCOUNT_NO ELSE B_ACCOUNT_NO END) REFCUSTODYCD, " & ControlChars.CrLf _
               & "  B_ORDER_NO, B_TRADING_ID, B_PC_FLAG, B_ACCOUNT_NO, " & ControlChars.CrLf _
               & "  S_ORDER_NO, S_TRADING_ID, S_PC_FLAG, S_ACCOUNT_NO " & ControlChars.CrLf _
               & "  FROM TRADING_RESULT, SYSVAR ,sbsecurities " & ControlChars.CrLf _
               & "  WHERE TRADING_RESULT.SEC_CODE = sbsecurities.symbol and sbsecurities.TRADEPLACE='001'  and TRADING_RESULT.CONFIRM_NO  NOT IN ( SELECT  nvl(substr(CONFIRM_NO,4),'-') FROM IOD WHERE DELTD <>'Y') and  " & ControlChars.CrLf _
               & "  GRNAME = 'SYSTEM' AND VARNAME = 'COMPANYCD' AND QUANTITY-MATCHED_BQTTY>0 AND SUBSTR (B_ACCOUNT_NO, 1, 3) = VARVALUE  " & ControlChars.CrLf _
               & "  ORDER BY SEC_CODE,CUSTODYCD,PRICE DESC) " & ControlChars.CrLf _
               & "   UNION ALL " & ControlChars.CrLf _
               & " SELECT * FROM (SELECT   MATCH_DATE TXDATE, " & ControlChars.CrLf _
               & "  (CASE WHEN SUBSTR (S_ACCOUNT_NO, 1, 3) = VARVALUE THEN S_ACCOUNT_NO ELSE B_ACCOUNT_NO END) CUSTODYCD, " & ControlChars.CrLf _
               & "  (CASE WHEN SUBSTR (S_ACCOUNT_NO, 1, 3) = VARVALUE THEN 'S' ELSE 'B' END) BORS, " & ControlChars.CrLf _
               & "  SEC_CODE, MATCH_DATE, MATCH_TIME, CONFIRM_NO, QUANTITY-MATCHED_SQTTY QUANTITY, PRICE, " & ControlChars.CrLf _
               & "  (CASE WHEN SUBSTR (B_ACCOUNT_NO, 1, 3) = VARVALUE THEN S_ACCOUNT_NO ELSE B_ACCOUNT_NO END) REFCUSTODYCD, " & ControlChars.CrLf _
               & "  B_ORDER_NO, B_TRADING_ID, B_PC_FLAG, B_ACCOUNT_NO, " & ControlChars.CrLf _
               & "  S_ORDER_NO, S_TRADING_ID, S_PC_FLAG, S_ACCOUNT_NO " & ControlChars.CrLf _
               & "  FROM TRADING_RESULT, SYSVAR ,sbsecurities " & ControlChars.CrLf _
               & "  WHERE TRADING_RESULT.SEC_CODE = sbsecurities.symbol and sbsecurities.TRADEPLACE='001' and TRADING_RESULT.CONFIRM_NO  NOT IN ( SELECT  nvl(substr(CONFIRM_NO,4),'-') FROM IOD WHERE DELTD <>'Y') and  " & ControlChars.CrLf _
               & "  GRNAME = 'SYSTEM' AND VARNAME = 'COMPANYCD' AND QUANTITY-MATCHED_SQTTY>0 AND SUBSTR (S_ACCOUNT_NO, 1, 3) = VARVALUE  " & ControlChars.CrLf _
               & "  ORDER BY SEC_CODE,CUSTODYCD,PRICE ASC) "

            'Lấy thông tin chung v? giao d�ịch
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_OD_ODMAST, gc_ActionInquiry, v_strCMD)
            v_ws.Message(v_strObjMsg)
            'Lưu trữ danh sách tìm kiếm trả v?

            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            mv_intResult = -1
            If v_nodeList.Count > 0 Then
                ReDim mv_arrRusult(v_nodeList.Count - 1)
            End If
            For i As Integer = 0 To v_nodeList.Count - 1
                v_strTEXT = vbNullString
                mv_intResult = v_nodeList.Count - 1
                mv_arrRusult(i) = New TRADING_RESULTHO
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = Trim(.InnerText.ToString)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "BORS"
                                mv_arrRusult(i).BORS = v_strValue
                            Case "CONFIRM_NO"
                                mv_arrRusult(i).CONFIRM_NO = v_strValue
                            Case "CUSTODYCD"
                                mv_arrRusult(i).CUSTODYCD = v_strValue
                            Case "MATCH_DATE"
                                mv_arrRusult(i).MATCH_DATE = v_strValue
                            Case "PRICE"
                                mv_arrRusult(i).PRICE = v_strValue
                            Case "QUANTITY"
                                mv_arrRusult(i).QUANTITY = v_strValue
                                mv_arrRusult(i).OLDQUANTITY = v_strValue
                            Case "SEC_CODE"
                                mv_arrRusult(i).SEC_CODE = v_strValue
                            Case "B_ACCOUNT_NO"
                                mv_arrRusult(i).v_strB_ACCOUNT_NO = v_strValue
                            Case "S_ACCOUNT_NO"
                                mv_arrRusult(i).v_strS_ACCOUNT_NO = v_strValue
                            Case "B_ORDER_NO"
                                mv_arrRusult(i).v_strB_ORDER_NO = v_strValue
                            Case "S_ORDER_NO"
                                mv_arrRusult(i).v_strS_ORDER_NO = v_strValue

                        End Select
                    End With
                Next
            Next


        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Sub
#End Region


#Region " Event "
    Private Sub ReceiveSelectedRowChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'Hi�ển thị thông tin lên màn hình
        If (ODReceiveGrid.CurrentRow Is Nothing) Then
            Exit Sub
        End If
        setGridRowValue(CType(ODReceiveGrid.CurrentRow, Xceed.Grid.DataRow))
        setControlValue()
    End Sub
    Private Sub AutoReceiveSelectedRowChanged(ByVal sender As Object, ByVal e As System.EventArgs)
       
    End Sub
    Private Sub btnReceive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReceive.Click
        If Not Receive_ControlValidation() Then
            Exit Sub
        End If
        OnSubmit(False)
    End Sub
    Private Sub btnReceiveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReceiveAll.Click
        OnSubmit(True)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCANCEL.Click
        OnClose()
    End Sub

    Private Sub lblPrice_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles lblPrice.Validating
        If Not IsNumeric(txtPrice.Text) Then
            MsgBox(mv_ResourceManager.GetString("PRICEISNOTNUMBER"), MsgBoxStyle.Information, Me.Text)
            e.Cancel = True
        ElseIf CDbl(txtPrice.Text) < 0 Then
            MsgBox(mv_ResourceManager.GetString("PRICEISSHOULDBEGREATERTHANOREQUALZERO"), MsgBoxStyle.Information, Me.Text)
            e.Cancel = True
        End If
        If Me.cboBORS.SelectedValue = "B" And mv_strPRICETYPE = "LO" Then
            If CDbl(txtPrice.Text) < mv_strEXPRICE Then
                MsgBox(mv_ResourceManager.GetString("PRICESHOULDBEGREATEROREQUALTOEXPRICE"), MsgBoxStyle.Information, Me.Text)
            End If
        End If
        If Me.cboBORS.SelectedValue = "S" And mv_strPRICETYPE = "LO" Then
            If CDbl(txtPrice.Text) > mv_strEXPRICE Then
                MsgBox(mv_ResourceManager.GetString("PRICESHOULDBESMALLEROREQUALTOEXPRICE"), MsgBoxStyle.Information, Me.Text)
            End If
        End If
    End Sub

    Private Sub lblQuantity_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles lblQuantity.Validating
        If Not IsNumeric(txtQuantity.Text) Then
            MsgBox(mv_ResourceManager.GetString("QTTYISNOTNUMBER"), MsgBoxStyle.Information, Me.Text)
            e.Cancel = True
        ElseIf CDbl(txtQuantity.Text) < 0 Then
            MsgBox(mv_ResourceManager.GetString("QTTYISSHOULDBEGREATERTHANOREQUALZERO"), MsgBoxStyle.Information, Me.Text)
            e.Cancel = True
        End If
    End Sub

    Private Sub frmODReceiveHO_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Select Case e.KeyCode
            Case Keys.Escape
                OnClose()
        End Select
    End Sub

    Private Sub txtQuantity_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtQuantity.Validating
        If Not IsNumeric(txtQuantity.Text) Then
            MsgBox(mv_ResourceManager.GetString("QUANTITYISNOTNUMBER"), MsgBoxStyle.Information, Me.Text)
            e.Cancel = True
        ElseIf CDbl(txtQuantity.Text) < 0 Then
            MsgBox(mv_ResourceManager.GetString("QUANTITYISSHOULDBEGREATERTHANOREQUALZERO"), MsgBoxStyle.Information, Me.Text)
            e.Cancel = True
        End If
        If CDbl(txtQuantity.Text) > mv_strEXQTTY Then
            MsgBox(mv_ResourceManager.GetString("QUANTITYSHOULDBESMALLERTHANEXQTTY"), MsgBoxStyle.Information, Me.Text)
            e.Cancel = True
        End If
        If (CInt(txtQuantity.Text) Mod mv_strTRADELOT > 0) Or CInt(txtQuantity.Text) <> CDbl(txtQuantity.Text) Then
            MsgBox(mv_ResourceManager.GetString("QUANTITYSHOULDBEINTRADELOD"), MsgBoxStyle.Information, Me.Text)
            e.Cancel = True
        End If
    End Sub

    Private Sub txtPrice_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPrice.Validating
        Try
            If Not IsNumeric(txtPrice.Text) Then
                MsgBox(mv_ResourceManager.GetString("PRICEISNOTNUMBER"), MsgBoxStyle.Information, Me.Text)
                e.Cancel = True
            ElseIf CDbl(txtPrice.Text) < 0 Then
                MsgBox(mv_ResourceManager.GetString("PRICEISSHOULDBEGREATERTHANOREQUALZERO"), MsgBoxStyle.Information, Me.Text)
                e.Cancel = True
            End If
            If Me.cboBORS.SelectedValue = "S" And mv_strPRICETYPE = "LO" Then
                If CDbl(txtPrice.Text) < mv_strEXPRICE Then
                    MsgBox(mv_ResourceManager.GetString("PRICESHOULDBEGREATEROREQUALTOEXPRICE"), MsgBoxStyle.Information, Me.Text)
                    e.Cancel = True
                    Exit Sub
                End If
            End If
            If Me.cboBORS.SelectedValue = "B" And mv_strPRICETYPE = "LO" Then
                If CDbl(txtPrice.Text) > mv_strEXPRICE Then
                    MsgBox(mv_ResourceManager.GetString("PRICESHOULDBESMALLEROREQUALTOEXPRICE"), MsgBoxStyle.Information, Me.Text)
                    e.Cancel = True
                    Exit Sub
                End If
            End If

            'Check phai nam trong khoang tran san (tru lenh thoa thuan cua HCM)
            If mv_strTradePlace = "001" And mv_strNORP = "P" Then
                Exit Sub
            Else
                If CDbl(txtPrice.Text) > CDbl(mv_strCeilingPrice) Or CDbl(txtPrice.Text) < CDbl(mv_strFloorPrice) Then
                    MsgBox(mv_ResourceManager.GetString("PRICESHOULDBEINRANGE"), MsgBoxStyle.Information, Me.Text)
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Grid_MATCHQTTYValueChange(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim v_IntIntdex As Integer
        For i As Integer = 0 To ODAutoReceiveGrid.DataRows.Count - 1
            If ODAutoReceiveGrid.DataRows(i) Is CType(sender, Xceed.Grid.DataCell).ParentRow Then
                v_IntIntdex = i
                Exit For
            End If
        Next
        If Not IsNumeric(ODAutoReceiveGrid.CurrentCell.Value) Then
            MsgBox(mv_ResourceManager.GetString("QUANTITYISNOTNUMBER"), MsgBoxStyle.Information, Me.Text)
            ODAutoReceiveGrid.DataRows(v_IntIntdex).Cells("MATCHQTTY").Value = 0
            Exit Sub
        ElseIf CDbl(ODAutoReceiveGrid.CurrentCell.Value) < 0 Then
            MsgBox(mv_ResourceManager.GetString("QUANTITYISSHOULDBEGREATERTHANOREQUALZERO"), MsgBoxStyle.Information, Me.Text)
            ODAutoReceiveGrid.DataRows(v_IntIntdex).Cells("MATCHQTTY").Value = 0
            Exit Sub
        End If
        If CDbl(ODAutoReceiveGrid.CurrentCell.Value) > ODAutoReceiveGrid.DataRows(v_IntIntdex).Cells("QUANTITY").Value Then
            MsgBox(mv_ResourceManager.GetString("QUANTITYSHOULDBESMALLERTHANEXQTTY"), MsgBoxStyle.Information, Me.Text)
            ODAutoReceiveGrid.DataRows(v_IntIntdex).Cells("MATCHQTTY").Value = 0
            Exit Sub
        End If
        If (CInt(ODAutoReceiveGrid.CurrentCell.Value) Mod mv_strTRADELOT > 0) Or CInt(ODAutoReceiveGrid.CurrentCell.Value) <> CDbl(ODAutoReceiveGrid.CurrentCell.Value) Then
            MsgBox(mv_ResourceManager.GetString("QUANTITYSHOULDBEINTRADELOD"), MsgBoxStyle.Information, Me.Text)
            ODAutoReceiveGrid.DataRows(v_IntIntdex).Cells("MATCHQTTY").Value = 0
            Exit Sub
        End If
    End Sub

    Private Sub frmODReceiveHO_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        mv_str_CLAUSE = "  AND CODEID LIKE '%" & Me.cboSCODEID.SelectedValue & "%'  AND BORS LIKE '%" & Me.cboSBORS.SelectedValue & "%'"
        mv_strSQLCMD = "SELECT * FROM (select O.orgorderid,o.codeid,o.symbol,o.custodycd,o.bors,o.norp,o.aorn,o.price,o.qtty," & ControlChars.CrLf _
            & " MTS.clearday,MTS.REMAINQTTY  remainqtty,MTS.execqtty,MTS.clearcd,MTS.seacctno,MTS.ciacctno,MTS.BRATIO," & ControlChars.CrLf _
            & " MTS.afacctno,MTS.PRICETYPE,SEIF.tradelot,SEIF.FLOORPRICE FLOOR_PRICE,SEIF.CEILINGPRICE CEILING_PRICE,SYM.TRADEPLACE,GETDUEDATE(TO_DATE('" & Me.BusDate & "','dd/MM/yyyy'),MTS.CLEARCD,SYM.TRADEPLACE,MTS.CLEARDAY) SETTLEDDAY" & ControlChars.CrLf _
            & " from (SELECT * FROM OOD WHERE OODSTATUS ='S' AND TRIM(BORS) Not In('D','E')) O,odmast MTS, securities_info SEIF, sbsecurities SYM where SYM.CODEID=SEIF.CODEID AND O.DELTD <> 'Y' AND o.codeid = seif.codeid and O.orgorderid=MTS.orderid and O.orgorderid=MTS.orderid and MTS.ORSTATUS<>'3'" & ControlChars.CrLf _
            & " and MTS.REMAINQTTY >0 Order by MTS.remainqtty,MTS.orderid) WHERE 0=0 "
        mv_str_SQLCMD = mv_strSQLCMD & mv_str_CLAUSE

        'mv_strAUTOSQLCMD = "SELECT RES.TXDATE, RES.*,MT.ORGORDERID OODORGORDERID,MT.CODEID OODCODEID,MT.SYMBOL OODSYMBOL,MT.CUSTODYCD OODCUSTODYCD,MT.BORS OODBORS,MT.NORP OODNORP,MT.AORN OODAORN," & _
        '                " MT.clearday, MT.remainqtty, MT.execqtty, MT.price EXEC_PRICE, MT.clearcd, MT.seacctno, MT.ciacctno, MT.afacctno, MT.PRICETYPE,MT.TRADELOT" & _
        '                " FROM(SELECT MATCH_DATE TXDATE,(CASE WHEN SUBSTR(B_ACCOUNT_NO,1,3)=VARVALUE THEN B_ACCOUNT_NO ELSE S_ACCOUNT_NO END) CUSTODYCD, (CASE WHEN SUBSTR(B_ACCOUNT_NO,1,3)=VARVALUE THEN 'B' ELSE 'S' END) BORS, SEC_CODE, MATCH_DATE, MATCH_TIME, CONFIRM_NO, QUANTITY, PRICE, (CASE WHEN SUBSTR(B_ACCOUNT_NO,1,3)=VARVALUE THEN S_ACCOUNT_NO ELSE B_ACCOUNT_NO END) REFCUSTODYCD, B_ORDER_NO, B_TRADING_ID, B_PC_FLAG, B_ACCOUNT_NO, S_ORDER_NO, S_TRADING_ID, S_PC_FLAG, S_ACCOUNT_NO" & _
        '                " FROM TRADING_RESULT, SYSVAR" & _
        '                " WHERE GRNAME='SYSTEM' AND VARNAME='COMPANYCD' ORDER BY MATCH_DATE,CONFIRM_NO)RES  LEFT JOIN" & _
        '                " (select MTS.clearday,MTS.remainqtty,MTS.execqtty,MTS.clearcd,MTS.seacctno,MTS.ciacctno,MTS.afacctno,MTS.PRICETYPE,OOD.*,SECINFO.tradeunit,SECINFO.tradelot from ood,odmast MTS,securities_info SECINFO where OOD.orgorderid=MTS.orderid and MTS.codeid=SECINFO.codeid )MT" & _
        '                " ON (RES.CUSTODYCD=MT.CUSTODYCD AND RES.BORS=MT.BORS AND RES.SEC_CODE=MT.SYMBOL)"
        mv_strAUTOSQLCMD = "SELECT res.txdate, res.*, mt.orgorderid oodorgorderid, mt.codeid oodcodeid," & ControlChars.CrLf _
                        & " mt.symbol oodsymbol, mt.custodycd oodcustodycd, mt.bors oodbors," & ControlChars.CrLf _
                        & " mt.norp oodnorp, mt.aorn oodaorn, mt.clearday, mt.remainqtty," & ControlChars.CrLf _
                        & " mt.execqtty, mt.price exec_price, mt.clearcd, mt.seacctno, mt.ciacctno," & ControlChars.CrLf _
                        & " mt.afacctno, mt.pricetype, mt.tradelot,mt.qtty,mt.tradeunit" & ControlChars.CrLf _
                    & " FROM " & ControlChars.CrLf _
                        & " (SELECT   match_date txdate," & ControlChars.CrLf _
                        & " (CASE WHEN SUBSTR (b_account_no, 1, 3) = varvalue THEN b_account_no ELSE s_account_no END) custodycd," & ControlChars.CrLf _
                        & " (CASE WHEN SUBSTR (b_account_no, 1, 3) = varvalue THEN 'B' ELSE 'S' END) bors," & ControlChars.CrLf _
                        & " sec_code, match_date, match_time, confirm_no, quantity, price," & ControlChars.CrLf _
                        & " (CASE WHEN SUBSTR (b_account_no, 1, 3) = varvalue THEN s_account_no ELSE b_account_no END) refcustodycd," & ControlChars.CrLf _
                        & " b_order_no, b_trading_id, b_pc_flag, b_account_no," & ControlChars.CrLf _
                        & " s_order_no, s_trading_id, s_pc_flag, s_account_no" & ControlChars.CrLf _
                        & " FROM trading_result, sysvar" & ControlChars.CrLf _
                        & " WHERE grname = 'SYSTEM' AND varname = 'COMPANYCD'" & ControlChars.CrLf _
                        & " ORDER BY match_date, confirm_no) res " & ControlChars.CrLf _
                            & " LEFT JOIN (SELECT mts.clearday,mts.remainqtty,mts.execqtty,mts.clearcd,mts.seacctno," & ControlChars.CrLf _
                                            & " mts.ciacctno,mts.afacctno,mts.pricetype,ood.*,secinfo.tradeunit,secinfo.tradelot" & ControlChars.CrLf _
                                        & " FROM ood,odmast mts,securities_info secinfo" & ControlChars.CrLf _
                                        & " WHERE ood.orgorderid =mts.orderid AND mts.codeid = secinfo.codeid) mt " & ControlChars.CrLf _
                                        & " ON (res.custodycd =mt.custodycd AND res.bors = mt.bors AND res.sec_code =mt.symbol)" & ControlChars.CrLf _
                    & " Order by  oodcustodycd,qtty,match_date,match_time"
        LoadODReceive(mv_str_SQLCMD)
        InitDialog()
        'Add any initialization after the InitializeComponent() call
        mv_xmlDocumentInquiryData = New Xml.XmlDocument
    End Sub

    Private Sub btnMatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMatch.Click
        LoadODAutoReceive(mv_strAUTOSQLCMD)
    End Sub

#End Region

    Private Sub cboSCODEID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSCODEID.SelectedValueChanged
        mv_str_CLAUSE = "  AND CODEID LIKE '%" & Me.cboSCODEID.SelectedValue & "%'  AND BORS LIKE '%" & Me.cboSBORS.SelectedValue & "%'"
        mv_str_SQLCMD = mv_strSQLCMD & mv_str_CLAUSE
        LoadODReceive(mv_str_SQLCMD)
    End Sub

    Private Sub cboSBORS_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSBORS.SelectedValueChanged
        mv_str_CLAUSE = "  AND CODEID LIKE '%" & Me.cboSCODEID.SelectedValue & "%'  AND BORS LIKE '%" & Me.cboSBORS.SelectedValue & "%'"
        mv_str_SQLCMD = mv_strSQLCMD & mv_str_CLAUSE
        LoadODReceive(mv_str_SQLCMD)
    End Sub

    Private Sub cboSBORS_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSBORS.SelectedIndexChanged

    End Sub

    Private Sub txtQuantity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQuantity.TextChanged

    End Sub

    Private Sub btnViewTradingResult_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewTradingResult.Click
        Dim mv_frmSearchScreen As New frmSearch(mv_strLanguage)
        mv_frmSearchScreen.TableName = "MATCH_RESULT"
        mv_frmSearchScreen.ModuleCode = "SA"
        mv_frmSearchScreen.AuthCode = "NYNNYYNNNN" 'Chỉ cho phép thực hiện Close và View. Tính năng này cần nâng cấp để kiểm tra quy?n
        mv_frmSearchScreen.IsLocalSearch = gc_IsNotLocalMsg
        mv_frmSearchScreen.IsLookup = "N"
        mv_frmSearchScreen.SearchOnInit = False
        mv_frmSearchScreen.BranchId = Me.BranchId
        mv_frmSearchScreen.TellerId = Me.TellerId
        mv_frmSearchScreen.ShowDialog()
        'Khai bao cac bien cho khop lenh bang tay


        v_objTrading_result.CONFIRM_NO = mv_frmSearchScreen.mv_strCONFIRM_NO
        If mv_strBORS = "B" Then
            v_objTrading_result.CUSTODYCD = mv_frmSearchScreen.mv_strB_CUSTODYCD
        Else
            v_objTrading_result.CUSTODYCD = mv_frmSearchScreen.mv_strS_CUSTODYCD
        End If
        v_objTrading_result.BORS = mv_strBORS
        v_objTrading_result.SEC_CODE = mv_frmSearchScreen.mv_strSEC_CODE
        If mv_strBORS = "B" Then
            v_objTrading_result.QUANTITY = mv_frmSearchScreen.mv_intQUANTITY - mv_frmSearchScreen.mv_intB_QUANTITY
        Else
            v_objTrading_result.QUANTITY = mv_frmSearchScreen.mv_intQUANTITY - mv_frmSearchScreen.mv_intS_QUANTITY
        End If

        v_objTrading_result.OLDQUANTITY = mv_frmSearchScreen.mv_intQUANTITY
        v_objTrading_result.PRICE = mv_frmSearchScreen.mv_dblPRICE
        v_objTrading_result.MATCH_DATE = mv_frmSearchScreen.mv_strMATCH_DATE
        v_objTrading_result.v_strS_ACCOUNT_NO = mv_frmSearchScreen.mv_strS_CUSTODYCD
        v_objTrading_result.v_strB_ACCOUNT_NO = mv_frmSearchScreen.mv_strB_CUSTODYCD
        v_objTrading_result.v_strS_ORDER_NO = mv_frmSearchScreen.v_strS_ORDER_NO
        v_objTrading_result.v_strB_ORDER_NO = mv_frmSearchScreen.v_strB_ORDER_NO
        If Me.mv_strBORS = "B" Then
            Me.txtREFCUSTCD.Text = v_objTrading_result.v_strB_ACCOUNT_NO
        Else
            Me.txtREFCUSTCD.Text = v_objTrading_result.v_strS_ACCOUNT_NO
        End If
        If Me.mv_strBORS = "B" Then
            Me.txtRefOrderID.Text = v_objTrading_result.v_strB_ORDER_NO
        Else
            Me.txtRefOrderID.Text = v_objTrading_result.v_strS_ORDER_NO
        End If
    End Sub

    Private Sub FormatNumericTextbox(ByVal pv_ctrl As TextBox)
        Try
            Dim v_strFormat As String
            Dim v_intDecimal As String

            v_strFormat = "#,##0"
            If (v_strFormat.Length > 0) Then
                If (v_strFormat.IndexOf(".") <> -1) Then
                    v_intDecimal = Mid(v_strFormat, v_strFormat.IndexOf(".") + 2).Length()
                Else
                    v_intDecimal = 0
                End If
            Else
                v_intDecimal = 0
            End If

            If IsNumeric(pv_ctrl.Text) Then
                pv_ctrl.Text = FormatNumber(pv_ctrl.Text, v_intDecimal)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

    End Sub
End Class

Public Class OODHO
#Region " Declaration "
    Private mv_strORGORDERID As String
    Private mv_strCUSTODYCD As String
    Private mv_strBORS As String
    Private mv_strSYMBOL As String
    Private mv_strCODEID As String
    Private mv_strNORP As String
    Private mv_strAORN As String
    Private mv_intQTTY As Integer
    Public v_strAFACCTNO As String
    Public v_strCIACCTNO As String
    Public v_strSEACCTNO As String
    Public v_strCLEARDAY As String
    Public v_strCLEARCD As String
    Public v_strTRADEUNIT As String
    Public v_strEXECQTTY As String
    Public v_strEXECPRICE As String
    Public v_strSECUREDRATIO As String
#End Region

#Region " Constructors and deconstructors "
    Public Sub New()
        mv_strORGORDERID = String.Empty
        mv_strCUSTODYCD = String.Empty
        mv_strBORS = String.Empty
        mv_strSYMBOL = String.Empty
        mv_strCODEID = String.Empty
        mv_strNORP = String.Empty
        mv_strAORN = String.Empty
        mv_intQTTY = 0
    End Sub

    Public Overloads Sub Dispose()
        mv_strORGORDERID = String.Empty
        mv_strCUSTODYCD = String.Empty
        mv_strBORS = String.Empty
        mv_strSYMBOL = String.Empty
        mv_strCODEID = String.Empty
        mv_strNORP = String.Empty
        mv_strAORN = String.Empty
        mv_intQTTY = 0
    End Sub
#End Region

#Region " Properties "
    Public Property ORGORDERID() As String
        Get
            Return mv_strORGORDERID
        End Get
        Set(ByVal Value As String)
            mv_strORGORDERID = Value
        End Set
    End Property

    Public Property CUSTODYCD() As String
        Get
            Return mv_strCUSTODYCD
        End Get
        Set(ByVal Value As String)
            mv_strCUSTODYCD = Value
        End Set
    End Property

    Public Property BORS() As String
        Get
            Return mv_strBORS
        End Get
        Set(ByVal Value As String)
            mv_strBORS = Value
        End Set
    End Property

    Public Property SYMBOL() As String
        Get
            Return mv_strSYMBOL
        End Get
        Set(ByVal Value As String)
            mv_strSYMBOL = Value
        End Set
    End Property

    Public Property CODEID() As String
        Get
            Return mv_strCODEID
        End Get
        Set(ByVal Value As String)
            mv_strCODEID = Value
        End Set
    End Property

    Public Property NORP() As String
        Get
            Return mv_strNORP
        End Get
        Set(ByVal Value As String)
            mv_strNORP = Value
        End Set
    End Property

    Public Property AORN() As String
        Get
            Return mv_strAORN
        End Get
        Set(ByVal Value As String)
            mv_strAORN = Value
        End Set
    End Property

    Public Property QTTY() As String
        Get
            Return mv_intQTTY
        End Get
        Set(ByVal Value As String)
            mv_intQTTY = Value
        End Set
    End Property
#End Region
End Class

Public Class TRADING_RESULTHO
#Region " Declaration "
    Private mv_strCONFIRM_NO As String
    Private mv_strCUSTODYCD As String
    Private mv_strBORS As String
    Private mv_strSEC_CODE As String
    Private mv_intQUANTITY As Integer
    Private mv_intOLDQUANTITY As Integer
    Private mv_dblPRICE As Double
    Private mv_strMATCH_DATE As String
    Public v_strS_ACCOUNT_NO As String
    Public v_strB_ACCOUNT_NO As String
    Public v_strS_ORDER_NO As String
    Public v_strB_ORDER_NO As String

#End Region
#Region " Constructors and deconstructors "
    Public Sub New()
        mv_strCONFIRM_NO = String.Empty
        mv_strCUSTODYCD = String.Empty
        mv_strBORS = String.Empty
        mv_strSEC_CODE = String.Empty
        mv_intQUANTITY = 0
        mv_intOLDQUANTITY = 0
        mv_dblPRICE = 0
        mv_strMATCH_DATE = String.Empty
    End Sub
    Public Overloads Sub Dispose()
        mv_strCONFIRM_NO = String.Empty
        mv_strCUSTODYCD = String.Empty
        mv_strBORS = String.Empty
        mv_strSEC_CODE = String.Empty
        mv_intQUANTITY = 0
        mv_intOLDQUANTITY = 0
        mv_dblPRICE = 0
        mv_strMATCH_DATE = String.Empty
    End Sub
#End Region
#Region " Properties "
    Public Property CONFIRM_NO() As String
        Get
            Return mv_strCONFIRM_NO
        End Get
        Set(ByVal Value As String)
            mv_strCONFIRM_NO = Value
        End Set
    End Property

    Public Property CUSTODYCD() As String
        Get
            Return mv_strCUSTODYCD
        End Get
        Set(ByVal Value As String)
            mv_strCUSTODYCD = Value
        End Set
    End Property

    Public Property BORS() As String
        Get
            Return mv_strBORS
        End Get
        Set(ByVal Value As String)
            mv_strBORS = Value
        End Set
    End Property

    Public Property SEC_CODE() As String
        Get
            Return mv_strSEC_CODE
        End Get
        Set(ByVal Value As String)
            mv_strSEC_CODE = Value
        End Set
    End Property

    Public Property QUANTITY() As Integer
        Get
            Return mv_intQUANTITY
        End Get
        Set(ByVal Value As Integer)
            mv_intQUANTITY = Value
        End Set
    End Property

    Public Property OLDQUANTITY() As Integer
        Get
            Return mv_intOLDQUANTITY
        End Get
        Set(ByVal Value As Integer)
            mv_intOLDQUANTITY = Value
        End Set
    End Property

    Public Property PRICE() As Double
        Get
            Return mv_dblPRICE
        End Get
        Set(ByVal Value As Double)
            mv_dblPRICE = Value
        End Set
    End Property

    Public Property MATCH_DATE() As String
        Get
            Return mv_strMATCH_DATE
        End Get
        Set(ByVal Value As String)
            mv_strMATCH_DATE = Value
        End Set
    End Property
#End Region
End Class

Public Class MatchingOrderHO
#Region " Declaration "
    Private mv_strOOD_ORGORDERID As String
    Private mv_strOOD_CUSTODYCD As String
    Private mv_strOOD_BORS As String
    Private mv_strOOD_SYMBOL As String
    Private mv_strOOD_CODEID As String
    Private mv_strOOD_NORP As String
    Private mv_strOOD_AORN As String
    Private mv_intOOD_QTTY As Integer

    Private mv_strRESULT_CONFIRM_NO As String
    Private mv_strRESULT_CUSTODYCD As String
    Private mv_strRESULT_BORS As String
    Private mv_strRESULT_SEC_CODE As String
    Private mv_intRESULT_QUANTITY As Integer
    Private mv_dblRESULT_PRICE As Double
    Private mv_strRESULT_MATCH_DATE As String

    Private mv_intMATCHING_QTTY As Integer

    Public v_strS_ACCOUNT_NO As String
    Public v_strB_ACCOUNT_NO As String
    Public v_strS_ORDER_NO As String
    Public v_strB_ORDER_NO As String
    Public v_strAFACCTNO As String
    Public v_strCIACCTNO As String
    Public v_strSEACCTNO As String
    Public v_strCLEARDAY As String
    Public v_strCLEARCD As String
    Public v_strTRADEUNIT As String
    Public v_strEXECQTTY As String
    Public v_strEXECPRICE As String
    Public v_strSECUREDRATIO As String

#End Region

#Region " Constructors and deconstructors "
    Public Sub New()
        mv_strOOD_ORGORDERID = String.Empty
        mv_strOOD_CUSTODYCD = String.Empty
        mv_strOOD_BORS = String.Empty
        mv_strOOD_SYMBOL = String.Empty
        mv_strOOD_CODEID = String.Empty
        mv_strOOD_NORP = String.Empty
        mv_strOOD_AORN = String.Empty
        mv_intOOD_QTTY = 0

        mv_strRESULT_CONFIRM_NO = String.Empty
        mv_strRESULT_CUSTODYCD = String.Empty
        mv_strRESULT_BORS = String.Empty
        mv_strRESULT_SEC_CODE = String.Empty
        mv_intRESULT_QUANTITY = 0
        mv_dblRESULT_PRICE = 0
        mv_strRESULT_MATCH_DATE = String.Empty

        mv_intMATCHING_QTTY = 0
    End Sub

    Public Overloads Sub Dispose()
        mv_strOOD_ORGORDERID = String.Empty
        mv_strOOD_CUSTODYCD = String.Empty
        mv_strOOD_BORS = String.Empty
        mv_strOOD_SYMBOL = String.Empty
        mv_strOOD_CODEID = String.Empty
        mv_strOOD_NORP = String.Empty
        mv_strOOD_AORN = String.Empty
        mv_intOOD_QTTY = 0

        mv_strRESULT_CONFIRM_NO = String.Empty
        mv_strRESULT_CUSTODYCD = String.Empty
        mv_strRESULT_BORS = String.Empty
        mv_strRESULT_SEC_CODE = String.Empty
        mv_intRESULT_QUANTITY = 0
        mv_dblRESULT_PRICE = 0
        mv_strRESULT_MATCH_DATE = String.Empty

        mv_intMATCHING_QTTY = 0
    End Sub
#End Region

#Region " Properties "
    Public Property OOD_ORGORDERID() As String
        Get
            Return mv_strOOD_ORGORDERID
        End Get
        Set(ByVal Value As String)
            mv_strOOD_ORGORDERID = Value
        End Set
    End Property

    Public Property OOD_CUSTODYCD() As String
        Get
            Return mv_strOOD_CUSTODYCD
        End Get
        Set(ByVal Value As String)
            mv_strOOD_CUSTODYCD = Value
        End Set
    End Property

    Public Property OOD_BORS() As String
        Get
            Return mv_strOOD_BORS
        End Get
        Set(ByVal Value As String)
            mv_strOOD_BORS = Value
        End Set
    End Property

    Public Property OOD_SYMBOL() As String
        Get
            Return mv_strOOD_SYMBOL
        End Get
        Set(ByVal Value As String)
            mv_strOOD_SYMBOL = Value
        End Set
    End Property

    Public Property OOD_CODEID() As String
        Get
            Return mv_strOOD_CODEID
        End Get
        Set(ByVal Value As String)
            mv_strOOD_CODEID = Value
        End Set
    End Property

    Public Property OOD_NORP() As String
        Get
            Return mv_strOOD_NORP
        End Get
        Set(ByVal Value As String)
            mv_strOOD_NORP = Value
        End Set
    End Property

    Public Property OOD_AORN() As String
        Get
            Return mv_strOOD_AORN
        End Get
        Set(ByVal Value As String)
            mv_strOOD_AORN = Value
        End Set
    End Property

    Public Property OOD_QTTY() As String
        Get
            Return mv_intOOD_QTTY
        End Get
        Set(ByVal Value As String)
            mv_intOOD_QTTY = Value
        End Set
    End Property

    Public Property RESULT_CONFIRM_NO() As String
        Get
            Return mv_strRESULT_CONFIRM_NO
        End Get
        Set(ByVal Value As String)
            mv_strRESULT_CONFIRM_NO = Value
        End Set
    End Property

    Public Property RESULT_CUSTODYCD() As String
        Get
            Return mv_strRESULT_CUSTODYCD
        End Get
        Set(ByVal Value As String)
            mv_strRESULT_CUSTODYCD = Value
        End Set
    End Property

    Public Property RESULT_BORS() As String
        Get
            Return mv_strRESULT_BORS
        End Get
        Set(ByVal Value As String)
            mv_strRESULT_BORS = Value
        End Set
    End Property

    Public Property RESULT_SEC_CODE() As String
        Get
            Return mv_strRESULT_SEC_CODE
        End Get
        Set(ByVal Value As String)
            mv_strRESULT_SEC_CODE = Value
        End Set
    End Property

    Public Property RESULT_QUANTITY() As Integer
        Get
            Return mv_intRESULT_QUANTITY
        End Get
        Set(ByVal Value As Integer)
            mv_intRESULT_QUANTITY = Value
        End Set
    End Property

    Public Property RESULT_PRICE() As Double
        Get
            Return mv_dblRESULT_PRICE
        End Get
        Set(ByVal Value As Double)
            mv_dblRESULT_PRICE = Value
        End Set
    End Property

    Public Property RESULT_MATCH_DATE() As String
        Get
            Return mv_strRESULT_MATCH_DATE
        End Get
        Set(ByVal Value As String)
            mv_strRESULT_MATCH_DATE = Value
        End Set
    End Property

    Public Property MATCHING_QTTY() As Integer
        Get
            Return mv_intMATCHING_QTTY
        End Get
        Set(ByVal Value As Integer)
            mv_intMATCHING_QTTY = Value
        End Set
    End Property
#End Region
End Class