Imports AppCore

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStockInfo
    Inherits System.Windows.Forms.Form
    Implements IForm

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
        Me.pnControls = New System.Windows.Forms.Panel
        Me.btnGetAllStockInfo = New System.Windows.Forms.Button
        Me.btnUpdatePrice = New System.Windows.Forms.Button
        Me.pnStockInfo = New System.Windows.Forms.Panel
        Me.pnControls.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnControls
        '
        Me.pnControls.Controls.Add(Me.btnGetAllStockInfo)
        Me.pnControls.Controls.Add(Me.btnUpdatePrice)
        Me.pnControls.Location = New System.Drawing.Point(2, 2)
        Me.pnControls.Name = "pnControls"
        Me.pnControls.Size = New System.Drawing.Size(787, 44)
        Me.pnControls.TabIndex = 0
        '
        'btnGetAllStockInfo
        '
        Me.btnGetAllStockInfo.Location = New System.Drawing.Point(673, 10)
        Me.btnGetAllStockInfo.Name = "btnGetAllStockInfo"
        Me.btnGetAllStockInfo.Size = New System.Drawing.Size(105, 23)
        Me.btnGetAllStockInfo.TabIndex = 1
        Me.btnGetAllStockInfo.Text = "Lấy thông tin giá"
        Me.btnGetAllStockInfo.UseVisualStyleBackColor = True
        '
        'btnUpdatePrice
        '
        Me.btnUpdatePrice.Location = New System.Drawing.Point(591, 10)
        Me.btnUpdatePrice.Name = "btnUpdatePrice"
        Me.btnUpdatePrice.Size = New System.Drawing.Size(76, 23)
        Me.btnUpdatePrice.TabIndex = 0
        Me.btnUpdatePrice.Text = "Cập nhật giá"
        Me.btnUpdatePrice.UseVisualStyleBackColor = True
        '
        'pnStockInfo
        '
        Me.pnStockInfo.Location = New System.Drawing.Point(2, 52)
        Me.pnStockInfo.Name = "pnStockInfo"
        Me.pnStockInfo.Size = New System.Drawing.Size(787, 505)
        Me.pnStockInfo.TabIndex = 1
        '
        'frmStockInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 563)
        Me.Controls.Add(Me.pnStockInfo)
        Me.Controls.Add(Me.pnControls)
        Me.Name = "frmStockInfo"
        Me.ShowInTaskbar = False
        Me.Text = "frmStockInfo"
        Me.pnControls.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnControls As System.Windows.Forms.Panel
    Friend WithEvents pnStockInfo As System.Windows.Forms.Panel
    Friend WithEvents btnGetAllStockInfo As System.Windows.Forms.Button
    Friend WithEvents btnUpdatePrice As System.Windows.Forms.Button
End Class
