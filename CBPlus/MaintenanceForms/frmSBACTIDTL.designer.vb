<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSBACTIDTL
    Inherits AppCore.frmXtraMaintenance

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
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.lblREFID = New DevExpress.XtraEditors.LabelControl()
        Me.txtREFID = New DevExpress.XtraEditors.TextEdit()
        Me.lblASSIGNID = New DevExpress.XtraEditors.LabelControl()
        Me.cboASSIGNID = New DevExpress.XtraEditors.LookUpEdit()
        Me.tblNOTES = New DevExpress.XtraEditors.LabelControl()
        Me.tblACTIDTLTYP = New DevExpress.XtraEditors.LabelControl()
        Me.cboACTIDTLTYP = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtAUTOID = New DevExpress.XtraEditors.TextEdit()
        Me.txtREFACTICODE = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtNOTES = New System.Windows.Forms.RichTextBox()
        Me.lblRESOLVEDT = New DevExpress.XtraEditors.LabelControl()
        Me.dtpRESOLVEDT = New DevExpress.XtraEditors.DateEdit()
        Me.tlpSBACTIFILE = New DevExpress.XtraTab.XtraTabControl()
        Me.tpSBACTIFILE = New DevExpress.XtraTab.XtraTabPage()
        Me.tlpFILE = New System.Windows.Forms.TableLayoutPanel()
        Me.btnSBACTIFILE_ADD = New DevExpress.XtraEditors.SimpleButton()
        Me.gridSBACTIFILE = New DevExpress.XtraGrid.GridControl()
        Me.grvSBACTIFILE = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.btnSBACTIFILE_DELETE = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSBACTIFILE_VIEW = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSBACTIFILE_EDIT = New DevExpress.XtraEditors.SimpleButton()
        Me.DataTable1 = New System.Data.DataTable()
        Me.DataTable2 = New System.Data.DataTable()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.txtREFID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboASSIGNID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboACTIDTLTYP.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAUTOID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtREFACTICODE.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpRESOLVEDT.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpRESOLVEDT.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tlpSBACTIFILE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpSBACTIFILE.SuspendLayout()
        Me.tpSBACTIFILE.SuspendLayout()
        Me.tlpFILE.SuspendLayout()
        CType(Me.gridSBACTIFILE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvSBACTIFILE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupControl1.Controls.Add(Me.tlpSBACTIFILE)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 50)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(772, 514)
        Me.GroupControl1.TabIndex = 2
        Me.GroupControl1.Tag = "GroupControl1"
        Me.GroupControl1.Text = "Thêm mới quỹ hưu trí đầu tư"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 248.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.LabelControl2, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lblREFID, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtREFID, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblASSIGNID, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.cboASSIGNID, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.tblNOTES, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.tblACTIDTLTYP, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cboACTIDTLTYP, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtAUTOID, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.txtREFACTICODE, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelControl1, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.txtNOTES, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblRESOLVEDT, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpRESOLVEDT, 3, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(2, 21)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(768, 153)
        Me.TableLayoutPanel1.TabIndex = 1
        Me.TableLayoutPanel1.Tag = "TableLayoutPanel1"
        '
        'LabelControl2
        '
        Me.LabelControl2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl2.Location = New System.Drawing.Point(3, 156)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(104, 13)
        Me.LabelControl2.TabIndex = 43
        Me.LabelControl2.Tag = "AUTOID"
        Me.LabelControl2.Text = "lblAUTOID"
        '
        'lblREFID
        '
        Me.lblREFID.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblREFID.Location = New System.Drawing.Point(3, 6)
        Me.lblREFID.Name = "lblREFID"
        Me.lblREFID.Size = New System.Drawing.Size(30, 13)
        Me.lblREFID.TabIndex = 1
        Me.lblREFID.Tag = "REFID"
        Me.lblREFID.Text = "REFID"
        '
        'txtREFID
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtREFID, 3)
        Me.txtREFID.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtREFID.Location = New System.Drawing.Point(113, 3)
        Me.txtREFID.Name = "txtREFID"
        Me.txtREFID.Size = New System.Drawing.Size(652, 20)
        Me.txtREFID.TabIndex = 27
        Me.txtREFID.Tag = "REFID"
        '
        'lblASSIGNID
        '
        Me.lblASSIGNID.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblASSIGNID.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblASSIGNID.Location = New System.Drawing.Point(3, 106)
        Me.lblASSIGNID.Name = "lblASSIGNID"
        Me.lblASSIGNID.Size = New System.Drawing.Size(104, 13)
        Me.lblASSIGNID.TabIndex = 39
        Me.lblASSIGNID.Tag = "ASSIGNID"
        Me.lblASSIGNID.Text = "lblASSIGNID"
        '
        'cboASSIGNID
        '
        Me.cboASSIGNID.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboASSIGNID.Location = New System.Drawing.Point(113, 103)
        Me.cboASSIGNID.Name = "cboASSIGNID"
        Me.cboASSIGNID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboASSIGNID.Size = New System.Drawing.Size(294, 20)
        Me.cboASSIGNID.TabIndex = 40
        Me.cboASSIGNID.Tag = "ASSIGNID"
        '
        'tblNOTES
        '
        Me.tblNOTES.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tblNOTES.Location = New System.Drawing.Point(3, 68)
        Me.tblNOTES.Name = "tblNOTES"
        Me.tblNOTES.Size = New System.Drawing.Size(33, 13)
        Me.tblNOTES.TabIndex = 20
        Me.tblNOTES.Tag = "NOTES"
        Me.tblNOTES.Text = "NOTES"
        '
        'tblACTIDTLTYP
        '
        Me.tblACTIDTLTYP.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tblACTIDTLTYP.Location = New System.Drawing.Point(3, 31)
        Me.tblACTIDTLTYP.Name = "tblACTIDTLTYP"
        Me.tblACTIDTLTYP.Size = New System.Drawing.Size(60, 13)
        Me.tblACTIDTLTYP.TabIndex = 17
        Me.tblACTIDTLTYP.Tag = "ACTIDTLTYP"
        Me.tblACTIDTLTYP.Text = "ACTIDTLTYP"
        '
        'cboACTIDTLTYP
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboACTIDTLTYP, 3)
        Me.cboACTIDTLTYP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboACTIDTLTYP.Location = New System.Drawing.Point(113, 28)
        Me.cboACTIDTLTYP.Name = "cboACTIDTLTYP"
        Me.cboACTIDTLTYP.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboACTIDTLTYP.Size = New System.Drawing.Size(652, 20)
        Me.cboACTIDTLTYP.TabIndex = 1
        Me.cboACTIDTLTYP.Tag = "ACTIDTLTYP"
        '
        'txtAUTOID
        '
        Me.txtAUTOID.Location = New System.Drawing.Point(113, 153)
        Me.txtAUTOID.Name = "txtAUTOID"
        Me.txtAUTOID.Size = New System.Drawing.Size(294, 20)
        Me.txtAUTOID.TabIndex = 29
        Me.txtAUTOID.Tag = "AUTOID"
        Me.txtAUTOID.Visible = False
        '
        'txtREFACTICODE
        '
        Me.txtREFACTICODE.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtREFACTICODE.Location = New System.Drawing.Point(113, 128)
        Me.txtREFACTICODE.Name = "txtREFACTICODE"
        Me.txtREFACTICODE.Size = New System.Drawing.Size(294, 20)
        Me.txtREFACTICODE.TabIndex = 41
        Me.txtREFACTICODE.Tag = "REFACTICODE"
        Me.txtREFACTICODE.Visible = False
        '
        'LabelControl1
        '
        Me.LabelControl1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl1.Location = New System.Drawing.Point(3, 131)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(104, 13)
        Me.LabelControl1.TabIndex = 42
        Me.LabelControl1.Tag = "REFACTICODE"
        Me.LabelControl1.Text = "lblREFACTICODE"
        '
        'txtNOTES
        '
        Me.txtNOTES.BackColor = System.Drawing.Color.White
        Me.txtNOTES.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtNOTES, 3)
        Me.txtNOTES.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNOTES.Location = New System.Drawing.Point(113, 53)
        Me.txtNOTES.Name = "txtNOTES"
        Me.txtNOTES.Size = New System.Drawing.Size(652, 44)
        Me.txtNOTES.TabIndex = 44
        Me.txtNOTES.Tag = "NOTES"
        Me.txtNOTES.Text = ""
        '
        'lblRESOLVEDT
        '
        Me.lblRESOLVEDT.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRESOLVEDT.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblRESOLVEDT.Location = New System.Drawing.Point(413, 106)
        Me.lblRESOLVEDT.Name = "lblRESOLVEDT"
        Me.lblRESOLVEDT.Size = New System.Drawing.Size(104, 13)
        Me.lblRESOLVEDT.TabIndex = 45
        Me.lblRESOLVEDT.Tag = "RESOLVEDT"
        Me.lblRESOLVEDT.Text = "lblRESOLVEDT"
        '
        'dtpRESOLVEDT
        '
        Me.dtpRESOLVEDT.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpRESOLVEDT.EditValue = Nothing
        Me.dtpRESOLVEDT.Location = New System.Drawing.Point(523, 103)
        Me.dtpRESOLVEDT.Name = "dtpRESOLVEDT"
        Me.dtpRESOLVEDT.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtpRESOLVEDT.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtpRESOLVEDT.Size = New System.Drawing.Size(242, 20)
        Me.dtpRESOLVEDT.TabIndex = 46
        Me.dtpRESOLVEDT.Tag = "RESOLVEDT"
        '
        'tlpSBACTIFILE
        '
        Me.tlpSBACTIFILE.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.tlpSBACTIFILE.Location = New System.Drawing.Point(2, 180)
        Me.tlpSBACTIFILE.Name = "tlpSBACTIFILE"
        Me.tlpSBACTIFILE.SelectedTabPage = Me.tpSBACTIFILE
        Me.tlpSBACTIFILE.Size = New System.Drawing.Size(768, 332)
        Me.tlpSBACTIFILE.TabIndex = 30
        Me.tlpSBACTIFILE.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.tpSBACTIFILE})
        Me.tlpSBACTIFILE.Tag = "tlpSBACTIFILE"
        '
        'tpSBACTIFILE
        '
        Me.tpSBACTIFILE.Controls.Add(Me.tlpFILE)
        Me.tpSBACTIFILE.Name = "tpSBACTIFILE"
        Me.tpSBACTIFILE.Size = New System.Drawing.Size(762, 304)
        Me.tpSBACTIFILE.Tag = "tpSBACTIFILE"
        Me.tpSBACTIFILE.Text = "tpSBACTIFILE"
        '
        'tlpFILE
        '
        Me.tlpFILE.ColumnCount = 5
        Me.tlpFILE.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.tlpFILE.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.tlpFILE.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.tlpFILE.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.tlpFILE.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpFILE.Controls.Add(Me.btnSBACTIFILE_ADD, 0, 0)
        Me.tlpFILE.Controls.Add(Me.gridSBACTIFILE, 0, 1)
        Me.tlpFILE.Controls.Add(Me.btnSBACTIFILE_DELETE, 3, 0)
        Me.tlpFILE.Controls.Add(Me.btnSBACTIFILE_VIEW, 1, 0)
        Me.tlpFILE.Controls.Add(Me.btnSBACTIFILE_EDIT, 2, 0)
        Me.tlpFILE.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpFILE.Location = New System.Drawing.Point(0, 0)
        Me.tlpFILE.Name = "tlpFILE"
        Me.tlpFILE.RowCount = 2
        Me.tlpFILE.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.tlpFILE.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFILE.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpFILE.Size = New System.Drawing.Size(762, 304)
        Me.tlpFILE.TabIndex = 0
        Me.tlpFILE.Tag = "tlpFILE"
        '
        'btnSBACTIFILE_ADD
        '
        Me.btnSBACTIFILE_ADD.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSBACTIFILE_ADD.Location = New System.Drawing.Point(3, 5)
        Me.btnSBACTIFILE_ADD.Name = "btnSBACTIFILE_ADD"
        Me.btnSBACTIFILE_ADD.Size = New System.Drawing.Size(74, 23)
        Me.btnSBACTIFILE_ADD.TabIndex = 22
        Me.btnSBACTIFILE_ADD.Tag = "btnSBACTIFILE_ADD"
        Me.btnSBACTIFILE_ADD.Text = "Thêm mới"
        '
        'gridSBACTIFILE
        '
        Me.tlpFILE.SetColumnSpan(Me.gridSBACTIFILE, 5)
        Me.gridSBACTIFILE.Cursor = System.Windows.Forms.Cursors.Default
        Me.gridSBACTIFILE.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridSBACTIFILE.Location = New System.Drawing.Point(3, 37)
        Me.gridSBACTIFILE.MainView = Me.grvSBACTIFILE
        Me.gridSBACTIFILE.Name = "gridSBACTIFILE"
        Me.gridSBACTIFILE.Size = New System.Drawing.Size(1056, 264)
        Me.gridSBACTIFILE.TabIndex = 3
        Me.gridSBACTIFILE.Tag = "gridSBACTIFILE"
        Me.gridSBACTIFILE.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvSBACTIFILE, Me.GridView1, Me.GridView2})
        '
        'grvSBACTIFILE
        '
        Me.grvSBACTIFILE.GridControl = Me.gridSBACTIFILE
        Me.grvSBACTIFILE.Name = "grvSBACTIFILE"
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.gridSBACTIFILE
        Me.GridView1.Name = "GridView1"
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.gridSBACTIFILE
        Me.GridView2.Name = "GridView2"
        '
        'btnSBACTIFILE_DELETE
        '
        Me.btnSBACTIFILE_DELETE.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSBACTIFILE_DELETE.Location = New System.Drawing.Point(243, 5)
        Me.btnSBACTIFILE_DELETE.Name = "btnSBACTIFILE_DELETE"
        Me.btnSBACTIFILE_DELETE.Size = New System.Drawing.Size(74, 23)
        Me.btnSBACTIFILE_DELETE.TabIndex = 24
        Me.btnSBACTIFILE_DELETE.Tag = "btnSBACTIFILE_DELETE"
        Me.btnSBACTIFILE_DELETE.Text = "Xóa"
        '
        'btnSBACTIFILE_VIEW
        '
        Me.btnSBACTIFILE_VIEW.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSBACTIFILE_VIEW.Location = New System.Drawing.Point(83, 5)
        Me.btnSBACTIFILE_VIEW.Name = "btnSBACTIFILE_VIEW"
        Me.btnSBACTIFILE_VIEW.Size = New System.Drawing.Size(74, 23)
        Me.btnSBACTIFILE_VIEW.TabIndex = 25
        Me.btnSBACTIFILE_VIEW.Tag = "btnSBACTIFILE_VIEW"
        Me.btnSBACTIFILE_VIEW.Text = "Xem"
        '
        'btnSBACTIFILE_EDIT
        '
        Me.btnSBACTIFILE_EDIT.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSBACTIFILE_EDIT.Location = New System.Drawing.Point(163, 5)
        Me.btnSBACTIFILE_EDIT.Name = "btnSBACTIFILE_EDIT"
        Me.btnSBACTIFILE_EDIT.Size = New System.Drawing.Size(74, 23)
        Me.btnSBACTIFILE_EDIT.TabIndex = 23
        Me.btnSBACTIFILE_EDIT.Tag = "btnSBACTIFILE_EDIT"
        Me.btnSBACTIFILE_EDIT.Text = "Sửa"
        '
        'DataTable1
        '
        Me.DataTable1.Namespace = ""
        Me.DataTable1.TableName = "COMBOBOX"
        '
        'DataTable2
        '
        Me.DataTable2.Namespace = ""
        Me.DataTable2.TableName = "COMBOBOX"
        '
        'frmSBACTIDTL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(772, 608)
        Me.Controls.Add(Me.GroupControl1)
        Me.Name = "frmSBACTIDTL"
        Me.Tag = "frmSBACTIDTL"
        Me.Text = "frmSBACTIDTL"
        Me.Controls.SetChildIndex(Me.GroupControl1, 0)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.txtREFID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboASSIGNID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboACTIDTLTYP.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAUTOID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtREFACTICODE.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpRESOLVEDT.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpRESOLVEDT.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tlpSBACTIFILE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpSBACTIFILE.ResumeLayout(False)
        Me.tpSBACTIFILE.ResumeLayout(False)
        Me.tlpFILE.ResumeLayout(False)
        CType(Me.gridSBACTIFILE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvSBACTIFILE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents DataTable1 As System.Data.DataTable
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblREFID As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtREFID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtREFACTICODE As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtAUTOID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblASSIGNID As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboASSIGNID As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents tblNOTES As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tblACTIDTLTYP As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboACTIDTLTYP As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents tlpSBACTIFILE As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents tpSBACTIFILE As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents tlpFILE As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnSBACTIFILE_ADD As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents gridSBACTIFILE As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvSBACTIFILE As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnSBACTIFILE_DELETE As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSBACTIFILE_VIEW As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSBACTIFILE_EDIT As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents DataTable2 As System.Data.DataTable
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtNOTES As System.Windows.Forms.RichTextBox
    Friend WithEvents lblRESOLVEDT As DevExpress.XtraEditors.LabelControl
    Friend WithEvents dtpRESOLVEDT As DevExpress.XtraEditors.DateEdit
End Class
