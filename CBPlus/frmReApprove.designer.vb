<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReApprove
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
        Me.grbRemiser = New System.Windows.Forms.GroupBox
        Me.pnlRemiser = New System.Windows.Forms.Panel
        Me.btnCancel = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblCaption = New System.Windows.Forms.Label
        Me.btnChange = New System.Windows.Forms.Button
        Me.btnSearch = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.txtSearch = New System.Windows.Forms.TextBox
        Me.ckAll = New System.Windows.Forms.CheckBox
        Me.grbRemiser.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbRemiser
        '
        Me.grbRemiser.Controls.Add(Me.ckAll)
        Me.grbRemiser.Controls.Add(Me.pnlRemiser)
        Me.grbRemiser.Location = New System.Drawing.Point(12, 92)
        Me.grbRemiser.Name = "grbRemiser"
        Me.grbRemiser.Size = New System.Drawing.Size(765, 365)
        Me.grbRemiser.TabIndex = 0
        Me.grbRemiser.TabStop = False
        Me.grbRemiser.Tag = "grbRemiser"
        Me.grbRemiser.Text = "grbRemiser"
        '
        'pnlRemiser
        '
        Me.pnlRemiser.Location = New System.Drawing.Point(9, 41)
        Me.pnlRemiser.Name = "pnlRemiser"
        Me.pnlRemiser.Size = New System.Drawing.Size(750, 261)
        Me.pnlRemiser.TabIndex = 0
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(138, 446)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(78, 25)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Tag = "btnCancel"
        Me.btnCancel.Text = "btnCancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.Controls.Add(Me.lblCaption)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(789, 50)
        Me.Panel1.TabIndex = 3
        '
        'lblCaption
        '
        Me.lblCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaption.Location = New System.Drawing.Point(8, 16)
        Me.lblCaption.Name = "lblCaption"
        Me.lblCaption.Size = New System.Drawing.Size(776, 16)
        Me.lblCaption.TabIndex = 0
        Me.lblCaption.Tag = "lblCaption"
        Me.lblCaption.Text = "lblCaption"
        '
        'btnChange
        '
        Me.btnChange.Location = New System.Drawing.Point(21, 446)
        Me.btnChange.Name = "btnChange"
        Me.btnChange.Size = New System.Drawing.Size(77, 25)
        Me.btnChange.TabIndex = 6
        Me.btnChange.Tag = "btnChange"
        Me.btnChange.Text = "btnChange"
        Me.btnChange.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(379, 61)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(77, 25)
        Me.btnSearch.TabIndex = 11
        Me.btnSearch.Tag = "btnSearch"
        Me.btnSearch.Text = "btnSearch"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(693, 450)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(78, 25)
        Me.btnClose.TabIndex = 12
        Me.btnClose.Tag = "btnClose"
        Me.btnClose.Text = "btnClose"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(26, 63)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(340, 20)
        Me.txtSearch.TabIndex = 1
        Me.txtSearch.Tag = "txtSearch"
        '
        'ckAll
        '
        Me.ckAll.AutoSize = True
        Me.ckAll.Location = New System.Drawing.Point(31, 19)
        Me.ckAll.Name = "ckAll"
        Me.ckAll.Size = New System.Drawing.Size(37, 17)
        Me.ckAll.TabIndex = 17
        Me.ckAll.Tag = "ckAll"
        Me.ckAll.Text = "All"
        Me.ckAll.UseVisualStyleBackColor = True
        '
        'frmReApprove
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(789, 487)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.btnChange)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.grbRemiser)
        Me.KeyPreview = True
        Me.Name = "frmReApprove"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "frmReApprove"
        Me.Text = "frmReApprove"
        Me.grbRemiser.ResumeLayout(False)
        Me.grbRemiser.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grbRemiser As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents pnlRemiser As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblCaption As System.Windows.Forms.Label
    Friend WithEvents btnChange As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents ckAll As System.Windows.Forms.CheckBox
End Class
