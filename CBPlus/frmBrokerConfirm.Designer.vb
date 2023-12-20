<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBrokerConfirm
    Inherits AppCore.FormBase

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.lblName = New System.Windows.Forms.Label()
        Me.tmrOrder = New System.Windows.Forms.Timer(Me.components)
        Me.lblSTC = New System.Windows.Forms.Label()
        Me.pnInfo = New System.Windows.Forms.Panel()
        Me.lblMFULLNAME = New System.Windows.Forms.Label()
        Me.txtMCUSTODYCD = New System.Windows.Forms.TextBox()
        Me.lblMCUSTODYCD = New System.Windows.Forms.Label()
        Me.cboEmploy = New System.Windows.Forms.ComboBox()
        Me.btnSendMail = New DevExpress.XtraEditors.SimpleButton()
        Me.cboFX = New System.Windows.Forms.ComboBox()
        Me.cboAFMAST = New System.Windows.Forms.ComboBox()
        Me.cboPhone = New System.Windows.Forms.ComboBox()
        Me.cboBROKER = New System.Windows.Forms.ComboBox()
        Me.txtSTC = New System.Windows.Forms.TextBox()
        Me.lblEmploy = New System.Windows.Forms.Label()
        Me.lblFX = New System.Windows.Forms.Label()
        Me.lblPHONE = New System.Windows.Forms.Label()
        Me.lblBROKER = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtNoteSE = New System.Windows.Forms.TextBox()
        Me.lblNoteSE = New System.Windows.Forms.Label()
        Me.txtQuantity = New DevExpress.XtraEditors.TextEdit()
        Me.lblQByword = New System.Windows.Forms.Label()
        Me.lblQtBuyWord = New System.Windows.Forms.Label()
        Me.btnUnholdSE = New DevExpress.XtraEditors.SimpleButton()
        Me.btnHoldSE = New DevExpress.XtraEditors.SimpleButton()
        Me.cboSymbol = New System.Windows.Forms.ComboBox()
        Me.lblQuantity = New System.Windows.Forms.Label()
        Me.txtSEBLOCKEDBR = New System.Windows.Forms.TextBox()
        Me.lblLockbyBroker = New System.Windows.Forms.Label()
        Me.txtSEBLOCKED = New System.Windows.Forms.TextBox()
        Me.lblTotalBlockQtty = New System.Windows.Forms.Label()
        Me.txtSETRADE = New System.Windows.Forms.TextBox()
        Me.lblAvaiQtty = New System.Windows.Forms.Label()
        Me.txtSENAMEVN = New System.Windows.Forms.TextBox()
        Me.lblNameVN = New System.Windows.Forms.Label()
        Me.txtSENAMEEN = New System.Windows.Forms.TextBox()
        Me.lblISSSHORTNAME = New System.Windows.Forms.Label()
        Me.lblSECID = New System.Windows.Forms.Label()
        Me.lblNameEN = New System.Windows.Forms.Label()
        Me.DataTable1 = New System.Data.DataTable()
        Me.DataTable2 = New System.Data.DataTable()
        Me.DataTable3 = New System.Data.DataTable()
        Me.DataTable4 = New System.Data.DataTable()
        Me.DataTable5 = New System.Data.DataTable()
        Me.DataTable6 = New System.Data.DataTable()
        Me.lblSE = New System.Windows.Forms.Label()
        Me.pnlSEHOLD = New System.Windows.Forms.Panel()
        Me.pnlExchangeRate = New System.Windows.Forms.Panel()
        Me.pnlBankAccount = New System.Windows.Forms.Panel()
        Me.tabSEMain = New System.Windows.Forms.TabControl()
        Me.tabBROKER_SEHOLD = New System.Windows.Forms.TabPage()
        Me.tabBROKER_SEUNHOLD = New System.Windows.Forms.TabPage()
        Me.pnlUnholdSE = New System.Windows.Forms.Panel()
        Me.tabSE_SUMMARY_BROKER = New System.Windows.Forms.TabPage()
        Me.pnStockSummary = New System.Windows.Forms.Panel()
        Me.tabBROKER_SEMAST = New System.Windows.Forms.TabPage()
        Me.pnlSE = New System.Windows.Forms.Panel()
        Me.tabNOTE = New System.Windows.Forms.TabPage()
        Me.txtTabNotes = New System.Windows.Forms.TextBox()
        Me.tabCashMain = New System.Windows.Forms.TabControl()
        Me.tabBROKER_CASHHOLD = New System.Windows.Forms.TabPage()
        Me.pnlCashHold = New System.Windows.Forms.Panel()
        Me.tabBROKER_CASHUNHOLD = New System.Windows.Forms.TabPage()
        Me.pnlCashUnhold = New System.Windows.Forms.Panel()
        Me.tabCASH_SUMMARY_BROKER = New System.Windows.Forms.TabPage()
        Me.pnCashSummary = New System.Windows.Forms.Panel()
        Me.tabBROKER_DDMAST = New System.Windows.Forms.TabPage()
        Me.pnlCash = New System.Windows.Forms.Panel()
        Me.lblER = New System.Windows.Forms.Label()
        Me.lblBankAccount = New System.Windows.Forms.Label()
        Me.lblCash = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtAmount = New DevExpress.XtraEditors.TextEdit()
        Me.txtNOTE = New System.Windows.Forms.TextBox()
        Me.btnBilli = New DevExpress.XtraEditors.SimpleButton()
        Me.btnMili = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCashUnhold1 = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCashHold = New DevExpress.XtraEditors.SimpleButton()
        Me.cboDDMAST = New System.Windows.Forms.ComboBox()
        Me.lblNOTE = New System.Windows.Forms.Label()
        Me.txtMARKETVALUE = New System.Windows.Forms.TextBox()
        Me.lblMARKETVALUE = New System.Windows.Forms.Label()
        Me.txtEXCHANGERATE = New System.Windows.Forms.TextBox()
        Me.lblEXCHANGERATE = New System.Windows.Forms.Label()
        Me.lblWords = New System.Windows.Forms.Label()
        Me.lblAmountbyword = New System.Windows.Forms.Label()
        Me.lblAMOUNT = New System.Windows.Forms.Label()
        Me.txtHOLDBR = New System.Windows.Forms.TextBox()
        Me.lblHOLDBR = New System.Windows.Forms.Label()
        Me.txtHOLDBALANCE = New System.Windows.Forms.TextBox()
        Me.lblCCYCD = New System.Windows.Forms.Label()
        Me.lblHOLD = New System.Windows.Forms.Label()
        Me.txtBALANCE = New System.Windows.Forms.TextBox()
        Me.lblAccountNo = New System.Windows.Forms.Label()
        Me.lblAVAILABLE = New System.Windows.Forms.Label()
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
        Me.btnEXRATERefresh = New DevExpress.XtraEditors.SimpleButton()
        Me.btnBankInquiry = New DevExpress.XtraEditors.SimpleButton()
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
        Me.DataTable49 = New System.Data.DataTable()
        Me.DataTable50 = New System.Data.DataTable()
        Me.DataTable51 = New System.Data.DataTable()
        Me.DataTable52 = New System.Data.DataTable()
        Me.DataTable53 = New System.Data.DataTable()
        Me.DataTable54 = New System.Data.DataTable()
        Me.DataTable55 = New System.Data.DataTable()
        Me.DataTable56 = New System.Data.DataTable()
        Me.DataTable57 = New System.Data.DataTable()
        Me.DataTable58 = New System.Data.DataTable()
        Me.DataTable59 = New System.Data.DataTable()
        Me.DataTable60 = New System.Data.DataTable()
        Me.DataTable61 = New System.Data.DataTable()
        Me.DataTable62 = New System.Data.DataTable()
        Me.DataTable63 = New System.Data.DataTable()
        Me.DataTable64 = New System.Data.DataTable()
        Me.DataTable65 = New System.Data.DataTable()
        Me.DataTable66 = New System.Data.DataTable()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnInfo.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.txtQuantity.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabSEMain.SuspendLayout()
        Me.tabBROKER_SEHOLD.SuspendLayout()
        Me.tabBROKER_SEUNHOLD.SuspendLayout()
        Me.tabSE_SUMMARY_BROKER.SuspendLayout()
        Me.tabBROKER_SEMAST.SuspendLayout()
        Me.tabNOTE.SuspendLayout()
        Me.tabCashMain.SuspendLayout()
        Me.tabBROKER_CASHHOLD.SuspendLayout()
        Me.tabBROKER_CASHUNHOLD.SuspendLayout()
        Me.tabCASH_SUMMARY_BROKER.SuspendLayout()
        Me.tabBROKER_DDMAST.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.txtAmount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.DataTable49, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable50, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable51, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable52, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable53, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable54, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable55, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable56, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable57, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable58, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable59, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable60, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable61, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable62, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable63, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable64, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable65, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable66, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblName
        '
        Me.lblName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.Location = New System.Drawing.Point(236, 9)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(604, 18)
        Me.lblName.TabIndex = 0
        Me.lblName.Tag = "lblName"
        Me.lblName.Text = "---"
        '
        'lblSTC
        '
        Me.lblSTC.Location = New System.Drawing.Point(9, 11)
        Me.lblSTC.Name = "lblSTC"
        Me.lblSTC.Size = New System.Drawing.Size(87, 17)
        Me.lblSTC.TabIndex = 1
        Me.lblSTC.Tag = "lblMOBILE"
        Me.lblSTC.Text = "STC"
        '
        'pnInfo
        '
        Me.pnInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnInfo.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.pnInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnInfo.Controls.Add(Me.lblMFULLNAME)
        Me.pnInfo.Controls.Add(Me.txtMCUSTODYCD)
        Me.pnInfo.Controls.Add(Me.lblMCUSTODYCD)
        Me.pnInfo.Controls.Add(Me.cboEmploy)
        Me.pnInfo.Controls.Add(Me.btnSendMail)
        Me.pnInfo.Controls.Add(Me.cboFX)
        Me.pnInfo.Controls.Add(Me.cboAFMAST)
        Me.pnInfo.Controls.Add(Me.cboPhone)
        Me.pnInfo.Controls.Add(Me.cboBROKER)
        Me.pnInfo.Controls.Add(Me.txtSTC)
        Me.pnInfo.Controls.Add(Me.lblEmploy)
        Me.pnInfo.Controls.Add(Me.lblFX)
        Me.pnInfo.Controls.Add(Me.lblSTC)
        Me.pnInfo.Controls.Add(Me.lblPHONE)
        Me.pnInfo.Controls.Add(Me.lblBROKER)
        Me.pnInfo.Controls.Add(Me.lblName)
        Me.pnInfo.Location = New System.Drawing.Point(3, 3)
        Me.pnInfo.Name = "pnInfo"
        Me.pnInfo.Size = New System.Drawing.Size(1894, 90)
        Me.pnInfo.TabIndex = 16
        '
        'lblMFULLNAME
        '
        Me.lblMFULLNAME.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblMFULLNAME.Location = New System.Drawing.Point(236, 37)
        Me.lblMFULLNAME.Name = "lblMFULLNAME"
        Me.lblMFULLNAME.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblMFULLNAME.Size = New System.Drawing.Size(604, 18)
        Me.lblMFULLNAME.TabIndex = 87
        Me.lblMFULLNAME.Tag = "MFULLNAME"
        Me.lblMFULLNAME.Text = "---"
        '
        'txtMCUSTODYCD
        '
        Me.txtMCUSTODYCD.Enabled = False
        Me.txtMCUSTODYCD.Location = New System.Drawing.Point(102, 34)
        Me.txtMCUSTODYCD.MaxLength = 10
        Me.txtMCUSTODYCD.Name = "txtMCUSTODYCD"
        Me.txtMCUSTODYCD.Size = New System.Drawing.Size(128, 21)
        Me.txtMCUSTODYCD.TabIndex = 86
        Me.txtMCUSTODYCD.Tag = "MCUSTODYCD"
        '
        'lblMCUSTODYCD
        '
        Me.lblMCUSTODYCD.Location = New System.Drawing.Point(9, 37)
        Me.lblMCUSTODYCD.Name = "lblMCUSTODYCD"
        Me.lblMCUSTODYCD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblMCUSTODYCD.Size = New System.Drawing.Size(87, 16)
        Me.lblMCUSTODYCD.TabIndex = 85
        Me.lblMCUSTODYCD.Tag = "MCUSTODYCD"
        Me.lblMCUSTODYCD.Text = "Master account"
        '
        'cboEmploy
        '
        Me.cboEmploy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboEmploy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboEmploy.FormattingEnabled = True
        Me.cboEmploy.Location = New System.Drawing.Point(102, 59)
        Me.cboEmploy.Name = "cboEmploy"
        Me.cboEmploy.Size = New System.Drawing.Size(214, 21)
        Me.cboEmploy.TabIndex = 84
        '
        'btnSendMail
        '
        Me.btnSendMail.Enabled = False
        Me.btnSendMail.Location = New System.Drawing.Point(1265, 59)
        Me.btnSendMail.Name = "btnSendMail"
        Me.btnSendMail.Size = New System.Drawing.Size(75, 21)
        Me.btnSendMail.TabIndex = 10
        Me.btnSendMail.Text = "Send email"
        '
        'cboFX
        '
        Me.cboFX.FormattingEnabled = True
        Me.cboFX.Location = New System.Drawing.Point(1189, 59)
        Me.cboFX.Name = "cboFX"
        Me.cboFX.Size = New System.Drawing.Size(70, 21)
        Me.cboFX.TabIndex = 9
        '
        'cboAFMAST
        '
        Me.cboAFMAST.FormattingEnabled = True
        Me.cboAFMAST.Location = New System.Drawing.Point(1330, 32)
        Me.cboAFMAST.Name = "cboAFMAST"
        Me.cboAFMAST.Size = New System.Drawing.Size(10, 21)
        Me.cboAFMAST.TabIndex = 9
        Me.cboAFMAST.Visible = False
        '
        'cboPhone
        '
        Me.cboPhone.FormattingEnabled = True
        Me.cboPhone.Location = New System.Drawing.Point(1006, 58)
        Me.cboPhone.Name = "cboPhone"
        Me.cboPhone.Size = New System.Drawing.Size(121, 21)
        Me.cboPhone.TabIndex = 2
        '
        'cboBROKER
        '
        Me.cboBROKER.FormattingEnabled = True
        Me.cboBROKER.Location = New System.Drawing.Point(388, 59)
        Me.cboBROKER.Name = "cboBROKER"
        Me.cboBROKER.Size = New System.Drawing.Size(536, 21)
        Me.cboBROKER.TabIndex = 1
        '
        'txtSTC
        '
        Me.txtSTC.Location = New System.Drawing.Point(102, 8)
        Me.txtSTC.MaxLength = 10
        Me.txtSTC.Name = "txtSTC"
        Me.txtSTC.Size = New System.Drawing.Size(128, 21)
        Me.txtSTC.TabIndex = 0
        Me.txtSTC.Tag = "STC"
        '
        'lblEmploy
        '
        Me.lblEmploy.Location = New System.Drawing.Point(9, 62)
        Me.lblEmploy.Name = "lblEmploy"
        Me.lblEmploy.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblEmploy.Size = New System.Drawing.Size(87, 16)
        Me.lblEmploy.TabIndex = 3
        Me.lblEmploy.Tag = "EMPLOY"
        Me.lblEmploy.Text = "Employ business"
        '
        'lblFX
        '
        Me.lblFX.Location = New System.Drawing.Point(1133, 61)
        Me.lblFX.Name = "lblFX"
        Me.lblFX.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblFX.Size = New System.Drawing.Size(53, 17)
        Me.lblFX.TabIndex = 3
        Me.lblFX.Tag = "FX"
        Me.lblFX.Text = "FX"
        '
        'lblPHONE
        '
        Me.lblPHONE.Location = New System.Drawing.Point(930, 62)
        Me.lblPHONE.Name = "lblPHONE"
        Me.lblPHONE.Size = New System.Drawing.Size(75, 16)
        Me.lblPHONE.TabIndex = 3
        Me.lblPHONE.Tag = "PHONE"
        Me.lblPHONE.Text = "Số điện thoại"
        '
        'lblBROKER
        '
        Me.lblBROKER.Location = New System.Drawing.Point(322, 63)
        Me.lblBROKER.Name = "lblBROKER"
        Me.lblBROKER.Size = New System.Drawing.Size(62, 18)
        Me.lblBROKER.TabIndex = 3
        Me.lblBROKER.Tag = "BROKER"
        Me.lblBROKER.Text = "Broker"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.GroupBox2.Controls.Add(Me.txtNoteSE)
        Me.GroupBox2.Controls.Add(Me.lblNoteSE)
        Me.GroupBox2.Controls.Add(Me.txtQuantity)
        Me.GroupBox2.Controls.Add(Me.lblQByword)
        Me.GroupBox2.Controls.Add(Me.lblQtBuyWord)
        Me.GroupBox2.Controls.Add(Me.btnUnholdSE)
        Me.GroupBox2.Controls.Add(Me.btnHoldSE)
        Me.GroupBox2.Controls.Add(Me.cboSymbol)
        Me.GroupBox2.Controls.Add(Me.lblQuantity)
        Me.GroupBox2.Controls.Add(Me.txtSEBLOCKEDBR)
        Me.GroupBox2.Controls.Add(Me.lblLockbyBroker)
        Me.GroupBox2.Controls.Add(Me.txtSEBLOCKED)
        Me.GroupBox2.Controls.Add(Me.lblTotalBlockQtty)
        Me.GroupBox2.Controls.Add(Me.txtSETRADE)
        Me.GroupBox2.Controls.Add(Me.lblAvaiQtty)
        Me.GroupBox2.Controls.Add(Me.txtSENAMEVN)
        Me.GroupBox2.Controls.Add(Me.lblNameVN)
        Me.GroupBox2.Controls.Add(Me.txtSENAMEEN)
        Me.GroupBox2.Controls.Add(Me.lblISSSHORTNAME)
        Me.GroupBox2.Controls.Add(Me.lblSECID)
        Me.GroupBox2.Controls.Add(Me.lblNameEN)
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(3, 118)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(513, 228)
        Me.GroupBox2.TabIndex = 35
        Me.GroupBox2.TabStop = False
        '
        'txtNoteSE
        '
        Me.txtNoteSE.Location = New System.Drawing.Point(134, 180)
        Me.txtNoteSE.MaxLength = 150
        Me.txtNoteSE.Name = "txtNoteSE"
        Me.txtNoteSE.Size = New System.Drawing.Size(359, 20)
        Me.txtNoteSE.TabIndex = 6
        Me.txtNoteSE.Tag = "NOTE"
        '
        'lblNoteSE
        '
        Me.lblNoteSE.Location = New System.Drawing.Point(8, 180)
        Me.lblNoteSE.Name = "lblNoteSE"
        Me.lblNoteSE.Size = New System.Drawing.Size(80, 23)
        Me.lblNoteSE.TabIndex = 73
        Me.lblNoteSE.Tag = "lblNOTE"
        Me.lblNoteSE.Text = "Note"
        '
        'txtQuantity
        '
        Me.txtQuantity.EditValue = "0"
        Me.txtQuantity.Location = New System.Drawing.Point(134, 142)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.txtQuantity.Properties.Mask.EditMask = "n0"
        Me.txtQuantity.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtQuantity.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtQuantity.Properties.MaxLength = 15
        Me.txtQuantity.Size = New System.Drawing.Size(359, 20)
        Me.txtQuantity.TabIndex = 5
        '
        'lblQByword
        '
        Me.lblQByword.Location = New System.Drawing.Point(8, 162)
        Me.lblQByword.Name = "lblQByword"
        Me.lblQByword.Size = New System.Drawing.Size(108, 23)
        Me.lblQByword.TabIndex = 82
        Me.lblQByword.Tag = "AMOUNT"
        Me.lblQByword.Text = "In words"
        '
        'lblQtBuyWord
        '
        Me.lblQtBuyWord.Location = New System.Drawing.Point(133, 165)
        Me.lblQtBuyWord.Name = "lblQtBuyWord"
        Me.lblQtBuyWord.Size = New System.Drawing.Size(289, 23)
        Me.lblQtBuyWord.TabIndex = 83
        Me.lblQtBuyWord.Tag = "AMOUNT"
        '
        'btnUnholdSE
        '
        Me.btnUnholdSE.Location = New System.Drawing.Point(405, 203)
        Me.btnUnholdSE.Name = "btnUnholdSE"
        Me.btnUnholdSE.Size = New System.Drawing.Size(88, 23)
        Me.btnUnholdSE.TabIndex = 8
        Me.btnUnholdSE.Text = "Unhold"
        '
        'btnHoldSE
        '
        Me.btnHoldSE.Location = New System.Drawing.Point(134, 203)
        Me.btnHoldSE.Name = "btnHoldSE"
        Me.btnHoldSE.Size = New System.Drawing.Size(87, 23)
        Me.btnHoldSE.TabIndex = 7
        Me.btnHoldSE.Text = "Hold"
        '
        'cboSymbol
        '
        Me.cboSymbol.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSymbol.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSymbol.FormattingEnabled = True
        Me.cboSymbol.Location = New System.Drawing.Point(134, 9)
        Me.cboSymbol.Name = "cboSymbol"
        Me.cboSymbol.Size = New System.Drawing.Size(224, 21)
        Me.cboSymbol.TabIndex = 4
        '
        'lblQuantity
        '
        Me.lblQuantity.Location = New System.Drawing.Point(8, 141)
        Me.lblQuantity.Name = "lblQuantity"
        Me.lblQuantity.Size = New System.Drawing.Size(80, 23)
        Me.lblQuantity.TabIndex = 74
        Me.lblQuantity.Tag = "lblMARKETVALUE"
        Me.lblQuantity.Text = "Quantity"
        '
        'txtSEBLOCKEDBR
        '
        Me.txtSEBLOCKEDBR.Enabled = False
        Me.txtSEBLOCKEDBR.Location = New System.Drawing.Point(134, 119)
        Me.txtSEBLOCKEDBR.MaxLength = 50
        Me.txtSEBLOCKEDBR.Name = "txtSEBLOCKEDBR"
        Me.txtSEBLOCKEDBR.Size = New System.Drawing.Size(359, 20)
        Me.txtSEBLOCKEDBR.TabIndex = 75
        Me.txtSEBLOCKEDBR.Tag = "EXCHANGERATE"
        '
        'lblLockbyBroker
        '
        Me.lblLockbyBroker.Location = New System.Drawing.Point(8, 119)
        Me.lblLockbyBroker.Name = "lblLockbyBroker"
        Me.lblLockbyBroker.Size = New System.Drawing.Size(130, 23)
        Me.lblLockbyBroker.TabIndex = 71
        Me.lblLockbyBroker.Tag = "lblEXCHANGERATE"
        Me.lblLockbyBroker.Text = "Blocked by broker"
        '
        'txtSEBLOCKED
        '
        Me.txtSEBLOCKED.Enabled = False
        Me.txtSEBLOCKED.Location = New System.Drawing.Point(134, 98)
        Me.txtSEBLOCKED.MaxLength = 50
        Me.txtSEBLOCKED.Name = "txtSEBLOCKED"
        Me.txtSEBLOCKED.Size = New System.Drawing.Size(359, 20)
        Me.txtSEBLOCKED.TabIndex = 77
        Me.txtSEBLOCKED.Tag = "AMOUNT"
        Me.txtSEBLOCKED.Text = "0"
        '
        'lblTotalBlockQtty
        '
        Me.lblTotalBlockQtty.Location = New System.Drawing.Point(8, 98)
        Me.lblTotalBlockQtty.Name = "lblTotalBlockQtty"
        Me.lblTotalBlockQtty.Size = New System.Drawing.Size(130, 23)
        Me.lblTotalBlockQtty.TabIndex = 68
        Me.lblTotalBlockQtty.Tag = "AMOUNT"
        Me.lblTotalBlockQtty.Text = "Total blocked quantity"
        '
        'txtSETRADE
        '
        Me.txtSETRADE.Enabled = False
        Me.txtSETRADE.Location = New System.Drawing.Point(134, 76)
        Me.txtSETRADE.MaxLength = 50
        Me.txtSETRADE.Name = "txtSETRADE"
        Me.txtSETRADE.Size = New System.Drawing.Size(359, 20)
        Me.txtSETRADE.TabIndex = 79
        Me.txtSETRADE.Tag = "HOLDBR"
        Me.txtSETRADE.Text = "TextBox5"
        '
        'lblAvaiQtty
        '
        Me.lblAvaiQtty.Location = New System.Drawing.Point(8, 76)
        Me.lblAvaiQtty.Name = "lblAvaiQtty"
        Me.lblAvaiQtty.Size = New System.Drawing.Size(120, 23)
        Me.lblAvaiQtty.TabIndex = 70
        Me.lblAvaiQtty.Tag = "lblHOLDBR"
        Me.lblAvaiQtty.Text = "Available quantity"
        '
        'txtSENAMEVN
        '
        Me.txtSENAMEVN.Enabled = False
        Me.txtSENAMEVN.Location = New System.Drawing.Point(134, 54)
        Me.txtSENAMEVN.MaxLength = 50
        Me.txtSENAMEVN.Name = "txtSENAMEVN"
        Me.txtSENAMEVN.Size = New System.Drawing.Size(359, 20)
        Me.txtSENAMEVN.TabIndex = 80
        Me.txtSENAMEVN.Tag = "HOLD"
        Me.txtSENAMEVN.Text = "TextBox6"
        '
        'lblNameVN
        '
        Me.lblNameVN.Location = New System.Drawing.Point(8, 54)
        Me.lblNameVN.Name = "lblNameVN"
        Me.lblNameVN.Size = New System.Drawing.Size(80, 23)
        Me.lblNameVN.TabIndex = 69
        Me.lblNameVN.Tag = "lblHOLD"
        Me.lblNameVN.Text = "Full name (VN)"
        '
        'txtSENAMEEN
        '
        Me.txtSENAMEEN.Enabled = False
        Me.txtSENAMEEN.Location = New System.Drawing.Point(134, 32)
        Me.txtSENAMEEN.MaxLength = 50
        Me.txtSENAMEEN.Name = "txtSENAMEEN"
        Me.txtSENAMEEN.Size = New System.Drawing.Size(359, 20)
        Me.txtSENAMEEN.TabIndex = 78
        Me.txtSENAMEEN.Tag = "AVAILABLE"
        Me.txtSENAMEEN.Text = "TextBox7"
        '
        'lblISSSHORTNAME
        '
        Me.lblISSSHORTNAME.Location = New System.Drawing.Point(364, 11)
        Me.lblISSSHORTNAME.Name = "lblISSSHORTNAME"
        Me.lblISSSHORTNAME.Size = New System.Drawing.Size(153, 19)
        Me.lblISSSHORTNAME.TabIndex = 72
        Me.lblISSSHORTNAME.Tag = ""
        '
        'lblSECID
        '
        Me.lblSECID.Location = New System.Drawing.Point(8, 12)
        Me.lblSECID.Name = "lblSECID"
        Me.lblSECID.Size = New System.Drawing.Size(80, 19)
        Me.lblSECID.TabIndex = 72
        Me.lblSECID.Tag = "lblAVAILABLE"
        Me.lblSECID.Text = "Securities ID (Ticker)"
        '
        'lblNameEN
        '
        Me.lblNameEN.Location = New System.Drawing.Point(8, 32)
        Me.lblNameEN.Name = "lblNameEN"
        Me.lblNameEN.Size = New System.Drawing.Size(80, 23)
        Me.lblNameEN.TabIndex = 72
        Me.lblNameEN.Tag = "lblAVAILABLE"
        Me.lblNameEN.Text = "Full name (EN)"
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
        'lblSE
        '
        Me.lblSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.lblSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSE.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblSE.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSE.ForeColor = System.Drawing.Color.White
        Me.lblSE.Location = New System.Drawing.Point(3, 96)
        Me.lblSE.Name = "lblSE"
        Me.lblSE.Size = New System.Drawing.Size(513, 22)
        Me.lblSE.TabIndex = 72
        Me.lblSE.Tag = "lblAVAILABLE"
        Me.lblSE.Text = "SECURITIES"
        Me.lblSE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlSEHOLD
        '
        Me.pnlSEHOLD.AutoScroll = True
        Me.pnlSEHOLD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlSEHOLD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSEHOLD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlSEHOLD.Location = New System.Drawing.Point(3, 3)
        Me.pnlSEHOLD.Name = "pnlSEHOLD"
        Me.pnlSEHOLD.Size = New System.Drawing.Size(1880, 235)
        Me.pnlSEHOLD.TabIndex = 73
        '
        'pnlExchangeRate
        '
        Me.pnlExchangeRate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlExchangeRate.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.pnlExchangeRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlExchangeRate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlExchangeRate.Location = New System.Drawing.Point(1079, 118)
        Me.pnlExchangeRate.Name = "pnlExchangeRate"
        Me.pnlExchangeRate.Size = New System.Drawing.Size(818, 87)
        Me.pnlExchangeRate.TabIndex = 74
        '
        'pnlBankAccount
        '
        Me.pnlBankAccount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlBankAccount.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.pnlBankAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlBankAccount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlBankAccount.Location = New System.Drawing.Point(1079, 233)
        Me.pnlBankAccount.Name = "pnlBankAccount"
        Me.pnlBankAccount.Size = New System.Drawing.Size(818, 113)
        Me.pnlBankAccount.TabIndex = 75
        '
        'tabSEMain
        '
        Me.tabSEMain.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabSEMain.Controls.Add(Me.tabBROKER_SEHOLD)
        Me.tabSEMain.Controls.Add(Me.tabBROKER_SEUNHOLD)
        Me.tabSEMain.Controls.Add(Me.tabSE_SUMMARY_BROKER)
        Me.tabSEMain.Controls.Add(Me.tabBROKER_SEMAST)
        Me.tabSEMain.Controls.Add(Me.tabNOTE)
        Me.tabSEMain.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabSEMain.Location = New System.Drawing.Point(3, 350)
        Me.tabSEMain.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.tabSEMain.Name = "tabSEMain"
        Me.tabSEMain.SelectedIndex = 0
        Me.tabSEMain.Size = New System.Drawing.Size(1894, 270)
        Me.tabSEMain.TabIndex = 76
        '
        'tabBROKER_SEHOLD
        '
        Me.tabBROKER_SEHOLD.Controls.Add(Me.pnlSEHOLD)
        Me.tabBROKER_SEHOLD.Location = New System.Drawing.Point(4, 25)
        Me.tabBROKER_SEHOLD.Name = "tabBROKER_SEHOLD"
        Me.tabBROKER_SEHOLD.Padding = New System.Windows.Forms.Padding(3)
        Me.tabBROKER_SEHOLD.Size = New System.Drawing.Size(1886, 241)
        Me.tabBROKER_SEHOLD.TabIndex = 0
        Me.tabBROKER_SEHOLD.Tag = "BROKER_SEHOLD"
        Me.tabBROKER_SEHOLD.Text = "Stock hold"
        Me.tabBROKER_SEHOLD.UseVisualStyleBackColor = True
        '
        'tabBROKER_SEUNHOLD
        '
        Me.tabBROKER_SEUNHOLD.Controls.Add(Me.pnlUnholdSE)
        Me.tabBROKER_SEUNHOLD.Location = New System.Drawing.Point(4, 25)
        Me.tabBROKER_SEUNHOLD.Name = "tabBROKER_SEUNHOLD"
        Me.tabBROKER_SEUNHOLD.Size = New System.Drawing.Size(1586, 241)
        Me.tabBROKER_SEUNHOLD.TabIndex = 2
        Me.tabBROKER_SEUNHOLD.Tag = "BROKER_SEUNHOLD"
        Me.tabBROKER_SEUNHOLD.Text = "Stock unhold"
        Me.tabBROKER_SEUNHOLD.UseVisualStyleBackColor = True
        '
        'pnlUnholdSE
        '
        Me.pnlUnholdSE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlUnholdSE.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlUnholdSE.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlUnholdSE.Location = New System.Drawing.Point(0, 0)
        Me.pnlUnholdSE.Name = "pnlUnholdSE"
        Me.pnlUnholdSE.Size = New System.Drawing.Size(1586, 241)
        Me.pnlUnholdSE.TabIndex = 74
        '
        'tabSE_SUMMARY_BROKER
        '
        Me.tabSE_SUMMARY_BROKER.Controls.Add(Me.pnStockSummary)
        Me.tabSE_SUMMARY_BROKER.Location = New System.Drawing.Point(4, 25)
        Me.tabSE_SUMMARY_BROKER.Name = "tabSE_SUMMARY_BROKER"
        Me.tabSE_SUMMARY_BROKER.Size = New System.Drawing.Size(1586, 241)
        Me.tabSE_SUMMARY_BROKER.TabIndex = 3
        Me.tabSE_SUMMARY_BROKER.Tag = "SE_SUMMARY_BROKER"
        Me.tabSE_SUMMARY_BROKER.Text = "Stock summary"
        Me.tabSE_SUMMARY_BROKER.UseVisualStyleBackColor = True
        '
        'pnStockSummary
        '
        Me.pnStockSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnStockSummary.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnStockSummary.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnStockSummary.Location = New System.Drawing.Point(0, 0)
        Me.pnStockSummary.Name = "pnStockSummary"
        Me.pnStockSummary.Size = New System.Drawing.Size(1586, 241)
        Me.pnStockSummary.TabIndex = 75
        '
        'tabBROKER_SEMAST
        '
        Me.tabBROKER_SEMAST.Controls.Add(Me.pnlSE)
        Me.tabBROKER_SEMAST.Location = New System.Drawing.Point(4, 25)
        Me.tabBROKER_SEMAST.Name = "tabBROKER_SEMAST"
        Me.tabBROKER_SEMAST.Padding = New System.Windows.Forms.Padding(3)
        Me.tabBROKER_SEMAST.Size = New System.Drawing.Size(1586, 241)
        Me.tabBROKER_SEMAST.TabIndex = 1
        Me.tabBROKER_SEMAST.Tag = "BROKER_SEMAST"
        Me.tabBROKER_SEMAST.Text = "Stocks balance"
        Me.tabBROKER_SEMAST.UseVisualStyleBackColor = True
        '
        'pnlSE
        '
        Me.pnlSE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlSE.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSE.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlSE.Location = New System.Drawing.Point(3, 3)
        Me.pnlSE.Name = "pnlSE"
        Me.pnlSE.Size = New System.Drawing.Size(1580, 235)
        Me.pnlSE.TabIndex = 74
        '
        'tabNOTE
        '
        Me.tabNOTE.Controls.Add(Me.txtTabNotes)
        Me.tabNOTE.Location = New System.Drawing.Point(4, 25)
        Me.tabNOTE.Name = "tabNOTE"
        Me.tabNOTE.Padding = New System.Windows.Forms.Padding(3)
        Me.tabNOTE.Size = New System.Drawing.Size(1586, 241)
        Me.tabNOTE.TabIndex = 4
        Me.tabNOTE.Text = "Note"
        Me.tabNOTE.UseVisualStyleBackColor = True
        '
        'txtTabNotes
        '
        Me.txtTabNotes.Location = New System.Drawing.Point(0, 0)
        Me.txtTabNotes.Multiline = True
        Me.txtTabNotes.Name = "txtTabNotes"
        Me.txtTabNotes.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtTabNotes.Size = New System.Drawing.Size(1337, 99)
        Me.txtTabNotes.TabIndex = 0
        '
        'tabCashMain
        '
        Me.tabCashMain.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabCashMain.Controls.Add(Me.tabBROKER_CASHHOLD)
        Me.tabCashMain.Controls.Add(Me.tabBROKER_CASHUNHOLD)
        Me.tabCashMain.Controls.Add(Me.tabCASH_SUMMARY_BROKER)
        Me.tabCashMain.Controls.Add(Me.tabBROKER_DDMAST)
        Me.tabCashMain.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabCashMain.Location = New System.Drawing.Point(4, 623)
        Me.tabCashMain.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.tabCashMain.Name = "tabCashMain"
        Me.tabCashMain.SelectedIndex = 0
        Me.tabCashMain.Size = New System.Drawing.Size(1893, 270)
        Me.tabCashMain.TabIndex = 77
        '
        'tabBROKER_CASHHOLD
        '
        Me.tabBROKER_CASHHOLD.Controls.Add(Me.pnlCashHold)
        Me.tabBROKER_CASHHOLD.Location = New System.Drawing.Point(4, 25)
        Me.tabBROKER_CASHHOLD.Name = "tabBROKER_CASHHOLD"
        Me.tabBROKER_CASHHOLD.Padding = New System.Windows.Forms.Padding(3)
        Me.tabBROKER_CASHHOLD.Size = New System.Drawing.Size(1885, 241)
        Me.tabBROKER_CASHHOLD.TabIndex = 0
        Me.tabBROKER_CASHHOLD.Tag = "BROKER_CASHHOLD"
        Me.tabBROKER_CASHHOLD.Text = "Cash hold"
        Me.tabBROKER_CASHHOLD.UseVisualStyleBackColor = True
        '
        'pnlCashHold
        '
        Me.pnlCashHold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlCashHold.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCashHold.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlCashHold.Location = New System.Drawing.Point(3, 3)
        Me.pnlCashHold.Name = "pnlCashHold"
        Me.pnlCashHold.Size = New System.Drawing.Size(1879, 235)
        Me.pnlCashHold.TabIndex = 73
        '
        'tabBROKER_CASHUNHOLD
        '
        Me.tabBROKER_CASHUNHOLD.Controls.Add(Me.pnlCashUnhold)
        Me.tabBROKER_CASHUNHOLD.Location = New System.Drawing.Point(4, 25)
        Me.tabBROKER_CASHUNHOLD.Name = "tabBROKER_CASHUNHOLD"
        Me.tabBROKER_CASHUNHOLD.Size = New System.Drawing.Size(1585, 241)
        Me.tabBROKER_CASHUNHOLD.TabIndex = 2
        Me.tabBROKER_CASHUNHOLD.Tag = "BROKER_CASHUNHOLD"
        Me.tabBROKER_CASHUNHOLD.Text = "Cash unhold"
        Me.tabBROKER_CASHUNHOLD.UseVisualStyleBackColor = True
        '
        'pnlCashUnhold
        '
        Me.pnlCashUnhold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlCashUnhold.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCashUnhold.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlCashUnhold.Location = New System.Drawing.Point(0, 0)
        Me.pnlCashUnhold.Name = "pnlCashUnhold"
        Me.pnlCashUnhold.Size = New System.Drawing.Size(1585, 241)
        Me.pnlCashUnhold.TabIndex = 74
        '
        'tabCASH_SUMMARY_BROKER
        '
        Me.tabCASH_SUMMARY_BROKER.Controls.Add(Me.pnCashSummary)
        Me.tabCASH_SUMMARY_BROKER.Location = New System.Drawing.Point(4, 25)
        Me.tabCASH_SUMMARY_BROKER.Name = "tabCASH_SUMMARY_BROKER"
        Me.tabCASH_SUMMARY_BROKER.Size = New System.Drawing.Size(1585, 241)
        Me.tabCASH_SUMMARY_BROKER.TabIndex = 3
        Me.tabCASH_SUMMARY_BROKER.Tag = "CASH_SUMMARY_BROKER"
        Me.tabCASH_SUMMARY_BROKER.Text = "Cash summary"
        Me.tabCASH_SUMMARY_BROKER.UseVisualStyleBackColor = True
        '
        'pnCashSummary
        '
        Me.pnCashSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnCashSummary.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnCashSummary.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnCashSummary.Location = New System.Drawing.Point(0, 0)
        Me.pnCashSummary.Name = "pnCashSummary"
        Me.pnCashSummary.Size = New System.Drawing.Size(1585, 241)
        Me.pnCashSummary.TabIndex = 75
        '
        'tabBROKER_DDMAST
        '
        Me.tabBROKER_DDMAST.Controls.Add(Me.pnlCash)
        Me.tabBROKER_DDMAST.Location = New System.Drawing.Point(4, 25)
        Me.tabBROKER_DDMAST.Name = "tabBROKER_DDMAST"
        Me.tabBROKER_DDMAST.Padding = New System.Windows.Forms.Padding(3)
        Me.tabBROKER_DDMAST.Size = New System.Drawing.Size(1585, 241)
        Me.tabBROKER_DDMAST.TabIndex = 1
        Me.tabBROKER_DDMAST.Tag = "BROKER_DDMAST"
        Me.tabBROKER_DDMAST.Text = "Cash accounts"
        Me.tabBROKER_DDMAST.UseVisualStyleBackColor = True
        '
        'pnlCash
        '
        Me.pnlCash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlCash.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCash.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlCash.Location = New System.Drawing.Point(3, 3)
        Me.pnlCash.Name = "pnlCash"
        Me.pnlCash.Size = New System.Drawing.Size(1579, 235)
        Me.pnlCash.TabIndex = 74
        '
        'lblER
        '
        Me.lblER.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblER.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(190, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.lblER.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblER.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblER.Location = New System.Drawing.Point(1079, 96)
        Me.lblER.Name = "lblER"
        Me.lblER.Size = New System.Drawing.Size(818, 22)
        Me.lblER.TabIndex = 72
        Me.lblER.Tag = "lblAVAILABLE"
        Me.lblER.Text = "Exchange rate"
        Me.lblER.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblBankAccount
        '
        Me.lblBankAccount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBankAccount.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(190, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.lblBankAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblBankAccount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBankAccount.Location = New System.Drawing.Point(1080, 208)
        Me.lblBankAccount.Name = "lblBankAccount"
        Me.lblBankAccount.Size = New System.Drawing.Size(817, 22)
        Me.lblBankAccount.TabIndex = 72
        Me.lblBankAccount.Tag = "lblAVAILABLE"
        Me.lblBankAccount.Text = "Available bank account"
        Me.lblBankAccount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCash
        '
        Me.lblCash.BackColor = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblCash.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCash.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblCash.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCash.ForeColor = System.Drawing.Color.White
        Me.lblCash.Location = New System.Drawing.Point(519, 96)
        Me.lblCash.Name = "lblCash"
        Me.lblCash.Size = New System.Drawing.Size(556, 22)
        Me.lblCash.TabIndex = 78
        Me.lblCash.Tag = "lblAVAILABLE"
        Me.lblCash.Text = "CASH"
        Me.lblCash.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.GroupBox1.Controls.Add(Me.txtAmount)
        Me.GroupBox1.Controls.Add(Me.txtNOTE)
        Me.GroupBox1.Controls.Add(Me.btnBilli)
        Me.GroupBox1.Controls.Add(Me.btnMili)
        Me.GroupBox1.Controls.Add(Me.btnCashUnhold1)
        Me.GroupBox1.Controls.Add(Me.btnCashHold)
        Me.GroupBox1.Controls.Add(Me.cboDDMAST)
        Me.GroupBox1.Controls.Add(Me.lblNOTE)
        Me.GroupBox1.Controls.Add(Me.txtMARKETVALUE)
        Me.GroupBox1.Controls.Add(Me.lblMARKETVALUE)
        Me.GroupBox1.Controls.Add(Me.txtEXCHANGERATE)
        Me.GroupBox1.Controls.Add(Me.lblEXCHANGERATE)
        Me.GroupBox1.Controls.Add(Me.lblWords)
        Me.GroupBox1.Controls.Add(Me.lblAmountbyword)
        Me.GroupBox1.Controls.Add(Me.lblAMOUNT)
        Me.GroupBox1.Controls.Add(Me.txtHOLDBR)
        Me.GroupBox1.Controls.Add(Me.lblHOLDBR)
        Me.GroupBox1.Controls.Add(Me.txtHOLDBALANCE)
        Me.GroupBox1.Controls.Add(Me.lblCCYCD)
        Me.GroupBox1.Controls.Add(Me.lblHOLD)
        Me.GroupBox1.Controls.Add(Me.txtBALANCE)
        Me.GroupBox1.Controls.Add(Me.lblAccountNo)
        Me.GroupBox1.Controls.Add(Me.lblAVAILABLE)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(519, 118)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(556, 228)
        Me.GroupBox1.TabIndex = 79
        Me.GroupBox1.TabStop = False
        '
        'txtAmount
        '
        Me.txtAmount.EditValue = "0"
        Me.txtAmount.Location = New System.Drawing.Point(134, 98)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.txtAmount.Properties.Mask.EditMask = "n0"
        Me.txtAmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtAmount.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtAmount.Properties.MaxLength = 20
        Me.txtAmount.Size = New System.Drawing.Size(349, 20)
        Me.txtAmount.TabIndex = 10
        '
        'txtNOTE
        '
        Me.txtNOTE.Location = New System.Drawing.Point(134, 180)
        Me.txtNOTE.MaxLength = 150
        Me.txtNOTE.Name = "txtNOTE"
        Me.txtNOTE.Size = New System.Drawing.Size(398, 20)
        Me.txtNOTE.TabIndex = 11
        Me.txtNOTE.Tag = "NOTE"
        '
        'btnBilli
        '
        Me.btnBilli.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnBilli.Appearance.Options.UseFont = True
        Me.btnBilli.Location = New System.Drawing.Point(511, 98)
        Me.btnBilli.Name = "btnBilli"
        Me.btnBilli.Size = New System.Drawing.Size(21, 20)
        Me.btnBilli.TabIndex = 0
        Me.btnBilli.Text = "B"
        '
        'btnMili
        '
        Me.btnMili.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnMili.Appearance.Options.UseFont = True
        Me.btnMili.Location = New System.Drawing.Point(489, 98)
        Me.btnMili.Name = "btnMili"
        Me.btnMili.Size = New System.Drawing.Size(21, 20)
        Me.btnMili.TabIndex = 0
        Me.btnMili.Text = "M"
        '
        'btnCashUnhold1
        '
        Me.btnCashUnhold1.Location = New System.Drawing.Point(457, 203)
        Me.btnCashUnhold1.Name = "btnCashUnhold1"
        Me.btnCashUnhold1.Size = New System.Drawing.Size(75, 23)
        Me.btnCashUnhold1.TabIndex = 13
        Me.btnCashUnhold1.Text = "Unhold"
        Me.btnCashUnhold1.Visible = False
        '
        'btnCashHold
        '
        Me.btnCashHold.Location = New System.Drawing.Point(134, 203)
        Me.btnCashHold.Name = "btnCashHold"
        Me.btnCashHold.Size = New System.Drawing.Size(95, 23)
        Me.btnCashHold.TabIndex = 12
        Me.btnCashHold.Text = "Hold"
        '
        'cboDDMAST
        '
        Me.cboDDMAST.FormattingEnabled = True
        Me.cboDDMAST.Location = New System.Drawing.Point(134, 9)
        Me.cboDDMAST.Name = "cboDDMAST"
        Me.cboDDMAST.Size = New System.Drawing.Size(349, 21)
        Me.cboDDMAST.TabIndex = 9
        '
        'lblNOTE
        '
        Me.lblNOTE.Location = New System.Drawing.Point(8, 180)
        Me.lblNOTE.Name = "lblNOTE"
        Me.lblNOTE.Size = New System.Drawing.Size(80, 23)
        Me.lblNOTE.TabIndex = 73
        Me.lblNOTE.Tag = "lblNOTE"
        Me.lblNOTE.Text = "Note"
        '
        'txtMARKETVALUE
        '
        Me.txtMARKETVALUE.Enabled = False
        Me.txtMARKETVALUE.Location = New System.Drawing.Point(134, 158)
        Me.txtMARKETVALUE.MaxLength = 50
        Me.txtMARKETVALUE.Name = "txtMARKETVALUE"
        Me.txtMARKETVALUE.Size = New System.Drawing.Size(398, 20)
        Me.txtMARKETVALUE.TabIndex = 76
        Me.txtMARKETVALUE.Tag = "MARKETVALUE"
        Me.txtMARKETVALUE.Text = "txtMARKETVALUE"
        '
        'lblMARKETVALUE
        '
        Me.lblMARKETVALUE.Location = New System.Drawing.Point(8, 158)
        Me.lblMARKETVALUE.Name = "lblMARKETVALUE"
        Me.lblMARKETVALUE.Size = New System.Drawing.Size(80, 23)
        Me.lblMARKETVALUE.TabIndex = 74
        Me.lblMARKETVALUE.Tag = "lblMARKETVALUE"
        Me.lblMARKETVALUE.Text = "Market value"
        '
        'txtEXCHANGERATE
        '
        Me.txtEXCHANGERATE.Enabled = False
        Me.txtEXCHANGERATE.Location = New System.Drawing.Point(134, 136)
        Me.txtEXCHANGERATE.MaxLength = 50
        Me.txtEXCHANGERATE.Name = "txtEXCHANGERATE"
        Me.txtEXCHANGERATE.Size = New System.Drawing.Size(398, 20)
        Me.txtEXCHANGERATE.TabIndex = 75
        Me.txtEXCHANGERATE.Tag = "EXCHANGERATE"
        Me.txtEXCHANGERATE.Text = "txtEXCHANGERATE"
        '
        'lblEXCHANGERATE
        '
        Me.lblEXCHANGERATE.Location = New System.Drawing.Point(8, 136)
        Me.lblEXCHANGERATE.Name = "lblEXCHANGERATE"
        Me.lblEXCHANGERATE.Size = New System.Drawing.Size(80, 23)
        Me.lblEXCHANGERATE.TabIndex = 71
        Me.lblEXCHANGERATE.Tag = "lblEXCHANGERATE"
        Me.lblEXCHANGERATE.Text = "Exchange rate"
        '
        'lblWords
        '
        Me.lblWords.Location = New System.Drawing.Point(131, 120)
        Me.lblWords.Name = "lblWords"
        Me.lblWords.Size = New System.Drawing.Size(289, 23)
        Me.lblWords.TabIndex = 68
        Me.lblWords.Tag = "AMOUNT"
        '
        'lblAmountbyword
        '
        Me.lblAmountbyword.Location = New System.Drawing.Point(8, 117)
        Me.lblAmountbyword.Name = "lblAmountbyword"
        Me.lblAmountbyword.Size = New System.Drawing.Size(108, 23)
        Me.lblAmountbyword.TabIndex = 68
        Me.lblAmountbyword.Tag = "AMOUNT"
        Me.lblAmountbyword.Text = "In words"
        '
        'lblAMOUNT
        '
        Me.lblAMOUNT.Location = New System.Drawing.Point(8, 98)
        Me.lblAMOUNT.Name = "lblAMOUNT"
        Me.lblAMOUNT.Size = New System.Drawing.Size(80, 23)
        Me.lblAMOUNT.TabIndex = 68
        Me.lblAMOUNT.Tag = "AMOUNT"
        Me.lblAMOUNT.Text = "Amount"
        '
        'txtHOLDBR
        '
        Me.txtHOLDBR.Enabled = False
        Me.txtHOLDBR.Location = New System.Drawing.Point(134, 76)
        Me.txtHOLDBR.MaxLength = 50
        Me.txtHOLDBR.Name = "txtHOLDBR"
        Me.txtHOLDBR.Size = New System.Drawing.Size(398, 20)
        Me.txtHOLDBR.TabIndex = 79
        Me.txtHOLDBR.Tag = "HOLDBR"
        Me.txtHOLDBR.Text = "txtHOLDBR"
        '
        'lblHOLDBR
        '
        Me.lblHOLDBR.Location = New System.Drawing.Point(8, 76)
        Me.lblHOLDBR.Name = "lblHOLDBR"
        Me.lblHOLDBR.Size = New System.Drawing.Size(145, 23)
        Me.lblHOLDBR.TabIndex = 70
        Me.lblHOLDBR.Tag = "lblHOLDBR"
        Me.lblHOLDBR.Text = "Total hold by broker"
        '
        'txtHOLDBALANCE
        '
        Me.txtHOLDBALANCE.Enabled = False
        Me.txtHOLDBALANCE.Location = New System.Drawing.Point(134, 54)
        Me.txtHOLDBALANCE.MaxLength = 50
        Me.txtHOLDBALANCE.Name = "txtHOLDBALANCE"
        Me.txtHOLDBALANCE.Size = New System.Drawing.Size(398, 20)
        Me.txtHOLDBALANCE.TabIndex = 80
        Me.txtHOLDBALANCE.Tag = "HOLDBALANCE"
        Me.txtHOLDBALANCE.Text = "txtHOLDBALANCE"
        '
        'lblCCYCD
        '
        Me.lblCCYCD.Location = New System.Drawing.Point(489, 11)
        Me.lblCCYCD.Name = "lblCCYCD"
        Me.lblCCYCD.Size = New System.Drawing.Size(45, 16)
        Me.lblCCYCD.TabIndex = 69
        Me.lblCCYCD.Tag = "lblCCYCD"
        Me.lblCCYCD.Text = "VND"
        '
        'lblHOLD
        '
        Me.lblHOLD.Location = New System.Drawing.Point(8, 54)
        Me.lblHOLD.Name = "lblHOLD"
        Me.lblHOLD.Size = New System.Drawing.Size(127, 23)
        Me.lblHOLD.TabIndex = 69
        Me.lblHOLD.Tag = "lblHOLD"
        Me.lblHOLD.Text = "Total hold"
        '
        'txtBALANCE
        '
        Me.txtBALANCE.Enabled = False
        Me.txtBALANCE.Location = New System.Drawing.Point(134, 32)
        Me.txtBALANCE.MaxLength = 50
        Me.txtBALANCE.Name = "txtBALANCE"
        Me.txtBALANCE.Size = New System.Drawing.Size(398, 20)
        Me.txtBALANCE.TabIndex = 78
        Me.txtBALANCE.Tag = "BALANCE"
        Me.txtBALANCE.Text = "txtBALANCE"
        '
        'lblAccountNo
        '
        Me.lblAccountNo.Location = New System.Drawing.Point(8, 13)
        Me.lblAccountNo.Name = "lblAccountNo"
        Me.lblAccountNo.Size = New System.Drawing.Size(80, 18)
        Me.lblAccountNo.TabIndex = 72
        Me.lblAccountNo.Tag = "lblAVAILABLE"
        Me.lblAccountNo.Text = "Account No"
        '
        'lblAVAILABLE
        '
        Me.lblAVAILABLE.Location = New System.Drawing.Point(8, 32)
        Me.lblAVAILABLE.Name = "lblAVAILABLE"
        Me.lblAVAILABLE.Size = New System.Drawing.Size(108, 23)
        Me.lblAVAILABLE.TabIndex = 72
        Me.lblAVAILABLE.Tag = "lblBALANCE"
        Me.lblAVAILABLE.Text = "Available balance"
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
        'btnEXRATERefresh
        '
        Me.btnEXRATERefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEXRATERefresh.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnEXRATERefresh.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnEXRATERefresh.Location = New System.Drawing.Point(1873, 97)
        Me.btnEXRATERefresh.Name = "btnEXRATERefresh"
        Me.btnEXRATERefresh.Size = New System.Drawing.Size(23, 20)
        Me.btnEXRATERefresh.TabIndex = 80
        Me.btnEXRATERefresh.Text = "..."
        '
        'btnBankInquiry
        '
        Me.btnBankInquiry.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBankInquiry.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnBankInquiry.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnBankInquiry.Location = New System.Drawing.Point(1873, 209)
        Me.btnBankInquiry.Name = "btnBankInquiry"
        Me.btnBankInquiry.Size = New System.Drawing.Size(23, 20)
        Me.btnBankInquiry.TabIndex = 80
        Me.btnBankInquiry.Text = "..."
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
        'DataTable49
        '
        Me.DataTable49.Namespace = ""
        Me.DataTable49.TableName = "COMBOBOX"
        '
        'DataTable50
        '
        Me.DataTable50.Namespace = ""
        Me.DataTable50.TableName = "COMBOBOX"
        '
        'DataTable51
        '
        Me.DataTable51.Namespace = ""
        Me.DataTable51.TableName = "COMBOBOX"
        '
        'DataTable52
        '
        Me.DataTable52.Namespace = ""
        Me.DataTable52.TableName = "COMBOBOX"
        '
        'DataTable53
        '
        Me.DataTable53.Namespace = ""
        Me.DataTable53.TableName = "COMBOBOX"
        '
        'DataTable54
        '
        Me.DataTable54.Namespace = ""
        Me.DataTable54.TableName = "COMBOBOX"
        '
        'DataTable55
        '
        Me.DataTable55.Namespace = ""
        Me.DataTable55.TableName = "COMBOBOX"
        '
        'DataTable56
        '
        Me.DataTable56.Namespace = ""
        Me.DataTable56.TableName = "COMBOBOX"
        '
        'DataTable57
        '
        Me.DataTable57.Namespace = ""
        Me.DataTable57.TableName = "COMBOBOX"
        '
        'DataTable58
        '
        Me.DataTable58.Namespace = ""
        Me.DataTable58.TableName = "COMBOBOX"
        '
        'DataTable59
        '
        Me.DataTable59.Namespace = ""
        Me.DataTable59.TableName = "COMBOBOX"
        '
        'DataTable60
        '
        Me.DataTable60.Namespace = ""
        Me.DataTable60.TableName = "COMBOBOX"
        '
        'DataTable61
        '
        Me.DataTable61.Namespace = ""
        Me.DataTable61.TableName = "COMBOBOX"
        '
        'DataTable62
        '
        Me.DataTable62.Namespace = ""
        Me.DataTable62.TableName = "COMBOBOX"
        '
        'DataTable63
        '
        Me.DataTable63.Namespace = ""
        Me.DataTable63.TableName = "COMBOBOX"
        '
        'DataTable64
        '
        Me.DataTable64.Namespace = ""
        Me.DataTable64.TableName = "COMBOBOX"
        '
        'DataTable65
        '
        Me.DataTable65.Namespace = ""
        Me.DataTable65.TableName = "COMBOBOX"
        '
        'DataTable66
        '
        Me.DataTable66.Namespace = ""
        Me.DataTable66.TableName = "COMBOBOX"
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.pnInfo)
        Me.Panel1.Controls.Add(Me.tabCashMain)
        Me.Panel1.Controls.Add(Me.btnBankInquiry)
        Me.Panel1.Controls.Add(Me.tabSEMain)
        Me.Panel1.Controls.Add(Me.lblSE)
        Me.Panel1.Controls.Add(Me.pnlBankAccount)
        Me.Panel1.Controls.Add(Me.btnEXRATERefresh)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.lblBankAccount)
        Me.Panel1.Controls.Add(Me.pnlExchangeRate)
        Me.Panel1.Controls.Add(Me.lblCash)
        Me.Panel1.Controls.Add(Me.lblER)
        Me.Panel1.Location = New System.Drawing.Point(4, 5)
        Me.Panel1.MinimumSize = New System.Drawing.Size(1600, 895)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1900, 895)
        Me.Panel1.TabIndex = 81
        '
        'frmBrokerConfirm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1904, 901)
        Me.Controls.Add(Me.Panel1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBrokerConfirm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmBrokerConfirm"
        Me.pnInfo.ResumeLayout(False)
        Me.pnInfo.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.txtQuantity.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabSEMain.ResumeLayout(False)
        Me.tabBROKER_SEHOLD.ResumeLayout(False)
        Me.tabBROKER_SEUNHOLD.ResumeLayout(False)
        Me.tabSE_SUMMARY_BROKER.ResumeLayout(False)
        Me.tabBROKER_SEMAST.ResumeLayout(False)
        Me.tabNOTE.ResumeLayout(False)
        Me.tabNOTE.PerformLayout()
        Me.tabCashMain.ResumeLayout(False)
        Me.tabBROKER_CASHHOLD.ResumeLayout(False)
        Me.tabBROKER_CASHUNHOLD.ResumeLayout(False)
        Me.tabCASH_SUMMARY_BROKER.ResumeLayout(False)
        Me.tabBROKER_DDMAST.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txtAmount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.DataTable49, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable50, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable51, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable52, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable53, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable54, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable55, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable56, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable57, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable58, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable59, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable60, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable61, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable62, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable63, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable64, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable65, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable66, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents tmrOrder As System.Windows.Forms.Timer
    Friend WithEvents lblSTC As System.Windows.Forms.Label
    Friend WithEvents pnInfo As System.Windows.Forms.Panel
    Friend WithEvents txtSTC As System.Windows.Forms.TextBox
    Friend WithEvents lblBROKER As System.Windows.Forms.Label
    Friend WithEvents cboBROKER As System.Windows.Forms.ComboBox
    Friend WithEvents cboPhone As System.Windows.Forms.ComboBox
    Friend WithEvents lblFX As System.Windows.Forms.Label
    Friend WithEvents lblPHONE As System.Windows.Forms.Label
    Friend WithEvents cboFX As System.Windows.Forms.ComboBox
    Friend WithEvents lblEmploy As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNoteSE As System.Windows.Forms.TextBox
    Friend WithEvents lblNoteSE As System.Windows.Forms.Label
    Friend WithEvents lblQuantity As System.Windows.Forms.Label
    Friend WithEvents txtSEBLOCKEDBR As System.Windows.Forms.TextBox
    Friend WithEvents lblLockbyBroker As System.Windows.Forms.Label
    Friend WithEvents lblTotalBlockQtty As System.Windows.Forms.Label
    Friend WithEvents txtSETRADE As System.Windows.Forms.TextBox
    Friend WithEvents lblAvaiQtty As System.Windows.Forms.Label
    Friend WithEvents txtSENAMEVN As System.Windows.Forms.TextBox
    Friend WithEvents lblNameVN As System.Windows.Forms.Label
    Friend WithEvents txtSENAMEEN As System.Windows.Forms.TextBox
    Friend WithEvents lblNameEN As System.Windows.Forms.Label
    Friend WithEvents cboSymbol As System.Windows.Forms.ComboBox
    Friend WithEvents lblSECID As System.Windows.Forms.Label
    Friend WithEvents cboAFMAST As System.Windows.Forms.ComboBox
    Friend WithEvents DataTable1 As System.Data.DataTable
    Friend WithEvents DataTable2 As System.Data.DataTable
    Friend WithEvents DataTable3 As System.Data.DataTable
    Friend WithEvents DataTable4 As System.Data.DataTable
    Friend WithEvents DataTable5 As System.Data.DataTable
    Friend WithEvents DataTable6 As System.Data.DataTable
    Friend WithEvents lblSE As System.Windows.Forms.Label
    Friend WithEvents pnlSEHOLD As System.Windows.Forms.Panel
    Friend WithEvents pnlExchangeRate As System.Windows.Forms.Panel
    Friend WithEvents pnlBankAccount As System.Windows.Forms.Panel
    Friend WithEvents tabSEMain As System.Windows.Forms.TabControl
    Friend WithEvents tabBROKER_SEHOLD As System.Windows.Forms.TabPage
    Friend WithEvents tabBROKER_SEMAST As System.Windows.Forms.TabPage
    Friend WithEvents pnlSE As System.Windows.Forms.Panel
    Friend WithEvents tabCashMain As System.Windows.Forms.TabControl
    Friend WithEvents tabBROKER_CASHHOLD As System.Windows.Forms.TabPage
    Friend WithEvents pnlCashHold As System.Windows.Forms.Panel
    Friend WithEvents tabBROKER_DDMAST As System.Windows.Forms.TabPage
    Friend WithEvents pnlCash As System.Windows.Forms.Panel
    Friend WithEvents lblER As System.Windows.Forms.Label
    Friend WithEvents lblBankAccount As System.Windows.Forms.Label
    Friend WithEvents lblCash As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNOTE As System.Windows.Forms.TextBox
    Friend WithEvents cboDDMAST As System.Windows.Forms.ComboBox
    Friend WithEvents txtMARKETVALUE As System.Windows.Forms.TextBox
    Friend WithEvents lblMARKETVALUE As System.Windows.Forms.Label
    Friend WithEvents txtEXCHANGERATE As System.Windows.Forms.TextBox
    Friend WithEvents lblEXCHANGERATE As System.Windows.Forms.Label
    Friend WithEvents lblAMOUNT As System.Windows.Forms.Label
    Friend WithEvents txtHOLDBR As System.Windows.Forms.TextBox
    Friend WithEvents lblHOLDBR As System.Windows.Forms.Label
    Friend WithEvents txtHOLDBALANCE As System.Windows.Forms.TextBox
    Friend WithEvents lblCCYCD As System.Windows.Forms.Label
    Friend WithEvents lblHOLD As System.Windows.Forms.Label
    Friend WithEvents txtBALANCE As System.Windows.Forms.TextBox
    Friend WithEvents lblAccountNo As System.Windows.Forms.Label
    Friend WithEvents lblAVAILABLE As System.Windows.Forms.Label
    Friend WithEvents DataTable7 As System.Data.DataTable
    Friend WithEvents DataTable8 As System.Data.DataTable
    Friend WithEvents DataTable9 As System.Data.DataTable
    Friend WithEvents DataTable10 As System.Data.DataTable
    Friend WithEvents DataTable11 As System.Data.DataTable
    Friend WithEvents DataTable12 As System.Data.DataTable
    Friend WithEvents DataTable13 As System.Data.DataTable
    Friend WithEvents DataTable14 As System.Data.DataTable
    Friend WithEvents DataTable15 As System.Data.DataTable
    Friend WithEvents DataTable16 As System.Data.DataTable
    Friend WithEvents DataTable17 As System.Data.DataTable
    Friend WithEvents DataTable18 As System.Data.DataTable
    Friend WithEvents DataTable19 As System.Data.DataTable
    Friend WithEvents DataTable20 As System.Data.DataTable
    Friend WithEvents DataTable21 As System.Data.DataTable
    Friend WithEvents DataTable22 As System.Data.DataTable
    Friend WithEvents DataTable23 As System.Data.DataTable
    Friend WithEvents DataTable24 As System.Data.DataTable
    Friend WithEvents tabBROKER_SEUNHOLD As System.Windows.Forms.TabPage
    Friend WithEvents pnlUnholdSE As System.Windows.Forms.Panel
    Friend WithEvents tabBROKER_CASHUNHOLD As System.Windows.Forms.TabPage
    Friend WithEvents pnlCashUnhold As System.Windows.Forms.Panel
    Friend WithEvents lblWords As System.Windows.Forms.Label
    Friend WithEvents btnHoldSE As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblAmountbyword As System.Windows.Forms.Label
    Friend WithEvents btnCashUnhold1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCashHold As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnUnholdSE As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnBilli As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnMili As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblNOTE As System.Windows.Forms.Label
    Friend WithEvents txtAmount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtQuantity As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtSEBLOCKED As System.Windows.Forms.TextBox
    Friend WithEvents lblQByword As System.Windows.Forms.Label
    Friend WithEvents lblQtBuyWord As System.Windows.Forms.Label
    Friend WithEvents lblISSSHORTNAME As System.Windows.Forms.Label
    Friend WithEvents btnEXRATERefresh As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnBankInquiry As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSendMail As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DataTable25 As System.Data.DataTable
    Friend WithEvents DataTable26 As System.Data.DataTable
    Friend WithEvents DataTable27 As System.Data.DataTable
    Friend WithEvents DataTable28 As System.Data.DataTable
    Friend WithEvents DataTable29 As System.Data.DataTable
    Friend WithEvents DataTable30 As System.Data.DataTable
    Friend WithEvents DataTable31 As System.Data.DataTable
    Friend WithEvents DataTable32 As System.Data.DataTable
    Friend WithEvents DataTable33 As System.Data.DataTable
    Friend WithEvents DataTable34 As System.Data.DataTable
    Friend WithEvents DataTable35 As System.Data.DataTable
    Friend WithEvents DataTable36 As System.Data.DataTable
    Friend WithEvents DataTable37 As System.Data.DataTable
    Friend WithEvents DataTable38 As System.Data.DataTable
    Friend WithEvents DataTable39 As System.Data.DataTable
    Friend WithEvents DataTable40 As System.Data.DataTable
    Friend WithEvents DataTable41 As System.Data.DataTable
    Friend WithEvents DataTable42 As System.Data.DataTable
    Friend WithEvents DataTable43 As System.Data.DataTable
    Friend WithEvents DataTable44 As System.Data.DataTable
    Friend WithEvents DataTable45 As System.Data.DataTable
    Friend WithEvents DataTable46 As System.Data.DataTable
    Friend WithEvents DataTable47 As System.Data.DataTable
    Friend WithEvents DataTable48 As System.Data.DataTable
    Friend WithEvents DataTable49 As System.Data.DataTable
    Friend WithEvents DataTable50 As System.Data.DataTable
    Friend WithEvents DataTable51 As System.Data.DataTable
    Friend WithEvents DataTable52 As System.Data.DataTable
    Friend WithEvents DataTable53 As System.Data.DataTable
    Friend WithEvents DataTable54 As System.Data.DataTable
    Friend WithEvents DataTable55 As System.Data.DataTable
    Friend WithEvents DataTable56 As System.Data.DataTable
    Friend WithEvents DataTable57 As System.Data.DataTable
    Friend WithEvents DataTable58 As System.Data.DataTable
    Friend WithEvents DataTable59 As System.Data.DataTable
    Friend WithEvents DataTable60 As System.Data.DataTable
    Friend WithEvents DataTable61 As System.Data.DataTable
    Friend WithEvents DataTable62 As System.Data.DataTable
    Friend WithEvents DataTable63 As System.Data.DataTable
    Friend WithEvents DataTable64 As System.Data.DataTable
    Friend WithEvents DataTable65 As System.Data.DataTable
    Friend WithEvents cboEmploy As System.Windows.Forms.ComboBox
    Friend WithEvents tabCASH_SUMMARY_BROKER As System.Windows.Forms.TabPage
    Friend WithEvents pnCashSummary As System.Windows.Forms.Panel
    Friend WithEvents tabSE_SUMMARY_BROKER As System.Windows.Forms.TabPage
    Friend WithEvents pnStockSummary As System.Windows.Forms.Panel
    Friend WithEvents tabNOTE As System.Windows.Forms.TabPage
    Friend WithEvents txtTabNotes As System.Windows.Forms.TextBox
    Friend WithEvents DataTable66 As System.Data.DataTable
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblMFULLNAME As System.Windows.Forms.Label
    Friend WithEvents txtMCUSTODYCD As System.Windows.Forms.TextBox
    Friend WithEvents lblMCUSTODYCD As System.Windows.Forms.Label
End Class
