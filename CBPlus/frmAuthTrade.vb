Public Class frmAuthTrading
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal pv_strLanguage As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.LANGUAGE = pv_strLanguage
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
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents pnConfirm As System.Windows.Forms.Panel
    Friend WithEvents lblConfirm As System.Windows.Forms.Label
    Friend WithEvents lblCaption As System.Windows.Forms.Label
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAuthTrading))
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.lblPassword = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.lblCaption = New System.Windows.Forms.Label
        Me.pnConfirm = New System.Windows.Forms.Panel
        Me.lblConfirm = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnConfirm.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleDescription = "Cancel"
        Me.btnCancel.AccessibleName = "Cancel"
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnCancel.Location = New System.Drawing.Point(408, 224)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 24)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "&Cancel"
        '
        'btnOK
        '
        Me.btnOK.AccessibleDescription = "OK"
        Me.btnOK.AccessibleName = "OK"
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnOK.Location = New System.Drawing.Point(328, 224)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(80, 24)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "&OK"
        '
        'txtPassword
        '
        Me.txtPassword.AccessibleDescription = "Password"
        Me.txtPassword.AccessibleName = "Password"
        Me.txtPassword.Location = New System.Drawing.Point(96, 224)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(224, 20)
        Me.txtPassword.TabIndex = 2
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Location = New System.Drawing.Point(8, 224)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(56, 13)
        Me.lblPassword.TabIndex = 1
        Me.lblPassword.Text = "Password:"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.lblCaption)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(488, 50)
        Me.Panel1.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(21, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 32)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'lblCaption
        '
        Me.lblCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaption.Location = New System.Drawing.Point(72, 16)
        Me.lblCaption.Name = "lblCaption"
        Me.lblCaption.Size = New System.Drawing.Size(280, 16)
        Me.lblCaption.TabIndex = 0
        Me.lblCaption.Text = "Enter your trading password."
        '
        'pnConfirm
        '
        Me.pnConfirm.Controls.Add(Me.lblConfirm)
        Me.pnConfirm.Location = New System.Drawing.Point(0, 56)
        Me.pnConfirm.Name = "pnConfirm"
        Me.pnConfirm.Size = New System.Drawing.Size(488, 160)
        Me.pnConfirm.TabIndex = 18
        '
        'lblConfirm
        '
        Me.lblConfirm.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConfirm.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lblConfirm.Location = New System.Drawing.Point(0, 0)
        Me.lblConfirm.Name = "lblConfirm"
        Me.lblConfirm.Size = New System.Drawing.Size(488, 160)
        Me.lblConfirm.TabIndex = 0
        Me.lblConfirm.Text = "Customer Confirmation"
        Me.lblConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmAuthTrading
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(488, 253)
        Me.Controls.Add(Me.pnConfirm)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAuthTrading"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Authenticate Trading"
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnConfirm.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region " Private section "
    Const c_ResourceManager = gc_RootNamespace & "." & "frmAuthTrade-"
    Private mv_ResourceManager As Resources.ResourceManager

    Private mv_strLANGUAGE As String
    Private mv_strPASSWORD As String
    Private mv_strORDERCONTENT As String
    Private mv_strFULLNAME As String
    Private mv_strLICENSE As String
    Private mv_strPHONE As String
    Private mv_blnRESULT As Boolean = False

    Public Property RESULT() As Boolean
        Get
            Return mv_blnRESULT
        End Get
        Set(ByVal Value As Boolean)
            mv_blnRESULT = Value
        End Set
    End Property

    Public Property FULLNAME() As String
        Get
            Return mv_strFULLNAME
        End Get
        Set(ByVal Value As String)
            mv_strFULLNAME = Value
        End Set
    End Property

    Public Property LICENSE() As String
        Get
            Return mv_strLICENSE
        End Get
        Set(ByVal Value As String)
            mv_strLICENSE = Value
        End Set
    End Property

    Public Property PHONE() As String
        Get
            Return mv_strPHONE
        End Get
        Set(ByVal Value As String)
            mv_strPHONE = Value
        End Set
    End Property

    Public Property LANGUAGE() As String
        Get
            Return mv_strLANGUAGE
        End Get
        Set(ByVal Value As String)
            mv_strLANGUAGE = Value
        End Set
    End Property

    Public Property PASSWORD() As String
        Get
            Return mv_strPASSWORD
        End Get
        Set(ByVal Value As String)
            mv_strPASSWORD = Value
        End Set
    End Property

    Public Property ORDERCONTENT() As String
        Get
            Return mv_strORDERCONTENT
        End Get
        Set(ByVal Value As String)
            mv_strORDERCONTENT = Value
        End Set
    End Property

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
            End If
        Next
        Me.Text = mv_ResourceManager.GetString(Me.Name)
    End Sub
#End Region

#Region " Form events "
    Private Sub frmAuthTrading_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Khoi tao resource
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & Me.LANGUAGE, System.Reflection.Assembly.GetExecutingAssembly())
        LoadResource(Me)
        Me.lblConfirm.Text = Me.ORDERCONTENT
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If Me.PASSWORD = Me.txtPassword.Text.Trim Then
            Me.RESULT = True
            Me.Close()
        Else
            'MessageBox.Show("Incorrect password, please retype!")
            MsgBox(mv_ResourceManager.GetString("ERR_INVALID_PWD"))
            Me.ActiveControl = Me.txtPassword
            Me.RESULT = False
        End If

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.PASSWORD = String.Empty
        Me.Close()
    End Sub

    Private Sub frmAuthTrading_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Select Case e.KeyCode
            Case Keys.Escape
                Me.PASSWORD = String.Empty
                Me.Close()
            Case Keys.Enter
                If Me.PASSWORD = Me.txtPassword.Text.Trim Then
                    Me.RESULT = True
                    Me.Close()
                Else
                    'MessageBox.Show("Incorrect password, please retype!")
                    MsgBox(mv_ResourceManager.GetString("ERR_INVALID_PWD"))
                    Me.ActiveControl = Me.txtPassword
                    Me.RESULT = False
                End If
        End Select
    End Sub
#End Region

End Class
