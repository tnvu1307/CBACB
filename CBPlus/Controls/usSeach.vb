Imports CommonLibrary
Imports System.Collections
Imports AppCore
Imports Microsoft.Win32
Imports System.IO
Imports System.Threading
Imports _DIRECT.AuthWS
Imports DevExpress.Utils

Public Class usSeach
    Inherits System.Windows.Forms.UserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Private WithEvents SmartToolBar1 As Xceed.SmartUI.Controls.ToolBar.SmartToolBar

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents imlSearch As System.Windows.Forms.ImageList
    Friend WithEvents grbSearchFilter As System.Windows.Forms.GroupBox
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents btnRemoveAll As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents grbConditionList As System.Windows.Forms.GroupBox
    Friend WithEvents lstCondition As System.Windows.Forms.CheckedListBox
    Friend WithEvents grbCondition As System.Windows.Forms.GroupBox
    Friend WithEvents txtValue As System.Windows.Forms.Control
    Friend WithEvents lblValue As System.Windows.Forms.Label
    Friend WithEvents cboOperator As AppCore.ComboBoxEx
    Friend WithEvents lblOperator As System.Windows.Forms.Label
    Friend WithEvents cboField As AppCore.ComboBoxEx
    Friend WithEvents lblField As System.Windows.Forms.Label
    Private WithEvents tbnCashier As Xceed.SmartUI.Controls.ToolBar.Tool
    Private WithEvents tbnView As Xceed.SmartUI.Controls.ToolBar.Tool
    Private WithEvents tbnApprove As Xceed.SmartUI.Controls.ToolBar.Tool
    Private WithEvents tbnReject As Xceed.SmartUI.Controls.ToolBar.Tool
    Private WithEvents tbnDelete As Xceed.SmartUI.Controls.ToolBar.Tool
    Friend WithEvents grbSearchResult As System.Windows.Forms.GroupBox
    Friend WithEvents pnlSearchResult As System.Windows.Forms.Panel
    Public WithEvents tmrSearch As System.Windows.Forms.Timer
    Private WithEvents btnRefuse As Xceed.SmartUI.Controls.ToolBar.Tool
    Friend WithEvents mnuGrid As System.Windows.Forms.ContextMenu
    Friend WithEvents mnuSelectAll As System.Windows.Forms.MenuItem
    Friend WithEvents mnuDeselectAll As System.Windows.Forms.MenuItem
    Friend WithEvents SearchGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvResult As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents DataTable21 As System.Data.DataTable
    Friend WithEvents RepositoryItemCheckEdit As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents DataTable34 As System.Data.DataTable
    Friend WithEvents DataTable35 As System.Data.DataTable
    Friend WithEvents DataTable38 As System.Data.DataTable
    Friend WithEvents DataTable1 As System.Data.DataTable
    Friend WithEvents DataTable2 As System.Data.DataTable
    Friend WithEvents DataTable3 As System.Data.DataTable
    Friend WithEvents btnHistory As System.Windows.Forms.Button

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(usSeach))
        Dim GridLevelNode2 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.SmartToolBar1 = New Xceed.SmartUI.Controls.ToolBar.SmartToolBar(Me.components)
        Me.tbnCashier = New Xceed.SmartUI.Controls.ToolBar.Tool()
        Me.tbnView = New Xceed.SmartUI.Controls.ToolBar.Tool()
        Me.tbnApprove = New Xceed.SmartUI.Controls.ToolBar.Tool()
        Me.tbnReject = New Xceed.SmartUI.Controls.ToolBar.Tool()
        Me.btnRefuse = New Xceed.SmartUI.Controls.ToolBar.Tool()
        Me.tbnDelete = New Xceed.SmartUI.Controls.ToolBar.Tool()
        Me.imlSearch = New System.Windows.Forms.ImageList(Me.components)
        Me.grbSearchFilter = New System.Windows.Forms.GroupBox()
        Me.btnHistory = New System.Windows.Forms.Button()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.btnRemoveAll = New System.Windows.Forms.Button()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.grbConditionList = New System.Windows.Forms.GroupBox()
        Me.lstCondition = New System.Windows.Forms.CheckedListBox()
        Me.grbCondition = New System.Windows.Forms.GroupBox()
        Me.txtValue = New System.Windows.Forms.Control()
        Me.lblValue = New System.Windows.Forms.Label()
        Me.cboOperator = New AppCore.ComboBoxEx()
        Me.lblOperator = New System.Windows.Forms.Label()
        Me.cboField = New AppCore.ComboBoxEx()
        Me.lblField = New System.Windows.Forms.Label()
        Me.grbSearchResult = New System.Windows.Forms.GroupBox()
        Me.pnlSearchResult = New System.Windows.Forms.Panel()
        Me.SearchGrid = New DevExpress.XtraGrid.GridControl()
        Me.gvResult = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RepositoryItemCheckEdit = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.tmrSearch = New System.Windows.Forms.Timer(Me.components)
        Me.mnuGrid = New System.Windows.Forms.ContextMenu()
        Me.mnuSelectAll = New System.Windows.Forms.MenuItem()
        Me.mnuDeselectAll = New System.Windows.Forms.MenuItem()
        Me.DataTable21 = New System.Data.DataTable()
        Me.DataTable34 = New System.Data.DataTable()
        Me.DataTable35 = New System.Data.DataTable()
        Me.DataTable38 = New System.Data.DataTable()
        Me.DataTable1 = New System.Data.DataTable()
        Me.DataTable2 = New System.Data.DataTable()
        Me.DataTable3 = New System.Data.DataTable()
        CType(Me.SmartToolBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbSearchFilter.SuspendLayout()
        Me.grbConditionList.SuspendLayout()
        Me.grbCondition.SuspendLayout()
        Me.grbSearchResult.SuspendLayout()
        Me.pnlSearchResult.SuspendLayout()
        CType(Me.SearchGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvResult, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable34, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable35, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable38, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SmartToolBar1
        '
        Me.SmartToolBar1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.SmartToolBar1.Items.AddRange(New Xceed.SmartUI.SmartItem() {Me.tbnCashier, Me.tbnView, Me.tbnApprove, Me.tbnReject, Me.btnRefuse, Me.tbnDelete})
        Me.SmartToolBar1.ItemsImageList = Me.imlSearch
        Me.SmartToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.SmartToolBar1.Name = "SmartToolBar1"
        Me.SmartToolBar1.Size = New System.Drawing.Size(936, 42)
        Me.SmartToolBar1.TabIndex = 1
        Me.SmartToolBar1.Text = "SmartToolBar1"
        Me.SmartToolBar1.UIStyle = Xceed.SmartUI.UIStyle.UIStyle.WindowsClassic
        '
        'tbnCashier
        '
        Me.tbnCashier.Enabled = False
        Me.tbnCashier.ImageIndex = 4
        Me.tbnCashier.Name = "tbnCashier"
        Me.tbnCashier.Tag = Nothing
        Me.tbnCashier.Text = "&Cashier"
        '
        'tbnView
        '
        Me.tbnView.ImageIndex = 0
        Me.tbnView.Name = "tbnView"
        Me.tbnView.OverFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbnView.Tag = Nothing
        Me.tbnView.Text = "&View"
        '
        'tbnApprove
        '
        Me.tbnApprove.ImageIndex = 2
        Me.tbnApprove.Name = "tbnApprove"
        Me.tbnApprove.Tag = Nothing
        Me.tbnApprove.Text = "&Approve"
        '
        'tbnReject
        '
        Me.tbnReject.ImageIndex = 7
        Me.tbnReject.Name = "tbnReject"
        Me.tbnReject.Tag = Nothing
        Me.tbnReject.Text = "&Reject"
        '
        'btnRefuse
        '
        Me.btnRefuse.ImageIndex = 3
        Me.btnRefuse.Name = "btnRefuse"
        Me.btnRefuse.Tag = Nothing
        Me.btnRefuse.Text = "&Refuse"
        '
        'tbnDelete
        '
        Me.tbnDelete.ImageIndex = 1
        Me.tbnDelete.Name = "tbnDelete"
        Me.tbnDelete.Tag = Nothing
        Me.tbnDelete.Text = "&Delete"
        '
        'imlSearch
        '
        Me.imlSearch.ImageStream = CType(resources.GetObject("imlSearch.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlSearch.TransparentColor = System.Drawing.Color.Transparent
        Me.imlSearch.Images.SetKeyName(0, "")
        Me.imlSearch.Images.SetKeyName(1, "")
        Me.imlSearch.Images.SetKeyName(2, "")
        Me.imlSearch.Images.SetKeyName(3, "")
        Me.imlSearch.Images.SetKeyName(4, "")
        Me.imlSearch.Images.SetKeyName(5, "")
        Me.imlSearch.Images.SetKeyName(6, "")
        Me.imlSearch.Images.SetKeyName(7, "")
        Me.imlSearch.Images.SetKeyName(8, "")
        '
        'grbSearchFilter
        '
        Me.grbSearchFilter.Controls.Add(Me.btnHistory)
        Me.grbSearchFilter.Controls.Add(Me.btnExport)
        Me.grbSearchFilter.Controls.Add(Me.btnRemoveAll)
        Me.grbSearchFilter.Controls.Add(Me.btnRemove)
        Me.grbSearchFilter.Controls.Add(Me.btnAdd)
        Me.grbSearchFilter.Controls.Add(Me.btnSearch)
        Me.grbSearchFilter.Controls.Add(Me.grbConditionList)
        Me.grbSearchFilter.Controls.Add(Me.grbCondition)
        Me.grbSearchFilter.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbSearchFilter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbSearchFilter.Location = New System.Drawing.Point(0, 42)
        Me.grbSearchFilter.Name = "grbSearchFilter"
        Me.grbSearchFilter.Size = New System.Drawing.Size(936, 151)
        Me.grbSearchFilter.TabIndex = 2
        Me.grbSearchFilter.TabStop = False
        Me.grbSearchFilter.Text = "grbSearchFilter"
        '
        'btnHistory
        '
        Me.btnHistory.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.btnHistory.Location = New System.Drawing.Point(768, 84)
        Me.btnHistory.Name = "btnHistory"
        Me.btnHistory.Size = New System.Drawing.Size(75, 23)
        Me.btnHistory.TabIndex = 9
        Me.btnHistory.Tag = "btnHistory"
        Me.btnHistory.Text = "btnHistory"
        '
        'btnExport
        '
        Me.btnExport.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExport.Location = New System.Drawing.Point(768, 54)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(75, 23)
        Me.btnExport.TabIndex = 8
        Me.btnExport.Text = "btnExport"
        '
        'btnRemoveAll
        '
        Me.btnRemoveAll.Font = New System.Drawing.Font("Webdings", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.btnRemoveAll.Location = New System.Drawing.Point(291, 96)
        Me.btnRemoveAll.Name = "btnRemoveAll"
        Me.btnRemoveAll.Size = New System.Drawing.Size(32, 24)
        Me.btnRemoveAll.TabIndex = 7
        Me.btnRemoveAll.Text = "7"
        '
        'btnRemove
        '
        Me.btnRemove.Font = New System.Drawing.Font("Webdings", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.btnRemove.Location = New System.Drawing.Point(291, 68)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(32, 24)
        Me.btnRemove.TabIndex = 6
        Me.btnRemove.Text = "3"
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Webdings", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(291, 40)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(32, 24)
        Me.btnAdd.TabIndex = 5
        Me.btnAdd.Text = "4"
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(768, 25)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 2
        Me.btnSearch.Text = "btnSearch"
        '
        'grbConditionList
        '
        Me.grbConditionList.Controls.Add(Me.lstCondition)
        Me.grbConditionList.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbConditionList.Location = New System.Drawing.Point(329, 19)
        Me.grbConditionList.Name = "grbConditionList"
        Me.grbConditionList.Size = New System.Drawing.Size(279, 117)
        Me.grbConditionList.TabIndex = 1
        Me.grbConditionList.TabStop = False
        Me.grbConditionList.Text = "grbConditionList"
        '
        'lstCondition
        '
        Me.lstCondition.CheckOnClick = True
        Me.lstCondition.ColumnWidth = 400
        Me.lstCondition.Location = New System.Drawing.Point(8, 24)
        Me.lstCondition.Name = "lstCondition"
        Me.lstCondition.Size = New System.Drawing.Size(264, 84)
        Me.lstCondition.TabIndex = 0
        '
        'grbCondition
        '
        Me.grbCondition.Controls.Add(Me.txtValue)
        Me.grbCondition.Controls.Add(Me.lblValue)
        Me.grbCondition.Controls.Add(Me.cboOperator)
        Me.grbCondition.Controls.Add(Me.lblOperator)
        Me.grbCondition.Controls.Add(Me.cboField)
        Me.grbCondition.Controls.Add(Me.lblField)
        Me.grbCondition.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbCondition.Location = New System.Drawing.Point(8, 19)
        Me.grbCondition.Name = "grbCondition"
        Me.grbCondition.Size = New System.Drawing.Size(280, 117)
        Me.grbCondition.TabIndex = 0
        Me.grbCondition.TabStop = False
        Me.grbCondition.Text = "grbCondition"
        '
        'txtValue
        '
        Me.txtValue.Location = New System.Drawing.Point(99, 80)
        Me.txtValue.Name = "txtValue"
        Me.txtValue.Size = New System.Drawing.Size(177, 21)
        Me.txtValue.TabIndex = 5
        Me.txtValue.Text = "txtValue"
        '
        'lblValue
        '
        Me.lblValue.Location = New System.Drawing.Point(9, 82)
        Me.lblValue.Name = "lblValue"
        Me.lblValue.Size = New System.Drawing.Size(79, 16)
        Me.lblValue.TabIndex = 4
        Me.lblValue.Text = "lblValue"
        '
        'cboOperator
        '
        Me.cboOperator.DisplayMember = "DISPLAY"
        Me.cboOperator.Location = New System.Drawing.Point(100, 52)
        Me.cboOperator.Name = "cboOperator"
        Me.cboOperator.Size = New System.Drawing.Size(176, 21)
        Me.cboOperator.TabIndex = 3
        Me.cboOperator.ValueMember = "VALUE"
        '
        'lblOperator
        '
        Me.lblOperator.Location = New System.Drawing.Point(9, 54)
        Me.lblOperator.Name = "lblOperator"
        Me.lblOperator.Size = New System.Drawing.Size(79, 16)
        Me.lblOperator.TabIndex = 2
        Me.lblOperator.Text = "lblOperator"
        '
        'cboField
        '
        Me.cboField.DisplayMember = "DISPLAY"
        Me.cboField.Location = New System.Drawing.Point(100, 24)
        Me.cboField.Name = "cboField"
        Me.cboField.Size = New System.Drawing.Size(176, 21)
        Me.cboField.TabIndex = 1
        Me.cboField.ValueMember = "VALUE"
        '
        'lblField
        '
        Me.lblField.Location = New System.Drawing.Point(10, 26)
        Me.lblField.Name = "lblField"
        Me.lblField.Size = New System.Drawing.Size(78, 16)
        Me.lblField.TabIndex = 0
        Me.lblField.Text = "lblField"
        '
        'grbSearchResult
        '
        Me.grbSearchResult.Controls.Add(Me.pnlSearchResult)
        Me.grbSearchResult.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbSearchResult.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbSearchResult.Location = New System.Drawing.Point(0, 193)
        Me.grbSearchResult.Name = "grbSearchResult"
        Me.grbSearchResult.Size = New System.Drawing.Size(936, 336)
        Me.grbSearchResult.TabIndex = 6
        Me.grbSearchResult.TabStop = False
        Me.grbSearchResult.Text = "grbSearchResult"
        '
        'pnlSearchResult
        '
        Me.pnlSearchResult.Controls.Add(Me.SearchGrid)
        Me.pnlSearchResult.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlSearchResult.Location = New System.Drawing.Point(8, 24)
        Me.pnlSearchResult.Name = "pnlSearchResult"
        Me.pnlSearchResult.Size = New System.Drawing.Size(832, 304)
        Me.pnlSearchResult.TabIndex = 0
        '
        'SearchGrid
        '
        Me.SearchGrid.Cursor = System.Windows.Forms.Cursors.Default
        Me.SearchGrid.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode2.RelationName = "Level1"
        Me.SearchGrid.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode2})
        Me.SearchGrid.Location = New System.Drawing.Point(0, 0)
        Me.SearchGrid.MainView = Me.gvResult
        Me.SearchGrid.Name = "SearchGrid"
        Me.SearchGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit})
        Me.SearchGrid.Size = New System.Drawing.Size(832, 304)
        Me.SearchGrid.TabIndex = 0
        Me.SearchGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvResult})
        '
        'gvResult
        '
        Me.gvResult.GridControl = Me.SearchGrid
        Me.gvResult.Name = "gvResult"
        Me.gvResult.OptionsBehavior.CopyToClipboardWithColumnHeaders = False
        Me.gvResult.OptionsSelection.MultiSelect = True
        Me.gvResult.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect
        '
        'RepositoryItemCheckEdit
        '
        Me.RepositoryItemCheckEdit.AutoHeight = False
        Me.RepositoryItemCheckEdit.Caption = "Check"
        Me.RepositoryItemCheckEdit.Name = "RepositoryItemCheckEdit"
        Me.RepositoryItemCheckEdit.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'tmrSearch
        '
        Me.tmrSearch.Interval = 100000
        '
        'mnuGrid
        '
        Me.mnuGrid.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuSelectAll, Me.mnuDeselectAll})
        '
        'mnuSelectAll
        '
        Me.mnuSelectAll.Index = 0
        Me.mnuSelectAll.Text = "Select all"
        '
        'mnuDeselectAll
        '
        Me.mnuDeselectAll.Index = 1
        Me.mnuDeselectAll.Text = "Deselect all"
        '
        'DataTable21
        '
        Me.DataTable21.Namespace = ""
        Me.DataTable21.TableName = "COMBOBOX"
        '
        'DataTable34
        '
        Me.DataTable34.Namespace = ""
        Me.DataTable34.TableName = "COMBOBOX"
        '
        'DataTable35
        '
        Me.DataTable35.Namespace = ""
        Me.DataTable35.TableName = "COMBOBOX"
        '
        'DataTable38
        '
        Me.DataTable38.Namespace = ""
        Me.DataTable38.TableName = "COMBOBOX"
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
        'DataTable3
        '
        Me.DataTable3.Namespace = ""
        Me.DataTable3.TableName = "COMBOBOX"
        '
        'usSeach
        '
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.Controls.Add(Me.grbSearchResult)
        Me.Controls.Add(Me.grbSearchFilter)
        Me.Controls.Add(Me.SmartToolBar1)
        Me.Name = "usSeach"
        Me.Size = New System.Drawing.Size(936, 400)
        CType(Me.SmartToolBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbSearchFilter.ResumeLayout(False)
        Me.grbConditionList.ResumeLayout(False)
        Me.grbCondition.ResumeLayout(False)
        Me.grbSearchResult.ResumeLayout(False)
        Me.pnlSearchResult.ResumeLayout(False)
        CType(Me.SearchGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvResult, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable34, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable35, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable38, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Khai báo hằng, biến "
    Const c_ResourceManager = gc_RootNamespace & ".ucSearch-"
    Const c_ResourceManagerGrid = "AppCore.frmSearch-"
    Const c_BlnAutoSearch = False

    Public mv_strSearchFilter As String
    Public hFilter As New Hashtable

    Private mv_strTableName As String
    Private mv_strCaption As String
    Private mv_strEnCaption As String
    Private mv_strKeyColumn As String
    Private mv_strKeyFieldType As String
    Private mv_strRefColumn As String
    Private mv_strRefFieldType As String
    Private mv_strCmdSql As String
    Private mv_strObjName As String
    Private mv_strFormName As String
    Private mv_intSearchNum As Integer
    Private mv_strModuleCode As String
    Private mv_strIsLocalSearch As String
    Private mv_blnSearchOnInit As Boolean

    Private mv_arrSrFieldOperator() As String                   'Danh sách các toán tử đi?u ki�ện
    Private mv_arrSrOperator() As String                        'Mảng các toán tử đi?u ki�ện
    Private mv_arrSrSQLRef() As String                          'Câu lệnh SQL liên quan
    Private mv_arrSrFieldType() As String                       'Loại dữ liệu của trư?ng
    Private mv_arrSrFieldSrch() As String                       'T�ên các trư?ng l�àm tiêu chí để tìm kiếm
    Private mv_arrSrFieldDisp() As String                       'Tên các trư?ng s�ẽ hiển thị trên Combo
    Private mv_arrSrFieldMask() As String                       'Mặt nạ nhập dữ liệu
    Private mv_arrStFieldDefValue() As String                   'Gía trị mặc định
    Private mv_arrStSummaryCode() As String

    Private mv_arrSrFieldFormat() As String                     '?�ịnh dạng dữ liệu
    Private mv_arrSrFieldDisplay() As String                    'Có hiển thị trên lưới không
    Private mv_arrSrFieldWidth() As Integer                     '?�ộ rộng hiển thị trên lưới

    Private mv_arrStFieldMandartory() As String
    Private mv_arrStFieldMultiLang() As String                   'Có đa ngôn ngữ không
    Private mv_arrStFieldRefCDType() As String                   '
    Private mv_arrStFieldRefCDName() As String                   '

    Private mv_strLanguage As String
    Private mv_ResourceManager As Resources.ResourceManager
    Private mv_ResourceManagerGrid As Resources.ResourceManager


    Private mv_strBranchId As String
    Private mv_strTellerId As String
    Private mv_strTellerType As String
    Private mv_strTellerGroup As String
    Private mv_strBusDate As String
    Private mv_Worker As Thread = Nothing
    Private mv_strINTERVAL As String

    Public gvSearchSelection As GridCheckMarksSelection

#End Region

#Region " Các thuộc tính của form "
    Public Property TableName() As String
        Get
            Return mv_strTableName
        End Get
        Set(ByVal Value As String)
            mv_strTableName = Value
        End Set
    End Property

    Public Property UserLanguage() As String
        Get
            Return mv_strLanguage
        End Get
        Set(ByVal Value As String)
            mv_strLanguage = Value
        End Set
    End Property

    Public Property FormCaption() As String
        Get
            Return mv_strCaption
        End Get
        Set(ByVal Value As String)
            mv_strCaption = Value
        End Set
    End Property

    Public Property KeyColumn() As String
        Get
            Return mv_strKeyColumn
        End Get
        Set(ByVal Value As String)
            mv_strKeyColumn = Value
        End Set
    End Property

    Public Property KeyFieldType() As String
        Get
            Return mv_strKeyFieldType
        End Get
        Set(ByVal Value As String)
            mv_strKeyFieldType = Value
        End Set
    End Property

    Public ReadOnly Property ObjectName() As String
        Get
            Return mv_strObjName
        End Get
    End Property

    Public ReadOnly Property MaintenanceFormName() As String
        Get
            Return mv_strFormName
        End Get
    End Property

    Public Property ModuleCode() As String
        Get
            Return mv_strModuleCode
        End Get
        Set(ByVal Value As String)
            mv_strModuleCode = Value
        End Set
    End Property

    Public Property IsLocalSearch() As String
        Get
            Return mv_strIsLocalSearch
        End Get
        Set(ByVal Value As String)
            mv_strIsLocalSearch = Value
        End Set
    End Property

    Public Property SearchOnInit() As Boolean
        Get
            Return mv_blnSearchOnInit
        End Get
        Set(ByVal Value As Boolean)
            mv_blnSearchOnInit = Value
        End Set
    End Property

    Public Property BranchId() As String
        Get
            Return mv_strBranchId
        End Get
        Set(ByVal Value As String)
            mv_strBranchId = Value
        End Set
    End Property

    Public Property TellerId() As String
        Get
            Return mv_strTellerId
        End Get
        Set(ByVal Value As String)
            mv_strTellerId = Value
        End Set
    End Property

    Public Property BusDate() As String
        Get
            Return mv_strBusDate
        End Get
        Set(ByVal Value As String)
            mv_strBusDate = Value
        End Set
    End Property

    Public Property INTERVAL() As String
        Get
            Return mv_strINTERVAL
        End Get
        Set(ByVal Value As String)
            mv_strINTERVAL = Value
        End Set
    End Property


    Public ReadOnly Property ResourceManager() As Resources.ResourceManager
        Get
            Return mv_ResourceManager
        End Get
    End Property

    Public Property TellerType() As String
        Get
            Return mv_strTellerType
        End Get
        Set(ByVal Value As String)
            mv_strTellerType = Value
        End Set
    End Property

    Public Property TellerGroup() As String
        Get
            Return mv_strTellerGroup
        End Get
        Set(ByVal Value As String)
            mv_strTellerGroup = Value
        End Set
    End Property
#End Region

#Region " Overridable Function "
    'Protected Overridable Function OnSearch(Optional ByVal pv_strIsLocal As String = "", Optional ByVal pv_strModule As String = "") As Int32
    Public Overridable Function OnSearch(Optional ByVal pv_strIsLocal As String = "", Optional ByVal pv_strModule As String = "") As Int32
        Try
            Dim v_arrTellerGroup(), v_strTellerGroup As String

            If Not TellerGroup Is Nothing Then
                v_arrTellerGroup = TellerGroup.Split("|")
                v_strTellerGroup = "'" & CStr(v_arrTellerGroup(0)).Trim & "'"
                If v_arrTellerGroup.Length > 1 Then
                    For i As Integer = 1 To v_arrTellerGroup.Length - 2
                        v_strTellerGroup &= ", " & "'" & CStr(v_arrTellerGroup(i)).Trim & "'"
                    Next
                End If
                v_strTellerGroup = "(" & v_strTellerGroup & ")"
            Else
                v_strTellerGroup = "('')"
            End If

            Dim str_search, str_Clause As String

            Dim v_strFLDNAME As String

            'Update mouse pointer
            Cursor.Current = Cursors.WaitCursor

            mv_strSearchFilter = String.Empty
            For i As Integer = 0 To lstCondition.Items.Count - 1
                If lstCondition.GetItemChecked(i) Then
                    'mv_strSearchFilter &= " AND TLLOG." & hFilter(lstCondition.Items(i).ToString())
                    mv_strSearchFilter &= " AND " & hFilter(lstCondition.Items(i).ToString())
                End If
            Next
            If mv_strSearchFilter = "" Then
                mv_strSearchFilter = Mid(mv_strSearchFilter, 5) & " 0=0 ORDER BY TLLOG.AUTOID DESC "
            Else
                mv_strSearchFilter = Mid(mv_strSearchFilter, 5) & " ORDER BY TLLOG.AUTOID DESC "

            End If
            'mv_ResourceManager.GetString("ucSearch.ApproveConfirm")
            If (pv_strIsLocal <> "") And (pv_strModule <> "") Then

                'str_search = "pr_getUsSearch"
                'str_Clause = "TellerId!" & Trim(TellerId) & "!varchar2!20^BranchId!" & BranchId & "!varchar2!20^TellerGroup!" & v_strTellerGroup & "!Varchar2!4000^SearchFilter!" & mv_strSearchFilter & "!Varchar2!20000"
                If Me.UserLanguage = gc_LANG_ENGLISH Then
                    str_search = "pr_getussearch_en"
                Else
                    str_search = "pr_getUsSearch"
                End If

                str_Clause = "TellerId!" & Trim(TellerId) & "!varchar2!20^BranchId!" & BranchId & "!varchar2!20^SearchFilter!" & mv_strSearchFilter & "!Varchar2!20000"
                Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, pv_strIsLocal, gc_MsgTypeObj, pv_strModule, _
                    gc_ActionInquiry, IIf(str_search.Trim.Length() > 0, str_search, ""), str_Clause, , , , , , , gc_CommandProcedure)

                v_ws.Message(v_strObjMsg)

                'Fill data into search grid
                FillDataXtraGrid(SearchGrid, v_strObjMsg, c_ResourceManager & UserLanguage, mv_strTableName)

                If Not gvResult.Columns.Contains(gvResult.Columns("CheckMarkSelection")) Then
                    gvSearchSelection = New GridCheckMarksSelection(gvResult, TableName)
                    gvSearchSelection.CheckMarkColumn.VisibleIndex = 0
                    gvSearchSelection.CheckMarkColumn.OptionsColumn.Printable = DefaultBoolean.False
                End If
            End If
            gvSearchSelection.ClearSelection()
            'XtraGridFormat(gvResult, c_ResourceManager & UserLanguage, mv_arrSrFieldSrch, mv_arrSrFieldFormat, mv_arrSrFieldWidth, mv_arrSrFieldDisp, mv_arrSrFieldDisplay, mv_arrSrFieldFormat)
            'Update mouse pointer
            Cursor.Current = Cursors.Default
            tmrSearch.Enabled = c_BlnAutoSearch
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function

    Public Overridable Function OnHistory(Optional ByVal pv_strIsLocal As String = gc_IsNotLocalMsg, Optional ByVal pv_strModule As String = "") As Int32
        Try

            Dim str_search As String

            Dim v_arrTellerGroup(), v_strTellerGroup As String

            If Not TellerGroup Is Nothing Then
                v_arrTellerGroup = TellerGroup.Split("|")
                v_strTellerGroup = "'" & CStr(v_arrTellerGroup(0)).Trim & "'"
                If v_arrTellerGroup.Length > 1 Then
                    For k As Integer = 1 To v_arrTellerGroup.Length - 2
                        v_strTellerGroup &= ", " & "'" & CStr(v_arrTellerGroup(k)).Trim & "'"
                    Next
                End If
                v_strTellerGroup = "(" & v_strTellerGroup & ")"
            Else
                v_strTellerGroup = "('')"
            End If

            If Trim(TellerId) = "0001" Then
                str_search = " SELECT * FROM (SELECT TLLOG.CFFULLNAME CFFULLNAME,TLLOG.CFCUSTODYCD IDAFACCTNO, CF.CIFID, NVL(SB.SYMBOL,'---') CODEID, tltx.txdesc NAMENV, TLLOG.AUTOID,A1.CDCONTENT DELTD,nvl(tllog.txtime, to_char(tllog.createdt, 'hh24:mi:ss')) TXTIME,TLLOG.TXNUM,TLLOG.TXDATE,TLLOG.BUSDATE,TLLOG.BRID,TLLOG.TLTXCD,A0.CDCONTENT TXSTATUS," & ControlChars.CrLf _
                                & "TLLOG.TXDESC,MSGACCT ACCTNO, MSGAMT AMT, TLLOG.TLID,TLLOG.CHID,TLLOG.CHKID,TLLOG.OFFID, " & ControlChars.CrLf _
                                & "TLMAKER.TLNAME TLNAME, TLCASHIER.TLNAME CHNAME, TLCHECKER.TLNAME CHKNAME, TLOFFICER.TLNAME OFFNAME " & ControlChars.CrLf _
                                & "FROM TLLOGALL TLLOG, TLTX,SBSECURITIES SB, CFMAST CF, ALLCODE A0, ALLCODE A1, " & ControlChars.CrLf _
                                & "(SELECT TLID, TLNAME FROM TLPROFILES WHERE 0=0 UNION ALL SELECT '____' TLID, '____' TLNAME FROM DUAL) TLMAKER, " & ControlChars.CrLf _
                                & "(SELECT TLID, TLNAME FROM TLPROFILES WHERE 0=0 UNION ALL SELECT '____' TLID, '____' TLNAME FROM DUAL) TLCASHIER, " & ControlChars.CrLf _
                                & "(SELECT TLID, TLNAME FROM TLPROFILES WHERE 0=0 UNION ALL SELECT '____' TLID, '____' TLNAME FROM DUAL) TLOFFICER, " & ControlChars.CrLf _
                                & "(SELECT TLID, TLNAME FROM TLPROFILES WHERE 0=0 UNION ALL SELECT '____' TLID, '____' TLNAME FROM DUAL) TLCHECKER " & ControlChars.CrLf _
                                & "WHERE NOT (TLLOG.TLTXCD LIKE '%71'OR TLLOG.TLTXCD LIKE '%72') AND TLLOG.TLTXCD=TLTX.TLTXCD " & ControlChars.CrLf _
                                & "AND A0.CDTYPE='SY' AND A0.CDNAME = 'TXSTATUS' AND A0.CDVAL=TXSTATUS  " & ControlChars.CrLf _
                                & "AND A1.CDTYPE='SY' AND A1.CDNAME = 'YESNO' AND A1.CDVAL=DELTD " & ControlChars.CrLf _
                                & " AND TLLOG.ccyusage= SB.CODEID(+) and TLLOG.CFCUSTODYCD = CF.CUSTODYCD(+) " & ControlChars.CrLf _
                                & "AND (CASE WHEN TLLOG.TLID IS NULL THEN '____' ELSE TLLOG.TLID END)=TLMAKER.TLID " & ControlChars.CrLf _
                                & "AND (CASE WHEN TLLOG.CHID IS NULL THEN '____' ELSE TLLOG.CHID END)=TLCASHIER.TLID " & ControlChars.CrLf _
                                & "AND (CASE WHEN TLLOG.CHKID IS NULL THEN '____' ELSE TLLOG.CHKID END)=TLCHECKER.TLID " & ControlChars.CrLf _
                                & "AND (CASE WHEN TLLOG.OFFID IS NULL THEN '____' ELSE TLLOG.OFFID END)=TLOFFICER.TLID) TLLOG WHERE 0=0  "

            Else
                str_search = " SELECT distinct * FROM (SELECT TLLOG.CFFULLNAME CFFULLNAME,TLLOG.CFCUSTODYCD IDAFACCTNO, CF.CIFID, NVL(SB.SYMBOL,'---') CODEID, tltx.txdesc NAMENV,TLLOG.AUTOID,A1.CDCONTENT DELTD,nvl(tllog.txtime, to_char(tllog.createdt, 'hh24:mi:ss')) TXTIME,TLLOG.TXNUM,TLLOG.TXDATE,TLLOG.BUSDATE,TLLOG.BRID,TLLOG.TLTXCD,A0.CDCONTENT TXSTATUS, " & ControlChars.CrLf _
                                & "TLLOG.TXDESC,MSGACCT ACCTNO, MSGAMT AMT, TLLOG.TLID,TLLOG.CHID,TLLOG.CHKID,TLLOG.OFFID, " & ControlChars.CrLf _
                                & "TLMAKER.TLNAME TLNAME, TLCASHIER.TLNAME CHNAME, TLCHECKER.TLNAME CHKNAME, TLOFFICER.TLNAME OFFNAME " & ControlChars.CrLf _
                                & "FROM TLLOGALL TLLOG, TLTX,SBSECURITIES SB, CFMAST CF, ALLCODE A0, ALLCODE A1, " & ControlChars.CrLf _
                                & "(SELECT GRPID FROM TLGRPUSERS WHERE BRID='" & Me.BranchId & "' AND TLID='" & Me.TellerId & "' UNION ALL select 'XXXX' GRPID from dual) TLCAREBY," & ControlChars.CrLf _
                                & "(SELECT TLID, TLNAME FROM TLPROFILES WHERE 0=0 UNION ALL SELECT '____' TLID, '____' TLNAME FROM DUAL) TLMAKER, " & ControlChars.CrLf _
                                & "(SELECT TLID, TLNAME FROM TLPROFILES WHERE 0=0 UNION ALL SELECT '____' TLID, '____' TLNAME FROM DUAL) TLCASHIER, " & ControlChars.CrLf _
                                & "(SELECT TLID, TLNAME FROM TLPROFILES WHERE 0=0 UNION ALL SELECT '____' TLID, '____' TLNAME FROM DUAL) TLOFFICER, " & ControlChars.CrLf _
                                & "(SELECT TLID, TLNAME FROM TLPROFILES WHERE 0=0 UNION ALL SELECT '____' TLID, '____' TLNAME FROM DUAL) TLCHECKER " & ControlChars.CrLf _
                                & "WHERE NOT (TLLOG.TLTXCD LIKE '%71'OR TLLOG.TLTXCD LIKE '%72') AND TLLOG.TLTXCD=TLTX.TLTXCD " & ControlChars.CrLf _
                                & "AND (TLLOG.TLID= '" & TellerId & "' or  TLLOG.CAREBYGRP IS NULL OR (TLLOG.CAREBYGRP LIKE '%' || TLCAREBY.GRPID || '%')) " & ControlChars.CrLf _
                                & "AND A0.CDTYPE='SY' AND A0.CDNAME = 'TXSTATUS' AND A0.CDVAL=TXSTATUS  " & ControlChars.CrLf _
                                & "AND A1.CDTYPE='SY' AND A1.CDNAME = 'YESNO' AND A1.CDVAL=DELTD " & ControlChars.CrLf _
                                & " AND TLLOG.ccyusage= SB.CODEID(+) AND TLLOG.CFCUSTODYCD = CF.CUSTODYCD(+) " & ControlChars.CrLf _
                                & "AND (CASE WHEN TLLOG.TLID IS NULL THEN '____' ELSE TLLOG.TLID END)=TLMAKER.TLID " & ControlChars.CrLf _
                                & "AND (CASE WHEN TLLOG.CHID IS NULL THEN '____' ELSE TLLOG.CHID END)=TLCASHIER.TLID " & ControlChars.CrLf _
                                & "AND (CASE WHEN TLLOG.CHKID IS NULL THEN '____' ELSE TLLOG.CHKID END)=TLCHECKER.TLID " & ControlChars.CrLf _
                                & "AND (CASE WHEN TLLOG.OFFID IS NULL THEN '____' ELSE TLLOG.OFFID END)=TLOFFICER.TLID " & ControlChars.CrLf _
                                & "AND (TLLOG.BRID= '" & Me.BranchId & "' ) " & ControlChars.CrLf _
                                & "AND (SUBSTR(TLLOG.TXNUM,1,4) <> '9900' ) " & ControlChars.CrLf _
                                & "AND (TLLOG.TLID= '" & TellerId & "' " & ControlChars.CrLf _
                                & "OR (TLLOG.TLTXCD IN ( SELECT DISTINCT TLTXCD FROM TLAUTH WHERE TLTYPE='T' AND TLLIMIT >=0 and AUTHID= '" & TellerId & "' AND AUTHTYPE='U'" & ControlChars.CrLf _
                                & " UNION ALL SELECT DISTINCT TLTXCD FROM TLAUTH WHERE TLTYPE='T' AND TLLIMIT >=0 and AUTHID IN  " & v_strTellerGroup & "  AND AUTHTYPE='G'))" & ControlChars.CrLf _
                                & "OR (TLLOG.TLTXCD IN ( SELECT DISTINCT TLTXCD FROM TLAUTH WHERE TLTYPE='A' AND TLLIMIT >=0 and AUTHID= '" & TellerId & "' AND AUTHTYPE='U'" & ControlChars.CrLf _
                                & " UNION ALL SELECT DISTINCT TLTXCD FROM TLAUTH WHERE TLTYPE='A' AND TLLIMIT >=0 and AUTHID IN  " & v_strTellerGroup & "  AND AUTHTYPE='G'))" & ControlChars.CrLf _
                                & "OR (TLLOG.TLTXCD IN ( SELECT DISTINCT TLTXCD FROM TLAUTH WHERE TLTYPE='C' AND TLLIMIT >=0 and AUTHID= '" & TellerId & "' AND AUTHTYPE='U'" & ControlChars.CrLf _
                                & " UNION ALL SELECT DISTINCT TLTXCD FROM TLAUTH WHERE TLTYPE='C' AND TLLIMIT >=0 and AUTHID IN  " & v_strTellerGroup & "  AND AUTHTYPE='G'))" & ControlChars.CrLf _
                                & "OR (TLLOG.TLTXCD IN ( SELECT DISTINCT TLTXCD FROM TLAUTH WHERE TLTYPE='R' AND TLLIMIT >=0 and AUTHID= '" & TellerId & "' AND AUTHTYPE='U'" & ControlChars.CrLf _
                                & " UNION ALL SELECT DISTINCT TLTXCD FROM TLAUTH WHERE TLTYPE='R' AND TLLIMIT >=0 and AUTHID IN " & v_strTellerGroup & " AND AUTHTYPE='G'))))TLLOG WHERE 0=0 "
            End If

            Dim i, j As Integer

            'Update mouse pointer
            Cursor.Current = Cursors.WaitCursor

            mv_strSearchFilter = String.Empty
            For i = 0 To lstCondition.Items.Count - 1
                If lstCondition.GetItemChecked(i) Then
                    'mv_strSearchFilter &= " AND TLLOG." & hFilter(lstCondition.Items(i).ToString())
                    mv_strSearchFilter &= " AND " & hFilter(lstCondition.Items(i).ToString())
                End If
            Next i
            If mv_strSearchFilter = "" Then
                mv_strSearchFilter = Mid(mv_strSearchFilter, 5) & " 0=0 ORDER BY TLLOG.TXNUM DESC "
            Else
                mv_strSearchFilter = Mid(mv_strSearchFilter, 5) & " ORDER BY TLLOG.TXNUM DESC "
            End If
            If Strings.InStr(mv_strSearchFilter, "TLLOG.TXDATE =") <= 0 And Strings.InStr(mv_strSearchFilter, "TLLOG.BUSDATE =") <= 0 Then
                'MessageBox.Show("Điều kiện tìm kiếm không hợp lệ, cần phải tìm kiếm theo ngày chứng từ hoặc ngày giao dịch !")
                MsgBox(mv_ResourceManager.GetString("ERR_WRONG_CONDITION"))
                Return 0
            End If

            If (pv_strIsLocal <> "") And (pv_strModule <> "") And (Strings.InStr(mv_strSearchFilter, "TLLOG.TXDATE =") > 0 Or Strings.InStr(mv_strSearchFilter, "TLLOG.BUSDATE =") > 0) Then
                Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, pv_strIsLocal, gc_MsgTypeObj, "CF.CFMAST", _
                    gc_ActionInquiry, IIf(str_search.Trim.Length() > 0, str_search, ""), mv_strSearchFilter)

                v_ws.Message(v_strObjMsg)

                'Fill data into search grid
                'FillDataGrid(SearchGrid, v_strObjMsg, c_ResourceManagerGrid & UserLanguage, mv_strTableName, , 0)
                FillDataXtraGrid(SearchGrid, v_strObjMsg, c_ResourceManagerGrid & UserLanguage, mv_strTableName, , , , )

            End If

            'ssbPanelStatus.Text = String.Empty

            'Update mouse pointer
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function


    Protected Overridable Function OnView() As Int32
        Try
            'Lấy TXDATE và TXNUM
            Dim v_strTXNUM, v_strTXDATE, v_strNextTXNUM, v_strNextTXDATE, v_strTLTXCD As String
            Dim v_strDeltd As String

            Dim drv As DataRowView = CType(gvResult.GetFocusedRow, DataRowView)

            If Not (drv Is Nothing) Then
                Dim dr As DataRow = drv.Row
                v_strTXNUM = Trim(dr("TXNUM"))
                v_strTXDATE = Trim(dr("TXDATE"))
                v_strTLTXCD = Trim(dr("TLTXCD"))

                If InStr("8870/8874/8875/8876/8877/8882/8883/8884/8885", v_strTLTXCD) > 0 Then
                    'Fill vào màn hình dặt lệnh                    
                    v_strDeltd = Trim(dr("DELTD"))

                    Dim frm As New frmQuickOrderTransact(UserLanguage)
                    If InStr("8882/8883", v_strTLTXCD) > 0 Then
                        frm.mv_blnIsDelete = True
                        frm.mv_blnAmendment = False
                    ElseIf InStr("8884/8885", v_strTLTXCD) > 0 Then
                        frm.mv_blnIsDelete = True
                        frm.mv_blnAmendment = True
                    End If
                    frm.LocalObject = gc_IsNotLocalMsg
                    frm.ObjectName = ""
                    frm.TxDate = v_strTXDATE
                    frm.TxNum = v_strTXNUM
                    frm.BusDate = Me.BusDate
                    frm.TellerType = Me.TellerType
                    frm.BranchId = Me.BranchId
                    frm.TellerId = Me.TellerId
                    frm.TransactionDeleted = v_strDeltd
                    frm.ViewMode = True
                    frm.ShowDialog()
                ElseIf InStr("8894", v_strTLTXCD) > 0 Then
                    Dim frm As New frmSBETF(UserLanguage)
                    frm.Txnum = v_strTXNUM
                    frm.Txdate = v_strTXDATE
                    frm.UserLanguage = Me.UserLanguage
                    frm.BranchId = Me.BranchId
                    frm.TellerId = Me.TellerId
                    frm.ExeFlag = ExecuteFlag.Edit
                    frm.ShowDialog()
                ElseIf InStr("8800", v_strTLTXCD) > 0 Then
                    'Duyet import file
                    'TruongLD edit 06/02/2020
                    Dim frm As New frmReadFile(Me.UserLanguage)
                    frm.Txnum = v_strTXNUM
                    frm.TxDate = v_strTXDATE
                    frm.tltxcd = v_strTLTXCD
                    frm.FileID = Trim(dr("ACCTNO"))
                    frm.IsApprove = True
                    frm.IsImport = True
                    frm.IsTransaction = True
                    frm.BranchId = Me.BranchId
                    frm.TellerID = Me.TellerId
                    frm.BusDate = Me.BusDate
                    frm.UserLanguage = Me.UserLanguage
                    frm.ModuleCode = SUB_SYSTEM_SA
                    frm.ShowDialog()
                Else

                    'Hiển thị lên màn hình giao dịch
                    Dim frm As New frmTransactMaster(UserLanguage)
                    frm.LocalObject = gc_IsNotLocalMsg
                    frm.ObjectName = ""
                    frm.TxDate = v_strTXDATE
                    frm.TxNum = v_strTXNUM
                    frm.BusDate = Me.BusDate
                    frm.TellerType = Me.TellerType
                    frm.BranchId = Me.BranchId
                    frm.TellerId = Me.TellerId
                    frm.ShowDialog()

                End If
                'GianhVG chinh sua neu view giao dich trong ngay thi search lai
                'View giao dich trong qua khu thi giu nguyen man hinh search
                If v_strTXDATE = Me.BusDate Then
                    OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName)
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Protected Overridable Function OnRefuse(Optional ByVal prsRowFocus As Boolean = False) As Int32
        Try
            'Modified by ChienTD 12/01/2007
            'Purpose: Confirm before action
            'update tiennv
            Dim dt As DataTable = SearchGrid.DataSource
            If dt.Rows.Count = 0 Then
                Exit Function
            End If
            If MsgBox(mv_ResourceManager.GetString("ucSearch.RefuseConfirm"), MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Me.Text) = MsgBoxResult.Yes Then
                Dim v_strTXNUM, v_strTXDATE As String
                Dim success As Boolean = False
                If (prsRowFocus) Then
                    Dim drv As DataRowView = CType(gvResult.GetFocusedRow, DataRowView)
                    If Not (drv Is Nothing) Then
                        Dim dr As DataRow = drv.Row
                        v_strTXNUM = Trim(dr("TXNUM"))
                        v_strTXDATE = Trim(dr("TXDATE"))
                        success = RefuseTran(v_strTXNUM, v_strTXDATE)
                    End If
                Else
                    Dim drs As ArrayList = gvSearchSelection.GetSelectionRows()
                    If (drs Is Nothing Or drs.Count = 0) Then
                        MsgBox(mv_ResourceManager.GetString("ucSearch.SelectionRowIsNull"))
                        Exit Function
                    End If

                    For Each rv As DataRowView In drs
                        v_strTXNUM = Trim(rv.Row("TXNUM"))
                        v_strTXDATE = Trim(rv.Row("TXDATE"))
                        success = RefuseTran(v_strTXNUM, v_strTXDATE)
                        If Not success Then
                            Exit Function
                        End If
                    Next
                End If

                If success Then
                    MessageBox.Show(mv_ResourceManager.GetString("ucSearch.RefusedSuccessful"))
                    OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName)
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Private Function RefuseTran(ByVal v_strTXNUM As String, ByVal v_strTXDATE As String) As Boolean
        Dim result As Boolean
        Try
            'Lấy TXDATE và TXNUM
            Dim v_strTxMsg As String, v_intSTATUS As Integer, v_strOVRRQS, v_strCHKID, v_strOFFID, v_strDELTD As String
            Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
            'Lấy thông tin chi tiết v? �điện giao dịch
            Dim v_strClause, v_strObjMsg As String
            Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery

            'Lấy thông tin chung v? giao d�ịch. Message trả v? s�ẽ là TxMessage
            v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "GetMessage", , v_strTXNUM)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
            v_intSTATUS = CInt(CType(v_attrColl.GetNamedItem(gc_AtributeSTATUS), Xml.XmlAttribute).Value)
            v_strOVRRQS = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOVRRQS), Xml.XmlAttribute).Value)
            v_strCHKID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCHKID), Xml.XmlAttribute).Value)
            v_strOFFID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOFFID), Xml.XmlAttribute).Value)
            v_strDELTD = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeDELTD), Xml.XmlAttribute).Value)
            If v_intSTATUS = TransactStatus.Pending And Trim(v_strDELTD) <> "Y" Then
                'Chỉ cho phép duyệt đối với những giao dịch chưa hoàn tất và 
                If (Len(Trim(Replace(v_strOVRRQS, OVRRQS_CHECKER_CONTROL, vbNullString))) > 0 And Len(v_strCHKID) = 0) _
                    Or (InStr(v_strOVRRQS, OVRRQS_CHECKER_CONTROL) > 0 And Len(v_strOFFID) = 0) Then
                    v_strObjMsg = String.Empty
                    v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , TellerType, "RefuseMessage", , v_strTXNUM)
                    v_lngError = v_ws.Message(v_strObjMsg)
                    If v_lngError <> ERR_SYSTEM_OK Then
                        'Thông báo lỗi
                        GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                        Cursor.Current = Cursors.Default
                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Exit Function
                    End If
                    result = True
                End If
            ElseIf v_intSTATUS = TransactStatus.Deleting And Trim(v_strDELTD) <> "Y" Then
                'Chỉ cho phép duyệt đối với những giao dịch dang o trang thai deleting 

                v_strObjMsg = String.Empty
                v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , TellerType, "RefuseDeletingMessage", , v_strTXNUM)
                v_lngError = v_ws.Message(v_strObjMsg)
                If v_lngError <> ERR_SYSTEM_OK Then
                    'Thông báo lỗi
                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                    Cursor.Current = Cursors.Default
                    MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                    Exit Function
                End If
                result = True
            Else
                MsgBox(mv_ResourceManager.GetString("ucSearch.AllowWhenStatusDeletingOrNotComplete"))
                Return False
            End If

        Catch ex As Exception
            result = False
        End Try
        Return result
    End Function

    Protected Overridable Function OnApprove(Optional ByVal prsRowFocus As Boolean = False) As Int32
        Try
            'Modified by ChienTD 12/01/2007
            'Purpose: Confirm before action
            'update tiennv
            Dim dt As DataTable = SearchGrid.DataSource

            If dt.Rows.Count = 0 Then
                Exit Function
            End If

            If MsgBox(mv_ResourceManager.GetString("ucSearch.ApproveConfirm"), MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Me.Text) = MsgBoxResult.Yes Then
                'Lấy TXDATE và TXNUM
                Dim v_blTick As Boolean = False, v_blProccess As Boolean = False

                Dim v_strTXNUM, v_strTXDATE, v_strTxMsg As String, v_intSTATUS As Integer, v_strOVRRQS, v_strTLTXCD, v_strCHKID, v_strOFFID, v_strDELTD, v_strTLID, v_strOFFNAME As String
                Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long

                'TungNT sua co the approve all, neu co tick thi se thuc hien, ko thi chi thuc hien dong current
                Dim v_lngApprCount As Long = 0

                If (prsRowFocus) Then
                    Dim drv As DataRowView = gvResult.GetFocusedRow
                    If (drv IsNot Nothing) Then
                        Dim dr As DataRow = drv.Row
                        v_strTXNUM = Trim(dr("TXNUM"))
                        v_strTXDATE = Trim(dr("TXDATE"))
                        v_strOFFNAME = Trim(dr("OFFNAME"))
                        v_blProccess = ApproveTran(v_strTXNUM, v_strTXDATE, v_blProccess)
                        If v_blProccess Then
                            v_lngApprCount = v_lngApprCount + 1
                        End If

                    End If
                Else
                    Dim drs As ArrayList = gvSearchSelection.GetSelectionRows()
                    If (drs Is Nothing Or drs.Count = 0) Then
                        MsgBox(mv_ResourceManager.GetString("ucSearch.SelectionRowIsNull"))
                        Exit Function
                    End If

                    For Each rv As DataRowView In drs
                        v_strTXNUM = Trim(rv.Row("TXNUM")) 'Trim(CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("TXNUM").Value)
                        v_strTXDATE = Trim(rv.Row("TXDATE")) 'Trim(CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("TXDATE").Value)
                        v_strOFFNAME = Trim(rv.Row("OFFNAME")) 'Trim(CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("OFFNAME").Value)
                        v_blProccess = ApproveTran(v_strTXNUM, v_strTXDATE, v_blProccess)
                        If v_blProccess = False Then
                            Exit For
                        Else
                            v_lngApprCount = v_lngApprCount + 1
                        End If
                    Next
                End If
                MessageBox.Show(mv_ResourceManager.GetString("ucSearch.ApprovedCountSuccessful").Replace("{0}", v_lngApprCount.ToString("###,##0")))
                'End
            End If
            OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    'TungNT - tach ham approve sang ham khac
    Private Function ApproveTran(ByVal pv_strTxNum As String, ByVal pv_strTxDate As String, ByVal pv_strOffName As String) As Long
        Dim v_strTXNUM, v_strTXDATE, v_strTxMsg As String, v_intSTATUS As Integer, v_strOVRRQS, v_strTLTXCD, v_strCHKID, v_strOFFID, v_strDELTD, v_strTLID, v_strOFFNAME As String
        Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long

        v_strTXNUM = pv_strTxNum 'Trim(CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("TXNUM").Value)
        v_strTXDATE = pv_strTxDate 'Trim(CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("TXDATE").Value)
        v_strOFFNAME = pv_strOffName 'Trim(CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("OFFNAME").Value)
        'Lấy thông tin chi tiết v? �điện giao dịch
        Dim v_strClause, v_strObjMsg As String
        Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strWarningMessage As String = String.Empty
        Dim v_strInfoMessage As String = String.Empty

        Try
            'Lấy thông tin chung v? giao d�ịch. Message trả v? s�ẽ là TxMessage
            v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "GetMessage", , v_strTXNUM)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
            v_intSTATUS = CInt(CType(v_attrColl.GetNamedItem(gc_AtributeSTATUS), Xml.XmlAttribute).Value)
            v_strOVRRQS = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOVRRQS), Xml.XmlAttribute).Value)
            v_strTLTXCD = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLTXCD), Xml.XmlAttribute).Value)
            v_strCHKID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCHKID), Xml.XmlAttribute).Value)
            v_strOFFID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOFFID), Xml.XmlAttribute).Value)
            v_strDELTD = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeDELTD), Xml.XmlAttribute).Value)
            v_strTLID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            If v_intSTATUS = TransactStatus.Pending And Trim(v_strDELTD) <> "Y" Then
                'Chỉ cho phép duyệt đối với những giao dịch chưa hoàn tất và 
                If (Len(Trim(Replace(v_strOVRRQS, OVRRQS_CHECKER_CONTROL, vbNullString))) > 0 And Len(v_strCHKID) = 0) _
                    Or (InStr(v_strOVRRQS, OVRRQS_CHECKER_CONTROL) > 0 And Len(v_strOFFID) = 0) Then
                    v_strObjMsg = String.Empty
                    v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , TellerType, "ApproveMessage", , v_strTXNUM)
                    v_lngError = v_ws.Message(v_strObjMsg)

                    ''get Warning Message
                    GetWarningFromMessage(v_strObjMsg, v_strWarningMessage, v_strInfoMessage)
                    Cursor.Current = Cursors.Default
                    If v_strInfoMessage <> String.Empty Then
                        MsgBox(v_strInfoMessage, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, Me.Text)
                    End If
                    If v_strWarningMessage <> String.Empty Then
                        MsgBox(v_strWarningMessage, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, Me.Text)
                    End If

                    If v_lngError <> ERR_SYSTEM_OK Then
                        'Thông báo lỗi
                        If v_strTLTXCD = gc_CF_REMAP_TOKEN Then
                            Dim v_xmlErrorDocument As XmlDocumentEx
                            v_xmlErrorDocument = New XmlDocumentEx()
                            v_xmlErrorDocument.LoadXml(v_strObjMsg)
                            Dim v_xmlerrorNode = v_xmlErrorDocument.SelectSingleNode("ObjectMessage/ObjData/Entry[@fldname='p_err_message']")
                            If Not (v_xmlerrorNode Is Nothing) Then
                                v_strErrorMessage = v_xmlerrorNode.InnerText
                                Cursor.Current = Cursors.Default
                                MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                                Exit Function
                            Else
                                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                                Cursor.Current = Cursors.Default
                                MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                                Exit Function
                            End If
                        Else
                            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                            Cursor.Current = Cursors.Default
                            MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                            Exit Function
                        End If
                        Return False
                    End If
                    'MessageBox.Show(mv_ResourceManager.GetString("ucSearch.ApprovedSuccessful"))
                    Return True
                End If
            ElseIf v_intSTATUS = TransactStatus.Deleting And Trim(v_strDELTD) <> "Y" Then
                'Duyệt xoá
                'Ducnv kiem tra chi maker moi duoc delete
                'Voi giao dich 9902 xoa giao dich GL trong qua khu thi khong can phai chi maker moi duoc xoa
                If v_strTLTXCD <> gc_GL_NORMAL Then
                    If Trim(Me.TellerId) <> ADMIN_ID And v_strOFFID.Length > 0 And Trim(Me.TellerId) <> Trim(v_strOFFID) Then
                        MsgBox(String.Format(mv_ResourceManager.GetString("ucSearch.ErrorApprove"), v_strOFFNAME))
                        Return False
                    End If
                End If


                v_strObjMsg = String.Empty
                v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , TellerType, "ApproveDeleteMessage", , v_strTXNUM)
                v_lngError = v_ws.Message(v_strObjMsg)
                If v_lngError <> ERR_SYSTEM_OK Then
                    'Thông báo lỗi
                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                    Cursor.Current = Cursors.Default
                    MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                    Return False
                End If
                'MessageBox.Show(mv_ResourceManager.GetString("ucSearch.DeleteSuccessful"))
                Return True
            End If

            Return True
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    'End

    Protected Overridable Function OnApproveALL() As Int32
        Try
            Dim dt As DataTable = SearchGrid.DataSource

            If dt Is Nothing Or dt.Rows.Count = 0 Then
                Exit Function
            End If
            If MsgBox(mv_ResourceManager.GetString("ucSearch.ApproveConfirm"), MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Me.Text) = MsgBoxResult.Yes Then
                'Update mouse pointer
                Cursor.Current = Cursors.WaitCursor
                'Không định timer
                tmrSearch.Enabled = False
                If dt.Rows.Count > 0 Then
                    Dim i As Integer
                    For i = 0 To dt.Rows.Count - 1
                        'Lấy TXDATE và TXNUM
                        Dim v_strTXNUM, v_strTXDATE, v_strTxMsg As String, v_intSTATUS As Integer, v_strOVRRQS, v_strCHKID, v_strOFFID, v_strDELTD As String
                        Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
                        If Not (dt.Rows(i) Is Nothing) Then
                            v_strTXNUM = Trim(dt.Rows(i)("TXNUM"))
                            v_strTXDATE = Trim(dt.Rows(i)("TXDATE"))
                            'Lấy thông tin chi tiết v? �điện giao dịch
                            Dim v_strClause, v_strObjMsg As String
                            Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument
                            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery

                            'Lấy thông tin chung v? giao d�ịch. Message trả v? s�ẽ là TxMessage
                            v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "GetMessage", , v_strTXNUM)
                            v_ws.Message(v_strObjMsg)
                            v_xmlDocument.LoadXml(v_strObjMsg)
                            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
                            v_intSTATUS = CInt(CType(v_attrColl.GetNamedItem(gc_AtributeSTATUS), Xml.XmlAttribute).Value)
                            v_strOVRRQS = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOVRRQS), Xml.XmlAttribute).Value)
                            v_strCHKID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCHKID), Xml.XmlAttribute).Value)
                            v_strOFFID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOFFID), Xml.XmlAttribute).Value)
                            v_strDELTD = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeDELTD), Xml.XmlAttribute).Value)
                            If v_intSTATUS = TransactStatus.Pending And Trim(v_strDELTD) <> "Y" Then
                                'Chỉ cho phép duyệt đối với những giao dịch chưa hoàn tất và 
                                If (Len(Trim(Replace(v_strOVRRQS, OVRRQS_CHECKER_CONTROL, vbNullString))) > 0 And Len(v_strCHKID) = 0) _
                                    Or (InStr(v_strOVRRQS, OVRRQS_CHECKER_CONTROL) > 0 And Len(v_strOFFID) = 0) Then
                                    v_strObjMsg = String.Empty
                                    v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , TellerType, "ApproveMessage", , v_strTXNUM)
                                    v_lngError = v_ws.Message(v_strObjMsg)
                                    'If v_lngError <> ERR_SYSTEM_OK Then
                                    '    'Thông báo lỗi
                                    '    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                                    '    MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, Me.Text)
                                    'End If
                                End If
                            End If
                        End If
                    Next
                End If
                gvSearchSelection.ClearSelection()
                MessageBox.Show(mv_ResourceManager.GetString("ucSearch.ApprovedSuccessful"))
                OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName)
                'Kích hoạt Timer
                tmrSearch.Enabled = c_BlnAutoSearch
                'Update mouse pointer
                Cursor.Current = Cursors.Default
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Protected Overridable Function OnReject(Optional ByVal prsRowFocus As Boolean = False) As Int32
        Try
            'Modified by ChienTD 12/01/2007
            'Purpose: Confirm before action
            Dim dt As DataTable = SearchGrid.DataSource

            If dt Is Nothing Or dt.Rows.Count = 0 Then
                Exit Function
            End If
            If MsgBox(mv_ResourceManager.GetString("ucSearch.RejectConfirm"), MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Me.Text) = MsgBoxResult.Yes Then
                Dim v_strTXNUM, v_strTXDATE, v_strErrorMessage As String
                Dim success As Boolean = False

                If (prsRowFocus) Then
                    Dim drv As DataRowView = gvResult.GetFocusedRow
                    If Not (drv Is Nothing) Then
                        Dim dr As DataRow = drv.Row
                        v_strTXNUM = Trim(dr("TXNUM"))
                        v_strTXDATE = Trim(dr("TXDATE"))
                        success = RejectTran(v_strTXNUM, v_strTXDATE)
                    End If
                Else
                    Dim drs As ArrayList = gvSearchSelection.GetSelectionRows()
                    If (drs Is Nothing Or drs.Count = 0) Then
                        MsgBox(mv_ResourceManager.GetString("ucSearch.SelectionRowIsNull"))
                        Exit Function
                    End If

                    For Each rv As DataRowView In drs
                        v_strTXNUM = Trim(rv.Row("TXNUM"))
                        v_strTXDATE = Trim(rv.Row("TXDATE"))
                        success = RejectTran(v_strTXNUM, v_strTXDATE)
                        If Not success Then
                            Exit Function
                        End If
                    Next
                End If

                If (success) Then
                    MessageBox.Show(mv_ResourceManager.GetString("ucSearch.RerectedSuccessful"))
                    gvSearchSelection.ClearSelection()
                    OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName)
                End If


            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Private Function RejectTran(ByVal v_strTXNUM As String, ByVal v_strTXDATE As String) As Boolean
        Dim result As Boolean = False
        Try
            'Lấy TXDATE và TXNUM
            Dim v_strTxMsg As String, v_intSTATUS As Integer, v_strOVRRQS, v_strCHKID, v_strOFFID, v_strDELTD As String
            Dim v_strErrorSource, v_strErrorMessage, v_strCommentMessage As String, v_lngError As Long
            'Lấy thông tin chi tiết v? �điện giao dịch
            Dim v_strClause, v_strObjMsg As String
            Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery

            'Lấy thông tin chung v? giao d�ịch. Message trả v? s�ẽ là TxMessage
            v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "GetMessage", , v_strTXNUM)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
            v_intSTATUS = CInt(CType(v_attrColl.GetNamedItem(gc_AtributeSTATUS), Xml.XmlAttribute).Value)
            v_strOVRRQS = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOVRRQS), Xml.XmlAttribute).Value)
            v_strCHKID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCHKID), Xml.XmlAttribute).Value)
            v_strOFFID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOFFID), Xml.XmlAttribute).Value)
            v_strDELTD = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeDELTD), Xml.XmlAttribute).Value)
            v_strCommentMessage = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXDESC), Xml.XmlAttribute).Value)

            If (v_intSTATUS <> TransactStatus.Pending) Then
                MsgBox(mv_ResourceManager.GetString("ucSearch.RejectWhenPending"))
                Return False
            End If

            If v_intSTATUS = TransactStatus.Pending And Trim(v_strDELTD) <> "Y" Then
                'Chỉ cho phép duyệt đối với những giao dịch đang cho duyet
                If (Len(Trim(Replace(v_strOVRRQS, OVRRQS_CHECKER_CONTROL, vbNullString))) > 0 And Len(v_strCHKID) = 0) _
                    Or (InStr(v_strOVRRQS, OVRRQS_CHECKER_CONTROL) > 0 And Len(v_strOFFID) = 0) Then
                    'Hiển thị InputBox yêu cầu nhập lý do Reject
                    v_strCommentMessage = InputBox(mv_ResourceManager.GetString("ucSearch.RejectComment"), Me.Text, v_strCommentMessage)
                    If Len(Trim(v_strCommentMessage)) > 0 Then
                        v_strObjMsg = String.Empty
                        v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "RejectMessage", , v_strTXNUM, v_strCommentMessage)
                        v_lngError = v_ws.Message(v_strObjMsg)
                        If v_lngError <> ERR_SYSTEM_OK Then
                            'Thông báo lỗi
                            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                            Cursor.Current = Cursors.Default
                            MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                            Exit Function
                        End If
                        result = True
                    End If
                End If
            End If
        Catch ex As Exception
            result = False
        End Try
        Return result

    End Function
    Protected Overridable Function OnCashierALL() As Int32
        Try
            'Modified by ChienTD 12/01/2007
            'Purpose: Confirm before action
            Dim dt As DataTable = SearchGrid.DataSource
            If dt Is Nothing Or dt.Rows.Count = 0 Then
                Exit Function
            End If
            If MsgBox(mv_ResourceManager.GetString("ucSearch.CashierConfirm"), MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Me.Text) = MsgBoxResult.Yes Then
                'Update mouse pointer
                Cursor.Current = Cursors.WaitCursor
                'Không định timer
                tmrSearch.Enabled = False

                If dt.Rows.Count > 0 Then
                    Dim i As Integer
                    For i = 0 To dt.Rows.Count - 1
                        'Lấy TXDATE và TXNUM
                        Dim v_strTXNUM, v_strTXDATE, v_strTxMsg As String, v_intSTATUS As Integer, v_strDELTD As String
                        Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
                        If Not (dt.Rows(i) Is Nothing) Then
                            v_strTXNUM = Trim(dt.Rows(i)("TXNUM"))
                            v_strTXDATE = Trim(dt.Rows(i)("TXDATE"))
                            'Lấy thông tin chi tiết v? �điện giao dịch
                            Dim v_strClause, v_strObjMsg As String
                            Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument
                            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery

                            'Lấy thông tin chung v? giao d�ịch. Message trả v? s�ẽ là TxMessage
                            v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "GetMessage", , v_strTXNUM)
                            v_ws.Message(v_strObjMsg)
                            v_xmlDocument.LoadXml(v_strObjMsg)
                            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
                            v_intSTATUS = CInt(CType(v_attrColl.GetNamedItem(gc_AtributeSTATUS), Xml.XmlAttribute).Value)
                            v_strDELTD = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeDELTD), Xml.XmlAttribute).Value)
                            If v_intSTATUS = TransactStatus.Cashier And Trim(v_strDELTD) <> "Y" Then
                                'Chỉ cho phép thanh toán đối với các giao dịch đang ở trạng thái ch? thanh to�án
                                v_strObjMsg = String.Empty
                                v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , TellerType, "CashMessage", , v_strTXNUM)
                                v_lngError = v_ws.Message(v_strObjMsg)
                                If v_lngError <> ERR_SYSTEM_OK Then
                                    'Thông báo lỗi
                                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                                    MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                                End If
                            End If
                        End If
                    Next
                End If
                MessageBox.Show(mv_ResourceManager.GetString("ucSearch.CashieredSuccessful"))
                OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName)
                'Kích hoạt Timer
                tmrSearch.Enabled = c_BlnAutoSearch
                'Update mouse pointer
                Cursor.Current = Cursors.Default
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Protected Overridable Function OnDelete(Optional ByVal prsRowFocus As Boolean = False) As Int32
        Try
            'Modified by ChienTD 12/01/2007
            'Purpose: Confirm before action
            Dim dt As DataTable = SearchGrid.DataSource
            If dt Is Nothing Or dt.Rows.Count = 0 Then
                Exit Function
            End If
            If MsgBox(mv_ResourceManager.GetString("ucSearch.DelConfirm"), MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Me.Text) = MsgBoxResult.Yes Then
                'Lấy TXDATE và TXNUM
                Dim v_blTick As Boolean = False, v_blProccess As Boolean = False

                Dim v_strTXNUM, v_strTXDATE, v_strBUSDATE, v_strTLTXCD, v_strTxMsg, v_strDESC As String, v_intSTATUS As Integer, v_strOVRRQS, v_strCHKID, v_strOFFID, v_strDELTD, v_strTLID, v_strTLNAME As String
                Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
                If (prsRowFocus) Then
                    Dim drv As DataRowView = gvResult.GetFocusedRow
                    If Not (drv Is Nothing) Then
                        Dim dr As DataRow = drv.Row
                        v_strTXNUM = Trim(dr("TXNUM"))
                        v_strTXDATE = Trim(dr("TXDATE"))
                        v_strBUSDATE = Trim(dr("BUSDATE"))
                        v_strTLTXCD = Trim(dr("TLTXCD"))
                        v_strDESC = Trim(dr("TXDESC"))
                        v_strTLNAME = Trim(dr("TLNAME"))
                        v_blProccess = DeleteTran(v_strTXNUM, v_strTXDATE, v_strBUSDATE, v_strTLTXCD, v_strDESC, v_strTLNAME)
                    End If
                Else
                    Dim drs As ArrayList = gvSearchSelection.GetSelectionRows()
                    If (drs Is Nothing Or drs.Count = 0) Then
                        MsgBox(mv_ResourceManager.GetString("ucSearch.SelectionRowIsNull"))
                        Exit Function
                    End If
                    For Each rv As DataRowView In drs
                        v_strTXNUM = Trim(rv.Row("TXNUM"))
                        v_strTXDATE = Trim(rv.Row("TXDATE"))
                        v_strBUSDATE = Trim(rv.Row("BUSDATE"))
                        v_strTLTXCD = Trim(rv.Row("TLTXCD"))
                        v_strDESC = Trim(rv.Row("TXDESC"))
                        v_strTLNAME = Trim(rv.Row("TLNAME"))
                        v_blProccess = DeleteTran(v_strTXNUM, v_strTXDATE, v_strBUSDATE, v_strTLTXCD, v_strDESC, v_strTLNAME)
                        If Not v_blProccess Then
                            Exit For
                        End If
                    Next
                End If
                OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Private Function DeleteTran(ByVal pv_strTxNum As String, ByVal pv_strTxDate As String, _
                                ByVal pv_strBusDate As String, ByVal pv_strTltxcd As String, _
                                ByVal pv_strDesc As String, ByVal pv_strTlName As String) As Boolean
        Dim v_strTXNUM, v_strTXDATE, v_strBUSDATE, v_strTLTXCD, v_strTxMsg, v_strDESC As String, v_intSTATUS As Integer, v_strOVRRQS, v_strCHKID, v_strOFFID, v_strDELTD, v_strTLID, v_strTLNAME As String
        Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
        Try
            v_strTXNUM = pv_strTxNum 'Trim(CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("TXNUM").Value)
            v_strTXDATE = pv_strTxDate 'Trim(CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("TXDATE").Value)
            v_strBUSDATE = pv_strBusDate 'Trim(CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("BUSDATE").Value)
            v_strTLTXCD = pv_strTltxcd 'Trim(CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("TLTXCD").Value)
            v_strDESC = pv_strDesc 'Trim(CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("TXDESC").Value)
            v_strTLNAME = pv_strTlName 'Trim(CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("TLNAME").Value)

            'Lấy thông tin chi tiết v? �điện giao dịch
            Dim v_strClause, v_strObjMsg As String
            Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery

            'Lấy thông tin chung v? giao d�ịch. Message trả v? s�ẽ là TxMessage
            v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "GetMessage", , v_strTXNUM)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
            v_intSTATUS = CInt(CType(v_attrColl.GetNamedItem(gc_AtributeSTATUS), Xml.XmlAttribute).Value)
            v_strOVRRQS = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOVRRQS), Xml.XmlAttribute).Value)
            v_strCHKID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCHKID), Xml.XmlAttribute).Value)
            v_strOFFID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOFFID), Xml.XmlAttribute).Value)
            v_strDELTD = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeDELTD), Xml.XmlAttribute).Value)
            v_strTLID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            'Ducnv kiem tra chi maker moi duoc delete
            'Voi giao dich 9902 xoa giao dich GL trong qua khu thi khong can phai chi maker moi duoc xoa
            If v_strTLTXCD <> gc_GL_NORMAL Then
                If Trim(Me.TellerId) <> ADMIN_ID And Trim(Me.TellerId) <> Trim(v_strTLID) Then
                    MsgBox(String.Format(mv_ResourceManager.GetString("ucSearch.ErrorDelete"), v_strTLNAME))
                    Return False
                End If
            End If


            If v_strTLTXCD = gc_GL_NORMAL And v_strTXDATE <> Me.BusDate Then
                Dim drv As DataRowView = gvResult.GetFocusedRow
                If (drv IsNot Nothing) Then
                    v_strDELTD = Strings.Mid((drv.Row("DELTD")), 1, 1)
                End If
            End If
            If Trim(v_strDELTD) <> "Y" And v_intSTATUS <> TransactStatus.ErrorOccured And v_intSTATUS <> TransactStatus.Refuse And v_intSTATUS <> TransactStatus.Completed And v_intSTATUS <> TransactStatus.Deleting Then
                If v_strTLTXCD = gc_GL_NORMAL And v_strTXDATE <> Me.BusDate Then
                    Reverse9900(v_strTXNUM, v_strTXDATE, v_strDESC)
                Else
                    'Chỉ xoá đối với những giao dịch chưa bị xoá và không lỗi và chưa bị refuse
                    v_strObjMsg = String.Empty
                    v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "DeleteMessage", , v_strTXNUM)
                    v_lngError = v_ws.Message(v_strObjMsg)
                    If v_lngError <> ERR_SYSTEM_OK Then
                        'Thông báo lỗi
                        GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                        Cursor.Current = Cursors.Default
                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Exit Function
                    End If
                    MessageBox.Show(mv_ResourceManager.GetString("ucSearch.DeletingSuccessful"))
                    Return True
                End If
            ElseIf Trim(v_strDELTD) <> "Y" And v_intSTATUS = TransactStatus.Completed Then
                'Thuc hien xoa voi giao dich o trang thai Complete chuyen thanh Pending to Delete
                v_strObjMsg = String.Empty
                v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "DeletingMessage", , v_strTXNUM)
                v_lngError = v_ws.Message(v_strObjMsg)
                If v_lngError <> ERR_SYSTEM_OK Then
                    'Thông báo lỗi
                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                    Cursor.Current = Cursors.Default
                    If v_lngError = ERR_SA_CHECKER1_OVR Or v_lngError = ERR_SA_CHECKER2_OVR Then
                        GetReasonFromMessage(v_strObjMsg, v_strErrorMessage, Me.UserLanguage)
                    End If
                    MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                    Return False
                End If
                MessageBox.Show(mv_ResourceManager.GetString("ucSearch.DeletingSuccessful"))
                Return True
            End If
            Return True
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Public Function Reverse9900(ByVal v_strTXNUM As String, ByVal v_strTXDATE As String, ByVal v_strDESC As String) As Integer
        Dim frm As New frmTransact(UserLanguage)
        frm.LocalObject = gc_IsNotLocalMsg
        frm.ObjectName = ""
        frm.TxDate = v_strTXDATE
        frm.TxNum = v_strTXNUM
        frm.TXDESC = v_strDESC
        frm.BusDate = Me.BusDate
        frm.TellerType = Me.TellerType
        frm.BranchId = Me.BranchId
        frm.TellerId = Me.TellerId
        frm.Tltxcd = gc_GL_REVERSE9900
        frm.ShowDialog()
    End Function

    Protected Overridable Function OnCashier(Optional ByVal prsRowFocus As Boolean = False) As Int32
        Try
            'Modified by ChienTD 12/01/2007
            'Purpose: Confirm before action
            Dim dt As DataTable = SearchGrid.DataSource
            If dt Is Nothing Or dt.Rows.Count = 0 Then
                Exit Function
            End If
            If MsgBox(mv_ResourceManager.GetString("ucSearch.CashierConfirm"), MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Me.Text) = MsgBoxResult.Yes Then
                'Lấy TXDATE và TXNUM
                Dim v_blTick As Boolean = False, v_blProccess As Boolean = False

                Dim v_strTXNUM, v_strTXDATE, v_strTxMsg As String, v_intSTATUS As Integer, v_strDELTD As String
                Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long

                If (prsRowFocus) Then
                    Dim drv As DataRowView = gvResult.GetFocusedRow
                    If drv IsNot Nothing Then
                        v_strTXNUM = Trim(drv.Row("TXNUM"))
                        v_strTXDATE = Trim(drv.Row("TXDATE"))
                        v_blProccess = CashierTran(v_strTXNUM, v_strTXDATE)
                    End If
                Else
                    Dim drs As ArrayList = gvSearchSelection.GetSelectionRows()
                    If (drs Is Nothing Or drs.Count = 0) Then
                        MsgBox(mv_ResourceManager.GetString("ucSearch.SelectionRowIsNull"))
                        Exit Function
                    End If

                    For Each rv As DataRowView In drs
                        v_strTXNUM = Trim(rv.Row("TXNUM"))
                        v_strTXDATE = Trim(rv.Row("TXDATE"))

                        v_blTick = True
                        v_blProccess = CashierTran(v_strTXNUM, v_strTXDATE)
                        If Not v_blProccess Then
                            Exit For
                        End If
                    Next
                End If
            End If
            OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Private Function CashierTran(ByVal pv_strTxNum As String, ByVal pv_strTxDate As String) As Boolean
        'Lấy TXDATE và TXNUM
        Dim v_strTXNUM, v_strTXDATE, v_strTxMsg As String, v_intSTATUS As Integer, v_strDELTD As String
        Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long

        v_strTXNUM = pv_strTxNum
        v_strTXDATE = pv_strTxDate
        Try
            'Lấy thông tin chi tiết v? �điện giao dịch
            Dim v_strClause, v_strObjMsg As String
            Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery

            'Lấy thông tin chung v? giao d�ịch. Message trả v? s�ẽ là TxMessage
            v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "GetMessage", , v_strTXNUM)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
            v_intSTATUS = CInt(CType(v_attrColl.GetNamedItem(gc_AtributeSTATUS), Xml.XmlAttribute).Value)
            v_strDELTD = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeDELTD), Xml.XmlAttribute).Value)
            If v_intSTATUS = TransactStatus.Cashier And Trim(v_strDELTD) <> "Y" Then
                'Chỉ cho phép thanh toán đối với các giao dịch đang ở trạng thái ch? thanh to�án
                v_strObjMsg = String.Empty
                v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , TellerType, "CashMessage", , v_strTXNUM)
                v_lngError = v_ws.Message(v_strObjMsg)
                If v_lngError <> ERR_SYSTEM_OK Then
                    'Thông báo lỗi
                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                    Cursor.Current = Cursors.Default
                    MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                    Return False
                End If
                MessageBox.Show(mv_ResourceManager.GetString("ucSearch.CashieredSuccessful"))
                Return True
            End If

            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Protected Overridable Function OnExport() As Int32
        Try
            Dim v_dlgSave As New SaveFileDialog
            Dim v_strTemp As String
            v_dlgSave.Filter = "Text files (*.txt)|*.txt|CSV files (*.csv)|*.csv|Excel files (*.xls)|*.xls|Excel files (*.xlsx)|*.xlsx|Pdf files (*.pdf)|*.pdf|All files (*.*)|*.*"
            v_dlgSave.RestoreDirectory = True
            Dim v_res As DialogResult = v_dlgSave.ShowDialog(Me)
            Dim v_filetype As String
            'CreateExcelFile.CreateExcelDocument(ds, targetFilename)

            If v_res = DialogResult.OK Then
                Dim v_strFileName As String = v_dlgSave.FileName

                'trung.luu check extension khi chon export all file (*.*)
                Dim extension As String = Path.GetExtension(v_strFileName)
                If extension = "" Then
                    MsgBox(mv_ResourceManager.GetString("ucSearch.NothingExtension"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                End If

                'v_filetype = Mid(v_strFileName, Len(v_strFileName) - 3)
                v_filetype = Mid(v_strFileName, InStr(v_strFileName, "."))
                If v_filetype = ".txt" Or v_filetype = ".csv" Then
                    Dim v_strData As String
                    Dim v_streamWriter As New StreamWriter(v_strFileName, False, System.Text.Encoding.Unicode)

                    If (gvResult.RowCount > 0) Then
                        'Write file's header
                        v_strData = String.Empty
                        For idx As Integer = 0 To gvResult.Columns.Count - 1
                            If gvResult.Columns(idx).Visible Then
                                If gvResult.Columns(idx).Caption <> "Mark" Then
                                    v_strData &= gvResult.Columns(idx).Caption & vbTab
                                End If

                            End If
                        Next
                        v_streamWriter.WriteLine(v_strData)

                        'Write data
                        For i As Integer = 0 To gvResult.RowCount - 1
                            v_strData = String.Empty

                            For j As Integer = 0 To gvResult.Columns.Count - 1
                                If gvResult.Columns(j).Visible Then

                                    If gvResult.Columns(j).Caption <> "Mark" Then
                                        If v_filetype = ".txt" Then
                                            v_strTemp = "@" & CStr(gvResult.GetDataRow(i)(j))
                                        Else
                                            v_strTemp = CStr(gvResult.GetDataRow(i)(j))
                                        End If

                                        v_strData &= v_strTemp & vbTab
                                    End If
                                End If
                            Next

                            'Write data to the file
                            v_streamWriter.WriteLine(v_strData)
                        Next
                    Else
                        MsgBox(mv_ResourceManager.GetString("frmSearch.NothingToExport"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                        Exit Function
                    End If

                    'Close StreamWriter
                    v_streamWriter.Close()
                Else
                    'Ghi file excel
                    Dim v_Ew As New ExcelLib
                    v_Ew.ExportData(v_strFileName, SearchGrid, v_filetype)
                End If
                MsgBox(mv_ResourceManager.GetString("frmSearch.ExportSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            End If

            Exit Function

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            'MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function
#End Region

#Region " Other methods "
    Public Overridable Function InitDialog()
        'Khởi tạo kích thước form và load resource

        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        mv_ResourceManagerGrid = New Resources.ResourceManager(c_ResourceManagerGrid & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        LoadResource(Me)
        LoadInterface()

        tbnApprove.Text = mv_ResourceManager.GetString("tbnApprove")
        tbnCashier.Text = mv_ResourceManager.GetString("tbnCashier")
        tbnDelete.Text = mv_ResourceManager.GetString("tbnDelete")
        tbnReject.Text = mv_ResourceManager.GetString("tbnReject")
        tbnView.Text = mv_ResourceManager.GetString("tbnView")
        btnRefuse.Text = mv_ResourceManager.GetString("btnRefuse")

        'Thiết lập các thuộc tính ban đầu cho form
        DoResizeForm()

        SearchGrid.Dock = Windows.Forms.DockStyle.Fill
        Me.pnlSearchResult.Controls.Add(SearchGrid)
        SearchGrid.Dock = Windows.Forms.DockStyle.Fill
        'Set event double click for Grid
        AddHandler SearchGrid.DoubleClick, AddressOf Grid_DblClick
        'If Me.SearchGrid.DataRowTemplate.Cells.Count >= 0 Then
        '    For i As Integer = 0 To Me.SearchGrid.DataRowTemplate.Cells.Count - 1
        '        AddHandler SearchGrid.DataRowTemplate.Cells(i).DoubleClick, AddressOf Grid_DblClick
        '        AddHandler SearchGrid.DataRowTemplate.Cells(i).Click, AddressOf Grid_Click
        '    Next
        'End If
        AddHandler SearchGrid.KeyUp, AddressOf Grid_KeyUp
        'AddHandler SearchGrid.SelectedRowsChanged, AddressOf Grid_SelectedRowsChanged

        'If Not SearchGrid.Columns("__TICK") Is Nothing Then
        '    SearchGrid.Columns("__TICK").Visible = True
        '    SearchGrid.ContextMenu = Me.mnuGrid
        'End If

        'Set click event for buttons
        AddHandler btnHistory.Click, AddressOf Button_Click
        AddHandler btnSearch.Click, AddressOf Button_Click
        AddHandler btnExport.Click, AddressOf Button_Click
        AddHandler btnAdd.Click, AddressOf Button_Click
        AddHandler btnRemove.Click, AddressOf Button_Click
        AddHandler btnRemoveAll.Click, AddressOf Button_Click

        'Set selected index changed event for ComboBoxes
        AddHandler cboField.SelectedIndexChanged, AddressOf Combo_SelectedIndexChanged
        AddHandler cboOperator.SelectedIndexChanged, AddressOf Combo_SelectedIndexChanged

        'Thiết lập các giá trị ban đầu cho các đi?u ki�ện tìm kiếm
        Dim v_strCmdInquiry As String = "SELECT * FROM V_SEARCHCD WHERE 0=0 "
        Dim v_strClause As String = " UPPER(SEARCHCODE) = '" & mv_strTableName & "' ORDER BY POSITION"
        Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_SEARCHFLD, gc_ActionInquiry, v_strCmdInquiry, v_strClause, )

        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        v_ws.Message(v_strObjMsg)
        PrepareSearchParams(mv_arrStSummaryCode, UserLanguage, v_strObjMsg, mv_strCaption, mv_strEnCaption, mv_strCmdSql, mv_strObjName, mv_strFormName, _
            mv_arrSrFieldSrch, mv_arrSrFieldDisp, mv_arrSrFieldType, mv_arrSrFieldMask, mv_arrStFieldDefValue, _
            mv_arrSrFieldOperator, mv_arrSrFieldFormat, mv_arrSrFieldDisplay, mv_arrSrFieldWidth, _
            mv_arrSrSQLRef, mv_arrStFieldMultiLang, mv_arrStFieldMandartory, mv_arrStFieldRefCDType, mv_arrStFieldRefCDName, _
            mv_strKeyColumn, mv_strKeyFieldType, mv_intSearchNum, mv_strRefColumn, mv_strRefFieldType)

        cboField.Clears()
        For i As Integer = 1 To mv_intSearchNum
            cboField.AddItems(mv_arrSrFieldDisp(i), mv_arrSrFieldSrch(i))
        Next
        '8. Update form caption
        If UserLanguage <> "EN" Then
            FormCaption = mv_strCaption
        Else
            FormCaption = mv_strEnCaption
        End If
        Me.Text = FormCaption

        SearchGrid.DataSource = InitGridSearchFields(mv_strTableName, mv_arrSrFieldSrch, mv_arrSrFieldDisp, mv_arrSrFieldType)
        'Formatgid
        XtraGridFormatSummary(Me.gvResult, "", mv_arrSrFieldSrch, mv_arrSrFieldFormat, mv_arrSrFieldWidth, mv_arrSrFieldDisp, mv_arrSrFieldDisplay, mv_arrStSummaryCode)

        If SearchOnInit Then
            gvSearchSelection.ClearSelection()
            OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName)
        End If
    End Function

    Public Sub PrepareSearchParams(ByRef pv_arrSrSummaryCode() As String, ByVal pv_strUserLanguage As String, ByVal pv_strObjMsg As String, ByRef pv_strSrTitle As String, ByRef pv_strSrEnTitle As String, _
                                   ByRef pv_strSrCmd As String, ByRef pv_strSrObjName As String, _
                                   ByRef pv_strFrmName As String, ByRef pv_arrSrFieldCode() As String, _
                                   ByRef pv_arrSrFieldName() As String, ByRef pv_arrSrFieldType() As String, _
                                   ByRef pv_arrSrFieldMask() As String, ByRef pv_arrSrFieldDefValue() As String, ByRef pv_arrSrFieldOperator() As String, _
                                   ByRef pv_arrSrFieldFormat() As String, ByRef pv_arrSrFieldDisplay() As String, _
                                   ByRef pv_arrSrFieldWidth() As Integer, ByRef pv_arrSrLookupSql() As String, ByRef pv_arrSrFieldMultiLang() As String, _
                                   ByRef pv_arrSrFieldMandatory() As String, ByRef pv_arrSrRefCDType() As String, ByRef pv_arrSrRefCDName() As String, _
                                   ByRef pv_strKeyColumn As String, ByRef pv_strKeyFieldType As String, ByRef pv_intSearchNum As Integer, _
                                   ByRef pv_strRefColumn As String, ByRef pv_strRefFieldType As String, Optional ByRef pv_strSrOderByCmd As String = "", _
                                   Optional ByRef pv_strTLTXCD As String = "", Optional ByRef pv_strISSMS As String = "N", _
                                   Optional ByRef pv_strISEMAIL As String = "N", Optional ByRef pv_intRowPerPage As Integer = 0, Optional ByRef pv_strAUTHCODE As String = "", _
                                   Optional ByRef pv_strROWLIMIT As String = "Y", Optional ByRef pv_strCMDTYPE As String = "T", Optional ByRef pv_strCondDefFld As String = "", _
                                   Optional ByRef pv_strBANKINQ As String = "N", Optional ByRef pv_strBANKACCT As String = "")

        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strFLDNAME, v_strValue As String
        Dim v_strKeyValue, v_strSrch, v_strRefValue As String
        Dim v_strOderbycmdsql, v_strSrTitle, v_strSrEnTitle, v_strSrCmd, v_strSrObjName, v_strFrmName, v_strSrFieldCode, v_strSrFieldMultiLang, _
            v_strSrFieldName, v_strSrEnFieldName, v_strSrFieldType, v_strSrFieldMask, v_strSrFieldDefValue, v_strSrFieldOperator, v_strSrFieldFormat As String
        Dim v_strSrFieldDisplay, v_strSrLookupSql, v_strSrRefACDType, v_strSrRefACDName, v_strSrSummaryCode As String
        Dim v_intSrFieldWidth, v_intFieldCount As Integer

        Try
            pv_intSearchNum = 0

            v_xmlDocument.LoadXml(pv_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            v_intFieldCount = v_nodeList.Count
            ReDim pv_arrSrFieldCode(v_intFieldCount)
            ReDim pv_arrSrFieldName(v_intFieldCount)
            ReDim pv_arrSrFieldType(v_intFieldCount)
            ReDim pv_arrSrFieldMask(v_intFieldCount)
            ReDim pv_arrSrFieldDefValue(v_intFieldCount)
            ReDim pv_arrSrFieldOperator(v_intFieldCount)
            ReDim pv_arrSrFieldFormat(v_intFieldCount)
            ReDim pv_arrSrFieldDisplay(v_intFieldCount)
            ReDim pv_arrSrFieldWidth(v_intFieldCount)
            ReDim pv_arrSrLookupSql(v_intFieldCount)
            ReDim pv_arrSrFieldMultiLang(v_intFieldCount)
            ReDim pv_arrSrFieldMandatory(v_intFieldCount)
            ReDim pv_arrSrRefCDType(v_intFieldCount)
            ReDim pv_arrSrRefCDName(v_intFieldCount)
            ReDim pv_arrSrSummaryCode(v_intFieldCount)

            For i As Integer = 0 To v_intFieldCount - 1
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strValue = .InnerText.ToString

                        Select Case Trim(v_strFLDNAME)
                            Case "ROWPERPAGE"
                                If IsNumeric(v_strValue) Then
                                    pv_intRowPerPage = CInt(v_strValue)
                                Else
                                    pv_intRowPerPage = 0
                                End If
                            Case "SRCH"
                                v_strSrch = Trim(v_strValue)
                            Case "AUTHCODE"
                                pv_strAUTHCODE = Trim(v_strValue)
                            Case "ROWLIMIT"
                                pv_strROWLIMIT = Trim(v_strValue)
                            Case "CMDTYPE"
                                pv_strCMDTYPE = Trim(v_strValue)
                            Case "SEARCHTITLE"
                                v_strSrTitle = Trim(v_strValue)
                            Case "EN_SEARCHTITLE"
                                v_strSrEnTitle = Trim(v_strValue)
                            Case "SEARCHCMDSQL"
                                v_strSrCmd = Trim(v_strValue)
                            Case "OBJNAME"
                                v_strSrObjName = Trim(v_strValue)
                            Case "FRMNAME"
                                v_strFrmName = Trim(v_strValue)
                            Case "FIELDCODE"
                                v_strSrFieldCode = Trim(v_strValue)
                            Case "FIELDNAME"
                                v_strSrFieldName = Trim(v_strValue)
                            Case "EN_FIELDNAME"
                                v_strSrEnFieldName = Trim(v_strValue)
                            Case "FIELDTYPE"
                                v_strSrFieldType = Trim(v_strValue)
                            Case "MASK"
                                v_strSrFieldMask = Trim(v_strValue)
                            Case "DEFVALUE"
                                v_strSrFieldDefValue = Trim(v_strValue)
                            Case "ORDERBYCMDSQL"
                                v_strOderbycmdsql = Trim(v_strValue)
                            Case "OPERATOR"
                                v_strSrFieldOperator = Trim(v_strValue)
                            Case "FORMAT"
                                v_strSrFieldFormat = Trim(v_strValue)
                            Case "DISPLAY"
                                v_strSrFieldDisplay = Trim(v_strValue)
                            Case "KEY"
                                v_strKeyValue = Trim(v_strValue)
                                If v_strKeyValue = "Y" Then
                                    pv_strKeyColumn = v_strSrFieldCode
                                    pv_strKeyFieldType = v_strSrFieldType
                                End If
                            Case "REFVALUE"
                                v_strRefValue = Trim(v_strValue)

                                If v_strRefValue = "Y" Then
                                    pv_strRefColumn = v_strSrFieldCode
                                    pv_strRefFieldType = v_strSrFieldType
                                End If
                            Case "WIDTH"
                                v_intSrFieldWidth = CInt(Trim(v_strValue))
                            Case "TLTXCD"
                                pv_strTLTXCD = Trim(v_strValue)
                            Case "LOOKUPCMDSQL"
                                v_strSrLookupSql = Trim(v_strValue)
                            Case "ISSMS"
                                pv_strISSMS = Trim(v_strValue)
                            Case "ISEMAIL"
                                pv_strISEMAIL = Trim(v_strValue)
                            Case "MULTILANG"
                                v_strSrFieldMultiLang = Trim(v_strValue)
                            Case "ACDTYPE"
                                v_strSrRefACDType = Trim(v_strValue)
                            Case "ACDNAME"
                                v_strSrRefACDName = Trim(v_strValue)
                            Case "CONDDEFFLD"
                                pv_strCondDefFld = Trim(v_strValue)
                            Case "BANKINQ"
                                pv_strBANKINQ = Trim(v_strValue)
                            Case "BANKACCT"
                                pv_strBANKACCT = Trim(v_strValue)
                            Case "SUMMARYCD"
                                v_strSrSummaryCode = Trim(v_strValue)
                        End Select
                    End With
                Next

                If v_strSrch = "Y" Or v_strSrch = "M" Then  'M là bắt buộc phải nhập giá trị tìm kiếm
                    pv_intSearchNum += 1

                    If pv_intSearchNum = 1 Then
                        pv_strSrTitle = v_strSrTitle
                        pv_strSrEnTitle = v_strSrEnTitle
                        pv_strSrCmd = v_strSrCmd
                        pv_strSrOderByCmd = v_strOderbycmdsql
                        pv_strSrObjName = v_strSrObjName
                        pv_strFrmName = v_strFrmName
                    End If
                    pv_arrSrFieldCode(pv_intSearchNum) = v_strSrFieldCode
                    pv_arrSrFieldName(pv_intSearchNum) = IIf(pv_strUserLanguage = gc_LANG_VIETNAMESE, v_strSrFieldName, v_strSrEnFieldName)
                    pv_arrSrFieldType(pv_intSearchNum) = v_strSrFieldType
                    pv_arrSrFieldMask(pv_intSearchNum) = v_strSrFieldMask
                    pv_arrSrFieldDefValue(pv_intSearchNum) = v_strSrFieldDefValue
                    pv_arrSrFieldOperator(pv_intSearchNum) = v_strSrFieldOperator
                    pv_arrSrFieldFormat(pv_intSearchNum) = v_strSrFieldFormat
                    pv_arrSrFieldDisplay(pv_intSearchNum) = v_strSrFieldDisplay
                    pv_arrSrFieldWidth(pv_intSearchNum) = v_intSrFieldWidth
                    pv_arrSrLookupSql(pv_intSearchNum) = v_strSrLookupSql
                    pv_arrSrFieldMandatory(pv_intSearchNum) = v_strSrch
                    'pv_arrSrFieldName(pv_intSearchNum) = v_strSrFieldName
                    pv_arrSrRefCDType(v_intFieldCount) = v_strSrRefACDType
                    pv_arrSrRefCDName(v_intFieldCount) = v_strSrRefACDName
                    pv_arrSrSummaryCode(pv_intSearchNum) = v_strSrSummaryCode
                End If
            Next

            If pv_intSearchNum > 0 Then
                ReDim Preserve pv_arrSrFieldCode(pv_intSearchNum)
                ReDim Preserve pv_arrSrFieldName(pv_intSearchNum)
                ReDim Preserve pv_arrSrFieldType(pv_intSearchNum)
                ReDim Preserve pv_arrSrFieldMask(pv_intSearchNum)
                ReDim Preserve pv_arrSrFieldDefValue(pv_intSearchNum)
                ReDim Preserve pv_arrSrFieldOperator(pv_intSearchNum)
                ReDim Preserve pv_arrSrFieldFormat(pv_intSearchNum)
                ReDim Preserve pv_arrSrFieldDisplay(pv_intSearchNum)
                ReDim Preserve pv_arrSrFieldWidth(pv_intSearchNum)
                ReDim Preserve pv_arrSrLookupSql(pv_intSearchNum)
                ReDim Preserve pv_arrSrFieldMultiLang(pv_intSearchNum)
                ReDim Preserve pv_arrSrFieldMandatory(pv_intSearchNum)
                ReDim Preserve pv_arrSrRefCDType(v_intFieldCount)
                ReDim Preserve pv_arrSrRefCDName(v_intFieldCount)

            End If
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            Throw ex
        End Try
    End Sub

    Private Sub DoResizeForm()
        grbSearchFilter.Width = Me.Width - 18
        btnSearch.Left = grbSearchFilter.Width - btnSearch.Width - 9
        btnExport.Left = btnSearch.Left
        btnHistory.Left = btnSearch.Left
        grbConditionList.Width = grbSearchFilter.Width - btnSearch.Width - grbConditionList.Left - 18
        lstCondition.Width = grbConditionList.Width - 16

        grbSearchResult.Width = grbSearchFilter.Width
        pnlSearchResult.Width = grbSearchResult.Width - 16
        grbSearchResult.Height = Me.Height - grbSearchResult.Top
        pnlSearchResult.Height = grbSearchResult.Height - 32

    End Sub

    Private Sub LoadResource(ByRef pv_ctrl As Windows.Forms.Control)
        Dim v_ctrl As Windows.Forms.Control

        For Each v_ctrl In pv_ctrl.Controls
            If TypeOf (v_ctrl) Is Label Then
                CType(v_ctrl, Label).Text = mv_ResourceManager.GetString("ucSearch." & v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is GroupBox Then
                CType(v_ctrl, GroupBox).Text = mv_ResourceManager.GetString("ucSearch." & v_ctrl.Name)
                LoadResource(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is Button Then
                CType(v_ctrl, Button).Text = mv_ResourceManager.GetString("ucSearch." & v_ctrl.Name)
            End If
        Next
    End Sub

    Public Overridable Sub LoadInterface()
        Try
            Dim v_strTeller, v_strCashier, v_strOfficer, v_strChecker As String
            v_strTeller = Mid(TellerType, 1, 1)
            v_strCashier = Mid(TellerType, 2, 1)
            v_strOfficer = Mid(TellerType, 3, 1)
            v_strChecker = Mid(TellerType, 4, 1)

            'Display toolbar button
            tbnApprove.Enabled = ((v_strOfficer = "Y") Or (v_strChecker = "Y"))
            tbnCashier.Enabled = (v_strCashier = "Y")
            tbnReject.Enabled = ((v_strOfficer = "Y") Or (v_strChecker = "Y"))
            tbnDelete.Enabled = (v_strTeller = "Y")
            btnRefuse.Enabled = ((v_strOfficer = "Y") Or (v_strChecker = "Y"))

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub NewTxtValue(ByVal pv_strSqlRef As String)
        txtValue.Dispose()

        If pv_strSqlRef.Trim.Length < 1 Then
            If Trim$(mv_arrSrFieldType(cboField.SelectedIndex + 1)) = "D" Then
                Me.txtValue = New DateTimePicker
                CType(Me.txtValue, DateTimePicker).Format = DateTimePickerFormat.Custom
                CType(Me.txtValue, DateTimePicker).CustomFormat = gc_FORMAT_DATE
            Else
                Me.txtValue = New System.Windows.Forms.TextBox
            End If
        Else
            Me.txtValue = New ComboBoxEx
        End If
        Me.grbCondition.Controls.Add(Me.txtValue)
        '
        'txtValue
        '
        Me.txtValue.Enabled = True
        Me.txtValue.Name = "txtValue"
        Me.txtValue.Width = cboOperator.Width
        Me.txtValue.Height = cboOperator.Height
        Me.txtValue.Left = cboOperator.Left
        Me.txtValue.Top = cboOperator.Top + cboOperator.Height + (cboOperator.Top - cboField.Top - cboField.Height)
        Me.txtValue.TabIndex = cboOperator.TabIndex + 1
        Me.txtValue.Text = String.Empty
        Me.txtValue.Visible = True

        'Load CSDL
        If pv_strSqlRef.Trim.Length > 0 Then
            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_SEARCHFLD, gc_ActionInquiry, pv_strSqlRef)
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            v_ws.Message(v_strObjMsg)
            FillComboEx(v_strObjMsg, txtValue, "", Me.UserLanguage)
        End If
    End Sub


#End Region

#Region " Các sự kiện của form "

    Private Sub tmrSearch_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrSearch.Tick
        OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName)
    End Sub

    Private Sub frmSearch_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        DoResizeForm()
    End Sub

    Private Sub txtValue_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtValue.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    AddSearchCriteria()
            End Select
        Catch ex As Exception
            LogError.Write("Error source: AppCore.frmSearch.txtValue_KeyDown" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v_strValue, v_strValueDisplay As String
        Dim v_objResult As Object
        Dim v_strFilterTmp As String
        Dim v_strSearchKey As String
        Dim v_blnSearchKeyAdded As Boolean

        Try
            If (sender Is btnSearch) Then
                OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName)
            ElseIf (sender Is btnHistory) Then
                OnHistory(, ModuleCode & "." & ObjectName)
            ElseIf (sender Is btnExport) Then
                OnExport()
            ElseIf (sender Is btnAdd) Then
                AddSearchCriteria()
            ElseIf (sender Is btnRemove) Then
                RemoveSearchCriteria()
            ElseIf (sender Is btnRemoveAll) Then
                RemoveAllSearchCriterias()
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            Throw ex
        End Try
    End Sub

    Private Sub Combo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If (sender Is cboField) Then
            'Load các toán tử đi?u ki�ện
            AnalyzeOperator(mv_arrSrFieldOperator(cboField.SelectedIndex + 1), mv_arrSrOperator)
            cboOperator.Clears()
            For i As Integer = 1 To mv_arrSrOperator.Length
                cboOperator.AddItems(mv_arrSrOperator(i - 1), mv_arrSrOperator(i - 1))
            Next

            NewTxtValue(mv_arrSrSQLRef(cboField.SelectedIndex + 1))
        ElseIf (sender Is cboOperator) Then

        End If
    End Sub

    Private Sub tbnView_Click(ByVal sender As System.Object, ByVal e As Xceed.SmartUI.SmartItemClickEventArgs) Handles tbnView.Click
        'If SearchGrid.SelectedRows.Count > 0 Then
        '    OnView()
        'Else
        '    MsgBox(mv_ResourceManager.GetString("ucSearch.NotSelected"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        'End If
        'tiennv
        OnView()
    End Sub

    Private Sub tbnCashier_Click(ByVal sender As Object, ByVal e As Xceed.SmartUI.SmartItemClickEventArgs) Handles tbnCashier.Click
        'If SearchGrid.SelectedRows.Count > 0 Then
        '    OnCashier()
        'Else
        '    MsgBox(mv_ResourceManager.GetString("ucSearch.NotSelected"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        'End If
        'OnCashier()
    End Sub

    Private Sub tbnApprove_Click(ByVal sender As System.Object, ByVal e As Xceed.SmartUI.SmartItemClickEventArgs) Handles tbnApprove.Click
        'If SearchGrid.SelectedRows.Count > 0 Then
        '    OnApprove()
        'Else
        '    MsgBox(mv_ResourceManager.GetString("ucSearch.NotSelected"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        'End If

        OnApprove()
    End Sub

    Private Sub tbnReject_Click(ByVal sender As System.Object, ByVal e As Xceed.SmartUI.SmartItemClickEventArgs) Handles tbnReject.Click
        'If SearchGrid.SelectedRows.Count > 0 Then
        '    OnReject()
        'Else
        '    MsgBox(mv_ResourceManager.GetString("ucSearch.NotSelected"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        'End If

        OnReject()
    End Sub

    Private Sub tbnDelete_Click(ByVal sender As System.Object, ByVal e As Xceed.SmartUI.SmartItemClickEventArgs) Handles tbnDelete.Click
        'If SearchGrid.SelectedRows.Count > 0 Then
        '    OnDelete()
        'Else
        '    MsgBox(mv_ResourceManager.GetString("ucSearch.NotSelected"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        'End If
        OnDelete()
    End Sub

    Private Sub btnRefuse_Click(ByVal sender As System.Object, ByVal e As Xceed.SmartUI.SmartItemClickEventArgs) Handles btnRefuse.Click
        'If SearchGrid.SelectedRows.Count > 0 Then
        '    OnRefuse()
        'Else
        '    MsgBox(mv_ResourceManager.GetString("ucSearch.NotSelected"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        'End If
        OnRefuse()
    End Sub

    Private Sub usSeach_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        'Select Case e.KeyCode
        '    Case Keys.C
        '        If Keys.Control Then
        '            If Not (SearchGrid.CurrentRow Is Nothing) Then
        '                If Not (SearchGrid.CurrentRow Is SearchGrid.FixedFooterRows.Item(0)) Then
        '                    Clipboard.SetDataObject(CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("ACCTNO").Value)
        '                End If
        '            End If
        '        End If
        '    Case Keys.F6
        '        If Not (SearchGrid Is Nothing) Then
        '            If SearchGrid.Enabled And SearchGrid.Visible Then
        '                SearchGrid.Focus()
        '            End If
        '        End If
        'End Select
    End Sub
    Private Sub Grid_DblClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            OnView()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Grid_SelectedRowsChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            'Trim(CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("TLTXCD").Value)
            If Trim(CType(CType(sender, GridEx).CurrentRow, Xceed.Grid.DataRow).Cells("TXSTATUSCD").Value) = TransactStatus.Cashier Then
                tbnCashier.Enabled = True
            Else
                tbnCashier.Enabled = False
            End If
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Grid_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            Select Case e.KeyCode
                Case Keys.Space
                    'If Not SearchGrid.Columns("__TICK") Is Nothing Then

                    '    If CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("__TICK").Visible Then
                    '        If CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("__TICK").Value = "X" Then
                    '            CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("__TICK").Value = String.Empty
                    '        Else
                    '            CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("__TICK").Value = "X"
                    '        End If
                    '    End If
                    'End If
                    gvSearchSelection.SelectRow(gvResult.GetFocusedDataSourceRowIndex, Not gvSearchSelection.IsRowSelected(gvResult.GetFocusedDataSourceRowIndex))
                Case Keys.Control.A
                    gvSearchSelection.SelectAll()
                    'If Not SearchGrid.Columns("__TICK") Is Nothing Then
                    '    For i As Integer = 0 To SearchGrid.DataRows.Count - 1
                    '        If SearchGrid.DataRows(i).Cells("__TICK").Visible Then
                    '            If SearchGrid.DataRows(i).Cells("__TICK").Value = "X" Then
                    '                SearchGrid.DataRows(i).Cells("__TICK").Value = String.Empty
                    '            Else
                    '                SearchGrid.DataRows(i).Cells("__TICK").Value = "X"
                    '            End If
                    '        End If
                    '    Next
                    'End If
                Case Keys.Alt.D
                    OnDelete(True)
                Case Keys.Alt.V
                    OnView()
                Case Keys.Alt.A
                    OnApprove(True)
                Case Keys.Alt.R
                    OnReject(True)
                Case Keys.Alt.C
                    'OnCashier(True)
                Case Keys.Alt.Home
                    OnApproveALL()
                Case Keys.Alt.End
                    OnCashierALL()
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub



    Private Function CountRow() As Int32
        Try
            mv_strSearchFilter = String.Empty
            For i As Integer = 0 To lstCondition.Items.Count - 1
                If lstCondition.GetItemChecked(i) Then
                    mv_strSearchFilter &= " AND " & hFilter(lstCondition.Items(i).ToString())
                End If
            Next i
            mv_strSearchFilter = Mid(mv_strSearchFilter, 5)
            If mv_strSearchFilter = "" Then
                mv_strSearchFilter = " 0 = 0 "
            End If
            'If (mv_strSrOderByCmd <> "") And (mv_strSearchFilter <> "") Then
            '    mv_strSearchFilter &= "ORDER BY " & mv_strSrOderByCmd
            'End If

            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_int, v_intCount As Integer
            Dim v_intCOUNTROW As Int32
            Dim v_strFLDNAME, v_strVALUE As String
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery

            Dim v_strCmdInquiry As String = "select COUNT(*) COUNTROW from " & mv_strObjName & " Where 0=0"
            'Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId , gc_IsNotLocalMsg, gc_MsgTypeObj, "SA.ALLCODE", gc_ActionInquiry, v_strCmdInquiry)
            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, IsLocalSearch, gc_MsgTypeObj, ModuleCode & "." & ObjectName, _
                                          gc_ActionInquiry, v_strCmdInquiry, mv_strSearchFilter)

            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For v_intCount = 0 To v_nodeList.Count - 1
                For v_int = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                    With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                        v_strFLDNAME = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("fldname").Value.Trim()
                        v_strVALUE = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("oldval").Value.Trim()

                        Select Case v_strFLDNAME
                            Case "COUNTROW"
                                v_intCOUNTROW = v_strVALUE
                        End Select
                    End With
                Next
            Next
            Return v_intCOUNTROW
        Catch ex As Exception
            Throw ex

        End Try
    End Function

    'Private Sub AddSearchCriteria()
    '    Try
    '        Dim v_strValue, v_strValueDisplay As String
    '        Dim v_objResult As Object
    '        Dim v_strFilterTmp As String
    '        Dim v_strSearchKey As String
    '        Dim v_blnSearchKeyAdded As Boolean

    '        v_strValueDisplay = Trim(txtValue.Text)
    '        If mv_arrSrSQLRef(cboField.SelectedIndex + 1).Trim.Length > 0 Then
    '            v_strValue = v_strValueDisplay
    '        Else
    '            v_strValue = Trim(txtValue.Text)
    '        End If

    '        If v_strValue <> String.Empty Then
    '            v_objResult = hFilter(mv_arrSrFieldDisp(cboField.SelectedIndex + 1) & " " _
    '                & IIf(Trim(cboOperator.SelectedValue) = "LIKE", "%", "") & " " _
    '                & IIf(mv_arrSrFieldType(cboField.SelectedIndex + 1) <> "N", "'", "") _
    '                & v_strValueDisplay & IIf(Trim(mv_arrSrFieldType(cboField.SelectedIndex + 1)) <> "N", "'", ""))

    '            If (v_objResult Is Nothing) Then
    '                v_blnSearchKeyAdded = False
    '                v_strSearchKey = mv_arrSrFieldDisp(cboField.SelectedIndex + 1) & " " _
    '                    & cboOperator.SelectedValue & " " & IIf(mv_arrSrFieldType(cboField.SelectedIndex + 1) <> "N", "'", "") _
    '                    & v_strValueDisplay & IIf(mv_arrSrFieldType(cboField.SelectedIndex + 1) <> "N", "'", "")

    '                For i As Integer = 0 To lstCondition.Items.Count - 1
    '                    If lstCondition.Items(i).ToString() = v_strSearchKey Then
    '                        v_blnSearchKeyAdded = True
    '                        Exit For
    '                    End If
    '                Next

    '                If Not v_blnSearchKeyAdded Then

    '                    v_strFilterTmp = IIf(mv_arrSrSQLRef(cboField.SelectedIndex + 1).Trim.Length = 0, _
    '                        mv_arrSrFieldSrch(cboField.SelectedIndex + 1), _
    '                        mv_arrSrFieldSrch(cboField.SelectedIndex + 1))
    '                    v_strFilterTmp &= " " & cboOperator.SelectedValue & " "
    '                    Select Case mv_arrSrFieldType(cboField.SelectedIndex + 1)
    '                        Case "D"
    '                            v_strFilterTmp &= "TO_DATE('" & v_strValue & "', '" & gc_FORMAT_DATE & "')"
    '                        Case "N"
    '                            If IsNumeric(v_strValue) Then
    '                                v_strFilterTmp &= CDbl(v_strValue)
    '                            Else
    '                                Exit Sub
    '                            End If
    '                        Case "C"
    '                            v_strFilterTmp &= "'" _
    '                                & IIf(Trim(cboOperator.SelectedValue) = "LIKE", "%", "") & v_strValue _
    '                                & IIf(Trim(cboOperator.SelectedValue) = "LIKE", "%", "") & "'"
    '                    End Select
    '                    lstCondition.Items.Add(v_strSearchKey, True)
    '                    hFilter.Add(v_strSearchKey, v_strFilterTmp)
    '                End If
    '            End If
    '        End If
    '    Catch ex As Exception
    '        LogError.Write("Error source: AppCore.frmSearch.AddSearchCriteria" & vbNewLine _
    '                     & "Error code: System error!" & vbNewLine _
    '                     & "Error message: " & ex.Message, EventLogEntryType.Error)
    '        MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
    '    End Try
    'End Sub
    Private Sub AddSearchCriteria()
        Try
            Dim v_strValue, v_strValueDisplay As String
            Dim v_objResult As Object
            Dim v_strFilterTmp As String
            Dim v_strFilterTmpUpper As String
            Dim v_strSearchKey As String
            Dim v_blnSearchKeyAdded As Boolean
            Dim i1 As Int16
            v_strValueDisplay = Trim(txtValue.Text)
            If mv_arrSrSQLRef(cboField.SelectedIndex + 1).Trim.Length > 0 Then
                v_strValue = v_strValueDisplay
            Else
                v_strValue = Trim(txtValue.Text.ToString)

            End If
            If InStr(v_strValue, "'") > 0 Or InStr(v_strValue, "^") Or InStr(v_strValue, "!") Then
                MessageBox.Show(mv_ResourceManager.GetString("ERR_SPECIAL_CHARACTER"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If v_strValue <> String.Empty Then
                v_objResult = hFilter(mv_arrSrFieldDisp(cboField.SelectedIndex + 1) & " " _
                    & IIf(Trim(cboOperator.SelectedValue) = "LIKE", "%", "") & " " _
                    & IIf(mv_arrSrFieldType(cboField.SelectedIndex + 1) <> "N", "'", "") _
                    & v_strValueDisplay & IIf(Trim(mv_arrSrFieldType(cboField.SelectedIndex + 1)) <> "N", "'", ""))

                If (v_objResult Is Nothing) Then
                    v_blnSearchKeyAdded = False
                    v_strSearchKey = mv_arrSrFieldDisp(cboField.SelectedIndex + 1) & " " _
                        & cboOperator.SelectedValue & " " & IIf(mv_arrSrFieldType(cboField.SelectedIndex + 1) <> "N", "'", "") _
                        & v_strValueDisplay & IIf(mv_arrSrFieldType(cboField.SelectedIndex + 1) <> "N", "'", "")

                    For i As Integer = 0 To lstCondition.Items.Count - 1
                        If lstCondition.Items(i).ToString() = v_strSearchKey Then
                            v_blnSearchKeyAdded = True
                            Exit For
                        End If
                    Next

                    If Not v_blnSearchKeyAdded Then
                        v_strFilterTmp = "TLLOG."
                        v_strFilterTmp &= IIf(mv_arrSrSQLRef(cboField.SelectedIndex + 1).Trim.Length = 0, _
                            mv_arrSrFieldSrch(cboField.SelectedIndex + 1), _
                            mv_arrSrFieldSrch(cboField.SelectedIndex + 1))
                        v_strFilterTmpUpper = "REPLACE (UPPER( Trim (" & v_strFilterTmp & ")),'.','')"
                        v_strFilterTmp &= " " & cboOperator.SelectedValue & " "
                        v_strFilterTmpUpper &= " " & cboOperator.SelectedValue & " "
                        Select Case mv_arrSrFieldType(cboField.SelectedIndex + 1)
                            Case "D"
                                v_strFilterTmp &= "TO_DATE('" & v_strValue & "', '" & gc_FORMAT_DATE & "')"
                            Case "N"

                                If IsNumeric(v_strValue) Then
                                    v_strFilterTmp &= CDbl(v_strValue)
                                Else
                                    Exit Sub
                                End If
                            Case "C"
                                v_strValue = Trim(Replace(v_strValue, ".", String.Empty))
                                If InStr(v_strValue, "%") > 0 Then
                                    v_strFilterTmpUpper &= "UPPER ('" _
                                                  & IIf(Trim(cboOperator.SelectedValue) = "LIKE", "", "") & v_strValue _
                                                  & IIf(Trim(cboOperator.SelectedValue) = "LIKE", "", "") & "')"

                                Else

                                    v_strFilterTmpUpper &= "UPPER ('" _
                                                & IIf(Trim(cboOperator.SelectedValue) = "LIKE", "%", "") & v_strValue _
                                                & IIf(Trim(cboOperator.SelectedValue) = "LIKE", "%", "") & "')"

                                End If
                                v_strFilterTmp = String.Empty
                                v_strFilterTmp = v_strFilterTmpUpper
                        End Select
                        lstCondition.Items.Add(v_strSearchKey, True)
                        hFilter.Add(v_strSearchKey, v_strFilterTmp)
                    End If
                End If
            End If
            Me.btnSearch.Select()
        Catch ex As Exception
            LogError.Write("Error source: AppCore.frmSearch.AddSearchCriteria" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub RemoveSearchCriteria()
        Try
            Dim v_objResult As Object

            If lstCondition.SelectedIndex <> -1 Then
                v_objResult = hFilter(lstCondition.Items(lstCondition.SelectedIndex).ToString())

                If Not (v_objResult Is Nothing) Then
                    hFilter.Remove(lstCondition.Items(lstCondition.SelectedIndex).ToString())
                    lstCondition.Items.RemoveAt(lstCondition.SelectedIndex)
                End If
            End If
        Catch ex As Exception
            LogError.Write("Error source: AppCore.frmSearch.AddSearchCriteria" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub RemoveAllSearchCriterias()
        Try
            Dim v_objResult As Object
            Dim v_strValueDisplay As String

            For i As Integer = 0 To lstCondition.Items.Count - 1
                v_objResult = hFilter(lstCondition.Items(i).ToString())

                If Not (v_objResult Is Nothing) Then
                    v_strValueDisplay = lstCondition.Items(i).ToString()
                    hFilter.Remove(v_strValueDisplay)
                End If
            Next
            lstCondition.Items.Clear()
        Catch ex As Exception
            LogError.Write("Error source: AppCore.frmSearch.AddSearchCriteria" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub
#End Region

    Private Sub mnuSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSelectAll.Click
        'Dim v_intRow As Integer
        'If Not SearchGrid Is Nothing Then
        '    If SearchGrid.DataRows.Count > 0 Then
        '        For v_intRow = 0 To SearchGrid.DataRows.Count - 1 Step 1
        '            If SearchGrid.DataRows(v_intRow).Cells("__TICK").Visible = True Then
        '                SearchGrid.DataRows(v_intRow).Cells("__TICK").Value = "X"
        '            End If
        '        Next
        '    End If
        'End If
    End Sub

    Private Sub mnuDeselectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDeselectAll.Click
        'Dim v_intRow As Integer
        'If Not SearchGrid Is Nothing Then
        '    If SearchGrid.DataRows.Count > 0 Then
        '        For v_intRow = 0 To SearchGrid.DataRows.Count - 1 Step 1
        '            SearchGrid.DataRows(v_intRow).Cells("__TICK").Value = String.Empty
        '        Next
        '    End If
        'End If

    End Sub

    Protected Overridable Sub Grid_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'If Not SearchGrid.CurrentColumn Is Nothing Then
        '    If SearchGrid.CurrentColumn.FieldName = "__TICK" Then
        '        If SearchGrid.CurrentCell.Visible Then
        '            If SearchGrid.CurrentCell.Value = "X" Then
        '                SearchGrid.CurrentCell.Value = String.Empty
        '            Else
        '                SearchGrid.CurrentCell.Value = "X"
        '            End If
        '        End If
        '    End If
        'End If
    End Sub

    Private Sub usSeach_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
