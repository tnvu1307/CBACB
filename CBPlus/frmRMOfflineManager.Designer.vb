<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRMOfflineManager
    Inherits DevExpress.XtraEditors.XtraForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRMOfflineManager))
        Me.pnpSearchResult = New System.Windows.Forms.Panel
        Me.grbSearchResult = New System.Windows.Forms.GroupBox
        Me.chkisSum = New System.Windows.Forms.CheckBox
        Me.pnsSearchResult = New System.Windows.Forms.Panel
        Me.chkAll = New System.Windows.Forms.CheckBox
        Me.btnExport = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnLoadData = New System.Windows.Forms.Button
        Me.btnSync = New System.Windows.Forms.Button
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.mnuGrid = New System.Windows.Forms.ContextMenu
        Me.mnuSelectAll = New System.Windows.Forms.MenuItem
        Me.mnuDeselectAll = New System.Windows.Forms.MenuItem
        Me.tabIorE = New System.Windows.Forms.TabPage
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lblTXDATE = New System.Windows.Forms.Label
        Me.dtpTXDATE = New System.Windows.Forms.DateTimePicker
        Me.btnSearch = New System.Windows.Forms.Button
        Me.cboStatus = New AppCore.ComboBoxEx
        Me.txtCondition = New System.Windows.Forms.TextBox
        Me.lblStatus = New System.Windows.Forms.Label
        Me.chkIsSigner = New System.Windows.Forms.CheckBox
        Me.cboTranCode = New AppCore.ComboBoxEx
        Me.cboCondition = New AppCore.ComboBoxEx
        Me.lblCondition = New System.Windows.Forms.Label
        Me.cboBankName = New AppCore.ComboBoxEx
        Me.lblTranCode = New System.Windows.Forms.Label
        Me.lblBankName = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblBrowse = New System.Windows.Forms.Label
        Me.lblPath = New System.Windows.Forms.Label
        Me.btnBrowse = New System.Windows.Forms.Button
        Me.cboFileType = New AppCore.ComboBoxEx
        Me.lblFileType = New System.Windows.Forms.Label
        Me.txtPath = New System.Windows.Forms.TextBox
        Me.tabRMOfflineManager = New System.Windows.Forms.TabControl
        Me.btnExport1 = New System.Windows.Forms.Button
        Me.pnpSearchResult.SuspendLayout()
        Me.grbSearchResult.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.tabIorE.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tabRMOfflineManager.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnpSearchResult
        '
        Me.pnpSearchResult.Controls.Add(Me.grbSearchResult)
        Me.pnpSearchResult.Location = New System.Drawing.Point(6, 154)
        Me.pnpSearchResult.Name = "pnpSearchResult"
        Me.pnpSearchResult.Size = New System.Drawing.Size(904, 396)
        Me.pnpSearchResult.TabIndex = 2
        '
        'grbSearchResult
        '
        Me.grbSearchResult.Controls.Add(Me.chkisSum)
        Me.grbSearchResult.Controls.Add(Me.pnsSearchResult)
        Me.grbSearchResult.Controls.Add(Me.chkAll)
        Me.grbSearchResult.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grbSearchResult.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbSearchResult.Location = New System.Drawing.Point(0, 0)
        Me.grbSearchResult.Name = "grbSearchResult"
        Me.grbSearchResult.Size = New System.Drawing.Size(904, 396)
        Me.grbSearchResult.TabIndex = 26
        Me.grbSearchResult.TabStop = False
        Me.grbSearchResult.Tag = "grbSearchResult"
        Me.grbSearchResult.Text = "Kết quả tìm kiếm"
        '
        'chkisSum
        '
        Me.chkisSum.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkisSum.AutoSize = True
        Me.chkisSum.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkisSum.Checked = True
        Me.chkisSum.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkisSum.Location = New System.Drawing.Point(123, 368)
        Me.chkisSum.Name = "chkisSum"
        Me.chkisSum.Size = New System.Drawing.Size(69, 17)
        Me.chkisSum.TabIndex = 35
        Me.chkisSum.Tag = "chkisSum"
        Me.chkisSum.Text = "chkisSum"
        Me.chkisSum.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkisSum.UseVisualStyleBackColor = True
        Me.chkisSum.Visible = False
        '
        'pnsSearchResult
        '
        Me.pnsSearchResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnsSearchResult.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnsSearchResult.Location = New System.Drawing.Point(3, 17)
        Me.pnsSearchResult.Name = "pnsSearchResult"
        Me.pnsSearchResult.Size = New System.Drawing.Size(898, 345)
        Me.pnsSearchResult.TabIndex = 0
        '
        'chkAll
        '
        Me.chkAll.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkAll.AutoSize = True
        Me.chkAll.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkAll.Location = New System.Drawing.Point(10, 368)
        Me.chkAll.Name = "chkAll"
        Me.chkAll.Size = New System.Drawing.Size(53, 17)
        Me.chkAll.TabIndex = 12
        Me.chkAll.Tag = "chkAll"
        Me.chkAll.Text = "chkAll"
        Me.chkAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkAll.UseVisualStyleBackColor = True
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(431, 16)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(80, 35)
        Me.btnExport.TabIndex = 32
        Me.btnExport.Tag = "btnExport"
        Me.btnExport.Text = "btnExport"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(622, 16)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(80, 35)
        Me.btnSave.TabIndex = 30
        Me.btnSave.Tag = "btnSave"
        Me.btnSave.Text = "btnSave"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(808, 16)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 35)
        Me.btnCancel.TabIndex = 31
        Me.btnCancel.Tag = "btnCancel"
        Me.btnCancel.Text = "btnCancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnLoadData
        '
        Me.btnLoadData.Location = New System.Drawing.Point(526, 16)
        Me.btnLoadData.Name = "btnLoadData"
        Me.btnLoadData.Size = New System.Drawing.Size(80, 35)
        Me.btnLoadData.TabIndex = 29
        Me.btnLoadData.Tag = "btnLoadData"
        Me.btnLoadData.Text = "btnLoadData"
        Me.btnLoadData.UseVisualStyleBackColor = True
        '
        'btnSync
        '
        Me.btnSync.Location = New System.Drawing.Point(716, 16)
        Me.btnSync.Name = "btnSync"
        Me.btnSync.Size = New System.Drawing.Size(80, 35)
        Me.btnSync.TabIndex = 34
        Me.btnSync.Tag = "btnSync"
        Me.btnSync.Text = "btnSync"
        Me.btnSync.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.GroupBox3)
        Me.Panel4.Location = New System.Drawing.Point(5, 545)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(904, 63)
        Me.Panel4.TabIndex = 0
        Me.Panel4.Tag = "Panel4"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnExport1)
        Me.GroupBox3.Controls.Add(Me.btnExport)
        Me.GroupBox3.Controls.Add(Me.btnLoadData)
        Me.GroupBox3.Controls.Add(Me.btnSync)
        Me.GroupBox3.Controls.Add(Me.btnSave)
        Me.GroupBox3.Controls.Add(Me.btnCancel)
        Me.GroupBox3.Location = New System.Drawing.Point(4, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(895, 57)
        Me.GroupBox3.TabIndex = 35
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Tag = "GroupBox3"
        '
        'mnuGrid
        '
        Me.mnuGrid.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuSelectAll, Me.mnuDeselectAll})
        '
        'mnuSelectAll
        '
        Me.mnuSelectAll.Index = 0
        Me.mnuSelectAll.Tag = "mnuSelectAll"
        Me.mnuSelectAll.Text = "Select all"
        '
        'mnuDeselectAll
        '
        Me.mnuDeselectAll.Index = 1
        Me.mnuDeselectAll.Tag = "mnuDeselectAll"
        Me.mnuDeselectAll.Text = "Deselect all"
        '
        'tabIorE
        '
        Me.tabIorE.Controls.Add(Me.Panel2)
        Me.tabIorE.Controls.Add(Me.Panel4)
        Me.tabIorE.Controls.Add(Me.pnpSearchResult)
        Me.tabIorE.Controls.Add(Me.Panel1)
        Me.tabIorE.Location = New System.Drawing.Point(4, 22)
        Me.tabIorE.Name = "tabIorE"
        Me.tabIorE.Padding = New System.Windows.Forms.Padding(3)
        Me.tabIorE.Size = New System.Drawing.Size(913, 611)
        Me.tabIorE.TabIndex = 1
        Me.tabIorE.Tag = "tabIorE"
        Me.tabIorE.Text = "tabIorE"
        Me.tabIorE.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.GroupBox2)
        Me.Panel2.Location = New System.Drawing.Point(4, 82)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(906, 70)
        Me.Panel2.TabIndex = 33
        Me.Panel2.Tag = "Panel2"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblTXDATE)
        Me.GroupBox2.Controls.Add(Me.dtpTXDATE)
        Me.GroupBox2.Controls.Add(Me.btnSearch)
        Me.GroupBox2.Controls.Add(Me.cboStatus)
        Me.GroupBox2.Controls.Add(Me.txtCondition)
        Me.GroupBox2.Controls.Add(Me.lblStatus)
        Me.GroupBox2.Controls.Add(Me.chkIsSigner)
        Me.GroupBox2.Controls.Add(Me.cboTranCode)
        Me.GroupBox2.Controls.Add(Me.cboCondition)
        Me.GroupBox2.Controls.Add(Me.lblCondition)
        Me.GroupBox2.Controls.Add(Me.cboBankName)
        Me.GroupBox2.Controls.Add(Me.lblTranCode)
        Me.GroupBox2.Controls.Add(Me.lblBankName)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 1)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(900, 65)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Tag = "GroupBox2"
        '
        'lblTXDATE
        '
        Me.lblTXDATE.AutoSize = True
        Me.lblTXDATE.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.lblTXDATE.Location = New System.Drawing.Point(550, 38)
        Me.lblTXDATE.Name = "lblTXDATE"
        Me.lblTXDATE.Size = New System.Drawing.Size(55, 13)
        Me.lblTXDATE.TabIndex = 39
        Me.lblTXDATE.Tag = "lblTXDATE"
        Me.lblTXDATE.Text = "lblTXDATE"
        Me.lblTXDATE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dtpTXDATE
        '
        Me.dtpTXDATE.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTXDATE.Location = New System.Drawing.Point(612, 34)
        Me.dtpTXDATE.Name = "dtpTXDATE"
        Me.dtpTXDATE.Size = New System.Drawing.Size(82, 21)
        Me.dtpTXDATE.TabIndex = 38
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(703, 13)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(97, 35)
        Me.btnSearch.TabIndex = 11
        Me.btnSearch.Tag = "btnSearch"
        Me.btnSearch.Text = "btnSearch"
        '
        'cboStatus
        '
        Me.cboStatus.BackColor = System.Drawing.Color.White
        Me.cboStatus.DisplayMember = "DISPLAY"
        Me.cboStatus.Location = New System.Drawing.Point(433, 34)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(111, 21)
        Me.cboStatus.TabIndex = 8
        Me.cboStatus.ValueMember = "VALUE"
        '
        'txtCondition
        '
        Me.txtCondition.BackColor = System.Drawing.Color.White
        Me.txtCondition.Location = New System.Drawing.Point(550, 10)
        Me.txtCondition.Name = "txtCondition"
        Me.txtCondition.Size = New System.Drawing.Size(144, 21)
        Me.txtCondition.TabIndex = 37
        Me.txtCondition.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.lblStatus.Location = New System.Drawing.Point(355, 38)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(48, 13)
        Me.lblStatus.TabIndex = 7
        Me.lblStatus.Tag = "lblStatus"
        Me.lblStatus.Text = "lblStatus"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkIsSigner
        '
        Me.chkIsSigner.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkIsSigner.AutoSize = True
        Me.chkIsSigner.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkIsSigner.Location = New System.Drawing.Point(810, 21)
        Me.chkIsSigner.Name = "chkIsSigner"
        Me.chkIsSigner.Size = New System.Drawing.Size(81, 17)
        Me.chkIsSigner.TabIndex = 11
        Me.chkIsSigner.Tag = "chkIsSigner"
        Me.chkIsSigner.Text = "chkIsSigner"
        Me.chkIsSigner.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkIsSigner.UseVisualStyleBackColor = True
        '
        'cboTranCode
        '
        Me.cboTranCode.BackColor = System.Drawing.Color.White
        Me.cboTranCode.DisplayMember = "DISPLAY"
        Me.cboTranCode.Location = New System.Drawing.Point(91, 38)
        Me.cboTranCode.Name = "cboTranCode"
        Me.cboTranCode.Size = New System.Drawing.Size(258, 21)
        Me.cboTranCode.TabIndex = 8
        Me.cboTranCode.ValueMember = "VALUE"
        '
        'cboCondition
        '
        Me.cboCondition.BackColor = System.Drawing.Color.White
        Me.cboCondition.DisplayMember = "DISPLAY"
        Me.cboCondition.Location = New System.Drawing.Point(433, 9)
        Me.cboCondition.Name = "cboCondition"
        Me.cboCondition.Size = New System.Drawing.Size(111, 21)
        Me.cboCondition.TabIndex = 36
        Me.cboCondition.ValueMember = "VALUE"
        '
        'lblCondition
        '
        Me.lblCondition.AutoSize = True
        Me.lblCondition.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.lblCondition.Location = New System.Drawing.Point(355, 13)
        Me.lblCondition.Name = "lblCondition"
        Me.lblCondition.Size = New System.Drawing.Size(62, 13)
        Me.lblCondition.TabIndex = 36
        Me.lblCondition.Tag = "lblCondition"
        Me.lblCondition.Text = "lblCondition"
        Me.lblCondition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboBankName
        '
        Me.cboBankName.BackColor = System.Drawing.Color.White
        Me.cboBankName.DisplayMember = "DISPLAY"
        Me.cboBankName.Location = New System.Drawing.Point(91, 13)
        Me.cboBankName.Name = "cboBankName"
        Me.cboBankName.Size = New System.Drawing.Size(258, 21)
        Me.cboBankName.TabIndex = 6
        Me.cboBankName.ValueMember = "VALUE"
        '
        'lblTranCode
        '
        Me.lblTranCode.AutoSize = True
        Me.lblTranCode.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.lblTranCode.Location = New System.Drawing.Point(6, 42)
        Me.lblTranCode.Name = "lblTranCode"
        Me.lblTranCode.Size = New System.Drawing.Size(64, 13)
        Me.lblTranCode.TabIndex = 7
        Me.lblTranCode.Tag = "lblTranCode"
        Me.lblTranCode.Text = "lblTranCode"
        Me.lblTranCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBankName
        '
        Me.lblBankName.AutoSize = True
        Me.lblBankName.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.lblBankName.Location = New System.Drawing.Point(6, 17)
        Me.lblBankName.Name = "lblBankName"
        Me.lblBankName.Size = New System.Drawing.Size(67, 13)
        Me.lblBankName.TabIndex = 0
        Me.lblBankName.Tag = "lblBankName"
        Me.lblBankName.Text = "lblBankName"
        Me.lblBankName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(907, 78)
        Me.Panel1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblBrowse)
        Me.GroupBox1.Controls.Add(Me.lblPath)
        Me.GroupBox1.Controls.Add(Me.btnBrowse)
        Me.GroupBox1.Controls.Add(Me.cboFileType)
        Me.GroupBox1.Controls.Add(Me.lblFileType)
        Me.GroupBox1.Controls.Add(Me.txtPath)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(901, 69)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Tag = "GroupBox1"
        '
        'lblBrowse
        '
        Me.lblBrowse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBrowse.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBrowse.ForeColor = System.Drawing.Color.Red
        Me.lblBrowse.Location = New System.Drawing.Point(836, 16)
        Me.lblBrowse.Name = "lblBrowse"
        Me.lblBrowse.Size = New System.Drawing.Size(56, 23)
        Me.lblBrowse.TabIndex = 13
        Me.lblBrowse.Tag = "lblBrowse"
        Me.lblBrowse.Text = "Chọn"
        '
        'lblPath
        '
        Me.lblPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPath.ForeColor = System.Drawing.Color.Red
        Me.lblPath.Location = New System.Drawing.Point(340, 16)
        Me.lblPath.Name = "lblPath"
        Me.lblPath.Size = New System.Drawing.Size(499, 23)
        Me.lblPath.TabIndex = 14
        Me.lblPath.Tag = "lblPath"
        Me.lblPath.Text = "Đường dẫn"
        '
        'btnBrowse
        '
        Me.btnBrowse.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBrowse.Location = New System.Drawing.Point(836, 40)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(56, 21)
        Me.btnBrowse.TabIndex = 17
        Me.btnBrowse.Tag = "btnBrowse"
        Me.btnBrowse.Text = ">>>"
        '
        'cboFileType
        '
        Me.cboFileType.BackColor = System.Drawing.Color.White
        Me.cboFileType.DisplayMember = "DISPLAY"
        Me.cboFileType.Location = New System.Drawing.Point(9, 40)
        Me.cboFileType.Name = "cboFileType"
        Me.cboFileType.Size = New System.Drawing.Size(331, 21)
        Me.cboFileType.TabIndex = 16
        Me.cboFileType.ValueMember = "VALUE"
        '
        'lblFileType
        '
        Me.lblFileType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFileType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFileType.ForeColor = System.Drawing.Color.Red
        Me.lblFileType.Location = New System.Drawing.Point(9, 16)
        Me.lblFileType.Name = "lblFileType"
        Me.lblFileType.Size = New System.Drawing.Size(331, 23)
        Me.lblFileType.TabIndex = 15
        Me.lblFileType.Tag = "lblFileType"
        Me.lblFileType.Text = "Loại file"
        '
        'txtPath
        '
        Me.txtPath.BackColor = System.Drawing.Color.White
        Me.txtPath.Location = New System.Drawing.Point(340, 40)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.Size = New System.Drawing.Size(496, 21)
        Me.txtPath.TabIndex = 12
        '
        'tabRMOfflineManager
        '
        Me.tabRMOfflineManager.Controls.Add(Me.tabIorE)
        Me.tabRMOfflineManager.Location = New System.Drawing.Point(2, 2)
        Me.tabRMOfflineManager.Name = "tabRMOfflineManager"
        Me.tabRMOfflineManager.SelectedIndex = 0
        Me.tabRMOfflineManager.Size = New System.Drawing.Size(921, 637)
        Me.tabRMOfflineManager.TabIndex = 34
        Me.tabRMOfflineManager.Tag = "tabRMOfflineManager"
        '
        'btnExport1
        '
        Me.btnExport1.Location = New System.Drawing.Point(335, 16)
        Me.btnExport1.Name = "btnExport1"
        Me.btnExport1.Size = New System.Drawing.Size(80, 35)
        Me.btnExport1.TabIndex = 32
        Me.btnExport1.Tag = "btnExport"
        Me.btnExport1.Text = "Export Grid"
        Me.btnExport1.UseVisualStyleBackColor = True
        '
        'frmRMOfflineManager
        '
        Me.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(926, 641)
        Me.Controls.Add(Me.tabRMOfflineManager)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmRMOfflineManager"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmRMOfflineManager"
        Me.pnpSearchResult.ResumeLayout(False)
        Me.grbSearchResult.ResumeLayout(False)
        Me.grbSearchResult.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.tabIorE.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tabRMOfflineManager.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnpSearchResult As System.Windows.Forms.Panel
    Friend WithEvents grbSearchResult As System.Windows.Forms.GroupBox
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnLoadData As System.Windows.Forms.Button
    Friend WithEvents btnSync As System.Windows.Forms.Button
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents mnuGrid As System.Windows.Forms.ContextMenu
    Friend WithEvents mnuSelectAll As System.Windows.Forms.MenuItem
    Friend WithEvents mnuDeselectAll As System.Windows.Forms.MenuItem
    Friend WithEvents chkAll As System.Windows.Forms.CheckBox
    Friend WithEvents chkisSum As System.Windows.Forms.CheckBox
    Friend WithEvents tabIorE As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkIsSigner As System.Windows.Forms.CheckBox
    Friend WithEvents cboStatus As AppCore.ComboBoxEx
    Friend WithEvents cboTranCode As AppCore.ComboBoxEx
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents cboBankName As AppCore.ComboBoxEx
    Friend WithEvents lblTranCode As System.Windows.Forms.Label
    Friend WithEvents lblBankName As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblBrowse As System.Windows.Forms.Label
    Friend WithEvents lblPath As System.Windows.Forms.Label
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents cboFileType As AppCore.ComboBoxEx
    Friend WithEvents lblFileType As System.Windows.Forms.Label
    Friend WithEvents txtPath As System.Windows.Forms.TextBox
    Friend WithEvents tabRMOfflineManager As System.Windows.Forms.TabControl
    Friend WithEvents pnsSearchResult As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblCondition As System.Windows.Forms.Label
    Friend WithEvents txtCondition As System.Windows.Forms.TextBox
    Friend WithEvents cboCondition As AppCore.ComboBoxEx
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lblTXDATE As System.Windows.Forms.Label
    Friend WithEvents dtpTXDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnExport1 As System.Windows.Forms.Button
End Class
