<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMarketInfo
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnRefresh = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.lblInfoDetail = New System.Windows.Forms.Label
        Me.btnExport = New System.Windows.Forms.Button
        Me.RichEditControl1 = New DevExpress.XtraRichEdit.RichEditControl
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.RichEditControl1)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(685, 309)
        Me.Panel1.TabIndex = 0
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(541, 328)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(75, 23)
        Me.btnRefresh.TabIndex = 0
        Me.btnRefresh.Text = "Làm &Mới"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(622, 328)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "&Thoát"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lblInfoDetail
        '
        Me.lblInfoDetail.AutoSize = True
        Me.lblInfoDetail.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfoDetail.Location = New System.Drawing.Point(12, 332)
        Me.lblInfoDetail.Name = "lblInfoDetail"
        Me.lblInfoDetail.Size = New System.Drawing.Size(209, 15)
        Me.lblInfoDetail.TabIndex = 2
        Me.lblInfoDetail.Text = "Click đúp vào thông tin để xem chi tiết"
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(428, 328)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(107, 23)
        Me.btnExport.TabIndex = 3
        Me.btnExport.Text = "&Kết xuất nội dung"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'RichEditControl1
        '
        Me.RichEditControl1.Location = New System.Drawing.Point(250, 3)
        Me.RichEditControl1.Name = "RichEditControl1"
        Me.RichEditControl1.Size = New System.Drawing.Size(400, 200)
        Me.RichEditControl1.TabIndex = 4
        Me.RichEditControl1.Text = "RichEditControl1"
        Me.RichEditControl1.Visible = False
        '
        'FrmMarketInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(709, 361)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.lblInfoDetail)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(725, 399)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(725, 399)
        Me.Name = "FrmMarketInfo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmMarketInfo"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblInfoDetail As System.Windows.Forms.Label
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents RichEditControl1 As DevExpress.XtraRichEdit.RichEditControl
End Class
