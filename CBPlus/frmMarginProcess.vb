Imports System.Windows.Forms
Imports Xceed.SmartUI.Controls
Imports CommonLibrary
Imports System.Collections
Imports AppCore
Imports AppCore.modCoreLib


Public Class frmMarginProcess
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal pv_strLanguage As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        mv_strLanguage = pv_strLanguage
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())

        InitializeGrid()
        InitDialog()

        'Add any initialization after the InitializeComponent() call
        mv_xmlDocumentInquiryData = New Xml.XmlDocument
    End Sub


    Public Sub New(ByVal pv_strLanguage As String, ByVal pv_strObjName As String)
        MyBase.New()
        ObjectName = pv_strObjName

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        mv_strLanguage = pv_strLanguage
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())

        If pv_strObjName <> "MR1003" Then
            Me.grbGAcctno.Visible = False
            'Me.lblvBfOdrAMT.Visible = True
            Me.lblvBfOdrAMT_G.Visible = False
            Me.lblvLstOdrAMT.Visible = True
            Me.lblvLstOdrAMT_G.Visible = False
            Me.grbAcctno.Visible = True
            Me.grbAddSec.Visible = True
        Else
            Me.grbAddSec.Visible = False
            'Me.grbAcctno.Visible = False
            Me.grbGAcctno.Visible = False
            Me.lblvBfOdrAMT.Visible = False
            Me.lblvBfOdrAMT_G.Visible = True
            Me.lblvLstOdrAMT.Visible = False
            Me.lblvLstOdrAMT_G.Visible = True
        End If

        InitializeGrid()
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
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents pnODSendInfo As System.Windows.Forms.Panel
    Friend WithEvents lblSecinfo As System.Windows.Forms.Label
    Friend WithEvents btnPlaceOrder As System.Windows.Forms.Button
    Friend WithEvents grbAddSec As System.Windows.Forms.GroupBox
    Friend WithEvents txtSYMBOL As System.Windows.Forms.TextBox
    Friend WithEvents lblSYMBOL As System.Windows.Forms.Label
    Friend WithEvents txtSECADD As System.Windows.Forms.TextBox
    Friend WithEvents lblSecAdd As System.Windows.Forms.Label
    Friend WithEvents pnlTitle As System.Windows.Forms.Panel
    Friend WithEvents grbCommonInfo As System.Windows.Forms.GroupBox
    Friend WithEvents lblvGBroker As System.Windows.Forms.Label
    Friend WithEvents lblvBroker As System.Windows.Forms.Label
    Friend WithEvents lblGBroker As System.Windows.Forms.Label
    Friend WithEvents lblBroker As System.Windows.Forms.Label
    Friend WithEvents lblvCustName As System.Windows.Forms.Label
    Friend WithEvents lblvCustodycd As System.Windows.Forms.Label
    Friend WithEvents lblCustName As System.Windows.Forms.Label
    Friend WithEvents lblCustodycd1 As System.Windows.Forms.Label
    Friend WithEvents lblvLstOdrAMT_G As System.Windows.Forms.Label
    Friend WithEvents lblvBfOdrAMT_G As System.Windows.Forms.Label
    Friend WithEvents lblLstOdrAMT_G As System.Windows.Forms.Label
    Friend WithEvents lblBfOdrAMT_G As System.Windows.Forms.Label
    Friend WithEvents lblvLstOdrAMT As System.Windows.Forms.Label
    Friend WithEvents lblvBfOdrAMT As System.Windows.Forms.Label
    Friend WithEvents lblLstOdrAMT As System.Windows.Forms.Label
    Friend WithEvents lblBfOdrAMT As System.Windows.Forms.Label
    Friend WithEvents grbGAcctno As System.Windows.Forms.GroupBox
    Friend WithEvents grbAcctno As System.Windows.Forms.GroupBox
    Friend WithEvents lblLeftAMT As System.Windows.Forms.Label
    Friend WithEvents lblAddAmt As System.Windows.Forms.Label
    Friend WithEvents lblSECRisk As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.pnODSendInfo = New System.Windows.Forms.Panel
        Me.grbGAcctno = New System.Windows.Forms.GroupBox
        Me.lblLstOdrAMT_G = New System.Windows.Forms.Label
        Me.lblBfOdrAMT_G = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnPlaceOrder = New System.Windows.Forms.Button
        Me.lblSecinfo = New System.Windows.Forms.Label
        Me.lblSECRisk = New System.Windows.Forms.Label
        Me.grbAddSec = New System.Windows.Forms.GroupBox
        Me.txtSYMBOL = New System.Windows.Forms.TextBox
        Me.lblSYMBOL = New System.Windows.Forms.Label
        Me.txtSECADD = New System.Windows.Forms.TextBox
        Me.lblSecAdd = New System.Windows.Forms.Label
        Me.pnlTitle = New System.Windows.Forms.Panel
        Me.grbCommonInfo = New System.Windows.Forms.GroupBox
        Me.grbAcctno = New System.Windows.Forms.GroupBox
        Me.lblLeftAMT = New System.Windows.Forms.Label
        Me.lblvLstOdrAMT_G = New System.Windows.Forms.Label
        Me.lblvLstOdrAMT = New System.Windows.Forms.Label
        Me.lblvBfOdrAMT_G = New System.Windows.Forms.Label
        Me.lblBfOdrAMT = New System.Windows.Forms.Label
        Me.lblAddAmt = New System.Windows.Forms.Label
        Me.lblLstOdrAMT = New System.Windows.Forms.Label
        Me.lblvBfOdrAMT = New System.Windows.Forms.Label
        Me.lblvGBroker = New System.Windows.Forms.Label
        Me.lblvBroker = New System.Windows.Forms.Label
        Me.lblGBroker = New System.Windows.Forms.Label
        Me.lblBroker = New System.Windows.Forms.Label
        Me.lblvCustName = New System.Windows.Forms.Label
        Me.lblvCustodycd = New System.Windows.Forms.Label
        Me.lblCustName = New System.Windows.Forms.Label
        Me.lblCustodycd1 = New System.Windows.Forms.Label
        Me.pnODSendInfo.SuspendLayout()
        Me.grbGAcctno.SuspendLayout()
        Me.grbAddSec.SuspendLayout()
        Me.grbCommonInfo.SuspendLayout()
        Me.grbAcctno.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnODSendInfo
        '
        Me.pnODSendInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnODSendInfo.Controls.Add(Me.grbGAcctno)
        Me.pnODSendInfo.Location = New System.Drawing.Point(10, 156)
        Me.pnODSendInfo.Name = "pnODSendInfo"
        Me.pnODSendInfo.Size = New System.Drawing.Size(961, 251)
        Me.pnODSendInfo.TabIndex = 2
        '
        'grbGAcctno
        '
        Me.grbGAcctno.Controls.Add(Me.lblLstOdrAMT_G)
        Me.grbGAcctno.Controls.Add(Me.lblBfOdrAMT_G)
        Me.grbGAcctno.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbGAcctno.Location = New System.Drawing.Point(595, 12)
        Me.grbGAcctno.Name = "grbGAcctno"
        Me.grbGAcctno.Size = New System.Drawing.Size(350, 59)
        Me.grbGAcctno.TabIndex = 0
        Me.grbGAcctno.TabStop = False
        Me.grbGAcctno.Text = "GroupBox2"
        '
        'lblLstOdrAMT_G
        '
        Me.lblLstOdrAMT_G.AutoSize = True
        Me.lblLstOdrAMT_G.Location = New System.Drawing.Point(6, 40)
        Me.lblLstOdrAMT_G.Name = "lblLstOdrAMT_G"
        Me.lblLstOdrAMT_G.Size = New System.Drawing.Size(85, 13)
        Me.lblLstOdrAMT_G.TabIndex = 20
        Me.lblLstOdrAMT_G.Text = "lblLstOdrAMT_G"
        '
        'lblBfOdrAMT_G
        '
        Me.lblBfOdrAMT_G.AutoSize = True
        Me.lblBfOdrAMT_G.Location = New System.Drawing.Point(6, 18)
        Me.lblBfOdrAMT_G.Name = "lblBfOdrAMT_G"
        Me.lblBfOdrAMT_G.Size = New System.Drawing.Size(81, 13)
        Me.lblBfOdrAMT_G.TabIndex = 19
        Me.lblBfOdrAMT_G.Text = "lblBfOdrAMT_G"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(892, 475)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 24)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "btnCancel"
        '
        'btnPlaceOrder
        '
        Me.btnPlaceOrder.Location = New System.Drawing.Point(804, 475)
        Me.btnPlaceOrder.Name = "btnPlaceOrder"
        Me.btnPlaceOrder.Size = New System.Drawing.Size(80, 24)
        Me.btnPlaceOrder.TabIndex = 4
        Me.btnPlaceOrder.Text = "PlaceOrder"
        '
        'lblSecinfo
        '
        Me.lblSecinfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSecinfo.ForeColor = System.Drawing.Color.Blue
        Me.lblSecinfo.Location = New System.Drawing.Point(9, 420)
        Me.lblSecinfo.Name = "lblSecinfo"
        Me.lblSecinfo.Size = New System.Drawing.Size(481, 38)
        Me.lblSecinfo.TabIndex = 9
        Me.lblSecinfo.Tag = "lblSecinfo"
        Me.lblSecinfo.Text = "lblSecinfo"
        Me.lblSecinfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSECRisk
        '
        Me.lblSECRisk.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSECRisk.ForeColor = System.Drawing.Color.Blue
        Me.lblSECRisk.Location = New System.Drawing.Point(8, 457)
        Me.lblSECRisk.Name = "lblSECRisk"
        Me.lblSECRisk.Size = New System.Drawing.Size(481, 38)
        Me.lblSECRisk.TabIndex = 12
        Me.lblSECRisk.Tag = "lblSECRisk"
        Me.lblSECRisk.Text = "lblSECRisk"
        Me.lblSECRisk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grbAddSec
        '
        Me.grbAddSec.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbAddSec.Controls.Add(Me.txtSYMBOL)
        Me.grbAddSec.Controls.Add(Me.lblSYMBOL)
        Me.grbAddSec.Controls.Add(Me.txtSECADD)
        Me.grbAddSec.Controls.Add(Me.lblSecAdd)
        Me.grbAddSec.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbAddSec.Location = New System.Drawing.Point(522, 418)
        Me.grbAddSec.Name = "grbAddSec"
        Me.grbAddSec.Size = New System.Drawing.Size(447, 51)
        Me.grbAddSec.TabIndex = 13
        Me.grbAddSec.TabStop = False
        Me.grbAddSec.Tag = "grbAddSec"
        Me.grbAddSec.Text = "Tính toán chứng khoán bổ sung"
        '
        'txtSYMBOL
        '
        Me.txtSYMBOL.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtSYMBOL.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSYMBOL.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSYMBOL.Location = New System.Drawing.Point(82, 25)
        Me.txtSYMBOL.Name = "txtSYMBOL"
        Me.txtSYMBOL.Size = New System.Drawing.Size(94, 20)
        Me.txtSYMBOL.TabIndex = 0
        Me.txtSYMBOL.Tag = "txtSYMBOL"
        '
        'lblSYMBOL
        '
        Me.lblSYMBOL.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblSYMBOL.AutoSize = True
        Me.lblSYMBOL.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSYMBOL.Location = New System.Drawing.Point(10, 28)
        Me.lblSYMBOL.Name = "lblSYMBOL"
        Me.lblSYMBOL.Size = New System.Drawing.Size(39, 13)
        Me.lblSYMBOL.TabIndex = 4
        Me.lblSYMBOL.Tag = "lblSYMBOL"
        Me.lblSYMBOL.Text = "Mã CK"
        '
        'txtSECADD
        '
        Me.txtSECADD.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtSECADD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSECADD.Location = New System.Drawing.Point(315, 25)
        Me.txtSECADD.Name = "txtSECADD"
        Me.txtSECADD.Size = New System.Drawing.Size(119, 20)
        Me.txtSECADD.TabIndex = 1
        Me.txtSECADD.Tag = "txtSECADD"
        Me.txtSECADD.Text = "0"
        Me.txtSECADD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSecAdd
        '
        Me.lblSecAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblSecAdd.AutoSize = True
        Me.lblSecAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSecAdd.Location = New System.Drawing.Point(215, 28)
        Me.lblSecAdd.Name = "lblSecAdd"
        Me.lblSecAdd.Size = New System.Drawing.Size(61, 13)
        Me.lblSecAdd.TabIndex = 6
        Me.lblSecAdd.Tag = "lblSecAdd"
        Me.lblSecAdd.Text = "SL bổ sung"
        '
        'pnlTitle
        '
        Me.pnlTitle.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTitle.Location = New System.Drawing.Point(0, 0)
        Me.pnlTitle.Name = "pnlTitle"
        Me.pnlTitle.Size = New System.Drawing.Size(980, 50)
        Me.pnlTitle.TabIndex = 0
        '
        'grbCommonInfo
        '
        Me.grbCommonInfo.Controls.Add(Me.grbAcctno)
        Me.grbCommonInfo.Controls.Add(Me.lblvGBroker)
        Me.grbCommonInfo.Controls.Add(Me.lblvBroker)
        Me.grbCommonInfo.Controls.Add(Me.lblGBroker)
        Me.grbCommonInfo.Controls.Add(Me.lblBroker)
        Me.grbCommonInfo.Controls.Add(Me.lblvCustName)
        Me.grbCommonInfo.Controls.Add(Me.lblvCustodycd)
        Me.grbCommonInfo.Controls.Add(Me.lblCustName)
        Me.grbCommonInfo.Controls.Add(Me.lblCustodycd1)
        Me.grbCommonInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbCommonInfo.Location = New System.Drawing.Point(0, 56)
        Me.grbCommonInfo.Name = "grbCommonInfo"
        Me.grbCommonInfo.Size = New System.Drawing.Size(980, 82)
        Me.grbCommonInfo.TabIndex = 14
        Me.grbCommonInfo.TabStop = False
        Me.grbCommonInfo.Tag = "grbCommonInfo"
        Me.grbCommonInfo.Text = "GroupBox1"
        '
        'grbAcctno
        '
        Me.grbAcctno.Controls.Add(Me.lblLeftAMT)
        Me.grbAcctno.Controls.Add(Me.lblvLstOdrAMT_G)
        Me.grbAcctno.Controls.Add(Me.lblvLstOdrAMT)
        Me.grbAcctno.Controls.Add(Me.lblvBfOdrAMT_G)
        Me.grbAcctno.Controls.Add(Me.lblBfOdrAMT)
        Me.grbAcctno.Controls.Add(Me.lblAddAmt)
        Me.grbAcctno.Controls.Add(Me.lblLstOdrAMT)
        Me.grbAcctno.Controls.Add(Me.lblvBfOdrAMT)
        Me.grbAcctno.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbAcctno.Location = New System.Drawing.Point(606, 14)
        Me.grbAcctno.Name = "grbAcctno"
        Me.grbAcctno.Size = New System.Drawing.Size(350, 59)
        Me.grbAcctno.TabIndex = 23
        Me.grbAcctno.TabStop = False
        Me.grbAcctno.Text = "GroupBox1"
        '
        'lblLeftAMT
        '
        Me.lblLeftAMT.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLeftAMT.ForeColor = System.Drawing.Color.Red
        Me.lblLeftAMT.Location = New System.Drawing.Point(438, 34)
        Me.lblLeftAMT.Name = "lblLeftAMT"
        Me.lblLeftAMT.Size = New System.Drawing.Size(131, 23)
        Me.lblLeftAMT.TabIndex = 5
        Me.lblLeftAMT.Tag = "lblLeftAMT"
        Me.lblLeftAMT.Text = "lblLeftAMT"
        Me.lblLeftAMT.Visible = False
        '
        'lblvLstOdrAMT_G
        '
        Me.lblvLstOdrAMT_G.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblvLstOdrAMT_G.ForeColor = System.Drawing.Color.Red
        Me.lblvLstOdrAMT_G.Location = New System.Drawing.Point(191, 44)
        Me.lblvLstOdrAMT_G.Name = "lblvLstOdrAMT_G"
        Me.lblvLstOdrAMT_G.Size = New System.Drawing.Size(150, 13)
        Me.lblvLstOdrAMT_G.TabIndex = 22
        Me.lblvLstOdrAMT_G.Text = "lblvLstOdrAMT_G"
        Me.lblvLstOdrAMT_G.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblvLstOdrAMT
        '
        Me.lblvLstOdrAMT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblvLstOdrAMT.ForeColor = System.Drawing.Color.Red
        Me.lblvLstOdrAMT.Location = New System.Drawing.Point(191, 43)
        Me.lblvLstOdrAMT.Name = "lblvLstOdrAMT"
        Me.lblvLstOdrAMT.Size = New System.Drawing.Size(150, 13)
        Me.lblvLstOdrAMT.TabIndex = 18
        Me.lblvLstOdrAMT.Text = "lblvLstOdrAMT"
        Me.lblvLstOdrAMT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblvBfOdrAMT_G
        '
        Me.lblvBfOdrAMT_G.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblvBfOdrAMT_G.Location = New System.Drawing.Point(191, 22)
        Me.lblvBfOdrAMT_G.Name = "lblvBfOdrAMT_G"
        Me.lblvBfOdrAMT_G.Size = New System.Drawing.Size(150, 13)
        Me.lblvBfOdrAMT_G.TabIndex = 21
        Me.lblvBfOdrAMT_G.Text = "lblvBfOdrAMT_G"
        Me.lblvBfOdrAMT_G.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBfOdrAMT
        '
        Me.lblBfOdrAMT.AutoSize = True
        Me.lblBfOdrAMT.Location = New System.Drawing.Point(6, 20)
        Me.lblBfOdrAMT.Name = "lblBfOdrAMT"
        Me.lblBfOdrAMT.Size = New System.Drawing.Size(67, 13)
        Me.lblBfOdrAMT.TabIndex = 15
        Me.lblBfOdrAMT.Text = "lblBfOdrAMT"
        '
        'lblAddAmt
        '
        Me.lblAddAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAddAmt.ForeColor = System.Drawing.Color.Red
        Me.lblAddAmt.Location = New System.Drawing.Point(437, 15)
        Me.lblAddAmt.Name = "lblAddAmt"
        Me.lblAddAmt.Size = New System.Drawing.Size(131, 23)
        Me.lblAddAmt.TabIndex = 4
        Me.lblAddAmt.Tag = "lblAddAmt"
        Me.lblAddAmt.Text = "lblAddAmt"
        Me.lblAddAmt.Visible = False
        '
        'lblLstOdrAMT
        '
        Me.lblLstOdrAMT.AutoSize = True
        Me.lblLstOdrAMT.Location = New System.Drawing.Point(6, 43)
        Me.lblLstOdrAMT.Name = "lblLstOdrAMT"
        Me.lblLstOdrAMT.Size = New System.Drawing.Size(71, 13)
        Me.lblLstOdrAMT.TabIndex = 16
        Me.lblLstOdrAMT.Text = "lblLstOdrAMT"
        '
        'lblvBfOdrAMT
        '
        Me.lblvBfOdrAMT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblvBfOdrAMT.Location = New System.Drawing.Point(191, 21)
        Me.lblvBfOdrAMT.Name = "lblvBfOdrAMT"
        Me.lblvBfOdrAMT.Size = New System.Drawing.Size(150, 13)
        Me.lblvBfOdrAMT.TabIndex = 17
        Me.lblvBfOdrAMT.Text = "lblvBfOdrAMT"
        Me.lblvBfOdrAMT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblvGBroker
        '
        Me.lblvGBroker.AutoSize = True
        Me.lblvGBroker.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblvGBroker.Location = New System.Drawing.Point(363, 56)
        Me.lblvGBroker.Name = "lblvGBroker"
        Me.lblvGBroker.Size = New System.Drawing.Size(62, 13)
        Me.lblvGBroker.TabIndex = 14
        Me.lblvGBroker.Text = "lblvGBroker"
        '
        'lblvBroker
        '
        Me.lblvBroker.AutoSize = True
        Me.lblvBroker.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblvBroker.Location = New System.Drawing.Point(336, 30)
        Me.lblvBroker.Name = "lblvBroker"
        Me.lblvBroker.Size = New System.Drawing.Size(54, 13)
        Me.lblvBroker.TabIndex = 13
        Me.lblvBroker.Text = "lblvBroker"
        '
        'lblGBroker
        '
        Me.lblGBroker.AutoSize = True
        Me.lblGBroker.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGBroker.Location = New System.Drawing.Point(247, 56)
        Me.lblGBroker.Name = "lblGBroker"
        Me.lblGBroker.Size = New System.Drawing.Size(56, 13)
        Me.lblGBroker.TabIndex = 10
        Me.lblGBroker.Text = "lblGBroker"
        '
        'lblBroker
        '
        Me.lblBroker.AutoSize = True
        Me.lblBroker.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBroker.Location = New System.Drawing.Point(247, 30)
        Me.lblBroker.Name = "lblBroker"
        Me.lblBroker.Size = New System.Drawing.Size(48, 13)
        Me.lblBroker.TabIndex = 9
        Me.lblBroker.Text = "lblBroker"
        '
        'lblvCustName
        '
        Me.lblvCustName.AutoSize = True
        Me.lblvCustName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblvCustName.Location = New System.Drawing.Point(82, 55)
        Me.lblvCustName.Name = "lblvCustName"
        Me.lblvCustName.Size = New System.Drawing.Size(72, 13)
        Me.lblvCustName.TabIndex = 5
        Me.lblvCustName.Text = "lblvCustName"
        '
        'lblvCustodycd
        '
        Me.lblvCustodycd.AutoSize = True
        Me.lblvCustodycd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblvCustodycd.Location = New System.Drawing.Point(82, 28)
        Me.lblvCustodycd.Name = "lblvCustodycd"
        Me.lblvCustodycd.Size = New System.Drawing.Size(73, 13)
        Me.lblvCustodycd.TabIndex = 4
        Me.lblvCustodycd.Text = "lblvCustodycd"
        '
        'lblCustName
        '
        Me.lblCustName.AutoSize = True
        Me.lblCustName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustName.Location = New System.Drawing.Point(4, 55)
        Me.lblCustName.Name = "lblCustName"
        Me.lblCustName.Size = New System.Drawing.Size(66, 13)
        Me.lblCustName.TabIndex = 1
        Me.lblCustName.Text = "lblCustName"
        '
        'lblCustodycd1
        '
        Me.lblCustodycd1.AutoSize = True
        Me.lblCustodycd1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustodycd1.Location = New System.Drawing.Point(4, 28)
        Me.lblCustodycd1.Name = "lblCustodycd1"
        Me.lblCustodycd1.Size = New System.Drawing.Size(67, 13)
        Me.lblCustodycd1.TabIndex = 0
        Me.lblCustodycd1.Text = "lblCustodycd"
        '
        'frmMarginProcess
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(980, 506)
        Me.Controls.Add(Me.grbCommonInfo)
        Me.Controls.Add(Me.grbAddSec)
        Me.Controls.Add(Me.lblSECRisk)
        Me.Controls.Add(Me.lblSecinfo)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.pnODSendInfo)
        Me.Controls.Add(Me.pnlTitle)
        Me.Controls.Add(Me.btnPlaceOrder)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMarginProcess"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "frmMarginProcess"
        Me.Text = "frmMarginProcess"
        Me.pnODSendInfo.ResumeLayout(False)
        Me.grbGAcctno.ResumeLayout(False)
        Me.grbGAcctno.PerformLayout()
        Me.grbAddSec.ResumeLayout(False)
        Me.grbAddSec.PerformLayout()
        Me.grbCommonInfo.ResumeLayout(False)
        Me.grbCommonInfo.PerformLayout()
        Me.grbAcctno.ResumeLayout(False)
        Me.grbAcctno.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Declare constant and variables "
    Public mv_strSYMBOLLIST As String = ""
    Public mv_SymbolTalble As New DataTable
    Const c_ResourceManager = "_DIRECT.frmMarginProcess-"
    Public ODSendGrid As GridEx
    Dim mv_strACTYPE As String = String.Empty
    Dim mv_strAFACCTNO As String = String.Empty
    Dim mv_strGROUPLEADER As String = String.Empty
    Dim mv_strGROUPID As String = String.Empty
    Dim mv_dblRTNAMOUNT As Double = 0
    Dim mv_dblOVDAMOUNT As Double = 0
    Dim mv_dblSELLLOSTASS As Double = 0
    Dim mv_dblSELLAMOUNT As Double = 0
    Dim mv_dblADDRTNAMOUNT As Double = 0
    Dim mv_dblMRIRATE As Double = 0
    Dim mv_dblSELLRATE As Double = 0
    Dim mv_dblMRRATE As Double = 0
    Dim mv_dblRTLAMT_MR As Double = 0
    Dim mv_dblRTLAMT_MC As Double = 0
    Dim mv_dblRTLAMT_MB As Double = 0
    Dim mv_dblRTSELLAMT_MR As Double = 0
    Dim mv_dblRTSELLAMT_MB As Double = 0
    Dim mv_dblRTSELLAMT_MC As Double = 0
    Dim mv_dblOUTSTANDING As Double = 0
    Dim mv_dblTOTALVND As Double = 0
    Dim mv_dblMINODAMT As Double = 0
    Dim mv_dblMRSRATE As Double = 0
    Dim mv_dblMCSRATE As Double = 0
    Dim mv_dblMBSRATE As Double = 0
    Dim mv_dblAddVND As Double = 0

    Dim mv_dblFloorPrice As Double
    Dim mv_dblMarginPrice As Double
    Dim mv_dblCeilingPrice As Double
    Dim mv_dblTradeLot As Double
    Dim mv_dblTradeUnit As Double
    Dim mv_strTradePlace As String
    Dim mv_dblSecureRatio As Double
    Dim mv_dblBasicPrice As Double
    Dim mv_strMarginType As String = "N"
    Dim mv_strDUE As String
    Dim mv_dblNumDue As Double = 0
    Dim mv_dblDFRate As Double = 0
    Dim mv_dblIRate As Double = 0
    Dim mv_dblMRate As Double = 0
    Dim mv_dblDFREFPRICE As Double = 0
    Dim mv_dblDEFFEERATE As Double = 0
    Dim mv_dblADVSELLDUTY As Double = 0
    Dim mv_dblADVRATE As Double = 0
    Dim mv_dblADVMINFEE As Double = 0
    Dim mv_dblDAYS As Double = 3
    'DieuNDA 28/10/2015: Them so ngay clearday tren loai hinh ODTYPE
    Dim mv_dblClearday As Double = 3

    Dim mv_dblMarginRatioRate As Double = 0
    Dim mv_dblDPRatioRate As Double = 0
    Dim mv_dblSecMarginPrice As Double = 0
    Dim mv_dblMarginRefRatioRate As Double = 0
    Dim mv_dblSecMarginRefPrice As Double = 0

    Dim mv_dbdParvalue As Double
    Private mv_strAction As String = "N"
    Private mv_strSQLCMD As String = String.Empty
    Private mv_strObjectName As String
    Private mv_strTltxcd As String
    Private mv_strModuleCode As String
    Private mv_strLanguage As String
    Private mv_ResourceManager As Resources.ResourceManager
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

    Dim mv_dblADDRTNAMOUNT_M As Double
    Dim mv_dblOVDAMOUNT_M As Double
    Dim mv_dblSELLLOSTASS_M As Double
    Dim mv_dblSELLAMOUNT_M As Double
    Dim mv_dblMRIRATE_M As Double
    Dim mv_dblSELLRATE_M As Double
    Dim mv_dblMRRATE_M As Double
    Private mv_strACCTNO_M As String

    Private mv_intCurrentRow As Integer

    Private Const CONTROL_PNL_CONTRACT_TOP = 200
    Private Const CONTROL_BUTTON_TOP = 400
    Private Const FRM_DEFAULT_HEIGHT = 260
    Private Const FRM_EXTEND_HEIGHT = 460

    Private mv_strOrderStatus As String
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
    Public Property AFACCTNO() As String
        Get
            Return mv_strAFACCTNO
        End Get
        Set(ByVal Value As String)
            mv_strAFACCTNO = Value
        End Set
    End Property

    Public Property GROUPLEADER() As String
        Get
            Return mv_strGROUPLEADER
        End Get
        Set(ByVal Value As String)
            mv_strGROUPLEADER = Value
        End Set
    End Property

    Public Property ACTYPE() As String
        Get
            Return mv_strACTYPE
        End Get
        Set(ByVal Value As String)
            mv_strACTYPE = Value
        End Set
    End Property
    Public Property RTNAMOUNT() As Double
        Get
            Return mv_dblRTNAMOUNT
        End Get
        Set(ByVal Value As Double)
            mv_dblRTNAMOUNT = Value
        End Set
    End Property
    Public Property OVDAMOUNT() As Double
        Get
            Return mv_dblOVDAMOUNT
        End Get
        Set(ByVal Value As Double)
            mv_dblOVDAMOUNT = Value
        End Set
    End Property
    Public Property SELLLOSTASS() As Double
        Get
            Return mv_dblSELLLOSTASS
        End Get
        Set(ByVal Value As Double)
            mv_dblSELLLOSTASS = Value
        End Set
    End Property
    Public Property SELLAMOUNT() As Double
        Get
            Return mv_dblSELLAMOUNT
        End Get
        Set(ByVal Value As Double)
            mv_dblSELLAMOUNT = Value
        End Set
    End Property
    Public Property ADDRTNAMOUNT() As Double
        Get
            Return mv_dblADDRTNAMOUNT
        End Get
        Set(ByVal Value As Double)
            mv_dblADDRTNAMOUNT = Value
        End Set
    End Property

    Public Property MRIRATE() As Double
        Get
            Return mv_dblMRIRATE
        End Get
        Set(ByVal Value As Double)
            mv_dblMRIRATE = Value
        End Set
    End Property

    Public Property GROUPID() As String
        Get
            Return mv_strGROUPID
        End Get
        Set(ByVal Value As String)
            mv_strGROUPID = Value
        End Set
    End Property

    Public Property SELLRATE() As Double
        Get
            Return mv_dblSELLRATE
        End Get
        Set(ByVal Value As Double)
            mv_dblSELLRATE = Value
        End Set
    End Property

    Public Property MRRATE() As Double
        Get
            Return mv_dblMRRATE
        End Get
        Set(ByVal Value As Double)
            mv_dblMRRATE = Value
        End Set
    End Property

    Public Property RTLAMT_MR() As Double
        Get
            Return mv_dblRTLAMT_MR
        End Get
        Set(ByVal Value As Double)
            mv_dblRTLAMT_MR = Value
        End Set
    End Property

    Public Property RTLAMT_MC() As Double
        Get
            Return mv_dblRTLAMT_MC
        End Get
        Set(ByVal Value As Double)
            mv_dblRTLAMT_MC = Value
        End Set
    End Property

    Public Property RTLAMT_MB() As Double
        Get
            Return mv_dblRTLAMT_MB
        End Get
        Set(ByVal Value As Double)
            mv_dblRTLAMT_MB = Value
        End Set
    End Property

    Public Property RTSELLAMT_MR() As Double
        Get
            Return mv_dblRTSELLAMT_MR
        End Get
        Set(ByVal Value As Double)
            mv_dblRTSELLAMT_MR = Value
        End Set
    End Property

    Public Property RTSELLAMT_MC() As Double
        Get
            Return mv_dblRTSELLAMT_MC
        End Get
        Set(ByVal Value As Double)
            mv_dblRTSELLAMT_MC = Value
        End Set
    End Property

    Public Property RTSELLAMT_MB() As Double
        Get
            Return mv_dblRTSELLAMT_MB
        End Get
        Set(ByVal Value As Double)
            mv_dblRTSELLAMT_MB = Value
        End Set
    End Property

    Public Property OUTSTANDING() As Double
        Get
            Return mv_dblOUTSTANDING
        End Get
        Set(ByVal Value As Double)
            mv_dblOUTSTANDING = Value
        End Set
    End Property

    Public Property TOTALVND() As Double
        Get
            Return mv_dblTOTALVND
        End Get
        Set(ByVal Value As Double)
            mv_dblTOTALVND = Value
        End Set
    End Property

    Public Property MINODAMT() As Double
        Get
            Return mv_dblMINODAMT
        End Get
        Set(ByVal Value As Double)
            mv_dblMINODAMT = Value
        End Set
    End Property

    Public Property MRSRATE() As Double
        Get
            Return mv_dblMRSRATE
        End Get
        Set(ByVal Value As Double)
            mv_dblMRSRATE = Value
        End Set
    End Property

    Public Property MCSRATE() As Double
        Get
            Return mv_dblMCSRATE
        End Get
        Set(ByVal Value As Double)
            mv_dblMCSRATE = Value
        End Set
    End Property

    Public Property MBSRATE() As Double
        Get
            Return mv_dblMBSRATE
        End Get
        Set(ByVal Value As Double)
            mv_dblMBSRATE = Value
        End Set
    End Property

    Public Property ADDVND() As Double
        Get
            Return mv_dblAddVND
        End Get
        Set(ByVal Value As Double)
            mv_dblAddVND = Value
        End Set
    End Property

#End Region

#Region " Other Methods "
    Public Sub GetOrder()
        Try
            Dim v_strCmdInquiry As String

            If ObjectName <> "MR1003" Then
                If IIf(GROUPLEADER Is Nothing, "", GROUPLEADER).Length > 0 Then
                    v_strCmdInquiry = "select AFACCTNO,ACTYPE,EXECTYPE,SYMBOL,QUANTITY,SELLQTTY,SELLPRICE,TRADEPLACE, LNRATE,LNRATE_MR,LNRATE_MC," & ControlChars.CrLf _
                                       & "    SCRRATE,OCRATE,DLRATE from vw_mr_MarginProcess_Grouplead where AFACCTNO = '" & AFACCTNO & "'" & ControlChars.CrLf
                Else
                    v_strCmdInquiry = "select AFACCTNO,ACTYPE,EXECTYPE,SYMBOL,QUANTITY,SELLQTTY, SELLPRICE,TRADEPLACE, LNRATE,LNRATE_MR,LNRATE_MC," & ControlChars.CrLf _
                                       & "    SCRRATE,OCRATE,DLRATE from vw_mr_marginprocess where AFACCTNO = '" & AFACCTNO & "'" & ControlChars.CrLf

                End If
            Else
                If IIf(GROUPLEADER Is Nothing, "", GROUPLEADER).Length > 0 Then
                    v_strCmdInquiry = "select AFACCTNO,ACTYPE,EXECTYPE,SYMBOL,QUANTITY,SELLQTTY,SELLPRICE,TRADEPLACE, LNRATE,LNRATE_MR,LNRATE_MC," & ControlChars.CrLf _
                                       & "    SCRRATE,OCRATE,DLRATE from vw_mr_MarginProcess_Grouplead where GROUPID = '" & GROUPID & "'" & ControlChars.CrLf
                Else
                    v_strCmdInquiry = "select AFACCTNO,ACTYPE,EXECTYPE,SYMBOL,QUANTITY,SELLQTTY,SELLPRICE,TRADEPLACE, LNRATE,LNRATE_MR,LNRATE_MC," & ControlChars.CrLf _
                                       & "    SCRRATE,OCRATE,DLRATE from vw_mr_marginprocess where GROUPID = '" & GROUPID & "'" & ControlChars.CrLf

                End If
            End If


            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, "N", gc_MsgTypeObj, OBJNAME_OD_ODMAST, gc_ActionInquiry, v_strCmdInquiry)
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            v_ws.Message(v_strObjMsg)

            FillDataGrid(ODSendGrid, v_strObjMsg, "")

            If mv_intCurrentRow >= ODSendGrid.DataRows.Count Then mv_intCurrentRow = 0
            If ODSendGrid.DataRows.Count > 0 Then
                ODSendGrid.CurrentRow = ODSendGrid.DataRows(mv_intCurrentRow)
                ODSendGrid.SelectedRows.Clear()
                ODSendGrid.SelectedRows.Add(ODSendGrid.CurrentRow)
                btnPlaceOrder.Focus()


                Dim v_nodeList As Xml.XmlNodeList
                Dim v_xmlDocument As New Xml.XmlDocument
                Dim v_strValue, v_strFLDNAME, v_strTEXT As String
                Dim v_strCmdSQL As String



                v_strCmdSQL = " select AD.*, getnonworkingday(3) DAYS fROM ADTYPE AD, AFTYPE AF, AFMAST AFM " & _
                                "WHERE AD.ACTYPE=AF.ADTYPE AND AF.ACTYPE=AFM.ACTYPE AND AFM.ACCTNO='" & mv_strAFACCTNO & "'"

                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
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
                                Case "ADVRATE"
                                    mv_dblADVRATE = CDbl(v_strValue)
                                Case "ADVMINFEE"
                                    mv_dblADVMINFEE = CDbl(v_strValue)
                                    'Case "DAYS"
                                    '    mv_dblDAYS = CDbl(v_strValue)
                            End Select
                        End With
                    Next
                Next

                


            End If




        Catch ex As Exception
            Throw ex
        End Try



    End Sub
    Private Sub InitializeGrid()
        'KhÃ¡Â»Å¸i tÃ¡ÂºÂ¡o Grid contacts
        ODSendGrid = New GridEx
        Dim v_cmrContactsHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrContactsHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrContactsHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        ODSendGrid.FixedHeaderRows.Add(v_cmrContactsHeader)
        v_cmrContactsHeader.Height = 30

        ODSendGrid.Columns.Add(New Xceed.Grid.Column("TICK", GetType(System.String)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("AFACCTNO", GetType(System.String)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("ACTYPE", GetType(System.String)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("EXECTYPE", GetType(System.String)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("SYMBOL", GetType(System.String)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("TRADEPLACE", GetType(System.String)))

        ODSendGrid.Columns.Add(New Xceed.Grid.Column("LNRATE", GetType(System.Double)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("LNRATE_MR", GetType(System.Double)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("LNRATE_MC", GetType(System.Double)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("SCRRATE", GetType(System.Double)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("OCRATE", GetType(System.Double)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("DLRATE", GetType(System.Double)))

        ODSendGrid.Columns.Add(New Xceed.Grid.Column("QUANTITY", GetType(System.Double)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("SELLQTTY", GetType(System.Double)))
        'ODSendGrid.Columns.Add(New Xceed.Grid.Column("FACTORQTTY", GetType(System.Double)))

        ODSendGrid.Columns.Add(New Xceed.Grid.Column("SELLPRICE", GetType(System.String)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("SELLAMT", GetType(System.Double)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("LOSTASSAMT", GetType(System.Double)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("ADDAMOUNT", GetType(System.Double)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("QRTT0", GetType(System.Double)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("QRTT", GetType(System.Double)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("SCRQTTY", GetType(System.Double)))


        ODSendGrid.Columns("TICK").Title = mv_ResourceManager.GetString("TICK")
        ODSendGrid.Columns("AFACCTNO").Title = mv_ResourceManager.GetString("AFACCTNO")
        ODSendGrid.Columns("ACTYPE").Title = mv_ResourceManager.GetString("ACTYPE")
        ODSendGrid.Columns("EXECTYPE").Title = mv_ResourceManager.GetString("EXECTYPE")
        ODSendGrid.Columns("SYMBOL").Title = mv_ResourceManager.GetString("SYMBOL")

        ODSendGrid.Columns("LNRATE").Title = mv_ResourceManager.GetString("LNRATE")
        ODSendGrid.Columns("LNRATE_MR").Title = mv_ResourceManager.GetString("LNRATE_MR")
        ODSendGrid.Columns("LNRATE_MC").Title = mv_ResourceManager.GetString("LNRATE_MC")
        ODSendGrid.Columns("SCRRATE").Title = mv_ResourceManager.GetString("SCRRATE")
        ODSendGrid.Columns("OCRATE").Title = mv_ResourceManager.GetString("OCRATE")
        ODSendGrid.Columns("DLRATE").Title = mv_ResourceManager.GetString("DLRATE")

        ODSendGrid.Columns("QUANTITY").Title = mv_ResourceManager.GetString("QUANTITY")
        ODSendGrid.Columns("SELLQTTY").Title = mv_ResourceManager.GetString("SELLQTTY")
        ODSendGrid.Columns("SCRQTTY").Title = mv_ResourceManager.GetString("SCRQTTY")
        'ODSendGrid.Columns("FACTORQTTY").Title = mv_ResourceManager.GetString("FACTORQTTY")

        ODSendGrid.Columns("SELLPRICE").Title = mv_ResourceManager.GetString("SELLPRICE")
        ODSendGrid.Columns("SELLAMT").Title = mv_ResourceManager.GetString("SELLAMT")
        ODSendGrid.Columns("ADDAMOUNT").Title = mv_ResourceManager.GetString("ADDAMOUNT")
        ODSendGrid.Columns("LOSTASSAMT").Title = mv_ResourceManager.GetString("LOSTASSAMT")
        ODSendGrid.Columns("QRTT").Title = mv_ResourceManager.GetString("QRTT")
        ODSendGrid.Columns("QRTT0").Title = mv_ResourceManager.GetString("QRTT0")


        ODSendGrid.Columns("QUANTITY").FormatSpecifier = "#,##0"
        ODSendGrid.Columns("SELLQTTY").FormatSpecifier = "#,##0"
        ODSendGrid.Columns("SCRQTTY").FormatSpecifier = "#,##0"
        'ODSendGrid.Columns("FACTORQTTY").FormatSpecifier = "#,##0"
        ODSendGrid.Columns("SELLAMT").FormatSpecifier = "#,##0"
        ODSendGrid.Columns("ADDAMOUNT").FormatSpecifier = "#,##0"
        ODSendGrid.Columns("LOSTASSAMT").FormatSpecifier = "#,##0"
        ODSendGrid.Columns("QRTT").FormatSpecifier = "#,##0"
        ODSendGrid.Columns("QRTT0").FormatSpecifier = "#,##0"

        ODSendGrid.Columns("LNRATE").FormatSpecifier = "#,##0.###"
        ODSendGrid.Columns("LNRATE_MR").FormatSpecifier = "#,##0.###"
        ODSendGrid.Columns("LNRATE_MC").FormatSpecifier = "#,##0.###"
        ODSendGrid.Columns("SCRRATE").FormatSpecifier = "#,##0.###"
        ODSendGrid.Columns("OCRATE").FormatSpecifier = "#,##0.###"
        ODSendGrid.Columns("DLRATE").FormatSpecifier = "#,##0.###"


        ODSendGrid.Columns("TICK").Width = 15
        ODSendGrid.Columns("AFACCTNO").Width = 100
        ODSendGrid.Columns("EXECTYPE").Width = 75
        ODSendGrid.Columns("ACTYPE").Visible = False
        ODSendGrid.Columns("TRADEPLACE").Visible = False
        ODSendGrid.Columns("LOSTASSAMT").Visible = False
        ODSendGrid.Columns("ADDAMOUNT").Visible = False

        'ODSendGrid.Columns("LOSTASSAMT").Visible = False
        ODSendGrid.Columns("SYMBOL").Width = 100
        ODSendGrid.Columns("QUANTITY").Width = 100
        ODSendGrid.Columns("SELLQTTY").Width = 100
        ODSendGrid.Columns("SCRQTTY").Width = 100
        'ODSendGrid.Columns("FACTORQTTY").Width = 100
        ODSendGrid.Columns("SELLPRICE").Width = 100
        ODSendGrid.Columns("SELLAMT").Width = 100
        ODSendGrid.Columns("LNRATE").Width = 80
        ODSendGrid.Columns("LNRATE_MR").Width = 80
        ODSendGrid.Columns("LNRATE_MC").Width = 80
        ODSendGrid.Columns("LNRATE_MR").Visible = False
        ODSendGrid.Columns("LNRATE_MC").Visible = False
        ODSendGrid.Columns("SCRRATE").Width = 80
        ODSendGrid.Columns("OCRATE").Width = 80
        ODSendGrid.Columns("DLRATE").Width = 80
        ODSendGrid.Columns("QRTT").Width = 100
        ODSendGrid.Columns("QRTT0").Width = 100

        ODSendGrid.Columns("TICK").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        ODSendGrid.Columns("AFACCTNO").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        ODSendGrid.Columns("ACTYPE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        ODSendGrid.Columns("SYMBOL").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        ODSendGrid.Columns("QUANTITY").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        ODSendGrid.Columns("SELLQTTY").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        ODSendGrid.Columns("SCRQTTY").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        'ODSendGrid.Columns("FACTORQTTY").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        ODSendGrid.Columns("SELLPRICE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        ODSendGrid.Columns("SELLAMT").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        ODSendGrid.Columns("ADDAMOUNT").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        ODSendGrid.Columns("LOSTASSAMT").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        ODSendGrid.Columns("LNRATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        ODSendGrid.Columns("LNRATE_MR").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        ODSendGrid.Columns("LNRATE_MC").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        ODSendGrid.Columns("SCRRATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        ODSendGrid.Columns("OCRATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        ODSendGrid.Columns("DLRATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        ODSendGrid.Columns("QRTT").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        ODSendGrid.Columns("QRTT0").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right

        ODSendGrid.Columns("SELLQTTY").ReadOnly = False
        ODSendGrid.Columns("SELLPRICE").ReadOnly = False


        Me.pnODSendInfo.Controls.Clear()
        Me.pnODSendInfo.Controls.Add(ODSendGrid)
        ODSendGrid.Dock = Windows.Forms.DockStyle.Fill
        'AddHandler ODSendGrid.SelectedRowsChanged, AddressOf ODSendCurrentCellChanged
        If Me.ODSendGrid.DataRowTemplate.Cells.Count >= 0 Then
            For i As Integer = 1 To Me.ODSendGrid.DataRowTemplate.Cells.Count - 1
                AddHandler ODSendGrid.DataRowTemplate.Cells(i).DoubleClick, AddressOf OnView
            Next
        End If

        If Me.ODSendGrid.DataRowTemplate.Cells.Count >= 0 Then
            For i As Integer = 1 To Me.ODSendGrid.DataRowTemplate.Cells.Count - 1
                'AddHandler ODSendGrid.DataRowTemplate.Cells(i).LeavingEdit, AddressOf ODSendLeavingEdit
                AddHandler ODSendGrid.DataRowTemplate.Cells(i).ValueChanged, AddressOf ODSendLeavingEdit
            Next
        End If

        If Me.ODSendGrid.DataRowTemplate.Cells.Count >= 0 Then
            For i As Integer = 1 To Me.ODSendGrid.DataRowTemplate.Cells.Count - 1
                AddHandler ODSendGrid.DataRowTemplate.Cells(i).Click, AddressOf ODSendClickRowChanged
            Next
        End If

        AddHandler ODSendGrid.DataRowTemplate.Cells("TICK").Click, AddressOf ODSendSelectedRowChanged
    End Sub
    Private Function CheckOrderStatus() As String
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

            v_strClause = Trim(CType(ODSendGrid.CurrentRow, Xceed.Grid.DataRow).Cells("ORDERID").Value)

            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_strClause, "CheckOrderStatus", , , , IpAddress)
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            v_lngErrorCode = v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)

            'KiÃ¡Â»Æ’m tra thÃƒÂ´ng tin vÃƒÂ  xÃ¡Â»Â­ lÃƒÂ½ lÃ¡Â»â€”i (nÃ¡ÂºÂ¿u cÃƒÂ³) tÃ¡Â»Â« message trÃ¡ÂºÂ£ vÃ¡Â»?            
            If v_lngErrorCode <> ERR_SYSTEM_OK Then
                'ThÃƒÂ´ng bÃƒÂ¡o lÃ¡Â»â€”i
                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                Cursor.Current = Cursors.Default
                MsgBox(v_strErrorMessage, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, Me.Text)
                Exit Function
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function

    Private Sub LoadODSend(ByVal pv_strSQLCMD As String)
        Try
            If Not ODSendGrid Is Nothing And Len(pv_strSQLCMD) > 0 Then
                'Remove cÃƒÂ¡c bÃ¡ÂºÂ£n ghi cÃ…Â©
                ODSendGrid.DataRows.Clear()
                Dim v_strSQL As String = pv_strSQLCMD
                Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_OD_ODMAST, gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                Dim v_strResourceManager As String

                FillDataGrid(ODSendGrid, v_strObjMsg, "")

                If Me.ODSendGrid.DataRows.Count > 0 Then
                    ODSendGrid.CurrentRow = Me.ODSendGrid.DataRows(0)
                End If
            End If
        Catch ex As Exception
            'MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Sub


#End Region

#Region " Other method "

    Protected Overridable Function InitDialog()
        'KhÃ¡Â»Å¸i tÃ¡ÂºÂ¡o kÃƒÂ­ch thÃ†Â°Ã¡Â»â€ºc form vÃƒÂ  load resource
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        LoadResource(Me)
        ResetScreen(Me)

    End Function

    Private Sub ResetScreen(ByRef pv_ctrl As Windows.Forms.Control)
        Dim i, v_intNumSelected, v_intNum As Integer
        v_intNumSelected = 0
        v_intNum = ODSendGrid.DataRows.Count
        If Me.ODSendGrid.DataRows.Count > 0 Then
            ODSendGrid.CurrentRow = Me.ODSendGrid.DataRows(0)
        End If
    End Sub

    Private Sub OnClose()
        Me.Dispose()
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

    Private Sub ShowSearchFunction(ByVal pv_enable As Boolean)
        If pv_enable = False Then

        End If
    End Sub
    Private Sub OnView(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GetSecuritiesInfo(ByVal v_strCODEID As String, ByVal v_strDEALNO As String, ByVal v_strAcc As String)
        Try
            'Láº¥y thÃ´ng tin v? giÃ¡ chá»©ng khoÃ¡n
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_strValue, v_strFLDNAME, v_strTEXT As String
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_strCmdSQL As String, v_strObjMsg As String
            Dim v_dblLNPrice As Double
            mv_strACCTNO_M = v_strAcc
            Dim v_strPricetype As String = String.Empty

            v_strCmdSQL = " SELECT SEINF.BASICPRICE, SEINF.FLOORPRICE,SEINF.MARGINPRICE, SEINF.CEILINGPRICE, SEINF.SECUREDRATIOMAX, SEINF.SECUREDRATIOMIN, SEINF.TRADELOT,  " & ControlChars.CrLf _
                        & "     SEINF.TRADEUNIT, SEINF.TRADEBUYSELL , SE.PARVALUE, A.VARVALUE TRADING_CYCLE, B.FULLNAME, SE.TRADEPLACE, SE.SECTYPE,  " & ControlChars.CrLf _
                        & "     (CASE WHEN (TO_DATE(SEINF.LISTTINGDATE)=(SELECT TO_DATE(VARVALUE,'DD/MM/YYYY') CURRDATE FROM SYSVAR WHERE VARNAME='CURRDATE'  " & ControlChars.CrLf _
                        & "     AND GRNAME='SYSTEM') AND SE.TRADEPLACE='001') THEN 'Y' ELSE 'N' END ) FIRSTLISTTING, NVL(RSK.MRRATIORATE,0) MRRATIORATE, NVL(RSK.DPRATIORATE,0) DPRATIORATE, NVL(RSK.MRPRICERATE,0) MRPRICERATE ,  " & ControlChars.CrLf _
                        & "     NVL(RSK.MRRATIOLOAN,0) MRRATIOLOAN, NVL(RSK.MRPRICELOAN,0) MRPRICELOAN, NVL(RSK2.MRRATIORATE,0) MRRATIORATE2, NVL(RSK2.MRPRICERATE,0) MRPRICERATE2, ad.*,  " & ControlChars.CrLf _
                        & "     LEAST(NVL(RSK.MRPRICELOAN,0),SEINF.MARGINPRICE) LNPRICE, getnonworkingday(TO_NUMBER(A.VARVALUE)) DAYS " & ControlChars.CrLf _
                        & " FROM SECURITIES_INFO SEINF,SBSECURITIES SE,SYSVAR A, ISSUERS B, (SELECT codeid,MRRATIOLOAN,MRPRICELOAN,MRRATIORATE,DPRATIORATE,MRPRICERATE  FROM AFSERISK WHERE   ACTYPE= '" & v_strDEALNO & "') RSK, (SELECT codeid,MRRATIOLOAN,MRPRICELOAN,MRRATIORATE,MRPRICERATE  FROM AFSERISK74 WHERE   ACTYPE= '" & v_strDEALNO & "') RSK2,  " & ControlChars.CrLf _
                        & "     (select AD.ADVRATE, ADVMINFEE, vw.rtnamountref, vw.ovdamountref, vw.selllostassref, vw.sellamountref, vw.mrirate,  " & ControlChars.CrLf _
                        & "         vw.sellrate, vw.mrrate " & ControlChars.CrLf _
                        & "         fROM ADTYPE AD, AFTYPE AF, AFMAST AFM , vw_mr0003_all vw " & ControlChars.CrLf _
                        & "         WHERE AD.ACTYPE=AF.ADTYPE AND AF.ACTYPE=AFM.ACTYPE AND vw.ACCTNO=AFM.ACCTNO AND AFM.ACCTNO='" & v_strAcc & "' and ROWNUM<=1 " & ControlChars.CrLf _
                        & "     ) ad  " & ControlChars.CrLf _
                        & " WHERE SEINF.CODEID=SE.CODEID AND SEINF.SYMBOL='" & v_strCODEID & "'  " & ControlChars.CrLf _
                        & " AND SE.ISSUERID = B.ISSUERID AND A.GRNAME='OD' AND A.VARNAME='CLEARDAY'  AND SE.CODEID= RSK.CODEID(+) AND SE.CODEID= RSK2.CODEID(+) " & ControlChars.CrLf
                        

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            If v_nodeList.Count >= 1 Then

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
                                Case "TRADEPLACE"
                                    mv_strTradePlace = v_strValue
                                Case "PARVALUE"
                                    mv_dbdParvalue = CDbl(v_strValue)
                                Case "DFRATE"
                                    mv_dblDFRate = CDec(Trim(v_strValue))
                                Case "IRATE"
                                    mv_dblIRate = CDec(Trim(v_strValue))
                                Case "MRATE"
                                    mv_dblMRate = CDec(Trim(v_strValue))
                                Case "NUM"
                                    mv_dblNumDue = CDbl(v_strValue)
                                Case "DFREFPRICE"
                                    mv_dblDFREFPRICE = CDec(Trim(v_strValue))
                                Case "MRRATIORATE"
                                    mv_dblMarginRatioRate = CDec(Trim(v_strValue))
                                Case "DPRATIORATE"
                                    mv_dblDPRatioRate = CDec(Trim(v_strValue))
                                Case "MRPRICERATE"
                                    mv_dblSecMarginPrice = CDec(Trim(v_strValue))
                                Case "MRRATIORATE2"
                                    mv_dblMarginRefRatioRate = CDec(Trim(v_strValue))
                                Case "MRPRICERATE2"
                                    mv_dblSecMarginRefPrice = CDec(Trim(v_strValue))
                                Case "LNPRICE"
                                    v_dblLNPrice = CDbl(v_strValue)

                                    'Cac ty le ung truoc
                                Case "ADVRATE"
                                    mv_dblADVRATE = CDbl(v_strValue)
                                Case "ADVMINFEE"
                                    mv_dblADVMINFEE = CDbl(v_strValue)
                                Case "DAYS"
                                    mv_dblDAYS = CDbl(v_strValue)
                                Case "RTNAMOUNTREF"
                                    mv_dblADDRTNAMOUNT_M = CDbl(v_strValue)
                                Case "OVDAMOUNTREF"
                                    mv_dblOVDAMOUNT_M = CDbl(v_strValue)
                                Case "SELLLOSTASSREF"
                                    mv_dblSELLLOSTASS_M = CDbl(v_strValue)
                                Case "SELLAMOUNTREF"
                                    mv_dblSELLAMOUNT_M = CDbl(v_strValue)
                                Case "MRIRATE"
                                    mv_dblMRIRATE_M = CDbl(v_strValue)
                                Case "SELLRATE"
                                    mv_dblSELLRATE_M = CDbl(v_strValue)
                                Case "MRRATE"
                                    mv_dblMRRATE_M = CDbl(v_strValue)
                            End Select
                        End With
                    Next
                    v_strTEXT = " [" & mv_ResourceManager.GetString("REFPRICE") & mv_dblBasicPrice / mv_dblTradeUnit & "] " & _
                        "[" & mv_ResourceManager.GetString("FLOORPRICE") & mv_dblFloorPrice / mv_dblTradeUnit & "] " & _
                        "[" & mv_ResourceManager.GetString("CEILINGPRICE") & mv_dblCeilingPrice / mv_dblTradeUnit & "] " & _
                        "[" & mv_ResourceManager.GetString("TRADELOT") & mv_dblTradeLot & "] " & _
                        "[" & mv_ResourceManager.GetString("TRADEUNIT") & mv_dblTradeUnit & "] "
                    Me.lblSecinfo.Text = v_strTEXT
                    
                    Me.lblSECRisk.Text = " [" & mv_ResourceManager.GetString("RATIOLOANMR") & mv_dblMarginRatioRate & "] " & _
                        " [" & mv_ResourceManager.GetString("RATIOLOANTC") & mv_dblDPRatioRate & "] " & _
                        "[" & mv_ResourceManager.GetString("LNPRICE") & v_dblLNPrice / mv_dblTradeUnit & "] "

                Next
            Else
                mv_dblBasicPrice = 0
                mv_dblFloorPrice = 0
                mv_dblMarginPrice = 0
                mv_dblCeilingPrice = 0
                mv_dblTradeLot = 0
                mv_dblTradeUnit = 0
                mv_strTradePlace = ""
                mv_dbdParvalue = 0
                mv_dblDFRate = 0
                mv_dblIRate = 0
                mv_dblDFREFPRICE = 0
                mv_dblMarginRatioRate = 0
                mv_dblSecMarginPrice = 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, Me.Text)
        End Try
    End Sub


    Private Sub GetAddSec()
        If AFACCTNO Is Nothing OrElse Me.txtSYMBOL.Text.Trim.Length = 0 Then
            Me.txtSECADD.Text = 0
            Return
        End If
        If ObjectName = "MR0003" Or ObjectName = "MR1003" Then
            If CDbl(ADDRTNAMOUNT) - CDbl(SELLAMOUNT) <= 0 Then ' Khong can bo sung
                Me.txtSECADD.Text = 0
                Return
            End If
            Dim v_strCmdSQL, v_strObjMsg, v_strClause As String
            Dim v_ws As New BDSDeliveryManagement
            Dim v_dec As Decimal
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strValue, v_strFLDNAME As String, i, j As Integer
            Try


                v_strCmdSQL = "pr_getAddSec"
                v_strClause = "p_afacctno!" & AFACCTNO & "!varchar2!10^p_symbol!" & Me.txtSYMBOL.Text.ToUpper & "!varchar2!30^p_addAmount!" & Math.Round(CDbl(SELLAMOUNT), 0) & "!Number!20"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strCmdSQL, v_strClause, , , , , , , gc_CommandProcedure)
                v_ws.Message(v_strObjMsg)
                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

                For i = 0 To v_nodeList.Count - 1
                    For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            v_strValue = Trim(.InnerText.ToString)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME)
                                Case "ADDQTTY"
                                    Me.txtSECADD.Text = Format(Math.Round(CDbl(v_strValue)), gc_FORMAT_NUMBER_0)
                            End Select
                        End With
                    Next
                Next
            Catch ex As Exception
                Throw ex
            End Try
        End If

    End Sub
#End Region

#Region " Event "
    Private Sub ODSendCurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'HiÃ¡Â»Æ’n thÃ¡Â»â€¹ thÃƒÂ´ng tin lÃƒÂªn mÃƒÂ n hÃƒÂ¬nh
        If (ODSendGrid.CurrentRow Is Nothing) Then
            Exit Sub
        End If
    End Sub
    Private Sub ODSendClickRowChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim v_strRef As String
        Dim v_strAcc As String


        v_strRef = CType(ODSendGrid.CurrentRow, Xceed.Grid.DataRow).Cells("ACTYPE").Value
        v_strAcc = CType(ODSendGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AFACCTNO").Value

        GetSecuritiesInfo(CType(ODSendGrid.CurrentRow, Xceed.Grid.DataRow).Cells("SYMBOL").Value, v_strRef, v_strAcc)


    End Sub
    Private Sub ODSendSelectedRowChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim i, m As Integer
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_strValue, v_strFLDNAME, v_strTEXT As String
        Dim v_strCmdSQL As String
        Dim v_ws As New BDSDeliveryManagement
        Dim v_strObjMsg As String

        Try
            Dim v_dblPrice As Double
            If (ODSendGrid.CurrentCell Is Nothing) Then
                Exit Sub
            End If
            If (ODSendGrid.CurrentRow Is ODSendGrid.HeaderRows) Then
                Exit Sub
            End If

            Dim v_strRef As String
            Dim v_strAcc As String

            v_strRef = CType(ODSendGrid.CurrentRow, Xceed.Grid.DataRow).Cells("ACTYPE").Value
            v_strAcc = CType(ODSendGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AFACCTNO").Value

            GetSecuritiesInfo(CType(ODSendGrid.CurrentRow, Xceed.Grid.DataRow).Cells("SYMBOL").Value, v_strRef, v_strAcc)

            If Me.ODSendGrid.DataRows.Count > 0 Then

                For i = 0 To Me.ODSendGrid.DataRows.Count - 1
                    If (ODSendGrid.CurrentCell Is ODSendGrid.DataRows(i).Cells("TICK")) Then
                        'Chuyen trang thai select cho dong nay
                        If ODSendGrid.DataRows(i).Cells("TICK").Value = Nothing Then
                            ODSendGrid.DataRows(i).Cells("TICK").Value = "X"

                            ' Lay loai hinh dat lenh, DEFFEERATE va ADVRATE theo loai hinh ACTYPE cua tieu khoan
                            v_strCmdSQL = " SELECT ACTYPE, ACTYPE VALUECD, ACTYPE VALUE, TYPENAME DISPLAY, TYPENAME EN_DISPLAY,   TYPENAME DESCRIPTION, TRADELIMIT, BRATIO, MINFEEAMT, " & _
                                          " DEFFEERATE, VARVALUE FROM ODTYPE O, SYSVAR, SBSECURITIES S   WHERE O.STATUS='Y' AND ( VIA='F'OR VIA = 'A')   AND CLEARCD='B'   AND (EXECTYPE='NB' OR EXECTYPE='AA') " & _
                                          " AND (O.TIMETYPE='T' OR O.TIMETYPE='A' )  AND (O.PRICETYPE='LO' OR O.PRICETYPE='AA')   AND (O.MATCHTYPE='N' OR O.MATCHTYPE='A')  AND " & _
                                          " (O.TRADEPLACE='001' OR O.TRADEPLACE='000')  AND (INSTR(CASE WHEN S.SECTYPE IN ('001','002') THEN S.SECTYPE || ',111,333' " & _
                                          "      WHEN S.SECTYPE IN ('003','006') THEN S.SECTYPE || ',222,333,444' " & _
                                          "      WHEN S.SECTYPE IN ('008') THEN S.SECTYPE || ',111,444' " & _
                                          "      ELSE S.SECTYPE END, O.SECTYPE) > 0 OR O.SECTYPE = '000' " & _
                                          "  )  AND (NORK='N' OR NORK ='A')  AND VARNAME = 'ADVSELLDUTY' AND S.SYMBOL='" & ODSendGrid.DataRows(i).Cells("SYMBOL").Value & "' AND" & _
                                          " ACTYPE IN (SELECT ACTYPE FROM AFIDTYPE WHERE OBJNAME='OD.ODTYPE' AND AFTYPE ='" & CType(ODSendGrid.CurrentRow, Xceed.Grid.DataRow).Cells("ACTYPE").Value & "')"

                            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
                            v_ws.Message(v_strObjMsg)
                            v_xmlDocument.LoadXml(v_strObjMsg)
                            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

                            For m = 0 To 0
                                v_strTEXT = String.Empty
                                For j As Integer = 0 To v_nodeList.Item(m).ChildNodes.Count - 1
                                    With v_nodeList.Item(m).ChildNodes(j)
                                        v_strValue = Trim(.InnerText.ToString)
                                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                        Select Case Trim(v_strFLDNAME)
                                            Case "DEFFEERATE"
                                                mv_dblDEFFEERATE = CDbl(v_strValue)
                                            Case "VARVALUE"
                                                mv_dblADVSELLDUTY = CDbl(v_strValue)
                                        End Select
                                    End With
                                Next
                            Next



                            If ObjectName = "MR0003" Or ObjectName = "MR1003" Then
                                Dim V_ReturnAmount As Double = 0
                                Dim v_dblReleaseAmount As Double = 0
                                Dim v_dblSELLLOSTASS As Double = 0
                                Dim v_dblSellQtty, v_dblSellQttyOvd, v_dblSellQttyRtt As Double
                                Dim v_dbldblAddOvd, v_dblAddRtt As Double

                                For j As Integer = 0 To Me.ODSendGrid.DataRows.Count - 1
                                    If ODSendGrid.DataRows(j).Cells("TICK").Value = "X" Then
                                        If IsNumeric(ODSendGrid.DataRows(j).Cells("ADDAMOUNT").Value) Then
                                            v_dblReleaseAmount += CDbl(ODSendGrid.DataRows(j).Cells("ADDAMOUNT").Value)
                                        End If
                                        If IsNumeric(ODSendGrid.DataRows(j).Cells("LOSTASSAMT").Value) Then
                                            v_dblSELLLOSTASS += CDbl(ODSendGrid.DataRows(j).Cells("LOSTASSAMT").Value)
                                        End If
                                        'If IsNumeric(ODSendGrid.DataRows(j).Cells("LNRATE").Value) Then
                                        'v_dblLNrate += CDbl(ODSendGrid.DataRows(j).Cells("LNRATE").Value)
                                        'End If
                                    Else
                                        CType(ODSendGrid.DataRows(j), Xceed.Grid.DataRow).Cells("ADDAMOUNT").Value = CDbl("0")
                                        CType(ODSendGrid.DataRows(j), Xceed.Grid.DataRow).Cells("LOSTASSAMT").Value = CDbl("0")
                                        CType(ODSendGrid.DataRows(j), Xceed.Grid.DataRow).Cells("SELLAMT").Value = CDbl("0")
                                    'CType(ODSendGrid.DataRows(j), Xceed.Grid.DataRow).Cells("LNRATE").Value = CDbl("0")
                                    End If
                                Next

                                If (ObjectName <> "MR0003") Then
                                    v_dblAddRtt = CDbl(ADDRTNAMOUNT) - CDbl(SELLAMOUNT) - v_dblReleaseAmount
                                    v_dbldblAddOvd = CDbl(OVDAMOUNT) - CDbl(SELLLOSTASS) - v_dblSELLLOSTASS - CDbl(SELLAMOUNT) - v_dblReleaseAmount
                                    v_dblSellQttyRtt = v_dblAddRtt / (mv_dblFloorPrice * (1 - (mv_dblDEFFEERATE + mv_dblADVSELLDUTY) / 100) / (1 + (mv_dblADVRATE / 100 * mv_dblDAYS) / 360) - IIf(mv_dblSecMarginPrice > mv_dblMarginPrice, mv_dblMarginPrice, mv_dblSecMarginPrice) * mv_dblMarginRatioRate / MRIRATE)
                                    v_dblSellQttyOvd = v_dbldblAddOvd / (mv_dblFloorPrice * (1 - (mv_dblDEFFEERATE + mv_dblADVSELLDUTY) / 100) / (1 + (mv_dblADVRATE / 100 * mv_dblDAYS) / 360))
                                    v_dblSellQtty = Math.Max(v_dblSellQttyRtt, v_dblSellQttyOvd)
                                    v_dblSellQtty = Math.Max(v_dblSellQtty, 0)
                                    v_dblSellQtty = Math.Ceiling(v_dblSellQtty / mv_dblTradeLot) * mv_dblTradeLot
                                    ODSendGrid.DataRows(i).Cells("SELLQTTY").Value = Math.Min(v_dblSellQtty, Math.Floor(CDbl(ODSendGrid.DataRows(i).Cells("QUANTITY").Value) / mv_dblTradeLot) * mv_dblTradeLot)

                                    Try

                                        Dim v_strClause As String
                                        Dim l, k As Integer
                                        Dim v_addQTTYSCR As Double = 0
                                        Dim v_addQRtt As Double = 0
                                        Dim v_addQRtt0 As Double = 0
                                        Dim v_addQFinal As Double = 0
                                        v_strCmdSQL = "pr_mr0003_getAddQTTY"
                                        v_strClause = "p_afacctno!" & ODSendGrid.DataRows(i).Cells("AFACCTNO").Value & "!varchar2!10^p_symbol!" & ODSendGrid.DataRows(i).Cells("SYMBOL").Value & "!varchar2!30^p_sellprice!" & ODSendGrid.DataRows(i).Cells("SELLPRICE").Value & "!varchar2!30^p_feerate!" & mv_dblDEFFEERATE & "!varchar2!30^p_taxrate!" & mv_dblADVSELLDUTY & "!varchar2!30^p_loanprice!" & IIf(mv_dblSecMarginPrice > mv_dblMarginPrice, mv_dblMarginPrice, mv_dblSecMarginPrice) & "!varchar2!30^p_MRRATIORATE!" & CDbl(ODSendGrid.DataRows(i).Cells("LNRATE_MR").Value) & "!varchar2!30^p_DPRATIORATE!" & CDbl(ODSendGrid.DataRows(i).Cells("LNRATE_MC").Value) & "!varchar2!30"
                                        'v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_SA_ALLCODE, gc_ActionInquiry, v_strCmdSQL, v_strClause, , , , , , , gc_CommandProcedure)
                                        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strCmdSQL, v_strClause, , , , , , , gc_CommandProcedure)
                                        v_ws.Message(v_strObjMsg)
                                        v_xmlDocument.LoadXml(v_strObjMsg)
                                        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

                                        For l = 0 To v_nodeList.Count - 1
                                            For k = 0 To v_nodeList.Item(l).ChildNodes.Count - 1
                                                With v_nodeList.Item(l).ChildNodes(k)
                                                    v_strValue = Trim(.InnerText.ToString)
                                                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                                    Select Case Trim(v_strFLDNAME)
                                                        Case "QG"
                                                            v_addQTTYSCR = Format(Math.Round(CDbl(v_strValue)), gc_FORMAT_NUMBER_0)
                                                        Case "QRTT"
                                                            v_addQRtt = Format(Math.Round(CDbl(v_strValue)), gc_FORMAT_NUMBER_0)
                                                        Case "QRTT0"
                                                            v_addQRtt0 = Format(Math.Round(CDbl(v_strValue)), gc_FORMAT_NUMBER_0)
                                                        Case "QFINAL"
                                                            v_addQFinal = Format(Math.Round(CDbl(v_strValue)), gc_FORMAT_NUMBER_0)
                                                    End Select
                                                End With
                                            Next
                                        Next
                                        v_addQTTYSCR = Math.Ceiling(v_addQTTYSCR / mv_dblTradeLot) * mv_dblTradeLot
                                        ODSendGrid.DataRows(i).Cells("SCRQTTY").Value = v_addQTTYSCR
                                        v_addQRtt = Math.Ceiling(v_addQRtt / mv_dblTradeLot) * mv_dblTradeLot
                                        ODSendGrid.DataRows(i).Cells("QRTT").Value = v_addQRtt
                                        v_addQRtt0 = Math.Ceiling(v_addQRtt0 / mv_dblTradeLot) * mv_dblTradeLot
                                        ODSendGrid.DataRows(i).Cells("QRTT0").Value = v_addQRtt0
                                        v_addQFinal = Math.Ceiling(v_addQFinal / mv_dblTradeLot) * mv_dblTradeLot
                                        'ODSendGrid.DataRows(i).Cells("SELLQTTY").Value = v_addQFinal
                                        ODSendGrid.DataRows(i).Cells("SELLQTTY").Value = Math.Min(v_addQFinal, Math.Floor(CDbl(ODSendGrid.DataRows(i).Cells("QUANTITY").Value) / mv_dblTradeLot) * mv_dblTradeLot)

                                        'Dim v_addVND As Double
                                        'v_strCmdSQL = "pr_mr0003_addvnd"
                                        'v_strClause = "p_afacctno!" & ODSendGrid.DataRows(i).Cells("AFACCTNO").Value & "!varchar2!10^p_oldaddvnd!" & CDbl(lblvBfOdrAMT_G.Text) & "!varchar2!30^p_sellprice!" & ODSendGrid.DataRows(i).Cells("SELLPRICE").Value & "!varchar2!30^p_sellqtty!" & ODSendGrid.DataRows(i).Cells("SELLQTTY").Value & "!varchar2!30^p_feerate!" & mv_dblDEFFEERATE & "!varchar2!30^p_taxrate!" & mv_dblADVSELLDUTY & "!varchar2!30^p_groupid!" & GROUPID & "!varchar2!10"
                                        'v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_SA_ALLCODE, gc_ActionInquiry, v_strCmdSQL, v_strClause, , , , , , , gc_CommandProcedure)
                                        'v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strCmdSQL, v_strClause, , , , , , , gc_CommandProcedure)
                                        'v_ws.Message(v_strObjMsg)
                                        'v_xmlDocument.LoadXml(v_strObjMsg)
                                        'v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

                                        'For l = 0 To v_nodeList.Count - 1
                                        'For k = 0 To v_nodeList.Item(l).ChildNodes.Count - 1
                                        'With v_nodeList.Item(l).ChildNodes(k)
                                        'v_strValue = Trim(.InnerText.ToString)
                                        'v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                        'Select Case Trim(v_strFLDNAME)
                                        '    Case "ADDVND"
                                        'v_addVND = Format(Math.Round(CDbl(v_strValue)), gc_FORMAT_NUMBER_0)

                                        'End Select
                                        'End With
                                        'Next
                                        'Next

                                        'Me.lblvLstOdrAMT_G.Text = Format(v_addVND, "#,##0")
                                        'If IsNumeric(Me.lblvLstOdrAMT_G.Text) AndAlso CDbl(Me.lblvLstOdrAMT_G.Text) > 0 Then
                                        'Me.lblvLstOdrAMT_G.ForeColor = Color.Red
                                        'Else
                                        'Me.lblvLstOdrAMT_G.ForeColor = Color.Black
                                        'End If

                                    Catch ex As Exception
                                        Throw ex
                                    End Try
                                Else
                                    v_dblAddRtt = CDbl(ADDRTNAMOUNT) - CDbl(SELLAMOUNT) - v_dblReleaseAmount
                                    v_dbldblAddOvd = CDbl(OVDAMOUNT) - CDbl(SELLLOSTASS) - v_dblSELLLOSTASS - CDbl(SELLAMOUNT) - v_dblReleaseAmount

                                    v_dblSellQttyRtt = v_dblAddRtt / (mv_dblFloorPrice * (1 - (mv_dblDEFFEERATE + mv_dblADVSELLDUTY) / 100) / (1 + (mv_dblADVRATE / 100 * mv_dblDAYS) / 360) - IIf(mv_dblSecMarginPrice > mv_dblMarginPrice, mv_dblMarginPrice, mv_dblSecMarginPrice) * mv_dblMarginRatioRate / mv_dblMRIRATE)
                                    v_dblSellQttyOvd = v_dbldblAddOvd / mv_dblFloorPrice * (1 - (mv_dblDEFFEERATE + mv_dblADVSELLDUTY) / 100) / (1 + (mv_dblADVRATE / 100 * mv_dblDAYS) / 360)


                                    Try

                                        Dim v_strClause As String
                                        Dim l, k As Integer
                                        Dim v_addQTTYSCR As Double = 0
                                        Dim v_addQRtt As Double = 0
                                        Dim v_addQRtt0 As Double = 0
                                        Dim v_addQFinal As Double = 0
                                        v_strCmdSQL = "pr_mr0003_getAddQTTY"
                                        v_strClause = "p_afacctno!" & ODSendGrid.DataRows(i).Cells("AFACCTNO").Value & "!varchar2!10^p_symbol!" & ODSendGrid.DataRows(i).Cells("SYMBOL").Value & "!varchar2!30^p_sellprice!" & ODSendGrid.DataRows(i).Cells("SELLPRICE").Value & "!varchar2!30^p_feerate!" & mv_dblDEFFEERATE & "!varchar2!30^p_taxrate!" & mv_dblADVSELLDUTY & "!varchar2!30^p_loanprice!" & IIf(mv_dblSecMarginPrice > mv_dblMarginPrice, mv_dblMarginPrice, mv_dblSecMarginPrice) & "!varchar2!30^p_MRRATIORATE!" & CDbl(ODSendGrid.DataRows(i).Cells("LNRATE_MR").Value) & "!varchar2!30^p_DPRATIORATE!" & CDbl(ODSendGrid.DataRows(i).Cells("LNRATE_MC").Value) & "!varchar2!30"
                                        'v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_SA_ALLCODE, gc_ActionInquiry, v_strCmdSQL, v_strClause, , , , , , , gc_CommandProcedure)
                                        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strCmdSQL, v_strClause, , , , , , , gc_CommandProcedure)
                                        v_ws.Message(v_strObjMsg)
                                        v_xmlDocument.LoadXml(v_strObjMsg)
                                        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

                                        For l = 0 To v_nodeList.Count - 1
                                            For k = 0 To v_nodeList.Item(l).ChildNodes.Count - 1
                                                With v_nodeList.Item(l).ChildNodes(k)
                                                    v_strValue = Trim(.InnerText.ToString)
                                                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                                    Select Case Trim(v_strFLDNAME)
                                                        Case "QG"
                                                            v_addQTTYSCR = Format(Math.Round(CDbl(v_strValue)), gc_FORMAT_NUMBER_0)
                                                        Case "QRTT"
                                                            v_addQRtt = Format(Math.Round(CDbl(v_strValue)), gc_FORMAT_NUMBER_0)
                                                        Case "QRTT0"
                                                            v_addQRtt0 = Format(Math.Round(CDbl(v_strValue)), gc_FORMAT_NUMBER_0)
                                                        Case "QFINAL"
                                                            v_addQFinal = Format(Math.Round(CDbl(v_strValue)), gc_FORMAT_NUMBER_0)
                                                    End Select
                                                End With
                                            Next
                                        Next
                                        v_addQTTYSCR = Math.Ceiling(v_addQTTYSCR / mv_dblTradeLot) * mv_dblTradeLot
                                        ODSendGrid.DataRows(i).Cells("SCRQTTY").Value = v_addQTTYSCR
                                        v_addQRtt = Math.Ceiling(v_addQRtt / mv_dblTradeLot) * mv_dblTradeLot
                                        ODSendGrid.DataRows(i).Cells("QRTT").Value = v_addQRtt
                                        v_addQRtt0 = Math.Ceiling(v_addQRtt0 / mv_dblTradeLot) * mv_dblTradeLot
                                        ODSendGrid.DataRows(i).Cells("QRTT0").Value = v_addQRtt0
                                        v_addQFinal = Math.Ceiling(v_addQFinal / mv_dblTradeLot) * mv_dblTradeLot
                                        'ODSendGrid.DataRows(i).Cells("SELLQTTY").Value = v_addQFinal
                                        ODSendGrid.DataRows(i).Cells("SELLQTTY").Value = Math.Min(v_addQFinal, Math.Floor(CDbl(ODSendGrid.DataRows(i).Cells("QUANTITY").Value) / mv_dblTradeLot) * mv_dblTradeLot)

                                        'Dim v_addVND As Double
                                        'v_strCmdSQL = "pr_mr0003_addvnd"
                                        'v_strClause = "p_afacctno!" & ODSendGrid.DataRows(i).Cells("AFACCTNO").Value & "!varchar2!10^p_oldaddvnd!" & CDbl(lblvBfOdrAMT.Text) & "!varchar2!30^p_sellprice!" & ODSendGrid.DataRows(i).Cells("SELLPRICE").Value & "!varchar2!30^p_sellqtty!" & ODSendGrid.DataRows(i).Cells("SELLQTTY").Value & "!varchar2!30^p_feerate!" & mv_dblDEFFEERATE & "!varchar2!30^p_taxrate!" & mv_dblADVSELLDUTY & "!varchar2!30"

                                        'v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strCmdSQL, v_strClause, , , , , , , gc_CommandProcedure)
                                        'v_ws.Message(v_strObjMsg)
                                        'v_xmlDocument.LoadXml(v_strObjMsg)
                                        'v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

                                        'For l = 0 To v_nodeList.Count - 1
                                        'For k = 0 To v_nodeList.Item(l).ChildNodes.Count - 1
                                        'With v_nodeList.Item(l).ChildNodes(k)
                                        'v_strValue = Trim(.InnerText.ToString)
                                        'v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                        'Select Case Trim(v_strFLDNAME)
                                        'Case "ADDVND"
                                        'v_addVND = Format(Math.Round(CDbl(v_strValue)), gc_FORMAT_NUMBER_0)

                                        'End Select
                                        'End With
                                        'Next
                                        'Next

                                        'Me.lblvLstOdrAMT.Text = Format(v_addVND, "#,##0")
                                        'If IsNumeric(Me.lblvLstOdrAMT.Text) AndAlso CDbl(Me.lblvLstOdrAMT.Text) > 0 Then
                                        'Me.lblvLstOdrAMT.ForeColor = Color.Red
                                        'Else
                                        'Me.lblvLstOdrAMT.ForeColor = Color.Black
                                        'End If

                                    Catch ex As Exception
                                        Throw ex
                                    End Try
                                    


                                End If

                            End If
                            'Set lai cac thong tion cho Grid
                            SetGridValue(ODSendGrid.DataRows(i))

                        Else
                            ODSendGrid.DataRows(i).Cells("TICK").Value = Nothing
                            ODSendGrid.DataRows(i).Cells("ADDAMOUNT").Value = Nothing
                            ODSendGrid.DataRows(i).Cells("SCRQTTY").Value = Nothing
                            ODSendGrid.DataRows(i).Cells("QRTT").Value = Nothing
                            ODSendGrid.DataRows(i).Cells("QRTT0").Value = Nothing
                            ODSendGrid.DataRows(i).Cells("SELLQTTY").Value = ODSendGrid.DataRows(i).Cells("QUANTITY").Value
                        End If
                        'Exit For
                    Else
                        ODSendGrid.DataRows(i).Cells("TICK").Value = Nothing
                        ODSendGrid.DataRows(i).Cells("SCRQTTY").Value = Nothing
                        ODSendGrid.DataRows(i).Cells("QRTT").Value = Nothing
                        ODSendGrid.DataRows(i).Cells("QRTT0").Value = Nothing
                        ODSendGrid.DataRows(i).Cells("SELLQTTY").Value = ODSendGrid.DataRows(i).Cells("QUANTITY").Value
                    End If
                Next
            End If
            SetLeftAmount()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub SetGridValue(ByVal v_DataRow As Xceed.Grid.CellRow)
        Dim v_dblPrice As Double
        Dim v_blOrderType As Boolean
        Dim v_dblSellAmount, v_dblReceivingAmount As Double
        Dim v_dblLossAssest As Double
        If v_DataRow.Cells("SELLPRICE").Value = "ATC" Or v_DataRow.Cells("SELLPRICE").Value = "ATO" Or v_DataRow.Cells("SELLPRICE").Value = "MP" Or v_DataRow.Cells("SELLPRICE").Value = "MTL" Or v_DataRow.Cells("SELLPRICE").Value = "MAK" Or v_DataRow.Cells("SELLPRICE").Value = "MOK" Then
            v_blOrderType = True
        Else
            v_blOrderType = False
        End If

        v_dblSellAmount = CDbl(IIf(v_blOrderType = True, mv_dblFloorPrice / mv_dblTradeUnit, v_DataRow.Cells("SELLPRICE").Value) * v_DataRow.Cells("SELLQTTY").Value * mv_dblTradeUnit * (1 - (mv_dblDEFFEERATE + mv_dblADVSELLDUTY) / 100 - Math.Round((mv_dblADVRATE / 100 * mv_dblDAYS) / 360, 7)))
        v_dblLossAssest = IIf(mv_dblSecMarginPrice > mv_dblMarginPrice, mv_dblMarginPrice, mv_dblSecMarginPrice) * v_DataRow.Cells("SELLQTTY").Value * v_DataRow.Cells("LNRATE").Value / mv_dblSELLRATE
        v_dblReceivingAmount = Math.Min(v_dblSellAmount * (1 - (mv_dblADVRATE / 100 * mv_dblDAYS) / 360), v_dblSellAmount - mv_dblADVMINFEE)
        
        If ObjectName = "MR0003" Or ObjectName = "MR1003" Then
            'v_DataRow.Cells("ADDAMOUNT").Value = FRound(CDbl(IIf(v_blOrderType = True, mv_dblFloorPrice / mv_dblTradeUnit, v_DataRow.Cells("SELLPRICE").Value) * v_DataRow.Cells("SELLQTTY").Value * mv_dblTradeUnit * (1 - (mv_dblDEFFEERATE + mv_dblADVSELLDUTY) / 100) * (1 - (mv_dblADVRATE / 100 * 3) / 360) - IIf(mv_dblSecMarginPrice > mv_dblMarginPrice, mv_dblMarginPrice, mv_dblSecMarginPrice) * v_DataRow.Cells("SELLQTTY").Value * mv_dblMarginRatioRate / MRIRATE), 0)
            'v_DataRow.Cells("LOSTASSAMT").Value = IIf(mv_dblSecMarginPrice > mv_dblMarginPrice, mv_dblMarginPrice, mv_dblSecMarginPrice) * v_DataRow.Cells("SELLQTTY").Value * mv_dblMarginRatioRate / MRIRATE
            v_DataRow.Cells("SELLAMT").Value = FRound(v_dblSellAmount, 0)
            v_DataRow.Cells("ADDAMOUNT").Value = FRound(v_dblReceivingAmount - v_dblLossAssest, 0)
            v_DataRow.Cells("LOSTASSAMT").Value = FRound(v_dblLossAssest, 0)

            
        Else
            v_DataRow.Cells("ADDAMOUNT").Value = FRound(CDbl(IIf(v_blOrderType = True, mv_dblFloorPrice / mv_dblTradeUnit, v_DataRow.Cells("SELLPRICE").Value) * v_DataRow.Cells("SELLQTTY").Value * mv_dblTradeUnit * (1 - (mv_dblDEFFEERATE + mv_dblADVSELLDUTY) / 100) / (1 + (mv_dblADVRATE / 100 * mv_dblDAYS) / 365) - IIf(mv_dblSecMarginPrice > mv_dblMarginPrice, mv_dblMarginPrice, mv_dblSecMarginPrice) * v_DataRow.Cells("SELLQTTY").Value * mv_dblMarginRatioRate / MRIRATE), 0)
        End If
    End Sub

    Private Sub SetLeftAmount()
        Dim V_ReturnAmount As Double = 0
        Dim v_dblReleaseAmount As Double = 0
        Dim v_dblSELLLOSTASS As Double = 0
        Dim V_ReturnAmount_M As Double = 0
        Dim v_dblReleaseAmount_M As Double = 0
        Dim v_dblSELLLOSTASS_M As Double = 0

        If (ODSendGrid.CurrentCell Is Nothing) Then
            Exit Sub
        End If

        If (ODSendGrid.CurrentRow Is ODSendGrid.HeaderRows) Then
            Exit Sub
        End If

        Dim v_dblAddamount As Double = CDbl(IIf(IsNumeric(Me.lblAddAmt.Text), Me.lblAddAmt.Text, 0))
        If (ObjectName = "MR1003") Then
            v_dblAddamount = CDbl(IIf(IsNumeric(Me.lblvLstOdrAMT_G.Text), Me.lblvLstOdrAMT_G.Text, 0))
        End If
        Me.lblvLstOdrAMT.Text = Me.lblvBfOdrAMT.Text
        Me.lblvLstOdrAMT_G.Text = Me.lblvBfOdrAMT_G.Text
        If ObjectName = "MR0003" Or ObjectName = "MR1003" Then
            For i As Integer = 0 To Me.ODSendGrid.DataRows.Count - 1
                If ODSendGrid.DataRows(i).Cells("TICK").Value = "X" Then
                    If IsNumeric(ODSendGrid.DataRows(i).Cells("ADDAMOUNT").Value) Then
                        v_dblReleaseAmount += CDbl(ODSendGrid.DataRows(i).Cells("ADDAMOUNT").Value)
                    End If
                    If IsNumeric(ODSendGrid.DataRows(i).Cells("LOSTASSAMT").Value) Then
                        v_dblSELLLOSTASS += CDbl(ODSendGrid.DataRows(i).Cells("LOSTASSAMT").Value)
                    End If

                    If IsNumeric(ODSendGrid.DataRows(i).Cells("ADDAMOUNT").Value) And ODSendGrid.DataRows(i).Cells("AFACCTNO").Value = AFACCTNO Then
                        v_dblReleaseAmount_M += CDbl(ODSendGrid.DataRows(i).Cells("ADDAMOUNT").Value)
                    End If
                    If IsNumeric(ODSendGrid.DataRows(i).Cells("LOSTASSAMT").Value) And ODSendGrid.DataRows(i).Cells("AFACCTNO").Value = AFACCTNO Then
                        v_dblSELLLOSTASS_M += CDbl(ODSendGrid.DataRows(i).Cells("LOSTASSAMT").Value)
                    End If

                    Try
                        Dim v_nodeList As Xml.XmlNodeList
                        Dim v_xmlDocument As New Xml.XmlDocument
                        Dim v_strValue, v_strFLDNAME, v_strTEXT As String
                        Dim v_strCmdSQL As String
                        Dim v_ws As New BDSDeliveryManagement
                        Dim v_strClause, v_strObjMsg As String
                        Dim v_addVND As Double
                        v_strCmdSQL = "pr_mr0003_addvnd"
                        If (ObjectName = "MR0003") Then
                            v_strClause = "p_afacctno!" & ODSendGrid.DataRows(i).Cells("AFACCTNO").Value & "!varchar2!10^p_symbol!" & ODSendGrid.DataRows(i).Cells("SYMBOL").Value & "!varchar2!30^p_oldaddvnd!" & CDbl(lblvBfOdrAMT.Text) & "!varchar2!30^p_sellprice!" & ODSendGrid.DataRows(i).Cells("SELLPRICE").Value & "!varchar2!30^p_sellqtty!" & ODSendGrid.DataRows(i).Cells("SELLQTTY").Value & "!varchar2!30^p_feerate!" & mv_dblDEFFEERATE & "!varchar2!30^p_taxrate!" & mv_dblADVSELLDUTY & "!varchar2!30^p_mrratiorate!" & CDbl(ODSendGrid.DataRows(i).Cells("LNRATE_MR").Value) & "!varchar2!30^p_dpratiorate!" & CDbl(ODSendGrid.DataRows(i).Cells("LNRATE_MC").Value) & "!varchar2!30^p_groupid!_!varchar2!10"
                        Else
                            v_strClause = "p_afacctno!" & ODSendGrid.DataRows(i).Cells("AFACCTNO").Value & "!varchar2!10^p_symbol!" & ODSendGrid.DataRows(i).Cells("SYMBOL").Value & "!varchar2!30^p_oldaddvnd!" & CDbl(lblvBfOdrAMT_G.Text) & "!varchar2!30^p_sellprice!" & ODSendGrid.DataRows(i).Cells("SELLPRICE").Value & "!varchar2!30^p_sellqtty!" & ODSendGrid.DataRows(i).Cells("SELLQTTY").Value & "!varchar2!30^p_feerate!" & mv_dblDEFFEERATE & "!varchar2!30^p_taxrate!" & mv_dblADVSELLDUTY & "!varchar2!30^p_mrratiorate!" & CDbl(ODSendGrid.DataRows(i).Cells("LNRATE_MR").Value) & "!varchar2!30^p_dpratiorate!" & CDbl(ODSendGrid.DataRows(i).Cells("LNRATE_MC").Value) & "!varchar2!30^p_groupid!" & GROUPID & "!varchar2!10"
                        End If
                        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strCmdSQL, v_strClause, , , , , , , gc_CommandProcedure)
                        v_ws.Message(v_strObjMsg)
                        v_xmlDocument.LoadXml(v_strObjMsg)
                        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                        Dim l, k As Integer
                        For l = 0 To v_nodeList.Count - 1
                            For k = 0 To v_nodeList.Item(l).ChildNodes.Count - 1
                                With v_nodeList.Item(l).ChildNodes(k)
                                    v_strValue = Trim(.InnerText.ToString)
                                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                    Select Case Trim(v_strFLDNAME)
                                        Case "ADDVND"
                                            v_addVND = Format(Math.Round(CDbl(v_strValue)), gc_FORMAT_NUMBER_0)

                                    End Select
                                End With
                            Next
                        Next
                        If (ObjectName = "MR0003") Then
                            Me.lblvLstOdrAMT.Text = Format(v_addVND, "#,##0")
                            
                        Else
                            Me.lblvLstOdrAMT_G.Text = Format(v_addVND, "#,##0")
                            
                        End If
                    Catch ex As Exception
                        Throw ex
                    End Try
                Else
                    CType(ODSendGrid.DataRows(i), Xceed.Grid.DataRow).Cells("ADDAMOUNT").Value = CDbl("0")
                    CType(ODSendGrid.DataRows(i), Xceed.Grid.DataRow).Cells("LOSTASSAMT").Value = CDbl("0")
                    CType(ODSendGrid.DataRows(i), Xceed.Grid.DataRow).Cells("SELLAMT").Value = CDbl("0")
                End If
            Next



            'If ObjectName = "MR1003" Then

            'V_ReturnAmount_M = Math.Max(mv_dblADDRTNAMOUNT_M - mv_dblSELLAMOUNT_M - v_dblReleaseAmount_M, mv_dblOVDAMOUNT_M - mv_dblSELLLOSTASS_M - v_dblSELLLOSTASS_M - mv_dblSELLAMOUNT_M - v_dblReleaseAmount_M)

            'V_ReturnAmount = Math.Max(CDbl(ADDRTNAMOUNT) - CDbl(SELLAMOUNT) - v_dblReleaseAmount, CDbl(OVDAMOUNT) - CDbl(SELLLOSTASS) - v_dblSELLLOSTASS - CDbl(SELLAMOUNT) - v_dblReleaseAmount)
            'Else
            'V_ReturnAmount = Math.Max(CDbl(ADDRTNAMOUNT) - CDbl(SELLAMOUNT) - v_dblReleaseAmount, CDbl(OVDAMOUNT) - CDbl(SELLLOSTASS) - v_dblSELLLOSTASS - CDbl(SELLAMOUNT) - v_dblReleaseAmount)
            'End If


            'If ObjectName = "MR1003" Then
            'Me.lblvLstOdrAMT_G.Text = Format(V_ReturnAmount, "#,##0")
            'If mv_strACCTNO_M = AFACCTNO Then
            'Me.lblLeftAMT.Text = Format(V_ReturnAmount_M, "#,##0")
            'Me.lblvLstOdrAMT.Text = Format(V_ReturnAmount_M, "#,##0")
            'End If

        Else
            Me.lblLeftAMT.Text = Format(V_ReturnAmount, "#,##0")
            Me.lblvLstOdrAMT.Text = Format(V_ReturnAmount, "#,##0")
        End If

        'Else
        'For i As Integer = 0 To Me.ODSendGrid.DataRows.Count - 1
        'If ODSendGrid.DataRows(i).Cells("TICK").Value = "X" Then
        'If IsNumeric(ODSendGrid.DataRows(i).Cells("ADDAMOUNT").Value) Then
        'v_dblReleaseAmount += CDbl(ODSendGrid.DataRows(i).Cells("ADDAMOUNT").Value)
        'End If
        'Else
        'CType(ODSendGrid.DataRows(i), Xceed.Grid.DataRow).Cells("ADDAMOUNT").Value = CDbl("0")
        'End If
        'Next

        'V_ReturnAmount = RTNAMOUNT + v_dblReleaseAmount
        'Me.lblLeftAMT.Text = Format(v_dblAddamount - V_ReturnAmount, "#,##0")
        'Me.lblvLstOdrAMT.Text = Format(v_dblAddamount - V_ReturnAmount, "#,##0")

        'End If

        'If IsNumeric(Me.lblLeftAMT.Text) AndAlso CDbl(Me.lblLeftAMT.Text) > 0 Then
        'Me.lblLeftAMT.ForeColor = Color.Red
        'Else
        'Me.lblLeftAMT.ForeColor = Color.Green
        'End If

        If IsNumeric(Me.lblvLstOdrAMT.Text) AndAlso CDbl(Me.lblvLstOdrAMT.Text) > 0 Then
            Me.lblvLstOdrAMT.ForeColor = Color.Red
        Else
            Me.lblvLstOdrAMT.ForeColor = Color.Black
        End If

        If IsNumeric(Me.lblvLstOdrAMT_G.Text) AndAlso CDbl(Me.lblvLstOdrAMT_G.Text) > 0 Then
            Me.lblvLstOdrAMT_G.ForeColor = Color.Red
        Else
            Me.lblvLstOdrAMT_G.ForeColor = Color.Black
        End If

    End Sub

    'Private Sub ODSendLeavingEdit(ByVal sender As Object, ByVal e As Xceed.Grid.LeavingEditEventArgs)
    Private Sub ODSendLeavingEdit(ByVal sender As Object, ByVal e As System.EventArgs)
        'Lay thong tin ve chung khoan

        If (ODSendGrid.CurrentCell Is Nothing) Then
            Exit Sub
        End If
        If (ODSendGrid.CurrentRow Is ODSendGrid.HeaderRows) Then
            Exit Sub
        End If
        'GetSecuritiesInfo(ODSendGrid.CurrentCell.ParentRow.Cells("SYMBOL").Value, ODSendGrid.CurrentCell.ParentRow.Cells("DEALNO").Value)
        Dim i As Integer
        Dim v_dblPrice As Double
        If Me.ODSendGrid.DataRows.Count > 0 Then
            For i = 0 To Me.ODSendGrid.DataRows.Count - 1
                If (ODSendGrid.CurrentCell Is ODSendGrid.DataRows(i).Cells("SELLQTTY")) Then
                    'Chuyen trang thai select cho dong nay
                    If Not IsNumeric(ODSendGrid.CurrentCell.Value) Then
                        MessageBox.Show(mv_ResourceManager.GetString("ERR_INV_NUMBER"))
                        ODSendGrid.DataRows(i).Cells("SELLQTTY").Value = Math.Floor(ODSendGrid.DataRows(i).Cells("QUANTITY").Value / mv_dblTradeLot) * mv_dblTradeLot
                        'e.Cancel = True
                        'Exit Sub
                    Else
                        If CDbl(ODSendGrid.CurrentCell.Value) Mod mv_dblTradeLot <> 0 Then
                            MessageBox.Show(mv_ResourceManager.GetString("ERR_INV_TRADELOT"))
                            ODSendGrid.DataRows(i).Cells("SELLQTTY").Value = Math.Floor(ODSendGrid.DataRows(i).Cells("QUANTITY").Value / mv_dblTradeLot) * mv_dblTradeLot
                            'e.Cancel = True
                            'Exit Sub
                        End If
                        If CDbl(ODSendGrid.CurrentCell.Value) > ODSendGrid.DataRows(i).Cells("QUANTITY").Value Then
                            MessageBox.Show(mv_ResourceManager.GetString("ERR_INV_OVRQTTY"))
                            ODSendGrid.DataRows(i).Cells("SELLQTTY").Value = Math.Floor(ODSendGrid.DataRows(i).Cells("QUANTITY").Value / mv_dblTradeLot) * mv_dblTradeLot
                            'e.Cancel = True
                            'Exit Sub
                        End If
                    End If
                    If ODSendGrid.DataRows(i).Cells("TICK").Value = "X" Then

                        SetGridValue(ODSendGrid.DataRows(i))

                    End If
                    SetLeftAmount()
                ElseIf (ODSendGrid.CurrentCell Is ODSendGrid.DataRows(i).Cells("SELLPRICE")) Then
                    If Not IsNumeric(ODSendGrid.CurrentCell.Value) Then
                        If mv_strTradePlace = "001" Then
                            'San HOSE
                            If (UCase(CStr(ODSendGrid.CurrentCell.Value)) <> "ATO" And UCase(CStr(ODSendGrid.CurrentCell.Value)) <> "ATC" And UCase(CStr(ODSendGrid.CurrentCell.Value)) <> "MP") Then
                                MessageBox.Show("Price must be ATO, ATC, MP or valid limit price!")
                                ODSendGrid.DataRows(i).Cells("SELLPRICE").Value = CStr(mv_dblBasicPrice / mv_dblTradeUnit)
                                'e.Cancel = True
                                'Exit Sub
                            Else
                                ODSendGrid.CurrentCell.Value = UCase(ODSendGrid.CurrentCell.Value)
                            End If
                        ElseIf mv_strTradePlace = "002" Then
                            'San HASE
                            ' MessageBox.Show("Price must be valid limit price!")
                            ' ODSendGrid.DataRows(i).Cells("SELLPRICE").Value = CStr(mv_dblBasicPrice / mv_dblTradeUnit)
                            If (UCase(CStr(ODSendGrid.CurrentCell.Value)) <> "ATO" And UCase(CStr(ODSendGrid.CurrentCell.Value)) <> "ATC" And UCase(CStr(ODSendGrid.CurrentCell.Value)) <> "MOK" And UCase(CStr(ODSendGrid.CurrentCell.Value)) <> "MAK" And UCase(CStr(ODSendGrid.CurrentCell.Value)) <> "MTL") Then
                                MessageBox.Show(mv_ResourceManager.GetString("ERR_INV_PRICE"))
                                ODSendGrid.DataRows(i).Cells("SELLPRICE").Value = CStr(mv_dblBasicPrice / mv_dblTradeUnit)
                                'e.Cancel = True
                                'Exit Sub
                            Else
                                ODSendGrid.CurrentCell.Value = UCase(ODSendGrid.CurrentCell.Value)
                            End If
                            'e.Cancel = True
                            'Exit Sub
                        Else
                            MessageBox.Show(mv_ResourceManager.GetString("ERR_INV_LIMITPRICE"))
                            ODSendGrid.DataRows(i).Cells("SELLPRICE").Value = CStr(mv_dblBasicPrice / mv_dblTradeUnit)
                            'e.Cancel = True
                            'Exit Sub
                        End If
                        If ODSendGrid.DataRows(i).Cells("TICK").Value = "X" Then

                            SetGridValue(ODSendGrid.DataRows(i))

                        End If
                    Else
                        'Gia limit
                        'Phai dung ticksize, tran san
                        If CDbl(ODSendGrid.CurrentCell.Value) * mv_dblTradeUnit > mv_dblCeilingPrice Or CDbl(ODSendGrid.CurrentCell.Value) * mv_dblTradeUnit < mv_dblFloorPrice Then
                            MessageBox.Show(mv_ResourceManager.GetString("ERR_INV_FCPRICE"))
                            ODSendGrid.DataRows(i).Cells("SELLPRICE").Value = CStr(mv_dblBasicPrice / mv_dblTradeUnit)
                            'e.Cancel = True
                            'Exit Sub
                        End If
                        If ODSendGrid.DataRows(i).Cells("TICK").Value = "X" Then

                            SetGridValue(ODSendGrid.DataRows(i))
                            Try

                                'Dim i, m As Integer
                                Dim v_nodeList As Xml.XmlNodeList
                                Dim v_xmlDocument As New Xml.XmlDocument
                                Dim v_strValue, v_strFLDNAME, v_strTEXT As String
                                Dim v_strCmdSQL As String
                                Dim v_ws As New BDSDeliveryManagement
                                Dim v_strObjMsg As String

                                Dim v_strClause As String
                                Dim l, k As Integer
                                Dim v_addQTTYSCR As Double = 0
                                Dim v_addQRtt As Double = 0
                                Dim v_addQRtt0 As Double = 0
                                Dim v_addQFinal As Double = 0
                                Dim v_strRef As String
                                Dim v_strAcc As String

                                v_strRef = ODSendGrid.DataRows(i).Cells("ACTYPE").Value
                                v_strAcc = ODSendGrid.DataRows(i).Cells("AFACCTNO").Value
                                GetSecuritiesInfo(ODSendGrid.DataRows(i).Cells("SYMBOL").Value, v_strRef, v_strAcc)

                                v_strCmdSQL = "pr_mr0003_getAddQTTY"
                                v_strClause = "p_afacctno!" & ODSendGrid.DataRows(i).Cells("AFACCTNO").Value & "!varchar2!10^p_symbol!" & ODSendGrid.DataRows(i).Cells("SYMBOL").Value & "!varchar2!30^p_sellprice!" & ODSendGrid.DataRows(i).Cells("SELLPRICE").Value & "!varchar2!30^p_feerate!" & mv_dblDEFFEERATE & "!varchar2!30^p_taxrate!" & mv_dblADVSELLDUTY & "!varchar2!30^p_loanprice!" & IIf(mv_dblSecMarginPrice > mv_dblMarginPrice, mv_dblMarginPrice, mv_dblSecMarginPrice) & "!varchar2!30^p_MRRATIORATE!" & CDbl(ODSendGrid.DataRows(i).Cells("LNRATE_MR").Value) & "!varchar2!30^p_DPRATIORATE!" & CDbl(ODSendGrid.DataRows(i).Cells("LNRATE_MC").Value) & "!varchar2!30"
                                'v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_SA_ALLCODE, gc_ActionInquiry, v_strCmdSQL, v_strClause, , , , , , , gc_CommandProcedure)
                                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strCmdSQL, v_strClause, , , , , , , gc_CommandProcedure)
                                v_ws.Message(v_strObjMsg)
                                v_xmlDocument.LoadXml(v_strObjMsg)
                                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

                                For l = 0 To v_nodeList.Count - 1
                                    For k = 0 To v_nodeList.Item(l).ChildNodes.Count - 1
                                        With v_nodeList.Item(l).ChildNodes(k)
                                            v_strValue = Trim(.InnerText.ToString)
                                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                            Select Case Trim(v_strFLDNAME)
                                                Case "QG"
                                                    v_addQTTYSCR = Format(Math.Round(CDbl(v_strValue)), gc_FORMAT_NUMBER_0)
                                                Case "QRTT"
                                                    v_addQRtt = Format(Math.Round(CDbl(v_strValue)), gc_FORMAT_NUMBER_0)
                                                Case "QRTT0"
                                                    v_addQRtt0 = Format(Math.Round(CDbl(v_strValue)), gc_FORMAT_NUMBER_0)
                                                Case "QFINAL"
                                                    v_addQFinal = Format(Math.Round(CDbl(v_strValue)), gc_FORMAT_NUMBER_0)
                                            End Select
                                        End With
                                    Next
                                Next
                                v_addQTTYSCR = Math.Ceiling(v_addQTTYSCR / mv_dblTradeLot) * mv_dblTradeLot
                                ODSendGrid.DataRows(i).Cells("SCRQTTY").Value = v_addQTTYSCR
                                v_addQRtt = Math.Ceiling(v_addQRtt / mv_dblTradeLot) * mv_dblTradeLot
                                ODSendGrid.DataRows(i).Cells("QRTT").Value = v_addQRtt
                                v_addQRtt0 = Math.Ceiling(v_addQRtt0 / mv_dblTradeLot) * mv_dblTradeLot
                                ODSendGrid.DataRows(i).Cells("QRTT0").Value = v_addQRtt0
                                v_addQFinal = Math.Ceiling(v_addQFinal / mv_dblTradeLot) * mv_dblTradeLot
                                'ODSendGrid.DataRows(i).Cells("SELLQTTY").Value = v_addQFinal
                                ODSendGrid.DataRows(i).Cells("SELLQTTY").Value = Math.Min(v_addQFinal, Math.Floor(CDbl(ODSendGrid.DataRows(i).Cells("QUANTITY").Value) / mv_dblTradeLot) * mv_dblTradeLot)

                                

                            Catch ex As Exception
                                Throw ex
                            End Try

                        End If
                        SetLeftAmount()
                    End If
                Else

                End If
            Next
        End If
    End Sub

    Private Sub btnPlaceOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlaceOrder.Click
        Dim v_strAFACCTNO, v_strSYMBOL, v_strEXECTYPE, v_strPriceType, v_strSellQtty, v_strSellPrice As String
        If (ODSendGrid.CurrentCell Is Nothing) Then
            Exit Sub
        End If
        If (ODSendGrid.CurrentRow Is ODSendGrid.HeaderRows) Then
            Exit Sub
        End If
        If Me.ODSendGrid.DataRows.Count > 0 Then
            For i As Integer = 0 To Me.ODSendGrid.DataRows.Count - 1
                If ODSendGrid.DataRows(i).Cells("TICK").Value = "X" Then
                    Dim v_strInputParam As String = ""
                    Dim frm As New frmQuickOrderTransact(mv_strLanguage)
                    v_strAFACCTNO = ODSendGrid.DataRows(i).Cells("AFACCTNO").Value
                    v_strInputParam &= "CUSTODYCD#" & lblvCustodycd.Text
                    v_strInputParam &= "|CONTRACTNO#" & v_strAFACCTNO
                    If ObjectName = "DF1050" Then
                        v_strInputParam &= "|DEALNO#" & ODSendGrid.DataRows(i).Cells("DEALNO").Value
                    End If
                    v_strSYMBOL = ODSendGrid.DataRows(i).Cells("SYMBOL").Value
                    v_strInputParam &= "|SYMBOL#" & v_strSYMBOL
                    v_strEXECTYPE = ODSendGrid.DataRows(i).Cells("EXECTYPE").Value
                    v_strInputParam &= "|EXECTYPE#" & v_strEXECTYPE
                    v_strPriceType = IIf(IsNumeric(ODSendGrid.DataRows(i).Cells("SELLPRICE").Value), "LO", (Trim(ODSendGrid.DataRows(i).Cells("SELLPRICE").Value)).ToString)
                    v_strInputParam &= "|PRICETYPE#" & v_strPriceType
                    v_strSellQtty = ODSendGrid.DataRows(i).Cells("SELLQTTY").Value
                    v_strInputParam &= "|QUANTITY#" & v_strSellQtty
                    If IsNumeric(ODSendGrid.DataRows(i).Cells("SELLPRICE").Value) Then
                        If ODSendGrid.DataRows(i).Cells("TRADEPLACE").Value = "002" Then
                            'v_strSellPrice = (CDbl(ODSendGrid.DataRows(i).Cells("SELLPRICE").Value) * mv_dblTradeUnit).ToString
                            v_strSellPrice = (CDbl(ODSendGrid.DataRows(i).Cells("SELLPRICE").Value)).ToString
                        Else
                            v_strSellPrice = ODSendGrid.DataRows(i).Cells("SELLPRICE").Value
                        End If
                    End If
                    If v_strPriceType = "LO" Then
                        v_strInputParam &= "|LIMITPRICE#" & v_strSellPrice
                    End If


                    frm.InitParam = v_strInputParam
                    frm.IsDisposal = "Y"
                    frm.TellerName = "Liquidity processing"
                    frm.ObjectName = ""
                    frm.ModuleCode = "OD"
                    frm.LocalObject = gc_IsNotLocalMsg
                    frm.BranchId = Me.BranchId
                    frm.TellerId = Me.TellerId
                    frm.IpAddress = Me.IpAddress
                    frm.WsName = Me.WsName
                    frm.BusDate = Me.BusDate
                    frm.SYMBOLLIST = mv_strSYMBOLLIST
                    frm.mv_SymbolTalble = mv_SymbolTalble
                    frm.AdvanceOrder = True
                    frm.ShowDialog()
                    frm.Dispose()
                    
                End If
            Next
            'Me.Dispose()
            GetOrder() 'Refesh lai form
            Try

                Dim v_dblRTNREMAINAMT, v_dblRTNREMAINAMT_G As Double
                Dim v_nodeList As Xml.XmlNodeList
                Dim v_xmlDocument As New Xml.XmlDocument
                Dim v_strValue, v_strFLDNAME, v_strTEXT As String
                Dim v_strCmdSQL As String

                If ObjectName <> "MR1003" Then
                    v_strCmdSQL = " select RTNREMAINAMT,RTNREMAINAMT_G from vw_mr0003_all where ACCTNO='" & mv_strAFACCTNO & "'"
                Else
                    v_strCmdSQL = " select RTNREMAINAMT,RTNREMAINAMT_G from vw_mr1003 where GROUPID='" & GROUPID & "'"
                End If

                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
                Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                v_ws.Message(v_strObjMsg)
                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                'Dim k, l As Integer
                For k As Integer = 0 To v_nodeList.Count - 1
                    v_strTEXT = String.Empty
                    For l As Integer = 0 To v_nodeList.Item(k).ChildNodes.Count - 1
                        With v_nodeList.Item(k).ChildNodes(l)
                            v_strValue = Trim(.InnerText.ToString)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME)
                                Case "RTNREMAINAMT"
                                    v_dblRTNREMAINAMT = CDbl(v_strValue)
                                Case "RTNREMAINAMT_G"
                                    v_dblRTNREMAINAMT_G = CDbl(v_strValue)

                            End Select
                        End With
                    Next
                Next
                Me.lblvLstOdrAMT.Text = Format(v_dblRTNREMAINAMT, "#,##0")
                Me.lblvLstOdrAMT_G.Text = Format(v_dblRTNREMAINAMT_G, "#,##0")
                Me.lblvBfOdrAMT.Text = Format(v_dblRTNREMAINAMT, "#,##0")
                Me.lblvBfOdrAMT_G.Text = Format(v_dblRTNREMAINAMT_G, "#,##0")
                If IsNumeric(Me.lblLeftAMT.Text) AndAlso CDbl(Me.lblLeftAMT.Text) > 0 Then
                    Me.lblLeftAMT.ForeColor = Color.Red
                Else
                    Me.lblLeftAMT.ForeColor = Color.Green
                End If

                If IsNumeric(Me.lblvLstOdrAMT.Text) AndAlso CDbl(Me.lblvLstOdrAMT.Text) > 0 Then
                    Me.lblvLstOdrAMT.ForeColor = Color.Red
                Else
                    Me.lblvLstOdrAMT.ForeColor = Color.Black
                End If

                If IsNumeric(Me.lblvLstOdrAMT_G.Text) AndAlso CDbl(Me.lblvLstOdrAMT_G.Text) > 0 Then
                    Me.lblvLstOdrAMT_G.ForeColor = Color.Red
                Else
                    Me.lblvLstOdrAMT_G.ForeColor = Color.Black
                End If
                'Cap nhat lai trang thai bi trigger cua tieu khoan
                Dim v_strClause As String
                v_strCmdSQL = "pr_mr0003_updateTriggerStatus"
                v_strClause = "p_afacctno!" & v_strAFACCTNO & "!varchar2!10"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strCmdSQL, v_strClause, , , , , , , gc_CommandProcedure)
                v_ws.Message(v_strObjMsg)

            Catch ex As Exception

            End Try
        End If

    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmODSend_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Select Case e.KeyCode
            Case Keys.Escape
                OnClose()
            Case Keys.F5
                GetOrder()
                Me.lblLstOdrAMT.Text = Me.lblBfOdrAMT.Text
                Me.lblLstOdrAMT_G.Text = Me.lblBfOdrAMT_G.Text
        End Select
    End Sub
    Private Sub frmODSend_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetOrder()
    End Sub
#End Region

    Private Sub txtSYMBOL_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSYMBOL.Leave
        GetAddSec()
    End Sub

   
    
End Class
