<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReAddRM
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReAddRM))
        Me.grbRemiser = New System.Windows.Forms.GroupBox
        Me.pnlRemiser = New System.Windows.Forms.Panel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblCaption = New System.Windows.Forms.Label
        Me.btnChange = New System.Windows.Forms.Button
        Me.mskReAcctno = New System.Windows.Forms.MaskedTextBox
        Me.lblReAcctno = New System.Windows.Forms.Label
        Me.lblReName = New System.Windows.Forms.Label
        Me.btnSearch = New System.Windows.Forms.Button
        Me.lblCustodycd = New System.Windows.Forms.Label
        Me.txbCustodycd = New System.Windows.Forms.TextBox
        Me.lblFullname = New System.Windows.Forms.Label
        Me.lblAcctno = New System.Windows.Forms.Label
        Me.cboAFACCTNO = New AppCore.ComboBoxEx
        Me.btnClose = New System.Windows.Forms.Button
        Me.grbRemiser.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbRemiser
        '
        Me.grbRemiser.Controls.Add(Me.pnlRemiser)
        Me.grbRemiser.Location = New System.Drawing.Point(6, 119)
        Me.grbRemiser.Name = "grbRemiser"
        Me.grbRemiser.Size = New System.Drawing.Size(765, 325)
        Me.grbRemiser.TabIndex = 0
        Me.grbRemiser.TabStop = False
        Me.grbRemiser.Tag = "grbRemiser"
        Me.grbRemiser.Text = "grbRemiser"
        '
        'pnlRemiser
        '
        Me.pnlRemiser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlRemiser.Location = New System.Drawing.Point(3, 16)
        Me.pnlRemiser.Name = "pnlRemiser"
        Me.pnlRemiser.Size = New System.Drawing.Size(759, 306)
        Me.pnlRemiser.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.Controls.Add(Me.lblCaption)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(775, 50)
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
        Me.btnChange.Location = New System.Drawing.Point(602, 450)
        Me.btnChange.Name = "btnChange"
        Me.btnChange.Size = New System.Drawing.Size(77, 25)
        Me.btnChange.TabIndex = 6
        Me.btnChange.Tag = "btnChange"
        Me.btnChange.Text = "btnChange"
        Me.btnChange.UseVisualStyleBackColor = True
        '
        'mskReAcctno
        '
        Me.mskReAcctno.Location = New System.Drawing.Point(569, 65)
        Me.mskReAcctno.Name = "mskReAcctno"
        Me.mskReAcctno.Size = New System.Drawing.Size(83, 20)
        Me.mskReAcctno.TabIndex = 2
        Me.mskReAcctno.Tag = "mskReAcctno"
        '
        'lblReAcctno
        '
        Me.lblReAcctno.Location = New System.Drawing.Point(465, 66)
        Me.lblReAcctno.Name = "lblReAcctno"
        Me.lblReAcctno.Size = New System.Drawing.Size(93, 19)
        Me.lblReAcctno.TabIndex = 9
        Me.lblReAcctno.Tag = "lblReAcctno"
        Me.lblReAcctno.Text = "lblReAcctno"
        '
        'lblReName
        '
        Me.lblReName.AutoSize = True
        Me.lblReName.Location = New System.Drawing.Point(663, 68)
        Me.lblReName.Name = "lblReName"
        Me.lblReName.Size = New System.Drawing.Size(59, 13)
        Me.lblReName.TabIndex = 10
        Me.lblReName.Tag = "lblReName"
        Me.lblReName.Text = "lblReName"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(570, 88)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(77, 25)
        Me.btnSearch.TabIndex = 11
        Me.btnSearch.Tag = "btnSearch"
        Me.btnSearch.Text = "btnSearch"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'lblCustodycd
        '
        Me.lblCustodycd.Location = New System.Drawing.Point(20, 60)
        Me.lblCustodycd.Name = "lblCustodycd"
        Me.lblCustodycd.Size = New System.Drawing.Size(89, 19)
        Me.lblCustodycd.TabIndex = 12
        Me.lblCustodycd.Tag = "lblCustodycd"
        Me.lblCustodycd.Text = "lblCustodycd"
        '
        'txbCustodycd
        '
        Me.txbCustodycd.Location = New System.Drawing.Point(111, 58)
        Me.txbCustodycd.Name = "txbCustodycd"
        Me.txbCustodycd.Size = New System.Drawing.Size(89, 20)
        Me.txbCustodycd.TabIndex = 0
        Me.txbCustodycd.Tag = "txbCustodycd"
        Me.txbCustodycd.Text = "txbCustodycd"
        '
        'lblFullname
        '
        Me.lblFullname.Location = New System.Drawing.Point(215, 59)
        Me.lblFullname.Name = "lblFullname"
        Me.lblFullname.Size = New System.Drawing.Size(89, 19)
        Me.lblFullname.TabIndex = 13
        Me.lblFullname.Tag = "lblFullname"
        Me.lblFullname.Text = "lblFullname"
        '
        'lblAcctno
        '
        Me.lblAcctno.Location = New System.Drawing.Point(20, 87)
        Me.lblAcctno.Name = "lblAcctno"
        Me.lblAcctno.Size = New System.Drawing.Size(89, 19)
        Me.lblAcctno.TabIndex = 15
        Me.lblAcctno.Tag = "lblAcctno"
        Me.lblAcctno.Text = "lblAcctno"
        '
        'cboAFACCTNO
        '
        Me.cboAFACCTNO.DisplayMember = "DISPLAY"
        Me.cboAFACCTNO.FormattingEnabled = True
        Me.cboAFACCTNO.Location = New System.Drawing.Point(114, 87)
        Me.cboAFACCTNO.Name = "cboAFACCTNO"
        Me.cboAFACCTNO.Size = New System.Drawing.Size(340, 21)
        Me.cboAFACCTNO.TabIndex = 1
        Me.cboAFACCTNO.Tag = "cboAFACCTNO"
        Me.cboAFACCTNO.ValueMember = "VALUE"
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(685, 450)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(78, 25)
        Me.btnClose.TabIndex = 16
        Me.btnClose.Tag = "btnClose"
        Me.btnClose.Text = "btnClose"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'frmReAddRM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(775, 483)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.cboAFACCTNO)
        Me.Controls.Add(Me.lblAcctno)
        Me.Controls.Add(Me.lblFullname)
        Me.Controls.Add(Me.txbCustodycd)
        Me.Controls.Add(Me.lblCustodycd)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.lblReName)
        Me.Controls.Add(Me.lblReAcctno)
        Me.Controls.Add(Me.mskReAcctno)
        Me.Controls.Add(Me.btnChange)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.grbRemiser)
        Me.KeyPreview = True
        Me.Name = "frmReAddRM"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "frmReAddRM"
        Me.Text = "frmReAddRM"
        Me.grbRemiser.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grbRemiser As System.Windows.Forms.GroupBox
    Friend WithEvents pnlRemiser As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblCaption As System.Windows.Forms.Label
    Friend WithEvents btnChange As System.Windows.Forms.Button
    Friend WithEvents mskReAcctno As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblReAcctno As System.Windows.Forms.Label
    Friend WithEvents lblReName As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents lblCustodycd As System.Windows.Forms.Label
    Friend WithEvents txbCustodycd As System.Windows.Forms.TextBox
    Friend WithEvents lblFullname As System.Windows.Forms.Label
    Friend WithEvents lblAcctno As System.Windows.Forms.Label
    Friend WithEvents cboAFACCTNO As AppCore.ComboBoxEx
    Friend WithEvents btnClose As System.Windows.Forms.Button
End Class
