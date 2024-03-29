Imports CommonLibrary
Imports AppCore
Imports System.Xml.XmlNode
Imports System.Xml
Imports TestBase64
Imports ZetaCompressionLibrary
Imports System.IO
Public Class frmCFAUTH
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
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents lblVALDATE As System.Windows.Forms.Label
    Friend WithEvents lblTELEPHONE As System.Windows.Forms.Label
    Public WithEvents lblLICENSENO As System.Windows.Forms.Label
    Friend WithEvents lblADDRESS As System.Windows.Forms.Label
    Friend WithEvents txtLICENSENO As System.Windows.Forms.TextBox
    Friend WithEvents txtADDRESS As System.Windows.Forms.TextBox
    Friend WithEvents dtpVALDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtTELEPHONE As System.Windows.Forms.TextBox
    Friend WithEvents lblFULLNAME As System.Windows.Forms.Label
    Friend WithEvents txtFULLNAME As System.Windows.Forms.TextBox
    Friend WithEvents GpAuth As System.Windows.Forms.GroupBox
    Friend WithEvents tbcCFAUTH As System.Windows.Forms.TabControl
    Friend WithEvents tpAuthInfo As System.Windows.Forms.TabPage
    Friend WithEvents tpSign As System.Windows.Forms.TabPage
    Friend WithEvents txtBROWSER As System.Windows.Forms.TextBox
    Friend WithEvents btnBROWSER As System.Windows.Forms.Button
    Friend WithEvents ckb10 As System.Windows.Forms.CheckBox
    Friend WithEvents ckb9 As System.Windows.Forms.CheckBox
    Friend WithEvents ckb8 As System.Windows.Forms.CheckBox
    Friend WithEvents ckb5 As System.Windows.Forms.CheckBox
    Friend WithEvents ckb4 As System.Windows.Forms.CheckBox
    Friend WithEvents ckb3 As System.Windows.Forms.CheckBox
    Friend WithEvents ckb2 As System.Windows.Forms.CheckBox
    Friend WithEvents ckb1 As System.Windows.Forms.CheckBox
    Friend WithEvents txtLNPLACE As System.Windows.Forms.TextBox
    Friend WithEvents btnNEXT As System.Windows.Forms.Button
    Friend WithEvents btnPREVIOUS As System.Windows.Forms.Button
    Friend WithEvents ckb11 As System.Windows.Forms.CheckBox
    Friend WithEvents ckb7 As System.Windows.Forms.CheckBox
    Friend WithEvents tpHiddenTab As System.Windows.Forms.TabPage
    Friend WithEvents txtLINKAUTH As System.Windows.Forms.TextBox
    Friend WithEvents txtAUTOID As System.Windows.Forms.TextBox
    Friend WithEvents cboDELTD As AppCore.ComboBoxEx
    Friend WithEvents TRANSFER As System.Windows.Forms.GroupBox
    Friend WithEvents cboBANKNAME As AppCore.ComboBoxEx
    Friend WithEvents lblBANKNAME As System.Windows.Forms.Label
    Friend WithEvents txtACCOUNTNAME As System.Windows.Forms.TextBox
    Friend WithEvents lblACCOUNTNAME As System.Windows.Forms.Label
    Friend WithEvents txtBANKACCOUNT As System.Windows.Forms.TextBox
    Friend WithEvents lblBANKACCOUNT As System.Windows.Forms.Label
    Friend WithEvents txtCFCUSTID As System.Windows.Forms.TextBox
    Friend WithEvents lblCFCUSTID As System.Windows.Forms.Label
    Friend WithEvents TabControlHide As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents ckbALL As System.Windows.Forms.CheckBox
    Friend WithEvents pbxSIGNATURE As System.Windows.Forms.PictureBox
    Friend WithEvents cboAUTHTYPE As AppCore.ComboBoxEx
    Friend WithEvents lblAUTHTYPE As System.Windows.Forms.Label
    Friend WithEvents ckb6 As System.Windows.Forms.CheckBox
    Friend WithEvents txtDESCRIPTION As System.Windows.Forms.TextBox
    Friend WithEvents lblDESCRIPTION As System.Windows.Forms.Label
    Friend WithEvents DataTable6 As System.Data.DataTable
    Friend WithEvents ckb12 As System.Windows.Forms.CheckBox
    Friend WithEvents ckb13 As System.Windows.Forms.CheckBox
    Friend WithEvents DataTable7 As System.Data.DataTable
    Friend WithEvents DataTable8 As System.Data.DataTable
    Friend WithEvents DataTable9 As System.Data.DataTable
    Friend WithEvents ckb15 As System.Windows.Forms.CheckBox
    Friend WithEvents ckb16 As System.Windows.Forms.CheckBox
    Friend WithEvents ckb14 As System.Windows.Forms.CheckBox
    Friend WithEvents DataTable1 As System.Data.DataTable
    Friend WithEvents DataTable11 As System.Data.DataTable
    Friend WithEvents DataTable2 As System.Data.DataTable
    Friend WithEvents DataTable3 As System.Data.DataTable
    Friend WithEvents DataTable29 As System.Data.DataTable
    Friend WithEvents DataTable4 As System.Data.DataTable
    Friend WithEvents txtEMAIL As System.Windows.Forms.TextBox
    Friend WithEvents lblEMAIL As System.Windows.Forms.Label
    Friend WithEvents cboSHV As AppCore.ComboBoxEx
    Friend WithEvents lblSHV As System.Windows.Forms.Label
    Friend WithEvents cboAUTHLIMIT As AppCore.ComboBoxEx
    Friend WithEvents cboNOTARY As AppCore.ComboBoxEx
    Friend WithEvents lblAUTHLIMIT As System.Windows.Forms.Label
    Friend WithEvents dtpLNIDDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblLNIDDATE As System.Windows.Forms.Label
    Friend WithEvents lblLNPLACE As System.Windows.Forms.Label
    Friend WithEvents dtpEXPDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtCUSTID As System.Windows.Forms.TextBox
    Friend WithEvents lblEXPDATE As System.Windows.Forms.Label
    Friend WithEvents lblCUSTID As System.Windows.Forms.Label
    Friend WithEvents DataTable39 As System.Data.DataTable
    Friend WithEvents DataTable42 As System.Data.DataTable
    Friend WithEvents lblTITLE As System.Windows.Forms.Label
    Friend WithEvents DataTable58 As System.Data.DataTable
    Friend WithEvents txtTITLE As System.Windows.Forms.TextBox
    Friend WithEvents lblNOTARY As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCFAUTH))
        Me.GpAuth = New System.Windows.Forms.GroupBox()
        Me.txtEMAIL = New System.Windows.Forms.TextBox()
        Me.lblEMAIL = New System.Windows.Forms.Label()
        Me.cboSHV = New AppCore.ComboBoxEx()
        Me.lblSHV = New System.Windows.Forms.Label()
        Me.ckb15 = New System.Windows.Forms.CheckBox()
        Me.ckb16 = New System.Windows.Forms.CheckBox()
        Me.ckb14 = New System.Windows.Forms.CheckBox()
        Me.ckb13 = New System.Windows.Forms.CheckBox()
        Me.ckb12 = New System.Windows.Forms.CheckBox()
        Me.txtDESCRIPTION = New System.Windows.Forms.TextBox()
        Me.lblDESCRIPTION = New System.Windows.Forms.Label()
        Me.cboAUTHLIMIT = New AppCore.ComboBoxEx()
        Me.cboAUTHTYPE = New AppCore.ComboBoxEx()
        Me.lblAUTHLIMIT = New System.Windows.Forms.Label()
        Me.lblNOTARY = New System.Windows.Forms.Label()
        Me.lblAUTHTYPE = New System.Windows.Forms.Label()
        Me.ckbALL = New System.Windows.Forms.CheckBox()
        Me.ckb7 = New System.Windows.Forms.CheckBox()
        Me.dtpLNIDDATE = New System.Windows.Forms.DateTimePicker()
        Me.lblLNIDDATE = New System.Windows.Forms.Label()
        Me.txtLNPLACE = New System.Windows.Forms.TextBox()
        Me.lblLNPLACE = New System.Windows.Forms.Label()
        Me.ckb9 = New System.Windows.Forms.CheckBox()
        Me.ckb8 = New System.Windows.Forms.CheckBox()
        Me.ckb5 = New System.Windows.Forms.CheckBox()
        Me.ckb4 = New System.Windows.Forms.CheckBox()
        Me.ckb3 = New System.Windows.Forms.CheckBox()
        Me.ckb2 = New System.Windows.Forms.CheckBox()
        Me.ckb1 = New System.Windows.Forms.CheckBox()
        Me.txtFULLNAME = New System.Windows.Forms.TextBox()
        Me.dtpEXPDATE = New System.Windows.Forms.DateTimePicker()
        Me.dtpVALDATE = New System.Windows.Forms.DateTimePicker()
        Me.txtADDRESS = New System.Windows.Forms.TextBox()
        Me.txtLICENSENO = New System.Windows.Forms.TextBox()
        Me.txtTELEPHONE = New System.Windows.Forms.TextBox()
        Me.txtCUSTID = New System.Windows.Forms.TextBox()
        Me.lblADDRESS = New System.Windows.Forms.Label()
        Me.lblFULLNAME = New System.Windows.Forms.Label()
        Me.lblLICENSENO = New System.Windows.Forms.Label()
        Me.lblTELEPHONE = New System.Windows.Forms.Label()
        Me.lblVALDATE = New System.Windows.Forms.Label()
        Me.lblEXPDATE = New System.Windows.Forms.Label()
        Me.lblCUSTID = New System.Windows.Forms.Label()
        Me.cboNOTARY = New AppCore.ComboBoxEx()
        Me.ckb6 = New System.Windows.Forms.CheckBox()
        Me.ckb11 = New System.Windows.Forms.CheckBox()
        Me.ckb10 = New System.Windows.Forms.CheckBox()
        Me.tbcCFAUTH = New System.Windows.Forms.TabControl()
        Me.tpAuthInfo = New System.Windows.Forms.TabPage()
        Me.tpSign = New System.Windows.Forms.TabPage()
        Me.pbxSIGNATURE = New System.Windows.Forms.PictureBox()
        Me.btnPREVIOUS = New System.Windows.Forms.Button()
        Me.btnNEXT = New System.Windows.Forms.Button()
        Me.txtBROWSER = New System.Windows.Forms.TextBox()
        Me.btnBROWSER = New System.Windows.Forms.Button()
        Me.tpHiddenTab = New System.Windows.Forms.TabPage()
        Me.txtCFCUSTID = New System.Windows.Forms.TextBox()
        Me.lblCFCUSTID = New System.Windows.Forms.Label()
        Me.txtLINKAUTH = New System.Windows.Forms.TextBox()
        Me.txtAUTOID = New System.Windows.Forms.TextBox()
        Me.cboDELTD = New AppCore.ComboBoxEx()
        Me.TRANSFER = New System.Windows.Forms.GroupBox()
        Me.cboBANKNAME = New AppCore.ComboBoxEx()
        Me.lblBANKNAME = New System.Windows.Forms.Label()
        Me.txtACCOUNTNAME = New System.Windows.Forms.TextBox()
        Me.lblACCOUNTNAME = New System.Windows.Forms.Label()
        Me.txtBANKACCOUNT = New System.Windows.Forms.TextBox()
        Me.lblBANKACCOUNT = New System.Windows.Forms.Label()
        Me.TabControlHide = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.DataTable6 = New System.Data.DataTable()
        Me.DataTable7 = New System.Data.DataTable()
        Me.DataTable8 = New System.Data.DataTable()
        Me.DataTable9 = New System.Data.DataTable()
        Me.DataTable1 = New System.Data.DataTable()
        Me.DataTable11 = New System.Data.DataTable()
        Me.DataTable2 = New System.Data.DataTable()
        Me.DataTable3 = New System.Data.DataTable()
        Me.DataTable29 = New System.Data.DataTable()
        Me.DataTable4 = New System.Data.DataTable()
        Me.DataTable39 = New System.Data.DataTable()
        Me.DataTable42 = New System.Data.DataTable()
        Me.lblTITLE = New System.Windows.Forms.Label()
        Me.DataTable58 = New System.Data.DataTable()
        Me.txtTITLE = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.GpAuth.SuspendLayout()
        Me.tbcCFAUTH.SuspendLayout()
        Me.tpAuthInfo.SuspendLayout()
        Me.tpSign.SuspendLayout()
        CType(Me.pbxSIGNATURE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpHiddenTab.SuspendLayout()
        Me.TRANSFER.SuspendLayout()
        Me.TabControlHide.SuspendLayout()
        CType(Me.DataTable6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable29, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable39, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable42, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable58, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(375, 407)
        Me.btnOK.Size = New System.Drawing.Size(85, 24)
        Me.btnOK.TabIndex = 40
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(557, 407)
        Me.btnCancel.Size = New System.Drawing.Size(85, 24)
        Me.btnCancel.TabIndex = 42
        '
        'lblCaption
        '
        Me.lblCaption.Location = New System.Drawing.Point(7, 17)
        '
        'btnApply
        '
        Me.btnApply.Location = New System.Drawing.Point(466, 408)
        Me.btnApply.Size = New System.Drawing.Size(85, 23)
        Me.btnApply.TabIndex = 41
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(656, 50)
        '
        'btnApprv
        '
        Me.btnApprv.Location = New System.Drawing.Point(270, 470)
        '
        'cboLink
        '
        Me.cboLink.Location = New System.Drawing.Point(6, 475)
        '
        'GpAuth
        '
        Me.GpAuth.BackColor = System.Drawing.SystemColors.Control
        Me.GpAuth.Controls.Add(Me.txtTITLE)
        Me.GpAuth.Controls.Add(Me.lblTITLE)
        Me.GpAuth.Controls.Add(Me.txtEMAIL)
        Me.GpAuth.Controls.Add(Me.lblEMAIL)
        Me.GpAuth.Controls.Add(Me.cboSHV)
        Me.GpAuth.Controls.Add(Me.lblSHV)
        Me.GpAuth.Controls.Add(Me.ckb15)
        Me.GpAuth.Controls.Add(Me.ckb16)
        Me.GpAuth.Controls.Add(Me.ckb14)
        Me.GpAuth.Controls.Add(Me.ckb13)
        Me.GpAuth.Controls.Add(Me.ckb12)
        Me.GpAuth.Controls.Add(Me.txtDESCRIPTION)
        Me.GpAuth.Controls.Add(Me.lblDESCRIPTION)
        Me.GpAuth.Controls.Add(Me.cboAUTHLIMIT)
        Me.GpAuth.Controls.Add(Me.cboAUTHTYPE)
        Me.GpAuth.Controls.Add(Me.lblAUTHLIMIT)
        Me.GpAuth.Controls.Add(Me.lblNOTARY)
        Me.GpAuth.Controls.Add(Me.lblAUTHTYPE)
        Me.GpAuth.Controls.Add(Me.ckbALL)
        Me.GpAuth.Controls.Add(Me.ckb7)
        Me.GpAuth.Controls.Add(Me.dtpLNIDDATE)
        Me.GpAuth.Controls.Add(Me.lblLNIDDATE)
        Me.GpAuth.Controls.Add(Me.txtLNPLACE)
        Me.GpAuth.Controls.Add(Me.lblLNPLACE)
        Me.GpAuth.Controls.Add(Me.ckb9)
        Me.GpAuth.Controls.Add(Me.ckb8)
        Me.GpAuth.Controls.Add(Me.ckb5)
        Me.GpAuth.Controls.Add(Me.ckb4)
        Me.GpAuth.Controls.Add(Me.ckb3)
        Me.GpAuth.Controls.Add(Me.ckb2)
        Me.GpAuth.Controls.Add(Me.ckb1)
        Me.GpAuth.Controls.Add(Me.txtFULLNAME)
        Me.GpAuth.Controls.Add(Me.dtpEXPDATE)
        Me.GpAuth.Controls.Add(Me.dtpVALDATE)
        Me.GpAuth.Controls.Add(Me.txtADDRESS)
        Me.GpAuth.Controls.Add(Me.txtLICENSENO)
        Me.GpAuth.Controls.Add(Me.txtTELEPHONE)
        Me.GpAuth.Controls.Add(Me.txtCUSTID)
        Me.GpAuth.Controls.Add(Me.lblADDRESS)
        Me.GpAuth.Controls.Add(Me.lblFULLNAME)
        Me.GpAuth.Controls.Add(Me.lblLICENSENO)
        Me.GpAuth.Controls.Add(Me.lblTELEPHONE)
        Me.GpAuth.Controls.Add(Me.lblVALDATE)
        Me.GpAuth.Controls.Add(Me.lblEXPDATE)
        Me.GpAuth.Controls.Add(Me.lblCUSTID)
        Me.GpAuth.Location = New System.Drawing.Point(3, 4)
        Me.GpAuth.Name = "GpAuth"
        Me.GpAuth.Size = New System.Drawing.Size(641, 313)
        Me.GpAuth.TabIndex = 0
        Me.GpAuth.TabStop = False
        Me.GpAuth.Tag = "GpAuth"
        Me.GpAuth.Text = "GpAuth"
        '
        'txtEMAIL
        '
        Me.txtEMAIL.Location = New System.Drawing.Point(94, 94)
        Me.txtEMAIL.Name = "txtEMAIL"
        Me.txtEMAIL.Size = New System.Drawing.Size(143, 21)
        Me.txtEMAIL.TabIndex = 179
        Me.txtEMAIL.Tag = "EMAIL"
        '
        'lblEMAIL
        '
        Me.lblEMAIL.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblEMAIL.Location = New System.Drawing.Point(7, 100)
        Me.lblEMAIL.Name = "lblEMAIL"
        Me.lblEMAIL.Size = New System.Drawing.Size(92, 15)
        Me.lblEMAIL.TabIndex = 178
        Me.lblEMAIL.Tag = "lblEMAIL"
        Me.lblEMAIL.Text = "Email:"
        '
        'cboSHV
        '
        Me.cboSHV.DisplayMember = "DISPLAY"
        Me.cboSHV.FormattingEnabled = True
        Me.cboSHV.Location = New System.Drawing.Point(537, 148)
        Me.cboSHV.Name = "cboSHV"
        Me.cboSHV.Size = New System.Drawing.Size(94, 21)
        Me.cboSHV.TabIndex = 10
        Me.cboSHV.Tag = "SHV"
        Me.cboSHV.ValueMember = "VALUE"
        '
        'lblSHV
        '
        Me.lblSHV.AutoSize = True
        Me.lblSHV.Location = New System.Drawing.Point(471, 153)
        Me.lblSHV.Name = "lblSHV"
        Me.lblSHV.Size = New System.Drawing.Size(30, 13)
        Me.lblSHV.TabIndex = 177
        Me.lblSHV.Tag = "lblSHV"
        Me.lblSHV.Text = "SHV:"
        '
        'ckb15
        '
        Me.ckb15.Location = New System.Drawing.Point(514, 260)
        Me.ckb15.Name = "ckb15"
        Me.ckb15.Size = New System.Drawing.Size(127, 20)
        Me.ckb15.TabIndex = 25
        Me.ckb15.Tag = "ckb15"
        Me.ckb15.Text = "cbk15"
        '
        'ckb16
        '
        Me.ckb16.Location = New System.Drawing.Point(183, 283)
        Me.ckb16.Name = "ckb16"
        Me.ckb16.Size = New System.Drawing.Size(127, 20)
        Me.ckb16.TabIndex = 25
        Me.ckb16.Tag = "ckb16"
        Me.ckb16.Text = "cbk16"
        '
        'ckb14
        '
        Me.ckb14.Location = New System.Drawing.Point(514, 234)
        Me.ckb14.Name = "ckb14"
        Me.ckb14.Size = New System.Drawing.Size(121, 20)
        Me.ckb14.TabIndex = 21
        Me.ckb14.Tag = "ckb14"
        Me.ckb14.Text = "ckb14"
        '
        'ckb13
        '
        Me.ckb13.AutoSize = True
        Me.ckb13.Location = New System.Drawing.Point(514, 213)
        Me.ckb13.Name = "ckb13"
        Me.ckb13.Size = New System.Drawing.Size(54, 17)
        Me.ckb13.TabIndex = 17
        Me.ckb13.Text = "ckb13"
        Me.ckb13.UseVisualStyleBackColor = True
        '
        'ckb12
        '
        Me.ckb12.AutoSize = True
        Me.ckb12.Location = New System.Drawing.Point(10, 285)
        Me.ckb12.Name = "ckb12"
        Me.ckb12.Size = New System.Drawing.Size(54, 17)
        Me.ckb12.TabIndex = 28
        Me.ckb12.Text = "ckb12"
        Me.ckb12.UseVisualStyleBackColor = True
        '
        'txtDESCRIPTION
        '
        Me.txtDESCRIPTION.Location = New System.Drawing.Point(93, 175)
        Me.txtDESCRIPTION.MaxLength = 1
        Me.txtDESCRIPTION.Name = "txtDESCRIPTION"
        Me.txtDESCRIPTION.Size = New System.Drawing.Size(542, 21)
        Me.txtDESCRIPTION.TabIndex = 13
        Me.txtDESCRIPTION.Tag = "DESCRIPTION"
        Me.txtDESCRIPTION.Text = "txtDESCRIPTION"
        '
        'lblDESCRIPTION
        '
        Me.lblDESCRIPTION.Location = New System.Drawing.Point(7, 181)
        Me.lblDESCRIPTION.Name = "lblDESCRIPTION"
        Me.lblDESCRIPTION.Size = New System.Drawing.Size(92, 15)
        Me.lblDESCRIPTION.TabIndex = 174
        Me.lblDESCRIPTION.Tag = "DESCRIPTION"
        Me.lblDESCRIPTION.Text = "Mô tả"
        '
        'cboAUTHLIMIT
        '
        Me.cboAUTHLIMIT.DisplayMember = "DISPLAY"
        Me.cboAUTHLIMIT.FormattingEnabled = True
        Me.cboAUTHLIMIT.Location = New System.Drawing.Point(338, 124)
        Me.cboAUTHLIMIT.Name = "cboAUTHLIMIT"
        Me.cboAUTHLIMIT.Size = New System.Drawing.Size(95, 21)
        Me.cboAUTHLIMIT.TabIndex = 9
        Me.cboAUTHLIMIT.Tag = "AUTHLIMIT"
        Me.cboAUTHLIMIT.ValueMember = "VALUE"
        '
        'cboAUTHTYPE
        '
        Me.cboAUTHTYPE.DisplayMember = "DISPLAY"
        Me.cboAUTHTYPE.FormattingEnabled = True
        Me.cboAUTHTYPE.Location = New System.Drawing.Point(93, 121)
        Me.cboAUTHTYPE.Name = "cboAUTHTYPE"
        Me.cboAUTHTYPE.Size = New System.Drawing.Size(144, 21)
        Me.cboAUTHTYPE.TabIndex = 8
        Me.cboAUTHTYPE.Tag = "AUTHTYPE"
        Me.cboAUTHTYPE.ValueMember = "VALUE"
        '
        'lblAUTHLIMIT
        '
        Me.lblAUTHLIMIT.AutoSize = True
        Me.lblAUTHLIMIT.Location = New System.Drawing.Point(252, 127)
        Me.lblAUTHLIMIT.Name = "lblAUTHLIMIT"
        Me.lblAUTHLIMIT.Size = New System.Drawing.Size(79, 13)
        Me.lblAUTHLIMIT.TabIndex = 173
        Me.lblAUTHLIMIT.Tag = "AUTHLIMIT"
        Me.lblAUTHLIMIT.Text = "Kiểu ủy quyền:"
        '
        'lblNOTARY
        '
        Me.lblNOTARY.AutoSize = True
        Me.lblNOTARY.Location = New System.Drawing.Point(650, 13)
        Me.lblNOTARY.Name = "lblNOTARY"
        Me.lblNOTARY.Size = New System.Drawing.Size(69, 13)
        Me.lblNOTARY.TabIndex = 173
        Me.lblNOTARY.Tag = "NOTARY"
        Me.lblNOTARY.Text = "Công chứng:"
        Me.lblNOTARY.Visible = False
        '
        'lblAUTHTYPE
        '
        Me.lblAUTHTYPE.AutoSize = True
        Me.lblAUTHTYPE.Location = New System.Drawing.Point(7, 127)
        Me.lblAUTHTYPE.Name = "lblAUTHTYPE"
        Me.lblAUTHTYPE.Size = New System.Drawing.Size(78, 13)
        Me.lblAUTHTYPE.TabIndex = 173
        Me.lblAUTHTYPE.Tag = "AUTHTYPE"
        Me.lblAUTHTYPE.Text = "Loại ủy quyền:"
        '
        'ckbALL
        '
        Me.ckbALL.Location = New System.Drawing.Point(9, 211)
        Me.ckbALL.Name = "ckbALL"
        Me.ckbALL.Size = New System.Drawing.Size(168, 20)
        Me.ckbALL.TabIndex = 14
        Me.ckbALL.Tag = "ckbALL"
        Me.ckbALL.Text = "ckbALL"
        '
        'ckb7
        '
        Me.ckb7.Location = New System.Drawing.Point(9, 258)
        Me.ckb7.Name = "ckb7"
        Me.ckb7.Size = New System.Drawing.Size(162, 21)
        Me.ckb7.TabIndex = 27
        Me.ckb7.Tag = "ckb7"
        Me.ckb7.Text = "ckb7"
        '
        'dtpLNIDDATE
        '
        Me.dtpLNIDDATE.CustomFormat = "dd/MM/yyyy"
        Me.dtpLNIDDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpLNIDDATE.Location = New System.Drawing.Point(537, 121)
        Me.dtpLNIDDATE.Name = "dtpLNIDDATE"
        Me.dtpLNIDDATE.Size = New System.Drawing.Size(94, 21)
        Me.dtpLNIDDATE.TabIndex = 7
        Me.dtpLNIDDATE.Tag = "LNIDDATE"
        '
        'lblLNIDDATE
        '
        Me.lblLNIDDATE.Location = New System.Drawing.Point(471, 124)
        Me.lblLNIDDATE.Name = "lblLNIDDATE"
        Me.lblLNIDDATE.Size = New System.Drawing.Size(60, 21)
        Me.lblLNIDDATE.TabIndex = 34
        Me.lblLNIDDATE.Tag = "LNIDDATE"
        Me.lblLNIDDATE.Text = "Ngày cấp:"
        '
        'txtLNPLACE
        '
        Me.txtLNPLACE.Location = New System.Drawing.Point(536, 94)
        Me.txtLNPLACE.Name = "txtLNPLACE"
        Me.txtLNPLACE.Size = New System.Drawing.Size(95, 21)
        Me.txtLNPLACE.TabIndex = 6
        Me.txtLNPLACE.Tag = "LNPLACE"
        '
        'lblLNPLACE
        '
        Me.lblLNPLACE.AutoSize = True
        Me.lblLNPLACE.Location = New System.Drawing.Point(471, 97)
        Me.lblLNPLACE.Name = "lblLNPLACE"
        Me.lblLNPLACE.Size = New System.Drawing.Size(46, 13)
        Me.lblLNPLACE.TabIndex = 33
        Me.lblLNPLACE.Tag = "LNPLACE"
        Me.lblLNPLACE.Text = "Nơi cấp:"
        '
        'ckb9
        '
        Me.ckb9.Location = New System.Drawing.Point(351, 260)
        Me.ckb9.Name = "ckb9"
        Me.ckb9.Size = New System.Drawing.Size(138, 20)
        Me.ckb9.TabIndex = 24
        Me.ckb9.Tag = "ckb9"
        Me.ckb9.Text = "ckb9"
        '
        'ckb8
        '
        Me.ckb8.Location = New System.Drawing.Point(183, 259)
        Me.ckb8.Name = "ckb8"
        Me.ckb8.Size = New System.Drawing.Size(112, 20)
        Me.ckb8.TabIndex = 23
        Me.ckb8.Tag = "ckb8"
        Me.ckb8.Text = "ckb8"
        '
        'ckb5
        '
        Me.ckb5.Location = New System.Drawing.Point(351, 234)
        Me.ckb5.Name = "ckb5"
        Me.ckb5.Size = New System.Drawing.Size(140, 20)
        Me.ckb5.TabIndex = 20
        Me.ckb5.Tag = "ckb5"
        Me.ckb5.Text = "ckb5"
        '
        'ckb4
        '
        Me.ckb4.Location = New System.Drawing.Point(183, 234)
        Me.ckb4.Name = "ckb4"
        Me.ckb4.Size = New System.Drawing.Size(144, 20)
        Me.ckb4.TabIndex = 19
        Me.ckb4.Tag = "ckb4"
        Me.ckb4.Text = "ckb4"
        '
        'ckb3
        '
        Me.ckb3.Location = New System.Drawing.Point(9, 234)
        Me.ckb3.Name = "ckb3"
        Me.ckb3.Size = New System.Drawing.Size(168, 20)
        Me.ckb3.TabIndex = 18
        Me.ckb3.Tag = "ckb3"
        Me.ckb3.Text = "ckb3"
        '
        'ckb2
        '
        Me.ckb2.Location = New System.Drawing.Point(351, 211)
        Me.ckb2.Name = "ckb2"
        Me.ckb2.Size = New System.Drawing.Size(140, 20)
        Me.ckb2.TabIndex = 16
        Me.ckb2.Tag = "ckb2"
        Me.ckb2.Text = "ckb2"
        '
        'ckb1
        '
        Me.ckb1.Location = New System.Drawing.Point(183, 211)
        Me.ckb1.Name = "ckb1"
        Me.ckb1.Size = New System.Drawing.Size(144, 20)
        Me.ckb1.TabIndex = 15
        Me.ckb1.Tag = "ckb1"
        Me.ckb1.Text = "ckb1"
        '
        'txtFULLNAME
        '
        Me.txtFULLNAME.Location = New System.Drawing.Point(93, 40)
        Me.txtFULLNAME.Name = "txtFULLNAME"
        Me.txtFULLNAME.Size = New System.Drawing.Size(542, 21)
        Me.txtFULLNAME.TabIndex = 3
        Me.txtFULLNAME.Tag = "FULLNAME"
        Me.txtFULLNAME.Text = "txtFULLNAME"
        '
        'dtpEXPDATE
        '
        Me.dtpEXPDATE.CustomFormat = "dd/MM/yyyy"
        Me.dtpEXPDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEXPDATE.Location = New System.Drawing.Point(351, 151)
        Me.dtpEXPDATE.Name = "dtpEXPDATE"
        Me.dtpEXPDATE.Size = New System.Drawing.Size(108, 21)
        Me.dtpEXPDATE.TabIndex = 12
        Me.dtpEXPDATE.Tag = "EXPDATE"
        '
        'dtpVALDATE
        '
        Me.dtpVALDATE.CustomFormat = "dd/MM/yyyy"
        Me.dtpVALDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpVALDATE.Location = New System.Drawing.Point(93, 148)
        Me.dtpVALDATE.Name = "dtpVALDATE"
        Me.dtpVALDATE.Size = New System.Drawing.Size(144, 21)
        Me.dtpVALDATE.TabIndex = 11
        Me.dtpVALDATE.Tag = "VALDATE"
        '
        'txtADDRESS
        '
        Me.txtADDRESS.Location = New System.Drawing.Point(93, 67)
        Me.txtADDRESS.Name = "txtADDRESS"
        Me.txtADDRESS.Size = New System.Drawing.Size(542, 21)
        Me.txtADDRESS.TabIndex = 4
        Me.txtADDRESS.Tag = "ADDRESS"
        Me.txtADDRESS.Text = "txtADDRESS"
        '
        'txtLICENSENO
        '
        Me.txtLICENSENO.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLICENSENO.Location = New System.Drawing.Point(93, 13)
        Me.txtLICENSENO.Name = "txtLICENSENO"
        Me.txtLICENSENO.Size = New System.Drawing.Size(144, 21)
        Me.txtLICENSENO.TabIndex = 0
        Me.txtLICENSENO.Tag = "LICENSENO"
        Me.txtLICENSENO.Text = "txtLICENSENO"
        '
        'txtTELEPHONE
        '
        Me.txtTELEPHONE.Location = New System.Drawing.Point(338, 94)
        Me.txtTELEPHONE.Name = "txtTELEPHONE"
        Me.txtTELEPHONE.Size = New System.Drawing.Size(84, 21)
        Me.txtTELEPHONE.TabIndex = 5
        Me.txtTELEPHONE.Tag = "TELEPHONE"
        Me.txtTELEPHONE.Text = "txtTELEPHONE"
        '
        'txtCUSTID
        '
        Me.txtCUSTID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCUSTID.Location = New System.Drawing.Point(331, 16)
        Me.txtCUSTID.Name = "txtCUSTID"
        Me.txtCUSTID.Size = New System.Drawing.Size(94, 21)
        Me.txtCUSTID.TabIndex = 1
        Me.txtCUSTID.Tag = "CUSTID"
        Me.txtCUSTID.Text = "txtCUSTID"
        '
        'lblADDRESS
        '
        Me.lblADDRESS.Location = New System.Drawing.Point(6, 73)
        Me.lblADDRESS.Name = "lblADDRESS"
        Me.lblADDRESS.Size = New System.Drawing.Size(92, 18)
        Me.lblADDRESS.TabIndex = 7
        Me.lblADDRESS.Tag = "ADDRESS"
        Me.lblADDRESS.Text = "lblADDRESS"
        '
        'lblFULLNAME
        '
        Me.lblFULLNAME.Location = New System.Drawing.Point(6, 46)
        Me.lblFULLNAME.Name = "lblFULLNAME"
        Me.lblFULLNAME.Size = New System.Drawing.Size(92, 18)
        Me.lblFULLNAME.TabIndex = 6
        Me.lblFULLNAME.Tag = "FULLNAME"
        Me.lblFULLNAME.Text = "lblFULLNAME"
        '
        'lblLICENSENO
        '
        Me.lblLICENSENO.Location = New System.Drawing.Point(6, 19)
        Me.lblLICENSENO.Name = "lblLICENSENO"
        Me.lblLICENSENO.Size = New System.Drawing.Size(120, 21)
        Me.lblLICENSENO.TabIndex = 5
        Me.lblLICENSENO.Tag = "LICENSENO"
        Me.lblLICENSENO.Text = "ID Code"
        '
        'lblTELEPHONE
        '
        Me.lblTELEPHONE.Location = New System.Drawing.Point(251, 100)
        Me.lblTELEPHONE.Name = "lblTELEPHONE"
        Me.lblTELEPHONE.Size = New System.Drawing.Size(92, 15)
        Me.lblTELEPHONE.TabIndex = 4
        Me.lblTELEPHONE.Tag = "TELEPHONE"
        Me.lblTELEPHONE.Text = "lblTELEPHONE"
        '
        'lblVALDATE
        '
        Me.lblVALDATE.Location = New System.Drawing.Point(7, 154)
        Me.lblVALDATE.Name = "lblVALDATE"
        Me.lblVALDATE.Size = New System.Drawing.Size(86, 18)
        Me.lblVALDATE.TabIndex = 3
        Me.lblVALDATE.Tag = "VALDATE"
        Me.lblVALDATE.Text = "Ngày hiệu lực:"
        '
        'lblEXPDATE
        '
        Me.lblEXPDATE.Location = New System.Drawing.Point(252, 154)
        Me.lblEXPDATE.Name = "lblEXPDATE"
        Me.lblEXPDATE.Size = New System.Drawing.Size(101, 21)
        Me.lblEXPDATE.TabIndex = 2
        Me.lblEXPDATE.Tag = "EXPDATE"
        Me.lblEXPDATE.Text = "Ngày hết hiệu lực:"
        '
        'lblCUSTID
        '
        Me.lblCUSTID.Location = New System.Drawing.Point(244, 19)
        Me.lblCUSTID.Name = "lblCUSTID"
        Me.lblCUSTID.Size = New System.Drawing.Size(92, 21)
        Me.lblCUSTID.TabIndex = 0
        Me.lblCUSTID.Tag = "CUSTID"
        Me.lblCUSTID.Text = "lblCUSTID"
        '
        'cboNOTARY
        '
        Me.cboNOTARY.DisplayMember = "DISPLAY"
        Me.cboNOTARY.FormattingEnabled = True
        Me.cboNOTARY.Location = New System.Drawing.Point(835, 95)
        Me.cboNOTARY.Name = "cboNOTARY"
        Me.cboNOTARY.Size = New System.Drawing.Size(94, 21)
        Me.cboNOTARY.TabIndex = 2
        Me.cboNOTARY.Tag = "NOTARY"
        Me.cboNOTARY.ValueMember = "VALUE"
        Me.cboNOTARY.Visible = False
        '
        'ckb6
        '
        Me.ckb6.Enabled = False
        Me.ckb6.Location = New System.Drawing.Point(190, 411)
        Me.ckb6.Name = "ckb6"
        Me.ckb6.Size = New System.Drawing.Size(54, 20)
        Me.ckb6.TabIndex = 29
        Me.ckb6.Tag = "ckb6"
        Me.ckb6.Text = "ckb6"
        Me.ckb6.Visible = False
        '
        'ckb11
        '
        Me.ckb11.Location = New System.Drawing.Point(244, 411)
        Me.ckb11.Name = "ckb11"
        Me.ckb11.Size = New System.Drawing.Size(54, 20)
        Me.ckb11.TabIndex = 26
        Me.ckb11.Tag = "ckb11"
        Me.ckb11.Text = "ckb11"
        Me.ckb11.Visible = False
        '
        'ckb10
        '
        Me.ckb10.Location = New System.Drawing.Point(304, 411)
        Me.ckb10.Name = "ckb10"
        Me.ckb10.Size = New System.Drawing.Size(40, 20)
        Me.ckb10.TabIndex = 22
        Me.ckb10.Tag = "ckb10"
        Me.ckb10.Text = "ckb10"
        Me.ckb10.Visible = False
        '
        'tbcCFAUTH
        '
        Me.tbcCFAUTH.Controls.Add(Me.tpAuthInfo)
        Me.tbcCFAUTH.Controls.Add(Me.tpSign)
        Me.tbcCFAUTH.Controls.Add(Me.tpHiddenTab)
        Me.tbcCFAUTH.Location = New System.Drawing.Point(0, 56)
        Me.tbcCFAUTH.Name = "tbcCFAUTH"
        Me.tbcCFAUTH.SelectedIndex = 0
        Me.tbcCFAUTH.Size = New System.Drawing.Size(655, 346)
        Me.tbcCFAUTH.TabIndex = 3
        Me.tbcCFAUTH.Tag = "tbcCFAUTH"
        '
        'tpAuthInfo
        '
        Me.tpAuthInfo.BackColor = System.Drawing.SystemColors.Control
        Me.tpAuthInfo.Controls.Add(Me.GpAuth)
        Me.tpAuthInfo.Location = New System.Drawing.Point(4, 22)
        Me.tpAuthInfo.Name = "tpAuthInfo"
        Me.tpAuthInfo.Size = New System.Drawing.Size(647, 320)
        Me.tpAuthInfo.TabIndex = 0
        Me.tpAuthInfo.Tag = "tpAuthInfo"
        Me.tpAuthInfo.Text = "tpAuthInfo"
        '
        'tpSign
        '
        Me.tpSign.BackColor = System.Drawing.SystemColors.Control
        Me.tpSign.Controls.Add(Me.pbxSIGNATURE)
        Me.tpSign.Controls.Add(Me.btnPREVIOUS)
        Me.tpSign.Controls.Add(Me.btnNEXT)
        Me.tpSign.Controls.Add(Me.txtBROWSER)
        Me.tpSign.Controls.Add(Me.btnBROWSER)
        Me.tpSign.Location = New System.Drawing.Point(4, 22)
        Me.tpSign.Name = "tpSign"
        Me.tpSign.Size = New System.Drawing.Size(647, 320)
        Me.tpSign.TabIndex = 1
        Me.tpSign.Tag = "tpSign"
        Me.tpSign.Text = "tpSign"
        '
        'pbxSIGNATURE
        '
        Me.pbxSIGNATURE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbxSIGNATURE.InitialImage = Nothing
        Me.pbxSIGNATURE.Location = New System.Drawing.Point(4, 33)
        Me.pbxSIGNATURE.Name = "pbxSIGNATURE"
        Me.pbxSIGNATURE.Size = New System.Drawing.Size(640, 261)
        Me.pbxSIGNATURE.TabIndex = 0
        Me.pbxSIGNATURE.TabStop = False
        Me.pbxSIGNATURE.Tag = "SIGNATURE"
        '
        'btnPREVIOUS
        '
        Me.btnPREVIOUS.Location = New System.Drawing.Point(483, 4)
        Me.btnPREVIOUS.Name = "btnPREVIOUS"
        Me.btnPREVIOUS.Size = New System.Drawing.Size(74, 22)
        Me.btnPREVIOUS.TabIndex = 24
        Me.btnPREVIOUS.Tag = "btnPREVIOUS"
        Me.btnPREVIOUS.Text = "btnPREVIOUS"
        Me.btnPREVIOUS.UseVisualStyleBackColor = True
        '
        'btnNEXT
        '
        Me.btnNEXT.Location = New System.Drawing.Point(563, 4)
        Me.btnNEXT.Name = "btnNEXT"
        Me.btnNEXT.Size = New System.Drawing.Size(75, 23)
        Me.btnNEXT.TabIndex = 0
        Me.btnNEXT.Tag = "btnNEXT"
        Me.btnNEXT.Text = "btnNEXT"
        Me.btnNEXT.UseVisualStyleBackColor = True
        '
        'txtBROWSER
        '
        Me.txtBROWSER.Location = New System.Drawing.Point(84, 6)
        Me.txtBROWSER.Name = "txtBROWSER"
        Me.txtBROWSER.Size = New System.Drawing.Size(393, 21)
        Me.txtBROWSER.TabIndex = 21
        Me.txtBROWSER.Tag = "BROWSER"
        '
        'btnBROWSER
        '
        Me.btnBROWSER.Location = New System.Drawing.Point(4, 4)
        Me.btnBROWSER.Name = "btnBROWSER"
        Me.btnBROWSER.Size = New System.Drawing.Size(75, 23)
        Me.btnBROWSER.TabIndex = 22
        Me.btnBROWSER.Tag = "btnBROWSER"
        Me.btnBROWSER.Text = "btnBROWSER"
        '
        'tpHiddenTab
        '
        Me.tpHiddenTab.Controls.Add(Me.txtCFCUSTID)
        Me.tpHiddenTab.Controls.Add(Me.lblCFCUSTID)
        Me.tpHiddenTab.Controls.Add(Me.txtLINKAUTH)
        Me.tpHiddenTab.Controls.Add(Me.txtAUTOID)
        Me.tpHiddenTab.Controls.Add(Me.cboDELTD)
        Me.tpHiddenTab.Controls.Add(Me.TRANSFER)
        Me.tpHiddenTab.Location = New System.Drawing.Point(4, 22)
        Me.tpHiddenTab.Name = "tpHiddenTab"
        Me.tpHiddenTab.Size = New System.Drawing.Size(647, 320)
        Me.tpHiddenTab.TabIndex = 2
        Me.tpHiddenTab.Tag = "tpHiddenTab"
        Me.tpHiddenTab.Text = "tpHiddenTab"
        Me.tpHiddenTab.UseVisualStyleBackColor = True
        '
        'txtCFCUSTID
        '
        Me.txtCFCUSTID.Location = New System.Drawing.Point(107, 90)
        Me.txtCFCUSTID.Name = "txtCFCUSTID"
        Me.txtCFCUSTID.Size = New System.Drawing.Size(100, 21)
        Me.txtCFCUSTID.TabIndex = 38
        Me.txtCFCUSTID.Tag = "CFCUSTID"
        '
        'lblCFCUSTID
        '
        Me.lblCFCUSTID.Location = New System.Drawing.Point(8, 90)
        Me.lblCFCUSTID.Name = "lblCFCUSTID"
        Me.lblCFCUSTID.Size = New System.Drawing.Size(93, 21)
        Me.lblCFCUSTID.TabIndex = 37
        Me.lblCFCUSTID.Tag = "CFCUSTID"
        Me.lblCFCUSTID.Text = "lblCFCUSTID"
        '
        'txtLINKAUTH
        '
        Me.txtLINKAUTH.Location = New System.Drawing.Point(145, 159)
        Me.txtLINKAUTH.Name = "txtLINKAUTH"
        Me.txtLINKAUTH.Size = New System.Drawing.Size(77, 21)
        Me.txtLINKAUTH.TabIndex = 36
        Me.txtLINKAUTH.Tag = "LINKAUTH"
        Me.txtLINKAUTH.Text = "txtLINKAUTH"
        '
        'txtAUTOID
        '
        Me.txtAUTOID.Location = New System.Drawing.Point(234, 159)
        Me.txtAUTOID.Name = "txtAUTOID"
        Me.txtAUTOID.Size = New System.Drawing.Size(63, 21)
        Me.txtAUTOID.TabIndex = 34
        Me.txtAUTOID.Tag = "AUTOID"
        Me.txtAUTOID.Text = "txtAUTOID"
        '
        'cboDELTD
        '
        Me.cboDELTD.DisplayMember = "DISPLAY"
        Me.cboDELTD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDELTD.Location = New System.Drawing.Point(304, 160)
        Me.cboDELTD.Name = "cboDELTD"
        Me.cboDELTD.Size = New System.Drawing.Size(132, 21)
        Me.cboDELTD.TabIndex = 35
        Me.cboDELTD.Tag = "DELTD"
        Me.cboDELTD.ValueMember = "VALUE"
        '
        'TRANSFER
        '
        Me.TRANSFER.Controls.Add(Me.cboBANKNAME)
        Me.TRANSFER.Controls.Add(Me.lblBANKNAME)
        Me.TRANSFER.Controls.Add(Me.txtACCOUNTNAME)
        Me.TRANSFER.Controls.Add(Me.lblACCOUNTNAME)
        Me.TRANSFER.Controls.Add(Me.txtBANKACCOUNT)
        Me.TRANSFER.Controls.Add(Me.lblBANKACCOUNT)
        Me.TRANSFER.Location = New System.Drawing.Point(3, 3)
        Me.TRANSFER.Name = "TRANSFER"
        Me.TRANSFER.Size = New System.Drawing.Size(548, 68)
        Me.TRANSFER.TabIndex = 33
        Me.TRANSFER.TabStop = False
        Me.TRANSFER.Tag = "TRANSFER"
        Me.TRANSFER.Text = "TRANSFER"
        '
        'cboBANKNAME
        '
        Me.cboBANKNAME.DisplayMember = "DISPLAY"
        Me.cboBANKNAME.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBANKNAME.Location = New System.Drawing.Point(392, 41)
        Me.cboBANKNAME.Name = "cboBANKNAME"
        Me.cboBANKNAME.Size = New System.Drawing.Size(148, 21)
        Me.cboBANKNAME.TabIndex = 29
        Me.cboBANKNAME.Tag = "BANKNAME"
        Me.cboBANKNAME.ValueMember = "VALUE"
        '
        'lblBANKNAME
        '
        Me.lblBANKNAME.Location = New System.Drawing.Point(276, 41)
        Me.lblBANKNAME.Name = "lblBANKNAME"
        Me.lblBANKNAME.Size = New System.Drawing.Size(100, 21)
        Me.lblBANKNAME.TabIndex = 31
        Me.lblBANKNAME.Tag = "BANKNAME"
        Me.lblBANKNAME.Text = "lblBANKNAME"
        Me.lblBANKNAME.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtACCOUNTNAME
        '
        Me.txtACCOUNTNAME.Location = New System.Drawing.Point(224, 15)
        Me.txtACCOUNTNAME.Name = "txtACCOUNTNAME"
        Me.txtACCOUNTNAME.Size = New System.Drawing.Size(316, 21)
        Me.txtACCOUNTNAME.TabIndex = 24
        Me.txtACCOUNTNAME.Tag = "ACCOUNTNAME"
        Me.txtACCOUNTNAME.Text = "txtACCOUNTNAME"
        '
        'lblACCOUNTNAME
        '
        Me.lblACCOUNTNAME.Location = New System.Drawing.Point(116, 15)
        Me.lblACCOUNTNAME.Name = "lblACCOUNTNAME"
        Me.lblACCOUNTNAME.Size = New System.Drawing.Size(100, 21)
        Me.lblACCOUNTNAME.TabIndex = 25
        Me.lblACCOUNTNAME.Tag = "ACCOUNTNAME"
        Me.lblACCOUNTNAME.Text = "lblACCOUNTNAME"
        '
        'txtBANKACCOUNT
        '
        Me.txtBANKACCOUNT.Location = New System.Drawing.Point(116, 41)
        Me.txtBANKACCOUNT.MaxLength = 20
        Me.txtBANKACCOUNT.Name = "txtBANKACCOUNT"
        Me.txtBANKACCOUNT.Size = New System.Drawing.Size(148, 21)
        Me.txtBANKACCOUNT.TabIndex = 28
        Me.txtBANKACCOUNT.Tag = "BANKACCOUNT"
        Me.txtBANKACCOUNT.Text = "txtBANKACCOUNT"
        '
        'lblBANKACCOUNT
        '
        Me.lblBANKACCOUNT.Location = New System.Drawing.Point(4, 41)
        Me.lblBANKACCOUNT.Name = "lblBANKACCOUNT"
        Me.lblBANKACCOUNT.Size = New System.Drawing.Size(92, 21)
        Me.lblBANKACCOUNT.TabIndex = 30
        Me.lblBANKACCOUNT.Tag = "BANKACCOUNT"
        Me.lblBANKACCOUNT.Text = "lblBANKACCOUNT"
        Me.lblBANKACCOUNT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TabControlHide
        '
        Me.TabControlHide.Controls.Add(Me.TabPage1)
        Me.TabControlHide.Controls.Add(Me.TabPage2)
        Me.TabControlHide.Location = New System.Drawing.Point(12, 407)
        Me.TabControlHide.Name = "TabControlHide"
        Me.TabControlHide.SelectedIndex = 0
        Me.TabControlHide.Size = New System.Drawing.Size(200, 23)
        Me.TabControlHide.TabIndex = 15
        Me.TabControlHide.Visible = False
        '
        'TabPage1
        '
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(192, 0)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(192, 0)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
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
        'DataTable1
        '
        Me.DataTable1.Namespace = ""
        Me.DataTable1.TableName = "COMBOBOX"
        '
        'DataTable11
        '
        Me.DataTable11.Namespace = ""
        Me.DataTable11.TableName = "COMBOBOX"
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
        'DataTable29
        '
        Me.DataTable29.Namespace = ""
        Me.DataTable29.TableName = "COMBOBOX"
        '
        'DataTable4
        '
        Me.DataTable4.Namespace = ""
        Me.DataTable4.TableName = "COMBOBOX"
        '
        'DataTable39
        '
        Me.DataTable39.Namespace = ""
        Me.DataTable39.TableName = "COMBOBOX"
        '
        'DataTable42
        '
        Me.DataTable42.Namespace = ""
        Me.DataTable42.TableName = "COMBOBOX"
        '
        'lblTITLE
        '
        Me.lblTITLE.Location = New System.Drawing.Point(434, 16)
        Me.lblTITLE.Name = "lblTITLE"
        Me.lblTITLE.Size = New System.Drawing.Size(78, 21)
        Me.lblTITLE.TabIndex = 180
        Me.lblTITLE.Tag = "TITLE"
        Me.lblTITLE.Text = "Label1"
        '
        'DataTable58
        '
        Me.DataTable58.Namespace = ""
        Me.DataTable58.TableName = "COMBOBOX"
        '
        'txtTITLE
        '
        Me.txtTITLE.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtTITLE.Location = New System.Drawing.Point(491, 13)
        Me.txtTITLE.Name = "txtTITLE"
        Me.txtTITLE.Size = New System.Drawing.Size(144, 21)
        Me.txtTITLE.TabIndex = 181
        Me.txtTITLE.Tag = "TITLE"
        Me.txtTITLE.Text = "TextBox1"
        '
        'frmCFAUTH
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(656, 436)
        Me.Controls.Add(Me.TabControlHide)
        Me.Controls.Add(Me.tbcCFAUTH)
        Me.Controls.Add(Me.ckb6)
        Me.Controls.Add(Me.ckb10)
        Me.Controls.Add(Me.ckb11)
        Me.Controls.Add(Me.cboNOTARY)
        Me.Name = "frmCFAUTH"
        Me.Text = "frmCFAUTH"
        Me.Controls.SetChildIndex(Me.cboNOTARY, 0)
        Me.Controls.SetChildIndex(Me.ckb11, 0)
        Me.Controls.SetChildIndex(Me.ckb10, 0)
        Me.Controls.SetChildIndex(Me.ckb6, 0)
        Me.Controls.SetChildIndex(Me.btnApprv, 0)
        Me.Controls.SetChildIndex(Me.btnApply, 0)
        Me.Controls.SetChildIndex(Me.cboLink, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.tbcCFAUTH, 0)
        Me.Controls.SetChildIndex(Me.TabControlHide, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GpAuth.ResumeLayout(False)
        Me.GpAuth.PerformLayout()
        Me.tbcCFAUTH.ResumeLayout(False)
        Me.tpAuthInfo.ResumeLayout(False)
        Me.tpSign.ResumeLayout(False)
        Me.tpSign.PerformLayout()
        CType(Me.pbxSIGNATURE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpHiddenTab.ResumeLayout(False)
        Me.tpHiddenTab.PerformLayout()
        Me.TRANSFER.ResumeLayout(False)
        Me.TRANSFER.PerformLayout()
        Me.TabControlHide.ResumeLayout(False)
        CType(Me.DataTable6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable29, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable39, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable42, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable58, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Declare constants and variables "
    Private mv_CustAuthID As String
    Private mv_lngFileSize As Long
    Private mv_linkauth As String
    Private mv_ImageViewer As New ImageViewer
    Private mv_orgcustid As String
    Private mv_arrSIGNATURE As String()
    Private mv_currIdx As Integer = 0
    Private mv_idxNumOfSign As Integer = 0
    Private mv_idcode As String
    Private mv_content As String
#End Region

#Region " Properties "
    Public Property CustAUTHID() As String
        Get
            Return mv_CustAuthID
        End Get
        Set(ByVal Value As String)
            mv_CustAuthID = Value
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
        TabControlHide.TabPages.Add(tpHiddenTab)
        tbcCFAUTH.TabPages.Remove(tpHiddenTab)
        Me.lblSHV.ForeColor = Color.Blue
        Me.txtCFCUSTID.Text = Me.CustAUTHID
        Me.lblEMAIL.ForeColor = Me.lblSHV.ForeColor
        Try
            MyBase.OnInit()

            'Load Resource Manager
            ResourceManager = New Resources.ResourceManager(gc_RootNamespace & "." & Me.Name & "-" & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
            LoadUserInterface(Me)
            LoadLinkAuth()
            Me.txtACCOUNTNAME.Enabled = False
            Me.txtBANKACCOUNT.Enabled = False
            Me.txtCFCUSTID.Enabled = True
            Me.cboBANKNAME.Enabled = False
            If ExeFlag = ExecuteFlag.Edit Or ExeFlag = ExecuteFlag.View Then
                LoadCFSign(KeyFieldValue.ToString())
                'Me.pnSignatures.Controls.Clear()
                'Me.pnSignatures.Controls.Add(mv_ImageViewer)
                'mv_ImageViewer.Dock = DockStyle.Fill
                getCustInfoByKey()
            End If

            If Me.ckb7.Checked = True Then
                Me.txtACCOUNTNAME.Enabled = True
                Me.txtBANKACCOUNT.Enabled = True
                Me.cboBANKNAME.Enabled = True
            Else
                Me.txtACCOUNTNAME.Enabled = False
                Me.txtBANKACCOUNT.Enabled = False
                Me.cboBANKNAME.Enabled = False
            End If
            'longnh
            If cboAUTHLIMIT.SelectedValue = "Y" Then
                dtpVALDATE.Enabled = True
                dtpEXPDATE.Enabled = True
            Else
                'dtpVALDATE.Enabled = False
                dtpEXPDATE.Enabled = False
            End If

            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_int, v_intCount, i, j As Integer
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_strlinkauth As String
            Dim v_strFLDNAME, v_strVALUE As String
            Dim arrcflink As String()
            ReDim arrcflink(11)
            For i = 0 To 10
                arrcflink(i) = "N"
            Next
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ResourceManager.GetString("InitDialogFailed"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub


    Private Function CheckValidDate() As Long
        'Chi cho truong hop add new con edit thi chi check expdate > valdate la duoc 
        If Me.dtpEXPDATE.Value.ToString("DD/MM/YYYY") < Me.BusDate Then
            Return 1
        ElseIf Me.dtpVALDATE.Value.ToString("DD/MM/YYYY") < Me.BusDate Then
            Return 2
        End If
    End Function

    Public Overrides Sub OnSave()

        Dim v_strObjMsg, v_strTxMsg, v_strSQL, v_strCOUNT As String
        Dim v_xmlDocument As New XmlDocument
        Dim v_txDocument As New XmlDocument
        Dim v_objDataNode, v_entryNode As XmlNode
        Dim v_dataElement As XmlElement
        Dim v_nodeList As XmlNodeList
        Dim v_attrFLDNAME, v_attrDATATYPE, v_attrDEFNAME As XmlAttribute
        Dim v_strValue, v_strFLDNAME, v_strDATATYPE, v_strDEFNAME As String
        Dim i, j As Integer
        Try
            'Update mouse pointer
            Cursor.Current = Cursors.WaitCursor
            SetLinkAuth()


            If CInt(mv_lngFileSize / 1024) > 22 Then
                MsgBox(ResourceManager.GetString("INVALIDFILESIZE"), MsgBoxStyle.Critical, gc_ApplicationTitle)
                Exit Sub
            End If

            MyBase.OnSave()
            If Not DoDataExchange(True) Then
                Exit Sub
            End If

            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_strErrorSource, v_strErrorMessage As String
            'PhuongHT: check mv_linkauth không được bằng 'NNNNNNNNNN'
            'THUNT-2019-10-08: KIỂM TRA NGƯỜI ĐƯỢC ỦY QUYỀN CÓ PHẢI SHV
            If txtLICENSENO.Text Is Nothing Then
                MsgBox(ResourceManager.GetString("ERR_IDCODE_NULL"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                Exit Sub
            End If
            v_strSQL = "Select count(*) RESULT from CFAUTH AU , CFMAST CF where CF.CUSTID=AU.CFCUSTID AND AU.LICENSENO='" & txtLICENSENO.Text & "'"
            v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, "CF.CFMAST", gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strValue = .InnerText.ToString()

                    Select Case Trim(v_strFLDNAME)
                        Case "RESULT"
                            v_strCOUNT = Trim(v_strValue)
                    End Select
                End With
            Next

            'If v_strCOUNT <> 0 And cboSHV.SelectedValue.ToString <> "Y" Or v_strCOUNT = 0 And cboSHV.SelectedValue.ToString <> "N" Then
            '    MsgBox(ResourceManager.GetString("ERR_CF_CFAUTH_SHV"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            '    Exit Sub
            'End If

            'SetLinkAuth()
            If (mv_linkauth = "NNNNNNNNNNN") Then
                MsgBox(ResourceManager.GetString("ERR_CF_CFAUTH_NULL"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                Exit Sub
            End If
            Select Case ExeFlag
                Case ExecuteFlag.AddNew

                    Select Case CheckValidDate()
                        Case 1
                            MsgBox(ResourceManager.GetString("ERR_EXPRISEDDATE_INVALID"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                            Exit Sub
                        Case 2
                            MsgBox(ResourceManager.GetString("ERR_VALDATE_INVALID"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                            Exit Sub
                    End Select
                    'Call webservice
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionAdd, , , , gc_AutoIdUsed, , , , , , ParentObjName, ParentClause)
                    BuildXMLObjData(mv_dsInput, v_strObjMsg)

                    Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)
                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)




                    If v_lngErrorCode <> 0 Then
                        'Update mouse pointer
                        Cursor.Current = Cursors.Default
                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Exit Sub
                    End If
                    'UpdateLinkAuth()
                    MsgBox(ResourceManager.GetString("EditSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    Me.DialogResult = DialogResult.OK
                    MyBase.OnClose()
                Case ExecuteFlag.Edit
                    Dim v_strClause As String

                    Select Case KeyFieldType
                        Case "C"
                            v_strClause = KeyFieldName & " = '" & KeyFieldValue & "'"
                        Case "D"
                            v_strClause = KeyFieldName & " = TO_DATE('" & KeyFieldValue & "', '" & gc_FORMAT_DATE & "')"
                        Case "N"
                            v_strClause = KeyFieldName & " = " & KeyFieldValue.ToString()
                    End Select

                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionEdit, , v_strClause, , , , , , , , ParentObjName, ParentClause)
                    BuildXMLObjData(mv_dsInput, v_strObjMsg, mv_dsOldInput, ExecuteFlag.Edit)

                    'Ki?m tra thông tin và x? lý l?i (n?u có) t? message tr? v?
                    Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)
                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)

                    If v_lngErrorCode <> 0 Then
                        'Update mouse pointer
                        Cursor.Current = Cursors.Default
                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Exit Sub
                    End If

                    'UpdateLinkAuth()

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
        MyBase.LoadUserInterface(pv_ctrl)


        'S?a ch? này cho t?ng form maintenance khác nhau
        If ExeFlag = ExecuteFlag.Edit Or ExeFlag = ExecuteFlag.View Then
            FillCheckBoxValue()
        End If
        If (ExeFlag = ExecuteFlag.AddNew) Then
            Me.txtCFCUSTID.Text = CustAUTHID
            Me.cboDELTD.SelectedValue = "N"
            'EDIT 18/12

            txtCFCUSTID.Enabled = True
            Me.dtpEXPDATE.Value = DateAdd(DateInterval.Year, 10, dtpVALDATE.Value)
        ElseIf (ExeFlag = ExecuteFlag.Edit) Then
            'Me.txtCUSTID.Enabled = False
            If Not txtCFCUSTID.Text.Length > 0 Then
                txtFULLNAME.Enabled = True
                txtADDRESS.Enabled = True
                txtTELEPHONE.Enabled = True
                txtEMAIL.Enabled = True
                txtLNPLACE.Enabled = True
                txtLICENSENO.Enabled = True
                dtpLNIDDATE.Enabled = True
                'Else
                '    txtFULLNAME.Enabled = False
                '    txtADDRESS.Enabled = False
                '    txtTELEPHONE.Enabled = False
                '    txtEMAIL.Enabled = False
                '    txtLNPLACE.Enabled = False
                '    txtLICENSENO.Enabled = False
                '    dtpLNIDDATE.Enabled = False
            End If
        End If
        If ExeFlag = ExecuteFlag.Edit Then
            Me.dtpEXPDATE.Enabled = True
            Me.dtpVALDATE.Enabled = True
        End If
        Me.cboDELTD.Visible = False
    End Sub
    Private Sub FillCheckBoxValue()
        Try
            If ExeFlag = ExecuteFlag.View Or ExeFlag = ExecuteFlag.Edit Then
                Dim v_xmlDocument As New Xml.XmlDocument
                Dim v_nodeList As Xml.XmlNodeList
                Dim v_int, v_intCount, i As Integer
                Dim v_strCDCONTENT As String
                Dim v_strFLDNAME, v_strVALUE As String
                Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                Dim v_strlinkauth As String

                v_strlinkauth = txtLINKAUTH.Text
                Dim arrcflink As String()
                ReDim arrcflink(15)
                For i = 0 To 15
                    arrcflink(i) = Mid(v_strlinkauth, i + 1, 1)
                Next
                If arrcflink(0) = "N" Then
                    Me.ckb1.Checked = False
                Else
                    Me.ckb1.Checked = True

                End If
                If arrcflink(1) = "N" Then
                    Me.ckb2.Checked = False
                Else
                    Me.ckb2.Checked = True
                End If
                If arrcflink(2) = "N" Then
                    Me.ckb3.Checked = False
                Else
                    Me.ckb3.Checked = True
                End If
                If arrcflink(3) = "N" Then
                    Me.ckb4.Checked = False
                Else
                    Me.ckb4.Checked = True
                End If
                If arrcflink(4) = "N" Then
                    Me.ckb5.Checked = False
                Else
                    Me.ckb5.Checked = True
                End If
                If arrcflink(5) = "N" Then
                    Me.ckb6.Checked = False
                Else
                    Me.ckb6.Checked = True
                End If
                If arrcflink(6) = "N" Then
                    Me.ckb7.Checked = False
                Else
                    Me.ckb7.Checked = True
                End If
                If arrcflink(7) = "N" Then
                    Me.ckb8.Checked = False
                Else
                    Me.ckb8.Checked = True
                End If
                If arrcflink(8) = "N" Then
                    Me.ckb9.Checked = False
                Else
                    Me.ckb9.Checked = True
                End If
                If arrcflink(9) = "N" Then
                    Me.ckb10.Checked = False
                Else
                    Me.ckb10.Checked = True

                End If

                If arrcflink(10) = "N" Then
                    Me.ckb11.Checked = False
                Else
                    Me.ckb11.Checked = True

                End If

                If arrcflink(11) = "N" Then
                    Me.ckb12.Checked = False
                Else
                    Me.ckb12.Checked = True

                End If

                If arrcflink(12) = "N" Then
                    Me.ckb13.Checked = False
                Else
                    Me.ckb13.Checked = True

                End If
                'thunt-2019-09-19
                If arrcflink(13) = "N" Then
                    Me.ckb14.Checked = False
                Else
                    Me.ckb14.Checked = True

                End If
                If arrcflink(14) = "N" Then
                    Me.ckb15.Checked = False
                Else
                    Me.ckb15.Checked = True

                End If
                If arrcflink(15) = "N" Then
                    Me.ckb16.Checked = False
                Else
                    Me.ckb16.Checked = True

                End If
                If ExeFlag = ExecuteFlag.View Then
                    Me.ckb1.Enabled = False
                    Me.ckb2.Enabled = False
                    Me.ckb3.Enabled = False
                    Me.ckb4.Enabled = False
                    Me.ckb5.Enabled = False
                    Me.ckb6.Enabled = False
                    Me.ckb7.Enabled = False
                    Me.ckb8.Enabled = False
                    Me.ckb9.Enabled = False
                    Me.ckb10.Enabled = False
                    Me.ckb11.Enabled = False
                    Me.ckb12.Enabled = False
                    Me.ckb13.Enabled = False
                    Me.ckb14.Enabled = False
                    Me.ckb15.Enabled = False
                    Me.ckb16.Enabled = False
                    Me.ckbALL.Enabled = False
                End If
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                                     & "Error code: System error!" & vbNewLine _
                                     & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try

    End Sub
    Private Sub LoadLinkAuth()
        Try
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_int, v_intCount As Integer
            Dim v_strCDCONTENT As String
            Dim v_strFLDNAME, v_strVALUE As String
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_strAuth() As String
            ReDim v_strAuth(15)
            Dim v_strCmdInquiry As String = "SELECT CDCONTENT,EN_CDCONTENT FROM ALLCODE WHERE CDTYPE ='CF' AND CDNAME = 'LINKAUTH' ORDER BY LSTODR  "
            Dim v_strObjMsg As String = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_ALLCODE, gc_ActionInquiry, v_strCmdInquiry)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For v_intCount = 0 To v_nodeList.Count - 1
                For v_int = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                    With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                        v_strFLDNAME = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("fldname").Value.Trim()
                        v_strVALUE = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("oldval").Value.Trim()

                        Select Case v_strFLDNAME
                            Case "CDCONTENT", "EN_CDCONTENT"
                                If Me.UserLanguage = "EN" And Trim(v_strFLDNAME) = "EN_CDCONTENT" Then
                                    v_strAuth(v_intCount) = v_strVALUE
                                ElseIf Me.UserLanguage = "VN" And Trim(v_strFLDNAME) = "CDCONTENT" Then
                                    v_strAuth(v_intCount) = v_strVALUE
                                End If
                        End Select
                    End With
                Next
            Next
            Me.ckb1.Text = v_strAuth(0)
            Me.ckb2.Text = v_strAuth(1)
            Me.ckb3.Text = v_strAuth(2)
            Me.ckb4.Text = v_strAuth(3)
            Me.ckb5.Text = v_strAuth(4)
            Me.ckb6.Text = v_strAuth(5)
            Me.ckb7.Text = v_strAuth(6)
            Me.ckb8.Text = v_strAuth(7)
            Me.ckb9.Text = v_strAuth(8)
            Me.ckb10.Text = v_strAuth(9)
            Me.ckb11.Text = v_strAuth(10)
            Me.ckb12.Text = v_strAuth(11)
            Me.ckb13.Text = v_strAuth(12)
            Me.ckb14.Text = v_strAuth(13)
            Me.ckb15.Text = v_strAuth(14)
            Me.ckb16.Text = v_strAuth(15)
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub
    Private Sub SetLinkAuth()
        Dim str_linkauth As String
        If Me.ckb1.Checked = True Then
            str_linkauth = str_linkauth & "Y"
        Else
            str_linkauth = str_linkauth & "N"
        End If
        If Me.ckb2.Checked = True Then
            str_linkauth = str_linkauth & "Y"
        Else
            str_linkauth = str_linkauth & "N"
        End If
        If Me.ckb3.Checked = True Then
            str_linkauth = str_linkauth & "Y"
        Else
            str_linkauth = str_linkauth & "N"
        End If
        If Me.ckb4.Checked = True Then
            str_linkauth = str_linkauth & "Y"
        Else
            str_linkauth = str_linkauth & "N"
        End If
        If Me.ckb5.Checked = True Then
            str_linkauth = str_linkauth & "Y"
        Else
            str_linkauth = str_linkauth & "N"
        End If
        If Me.ckb6.Checked = True Then
            str_linkauth = str_linkauth & "Y"
        Else
            str_linkauth = str_linkauth & "N"
        End If
        If Me.ckb7.Checked = True Then
            str_linkauth = str_linkauth & "Y"
        Else
            str_linkauth = str_linkauth & "N"
        End If
        If Me.ckb8.Checked = True Then
            str_linkauth = str_linkauth & "Y"
        Else
            str_linkauth = str_linkauth & "N"
        End If
        If Me.ckb9.Checked = True Then
            str_linkauth = str_linkauth & "Y"
        Else
            str_linkauth = str_linkauth & "N"
        End If
        If Me.ckb10.Checked = True Then
            str_linkauth = str_linkauth & "Y"
        Else
            str_linkauth = str_linkauth & "N"
        End If
        If Me.ckb11.Checked = True Then
            str_linkauth = str_linkauth & "Y"
        Else
            str_linkauth = str_linkauth & "N"
        End If

        If Me.ckb12.Checked = True Then
            str_linkauth = str_linkauth & "Y"
        Else
            str_linkauth = str_linkauth & "N"
        End If
        If Me.ckb13.Checked = True Then
            str_linkauth = str_linkauth & "Y"
        Else
            str_linkauth = str_linkauth & "N"
        End If
        'thunt-2019-19-09
        If Me.ckb14.Checked = True Then
            str_linkauth = str_linkauth & "Y"
        Else
            str_linkauth = str_linkauth & "N"
        End If

        If Me.ckb15.Checked = True Then
            str_linkauth = str_linkauth & "Y"
        Else
            str_linkauth = str_linkauth & "N"
        End If

        If Me.ckb16.Checked = True Then
            str_linkauth = str_linkauth & "Y"
        Else
            str_linkauth = str_linkauth & "N"
        End If
        mv_linkauth = str_linkauth
        txtLINKAUTH.Text = str_linkauth
    End Sub
    Private Sub UpdateLinkAuth()
        Try
            'Lay autoid neu la addnew

            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_strSQL, v_strObjMsg, v_strValue, v_strFLDNAME, v_strClause, v_strAUTOID As String
            SetLinkAuth()
            If (ExeFlag = ExecuteFlag.AddNew) Then
                v_strSQL = "SELECT MAX(AUTOID) AUTOID FROM CFAUTH WHERE CFCUSTID='" & Trim(Me.txtCFCUSTID.Text) & "'"
                v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                For i As Integer = 0 To v_nodeList.Count - 1
                    For j As Integer = 0 To v_nodeList.Item(j).ChildNodes.Count - 1
                        With v_nodeList.Item(j).ChildNodes(i)
                            v_strFLDNAME = v_nodeList.Item(j).ChildNodes(i).Attributes.GetNamedItem("fldname").Value.Trim()
                            v_strValue = v_nodeList.Item(j).ChildNodes(i).Attributes.GetNamedItem("oldval").Value.Trim()
                            Select Case v_strFLDNAME
                                Case "AUTOID"
                                    v_strAUTOID = v_strValue
                            End Select
                        End With
                    Next
                Next
            Else
                v_strAUTOID = Trim(Me.txtAUTOID.Text)
            End If

            'Cập nhật không cho phép gửi thẳng lệnh SQL
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFAUTH, gc_ActionAdhoc, , v_strAUTOID, , , , mv_linkauth)
            v_ws.Message(v_strObjMsg)
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                                    & "Error code: System error!" & vbNewLine _
                                    & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ResourceManager.GetString("SavingFailed"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub getCustInfoByLicenseNO()
        If txtLICENSENO.Text <> "" Then
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_int, v_intCount As Integer
            Dim v_strFULLNAME, v_strIDCODE, v_strPHONE, v_strEMAIL As String
            Dim v_strFLDNAME, v_strVALUE, v_strADDRESS, v_strIDDATE, v_strIDEXPIRED, v_strCUSTID As String
            Dim v_strIDPLACE As String
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery

            Dim v_strCmdInquiry As String = "Select CUSTID, FULLNAME,IDCODE,ADDRESS,MOBILESMS,EMAIL,IDDATE,IDEXPIRED,IDPLACE  from CFMAST WHERE IDCODE ='" & txtLICENSENO.Text & "' " 'And STATUS = 'A'" SHBVNEX-1499
            Dim v_strObjMsg As String = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, "SA.ALLCODE", gc_ActionInquiry, v_strCmdInquiry)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            If v_nodeList.Count = 0 Then 'trung.luu: SHBVNEX-1499 licenseno thuoc cfauth khong thuoc cfmast
                v_strCmdInquiry = "Select '' CUSTID, FULLNAME,licenseno IDCODE,ADDRESS,telephone MOBILESMS,EMAIL,lniddate IDDATE,lnidexpdate IDEXPIRED,lnplace IDPLACE  from cfauth WHERE licenseno ='" & txtLICENSENO.Text & "' " 'And STATUS = 'A'" SHBVNEX-1499
                v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, "SA.ALLCODE", gc_ActionInquiry, v_strCmdInquiry)
                v_ws.Message(v_strObjMsg)
                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            End If
            If v_nodeList.Count > 0 Then
                For v_intCount = 0 To v_nodeList.Count - 1
                    For v_int = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                        With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                            v_strFLDNAME = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("fldname").Value.Trim()
                            v_strVALUE = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("oldval").Value.Trim()

                            Select Case v_strFLDNAME
                                Case "CUSTID"
                                    v_strCUSTID = v_strVALUE
                                Case "FULLNAME"
                                    v_strFULLNAME = v_strVALUE
                                Case "ADDRESS"
                                    v_strADDRESS = v_strVALUE
                                Case "IDCODE"
                                    v_strIDCODE = v_strVALUE
                                Case "MOBILESMS"
                                    v_strPHONE = v_strVALUE
                                Case "EMAIL"
                                    v_strEMAIL = v_strVALUE
                                Case "IDDATE"
                                    dtpLNIDDATE.Text = v_strVALUE
                                Case "IDEXPIRED"
                                    v_strIDEXPIRED = v_strVALUE
                                Case "IDPLACE"
                                    v_strIDPLACE = v_strVALUE
                            End Select
                        End With
                    Next
                Next
                txtFULLNAME.Text = v_strFULLNAME
                txtADDRESS.Text = v_strADDRESS
                txtLICENSENO.Text = v_strIDCODE
                txtTELEPHONE.Text = v_strPHONE
                txtEMAIL.Text = v_strEMAIL
                txtLNPLACE.Text = v_strIDPLACE
                'dtpLNIDDATE.Text = v_strIDDATE
                txtCUSTID.Text = v_strCUSTID
                mv_idcode = v_strIDCODE
            End If
        End If
    End Sub

    Private Sub getCustInfoByKey()
        If KeyFieldValue <> "" Then
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_int, v_intCount As Integer
            Dim v_strFULLNAME, v_strIDCODE, v_strPHONE, v_strSHV, v_strEMAIL As String
            Dim v_strFLDNAME, v_strVALUE, v_strADDRESS, v_strIDDATE, v_strIDEXPIRED, v_strCUSTID As String
            Dim v_strIDPLACE As String
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery

            Dim v_strCmdInquiry As String = "Select AU.CUSTID, case when nvl(AU.CUSTID,'XXX') <> 'XXX' then CF.FULLNAME else AU.FULLNAME end FULLNAME, " & ControlChars.CrLf _
                                        & "case when nvl(AU.CUSTID,'XXX') <> 'XXX' then CF.IDCODE else AU.licenseno end IDCODE, " & ControlChars.CrLf _
                                        & "case when nvl(AU.CUSTID,'XXX') <> 'XXX' then CF.ADDRESS else AU.ADDRESS end ADDRESS, " & ControlChars.CrLf _
                                        & "case when nvl(AU.CUSTID,'XXX') <> 'XXX' then CF.MOBILESMS else AU.telephone end MOBILE, " & ControlChars.CrLf _
                                        & "case when nvl(AU.CUSTID,'XXX') <> 'XXX' then CF.EMAIL else AU.EMAIL end EMAIL, " & ControlChars.CrLf _
                                        & "case when nvl(AU.CUSTID,'XXX') <> 'XXX' then CF.IDDATE else AU.lniddate end IDDATE, " & ControlChars.CrLf _
                                        & "case when nvl(AU.CUSTID,'XXX') <> 'XXX' then CF.IDPLACE else AU.lnplace end IDPLACE, " & ControlChars.CrLf _
                                        & "to_char(valdate,'DD/MM/RRRR') valdate, to_char(expdate,'DD/MM/RRRR') expdate , AU.SHV " & ControlChars.CrLf _
                                        & "from CFAUTH AU, CFMAST CF, ALLCODE AL WHERE AL.CDVAL = AU.SHV and AL.CDNAME='YESNO' and AL.CDTYPE='SY' and AU.AUTOID ='" & KeyFieldValue & "' and AU.custid = cf.custid(+) "
            Dim v_strObjMsg As String = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, "SA.ALLCODE", gc_ActionInquiry, v_strCmdInquiry)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            If v_nodeList.Count > 0 Then
                For v_intCount = 0 To v_nodeList.Count - 1
                    For v_int = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                        With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                            v_strFLDNAME = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("fldname").Value.Trim()
                            v_strVALUE = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("oldval").Value.Trim()

                            Select Case v_strFLDNAME
                                Case "CUSTID"
                                    v_strCUSTID = v_strVALUE
                                Case "FULLNAME"
                                    v_strFULLNAME = v_strVALUE
                                Case "ADDRESS"
                                    v_strADDRESS = v_strVALUE
                                Case "IDCODE"
                                    v_strIDCODE = v_strVALUE
                                Case "MOBILE"
                                    v_strPHONE = v_strVALUE
                                Case "EMAIL"
                                    v_strEMAIL = v_strVALUE
                                Case "IDDATE"
                                    dtpLNIDDATE.Text = v_strVALUE
                                Case "IDEXPIRED"
                                    v_strIDEXPIRED = v_strVALUE
                                Case "IDPLACE"
                                    v_strIDPLACE = v_strVALUE
                                Case "VALDATE"
                                    dtpVALDATE.Text = v_strVALUE
                                Case "EXPDATE"
                                    dtpEXPDATE.Text = v_strVALUE
                                Case "SHV"
                                    v_strSHV = v_strVALUE
                            End Select
                        End With
                    Next
                Next

                txtFULLNAME.Text = v_strFULLNAME
                txtADDRESS.Text = v_strADDRESS
                txtLICENSENO.Text = v_strIDCODE
                txtTELEPHONE.Text = v_strPHONE
                txtEMAIL.Text = v_strEMAIL
                txtLNPLACE.Text = v_strIDPLACE
                ' dtpLNIDDATE.Text = v_strIDDATE
                txtCUSTID.Text = v_strCUSTID
                txtFULLNAME.Enabled = False
                txtADDRESS.Enabled = False
                txtTELEPHONE.Enabled = False
                txtEMAIL.Enabled = False
                txtLNPLACE.Enabled = False
                dtpLNIDDATE.Enabled = False
            End If

        End If
    End Sub

    'Private Sub getSHV()
    '    Dim v_xmlDocument As New Xml.XmlDocument
    '    Dim v_nodeList As Xml.XmlNodeList
    '    Dim v_int, v_intCount As Integer
    '    Dim v_strFULLNAME, v_strIDCODE, v_strPHONE As String
    '    Dim v_strFLDNAME, v_strVALUE, v_strADDRESS, v_strIDDATE, v_strIDEXPIRED, v_strCUSTID As String
    '    Dim v_strIDPLACE As String
    '    Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery

    '    Dim v_strCmdInquiry As String = "Select CDVAL VALUECD, CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY from ALLCODE WHERE cdname = 'YESNO' AND cdtype = 'SY'"
    '    Dim v_strObjMsg As String = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, "SA.ALLCODE", gc_ActionInquiry, v_strCmdInquiry)
    '    v_ws.Message(v_strObjMsg)
    '    Me.cboSHV.Clears()
    '    FillComboEx(v_strObjMsg, Me.cboSHV, "", Me.UserLanguage)

    'End Sub

    Private Sub getCustInfoByCustID()
        If txtCUSTID.Text <> "" Then
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_int, v_intCount As Integer
            Dim v_strFULLNAME, v_strIDCODE, v_strPHONE, v_strEMAIL As String
            Dim v_strFLDNAME, v_strVALUE, v_strADDRESS, v_strIDDATE, v_strIDEXPIRED, v_strCUSTID As String
            Dim v_strIDPLACE As String
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            v_strCUSTID = txtCUSTID.Text.Replace(".", "")
            Dim v_strCmdInquiry As String = "Select CUSTID, FULLNAME,IDCODE,ADDRESS,MOBILESMS MOBILE,EMAIL,IDDATE,IDEXPIRED,IDPLACE  from CFMAST WHERE CUSTID ='" & v_strCUSTID & "' And STATUS = 'A'"
            Dim v_strObjMsg As String = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, "SA.ALLCODE", gc_ActionInquiry, v_strCmdInquiry)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            If v_nodeList.Count > 0 Then
                For v_intCount = 0 To v_nodeList.Count - 1
                    For v_int = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                        With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                            v_strFLDNAME = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("fldname").Value.Trim()
                            v_strVALUE = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("oldval").Value.Trim()

                            Select Case v_strFLDNAME
                                Case "CUSTID"
                                    v_strCUSTID = v_strVALUE
                                Case "FULLNAME"
                                    v_strFULLNAME = v_strVALUE
                                Case "ADDRESS"
                                    v_strADDRESS = v_strVALUE
                                Case "IDCODE"
                                    v_strIDCODE = v_strVALUE
                                Case "MOBILE"
                                    v_strPHONE = v_strVALUE
                                Case "EMAIL"
                                    v_strEMAIL = v_strVALUE
                                Case "IDDATE"
                                    dtpLNIDDATE.Text = v_strVALUE
                                Case "IDEXPIRED"
                                    v_strIDEXPIRED = v_strVALUE
                                Case "IDPLACE"
                                    v_strIDPLACE = v_strVALUE
                                Case "VALDATE"
                                    dtpVALDATE.Text = v_strVALUE
                                Case "EXPDATE"
                                    dtpEXPDATE.Text = v_strVALUE
                            End Select
                        End With
                    Next
                Next


                txtFULLNAME.Text = v_strFULLNAME
                txtADDRESS.Text = v_strADDRESS
                txtLICENSENO.Text = v_strIDCODE
                txtTELEPHONE.Text = v_strPHONE
                txtLNPLACE.Text = v_strIDPLACE
                txtEMAIL.Text = v_strEMAIL
                'dtpLNIDDATE.Text = v_strIDDATE
                txtCUSTID.Text = v_strCUSTID

                txtFULLNAME.Enabled = False
                txtADDRESS.Enabled = False
                txtTELEPHONE.Enabled = False
                txtEMAIL.Enabled = False
                txtLNPLACE.Enabled = False
                dtpLNIDDATE.Enabled = False
            End If

        End If
    End Sub
#End Region

#Region " Control validations "
    Private Function ControlValidation(Optional ByVal pv_blnSaved As Boolean = False) As Boolean


        Try
            If pv_blnSaved Then
                Dim date1 As Date = dtpVALDATE.Value
                Dim date2 As Date = dtpEXPDATE.Value

                Dim v_strResult As Integer = DateTime.Compare(date1, date2)
                If v_strResult >= 0 Then
                    MsgBox(ResourceManager.GetString("EXPDTERLIERTHANVALDT"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    Exit Function
                End If

                Return MyBase.VerifyRules
            End If


            Return True
        Catch ex As Exception
            Throw ex
            Return False
        End Try
    End Function
    Private Sub LoadCFSign(ByVal pv_strAUTOID As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim v_strSIGNATURE, v_strCUSTID As String
            Dim v_strSQL As String = "SELECT SIGNATURE,CUSTID FROM CFAUTH  WHERE TRIM(AUTOID)='" & pv_strAUTOID & "'"
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_strObjMsg As String = BuildXMLObjMsg(, , , , MyBase.LocalObject, gc_MsgTypeObj, "CF.CFSIGN", _
                gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)
            Dim v_xmlDoc As New XmlDocument
            v_xmlDoc.LoadXml(v_strObjMsg)
            Dim v_xmlNodeList As XmlNodeList = v_xmlDoc.SelectNodes("/ObjectMessage/ObjData")
            Dim v_xmlEntry As XmlNode
            Dim v_strFLDNAME As String = String.Empty
            Dim v_strValue As String = String.Empty

            For i As Integer = 0 To v_xmlNodeList.Count - 1
                For j As Integer = 0 To v_xmlNodeList.Item(i).ChildNodes.Count - 1
                    With v_xmlNodeList.Item(i).ChildNodes(j)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strValue = .InnerText.ToString
                        Select Case Trim(v_strFLDNAME)
                            Case "SIGNATURE"
                                v_strSIGNATURE = Trim(v_strValue)
                            Case "CUSTID"
                                v_strCUSTID = Trim(v_strValue)
                        End Select
                    End With
                Next
            Next
            If v_strSIGNATURE.Length > 0 Then
                mv_idxNumOfSign = mv_idxNumOfSign + 1
            End If

            If v_strCUSTID <> "" Then
                v_strSIGNATURE = getSIGN_CFSIGN(pv_strAUTOID)
                Me.btnBROWSER.Enabled = False
                Me.txtBROWSER.Enabled = False
            End If
            If v_strSIGNATURE.Length > 0 Then
                'mv_ImageViewer.Image = GetImageFromString(v_strSIGNATURE)
                'mv_ImageViewer.Refresh()
                pbxSIGNATURE.Image = GetImageFromString(v_strSIGNATURE)
                pbxSIGNATURE.SizeMode = PictureBoxSizeMode.CenterImage
                pbxSIGNATURE.BorderStyle = BorderStyle.Fixed3D
            Else
                pbxSIGNATURE.Image = Nothing
                pbxSIGNATURE.Refresh()
            End If
            Cursor.Current = Cursors.Default

        Catch ex As Exception
            'MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Function getSIGN_CFSIGN(ByVal pv_strAUTOID As String) As String

        Try
            Cursor.Current = Cursors.WaitCursor
            Dim v_strSQL As String = "SELECT SIGNATURE FROM CFSIGN, SYSVAR SYS WHERE CUSTID = (select CUSTID from CFAUTH where AUTOID='" & pv_strAUTOID & "')" _
            & " AND sys.varname = 'CURRDATE' AND grname = 'SYSTEM' " _
            & " AND to_date(sys.varvalue,'DD/MM/RRRR') >= valdate AND to_date(sys.varvalue,'DD/MM/RRRR') <= expdate order by autoid desc"

            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_strObjMsg As String = BuildXMLObjMsg(, , , , MyBase.LocalObject, gc_MsgTypeObj, "CF.CFSIGN", _
                gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)
            Dim v_xmlDoc As New XmlDocument
            v_xmlDoc.LoadXml(v_strObjMsg)
            Dim v_xmlNodeList As XmlNodeList = v_xmlDoc.SelectNodes("/ObjectMessage/ObjData")
            Dim v_xmlEntry As XmlNode
            Dim v_strFLDNAME As String = String.Empty
            Dim v_strValue As String = String.Empty
            ReDim mv_arrSIGNATURE(v_xmlNodeList.Count - 1)
            For i As Integer = 0 To v_xmlNodeList.Count - 1
                For j As Integer = 0 To v_xmlNodeList.Item(i).ChildNodes.Count - 1
                    With v_xmlNodeList.Item(i).ChildNodes(j)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strValue = .InnerText.ToString
                        Select Case Trim(v_strFLDNAME)
                            Case "SIGNATURE"
                                mv_arrSIGNATURE(i) = Trim(v_strValue)
                                mv_idxNumOfSign = mv_idxNumOfSign + 1
                        End Select
                    End With
                Next
            Next
            Return mv_arrSIGNATURE(0).ToString
        Catch ex As Exception
            'MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Function


#End Region

#Region "form events"
    Private Sub frmCFAUTH_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.ExeFlag = ExecuteFlag.View Then
            Me.txtBROWSER.Enabled = False
            Me.btnBROWSER.Enabled = False
        ElseIf Me.ExeFlag = ExecuteFlag.Edit Then
            If Me.txtCUSTID.Text.Length > 0 Then
                txtFULLNAME.Enabled = False
                txtADDRESS.Enabled = False
                txtTELEPHONE.Enabled = False
                If txtEMAIL.Text.Length > 3 Then
                    txtEMAIL.Enabled = False
                Else
                    txtEMAIL.Enabled = True
                End If
                txtLNPLACE.Enabled = False
                txtLICENSENO.Enabled = False
                dtpLNIDDATE.Enabled = False
            Else
                txtFULLNAME.Enabled = True
                txtADDRESS.Enabled = True
                txtTELEPHONE.Enabled = True
                txtEMAIL.Enabled = True
                txtLNPLACE.Enabled = True
                dtpLNIDDATE.Enabled = True
            End If
                btnNEXT.Enabled = False
                btnPREVIOUS.Enabled = False
            ElseIf Me.ExeFlag = ExecuteFlag.AddNew Then
                btnNEXT.Enabled = False
                btnPREVIOUS.Enabled = False
            End If
    End Sub

    Private Sub btnBROWSER_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBROWSER.Click
        Try
            Dim v_oFileDlg As New OpenFileDialog
            With v_oFileDlg
                .InitialDirectory = "C:\"
                .Filter = "Bitmaps|*.bmp|GIFs|*.gif|JPEGs|*.jpg"
                .FilterIndex = 2
                .RestoreDirectory = True
            End With
            If v_oFileDlg.ShowDialog() = DialogResult.OK Then
                With pbxSIGNATURE
                    .Image = Image.FromFile(v_oFileDlg.FileName)
                    .SizeMode = PictureBoxSizeMode.CenterImage
                    .BorderStyle = BorderStyle.Fixed3D
                End With
                txtBROWSER.Text = v_oFileDlg.FileName
                mv_lngFileSize = FileLen(v_oFileDlg.FileName)
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
               & "Error code: System error!" & vbNewLine _
               & "Error message: " & ex.Message, EventLogEntryType.Error)
            'MessageBox.Show(mv_ResourceManager.GetString("frmReceiverData.CannotOpenFile"), Me.FormCaption, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub



    Private Sub txtCUSTID_Validating1(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCUSTID.Validating
        Try
            getCustInfoByCustID()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ckb7_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.ckb7.Checked = True Then
            Me.txtACCOUNTNAME.Enabled = True
            Me.txtBANKACCOUNT.Enabled = True
            Me.cboBANKNAME.Enabled = True
        Else
            Me.txtACCOUNTNAME.Enabled = False
            Me.txtBANKACCOUNT.Enabled = False
            Me.cboBANKNAME.Enabled = False
        End If
    End Sub
#End Region


    Private Sub btnNEXT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNEXT.Click
        If mv_currIdx = mv_idxNumOfSign - 1 Then
            Exit Sub
        Else
            mv_currIdx = mv_currIdx + 1
            pbxSIGNATURE.Image = GetImageFromString(mv_arrSIGNATURE(mv_currIdx))
        End If
    End Sub

    Private Sub btnPREVIOUS_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPREVIOUS.Click
        If mv_currIdx = 0 Then
            Exit Sub
        Else
            mv_currIdx = mv_currIdx - 1
            pbxSIGNATURE.Image = GetImageFromString(mv_arrSIGNATURE(mv_currIdx))
        End If
    End Sub


    Private Sub ckbALL_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckbALL.CheckedChanged
        If ckbALL.Checked Then
            ckb1.Checked = IIf(ckb1.Enabled = True, True, False)
            ckb2.Checked = IIf(ckb2.Enabled = True, True, False)
            ckb3.Checked = IIf(ckb3.Enabled = True, True, False)
            ckb4.Checked = IIf(ckb4.Enabled = True, True, False)
            ckb5.Checked = IIf(ckb5.Enabled = True, True, False)
            ckb6.Checked = IIf(ckb6.Enabled = True, True, False)
            ckb7.Checked = IIf(ckb7.Enabled = True, True, False)
            ckb8.Checked = IIf(ckb8.Enabled = True, True, False)
            ckb9.Checked = IIf(ckb9.Enabled = True, True, False)
            ckb10.Checked = IIf(ckb10.Enabled = True, True, False)
            ckb11.Checked = IIf(ckb11.Enabled = True, True, False)
            ckb12.Checked = IIf(ckb12.Enabled = True, True, False)
            ckb13.Checked = IIf(ckb13.Enabled = True, True, False)
            ckb14.Checked = IIf(ckb14.Enabled = True, True, False) 'thunt-2019-19-09
            ckb15.Checked = IIf(ckb15.Enabled = True, True, False) 'thunt-2019-19-09
            ckb16.Checked = IIf(ckb16.Enabled = True, True, False) 'thunt-2019-19-09
        Else
            ckb1.Checked = False
            ckb2.Checked = False
            ckb3.Checked = False
            ckb4.Checked = False
            ckb5.Checked = False
            ckb6.Checked = False
            ckb7.Checked = False
            ckb8.Checked = False
            ckb9.Checked = False
            ckb10.Checked = False
            ckb11.Checked = False
            ckb12.Checked = False
            ckb13.Checked = False
            ckb14.Checked = False
            ckb15.Checked = False
            ckb16.Checked = False
        End If
    End Sub

    Private Sub txtLICENSENO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLICENSENO.Validating
        getCustInfoByLicenseNO()
        If txtLICENSENO.Text = mv_idcode And Not mv_idcode Is Nothing Then
            txtFULLNAME.Enabled = False
            txtADDRESS.Enabled = False
            txtTELEPHONE.Enabled = False
            If txtEMAIL.Text.Length > 3 Then
                txtEMAIL.Enabled = False
            Else
                txtEMAIL.Enabled = False
            End If
            txtLNPLACE.Enabled = False
            dtpLNIDDATE.Enabled = False

        Else
            txtFULLNAME.Enabled = True
            txtADDRESS.Enabled = True
            txtTELEPHONE.Enabled = True
            txtEMAIL.Enabled = True
            txtLNPLACE.Enabled = True
            dtpLNIDDATE.Enabled = True
            txtCUSTID.Clear()
        End If
    End Sub

    Private Sub dtpEXPDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpEXPDATE.Validating
        If Not dtpEXPDATE.Value >= dtpVALDATE.Value Then
            MsgBox(ResourceManager.GetString("ERR_CF_CFAUTH_EXPDATEGreaterThanVALDATE"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            dtpEXPDATE.Focus()
        End If
    End Sub

    Private Sub cboAUTHTYPE_ControlAdded(sender As Object, e As ControlEventArgs) Handles cboAUTHTYPE.ControlAdded

    End Sub



    Private Sub cboAUTHTYPE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAUTHTYPE.SelectedIndexChanged
        'longnh
        If cboAUTHTYPE.SelectedValue.ToString = "C" Then
            ckb1.Enabled = False
            ckb2.Enabled = False
            ckb3.Enabled = True
            ckb4.Enabled = False
            ckb5.Enabled = False
            ckb6.Enabled = True
            ckb7.Enabled = False
            ckb8.Enabled = False
            ckb9.Enabled = False
            ckb10.Enabled = False
            ckb11.Enabled = False
            ckb14.Enabled = False
            ckb15.Enabled = False
            ckb16.Enabled = False
            ckb1.Checked = False
            ckb2.Checked = False
            'ckb3.Checked = True
            ckb4.Checked = False
            ckb5.Checked = False
            'ckb6.Checked = True
            ckb7.Checked = False
            ckb8.Checked = False
            ckb9.Checked = False
            ckb10.Checked = False
            ckb11.Checked = False
            ckb14.Checked = False
            ckb15.Checked = False
            ckb16.Checked = False
        ElseIf cboAUTHTYPE.SelectedValue.ToString = "O" Then
            ckb1.Enabled = True
            ckb2.Enabled = True
            ckb3.Enabled = False
            ckb4.Enabled = True
            ckb5.Enabled = True
            ckb6.Enabled = True
            ckb7.Enabled = True
            ckb8.Enabled = True
            ckb9.Enabled = True
            ckb10.Enabled = True
            ckb11.Enabled = True
            ckb14.Enabled = True
            ckb15.Enabled = True
            ckb16.Enabled = True
            'ckb1.Checked = True
            'ckb2.Checked = True
            ckb3.Checked = False
            'ckb4.Checked = True
            'ckb5.Checked = True
            'ckb7.Checked = True
            'ckb8.Checked = True
            'ckb9.Checked = True
            'ckb10.Checked = True
            'ckb11.Checked = True
        ElseIf cboAUTHTYPE.SelectedValue.ToString = "A" Then
            ckb1.Enabled = True
            ckb2.Enabled = True
            ckb3.Enabled = True
            ckb4.Enabled = True
            ckb5.Enabled = True
            ckb7.Enabled = True
            ckb8.Enabled = True
            ckb9.Enabled = True
            ckb10.Enabled = True
            ckb11.Enabled = True
            ckb14.Enabled = True
            ckb15.Enabled = True
            ckb16.Enabled = True
        End If
    End Sub

    Private Sub cboAUTHLIMIT_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAUTHLIMIT.SelectedIndexChanged
        'longnh
        If cboAUTHLIMIT.SelectedValue.ToString = "Y" Then
            dtpVALDATE.Enabled = True
            dtpEXPDATE.Enabled = True
        Else
            'dtpVALDATE.Enabled = False
            dtpEXPDATE.Enabled = False
            dtpEXPDATE.Value = DateAdd(DateInterval.Year, 100, dtpVALDATE.Value)
        End If
    End Sub



    Private Sub btnApply_Click(sender As Object, e As EventArgs) Handles btnApply.Click

    End Sub

    Private Sub cboSHVUSER_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSHV.SelectedIndexChanged

        If cboSHV.SelectedValue.ToString = "Y" Then
            ckb1.Enabled = True
            ckb2.Enabled = True
            ckb3.Enabled = True
            ckb4.Enabled = True
            ckb5.Enabled = True
            ckb7.Enabled = True
            ckb8.Enabled = True
            ckb9.Enabled = True
            ckb10.Enabled = True
            ckb11.Enabled = True
            ckb14.Enabled = True
            ckb15.Enabled = True
            ckb16.Enabled = True
        End If
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

    End Sub
End Class
