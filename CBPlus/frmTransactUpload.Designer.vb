<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTransactUpload
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTransactUpload))
        Me.grbMaintain = New System.Windows.Forms.GroupBox
        Me.btnRead = New System.Windows.Forms.Button
        Me.btnBrowse = New System.Windows.Forms.Button
        Me.lblRead = New System.Windows.Forms.Label
        Me.lblBrowse = New System.Windows.Forms.Label
        Me.btnWrite = New System.Windows.Forms.Button
        Me.cboFileType = New AppCore.ComboBoxEx
        Me.lblFileType = New System.Windows.Forms.Label
        Me.lblPath = New System.Windows.Forms.Label
        Me.lblWrite = New System.Windows.Forms.Label
        Me.txtPath = New System.Windows.Forms.TextBox
        Me.grbContent = New System.Windows.Forms.GroupBox
        Me.tcrtData = New System.Windows.Forms.TabControl
        Me.tpg1 = New System.Windows.Forms.TabPage
        Me.pnlUploadData = New System.Windows.Forms.Panel
        Me.tpg2 = New System.Windows.Forms.TabPage
        Me.pnlUploadedData = New System.Windows.Forms.Panel
        Me.btnCancel = New System.Windows.Forms.Button
        Me.cmsSelectedAll = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItemSelectedAll = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemUnSelectedAll = New System.Windows.Forms.ToolStripMenuItem
        Me.txtFileID = New System.Windows.Forms.TextBox
        Me.grbMaintain.SuspendLayout()
        Me.grbContent.SuspendLayout()
        Me.tcrtData.SuspendLayout()
        Me.tpg1.SuspendLayout()
        Me.tpg2.SuspendLayout()
        Me.cmsSelectedAll.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbMaintain
        '
        Me.grbMaintain.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbMaintain.Controls.Add(Me.btnRead)
        Me.grbMaintain.Controls.Add(Me.btnBrowse)
        Me.grbMaintain.Controls.Add(Me.lblRead)
        Me.grbMaintain.Controls.Add(Me.lblBrowse)
        Me.grbMaintain.Controls.Add(Me.btnWrite)
        Me.grbMaintain.Controls.Add(Me.cboFileType)
        Me.grbMaintain.Controls.Add(Me.lblFileType)
        Me.grbMaintain.Controls.Add(Me.lblPath)
        Me.grbMaintain.Controls.Add(Me.lblWrite)
        Me.grbMaintain.Controls.Add(Me.txtPath)
        Me.grbMaintain.Location = New System.Drawing.Point(3, 2)
        Me.grbMaintain.Name = "grbMaintain"
        Me.grbMaintain.Size = New System.Drawing.Size(880, 75)
        Me.grbMaintain.TabIndex = 0
        Me.grbMaintain.TabStop = False
        '
        'btnRead
        '
        Me.btnRead.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRead.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRead.Location = New System.Drawing.Point(716, 40)
        Me.btnRead.Name = "btnRead"
        Me.btnRead.Size = New System.Drawing.Size(73, 21)
        Me.btnRead.TabIndex = 16
        Me.btnRead.Text = "Read"
        '
        'btnBrowse
        '
        Me.btnBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBrowse.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBrowse.Location = New System.Drawing.Point(635, 40)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(75, 21)
        Me.btnBrowse.TabIndex = 14
        Me.btnBrowse.Text = "Browse..."
        '
        'lblRead
        '
        Me.lblRead.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRead.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRead.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRead.ForeColor = System.Drawing.Color.Red
        Me.lblRead.Location = New System.Drawing.Point(716, 16)
        Me.lblRead.Name = "lblRead"
        Me.lblRead.Size = New System.Drawing.Size(73, 23)
        Me.lblRead.TabIndex = 15
        Me.lblRead.Text = "Đọc"
        Me.lblRead.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblBrowse
        '
        Me.lblBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBrowse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBrowse.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBrowse.ForeColor = System.Drawing.Color.Red
        Me.lblBrowse.Location = New System.Drawing.Point(635, 16)
        Me.lblBrowse.Name = "lblBrowse"
        Me.lblBrowse.Size = New System.Drawing.Size(75, 23)
        Me.lblBrowse.TabIndex = 13
        Me.lblBrowse.Text = "Chọn"
        Me.lblBrowse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnWrite
        '
        Me.btnWrite.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnWrite.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWrite.Location = New System.Drawing.Point(795, 40)
        Me.btnWrite.Name = "btnWrite"
        Me.btnWrite.Size = New System.Drawing.Size(75, 21)
        Me.btnWrite.TabIndex = 12
        Me.btnWrite.Text = "Write"
        '
        'cboFileType
        '
        Me.cboFileType.DisplayMember = "DISPLAY"
        Me.cboFileType.Location = New System.Drawing.Point(9, 40)
        Me.cboFileType.Name = "cboFileType"
        Me.cboFileType.Size = New System.Drawing.Size(239, 21)
        Me.cboFileType.TabIndex = 11
        Me.cboFileType.ValueMember = "VALUE"
        '
        'lblFileType
        '
        Me.lblFileType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFileType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFileType.ForeColor = System.Drawing.Color.Red
        Me.lblFileType.Location = New System.Drawing.Point(9, 16)
        Me.lblFileType.Name = "lblFileType"
        Me.lblFileType.Size = New System.Drawing.Size(239, 23)
        Me.lblFileType.TabIndex = 10
        Me.lblFileType.Text = "Loại file"
        '
        'lblPath
        '
        Me.lblPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPath.ForeColor = System.Drawing.Color.Red
        Me.lblPath.Location = New System.Drawing.Point(254, 16)
        Me.lblPath.Name = "lblPath"
        Me.lblPath.Size = New System.Drawing.Size(375, 23)
        Me.lblPath.TabIndex = 9
        Me.lblPath.Text = "Đường dẫn"
        '
        'lblWrite
        '
        Me.lblWrite.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblWrite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWrite.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWrite.ForeColor = System.Drawing.Color.Red
        Me.lblWrite.Location = New System.Drawing.Point(795, 16)
        Me.lblWrite.Name = "lblWrite"
        Me.lblWrite.Size = New System.Drawing.Size(75, 23)
        Me.lblWrite.TabIndex = 8
        Me.lblWrite.Text = "Ghi"
        Me.lblWrite.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtPath
        '
        Me.txtPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPath.Location = New System.Drawing.Point(254, 40)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.Size = New System.Drawing.Size(375, 21)
        Me.txtPath.TabIndex = 7
        '
        'grbContent
        '
        Me.grbContent.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbContent.Controls.Add(Me.tcrtData)
        Me.grbContent.Location = New System.Drawing.Point(3, 76)
        Me.grbContent.Name = "grbContent"
        Me.grbContent.Size = New System.Drawing.Size(880, 404)
        Me.grbContent.TabIndex = 1
        Me.grbContent.TabStop = False
        '
        'tcrtData
        '
        Me.tcrtData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tcrtData.Controls.Add(Me.tpg1)
        Me.tcrtData.Controls.Add(Me.tpg2)
        Me.tcrtData.Location = New System.Drawing.Point(5, 10)
        Me.tcrtData.Name = "tcrtData"
        Me.tcrtData.SelectedIndex = 0
        Me.tcrtData.Size = New System.Drawing.Size(870, 388)
        Me.tcrtData.TabIndex = 1
        '
        'tpg1
        '
        Me.tpg1.Controls.Add(Me.pnlUploadData)
        Me.tpg1.Location = New System.Drawing.Point(4, 22)
        Me.tpg1.Name = "tpg1"
        Me.tpg1.Padding = New System.Windows.Forms.Padding(3)
        Me.tpg1.Size = New System.Drawing.Size(862, 362)
        Me.tpg1.TabIndex = 1
        Me.tpg1.Text = "tpg1"
        Me.tpg1.UseVisualStyleBackColor = True
        '
        'pnlUploadData
        '
        Me.pnlUploadData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlUploadData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlUploadData.Location = New System.Drawing.Point(4, 4)
        Me.pnlUploadData.Name = "pnlUploadData"
        Me.pnlUploadData.Size = New System.Drawing.Size(855, 355)
        Me.pnlUploadData.TabIndex = 1
        '
        'tpg2
        '
        Me.tpg2.Controls.Add(Me.pnlUploadedData)
        Me.tpg2.Location = New System.Drawing.Point(4, 22)
        Me.tpg2.Name = "tpg2"
        Me.tpg2.Padding = New System.Windows.Forms.Padding(3)
        Me.tpg2.Size = New System.Drawing.Size(862, 362)
        Me.tpg2.TabIndex = 0
        Me.tpg2.Text = "tpg2"
        Me.tpg2.UseVisualStyleBackColor = True
        '
        'pnlUploadedData
        '
        Me.pnlUploadedData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlUploadedData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlUploadedData.Location = New System.Drawing.Point(4, 4)
        Me.pnlUploadedData.Name = "pnlUploadedData"
        Me.pnlUploadedData.Size = New System.Drawing.Size(855, 355)
        Me.pnlUploadedData.TabIndex = 0
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(806, 485)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 24)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "btnCancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'cmsSelectedAll
        '
        Me.cmsSelectedAll.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemSelectedAll, Me.ToolStripMenuItemUnSelectedAll})
        Me.cmsSelectedAll.Name = "cmsSelectedAll"
        Me.cmsSelectedAll.Size = New System.Drawing.Size(139, 48)
        '
        'ToolStripMenuItemSelectedAll
        '
        Me.ToolStripMenuItemSelectedAll.Name = "ToolStripMenuItemSelectedAll"
        Me.ToolStripMenuItemSelectedAll.Size = New System.Drawing.Size(138, 22)
        Me.ToolStripMenuItemSelectedAll.Text = "Chọn hết"
        '
        'ToolStripMenuItemUnSelectedAll
        '
        Me.ToolStripMenuItemUnSelectedAll.Name = "ToolStripMenuItemUnSelectedAll"
        Me.ToolStripMenuItemUnSelectedAll.Size = New System.Drawing.Size(138, 22)
        Me.ToolStripMenuItemUnSelectedAll.Text = "Bỏ chọn hết"
        '
        'txtFileID
        '
        Me.txtFileID.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtFileID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFileID.Location = New System.Drawing.Point(8, 486)
        Me.txtFileID.Name = "txtFileID"
        Me.txtFileID.ReadOnly = True
        Me.txtFileID.Size = New System.Drawing.Size(120, 21)
        Me.txtFileID.TabIndex = 5
        Me.txtFileID.Tag = "txtFileID"
        Me.txtFileID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'frmTransactUpload
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(885, 513)
        Me.Controls.Add(Me.txtFileID)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.grbContent)
        Me.Controls.Add(Me.grbMaintain)
        Me.KeyPreview = True
        Me.Name = "frmTransactUpload"
        Me.Text = "frmTransactUpload"
        Me.grbMaintain.ResumeLayout(False)
        Me.grbMaintain.PerformLayout()
        Me.grbContent.ResumeLayout(False)
        Me.tcrtData.ResumeLayout(False)
        Me.tpg1.ResumeLayout(False)
        Me.tpg2.ResumeLayout(False)
        Me.cmsSelectedAll.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grbMaintain As System.Windows.Forms.GroupBox
    Friend WithEvents btnWrite As System.Windows.Forms.Button
    Friend WithEvents cboFileType As AppCore.ComboBoxEx
    Friend WithEvents lblFileType As System.Windows.Forms.Label
    Friend WithEvents lblPath As System.Windows.Forms.Label
    Friend WithEvents lblWrite As System.Windows.Forms.Label
    Friend WithEvents txtPath As System.Windows.Forms.TextBox
    Friend WithEvents grbContent As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents pnlUploadedData As System.Windows.Forms.Panel
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents lblBrowse As System.Windows.Forms.Label
    Friend WithEvents btnRead As System.Windows.Forms.Button
    Friend WithEvents lblRead As System.Windows.Forms.Label
    Friend WithEvents tcrtData As System.Windows.Forms.TabControl
    Friend WithEvents tpg2 As System.Windows.Forms.TabPage
    Friend WithEvents tpg1 As System.Windows.Forms.TabPage
    Friend WithEvents pnlUploadData As System.Windows.Forms.Panel
    Friend WithEvents cmsSelectedAll As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItemSelectedAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemUnSelectedAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtFileID As System.Windows.Forms.TextBox
End Class
