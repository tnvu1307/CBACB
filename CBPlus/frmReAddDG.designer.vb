<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReAddDG
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
        Me.ckAll = New System.Windows.Forms.CheckBox
        Me.pnlRemiser = New System.Windows.Forms.Panel
        Me.btnCancel = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblCaption = New System.Windows.Forms.Label
        Me.btnChange = New System.Windows.Forms.Button
        Me.mskReAcctno = New System.Windows.Forms.MaskedTextBox
        Me.lblReAcctno = New System.Windows.Forms.Label
        Me.lblReName = New System.Windows.Forms.Label
        Me.mskReDG = New System.Windows.Forms.MaskedTextBox
        Me.lblDGname = New System.Windows.Forms.Label
        Me.lblReDG = New System.Windows.Forms.Label
        Me.dtpFromDate = New System.Windows.Forms.DateTimePicker
        Me.dtpToDate = New System.Windows.Forms.DateTimePicker
        Me.lblFromDate = New System.Windows.Forms.Label
        Me.lblToDate = New System.Windows.Forms.Label
        Me.txtSearch = New System.Windows.Forms.TextBox
        Me.btnSearch = New System.Windows.Forms.Button
        Me.lblReDGCareby = New System.Windows.Forms.Label
        Me.lblDGCarebyname = New System.Windows.Forms.Label
        Me.mskReCarebyDG = New System.Windows.Forms.MaskedTextBox
        Me.grbRemiser.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbRemiser
        '
        Me.grbRemiser.Controls.Add(Me.ckAll)
        Me.grbRemiser.Controls.Add(Me.pnlRemiser)
        Me.grbRemiser.Location = New System.Drawing.Point(12, 167)
        Me.grbRemiser.Name = "grbRemiser"
        Me.grbRemiser.Size = New System.Drawing.Size(765, 316)
        Me.grbRemiser.TabIndex = 0
        Me.grbRemiser.TabStop = False
        Me.grbRemiser.Tag = "grbRemiser"
        Me.grbRemiser.Text = "grbRemiser"
        '
        'ckAll
        '
        Me.ckAll.AutoSize = True
        Me.ckAll.Location = New System.Drawing.Point(31, 19)
        Me.ckAll.Name = "ckAll"
        Me.ckAll.Size = New System.Drawing.Size(37, 17)
        Me.ckAll.TabIndex = 8
        Me.ckAll.Tag = "ckAll"
        Me.ckAll.Text = "All"
        Me.ckAll.UseVisualStyleBackColor = True
        '
        'pnlRemiser
        '
        Me.pnlRemiser.Location = New System.Drawing.Point(9, 44)
        Me.pnlRemiser.Name = "pnlRemiser"
        Me.pnlRemiser.Size = New System.Drawing.Size(750, 263)
        Me.pnlRemiser.TabIndex = 0
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(691, 489)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(78, 25)
        Me.btnCancel.TabIndex = 15
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
        Me.btnChange.Location = New System.Drawing.Point(595, 489)
        Me.btnChange.Name = "btnChange"
        Me.btnChange.Size = New System.Drawing.Size(77, 25)
        Me.btnChange.TabIndex = 16
        Me.btnChange.Tag = "btnChange"
        Me.btnChange.Text = "btnChange"
        Me.btnChange.UseVisualStyleBackColor = True
        '
        'mskReAcctno
        '
        Me.mskReAcctno.Location = New System.Drawing.Point(162, 64)
        Me.mskReAcctno.Name = "mskReAcctno"
        Me.mskReAcctno.Size = New System.Drawing.Size(119, 20)
        Me.mskReAcctno.TabIndex = 1
        Me.mskReAcctno.Tag = "mskReAcctno"
        Me.mskReAcctno.Text = "mskReAcctno"
        '
        'lblReAcctno
        '
        Me.lblReAcctno.Location = New System.Drawing.Point(9, 65)
        Me.lblReAcctno.Name = "lblReAcctno"
        Me.lblReAcctno.Size = New System.Drawing.Size(117, 28)
        Me.lblReAcctno.TabIndex = 9
        Me.lblReAcctno.Tag = "lblReAcctno"
        Me.lblReAcctno.Text = "lblReAcctno"
        '
        'lblReName
        '
        Me.lblReName.AutoSize = True
        Me.lblReName.Location = New System.Drawing.Point(287, 67)
        Me.lblReName.Name = "lblReName"
        Me.lblReName.Size = New System.Drawing.Size(59, 13)
        Me.lblReName.TabIndex = 10
        Me.lblReName.Tag = "lblReName"
        Me.lblReName.Text = "lblReName"
        '
        'mskReDG
        '
        Me.mskReDG.Location = New System.Drawing.Point(162, 103)
        Me.mskReDG.Name = "mskReDG"
        Me.mskReDG.Size = New System.Drawing.Size(119, 20)
        Me.mskReDG.TabIndex = 4
        Me.mskReDG.Tag = "mskReDG"
        Me.mskReDG.Text = "mskReDG"
        '
        'lblDGname
        '
        Me.lblDGname.AutoSize = True
        Me.lblDGname.Location = New System.Drawing.Point(287, 106)
        Me.lblDGname.Name = "lblDGname"
        Me.lblDGname.Size = New System.Drawing.Size(59, 13)
        Me.lblDGname.TabIndex = 12
        Me.lblDGname.Tag = "lblDGname"
        Me.lblDGname.Text = "lblDGname"
        '
        'lblReDG
        '
        Me.lblReDG.Location = New System.Drawing.Point(9, 104)
        Me.lblReDG.Name = "lblReDG"
        Me.lblReDG.Size = New System.Drawing.Size(147, 20)
        Me.lblReDG.TabIndex = 13
        Me.lblReDG.Tag = "lblReDG"
        Me.lblReDG.Text = "lblReDG"
        '
        'dtpFromDate
        '
        Me.dtpFromDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFromDate.Location = New System.Drawing.Point(162, 136)
        Me.dtpFromDate.Name = "dtpFromDate"
        Me.dtpFromDate.Size = New System.Drawing.Size(119, 20)
        Me.dtpFromDate.TabIndex = 6
        Me.dtpFromDate.Tag = "dtpFromDate"
        Me.dtpFromDate.Value = New Date(2006, 10, 30, 0, 0, 0, 0)
        '
        'dtpToDate
        '
        Me.dtpToDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpToDate.Location = New System.Drawing.Point(572, 136)
        Me.dtpToDate.Name = "dtpToDate"
        Me.dtpToDate.Size = New System.Drawing.Size(119, 20)
        Me.dtpToDate.TabIndex = 7
        Me.dtpToDate.Tag = "dtpToDate"
        Me.dtpToDate.Value = New Date(2006, 10, 30, 0, 0, 0, 0)
        '
        'lblFromDate
        '
        Me.lblFromDate.AutoSize = True
        Me.lblFromDate.Location = New System.Drawing.Point(8, 136)
        Me.lblFromDate.Name = "lblFromDate"
        Me.lblFromDate.Size = New System.Drawing.Size(63, 13)
        Me.lblFromDate.TabIndex = 14
        Me.lblFromDate.Tag = "lblFromDate"
        Me.lblFromDate.Text = "lblFromDate"
        '
        'lblToDate
        '
        Me.lblToDate.AutoSize = True
        Me.lblToDate.Location = New System.Drawing.Point(472, 136)
        Me.lblToDate.Name = "lblToDate"
        Me.lblToDate.Size = New System.Drawing.Size(53, 13)
        Me.lblToDate.TabIndex = 15
        Me.lblToDate.Tag = "lblToDate"
        Me.lblToDate.Text = "lblToDate"
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(475, 62)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(216, 20)
        Me.txtSearch.TabIndex = 2
        Me.txtSearch.Tag = "txtSearch"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(694, 62)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(77, 25)
        Me.btnSearch.TabIndex = 3
        Me.btnSearch.Tag = "btnSearch"
        Me.btnSearch.Text = "btnSearch"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'lblReDGCareby
        '
        Me.lblReDGCareby.Location = New System.Drawing.Point(472, 104)
        Me.lblReDGCareby.Name = "lblReDGCareby"
        Me.lblReDGCareby.Size = New System.Drawing.Size(96, 20)
        Me.lblReDGCareby.TabIndex = 18
        Me.lblReDGCareby.Tag = "lblReDGCareby"
        Me.lblReDGCareby.Text = "lblReDGCareby"
        '
        'lblDGCarebyname
        '
        Me.lblDGCarebyname.AutoSize = True
        Me.lblDGCarebyname.Location = New System.Drawing.Point(696, 107)
        Me.lblDGCarebyname.Name = "lblDGCarebyname"
        Me.lblDGCarebyname.Size = New System.Drawing.Size(92, 13)
        Me.lblDGCarebyname.TabIndex = 17
        Me.lblDGCarebyname.Tag = "lblDGCarebyname"
        Me.lblDGCarebyname.Text = "lblDGCarebyname"
        '
        'mskReCarebyDG
        '
        Me.mskReCarebyDG.Location = New System.Drawing.Point(572, 104)
        Me.mskReCarebyDG.Name = "mskReCarebyDG"
        Me.mskReCarebyDG.Size = New System.Drawing.Size(119, 20)
        Me.mskReCarebyDG.TabIndex = 5
        Me.mskReCarebyDG.Tag = "mskReCarebyDG"
        Me.mskReCarebyDG.Text = "mskReCarebyDG"
        '
        'frmReAddDG
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(789, 526)
        Me.Controls.Add(Me.lblReDGCareby)
        Me.Controls.Add(Me.lblDGCarebyname)
        Me.Controls.Add(Me.mskReCarebyDG)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.lblToDate)
        Me.Controls.Add(Me.lblFromDate)
        Me.Controls.Add(Me.dtpToDate)
        Me.Controls.Add(Me.dtpFromDate)
        Me.Controls.Add(Me.lblReDG)
        Me.Controls.Add(Me.lblDGname)
        Me.Controls.Add(Me.mskReDG)
        Me.Controls.Add(Me.lblReName)
        Me.Controls.Add(Me.lblReAcctno)
        Me.Controls.Add(Me.mskReAcctno)
        Me.Controls.Add(Me.btnChange)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.grbRemiser)
        Me.KeyPreview = True
        Me.Name = "frmReAddDG"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "frmReAddDG"
        Me.Text = "frmReAddDG"
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
    Friend WithEvents mskReAcctno As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblReAcctno As System.Windows.Forms.Label
    Friend WithEvents lblReName As System.Windows.Forms.Label
    Friend WithEvents mskReDG As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblDGname As System.Windows.Forms.Label
    Friend WithEvents lblReDG As System.Windows.Forms.Label
    Friend WithEvents dtpFromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFromDate As System.Windows.Forms.Label
    Friend WithEvents lblToDate As System.Windows.Forms.Label
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents ckAll As System.Windows.Forms.CheckBox
    Friend WithEvents lblReDGCareby As System.Windows.Forms.Label
    Friend WithEvents lblDGCarebyname As System.Windows.Forms.Label
    Friend WithEvents mskReCarebyDG As System.Windows.Forms.MaskedTextBox
End Class
