<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSMSEMAIL
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSMSEMAIL))
        Me.btnSent = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.lblTYPESMS = New System.Windows.Forms.Label
        Me.lblLISTPHONE = New System.Windows.Forms.Label
        Me.lblDESC = New System.Windows.Forms.Label
        Me.txtDESC = New System.Windows.Forms.TextBox
        Me.cboTYPESMS = New AppCore.ComboBoxEx
        Me.txtBROWSER = New System.Windows.Forms.TextBox
        Me.btnBROWSER = New System.Windows.Forms.Button
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.dtpRETURNTRADE = New System.Windows.Forms.DateTimePicker
        Me.dtpTODATE = New System.Windows.Forms.DateTimePicker
        Me.dtpFRMDATE = New System.Windows.Forms.DateTimePicker
        Me.lblRETURNTRADE = New System.Windows.Forms.Label
        Me.lblTODATE = New System.Windows.Forms.Label
        Me.lblFROMDATE = New System.Windows.Forms.Label
        Me.chkSYSTEMSMS = New System.Windows.Forms.CheckBox
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSent
        '
        Me.btnSent.Location = New System.Drawing.Point(434, 293)
        Me.btnSent.Name = "btnSent"
        Me.btnSent.Size = New System.Drawing.Size(119, 30)
        Me.btnSent.TabIndex = 17
        Me.btnSent.Tag = "btnSent"
        Me.btnSent.Text = "btnSent"
        Me.btnSent.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(581, 294)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(119, 30)
        Me.btnCancel.TabIndex = 17
        Me.btnCancel.Tag = "btnCancel"
        Me.btnCancel.Text = "btnCancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lblTYPESMS
        '
        Me.lblTYPESMS.AutoSize = True
        Me.lblTYPESMS.Location = New System.Drawing.Point(28, 22)
        Me.lblTYPESMS.Name = "lblTYPESMS"
        Me.lblTYPESMS.Size = New System.Drawing.Size(68, 13)
        Me.lblTYPESMS.TabIndex = 0
        Me.lblTYPESMS.Tag = "lblTYPESMS"
        Me.lblTYPESMS.Text = "lblTYPESMS"
        '
        'lblLISTPHONE
        '
        Me.lblLISTPHONE.AutoSize = True
        Me.lblLISTPHONE.Location = New System.Drawing.Point(28, 56)
        Me.lblLISTPHONE.Name = "lblLISTPHONE"
        Me.lblLISTPHONE.Size = New System.Drawing.Size(78, 13)
        Me.lblLISTPHONE.TabIndex = 0
        Me.lblLISTPHONE.Tag = "lblLISTPHONE"
        Me.lblLISTPHONE.Text = "lblLISTPHONE"
        '
        'lblDESC
        '
        Me.lblDESC.AutoSize = True
        Me.lblDESC.Location = New System.Drawing.Point(28, 133)
        Me.lblDESC.Name = "lblDESC"
        Me.lblDESC.Size = New System.Drawing.Size(46, 13)
        Me.lblDESC.TabIndex = 0
        Me.lblDESC.Tag = "lblDESC"
        Me.lblDESC.Text = "lblDESC"
        '
        'txtDESC
        '
        Me.txtDESC.Enabled = False
        Me.txtDESC.Location = New System.Drawing.Point(127, 136)
        Me.txtDESC.Multiline = True
        Me.txtDESC.Name = "txtDESC"
        Me.txtDESC.Size = New System.Drawing.Size(571, 135)
        Me.txtDESC.TabIndex = 3
        Me.txtDESC.Tag = "DESC"
        '
        'cboTYPESMS
        '
        Me.cboTYPESMS.DisplayMember = "DISPLAY"
        Me.cboTYPESMS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTYPESMS.Location = New System.Drawing.Point(127, 19)
        Me.cboTYPESMS.Name = "cboTYPESMS"
        Me.cboTYPESMS.Size = New System.Drawing.Size(393, 21)
        Me.cboTYPESMS.TabIndex = 30
        Me.cboTYPESMS.Tag = "TYPESMS"
        Me.cboTYPESMS.ValueMember = "VALUE"
        '
        'txtBROWSER
        '
        Me.txtBROWSER.Enabled = False
        Me.txtBROWSER.Location = New System.Drawing.Point(127, 53)
        Me.txtBROWSER.Name = "txtBROWSER"
        Me.txtBROWSER.Size = New System.Drawing.Size(393, 20)
        Me.txtBROWSER.TabIndex = 31
        Me.txtBROWSER.Tag = "BROWSER"
        '
        'btnBROWSER
        '
        Me.btnBROWSER.Location = New System.Drawing.Point(575, 43)
        Me.btnBROWSER.Name = "btnBROWSER"
        Me.btnBROWSER.Size = New System.Drawing.Size(101, 30)
        Me.btnBROWSER.TabIndex = 32
        Me.btnBROWSER.Tag = "btnBROWSER"
        Me.btnBROWSER.Text = "btnBROWSER"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.chkSYSTEMSMS)
        Me.Panel2.Controls.Add(Me.dtpRETURNTRADE)
        Me.Panel2.Controls.Add(Me.dtpTODATE)
        Me.Panel2.Controls.Add(Me.dtpFRMDATE)
        Me.Panel2.Controls.Add(Me.lblRETURNTRADE)
        Me.Panel2.Controls.Add(Me.btnBROWSER)
        Me.Panel2.Controls.Add(Me.txtBROWSER)
        Me.Panel2.Controls.Add(Me.cboTYPESMS)
        Me.Panel2.Controls.Add(Me.txtDESC)
        Me.Panel2.Controls.Add(Me.lblDESC)
        Me.Panel2.Controls.Add(Me.lblTODATE)
        Me.Panel2.Controls.Add(Me.lblFROMDATE)
        Me.Panel2.Controls.Add(Me.lblLISTPHONE)
        Me.Panel2.Controls.Add(Me.lblTYPESMS)
        Me.Panel2.Location = New System.Drawing.Point(2, 1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(715, 281)
        Me.Panel2.TabIndex = 16
        '
        'dtpRETURNTRADE
        '
        Me.dtpRETURNTRADE.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpRETURNTRADE.Location = New System.Drawing.Point(575, 81)
        Me.dtpRETURNTRADE.Name = "dtpRETURNTRADE"
        Me.dtpRETURNTRADE.Size = New System.Drawing.Size(99, 20)
        Me.dtpRETURNTRADE.TabIndex = 36
        Me.dtpRETURNTRADE.Value = New Date(2013, 11, 13, 0, 0, 0, 0)
        '
        'dtpTODATE
        '
        Me.dtpTODATE.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTODATE.Location = New System.Drawing.Point(325, 81)
        Me.dtpTODATE.Name = "dtpTODATE"
        Me.dtpTODATE.Size = New System.Drawing.Size(99, 20)
        Me.dtpTODATE.TabIndex = 35
        Me.dtpTODATE.Value = New Date(2013, 11, 13, 0, 0, 0, 0)
        '
        'dtpFRMDATE
        '
        Me.dtpFRMDATE.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFRMDATE.Location = New System.Drawing.Point(127, 81)
        Me.dtpFRMDATE.Name = "dtpFRMDATE"
        Me.dtpFRMDATE.Size = New System.Drawing.Size(99, 20)
        Me.dtpFRMDATE.TabIndex = 34
        Me.dtpFRMDATE.Value = New Date(2013, 11, 13, 0, 0, 0, 0)
        '
        'lblRETURNTRADE
        '
        Me.lblRETURNTRADE.AutoSize = True
        Me.lblRETURNTRADE.Location = New System.Drawing.Point(443, 83)
        Me.lblRETURNTRADE.Name = "lblRETURNTRADE"
        Me.lblRETURNTRADE.Size = New System.Drawing.Size(100, 13)
        Me.lblRETURNTRADE.TabIndex = 33
        Me.lblRETURNTRADE.Tag = "lblRETURNTRADE"
        Me.lblRETURNTRADE.Text = "lblRETURNTRADE"
        '
        'lblTODATE
        '
        Me.lblTODATE.AutoSize = True
        Me.lblTODATE.Location = New System.Drawing.Point(246, 81)
        Me.lblTODATE.Name = "lblTODATE"
        Me.lblTODATE.Size = New System.Drawing.Size(61, 13)
        Me.lblTODATE.TabIndex = 0
        Me.lblTODATE.Tag = "lblTODATE"
        Me.lblTODATE.Text = "lblTODATE"
        '
        'lblFROMDATE
        '
        Me.lblFROMDATE.AutoSize = True
        Me.lblFROMDATE.Location = New System.Drawing.Point(28, 79)
        Me.lblFROMDATE.Name = "lblFROMDATE"
        Me.lblFROMDATE.Size = New System.Drawing.Size(77, 13)
        Me.lblFROMDATE.TabIndex = 0
        Me.lblFROMDATE.Tag = "lblFROMDATE"
        Me.lblFROMDATE.Text = "lblFROMDATE"
        '
        'chkSYSTEMSMS
        '
        Me.chkSYSTEMSMS.AutoSize = True
        Me.chkSYSTEMSMS.Location = New System.Drawing.Point(128, 107)
        Me.chkSYSTEMSMS.Name = "chkSYSTEMSMS"
        Me.chkSYSTEMSMS.Size = New System.Drawing.Size(118, 21)
        Me.chkSYSTEMSMS.TabIndex = 37
        Me.chkSYSTEMSMS.Tag = "chkSYSTEMSMS"
        Me.chkSYSTEMSMS.Text = "chkSYSTEMSMS"
        Me.chkSYSTEMSMS.UseVisualStyleBackColor = True
        '
        'frmSMSEMAIL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(719, 327)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSent)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmSMSEMAIL"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.Text = "frmSMSEMAIL"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnSent As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblTYPESMS As System.Windows.Forms.Label
    Friend WithEvents lblLISTPHONE As System.Windows.Forms.Label
    Friend WithEvents lblDESC As System.Windows.Forms.Label
    Friend WithEvents txtDESC As System.Windows.Forms.TextBox
    Friend WithEvents cboTYPESMS As AppCore.ComboBoxEx
    Friend WithEvents txtBROWSER As System.Windows.Forms.TextBox
    Friend WithEvents btnBROWSER As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents dtpTODATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFRMDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblRETURNTRADE As System.Windows.Forms.Label
    Friend WithEvents lblTODATE As System.Windows.Forms.Label
    Friend WithEvents lblFROMDATE As System.Windows.Forms.Label
    Friend WithEvents dtpRETURNTRADE As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkSYSTEMSMS As System.Windows.Forms.CheckBox
End Class
