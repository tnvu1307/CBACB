Imports CommonLibrary

Public Class frmOrderSendingConfirm
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal pv_strLanguage As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        mv_strUserLanguage = pv_strLanguage
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        LoadResource(Me)
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
    Friend WithEvents pnlDisplay As System.Windows.Forms.Panel
    Friend WithEvents lblLine6 As System.Windows.Forms.Label
    Friend WithEvents lblLine5 As System.Windows.Forms.Label
    Friend WithEvents lblLine4 As System.Windows.Forms.Label
    Friend WithEvents lblLine3 As System.Windows.Forms.Label
    Friend WithEvents lblLine1 As System.Windows.Forms.Label
    Friend WithEvents btnSend As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblLine7 As System.Windows.Forms.Label
    Friend WithEvents btnRefuse As System.Windows.Forms.Button
    Friend WithEvents lblLine8 As System.Windows.Forms.Label
    Friend WithEvents lblLine2 As System.Windows.Forms.Label
    Friend WithEvents txtQTTY As System.Windows.Forms.TextBox
    Friend WithEvents txtPRICE As System.Windows.Forms.TextBox
    Friend WithEvents lblQTTY As System.Windows.Forms.Label
    Friend WithEvents lblPRICE As System.Windows.Forms.Label
    Friend WithEvents lblExe As System.Windows.Forms.Label
    Friend WithEvents txtExe As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.pnlDisplay = New System.Windows.Forms.Panel
        Me.lblLine8 = New System.Windows.Forms.Label
        Me.lblLine7 = New System.Windows.Forms.Label
        Me.lblLine6 = New System.Windows.Forms.Label
        Me.lblLine5 = New System.Windows.Forms.Label
        Me.lblLine4 = New System.Windows.Forms.Label
        Me.lblLine3 = New System.Windows.Forms.Label
        Me.lblLine2 = New System.Windows.Forms.Label
        Me.lblLine1 = New System.Windows.Forms.Label
        Me.btnSend = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnRefuse = New System.Windows.Forms.Button
        Me.txtQTTY = New System.Windows.Forms.TextBox
        Me.txtPRICE = New System.Windows.Forms.TextBox
        Me.lblQTTY = New System.Windows.Forms.Label
        Me.lblPRICE = New System.Windows.Forms.Label
        Me.lblExe = New System.Windows.Forms.Label
        Me.txtExe = New System.Windows.Forms.TextBox
        Me.pnlDisplay.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlDisplay
        '
        Me.pnlDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlDisplay.Controls.Add(Me.lblLine8)
        Me.pnlDisplay.Controls.Add(Me.lblLine7)
        Me.pnlDisplay.Controls.Add(Me.lblLine6)
        Me.pnlDisplay.Controls.Add(Me.lblLine5)
        Me.pnlDisplay.Controls.Add(Me.lblLine4)
        Me.pnlDisplay.Controls.Add(Me.lblLine3)
        Me.pnlDisplay.Controls.Add(Me.lblLine2)
        Me.pnlDisplay.Controls.Add(Me.lblLine1)
        Me.pnlDisplay.Location = New System.Drawing.Point(4, 4)
        Me.pnlDisplay.Name = "pnlDisplay"
        Me.pnlDisplay.Size = New System.Drawing.Size(672, 252)
        Me.pnlDisplay.TabIndex = 15
        '
        'lblLine8
        '
        Me.lblLine8.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLine8.ForeColor = System.Drawing.Color.Indigo
        Me.lblLine8.Location = New System.Drawing.Point(8, 64)
        Me.lblLine8.Name = "lblLine8"
        Me.lblLine8.Size = New System.Drawing.Size(656, 36)
        Me.lblLine8.TabIndex = 7
        Me.lblLine8.Text = "lblLine8"
        Me.lblLine8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLine7
        '
        Me.lblLine7.Location = New System.Drawing.Point(396, 8)
        Me.lblLine7.Name = "lblLine7"
        Me.lblLine7.Size = New System.Drawing.Size(268, 23)
        Me.lblLine7.TabIndex = 6
        Me.lblLine7.Text = "lblLine7"
        Me.lblLine7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblLine6
        '
        Me.lblLine6.Location = New System.Drawing.Point(396, 36)
        Me.lblLine6.Name = "lblLine6"
        Me.lblLine6.Size = New System.Drawing.Size(268, 23)
        Me.lblLine6.TabIndex = 5
        Me.lblLine6.Text = "lblLine6"
        Me.lblLine6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblLine5
        '
        Me.lblLine5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblLine5.Font = New System.Drawing.Font("Tahoma", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLine5.Location = New System.Drawing.Point(8, 187)
        Me.lblLine5.Name = "lblLine5"
        Me.lblLine5.Size = New System.Drawing.Size(656, 56)
        Me.lblLine5.TabIndex = 4
        Me.lblLine5.Text = "lblLine5"
        Me.lblLine5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLine4
        '
        Me.lblLine4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLine4.Location = New System.Drawing.Point(8, 155)
        Me.lblLine4.Name = "lblLine4"
        Me.lblLine4.Size = New System.Drawing.Size(656, 23)
        Me.lblLine4.TabIndex = 3
        Me.lblLine4.Text = "Label4"
        Me.lblLine4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLine3
        '
        Me.lblLine3.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLine3.Location = New System.Drawing.Point(8, 103)
        Me.lblLine3.Name = "lblLine3"
        Me.lblLine3.Size = New System.Drawing.Size(656, 44)
        Me.lblLine3.TabIndex = 2
        Me.lblLine3.Text = "Label3"
        Me.lblLine3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLine2
        '
        Me.lblLine2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLine2.Location = New System.Drawing.Point(8, 36)
        Me.lblLine2.Name = "lblLine2"
        Me.lblLine2.Size = New System.Drawing.Size(332, 23)
        Me.lblLine2.TabIndex = 1
        Me.lblLine2.Text = "Label2"
        '
        'lblLine1
        '
        Me.lblLine1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLine1.Location = New System.Drawing.Point(8, 8)
        Me.lblLine1.Name = "lblLine1"
        Me.lblLine1.Size = New System.Drawing.Size(332, 23)
        Me.lblLine1.TabIndex = 0
        Me.lblLine1.Text = "Label1"
        '
        'btnSend
        '
        Me.btnSend.Location = New System.Drawing.Point(516, 266)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(75, 23)
        Me.btnSend.TabIndex = 16
        Me.btnSend.Text = "&Send"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(600, 266)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 17
        Me.btnCancel.Text = "&Exit"
        '
        'btnRefuse
        '
        Me.btnRefuse.Location = New System.Drawing.Point(432, 266)
        Me.btnRefuse.Name = "btnRefuse"
        Me.btnRefuse.Size = New System.Drawing.Size(75, 23)
        Me.btnRefuse.TabIndex = 18
        Me.btnRefuse.Text = "&Refuse"
        '
        'txtQTTY
        '
        Me.txtQTTY.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQTTY.ForeColor = System.Drawing.Color.SlateBlue
        Me.txtQTTY.Location = New System.Drawing.Point(232, 265)
        Me.txtQTTY.Name = "txtQTTY"
        Me.txtQTTY.Size = New System.Drawing.Size(64, 23)
        Me.txtQTTY.TabIndex = 19
        Me.txtQTTY.Text = "txtQTTY"
        '
        'txtPRICE
        '
        Me.txtPRICE.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPRICE.ForeColor = System.Drawing.Color.SlateBlue
        Me.txtPRICE.Location = New System.Drawing.Point(360, 265)
        Me.txtPRICE.Name = "txtPRICE"
        Me.txtPRICE.Size = New System.Drawing.Size(64, 23)
        Me.txtPRICE.TabIndex = 20
        Me.txtPRICE.Text = "txtPRICE"
        '
        'lblQTTY
        '
        Me.lblQTTY.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQTTY.ForeColor = System.Drawing.Color.SlateBlue
        Me.lblQTTY.Location = New System.Drawing.Point(148, 265)
        Me.lblQTTY.Name = "lblQTTY"
        Me.lblQTTY.Size = New System.Drawing.Size(80, 20)
        Me.lblQTTY.TabIndex = 21
        Me.lblQTTY.Text = "lblQTTY"
        '
        'lblPRICE
        '
        Me.lblPRICE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPRICE.ForeColor = System.Drawing.Color.SlateBlue
        Me.lblPRICE.Location = New System.Drawing.Point(300, 265)
        Me.lblPRICE.Name = "lblPRICE"
        Me.lblPRICE.Size = New System.Drawing.Size(60, 20)
        Me.lblPRICE.TabIndex = 22
        Me.lblPRICE.Text = "lblPRICE"
        '
        'lblExe
        '
        Me.lblExe.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExe.ForeColor = System.Drawing.Color.SlateBlue
        Me.lblExe.Location = New System.Drawing.Point(12, 265)
        Me.lblExe.Name = "lblExe"
        Me.lblExe.Size = New System.Drawing.Size(68, 20)
        Me.lblExe.TabIndex = 24
        Me.lblExe.Text = "lblExe"
        Me.lblExe.Visible = False
        '
        'txtExe
        '
        Me.txtExe.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExe.ForeColor = System.Drawing.Color.SlateBlue
        Me.txtExe.Location = New System.Drawing.Point(80, 265)
        Me.txtExe.Name = "txtExe"
        Me.txtExe.Size = New System.Drawing.Size(64, 23)
        Me.txtExe.TabIndex = 23
        Me.txtExe.Text = "txtExe"
        Me.txtExe.Visible = False
        '
        'frmOrderSendingConfirm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(682, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblExe)
        Me.Controls.Add(Me.txtExe)
        Me.Controls.Add(Me.lblPRICE)
        Me.Controls.Add(Me.lblQTTY)
        Me.Controls.Add(Me.txtPRICE)
        Me.Controls.Add(Me.txtQTTY)
        Me.Controls.Add(Me.btnRefuse)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSend)
        Me.Controls.Add(Me.pnlDisplay)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOrderSendingConfirm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Order Sending Confirm"
        Me.pnlDisplay.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region " Declare constant and variables "
    Const c_ResourceManager = "_DIRECT.frmOrderSendingConfirm-"
    Private mv_ResourceManager As Resources.ResourceManager
    Private mv_strUserLanguage As String
    Private mv_strTLTXCD As String
    Private mv_strTxNum As String
    Private mv_strTxDate As String
    Private mv_strAFAccount As String
    Private mv_strCustodyCode As String
    Private mv_strCustName As String
    Private mv_strSymbol As String
    Private mv_strIssuer As String
    Private mv_strPrice As String
    Private mv_strQuantity As String
    Private mv_strOrderID As String
    Private mv_strRefOrderID As String
    Private mv_strBuyOrSell As String
    Private mv_strTradeUnit As String
    Private mv_strBratio As String
    Private mv_strOldBratio As String
    Private mv_strBranchId As String
    Private mv_strTellerID As String
    Private mv_strPriceType As String
    Private mv_strClearDay As String
    Private mv_strTellerType As String
    Private mv_strTxDesc As String
    Private mv_strSEAcctNo As String
    Private mv_strFullName As String
    Private mv_strTradeLot As String
    'Cho huy sua
    Private mv_strMatchedQtty As String
    Private mv_strCancelQtty As String
    Private mv_strAmentmentQtty As String
    Private mv_strAmendmentPrice As String
    Private mv_strOldAmentmentQtty As String
    Private mv_strOldAmendmentPrice As String
    Private mv_intNoSubmit As Integer = 0
    Private mv_blnEditOrder As Boolean = False
    Private mv_strExecQtty As String


    Dim mv_isSEND As Boolean = False
    Dim mv_isDeleteOK As Boolean = False
    Public mv_intStep As Integer = 0

    Private mv_arrObjFields() As CFieldMaster
    Private mv_arrObjFldVals() As CFieldVal
    Private mv_arrObjAccounts() As CAccountEntry

    Private mv_blnAcctEntry As Boolean = False
    Private mv_strIpAddress As String
    Private mv_strWsName As String
    Private mv_strBusDate As String

    Private Const OD_RELEASE_BUY_ORDER As String = "8852"
    Private Const OD_RELEASE_SELL_ORDER As String = "8853"

    Private Const OD_ORSTATUS_COMPLETE As String = "7"

    Private mv_strOrderStatus As String
    Private mv_strMapOrder As String = ""
    Private mv_strOutOrderStatus As String
    Private mv_strExecType As String

#End Region

#Region " Properties "

    Public Property ExecType() As String
        Get
            Return mv_strExecType
        End Get
        Set(ByVal Value As String)
            mv_strExecType = Value
        End Set
    End Property

    Public Property IsEditOrder() As Boolean
        Get
            Return mv_blnEditOrder
        End Get
        Set(ByVal Value As Boolean)
            mv_blnEditOrder = Value
        End Set
    End Property
    Public Property ExecQtty() As String
        Get
            Return mv_strExecQtty
        End Get
        Set(ByVal Value As String)
            mv_strExecQtty = Value
        End Set
    End Property

    Public Property NoSubmit() As Integer
        Get
            Return mv_intNoSubmit
        End Get
        Set(ByVal Value As Integer)
            mv_intNoSubmit = Value
        End Set
    End Property

    Public Property AmendmentPrice() As String
        Get
            Return mv_strAmendmentPrice
        End Get
        Set(ByVal Value As String)
            mv_strAmendmentPrice = Value
        End Set
    End Property
    Public Property AmendmentQtty() As String
        Get
            Return mv_strAmentmentQtty
        End Get
        Set(ByVal Value As String)
            mv_strAmentmentQtty = Value
        End Set
    End Property

    Public Property OldAmendmentPrice() As String
        Get
            Return mv_strOldAmendmentPrice
        End Get
        Set(ByVal Value As String)
            mv_strOldAmendmentPrice = Value
        End Set
    End Property
    Public Property OldAmendmentQtty() As String
        Get
            Return mv_strOldAmentmentQtty
        End Get
        Set(ByVal Value As String)
            mv_strOldAmentmentQtty = Value
        End Set
    End Property

    Public Property CancelQtty() As String
        Get
            Return mv_strCancelQtty
        End Get
        Set(ByVal Value As String)
            mv_strCancelQtty = Value
        End Set
    End Property

    Public Property MatchedQtty() As String
        Get
            Return mv_strMatchedQtty
        End Get
        Set(ByVal Value As String)
            mv_strMatchedQtty = Value
        End Set
    End Property

    Public Property OrderStatus() As String
        Get
            Return mv_strOrderStatus
        End Get
        Set(ByVal Value As String)
            mv_strOrderStatus = Value
        End Set
    End Property

    Public Property MapOrder() As String
        Get
            Return mv_strMapOrder
        End Get
        Set(ByVal Value As String)
            mv_strMapOrder = Value
        End Set
    End Property

    Public Property OutOrderStatus() As String
        Get
            Return mv_strOutOrderStatus
        End Get
        Set(ByVal Value As String)
            mv_strOutOrderStatus = Value
        End Set
    End Property

    Public Property FullName() As String
        Get
            Return mv_strFullName
        End Get
        Set(ByVal Value As String)
            mv_strFullName = Value
        End Set
    End Property

    Public Property TradeLot() As String
        Get
            Return mv_strTradeLot
        End Get
        Set(ByVal Value As String)
            mv_strTradeLot = Value
        End Set
    End Property

    Public Property SEAcctNo() As String
        Get
            Return mv_strSEAcctNo
        End Get
        Set(ByVal Value As String)
            mv_strSEAcctNo = Value
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
    Public Property BusDate() As String
        Get
            Return mv_strBusDate
        End Get
        Set(ByVal Value As String)
            mv_strBusDate = Value
        End Set
    End Property
    Public Property Bratio() As String
        Get
            Return mv_strBratio
        End Get
        Set(ByVal Value As String)
            mv_strBratio = Value
        End Set
    End Property
    Public Property OldBratio() As String
        Get
            Return mv_strOldBratio
        End Get
        Set(ByVal Value As String)
            mv_strOldBratio = Value
        End Set
    End Property
    Public Property TradeUnit() As String
        Get
            Return mv_strTradeUnit
        End Get
        Set(ByVal Value As String)
            mv_strTradeUnit = Value
        End Set
    End Property
    Public Property TxDesc() As String
        Get
            Return mv_strTxDesc
        End Get
        Set(ByVal Value As String)
            mv_strTxDesc = Value
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
    Public Property TLTXCD() As String
        Get
            Return mv_strTLTXCD
        End Get
        Set(ByVal Value As String)
            mv_strTLTXCD = Value
        End Set
    End Property
    Public Property UserLanguage() As String
        Get
            Return mv_strUserLanguage
        End Get
        Set(ByVal Value As String)
            mv_strUserLanguage = Value
        End Set
    End Property
    Public Property ClearDays() As String
        Get
            Return mv_strClearDay
        End Get
        Set(ByVal Value As String)
            mv_strClearDay = Value
        End Set
    End Property
    Public Property PriceType() As String
        Get
            Return mv_strPriceType
        End Get
        Set(ByVal Value As String)
            mv_strPriceType = Value
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
    Public Property TellerID() As String
        Get
            Return mv_strTellerID
        End Get
        Set(ByVal Value As String)
            mv_strTellerID = Value
        End Set
    End Property
    Public Property BOrS() As String
        Get
            Return mv_strBuyOrSell
        End Get
        Set(ByVal Value As String)
            mv_strBuyOrSell = Value
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
    Public Property TxDate() As String
        Get
            Return mv_strTxDate
        End Get
        Set(ByVal Value As String)
            mv_strTxDate = Value
        End Set
    End Property
    Public Property AFAccount() As String
        Get
            Return mv_strAFAccount
        End Get
        Set(ByVal Value As String)
            mv_strAFAccount = Value
        End Set
    End Property
    Public Property CustodyCode() As String
        Get
            Return mv_strCustodyCode
        End Get
        Set(ByVal Value As String)
            mv_strCustodyCode = Value
        End Set
    End Property

    Public Property CustomerFullName() As String
        Get
            Return mv_strCustName
        End Get
        Set(ByVal Value As String)
            mv_strCustName = Value
        End Set
    End Property
    Public Property Symbol() As String
        Get
            Return mv_strSymbol
        End Get
        Set(ByVal Value As String)
            mv_strSymbol = Value
        End Set
    End Property
    Public Property Issuer() As String
        Get
            Return mv_strIssuer
        End Get
        Set(ByVal Value As String)
            mv_strIssuer = Value
        End Set
    End Property
    Public Property Price() As String
        Get
            Return mv_strPrice
        End Get
        Set(ByVal Value As String)
            mv_strPrice = Value
        End Set
    End Property
    Public Property Quantity() As String
        Get
            Return mv_strQuantity
        End Get
        Set(ByVal Value As String)
            mv_strQuantity = Value
        End Set
    End Property
    Public Property OrderID() As String
        Get
            Return mv_strOrderID
        End Get
        Set(ByVal Value As String)
            mv_strOrderID = Value
        End Set
    End Property
    Public Property RefOrderID() As String
        Get
            Return mv_strRefOrderID
        End Get
        Set(ByVal Value As String)
            mv_strRefOrderID = Value
        End Set
    End Property
    'Public Property TradePlace() As String
    '    Get
    '        Return mv_strTradePlace
    '    End Get
    '    Set(ByVal Value As String)
    '        mv_strTradePlace = Value
    '    End Set
    'End Property
    'Public Property Via() As String
    '    Get
    '        Return mv_strVia
    '    End Get
    '    Set(ByVal Value As String)
    '        mv_strVia = Value
    '    End Set
    'End Property
#End Region

#Region " Form event "
    Private Sub frmOrderSendingConfirm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        'OnLock()
        OnView()
    End Sub
    Private Sub btnSend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSend.Click
        ''Check before send
        'If CDbl(txtQTTY.Text) Mod CDbl(TradeLot) > 0 Then
        '    MessageBox.Show("Invalid trade lot!")
        '    Exit Sub
        'End If
        'If NoSubmit > 0 Then
        '    If CInt(Me.txtQTTY.Text) > CInt(Quantity) - CInt(MatchedQtty) Then
        '        MessageBox.Show("Invalid adjust quantity!")
        '        Me.txtQTTY.Focus()
        '        Exit Sub
        '    End If
        'End If
        'If InStr(gc_OD_CANCELBUYORDER & "/" & gc_OD_CANCELSELLORDER, TLTXCD) > 0 Then
        '    OnCancelOrder()
        'ElseIf InStr(gc_OD_AMENDMENTBUYORDER & "/" & gc_OD_AMENDMENTSELLORDER, TLTXCD) > 0 Then
        '    OnAmendmentOrder()
        'Else
        '    OnSent()
        'End If
        OnSendClick()
    End Sub
    Private Sub btnRefuse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefuse.Click
        If InStr(gc_OD_CANCELBUYORDER & "/" & gc_OD_CANCELSELLORDER & "/" & gc_OD_AMENDMENTBUYORDER & "/" & gc_OD_AMENDMENTSELLORDER, TLTXCD) > 0 Then
            OnRefuseCorrect()
        Else
            OnRefuse()
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        'OnUnLock()
        'OnDeleteODQUEUE()
        'OnClose()
        OnCancel()
    End Sub
    Private Sub frmOrderSendingConfirm_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Select Case e.KeyCode
            Case Keys.Home
                If btnRefuse.Enabled Then
                    If InStr(gc_OD_CANCELBUYORDER & "/" & gc_OD_CANCELSELLORDER & "/" & gc_OD_AMENDMENTBUYORDER & "/" & gc_OD_AMENDMENTSELLORDER, TLTXCD) > 0 Then
                        OnRefuseCorrect()
                    Else
                        OnRefuse()
                    End If
                End If

            Case Keys.Escape
                'OnUnLock()
                'OnDeleteODQUEUE()
                'OnClose()
                OnCancel()
            Case Keys.End
                'If Me.btnSend.Enabled Then
                '    If InStr(gc_OD_CANCELBUYORDER & "/" & gc_OD_CANCELSELLORDER, TLTXCD) > 0 Then
                '        OnCancelOrder()
                '    ElseIf InStr(gc_OD_AMENDMENTBUYORDER & "/" & gc_OD_AMENDMENTSELLORDER, TLTXCD) > 0 Then
                '        OnAmendmentOrder()
                '    Else
                '        OnSent()
                '    End If
                'End If
                If Me.btnSend.Enabled Then
                    OnSendClick()
                End If

        End Select
    End Sub
    Private Sub frmOrderSendingConfirm_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        If Not mv_isSEND Then
            'OnUnLock()
            'OnDeleteODQUEUE()
            'OnClose()
            OnCancel()
        End If
    End Sub


    Private Sub txtQTTY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtQTTY.Validating
        If Not IsNumeric(Me.txtQTTY.Text) Then
            MessageBox.Show(mv_ResourceManager.GetString("Invalidnumeric"))
            Me.txtQTTY.Focus()
            e.Cancel = True
            Return
        End If

        'If CDbl(txtQTTY.Text) Mod CDbl(TradeLot) > 0 Then
        '    MessageBox.Show(mv_ResourceManager.GetString("Invalidtradelot"))
        '    e.Cancel = True
        '    Return
        'End If

        If NoSubmit > 0 Then
            'If CInt(Me.txtQTTY.Text) > CInt(Quantity) - CInt(MatchedQtty) Then
            '    MessageBox.Show("Invalid adjust quantity!")
            '    Me.txtQTTY.Focus()
            'End If
            If InStr(gc_OD_AMENDMENTBUYORDER & "/" & gc_OD_AMENDMENTSELLORDER, TLTXCD) > 0 Then
                'lblLine3.Text = BOrS & " | " & Symbol & " | Quantity: " & FormatNumber(Me.txtQTTY.Text, 0) & " | Price: " & CDbl(AmendmentPrice) / CDbl(Me.TradeUnit)
                'If PriceType <> "LO" Then
                '    lblLine3.Text = BOrS & " | " & Symbol & " | " & mv_ResourceManager.GetString("Quantity") & ": " & FormatNumber(Me.txtQTTY.Text, 0) & " | " & mv_ResourceManager.GetString("Price") & ": " & PriceType
                'Else
                '    lblLine3.Text = BOrS & " | " & Symbol & " | " & mv_ResourceManager.GetString("Quantity") & ": " & FormatNumber(Me.txtQTTY.Text, 0) & " | " & mv_ResourceManager.GetString("Price") & ": " & CDbl(AmendmentPrice)
                'End If
                'lblLine3.Text = BOrS & " | " & Symbol & " | Quantity: " & FormatNumber(Me.txtQTTY.Text, 0) & " | Price: " & CDbl(AmendmentPrice) / CDbl(Me.TradeUnit)
                If Not InStr("LO|SO>|IO|SO<", PriceType) > 0 Then
                    lblLine3.Text = BOrS & " | " & Symbol & " | " & mv_ResourceManager.GetString("Quantity") & ": " & FormatNumber(Me.txtQTTY.Text, 0) & " | " & mv_ResourceManager.GetString("Price") & ": " & PriceType
                Else
                    lblLine3.Text = BOrS & " | " & Symbol & " | " & mv_ResourceManager.GetString("Quantity") & ": " & FormatNumber(Me.txtQTTY.Text, 0) & " | " & mv_ResourceManager.GetString("Price") & ": " & CDbl(AmendmentPrice)
                End If

            End If
            'If CInt(Me.txtQTTY.Text) > CInt(Quantity) Then
            '    MessageBox.Show(mv_ResourceManager.GetString("AdjustQttyOverOrgQtty"))
            '    Me.txtQTTY.Focus()
            'End If
        Else
            'If CInt(Me.txtQTTY.Text) > CInt(Quantity) Then
            '    MessageBox.Show(mv_ResourceManager.GetString("AdjustQttyOverOrgQtty"))
            '    Me.txtQTTY.Focus()
            'End If
        End If
    End Sub

    Private Sub txtQTTY_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQTTY.KeyPress
        If IsNumeric(Me.txtQTTY.Text) And InStr(gc_OD_AMENDMENTBUYORDER & "/" & gc_OD_AMENDMENTSELLORDER, TLTXCD) > 0 And NoSubmit > 0 Then
            'lblLine3.Text = BOrS & " | " & Symbol & " | Quantity: " & FormatNumber(Me.txtQTTY.Text, 0) & " | Price: " & CDbl(AmendmentPrice) / CDbl(Me.TradeUnit)
            If PriceType <> "LO" Then
                lblLine3.Text = BOrS & " | " & Symbol & " | " & mv_ResourceManager.GetString("Quantity") & ": " & FormatNumber(Me.txtQTTY.Text, 0) & " | " & mv_ResourceManager.GetString("Price") & ": " & PriceType
            Else
                lblLine3.Text = BOrS & " | " & Symbol & " | " & mv_ResourceManager.GetString("Quantity") & ": " & FormatNumber(Me.txtQTTY.Text, 0) & " | " & mv_ResourceManager.GetString("Price") & ": " & CDbl(AmendmentPrice) / CDbl(Me.TradeUnit)
            End If
        End If
    End Sub

    Private Sub txtQTTY_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtQTTY.KeyUp
        If IsNumeric(Me.txtQTTY.Text) And InStr(gc_OD_AMENDMENTBUYORDER & "/" & gc_OD_AMENDMENTSELLORDER, TLTXCD) > 0 And NoSubmit > 0 Then
            'lblLine3.Text = BOrS & " | " & Symbol & " | Quantity: " & FormatNumber(Me.txtQTTY.Text, 0) & " | Price: " & CDbl(AmendmentPrice) / CDbl(Me.TradeUnit)
            If PriceType <> "LO" Then
                lblLine3.Text = BOrS & " | " & Symbol & " | " & mv_ResourceManager.GetString("Quantity") & ": " & FormatNumber(Me.txtQTTY.Text, 0) & " | " & mv_ResourceManager.GetString("Price") & ": " & PriceType
            Else
                lblLine3.Text = BOrS & " | " & Symbol & " | " & mv_ResourceManager.GetString("Quantity") & ": " & FormatNumber(Me.txtQTTY.Text, 0) & " | " & mv_ResourceManager.GetString("Price") & ": " & CDbl(AmendmentPrice) / CDbl(Me.TradeUnit)
            End If
        End If
    End Sub

#End Region

#Region " Private methods"

    Private Function ReleaseOrder() As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_xmlDocument As New Xml.XmlDocument, v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
        Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode, v_intIndex As Long, i, v_intCount As Integer
        'Dim v_strFLDNAME As String, v_strFLDDEFNAME As String, v_strFLDVAL As String, v_strFLDVALUE As String, 
        Dim v_strTXDESC As String
        Dim v_attrFLDNAME As Xml.XmlAttribute, v_attrDATATYPE As Xml.XmlAttribute

        Dim v_strORGORDERID, v_strCODEID, v_strCIACCTNO, v_strSEACCTNO, v_strAFACCTNO, v_strSYMBOL, v_strBORS As String
        Dim v_dblREMAINQTTY, v_dblAVLCANCELAMT, v_dblPARVALUE, v_dblEXPRICE, v_dblEXQTTY, _
        v_dblCANCELQTTY, v_dblADJUSTQTTY, v_dblREJECTQTTY, v_dblMATCHAMT, v_dblSECUREDAMT, v_dblRLSSECURED, v_dblQUOTEPRICE, v_dblORDERQTTY, v_dblISMORTAGE As Double

        Try
            'Giáº£i toáº£ kÃ½ quá»¹ Ä‘á»‘i vá»›i cÃ¡c lá»‡nh khÃ´ng Ä‘Æ°á»£c khá»›p trong ngÃ y, chá»‰ quan tÃ¢m Ä‘áº¿n cÃ¡c lá»‡nh Ä‘Ã£ Ä‘Æ°á»£c Ä‘áº©y lÃªn há»‡ thá»‘ng giao dá»‹ch
            Dim v_strSQL As String = " SELECT MST.ORDERID ORGORDERID, MST.CODEID, CI.AFACCTNO CIACCTNO,CI.AFACCTNO || MST.CODEID SEACCTNO, CI.AFACCTNO AFACCTNO,MST.REMAINQTTY REMAINQTTY, " & ControlChars.CrLf _
                     & " (CASE WHEN MST.SECUREDAMT - MST.MATCHAMT - MST.RLSSECURED > 0 THEN MST.SECUREDAMT - MST.MATCHAMT - MST.RLSSECURED ELSE 0 END) AVLCANCELAMT,MST.ORDERQTTY,MST.QUOTEPRICE, " & ControlChars.CrLf _
                     & " MST.EXPRICE, MST.EXQTTY, MST.CANCELQTTY, MST.ADJUSTQTTY,MST.REJECTQTTY, MST.MATCHAMT, MST.SECUREDAMT, MST.RLSSECURED,CCY.PARVALUE,CCY.SYMBOL, " & ControlChars.CrLf _
                     & " (CASE WHEN EXECTYPE='NB' OR EXECTYPE='BC' THEN 'B' ELSE 'S' END) BORS, (CASE WHEN EXECTYPE='MS' THEN 1 ELSE 0 END) ISMORTAGE " & ControlChars.CrLf _
                     & " FROM (SELECT * FROM ODMAST WHERE ORDERID = '" & OrderID & "'" & ") MST, CIMAST CI, SBSECURITIES CCY " & ControlChars.CrLf _
                     & " WHERE MST.AFACCTNO = CI.AFACCTNO AND TRIM (MST.CODEID) = TRIM (CCY.CODEID) AND CCY.TRADEPLACE <> '003' " & ControlChars.CrLf

            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_strValue, v_strFLDNAME As String

            Dim v_strObjMsg As String = BuildXMLObjMsg(, Me.BranchId, , Me.TellerID, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_OD_ODMAST, gc_ActionInquiry, v_strSQL)
            v_lngErrCode = v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For k As Integer = 0 To v_nodeList.Count - 1
                For j As Integer = 0 To v_nodeList.Item(k).ChildNodes.Count - 1
                    With v_nodeList.Item(k).ChildNodes(j)
                        v_strValue = Trim(.InnerText.ToString)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "ORGORDERID"
                                v_strORGORDERID = v_strValue
                            Case "CODEID"
                                v_strCODEID = v_strValue
                            Case "CIACCTNO"
                                v_strCIACCTNO = v_strValue
                            Case "SEACCTNO"
                                v_strSEACCTNO = v_strValue
                            Case "AFACCTNO"
                                v_strAFACCTNO = v_strValue
                            Case "REMAINQTTY"
                                v_dblREMAINQTTY = CDbl(v_strValue)
                            Case "AVLCANCELAMT"
                                v_dblAVLCANCELAMT = CDbl(v_strValue)
                            Case "PARVALUE"
                                v_dblPARVALUE = CDbl(v_strValue)
                            Case "EXPRICE"
                                v_dblEXPRICE = CDbl(v_strValue)
                            Case "EXQTTY"
                                v_dblEXQTTY = CDbl(v_strValue)
                            Case "CANCELQTTY"
                                v_dblCANCELQTTY = CDbl(v_strValue)
                            Case "ADJUSTQTTY"
                                v_dblADJUSTQTTY = CDbl(v_strValue)
                            Case "REJECTQTTY"
                                v_dblREJECTQTTY = CDbl(v_strValue)
                            Case "MATCHAMT"
                                v_dblMATCHAMT = CDbl(v_strValue)
                            Case "SECUREDAMT"
                                v_dblSECUREDAMT = CDbl(v_strValue)
                            Case "RLSSECURED"
                                v_dblRLSSECURED = CDbl(v_strValue)
                            Case "SYMBOL"
                                v_strSYMBOL = v_strValue
                            Case "BORS"
                                v_strBORS = v_strValue
                            Case "QUOTEPRICE"
                                v_dblQUOTEPRICE = CDbl(v_strValue)
                            Case "ORDERQTTY"
                                v_dblORDERQTTY = CDbl(v_strValue)
                            Case "ISMORTAGE"
                                v_dblISMORTAGE = CDbl(v_strValue)
                        End Select
                    End With
                Next
            Next

            Dim v_ds As New DataSet
            Dim v_strTxMsg As String
            Dim v_strErrorMessage, v_strErrorSource As String

            If v_strBORS = "B" Then
                BuildTransDS(v_ds, String.Empty, OD_RELEASE_BUY_ORDER)  'Tao cau truc cho dataset
                v_strTxMsg = BuildXMLTxMsg(gc_MsgTypeTrans, gc_IsLocalMsg, OD_RELEASE_BUY_ORDER, Me.BranchId, _
                                    Me.TellerID, Me.IpAddress, Me.WsName, , , , , , , , , , , , , , , , , Me.BusDate)
                v_strTXDESC = "Release secured deposit buy order (in day)"
            ElseIf v_strBORS = "S" Then
                BuildTransDS(v_ds, String.Empty, OD_RELEASE_SELL_ORDER)  'Tao cau truc cho dataset
                v_strTxMsg = BuildXMLTxMsg(gc_MsgTypeTrans, gc_IsLocalMsg, OD_RELEASE_SELL_ORDER, Me.BranchId, _
                                   Me.TellerID, Me.IpAddress, Me.WsName, , , , , , , , , , , , , , , , , Me.BusDate)
                v_strTXDESC = "Release secured deposit sell order (in day)"
            End If

            Dim v_dr As DataRow = v_ds.Tables(0).NewRow()
            For Each v_dc As DataColumn In v_ds.Tables(0).Columns
                Select Case v_dc.ColumnName
                    Case "03" 'ORGORDERID
                        v_dr(v_dc.ColumnName) = v_strORGORDERID
                    Case "80" 'CODEID
                        v_dr(v_dc.ColumnName) = v_strCODEID
                    Case "05" 'CIACCTNO
                        v_dr(v_dc.ColumnName) = v_strCIACCTNO
                    Case "06" 'SEACCTNO
                        v_dr(v_dc.ColumnName) = v_strSEACCTNO
                    Case "07" 'AFACCTNO
                        v_dr(v_dc.ColumnName) = v_strAFACCTNO
                    Case "10" 'REMAINQTTY
                        v_dr(v_dc.ColumnName) = v_dblREMAINQTTY
                    Case "11" 'AVLCANCELAMT
                        v_dr(v_dc.ColumnName) = v_dblAVLCANCELAMT
                    Case "12" 'PARVALUE
                        v_dr(v_dc.ColumnName) = v_dblPARVALUE
                    Case "13" 'EXPRICE
                        v_dr(v_dc.ColumnName) = v_dblEXPRICE
                    Case "14" 'EXQTTY
                        v_dr(v_dc.ColumnName) = v_dblEXQTTY
                    Case "15" 'CANCELQTTY
                        v_dr(v_dc.ColumnName) = v_dblCANCELQTTY
                    Case "16" 'ADJUSTQTTY
                        v_dr(v_dc.ColumnName) = v_dblADJUSTQTTY
                    Case "17" 'REJECTQTTY
                        v_dr(v_dc.ColumnName) = v_dblREJECTQTTY
                    Case "18" 'MATCHAMT
                        v_dr(v_dc.ColumnName) = v_dblMATCHAMT
                    Case "19" 'SECUREDAMT
                        v_dr(v_dc.ColumnName) = v_dblSECUREDAMT
                    Case "20" 'RLSSECURED
                        v_dr(v_dc.ColumnName) = v_dblRLSSECURED
                    Case "60" 'RLSSECURED
                        v_dr(v_dc.ColumnName) = v_dblISMORTAGE
                    Case "30" 'DESC                                              
                        v_dr(v_dc.ColumnName) = v_strTXDESC & ": " & v_strORGORDERID & ". " & CStr(v_dblORDERQTTY) & "." & v_strSYMBOL & "X" & CStr(v_dblQUOTEPRICE)
                End Select
            Next
            v_ds.Tables(0).Rows.Add(v_dr)

            BuildXmlTransData(v_strTxMsg, v_ds)
            v_lngErrCode = v_ws.Message(v_strTxMsg)
            'v_lngErrCode = v_ws.Message(v_strTxMsg)

            If v_lngErrCode <> ERR_SYSTEM_OK Then
                GetErrorFromMessage(v_strTxMsg, v_strErrorSource, v_lngErrCode, v_strErrorMessage, Me.UserLanguage)
                Cursor.Current = Cursors.Default
                MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                Exit Function
            Else
                MessageBox.Show(mv_ResourceManager.GetString("RefusedSuccessful"))
            End If
            Return v_lngErrCode

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function

    Public Function BuildTransDS(ByRef pv_ds As DataSet, ByVal pv_tableName As String, _
                                      ByVal pv_objName As String, Optional ByVal pv_listFldName As String = "") As Long
        Try

            Dim v_lngErrCode As Long = ERR_SYSTEM_OK
            Dim v_strErrorSource As String = String.Empty
            Dim v_strErrorMessage As String = String.Empty

            Dim v_strCmdInquiry As String = "SELECT FLDNAME,DATATYPE FROM FLDMASTER WHERE OBJNAME='" & pv_objName & "'" & pv_listFldName
            Dim v_strObjMsg As String = BuildXMLObjMsg(, Me.BranchId, , Me.TellerID, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_SEARCHFLD, gc_ActionInquiry, v_strCmdInquiry, , )
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery

            v_lngErrCode = v_ws.Message(v_strObjMsg)

            If v_lngErrCode <> ERR_SYSTEM_OK Then
                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrCode, v_strErrorMessage, Me.UserLanguage)
                GetReasonFromMessage(v_strObjMsg, v_strErrorMessage, Me.UserLanguage)
            End If

            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strFLDNAME, v_strValue As String
            Dim pv_strObjMsg As String = v_strObjMsg
            Dim v_arrFldNames(), v_arrFldTypes() As String
            Dim v_int As Integer
            v_int = 0
            v_xmlDocument.LoadXml(pv_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            ReDim v_arrFldNames(v_nodeList.Count - 1)
            ReDim v_arrFldTypes(v_nodeList.Count - 1)

            For i As Integer = 0 To v_nodeList.Count - 1
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strValue = .InnerText.ToString.Trim
                        Select Case CStr(v_strFLDNAME).Trim
                            Case "FLDNAME"
                                v_arrFldNames(v_int) = Trim(v_strValue)
                            Case "DATATYPE"
                                v_arrFldTypes(v_int) = Trim(v_strValue)
                        End Select
                    End With
                Next
                v_int += 1
            Next
            Dim v_dc As DataColumn
            If Not (pv_ds Is Nothing) Then
                pv_ds.Dispose()
            End If

            pv_ds = New DataSet("INPUT")
            pv_ds.Tables.Add(pv_tableName)

            For i As Integer = 0 To v_arrFldNames.Length - 1
                v_dc = New DataColumn(v_arrFldNames(i).ToString)
                Select Case v_arrFldTypes(i).ToString
                    Case "C"
                        v_dc.DataType = GetType(String)
                    Case "D"
                        v_dc.DataType = GetType(System.DateTime)
                    Case "N"
                        v_dc.DataType = GetType(Double)
                    Case Else
                        v_dc.DataType = GetType(String)
                End Select
                pv_ds.Tables(0).Columns.Add(v_dc)
            Next
            Return v_lngErrCode
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function BuildXmlTransData(ByRef pv_strTxMsg As String, ByVal pv_ds As DataSet) As Boolean
        Try
            Dim v_xmlDocument As New Xml.XmlDocument, v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
            Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode, v_intIndex As Long, i, v_intCount As Integer
            Dim v_strFLDNAME As String, v_strFLDDEFNAME As String, v_strDATATYPE As String, v_strFLDVALUE As String
            Dim v_attrFLDNAME As Xml.XmlAttribute, v_attrDATATYPE As Xml.XmlAttribute
            '
            v_xmlDocument.LoadXml(pv_strTxMsg)
            v_dataElement = v_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "fields", "")

            'Dua vao dataset
            Dim v_dr As DataRow
            Dim v_dc As DataColumn

            'Tao mot dong duy nhat
            v_dr = pv_ds.Tables(0).Rows(0) 'Lay dong dau tien

            If v_dr Is Nothing Then
                Return False
            End If

            For Each v_dc In pv_ds.Tables(0).Columns
                v_strFLDNAME = v_dc.ColumnName

                Select Case CStr(v_dc.DataType.ToString)
                    Case "System.String"
                        v_strDATATYPE = "C"
                    Case "System.DateTime"
                        v_strDATATYPE = "D"
                    Case Else
                        v_strDATATYPE = "N"
                End Select

                v_strFLDVALUE = v_dr(v_strFLDNAME).ToString
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
            Next
            pv_strTxMsg = v_xmlDocument.InnerXml
            Return True
        Catch ex As Exception
            Throw ex
        End Try
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

    Private Sub OnSendClick()
        'Check before send
        If InStr(gc_OD_CANCELBUYORDER & "/" & gc_OD_CANCELSELLORDER & "/" & gc_OD_AMENDMENTBUYORDER & "/" & gc_OD_AMENDMENTSELLORDER, TLTXCD) > 0 Then
            'If CDbl(txtQTTY.Text) Mod CDbl(TradeLot) > 0 Then
            '    MessageBox.Show(mv_ResourceManager.GetString("Invalidtradelot"))
            '    Exit Sub
            'End If
            If NoSubmit > 0 Then
                ''Bo kiem tra vi san HNX co kha nang sua khoi luong > khoi luong dat
                'If CInt(Me.txtQTTY.Text) > CInt(Quantity) - CInt(MatchedQtty) Then
                '    MessageBox.Show(mv_ResourceManager.GetString("Invalidadjustquantity"))
                '    Me.txtQTTY.Focus()
                '    Exit Sub
                'End If
            End If
            If IsNumeric(ExecQtty) Then
                If CDbl(txtQTTY.Text) < CDbl(ExecQtty) And NoSubmit = 0 Then
                    MessageBox.Show(mv_ResourceManager.GetString("Invalidmatchedquantity"))
                    Exit Sub
                End If
            End If
            If (CInt(Me.txtQTTY.Text) < 0) And NoSubmit > 0 Then
                'If (CInt(Me.txtQTTY.Text) > CInt(Quantity) Or CInt(Me.txtQTTY.Text) < 0) And NoSubmit > 0 Then

                MessageBox.Show(mv_ResourceManager.GetString("AdjustQttyOverOrgQtty"))
                Me.txtQTTY.Focus()
                Exit Sub
            End If
        End If

        'Send Execution
        If InStr(gc_OD_CANCELBUYORDER & "/" & gc_OD_CANCELSELLORDER, TLTXCD) > 0 Then
            OnCancelOrder()
        ElseIf InStr(gc_OD_AMENDMENTBUYORDER & "/" & gc_OD_AMENDMENTSELLORDER, TLTXCD) > 0 Then
            OnAmendmentOrder()
        Else
            OnSent()
        End If
    End Sub

    Private Sub OnClose()
        Me.Dispose()
    End Sub
    Private Function GetOrderID() As String
        Dim v_strClause, v_strAutoID As String
        Dim v_int, v_intCount As Integer
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strFLDNAME, v_strVALUE As String
        'Láº¥y ra sá»‘ tá»± tÄƒng
        v_strClause = "SEQ_ODMAST"
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_wsBDS As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerID, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_strClause, "GetInventory")
        v_wsBDS.Message(v_strObjMsg)
        v_xmlDocument.LoadXml(v_strObjMsg)
        v_strAutoID = v_xmlDocument.DocumentElement.Attributes("CLAUSE").Value
        'Táº¡o sá»‘ hiá»‡u lá»‡nh = MÃ£ chi nhÃ¡nh + NgÃ y há»‡ thá»‘ng + Sá»‘ tá»± tÄƒng
        Dim v_strOrderID As String
        v_strOrderID = Me.BranchId & Mid(Replace(Me.BusDate, "/", vbNullString), 1, 4) & Mid(Replace(Me.BusDate, "/", vbNullString), 7, 2) & Strings.Right(gc_FORMAT_ODAUTOID & CStr(v_strAutoID), Len(gc_FORMAT_ODAUTOID))
        Return v_strOrderID
    End Function

    Private Sub OnView()
        Try

            If InStr(BOrS, "S") > 0 Then
                lblLine1.ForeColor = System.Drawing.Color.Red
                lblLine2.ForeColor = System.Drawing.Color.Red
                lblLine3.ForeColor = System.Drawing.Color.Red
                lblLine4.ForeColor = System.Drawing.Color.Red
                lblLine5.ForeColor = System.Drawing.Color.Red
                lblLine6.ForeColor = System.Drawing.Color.Red
                lblLine7.ForeColor = System.Drawing.Color.Red
                lblLine8.ForeColor = System.Drawing.Color.Blue
                lblQTTY.ForeColor = System.Drawing.Color.Blue
                lblPRICE.ForeColor = System.Drawing.Color.Blue
            Else
                lblLine1.ForeColor = System.Drawing.Color.Blue
                lblLine2.ForeColor = System.Drawing.Color.Blue
                lblLine3.ForeColor = System.Drawing.Color.Blue
                lblLine4.ForeColor = System.Drawing.Color.Blue
                lblLine5.ForeColor = System.Drawing.Color.Blue
                lblLine6.ForeColor = System.Drawing.Color.Blue
                lblLine7.ForeColor = System.Drawing.Color.Blue
                lblLine8.ForeColor = System.Drawing.Color.Indigo
                lblQTTY.ForeColor = System.Drawing.Color.Indigo
                lblPRICE.ForeColor = System.Drawing.Color.Indigo
            End If
            Me.ActiveControl = Me.lblLine1
            Dim v_strPrice As String

            If InStr(BOrS, "P") > 0 Then
                v_strPrice = FormatNumber(Price, 6)
            Else
                v_strPrice = FormatNumber(Price, 6)
            End If
            If PriceType <> "LO" Then
                If InStr(gc_OD_CANCELBUYORDER & "/" & gc_OD_CANCELSELLORDER & "/" & gc_OD_AMENDMENTBUYORDER & "/" & gc_OD_AMENDMENTSELLORDER, TLTXCD) > 0 Then
                Else
                    v_strPrice = PriceType
                End If
            End If

            lblLine8.Text = String.Empty
            lblQTTY.Text = String.Empty
            lblPRICE.Text = String.Empty
            txtQTTY.Visible = False
            txtPRICE.Visible = False
            txtExe.Visible = False
            lblExe.Visible = False

            If InStr("8882/8883", TLTXCD) > 0 Then
                txtQTTY.Visible = True
                lblLine8.Text = mv_ResourceManager.GetString("Cancel")
                lblLine8.TextAlign = ContentAlignment.MiddleCenter
                lblQTTY.Text = mv_ResourceManager.GetString("Matched")
                txtQTTY.Text = "0"
                Me.ActiveControl = txtQTTY
                Me.Select()
                If InStr("8884/8885", TLTXCD) > 0 Then
                    txtPRICE.Visible = True
                    lblPRICE.Text = mv_ResourceManager.GetString("Price")
                    txtPRICE.Text = v_strPrice
                End If
            ElseIf InStr("8884/8885", TLTXCD) > 0 Then
                txtQTTY.Visible = True
                If Me.OrderStatus = "8" Then
                    'lblLine8.Text = "Amend(Not Send)"
                    lblLine8.Text = ""
                    txtQTTY.Enabled = False
                Else
                    lblLine8.Text = mv_ResourceManager.GetString("Amend")
                    txtQTTY.Enabled = True
                End If
                lblLine8.TextAlign = ContentAlignment.MiddleCenter
                lblQTTY.Text = mv_ResourceManager.GetString("Matched")
                txtQTTY.Text = "0"
                lblPRICE.Text = mv_ResourceManager.GetString("Price")
                txtPRICE.Text = Me.AmendmentPrice
                Me.ActiveControl = txtQTTY
                Me.Select()
                txtPRICE.Visible = True
                txtPRICE.Enabled = False
                'txtExe.Visible = True
                txtExe.Enabled = False
                txtExe.Text = ExecQtty
                'lblExe.Visible = True
                lblExe.Text = mv_ResourceManager.GetString("Executed")
            End If
            If Me.OrderStatus = "8" And InStr("8884/8885", TLTXCD) > 0 Then
                txtPRICE.Visible = False
                txtQTTY.Visible = False
                lblQTTY.Visible = False
                lblPRICE.Visible = False
            End If
            'If (Me.PriceType = "MP" Or Me.PriceType = "ATO" Or Me.PriceType = "MO") And Me.OrderStatus <> OD_ORSTATUS_COMPLETE Then
            '    btnRefuse.Enabled = True
            'Else
            '    btnRefuse.Enabled = False
            'End If
            If InStr(gc_OD_CANCELBUYORDER & "/" & gc_OD_CANCELSELLORDER & "/" & gc_OD_AMENDMENTBUYORDER & "/" & gc_OD_AMENDMENTSELLORDER, TLTXCD) <= 0 And Me.OrderStatus <> OD_ORSTATUS_COMPLETE Then
                btnRefuse.Enabled = True
            Else
                btnRefuse.Enabled = False
            End If
            'Neu lenh bi sua da send thi cho phep refuse
            lblLine8.Text = lblLine8.Text & IIf(Me.MapOrder.Trim = "", Me.MapOrder.Trim, " : " & Me.MapOrder.Trim)
            lblLine1.Text = mv_ResourceManager.GetString("CustomerName") & CustomerFullName

            If InStr(gc_OD_AMENDMENTBUYORDER & "/" & gc_OD_AMENDMENTSELLORDER, TLTXCD) > 0 And NoSubmit = 0 And Me.OrderStatus <> "8" Then
                If PriceType <> "LO" Then
                    lblLine2.Text = mv_ResourceManager.GetString("AMENDS") & " (" & mv_ResourceManager.GetString("Quantity") & ": " & FormatNumber(AmendmentQtty, 0) & " | " & mv_ResourceManager.GetString("Price") & ": " & PriceType & ")"
                Else
                    If InStr(BOrS, "P") > 0 Then
                        lblLine2.Text = mv_ResourceManager.GetString("AMENDS") & " (" & mv_ResourceManager.GetString("Quantity") & ": " & FormatNumber(AmendmentQtty, 0) & " | " & mv_ResourceManager.GetString("Price") & ": " & CStr(CDbl(AmendmentPrice)) & ")"
                    Else
                        lblLine2.Text = mv_ResourceManager.GetString("AMENDS") & " (" & mv_ResourceManager.GetString("Quantity") & ": " & FormatNumber(AmendmentQtty, 0) & " | " & mv_ResourceManager.GetString("Price") & ": " & CStr(CDbl(AmendmentPrice) / CDbl(TradeUnit)) & ")"
                    End If

                End If
            Else
                lblLine2.Text = String.Empty
            End If
            If Me.OrderStatus = "8" And InStr(gc_OD_CANCELBUYORDER & "/" & gc_OD_CANCELSELLORDER & "/" & gc_OD_AMENDMENTBUYORDER & "/" & gc_OD_AMENDMENTSELLORDER, TLTXCD) > 0 Then
                If PriceType <> "LO" Then
                    lblLine3.Text = BOrS & " | " & Symbol & " | " & mv_ResourceManager.GetString("Quantity") & ": " & FormatNumber(AmendmentQtty, 0) & " | " & mv_ResourceManager.GetString("Price") & ": " & PriceType
                Else
                    If InStr(BOrS, "P") > 0 Then
                        lblLine3.Text = BOrS & " | " & Symbol & " | " & mv_ResourceManager.GetString("Quantity") & ": " & FormatNumber(AmendmentQtty, 0) & " | " & mv_ResourceManager.GetString("Price") & ": " & CStr(CDbl(AmendmentPrice))
                    Else
                        lblLine3.Text = BOrS & " | " & Symbol & " | " & mv_ResourceManager.GetString("Quantity") & ": " & FormatNumber(AmendmentQtty, 0) & " | " & mv_ResourceManager.GetString("Price") & ": " & CStr(CDbl(AmendmentPrice) / CDbl(TradeUnit))
                    End If

                End If
            Else
                If Me.OrderStatus = "4" Then
                    If InStr(BOrS, "P") > 0 Then
                        lblLine3.Text = BOrS & " | " & Symbol & " | " & mv_ResourceManager.GetString("QuantityPending") & ": " & FormatNumber(Quantity, 0) & " | " & mv_ResourceManager.GetString("Price") & ": " & Me.AmendmentPrice
                    Else
                        If IsNumeric(v_strPrice) Then
                            lblLine3.Text = BOrS & " | " & Symbol & " | " & mv_ResourceManager.GetString("QuantityPending") & ": " & FormatNumber(Quantity, 0) & " | " & mv_ResourceManager.GetString("Price") & ": " & CStr(CDbl(v_strPrice) * CDbl(TradeUnit))
                        Else 'ATO, ATC,...
                            lblLine3.Text = BOrS & " | " & Symbol & " | " & mv_ResourceManager.GetString("QuantityPending") & ": " & FormatNumber(Quantity, 0) & " | " & mv_ResourceManager.GetString("Price") & ": " & v_strPrice
                        End If
                    End If
                    'Tantv 

                    'end Tantv
                    'lblLine3.Text = BOrS & " | " & Symbol & " | " & mv_ResourceManager.GetString("QuantityPending") & ": " & FormatNumber(Quantity - ExecQtty, 0) & " | " & mv_ResourceManager.GetString("Price") & ": " & v_strPrice
                Else
                    If InStr(BOrS, "P") > 0 Then
                        'lblLine3.Text = OrderID & " | " & BOrS & " | " & Symbol & " | " & mv_ResourceManager.GetString("Quantity") & ": " & FormatNumber(Quantity, 0) & " | " & mv_ResourceManager.GetString("Price") & ": " & Me.AmendmentPrice
                        lblLine3.Text = BOrS & " | " & Symbol & " | " & mv_ResourceManager.GetString("Quantity") & ": " & FormatNumber(Quantity, 0) & " | " & mv_ResourceManager.GetString("Price") & ": " & FormatNumber(Me.AmendmentPrice, 0)
                    Else
                        If IsNumeric(v_strPrice) Then
                            'lblLine3.Text = OrderID & " | " & BOrS & " | " & Symbol & " | " & mv_ResourceManager.GetString("Quantity") & ": " & FormatNumber(Quantity, 0) & " | " & mv_ResourceManager.GetString("Price") & ": " & CStr(CDbl(v_strPrice) * CDbl(TradeUnit))
                            lblLine3.Text = PriceType & " | " & BOrS & " | " & Symbol & " | " & mv_ResourceManager.GetString("Quantity") & ": " & FormatNumber(Quantity, 0) & " | " & mv_ResourceManager.GetString("Price") & ": " & FormatNumber(CStr(CDbl(v_strPrice) * CDbl(TradeUnit)), 0)
                        ElseIf InStr(1, "SO>SO<IO", PriceType) <> 0 Then
                            lblLine3.Text = v_strPrice & " | " & BOrS & " | " & Symbol & " | " & mv_ResourceManager.GetString("Quantity") & ": " & FormatNumber(Quantity, 0) & " | " & mv_ResourceManager.GetString("Price") & ": " & FormatNumber(Me.AmendmentPrice, 0)
                        Else 'ATO, ATC,...
                            'lblLine3.Text = BOrS & " | " & Symbol & " | " & mv_ResourceManager.GetString("Quantity") & ": " & FormatNumber(Quantity, 0) & " | " & mv_ResourceManager.GetString("Price") & ": " & v_strPrice
                            'chaunh
                            ' lblLine3.Text = OrderID & " | " & v_strPrice & " | " & BOrS & " | " & Symbol & " | " & mv_ResourceManager.GetString("Quantity") & ": " & FormatNumber(Quantity, 0) & " | " & mv_ResourceManager.GetString("Price") & ": " & Price
                            ' lblLine3.Text = v_strPrice & " | " & BOrS & " | " & Symbol & " | " & mv_ResourceManager.GetString("Quantity") & ": " & FormatNumber(Quantity, 0) & " | " & mv_ResourceManager.GetString("Price") & ": " & Price
                            lblLine3.Text = v_strPrice & " | " & BOrS & " | " & Symbol & " | " & mv_ResourceManager.GetString("Quantity") & ": " & FormatNumber(Quantity, 0)
                        End If

                    End If

                End If

            End If
            lblLine4.Text = "( " & Symbol & " ) " & Issuer




            lblLine5.Text = mv_ResourceManager.GetString("CustodyCode") & Strings.Left(CustodyCode, 4) & "." & Strings.Mid(CustodyCode, 5, 3) & "." & Strings.Right(CustodyCode, 3)
            If InStr(BOrS, "P") > 0 Then
                lblLine6.Text = TxDesc
            Else
                lblLine6.Text = String.Empty
            End If

            If ClearDays.Length > 0 Then
                lblLine7.Text = mv_ResourceManager.GetString("SettlementCycle") & ClearDays
            Else
                lblLine7.Text = String.Empty
            End If
            If InStr(gc_OD_AMENDMENTBUYORDER & "/" & gc_OD_AMENDMENTSELLORDER, TLTXCD) > 0 And NoSubmit = 0 And Me.OrderStatus <> "8" Then
                lblLine7.Text = mv_ResourceManager.GetString("OriginalOrder")
            End If
            btnRefuse.Enabled = False
            btnRefuse.Visible = False
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub OnLock()
        Dim v_strFilter As String
        Dim v_strFLDNAME, v_strValue As String
        Dim v_strFieldType, v_strDataType As String
        Dim v_ctrl As Windows.Forms.Control

        Try
            Dim v_strCmdInquiry As String

            'v_strCmdInquiry = "UPDATE OOD SET OODSTATUS = 'B', TLIDSENT='" & TellerID & "' WHERE ORGORDERID = '" & OrderID & "'"
            'Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerID, "N", gc_MsgTypeObj, OBJNAME_OD_OOD, gc_ActionAdhoc, v_strCmdInquiry, OrderID)

            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerID, "N", gc_MsgTypeObj, OBJNAME_OD_OOD, gc_ActionAdhoc, v_strCmdInquiry, OrderID, "OnLock")
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            v_ws.Message(v_strObjMsg)

            'Kiá»ƒm tra thÃ´ng tin vÃ  xá»­ lÃ½ lá»—i (náº¿u cÃ³) tá»« message tráº£ v?
            Dim v_strErrorSource, v_strErrorMessage As String
            Dim v_lngErrorCode As Long

            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
            If v_lngErrorCode <> 0 Then
                'Update mouse pointer
                Cursor.Current = Cursors.Default
                MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                Exit Sub
            End If

            'MsgBox(ResourceManager.GetString("SentSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
            'Me.DialogResult = DialogResult.OK
            'MyBase.OnClose()

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub OnRefuseCorrect()
        Dim v_strFilter As String
        Dim v_strFLDNAME, v_strValue As String
        Dim v_strFieldType, v_strDataType As String
        Dim v_ctrl As Windows.Forms.Control
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_strErrorSource, v_strErrorMessage As String
        Dim v_lngErrorCode As Long

        Try
            Cursor.Current = Cursors.WaitCursor
            Dim v_strClause As String
            v_strClause = Me.OrderID
            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerID, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_strClause, "RefuseCorrectionOrder", , , , IpAddress)
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            v_lngErrorCode = v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)

            'KiÃ¡Â»Æ’m tra thÃƒÂ´ng tin vÃƒÂ  xÃ¡Â»Â­ lÃƒÂ½ lÃ¡Â»â€”i (nÃ¡ÂºÂ¿u cÃƒÂ³) tÃ¡Â»Â« message trÃ¡ÂºÂ£ vÃ¡Â»?            
            If v_lngErrorCode <> ERR_SYSTEM_OK Then
                'ThÃƒÂ´ng bÃƒÂ¡o lÃ¡Â»â€”i
                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                Cursor.Current = Cursors.Default
                MsgBox(v_strErrorMessage, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, Me.Text)
                Exit Sub
            End If
            mv_isSEND = True
            Cursor.Current = Cursors.Default
            Me.OnClose()

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub OnInsertODQUEUE(ByVal pv_strORGORDERID As String)
        Dim v_strFilter As String
        Dim v_strFLDNAME, v_strValue As String
        Dim v_strFieldType, v_strDataType As String
        Dim v_ctrl As Windows.Forms.Control

        Try
            Dim v_strCmdInquiry As String
            'v_strCmdInquiry = "INSERT INTO ODQUEUE SELECT * FROM OOD WHERE TRIM(ORGORDERID) = '" & pv_strORGORDERID & "'"
            'Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerID, "N", gc_MsgTypeObj, OBJNAME_OD_OOD, gc_ActionAdhoc, v_strCmdInquiry)
            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerID, "N", gc_MsgTypeObj, OBJNAME_OD_OOD, gc_ActionAdhoc, v_strCmdInquiry, pv_strORGORDERID, "OnInsertODQUEUE")
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            v_ws.Message(v_strObjMsg)

            'Kiá»ƒm tra thÃ´ng tin vÃ  xá»­ lÃ½ lá»—i (náº¿u cÃ³) tá»« message tráº£ v?
            Dim v_strErrorSource, v_strErrorMessage As String
            Dim v_lngErrorCode As Long

            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
            If v_lngErrorCode <> 0 Then
                'Update mouse pointer
                Cursor.Current = Cursors.Default
                MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                Exit Sub
            End If

            'MsgBox(ResourceManager.GetString("SentSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
            'Me.DialogResult = DialogResult.OK
            'MyBase.OnClose()

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub
    Private Sub OnDeleteODQUEUE()
        Dim v_strFilter As String
        Dim v_strFLDNAME, v_strValue As String
        Dim v_strFieldType, v_strDataType As String
        Dim v_ctrl As Windows.Forms.Control

        Try
            Dim v_strCmdInquiry As String
            'v_strCmdInquiry = "DELETE FROM ODQUEUE WHERE TRIM(ORGORDERID) = '" & OrderID & "'"
            'Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerID, "N", gc_MsgTypeObj, OBJNAME_OD_OOD, gc_ActionAdhoc, v_strCmdInquiry)
            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerID, "N", gc_MsgTypeObj, OBJNAME_OD_OOD, gc_ActionAdhoc, v_strCmdInquiry, OrderID, "OnDeleteODQUEUE")
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            v_ws.Message(v_strObjMsg)

            'Kiá»ƒm tra thÃ´ng tin vÃ  xá»­ lÃ½ lá»—i (náº¿u cÃ³) tá»« message tráº£ v?
            Dim v_strErrorSource, v_strErrorMessage As String
            Dim v_lngErrorCode As Long

            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
            If v_lngErrorCode <> 0 Then
                'Update mouse pointer
                Cursor.Current = Cursors.Default
                MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                Exit Sub
            End If

            'MsgBox(ResourceManager.GetString("SentSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
            'Me.DialogResult = DialogResult.OK
            'MyBase.OnClose()

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub
    Private Sub OnCancel()
        If InStr(gc_OD_CANCELBUYORDER & "/" & gc_OD_CANCELSELLORDER & "/" & gc_OD_AMENDMENTBUYORDER & "/" & gc_OD_AMENDMENTSELLORDER, TLTXCD) > 0 Then
            Me.IsEditOrder = True
            If Me.NoSubmit > 0 Then
                Me.NoSubmit = 0
                Me.lblQTTY.Text = mv_ResourceManager.GetString("Matched")
                Me.txtQTTY.Text = Me.MatchedQtty
                Me.txtQTTY.Enabled = True
                Me.btnSend.Enabled = True
                Me.btnSend.Text = mv_ResourceManager.GetString("Send")
                Me.btnCancel.Text = mv_ResourceManager.GetString("Exit")
                Me.ActiveControl = txtQTTY
                Me.btnRefuse.Enabled = False
                If Me.OrderStatus <> "8" Then
                    lblLine7.Text = mv_ResourceManager.GetString("OriginalOrder")
                End If
                Dim v_strPrice As String = FormatNumber(Price, 1)
                If PriceType <> "LO" Then
                    v_strPrice = PriceType
                End If
                If InStr(gc_OD_AMENDMENTBUYORDER & "/" & gc_OD_AMENDMENTSELLORDER, TLTXCD) > 0 And NoSubmit = 0 And Me.OrderStatus <> "8" Then
                    lblLine2.Text = mv_ResourceManager.GetString("AMENDS") & " (" & mv_ResourceManager.GetString("Quantity") & ": " & FormatNumber(AmendmentQtty, 0) & " | " & mv_ResourceManager.GetString("Price") & ": " & CStr(CDbl(AmendmentPrice) / CDbl(TradeUnit)) & ")"
                Else
                    lblLine2.Text = String.Empty
                End If
                If Me.OrderStatus = "8" And InStr(gc_OD_CANCELBUYORDER & "/" & gc_OD_CANCELSELLORDER & "/" & gc_OD_AMENDMENTBUYORDER & "/" & gc_OD_AMENDMENTSELLORDER, TLTXCD) > 0 Then
                    lblLine3.Text = BOrS & " | " & Symbol & " | " & mv_ResourceManager.GetString("Quantity") & ": " & FormatNumber(AmendmentQtty, 0) & " | " & mv_ResourceManager.GetString("Price") & ": " & CStr(CDbl(AmendmentPrice) / CDbl(TradeUnit))
                Else
                    lblLine3.Text = BOrS & " | " & Symbol & " | " & mv_ResourceManager.GetString("Quantity") & ": " & FormatNumber(Quantity, 0) & " | " & mv_ResourceManager.GetString("Price") & ": " & v_strPrice
                End If
                Exit Sub
            End If
        End If

        Dim v_strFilter, v_strClause As String
        Dim v_strFLDNAME, v_strValue As String
        Dim v_strFieldType, v_strDataType As String
        Dim v_ctrl As Windows.Forms.Control
        Dim v_strErrorSource, v_strErrorMessage As String
        Dim v_lngErrorCode As Long
        Try
            Dim v_strCmdInquiry As String
            v_strClause = Trim(OrderID)
            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerID, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_strClause, "CancelOrderSending", , , , IpAddress)
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            v_lngErrorCode = v_ws.Message(v_strObjMsg)
            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
            If v_lngErrorCode <> 0 Then
                'Update mouse pointer
                Cursor.Current = Cursors.Default
                MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                Exit Sub
            Else
                Me.Close()
            End If
            mv_intStep = 0
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub
    Private Sub OnCancelOrder()
        Me.IsEditOrder = True
        If Me.NoSubmit > 0 Then
            Me.CancelQtty = Me.txtQTTY.Text
            Me.AmendmentQtty = "0"
            Me.AmendmentPrice = Price
            OnApprove()
            If mv_isDeleteOK Then
                'OnSent()
                mv_isSEND = True
                Me.Dispose()
                mv_intStep = 0
                Me.NoSubmit = 0
                Me.btnRefuse.Enabled = True
            End If
        Else
            Me.NoSubmit = 1
            If Me.OrderStatus <> "8" Then
                Me.btnRefuse.Enabled = True
            Else
                Me.btnRefuse.Enabled = False
            End If
            Me.lblQTTY.Text = mv_ResourceManager.GetString("Cancel")
            Me.MatchedQtty = Me.txtQTTY.Text
            'If (CInt(Quantity) - CInt(MatchedQtty) + CInt(ExecQtty)) <= 0 Then
            If (CInt(Quantity) - CInt(MatchedQtty)) <= 0 Then
                Me.btnSend.Enabled = False
                Me.btnRefuse.Enabled = True
                btnRefuse.Enabled = True
                btnRefuse.Visible = True
                Me.ActiveControl = btnRefuse
            Else
                Me.btnSend.Enabled = True
                Me.btnRefuse.Enabled = False
                btnRefuse.Enabled = False
                btnRefuse.Visible = False
            End If
            Me.txtQTTY.Enabled = False
            'Me.txtQTTY.Text = (CInt(Quantity) - CInt(MatchedQtty) + CInt(ExecQtty)).ToString
            Me.txtQTTY.Text = (CInt(Quantity) - CInt(MatchedQtty)).ToString
            Me.btnSend.Text = mv_ResourceManager.GetString("Confirm")
            Me.btnCancel.Text = mv_ResourceManager.GetString("Back")
            Me.ActiveControl = txtQTTY
        End If
    End Sub

    Private Sub OnAmendmentOrder()
        Me.IsEditOrder = True
        If Me.OrderStatus = "8" Then
            '1 lan confirm voi lenh sua chua send
            Me.MatchedQtty = "0"
            Me.CancelQtty = "0"
            OnApprove()
            If mv_isDeleteOK Then
                'OnSent()
                mv_isSEND = True
                Me.Dispose()
                mv_intStep = 0
            End If
        Else
            '2 lan confirm voi lenh sua da send
            If Me.NoSubmit > 0 Then
                Me.CancelQtty = "0"
                Me.AmendmentQtty = Me.txtQTTY.Text
                OnApprove()
                If mv_isDeleteOK Then
                    'OnSent()
                    mv_isSEND = True
                    Me.Dispose()
                    mv_intStep = 0
                End If
                Me.NoSubmit = 0
            Else
                Me.NoSubmit = 1
                Me.lblQTTY.Text = mv_ResourceManager.GetString("Amendment")
                Me.MatchedQtty = Me.txtQTTY.Text

                If Me.OrderStatus <> "8" Then
                    Me.btnRefuse.Enabled = True
                Else
                    Me.btnRefuse.Enabled = False
                End If

                'If CInt(Me.AmendmentQtty) - CInt(MatchedQtty) + CInt(ExecQtty) > 0 Then
                If CInt(Me.AmendmentQtty) - CInt(MatchedQtty) > 0 Then
                    Me.txtQTTY.Text = CStr(CInt(Me.AmendmentQtty) - CInt(MatchedQtty)).ToString '+ CInt(ExecQtty)).ToString
                    Me.btnRefuse.Enabled = False
                    btnRefuse.Visible = False
                Else
                    Me.txtQTTY.Text = "0"
                    Me.btnSend.Enabled = False
                    btnRefuse.Enabled = True
                    btnRefuse.Visible = True
                    Me.ActiveControl = btnRefuse
                End If
                'lblLine3.Text = BOrS & " | " & Symbol & " | Quantity: " & FormatNumber(Me.txtQTTY.Text, 0) & " | Price: " & CDbl(AmendmentPrice) / CDbl(Me.TradeUnit)
                If PriceType <> "LO" Then
                    lblLine3.Text = BOrS & " | " & Symbol & " | " & mv_ResourceManager.GetString("Quantity") & ": " & FormatNumber(Me.txtQTTY.Text, 0) & " | " & mv_ResourceManager.GetString("Price") & ": " & PriceType
                Else
                    lblLine3.Text = BOrS & " | " & Symbol & " | " & mv_ResourceManager.GetString("Quantity") & ": " & FormatNumber(Me.txtQTTY.Text, 0) & " | " & mv_ResourceManager.GetString("Price") & ": " & CDbl(AmendmentPrice) / CDbl(Me.TradeUnit)
                End If
                If InStr(gc_OD_AMENDMENTBUYORDER & "/" & gc_OD_AMENDMENTSELLORDER, TLTXCD) > 0 And NoSubmit = 1 Then
                    lblLine7.Text = mv_ResourceManager.GetString("Amendmentorder")
                End If
                Me.btnSend.Text = mv_ResourceManager.GetString("Confirm")
                Me.btnCancel.Text = mv_ResourceManager.GetString("Back")
                'Me.ActiveControl = txtQTTY
                Me.txtQTTY.Enabled = False
            End If
        End If
    End Sub

    Private Sub OnUnLock()
        Dim v_strFilter As String
        Dim v_strFLDNAME, v_strValue As String
        Dim v_strFieldType, v_strDataType As String
        Dim v_ctrl As Windows.Forms.Control

        Try
            Dim v_strCmdInquiry As String

            'v_strCmdInquiry = "UPDATE OOD SET OODSTATUS = 'N', TLIDSENT='' WHERE ORGORDERID = '" & OrderID & "'"
            'Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerID, "N", gc_MsgTypeObj, OBJNAME_OD_OOD, gc_ActionAdhoc, v_strCmdInquiry)
            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerID, "N", gc_MsgTypeObj, OBJNAME_OD_OOD, gc_ActionAdhoc, v_strCmdInquiry, OrderID, "OnUnLock")
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            v_ws.Message(v_strObjMsg)

            'Kiá»ƒm tra thÃ´ng tin vÃ  xá»­ lÃ½ lá»—i (náº¿u cÃ³) tá»« message tráº£ v?
            Dim v_strErrorSource, v_strErrorMessage As String
            Dim v_lngErrorCode As Long

            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
            If v_lngErrorCode <> 0 Then
                'Update mouse pointer
                Cursor.Current = Cursors.Default
                MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                Exit Sub
            End If

            'MsgBox(ResourceManager.GetString("SentSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
            'Me.DialogResult = DialogResult.OK
            'MyBase.OnClose()
            mv_intStep = 1
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub
    Private Sub OnSent()
        Dim v_strFilter, v_strClause As String
        Dim v_strFLDNAME, v_strValue As String
        Dim v_strFieldType, v_strDataType As String
        Dim v_ctrl As Windows.Forms.Control
        Dim v_strErrorSource, v_strErrorMessage As String
        Dim v_lngErrorCode As Long

        Try
            Dim v_strCmdInquiry As String

            'v_strCmdInquiry = "UPDATE OOD SET OODSTATUS = 'S', TXTIME = TO_CHAR(SYSDATE,'HH:MI:SS'), TLIDSENT = '" & TellerID & "' WHERE ORGORDERID = '" & OrderID & "'"

            'Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerID, "N", gc_MsgTypeObj, OBJNAME_OD_OOD, gc_ActionAdhoc, v_strCmdInquiry)
            'Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            'v_ws.Message(v_strObjMsg)
            v_strClause = Trim(OrderID)
            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerID, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_strClause, "UpdateOrderStatus", , , , IpAddress)
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            v_lngErrorCode = v_ws.Message(v_strObjMsg)
            'v_xmlDocument.LoadXml(v_strObjMsg)

            'Kiï¿½á»ƒm tra thÃ´ng tin vÃ  xá»­ lÃ½ lá»—i (náº¿u cÃ³) tá»« message tráº£ v?
            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
            If v_lngErrorCode <> 0 Then
                'Update mouse pointer
                Cursor.Current = Cursors.Default
                MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                Exit Sub
            Else
                mv_isSEND = True
                Me.Dispose()
            End If

            'MsgBox(ResourceManager.GetString("SentSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
            'Me.DialogResult = DialogResult.OK
            'MyBase.OnClose()
            mv_intStep = 0
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub
    Private Sub OnApprove()
        Dim v_strErrorSource, v_strErrorMessage As String, v_strTxMsg As String
        Dim v_lngError As Long
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery

        Try
            If Not VerifyRules(v_strTxMsg) Then
                Exit Sub
            Else
                v_lngError = v_ws.Message(v_strTxMsg)
                If v_lngError <> ERR_SYSTEM_OK Then

                    GetErrorFromMessage(v_strTxMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                    Cursor.Current = Cursors.Default
                    If v_lngError <> ERR_SA_CHECKER1_OVR And v_lngError <> ERR_SA_CHECKER2_OVR Then
                        MessageBox.Show(v_strErrorMessage, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    Else

                        GetReasonFromMessage(v_strTxMsg, v_strErrorMessage, Me.UserLanguage)
                        MessageBox.Show(v_strErrorMessage, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End If
            End If
            mv_isDeleteOK = True
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Function VerifyRules(ByRef v_strTxMsg As String) As Long
        Try
            Dim v_xmlDocument As New Xml.XmlDocument, v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
            Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode, v_intIndex As Long, i, v_intCount As Integer
            Dim v_strFLDNAME As String, v_strFLDDEFNAME As String, v_strDATATYPE As String, v_strFLDVALUE As String
            Dim v_strERRMSG, v_strENERRMSG, v_strOPERATOR, v_strVALEXP, v_strVALEXP2 As String, v_strACTYPE, v_strDESC As String
            Dim v_dtVALEXP, v_dtVALEXP2, v_dtFLDVALUE As Date, v_strCMDSQL As String
            Dim v_ctl As Control, v_attrFLDNAME As Xml.XmlAttribute, v_attrDATATYPE As Xml.XmlAttribute, v_objEval As New Evaluator
            Dim v_strTLTXCD As String

            Select Case TLTXCD
                Case gc_OD_CANCELBUYORDER, gc_OD_AMENDMENTBUYORDER
                    v_strTLTXCD = gc_OD_APPROVE_EDITBUYORDER
                Case gc_OD_CANCELSELLORDER, gc_OD_AMENDMENTSELLORDER
                    v_strTLTXCD = gc_OD_APPROVE_EDITSELLORDER
                Case Else
                    Return False
            End Select
            LoadScreen(v_strTLTXCD)
            v_strTxMsg = BuildXMLTxMsg(gc_MsgTypeTrans, gc_IsLocalMsg, v_strTLTXCD, Me.BranchId, Me.TellerID, Me.IpAddress, Me.WsName, , , , , , , , , , , , , , , , , Me.BusDate)
            v_xmlDocument.LoadXml(v_strTxMsg)
            v_dataElement = v_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "fields", "")
            If mv_arrObjFields.GetLength(0) > 0 Then
                For v_intIndex = 0 To mv_arrObjFields.GetLength(0) - 1 Step 1
                    If Not mv_arrObjFields(v_intIndex) Is Nothing Then
                        v_strFLDNAME = mv_arrObjFields(v_intIndex).FieldName
                        v_strDATATYPE = mv_arrObjFields(v_intIndex).DataType
                        Select Case Trim(v_strFLDNAME)
                            Case "01" 'SYMBOL
                                v_strFLDVALUE = Symbol
                            Case "03" 'AFACCTNO
                                v_strFLDVALUE = AFAccount
                            Case "06" 'SEACCTNO
                                v_strFLDVALUE = SEAcctNo
                            Case "11" 'QUOTEPRICE
                                v_strFLDVALUE = Price
                            Case "12" 'ORDERQTTY
                                v_strFLDVALUE = Quantity
                            Case "13" 'BRATIO
                                v_strFLDVALUE = Bratio
                            Case "20" 'OldBratio
                                v_strFLDVALUE = OldBratio
                            Case "14" 'CANCELQTTY
                                v_strFLDVALUE = CancelQtty
                            Case "15" 'AMENDMENTQTTY
                                v_strFLDVALUE = AmendmentQtty
                            Case "16" 'AMENDMENTPRICE
                                v_strFLDVALUE = AmendmentPrice
                            Case "17" 'MATCHEDQTTY
                                v_strFLDVALUE = MatchedQtty
                            Case "07" 'SYMBOL
                                v_strFLDVALUE = Symbol
                            Case "18" 'AdvancedAmount= max((CDbl(txtQuantity.Text) * CDbl(txtQuotePrice.Text) - mv_dblPrice * mv_dblQtty),0) (For Adjust Order Only)
                                'If CDbl(OldAmendmentQtty) * CDbl(OldAmendmentPrice) - Price * Quantity * TradeUnit > 0 Then
                                '    v_strFLDVALUE = CDbl(OldAmendmentQtty) * CDbl(OldAmendmentPrice) - Price * Quantity * TradeUnit
                                'Else
                                '    v_strFLDVALUE = "0"
                                'End If
                                If TLTXCD = gc_OD_AMENDMENTBUYORDER And CDbl(OldAmendmentQtty) * CDbl(OldAmendmentPrice) * CDbl(Bratio) / 100 - Price * Quantity * TradeUnit * CDbl(OldBratio) / 100 > 0 Then
                                    v_strFLDVALUE = CDbl(OldAmendmentQtty) * CDbl(OldAmendmentPrice) * CDbl(Bratio) / 100 - Price * Quantity * TradeUnit * CDbl(OldBratio) / 100
                                Else
                                    v_strFLDVALUE = "0"
                                End If
                            Case "19" 'EXECQTTY
                                v_strFLDVALUE = ExecQtty
                            Case "04" 'ORDERID
                                v_strFLDVALUE = GetOrderID()
                            Case "08" 'REFORDERID
                                v_strFLDVALUE = RefOrderID
                            Case "98" 'TRADEUNIT
                                v_strFLDVALUE = TradeUnit
                            Case "99" 'HUNDRED           
                                v_strFLDVALUE = 100
                            Case "30" 'DESC
                                If TLTXCD = gc_OD_CANCELBUYORDER Or TLTXCD = gc_OD_CANCELSELLORDER Then
                                    v_strFLDVALUE = mv_ResourceManager.GetString("ApproveCancel") & "  " & OrderID & " " & FullName & " " & IIf(BOrS = "S" Or BOrS = "NS", "NS", "NB") & " " & Symbol & " " & Quantity & "X" & Price
                                Else
                                    v_strFLDVALUE = mv_ResourceManager.GetString("ApproveAmendment") & "  " & OrderID & " " & FullName & " " & IIf(BOrS = "S" Or BOrS = "NS", "NS", "NB") & " " & Symbol & " " & Quantity & "X" & Price
                                End If
                            Case "60" 'Is mortage
                                v_strFLDVALUE = IIf(Me.ExecType = "MS", "1", "0")
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

            CreateFeemap(v_xmlDocument)
            v_strTxMsg = v_xmlDocument.InnerXml
            Return True
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function
    'HÃ m nÃ y táº¡o láº¡i CreateFeemap trÃªn cÆ¡ sá»Ÿ tham sá»‘ Ä‘á»‹nh nghÄ©a trong báº£ng FEEMAP
    Private Function CreateFeemap(ByRef pv_xmlDocument As Xml.XmlDocument)
        Dim v_feeElement As Xml.XmlElement
        Dim v_entryNode As Xml.XmlNode
        Dim strTLTXCD, v_strFEECD, v_strGLACCTNO, v_strFORP, v_strAMTEXP, v_strVALEXP As String
        Dim v_dblTOTALFEEAMT, v_dblTOTALVATAMT, v_dblFLATAMT, v_dblFEEAMT, v_dblVATAMT, v_dblTXAMT, v_dblFEERATE, v_dblVATRATE, v_dblMINVAL, v_dblMAXVAL As Double

        'Láº¥y thÃ´ng tin chung v? giao dï¿½á»‹ch
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
            'Láº¥y dá»¯ liá»‡u
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
            'TÃ­nh toÃ¡n giÃ¡ trá»‹ phÃ­
            v_strVALEXP = BuildAMTEXP(v_strAMTEXP)
            v_dblTXAMT = v_objEval.Eval(v_strVALEXP)
            If v_strFORP = "F" Then
                'PhÃ­ cá»‘ Ä‘á»‹nh
                v_dblFEEAMT = v_dblFLATAMT
            Else
                'PhÃ­ theo tá»· lá»‡
                v_dblFEEAMT = v_dblFEERATE * v_dblTXAMT / 100
                If v_dblFEEAMT < v_dblMINVAL Then v_dblFEEAMT = v_dblMINVAL
                If v_dblFEEAMT > v_dblMAXVAL Then v_dblFEEAMT = v_dblMAXVAL
            End If
            v_dblVATAMT = v_dblFEEAMT * v_dblVATRATE / 100

            'Táº¡o cÃ¡c dÃ²ng thu phÃ­
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

    '---------------------------------------------------------------------------------------------------------
    'HÃ m nÃ y Ä‘Æ°á»£c sá»­ dá»¥ng Ä‘á»ƒ náº¡p mÃ n hÃ¬nh.
    'Biáº¿n vÃ o 
    '   strTLTXCD lÃ  mÃ£ giao dá»‹ch, dÃ¹ng Ä‘á»ƒ xÃ¡c Ä‘á»‹nh cÃ¡c trÆ°?ng trong giao dá»‹ch
    '   v_blnChain  XÃ¡c Ä‘á»‹nh xem cÃ³ pháº£i náº¡p mÃ n hÃ¬nh sau khi Ä‘Ã£ tra cá»©u khÃ´ng
    '   v_blnData   XÃ¡c Ä‘á»‹nh xem cÃ³ pháº£i náº¡p mÃ n hÃ¬nh xem chi tiáº¿t giao dá»‹ch khÃ´ng
    '   v_strXML    LÃ  ná»™i dung chuá»—i XML tÆ°Æ¡ng á»©ng vá»›i v_blnChain hoáº·c v_blnData
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

            'Láº¥y thÃ´ng tin chung ve giao dá»‹ch

            v_strSQL = "SELECT TX.* FROM TLTX TX, APPMODULES APP WHERE SUBSTR(TX.TLTXCD,1,2)=APP.TXCODE " _
                & "AND UPPER(TX.TLTXCD) = '" & strTLTXCD & "' " _
                & "AND UPPER(APP.MODCODE) = 'OD' "
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLTX, gc_ActionInquiry, v_strSQL)

            v_ws.Message(v_strObjMsg)

            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            If v_nodeList.Count = 0 Then
                'Náº¿u khÃ´ng tá»“n táº¡i mÃ£ giao dá»‹ch
                MessageBox.Show(mv_ResourceManager.GetString("ERR_TLTXCD_NOTFOUND"))
                'ResetScreen(Me)
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

                'xá»­ lÃ½
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

    Private Sub OnRefuse()
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Try
            If MsgBox(mv_ResourceManager.GetString("RefuseConfirm"), MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Me.Text) = MsgBoxResult.Yes Then
                Cursor.Current = Cursors.WaitCursor
                v_lngErrCode = ReleaseOrder()
                mv_isSEND = True
                Cursor.Current = Cursors.Default
                Me.OnClose()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

#End Region

End Class
