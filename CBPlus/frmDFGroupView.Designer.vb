<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDFGroupView
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDFGroupView))
        Me.grbDFGroupParameter = New System.Windows.Forms.GroupBox
        Me.lblDESC = New System.Windows.Forms.Label
        Me.txtDESC = New System.Windows.Forms.TextBox
        Me.lblCONFIRMAMT = New System.Windows.Forms.Label
        Me.txtCONFIRMAMT = New System.Windows.Forms.TextBox
        Me.lblEXPECTEDAMT = New System.Windows.Forms.Label
        Me.txtEXPECTEDAMT = New System.Windows.Forms.TextBox
        Me.lblBANKNAME = New System.Windows.Forms.Label
        Me.lblINUSEDLIMIT = New System.Windows.Forms.Label
        Me.txtINUSEDLIMIT = New System.Windows.Forms.TextBox
        Me.lblCUSTLIMIT = New System.Windows.Forms.Label
        Me.txtCUSTLIMIT = New System.Windows.Forms.TextBox
        Me.lblCUSTBANK = New System.Windows.Forms.Label
        Me.txtCUSTBANK = New System.Windows.Forms.TextBox
        Me.lblDFTYPE = New System.Windows.Forms.Label
        Me.cboDFTYPE = New AppCore.ComboBoxEx
        CType(Me.mv_SymbolTable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbDFGroupParameter.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbSearchFilter
        '
        Me.grbSearchFilter.Location = New System.Drawing.Point(5, 155)
        Me.grbSearchFilter.Text = "Điều kiện tìm kiếm:"
        '
        'grbSearchResult
        '
        Me.grbSearchResult.Location = New System.Drawing.Point(5, 312)
        Me.grbSearchResult.Size = New System.Drawing.Size(878, 246)
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
        'grbDFGroupParameter
        '
        Me.grbDFGroupParameter.Controls.Add(Me.cboDFTYPE)
        Me.grbDFGroupParameter.Controls.Add(Me.lblDFTYPE)
        Me.grbDFGroupParameter.Controls.Add(Me.lblDESC)
        Me.grbDFGroupParameter.Controls.Add(Me.txtDESC)
        Me.grbDFGroupParameter.Controls.Add(Me.lblCONFIRMAMT)
        Me.grbDFGroupParameter.Controls.Add(Me.txtCONFIRMAMT)
        Me.grbDFGroupParameter.Controls.Add(Me.lblEXPECTEDAMT)
        Me.grbDFGroupParameter.Controls.Add(Me.txtEXPECTEDAMT)
        Me.grbDFGroupParameter.Controls.Add(Me.lblBANKNAME)
        Me.grbDFGroupParameter.Controls.Add(Me.lblINUSEDLIMIT)
        Me.grbDFGroupParameter.Controls.Add(Me.txtINUSEDLIMIT)
        Me.grbDFGroupParameter.Controls.Add(Me.lblCUSTLIMIT)
        Me.grbDFGroupParameter.Controls.Add(Me.txtCUSTLIMIT)
        Me.grbDFGroupParameter.Controls.Add(Me.lblCUSTBANK)
        Me.grbDFGroupParameter.Controls.Add(Me.txtCUSTBANK)
        Me.grbDFGroupParameter.Location = New System.Drawing.Point(5, 46)
        Me.grbDFGroupParameter.Name = "grbDFGroupParameter"
        Me.grbDFGroupParameter.Size = New System.Drawing.Size(869, 105)
        Me.grbDFGroupParameter.TabIndex = 14
        Me.grbDFGroupParameter.TabStop = False
        Me.grbDFGroupParameter.Tag = "grbDFGroupParameter"
        Me.grbDFGroupParameter.Text = "grbDFGroupParameter"
        '
        'lblDESC
        '
        Me.lblDESC.AutoSize = True
        Me.lblDESC.Location = New System.Drawing.Point(8, 77)
        Me.lblDESC.Name = "lblDESC"
        Me.lblDESC.Size = New System.Drawing.Size(43, 13)
        Me.lblDESC.TabIndex = 12
        Me.lblDESC.Tag = "lblDESC"
        Me.lblDESC.Text = "lblDESC"
        '
        'txtDESC
        '
        Me.txtDESC.Location = New System.Drawing.Point(90, 74)
        Me.txtDESC.Name = "txtDESC"
        Me.txtDESC.Size = New System.Drawing.Size(773, 21)
        Me.txtDESC.TabIndex = 11
        Me.txtDESC.Tag = "txtDESC"
        '
        'lblCONFIRMAMT
        '
        Me.lblCONFIRMAMT.AutoSize = True
        Me.lblCONFIRMAMT.Location = New System.Drawing.Point(665, 50)
        Me.lblCONFIRMAMT.Name = "lblCONFIRMAMT"
        Me.lblCONFIRMAMT.Size = New System.Drawing.Size(85, 13)
        Me.lblCONFIRMAMT.TabIndex = 10
        Me.lblCONFIRMAMT.Tag = "lblCONFIRMAMT"
        Me.lblCONFIRMAMT.Text = "lblCONFIRMAMT"
        '
        'txtCONFIRMAMT
        '
        Me.txtCONFIRMAMT.Enabled = False
        Me.txtCONFIRMAMT.Location = New System.Drawing.Point(763, 47)
        Me.txtCONFIRMAMT.Name = "txtCONFIRMAMT"
        Me.txtCONFIRMAMT.Size = New System.Drawing.Size(100, 21)
        Me.txtCONFIRMAMT.TabIndex = 9
        Me.txtCONFIRMAMT.Tag = "txtCONFIRMAMT"
        Me.txtCONFIRMAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblEXPECTEDAMT
        '
        Me.lblEXPECTEDAMT.AutoSize = True
        Me.lblEXPECTEDAMT.Location = New System.Drawing.Point(446, 50)
        Me.lblEXPECTEDAMT.Name = "lblEXPECTEDAMT"
        Me.lblEXPECTEDAMT.Size = New System.Drawing.Size(88, 13)
        Me.lblEXPECTEDAMT.TabIndex = 8
        Me.lblEXPECTEDAMT.Tag = "lblEXPECTEDAMT"
        Me.lblEXPECTEDAMT.Text = "lblEXPECTEDAMT"
        '
        'txtEXPECTEDAMT
        '
        Me.txtEXPECTEDAMT.Location = New System.Drawing.Point(544, 47)
        Me.txtEXPECTEDAMT.Name = "txtEXPECTEDAMT"
        Me.txtEXPECTEDAMT.Size = New System.Drawing.Size(100, 21)
        Me.txtEXPECTEDAMT.TabIndex = 7
        Me.txtEXPECTEDAMT.Tag = "txtEXPECTEDAMT"
        Me.txtEXPECTEDAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        'lblINUSEDLIMIT
        '
        Me.lblINUSEDLIMIT.AutoSize = True
        Me.lblINUSEDLIMIT.Location = New System.Drawing.Point(665, 23)
        Me.lblINUSEDLIMIT.Name = "lblINUSEDLIMIT"
        Me.lblINUSEDLIMIT.Size = New System.Drawing.Size(81, 13)
        Me.lblINUSEDLIMIT.TabIndex = 5
        Me.lblINUSEDLIMIT.Tag = "lblINUSEDLIMIT"
        Me.lblINUSEDLIMIT.Text = "lblINUSEDLIMIT"
        '
        'txtINUSEDLIMIT
        '
        Me.txtINUSEDLIMIT.Enabled = False
        Me.txtINUSEDLIMIT.Location = New System.Drawing.Point(763, 20)
        Me.txtINUSEDLIMIT.Name = "txtINUSEDLIMIT"
        Me.txtINUSEDLIMIT.Size = New System.Drawing.Size(100, 21)
        Me.txtINUSEDLIMIT.TabIndex = 4
        Me.txtINUSEDLIMIT.Tag = "txtINUSEDLIMIT"
        Me.txtINUSEDLIMIT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCUSTLIMIT
        '
        Me.lblCUSTLIMIT.AutoSize = True
        Me.lblCUSTLIMIT.Location = New System.Drawing.Point(446, 23)
        Me.lblCUSTLIMIT.Name = "lblCUSTLIMIT"
        Me.lblCUSTLIMIT.Size = New System.Drawing.Size(70, 13)
        Me.lblCUSTLIMIT.TabIndex = 3
        Me.lblCUSTLIMIT.Tag = "lblCUSTLIMIT"
        Me.lblCUSTLIMIT.Text = "lblCUSTLIMIT"
        '
        'txtCUSTLIMIT
        '
        Me.txtCUSTLIMIT.Enabled = False
        Me.txtCUSTLIMIT.Location = New System.Drawing.Point(544, 20)
        Me.txtCUSTLIMIT.Name = "txtCUSTLIMIT"
        Me.txtCUSTLIMIT.Size = New System.Drawing.Size(100, 21)
        Me.txtCUSTLIMIT.TabIndex = 2
        Me.txtCUSTLIMIT.Tag = "txtCUSTLIMIT"
        Me.txtCUSTLIMIT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCUSTBANK
        '
        Me.lblCUSTBANK.AutoSize = True
        Me.lblCUSTBANK.Location = New System.Drawing.Point(7, 23)
        Me.lblCUSTBANK.Name = "lblCUSTBANK"
        Me.lblCUSTBANK.Size = New System.Drawing.Size(69, 13)
        Me.lblCUSTBANK.TabIndex = 1
        Me.lblCUSTBANK.Tag = "lblCUSTBANK"
        Me.lblCUSTBANK.Text = "lblCUSTBANK"
        '
        'txtCUSTBANK
        '
        Me.txtCUSTBANK.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtCUSTBANK.Location = New System.Drawing.Point(90, 20)
        Me.txtCUSTBANK.MaxLength = 10
        Me.txtCUSTBANK.Name = "txtCUSTBANK"
        Me.txtCUSTBANK.Size = New System.Drawing.Size(73, 21)
        Me.txtCUSTBANK.TabIndex = 0
        Me.txtCUSTBANK.Tag = "txtCUSTBANK"
        '
        'lblDFTYPE
        '
        Me.lblDFTYPE.AutoSize = True
        Me.lblDFTYPE.Location = New System.Drawing.Point(7, 50)
        Me.lblDFTYPE.Name = "lblDFTYPE"
        Me.lblDFTYPE.Size = New System.Drawing.Size(54, 13)
        Me.lblDFTYPE.TabIndex = 13
        Me.lblDFTYPE.Tag = "lblDFTYPE"
        Me.lblDFTYPE.Text = "lblDFTYPE"
        '
        'cboDFTYPE
        '
        Me.cboDFTYPE.DisplayMember = "DISPLAY"
        Me.cboDFTYPE.FormattingEnabled = True
        Me.cboDFTYPE.Location = New System.Drawing.Point(90, 47)
        Me.cboDFTYPE.Name = "cboDFTYPE"
        Me.cboDFTYPE.Size = New System.Drawing.Size(310, 21)
        Me.cboDFTYPE.TabIndex = 14
        Me.cboDFTYPE.Tag = "cboDFTYPE"
        Me.cboDFTYPE.ValueMember = "VALUE"
        '
        'frmDFGroupView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(880, 603)
        Me.Controls.Add(Me.grbDFGroupParameter)
        Me.Name = "frmDFGroupView"
        Me.Text = "frmDFGroupView"
        Me.Controls.SetChildIndex(Me.grbDFGroupParameter, 0)
        Me.Controls.SetChildIndex(Me.chkauto, 0)
        Me.Controls.SetChildIndex(Me.btnBACK, 0)
        Me.Controls.SetChildIndex(Me.btnNEXT, 0)
        Me.Controls.SetChildIndex(Me.grbSearchFilter, 0)
        Me.Controls.SetChildIndex(Me.grbSearchResult, 0)
        Me.Controls.SetChildIndex(Me.chkALL, 0)
        Me.Controls.SetChildIndex(Me.chkExeAll, 0)
        CType(Me.mv_SymbolTable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbDFGroupParameter.ResumeLayout(False)
        Me.grbDFGroupParameter.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grbDFGroupParameter As System.Windows.Forms.GroupBox
    Friend WithEvents lblCUSTBANK As System.Windows.Forms.Label
    Friend WithEvents txtCUSTBANK As System.Windows.Forms.TextBox
    Friend WithEvents lblCUSTLIMIT As System.Windows.Forms.Label
    Friend WithEvents txtCUSTLIMIT As System.Windows.Forms.TextBox
    Friend WithEvents lblBANKNAME As System.Windows.Forms.Label
    Friend WithEvents lblINUSEDLIMIT As System.Windows.Forms.Label
    Friend WithEvents txtINUSEDLIMIT As System.Windows.Forms.TextBox
    Friend WithEvents lblCONFIRMAMT As System.Windows.Forms.Label
    Friend WithEvents txtCONFIRMAMT As System.Windows.Forms.TextBox
    Friend WithEvents lblEXPECTEDAMT As System.Windows.Forms.Label
    Friend WithEvents txtEXPECTEDAMT As System.Windows.Forms.TextBox
    Friend WithEvents lblDESC As System.Windows.Forms.Label
    Friend WithEvents txtDESC As System.Windows.Forms.TextBox
    Friend WithEvents lblDFTYPE As System.Windows.Forms.Label
    Friend WithEvents cboDFTYPE As AppCore.ComboBoxEx
End Class
