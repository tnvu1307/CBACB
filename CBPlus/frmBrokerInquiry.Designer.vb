<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBrokerInquiry
    Inherits AppCore.frmMaintenance

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBrokerInquiry))
        Me.grbAF = New System.Windows.Forms.GroupBox
        Me.lblSESECUREDV = New System.Windows.Forms.Label
        Me.lblACCOUNTVALUEV = New System.Windows.Forms.Label
        Me.lblSESECURED = New System.Windows.Forms.Label
        Me.lblACCOUNTVALUE = New System.Windows.Forms.Label
        Me.lblMARGINRATEV = New System.Windows.Forms.Label
        Me.lblPP0V = New System.Windows.Forms.Label
        Me.lblNETASSVALUEV = New System.Windows.Forms.Label
        Me.lblTOTALODAMTV = New System.Windows.Forms.Label
        Me.lblTOTALSEAMTV = New System.Windows.Forms.Label
        Me.lblBALANCEV = New System.Windows.Forms.Label
        Me.lblNETASSVALUE = New System.Windows.Forms.Label
        Me.lblTOTALODAMT = New System.Windows.Forms.Label
        Me.lblMARGINRATE = New System.Windows.Forms.Label
        Me.lblTOTALSEAMT = New System.Windows.Forms.Label
        Me.lblPP0 = New System.Windows.Forms.Label
        Me.lblBALANCE = New System.Windows.Forms.Label
        Me.grbCF = New System.Windows.Forms.GroupBox
        Me.btnRefresh = New System.Windows.Forms.Button
        Me.lblAFACCTNO = New System.Windows.Forms.Label
        Me.lblCUSTODYCD = New System.Windows.Forms.Label
        Me.cboAFACCTNO = New AppCore.ComboBoxEx
        Me.txtCUSTODYCD = New System.Windows.Forms.TextBox
        Me.grbPPSE = New System.Windows.Forms.GroupBox
        Me.lblADVANCELINE = New System.Windows.Forms.Label
        Me.txtADVANCELINE = New System.Windows.Forms.TextBox
        Me.lblAVLLIMIT = New System.Windows.Forms.Label
        Me.txtAVLLIMIT = New System.Windows.Forms.TextBox
        Me.lblMRCRLIMITMAX = New System.Windows.Forms.Label
        Me.txtMRCRLIMITMAX = New System.Windows.Forms.TextBox
        Me.txtSYMBOL = New System.Windows.Forms.TextBox
        Me.lblPPSE = New System.Windows.Forms.Label
        Me.lblSYMBOL = New System.Windows.Forms.Label
        Me.txtPPSE = New System.Windows.Forms.TextBox
        Me.txtPRICE = New System.Windows.Forms.TextBox
        Me.lblPRICE = New System.Windows.Forms.Label
        Me.grbSE = New System.Windows.Forms.GroupBox
        Me.grbReports = New System.Windows.Forms.GroupBox
        Me.btnMRCALL = New System.Windows.Forms.Button
        Me.btnLNREPORT = New System.Windows.Forms.Button
        Me.btnAFCALL = New System.Windows.Forms.Button
        Me.btnCAREPORT = New System.Windows.Forms.Button
        Me.btnTRFBUY = New System.Windows.Forms.Button
        Me.btnODADV = New System.Windows.Forms.Button
        Me.btnAFREPORT = New System.Windows.Forms.Button
        Me.btnCIREPORT = New System.Windows.Forms.Button
        Me.btnSEREPORT = New System.Windows.Forms.Button
        Me.btnODHISTORY = New System.Windows.Forms.Button
        Me.DataTable1 = New System.Data.DataTable
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblBankInfo = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.grbAF.SuspendLayout()
        Me.grbCF.SuspendLayout()
        Me.grbPPSE.SuspendLayout()
        Me.grbReports.SuspendLayout()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(690, 571)
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(850, 571)
        Me.btnCancel.TabIndex = 0
        '
        'lblCaption
        '
        Me.lblCaption.Location = New System.Drawing.Point(7, 9)
        '
        'btnApply
        '
        Me.btnApply.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnApply.Location = New System.Drawing.Point(770, 571)
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.None
        Me.Panel1.Location = New System.Drawing.Point(3, 0)
        Me.Panel1.Size = New System.Drawing.Size(931, 56)
        '
        'btnApprv
        '
        Me.btnApprv.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnApprv.Location = New System.Drawing.Point(609, 571)
        '
        'cboLink
        '
        Me.cboLink.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboLink.Location = New System.Drawing.Point(25, 573)
        Me.cboLink.Visible = False
        '
        'grbAF
        '
        Me.grbAF.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbAF.Controls.Add(Me.lblSESECUREDV)
        Me.grbAF.Controls.Add(Me.lblACCOUNTVALUEV)
        Me.grbAF.Controls.Add(Me.lblSESECURED)
        Me.grbAF.Controls.Add(Me.lblACCOUNTVALUE)
        Me.grbAF.Controls.Add(Me.lblMARGINRATEV)
        Me.grbAF.Controls.Add(Me.lblPP0V)
        Me.grbAF.Controls.Add(Me.lblNETASSVALUEV)
        Me.grbAF.Controls.Add(Me.lblTOTALODAMTV)
        Me.grbAF.Controls.Add(Me.lblTOTALSEAMTV)
        Me.grbAF.Controls.Add(Me.lblBALANCEV)
        Me.grbAF.Controls.Add(Me.lblNETASSVALUE)
        Me.grbAF.Controls.Add(Me.lblTOTALODAMT)
        Me.grbAF.Controls.Add(Me.lblMARGINRATE)
        Me.grbAF.Controls.Add(Me.lblTOTALSEAMT)
        Me.grbAF.Controls.Add(Me.lblPP0)
        Me.grbAF.Controls.Add(Me.lblBALANCE)
        Me.grbAF.Location = New System.Drawing.Point(3, 125)
        Me.grbAF.Name = "grbAF"
        Me.grbAF.Size = New System.Drawing.Size(931, 130)
        Me.grbAF.TabIndex = 1
        Me.grbAF.TabStop = False
        Me.grbAF.Tag = "grbAF"
        '
        'lblSESECUREDV
        '
        Me.lblSESECUREDV.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSESECUREDV.Location = New System.Drawing.Point(715, 17)
        Me.lblSESECUREDV.Name = "lblSESECUREDV"
        Me.lblSESECUREDV.Size = New System.Drawing.Size(152, 13)
        Me.lblSESECUREDV.TabIndex = 32
        Me.lblSESECUREDV.Tag = "lblSESECUREDV"
        Me.lblSESECUREDV.Text = "0"
        '
        'lblACCOUNTVALUEV
        '
        Me.lblACCOUNTVALUEV.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblACCOUNTVALUEV.Location = New System.Drawing.Point(715, 43)
        Me.lblACCOUNTVALUEV.Name = "lblACCOUNTVALUEV"
        Me.lblACCOUNTVALUEV.Size = New System.Drawing.Size(152, 13)
        Me.lblACCOUNTVALUEV.TabIndex = 31
        Me.lblACCOUNTVALUEV.Tag = "lblACCOUNTVALUEV"
        Me.lblACCOUNTVALUEV.Text = "0"
        '
        'lblSESECURED
        '
        Me.lblSESECURED.AutoSize = True
        Me.lblSESECURED.Location = New System.Drawing.Point(468, 17)
        Me.lblSESECURED.Name = "lblSESECURED"
        Me.lblSESECURED.Size = New System.Drawing.Size(75, 13)
        Me.lblSESECURED.TabIndex = 30
        Me.lblSESECURED.Tag = "lblSESECURED"
        Me.lblSESECURED.Text = "lblSESECURED"
        '
        'lblACCOUNTVALUE
        '
        Me.lblACCOUNTVALUE.AutoSize = True
        Me.lblACCOUNTVALUE.Location = New System.Drawing.Point(468, 44)
        Me.lblACCOUNTVALUE.Name = "lblACCOUNTVALUE"
        Me.lblACCOUNTVALUE.Size = New System.Drawing.Size(97, 13)
        Me.lblACCOUNTVALUE.TabIndex = 29
        Me.lblACCOUNTVALUE.Tag = "lblACCOUNTVALUE"
        Me.lblACCOUNTVALUE.Text = "lblACCOUNTVALUE"
        '
        'lblMARGINRATEV
        '
        Me.lblMARGINRATEV.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMARGINRATEV.Location = New System.Drawing.Point(715, 98)
        Me.lblMARGINRATEV.Name = "lblMARGINRATEV"
        Me.lblMARGINRATEV.Size = New System.Drawing.Size(152, 13)
        Me.lblMARGINRATEV.TabIndex = 28
        Me.lblMARGINRATEV.Tag = "lblMARGINRATEV"
        Me.lblMARGINRATEV.Text = "0"
        '
        'lblPP0V
        '
        Me.lblPP0V.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPP0V.Location = New System.Drawing.Point(715, 71)
        Me.lblPP0V.Name = "lblPP0V"
        Me.lblPP0V.Size = New System.Drawing.Size(152, 13)
        Me.lblPP0V.TabIndex = 25
        Me.lblPP0V.Tag = "lblPP0V"
        Me.lblPP0V.Text = "0"
        '
        'lblNETASSVALUEV
        '
        Me.lblNETASSVALUEV.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNETASSVALUEV.Location = New System.Drawing.Point(261, 98)
        Me.lblNETASSVALUEV.Name = "lblNETASSVALUEV"
        Me.lblNETASSVALUEV.Size = New System.Drawing.Size(152, 13)
        Me.lblNETASSVALUEV.TabIndex = 24
        Me.lblNETASSVALUEV.Tag = "lblNETASSVALUEV"
        Me.lblNETASSVALUEV.Text = "0"
        '
        'lblTOTALODAMTV
        '
        Me.lblTOTALODAMTV.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTOTALODAMTV.Location = New System.Drawing.Point(261, 71)
        Me.lblTOTALODAMTV.Name = "lblTOTALODAMTV"
        Me.lblTOTALODAMTV.Size = New System.Drawing.Size(152, 13)
        Me.lblTOTALODAMTV.TabIndex = 23
        Me.lblTOTALODAMTV.Tag = "lblTOTALODAMTV"
        Me.lblTOTALODAMTV.Text = "0"
        '
        'lblTOTALSEAMTV
        '
        Me.lblTOTALSEAMTV.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTOTALSEAMTV.Location = New System.Drawing.Point(261, 43)
        Me.lblTOTALSEAMTV.Name = "lblTOTALSEAMTV"
        Me.lblTOTALSEAMTV.Size = New System.Drawing.Size(152, 13)
        Me.lblTOTALSEAMTV.TabIndex = 22
        Me.lblTOTALSEAMTV.Tag = "lblTOTALSEAMTV"
        Me.lblTOTALSEAMTV.Text = "0"
        '
        'lblBALANCEV
        '
        Me.lblBALANCEV.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBALANCEV.Location = New System.Drawing.Point(261, 17)
        Me.lblBALANCEV.Name = "lblBALANCEV"
        Me.lblBALANCEV.Size = New System.Drawing.Size(152, 13)
        Me.lblBALANCEV.TabIndex = 21
        Me.lblBALANCEV.Tag = "lblBALANCEV"
        Me.lblBALANCEV.Text = "0"
        '
        'lblNETASSVALUE
        '
        Me.lblNETASSVALUE.AutoSize = True
        Me.lblNETASSVALUE.Location = New System.Drawing.Point(9, 98)
        Me.lblNETASSVALUE.Name = "lblNETASSVALUE"
        Me.lblNETASSVALUE.Size = New System.Drawing.Size(86, 13)
        Me.lblNETASSVALUE.TabIndex = 14
        Me.lblNETASSVALUE.Tag = "lblNETASSVALUE"
        Me.lblNETASSVALUE.Text = "lblNETASSVALUE"
        '
        'lblTOTALODAMT
        '
        Me.lblTOTALODAMT.AutoSize = True
        Me.lblTOTALODAMT.Location = New System.Drawing.Point(9, 71)
        Me.lblTOTALODAMT.Name = "lblTOTALODAMT"
        Me.lblTOTALODAMT.Size = New System.Drawing.Size(85, 13)
        Me.lblTOTALODAMT.TabIndex = 12
        Me.lblTOTALODAMT.Tag = "lblTOTALODAMT"
        Me.lblTOTALODAMT.Text = "lblTOTALODAMT"
        '
        'lblMARGINRATE
        '
        Me.lblMARGINRATE.AutoSize = True
        Me.lblMARGINRATE.Location = New System.Drawing.Point(468, 98)
        Me.lblMARGINRATE.Name = "lblMARGINRATE"
        Me.lblMARGINRATE.Size = New System.Drawing.Size(83, 13)
        Me.lblMARGINRATE.TabIndex = 10
        Me.lblMARGINRATE.Tag = "lblMARGINRATE"
        Me.lblMARGINRATE.Text = "lblMARGINRATE"
        '
        'lblTOTALSEAMT
        '
        Me.lblTOTALSEAMT.AutoSize = True
        Me.lblTOTALSEAMT.Location = New System.Drawing.Point(9, 44)
        Me.lblTOTALSEAMT.Name = "lblTOTALSEAMT"
        Me.lblTOTALSEAMT.Size = New System.Drawing.Size(82, 13)
        Me.lblTOTALSEAMT.TabIndex = 8
        Me.lblTOTALSEAMT.Tag = "lblTOTALSEAMT"
        Me.lblTOTALSEAMT.Text = "lblTOTALSEAMT"
        '
        'lblPP0
        '
        Me.lblPP0.AutoSize = True
        Me.lblPP0.Location = New System.Drawing.Point(468, 71)
        Me.lblPP0.Name = "lblPP0"
        Me.lblPP0.Size = New System.Drawing.Size(35, 13)
        Me.lblPP0.TabIndex = 6
        Me.lblPP0.Tag = "lblPP0"
        Me.lblPP0.Text = "lblPP0"
        '
        'lblBALANCE
        '
        Me.lblBALANCE.AutoSize = True
        Me.lblBALANCE.Location = New System.Drawing.Point(9, 17)
        Me.lblBALANCE.Name = "lblBALANCE"
        Me.lblBALANCE.Size = New System.Drawing.Size(62, 13)
        Me.lblBALANCE.TabIndex = 4
        Me.lblBALANCE.Tag = "lblBALANCE"
        Me.lblBALANCE.Text = "lblBALANCE"
        '
        'grbCF
        '
        Me.grbCF.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbCF.Controls.Add(Me.lblBankInfo)
        Me.grbCF.Controls.Add(Me.btnRefresh)
        Me.grbCF.Controls.Add(Me.lblAFACCTNO)
        Me.grbCF.Controls.Add(Me.lblCUSTODYCD)
        Me.grbCF.Controls.Add(Me.cboAFACCTNO)
        Me.grbCF.Controls.Add(Me.txtCUSTODYCD)
        Me.grbCF.Location = New System.Drawing.Point(3, 50)
        Me.grbCF.Name = "grbCF"
        Me.grbCF.Size = New System.Drawing.Size(931, 78)
        Me.grbCF.TabIndex = 0
        Me.grbCF.TabStop = False
        Me.grbCF.Tag = "grbCF"
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(853, 20)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(75, 23)
        Me.btnRefresh.TabIndex = 3
        Me.btnRefresh.Tag = "btnRefresh"
        Me.btnRefresh.Text = "btnRefresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'lblAFACCTNO
        '
        Me.lblAFACCTNO.AutoSize = True
        Me.lblAFACCTNO.Location = New System.Drawing.Point(244, 23)
        Me.lblAFACCTNO.Name = "lblAFACCTNO"
        Me.lblAFACCTNO.Size = New System.Drawing.Size(72, 13)
        Me.lblAFACCTNO.TabIndex = 2
        Me.lblAFACCTNO.Tag = "lblAFACCTNO"
        Me.lblAFACCTNO.Text = "lblAFACCTNO"
        '
        'lblCUSTODYCD
        '
        Me.lblCUSTODYCD.AutoSize = True
        Me.lblCUSTODYCD.Location = New System.Drawing.Point(6, 23)
        Me.lblCUSTODYCD.Name = "lblCUSTODYCD"
        Me.lblCUSTODYCD.Size = New System.Drawing.Size(78, 13)
        Me.lblCUSTODYCD.TabIndex = 0
        Me.lblCUSTODYCD.Tag = "lblCUSTODYCD"
        Me.lblCUSTODYCD.Text = "lblCUSTODYCD"
        '
        'cboAFACCTNO
        '
        Me.cboAFACCTNO.DisplayMember = "DISPLAY"
        Me.cboAFACCTNO.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAFACCTNO.FormattingEnabled = True
        Me.cboAFACCTNO.Location = New System.Drawing.Point(388, 20)
        Me.cboAFACCTNO.Name = "cboAFACCTNO"
        Me.cboAFACCTNO.Size = New System.Drawing.Size(454, 21)
        Me.cboAFACCTNO.TabIndex = 1
        Me.cboAFACCTNO.Tag = "cboAFACCTNO"
        Me.cboAFACCTNO.ValueMember = "VALUE"
        '
        'txtCUSTODYCD
        '
        Me.txtCUSTODYCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCUSTODYCD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCUSTODYCD.Location = New System.Drawing.Point(115, 20)
        Me.txtCUSTODYCD.MaxLength = 10
        Me.txtCUSTODYCD.Name = "txtCUSTODYCD"
        Me.txtCUSTODYCD.Size = New System.Drawing.Size(100, 21)
        Me.txtCUSTODYCD.TabIndex = 0
        Me.txtCUSTODYCD.Tag = "txtCUSTODYCD"
        '
        'grbPPSE
        '
        Me.grbPPSE.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbPPSE.Controls.Add(Me.lblADVANCELINE)
        Me.grbPPSE.Controls.Add(Me.txtADVANCELINE)
        Me.grbPPSE.Controls.Add(Me.lblAVLLIMIT)
        Me.grbPPSE.Controls.Add(Me.txtAVLLIMIT)
        Me.grbPPSE.Controls.Add(Me.lblMRCRLIMITMAX)
        Me.grbPPSE.Controls.Add(Me.txtMRCRLIMITMAX)
        Me.grbPPSE.Controls.Add(Me.txtSYMBOL)
        Me.grbPPSE.Controls.Add(Me.lblPPSE)
        Me.grbPPSE.Controls.Add(Me.lblSYMBOL)
        Me.grbPPSE.Controls.Add(Me.txtPPSE)
        Me.grbPPSE.Controls.Add(Me.txtPRICE)
        Me.grbPPSE.Controls.Add(Me.lblPRICE)
        Me.grbPPSE.Location = New System.Drawing.Point(3, 492)
        Me.grbPPSE.Name = "grbPPSE"
        Me.grbPPSE.Size = New System.Drawing.Size(931, 75)
        Me.grbPPSE.TabIndex = 11
        Me.grbPPSE.TabStop = False
        Me.grbPPSE.Tag = "grbPPSE"
        Me.grbPPSE.Text = "grbPPSE"
        '
        'lblADVANCELINE
        '
        Me.lblADVANCELINE.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblADVANCELINE.AutoSize = True
        Me.lblADVANCELINE.Location = New System.Drawing.Point(596, 51)
        Me.lblADVANCELINE.Name = "lblADVANCELINE"
        Me.lblADVANCELINE.Size = New System.Drawing.Size(173, 13)
        Me.lblADVANCELINE.TabIndex = 16
        Me.lblADVANCELINE.Tag = "lblADVANCELINE"
        Me.lblADVANCELINE.Text = "Hạn mức bảo lãnh cấp trong ngày:"
        '
        'txtADVANCELINE
        '
        Me.txtADVANCELINE.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtADVANCELINE.Enabled = False
        Me.txtADVANCELINE.Location = New System.Drawing.Point(773, 48)
        Me.txtADVANCELINE.Name = "txtADVANCELINE"
        Me.txtADVANCELINE.ReadOnly = True
        Me.txtADVANCELINE.Size = New System.Drawing.Size(131, 21)
        Me.txtADVANCELINE.TabIndex = 15
        Me.txtADVANCELINE.Tag = "txtADVANCELINE"
        Me.txtADVANCELINE.Text = "0"
        Me.txtADVANCELINE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblAVLLIMIT
        '
        Me.lblAVLLIMIT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAVLLIMIT.AutoSize = True
        Me.lblAVLLIMIT.Location = New System.Drawing.Point(300, 51)
        Me.lblAVLLIMIT.Name = "lblAVLLIMIT"
        Me.lblAVLLIMIT.Size = New System.Drawing.Size(107, 13)
        Me.lblAVLLIMIT.TabIndex = 14
        Me.lblAVLLIMIT.Tag = "lblAVLLIMIT"
        Me.lblAVLLIMIT.Text = "Hạn mức vay còn lại:"
        '
        'txtAVLLIMIT
        '
        Me.txtAVLLIMIT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAVLLIMIT.Enabled = False
        Me.txtAVLLIMIT.Location = New System.Drawing.Point(420, 48)
        Me.txtAVLLIMIT.Name = "txtAVLLIMIT"
        Me.txtAVLLIMIT.ReadOnly = True
        Me.txtAVLLIMIT.Size = New System.Drawing.Size(131, 21)
        Me.txtAVLLIMIT.TabIndex = 13
        Me.txtAVLLIMIT.Tag = "txtAVLLIMIT"
        Me.txtAVLLIMIT.Text = "0"
        Me.txtAVLLIMIT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblMRCRLIMITMAX
        '
        Me.lblMRCRLIMITMAX.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMRCRLIMITMAX.AutoSize = True
        Me.lblMRCRLIMITMAX.Location = New System.Drawing.Point(32, 51)
        Me.lblMRCRLIMITMAX.Name = "lblMRCRLIMITMAX"
        Me.lblMRCRLIMITMAX.Size = New System.Drawing.Size(104, 13)
        Me.lblMRCRLIMITMAX.TabIndex = 12
        Me.lblMRCRLIMITMAX.Tag = "lblMRCRLIMITMAX"
        Me.lblMRCRLIMITMAX.Text = "Hạn mức vay tối đa:"
        '
        'txtMRCRLIMITMAX
        '
        Me.txtMRCRLIMITMAX.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMRCRLIMITMAX.Enabled = False
        Me.txtMRCRLIMITMAX.Location = New System.Drawing.Point(143, 48)
        Me.txtMRCRLIMITMAX.Name = "txtMRCRLIMITMAX"
        Me.txtMRCRLIMITMAX.ReadOnly = True
        Me.txtMRCRLIMITMAX.Size = New System.Drawing.Size(131, 21)
        Me.txtMRCRLIMITMAX.TabIndex = 11
        Me.txtMRCRLIMITMAX.Tag = "txtMRCRLIMITMAX"
        Me.txtMRCRLIMITMAX.Text = "0"
        Me.txtMRCRLIMITMAX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSYMBOL
        '
        Me.txtSYMBOL.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtSYMBOL.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSYMBOL.Location = New System.Drawing.Point(90, 18)
        Me.txtSYMBOL.Name = "txtSYMBOL"
        Me.txtSYMBOL.Size = New System.Drawing.Size(94, 21)
        Me.txtSYMBOL.TabIndex = 0
        Me.txtSYMBOL.Tag = "txtSYMBOL"
        '
        'lblPPSE
        '
        Me.lblPPSE.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPPSE.AutoSize = True
        Me.lblPPSE.Location = New System.Drawing.Point(596, 21)
        Me.lblPPSE.Name = "lblPPSE"
        Me.lblPPSE.Size = New System.Drawing.Size(41, 13)
        Me.lblPPSE.TabIndex = 10
        Me.lblPPSE.Tag = "lblPPSE"
        Me.lblPPSE.Text = "lblPPSE"
        '
        'lblSYMBOL
        '
        Me.lblSYMBOL.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblSYMBOL.AutoSize = True
        Me.lblSYMBOL.Location = New System.Drawing.Point(31, 21)
        Me.lblSYMBOL.Name = "lblSYMBOL"
        Me.lblSYMBOL.Size = New System.Drawing.Size(56, 13)
        Me.lblSYMBOL.TabIndex = 4
        Me.lblSYMBOL.Tag = "lblSYMBOL"
        Me.lblSYMBOL.Text = "lblSYMBOL"
        '
        'txtPPSE
        '
        Me.txtPPSE.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPPSE.Enabled = False
        Me.txtPPSE.Location = New System.Drawing.Point(672, 18)
        Me.txtPPSE.Name = "txtPPSE"
        Me.txtPPSE.ReadOnly = True
        Me.txtPPSE.Size = New System.Drawing.Size(232, 21)
        Me.txtPPSE.TabIndex = 3
        Me.txtPPSE.Tag = "txtPPSE"
        Me.txtPPSE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPRICE
        '
        Me.txtPRICE.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtPRICE.Location = New System.Drawing.Point(301, 18)
        Me.txtPRICE.Name = "txtPRICE"
        Me.txtPRICE.Size = New System.Drawing.Size(119, 21)
        Me.txtPRICE.TabIndex = 1
        Me.txtPRICE.Tag = "txtPRICE"
        Me.txtPRICE.Text = "0"
        Me.txtPRICE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPRICE
        '
        Me.lblPRICE.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblPRICE.AutoSize = True
        Me.lblPRICE.Location = New System.Drawing.Point(222, 21)
        Me.lblPRICE.Name = "lblPRICE"
        Me.lblPRICE.Size = New System.Drawing.Size(47, 13)
        Me.lblPRICE.TabIndex = 6
        Me.lblPRICE.Tag = "lblPRICE"
        Me.lblPRICE.Text = "lblPRICE"
        '
        'grbSE
        '
        Me.grbSE.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbSE.Location = New System.Drawing.Point(3, 317)
        Me.grbSE.Name = "grbSE"
        Me.grbSE.Size = New System.Drawing.Size(931, 169)
        Me.grbSE.TabIndex = 0
        Me.grbSE.TabStop = False
        Me.grbSE.Tag = "grbSE"
        Me.grbSE.Text = "grbSE"
        '
        'grbReports
        '
        Me.grbReports.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbReports.Controls.Add(Me.btnMRCALL)
        Me.grbReports.Controls.Add(Me.btnLNREPORT)
        Me.grbReports.Controls.Add(Me.btnAFCALL)
        Me.grbReports.Controls.Add(Me.btnCAREPORT)
        Me.grbReports.Controls.Add(Me.btnTRFBUY)
        Me.grbReports.Controls.Add(Me.btnODADV)
        Me.grbReports.Controls.Add(Me.btnAFREPORT)
        Me.grbReports.Controls.Add(Me.btnCIREPORT)
        Me.grbReports.Controls.Add(Me.btnSEREPORT)
        Me.grbReports.Controls.Add(Me.btnODHISTORY)
        Me.grbReports.Location = New System.Drawing.Point(3, 258)
        Me.grbReports.Name = "grbReports"
        Me.grbReports.Size = New System.Drawing.Size(931, 53)
        Me.grbReports.TabIndex = 1
        Me.grbReports.TabStop = False
        Me.grbReports.Tag = "grbReports"
        Me.grbReports.Text = "grbReports"
        '
        'btnMRCALL
        '
        Me.btnMRCALL.Enabled = False
        Me.btnMRCALL.Location = New System.Drawing.Point(740, 20)
        Me.btnMRCALL.Name = "btnMRCALL"
        Me.btnMRCALL.Size = New System.Drawing.Size(85, 23)
        Me.btnMRCALL.TabIndex = 9
        Me.btnMRCALL.Tag = "btnMRCALL"
        Me.btnMRCALL.Text = "btnMRCALL"
        Me.btnMRCALL.UseVisualStyleBackColor = True
        '
        'btnLNREPORT
        '
        Me.btnLNREPORT.Enabled = False
        Me.btnLNREPORT.Location = New System.Drawing.Point(831, 20)
        Me.btnLNREPORT.Name = "btnLNREPORT"
        Me.btnLNREPORT.Size = New System.Drawing.Size(85, 23)
        Me.btnLNREPORT.TabIndex = 8
        Me.btnLNREPORT.Tag = "btnLNREPORT"
        Me.btnLNREPORT.Text = "btnLNREPORT"
        Me.btnLNREPORT.UseVisualStyleBackColor = True
        '
        'btnAFCALL
        '
        Me.btnAFCALL.Enabled = False
        Me.btnAFCALL.Location = New System.Drawing.Point(649, 20)
        Me.btnAFCALL.Name = "btnAFCALL"
        Me.btnAFCALL.Size = New System.Drawing.Size(85, 23)
        Me.btnAFCALL.TabIndex = 7
        Me.btnAFCALL.Tag = "btnAFCALL"
        Me.btnAFCALL.Text = "btnAFCALL"
        Me.btnAFCALL.UseVisualStyleBackColor = True
        '
        'btnCAREPORT
        '
        Me.btnCAREPORT.Enabled = False
        Me.btnCAREPORT.Location = New System.Drawing.Point(558, 20)
        Me.btnCAREPORT.Name = "btnCAREPORT"
        Me.btnCAREPORT.Size = New System.Drawing.Size(85, 23)
        Me.btnCAREPORT.TabIndex = 6
        Me.btnCAREPORT.Tag = "btnCAREPORT"
        Me.btnCAREPORT.Text = "btnCAREPORT"
        Me.btnCAREPORT.UseVisualStyleBackColor = True
        '
        'btnTRFBUY
        '
        Me.btnTRFBUY.Enabled = False
        Me.btnTRFBUY.Location = New System.Drawing.Point(468, 20)
        Me.btnTRFBUY.Name = "btnTRFBUY"
        Me.btnTRFBUY.Size = New System.Drawing.Size(85, 23)
        Me.btnTRFBUY.TabIndex = 5
        Me.btnTRFBUY.Tag = "btnTRFBUY"
        Me.btnTRFBUY.Text = "btnTRFBUY"
        Me.btnTRFBUY.UseVisualStyleBackColor = True
        '
        'btnODADV
        '
        Me.btnODADV.Enabled = False
        Me.btnODADV.Location = New System.Drawing.Point(377, 20)
        Me.btnODADV.Name = "btnODADV"
        Me.btnODADV.Size = New System.Drawing.Size(85, 23)
        Me.btnODADV.TabIndex = 4
        Me.btnODADV.Tag = "btnODADV"
        Me.btnODADV.Text = "btnODADV"
        Me.btnODADV.UseVisualStyleBackColor = True
        '
        'btnAFREPORT
        '
        Me.btnAFREPORT.Enabled = False
        Me.btnAFREPORT.Location = New System.Drawing.Point(285, 20)
        Me.btnAFREPORT.Name = "btnAFREPORT"
        Me.btnAFREPORT.Size = New System.Drawing.Size(85, 23)
        Me.btnAFREPORT.TabIndex = 3
        Me.btnAFREPORT.Tag = "btnAFREPORT"
        Me.btnAFREPORT.Text = "btnAFREPORT"
        Me.btnAFREPORT.UseVisualStyleBackColor = True
        '
        'btnCIREPORT
        '
        Me.btnCIREPORT.Enabled = False
        Me.btnCIREPORT.Location = New System.Drawing.Point(193, 20)
        Me.btnCIREPORT.Name = "btnCIREPORT"
        Me.btnCIREPORT.Size = New System.Drawing.Size(85, 23)
        Me.btnCIREPORT.TabIndex = 2
        Me.btnCIREPORT.Tag = "btnCIREPORT"
        Me.btnCIREPORT.Text = "btnCIREPORT"
        Me.btnCIREPORT.UseVisualStyleBackColor = True
        '
        'btnSEREPORT
        '
        Me.btnSEREPORT.Enabled = False
        Me.btnSEREPORT.Location = New System.Drawing.Point(101, 20)
        Me.btnSEREPORT.Name = "btnSEREPORT"
        Me.btnSEREPORT.Size = New System.Drawing.Size(85, 23)
        Me.btnSEREPORT.TabIndex = 1
        Me.btnSEREPORT.Tag = "btnSEREPORT"
        Me.btnSEREPORT.Text = "btnSEREPORT"
        Me.btnSEREPORT.UseVisualStyleBackColor = True
        '
        'btnODHISTORY
        '
        Me.btnODHISTORY.Enabled = False
        Me.btnODHISTORY.Location = New System.Drawing.Point(9, 20)
        Me.btnODHISTORY.Name = "btnODHISTORY"
        Me.btnODHISTORY.Size = New System.Drawing.Size(85, 23)
        Me.btnODHISTORY.TabIndex = 0
        Me.btnODHISTORY.Tag = "btnODHISTORY"
        Me.btnODHISTORY.Text = "btnODHISTORY"
        Me.btnODHISTORY.UseVisualStyleBackColor = True
        '
        'lblBankInfo
        '
        Me.lblBankInfo.AutoSize = True
        Me.lblBankInfo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBankInfo.Location = New System.Drawing.Point(6, 54)
        Me.lblBankInfo.Name = "lblBankInfo"
        Me.lblBankInfo.Size = New System.Drawing.Size(71, 13)
        Me.lblBankInfo.TabIndex = 4
        Me.lblBankInfo.Tag = "lblBankInfo"
        Me.lblBankInfo.Text = "lblBankInfo"
        '
        'frmBrokerInquiry
        '
        Me.ClientSize = New System.Drawing.Size(937, 606)
        Me.Controls.Add(Me.grbSE)
        Me.Controls.Add(Me.grbCF)
        Me.Controls.Add(Me.grbAF)
        Me.Controls.Add(Me.grbReports)
        Me.Controls.Add(Me.grbPPSE)
        Me.MaximizeBox = True
        Me.Name = "frmBrokerInquiry"
        Me.Controls.SetChildIndex(Me.grbPPSE, 0)
        Me.Controls.SetChildIndex(Me.grbReports, 0)
        Me.Controls.SetChildIndex(Me.grbAF, 0)
        Me.Controls.SetChildIndex(Me.grbCF, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.grbSE, 0)
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.btnApply, 0)
        Me.Controls.SetChildIndex(Me.btnApprv, 0)
        Me.Controls.SetChildIndex(Me.cboLink, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.grbAF.ResumeLayout(False)
        Me.grbAF.PerformLayout()
        Me.grbCF.ResumeLayout(False)
        Me.grbCF.PerformLayout()
        Me.grbPPSE.ResumeLayout(False)
        Me.grbPPSE.PerformLayout()
        Me.grbReports.ResumeLayout(False)
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grbAF As System.Windows.Forms.GroupBox
    Friend WithEvents grbCF As System.Windows.Forms.GroupBox
    Friend WithEvents lblAFACCTNO As System.Windows.Forms.Label
    Friend WithEvents lblCUSTODYCD As System.Windows.Forms.Label
    Friend WithEvents cboAFACCTNO As AppCore.ComboBoxEx
    Friend WithEvents txtCUSTODYCD As System.Windows.Forms.TextBox
    Friend WithEvents lblPP0 As System.Windows.Forms.Label
    Friend WithEvents lblBALANCE As System.Windows.Forms.Label
    Friend WithEvents lblNETASSVALUE As System.Windows.Forms.Label
    Friend WithEvents lblTOTALODAMT As System.Windows.Forms.Label
    Friend WithEvents lblMARGINRATE As System.Windows.Forms.Label
    Friend WithEvents lblTOTALSEAMT As System.Windows.Forms.Label
    Friend WithEvents lblPPSE As System.Windows.Forms.Label
    Friend WithEvents txtPPSE As System.Windows.Forms.TextBox
    Friend WithEvents lblPRICE As System.Windows.Forms.Label
    Friend WithEvents txtPRICE As System.Windows.Forms.TextBox
    Friend WithEvents lblSYMBOL As System.Windows.Forms.Label
    Friend WithEvents txtSYMBOL As System.Windows.Forms.TextBox
    Friend WithEvents grbPPSE As System.Windows.Forms.GroupBox
    Friend WithEvents grbSE As System.Windows.Forms.GroupBox
    Friend WithEvents lblMARGINRATE_74 As System.Windows.Forms.Label
    Friend WithEvents grbReports As System.Windows.Forms.GroupBox
    Friend WithEvents btnLNREPORT As System.Windows.Forms.Button
    Friend WithEvents btnAFCALL As System.Windows.Forms.Button
    Friend WithEvents btnCAREPORT As System.Windows.Forms.Button
    Friend WithEvents btnTRFBUY As System.Windows.Forms.Button
    Friend WithEvents btnODADV As System.Windows.Forms.Button
    Friend WithEvents btnAFREPORT As System.Windows.Forms.Button
    Friend WithEvents btnCIREPORT As System.Windows.Forms.Button
    Friend WithEvents btnSEREPORT As System.Windows.Forms.Button
    Friend WithEvents btnODHISTORY As System.Windows.Forms.Button
    Friend WithEvents DataTable1 As System.Data.DataTable
    Friend WithEvents btnMRCALL As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lblBALANCEV As System.Windows.Forms.Label
    Friend WithEvents lblMARGINRATEV As System.Windows.Forms.Label
    Friend WithEvents lblMARGINRATE_74V As System.Windows.Forms.Label
    Friend WithEvents lblPP0V As System.Windows.Forms.Label
    Friend WithEvents lblNETASSVALUEV As System.Windows.Forms.Label
    Friend WithEvents lblTOTALSEAMTV As System.Windows.Forms.Label
    Friend WithEvents lblTOTALODAMTV As System.Windows.Forms.Label
    Friend WithEvents lblSESECUREDV As System.Windows.Forms.Label
    Friend WithEvents lblACCOUNTVALUEV As System.Windows.Forms.Label
    Friend WithEvents lblSESECURED As System.Windows.Forms.Label
    Friend WithEvents lblACCOUNTVALUE As System.Windows.Forms.Label
    Friend WithEvents lblMRCRLIMITMAX As System.Windows.Forms.Label
    Friend WithEvents txtMRCRLIMITMAX As System.Windows.Forms.TextBox
    Friend WithEvents lblADVANCELINE As System.Windows.Forms.Label
    Friend WithEvents txtADVANCELINE As System.Windows.Forms.TextBox
    Friend WithEvents lblAVLLIMIT As System.Windows.Forms.Label
    Friend WithEvents txtAVLLIMIT As System.Windows.Forms.TextBox
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents lblBankInfo As System.Windows.Forms.Label

End Class
