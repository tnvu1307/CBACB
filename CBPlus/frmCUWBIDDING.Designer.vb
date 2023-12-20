<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCUWBIDDING
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCUWBIDDING))
        Me.txtCUTEDAMT = New System.Windows.Forms.TextBox
        Me.lblCUTEDAMT = New System.Windows.Forms.Label
        Me.txtCASHFEE = New System.Windows.Forms.TextBox
        Me.lblCASHFEE = New System.Windows.Forms.Label
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
        'txtCUTEDAMT
        '
        Me.txtCUTEDAMT.Location = New System.Drawing.Point(484, 92)
        Me.txtCUTEDAMT.Name = "txtCUTEDAMT"
        Me.txtCUTEDAMT.ReadOnly = True
        Me.txtCUTEDAMT.Size = New System.Drawing.Size(157, 20)
        Me.txtCUTEDAMT.TabIndex = 87
        Me.txtCUTEDAMT.Tag = "CUTEDAMT"
        Me.txtCUTEDAMT.Text = "0"
        Me.txtCUTEDAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCUTEDAMT
        '
        Me.lblCUTEDAMT.AutoSize = True
        Me.lblCUTEDAMT.Location = New System.Drawing.Point(346, 95)
        Me.lblCUTEDAMT.Name = "lblCUTEDAMT"
        Me.lblCUTEDAMT.Size = New System.Drawing.Size(77, 13)
        Me.lblCUTEDAMT.TabIndex = 86
        Me.lblCUTEDAMT.Tag = "CUTEDAMT"
        Me.lblCUTEDAMT.Text = "lblCUTEDAMT"
        '
        'txtCASHFEE
        '
        Me.txtCASHFEE.Location = New System.Drawing.Point(131, 92)
        Me.txtCASHFEE.Name = "txtCASHFEE"
        Me.txtCASHFEE.Size = New System.Drawing.Size(168, 20)
        Me.txtCASHFEE.TabIndex = 79
        Me.txtCASHFEE.Tag = "CASHFEE"
        Me.txtCASHFEE.Text = "0"
        Me.txtCASHFEE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCASHFEE
        '
        Me.lblCASHFEE.AutoSize = True
        Me.lblCASHFEE.Location = New System.Drawing.Point(37, 95)
        Me.lblCASHFEE.Name = "lblCASHFEE"
        Me.lblCASHFEE.Size = New System.Drawing.Size(66, 13)
        Me.lblCASHFEE.TabIndex = 78
        Me.lblCASHFEE.Tag = "CASHFEE"
        Me.lblCASHFEE.Text = "lblCASHFEE"
        '
        'lblAFACCTNO
        '
        Me.lblAFACCTNO.AutoSize = True
        Me.lblAFACCTNO.Location = New System.Drawing.Point(346, 67)
        Me.lblAFACCTNO.Name = "lblAFACCTNO"
        Me.lblAFACCTNO.Size = New System.Drawing.Size(74, 13)
        Me.lblAFACCTNO.TabIndex = 70
        Me.lblAFACCTNO.Tag = "AFACCTNO"
        Me.lblAFACCTNO.Text = "lblAFACCTNO"
        '
        'lblISSUEDATE
        '
        Me.lblISSUEDATE.AutoSize = True
        Me.lblISSUEDATE.Location = New System.Drawing.Point(346, 37)
        Me.lblISSUEDATE.Name = "lblISSUEDATE"
        Me.lblISSUEDATE.Size = New System.Drawing.Size(78, 13)
        Me.lblISSUEDATE.TabIndex = 68
        Me.lblISSUEDATE.Tag = "ISSUEDATE"
        Me.lblISSUEDATE.Text = "lblISSUEDATE"
        '
        'lblCODEID
        '
        Me.lblCODEID.AutoSize = True
        Me.lblCODEID.Location = New System.Drawing.Point(35, 37)
        Me.lblCODEID.Name = "lblCODEID"
        Me.lblCODEID.Size = New System.Drawing.Size(58, 13)
        Me.lblCODEID.TabIndex = 66
        Me.lblCODEID.Tag = "CODEID"
        Me.lblCODEID.Text = "lblCODEID"
        '
        'lblCUSTODYCD
        '
        Me.lblCUSTODYCD.AutoSize = True
        Me.lblCUSTODYCD.Location = New System.Drawing.Point(35, 67)
        Me.lblCUSTODYCD.Name = "lblCUSTODYCD"
        Me.lblCUSTODYCD.Size = New System.Drawing.Size(84, 13)
        Me.lblCUSTODYCD.TabIndex = 64
        Me.lblCUSTODYCD.Tag = "CUSTODYCD"
        Me.lblCUSTODYCD.Text = "lblCUSTODYCD"
        '
        'txtACTYPE
        '
        Me.txtACTYPE.Location = New System.Drawing.Point(16, 347)
        Me.txtACTYPE.Name = "txtACTYPE"
        Me.txtACTYPE.ReadOnly = True
        Me.txtACTYPE.Size = New System.Drawing.Size(100, 20)
        Me.txtACTYPE.TabIndex = 73
        Me.txtACTYPE.Tag = "txtACTYPE"
        Me.txtACTYPE.Visible = False
        '
        'btnAdjust
        '
        Me.btnAdjust.Location = New System.Drawing.Point(415, 345)
        Me.btnAdjust.Name = "btnAdjust"
        Me.btnAdjust.Size = New System.Drawing.Size(75, 23)
        Me.btnAdjust.TabIndex = 91
        Me.btnAdjust.Text = "btnAdjust"
        Me.btnAdjust.UseVisualStyleBackColor = True
        '
        'btnApply
        '
        Me.btnApply.Location = New System.Drawing.Point(499, 345)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(75, 23)
        Me.btnApply.TabIndex = 90
        Me.btnApply.Text = "btnApply"
        Me.btnApply.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(586, 345)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 89
        Me.btnCancel.Text = "btnCancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'txtCOREBANK
        '
        Me.txtCOREBANK.Location = New System.Drawing.Point(122, 348)
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
        Me.grbCPSchd.Location = New System.Drawing.Point(3, 125)
        Me.grbCPSchd.Name = "grbCPSchd"
        Me.grbCPSchd.Size = New System.Drawing.Size(668, 214)
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
        Me.Panel1.Size = New System.Drawing.Size(646, 189)
        Me.Panel1.TabIndex = 0
        '
        'txtCUSTODYCD
        '
        Me.txtCUSTODYCD.BackColor = System.Drawing.Color.Lime
        Me.txtCUSTODYCD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCUSTODYCD.Location = New System.Drawing.Point(131, 64)
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
        Me.dptISSUEDATE.Location = New System.Drawing.Point(484, 30)
        Me.dptISSUEDATE.Name = "dptISSUEDATE"
        Me.dptISSUEDATE.Size = New System.Drawing.Size(157, 20)
        Me.dptISSUEDATE.TabIndex = 70
        Me.dptISSUEDATE.Tag = "ISSUEDATE"
        '
        'cboCODEID
        '
        Me.cboCODEID.DisplayMember = "DISPLAY"
        Me.cboCODEID.FormattingEnabled = True
        Me.cboCODEID.Location = New System.Drawing.Point(131, 33)
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
        Me.cboAFACCTNO.Location = New System.Drawing.Point(484, 64)
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
        Me.cboBIDTYPE.Location = New System.Drawing.Point(131, 4)
        Me.cboBIDTYPE.Name = "cboBIDTYPE"
        Me.cboBIDTYPE.Size = New System.Drawing.Size(168, 21)
        Me.cboBIDTYPE.TabIndex = 1
        Me.cboBIDTYPE.Tag = "BIDTYPE"
        Me.cboBIDTYPE.ValueMember = "VALUE"
        '
        'lblBIDTYPE
        '
        Me.lblBIDTYPE.AutoSize = True
        Me.lblBIDTYPE.Location = New System.Drawing.Point(35, 12)
        Me.lblBIDTYPE.Name = "lblBIDTYPE"
        Me.lblBIDTYPE.Size = New System.Drawing.Size(63, 13)
        Me.lblBIDTYPE.TabIndex = 93
        Me.lblBIDTYPE.Tag = "BIDTYPE"
        Me.lblBIDTYPE.Text = "lblBIDTYPE"
        '
        'frmCUWBIDDING
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(679, 377)
        Me.Controls.Add(Me.cboBIDTYPE)
        Me.Controls.Add(Me.lblBIDTYPE)
        Me.Controls.Add(Me.dptISSUEDATE)
        Me.Controls.Add(Me.cboCODEID)
        Me.Controls.Add(Me.cboAFACCTNO)
        Me.Controls.Add(Me.txtCUSTODYCD)
        Me.Controls.Add(Me.grbCPSchd)
        Me.Controls.Add(Me.txtACTYPE)
        Me.Controls.Add(Me.btnAdjust)
        Me.Controls.Add(Me.txtCUTEDAMT)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.lblCUTEDAMT)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.txtCOREBANK)
        Me.Controls.Add(Me.txtCASHFEE)
        Me.Controls.Add(Me.lblCASHFEE)
        Me.Controls.Add(Me.lblAFACCTNO)
        Me.Controls.Add(Me.lblISSUEDATE)
        Me.Controls.Add(Me.lblCODEID)
        Me.Controls.Add(Me.lblCUSTODYCD)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCUWBIDDING"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmCUWBIDDING"
        Me.grbCPSchd.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCUTEDAMT As System.Windows.Forms.TextBox
    Friend WithEvents lblCUTEDAMT As System.Windows.Forms.Label
    Friend WithEvents txtCASHFEE As System.Windows.Forms.TextBox
    Friend WithEvents lblCASHFEE As System.Windows.Forms.Label
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
