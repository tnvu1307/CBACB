<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCompareTradingResult
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
        Me.TabControlTrading = New System.Windows.Forms.TabControl
        Me.TabTradingHNX = New System.Windows.Forms.TabPage
        Me.lbfile = New System.Windows.Forms.Label
        Me.btnCompare = New System.Windows.Forms.Button
        Me.btnReadFile = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.PnResultLoadHNX = New System.Windows.Forms.Panel
        Me.Button2 = New System.Windows.Forms.Button
        Me.txtPath = New System.Windows.Forms.TextBox
        Me.TabTradingHOSE = New System.Windows.Forms.TabPage
        Me.lbType = New System.Windows.Forms.Label
        Me.CboxTypeFile = New System.Windows.Forms.ComboBox
        Me.btnCompareHO = New System.Windows.Forms.Button
        Me.btnReadFileHO = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.PnHOSE = New System.Windows.Forms.Panel
        Me.Button1 = New System.Windows.Forms.Button
        Me.txtPathHOSE = New System.Windows.Forms.TextBox
        Me.TabTradingUPCOM = New System.Windows.Forms.TabPage
        Me.btnReadFileUp = New System.Windows.Forms.Button
        Me.GroupBoxupcom = New System.Windows.Forms.GroupBox
        Me.PnUpcom = New System.Windows.Forms.Panel
        Me.btnCompareUP = New System.Windows.Forms.Button
        Me.btnbrowseupcom = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtPathUP = New System.Windows.Forms.TextBox
        Me.btnExport = New System.Windows.Forms.Button
        Me.TabControlTrading.SuspendLayout()
        Me.TabTradingHNX.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabTradingHOSE.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabTradingUPCOM.SuspendLayout()
        Me.GroupBoxupcom.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControlTrading
        '
        Me.TabControlTrading.Controls.Add(Me.TabTradingHNX)
        Me.TabControlTrading.Controls.Add(Me.TabTradingHOSE)
        Me.TabControlTrading.Controls.Add(Me.TabTradingUPCOM)
        Me.TabControlTrading.Location = New System.Drawing.Point(12, 6)
        Me.TabControlTrading.Name = "TabControlTrading"
        Me.TabControlTrading.SelectedIndex = 0
        Me.TabControlTrading.Size = New System.Drawing.Size(733, 410)
        Me.TabControlTrading.TabIndex = 0
        Me.TabControlTrading.Tag = "TabControlTrading"
        '
        'TabTradingHNX
        '
        Me.TabTradingHNX.Controls.Add(Me.lbfile)
        Me.TabTradingHNX.Controls.Add(Me.btnCompare)
        Me.TabTradingHNX.Controls.Add(Me.btnReadFile)
        Me.TabTradingHNX.Controls.Add(Me.GroupBox1)
        Me.TabTradingHNX.Controls.Add(Me.Button2)
        Me.TabTradingHNX.Controls.Add(Me.txtPath)
        Me.TabTradingHNX.Location = New System.Drawing.Point(4, 22)
        Me.TabTradingHNX.Name = "TabTradingHNX"
        Me.TabTradingHNX.Padding = New System.Windows.Forms.Padding(3)
        Me.TabTradingHNX.Size = New System.Drawing.Size(725, 384)
        Me.TabTradingHNX.TabIndex = 0
        Me.TabTradingHNX.Text = "HNX"
        Me.TabTradingHNX.UseVisualStyleBackColor = True
        '
        'lbfile
        '
        Me.lbfile.AutoSize = True
        Me.lbfile.Location = New System.Drawing.Point(196, 22)
        Me.lbfile.Name = "lbfile"
        Me.lbfile.Size = New System.Drawing.Size(54, 13)
        Me.lbfile.TabIndex = 0
        Me.lbfile.Tag = "lbfile"
        Me.lbfile.Text = "Chọn file :"
        '
        'btnCompare
        '
        Me.btnCompare.Location = New System.Drawing.Point(643, 15)
        Me.btnCompare.Name = "btnCompare"
        Me.btnCompare.Size = New System.Drawing.Size(75, 20)
        Me.btnCompare.TabIndex = 5
        Me.btnCompare.Tag = "btnCompare"
        Me.btnCompare.Text = "btnCompare"
        Me.btnCompare.UseVisualStyleBackColor = True
        '
        'btnReadFile
        '
        Me.btnReadFile.Location = New System.Drawing.Point(559, 15)
        Me.btnReadFile.Name = "btnReadFile"
        Me.btnReadFile.Size = New System.Drawing.Size(78, 20)
        Me.btnReadFile.TabIndex = 4
        Me.btnReadFile.Tag = "btnReadFile"
        Me.btnReadFile.Text = "btnReadFile"
        Me.btnReadFile.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PnResultLoadHNX)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(718, 337)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Tag = "GroupBox1"
        Me.GroupBox1.Text = "GroupBox1"
        '
        'PnResultLoadHNX
        '
        Me.PnResultLoadHNX.Location = New System.Drawing.Point(6, 19)
        Me.PnResultLoadHNX.Name = "PnResultLoadHNX"
        Me.PnResultLoadHNX.Size = New System.Drawing.Size(706, 312)
        Me.PnResultLoadHNX.TabIndex = 0
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(531, 15)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(22, 20)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "..."
        Me.Button2.UseVisualStyleBackColor = True
        '
        'txtPath
        '
        Me.txtPath.Location = New System.Drawing.Point(263, 15)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.Size = New System.Drawing.Size(261, 20)
        Me.txtPath.TabIndex = 0
        '
        'TabTradingHOSE
        '
        Me.TabTradingHOSE.Controls.Add(Me.lbType)
        Me.TabTradingHOSE.Controls.Add(Me.CboxTypeFile)
        Me.TabTradingHOSE.Controls.Add(Me.btnCompareHO)
        Me.TabTradingHOSE.Controls.Add(Me.btnReadFileHO)
        Me.TabTradingHOSE.Controls.Add(Me.GroupBox2)
        Me.TabTradingHOSE.Controls.Add(Me.Button1)
        Me.TabTradingHOSE.Controls.Add(Me.txtPathHOSE)
        Me.TabTradingHOSE.Location = New System.Drawing.Point(4, 22)
        Me.TabTradingHOSE.Name = "TabTradingHOSE"
        Me.TabTradingHOSE.Padding = New System.Windows.Forms.Padding(3)
        Me.TabTradingHOSE.Size = New System.Drawing.Size(725, 384)
        Me.TabTradingHOSE.TabIndex = 1
        Me.TabTradingHOSE.Text = "HOSE"
        Me.TabTradingHOSE.UseVisualStyleBackColor = True
        '
        'lbType
        '
        Me.lbType.AutoSize = True
        Me.lbType.Location = New System.Drawing.Point(85, 20)
        Me.lbType.Name = "lbType"
        Me.lbType.Size = New System.Drawing.Size(56, 13)
        Me.lbType.TabIndex = 6
        Me.lbType.Tag = "lbType"
        Me.lbType.Text = "Loại lệnh :"
        '
        'CboxTypeFile
        '
        Me.CboxTypeFile.FormattingEnabled = True
        Me.CboxTypeFile.Location = New System.Drawing.Point(147, 15)
        Me.CboxTypeFile.Name = "CboxTypeFile"
        Me.CboxTypeFile.Size = New System.Drawing.Size(108, 21)
        Me.CboxTypeFile.TabIndex = 5
        '
        'btnCompareHO
        '
        Me.btnCompareHO.Location = New System.Drawing.Point(645, 15)
        Me.btnCompareHO.Name = "btnCompareHO"
        Me.btnCompareHO.Size = New System.Drawing.Size(75, 20)
        Me.btnCompareHO.TabIndex = 4
        Me.btnCompareHO.Tag = "btnCompareHO"
        Me.btnCompareHO.Text = "btnCompare"
        Me.btnCompareHO.UseVisualStyleBackColor = True
        '
        'btnReadFileHO
        '
        Me.btnReadFileHO.Location = New System.Drawing.Point(564, 15)
        Me.btnReadFileHO.Name = "btnReadFileHO"
        Me.btnReadFileHO.Size = New System.Drawing.Size(75, 20)
        Me.btnReadFileHO.TabIndex = 3
        Me.btnReadFileHO.Tag = "btnReadFileHO"
        Me.btnReadFileHO.Text = "btnReadFile"
        Me.btnReadFileHO.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.PnHOSE)
        Me.GroupBox2.Location = New System.Drawing.Point(2, 41)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(721, 340)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Tag = "GroupBox2"
        Me.GroupBox2.Text = "GroupBox2"
        '
        'PnHOSE
        '
        Me.PnHOSE.Location = New System.Drawing.Point(6, 19)
        Me.PnHOSE.Name = "PnHOSE"
        Me.PnHOSE.Size = New System.Drawing.Size(703, 315)
        Me.PnHOSE.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(528, 15)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(26, 20)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtPathHOSE
        '
        Me.txtPathHOSE.Location = New System.Drawing.Point(261, 15)
        Me.txtPathHOSE.Name = "txtPathHOSE"
        Me.txtPathHOSE.Size = New System.Drawing.Size(261, 20)
        Me.txtPathHOSE.TabIndex = 0
        '
        'TabTradingUPCOM
        '
        Me.TabTradingUPCOM.Controls.Add(Me.btnReadFileUp)
        Me.TabTradingUPCOM.Controls.Add(Me.GroupBoxupcom)
        Me.TabTradingUPCOM.Controls.Add(Me.btnCompareUP)
        Me.TabTradingUPCOM.Controls.Add(Me.btnbrowseupcom)
        Me.TabTradingUPCOM.Controls.Add(Me.Label3)
        Me.TabTradingUPCOM.Controls.Add(Me.txtPathUP)
        Me.TabTradingUPCOM.Location = New System.Drawing.Point(4, 22)
        Me.TabTradingUPCOM.Name = "TabTradingUPCOM"
        Me.TabTradingUPCOM.Size = New System.Drawing.Size(725, 384)
        Me.TabTradingUPCOM.TabIndex = 2
        Me.TabTradingUPCOM.Text = "UPCOM"
        Me.TabTradingUPCOM.UseVisualStyleBackColor = True
        '
        'btnReadFileUp
        '
        Me.btnReadFileUp.Location = New System.Drawing.Point(562, 15)
        Me.btnReadFileUp.Name = "btnReadFileUp"
        Me.btnReadFileUp.Size = New System.Drawing.Size(75, 20)
        Me.btnReadFileUp.TabIndex = 1
        Me.btnReadFileUp.Text = "Button4"
        Me.btnReadFileUp.UseVisualStyleBackColor = True
        '
        'GroupBoxupcom
        '
        Me.GroupBoxupcom.Controls.Add(Me.PnUpcom)
        Me.GroupBoxupcom.Location = New System.Drawing.Point(5, 41)
        Me.GroupBoxupcom.Name = "GroupBoxupcom"
        Me.GroupBoxupcom.Size = New System.Drawing.Size(717, 343)
        Me.GroupBoxupcom.TabIndex = 6
        Me.GroupBoxupcom.TabStop = False
        Me.GroupBoxupcom.Text = "GroupBox3"
        '
        'PnUpcom
        '
        Me.PnUpcom.Location = New System.Drawing.Point(6, 19)
        Me.PnUpcom.Name = "PnUpcom"
        Me.PnUpcom.Size = New System.Drawing.Size(705, 318)
        Me.PnUpcom.TabIndex = 0
        '
        'btnCompareUP
        '
        Me.btnCompareUP.Location = New System.Drawing.Point(643, 15)
        Me.btnCompareUP.Name = "btnCompareUP"
        Me.btnCompareUP.Size = New System.Drawing.Size(77, 20)
        Me.btnCompareUP.TabIndex = 5
        Me.btnCompareUP.Text = "Button3"
        Me.btnCompareUP.UseVisualStyleBackColor = True
        '
        'btnbrowseupcom
        '
        Me.btnbrowseupcom.Location = New System.Drawing.Point(508, 15)
        Me.btnbrowseupcom.Name = "btnbrowseupcom"
        Me.btnbrowseupcom.Size = New System.Drawing.Size(29, 20)
        Me.btnbrowseupcom.TabIndex = 4
        Me.btnbrowseupcom.Text = "..."
        Me.btnbrowseupcom.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(174, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Chọn file :"
        '
        'txtPathUP
        '
        Me.txtPathUP.Location = New System.Drawing.Point(237, 15)
        Me.txtPathUP.Name = "txtPathUP"
        Me.txtPathUP.Size = New System.Drawing.Size(261, 20)
        Me.txtPathUP.TabIndex = 2
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(604, 435)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(141, 23)
        Me.btnExport.TabIndex = 1
        Me.btnExport.Tag = "btnExport"
        Me.btnExport.Text = "btnExport"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'frmCompareTradingResult
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(757, 470)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.TabControlTrading)
        Me.KeyPreview = True
        Me.Name = "frmCompareTradingResult"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "So sánh kết quả khớp lệnh với sở GDCK"
        Me.Text = "frmCompareTradingResult"
        Me.TabControlTrading.ResumeLayout(False)
        Me.TabTradingHNX.ResumeLayout(False)
        Me.TabTradingHNX.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.TabTradingHOSE.ResumeLayout(False)
        Me.TabTradingHOSE.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.TabTradingUPCOM.ResumeLayout(False)
        Me.TabTradingUPCOM.PerformLayout()
        Me.GroupBoxupcom.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControlTrading As System.Windows.Forms.TabControl
    Friend WithEvents TabTradingHNX As System.Windows.Forms.TabPage
    Friend WithEvents TabTradingHOSE As System.Windows.Forms.TabPage
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents txtPath As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents PnResultLoadHNX As System.Windows.Forms.Panel
    Friend WithEvents btnCompare As System.Windows.Forms.Button
    Friend WithEvents btnReadFile As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents PnHOSE As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtPathHOSE As System.Windows.Forms.TextBox
    Friend WithEvents btnReadFileHO As System.Windows.Forms.Button
    Friend WithEvents btnCompareHO As System.Windows.Forms.Button
    Friend WithEvents CboxTypeFile As System.Windows.Forms.ComboBox
    Friend WithEvents lbType As System.Windows.Forms.Label
    Friend WithEvents lbfile As System.Windows.Forms.Label
    Friend WithEvents TabTradingUPCOM As System.Windows.Forms.TabPage
    Friend WithEvents btnCompareUP As System.Windows.Forms.Button
    Friend WithEvents btnbrowseupcom As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPathUP As System.Windows.Forms.TextBox
    Friend WithEvents btnReadFileUp As System.Windows.Forms.Button
    Friend WithEvents GroupBoxupcom As System.Windows.Forms.GroupBox
    Friend WithEvents PnUpcom As System.Windows.Forms.Panel
    Friend WithEvents btnExport As System.Windows.Forms.Button
End Class
