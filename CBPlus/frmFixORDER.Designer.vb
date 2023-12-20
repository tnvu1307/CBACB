<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFixORDER
    Inherits AppCore.frmSearch

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'grbSearchFilter
        '
        Me.grbSearchFilter.Text = "Điều kiện tìm kiếm:"
        '
        'grbSearchResult
        '
        Me.grbSearchResult.Size = New System.Drawing.Size(870, 249)
        Me.grbSearchResult.Text = "Kết quả tìm kiếm:"
        '
        'btnNEXT
        '
        Me.btnNEXT.Location = New System.Drawing.Point(64, 458)
        Me.btnNEXT.Text = "Sau"
        '
        'btnBACK
        '
        Me.btnBACK.Location = New System.Drawing.Point(8, 458)
        Me.btnBACK.Text = "Trước"
        '
        'chkALL
        '
        Me.chkALL.Location = New System.Drawing.Point(132, 461)
        '
        'chkExeAll
        '
        Me.chkExeAll.Location = New System.Drawing.Point(688, 462)
        '
        'chkauto
        '
        Me.chkauto.Location = New System.Drawing.Point(416, 462)
        '
        'frmFixORDER
        '
        Me.ClientSize = New System.Drawing.Size(880, 506)
        Me.Name = "frmFixORDER"
        Me.Text = ""
        Me.ResumeLayout(False)

    End Sub

End Class
