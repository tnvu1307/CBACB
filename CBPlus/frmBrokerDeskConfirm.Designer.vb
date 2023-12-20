<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBrokerDeskConfirm
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
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.pnDetail = New System.Windows.Forms.Panel
        Me.lblConfirmation = New System.Windows.Forms.Label
        Me.pnHeader = New System.Windows.Forms.Panel
        Me.lblAccountInfor = New System.Windows.Forms.Label
        Me.TableLayoutPanel1.SuspendLayout()
        Me.pnDetail.SuspendLayout()
        Me.pnHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(392, 358)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'pnDetail
        '
        Me.pnDetail.Controls.Add(Me.lblConfirmation)
        Me.pnDetail.Location = New System.Drawing.Point(0, 76)
        Me.pnDetail.Name = "pnDetail"
        Me.pnDetail.Size = New System.Drawing.Size(552, 270)
        Me.pnDetail.TabIndex = 1
        '
        'lblConfirmation
        '
        Me.lblConfirmation.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConfirmation.ForeColor = System.Drawing.Color.Red
        Me.lblConfirmation.Location = New System.Drawing.Point(12, 14)
        Me.lblConfirmation.Name = "lblConfirmation"
        Me.lblConfirmation.Size = New System.Drawing.Size(526, 234)
        Me.lblConfirmation.TabIndex = 0
        Me.lblConfirmation.Text = "LỤC ĐÌNH VINH, TK: 017C000001.MUA.ACB 10000@50"
        Me.lblConfirmation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnHeader
        '
        Me.pnHeader.Controls.Add(Me.lblAccountInfor)
        Me.pnHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnHeader.Name = "pnHeader"
        Me.pnHeader.Size = New System.Drawing.Size(550, 76)
        Me.pnHeader.TabIndex = 2
        '
        'lblAccountInfor
        '
        Me.lblAccountInfor.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccountInfor.Location = New System.Drawing.Point(6, 10)
        Me.lblAccountInfor.Name = "lblAccountInfor"
        Me.lblAccountInfor.Size = New System.Drawing.Size(538, 58)
        Me.lblAccountInfor.TabIndex = 0
        Me.lblAccountInfor.Text = "LỤC ĐÌNH VINH"
        Me.lblAccountInfor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmBrokerDeskConfirm
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(550, 399)
        Me.Controls.Add(Me.pnHeader)
        Me.Controls.Add(Me.pnDetail)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBrokerDeskConfirm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.pnDetail.ResumeLayout(False)
        Me.pnHeader.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents pnDetail As System.Windows.Forms.Panel
    Friend WithEvents pnHeader As System.Windows.Forms.Panel
    Friend WithEvents lblConfirmation As System.Windows.Forms.Label
    Friend WithEvents lblAccountInfor As System.Windows.Forms.Label

End Class
