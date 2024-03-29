Imports System.Windows.Forms
Imports Xceed.SmartUI.Controls
Imports CommonLibrary
Imports System.Collections
Imports System.IO
Imports AppCore
Imports AppCore.modCoreLib
Imports System
Imports System.Threading

Public Class frmRMBankRequest
    Inherits System.Windows.Forms.Form

#Region " Declare constant and variables "
    Const c_ResourceManager = "_DIRECT.frmRMBankRequest-"
    Public BankList As GridEx
    Public SendReq As GridEx
    Public RecReq As GridEx
    Private mv_strObjectName As String
    Private mv_strModuleCode As String
    Private mv_strLanguage As String
    Private mv_ResourceManager As Resources.ResourceManager
    Private mv_arrObjFields() As CFieldMaster

    Private mv_strLocalObject As String
    Private mv_strBranchId As String
    Private mv_strTellerId As String
    Private mv_strIpAddress As String
    Private mv_strWsName As String
    Private mv_strBusDate As String
    Private mv_strXMLObjData As String
    Private mv_xmlDocument As New Xml.XmlDocument

    Private mv_strHistoryCommand As String
    Private mv_intCurrentPageNumber As Integer = 1
    Private mv_intTotalPage As Integer = 2
    Const NAVIGATE_FIRST = 1
    Const NAVIGATE_PREV = 2
    Const NAVIGATE_NEXT = 3
    Const NAVIGATE_LAST = 4

    Const CONTROL_TOP = 10
    Const CONTROL_LEFT = 10
    Const CONTROL_GAP = 2
    Const CONTROL_HEIGHT = 23
    Const LBLCAPTION_WIDTH = 120
    Const ALL_WIDTH = 550
    Const WIDTH_PERCHAR = 20
    Const PREFIXED_MSKDATA = "mskData"
    Const PREFIXED_LBLDESC = "lblDesc"
    Const PREFIXED_LBLCAP = "lblCaption"

    Const POS_FLDNAME = 1
    Const POS_FLDTYPE = POS_FLDNAME + 2
    Const POS_LOOKUP = POS_FLDTYPE + 1
    Const POS_SQLLIST = POS_LOOKUP + 1


    Dim mv_blnIsRunningMapOrderBook As Boolean = False
    Dim mv_blnIsRunningMapTradeBook As Boolean = False
    Friend WithEvents btnGetBank As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents tabControl As System.Windows.Forms.TabControl
    Friend WithEvents tbSendRequest As System.Windows.Forms.TabPage
    Friend WithEvents tbReceiveRequest As System.Windows.Forms.TabPage
    Friend WithEvents tbBankList As System.Windows.Forms.TabPage
    Friend WithEvents btnEditRequest As System.Windows.Forms.Button
    Friend WithEvents btnChangRequest As System.Windows.Forms.Button
    Friend WithEvents btnSendRequest As System.Windows.Forms.Button
    Friend WithEvents btnReceiveRequest As System.Windows.Forms.Button
    Friend WithEvents pnSendRequest As System.Windows.Forms.Panel
    Friend WithEvents pnBankList As System.Windows.Forms.Panel
    Friend WithEvents pnReceiveRequest As System.Windows.Forms.Panel
    Friend WithEvents btnReconcide As System.Windows.Forms.Button
    Friend WithEvents btnGetTransferResult As System.Windows.Forms.Button
    Friend WithEvents btnManualMsg As System.Windows.Forms.Button
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Dim mv_blnIsRunningSendSMS As Boolean = False
#End Region

#Region " Properties "
    Public Property HISTRORYCOMMAND() As String
        Get
            Return mv_strHistoryCommand
        End Get
        Set(ByVal Value As String)
            mv_strHistoryCommand = Value
        End Set
    End Property

    Public Property TOTALPAGE() As Integer
        Get
            Return mv_intTotalPage
        End Get
        Set(ByVal Value As Integer)
            mv_intTotalPage = Value
        End Set
    End Property

    Public Property CURRENTPAGE() As Integer
        Get
            Return mv_intCurrentPageNumber
        End Get
        Set(ByVal Value As Integer)
            mv_intCurrentPageNumber = Value
        End Set
    End Property

    Public Property XmlObjData() As String
        Get
            Return mv_strXMLObjData
        End Get
        Set(ByVal Value As String)
            mv_strXMLObjData = Value
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
#End Region

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal pv_strLanguage As String)
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        mv_strLanguage = pv_strLanguage
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        LoadResource(Me)
        InitializeGrid()
        GetDataForGrid(tabControl.SelectedIndex)
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
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents txtInterval As System.Windows.Forms.TextBox
    Friend WithEvents tmAutoProcess As System.Windows.Forms.Timer
    Friend WithEvents chkAuto As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.tmAutoProcess = New System.Windows.Forms.Timer(Me.components)
        Me.chkAuto = New System.Windows.Forms.CheckBox()
        Me.txtInterval = New System.Windows.Forms.TextBox()
        Me.btnGetBank = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.tabControl = New System.Windows.Forms.TabControl()
        Me.tbSendRequest = New System.Windows.Forms.TabPage()
        Me.pnSendRequest = New System.Windows.Forms.Panel()
        Me.tbReceiveRequest = New System.Windows.Forms.TabPage()
        Me.pnReceiveRequest = New System.Windows.Forms.Panel()
        Me.tbBankList = New System.Windows.Forms.TabPage()
        Me.pnBankList = New System.Windows.Forms.Panel()
        Me.btnEditRequest = New System.Windows.Forms.Button()
        Me.btnChangRequest = New System.Windows.Forms.Button()
        Me.btnSendRequest = New System.Windows.Forms.Button()
        Me.btnReceiveRequest = New System.Windows.Forms.Button()
        Me.btnReconcide = New System.Windows.Forms.Button()
        Me.btnGetTransferResult = New System.Windows.Forms.Button()
        Me.btnManualMsg = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.tabControl.SuspendLayout()
        Me.tbSendRequest.SuspendLayout()
        Me.tbReceiveRequest.SuspendLayout()
        Me.tbBankList.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(809, 454)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(88, 23)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "&Close"
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(185, 454)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(88, 23)
        Me.btnSubmit.TabIndex = 2
        Me.btnSubmit.Text = "&Submit"
        '
        'tmAutoProcess
        '
        '
        'chkAuto
        '
        Me.chkAuto.Location = New System.Drawing.Point(13, 453)
        Me.chkAuto.Name = "chkAuto"
        Me.chkAuto.Size = New System.Drawing.Size(112, 24)
        Me.chkAuto.TabIndex = 7
        Me.chkAuto.Tag = "chkAuto"
        Me.chkAuto.Text = "Auto-process (s)"
        '
        'txtInterval
        '
        Me.txtInterval.Location = New System.Drawing.Point(129, 456)
        Me.txtInterval.Name = "txtInterval"
        Me.txtInterval.Size = New System.Drawing.Size(40, 20)
        Me.txtInterval.TabIndex = 8
        Me.txtInterval.Text = "180"
        '
        'btnGetBank
        '
        Me.btnGetBank.Location = New System.Drawing.Point(773, 12)
        Me.btnGetBank.Name = "btnGetBank"
        Me.btnGetBank.Size = New System.Drawing.Size(111, 23)
        Me.btnGetBank.TabIndex = 9
        Me.btnGetBank.Tag = "btnGetBank"
        Me.btnGetBank.Text = "btnGetBank"
        Me.btnGetBank.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.tabControl)
        Me.Panel1.Location = New System.Drawing.Point(12, 50)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(885, 386)
        Me.Panel1.TabIndex = 10
        '
        'tabControl
        '
        Me.tabControl.Controls.Add(Me.tbSendRequest)
        Me.tabControl.Controls.Add(Me.tbReceiveRequest)
        Me.tabControl.Controls.Add(Me.tbBankList)
        Me.tabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabControl.Location = New System.Drawing.Point(0, 0)
        Me.tabControl.Name = "tabControl"
        Me.tabControl.SelectedIndex = 0
        Me.tabControl.Size = New System.Drawing.Size(885, 386)
        Me.tabControl.TabIndex = 0
        '
        'tbSendRequest
        '
        Me.tbSendRequest.Controls.Add(Me.pnSendRequest)
        Me.tbSendRequest.Location = New System.Drawing.Point(4, 22)
        Me.tbSendRequest.Name = "tbSendRequest"
        Me.tbSendRequest.Padding = New System.Windows.Forms.Padding(3)
        Me.tbSendRequest.Size = New System.Drawing.Size(877, 360)
        Me.tbSendRequest.TabIndex = 0
        Me.tbSendRequest.Tag = "tbSendRequest"
        Me.tbSendRequest.Text = "Y/C Chi hộ"
        Me.tbSendRequest.UseVisualStyleBackColor = True
        '
        'pnSendRequest
        '
        Me.pnSendRequest.BackColor = System.Drawing.SystemColors.Control
        Me.pnSendRequest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnSendRequest.Location = New System.Drawing.Point(1, 2)
        Me.pnSendRequest.Name = "pnSendRequest"
        Me.pnSendRequest.Size = New System.Drawing.Size(876, 358)
        Me.pnSendRequest.TabIndex = 3
        '
        'tbReceiveRequest
        '
        Me.tbReceiveRequest.Controls.Add(Me.pnReceiveRequest)
        Me.tbReceiveRequest.Location = New System.Drawing.Point(4, 22)
        Me.tbReceiveRequest.Name = "tbReceiveRequest"
        Me.tbReceiveRequest.Padding = New System.Windows.Forms.Padding(3)
        Me.tbReceiveRequest.Size = New System.Drawing.Size(877, 360)
        Me.tbReceiveRequest.TabIndex = 1
        Me.tbReceiveRequest.Tag = "tbReceiveRequest"
        Me.tbReceiveRequest.Text = "Y/C Thu hộ"
        Me.tbReceiveRequest.UseVisualStyleBackColor = True
        '
        'pnReceiveRequest
        '
        Me.pnReceiveRequest.BackColor = System.Drawing.SystemColors.Control
        Me.pnReceiveRequest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnReceiveRequest.Location = New System.Drawing.Point(0, 1)
        Me.pnReceiveRequest.Name = "pnReceiveRequest"
        Me.pnReceiveRequest.Size = New System.Drawing.Size(876, 358)
        Me.pnReceiveRequest.TabIndex = 4
        '
        'tbBankList
        '
        Me.tbBankList.Controls.Add(Me.pnBankList)
        Me.tbBankList.Location = New System.Drawing.Point(4, 22)
        Me.tbBankList.Name = "tbBankList"
        Me.tbBankList.Size = New System.Drawing.Size(877, 360)
        Me.tbBankList.TabIndex = 2
        Me.tbBankList.Tag = "tbBankList"
        Me.tbBankList.Text = "D/S Ngân hàng"
        Me.tbBankList.UseVisualStyleBackColor = True
        '
        'pnBankList
        '
        Me.pnBankList.BackColor = System.Drawing.SystemColors.Control
        Me.pnBankList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnBankList.Location = New System.Drawing.Point(0, 1)
        Me.pnBankList.Name = "pnBankList"
        Me.pnBankList.Size = New System.Drawing.Size(876, 358)
        Me.pnBankList.TabIndex = 4
        '
        'btnEditRequest
        '
        Me.btnEditRequest.Location = New System.Drawing.Point(12, 12)
        Me.btnEditRequest.Name = "btnEditRequest"
        Me.btnEditRequest.Size = New System.Drawing.Size(118, 23)
        Me.btnEditRequest.TabIndex = 11
        Me.btnEditRequest.Tag = "btnEditRequest"
        Me.btnEditRequest.Text = "btnEditRequest"
        Me.btnEditRequest.UseVisualStyleBackColor = True
        Me.btnEditRequest.Visible = False
        '
        'btnChangRequest
        '
        Me.btnChangRequest.Location = New System.Drawing.Point(138, 12)
        Me.btnChangRequest.Name = "btnChangRequest"
        Me.btnChangRequest.Size = New System.Drawing.Size(118, 23)
        Me.btnChangRequest.TabIndex = 12
        Me.btnChangRequest.Tag = "btnChangRequest"
        Me.btnChangRequest.Text = "btnChangRequest"
        Me.btnChangRequest.UseVisualStyleBackColor = True
        Me.btnChangRequest.Visible = False
        '
        'btnSendRequest
        '
        Me.btnSendRequest.Location = New System.Drawing.Point(565, 454)
        Me.btnSendRequest.Name = "btnSendRequest"
        Me.btnSendRequest.Size = New System.Drawing.Size(110, 23)
        Me.btnSendRequest.TabIndex = 13
        Me.btnSendRequest.Tag = "btnSendRequest"
        Me.btnSendRequest.Text = "btnSendRequest"
        Me.btnSendRequest.UseVisualStyleBackColor = True
        '
        'btnReceiveRequest
        '
        Me.btnReceiveRequest.Location = New System.Drawing.Point(430, 454)
        Me.btnReceiveRequest.Name = "btnReceiveRequest"
        Me.btnReceiveRequest.Size = New System.Drawing.Size(117, 23)
        Me.btnReceiveRequest.TabIndex = 14
        Me.btnReceiveRequest.Tag = "btnReceiveRequest"
        Me.btnReceiveRequest.Text = "btnReceiveRequest"
        Me.btnReceiveRequest.UseVisualStyleBackColor = True
        '
        'btnReconcide
        '
        Me.btnReconcide.Enabled = False
        Me.btnReconcide.Location = New System.Drawing.Point(654, 12)
        Me.btnReconcide.Name = "btnReconcide"
        Me.btnReconcide.Size = New System.Drawing.Size(113, 23)
        Me.btnReconcide.TabIndex = 15
        Me.btnReconcide.Tag = "btnReconcide"
        Me.btnReconcide.Text = "btnReconcide"
        Me.btnReconcide.UseVisualStyleBackColor = True
        '
        'btnGetTransferResult
        '
        Me.btnGetTransferResult.Location = New System.Drawing.Point(300, 454)
        Me.btnGetTransferResult.Name = "btnGetTransferResult"
        Me.btnGetTransferResult.Size = New System.Drawing.Size(113, 23)
        Me.btnGetTransferResult.TabIndex = 16
        Me.btnGetTransferResult.Tag = "btnGetTransferResult"
        Me.btnGetTransferResult.Text = "btnGetTransferResult"
        Me.btnGetTransferResult.UseVisualStyleBackColor = True
        '
        'btnManualMsg
        '
        Me.btnManualMsg.Location = New System.Drawing.Point(320, 12)
        Me.btnManualMsg.Name = "btnManualMsg"
        Me.btnManualMsg.Size = New System.Drawing.Size(136, 23)
        Me.btnManualMsg.TabIndex = 17
        Me.btnManualMsg.Tag = "btnManualMsg"
        Me.btnManualMsg.Text = "btnManualMsg"
        Me.btnManualMsg.UseVisualStyleBackColor = True
        Me.btnManualMsg.Visible = False
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(462, 12)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(136, 23)
        Me.btnRefresh.TabIndex = 18
        Me.btnRefresh.Tag = "btnRefresh"
        Me.btnRefresh.Text = "btnRefresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'frmRMBankRequest
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(909, 485)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.btnManualMsg)
        Me.Controls.Add(Me.btnGetTransferResult)
        Me.Controls.Add(Me.btnReconcide)
        Me.Controls.Add(Me.btnReceiveRequest)
        Me.Controls.Add(Me.btnSendRequest)
        Me.Controls.Add(Me.btnChangRequest)
        Me.Controls.Add(Me.btnEditRequest)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnGetBank)
        Me.Controls.Add(Me.txtInterval)
        Me.Controls.Add(Me.chkAuto)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSubmit)
        Me.KeyPreview = True
        Me.Name = "frmRMBankRequest"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "frmRMBankRequest"
        Me.Text = "Quản lý thông tin thu chi điện tử"
        Me.Panel1.ResumeLayout(False)
        Me.tabControl.ResumeLayout(False)
        Me.tbSendRequest.ResumeLayout(False)
        Me.tbReceiveRequest.ResumeLayout(False)
        Me.tbBankList.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region " Form events "
    Private Sub btnSyn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'SynchronousTransaction()
    End Sub
    Private Sub btnResetCache_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'OnResetCache()
    End Sub

    Private Sub InitializeGrid()
        'Khá»Ÿi táº¡o Grid contacts
        BankList = New GridEx
        Dim v_cmrBankListHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrBankListHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrBankListHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        BankList.FixedHeaderRows.Add(v_cmrBankListHeader)

        BankList.Columns.Add(New Xceed.Grid.Column("BANKCODE", GetType(System.String)))
        BankList.Columns.Add(New Xceed.Grid.Column("BANKNAME", GetType(System.String)))
        BankList.Columns.Add(New Xceed.Grid.Column("REGIONAL", GetType(System.String)))
        BankList.Columns.Add(New Xceed.Grid.Column("CREATEDT", GetType(System.String)))

        BankList.Columns("BANKCODE").Title = mv_ResourceManager.GetString("BANKCODE")
        BankList.Columns("BANKNAME").Title = mv_ResourceManager.GetString("BANKNAME")
        BankList.Columns("REGIONAL").Title = mv_ResourceManager.GetString("REGIONAL")
        BankList.Columns("CREATEDT").Title = mv_ResourceManager.GetString("CREATEDT")



        BankList.Columns("BANKCODE").Width = 100
        BankList.Columns("BANKNAME").Width = 250
        BankList.Columns("REGIONAL").Width = 80
        BankList.Columns("CREATEDT").Width = 100

        BankList.Columns("BANKCODE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        BankList.Columns("BANKNAME").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        BankList.Columns("REGIONAL").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        BankList.Columns("CREATEDT").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left

        BankList.Columns("BANKCODE").CanBeSorted = False
        BankList.Columns("BANKNAME").CanBeSorted = False
        BankList.Columns("REGIONAL").CanBeSorted = False
        BankList.Columns("CREATEDT").CanBeSorted = False


        Me.pnBankList.Controls.Clear()
        Me.pnBankList.Controls.Add(BankList)
        BankList.Dock = Windows.Forms.DockStyle.Fill
        'AddHandler BankList.SelectedRowsChanged, AddressOf ODSendCurrentCellChanged
        'If Me.BankList.DataRowTemplate.Cells.Count >= 0 Then
        '    For i As Integer = 1 To Me.BankList.DataRowTemplate.Cells.Count - 1
        '        AddHandler BankList.DataRowTemplate.Cells(i).DoubleClick, AddressOf OnView
        '    Next
        'End If

        'AddHandler BankList.DataRowTemplate.Cells("CHECKALL").Click, AddressOf ODSendSelectedRowChanged        



        SendReq = New GridEx
        Dim v_cmrSendReqHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrSendReqHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrSendReqHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        SendReq.FixedHeaderRows.Add(v_cmrSendReqHeader)

        SendReq.Columns.Add(New Xceed.Grid.Column("REQID", GetType(System.String)))
        SendReq.Columns.Add(New Xceed.Grid.Column("TRFCODE", GetType(System.String)))
        SendReq.Columns.Add(New Xceed.Grid.Column("REFCODE", GetType(System.String)))
        SendReq.Columns.Add(New Xceed.Grid.Column("TXDATE", GetType(System.String)))
        SendReq.Columns.Add(New Xceed.Grid.Column("OBJKEY", GetType(System.String)))
        SendReq.Columns.Add(New Xceed.Grid.Column("CUSTODYCD", GetType(System.String)))
        SendReq.Columns.Add(New Xceed.Grid.Column("AFACCTNO", GetType(System.String)))
        SendReq.Columns.Add(New Xceed.Grid.Column("ACCNAME", GetType(System.String)))
        SendReq.Columns.Add(New Xceed.Grid.Column("TXAMT", GetType(System.Double)))
        SendReq.Columns.Add(New Xceed.Grid.Column("STATUS", GetType(System.String)))
        SendReq.Columns.Add(New Xceed.Grid.Column("BANKCODE", GetType(System.String)))
        SendReq.Columns.Add(New Xceed.Grid.Column("BANKACCT", GetType(System.String)))
        SendReq.Columns.Add(New Xceed.Grid.Column("BANKNAME", GetType(System.String)))
        SendReq.Columns.Add(New Xceed.Grid.Column("BANKCITY", GetType(System.String)))
        SendReq.Columns.Add(New Xceed.Grid.Column("DESACCTNO", GetType(System.String)))
        SendReq.Columns.Add(New Xceed.Grid.Column("DESACCTNAME", GetType(System.String)))
        SendReq.Columns.Add(New Xceed.Grid.Column("NOTES", GetType(System.String)))
        SendReq.Columns.Add(New Xceed.Grid.Column("ERRORDESC", GetType(System.String)))

        SendReq.Columns("REQID").Title = mv_ResourceManager.GetString("S_REQID")
        SendReq.Columns("TRFCODE").Title = mv_ResourceManager.GetString("S_TRFCODE")
        SendReq.Columns("REFCODE").Title = mv_ResourceManager.GetString("S_REFCODE")
        SendReq.Columns("TXDATE").Title = mv_ResourceManager.GetString("S_TXDATE")
        SendReq.Columns("OBJKEY").Title = mv_ResourceManager.GetString("S_OBJKEY")
        SendReq.Columns("CUSTODYCD").Title = mv_ResourceManager.GetString("S_CUSTODYCD")
        SendReq.Columns("AFACCTNO").Title = mv_ResourceManager.GetString("S_AFACCTNO")
        SendReq.Columns("ACCNAME").Title = mv_ResourceManager.GetString("S_ACCNAME")
        SendReq.Columns("TXAMT").Title = mv_ResourceManager.GetString("S_TXAMT")
        SendReq.Columns("BANKCODE").Title = mv_ResourceManager.GetString("BANKCODE")
        SendReq.Columns("BANKACCT").Title = mv_ResourceManager.GetString("S_BANKACCT")
        SendReq.Columns("BANKNAME").Title = mv_ResourceManager.GetString("BANKNAME")
        SendReq.Columns("BANKCITY").Title = mv_ResourceManager.GetString("S_BANKCITY")
        SendReq.Columns("DESACCTNO").Title = mv_ResourceManager.GetString("S_DESACCTNO")
        SendReq.Columns("DESACCTNAME").Title = mv_ResourceManager.GetString("S_DESACCTNAME")
        SendReq.Columns("STATUS").Title = mv_ResourceManager.GetString("S_STATUS")
        SendReq.Columns("NOTES").Title = mv_ResourceManager.GetString("S_NOTES")
        SendReq.Columns("ERRORDESC").Title = mv_ResourceManager.GetString("ERRORDESC")

        SendReq.Columns("REQID").Width = 50
        SendReq.Columns("TRFCODE").Width = 0
        SendReq.Columns("REFCODE").Width = 150
        SendReq.Columns("TXDATE").Width = 70
        SendReq.Columns("OBJKEY").Width = 80
        SendReq.Columns("CUSTODYCD").Width = 80
        SendReq.Columns("AFACCTNO").Width = 80
        SendReq.Columns("ACCNAME").Width = 200
        SendReq.Columns("TXAMT").Width = 100
        SendReq.Columns("BANKCODE").Width = 100
        SendReq.Columns("BANKACCT").Width = 100
        SendReq.Columns("BANKNAME").Width = 200
        SendReq.Columns("BANKCITY").Width = 100
        SendReq.Columns("DESACCTNO").Width = 0
        SendReq.Columns("DESACCTNAME").Width = 0
        SendReq.Columns("STATUS").Width = 60
        SendReq.Columns("NOTES").Width = 200
        SendReq.Columns("ERRORDESC").Width = 200

        SendReq.Columns("REQID").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        SendReq.Columns("TRFCODE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        SendReq.Columns("REFCODE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        SendReq.Columns("ACCNAME").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        SendReq.Columns("TXAMT").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        SendReq.Columns("BANKCODE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        SendReq.Columns("BANKACCT").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        SendReq.Columns("BANKNAME").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        SendReq.Columns("BANKCITY").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        SendReq.Columns("DESACCTNO").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        SendReq.Columns("DESACCTNAME").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        SendReq.Columns("STATUS").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        SendReq.Columns("NOTES").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        SendReq.Columns("ERRORDESC").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left

        SendReq.Columns("REQID").CanBeSorted = True
        SendReq.Columns("TRFCODE").CanBeSorted = False
        SendReq.Columns("REFCODE").CanBeSorted = False
        SendReq.Columns("ACCNAME").CanBeSorted = False
        SendReq.Columns("TXAMT").CanBeSorted = True
        SendReq.Columns("TXAMT").FormatSpecifier = "#,##0"
        SendReq.Columns("BANKCODE").CanBeSorted = False
        SendReq.Columns("BANKACCT").CanBeSorted = False
        SendReq.Columns("BANKNAME").CanBeSorted = False
        SendReq.Columns("BANKCITY").CanBeSorted = False
        SendReq.Columns("DESACCTNO").CanBeSorted = False
        SendReq.Columns("DESACCTNAME").CanBeSorted = False
        SendReq.Columns("STATUS").CanBeSorted = False
        SendReq.Columns("NOTES").CanBeSorted = False


        Me.pnSendRequest.Controls.Clear()
        Me.pnSendRequest.Controls.Add(SendReq)
        SendReq.Dock = Windows.Forms.DockStyle.Fill




        RecReq = New GridEx
        Dim v_cmrRecReqHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrRecReqHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrRecReqHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        RecReq.FixedHeaderRows.Add(v_cmrRecReqHeader)

        RecReq.Columns.Add(New Xceed.Grid.Column("AUTOID", GetType(System.String)))
        RecReq.Columns.Add(New Xceed.Grid.Column("CREATEDDATE", GetType(System.String)))
        RecReq.Columns.Add(New Xceed.Grid.Column("TRANSACTIONNUMBER", GetType(System.String)))
        RecReq.Columns.Add(New Xceed.Grid.Column("STATUS", GetType(System.String)))
        RecReq.Columns.Add(New Xceed.Grid.Column("TRNREF", GetType(System.String)))
        RecReq.Columns.Add(New Xceed.Grid.Column("TRN_DT", GetType(System.String)))
        RecReq.Columns.Add(New Xceed.Grid.Column("DESBANKACCOUNT", GetType(System.String)))
        RecReq.Columns.Add(New Xceed.Grid.Column("ACCNAME", GetType(System.String)))
        RecReq.Columns.Add(New Xceed.Grid.Column("ACCNUM", GetType(System.String)))
        RecReq.Columns.Add(New Xceed.Grid.Column("BANKCODE", GetType(System.String)))
        RecReq.Columns.Add(New Xceed.Grid.Column("BRANCH", GetType(System.String)))
        RecReq.Columns.Add(New Xceed.Grid.Column("LOCATION", GetType(System.String)))
        RecReq.Columns.Add(New Xceed.Grid.Column("AMOUNT", GetType(System.Double)))
        RecReq.Columns.Add(New Xceed.Grid.Column("KEYACCT1", GetType(System.String)))
        RecReq.Columns.Add(New Xceed.Grid.Column("KEYACCT2", GetType(System.String)))
        RecReq.Columns.Add(New Xceed.Grid.Column("TRANSACTIONDESCRIPTION", GetType(System.String)))
        RecReq.Columns.Add(New Xceed.Grid.Column("ERRORDESC", GetType(System.String)))
        RecReq.Columns.Add(New Xceed.Grid.Column("ISCONFIRMED", GetType(System.String)))
        RecReq.Columns.Add(New Xceed.Grid.Column("ISMANUAL", GetType(System.String)))
        RecReq.Columns.Add(New Xceed.Grid.Column("USERCREATED", GetType(System.String)))

        RecReq.Columns("AUTOID").Title = mv_ResourceManager.GetString("AUTOID")
        RecReq.Columns("CREATEDDATE").Title = mv_ResourceManager.GetString("CREATEDDATE")
        RecReq.Columns("TRANSACTIONNUMBER").Title = mv_ResourceManager.GetString("TRANSACTIONNUMBER")
        RecReq.Columns("STATUS").Title = mv_ResourceManager.GetString("STATUS")
        RecReq.Columns("TRNREF").Title = mv_ResourceManager.GetString("TRNREF")
        RecReq.Columns("TRN_DT").Title = mv_ResourceManager.GetString("TRN_DT")
        RecReq.Columns("DESBANKACCOUNT").Title = mv_ResourceManager.GetString("DESBANKACCOUNT")
        RecReq.Columns("ACCNAME").Title = mv_ResourceManager.GetString("ACCNAME")
        RecReq.Columns("ACCNUM").Title = mv_ResourceManager.GetString("ACCNUM")
        RecReq.Columns("BANKCODE").Title = mv_ResourceManager.GetString("BANKCODE")
        RecReq.Columns("BRANCH").Title = mv_ResourceManager.GetString("BRANCH")
        RecReq.Columns("LOCATION").Title = mv_ResourceManager.GetString("LOCATION")
        RecReq.Columns("AMOUNT").Title = mv_ResourceManager.GetString("AMOUNT")
        RecReq.Columns("KEYACCT1").Title = mv_ResourceManager.GetString("KEYACCT1")
        RecReq.Columns("KEYACCT2").Title = mv_ResourceManager.GetString("KEYACCT2")
        RecReq.Columns("TRANSACTIONDESCRIPTION").Title = mv_ResourceManager.GetString("TRANSACTIONDESCRIPTION")
        RecReq.Columns("ERRORDESC").Title = mv_ResourceManager.GetString("ERRORDESC")
        RecReq.Columns("ISCONFIRMED").Title = mv_ResourceManager.GetString("ISCONFIRMED")
        RecReq.Columns("ISMANUAL").Title = mv_ResourceManager.GetString("ISMANUAL")
        RecReq.Columns("USERCREATED").Title = mv_ResourceManager.GetString("USERCREATED")

        RecReq.Columns("AUTOID").Width = 50
        RecReq.Columns("CREATEDDATE").Width = 0
        RecReq.Columns("TRANSACTIONNUMBER").Width = 100
        RecReq.Columns("STATUS").Width = 80
        RecReq.Columns("TRNREF").Width = 80
        RecReq.Columns("TRN_DT").Width = 80
        RecReq.Columns("DESBANKACCOUNT").Width = 100
        RecReq.Columns("ACCNAME").Width = 100
        RecReq.Columns("ACCNUM").Width = 0
        RecReq.Columns("BANKCODE").Width = 80
        RecReq.Columns("BRANCH").Width = 0
        RecReq.Columns("LOCATION").Width = 100
        RecReq.Columns("AMOUNT").Width = 100
        RecReq.Columns("KEYACCT1").Width = 100
        RecReq.Columns("KEYACCT2").Width = 100
        RecReq.Columns("TRANSACTIONDESCRIPTION").Width = 200
        RecReq.Columns("ISCONFIRMED").Width = 0
        RecReq.Columns("ISMANUAL").Width = 0
        RecReq.Columns("USERCREATED").Width = 0

        RecReq.Columns("AUTOID").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        RecReq.Columns("CREATEDDATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        RecReq.Columns("TRANSACTIONNUMBER").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        RecReq.Columns("STATUS").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        RecReq.Columns("TRNREF").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        RecReq.Columns("TRN_DT").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        RecReq.Columns("DESBANKACCOUNT").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        RecReq.Columns("ACCNAME").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        RecReq.Columns("ACCNUM").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        RecReq.Columns("BANKCODE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        RecReq.Columns("BRANCH").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        RecReq.Columns("LOCATION").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        RecReq.Columns("AMOUNT").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        RecReq.Columns("KEYACCT1").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        RecReq.Columns("KEYACCT2").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        RecReq.Columns("TRANSACTIONDESCRIPTION").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        RecReq.Columns("ISCONFIRMED").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        RecReq.Columns("ISMANUAL").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        RecReq.Columns("USERCREATED").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left

        RecReq.Columns("AUTOID").CanBeSorted = True
        RecReq.Columns("CREATEDDATE").CanBeSorted = False
        RecReq.Columns("TRANSACTIONNUMBER").CanBeSorted = False
        RecReq.Columns("STATUS").CanBeSorted = False
        RecReq.Columns("TRNREF").CanBeSorted = False
        RecReq.Columns("TRN_DT").CanBeSorted = False
        RecReq.Columns("DESBANKACCOUNT").CanBeSorted = False
        RecReq.Columns("ACCNAME").CanBeSorted = False
        RecReq.Columns("ACCNUM").CanBeSorted = False
        RecReq.Columns("BANKCODE").CanBeSorted = False
        RecReq.Columns("BRANCH").CanBeSorted = False
        RecReq.Columns("LOCATION").CanBeSorted = False
        RecReq.Columns("AMOUNT").CanBeSorted = True
        RecReq.Columns("AMOUNT").FormatSpecifier = "#,##0"
        RecReq.Columns("KEYACCT1").CanBeSorted = False
        RecReq.Columns("KEYACCT2").CanBeSorted = False
        RecReq.Columns("TRANSACTIONDESCRIPTION").CanBeSorted = False
        RecReq.Columns("ISCONFIRMED").CanBeSorted = False
        RecReq.Columns("ISMANUAL").CanBeSorted = False
        RecReq.Columns("USERCREATED").CanBeSorted = False


        Me.pnReceiveRequest.Controls.Clear()
        Me.pnReceiveRequest.Controls.Add(RecReq)
        RecReq.Dock = Windows.Forms.DockStyle.Fill




    End Sub

    'Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
    '    Dim v_ws As New StockTicker.StockTicker, v_strRETURN, v_strValue As String, i, j As Integer
    '    Try
    '        Me.txtFeedBack.Text = String.Empty
    '        Dim v_strCMDLINE As String
    '        For i = 0 To Me.chklistTasks.Items.Count - 1
    '            If chklistTasks.GetItemChecked(i) = True Then
    '                v_strCMDLINE = CType(chklistTasks.Items(i), String)
    '                j = InStr(v_strCMDLINE, ":")
    '                v_strValue = Mid(v_strCMDLINE, 1, j - 1)
    '                Select Case v_strValue
    '                    Case "AUTOGV"
    '                        AutoRunGeneralView()
    '                    Case "SYNCTRANS"
    '                        SynchronousTransaction()
    '                    Case "START_VSMKTINFO"
    '                        v_strRETURN = v_ws.StartSTCAdapter("VS", "MARKETINFO")
    '                    Case "START_VNMKTINFO"
    '                        v_strRETURN = v_ws.StartSTCAdapter("VN", "MARKETINFO")
    '                    Case "START_VSTRADE"
    '                        v_strRETURN = v_ws.StartSTCAdapter("VS", "TRADINGDATA")
    '                    Case "START_VNTRADE"
    '                        v_strRETURN = v_ws.StartSTCAdapter("VN", "TRADINGDATA")
    '                    Case "GET_VSMARKETWATCH"
    '                        v_strRETURN = v_ws.StartSTCAdapter("VS", "MARKETWATCH")
    '                    Case "GET_VNMARKETWATCH"
    '                        v_strRETURN = v_ws.StartSTCAdapter("VN", "MARKETWATCH")
    '                    Case "START_MAP_STCORDERBOOK"
    '                        'Get current exchange order book
    '                        v_strRETURN = v_ws.GetOrderBook
    '                        MapExchangeOrderBook(v_strRETURN)
    '                    Case "START_MAP_STCTRADEBOOK"
    '                        v_strRETURN = v_ws.GetTradeBook
    '                        MapExchangeTradeBook(v_strRETURN)
    '                End Select
    '                Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": " + v_strValue + "-DONE"
    '            End If
    '        Next
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    Finally
    '        v_ws = Nothing
    '    End Try
    'End Sub
    Private Sub OnProcess()

        Try
            Me.CallProcess1104()
            Me.CallProcess1141()
            'Me.ExecuteSendBankRequestProcess()
            Me.ExecuteSendReconcide()

            Me.ExecuteReceiveBankRequestProcess()
            Me.ExecuteSendBankRequestProcess()
            Me.ExecuteGetTransferResult()
            GetDataForGrid(tabControl.SelectedIndex)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            'v_ws = Nothing
        End Try
    End Sub

    ' async method --nghiemnt
    Delegate Sub UpdateUsingCallback(ByVal ar As IAsyncResult)

    Private Sub ThreadMapOrderBook()

    End Sub

    Private Sub ThreadMapTradeBook()

    End Sub

    Private Sub ThreadSendSMS()

    End Sub

    Private Sub wsThreadMapOrderBook(ByVal ar As IAsyncResult)
        'If txtFeedBack.InvokeRequired Then
        '    Dim callback As UpdateUsingCallback = New UpdateUsingCallback(AddressOf wsThreadMapOrderBook)
        '    Me.Invoke(callback, New Object() {ar})
        'Else
        '    Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + "[MapOrderBook] " + Now.ToLongTimeString + ": Done"
        '    'Swith off flag: allow to request again
        '    mv_blnIsRunningMapOrderBook = False
        'End If
    End Sub

    Private Sub wsThreadMapTradeBook(ByVal ar As IAsyncResult)
        'If txtFeedBack.InvokeRequired Then
        '    Dim callback As UpdateUsingCallback = New UpdateUsingCallback(AddressOf wsThreadMapTradeBook)
        '    Me.Invoke(callback, New Object() {ar})
        'Else
        '    Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + "[MapTradeBook] " + Now.ToLongTimeString + ": Done"
        '    'Swith off flag: allow to request again
        '    mv_blnIsRunningMapTradeBook = False
        'End If
    End Sub

    Private Sub wsThreadSendSMS(ByVal ar As IAsyncResult)
        'If txtFeedBack.InvokeRequired Then
        '    Dim callback As UpdateUsingCallback = New UpdateUsingCallback(AddressOf wsThreadSendSMS)
        '    Me.Invoke(callback, New Object() {ar})
        'Else
        '    Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + "[SendSMS] " + Now.ToLongTimeString + ": Done"
        '    'Swith off flag: allow to request again
        '    mv_blnIsRunningSendSMS = False
        'End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Onclose()
    End Sub
#End Region

#Region " Private function "

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


    Private Sub Onclose()
        Me.Close()
        Me.tmAutoProcess.Enabled = False
    End Sub

    'Private Sub SendOrderToCompany()
    '    Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
    '    Try
    '        Dim v_strObjMsg As String, pv_xmlDocument As New Xml.XmlDocument
    '        'TruongLD Comment when convert
    '        'Dim v_ws As New AuthWS.AuthService
    '        'TruongLD Add when convert
    '        Dim v_ws As New AuthManagement
    '        'End TruongLD
    '        v_strObjMsg = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "SendOrderToCompany", , , "GetDate")
    '        v_lngError = v_ws.Message(v_strObjMsg)
    '        pv_xmlDocument.LoadXml(v_strObjMsg)
    '        If v_lngError <> ERR_SYSTEM_OK Then
    '            'Thông báo l?i
    '            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
    '            Cursor.Current = Cursors.Default
    '            Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": " + v_strErrorMessage
    '            Exit Sub
    '        Else
    '            Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": Send order from FO to company successfully"
    '        End If

    '    Catch ex As Exception
    '        LogError.Write("Error source: " & ex.Source & vbNewLine _
    '                     & "Error code: System error!" & vbNewLine _
    '                     & "Error message: " & ex.Message, EventLogEntryType.Error)
    '        MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
    '    End Try
    'End Sub

    'Private Sub SendGTCOrderToCompany(ByVal v_strFunType As String)
    '    Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
    '    Try
    '        Dim v_strObjMsg As String, pv_xmlDocument As New Xml.XmlDocument
    '        'TruongLD Comment when convert
    '        'Dim v_ws As New AuthWS.AuthService
    '        'TruongLD Add when convert
    '        Dim v_ws As New AuthManagement
    '        'End TruongLD
    '        v_strObjMsg = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "SendGTCOrderToCompany", , , "GetDate", v_strFunType)
    '        v_lngError = v_ws.Message(v_strObjMsg)
    '        pv_xmlDocument.LoadXml(v_strObjMsg)
    '        If v_lngError <> ERR_SYSTEM_OK Then
    '            'Thông báo l?i
    '            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
    '            Cursor.Current = Cursors.Default
    '            Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": " + v_strErrorMessage
    '            Exit Sub
    '        Else
    '            Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": Send order from FO to company successfully"
    '        End If

    '    Catch ex As Exception
    '        LogError.Write("Error source: " & ex.Source & vbNewLine _
    '                     & "Error code: System error!" & vbNewLine _
    '                     & "Error message: " & ex.Message, EventLogEntryType.Error)
    '        MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
    '    End Try
    'End Sub

    'Private Sub OnResetCache()
    '    Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
    '    Try
    '        Dim v_strObjMsg As String, pv_xmlDocument As New Xml.XmlDocument
    '        'TruongLD Comment when convert
    '        'Dim v_ws As New AuthWS.AuthService
    '        'TruongLD Add when convert
    '        Dim v_ws As New AuthManagement
    '        'End TruongLD
    '        v_strObjMsg = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "ResetCacheProcessing", , , "GetDate")
    '        v_lngError = v_ws.Message(v_strObjMsg)
    '        pv_xmlDocument.LoadXml(v_strObjMsg)
    '        If v_lngError <> ERR_SYSTEM_OK Then
    '            'Thông báo l?i
    '            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
    '            Cursor.Current = Cursors.Default
    '            Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": " + v_strErrorMessage
    '            Exit Sub
    '        Else
    '            Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": OnResetCache successfully" + v_strErrorMessage
    '        End If
    '    Catch ex As Exception
    '        LogError.Write("Error source: " & ex.Source & vbNewLine _
    '                                 & "Error code: System error!" & vbNewLine _
    '                                 & "Error message: " & ex.Message, EventLogEntryType.Error)
    '        MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
    '    End Try
    'End Sub

    'Private Sub SynchronousTransaction()
    '    Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
    '    Try
    '        Dim v_strObjMsg As String, pv_xmlDocument As New Xml.XmlDocument
    '        'TruongLD Comment when convert
    '        'Dim v_ws As New AuthWS.AuthService
    '        'TruongLD Add when convert
    '        Dim v_ws As New AuthManagement
    '        'End TruongLD
    '        v_strObjMsg = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "AsynchronousProcessing", , , "GetDate")
    '        v_lngError = v_ws.Message(v_strObjMsg)
    '        pv_xmlDocument.LoadXml(v_strObjMsg)
    '        If v_lngError <> ERR_SYSTEM_OK Then
    '            'Thông báo l?i
    '            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
    '            Cursor.Current = Cursors.Default
    '            Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": " + v_strErrorMessage
    '            Exit Sub
    '        Else
    '            Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": Change status successfully"
    '        End If

    '    Catch ex As Exception
    '        LogError.Write("Error source: " & ex.Source & vbNewLine _
    '                     & "Error code: System error!" & vbNewLine _
    '                     & "Error message: " & ex.Message, EventLogEntryType.Error)
    '        MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
    '    End Try
    'End Sub

    'Private Sub AutoRunGeneralView()
    '    Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
    '    Try
    '        Dim v_strObjMsg As String, pv_xmlDocument As New Xml.XmlDocument
    '        'TruongLD Comment when convert
    '        'Dim v_ws As New AuthWS.AuthService
    '        'TruongLD Add when convert
    '        Dim v_ws As New AuthManagement
    '        'End TruongLD
    '        v_strObjMsg = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "AutoRunGeneralView", , , "GetDate")
    '        v_lngError = v_ws.Message(v_strObjMsg)
    '        pv_xmlDocument.LoadXml(v_strObjMsg)
    '        If v_lngError <> ERR_SYSTEM_OK Then
    '            'Thông báo l?i
    '            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
    '            Cursor.Current = Cursors.Default
    '            Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": " + v_strErrorMessage
    '            Exit Sub
    '        Else
    '            Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": Change status successfully"
    '        End If

    '    Catch ex As Exception
    '        LogError.Write("Error source: " & ex.Source & vbNewLine _
    '                     & "Error code: System error!" & vbNewLine _
    '                     & "Error message: " & ex.Message, EventLogEntryType.Error)
    '        MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
    '    End Try
    'End Sub

    'Private Sub MapExchangeStockTicker(ByVal v_strStockTicker As String)
    '    Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
    '    Try
    '        'Create message
    '        Dim v_strObjMsg As String, pv_xmlDocument As New Xml.XmlDocument
    '        'TruongLD Comment when convert
    '        'Dim v_ws As New AuthWS.AuthService
    '        'TruongLD Add when convert
    '        Dim v_ws As New AuthManagement
    '        'End TruongLD
    '        v_strObjMsg = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "MapExchangeStockTicker", , , "GetDate")
    '        pv_xmlDocument.LoadXml(v_strObjMsg)

    '        'Map exchange order book
    '        Dim nodeItem As Xml.XmlNode, pv_xmlSTCBook As New Xml.XmlDocument
    '        pv_xmlSTCBook.LoadXml(v_strStockTicker)
    '        nodeItem = pv_xmlDocument.ImportNode(pv_xmlSTCBook.SelectSingleNode("/StockTicker"), True)
    '        pv_xmlDocument.DocumentElement.AppendChild(nodeItem)

    '        'Send message to HOST to map
    '        v_strObjMsg = pv_xmlDocument.InnerXml
    '        v_lngError = v_ws.Message(v_strObjMsg)
    '        pv_xmlDocument.LoadXml(v_strObjMsg)
    '        If v_lngError <> ERR_SYSTEM_OK Then
    '            'Thông báo l?i
    '            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
    '            Cursor.Current = Cursors.Default
    '            Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": " + v_strErrorMessage
    '            Exit Sub
    '        Else
    '            Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": Map stock ticker successfully"
    '        End If
    '    Catch ex As Exception
    '        LogError.Write("Error source: " & ex.Source & vbNewLine _
    '                                 & "Error code: System error!" & vbNewLine _
    '                                 & "Error message: " & ex.Message, EventLogEntryType.Error)
    '        MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
    '    End Try
    'End Sub

    'Private Sub MapExchangeOrderBook(ByVal v_strSTCOrderBook As String)
    '    Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
    '    Try
    '        'Create message
    '        Dim v_strObjMsg As String, pv_xmlDocument As New Xml.XmlDocument
    '        'TruongLD Comment when convert
    '        'Dim v_ws As New AuthWS.AuthService
    '        'TruongLD Add when convert
    '        Dim v_ws As New AuthManagement
    '        'End TruongLD
    '        v_strObjMsg = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "MapExchangeOrderBook", , , "GetDate")
    '        pv_xmlDocument.LoadXml(v_strObjMsg)

    '        'Map exchange order book
    '        Dim nodeItem As Xml.XmlNode, pv_xmlSTCBook As New Xml.XmlDocument
    '        pv_xmlSTCBook.LoadXml(v_strSTCOrderBook)
    '        nodeItem = pv_xmlDocument.ImportNode(pv_xmlSTCBook.SelectSingleNode("/OrderBook"), True)
    '        pv_xmlDocument.DocumentElement.AppendChild(nodeItem)

    '        'Send message to HOST to map
    '        v_strObjMsg = pv_xmlDocument.InnerXml
    '        v_lngError = v_ws.Message(v_strObjMsg)
    '        pv_xmlDocument.LoadXml(v_strObjMsg)
    '        If v_lngError <> ERR_SYSTEM_OK Then
    '            'Thông báo l?i
    '            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
    '            Cursor.Current = Cursors.Default
    '            Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": " + v_strErrorMessage
    '            Exit Sub
    '        Else
    '            Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": Map exchange order book successfully"
    '        End If
    '    Catch ex As Exception
    '        LogError.Write("Error source: " & ex.Source & vbNewLine _
    '                                 & "Error code: System error!" & vbNewLine _
    '                                 & "Error message: " & ex.Message, EventLogEntryType.Error)
    '        MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
    '    End Try
    'End Sub

    'Private Sub MapExchangeTradeBook(ByVal v_strSTCTradeBook As String)
    '    Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
    '    Try
    '        'Create message
    '        Dim v_strObjMsg As String, pv_xmlDocument As New Xml.XmlDocument
    '        'TruongLD Comment when convert
    '        'Dim v_ws As New AuthWS.AuthService
    '        'TruongLD Add when convert
    '        Dim v_ws As New AuthManagement
    '        'End TruongLD
    '        v_strObjMsg = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "MapExchangeTradeBook", , , "GetDate")
    '        pv_xmlDocument.LoadXml(v_strObjMsg)

    '        'Map exchange order book
    '        Dim nodeItem As Xml.XmlNode, pv_xmlSTCBook As New Xml.XmlDocument
    '        pv_xmlSTCBook.LoadXml(v_strSTCTradeBook)
    '        nodeItem = pv_xmlDocument.ImportNode(pv_xmlSTCBook.SelectSingleNode("/TradeBook"), True)
    '        pv_xmlDocument.DocumentElement.AppendChild(nodeItem)

    '        'Send message to HOST to map
    '        v_strObjMsg = pv_xmlDocument.InnerXml
    '        v_lngError = v_ws.Message(v_strObjMsg)
    '        pv_xmlDocument.LoadXml(v_strObjMsg)
    '        If v_lngError <> ERR_SYSTEM_OK Then
    '            'Thông báo l?i
    '            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
    '            Cursor.Current = Cursors.Default
    '            Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": " + v_strErrorMessage
    '            Exit Sub
    '        Else
    '            Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": Map exchange trade book successfully"
    '        End If
    '    Catch ex As Exception
    '        LogError.Write("Error source: " & ex.Source & vbNewLine _
    '                                 & "Error code: System error!" & vbNewLine _
    '                                 & "Error message: " & ex.Message, EventLogEntryType.Error)
    '        MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
    '    End Try
    'End Sub

    'Private Sub BuyAmountTransferProcess()
    '    Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
    '    Try
    '        Dim v_strObjMsg As String, pv_xmlDocument As New Xml.XmlDocument
    '        Dim v_ws As New AuthManagement
    '        v_strObjMsg = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "BuyAmountTransfer", , , "GetDate")
    '        v_lngError = v_ws.Message(v_strObjMsg)
    '        pv_xmlDocument.LoadXml(v_strObjMsg)
    '        If v_lngError <> ERR_SYSTEM_OK Then
    '            'Thông báo l?i
    '            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
    '            Cursor.Current = Cursors.Default
    '            Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": " + v_strErrorMessage
    '            Exit Sub
    '        Else
    '            Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": Buy Amount Transfer Successfully!"
    '        End If

    '    Catch ex As Exception
    '        LogError.Write("Error source: " & ex.Source & vbNewLine _
    '                     & "Error code: System error!" & vbNewLine _
    '                     & "Error message: " & ex.Message, EventLogEntryType.Error)
    '        MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
    '    End Try
    'End Sub

    'Private Sub BuyFeeTransferProcess()
    '    Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
    '    Try
    '        Dim v_strObjMsg As String, pv_xmlDocument As New Xml.XmlDocument
    '        Dim v_ws As New AuthManagement
    '        v_strObjMsg = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "BuyFeeTransfer", , , "GetDate")
    '        v_lngError = v_ws.Message(v_strObjMsg)
    '        pv_xmlDocument.LoadXml(v_strObjMsg)
    '        If v_lngError <> ERR_SYSTEM_OK Then
    '            'Thông báo l?i
    '            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
    '            Cursor.Current = Cursors.Default
    '            Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": " + v_strErrorMessage
    '            Exit Sub
    '        Else
    '            Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": Buy fee Transfer Successfully!"
    '        End If

    '    Catch ex As Exception
    '        LogError.Write("Error source: " & ex.Source & vbNewLine _
    '                     & "Error code: System error!" & vbNewLine _
    '                     & "Error message: " & ex.Message, EventLogEntryType.Error)
    '        MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
    '    End Try
    'End Sub

    'Private Sub ExecuteCA3384Process()
    '    Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
    '    Try
    '        Dim v_strObjMsg As String, pv_xmlDocument As New Xml.XmlDocument
    '        Dim v_ws As New AuthManagement
    '        v_strObjMsg = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "ExecuteCA3384", , , "GetDate")
    '        v_lngError = v_ws.Message(v_strObjMsg)
    '        pv_xmlDocument.LoadXml(v_strObjMsg)
    '        If v_lngError <> ERR_SYSTEM_OK Then
    '            'Thông báo l?i
    '            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
    '            Cursor.Current = Cursors.Default
    '            Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": " + v_strErrorMessage
    '            Exit Sub
    '        Else
    '            Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": Execute CA 3384 Successfully!"
    '        End If

    '    Catch ex As Exception
    '        LogError.Write("Error source: " & ex.Source & vbNewLine _
    '                     & "Error code: System error!" & vbNewLine _
    '                     & "Error message: " & ex.Message, EventLogEntryType.Error)
    '        MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
    '    End Try
    'End Sub

    'Private Sub ExecuteCA3386Process()
    '    Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
    '    Try
    '        Dim v_strObjMsg As String, pv_xmlDocument As New Xml.XmlDocument
    '        Dim v_ws As New AuthManagement
    '        v_strObjMsg = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "ExecuteCA3386", , , "GetDate")
    '        v_lngError = v_ws.Message(v_strObjMsg)
    '        pv_xmlDocument.LoadXml(v_strObjMsg)
    '        If v_lngError <> ERR_SYSTEM_OK Then
    '            'Thông báo l?i
    '            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
    '            Cursor.Current = Cursors.Default
    '            Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": " + v_strErrorMessage
    '            Exit Sub
    '        Else
    '            Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": Execute CA 3386 Successfully!"
    '        End If

    '    Catch ex As Exception
    '        LogError.Write("Error source: " & ex.Source & vbNewLine _
    '                     & "Error code: System error!" & vbNewLine _
    '                     & "Error message: " & ex.Message, EventLogEntryType.Error)
    '        MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
    '    End Try
    'End Sub

    'Private Sub ExecuteCA3350Process()
    '    Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
    '    Try
    '        Dim v_strObjMsg As String, pv_xmlDocument As New Xml.XmlDocument
    '        Dim v_ws As New AuthManagement
    '        v_strObjMsg = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "ExecuteCA3350", , , "GetDate")
    '        v_lngError = v_ws.Message(v_strObjMsg)
    '        pv_xmlDocument.LoadXml(v_strObjMsg)
    '        If v_lngError <> ERR_SYSTEM_OK Then
    '            'Thông báo l?i
    '            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
    '            Cursor.Current = Cursors.Default
    '            Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": " + v_strErrorMessage
    '            Exit Sub
    '        Else
    '            Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": Execute CA 3350 Successfully!"
    '        End If

    '    Catch ex As Exception
    '        LogError.Write("Error source: " & ex.Source & vbNewLine _
    '                     & "Error code: System error!" & vbNewLine _
    '                     & "Error message: " & ex.Message, EventLogEntryType.Error)
    '        MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
    '    End Try
    'End Sub

    'Private Sub ExecuteCA3350DFProcess()
    '    Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
    '    Try
    '        Dim v_strObjMsg As String, pv_xmlDocument As New Xml.XmlDocument
    '        Dim v_ws As New AuthManagement
    '        v_strObjMsg = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "ExecuteCA3350DF", , , "GetDate")
    '        v_lngError = v_ws.Message(v_strObjMsg)
    '        pv_xmlDocument.LoadXml(v_strObjMsg)
    '        If v_lngError <> ERR_SYSTEM_OK Then
    '            'Thông báo l?i
    '            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
    '            Cursor.Current = Cursors.Default
    '            Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": " + v_strErrorMessage
    '            Exit Sub
    '        Else
    '            Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": Execute CA 3350 duty fee Successfully!"
    '        End If

    '    Catch ex As Exception
    '        LogError.Write("Error source: " & ex.Source & vbNewLine _
    '                     & "Error code: System error!" & vbNewLine _
    '                     & "Error message: " & ex.Message, EventLogEntryType.Error)
    '        MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
    '    End Try
    'End Sub

    'Private Sub ExecuteRM8879Process()
    '    Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
    '    Try
    '        Dim v_strObjMsg As String, pv_xmlDocument As New Xml.XmlDocument
    '        Dim v_ws As New AuthManagement
    '        v_strObjMsg = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "ExecuteRM8879", , , "GetDate")
    '        v_lngError = v_ws.Message(v_strObjMsg)
    '        pv_xmlDocument.LoadXml(v_strObjMsg)
    '        If v_lngError <> ERR_SYSTEM_OK Then
    '            'Thông báo l?i
    '            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
    '            Cursor.Current = Cursors.Default
    '            Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": " + v_strErrorMessage
    '            Exit Sub
    '        Else
    '            Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": Execute RM8879 Successfully!"
    '        End If

    '    Catch ex As Exception
    '        LogError.Write("Error source: " & ex.Source & vbNewLine _
    '                     & "Error code: System error!" & vbNewLine _
    '                     & "Error message: " & ex.Message, EventLogEntryType.Error)
    '        MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
    '    End Try
    'End Sub

    'Private Sub ExecuteRM8879DFProcess()
    '    Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
    '    Try
    '        Dim v_strObjMsg As String, pv_xmlDocument As New Xml.XmlDocument
    '        Dim v_ws As New AuthManagement
    '        v_strObjMsg = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "ExecuteRM8879DF", , , "GetDate")
    '        v_lngError = v_ws.Message(v_strObjMsg)
    '        pv_xmlDocument.LoadXml(v_strObjMsg)
    '        If v_lngError <> ERR_SYSTEM_OK Then
    '            'Thông báo l?i
    '            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
    '            Cursor.Current = Cursors.Default
    '            Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": " + v_strErrorMessage
    '            Exit Sub
    '        Else
    '            Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": Execute RM8879 Successfully!"
    '        End If

    '    Catch ex As Exception
    '        LogError.Write("Error source: " & ex.Source & vbNewLine _
    '                     & "Error code: System error!" & vbNewLine _
    '                     & "Error message: " & ex.Message, EventLogEntryType.Error)
    '        MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
    '    End Try
    'End Sub

    'Private Sub ExecuteTRFBatchProcess()
    '    Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
    '    Try
    '        Dim v_strObjMsg As String, pv_xmlDocument As New Xml.XmlDocument
    '        Dim v_ws As New AuthManagement
    '        v_strObjMsg = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "BankTrfReport", , , "GetDate", WsName, IpAddress)
    '        v_lngError = v_ws.Message(v_strObjMsg)
    '        pv_xmlDocument.LoadXml(v_strObjMsg)
    '        If v_lngError <> ERR_SYSTEM_OK Then
    '            'Thông báo l?i
    '            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
    '            Cursor.Current = Cursors.Default
    '            Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": " + v_strErrorMessage
    '            Exit Sub
    '        Else
    '            Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": Execute transfer batch Successfully!"
    '        End If

    '    Catch ex As Exception
    '        LogError.Write("Error source: " & ex.Source & vbNewLine _
    '                     & "Error code: System error!" & vbNewLine _
    '                     & "Error message: " & ex.Message, EventLogEntryType.Error)
    '        MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
    '    End Try
    'End Sub

    'Private Sub ExecuteGetBatchStsProcess()
    '    Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
    '    Try
    '        Dim v_strObjMsg As String, pv_xmlDocument As New Xml.XmlDocument
    '        Dim v_ws As New AuthManagement
    '        v_strObjMsg = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "BankGetReportSts", , , "GetDate", WsName, IpAddress)
    '        v_lngError = v_ws.Message(v_strObjMsg)
    '        pv_xmlDocument.LoadXml(v_strObjMsg)
    '        If v_lngError <> ERR_SYSTEM_OK Then
    '            'Thông báo l?i
    '            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
    '            Cursor.Current = Cursors.Default
    '            Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": " + v_strErrorMessage
    '            Exit Sub
    '        Else
    '            Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": Execute transfer batch Successfully!"
    '        End If

    '    Catch ex As Exception
    '        LogError.Write("Error source: " & ex.Source & vbNewLine _
    '                     & "Error code: System error!" & vbNewLine _
    '                     & "Error message: " & ex.Message, EventLogEntryType.Error)
    '        MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
    '    End Try
    'End Sub

    'Private Sub SendSMS()
    '    Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
    '    Try
    '        Dim v_strObjMsg As String, pv_xmlDocument As New Xml.XmlDocument
    '        Dim v_ws As New SMSService.SMSDeliveryClient
    '        v_lngError = v_ws.SendSMS()

    '        If v_lngError <> ERR_SYSTEM_OK Then
    '            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
    '            Cursor.Current = Cursors.Default
    '            Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": " + v_strErrorMessage
    '            Exit Sub
    '        Else
    '            Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": Send SMS Message successfully"
    '        End If
    '    Catch ex As Exception
    '        LogError.Write("Error source: " & ex.Source & vbNewLine _
    '                                 & "Error code: System error!" & vbNewLine _
    '                                 & "Error message: " & ex.Message, EventLogEntryType.Error)
    '        MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
    '    End Try
    'End Sub

    Private Sub ExecuteGetBankListProcess()
        Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
        Try
            Dim v_strObjMsg As String, pv_xmlDocument As New Xml.XmlDocument
            Dim v_ws As New AuthManagement
            v_strObjMsg = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "TCDTGetBankList", , , "GetDate", WsName, IpAddress)
            v_lngError = v_ws.Message(v_strObjMsg)
            pv_xmlDocument.LoadXml(v_strObjMsg)
            If v_lngError <> ERR_SYSTEM_OK Then
                'Thong bao loi
                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                Cursor.Current = Cursors.Default
                MessageBox.Show(v_strErrorMessage)
                Exit Sub
            ElseIf Not Me.chkAuto.Checked Then
                MessageBox.Show(mv_ResourceManager.GetString("MSG_GETLISTTRANFER"))
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub ExecuteSendBankRequestProcess()
        Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
        Try
            Dim v_strObjMsg As String, pv_xmlDocument As New Xml.XmlDocument
            Dim v_ws As New AuthManagement
            'v_strObjMsg = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "TCDTSendReconcide", , , "GetDate", WsName, IpAddress)
            v_strObjMsg = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "TCDTSendBankRequest", , , "GetDate", WsName, IpAddress)
            v_lngError = v_ws.Message(v_strObjMsg)
            pv_xmlDocument.LoadXml(v_strObjMsg)
            If v_lngError <> ERR_SYSTEM_OK Then
                'Thong bao loi
                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                If Not Me.chkAuto.Checked Then
                    'Thong bao loi
                    Cursor.Current = Cursors.Default
                    MessageBox.Show(v_strErrorMessage)
                Else
                    LogMessage(v_strErrorMessage)
                End If
                Exit Sub
            ElseIf Not Me.chkAuto.Checked Then
                MessageBox.Show(mv_ResourceManager.GetString("MSG_SENDCOMPLETE"))
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub ExecuteReceiveBankRequestProcess()

        Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
        Try
            Dim v_strObjMsg As String, pv_xmlDocument As New Xml.XmlDocument
            Dim v_ws As New AuthManagement
            v_strObjMsg = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "TCDTReceiveBankRequest", , , "GetDate", WsName, IpAddress)
            v_lngError = v_ws.Message(v_strObjMsg)
            pv_xmlDocument.LoadXml(v_strObjMsg)
            If v_lngError <> ERR_SYSTEM_OK Then
                'Thong bao loi
                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                If Not Me.chkAuto.Checked Then
                    'Thong bao loi
                    Cursor.Current = Cursors.Default
                    MessageBox.Show(v_strErrorMessage)
                Else
                    LogMessage(v_strErrorMessage)
                End If

                Exit Sub
            ElseIf Not Me.chkAuto.Checked Then
                MessageBox.Show(mv_ResourceManager.GetString("MSG_REVSUCCESS"))
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub ExecuteReconcideBankRequest()
        'HaiLT enable phuc vu test ban that
        'Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
        'Try
        '    Dim v_strObjMsg As String, pv_xmlDocument As New Xml.XmlDocument
        '    Dim v_ws As New AuthManagement
        '    v_strObjMsg = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "TCDTTransferReconcide", , , "GetDate", WsName, IpAddress)
        '    v_lngError = v_ws.Message(v_strObjMsg)
        '    pv_xmlDocument.LoadXml(v_strObjMsg)
        '    If v_lngError <> ERR_SYSTEM_OK Then
        '        'Thong bao loi
        '        GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
        '        Cursor.Current = Cursors.Default
        '        MessageBox.Show(v_strErrorMessage)
        '        Exit Sub
        '    ElseIf Not Me.chkAuto.Checked Then
        '        MessageBox.Show("Đã nhận kết quả đối chiếu, kết quả vui lòng xem view chi tiết!")
        '    End If

        'Catch ex As Exception
        '    LogError.Write("Error source: " & ex.Source & vbNewLine _
        '                 & "Error code: System error!" & vbNewLine _
        '                 & "Error message: " & ex.Message, EventLogEntryType.Error)
        '    MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        'End Try
    End Sub

    Private Sub ExecuteSendReconcide()

        Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
        Try
            Dim v_strObjMsg As String, pv_xmlDocument As New Xml.XmlDocument
            Dim v_ws As New AuthManagement
            v_strObjMsg = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "TCDTSendReconcide", , , "GetDate", WsName, IpAddress)
            v_lngError = v_ws.Message(v_strObjMsg)
            pv_xmlDocument.LoadXml(v_strObjMsg)
            If v_lngError <> ERR_SYSTEM_OK Then
                'Thong bao loi
                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                Cursor.Current = Cursors.Default
                MessageBox.Show(v_strErrorMessage)
                Exit Sub
            ElseIf Not Me.chkAuto.Checked Then
                MessageBox.Show("Đã gửi đối soát thành công!")
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub ExecuteGetTransferResult()
        Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
        Try
            Dim v_strObjMsg As String, pv_xmlDocument As New Xml.XmlDocument
            Dim v_ws As New AuthManagement
            v_strObjMsg = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "TCDTGetTransferResult", , , "GetDate", WsName, IpAddress)
            v_lngError = v_ws.Message(v_strObjMsg)
            pv_xmlDocument.LoadXml(v_strObjMsg)
            If v_lngError <> ERR_SYSTEM_OK Then
                'Thong bao loi
                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                If Not Me.chkAuto.Checked Then
                    'Thong bao loi
                    Cursor.Current = Cursors.Default
                    MessageBox.Show(v_strErrorMessage)
                Else
                    LogMessage(v_strErrorMessage)
                End If
                Exit Sub
            ElseIf Not Me.chkAuto.Checked Then
                MessageBox.Show(mv_ResourceManager.GetString("MSG_GETSTATUS"))
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub CallProcess1104()
        Dim v_strCmdSQL, v_strObjMsg, v_strClause As String
        Dim v_ws As New BDSDeliveryManagement
        Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
        Try

            Dim pv_xmlDocument As New Xml.XmlDocument
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, "CI.CIMAST", gc_ActionAdhoc, , v_strClause, "CallProcess1104", gc_AutoIdUsed, , "12345", WsName, IpAddress)
            v_lngError = v_ws.Message(v_strObjMsg)
            pv_xmlDocument.LoadXml(v_strObjMsg)
            If v_lngError <> ERR_SYSTEM_OK Then
                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                If Not Me.chkAuto.Checked Then
                    'Thong bao loi
                    Cursor.Current = Cursors.Default
                    MessageBox.Show(v_strErrorMessage)
                Else
                    LogMessage(v_strErrorMessage)
                End If
                Exit Sub
            ElseIf Not Me.chkAuto.Checked Then
                MessageBox.Show(mv_ResourceManager.GetString("MSG_CTRSUCCESS"))
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CallProcess1141()
        Dim v_strCmdSQL, v_strObjMsg, v_strClause As String
        Dim v_ws As New BDSDeliveryManagement
        Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
        Try

            Dim pv_xmlDocument As New Xml.XmlDocument
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, "CI.CIMAST", gc_ActionAdhoc, , v_strClause, "CallProcess1141", gc_AutoIdUsed, , "12345", WsName, IpAddress)
            v_lngError = v_ws.Message(v_strObjMsg)
            pv_xmlDocument.LoadXml(v_strObjMsg)
            If v_lngError <> ERR_SYSTEM_OK Then
                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                If Not Me.chkAuto.Checked Then
                    'Thong bao loi
                    Cursor.Current = Cursors.Default
                    MessageBox.Show(v_strErrorMessage)
                Else
                    LogMessage(v_strErrorMessage)
                End If

                Exit Sub
            ElseIf Not Me.chkAuto.Checked Then
                MessageBox.Show(mv_ResourceManager.GetString("MSG_REVTRSUCCESS"))
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tabControl_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabControl.SelectedIndexChanged

        Dim v_strTabPageName = tabControl.TabPages(tabControl.SelectedIndex).Name.ToLower
        If String.Compare(v_strTabPageName, tbSendRequest.Name.ToLower) = 0 Then
            btnEditRequest.Enabled = True
            btnChangRequest.Enabled = True
        ElseIf String.Compare(v_strTabPageName, tbReceiveRequest.Name.ToLower) = 0 Then
            btnEditRequest.Enabled = True
            btnChangRequest.Enabled = True
        ElseIf String.Compare(v_strTabPageName, tbBankList.Name.ToLower) = 0 Then
            btnEditRequest.Enabled = False
            btnChangRequest.Enabled = False
        End If

        GetDataForGrid(tabControl.SelectedIndex)

    End Sub


#End Region

    Public Sub GetDataForGrid(ByVal vTab As Integer)
        Dim v_strCmdInquiry, v_strFilter, v_strObjMsg, v_strCmdSQL, v_strClause As String
        Dim v_ws As New BDSDeliveryManagement


        Select Case vTab
            Case 0
                'v_strCmdInquiry = "SELECT mst.REQID,mst.TRFCODE,mst.REFCODE,TO_CHAR(mst.TXDATE,'DD/MM/RRRR') TXDATE,mst.OBJKEY," & _
                '           " cf.custodycd, mst.AFACCTNO,mst.diraccname accname,mst.TXAMT, mst.DIRBANKCODE BANKCODE,mst.BANKACCT, " & _
                '           " mst.dirbankname BANKNAME, mst.dirbankcity BANKCITY, fn_gettcdtdesbankacc(substr(mst.AFACCTNO,1,4)) DESACCTNO, " & _
                '           " fn_gettcdtdesbankname(substr(mst.AFACCTNO,1,4)) DESACCTNAME,MST.STATUS, mst.NOTES, MST.ERRORDESC" & _
                '           " FROM CRBTXREQ MST,CIREMITTANCE rm, afmast af, cfmast cf" & _
                '           " WHERE MST.OBJTYPE = 'T' AND MST.VIA = 'DIR'" & _
                '           " and mst.afacctno = af.acctno and af.custid = cf.custid and mst.txdate = rm.txdate and rm.txnum = mst.objkey and rm.rmstatus ='P'" & _
                '           " order by mst.reqid"
                'v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, "N", gc_MsgTypeObj, OBJNAME_OD_ODMAST, gc_ActionInquiry, v_strCmdInquiry)


                v_strCmdSQL = "getcrbtxreq_info"
                v_strClause = "v_TABLE!" & "CRBTXREQ" & "!varchar2!20"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strCmdSQL, v_strClause, , , , , , , gc_CommandProcedure)
                v_ws.Message(v_strObjMsg)
                FillDataGrid(SendReq, v_strObjMsg, "")
                If SendReq.DataRows.Count > 0 Then
                    SendReq.CurrentRow = SendReq.DataRows(0)
                    SendReq.SelectedRows.Clear()
                    SendReq.SelectedRows.Add(SendReq.CurrentRow)
                End If
            Case 1
                'v_strCmdInquiry = "SELECT CRB.autoid, CRB.txdate, CRB.transactionnumber, A1.CDCONTENT status, CRB.trnref, " & _
                '                   " CRB.trn_dt, CRB.desbankaccount, CRB.accname, CRB.accnum, CRB.bankcode,  " & _
                '                   " CRB.branch, CRB.location, CRB.amount, CRB.keyacct1, CRB.keyacct2, " & _
                '                   " CRB.transactiondescription, CRB.isconfirmed, CRB.ismanual, " & _
                '                   " CRB.usercreated, CRB.createdt, CRB.errordesc " & _
                '                   " FROM crbbankrequest CRB, ALLCODE A1 where CRB.STATUS =A1.CDVAL AND A1.CDTYPE = 'RM' AND A1.CDNAME = 'CRBRQDSTS' AND CRB.status <> 'C' order by autoid"

                'v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, "N", gc_MsgTypeObj, OBJNAME_OD_ODMAST, gc_ActionInquiry, v_strCmdInquiry)

                v_strCmdSQL = "getcrbbankrequest_info"
                v_strClause = "v_TABLE!" & "CRBBANKREQUEST" & "!varchar2!20"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strCmdSQL, v_strClause, , , , , , , gc_CommandProcedure)
                v_ws.Message(v_strObjMsg)

                FillDataGrid(RecReq, v_strObjMsg, "")
                If RecReq.DataRows.Count > 0 Then
                    RecReq.CurrentRow = RecReq.DataRows(0)
                    RecReq.SelectedRows.Clear()
                    RecReq.SelectedRows.Add(RecReq.CurrentRow)
                End If
            Case 2
                v_strCmdInquiry = "SELECT * FROM crbbanklist"

                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, "N", gc_MsgTypeObj, OBJNAME_OD_ODMAST, gc_ActionInquiry, v_strCmdInquiry)
                'Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                v_ws.Message(v_strObjMsg)

                FillDataGrid(BankList, v_strObjMsg, "")
                If BankList.DataRows.Count > 0 Then
                    BankList.CurrentRow = BankList.DataRows(0)
                    BankList.SelectedRows.Clear()
                    BankList.SelectedRows.Add(BankList.CurrentRow)
                End If
        End Select

    End Sub


    Private Sub tmAutoProcess_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmAutoProcess.Tick
        If Me.chkAuto.Checked Then
            OnProcess()
        End If
    End Sub

    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        tmAutoProcess.Enabled = False
        If Me.chkAuto.Checked Then
            Dim v_strINTERVAL As String = Me.txtInterval.Text
            If IsNumeric(v_strINTERVAL) Then
                Me.tmAutoProcess.Interval = CDbl(v_strINTERVAL) * 1000
            Else
                Me.tmAutoProcess.Interval = 180000
            End If
            tmAutoProcess.Enabled = True
            btnSubmit.Enabled = False
            OnProcess()
        Else
            OnProcess()
            tmAutoProcess.Enabled = False
        End If
    End Sub

    Private Sub chkAuto_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAuto.CheckedChanged

        If chkAuto.Checked Then
            Dim v_strINTERVAL As String = Me.txtInterval.Text
            If IsNumeric(v_strINTERVAL) Then
                Me.tmAutoProcess.Interval = CDbl(v_strINTERVAL) * 1000
            Else
                Me.tmAutoProcess.Interval = 180000
            End If
            Me.btnGetTransferResult.Enabled = False
            Me.btnReceiveRequest.Enabled = False
            Me.btnSendRequest.Enabled = False
        Else
            Me.btnGetTransferResult.Enabled = True
            Me.btnReceiveRequest.Enabled = True
            Me.btnSendRequest.Enabled = True
            Me.btnSubmit.Enabled = True
            tmAutoProcess.Enabled = False
        End If
    End Sub

    Private Sub frmRMBankRequest_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        tmAutoProcess.Enabled = False
    End Sub

    Private Sub chklistTasks_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnGetBank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetBank.Click
        ExecuteGetBankListProcess()
    End Sub

    Private Sub btnSendRequest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendRequest.Click
        ExecuteSendBankRequestProcess()
        'Lay lai du lieu cho tab Y/C Chi ho
        GetDataForGrid(0)
    End Sub

    Private Sub btnReceiveRequest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReceiveRequest.Click
        ExecuteReceiveBankRequestProcess()
    End Sub

    Private Sub btnChangRequest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangRequest.Click

        If tabControl.SelectedIndex = 0 Then
            If Not (SendReq.CurrentRow Is Nothing) Then
                Dim v_frm As New frmRMChangeRequest
                v_frm.BranchId = BranchId
                v_frm.UserLanguage = UserLanguage
                v_frm.ModuleCode = ModuleCode
                v_frm.ExeFlag = ExecuteFlag.Edit
                v_frm.ObjectName = "RM.CRBTXREQ"
                v_frm.TableName = "CRBTXREQ"
                v_frm.LocalObject = "N"
                v_frm.BusDate = Me.BusDate
                v_frm.KeyFieldName = "REQID"
                v_frm.KeyFieldType = "N"
                v_frm.KeyFieldValue = Trim(CType(SendReq.CurrentRow, Xceed.Grid.DataRow).Cells("REQID").Value)
                v_frm.ReqID = Trim(CType(SendReq.CurrentRow, Xceed.Grid.DataRow).Cells("REQID").Value)
                v_frm.EditInfo = True
                v_frm.ShowDialog()
            End If
        Else
            If Not (RecReq.CurrentRow Is Nothing) Then
                'Dim v_frm As New frmRMRecChangeRequest
                'v_frm.BranchId = BranchId
                'v_frm.UserLanguage = UserLanguage
                'v_frm.ModuleCode = ModuleCode
                'v_frm.ExeFlag = ExecuteFlag.Edit
                'v_frm.ObjectName = "RM.CRBBANKREQUEST"
                'v_frm.TableName = "CRBBANKREQUEST"
                'v_frm.LocalObject = "N"
                'v_frm.BusDate = Me.BusDate
                'v_frm.KeyFieldName = "AUTOID"
                'v_frm.KeyFieldType = "N"
                'v_frm.KeyFieldValue = Trim(CType(RecReq.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value)
                'v_frm.ReqID = Trim(CType(RecReq.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value)
                'v_frm.EditInfo = True
                'v_frm.ShowDialog()

                Dim v_frm As New frmRMManualMsg
                v_frm.BranchId = BranchId
                v_frm.UserLanguage = UserLanguage
                v_frm.ModuleCode = ModuleCode
                v_frm.ExeFlag = ExecuteFlag.Edit
                v_frm.ObjectName = "RM.CRBBANKREQUEST"
                v_frm.TableName = "CRBBANKREQUEST"
                v_frm.LocalObject = "N"
                v_frm.EditInfo = True
                v_frm.BusDate = Me.BusDate
                v_frm.KeyFieldName = "AUTOID"
                v_frm.KeyFieldType = "N"
                v_frm.KeyFieldValue = Trim(CType(RecReq.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value)
                v_frm.ReqID = Trim(CType(RecReq.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value)
                v_frm.ShowDialog()


            End If
        End If

        GetDataForGrid(tabControl.SelectedIndex)
    End Sub

    Private Sub btnEditRequest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditRequest.Click
        If tabControl.SelectedIndex = 0 Then
            If Not (SendReq.CurrentRow Is Nothing) Then
                Dim v_frm As New frmRMChangeRequest
                v_frm.BranchId = BranchId
                v_frm.UserLanguage = UserLanguage
                v_frm.ModuleCode = ModuleCode
                v_frm.ExeFlag = ExecuteFlag.Edit
                v_frm.ObjectName = "RM.CRBTXREQ"
                v_frm.TableName = "CRBTXREQ"
                v_frm.LocalObject = "N"
                v_frm.BusDate = Me.BusDate
                v_frm.KeyFieldName = "REQID"
                v_frm.KeyFieldType = "N"
                v_frm.KeyFieldValue = Trim(CType(SendReq.CurrentRow, Xceed.Grid.DataRow).Cells("REQID").Value)
                v_frm.ReqID = Trim(CType(SendReq.CurrentRow, Xceed.Grid.DataRow).Cells("REQID").Value)
                v_frm.EditInfo = False
                v_frm.ShowDialog()
            End If
        Else
            If Not (RecReq.CurrentRow Is Nothing) Then
                'Dim v_frm As New frmRMRecChangeRequest
                'v_frm.BranchId = BranchId
                'v_frm.UserLanguage = UserLanguage
                'v_frm.ModuleCode = ModuleCode
                'v_frm.ExeFlag = ExecuteFlag.Edit
                'v_frm.ObjectName = "RM.CRBBANKREQUEST"
                'v_frm.TableName = "CRBBANKREQUEST"
                'v_frm.LocalObject = "N"
                'v_frm.BusDate = Me.BusDate
                'v_frm.KeyFieldName = "AUTOID"
                'v_frm.KeyFieldType = "N"
                'v_frm.KeyFieldValue = Trim(CType(RecReq.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value)
                'v_frm.ReqID = Trim(CType(RecReq.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value)
                'v_frm.EditInfo = False
                'v_frm.ShowDialog()
                Dim v_frm As New frmRMManualMsg
                v_frm.BranchId = BranchId
                v_frm.UserLanguage = UserLanguage
                v_frm.ModuleCode = ModuleCode
                v_frm.ExeFlag = ExecuteFlag.Edit
                v_frm.ObjectName = "RM.CRBBANKREQUEST"
                v_frm.TableName = "CRBBANKREQUEST"
                v_frm.LocalObject = "N"
                v_frm.BusDate = Me.BusDate
                v_frm.KeyFieldName = "AUTOID"
                v_frm.KeyFieldType = "N"
                v_frm.EditInfo = False
                v_frm.KeyFieldValue = Trim(CType(RecReq.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value)
                v_frm.ReqID = Trim(CType(RecReq.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value)
                v_frm.ShowDialog()

            End If
        End If
        GetDataForGrid(tabControl.SelectedIndex)
    End Sub

    Private Sub btnReconcide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReconcide.Click
        ExecuteReconcideBankRequest()
        'ExecuteSendReconcide()
    End Sub

    Private Sub frmRMBankRequest_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        Select Case e.KeyCode
            Case Keys.Escape
                Onclose()
        End Select
    End Sub
    Public Delegate Sub AsyncUpdateGetTransferGui(ByVal v_isEnable As Boolean)
    Private Sub UpdateGetTransferGui(ByVal v_isEnable As Boolean)
        If btnGetTransferResult.InvokeRequired Then
            btnGetTransferResult.Invoke(New AsyncUpdateGetTransferGui(AddressOf UpdateGetTransferGui), v_isEnable)
        Else
            btnGetTransferResult.Enabled = v_isEnable
            If v_isEnable Then
                GetDataForGrid(0)
            End If
        End If
    End Sub

    Private Sub ExecuteGetTransferResultByThread()
        ExecuteGetTransferResult()
        If Me.InvokeRequired Then
            'Me.Invoke(New AsyncGetDataForGrid(AddressOf GetDataForGrid), 0)
            'Lay lai du lieu cho tab Y/C Chi ho
        Else
            GetDataForGrid(0)
        End If
    End Sub

    'Private Sub btnGetTransferResult_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetTransferResult.Click
    '    'ExecuteGetTransferResult()
    '    ''Lay lai du lieu cho tab Y/C Chi ho
    '    'GetDataForGrid(0)
    '    ThreadPool.QueueUserWorkItem(AddressOf ExecuteGetTransferResultByThread)
    'End Sub

    Private Sub btnGetTransferResult_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetTransferResult.Click
        ExecuteGetTransferResult()
        'Lay lai du lieu cho tab Y/C Chi ho
        GetDataForGrid(0)

    End Sub

    Private Sub btnManualMsg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnManualMsg.Click
        Dim v_frm As New frmRMManualMsg
        v_frm.BranchId = BranchId
        v_frm.UserLanguage = UserLanguage
        v_frm.ModuleCode = ModuleCode
        v_frm.ExeFlag = ExecuteFlag.AddNew
        v_frm.ObjectName = "RM.CRBBANKREQUEST"
        v_frm.TableName = "CRBBANKREQUEST"
        v_frm.LocalObject = "N"
        v_frm.BusDate = Me.BusDate
        v_frm.TellerId = Me.TellerId
        v_frm.EditInfo = True
        'v_frm.KeyFieldName = "AUTOID"
        'v_frm.KeyFieldType = "N"
        'v_frm.KeyFieldValue = Trim(CType(RecReq.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value)
        'v_frm.ReqID = Trim(CType(RecReq.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value)        
        v_frm.ShowDialog()
    End Sub


    'Private Sub CorebankFOHoldDirect(ByVal pv_AFACCTNO As String, ByVal pv_AMOUNT As Double)
    '    Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
    '    Try
    '        Dim v_strObjMsg As String, pv_xmlDocument As New Xml.XmlDocument
    '        Dim v_ws As New AuthManagement
    '        v_strObjMsg = BuildXMLObjMsg(, "0001", , "6868", "N", "O", "SY.AUTH", "INQUIRY", , , "BankFOHoldDirect", , , "HOLD|" & pv_AFACCTNO & "|" & pv_AMOUNT.ToString, WsName, IpAddress)
    '        v_lngError = v_ws.Message(v_strObjMsg)
    '        pv_xmlDocument.LoadXml(v_strObjMsg)
    '        If v_lngError <> ERR_SYSTEM_OK Then
    '            'Thong bao loi
    '            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
    '            Cursor.Current = Cursors.Default
    '            MessageBox.Show(v_strErrorMessage)
    '            Exit Sub
    '        Else
    '            MessageBox.Show("Lấy trạng thái thành công. Xem lại danh sách chi hộ để có thông tin chi tiết!")
    '        End If

    '    Catch ex As Exception
    '        LogError.Write("Error source: " & ex.Source & vbNewLine _
    '                     & "Error code: System error!" & vbNewLine _
    '                     & "Error message: " & ex.Message, EventLogEntryType.Error)
    '        MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
    '    End Try
    'End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        GetDataForGrid(tabControl.SelectedIndex)
    End Sub
    Public Sub LogMessage(ByVal pv_strMessage As String)
        Dim v_strPath As String = AppDomain.CurrentDomain.BaseDirectory.Replace("bin\Debug\", "").Replace("bin\Release\", "") & "MessageLog\"
        Dim v_strFileName As String = "LogError_" & DateTime.Now.ToString("yyyyMMdd") & ".txt"

        Try
            If Not Directory.Exists(v_strPath) Then
                Directory.CreateDirectory(v_strPath)
            End If

            Dim fs As New FileStream(v_strPath & v_strFileName, FileMode.Append, FileAccess.Write, FileShare.ReadWrite)
            If Not fs Is Nothing Then
                Dim sw As New StreamWriter(fs)
                Dim v_strMessage As String = "[" & DateTime.Now.ToString("dd/MM/yyyy") & " - " & DateTime.Now.ToString("HH:mm:ss") & "] ErrorMessage: " & pv_strMessage
                sw.WriteLine(v_strMessage)
                sw.Flush()
                sw.Close()
                fs.Close()
            End If
        Catch ex As Exception
            LogError.Write("Error source: frmRMBANKREQUEST.LogMessage" & vbNewLine _
                        & "Error message: " & ex.Message, EventLogEntryType.Error)
        End Try
    End Sub

End Class
