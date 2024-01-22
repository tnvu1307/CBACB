Imports Microsoft.Win32
Imports CommonLibrary
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class frmXtraLogin
    Inherits DevExpress.XtraEditors.XtraForm

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal bl As CBusLayer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        m_BusLayer = bl
        m_ResourceManager = New Resources.ResourceManager("_DIRECT.Localize-" & m_BusLayer.AppLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        m_ResourceManager_LOGIN = New Resources.ResourceManager("_DIRECT.frmXtraLOGIN-" & m_BusLayer.AppLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        SetCultureInfo()
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

    Public Sub SetCultureInfo()

        Dim appLanguage As String = m_BusLayer.AppLanguage
        If Not String.IsNullOrEmpty(appLanguage) Then
            If appLanguage = "EN" Then
                System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

            End If
            If appLanguage = "VN" Then
                System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("vi-VN")

            End If
        End If
        Dim newCulture As System.Globalization.CultureInfo = CType(System.Threading.Thread.CurrentThread.CurrentCulture.Clone(), System.Globalization.CultureInfo)
        newCulture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        newCulture.NumberFormat.NumberDecimalSeparator = "."
        newCulture.NumberFormat.NumberGroupSeparator = ","
        newCulture.DateTimeFormat.DateSeparator = "/"

        System.Threading.Thread.CurrentThread.CurrentCulture = newCulture
    End Sub


    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lcUsername As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lcPassword As DevExpress.XtraEditors.LabelControl
    Friend WithEvents teUsername As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tePassword As DevExpress.XtraEditors.TextEdit
    Friend WithEvents ceSavePassword As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents sbLogin As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents sbLoginMicrosoft As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DataTable1 As DataTable
    Friend WithEvents DataTable2 As DataTable
    Friend WithEvents DataTable3 As DataTable
    Friend WithEvents DataTable4 As DataTable
    Friend WithEvents DataTable5 As DataTable
    Friend WithEvents DataTable6 As DataTable
    Friend WithEvents DataTable7 As DataTable
    Friend WithEvents DataTable8 As DataTable
    Friend WithEvents DataTable9 As DataTable
    Friend WithEvents DataTable10 As DataTable
    Friend WithEvents DataTable11 As DataTable
    Friend WithEvents DataTable12 As DataTable
    Friend WithEvents DataTable13 As DataTable
    Friend WithEvents DataTable14 As DataTable
    Friend WithEvents DataTable15 As DataTable
    Friend WithEvents DataTable16 As DataTable
    Friend WithEvents DataTable17 As DataTable
    Friend WithEvents DataTable18 As DataTable
    Friend WithEvents DataTable19 As DataTable
    Friend WithEvents DataTable20 As DataTable
    Friend WithEvents DataTable21 As DataTable
    Friend WithEvents DataTable22 As DataTable
    Friend WithEvents DataTable23 As DataTable
    Friend WithEvents DataTable24 As DataTable
    Friend WithEvents DataTable25 As DataTable
    Friend WithEvents DataTable26 As DataTable
    Friend WithEvents DataTable27 As DataTable
    Friend WithEvents DataTable28 As DataTable
    Friend WithEvents DataTable29 As DataTable
    Friend WithEvents DataTable30 As DataTable
    Friend WithEvents DataTable31 As DataTable
    Friend WithEvents DataTable32 As DataTable
    Friend WithEvents DataTable33 As DataTable
    Friend WithEvents DataTable34 As DataTable
    Friend WithEvents DataTable35 As DataTable
    Friend WithEvents DataTable36 As DataTable
    Friend WithEvents DataTable37 As DataTable
    Friend WithEvents DataTable38 As DataTable
    Friend WithEvents DataTable39 As DataTable
    Friend WithEvents DataTable40 As DataTable
    Friend WithEvents DataTable41 As DataTable
    Friend WithEvents DataTable42 As DataTable
    Friend WithEvents DataTable43 As DataTable
    Friend WithEvents DataTable44 As DataTable
    Friend WithEvents DataTable45 As DataTable
    Friend WithEvents DataTable46 As DataTable
    Friend WithEvents DataTable47 As DataTable
    Friend WithEvents DataTable48 As DataTable
    Friend WithEvents sbCancel As DevExpress.XtraEditors.SimpleButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmXtraLogin))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.tePassword = New DevExpress.XtraEditors.TextEdit()
        Me.lcPassword = New DevExpress.XtraEditors.LabelControl()
        Me.teUsername = New DevExpress.XtraEditors.TextEdit()
        Me.lcUsername = New DevExpress.XtraEditors.LabelControl()
        Me.sbLogin = New DevExpress.XtraEditors.SimpleButton()
        Me.sbCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        Me.ceSavePassword = New DevExpress.XtraEditors.CheckEdit()
        Me.sbLoginMicrosoft = New DevExpress.XtraEditors.SimpleButton()
        Me.DataTable1 = New System.Data.DataTable()
        Me.DataTable2 = New System.Data.DataTable()
        Me.DataTable3 = New System.Data.DataTable()
        Me.DataTable4 = New System.Data.DataTable()
        Me.DataTable5 = New System.Data.DataTable()
        Me.DataTable6 = New System.Data.DataTable()
        Me.DataTable7 = New System.Data.DataTable()
        Me.DataTable8 = New System.Data.DataTable()
        Me.DataTable9 = New System.Data.DataTable()
        Me.DataTable10 = New System.Data.DataTable()
        Me.DataTable11 = New System.Data.DataTable()
        Me.DataTable12 = New System.Data.DataTable()
        Me.DataTable13 = New System.Data.DataTable()
        Me.DataTable14 = New System.Data.DataTable()
        Me.DataTable15 = New System.Data.DataTable()
        Me.DataTable16 = New System.Data.DataTable()
        Me.DataTable17 = New System.Data.DataTable()
        Me.DataTable18 = New System.Data.DataTable()
        Me.DataTable19 = New System.Data.DataTable()
        Me.DataTable20 = New System.Data.DataTable()
        Me.DataTable21 = New System.Data.DataTable()
        Me.DataTable22 = New System.Data.DataTable()
        Me.DataTable23 = New System.Data.DataTable()
        Me.DataTable24 = New System.Data.DataTable()
        Me.DataTable25 = New System.Data.DataTable()
        Me.DataTable26 = New System.Data.DataTable()
        Me.DataTable27 = New System.Data.DataTable()
        Me.DataTable28 = New System.Data.DataTable()
        Me.DataTable29 = New System.Data.DataTable()
        Me.DataTable30 = New System.Data.DataTable()
        Me.DataTable31 = New System.Data.DataTable()
        Me.DataTable32 = New System.Data.DataTable()
        Me.DataTable33 = New System.Data.DataTable()
        Me.DataTable34 = New System.Data.DataTable()
        Me.DataTable35 = New System.Data.DataTable()
        Me.DataTable36 = New System.Data.DataTable()
        Me.DataTable37 = New System.Data.DataTable()
        Me.DataTable38 = New System.Data.DataTable()
        Me.DataTable39 = New System.Data.DataTable()
        Me.DataTable40 = New System.Data.DataTable()
        Me.DataTable41 = New System.Data.DataTable()
        Me.DataTable42 = New System.Data.DataTable()
        Me.DataTable43 = New System.Data.DataTable()
        Me.DataTable44 = New System.Data.DataTable()
        Me.DataTable45 = New System.Data.DataTable()
        Me.DataTable46 = New System.Data.DataTable()
        Me.DataTable47 = New System.Data.DataTable()
        Me.DataTable48 = New System.Data.DataTable()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.tePassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.teUsername.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ceSavePassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable26, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable27, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable28, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable29, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable30, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable31, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable32, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable33, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable34, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable35, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable36, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable37, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable38, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable39, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable40, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable41, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable42, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable43, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable44, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable45, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable46, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable47, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable48, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.tePassword, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lcPassword, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.teUsername, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lcUsername, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.sbLogin, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.sbCancel, 2, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.PictureEdit1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ceSavePassword, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.sbLoginMicrosoft, 3, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 160.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(546, 335)
        Me.TableLayoutPanel1.TabIndex = 8
        '
        'tePassword
        '
        Me.tePassword.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.SetColumnSpan(Me.tePassword, 3)
        Me.tePassword.Location = New System.Drawing.Point(176, 195)
        Me.tePassword.Name = "tePassword"
        Me.tePassword.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tePassword.Size = New System.Drawing.Size(367, 20)
        Me.tePassword.TabIndex = 3
        '
        'lcPassword
        '
        Me.lcPassword.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lcPassword.Location = New System.Drawing.Point(3, 198)
        Me.lcPassword.Name = "lcPassword"
        Me.lcPassword.Size = New System.Drawing.Size(48, 13)
        Me.lcPassword.TabIndex = 1
        Me.lcPassword.Text = "Mật khẩu:"
        '
        'teUsername
        '
        Me.teUsername.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.SetColumnSpan(Me.teUsername, 3)
        Me.teUsername.Location = New System.Drawing.Point(176, 165)
        Me.teUsername.Name = "teUsername"
        Me.teUsername.Size = New System.Drawing.Size(367, 20)
        Me.teUsername.TabIndex = 2
        '
        'lcUsername
        '
        Me.lcUsername.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lcUsername.Location = New System.Drawing.Point(3, 168)
        Me.lcUsername.Name = "lcUsername"
        Me.lcUsername.Size = New System.Drawing.Size(76, 13)
        Me.lcUsername.TabIndex = 0
        Me.lcUsername.Text = "Tên đăng nhập:"
        '
        'sbLogin
        '
        Me.sbLogin.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbLogin.Image = CType(resources.GetObject("sbLogin.Image"), System.Drawing.Image)
        Me.sbLogin.Location = New System.Drawing.Point(179, 297)
        Me.sbLogin.Margin = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.sbLogin.Name = "sbLogin"
        Me.sbLogin.Size = New System.Drawing.Size(88, 25)
        Me.sbLogin.TabIndex = 6
        Me.sbLogin.Text = "Đăng &nhập"
        '
        'sbCancel
        '
        Me.sbCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.sbCancel.Image = CType(resources.GetObject("sbCancel.Image"), System.Drawing.Image)
        Me.sbCancel.Location = New System.Drawing.Point(279, 297)
        Me.sbCancel.Margin = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.sbCancel.Name = "sbCancel"
        Me.sbCancel.Size = New System.Drawing.Size(88, 25)
        Me.sbCancel.TabIndex = 7
        Me.sbCancel.Text = "&Thoát"
        '
        'PictureEdit1
        '
        Me.PictureEdit1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.TableLayoutPanel1.SetColumnSpan(Me.PictureEdit1, 4)
        Me.PictureEdit1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureEdit1.EditValue = Global._DIRECT.My.Resources.Resources.new_sh
        Me.PictureEdit1.Location = New System.Drawing.Point(0, 0)
        Me.PictureEdit1.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureEdit1.Name = "PictureEdit1"
        Me.PictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.PictureEdit1.Properties.Appearance.Options.UseBackColor = True
        Me.PictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PictureEdit1.Size = New System.Drawing.Size(546, 160)
        Me.PictureEdit1.TabIndex = 7
        '
        'ceSavePassword
        '
        Me.ceSavePassword.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.SetColumnSpan(Me.ceSavePassword, 2)
        Me.ceSavePassword.Location = New System.Drawing.Point(176, 225)
        Me.ceSavePassword.Name = "ceSavePassword"
        Me.ceSavePassword.Properties.Caption = "Lưu mật khẩu"
        Me.ceSavePassword.Size = New System.Drawing.Size(194, 19)
        Me.ceSavePassword.TabIndex = 5
        '
        'sbLoginMicrosoft
        '
        Me.sbLoginMicrosoft.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbLoginMicrosoft.Image = CType(resources.GetObject("sbLoginMicrosoft.Image"), System.Drawing.Image)
        Me.sbLoginMicrosoft.Location = New System.Drawing.Point(379, 223)
        Me.sbLoginMicrosoft.Margin = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.sbLoginMicrosoft.Name = "sbLoginMicrosoft"
        Me.sbLoginMicrosoft.Size = New System.Drawing.Size(161, 24)
        Me.sbLoginMicrosoft.TabIndex = 8
        Me.sbLoginMicrosoft.Text = "Đăng nhập bằng Microsoft"
        '
        'DataTable1
        '
        Me.DataTable1.Namespace = ""
        Me.DataTable1.TableName = "COMBOBOX"
        '
        'DataTable2
        '
        Me.DataTable2.Namespace = ""
        Me.DataTable2.TableName = "COMBOBOX"
        '
        'DataTable3
        '
        Me.DataTable3.Namespace = ""
        Me.DataTable3.TableName = "COMBOBOX"
        '
        'DataTable4
        '
        Me.DataTable4.Namespace = ""
        Me.DataTable4.TableName = "COMBOBOX"
        '
        'DataTable5
        '
        Me.DataTable5.Namespace = ""
        Me.DataTable5.TableName = "COMBOBOX"
        '
        'DataTable6
        '
        Me.DataTable6.Namespace = ""
        Me.DataTable6.TableName = "COMBOBOX"
        '
        'DataTable7
        '
        Me.DataTable7.Namespace = ""
        Me.DataTable7.TableName = "COMBOBOX"
        '
        'DataTable8
        '
        Me.DataTable8.Namespace = ""
        Me.DataTable8.TableName = "COMBOBOX"
        '
        'DataTable9
        '
        Me.DataTable9.Namespace = ""
        Me.DataTable9.TableName = "COMBOBOX"
        '
        'DataTable10
        '
        Me.DataTable10.Namespace = ""
        Me.DataTable10.TableName = "COMBOBOX"
        '
        'DataTable11
        '
        Me.DataTable11.Namespace = ""
        Me.DataTable11.TableName = "COMBOBOX"
        '
        'DataTable12
        '
        Me.DataTable12.Namespace = ""
        Me.DataTable12.TableName = "COMBOBOX"
        '
        'DataTable13
        '
        Me.DataTable13.Namespace = ""
        Me.DataTable13.TableName = "COMBOBOX"
        '
        'DataTable14
        '
        Me.DataTable14.Namespace = ""
        Me.DataTable14.TableName = "COMBOBOX"
        '
        'DataTable15
        '
        Me.DataTable15.Namespace = ""
        Me.DataTable15.TableName = "COMBOBOX"
        '
        'DataTable16
        '
        Me.DataTable16.Namespace = ""
        Me.DataTable16.TableName = "COMBOBOX"
        '
        'DataTable17
        '
        Me.DataTable17.Namespace = ""
        Me.DataTable17.TableName = "COMBOBOX"
        '
        'DataTable18
        '
        Me.DataTable18.Namespace = ""
        Me.DataTable18.TableName = "COMBOBOX"
        '
        'DataTable19
        '
        Me.DataTable19.Namespace = ""
        Me.DataTable19.TableName = "COMBOBOX"
        '
        'DataTable20
        '
        Me.DataTable20.Namespace = ""
        Me.DataTable20.TableName = "COMBOBOX"
        '
        'DataTable21
        '
        Me.DataTable21.Namespace = ""
        Me.DataTable21.TableName = "COMBOBOX"
        '
        'DataTable22
        '
        Me.DataTable22.Namespace = ""
        Me.DataTable22.TableName = "COMBOBOX"
        '
        'DataTable23
        '
        Me.DataTable23.Namespace = ""
        Me.DataTable23.TableName = "COMBOBOX"
        '
        'DataTable24
        '
        Me.DataTable24.Namespace = ""
        Me.DataTable24.TableName = "COMBOBOX"
        '
        'DataTable25
        '
        Me.DataTable25.Namespace = ""
        Me.DataTable25.TableName = "COMBOBOX"
        '
        'DataTable26
        '
        Me.DataTable26.Namespace = ""
        Me.DataTable26.TableName = "COMBOBOX"
        '
        'DataTable27
        '
        Me.DataTable27.Namespace = ""
        Me.DataTable27.TableName = "COMBOBOX"
        '
        'DataTable28
        '
        Me.DataTable28.Namespace = ""
        Me.DataTable28.TableName = "COMBOBOX"
        '
        'DataTable29
        '
        Me.DataTable29.Namespace = ""
        Me.DataTable29.TableName = "COMBOBOX"
        '
        'DataTable30
        '
        Me.DataTable30.Namespace = ""
        Me.DataTable30.TableName = "COMBOBOX"
        '
        'DataTable31
        '
        Me.DataTable31.Namespace = ""
        Me.DataTable31.TableName = "COMBOBOX"
        '
        'DataTable32
        '
        Me.DataTable32.Namespace = ""
        Me.DataTable32.TableName = "COMBOBOX"
        '
        'DataTable33
        '
        Me.DataTable33.Namespace = ""
        Me.DataTable33.TableName = "COMBOBOX"
        '
        'DataTable34
        '
        Me.DataTable34.Namespace = ""
        Me.DataTable34.TableName = "COMBOBOX"
        '
        'DataTable35
        '
        Me.DataTable35.Namespace = ""
        Me.DataTable35.TableName = "COMBOBOX"
        '
        'DataTable36
        '
        Me.DataTable36.Namespace = ""
        Me.DataTable36.TableName = "COMBOBOX"
        '
        'DataTable37
        '
        Me.DataTable37.Namespace = ""
        Me.DataTable37.TableName = "COMBOBOX"
        '
        'DataTable38
        '
        Me.DataTable38.Namespace = ""
        Me.DataTable38.TableName = "COMBOBOX"
        '
        'DataTable39
        '
        Me.DataTable39.Namespace = ""
        Me.DataTable39.TableName = "COMBOBOX"
        '
        'DataTable40
        '
        Me.DataTable40.Namespace = ""
        Me.DataTable40.TableName = "COMBOBOX"
        '
        'DataTable41
        '
        Me.DataTable41.Namespace = ""
        Me.DataTable41.TableName = "COMBOBOX"
        '
        'DataTable42
        '
        Me.DataTable42.Namespace = ""
        Me.DataTable42.TableName = "COMBOBOX"
        '
        'DataTable43
        '
        Me.DataTable43.Namespace = ""
        Me.DataTable43.TableName = "COMBOBOX"
        '
        'DataTable44
        '
        Me.DataTable44.Namespace = ""
        Me.DataTable44.TableName = "COMBOBOX"
        '
        'DataTable45
        '
        Me.DataTable45.Namespace = ""
        Me.DataTable45.TableName = "COMBOBOX"
        '
        'DataTable46
        '
        Me.DataTable46.Namespace = ""
        Me.DataTable46.TableName = "COMBOBOX"
        '
        'DataTable47
        '
        Me.DataTable47.Namespace = ""
        Me.DataTable47.TableName = "COMBOBOX"
        '
        'DataTable48
        '
        Me.DataTable48.Namespace = ""
        Me.DataTable48.TableName = "COMBOBOX"
        '
        'frmXtraLogin
        '
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.sbCancel
        Me.ClientSize = New System.Drawing.Size(546, 335)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmXtraLogin"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.tePassword.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.teUsername.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ceSavePassword.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable26, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable27, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable28, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable29, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable30, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable31, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable32, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable33, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable34, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable35, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable36, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable37, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable38, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable39, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable40, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable41, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable42, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable43, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable44, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable45, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable46, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable47, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable48, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private m_BusLayer As CBusLayer
    Private m_ResourceManager As Resources.ResourceManager
    Private m_ResourceManager_LOGIN As Resources.ResourceManager
    Public mv_SignMode As String = "N"
    Public mv_isValidToken As Boolean = True


    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbCancel.Click
        Me.Close()
    End Sub
    Private Sub getSignMode()
        Dim v_strCmdInquiry As String
        v_strCmdInquiry = "SELECT VARVALUE FROM SYSVAR WHERE VARNAME ='ISSIGNMODE' "
        Dim v_strObjMsg As String = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_SEARCHFLD, gc_ActionInquiry, v_strCmdInquiry, , )
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        v_ws.Message(v_strObjMsg)

        Dim v_xmlDocument As New System.Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_nodeEntry As Xml.XmlNode
        Dim v_strFLDNAME As String
        Dim v_strValue As String

        v_xmlDocument.LoadXml(v_strObjMsg)
        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

        For i As Integer = 0 To v_nodeList.Count - 1
            For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                With v_nodeList.Item(i).ChildNodes(j)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strValue = .InnerText.ToString
                    Select Case Trim(v_strFLDNAME)
                        Case "VARVALUE"
                            mv_SignMode = Trim(v_strValue)
                    End Select
                End With
            Next
        Next
    End Sub
    Private Sub frmLogin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load




        ceSavePassword.Text = m_ResourceManager_LOGIN.GetString("ceSavePassword")
        lcPassword.Text = m_ResourceManager_LOGIN.GetString("lcPassword")
        lcUsername.Text = m_ResourceManager_LOGIN.GetString("lcUsername")
        sbCancel.Text = m_ResourceManager_LOGIN.GetString("sbCancel")
        sbLogin.Text = m_ResourceManager_LOGIN.GetString("sbLogin")
        'Me.cboBusinessArea.SelectedValue = "FA"



        '#If DEBUG Then
        Dim v_strUserName As String = String.Empty
        Dim v_strPassword As String = String.Empty

        Try

            ceSavePassword.Visible = True

            Dim v_regKey As RegistryKey = Registry.CurrentUser.OpenSubKey(gc_RegistryKey)

            If Not v_regKey Is Nothing Then
                v_strUserName = CType(v_regKey.GetValue("UserName"), String)
                'v_strPassword = DataProtection.UnprotectData(CType(v_regKey.GetValue("Password"), String))
                v_strPassword = CStr(v_regKey.GetValue("Password"))
                v_regKey.Close()
            End If
        Catch ex As Exception
            LogError.Write(ex.Message & vbCrLf & ex.StackTrace, EventLogEntryType.Error)
        End Try

        If v_strUserName <> String.Empty AndAlso v_strPassword <> String.Empty Then

            teUsername.Text = v_strUserName
            tePassword.Text = v_strPassword
            ceSavePassword.Checked = True

        End If
        '#End If

        Me.Activate()
        teUsername.Focus()
    End Sub

    Private Sub txtUserName_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles teUsername.Enter
        With teUsername
            .SelectionStart = 0
            .SelectionLength = .Text.Length
        End With
    End Sub

    Private Sub txtUsername_KeyPress(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtPassword_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tePassword.Enter
        With tePassword
            .SelectionStart = 0
            .SelectionLength = .Text.Length
        End With
    End Sub

    Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles sbLogin.Click
        DoConfirm()
    End Sub

    Private Sub frmLogin_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.Enter
                If Me.ActiveControl.Parent.Name = "sbLogin" Then
                    DoConfirm()
                ElseIf Me.ActiveControl.Parent.Name = "teUsername" Then
                    Me.tePassword.Focus()
                    Me.tePassword.SelectAll()
                ElseIf Me.ActiveControl.Parent.Name = "tePassword" Then
                    Me.sbLogin.Focus()
                End If
                'If Me.sbLogin.Focused Then
                '    DoConfirm()
                'ElseIf Me.teUsername.Focused Then
                '    Me.tePassword.Focus()
                '    Me.tePassword.SelectAll()
                'ElseIf Me.tePassword.Focused Then
                '    Me.sbLogin.Focus()
                '    'Else
                '    '    SendKeys.Send("{Tab}")
                '    '    e.Handled = True
                'End If

        End Select
    End Sub

    Private Sub DoConfirm()
        'GetVersion()
        Me.DialogResult = DialogResult.None
        Dim v_lngErr As Long
        Dim v_strObjMsg, v_strErrorSource, v_strErrorMessage As String
        Dim v_strSQL As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery


        If teUsername.Text.Trim() <> String.Empty AndAlso tePassword.Text.Trim() <> String.Empty Then
            MyBase.Cursor = Cursors.WaitCursor
            'Dim blResult As BusLayerResult = m_BusLayer.Login(teUserName.Text, DataProtection.ProtectData(tePassword.Text, GetMACAddress()))

            Dim blResult As BusLayerResult = m_BusLayer.Login(teUsername.Text, tePassword.Text)
            MyBase.Cursor = Cursors.Arrow

            If blResult = BusLayerResult.Success Then


                '#If DEBUG Then
                'Vào hệ thống thành công, lưu lại mã truy cập và mật khẩu nếu cần
                Try
                    Dim v_regKey As RegistryKey = Registry.CurrentUser.CreateSubKey(gc_RegistryKey)

                    If ceSavePassword.Checked Then
                        v_regKey.SetValue(gc_REG_USERNAME, teUsername.Text)
                        'v_regKey.SetValue(gc_REG_PASSWORD, DataProtection.ProtectData(tePassword.Text, GetMACAddress()))
                        v_regKey.SetValue(gc_REG_PASSWORD, tePassword.Text)
                    Else
                        v_regKey.DeleteValue(gc_REG_USERNAME, False)
                        v_regKey.DeleteValue(gc_REG_PASSWORD, False)
                    End If
                    v_regKey.Close()
                Catch ex As Exception
                    LogError.Write(ex.Message & vbCrLf & ex.StackTrace, EventLogEntryType.Error)
                End Try
                '#End If
                Me.DialogResult = DialogResult.OK
                Me.Close()
            Else
                teUsername.SelectAll()
                teUsername.Focus()

                If blResult = BusLayerResult.ServiceFailure Then
                    MsgBox(m_ResourceManager.GetString(gc_SYSERR_SVR_ERROR) & " " & m_ResourceManager.GetString(gc_SYSERR_CONTACT_NET_ADMIN),
                        MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                ElseIf blResult = BusLayerResult.ConnectionFailure Then
                    MsgBox(m_ResourceManager.GetString(gc_SYSERR_SRV_UNREACHABLE) & " " & m_ResourceManager.GetString(gc_SYSERR_CHECK_CONNECTION),
                        MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                ElseIf blResult = BusLayerResult.AuthenticationFailure Then
                    MsgBox(m_ResourceManager.GetString(gc_SYSERR_INCORRECT_USR_OR_PWD) & " " & m_ResourceManager.GetString(gc_SYSERR_RE_TYPE),
                        MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                ElseIf blResult = CType(BusLayerResult.AccountBlock, String) Then
                    MsgBox("Tài khoản của bạn đã bị khóa. Vui lòng liên hệ admin để được hỗ trợ!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                Else
                    MsgBox(m_ResourceManager.GetString(gc_SYSERR_UNKNOWN_ERROR) & " " & m_ResourceManager.GetString(gc_SYSERR_CHECK_EVENT_LOG),
                        MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                End If
            End If
        Else
            MsgBox(m_ResourceManager.GetString(gc_SYSERR_RE_TYPE), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End If
    End Sub


    'Private Sub GetVersion()
    '    Try
    '        'Get version from SYSVAL table on BDS
    '        Dim v_strSQL As String = String.Empty
    '        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
    '        Dim v_xmlDocument As New XmlDocumentEx
    '        Dim v_nodeList As Xml.XmlNodeList
    '        Dim v_strValue, v_strFLDNAME As String
    '        Dim v_Vesion As String = String.Empty
    '        Dim myBuildInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(Application.ExecutablePath)

    '        Dim a = myBuildInfo.FileVersion
    '        v_strSQL = "SELECT * FROM VERSION ORDER BY ACTUALVERSION DESC FETCH FIRST 1 ROW ONLY"
    '        Dim v_strObjMsg As String = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_AFMAST, gc_ActionInquiry, v_strSQL)
    '        v_ws.UnCheckKey(v_strObjMsg)

    '        v_xmlDocument.LoadXml(v_strObjMsg)
    '        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

    '        For i As Integer = 0 To v_nodeList.Count - 1
    '            For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
    '                With v_nodeList.Item(i).ChildNodes(j)
    '                    v_strValue = .InnerText.ToString
    '                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)

    '                    Select Case Trim(v_strFLDNAME)
    '                        Case "SYSTEMVERSION"
    '                            v_Vesion = v_strValue.Trim()
    '                    End Select
    '                End With
    '            Next
    '        Next

    '    Catch ex As Exception
    '    End Try
    'End Sub

    Private Sub sbLoginMicrosoft_Click(sender As Object, e As EventArgs) Handles sbLoginMicrosoft.Click
        Dim v_strObjMsg, v_strErrorSource, v_strErrorMessage As String
        Dim v_lngErr As Long
        Dim v_ws As New BDSDeliveryManagement
        Dim v_jsonMsg As String

        ''1. Call HOSTService to get info authorization Microsoft
        v_strObjMsg = BuildXMLObjMsg()
        v_lngErr = v_ws.GetInfoAuthorMicrosoft(v_strObjMsg)

        If v_lngErr <> ERR_SYSTEM_OK Then
            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErr, v_strErrorMessage, m_BusLayer.AppLanguage)
            Cursor.Current = Cursors.Default
            MsgBox(v_strErrorMessage, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, Me.Text)
            Me.Close()
        End If

        Dim jsonRes = JToken.Parse(v_strObjMsg)

        ''2. Call API Microsoft to get access_token and user_id
        Dim frmLoginMicrosoft As New frmLoginMicrosoft(jsonRes("urlAuthorizeCode").ToString(),
                                                       jsonRes("urlAccessToken").ToString(),
                                                       jsonRes("redirectUri").ToString(),
                                                       jsonRes("clientId").ToString(),
                                                       jsonRes("clientSecret").ToString(),
                                                       jsonRes("scope").ToString())
        Dim frmLoginMicrosoftResult As DialogResult = frmLoginMicrosoft.ShowDialog(Me)

        If (frmLoginMicrosoftResult = DialogResult.OK) Then
            'Get access_token and user_id successful
            Dim authenMicrosoft = frmLoginMicrosoft.AuthenMicrosoft

            ''3. Insert new account or Update accessToken account Microsoft
            v_jsonMsg = JsonConvert.SerializeObject(authenMicrosoft)
            v_lngErr = v_ws.InsertOrUpdateAccMicrosoft(v_jsonMsg)

            If v_lngErr <> ERR_SYSTEM_OK Then
                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErr, v_strErrorMessage, m_BusLayer.AppLanguage)
                Cursor.Current = Cursors.Default
                MsgBox(v_strErrorMessage, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, Me.Text)

                Me.Close()
            End If

            ''4. Get info acc Microsoft + Show frmTLPROFILES (edit) if TLNAME account Microsoft is null"
            'Get info acc Microsoft
            Dim blResult As BusLayerResult = m_BusLayer.LoginMicrosoft(v_jsonMsg)

            'If TLNAME is null => Show form fill info account
            If blResult = BusLayerResult.Success Then
                If String.IsNullOrEmpty(m_BusLayer.CurrentTellerProfile.TellerName) = True Then
                    Dim v_strFullObjName As String

                    Dim v_frm As Object
                    Dim moduleCode = "SA"
                    Dim tableName = "TLPROFILES"

                    v_frm = frmSearchMaster.GetFormByName("frmTLPROFILES")
                    v_strFullObjName = moduleCode & "." & tableName

                    v_frm.ExeFlag = ExecuteFlag.Edit
                    v_frm.UserLanguage = m_BusLayer.AppLanguage
                    v_frm.ModuleCode = moduleCode
                    v_frm.ObjectName = v_strFullObjName
                    v_frm.TableName = tableName
                    v_frm.LocalObject = "N"
                    v_frm.Text = "Thông tin tài khoản"
                    v_frm.TellerId = m_BusLayer.CurrentTellerProfile.TellerId
                    v_frm.TellerRight = "YYYY"
                    v_frm.AuthString = "YYYYY"
                    'v_frm.GroupCareBy = GroupCareBy
                    v_frm.BranchId = m_BusLayer.CurrentTellerProfile.BranchId
                    v_frm.Busdate = m_BusLayer.CurrentTellerProfile.BusDate
                    v_frm.KeyFieldName = "TLID"
                    v_frm.KeyFieldType = "C"
                    'v_frm.TellerNameField = m_BusLayer.CurrentTellerProfile.TellerName
                    v_frm.KeyFieldValue = m_BusLayer.CurrentTellerProfile.TellerId

                    Dim frmResult As DialogResult = v_frm.ShowDialog()
                End If

                'm_BusLayer.CurrentTellerProfile.AccessArea = Me.cboBusinessArea.Text
                Me.DialogResult = DialogResult.OK
                Me.Close()

            ElseIf blResult = BusLayerResult.AuthenticationFailure Then
                MsgBox(m_ResourceManager.GetString(gc_SYSERR_INCORRECT_USR_OR_PWD) & " " & m_ResourceManager.GetString(gc_SYSERR_RE_TYPE),
                   MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            End If
        End If
    End Sub
End Class
