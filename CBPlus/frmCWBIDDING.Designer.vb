<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCWBIDDING
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCWBIDDING))
        Me.txtTOTALAMT = New System.Windows.Forms.TextBox
        Me.lblTOTALAMT = New System.Windows.Forms.Label
        Me.txtCASHRATE = New System.Windows.Forms.TextBox
        Me.lblCASHRATE = New System.Windows.Forms.Label
        Me.txtRERATE = New System.Windows.Forms.TextBox
        Me.lblRERATE = New System.Windows.Forms.Label
        Me.txtCUTEDAMT = New System.Windows.Forms.TextBox
        Me.lblCUTEDAMT = New System.Windows.Forms.Label
        Me.txtCASHFEE = New System.Windows.Forms.TextBox
        Me.lblCASHFEE = New System.Windows.Forms.Label
        Me.txtREFEE = New System.Windows.Forms.TextBox
        Me.lblREFEE = New System.Windows.Forms.Label
        Me.txtREMAININGAMT = New System.Windows.Forms.TextBox
        Me.lblREMAININGAMT = New System.Windows.Forms.Label
        Me.txtBIDDINGAMT = New System.Windows.Forms.TextBox
        Me.lblBIDDINGAMT = New System.Windows.Forms.Label
        Me.lblAFACCTNO = New System.Windows.Forms.Label
        Me.lblISSUEDATE = New System.Windows.Forms.Label
        Me.lblCODEID = New System.Windows.Forms.Label
        Me.lblCUSTODYCD = New System.Windows.Forms.Label
        Me.txtACTYPE = New System.Windows.Forms.TextBox
        Me.btnAdjust = New System.Windows.Forms.Button
        Me.btnApply = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.txtCOREBANK = New System.Windows.Forms.TextBox
        Me.grbCPSchd = New System.Windows.Forms.GroupBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.txtCUSTODYCD = New System.Windows.Forms.TextBox
        Me.dptISSUEDATE = New System.Windows.Forms.DateTimePicker
        Me.cboCODEID = New AppCore.ComboBoxEx
        Me.cboAFACCTNO = New AppCore.ComboBoxEx
        Me.cboBIDTYPE = New AppCore.ComboBoxEx
        Me.lblBIDTYPE = New System.Windows.Forms.Label
        Me.grbCPSchd.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtTOTALAMT
        '
        Me.txtTOTALAMT.Location = New System.Drawing.Point(474, 189)
        Me.txtTOTALAMT.Name = "txtTOTALAMT"
        Me.txtTOTALAMT.ReadOnly = True
        Me.txtTOTALAMT.Size = New System.Drawing.Size(157, 20)
        Me.txtTOTALAMT.TabIndex = 87
        Me.txtTOTALAMT.Tag = "TOTALAMT"
        Me.txtTOTALAMT.Text = "0"
        Me.txtTOTALAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTOTALAMT
        '
        Me.lblTOTALAMT.AutoSize = True
        Me.lblTOTALAMT.Location = New System.Drawing.Point(348, 192)
        Me.lblTOTALAMT.Name = "lblTOTALAMT"
        Me.lblTOTALAMT.Size = New System.Drawing.Size(75, 13)
        Me.lblTOTALAMT.TabIndex = 86
        Me.lblTOTALAMT.Tag = "TOTALAMT"
        Me.lblTOTALAMT.Text = "lblTOTALAMT"
        '
        'txtCASHRATE
        '
        Me.txtCASHRATE.Location = New System.Drawing.Point(131, 158)
        Me.txtCASHRATE.Name = "txtCASHRATE"
        Me.txtCASHRATE.Size = New System.Drawing.Size(168, 20)
        Me.txtCASHRATE.TabIndex = 79
        Me.txtCASHRATE.Tag = "CASHRATE"
        Me.txtCASHRATE.Text = "0"
        Me.txtCASHRATE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCASHRATE
        '
        Me.lblCASHRATE.AutoSize = True
        Me.lblCASHRATE.Location = New System.Drawing.Point(24, 161)
        Me.lblCASHRATE.Name = "lblCASHRATE"
        Me.lblCASHRATE.Size = New System.Drawing.Size(75, 13)
        Me.lblCASHRATE.TabIndex = 84
        Me.lblCASHRATE.Tag = "CASHRATE"
        Me.lblCASHRATE.Text = "lblCASHRATE"
        '
        'txtRERATE
        '
        Me.txtRERATE.Location = New System.Drawing.Point(474, 129)
        Me.txtRERATE.Name = "txtRERATE"
        Me.txtRERATE.Size = New System.Drawing.Size(157, 20)
        Me.txtRERATE.TabIndex = 83
        Me.txtRERATE.Tag = "RERATE"
        Me.txtRERATE.Text = "0"
        Me.txtRERATE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblRERATE
        '
        Me.lblRERATE.AutoSize = True
        Me.lblRERATE.Location = New System.Drawing.Point(351, 132)
        Me.lblRERATE.Name = "lblRERATE"
        Me.lblRERATE.Size = New System.Drawing.Size(61, 13)
        Me.lblRERATE.TabIndex = 82
        Me.lblRERATE.Tag = "RERATE"
        Me.lblRERATE.Text = "lblRERATE"
        '
        'txtCUTEDAMT
        '
        Me.txtCUTEDAMT.Location = New System.Drawing.Point(474, 100)
        Me.txtCUTEDAMT.Name = "txtCUTEDAMT"
        Me.txtCUTEDAMT.ReadOnly = True
        Me.txtCUTEDAMT.Size = New System.Drawing.Size(157, 20)
        Me.txtCUTEDAMT.TabIndex = 75
        Me.txtCUTEDAMT.Tag = "CUTEDAMT"
        Me.txtCUTEDAMT.Text = "0"
        Me.txtCUTEDAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCUTEDAMT
        '
        Me.lblCUTEDAMT.AutoSize = True
        Me.lblCUTEDAMT.Location = New System.Drawing.Point(348, 103)
        Me.lblCUTEDAMT.Name = "lblCUTEDAMT"
        Me.lblCUTEDAMT.Size = New System.Drawing.Size(77, 13)
        Me.lblCUTEDAMT.TabIndex = 80
        Me.lblCUTEDAMT.Tag = "CUTEDAMT"
        Me.lblCUTEDAMT.Text = "lblCUTEDAMT"
        '
        'txtCASHFEE
        '
        Me.txtCASHFEE.Location = New System.Drawing.Point(131, 189)
        Me.txtCASHFEE.Name = "txtCASHFEE"
        Me.txtCASHFEE.ReadOnly = True
        Me.txtCASHFEE.Size = New System.Drawing.Size(168, 20)
        Me.txtCASHFEE.TabIndex = 81
        Me.txtCASHFEE.Tag = "CASHFEE"
        Me.txtCASHFEE.Text = "0"
        Me.txtCASHFEE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCASHFEE
        '
        Me.lblCASHFEE.AutoSize = True
        Me.lblCASHFEE.Location = New System.Drawing.Point(24, 192)
        Me.lblCASHFEE.Name = "lblCASHFEE"
        Me.lblCASHFEE.Size = New System.Drawing.Size(66, 13)
        Me.lblCASHFEE.TabIndex = 78
        Me.lblCASHFEE.Tag = "CASHFEE"
        Me.lblCASHFEE.Text = "lblCASHFEE"
        '
        'txtREFEE
        '
        Me.txtREFEE.Location = New System.Drawing.Point(474, 158)
        Me.txtREFEE.Name = "txtREFEE"
        Me.txtREFEE.ReadOnly = True
        Me.txtREFEE.Size = New System.Drawing.Size(157, 20)
        Me.txtREFEE.TabIndex = 85
        Me.txtREFEE.Tag = "REFEE"
        Me.txtREFEE.Text = "0"
        Me.txtREFEE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblREFEE
        '
        Me.lblREFEE.AutoSize = True
        Me.lblREFEE.Location = New System.Drawing.Point(351, 161)
        Me.lblREFEE.Name = "lblREFEE"
        Me.lblREFEE.Size = New System.Drawing.Size(52, 13)
        Me.lblREFEE.TabIndex = 76
        Me.lblREFEE.Tag = "REFEE"
        Me.lblREFEE.Text = "lblREFEE"
        '
        'txtREMAININGAMT
        '
        Me.txtREMAININGAMT.Location = New System.Drawing.Point(131, 129)
        Me.txtREMAININGAMT.Name = "txtREMAININGAMT"
        Me.txtREMAININGAMT.ReadOnly = True
        Me.txtREMAININGAMT.Size = New System.Drawing.Size(168, 20)
        Me.txtREMAININGAMT.TabIndex = 77
        Me.txtREMAININGAMT.Tag = "REMAININGAMT"
        Me.txtREMAININGAMT.Text = "0"
        Me.txtREMAININGAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblREMAININGAMT
        '
        Me.lblREMAININGAMT.AutoSize = True
        Me.lblREMAININGAMT.Location = New System.Drawing.Point(24, 132)
        Me.lblREMAININGAMT.Name = "lblREMAININGAMT"
        Me.lblREMAININGAMT.Size = New System.Drawing.Size(101, 13)
        Me.lblREMAININGAMT.TabIndex = 74
        Me.lblREMAININGAMT.Tag = "REMAININGAMT"
        Me.lblREMAININGAMT.Text = "lblREMAININGAMT"
        '
        'txtBIDDINGAMT
        '
        Me.txtBIDDINGAMT.Location = New System.Drawing.Point(131, 100)
        Me.txtBIDDINGAMT.Name = "txtBIDDINGAMT"
        Me.txtBIDDINGAMT.Size = New System.Drawing.Size(168, 20)
        Me.txtBIDDINGAMT.TabIndex = 73
        Me.txtBIDDINGAMT.Tag = "BIDDINGAMT"
        Me.txtBIDDINGAMT.Text = "0"
        Me.txtBIDDINGAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblBIDDINGAMT
        '
        Me.lblBIDDINGAMT.AutoSize = True
        Me.lblBIDDINGAMT.Location = New System.Drawing.Point(24, 103)
        Me.lblBIDDINGAMT.Name = "lblBIDDINGAMT"
        Me.lblBIDDINGAMT.Size = New System.Drawing.Size(85, 13)
        Me.lblBIDDINGAMT.TabIndex = 72
        Me.lblBIDDINGAMT.Tag = "BIDDINGAMT"
        Me.lblBIDDINGAMT.Text = "lblBIDDINGAMT"
        '
        'lblAFACCTNO
        '
        Me.lblAFACCTNO.AutoSize = True
        Me.lblAFACCTNO.Location = New System.Drawing.Point(348, 72)
        Me.lblAFACCTNO.Name = "lblAFACCTNO"
        Me.lblAFACCTNO.Size = New System.Drawing.Size(74, 13)
        Me.lblAFACCTNO.TabIndex = 70
        Me.lblAFACCTNO.Tag = "AFACCTNO"
        Me.lblAFACCTNO.Text = "lblAFACCTNO"
        '
        'lblISSUEDATE
        '
        Me.lblISSUEDATE.AutoSize = True
        Me.lblISSUEDATE.Location = New System.Drawing.Point(348, 42)
        Me.lblISSUEDATE.Name = "lblISSUEDATE"
        Me.lblISSUEDATE.Size = New System.Drawing.Size(78, 13)
        Me.lblISSUEDATE.TabIndex = 68
        Me.lblISSUEDATE.Tag = "ISSUEDATE"
        Me.lblISSUEDATE.Text = "lblISSUEDATE"
        '
        'lblCODEID
        '
        Me.lblCODEID.AutoSize = True
        Me.lblCODEID.Location = New System.Drawing.Point(24, 42)
        Me.lblCODEID.Name = "lblCODEID"
        Me.lblCODEID.Size = New System.Drawing.Size(58, 13)
        Me.lblCODEID.TabIndex = 66
        Me.lblCODEID.Tag = "CODEID"
        Me.lblCODEID.Text = "lblCODEID"
        '
        'lblCUSTODYCD
        '
        Me.lblCUSTODYCD.AutoSize = True
        Me.lblCUSTODYCD.Location = New System.Drawing.Point(24, 72)
        Me.lblCUSTODYCD.Name = "lblCUSTODYCD"
        Me.lblCUSTODYCD.Size = New System.Drawing.Size(84, 13)
        Me.lblCUSTODYCD.TabIndex = 64
        Me.lblCUSTODYCD.Tag = "CUSTODYCD"
        Me.lblCUSTODYCD.Text = "lblCUSTODYCD"
        '
        'txtACTYPE
        '
        Me.txtACTYPE.Location = New System.Drawing.Point(20, 414)
        Me.txtACTYPE.Name = "txtACTYPE"
        Me.txtACTYPE.ReadOnly = True
        Me.txtACTYPE.Size = New System.Drawing.Size(100, 20)
        Me.txtACTYPE.TabIndex = 73
        Me.txtACTYPE.Tag = "txtACTYPE"
        Me.txtACTYPE.Visible = False
        '
        'btnAdjust
        '
        Me.btnAdjust.Location = New System.Drawing.Point(419, 412)
        Me.btnAdjust.Name = "btnAdjust"
        Me.btnAdjust.Size = New System.Drawing.Size(75, 23)
        Me.btnAdjust.TabIndex = 90
        Me.btnAdjust.Text = "btnAdjust"
        Me.btnAdjust.UseVisualStyleBackColor = True
        '
        'btnApply
        '
        Me.btnApply.Location = New System.Drawing.Point(503, 412)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(75, 23)
        Me.btnApply.TabIndex = 89
        Me.btnApply.Text = "btnApply"
        Me.btnApply.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(590, 412)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 91
        Me.btnCancel.Text = "btnCancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'txtCOREBANK
        '
        Me.txtCOREBANK.Location = New System.Drawing.Point(126, 415)
        Me.txtCOREBANK.Name = "txtCOREBANK"
        Me.txtCOREBANK.ReadOnly = True
        Me.txtCOREBANK.Size = New System.Drawing.Size(100, 20)
        Me.txtCOREBANK.TabIndex = 74
        Me.txtCOREBANK.Tag = "txtCOREBANK"
        Me.txtCOREBANK.Visible = False
        '
        'grbCPSchd
        '
        Me.grbCPSchd.Controls.Add(Me.Panel1)
        Me.grbCPSchd.Location = New System.Drawing.Point(3, 214)
        Me.grbCPSchd.Name = "grbCPSchd"
        Me.grbCPSchd.Size = New System.Drawing.Size(668, 180)
        Me.grbCPSchd.TabIndex = 88
        Me.grbCPSchd.TabStop = False
        Me.grbCPSchd.Tag = "grbCPSchd"
        Me.grbCPSchd.Text = "grbCPSchd"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Location = New System.Drawing.Point(12, 19)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(646, 155)
        Me.Panel1.TabIndex = 0
        '
        'txtCUSTODYCD
        '
        Me.txtCUSTODYCD.BackColor = System.Drawing.Color.Lime
        Me.txtCUSTODYCD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCUSTODYCD.Location = New System.Drawing.Point(131, 69)
        Me.txtCUSTODYCD.MaxLength = 10
        Me.txtCUSTODYCD.Name = "txtCUSTODYCD"
        Me.txtCUSTODYCD.Size = New System.Drawing.Size(168, 20)
        Me.txtCUSTODYCD.TabIndex = 71
        Me.txtCUSTODYCD.Tag = "CUSTODYCD"
        Me.txtCUSTODYCD.Text = "txtCUSTODYCD"
        '
        'dptISSUEDATE
        '
        Me.dptISSUEDATE.CustomFormat = "dd/MM/yyyy"
        Me.dptISSUEDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dptISSUEDATE.Location = New System.Drawing.Point(474, 40)
        Me.dptISSUEDATE.Name = "dptISSUEDATE"
        Me.dptISSUEDATE.Size = New System.Drawing.Size(157, 20)
        Me.dptISSUEDATE.TabIndex = 70
        Me.dptISSUEDATE.Tag = "ISSUEDATE"
        '
        'cboCODEID
        '
        Me.cboCODEID.DisplayMember = "DISPLAY"
        Me.cboCODEID.FormattingEnabled = True
        Me.cboCODEID.Location = New System.Drawing.Point(131, 39)
        Me.cboCODEID.Name = "cboCODEID"
        Me.cboCODEID.Size = New System.Drawing.Size(168, 21)
        Me.cboCODEID.TabIndex = 2
        Me.cboCODEID.Tag = "CODEID"
        Me.cboCODEID.ValueMember = "VALUE"
        '
        'cboAFACCTNO
        '
        Me.cboAFACCTNO.DisplayMember = "DISPLAY"
        Me.cboAFACCTNO.FormattingEnabled = True
        Me.cboAFACCTNO.Location = New System.Drawing.Point(474, 69)
        Me.cboAFACCTNO.Name = "cboAFACCTNO"
        Me.cboAFACCTNO.Size = New System.Drawing.Size(157, 21)
        Me.cboAFACCTNO.TabIndex = 72
        Me.cboAFACCTNO.Tag = "AFACCTNO"
        Me.cboAFACCTNO.ValueMember = "VALUE"
        '
        'cboBIDTYPE
        '
        Me.cboBIDTYPE.DisplayMember = "DISPLAY"
        Me.cboBIDTYPE.FormattingEnabled = True
        Me.cboBIDTYPE.Location = New System.Drawing.Point(131, 10)
        Me.cboBIDTYPE.Name = "cboBIDTYPE"
        Me.cboBIDTYPE.Size = New System.Drawing.Size(168, 21)
        Me.cboBIDTYPE.TabIndex = 1
        Me.cboBIDTYPE.Tag = "BIDTYPE"
        Me.cboBIDTYPE.ValueMember = "VALUE"
        '
        'lblBIDTYPE
        '
        Me.lblBIDTYPE.AutoSize = True
        Me.lblBIDTYPE.Location = New System.Drawing.Point(24, 13)
        Me.lblBIDTYPE.Name = "lblBIDTYPE"
        Me.lblBIDTYPE.Size = New System.Drawing.Size(63, 13)
        Me.lblBIDTYPE.TabIndex = 93
        Me.lblBIDTYPE.Tag = "BIDTYPE"
        Me.lblBIDTYPE.Text = "lblBIDTYPE"
        '
        'frmCWBIDDING
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(679, 447)
        Me.Controls.Add(Me.cboBIDTYPE)
        Me.Controls.Add(Me.lblBIDTYPE)
        Me.Controls.Add(Me.dptISSUEDATE)
        Me.Controls.Add(Me.cboCODEID)
        Me.Controls.Add(Me.cboAFACCTNO)
        Me.Controls.Add(Me.txtCUSTODYCD)
        Me.Controls.Add(Me.grbCPSchd)
        Me.Controls.Add(Me.txtACTYPE)
        Me.Controls.Add(Me.btnAdjust)
        Me.Controls.Add(Me.txtTOTALAMT)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.lblTOTALAMT)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.txtCASHRATE)
        Me.Controls.Add(Me.txtCOREBANK)
        Me.Controls.Add(Me.lblCASHRATE)
        Me.Controls.Add(Me.txtRERATE)
        Me.Controls.Add(Me.lblRERATE)
        Me.Controls.Add(Me.txtCUTEDAMT)
        Me.Controls.Add(Me.lblCUTEDAMT)
        Me.Controls.Add(Me.txtCASHFEE)
        Me.Controls.Add(Me.lblCASHFEE)
        Me.Controls.Add(Me.txtREFEE)
        Me.Controls.Add(Me.lblREFEE)
        Me.Controls.Add(Me.txtREMAININGAMT)
        Me.Controls.Add(Me.lblREMAININGAMT)
        Me.Controls.Add(Me.txtBIDDINGAMT)
        Me.Controls.Add(Me.lblBIDDINGAMT)
        Me.Controls.Add(Me.lblAFACCTNO)
        Me.Controls.Add(Me.lblISSUEDATE)
        Me.Controls.Add(Me.lblCODEID)
        Me.Controls.Add(Me.lblCUSTODYCD)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCWBIDDING"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmCWBIDDING"
        Me.grbCPSchd.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtTOTALAMT As System.Windows.Forms.TextBox
    Friend WithEvents lblTOTALAMT As System.Windows.Forms.Label
    Friend WithEvents txtCASHRATE As System.Windows.Forms.TextBox
    Friend WithEvents lblCASHRATE As System.Windows.Forms.Label
    Friend WithEvents txtRERATE As System.Windows.Forms.TextBox
    Friend WithEvents lblRERATE As System.Windows.Forms.Label
    Friend WithEvents txtCUTEDAMT As System.Windows.Forms.TextBox
    Friend WithEvents lblCUTEDAMT As System.Windows.Forms.Label
    Friend WithEvents txtCASHFEE As System.Windows.Forms.TextBox
    Friend WithEvents lblCASHFEE As System.Windows.Forms.Label
    Friend WithEvents txtREFEE As System.Windows.Forms.TextBox
    Friend WithEvents lblREFEE As System.Windows.Forms.Label
    Friend WithEvents txtREMAININGAMT As System.Windows.Forms.TextBox
    Friend WithEvents lblREMAININGAMT As System.Windows.Forms.Label
    Friend WithEvents txtBIDDINGAMT As System.Windows.Forms.TextBox
    Friend WithEvents lblBIDDINGAMT As System.Windows.Forms.Label
    Friend WithEvents lblAFACCTNO As System.Windows.Forms.Label
    Friend WithEvents lblISSUEDATE As System.Windows.Forms.Label
    Friend WithEvents lblCODEID As System.Windows.Forms.Label
    Friend WithEvents lblCUSTODYCD As System.Windows.Forms.Label
    Friend WithEvents txtACTYPE As System.Windows.Forms.TextBox
    Friend WithEvents btnAdjust As System.Windows.Forms.Button
    Friend WithEvents btnApply As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents txtCOREBANK As System.Windows.Forms.TextBox
    Friend WithEvents grbCPSchd As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtCUSTODYCD As System.Windows.Forms.TextBox
    Friend WithEvents cboAFACCTNO As AppCore.ComboBoxEx
    Friend WithEvents cboCODEID As AppCore.ComboBoxEx
    Friend WithEvents dptISSUEDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboBIDTYPE As AppCore.ComboBoxEx
    Friend WithEvents lblBIDTYPE As System.Windows.Forms.Label
End Class
