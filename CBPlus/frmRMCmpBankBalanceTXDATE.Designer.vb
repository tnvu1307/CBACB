<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRMCmpBankBalanceTXDATE
    Inherits AppCore.FormBase

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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRMCmpBankBalanceTXDATE))
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.DataTable4 = New System.Data.DataTable()
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.bbiExport = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiClose = New DevExpress.XtraBars.BarButtonItem()
        Me.cbauto = New DevExpress.XtraBars.BarCheckItem()
        Me.rpBankMenu = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpgExport = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgClose = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonStatusBar2 = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.bciRefeshAuto1 = New DevExpress.XtraBars.BarCheckItem()
        Me.DataTable17 = New System.Data.DataTable()
        Me.gcResult = New DevExpress.XtraEditors.GroupControl()
        Me.gridResult = New DevExpress.XtraGrid.GridControl()
        Me.gvResult = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.DataTable24 = New System.Data.DataTable()
        Me.tmAutoProcess = New System.Windows.Forms.Timer(Me.components)
        Me.DataTable29 = New System.Data.DataTable()
        Me.DataTable7 = New System.Data.DataTable()
        Me.RibbonPage2 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup2 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPageGroup3 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.BarButtonItem2 = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPageGroup4 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.BarButtonItem3 = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPageGroup5 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.BarButtonItem4 = New DevExpress.XtraBars.BarButtonItem()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblTXDATE = New System.Windows.Forms.Label()
        Me.dtpTXDATE = New System.Windows.Forms.DateTimePicker()
        CType(Me.DataTable4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcResult, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gcResult.SuspendLayout()
        CType(Me.gridResult, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvResult, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable29, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'RibbonPageGroup1
        '
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        Me.RibbonPageGroup1.Text = "RibbonPageGroup1"
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup1})
        Me.RibbonPage1.Name = "RibbonPage1"
        '
        'DataTable4
        '
        Me.DataTable4.Namespace = ""
        Me.DataTable4.TableName = "COMBOBOX"
        '
        'RibbonControl1
        '
        Me.RibbonControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RibbonControl1.Dock = System.Windows.Forms.DockStyle.None
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.bbiExport, Me.bbiClose, Me.cbauto})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.MaxItemId = 5
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.rpBankMenu})
        Me.RibbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl1.ShowCategoryInCaption = False
        Me.RibbonControl1.ShowFullScreenButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide
        Me.RibbonControl1.ShowToolbarCustomizeItem = False
        Me.RibbonControl1.Size = New System.Drawing.Size(679, 121)
        Me.RibbonControl1.StatusBar = Me.RibbonStatusBar2
        Me.RibbonControl1.Toolbar.ShowCustomizeItem = False
        '
        'bbiExport
        '
        Me.bbiExport.Caption = "Kết xuất"
        Me.bbiExport.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.bbiExport.Glyph = CType(resources.GetObject("bbiExport.Glyph"), System.Drawing.Image)
        Me.bbiExport.Id = 2
        Me.bbiExport.LargeGlyph = CType(resources.GetObject("bbiExport.LargeGlyph"), System.Drawing.Image)
        Me.bbiExport.Name = "bbiExport"
        '
        'bbiClose
        '
        Me.bbiClose.Caption = "Thoát"
        Me.bbiClose.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.bbiClose.Glyph = CType(resources.GetObject("bbiClose.Glyph"), System.Drawing.Image)
        Me.bbiClose.Id = 3
        Me.bbiClose.LargeGlyph = CType(resources.GetObject("bbiClose.LargeGlyph"), System.Drawing.Image)
        Me.bbiClose.Name = "bbiClose"
        '
        'cbauto
        '
        Me.cbauto.Caption = "Auto Search"
        Me.cbauto.Id = 4
        Me.cbauto.Name = "cbauto"
        '
        'rpBankMenu
        '
        Me.rpBankMenu.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpgExport, Me.rpgClose})
        Me.rpBankMenu.Name = "rpBankMenu"
        Me.rpBankMenu.Text = "Số dư ngân hàng"
        '
        'rpgExport
        '
        Me.rpgExport.ItemLinks.Add(Me.bbiExport)
        Me.rpgExport.Name = "rpgExport"
        '
        'rpgClose
        '
        Me.rpgClose.ItemLinks.Add(Me.bbiClose)
        Me.rpgClose.Name = "rpgClose"
        '
        'RibbonStatusBar2
        '
        Me.RibbonStatusBar2.ItemLinks.Add(Me.bciRefeshAuto1)
        Me.RibbonStatusBar2.ItemLinks.Add(Me.cbauto)
        Me.RibbonStatusBar2.Location = New System.Drawing.Point(0, 459)
        Me.RibbonStatusBar2.Name = "RibbonStatusBar2"
        Me.RibbonStatusBar2.Ribbon = Me.RibbonControl1
        Me.RibbonStatusBar2.Size = New System.Drawing.Size(679, 27)
        '
        'bciRefeshAuto1
        '
        Me.bciRefeshAuto1.Caption = "Tự động Refresh"
        Me.bciRefeshAuto1.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.bciRefeshAuto1.CheckBoxVisibility = DevExpress.XtraBars.CheckBoxVisibility.BeforeText
        Me.bciRefeshAuto1.Id = 1
        Me.bciRefeshAuto1.Name = "bciRefeshAuto1"
        '
        'DataTable17
        '
        Me.DataTable17.Namespace = ""
        Me.DataTable17.TableName = "COMBOBOX"
        '
        'gcResult
        '
        Me.gcResult.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gcResult.Controls.Add(Me.gridResult)
        Me.gcResult.Location = New System.Drawing.Point(0, 160)
        Me.gcResult.Name = "gcResult"
        Me.gcResult.Padding = New System.Windows.Forms.Padding(0, 0, 0, 27)
        Me.gcResult.Size = New System.Drawing.Size(679, 326)
        Me.gcResult.TabIndex = 1
        Me.gcResult.Text = "Kết quả"
        '
        'gridResult
        '
        Me.gridResult.Cursor = System.Windows.Forms.Cursors.Default
        Me.gridResult.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridResult.Location = New System.Drawing.Point(2, 21)
        Me.gridResult.MainView = Me.gvResult
        Me.gridResult.MenuManager = Me.RibbonControl1
        Me.gridResult.Name = "gridResult"
        Me.gridResult.Size = New System.Drawing.Size(675, 276)
        Me.gridResult.TabIndex = 0
        Me.gridResult.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvResult})
        '
        'gvResult
        '
        Me.gvResult.GridControl = Me.gridResult
        Me.gvResult.Name = "gvResult"
        Me.gvResult.OptionsBehavior.CopyToClipboardWithColumnHeaders = False
        Me.gvResult.OptionsSelection.MultiSelect = True
        Me.gvResult.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect
        Me.gvResult.OptionsView.ShowFooter = True
        '
        'DataTable24
        '
        Me.DataTable24.Namespace = ""
        Me.DataTable24.TableName = "COMBOBOX"
        '
        'tmAutoProcess
        '
        '
        'DataTable29
        '
        Me.DataTable29.Namespace = ""
        Me.DataTable29.TableName = "COMBOBOX"
        '
        'DataTable7
        '
        Me.DataTable7.Namespace = ""
        Me.DataTable7.TableName = "COMBOBOX"
        '
        'RibbonPage2
        '
        Me.RibbonPage2.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup2, Me.RibbonPageGroup3, Me.RibbonPageGroup4, Me.RibbonPageGroup5})
        Me.RibbonPage2.Name = "RibbonPage2"
        Me.RibbonPage2.Text = "Số dư ngân hàng"
        '
        'RibbonPageGroup2
        '
        Me.RibbonPageGroup2.ItemLinks.Add(Me.BarButtonItem1)
        Me.RibbonPageGroup2.Name = "RibbonPageGroup2"
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "Lấy số dư"
        Me.BarButtonItem1.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BarButtonItem1.Glyph = CType(resources.GetObject("BarButtonItem1.Glyph"), System.Drawing.Image)
        Me.BarButtonItem1.Id = 1
        Me.BarButtonItem1.LargeGlyph = CType(resources.GetObject("BarButtonItem1.LargeGlyph"), System.Drawing.Image)
        Me.BarButtonItem1.Name = "BarButtonItem1"
        '
        'RibbonPageGroup3
        '
        Me.RibbonPageGroup3.ItemLinks.Add(Me.BarButtonItem2)
        Me.RibbonPageGroup3.Name = "RibbonPageGroup3"
        '
        'BarButtonItem2
        '
        Me.BarButtonItem2.Caption = "Đối chiếu"
        Me.BarButtonItem2.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BarButtonItem2.Glyph = CType(resources.GetObject("BarButtonItem2.Glyph"), System.Drawing.Image)
        Me.BarButtonItem2.Id = 2
        Me.BarButtonItem2.LargeGlyph = CType(resources.GetObject("BarButtonItem2.LargeGlyph"), System.Drawing.Image)
        Me.BarButtonItem2.Name = "BarButtonItem2"
        '
        'RibbonPageGroup4
        '
        Me.RibbonPageGroup4.ItemLinks.Add(Me.BarButtonItem3)
        Me.RibbonPageGroup4.Name = "RibbonPageGroup4"
        '
        'BarButtonItem3
        '
        Me.BarButtonItem3.Caption = "Kết xuất"
        Me.BarButtonItem3.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BarButtonItem3.Glyph = CType(resources.GetObject("BarButtonItem3.Glyph"), System.Drawing.Image)
        Me.BarButtonItem3.Id = 2
        Me.BarButtonItem3.LargeGlyph = CType(resources.GetObject("BarButtonItem3.LargeGlyph"), System.Drawing.Image)
        Me.BarButtonItem3.Name = "BarButtonItem3"
        '
        'RibbonPageGroup5
        '
        Me.RibbonPageGroup5.ItemLinks.Add(Me.BarButtonItem4)
        Me.RibbonPageGroup5.Name = "RibbonPageGroup5"
        '
        'BarButtonItem4
        '
        Me.BarButtonItem4.Caption = "Thoát"
        Me.BarButtonItem4.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BarButtonItem4.Glyph = CType(resources.GetObject("BarButtonItem4.Glyph"), System.Drawing.Image)
        Me.BarButtonItem4.Id = 3
        Me.BarButtonItem4.LargeGlyph = CType(resources.GetObject("BarButtonItem4.LargeGlyph"), System.Drawing.Image)
        Me.BarButtonItem4.Name = "BarButtonItem4"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.lblTXDATE, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpTXDATE, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 116)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(679, 38)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'lblTXDATE
        '
        Me.lblTXDATE.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTXDATE.AutoSize = True
        Me.lblTXDATE.Location = New System.Drawing.Point(20, 13)
        Me.lblTXDATE.Margin = New System.Windows.Forms.Padding(3, 13, 3, 0)
        Me.lblTXDATE.Name = "lblTXDATE"
        Me.lblTXDATE.Size = New System.Drawing.Size(77, 13)
        Me.lblTXDATE.TabIndex = 0
        Me.lblTXDATE.Tag = "lblTXDATE"
        Me.lblTXDATE.Text = "Ngày giao dịch"
        '
        'dtpTXDATE
        '
        Me.dtpTXDATE.CustomFormat = "dd/MM/yyyy"
        Me.dtpTXDATE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.dtpTXDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTXDATE.Location = New System.Drawing.Point(103, 10)
        Me.dtpTXDATE.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.dtpTXDATE.Name = "dtpTXDATE"
        Me.dtpTXDATE.Size = New System.Drawing.Size(194, 20)
        Me.dtpTXDATE.TabIndex = 1
        '
        'frmRMCmpBankBalanceTXDATE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(679, 486)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.RibbonStatusBar2)
        Me.Controls.Add(Me.gcResult)
        Me.Controls.Add(Me.RibbonControl1)
        Me.Name = "frmRMCmpBankBalanceTXDATE"
        Me.Text = "frmRMCmpBankBalance"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataTable4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcResult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gcResult.ResumeLayout(False)
        CType(Me.gridResult, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvResult, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable29, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents DataTable4 As System.Data.DataTable
    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents rpBankMenu As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents DataTable17 As System.Data.DataTable
    Friend WithEvents gcResult As DevExpress.XtraEditors.GroupControl
    Friend WithEvents gridResult As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvResult As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents DataTable24 As System.Data.DataTable
    Friend WithEvents tmAutoProcess As System.Windows.Forms.Timer
    Friend WithEvents bbiExport As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgExport As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents DataTable29 As System.Data.DataTable
    Friend WithEvents bbiClose As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgClose As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents DataTable7 As System.Data.DataTable
    Friend WithEvents RibbonStatusBar2 As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Friend WithEvents bciRefeshAuto1 As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents RibbonPage2 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup2 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup3 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BarButtonItem2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup4 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BarButtonItem3 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup5 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BarButtonItem4 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cbauto As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblTXDATE As System.Windows.Forms.Label
    Friend WithEvents dtpTXDATE As System.Windows.Forms.DateTimePicker
End Class
