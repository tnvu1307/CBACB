Imports CommonLibrary
Imports AppCore
Imports System.Xml.XmlNode
Imports System.Xml

Public Class frmCFLINK
    Inherits AppCore.frmMaintenance
    Public mv_StrACCTNO As String

    Private mv_ImageViewer As New ImageViewer
    Private mv_arrSIGNATURE As String()
    Private mv_idxNumOfSign As Integer = 0

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
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpMainInfo As System.Windows.Forms.TabPage
    Friend WithEvents grbMAINLINK As System.Windows.Forms.GroupBox
    Friend WithEvents txtLICENSENO As System.Windows.Forms.Label
    Friend WithEvents dtpLNIDDATE As System.Windows.Forms.Label
    Friend WithEvents lblLNIDDATE As System.Windows.Forms.Label
    Friend WithEvents txtLNPLACE As System.Windows.Forms.Label
    Friend WithEvents lblLNPLACE As System.Windows.Forms.Label
    Friend WithEvents txtTELEPHONE As System.Windows.Forms.Label
    Friend WithEvents lblLICENSENO As System.Windows.Forms.Label
    Friend WithEvents lblTELEPHONE As System.Windows.Forms.Label
    Friend WithEvents txtFULLNAME As System.Windows.Forms.Label
    Friend WithEvents txtADDRESS As System.Windows.Forms.Label
    Friend WithEvents lblADDRESS As System.Windows.Forms.Label
    Friend WithEvents ckb10 As System.Windows.Forms.CheckBox
    Friend WithEvents ckb9 As System.Windows.Forms.CheckBox
    Friend WithEvents ckb8 As System.Windows.Forms.CheckBox
    Friend WithEvents ckb7 As System.Windows.Forms.CheckBox
    Friend WithEvents ckb6 As System.Windows.Forms.CheckBox
    Friend WithEvents ckb5 As System.Windows.Forms.CheckBox
    Friend WithEvents ckb4 As System.Windows.Forms.CheckBox
    Friend WithEvents ckb3 As System.Windows.Forms.CheckBox
    Friend WithEvents ckb2 As System.Windows.Forms.CheckBox
    Friend WithEvents ckb1 As System.Windows.Forms.CheckBox
    Friend WithEvents lblLINKTYPE As System.Windows.Forms.Label
    Friend WithEvents cboLINKTYPE As AppCore.ComboBoxEx
    Friend WithEvents lblACCTNO As System.Windows.Forms.Label
    Friend WithEvents txtACCTNO As System.Windows.Forms.TextBox
    Friend WithEvents lblDESCRIPTION As System.Windows.Forms.Label
    Friend WithEvents txtDESCRIPTION As System.Windows.Forms.TextBox
    Friend WithEvents lblCUSTID As System.Windows.Forms.Label
    Friend WithEvents txtCUSTID As System.Windows.Forms.TextBox
    Friend WithEvents tpSign As System.Windows.Forms.TabPage
    Friend WithEvents btnPREVIOUS As System.Windows.Forms.Button
    Friend WithEvents btnNEXT As System.Windows.Forms.Button
    Friend WithEvents pnSignatures As System.Windows.Forms.Panel
    Friend WithEvents pbxSIGNATURE As System.Windows.Forms.PictureBox

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents txtAUTOID As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCFLINK))
        Me.txtAUTOID = New System.Windows.Forms.TextBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tpMainInfo = New System.Windows.Forms.TabPage
        Me.grbMAINLINK = New System.Windows.Forms.GroupBox
        Me.txtLICENSENO = New System.Windows.Forms.Label
        Me.dtpLNIDDATE = New System.Windows.Forms.Label
        Me.lblLNIDDATE = New System.Windows.Forms.Label
        Me.txtLNPLACE = New System.Windows.Forms.Label
        Me.lblLNPLACE = New System.Windows.Forms.Label
        Me.txtTELEPHONE = New System.Windows.Forms.Label
        Me.lblLICENSENO = New System.Windows.Forms.Label
        Me.lblTELEPHONE = New System.Windows.Forms.Label
        Me.txtFULLNAME = New System.Windows.Forms.Label
        Me.txtADDRESS = New System.Windows.Forms.Label
        Me.lblADDRESS = New System.Windows.Forms.Label
        Me.ckb10 = New System.Windows.Forms.CheckBox
        Me.ckb9 = New System.Windows.Forms.CheckBox
        Me.ckb8 = New System.Windows.Forms.CheckBox
        Me.ckb7 = New System.Windows.Forms.CheckBox
        Me.ckb6 = New System.Windows.Forms.CheckBox
        Me.ckb5 = New System.Windows.Forms.CheckBox
        Me.ckb4 = New System.Windows.Forms.CheckBox
        Me.ckb3 = New System.Windows.Forms.CheckBox
        Me.ckb2 = New System.Windows.Forms.CheckBox
        Me.ckb1 = New System.Windows.Forms.CheckBox
        Me.lblLINKTYPE = New System.Windows.Forms.Label
        Me.cboLINKTYPE = New AppCore.ComboBoxEx
        Me.lblACCTNO = New System.Windows.Forms.Label
        Me.txtACCTNO = New System.Windows.Forms.TextBox
        Me.lblDESCRIPTION = New System.Windows.Forms.Label
        Me.txtDESCRIPTION = New System.Windows.Forms.TextBox
        Me.lblCUSTID = New System.Windows.Forms.Label
        Me.txtCUSTID = New System.Windows.Forms.TextBox
        Me.tpSign = New System.Windows.Forms.TabPage
        Me.btnPREVIOUS = New System.Windows.Forms.Button
        Me.btnNEXT = New System.Windows.Forms.Button
        Me.pnSignatures = New System.Windows.Forms.Panel
        Me.pbxSIGNATURE = New System.Windows.Forms.PictureBox
        Me.Panel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tpMainInfo.SuspendLayout()
        Me.grbMAINLINK.SuspendLayout()
        Me.tpSign.SuspendLayout()
        CType(Me.pbxSIGNATURE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(325, 468)
        Me.btnOK.Size = New System.Drawing.Size(75, 24)
        Me.btnOK.TabIndex = 1
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(405, 468)
        Me.btnCancel.Size = New System.Drawing.Size(75, 24)
        Me.btnCancel.TabIndex = 2
        '
        'lblCaption
        '
        Me.lblCaption.Location = New System.Drawing.Point(7, 17)
        '
        'btnApply
        '
        Me.btnApply.Location = New System.Drawing.Point(485, 468)
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(582, 50)
        '
        'btnApprv
        '
        Me.btnApprv.Location = New System.Drawing.Point(159, 534)
        '
        'cboLink
        '
        Me.cboLink.Location = New System.Drawing.Point(21, 536)
        '
        'txtAUTOID
        '
        Me.txtAUTOID.Location = New System.Drawing.Point(23, 508)
        Me.txtAUTOID.Name = "txtAUTOID"
        Me.txtAUTOID.Size = New System.Drawing.Size(112, 21)
        Me.txtAUTOID.TabIndex = 20
        Me.txtAUTOID.Tag = "AUTOID"
        Me.txtAUTOID.Text = "txtAUTOID"
        Me.txtAUTOID.Visible = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tpMainInfo)
        Me.TabControl1.Controls.Add(Me.tpSign)
        Me.TabControl1.Location = New System.Drawing.Point(10, 59)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(561, 393)
        Me.TabControl1.TabIndex = 21
        Me.TabControl1.Tag = "TabControl1"
        '
        'tpMainInfo
        '
        Me.tpMainInfo.Controls.Add(Me.grbMAINLINK)
        Me.tpMainInfo.Location = New System.Drawing.Point(4, 22)
        Me.tpMainInfo.Name = "tpMainInfo"
        Me.tpMainInfo.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMainInfo.Size = New System.Drawing.Size(553, 367)
        Me.tpMainInfo.TabIndex = 0
        Me.tpMainInfo.Tag = "tpMainInfo"
        Me.tpMainInfo.Text = "tpMaininfo"
        Me.tpMainInfo.UseVisualStyleBackColor = True
        '
        'grbMAINLINK
        '
        Me.grbMAINLINK.Controls.Add(Me.txtLICENSENO)
        Me.grbMAINLINK.Controls.Add(Me.dtpLNIDDATE)
        Me.grbMAINLINK.Controls.Add(Me.lblLNIDDATE)
        Me.grbMAINLINK.Controls.Add(Me.txtLNPLACE)
        Me.grbMAINLINK.Controls.Add(Me.lblLNPLACE)
        Me.grbMAINLINK.Controls.Add(Me.txtTELEPHONE)
        Me.grbMAINLINK.Controls.Add(Me.lblLICENSENO)
        Me.grbMAINLINK.Controls.Add(Me.lblTELEPHONE)
        Me.grbMAINLINK.Controls.Add(Me.txtFULLNAME)
        Me.grbMAINLINK.Controls.Add(Me.txtADDRESS)
        Me.grbMAINLINK.Controls.Add(Me.lblADDRESS)
        Me.grbMAINLINK.Controls.Add(Me.ckb10)
        Me.grbMAINLINK.Controls.Add(Me.ckb9)
        Me.grbMAINLINK.Controls.Add(Me.ckb8)
        Me.grbMAINLINK.Controls.Add(Me.ckb7)
        Me.grbMAINLINK.Controls.Add(Me.ckb6)
        Me.grbMAINLINK.Controls.Add(Me.ckb5)
        Me.grbMAINLINK.Controls.Add(Me.ckb4)
        Me.grbMAINLINK.Controls.Add(Me.ckb3)
        Me.grbMAINLINK.Controls.Add(Me.ckb2)
        Me.grbMAINLINK.Controls.Add(Me.ckb1)
        Me.grbMAINLINK.Controls.Add(Me.lblLINKTYPE)
        Me.grbMAINLINK.Controls.Add(Me.cboLINKTYPE)
        Me.grbMAINLINK.Controls.Add(Me.lblACCTNO)
        Me.grbMAINLINK.Controls.Add(Me.txtACCTNO)
        Me.grbMAINLINK.Controls.Add(Me.lblDESCRIPTION)
        Me.grbMAINLINK.Controls.Add(Me.txtDESCRIPTION)
        Me.grbMAINLINK.Controls.Add(Me.lblCUSTID)
        Me.grbMAINLINK.Controls.Add(Me.txtCUSTID)
        Me.grbMAINLINK.Location = New System.Drawing.Point(1, 5)
        Me.grbMAINLINK.Name = "grbMAINLINK"
        Me.grbMAINLINK.Size = New System.Drawing.Size(545, 359)
        Me.grbMAINLINK.TabIndex = 1
        Me.grbMAINLINK.TabStop = False
        Me.grbMAINLINK.Tag = "grbMAINLINK"
        Me.grbMAINLINK.Text = "grbMAINLINK"
        '
        'txtLICENSENO
        '
        Me.txtLICENSENO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLICENSENO.Location = New System.Drawing.Point(360, 154)
        Me.txtLICENSENO.Name = "txtLICENSENO"
        Me.txtLICENSENO.Size = New System.Drawing.Size(132, 21)
        Me.txtLICENSENO.TabIndex = 52
        Me.txtLICENSENO.Tag = ""
        '
        'dtpLNIDDATE
        '
        Me.dtpLNIDDATE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dtpLNIDDATE.Location = New System.Drawing.Point(360, 184)
        Me.dtpLNIDDATE.Name = "dtpLNIDDATE"
        Me.dtpLNIDDATE.Size = New System.Drawing.Size(132, 21)
        Me.dtpLNIDDATE.TabIndex = 51
        Me.dtpLNIDDATE.Tag = ""
        '
        'lblLNIDDATE
        '
        Me.lblLNIDDATE.Location = New System.Drawing.Point(268, 187)
        Me.lblLNIDDATE.Name = "lblLNIDDATE"
        Me.lblLNIDDATE.Size = New System.Drawing.Size(120, 21)
        Me.lblLNIDDATE.TabIndex = 50
        Me.lblLNIDDATE.Tag = "LNIDDATE"
        Me.lblLNIDDATE.Text = "lblLNIDDATE"
        '
        'txtLNPLACE
        '
        Me.txtLNPLACE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLNPLACE.Location = New System.Drawing.Point(121, 183)
        Me.txtLNPLACE.Name = "txtLNPLACE"
        Me.txtLNPLACE.Size = New System.Drawing.Size(133, 21)
        Me.txtLNPLACE.TabIndex = 48
        Me.txtLNPLACE.Tag = ""
        '
        'lblLNPLACE
        '
        Me.lblLNPLACE.AutoSize = True
        Me.lblLNPLACE.Location = New System.Drawing.Point(12, 183)
        Me.lblLNPLACE.Name = "lblLNPLACE"
        Me.lblLNPLACE.Size = New System.Drawing.Size(60, 13)
        Me.lblLNPLACE.TabIndex = 49
        Me.lblLNPLACE.Tag = "LNPLACE"
        Me.lblLNPLACE.Text = "lblLNPLACE"
        '
        'txtTELEPHONE
        '
        Me.txtTELEPHONE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTELEPHONE.Location = New System.Drawing.Point(122, 151)
        Me.txtTELEPHONE.Name = "txtTELEPHONE"
        Me.txtTELEPHONE.Size = New System.Drawing.Size(132, 21)
        Me.txtTELEPHONE.TabIndex = 46
        Me.txtTELEPHONE.Tag = ""
        Me.txtTELEPHONE.Text = "txtTELEPHONE"
        '
        'lblLICENSENO
        '
        Me.lblLICENSENO.Location = New System.Drawing.Point(268, 154)
        Me.lblLICENSENO.Name = "lblLICENSENO"
        Me.lblLICENSENO.Size = New System.Drawing.Size(88, 21)
        Me.lblLICENSENO.TabIndex = 47
        Me.lblLICENSENO.Tag = "LICENSENO"
        Me.lblLICENSENO.Text = "lblLICENSENO"
        '
        'lblTELEPHONE
        '
        Me.lblTELEPHONE.Location = New System.Drawing.Point(12, 151)
        Me.lblTELEPHONE.Name = "lblTELEPHONE"
        Me.lblTELEPHONE.Size = New System.Drawing.Size(108, 21)
        Me.lblTELEPHONE.TabIndex = 45
        Me.lblTELEPHONE.Tag = "TELEPHONE"
        Me.lblTELEPHONE.Text = "lblTELEPHONE"
        '
        'txtFULLNAME
        '
        Me.txtFULLNAME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFULLNAME.Location = New System.Drawing.Point(239, 88)
        Me.txtFULLNAME.Name = "txtFULLNAME"
        Me.txtFULLNAME.Size = New System.Drawing.Size(253, 21)
        Me.txtFULLNAME.TabIndex = 41
        Me.txtFULLNAME.Tag = ""
        Me.txtFULLNAME.Text = "txtFULLNAME"
        '
        'txtADDRESS
        '
        Me.txtADDRESS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtADDRESS.Location = New System.Drawing.Point(122, 119)
        Me.txtADDRESS.Name = "txtADDRESS"
        Me.txtADDRESS.Size = New System.Drawing.Size(370, 21)
        Me.txtADDRESS.TabIndex = 42
        Me.txtADDRESS.Tag = ""
        Me.txtADDRESS.Text = "txtADDRESS"
        '
        'lblADDRESS
        '
        Me.lblADDRESS.Location = New System.Drawing.Point(12, 119)
        Me.lblADDRESS.Name = "lblADDRESS"
        Me.lblADDRESS.Size = New System.Drawing.Size(108, 21)
        Me.lblADDRESS.TabIndex = 44
        Me.lblADDRESS.Tag = "ADDRESS"
        Me.lblADDRESS.Text = "lblADDRESS"
        '
        'ckb10
        '
        Me.ckb10.Location = New System.Drawing.Point(22, 324)
        Me.ckb10.Name = "ckb10"
        Me.ckb10.Size = New System.Drawing.Size(135, 24)
        Me.ckb10.TabIndex = 13
        Me.ckb10.Tag = "ckb9"
        Me.ckb10.Text = "ckb10"
        '
        'ckb9
        '
        Me.ckb9.Location = New System.Drawing.Point(307, 298)
        Me.ckb9.Name = "ckb9"
        Me.ckb9.Size = New System.Drawing.Size(161, 24)
        Me.ckb9.TabIndex = 12
        Me.ckb9.Tag = "ckb9"
        Me.ckb9.Text = "ckb9"
        '
        'ckb8
        '
        Me.ckb8.Location = New System.Drawing.Point(166, 298)
        Me.ckb8.Name = "ckb8"
        Me.ckb8.Size = New System.Drawing.Size(132, 24)
        Me.ckb8.TabIndex = 11
        Me.ckb8.Tag = "ckb8"
        Me.ckb8.Text = "ckb8"
        '
        'ckb7
        '
        Me.ckb7.Location = New System.Drawing.Point(22, 298)
        Me.ckb7.Name = "ckb7"
        Me.ckb7.Size = New System.Drawing.Size(135, 24)
        Me.ckb7.TabIndex = 10
        Me.ckb7.Tag = "ckb7"
        Me.ckb7.Text = "ckb7"
        '
        'ckb6
        '
        Me.ckb6.Location = New System.Drawing.Point(307, 272)
        Me.ckb6.Name = "ckb6"
        Me.ckb6.Size = New System.Drawing.Size(161, 24)
        Me.ckb6.TabIndex = 9
        Me.ckb6.Tag = "ckb6"
        Me.ckb6.Text = "ckb6"
        '
        'ckb5
        '
        Me.ckb5.Location = New System.Drawing.Point(166, 272)
        Me.ckb5.Name = "ckb5"
        Me.ckb5.Size = New System.Drawing.Size(132, 24)
        Me.ckb5.TabIndex = 8
        Me.ckb5.Tag = "ckb5"
        Me.ckb5.Text = "ckb5"
        '
        'ckb4
        '
        Me.ckb4.Location = New System.Drawing.Point(22, 272)
        Me.ckb4.Name = "ckb4"
        Me.ckb4.Size = New System.Drawing.Size(135, 24)
        Me.ckb4.TabIndex = 7
        Me.ckb4.Tag = "ckb4"
        Me.ckb4.Text = "ckb4"
        '
        'ckb3
        '
        Me.ckb3.Location = New System.Drawing.Point(307, 246)
        Me.ckb3.Name = "ckb3"
        Me.ckb3.Size = New System.Drawing.Size(161, 24)
        Me.ckb3.TabIndex = 6
        Me.ckb3.Tag = "ckb3"
        Me.ckb3.Text = "ckb3"
        '
        'ckb2
        '
        Me.ckb2.Location = New System.Drawing.Point(166, 246)
        Me.ckb2.Name = "ckb2"
        Me.ckb2.Size = New System.Drawing.Size(132, 24)
        Me.ckb2.TabIndex = 5
        Me.ckb2.Tag = "ckb2"
        Me.ckb2.Text = "ckb2"
        '
        'ckb1
        '
        Me.ckb1.Location = New System.Drawing.Point(22, 246)
        Me.ckb1.Name = "ckb1"
        Me.ckb1.Size = New System.Drawing.Size(135, 24)
        Me.ckb1.TabIndex = 4
        Me.ckb1.Tag = "ckb1"
        Me.ckb1.Text = "ckb1"
        '
        'lblLINKTYPE
        '
        Me.lblLINKTYPE.Location = New System.Drawing.Point(12, 50)
        Me.lblLINKTYPE.Name = "lblLINKTYPE"
        Me.lblLINKTYPE.Size = New System.Drawing.Size(96, 24)
        Me.lblLINKTYPE.TabIndex = 19
        Me.lblLINKTYPE.Tag = "LINKTYPE"
        Me.lblLINKTYPE.Text = "lblLINKTYPE"
        '
        'cboLINKTYPE
        '
        Me.cboLINKTYPE.DisplayMember = "DISPLAY"
        Me.cboLINKTYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLINKTYPE.Location = New System.Drawing.Point(122, 52)
        Me.cboLINKTYPE.Name = "cboLINKTYPE"
        Me.cboLINKTYPE.Size = New System.Drawing.Size(370, 21)
        Me.cboLINKTYPE.TabIndex = 2
        Me.cboLINKTYPE.Tag = "LINKTYPE"
        Me.cboLINKTYPE.ValueMember = "VALUE"
        '
        'lblACCTNO
        '
        Me.lblACCTNO.Location = New System.Drawing.Point(12, 19)
        Me.lblACCTNO.Name = "lblACCTNO"
        Me.lblACCTNO.Size = New System.Drawing.Size(96, 24)
        Me.lblACCTNO.TabIndex = 17
        Me.lblACCTNO.Tag = "ACCTNO"
        Me.lblACCTNO.Text = "lblACCTNO"
        '
        'txtACCTNO
        '
        Me.txtACCTNO.Location = New System.Drawing.Point(122, 21)
        Me.txtACCTNO.Name = "txtACCTNO"
        Me.txtACCTNO.Size = New System.Drawing.Size(112, 21)
        Me.txtACCTNO.TabIndex = 0
        Me.txtACCTNO.Tag = "ACCTNO"
        Me.txtACCTNO.Text = "txtACCTNO"
        '
        'lblDESCRIPTION
        '
        Me.lblDESCRIPTION.Location = New System.Drawing.Point(8, 215)
        Me.lblDESCRIPTION.Name = "lblDESCRIPTION"
        Me.lblDESCRIPTION.Size = New System.Drawing.Size(96, 24)
        Me.lblDESCRIPTION.TabIndex = 15
        Me.lblDESCRIPTION.Tag = "DESCRIPTION"
        Me.lblDESCRIPTION.Text = "lblDESCRIPTION"
        '
        'txtDESCRIPTION
        '
        Me.txtDESCRIPTION.Location = New System.Drawing.Point(121, 217)
        Me.txtDESCRIPTION.Name = "txtDESCRIPTION"
        Me.txtDESCRIPTION.Size = New System.Drawing.Size(371, 21)
        Me.txtDESCRIPTION.TabIndex = 3
        Me.txtDESCRIPTION.Tag = "DESCRIPTION"
        Me.txtDESCRIPTION.Text = "txtDESCRIPTION"
        '
        'lblCUSTID
        '
        Me.lblCUSTID.Location = New System.Drawing.Point(12, 88)
        Me.lblCUSTID.Name = "lblCUSTID"
        Me.lblCUSTID.Size = New System.Drawing.Size(88, 24)
        Me.lblCUSTID.TabIndex = 13
        Me.lblCUSTID.Tag = "CUSTID"
        Me.lblCUSTID.Text = "lblCUSTID"
        '
        'txtCUSTID
        '
        Me.txtCUSTID.Location = New System.Drawing.Point(121, 86)
        Me.txtCUSTID.Name = "txtCUSTID"
        Me.txtCUSTID.Size = New System.Drawing.Size(112, 21)
        Me.txtCUSTID.TabIndex = 1
        Me.txtCUSTID.Tag = "CUSTID"
        Me.txtCUSTID.Text = "txtCUSTID"
        '
        'tpSign
        '
        Me.tpSign.Controls.Add(Me.btnPREVIOUS)
        Me.tpSign.Controls.Add(Me.btnNEXT)
        Me.tpSign.Controls.Add(Me.pnSignatures)
        Me.tpSign.Controls.Add(Me.pbxSIGNATURE)
        Me.tpSign.Location = New System.Drawing.Point(4, 22)
        Me.tpSign.Name = "tpSign"
        Me.tpSign.Padding = New System.Windows.Forms.Padding(3)
        Me.tpSign.Size = New System.Drawing.Size(553, 367)
        Me.tpSign.TabIndex = 1
        Me.tpSign.Tag = "tpSign"
        Me.tpSign.Text = "tpSign"
        Me.tpSign.UseVisualStyleBackColor = True
        '
        'btnPREVIOUS
        '
        Me.btnPREVIOUS.Location = New System.Drawing.Point(388, 17)
        Me.btnPREVIOUS.Name = "btnPREVIOUS"
        Me.btnPREVIOUS.Size = New System.Drawing.Size(74, 22)
        Me.btnPREVIOUS.TabIndex = 28
        Me.btnPREVIOUS.Tag = "btnPREVIOUS"
        Me.btnPREVIOUS.Text = "btnPREVIOUS"
        Me.btnPREVIOUS.UseVisualStyleBackColor = True
        '
        'btnNEXT
        '
        Me.btnNEXT.Location = New System.Drawing.Point(471, 16)
        Me.btnNEXT.Name = "btnNEXT"
        Me.btnNEXT.Size = New System.Drawing.Size(75, 23)
        Me.btnNEXT.TabIndex = 25
        Me.btnNEXT.Tag = "btnNEXT"
        Me.btnNEXT.Text = "btnNEXT"
        Me.btnNEXT.UseVisualStyleBackColor = True
        '
        'pnSignatures
        '
        Me.pnSignatures.Location = New System.Drawing.Point(6, 45)
        Me.pnSignatures.Name = "pnSignatures"
        Me.pnSignatures.Size = New System.Drawing.Size(540, 291)
        Me.pnSignatures.TabIndex = 27
        Me.pnSignatures.Tag = "pnSignatures"
        '
        'pbxSIGNATURE
        '
        Me.pbxSIGNATURE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pbxSIGNATURE.Location = New System.Drawing.Point(6, 45)
        Me.pbxSIGNATURE.Name = "pbxSIGNATURE"
        Me.pbxSIGNATURE.Size = New System.Drawing.Size(540, 303)
        Me.pbxSIGNATURE.TabIndex = 26
        Me.pbxSIGNATURE.TabStop = False
        Me.pbxSIGNATURE.Tag = ""
        '
        'frmCFLINK
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(582, 499)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.txtAUTOID)
        Me.Name = "frmCFLINK"
        Me.Text = "frmCFLINK"
        Me.Controls.SetChildIndex(Me.cboLink, 0)
        Me.Controls.SetChildIndex(Me.btnApprv, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.btnApply, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.txtAUTOID, 0)
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.tpMainInfo.ResumeLayout(False)
        Me.grbMAINLINK.ResumeLayout(False)
        Me.grbMAINLINK.PerformLayout()
        Me.tpSign.ResumeLayout(False)
        CType(Me.pbxSIGNATURE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region " Overrides Methods "
    Private Sub checkboxValue()
        If ExeFlag = ExecuteFlag.View Or ExeFlag = ExecuteFlag.Edit Then

            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_int, v_intCount, i As Integer
            Dim v_strCDCONTENT As String
            Dim v_strFLDNAME, v_strVALUE As String
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_strlinkauth As String

            Dim v_strCmdInquiry As String = "  select linkauth from CFLINK where autoid = " & Me.txtAUTOID.Text & " "
            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, "CF.CFLINK", gc_ActionInquiry, v_strCmdInquiry)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            '  For v_intCount = 0 To v_nodeList.Count - 1
            For v_int = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(v_int)
                    v_strFLDNAME = v_nodeList.Item(0).ChildNodes(v_int).Attributes.GetNamedItem("fldname").Value.Trim()
                    v_strVALUE = v_nodeList.Item(0).ChildNodes(v_int).Attributes.GetNamedItem("oldval").Value.Trim()

                    Select Case v_strFLDNAME
                        Case "linkauth"
                            v_strlinkauth = v_strVALUE

                    End Select
                End With
                ' Next
            Next
            v_strlinkauth = v_strVALUE
            Dim arrcflink As String()
            ReDim arrcflink(9)
            For i = 0 To 9
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

            End If
        End If


    End Sub
    Public Overrides Sub OnInit()
        Dim v_ctrl As Windows.Forms.Control

        Try
            MyBase.OnInit()
            txtLNPLACE.Enabled = False
            txtFULLNAME.Enabled = False
            txtADDRESS.Enabled = False
            txtLICENSENO.Enabled = False
            txtTELEPHONE.Enabled = False
            Me.dtpLNIDDATE.Enabled = False

            txtLNPLACE.Text = ""
            txtFULLNAME.Text = ""
            txtADDRESS.Text = ""
            txtLICENSENO.Text = ""
            txtTELEPHONE.Text = ""
            Me.dtpLNIDDATE.Text = Nothing

            'Load Resource Manager
            ResourceManager = New Resources.ResourceManager(gc_RootNamespace & "." & Me.Name & "-" & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
            LoadUserInterface(Me)
            ' DoFillReturnValue()
            checkboxValue()

            If ExeFlag = ExecuteFlag.Edit Or ExeFlag = ExecuteFlag.View Then
                getCustInfo()
            End If
            laodResource()
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ResourceManager.GetString("InitDialogFailed"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub
    Private Sub laodResource()

        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_int, v_intCount As Integer
        Dim v_strCDCONTENT As String
        Dim v_strFLDNAME, v_strVALUE As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strAuth() As String
        ReDim v_strAuth(10)
        Dim v_strCmdInquiry As String = "select CDCONTENT, EN_CDCONTENT from allcode where CDTYPE ='CF' AND cdname = 'LINKAUTH' ORDER BY LSTODR  "
        Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, "SA.ALLCODE", gc_ActionInquiry, v_strCmdInquiry)
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

    End Sub

    Public Overrides Sub OnSave()

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


        Dim v_strObjMsg As String

        Dim str_add As String
        str_add = Replace(Me.txtCUSTID.Text, ".", "") & "$" & Me.txtACCTNO.Text & "$" & Me.cboLINKTYPE.SelectedValue & "$" & Me.txtDESCRIPTION.Text & "$" & str_linkauth

        Try
            'Update mouse pointer
            Cursor.Current = Cursors.WaitCursor

            MyBase.OnSave()
            If Not DoDataExchange(True) Then
                Exit Sub
            End If

            Select Case ExeFlag
                Case ExecuteFlag.AddNew
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionAdhoc, , str_add, "ADDCFLINK", , , , , , , ParentObjName, ParentClause)
                    BuildXMLObjData(mv_dsInput, v_strObjMsg)

                    Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                    Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)

                    'Kiểm tra thông tin và xử lý lỗi (nếu có) từ message trả về
                    Dim v_strErrorSource, v_strErrorMessage As String

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
                    Dim v_strClause As String

                    Select Case KeyFieldType
                        Case "C"
                            v_strClause = KeyFieldName & " = '" & KeyFieldValue & "'"
                        Case "D"
                            v_strClause = KeyFieldName & " = TO_DATE('" & KeyFieldValue & "', '" & gc_FORMAT_DATE & "')"
                        Case "N"
                            v_strClause = KeyFieldName & " = " & KeyFieldValue.ToString()
                    End Select
                    Dim str_edit As String
                    str_edit = Me.txtAUTOID.Text & "$" & Me.txtCUSTID.Text & "$" & Me.txtACCTNO.Text & "$" & Me.cboLINKTYPE.SelectedValue & "$" & Me.txtDESCRIPTION.Text & "$" & str_linkauth

                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionAdhoc, , str_edit, "EDITCFLINK", , , , , , , ParentObjName, ParentClause)
                    BuildXMLObjData(mv_dsInput, v_strObjMsg)

                    Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                    Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)

                    'Kiểm tra thông tin và xử lý lỗi (nếu có) từ message trả về
                    Dim v_strErrorSource, v_strErrorMessage As String

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
            MsgBox(ResourceManager.GetString("SavingFailed"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
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

        'Sửa chỗ này cho từng form maintenance khác nhau
        If (ExeFlag = ExecuteFlag.Edit) Then
            txtAUTOID.Enabled = False
            Me.txtACCTNO.Enabled = False
        End If
        If ExeFlag = ExecuteFlag.AddNew Then
            Me.txtACCTNO.Text = mv_StrACCTNO
            Me.txtACCTNO.Enabled = False
        End If
    End Sub

    Private Sub getCustInfo()
        If txtCUSTID.Text <> "" Then
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_int, v_intCount As Integer
            Dim v_strFULLNAME, v_strIDCODE, v_strPHONE As String
            Dim v_strFLDNAME, v_strVALUE, v_strADDRESS, v_strIDDATE, v_strIDEXPIRED As String
            Dim v_strIDPLACE As String
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery

            Dim v_strCmdInquiry As String = "Select FULLNAME,IDCODE,ADDRESS,PHONE,IDDATE,IDEXPIRED,IDPLACE  from CFMAST WHERE CUSTID ='" & Replace(txtCUSTID.Text, ".", "") & "' And STATUS = 'A'"
            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, "SA.ALLCODE", gc_ActionInquiry, v_strCmdInquiry)
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
                                Case "FULLNAME"
                                    v_strFULLNAME = v_strVALUE
                                Case "ADDRESS"
                                    v_strADDRESS = v_strVALUE
                                Case "IDCODE"
                                    v_strIDCODE = v_strVALUE
                                Case "PHONE"
                                    v_strPHONE = v_strVALUE
                                Case "IDDATE"
                                    v_strIDDATE = v_strVALUE
                                Case "IDEXPIRED"
                                    v_strIDEXPIRED = v_strVALUE
                                Case "IDPLACE"
                                    v_strIDPLACE = v_strVALUE
                            End Select
                        End With
                    Next
                Next
            Else
                Cursor.Current = Cursors.Default
                MsgBox(ResourceManager.GetString("ERR_CF_CFAUTH_CUSTID_NOTFOUND"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                txtCUSTID.Focus()
                Exit Sub
            End If
            txtFULLNAME.Text = v_strFULLNAME
            txtADDRESS.Text = v_strADDRESS
            txtLICENSENO.Text = v_strIDCODE
            txtTELEPHONE.Text = v_strPHONE
            txtLNPLACE.Text = v_strIDPLACE
            Me.dtpLNIDDATE.Text = v_strIDDATE

            txtLNPLACE.Enabled = False
            txtFULLNAME.Enabled = False
            txtADDRESS.Enabled = False
            txtLICENSENO.Enabled = False
            txtTELEPHONE.Enabled = False
            Me.dtpLNIDDATE.Enabled = False

            LoadCFSign(Me.txtCUSTID.Text)
            Me.pnSignatures.Controls.Clear()
            Me.pnSignatures.Controls.Add(mv_ImageViewer)
            mv_ImageViewer.Dock = DockStyle.Fill

        End If
    End Sub

    Private Sub LoadCFSign(ByVal pv_strCustid As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim v_strSIGNATURE, v_strCUSTID As String
            If pv_strCustid <> "" Then
                'Neu nguoi uy quyen co custid tai cong ty thi khong add va edit o day.
                'Lay chu ky gan kem voi custid nay
                v_strSIGNATURE = getSIGN_CFSIGN(pv_strCustid)
            End If
            If v_strSIGNATURE.Length > 0 Then
                mv_ImageViewer.Image = GetImageFromString(v_strSIGNATURE)
            Else
                mv_ImageViewer.Image = Nothing
                mv_ImageViewer.Refresh()
            End If
            Cursor.Current = Cursors.Default

        Catch ex As Exception
            'MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Function getSIGN_CFSIGN(ByVal pv_strCustid As String) As String

        Try
            Cursor.Current = Cursors.WaitCursor
            'Dim mv_arrSIGNATURE As String
            'Neu da co chu ki trong CFSIGN thi lay ra
            Dim v_strSQL As String = "SELECT SIGNATURE FROM CFSIGN, SYSVAR SYS WHERE CUSTID = '" & pv_strCustid & "'" _
            & " AND sys.varname = 'CURRDATE' AND grname = 'SYSTEM' " _
            & " AND to_date(sys.varvalue,'DD/MM/RRRR') >= valdate AND to_date(sys.varvalue,'DD/MM/RRRR') <= expdate order by autoid desc"

            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, MyBase.LocalObject, gc_MsgTypeObj, "CF.CFSIGN", _
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

#Region " Control validations "
    Private Function ControlValidation(Optional ByVal pv_blnSaved As Boolean = False) As Boolean

        Try
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

    Private Sub txtCUSTID_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCUSTID.Validating
        getCustInfo()
    End Sub
End Class
