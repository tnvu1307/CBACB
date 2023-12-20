<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManualAdvance
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmManualAdvance))
        Me.grbCFInfo = New System.Windows.Forms.GroupBox
        Me.lblBALDEFOVD = New System.Windows.Forms.Label
        Me.txtBALDEFOVD = New System.Windows.Forms.TextBox
        Me.lblBANKCODE = New System.Windows.Forms.Label
        Me.txtBANKCODE = New System.Windows.Forms.TextBox
        Me.lblBANKACCT = New System.Windows.Forms.Label
        Me.txtBANKACCT = New System.Windows.Forms.TextBox
        Me.lblIDDATE = New System.Windows.Forms.Label
        Me.txtIDDATE = New System.Windows.Forms.TextBox
        Me.lblIDPLACE = New System.Windows.Forms.Label
        Me.txtIDPLACE = New System.Windows.Forms.TextBox
        Me.lblIDCODE = New System.Windows.Forms.Label
        Me.txtIDCODE = New System.Windows.Forms.TextBox
        Me.lblADDRESS = New System.Windows.Forms.Label
        Me.txtADDRESS = New System.Windows.Forms.TextBox
        Me.lblFULLNAME = New System.Windows.Forms.Label
        Me.txtFULLNAME = New System.Windows.Forms.TextBox
        Me.cboAFACCTNO = New AppCore.ComboBoxEx
        Me.lblCUSTODYCD = New System.Windows.Forms.Label
        Me.txtCUSTODYCD = New System.Windows.Forms.TextBox
        Me.grbAdvInfo = New System.Windows.Forms.GroupBox
        Me.lblREMAINADV_SYS = New System.Windows.Forms.Label
        Me.txtREMAINADV_SYS = New System.Windows.Forms.TextBox
        Me.lblREMAINADV = New System.Windows.Forms.Label
        Me.txtREMAINADV = New System.Windows.Forms.TextBox
        Me.lblVAT = New System.Windows.Forms.Label
        Me.txtVAT = New System.Windows.Forms.TextBox
        Me.lblBNKMINBAL = New System.Windows.Forms.Label
        Me.txtBNKMINBAL = New System.Windows.Forms.TextBox
        Me.lblCMPMAXBAL = New System.Windows.Forms.Label
        Me.txtCMPMAXBAL = New System.Windows.Forms.TextBox
        Me.lblCMPMINBAL = New System.Windows.Forms.Label
        Me.txtCMPMINBAL = New System.Windows.Forms.TextBox
        Me.lblBNKRATE = New System.Windows.Forms.Label
        Me.txtBNKRATE = New System.Windows.Forms.TextBox
        Me.lblINTRATE = New System.Windows.Forms.Label
        Me.txtINTRATE = New System.Windows.Forms.TextBox
        Me.lblMINADVAMT = New System.Windows.Forms.Label
        Me.txtMINADVAMT = New System.Windows.Forms.TextBox
        Me.lblADTYPE = New System.Windows.Forms.Label
        Me.cboADTYPE = New AppCore.ComboBoxEx
        Me.lblRCVADVAMT = New System.Windows.Forms.Label
        Me.txtRCVADVAMT = New System.Windows.Forms.TextBox
        Me.lblADVAMT = New System.Windows.Forms.Label
        Me.txtADVAMT = New System.Windows.Forms.TextBox
        Me.lblAVLADVAMT = New System.Windows.Forms.Label
        Me.txtAVLADVAMT = New System.Windows.Forms.TextBox
        Me.grbAdvSchd = New System.Windows.Forms.GroupBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnApply = New System.Windows.Forms.Button
        Me.btnAdjust = New System.Windows.Forms.Button
        Me.txtACTYPE = New System.Windows.Forms.TextBox
        Me.txtCOREBANK = New System.Windows.Forms.TextBox
        Me.btnPRINT = New System.Windows.Forms.Button
        Me.grbCFInfo.SuspendLayout()
        Me.grbAdvInfo.SuspendLayout()
        Me.grbAdvSchd.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbCFInfo
        '
        Me.grbCFInfo.Controls.Add(Me.lblBALDEFOVD)
        Me.grbCFInfo.Controls.Add(Me.txtBALDEFOVD)
        Me.grbCFInfo.Controls.Add(Me.lblBANKCODE)
        Me.grbCFInfo.Controls.Add(Me.txtBANKCODE)
        Me.grbCFInfo.Controls.Add(Me.lblBANKACCT)
        Me.grbCFInfo.Controls.Add(Me.txtBANKACCT)
        Me.grbCFInfo.Controls.Add(Me.lblIDDATE)
        Me.grbCFInfo.Controls.Add(Me.txtIDDATE)
        Me.grbCFInfo.Controls.Add(Me.lblIDPLACE)
        Me.grbCFInfo.Controls.Add(Me.txtIDPLACE)
        Me.grbCFInfo.Controls.Add(Me.lblIDCODE)
        Me.grbCFInfo.Controls.Add(Me.txtIDCODE)
        Me.grbCFInfo.Controls.Add(Me.lblADDRESS)
        Me.grbCFInfo.Controls.Add(Me.txtADDRESS)
        Me.grbCFInfo.Controls.Add(Me.lblFULLNAME)
        Me.grbCFInfo.Controls.Add(Me.txtFULLNAME)
        Me.grbCFInfo.Controls.Add(Me.cboAFACCTNO)
        Me.grbCFInfo.Controls.Add(Me.lblCUSTODYCD)
        Me.grbCFInfo.Controls.Add(Me.txtCUSTODYCD)
        Me.grbCFInfo.Location = New System.Drawing.Point(3, 2)
        Me.grbCFInfo.Name = "grbCFInfo"
        Me.grbCFInfo.Size = New System.Drawing.Size(704, 148)
        Me.grbCFInfo.TabIndex = 0
        Me.grbCFInfo.TabStop = False
        Me.grbCFInfo.Tag = "grbCFInfo"
        Me.grbCFInfo.Text = "grbCFInfo"
        '
        'lblBALDEFOVD
        '
        Me.lblBALDEFOVD.AutoSize = True
        Me.lblBALDEFOVD.Location = New System.Drawing.Point(480, 124)
        Me.lblBALDEFOVD.Name = "lblBALDEFOVD"
        Me.lblBALDEFOVD.Size = New System.Drawing.Size(81, 13)
        Me.lblBALDEFOVD.TabIndex = 20
        Me.lblBALDEFOVD.Tag = "lblBALDEFOVD"
        Me.lblBALDEFOVD.Text = "lblBALDEFOVD"
        '
        'txtBALDEFOVD
        '
        Me.txtBALDEFOVD.Location = New System.Drawing.Point(583, 121)
        Me.txtBALDEFOVD.Name = "txtBALDEFOVD"
        Me.txtBALDEFOVD.ReadOnly = True
        Me.txtBALDEFOVD.Size = New System.Drawing.Size(115, 20)
        Me.txtBALDEFOVD.TabIndex = 19
        Me.txtBALDEFOVD.Tag = "txtBALDEFOVD"
        Me.txtBALDEFOVD.Text = "0"
        '
        'lblBANKCODE
        '
        Me.lblBANKCODE.AutoSize = True
        Me.lblBANKCODE.Location = New System.Drawing.Point(281, 124)
        Me.lblBANKCODE.Name = "lblBANKCODE"
        Me.lblBANKCODE.Size = New System.Drawing.Size(76, 13)
        Me.lblBANKCODE.TabIndex = 18
        Me.lblBANKCODE.Tag = "lblBANKCODE"
        Me.lblBANKCODE.Text = "lblBANKCODE"
        '
        'txtBANKCODE
        '
        Me.txtBANKCODE.Location = New System.Drawing.Point(364, 121)
        Me.txtBANKCODE.Name = "txtBANKCODE"
        Me.txtBANKCODE.ReadOnly = True
        Me.txtBANKCODE.Size = New System.Drawing.Size(100, 20)
        Me.txtBANKCODE.TabIndex = 17
        Me.txtBANKCODE.Tag = "txtBANKCODE"
        '
        'lblBANKACCT
        '
        Me.lblBANKACCT.AutoSize = True
        Me.lblBANKACCT.Location = New System.Drawing.Point(9, 124)
        Me.lblBANKACCT.Name = "lblBANKACCT"
        Me.lblBANKACCT.Size = New System.Drawing.Size(74, 13)
        Me.lblBANKACCT.TabIndex = 16
        Me.lblBANKACCT.Tag = "lblBANKACCT"
        Me.lblBANKACCT.Text = "lblBANKACCT"
        '
        'txtBANKACCT
        '
        Me.txtBANKACCT.Location = New System.Drawing.Point(128, 121)
        Me.txtBANKACCT.Name = "txtBANKACCT"
        Me.txtBANKACCT.ReadOnly = True
        Me.txtBANKACCT.Size = New System.Drawing.Size(139, 20)
        Me.txtBANKACCT.TabIndex = 15
        Me.txtBANKACCT.Tag = "txtBANKACCT"
        '
        'lblIDDATE
        '
        Me.lblIDDATE.AutoSize = True
        Me.lblIDDATE.Location = New System.Drawing.Point(529, 98)
        Me.lblIDDATE.Name = "lblIDDATE"
        Me.lblIDDATE.Size = New System.Drawing.Size(57, 13)
        Me.lblIDDATE.TabIndex = 12
        Me.lblIDDATE.Tag = "lblIDDATE"
        Me.lblIDDATE.Text = "lblIDDATE"
        '
        'txtIDDATE
        '
        Me.txtIDDATE.Location = New System.Drawing.Point(615, 95)
        Me.txtIDDATE.Name = "txtIDDATE"
        Me.txtIDDATE.ReadOnly = True
        Me.txtIDDATE.Size = New System.Drawing.Size(83, 20)
        Me.txtIDDATE.TabIndex = 11
        Me.txtIDDATE.Tag = "txtIDDATE"
        '
        'lblIDPLACE
        '
        Me.lblIDPLACE.AutoSize = True
        Me.lblIDPLACE.Location = New System.Drawing.Point(234, 98)
        Me.lblIDPLACE.Name = "lblIDPLACE"
        Me.lblIDPLACE.Size = New System.Drawing.Size(62, 13)
        Me.lblIDPLACE.TabIndex = 10
        Me.lblIDPLACE.Tag = "lblIDPLACE"
        Me.lblIDPLACE.Text = "lblIDPLACE"
        '
        'txtIDPLACE
        '
        Me.txtIDPLACE.Location = New System.Drawing.Point(333, 95)
        Me.txtIDPLACE.Name = "txtIDPLACE"
        Me.txtIDPLACE.ReadOnly = True
        Me.txtIDPLACE.Size = New System.Drawing.Size(190, 20)
        Me.txtIDPLACE.TabIndex = 9
        Me.txtIDPLACE.Tag = "txtIDPLACE"
        '
        'lblIDCODE
        '
        Me.lblIDCODE.AutoSize = True
        Me.lblIDCODE.Location = New System.Drawing.Point(9, 98)
        Me.lblIDCODE.Name = "lblIDCODE"
        Me.lblIDCODE.Size = New System.Drawing.Size(58, 13)
        Me.lblIDCODE.TabIndex = 8
        Me.lblIDCODE.Tag = "lblIDCODE"
        Me.lblIDCODE.Text = "lblIDCODE"
        '
        'txtIDCODE
        '
        Me.txtIDCODE.Location = New System.Drawing.Point(128, 95)
        Me.txtIDCODE.Name = "txtIDCODE"
        Me.txtIDCODE.ReadOnly = True
        Me.txtIDCODE.Size = New System.Drawing.Size(100, 20)
        Me.txtIDCODE.TabIndex = 7
        Me.txtIDCODE.Tag = "txtIDCODE"
        '
        'lblADDRESS
        '
        Me.lblADDRESS.AutoSize = True
        Me.lblADDRESS.Location = New System.Drawing.Point(9, 72)
        Me.lblADDRESS.Name = "lblADDRESS"
        Me.lblADDRESS.Size = New System.Drawing.Size(69, 13)
        Me.lblADDRESS.TabIndex = 6
        Me.lblADDRESS.Tag = "lblADDRESS"
        Me.lblADDRESS.Text = "lblADDRESS"
        '
        'txtADDRESS
        '
        Me.txtADDRESS.Location = New System.Drawing.Point(128, 69)
        Me.txtADDRESS.Name = "txtADDRESS"
        Me.txtADDRESS.ReadOnly = True
        Me.txtADDRESS.Size = New System.Drawing.Size(570, 20)
        Me.txtADDRESS.TabIndex = 5
        Me.txtADDRESS.Tag = "txtADDRESS"
        '
        'lblFULLNAME
        '
        Me.lblFULLNAME.AutoSize = True
        Me.lblFULLNAME.Location = New System.Drawing.Point(9, 46)
        Me.lblFULLNAME.Name = "lblFULLNAME"
        Me.lblFULLNAME.Size = New System.Drawing.Size(74, 13)
        Me.lblFULLNAME.TabIndex = 4
        Me.lblFULLNAME.Tag = "lblFULLNAME"
        Me.lblFULLNAME.Text = "lblFULLNAME"
        '
        'txtFULLNAME
        '
        Me.txtFULLNAME.Location = New System.Drawing.Point(128, 43)
        Me.txtFULLNAME.Name = "txtFULLNAME"
        Me.txtFULLNAME.ReadOnly = True
        Me.txtFULLNAME.Size = New System.Drawing.Size(570, 20)
        Me.txtFULLNAME.TabIndex = 3
        Me.txtFULLNAME.Tag = "txtFULLNAME"
        '
        'cboAFACCTNO
        '
        Me.cboAFACCTNO.DisplayMember = "DISPLAY"
        Me.cboAFACCTNO.FormattingEnabled = True
        Me.cboAFACCTNO.Location = New System.Drawing.Point(234, 16)
        Me.cboAFACCTNO.Name = "cboAFACCTNO"
        Me.cboAFACCTNO.Size = New System.Drawing.Size(464, 21)
        Me.cboAFACCTNO.TabIndex = 2
        Me.cboAFACCTNO.Tag = "cboAFACCTNO"
        Me.cboAFACCTNO.ValueMember = "VALUE"
        '
        'lblCUSTODYCD
        '
        Me.lblCUSTODYCD.AutoSize = True
        Me.lblCUSTODYCD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCUSTODYCD.Location = New System.Drawing.Point(9, 19)
        Me.lblCUSTODYCD.Name = "lblCUSTODYCD"
        Me.lblCUSTODYCD.Size = New System.Drawing.Size(96, 13)
        Me.lblCUSTODYCD.TabIndex = 1
        Me.lblCUSTODYCD.Tag = "lblCUSTODYCD"
        Me.lblCUSTODYCD.Text = "lblCUSTODYCD"
        '
        'txtCUSTODYCD
        '
        Me.txtCUSTODYCD.BackColor = System.Drawing.Color.Lime
        Me.txtCUSTODYCD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCUSTODYCD.Location = New System.Drawing.Point(128, 16)
        Me.txtCUSTODYCD.MaxLength = 10
        Me.txtCUSTODYCD.Name = "txtCUSTODYCD"
        Me.txtCUSTODYCD.Size = New System.Drawing.Size(100, 20)
        Me.txtCUSTODYCD.TabIndex = 0
        Me.txtCUSTODYCD.Tag = "txtCUSTODYCD"
        Me.txtCUSTODYCD.Text = "txtCUSTODYCD"
        '
        'grbAdvInfo
        '
        Me.grbAdvInfo.Controls.Add(Me.lblREMAINADV_SYS)
        Me.grbAdvInfo.Controls.Add(Me.txtREMAINADV_SYS)
        Me.grbAdvInfo.Controls.Add(Me.lblREMAINADV)
        Me.grbAdvInfo.Controls.Add(Me.txtREMAINADV)
        Me.grbAdvInfo.Controls.Add(Me.lblVAT)
        Me.grbAdvInfo.Controls.Add(Me.txtVAT)
        Me.grbAdvInfo.Controls.Add(Me.lblBNKMINBAL)
        Me.grbAdvInfo.Controls.Add(Me.txtBNKMINBAL)
        Me.grbAdvInfo.Controls.Add(Me.lblCMPMAXBAL)
        Me.grbAdvInfo.Controls.Add(Me.txtCMPMAXBAL)
        Me.grbAdvInfo.Controls.Add(Me.lblCMPMINBAL)
        Me.grbAdvInfo.Controls.Add(Me.txtCMPMINBAL)
        Me.grbAdvInfo.Controls.Add(Me.lblBNKRATE)
        Me.grbAdvInfo.Controls.Add(Me.txtBNKRATE)
        Me.grbAdvInfo.Controls.Add(Me.lblINTRATE)
        Me.grbAdvInfo.Controls.Add(Me.txtINTRATE)
        Me.grbAdvInfo.Controls.Add(Me.lblMINADVAMT)
        Me.grbAdvInfo.Controls.Add(Me.txtMINADVAMT)
        Me.grbAdvInfo.Controls.Add(Me.lblADTYPE)
        Me.grbAdvInfo.Controls.Add(Me.cboADTYPE)
        Me.grbAdvInfo.Controls.Add(Me.lblRCVADVAMT)
        Me.grbAdvInfo.Controls.Add(Me.txtRCVADVAMT)
        Me.grbAdvInfo.Controls.Add(Me.lblADVAMT)
        Me.grbAdvInfo.Controls.Add(Me.txtADVAMT)
        Me.grbAdvInfo.Controls.Add(Me.lblAVLADVAMT)
        Me.grbAdvInfo.Controls.Add(Me.txtAVLADVAMT)
        Me.grbAdvInfo.Location = New System.Drawing.Point(3, 156)
        Me.grbAdvInfo.Name = "grbAdvInfo"
        Me.grbAdvInfo.Size = New System.Drawing.Size(704, 149)
        Me.grbAdvInfo.TabIndex = 1
        Me.grbAdvInfo.TabStop = False
        Me.grbAdvInfo.Tag = "grbAdvInfo"
        Me.grbAdvInfo.Text = "grbAdvInfo"
        '
        'lblREMAINADV_SYS
        '
        Me.lblREMAINADV_SYS.AutoSize = True
        Me.lblREMAINADV_SYS.Location = New System.Drawing.Point(374, 124)
        Me.lblREMAINADV_SYS.Name = "lblREMAINADV_SYS"
        Me.lblREMAINADV_SYS.Size = New System.Drawing.Size(108, 13)
        Me.lblREMAINADV_SYS.TabIndex = 32
        Me.lblREMAINADV_SYS.Tag = "lblREMAINADV_SYS"
        Me.lblREMAINADV_SYS.Text = "lblREMAINADV_SYS"
        '
        'txtREMAINADV_SYS
        '
        Me.txtREMAINADV_SYS.Location = New System.Drawing.Point(560, 121)
        Me.txtREMAINADV_SYS.Name = "txtREMAINADV_SYS"
        Me.txtREMAINADV_SYS.ReadOnly = True
        Me.txtREMAINADV_SYS.Size = New System.Drawing.Size(138, 20)
        Me.txtREMAINADV_SYS.TabIndex = 31
        Me.txtREMAINADV_SYS.Tag = "txtREMAINADV_SYS"
        Me.txtREMAINADV_SYS.Text = "0"
        Me.txtREMAINADV_SYS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblREMAINADV
        '
        Me.lblREMAINADV.AutoSize = True
        Me.lblREMAINADV.Location = New System.Drawing.Point(9, 124)
        Me.lblREMAINADV.Name = "lblREMAINADV"
        Me.lblREMAINADV.Size = New System.Drawing.Size(81, 13)
        Me.lblREMAINADV.TabIndex = 30
        Me.lblREMAINADV.Tag = "lblREMAINADV"
        Me.lblREMAINADV.Text = "lblREMAINADV"
        '
        'txtREMAINADV
        '
        Me.txtREMAINADV.Location = New System.Drawing.Point(191, 121)
        Me.txtREMAINADV.Name = "txtREMAINADV"
        Me.txtREMAINADV.ReadOnly = True
        Me.txtREMAINADV.Size = New System.Drawing.Size(138, 20)
        Me.txtREMAINADV.TabIndex = 29
        Me.txtREMAINADV.Tag = "txtREMAINADV"
        Me.txtREMAINADV.Text = "0"
        Me.txtREMAINADV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblVAT
        '
        Me.lblVAT.AutoSize = True
        Me.lblVAT.Location = New System.Drawing.Point(470, 46)
        Me.lblVAT.Name = "lblVAT"
        Me.lblVAT.Size = New System.Drawing.Size(38, 13)
        Me.lblVAT.TabIndex = 28
        Me.lblVAT.Tag = "lblVAT"
        Me.lblVAT.Text = "lblVAT"
        '
        'txtVAT
        '
        Me.txtVAT.Location = New System.Drawing.Point(598, 43)
        Me.txtVAT.Name = "txtVAT"
        Me.txtVAT.ReadOnly = True
        Me.txtVAT.Size = New System.Drawing.Size(100, 20)
        Me.txtVAT.TabIndex = 27
        Me.txtVAT.Tag = "txtVAT"
        Me.txtVAT.Text = "0"
        Me.txtVAT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblBNKMINBAL
        '
        Me.lblBNKMINBAL.AutoSize = True
        Me.lblBNKMINBAL.Location = New System.Drawing.Point(470, 98)
        Me.lblBNKMINBAL.Name = "lblBNKMINBAL"
        Me.lblBNKMINBAL.Size = New System.Drawing.Size(79, 13)
        Me.lblBNKMINBAL.TabIndex = 26
        Me.lblBNKMINBAL.Tag = "lblBNKMINBAL"
        Me.lblBNKMINBAL.Text = "lblBNKMINBAL"
        '
        'txtBNKMINBAL
        '
        Me.txtBNKMINBAL.Location = New System.Drawing.Point(598, 95)
        Me.txtBNKMINBAL.Name = "txtBNKMINBAL"
        Me.txtBNKMINBAL.ReadOnly = True
        Me.txtBNKMINBAL.Size = New System.Drawing.Size(100, 20)
        Me.txtBNKMINBAL.TabIndex = 25
        Me.txtBNKMINBAL.Tag = "txtBNKMINBAL"
        Me.txtBNKMINBAL.Text = "0"
        Me.txtBNKMINBAL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCMPMAXBAL
        '
        Me.lblCMPMAXBAL.AutoSize = True
        Me.lblCMPMAXBAL.Location = New System.Drawing.Point(235, 98)
        Me.lblCMPMAXBAL.Name = "lblCMPMAXBAL"
        Me.lblCMPMAXBAL.Size = New System.Drawing.Size(83, 13)
        Me.lblCMPMAXBAL.TabIndex = 24
        Me.lblCMPMAXBAL.Tag = "lblCMPMAXBAL"
        Me.lblCMPMAXBAL.Text = "lblCMPMAXBAL"
        '
        'txtCMPMAXBAL
        '
        Me.txtCMPMAXBAL.Location = New System.Drawing.Point(364, 95)
        Me.txtCMPMAXBAL.Name = "txtCMPMAXBAL"
        Me.txtCMPMAXBAL.ReadOnly = True
        Me.txtCMPMAXBAL.Size = New System.Drawing.Size(100, 20)
        Me.txtCMPMAXBAL.TabIndex = 23
        Me.txtCMPMAXBAL.Tag = "txtCMPMAXBAL"
        Me.txtCMPMAXBAL.Text = "0"
        Me.txtCMPMAXBAL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCMPMINBAL
        '
        Me.lblCMPMINBAL.AutoSize = True
        Me.lblCMPMINBAL.Location = New System.Drawing.Point(9, 98)
        Me.lblCMPMINBAL.Name = "lblCMPMINBAL"
        Me.lblCMPMINBAL.Size = New System.Drawing.Size(80, 13)
        Me.lblCMPMINBAL.TabIndex = 22
        Me.lblCMPMINBAL.Tag = "lblCMPMINBAL"
        Me.lblCMPMINBAL.Text = "lblCMPMINBAL"
        '
        'txtCMPMINBAL
        '
        Me.txtCMPMINBAL.Location = New System.Drawing.Point(128, 95)
        Me.txtCMPMINBAL.Name = "txtCMPMINBAL"
        Me.txtCMPMINBAL.ReadOnly = True
        Me.txtCMPMINBAL.Size = New System.Drawing.Size(100, 20)
        Me.txtCMPMINBAL.TabIndex = 21
        Me.txtCMPMINBAL.Tag = "txtCMPMINBAL"
        Me.txtCMPMINBAL.Text = "0"
        Me.txtCMPMINBAL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblBNKRATE
        '
        Me.lblBNKRATE.AutoSize = True
        Me.lblBNKRATE.Location = New System.Drawing.Point(470, 72)
        Me.lblBNKRATE.Name = "lblBNKRATE"
        Me.lblBNKRATE.Size = New System.Drawing.Size(68, 13)
        Me.lblBNKRATE.TabIndex = 20
        Me.lblBNKRATE.Tag = "lblBNKRATE"
        Me.lblBNKRATE.Text = "lblBNKRATE"
        '
        'txtBNKRATE
        '
        Me.txtBNKRATE.Location = New System.Drawing.Point(598, 69)
        Me.txtBNKRATE.Name = "txtBNKRATE"
        Me.txtBNKRATE.ReadOnly = True
        Me.txtBNKRATE.Size = New System.Drawing.Size(100, 20)
        Me.txtBNKRATE.TabIndex = 19
        Me.txtBNKRATE.Tag = "txtBNKRATE"
        Me.txtBNKRATE.Text = "0"
        Me.txtBNKRATE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblINTRATE
        '
        Me.lblINTRATE.AutoSize = True
        Me.lblINTRATE.Location = New System.Drawing.Point(235, 72)
        Me.lblINTRATE.Name = "lblINTRATE"
        Me.lblINTRATE.Size = New System.Drawing.Size(64, 13)
        Me.lblINTRATE.TabIndex = 18
        Me.lblINTRATE.Tag = "lblINTRATE"
        Me.lblINTRATE.Text = "lblINTRATE"
        '
        'txtINTRATE
        '
        Me.txtINTRATE.Location = New System.Drawing.Point(364, 69)
        Me.txtINTRATE.Name = "txtINTRATE"
        Me.txtINTRATE.ReadOnly = True
        Me.txtINTRATE.Size = New System.Drawing.Size(100, 20)
        Me.txtINTRATE.TabIndex = 17
        Me.txtINTRATE.Tag = "txtINTRATE"
        Me.txtINTRATE.Text = "0"
        Me.txtINTRATE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblMINADVAMT
        '
        Me.lblMINADVAMT.AutoSize = True
        Me.lblMINADVAMT.Location = New System.Drawing.Point(9, 72)
        Me.lblMINADVAMT.Name = "lblMINADVAMT"
        Me.lblMINADVAMT.Size = New System.Drawing.Size(82, 13)
        Me.lblMINADVAMT.TabIndex = 16
        Me.lblMINADVAMT.Tag = "lblMINADVAMT"
        Me.lblMINADVAMT.Text = "lblMINADVAMT"
        '
        'txtMINADVAMT
        '
        Me.txtMINADVAMT.Location = New System.Drawing.Point(128, 69)
        Me.txtMINADVAMT.Name = "txtMINADVAMT"
        Me.txtMINADVAMT.ReadOnly = True
        Me.txtMINADVAMT.Size = New System.Drawing.Size(100, 20)
        Me.txtMINADVAMT.TabIndex = 15
        Me.txtMINADVAMT.Tag = "txtMINADVAMT"
        Me.txtMINADVAMT.Text = "0"
        Me.txtMINADVAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblADTYPE
        '
        Me.lblADTYPE.AutoSize = True
        Me.lblADTYPE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblADTYPE.Location = New System.Drawing.Point(9, 45)
        Me.lblADTYPE.Name = "lblADTYPE"
        Me.lblADTYPE.Size = New System.Drawing.Size(69, 13)
        Me.lblADTYPE.TabIndex = 14
        Me.lblADTYPE.Tag = "lblADTYPE"
        Me.lblADTYPE.Text = "lblADTYPE"
        '
        'cboADTYPE
        '
        Me.cboADTYPE.DisplayMember = "DISPLAY"
        Me.cboADTYPE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboADTYPE.FormattingEnabled = True
        Me.cboADTYPE.Location = New System.Drawing.Point(128, 42)
        Me.cboADTYPE.Name = "cboADTYPE"
        Me.cboADTYPE.Size = New System.Drawing.Size(336, 21)
        Me.cboADTYPE.TabIndex = 13
        Me.cboADTYPE.Tag = "cboADTYPE"
        Me.cboADTYPE.ValueMember = "VALUE"
        '
        'lblRCVADVAMT
        '
        Me.lblRCVADVAMT.AutoSize = True
        Me.lblRCVADVAMT.Location = New System.Drawing.Point(234, 18)
        Me.lblRCVADVAMT.Name = "lblRCVADVAMT"
        Me.lblRCVADVAMT.Size = New System.Drawing.Size(84, 13)
        Me.lblRCVADVAMT.TabIndex = 9
        Me.lblRCVADVAMT.Tag = "lblRCVADVAMT"
        Me.lblRCVADVAMT.Text = "lblRCVADVAMT"
        '
        'txtRCVADVAMT
        '
        Me.txtRCVADVAMT.Location = New System.Drawing.Point(364, 16)
        Me.txtRCVADVAMT.Name = "txtRCVADVAMT"
        Me.txtRCVADVAMT.ReadOnly = True
        Me.txtRCVADVAMT.Size = New System.Drawing.Size(100, 20)
        Me.txtRCVADVAMT.TabIndex = 6
        Me.txtRCVADVAMT.Tag = "txtRCVADVAMT"
        Me.txtRCVADVAMT.Text = "0"
        Me.txtRCVADVAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblADVAMT
        '
        Me.lblADVAMT.AutoSize = True
        Me.lblADVAMT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblADVAMT.Location = New System.Drawing.Point(470, 19)
        Me.lblADVAMT.Name = "lblADVAMT"
        Me.lblADVAMT.Size = New System.Drawing.Size(71, 13)
        Me.lblADVAMT.TabIndex = 7
        Me.lblADVAMT.Tag = "lblADVAMT"
        Me.lblADVAMT.Text = "lblADVAMT"
        '
        'txtADVAMT
        '
        Me.txtADVAMT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtADVAMT.Location = New System.Drawing.Point(598, 16)
        Me.txtADVAMT.Name = "txtADVAMT"
        Me.txtADVAMT.Size = New System.Drawing.Size(100, 20)
        Me.txtADVAMT.TabIndex = 8
        Me.txtADVAMT.Tag = "txtADVAMT"
        Me.txtADVAMT.Text = "0"
        Me.txtADVAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblAVLADVAMT
        '
        Me.lblAVLADVAMT.AutoSize = True
        Me.lblAVLADVAMT.Location = New System.Drawing.Point(9, 19)
        Me.lblAVLADVAMT.Name = "lblAVLADVAMT"
        Me.lblAVLADVAMT.Size = New System.Drawing.Size(82, 13)
        Me.lblAVLADVAMT.TabIndex = 5
        Me.lblAVLADVAMT.Tag = "lblAVLADVAMT"
        Me.lblAVLADVAMT.Text = "lblAVLADVAMT"
        '
        'txtAVLADVAMT
        '
        Me.txtAVLADVAMT.Location = New System.Drawing.Point(128, 16)
        Me.txtAVLADVAMT.Name = "txtAVLADVAMT"
        Me.txtAVLADVAMT.ReadOnly = True
        Me.txtAVLADVAMT.Size = New System.Drawing.Size(100, 20)
        Me.txtAVLADVAMT.TabIndex = 4
        Me.txtAVLADVAMT.Tag = "txtAVLADVAMT"
        Me.txtAVLADVAMT.Text = "0"
        Me.txtAVLADVAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'grbAdvSchd
        '
        Me.grbAdvSchd.Controls.Add(Me.Panel1)
        Me.grbAdvSchd.Location = New System.Drawing.Point(3, 311)
        Me.grbAdvSchd.Name = "grbAdvSchd"
        Me.grbAdvSchd.Size = New System.Drawing.Size(704, 144)
        Me.grbAdvSchd.TabIndex = 2
        Me.grbAdvSchd.TabStop = False
        Me.grbAdvSchd.Tag = "grbAdvSchd"
        Me.grbAdvSchd.Text = "grbAdvSchd"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Location = New System.Drawing.Point(12, 19)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(682, 119)
        Me.Panel1.TabIndex = 0
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(622, 462)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "btnCancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnApply
        '
        Me.btnApply.Location = New System.Drawing.Point(535, 462)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(75, 23)
        Me.btnApply.TabIndex = 4
        Me.btnApply.Text = "btnApply"
        Me.btnApply.UseVisualStyleBackColor = True
        '
        'btnAdjust
        '
        Me.btnAdjust.Location = New System.Drawing.Point(451, 462)
        Me.btnAdjust.Name = "btnAdjust"
        Me.btnAdjust.Size = New System.Drawing.Size(75, 23)
        Me.btnAdjust.TabIndex = 5
        Me.btnAdjust.Text = "btnAdjust"
        Me.btnAdjust.UseVisualStyleBackColor = True
        '
        'txtACTYPE
        '
        Me.txtACTYPE.Location = New System.Drawing.Point(15, 464)
        Me.txtACTYPE.Name = "txtACTYPE"
        Me.txtACTYPE.ReadOnly = True
        Me.txtACTYPE.Size = New System.Drawing.Size(100, 20)
        Me.txtACTYPE.TabIndex = 8
        Me.txtACTYPE.Tag = "txtACTYPE"
        Me.txtACTYPE.Visible = False
        '
        'txtCOREBANK
        '
        Me.txtCOREBANK.Location = New System.Drawing.Point(121, 465)
        Me.txtCOREBANK.Name = "txtCOREBANK"
        Me.txtCOREBANK.ReadOnly = True
        Me.txtCOREBANK.Size = New System.Drawing.Size(100, 20)
        Me.txtCOREBANK.TabIndex = 13
        Me.txtCOREBANK.Tag = "txtCOREBANK"
        Me.txtCOREBANK.Visible = False
        '
        'btnPRINT
        '
        Me.btnPRINT.Location = New System.Drawing.Point(353, 462)
        Me.btnPRINT.Name = "btnPRINT"
        Me.btnPRINT.Size = New System.Drawing.Size(89, 23)
        Me.btnPRINT.TabIndex = 19
        Me.btnPRINT.Tag = "btnPRINT"
        Me.btnPRINT.Text = "In"
        Me.btnPRINT.UseVisualStyleBackColor = True
        '
        'frmManualAdvance
        '
        Me.AcceptButton = Me.btnApply
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(709, 494)
        Me.Controls.Add(Me.btnPRINT)
        Me.Controls.Add(Me.txtACTYPE)
        Me.Controls.Add(Me.btnAdjust)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.grbAdvSchd)
        Me.Controls.Add(Me.txtCOREBANK)
        Me.Controls.Add(Me.grbAdvInfo)
        Me.Controls.Add(Me.grbCFInfo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmManualAdvance"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmManualAdvance"
        Me.grbCFInfo.ResumeLayout(False)
        Me.grbCFInfo.PerformLayout()
        Me.grbAdvInfo.ResumeLayout(False)
        Me.grbAdvInfo.PerformLayout()
        Me.grbAdvSchd.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grbCFInfo As System.Windows.Forms.GroupBox
    Friend WithEvents grbAdvInfo As System.Windows.Forms.GroupBox
    Friend WithEvents grbAdvSchd As System.Windows.Forms.GroupBox
    Friend WithEvents lblCUSTODYCD As System.Windows.Forms.Label
    Friend WithEvents txtCUSTODYCD As System.Windows.Forms.TextBox
    Friend WithEvents lblADDRESS As System.Windows.Forms.Label
    Friend WithEvents txtADDRESS As System.Windows.Forms.TextBox
    Friend WithEvents lblFULLNAME As System.Windows.Forms.Label
    Friend WithEvents txtFULLNAME As System.Windows.Forms.TextBox
    Friend WithEvents cboAFACCTNO As AppCore.ComboBoxEx
    Friend WithEvents lblIDDATE As System.Windows.Forms.Label
    Friend WithEvents txtIDDATE As System.Windows.Forms.TextBox
    Friend WithEvents lblIDPLACE As System.Windows.Forms.Label
    Friend WithEvents txtIDPLACE As System.Windows.Forms.TextBox
    Friend WithEvents lblIDCODE As System.Windows.Forms.Label
    Friend WithEvents txtIDCODE As System.Windows.Forms.TextBox
    Friend WithEvents lblAVLADVAMT As System.Windows.Forms.Label
    Friend WithEvents txtAVLADVAMT As System.Windows.Forms.TextBox
    Friend WithEvents lblADVAMT As System.Windows.Forms.Label
    Friend WithEvents txtADVAMT As System.Windows.Forms.TextBox
    Friend WithEvents lblRCVADVAMT As System.Windows.Forms.Label
    Friend WithEvents txtRCVADVAMT As System.Windows.Forms.TextBox
    Friend WithEvents lblMINADVAMT As System.Windows.Forms.Label
    Friend WithEvents txtMINADVAMT As System.Windows.Forms.TextBox
    Friend WithEvents lblADTYPE As System.Windows.Forms.Label
    Friend WithEvents cboADTYPE As AppCore.ComboBoxEx
    Friend WithEvents lblBNKMINBAL As System.Windows.Forms.Label
    Friend WithEvents txtBNKMINBAL As System.Windows.Forms.TextBox
    Friend WithEvents lblCMPMAXBAL As System.Windows.Forms.Label
    Friend WithEvents txtCMPMAXBAL As System.Windows.Forms.TextBox
    Friend WithEvents lblCMPMINBAL As System.Windows.Forms.Label
    Friend WithEvents txtCMPMINBAL As System.Windows.Forms.TextBox
    Friend WithEvents lblBNKRATE As System.Windows.Forms.Label
    Friend WithEvents txtBNKRATE As System.Windows.Forms.TextBox
    Friend WithEvents lblINTRATE As System.Windows.Forms.Label
    Friend WithEvents txtINTRATE As System.Windows.Forms.TextBox
    Friend WithEvents lblVAT As System.Windows.Forms.Label
    Friend WithEvents txtVAT As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnApply As System.Windows.Forms.Button
    Friend WithEvents btnAdjust As System.Windows.Forms.Button
    Friend WithEvents txtACTYPE As System.Windows.Forms.TextBox
    Friend WithEvents lblBANKCODE As System.Windows.Forms.Label
    Friend WithEvents txtBANKCODE As System.Windows.Forms.TextBox
    Friend WithEvents lblBANKACCT As System.Windows.Forms.Label
    Friend WithEvents txtBANKACCT As System.Windows.Forms.TextBox
    Friend WithEvents txtCOREBANK As System.Windows.Forms.TextBox
    Friend WithEvents btnPRINT As System.Windows.Forms.Button
    Friend WithEvents lblBALDEFOVD As System.Windows.Forms.Label
    Friend WithEvents txtBALDEFOVD As System.Windows.Forms.TextBox
    Friend WithEvents lblREMAINADV As System.Windows.Forms.Label
    Friend WithEvents txtREMAINADV As System.Windows.Forms.TextBox
    Friend WithEvents lblREMAINADV_SYS As System.Windows.Forms.Label
    Friend WithEvents txtREMAINADV_SYS As System.Windows.Forms.TextBox
End Class
