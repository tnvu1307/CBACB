<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLNChangeTYPE
    Inherits AppCore.frmSearch

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLNChangeTYPE))
        Me.grbLNChangeTYPEParameter = New System.Windows.Forms.GroupBox
        Me.cboNEWLNTYPE = New AppCore.ComboBoxEx
        Me.lblNewLNTYPE = New System.Windows.Forms.Label
        Me.cboOLDLNTYPE = New AppCore.ComboBoxEx
        Me.lblOldLNTYPE = New System.Windows.Forms.Label
        Me.lblDESC = New System.Windows.Forms.Label
        Me.txtDESC = New System.Windows.Forms.TextBox
        Me.lblBANKNAME = New System.Windows.Forms.Label
        CType(Me.mv_SymbolTable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbLNChangeTYPEParameter.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbSearchFilter
        '
        Me.grbSearchFilter.Location = New System.Drawing.Point(5, 127)
        Me.grbSearchFilter.Text = "Điều kiện tìm kiếm:"
        '
        'grbSearchResult
        '
        Me.grbSearchResult.Location = New System.Drawing.Point(5, 284)
        Me.grbSearchResult.Size = New System.Drawing.Size(878, 274)
        Me.grbSearchResult.Text = "Kết quả tìm kiếm:"
        '
        'btnNEXT
        '
        Me.btnNEXT.Location = New System.Drawing.Point(64, 555)
        Me.btnNEXT.Text = "Sau"
        '
        'btnBACK
        '
        Me.btnBACK.Location = New System.Drawing.Point(8, 555)
        Me.btnBACK.Text = "Trước"
        '
        'chkALL
        '
        Me.chkALL.Location = New System.Drawing.Point(132, 558)
        '
        'chkExeAll
        '
        Me.chkExeAll.Location = New System.Drawing.Point(688, 559)
        '
        'chkauto
        '
        Me.chkauto.Location = New System.Drawing.Point(416, 559)
        '
        'grbLNChangeTYPEParameter
        '
        Me.grbLNChangeTYPEParameter.Controls.Add(Me.cboNEWLNTYPE)
        Me.grbLNChangeTYPEParameter.Controls.Add(Me.lblNewLNTYPE)
        Me.grbLNChangeTYPEParameter.Controls.Add(Me.cboOLDLNTYPE)
        Me.grbLNChangeTYPEParameter.Controls.Add(Me.lblOldLNTYPE)
        Me.grbLNChangeTYPEParameter.Controls.Add(Me.lblDESC)
        Me.grbLNChangeTYPEParameter.Controls.Add(Me.txtDESC)
        Me.grbLNChangeTYPEParameter.Controls.Add(Me.lblBANKNAME)
        Me.grbLNChangeTYPEParameter.Location = New System.Drawing.Point(5, 46)
        Me.grbLNChangeTYPEParameter.Name = "grbLNChangeTYPEParameter"
        Me.grbLNChangeTYPEParameter.Size = New System.Drawing.Size(869, 75)
        Me.grbLNChangeTYPEParameter.TabIndex = 14
        Me.grbLNChangeTYPEParameter.TabStop = False
        Me.grbLNChangeTYPEParameter.Tag = "grbLNChangeTYPEParameter"
        Me.grbLNChangeTYPEParameter.Text = "grbLNChangeTYPEParameter"
        '
        'cboNEWLNTYPE
        '
        Me.cboNEWLNTYPE.DisplayMember = "DISPLAY"
        Me.cboNEWLNTYPE.FormattingEnabled = True
        Me.cboNEWLNTYPE.Location = New System.Drawing.Point(552, 20)
        Me.cboNEWLNTYPE.Name = "cboNEWLNTYPE"
        Me.cboNEWLNTYPE.Size = New System.Drawing.Size(311, 21)
        Me.cboNEWLNTYPE.TabIndex = 16
        Me.cboNEWLNTYPE.Tag = "cboNEWLNTYPE"
        Me.cboNEWLNTYPE.ValueMember = "VALUE"
        '
        'lblNewLNTYPE
        '
        Me.lblNewLNTYPE.AutoSize = True
        Me.lblNewLNTYPE.Location = New System.Drawing.Point(413, 23)
        Me.lblNewLNTYPE.Name = "lblNewLNTYPE"
        Me.lblNewLNTYPE.Size = New System.Drawing.Size(74, 13)
        Me.lblNewLNTYPE.TabIndex = 15
        Me.lblNewLNTYPE.Tag = "lblNewLNTYPE"
        Me.lblNewLNTYPE.Text = "lblNewLNTYPE"
        '
        'cboOLDLNTYPE
        '
        Me.cboOLDLNTYPE.DisplayMember = "DISPLAY"
        Me.cboOLDLNTYPE.FormattingEnabled = True
        Me.cboOLDLNTYPE.Location = New System.Drawing.Point(127, 20)
        Me.cboOLDLNTYPE.Name = "cboOLDLNTYPE"
        Me.cboOLDLNTYPE.Size = New System.Drawing.Size(273, 21)
        Me.cboOLDLNTYPE.TabIndex = 14
        Me.cboOLDLNTYPE.Tag = "cboOLDLNTYPE"
        Me.cboOLDLNTYPE.ValueMember = "VALUE"
        '
        'lblOldLNTYPE
        '
        Me.lblOldLNTYPE.AutoSize = True
        Me.lblOldLNTYPE.Location = New System.Drawing.Point(7, 23)
        Me.lblOldLNTYPE.Name = "lblOldLNTYPE"
        Me.lblOldLNTYPE.Size = New System.Drawing.Size(69, 13)
        Me.lblOldLNTYPE.TabIndex = 13
        Me.lblOldLNTYPE.Tag = "lblOldLNTYPE"
        Me.lblOldLNTYPE.Text = "lblOldLNTYPE"
        '
        'lblDESC
        '
        Me.lblDESC.AutoSize = True
        Me.lblDESC.Location = New System.Drawing.Point(8, 50)
        Me.lblDESC.Name = "lblDESC"
        Me.lblDESC.Size = New System.Drawing.Size(43, 13)
        Me.lblDESC.TabIndex = 12
        Me.lblDESC.Tag = "lblDESC"
        Me.lblDESC.Text = "lblDESC"
        '
        'txtDESC
        '
        Me.txtDESC.Location = New System.Drawing.Point(127, 47)
        Me.txtDESC.Name = "txtDESC"
        Me.txtDESC.Size = New System.Drawing.Size(736, 21)
        Me.txtDESC.TabIndex = 11
        Me.txtDESC.Tag = "txtDESC"
        '
        'lblBANKNAME
        '
        Me.lblBANKNAME.AutoSize = True
        Me.lblBANKNAME.Location = New System.Drawing.Point(169, 23)
        Me.lblBANKNAME.Name = "lblBANKNAME"
        Me.lblBANKNAME.Size = New System.Drawing.Size(0, 13)
        Me.lblBANKNAME.TabIndex = 6
        Me.lblBANKNAME.Tag = "lblBANKNAME"
        '
        'frmLNChangeTYPE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(880, 603)
        Me.Controls.Add(Me.grbLNChangeTYPEParameter)
        Me.Name = "frmLNChangeTYPE"
        Me.Text = "frmLNChangeTYPE"
        Me.Controls.SetChildIndex(Me.grbSearchFilter, 0)
        Me.Controls.SetChildIndex(Me.grbSearchResult, 0)
        Me.Controls.SetChildIndex(Me.grbLNChangeTYPEParameter, 0)
        Me.Controls.SetChildIndex(Me.chkauto, 0)
        Me.Controls.SetChildIndex(Me.btnBACK, 0)
        Me.Controls.SetChildIndex(Me.btnNEXT, 0)
        Me.Controls.SetChildIndex(Me.chkALL, 0)
        Me.Controls.SetChildIndex(Me.chkExeAll, 0)
        CType(Me.mv_SymbolTable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbLNChangeTYPEParameter.ResumeLayout(False)
        Me.grbLNChangeTYPEParameter.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grbLNChangeTYPEParameter As System.Windows.Forms.GroupBox
    Friend WithEvents lblBANKNAME As System.Windows.Forms.Label
    Friend WithEvents lblDESC As System.Windows.Forms.Label
    Friend WithEvents txtDESC As System.Windows.Forms.TextBox
    Friend WithEvents lblOldLNTYPE As System.Windows.Forms.Label
    Friend WithEvents cboOLDLNTYPE As AppCore.ComboBoxEx
    Friend WithEvents cboNEWLNTYPE As AppCore.ComboBoxEx
    Friend WithEvents lblNewLNTYPE As System.Windows.Forms.Label
End Class
