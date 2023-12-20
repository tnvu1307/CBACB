Imports CommonLibrary
Imports AppCore
Public Class frmCFRELATION
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
    Friend WithEvents lblCUSTID As System.Windows.Forms.Label
    Friend WithEvents lblRECUSTID As System.Windows.Forms.Label
    Friend WithEvents lblRETYPE As System.Windows.Forms.Label
    Friend WithEvents lblDESCRIPTION As System.Windows.Forms.Label
    Friend WithEvents txtAUTOID As System.Windows.Forms.TextBox
    Friend WithEvents grbCFRELATION As System.Windows.Forms.GroupBox
    Friend WithEvents txtCUSTID As FlexMaskEditBox
    Friend WithEvents txtDESCRIPTION As System.Windows.Forms.TextBox
    Friend WithEvents cboRETYPE As ComboBoxEx
    Friend WithEvents txtRECUSTID As System.Windows.Forms.TextBox
    Friend WithEvents txtFULLNAME As System.Windows.Forms.TextBox
    Friend WithEvents txtADDRESS As System.Windows.Forms.TextBox
    Friend WithEvents lblADDRESS As System.Windows.Forms.Label
    Friend WithEvents lblFULLNAME As System.Windows.Forms.Label
    Friend WithEvents txtTELEPHONE As System.Windows.Forms.TextBox
    Friend WithEvents lblLICENSENO As System.Windows.Forms.Label
    Friend WithEvents lblTELEPHONE As System.Windows.Forms.Label
    Friend WithEvents dtpLNIDDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblLNIDDATE As System.Windows.Forms.Label
    Friend WithEvents txtLNPLACE As System.Windows.Forms.TextBox
    Friend WithEvents lblLNPLACE As System.Windows.Forms.Label
    Friend WithEvents txtLICENSENO As System.Windows.Forms.TextBox
    Friend WithEvents ChartItemBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents cboACTIVE As AppCore.ComboBoxEx
    Friend WithEvents dtpACDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblACDATE As System.Windows.Forms.Label
    Friend WithEvents lblACTIVES As System.Windows.Forms.Label
    Friend WithEvents lblCustomerName As System.Windows.Forms.Label

    Friend WithEvents tbcCFAUTH As System.Windows.Forms.TabControl
    Friend WithEvents tpAuthInfo As System.Windows.Forms.TabPage
    Friend WithEvents tpSign As System.Windows.Forms.TabPage
    Friend WithEvents pbxSIGNATURE As System.Windows.Forms.PictureBox
    Friend WithEvents btnNEXT As System.Windows.Forms.Button
    Friend WithEvents btnPREVIOUS As System.Windows.Forms.Button
    Friend WithEvents txtBROWSER As System.Windows.Forms.TextBox
    Friend WithEvents DataTable31 As System.Data.DataTable
    Friend WithEvents txtHOLDING As System.Windows.Forms.TextBox
    Friend WithEvents lblHolding As System.Windows.Forms.Label
    Friend WithEvents txtEMAIL As System.Windows.Forms.TextBox
    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents DataTable32 As System.Data.DataTable
    Friend WithEvents DataTable35 As System.Data.DataTable
    Friend WithEvents lblTITLECFRELATION As System.Windows.Forms.Label
    Friend WithEvents txtTITLECFRELATION As System.Windows.Forms.TextBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents btnBROWSER As System.Windows.Forms.Button

    ' <System.Diagnostics.DebuggerStepThrough()> 
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCFRELATION))
        Me.grbCFRELATION = New System.Windows.Forms.GroupBox()
        Me.txtEMAIL = New System.Windows.Forms.TextBox()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.txtHOLDING = New System.Windows.Forms.TextBox()
        Me.lblHolding = New System.Windows.Forms.Label()
        Me.lblACDATE = New System.Windows.Forms.Label()
        Me.lblACTIVES = New System.Windows.Forms.Label()
        Me.dtpACDATE = New System.Windows.Forms.DateTimePicker()
        Me.cboACTIVE = New AppCore.ComboBoxEx()
        Me.txtLICENSENO = New System.Windows.Forms.TextBox()
        Me.dtpLNIDDATE = New System.Windows.Forms.DateTimePicker()
        Me.lblLNIDDATE = New System.Windows.Forms.Label()
        Me.txtLNPLACE = New System.Windows.Forms.TextBox()
        Me.lblLNPLACE = New System.Windows.Forms.Label()
        Me.txtTELEPHONE = New System.Windows.Forms.TextBox()
        Me.lblLICENSENO = New System.Windows.Forms.Label()
        Me.lblTELEPHONE = New System.Windows.Forms.Label()
        Me.txtFULLNAME = New System.Windows.Forms.TextBox()
        Me.txtADDRESS = New System.Windows.Forms.TextBox()
        Me.lblADDRESS = New System.Windows.Forms.Label()
        Me.lblFULLNAME = New System.Windows.Forms.Label()
        Me.txtRECUSTID = New System.Windows.Forms.TextBox()
        Me.cboRETYPE = New AppCore.ComboBoxEx()
        Me.txtDESCRIPTION = New System.Windows.Forms.TextBox()
        Me.txtCUSTID = New AppCore.FlexMaskEditBox()
        Me.lblDESCRIPTION = New System.Windows.Forms.Label()
        Me.lblRETYPE = New System.Windows.Forms.Label()
        Me.lblRECUSTID = New System.Windows.Forms.Label()
        Me.lblCUSTID = New System.Windows.Forms.Label()
        Me.lblCustomerName = New System.Windows.Forms.Label()
        Me.txtAUTOID = New System.Windows.Forms.TextBox()
        Me.ChartItemBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.tbcCFAUTH = New System.Windows.Forms.TabControl()
        Me.tpAuthInfo = New System.Windows.Forms.TabPage()
        Me.tpSign = New System.Windows.Forms.TabPage()
        Me.pbxSIGNATURE = New System.Windows.Forms.PictureBox()
        Me.btnPREVIOUS = New System.Windows.Forms.Button()
        Me.btnNEXT = New System.Windows.Forms.Button()
        Me.txtBROWSER = New System.Windows.Forms.TextBox()
        Me.btnBROWSER = New System.Windows.Forms.Button()
        Me.DataTable31 = New System.Data.DataTable()
        Me.DataTable32 = New System.Data.DataTable()
        Me.DataTable35 = New System.Data.DataTable()
        Me.lblTITLECFRELATION = New System.Windows.Forms.Label()
        Me.txtTITLECFRELATION = New System.Windows.Forms.TextBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Panel1.SuspendLayout()
        Me.grbCFRELATION.SuspendLayout()
        CType(Me.ChartItemBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbcCFAUTH.SuspendLayout()
        Me.tpAuthInfo.SuspendLayout()
        Me.tpSign.SuspendLayout()
        CType(Me.pbxSIGNATURE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable31, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable32, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable35, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(264, 414)
        Me.btnOK.Size = New System.Drawing.Size(80, 24)
        Me.btnOK.TabIndex = 20
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(436, 414)
        Me.btnCancel.Size = New System.Drawing.Size(80, 24)
        Me.btnCancel.TabIndex = 21
        '
        'lblCaption
        '
        Me.lblCaption.Location = New System.Drawing.Point(7, 17)
        '
        'btnApply
        '
        Me.btnApply.Location = New System.Drawing.Point(350, 414)
        Me.btnApply.Size = New System.Drawing.Size(80, 24)
        Me.btnApply.TabIndex = 22
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(528, 50)
        '
        'btnApprv
        '
        Me.btnApprv.Location = New System.Drawing.Point(273, 551)
        '
        'cboLink
        '
        Me.cboLink.Location = New System.Drawing.Point(8, 551)
        '
        'grbCFRELATION
        '
        Me.grbCFRELATION.Controls.Add(Me.txtTITLECFRELATION)
        Me.grbCFRELATION.Controls.Add(Me.lblTITLECFRELATION)
        Me.grbCFRELATION.Controls.Add(Me.txtEMAIL)
        Me.grbCFRELATION.Controls.Add(Me.lblEmail)
        Me.grbCFRELATION.Controls.Add(Me.txtHOLDING)
        Me.grbCFRELATION.Controls.Add(Me.lblHolding)
        Me.grbCFRELATION.Controls.Add(Me.lblACDATE)
        Me.grbCFRELATION.Controls.Add(Me.lblACTIVES)
        Me.grbCFRELATION.Controls.Add(Me.dtpACDATE)
        Me.grbCFRELATION.Controls.Add(Me.cboACTIVE)
        Me.grbCFRELATION.Controls.Add(Me.txtLICENSENO)
        Me.grbCFRELATION.Controls.Add(Me.dtpLNIDDATE)
        Me.grbCFRELATION.Controls.Add(Me.lblLNIDDATE)
        Me.grbCFRELATION.Controls.Add(Me.txtLNPLACE)
        Me.grbCFRELATION.Controls.Add(Me.lblLNPLACE)
        Me.grbCFRELATION.Controls.Add(Me.txtTELEPHONE)
        Me.grbCFRELATION.Controls.Add(Me.lblLICENSENO)
        Me.grbCFRELATION.Controls.Add(Me.lblTELEPHONE)
        Me.grbCFRELATION.Controls.Add(Me.txtFULLNAME)
        Me.grbCFRELATION.Controls.Add(Me.txtADDRESS)
        Me.grbCFRELATION.Controls.Add(Me.lblADDRESS)
        Me.grbCFRELATION.Controls.Add(Me.lblFULLNAME)
        Me.grbCFRELATION.Controls.Add(Me.txtRECUSTID)
        Me.grbCFRELATION.Controls.Add(Me.cboRETYPE)
        Me.grbCFRELATION.Controls.Add(Me.txtDESCRIPTION)
        Me.grbCFRELATION.Controls.Add(Me.txtCUSTID)
        Me.grbCFRELATION.Controls.Add(Me.lblDESCRIPTION)
        Me.grbCFRELATION.Controls.Add(Me.lblRETYPE)
        Me.grbCFRELATION.Controls.Add(Me.lblRECUSTID)
        Me.grbCFRELATION.Controls.Add(Me.lblCUSTID)
        Me.grbCFRELATION.Location = New System.Drawing.Point(6, 4)
        Me.grbCFRELATION.Name = "grbCFRELATION"
        Me.grbCFRELATION.Size = New System.Drawing.Size(511, 326)
        Me.grbCFRELATION.TabIndex = 0
        Me.grbCFRELATION.TabStop = False
        Me.grbCFRELATION.Tag = "grbCFRELATION"
        Me.grbCFRELATION.Text = "grbCFRELATION"
        '
        'txtEMAIL
        '
        Me.txtEMAIL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEMAIL.Location = New System.Drawing.Point(371, 249)
        Me.txtEMAIL.Name = "txtEMAIL"
        Me.txtEMAIL.Size = New System.Drawing.Size(135, 21)
        Me.txtEMAIL.TabIndex = 12
        Me.txtEMAIL.Tag = "EMAIL"
        Me.txtEMAIL.Text = "txtEMAIL"
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Location = New System.Drawing.Point(260, 249)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(41, 13)
        Me.lblEmail.TabIndex = 51
        Me.lblEmail.Tag = "EMAIL"
        Me.lblEmail.Text = "lblEmail"
        '
        'txtHOLDING
        '
        Me.txtHOLDING.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHOLDING.Location = New System.Drawing.Point(113, 249)
        Me.txtHOLDING.Name = "txtHOLDING"
        Me.txtHOLDING.Size = New System.Drawing.Size(133, 21)
        Me.txtHOLDING.TabIndex = 11
        Me.txtHOLDING.Tag = "HOLDING"
        Me.txtHOLDING.Text = "txtHOLDING"
        '
        'lblHolding
        '
        Me.lblHolding.AutoSize = True
        Me.lblHolding.Location = New System.Drawing.Point(6, 249)
        Me.lblHolding.Name = "lblHolding"
        Me.lblHolding.Size = New System.Drawing.Size(52, 13)
        Me.lblHolding.TabIndex = 49
        Me.lblHolding.Tag = "HOLDING"
        Me.lblHolding.Text = "lblHolding"
        '
        'lblACDATE
        '
        Me.lblACDATE.AutoSize = True
        Me.lblACDATE.Location = New System.Drawing.Point(262, 85)
        Me.lblACDATE.Name = "lblACDATE"
        Me.lblACDATE.Size = New System.Drawing.Size(57, 13)
        Me.lblACDATE.TabIndex = 48
        Me.lblACDATE.Tag = "ACDATE"
        Me.lblACDATE.Text = "lblACDATE"
        '
        'lblACTIVES
        '
        Me.lblACTIVES.AutoSize = True
        Me.lblACTIVES.Location = New System.Drawing.Point(5, 87)
        Me.lblACTIVES.Name = "lblACTIVES"
        Me.lblACTIVES.Size = New System.Drawing.Size(59, 13)
        Me.lblACTIVES.TabIndex = 47
        Me.lblACTIVES.Tag = "ACTIVES"
        Me.lblACTIVES.Text = "lblACTIVES"
        '
        'dtpACDATE
        '
        Me.dtpACDATE.CustomFormat = "dd/MM/yyyy"
        Me.dtpACDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpACDATE.Location = New System.Drawing.Point(371, 81)
        Me.dtpACDATE.Name = "dtpACDATE"
        Me.dtpACDATE.Size = New System.Drawing.Size(135, 21)
        Me.dtpACDATE.TabIndex = 4
        Me.dtpACDATE.Tag = "ACDATE"
        Me.dtpACDATE.Value = New Date(2013, 10, 2, 17, 56, 26, 0)
        '
        'cboACTIVE
        '
        Me.cboACTIVE.DisplayMember = "DISPLAY"
        Me.cboACTIVE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboACTIVE.Location = New System.Drawing.Point(113, 82)
        Me.cboACTIVE.Name = "cboACTIVE"
        Me.cboACTIVE.Size = New System.Drawing.Size(133, 21)
        Me.cboACTIVE.TabIndex = 3
        Me.cboACTIVE.Tag = "ACTIVES"
        Me.cboACTIVE.ValueMember = "VALUE"
        '
        'txtLICENSENO
        '
        Me.txtLICENSENO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLICENSENO.Location = New System.Drawing.Point(371, 184)
        Me.txtLICENSENO.Name = "txtLICENSENO"
        Me.txtLICENSENO.Size = New System.Drawing.Size(135, 21)
        Me.txtLICENSENO.TabIndex = 8
        Me.txtLICENSENO.Tag = "LICENSENO"
        '
        'dtpLNIDDATE
        '
        Me.dtpLNIDDATE.CustomFormat = "dd/MM/yyyy"
        Me.dtpLNIDDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpLNIDDATE.Location = New System.Drawing.Point(371, 214)
        Me.dtpLNIDDATE.Name = "dtpLNIDDATE"
        Me.dtpLNIDDATE.Size = New System.Drawing.Size(135, 21)
        Me.dtpLNIDDATE.TabIndex = 10
        Me.dtpLNIDDATE.Tag = "LNIDDATE"
        Me.dtpLNIDDATE.Value = New Date(2013, 10, 2, 17, 56, 26, 0)
        '
        'lblLNIDDATE
        '
        Me.lblLNIDDATE.Location = New System.Drawing.Point(260, 217)
        Me.lblLNIDDATE.Name = "lblLNIDDATE"
        Me.lblLNIDDATE.Size = New System.Drawing.Size(120, 21)
        Me.lblLNIDDATE.TabIndex = 38
        Me.lblLNIDDATE.Tag = "LNIDDATE"
        Me.lblLNIDDATE.Text = "lblLNIDDATE"
        '
        'txtLNPLACE
        '
        Me.txtLNPLACE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLNPLACE.Location = New System.Drawing.Point(113, 213)
        Me.txtLNPLACE.Name = "txtLNPLACE"
        Me.txtLNPLACE.Size = New System.Drawing.Size(133, 21)
        Me.txtLNPLACE.TabIndex = 9
        Me.txtLNPLACE.Tag = "LNPLACE"
        '
        'lblLNPLACE
        '
        Me.lblLNPLACE.AutoSize = True
        Me.lblLNPLACE.Location = New System.Drawing.Point(4, 213)
        Me.lblLNPLACE.Name = "lblLNPLACE"
        Me.lblLNPLACE.Size = New System.Drawing.Size(60, 13)
        Me.lblLNPLACE.TabIndex = 37
        Me.lblLNPLACE.Tag = "LNPLACE"
        Me.lblLNPLACE.Text = "lblLNPLACE"
        '
        'txtTELEPHONE
        '
        Me.txtTELEPHONE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTELEPHONE.Location = New System.Drawing.Point(114, 181)
        Me.txtTELEPHONE.Name = "txtTELEPHONE"
        Me.txtTELEPHONE.Size = New System.Drawing.Size(132, 21)
        Me.txtTELEPHONE.TabIndex = 7
        Me.txtTELEPHONE.Tag = "TELEPHONE"
        Me.txtTELEPHONE.Text = "txtTELEPHONE"
        '
        'lblLICENSENO
        '
        Me.lblLICENSENO.Location = New System.Drawing.Point(260, 184)
        Me.lblLICENSENO.Name = "lblLICENSENO"
        Me.lblLICENSENO.Size = New System.Drawing.Size(88, 21)
        Me.lblLICENSENO.TabIndex = 14
        Me.lblLICENSENO.Tag = "LICENSENO"
        Me.lblLICENSENO.Text = "lblLICENSENO"
        '
        'lblTELEPHONE
        '
        Me.lblTELEPHONE.Location = New System.Drawing.Point(4, 181)
        Me.lblTELEPHONE.Name = "lblTELEPHONE"
        Me.lblTELEPHONE.Size = New System.Drawing.Size(108, 21)
        Me.lblTELEPHONE.TabIndex = 12
        Me.lblTELEPHONE.Tag = "TELEPHONE"
        Me.lblTELEPHONE.Text = "lblTELEPHONE"
        '
        'txtFULLNAME
        '
        Me.txtFULLNAME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFULLNAME.Location = New System.Drawing.Point(114, 118)
        Me.txtFULLNAME.Name = "txtFULLNAME"
        Me.txtFULLNAME.Size = New System.Drawing.Size(392, 21)
        Me.txtFULLNAME.TabIndex = 5
        Me.txtFULLNAME.Tag = "FULLNAME"
        Me.txtFULLNAME.Text = "txtFULLNAME"
        '
        'txtADDRESS
        '
        Me.txtADDRESS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtADDRESS.Location = New System.Drawing.Point(114, 149)
        Me.txtADDRESS.Name = "txtADDRESS"
        Me.txtADDRESS.Size = New System.Drawing.Size(392, 21)
        Me.txtADDRESS.TabIndex = 6
        Me.txtADDRESS.Tag = "ADDRESS"
        Me.txtADDRESS.Text = "txtADDRESS"
        '
        'lblADDRESS
        '
        Me.lblADDRESS.Location = New System.Drawing.Point(4, 149)
        Me.lblADDRESS.Name = "lblADDRESS"
        Me.lblADDRESS.Size = New System.Drawing.Size(108, 21)
        Me.lblADDRESS.TabIndex = 11
        Me.lblADDRESS.Tag = "ADDRESS"
        Me.lblADDRESS.Text = "lblADDRESS"
        '
        'lblFULLNAME
        '
        Me.lblFULLNAME.Location = New System.Drawing.Point(4, 118)
        Me.lblFULLNAME.Name = "lblFULLNAME"
        Me.lblFULLNAME.Size = New System.Drawing.Size(108, 21)
        Me.lblFULLNAME.TabIndex = 10
        Me.lblFULLNAME.Tag = "FULLNAME"
        Me.lblFULLNAME.Text = "lblFULLNAME"
        '
        'txtRECUSTID
        '
        Me.txtRECUSTID.Location = New System.Drawing.Point(114, 52)
        Me.txtRECUSTID.Name = "txtRECUSTID"
        Me.txtRECUSTID.Size = New System.Drawing.Size(132, 21)
        Me.txtRECUSTID.TabIndex = 2
        Me.txtRECUSTID.Tag = "RECUSTID"
        Me.txtRECUSTID.Text = "txtRECUSTID"
        '
        'cboRETYPE
        '
        Me.cboRETYPE.DisplayMember = "DISPLAY"
        Me.cboRETYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRETYPE.Location = New System.Drawing.Point(371, 21)
        Me.cboRETYPE.Name = "cboRETYPE"
        Me.cboRETYPE.Size = New System.Drawing.Size(135, 21)
        Me.cboRETYPE.TabIndex = 1
        Me.cboRETYPE.Tag = "RETYPE"
        Me.cboRETYPE.ValueMember = "VALUE"
        '
        'txtDESCRIPTION
        '
        Me.txtDESCRIPTION.Location = New System.Drawing.Point(114, 287)
        Me.txtDESCRIPTION.Name = "txtDESCRIPTION"
        Me.txtDESCRIPTION.Size = New System.Drawing.Size(392, 21)
        Me.txtDESCRIPTION.TabIndex = 13
        Me.txtDESCRIPTION.Tag = "DESCRIPTION"
        Me.txtDESCRIPTION.Text = "txtDESCRIPTION"
        '
        'txtCUSTID
        '
        Me.txtCUSTID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCUSTID.Location = New System.Drawing.Point(114, 21)
        Me.txtCUSTID.Name = "txtCUSTID"
        Me.txtCUSTID.Size = New System.Drawing.Size(132, 21)
        Me.txtCUSTID.TabIndex = 0
        Me.txtCUSTID.Tag = "CUSTID"
        Me.txtCUSTID.Text = "txtCUSTID"
        '
        'lblDESCRIPTION
        '
        Me.lblDESCRIPTION.Location = New System.Drawing.Point(4, 287)
        Me.lblDESCRIPTION.Name = "lblDESCRIPTION"
        Me.lblDESCRIPTION.Size = New System.Drawing.Size(108, 23)
        Me.lblDESCRIPTION.TabIndex = 3
        Me.lblDESCRIPTION.Tag = "DESCRIPTION"
        Me.lblDESCRIPTION.Text = "lblDESCRIPTION"
        '
        'lblRETYPE
        '
        Me.lblRETYPE.Location = New System.Drawing.Point(263, 20)
        Me.lblRETYPE.Name = "lblRETYPE"
        Me.lblRETYPE.Size = New System.Drawing.Size(102, 23)
        Me.lblRETYPE.TabIndex = 2
        Me.lblRETYPE.Tag = "RETYPE"
        Me.lblRETYPE.Text = "lblRETYPE"
        '
        'lblRECUSTID
        '
        Me.lblRECUSTID.Location = New System.Drawing.Point(4, 52)
        Me.lblRECUSTID.Name = "lblRECUSTID"
        Me.lblRECUSTID.Size = New System.Drawing.Size(108, 23)
        Me.lblRECUSTID.TabIndex = 1
        Me.lblRECUSTID.Tag = "RECUSTID"
        Me.lblRECUSTID.Text = "lblRECUSTID"
        '
        'lblCUSTID
        '
        Me.lblCUSTID.Location = New System.Drawing.Point(4, 20)
        Me.lblCUSTID.Name = "lblCUSTID"
        Me.lblCUSTID.Size = New System.Drawing.Size(108, 23)
        Me.lblCUSTID.TabIndex = 0
        Me.lblCUSTID.Tag = "CUSTID"
        Me.lblCUSTID.Text = "lblCUSTID"
        '
        'lblCustomerName
        '
        Me.lblCustomerName.Location = New System.Drawing.Point(378, 426)
        Me.lblCustomerName.Name = "lblCustomerName"
        Me.lblCustomerName.Size = New System.Drawing.Size(100, 23)
        Me.lblCustomerName.TabIndex = 43
        '
        'txtAUTOID
        '
        Me.txtAUTOID.Location = New System.Drawing.Point(156, 553)
        Me.txtAUTOID.Name = "txtAUTOID"
        Me.txtAUTOID.Size = New System.Drawing.Size(100, 21)
        Me.txtAUTOID.TabIndex = 7
        Me.txtAUTOID.Tag = "AUTOID"
        Me.txtAUTOID.Text = "txtAUTOID"
        '
        'ChartItemBindingSource
        '
        'Me.ChartItemBindingSource.DataSource = GetType(_DIRECT.WebStockTicker.ChartItem)
        '
        'tbcCFAUTH
        '
        Me.tbcCFAUTH.Controls.Add(Me.tpAuthInfo)
        Me.tbcCFAUTH.Controls.Add(Me.tpSign)
        Me.tbcCFAUTH.Location = New System.Drawing.Point(0, 56)
        Me.tbcCFAUTH.Name = "tbcCFAUTH"
        Me.tbcCFAUTH.SelectedIndex = 0
        Me.tbcCFAUTH.Size = New System.Drawing.Size(527, 402)
        Me.tbcCFAUTH.TabIndex = 3
        Me.tbcCFAUTH.Tag = "tbcCFAUTH"
        '
        'tpAuthInfo
        '
        Me.tpAuthInfo.BackColor = System.Drawing.SystemColors.Control
        Me.tpAuthInfo.Controls.Add(Me.grbCFRELATION)
        Me.tpAuthInfo.Location = New System.Drawing.Point(4, 22)
        Me.tpAuthInfo.Name = "tpAuthInfo"
        Me.tpAuthInfo.Size = New System.Drawing.Size(519, 376)
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
        Me.tpSign.Size = New System.Drawing.Size(519, 376)
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
        Me.pbxSIGNATURE.Size = New System.Drawing.Size(490, 254)
        Me.pbxSIGNATURE.TabIndex = 0
        Me.pbxSIGNATURE.TabStop = False
        Me.pbxSIGNATURE.Tag = "SIGNATURE"
        '
        'btnPREVIOUS
        '
        Me.btnPREVIOUS.Location = New System.Drawing.Point(4, 293)
        Me.btnPREVIOUS.Name = "btnPREVIOUS"
        Me.btnPREVIOUS.Size = New System.Drawing.Size(74, 22)
        Me.btnPREVIOUS.TabIndex = 24
        Me.btnPREVIOUS.Tag = "btnPREVIOUS"
        Me.btnPREVIOUS.Text = "btnPREVIOUS"
        Me.btnPREVIOUS.UseVisualStyleBackColor = True
        Me.btnPREVIOUS.Visible = False
        '
        'btnNEXT
        '
        Me.btnNEXT.Location = New System.Drawing.Point(84, 293)
        Me.btnNEXT.Name = "btnNEXT"
        Me.btnNEXT.Size = New System.Drawing.Size(75, 23)
        Me.btnNEXT.TabIndex = 0
        Me.btnNEXT.Tag = "btnNEXT"
        Me.btnNEXT.Text = "btnNEXT"
        Me.btnNEXT.UseVisualStyleBackColor = True
        Me.btnNEXT.Visible = False
        '
        'txtBROWSER
        '
        Me.txtBROWSER.Location = New System.Drawing.Point(84, 6)
        Me.txtBROWSER.Name = "txtBROWSER"
        Me.txtBROWSER.Size = New System.Drawing.Size(410, 21)
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
        'DataTable35
        '
        Me.DataTable35.Namespace = ""
        Me.DataTable35.TableName = "COMBOBOX"
        '
        'lblTITLECFRELATION
        '
        Me.lblTITLECFRELATION.AutoSize = True
        Me.lblTITLECFRELATION.Location = New System.Drawing.Point(262, 52)
        Me.lblTITLECFRELATION.Name = "lblTITLECFRELATION"
        Me.lblTITLECFRELATION.Size = New System.Drawing.Size(107, 13)
        Me.lblTITLECFRELATION.TabIndex = 52
        Me.lblTITLECFRELATION.Tag = "TITLECFRELATION"
        Me.lblTITLECFRELATION.Text = "lblTITLECFRELATION"
        '
        'txtTITLECFRELATION
        '
        Me.txtTITLECFRELATION.Location = New System.Drawing.Point(371, 49)
        Me.txtTITLECFRELATION.Name = "txtTITLECFRELATION"
        Me.txtTITLECFRELATION.Size = New System.Drawing.Size(134, 21)
        Me.txtTITLECFRELATION.TabIndex = 53
        Me.txtTITLECFRELATION.Tag = "TITLECFRELATION"
        Me.txtTITLECFRELATION.Text = "txtTITLECFRELATION"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'frmCFRELATION
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(528, 460)
        Me.Controls.Add(Me.txtAUTOID)
        Me.Controls.Add(Me.lblCustomerName)
        Me.Controls.Add(Me.tbcCFAUTH)
        Me.Name = "frmCFRELATION"
        Me.Text = "frmCFRELATION"
        Me.Controls.SetChildIndex(Me.tbcCFAUTH, 0)
        Me.Controls.SetChildIndex(Me.lblCustomerName, 0)
        Me.Controls.SetChildIndex(Me.btnApprv, 0)
        Me.Controls.SetChildIndex(Me.btnApply, 0)
        Me.Controls.SetChildIndex(Me.cboLink, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.txtAUTOID, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.grbCFRELATION.ResumeLayout(False)
        Me.grbCFRELATION.PerformLayout()
        CType(Me.ChartItemBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbcCFAUTH.ResumeLayout(False)
        Me.tpAuthInfo.ResumeLayout(False)
        Me.tpSign.ResumeLayout(False)
        Me.tpSign.PerformLayout()
        CType(Me.pbxSIGNATURE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable31, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable32, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable35, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region " Declare constants and variables "
    Private mv_CustomerId As String
    Public mv_CustomerName As String
#End Region

#Region " Properties "
    Public Property CustomerId() As String
        Get
            Return mv_CustomerId
        End Get
        Set(ByVal Value As String)
            mv_CustomerId = Value
        End Set
    End Property

#End Region

#Region "Private method"
    Private Sub GetCustomerInfor(ByVal pv_strCustID As String)
        Try
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
            Dim v_strSQL, v_strObjMsg, v_strValue, v_strFLDNAME As String
            v_strSQL = "SELECT  FULLNAME CUSTNAME, ADDRESS,EMAIL,PHONE,MOBILE,FAX,STATUS, CAREBY  FROM CFMAST WHERE CUSTID = '" & pv_strCustID & "'"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_AFMAST, gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Count - 1
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = Trim(.InnerText.ToString)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "CUSTNAME"
                                mv_CustomerName = v_strValue
                        End Select
                    End With
                Next
            Next
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                                    & "Error code: System error!" & vbNewLine _
                                    & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ResourceManager.GetString("SavingFailed"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub getCustInfo()
        'If txtRECUSTID.Text <> "" Then
        'If txtRECUSTID.Text.Trim = txtCUSTID.Text.Trim Then
        '    MsgBox(ResourceManager.GetString("msgCUSAUTHORGCUS"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        '    Me.txtCUSTID.Focus()
        '    Exit Sub
        'Else
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_int, v_intCount As Integer
        Dim v_strFULLNAME, v_strIDCODE, v_strPHONE, v_strEMAIL, v_strHOLD As String
        Dim v_strFLDNAME, v_strVALUE, v_strADDRESS, v_strIDDATE, v_strIDEXPIRED As String
        Dim v_strIDPLACE As String
        Dim v_strACDATE As String
        Dim v_strACTIVES As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        'Trim(CType(ISSUERGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value)
        Dim v_strCmdInquiry As String
        If txtRECUSTID.Text <> "" And ExeFlag = ExecuteFlag.AddNew Then
            v_strCmdInquiry = "Select FULLNAME,IDCODE,ADDRESS,MOBILESMS PHONE,EMAIL,IDDATE,IDEXPIRED,IDPLACE from CFMAST WHERE CUSTID='" & Replace(txtRECUSTID.Text, ".", "") & "' "
            'v_strCmdInquiry = "Select FULLNAME,ACTIVES, LICENSENO IDCODE,ADDRESS, TELEPHONE PHONE, LNIDDATE IDDATE,ACDATE ACDATE,LNPLACE IDPLACE  from CFRELATION where autoid = '" & KeyFieldValue & "' "
        ElseIf txtRECUSTID.Text.Length > 0 And (ExeFlag = ExecuteFlag.Edit Or ExeFlag = ExecuteFlag.View) Then
            v_strCmdInquiry = "Select CF.FULLNAME,CF.IDCODE,CFR.ACTIVES ACTIVES,CASE WHEN CFR.EMAIL IS NULL THEN CF.EMAIL ELSE CFR.EMAIL END EMAIL,CFR.ACDATE ACDATE,CF.ADDRESS,CASE WHEN CFR.TELEPHONE IS NULL THEN CF.MOBILESMS ELSE CFR.TELEPHONE END PHONE,CF.IDDATE,CF.IDEXPIRED,CFR.HOLDING,CF.IDPLACE " _
                            & "from CFMAST CF,CFRELATION CFR WHERE TRIM(CF.CUSTID) = TRIM(CFR.recustid(+)) AND CFR.CUSTID='" & Trim(Replace(txtCUSTID.Text, ".", "")) & "'AND CF.CUSTID='" & Trim(Replace(txtRECUSTID.Text, ".", "")) & "' "
        Else
            v_strCmdInquiry = "Select FULLNAME,ACTIVES, LICENSENO IDCODE,ADDRESS, TELEPHONE PHONE, LNIDDATE IDDATE,ACDATE ACDATE,LNPLACE IDPLACE,HOLDING,EMAIL  from CFRELATION where autoid = '" & KeyFieldValue & "' "
        End If
        If ExeFlag = ExecuteFlag.View Then
            txtEMAIL.ReadOnly = True
            txtHOLDING.ReadOnly = True
        Else
            txtEMAIL.ReadOnly = False
            txtHOLDING.ReadOnly = False
        End If
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
                            Case "ACTIVES"
                                v_strACTIVES = v_strVALUE
                            Case "EMAIL"
                                v_strEMAIL = v_strVALUE
                            Case "HOLDING"
                                v_strHOLD = v_strVALUE
                            Case "PHONE"
                                v_strPHONE = v_strVALUE
                            Case "ACDATE"
                                v_strACDATE = v_strVALUE
                            Case "IDDATE"
                                v_strIDDATE = v_strVALUE
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
        txtEMAIL.Text = v_strEMAIL
        txtLICENSENO.Text = v_strIDCODE
        txtTELEPHONE.Text = v_strPHONE
        txtLNPLACE.Text = v_strIDPLACE
        Me.dtpLNIDDATE.Text = v_strIDDATE
        txtHOLDING.Text = v_strHOLD
        lblCustomerName.Text = v_strFULLNAME
        If ExeFlag = ExecuteFlag.Edit Or ExeFlag = ExecuteFlag.View Then
            cboACTIVE.SelectedValue = v_strACTIVES
            Me.dtpACDATE.Text = v_strACDATE
        End If
        'txtLNPLACE.Enabled = False
        'txtFULLNAME.Enabled = False
        'txtADDRESS.Enabled = False
        'txtLICENSENO.Enabled = False
        'txtTELEPHONE.Enabled = False
        'Me.dtpLNIDDATE.Enabled = False

        'End If
        'End If
    End Sub

    Private Function checkRelationType() As Boolean
        Dim v_strCmdInquiri As String
        Dim v_strObjMsg As String
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_int, v_intCount, v_Count As Integer
        Dim v_strFULLNAME, v_strIDCODE, v_strPHONE As String
        Dim v_strRETYPE As String
        Dim v_strACDATE As String
        Dim v_strFLDNAME, v_strVALUE, v_strADDRESS, v_strIDDATE, v_strIDEXPIRED As String
        Dim v_strCmdInquiry, v_strReturn As String
        Try
            v_strCmdInquiri = "Select COUNT(*) CNT from CFRELATION where ACTIVES='Y' AND RETYPE='" & cboRETYPE.SelectedValue & "' AND RECUSTID <> '" & txtRECUSTID.Text & "'  AND CUSTID = '" & txtCUSTID.Text & "' "
            Dim v_strObjMsgs As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, "SA.ALLCODE", gc_ActionInquiry, v_strCmdInquiri)
            Dim v_wt As New BDSDeliveryManagement
            v_wt.Message(v_strObjMsgs)
            v_xmlDocument.LoadXml(v_strObjMsgs)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            If v_nodeList.Count > 0 Then
                For v_intCount = 0 To v_nodeList.Count - 1
                    For v_int = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                        With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                            v_strFLDNAME = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("fldname").Value.Trim()
                            v_strVALUE = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("oldval").Value.Trim()

                            Select Case v_strFLDNAME
                                Case "CNT"
                                    v_Count = v_strVALUE
                            End Select

                        End With
                    Next
                Next
            End If

            If v_Count > 0 Then
                Return False
            End If
            Return True

            'If (cboRETYPE.SelectedIndex = 0 And v_strRETYPE = "009") Then
            '    'MsgBox(ResourceManager.GetString("Error009"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            '    'Me.DialogResult = DialogResult.OK
            '    'MyBase.OnClose()
            '    v_strReturn = ResourceManager.GetString("Error009")
            '    Return v_strReturn
            'ElseIf (cboRETYPE.SelectedIndex = 1 And v_strRETYPE = "010") Then
            '    'MsgBox(ResourceManager.GetString("Error010"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            '    'Me.DialogResult = DialogResult.OK
            '    'MyBase.OnClose()
            '    v_strReturn = ResourceManager.GetString("Error009")
            '    Return v_strReturn
            'ElseIf (cboRETYPE.SelectedIndex = 1 And v_strRETYPE = "011") Then
            '    'MsgBox(ResourceManager.GetString("Error011"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            '    'Me.DialogResult = DialogResult.OK
            '    'MyBase.OnClose()
            '    v_strReturn = ResourceManager.GetString("Error009")
            '    Return v_strReturn
            'ElseIf (cboRETYPE.SelectedIndex = 1 And v_nodeList.Count = 2) Then
            '    'MsgBox(ResourceManager.GetString("ErrorNodeList010"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            '    'Me.DialogResult = DialogResult.OK
            '    'MyBase.OnClose()
            '    v_strReturn = ResourceManager.GetString("Error009")
            '    Return v_strReturn
            'ElseIf (cboRETYPE.SelectedIndex = 0 And v_nodeList.Count = 2) Then
            '    'MsgBox(ResourceManager.GetString("ErrorNodeList010"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            '    'Me.DialogResult = DialogResult.OK
            '    'MyBase.OnClose()
            '    v_strReturn = ResourceManager.GetString("Error009")
            '    Return v_strReturn
            'ElseIf (cboRETYPE.SelectedIndex = 0 And v_nodeList.Count = 2) Then
            '    v_strReturn = ResourceManager.GetString("Error009")
            '    Return v_strReturn
            'End If

            Return "0"
        Catch ex As Exception
            Return False
        End Try


    End Function

#End Region

#Region " Overrides Methods "
    Public Overrides Sub OnInit()
        Dim v_ctrl As Windows.Forms.Control
        Dim v_strSQL, v_strObjMsg As String
        Try
            MyBase.OnInit()
            'txtLNPLACE.Enabled = False
            'txtFULLNAME.Enabled = False
            'txtADDRESS.Enabled = False
            'txtLICENSENO.Enabled = False
            'txtTELEPHONE.Enabled = False
            'Me.dtpLNIDDATE.Enabled = False

            lblHolding.ForeColor = lblFULLNAME.ForeColor
            lblEmail.ForeColor = lblFULLNAME.ForeColor
            txtLNPLACE.Text = ""
            txtFULLNAME.Text = ""
            txtADDRESS.Text = ""
            txtLICENSENO.Text = ""
            txtTELEPHONE.Text = ""
            txtEMAIL.Text = ""
            txtHOLDING.Text = ""
            Me.dtpLNIDDATE.Text = Nothing
            Me.dtpACDATE.Text = Nothing
            Dim v_wsAR As New BDSDeliveryManagement

            If ExeFlag = ExecuteFlag.Edit Or ExeFlag = ExecuteFlag.View Then
                getCustInfo()
            End If
            'Load Resource Manager
            ResourceManager = New Resources.ResourceManager(gc_RootNamespace & "." & Me.Name & "-" & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
            LoadUserInterface(Me)
            Me.lblCustomerName.Text = mv_CustomerName
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ResourceManager.GetString("InitDialogFailed"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Public Overrides Sub OnSave()
        Dim v_strObjMsg As String
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_int, v_intCount As Integer
        Dim v_strFULLNAME, v_strIDCODE, v_strPHONE, v_strEMAIL, v_strHOLD As String
        Dim v_strRETYPE As String
        Dim v_strACDATE As String
        Dim v_strFLDNAME, v_strVALUE, v_strADDRESS, v_strIDDATE, v_strIDEXPIRED As String
        Dim v_strCmdInquiri As String
        Dim v_strCmdInquiry As String
        Try
            'Update mouse pointer
            Cursor.Current = Cursors.WaitCursor

            MyBase.OnSave()
            If Not DoDataExchange(True) Then
                Exit Sub
            End If

            If checkRelationType() = False Then
                MsgBox(ResourceManager.GetString("msgDuplicateRelationType"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                Me.cboRETYPE.Focus()
                Exit Sub
            End If

            'thunt-2019-25-09: refcustid <> custid
            If txtRECUSTID.Text.Trim = txtCUSTID.Text.Trim Then
                MsgBox(ResourceManager.GetString("msgCUSAUTHORGCUS"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                Me.txtRECUSTID.Focus()
                Exit Sub
            End If

            
            Select Case ExeFlag
                Case ExecuteFlag.AddNew

                    'If checkRelationType() = False Then
                    '    MsgBox(ResourceManager.GetString("msgDuplicateRelationType"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    '    Me.txtRECUSTID.Focus()
                    '    Exit Sub
                    'End If

                    Dim v_strObjMsgt As String
                    v_strObjMsgt = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionAdd, , , , gc_AutoIdUsed, , , , , , ParentObjName, ParentClause)
                    BuildXMLObjData(mv_dsInput, v_strObjMsgt)

                    Dim v_wa As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                    Dim v_lngErrorCode As Long = v_wa.Message(v_strObjMsgt)

                    'Ki?m tra thông tin và x? lý l?i (n?u có) t? message tr? v?
                    Dim v_strErrorSource, v_strErrorMessage As String

                    GetErrorFromMessage(v_strObjMsgt, v_strErrorSource, v_lngErrorCode, v_strErrorMessage)
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
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionEdit, , v_strClause, , , , , , , , ParentObjName, ParentClause)
                    BuildXMLObjData(mv_dsInput, v_strObjMsg, mv_dsOldInput, ExecuteFlag.Edit)

                    Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                    Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)

                    'Ki?m tra thông tin và x? lý l?i (n?u có) t? message tr? v?
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
        If (ExeFlag = ExecuteFlag.AddNew) Then
            txtCUSTID.Text = CustomerId
            txtCUSTID.Enabled = False
        ElseIf (ExeFlag = ExecuteFlag.Edit) Then
            txtCUSTID.Text = CustomerId
            txtCUSTID.Enabled = False
        End If
    End Sub
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

    Private Sub txtRECUSTID_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtRECUSTID.Validating
        txtRECUSTID.Text = Replace(txtRECUSTID.Text, ".", "")
        getCustInfo()
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
                'mv_lngFileSize = FileLen(v_oFileDlg.FileName)
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
               & "Error code: System error!" & vbNewLine _
               & "Error message: " & ex.Message, EventLogEntryType.Error)
            'MessageBox.Show(mv_ResourceManager.GetString("frmReceiverData.CannotOpenFile"), Me.FormCaption, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

    End Sub

    Private Sub btnApply_Click(sender As Object, e As EventArgs) Handles btnApply.Click

    End Sub
End Class
