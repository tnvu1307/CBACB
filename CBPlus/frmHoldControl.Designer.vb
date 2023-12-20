<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHoldControl
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.grpConfig = New System.Windows.Forms.GroupBox
        Me.cmdBANKREQUEST = New System.Windows.Forms.Button
        Me.txtQueueSize = New System.Windows.Forms.TextBox
        Me.lblQueueSize = New System.Windows.Forms.Label
        Me.cmdAction = New System.Windows.Forms.Button
        Me.txtEmail = New System.Windows.Forms.TextBox
        Me.lblEmail = New System.Windows.Forms.Label
        Me.lblMS = New System.Windows.Forms.Label
        Me.txtInterval = New System.Windows.Forms.TextBox
        Me.lblInterval = New System.Windows.Forms.Label
        Me.grpBankInfo = New System.Windows.Forms.GroupBox
        Me.lblSTB = New System.Windows.Forms.Label
        Me.lblBIDV = New System.Windows.Forms.Label
        Me.lblDAB = New System.Windows.Forms.Label
        Me.lblBVB = New System.Windows.Forms.Label
        Me.chkSTBActive = New System.Windows.Forms.CheckBox
        Me.lblSTBStatus = New System.Windows.Forms.Label
        Me.chkBIDVActive = New System.Windows.Forms.CheckBox
        Me.lblBIDVStatus = New System.Windows.Forms.Label
        Me.chkDABActive = New System.Windows.Forms.CheckBox
        Me.lblDABStatus = New System.Windows.Forms.Label
        Me.chkBVBActive = New System.Windows.Forms.CheckBox
        Me.lblBVBStatus = New System.Windows.Forms.Label
        Me.txtLog = New System.Windows.Forms.RichTextBox
        Me.TableLayoutPanel1.SuspendLayout()
        Me.grpConfig.SuspendLayout()
        Me.grpBankInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.grpConfig, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.grpBankInfo, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtLog, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(893, 474)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'grpConfig
        '
        Me.grpConfig.Controls.Add(Me.cmdBANKREQUEST)
        Me.grpConfig.Controls.Add(Me.txtQueueSize)
        Me.grpConfig.Controls.Add(Me.lblQueueSize)
        Me.grpConfig.Controls.Add(Me.cmdAction)
        Me.grpConfig.Controls.Add(Me.txtEmail)
        Me.grpConfig.Controls.Add(Me.lblEmail)
        Me.grpConfig.Controls.Add(Me.lblMS)
        Me.grpConfig.Controls.Add(Me.txtInterval)
        Me.grpConfig.Controls.Add(Me.lblInterval)
        Me.grpConfig.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpConfig.Location = New System.Drawing.Point(3, 73)
        Me.grpConfig.Name = "grpConfig"
        Me.grpConfig.Size = New System.Drawing.Size(887, 64)
        Me.grpConfig.TabIndex = 1
        Me.grpConfig.TabStop = False
        Me.grpConfig.Text = "Thông số cấu hình"
        '
        'cmdBANKREQUEST
        '
        Me.cmdBANKREQUEST.Location = New System.Drawing.Point(759, 23)
        Me.cmdBANKREQUEST.Name = "cmdBANKREQUEST"
        Me.cmdBANKREQUEST.Size = New System.Drawing.Size(110, 23)
        Me.cmdBANKREQUEST.TabIndex = 8
        Me.cmdBANKREQUEST.Tag = "BANKREQUEST"
        Me.cmdBANKREQUEST.Text = "lblBANKREQUEST"
        Me.cmdBANKREQUEST.UseVisualStyleBackColor = True
        '
        'txtQueueSize
        '
        Me.txtQueueSize.Location = New System.Drawing.Point(310, 25)
        Me.txtQueueSize.Name = "txtQueueSize"
        Me.txtQueueSize.Size = New System.Drawing.Size(64, 20)
        Me.txtQueueSize.TabIndex = 7
        '
        'lblQueueSize
        '
        Me.lblQueueSize.AutoSize = True
        Me.lblQueueSize.Location = New System.Drawing.Point(198, 28)
        Me.lblQueueSize.Name = "lblQueueSize"
        Me.lblQueueSize.Size = New System.Drawing.Size(106, 13)
        Me.lblQueueSize.TabIndex = 6
        Me.lblQueueSize.Text = "Dòng xử lý / lần quét"
        '
        'cmdAction
        '
        Me.cmdAction.Location = New System.Drawing.Point(644, 23)
        Me.cmdAction.Name = "cmdAction"
        Me.cmdAction.Size = New System.Drawing.Size(75, 23)
        Me.cmdAction.TabIndex = 5
        Me.cmdAction.Text = "Chạy"
        Me.cmdAction.UseVisualStyleBackColor = True
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(460, 25)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(173, 20)
        Me.txtEmail.TabIndex = 4
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Location = New System.Drawing.Point(388, 28)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(66, 13)
        Me.lblEmail.TabIndex = 3
        Me.lblEmail.Text = "Email báo lỗi"
        '
        'lblMS
        '
        Me.lblMS.AutoSize = True
        Me.lblMS.Location = New System.Drawing.Point(166, 28)
        Me.lblMS.Name = "lblMS"
        Me.lblMS.Size = New System.Drawing.Size(26, 13)
        Me.lblMS.TabIndex = 2
        Me.lblMS.Text = "(ms)"
        '
        'txtInterval
        '
        Me.txtInterval.Location = New System.Drawing.Point(85, 25)
        Me.txtInterval.Name = "txtInterval"
        Me.txtInterval.Size = New System.Drawing.Size(75, 20)
        Me.txtInterval.TabIndex = 1
        '
        'lblInterval
        '
        Me.lblInterval.AutoSize = True
        Me.lblInterval.Location = New System.Drawing.Point(15, 28)
        Me.lblInterval.Name = "lblInterval"
        Me.lblInterval.Size = New System.Drawing.Size(64, 13)
        Me.lblInterval.TabIndex = 0
        Me.lblInterval.Text = "Tần số quét"
        '
        'grpBankInfo
        '
        Me.grpBankInfo.Controls.Add(Me.lblSTB)
        Me.grpBankInfo.Controls.Add(Me.lblBIDV)
        Me.grpBankInfo.Controls.Add(Me.lblDAB)
        Me.grpBankInfo.Controls.Add(Me.lblBVB)
        Me.grpBankInfo.Controls.Add(Me.chkSTBActive)
        Me.grpBankInfo.Controls.Add(Me.lblSTBStatus)
        Me.grpBankInfo.Controls.Add(Me.chkBIDVActive)
        Me.grpBankInfo.Controls.Add(Me.lblBIDVStatus)
        Me.grpBankInfo.Controls.Add(Me.chkDABActive)
        Me.grpBankInfo.Controls.Add(Me.lblDABStatus)
        Me.grpBankInfo.Controls.Add(Me.chkBVBActive)
        Me.grpBankInfo.Controls.Add(Me.lblBVBStatus)
        Me.grpBankInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpBankInfo.Location = New System.Drawing.Point(3, 3)
        Me.grpBankInfo.Name = "grpBankInfo"
        Me.grpBankInfo.Size = New System.Drawing.Size(887, 64)
        Me.grpBankInfo.TabIndex = 0
        Me.grpBankInfo.TabStop = False
        Me.grpBankInfo.Text = "Thông tin queue ngân hàng"
        '
        'lblSTB
        '
        Me.lblSTB.AutoSize = True
        Me.lblSTB.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSTB.Location = New System.Drawing.Point(633, 30)
        Me.lblSTB.Name = "lblSTB"
        Me.lblSTB.Size = New System.Drawing.Size(74, 13)
        Me.lblSTB.TabIndex = 15
        Me.lblSTB.Text = "SacomBank"
        '
        'lblBIDV
        '
        Me.lblBIDV.AutoSize = True
        Me.lblBIDV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBIDV.Location = New System.Drawing.Point(10, 30)
        Me.lblBIDV.Name = "lblBIDV"
        Me.lblBIDV.Size = New System.Drawing.Size(69, 13)
        Me.lblBIDV.TabIndex = 14
        Me.lblBIDV.Text = "BIDV Bank"
        '
        'lblDAB
        '
        Me.lblDAB.AutoSize = True
        Me.lblDAB.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDAB.Location = New System.Drawing.Point(220, 30)
        Me.lblDAB.Name = "lblDAB"
        Me.lblDAB.Size = New System.Drawing.Size(82, 13)
        Me.lblDAB.TabIndex = 13
        Me.lblDAB.Text = "Đông Á Bank"
        '
        'lblBVB
        '
        Me.lblBVB.AutoSize = True
        Me.lblBVB.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBVB.Location = New System.Drawing.Point(430, 30)
        Me.lblBVB.Name = "lblBVB"
        Me.lblBVB.Size = New System.Drawing.Size(88, 13)
        Me.lblBVB.TabIndex = 12
        Me.lblBVB.Text = "Bảo Việt Bank"
        '
        'chkSTBActive
        '
        Me.chkSTBActive.AutoSize = True
        Me.chkSTBActive.Location = New System.Drawing.Point(759, 28)
        Me.chkSTBActive.Name = "chkSTBActive"
        Me.chkSTBActive.Size = New System.Drawing.Size(56, 17)
        Me.chkSTBActive.TabIndex = 11
        Me.chkSTBActive.Text = "Active"
        Me.chkSTBActive.UseVisualStyleBackColor = True
        '
        'lblSTBStatus
        '
        Me.lblSTBStatus.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.lblSTBStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSTBStatus.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblSTBStatus.Location = New System.Drawing.Point(710, 30)
        Me.lblSTBStatus.Name = "lblSTBStatus"
        Me.lblSTBStatus.Size = New System.Drawing.Size(43, 13)
        Me.lblSTBStatus.TabIndex = 10
        Me.lblSTBStatus.Text = "Online"
        '
        'chkBIDVActive
        '
        Me.chkBIDVActive.AutoSize = True
        Me.chkBIDVActive.Location = New System.Drawing.Point(149, 28)
        Me.chkBIDVActive.Name = "chkBIDVActive"
        Me.chkBIDVActive.Size = New System.Drawing.Size(56, 17)
        Me.chkBIDVActive.TabIndex = 8
        Me.chkBIDVActive.Text = "Active"
        Me.chkBIDVActive.UseVisualStyleBackColor = True
        '
        'lblBIDVStatus
        '
        Me.lblBIDVStatus.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.lblBIDVStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBIDVStatus.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblBIDVStatus.Location = New System.Drawing.Point(100, 30)
        Me.lblBIDVStatus.Name = "lblBIDVStatus"
        Me.lblBIDVStatus.Size = New System.Drawing.Size(43, 13)
        Me.lblBIDVStatus.TabIndex = 7
        Me.lblBIDVStatus.Text = "Online"
        '
        'chkDABActive
        '
        Me.chkDABActive.AutoSize = True
        Me.chkDABActive.Location = New System.Drawing.Point(363, 28)
        Me.chkDABActive.Name = "chkDABActive"
        Me.chkDABActive.Size = New System.Drawing.Size(56, 17)
        Me.chkDABActive.TabIndex = 6
        Me.chkDABActive.Text = "Active"
        Me.chkDABActive.UseVisualStyleBackColor = True
        '
        'lblDABStatus
        '
        Me.lblDABStatus.AutoSize = True
        Me.lblDABStatus.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.lblDABStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDABStatus.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblDABStatus.Location = New System.Drawing.Point(314, 30)
        Me.lblDABStatus.Name = "lblDABStatus"
        Me.lblDABStatus.Size = New System.Drawing.Size(43, 13)
        Me.lblDABStatus.TabIndex = 5
        Me.lblDABStatus.Text = "Online"
        '
        'chkBVBActive
        '
        Me.chkBVBActive.AutoSize = True
        Me.chkBVBActive.Location = New System.Drawing.Point(571, 28)
        Me.chkBVBActive.Name = "chkBVBActive"
        Me.chkBVBActive.Size = New System.Drawing.Size(56, 17)
        Me.chkBVBActive.TabIndex = 4
        Me.chkBVBActive.Text = "Active"
        Me.chkBVBActive.UseVisualStyleBackColor = True
        '
        'lblBVBStatus
        '
        Me.lblBVBStatus.AutoSize = True
        Me.lblBVBStatus.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.lblBVBStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBVBStatus.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblBVBStatus.Location = New System.Drawing.Point(522, 30)
        Me.lblBVBStatus.Name = "lblBVBStatus"
        Me.lblBVBStatus.Size = New System.Drawing.Size(43, 13)
        Me.lblBVBStatus.TabIndex = 3
        Me.lblBVBStatus.Text = "Online"
        '
        'txtLog
        '
        Me.txtLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtLog.Location = New System.Drawing.Point(3, 143)
        Me.txtLog.Name = "txtLog"
        Me.txtLog.Size = New System.Drawing.Size(887, 328)
        Me.txtLog.TabIndex = 2
        Me.txtLog.Text = ""
        '
        'frmHoldControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(893, 474)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmHoldControl"
        Me.Text = "Vận hành queue Hold/Unhold với ngân hàng"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.grpConfig.ResumeLayout(False)
        Me.grpConfig.PerformLayout()
        Me.grpBankInfo.ResumeLayout(False)
        Me.grpBankInfo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents grpBankInfo As System.Windows.Forms.GroupBox
    Friend WithEvents grpConfig As System.Windows.Forms.GroupBox
    Friend WithEvents txtInterval As System.Windows.Forms.TextBox
    Friend WithEvents lblInterval As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents lblMS As System.Windows.Forms.Label
    Friend WithEvents lblBVBStatus As System.Windows.Forms.Label
    Friend WithEvents cmdAction As System.Windows.Forms.Button
    Friend WithEvents chkBIDVActive As System.Windows.Forms.CheckBox
    Friend WithEvents lblBIDVStatus As System.Windows.Forms.Label
    Friend WithEvents chkDABActive As System.Windows.Forms.CheckBox
    Friend WithEvents lblDABStatus As System.Windows.Forms.Label
    Friend WithEvents chkBVBActive As System.Windows.Forms.CheckBox
    Friend WithEvents chkSTBActive As System.Windows.Forms.CheckBox
    Friend WithEvents lblSTBStatus As System.Windows.Forms.Label
    Friend WithEvents txtQueueSize As System.Windows.Forms.TextBox
    Friend WithEvents lblQueueSize As System.Windows.Forms.Label
    Friend WithEvents lblBIDV As System.Windows.Forms.Label
    Friend WithEvents lblDAB As System.Windows.Forms.Label
    Friend WithEvents lblBVB As System.Windows.Forms.Label
    Friend WithEvents lblSTB As System.Windows.Forms.Label
    Friend WithEvents txtLog As System.Windows.Forms.RichTextBox
    Friend WithEvents cmdBANKREQUEST As System.Windows.Forms.Button
End Class
