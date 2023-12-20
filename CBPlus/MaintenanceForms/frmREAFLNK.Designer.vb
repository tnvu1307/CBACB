<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmREAFLNK
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmREAFLNK))
        Me.tbcREAFLNK = New System.Windows.Forms.TabControl
        Me.tpREAFLNK = New System.Windows.Forms.TabPage
        Me.pnlREAFLNK = New System.Windows.Forms.Panel
        Me.txtDAYSFUTURE = New System.Windows.Forms.TextBox
        Me.lblDAYSFUTURE = New System.Windows.Forms.Label
        Me.lblREFURFULLNAMEText = New System.Windows.Forms.Label
        Me.txtREACCTNONEW = New System.Windows.Forms.TextBox
        Me.lblREACCTNONEW = New System.Windows.Forms.Label
        Me.lblREFULLNAMEText = New System.Windows.Forms.Label
        Me.lblREACCTNO = New System.Windows.Forms.Label
        Me.txtREACCTNO = New AppCore.FlexMaskEditBox
        Me.lblTODATE = New System.Windows.Forms.Label
        Me.lblFRDATE = New System.Windows.Forms.Label
        Me.dtpFRDATE = New System.Windows.Forms.DateTimePicker
        Me.dtpTODATE = New System.Windows.Forms.DateTimePicker
        Me.tpHidenTab = New System.Windows.Forms.TabPage
        Me.txtFUREACCTNO = New AppCore.FlexMaskEditBox
        Me.lblFUREFULLNAMEText = New System.Windows.Forms.Label
        Me.lblFUREACCTNO = New System.Windows.Forms.Label
        Me.lblFUREFRECFLNKID = New System.Windows.Forms.Label
        Me.txtFUREFRECFLNKID = New System.Windows.Forms.TextBox
        Me.lblREFRECFLNKID = New System.Windows.Forms.Label
        Me.txtREFRECFLNKID = New System.Windows.Forms.TextBox
        Me.lblORGREACCTNO = New System.Windows.Forms.Label
        Me.txtORGREACCTNO = New System.Windows.Forms.TextBox
        Me.lblAUTOID = New System.Windows.Forms.Label
        Me.lblAFACCTNO = New System.Windows.Forms.Label
        Me.txtAFACCTNO = New System.Windows.Forms.TextBox
        Me.txtAUTOID = New System.Windows.Forms.TextBox
        Me.tbcHidenTab = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.lblMGTYPE = New System.Windows.Forms.Label
        Me.cboMGTYPE = New AppCore.ComboBoxEx
        Me.Panel1.SuspendLayout()
        Me.tbcREAFLNK.SuspendLayout()
        Me.tpREAFLNK.SuspendLayout()
        Me.pnlREAFLNK.SuspendLayout()
        Me.tpHidenTab.SuspendLayout()
        Me.tbcHidenTab.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(306, 302)
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(466, 302)
        '
        'btnApply
        '
        Me.btnApply.Location = New System.Drawing.Point(386, 302)
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(558, 50)
        '
        'btnApprv
        '
        Me.btnApprv.Location = New System.Drawing.Point(225, 302)
        '
        'cboLink
        '
        '
        'tbcREAFLNK
        '
        Me.tbcREAFLNK.Controls.Add(Me.tpREAFLNK)
        Me.tbcREAFLNK.Controls.Add(Me.tpHidenTab)
        Me.tbcREAFLNK.Location = New System.Drawing.Point(0, 56)
        Me.tbcREAFLNK.Name = "tbcREAFLNK"
        Me.tbcREAFLNK.SelectedIndex = 0
        Me.tbcREAFLNK.Size = New System.Drawing.Size(558, 240)
        Me.tbcREAFLNK.TabIndex = 15
        Me.tbcREAFLNK.Tag = "tbcREAFLNK"
        '
        'tpREAFLNK
        '
        Me.tpREAFLNK.BackColor = System.Drawing.Color.Transparent
        Me.tpREAFLNK.Controls.Add(Me.pnlREAFLNK)
        Me.tpREAFLNK.Location = New System.Drawing.Point(4, 22)
        Me.tpREAFLNK.Name = "tpREAFLNK"
        Me.tpREAFLNK.Padding = New System.Windows.Forms.Padding(3)
        Me.tpREAFLNK.Size = New System.Drawing.Size(550, 214)
        Me.tpREAFLNK.TabIndex = 0
        Me.tpREAFLNK.Tag = "tpREAFLNK"
        Me.tpREAFLNK.Text = "tpREAFLNK"
        Me.tpREAFLNK.UseVisualStyleBackColor = True
        '
        'pnlREAFLNK
        '
        Me.pnlREAFLNK.BackColor = System.Drawing.SystemColors.Control
        Me.pnlREAFLNK.Controls.Add(Me.cboMGTYPE)
        Me.pnlREAFLNK.Controls.Add(Me.lblMGTYPE)
        Me.pnlREAFLNK.Controls.Add(Me.txtDAYSFUTURE)
        Me.pnlREAFLNK.Controls.Add(Me.lblDAYSFUTURE)
        Me.pnlREAFLNK.Controls.Add(Me.lblREFURFULLNAMEText)
        Me.pnlREAFLNK.Controls.Add(Me.txtREACCTNONEW)
        Me.pnlREAFLNK.Controls.Add(Me.lblREACCTNONEW)
        Me.pnlREAFLNK.Controls.Add(Me.lblREFULLNAMEText)
        Me.pnlREAFLNK.Controls.Add(Me.lblREACCTNO)
        Me.pnlREAFLNK.Controls.Add(Me.txtREACCTNO)
        Me.pnlREAFLNK.Controls.Add(Me.lblTODATE)
        Me.pnlREAFLNK.Controls.Add(Me.lblFRDATE)
        Me.pnlREAFLNK.Controls.Add(Me.dtpFRDATE)
        Me.pnlREAFLNK.Controls.Add(Me.dtpTODATE)
        Me.pnlREAFLNK.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlREAFLNK.Location = New System.Drawing.Point(3, 3)
        Me.pnlREAFLNK.Name = "pnlREAFLNK"
        Me.pnlREAFLNK.Size = New System.Drawing.Size(544, 208)
        Me.pnlREAFLNK.TabIndex = 0
        Me.pnlREAFLNK.Tag = "pnlREAFLNK"
        '
        'txtDAYSFUTURE
        '
        Me.txtDAYSFUTURE.Location = New System.Drawing.Point(156, 89)
        Me.txtDAYSFUTURE.Name = "txtDAYSFUTURE"
        Me.txtDAYSFUTURE.Size = New System.Drawing.Size(78, 21)
        Me.txtDAYSFUTURE.TabIndex = 34
        Me.txtDAYSFUTURE.Tag = "FURDAYS"
        '
        'lblDAYSFUTURE
        '
        Me.lblDAYSFUTURE.AutoSize = True
        Me.lblDAYSFUTURE.Location = New System.Drawing.Point(5, 92)
        Me.lblDAYSFUTURE.Name = "lblDAYSFUTURE"
        Me.lblDAYSFUTURE.Size = New System.Drawing.Size(82, 13)
        Me.lblDAYSFUTURE.TabIndex = 33
        Me.lblDAYSFUTURE.Tag = "FURDAYS"
        Me.lblDAYSFUTURE.Text = "lblDAYSFUTURE"
        '
        'lblREFURFULLNAMEText
        '
        Me.lblREFURFULLNAMEText.AutoSize = True
        Me.lblREFURFULLNAMEText.Location = New System.Drawing.Point(307, 65)
        Me.lblREFURFULLNAMEText.Name = "lblREFURFULLNAMEText"
        Me.lblREFURFULLNAMEText.Size = New System.Drawing.Size(123, 13)
        Me.lblREFURFULLNAMEText.TabIndex = 32
        Me.lblREFURFULLNAMEText.Text = "lblREFURFULLNAMEText"
        '
        'txtREACCTNONEW
        '
        Me.txtREACCTNONEW.Location = New System.Drawing.Point(156, 62)
        Me.txtREACCTNONEW.Name = "txtREACCTNONEW"
        Me.txtREACCTNONEW.Size = New System.Drawing.Size(145, 21)
        Me.txtREACCTNONEW.TabIndex = 31
        Me.txtREACCTNONEW.Tag = "FUTREACCTNO"
        '
        'lblREACCTNONEW
        '
        Me.lblREACCTNONEW.AutoSize = True
        Me.lblREACCTNONEW.Location = New System.Drawing.Point(5, 65)
        Me.lblREACCTNONEW.Name = "lblREACCTNONEW"
        Me.lblREACCTNONEW.Size = New System.Drawing.Size(95, 13)
        Me.lblREACCTNONEW.TabIndex = 25
        Me.lblREACCTNONEW.Tag = "FUTREACCTNO"
        Me.lblREACCTNONEW.Text = "lblREACCTNONEW"
        '
        'lblREFULLNAMEText
        '
        Me.lblREFULLNAMEText.AutoSize = True
        Me.lblREFULLNAMEText.Location = New System.Drawing.Point(307, 39)
        Me.lblREFULLNAMEText.Name = "lblREFULLNAMEText"
        Me.lblREFULLNAMEText.Size = New System.Drawing.Size(103, 13)
        Me.lblREFULLNAMEText.TabIndex = 24
        Me.lblREFULLNAMEText.Text = "lblREFULLNAMEText"
        '
        'lblREACCTNO
        '
        Me.lblREACCTNO.AutoSize = True
        Me.lblREACCTNO.Location = New System.Drawing.Point(5, 39)
        Me.lblREACCTNO.Name = "lblREACCTNO"
        Me.lblREACCTNO.Size = New System.Drawing.Size(72, 13)
        Me.lblREACCTNO.TabIndex = 19
        Me.lblREACCTNO.Tag = "REACCTNO"
        Me.lblREACCTNO.Text = "lblREACCTNO"
        '
        'txtREACCTNO
        '
        Me.txtREACCTNO.Location = New System.Drawing.Point(156, 36)
        Me.txtREACCTNO.Name = "txtREACCTNO"
        Me.txtREACCTNO.Size = New System.Drawing.Size(145, 21)
        Me.txtREACCTNO.TabIndex = 0
        Me.txtREACCTNO.Tag = "REACCTNO"
        '
        'lblTODATE
        '
        Me.lblTODATE.AutoSize = True
        Me.lblTODATE.Location = New System.Drawing.Point(5, 150)
        Me.lblTODATE.Name = "lblTODATE"
        Me.lblTODATE.Size = New System.Drawing.Size(57, 13)
        Me.lblTODATE.TabIndex = 3
        Me.lblTODATE.Tag = "TODATE"
        Me.lblTODATE.Text = "lblTODATE"
        '
        'lblFRDATE
        '
        Me.lblFRDATE.AutoSize = True
        Me.lblFRDATE.Location = New System.Drawing.Point(5, 121)
        Me.lblFRDATE.Name = "lblFRDATE"
        Me.lblFRDATE.Size = New System.Drawing.Size(56, 13)
        Me.lblFRDATE.TabIndex = 2
        Me.lblFRDATE.Tag = "FRDATE"
        Me.lblFRDATE.Text = "lblFRDATE"
        '
        'dtpFRDATE
        '
        Me.dtpFRDATE.CustomFormat = "dd/MM/yyyy"
        Me.dtpFRDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFRDATE.Location = New System.Drawing.Point(156, 117)
        Me.dtpFRDATE.Name = "dtpFRDATE"
        Me.dtpFRDATE.Size = New System.Drawing.Size(78, 21)
        Me.dtpFRDATE.TabIndex = 1
        Me.dtpFRDATE.Tag = "FRDATE"
        '
        'dtpTODATE
        '
        Me.dtpTODATE.CustomFormat = "dd/MM/yyyy"
        Me.dtpTODATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTODATE.Location = New System.Drawing.Point(156, 144)
        Me.dtpTODATE.Name = "dtpTODATE"
        Me.dtpTODATE.Size = New System.Drawing.Size(78, 21)
        Me.dtpTODATE.TabIndex = 2
        Me.dtpTODATE.Tag = "TODATE"
        '
        'tpHidenTab
        '
        Me.tpHidenTab.Controls.Add(Me.txtFUREACCTNO)
        Me.tpHidenTab.Controls.Add(Me.lblFUREFULLNAMEText)
        Me.tpHidenTab.Controls.Add(Me.lblFUREACCTNO)
        Me.tpHidenTab.Controls.Add(Me.lblFUREFRECFLNKID)
        Me.tpHidenTab.Controls.Add(Me.txtFUREFRECFLNKID)
        Me.tpHidenTab.Controls.Add(Me.lblREFRECFLNKID)
        Me.tpHidenTab.Controls.Add(Me.txtREFRECFLNKID)
        Me.tpHidenTab.Controls.Add(Me.lblORGREACCTNO)
        Me.tpHidenTab.Controls.Add(Me.txtORGREACCTNO)
        Me.tpHidenTab.Controls.Add(Me.lblAUTOID)
        Me.tpHidenTab.Controls.Add(Me.lblAFACCTNO)
        Me.tpHidenTab.Controls.Add(Me.txtAFACCTNO)
        Me.tpHidenTab.Controls.Add(Me.txtAUTOID)
        Me.tpHidenTab.Location = New System.Drawing.Point(4, 22)
        Me.tpHidenTab.Name = "tpHidenTab"
        Me.tpHidenTab.Size = New System.Drawing.Size(550, 214)
        Me.tpHidenTab.TabIndex = 1
        Me.tpHidenTab.Tag = "tpHidenTab"
        Me.tpHidenTab.Text = "tpHidenTab"
        Me.tpHidenTab.UseVisualStyleBackColor = True
        '
        'txtFUREACCTNO
        '
        Me.txtFUREACCTNO.Location = New System.Drawing.Point(143, 88)
        Me.txtFUREACCTNO.Name = "txtFUREACCTNO"
        Me.txtFUREACCTNO.Size = New System.Drawing.Size(145, 21)
        Me.txtFUREACCTNO.TabIndex = 40
        Me.txtFUREACCTNO.Tag = "FUREACCTNO"
        '
        'lblFUREFULLNAMEText
        '
        Me.lblFUREFULLNAMEText.AutoSize = True
        Me.lblFUREFULLNAMEText.Location = New System.Drawing.Point(294, 91)
        Me.lblFUREFULLNAMEText.Name = "lblFUREFULLNAMEText"
        Me.lblFUREFULLNAMEText.Size = New System.Drawing.Size(116, 13)
        Me.lblFUREFULLNAMEText.TabIndex = 39
        Me.lblFUREFULLNAMEText.Text = "lblFUREFULLNAMEText"
        '
        'lblFUREACCTNO
        '
        Me.lblFUREACCTNO.AutoSize = True
        Me.lblFUREACCTNO.Location = New System.Drawing.Point(18, 91)
        Me.lblFUREACCTNO.Name = "lblFUREACCTNO"
        Me.lblFUREACCTNO.Size = New System.Drawing.Size(85, 13)
        Me.lblFUREACCTNO.TabIndex = 38
        Me.lblFUREACCTNO.Tag = "FUREACCTNO"
        Me.lblFUREACCTNO.Text = "lblFUREACCTNO"
        '
        'lblFUREFRECFLNKID
        '
        Me.lblFUREFRECFLNKID.AutoSize = True
        Me.lblFUREFRECFLNKID.Location = New System.Drawing.Point(18, 68)
        Me.lblFUREFRECFLNKID.Name = "lblFUREFRECFLNKID"
        Me.lblFUREFRECFLNKID.Size = New System.Drawing.Size(104, 13)
        Me.lblFUREFRECFLNKID.TabIndex = 37
        Me.lblFUREFRECFLNKID.Tag = "FUREFRECFLNKID"
        Me.lblFUREFRECFLNKID.Text = "lblFUREFRECFLNKID"
        '
        'txtFUREFRECFLNKID
        '
        Me.txtFUREFRECFLNKID.Location = New System.Drawing.Point(177, 65)
        Me.txtFUREFRECFLNKID.Name = "txtFUREFRECFLNKID"
        Me.txtFUREFRECFLNKID.Size = New System.Drawing.Size(100, 21)
        Me.txtFUREFRECFLNKID.TabIndex = 36
        Me.txtFUREFRECFLNKID.Tag = "FUREFRECFLNKID"
        '
        'lblREFRECFLNKID
        '
        Me.lblREFRECFLNKID.AutoSize = True
        Me.lblREFRECFLNKID.Location = New System.Drawing.Point(286, 41)
        Me.lblREFRECFLNKID.Name = "lblREFRECFLNKID"
        Me.lblREFRECFLNKID.Size = New System.Drawing.Size(91, 13)
        Me.lblREFRECFLNKID.TabIndex = 35
        Me.lblREFRECFLNKID.Tag = "REFRECFLNKID"
        Me.lblREFRECFLNKID.Text = "lblREFRECFLNKID"
        '
        'txtREFRECFLNKID
        '
        Me.txtREFRECFLNKID.Location = New System.Drawing.Point(445, 38)
        Me.txtREFRECFLNKID.Name = "txtREFRECFLNKID"
        Me.txtREFRECFLNKID.Size = New System.Drawing.Size(100, 21)
        Me.txtREFRECFLNKID.TabIndex = 34
        Me.txtREFRECFLNKID.Tag = "REFRECFLNKID"
        '
        'lblORGREACCTNO
        '
        Me.lblORGREACCTNO.AutoSize = True
        Me.lblORGREACCTNO.Location = New System.Drawing.Point(18, 41)
        Me.lblORGREACCTNO.Name = "lblORGREACCTNO"
        Me.lblORGREACCTNO.Size = New System.Drawing.Size(94, 13)
        Me.lblORGREACCTNO.TabIndex = 33
        Me.lblORGREACCTNO.Tag = "ORGREACCTNO"
        Me.lblORGREACCTNO.Text = "lblORGREACCTNO"
        '
        'txtORGREACCTNO
        '
        Me.txtORGREACCTNO.Location = New System.Drawing.Point(177, 38)
        Me.txtORGREACCTNO.Name = "txtORGREACCTNO"
        Me.txtORGREACCTNO.Size = New System.Drawing.Size(100, 21)
        Me.txtORGREACCTNO.TabIndex = 32
        Me.txtORGREACCTNO.Tag = "ORGREACCTNO"
        '
        'lblAUTOID
        '
        Me.lblAUTOID.AutoSize = True
        Me.lblAUTOID.Location = New System.Drawing.Point(320, 15)
        Me.lblAUTOID.Name = "lblAUTOID"
        Me.lblAUTOID.Size = New System.Drawing.Size(56, 13)
        Me.lblAUTOID.TabIndex = 29
        Me.lblAUTOID.Tag = "AUTOID"
        Me.lblAUTOID.Text = "lblAUTOID"
        Me.lblAUTOID.Visible = False
        '
        'lblAFACCTNO
        '
        Me.lblAFACCTNO.AutoSize = True
        Me.lblAFACCTNO.Location = New System.Drawing.Point(18, 15)
        Me.lblAFACCTNO.Name = "lblAFACCTNO"
        Me.lblAFACCTNO.Size = New System.Drawing.Size(72, 13)
        Me.lblAFACCTNO.TabIndex = 31
        Me.lblAFACCTNO.Tag = "AFACCTNO"
        Me.lblAFACCTNO.Text = "lblAFACCTNO"
        '
        'txtAFACCTNO
        '
        Me.txtAFACCTNO.Location = New System.Drawing.Point(177, 11)
        Me.txtAFACCTNO.Name = "txtAFACCTNO"
        Me.txtAFACCTNO.Size = New System.Drawing.Size(100, 21)
        Me.txtAFACCTNO.TabIndex = 30
        Me.txtAFACCTNO.Tag = "AFACCTNO"
        '
        'txtAUTOID
        '
        Me.txtAUTOID.Location = New System.Drawing.Point(400, 11)
        Me.txtAUTOID.Name = "txtAUTOID"
        Me.txtAUTOID.Size = New System.Drawing.Size(100, 21)
        Me.txtAUTOID.TabIndex = 28
        Me.txtAUTOID.Tag = "AUTOID"
        Me.txtAUTOID.Visible = False
        '
        'tbcHidenTab
        '
        Me.tbcHidenTab.Controls.Add(Me.TabPage1)
        Me.tbcHidenTab.Location = New System.Drawing.Point(7, 371)
        Me.tbcHidenTab.Name = "tbcHidenTab"
        Me.tbcHidenTab.SelectedIndex = 0
        Me.tbcHidenTab.Size = New System.Drawing.Size(200, 27)
        Me.tbcHidenTab.TabIndex = 16
        '
        'TabPage1
        '
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(192, 1)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'lblMGTYPE
        '
        Me.lblMGTYPE.AutoSize = True
        Me.lblMGTYPE.Location = New System.Drawing.Point(5, 12)
        Me.lblMGTYPE.Name = "lblMGTYPE"
        Me.lblMGTYPE.Size = New System.Drawing.Size(56, 13)
        Me.lblMGTYPE.TabIndex = 35
        Me.lblMGTYPE.Tag = "MGTYPE"
        Me.lblMGTYPE.Text = "lblMGTYPE"
        '
        'cboMGTYPE
        '
        Me.cboMGTYPE.DisplayMember = "DISPLAY"
        Me.cboMGTYPE.FormattingEnabled = True
        Me.cboMGTYPE.Location = New System.Drawing.Point(156, 9)
        Me.cboMGTYPE.Name = "cboMGTYPE"
        Me.cboMGTYPE.Size = New System.Drawing.Size(144, 21)
        Me.cboMGTYPE.TabIndex = 37
        Me.cboMGTYPE.Tag = "MGTYPE"
        Me.cboMGTYPE.ValueMember = "VALUE"
        '
        'frmREAFLNK
        '
        Me.ClientSize = New System.Drawing.Size(558, 334)
        Me.Controls.Add(Me.tbcHidenTab)
        Me.Controls.Add(Me.tbcREAFLNK)
        Me.Name = "frmREAFLNK"
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnApprv, 0)
        Me.Controls.SetChildIndex(Me.btnApply, 0)
        Me.Controls.SetChildIndex(Me.tbcREAFLNK, 0)
        Me.Controls.SetChildIndex(Me.tbcHidenTab, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.cboLink, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.tbcREAFLNK.ResumeLayout(False)
        Me.tpREAFLNK.ResumeLayout(False)
        Me.pnlREAFLNK.ResumeLayout(False)
        Me.pnlREAFLNK.PerformLayout()
        Me.tpHidenTab.ResumeLayout(False)
        Me.tpHidenTab.PerformLayout()
        Me.tbcHidenTab.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbcREAFLNK As System.Windows.Forms.TabControl
    Friend WithEvents tpREAFLNK As System.Windows.Forms.TabPage
    Friend WithEvents pnlREAFLNK As System.Windows.Forms.Panel
    Friend WithEvents lblTODATE As System.Windows.Forms.Label
    Friend WithEvents lblFRDATE As System.Windows.Forms.Label
    Friend WithEvents dtpFRDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpTODATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblREACCTNO As System.Windows.Forms.Label
    Friend WithEvents txtREACCTNO As AppCore.FlexMaskEditBox
    Friend WithEvents tpHidenTab As System.Windows.Forms.TabPage
    Friend WithEvents tbcHidenTab As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents lblREFULLNAMEText As System.Windows.Forms.Label
    Friend WithEvents lblFUREFRECFLNKID As System.Windows.Forms.Label
    Friend WithEvents txtFUREFRECFLNKID As System.Windows.Forms.TextBox
    Friend WithEvents lblREFRECFLNKID As System.Windows.Forms.Label
    Friend WithEvents txtREFRECFLNKID As System.Windows.Forms.TextBox
    Friend WithEvents lblORGREACCTNO As System.Windows.Forms.Label
    Friend WithEvents txtORGREACCTNO As System.Windows.Forms.TextBox
    Friend WithEvents lblAUTOID As System.Windows.Forms.Label
    Friend WithEvents lblAFACCTNO As System.Windows.Forms.Label
    Friend WithEvents txtAFACCTNO As System.Windows.Forms.TextBox
    Friend WithEvents txtAUTOID As System.Windows.Forms.TextBox
    Friend WithEvents lblFUREFULLNAMEText As System.Windows.Forms.Label
    Friend WithEvents lblFUREACCTNO As System.Windows.Forms.Label
    Friend WithEvents txtFUREACCTNO As AppCore.FlexMaskEditBox
    Friend WithEvents lblREACCTNONEW As System.Windows.Forms.Label
    Friend WithEvents lblDAYSFUTURE As System.Windows.Forms.Label
    Friend WithEvents lblREFURFULLNAMEText As System.Windows.Forms.Label
    Friend WithEvents txtREACCTNONEW As System.Windows.Forms.TextBox
    Friend WithEvents txtDAYSFUTURE As System.Windows.Forms.TextBox
    Friend WithEvents lblMGTYPE As System.Windows.Forms.Label
    Friend WithEvents cboMGTYPE As AppCore.ComboBoxEx

End Class
