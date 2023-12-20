<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReChangeRe
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReChangeRe))
        Me.grbRemiser = New System.Windows.Forms.GroupBox
        Me.ckAll = New System.Windows.Forms.CheckBox
        Me.pnlRemiser = New System.Windows.Forms.Panel
        Me.btnCancel = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblCaption = New System.Windows.Forms.Label
        Me.btnChange = New System.Windows.Forms.Button
        Me.mskReAcctno = New System.Windows.Forms.MaskedTextBox
        Me.lblReAcctno = New System.Windows.Forms.Label
        Me.lblReName = New System.Windows.Forms.Label
        Me.mskReDG = New System.Windows.Forms.MaskedTextBox
        Me.lblDGname = New System.Windows.Forms.Label
        Me.lblReDG = New System.Windows.Forms.Label
        Me.dtpFromDate = New System.Windows.Forms.DateTimePicker
        Me.dtpToDate = New System.Windows.Forms.DateTimePicker
        Me.lblFromDate = New System.Windows.Forms.Label
        Me.lblToDate = New System.Windows.Forms.Label
        Me.txtSearch = New System.Windows.Forms.TextBox
        Me.btnSearch = New System.Windows.Forms.Button
        Me.lblcareby = New System.Windows.Forms.Label
        Me.mskFUTREACCTNO = New System.Windows.Forms.MaskedTextBox
        Me.lblFUTREACCTNO = New System.Windows.Forms.Label
        Me.lblREFTNAME = New System.Windows.Forms.Label
        Me.mskFUTREACCTNONEW = New System.Windows.Forms.MaskedTextBox
        Me.lblREFTNAMENEW = New System.Windows.Forms.Label
        Me.lblFUTREACCTNONEW = New System.Windows.Forms.Label
        Me.lblFURDAYS = New System.Windows.Forms.Label
        Me.dtpFUTODATE = New System.Windows.Forms.DateTimePicker
        Me.lblFurToDate = New System.Windows.Forms.Label
        Me.mskFURDAYS = New System.Windows.Forms.MaskedTextBox
        Me.grpSearch = New System.Windows.Forms.GroupBox
        Me.cboCareby = New AppCore.ComboBoxEx
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lblTCBNew = New System.Windows.Forms.Label
        Me.lblCBNew = New System.Windows.Forms.Label
        Me.mskTCBNew = New System.Windows.Forms.MaskedTextBox
        Me.mskCBNew = New System.Windows.Forms.MaskedTextBox
        Me.lblFCarebyNew = New System.Windows.Forms.Label
        Me.lblCarebyNew = New System.Windows.Forms.Label
        Me.grbRemiser.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.grpSearch.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbRemiser
        '
        Me.grbRemiser.Controls.Add(Me.ckAll)
        Me.grbRemiser.Controls.Add(Me.pnlRemiser)
        Me.grbRemiser.Location = New System.Drawing.Point(12, 223)
        Me.grbRemiser.Name = "grbRemiser"
        Me.grbRemiser.Size = New System.Drawing.Size(862, 292)
        Me.grbRemiser.TabIndex = 0
        Me.grbRemiser.TabStop = False
        Me.grbRemiser.Tag = "grbRemiser"
        Me.grbRemiser.Text = "grbRemiser"
        '
        'ckAll
        '
        Me.ckAll.AutoSize = True
        Me.ckAll.Location = New System.Drawing.Point(31, 19)
        Me.ckAll.Name = "ckAll"
        Me.ckAll.Size = New System.Drawing.Size(37, 17)
        Me.ckAll.TabIndex = 16
        Me.ckAll.Tag = "ckAll"
        Me.ckAll.Text = "All"
        Me.ckAll.UseVisualStyleBackColor = True
        '
        'pnlRemiser
        '
        Me.pnlRemiser.Location = New System.Drawing.Point(15, 52)
        Me.pnlRemiser.Name = "pnlRemiser"
        Me.pnlRemiser.Size = New System.Drawing.Size(833, 232)
        Me.pnlRemiser.TabIndex = 0
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(691, 521)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(78, 25)
        Me.btnCancel.TabIndex = 17
        Me.btnCancel.Tag = "btnCancel"
        Me.btnCancel.Text = "btnCancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.Controls.Add(Me.lblCaption)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(886, 50)
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
        Me.btnChange.Location = New System.Drawing.Point(595, 521)
        Me.btnChange.Name = "btnChange"
        Me.btnChange.Size = New System.Drawing.Size(77, 25)
        Me.btnChange.TabIndex = 20
        Me.btnChange.Tag = "btnChange"
        Me.btnChange.Text = "btnChange"
        Me.btnChange.UseVisualStyleBackColor = True
        '
        'mskReAcctno
        '
        Me.mskReAcctno.Location = New System.Drawing.Point(116, 15)
        Me.mskReAcctno.Name = "mskReAcctno"
        Me.mskReAcctno.Size = New System.Drawing.Size(128, 20)
        Me.mskReAcctno.TabIndex = 1
        Me.mskReAcctno.Tag = "mskReAcctno"
        Me.mskReAcctno.Text = "mskReAcctno"
        '
        'lblReAcctno
        '
        Me.lblReAcctno.Location = New System.Drawing.Point(9, 18)
        Me.lblReAcctno.Name = "lblReAcctno"
        Me.lblReAcctno.Size = New System.Drawing.Size(65, 17)
        Me.lblReAcctno.TabIndex = 9
        Me.lblReAcctno.Tag = "lblReAcctno"
        Me.lblReAcctno.Text = "lblReAcctno"
        '
        'lblReName
        '
        Me.lblReName.AutoSize = True
        Me.lblReName.Location = New System.Drawing.Point(250, 18)
        Me.lblReName.Name = "lblReName"
        Me.lblReName.Size = New System.Drawing.Size(59, 13)
        Me.lblReName.TabIndex = 10
        Me.lblReName.Tag = "lblReName"
        Me.lblReName.Text = "lblReName"
        '
        'mskReDG
        '
        Me.mskReDG.Location = New System.Drawing.Point(116, 11)
        Me.mskReDG.Name = "mskReDG"
        Me.mskReDG.Size = New System.Drawing.Size(127, 20)
        Me.mskReDG.TabIndex = 6
        Me.mskReDG.Tag = "mskReDG"
        Me.mskReDG.Text = "mskReDG"
        '
        'lblDGname
        '
        Me.lblDGname.AutoSize = True
        Me.lblDGname.Location = New System.Drawing.Point(256, 11)
        Me.lblDGname.Name = "lblDGname"
        Me.lblDGname.Size = New System.Drawing.Size(59, 13)
        Me.lblDGname.TabIndex = 12
        Me.lblDGname.Tag = "lblDGname"
        Me.lblDGname.Text = "lblDGname"
        '
        'lblReDG
        '
        Me.lblReDG.Location = New System.Drawing.Point(11, 11)
        Me.lblReDG.Name = "lblReDG"
        Me.lblReDG.Size = New System.Drawing.Size(100, 13)
        Me.lblReDG.TabIndex = 13
        Me.lblReDG.Tag = "lblReDG"
        Me.lblReDG.Text = "TKMG hiện tại"
        '
        'dtpFromDate
        '
        Me.dtpFromDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFromDate.Location = New System.Drawing.Point(560, 11)
        Me.dtpFromDate.Name = "dtpFromDate"
        Me.dtpFromDate.Size = New System.Drawing.Size(128, 20)
        Me.dtpFromDate.TabIndex = 10
        Me.dtpFromDate.Tag = "dtpFromDate"
        Me.dtpFromDate.Value = New Date(2006, 10, 30, 0, 0, 0, 0)
        '
        'dtpToDate
        '
        Me.dtpToDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpToDate.Location = New System.Drawing.Point(560, 34)
        Me.dtpToDate.Name = "dtpToDate"
        Me.dtpToDate.Size = New System.Drawing.Size(128, 20)
        Me.dtpToDate.TabIndex = 11
        Me.dtpToDate.Tag = "dtpToDate"
        Me.dtpToDate.Value = New Date(2006, 10, 30, 0, 0, 0, 0)
        '
        'lblFromDate
        '
        Me.lblFromDate.AutoSize = True
        Me.lblFromDate.Location = New System.Drawing.Point(449, 11)
        Me.lblFromDate.Name = "lblFromDate"
        Me.lblFromDate.Size = New System.Drawing.Size(63, 13)
        Me.lblFromDate.TabIndex = 14
        Me.lblFromDate.Tag = "lblFromDate"
        Me.lblFromDate.Text = "lblFromDate"
        '
        'lblToDate
        '
        Me.lblToDate.AutoSize = True
        Me.lblToDate.Location = New System.Drawing.Point(449, 34)
        Me.lblToDate.Name = "lblToDate"
        Me.lblToDate.Size = New System.Drawing.Size(53, 13)
        Me.lblToDate.TabIndex = 15
        Me.lblToDate.Tag = "lblToDate"
        Me.lblToDate.Text = "lblToDate"
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(560, 40)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(276, 20)
        Me.txtSearch.TabIndex = 4
        Me.txtSearch.Tag = "txtSearch"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(446, 38)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(77, 24)
        Me.btnSearch.TabIndex = 5
        Me.btnSearch.Tag = "btnSearch"
        Me.btnSearch.Text = "btnSearch"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'lblcareby
        '
        Me.lblcareby.Location = New System.Drawing.Point(445, 18)
        Me.lblcareby.Name = "lblcareby"
        Me.lblcareby.Size = New System.Drawing.Size(109, 18)
        Me.lblcareby.TabIndex = 17
        Me.lblcareby.Tag = "lblCareby"
        Me.lblcareby.Text = "Careby"
        '
        'mskFUTREACCTNO
        '
        Me.mskFUTREACCTNO.Location = New System.Drawing.Point(116, 41)
        Me.mskFUTREACCTNO.Name = "mskFUTREACCTNO"
        Me.mskFUTREACCTNO.Size = New System.Drawing.Size(128, 20)
        Me.mskFUTREACCTNO.TabIndex = 2
        Me.mskFUTREACCTNO.Tag = "FUTREACCTNO"
        Me.mskFUTREACCTNO.Text = "mskFUTREACCTNO"
        '
        'lblFUTREACCTNO
        '
        Me.lblFUTREACCTNO.Location = New System.Drawing.Point(9, 44)
        Me.lblFUTREACCTNO.Name = "lblFUTREACCTNO"
        Me.lblFUTREACCTNO.Size = New System.Drawing.Size(102, 17)
        Me.lblFUTREACCTNO.TabIndex = 9
        Me.lblFUTREACCTNO.Tag = "lblFUTREACCTNO"
        Me.lblFUTREACCTNO.Text = "TKMG cũ tương lai:"
        '
        'lblREFTNAME
        '
        Me.lblREFTNAME.AutoSize = True
        Me.lblREFTNAME.Location = New System.Drawing.Point(250, 44)
        Me.lblREFTNAME.Name = "lblREFTNAME"
        Me.lblREFTNAME.Size = New System.Drawing.Size(76, 13)
        Me.lblREFTNAME.TabIndex = 10
        Me.lblREFTNAME.Tag = "lblREFTNAME"
        Me.lblREFTNAME.Text = "lblREFTNAME"
        '
        'mskFUTREACCTNONEW
        '
        Me.mskFUTREACCTNONEW.Location = New System.Drawing.Point(115, 58)
        Me.mskFUTREACCTNONEW.Name = "mskFUTREACCTNONEW"
        Me.mskFUTREACCTNONEW.Size = New System.Drawing.Size(128, 20)
        Me.mskFUTREACCTNONEW.TabIndex = 8
        Me.mskFUTREACCTNONEW.Tag = "mskFUTREACCTNONEW"
        Me.mskFUTREACCTNONEW.Text = "mskFUTREACCTNONEW"
        '
        'lblREFTNAMENEW
        '
        Me.lblREFTNAMENEW.AutoSize = True
        Me.lblREFTNAMENEW.Location = New System.Drawing.Point(254, 59)
        Me.lblREFTNAMENEW.Name = "lblREFTNAMENEW"
        Me.lblREFTNAMENEW.Size = New System.Drawing.Size(102, 13)
        Me.lblREFTNAMENEW.TabIndex = 12
        Me.lblREFTNAMENEW.Tag = "lblREFTNAMENEW"
        Me.lblREFTNAMENEW.Text = "lblREFTNAMENEW"
        '
        'lblFUTREACCTNONEW
        '
        Me.lblFUTREACCTNONEW.Location = New System.Drawing.Point(11, 59)
        Me.lblFUTREACCTNONEW.Name = "lblFUTREACCTNONEW"
        Me.lblFUTREACCTNONEW.Size = New System.Drawing.Size(100, 13)
        Me.lblFUTREACCTNONEW.TabIndex = 13
        Me.lblFUTREACCTNONEW.Tag = "lblFUTREACCTNONEW"
        Me.lblFUTREACCTNONEW.Text = "TKMG mới tương lai:"
        '
        'lblFURDAYS
        '
        Me.lblFURDAYS.AutoSize = True
        Me.lblFURDAYS.Location = New System.Drawing.Point(449, 59)
        Me.lblFURDAYS.Name = "lblFURDAYS"
        Me.lblFURDAYS.Size = New System.Drawing.Size(68, 13)
        Me.lblFURDAYS.TabIndex = 14
        Me.lblFURDAYS.Tag = "lblFURDAYS"
        Me.lblFURDAYS.Text = "lblFURDAYS"
        '
        'dtpFUTODATE
        '
        Me.dtpFUTODATE.CustomFormat = "dd/MM/yyyy"
        Me.dtpFUTODATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFUTODATE.Location = New System.Drawing.Point(560, 81)
        Me.dtpFUTODATE.Name = "dtpFUTODATE"
        Me.dtpFUTODATE.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.dtpFUTODATE.Size = New System.Drawing.Size(128, 20)
        Me.dtpFUTODATE.TabIndex = 13
        Me.dtpFUTODATE.Tag = "dtpToDate"
        Me.dtpFUTODATE.Value = New Date(2099, 1, 1, 0, 0, 0, 0)
        '
        'lblFurToDate
        '
        Me.lblFurToDate.AutoSize = True
        Me.lblFurToDate.Location = New System.Drawing.Point(449, 81)
        Me.lblFurToDate.Name = "lblFurToDate"
        Me.lblFurToDate.Size = New System.Drawing.Size(74, 13)
        Me.lblFurToDate.TabIndex = 15
        Me.lblFurToDate.Tag = "lblFurToDate"
        Me.lblFurToDate.Text = "Ngày hết hạn:"
        '
        'mskFURDAYS
        '
        Me.mskFURDAYS.Enabled = False
        Me.mskFURDAYS.Location = New System.Drawing.Point(560, 56)
        Me.mskFURDAYS.Name = "mskFURDAYS"
        Me.mskFURDAYS.Size = New System.Drawing.Size(128, 20)
        Me.mskFURDAYS.TabIndex = 12
        Me.mskFURDAYS.Tag = "mskFURDAYS"
        Me.mskFURDAYS.Text = "360"
        Me.mskFURDAYS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'grpSearch
        '
        Me.grpSearch.Controls.Add(Me.lblcareby)
        Me.grpSearch.Controls.Add(Me.btnSearch)
        Me.grpSearch.Controls.Add(Me.txtSearch)
        Me.grpSearch.Controls.Add(Me.cboCareby)
        Me.grpSearch.Controls.Add(Me.lblREFTNAME)
        Me.grpSearch.Controls.Add(Me.lblReName)
        Me.grpSearch.Controls.Add(Me.lblFUTREACCTNO)
        Me.grpSearch.Controls.Add(Me.mskFUTREACCTNO)
        Me.grpSearch.Controls.Add(Me.lblReAcctno)
        Me.grpSearch.Controls.Add(Me.mskReAcctno)
        Me.grpSearch.Location = New System.Drawing.Point(12, 49)
        Me.grpSearch.Name = "grpSearch"
        Me.grpSearch.Size = New System.Drawing.Size(856, 65)
        Me.grpSearch.TabIndex = 18
        Me.grpSearch.TabStop = False
        Me.grpSearch.Tag = "grpSearch"
        Me.grpSearch.Text = "Search"
        '
        'cboCareby
        '
        Me.cboCareby.DisplayMember = "DISPLAY"
        Me.cboCareby.Location = New System.Drawing.Point(560, 15)
        Me.cboCareby.Name = "cboCareby"
        Me.cboCareby.Size = New System.Drawing.Size(123, 21)
        Me.cboCareby.TabIndex = 3
        Me.cboCareby.ValueMember = "VALUE"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblTCBNew)
        Me.GroupBox2.Controls.Add(Me.lblCBNew)
        Me.GroupBox2.Controls.Add(Me.mskTCBNew)
        Me.GroupBox2.Controls.Add(Me.mskCBNew)
        Me.GroupBox2.Controls.Add(Me.lblFCarebyNew)
        Me.GroupBox2.Controls.Add(Me.lblCarebyNew)
        Me.GroupBox2.Controls.Add(Me.lblFurToDate)
        Me.GroupBox2.Controls.Add(Me.lblToDate)
        Me.GroupBox2.Controls.Add(Me.lblFURDAYS)
        Me.GroupBox2.Controls.Add(Me.lblFromDate)
        Me.GroupBox2.Controls.Add(Me.dtpFUTODATE)
        Me.GroupBox2.Controls.Add(Me.dtpToDate)
        Me.GroupBox2.Controls.Add(Me.dtpFromDate)
        Me.GroupBox2.Controls.Add(Me.lblFUTREACCTNONEW)
        Me.GroupBox2.Controls.Add(Me.lblReDG)
        Me.GroupBox2.Controls.Add(Me.lblREFTNAMENEW)
        Me.GroupBox2.Controls.Add(Me.lblDGname)
        Me.GroupBox2.Controls.Add(Me.mskFUTREACCTNONEW)
        Me.GroupBox2.Controls.Add(Me.mskReDG)
        Me.GroupBox2.Controls.Add(Me.mskFURDAYS)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 113)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(856, 104)
        Me.GroupBox2.TabIndex = 19
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Tag = "GroupBox2"
        '
        'lblTCBNew
        '
        Me.lblTCBNew.AutoSize = True
        Me.lblTCBNew.Location = New System.Drawing.Point(256, 80)
        Me.lblTCBNew.Name = "lblTCBNew"
        Me.lblTCBNew.Size = New System.Drawing.Size(60, 13)
        Me.lblTCBNew.TabIndex = 25
        Me.lblTCBNew.Tag = "lblTCBNew"
        Me.lblTCBNew.Text = "lblTCBNew"
        '
        'lblCBNew
        '
        Me.lblCBNew.AutoSize = True
        Me.lblCBNew.Location = New System.Drawing.Point(256, 35)
        Me.lblCBNew.Name = "lblCBNew"
        Me.lblCBNew.Size = New System.Drawing.Size(53, 13)
        Me.lblCBNew.TabIndex = 24
        Me.lblCBNew.Tag = "lblCBNew"
        Me.lblCBNew.Text = "lblCBNew"
        '
        'mskTCBNew
        '
        Me.mskTCBNew.Location = New System.Drawing.Point(116, 80)
        Me.mskTCBNew.Name = "mskTCBNew"
        Me.mskTCBNew.Size = New System.Drawing.Size(127, 20)
        Me.mskTCBNew.TabIndex = 9
        Me.mskTCBNew.Tag = "mskTCBNew"
        Me.mskTCBNew.Text = "mskTCBNew"
        '
        'mskCBNew
        '
        Me.mskCBNew.Location = New System.Drawing.Point(117, 34)
        Me.mskCBNew.Name = "mskCBNew"
        Me.mskCBNew.Size = New System.Drawing.Size(127, 20)
        Me.mskCBNew.TabIndex = 7
        Me.mskCBNew.Tag = "mskCBNew"
        Me.mskCBNew.Text = "mskCBNew"
        '
        'lblFCarebyNew
        '
        Me.lblFCarebyNew.Location = New System.Drawing.Point(13, 83)
        Me.lblFCarebyNew.Name = "lblFCarebyNew"
        Me.lblFCarebyNew.Size = New System.Drawing.Size(98, 18)
        Me.lblFCarebyNew.TabIndex = 21
        Me.lblFCarebyNew.Tag = "lblFCarebyNew"
        Me.lblFCarebyNew.Text = "Careby TL"
        '
        'lblCarebyNew
        '
        Me.lblCarebyNew.Location = New System.Drawing.Point(11, 35)
        Me.lblCarebyNew.Name = "lblCarebyNew"
        Me.lblCarebyNew.Size = New System.Drawing.Size(97, 18)
        Me.lblCarebyNew.TabIndex = 19
        Me.lblCarebyNew.Tag = "lblCarebyNew"
        Me.lblCarebyNew.Text = "Careby"
        '
        'frmReChangeRe
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(886, 558)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.grpSearch)
        Me.Controls.Add(Me.btnChange)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.grbRemiser)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmReChangeRe"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "frmReChangeRe"
        Me.Text = "frmReChangeRe"
        Me.grbRemiser.ResumeLayout(False)
        Me.grbRemiser.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.grpSearch.ResumeLayout(False)
        Me.grpSearch.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grbRemiser As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents pnlRemiser As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblCaption As System.Windows.Forms.Label
    Friend WithEvents btnChange As System.Windows.Forms.Button
    Friend WithEvents mskReAcctno As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblReAcctno As System.Windows.Forms.Label
    Friend WithEvents lblReName As System.Windows.Forms.Label
    Friend WithEvents mskReDG As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblDGname As System.Windows.Forms.Label
    Friend WithEvents lblReDG As System.Windows.Forms.Label
    Friend WithEvents dtpFromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFromDate As System.Windows.Forms.Label
    Friend WithEvents lblToDate As System.Windows.Forms.Label
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents ckAll As System.Windows.Forms.CheckBox
    Friend WithEvents cboCareby As AppCore.ComboBoxEx
    Friend WithEvents lblcareby As System.Windows.Forms.Label
    Friend WithEvents mskFUTREACCTNO As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblFUTREACCTNO As System.Windows.Forms.Label
    Friend WithEvents lblREFTNAME As System.Windows.Forms.Label
    Friend WithEvents mskFUTREACCTNONEW As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblREFTNAMENEW As System.Windows.Forms.Label
    Friend WithEvents lblFUTREACCTNONEW As System.Windows.Forms.Label
    Friend WithEvents lblFURDAYS As System.Windows.Forms.Label
    Friend WithEvents dtpFUTODATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFurToDate As System.Windows.Forms.Label
    Friend WithEvents mskFURDAYS As System.Windows.Forms.MaskedTextBox
    Friend WithEvents grpSearch As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblFCarebyNew As System.Windows.Forms.Label
    Friend WithEvents lblCarebyNew As System.Windows.Forms.Label
    Friend WithEvents mskCBNew As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mskTCBNew As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblTCBNew As System.Windows.Forms.Label
    Friend WithEvents lblCBNew As System.Windows.Forms.Label
End Class
