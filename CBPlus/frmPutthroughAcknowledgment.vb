Imports System.Windows.Forms
Imports Xceed.SmartUI.Controls
Imports CommonLibrary
Imports System.Collections
Imports AppCore
Imports AppCore.modCoreLib


Public Class frmPutthroughAcknowledgment
    Inherits System.Windows.Forms.Form
#Region " Declare constant and variables "
    Const c_ResourceManager = "_DIRECT.frmPutthroughAcknowledgment-"
    Public PTMsgGrid, PTCancelMsgGrid, PTDealGrid, PTAdvGrid, PTAdvAllGrid As GridEx
    Dim mv_strEXECTYPE, mv_strEXECTYPE_VAL, mv_strCUSTODYCD, mv_strSYMBOL As String
    Dim mv_strOODSTATUS, mv_strPRICE, mv_strQTTY, mv_strORDERID, mv_strORDERQTTY, mv_strDESC_PRICETYPE, mv_strQUOTEPRICE, mv_strLIMITPRICE As String
    Dim mv_strCURRPRICE, mv_strMATCHTYPE, mv_strNORK, mv_strCODEID, mv_strSECURERATIOTMIN, mv_strSECURERATIOMAX, mv_strTYP_BRATIO, mv_strAF_BRATIO As String
    Dim mv_strCIACCTNO, mv_strSEACCTNO, mv_strAFACCTNO, mv_strPARVALUE, mv_strTradePlace, mv_strPriceType, mv_strSecType As String

    Dim mv_strLastAFACCTNO As String = String.Empty
    Dim mv_dblFloorPrice As Double
    Dim mv_dblCeilingPrice As Double
    Dim mv_dblTradeLot As Double
    Dim mv_dblTradeUnit As Double
    Dim mv_dblSecureRatio As Double

    Private mv_blnIsPutthrough As Boolean = False
    Private mv_strAction As String = "N"
    Private mv_strSQLCMD As String = String.Empty
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
    Private mv_strTellerType As String
    Private mv_strIpAddress As String
    Private mv_strWsName As String
    Private mv_strBusDate As String = String.Empty
    Private mv_strTxDate As String = String.Empty
    Private mv_strTxNum As String = String.Empty

    Private mv_blnOrderSendingEx As Boolean = True
    Private mv_intCurrentRow As Integer

    Private Const CONTROL_PNL_CONTRACT_TOP = 200
    Private Const CONTROL_BUTTON_TOP = 400
    Private Const FRM_DEFAULT_HEIGHT = 260
    Private Const FRM_EXTEND_HEIGHT = 460
    Friend WithEvents tpPutthroughAdvAll As System.Windows.Forms.TabPage
    Friend WithEvents pnPTAdvAll As System.Windows.Forms.Panel

    Private mv_strOrderStatus As String
#End Region

#Region " Properties "
    Public Property IsPutthought() As Boolean
        Get
            Return mv_blnIsPutthrough
        End Get
        Set(ByVal Value As Boolean)
            mv_blnIsPutthrough = Value
        End Set
    End Property

    Public Property Action() As String
        Get
            Return mv_strAction
        End Get
        Set(ByVal Value As String)
            mv_strAction = Value
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
    Public Property OrderSendingEx() As Boolean
        Get
            Return mv_blnOrderSendingEx
        End Get
        Set(ByVal Value As Boolean)
            mv_blnOrderSendingEx = Value
        End Set
    End Property
#End Region

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal pv_strLanguage As String)
        MyBase.New()
        InitializeComponent()
        mv_strLanguage = pv_strLanguage
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        InitializeGrid()
        'This call is required by the Windows Form Designer.
        'Add any initialization after the InitializeComponent() call
        InitDialog()
        'Add any initialization after the InitializeComponent() call
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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnConfirm As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpPutthroughAck As System.Windows.Forms.TabPage
    Friend WithEvents tpPutthroughCancelAck As System.Windows.Forms.TabPage
    Friend WithEvents btnReject As System.Windows.Forms.Button
    Friend WithEvents pnPutthrough As System.Windows.Forms.Panel
    Friend WithEvents pnPutthroughCancel As System.Windows.Forms.Panel
    Friend WithEvents tpPutthroughDeal As System.Windows.Forms.TabPage
    Friend WithEvents pnPTDeal As System.Windows.Forms.Panel
    Friend WithEvents tpPutthroughAdv As System.Windows.Forms.TabPage
    Friend WithEvents pnPTAdv As System.Windows.Forms.Panel
    Friend WithEvents grbAdvMsg As System.Windows.Forms.GroupBox
    Friend WithEvents lblSYMBOL As System.Windows.Forms.Label
    Friend WithEvents lblSIDE As System.Windows.Forms.Label
    Friend WithEvents lblBOARD As System.Windows.Forms.Label
    Friend WithEvents lblVOLUME As System.Windows.Forms.Label
    Friend WithEvents lblPRICE As System.Windows.Forms.Label
    Friend WithEvents lblCONTACT As System.Windows.Forms.Label
    Friend WithEvents btnADD As System.Windows.Forms.Button
    Friend WithEvents ckbACTIVE As System.Windows.Forms.CheckBox
    Friend WithEvents cboBOARD As ComboBoxEx
    Friend WithEvents txtPRICE As System.Windows.Forms.TextBox
    Friend WithEvents txtVOLUME As System.Windows.Forms.TextBox
    Friend WithEvents cboSIDE As ComboBoxEx
    Friend WithEvents cboSYMBOL As ComboBoxEx
    Friend WithEvents btnACTIVE As System.Windows.Forms.Button
    Friend WithEvents btnCANCEL As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnDELETE As System.Windows.Forms.Button
    Friend WithEvents txtCONTACT As System.Windows.Forms.TextBox
    Friend WithEvents lblInfoCeilFloor As System.Windows.Forms.Label
    Friend WithEvents txtToCompID As System.Windows.Forms.TextBox
    Friend WithEvents lblToCompID As System.Windows.Forms.Label
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPutthroughAcknowledgment))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tpPutthroughAck = New System.Windows.Forms.TabPage
        Me.pnPutthrough = New System.Windows.Forms.Panel
        Me.tpPutthroughCancelAck = New System.Windows.Forms.TabPage
        Me.pnPutthroughCancel = New System.Windows.Forms.Panel
        Me.tpPutthroughDeal = New System.Windows.Forms.TabPage
        Me.pnPTDeal = New System.Windows.Forms.Panel
        Me.tpPutthroughAdv = New System.Windows.Forms.TabPage
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnDELETE = New System.Windows.Forms.Button
        Me.btnACTIVE = New System.Windows.Forms.Button
        Me.btnCANCEL = New System.Windows.Forms.Button
        Me.grbAdvMsg = New System.Windows.Forms.GroupBox
        Me.lblToCompID = New System.Windows.Forms.Label
        Me.txtToCompID = New System.Windows.Forms.TextBox
        Me.lblInfoCeilFloor = New System.Windows.Forms.Label
        Me.btnADD = New System.Windows.Forms.Button
        Me.lblCONTACT = New System.Windows.Forms.Label
        Me.lblPRICE = New System.Windows.Forms.Label
        Me.lblVOLUME = New System.Windows.Forms.Label
        Me.lblBOARD = New System.Windows.Forms.Label
        Me.lblSIDE = New System.Windows.Forms.Label
        Me.lblSYMBOL = New System.Windows.Forms.Label
        Me.ckbACTIVE = New System.Windows.Forms.CheckBox
        Me.txtCONTACT = New System.Windows.Forms.TextBox
        Me.cboBOARD = New AppCore.ComboBoxEx
        Me.txtPRICE = New System.Windows.Forms.TextBox
        Me.txtVOLUME = New System.Windows.Forms.TextBox
        Me.cboSIDE = New AppCore.ComboBoxEx
        Me.cboSYMBOL = New AppCore.ComboBoxEx
        Me.pnPTAdv = New System.Windows.Forms.Panel
        Me.tpPutthroughAdvAll = New System.Windows.Forms.TabPage
        Me.pnPTAdvAll = New System.Windows.Forms.Panel
        Me.btnConfirm = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnReject = New System.Windows.Forms.Button
        Me.btnRefresh = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tpPutthroughAck.SuspendLayout()
        Me.tpPutthroughCancelAck.SuspendLayout()
        Me.tpPutthroughDeal.SuspendLayout()
        Me.tpPutthroughAdv.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grbAdvMsg.SuspendLayout()
        Me.tpPutthroughAdvAll.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TabControl1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(792, 536)
        Me.Panel1.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tpPutthroughAck)
        Me.TabControl1.Controls.Add(Me.tpPutthroughCancelAck)
        Me.TabControl1.Controls.Add(Me.tpPutthroughDeal)
        Me.TabControl1.Controls.Add(Me.tpPutthroughAdv)
        Me.TabControl1.Controls.Add(Me.tpPutthroughAdvAll)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(792, 536)
        Me.TabControl1.TabIndex = 0
        '
        'tpPutthroughAck
        '
        Me.tpPutthroughAck.Controls.Add(Me.pnPutthrough)
        Me.tpPutthroughAck.Location = New System.Drawing.Point(4, 22)
        Me.tpPutthroughAck.Name = "tpPutthroughAck"
        Me.tpPutthroughAck.Size = New System.Drawing.Size(784, 510)
        Me.tpPutthroughAck.TabIndex = 0
        Me.tpPutthroughAck.Tag = "PutthroughAck"
        Me.tpPutthroughAck.Text = "Put through deal acknowledgment"
        Me.tpPutthroughAck.UseVisualStyleBackColor = True
        '
        'pnPutthrough
        '
        Me.pnPutthrough.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnPutthrough.Location = New System.Drawing.Point(0, 0)
        Me.pnPutthrough.Name = "pnPutthrough"
        Me.pnPutthrough.Size = New System.Drawing.Size(784, 510)
        Me.pnPutthrough.TabIndex = 0
        '
        'tpPutthroughCancelAck
        '
        Me.tpPutthroughCancelAck.Controls.Add(Me.pnPutthroughCancel)
        Me.tpPutthroughCancelAck.Location = New System.Drawing.Point(4, 22)
        Me.tpPutthroughCancelAck.Name = "tpPutthroughCancelAck"
        Me.tpPutthroughCancelAck.Size = New System.Drawing.Size(784, 510)
        Me.tpPutthroughCancelAck.TabIndex = 1
        Me.tpPutthroughCancelAck.Tag = "PutthroughCancelAck"
        Me.tpPutthroughCancelAck.Text = "Put through cancel acknowledgment"
        Me.tpPutthroughCancelAck.UseVisualStyleBackColor = True
        '
        'pnPutthroughCancel
        '
        Me.pnPutthroughCancel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnPutthroughCancel.Location = New System.Drawing.Point(0, 0)
        Me.pnPutthroughCancel.Name = "pnPutthroughCancel"
        Me.pnPutthroughCancel.Size = New System.Drawing.Size(784, 510)
        Me.pnPutthroughCancel.TabIndex = 0
        '
        'tpPutthroughDeal
        '
        Me.tpPutthroughDeal.Controls.Add(Me.pnPTDeal)
        Me.tpPutthroughDeal.Location = New System.Drawing.Point(4, 22)
        Me.tpPutthroughDeal.Name = "tpPutthroughDeal"
        Me.tpPutthroughDeal.Size = New System.Drawing.Size(784, 510)
        Me.tpPutthroughDeal.TabIndex = 2
        Me.tpPutthroughDeal.Tag = "PutthroughDeal"
        Me.tpPutthroughDeal.Text = "Putthrough deal"
        Me.tpPutthroughDeal.UseVisualStyleBackColor = True


        '
        'pnPTDeal
        '
        Me.pnPTDeal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnPTDeal.Location = New System.Drawing.Point(0, 0)
        Me.pnPTDeal.Name = "pnPTDeal"
        Me.pnPTDeal.Size = New System.Drawing.Size(784, 510)
        Me.pnPTDeal.TabIndex = 0
        '
        'tpPutthroughAdv
        '
        Me.tpPutthroughAdv.Controls.Add(Me.GroupBox1)
        Me.tpPutthroughAdv.Controls.Add(Me.grbAdvMsg)
        Me.tpPutthroughAdv.Controls.Add(Me.pnPTAdv)
        Me.tpPutthroughAdv.Location = New System.Drawing.Point(4, 22)
        Me.tpPutthroughAdv.Name = "tpPutthroughAdv"
        Me.tpPutthroughAdv.Size = New System.Drawing.Size(784, 510)
        Me.tpPutthroughAdv.TabIndex = 3
        Me.tpPutthroughAdv.Tag = "PutthroughAdv"
        Me.tpPutthroughAdv.Text = "Putthrough advertisement"
        Me.tpPutthroughAdv.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnDELETE)
        Me.GroupBox1.Controls.Add(Me.btnACTIVE)
        Me.GroupBox1.Controls.Add(Me.btnCANCEL)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 320)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(768, 40)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'btnDELETE
        '
        Me.btnDELETE.Location = New System.Drawing.Point(485, 12)
        Me.btnDELETE.Name = "btnDELETE"
        Me.btnDELETE.Size = New System.Drawing.Size(96, 23)
        Me.btnDELETE.TabIndex = 8
        Me.btnDELETE.Tag = "DELETE"
        Me.btnDELETE.Text = "btnDELETE"
        '
        'btnACTIVE
        '
        Me.btnACTIVE.Location = New System.Drawing.Point(587, 11)
        Me.btnACTIVE.Name = "btnACTIVE"
        Me.btnACTIVE.Size = New System.Drawing.Size(80, 23)
        Me.btnACTIVE.TabIndex = 9
        Me.btnACTIVE.Tag = "ACTIVE"
        Me.btnACTIVE.Text = "btnACTIVE"
        '
        'btnCANCEL
        '
        Me.btnCANCEL.Location = New System.Drawing.Point(672, 11)
        Me.btnCANCEL.Name = "btnCANCEL"
        Me.btnCANCEL.Size = New System.Drawing.Size(88, 23)
        Me.btnCANCEL.TabIndex = 10
        Me.btnCANCEL.Tag = "CANCEL"
        Me.btnCANCEL.Text = "btnCANCEL"
        '
        'grbAdvMsg
        '
        Me.grbAdvMsg.Controls.Add(Me.lblToCompID)
        Me.grbAdvMsg.Controls.Add(Me.txtToCompID)
        Me.grbAdvMsg.Controls.Add(Me.lblInfoCeilFloor)
        Me.grbAdvMsg.Controls.Add(Me.btnADD)
        Me.grbAdvMsg.Controls.Add(Me.lblCONTACT)
        Me.grbAdvMsg.Controls.Add(Me.lblPRICE)
        Me.grbAdvMsg.Controls.Add(Me.lblVOLUME)
        Me.grbAdvMsg.Controls.Add(Me.lblBOARD)
        Me.grbAdvMsg.Controls.Add(Me.lblSIDE)
        Me.grbAdvMsg.Controls.Add(Me.lblSYMBOL)
        Me.grbAdvMsg.Controls.Add(Me.ckbACTIVE)
        Me.grbAdvMsg.Controls.Add(Me.txtCONTACT)
        Me.grbAdvMsg.Controls.Add(Me.cboBOARD)
        Me.grbAdvMsg.Controls.Add(Me.txtPRICE)
        Me.grbAdvMsg.Controls.Add(Me.txtVOLUME)
        Me.grbAdvMsg.Controls.Add(Me.cboSIDE)
        Me.grbAdvMsg.Controls.Add(Me.cboSYMBOL)
        Me.grbAdvMsg.Location = New System.Drawing.Point(8, 368)
        Me.grbAdvMsg.Name = "grbAdvMsg"
        Me.grbAdvMsg.Size = New System.Drawing.Size(768, 136)
        Me.grbAdvMsg.TabIndex = 1
        Me.grbAdvMsg.TabStop = False
        Me.grbAdvMsg.Text = "Create advertisement message"
        '
        'lblToCompID
        '
        Me.lblToCompID.Location = New System.Drawing.Point(314, 80)
        Me.lblToCompID.Name = "lblToCompID"
        Me.lblToCompID.Size = New System.Drawing.Size(64, 23)
        Me.lblToCompID.TabIndex = 16
        Me.lblToCompID.Tag = "TOCOMPID"
        Me.lblToCompID.Text = "lblToCompID"
        Me.lblToCompID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtToCompID
        '
        Me.txtToCompID.Location = New System.Drawing.Point(384, 80)
        Me.txtToCompID.Name = "txtToCompID"
        Me.txtToCompID.Size = New System.Drawing.Size(56, 20)
        Me.txtToCompID.TabIndex = 5
        Me.txtToCompID.Tag = "CONTACT"
        Me.txtToCompID.Text = "0"
        '
        'lblInfoCeilFloor
        '
        Me.lblInfoCeilFloor.Location = New System.Drawing.Point(16, 48)
        Me.lblInfoCeilFloor.Name = "lblInfoCeilFloor"
        Me.lblInfoCeilFloor.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblInfoCeilFloor.Size = New System.Drawing.Size(304, 23)
        Me.lblInfoCeilFloor.TabIndex = 14
        '
        'btnADD
        '
        Me.btnADD.Location = New System.Drawing.Point(664, 24)
        Me.btnADD.Name = "btnADD"
        Me.btnADD.Size = New System.Drawing.Size(80, 23)
        Me.btnADD.TabIndex = 7
        Me.btnADD.Tag = "ADD"
        Me.btnADD.Text = "btnADD"
        '
        'lblCONTACT
        '
        Me.lblCONTACT.Location = New System.Drawing.Point(440, 80)
        Me.lblCONTACT.Name = "lblCONTACT"
        Me.lblCONTACT.Size = New System.Drawing.Size(72, 23)
        Me.lblCONTACT.TabIndex = 13
        Me.lblCONTACT.Tag = "CONTACT"
        Me.lblCONTACT.Text = "lblCONTACT"
        Me.lblCONTACT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPRICE
        '
        Me.lblPRICE.Location = New System.Drawing.Point(184, 80)
        Me.lblPRICE.Name = "lblPRICE"
        Me.lblPRICE.Size = New System.Drawing.Size(56, 23)
        Me.lblPRICE.TabIndex = 11
        Me.lblPRICE.Tag = "PRICE"
        Me.lblPRICE.Text = "lblPRICE"
        Me.lblPRICE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblVOLUME
        '
        Me.lblVOLUME.Location = New System.Drawing.Point(16, 80)
        Me.lblVOLUME.Name = "lblVOLUME"
        Me.lblVOLUME.Size = New System.Drawing.Size(72, 23)
        Me.lblVOLUME.TabIndex = 10
        Me.lblVOLUME.Tag = "VOLUME"
        Me.lblVOLUME.Text = "lblVOLUME"
        Me.lblVOLUME.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBOARD
        '
        Me.lblBOARD.Location = New System.Drawing.Point(448, 24)
        Me.lblBOARD.Name = "lblBOARD"
        Me.lblBOARD.Size = New System.Drawing.Size(87, 23)
        Me.lblBOARD.TabIndex = 9
        Me.lblBOARD.Tag = "BOARD"
        Me.lblBOARD.Text = "lblBOARD"
        '
        'lblSIDE
        '
        Me.lblSIDE.Location = New System.Drawing.Point(184, 24)
        Me.lblSIDE.Name = "lblSIDE"
        Me.lblSIDE.Size = New System.Drawing.Size(56, 23)
        Me.lblSIDE.TabIndex = 8
        Me.lblSIDE.Tag = "SIDE"
        Me.lblSIDE.Text = "lblSIDE"
        '
        'lblSYMBOL
        '
        Me.lblSYMBOL.Location = New System.Drawing.Point(16, 24)
        Me.lblSYMBOL.Name = "lblSYMBOL"
        Me.lblSYMBOL.Size = New System.Drawing.Size(72, 23)
        Me.lblSYMBOL.TabIndex = 7
        Me.lblSYMBOL.Tag = "SYMBOL"
        Me.lblSYMBOL.Text = "lblSYMBOL"
        '
        'ckbACTIVE
        '
        Me.ckbACTIVE.Checked = True
        Me.ckbACTIVE.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckbACTIVE.Location = New System.Drawing.Point(664, 59)
        Me.ckbACTIVE.Name = "ckbACTIVE"
        Me.ckbACTIVE.Size = New System.Drawing.Size(88, 24)
        Me.ckbACTIVE.TabIndex = 8
        Me.ckbACTIVE.Tag = "ACTIVE"
        Me.ckbACTIVE.Text = "ckbACTIVE"
        '
        'txtCONTACT
        '
        Me.txtCONTACT.Location = New System.Drawing.Point(512, 81)
        Me.txtCONTACT.Name = "txtCONTACT"
        Me.txtCONTACT.Size = New System.Drawing.Size(136, 20)
        Me.txtCONTACT.TabIndex = 6
        Me.txtCONTACT.Tag = "CONTACT"
        Me.txtCONTACT.Text = "txtCONTACT"
        '
        'cboBOARD
        '
        Me.cboBOARD.DisplayMember = "DISPLAY"
        Me.cboBOARD.Location = New System.Drawing.Point(560, 24)
        Me.cboBOARD.Name = "cboBOARD"
        Me.cboBOARD.Size = New System.Drawing.Size(88, 21)
        Me.cboBOARD.TabIndex = 2
        Me.cboBOARD.Tag = "BOARD"
        Me.cboBOARD.ValueMember = "VALUE"
        '
        'txtPRICE
        '
        Me.txtPRICE.Location = New System.Drawing.Point(240, 81)
        Me.txtPRICE.Name = "txtPRICE"
        Me.txtPRICE.Size = New System.Drawing.Size(72, 20)
        Me.txtPRICE.TabIndex = 4
        Me.txtPRICE.Tag = "PRICE"
        Me.txtPRICE.Text = "txtPRICE"
        '
        'txtVOLUME
        '
        Me.txtVOLUME.Location = New System.Drawing.Point(96, 81)
        Me.txtVOLUME.Name = "txtVOLUME"
        Me.txtVOLUME.Size = New System.Drawing.Size(80, 20)
        Me.txtVOLUME.TabIndex = 3
        Me.txtVOLUME.Tag = "VOLUME"
        Me.txtVOLUME.Text = "txtVOLUME"
        '
        'cboSIDE
        '
        Me.cboSIDE.DisplayMember = "DISPLAY"
        Me.cboSIDE.Location = New System.Drawing.Point(240, 24)
        Me.cboSIDE.Name = "cboSIDE"
        Me.cboSIDE.Size = New System.Drawing.Size(72, 21)
        Me.cboSIDE.TabIndex = 1
        Me.cboSIDE.Tag = "cboSIDE"
        Me.cboSIDE.ValueMember = "VALUE"
        '
        'cboSYMBOL
        '
        Me.cboSYMBOL.DisplayMember = "DISPLAY"
        Me.cboSYMBOL.Location = New System.Drawing.Point(96, 24)
        Me.cboSYMBOL.Name = "cboSYMBOL"
        Me.cboSYMBOL.Size = New System.Drawing.Size(80, 21)
        Me.cboSYMBOL.TabIndex = 0
        Me.cboSYMBOL.Tag = "SYMBOL"
        Me.cboSYMBOL.ValueMember = "VALUE"
        '
        'pnPTAdv
        '
        Me.pnPTAdv.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnPTAdv.Location = New System.Drawing.Point(0, 0)
        Me.pnPTAdv.Name = "pnPTAdv"
        Me.pnPTAdv.Size = New System.Drawing.Size(784, 312)
        Me.pnPTAdv.TabIndex = 0
        '
        'tpPutthroughAdvAll
        '
        Me.tpPutthroughAdvAll.Controls.Add(Me.pnPTAdvAll)
        Me.tpPutthroughAdvAll.Location = New System.Drawing.Point(4, 22)
        Me.tpPutthroughAdvAll.Name = "tpPutthroughAdvAll"
        Me.tpPutthroughAdvAll.Size = New System.Drawing.Size(784, 510)
        Me.tpPutthroughAdvAll.TabIndex = 4
        Me.tpPutthroughAdvAll.Text = "Lệnh quảng cáo toàn thị trường"
        Me.tpPutthroughAdvAll.UseVisualStyleBackColor = True
        '
        'pnPTAdvAll
        '
        Me.pnPTAdvAll.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnPTAdvAll.Location = New System.Drawing.Point(0, 0)
        Me.pnPTAdvAll.Name = "pnPTAdvAll"
        Me.pnPTAdvAll.Size = New System.Drawing.Size(784, 511)
        Me.pnPTAdvAll.TabIndex = 1
        '
        'btnConfirm
        '
        Me.btnConfirm.Location = New System.Drawing.Point(634, 541)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(75, 23)
        Me.btnConfirm.TabIndex = 1
        Me.btnConfirm.Tag = "btnConfirm"
        Me.btnConfirm.Text = "btnConfirm"
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(716, 541)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 2
        Me.btnExit.Tag = "btnExit"
        Me.btnExit.Text = "btnExit"
        '
        'btnReject
        '
        Me.btnReject.Location = New System.Drawing.Point(551, 541)
        Me.btnReject.Name = "btnReject"
        Me.btnReject.Size = New System.Drawing.Size(75, 23)
        Me.btnReject.TabIndex = 3
        Me.btnReject.Tag = "btnReject"
        Me.btnReject.Text = "btnReject"
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(472, 541)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(75, 23)
        Me.btnRefresh.TabIndex = 4
        Me.btnRefresh.Tag = "btnRefresh"
        Me.btnRefresh.Text = "btnRefresh"
        '
        'frmPutthroughAcknowledgment
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(792, 573)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.btnReject)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnConfirm)
        Me.Controls.Add(Me.Panel1)
        Me.KeyPreview = True
        Me.Name = "frmPutthroughAcknowledgment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmPutthroughAcknowledgment"
        Me.Panel1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.tpPutthroughAck.ResumeLayout(False)
        Me.tpPutthroughCancelAck.ResumeLayout(False)
        Me.tpPutthroughDeal.ResumeLayout(False)
        Me.tpPutthroughAdv.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.grbAdvMsg.ResumeLayout(False)
        Me.grbAdvMsg.PerformLayout()
        Me.tpPutthroughAdvAll.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
#Region "Private method"
    Private Sub OnClose()
        Me.Dispose()
    End Sub

    Private Sub OnConfirm(ByVal v_strOrderNumber As String)
        Dim v_strFilter, v_strClause As String
        Dim v_strFLDNAME, v_strValue As String
        Dim v_strFieldType, v_strDataType As String
        Dim v_ctrl As Windows.Forms.Control
        Dim v_strErrorSource, v_strErrorMessage As String
        Dim v_lngErrorCode As Long

        Try
            Dim v_strCmdInquiry As String
            If Me.TabControl1.SelectedTab Is TabControl1.TabPages(0) Then
                If (PTMsgGrid.CurrentRow Is Nothing) Then
                    Exit Sub
                End If
                v_strClause = Trim("ORDERPTACK") & "|" & CType(PTMsgGrid.CurrentRow, Xceed.Grid.DataRow).Cells("CONFIRMNUMBER").Value & "|" & v_strOrderNumber
            ElseIf Me.TabControl1.SelectedTab Is TabControl1.TabPages(1) Then
                'Confirm huy thoa thuan, sinh msg 3D code A
                If (PTCancelMsgGrid.CurrentRow Is Nothing) Then
                    Exit Sub
                End If

                If CType(PTCancelMsgGrid.CurrentRow, Xceed.Grid.DataRow).Cells("SIDE").Value = "B" Then
                    MessageBox.Show(mv_ResourceManager.GetString("MSG_BUYORDER"))
                    Exit Sub
                End If
                v_strClause = Trim("CANCELORDERPTACK") & "|" & CType(PTCancelMsgGrid.CurrentRow, Xceed.Grid.DataRow).Cells("CONFIRMNUMBER").Value & "|" & v_strOrderNumber
            ElseIf Me.TabControl1.SelectedTab Is TabControl1.TabPages(2) Then
                If (PTDealGrid.CurrentRow Is Nothing) Then
                    Exit Sub
                End If
                If CType(PTDealGrid.CurrentRow, Xceed.Grid.DataRow).Cells("BORS").Value = "B" Then
                    MessageBox.Show(mv_ResourceManager.GetString("MSG_BUYORDER"))
                    Exit Sub
                End If
                v_strClause = Trim("ORDERPTDEAL") & "|" & CType(PTDealGrid.CurrentRow, Xceed.Grid.DataRow).Cells("CONFIRMNUMBER").Value & "|" & v_strOrderNumber
            End If
            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_strClause, "PutthroughConfirm", , , , IpAddress)
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            v_lngErrorCode = v_ws.Message(v_strObjMsg)

            'KIEM TRA THONG TIN LAY LOI TRA VE
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

    Private Sub OnAdd()
        Dim v_strFilter, v_strClause As String
        Dim v_strFLDNAME, v_strValue As String
        Dim v_strFieldType, v_strDataType As String
        Dim v_ctrl As Windows.Forms.Control
        Dim v_strErrorSource, v_strErrorMessage As String
        Dim v_lngErrorCode As Long

        Try
            Dim v_strCmdInquiry As String
            If Me.TabControl1.SelectedTab Is TabControl1.TabPages(3) Then
                'Control validation
                'Check ma CK
                If (Me.cboSYMBOL.Text = "" Or Me.cboSYMBOL.SelectedValue = "-1") Then
                    'MessageBox.Show("Chọn chứng khoán!")
                    MessageBox.Show(mv_ResourceManager.GetString("ERR_CHOOSE_SYMBOL"))
                    Me.ActiveControl = Me.cboSYMBOL
                    Exit Sub
                End If
                'Check khoi luong
                If Not IsNumeric(Me.txtVOLUME.Text) Then
                    MessageBox.Show(mv_ResourceManager.GetString("ERR_INVQTTY"))
                    Me.ActiveControl = Me.txtVOLUME
                    Exit Sub
                End If

                If mv_strSecType <> "006" And ((CDbl(Me.txtVOLUME.Text) < 20000 And mv_strTradePlace = "001") Or ((CDbl(Me.txtVOLUME.Text) < 5000 And CDbl(Me.txtVOLUME.Text) >= 100 And mv_strTradePlace = "002"))) Then
                    MessageBox.Show(mv_ResourceManager.GetString("ERR_INVQTTY"))
                    Me.ActiveControl = Me.txtVOLUME
                    Exit Sub
                End If

                'Check gia -- nghiemnt add
                If (IsNumeric(Me.txtPRICE.Text) = False And Me.txtPRICE.Text <> "") Then
                    MessageBox.Show(mv_ResourceManager.GetString("ERR_INVPRICE"))
                    Me.ActiveControl = Me.txtPRICE
                    Exit Sub
                End If

                If CDbl(Me.txtPRICE.Text) < mv_dblFloorPrice / mv_dblTradeUnit Or CDbl(Me.txtPRICE.Text) > mv_dblCeilingPrice / mv_dblTradeUnit Then
                    MessageBox.Show(mv_ResourceManager.GetString("ERR_INV_CFPRICE"))
                    Me.ActiveControl = Me.txtPRICE
                    Exit Sub
                End If

                'Check contact
                If Me.txtCONTACT.Text.Length < 1 Then
                    MessageBox.Show(mv_ResourceManager.GetString("MSG_INSERT _CONTRACT"))
                    Me.ActiveControl = Me.txtCONTACT
                    Exit Sub
                End If
                'If Not IsNumeric(Me.txtCONTACT.Text) Then
                '    MessageBox.Show("Contact is invalid, contact is phone number!")
                '    Me.ActiveControl = Me.txtCONTACT
                '    Exit Sub
                'End If
            Else
                Exit Sub
            End If
            If MsgBox(mv_ResourceManager.GetString("MSG_CONFIRM"), MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Me.Text) = MsgBoxResult.Yes Then
                'Build info Clause
                v_strClause = Me.cboSYMBOL.Text & "|" & Me.cboSIDE.SelectedValue & "|" & Me.cboBOARD.SelectedValue & "|" & Me.txtVOLUME.Text & "|" & Me.txtPRICE.Text & "|" & Me.txtToCompID.Text & "|" & Me.txtCONTACT.Text & "|" & IIf(Me.ckbACTIVE.Checked, "Y", "N")
                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_strClause, "PutthroughAdvAdd", , , , IpAddress)
                Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                v_lngErrorCode = v_ws.Message(v_strObjMsg)

                'KIEM TRA THONG TIN LAY LOI TRA VE
                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                If v_lngErrorCode <> 0 Then
                    'Update mouse pointer
                    Cursor.Current = Cursors.Default
                    MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub OnCancel()
        Dim v_strFilter, v_strClause As String
        Dim v_strFLDNAME, v_strValue As String
        Dim v_strFieldType, v_strDataType As String
        Dim v_ctrl As Windows.Forms.Control
        Dim v_strErrorSource, v_strErrorMessage As String
        Dim v_lngErrorCode As Long

        Try
            Dim v_strCmdInquiry As String
            If Not Me.TabControl1.SelectedTab Is TabControl1.TabPages(3) Then
                Exit Sub
            End If
            If MsgBox(mv_ResourceManager.GetString("MSG_CONFIRM_CANCEL"), MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Me.Text) = MsgBoxResult.Yes Then
                'Build info Clause
                v_strClause = CType(PTAdvGrid.CurrentRow, Xceed.Grid.DataRow).Cells("SECURITYSYMBOL").Value _
                & "|" & CType(PTAdvGrid.CurrentRow, Xceed.Grid.DataRow).Cells("SIDE").Value _
                & "|" & CType(PTAdvGrid.CurrentRow, Xceed.Grid.DataRow).Cells("BOARD").Value _
                & "|" & CType(PTAdvGrid.CurrentRow, Xceed.Grid.DataRow).Cells("VOLUME").Value _
                & "|" & CType(PTAdvGrid.CurrentRow, Xceed.Grid.DataRow).Cells("PRICE").Value _
                & "|" & CType(PTAdvGrid.CurrentRow, Xceed.Grid.DataRow).Cells("CONTACT").Value _
                & "|" & CType(PTAdvGrid.CurrentRow, Xceed.Grid.DataRow).Cells("ISACTIVE").Value _
                & "|" & CType(PTAdvGrid.CurrentRow, Xceed.Grid.DataRow).Cells("DELETED").Value _
                & "|" & CType(PTAdvGrid.CurrentRow, Xceed.Grid.DataRow).Cells("ISSEND").Value _
                & "|" & CType(PTAdvGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value _
                & "|" & CType(PTAdvGrid.CurrentRow, Xceed.Grid.DataRow).Cells("TIMESTAMP").Value
                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_strClause, "PutthroughAdvCancel", , , , IpAddress)
                Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                v_lngErrorCode = v_ws.Message(v_strObjMsg)

                'KIEM TRA THONG TIN LAY LOI TRA VE
                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                If v_lngErrorCode <> 0 Then
                    'Update mouse pointer
                    Cursor.Current = Cursors.Default
                    MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub OnDelete()
        Dim v_strFilter, v_strClause As String
        Dim v_strFLDNAME, v_strValue As String
        Dim v_strFieldType, v_strDataType As String
        Dim v_ctrl As Windows.Forms.Control
        Dim v_strErrorSource, v_strErrorMessage As String
        Dim v_lngErrorCode As Long

        Try
            Dim v_strCmdInquiry As String
            If Not Me.TabControl1.SelectedTab Is TabControl1.TabPages(3) Then
                Exit Sub
            End If
            If MsgBox(mv_ResourceManager.GetString("MSG_CONFIRM_DEL_INACTIVE"), MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Me.Text) = MsgBoxResult.Yes Then
                'Build info Clause
                v_strClause = CType(PTAdvGrid.CurrentRow, Xceed.Grid.DataRow).Cells("SECURITYSYMBOL").Value _
                & "|" & CType(PTAdvGrid.CurrentRow, Xceed.Grid.DataRow).Cells("SIDE").Value _
                & "|" & CType(PTAdvGrid.CurrentRow, Xceed.Grid.DataRow).Cells("BOARD").Value _
                & "|" & CType(PTAdvGrid.CurrentRow, Xceed.Grid.DataRow).Cells("VOLUME").Value _
                & "|" & CType(PTAdvGrid.CurrentRow, Xceed.Grid.DataRow).Cells("PRICE").Value _
                & "|" & CType(PTAdvGrid.CurrentRow, Xceed.Grid.DataRow).Cells("CONTACT").Value _
                & "|" & CType(PTAdvGrid.CurrentRow, Xceed.Grid.DataRow).Cells("ISACTIVE").Value _
                & "|" & CType(PTAdvGrid.CurrentRow, Xceed.Grid.DataRow).Cells("DELETED").Value _
                & "|" & CType(PTAdvGrid.CurrentRow, Xceed.Grid.DataRow).Cells("ISSEND").Value _
                & "|" & CType(PTAdvGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value
                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_strClause, "PutthroughAdvDelete", , , , IpAddress)
                Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                v_lngErrorCode = v_ws.Message(v_strObjMsg)

                'KIEM TRA THONG TIN LAY LOI TRA VE
                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                If v_lngErrorCode <> 0 Then
                    'Update mouse pointer
                    Cursor.Current = Cursors.Default
                    MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub OnActive()
        Dim v_strFilter, v_strClause As String
        Dim v_strFLDNAME, v_strValue As String
        Dim v_strFieldType, v_strDataType As String
        Dim v_ctrl As Windows.Forms.Control
        Dim v_strErrorSource, v_strErrorMessage As String
        Dim v_lngErrorCode As Long

        Try
            Dim v_strCmdInquiry As String
            If Not Me.TabControl1.SelectedTab Is TabControl1.TabPages(3) Then
                Exit Sub
            End If
            If MsgBox(mv_ResourceManager.GetString("MSG_CONFIRM_REACTIVE"), MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Me.Text) = MsgBoxResult.Yes Then
                'Build info Clause
                v_strClause = CType(PTAdvGrid.CurrentRow, Xceed.Grid.DataRow).Cells("SECURITYSYMBOL").Value _
                & "|" & CType(PTAdvGrid.CurrentRow, Xceed.Grid.DataRow).Cells("SIDE").Value _
                & "|" & CType(PTAdvGrid.CurrentRow, Xceed.Grid.DataRow).Cells("BOARD").Value _
                & "|" & CType(PTAdvGrid.CurrentRow, Xceed.Grid.DataRow).Cells("VOLUME").Value _
                & "|" & CType(PTAdvGrid.CurrentRow, Xceed.Grid.DataRow).Cells("PRICE").Value _
                & "|" & CType(PTAdvGrid.CurrentRow, Xceed.Grid.DataRow).Cells("CONTACT").Value _
                & "|" & CType(PTAdvGrid.CurrentRow, Xceed.Grid.DataRow).Cells("ISACTIVE").Value _
                & "|" & CType(PTAdvGrid.CurrentRow, Xceed.Grid.DataRow).Cells("DELETED").Value _
                & "|" & CType(PTAdvGrid.CurrentRow, Xceed.Grid.DataRow).Cells("ISSEND").Value _
                & "|" & CType(PTAdvGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value
                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_strClause, "PutthroughAdvActive", , , , IpAddress)
                Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                v_lngErrorCode = v_ws.Message(v_strObjMsg)

                'KIEM TRA THONG TIN LAY LOI TRA VE
                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                If v_lngErrorCode <> 0 Then
                    'Update mouse pointer
                    Cursor.Current = Cursors.Default
                    MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub OnReject(ByVal v_strOrderNumber As String)
        Dim v_strFilter, v_strClause As String
        Dim v_strFLDNAME, v_strValue As String
        Dim v_strFieldType, v_strDataType As String
        Dim v_ctrl As Windows.Forms.Control
        Dim v_strErrorSource, v_strErrorMessage As String
        Dim v_lngErrorCode As Long

        Try
            Dim v_strCmdInquiry As String
            If Me.TabControl1.SelectedTab Is TabControl1.TabPages(0) Then
                If (PTMsgGrid.CurrentRow Is Nothing) Then
                    Exit Sub
                End If
                v_strClause = Trim("ORDERPTACK") & "|" & CType(PTMsgGrid.CurrentRow, Xceed.Grid.DataRow).Cells("CONFIRMNUMBER").Value & "|" & v_strOrderNumber
            ElseIf Me.TabControl1.SelectedTab Is TabControl1.TabPages(1) Then
                If (PTCancelMsgGrid.CurrentRow Is Nothing) Then
                    Exit Sub
                End If
                If CType(PTCancelMsgGrid.CurrentRow, Xceed.Grid.DataRow).Cells("SIDE").Value = "B" Then
                    MessageBox.Show(mv_ResourceManager.GetString("MSG_BUYORDER"))
                    Exit Sub
                End If
                v_strClause = Trim("CANCELORDERPTACK") & "|" & CType(PTCancelMsgGrid.CurrentRow, Xceed.Grid.DataRow).Cells("CONFIRMNUMBER").Value & "|" & v_strOrderNumber
            ElseIf Me.TabControl1.SelectedTab Is TabControl1.TabPages(2) Then
                If (PTDealGrid.CurrentRow Is Nothing) Then
                    Exit Sub
                End If
                If CType(PTDealGrid.CurrentRow, Xceed.Grid.DataRow).Cells("BORS").Value = "B" Then
                    MessageBox.Show(mv_ResourceManager.GetString("MSG_BUYORDER"))
                    Exit Sub
                End If
                v_strClause = Trim("ORDERPTDEAL") & "|" & CType(PTDealGrid.CurrentRow, Xceed.Grid.DataRow).Cells("CONFIRM_NO").Value & "|" & v_strOrderNumber
            End If
            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_strClause, "PutthroughReject", , , , IpAddress)
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            v_lngErrorCode = v_ws.Message(v_strObjMsg)

            'KIEM TRA THONG TIN LAY LOI TRA VE
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

    Private Sub DoResizeForm()

    End Sub

    Private Sub LoadResource(ByRef pv_ctrl As Windows.Forms.Control)
        Dim v_ctrl As Windows.Forms.Control

        For Each v_ctrl In pv_ctrl.Controls
            If TypeOf (v_ctrl) Is Label Then
                CType(v_ctrl, Label).Text = mv_ResourceManager.GetString(v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is TextBox Then
                CType(v_ctrl, TextBox).Text = ""
            ElseIf TypeOf (v_ctrl) Is CheckBox Then
                CType(v_ctrl, CheckBox).Text = mv_ResourceManager.GetString(v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is GroupBox Then
                CType(v_ctrl, GroupBox).Text = mv_ResourceManager.GetString(v_ctrl.Name)
                LoadResource(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is Button Then
                CType(v_ctrl, Button).Text = mv_ResourceManager.GetString(v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is Panel Then
                LoadResource(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is TabControl Then
                LoadResource(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is TabPage Then
                LoadResource(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is GroupBox Then
                LoadResource(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is DateTimePicker Then
                CType(v_ctrl, DateTimePicker).Value = CDate(Me.BusDate)
            End If
        Next
        Me.Text = mv_ResourceManager.GetString(Me.Name)
        Me.tpPutthroughAck.Text = mv_ResourceManager.GetString(Me.tpPutthroughAck.Name)
        Me.tpPutthroughAdv.Text = mv_ResourceManager.GetString(Me.tpPutthroughAdv.Name)
        Me.tpPutthroughCancelAck.Text = mv_ResourceManager.GetString(Me.tpPutthroughCancelAck.Name)
        Me.tpPutthroughDeal.Text = mv_ResourceManager.GetString(Me.tpPutthroughDeal.Name)

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

    Private Sub ResetScreen(ByRef pv_ctrl As Windows.Forms.Control)
    End Sub

    Protected Overridable Function InitDialog()
        'Khởi tạo kích thước form và load resource
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        LoadResource(Me)
        DoResizeForm()
        ResetScreen(Me)
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strCmdSQL As String, v_strObjMsg As String
        'v_strCmdSQL = "SELECT CODEID VALUE, SYMBOL DISPLAY FROM SBSECURITIES where tradeplace ='001' and sectype <>'004' ORDER BY SYMBOL"
        v_strCmdSQL = "SELECT VALUE, DISPLAY, EN_DISPLAY FROM ( " _
                        & " SELECT '-1' VALUE, ' ' DISPLAY, ' ' EN_DISPLAY FROM DUAL " _
                        & " UNION ALL " _
                        & " SELECT CODEID VALUE, SYMBOL DISPLAY, SYMBOL EN_DISPLAY FROM SBSECURITIES where sectype <>'004' " _
                        & " ) ORDER BY DISPLAY ASC"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
        v_ws.Message(v_strObjMsg)
        FillComboEx(v_strObjMsg, cboSYMBOL, "", Me.UserLanguage)

        v_strCmdSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, LSTODR FROM ALLCODE WHERE CDTYPE='OD' AND TRIM(CDNAME)='BORS' AND LSTODR<2  ORDER BY LSTODR"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
        v_ws.Message(v_strObjMsg)
        FillComboEx(v_strObjMsg, cboSIDE, "", Me.UserLanguage)

        v_strCmdSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, LSTODR FROM ALLCODE WHERE CDTYPE='OD' AND TRIM(CDNAME)='BOARD' ORDER BY LSTODR"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
        v_ws.Message(v_strObjMsg)
        FillComboEx(v_strObjMsg, cboBOARD, "", Me.UserLanguage)

        If cboSYMBOL.Items.Count > 0 Then cboSYMBOL.SelectedIndex = 0
        If cboSIDE.Items.Count > 0 Then cboSIDE.SelectedIndex = 0
        If cboBOARD.Items.Count > 0 Then cboBOARD.SelectedIndex = 0

    End Function


    Private Sub InitializeGrid()
        'Khởi tạo Grid Putthrough
        PTMsgGrid = New GridEx
        Dim v_cmrContactsHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrContactsHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrContactsHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        PTMsgGrid.FixedHeaderRows.Add(v_cmrContactsHeader)
        'PTMsgGrid.Columns.Add(New Xceed.Grid.Column("CHECKALL", GetType(System.String)))
        PTMsgGrid.Columns.Add(New Xceed.Grid.Column("FIRM", GetType(System.String)))
        PTMsgGrid.Columns.Add(New Xceed.Grid.Column("BUYERTRADEID", GetType(System.String)))
        PTMsgGrid.Columns.Add(New Xceed.Grid.Column("SIDE", GetType(System.String)))
        PTMsgGrid.Columns.Add(New Xceed.Grid.Column("SELLERCONTRAFIRM", GetType(System.String)))
        PTMsgGrid.Columns.Add(New Xceed.Grid.Column("SELLERTRADEID", GetType(System.String)))
        PTMsgGrid.Columns.Add(New Xceed.Grid.Column("SECURITYSYMBOL", GetType(System.String)))
        PTMsgGrid.Columns.Add(New Xceed.Grid.Column("VOLUME", GetType(System.String)))
        PTMsgGrid.Columns.Add(New Xceed.Grid.Column("PRICE", GetType(System.String)))
        PTMsgGrid.Columns.Add(New Xceed.Grid.Column("BOARD", GetType(System.String)))
        PTMsgGrid.Columns.Add(New Xceed.Grid.Column("CONFIRMNUMBER", GetType(System.String)))
        PTMsgGrid.Columns.Add(New Xceed.Grid.Column("TRADING_DATE", GetType(System.String)))
        PTMsgGrid.Columns.Add(New Xceed.Grid.Column("TIMESTAMP", GetType(System.String)))



        PTMsgGrid.Columns("FIRM").Title = mv_ResourceManager.GetString("FIRM")
        PTMsgGrid.Columns("BUYERTRADEID").Title = mv_ResourceManager.GetString("BUYERTRADEID")
        PTMsgGrid.Columns("SIDE").Title = mv_ResourceManager.GetString("SIDE")
        PTMsgGrid.Columns("SELLERCONTRAFIRM").Title = mv_ResourceManager.GetString("SELLERCONTRAFIRM")
        PTMsgGrid.Columns("SELLERTRADEID").Title = mv_ResourceManager.GetString("SELLERTRADEID")
        PTMsgGrid.Columns("SECURITYSYMBOL").Title = mv_ResourceManager.GetString("SECURITYSYMBOL")
        PTMsgGrid.Columns("VOLUME").Title = mv_ResourceManager.GetString("VOLUME")
        PTMsgGrid.Columns("PRICE").Title = mv_ResourceManager.GetString("PRICE")
        PTMsgGrid.Columns("BOARD").Title = mv_ResourceManager.GetString("BOARD")
        PTMsgGrid.Columns("CONFIRMNUMBER").Title = mv_ResourceManager.GetString("CONFIRMNUMBER")
        PTMsgGrid.Columns("TRADING_DATE").Title = mv_ResourceManager.GetString("TRADING_DATE")
        PTMsgGrid.Columns("TIMESTAMP").Title = mv_ResourceManager.GetString("TIMESTAMP")


        Me.pnPutthrough.Controls.Clear()
        Me.pnPutthrough.Controls.Add(PTMsgGrid)
        PTMsgGrid.Dock = Windows.Forms.DockStyle.Fill
        AddHandler PTMsgGrid.SelectedRowsChanged, AddressOf Me.PTMsgGridSelectedRowChanged

        'Khởi tạo Grid Cancel Putthrough
        PTCancelMsgGrid = New GridEx
        v_cmrContactsHeader = New Xceed.Grid.ColumnManagerRow
        v_cmrContactsHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrContactsHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        PTCancelMsgGrid.FixedHeaderRows.Add(v_cmrContactsHeader)
        'PTMsgGrid.Columns.Add(New Xceed.Grid.Column("CHECKALL", GetType(System.String)))
        PTCancelMsgGrid.Columns.Add(New Xceed.Grid.Column("FULLNAME", GetType(System.String)))
        PTCancelMsgGrid.Columns.Add(New Xceed.Grid.Column("FIRM", GetType(System.String)))
        PTCancelMsgGrid.Columns.Add(New Xceed.Grid.Column("TRADEID", GetType(System.String)))
        PTCancelMsgGrid.Columns.Add(New Xceed.Grid.Column("SIDE", GetType(System.String)))
        PTCancelMsgGrid.Columns.Add(New Xceed.Grid.Column("CONTRAFIRM", GetType(System.String)))
        PTCancelMsgGrid.Columns.Add(New Xceed.Grid.Column("SECURITYSYMBOL", GetType(System.String)))
        PTCancelMsgGrid.Columns.Add(New Xceed.Grid.Column("CONFIRMNUMBER", GetType(System.String)))
        PTCancelMsgGrid.Columns.Add(New Xceed.Grid.Column("TRADING_DATE", GetType(System.String)))
        PTCancelMsgGrid.Columns.Add(New Xceed.Grid.Column("TIMESTAMP", GetType(System.String)))
        PTCancelMsgGrid.Columns.Add(New Xceed.Grid.Column("ORGORDERID", GetType(System.String)))
        PTCancelMsgGrid.Columns.Add(New Xceed.Grid.Column("CUSTODYCD", GetType(System.String)))
        PTCancelMsgGrid.Columns.Add(New Xceed.Grid.Column("QTTY", GetType(System.String)))
        PTCancelMsgGrid.Columns.Add(New Xceed.Grid.Column("PRICE", GetType(System.String)))


        PTCancelMsgGrid.Columns("FULLNAME").Title = mv_ResourceManager.GetString("FULLNAME")
        PTCancelMsgGrid.Columns("FIRM").Title = mv_ResourceManager.GetString("FIRM")
        PTCancelMsgGrid.Columns("TRADEID").Title = mv_ResourceManager.GetString("BUYERTRADEID")
        PTCancelMsgGrid.Columns("SIDE").Title = mv_ResourceManager.GetString("SIDE")
        PTCancelMsgGrid.Columns("CONTRAFIRM").Title = mv_ResourceManager.GetString("SELLERCONTRAFIRM")
        PTCancelMsgGrid.Columns("SECURITYSYMBOL").Title = mv_ResourceManager.GetString("SECURITYSYMBOL")
        PTCancelMsgGrid.Columns("CONFIRMNUMBER").Title = mv_ResourceManager.GetString("CONFIRMNUMBER")
        PTCancelMsgGrid.Columns("TRADING_DATE").Title = mv_ResourceManager.GetString("TRADING_DATE")
        PTCancelMsgGrid.Columns("TIMESTAMP").Title = mv_ResourceManager.GetString("TIMESTAMP")
        PTCancelMsgGrid.Columns("QTTY").Title = mv_ResourceManager.GetString("VOLUME")
        PTCancelMsgGrid.Columns("PRICE").Title = mv_ResourceManager.GetString("PRICE")
        PTCancelMsgGrid.Columns("ORGORDERID").Title = mv_ResourceManager.GetString("ORGORDERID")
        PTCancelMsgGrid.Columns("CUSTODYCD").Title = mv_ResourceManager.GetString("CUSTODYCD")
        AddHandler PTCancelMsgGrid.SelectedRowsChanged, AddressOf Me.PTCancelMsgGridSelectedRowChanged


        Me.pnPutthroughCancel.Controls.Clear()
        Me.pnPutthroughCancel.Controls.Add(PTCancelMsgGrid)
        PTCancelMsgGrid.Dock = Windows.Forms.DockStyle.Fill


        'Khởi tạo Grid InOrder
        PTDealGrid = New GridEx

        Dim v_cmrInOrderHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrInOrderHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrInOrderHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        PTDealGrid.FixedHeaderRows.Add(v_cmrInOrderHeader)
        PTDealGrid.Columns.Add(New Xceed.Grid.Column("ORGORDERID", GetType(System.String)))
        PTDealGrid.Columns.Add(New Xceed.Grid.Column("CONFIRM_NO", GetType(System.String)))
        PTDealGrid.Columns.Add(New Xceed.Grid.Column("CUSTODYCD", GetType(System.String)))
        PTDealGrid.Columns.Add(New Xceed.Grid.Column("CODEID", GetType(System.String)))
        PTDealGrid.Columns.Add(New Xceed.Grid.Column("SYMBOL", GetType(System.String)))
        PTDealGrid.Columns.Add(New Xceed.Grid.Column("BORS", GetType(System.String)))
        PTDealGrid.Columns.Add(New Xceed.Grid.Column("NORP", GetType(System.String)))
        PTDealGrid.Columns.Add(New Xceed.Grid.Column("AORN", GetType(System.String)))
        'PTDealGrid.Columns.Add(New Xceed.Grid.Column("PRICE", GetType(System.Double)))
        PTDealGrid.Columns.Add(New Xceed.Grid.Column("PRICE", GetType(System.String)))

        PTDealGrid.Columns.Add(New Xceed.Grid.Column("QTTY", GetType(System.Double)))
        PTDealGrid.Columns.Add(New Xceed.Grid.Column("REFCUSTCD", GetType(System.String)))
        '    PTDealGrid.Columns.Add(New Xceed.Grid.Column("MATCHPRICE", GetType(System.Double)))
        PTDealGrid.Columns.Add(New Xceed.Grid.Column("MATCHPRICE", GetType(System.String)))
        PTDealGrid.Columns.Add(New Xceed.Grid.Column("MATCHQTTY", GetType(System.Double)))
        PTDealGrid.Columns.Add(New Xceed.Grid.Column("TXDATE", GetType(System.String)))
        PTDealGrid.Columns.Add(New Xceed.Grid.Column("CANCELLING", GetType(System.String)))

        PTDealGrid.Columns("ORGORDERID").Title = mv_ResourceManager.GetString("grid.ORGORDERID")
        PTDealGrid.Columns("CODEID").Title = mv_ResourceManager.GetString("grid.CODEID")
        PTDealGrid.Columns("SYMBOL").Title = mv_ResourceManager.GetString("grid.SYMBOL")
        PTDealGrid.Columns("BORS").Title = mv_ResourceManager.GetString("grid.BORS")
        PTDealGrid.Columns("NORP").Title = mv_ResourceManager.GetString("grid.NORP")
        PTDealGrid.Columns("AORN").Title = mv_ResourceManager.GetString("grid.AORN")
        PTDealGrid.Columns("PRICE").Title = mv_ResourceManager.GetString("grid.PRICE")
        'PTDealGrid.Columns("PRICE").FormatSpecifier = "#,##0"
        PTDealGrid.Columns("QTTY").Title = mv_ResourceManager.GetString("grid.QTTY")
        PTDealGrid.Columns("QTTY").FormatSpecifier = "#,##0"
        PTDealGrid.Columns("REFCUSTCD").Title = mv_ResourceManager.GetString("grid.REFCUSTCD")
        PTDealGrid.Columns("MATCHPRICE").Title = mv_ResourceManager.GetString("grid.MATCHPRICE")
        'PTDealGrid.Columns("MATCHPRICE").FormatSpecifier = "#,##0"
        PTDealGrid.Columns("MATCHQTTY").Title = mv_ResourceManager.GetString("grid.MATCHQTTY")
        PTDealGrid.Columns("MATCHQTTY").FormatSpecifier = "#,##0"
        PTDealGrid.Columns("TXDATE").Title = mv_ResourceManager.GetString("grid.TXDATE")
        PTDealGrid.Columns("CONFIRM_NO").Title = mv_ResourceManager.GetString("grid.TXDATE")
        PTDealGrid.Columns("CANCELLING").Title = mv_ResourceManager.GetString("grid.CANCELLING")
        PTDealGrid.Columns("CUSTODYCD").Title = mv_ResourceManager.GetString("grid.CUSTODYCD")
        AddHandler PTDealGrid.SelectedRowsChanged, AddressOf Me.PTDealGridSelectedRowChanged



        Me.pnPTDeal.Controls.Clear()
        Me.pnPTDeal.Controls.Add(PTDealGrid)
        PTDealGrid.Dock = Windows.Forms.DockStyle.Fill


        'Tao grid putthrough order advertisement
        PTAdvGrid = New GridEx
        v_cmrContactsHeader = New Xceed.Grid.ColumnManagerRow
        v_cmrContactsHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrContactsHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        PTAdvGrid.FixedHeaderRows.Add(v_cmrContactsHeader)
        'PTMsgGrid.Columns.Add(New Xceed.Grid.Column("CHECKALL", GetType(System.String)))
        PTAdvGrid.Columns.Add(New Xceed.Grid.Column("SECURITYSYMBOL", GetType(System.String)))
        PTAdvGrid.Columns.Add(New Xceed.Grid.Column("SIDE", GetType(System.String)))
        PTAdvGrid.Columns.Add(New Xceed.Grid.Column("VOLUME", GetType(System.String)))
        PTAdvGrid.Columns.Add(New Xceed.Grid.Column("PRICE", GetType(System.String)))
        PTAdvGrid.Columns.Add(New Xceed.Grid.Column("ISSEND", GetType(System.String)))
        PTAdvGrid.Columns.Add(New Xceed.Grid.Column("DELETED", GetType(System.String)))
        PTAdvGrid.Columns.Add(New Xceed.Grid.Column("ISACTIVE", GetType(System.String)))
        PTAdvGrid.Columns.Add(New Xceed.Grid.Column("TOCOMPID", GetType(System.String)))
        PTAdvGrid.Columns.Add(New Xceed.Grid.Column("CONTACT", GetType(System.String)))
        PTAdvGrid.Columns.Add(New Xceed.Grid.Column("TRADEID", GetType(System.String)))
        PTAdvGrid.Columns.Add(New Xceed.Grid.Column("BOARD", GetType(System.String)))
        PTAdvGrid.Columns.Add(New Xceed.Grid.Column("SENDTIME", GetType(System.String)))
        PTAdvGrid.Columns.Add(New Xceed.Grid.Column("FLAG", GetType(System.String)))
        PTAdvGrid.Columns.Add(New Xceed.Grid.Column("TIMESTAMP", GetType(System.String)))
        PTAdvGrid.Columns.Add(New Xceed.Grid.Column("FIRM", GetType(System.String)))
        PTAdvGrid.Columns.Add(New Xceed.Grid.Column("AUTOID", GetType(System.String)))



        PTAdvGrid.Columns("AUTOID").Title = mv_ResourceManager.GetString("AUTOID")
        PTAdvGrid.Columns("FIRM").Title = mv_ResourceManager.GetString("FIRM")
        PTAdvGrid.Columns("TRADEID").Title = mv_ResourceManager.GetString("BUYERTRADEID")
        PTAdvGrid.Columns("SECURITYSYMBOL").Title = mv_ResourceManager.GetString("SECURITYSYMBOL")
        PTAdvGrid.Columns("SIDE").Title = mv_ResourceManager.GetString("SIDE")
        PTAdvGrid.Columns("VOLUME").Title = mv_ResourceManager.GetString("VOLUME")
        PTAdvGrid.Columns("PRICE").Title = mv_ResourceManager.GetString("PRICE")
        PTAdvGrid.Columns("BOARD").Title = mv_ResourceManager.GetString("BOARD")
        PTAdvGrid.Columns("SENDTIME").Title = mv_ResourceManager.GetString("SENDTIME")
        PTAdvGrid.Columns("FLAG").Title = mv_ResourceManager.GetString("FLAG")
        PTAdvGrid.Columns("CONTACT").Title = mv_ResourceManager.GetString("CONTACT")
        PTAdvGrid.Columns("ISACTIVE").Title = mv_ResourceManager.GetString("ISACTIVE")
        PTAdvGrid.Columns("ISSEND").Title = mv_ResourceManager.GetString("ISSEND")
        PTAdvGrid.Columns("TIMESTAMP").Title = mv_ResourceManager.GetString("TIMESTAMP")
        PTAdvGrid.Columns("DELETED").Title = mv_ResourceManager.GetString("DELETED")
        PTAdvGrid.Columns("TOCOMPID").Title = mv_ResourceManager.GetString("TOCOMPID")
        AddHandler PTAdvGrid.SelectedRowsChanged, AddressOf Me.PTAdvGridSelectedRowChanged
        Me.pnPTAdv.Controls.Clear()
        Me.pnPTAdv.Controls.Add(PTAdvGrid)
        PTAdvGrid.Dock = Windows.Forms.DockStyle.Fill


        'Tao grid putthrough order advertisement All
        PTAdvAllGrid = New GridEx
        v_cmrContactsHeader = New Xceed.Grid.ColumnManagerRow
        v_cmrContactsHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrContactsHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        PTAdvAllGrid.FixedHeaderRows.Add(v_cmrContactsHeader)
        'PTMsgGrid.Columns.Add(New Xceed.Grid.Column("CHECKALL", GetType(System.String)))
        PTAdvAllGrid.Columns.Add(New Xceed.Grid.Column("ADVSIDE", GetType(System.String)))
        PTAdvAllGrid.Columns.Add(New Xceed.Grid.Column("TEXT", GetType(System.String)))
        PTAdvAllGrid.Columns.Add(New Xceed.Grid.Column("QUANTITY", GetType(System.String)))
        PTAdvAllGrid.Columns.Add(New Xceed.Grid.Column("ADVTRANSTYPE", GetType(System.String)))
        PTAdvAllGrid.Columns.Add(New Xceed.Grid.Column("SYMBOL", GetType(System.String)))
        PTAdvAllGrid.Columns.Add(New Xceed.Grid.Column("DELIVERTOCOMPID", GetType(System.String)))
        PTAdvAllGrid.Columns.Add(New Xceed.Grid.Column("PRICE", GetType(System.String)))
        PTAdvAllGrid.Columns.Add(New Xceed.Grid.Column("ADVID", GetType(System.String)))
        PTAdvAllGrid.Columns.Add(New Xceed.Grid.Column("SENDERSUBID", GetType(System.String)))


        PTAdvAllGrid.Columns("ADVSIDE").Title = mv_ResourceManager.GetString("PTAdvAllGrid.ADVSIDE")
        PTAdvAllGrid.Columns("TEXT").Title = mv_ResourceManager.GetString("PTAdvAllGrid.TEXT")
        PTAdvAllGrid.Columns("QUANTITY").Title = mv_ResourceManager.GetString("PTAdvAllGrid.QUANTITY")
        PTAdvAllGrid.Columns("ADVTRANSTYPE").Title = mv_ResourceManager.GetString("PTAdvAllGrid.ADVTRANSTYPE")
        PTAdvAllGrid.Columns("SYMBOL").Title = mv_ResourceManager.GetString("PTAdvAllGrid.SYMBOL")
        PTAdvAllGrid.Columns("DELIVERTOCOMPID").Title = mv_ResourceManager.GetString("PTAdvAllGrid.DELIVERTOCOMPID")
        PTAdvAllGrid.Columns("PRICE").Title = mv_ResourceManager.GetString("PTAdvAllGrid.PRICE")
        PTAdvAllGrid.Columns("ADVID").Title = mv_ResourceManager.GetString("PTAdvAllGrid.ADVID")
        PTAdvAllGrid.Columns("SENDERSUBID").Title = mv_ResourceManager.GetString("PTAdvAllGrid.SENDERSUBID")

        AddHandler PTAdvAllGrid.SelectedRowsChanged, AddressOf Me.PTAdvAllGridSelectedRowChanged
        Me.pnPTAdvAll.Controls.Clear()
        Me.pnPTAdvAll.Controls.Add(PTAdvAllGrid)
        PTAdvAllGrid.Dock = Windows.Forms.DockStyle.Fill

    End Sub
    'Private Sub OnView(ByVal sender As Object, ByVal e As System.EventArgs)

    'End Sub

    Public Sub GetPTMsgMessage()
        Dim v_strCmdInquiry, v_strFilter As String
        Dim v_intIndex As Int16
        Dim v_intODKIND As Int16
        Try
            'v_strCmdInquiry = "SELECT A.TIMESTAMP, A.MESSAGETYPE, A.FIRM, A.BUYERTRADEID, A.SIDE," _
            '        & " A.SELLERCONTRAFIRM, A.SCLIENTID SELLERTRADEID, A.SECURITYSYMBOL, A.VOLUME," _
            '        & " A.PRICE, A.BOARD, A.CONFIRMNUMBER, A.OFFSET, A.TRADING_DATE" _
            '        & " FROM ORDERPTACK A , SYSVAR B WHERE A.STATUS='N' AND B.VARNAME='COMPANYCD' AND SUBSTR(A.SCLIENTID,1,3) NOT LIKE B.VARVALUE"

            v_strCmdInquiry = "SELECT A.TIMESTAMP, A.MESSAGETYPE, A.FIRM, A.BUYERTRADEID, A.SIDE," _
                            & " A.SELLERCONTRAFIRM, A.SELLERTRADEID, A.SECURITYSYMBOL, A.VOLUME," _
                            & " A.PRICE, A.BOARD, A.CONFIRMNUMBER, A.OFFSET, A.TRADING_DATE" _
                            & " FROM ORDERPTACK A WHERE A.STATUS='N' " _
                            & " AND NOT EXISTS(SELECT * FROM IOD WHERE IOD.DELTD <> 'Y' AND IOD.CONFIRM_NO = A.CONFIRMNUMBER)"

            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_OD_ODMAST, gc_ActionInquiry, v_strCmdInquiry)
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            v_ws.Message(v_strObjMsg)

            FillDataGrid(PTMsgGrid, v_strObjMsg, "")
            If mv_intCurrentRow >= PTMsgGrid.DataRows.Count Then mv_intCurrentRow = 0
            If PTMsgGrid.DataRows.Count > 0 Then
                PTMsgGrid.CurrentRow = PTMsgGrid.DataRows(mv_intCurrentRow)
                PTMsgGrid.SelectedRows.Clear()
                PTMsgGrid.SelectedRows.Add(PTMsgGrid.CurrentRow)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Delegate Sub dlgGetPTCancelMessage()
    Dim mydelGetPTCancelMessage As dlgGetPTCancelMessage
    Public Sub GetPTCancelMessage()
        mydelGetPTCancelMessage = New dlgGetPTCancelMessage(AddressOf prGetPTCancelMessage)
        mydelGetPTCancelMessage.Invoke()
    End Sub
    Public Sub prGetPTCancelMessage()
        Dim v_strCmdInquiry, v_strFilter As String
        Dim v_intIndex As Int16
        Dim v_intODKIND As Int16
        Try
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery

            v_strCmdInquiry = "SELECT CF.FULLNAME,PT.*,IOD.ORGORDERID,IOD.CUSTODYCD,IOD.QTTY,IOD.PRICE " _
                & "FROM CANCELORDERPTACK PT,IOD,CFMAST CF " _
                & "WHERE(TRIM(PT.CONFIRMNUMBER) = TRIM(IOD.CONFIRM_NO) And CF.CUSTODYCD = IOD.CUSTODYCD)" _
                & "AND PT.STATUS='N' AND PT.ISCONFIRM='N' AND PT.SORR <>'S' and orgorderid in (select orgorderid from ood where BORS ='B' and NORP ='P')"

            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_OD_ODMAST, gc_ActionInquiry, v_strCmdInquiry)
            v_ws = New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            v_ws.Message(v_strObjMsg)

            FillDataGrid(PTCancelMsgGrid, v_strObjMsg, "")
            If mv_intCurrentRow >= PTCancelMsgGrid.DataRows.Count Then mv_intCurrentRow = 0
            If PTCancelMsgGrid.DataRows.Count > 0 Then
                PTCancelMsgGrid.CurrentRow = PTCancelMsgGrid.DataRows(mv_intCurrentRow)
                PTCancelMsgGrid.SelectedRows.Clear()
                PTCancelMsgGrid.SelectedRows.Add(PTCancelMsgGrid.CurrentRow)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Delegate Sub dlgGetPTDealMessage()
    Dim mydelGetPTDealMessage As dlgGetPTDealMessage
    Public Sub GetPTDealMessage()
        mydelGetPTDealMessage = New dlgGetPTDealMessage(AddressOf prGetPTDealMessage)
        mydelGetPTDealMessage.Invoke()
    End Sub
    Public Sub prGetPTDealMessage()
        Dim v_strCmdInquiry, v_strFilter As String
        Dim v_intIndex As Int16
        Dim v_intODKIND As Int16
        Try
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            v_strCmdInquiry = " select * from ( " & ControlChars.CrLf _
                            & " SELECT ORGORDERID,CODEID,CUSTODYCD,SYMBOL,BORS,NORP,AORN,PRICE,QTTY,REFCUSTCD,MATCHPRICE,MATCHQTTY,TXDATE," & ControlChars.CrLf _
                            & " CONFIRM_NO,'No' CANCELLING FROM IOD WHERE IOD.DELTD <> 'Y' AND  NORP='P'" & ControlChars.CrLf _
                            & " and orgorderid not in (SELECT ORDERNUMBER FROM CANCELORDERPTACK WHERE SORR='S')" & ControlChars.CrLf _
                            & " union" & ControlChars.CrLf _
                            & " SELECT ORGORDERID,CODEID,CUSTODYCD,SYMBOL,BORS,NORP,AORN,PRICE,QTTY,REFCUSTCD,MATCHPRICE,MATCHQTTY,TXDATE,CONFIRM_NO,'Yes' CANCELLING FROM IOD WHERE IOD.DELTD <> 'Y' AND  NORP='P'" & ControlChars.CrLf _
                            & " and orgorderid  in (SELECT ORDERNUMBER FROM CANCELORDERPTACK WHERE SORR='S')" & ControlChars.CrLf _
                            & " )" & ControlChars.CrLf _
                            & " ORDER BY ORGORDERID"
            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_OD_ODMAST, gc_ActionInquiry, v_strCmdInquiry)
            v_ws.Message(v_strObjMsg)
            FillDataGrid(PTDealGrid, v_strObjMsg, "")
        Catch ex As Exception

        End Try
    End Sub

    Delegate Sub dlgGetPTAdvMessage()
    Dim mydelGetPTAdvMessage As dlgGetPTAdvMessage
    Public Sub GetPTAdvMessage()
        mydelGetPTAdvMessage = New dlgGetPTAdvMessage(AddressOf prGetPTAdvMessage)
        mydelGetPTAdvMessage.Invoke()
    End Sub
    Public Sub prGetPTAdvMessage()
        Dim v_strCmdInquiry, v_strFilter As String
        Dim v_intIndex As Int16
        Dim v_intODKIND As Int16
        Try
            v_strCmdInquiry = "SELECT *  FROM ORDERPTADV"

            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_OD_ODMAST, gc_ActionInquiry, v_strCmdInquiry)
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            v_ws.Message(v_strObjMsg)

            FillDataGrid(PTAdvGrid, v_strObjMsg, "")
            If mv_intCurrentRow >= PTAdvGrid.DataRows.Count Then mv_intCurrentRow = 0
            If PTAdvGrid.DataRows.Count > 0 Then
                PTAdvGrid.CurrentRow = PTAdvGrid.DataRows(mv_intCurrentRow)
                PTAdvGrid.SelectedRows.Clear()
                PTAdvGrid.SelectedRows.Add(PTAdvGrid.CurrentRow)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Delegate Sub dlgGetPTAdvAllMessage()
    Dim mydelGetPTAdvAllMessage As dlgGetPTAdvAllMessage
    Public Sub GetPTAdvAllMessage()
        mydelGetPTAdvAllMessage = New dlgGetPTAdvAllMessage(AddressOf prGetPTAdvAllMessage)
        mydelGetPTAdvAllMessage.Invoke()
    End Sub
    Public Sub prGetPTAdvAllMessage()
        Dim v_strCmdInquiry, v_strFilter As String
        Dim v_intIndex As Int16
        Dim v_intODKIND As Int16
        Try
            v_strCmdInquiry = "SELECT ADVSIDE,TEXT,QUANTITY,ADVTRANSTYPE,SYMBOL," & _
                                " DELIVERTOCOMPID, PRICE, ADVID, SENDERSUBID" & _
                                " FROM haput_ad where 0=0"

            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_OD_ODMAST, gc_ActionInquiry, v_strCmdInquiry)
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            v_ws.Message(v_strObjMsg)

            FillDataGrid(PTAdvAllGrid, v_strObjMsg, "")
            If mv_intCurrentRow >= PTAdvGrid.DataRows.Count Then mv_intCurrentRow = 0
            If PTAdvAllGrid.DataRows.Count > 0 Then
                PTAdvAllGrid.CurrentRow = PTAdvGrid.DataRows(mv_intCurrentRow)
                PTAdvAllGrid.SelectedRows.Clear()
                PTAdvAllGrid.SelectedRows.Add(PTAdvAllGrid.CurrentRow)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub On1FirmOrder()
        Try
            If MsgBox(mv_ResourceManager.GetString("MSG_CONFIRM_ONEF"), MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Me.Text) = MsgBoxResult.Yes Then
                'Màn hình đặt lệnh thoa thuan 2 firm
                Dim v_strAdvRedID, v_strSymbol As String
                Dim v_dblQuantity As Double
                Dim v_dblPrice As Double
                'If CType(PTAdvAllGrid.CurrentRow, Xceed.Grid.DataRow).Cells("ADVTRANSTYPE").Value = "N" Then
                '    If CType(PTAdvAllGrid.CurrentRow, Xceed.Grid.DataRow).Cells("ADVSIDE").Value = "S" And CType(PTAdvAllGrid.CurrentRow, Xceed.Grid.DataRow).Cells("SENDERSUBID").Value = "002" Then

                'If 
                v_strAdvRedID = CType(PTAdvAllGrid.CurrentRow, Xceed.Grid.DataRow).Cells("ADVID").Value
                v_dblQuantity = CDbl(CType(PTAdvAllGrid.CurrentRow, Xceed.Grid.DataRow).Cells("QUANTITY").Value)
                v_dblPrice = CDbl(CType(PTAdvAllGrid.CurrentRow, Xceed.Grid.DataRow).Cells("PRICE").Value)
                v_strSymbol = CType(PTAdvAllGrid.CurrentRow, Xceed.Grid.DataRow).Cells("SYMBOL").Value
                Dim frm As New frmQuickOrderPTOneFirm(Me.UserLanguage)
                frm.LocalObject = gc_IsNotLocalMsg
                frm.ModuleCode = "OD"
                frm.BranchId = Me.BranchId
                frm.TellerId = Me.TellerId
                frm.IpAddress = Me.IpAddress
                frm.WsName = Me.WsName
                frm.BusDate = Me.BusDate
                frm.AdvanceOrder = True
                frm.AFACCTNO = Nothing
                frm.CUSTODYCD = Nothing
                frm.Quantity = v_dblQuantity
                frm.Price = v_dblPrice / 1000
                frm.ADVREFID = v_strAdvRedID
                frm.Symbol = v_strSymbol
                frm.ShowDialog()
                frm.Dispose()
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub On2FirmOrder()
        Try
            If MsgBox(mv_ResourceManager.GetString("MSG_CONFIRM_TWOPF"), MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Me.Text) = MsgBoxResult.Yes Then
                'Màn hình đặt lệnh thoa thuan 2 firm
                Dim v_strAdvRedID, v_strSymbol, v_strBORS, v_strSENDERSUBID As String
                Dim v_dblQuantity As Double
                Dim v_dblPrice As Double
                'If CType(PTAdvAllGrid.CurrentRow, Xceed.Grid.DataRow).Cells("ADVTRANSTYPE").Value = "N" Then
                '    If CType(PTAdvAllGrid.CurrentRow, Xceed.Grid.DataRow).Cells("ADVSIDE").Value = "S" And CType(PTAdvAllGrid.CurrentRow, Xceed.Grid.DataRow).Cells("SENDERSUBID").Value = "002" Then

                'If 
                v_strAdvRedID = CType(PTAdvAllGrid.CurrentRow, Xceed.Grid.DataRow).Cells("ADVID").Value
                v_dblQuantity = CDbl(CType(PTAdvAllGrid.CurrentRow, Xceed.Grid.DataRow).Cells("QUANTITY").Value)
                v_dblPrice = CDbl(CType(PTAdvAllGrid.CurrentRow, Xceed.Grid.DataRow).Cells("PRICE").Value)
                v_strSymbol = CType(PTAdvAllGrid.CurrentRow, Xceed.Grid.DataRow).Cells("SYMBOL").Value
                'If CType(PTAdvAllGrid.CurrentRow, Xceed.Grid.DataRow).Cells("ADVSIDE").Value = "S" And CType(PTAdvAllGrid.CurrentRow, Xceed.Grid.DataRow).Cells("SENDERSUBID").Value = "002" Then
                '    v_strBORS = "NS"
                'ElseIf CType(PTAdvAllGrid.CurrentRow, Xceed.Grid.DataRow).Cells("ADVSIDE").Value = "B" And CType(PTAdvAllGrid.CurrentRow, Xceed.Grid.DataRow).Cells("SENDERSUBID").Value <> "002" Then
                '    v_strBORS = "NS"
                'End If
                v_strBORS = "NS"
                v_strSENDERSUBID = CType(PTAdvAllGrid.CurrentRow, Xceed.Grid.DataRow).Cells("SENDERSUBID").Value
                'Ngay 07/11/2018 NamTv chinh sua doi tu 022 --> SHV
                If v_strSENDERSUBID = "SHV" Then
                    v_strSENDERSUBID = CType(PTAdvAllGrid.CurrentRow, Xceed.Grid.DataRow).Cells("DELIVERTOCOMPID").Value
                    If v_strSENDERSUBID = "0" Then
                        v_strSENDERSUBID = ""
                    End If
                End If

                Dim frm As New frmQuickOrderTransactPT(Me.UserLanguage)
                frm.LocalObject = gc_IsNotLocalMsg
                frm.ModuleCode = "OD"
                frm.BranchId = Me.BranchId
                frm.TellerId = Me.TellerId
                frm.IpAddress = Me.IpAddress
                frm.WsName = Me.WsName
                frm.BusDate = Me.BusDate
                frm.AdvanceOrder = True
                frm.AFACCTNO = Nothing
                frm.CUSTODYCD = Nothing
                frm.Quantity = v_dblQuantity
                frm.Price = v_dblPrice
                frm.ADVREFID = v_strAdvRedID
                frm.Symbol = v_strSymbol
                frm.BORS = v_strBORS
                frm.CONTRAFIRM = v_strSENDERSUBID
                frm.ShowDialog()
                frm.Dispose()
            End If
        Catch ex As Exception
            Throw ex
        End Try

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
#End Region

    Private Sub frmPutthroughAcknowledgment_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetPTAdvMessage()
        GetPTCancelMessage()
        GetPTDealMessage()
        GetPTMsgMessage()
        GetPTAdvAllMessage()
        OnButtonStatusRefresh()
    End Sub

    Private Sub btnConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        If Me.TabControl1.SelectedTab Is TabControl1.TabPages(2) Then
            Exit Sub
        End If
        If Me.TabControl1.SelectedTab Is TabControl1.TabPages(4) Then
            'Thoa thuan 1 Firm
            On1FirmOrder()
            Exit Sub
        End If
        If MsgBox(mv_ResourceManager.GetString("MSG_CONFIRM_DEAL"), MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Me.Text) = MsgBoxResult.Yes Then

            If Me.TabControl1.SelectedTab Is TabControl1.TabPages(1) Then
                'Confirm dong y huy thoa thuan
                OnConfirm(Trim(CType(PTCancelMsgGrid.CurrentRow, Xceed.Grid.DataRow).Cells("CONFIRMNUMBER").Value))
                GetPTCancelMessage()
            ElseIf Me.TabControl1.SelectedTab Is TabControl1.TabPages(0) Then
                Dim v_strSymbol, v_strQtty, v_strPrice As String
                If Me.PTMsgGrid.DataRows.Count > 0 Then
                    If Not PTMsgGrid.CurrentRow Is Nothing Then
                        v_strSymbol = Trim(CType(PTMsgGrid.CurrentRow, Xceed.Grid.DataRow).Cells("SECURITYSYMBOL").Value)
                        v_strQtty = Trim(CType(PTMsgGrid.CurrentRow, Xceed.Grid.DataRow).Cells("VOLUME").Value)
                        v_strPrice = CStr(CType(PTMsgGrid.CurrentRow, Xceed.Grid.DataRow).Cells("PRICE").Value)
                        v_strPrice = CDbl(Mid(v_strPrice, 1, 6)) + CDbl("0." & Mid(v_strPrice, 7, 6))
                        v_strPrice = v_strPrice
                        Dim frm As New frmQuickOrderTransact(Me.UserLanguage)
                        frm.TellerId = Me.TellerId
                        frm.BranchId = Me.BranchId
                        frm.BusDate = Me.BusDate
                        frm.AdvanceOrder = True
                        frm.CurrentTime = DateTime.Now.ToString("HHmmss")
                        frm.InitParam = "EXECTYPE#NB|SYMBOL#" & v_strSymbol & "|QUANTITY#" & v_strQtty & "|PRICETYPE#LO|LIMITPRICE#" & v_strPrice & "|MATCHTYPE#P|VIA#F|DISABLEINPUT#1"
                        frm.CloseOnFinish = True
                        frm.mv_blnIsPTRepo = True
                        frm.ShowDialog()
                        Dim v_OrderNum As String = frm.ReturnValue
                        If v_OrderNum.Length > 0 Then
                            OnConfirm(Trim(v_OrderNum))
                            GetPTCancelMessage()
                            GetPTMsgMessage()
                        End If
                    End If
                End If
            Else
                Dim frm As New frmSearch(Me.UserLanguage)
                Dim strValue, strDisplay As String
                frm.TableName = "ODMAST"
                frm.ModuleCode = "OD"
                frm.AuthCode = "NNNNYYNNNN" 'Không cho phép thực hiện chức năng nào 
                frm.IsLocalSearch = gc_IsNotLocalMsg
                frm.IsLookup = "Y"
                frm.SearchOnInit = False
                frm.BranchId = Me.BranchId
                frm.TellerId = Me.TellerId
                strDisplay = "Match type = 'Putthrought'"
                strValue = "UPPER( Trim (T.MATCHTYPE)) = UPPER ('P')"

                CreateDefaultCondition(strDisplay, strValue)
                frm.ShowDialog()
                If Trim(frm.ReturnValue).Length > 0 Then
                    OnConfirm(Trim(frm.ReturnValue))
                    GetPTCancelMessage()
                    GetPTMsgMessage()
                Else
                    MessageBox.Show(mv_ResourceManager.GetString("MSG_CH_ORDER"))
                End If
            End If
        End If
    End Sub

    Private Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        OnClose()
    End Sub

    Private Sub btnReject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReject.Click
        Dim v_strErrorSource, v_strErrorMessage As String
        Dim v_lngErrorCode As Long
        Dim v_strClause As String
        If Me.TabControl1.SelectedTab Is TabControl1.TabPages(4) Then
            'Thoa thuan 2 Firm
            On2FirmOrder()
            Exit Sub
        End If
        'Reject thoa thuan
        If Me.TabControl1.SelectedTab Is TabControl1.TabPages(2) Then
            If (PTDealGrid.CurrentRow Is Nothing) Then
                Exit Sub
            End If
            If Trim(CType(PTDealGrid.CurrentRow, Xceed.Grid.DataRow).Cells("CANCELLING").Value) = "Yes" Then
                MessageBox.Show(mv_ResourceManager.GetString("MSG_PENDING01"))
                Exit Sub
            End If
        End If
        If MsgBox(mv_ResourceManager.GetString("MSG_CANCEL_DEAL"), MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Me.Text) = MsgBoxResult.Yes Then
            If Me.TabControl1.SelectedTab Is TabControl1.TabPages(2) Then
                If (PTDealGrid.CurrentRow Is Nothing) Then
                    Exit Sub
                End If
                OnReject(Trim(CType(PTDealGrid.CurrentRow, Xceed.Grid.DataRow).Cells("ORGORDERID").Value))
                GetPTCancelMessage()
                GetPTMsgMessage()
                GetPTDealMessage()
            ElseIf Me.TabControl1.SelectedTab Is TabControl1.TabPages(1) Then 'Confirm khong dong y huy thoa thuan
                OnReject(Trim(CType(PTCancelMsgGrid.CurrentRow, Xceed.Grid.DataRow).Cells("CONFIRMNUMBER").Value))
                GetPTCancelMessage()
                GetPTMsgMessage()
                GetPTDealMessage()
            Else 'ThanhNV: Huy lenh thoa thuan 
                'Neu SELL: Huy thoa thuan ban chua xac nhan.
                If Trim(CType(PTMsgGrid.CurrentRow, Xceed.Grid.DataRow).Cells("SIDE").Value) = "S" Then

                    If MsgBox(mv_ResourceManager.GetString("MSG_REJECT_DEAL"), MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Me.Text) = MsgBoxResult.Yes Then
                        v_strClause = Trim(CType(PTMsgGrid.CurrentRow, Xceed.Grid.DataRow).Cells("SIDE").Value) & "|" & Trim(CType(PTMsgGrid.CurrentRow, Xceed.Grid.DataRow).Cells("CONFIRMNUMBER").Value)
                        Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_strClause, "PutthroughRejectNotConfirm", , , , IpAddress)
                        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                        v_lngErrorCode = v_ws.Message(v_strObjMsg)

                        'KIEM TRA THONG TIN LAY LOI TRA VE
                        GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                        If v_lngErrorCode <> 0 Then
                            'Update mouse pointer
                            Cursor.Current = Cursors.Default
                            MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                            Exit Sub
                        End If

                    End If
                    GetPTCancelMessage()
                    GetPTMsgMessage()
                    GetPTDealMessage()
                Else
                    'Neu BUY: Reject yeu cau mua
                    ' DUCNV SU : KO CAN NHAP LENH DOI UNG
                    OnReject("0")
                    GetPTCancelMessage()
                    GetPTMsgMessage()
                    GetPTDealMessage()
                    'Dim frm As New frmSearch(Me.UserLanguage)
                    'Dim strValue, strDisplay As String
                    'frm.TableName = "ODMAST"
                    'frm.ModuleCode = "OD"
                    'frm.AuthCode = "NNNNYYNNNN" 'Không cho phép thực hiện chức năng nào 
                    'frm.IsLocalSearch = gc_IsNotLocalMsg
                    'frm.IsLookup = "Y"
                    'frm.SearchOnInit = False
                    'frm.BranchId = Me.BranchId
                    'frm.TellerId = Me.TellerId
                    'strDisplay = "Match type = 'Putthrought'"
                    'strValue = "UPPER( Trim (T.MATCHTYPE)) = UPPER ('P')"

                    'CreateDefaultCondition(strDisplay, strValue)
                    'frm.ShowDialog()
                    'If Trim(frm.ReturnValue).Length > 0 Then
                    '    OnReject(Trim(frm.ReturnValue))
                    '    GetPTCancelMessage()
                    '    GetPTMsgMessage()
                    '    GetPTDealMessage()
                    'Else
                    '    MessageBox.Show("Please chose the correspond order!")
                    'End If
                End If
            End If
        End If
    End Sub

    Private Sub btnADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnADD.Click
        OnAdd()
        GetPTAdvMessage()
    End Sub

    Private Sub btnDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDELETE.Click
        OnDelete()
        GetPTAdvMessage()
    End Sub

    Private Sub btnACTIVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnACTIVE.Click
        OnActive()
        GetPTAdvMessage()
    End Sub

    Private Sub btnCANCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCANCEL.Click
        OnCancel()
        GetPTAdvMessage()
    End Sub

    Private Sub PTAdvGridSelectedRowChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If (PTAdvGrid.CurrentRow Is Nothing) Then
            Exit Sub
        End If
        If CType(PTAdvGrid.CurrentRow, Xceed.Grid.DataRow).Cells("DELETED").Value = "Y" Then
            Me.btnCANCEL.Enabled = False
            Me.btnACTIVE.Enabled = False
            Me.btnDELETE.Enabled = False
        ElseIf CType(PTAdvGrid.CurrentRow, Xceed.Grid.DataRow).Cells("ISSEND").Value = "Y" Then
            Me.btnCANCEL.Enabled = True
            Me.btnACTIVE.Enabled = False
            Me.btnDELETE.Enabled = False
        ElseIf CType(PTAdvGrid.CurrentRow, Xceed.Grid.DataRow).Cells("ISACTIVE").Value = "N" Then
            Me.btnCANCEL.Enabled = False
            Me.btnACTIVE.Enabled = True
            Me.btnDELETE.Enabled = True
        ElseIf CType(PTAdvGrid.CurrentRow, Xceed.Grid.DataRow).Cells("ISACTIVE").Value = "Y" Then
            Me.btnCANCEL.Enabled = False
            Me.btnACTIVE.Enabled = False
            Me.btnDELETE.Enabled = False
        End If
    End Sub
    Private Sub PTDealGridSelectedRowChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If (PTDealGrid.CurrentRow Is Nothing) Then
            Exit Sub
        End If
        If CType(PTDealGrid.CurrentRow, Xceed.Grid.DataRow).Cells("BORS").Value = "B" Then
            Me.btnReject.Enabled = False ' Khong cho huy tu ben mua
            'Me.btnConfirm.Enabled = False ' Khong cho xac nhan tu ben mua
        Else
            Me.btnReject.Enabled = True ' Ben ban co quyen huy
            'Me.btnConfirm.Enabled = True ' Ben ban co xac nhan
        End If
    End Sub
    Private Sub PTAdvAllGridSelectedRowChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If (PTAdvAllGrid.CurrentRow Is Nothing) Then
            Exit Sub
        End If

        If (PTAdvAllGrid.CurrentRow Is Nothing) Then
            Me.btnReject.Enabled = False ' Khong thoa thuan 2 Firm
            Me.btnConfirm.Enabled = False ' Khong thoa thuan 1 Firm
        End If
        If CType(PTAdvAllGrid.CurrentRow, Xceed.Grid.DataRow).Cells("ADVTRANSTYPE").Value = "N" Then
            If CType(PTAdvAllGrid.CurrentRow, Xceed.Grid.DataRow).Cells("ADVSIDE").Value = "S" And CType(PTAdvAllGrid.CurrentRow, Xceed.Grid.DataRow).Cells("SENDERSUBID").Value = "SHV" And CType(PTAdvAllGrid.CurrentRow, Xceed.Grid.DataRow).Cells("DELIVERTOCOMPID").Value = "002" Then
                Me.btnReject.Enabled = False ' Duoc thoa thuan 2 Firm
                Me.btnConfirm.Enabled = True ' Duoc thoa thuan 1 Firm
            ElseIf CType(PTAdvAllGrid.CurrentRow, Xceed.Grid.DataRow).Cells("ADVSIDE").Value = "S" And CType(PTAdvAllGrid.CurrentRow, Xceed.Grid.DataRow).Cells("SENDERSUBID").Value = "SHV" And CType(PTAdvAllGrid.CurrentRow, Xceed.Grid.DataRow).Cells("DELIVERTOCOMPID").Value <> "002" And CType(PTAdvAllGrid.CurrentRow, Xceed.Grid.DataRow).Cells("DELIVERTOCOMPID").Value <> "0" Then
                Me.btnConfirm.Enabled = False
                Me.btnReject.Enabled = True
            ElseIf CType(PTAdvAllGrid.CurrentRow, Xceed.Grid.DataRow).Cells("ADVSIDE").Value = "S" And CType(PTAdvAllGrid.CurrentRow, Xceed.Grid.DataRow).Cells("SENDERSUBID").Value = "SHV" And CType(PTAdvAllGrid.CurrentRow, Xceed.Grid.DataRow).Cells("DELIVERTOCOMPID").Value <> "002" And CType(PTAdvAllGrid.CurrentRow, Xceed.Grid.DataRow).Cells("DELIVERTOCOMPID").Value = "0" Then
                Me.btnConfirm.Enabled = True
                Me.btnReject.Enabled = True
            ElseIf CType(PTAdvAllGrid.CurrentRow, Xceed.Grid.DataRow).Cells("ADVSIDE").Value = "B" And CType(PTAdvAllGrid.CurrentRow, Xceed.Grid.DataRow).Cells("SENDERSUBID").Value = "SHV" And CType(PTAdvAllGrid.CurrentRow, Xceed.Grid.DataRow).Cells("DELIVERTOCOMPID").Value = "0" Then
                Me.btnConfirm.Enabled = True
                Me.btnReject.Enabled = False
            ElseIf CType(PTAdvAllGrid.CurrentRow, Xceed.Grid.DataRow).Cells("ADVSIDE").Value = "B" And CType(PTAdvAllGrid.CurrentRow, Xceed.Grid.DataRow).Cells("SENDERSUBID").Value = "SHV" And CType(PTAdvAllGrid.CurrentRow, Xceed.Grid.DataRow).Cells("DELIVERTOCOMPID").Value = "002" Then
                Me.btnConfirm.Enabled = True
                Me.btnReject.Enabled = False
            ElseIf CType(PTAdvAllGrid.CurrentRow, Xceed.Grid.DataRow).Cells("ADVSIDE").Value = "B" And CType(PTAdvAllGrid.CurrentRow, Xceed.Grid.DataRow).Cells("SENDERSUBID").Value = "SHV" And CType(PTAdvAllGrid.CurrentRow, Xceed.Grid.DataRow).Cells("DELIVERTOCOMPID").Value <> "002" Then
                Me.btnConfirm.Enabled = False
                Me.btnReject.Enabled = False
            ElseIf CType(PTAdvAllGrid.CurrentRow, Xceed.Grid.DataRow).Cells("ADVSIDE").Value = "S" And CType(PTAdvAllGrid.CurrentRow, Xceed.Grid.DataRow).Cells("SENDERSUBID").Value = "SHV" And CType(PTAdvAllGrid.CurrentRow, Xceed.Grid.DataRow).Cells("DELIVERTOCOMPID").Value = "0" Then
                Me.btnConfirm.Enabled = True
                Me.btnReject.Enabled = True
            ElseIf CType(PTAdvAllGrid.CurrentRow, Xceed.Grid.DataRow).Cells("ADVSIDE").Value = "B" And CType(PTAdvAllGrid.CurrentRow, Xceed.Grid.DataRow).Cells("SENDERSUBID").Value <> "SHV" Then
                Me.btnConfirm.Enabled = False
                Me.btnReject.Enabled = True
            Else
                Me.btnConfirm.Enabled = False
                Me.btnReject.Enabled = False
            End If
        Else
            Me.btnReject.Enabled = False ' Khong thoa thuan 2 Firm
            Me.btnConfirm.Enabled = False ' Khong thoa thuan 1 Firm
        End If
    End Sub

    Private Sub PTMsgGridSelectedRowChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If (PTMsgGrid.CurrentRow Is Nothing) Then
            Me.btnReject.Enabled = False
            Me.btnConfirm.Enabled = False
            Exit Sub
        Else
            Me.btnReject.Enabled = True
            Me.btnConfirm.Enabled = True
            Exit Sub
        End If
    End Sub

    Private Sub PTCancelMsgGridSelectedRowChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If (PTCancelMsgGrid.CurrentRow Is Nothing) Then
            Exit Sub
        End If
        If CType(PTCancelMsgGrid.CurrentRow, Xceed.Grid.DataRow).Cells("SIDE").Value = "B" Then
            Me.btnReject.Enabled = False ' Khong cho huy tu ben mua
            Me.btnConfirm.Enabled = False ' Khong cho xac nhan tu ben mua
        Else
            Me.btnReject.Enabled = True ' Ben ban co quyen huy
            Me.btnConfirm.Enabled = True ' Ben ban co xac nhan
        End If
    End Sub

    Sub Prc_CeilFloor_Price()
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strCmdSQL As String, v_strObjMsg As String
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strFLDNAME, v_strValue As String
        Dim v_arrValue(), v_arrDisplay() As String
        Dim v_int As Integer
        Dim v_Info As String

        v_strCmdSQL = "select A.symbol || ': CeilPrice: '|| A.CEILINGPRICE/TRADEUNIT || '     FloorPrice: ' || A.FLOORPRICE/TRADEUNIT INFO, B.TRADEPLACE, A.CEILINGPRICE, A.FLOORPRICE, B.SECTYPE, TRADEUNIT from securities_info A, SBSECURITIES B Where  A.CODEID=B.CODEID AND A.symbol= '" & Me.cboSYMBOL.Text & "'"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_OD_ODMAST, gc_ActionInquiry, v_strCmdSQL)
        v_ws.Message(v_strObjMsg)

        v_xmlDocument.LoadXml(v_strObjMsg)
        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

        For i As Integer = 0 To v_nodeList.Count - 1
            For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                With v_nodeList.Item(i).ChildNodes(j)
                    v_strValue = .InnerText.ToString
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    Select Case Trim(v_strFLDNAME)
                        Case "INFO"
                            v_Info = v_strValue.Trim()
                        Case "TRADEPLACE"
                            mv_strTradePlace = v_strValue.Trim()
                        Case "CEILINGPRICE"
                            mv_dblCeilingPrice = CDbl(v_strValue)
                        Case "FLOORPRICE"
                            mv_dblFloorPrice = CDbl(v_strValue)
                        Case "SECTYPE"
                            mv_strSecType = v_strValue.Trim()
                        Case "TRADEUNIT"
                            mv_dblTradeUnit = CDbl(v_strValue)
                    End Select
                End With
            Next
        Next
        Me.lblInfoCeilFloor.Text = v_Info


    End Sub
    Private Sub OnButtonStatusRefresh()
        If Me.TabControl1.SelectedTab Is TabControl1.TabPages(0) Then
            btnReject.Text = mv_ResourceManager.GetString("btnReject")
            btnConfirm.Text = mv_ResourceManager.GetString("btnConfirm")
            If (PTMsgGrid.CurrentRow Is Nothing) Then
                Me.btnReject.Enabled = False
                Me.btnConfirm.Enabled = False
                Exit Sub
            Else
                Me.btnReject.Enabled = True
                Me.btnConfirm.Enabled = True
                Exit Sub
            End If
        ElseIf Me.TabControl1.SelectedTab Is TabControl1.TabPages(1) Then
            btnReject.Text = mv_ResourceManager.GetString("btnReject")
            btnConfirm.Text = mv_ResourceManager.GetString("btnConfirm")
            If (PTCancelMsgGrid.CurrentRow Is Nothing) Then
                Me.btnReject.Enabled = False ' Khong cho huy tu ben mua
                Me.btnConfirm.Enabled = False ' Khong cho xac nhan tu ben mua
                Exit Sub
            End If
            If CType(PTCancelMsgGrid.CurrentRow, Xceed.Grid.DataRow).Cells("SIDE").Value = "B" Then
                Me.btnReject.Enabled = False ' Khong cho huy tu ben mua
                Me.btnConfirm.Enabled = False ' Khong cho xac nhan tu ben mua
            Else
                Me.btnReject.Enabled = True ' Ben ban co quyen huy
                Me.btnConfirm.Enabled = True ' Ben ban co xac nhan
            End If
        ElseIf Me.TabControl1.SelectedTab Is TabControl1.TabPages(2) Then
            btnReject.Text = mv_ResourceManager.GetString("btnReject_Cancel")
            btnConfirm.Text = mv_ResourceManager.GetString("btnConfirm")
            If (PTDealGrid.CurrentRow Is Nothing) Then
                Me.btnReject.Enabled = False
                btnConfirm.Enabled = False
                Exit Sub
            End If
            If CType(PTDealGrid.CurrentRow, Xceed.Grid.DataRow).Cells("BORS").Value = "B" Then
                Me.btnReject.Enabled = False ' Khong cho huy tu ben mua
                'Me.btnConfirm.Enabled = False ' Khong cho xac nhan tu ben mua
            Else
                Me.btnReject.Enabled = True ' Ben ban co quyen huy
                'Me.btnConfirm.Enabled = True ' Ben ban co xac nhan
            End If
            btnConfirm.Enabled = False
        ElseIf Me.TabControl1.SelectedTab Is TabControl1.TabPages(3) Then
            btnReject.Text = mv_ResourceManager.GetString("btnReject_Cancel")
            btnConfirm.Text = mv_ResourceManager.GetString("btnConfirm")
            If (PTAdvGrid.CurrentRow Is Nothing) Then
                Me.btnCANCEL.Enabled = False
                Me.btnACTIVE.Enabled = False
                Me.btnDELETE.Enabled = False
                Exit Sub
            End If
            If CType(PTAdvGrid.CurrentRow, Xceed.Grid.DataRow).Cells("DELETED").Value = "Y" Then
                Me.btnCANCEL.Enabled = False
                Me.btnACTIVE.Enabled = False
                Me.btnDELETE.Enabled = False
            ElseIf CType(PTAdvGrid.CurrentRow, Xceed.Grid.DataRow).Cells("ISSEND").Value = "Y" Then
                Me.btnCANCEL.Enabled = True
                Me.btnACTIVE.Enabled = False
                Me.btnDELETE.Enabled = False
            ElseIf CType(PTAdvGrid.CurrentRow, Xceed.Grid.DataRow).Cells("ISACTIVE").Value = "N" Then
                Me.btnCANCEL.Enabled = False
                Me.btnACTIVE.Enabled = True
                Me.btnDELETE.Enabled = True
            ElseIf CType(PTAdvGrid.CurrentRow, Xceed.Grid.DataRow).Cells("ISACTIVE").Value = "Y" Then
                Me.btnCANCEL.Enabled = False
                Me.btnACTIVE.Enabled = False
                Me.btnDELETE.Enabled = False
            End If
        ElseIf Me.TabControl1.SelectedTab Is TabControl1.TabPages(4) Then
            btnReject.Text = mv_ResourceManager.GetString("btnReject_2Firm")
            btnConfirm.Text = mv_ResourceManager.GetString("btnConfirm_1Firm")
            If (PTAdvAllGrid.CurrentRow Is Nothing) Then
                Me.btnReject.Enabled = False ' Khong thoa thuan 2 Firm
                Me.btnConfirm.Enabled = False ' Khong thoa thuan 1 Firm
                Exit Sub
            End If
            If CType(PTAdvAllGrid.CurrentRow, Xceed.Grid.DataRow).Cells("ADVTRANSTYPE").Value = "N" Then
                If CType(PTAdvAllGrid.CurrentRow, Xceed.Grid.DataRow).Cells("ADVSIDE").Value = "S" And CType(PTAdvAllGrid.CurrentRow, Xceed.Grid.DataRow).Cells("SENDERSUBID").Value = "SHV" Then
                    Me.btnReject.Enabled = True ' Duoc thoa thuan 2 Firm
                    Me.btnConfirm.Enabled = True ' Duoc thoa thuan 1 Firm
                ElseIf CType(PTAdvAllGrid.CurrentRow, Xceed.Grid.DataRow).Cells("ADVSIDE").Value = "B" And CType(PTAdvAllGrid.CurrentRow, Xceed.Grid.DataRow).Cells("SENDERSUBID").Value = "SHV" Then
                    Me.btnConfirm.Enabled = True
                    Me.btnReject.Enabled = False

                ElseIf CType(PTAdvAllGrid.CurrentRow, Xceed.Grid.DataRow).Cells("ADVSIDE").Value = "B" And CType(PTAdvAllGrid.CurrentRow, Xceed.Grid.DataRow).Cells("SENDERSUBID").Value <> "SHV" Then
                    Me.btnConfirm.Enabled = False
                    Me.btnReject.Enabled = True
                Else
                    Me.btnConfirm.Enabled = False
                    Me.btnReject.Enabled = False
                End If
                If CType(PTAdvAllGrid.CurrentRow, Xceed.Grid.DataRow).Cells("DELIVERTOCOMPID").Value <> "SHV" And CType(PTAdvAllGrid.CurrentRow, Xceed.Grid.DataRow).Cells("DELIVERTOCOMPID").Value <> "0" Then
                    Me.btnConfirm.Enabled = False
                    'Me.btnReject.Enabled = False
                End If
            Else
                Me.btnReject.Enabled = False ' Khong thoa thuan 2 Firm
                Me.btnConfirm.Enabled = False ' Khong thoa thuan 1 Firm
            End If
        End If
    End Sub

    Private Sub cboSYMBOL_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSYMBOL.SelectedIndexChanged
        Prc_CeilFloor_Price()
    End Sub

    Private Sub pnPutthroughCancel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnPutthroughCancel.Paint

    End Sub

    Private Sub btnReresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        GetPTAdvMessage()
        GetPTCancelMessage()
        GetPTDealMessage()
        GetPTMsgMessage()
        GetPTAdvAllMessage()
        OnButtonStatusRefresh()
    End Sub

    Private Sub grbAdvMsg_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grbAdvMsg.Enter

    End Sub

    Private Sub frmPutthroughAcknowledgment_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Select Case e.KeyCode
            Case Keys.Escape
                OnClose()
        End Select
    End Sub

    Private Sub txtCONTACT_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCONTACT.Validated
        If txtCONTACT.Text.Length > 0 Then
            If Not IsNumeric(txtCONTACT.Text) Then
                MessageBox.Show(mv_ResourceManager.GetString("INVALID_PHONENUMBER"))
                txtCONTACT.Focus()
            End If
        End If
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        'If Me.TabControl1.SelectedTab Is TabControl1.TabPages(0) Then
        '    btnReject.Text = mv_ResourceManager.GetString("btnReject")
        '    btnConfirm.Text = mv_ResourceManager.GetString("btnConfirm")
        '    btnReject.Enabled = True
        '    btnConfirm.Enabled = True
        'ElseIf Me.TabControl1.SelectedTab Is TabControl1.TabPages(1) Then
        '    btnReject.Text = mv_ResourceManager.GetString("btnReject")
        '    btnConfirm.Text = mv_ResourceManager.GetString("btnConfirm")
        '    btnReject.Enabled = True
        '    btnConfirm.Enabled = True
        'ElseIf Me.TabControl1.SelectedTab Is TabControl1.TabPages(2) Then
        '    btnReject.Text = mv_ResourceManager.GetString("btnReject_Cancel")
        '    btnConfirm.Text = mv_ResourceManager.GetString("btnConfirm")
        '    btnReject.Enabled = True
        '    btnConfirm.Enabled = False
        'ElseIf Me.TabControl1.SelectedTab Is TabControl1.TabPages(3) Then
        '    btnReject.Text = mv_ResourceManager.GetString("btnReject_Cancel")
        '    btnConfirm.Text = mv_ResourceManager.GetString("btnConfirm")
        '    btnReject.Enabled = False
        '    btnConfirm.Enabled = False
        'ElseIf Me.TabControl1.SelectedTab Is TabControl1.TabPages(4) Then
        '    btnReject.Text = mv_ResourceManager.GetString("btnReject_2Firm")
        '    btnConfirm.Text = mv_ResourceManager.GetString("btnConfirm_1Firm")
        '    btnReject.Enabled = False
        '    btnConfirm.Enabled = False
        'End If
        OnButtonStatusRefresh()
    End Sub

   
End Class
