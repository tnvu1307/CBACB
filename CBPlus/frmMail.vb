Imports CommonLibrary
Imports Microsoft.Win32
Imports System.IO
Imports AppCore

Public Class frmMail
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal pv_strLanguage As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        mv_strLanguage = pv_strLanguage
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
    Protected WithEvents Panel1 As System.Windows.Forms.Panel
    Protected WithEvents lblCaption As System.Windows.Forms.Label
    Friend WithEvents grpParameters As System.Windows.Forms.GroupBox
    Friend WithEvents txtSMTPSERVER As System.Windows.Forms.TextBox
    Friend WithEvents lblSMTPSERVER As System.Windows.Forms.Label
    Friend WithEvents txtUSERNAME As System.Windows.Forms.TextBox
    Friend WithEvents lblUSERNAME As System.Windows.Forms.Label
    Friend WithEvents txtPASSWORD As System.Windows.Forms.TextBox
    Friend WithEvents lblPASSWORD As System.Windows.Forms.Label
    Friend WithEvents txtTITLE As System.Windows.Forms.TextBox
    Friend WithEvents lblTITLE As System.Windows.Forms.Label
    Friend WithEvents txtBODY As System.Windows.Forms.TextBox
    Friend WithEvents lblBODYFILE As System.Windows.Forms.Label
    Friend WithEvents btnATTACHMENTS As System.Windows.Forms.Button
    Friend WithEvents txtAttachments As System.Windows.Forms.TextBox
    Friend WithEvents lblATTACHMENTS As System.Windows.Forms.Label
    Friend WithEvents btnBroadcast As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnSubcribed As System.Windows.Forms.Button
    Friend WithEvents lblFROM As System.Windows.Forms.Label
    Friend WithEvents txtFROM As System.Windows.Forms.TextBox
    Friend WithEvents rdbSubscribe As System.Windows.Forms.RadioButton
    Friend WithEvents rdbBroadcast As System.Windows.Forms.RadioButton
    Friend WithEvents grpAttchments As System.Windows.Forms.GroupBox
    Friend WithEvents txtPathbody As System.Windows.Forms.TextBox
    Friend WithEvents btnBody As System.Windows.Forms.Button
    Friend WithEvents lblPathSignature As System.Windows.Forms.Label
    Friend WithEvents txtSignature As System.Windows.Forms.TextBox
    Friend WithEvents HTMLE As Microsoft.ConsultingServices.HtmlEditor.HtmlEditorControl
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblCaption = New System.Windows.Forms.Label
        Me.grpParameters = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtSignature = New System.Windows.Forms.TextBox
        Me.lblPathSignature = New System.Windows.Forms.Label
        Me.txtPathbody = New System.Windows.Forms.TextBox
        Me.btnBody = New System.Windows.Forms.Button
        Me.rdbBroadcast = New System.Windows.Forms.RadioButton
        Me.rdbSubscribe = New System.Windows.Forms.RadioButton
        Me.grpAttchments = New System.Windows.Forms.GroupBox
        Me.txtAttachments = New System.Windows.Forms.TextBox
        Me.btnSubcribed = New System.Windows.Forms.Button
        Me.btnATTACHMENTS = New System.Windows.Forms.Button
        Me.btnBroadcast = New System.Windows.Forms.Button
        Me.txtFROM = New System.Windows.Forms.TextBox
        Me.lblFROM = New System.Windows.Forms.Label
        Me.lblATTACHMENTS = New System.Windows.Forms.Label
        Me.txtBODY = New System.Windows.Forms.TextBox
        Me.lblBODYFILE = New System.Windows.Forms.Label
        Me.txtTITLE = New System.Windows.Forms.TextBox
        Me.lblTITLE = New System.Windows.Forms.Label
        Me.txtPASSWORD = New System.Windows.Forms.TextBox
        Me.lblPASSWORD = New System.Windows.Forms.Label
        Me.txtUSERNAME = New System.Windows.Forms.TextBox
        Me.lblUSERNAME = New System.Windows.Forms.Label
        Me.txtSMTPSERVER = New System.Windows.Forms.TextBox
        Me.lblSMTPSERVER = New System.Windows.Forms.Label
        Me.btnClose = New System.Windows.Forms.Button
        Me.HTMLE = New Microsoft.ConsultingServices.HtmlEditor.HtmlEditorControl
        Me.btnSave = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.grpParameters.SuspendLayout()
        Me.grpAttchments.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.Controls.Add(Me.lblCaption)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1236, 50)
        Me.Panel1.TabIndex = 3
        '
        'lblCaption
        '
        Me.lblCaption.AutoSize = True
        Me.lblCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaption.Location = New System.Drawing.Point(7, 16)
        Me.lblCaption.Name = "lblCaption"
        Me.lblCaption.Size = New System.Drawing.Size(63, 13)
        Me.lblCaption.TabIndex = 0
        Me.lblCaption.Tag = "lblCaption"
        Me.lblCaption.Text = "lblCaption"
        '
        'grpParameters
        '
        Me.grpParameters.Controls.Add(Me.Label1)
        Me.grpParameters.Controls.Add(Me.txtSignature)
        Me.grpParameters.Controls.Add(Me.lblPathSignature)
        Me.grpParameters.Controls.Add(Me.txtPathbody)
        Me.grpParameters.Controls.Add(Me.btnBody)
        Me.grpParameters.Controls.Add(Me.rdbBroadcast)
        Me.grpParameters.Controls.Add(Me.rdbSubscribe)
        Me.grpParameters.Controls.Add(Me.grpAttchments)
        Me.grpParameters.Controls.Add(Me.txtFROM)
        Me.grpParameters.Controls.Add(Me.lblFROM)
        Me.grpParameters.Controls.Add(Me.lblATTACHMENTS)
        Me.grpParameters.Controls.Add(Me.txtBODY)
        Me.grpParameters.Controls.Add(Me.lblBODYFILE)
        Me.grpParameters.Controls.Add(Me.txtTITLE)
        Me.grpParameters.Controls.Add(Me.lblTITLE)
        Me.grpParameters.Controls.Add(Me.txtPASSWORD)
        Me.grpParameters.Controls.Add(Me.lblPASSWORD)
        Me.grpParameters.Controls.Add(Me.txtUSERNAME)
        Me.grpParameters.Controls.Add(Me.lblUSERNAME)
        Me.grpParameters.Controls.Add(Me.txtSMTPSERVER)
        Me.grpParameters.Controls.Add(Me.lblSMTPSERVER)
        Me.grpParameters.Location = New System.Drawing.Point(8, 56)
        Me.grpParameters.Name = "grpParameters"
        Me.grpParameters.Size = New System.Drawing.Size(575, 430)
        Me.grpParameters.TabIndex = 4
        Me.grpParameters.TabStop = False
        Me.grpParameters.Text = "grpParameters"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 232)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 21)
        Me.Label1.TabIndex = 29
        Me.Label1.Tag = "BODYFILE"
        Me.Label1.Text = "Signature"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSignature
        '
        Me.txtSignature.Location = New System.Drawing.Point(120, 232)
        Me.txtSignature.Multiline = True
        Me.txtSignature.Name = "txtSignature"
        Me.txtSignature.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSignature.Size = New System.Drawing.Size(432, 96)
        Me.txtSignature.TabIndex = 28
        '
        'lblPathSignature
        '
        Me.lblPathSignature.Location = New System.Drawing.Point(8, 264)
        Me.lblPathSignature.Name = "lblPathSignature"
        Me.lblPathSignature.Size = New System.Drawing.Size(100, 23)
        Me.lblPathSignature.TabIndex = 27
        Me.lblPathSignature.Tag = "PathSignature"
        Me.lblPathSignature.Text = "lblPathSignature"
        '
        'txtPathbody
        '
        Me.txtPathbody.Location = New System.Drawing.Point(128, 384)
        Me.txtPathbody.Name = "txtPathbody"
        Me.txtPathbody.Size = New System.Drawing.Size(296, 20)
        Me.txtPathbody.TabIndex = 25
        Me.txtPathbody.Visible = False
        '
        'btnBody
        '
        Me.btnBody.Location = New System.Drawing.Point(432, 384)
        Me.btnBody.Name = "btnBody"
        Me.btnBody.Size = New System.Drawing.Size(24, 20)
        Me.btnBody.TabIndex = 26
        Me.btnBody.Text = "..."
        Me.btnBody.Visible = False
        '
        'rdbBroadcast
        '
        Me.rdbBroadcast.Location = New System.Drawing.Point(208, 352)
        Me.rdbBroadcast.Name = "rdbBroadcast"
        Me.rdbBroadcast.Size = New System.Drawing.Size(104, 24)
        Me.rdbBroadcast.TabIndex = 24
        Me.rdbBroadcast.Text = "Broadcast"
        '
        'rdbSubscribe
        '
        Me.rdbSubscribe.Location = New System.Drawing.Point(120, 352)
        Me.rdbSubscribe.Name = "rdbSubscribe"
        Me.rdbSubscribe.Size = New System.Drawing.Size(80, 24)
        Me.rdbSubscribe.TabIndex = 23
        Me.rdbSubscribe.Text = "Subscribe"
        '
        'grpAttchments
        '
        Me.grpAttchments.Controls.Add(Me.txtAttachments)
        Me.grpAttchments.Controls.Add(Me.btnSubcribed)
        Me.grpAttchments.Controls.Add(Me.btnATTACHMENTS)
        Me.grpAttchments.Controls.Add(Me.btnBroadcast)
        Me.grpAttchments.Location = New System.Drawing.Point(120, 336)
        Me.grpAttchments.Name = "grpAttchments"
        Me.grpAttchments.Size = New System.Drawing.Size(432, 48)
        Me.grpAttchments.TabIndex = 22
        Me.grpAttchments.TabStop = False
        Me.grpAttchments.Text = "grpSubcribe"
        '
        'txtAttachments
        '
        Me.txtAttachments.Location = New System.Drawing.Point(8, 16)
        Me.txtAttachments.Name = "txtAttachments"
        Me.txtAttachments.Size = New System.Drawing.Size(296, 20)
        Me.txtAttachments.TabIndex = 7
        '
        'btnSubcribed
        '
        Me.btnSubcribed.Location = New System.Drawing.Point(344, 16)
        Me.btnSubcribed.Name = "btnSubcribed"
        Me.btnSubcribed.Size = New System.Drawing.Size(80, 23)
        Me.btnSubcribed.TabIndex = 9
        Me.btnSubcribed.Tag = "Subcribed"
        Me.btnSubcribed.Text = "btnSubcribed"
        '
        'btnATTACHMENTS
        '
        Me.btnATTACHMENTS.Location = New System.Drawing.Point(312, 16)
        Me.btnATTACHMENTS.Name = "btnATTACHMENTS"
        Me.btnATTACHMENTS.Size = New System.Drawing.Size(24, 20)
        Me.btnATTACHMENTS.TabIndex = 8
        Me.btnATTACHMENTS.Text = "..."
        '
        'btnBroadcast
        '
        Me.btnBroadcast.Location = New System.Drawing.Point(344, 16)
        Me.btnBroadcast.Name = "btnBroadcast"
        Me.btnBroadcast.Size = New System.Drawing.Size(80, 23)
        Me.btnBroadcast.TabIndex = 10
        Me.btnBroadcast.Tag = "Broadcast"
        Me.btnBroadcast.Text = "btnBroadcast"
        '
        'txtFROM
        '
        Me.txtFROM.Location = New System.Drawing.Point(384, 24)
        Me.txtFROM.Name = "txtFROM"
        Me.txtFROM.Size = New System.Drawing.Size(168, 20)
        Me.txtFROM.TabIndex = 1
        Me.txtFROM.Tag = "FROM"
        '
        'lblFROM
        '
        Me.lblFROM.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFROM.Location = New System.Drawing.Point(272, 24)
        Me.lblFROM.Name = "lblFROM"
        Me.lblFROM.Size = New System.Drawing.Size(112, 21)
        Me.lblFROM.TabIndex = 21
        Me.lblFROM.Tag = "FROM"
        Me.lblFROM.Text = "lblFROM"
        Me.lblFROM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblATTACHMENTS
        '
        Me.lblATTACHMENTS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblATTACHMENTS.Location = New System.Drawing.Point(8, 352)
        Me.lblATTACHMENTS.Name = "lblATTACHMENTS"
        Me.lblATTACHMENTS.Size = New System.Drawing.Size(104, 21)
        Me.lblATTACHMENTS.TabIndex = 18
        Me.lblATTACHMENTS.Tag = "ATTACHMENTS"
        Me.lblATTACHMENTS.Text = "lblATTACHMENTS"
        Me.lblATTACHMENTS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBODY
        '
        Me.txtBODY.Location = New System.Drawing.Point(120, 120)
        Me.txtBODY.Multiline = True
        Me.txtBODY.Name = "txtBODY"
        Me.txtBODY.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtBODY.Size = New System.Drawing.Size(432, 88)
        Me.txtBODY.TabIndex = 5
        '
        'lblBODYFILE
        '
        Me.lblBODYFILE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBODYFILE.Location = New System.Drawing.Point(8, 120)
        Me.lblBODYFILE.Name = "lblBODYFILE"
        Me.lblBODYFILE.Size = New System.Drawing.Size(112, 21)
        Me.lblBODYFILE.TabIndex = 15
        Me.lblBODYFILE.Tag = "BODYFILE"
        Me.lblBODYFILE.Text = "lblBODYFILE"
        Me.lblBODYFILE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTITLE
        '
        Me.txtTITLE.Location = New System.Drawing.Point(120, 88)
        Me.txtTITLE.Name = "txtTITLE"
        Me.txtTITLE.Size = New System.Drawing.Size(432, 20)
        Me.txtTITLE.TabIndex = 4
        Me.txtTITLE.Text = "Test send mail"
        '
        'lblTITLE
        '
        Me.lblTITLE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTITLE.Location = New System.Drawing.Point(8, 88)
        Me.lblTITLE.Name = "lblTITLE"
        Me.lblTITLE.Size = New System.Drawing.Size(112, 21)
        Me.lblTITLE.TabIndex = 13
        Me.lblTITLE.Tag = "TITLE"
        Me.lblTITLE.Text = "lblTITLE"
        Me.lblTITLE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPASSWORD
        '
        Me.txtPASSWORD.Location = New System.Drawing.Point(384, 56)
        Me.txtPASSWORD.Name = "txtPASSWORD"
        Me.txtPASSWORD.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPASSWORD.Size = New System.Drawing.Size(168, 20)
        Me.txtPASSWORD.TabIndex = 3
        '
        'lblPASSWORD
        '
        Me.lblPASSWORD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPASSWORD.Location = New System.Drawing.Point(272, 56)
        Me.lblPASSWORD.Name = "lblPASSWORD"
        Me.lblPASSWORD.Size = New System.Drawing.Size(112, 21)
        Me.lblPASSWORD.TabIndex = 11
        Me.lblPASSWORD.Tag = "PASSWORD"
        Me.lblPASSWORD.Text = "lblPASSWORD"
        Me.lblPASSWORD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtUSERNAME
        '
        Me.txtUSERNAME.Location = New System.Drawing.Point(120, 56)
        Me.txtUSERNAME.Name = "txtUSERNAME"
        Me.txtUSERNAME.Size = New System.Drawing.Size(144, 20)
        Me.txtUSERNAME.TabIndex = 2
        '
        'lblUSERNAME
        '
        Me.lblUSERNAME.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUSERNAME.Location = New System.Drawing.Point(8, 56)
        Me.lblUSERNAME.Name = "lblUSERNAME"
        Me.lblUSERNAME.Size = New System.Drawing.Size(112, 21)
        Me.lblUSERNAME.TabIndex = 9
        Me.lblUSERNAME.Tag = "USERNAME"
        Me.lblUSERNAME.Text = "lblUSERNAME"
        Me.lblUSERNAME.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSMTPSERVER
        '
        Me.txtSMTPSERVER.Location = New System.Drawing.Point(120, 24)
        Me.txtSMTPSERVER.Name = "txtSMTPSERVER"
        Me.txtSMTPSERVER.Size = New System.Drawing.Size(144, 20)
        Me.txtSMTPSERVER.TabIndex = 0
        Me.txtSMTPSERVER.Text = "ipa-ex1"
        '
        'lblSMTPSERVER
        '
        Me.lblSMTPSERVER.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSMTPSERVER.Location = New System.Drawing.Point(8, 24)
        Me.lblSMTPSERVER.Name = "lblSMTPSERVER"
        Me.lblSMTPSERVER.Size = New System.Drawing.Size(112, 21)
        Me.lblSMTPSERVER.TabIndex = 7
        Me.lblSMTPSERVER.Tag = "SMTPSERVER"
        Me.lblSMTPSERVER.Text = "lblSMTPSERVER"
        Me.lblSMTPSERVER.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(472, 463)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(80, 23)
        Me.btnClose.TabIndex = 11
        Me.btnClose.Tag = "Close"
        Me.btnClose.Text = "btnClose"
        '
        'HTMLE
        '
        Me.HTMLE.InnerText = Nothing
        Me.HTMLE.Location = New System.Drawing.Point(589, 71)
        Me.HTMLE.Name = "HTMLE"
        Me.HTMLE.Size = New System.Drawing.Size(597, 300)
        Me.HTMLE.TabIndex = 30
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(766, 392)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 31
        Me.btnSave.Text = "btnSave"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'frmMail
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1236, 512)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.HTMLE)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.grpParameters)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Name = "frmMail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmMail"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.grpParameters.ResumeLayout(False)
        Me.grpParameters.PerformLayout()
        Me.grpAttchments.ResumeLayout(False)
        Me.grpAttchments.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Declare constants and variables "
    Private mv_ResourceManager As Resources.ResourceManager
    Private mv_strLanguage As String
    Private mv_strModuleCode As String
    Private mv_strObjectName As String
    Private mv_strBranchId As String
    Private mv_strBranchName As String
    Private mv_strTellerId As String
    Private mv_strTellerName As String
    Protected mv_dsInput As DataSet
#End Region

#Region " Properties "

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

    Public Property BranchName() As String
        Get
            Return mv_strBranchName
        End Get
        Set(ByVal Value As String)
            mv_strBranchName = Value
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

    Public Property TellerName() As String
        Get
            Return mv_strTellerName
        End Get
        Set(ByVal Value As String)
            mv_strTellerName = Value
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

    Public Property ResourceManager() As Resources.ResourceManager
        Get
            Return mv_ResourceManager
        End Get
        Set(ByVal Value As Resources.ResourceManager)
            mv_ResourceManager = Value
        End Set
    End Property
#End Region

#Region " Overridable methods "
    Public Overridable Sub OnInit()
        Try
            'Kh?i t?o kích thu?c form và load resource
            mv_ResourceManager = New Resources.ResourceManager("_DIRECT.frmMail-" & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
            LoadUserInterface(Me)
            DisplayOption()
            loadInfoMail()
        Catch ex As Exception

        End Try
    End Sub
    Public Sub DisplayOption()
        'rdbSubscribe.Checked = True
        'rdbBroadcast.Checked = False
        'btnSubcribed.Visible = True
        'btnBroadcast.Visible = False
        rdbSubscribe.Checked = True
        rdbSubscribe.Visible = False
        rdbBroadcast.Visible = False
        btnBroadcast.Visible = False
        btnSubcribed.Visible = True
    End Sub

    Public Overridable Sub LoadUserInterface(ByRef pv_ctrl As Windows.Forms.Control)
        Dim v_ctrl As Windows.Forms.Control

        Try

            For Each v_ctrl In pv_ctrl.Controls
                If TypeOf (v_ctrl) Is Panel Then
                    LoadUserInterface(v_ctrl)
                ElseIf TypeOf (v_ctrl) Is GroupBox Then
                    CType(v_ctrl, GroupBox).Text = mv_ResourceManager.GetString("frmMail." & v_ctrl.Name)
                    LoadUserInterface(v_ctrl)
                ElseIf TypeOf (v_ctrl) Is Label Then
                    CType(v_ctrl, Label).Text = mv_ResourceManager.GetString("frmMail." & v_ctrl.Name)
                ElseIf TypeOf (v_ctrl) Is Button Then
                    CType(v_ctrl, Button).Text = mv_ResourceManager.GetString("frmMail." & v_ctrl.Name)
                ElseIf TypeOf (v_ctrl) Is CheckBox Then
                    CType(v_ctrl, CheckBox).Text = mv_ResourceManager.GetString("frmMail." & v_ctrl.Name)
                End If
            Next

            'Load caption of form, label caption
            Me.Text = mv_ResourceManager.GetString("frmMail")
            lblCaption.Text = mv_ResourceManager.GetString("frmMail.lblCaption") & TellerName

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Overridable Sub OnClose()
        Me.Close()
    End Sub

    'Public Overridable Sub OnBroadcast()
    '    Try
    '        'Read the body file
    '        Dim filestream As StreamReader
    '        filestream = File.OpenText(Me.txtBODY.Text)
    '        Dim readcontents As String
    '        readcontents = filestream.ReadToEnd()
    '        filestream.Close()

    '        'Get list of attachment in specific folder
    '        Dim vAttachments As New ArrayList
    '        If Me.txtAttachments.Text.Length > 0 Then
    '            Dim v_strFULLPATH As String = Path.GetDirectoryName(Me.txtAttachments.Text)
    '            If v_strFULLPATH.Length > 0 Then
    '                Dim vAttachFile As String = Dir(v_strFULLPATH & "\*.*", FileAttribute.Normal)   ' Retrieve the first entry.
    '                Do While Not vAttachFile Is Nothing   ' Start the loop.
    '                    vAttachments.Add(v_strFULLPATH & "\" & vAttachFile)
    '                    vAttachFile = Dir()   ' Get next entry.
    '                Loop
    '            End If
    '        End If

    '        'Get list of customer
    '        Dim v_strSQL As String = "SELECT CF.FULLNAME, CF.SHORTNAME, AF.ACCTNO, AF.EMAIL FROM AFMAST AF, CFMAST CF WHERE CF.CUSTID=AF.CUSTID"
    '        Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_RPTMASTER, _
    '                                gc_ActionInquiry, v_strSQL)
    '        Dim v_wsObj As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
    '        v_wsObj.Message(v_strObjMsg)
    '        Dim v_xmlDocument As New XmlDocumentEx
    '        Dim v_xmlNodeList As Xml.XmlNodeList
    '        Dim v_strFLDNAME, v_strVALUE, v_strBODY, v_strAFACCTNO, v_strEMAIL, v_strFULLNAME, v_strSHORTNAME As String
    '        Dim objMail As New Delivery, v_strTO As String

    '        'Send the broadcast message
    '        v_xmlDocument.LoadXml(v_strObjMsg)
    '        v_xmlNodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
    '        For j As Integer = 0 To v_xmlNodeList.Count - 1
    '            v_strAFACCTNO = String.Empty
    '            v_strEMAIL = String.Empty
    '            v_strFULLNAME = String.Empty
    '            v_strSHORTNAME = String.Empty
    '            v_strBODY = readcontents
    '            For k As Integer = 0 To v_xmlNodeList.Item(j).ChildNodes.Count - 1
    '                With v_xmlNodeList.Item(j).ChildNodes(k)
    '                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
    '                    v_strVALUE = .InnerText.ToString
    '                    v_strBODY = v_strBODY.Replace("[" & v_strFLDNAME & "]", v_strVALUE)
    '                    Select Case v_strFLDNAME.Trim()
    '                        Case "ACCTNO"
    '                            v_strAFACCTNO = v_strVALUE.Trim()
    '                        Case "EMAIL"
    '                            v_strEMAIL = v_strVALUE.Trim()
    '                        Case "FULLNAME"
    '                            v_strFULLNAME = v_strVALUE.Trim()
    '                        Case "SHORTNAME"
    '                            v_strSHORTNAME = v_strVALUE.Trim()
    '                    End Select
    '                End With
    '            Next
    '            'Send the mail
    '            If Not vAttachments Is Nothing Then
    '                objMail.SendMail(txtFROM.Text, v_strEMAIL, Me.txtTITLE.Text, Me.txtUSERNAME.Text, Me.txtPASSWORD.Text, v_strBODY, Me.txtSMTPSERVER.Text, vAttachments)
    '            Else
    '                objMail.SendMail(txtFROM.Text, v_strEMAIL, Me.txtTITLE.Text, Me.txtUSERNAME.Text, Me.txtPASSWORD.Text, v_strBODY, Me.txtSMTPSERVER.Text)
    '            End If
    '        Next
    '        objMail = Nothing

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub
    Public Overridable Sub OnBroadcast()
        Try
            'Read the body file
            Dim readcontents As String
            Dim v_arrContents() As String
            Dim v_blnSent As Boolean = False


            Dim c As Char = Chr(10).ToString()
            v_arrContents = txtBODY.Text.Trim().Split(c)
            Dim v_arrContents1(v_arrContents.Length - 1) As String
            For j As Integer = 0 To v_arrContents.Length - 2
                v_arrContents(j) = v_arrContents(j).Substring(0, v_arrContents(j).Length - 1)
            Next
            For i As Integer = 0 To v_arrContents1.Length - 1
                readcontents += v_arrContents(i) + "<BR>"
            Next

            'Get list of attachment in specific folder
            Dim vAttachments As New ArrayList
            If Me.txtAttachments.Text.Length > 0 Then
                Dim v_strFULLPATH As String = Path.GetDirectoryName(Me.txtAttachments.Text)
                If v_strFULLPATH.Length > 0 Then
                    Dim vAttachFile As String = Dir(v_strFULLPATH & "\*.*", FileAttribute.Normal)   ' Retrieve the first entry.
                    Do While Not vAttachFile Is Nothing   ' Start the loop.
                        vAttachments.Add(v_strFULLPATH & "\" & vAttachFile)
                        vAttachFile = Dir()   ' Get next entry.
                    Loop
                End If
            Else
                MsgBox("Please choose file to attach!", MsgBoxStyle.OkOnly)
                Exit Sub
            End If

            'Get list of customer
            Dim v_strSQL As String = "SELECT CF.FULLNAME, CF.SHORTNAME, AF.ACCTNO, AF.EMAIL FROM AFMAST AF, CFMAST CF WHERE CF.CUSTID=AF.CUSTID"
            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_RPTMASTER, _
                                    gc_ActionInquiry, v_strSQL)
            Dim v_wsObj As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            v_wsObj.Message(v_strObjMsg)
            Dim v_xmlDocument As New XmlDocumentEx
            Dim v_xmlNodeList As Xml.XmlNodeList
            Dim v_strFLDNAME, v_strVALUE, v_strBODY, v_strSignature, v_strAFACCTNO, v_strEMAIL, v_strFULLNAME, v_strSHORTNAME As String
            Dim objMail As New Delivery, v_strTO As String

            'Send the broadcast message
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_xmlNodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For j As Integer = 0 To v_xmlNodeList.Count - 1
                v_strAFACCTNO = String.Empty
                v_strEMAIL = String.Empty
                v_strFULLNAME = String.Empty
                v_strSHORTNAME = String.Empty
                v_strBODY = readcontents
                For k As Integer = 0 To v_xmlNodeList.Item(j).ChildNodes.Count - 1
                    With v_xmlNodeList.Item(j).ChildNodes(k)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strVALUE = .InnerText.ToString
                        v_strBODY = v_strBODY.Replace("[" & v_strFLDNAME & "]", v_strVALUE)
                        Select Case v_strFLDNAME.Trim()
                            Case "ACCTNO"
                                v_strAFACCTNO = v_strVALUE.Trim()
                            Case "EMAIL"
                                v_strEMAIL = v_strVALUE.Trim()
                            Case "FULLNAME"
                                v_strFULLNAME = v_strVALUE.Trim()
                            Case "SHORTNAME"
                                v_strSHORTNAME = v_strVALUE.Trim()
                        End Select
                    End With
                Next
                v_strSignature = Me.txtSignature.Text
                'Send the mail
                If Not vAttachments Is Nothing Then
                    v_blnSent = Delivery.SendMail(v_strSignature, txtFROM.Text, v_strEMAIL, Me.txtTITLE.Text, Me.txtUSERNAME.Text, Me.txtPASSWORD.Text, v_strBODY, Me.txtSMTPSERVER.Text, vAttachments)
                Else
                    v_blnSent = Delivery.SendMail(v_strSignature, txtFROM.Text, v_strEMAIL, Me.txtTITLE.Text, Me.txtUSERNAME.Text, Me.txtPASSWORD.Text, v_strBODY, Me.txtSMTPSERVER.Text)
                End If
            Next
            objMail = Nothing
            If v_blnSent Then
                MsgBox("Send mails successfully!", MsgBoxStyle.OkOnly)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Public Overridable Sub OnSubcribed()
    '    Try
    '        'Read the body file
    '        Dim filestream As StreamReader
    '        filestream = File.OpenText(Me.txtBODY.Text)
    '        Dim readcontents As String
    '        readcontents = filestream.ReadToEnd()
    '        filestream.Close()

    '        'Get list of attachment in specific folder
    '        Dim vAttachments As New ArrayList
    '        Dim vAttachFile As String
    '        If Me.txtAttachments.Text.Length > 0 Then
    '            Dim v_strFULLPATH As String = Path.GetDirectoryName(Me.txtAttachments.Text)
    '            If v_strFULLPATH.Length > 0 Then
    '                'Get list of customer
    '                Dim v_strSQL As String = "SELECT CF.FULLNAME, CF.SHORTNAME, AF.ACCTNO, AF.EMAIL FROM AFMAST AF, CFMAST CF WHERE CF.CUSTID=AF.CUSTID AND AF.RECEIVEVIA='E'"
    '                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_RPTMASTER, _
    '                                        gc_ActionInquiry, v_strSQL)
    '                Dim v_wsObj As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
    '                v_wsObj.Message(v_strObjMsg)
    '                Dim v_xmlDocument As New XmlDocumentEx
    '                Dim v_xmlNodeList As Xml.XmlNodeList
    '                Dim v_strFLDNAME, v_strVALUE, v_strBODY, v_strAFACCTNO, v_strEMAIL, v_strFULLNAME, v_strSHORTNAME As String
    '                Dim objMail As New Delivery, v_strTO As String

    '                'Send the broadcast message
    '                v_xmlDocument.LoadXml(v_strObjMsg)
    '                v_xmlNodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
    '                For j As Integer = 0 To v_xmlNodeList.Count - 1
    '                    v_strAFACCTNO = String.Empty
    '                    v_strEMAIL = String.Empty
    '                    v_strFULLNAME = String.Empty
    '                    v_strSHORTNAME = String.Empty
    '                    v_strBODY = readcontents
    '                    vAttachments.Clear()
    '                    For k As Integer = 0 To v_xmlNodeList.Item(j).ChildNodes.Count - 1
    '                        With v_xmlNodeList.Item(j).ChildNodes(k)
    '                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
    '                            v_strVALUE = .InnerText.ToString
    '                            v_strBODY = v_strBODY.Replace("[" & v_strFLDNAME & "]", v_strVALUE)
    '                            Select Case v_strFLDNAME.Trim()
    '                                Case "ACCTNO"
    '                                    v_strAFACCTNO = v_strVALUE.Trim()
    '                                Case "EMAIL"
    '                                    v_strEMAIL = v_strVALUE.Trim()
    '                                Case "FULLNAME"
    '                                    v_strFULLNAME = v_strVALUE.Trim()
    '                                Case "SHORTNAME"
    '                                    v_strSHORTNAME = v_strVALUE.Trim()
    '                            End Select
    '                        End With
    '                    Next

    '                    'Get all report for contract
    '                    vAttachFile = Dir(v_strFULLPATH & "\" & v_strAFACCTNO & "*.PDF", FileAttribute.Normal)  ' Retrieve the first entry.

    '                    Do While Not vAttachFile Is Nothing   ' Start the loop.
    '                        vAttachments.Add(v_strFULLPATH & "\" & vAttachFile)
    '                        vAttachFile = Dir()   ' Get next entry.
    '                    Loop

    '                    'Send the mail
    '                    If Not vAttachments Is Nothing Then
    '                        objMail.SendMail(txtFROM.Text, v_strEMAIL, Me.txtTITLE.Text, Me.txtUSERNAME.Text, Me.txtPASSWORD.Text, v_strBODY, Me.txtSMTPSERVER.Text, vAttachments)
    '                    Else
    '                        objMail.SendMail(txtFROM.Text, v_strEMAIL, Me.txtTITLE.Text, Me.txtUSERNAME.Text, Me.txtPASSWORD.Text, v_strBODY, Me.txtSMTPSERVER.Text)
    '                    End If
    '                Next
    '                objMail = Nothing
    '            End If
    '        End If


    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    Public Overridable Sub OnSubcribed()
        Try
            'Dim filestream As StreamReader
            'filestream = File.OpenText(Me.txtBODY.Text)
            'Dim readcontents As String
            'readcontents = filestream.ReadToEnd()
            'filestream.Close()
            'filestream.e()
            'Show processing message
            If validateControls() Then
                Dim v_frm As New frmProcessing
                v_frm.UserLanguage = UserLanguage
                v_frm.ProcessType = ProcessType.SendEmailProcess
                v_frm.InitDialog()
                v_frm.Show()
                'End of show processing message
                Me.Enabled = False

                'Read the body file
                Dim readcontents As String = String.Empty
                Dim readSignature As String = String.Empty
                Dim v_arrContents(), v_arrSignature() As String


                Dim c As Char = Chr(10).ToString()
                v_arrContents = txtBODY.Text.Trim().Split(c)
                Dim v_arrContents1(v_arrContents.Length - 1) As String
                For j As Integer = 0 To v_arrContents.Length - 2
                    v_arrContents(j) = v_arrContents(j).Substring(0, v_arrContents(j).Length - 1)
                Next
                For i As Integer = 0 To v_arrContents1.Length - 1
                    readcontents += v_arrContents(i) + "<BR>"
                Next

                v_arrSignature = txtSignature.Text.Trim().Split(c)
                Dim v_arrSignature1(v_arrSignature.Length - 1) As String
                For jj As Integer = 0 To v_arrSignature.Length - 2
                    v_arrSignature(jj) = v_arrSignature(jj).Substring(0, v_arrSignature(jj).Length - 1)
                Next
                For ii As Integer = 0 To v_arrSignature1.Length - 1
                    readSignature += v_arrSignature(ii) + "<BR>"
                Next


                'Get list of attachment in specific folder
                Dim vAttachments As New ArrayList
                Dim vAttachFile As String
                If Me.txtAttachments.Text.Length > 0 Then
                    Dim v_strFULLPATH As String = Path.GetDirectoryName(Me.txtAttachments.Text)
                    If v_strFULLPATH.Length > 0 Then
                        'Get list of customer
                        'Dim v_strSQL As String = "SELECT CF.CUSTODYCD, CF.FULLNAME, CF.SHORTNAME, AF.ACCTNO, AF.EMAIL FROM AFMAST AF, CFMAST CF WHERE CF.CUSTID=AF.CUSTID AND AF.RECEIVEVIA='E' AND AF.EMAIL IS NOT NULL"
                        Dim v_strSQL As String = "SELECT TRUNC(COUNT(1)/100) + 1 PHANTRANG FROM (SELECT CF.FULLNAME, CF.SHORTNAME, AF.ACCTNO, AF.EMAIL FROM AFMAST AF, CFMAST CF, (SELECT DISTINCT AFACCTNO, STATUS FROM RPTAFMAST) RPTAF WHERE CF.CUSTID=AF.CUSTID AND AF.EMAIL IS NOT NULL AND AF.ACCTNO = RPTAF.AFACCTNO AND RPTAF.STATUS = 'A')"
                        Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_RPTMASTER, _
                                                gc_ActionInquiry, v_strSQL)
                        Dim v_wsObj As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery

                        v_wsObj.Message(v_strObjMsg)
                        Dim v_xmlDocument As New XmlDocumentEx
                        Dim v_xmlNodeList As Xml.XmlNodeList
                        Dim v_strFLDNAME, v_strVALUE, v_strBODY, v_strSignature, v_strAFACCTNO, v_strEMAIL, v_strFULLNAME, v_strSHORTNAME, v_strCUSTODYCD As String
                        Dim objMail As New Delivery, v_strTO As String
                        Dim v_intPages, v_intFront, v_intTail As Integer
                        Dim v_blnIsSend As Boolean = False

                        'Send the broadcast message
                        v_xmlDocument.LoadXml(v_strObjMsg)
                        v_xmlNodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

                        If v_xmlNodeList.Count > 0 AndAlso v_xmlNodeList.Item(0).ChildNodes.Count Then
                            v_intPages = CInt(v_xmlNodeList.Item(0).ChildNodes(0).InnerText.ToString().Trim())
                        End If

                        For a As Integer = 0 To v_intPages - 1
                            v_intFront = a * 100
                            v_intTail = (a + 1) * 100
                            v_strSQL = "SELECT CFAF.* FROM ( SELECT TEMP.*, ROWNUM ABC FROM (SELECT CF.CUSTODYCD, CF.FULLNAME, CF.SHORTNAME, AF.ACCTNO, AF.EMAIL " _
                                        & "FROM AFMAST AF, CFMAST CF, (SELECT DISTINCT AFACCTNO, STATUS FROM RPTAFMAST) RPTAF  WHERE CF.CUSTID=AF.CUSTID AND AF.EMAIL IS NOT NULL  AND AF.ACCTNO = RPTAF.AFACCTNO AND RPTAF.STATUS = 'A' ORDER BY CF.CUSTODYCD) TEMP) CFAF " _
                                        & "WHERE CFAF.ABC > " & v_intFront.ToString() & " AND CFAF.ABC <= " & v_intTail.ToString()
                            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_RPTMASTER, _
                                                gc_ActionInquiry, v_strSQL)
                            v_wsObj.Message(v_strObjMsg)
                            v_xmlDocument.LoadXml(v_strObjMsg)
                            v_xmlNodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                            For j As Integer = 0 To v_xmlNodeList.Count - 1
                                v_strCUSTODYCD = String.Empty
                                v_strAFACCTNO = String.Empty
                                v_strEMAIL = String.Empty
                                v_strFULLNAME = String.Empty
                                v_strSHORTNAME = String.Empty
                                v_strBODY = readcontents
                                v_strSignature = readSignature
                                vAttachments.Clear()

                                For k As Integer = 0 To v_xmlNodeList.Item(j).ChildNodes.Count - 1
                                    With v_xmlNodeList.Item(j).ChildNodes(k)
                                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                        v_strVALUE = .InnerText.ToString
                                        'v_strBODY = v_strBODY.Replace("[" & v_strFLDNAME & "]", v_strVALUE)
                                        Select Case v_strFLDNAME.Trim()
                                            Case "CUSTODYCD"
                                                v_strCUSTODYCD = v_strVALUE.Trim()
                                            Case "ACCTNO"
                                                v_strAFACCTNO = v_strVALUE.Trim()
                                            Case "EMAIL"
                                                v_strEMAIL = v_strVALUE.Trim()
                                            Case "FULLNAME"
                                                v_strFULLNAME = v_strVALUE.Trim()
                                            Case "SHORTNAME"
                                                v_strSHORTNAME = v_strVALUE.Trim()
                                        End Select
                                    End With
                                Next

                                'Get all report for contract
                                'vAttachFile = Dir(v_strFULLPATH & "\" & v_strAFACCTNO & "*.PDF", FileAttribute.Normal)  ' Retrieve the first entry.
                                vAttachFile = Dir(v_strFULLPATH & "\" & v_strCUSTODYCD & v_strAFACCTNO & "*.PDF", FileAttribute.Normal)  ' Retrieve the first entry.

                                Do While (Not vAttachFile Is Nothing AndAlso vAttachFile <> "")   ' Start the loop.
                                    vAttachments.Add(v_strFULLPATH & "\" & vAttachFile)
                                    vAttachFile = Dir()   ' Get next entry.
                                    v_blnIsSend = True 'Chi can co file la se gui
                                Loop
                                'Send the mail
                                If (Not vAttachments Is Nothing) AndAlso v_blnIsSend Then
                                    If (Delivery.SendMail(v_strSignature, txtFROM.Text, v_strEMAIL, Me.txtTITLE.Text, Me.txtUSERNAME.Text, Me.txtPASSWORD.Text, v_strBODY, Me.txtSMTPSERVER.Text, vAttachments)) Then
                                        For i As Integer = 0 To vAttachments.Count - 1
                                            MoveFile(vAttachments.Item(i).ToString(), v_strFULLPATH & "History\" & vAttachments.Item(i).ToString().Replace(v_strFULLPATH & "\", ""))
                                        Next
                                    End If
                                    'Neu khong co bao cao thi khong gui mail.
                                    'Else
                                    '    Delivery.SendMail(v_strSignature, txtFROM.Text, v_strEMAIL, Me.txtTITLE.Text, Me.txtUSERNAME.Text, Me.txtPASSWORD.Text, v_strBODY, Me.txtSMTPSERVER.Text)
                                End If
                                v_blnIsSend = False ' Gui xong tra lai trang thai False cho co.
                            Next
                        Next

                        objMail = Nothing
                    End If
                    MsgBox("Gửi Email thành công !", MsgBoxStyle.OkOnly)
                Else
                    MsgBox("Chọn file attach trước khi gửi !", MsgBoxStyle.OkOnly)
                End If
                v_frm.Close()
                Me.Enabled = True
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            Me.Enabled = True
        End Try

    End Sub


    'Private Function ChooseFolder(ByVal v_strFilter As String) As String
    '    Try
    '        Dim v_oFileDlg As New OpenFileDialog
    '        With v_oFileDlg
    '            .InitialDirectory = "C:\"
    '            If v_strFilter.Length = 0 Then
    '                .Filter = "All|*.*"
    '            Else
    '                .Filter = v_strFilter
    '            End If
    '            .FilterIndex = 2
    '        End With
    '        If v_oFileDlg.ShowDialog() = DialogResult.OK Then
    '            ChooseFolder = v_oFileDlg.FileName
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function
    Private Function ChooseFolder(ByVal v_strFilter As String) As String
        Dim result As String = "C:\"
        Try
            If rdbSubscribe.Checked Then
                Dim v_oFileDlg As New OpenFileDialog
                With v_oFileDlg
                    .InitialDirectory = "C:\"
                    If v_strFilter.Length = 0 Then
                        .Filter = "All|*.*"
                    Else
                        .Filter = v_strFilter
                    End If
                    .FilterIndex = 2
                    .RestoreDirectory = True
                End With
                If v_oFileDlg.ShowDialog() = DialogResult.OK Then
                    ChooseFolder = v_oFileDlg.FileName
                    result = v_oFileDlg.FileName
                End If
            ElseIf rdbBroadcast.Checked Then
                Dim v_oFolderDlg As New FolderBrowserDialog
                v_oFolderDlg.SelectedPath = "C:\"
                If v_oFolderDlg.ShowDialog() = DialogResult.OK Then
                    ChooseFolder = v_oFolderDlg.SelectedPath & "\"
                    result = v_oFolderDlg.SelectedPath & "\"
                End If
            End If
            Return result
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region "Control events"
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        OnClose()
    End Sub

    Private Sub btnBroadcast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBroadcast.Click
        OnBroadcast()
    End Sub

    Private Sub btnSubcribed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubcribed.Click
        OnSubcribed()
    End Sub

    Private Sub frmMail_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        OnInit()
    End Sub

    Private Sub frmMail_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Select Case e.KeyCode
            Case Keys.Escape
                OnClose()
        End Select
    End Sub

    Private Sub btnBODYFILE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.txtBODY.Text = ChooseFolder("HTML Document|*.HTML|All|*.*")
    End Sub

    Private Sub btnATTACHMENTS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnATTACHMENTS.Click
        'Me.txtAttachments.Text = ChooseFolder("Acrobat|*.PDF|All|*.*")
        Dim v_oFolderDlg As New FolderBrowserDialog
        v_oFolderDlg.SelectedPath = "C:\"
        If v_oFolderDlg.ShowDialog() = DialogResult.OK Then
            Me.txtAttachments.Text = v_oFolderDlg.SelectedPath & "\"
        End If
    End Sub

    Private Sub rdbSubscribe_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbSubscribe.Click
        SubcribeDisplay()
    End Sub

    Private Sub rdbBroadcast_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbBroadcast.CheckedChanged
        BroadcastDisplay()
    End Sub

    Private Sub btnBody_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBody.Click

        Dim strContents As String
        Dim objReader As StreamReader
        Try
            Me.txtPathbody.Text = ChooseFolder("Txt|*.txt|All|*.*")
            objReader = New StreamReader(Me.txtPathbody.Text)
            strContents = objReader.ReadToEnd()
            objReader.Close()
            Me.txtSignature.Text = strContents
        Catch Ex As Exception
            MessageBox.Show(Ex.Message)
        End Try
    End Sub

#End Region

#Region "Private methods"
    Private Function validateControls() As Double
        If Trim(Me.txtSMTPSERVER.Text).Length <= 0 Then
            MsgBox(mv_ResourceManager.GetString("SMTPSERVERNOTNULL"), MsgBoxStyle.OkOnly)
            Me.txtSMTPSERVER.Focus()
            Return False
        ElseIf Trim(Me.txtFROM.Text).Length <= 0 Then
            MsgBox(mv_ResourceManager.GetString("FROMNOTNULL"), MsgBoxStyle.OkOnly)
            Me.txtFROM.Focus()
            Return False
        ElseIf Trim(Me.txtUSERNAME.Text).Length <= 0 Then
            MsgBox(mv_ResourceManager.GetString("USERNAMENOTNULL"), MsgBoxStyle.OkOnly)
            Me.txtUSERNAME.Focus()
            Return False
        ElseIf Trim(Me.txtPASSWORD.Text).Length <= 0 Then
            MsgBox(mv_ResourceManager.GetString("PASSWORDNOTNULL"), MsgBoxStyle.OkOnly)
            Me.txtPASSWORD.Focus()
            Return False
        ElseIf Trim(Me.txtTITLE.Text).Length <= 0 Then
            MsgBox(mv_ResourceManager.GetString("TITLENOTNULL"), MsgBoxStyle.OkOnly)
            Me.txtTITLE.Focus()
            Return False
        ElseIf Trim(Me.txtBODY.Text).Length <= 0 Then
            MsgBox(mv_ResourceManager.GetString("BODYNOTNULL"), MsgBoxStyle.OkOnly)
            Me.txtBODY.Focus()
            Return False
        ElseIf Trim(Me.txtAttachments.Text).Length <= 0 Then
            MsgBox(mv_ResourceManager.GetString("ATTACHMENTSNOTNULL"), MsgBoxStyle.OkOnly)
            Me.txtAttachments.Focus()
            Return False
        Else
            Return True
        End If
    End Function

    Public Sub SubcribeDisplay()
        btnBroadcast.Visible = False
        btnSubcribed.Visible = True
    End Sub
    Public Sub BroadcastDisplay()
        btnSubcribed.Visible = False
        btnBroadcast.Visible = True
    End Sub

    Private Sub loadInfoMail()
        Dim v_strSQL, v_strFLDNAME, v_strVALUE, v_strObjMsgVar As String
        Dim v_wsObj As New BDSDeliveryManagement
        Dim v_xmlDocument As New XmlDocumentEx
        Dim v_xmlNodeList As Xml.XmlNodeList

        v_strSQL = "SELECT (SELECT VARDESC FROM SYSVAR WHERE GRNAME = 'SYSTEM' AND VARNAME = 'MAILAUTOBODY') MAILAUTOBODY " _
                            & ", (SELECT VARDESC FROM SYSVAR WHERE GRNAME = 'SYSTEM' AND VARNAME = 'MAILAUTOHEADER') MAILAUTOHEADER " _
                            & ", (SELECT VARDESC FROM SYSVAR WHERE GRNAME = 'SYSTEM' AND VARNAME = 'MESSDF1003FROEM') MESSDF1003FROEM " _
                            & ", (SELECT VARDESC FROM SYSVAR WHERE GRNAME = 'SYSTEM' AND VARNAME = 'MESSDF1003USER') MESSDF1003USER " _
                            & ", (SELECT VARDESC FROM SYSVAR WHERE GRNAME = 'SYSTEM' AND VARNAME = 'MESSDF1003PASS') MESSDF1003PASS " _
                            & ", (SELECT VARDESC FROM SYSVAR WHERE GRNAME = 'SYSTEM' AND VARNAME = 'MAILSERVERNAME') MAILSERVERNAME " _
                            & ", (SELECT VARDESC FROM SYSVAR WHERE GRNAME = 'SYSTEM' AND VARNAME = 'MAILHEADER') MAILHEADER " _
                            & ", (SELECT VARDESC FROM SYSVAR WHERE GRNAME = 'SYSTEM' AND VARNAME = 'MESSDF1003SIGN') MESSDF1003SIGN FROM DUAL"
        v_strObjMsgVar = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_RPTMASTER, _
                                        gc_ActionInquiry, v_strSQL)
        v_wsObj.Message(v_strObjMsgVar)
        v_xmlDocument.LoadXml(v_strObjMsgVar)
        v_xmlNodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

        For i As Integer = 0 To v_xmlNodeList.Count - 1
            For l As Integer = 0 To v_xmlNodeList.Item(i).ChildNodes.Count - 1
                With v_xmlNodeList.Item(i).ChildNodes(l)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strVALUE = .InnerText.ToString
                    Select Case v_strFLDNAME.Trim()
                        Case "MESSDF1003FROEM"
                            Me.txtFROM.Text = v_strVALUE.Trim()
                        Case "MAILAUTOHEADER"
                            Me.txtTITLE.Text = v_strVALUE.Trim()
                        Case "MAILAUTOBODY"
                            Me.txtBODY.Text = v_strVALUE.Trim()
                        Case "MESSDF1003USER"
                            Me.txtUSERNAME.Text = v_strVALUE.Trim()
                        Case "MESSDF1003PASS"
                            Me.txtPASSWORD.Text = v_strVALUE.Trim()
                        Case "MAILSERVERNAME"
                            Me.txtSMTPSERVER.Text = v_strVALUE.Trim()
                        Case "MESSDF1003SIGN"
                            Me.txtSignature.Text = v_strVALUE.Trim()
                    End Select
                End With
            Next
        Next
    End Sub
#End Region


    ' This method shows how to move files from one folder to another folder.

    Public Sub MoveFile(ByVal sourceFilePath As String, ByVal DestinationFilePath As String)
        Try
            If System.IO.File.Exists(sourceFilePath) = True Then
                System.IO.File.Move(sourceFilePath, DestinationFilePath)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


   

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim v_strRight2Save As String = String.Empty
        Dim v_strObjMsg As String
        'Dim v_xmlDocument As New XmlDocument
        'Dim v_txDocument As New XmlDocument

        'Get general information
        v_strRight2Save = Me.txtTITLE.Text & "|" & HTMLE.InnerHtml.ToString()

        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strErrorSource, v_strErrorMessage As String

        'Call webservice
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, "SA.EMAILSMS", gc_ActionAdhoc, , , "EMAILSMS_Addnew", , , v_strRight2Save, , , , "", v_strRight2Save)
        'v_ws.Message(v_strObjMsg)
        BuildXMLObjData(mv_dsInput, v_strObjMsg)

        Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)
        GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)


    End Sub
End Class
