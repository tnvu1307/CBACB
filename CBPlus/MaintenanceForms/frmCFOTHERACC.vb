Imports AppCore
Imports CommonLibrary

Public Class frmCFOTHERACC
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
    Friend WithEvents txtAUTOID As System.Windows.Forms.TextBox
    Friend WithEvents txtBankAcc As System.Windows.Forms.TextBox
    Friend WithEvents lblBankACName As System.Windows.Forms.Label
    Friend WithEvents txtBankACName As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents cboTYPE As AppCore.ComboBoxEx
    Friend WithEvents grpParameter As System.Windows.Forms.GroupBox
    Friend WithEvents lblBANKNAME As System.Windows.Forms.Label
    Friend WithEvents lblTYPE As System.Windows.Forms.Label
    Friend WithEvents txtBankName As System.Windows.Forms.TextBox
    Friend WithEvents txtCustID As FlexMaskEditBox
    Friend WithEvents lblCustID As System.Windows.Forms.Label
    Friend WithEvents lblACNIDCODE As System.Windows.Forms.Label
    Friend WithEvents lblACNIDDATE As System.Windows.Forms.Label
    Friend WithEvents txtACNIDCODE As System.Windows.Forms.TextBox
    Friend WithEvents txtACNIDPLACE As System.Windows.Forms.TextBox
    Friend WithEvents lblACNIDPLACE As System.Windows.Forms.Label
    Friend WithEvents txtFEECD As AppCore.FlexMaskEditBox
    Friend WithEvents lblFEECD As System.Windows.Forms.Label
    Friend WithEvents txtFEENAME As System.Windows.Forms.TextBox
    Friend WithEvents txtCityName As System.Windows.Forms.TextBox
    Friend WithEvents lblCityName As System.Windows.Forms.Label
    Friend WithEvents lblCityBank As System.Windows.Forms.Label
    Friend WithEvents txtCityBank As System.Windows.Forms.TextBox
    Friend WithEvents txtCFCUSTID As System.Windows.Forms.TextBox
    Friend WithEvents lblCFCUSTID As System.Windows.Forms.Label
    Friend WithEvents txtBANKCODE As FlexMaskEditBox
    Friend WithEvents lblBANKCODE As System.Windows.Forms.Label
    Friend WithEvents lblBankAcc As System.Windows.Forms.Label
    Friend WithEvents cmbDEFAULTACCT As AppCore.ComboBoxEx
    Friend WithEvents lblDEFAULTACCT As System.Windows.Forms.Label
    Friend WithEvents DataTable21 As System.Data.DataTable
    Friend WithEvents DataTable34 As System.Data.DataTable
    Friend WithEvents DataTable35 As System.Data.DataTable
    Friend WithEvents dtpACNIDDATE As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DataTable42 As System.Data.DataTable
    Friend WithEvents DataTable50 As System.Data.DataTable
    Friend WithEvents txtISBANKACCTNO As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCFOTHERACC))
        Me.txtAUTOID = New System.Windows.Forms.TextBox()
        Me.txtBankAcc = New System.Windows.Forms.TextBox()
        Me.lblBankACName = New System.Windows.Forms.Label()
        Me.txtBankACName = New System.Windows.Forms.TextBox()
        Me.cboTYPE = New AppCore.ComboBoxEx()
        Me.grpParameter = New System.Windows.Forms.GroupBox()
        Me.dtpACNIDDATE = New DevExpress.XtraEditors.DateEdit()
        Me.cmbDEFAULTACCT = New AppCore.ComboBoxEx()
        Me.lblDEFAULTACCT = New System.Windows.Forms.Label()
        Me.txtISBANKACCTNO = New System.Windows.Forms.TextBox()
        Me.txtBANKCODE = New AppCore.FlexMaskEditBox()
        Me.lblBANKCODE = New System.Windows.Forms.Label()
        Me.lblCityBank = New System.Windows.Forms.Label()
        Me.txtCityBank = New System.Windows.Forms.TextBox()
        Me.txtCityName = New System.Windows.Forms.TextBox()
        Me.lblCityName = New System.Windows.Forms.Label()
        Me.txtFEENAME = New System.Windows.Forms.TextBox()
        Me.txtFEECD = New AppCore.FlexMaskEditBox()
        Me.lblFEECD = New System.Windows.Forms.Label()
        Me.txtACNIDPLACE = New System.Windows.Forms.TextBox()
        Me.lblACNIDPLACE = New System.Windows.Forms.Label()
        Me.lblACNIDDATE = New System.Windows.Forms.Label()
        Me.txtACNIDCODE = New System.Windows.Forms.TextBox()
        Me.lblACNIDCODE = New System.Windows.Forms.Label()
        Me.lblCustID = New System.Windows.Forms.Label()
        Me.txtCustID = New AppCore.FlexMaskEditBox()
        Me.txtBankName = New System.Windows.Forms.TextBox()
        Me.lblBANKNAME = New System.Windows.Forms.Label()
        Me.lblBankAcc = New System.Windows.Forms.Label()
        Me.lblTYPE = New System.Windows.Forms.Label()
        Me.txtCFCUSTID = New System.Windows.Forms.TextBox()
        Me.lblCFCUSTID = New System.Windows.Forms.Label()
        Me.DataTable21 = New System.Data.DataTable()
        Me.DataTable34 = New System.Data.DataTable()
        Me.DataTable35 = New System.Data.DataTable()
        Me.DataTable42 = New System.Data.DataTable()
        Me.DataTable50 = New System.Data.DataTable()
        Me.Panel1.SuspendLayout()
        Me.grpParameter.SuspendLayout()
        CType(Me.dtpACNIDDATE.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpACNIDDATE.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable34, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable35, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable42, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable50, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(279, 389)
        Me.btnOK.Size = New System.Drawing.Size(77, 24)
        Me.btnOK.TabIndex = 15
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(445, 389)
        Me.btnCancel.Size = New System.Drawing.Size(77, 24)
        Me.btnCancel.TabIndex = 17
        '
        'btnApply
        '
        Me.btnApply.Location = New System.Drawing.Point(362, 389)
        Me.btnApply.Size = New System.Drawing.Size(77, 24)
        Me.btnApply.TabIndex = 16
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(557, 50)
        Me.Panel1.TabIndex = 3
        '
        'btnApprv
        '
        Me.btnApprv.Location = New System.Drawing.Point(750, 152)
        '
        'cboLink
        '
        Me.cboLink.Location = New System.Drawing.Point(750, 187)
        '
        'txtAUTOID
        '
        Me.txtAUTOID.Location = New System.Drawing.Point(750, 214)
        Me.txtAUTOID.Name = "txtAUTOID"
        Me.txtAUTOID.Size = New System.Drawing.Size(100, 21)
        Me.txtAUTOID.TabIndex = 28
        Me.txtAUTOID.Tag = "AUTOID"
        Me.txtAUTOID.Text = "txtAUTOID"
        Me.txtAUTOID.Visible = False
        '
        'txtBankAcc
        '
        Me.txtBankAcc.Location = New System.Drawing.Point(372, 14)
        Me.txtBankAcc.Name = "txtBankAcc"
        Me.txtBankAcc.Size = New System.Drawing.Size(151, 21)
        Me.txtBankAcc.TabIndex = 4
        Me.txtBankAcc.Tag = "BANKACC"
        '
        'lblBankACName
        '
        Me.lblBankACName.Location = New System.Drawing.Point(12, 43)
        Me.lblBankACName.Name = "lblBankACName"
        Me.lblBankACName.Size = New System.Drawing.Size(100, 23)
        Me.lblBankACName.TabIndex = 36
        Me.lblBankACName.Tag = "BANKACNAME"
        Me.lblBankACName.Text = "lblBankACName"
        '
        'txtBankACName
        '
        Me.txtBankACName.Enabled = False
        Me.txtBankACName.Location = New System.Drawing.Point(135, 40)
        Me.txtBankACName.Name = "txtBankACName"
        Me.txtBankACName.Size = New System.Drawing.Size(388, 21)
        Me.txtBankACName.TabIndex = 5
        Me.txtBankACName.Tag = "BANKACNAME"
        '
        'cboTYPE
        '
        Me.cboTYPE.DisplayMember = "DISPLAY"
        Me.cboTYPE.Location = New System.Drawing.Point(138, 56)
        Me.cboTYPE.Name = "cboTYPE"
        Me.cboTYPE.Size = New System.Drawing.Size(388, 21)
        Me.cboTYPE.TabIndex = 0
        Me.cboTYPE.Tag = "TYPE"
        Me.cboTYPE.ValueMember = "VALUE"
        '
        'grpParameter
        '
        Me.grpParameter.Controls.Add(Me.dtpACNIDDATE)
        Me.grpParameter.Controls.Add(Me.cmbDEFAULTACCT)
        Me.grpParameter.Controls.Add(Me.lblDEFAULTACCT)
        Me.grpParameter.Controls.Add(Me.txtISBANKACCTNO)
        Me.grpParameter.Controls.Add(Me.txtBANKCODE)
        Me.grpParameter.Controls.Add(Me.lblBANKCODE)
        Me.grpParameter.Controls.Add(Me.lblCityBank)
        Me.grpParameter.Controls.Add(Me.txtCityBank)
        Me.grpParameter.Controls.Add(Me.txtCityName)
        Me.grpParameter.Controls.Add(Me.lblCityName)
        Me.grpParameter.Controls.Add(Me.txtFEENAME)
        Me.grpParameter.Controls.Add(Me.txtFEECD)
        Me.grpParameter.Controls.Add(Me.lblFEECD)
        Me.grpParameter.Controls.Add(Me.txtACNIDPLACE)
        Me.grpParameter.Controls.Add(Me.lblACNIDPLACE)
        Me.grpParameter.Controls.Add(Me.lblACNIDDATE)
        Me.grpParameter.Controls.Add(Me.txtACNIDCODE)
        Me.grpParameter.Controls.Add(Me.lblACNIDCODE)
        Me.grpParameter.Controls.Add(Me.lblCustID)
        Me.grpParameter.Controls.Add(Me.txtCustID)
        Me.grpParameter.Controls.Add(Me.txtBankName)
        Me.grpParameter.Controls.Add(Me.lblBANKNAME)
        Me.grpParameter.Controls.Add(Me.txtBankAcc)
        Me.grpParameter.Controls.Add(Me.lblBankAcc)
        Me.grpParameter.Controls.Add(Me.txtBankACName)
        Me.grpParameter.Controls.Add(Me.lblBankACName)
        Me.grpParameter.Location = New System.Drawing.Point(4, 85)
        Me.grpParameter.Name = "grpParameter"
        Me.grpParameter.Size = New System.Drawing.Size(534, 286)
        Me.grpParameter.TabIndex = 1
        Me.grpParameter.TabStop = False
        Me.grpParameter.Tag = "PARAMETER"
        Me.grpParameter.Text = "grpParameter"
        '
        'dtpACNIDDATE
        '
        Me.dtpACNIDDATE.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.dtpACNIDDATE.EditValue = Nothing
        Me.dtpACNIDDATE.Location = New System.Drawing.Point(383, 147)
        Me.dtpACNIDDATE.Name = "dtpACNIDDATE"
        Me.dtpACNIDDATE.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
        Me.dtpACNIDDATE.Properties.Appearance.Options.UseBackColor = True
        Me.dtpACNIDDATE.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.dtpACNIDDATE.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtpACNIDDATE.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtpACNIDDATE.Size = New System.Drawing.Size(142, 20)
        Me.dtpACNIDDATE.TabIndex = 66
        Me.dtpACNIDDATE.Tag = "ACNIDDATE"
        '
        'cmbDEFAULTACCT
        '
        Me.cmbDEFAULTACCT.DisplayMember = "DISPLAY"
        Me.cmbDEFAULTACCT.FormattingEnabled = True
        Me.cmbDEFAULTACCT.Location = New System.Drawing.Point(135, 198)
        Me.cmbDEFAULTACCT.Name = "cmbDEFAULTACCT"
        Me.cmbDEFAULTACCT.Size = New System.Drawing.Size(121, 21)
        Me.cmbDEFAULTACCT.TabIndex = 69
        Me.cmbDEFAULTACCT.Tag = "DEFAULTACCT"
        Me.cmbDEFAULTACCT.ValueMember = "VALUE"
        '
        'lblDEFAULTACCT
        '
        Me.lblDEFAULTACCT.AutoSize = True
        Me.lblDEFAULTACCT.Location = New System.Drawing.Point(12, 206)
        Me.lblDEFAULTACCT.Name = "lblDEFAULTACCT"
        Me.lblDEFAULTACCT.Size = New System.Drawing.Size(88, 13)
        Me.lblDEFAULTACCT.TabIndex = 68
        Me.lblDEFAULTACCT.Tag = "DEFAULTACCT"
        Me.lblDEFAULTACCT.Text = "lblDEFAULTACCT"
        '
        'txtISBANKACCTNO
        '
        Me.txtISBANKACCTNO.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtISBANKACCTNO.Location = New System.Drawing.Point(134, 225)
        Me.txtISBANKACCTNO.Name = "txtISBANKACCTNO"
        Me.txtISBANKACCTNO.ReadOnly = True
        Me.txtISBANKACCTNO.Size = New System.Drawing.Size(66, 21)
        Me.txtISBANKACCTNO.TabIndex = 66
        Me.txtISBANKACCTNO.Tag = "ISBANKACCTNO"
        Me.txtISBANKACCTNO.Text = "Y"
        Me.txtISBANKACCTNO.Visible = False
        '
        'txtBANKCODE
        '
        Me.txtBANKCODE.Enabled = False
        Me.txtBANKCODE.Location = New System.Drawing.Point(135, 66)
        Me.txtBANKCODE.Name = "txtBANKCODE"
        Me.txtBANKCODE.Size = New System.Drawing.Size(90, 21)
        Me.txtBANKCODE.TabIndex = 6
        Me.txtBANKCODE.Tag = "BANKCODE"
        Me.txtBANKCODE.Text = "txtBANKCODE"
        '
        'lblBANKCODE
        '
        Me.lblBANKCODE.Location = New System.Drawing.Point(12, 69)
        Me.lblBANKCODE.Name = "lblBANKCODE"
        Me.lblBANKCODE.Size = New System.Drawing.Size(100, 23)
        Me.lblBANKCODE.TabIndex = 65
        Me.lblBANKCODE.Tag = "BANKCODE"
        Me.lblBANKCODE.Text = "lblBANKCODE"
        '
        'lblCityBank
        '
        Me.lblCityBank.ForeColor = System.Drawing.Color.Blue
        Me.lblCityBank.Location = New System.Drawing.Point(272, 122)
        Me.lblCityBank.Name = "lblCityBank"
        Me.lblCityBank.Size = New System.Drawing.Size(100, 23)
        Me.lblCityBank.TabIndex = 63
        Me.lblCityBank.Tag = "CITYBANK"
        Me.lblCityBank.Text = "lblCityBank"
        '
        'txtCityBank
        '
        Me.txtCityBank.Enabled = False
        Me.txtCityBank.Location = New System.Drawing.Point(383, 119)
        Me.txtCityBank.Name = "txtCityBank"
        Me.txtCityBank.Size = New System.Drawing.Size(142, 21)
        Me.txtCityBank.TabIndex = 9
        Me.txtCityBank.Tag = "CITYBANK"
        '
        'txtCityName
        '
        Me.txtCityName.Enabled = False
        Me.txtCityName.Location = New System.Drawing.Point(135, 119)
        Me.txtCityName.Name = "txtCityName"
        Me.txtCityName.Size = New System.Drawing.Size(131, 21)
        Me.txtCityName.TabIndex = 8
        Me.txtCityName.Tag = "CITYEF"
        '
        'lblCityName
        '
        Me.lblCityName.ForeColor = System.Drawing.Color.Blue
        Me.lblCityName.Location = New System.Drawing.Point(12, 122)
        Me.lblCityName.Name = "lblCityName"
        Me.lblCityName.Size = New System.Drawing.Size(100, 23)
        Me.lblCityName.TabIndex = 60
        Me.lblCityName.Tag = "CITYEF"
        Me.lblCityName.Text = "lblCityName"
        '
        'txtFEENAME
        '
        Me.txtFEENAME.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtFEENAME.Enabled = False
        Me.txtFEENAME.Location = New System.Drawing.Point(221, 252)
        Me.txtFEENAME.Name = "txtFEENAME"
        Me.txtFEENAME.ReadOnly = True
        Me.txtFEENAME.Size = New System.Drawing.Size(304, 21)
        Me.txtFEENAME.TabIndex = 14
        Me.txtFEENAME.Tag = ""
        Me.txtFEENAME.Text = "txtFEENAME"
        Me.txtFEENAME.Visible = False
        '
        'txtFEECD
        '
        Me.txtFEECD.Enabled = False
        Me.txtFEECD.Location = New System.Drawing.Point(134, 252)
        Me.txtFEECD.Name = "txtFEECD"
        Me.txtFEECD.Size = New System.Drawing.Size(80, 21)
        Me.txtFEECD.TabIndex = 13
        Me.txtFEECD.Tag = "FEECD"
        Me.txtFEECD.Text = "txtFEECD"
        Me.txtFEECD.Visible = False
        '
        'lblFEECD
        '
        Me.lblFEECD.AutoSize = True
        Me.lblFEECD.Enabled = False
        Me.lblFEECD.Location = New System.Drawing.Point(13, 258)
        Me.lblFEECD.Name = "lblFEECD"
        Me.lblFEECD.Size = New System.Drawing.Size(49, 13)
        Me.lblFEECD.TabIndex = 57
        Me.lblFEECD.Tag = "FEECD"
        Me.lblFEECD.Text = "lblFEECD"
        Me.lblFEECD.Visible = False
        '
        'txtACNIDPLACE
        '
        Me.txtACNIDPLACE.Location = New System.Drawing.Point(135, 173)
        Me.txtACNIDPLACE.Name = "txtACNIDPLACE"
        Me.txtACNIDPLACE.Size = New System.Drawing.Size(390, 21)
        Me.txtACNIDPLACE.TabIndex = 12
        Me.txtACNIDPLACE.Tag = "ACNIDPLACE"
        '
        'lblACNIDPLACE
        '
        Me.lblACNIDPLACE.AutoSize = True
        Me.lblACNIDPLACE.Location = New System.Drawing.Point(13, 176)
        Me.lblACNIDPLACE.Name = "lblACNIDPLACE"
        Me.lblACNIDPLACE.Size = New System.Drawing.Size(80, 13)
        Me.lblACNIDPLACE.TabIndex = 55
        Me.lblACNIDPLACE.Tag = "ACNIDPLACE"
        Me.lblACNIDPLACE.Text = "lblACNIDPLACE"
        '
        'lblACNIDDATE
        '
        Me.lblACNIDDATE.AutoSize = True
        Me.lblACNIDDATE.Location = New System.Drawing.Point(272, 149)
        Me.lblACNIDDATE.Name = "lblACNIDDATE"
        Me.lblACNIDDATE.Size = New System.Drawing.Size(75, 13)
        Me.lblACNIDDATE.TabIndex = 53
        Me.lblACNIDDATE.Tag = "ACNIDDATE"
        Me.lblACNIDDATE.Text = "lblACNIDDATE"
        '
        'txtACNIDCODE
        '
        Me.txtACNIDCODE.Location = New System.Drawing.Point(135, 146)
        Me.txtACNIDCODE.Name = "txtACNIDCODE"
        Me.txtACNIDCODE.Size = New System.Drawing.Size(100, 21)
        Me.txtACNIDCODE.TabIndex = 10
        Me.txtACNIDCODE.Tag = "ACNIDCODE"
        '
        'lblACNIDCODE
        '
        Me.lblACNIDCODE.AutoSize = True
        Me.lblACNIDCODE.Location = New System.Drawing.Point(13, 149)
        Me.lblACNIDCODE.Name = "lblACNIDCODE"
        Me.lblACNIDCODE.Size = New System.Drawing.Size(77, 13)
        Me.lblACNIDCODE.TabIndex = 51
        Me.lblACNIDCODE.Tag = "ACNIDCODE"
        Me.lblACNIDCODE.Text = "lblACNIDCODE"
        '
        'lblCustID
        '
        Me.lblCustID.Location = New System.Drawing.Point(13, 16)
        Me.lblCustID.Name = "lblCustID"
        Me.lblCustID.Size = New System.Drawing.Size(116, 23)
        Me.lblCustID.TabIndex = 46
        Me.lblCustID.Tag = "CUSTID"
        Me.lblCustID.Text = "lblCustID"
        '
        'txtCustID
        '
        Me.txtCustID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCustID.Location = New System.Drawing.Point(135, 14)
        Me.txtCustID.Name = "txtCustID"
        Me.txtCustID.Size = New System.Drawing.Size(90, 21)
        Me.txtCustID.TabIndex = 3
        Me.txtCustID.Tag = "CUSTID"
        Me.txtCustID.Text = "txtCustID"
        '
        'txtBankName
        '
        Me.txtBankName.Enabled = False
        Me.txtBankName.Location = New System.Drawing.Point(135, 92)
        Me.txtBankName.Name = "txtBankName"
        Me.txtBankName.Size = New System.Drawing.Size(390, 21)
        Me.txtBankName.TabIndex = 7
        Me.txtBankName.Tag = "BANKNAME"
        '
        'lblBANKNAME
        '
        Me.lblBANKNAME.Location = New System.Drawing.Point(13, 95)
        Me.lblBANKNAME.Name = "lblBANKNAME"
        Me.lblBANKNAME.Size = New System.Drawing.Size(100, 23)
        Me.lblBANKNAME.TabIndex = 42
        Me.lblBANKNAME.Tag = "BANKNAME"
        Me.lblBANKNAME.Text = "lblBANKNAME"
        '
        'lblBankAcc
        '
        Me.lblBankAcc.Location = New System.Drawing.Point(245, 16)
        Me.lblBankAcc.Name = "lblBankAcc"
        Me.lblBankAcc.Size = New System.Drawing.Size(113, 23)
        Me.lblBankAcc.TabIndex = 35
        Me.lblBankAcc.Tag = "BANKACC"
        Me.lblBankAcc.Text = "lblBankAcc"
        '
        'lblTYPE
        '
        Me.lblTYPE.Location = New System.Drawing.Point(12, 59)
        Me.lblTYPE.Name = "lblTYPE"
        Me.lblTYPE.Size = New System.Drawing.Size(63, 23)
        Me.lblTYPE.TabIndex = 43
        Me.lblTYPE.Tag = "TYPE"
        Me.lblTYPE.Text = "lblType"
        '
        'txtCFCUSTID
        '
        Me.txtCFCUSTID.Location = New System.Drawing.Point(712, 97)
        Me.txtCFCUSTID.Name = "txtCFCUSTID"
        Me.txtCFCUSTID.Size = New System.Drawing.Size(92, 21)
        Me.txtCFCUSTID.TabIndex = 64
        Me.txtCFCUSTID.Tag = "CFCUSTID"
        Me.txtCFCUSTID.Text = "txtCFCUSTID"
        '
        'lblCFCUSTID
        '
        Me.lblCFCUSTID.Location = New System.Drawing.Point(645, 95)
        Me.lblCFCUSTID.Name = "lblCFCUSTID"
        Me.lblCFCUSTID.Size = New System.Drawing.Size(52, 23)
        Me.lblCFCUSTID.TabIndex = 65
        Me.lblCFCUSTID.Tag = "CFCUSTID"
        Me.lblCFCUSTID.Text = "CFCUSTID"
        '
        'DataTable21
        '
        Me.DataTable21.Namespace = ""
        Me.DataTable21.TableName = "COMBOBOX"
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
        'DataTable42
        '
        Me.DataTable42.Namespace = ""
        Me.DataTable42.TableName = "COMBOBOX"
        '
        'DataTable50
        '
        Me.DataTable50.Namespace = ""
        Me.DataTable50.TableName = "COMBOBOX"
        '
        'frmCFOTHERACC
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(557, 509)
        Me.Controls.Add(Me.txtCFCUSTID)
        Me.Controls.Add(Me.lblCFCUSTID)
        Me.Controls.Add(Me.grpParameter)
        Me.Controls.Add(Me.txtAUTOID)
        Me.Controls.Add(Me.cboTYPE)
        Me.Controls.Add(Me.lblTYPE)
        Me.Name = "frmCFOTHERACC"
        Me.Tag = "CFOTHERACC"
        Me.Text = ""
        Me.Controls.SetChildIndex(Me.lblTYPE, 0)
        Me.Controls.SetChildIndex(Me.cboTYPE, 0)
        Me.Controls.SetChildIndex(Me.cboLink, 0)
        Me.Controls.SetChildIndex(Me.btnApprv, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.btnApply, 0)
        Me.Controls.SetChildIndex(Me.txtAUTOID, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.grpParameter, 0)
        Me.Controls.SetChildIndex(Me.lblCFCUSTID, 0)
        Me.Controls.SetChildIndex(Me.txtCFCUSTID, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.grpParameter.ResumeLayout(False)
        Me.grpParameter.PerformLayout()
        CType(Me.dtpACNIDDATE.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpACNIDDATE.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable34, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable35, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable42, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable50, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region " Declare constants and variables "
    Private mv_CustomerId As String
    Private mv_acctno As String
    Private v_strISBANKING As String = "N"

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

#Region " Overrides Methods "
    Public Overrides Sub OnInit()
        Dim v_ctrl As Windows.Forms.Control

        Try
            MyBase.OnInit()
            Me.txtCFCUSTID.Text = Me.CustomerId
            'Load Resource Manager
            ResourceManager = New Resources.ResourceManager(gc_RootNamespace & "." & Me.Name & "-" & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
            LoadUserInterface(Me)

            GetFeeName()
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ResourceManager.GetString("InitDialogFailed"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Public Overrides Sub OnSave()
        Dim v_strObjMsg As String

        Try
            'If Convert.ToString(cboTYPE.SelectedValue) <> "0" Then
            '    If Me.txtFEECD.Text = String.Empty Then
            '        MsgBox(ResourceManager.GetString("msgFEECDIsMandatory"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
            '        Exit Sub
            '    End If
            'End If

            If Me.txtBankAcc.Text.Trim.Length = 0 Then
                MsgBox(ResourceManager.GetString("msgBANKACCMandatory"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                Me.txtBankAcc.Focus()
                Exit Sub
            End If
            Select Case Convert.ToString(cboTYPE.SelectedValue)
                Case "1", "2"
                    If Me.txtBankName.Text.Trim.Length = 0 Then
                        MsgBox(ResourceManager.GetString("msgBANKNameMandatory"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Me.txtBankName.Focus()
                        Exit Sub
                    End If
                    If Me.txtCityBank.Text.Trim.Length = 0 Then
                        MsgBox(ResourceManager.GetString("msgCITYBANKMandatory"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Me.txtBankName.Focus()
                        Exit Sub
                    End If
                    If Me.txtBankACName.Text.Trim.Length = 0 Then
                        MsgBox(ResourceManager.GetString("msgBANKACNameMandatory"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Me.txtBankACName.Focus()
                        Exit Sub
                    End If
                Case "3"

                Case "4"
                    If Me.txtBankName.Text.Trim.Length = 0 Then
                        MsgBox(ResourceManager.GetString("msgBANKNameMandatory"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Me.txtBankName.Focus()
                        Exit Sub
                    End If
                    If Me.txtBankACName.Text.Trim.Length = 0 Then
                        MsgBox(ResourceManager.GetString("msgBANKACNameMandatory"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Me.txtBankACName.Focus()
                        Exit Sub
                    End If
            End Select

            'Update mouse pointer
            Cursor.Current = Cursors.WaitCursor
            Dim v_blnValid As Boolean
            v_blnValid = OnValidate()
            If v_blnValid = False Then
                MsgBox("Invalid Data", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                Exit Sub
            End If
            ''Neu lua chon ngan hang thi phai la ma ngan hang.
            'If Convert.ToString(cboTYPE.SelectedValue) <> "0" AndAlso v_strISBANKING = "N" Then
            '    MsgBox(ResourceManager.GetString("msgNOTISBANK"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            '    Me.txtCustID.Focus()
            '    Exit Sub
            'End If

            MyBase.OnSave()
            If Not DoDataExchange(True) Then
                Exit Sub
            End If

            Select Case ExeFlag
                Case ExecuteFlag.AddNew
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionAdd, , , , gc_AutoIdUsed, , , , , , ParentObjName, ParentClause)
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

                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionEdit, , v_strClause, , , , , , , , ParentObjName, ParentClause)
                    BuildXMLObjData(mv_dsInput, v_strObjMsg, mv_dsOldInput, ExecuteFlag.Edit)

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

        If (ExeFlag = ExecuteFlag.AddNew) Then

            Me.cboTYPE.Focus()
            Me.txtCustID.Enabled = True
            Me.txtBankAcc.Enabled = True
            Me.txtBankName.Enabled = True
            Me.txtCityName.Enabled = True
            Me.txtCityBank.Enabled = True
            Me.txtBankACName.Enabled = True
            Me.txtACNIDCODE.Enabled = True
            Me.txtACNIDPLACE.Enabled = True
            'Me.dtp.Enabled = True
            Me.dtpACNIDDATE.Enabled = True
            Me.txtBANKCODE.Enabled = True
        ElseIf (ExeFlag = ExecuteFlag.Edit) Then
            Me.cboTYPE.Enabled = False
            Me.txtCustID.Enabled = True
            Me.txtBankAcc.Enabled = True
            Me.txtBankName.Enabled = True
            Me.txtCityName.Enabled = True
            Me.txtCityBank.Enabled = True
            Me.txtBankACName.Enabled = True
            Me.txtACNIDCODE.Enabled = True
            Me.txtACNIDPLACE.Enabled = True
            Me.txtBANKCODE.Enabled = True
            'Me.dtp.Enabled = True
            Me.dtpACNIDDATE.Enabled = True
        ElseIf (ExeFlag = ExecuteFlag.View) Then
            Me.cboTYPE.Enabled = False
            Me.dtpACNIDDATE.Enabled = False
        End If
    End Sub


#End Region

#Region " Control validations "
    Private Function ControlValidation(Optional ByVal pv_blnSaved As Boolean = False) As Boolean
        'Dim v_ws As New BDSDeliveryManagement
        'Dim v_xmlDocument As New Xml.XmlDocument
        'Dim v_nodeList As Xml.XmlNodeList
        'Dim v_strFLDNAME, v_strVALUE, v_strNum, v_strIDEXPIRED, v_strCCUSTID As String
        'Dim v_intCount, v_int As Integer
        'Dim v_strSQL, v_strObjMsg As String
        Try
            'TrungLuu revert lại, code phía dưới dành cho PHS
            'longnh PHS_P1_ci0035 Khi nhấn “Chấp nhận” nếu TK ngân hàng user nhập vào không nằm trong danh sách 
            'TK ngân hàng liên kết hệ thống sẽ topup cảnh báo Yes/No “TK ngân hàng không liên kết với PHS”, nếu user chọn Yes thì thao tác được tiếp tục, ngược lại thì sẽ quay về màn hình đăng ký.

            If pv_blnSaved Then
                'v_strSQL = "select count (1) AUTOID from " _
                '    & " afmast where bankacctno = '" & txtBankAcc.Text & "'"
                'v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, MyBase.LocalObject, gc_MsgTypeObj, "CF.AUTOID", _
                '    gc_ActionInquiry, v_strSQL)
                'v_ws.Message(v_strObjMsg)
                'v_xmlDocument.LoadXml(v_strObjMsg)
                'v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                'For v_intCount = 0 To v_nodeList.Count - 1
                '    For v_int = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                '        With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                '            v_strFLDNAME = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("fldname").Value.Trim()
                '            v_strVALUE = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("oldval").Value.Trim()

                '            Select Case v_strFLDNAME
                '                Case "AUTOID"
                '                    v_strCCUSTID = v_strVALUE
                '            End Select
                '        End With
                '    Next
                'Next
                'If v_strCCUSTID = 0 And Convert.ToString(cboTYPE.SelectedValue) <> "0" Then
                '    If MsgBox(ResourceManager.GetString("BANKACCTNONOTLINK"), MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Me.Text) <> MsgBoxResult.Yes Then
                '        Exit Function
                '    End If
                'End If


                Return MyBase.VerifyRules()
            End If

            Return True
        Catch ex As Exception
            Throw ex
            Return False
        End Try
    End Function
#End Region

    Public Function OnValidate() As Boolean
        'Neu la` CI Acount
        Return True

    End Function

    Private Sub cboTYPE_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTYPE.KeyUp

    End Sub

    Private Sub cboTYPE_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTYPE.SelectedIndexChanged
        'Me.txtCustID.Enabled = True
        'Me.txtBankAcc.Enabled = True
        'Me.txtBankName.Enabled = True
        'Me.txtCityName.Enabled = True
        'Me.txtCityBank.Enabled = True
        'Me.txtBankACName.Enabled = True
        'Me.txtACNIDCODE.Enabled = True
        'Me.txtBANKCODE.Enabled = True
        'Me.txtACNIDPLACE.Enabled = True
        'Me.dtpACNIDDATE.Enabled = True
        'Me.lblACNIDDATE.Visible = True
        'Me.dtpACNIDDATE.Visible = True
        'Me.txtFEECD.Enabled = True
        'Me.txtFEENAME.Enabled = True
        'Me.lblCityName.ForeColor = Color.Blue
        Select Case Convert.ToString(cboTYPE.SelectedValue)
            Case "1", "2"
                Me.lblBankAcc.ForeColor = Color.Red
                Me.lblBankACName.ForeColor = Color.Red
                Me.lblBANKNAME.ForeColor = Color.Red
                Me.lblCityBank.ForeColor = Color.Red
            Case "3"
                Me.lblBANKNAME.ForeColor = Color.Blue
                Me.lblBankACName.ForeColor = Color.Blue
                Me.lblCityBank.ForeColor = Color.Blue
            Case "4"
                Me.lblBANKNAME.ForeColor = Color.Red
                Me.lblBankACName.ForeColor = Color.Red
                Me.lblCityBank.ForeColor = Color.Blue
        End Select
    End Sub


    Private Sub txtCustID_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCustID.Validating
        If txtCustID.Text <> "" Then
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_int, v_intCount As Integer
            Dim v_strFULLNAME, v_strIDCODE, v_strPHONE As String
            Dim v_strFLDNAME, v_strVALUE, v_strADDRESS, v_strIDDATE, v_strIDEXPIRED As String
            Dim v_strIDPLACE As String
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery

            Dim v_strCmdInquiry As String = "Select FULLNAME,IDCODE,ADDRESS,PHONE,IDDATE,IDEXPIRED,IDCODE,IDPLACE, ISBANKING from CFMAST WHERE CUSTID ='" & txtCustID.Text & "' "
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
                            Case "FULLNAME"
                                Me.txtBankACName.Text = v_strVALUE
                            Case "ADDRESS"
                                v_strADDRESS = v_strVALUE
                            Case "IDCODE"
                                Me.txtACNIDCODE.Text = v_strVALUE
                            Case "PHONE"
                                v_strPHONE = v_strVALUE
                            Case "IDDATE"
                                Me.dtpACNIDDATE.EditValue = v_strVALUE
                            Case "IDEXPIRED"
                                v_strIDEXPIRED = v_strVALUE
                            Case "IDPLACE"
                                Me.txtACNIDPLACE.Text = v_strVALUE
                            Case "ISBANKING"
                                v_strISBANKING = v_strVALUE
                        End Select
                    End With
                Next
            Next
        End If


    End Sub

    Private Sub GetFeeName()
        Try
            If Me.txtFEECD.Text <> String.Empty Then
                Dim v_xmlDocument As New Xml.XmlDocument
                Dim v_nodeList As Xml.XmlNodeList
                Dim v_int, v_intCount As Integer
                Dim v_strFULLNAME, v_strIDCODE, v_strPHONE As String
                Dim v_strFLDNAME, v_strVALUE, v_strADDRESS, v_strIDDATE, v_strIDEXPIRED As String
                Dim v_ws As New BDSDeliveryManagement


                Dim v_strCmdInquiry As String = "Select FEENAME from FEEMASTER where FEECD ='" & txtFEECD.Text & "' "
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
                                Case "FEENAME"
                                    Me.txtFEENAME.Text = v_strVALUE
                            End Select
                        End With
                    Next
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    'Private Sub txtCIAccount_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
    '    'lay ten tk CI
    '    Try
    '        If Me.txtCIAccount.Text <> "" Then
    '            Dim v_xmlDocument As New Xml.XmlDocument
    '            Dim v_nodeList As Xml.XmlNodeList
    '            Dim v_int, v_intCount As Integer
    '            Dim v_strFULLNAME, v_strIDCODE, v_strPHONE As String
    '            Dim v_strFLDNAME, v_strVALUE, v_strADDRESS, v_strIDDATE, v_strIDEXPIRED As String
    '            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery

    '            v_strFULLNAME = ""
    '            v_strIDDATE = "01/01/2000"
    '            'Khong cho dang ky cung mot so tieu khoan trong truong hop chuyen khoan noi bo.

    '            Dim v_strCmdInquiry As String = "Select CF.FULLNAME,CF.IDCODE,CF.ADDRESS,CF.PHONE,CF.IDDATE,CF.IDEXPIRED from CFMAST CF, AFMaST AF  WHERE AF.CUSTID =CF.CUSTID AND  AF.ACCTNO ='" & txtCIAccount.Text & "' "
    '            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, "SA.ALLCODE", gc_ActionInquiry, v_strCmdInquiry)
    '            v_ws.Message(v_strObjMsg)
    '            v_xmlDocument.LoadXml(v_strObjMsg)
    '            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
    '            For v_intCount = 0 To v_nodeList.Count - 1
    '                For v_int = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
    '                    With v_nodeList.Item(v_intCount).ChildNodes(v_int)
    '                        v_strFLDNAME = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("fldname").Value.Trim()
    '                        v_strVALUE = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("oldval").Value.Trim()

    '                        Select Case v_strFLDNAME
    '                            Case "FULLNAME"
    '                                v_strFULLNAME = v_strVALUE
    '                            Case "ADDRESS"
    '                                v_strADDRESS = v_strVALUE
    '                            Case "IDCODE"
    '                                v_strIDCODE = v_strVALUE
    '                            Case "PHONE"
    '                                v_strPHONE = v_strVALUE
    '                            Case "IDDATE"
    '                                v_strIDDATE = v_strVALUE
    '                            Case "IDEXPIRED"
    '                                v_strIDEXPIRED = v_strVALUE
    '                        End Select
    '                    End With
    '                Next
    '            Next
    '            Me.txtCINAME.Text = v_strFULLNAME
    '            Me.dtpACNIDDATE.Value = DDMMYYYY_SystemDate(v_strIDDATE)
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub txtFEECD_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtFEECD.Validating
        GetFeeName()
    End Sub


    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCityName.TextChanged

    End Sub

    Private Sub txtBankName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBankName.TextChanged

    End Sub

    Private Sub txtBANKCODE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtBANKCODE.Validating
        If txtBANKCODE.Text <> "" Then
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_int, v_intCount As Integer
            Dim v_strFULLNAME, v_strIDCODE, v_strPHONE As String
            Dim v_strFLDNAME, v_strVALUE, v_strADDRESS, v_strIDDATE, v_strIDEXPIRED As String
            Dim v_strIDPLACE As String
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery

            Dim v_strCmdInquiry As String = "SELECT CITAD BANKID , BANKCODE, BANKNAME, REGIONAL,REGIONAL CITY, CREATEDT, BRANCHNAME FROM CRBBANKLIST WHERE CITAD ='" & txtBANKCODE.Text & "' "
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
                            Case "BANKNAME"
                                txtBankName.Text = v_strVALUE
                            Case "BRANCHNAME"
                                txtCityBank.Text = v_strVALUE
                            Case "REGIONAL"
                                txtCityName.Text = v_strVALUE
                        End Select
                    End With
                Next
            Next
        End If
    End Sub

    Private Sub txtBankAcc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBankAcc.TextChanged
        Dim v_ws As New BDSDeliveryManagement
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strFLDNAME, v_strVALUE, v_strNum, v_strIDEXPIRED, v_strCCUSTID As String
        Dim v_intCount, v_int As Integer
        Dim v_strSQL, v_strObjMsg As String
        'longnh PHS_P1_ci0035 cap nhật trường ISBANKACCTNO ghi nhật tài khoản NH có liên kết với PHS
        If (Not txtBankAcc.Text Is Nothing AndAlso Not TellerId Is Nothing) Then
            v_strSQL = "select count (1) AUTOID from " _
                        & " afmast where bankacctno = '" & txtBankAcc.Text & "'"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, MyBase.LocalObject, gc_MsgTypeObj, "CF.AUTOID", _
                gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For v_intCount = 0 To v_nodeList.Count - 1
                For v_int = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                    With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                        v_strFLDNAME = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("fldname").Value.Trim()
                        v_strVALUE = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("oldval").Value.Trim()

                        Select Case v_strFLDNAME
                            Case "AUTOID"
                                v_strCCUSTID = v_strVALUE
                        End Select
                    End With
                Next
            Next
            If v_strCCUSTID = 0 Then
                txtISBANKACCTNO.Text = "N"
            Else
                txtISBANKACCTNO.Text = "Y"
            End If
        End If
    End Sub

    Private Sub btnApply_Click(sender As Object, e As EventArgs) Handles btnApply.Click

    End Sub
End Class
