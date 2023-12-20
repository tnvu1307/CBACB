Imports System.Windows.Forms
Imports Xceed.SmartUI.Controls
Imports CommonLibrary
Imports System.Collections
Imports System.IO
Imports AppCore
Imports AppCore.modCoreLib
Imports System
Imports System.Threading
Imports DevExpress.XtraEditors
Imports Xceed.Grid
Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO.Path
Imports System.Windows.Forms.Application

Public Class frmCSVCompare
    'Inherits System.Windows.Forms.Form
    Inherits FormBase

#Region " Declare constant and variables "
    Const c_ResourceManager = "_DIRECT.frmCSVCompare-"
    Const c_statusSYSTEMNULL = "SYSTEMNULL"
    Const c_statusVSDNULL = "VSDNULL"
    Const c_statusDEVIATION = "DEVIATION"
    Const c_statusNDEVIATION = "NDEVIATION"
    Const c_fnVIEWCSV = "VIEWCSV"
    Const c_fnCOMPARE = "COMPARE"
    Const c_fnQUERY = "QUERY"
    Const c_svWrite = "WRITE"
    Const c_svAPPRV = "APPROVE"
    Const c_svEXPORT = "EXPORT"

    'Public v_frm As frmTransact
    Public v_frm As frmXtraTransact
    Private ResultGrid As GridEx
    Private v_statusCol As String
    Private mDelimiterRows As Char = "|"
    Private mDelimiterItems As Char = "~"
    Private v_searchcode As String = ""
    Private mv_strObjname As String = "ST.CSVCMP"
    Private mv_ApprvoAllow As Boolean = False
    Private mv_AllowImport As Boolean = False
    Private mv_currFunction As String = c_fnCOMPARE
    Private mv_currSaveFN As String = c_svWrite
    Private mv_tltxcd As String = String.Empty
    Private mv_intErrCount As Integer = 0
    Private mv_Req_Date As String = String.Empty

    Private mv_ResourceManager As Resources.ResourceManager
    Private mv_strLanguage As String
    Private mv_strBusDate As String
    'Private mv_strObjectName As String = "DR.CSVCMP"
    Private mv_strModCode As String
    Private mv_strLocalObject As String
    Private mv_strBranchId As String
    Private mv_strTellerId As String
    Private mv_strIpAddress As String
    Private mv_strWsName As String
    Private mv_strCMPcode As String
    Private mv_strCurrCMPCODE As String
    Private mv_strCurrFileName As String
    Private mv_strCsvAutoid As String
    Private mv_strCMPfunc As String
    Private mv_hadImport As String
    Private mv_cmpFileName As String
    Private mv_strChoosingDate As String
    Private mv_strCSVBKDT As Integer
    Private mv_intSystem_col As Integer = 2
    Private mv_intVsd_col As Integer = 3
    Private mv_intDeviation_col As Integer = 4
    Private mv_max_row_per_time As Integer = 5000
    Private mv_blnADHOCFORMULAR As Boolean = False
    Private mv_strADHOCFORMULAR_FNC As String = "GET_CSVREPORT_FORMULARFIELD"

#End Region
#Region " Properties "
    Public Property SAVECODE() As String
        Get
            Return mv_strCurrCMPCODE
        End Get
        Set(ByVal value As String)
            If mv_strCurrCMPCODE = value Then
                Return
            End If
            mv_strCurrCMPCODE = value
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
    Public Property UserLanguage() As String
        Get
            Return mv_strLanguage
        End Get
        Set(ByVal value As String)
            mv_strLanguage = value
        End Set
    End Property
    Public Property ObjectName() As String
        Get
            Return mv_strObjname
        End Get
        Set(ByVal value As String)
            mv_strObjname = value
        End Set
    End Property
    Public Property ModuleCode() As String
        Get
            Return mv_strModCode
        End Get
        Set(ByVal value As String)
            mv_strModCode = value
        End Set
    End Property
    Public Property LocalObject() As String
        Get
            Return mv_strLocalObject
        End Get
        Set(ByVal value As String)
            mv_strLocalObject = value
        End Set
    End Property
    Public Property BranchId() As String
        Get
            Return mv_strBranchId
        End Get
        Set(ByVal value As String)
            mv_strBranchId = value
        End Set
    End Property
    Public Property TellerId() As String
        Get
            Return mv_strTellerId
        End Get
        Set(ByVal value As String)
            mv_strTellerId = value
        End Set
    End Property
    Public Property IpAddress() As String
        Get
            Return mv_strIpAddress
        End Get
        Set(ByVal value As String)
            mv_strIpAddress = value
        End Set
    End Property
    Public Property WsName() As String
        Get
            Return mv_strWsName
        End Get
        Set(ByVal value As String)
            mv_strWsName = value
        End Set
    End Property
    Public Property CMPCODE() As String
        Get
            Return mv_strCMPcode
        End Get
        Set(ByVal value As String)
            mv_strCMPcode = value
        End Set
    End Property
    Public Property CMPFUNC() As String
        Get
            Return mv_strCMPfunc
        End Get
        Set(ByVal value As String)
            mv_strCMPfunc = value
        End Set
    End Property
    Public Property FILENAME() As String
        Get
            Return mv_strCurrFileName
        End Get
        Set(ByVal value As String)
            mv_strCurrFileName = value
        End Set
    End Property
    Public Property CsvAutoid() As String
        Get
            Return mv_strCsvAutoid
        End Get
        Set(ByVal value As String)
            mv_strCsvAutoid = value
        End Set
    End Property
#End Region
#Region "Init form"
    Public Sub New(ByVal pv_strLanguage As String)
        MyBase.New()
        mv_strLanguage = pv_strLanguage
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call

    End Sub
    Private Sub InitializeGrid()
        GridDetail = New GridEx
        pnDetail.Controls.Clear()
        pnDetail.Controls.Add(GridDetail)
        GridDetail.Dock = Windows.Forms.DockStyle.Fill
        'Dim v_cmrGridHeader As New Xceed.Grid.ColumnManagerRow
        'v_cmrGridHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        'v_cmrGridHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        'GridDetail.FixedHeaderRows.Add(v_cmrGridHeader)

        'GridDetail.Columns.Add(New Xceed.Grid.Column("DMACCTNO", GetType(System.String)))
        'GridDetail.Columns.Add(New Xceed.Grid.Column("SYMBOL", GetType(System.String)))
        'GridDetail.Columns.Add(New Xceed.Grid.Column("SYSTEM", GetType(System.String)))
        'GridDetail.Columns.Add(New Xceed.Grid.Column("VSD", GetType(System.String)))
        'GridDetail.Columns.Add(New Xceed.Grid.Column("DEVIATION", GetType(System.String)))

        'GridDetail.Columns("DMACCTNO").Title = mv_ResourceManager.GetString("DMACCTNO")
        'GridDetail.Columns("SYMBOL").Title = mv_ResourceManager.GetString("SYMBOL")
        'GridDetail.Columns("SYSTEM").Title = mv_ResourceManager.GetString("SYSTEM")
        'GridDetail.Columns("VSD").Title = mv_ResourceManager.GetString("VSD")
        'GridDetail.Columns("DEVIATION").Title = mv_ResourceManager.GetString("DEVIATION")


        'GridDetail.Columns("DMACCTNO").Width = 120
        'GridDetail.Columns("SYMBOL").Width = 100
        'GridDetail.Columns("SYSTEM").Width = 100
        'GridDetail.Columns("VSD").Width = 100
        'GridDetail.Columns("DEVIATION").Width = 150


        'GridDetail.Columns("DMACCTNO").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        'GridDetail.Columns("SYMBOL").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        'GridDetail.Columns("SYSTEM").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        'GridDetail.Columns("VSD").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        'GridDetail.Columns("DEVIATION").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center

        'GridDetail.Columns("DMACCTNO").CanBeSorted = True
        'GridDetail.Columns("SYMBOL").CanBeSorted = True
        'GridDetail.Columns("SYSTEM").CanBeSorted = True
        'GridDetail.Columns("VSD").CanBeSorted = True
        'GridDetail.Columns("DEVIATION").CanBeSorted = True

        'Me.Panel1.Controls.Clear()
        'Me.Panel1.Controls.Add(GridDetail)
        'GridDetail.Dock = Windows.Forms.DockStyle.Fill
    End Sub
    Private Sub LoadResource(ByRef pv_ctrl As Windows.Forms.Control)
        Dim v_ctrl As Windows.Forms.Control
        For Each v_ctrl In pv_ctrl.Controls
            Try
                If TypeOf (v_ctrl) Is Label Then
                    CType(v_ctrl, Label).Text = mv_ResourceManager.GetString(v_ctrl.Name)
                ElseIf TypeOf (v_ctrl) Is CheckBox Then
                    CType(v_ctrl, CheckBox).Text = mv_ResourceManager.GetString(v_ctrl.Name)
                ElseIf TypeOf (v_ctrl) Is GroupBox Then
                    CType(v_ctrl, GroupBox).Text = mv_ResourceManager.GetString(v_ctrl.Name)
                    LoadResource(v_ctrl)
                ElseIf TypeOf (v_ctrl) Is Button Then
                    CType(v_ctrl, Button).Text = mv_ResourceManager.GetString(v_ctrl.Name)
                ElseIf TypeOf (v_ctrl) Is Panel Then
                    LoadResource(v_ctrl)
                ElseIf TypeOf (v_ctrl) Is DateTimePicker Then
                    CType(v_ctrl, DateTimePicker).Value = CDate(Me.BusDate)
                ElseIf TypeOf (v_ctrl) Is DateEdit Then
                    CType(v_ctrl, DateEdit).EditValue = CDate(Me.BusDate)
                End If
            Catch ex As Exception
            End Try
        Next
        Try
            Me.Text = mv_ResourceManager.GetString(Me.Name)
        Catch ex As Exception

        End Try

    End Sub
    'Form overrides dispose to clean up the component list.
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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCSVCompare))
        Me.tblDeailAll = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.dteDate = New DevExpress.XtraEditors.DateEdit()
        Me.cbCompareType = New AppCore.ComboBoxEx()
        Me.lblCompareType = New System.Windows.Forms.Label()
        Me.lblReportName = New System.Windows.Forms.Label()
        Me.lblFileName = New System.Windows.Forms.Label()
        Me.cboReportName = New AppCore.ComboBoxEx()
        Me.cboFileName = New AppCore.ComboBoxEx()
        Me.btnExecute = New System.Windows.Forms.Button()
        Me.lblIncludeHeader = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.pnDetail = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.btnApprv = New System.Windows.Forms.Button()
        Me.btnReport = New System.Windows.Forms.Button()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.DataTable33 = New System.Data.DataTable()
        Me.DataTable1 = New System.Data.DataTable()
        Me.tblDeailAll.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.dteDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dteDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        CType(Me.DataTable33, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tblDeailAll
        '
        Me.tblDeailAll.ColumnCount = 1
        Me.tblDeailAll.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblDeailAll.Controls.Add(Me.TableLayoutPanel1, 0, 0)
        Me.tblDeailAll.Controls.Add(Me.TableLayoutPanel5, 0, 1)
        Me.tblDeailAll.Controls.Add(Me.TableLayoutPanel6, 0, 2)
        Me.tblDeailAll.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblDeailAll.Location = New System.Drawing.Point(0, 0)
        Me.tblDeailAll.Name = "tblDeailAll"
        Me.tblDeailAll.RowCount = 3
        Me.tblDeailAll.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 152.0!))
        Me.tblDeailAll.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblDeailAll.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37.0!))
        Me.tblDeailAll.Size = New System.Drawing.Size(939, 459)
        Me.tblDeailAll.TabIndex = 14
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.8574491!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 97.53484!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.714898!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(933, 146)
        Me.TableLayoutPanel1.TabIndex = 13
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 4
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.523809!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.95681!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.38981!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.01883!))
        Me.TableLayoutPanel3.Controls.Add(Me.lblDate, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.dteDate, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.cbCompareType, 3, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.lblCompareType, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.lblReportName, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.lblFileName, 2, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.cboReportName, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.cboFileName, 3, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.btnExecute, 3, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.lblIncludeHeader, 3, 2)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(10, 3)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 4
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.32432!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.82883!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.42857!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(903, 140)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'lblDate
        '
        Me.lblDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDate.AutoSize = True
        Me.lblDate.Location = New System.Drawing.Point(3, 7)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(80, 13)
        Me.lblDate.TabIndex = 0
        Me.lblDate.Tag = "lblDate"
        Me.lblDate.Text = "Ngày"
        '
        'dteDate
        '
        Me.dteDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dteDate.EditValue = Nothing
        Me.dteDate.Location = New System.Drawing.Point(89, 4)
        Me.dteDate.Name = "dteDate"
        Me.dteDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.dteDate.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.dteDate.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.dteDate.Size = New System.Drawing.Size(111, 20)
        Me.dteDate.TabIndex = 7
        '
        'cbCompareType
        '
        Me.cbCompareType.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbCompareType.DisplayMember = "DISPLAY"
        Me.cbCompareType.FormattingEnabled = True
        Me.cbCompareType.Location = New System.Drawing.Point(354, 3)
        Me.cbCompareType.Name = "cbCompareType"
        Me.cbCompareType.Size = New System.Drawing.Size(546, 21)
        Me.cbCompareType.TabIndex = 3
        Me.cbCompareType.ValueMember = "VALUE"
        '
        'lblCompareType
        '
        Me.lblCompareType.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCompareType.AutoSize = True
        Me.lblCompareType.Location = New System.Drawing.Point(206, 7)
        Me.lblCompareType.Name = "lblCompareType"
        Me.lblCompareType.Size = New System.Drawing.Size(142, 13)
        Me.lblCompareType.TabIndex = 1
        Me.lblCompareType.Tag = "lblCompareType"
        Me.lblCompareType.Text = "Loại báo cáo"
        '
        'lblReportName
        '
        Me.lblReportName.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblReportName.AutoSize = True
        Me.lblReportName.Location = New System.Drawing.Point(3, 38)
        Me.lblReportName.Name = "lblReportName"
        Me.lblReportName.Size = New System.Drawing.Size(80, 13)
        Me.lblReportName.TabIndex = 8
        Me.lblReportName.Tag = "lblReportName"
        Me.lblReportName.Text = "Ten bao cao"
        '
        'lblFileName
        '
        Me.lblFileName.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblFileName.AutoSize = True
        Me.lblFileName.Location = New System.Drawing.Point(206, 38)
        Me.lblFileName.Name = "lblFileName"
        Me.lblFileName.Size = New System.Drawing.Size(142, 13)
        Me.lblFileName.TabIndex = 9
        Me.lblFileName.Tag = "lblFileName"
        Me.lblFileName.Text = "Ten file"
        '
        'cboReportName
        '
        Me.cboReportName.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboReportName.DisplayMember = "DISPLAY"
        Me.cboReportName.FormattingEnabled = True
        Me.cboReportName.Location = New System.Drawing.Point(89, 34)
        Me.cboReportName.Name = "cboReportName"
        Me.cboReportName.Size = New System.Drawing.Size(111, 21)
        Me.cboReportName.TabIndex = 10
        Me.cboReportName.ValueMember = "VALUE"
        '
        'cboFileName
        '
        Me.cboFileName.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboFileName.DisplayMember = "DISPLAY"
        Me.cboFileName.FormattingEnabled = True
        Me.cboFileName.Location = New System.Drawing.Point(354, 34)
        Me.cboFileName.Name = "cboFileName"
        Me.cboFileName.Size = New System.Drawing.Size(546, 21)
        Me.cboFileName.TabIndex = 6
        Me.cboFileName.ValueMember = "VALUE"
        '
        'btnExecute
        '
        Me.btnExecute.Location = New System.Drawing.Point(354, 88)
        Me.btnExecute.Name = "btnExecute"
        Me.btnExecute.Size = New System.Drawing.Size(167, 30)
        Me.btnExecute.TabIndex = 12
        Me.btnExecute.Text = "Xác nhận"
        Me.btnExecute.UseVisualStyleBackColor = True
        '
        'lblIncludeHeader
        '
        Me.lblIncludeHeader.AutoSize = True
        Me.lblIncludeHeader.Checked = True
        Me.lblIncludeHeader.CheckState = System.Windows.Forms.CheckState.Checked
        Me.lblIncludeHeader.Location = New System.Drawing.Point(354, 64)
        Me.lblIncludeHeader.Name = "lblIncludeHeader"
        Me.lblIncludeHeader.Size = New System.Drawing.Size(79, 17)
        Me.lblIncludeHeader.TabIndex = 13
        Me.lblIncludeHeader.Text = "CheckBox1"
        Me.lblIncludeHeader.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 3
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.pnDetail, 1, 0)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(3, 155)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 1
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 264.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(933, 264)
        Me.TableLayoutPanel5.TabIndex = 14
        '
        'pnDetail
        '
        Me.pnDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnDetail.Location = New System.Drawing.Point(23, 3)
        Me.pnDetail.Name = "pnDetail"
        Me.pnDetail.Size = New System.Drawing.Size(887, 258)
        Me.pnDetail.TabIndex = 0
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.ColumnCount = 7
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.15871!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.84129!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 113.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 104.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21.0!))
        Me.TableLayoutPanel6.Controls.Add(Me.btnExport, 5, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.btnApprv, 4, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.btnReport, 2, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.btnImport, 3, 0)
        Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(3, 425)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 1
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(933, 31)
        Me.TableLayoutPanel6.TabIndex = 15
        '
        'btnExport
        '
        Me.btnExport.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExport.Location = New System.Drawing.Point(810, 3)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(98, 25)
        Me.btnExport.TabIndex = 13
        Me.btnExport.Text = "Kết xuất"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'btnApprv
        '
        Me.btnApprv.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnApprv.Location = New System.Drawing.Point(699, 3)
        Me.btnApprv.Name = "btnApprv"
        Me.btnApprv.Size = New System.Drawing.Size(105, 25)
        Me.btnApprv.TabIndex = 14
        Me.btnApprv.Text = "Duyệt"
        Me.btnApprv.UseVisualStyleBackColor = True
        '
        'btnReport
        '
        Me.btnReport.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReport.Location = New System.Drawing.Point(474, 3)
        Me.btnReport.Name = "btnReport"
        Me.btnReport.Size = New System.Drawing.Size(105, 25)
        Me.btnReport.TabIndex = 15
        Me.btnReport.Text = "In báo cáo"
        Me.btnReport.UseVisualStyleBackColor = True
        Me.btnReport.Visible = False
        '
        'btnImport
        '
        Me.btnImport.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnImport.Location = New System.Drawing.Point(587, 3)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(105, 25)
        Me.btnImport.TabIndex = 16
        Me.btnImport.Text = "Import"
        Me.btnImport.UseVisualStyleBackColor = True
        Me.btnImport.Visible = False
        '
        'DataTable33
        '
        Me.DataTable33.Namespace = ""
        Me.DataTable33.TableName = "COMBOBOX"
        '
        'DataTable1
        '
        Me.DataTable1.Namespace = ""
        Me.DataTable1.TableName = "COMBOBOX"
        '
        'frmCSVCompare
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(939, 459)
        Me.Controls.Add(Me.tblDeailAll)
        Me.Name = "frmCSVCompare"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CSVCompare"
        Me.tblDeailAll.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        CType(Me.dteDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dteDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel6.ResumeLayout(False)
        CType(Me.DataTable33, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
#End Region
#Region "Init Param"
    Private Sub InitializeLsCompare()
        Dim v_strSQL, v_strObjMsg As String
        Dim v_ws As BDSDeliveryManagement
        Try
            'If Me.ModuleCode = "CA" Then
            'v_strSQL = String.Format("SELECT cmpid VALUE,DESCRIPTION DISPLAY,en_DESCRIPTION EN_DISPLAY FROM csvCompare WHERE cmpUsed = 'Y' and cmpid = 'CA' ORDER BY lstodr", UserLanguage)
            'v_strSQL = "SELECT cmpid,DECODE(UPPER(" & UserLanguage & ", FROM csvCompare WHERE cmpUsed = 'Y' ORDER BY lstodr"
            'Else
            v_strSQL = String.Format("SELECT cmpid VALUE,DESCRIPTION DISPLAY,en_DESCRIPTION EN_DISPLAY FROM csvCompare WHERE cmpUsed = 'Y' ORDER BY lstodr", UserLanguage)
            'End If
            v_ws = New BDSDeliveryManagement
            v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)
            FillComboEx(v_strObjMsg, cbCompareType, "", Me.UserLanguage)
        Catch ex As Exception
            LogError.Write("Error source: @FDS.frmCSVCompare.InitializeLsCompare" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
        End Try
    End Sub
    Private Sub GetInitParam()
        Dim v_ws As BDSDeliveryManagement
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_initParam As String
        Try
            Dim v_strSQL, v_strMsgObj, v_strValue, v_strFLDNAME As String
            v_ws = New BDSDeliveryManagement

            v_initParam = "initCSVBKDT"
            v_strSQL = "SELECT VARVALUE FROM SYSVAR WHERE VARNAME='CSVBKDT'"
            v_strMsgObj = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strMsgObj)
            v_xmlDocument.LoadXml(v_strMsgObj)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i = 0 To v_nodeList.Count - 1
                For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = .InnerText.ToString.Trim
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "CFGVALUE"
                                mv_strCSVBKDT = Integer.Parse(v_strValue.Trim)
                        End Select
                    End With
                Next
            Next
        Catch ex As Exception
            LogError.Write("Error source: @FDS.frmCSVCompare.GetInitParam." & v_initParam & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
        End Try
    End Sub
#End Region
#Region "Form event"
    Private Sub cbCompareType_SelectedIndexChanged()
        If Not Me.cbCompareType.SelectedValue Is Nothing Then
            Dim v_strFile As String
            mv_strCMPcode = Me.cbCompareType.SelectedValue.ToString
            v_strFile = mv_strCMPcode
            GetCMPInfo(v_strFile)
            'resetScreen()
            'Me.btnCompare.Enabled = True
            'getUpdateFileName()
            LoadReportName()


        Else
            'Me.btnCompare.Enabled = False
        End If
    End Sub
    Private Sub cboReportName_SelectedIndexChanged()
        If Not Me.cbCompareType.SelectedValue Is Nothing Then
            Dim v_strFile As String
            ' mv_strCMPcode = Me.cboReportName.SelectedValue.ToString()
            If Not Me.cboReportName.SelectedValue Is Nothing Then
                v_strFile = Me.cboReportName.SelectedValue.ToString()
            End If
            'GetCMPInfo(v_strFile)
            'resetScreen()
            'Me.btnCompare.Enabled = True
            getUpdateFileName()

            btnImport.Visible = False
            If Not cboReportName.SelectedValue Is Nothing Then
                If cboReportName.SelectedValue.ToString() = "CS077" Then
                    btnImport.Visible = True
                End If
            End If

        Else
            'Me.btnCompare.Enabled = False
        End If
    End Sub
    Private Sub dteDate_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If dteDate.EditValue Is Nothing Then
            Exit Sub
        End If
        mv_strChoosingDate = dteDate.EditValue.ToString.Substring(0, 10)
        getUpdateFileName()
    End Sub
    Private Sub btnCompare_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        ViewCompare()
    End Sub
    Private Sub btnWrite_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Select Case mv_currSaveFN
            Case c_svWrite
                SaveCompare()
            Case c_svAPPRV
                ApprvRouter()
                'Case c_svEXPORT
                '    ExportCSV()
        End Select
    End Sub

    Private Sub frmCSVCompare_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub


    Private Sub frmCSVCompare_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadResource(Me)
        Me.btnExecute.Enabled = False
        GetInitParam()
        'InitializeGrid()
        Me.dteDate.EditValue = DDMMYYYY_SystemDate(BusDate.Trim)
        Me.Text = mv_ResourceManager.GetString("CSVCompare")
        mv_strChoosingDate = BusDate

        InitializeLsCompare()
        'rdCompare.Checked = True
        'cbCompareType.SelectedIndex = -1
        'onChageRadioButton()
        cbCompareType_SelectedIndexChanged()
        'cboReportName_SelectedIndexChanged()
        'lblSummary.Visible = False
        'AddHandler rdCompare.CheckedChanged, AddressOf onChageRadioButton
        'AddHandler rdQueryResult.CheckedChanged, AddressOf onChageRadioButton
        'AddHandler rdViewCSV.CheckedChanged, AddressOf onChageRadioButton
        AddHandler dteDate.EditValueChanged, AddressOf dteDate_EditValueChanged
        AddHandler cbCompareType.SelectedIndexChanged, AddressOf cbCompareType_SelectedIndexChanged
        AddHandler cboFileName.SelectedIndexChanged, AddressOf cboFileName_SelectedIndexChanged
        AddHandler cboReportName.SelectedIndexChanged, AddressOf cboReportName_SelectedIndexChanged
    End Sub
    Private Sub cboFileName_SelectedIndexChanged()
        If cboFileName.SelectedIndex > -1 Then
            mv_strCsvAutoid = cboFileName.SelectedValue.ToString
        End If
    End Sub
#End Region
#Region "Form function"
    Private Sub ApprvRouter()
        Dim v_strFLDDEFVAL, v_strMODCODE As String
        'If mv_intErrCount > 0 Then
        '    MessageBox.Show(mv_ResourceManager.GetString("HasErrRows"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Exit Sub
        'End If
        Try
            'If mv_ApprvoAllow And Not IsDBNull(mv_tltxcd) Then
            'Select Case mv_tltxcd
            'Case "DT49"
            ' v_strFLDDEFVAL = String.Empty
            ' v_strMODCODE = "DT"
            '    Case "DA26"
            'Dim v_fdssymbol As String = GridDetail.DataRows(0).Cells("CODEID").Value
            'v_strFLDDEFVAL = "[01." & v_fdssymbol & "]"
            v_strFLDDEFVAL = ""
            If Not Me.cboReportName.SelectedValue Is Nothing And Not Me.cboFileName.SelectedValue Is Nothing Then
                If cboReportName.SelectedValue.ToString() = ("CA001") Or cboReportName.SelectedValue.ToString() = ("CA005") Or cboReportName.SelectedValue.ToString() = ("CA009") Or cboReportName.SelectedValue.ToString() = ("CA012") Or cboReportName.SelectedValue.ToString() = ("CA001") Or cboReportName.SelectedValue.ToString() = ("CA014") Or cboReportName.SelectedValue.ToString() = ("CA029") Then

                    mv_tltxcd = "1510"
                    v_strFLDDEFVAL = "[01." & cboReportName.SelectedValue.ToString() & "][22." & cboFileName.Text & "]"


                End If
                If cboReportName.SelectedValue.ToString() = ("DE013") Or cboReportName.SelectedValue.ToString() = ("DE065") Then

                    mv_tltxcd = "1509"
                    v_strFLDDEFVAL = "[01." & cboReportName.SelectedValue.ToString() & "][03." & cboFileName.Text & "]"


                End If

                If cboReportName.SelectedValue.ToString() = ("CS070") Or cboReportName.SelectedValue.ToString() = ("CS077") Then

                    mv_tltxcd = "1515"
                    v_strFLDDEFVAL = "[01." & cboReportName.SelectedValue.ToString() & "][03." & cboFileName.Text & "]"


                End If
            End If
            v_strMODCODE = "ST"
            ' End Select
            If mv_tltxcd.Length() <> 0 And v_strFLDDEFVAL.Length <> 0 Then
                'v_frm = New frmTransactMaster(mv_strLanguage)
                v_frm = New frmXtraTransactMaster(mv_strLanguage)
                v_frm.ObjectName = mv_tltxcd
                v_frm.ModuleCode = v_strMODCODE
                v_frm.LocalObject = gc_IsNotLocalMsg
                v_frm.BranchId = Me.BranchId
                v_frm.TellerId = Me.TellerId
                v_frm.IpAddress = Me.IpAddress
                v_frm.WsName = Me.WsName
                v_frm.BusDate = Me.BusDate
                v_frm.DefaultValue = v_strFLDDEFVAL
                v_frm.AutoClosedWhenOK = True
                v_frm.ShowDialog()
                v_frm.Dispose()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub getHisCompare()
        Dim v_ws As BDSDeliveryManagement
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strValue, v_strFLDNAME, v_autoid, v_tlName As String
        Try
            v_ws = New BDSDeliveryManagement
            Dim v_strSQL, v_strObjMsg As String
            Dim v_funcName = cbCompareType.SelectedValue
            'v_strSQL = "SELECT csv.*,tl.tlname FROM csvlogcompare csv, tlprofiles tl WHERE csv.tlid=tl.tlid txdate = TO_DATE('{0}','dd/mm/rrrr') AND comparetype='{2}'"
            v_strSQL = "SELECT csv.* FROM csvlogcompare csv WHERE comparedate = TO_DATE('{0}','dd/mm/rrrr') AND comparetype='{1}'"
            v_strSQL = String.Format(v_strSQL, mv_strChoosingDate, v_funcName)
            v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            If v_nodeList.Count > 0 Then
                For i As Integer = 0 To v_nodeList.Count - 1
                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            v_strValue = Trim(.InnerText.ToString)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME)
                                Case "AUTOID"
                                    v_autoid = v_strValue.Trim
                                Case "TLNAME"
                                    v_tlName = v_strValue.Trim

                            End Select
                        End With
                    Next
                Next
                Dim v_FromRow, v_ToRow As Integer
                Dim v_pageNum As Integer = 1
                Dim v_hasMore As Boolean = True
                While v_hasMore
                    v_FromRow = IIf(v_pageNum = 1, 1, v_ToRow + 1)
                    v_ToRow = v_FromRow + mv_max_row_per_time / 5
                    v_strSQL = "SELECT tbl.*, (tbl.RN - " & v_FromRow - 1 & ") RN2 FROM (SELECT * FROM csvlogcomparedtl WHERE refautoid = " & v_autoid & " AND rn BETWEEN " & v_FromRow & " AND " & v_ToRow & " order by rn) tbl "
                    v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQL)
                    v_ws.Message(v_strObjMsg)
                    fillDataToHorizontalGrid(GridDetail, v_strObjMsg, "", IIf(v_pageNum = 1, True, False), v_hasMore)
                    v_pageNum += 1
                End While
                formatGrid()
                'btnWrite.Enabled = mv_ApprvoAllow And (mv_strChoosingDate = mv_strBusDate)
            Else
                MessageBox.Show(mv_ResourceManager.GetString("err_NO_history"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                'btnWrite.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub fillDataToHorizontalGrid(ByVal pv_xGrid As GridControl, _
                                        ByVal pv_strObjMsg As String, _
                                        ByVal pv_strResource As String, _
                                        ByVal pv_firstPage As Boolean, _
                                        ByRef pv_hasMore As Boolean, _
                                        Optional ByVal pv_strTable As String = "", _
                                        Optional ByVal pv_strFilter As String = "", _
                                        Optional ByVal pv_intFromrow As Int32 = 0, _
                                        Optional ByVal pv_intTorow As Int32 = 0, _
                                        Optional ByVal pv_intTotalrow As Int32 = 0)

        Dim v_ws As BDSDeliveryManagement
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strValue, v_strFLDNAME, v_autoid, v_tlName As String
        Try
            v_xmlDocument.LoadXml(pv_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            Dim v_currRow As Integer = 0
            Dim v_columnName, v_value, v_rn As String
            pv_xGrid.BeginInit()
            pv_xGrid.SelectedRows.Clear()
            If pv_firstPage Then
                pv_xGrid.DataRows.Clear()
            End If
            Dim v_xDataRow As Xceed.Grid.DataRow
            For i As Integer = 0 To v_nodeList.Count - 1
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = Trim(.InnerText.ToString)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "COLUMN_NAME"
                                v_columnName = v_strValue.Trim
                            Case "VALUE"
                                v_value = v_strValue.Trim
                            Case "RN2"
                                v_rn = v_strValue.Trim
                        End Select
                    End With
                Next
                If v_rn > v_currRow Then
                    v_currRow += 1
                    v_xDataRow = GridDetail.DataRows.AddNew()
                End If
                For Each v_xColumn In GridDetail.Columns
                    If v_xColumn.FieldName = v_columnName Then
                        Select Case v_xColumn.DataType.Name
                            Case GetType(System.String).Name
                                v_xDataRow.Cells(v_columnName).Value = v_value
                            Case GetType(System.Decimal).Name
                                If v_value = "" Or v_value Is DBNull.Value Then
                                    v_value = 0
                                End If
                                v_xDataRow.Cells(v_xColumn.FieldName).Value = IIf(v_value Is DBNull.Value, 0, CDec(v_value))
                            Case GetType(Integer).Name
                                v_xDataRow.Cells(v_xColumn.FieldName).Value = IIf(v_value Is DBNull.Value, 0, CInt(v_value))
                            Case GetType(Long).Name
                                v_xDataRow.Cells(v_xColumn.FieldName).Value = IIf(v_value Is DBNull.Value, 0, CLng(v_value))
                            Case GetType(Double).Name
                                v_xDataRow.Cells(v_xColumn.FieldName).Value = IIf(v_value Is DBNull.Value, 0, CDbl(v_value))
                            Case GetType(System.DateTime).Name
                                v_xDataRow.Cells(v_xColumn.FieldName).Value = IIf(v_value Is DBNull.Value, "", CDate(v_value).ToShortDateString)
                            Case GetType(System.Boolean).Name
                                v_xDataRow.Cells(v_xColumn.FieldName).Value = IIf(v_value Is DBNull.Value, "", CStr(v_value))
                            Case Else
                                v_xDataRow.Cells(v_xColumn.FieldName).Value = IIf(v_value Is DBNull.Value, "", v_value)
                        End Select

                    End If
                Next
            Next
            GridDetail.EndInit()
            If v_rn = 0 Or v_rn < mv_max_row_per_time / 5 Then
                pv_hasMore = False
            Else
                pv_hasMore = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub resetScreen()
        If Not GridDetail Is Nothing Then
            GridDetail.Dispose()
        End If
        'If mv_currFunction = c_fnCOMPARE Or mv_currFunction = c_fnQUERY Then
        'If v_searchcode.Length > 0 Then
        GridDetail = New GridEx("VSDCMPVM", "AppCore.frmSearch-" & UserLanguage)
        Me.pnDetail.Controls.Clear()
        Me.pnDetail.Controls.Add(GridDetail)
        GridDetail.Dock = Windows.Forms.DockStyle.Fill
        ' End If
        'lblSummary.Visible = False
        'End If
        'btnWrite.Enabled = False
    End Sub
    Private Sub GetCMPInfo(ByVal pv_strFile As String)
        Dim v_ws As BDSDeliveryManagement
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strTEXT, v_strValue, v_strFLDNAME As String
        Try
            mv_blnADHOCFORMULAR = False
            Dim v_strSQL As String
            Dim v_strObjMsg As String
            v_ws = New BDSDeliveryManagement
            If pv_strFile.Length > 0 Then
                v_strSQL = String.Format("SELECT * FROM csvCompare WHERE cmpid = '{0}'", pv_strFile)
                v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                For i As Integer = 0 To v_nodeList.Count - 1
                    v_strTEXT = String.Empty
                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            v_strValue = Trim(.InnerText.ToString)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME).ToUpper
                                Case "CMPID"
                                    mv_strCMPfunc = v_strValue.Trim
                                Case "IMPORTALLOW"
                                    mv_AllowImport = IIf(v_strValue.Trim = "Y", True, False)
                                Case "SEARCHCODE"
                                    v_searchcode = v_strValue.Trim
                                Case "STATUSCOL"
                                    v_statusCol = v_strValue.Trim
                                Case "APPRVOALLOW"
                                    mv_ApprvoAllow = IIf(v_strValue.Trim = "Y", True, False)
                                Case "TLTXCD"
                                    mv_tltxcd = v_strValue.Trim
                                Case "ADHOCFORMULAR"
                                    mv_blnADHOCFORMULAR = IIf(v_strValue.Trim = "Y", True, False)
                            End Select
                        End With
                    Next
                Next
                If mv_strCMPfunc.Length = 0 Then
                    'Me.btnCompare.Enabled = False
                    'Me.btnWrite.Enabled = False
                Else
                    'Me.btnCompare.Enabled = True
                End If
            End If
        Catch ex As Exception
            LogError.Write("Error source: @FDS.frmCSVCompare.GetCMPInfo" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show("Đối chiếu chưa hỗ trợ", gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ViewCompare()
        Dim v_ws As BDSDeliveryManagement
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strValue, v_strFLDNAME As String
        Dim v_strDMA, v_strSYSTEM, v_strVSD, v_strDEVISION As String
        Dim v_strClause As String
        Dim v_strErr_Code As String

        Try
            Cursor.Current = Cursors.WaitCursor
            Dim v_strErrorSource, v_strErrorMessage, v_strtitle As String
            mv_cmpFileName = Me.cboFileName.SelectedValue.ToString
            v_strClause = CMPCODE & mDelimiterItems & mv_cmpFileName
            v_ws = New BDSDeliveryManagement
            ''kiem tra truoc khi thuc hien doi chieu
            'Dim v_strVerityCMP As String = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, mv_strObjname, gc_ActionAdhoc, , v_strClause, "verifyCompare", , , , IpAddress, , , , )
            'v_strErr_Code = v_ws.Message(v_strVerityCMP)
            'If v_strErr_Code <> ERR_SYSTEM_OK Then
            '    GetErrorFromMessage(v_strVerityCMP, v_strErrorSource, v_strErr_Code, v_strErrorMessage, Me.UserLanguage)
            '    Cursor.Current = Cursors.Default
            '    MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
            '    Exit Sub
            'End If

            'build message doi chieu
            Dim v_totalRow As Integer = 1, v_from_row = 1, v_to_row = 0, v_pageNum = 1
            Dim v_hasmore As Boolean = True, v_firstPage As Boolean = True
            While v_hasmore
                If v_pageNum = 1 Then
                    v_from_row = 1
                    v_to_row = v_from_row + mv_max_row_per_time
                Else
                    v_from_row = v_to_row + 1
                    v_to_row = v_from_row + mv_max_row_per_time
                End If

                Dim v_strObjMsg As String = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, mv_strObjname, gc_ActionAdhoc, , v_strClause, "getCompare", , , v_from_row & "^" & v_to_row, IpAddress, , , , )
                v_strErr_Code = v_ws.Message(v_strObjMsg)
                If v_strErr_Code <> ERR_SYSTEM_OK Then
                    MessageBox.Show(mv_ResourceManager.GetString("fileError"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                v_xmlDocument.LoadXml(v_strObjMsg)
                If v_pageNum > 1 Then
                    v_firstPage = False
                End If
                Dim v_RowCount As Integer = 0
                fillDataGrid(GridDetail, v_strObjMsg, "", v_firstPage, v_RowCount)
                ' FillDataSetToGrid(GridDetail, v_strObjMsg, "", v_firstPage, v_RowCount)
                If GridDetail.DataRows.Count = 0 Then
                    MessageBox.Show(mv_ResourceManager.GetString("noCompareData"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    v_hasmore = False
                End If
                If v_RowCount = 0 Or v_RowCount < mv_max_row_per_time Then
                    v_hasmore = False
                Else
                    v_pageNum += 1
                End If
            End While
            SAVECODE = CMPCODE
            formatGrid()
            If GridDetail.DataRows.Count > 0 Then
                'btnWrite.Enabled = True
            End If

        Catch ex As Exception
            LogError.Write("Error source: @FDS.frmCSVCompare.ViewCompare" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(mv_ResourceManager.GetString("fileError"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Function GetStringByFilter(ByVal dt As DataTable, ByVal strexp As String) As String
        Try
            Dim foundRows As Data.DataRow()
            foundRows = dt.Select(strexp)
            Return foundRows(0)("VALUE").ToString()
        Catch ex As Exception
            LogError.Write("Error source: GetStringByFilter" & strexp & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            'MessageBox.Show(mv_ResourceManager.GetString("fileError"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return ""
        End Try
    End Function
    Private Sub fillDataGrid(ByVal pv_xGrid As GridControl, _
                            ByVal pv_strObjMsg As String, _
                            ByVal pv_strResource As String, _
                            ByVal pv_firstPage As Boolean, _
                            ByRef pv_RowCount As Integer, _
                            Optional ByVal pv_initHeader As Boolean = False, _
                            Optional ByVal pv_strTable As String = "", _
                            Optional ByVal pv_strFilter As String = "", _
                            Optional ByVal pv_intFromrow As Int32 = 0, _
                            Optional ByVal pv_intTorow As Int32 = 0, _
                            Optional ByVal pv_intTotalrow As Int32 = 0)
        Dim v_dt As DataTable
        Dim v_dr As System.Data.DataRow
        Dim v_xColumn As Xceed.Grid.Column

        Try
            pv_xGrid.Columns.Clear()
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_int, v_intCount As Integer
            Dim v_strValue As String, v_strOldValue As String, v_strFLDNAME As String, v_strFLDTYPE As String
            Dim v_strColoumName As String
            Dim mv_strSTOCKTable As New DataTable
            Dim mv_strCUSTODYTable As New DataTable

            v_xmlDocument.LoadXml(pv_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            If pv_initHeader And pv_firstPage Then
                Dim v_fldname As String
                Dim v_fldname_ogr As String
                Dim v_fldname_en As String
                Dim v_defval As String
                Dim v_strSQL As String
                Dim v_strObjMsg As String
                Dim v_ws As BDSDeliveryManagement
                Dim v_xmlDocument1 As New Xml.XmlDocument
                Dim v_nodeList1 As Xml.XmlNodeList
                v_ws = New BDSDeliveryManagement
                v_strSQL = String.Format("SELECT * FROM CSVCOMPAREREPORTFLD WHERE instr('{0}',cmpid)>0 order by id ", cboReportName.SelectedValue.ToString)
                v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                v_xmlDocument1.LoadXml(v_strObjMsg)
                v_nodeList1 = v_xmlDocument1.SelectNodes("/ObjectMessage/ObjData")

                ' For i As Integer = 0 To v_nodeList1.Item(0).ChildNodes.Count - 1
                ' With v_nodeList1.Item(0).ChildNodes(i)
                '    v_fldname_ogr = UCase(CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value))
                '   pv_xGrid.Columns.Add(New Xceed.Grid.Column(v_fldname_ogr, GetType(System.String)))
                ' begin
                For i As Integer = 0 To v_nodeList1.Count - 1
                    'v_strTEXT = String.Empty
                    For j As Integer = 0 To v_nodeList1.Item(j).ChildNodes.Count - 1
                        With v_nodeList1.Item(i).ChildNodes(j)
                            v_strValue = Trim(.InnerText.ToString)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME).ToUpper
                                Case "DESCRIPTION"
                                    v_fldname = v_strValue.Trim
                                Case "EN_DESCRIPTION"
                                    v_fldname_en = v_strValue.Trim
                                Case "FLDNAME"
                                    v_fldname_ogr = v_strValue.Trim
                                Case "DEFVAL"
                                    v_defval = v_strValue.Trim
                            End Select
                        End With
                    Next
                    'Next
                    'end
                    pv_xGrid.Columns.Add(New Xceed.Grid.Column(v_fldname_ogr, GetType(System.String)))
                    pv_xGrid.Columns(v_fldname_ogr).Tag = v_defval


                    If Me.UserLanguage = "EN" Then
                        pv_xGrid.Columns(v_fldname_ogr).Title = v_fldname_en
                    Else
                        pv_xGrid.Columns(v_fldname_ogr).Title = v_fldname
                    End If

                    pv_xGrid.Columns(v_fldname_ogr).Width = 100
                    pv_xGrid.Columns(v_fldname_ogr).HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
                    pv_xGrid.Columns(v_fldname_ogr).CanBeSorted = True
                    '   End With
                Next
                pv_xGrid.DataRows.Clear()
            End If
            pv_xGrid.BeginInit()
            pv_xGrid.SelectedRows.Clear()
            If pv_firstPage Then
                pv_xGrid.DataRows.Clear()
            End If

            ' neu la de083 thi load them danh sach khach hang và chung khoan
            'If cboReportName.Text = "DE083" Then

            '    Dim v_strCmdSQL As String = "SELECT CUSTODYCD DISPLAY, cifid VALUE FROM cfmast where status ='C' "
            '    Dim v_strObjMsgSHB = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)

            '    Dim v_ws1 As BDSDeliveryManagement
            '    v_ws1 = New BDSDeliveryManagement
            '    v_ws1.Message(v_strObjMsgSHB)
            '    FillDataToTable(v_strObjMsgSHB, mv_strCUSTODYTable)

            '    v_strCmdSQL = "SELECT SYMBOL DISPLAY, ID VALUE FROM SHBSTOCK where status ='C' "
            '    v_strObjMsgSHB = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            '    v_ws1.Message(v_strObjMsgSHB)
            '    FillDataToTable(v_strObjMsgSHB, mv_strSTOCKTable)

            '    'Ngay 15/05/2018 NamTv chinh sua lai field POSITION_DATE
            '    v_strCmdSQL = "SELECT TO_DATE(TO_DATE(SUBSTR(REQ.CVAL,INSTR(REQ.CVAL,'TXDATE:')+7,8),'RRRR/MM/DD'),'DD/MM/RRRR') REQ_DATE" & ControlChars.NewLine _
            '                    & "FROM (SELECT * FROM VSD_PARCONTENT_LOG UNION ALL SELECT * FROM VSD_PARCONTENT_LOG_HIST) PA," & ControlChars.NewLine _
            '                    & "(SELECT * FROM VSDTXREQDTL UNION ALL SELECT * FROM VSDTXREQDTLHIST) REQ" & ControlChars.NewLine _
            '                    & "WHERE PA.REQID=REQ.REQID AND REQ.FLDNAME='PARAM'" & ControlChars.NewLine _
            '                    & "AND PA.CSVFILENAME= '" & cboFileName.Text.Replace("'", "''") & "'"
            '    v_strObjMsgSHB = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            '    v_ws1.Message(v_strObjMsgSHB)

            '    Dim v_xmlDocument2 As New Xml.XmlDocument
            '    Dim v_nodeList2 As Xml.XmlNodeList

            '    v_xmlDocument2.LoadXml(v_strObjMsgSHB)
            '    v_nodeList2 = v_xmlDocument2.SelectNodes("/ObjectMessage/ObjData")
            '    For i As Integer = 0 To v_nodeList2.Count - 1
            '        'v_strTEXT = String.Empty
            '        For j As Integer = 0 To v_nodeList2.Item(j).ChildNodes.Count - 1
            '            With v_nodeList2.Item(i).ChildNodes(j)
            '                v_strValue = Trim(.InnerText.ToString)
            '                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
            '                Select Case Trim(v_strFLDNAME).ToUpper
            '                    Case "REQ_DATE"
            '                        mv_Req_Date = v_strValue.Trim("DD/MM/RRRR")
            '                End Select
            '            End With
            '        Next
            '        'Next
            '    Next
            '    'Ngay 15/05/2018 NamTv End
            'End If

            pv_RowCount = v_nodeList.Count
            For v_intCount = 0 To v_nodeList.Count - 1
                'If (v_intCount >= v_nodeList.Count - rowperpage) Then

                Dim v_xDataRow As Xceed.Grid.DataRow = pv_xGrid.DataRows.AddNew()
                Try
                    For Each v_xColumn In pv_xGrid.Columns
                        v_strColoumName = UCase(Trim(v_xColumn.FieldName))

                        'gan gia tri default tu defval

                        If (InStr(v_xColumn.Tag, "@", CompareMethod.Text) > 0) Then
                            v_xDataRow.Cells(v_xColumn.FieldName).Value = Replace(v_xColumn.Tag, "@", "")
                        ElseIf (InStr(v_xColumn.Tag, "<$BUSDATE>", CompareMethod.Text) > 0) Then

                            v_xDataRow.Cells(v_xColumn.FieldName).Value = Me.BusDate
                        End If

                        If v_xColumn.FieldName = "TRADE_DATE" And cboReportName.Text = "CS077" Then
                            v_xDataRow.Cells(v_xColumn.FieldName).Value = IIf(dteDate.EditValue Is DBNull.Value, "", CDate(dteDate.EditValue).ToShortDateString)
                        End If

                        For v_int = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                            With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                                v_strValue = .InnerText.ToString
                                v_strFLDNAME = UCase(CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value))
                                v_strFLDTYPE = CStr(CType(.Attributes.GetNamedItem("fldtype"), Xml.XmlAttribute).Value)
                                If Not (v_strValue Is DBNull.Value) Then
                                    If Trim(v_strValue) = "" Then
                                        v_strValue = Nothing
                                    End If
                                End If

                                If v_strFLDNAME = v_strColoumName Then
                                    If v_strColoumName <> "SIGNATURE" Then
                                        If v_xColumn.DataType.Name = GetType(System.Boolean).Name Then
                                            v_xDataRow.Cells(v_xColumn.FieldName).Value = IIf(v_strValue = "0", False, True)
                                        Else
                                            Select Case v_xColumn.DataType.Name
                                                Case GetType(System.String).Name
                                                    v_xDataRow.Cells(v_xColumn.FieldName).Value = IIf(v_strValue Is DBNull.Value, "", CStr(v_strValue))
                                                Case GetType(System.Decimal).Name
                                                    If v_strValue = "" Then
                                                        v_strValue = 0
                                                    End If
                                                    v_xDataRow.Cells(v_xColumn.FieldName).Value = IIf(v_strValue Is DBNull.Value, 0, CDec(v_strValue))
                                                Case GetType(Integer).Name
                                                    v_xDataRow.Cells(v_xColumn.FieldName).Value = IIf(v_strValue Is DBNull.Value, 0, CInt(v_strValue))
                                                Case GetType(Long).Name
                                                    v_xDataRow.Cells(v_xColumn.FieldName).Value = IIf(v_strValue Is DBNull.Value, 0, CLng(v_strValue))
                                                Case GetType(Double).Name
                                                    v_xDataRow.Cells(v_xColumn.FieldName).Value = IIf(v_strValue Is DBNull.Value, 0, CDbl(v_strValue))
                                                Case GetType(System.DateTime).Name
                                                    v_xDataRow.Cells(v_xColumn.FieldName).Value = IIf(v_strValue Is DBNull.Value, "", CDate(v_strValue).ToShortDateString)
                                                Case GetType(System.Boolean).Name
                                                    v_xDataRow.Cells(v_xColumn.FieldName).Value = IIf(v_strValue Is DBNull.Value, "", CStr(v_strValue))

                                                Case Else
                                                    v_xDataRow.Cells(v_xColumn.FieldName).Value = IIf(v_strValue Is DBNull.Value, "", v_strValue)
                                            End Select
                                        End If
                                        'ThongPM comment
                                        'v_xDataRow.EndEdit()

                                    End If

                                End If
                            End With
                        Next

                    Next
                    '  End If
                Finally
                    v_xDataRow.EndEdit()
                End Try
            Next

            pv_xGrid.EndInit()
            _FormatGridBefore(pv_xGrid, pv_strTable, pv_strResource, False, , pv_intFromrow, pv_intTorow, pv_intTotalrow)
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            Throw ex
        Finally
            pv_xGrid.EndInit()
        End Try
    End Sub




    Private Sub SaveCompare()
        Dim v_ws As BDSDeliveryManagement
        Dim v_strObjMsg As String
        Dim v_strClause, v_strErrorSource, v_strErrorMessage, v_strtitle As String
        Dim v_fromRow As Integer = 0, v_toRow As Integer = 0, v_pageNum As Integer = 1
        Dim v_hasmore As Boolean = True
        Dim v_reference As String
        Try
            v_ws = New BDSDeliveryManagement
            If GridDetail.DataRows.Count = 0 Then
                MessageBox.Show(mv_ResourceManager.GetString("nodata"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf MessageBox.Show(mv_ResourceManager.GetString("issave") & cbCompareType.Text & "?", gc_ApplicationTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = Windows.Forms.DialogResult.OK Then
                Cursor.Current = Cursors.WaitCursor
                v_strClause = SAVECODE & mDelimiterItems & mv_cmpFileName

                v_ws = New BDSDeliveryManagement
                While v_hasmore
                    If v_pageNum = 1 Then
                        v_fromRow = 1
                    Else
                        v_fromRow = v_toRow + 1
                    End If
                    v_toRow = v_fromRow + mv_max_row_per_time
                    v_reference = buildSaveClause(v_fromRow, v_toRow, v_hasmore)
                    v_strObjMsg = BuildXMLObjMsg(mv_strChoosingDate, , , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, mv_strObjname, gc_ActionAdhoc, , SAVECODE, "saveCompare", v_pageNum, , v_reference, , IpAddress, , , )

                    v_ws.Message(v_strObjMsg)
                    v_pageNum += 1
                End While
                If mv_AllowImport Then
                    v_strObjMsg = BuildXMLObjMsg(mv_strChoosingDate, , , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, mv_strObjname, gc_ActionAdhoc, , SAVECODE, "apprvImport", , , v_reference, , IpAddress, , , )
                    v_ws.Message(v_strObjMsg)
                End If
                MessageBox.Show(mv_ResourceManager.GetString("saveComplete"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            LogError.Write("Error source: @FDS.frmCSVCompare.ViewCompare" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show("Lỗi hệ thống!!", gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Function buildSaveClause(ByVal pv_FromRow As Integer, _
                                    ByVal pv_ToRow As Integer, _
                                    ByRef pv_hasmore As Boolean) As String
        Dim v_saveClase As String = String.Empty
        Dim v_RowsCount = GridDetail.DataRows.Count
        Dim v_CellCount = GridDetail.DataRows(0).Cells.Count
        Dim v_fromRow = pv_FromRow - 1
        Dim v_toRow As Integer = Math.Min(pv_ToRow, v_RowsCount) - 1

        pv_hasmore = IIf(pv_ToRow - pv_FromRow > v_toRow - v_fromRow, False, True)
        Dim v_columnName, v_value As String
        For i As Integer = v_fromRow To v_toRow
            For j As Integer = 1 To v_CellCount - 1
                v_columnName = GridDetail.DataRows(i).Cells(j).AccessibleName
                v_value = GridDetail.DataRows(i).Cells(j).Value
                If v_value Is Nothing Then
                    v_value = String.Empty
                End If
                v_value = IIf(v_value.Length = 0, "NULL", v_value)
                v_saveClase = v_saveClase & i + 1 & "=" & v_columnName & "=" & v_value
                If j < v_CellCount - 1 Then
                    v_saveClase = v_saveClase & mDelimiterItems
                End If
            Next
            If i < v_RowsCount - 1 Then
                v_saveClase = v_saveClase & mDelimiterRows
            End If
        Next
        Return v_saveClase
    End Function
    Private Sub ViewCSVFile()
        'Dim v_frm As frmCSVViewIMP
        Try
            'If Not IsDBNull(FILENAME) Then
            '    v_frm = New frmCSVViewIMP(mv_strLanguage)
            '    'v_frm.FileName = FILENAME
            '    v_frm.FuncName = CMPCODE
            '    v_frm.AutoID = mv_strCsvAutoid
            '    v_frm.TellerID = mv_strTellerId
            '    v_frm.AllowIMP = IIf(mv_strAllowImport = "Y", True, False)
            '    v_frm.ShowDialog()
            '    v_frm.Dispose()

            'End If


            getFileDetail()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub



    Private Sub getUpdateFileName()
        Dim v_strSQL, v_strObjMsg As String
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_ws As BDSDeliveryManagement
        Try
            If cboFileName.Visible = True Then
                Dim v_bckDate As System.TimeSpan
                v_bckDate = DDMMYYYY_SystemDate(BusDate).Subtract(DDMMYYYY_SystemDate(mv_strChoosingDate))
                'If v_bckDate.Days > mv_strCSVBKDT Then
                'MessageBox.Show(mv_ResourceManager.GetString("backupNotAllow"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Me.cboFileName.Clears()
                'Me.btnExecute.Enabled = False
                'Exit Sub
            End If

            Try
                v_strSQL = String.Format("SELECT autoid VALUE, filename DISPLAY, filename EN_DISPLAY, to_char(txdate,'DD/MM/RRRR') DESCRIPTION " & ControlChars.NewLine _
                                        & " FROM vsd_csvcontent_log " & ControlChars.NewLine _
                                        & " WHERE TO_DATE(SUBSTR(FILENAME, INSTR(FILENAME,'''', -1, 3) + 1, 8),'DDMMRRRR') = TO_DATE('{1}','{2}') " & ControlChars.NewLine _
                                        & " and filename like '%{0}%'  " & ControlChars.NewLine _
                                        & " ORDER BY TO_DATE(SUBSTR(FILENAME, INSTR(FILENAME,'''', -1, 3) + 1, 8),'DDMMRRRR') DESC, TO_DATE(SUBSTR(FILENAME, INSTR(FILENAME,'''', -1, 2) + 1, 6),'HH24MISS') DESC ",
                                        cboReportName.SelectedValue.ToString, mv_strChoosingDate, gc_FORMAT_DATE_DB)

                v_ws = New BDSDeliveryManagement
                v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            Catch ex As Exception

            End Try
            

            'v_strSQL = "SELECT cmpid,DECODE(UPPER(" & UserLanguage & ", FROM csvCompare WHERE cmpUsed = 'Y' ORDER BY lstodr"
            v_ws = New BDSDeliveryManagement
            v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            If v_nodeList.Count <= 0 Then
                Try
                    'If MessageBox.Show(mv_ResourceManager.GetString("errNoCorrectFile"), gc_ApplicationTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                    v_strSQL = String.Format("SELECT autoid VALUE, filename DISPLAY, filename EN_DISPLAY, to_char(txdate,'DD/MM/RRRR') DESCRIPTION " & ControlChars.NewLine _
                                    & " FROM VSD_CSVCONTENT_LOGHIST " & ControlChars.NewLine _
                                    & " WHERE TO_DATE(SUBSTR(FILENAME, INSTR(FILENAME,'''', -1, 3) + 1, 8),'DDMMRRRR') = TO_DATE('{1}','{2}') " & ControlChars.NewLine _
                                    & " AND filename like '%{0}%' " & ControlChars.NewLine _
                                    & " ORDER BY TO_DATE(SUBSTR(FILENAME, INSTR(FILENAME,'''', -1, 3) + 1, 8),'DDMMRRRR') DESC, TO_DATE(SUBSTR(FILENAME, INSTR(FILENAME,'''', -1, 2) + 1, 6),'HH24MISS') DESC ",
                                    cboReportName.SelectedValue.ToString, mv_strChoosingDate, gc_FORMAT_DATE_DB)
                    v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQL)
                    v_ws.Message(v_strObjMsg)
                    v_xmlDocument.LoadXml(v_strObjMsg)
                    v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                Catch ex As Exception

                End Try
            End If
            'End If
            cboFileName.Clears()
            If v_nodeList.Count > 0 Then
                '     MessageBox.Show(mv_ResourceManager.GetString("errNoFile"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Else
                FillComboEx(v_strObjMsg, cboFileName, "", Me.UserLanguage)
            End If
            If Me.cboFileName.Items.Count = 0 Then
                'Me.btnCompare.Enabled = False
                Me.btnExecute.Enabled = False
                'Me.btnWrite.Enabled = False
            Else
                Me.btnExecute.Enabled = True
                'Me.btnCompare.Enabled = (mv_strChoosingDate = BusDate)
                'End If
            End If
        Catch ex As Exception
            LogError.Write("Error source: @FDS.frmCSVCompare.getUpdateFileName." & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            Me.cboFileName.Clears()
            Me.btnExecute.Enabled = False
        End Try
    End Sub

    Private Sub LoadReportName()
        Dim v_strSQL, v_strObjMsg As String
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_ws As BDSDeliveryManagement
        Try
            If cboFileName.Visible = True Then
                Dim v_bckDate As System.TimeSpan
                v_bckDate = DDMMYYYY_SystemDate(BusDate).Subtract(DDMMYYYY_SystemDate(mv_strChoosingDate))
                'If v_bckDate.Days > mv_strCSVBKDT Then
                'MessageBox.Show(mv_ResourceManager.GetString("backupNotAllow"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Me.cboFileName.Clears()
                'Me.btnExecute.Enabled = False
                'Exit Sub
                'End If
                v_strSQL = String.Format("SELECT description VALUE,description DISPLAY, en_description EN_DISPLAY from CSVCOMPAREreport  where cmpid = '{0}' ORDER BY description ", CMPCODE, mv_strChoosingDate, gc_FORMAT_DATE_DB)

                v_ws = New BDSDeliveryManagement
                v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            End If
            ' cboFileName.Clears()
            If v_nodeList.Count <= 0 Then
                MessageBox.Show(mv_ResourceManager.GetString("errNoFile"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                FillComboEx(v_strObjMsg, cboReportName, "", Me.UserLanguage)
                If CMPCODE = "CS" Then 'locpt: 14-01-2021 SHBVNEX-1943
                    cboReportName.Text = "CS077"
                End If
            End If
            If Me.cboFileName.Items.Count = 0 Then
                'Me.btnCompare.Enabled = False
                Me.btnExecute.Enabled = False
                'Me.btnWrite.Enabled = False
            Else
                Me.btnExecute.Enabled = True
                'Me.btnCompare.Enabled = (mv_strChoosingDate = BusDate)
                'End If
            End If
        Catch ex As Exception
            LogError.Write("Error source: @FDS.frmCSVCompare.getUpdateFileName." & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            Me.cboFileName.Clears()
            Me.btnExecute.Enabled = False
        End Try
    End Sub
    'Private Sub onChageRadioButton()
    '    btnExecute.Enabled = True
    '    If rdQueryResult.Checked = True Then
    '        mv_currFunction = c_fnQUERY
    '        mv_currSaveFN = c_svAPPRV
    '        lblFileName.Visible = False
    '        cboFileName.Visible = False
    '        dteDate.Enabled = True
    '        btnWrite.Visible = True
    '    ElseIf rdCompare.Checked = True Then
    '        mv_currFunction = c_fnCOMPARE
    '        mv_currSaveFN = c_svWrite
    '        lblFileName.Visible = True
    '        cboFileName.Visible = True
    '        dteDate.EditValue = DDMMYYYY_SystemDate(mv_strBusDate)
    '        dteDate.Enabled = False
    '        btnWrite.Visible = True
    '        'getUpdateFileName()
    '    ElseIf rdViewCSV.Checked = True Then
    '        mv_currFunction = c_fnVIEWCSV
    '        mv_currSaveFN = c_svEXPORT
    '        lblFileName.Visible = True
    '        cboFileName.Visible = True
    '        dteDate.Enabled = True
    '        btnWrite.Visible = False
    '        'getUpdateFileName()
    '    End If
    '    btnWrite.Text = mv_ResourceManager.GetString(mv_currSaveFN)
    '    resetScreen()

    'End Sub
    Private Sub formatGrid()
        Dim v_count As Integer = GridDetail.DataRows.Count
        Dim v_match = 0, v_deviation = 0, v_systemnull = 0, v_vsdnull = 0
        mv_intErrCount = 0
        For i As Integer = 0 To v_count - 1
            Select Case GridDetail.DataRows(i).Cells(v_statusCol).Value
                Case c_statusSYSTEMNULL
                    GridDetail.DataRows(i).ForeColor = Color.Red
                    v_systemnull += 1
                    mv_intErrCount += 1
                Case c_statusVSDNULL
                    GridDetail.DataRows(i).ForeColor = Color.Red
                    v_vsdnull += 1
                    mv_intErrCount += 1
                Case c_statusDEVIATION
                    GridDetail.DataRows(i).ForeColor = Color.Red
                    v_deviation += 1
                    mv_intErrCount += 1
                Case c_statusNDEVIATION
                    v_match += 1
            End Select
            'If GridDetail.DataRows(i).Cells(mv_intSystem_col).Value Is Nothing Then
            '    GridDetail.DataRows(i).Cells(mv_intDeviation_col).Value = mv_ResourceManager.GetString("SYSTEMNULL")
            '    GridDetail.DataRows(i).ForeColor = Color.Red
            '    v_systemnull += 1
            'ElseIf GridDetail.DataRows(i).Cells(mv_intVsd_col).Value Is Nothing Then
            '    GridDetail.DataRows(i).Cells(mv_intDeviation_col).Value = mv_ResourceManager.GetString("VSDNULL")
            '    GridDetail.DataRows(i).ForeColor = Color.Red
            '    v_vsdnull += 1
            'ElseIf GridDetail.DataRows(i).Cells(mv_intSystem_col).Value = GridDetail.DataRows(i).Cells(mv_intVsd_col).Value Then
            '    GridDetail.DataRows(i).Cells(mv_intDeviation_col).Value = mv_ResourceManager.GetString("notDeviation")
            '    v_match += 1
            'Else
            '    GridDetail.DataRows(i).Cells(mv_intDeviation_col).Value = mv_ResourceManager.GetString("isDeviation")
            '    GridDetail.DataRows(i).ForeColor = Color.Red
            '    v_deviation += 1
            'End If
        Next
        'Me.btnWrite.Enabled = True
        'lblSummary.Visible = True
        'Me.lblSummary.Text = String.Format(mv_ResourceManager.GetString("cmpSummary"), _
        '                                  GridDetail.DataRows.Count, v_match, v_deviation, v_vsdnull, v_systemnull)
    End Sub


    Private Sub getFileDetail()
        Dim v_strSQL, v_strObjMsg, v_strMSGBODY, v_strFuncName As String
        Dim v_ws As BDSDeliveryManagement
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_dsDetail As DataTable
        Dim v_allowIMP As String
        Dim v_fromRow, v_toRow, v_rowCount As Integer
        Dim v_pageNum As Integer = 1
        Dim v_hasmore As Boolean = True
        Dim v_maxrow As Integer = 6000
        Try
            mv_strCsvAutoid = cboFileName.SelectedValue.ToString
            v_strSQL = "SELECT  vsd.msgbody FROM (select * from  vsd_csvcontent_log union all select * from VSD_CSVCONTENT_LOGHIST) vsd WHERE autoid = " & mv_strCsvAutoid
            v_ws = New BDSDeliveryManagement
            GridDetail = New GridEx
            'v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQL)

            While v_hasmore
                If v_pageNum = 1 Then
                    v_fromRow = 1
                Else
                    v_fromRow = v_toRow + 1
                End If
                v_toRow = v_fromRow + v_maxrow
                v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, mv_strObjname, gc_ActionAdhoc, , mv_strCsvAutoid, "getFileDetail", , , v_fromRow & "^" & v_toRow, IpAddress, , , , )
                v_ws.Message(v_strObjMsg)
                'v_xmlDocument.LoadXml(v_strObjMsg)
                'v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                'Dim v_strValue, v_strFLDNAME As String
                'For i As Integer = 0 To v_nodeList.Count - 1
                '    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                '        With v_nodeList.Item(i).ChildNodes(j)
                '            v_strValue = .InnerText.ToString
                '            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                '            Select Case Trim(v_strFLDNAME)
                '                Case "MSGBODY"
                '                    v_strMSGBODY = v_strValue.Trim
                '                Case "FUNCNAME"
                '                    v_strFuncName = v_strValue.Trim
                '                Case "FILENAME"
                '                    FILENAME = v_strValue.Trim
                '            End Select
                '        End With
                '    Next
                'Next
                'Dim v_dsBody As DataSet
                'v_dsBody = CommonLib.ConvertXmlToDataSet(v_strMSGBODY)
                'If v_dsBody Is Nothing Then
                '    MsgBox(mv_ResourceManager.GetString("csvError"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                '    btnWrite.Enabled = False
                '    Exit Sub
                'End If
                'FillDetail2Grid(v_dsBody.Tables(0), v_pageNum)
                fillDataGrid(GridDetail, v_strObjMsg, "", IIf(v_pageNum = 1, True, False), v_rowCount, True)
                'FillDataSetToGrid(GridDetail, v_strObjMsg, "", 0, v_rowCount)
                'Dim ds As DataSet
                'ds = GridDetail.DataSource
                If v_rowCount <= v_maxrow Then
                    v_hasmore = False
                End If
                v_pageNum += 1
            End While

            If GridDetail.DataRows.Count > 0 Then
                Dim v_cmrContactsHeader As New Xceed.Grid.ColumnManagerRow
                v_cmrContactsHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
                v_cmrContactsHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
                GridDetail.FixedHeaderRows.Clear()
                GridDetail.FixedHeaderRows.Add(v_cmrContactsHeader)

                Dim v_frResultGrid = New Xceed.Grid.TextRow(String.Format(mv_ResourceManager.GetString("viewSummary"), GridDetail.DataRows.Count))
                v_frResultGrid.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
                v_frResultGrid.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic)
                GridDetail.FixedFooterRows.Clear()
                GridDetail.FixedFooterRows.Add(v_frResultGrid)

                Me.pnDetail.Controls.Clear()
                Me.pnDetail.Controls.Add(GridDetail)
                GridDetail.Dock = System.Windows.Forms.DockStyle.Fill
                GridDetail.EndInit()
                Me.pnDetail.Controls.Clear()
                Me.pnDetail.Controls.Add(GridDetail)
                GridDetail.Dock = System.Windows.Forms.DockStyle.Fill
            Else
                MsgBox(mv_ResourceManager.GetString("csvError"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            End If
            'btnWrite.Enabled = True
        Catch ex As Exception
            MsgBox(mv_ResourceManager.GetString("csvError"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            LogError.Write("Error source: @FDS.frmCSVCompare.getFileDetail" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
        End Try
    End Sub
    Private Sub FillDetail2Grid(ByVal pv_ds As DataTable)
        Try
            GridDetail = New GridEx

            Dim v_cmrContactsHeader As New Xceed.Grid.ColumnManagerRow
            v_cmrContactsHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
            v_cmrContactsHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            GridDetail.FixedHeaderRows.Add(v_cmrContactsHeader)
            For col As Integer = 0 To pv_ds.Columns.Count - 1
                GridDetail.Columns.Add(New Xceed.Grid.Column(pv_ds.Columns(col).Caption, GetType(System.String)))
                GridDetail.Columns(col).Title = pv_ds.Columns(col).Caption
                GridDetail.Columns(col).Width = 100
                GridDetail.Columns(col).HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
                GridDetail.Columns(col).CanBeSorted = True
            Next
            GridDetail.DataRows.Clear()
            GridDetail.BeginInit()
            Dim v_hadData As Boolean = False
            For row As Integer = 0 To pv_ds.Rows.Count - 1
                Dim v_xDataRow As Xceed.Grid.DataRow = GridDetail.DataRows.AddNew()
                v_hadData = False
                For Each v_xColumn As Xceed.Grid.Column In GridDetail.Columns
                    If Not IsDBNull(pv_ds.Rows(row)(v_xColumn.FieldName)) Then
                        v_hadData = True
                        v_xDataRow.Cells(v_xColumn.FieldName).Value = pv_ds.Rows(row)(v_xColumn.FieldName)
                    End If
                Next
                v_xDataRow.EndEdit()
                If Not v_hadData Then
                    GridDetail.DataRows.Remove(v_xDataRow)
                End If

            Next
            Dim v_frResultGrid = New Xceed.Grid.TextRow(String.Format(mv_ResourceManager.GetString("viewSummary"), GridDetail.DataRows.Count))
            v_frResultGrid.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
            v_frResultGrid.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic)
            GridDetail.FixedFooterRows.Clear()
            GridDetail.FixedFooterRows.Add(v_frResultGrid)

            Me.pnDetail.Controls.Clear()
            Me.pnDetail.Controls.Add(GridDetail)
            GridDetail.Dock = System.Windows.Forms.DockStyle.Fill
            GridDetail.EndInit()
            Me.pnDetail.Controls.Clear()
            Me.pnDetail.Controls.Add(GridDetail)
            GridDetail.Dock = System.Windows.Forms.DockStyle.Fill

            'btnWrite.Enabled = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub OnApprove(ByVal pv_grid As AppCore.GridEx)
        Dim v_ws As BDSDeliveryManagement
        Dim v_strMsgObj, v_strSQL, v_strValue, v_strFLDNAME, v_strTLTXCD, v_strTBLNAME, v_strDEFNAME, v_strFLDCD, v_strAutoid As String
        Dim v_strMODCODE, v_strObjMsg As String
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_hashTable As New Hashtable
        Dim mv_frmTransactScreen As frmTransact
        Dim v_strDefValue As String
        Try

            For i As Integer = 0 To pv_grid.DataRows.Count - 1
                If Not pv_grid.DataRows(i).Cells("STATUS").Value = "P" Then
                    Continue For
                End If

                v_strDefValue = String.Empty
                v_strAutoid = pv_grid.DataRows(i).Cells("AUTOID").Value
                With pv_grid.DataRows(i)
                    For Each v_xColumn As Xceed.Grid.Column In pv_grid.Columns
                        If v_hashTable.Contains(v_xColumn.FieldName) Then
                            v_strDefValue = v_strDefValue & String.Format("[{0}.{1}]", _
                                                                          v_hashTable(v_xColumn.FieldName), _
                                                                          .Cells(v_xColumn.FieldName).Value())
                        End If

                    Next

                End With
                'If v_strMODCODE <> "" And v_strTLTXCD <> "" Then
                mv_frmTransactScreen = New frmTransactMaster(Me.UserLanguage)
                mv_frmTransactScreen.ObjectName = "1503"
                mv_frmTransactScreen.ModuleCode = "ST"
                mv_frmTransactScreen.LocalObject = gc_IsNotLocalMsg
                mv_frmTransactScreen.BranchId = Me.BranchId
                mv_frmTransactScreen.TellerId = Me.TellerId
                mv_frmTransactScreen.IpAddress = Me.IpAddress
                mv_frmTransactScreen.WsName = Me.WsName
                mv_frmTransactScreen.BusDate = Me.BusDate
                mv_frmTransactScreen.TxDate = Me.BusDate

                mv_frmTransactScreen.DefaultValue = v_strDefValue
                mv_frmTransactScreen.AutoClosedWhenOK = True
                mv_frmTransactScreen.AutoSubmitWhenExecute = True
                mv_frmTransactScreen.AutoApprove = True
                mv_frmTransactScreen.ShowDialog()
                'mv_frmTransactScreen.OnSubmit()

                ' mv_frmTransactScreen.Dispose()

                'End If
            Next
        Catch ex As Exception
            LogError.Write("Error source: MSTP.frmUpdateSecInfo.OnSave.OnApprove" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            'MessageBox.Show("File dư liệu đầu vào không hợp lệ!!", gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            MessageBox.Show(mv_ResourceManager.GetString("File_data_invalid"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Protected Sub OnExport()
        Try
            Dim v_dlgSave As New SaveFileDialog
            Dim v_strTemp As String
            v_dlgSave.Filter = "Text files (*.txt)|*.txt|Excel files (*.xls)|*.xls|All files (*.*)|*.*"
            v_dlgSave.RestoreDirectory = True
            Dim v_res As DialogResult = v_dlgSave.ShowDialog(Me)

            If v_res = DialogResult.OK Then
                Dim v_strFileName As String = v_dlgSave.FileName
                If Mid(v_strFileName, Len(v_strFileName) - 3) <> ".xls" Then
                    Dim v_strData As String
                    Dim v_streamWriter As New StreamWriter(v_strFileName, False, System.Text.Encoding.Unicode)

                    If (GridDetail.DataRows.Count > 0) Then
                        'Write file's header
                        v_strData = String.Empty
                        For idx As Integer = 0 To GridDetail.Columns.Count - 1
                            If GridDetail.Columns(idx).Visible Then
                                v_strData &= GridDetail.Columns(idx).Title & vbTab
                            End If
                        Next
                        v_streamWriter.WriteLine(v_strData)

                        'Write data
                        For i As Integer = 0 To GridDetail.DataRows.Count - 1
                            v_strData = String.Empty

                            For j As Integer = 0 To GridDetail.DataRows(i).Cells.Count - 1
                                If GridDetail.Columns(j).Visible Then
                                    v_strTemp = "@" & CStr(GridDetail.DataRows(i).Cells(j).Value)
                                    v_strData &= v_strTemp & vbTab
                                End If
                            Next

                            'Write data to the file
                            v_streamWriter.WriteLine(v_strData)
                        Next
                    Else
                        MsgBox(mv_ResourceManager.GetString("frmSearch.NothingToExport"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                        Exit Sub
                    End If

                    'Close StreamWriter
                    v_streamWriter.Close()
                Else


                    'Chuyen doi cau hinh User Account Windows theo cau hinh cua Office
                    Dim oldCI As Globalization.CultureInfo
                    oldCI = System.Threading.Thread.CurrentThread.CurrentCulture
                    System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")


                    Dim objExcel As Excel.Application ' Excel object
                    Dim objWorkbook As Excel.Workbook 'Workbook object 
                    Dim objWorksheet As Excel.Worksheet 'Worksheet object 

                    objExcel = New Excel.Application
                    'Add a new workbook 
                    objWorkbook = objExcel.Workbooks.Add()

                    'Set the Wwrksheet object to the sheet in the workbook you want to use 
                    'Note: You can use an Index number as well as specifying the name of the sheet 
                    objWorksheet = CType(objWorkbook.Worksheets.Item("Sheet1"), Excel.Worksheet)

                    Dim varInt_StartRow As Integer
                    objWorkbook = objExcel.Workbooks.Open(v_strFileName)
                    objWorksheet = objWorkbook.Worksheets.Item("Sheet1")


                    varInt_StartRow = 0

                    If (GridDetail.DataRows.Count > 0) Then



                        Dim i, j As Integer
                        'Write header
                        For idx As Integer = 0 To GridDetail.Columns.Count - 1
                            If GridDetail.Columns(idx).Visible Then
                                'v_strData &= SearchGrid.Columns(idx).Title & vbTab
                                CType(objWorksheet.Cells(1, i + 1), Excel.Range).EntireColumn.NumberFormat = "@"
                                With objWorksheet.Range(objWorksheet.Cells(1, i + 1), objWorksheet.Cells(1, i + 1))
                                    .Value = CStr(GridDetail.Columns(idx).Title)
                                    .Font.Size = 12
                                    .Font.Name = "Times New Roman"
                                    .VerticalAlignment = Excel.Constants.xlTop
                                    .HorizontalAlignment = Excel.Constants.xlCenter
                                    .Select()
                                    i = i + 1
                                End With
                            End If
                        Next

                        'Write data
                        Dim v_strKeyFieldType, v_strFORMAT As String
                        For j = 0 To GridDetail.DataRows.Count - 1
                            i = 0
                            For idx As Integer = 0 To GridDetail.DataRows(j).Cells.Count - 1
                                If GridDetail.Columns(idx).Visible Then
                                    With objWorksheet.Range(objWorksheet.Cells(j + 2, i + 1), objWorksheet.Cells(j + 2, i + 1))
                                        If CStr(GridDetail.DataRows(j).Cells(idx).Value) = Nothing Then
                                            .Value = CStr(GridDetail.DataRows(j).Cells(idx).Value)
                                        Else
                                            '  v_strKeyFieldType = GetFIELDTYPE(CStr(GridDetail.DataRows(j).Cells(idx).AccessibleName), mv_strTableName, v_strFORMAT)
                                            If IsNumeric(CStr(GridDetail.DataRows(j).Cells(idx).Value)) And CStr(GridDetail.DataRows(j).Cells(idx).Value).Substring(0, 1) <> "0" Then
                                                .Value = CDbl(CStr(GridDetail.DataRows(j).Cells(idx).Value)).ToString("#,###")
                                            Else
                                                .Value = CStr(GridDetail.DataRows(j).Cells(idx).Value)
                                            End If
                                        End If
                                        .NumberFormat = "@"
                                    End With
                                    i = i + 1
                                End If
                            Next
                        Next

                        'Save workbook before closing 
                        objWorkbook.SaveAs(v_strFileName)

                    Else
                        MsgBox(mv_ResourceManager.GetString("frmSearch.NothingToExport"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                        Exit Sub
                    End If

                    'Close the workbook and Excel 
                    objWorkbook.Close(False, "", Nothing)
                    objWorkbook = Nothing
                    objExcel.Quit()
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(objExcel)
                    objExcel = Nothing

                    'Tra lai cau hinh User Account Windows theo mac dinh cua chuong trinh
                    System.Threading.Thread.CurrentThread.CurrentCulture = oldCI
                End If

            End If


            MsgBox(mv_ResourceManager.GetString("frmSearch.ExportSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)


            Exit Sub

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub ExportCSV()
        Try
            If Not GridDetail Is Nothing Then
                If GridDetail.DataRows.Count = 0 Then
                    MsgBox(mv_ResourceManager.GetString("nothingToExport"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    Exit Sub
                End If

                Dim v_dlgSave As New SaveFileDialog
                Dim v_strTemp As String
                v_dlgSave.Filter = "Text files (*.csv)|*.csv|Excel files (*.xls)|*.xls"
                v_dlgSave.RestoreDirectory = True
                Dim v_res As DialogResult = v_dlgSave.ShowDialog(Me)

                If v_res = DialogResult.OK Then
                    Dim v_strFileName As String = v_dlgSave.FileName
                    Dim v_prefixChar As String
                    'If Mid(v_strFileName, Len(v_strFileName) - 3) = ".xls" Then
                    '    v_prefixChar = ""
                    'Else
                    '    v_prefixChar = ""
                    'End If
                    'If Mid(v_strFileName, Len(v_strFileName) - 3) <> ".xls" Then
                    Dim v_strData As String
                    Dim v_streamWriter As New StreamWriter(v_strFileName, False, System.Text.Encoding.Unicode)

                    If (GridDetail.DataRows.Count > 0) Then
                        'Write file's header
                        v_strData = String.Empty
                        If lblIncludeHeader.Checked = True Then
                            For idx As Integer = 0 To GridDetail.Columns.Count - 1
                                If GridDetail.Columns(idx).Visible Then
                                    v_strData &= GridDetail.Columns(idx).Title & vbTab
                                End If
                            Next
                            v_streamWriter.WriteLine(v_strData)
                        End If
                        'Write data
                        For i As Integer = 0 To GridDetail.DataRows.Count - 1
                            v_strData = String.Empty

                            For j As Integer = 0 To GridDetail.DataRows(i).Cells.Count - 1
                                If GridDetail.Columns(j).Visible Then
                                    v_strTemp = v_prefixChar & CStr(GridDetail.DataRows(i).Cells(j).Value)
                                    v_strData &= v_strTemp & vbTab
                                End If
                            Next

                            'Write data to the file
                            v_streamWriter.WriteLine(v_strData)
                        Next
                    Else
                        MsgBox(mv_ResourceManager.GetString("NothingToExport"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                        Exit Sub
                    End If

                    'Close StreamWriter
                    v_streamWriter.Close()
                    MsgBox(mv_ResourceManager.GetString("ExportSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    '    Else

                    '        'Ghi file exce;
                    '        'chuyen doi cau hinh user account windows theo cau hinh cua office
                    '        Dim oldci As Globalization.CultureInfo
                    '        oldci = System.Threading.Thread.CurrentThread.CurrentCulture
                    '        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-us")


                    '        Dim objexcel As Excel.Application ' excel object
                    '        Dim objworkbook As Excel.Workbook 'workbook object 
                    '        Dim objworksheet As Excel.Worksheet 'worksheet object 

                    '        objexcel = New Excel.ApplicationClass
                    '        'add a new workbook 
                    '        objworkbook = objexcel.Workbooks.Add()

                    '        'set the wwrksheet object to the sheet in the workbook you want to use 
                    '        'note: you can use an index number as well as specifying the name of the sheet 
                    '        objworksheet = CType(objworkbook.Worksheets.Item("sheet1"), Excel.Worksheet)

                    '        Dim varint_startrow As Integer
                    '        If System.IO.File.Exists(v_strFileName) = True Then 'check to see if file exists
                    '            objworkbook = objexcel.Workbooks.Open(v_strFileName)
                    '            objworksheet = objworkbook.Worksheets.Item("sheet1")

                    '            'find last empty cell
                    '            varint_startrow = objworksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row
                    '        Else
                    '            varint_startrow = 0
                    '        End If
                    '        If (GridDetail.DataRows.Count > 0) Then

                    '            Dim i, j As Integer
                    '            'write header
                    '            For idx As Integer = 0 To GridDetail.Columns.Count - 1
                    '                If GridDetail.Columns(idx).Visible Then
                    '                    'v_strdata &= searchgrid.columns(idx).title & vbtab
                    '                    CType(objworksheet.Cells(1, i + 1), Excel.Range).EntireColumn.NumberFormat = "@"
                    '                    With objworksheet.Range(objworksheet.Cells(1, i + 1), objworksheet.Cells(1, i + 1))
                    '                        .Value = CStr(GridDetail.Columns(idx).Title)
                    '                        .Font.Size = 12
                    '                        .Font.Name = "times new roman"
                    '                        .VerticalAlignment = Excel.Constants.xlTop
                    '                        .HorizontalAlignment = Excel.Constants.xlCenter
                    '                        .Select()
                    '                        i = i + 1
                    '                    End With
                    '                End If
                    '            Next

                    '            'write data
                    '            For j = 0 To GridDetail.DataRows.Count - 1
                    '                i = 0
                    '                For idx As Integer = 0 To GridDetail.DataRows(j).Cells.Count - 1
                    '                    If GridDetail.Columns(idx).Visible Then
                    '                        With objworksheet.Range(objworksheet.Cells(j + 2, i + 1), objworksheet.Cells(j + 2, i + 1))
                    '                            .Value = CStr(GridDetail.DataRows(j).Cells(idx).Value)
                    '                            .NumberFormat = "@"
                    '                        End With
                    '                        i = i + 1
                    '                    End If
                    '                Next
                    '            Next

                    '            'save workbook before closing 
                    '            objworkbook.SaveAs(v_strFileName)

                    '        Else
                    '            MsgBox(mv_ResourceManager.GetString("frmsearch.nothingtoexport"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    '            Exit Sub
                    '        End If

                    '        'close the workbook and excel 
                    '        objworkbook.Close(False, "", Nothing)
                    '        objworkbook = Nothing
                    '        objexcel.Quit()
                    '        System.Runtime.InteropServices.Marshal.ReleaseComObject(objexcel)
                    '        objexcel = Nothing

                    '        'tra lai cau hinh user account windows theo mac dinh cua chuong trinh
                    '        System.Threading.Thread.CurrentThread.CurrentCulture = oldci
                    '    End If
                    '    MsgBox(mv_ResourceManager.GetString("ExportSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    'End If
                Else
                    MsgBox(mv_ResourceManager.GetString("nothingToExport"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    Exit Sub
                End If
            End If


        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub ExportCSVDE083()
        Try
            If Not GridDetail Is Nothing Then
                If GridDetail.DataRows.Count = 0 Then
                    MsgBox(mv_ResourceManager.GetString("nothingToExport"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    Exit Sub
                End If

                Dim v_dlgSave As New SaveFileDialog
                Dim v_strTemp As String
                v_dlgSave.Filter = "Text files (*.csv)|*.csv|Excel files (*.xls)|*.xls"
                v_dlgSave.RestoreDirectory = True
                Dim v_res As DialogResult = v_dlgSave.ShowDialog(Me)

                If v_res = DialogResult.OK Then
                    Dim v_strFileName As String = v_dlgSave.FileName
                    Dim v_prefixChar As String
                    Dim v_strData As String
                    Dim v_streamWriter As New StreamWriter(v_strFileName, False, System.Text.Encoding.Unicode)

                    If (GridDetail.DataRows.Count > 0) Then
                        'Write file's header
                        v_strData = String.Empty
                        If lblIncludeHeader.Checked = True Then
                            For idx As Integer = 0 To GridDetail.Columns.Count - 1
                                If GridDetail.Columns(idx).Visible Then
                                    v_strData &= GridDetail.Columns(idx).Title & ";"
                                End If
                            Next
                            v_streamWriter.WriteLine(v_strData)
                        End If
                        'Write data
                        For i As Integer = 0 To GridDetail.DataRows.Count - 1
                            v_strData = String.Empty

                            For j As Integer = 0 To GridDetail.DataRows(i).Cells.Count - 1
                                If GridDetail.Columns(j).Visible Then
                                    v_strTemp = v_prefixChar & CStr(GridDetail.DataRows(i).Cells(j).Value)
                                    v_strData &= v_strTemp & ";"
                                End If
                            Next

                            'Write data to the file
                            v_streamWriter.WriteLine(v_strData)
                        Next
                    Else
                        MsgBox(mv_ResourceManager.GetString("NothingToExport"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                        Exit Sub
                    End If

                    'Close StreamWriter
                    v_streamWriter.Close()
                    MsgBox(mv_ResourceManager.GetString("ExportSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                Else
                    MsgBox(mv_ResourceManager.GetString("nothingToExport"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    Exit Sub
                End If
            End If


        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub
#End Region

    Friend WithEvents GridDetail As GridEx
    Friend WithEvents tblDeailAll As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel6 As System.Windows.Forms.TableLayoutPanel


    Private Sub btnExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExport.Click
        If cboReportName.Text = "DE083" Then
            ExportCSVDE083()
        Else
            ExportCSV()
        End If
    End Sub

    Private Sub btnExecute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExecute.Click
        Try
            'Select Case mv_currFunction
            '    Case c_fnCOMPARE
            '        ViewCompare()
            '    Case c_fnVIEWCSV
            '        ViewCSVFile()
            '    Case c_fnQUERY
            '        getHisCompare()
            'End Select
            ViewCSVFile()
            'ViewCompare()
            'mv_strCurrFileName = cboFileName.SelectedText.ToString
            'ViewCSVFile()
        Catch ex As Exception
            LogError.Write("Error source: @FDS.frmCSVCompare.btnView_Click" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
        End Try
    End Sub

    Private Sub btnApprv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApprv.Click
        Try
            ApprvRouter()
        Catch ex As Exception
            LogError.Write("Error source: MSTP.frmUpdateSecInfo.OnSave" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            'MessageBox.Show("File dư liệu đầu vào không hợp lệ!!", gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            MessageBox.Show(mv_ResourceManager.GetString("File_data_invalid"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Try
            ExportReport()
        Catch ex As Exception
            LogError.Write("Error source: MSTP.frmCSVCompare.btnReport_Click" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(mv_ResourceManager.GetString("File_data_invalid"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ExportReport()
        Dim v_rptDocument As New ReportDocument
        Dim v_tbl As DataTable
        Dim v_strFileName, v_strFolderName, v_strReportName, v_strFolderTemp As String, v_blnFileExists As Boolean = False

        Try
            'check data
            If GridDetail Is Nothing Or (Not GridDetail Is Nothing AndAlso GridDetail.DataRows.Count) = 0 Then
                MessageBox.Show(mv_ResourceManager.GetString("NoResultData"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            'build dataset
            Dim v_ds As DataSet
            v_ds = buildDataSetRptData()


            v_strReportName = cboReportName.SelectedValue
            v_strFileName = v_strReportName & ".rpt"
            v_strFolderName = GetDirectoryName(ExecutablePath) & "\Reports\"
            v_strFolderTemp = v_strFolderName & "TEMP\"

            Dim v_dirInfo As New DirectoryInfo(v_strFolderName)
            Dim v_fileInfo() As FileInfo = v_dirInfo.GetFiles("*.rpt")
            Dim v_file As FileInfo

            ' Check if report template is exists
            For Each v_file In v_fileInfo
                If v_file.Name = v_strFileName Then
                    v_blnFileExists = True
                    Exit For
                End If
            Next
            If Not v_blnFileExists Then
                v_ds.WriteXml(GetReportXmlFileName(v_strFolderName, v_strReportName), XmlWriteMode.WriteSchema)
                MessageBox.Show(mv_ResourceManager.GetString("FileNotExists"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            v_rptDocument.Load(v_strFolderName & v_strFileName, CrystalDecisions.Shared.OpenReportMethod.OpenReportByTempCopy)
            If v_rptDocument.IsLoaded Then
                v_rptDocument.SetDataSource(v_ds)

                'load fomulafields
                Dim v_arrFomularName(), v_arrFomulaValue() As String
                If mv_blnADHOCFORMULAR Then
                    getFormularFieldsFromDB(cboFileName.Text, cbCompareType.SelectedValue.ToString.ToUpper, v_arrFomularName, v_arrFomulaValue)
                End If
                Dim v_crFFieldDefinitions As FormulaFieldDefinitions
                Dim v_crFFieldDefinition As FormulaFieldDefinition
                Dim v_strFormulaName, v_strFormulaValue As String
                v_crFFieldDefinitions = v_rptDocument.DataDefinition.FormulaFields()
                For i = 0 To v_crFFieldDefinitions.Count - 1
                    v_crFFieldDefinition = v_crFFieldDefinitions.Item(i)
                    v_strFormulaName = v_crFFieldDefinition.Name
                    Select Case v_strFormulaName.ToUpper
                        Case "F_CSVFILENAME"
                            v_crFFieldDefinition.Text = "'" & cboFileName.Text & "'"
                        Case Else
                            If Not v_arrFomularName Is Nothing AndAlso v_arrFomularName.Length > 0 Then
                                For j As Integer = 0 To v_arrFomularName.Length - 1
                                    If v_arrFomularName(j) = v_strFolderName.ToUpper Then
                                        v_crFFieldDefinition.Text = "'" & v_arrFomulaValue(j) & "'"
                                        Exit For
                                    End If
                                Next
                            End If
                    End Select
                Next


                v_rptDocument.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.CrystalReport, v_strFolderTemp & GetReportFileName(v_strReportName))
                MessageBox.Show(mv_ResourceManager.GetString("CreateSucessfully"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Dim v_frm As New frmReportView
                Dim v_Path As String = Environment.CurrentDirectory
                v_frm.RptFileName = v_strFolderTemp & GetReportFileName(v_strReportName)
                v_frm.RptName = v_strReportName
                v_frm.ShowDialog()
                Environment.CurrentDirectory = v_Path
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Function buildDataSetRptData() As DataSet
        Try
            Dim v_tbl As DataTable = New DataTable("RptData")
            For i As Integer = 0 To GridDetail.Columns.Count - 1
                v_tbl.Columns.Add(GridDetail.Columns(i).FieldName)
            Next
            For i As Integer = 0 To GridDetail.DataRows.Count - 1
                v_tbl.Rows.Add()
                For j As Integer = 0 To GridDetail.Columns.Count - 1
                    v_tbl.Rows(i)(j) = GridDetail.DataRows(i).Cells(j).Value
                Next
            Next
            Dim v_ds As New DataSet
            v_ds.Tables.Add(v_tbl)
            Return v_ds
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Sub getFormularFieldsFromDB(ByVal p_fileName As String, _
                                        ByVal p_compareType As String, _
                                        ByRef p_arrFormularName() As String, _
                                        ByRef p_arrFormularValue() As String)
        Dim v_ws As BDSDeliveryManagement
        Dim v_xmlDocument As New XmlDocumentEx
        Dim v_nodeList As Xml.XmlNodeList
        Try
            v_ws = New BDSDeliveryManagement
            Dim v_strObjMsg, v_strClause, v_strValue, v_strFLDNAME As String
            v_strClause = "p_fileName!" & p_fileName & "!VARCHAR!1000^p_reportType!" & p_compareType & "!VARCHAR!1000"
            v_strObjMsg = BuildXMLObjMsg("", Me.BranchId, "", Me.TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, Me.ObjectName, gc_ActionInquiry, mv_strADHOCFORMULAR_FNC, v_strClause, "", "", "", "", "", Me.IpAddress, gc_CommandProcedure)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            For i As Integer = 0 To v_nodeList.Count - 1
                ReDim p_arrFormularName(v_nodeList.Item(i).ChildNodes.Count - 1)
                ReDim p_arrFormularValue(v_nodeList.Item(i).ChildNodes.Count - 1)
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        p_arrFormularName(i) = "F_" & v_strFLDNAME.ToUpper
                        p_arrFormularValue(i) = v_strValue
                    End With
                Next
                Exit For 'get only first row
            Next
        Catch ex As Exception
            LogError.Write("Error source: MSTP.frmCSVCompare.getFormularFieldsFromDB" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
        End Try
    End Sub
    Private Function GetReportFileNameStandard(ByVal pv_strCMDID As String) As String
        Return pv_strCMDID & TellerId & ".prnx"
    End Function
    Private Function GetReportFileName(ByVal pv_strCMDID As String) As String
        Return pv_strCMDID & TellerId & ".rpt"
    End Function
    Private Function GetReportXmlFileName(ByVal pv_strFolderName As String, _
                                           ByVal pv_strFileName As String)
        Return pv_strFolderName & pv_strFileName & ".xml"
    End Function

    Private Function GetReportDateCreated(ByVal pv_strReportFileName As String, _
                                          ByVal ReportTempDirectory As String) As Date
        Try
            Dim v_dirInfo As New DirectoryInfo(ReportTempDirectory)
            Dim v_fileInfo As FileInfo
            Dim v_arrReportFiles() As FileInfo = v_dirInfo.GetFiles(pv_strReportFileName)
            For Each v_fileInfo In v_arrReportFiles
                If v_fileInfo.Name = pv_strReportFileName Then
                    'File ton tai
                    Return v_fileInfo.LastWriteTime
                End If
            Next

            'Xu ly doc file tu template
            pv_strReportFileName = pv_strReportFileName.Replace(".rpt", ".prnx")
            v_arrReportFiles = v_dirInfo.GetFiles(pv_strReportFileName)
            For Each v_fileInfo In v_arrReportFiles
                If v_fileInfo.Name = pv_strReportFileName Then
                    'File ton tai
                    Return v_fileInfo.LastWriteTime
                End If
            Next

            Return Nothing
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function

    Private mv_strFILEPATH As String = ""
    Private mv_strSHEETNAME As String = "SHEET1"
    Private mv_intROWTITLE As String = "1"
    Private mv_strEXTENTION As String = ".xls"
    Private mv_intPAGE As String = "0"
    Private mv_strSaveTableName As String
    Private mv_strSaveTableName_hist As String
    Private mv_strOVRRQD As String
    Private mv_strRPTID As String

    Private Sub GetFileInfo(ByVal pv_strFile As String)
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_strValue, v_strFLDNAME, v_strTEXT As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strCmdSQL As String, v_strObjMsg As String
        Try
            v_strCmdSQL = "SELECT * FROM filemaster WHERE filecode='" & pv_strFile & "'AND eori<>'C'"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerID, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Count - 1
                v_strTEXT = String.Empty
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = Trim(.InnerText.ToString)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "FILEPATH"
                                mv_strFILEPATH = v_strValue
                            Case "SHEETNAME"
                                mv_strSHEETNAME = v_strValue
                            Case "ROWTITLE"
                                mv_intROWTITLE = CInt(v_strValue)
                            Case "EXTENTION"
                                mv_strEXTENTION = v_strValue
                            Case "PAGE"
                                mv_intPAGE = CInt(v_strValue)
                            Case "TABLENAME"
                                mv_strSaveTableName = v_strValue
                            Case "TABLENAME_HIST"
                                mv_strSaveTableName_hist = v_strValue
                            Case "OVRRQD"
                                mv_strOVRRQD = v_strValue
                            Case "MODCODE"
                                mv_strMODCODE = v_strValue
                            Case "RPTID"
                                mv_strRPTID = v_strValue
                        End Select
                    End With
                Next
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LoadSaveData(ByVal mv_strSaveTableName As String, Optional ByVal mv_strSaveTableName_hist As String = "_", Optional ByVal pv_strFileID As String = "%")
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_strValue, v_strFLDNAME, v_strFLDTYPE, v_strTEXT As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strCmdSQL As String, v_strObjMsg As String
        Try
            v_strCmdSQL = "SELECT * FROM " & mv_strSaveTableName & " where fileid like '" & pv_strFileID & "'"

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerID, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            If v_nodeList.Count > 0 Then
                'Lay tieu de grid
                ResultGrid = New GridEx
                Dim v_cmrODBuyGrid As New Xceed.Grid.ColumnManagerRow
                v_cmrODBuyGrid.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
                v_cmrODBuyGrid.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
                'ODBuyGrid.FixedHeaderRows.Add(v_grODBuyGrid)
                ResultGrid.FixedHeaderRows.Add(v_cmrODBuyGrid)


                For j As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                    v_strFLDNAME = CStr(CType(v_nodeList.Item(0).ChildNodes(j).Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strFLDTYPE = CStr(CType(v_nodeList.Item(0).ChildNodes(j).Attributes.GetNamedItem("fldtype"), Xml.XmlAttribute).Value)
                    Select Case v_strFLDTYPE
                        Case "System.String"
                            ResultGrid.Columns.Add(New Xceed.Grid.Column(v_strFLDNAME, GetType(System.String)))
                        Case "System.DateTime"
                            ResultGrid.Columns.Add(New Xceed.Grid.Column(v_strFLDNAME, GetType(System.String)))
                        Case Else
                            ResultGrid.Columns.Add(New Xceed.Grid.Column(v_strFLDNAME, GetType(System.Double)))
                    End Select
                    ResultGrid.Columns(v_strFLDNAME).Title = v_strFLDNAME

                Next

                'Fill du lieu vao Grid
                For i As Integer = 0 To v_nodeList.Count - 1
                    v_strTEXT = String.Empty
                    Dim v_xDataRow As Xceed.Grid.DataRow = ResultGrid.DataRows.AddNew()
                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            v_strValue = Trim(.InnerText.ToString)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            v_strFLDTYPE = CStr(CType(.Attributes.GetNamedItem("fldtype"), Xml.XmlAttribute).Value)
                            Select Case v_strFLDTYPE
                                Case "System.String"
                                    v_xDataRow.Cells(v_strFLDNAME).Value = IIf(v_strValue Is DBNull.Value, "", CStr(v_strValue))
                                Case "System.DateTime"
                                    v_xDataRow.Cells(v_strFLDNAME).Value = IIf(v_strValue Is DBNull.Value, "", CStr(v_strValue))
                                Case Else
                                    If v_strValue.Length = 0 Or v_strValue Is vbNullString Then
                                        v_xDataRow.Cells(v_strFLDNAME).Value = 0
                                    Else
                                        v_xDataRow.Cells(v_strFLDNAME).Value = IIf(v_strValue Is DBNull.Value, 0, CDbl(v_strValue))
                                    End If

                            End Select

                        End With
                    Next
                    v_xDataRow.EndEdit()
                Next

                Dim v_frResultGrid = New Xceed.Grid.TextRow(mv_ResourceManager.GetString("RESULTSYN") & v_nodeList.Count & mv_ResourceManager.GetString("ROW"))
                v_frResultGrid.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
                v_frResultGrid.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic)
                ResultGrid.FixedFooterRows.Clear()
                ResultGrid.FixedFooterRows.Add(v_frResultGrid)

                Me.pnDetail.Controls.Clear()
                Me.pnDetail.Controls.Add(ResultGrid)
                ResultGrid.Dock = System.Windows.Forms.DockStyle.Fill

            Else
                'THong bao khong co du lieu duoc Import
                MessageBox.Show(mv_ResourceManager.GetString("ERR_CANTWRITE"))
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & ". LoadSaveData" & vbNewLine _
                         & "Error code: v_strCmdSQL = " & v_strCmdSQL & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            Throw ex
        End Try
    End Sub

    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        If Not GridDetail Is Nothing Then
            If GridDetail.DataRows.Count = 0 Then
                MsgBox(mv_ResourceManager.GetString("nothingToExport"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                Exit Sub
            End If
            btnImport.Enabled = False

            Dim v_ws As BDSDeliveryManagement
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strTEXT, v_strValue, v_strFLDNAME As String
            Dim v_strSQL As String
            Dim v_strObjMsg As String
            Dim mv_strFileCode As String

            v_ws = New BDSDeliveryManagement
            v_strSQL = String.Format("SELECT VSDREPORTID, IMPORTID FROM VSD_MAP_IMPORT WHERE VSDREPORTID = '{0}'", cboReportName.SelectedValue.ToString())
            v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Count - 1
                v_strTEXT = String.Empty
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = Trim(.InnerText.ToString)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME).ToUpper
                            Case "IMPORTID"
                                mv_strFileCode = v_strValue.Trim
                        End Select
                    End With
                Next
            Next

            If Not mv_strFileCode Is Nothing Then
                GetFileInfo(mv_strFileCode)

                Cursor.Current = Cursors.WaitCursor
                Dim v_strFunctionName As String = "ImportXMLFileToDB"
                Dim v_strClause, v_strErrorSource, v_strErrorMessage As String
                Dim v_grid As New AppCore.GridEx

                v_grid = GridDetail

                mv_strObjname = "SA.READFILE"
                If (MessageBox.Show(mv_ResourceManager.GetString("MSG_CONFIRM"), gc_ApplicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                    Dim v_strBuffer As New System.Text.StringBuilder
                    'Gan title
                    For Each v_xColumn As Xceed.Grid.Column In v_grid.Columns
                        If Not CType(v_xColumn, Xceed.Grid.Column).Title Is DBNull.Value Then
                            v_strValue = CType(v_xColumn, Xceed.Grid.Column).Title
                        Else
                            v_strValue = ""
                        End If
                        v_strBuffer.Append("" & v_strValue & "~")
                    Next
                    v_strBuffer.Append("|")
                    'Gan noi dung
                    For i As Integer = 0 To v_grid.DataRows.Count - 1
                        With v_grid.DataRows(i)
                            For Each v_xColumn As Xceed.Grid.Column In v_grid.Columns

                                If Not .Cells(v_xColumn.FieldName).Value() Is DBNull.Value Then
                                    v_strValue = CStr(.Cells(v_xColumn.FieldName).Value)
                                    If v_strValue Is Nothing Then
                                        v_strValue = ""
                                    End If
                                    If v_strValue.Contains("'") Then
                                        v_strValue = v_strValue.Replace("'", "''")
                                    End If
                                Else
                                    v_strValue = ""
                                End If
                                v_strBuffer.Append("" & v_strValue & "~")
                            Next
                            v_strBuffer.Append("|")
                        End With
                    Next
                    v_strClause = v_strBuffer.ToString
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, mv_strObjname, _
                            gc_ActionAdhoc, , v_strClause, v_strFunctionName, , , mv_strFileCode, IIf(False, "Y", "N"))
                    Dim v_lngError As Long = v_ws.Message(v_strObjMsg)

                    If v_lngError <> ERR_SYSTEM_OK Then
                        'Thông báo lỗi
                        GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                        Cursor.Current = Cursors.Default
                        MessageBox.Show(v_strErrorMessage, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If

                    Dim pv_xmlDocument As New Xml.XmlDocument
                    Dim v_strFeedBackMessage, v_strFeedBackMessageVN As String
                    pv_xmlDocument.LoadXml(v_strObjMsg)
                    v_strFeedBackMessageVN = pv_xmlDocument.DocumentElement.Attributes.GetNamedItem(gc_AtributeRESERVER).Value

                    Dim v_strFileId As String
                    v_strFileId = pv_xmlDocument.DocumentElement.Attributes.GetNamedItem(gc_AtributeAUTOID).Value

                    Dim str_replace As String = "Tổng số bản ghi"
                    Dim str_replace_EN As String = "Total records"
                    If Me.UserLanguage = "VN" Then
                        v_strFeedBackMessage = v_strFeedBackMessageVN
                    Else
                        v_strFeedBackMessage = Replace(v_strFeedBackMessageVN, str_replace, str_replace_EN)
                    End If

                    pv_xmlDocument = Nothing
                    Cursor.Current = Cursors.Default
                    'check error here
                    If v_strFeedBackMessage.Trim.Length = 0 Then
                        MessageBox.Show(mv_ResourceManager.GetString("MSG_SUCCESS"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show(mv_ResourceManager.GetString("MSG_SUCCESS") & ControlChars.CrLf & v_strFeedBackMessage, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    'LoadSaveData(mv_strSaveTableName, mv_strSaveTableName_hist, v_strFileId)
                End If
            End If
            btnImport.Enabled = True
        End If
    End Sub
End Class