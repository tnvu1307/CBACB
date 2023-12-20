<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUpdateReRev
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
        Me.txtRate = New System.Windows.Forms.TextBox
        Me.lblRate = New System.Windows.Forms.Label
        Me.btnChange = New System.Windows.Forms.Button
        Me.lblpercent = New System.Windows.Forms.Label
        Me.grbGroup = New System.Windows.Forms.GroupBox
        Me.rbGroup = New System.Windows.Forms.RadioButton
        Me.rbRemiser = New System.Windows.Forms.RadioButton
        Me.txtSearch = New System.Windows.Forms.TextBox
        Me.btnSearch = New System.Windows.Forms.Button
        Me.ckAll = New System.Windows.Forms.CheckBox
        Me.grbRemiser.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.grbGroup.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbRemiser
        '
        Me.grbRemiser.Controls.Add(Me.ckAll)
        Me.grbRemiser.Controls.Add(Me.pnlRemiser)
        Me.grbRemiser.Location = New System.Drawing.Point(12, 132)
        Me.grbRemiser.Name = "grbRemiser"
        Me.grbRemiser.Size = New System.Drawing.Size(746, 308)
        Me.grbRemiser.TabIndex = 0
        Me.grbRemiser.TabStop = False
        Me.grbRemiser.Tag = "grbRemiser"
        Me.grbRemiser.Text = "grbRemiser"
        '
        'pnlRemiser
        '
        Me.pnlRemiser.Location = New System.Drawing.Point(9, 40)
        Me.pnlRemiser.Name = "pnlRemiser"
        Me.pnlRemiser.Size = New System.Drawing.Size(728, 262)
        Me.pnlRemiser.TabIndex = 0
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(674, 446)
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
        'txtRate
        '
        Me.txtRate.Location = New System.Drawing.Point(534, 74)
        Me.txtRate.Name = "txtRate"
        Me.txtRate.Size = New System.Drawing.Size(113, 20)
        Me.txtRate.TabIndex = 4
        Me.txtRate.Text = "txtRate"
        '
        'lblRate
        '
        Me.lblRate.Location = New System.Drawing.Point(425, 75)
        Me.lblRate.Name = "lblRate"
        Me.lblRate.Size = New System.Drawing.Size(101, 19)
        Me.lblRate.TabIndex = 5
        Me.lblRate.Tag = "lblRate"
        Me.lblRate.Text = "lblRate"
        '
        'btnChange
        '
        Me.btnChange.Location = New System.Drawing.Point(682, 73)
        Me.btnChange.Name = "btnChange"
        Me.btnChange.Size = New System.Drawing.Size(77, 25)
        Me.btnChange.TabIndex = 6
        Me.btnChange.Tag = "btnChange"
        Me.btnChange.Text = "btnChange"
        Me.btnChange.UseVisualStyleBackColor = True
        '
        'lblpercent
        '
        Me.lblpercent.AutoSize = True
        Me.lblpercent.Location = New System.Drawing.Point(651, 77)
        Me.lblpercent.Name = "lblpercent"
        Me.lblpercent.Size = New System.Drawing.Size(15, 13)
        Me.lblpercent.TabIndex = 7
        Me.lblpercent.Tag = "lblpercent"
        Me.lblpercent.Text = "%"
        '
        'grbGroup
        '
        Me.grbGroup.Controls.Add(Me.rbGroup)
        Me.grbGroup.Controls.Add(Me.rbRemiser)
        Me.grbGroup.Location = New System.Drawing.Point(24, 56)
        Me.grbGroup.Name = "grbGroup"
        Me.grbGroup.Size = New System.Drawing.Size(164, 42)
        Me.grbGroup.TabIndex = 8
        Me.grbGroup.TabStop = False
        Me.grbGroup.Tag = "grbGroup"
        Me.grbGroup.Text = "grbGroup"
        '
        'rbGroup
        '
        Me.rbGroup.AutoSize = True
        Me.rbGroup.Location = New System.Drawing.Point(91, 18)
        Me.rbGroup.Name = "rbGroup"
        Me.rbGroup.Size = New System.Drawing.Size(63, 17)
        Me.rbGroup.TabIndex = 1
        Me.rbGroup.Tag = "rbGroup"
        Me.rbGroup.Text = "rbGroup"
        Me.rbGroup.UseVisualStyleBackColor = True
        '
        'rbRemiser
        '
        Me.rbRemiser.AutoSize = True
        Me.rbRemiser.Checked = True
        Me.rbRemiser.Location = New System.Drawing.Point(13, 19)
        Me.rbRemiser.Name = "rbRemiser"
        Me.rbRemiser.Size = New System.Drawing.Size(72, 17)
        Me.rbRemiser.TabIndex = 0
        Me.rbRemiser.TabStop = True
        Me.rbRemiser.Tag = "rbRemiser"
        Me.rbRemiser.Text = "rbRemiser"
        Me.rbRemiser.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(24, 103)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(265, 20)
        Me.txtSearch.TabIndex = 9
        Me.txtSearch.Tag = "txtSearch"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(297, 100)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(77, 25)
        Me.btnSearch.TabIndex = 10
        Me.btnSearch.Tag = "btnSearch"
        Me.btnSearch.Text = "btnSearch"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'ckAll
        '
        Me.ckAll.AutoSize = True
        Me.ckAll.Location = New System.Drawing.Point(31, 19)
        Me.ckAll.Name = "ckAll"
        Me.ckAll.Size = New System.Drawing.Size(37, 17)
        Me.ckAll.TabIndex = 1
        Me.ckAll.Tag = "ckAll"
        Me.ckAll.Text = "All"
        Me.ckAll.UseVisualStyleBackColor = True
        '
        'frmUpdateReRev
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(789, 487)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.grbGroup)
        Me.Controls.Add(Me.lblpercent)
        Me.Controls.Add(Me.btnChange)
        Me.Controls.Add(Me.lblRate)
        Me.Controls.Add(Me.txtRate)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.grbRemiser)
        Me.KeyPreview = True
        Me.Name = "frmUpdateReRev"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmUpdateReRev"
        Me.grbRemiser.ResumeLayout(False)
        Me.grbRemiser.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.grbGroup.ResumeLayout(False)
        Me.grbGroup.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grbRemiser As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents pnlRemiser As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblCaption As System.Windows.Forms.Label
    Friend WithEvents txtRate As System.Windows.Forms.TextBox
    Friend WithEvents lblRate As System.Windows.Forms.Label
    Friend WithEvents btnChange As System.Windows.Forms.Button
    Friend WithEvents lblpercent As System.Windows.Forms.Label
    Friend WithEvents grbGroup As System.Windows.Forms.GroupBox
    Friend WithEvents rbGroup As System.Windows.Forms.RadioButton
    Friend WithEvents rbRemiser As System.Windows.Forms.RadioButton
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents ckAll As System.Windows.Forms.CheckBox
End Class
