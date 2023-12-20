<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmShowNewsDetail
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
        Me.reDetail = New DevExpress.XtraRichEdit.RichEditControl
        Me.SuspendLayout()
        '
        'reDetail
        '
        Me.reDetail.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple
        Me.reDetail.Appearance.Text.Options.UseTextOptions = True
        Me.reDetail.Appearance.Text.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.reDetail.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.reDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.reDetail.Location = New System.Drawing.Point(0, 0)
        Me.reDetail.Name = "reDetail"
        Me.reDetail.Options.DocumentCapabilities.InlinePictures = DevExpress.XtraRichEdit.DocumentCapability.Enabled
        Me.reDetail.Options.HorizontalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden
        Me.reDetail.Options.VerticalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden
        Me.reDetail.ReadOnly = True
        Me.reDetail.Size = New System.Drawing.Size(878, 466)
        Me.reDetail.TabIndex = 0
        '
        'frmShowNewsDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(878, 466)
        Me.Controls.Add(Me.reDetail)
        Me.Name = "frmShowNewsDetail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmShowNewsDetail"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents reDetail As DevExpress.XtraRichEdit.RichEditControl
End Class
