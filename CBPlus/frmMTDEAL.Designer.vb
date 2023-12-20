<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMTDEAL
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
        Me.grbInfo = New System.Windows.Forms.GroupBox
        Me.lblSecInfo = New System.Windows.Forms.Label
        Me.lblSYMBOL = New System.Windows.Forms.Label
        Me.cboSYMBOL = New System.Windows.Forms.ComboBox
        Me.lblMTTYPE = New System.Windows.Forms.Label
        Me.txtMTTYPE = New System.Windows.Forms.TextBox
        Me.lblAFACCTNO = New System.Windows.Forms.Label
        Me.txtAFACCTNO = New System.Windows.Forms.TextBox
        Me.grpPrice = New System.Windows.Forms.GroupBox
        Me.lblQTTY = New System.Windows.Forms.Label
        Me.txtQTTY = New System.Windows.Forms.TextBox
        Me.lblLRATE = New System.Windows.Forms.Label
        Me.txtLRATE = New System.Windows.Forms.TextBox
        Me.lblMRATE = New System.Windows.Forms.Label
        Me.txtMRATE = New System.Windows.Forms.TextBox
        Me.lblIRATE = New System.Windows.Forms.Label
        Me.txtIRATE = New System.Windows.Forms.TextBox
        Me.lblTRIGGERPRICE = New System.Windows.Forms.Label
        Me.txtTRIGGERPRICE = New System.Windows.Forms.TextBox
        Me.lblMTPRICE = New System.Windows.Forms.Label
        Me.txtMTPRICE = New System.Windows.Forms.TextBox
        Me.lblMTRATE = New System.Windows.Forms.Label
        Me.txtMTRATE = New System.Windows.Forms.TextBox
        Me.lblREFPRICE = New System.Windows.Forms.Label
        Me.txtREFPRICE = New System.Windows.Forms.TextBox
        Me.grbNOTE = New System.Windows.Forms.GroupBox
        Me.lblDESCRIPTION = New System.Windows.Forms.Label
        Me.txtDESCRIPTION = New System.Windows.Forms.TextBox
        Me.lblREF = New System.Windows.Forms.Label
        Me.txtREF = New System.Windows.Forms.TextBox
        Me.btnSUBMIT = New System.Windows.Forms.Button
        Me.btnCANCEL = New System.Windows.Forms.Button
        Me.grbInfo.SuspendLayout()
        Me.grpPrice.SuspendLayout()
        Me.grbNOTE.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbInfo
        '
        Me.grbInfo.Controls.Add(Me.lblSecInfo)
        Me.grbInfo.Controls.Add(Me.lblSYMBOL)
        Me.grbInfo.Controls.Add(Me.cboSYMBOL)
        Me.grbInfo.Controls.Add(Me.lblMTTYPE)
        Me.grbInfo.Controls.Add(Me.txtMTTYPE)
        Me.grbInfo.Controls.Add(Me.lblAFACCTNO)
        Me.grbInfo.Controls.Add(Me.txtAFACCTNO)
        Me.grbInfo.Location = New System.Drawing.Point(26, 12)
        Me.grbInfo.Name = "grbInfo"
        Me.grbInfo.Size = New System.Drawing.Size(498, 103)
        Me.grbInfo.TabIndex = 0
        Me.grbInfo.TabStop = False
        Me.grbInfo.Tag = "grbInfo"
        Me.grbInfo.Text = "grbInfo"
        '
        'lblSecInfo
        '
        Me.lblSecInfo.Location = New System.Drawing.Point(122, 73)
        Me.lblSecInfo.Name = "lblSecInfo"
        Me.lblSecInfo.Size = New System.Drawing.Size(359, 23)
        Me.lblSecInfo.TabIndex = 6
        Me.lblSecInfo.Tag = "lblSecInfo"
        Me.lblSecInfo.Text = "lblSecInfo"
        '
        'lblSYMBOL
        '
        Me.lblSYMBOL.Location = New System.Drawing.Point(15, 47)
        Me.lblSYMBOL.Name = "lblSYMBOL"
        Me.lblSYMBOL.Size = New System.Drawing.Size(99, 23)
        Me.lblSYMBOL.TabIndex = 5
        Me.lblSYMBOL.Tag = "lblSYMBOL"
        Me.lblSYMBOL.Text = "lblSYMBOL"
        '
        'cboSYMBOL
        '
        Me.cboSYMBOL.DisplayMember = "cboSYMBOL"
        Me.cboSYMBOL.FormattingEnabled = True
        Me.cboSYMBOL.Location = New System.Drawing.Point(125, 49)
        Me.cboSYMBOL.Name = "cboSYMBOL"
        Me.cboSYMBOL.Size = New System.Drawing.Size(108, 21)
        Me.cboSYMBOL.TabIndex = 4
        Me.cboSYMBOL.Text = "cboSYMBOL"
        Me.cboSYMBOL.ValueMember = "cboSYMBOL"
        '
        'lblMTTYPE
        '
        Me.lblMTTYPE.Location = New System.Drawing.Point(254, 19)
        Me.lblMTTYPE.Name = "lblMTTYPE"
        Me.lblMTTYPE.Size = New System.Drawing.Size(108, 23)
        Me.lblMTTYPE.TabIndex = 3
        Me.lblMTTYPE.Tag = "lblMTTYPE"
        Me.lblMTTYPE.Text = "lblMTTYPE"
        '
        'txtMTTYPE
        '
        Me.txtMTTYPE.Location = New System.Drawing.Point(373, 19)
        Me.txtMTTYPE.Name = "txtMTTYPE"
        Me.txtMTTYPE.Size = New System.Drawing.Size(108, 20)
        Me.txtMTTYPE.TabIndex = 2
        Me.txtMTTYPE.Tag = "txtMTTYPE"
        Me.txtMTTYPE.Text = "txtMTTYPE"
        '
        'lblAFACCTNO
        '
        Me.lblAFACCTNO.Location = New System.Drawing.Point(15, 19)
        Me.lblAFACCTNO.Name = "lblAFACCTNO"
        Me.lblAFACCTNO.Size = New System.Drawing.Size(99, 23)
        Me.lblAFACCTNO.TabIndex = 1
        Me.lblAFACCTNO.Tag = "lblAFACCTNO"
        Me.lblAFACCTNO.Text = "lblAFACCTNO"
        '
        'txtAFACCTNO
        '
        Me.txtAFACCTNO.Location = New System.Drawing.Point(125, 19)
        Me.txtAFACCTNO.Name = "txtAFACCTNO"
        Me.txtAFACCTNO.Size = New System.Drawing.Size(108, 20)
        Me.txtAFACCTNO.TabIndex = 0
        Me.txtAFACCTNO.Tag = "txtAFACCTNO"
        Me.txtAFACCTNO.Text = "txtAFACCTNO"
        '
        'grpPrice
        '
        Me.grpPrice.Controls.Add(Me.lblQTTY)
        Me.grpPrice.Controls.Add(Me.txtQTTY)
        Me.grpPrice.Controls.Add(Me.lblLRATE)
        Me.grpPrice.Controls.Add(Me.txtLRATE)
        Me.grpPrice.Controls.Add(Me.lblMRATE)
        Me.grpPrice.Controls.Add(Me.txtMRATE)
        Me.grpPrice.Controls.Add(Me.lblIRATE)
        Me.grpPrice.Controls.Add(Me.txtIRATE)
        Me.grpPrice.Controls.Add(Me.lblTRIGGERPRICE)
        Me.grpPrice.Controls.Add(Me.txtTRIGGERPRICE)
        Me.grpPrice.Controls.Add(Me.lblMTPRICE)
        Me.grpPrice.Controls.Add(Me.txtMTPRICE)
        Me.grpPrice.Controls.Add(Me.lblMTRATE)
        Me.grpPrice.Controls.Add(Me.txtMTRATE)
        Me.grpPrice.Controls.Add(Me.lblREFPRICE)
        Me.grpPrice.Controls.Add(Me.txtREFPRICE)
        Me.grpPrice.Location = New System.Drawing.Point(26, 121)
        Me.grpPrice.Name = "grpPrice"
        Me.grpPrice.Size = New System.Drawing.Size(498, 129)
        Me.grpPrice.TabIndex = 1
        Me.grpPrice.TabStop = False
        Me.grpPrice.Tag = "grpPrice"
        Me.grpPrice.Text = "grpPrice"
        '
        'lblQTTY
        '
        Me.lblQTTY.Location = New System.Drawing.Point(263, 94)
        Me.lblQTTY.Name = "lblQTTY"
        Me.lblQTTY.Size = New System.Drawing.Size(99, 23)
        Me.lblQTTY.TabIndex = 17
        Me.lblQTTY.Tag = "lblQTTY"
        Me.lblQTTY.Text = "lblQTTY"
        '
        'txtQTTY
        '
        Me.txtQTTY.Location = New System.Drawing.Point(373, 94)
        Me.txtQTTY.Name = "txtQTTY"
        Me.txtQTTY.Size = New System.Drawing.Size(108, 20)
        Me.txtQTTY.TabIndex = 16
        Me.txtQTTY.Tag = "txtQTTY"
        Me.txtQTTY.Text = "txtQTTY"
        '
        'lblLRATE
        '
        Me.lblLRATE.Location = New System.Drawing.Point(15, 94)
        Me.lblLRATE.Name = "lblLRATE"
        Me.lblLRATE.Size = New System.Drawing.Size(99, 23)
        Me.lblLRATE.TabIndex = 15
        Me.lblLRATE.Tag = "lblLRATE"
        Me.lblLRATE.Text = "lblLRATE"
        '
        'txtLRATE
        '
        Me.txtLRATE.Location = New System.Drawing.Point(125, 94)
        Me.txtLRATE.Name = "txtLRATE"
        Me.txtLRATE.Size = New System.Drawing.Size(108, 20)
        Me.txtLRATE.TabIndex = 14
        Me.txtLRATE.Tag = "txtLRATE"
        Me.txtLRATE.Text = "txtLRATE"
        '
        'lblMRATE
        '
        Me.lblMRATE.Location = New System.Drawing.Point(263, 71)
        Me.lblMRATE.Name = "lblMRATE"
        Me.lblMRATE.Size = New System.Drawing.Size(99, 23)
        Me.lblMRATE.TabIndex = 13
        Me.lblMRATE.Tag = "lblMRATE"
        Me.lblMRATE.Text = "lblMRATE"
        '
        'txtMRATE
        '
        Me.txtMRATE.Location = New System.Drawing.Point(373, 71)
        Me.txtMRATE.Name = "txtMRATE"
        Me.txtMRATE.Size = New System.Drawing.Size(108, 20)
        Me.txtMRATE.TabIndex = 12
        Me.txtMRATE.Tag = "txtMRATE"
        Me.txtMRATE.Text = "txtMRATE"
        '
        'lblIRATE
        '
        Me.lblIRATE.Location = New System.Drawing.Point(15, 71)
        Me.lblIRATE.Name = "lblIRATE"
        Me.lblIRATE.Size = New System.Drawing.Size(99, 23)
        Me.lblIRATE.TabIndex = 11
        Me.lblIRATE.Tag = "lblIRATE"
        Me.lblIRATE.Text = "lblIRATE"
        '
        'txtIRATE
        '
        Me.txtIRATE.Location = New System.Drawing.Point(125, 71)
        Me.txtIRATE.Name = "txtIRATE"
        Me.txtIRATE.Size = New System.Drawing.Size(108, 20)
        Me.txtIRATE.TabIndex = 10
        Me.txtIRATE.Tag = "txtIRATE"
        Me.txtIRATE.Text = "txtIRATE"
        '
        'lblTRIGGERPRICE
        '
        Me.lblTRIGGERPRICE.Location = New System.Drawing.Point(263, 45)
        Me.lblTRIGGERPRICE.Name = "lblTRIGGERPRICE"
        Me.lblTRIGGERPRICE.Size = New System.Drawing.Size(99, 23)
        Me.lblTRIGGERPRICE.TabIndex = 9
        Me.lblTRIGGERPRICE.Tag = "lblTRIGGERPRICE"
        Me.lblTRIGGERPRICE.Text = "lblTRIGGERPRICE"
        '
        'txtTRIGGERPRICE
        '
        Me.txtTRIGGERPRICE.Location = New System.Drawing.Point(373, 45)
        Me.txtTRIGGERPRICE.Name = "txtTRIGGERPRICE"
        Me.txtTRIGGERPRICE.Size = New System.Drawing.Size(108, 20)
        Me.txtTRIGGERPRICE.TabIndex = 8
        Me.txtTRIGGERPRICE.Tag = "txtTRIGGERPRICE"
        Me.txtTRIGGERPRICE.Text = "txtTRIGGERPRICE"
        '
        'lblMTPRICE
        '
        Me.lblMTPRICE.Location = New System.Drawing.Point(15, 45)
        Me.lblMTPRICE.Name = "lblMTPRICE"
        Me.lblMTPRICE.Size = New System.Drawing.Size(99, 23)
        Me.lblMTPRICE.TabIndex = 7
        Me.lblMTPRICE.Tag = "lblMTPRICE"
        Me.lblMTPRICE.Text = "lblMTPRICE"
        '
        'txtMTPRICE
        '
        Me.txtMTPRICE.Location = New System.Drawing.Point(125, 45)
        Me.txtMTPRICE.Name = "txtMTPRICE"
        Me.txtMTPRICE.Size = New System.Drawing.Size(108, 20)
        Me.txtMTPRICE.TabIndex = 6
        Me.txtMTPRICE.Tag = "txtMTPRICE"
        Me.txtMTPRICE.Text = "txtMTPRICE"
        '
        'lblMTRATE
        '
        Me.lblMTRATE.Location = New System.Drawing.Point(263, 19)
        Me.lblMTRATE.Name = "lblMTRATE"
        Me.lblMTRATE.Size = New System.Drawing.Size(99, 23)
        Me.lblMTRATE.TabIndex = 5
        Me.lblMTRATE.Tag = "lblMTRATE"
        Me.lblMTRATE.Text = "lblMTRATE"
        '
        'txtMTRATE
        '
        Me.txtMTRATE.Location = New System.Drawing.Point(373, 19)
        Me.txtMTRATE.Name = "txtMTRATE"
        Me.txtMTRATE.Size = New System.Drawing.Size(108, 20)
        Me.txtMTRATE.TabIndex = 4
        Me.txtMTRATE.Tag = "txtMTRATE"
        Me.txtMTRATE.Text = "txtMTRATE"
        '
        'lblREFPRICE
        '
        Me.lblREFPRICE.Location = New System.Drawing.Point(15, 19)
        Me.lblREFPRICE.Name = "lblREFPRICE"
        Me.lblREFPRICE.Size = New System.Drawing.Size(99, 23)
        Me.lblREFPRICE.TabIndex = 3
        Me.lblREFPRICE.Tag = "lblREFPRICE"
        Me.lblREFPRICE.Text = "lblREFPRICE"
        '
        'txtREFPRICE
        '
        Me.txtREFPRICE.Location = New System.Drawing.Point(125, 19)
        Me.txtREFPRICE.Name = "txtREFPRICE"
        Me.txtREFPRICE.Size = New System.Drawing.Size(108, 20)
        Me.txtREFPRICE.TabIndex = 2
        Me.txtREFPRICE.Tag = "txtREFPRICE"
        Me.txtREFPRICE.Text = "txtREFPRICE"
        '
        'grbNOTE
        '
        Me.grbNOTE.Controls.Add(Me.lblDESCRIPTION)
        Me.grbNOTE.Controls.Add(Me.txtDESCRIPTION)
        Me.grbNOTE.Controls.Add(Me.lblREF)
        Me.grbNOTE.Controls.Add(Me.txtREF)
        Me.grbNOTE.Location = New System.Drawing.Point(27, 256)
        Me.grbNOTE.Name = "grbNOTE"
        Me.grbNOTE.Size = New System.Drawing.Size(497, 93)
        Me.grbNOTE.TabIndex = 2
        Me.grbNOTE.TabStop = False
        Me.grbNOTE.Tag = "grbNOTE"
        Me.grbNOTE.Text = "grbNOTE"
        '
        'lblDESCRIPTION
        '
        Me.lblDESCRIPTION.Location = New System.Drawing.Point(14, 45)
        Me.lblDESCRIPTION.Name = "lblDESCRIPTION"
        Me.lblDESCRIPTION.Size = New System.Drawing.Size(104, 23)
        Me.lblDESCRIPTION.TabIndex = 19
        Me.lblDESCRIPTION.Tag = "lblDESCRIPTION"
        Me.lblDESCRIPTION.Text = "lblDESCRIPTION"
        '
        'txtDESCRIPTION
        '
        Me.txtDESCRIPTION.Location = New System.Drawing.Point(124, 45)
        Me.txtDESCRIPTION.Name = "txtDESCRIPTION"
        Me.txtDESCRIPTION.Size = New System.Drawing.Size(356, 20)
        Me.txtDESCRIPTION.TabIndex = 18
        Me.txtDESCRIPTION.Tag = "txtDESCRIPTION"
        Me.txtDESCRIPTION.Text = "txtDESCRIPTION"
        '
        'lblREF
        '
        Me.lblREF.Location = New System.Drawing.Point(14, 19)
        Me.lblREF.Name = "lblREF"
        Me.lblREF.Size = New System.Drawing.Size(104, 23)
        Me.lblREF.TabIndex = 17
        Me.lblREF.Tag = "lblREF"
        Me.lblREF.Text = "lblREF"
        '
        'txtREF
        '
        Me.txtREF.Location = New System.Drawing.Point(124, 19)
        Me.txtREF.Name = "txtREF"
        Me.txtREF.Size = New System.Drawing.Size(356, 20)
        Me.txtREF.TabIndex = 16
        Me.txtREF.Tag = "txtREF"
        Me.txtREF.Text = "txtREF"
        '
        'btnSUBMIT
        '
        Me.btnSUBMIT.Location = New System.Drawing.Point(368, 358)
        Me.btnSUBMIT.Name = "btnSUBMIT"
        Me.btnSUBMIT.Size = New System.Drawing.Size(75, 23)
        Me.btnSUBMIT.TabIndex = 3
        Me.btnSUBMIT.Tag = "btnSUBMIT"
        Me.btnSUBMIT.Text = "btnSUBMIT"
        Me.btnSUBMIT.UseVisualStyleBackColor = True
        '
        'btnCANCEL
        '
        Me.btnCANCEL.Location = New System.Drawing.Point(449, 358)
        Me.btnCANCEL.Name = "btnCANCEL"
        Me.btnCANCEL.Size = New System.Drawing.Size(75, 23)
        Me.btnCANCEL.TabIndex = 4
        Me.btnCANCEL.Tag = "btnCANCEL"
        Me.btnCANCEL.Text = "btnCANCEL"
        Me.btnCANCEL.UseVisualStyleBackColor = True
        '
        'frmMTDEAL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(548, 393)
        Me.Controls.Add(Me.btnCANCEL)
        Me.Controls.Add(Me.btnSUBMIT)
        Me.Controls.Add(Me.grbNOTE)
        Me.Controls.Add(Me.grpPrice)
        Me.Controls.Add(Me.grbInfo)
        Me.Name = "frmMTDEAL"
        Me.Text = "frmMTDEAL"
        Me.grbInfo.ResumeLayout(False)
        Me.grbInfo.PerformLayout()
        Me.grpPrice.ResumeLayout(False)
        Me.grpPrice.PerformLayout()
        Me.grbNOTE.ResumeLayout(False)
        Me.grbNOTE.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grbInfo As System.Windows.Forms.GroupBox
    Friend WithEvents lblSYMBOL As System.Windows.Forms.Label
    Friend WithEvents cboSYMBOL As System.Windows.Forms.ComboBox
    Friend WithEvents lblMTTYPE As System.Windows.Forms.Label
    Friend WithEvents txtMTTYPE As System.Windows.Forms.TextBox
    Friend WithEvents lblAFACCTNO As System.Windows.Forms.Label
    Friend WithEvents txtAFACCTNO As System.Windows.Forms.TextBox
    Friend WithEvents grpPrice As System.Windows.Forms.GroupBox
    Friend WithEvents lblSecInfo As System.Windows.Forms.Label
    Friend WithEvents lblQTTY As System.Windows.Forms.Label
    Friend WithEvents txtQTTY As System.Windows.Forms.TextBox
    Friend WithEvents lblLRATE As System.Windows.Forms.Label
    Friend WithEvents txtLRATE As System.Windows.Forms.TextBox
    Friend WithEvents lblMRATE As System.Windows.Forms.Label
    Friend WithEvents txtMRATE As System.Windows.Forms.TextBox
    Friend WithEvents lblIRATE As System.Windows.Forms.Label
    Friend WithEvents txtIRATE As System.Windows.Forms.TextBox
    Friend WithEvents lblTRIGGERPRICE As System.Windows.Forms.Label
    Friend WithEvents txtTRIGGERPRICE As System.Windows.Forms.TextBox
    Friend WithEvents lblMTPRICE As System.Windows.Forms.Label
    Friend WithEvents txtMTPRICE As System.Windows.Forms.TextBox
    Friend WithEvents lblMTRATE As System.Windows.Forms.Label
    Friend WithEvents txtMTRATE As System.Windows.Forms.TextBox
    Friend WithEvents lblREFPRICE As System.Windows.Forms.Label
    Friend WithEvents txtREFPRICE As System.Windows.Forms.TextBox
    Friend WithEvents grbNOTE As System.Windows.Forms.GroupBox
    Friend WithEvents lblREF As System.Windows.Forms.Label
    Friend WithEvents txtREF As System.Windows.Forms.TextBox
    Friend WithEvents lblDESCRIPTION As System.Windows.Forms.Label
    Friend WithEvents txtDESCRIPTION As System.Windows.Forms.TextBox
    Friend WithEvents btnSUBMIT As System.Windows.Forms.Button
    Friend WithEvents btnCANCEL As System.Windows.Forms.Button
End Class
