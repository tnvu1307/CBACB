Imports System.Windows.Forms
Imports CommonLibrary
Imports AppCore
Imports _DIRECT.BDSDelivery
Imports System.IO

Public Structure SecurityRecord
    Dim StockNo As Short
    <VBFixedString(8)> Dim StockSymbol As String
    <VBFixedString(1)> Dim StockType As String
    Dim Ceiling As Integer 'Single
    Dim Floor As Integer 'Single
    Dim BigLotValue As Double
    <VBFixedString(25)> Dim SecurityName As String
    Dim SectorNo As Byte
    <VBFixedString(1)> Dim Designated As String
    <VBFixedString(1)> Dim SUSPENSION As String
    <VBFixedString(1)> Dim Delist As String
    <VBFixedString(1)> Dim HaltResumeFlag As String
    <VBFixedString(1)> Dim SPLIT As String
    <VBFixedString(1)> Dim Benefit As String
    <VBFixedString(1)> Dim Meeting As String
    <VBFixedString(1)> Dim Notice As String
    <VBFixedString(1)> Dim ClientIDRequired As String
    Dim CouponRate As Short
    <VBFixedString(6)> Dim IssueDate As String
    <VBFixedString(6)> Dim MatureDate As String
    Dim AvrPrice As Integer 'Single
    Dim ParValue As Short
    <VBFixedString(1)> Dim SDCFlag As String
    Dim PriorClosePrice As Integer 'Single
    <VBFixedString(6)> Dim PriorCloseDate As String
    Dim ProjectOpen As Integer 'Single
    Dim OpenPrice As Integer 'Single
    Dim Last As Integer 'Single
    Dim LastVol As Integer 'Single
    Dim LastVal As Double
    Dim Highest As Integer 'Single
    Dim Lowest As Integer 'Single
    Dim Totalshares As Double
    Dim TotalValue As Double
    Dim AccumulateDeal As Short
    Dim BigDeal As Short
    Dim BigVolume As Integer
    Dim BigValue As Double
    Dim OddDeal As Short
    Dim OddVolume As Integer
    Dim OddValue As Double
    Dim Best1Bid As Integer 'Single
    Dim Best1BidVolume As Integer
    Dim Best2Bid As Integer 'Single
    Dim Best2BidVolume As Integer
    Dim Best3Bid As Integer 'Single
    Dim Best3BidVolume As Integer
    Dim Best1Offer As Integer 'Single
    Dim Best1OfferVolume As Integer
    Dim Best2Offer As Integer 'Single
    Dim Best2OfferVolume As Integer
    Dim Best3Offer As Integer 'Single
    Dim Best3OfferVolume As Integer
    Dim BoardLost As Short
End Structure

Public Class frmUpdateSecInfo
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblCaption As System.Windows.Forms.Label
    Friend WithEvents grbOptions As System.Windows.Forms.GroupBox
    Friend WithEvents grbSources As System.Windows.Forms.GroupBox
    Friend WithEvents radioQuoteSvr As System.Windows.Forms.RadioButton
    Friend WithEvents radioFiles As System.Windows.Forms.RadioButton
    Friend WithEvents grbQuoteSvr As System.Windows.Forms.GroupBox
    Friend WithEvents grbSecInfo As System.Windows.Forms.GroupBox
    Friend WithEvents grbFiles As System.Windows.Forms.GroupBox
    Friend WithEvents pnlSecInfo As System.Windows.Forms.Panel
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnCalc As System.Windows.Forms.Button
    Friend WithEvents btnRead As System.Windows.Forms.Button
    Friend WithEvents lblFromFile As System.Windows.Forms.Label
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents lblTradeUnit As System.Windows.Forms.Label
    Friend WithEvents txtFromFile As System.Windows.Forms.TextBox
    Friend WithEvents txtTradeUnit As System.Windows.Forms.TextBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lblServerAddress As System.Windows.Forms.Label
    Friend WithEvents lblFromCenter As System.Windows.Forms.Label
    Friend WithEvents txtServerAddress As System.Windows.Forms.TextBox
    Friend WithEvents lblSystemTradeUnit As System.Windows.Forms.Label
    Friend WithEvents txtSystemTradeUnit As System.Windows.Forms.TextBox
    Friend WithEvents cboFromCenter As AppCore.ComboBoxEx
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUpdateSecInfo))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblCaption = New System.Windows.Forms.Label
        Me.grbOptions = New System.Windows.Forms.GroupBox
        Me.grbQuoteSvr = New System.Windows.Forms.GroupBox
        Me.cboFromCenter = New AppCore.ComboBoxEx
        Me.txtSystemTradeUnit = New System.Windows.Forms.TextBox
        Me.lblSystemTradeUnit = New System.Windows.Forms.Label
        Me.txtServerAddress = New System.Windows.Forms.TextBox
        Me.lblFromCenter = New System.Windows.Forms.Label
        Me.lblServerAddress = New System.Windows.Forms.Label
        Me.btnCalc = New System.Windows.Forms.Button
        Me.btnRead = New System.Windows.Forms.Button
        Me.grbSources = New System.Windows.Forms.GroupBox
        Me.radioFiles = New System.Windows.Forms.RadioButton
        Me.radioQuoteSvr = New System.Windows.Forms.RadioButton
        Me.grbFiles = New System.Windows.Forms.GroupBox
        Me.txtTradeUnit = New System.Windows.Forms.TextBox
        Me.lblTradeUnit = New System.Windows.Forms.Label
        Me.btnBrowse = New System.Windows.Forms.Button
        Me.txtFromFile = New System.Windows.Forms.TextBox
        Me.lblFromFile = New System.Windows.Forms.Label
        Me.grbSecInfo = New System.Windows.Forms.GroupBox
        Me.pnlSecInfo = New System.Windows.Forms.Panel
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.lblStatus = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.grbOptions.SuspendLayout()
        Me.grbQuoteSvr.SuspendLayout()
        Me.grbSources.SuspendLayout()
        Me.grbFiles.SuspendLayout()
        Me.grbSecInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.Controls.Add(Me.lblCaption)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(794, 50)
        Me.Panel1.TabIndex = 1
        '
        'lblCaption
        '
        Me.lblCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaption.Location = New System.Drawing.Point(8, 16)
        Me.lblCaption.Name = "lblCaption"
        Me.lblCaption.Size = New System.Drawing.Size(776, 16)
        Me.lblCaption.TabIndex = 0
        Me.lblCaption.Tag = "lblCaption"
        Me.lblCaption.Text = "lblCaption"
        '
        'grbOptions
        '
        Me.grbOptions.Controls.Add(Me.grbQuoteSvr)
        Me.grbOptions.Controls.Add(Me.btnCalc)
        Me.grbOptions.Controls.Add(Me.btnRead)
        Me.grbOptions.Controls.Add(Me.grbSources)
        Me.grbOptions.Controls.Add(Me.grbFiles)
        Me.grbOptions.Location = New System.Drawing.Point(5, 56)
        Me.grbOptions.Name = "grbOptions"
        Me.grbOptions.Size = New System.Drawing.Size(784, 104)
        Me.grbOptions.TabIndex = 0
        Me.grbOptions.TabStop = False
        Me.grbOptions.Tag = "grbOptions"
        Me.grbOptions.Text = "grbOptions"
        '
        'grbQuoteSvr
        '
        Me.grbQuoteSvr.Controls.Add(Me.cboFromCenter)
        Me.grbQuoteSvr.Controls.Add(Me.txtSystemTradeUnit)
        Me.grbQuoteSvr.Controls.Add(Me.lblSystemTradeUnit)
        Me.grbQuoteSvr.Controls.Add(Me.txtServerAddress)
        Me.grbQuoteSvr.Controls.Add(Me.lblFromCenter)
        Me.grbQuoteSvr.Controls.Add(Me.lblServerAddress)
        Me.grbQuoteSvr.Location = New System.Drawing.Point(158, 18)
        Me.grbQuoteSvr.Name = "grbQuoteSvr"
        Me.grbQuoteSvr.Size = New System.Drawing.Size(538, 78)
        Me.grbQuoteSvr.TabIndex = 1
        Me.grbQuoteSvr.TabStop = False
        Me.grbQuoteSvr.Tag = "grbQuoteSvr"
        Me.grbQuoteSvr.Text = "grbQuoteSvr"
        '
        'cboFromCenter
        '
        Me.cboFromCenter.DisplayMember = "DISPLAY"
        Me.cboFromCenter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFromCenter.Location = New System.Drawing.Point(104, 48)
        Me.cboFromCenter.Name = "cboFromCenter"
        Me.cboFromCenter.Size = New System.Drawing.Size(200, 21)
        Me.cboFromCenter.TabIndex = 6
        Me.cboFromCenter.Tag = "22"
        Me.cboFromCenter.ValueMember = "VALUE"
        '
        'txtSystemTradeUnit
        '
        Me.txtSystemTradeUnit.Location = New System.Drawing.Point(424, 48)
        Me.txtSystemTradeUnit.Name = "txtSystemTradeUnit"
        Me.txtSystemTradeUnit.Size = New System.Drawing.Size(104, 21)
        Me.txtSystemTradeUnit.TabIndex = 5
        Me.txtSystemTradeUnit.Tag = "txtSystemTradeUnit"
        Me.txtSystemTradeUnit.Text = "txtSystemTradeUnit"
        '
        'lblSystemTradeUnit
        '
        Me.lblSystemTradeUnit.AutoSize = True
        Me.lblSystemTradeUnit.Location = New System.Drawing.Point(312, 50)
        Me.lblSystemTradeUnit.Name = "lblSystemTradeUnit"
        Me.lblSystemTradeUnit.Size = New System.Drawing.Size(99, 13)
        Me.lblSystemTradeUnit.TabIndex = 4
        Me.lblSystemTradeUnit.Tag = "lblSystemTradeUnit"
        Me.lblSystemTradeUnit.Text = "lblSystemTradeUnit"
        '
        'txtServerAddress
        '
        Me.txtServerAddress.Location = New System.Drawing.Point(104, 24)
        Me.txtServerAddress.Name = "txtServerAddress"
        Me.txtServerAddress.Size = New System.Drawing.Size(424, 21)
        Me.txtServerAddress.TabIndex = 2
        Me.txtServerAddress.Tag = "txtServerAddress"
        Me.txtServerAddress.Text = "txtServerAddress"
        '
        'lblFromCenter
        '
        Me.lblFromCenter.AutoSize = True
        Me.lblFromCenter.Location = New System.Drawing.Point(40, 50)
        Me.lblFromCenter.Name = "lblFromCenter"
        Me.lblFromCenter.Size = New System.Drawing.Size(74, 13)
        Me.lblFromCenter.TabIndex = 1
        Me.lblFromCenter.Tag = "lblFromCenter"
        Me.lblFromCenter.Text = "lblFromCenter"
        '
        'lblServerAddress
        '
        Me.lblServerAddress.AutoSize = True
        Me.lblServerAddress.Location = New System.Drawing.Point(8, 24)
        Me.lblServerAddress.Name = "lblServerAddress"
        Me.lblServerAddress.Size = New System.Drawing.Size(88, 13)
        Me.lblServerAddress.TabIndex = 0
        Me.lblServerAddress.Tag = "lblServerAddress"
        Me.lblServerAddress.Text = "lblServerAddress"
        '
        'btnCalc
        '
        Me.btnCalc.Location = New System.Drawing.Point(701, 52)
        Me.btnCalc.Name = "btnCalc"
        Me.btnCalc.Size = New System.Drawing.Size(75, 23)
        Me.btnCalc.TabIndex = 3
        Me.btnCalc.Tag = "btnCalc"
        Me.btnCalc.Text = "btnCalc"
        '
        'btnRead
        '
        Me.btnRead.Location = New System.Drawing.Point(701, 24)
        Me.btnRead.Name = "btnRead"
        Me.btnRead.Size = New System.Drawing.Size(75, 23)
        Me.btnRead.TabIndex = 2
        Me.btnRead.Tag = "btnRead"
        Me.btnRead.Text = "btnRead"
        '
        'grbSources
        '
        Me.grbSources.Controls.Add(Me.radioFiles)
        Me.grbSources.Controls.Add(Me.radioQuoteSvr)
        Me.grbSources.Location = New System.Drawing.Point(8, 18)
        Me.grbSources.Name = "grbSources"
        Me.grbSources.Size = New System.Drawing.Size(144, 78)
        Me.grbSources.TabIndex = 0
        Me.grbSources.TabStop = False
        Me.grbSources.Tag = "grbSources"
        Me.grbSources.Text = "grbSources"
        '
        'radioFiles
        '
        Me.radioFiles.Location = New System.Drawing.Point(8, 47)
        Me.radioFiles.Name = "radioFiles"
        Me.radioFiles.Size = New System.Drawing.Size(128, 21)
        Me.radioFiles.TabIndex = 1
        Me.radioFiles.Tag = "radioFiles"
        Me.radioFiles.Text = "radioFiles"
        '
        'radioQuoteSvr
        '
        Me.radioQuoteSvr.Location = New System.Drawing.Point(8, 24)
        Me.radioQuoteSvr.Name = "radioQuoteSvr"
        Me.radioQuoteSvr.Size = New System.Drawing.Size(128, 21)
        Me.radioQuoteSvr.TabIndex = 0
        Me.radioQuoteSvr.Tag = "radioQuoteSvr"
        Me.radioQuoteSvr.Text = "radioQuoteSvr"
        '
        'grbFiles
        '
        Me.grbFiles.Controls.Add(Me.txtTradeUnit)
        Me.grbFiles.Controls.Add(Me.lblTradeUnit)
        Me.grbFiles.Controls.Add(Me.btnBrowse)
        Me.grbFiles.Controls.Add(Me.txtFromFile)
        Me.grbFiles.Controls.Add(Me.lblFromFile)
        Me.grbFiles.Location = New System.Drawing.Point(158, 18)
        Me.grbFiles.Name = "grbFiles"
        Me.grbFiles.Size = New System.Drawing.Size(538, 78)
        Me.grbFiles.TabIndex = 1
        Me.grbFiles.TabStop = False
        Me.grbFiles.Tag = "grbFiles"
        Me.grbFiles.Text = "grbFiles"
        '
        'txtTradeUnit
        '
        Me.txtTradeUnit.Location = New System.Drawing.Point(466, 48)
        Me.txtTradeUnit.Name = "txtTradeUnit"
        Me.txtTradeUnit.Size = New System.Drawing.Size(64, 21)
        Me.txtTradeUnit.TabIndex = 2
        Me.txtTradeUnit.Text = "txtTradeUnit"
        Me.txtTradeUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTradeUnit
        '
        Me.lblTradeUnit.Location = New System.Drawing.Point(466, 24)
        Me.lblTradeUnit.Name = "lblTradeUnit"
        Me.lblTradeUnit.Size = New System.Drawing.Size(64, 21)
        Me.lblTradeUnit.TabIndex = 3
        Me.lblTradeUnit.Tag = "lblTradeUnit"
        Me.lblTradeUnit.Text = "lblTradeUnit"
        Me.lblTradeUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(429, 48)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(30, 21)
        Me.btnBrowse.TabIndex = 1
        Me.btnBrowse.Tag = "btnBrowse"
        Me.btnBrowse.Text = "..."
        '
        'txtFromFile
        '
        Me.txtFromFile.Location = New System.Drawing.Point(8, 48)
        Me.txtFromFile.Name = "txtFromFile"
        Me.txtFromFile.Size = New System.Drawing.Size(416, 21)
        Me.txtFromFile.TabIndex = 0
        Me.txtFromFile.Text = "txtFromFile"
        '
        'lblFromFile
        '
        Me.lblFromFile.Location = New System.Drawing.Point(8, 24)
        Me.lblFromFile.Name = "lblFromFile"
        Me.lblFromFile.Size = New System.Drawing.Size(416, 21)
        Me.lblFromFile.TabIndex = 0
        Me.lblFromFile.Tag = "lblFromFile"
        Me.lblFromFile.Text = "lblFromFile"
        Me.lblFromFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grbSecInfo
        '
        Me.grbSecInfo.Controls.Add(Me.pnlSecInfo)
        Me.grbSecInfo.Location = New System.Drawing.Point(5, 166)
        Me.grbSecInfo.Name = "grbSecInfo"
        Me.grbSecInfo.Size = New System.Drawing.Size(784, 375)
        Me.grbSecInfo.TabIndex = 1
        Me.grbSecInfo.TabStop = False
        Me.grbSecInfo.Tag = "grbSecInfo"
        Me.grbSecInfo.Text = "grbSecInfo"
        '
        'pnlSecInfo
        '
        Me.pnlSecInfo.Location = New System.Drawing.Point(8, 24)
        Me.pnlSecInfo.Name = "pnlSecInfo"
        Me.pnlSecInfo.Size = New System.Drawing.Size(768, 342)
        Me.pnlSecInfo.TabIndex = 0
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(632, 547)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Tag = "btnOK"
        Me.btnOK.Text = "btnOK"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(714, 547)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Tag = "btnCancel"
        Me.btnCancel.Text = "btnCancel"
        '
        'lblStatus
        '
        Me.lblStatus.Location = New System.Drawing.Point(5, 547)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(603, 21)
        Me.lblStatus.TabIndex = 6
        Me.lblStatus.Tag = "lblStatus"
        Me.lblStatus.Text = "lblStatus"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmUpdateSecInfo
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(794, 575)
        Me.Controls.Add(Me.grbSecInfo)
        Me.Controls.Add(Me.grbOptions)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUpdateSecInfo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmUpdateSecInfo"
        Me.Panel1.ResumeLayout(False)
        Me.grbOptions.ResumeLayout(False)
        Me.grbQuoteSvr.ResumeLayout(False)
        Me.grbQuoteSvr.PerformLayout()
        Me.grbSources.ResumeLayout(False)
        Me.grbFiles.ResumeLayout(False)
        Me.grbFiles.PerformLayout()
        Me.grbSecInfo.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Constants and variables declaration "
    Const c_RESOURCE_MANAGER = "_DIRECT.frmUpdateSecInfo-"
    Const c_TRADE_UNIT_DEFAULT = "1"
    Const c_FILE_FORMAT_DAT = ".dat"
    Const c_FILE_FORMAT_XML = ".xml"
    Const c_TRADEPLACE_ALL = "000"
    Const c_TRADEPLACE_HOSTC = "001"
    Const c_TRADEPLACE_HASTC = "002"
    Const c_TRADEPLACE_OTC = "003"

    Private mv_resourceManager As Resources.ResourceManager
    Private mv_strLanguage As String
    Private mv_gridSecInfo As GridEx
    Private mv_strDBLinkName As String
    Private mv_strDBLinkDesc As String
#End Region

#Region " Properties "
    Public Property ResourceManager() As Resources.ResourceManager
        Get
            Return mv_resourceManager
        End Get
        Set(ByVal Value As Resources.ResourceManager)
            mv_resourceManager = Value
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


#End Region

#Region " Private methods "
    Private Sub InitDialog()
        Try
            'Add form's events
            AddHandler radioQuoteSvr.CheckedChanged, AddressOf RadioButton_CheckedChanged
            AddHandler radioFiles.CheckedChanged, AddressOf RadioButton_CheckedChanged

            AddHandler btnCancel.Click, AddressOf Button_Click
            AddHandler btnOK.Click, AddressOf Button_Click
            AddHandler btnRead.Click, AddressOf Button_Click
            AddHandler btnCalc.Click, AddressOf Button_Click
            AddHandler btnBrowse.Click, AddressOf Button_Click

            'Load resource and user's interface
            ResourceManager = New Resources.ResourceManager(c_RESOURCE_MANAGER & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
            LoadUserInterface(Me)
            InitSecInfoGrid()

            'Set default value for controls
            radioQuoteSvr.Checked = True
            lblStatus.Text = vbNullString
            txtTradeUnit.Text = c_TRADE_UNIT_DEFAULT

            'Init data for groupbox QuoteServer 
            SetupServerParameter()
            FillDataForComboBox()
            txtSystemTradeUnit.Text = c_TRADE_UNIT_DEFAULT
            txtServerAddress.Text = mv_strDBLinkDesc
            txtServerAddress.Enabled = False
            txtSystemTradeUnit.Enabled = False

        Catch ex As Exception
            LogError.Write("Error source: @DIRECT.frmUpdateSecInfo.InitDialog" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub LoadUserInterface(ByRef pv_ctrl As Windows.Forms.Control)
        Dim v_ctrl As Windows.Forms.Control

        Try
            For Each v_ctrl In pv_ctrl.Controls
                If TypeOf (v_ctrl) Is Label Then
                    CType(v_ctrl, Label).Text = ResourceManager.GetString(v_ctrl.Tag)
                ElseIf TypeOf (v_ctrl) Is Button Then
                    CType(v_ctrl, Button).Text = ResourceManager.GetString(v_ctrl.Tag)
                ElseIf TypeOf (v_ctrl) Is Panel Then
                    LoadUserInterface(v_ctrl)
                ElseIf TypeOf (v_ctrl) Is GroupBox Then
                    CType(v_ctrl, GroupBox).Text = ResourceManager.GetString(v_ctrl.Tag)
                    LoadUserInterface(v_ctrl)
                ElseIf TypeOf (v_ctrl) Is TabControl Then
                    For Each v_ctrlTmp As Control In CType(v_ctrl, TabControl).TabPages
                        CType(v_ctrlTmp, TabPage).Text = ResourceManager.GetString(v_ctrlTmp.Tag)
                    Next
                    LoadUserInterface(v_ctrl)
                ElseIf TypeOf (v_ctrl) Is TabPage Then
                    v_ctrl.BackColor = System.Drawing.SystemColors.InactiveCaptionText
                    CType(v_ctrl, TabPage).Text = ResourceManager.GetString(v_ctrl.Tag)
                    LoadUserInterface(v_ctrl)
                ElseIf TypeOf (v_ctrl) Is TextBox Then
                    CType(v_ctrl, TextBox).Text = vbNullString
                ElseIf TypeOf (v_ctrl) Is RadioButton Then
                    CType(v_ctrl, RadioButton).Text = ResourceManager.GetString(v_ctrl.Tag)
                End If
            Next
            'Load caption của form, label caption
            If (Me.Text.Trim() = String.Empty) Or (Me.Text.Trim() = Me.Name) Then
                Me.Text = ResourceManager.GetString(Me.Name)
            End If
            lblCaption.Text = ResourceManager.GetString(lblCaption.Tag)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OnClose()
        Me.Close()
    End Sub

    Private Sub InitSecInfoGrid()
        Try
            'Create new instance of GridEx
            mv_gridSecInfo = New GridEx
            mv_gridSecInfo.Dock = DockStyle.Fill

            Dim v_cmrHeader As New Xceed.Grid.ColumnManagerRow
            v_cmrHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
            v_cmrHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            v_cmrHeader.HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center

            mv_gridSecInfo.FixedHeaderRows.Add(v_cmrHeader)

            'Add column for grid
            With mv_gridSecInfo.Columns
                .Add(New Xceed.Grid.Column("SYMBOL", GetType(System.String)))
                .Add(New Xceed.Grid.Column("CODEID", GetType(System.String)))
                .Add(New Xceed.Grid.Column("TRADECD", GetType(System.String)))
                .Add(New Xceed.Grid.Column("TRADE_PLACE", GetType(System.String)))
                .Add(New Xceed.Grid.Column("REF_PRICE", GetType(System.Decimal)))
                .Add(New Xceed.Grid.Column("OPEN_PRICE", GetType(System.Decimal)))
                .Add(New Xceed.Grid.Column("FLOOR_PRICE", GetType(System.Decimal)))
                .Add(New Xceed.Grid.Column("CEILING_PRICE", GetType(System.Decimal)))
                .Add(New Xceed.Grid.Column("CURRENT_PRICE", GetType(System.Decimal)))
                .Add(New Xceed.Grid.Column("AVG_PRICE", GetType(System.Decimal)))
                .Add(New Xceed.Grid.Column("CLOSE_PRICE", GetType(System.Decimal)))
            End With
            mv_gridSecInfo.Columns(0).ReadOnly = True
            mv_gridSecInfo.Columns("CODEID").Visible = False
            mv_gridSecInfo.Columns("TRADECD").Visible = False
            For i As Integer = 4 To mv_gridSecInfo.Columns.Count - 1
                mv_gridSecInfo.Columns(i).ReadOnly = False
                mv_gridSecInfo.Columns(i).FormatSpecifier = "#,##0"
            Next

            'Load current securities information
            Dim v_strSQL As String = "SELECT S.SYMBOL SYMBOL, S.CODEID CODEID, S.TRADEPLACE TRADECD, A.CDCONTENT TRADE_PLACE, SI.BASICPRICE REF_PRICE, SI.OPENPRICE OPEN_PRICE, " _
                & "SI.FLOORPRICE FLOOR_PRICE, SI.CEILINGPRICE CEILING_PRICE, SI.CURRPRICE CURRENT_PRICE, SI.AVGPRICE AVG_PRICE, SI.CLOSEPRICE CLOSE_PRICE " _
                & "FROM SBSECURITIES S, SECURITIES_INFO SI, ALLCODE A " _
                & "WHERE S.CODEID = SI.CODEID AND A.CDTYPE = 'SA' AND A.CDNAME = 'TRADEPLACE' AND S.TRADEPLACE = A.CDVAL " _
                & "ORDER BY S.SYMBOL"

            FillDataToGrid(v_strSQL, mv_gridSecInfo)
        Catch ex As Exception
            LogError.Write("Error source: @DIRECT.frmUpdateSecInfo.InitSecInfoGrid" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            Throw ex
        End Try
    End Sub

    Private Sub OnSave()
        Try
            Dim v_strCodeId As String
            Dim v_decRefPrice, v_decOpenPrice, v_decFloorPrice, v_decCeilingPrice, v_decCurrPrice, v_decAvgPrice, v_decClosePrice As Decimal

            If (MessageBox.Show(ResourceManager.GetString("SAVE_CONFIRMATION"), gc_ApplicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                'TruongLD Comment when convert
                'v_ws.Timeout = gc_WEB_SERVICE_TIMEOUT
                Dim v_strSQL, v_strObjMsg As String

                For i As Integer = 0 To mv_gridSecInfo.DataRows.Count - 1
                    With mv_gridSecInfo.DataRows(i)
                        lblStatus.Text = ResourceManager.GetString("SAVING_STATUS").Replace("@", FormatNumber(i + 1, 0) & "/" _
                            & FormatNumber(mv_gridSecInfo.DataRows.Count, 0))

                        If (Not .Cells("CODEID").Value Is Nothing) Then
                            v_strCodeId = .Cells("CODEID").Value.ToString().Trim()
                        Else
                            v_strCodeId = vbNullString
                        End If
                        If (Not .Cells("REF_PRICE").Value Is Nothing) Then
                            v_decRefPrice = gf_CorrectNumericField(.Cells("REF_PRICE").Value.ToString().Trim())
                        Else
                            v_decRefPrice = 0
                        End If
                        If (Not .Cells("OPEN_PRICE").Value Is Nothing) Then
                            v_decOpenPrice = gf_CorrectNumericField(.Cells("OPEN_PRICE").Value.ToString().Trim())
                        Else
                            v_decOpenPrice = 0
                        End If
                        If (Not .Cells("FLOOR_PRICE").Value Is Nothing) Then
                            v_decFloorPrice = gf_CorrectNumericField(.Cells("FLOOR_PRICE").Value.ToString().Trim())
                        Else
                            v_decFloorPrice = 0
                        End If
                        If (Not .Cells("CEILING_PRICE").Value Is Nothing) Then
                            v_decCeilingPrice = gf_CorrectNumericField(.Cells("CEILING_PRICE").Value.ToString().Trim())
                        Else
                            v_decCeilingPrice = 0
                        End If
                        If (Not .Cells("CURRENT_PRICE").Value Is Nothing) Then
                            v_decCurrPrice = gf_CorrectNumericField(.Cells("CURRENT_PRICE").Value.ToString().Trim())
                        Else
                            v_decCurrPrice = 0
                        End If
                        If (Not .Cells("AVG_PRICE").Value Is Nothing) Then
                            v_decAvgPrice = gf_CorrectNumericField(.Cells("AVG_PRICE").Value.ToString().Trim())
                        Else
                            v_decAvgPrice = 0
                        End If
                        If (Not .Cells("CLOSE_PRICE").Value Is Nothing) Then
                            v_decClosePrice = gf_CorrectNumericField(.Cells("CLOSE_PRICE").Value.ToString().Trim())
                        Else
                            v_decClosePrice = 0
                        End If

                        v_strSQL = "UPDATE SECURITIES_INFO SET " _
                            & "BASICPRICE = " & v_decRefPrice.ToString() & ", " _
                            & "OPENPRICE = " & v_decOpenPrice.ToString() & ", " _
                            & "FLOORPRICE = " & v_decFloorPrice.ToString() & ", " _
                            & "CEILINGPRICE = " & v_decCeilingPrice.ToString() & ", " _
                            & "CURRPRICE = " & v_decCurrPrice.ToString() & ", " _
                            & "AVGPRICE = " & v_decAvgPrice.ToString() & ", " _
                            & "CLOSEPRICE = " & v_decClosePrice.ToString() & " " _
                            & "WHERE CODEID = '" & v_strCodeId & "'"
                        v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_SECURITIES_INFO, _
                            gc_ActionAdhoc, , , "UpdateSecInfoByCode", , , v_strSQL)
                        v_ws.Message(v_strObjMsg)
                    End With
                Next
                'TruongLD Comment when convert
                'v_ws.Dispose()
                lblStatus.Text = ResourceManager.GetString("SAVED_STATUS")
                MessageBox.Show(lblStatus.Text, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            LogError.Write("Error source: @DIRECT.frmUpdateSecInfo.OnSave" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub OnRead()
        Try
            If (radioQuoteSvr.Checked) And (Not radioFiles.Checked) Then
                'Read data from Quote Server
                ReadSecInfoFromQuoteSvr()
            ElseIf (Not radioQuoteSvr.Checked) And (radioFiles.Checked) Then
                'Read data from files
                ReadSecInfoFromFiles()
            End If
        Catch ex As Exception
            LogError.Write("Error source: @DIRECT.frmUpdateSecInfo.OnRead" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub OnCalc()
        Try
            If (MessageBox.Show(ResourceManager.GetString("CALC_CONFIRMATION"), gc_ApplicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                'Save du lieu hien tai vao trong database
                OnSave()
                'Disable Grid cho den khi tinh toan xong
                'Goi thu tuc tinh toan dua tren cac thong so dau vao

            End If
        Catch ex As Exception
            LogError.Write("Error source: @DIRECT.frmUpdateSecInfo.OnCalc" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub OnBrowser()
        Try
            Dim v_dlgOpen As New OpenFileDialog
            v_dlgOpen.Filter = "DAT files (*.dat)|*.dat|XML files (*.xml)|*.xml|All files (*.*)|*.*"
            v_dlgOpen.RestoreDirectory = True

            Dim v_res As DialogResult = v_dlgOpen.ShowDialog(Me)
            If v_res = DialogResult.OK Then
                txtFromFile.Text = v_dlgOpen.FileName
            End If
        Catch ex As Exception
            LogError.Write("Error source: @DIRECT.frmUpdateSecInfo.OnBrowser" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ReadSecInfoFromQuoteSvr()
        Try
            Dim v_strSymbol As String
            Dim v_decRefPrice, v_decOpenPrice, v_decFloorPrice, v_decCeilingPrice, v_decCurrPrice, v_decAvgPrice, v_decClosePrice As Decimal
            Dim v_strTradePlace As String
            Dim v_decTradeUnit As Decimal

            If (txtServerAddress.Text.Trim.Length > 0) Then
                If (Not IsNumeric(txtTradeUnit.Text)) Then
                    MessageBox.Show(ResourceManager.GetString("TRADEUNIT_MUST_NUMERIC"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtTradeUnit.Focus()
                    Exit Sub
                Else
                    v_decTradeUnit = CDec(txtTradeUnit.Text.Trim())
                    v_strTradePlace = cboFromCenter.SelectedValue

                    'Lay thong tin 
                    Select Case v_strTradePlace
                        Case c_TRADEPLACE_HASTC
                            GetDataFromHa(v_decTradeUnit)
                        Case c_TRADEPLACE_HOSTC
                            GetDataFromHo(v_decTradeUnit)
                        Case c_TRADEPLACE_ALL
                            GetDataFromAllCenter()
                        Case c_TRADEPLACE_OTC
                            GetDataFromOTC()
                    End Select
                End If
            Else
                'Message box here : cannot find server address
            End If
        Catch ex As Exception
            LogError.Write("Error source: @DIRECT.frmUpdateSecInfo.ReadSecInfoFromQuoteSvr" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ReadSecInfoFromFiles()
        Try
            Dim v_strSymbol As String
            Dim v_decRefPrice, v_decOpenPrice, v_decFloorPrice, v_decCeilingPrice, v_decCurrPrice, v_decAvgPrice, v_decClosePrice As Decimal
            Dim v_strTradePlace As String
            Dim v_decTradeUnit As Decimal

            If (txtFromFile.Text.Trim.Length > 0) Then
                If (Not IsNumeric(txtTradeUnit.Text)) Then
                    MessageBox.Show(ResourceManager.GetString("TRADEUNIT_MUST_NUMERIC"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtTradeUnit.Focus()
                    Exit Sub
                Else
                    v_decTradeUnit = CDec(txtTradeUnit.Text.Trim())
                End If

                Dim v_strFileName As String = txtFromFile.Text.Trim()
                Dim v_strFileType As String = v_strFileName.Substring(v_strFileName.Length - 4).ToUpper()

                Select Case v_strFileType
                    Case c_FILE_FORMAT_DAT.ToUpper()
                        If (MessageBox.Show(ResourceManager.GetString("READ_CONFIRMATION").Replace("@", v_strFileName), gc_ApplicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                            'Kiem tra file co ton tai hay khong
                            If (Not File.Exists(v_strFileName)) Then
                                MessageBox.Show(ResourceManager.GetString("FILENAME_MUST_VALID"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                txtFromFile.Focus()
                                Exit Sub
                            End If

                            v_strTradePlace = c_TRADEPLACE_HOSTC

                            Dim v_intFile As Integer
                            Dim v_recordSecu As SecurityRecord

                            v_intFile = FreeFile()
                            FileOpen(v_intFile, v_strFileName, OpenMode.Random, OpenAccess.Read, OpenShare.Shared, Len(v_recordSecu))
                            While Not EOF(v_intFile)
                                FileGet(v_intFile, v_recordSecu)

                                With v_recordSecu
                                    v_strSymbol = .StockSymbol.Trim()
                                    v_decRefPrice = gf_CorrectNumericField(.PriorClosePrice) * v_decTradeUnit
                                    v_decOpenPrice = gf_CorrectNumericField(.OpenPrice) * v_decTradeUnit
                                    v_decFloorPrice = gf_CorrectNumericField(.Floor) * v_decTradeUnit
                                    v_decCeilingPrice = gf_CorrectNumericField(.Ceiling) * v_decTradeUnit
                                    v_decCurrPrice = 0 * v_decTradeUnit
                                    v_decAvgPrice = gf_CorrectNumericField(.AvrPrice) * v_decTradeUnit
                                    v_decClosePrice = gf_CorrectNumericField(.Last) * v_decTradeUnit
                                End With

                                For j As Integer = 0 To mv_gridSecInfo.DataRows.Count - 1
                                    With mv_gridSecInfo.DataRows.Item(j)
                                        If (.Cells("SYMBOL").Value.ToString() = v_strSymbol) And (.Cells("TRADECD").Value.ToString() = v_strTradePlace) Then
                                            .BeginEdit()

                                            .Cells("REF_PRICE").Value = v_decRefPrice
                                            .Cells("OPEN_PRICE").Value = v_decOpenPrice
                                            .Cells("FLOOR_PRICE").Value = v_decFloorPrice
                                            .Cells("CEILING_PRICE").Value = v_decCeilingPrice
                                            .Cells("CURRENT_PRICE").Value = v_decCurrPrice
                                            .Cells("AVG_PRICE").Value = v_decAvgPrice
                                            .Cells("CLOSE_PRICE").Value = v_decClosePrice

                                            .EndEdit()
                                            Exit For
                                        End If
                                    End With
                                Next j
                            End While
                            FileClose(v_intFile)

                            MessageBox.Show(ResourceManager.GetString("READ_FILE_SUCCESSFULLY").Replace("@", v_strFileName), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    Case c_FILE_FORMAT_XML.ToUpper()
                        If (MessageBox.Show(ResourceManager.GetString("READ_CONFIRMATION").Replace("@", v_strFileName), gc_ApplicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                            'Kiem tra file co ton tai hay khong
                            If (Not File.Exists(v_strFileName)) Then
                                MessageBox.Show(ResourceManager.GetString("FILENAME_MUST_VALID"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                txtFromFile.Focus()
                                Exit Sub
                            End If

                            v_strTradePlace = c_TRADEPLACE_HASTC

                            Dim v_xmlDocument As New XmlDocumentEx
                            Dim v_nodeList As Xml.XmlNodeList

                            v_xmlDocument.Load(v_strFileName)
                            v_nodeList = v_xmlDocument.GetElementsByTagName("STS_STOCKS_INFO")

                            For i As Integer = 0 To v_nodeList.Count - 1
                                v_strSymbol = v_nodeList.Item(i).SelectSingleNode("CODE").InnerText

                                If (Not v_nodeList.Item(i).SelectSingleNode("BASIC_PRICE") Is Nothing) Then
                                    v_decRefPrice = gf_CorrectNumericField(v_nodeList.Item(i).SelectSingleNode("BASIC_PRICE").InnerText) * v_decTradeUnit
                                Else
                                    v_decRefPrice = 0
                                End If
                                If (Not v_nodeList.Item(i).SelectSingleNode("OPEN_PRICE") Is Nothing) Then
                                    v_decOpenPrice = gf_CorrectNumericField(v_nodeList.Item(i).SelectSingleNode("OPEN_PRICE").InnerText) * v_decTradeUnit
                                Else
                                    v_decOpenPrice = 0
                                End If
                                If (Not v_nodeList.Item(i).SelectSingleNode("FLOOR_PRICE") Is Nothing) Then
                                    v_decFloorPrice = gf_CorrectNumericField(v_nodeList.Item(i).SelectSingleNode("FLOOR_PRICE").InnerText) * v_decTradeUnit
                                Else
                                    v_decFloorPrice = 0
                                End If
                                If (Not v_nodeList.Item(i).SelectSingleNode("CEILING_PRICE") Is Nothing) Then
                                    v_decCeilingPrice = gf_CorrectNumericField(v_nodeList.Item(i).SelectSingleNode("CEILING_PRICE").InnerText) * v_decTradeUnit
                                Else
                                    v_decCeilingPrice = 0
                                End If
                                If (Not v_nodeList.Item(i).SelectSingleNode("CURRENT_PRICE") Is Nothing) Then
                                    v_decCurrPrice = gf_CorrectNumericField(v_nodeList.Item(i).SelectSingleNode("CURRENT_PRICE").InnerText) * v_decTradeUnit
                                Else
                                    v_decCurrPrice = 0
                                End If
                                If (Not v_nodeList.Item(i).SelectSingleNode("AVERAGE_PRICE") Is Nothing) Then
                                    v_decAvgPrice = gf_CorrectNumericField(v_nodeList.Item(i).SelectSingleNode("AVERAGE_PRICE").InnerText) * v_decTradeUnit
                                Else
                                    v_decAvgPrice = 0
                                End If
                                If (Not v_nodeList.Item(i).SelectSingleNode("CLOSE_PRICE") Is Nothing) Then
                                    v_decClosePrice = gf_CorrectNumericField(v_nodeList.Item(i).SelectSingleNode("CLOSE_PRICE").InnerText) * v_decTradeUnit
                                Else
                                    v_decClosePrice = 0
                                End If

                                For j As Integer = 0 To mv_gridSecInfo.DataRows.Count - 1
                                    With mv_gridSecInfo.DataRows.Item(j)
                                        If (.Cells("SYMBOL").Value.ToString() = v_strSymbol) And (.Cells("TRADECD").Value.ToString() = v_strTradePlace) Then
                                            .BeginEdit()

                                            .Cells("REF_PRICE").Value = v_decRefPrice
                                            .Cells("OPEN_PRICE").Value = v_decOpenPrice
                                            .Cells("FLOOR_PRICE").Value = v_decFloorPrice
                                            .Cells("CEILING_PRICE").Value = v_decCeilingPrice
                                            .Cells("CURRENT_PRICE").Value = v_decCurrPrice
                                            .Cells("AVG_PRICE").Value = v_decAvgPrice
                                            .Cells("CLOSE_PRICE").Value = v_decClosePrice

                                            .EndEdit()
                                            Exit For
                                        End If
                                    End With
                                Next j
                            Next i

                            MessageBox.Show(ResourceManager.GetString("READ_FILE_SUCCESSFULLY").Replace("@", v_strFileName), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    Case Else
                        MessageBox.Show(ResourceManager.GetString("FILENAME_MUST_VALID"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtFromFile.Focus()
                End Select
            Else
                MessageBox.Show(ResourceManager.GetString("FILENAME_MUST_VALID"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtFromFile.Focus()
            End If
        Catch ex As Exception
            LogError.Write("Error source: @DIRECT.frmUpdateSecInfo.ReadSecInfoFromFiles" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

#Region " Public methods "

#End Region

#Region " Form events "
    Private Sub frmUpdateSecInfo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitDialog()
    End Sub

    Private Sub RadioButton_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If (sender Is radioQuoteSvr) And (radioQuoteSvr.Checked) Then
            grbQuoteSvr.Visible = True
            grbFiles.Visible = False
        ElseIf (sender Is radioFiles) And (radioFiles.Checked) Then
            grbQuoteSvr.Visible = False
            grbFiles.Visible = True
        End If
    End Sub

    Private Sub Button_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If (sender Is btnCancel) Then
            OnClose()
        ElseIf (sender Is btnOK) Then
            OnSave()
        ElseIf (sender Is btnRead) Then
            OnRead()
        ElseIf (sender Is btnCalc) Then
            OnCalc()
        ElseIf (sender Is btnBrowse) Then
            OnBrowser()
        End If
    End Sub
#End Region

    Private Sub SetupServerParameter()
        Dim v_strSQL As String = "SELECT VARVALUE DBLINK ,VARDESC DBDESC FROM SYSVAR WHERE VARNAME='DBLINK_TO_QUOTE_SERVER'"
        Dim v_strMsgObj As String = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SE_SBSECURITIES, gc_ActionInquiry, v_strSQL)
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        'TruongLD Comment when convert
        'v_ws.Timeout = gc_WEB_SERVICE_TIMEOUT
        v_ws.Message(v_strMsgObj)
        'Fill data to grid
        Dim v_xmlDocument As New XmlDocumentEx
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strValue, v_strFLDNAME, v_strFLDTYPE As String

        v_xmlDocument.LoadXml(v_strMsgObj)
        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

        For i As Integer = 0 To v_nodeList.Count - 1
            For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                With v_nodeList.Item(i).ChildNodes(j)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    Select Case v_strFLDNAME
                        Case "DBDESC"
                            mv_strDBLinkDesc = .InnerText.ToString.Trim
                        Case "DBLINK"
                            mv_strDBLinkName = .InnerText.ToString.Trim
                    End Select
                End With
            Next
        Next
    End Sub

    Private Sub GetDataFromHo(ByVal pv_decTradeUnit As Double)
        Dim v_strSQL As String = " SELECT S.SYMBOL SYMBOL, S.CODEID CODEID, S.TRADEPLACE TRADECD, A.CDCONTENT TRADE_PLACE, Q.BASIC_PRICE * " & pv_decTradeUnit & " REF_PRICE, Q.OPEN_PRICE * " & pv_decTradeUnit & " OPEN_PRICE, " _
               & " Q.FLOOR_PRICE * " & pv_decTradeUnit & " FLOOR_PRICE, Q.CEILING_PRICE * " & pv_decTradeUnit & " CEILING_PRICE, Q.CURRENT_PRICE * " & pv_decTradeUnit & " CURRENT_PRICE, Q.AVERAGE_PRICE * " & pv_decTradeUnit & " AVG_PRICE, Q.CLOSE_PRICE * " & pv_decTradeUnit & " CLOSE_PRICE  " _
               & " FROM SBSECURITIES S, SECURITIES_INFO SI, ALLCODE A , " _
               & " SEC_INFO@" & mv_strDBLinkName & "  Q " _
               & " WHERE S.CODEID = SI.CODEID AND A.CDTYPE = 'SA'  " _
               & " AND A.CDNAME = 'TRADEPLACE' AND S.TRADEPLACE = A.CDVAL  " _
               & " AND S.SYMBOL=TRIM(Q.CODE) " _
               & " AND Q.FLOOR_CODE = (SELECT VARVALUE FROM SYSVAR@" & mv_strDBLinkName & " SYS WHERE GRNAME='SYSTEM' AND VARNAME='HOSTC_FLOOR_CODE') " _
               & " ORDER BY S.SYMBOL "
        FillDataToGrid(v_strSQL, mv_gridSecInfo)
    End Sub

    Private Sub GetDataFromHa(ByVal pv_decTradeUnit As Double)
        Dim v_strSQL As String = " SELECT S.SYMBOL SYMBOL, S.CODEID CODEID, S.TRADEPLACE TRADECD, A.CDCONTENT TRADE_PLACE, Q.BASIC_PRICE * " & pv_decTradeUnit & " REF_PRICE, Q.OPEN_PRICE * " & pv_decTradeUnit & " OPEN_PRICE, " _
               & " Q.FLOOR_PRICE * " & pv_decTradeUnit & " FLOOR_PRICE, Q.CEILING_PRICE * " & pv_decTradeUnit & " CEILING_PRICE, Q.CURRENT_PRICE * " & pv_decTradeUnit & " CURRENT_PRICE, Q.AVERAGE_PRICE * " & pv_decTradeUnit & " AVG_PRICE, Q.CLOSE_PRICE * " & pv_decTradeUnit & " CLOSE_PRICE  " _
               & " FROM SBSECURITIES S, SECURITIES_INFO SI, ALLCODE A , " _
               & " SEC_INFO@" & mv_strDBLinkName & " Q " _
               & " WHERE S.CODEID = SI.CODEID AND A.CDTYPE = 'SA'  " _
               & " AND A.CDNAME = 'TRADEPLACE' AND S.TRADEPLACE = A.CDVAL  " _
               & " AND S.SYMBOL=TRIM(Q.CODE) " _
               & " AND Q.FLOOR_CODE = (SELECT VARVALUE FROM SYSVAR@" & mv_strDBLinkName & " SYS WHERE GRNAME='SYSTEM' AND VARNAME='HASTC_FLOOR_CODE') " _
               & " ORDER BY S.SYMBOL "
        FillDataToGrid(v_strSQL, mv_gridSecInfo)
    End Sub

    Private Sub GetDataFromOTC()
        Dim v_strSQL As String = " SELECT S.SYMBOL SYMBOL, S.CODEID CODEID, S.TRADEPLACE TRADECD, A.CDCONTENT TRADE_PLACE, Q.BASIC_PRICE * SYS.VARVALUE REF_PRICE, Q.OPEN_PRICE * SYS.VARVALUE OPEN_PRICE, " _
                      & " Q.FLOOR_PRICE * SYS.VARVALUE FLOOR_PRICE, Q.CEILING_PRICE * SYS.VARVALUE CEILING_PRICE, Q.CURRENT_PRICE * SYS.VARVALUE CURRENT_PRICE, Q.AVERAGE_PRICE * SYS.VARVALUE AVG_PRICE, Q.CLOSE_PRICE * SYS.VARVALUE CLOSE_PRICE  " _
                      & " FROM SBSECURITIES S, SECURITIES_INFO SI, ALLCODE A ,SYSVAR SYS, " _
                      & " SEC_INFO@" & mv_strDBLinkName & " Q " _
                      & " WHERE S.CODEID = SI.CODEID AND A.CDTYPE = 'SA'  " _
                      & " AND A.CDNAME = 'TRADEPLACE' AND S.TRADEPLACE = A.CDVAL " _
                      & " AND S.SYMBOL=TRIM(Q.CODE) AND SYS.VARNAME='OTC_TRADE_UNIT'" _
                      & " AND Q.FLOOR_CODE = (SELECT VARVALUE FROM SYSVAR@" & mv_strDBLinkName & " SYS WHERE GRNAME='SYSTEM' AND VARNAME='OTC_FLOOR_CODE') "
        FillDataToGrid(v_strSQL, mv_gridSecInfo)
    End Sub
    Private Sub GetDataFromAllCenter()
        Dim v_strSQL As String = " SELECT S.SYMBOL SYMBOL, S.CODEID CODEID, S.TRADEPLACE TRADECD, A.CDCONTENT TRADE_PLACE, Q.BASIC_PRICE * SYS.VARVALUE REF_PRICE, Q.OPEN_PRICE * SYS.VARVALUE OPEN_PRICE, " _
                      & " Q.FLOOR_PRICE * SYS.VARVALUE FLOOR_PRICE, Q.CEILING_PRICE * SYS.VARVALUE CEILING_PRICE, Q.CURRENT_PRICE * SYS.VARVALUE CURRENT_PRICE, Q.AVERAGE_PRICE * SYS.VARVALUE AVG_PRICE, Q.CLOSE_PRICE * SYS.VARVALUE CLOSE_PRICE  " _
                      & " FROM SBSECURITIES S, SECURITIES_INFO SI, ALLCODE A ,SYSVAR SYS, " _
                      & " SEC_INFO@" & mv_strDBLinkName & " Q " _
                      & " WHERE S.CODEID = SI.CODEID AND A.CDTYPE = 'SA'  " _
                      & " AND A.CDNAME = 'TRADEPLACE' AND S.TRADEPLACE = A.CDVAL " _
                      & " AND S.SYMBOL=TRIM(Q.CODE) AND SYS.VARNAME='HASTC_TRADE_UNIT'" _
                      & " AND Q.FLOOR_CODE = (SELECT VARVALUE FROM SYSVAR@" & mv_strDBLinkName & " SYS WHERE GRNAME='SYSTEM' AND VARNAME='HASTC_FLOOR_CODE') " _
                & " UNION ALL " _
                      & " SELECT S.SYMBOL SYMBOL, S.CODEID CODEID, S.TRADEPLACE TRADECD, A.CDCONTENT TRADE_PLACE, Q.BASIC_PRICE * SYS.VARVALUE REF_PRICE, Q.OPEN_PRICE * SYS.VARVALUE OPEN_PRICE, " _
                      & " Q.FLOOR_PRICE * SYS.VARVALUE FLOOR_PRICE, Q.CEILING_PRICE * SYS.VARVALUE CEILING_PRICE, Q.CURRENT_PRICE * SYS.VARVALUE CURRENT_PRICE, Q.AVERAGE_PRICE * SYS.VARVALUE AVG_PRICE, Q.CLOSE_PRICE * SYS.VARVALUE CLOSE_PRICE  " _
                      & " FROM SBSECURITIES S, SECURITIES_INFO SI, ALLCODE A ,SYSVAR SYS, " _
                      & " SEC_INFO@" & mv_strDBLinkName & " Q " _
                      & " WHERE S.CODEID = SI.CODEID AND A.CDTYPE = 'SA'  " _
                      & " AND A.CDNAME = 'TRADEPLACE' AND S.TRADEPLACE = A.CDVAL " _
                      & " AND S.SYMBOL=TRIM(Q.CODE) AND SYS.VARNAME='HOSTC_TRADE_UNIT'" _
                      & " AND Q.FLOOR_CODE = (SELECT VARVALUE FROM SYSVAR@" & mv_strDBLinkName & " SYS WHERE GRNAME='SYSTEM' AND VARNAME='HOSTC_FLOOR_CODE') " _
                & " UNION ALL " _
                      & " SELECT S.SYMBOL SYMBOL, S.CODEID CODEID, S.TRADEPLACE TRADECD, A.CDCONTENT TRADE_PLACE, Q.BASIC_PRICE * SYS.VARVALUE REF_PRICE, Q.OPEN_PRICE * SYS.VARVALUE OPEN_PRICE, " _
                      & " Q.FLOOR_PRICE * SYS.VARVALUE FLOOR_PRICE, Q.CEILING_PRICE * SYS.VARVALUE CEILING_PRICE, Q.CURRENT_PRICE * SYS.VARVALUE CURRENT_PRICE, Q.AVERAGE_PRICE * SYS.VARVALUE AVG_PRICE, Q.CLOSE_PRICE * SYS.VARVALUE CLOSE_PRICE  " _
                      & " FROM SBSECURITIES S, SECURITIES_INFO SI, ALLCODE A ,SYSVAR SYS, " _
                      & " SEC_INFO@" & mv_strDBLinkName & " Q " _
                      & " WHERE S.CODEID = SI.CODEID AND A.CDTYPE = 'SA'  " _
                      & " AND A.CDNAME = 'TRADEPLACE' AND S.TRADEPLACE = A.CDVAL " _
                      & " AND S.SYMBOL=TRIM(Q.CODE) AND SYS.VARNAME='OTC_TRADE_UNIT'" _
                      & " AND Q.FLOOR_CODE = (SELECT VARVALUE FROM SYSVAR@" & mv_strDBLinkName & " SYS WHERE GRNAME='SYSTEM' AND VARNAME='OTC_FLOOR_CODE') "
        FillDataToGrid(v_strSQL, mv_gridSecInfo)
    End Sub
    Private Sub FillDataToGrid(ByVal pv_strSQL As String, ByRef pv_gridSecInfo As GridEx)
        Try
            Dim v_strMsgObj As String = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SE_SBSECURITIES, gc_ActionInquiry, pv_strSQL)
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            'TruongLD Comment when convert
            'v_ws.Timeout = gc_WEB_SERVICE_TIMEOUT
            v_ws.Message(v_strMsgObj)
            'Fill data to grid
            Dim v_xmlDocument As New XmlDocumentEx
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strValue, v_strFLDNAME, v_strFLDTYPE As String

            v_xmlDocument.LoadXml(v_strMsgObj)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            pv_gridSecInfo.DataRows.Clear()
            pv_gridSecInfo.BeginInit()

            For i As Integer = 0 To v_nodeList.Count - 1
                Dim v_xDataRow As Xceed.Grid.DataRow = pv_gridSecInfo.DataRows.AddNew()
                Dim v_xColumn As Xceed.Grid.Column
                For Each v_xColumn In pv_gridSecInfo.Columns
                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            v_strValue = .InnerText.ToString
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            v_strFLDTYPE = CStr(CType(.Attributes.GetNamedItem("fldtype"), Xml.XmlAttribute).Value)

                            If (v_strFLDNAME.ToUpper() = v_xColumn.FieldName.ToUpper()) Then
                                Select Case v_xColumn.DataType.Name
                                    Case GetType(System.String).Name
                                        v_xDataRow.Cells(v_xColumn.FieldName).Value = IIf(v_strValue Is DBNull.Value, "", CStr(v_strValue))
                                    Case GetType(System.Decimal).Name
                                        If v_strValue = "" Then
                                            v_strValue = 0
                                        End If
                                        v_xDataRow.Cells(v_xColumn.FieldName).Value = IIf(v_strValue Is DBNull.Value, 0, CDec(v_strValue))
                                    Case GetType(Integer).Name
                                        v_xDataRow.Cells(v_xColumn.FieldName).Value = IIf(v_strValue Is DBNull.Value, 0, CInt(v_strValue))
                                    Case GetType(Long).Name
                                        v_xDataRow.Cells(v_xColumn.FieldName).Value = IIf(v_strValue Is DBNull.Value, 0, CLng(v_strValue))
                                    Case GetType(System.DateTime).Name
                                        v_xDataRow.Cells(v_xColumn.FieldName).Value = IIf(v_strValue Is DBNull.Value, "", CDate(v_strValue).ToShortDateString)
                                    Case Else
                                        v_xDataRow.Cells(v_xColumn.FieldName).Value = IIf(v_strValue Is DBNull.Value, "", v_strValue)
                                End Select

                                v_xDataRow.EndEdit()
                            End If
                        End With
                    Next
                Next
            Next
            pv_gridSecInfo.EndInit()
            pnlSecInfo.Controls.Add(pv_gridSecInfo)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FillDataForComboBox()
        Try
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_strCmdSQL As String, v_strObjMsg As String

            v_strCmdSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY FROM ALLCODE WHERE CDTYPE='OD' AND TRIM(CDNAME)='TRADEPLACE' ORDER BY LSTODR"
            v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            FillComboEx(v_strObjMsg, cboFromCenter, "", Me.UserLanguage)
        Catch ex As Exception
            LogError.Write("Error source: @DIRECT.frmUpdateSecInfo.FillDataForComboBox" & vbNewLine _
                                   & "Error code: System error!" & vbNewLine _
                                   & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cboFromCenter_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFromCenter.SelectedIndexChanged
        Try
            Dim v_strSQL, v_strObjMsg, v_strFieldValue, v_strFULLDATA As String
            Dim v_strValue, v_strFLDNAME, v_strFLDTYPE As String
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_xmlDocument As New Xml.XmlDocument, v_nodeList As Xml.XmlNodeList

            If CType(sender, ComboBoxEx).SelectedValue Is DBNull.Value Then
                Exit Sub
            End If
            v_strFieldValue = CType(sender, ComboBoxEx).SelectedValue
            'Binhpt them thay doi grid khi chon san
            If v_strFieldValue.Equals(c_TRADEPLACE_ALL) Then
                v_strSQL = "SELECT S.SYMBOL SYMBOL, S.CODEID CODEID, S.TRADEPLACE TRADECD, A.CDCONTENT TRADE_PLACE, SI.BASICPRICE REF_PRICE, SI.OPENPRICE OPEN_PRICE, " _
                & "SI.FLOORPRICE FLOOR_PRICE, SI.CEILINGPRICE CEILING_PRICE, SI.CURRPRICE CURRENT_PRICE, SI.AVGPRICE AVG_PRICE, SI.CLOSEPRICE CLOSE_PRICE " _
                & "FROM SBSECURITIES S, SECURITIES_INFO SI, ALLCODE A " _
                & "WHERE S.CODEID = SI.CODEID AND A.CDTYPE = 'SA' AND A.CDNAME = 'TRADEPLACE' AND S.TRADEPLACE = A.CDVAL " _
                & "ORDER BY S.SYMBOL"
            Else
                v_strSQL = "SELECT S.SYMBOL SYMBOL, S.CODEID CODEID, S.TRADEPLACE TRADECD, A.CDCONTENT TRADE_PLACE, SI.BASICPRICE REF_PRICE, SI.OPENPRICE OPEN_PRICE, " _
                & "SI.FLOORPRICE FLOOR_PRICE, SI.CEILINGPRICE CEILING_PRICE, SI.CURRPRICE CURRENT_PRICE, SI.AVGPRICE AVG_PRICE, SI.CLOSEPRICE CLOSE_PRICE " _
                & "FROM SBSECURITIES S, SECURITIES_INFO SI, ALLCODE A " _
                & "WHERE S.CODEID = SI.CODEID AND A.CDTYPE = 'SA' AND A.CDNAME = 'TRADEPLACE' AND S.TRADEPLACE = A.CDVAL AND S.TRADEPLACE='" + v_strFieldValue.Trim + "'" _
                & "ORDER BY S.SYMBOL"
            End If
            FillDataToGrid(v_strSQL, mv_gridSecInfo)
            v_strSQL = ""
            'End Binhpt
            If v_strFieldValue.Equals(c_TRADEPLACE_HASTC) Then
                v_strSQL = "SELECT VARVALUE TRADE_UNIT FROM SYSVAR WHERE GRNAME='SYSTEM' AND VARNAME='HASTC_TRADE_UNIT'"
            ElseIf v_strFieldValue.Equals(c_TRADEPLACE_HOSTC) Then
                v_strSQL = "SELECT VARVALUE TRADE_UNIT FROM SYSVAR WHERE GRNAME='SYSTEM' AND VARNAME='HOSTC_TRADE_UNIT'"
            Else
                txtSystemTradeUnit.Text = c_TRADE_UNIT_DEFAULT
                Exit Sub
            End If
            v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQL, "")
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)

            'Gan lai du lieu cho text box trade unit
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Count - 1
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        txtSystemTradeUnit.Text = .InnerText.ToString
                    End With
                Next
            Next
        Catch ex As Exception
            LogError.Write("Error source: @DIRECT.frmUpdateSecInfo.cboFromCenter_SelectedIndexChanged" & vbNewLine _
                                              & "Error code: System error!" & vbNewLine _
                                              & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmUpdateSecInfo_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Select Case e.KeyCode
            Case Keys.Escape
                OnClose()
        End Select
    End Sub
End Class
