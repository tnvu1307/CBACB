Imports System.Windows.Forms
Imports Xceed.SmartUI.Controls
Imports CommonLibrary
Imports System.Collections
Imports System.IO
Imports AppCore

Public Class frmProductManagement
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal pv_strLanguage As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        mv_strLanguage = pv_strLanguage
    End Sub

    'Form overrides dispose to clean up the component list.
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

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents grbSearchFilter As System.Windows.Forms.GroupBox
    Friend WithEvents grbSearchResult As System.Windows.Forms.GroupBox
    Friend WithEvents btnRemoveAll As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents grbConditionList As System.Windows.Forms.GroupBox
    Friend WithEvents grbCondition As System.Windows.Forms.GroupBox
    Friend WithEvents txtValue As System.Windows.Forms.Control
    Friend WithEvents lblValue As System.Windows.Forms.Label
    Friend WithEvents cboOperator As ComboBoxEx
    Friend WithEvents lblOperator As System.Windows.Forms.Label
    Friend WithEvents cboField As ComboBoxEx
    Friend WithEvents lblField As System.Windows.Forms.Label
    Friend WithEvents lstCondition As System.Windows.Forms.CheckedListBox
    Friend WithEvents pnlSearchResult As System.Windows.Forms.Panel
    Friend WithEvents ssbInfo As Xceed.SmartUI.Controls.StatusBar.SmartStatusBar
    Friend WithEvents ssbPanelStatus As Xceed.SmartUI.Controls.StatusBar.SpringPanel
    Friend WithEvents ssbPanelExecFlag As Xceed.SmartUI.Controls.StatusBar.Panel
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents btnBACK As System.Windows.Forms.Button
    Friend WithEvents Tool1 As Xceed.SmartUI.Controls.ToolBar.Tool
    Friend WithEvents btnNEXT As System.Windows.Forms.Button
    Friend WithEvents chkALL As System.Windows.Forms.CheckBox
    Friend WithEvents imlSearch As System.Windows.Forms.ImageList
    Friend WithEvents SmartToolBar1 As Xceed.SmartUI.Controls.ToolBar.SmartToolBar
    Friend WithEvents tbnAdd As Xceed.SmartUI.Controls.ToolBar.Tool
    Friend WithEvents tbnView As Xceed.SmartUI.Controls.ToolBar.Tool
    Friend WithEvents tbnEdit As Xceed.SmartUI.Controls.ToolBar.Tool
    Friend WithEvents tbnDelete As Xceed.SmartUI.Controls.ToolBar.Tool
    Friend WithEvents tbnExecute As Xceed.SmartUI.Controls.ToolBar.Tool
    Friend WithEvents SeparatorTool1 As Xceed.SmartUI.Controls.ToolBar.SeparatorTool
    Friend WithEvents tbnExit As Xceed.SmartUI.Controls.ToolBar.Tool
    Friend WithEvents mnuGrid As System.Windows.Forms.ContextMenu
    Friend WithEvents mnuSelectAll As System.Windows.Forms.MenuItem
    Friend WithEvents mnuDeselectAll As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmProductManagement))
        Me.grbSearchFilter = New System.Windows.Forms.GroupBox
        Me.btnExport = New System.Windows.Forms.Button
        Me.btnRemoveAll = New System.Windows.Forms.Button
        Me.btnRemove = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.btnSearch = New System.Windows.Forms.Button
        Me.grbConditionList = New System.Windows.Forms.GroupBox
        Me.lstCondition = New System.Windows.Forms.CheckedListBox
        Me.grbCondition = New System.Windows.Forms.GroupBox
        Me.txtValue = New System.Windows.Forms.Control
        Me.lblValue = New System.Windows.Forms.Label
        Me.cboOperator = New AppCore.ComboBoxEx
        Me.lblOperator = New System.Windows.Forms.Label
        Me.cboField = New AppCore.ComboBoxEx
        Me.lblField = New System.Windows.Forms.Label
        Me.grbSearchResult = New System.Windows.Forms.GroupBox
        Me.pnlSearchResult = New System.Windows.Forms.Panel
        Me.ssbInfo = New Xceed.SmartUI.Controls.StatusBar.SmartStatusBar(Me.components)
        Me.ssbPanelStatus = New Xceed.SmartUI.Controls.StatusBar.SpringPanel("F6: Focus to grid, F7: Prev, F8: Next, F9: Choose")
        Me.ssbPanelExecFlag = New Xceed.SmartUI.Controls.StatusBar.Panel
        Me.btnBACK = New System.Windows.Forms.Button
        Me.Tool1 = New Xceed.SmartUI.Controls.ToolBar.Tool("tbnExit", 1)
        Me.btnNEXT = New System.Windows.Forms.Button
        Me.chkALL = New System.Windows.Forms.CheckBox
        Me.imlSearch = New System.Windows.Forms.ImageList(Me.components)
        Me.SmartToolBar1 = New Xceed.SmartUI.Controls.ToolBar.SmartToolBar(Me.components)
        Me.tbnAdd = New Xceed.SmartUI.Controls.ToolBar.Tool("tbnAdd", 4)
        Me.tbnView = New Xceed.SmartUI.Controls.ToolBar.Tool("tbnView", 0)
        Me.tbnEdit = New Xceed.SmartUI.Controls.ToolBar.Tool("tbnEdit", 2)
        Me.tbnDelete = New Xceed.SmartUI.Controls.ToolBar.Tool("tbnDelete", 3)
        Me.tbnExecute = New Xceed.SmartUI.Controls.ToolBar.Tool("Execute", 6)
        Me.SeparatorTool1 = New Xceed.SmartUI.Controls.ToolBar.SeparatorTool
        Me.tbnExit = New Xceed.SmartUI.Controls.ToolBar.Tool("tbnExit", 1)
        Me.mnuGrid = New System.Windows.Forms.ContextMenu
        Me.mnuSelectAll = New System.Windows.Forms.MenuItem
        Me.mnuDeselectAll = New System.Windows.Forms.MenuItem
        Me.grbSearchFilter.SuspendLayout()
        Me.grbConditionList.SuspendLayout()
        Me.grbCondition.SuspendLayout()
        Me.grbSearchResult.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbSearchFilter
        '
        Me.grbSearchFilter.Controls.Add(Me.btnExport)
        Me.grbSearchFilter.Controls.Add(Me.btnRemoveAll)
        Me.grbSearchFilter.Controls.Add(Me.btnRemove)
        Me.grbSearchFilter.Controls.Add(Me.btnAdd)
        Me.grbSearchFilter.Controls.Add(Me.btnSearch)
        Me.grbSearchFilter.Controls.Add(Me.grbConditionList)
        Me.grbSearchFilter.Controls.Add(Me.grbCondition)
        Me.grbSearchFilter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbSearchFilter.Location = New System.Drawing.Point(5, 49)
        Me.grbSearchFilter.Name = "grbSearchFilter"
        Me.grbSearchFilter.Size = New System.Drawing.Size(851, 151)
        Me.grbSearchFilter.TabIndex = 1
        Me.grbSearchFilter.TabStop = False
        Me.grbSearchFilter.Text = "grbSearchFilter"
        '
        'btnExport
        '
        Me.btnExport.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExport.Location = New System.Drawing.Point(768, 54)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.TabIndex = 8
        Me.btnExport.Text = "btnExport"
        '
        'btnRemoveAll
        '
        Me.btnRemoveAll.Font = New System.Drawing.Font("Webdings", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.btnRemoveAll.Location = New System.Drawing.Point(368, 96)
        Me.btnRemoveAll.Name = "btnRemoveAll"
        Me.btnRemoveAll.Size = New System.Drawing.Size(32, 24)
        Me.btnRemoveAll.TabIndex = 7
        Me.btnRemoveAll.Text = "7"
        '
        'btnRemove
        '
        Me.btnRemove.Font = New System.Drawing.Font("Webdings", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.btnRemove.Location = New System.Drawing.Point(368, 68)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(32, 24)
        Me.btnRemove.TabIndex = 6
        Me.btnRemove.Text = "3"
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Webdings", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(368, 40)
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
        Me.btnSearch.TabIndex = 2
        Me.btnSearch.Text = "btnSearch"
        '
        'grbConditionList
        '
        Me.grbConditionList.Controls.Add(Me.lstCondition)
        Me.grbConditionList.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbConditionList.Location = New System.Drawing.Point(408, 19)
        Me.grbConditionList.Name = "grbConditionList"
        Me.grbConditionList.Size = New System.Drawing.Size(352, 117)
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
        Me.lstCondition.Size = New System.Drawing.Size(336, 84)
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
        Me.grbCondition.Size = New System.Drawing.Size(352, 117)
        Me.grbCondition.TabIndex = 0
        Me.grbCondition.TabStop = False
        Me.grbCondition.Text = "grbCondition"
        '
        'txtValue
        '
        Me.txtValue.Location = New System.Drawing.Point(119, 80)
        Me.txtValue.Name = "txtValue"
        Me.txtValue.Size = New System.Drawing.Size(224, 21)
        Me.txtValue.TabIndex = 5
        Me.txtValue.Text = "txtValue"
        '
        'lblValue
        '
        Me.lblValue.Location = New System.Drawing.Point(9, 82)
        Me.lblValue.Name = "lblValue"
        Me.lblValue.Size = New System.Drawing.Size(102, 16)
        Me.lblValue.TabIndex = 4
        Me.lblValue.Text = "lblValue"
        '
        'cboOperator
        '
        Me.cboOperator.DisplayMember = "DISPLAY"
        Me.cboOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOperator.Location = New System.Drawing.Point(120, 52)
        Me.cboOperator.Name = "cboOperator"
        Me.cboOperator.Size = New System.Drawing.Size(224, 21)
        Me.cboOperator.TabIndex = 3
        Me.cboOperator.ValueMember = "VALUE"
        '
        'lblOperator
        '
        Me.lblOperator.Location = New System.Drawing.Point(9, 54)
        Me.lblOperator.Name = "lblOperator"
        Me.lblOperator.Size = New System.Drawing.Size(102, 16)
        Me.lblOperator.TabIndex = 2
        Me.lblOperator.Text = "lblOperator"
        '
        'cboField
        '
        Me.cboField.DisplayMember = "DISPLAY"
        Me.cboField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboField.Location = New System.Drawing.Point(120, 24)
        Me.cboField.Name = "cboField"
        Me.cboField.Size = New System.Drawing.Size(224, 21)
        Me.cboField.TabIndex = 1
        Me.cboField.ValueMember = "VALUE"
        '
        'lblField
        '
        Me.lblField.Location = New System.Drawing.Point(10, 26)
        Me.lblField.Name = "lblField"
        Me.lblField.Size = New System.Drawing.Size(102, 16)
        Me.lblField.TabIndex = 0
        Me.lblField.Text = "lblField"
        '
        'grbSearchResult
        '
        Me.grbSearchResult.Controls.Add(Me.pnlSearchResult)
        Me.grbSearchResult.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbSearchResult.Location = New System.Drawing.Point(5, 208)
        Me.grbSearchResult.Name = "grbSearchResult"
        Me.grbSearchResult.Size = New System.Drawing.Size(851, 312)
        Me.grbSearchResult.TabIndex = 2
        Me.grbSearchResult.TabStop = False
        Me.grbSearchResult.Text = "grbSearchResult"
        '
        'pnlSearchResult
        '
        Me.pnlSearchResult.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlSearchResult.Location = New System.Drawing.Point(8, 24)
        Me.pnlSearchResult.Name = "pnlSearchResult"
        Me.pnlSearchResult.Size = New System.Drawing.Size(832, 280)
        Me.pnlSearchResult.TabIndex = 0
        '
        'ssbInfo
        '
        Me.ssbInfo.Items.AddRange(New Object() {Me.ssbPanelStatus, Me.ssbPanelExecFlag})
        Me.ssbInfo.Location = New System.Drawing.Point(0, 549)
        Me.ssbInfo.Name = "ssbInfo"
        Me.ssbInfo.Size = New System.Drawing.Size(832, 23)
        Me.ssbInfo.TabIndex = 3
        Me.ssbInfo.Text = "ssbInfo"
        Me.ssbInfo.UIStyle = Xceed.SmartUI.UIStyle.UIStyle.WindowsClassic
        '
        'ssbPanelStatus
        '
        Me.ssbPanelStatus.Text = "F6: Focus to grid, F7: Prev, F8: Next, F9: Choose"
        '
        'btnBACK
        '
        Me.btnBACK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnBACK.Location = New System.Drawing.Point(8, 524)
        Me.btnBACK.Name = "btnBACK"
        Me.btnBACK.Size = New System.Drawing.Size(48, 21)
        Me.btnBACK.TabIndex = 10
        Me.btnBACK.Tag = "btnBACK"
        Me.btnBACK.Text = "btnBACK"
        '
        'Tool1
        '
        Me.Tool1.ImageIndex = 1
        Me.Tool1.Text = "tbnExit"
        '
        'btnNEXT
        '
        Me.btnNEXT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnNEXT.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.btnNEXT.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNEXT.Location = New System.Drawing.Point(64, 524)
        Me.btnNEXT.Name = "btnNEXT"
        Me.btnNEXT.Size = New System.Drawing.Size(48, 21)
        Me.btnNEXT.TabIndex = 9
        Me.btnNEXT.Tag = "btnNEXT"
        Me.btnNEXT.Text = "btnNEXT"
        '
        'chkALL
        '
        Me.chkALL.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkALL.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.chkALL.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkALL.Location = New System.Drawing.Point(132, 527)
        Me.chkALL.Name = "chkALL"
        Me.chkALL.Size = New System.Drawing.Size(88, 16)
        Me.chkALL.TabIndex = 11
        Me.chkALL.Tag = "chkALL"
        Me.chkALL.Text = "Search All"
        '
        'imlSearch
        '
        Me.imlSearch.ImageSize = New System.Drawing.Size(32, 32)
        Me.imlSearch.ImageStream = CType(resources.GetObject("imlSearch.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlSearch.TransparentColor = System.Drawing.Color.Transparent
        '
        'SmartToolBar1
        '
        Me.SmartToolBar1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.SmartToolBar1.Items.AddRange(New Object() {Me.tbnAdd, Me.tbnView, Me.tbnEdit, Me.tbnDelete, Me.tbnExecute, Me.SeparatorTool1, Me.tbnExit})
        Me.SmartToolBar1.ItemsImageList = Me.imlSearch
        Me.SmartToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.SmartToolBar1.Name = "SmartToolBar1"
        Me.SmartToolBar1.Size = New System.Drawing.Size(832, 42)
        Me.SmartToolBar1.TabIndex = 12
        Me.SmartToolBar1.Text = "SmartToolBar1"
        Me.SmartToolBar1.UIStyle = Xceed.SmartUI.UIStyle.UIStyle.WindowsClassic
        '
        'tbnAdd
        '
        Me.tbnAdd.ImageIndex = 4
        Me.tbnAdd.Text = "tbnAdd"
        '
        'tbnView
        '
        Me.tbnView.ImageIndex = 0
        Me.tbnView.OverFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbnView.Text = "tbnView"
        '
        'tbnEdit
        '
        Me.tbnEdit.ImageIndex = 2
        Me.tbnEdit.Text = "tbnEdit"
        '
        'tbnDelete
        '
        Me.tbnDelete.ImageIndex = 3
        Me.tbnDelete.Text = "tbnDelete"
        '
        'tbnExecute
        '
        Me.tbnExecute.ImageIndex = 6
        Me.tbnExecute.Text = "Execute"
        '
        'tbnExit
        '
        Me.tbnExit.ImageIndex = 1
        Me.tbnExit.Text = "tbnExit"
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
        'frmProductManagement
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.ClientSize = New System.Drawing.Size(832, 572)
        Me.Controls.Add(Me.chkALL)
        Me.Controls.Add(Me.ssbInfo)
        Me.Controls.Add(Me.grbSearchResult)
        Me.Controls.Add(Me.grbSearchFilter)
        Me.Controls.Add(Me.btnNEXT)
        Me.Controls.Add(Me.btnBACK)
        Me.Controls.Add(Me.SmartToolBar1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.MinimizeBox = False
        Me.Name = "frmProductManagement"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmSearch"
        Me.grbSearchFilter.ResumeLayout(False)
        Me.grbConditionList.ResumeLayout(False)
        Me.grbCondition.ResumeLayout(False)
        Me.grbSearchResult.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Khai báo hằng, biến "

    Private Const REGTYPE_AUTOID = "AUTOID"
    Private Const REGTYPE_AFTYPE = "AFTYPE"
    Private Const REGTYPE_MODCODE = "MODCODE"
    Private Const REGTYPE_ACTYPE = "ACTYPE"

    Private mv_strAFTYPE As String
    Private mv_strMODCODE As String
    Private mv_dsInput As DataSet
    Private mv_strUserLanguage As String
    Private mv_strSQLCMD As String
    Private mv_intExecFlag As ExecuteFlag

    Public Property ExeFlag() As ExecuteFlag
        Get
            Return mv_intExecFlag
        End Get
        Set(ByVal Value As ExecuteFlag)
            mv_intExecFlag = Value
        End Set
    End Property

    Public Property AFTYPE() As String
        Get
            Return mv_strAFTYPE
        End Get
        Set(ByVal Value As String)
            mv_strAFTYPE = Value
        End Set
    End Property
    Public Property MODCODE() As String
        Get
            Return mv_strMODCODE
        End Get
        Set(ByVal Value As String)
            mv_strMODCODE = Value
        End Set
    End Property


    Const c_ResourceManager = "_DIRECT.frmProductManagement-"
    Const c_ResourceManagerGrid = "AppCore.frmSearch-"
    Dim mv_dblTR_QTTY As Double = 0
    Protected WithEvents SearchGrid As GridEx
    Protected WithEvents SearchCell As Xceed.Grid.Cell
    Public mv_strSearchFilter As String
    Public hFilter As New Hashtable
    Public mv_frmTransactScreen As frmTransact

    'Khai bao cac bien cho khop lenh bang tay
    Public mv_strCONFIRM_NO As String = String.Empty
    Public mv_strCUSTODYCD As String = String.Empty
    Public mv_strB_CUSTODYCD As String = String.Empty
    Public mv_strS_CUSTODYCD As String = String.Empty
    Public mv_strBORS As String = String.Empty
    Public mv_strSEC_CODE As String = String.Empty
    Public mv_intQUANTITY As Integer = 0
    Public mv_intB_QUANTITY As Integer = 0
    Public mv_intS_QUANTITY As Integer = 0
    Public mv_dblPRICE As Double = 0
    Public mv_strMATCH_DATE As String = String.Empty
    Public v_strS_ACCOUNT_NO As String = String.Empty
    Public v_strB_ACCOUNT_NO As String = String.Empty
    Public v_strS_ORDER_NO As String = String.Empty
    Public v_strB_ORDER_NO As String = String.Empty

    Private mv_strTableName As String
    Private mv_strCaption As String
    Private mv_strEnCaption As String
    Private mv_strKeyColumn As String
    Private mv_strKeyFieldType As String
    Private mv_strRefColumn As String
    Private mv_strRefFieldType As String
    Private mv_strCmdSql As String
    Private mv_strCmdSqlTemp As String

    Private mv_strTLTXCD As String
    Private mv_strSrOderByCmd As String
    Private mv_strObjName As String
    Private mv_strFormName As String
    Private mv_intSearchNum As Integer
    Private mv_strModuleCode As String
    Private mv_strIsLocalSearch As String
    Private mv_blnSearchOnInit As Boolean
    Private mv_strAuthCode As String
    Private mv_strAuthString As String
    Private mv_strIsLookup As String = "N"
    Private mv_strReturnValue As String
    Private mv_strRefValue As String
    Private mv_strReturnData As String
    Private mv_strXMLData As String
    Private mv_intDblGrid As Integer = 0
    Private mv_strIpAddress As String
    Private mv_strWsName As String

    Private mv_arrSrFieldOperator() As String                   'Danh sách các toán tử đi?u kiện
    Private mv_arrSrOperator() As String                        'Mảng các toán tử đi?u kiện
    Private mv_arrSrSQLRef() As String                          'Câu lệnh SQL liên quan
    Private mv_arrSrFieldType() As String                       'Loại dữ liệu của trư?ng
    Private mv_arrSrFieldSrch() As String                       'Tên các trư?ng làm tiêu chí để tìm kiếm
    Private mv_arrSrFieldDisp() As String                       'Tên các trư?ng sẽ hiển thị trên Combo
    Private mv_arrSrFieldMask() As String                       'Mặt nạ nhập dữ liệu
    Private mv_arrStFieldDefValue() As String                   'Giá trị mặc định
    Private mv_arrSrFieldFormat() As String                     '?ịnh dạng dữ liệu
    Private mv_arrSrFieldDisplay() As String                    'Có hiển thị trên lưới không
    Private mv_arrSrFieldWidth() As Integer                     '?ộ rộng hiển thị trên lưới
    Private mv_arrStFieldMandartory() As String
    Private mv_arrStFieldMultiLang() As String                   'Có đa ngôn ngữ không
    Private mv_arrStFieldRefCDType() As String                   '
    Private mv_arrStFieldRefCDName() As String                   '

    Private mv_strLanguage As String
    Private mv_ResourceManager As Resources.ResourceManager

    Private mv_strBranchId As String
    Private mv_strTellerId As String
    Private mv_strTellerRight As String
    Private mv_strGroupCareBy As String
    Private mv_intpage As Int32 = 1
    Private mv_rowpage As Int32 = 1
    Private mv_strBusDate As String


    Private mv_SelectedRow As Xceed.Grid.Row
#End Region

#Region " Các thuộc tính của form "

    Public Property IpAddress() As String
        Get
            Return mv_strIpAddress
        End Get
        Set(ByVal Value As String)
            mv_strIpAddress = Value
        End Set
    End Property

    Public Property WsName() As String
        Get
            Return mv_strWsName
        End Get
        Set(ByVal Value As String)
            mv_strWsName = Value
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
    Public Property FULLDATA() As String
        Get
            Return mv_strXMLData
        End Get
        Set(ByVal Value As String)
            mv_strXMLData = Value
        End Set
    End Property

    Public Property RETURNDATA() As String
        Get
            Return mv_strReturnData
        End Get
        Set(ByVal Value As String)
            mv_strReturnData = Value
        End Set
    End Property

    Public Property ReturnValue() As String
        Get
            Return mv_strReturnValue
        End Get
        Set(ByVal Value As String)
            mv_strReturnValue = Value
        End Set
    End Property

    Public Property RefValue() As String
        Get
            Return mv_strRefValue
        End Get
        Set(ByVal Value As String)
            mv_strRefValue = Value
        End Set
    End Property

    Public Property IsLookup() As String
        Get
            Return mv_strIsLookup
        End Get
        Set(ByVal Value As String)
            mv_strIsLookup = Value
        End Set
    End Property

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

    Public Property TellerRight() As String
        Get
            Return mv_strTellerRight
        End Get
        Set(ByVal Value As String)
            mv_strTellerRight = Value
        End Set
    End Property

    Public Property GroupCareBy() As String
        Get
            Return mv_strGroupCareBy
        End Get
        Set(ByVal Value As String)
            mv_strGroupCareBy = Value
        End Set
    End Property

    Public ReadOnly Property ResourceManager() As Resources.ResourceManager
        Get
            Return mv_ResourceManager
        End Get
    End Property

    Public Property AuthCode() As String
        Get
            Return mv_strAuthCode
        End Get
        Set(ByVal Value As String)
            mv_strAuthCode = Value
        End Set
    End Property

    Public Property AuthString() As String
        Get
            Return mv_strAuthString
        End Get
        Set(ByVal Value As String)
            mv_strAuthString = Value
        End Set
    End Property
#End Region

#Region " Overridable Function "
    Public Overridable Sub OnClose()
        If Me.IsLookup = "Y" Then
            'Nếu là form search dùng để lookup thì trả v? giá trị tìm kiếm
            If SearchGrid.DataRows.Count > 0 Then
                If Not SearchGrid.CurrentRow Is Nothing Then
                    If Not (SearchGrid.CurrentRow Is SearchGrid.FixedFooterRows.Item(0)) Then
                        ReturnValue = CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells(mv_strKeyColumn).Value
                        If Len(mv_strRefColumn) > 0 Then
                            RefValue = CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells(mv_strRefColumn).Value
                        Else
                            RefValue = String.Empty
                        End If
                    End If
                End If
            End If
        Else
            If Me.TableName = "MATCH_RESULT" And Me.ModuleCode = "SA" Then
                'Nếu là form search dùng để tim kiem trong trading_result thì trả v? giá trị tìm kiếm
                If SearchGrid.DataRows.Count > 0 Then
                    If Not SearchGrid.CurrentRow Is Nothing Then
                        If Not (SearchGrid.CurrentRow Is SearchGrid.FixedFooterRows.Item(0)) Then
                            mv_strCONFIRM_NO = CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("CONFIRM_NO").Value
                            mv_strB_CUSTODYCD = CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("B_ACCOUNT_NO").Value
                            mv_strS_CUSTODYCD = CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("S_ACCOUNT_NO").Value
                            mv_strSEC_CODE = CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("SEC_CODE").Value
                            mv_intQUANTITY = CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("QUANTITY").Value
                            mv_intB_QUANTITY = CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("MATCHED_BQTTY").Value
                            mv_intS_QUANTITY = CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("MATCHED_SQTTY").Value
                            mv_dblPRICE = CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("PRICE").Value
                            mv_strMATCH_DATE = CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("TRADING_DATE").Value
                            v_strS_ACCOUNT_NO = CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("S_ACCOUNT_NO").Value
                            v_strB_ACCOUNT_NO = CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("B_ACCOUNT_NO").Value
                            v_strS_ORDER_NO = CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("S_ORDER_NO").Value
                            v_strB_ORDER_NO = CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("B_ORDER_NO").Value
                        End If
                    End If
                End If
            Else
                'Ghi nhận lại đi?u kiện tìm kiếm lần cuối cùng
                SaveLastSearch()
            End If
        End If
        Me.Close()
    End Sub

    Protected Overridable Function ShowForm(ByVal pv_intExecFlag As Integer) As DialogResult
        Select Case pv_intExecFlag
            Case ExecuteFlag.AddNew
                ssbPanelExecFlag.Text = mv_ResourceManager.GetString("ExecuteFlag.AddNew")
            Case ExecuteFlag.View
                ssbPanelExecFlag.Text = mv_ResourceManager.GetString("ExecuteFlag.View")
            Case ExecuteFlag.Edit
                ssbPanelExecFlag.Text = mv_ResourceManager.GetString("ExecuteFlag.Edit")
            Case ExecuteFlag.Delete
                ssbPanelExecFlag.Text = mv_ResourceManager.GetString("ExecuteFlag.Delete")
        End Select
    End Function

    Protected Overridable Function OnSearch(Optional ByVal pv_strIsLocal As String = "", Optional ByVal pv_strModule As String = "", Optional ByVal page As Int32 = 1) As Int32
        Dim i, j As Integer
        Dim v_xColumn As Xceed.Grid.Column, v_strFLDNAME, Value As String

        Try
            Cursor.Current = Cursors.WaitCursor

            'Update status bar
            ssbPanelStatus.Text = mv_ResourceManager.GetString("frmSearch.Searching")
            ssbPanelExecFlag.Text = String.Empty
            mv_strSearchFilter = String.Empty

            For i = 0 To lstCondition.Items.Count - 1
                If lstCondition.GetItemChecked(i) Then
                    mv_strSearchFilter &= " AND " & hFilter(lstCondition.Items(i).ToString())
                End If
            Next i
            mv_strSearchFilter = Mid(mv_strSearchFilter, 5)

            If (pv_strIsLocal <> "") And (pv_strModule <> "") Then
                Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                Dim strRow, vd As String
                Dim rownumber, v_intFrom, v_intTo As Int32
                v_intTo = page * mv_rowpage
                v_intFrom = v_intTo + 1 - mv_rowpage

                If (mv_strSrOderByCmd <> "") And (mv_strSearchFilter <> "") Then
                    mv_strSearchFilter &= "ORDER BY " & mv_strSrOderByCmd
                End If

                Dim v_strSQL As String
                Select Case ExeFlag
                    Case modCommond.ExecuteFlag.AddNew
                        'VanNT
                        'v_strSQL = " AND STATUS = 'Y' AND ACTYPE NOT IN (SELECT ACTYPE FROM REGTYPE WHERE MODCODE='" & Me.MODCODE & "' AND AFTYPE='" & Me.AFTYPE & "') "
                        If MODCODE = "FO" Then
                            v_strSQL = " AND STATUS = 'A' "
                        Else
                            v_strSQL = " AND STATUS = 'Y' "
                        End If
                        v_strSQL = v_strSQL & " AND ACTYPE NOT IN (SELECT ACTYPE FROM REGTYPE WHERE MODCODE='" & Me.MODCODE & "' AND AFTYPE='" & Me.AFTYPE & "') "
                        'End of VanNT
                    Case modCommond.ExecuteFlag.Delete
                        v_strSQL = " AND ACTYPE IN (SELECT ACTYPE FROM REGTYPE WHERE MODCODE='" & Me.MODCODE & "' AND AFTYPE='" & Me.AFTYPE & "')"
                End Select

                If mv_strSearchFilter = "" Then
                    If mv_strSrOderByCmd <> "" Then
                        mv_strSearchFilter = " 0=0 ORDER BY " & mv_strSrOderByCmd
                    Else
                        mv_strSearchFilter = " 0 = 0 "
                    End If
                    If Me.chkALL.Checked = True Then
                        strRow = "SELECT * FROM ( SELECT T1.*,ROWNUM RN FROM(" & mv_strCmdSql & v_strSQL & " AND " & mv_strSearchFilter & ")T1)" ' WHERE RN BETWEEN " & v_intFrom & " AND " & v_intTo
                    Else
                        strRow = "SELECT * FROM ( SELECT T1.*,ROWNUM RN FROM(" & mv_strCmdSql & v_strSQL & " AND " & mv_strSearchFilter & ")T1) WHERE RN BETWEEN " & v_intFrom & " AND " & v_intTo
                    End If
                    mv_strCmdSqlTemp = mv_strCmdSql & " AND " & mv_strSearchFilter
                Else
                    strRow = "SELECT * FROM ( SELECT T1.*,ROWNUM RN FROM(SELECT * FROM (" & mv_strCmdSql & v_strSQL & ") T WHERE  " & mv_strSearchFilter & ")T1) " 'WHERE RN BETWEEN " & v_intFrom & " AND " & v_intTo
                    mv_strCmdSqlTemp = "SELECT * FROM (" & mv_strCmdSql & v_strSQL & ") T WHERE  " & mv_strSearchFilter
                End If

                'TheNN sua
                strRow = strRow.Replace("<$BRID>", Me.BranchId)
                strRow = strRow.Replace("<$HO_BRID>", HO_BRID)
                strRow = strRow.Replace("<$BUSDATE>", Me.BusDate)

                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, pv_strIsLocal, gc_MsgTypeObj, pv_strModule, _
                                                    gc_ActionInquiry, strRow)
                v_ws.Message(v_strObjMsg)
                Me.FULLDATA = v_strObjMsg
                'Fill data into search grid
                FillDataGrid(SearchGrid, v_strObjMsg, c_ResourceManagerGrid & UserLanguage, mv_strTableName, , v_intFrom, v_intTo, CountRow())
                'Format data in search grid
                For Each v_xColumn In SearchGrid.Columns
                    v_strFLDNAME = UCase(Trim(v_xColumn.FieldName))
                    For i = 0 To mv_arrSrFieldSrch.GetLength(0) - 1
                        If UCase(mv_arrSrFieldSrch(i)) = v_strFLDNAME Then
                            v_xColumn.FormatSpecifier = mv_arrSrFieldFormat(i)
                            Exit For
                        End If
                    Next
                Next
            End If

            ssbPanelStatus.Text = String.Empty
            'Update mouse pointer
            Cursor.Current = Cursors.Default

            Me.btnNEXT.Enabled = True
            Me.btnBACK.Enabled = True

            If Me.tbnExecute.Visible Then
                If Not SearchGrid.Columns("__TICK") Is Nothing Then
                    SearchGrid.Columns("__TICK").Visible = True
                    SearchGrid.ContextMenu = Me.mnuGrid
                End If
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Function

    Protected Overridable Function GetRowPage() As Int32
        Dim v_strCmdInquiry As String
        Dim v_strRowPage As String = String.Empty
        v_strCmdInquiry = "select VARVALUE from SYSVAR where VARNAME='ROWPERPAGE'"
        Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_SEARCHFLD, gc_ActionInquiry, v_strCmdInquiry, , )
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        v_ws.Message(v_strObjMsg)
        Dim v_xmlDocument As New System.Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_nodeEntry As Xml.XmlNode
        Dim v_strFLDNAME As String
        Dim v_strValue As String
        Dim RowPage As Int32
        Try
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            For i As Integer = 0 To v_nodeList.Count - 1
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strValue = .InnerText.ToString
                        Select Case Trim(v_strFLDNAME)
                            Case "VARVALUE"
                                v_strRowPage = Trim(v_strValue)
                                Exit For
                        End Select
                    End With
                Next
            Next
            RowPage = CInt(v_strRowPage)
            Return RowPage
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return 0
        End Try
    End Function
    Protected Overridable Function OnExport() As Int32
        Try
            Dim v_dlgSave As New SaveFileDialog
            v_dlgSave.Filter = "Text files (*.txt)|*.txt|Excel files (*.xls)|*.xls|All files (*.*)|*.*"
            v_dlgSave.RestoreDirectory = True
            Dim v_res As DialogResult = v_dlgSave.ShowDialog(Me)
            If v_res = DialogResult.OK Then
                Dim v_strFileName As String = v_dlgSave.FileName
                Dim v_strData As String
                Dim v_streamWriter As New StreamWriter(v_strFileName, False, System.Text.Encoding.Unicode)

                If (SearchGrid.DataRows.Count > 0) Then
                    'Write file's header
                    v_strData = String.Empty
                    For idx As Integer = 0 To SearchGrid.Columns.Count - 1
                        If SearchGrid.Columns(idx).Visible Then
                            v_strData &= SearchGrid.Columns(idx).Title & vbTab
                        End If
                    Next
                    v_streamWriter.WriteLine(v_strData)

                    'Write data
                    For i As Integer = 0 To SearchGrid.DataRows.Count - 1
                        v_strData = String.Empty

                        For j As Integer = 0 To SearchGrid.DataRows(i).Cells.Count - 1
                            If SearchGrid.Columns(j).Visible Then
                                v_strData &= SearchGrid.DataRows(i).Cells(j).Value & vbTab
                            End If
                        Next

                        'Write data to the file
                        v_streamWriter.WriteLine(v_strData)
                    Next
                Else
                    MsgBox(mv_ResourceManager.GetString("frmSearch.NothingToExport"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
                    Exit Function
                End If

                'Close StreamWriter
                v_streamWriter.Close()

                MsgBox(mv_ResourceManager.GetString("frmSearch.ExportSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Function

    Protected Overridable Function OnAddNew() As Int32
        If ShowForm(ExecuteFlag.AddNew) = DialogResult.OK Then
        End If
    End Function

    Protected Overridable Function OnExecute() As Int32
        Dim v_strClause As String
        Cursor.Current = Cursors.WaitCursor
        If (MessageBox.Show("Do you want save this information ?", gc_ApplicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes) Then
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            'TruongLD Comment when convert
            'v_ws.Timeout = gc_WEB_SERVICE_TIMEOUT
            Dim v_strSQL, v_strObjMsg As String
            PrepareDataSet(mv_dsInput)

            For i As Integer = 0 To SearchGrid.DataRows.Count - 1
                If Not SearchGrid.DataRows(i) Is Nothing Then
                    If SearchGrid.DataRows(i).Cells("__TICK").Value = "X" Then
                        ssbPanelStatus.Text = "Saving on row @... !".Replace("@", FormatNumber(i + 1, 0) & "/" _
                            & FormatNumber(SearchGrid.DataRows.Count, 0))

                        FillDataToDS(SearchGrid.DataRows(i))

                        Select Case Me.ExeFlag
                            Case modCommond.ExecuteFlag.AddNew
                                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_REGTYPE, gc_ActionAdd, , , , gc_AutoIdUsed)
                                BuildXMLObjData(mv_dsInput, v_strObjMsg)
                            Case modCommond.ExecuteFlag.Delete
                                With SearchGrid.DataRows(i)
                                    v_strClause = REGTYPE_AFTYPE & "='" & Me.AFTYPE & "' AND " & REGTYPE_MODCODE & "='" & Me.MODCODE & "' AND " & REGTYPE_ACTYPE & "='" & .Cells(REGTYPE_ACTYPE).Value.ToString().Trim() & "'"
                                End With
                                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_REGTYPE, gc_ActionDelete, , v_strClause)
                        End Select


                        Dim v_strErrorSource, v_strErrorMessage As String
                        Dim v_lngErrorCode As Long
                        v_lngErrorCode = v_ws.Message(v_strObjMsg)
                        GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                        If v_lngErrorCode <> 0 Then
                            Cursor.Current = Cursors.Default
                            MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                            Exit Function
                        End If
                    End If
                End If
            Next
            'TruongLD Comment when convert
            'v_ws.Dispose()
            SearchGrid.DataRows.Clear()
            OnSearch(Me.IsLocalSearch, ModuleCode & "." & ObjectName)
        End If
        Cursor.Current = Cursors.Default
    End Function
    Private Function PrepareDataSet(ByRef pv_ds As DataSet) As DataSet
        Dim v_dc_0 As DataColumn
        Dim v_dc_1 As DataColumn
        Dim v_dc_2 As DataColumn
        Dim v_dc_3 As DataColumn
        Try
            If Not (pv_ds Is Nothing) Then
                pv_ds.Dispose()
            End If

            pv_ds = New DataSet("INPUT")
            pv_ds.Tables.Add("REGTYPE")


            v_dc_0 = New DataColumn(REGTYPE_AUTOID)
            v_dc_0.DataType = GetType(String)
            pv_ds.Tables(0).Columns.Add(v_dc_0)

            v_dc_1 = New DataColumn(REGTYPE_AFTYPE)
            v_dc_1.DataType = GetType(String)
            pv_ds.Tables(0).Columns.Add(v_dc_1)

            v_dc_2 = New DataColumn(REGTYPE_MODCODE)
            v_dc_2.DataType = GetType(String)
            pv_ds.Tables(0).Columns.Add(v_dc_2)

            v_dc_3 = New DataColumn(REGTYPE_ACTYPE)
            v_dc_3.DataType = GetType(String)
            pv_ds.Tables(0).Columns.Add(v_dc_3)

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function

    Private Sub FillDataToDS(ByVal pv_GridRow As Xceed.Grid.DataRow)
        Try
            Dim v_dr As DataRow
            Dim v_dc As DataColumn
            If Not mv_dsInput Is Nothing Then
                mv_dsInput.Tables(0).Rows.Clear()
                v_dr = mv_dsInput.Tables(0).NewRow()
                'Fill data for ds
                With pv_GridRow
                    v_dr(REGTYPE_AUTOID) = String.Empty
                    v_dr(REGTYPE_AFTYPE) = Me.AFTYPE
                    v_dr(REGTYPE_MODCODE) = Me.MODCODE
                    v_dr(REGTYPE_ACTYPE) = .Cells(REGTYPE_ACTYPE).Value.ToString().Trim()
                End With
                mv_dsInput.Tables(0).Rows.Add(v_dr)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Protected Overridable Function OnQuery() As Int32
        Try
            Dim v_strView As String
            If Len(Trim(AuthString)) > 0 Then
                v_strView = Mid(Trim(AuthString), 1, 1)
                If v_strView = "Y" Then
                    ShowForm(ExecuteFlag.View)
                Else
                    Return ERR_SYSTEM_OK
                End If
            End If
            Return 1
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Protected Overridable Function OnUpdate() As Int32
        'If Not (SearchGrid Is Nothing) Then
        '    mv_SelectedRow = SearchGrid.CurrentRow
        'End If
        If ShowForm(ExecuteFlag.Edit) = DialogResult.OK Then
            'OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName)
            'If Not (SearchGrid Is Nothing) Then
            '    If SearchGrid.Enabled And SearchGrid.Visible Then
            '        Dim v_strCITYPE As String = Trim(CType(mv_SelectedRow, Xceed.Grid.DataRow).Cells("ACTYPE").Value).ToString
            '        'SearchGrid.CurrentRow = SearchGrid..SelectedRows(.Controls.fin..ro
            '        'For Each v_row As Xceed.Grid.Row In SearchGrid.ro

            '        'Next
            '    End If
            'End If
        End If
    End Function

    Protected Overridable Function OnDelete(Optional ByVal pv_strIsLocal As String = "", Optional ByVal pv_strModule As String = "") As Int32
        Dim v_strKeyFieldName, v_strKeyFieldValue As String
        Dim v_strClause As String

        Try
            If MsgBox(mv_ResourceManager.GetString("frmSearch.DelConfirm"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                'Update mouse pointer
                Cursor.Current = Cursors.WaitCursor

                If (pv_strIsLocal <> "") And (pv_strModule <> "") Then
                    If Not (SearchGrid.CurrentRow Is Nothing) Then
                        If Not (SearchGrid.CurrentRow Is SearchGrid.FixedFooterRows.Item(0)) Then
                            v_strKeyFieldName = CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells(mv_strKeyColumn).FieldName
                            v_strKeyFieldValue = CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells(mv_strKeyColumn).Value
                            v_strKeyFieldValue = Replace(v_strKeyFieldValue, ".", "")
                            Select Case KeyFieldType
                                Case "D"
                                    v_strClause = v_strKeyFieldName & " = TO_DATE('" & v_strKeyFieldValue & "', '" & gc_FORMAT_DATE & "')"
                                Case "N"
                                    v_strClause = v_strKeyFieldName & " = " & v_strKeyFieldValue
                                Case "C"
                                    v_strClause = v_strKeyFieldName & " = '" & v_strKeyFieldValue & "'"
                            End Select

                            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, pv_strIsLocal, gc_MsgTypeObj, pv_strModule, gc_ActionDelete, , v_strClause)
                            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                            v_ws.Message(v_strObjMsg)

                            'Kiểm tra thông tin và xử lý lỗi (nếu có) từ message trả v?
                            Dim v_strErrorSource, v_strErrorMessage As String
                            Dim v_lngErrorCode As Long

                            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                            If v_lngErrorCode <> 0 Then
                                'Update mouse pointer
                                Cursor.Current = Cursors.Default
                                MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                                Exit Function
                            End If

                            'Remove dòng dữ liệu đã xoá kh?i grid
                            SearchGrid.CurrentRow.Remove()
                        Else
                            'Update mouse pointer
                            Cursor.Current = Cursors.Default
                            MsgBox(mv_ResourceManager.GetString("frmSearch.Footer"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                            Exit Function
                        End If
                    Else
                        'Update mouse pointer
                        Cursor.Current = Cursors.Default
                        MsgBox(mv_ResourceManager.GetString("frmSearch.NotSelected"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Exit Function
                    End If
                End If

                '?�ồng bộ lại thông tin
                'OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName)

                'Update mouse pointer
                Cursor.Current = Cursors.Default
                MsgBox(mv_ResourceManager.GetString("frmSearch.DelSuccess"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function



#End Region

#Region " Other methods "
    Protected Overridable Sub SetTransactForm()

    End Sub

    Protected Overridable Function InitDialog()
        'Khởi tạo kích thước form và load resource
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        LoadResource(Me)

        'Thiết lập các thuộc tính ban đầu cho form
        DoResizeForm()
        SearchGrid = New GridEx(mv_strTableName, c_ResourceManagerGrid & UserLanguage)
        Me.pnlSearchResult.Controls.Add(SearchGrid)
        SearchGrid.Dock = Windows.Forms.DockStyle.Fill
        'SearchCell = New Xceed.Grid.DataCell
        'SearchCell = SearchGrid.CurrentCell
        'Set double click event on Xceed Grid 
        AddHandler SearchGrid.DoubleClick, AddressOf Grid_DblClick
        If Me.SearchGrid.DataRowTemplate.Cells.Count >= 0 Then
            For i As Integer = 0 To Me.SearchGrid.DataRowTemplate.Cells.Count - 1
                AddHandler SearchGrid.DataRowTemplate.Cells(i).DoubleClick, AddressOf Grid_DblClick
                AddHandler SearchGrid.DataRowTemplate.Cells(i).Click, AddressOf Grid_Click
            Next
        End If
        AddHandler SearchGrid.DataRowTemplate.KeyUp, AddressOf Grid_KeyUp

        '
        'If Me.SearchGrid.DataRowTemplate.Cells.Count >= 0 Then
        '    For i As Integer = 0 To Me.SearchGrid.DataRowTemplate.Cells.Count - 1
        '        AddHandler SearchGrid.DataRowTemplate.Cells(i).Click, AddressOf Grid_Click
        '    Next
        'End If
        'Set click event for Xceed smart toolbar button
        AddHandler tbnAdd.Click, AddressOf Toolbar_Click
        AddHandler tbnView.Click, AddressOf Toolbar_Click
        AddHandler tbnEdit.Click, AddressOf Toolbar_Click
        AddHandler tbnDelete.Click, AddressOf Toolbar_Click
        AddHandler tbnExit.Click, AddressOf Toolbar_Click
        AddHandler tbnExecute.Click, AddressOf Toolbar_Click

        'Set click event for buttons
        AddHandler btnSearch.Click, AddressOf Button_Click
        AddHandler btnExport.Click, AddressOf Button_Click
        AddHandler btnAdd.Click, AddressOf Button_Click
        AddHandler btnRemove.Click, AddressOf Button_Click
        AddHandler btnRemoveAll.Click, AddressOf Button_Click

        'Set KeyDown event for Value textbox


        'Set enable status for toolbar buttons and other buttons depend on AuthCode string
        tbnAdd.Visible = (Mid(AuthCode, 1, 1) = "Y")
        tbnView.Visible = (Mid(AuthCode, 2, 1) = "Y")
        tbnEdit.Visible = (Mid(AuthCode, 3, 1) = "Y")
        tbnDelete.Visible = (Mid(AuthCode, 4, 1) = "Y")
        btnSearch.Enabled = (Mid(AuthCode, 5, 1) = "Y")
        btnExport.Enabled = (Mid(AuthCode, 6, 1) = "Y")
        tbnExecute.Visible = (Mid(AuthCode, 7, 1) = "Y")


        'Set enable status for toolbar buttons depend on AuthString string
        'If TellerId <> "0001" Then
        '    tbnView.Enabled = (Mid(AuthString, 1, 1) = "Y")
        '    tbnAdd.Enabled = (Mid(AuthString, 2, 1) = "Y")
        '    tbnEdit.Enabled = (Mid(AuthString, 3, 1) = "Y")
        '    tbnDelete.Enabled = (Mid(AuthString, 4, 1) = "Y")
        'End If


        'Set selected index changed event for ComboBoxes
        AddHandler cboField.SelectedIndexChanged, AddressOf Combo_SelectedIndexChanged
        AddHandler cboOperator.SelectedIndexChanged, AddressOf Combo_SelectedIndexChanged

        'Thiết lập các giá trị ban đầu cho các đi?u kiện tìm kiếm
        Dim v_strCmdInquiry As String = "SELECT * FROM V_SEARCHCD WHERE 0=0 "
        Dim v_strClause As String = " UPPER(SEARCHCODE) = '" & mv_strTableName & "' ORDER BY POSITION"
        Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_SEARCHFLD, gc_ActionInquiry, v_strCmdInquiry, v_strClause, )

        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        v_ws.Message(v_strObjMsg)
        PrepareSearchParams(UserLanguage, v_strObjMsg, mv_strCaption, mv_strEnCaption, mv_strCmdSql, mv_strObjName, mv_strFormName, _
            mv_arrSrFieldSrch, mv_arrSrFieldDisp, mv_arrSrFieldType, mv_arrSrFieldMask, mv_arrStFieldDefValue, _
            mv_arrSrFieldOperator, mv_arrSrFieldFormat, mv_arrSrFieldDisplay, mv_arrSrFieldWidth, _
            mv_arrSrSQLRef, mv_arrStFieldMultiLang, mv_arrStFieldMandartory, mv_arrStFieldRefCDType, mv_arrStFieldRefCDName, _
            mv_strKeyColumn, mv_strKeyFieldType, mv_intSearchNum, mv_strRefColumn, mv_strRefFieldType, mv_strSrOderByCmd, mv_strTLTXCD)

        cboField.Clears()
        For i As Integer = 1 To mv_intSearchNum
            cboField.AddItems(mv_arrSrFieldDisp(i), mv_arrSrFieldSrch(i))
        Next
        'Update form caption
        If UserLanguage <> "EN" Then
            FormCaption = mv_strCaption
        Else
            FormCaption = mv_strEnCaption
        End If
        Me.Text = FormCaption

        'Load the last filter
        LoadLastSearch()

        If SearchOnInit Then
            OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName)
        End If
        mv_rowpage = GetRowPage()

        'If Not mv_strTLTXCD Is Nothing Then
        '    If mv_strTLTXCD.Trim.Length = 0 Then Me.tbnExecute.Visible = False
        'End If
        If Not ObjectName Is Nothing Then
            If Me.ObjectName.Trim.Length = 0 Then Me.tbnView.Visible = False
        End If

        If Me.tbnExecute.Visible Then
            If Not SearchGrid.Columns("__TICK") Is Nothing Then
                SearchGrid.Columns("__TICK").Visible = True
                SearchGrid.ContextMenu = Me.mnuGrid
            End If
        End If
        Me.btnNEXT.Enabled = False
        Me.btnBACK.Enabled = False
    End Function

    Private Sub DoResizeForm()
        grbSearchFilter.Width = Me.Width - 18
        btnSearch.Left = grbSearchFilter.Width - btnSearch.Width - 9
        btnExport.Left = btnSearch.Left
        grbConditionList.Width = grbSearchFilter.Width - btnSearch.Width - grbConditionList.Left - 18
        lstCondition.Width = grbConditionList.Width - 16

        grbSearchResult.Width = grbSearchFilter.Width
        pnlSearchResult.Width = grbSearchResult.Width - 16
        grbSearchResult.Height = Me.Height - grbSearchResult.Top - ssbInfo.Height - 60
        pnlSearchResult.Height = grbSearchResult.Height - 32
    End Sub

    Private Sub SaveLastSearch()
        Try
            Dim v_strObjMsg As String, v_strDefVal As String = String.Empty
            Dim v_strUserProfiles As String = Application.LocalUserAppDataPath & "\" & Me.BranchId & Me.TellerId & ".xml"
            Dim v_strSection As String = Me.ModuleCode & "." & Me.ObjectName

            Dim v_xmlDocument As New Xml.XmlDocument, v_nodetxData As Xml.XmlNode
            Dim v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode, v_entryNodeTmp As Xml.XmlNode
            Dim v_attrObjName, v_attrChecked, v_attrValue, v_attrDisplay As Xml.XmlAttribute

            If Len(Dir(v_strUserProfiles)) = 0 Then
                'Tạo tệp tin UserProfiles
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, "USER_PROFILES:=" & Me.BranchId & "." & Me.TellerId, , , , )
                v_xmlDocument.LoadXml(v_strObjMsg)
            Else
                v_xmlDocument.Load(v_strUserProfiles)
            End If

            v_strObjMsg = v_xmlDocument.InnerXml
            'Nạp tệp tin UserProfiles
            v_nodetxData = v_xmlDocument.SelectSingleNode("ObjectMessage/ObjData[@OBJNAME='" & v_strSection & "']")
            If Not v_nodetxData Is Nothing Then
                v_xmlDocument.DocumentElement.RemoveChild(v_nodetxData)
            End If
            v_dataElement = v_xmlDocument.DocumentElement

            'Tạo node dữ liệu
            v_entryNode = v_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "ObjData", "")

            'Add object name
            v_attrObjName = v_xmlDocument.CreateAttribute("OBJNAME")
            v_attrObjName.Value = v_strSection
            v_entryNode.Attributes.Append(v_attrObjName)

            For i As Integer = 0 To lstCondition.Items.Count - 1
                v_entryNodeTmp = v_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "DataElement", "")

                'Add checked attribute
                v_attrChecked = v_xmlDocument.CreateAttribute("CHECKED")
                If lstCondition.GetItemChecked(i) Then
                    v_attrChecked.Value = "Y"
                Else
                    v_attrChecked.Value = "N"
                End If
                v_entryNodeTmp.Attributes.Append(v_attrChecked)

                'Add value attribute
                v_attrValue = v_xmlDocument.CreateAttribute("VALUE")
                v_attrValue.Value = hFilter(lstCondition.Items(i).ToString())
                v_entryNodeTmp.Attributes.Append(v_attrValue)

                'Add display attribute
                v_attrDisplay = v_xmlDocument.CreateAttribute("DISPLAY")
                v_attrDisplay.Value = lstCondition.Items(i).ToString()
                v_entryNodeTmp.Attributes.Append(v_attrDisplay)

                v_entryNode.AppendChild(v_entryNodeTmp)
            Next i

            v_dataElement.AppendChild(v_entryNode)
            v_xmlDocument.AppendChild(v_dataElement)

            v_xmlDocument.Save(v_strUserProfiles)
        Catch ex As Exception
            LogError.Write("Error source: AppCore.frmSearch.SaveLastSearch" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub LoadLastSearch()
        Try
            Dim v_strUserProfiles As String = Application.LocalUserAppDataPath & "\" & Me.BranchId & Me.TellerId & ".xml"
            Dim v_strSection As String = Me.ModuleCode & "." & Me.ObjectName
            Dim v_xmlDocument As New Xml.XmlDocument, v_nodetxData As Xml.XmlNode, v_nodeEntry As Xml.XmlNode
            Dim v_strObjMsg As String = String.Empty

            If Len(Dir(v_strUserProfiles)) = 0 Then
                'Tạo tệp tin UserProfiles
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, "USER_PROFILES:=" & Me.BranchId & "." & Me.TellerId, , , , )
                v_xmlDocument.LoadXml(v_strObjMsg)
                v_xmlDocument.Save(v_strUserProfiles)
            Else
                'Nạp tệp tin UserProfiles
                v_xmlDocument.Load(v_strUserProfiles)
                v_strObjMsg = v_xmlDocument.InnerXml
                v_nodetxData = v_xmlDocument.SelectSingleNode("ObjectMessage/ObjData[@OBJNAME='" & v_strSection & "']")

                If Not v_nodetxData Is Nothing Then
                    For i As Integer = 0 To v_nodetxData.ChildNodes.Count - 1
                        v_nodeEntry = v_nodetxData.ChildNodes(i)

                        lstCondition.Items.Add(v_nodeEntry.Attributes("DISPLAY").Value.ToString(), (v_nodeEntry.Attributes("CHECKED").Value.ToString() = "Y"))
                        hFilter.Add(v_nodeEntry.Attributes("DISPLAY").Value.ToString(), v_nodeEntry.Attributes("VALUE").Value.ToString())
                    Next i
                End If
            End If
        Catch ex As Exception
            LogError.Write("Error source: AppCore.frmSearch.LoadLastSearch" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub LoadResource(ByRef pv_ctrl As Windows.Forms.Control)
        Dim v_ctrl As Windows.Forms.Control

        For Each v_ctrl In pv_ctrl.Controls
            If TypeOf (v_ctrl) Is Label Then
                CType(v_ctrl, Label).Text = mv_ResourceManager.GetString("frmProductManagement." & v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is GroupBox Then
                CType(v_ctrl, GroupBox).Text = mv_ResourceManager.GetString("frmProductManagement." & v_ctrl.Name)
                LoadResource(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is Button Then
                CType(v_ctrl, Button).Text = mv_ResourceManager.GetString("frmProductManagement." & v_ctrl.Name)
            End If
        Next

        tbnAdd.Text = mv_ResourceManager.GetString("frmProductManagement.tbnAdd")
        tbnView.Text = mv_ResourceManager.GetString("frmProductManagement.tbnView")
        tbnEdit.Text = mv_ResourceManager.GetString("frmProductManagement.tbnEdit")
        tbnDelete.Text = mv_ResourceManager.GetString("frmProductManagement.tbnDelete")
        tbnExecute.Text = mv_ResourceManager.GetString("frmProductManagement.tbnExecute")
        tbnExit.Text = mv_ResourceManager.GetString("frmProductManagement.tbnExit")
        btnBACK.Text = mv_ResourceManager.GetString("frmProductManagement.btnBACK")
        btnNEXT.Text = mv_ResourceManager.GetString("frmProductManagement.btnNEXT")


    End Sub

    Private Sub NewTxtValue(ByVal pv_strSqlRef As String, ByVal pv_strFldType As String, _
                            ByVal pv_strFldMask As String, ByVal pv_strDefValue As String, ByVal pv_strFldFormat As String)
        txtValue.Dispose()

        If pv_strSqlRef.Trim.Length < 1 Then
            If Trim$(mv_arrSrFieldType(cboField.SelectedIndex + 1)) = "D" Then
                Me.txtValue = New DateTimePicker
                CType(Me.txtValue, DateTimePicker).Format = DateTimePickerFormat.Custom
                CType(Me.txtValue, DateTimePicker).CustomFormat = gc_FORMAT_DATE
            Else
                If (pv_strFldMask.Trim.Length = 0) Then
                    Me.txtValue = New System.Windows.Forms.TextBox

                    Select Case pv_strFldType.Trim
                        Case "C"
                            CType(Me.txtValue, TextBox).TextAlign = HorizontalAlignment.Left
                        Case "N"
                            CType(Me.txtValue, TextBox).TextAlign = HorizontalAlignment.Right
                    End Select
                Else
                    Me.txtValue = New FlexMaskEditBox
                    CType(Me.txtValue, FlexMaskEditBox).Mask = pv_strFldMask.Trim

                    If (pv_strFldFormat.Trim.Length > 0) Then
                        CType(Me.txtValue, FlexMaskEditBox).PromptChar = pv_strFldFormat.Trim
                    End If

                    Select Case pv_strFldType.Trim
                        Case "C"
                            CType(Me.txtValue, FlexMaskEditBox).TextAlign = HorizontalAlignment.Left
                        Case "N"
                            CType(Me.txtValue, FlexMaskEditBox).TextAlign = HorizontalAlignment.Right
                    End Select
                End If
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
        If pv_strDefValue <> "" Then
            Me.txtValue.Text = pv_strDefValue
        Else
            Me.txtValue.Text = String.Empty
        End If
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
    Private Sub frmSearch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitDialog()
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
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub frmSearch_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Dim CountR As Int32

        Select Case e.KeyCode
            Case Keys.F6
                If Not (SearchGrid Is Nothing) Then
                    If SearchGrid.Enabled And SearchGrid.Visible Then
                        SearchGrid.Focus()
                        If Not SearchGrid.CurrentRow Is Nothing Then
                            Dim dataRows As Xceed.Grid.Collections.ReadOnlyDataRowList = SearchGrid.GetSortedDataRows(True)
                            Dim firstTaggedDataRow As Xceed.Grid.DataRow = dataRows(0)
                            SearchGrid.CurrentRow = firstTaggedDataRow
                        End If
                    End If
                End If
            Case Keys.F7    'Prev
                mv_intpage = mv_intpage - 1
                If mv_intpage <= 0 Then
                    mv_intpage = 1
                End If
                OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
            Case Keys.F8    'Next
                CountR = CountRow()
                If CountR >= (mv_intpage + 1) * mv_rowpage Then
                    mv_intpage = mv_intpage + 1
                    OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
                End If
            Case Keys.F9
                'Tương đương nhấn Double Click của dòng hiện tại
                If mv_intDblGrid = 0 Then
                    mv_intDblGrid = 1
                    If Me.tbnView.Visible = False Then
                        OnClose()
                    End If
                    OnQuery()
                    mv_intDblGrid = 0
                End If
            Case Keys.Escape
                OnClose()
            Case Keys.C
                If Keys.Control Then
                    If Not (SearchGrid.CurrentRow Is Nothing) Then
                        If Not (SearchGrid.CurrentRow Is SearchGrid.FixedFooterRows.Item(0)) Then
                            If mv_strKeyColumn Is Nothing Then
                                Clipboard.SetDataObject(SearchGrid.CurrentCell.Value)
                            Else
                                Clipboard.SetDataObject(CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells(mv_strKeyColumn).Value)
                            End If
                        End If
                    End If
                End If
        End Select
    End Sub

    Private Sub Grid_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not SearchGrid.CurrentColumn Is Nothing Then
            If SearchGrid.CurrentColumn.FieldName = "__TICK" Then
                If SearchGrid.CurrentCell.Value = "X" Then
                    SearchGrid.CurrentCell.Value = String.Empty
                Else
                    SearchGrid.CurrentCell.Value = "X"
                End If
            End If
        End If
    End Sub

    Private Sub Grid_DblClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Cursor.Current = Cursors.WaitCursor
        Cursor.Show()
        If mv_intDblGrid = 0 Then
            mv_intDblGrid = 1
            If Me.tbnView.Visible = False Then
                If Me.tbnExecute.Visible = False Then
                    OnClose()
                    Exit Sub
                Else
                    OnExecute()
                    Exit Sub
                End If
            End If
            OnQuery()
            mv_intDblGrid = 0
        End If
    End Sub

    Private Sub Grid_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            Select Case e.KeyCode
                Case Keys.Space
                    Cursor.Current = Cursors.WaitCursor
                    Cursor.Show()
                    If Not SearchGrid.Columns("__TICK") Is Nothing Then
                        If SearchGrid.CurrentColumn.FieldName = "__TICK" Then
                            If SearchGrid.CurrentCell.Value = "X" Then
                                SearchGrid.CurrentCell.Value = String.Empty
                            Else
                                SearchGrid.CurrentCell.Value = "X"
                            End If
                        End If
                    End If
                Case Keys.Enter 'Enter = Onclose de insert luon cho GD,Double_click =View 
                    Cursor.Current = Cursors.WaitCursor
                    Cursor.Show()
                    'If mv_intDblGrid = 0 Then
                    '    mv_intDblGrid = 1
                    '    If Me.tbnView.Visible = False Then
                    '        If Me.tbnExecute.Visible = False Then
                    '            OnClose()
                    '            Exit Sub
                    '        Else
                    '            OnExecute()
                    '            Exit Sub
                    '        End If
                    '    End If
                    '    OnQuery()
                    '    mv_intDblGrid = 0
                    'End If
                    OnClose()
                Case Keys.Delete
                    OnDelete()
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Toolbar_Click(ByVal sender As System.Object, ByVal e As Xceed.SmartUI.SmartItemClickEventArgs)
        Cursor.Current = Cursors.WaitCursor
        Cursor.Show()
        CType(sender, Xceed.SmartUI.SmartItem).Enabled = False
        If (sender Is tbnAdd) And (tbnAdd.Visible = True) Then
            OnAddNew()
        ElseIf (sender Is tbnExecute) And (tbnExecute.Visible = True) Then
            OnExecute()
        ElseIf (sender Is tbnView) And (tbnView.Visible = True) Then
            OnQuery()
        ElseIf (sender Is tbnEdit) And (tbnEdit.Visible = True) Then
            OnUpdate()
        ElseIf (sender Is tbnDelete) And (tbnDelete.Visible = True) Then
            OnDelete(IsLocalSearch, ModuleCode & "." & ObjectName)
        ElseIf (sender Is tbnExit) Then
            OnClose()
        End If
        CType(sender, Xceed.SmartUI.SmartItem).Enabled = True
    End Sub

    Private Sub Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v_strValue, v_strValueDisplay As String
        Dim v_objResult As Object
        Dim v_strFilterTmp As String
        Dim v_strSearchKey As String
        Dim v_blnSearchKeyAdded As Boolean

        Try
            If (sender Is btnSearch) Then
                OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
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
            'Load các toán tử đi?u kiện
            AnalyzeOperator(mv_arrSrFieldOperator(cboField.SelectedIndex + 1), mv_arrSrOperator)
            cboOperator.Clears()
            For i As Integer = 1 To mv_arrSrOperator.Length
                cboOperator.AddItems(mv_arrSrOperator(i - 1), mv_arrSrOperator(i - 1))
            Next

            If CStr(Me.cboOperator.SelectedValue).Equals("LIKE") Then
                'Neu dieu kien tim kiem la like thi chuyen ve text box de bo dinh dang
                NewTxtValue(mv_arrSrSQLRef(cboField.SelectedIndex + 1), mv_arrSrFieldType(cboField.SelectedIndex + 1), _
                                    String.Empty, mv_arrStFieldDefValue(cboField.SelectedIndex + 1), mv_arrSrFieldFormat(cboField.SelectedIndex + 1))
            Else
                NewTxtValue(mv_arrSrSQLRef(cboField.SelectedIndex + 1), mv_arrSrFieldType(cboField.SelectedIndex + 1), _
                                mv_arrSrFieldMask(cboField.SelectedIndex + 1), mv_arrStFieldDefValue(cboField.SelectedIndex + 1), mv_arrSrFieldFormat(cboField.SelectedIndex + 1))
            End If

        ElseIf (sender Is cboOperator) Then
            If CStr(Me.cboOperator.SelectedValue).Equals("LIKE") Then
                'Neu dieu kien tim kiem la like thi chuyen ve text box de bo dinh dang
                NewTxtValue(mv_arrSrSQLRef(cboField.SelectedIndex + 1), mv_arrSrFieldType(cboField.SelectedIndex + 1), _
                                    String.Empty, mv_arrStFieldDefValue(cboField.SelectedIndex + 1), mv_arrSrFieldFormat(cboField.SelectedIndex + 1))
            Else
                NewTxtValue(mv_arrSrSQLRef(cboField.SelectedIndex + 1), mv_arrSrFieldType(cboField.SelectedIndex + 1), _
                                mv_arrSrFieldMask(cboField.SelectedIndex + 1), mv_arrStFieldDefValue(cboField.SelectedIndex + 1), mv_arrSrFieldFormat(cboField.SelectedIndex + 1))
            End If
            'Khi dieu kien tim kiem la like thi bo dinh dang
        End If
    End Sub

    Private Sub btnNEXT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNEXT.Click
        Dim CountR As Int32 = CountRow()
        If CountR >= (mv_intpage) * mv_rowpage Then
            mv_intpage = mv_intpage + 1
            OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
        End If
    End Sub

    Private Sub btnBACK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBACK.Click

        mv_intpage = mv_intpage - 1
        If mv_intpage <= 0 Then
            mv_intpage = 1
        End If
        OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
    End Sub

    Private Function CountRow() As Int32
        Try

            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_int, v_intCount As Integer
            Dim v_intCOUNTROW As Int32
            Dim v_strFLDNAME, v_strVALUE As String
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_strCmdInquiry As String = "select COUNT(*) COUNTROW from (" & mv_strCmdSqlTemp & ") WHERE 0=0"

            'TheNN sua
            v_strCmdInquiry = v_strCmdInquiry.Replace("<$BRID>", Me.BranchId)
            v_strCmdInquiry = v_strCmdInquiry.Replace("<$HO_BRID>", HO_BRID)
            v_strCmdInquiry = v_strCmdInquiry.Replace("<$BUSDATE>", Me.BusDate)


            'Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId , gc_IsNotLocalMsg, gc_MsgTypeObj, "SA.ALLCODE", gc_ActionInquiry, v_strCmdInquiry)
            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, IsLocalSearch, gc_MsgTypeObj, ModuleCode & "." & ObjectName, _
                                          gc_ActionInquiry, v_strCmdInquiry)

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

    Private Sub frmSearch_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Dim width As Int16
        width = Me.Width
        If width < 640 Then
            Me.Width = 640
            Me.Left = 0
        End If

    End Sub

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
                        v_strFilterTmp = "T."
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
                                    If v_strValue = String.Empty Then
                                        v_strFilterTmpUpper = Replace(v_strFilterTmpUpper, "=", "")
                                        v_strFilterTmpUpper &= " IS NULL "
                                    Else
                                        v_strFilterTmpUpper &= "UPPER ('" _
                                               & IIf(Trim(cboOperator.SelectedValue) = "LIKE", "%", "") & v_strValue _
                                               & IIf(Trim(cboOperator.SelectedValue) = "LIKE", "%", "") & "')"
                                    End If
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
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
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
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
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
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub mnuSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSelectAll.Click
        Dim v_intRow As Integer
        If Not SearchGrid Is Nothing Then
            If SearchGrid.DataRows.Count > 0 Then
                For v_intRow = 0 To SearchGrid.DataRows.Count - 1 Step 1
                    SearchGrid.DataRows(v_intRow).Cells("__TICK").Value = "X"
                Next
            End If
        End If
    End Sub

    Private Sub mnuDeselectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDeselectAll.Click
        Dim v_intRow As Integer
        If Not SearchGrid Is Nothing Then
            If SearchGrid.DataRows.Count > 0 Then
                For v_intRow = 0 To SearchGrid.DataRows.Count - 1 Step 1
                    SearchGrid.DataRows(v_intRow).Cells("__TICK").Value = String.Empty
                Next
            End If
        End If

    End Sub

    Private Sub SetFocusGrid(ByVal Value As String)
        Try
            Dim v_blnItemFound As Boolean = False
            Dim v_intIndex As Int16, v_strText As String
            Dim v_intOldIndex As Integer = SearchGrid.DataRows.IndexOf(SearchGrid.CurrentRow)
            ' Dim KeyFieldValue As String = Replace(Trim(CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells(KeyColumn).Value), ".", String.Empty)
            If KeyColumn = "" Then
                Exit Sub
            Else
                For v_intIndex = +1 To SearchGrid.DataRows.Count - 1
                    If UCase(CType(SearchGrid.DataRows(v_intIndex), Xceed.Grid.DataRow).Cells(KeyColumn).Value) = UCase(Value) Then
                        SearchGrid.CurrentRow = SearchGrid.DataRows.Item(v_intIndex)
                        SearchGrid.SelectedRows.Clear()
                        SearchGrid.SelectedRows.Add(SearchGrid.CurrentRow)
                        For i As Integer = 0 To SearchGrid.DataRows.IndexOf(SearchGrid.CurrentRow) - v_intOldIndex - 1
                            SearchGrid.Scroll(Xceed.Grid.ScrollDirection.Down)
                        Next
                        v_blnItemFound = True
                        Exit For
                    End If
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

   
End Class
