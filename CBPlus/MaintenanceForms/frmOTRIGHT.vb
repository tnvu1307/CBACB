Imports CommonLibrary
Imports AppCore
Imports System.Xml.XmlNode
Imports System.Xml
Imports TestBase64
Imports ZetaCompressionLibrary
Imports System.IO

Public Class frmOTRIGHT
    Inherits AppCore.frmMaintenance

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
    Private _mv_oldAuthType As String
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents lblAUTHCUSTID As System.Windows.Forms.Label
    Friend WithEvents lblEXPDATE As System.Windows.Forms.Label
    Friend WithEvents lblVALDATE As System.Windows.Forms.Label
    Friend WithEvents txtAUTHCUSTID As FlexMaskEditBox
    Friend WithEvents dtpVALDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboAUTHTYPE As AppCore.ComboBoxEx
    Friend WithEvents lblAUTHTYPE As System.Windows.Forms.Label
    Friend WithEvents cboASGNTYPE As AppCore.ComboBoxEx
    Friend WithEvents lblASGNTYPE As System.Windows.Forms.Label
    Friend WithEvents grbInfo As System.Windows.Forms.GroupBox
    Friend WithEvents grbRightAssgn As System.Windows.Forms.GroupBox
    Friend WithEvents pnRightInfor As System.Windows.Forms.Panel
    Friend WithEvents lblFULLNAME As System.Windows.Forms.Label
    Friend WithEvents lblIDCODE As System.Windows.Forms.Label
    Friend WithEvents lblFULLNAMEDP As System.Windows.Forms.Label
    Friend WithEvents lblIDCODEDP As System.Windows.Forms.Label
    Friend WithEvents lblAUTHCUSTODYCD As System.Windows.Forms.Label
    Friend WithEvents txtAUTHCUSTODYCD As System.Windows.Forms.TextBox
    Friend WithEvents txtSERIALTOKEN As System.Windows.Forms.TextBox
    Friend WithEvents lblSERIALTOKEN As System.Windows.Forms.Label
    Friend WithEvents lblVia As System.Windows.Forms.Label
    Friend WithEvents cboVia As AppCore.ComboBoxEx
    Friend WithEvents dtpEXPDATE As System.Windows.Forms.DateTimePicker
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOTRIGHT))
        Me.dtpEXPDATE = New System.Windows.Forms.DateTimePicker
        Me.dtpVALDATE = New System.Windows.Forms.DateTimePicker
        Me.txtAUTHCUSTID = New AppCore.FlexMaskEditBox
        Me.lblVALDATE = New System.Windows.Forms.Label
        Me.lblEXPDATE = New System.Windows.Forms.Label
        Me.lblAUTHCUSTID = New System.Windows.Forms.Label
        Me.cboAUTHTYPE = New AppCore.ComboBoxEx
        Me.lblAUTHTYPE = New System.Windows.Forms.Label
        Me.cboASGNTYPE = New AppCore.ComboBoxEx
        Me.lblASGNTYPE = New System.Windows.Forms.Label
        Me.grbInfo = New System.Windows.Forms.GroupBox
        Me.cboVia = New AppCore.ComboBoxEx
        Me.lblVia = New System.Windows.Forms.Label
        Me.lblSERIALTOKEN = New System.Windows.Forms.Label
        Me.txtSERIALTOKEN = New System.Windows.Forms.TextBox
        Me.txtAUTHCUSTODYCD = New System.Windows.Forms.TextBox
        Me.lblAUTHCUSTODYCD = New System.Windows.Forms.Label
        Me.lblIDCODEDP = New System.Windows.Forms.Label
        Me.lblFULLNAMEDP = New System.Windows.Forms.Label
        Me.lblIDCODE = New System.Windows.Forms.Label
        Me.lblFULLNAME = New System.Windows.Forms.Label
        Me.grbRightAssgn = New System.Windows.Forms.GroupBox
        Me.pnRightInfor = New System.Windows.Forms.Panel
        Me.Panel1.SuspendLayout()
        Me.grbInfo.SuspendLayout()
        Me.grbRightAssgn.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(423, 457)
        Me.btnOK.Size = New System.Drawing.Size(85, 24)
        Me.btnOK.TabIndex = 1
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(605, 457)
        Me.btnCancel.Size = New System.Drawing.Size(85, 24)
        Me.btnCancel.TabIndex = 2
        '
        'lblCaption
        '
        Me.lblCaption.Location = New System.Drawing.Point(7, 17)
        '
        'btnApply
        '
        Me.btnApply.Location = New System.Drawing.Point(514, 458)
        Me.btnApply.Size = New System.Drawing.Size(85, 23)
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(700, 50)
        '
        'btnApprv
        '
        Me.btnApprv.Location = New System.Drawing.Point(227, 561)
        '
        'cboLink
        '
        Me.cboLink.Location = New System.Drawing.Point(9, 562)
        '
        'dtpEXPDATE
        '
        Me.dtpEXPDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEXPDATE.Location = New System.Drawing.Point(855, 296)
        Me.dtpEXPDATE.Name = "dtpEXPDATE"
        Me.dtpEXPDATE.Size = New System.Drawing.Size(163, 21)
        Me.dtpEXPDATE.TabIndex = 5
        Me.dtpEXPDATE.Tag = "EXPDATE"
        '
        'dtpVALDATE
        '
        Me.dtpVALDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpVALDATE.Location = New System.Drawing.Point(136, 22)
        Me.dtpVALDATE.Name = "dtpVALDATE"
        Me.dtpVALDATE.Size = New System.Drawing.Size(163, 21)
        Me.dtpVALDATE.TabIndex = 0
        Me.dtpVALDATE.Tag = "VALDATE"
        '
        'txtAUTHCUSTID
        '
        Me.txtAUTHCUSTID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtAUTHCUSTID.Location = New System.Drawing.Point(855, 103)
        Me.txtAUTHCUSTID.Name = "txtAUTHCUSTID"
        Me.txtAUTHCUSTID.Size = New System.Drawing.Size(163, 21)
        Me.txtAUTHCUSTID.TabIndex = 1
        Me.txtAUTHCUSTID.Tag = "AUTHCUSTID"
        Me.txtAUTHCUSTID.Text = "txtAUTHCUSTID"
        '
        'lblVALDATE
        '
        Me.lblVALDATE.AutoSize = True
        Me.lblVALDATE.Location = New System.Drawing.Point(12, 22)
        Me.lblVALDATE.Name = "lblVALDATE"
        Me.lblVALDATE.Size = New System.Drawing.Size(61, 13)
        Me.lblVALDATE.TabIndex = 3
        Me.lblVALDATE.Tag = "VALDATE"
        Me.lblVALDATE.Text = "lblVALDATE"
        '
        'lblEXPDATE
        '
        Me.lblEXPDATE.AutoSize = True
        Me.lblEXPDATE.Location = New System.Drawing.Point(738, 300)
        Me.lblEXPDATE.Name = "lblEXPDATE"
        Me.lblEXPDATE.Size = New System.Drawing.Size(61, 13)
        Me.lblEXPDATE.TabIndex = 2
        Me.lblEXPDATE.Tag = "EXPDATE"
        Me.lblEXPDATE.Text = "lblEXPDATE"
        '
        'lblAUTHCUSTID
        '
        Me.lblAUTHCUSTID.AutoSize = True
        Me.lblAUTHCUSTID.Location = New System.Drawing.Point(750, 106)
        Me.lblAUTHCUSTID.Name = "lblAUTHCUSTID"
        Me.lblAUTHCUSTID.Size = New System.Drawing.Size(81, 13)
        Me.lblAUTHCUSTID.TabIndex = 0
        Me.lblAUTHCUSTID.Tag = "AUTHCUSTID"
        Me.lblAUTHCUSTID.Text = "lblAUTHCUSTID"
        '
        'cboAUTHTYPE
        '
        Me.cboAUTHTYPE.DisplayMember = "DISPLAY"
        Me.cboAUTHTYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAUTHTYPE.Location = New System.Drawing.Point(518, 22)
        Me.cboAUTHTYPE.Name = "cboAUTHTYPE"
        Me.cboAUTHTYPE.Size = New System.Drawing.Size(163, 21)
        Me.cboAUTHTYPE.TabIndex = 1
        Me.cboAUTHTYPE.Tag = "AUTHTYPE"
        Me.cboAUTHTYPE.ValueMember = "VALUE"
        '
        'lblAUTHTYPE
        '
        Me.lblAUTHTYPE.AutoSize = True
        Me.lblAUTHTYPE.Location = New System.Drawing.Point(373, 22)
        Me.lblAUTHTYPE.Name = "lblAUTHTYPE"
        Me.lblAUTHTYPE.Size = New System.Drawing.Size(68, 13)
        Me.lblAUTHTYPE.TabIndex = 16
        Me.lblAUTHTYPE.Tag = "AUTHTYPE"
        Me.lblAUTHTYPE.Text = "lblAUTHTYPE"
        '
        'cboASGNTYPE
        '
        Me.cboASGNTYPE.DisplayMember = "DISPLAY"
        Me.cboASGNTYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboASGNTYPE.Location = New System.Drawing.Point(136, 52)
        Me.cboASGNTYPE.Name = "cboASGNTYPE"
        Me.cboASGNTYPE.Size = New System.Drawing.Size(163, 21)
        Me.cboASGNTYPE.TabIndex = 2
        Me.cboASGNTYPE.Tag = "ASGNTYPE"
        Me.cboASGNTYPE.ValueMember = "VALUE"
        '
        'lblASGNTYPE
        '
        Me.lblASGNTYPE.AutoSize = True
        Me.lblASGNTYPE.Location = New System.Drawing.Point(12, 52)
        Me.lblASGNTYPE.Name = "lblASGNTYPE"
        Me.lblASGNTYPE.Size = New System.Drawing.Size(68, 13)
        Me.lblASGNTYPE.TabIndex = 18
        Me.lblASGNTYPE.Tag = "ASGNTYPE"
        Me.lblASGNTYPE.Text = "lblASGNTYPE"
        '
        'grbInfo
        '
        Me.grbInfo.Controls.Add(Me.cboVia)
        Me.grbInfo.Controls.Add(Me.lblSERIALTOKEN)
        Me.grbInfo.Controls.Add(Me.cboAUTHTYPE)
        Me.grbInfo.Controls.Add(Me.lblAUTHTYPE)
        Me.grbInfo.Controls.Add(Me.txtSERIALTOKEN)
        Me.grbInfo.Controls.Add(Me.lblASGNTYPE)
        Me.grbInfo.Controls.Add(Me.cboASGNTYPE)
        Me.grbInfo.Controls.Add(Me.lblVALDATE)
        Me.grbInfo.Controls.Add(Me.dtpVALDATE)
        Me.grbInfo.Controls.Add(Me.lblVia)
        Me.grbInfo.Location = New System.Drawing.Point(0, 56)
        Me.grbInfo.Name = "grbInfo"
        Me.grbInfo.Size = New System.Drawing.Size(698, 115)
        Me.grbInfo.TabIndex = 0
        Me.grbInfo.TabStop = False
        '
        'cboVia
        '
        Me.cboVia.DisplayMember = "DISPLAY"
        Me.cboVia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVia.Location = New System.Drawing.Point(136, 82)
        Me.cboVia.Name = "cboVia"
        Me.cboVia.Size = New System.Drawing.Size(163, 21)
        Me.cboVia.TabIndex = 22
        Me.cboVia.Tag = "ASGNTYPE"
        Me.cboVia.ValueMember = "VALUE"
        '
        'lblVia
        '
        Me.lblVia.AutoSize = True
        Me.lblVia.BackColor = System.Drawing.SystemColors.Control
        Me.lblVia.ForeColor = System.Drawing.Color.Red
        Me.lblVia.Location = New System.Drawing.Point(12, 82)
        Me.lblVia.Name = "lblVia"
        Me.lblVia.Size = New System.Drawing.Size(31, 13)
        Me.lblVia.TabIndex = 21
        Me.lblVia.Tag = "VIA"
        Me.lblVia.Text = "lblVia"
        '
        'lblSERIALTOKEN
        '
        Me.lblSERIALTOKEN.AutoSize = True
        Me.lblSERIALTOKEN.Location = New System.Drawing.Point(373, 52)
        Me.lblSERIALTOKEN.Name = "lblSERIALTOKEN"
        Me.lblSERIALTOKEN.Size = New System.Drawing.Size(85, 13)
        Me.lblSERIALTOKEN.TabIndex = 20
        Me.lblSERIALTOKEN.Tag = "SERIALTOKEN"
        Me.lblSERIALTOKEN.Text = "lblSERIALTOKEN"
        '
        'txtSERIALTOKEN
        '
        Me.txtSERIALTOKEN.Location = New System.Drawing.Point(518, 52)
        Me.txtSERIALTOKEN.Name = "txtSERIALTOKEN"
        Me.txtSERIALTOKEN.Size = New System.Drawing.Size(163, 21)
        Me.txtSERIALTOKEN.TabIndex = 3
        Me.txtSERIALTOKEN.Tag = "SERIALTOKEN"
        '
        'txtAUTHCUSTODYCD
        '
        Me.txtAUTHCUSTODYCD.Location = New System.Drawing.Point(855, 191)
        Me.txtAUTHCUSTODYCD.Name = "txtAUTHCUSTODYCD"
        Me.txtAUTHCUSTODYCD.Size = New System.Drawing.Size(163, 21)
        Me.txtAUTHCUSTODYCD.TabIndex = 25
        Me.txtAUTHCUSTODYCD.Tag = "AUTHCUSTODYCD"
        Me.txtAUTHCUSTODYCD.Text = "txtAUTHCUSTODYCD"
        '
        'lblAUTHCUSTODYCD
        '
        Me.lblAUTHCUSTODYCD.AutoSize = True
        Me.lblAUTHCUSTODYCD.Location = New System.Drawing.Point(738, 194)
        Me.lblAUTHCUSTODYCD.Name = "lblAUTHCUSTODYCD"
        Me.lblAUTHCUSTODYCD.Size = New System.Drawing.Size(105, 13)
        Me.lblAUTHCUSTODYCD.TabIndex = 24
        Me.lblAUTHCUSTODYCD.Tag = "AUTHCUSTODYCD"
        Me.lblAUTHCUSTODYCD.Text = "lblAUTHCUSTODYCD"
        '
        'lblIDCODEDP
        '
        Me.lblIDCODEDP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblIDCODEDP.Location = New System.Drawing.Point(855, 224)
        Me.lblIDCODEDP.Name = "lblIDCODEDP"
        Me.lblIDCODEDP.Size = New System.Drawing.Size(163, 25)
        Me.lblIDCODEDP.TabIndex = 3
        Me.lblIDCODEDP.Tag = "IDCODEDP"
        Me.lblIDCODEDP.Text = "lblIDCODEDP"
        Me.lblIDCODEDP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFULLNAMEDP
        '
        Me.lblFULLNAMEDP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFULLNAMEDP.Location = New System.Drawing.Point(855, 150)
        Me.lblFULLNAMEDP.Name = "lblFULLNAMEDP"
        Me.lblFULLNAMEDP.Size = New System.Drawing.Size(163, 25)
        Me.lblFULLNAMEDP.TabIndex = 2
        Me.lblFULLNAMEDP.Tag = "FULLNAMEDP"
        Me.lblFULLNAMEDP.Text = "lblFULLNAMEDP"
        Me.lblFULLNAMEDP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIDCODE
        '
        Me.lblIDCODE.AutoSize = True
        Me.lblIDCODE.Location = New System.Drawing.Point(738, 230)
        Me.lblIDCODE.Name = "lblIDCODE"
        Me.lblIDCODE.Size = New System.Drawing.Size(56, 13)
        Me.lblIDCODE.TabIndex = 22
        Me.lblIDCODE.Tag = "IDCODE"
        Me.lblIDCODE.Text = "lblIDCODE"
        '
        'lblFULLNAME
        '
        Me.lblFULLNAME.AutoSize = True
        Me.lblFULLNAME.Location = New System.Drawing.Point(750, 156)
        Me.lblFULLNAME.Name = "lblFULLNAME"
        Me.lblFULLNAME.Size = New System.Drawing.Size(68, 13)
        Me.lblFULLNAME.TabIndex = 19
        Me.lblFULLNAME.Tag = "FULLNAME"
        Me.lblFULLNAME.Text = "lblFULLNAME"
        '
        'grbRightAssgn
        '
        Me.grbRightAssgn.Controls.Add(Me.pnRightInfor)
        Me.grbRightAssgn.Location = New System.Drawing.Point(0, 177)
        Me.grbRightAssgn.Name = "grbRightAssgn"
        Me.grbRightAssgn.Size = New System.Drawing.Size(698, 277)
        Me.grbRightAssgn.TabIndex = 20
        Me.grbRightAssgn.TabStop = False
        Me.grbRightAssgn.Text = "grbRightAssgn"
        '
        'pnRightInfor
        '
        Me.pnRightInfor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnRightInfor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnRightInfor.Location = New System.Drawing.Point(3, 17)
        Me.pnRightInfor.Name = "pnRightInfor"
        Me.pnRightInfor.Size = New System.Drawing.Size(692, 257)
        Me.pnRightInfor.TabIndex = 0
        Me.pnRightInfor.Tag = "pnRightInfor"
        '
        'frmOTRIGHT
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(700, 497)
        Me.Controls.Add(Me.txtAUTHCUSTODYCD)
        Me.Controls.Add(Me.grbRightAssgn)
        Me.Controls.Add(Me.lblAUTHCUSTODYCD)
        Me.Controls.Add(Me.dtpEXPDATE)
        Me.Controls.Add(Me.grbInfo)
        Me.Controls.Add(Me.lblEXPDATE)
        Me.Controls.Add(Me.txtAUTHCUSTID)
        Me.Controls.Add(Me.lblIDCODEDP)
        Me.Controls.Add(Me.lblFULLNAMEDP)
        Me.Controls.Add(Me.lblIDCODE)
        Me.Controls.Add(Me.lblFULLNAME)
        Me.Controls.Add(Me.lblAUTHCUSTID)
        Me.Name = "frmOTRIGHT"
        Me.Text = "frmOTRIGHT"
        Me.Controls.SetChildIndex(Me.lblAUTHCUSTID, 0)
        Me.Controls.SetChildIndex(Me.lblFULLNAME, 0)
        Me.Controls.SetChildIndex(Me.lblIDCODE, 0)
        Me.Controls.SetChildIndex(Me.lblFULLNAMEDP, 0)
        Me.Controls.SetChildIndex(Me.lblIDCODEDP, 0)
        Me.Controls.SetChildIndex(Me.txtAUTHCUSTID, 0)
        Me.Controls.SetChildIndex(Me.lblEXPDATE, 0)
        Me.Controls.SetChildIndex(Me.grbInfo, 0)
        Me.Controls.SetChildIndex(Me.dtpEXPDATE, 0)
        Me.Controls.SetChildIndex(Me.lblAUTHCUSTODYCD, 0)
        Me.Controls.SetChildIndex(Me.grbRightAssgn, 0)
        Me.Controls.SetChildIndex(Me.txtAUTHCUSTODYCD, 0)
        Me.Controls.SetChildIndex(Me.btnApprv, 0)
        Me.Controls.SetChildIndex(Me.cboLink, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.btnApply, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.grbInfo.ResumeLayout(False)
        Me.grbInfo.PerformLayout()
        Me.grbRightAssgn.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region

#Region " Declare constants and variables "
    Friend WithEvents OTRightAuthGrid As GridEx
    'Public OTRightAuthGrid As GridEx

    Private mv_CustID As String
    Private mv_CustodyCD As String
    Private mv_email As String
    Private mv_mobilesms As String
    Private mv_fullname As String
    Private mv_OldAuthType As String
    Private mv_OldSerial As String
    Private mv_strAuthCustid As String
    Private mv_isNotApprove As Boolean
    Private mv_lngFileSize As Long
    Private mv_linkauth As String
    Private mv_ImageViewer As New ImageViewer
    Private mv_orgcustid As String
    Private mv_arrSIGNATURE As String()
    Private mv_currIdx As Integer = 0
    Private mv_idxNumOfSign As Integer = 0
    Private v_strErrorMessage As String
#End Region

#Region " Properties "
    Public Property CustID() As String
        Get
            Return mv_CustID
        End Get
        Set(ByVal Value As String)
            mv_CustID = Value
        End Set
    End Property
    Public Property Custodycd() As String
        Get
            Return mv_CustodyCD
        End Get
        Set(ByVal Value As String)
            mv_CustodyCD = Value
        End Set
    End Property
    Public Property email() As String
        Get
            Return mv_email
        End Get
        Set(ByVal Value As String)
            mv_email = Value
        End Set
    End Property
    Public Property mobilesms() As String
        Get
            Return mv_mobilesms
        End Get
        Set(ByVal Value As String)
            mv_mobilesms = Value
        End Set
    End Property
    Public Property fullname() As String
        Get
            Return mv_fullname
        End Get
        Set(ByVal Value As String)
            mv_fullname = Value
        End Set
    End Property

    Public Property OldAuthType() As String
        Get
            Return mv_OldAuthType
        End Get
        Set(ByVal Value As String)
            mv_OldAuthType = Value
        End Set
    End Property
    Public Property OldSerial() As String
        Get
            Return mv_OldSerial
        End Get
        Set(ByVal Value As String)
            mv_OldSerial = Value
        End Set
    End Property
    Public Property AuthCustid() As String
        Get
            Return mv_strAuthCustid
        End Get
        Set(ByVal Value As String)
            mv_strAuthCustid = Value
        End Set
    End Property

    Public Property orgcustid() As String
        Get
            Return mv_orgcustid
        End Get
        Set(ByVal Value As String)
            mv_orgcustid = Value
        End Set
    End Property


#End Region

#Region " Overrides Methods "
    Public Overrides Sub OnInit()
        Dim v_ctrl As Windows.Forms.Control

        Try
            MyBase.OnInit()
            Me.txtAUTHCUSTID.Text = Me.CustID
            'Load Resource Manager
            ResourceManager = New Resources.ResourceManager(gc_RootNamespace & "." & Me.Name & "-" & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
            LoadUserInterface(Me)
            InitGrid()
            'Load menu of Online Trading
            LoadOTRIGHT()

            Me.cboASGNTYPE.SelectedValue = "DEFAULT"
            'If ExeFlag = ExecuteFlag.Edit Or ExeFlag = ExecuteFlag.View Then
            FillData()
            'End If
            If ExeFlag = ExecuteFlag.Edit Or ExeFlag = ExecuteFlag.View Then
                cboAUTHTYPE.Enabled = False
                txtSERIALTOKEN.Enabled = False
                cboVia.Enabled = False '2.1.3.0|iss1594
                Me.dtpVALDATE.Enabled = False '2.1.3.0|iss 1594
            End If
            Me.cboASGNTYPE.Enabled = False
            If Not cboAUTHTYPE.SelectedValue Is DBNull.Value AndAlso Not OTRightAuthGrid Is Nothing Then
                If cboAUTHTYPE.SelectedValue = "0" Then
                    Me.OTRightAuthGrid.Columns("AUTHPASS").Visible = True
                    Me.OTRightAuthGrid.Columns("AUTHTOKEN").Visible = False
                    Me.OTRightAuthGrid.Columns("AUTHMATRIX").Visible = False
                    Me.OTRightAuthGrid.Columns("AUTHNUMSIG").Visible = False '2.1.3.0|iss 1594
                    Me.OTRightAuthGrid.Columns("AUTHOTPSMS").Visible = False 'OTP SMS
                ElseIf cboAUTHTYPE.SelectedValue = "1" Then
                    Me.OTRightAuthGrid.Columns("AUTHPASS").Visible = True
                    Me.OTRightAuthGrid.Columns("AUTHTOKEN").Visible = False
                    Me.OTRightAuthGrid.Columns("AUTHMATRIX").Visible = False
                    Me.OTRightAuthGrid.Columns("AUTHNUMSIG").Visible = False '2.1.3.0|iss 1594
                    Me.OTRightAuthGrid.Columns("AUTHOTPSMS").Visible = False 'OTP SMS
                ElseIf cboAUTHTYPE.SelectedValue = "2" Then
                    Me.OTRightAuthGrid.Columns("AUTHPASS").Visible = False
                    Me.OTRightAuthGrid.Columns("AUTHTOKEN").Visible = True
                    Me.OTRightAuthGrid.Columns("AUTHMATRIX").Visible = False
                    Me.OTRightAuthGrid.Columns("AUTHNUMSIG").Visible = False '2.1.3.0|iss 1594
                    Me.OTRightAuthGrid.Columns("AUTHOTPSMS").Visible = False 'OTP SMS
                ElseIf cboAUTHTYPE.SelectedValue = "3" Then
                    Me.OTRightAuthGrid.Columns("AUTHPASS").Visible = False
                    Me.OTRightAuthGrid.Columns("AUTHTOKEN").Visible = False
                    Me.OTRightAuthGrid.Columns("AUTHMATRIX").Visible = True
                    Me.OTRightAuthGrid.Columns("AUTHNUMSIG").Visible = False '2.1.3.0|iss 1594
                    Me.OTRightAuthGrid.Columns("AUTHOTPSMS").Visible = False 'OTP SMS
                ElseIf cboAUTHTYPE.SelectedValue = "4" Then
                    Me.OTRightAuthGrid.Columns("AUTHPASS").Visible = False
                    Me.OTRightAuthGrid.Columns("AUTHTOKEN").Visible = False
                    Me.OTRightAuthGrid.Columns("AUTHMATRIX").Visible = False
                    Me.OTRightAuthGrid.Columns("AUTHNUMSIG").Visible = True '2.1.3.0|iss 1594
                    Me.OTRightAuthGrid.Columns("AUTHOTPSMS").Visible = False 'OTP SMS
                ElseIf cboAUTHTYPE.SelectedValue = "5" Then
                    Me.OTRightAuthGrid.Columns("AUTHPASS").Visible = False
                    Me.OTRightAuthGrid.Columns("AUTHTOKEN").Visible = False
                    Me.OTRightAuthGrid.Columns("AUTHMATRIX").Visible = False
                    Me.OTRightAuthGrid.Columns("AUTHNUMSIG").Visible = False '2.1.3.0|iss 1594
                    Me.OTRightAuthGrid.Columns("AUTHOTPSMS").Visible = True 'OTP SMS
                End If
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ResourceManager.GetString("InitDialogFailed"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Function CheckValidDate() As Long
        'Chi cho truong hop add new con edit thi chi check expdate > valdate la duoc 
        If Me.dtpEXPDATE.Value < DDMMYYYY_SystemDate(Me.BusDate) Then
            Return 1
            'ElseIf Me.dtpVALDATE.Value >= Me.dtpEXPDATE.Value Then
            '    Return 3
        End If
    End Function

    Public Overrides Sub OnSave()

        Dim v_strObjMsg As String
        Dim v_xmlDocument As New XmlDocument
        Dim v_txDocument As New XmlDocument

        'QuangVD: check auth register
        For i As Integer = 0 To OTRightAuthGrid.DataRows.Count - 1
            Dim v_gridRow As Xceed.Grid.DataRow = OTRightAuthGrid.DataRows(i)
            '2.1.3.0|iss 1594
            If CStr(v_gridRow.Cells("EDITR").Value) = "X" And CStr(v_gridRow.Cells("AUTHPASS").Value) <> "X" And CStr(v_gridRow.Cells("AUTHTOKEN").Value) <> "X" And CStr(v_gridRow.Cells("AUTHMATRIX").Value) <> "X" And CStr(v_gridRow.Cells("AUTHNUMSIG").Value) <> "X" And CStr(v_gridRow.Cells("AUTHOTPSMS").Value) <> "X" And _
            (CStr(v_gridRow.Cells("MENUCODE").Value) = "CASHTRANS" Or CStr(v_gridRow.Cells("MENUCODE").Value) = "ADWINPUT" Or _
             CStr(v_gridRow.Cells("MENUCODE").Value) = "ISSUEINPUT" Or CStr(v_gridRow.Cells("MENUCODE").Value) = "MORTGAGE" Or _
             CStr(v_gridRow.Cells("MENUCODE").Value) = "BONDSTOSHARES" Or CStr(v_gridRow.Cells("MENUCODE").Value) = "TERMDEPOSIT") Then
                MsgBox(CStr(ResourceManager.GetString(CStr(v_gridRow.Cells("MENUCODE").Value)) + " " + ResourceManager.GetString("auth_warning")), MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                Exit Sub
            End If
        Next
        'Ngay 24/08/2018 NamTv truong hop Chu ky so, OTPSMS khong duoc dang ky dich vu khac ngoai dat lenh
        If cboAUTHTYPE.SelectedValue = "4" Or cboAUTHTYPE.SelectedValue = "5" Then
            For j As Integer = 0 To OTRightAuthGrid.DataRows.Count - 1
                Dim v_gridRow As Xceed.Grid.DataRow = OTRightAuthGrid.DataRows(j)
                '2.1.3.0|iss 1594
                If (CStr(v_gridRow.Cells("MENUCODE").Value) <> "ORDINPUT" And CStr(v_gridRow.Cells("MENUCODE").Value) <> "COND_ORDER" And CStr(v_gridRow.Cells("MENUCODE").Value) <> "GROUP_ORDER") And _
                (CStr(v_gridRow.Cells("VIEWR").Value) = "X" Or CStr(v_gridRow.Cells("SUBMITR").Value) = "X" Or CStr(v_gridRow.Cells("EDITR").Value) = "X" Or CStr(v_gridRow.Cells("SEARCHR").Value) = "X") Then
                    MsgBox(CStr(ResourceManager.GetString("NOSERVICEDIFFORDER")), MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
            Next
        End If

        'Ngay 24/08/2018 NamTv End

        Try
            'Update mouse pointer
            Cursor.Current = Cursors.WaitCursor

            MyBase.OnSave()
            If Not DoDataExchange(True) Then
                Exit Sub
            End If

            '2.1.3.0|iss1594
            If (cboAUTHTYPE.SelectedValue = "2" Or cboAUTHTYPE.SelectedValue = "3" Or cboAUTHTYPE.SelectedValue = "4") And txtSERIALTOKEN.TextLength = 0 Then
                MsgBox(CStr(ResourceManager.GetString("SERIALTOKEN_TEXT")), MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                Exit Sub
            End If

            If (email.Length + mobilesms.Length = 0) Then
                MsgBox(CStr(ResourceManager.GetString("ADD_MOBILE_EMAIL")), MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                Exit Sub
            End If


            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_strErrorSource, v_strErrorMessage As String

            Select Case ExeFlag
                Case ExecuteFlag.AddNew

                    Select Case CheckValidDate()
                        Case 1
                            MsgBox(ResourceManager.GetString("ERR_EXPRISEDDATE_INVALID"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                            Exit Sub
                        Case 2
                            MsgBox(ResourceManager.GetString("ERR_VALDATE_INVALID"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                            Exit Sub
                        Case 3
                            MsgBox(ResourceManager.GetString("ERR_VALDATE_LARGER_EXPDATE"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                            Exit Sub
                    End Select

                    Dim v_strRight2Save As String
                    v_strRight2Save = GetRight2Save()
                    'Call webservice
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionAdhoc, , , "OTRIGHT_Addnew", , , v_strRight2Save, , , , ParentObjName, ParentClause)
                    'v_ws.Message(v_strObjMsg)
                    BuildXMLObjData(mv_dsInput, v_strObjMsg)

                    Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)
                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)

                    If v_lngErrorCode <> 0 Then
                        'Update mouse pointer
                        Cursor.Current = Cursors.Default
                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Exit Sub
                    End If
                    MsgBox(ResourceManager.GetString("AddnewSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    Me.DialogResult = DialogResult.OK
                    MyBase.OnClose()
                Case ExecuteFlag.Edit
                    Select Case CheckValidDate()
                        Case 1
                            MsgBox(ResourceManager.GetString("ERR_EXPRISEDDATE_INVALID"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                            Exit Sub
                        Case 2
                            MsgBox(ResourceManager.GetString("ERR_VALDATE_INVALID"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                            Exit Sub
                        Case 3
                            MsgBox(ResourceManager.GetString("ERR_VALDATE_LARGER_EXPDATE"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                            Exit Sub
                    End Select
                    Dim v_strClause As String
                    Select Case KeyFieldType
                        Case "C"
                            v_strClause = KeyFieldName & " = '" & KeyFieldValue & "'"
                        Case "D"
                            v_strClause = KeyFieldName & " = TO_DATE('" & KeyFieldValue & "', '" & gc_FORMAT_DATE & "')"
                        Case "N"
                            v_strClause = KeyFieldName & " = " & KeyFieldValue.ToString()
                    End Select

                    Dim v_strRight2Save As String
                    v_strRight2Save = GetRight2Save()
                    'Call webservice
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionAdhoc, , v_strClause, "OTRIGHT_Edit", , , v_strRight2Save, , , , ParentObjName, ParentClause)
                    'v_ws.Message(v_strObjMsg)
                    BuildXMLObjData(mv_dsInput, v_strObjMsg)

                    Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)
                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)

                    If v_lngErrorCode <> 0 Then
                        'Update mouse pointer
                        Cursor.Current = Cursors.Default
                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Exit Sub
                    End If
                    MsgBox(ResourceManager.GetString("EditSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    Me.DialogResult = DialogResult.OK
                    MyBase.OnClose()
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
            If Not ControlValidation(pv_blnSaved) Then
                Return False
            End If

            Return MyBase.DoDataExchange(pv_blnSaved)
        Catch ex As Exception
            Throw ex
            Return False
        End Try
    End Function

    Overrides Sub LoadUserInterface(ByRef pv_ctrl As Windows.Forms.Control)
        'MyBase.LoadUserInterface(pv_ctrl)

        Dim v_ctrl As Windows.Forms.Control

        For Each v_ctrl In pv_ctrl.Controls
            If TypeOf (v_ctrl) Is Label Then
                CType(v_ctrl, Label).Text = ResourceManager.GetString(v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is CheckBox Then
                CType(v_ctrl, CheckBox).Text = ResourceManager.GetString(v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is GroupBox Then
                CType(v_ctrl, GroupBox).Text = ResourceManager.GetString(v_ctrl.Name)
                LoadUserInterface(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is Button Then
                CType(v_ctrl, Button).Text = ResourceManager.GetString(v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is Panel Then
                LoadUserInterface(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is DateTimePicker Then
                CType(v_ctrl, DateTimePicker).Value = CDate(Me.BusDate)
            End If
        Next
        Me.Text = ResourceManager.GetString(Me.Name)

        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strSQL, v_strObjMsg As String
        'begin '2.1.3.0|iss1594
        v_strSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, LSTODR FROM ALLCODE WHERE CDTYPE = 'CF' AND CDNAME = 'OTAUTHTYPE' AND CDUSER='Y' ORDER BY LSTODR"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQL)
        v_ws.Message(v_strObjMsg)
        FillComboEx(v_strObjMsg, cboAUTHTYPE, "", Me.UserLanguage)
        'end '2.1.3.0|iss1594

        v_strSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, LSTODR FROM ALLCODE WHERE CDTYPE = 'CF' AND CDNAME = 'OTRASGTYPE' ORDER BY LSTODR"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQL)
        v_ws.Message(v_strObjMsg)
        FillComboEx(v_strObjMsg, cboASGNTYPE, "", Me.UserLanguage)
        'begin '2.1.3.0|iss1594
        v_strSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, LSTODR FROM ALLCODE WHERE CDTYPE = 'OD' AND CDNAME = 'VIA'  AND CDUSER='Y' ORDER BY LSTODR"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQL)
        v_ws.Message(v_strObjMsg)
        FillComboEx(v_strObjMsg, Me.cboVia, "", Me.UserLanguage)
        'end '2.1.3.0|iss1594
        'S?a ch? này cho t?ng form maintenance khác nhau
        If ExeFlag = ExecuteFlag.Edit Or ExeFlag = ExecuteFlag.View Then
            'FillCheckBoxValue()
        End If
        If (ExeFlag = ExecuteFlag.AddNew) Then
            lblFULLNAMEDP.Text = String.Empty
            lblIDCODEDP.Text = String.Empty
            Me.dtpEXPDATE.Value = DateAdd(DateInterval.Year, 100, dtpVALDATE.Value)
        ElseIf (ExeFlag = ExecuteFlag.Edit) Then
            Me.txtAUTHCUSTID.Enabled = False
        End If
    End Sub

    Private Sub InitGrid()
        Try
            'Dinh nghia grid cho phan quyen online
            OTRightAuthGrid = New GridEx
            Dim v_cmrOTRightAuthGridHeader As New Xceed.Grid.ColumnManagerRow
            v_cmrOTRightAuthGridHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
            v_cmrOTRightAuthGridHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            v_cmrOTRightAuthGridHeader.HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
            v_cmrOTRightAuthGridHeader.Height = 35
            OTRightAuthGrid.FixedHeaderRows.Add(v_cmrOTRightAuthGridHeader)

            OTRightAuthGrid.Columns.Add(New Xceed.Grid.Column("MENUCODE", GetType(System.String)))
            OTRightAuthGrid.Columns.Add(New Xceed.Grid.Column("DESCRIPTION", GetType(System.String)))
            OTRightAuthGrid.Columns.Add(New Xceed.Grid.Column("SUBMITR", GetType(System.String)))
            OTRightAuthGrid.Columns.Add(New Xceed.Grid.Column("EDITR", GetType(System.String)))
            OTRightAuthGrid.Columns.Add(New Xceed.Grid.Column("SEARCHR", GetType(System.String)))
            OTRightAuthGrid.Columns.Add(New Xceed.Grid.Column("VIEWR", GetType(System.String)))
            OTRightAuthGrid.Columns.Add(New Xceed.Grid.Column("AUTHPASS", GetType(System.String)))
            OTRightAuthGrid.Columns.Add(New Xceed.Grid.Column("AUTHTOKEN", GetType(System.String)))
            OTRightAuthGrid.Columns.Add(New Xceed.Grid.Column("AUTHMATRIX", GetType(System.String)))
            OTRightAuthGrid.Columns.Add(New Xceed.Grid.Column("AUTHNUMSIG", GetType(System.String))) '2.1.3.0|iss 1594
            OTRightAuthGrid.Columns.Add(New Xceed.Grid.Column("AUTHOTPSMS", GetType(System.String))) 'OTP SMS

            OTRightAuthGrid.Columns("MENUCODE").Title = ResourceManager.GetString("grid.MENUCODE")
            OTRightAuthGrid.Columns("DESCRIPTION").Title = ResourceManager.GetString("grid.DESCRIPTION")
            OTRightAuthGrid.Columns("SUBMITR").Title = ResourceManager.GetString("grid.SUBMIT")
            OTRightAuthGrid.Columns("EDITR").Title = ResourceManager.GetString("grid.EDIT")
            OTRightAuthGrid.Columns("SEARCHR").Title = ResourceManager.GetString("grid.SEARCH")
            OTRightAuthGrid.Columns("AUTHPASS").Title = ResourceManager.GetString("grid.AUTHPASS")
            OTRightAuthGrid.Columns("AUTHTOKEN").Title = ResourceManager.GetString("grid.AUTHTOKEN")
            OTRightAuthGrid.Columns("AUTHMATRIX").Title = ResourceManager.GetString("grid.AUTHMATRIX")
            OTRightAuthGrid.Columns("AUTHNUMSIG").Title = ResourceManager.GetString("grid.AUTHNUMSIG") '2.1.3.0|iss 1594
            OTRightAuthGrid.Columns("AUTHOTPSMS").Title = ResourceManager.GetString("grid.AUTHOTPSMS") 'OTP SMS
            OTRightAuthGrid.Columns("VIEWR").Title = ResourceManager.GetString("grid.VIEW")

            OTRightAuthGrid.Columns("DESCRIPTION").Width = 150
            OTRightAuthGrid.Columns("VIEWR").Width = 60
            OTRightAuthGrid.Columns("SUBMITR").Width = 60
            OTRightAuthGrid.Columns("EDITR").Width = 60
            OTRightAuthGrid.Columns("SEARCHR").Width = 60
            OTRightAuthGrid.Columns("AUTHPASS").Width = 60
            OTRightAuthGrid.Columns("AUTHTOKEN").Width = 60
            OTRightAuthGrid.Columns("AUTHMATRIX").Width = 60
            OTRightAuthGrid.Columns("AUTHNUMSIG").Width = 100 '2.1.3.0|iss 1594
            OTRightAuthGrid.Columns("AUTHOTPSMS").Width = 100 'OTP SMS

            OTRightAuthGrid.Columns("VIEWR").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
            OTRightAuthGrid.Columns("SUBMITR").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
            OTRightAuthGrid.Columns("EDITR").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
            OTRightAuthGrid.Columns("SEARCHR").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
            OTRightAuthGrid.Columns("AUTHPASS").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
            OTRightAuthGrid.Columns("AUTHTOKEN").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
            OTRightAuthGrid.Columns("AUTHMATRIX").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
            OTRightAuthGrid.Columns("AUTHNUMSIG").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center '2.1.3.0|iss 1594
            OTRightAuthGrid.Columns("AUTHOTPSMS").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center 'OTP SMS

            Me.pnRightInfor.Controls.Clear()
            Me.pnRightInfor.Controls.Add(OTRightAuthGrid)
            OTRightAuthGrid.Dock = Windows.Forms.DockStyle.Fill

            If Me.OTRightAuthGrid.DataRowTemplate.Cells.Count >= 0 Then
                For i As Integer = 0 To Me.OTRightAuthGrid.DataRowTemplate.Cells.Count - 1
                    AddHandler OTRightAuthGrid.DataRowTemplate.Cells(i).Click, AddressOf OTRightAuthGrid_Click
                Next
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GetCustomerInfor()
        Try
            'Check ko cho phep uy quyen cho chinh minh
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_strSQL, v_strObjMsg, v_strValue, v_strFLDNAME As String
            Dim v_strCUSTID, v_strFULLNAME, v_strIDCODE, v_strCUSTODYCD As String

            v_strSQL = "SELECT CF.CUSTID, CF.FULLNAME, CF.IDCODE, CF.CUSTODYCD " & ControlChars.CrLf _
                        & "FROM CFMAST CF WHERE CF.CUSTID = '" & txtAUTHCUSTID.Text.Replace(".", "") & "'"

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            If v_nodeList.Count > 0 Then
                For i As Integer = 0 To v_nodeList.Count - 1
                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            v_strValue = Trim(.InnerText.ToString)
                            Select Case v_strFLDNAME
                                Case "CUSTID"
                                    v_strCUSTID = v_strValue
                                Case "FULLNAME"
                                    v_strFULLNAME = v_strValue
                                Case "IDCODE"
                                    v_strIDCODE = v_strValue
                                Case "CUSTODYCD"
                                    v_strCUSTODYCD = v_strValue
                            End Select
                        End With
                    Next
                Next

                'Set value
                txtAUTHCUSTID.Text = v_strCUSTID
                lblFULLNAMEDP.Text = v_strFULLNAME
                lblIDCODEDP.Text = v_strIDCODE
                txtAUTHCUSTODYCD.Text = v_strCUSTODYCD
            Else
                MsgBox(ResourceManager.GetString("ACCTNO_INVALID"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                Me.txtAUTHCUSTID.Focus()
            End If
            'End If


        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                                    & "Error code: System error!" & vbNewLine _
                                    & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ResourceManager.GetString("SavingFailed"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub LoadOTRIGHT()
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            If Not OTRightAuthGrid Is Nothing Then
                'Clear old data
                OTRightAuthGrid.DataRows.Clear()
                Dim v_strSQL As String
                v_strSQL = "SELECT CDVAL MENUCODE, CDCONTENT DESCRIPTION, '' VIEWR, '' SUBMITR, '' EDITR, '' SEARCHR " & ControlChars.CrLf _
                        & " FROM ALLCODE WHERE CDTYPE = 'SA' AND CDNAME = 'OTFUNC' AND CDUSER = 'Y' ORDER BY LSTODR"
                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_TLLOG, _
                    gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                FillDataGrid(OTRightAuthGrid, v_strObjMsg, "")
                'mv_blnRefreshTabPage_Authorized = True
            End If
        Catch ex As Exception
            Throw ex
        Finally
            v_ws = Nothing
        End Try
    End Sub

    Private Sub FillData()
        Try
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_strSQL, v_strObjMsg, v_strValue, v_strFLDNAME As String
            Dim v_strAUTHCUSTID, v_strAUTHAFACCTNO, v_strAUTHTYPE, v_strSERIALTOKEN, v_strVALDATE, v_strEXPDATE, v_strOTMNCODE, v_strOTRIGHT, v_strFULLNAME, v_strIDCODE, v_strCUSTODYCD As String
            Dim v_strSERIALNUMSIG, v_strVIA As String
            Dim v_hOTRIGHT As New Hashtable

            If (ExeFlag <> ExecuteFlag.AddNew) Then
                'begin '2.1.3.0|iss1594
                v_strSQL = "SELECT OT.AUTHCUSTID, OT.AUTHTYPE, OT.VALDATE, OT.EXPDATE, OT.SERIALTOKEN, CF.FULLNAME, CF.IDCODE, CF.CUSTODYCD, OT.serialNumSig, ot.VIA " & ControlChars.CrLf _
                        & "FROM OTRIGHT OT, CFMAST CF WHERE CF.CUSTID = OT.AUTHCUSTID AND CF.CUSTID='" & CustID & "' AND OT.DELTD = 'N' and ot.AUTOID ='" & Me.KeyFieldValue & "'" & ControlChars.CrLf _
                        & "ORDER BY OT.AUTOID"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                For i As Integer = 0 To v_nodeList.Count - 1
                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            v_strValue = Trim(.InnerText.ToString)
                            Select Case v_strFLDNAME
                                Case "AUTHCUSTID"
                                    v_strAUTHCUSTID = v_strValue
                                Case "AUTHTYPE"
                                    v_strAUTHTYPE = v_strValue
                                    OldAuthType = v_strValue
                                Case "VALDATE"
                                    v_strVALDATE = v_strValue
                                Case "EXPDATE"
                                    v_strEXPDATE = v_strValue
                                Case "EXPDATE"
                                    v_strEXPDATE = v_strValue
                                Case "FULLNAME"
                                    v_strFULLNAME = v_strValue
                                Case "IDCODE"
                                    v_strIDCODE = v_strValue
                                Case "CUSTODYCD"
                                    v_strCUSTODYCD = v_strValue
                                    Custodycd = v_strValue
                                Case "SERIALTOKEN"
                                    v_strSERIALTOKEN = v_strValue
                                    OldSerial = v_strValue
                                    'begin 2.1.3.0|iss 1594
                                Case "SERIALNUMSIG"
                                    v_strSERIALNUMSIG = v_strValue
                                Case "VIA"
                                    v_strVIA = v_strValue
                            End Select
                        End With
                    Next
                Next
                txtAUTHCUSTODYCD.Text = v_strCUSTODYCD
                txtAUTHCUSTID.Text = v_strAUTHCUSTID
                cboAUTHTYPE.SelectedValue = v_strAUTHTYPE
                'begin '2.1.3.0|iss1594
                dtpVALDATE.Value = CType(v_strVALDATE, Date)
                dtpEXPDATE.Value = CType(v_strEXPDATE, Date)
                If v_strAUTHTYPE = 2 Then
                    txtSERIALTOKEN.Text = v_strSERIALTOKEN
                ElseIf v_strAUTHTYPE = 4 Then
                    txtSERIALTOKEN.Text = v_strSERIALNUMSIG
                End If
                lblFULLNAMEDP.Text = v_strFULLNAME
                lblIDCODEDP.Text = v_strIDCODE
                Me.cboVia.SelectedValue = v_strVIA

                'Fill right
                v_strSQL = "SELECT AUTHCUSTID, OTMNCODE, OTRIGHT " & ControlChars.CrLf _
                        & "FROM OTRIGHTDTL WHERE CFCUSTID = '" & Me.CustID & "' AND AUTHCUSTID = '" & AuthCustid & "' AND DELTD = 'N' and via ='" & v_strVIA & "'" & ControlChars.CrLf _
                        & "ORDER BY AUTOID"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                For m As Integer = 0 To v_nodeList.Count - 1
                    For n As Integer = 0 To v_nodeList.Item(m).ChildNodes.Count - 1
                        With v_nodeList.Item(m).ChildNodes(n)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            v_strValue = Trim(.InnerText.ToString)
                            Select Case v_strFLDNAME
                                Case "OTMNCODE"
                                    v_strOTMNCODE = v_strValue
                                Case "OTRIGHT"
                                    v_strOTRIGHT = v_strValue
                            End Select
                        End With
                    Next
                    'Add to hash table
                    v_hOTRIGHT.Add(v_strOTMNCODE, v_strOTRIGHT)
                Next

                'Set right info
                For k As Integer = 0 To OTRightAuthGrid.DataRows.Count - 1
                    'Dim v_gridRow As Xceed.Grid.DataRow = OTRightAuthGrid.DataRows(k)
                    v_strOTMNCODE = CStr(OTRightAuthGrid.DataRows(k).Cells("MENUCODE").Value)
                    v_strOTRIGHT = v_hOTRIGHT(v_strOTMNCODE)
                    If v_strOTRIGHT <> String.Empty Then
                        OTRightAuthGrid.DataRows(k).Cells("VIEWR").Value = IIf(Mid(v_strOTRIGHT, 1, 1) = "Y", "X", "")
                        OTRightAuthGrid.DataRows(k).Cells("SUBMITR").Value = IIf(Mid(v_strOTRIGHT, 2, 1) = "Y", "X", "")
                        OTRightAuthGrid.DataRows(k).Cells("EDITR").Value = IIf(Mid(v_strOTRIGHT, 3, 1) = "Y", "X", "")
                        OTRightAuthGrid.DataRows(k).Cells("SEARCHR").Value = IIf(Mid(v_strOTRIGHT, 4, 1) = "Y", "X", "")
                        OTRightAuthGrid.DataRows(k).Cells("AUTHPASS").Value = IIf(Mid(v_strOTRIGHT, 5, 1) = "Y", "X", "")
                        OTRightAuthGrid.DataRows(k).Cells("AUTHTOKEN").Value = IIf(Mid(v_strOTRIGHT, 6, 1) = "Y", "X", "")
                        OTRightAuthGrid.DataRows(k).Cells("AUTHNUMSIG").Value = IIf(Mid(v_strOTRIGHT, 8, 1) = "Y", "X", "") '2.1.3.0|iss1594
                    End If
                    'OTRightAuthGrid.DataRows(k).Cells("").Value = ""
                Next
            Else
                v_strSQL = "SELECT  CF.FULLNAME, CF.IDCODE, CF.CUSTODYCD " & ControlChars.CrLf _
                        & "FROM  CFMAST CF WHERE  CF.CUSTID='" & CustID & "' "

                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                For i As Integer = 0 To v_nodeList.Count - 1
                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            v_strValue = Trim(.InnerText.ToString)
                            Select Case v_strFLDNAME
                                Case "FULLNAME"
                                    v_strFULLNAME = v_strValue
                                Case "IDCODE"
                                    v_strIDCODE = v_strValue
                                Case "CUSTODYCD"
                                    v_strCUSTODYCD = v_strValue
                                    Custodycd = v_strValue
                            End Select
                        End With
                    Next
                Next
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                                    & "Error code: System error!" & vbNewLine _
                                    & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ResourceManager.GetString("SavingFailed"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub SetDefaultOTRIGHT()
        Try
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_strSQL, v_strObjMsg, v_strValue, v_strFLDNAME As String
            Dim v_strTempRight As String = String.Empty

            v_strSQL = "SELECT VARVALUE" & ControlChars.CrLf _
                    & "FROM SYSVAR WHERE GRNAME = 'DEFINED' AND VARNAME = 'OTRIGHTDFLT'"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_TLLOG, gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Count - 1
                For j As Integer = 0 To v_nodeList.Item(j).ChildNodes.Count - 1
                    With v_nodeList.Item(j).ChildNodes(i)
                        v_strFLDNAME = v_nodeList.Item(j).ChildNodes(i).Attributes.GetNamedItem("fldname").Value.Trim()
                        v_strValue = v_nodeList.Item(j).ChildNodes(i).Attributes.GetNamedItem("oldval").Value.Trim()
                        Select Case v_strFLDNAME
                            Case "VARVALUE"
                                v_strTempRight = v_strValue
                        End Select
                    End With
                Next
            Next

            'Set default value
            'QuangVD: changed 29/10/2012 for auth columns
            If v_strTempRight.Length > 0 And OTRightAuthGrid.DataRows.Count > 0 Then
                For i As Integer = 0 To OTRightAuthGrid.DataRows.Count - 1
                    Dim v_gridRow As Xceed.Grid.DataRow = OTRightAuthGrid.DataRows(i)
                    If (CStr(v_gridRow.Cells("MENUCODE").Value) <> "TERMDEPOSIT" And _
                        CStr(v_gridRow.Cells("MENUCODE").Value) <> "ADMINMESSAGES" And _
                        CStr(v_gridRow.Cells("MENUCODE").Value) <> "ADMINBRANCH" And _
                        CStr(v_gridRow.Cells("MENUCODE").Value) <> "AGENTSETTING") Then
                        v_gridRow.Cells("VIEWR").Value = IIf(Mid(v_strTempRight, 1, 1) = "Y", "X", "")
                        v_gridRow.Cells("SUBMITR").Value = IIf(Mid(v_strTempRight, 2, 1) = "Y", "X", "")
                        v_gridRow.Cells("EDITR").Value = IIf(Mid(v_strTempRight, 3, 1) = "Y", "X", "")
                        v_gridRow.Cells("SEARCHR").Value = IIf(Mid(v_strTempRight, 4, 1) = "Y", "X", "")
                        v_gridRow.Cells("AUTHPASS").Value = IIf(Mid(v_strTempRight, 5, 1) = "Y", "X", "")
                        v_gridRow.Cells("AUTHTOKEN").Value = IIf(Mid(v_strTempRight, 6, 1) = "Y", "X", "")
                        v_gridRow.Cells("AUTHMATRIX").Value = IIf(Mid(v_strTempRight, 6, 1) = "Y", "X", "")
                        v_gridRow.Cells("AUTHNUMSIG").Value = IIf(Mid(v_strTempRight, 6, 1) = "Y", "X", "") '2.1.3.0|iss 1594
                        v_gridRow.Cells("AUTHOTPSMS").Value = IIf(Mid(v_strTempRight, 6, 1) = "Y", "X", "") 'OTP SMS
                    Else
                        v_gridRow.Cells("VIEWR").Value = ""
                        v_gridRow.Cells("SUBMITR").Value = ""
                        v_gridRow.Cells("EDITR").Value = ""
                        v_gridRow.Cells("SEARCHR").Value = ""
                        v_gridRow.Cells("AUTHPASS").Value = ""
                        v_gridRow.Cells("AUTHTOKEN").Value = ""
                        v_gridRow.Cells("AUTHMATRIX").Value = ""
                        v_gridRow.Cells("AUTHNUMSIG").Value = "" '2.1.3.0|iss 1594
                        v_gridRow.Cells("AUTHOTPSMS").Value = "" 'OTP SMS
                    End If
                    'If (CStr(v_gridRow.Cells("MENUCODE").Value) = "CASHTRANS" Or CStr(v_gridRow.Cells("MENUCODE").Value) = "ADWINPUT" Or _
                    '    CStr(v_gridRow.Cells("MENUCODE").Value) = "ISSUEINPUT" Or CStr(v_gridRow.Cells("MENUCODE").Value) = "MORTGAGE" Or _
                    '    CStr(v_gridRow.Cells("MENUCODE").Value) = "BONDSTOSHARES") Then
                    '    v_gridRow.Cells("AUTHTOKEN").Value = "X"
                    'End If
                    'If (CStr(v_gridRow.Cells("MENUCODE").Value) = "ORDINPUT" Or CStr(v_gridRow.Cells("MENUCODE").Value) = "COND_ORDER" Or _
                    '    CStr(v_gridRow.Cells("MENUCODE").Value) = "GROUP_ORDER") Then
                    '    v_gridRow.Cells("AUTHPASS").Value = "X"
                    'End If
                Next
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                                    & "Error code: System error!" & vbNewLine _
                                    & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ResourceManager.GetString("SavingFailed"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Function GetRight2Save() As String
        Try
            Dim v_strRight2Save As String = String.Empty

            'Get general information

            v_strRight2Save = Me.CustID & "|" _
                            & txtAUTHCUSTID.Text & "|" _
                            & cboAUTHTYPE.SelectedValue & "|" _
                            & CStr(dtpVALDATE.Value) & "|" _
                            & CStr(dtpEXPDATE.Value) & "|" _
                            & CStr(txtSERIALTOKEN.Text) & "|" _
                            & Me.Custodycd & "|" _
                            & Me.email & "|" _
                            & Me.mobilesms & "|" _
                            & Me.fullname & "|" _
                            & cboASGNTYPE.SelectedValue & "|" _
                            & Me.cboVia.SelectedValue & "#" '2.1.3.0|iss 1594

            'Get right information
            Dim v_strRight As String
            For i As Integer = 0 To OTRightAuthGrid.DataRows.Count - 1
                Dim v_gridRow As Xceed.Grid.DataRow = OTRightAuthGrid.DataRows(i)
                '2.1.3.0|iss 1594
                v_strRight &= CStr(v_gridRow.Cells("MENUCODE").Value) & "|" _
                            & IIf(CStr(v_gridRow.Cells("VIEWR").Value) = "X", "Y", "N") _
                            & IIf(CStr(v_gridRow.Cells("SUBMITR").Value) = "X", "Y", "N") _
                            & IIf(CStr(v_gridRow.Cells("EDITR").Value) = "X", "Y", "N") _
                            & IIf(CStr(v_gridRow.Cells("SEARCHR").Value) = "X", "Y", "N") _
                            & IIf(CStr(v_gridRow.Cells("AUTHPASS").Value) = "X", "Y", "N") _
                            & IIf(CStr(v_gridRow.Cells("AUTHTOKEN").Value) = "X", "Y", "N") _
                            & IIf(CStr(v_gridRow.Cells("AUTHMATRIX").Value) = "X", "Y", "N") _
                            & IIf(CStr(v_gridRow.Cells("AUTHNUMSIG").Value) = "X", "Y", "N") _
                            & IIf(CStr(v_gridRow.Cells("AUTHOTPSMS").Value) = "X", "Y", "N") _
                            & "$"
                '& IIf(CStr(v_gridRow.Cells("AUTHOTPSMS").Value) = "X", "Y", "N") _
            Next
            v_strRight2Save &= v_strRight

            Return v_strRight2Save
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                                    & "Error code: System error!" & vbNewLine _
                                    & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ResourceManager.GetString("SavingFailed"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function


#End Region

#Region " Control validations "
    Private Function ControlValidation(Optional ByVal pv_blnSaved As Boolean = False) As Boolean
        Try
            If ExeFlag = ExecuteFlag.Edit Then
                Me.dtpEXPDATE.Enabled = True
                Me.dtpVALDATE.Enabled = True
            End If

            If pv_blnSaved Then
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

    Private Sub txtAUTHCUSTODYCD_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.F5
                Dim frm As New frmSearch(Me.UserLanguage)
                frm.TableName = "CFMAST_NEW"
                frm.ModuleCode = "CF"
                frm.AuthCode = "NNNNYYNNNN" 'Không cho phép thực hiện chức năng nào 
                frm.IsLocalSearch = gc_IsNotLocalMsg
                frm.IsLookup = "Y"
                frm.SearchOnInit = False
                frm.BranchId = Me.BranchId
                frm.TellerId = Me.TellerId
                frm.ShowDialog()
                Me.txtAUTHCUSTID.Text = Trim(frm.ReturnValue)
                frm.Dispose()
        End Select
    End Sub

    Private Sub OTRightAuthGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OTRightAuthGrid.Click
        Dim v_gridRow As Xceed.Grid.DataRow = OTRightAuthGrid.CurrentRow
        If Not OTRightAuthGrid.CurrentColumn Is Nothing Then
            If (InStr("SAUTHTOKEN/AUTHPASS/AUTHMATRIX/AUTHNUMSIG/AUTHOTPSMS", OTRightAuthGrid.CurrentColumn.FieldName) > 0) And ExeFlag <> ExecuteFlag.View Then '2.1.3.0|iss 1594
                If OTRightAuthGrid.CurrentCell.Value = "X" Then
                    OTRightAuthGrid.CurrentCell.Value = String.Empty
                Else
                    OTRightAuthGrid.CurrentCell.Value = "X"
                End If
            End If
            If (InStr("SUBMITR", OTRightAuthGrid.CurrentColumn.FieldName) > 0) And ExeFlag <> ExecuteFlag.View Then
                If OTRightAuthGrid.CurrentCell.Value = "X" Then
                    OTRightAuthGrid.CurrentCell.Value = String.Empty
                Else
                    OTRightAuthGrid.CurrentCell.Value = "X"
                    v_gridRow.Cells("EDITR").Value = "X"
                    v_gridRow.Cells("SEARCHR").Value = "X"
                    v_gridRow.Cells("VIEWR").Value = "X"
                End If
            End If
            If (InStr("EDITR", OTRightAuthGrid.CurrentColumn.FieldName) > 0) And ExeFlag <> ExecuteFlag.View Then
                If OTRightAuthGrid.CurrentCell.Value = "X" Then
                    OTRightAuthGrid.CurrentCell.Value = String.Empty
                    v_gridRow.Cells("SUBMITR").Value = String.Empty
                Else
                    OTRightAuthGrid.CurrentCell.Value = "X"
                    v_gridRow.Cells("SEARCHR").Value = "X"
                    v_gridRow.Cells("VIEWR").Value = "X"
                End If
            End If
            If (InStr("SEARCHR", OTRightAuthGrid.CurrentColumn.FieldName) > 0) And ExeFlag <> ExecuteFlag.View Then
                If OTRightAuthGrid.CurrentCell.Value = "X" Then
                    OTRightAuthGrid.CurrentCell.Value = String.Empty
                    v_gridRow.Cells("SUBMITR").Value = String.Empty
                    v_gridRow.Cells("EDITR").Value = String.Empty
                Else
                    OTRightAuthGrid.CurrentCell.Value = "X"
                    v_gridRow.Cells("VIEWR").Value = "X"
                End If
            End If
            If (InStr("VIEWR", OTRightAuthGrid.CurrentColumn.FieldName) > 0) And ExeFlag <> ExecuteFlag.View Then
                If OTRightAuthGrid.CurrentCell.Value = "X" Then
                    OTRightAuthGrid.CurrentCell.Value = String.Empty
                    v_gridRow.Cells("SUBMITR").Value = String.Empty
                    v_gridRow.Cells("EDITR").Value = String.Empty
                    v_gridRow.Cells("SEARCHR").Value = String.Empty
                Else
                    OTRightAuthGrid.CurrentCell.Value = "X"
                End If
            End If
        End If
    End Sub


    Private Sub cboASGNTYPE_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboASGNTYPE.SelectedIndexChanged
        If Not cboASGNTYPE.SelectedValue Is DBNull.Value Then
            If cboASGNTYPE.SelectedValue = "DEFAULT" Then
                SetDefaultOTRIGHT()
            End If
        End If
    End Sub

    Private Sub txtAUTHCUSTID_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtAUTHCUSTID.Validating
        txtAUTHCUSTID.Text = txtAUTHCUSTID.Text.ToUpper
        If txtAUTHCUSTID.Text.Replace(".", "").Length = 10 Then
            GetCustomerInfor()
        ElseIf txtAUTHCUSTID.Text.Replace(".", "").Length = 0 Then

        Else
            MsgBox(ResourceManager.GetString("ACCTNO_INVALID"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            Me.txtAUTHCUSTID.Focus()
        End If
    End Sub
    Private Sub cboAUTHTYPE_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAUTHTYPE.SelectedIndexChanged
        If cboAUTHTYPE.SelectedValue Is DBNull.Value Then
            txtSERIALTOKEN.Enabled = True
        Else
            If (Not cboAUTHTYPE.SelectedValue Is DBNull.Value AndAlso (cboAUTHTYPE.SelectedValue = "0" Or cboAUTHTYPE.SelectedValue = "1")) Then
                txtSERIALTOKEN.Enabled = False
                'PhuNh txtSERIALTOKEN.Text = OldSerial: luu lai serial
                txtSERIALTOKEN.Text = OldSerial
            Else
                'PhuNh txtSERIALTOKEN.Text = OldSerial: hien thi serial dang dung
                'txtSERIALTOKEN.Text = OldSerial
                txtSERIALTOKEN.Enabled = True
            End If
        End If
        If Not cboAUTHTYPE.SelectedValue Is DBNull.Value AndAlso Not OTRightAuthGrid Is Nothing Then
            If cboAUTHTYPE.SelectedValue = "0" Then
                Me.OTRightAuthGrid.Columns("AUTHPASS").Visible = True
                Me.OTRightAuthGrid.Columns("AUTHTOKEN").Visible = False
                Me.OTRightAuthGrid.Columns("AUTHMATRIX").Visible = False
                Me.OTRightAuthGrid.Columns("AUTHNUMSIG").Visible = False '2.1.3.0|iss 1594
                Me.OTRightAuthGrid.Columns("AUTHOTPSMS").Visible = False 'OTP SMS
                SetDefaultOTRIGHT()
                For i As Integer = 0 To OTRightAuthGrid.DataRows.Count - 1
                    If OTRightAuthGrid.DataRows(i).Cells("MENUCODE").Value <> "TERMDEPOSIT" _
                    AndAlso OTRightAuthGrid.DataRows(i).Cells("MENUCODE").Value <> "ADMINMESSAGES" _
                    AndAlso OTRightAuthGrid.DataRows(i).Cells("MENUCODE").Value <> "ADMINBRANCH" _
                    AndAlso OTRightAuthGrid.DataRows(i).Cells("MENUCODE").Value <> "AGENTSETTING" Then
                        OTRightAuthGrid.DataRows(i).Cells("AUTHPASS").Value = String.Empty
                        OTRightAuthGrid.DataRows(i).Cells("AUTHTOKEN").Value = String.Empty
                        OTRightAuthGrid.DataRows(i).Cells("AUTHMATRIX").Value = String.Empty
                        OTRightAuthGrid.DataRows(i).Cells("AUTHNUMSIG").Value = String.Empty '2.1.3.0|iss 1594
                        OTRightAuthGrid.DataRows(i).Cells("AUTHOTPSMS").Value = String.Empty 'OTP SMS
                    End If
                Next
            ElseIf cboAUTHTYPE.SelectedValue = "1" Then
                Me.OTRightAuthGrid.Columns("AUTHPASS").Visible = True
                Me.OTRightAuthGrid.Columns("AUTHTOKEN").Visible = False
                Me.OTRightAuthGrid.Columns("AUTHMATRIX").Visible = False
                Me.OTRightAuthGrid.Columns("AUTHNUMSIG").Visible = False '2.1.3.0|iss 1594
                Me.OTRightAuthGrid.Columns("AUTHOTPSMS").Visible = False 'OTP SMS
                SetDefaultOTRIGHT()
                For i As Integer = 0 To OTRightAuthGrid.DataRows.Count - 1
                    If OTRightAuthGrid.DataRows(i).Cells("MENUCODE").Value <> "TERMDEPOSIT" _
                    AndAlso OTRightAuthGrid.DataRows(i).Cells("MENUCODE").Value <> "ADMINMESSAGES" _
                    AndAlso OTRightAuthGrid.DataRows(i).Cells("MENUCODE").Value <> "ADMINBRANCH" _
                    AndAlso OTRightAuthGrid.DataRows(i).Cells("MENUCODE").Value <> "AGENTSETTING" Then
                        OTRightAuthGrid.DataRows(i).Cells("AUTHPASS").Value = "X"
                        OTRightAuthGrid.DataRows(i).Cells("AUTHTOKEN").Value = String.Empty
                        OTRightAuthGrid.DataRows(i).Cells("AUTHMATRIX").Value = String.Empty
                        OTRightAuthGrid.DataRows(i).Cells("AUTHNUMSIG").Value = String.Empty '2.1.3.0|iss 1594
                        OTRightAuthGrid.DataRows(i).Cells("AUTHOTPSMS").Value = String.Empty 'OTP SMS
                    End If
                Next
            ElseIf cboAUTHTYPE.SelectedValue = "2" Then
                Me.OTRightAuthGrid.Columns("AUTHPASS").Visible = False
                Me.OTRightAuthGrid.Columns("AUTHTOKEN").Visible = True
                Me.OTRightAuthGrid.Columns("AUTHMATRIX").Visible = False
                Me.OTRightAuthGrid.Columns("AUTHNUMSIG").Visible = False '2.1.3.0|iss 1594
                Me.OTRightAuthGrid.Columns("AUTHOTPSMS").Visible = False 'OTP SMS
                SetDefaultOTRIGHT()
                For i As Integer = 0 To OTRightAuthGrid.DataRows.Count - 1
                    If OTRightAuthGrid.DataRows(i).Cells("MENUCODE").Value <> "TERMDEPOSIT" _
                    AndAlso OTRightAuthGrid.DataRows(i).Cells("MENUCODE").Value <> "ADMINMESSAGES" _
                    AndAlso OTRightAuthGrid.DataRows(i).Cells("MENUCODE").Value <> "ADMINBRANCH" _
                    AndAlso OTRightAuthGrid.DataRows(i).Cells("MENUCODE").Value <> "AGENTSETTING" Then
                        OTRightAuthGrid.DataRows(i).Cells("AUTHPASS").Value = String.Empty
                        OTRightAuthGrid.DataRows(i).Cells("AUTHTOKEN").Value = "X"
                        OTRightAuthGrid.DataRows(i).Cells("AUTHMATRIX").Value = String.Empty
                        OTRightAuthGrid.DataRows(i).Cells("AUTHNUMSIG").Value = String.Empty '2.1.3.0|iss 1594
                        OTRightAuthGrid.DataRows(i).Cells("AUTHOTPSMS").Value = String.Empty 'OTP SMS
                    End If
                Next
                'If (txtSERIALTOKEN.Text.Length = 0) Then
                '    MsgBox(ResourceManager.GetString("SERIALTOKEN_INVALID_1"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                'End If
            ElseIf cboAUTHTYPE.SelectedValue = "3" Then
                Me.OTRightAuthGrid.Columns("AUTHPASS").Visible = False
                Me.OTRightAuthGrid.Columns("AUTHTOKEN").Visible = False
                Me.OTRightAuthGrid.Columns("AUTHMATRIX").Visible = True
                Me.OTRightAuthGrid.Columns("AUTHNUMSIG").Visible = False '2.1.3.0|iss 1594
                Me.OTRightAuthGrid.Columns("AUTHOTPSMS").Visible = False 'OTP SMS
                SetDefaultOTRIGHT()
                For i As Integer = 0 To OTRightAuthGrid.DataRows.Count - 1
                    If OTRightAuthGrid.DataRows(i).Cells("MENUCODE").Value <> "TERMDEPOSIT" _
                    AndAlso OTRightAuthGrid.DataRows(i).Cells("MENUCODE").Value <> "ADMINMESSAGES" _
                    AndAlso OTRightAuthGrid.DataRows(i).Cells("MENUCODE").Value <> "ADMINBRANCH" _
                    AndAlso OTRightAuthGrid.DataRows(i).Cells("MENUCODE").Value <> "AGENTSETTING" Then
                        OTRightAuthGrid.DataRows(i).Cells("AUTHPASS").Value = String.Empty
                        OTRightAuthGrid.DataRows(i).Cells("AUTHTOKEN").Value = String.Empty
                        OTRightAuthGrid.DataRows(i).Cells("AUTHMATRIX").Value = "X"
                        OTRightAuthGrid.DataRows(i).Cells("AUTHNUMSIG").Value = String.Empty '2.1.3.0|iss 1594
                        OTRightAuthGrid.DataRows(i).Cells("AUTHOTPSMS").Value = String.Empty 'OTP SMS
                    End If
                Next
            ElseIf cboAUTHTYPE.SelectedValue = "4" Then
                Me.OTRightAuthGrid.Columns("AUTHPASS").Visible = False
                Me.OTRightAuthGrid.Columns("AUTHTOKEN").Visible = False
                Me.OTRightAuthGrid.Columns("AUTHMATRIX").Visible = False
                Me.OTRightAuthGrid.Columns("AUTHNUMSIG").Visible = True '2.1.3.0|iss 1594
                Me.OTRightAuthGrid.Columns("AUTHOTPSMS").Visible = False 'OTP SMS
                For i As Integer = 0 To OTRightAuthGrid.DataRows.Count - 1
                    OTRightAuthGrid.DataRows(i).Cells("VIEWR").Value = String.Empty
                    OTRightAuthGrid.DataRows(i).Cells("SUBMITR").Value = String.Empty
                    OTRightAuthGrid.DataRows(i).Cells("EDITR").Value = String.Empty
                    OTRightAuthGrid.DataRows(i).Cells("SEARCHR").Value = String.Empty
                    If OTRightAuthGrid.DataRows(i).Cells("MENUCODE").Value = "ORDINPUT" _
                    Or OTRightAuthGrid.DataRows(i).Cells("MENUCODE").Value = "COND_ORDER" _
                    Or OTRightAuthGrid.DataRows(i).Cells("MENUCODE").Value = "GROUP_ORDER" Then
                        OTRightAuthGrid.DataRows(i).Cells("AUTHPASS").Value = String.Empty
                        OTRightAuthGrid.DataRows(i).Cells("AUTHTOKEN").Value = String.Empty
                        OTRightAuthGrid.DataRows(i).Cells("AUTHMATRIX").Value = String.Empty
                        OTRightAuthGrid.DataRows(i).Cells("AUTHNUMSIG").Value = "X" '2.1.3.0|iss 1594
                        OTRightAuthGrid.DataRows(i).Cells("AUTHOTPSMS").Value = String.Empty 'OTP SMS
                        OTRightAuthGrid.DataRows(i).Cells("VIEWR").Value = "X"
                        OTRightAuthGrid.DataRows(i).Cells("SUBMITR").Value = "X"
                        OTRightAuthGrid.DataRows(i).Cells("EDITR").Value = "X"
                        OTRightAuthGrid.DataRows(i).Cells("SEARCHR").Value = "X"
                    End If
                Next
            ElseIf cboAUTHTYPE.SelectedValue = "5" Then
                Me.OTRightAuthGrid.Columns("AUTHPASS").Visible = False
                Me.OTRightAuthGrid.Columns("AUTHTOKEN").Visible = False
                Me.OTRightAuthGrid.Columns("AUTHMATRIX").Visible = False
                Me.OTRightAuthGrid.Columns("AUTHNUMSIG").Visible = False '2.1.3.0|iss 1594
                Me.OTRightAuthGrid.Columns("AUTHOTPSMS").Visible = True 'OTP SMS
                For i As Integer = 0 To OTRightAuthGrid.DataRows.Count - 1
                    OTRightAuthGrid.DataRows(i).Cells("VIEWR").Value = String.Empty
                    OTRightAuthGrid.DataRows(i).Cells("SUBMITR").Value = String.Empty
                    OTRightAuthGrid.DataRows(i).Cells("EDITR").Value = String.Empty
                    OTRightAuthGrid.DataRows(i).Cells("SEARCHR").Value = String.Empty
                    If OTRightAuthGrid.DataRows(i).Cells("MENUCODE").Value = "ORDINPUT" _
                    Or OTRightAuthGrid.DataRows(i).Cells("MENUCODE").Value = "COND_ORDER" _
                    Or OTRightAuthGrid.DataRows(i).Cells("MENUCODE").Value = "GROUP_ORDER" Then
                        OTRightAuthGrid.DataRows(i).Cells("AUTHPASS").Value = String.Empty
                        OTRightAuthGrid.DataRows(i).Cells("AUTHTOKEN").Value = String.Empty
                        OTRightAuthGrid.DataRows(i).Cells("AUTHMATRIX").Value = String.Empty
                        OTRightAuthGrid.DataRows(i).Cells("AUTHNUMSIG").Value = String.Empty '2.1.3.0|iss 1594
                        OTRightAuthGrid.DataRows(i).Cells("AUTHOTPSMS").Value = "X" 'OTP SMS
                        OTRightAuthGrid.DataRows(i).Cells("VIEWR").Value = "X"
                        OTRightAuthGrid.DataRows(i).Cells("SUBMITR").Value = "X"
                        OTRightAuthGrid.DataRows(i).Cells("EDITR").Value = "X"
                        OTRightAuthGrid.DataRows(i).Cells("SEARCHR").Value = "X"
                    End If
                Next
                'If (txtSERIALTOKEN.Text.Length = 0) Then
                '    MsgBox(ResourceManager.GetString("SERIALTOKEN_INVALID_2"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                'End If
            End If
        End If
    End Sub
#End Region
    '2.1.3.0|iss1646
    Private Sub txtSERIALTOKEN_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSERIALTOKEN.Leave
        Me.txtSERIALTOKEN.Text = UCase(Me.txtSERIALTOKEN.Text)
    End Sub

End Class
