Imports System.Windows.Forms
Imports Xceed.SmartUI.Controls
Imports CommonLibrary
Imports System.Collections
Imports System.IO


Public Class frmReceiverData
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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblCaption As System.Windows.Forms.Label
    Friend WithEvents grbSearchResult As System.Windows.Forms.GroupBox
    Friend WithEvents pnlSearchResult As System.Windows.Forms.Panel
    'Friend WithEvents cboFileType As System.Windows.Forms.ComboBox
    Friend WithEvents grbSources As System.Windows.Forms.GroupBox
    Friend WithEvents radioFiles As System.Windows.Forms.RadioButton
    Friend WithEvents radioQuoteSvr As System.Windows.Forms.RadioButton
    Friend WithEvents grbButton As System.Windows.Forms.GroupBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnLoadData As System.Windows.Forms.Button
    Friend WithEvents txtServerAddress As System.Windows.Forms.TextBox
    Friend WithEvents grbFiles As System.Windows.Forms.GroupBox
    Friend WithEvents grbQuoteSvr As System.Windows.Forms.GroupBox
    Friend WithEvents btnBrowser As System.Windows.Forms.Button
    Friend WithEvents txtFromFile As System.Windows.Forms.TextBox
    Friend WithEvents lblFromFile As System.Windows.Forms.Label
    Friend WithEvents lblServerAddress As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblCaption = New System.Windows.Forms.Label
        Me.grbSearchResult = New System.Windows.Forms.GroupBox
        Me.pnlSearchResult = New System.Windows.Forms.Panel
        Me.grbSources = New System.Windows.Forms.GroupBox
        Me.radioFiles = New System.Windows.Forms.RadioButton
        Me.radioQuoteSvr = New System.Windows.Forms.RadioButton
        Me.grbButton = New System.Windows.Forms.GroupBox
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnLoadData = New System.Windows.Forms.Button
        Me.txtServerAddress = New System.Windows.Forms.TextBox
        Me.grbFiles = New System.Windows.Forms.GroupBox
        Me.lblFromFile = New System.Windows.Forms.Label
        Me.txtFromFile = New System.Windows.Forms.TextBox
        Me.btnBrowser = New System.Windows.Forms.Button
        Me.grbQuoteSvr = New System.Windows.Forms.GroupBox
        Me.lblServerAddress = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.grbSearchResult.SuspendLayout()
        Me.grbSources.SuspendLayout()
        Me.grbButton.SuspendLayout()
        Me.grbFiles.SuspendLayout()
        Me.grbQuoteSvr.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.Controls.Add(Me.lblCaption)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(794, 50)
        Me.Panel1.TabIndex = 22
        '
        'lblCaption
        '
        Me.lblCaption.AutoSize = True
        Me.lblCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaption.Location = New System.Drawing.Point(16, 16)
        Me.lblCaption.Name = "lblCaption"
        Me.lblCaption.Size = New System.Drawing.Size(63, 13)
        Me.lblCaption.TabIndex = 0
        Me.lblCaption.Tag = "lblCaption"
        Me.lblCaption.Text = "lblCaption"
        '
        'grbSearchResult
        '
        Me.grbSearchResult.Controls.Add(Me.pnlSearchResult)
        Me.grbSearchResult.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbSearchResult.Location = New System.Drawing.Point(8, 136)
        Me.grbSearchResult.Name = "grbSearchResult"
        Me.grbSearchResult.Size = New System.Drawing.Size(776, 360)
        Me.grbSearchResult.TabIndex = 24
        Me.grbSearchResult.TabStop = False
        Me.grbSearchResult.Tag = "grbSearchResult"
        Me.grbSearchResult.Text = "grbSearchResult"
        '
        'pnlSearchResult
        '
        Me.pnlSearchResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlSearchResult.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSearchResult.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlSearchResult.Location = New System.Drawing.Point(3, 17)
        Me.pnlSearchResult.Name = "pnlSearchResult"
        Me.pnlSearchResult.Size = New System.Drawing.Size(770, 340)
        Me.pnlSearchResult.TabIndex = 0
        '
        'grbSources
        '
        Me.grbSources.Controls.Add(Me.radioFiles)
        Me.grbSources.Controls.Add(Me.radioQuoteSvr)
        Me.grbSources.Location = New System.Drawing.Point(8, 64)
        Me.grbSources.Name = "grbSources"
        Me.grbSources.Size = New System.Drawing.Size(144, 64)
        Me.grbSources.TabIndex = 27
        Me.grbSources.TabStop = False
        Me.grbSources.Tag = "grbSources"
        Me.grbSources.Text = "grbSources"
        '
        'radioFiles
        '
        Me.radioFiles.Location = New System.Drawing.Point(8, 40)
        Me.radioFiles.Name = "radioFiles"
        Me.radioFiles.Size = New System.Drawing.Size(128, 21)
        Me.radioFiles.TabIndex = 1
        Me.radioFiles.Tag = "radioFiles"
        Me.radioFiles.Text = "radioFiles"
        '
        'radioQuoteSvr
        '
        Me.radioQuoteSvr.Location = New System.Drawing.Point(8, 16)
        Me.radioQuoteSvr.Name = "radioQuoteSvr"
        Me.radioQuoteSvr.Size = New System.Drawing.Size(128, 21)
        Me.radioQuoteSvr.TabIndex = 0
        Me.radioQuoteSvr.Tag = "radioQuoteSvr"
        Me.radioQuoteSvr.Text = "radioQuoteSvr"
        '
        'grbButton
        '
        Me.grbButton.Controls.Add(Me.btnSave)
        Me.grbButton.Controls.Add(Me.btnCancel)
        Me.grbButton.Controls.Add(Me.btnLoadData)
        Me.grbButton.Location = New System.Drawing.Point(8, 496)
        Me.grbButton.Name = "grbButton"
        Me.grbButton.Size = New System.Drawing.Size(776, 45)
        Me.grbButton.TabIndex = 25
        Me.grbButton.TabStop = False
        Me.grbButton.Tag = "grbButton"
        Me.grbButton.Text = "grbButton"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(616, 16)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 26
        Me.btnSave.Tag = "btnSave"
        Me.btnSave.Text = "btnSave"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(696, 16)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 27
        Me.btnCancel.Tag = "btnCancel"
        Me.btnCancel.Text = "btnCancel"
        '
        'btnLoadData
        '
        Me.btnLoadData.Location = New System.Drawing.Point(536, 16)
        Me.btnLoadData.Name = "btnLoadData"
        Me.btnLoadData.Size = New System.Drawing.Size(75, 23)
        Me.btnLoadData.TabIndex = 25
        Me.btnLoadData.Tag = "btnLoadData"
        Me.btnLoadData.Text = "btnLoadData"
        '
        'txtServerAddress
        '
        Me.txtServerAddress.Location = New System.Drawing.Point(8, 35)
        Me.txtServerAddress.Name = "txtServerAddress"
        Me.txtServerAddress.Size = New System.Drawing.Size(600, 20)
        Me.txtServerAddress.TabIndex = 1
        Me.txtServerAddress.Tag = "txtServerAddress"
        Me.txtServerAddress.Text = "txtServerAddress"
        '
        'grbFiles
        '
        Me.grbFiles.Controls.Add(Me.lblFromFile)
        Me.grbFiles.Controls.Add(Me.txtFromFile)
        Me.grbFiles.Controls.Add(Me.btnBrowser)
        Me.grbFiles.Location = New System.Drawing.Point(160, 64)
        Me.grbFiles.Name = "grbFiles"
        Me.grbFiles.Size = New System.Drawing.Size(624, 64)
        Me.grbFiles.TabIndex = 1
        Me.grbFiles.TabStop = False
        Me.grbFiles.Tag = "grbFiles"
        Me.grbFiles.Text = "grbFiles"
        '
        'lblFromFile
        '
        Me.lblFromFile.AutoSize = True
        Me.lblFromFile.Location = New System.Drawing.Point(8, 16)
        Me.lblFromFile.Name = "lblFromFile"
        Me.lblFromFile.Size = New System.Drawing.Size(56, 13)
        Me.lblFromFile.TabIndex = 2
        Me.lblFromFile.Tag = "lblFromFile"
        Me.lblFromFile.Text = "lblFromFile"
        '
        'txtFromFile
        '
        Me.txtFromFile.Location = New System.Drawing.Point(8, 35)
        Me.txtFromFile.Name = "txtFromFile"
        Me.txtFromFile.Size = New System.Drawing.Size(568, 20)
        Me.txtFromFile.TabIndex = 1
        Me.txtFromFile.Text = "txtFromFile"
        '
        'btnBrowser
        '
        Me.btnBrowser.Location = New System.Drawing.Point(584, 32)
        Me.btnBrowser.Name = "btnBrowser"
        Me.btnBrowser.Size = New System.Drawing.Size(32, 23)
        Me.btnBrowser.TabIndex = 1
        Me.btnBrowser.Tag = "btnBrowser"
        '
        'grbQuoteSvr
        '
        Me.grbQuoteSvr.Controls.Add(Me.lblServerAddress)
        Me.grbQuoteSvr.Controls.Add(Me.txtServerAddress)
        Me.grbQuoteSvr.Location = New System.Drawing.Point(160, 64)
        Me.grbQuoteSvr.Name = "grbQuoteSvr"
        Me.grbQuoteSvr.Size = New System.Drawing.Size(624, 64)
        Me.grbQuoteSvr.TabIndex = 1
        Me.grbQuoteSvr.TabStop = False
        Me.grbQuoteSvr.Tag = "grbQuoteSvr"
        Me.grbQuoteSvr.Text = "grbQuoteSvr"
        '
        'lblServerAddress
        '
        Me.lblServerAddress.AutoSize = True
        Me.lblServerAddress.Location = New System.Drawing.Point(8, 16)
        Me.lblServerAddress.Name = "lblServerAddress"
        Me.lblServerAddress.Size = New System.Drawing.Size(86, 13)
        Me.lblServerAddress.TabIndex = 2
        Me.lblServerAddress.Tag = "lblServerAddress"
        Me.lblServerAddress.Text = "lblServerAddress"
        '
        'frmReceiverData
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(794, 550)
        Me.Controls.Add(Me.grbSources)
        Me.Controls.Add(Me.grbButton)
        Me.Controls.Add(Me.grbSearchResult)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.grbQuoteSvr)
        Me.Controls.Add(Me.grbFiles)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmReceiverData"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "frmReceiverData"
        Me.Text = "frmReceiverData"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.grbSearchResult.ResumeLayout(False)
        Me.grbSources.ResumeLayout(False)
        Me.grbButton.ResumeLayout(False)
        Me.grbFiles.ResumeLayout(False)
        Me.grbFiles.PerformLayout()
        Me.grbQuoteSvr.ResumeLayout(False)
        Me.grbQuoteSvr.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Property"
    Const c_ResourceManager = "AppCore.frmReceiverData-"
    Private mv_strFileName As String
    Private mv_strTableName As String
    Private mv_ResourceManager As Resources.ResourceManager
    Public SearchGrid As GridEx
    Private mv_strModuleCode As String
    Private mv_strObjName As String
    Private mv_strLanguage As String
    Private mv_strIsLocalSearch As String
    Private mv_strCaption As String
    Private mv_strEnCaption As String
    Private mv_strAuthCode As String

    Private mv_strBusDate As String
    Public Property BusDate() As String
        Get
            Return mv_strBusDate
        End Get
        Set(ByVal Value As String)
            mv_strBusDate = Value

        End Set
    End Property
    

    Public Property AuthCode() As String
        Get
            Return mv_strAuthCode
        End Get
        Set(ByVal Value As String)
            mv_strAuthCode = Value
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
    Public ReadOnly Property ObjectName() As String
        Get
            Return mv_strObjName
        End Get
    End Property
    Public ReadOnly Property ResourceManager() As Resources.ResourceManager
        Get
            Return mv_ResourceManager
        End Get
    End Property

    Public Property IsLocalSearch() As String
        Get
            Return mv_strIsLocalSearch
        End Get
        Set(ByVal Value As String)
            mv_strIsLocalSearch = Value
        End Set
    End Property

    Public Property ModuleCode() As String
        Get
            Return mv_strModuleCode
        End Get
        Set(ByVal Value As String)
            mv_strModuleCode = Value
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
#End Region

    Private c_SYS_STRING_TYPE As String = "System.String"
    Private mv_srcFileName As String
    Private mv_strCmdSqlInsert As String
    Private mv_intFileTypeFlag As Integer
    Private mv_HOSTC_FLOORCODE As String = "10"

    Const c_RESOURCE_MANAGER = "_DIRECT.frmTradingResult-"
    Const c_TRADE_UNIT_DEFAULT = "1"
    Const c_FILE_FORMAT_XML = ".xml"
    Const c_FILE_FORMAT_TEXT = ".txt"
    Const c_TRADEPLACE_HOSTC = "001"
    Const c_TRADEPLACE_HASTC = "002"


    Const c_FILE_ASTDL = "astdl"
    Const c_FILE_ASTPT = "astpt"

    Private mv_strDBLinkName As String
    Private mv_strDBLinkDesc As String
    Private mv_strReceiverData As String


#Region " Form methods "
    Protected Overridable Function InitDialog()

        AddHandler radioQuoteSvr.CheckedChanged, AddressOf RadioButton_CheckedChanged
        AddHandler radioFiles.CheckedChanged, AddressOf RadioButton_CheckedChanged

        AddHandler btnSave.Click, AddressOf Button_Click
        AddHandler btnCancel.Click, AddressOf Button_Click
        AddHandler btnBrowser.Click, AddressOf Button_Click
        AddHandler btnLoadData.Click, AddressOf Button_Click

        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        LoadResource(Me)

        'DoResizeForm()

        SearchGrid = New GridEx(mv_strTableName, c_ResourceManager & UserLanguage)
        Dim v_coloum As New Xceed.Grid.Column
        v_coloum = SearchGrid.Columns("__TICK")
        SearchGrid.Columns.Remove(v_coloum)
        Me.pnlSearchResult.Controls.Add(SearchGrid)
        SearchGrid.Dock = Windows.Forms.DockStyle.Fill
        Me.txtFromFile.Text = String.Empty

        LoadUserInterface(Me)
        LoadTradingResultGrid()
        radioQuoteSvr.Checked = True

        SetupServerParameter()
        Me.txtServerAddress.Text = mv_strDBLinkDesc
        Me.txtServerAddress.Enabled = False

    End Function

    Private Sub SetupServerParameter()
        Dim v_strSQL As String = "SELECT VARVALUE DBLINK ,VARDESC DBDESC FROM SYSVAR WHERE VARNAME='DBLINK_TO_QUOTE_SERVER'"
        Dim v_strMsgObj As String = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SE_SBSECURITIES, gc_ActionInquiry, v_strSQL)
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        'TruongLD Comment when convert
        'v_ws.Timeout = gc_WEB_SERVICE_TIMEOUT
        v_ws.Message(v_strMsgObj)
        'Fill data to grid
        Dim v_xmlDocument As New XmlDocumentEx
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strValue, v_strFLDNAME, v_strFLDTYPE As String

        v_xmlDocument.LoadXml(v_strMsgObj)
        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

        For i As Integer = 0 To v_nodeList.Count - 1
            For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                With v_nodeList.Item(i).ChildNodes(j)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    Select Case v_strFLDNAME
                        Case "DBDESC"
                            mv_strDBLinkDesc = .InnerText.ToString.Trim
                        Case "DBLINK"
                            mv_strDBLinkName = .InnerText.ToString.Trim
                    End Select
                End With
            Next
        Next


        v_strSQL = "SELECT VARVALUE DATA_HO_HA FROM SYSVAR WHERE VARNAME='RECEIVER_DATA_HO_HA'"
        v_strMsgObj = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SE_SBSECURITIES, gc_ActionInquiry, v_strSQL)
        'TruongLD Comment when convert
        'v_ws.Timeout = gc_WEB_SERVICE_TIMEOUT
        v_ws.Message(v_strMsgObj)
        'Fill data to grid
        v_xmlDocument.LoadXml(v_strMsgObj)
        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

        For i As Integer = 0 To v_nodeList.Count - 1
            For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                With v_nodeList.Item(i).ChildNodes(j)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    Select Case v_strFLDNAME
                        Case "DATA_HO_HA"
                            mv_strReceiverData = .InnerText.ToString.Trim
                    End Select
                End With
            Next
        Next
    End Sub

    Private Sub LoadTradingResultGrid()
        Try
            SearchGrid.DataRows.Clear()
            Dim v_strSQL As String = "SELECT A.FLOOR_CODE, A.TRADING_DATE, A.CONFIRM_NO, A.B_ORDER_NO, " _
                            & " A.B_ORDER_DATE, A.S_ORDER_NO, A.S_ORDER_DATE, A.B_NEXT_CNFRM, " _
                            & " A.S_NEXT_CNFRM, A.MATCH_TIME, A.MATCH_DATE, A.B_TRADING_ID, " _
                            & " A.S_TRADING_ID, A.B_PC_FLAG, A.S_PC_FLAG, A.B_CODE_TRADE, " _
                            & " A.S_CODE_TRADE, A.STATUS, A.SEC_CODE, A.QUANTITY, A.PRICE, " _
                            & " A.B_ACCOUNT_NO, A.S_ACCOUNT_NO, A.SETT_TYPE, A.SETT_DATE FROM TRADING_RESULT A "
            Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
            Dim v_strObjMsg As String = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TRADING_RESULT, gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)
            Dim v_strResourceManager As String
            FillDataGrid(SearchGrid, v_strObjMsg, "")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub LoadResource(ByRef pv_ctrl As Windows.Forms.Control)
        Dim v_ctrl As Windows.Forms.Control
        For Each v_ctrl In pv_ctrl.Controls
            If TypeOf (v_ctrl) Is Label Then
                CType(v_ctrl, Label).Text = mv_ResourceManager.GetString("frmReceiverData." & v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is GroupBox Then
                CType(v_ctrl, GroupBox).Text = mv_ResourceManager.GetString("frmReceiverData." & v_ctrl.Name)
                LoadResource(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is Button Then
                CType(v_ctrl, Button).Text = mv_ResourceManager.GetString("frmReceiverData." & v_ctrl.Name)
            End If
        Next
        Me.btnBrowser.Text = mv_ResourceManager.GetString("frmReceiverData.btnOpenFile")
    End Sub


    Private Sub LoadUserInterface(ByRef pv_ctrl As Windows.Forms.Control)
        Dim v_ctrl As Windows.Forms.Control
        Try
            For Each v_ctrl In pv_ctrl.Controls
                If TypeOf (v_ctrl) Is Label Then
                    CType(v_ctrl, Label).Text = ResourceManager.GetString(v_ctrl.Tag)
                ElseIf TypeOf (v_ctrl) Is Button Then
                    CType(v_ctrl, Button).Text = ResourceManager.GetString(v_ctrl.Tag)
                ElseIf TypeOf (v_ctrl) Is Panel Then
                    LoadUserInterface(v_ctrl)
                ElseIf TypeOf (v_ctrl) Is GroupBox Then
                    CType(v_ctrl, GroupBox).Text = ResourceManager.GetString(v_ctrl.Tag)
                    LoadUserInterface(v_ctrl)
                ElseIf TypeOf (v_ctrl) Is TabControl Then
                    For Each v_ctrlTmp As Control In CType(v_ctrl, TabControl).TabPages
                        CType(v_ctrlTmp, TabPage).Text = ResourceManager.GetString(v_ctrlTmp.Tag)
                    Next
                    LoadUserInterface(v_ctrl)
                ElseIf TypeOf (v_ctrl) Is TabPage Then
                    v_ctrl.BackColor = System.Drawing.SystemColors.InactiveCaptionText
                    CType(v_ctrl, TabPage).Text = ResourceManager.GetString(v_ctrl.Tag)
                    LoadUserInterface(v_ctrl)
                ElseIf TypeOf (v_ctrl) Is TextBox Then
                    CType(v_ctrl, TextBox).Text = vbNullString
                ElseIf TypeOf (v_ctrl) Is RadioButton Then
                    CType(v_ctrl, RadioButton).Text = ResourceManager.GetString(v_ctrl.Tag)
                End If
            Next
            'Load caption của form, label caption
            If (Me.Text.Trim() = String.Empty) Or (Me.Text.Trim() = Me.Name) Then
                Me.Text = ResourceManager.GetString(Me.Name)
            End If
            lblCaption.Text = ResourceManager.GetString(lblCaption.Tag)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "Private Method"

    'DUA DU LIEU VAO GRID
    Private Function FillDataFromTRADING_RESULT(ByVal v_ds As DataSet)
        Try
            For Each v_dr As DataRow In v_ds.Tables(0).Rows
                Dim v_xDataRow As Xceed.Grid.DataRow = SearchGrid.DataRows.AddNew()
                For Each v_xColumn As Xceed.Grid.Column In SearchGrid.Columns
                    If Not (v_dr(v_xColumn.FieldName) Is DBNull.Value) Then
                        Select Case v_xColumn.FieldName
                            Case "TRADING_DATE"
                                Dim v_t As New Date
                                v_t = v_dr("TRADING_DATE")
                                v_xDataRow.Cells(v_xColumn.FieldName).Value = CStr(v_t.ToString(gc_FORMAT_DATE))
                            Case "B_ORDER_DATE"
                                Dim v_t As New Date
                                v_t = v_dr("B_ORDER_DATE")
                                v_xDataRow.Cells(v_xColumn.FieldName).Value = CStr(v_t.ToString(gc_FORMAT_DATE))
                            Case "S_ORDER_DATE"
                                Dim v_t As New Date
                                v_t = v_dr("S_ORDER_DATE")
                                v_xDataRow.Cells(v_xColumn.FieldName).Value = CStr(v_t.ToString(gc_FORMAT_DATE))
                            Case "MATCH_DATE"
                                Dim v_t As New Date
                                v_t = v_dr("MATCH_DATE")
                                v_xDataRow.Cells(v_xColumn.FieldName).Value = CStr(v_t.ToString(gc_FORMAT_DATE))
                            Case Else
                                v_xDataRow.Cells(v_xColumn.FieldName).Value = CStr(v_dr(v_xColumn.FieldName))
                        End Select
                    Else
                        If v_xColumn.FieldName.Equals("SETT_DATE") Then
                            v_xDataRow.Cells(v_xColumn.FieldName).Value = "0"
                        Else
                            v_xDataRow.Cells(v_xColumn.FieldName).Value = ""
                        End If
                    End If
                Next
                v_xDataRow.EndEdit()
            Next
            SearchGrid.EndInit()
            'UpdateFooterRow(SearchGrid)
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                     & "Error code: System error!" & vbNewLine _
                     & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Function


    Private Function FillDataFromASTDL(ByVal v_ds As DataSet)
        Dim v_dt As New DataTable
        v_dt = v_ds.Tables(0)
        Dim v_xColumn As Xceed.Grid.Column
        Dim v_strValue As String
        Try
            SearchGrid.DataRows.Clear()
            SearchGrid.BeginInit()
            Dim v_intRowCnt As Integer
            For v_intRowCnt = 0 To v_dt.Rows.Count - 1
                Dim v_xDataRow As Xceed.Grid.DataRow = SearchGrid.DataRows.AddNew()
                For Each v_xColumn In SearchGrid.Columns
                    If Not v_dt.Rows(v_intRowCnt)(v_xColumn.FieldName) Is DBNull.Value Then
                        v_strValue = CStr(Trim(v_dt.Rows(v_intRowCnt)(v_xColumn.FieldName)))
                    Else
                        v_strValue = String.Empty
                    End If
                    v_xDataRow.Cells(v_xColumn.FieldName).Value = CStr(v_strValue)
                Next
                v_xDataRow.EndEdit()
            Next
            SearchGrid.EndInit()
            'UpdateFooterRow(SearchGrid)
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                     & "Error code: System error!" & vbNewLine _
                     & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Function

#Region "Create dataset"

    Private Function CreateDataSetFromASTPT() As DataSet

        Dim v_ds As New DataSet("DataSetForASTPT")
        Dim v_dt As New DataTable("DataTableForASTPT")

        Dim v_arrFldName() As String = {"FLOOR_CODE", "TRADING_DATE", "CONFIRM_NO", "B_ORDER_NO", "B_ORDER_DATE", _
                                        "S_ORDER_NO", "S_ORDER_DATE", "B_NEXT_CNFRM", "S_NEXT_CNFRM", "MATCH_TIME", _
                                        "MATCH_DATE", "B_TRADING_ID", "S_TRADING_ID", "B_PC_FLAG", "S_PC_FLAG", _
                                        "B_CODE_TRADE", "S_CODE_TRADE", "STATUS", "SEC_CODE", "QUANTITY", "PRICE", _
                                        "B_ACCOUNT_NO", "S_ACCOUNT_NO", "SETT_TYPE", "SETT_DATE"}
        'created by Chaunh 31/08/2011
        Dim v_arrFldStartPos() As Integer = {0, 14, 0, 82, 14, _
                                             82, 14, 0, 0, 6, _
                                             14, 24, 28, 0, 0, _
                                             32, 35, 39, 41, 95, 49, _
                                             62, 72, 0, 0}
        Dim v_arrFldSize() As Integer = {0, 10, 6, 5, 10, _
                                        5, 10, 0, 0, 8, _
                                        10, 4, 4, 0, 0, _
                                        3, 3, 2, 8, 8, 13, _
                                        10, 10, 0, 0} ' end Chaunh

        'Dim v_arrFldSize() As Integer = {0, 10, 6, 0, 0, 0, 0, 0, 0, 8, 10, 4, 4, 0, 0, 0, 0, 2, 8, 8, 13, 10, 10, 0, 0}
        'Dim v_arrFldStartPos() As Integer = {0, 14, 0, 0, 0, 0, 0, 0, 0, 6, 14, 24, 28, 0, 0, 0, 0, 37, 39, 101, 47, 60, 70, 0, 0}


        Dim v_strLine As String = String.Empty
        Dim v_strTempVal As String = String.Empty
        Dim v_oFile As System.IO.File
        Dim v_oRead As System.IO.StreamReader

        'Make Column
        For i As Integer = 0 To v_arrFldName.Length - 1
            Dim v_dc As New DataColumn
            v_dc.ColumnName = v_arrFldName(i).ToString()
            v_dc.Caption = v_arrFldName(i).ToString()
            v_dc.DataType = System.Type.GetType(c_SYS_STRING_TYPE)
            v_dt.Columns.Add(v_dc)
        Next
        'Make Row
        Dim v_objTempVal As Object
        Try

            Dim v_checkFile As New FileInfo(mv_srcFileName)
            If Not v_checkFile.Exists Then
                Exit Function
            End If
            v_oRead = v_oFile.OpenText(mv_srcFileName)
            v_oRead.BaseStream.Seek(0, SeekOrigin.Begin)
            While v_oRead.Peek <> -1
                v_strLine = v_oRead.ReadLine()
                Dim v_drow As DataRow
                v_drow = v_dt.NewRow()
                For k As Integer = 0 To v_arrFldName.Length - 1
                    If (k = 0) Then
                        'FloorCode
                        v_drow(v_arrFldName(k).ToString()) = mv_HOSTC_FLOORCODE

                    ElseIf (k = 19) Then 'created by Chaunh 31/08/2011
                        'neu k = 19, collumn QUANTITY
                        For i As Integer = 95 To 119
                            v_objTempVal = CObj(v_strLine.Substring(i, 8))
                            i = i + 8
                            If CInt(v_objTempVal) > 0 Then
                                Exit For
                            End If
                        Next
                        v_drow(v_arrFldName(k).ToString()) = Trim(v_objTempVal) 'end Chaunh
                    Else
                        If (v_arrFldStartPos(k) <> -1) Then
                            v_objTempVal = CObj(v_strLine.Substring(v_arrFldStartPos(k), v_arrFldSize(k)))
                            If k = 20 Then 'created by CHaunh 31/08/2011
                                v_objTempVal = CObj(Math.Round(CDbl(v_objTempVal), 6))
                            End If 'end Chaunh
                            v_drow(v_arrFldName(k).ToString()) = Trim(v_objTempVal)
                        End If
                    End If
                Next
                v_dt.Rows.Add(v_drow)
            End While
            v_oRead.Close()
            v_ds.Tables.Add(v_dt)

            Dim v_colsMATCHED_BQTTY As New DataColumn("MATCHED_BQTTY", System.Type.GetType("System.String"))
            Dim v_colsMATCHED_SQTTY As New DataColumn("MATCHED_SQTTY", System.Type.GetType("System.String"))
            v_ds.Tables(0).Columns.Add(v_colsMATCHED_BQTTY)
            v_ds.Tables(0).Columns.Add(v_colsMATCHED_SQTTY)

            Return v_ds
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
        End Try
    End Function

    Private Function CreateDataSetFromASTDL() As DataSet

        Dim v_ds As New DataSet("DataSetForASTDL")
        Dim v_dt As New DataTable("DataTableForASTDL")
        Dim v_arrFldName() As String = {"FLOOR_CODE", "TRADING_DATE", "CONFIRM_NO", "B_ORDER_NO", "B_ORDER_DATE", _
                                        "S_ORDER_NO", "S_ORDER_DATE", "B_NEXT_CNFRM", "S_NEXT_CNFRM", "MATCH_TIME", _
                                        "MATCH_DATE", "B_TRADING_ID", "S_TRADING_ID", "B_PC_FLAG", "S_PC_FLAG", _
                                        "B_CODE_TRADE", "S_CODE_TRADE", "STATUS", "SEC_CODE", "QUANTITY", "PRICE", _
                                        "B_ACCOUNT_NO", "S_ACCOUNT_NO", "SETT_TYPE", "SETT_DATE"}

        'Cho file astdl.txt
        Dim v_arrFldSize() As Integer = {0, 10, 6, 8, 10, 8, 10, 6, 6, 8, 10, 4, 4, 1, 1, 0, 0, 2, 8, 8, 9, 10, 10, 0, 0}

        'Dim v_arrFldStartPos() As Integer = {0, 62, 0, 6, 14, 24, 32, 42, 48, 54, 62, 72, 76, 80, 81, 0, 0, 87, 89, 97, 105, 114, 124, 0, 0}
        Dim v_arrFldStartPos() As Integer = {0, 62, 0, 6, 14, 24, 32, 42, 48, 54, 62, 72, 76, 80, 81, 0, 0, 87, 90, 99, 107, 116, 126, 0, 0}

        Dim v_strLine As String = String.Empty
        Dim v_strTempVal As String = String.Empty
        Dim v_oFile As System.IO.File
        Dim v_oRead As System.IO.StreamReader

        'Make Column
        For i As Integer = 0 To v_arrFldName.Length - 1
            Dim v_dc As New DataColumn
            v_dc.ColumnName = v_arrFldName(i).ToString()
            v_dc.Caption = v_arrFldName(i).ToString()
            v_dc.DataType = System.Type.GetType(c_SYS_STRING_TYPE)
            v_dt.Columns.Add(v_dc)
        Next
        'Make Row
        Dim v_objTempVal As Object
        Try
            Dim v_checkFile As New FileInfo(mv_srcFileName)
            If Not v_checkFile.Exists Then
                Exit Function
            End If
            v_oRead = v_oFile.OpenText(mv_srcFileName)
            v_oRead.BaseStream.Seek(0, SeekOrigin.Begin)
            While v_oRead.Peek <> -1
                v_strLine = v_oRead.ReadLine()
                Dim v_drow As DataRow
                v_drow = v_dt.NewRow()
                For k As Integer = 0 To v_arrFldName.Length - 1
                    If (k = 0) Then
                        'FloorCode
                        v_drow(v_arrFldName(k).ToString()) = mv_HOSTC_FLOORCODE
                    Else
                        If (v_arrFldStartPos(k) <> -1) Then
                            v_objTempVal = CObj(v_strLine.Substring(v_arrFldStartPos(k), v_arrFldSize(k)))
                            v_drow(v_arrFldName(k).ToString()) = Trim(v_objTempVal)
                        End If
                    End If
                Next
                v_dt.Rows.Add(v_drow)
            End While
            v_oRead.Close()
            v_ds.Tables.Add(v_dt)

            Dim v_colsMATCHED_BQTTY As New DataColumn("MATCHED_BQTTY", System.Type.GetType("System.String"))
            Dim v_colsMATCHED_SQTTY As New DataColumn("MATCHED_SQTTY", System.Type.GetType("System.String"))
            v_ds.Tables(0).Columns.Add(v_colsMATCHED_BQTTY)
            v_ds.Tables(0).Columns.Add(v_colsMATCHED_SQTTY)

            Return v_ds
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message : " & ex.Message, EventLogEntryType.Error)
        End Try
    End Function

    Private Function CreateDatasetFromTRADING_RESULT() As DataSet
        Try
            Dim v_ds As New DataSet

            Dim v_checkFile As New FileInfo(mv_srcFileName)
            If Not v_checkFile.Exists Then
                Exit Function
            End If
            v_ds.ReadXml(mv_srcFileName)
            Dim v_colsMATCHED_BQTTY As New DataColumn("MATCHED_BQTTY", System.Type.GetType("System.String"))
            Dim v_colsMATCHED_SQTTY As New DataColumn("MATCHED_SQTTY", System.Type.GetType("System.String"))
            v_ds.Tables(0).Columns.Add(v_colsMATCHED_BQTTY)
            v_ds.Tables(0).Columns.Add(v_colsMATCHED_SQTTY)
            Return v_ds
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                             & "Error code: System error!" & vbNewLine _
                             & "Error message : " & ex.Message, EventLogEntryType.Error)
        End Try
    End Function

#End Region

    Private Sub OnSave()
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim v_strFunctionName As String = "ImportTradingResultToDB"
            Dim v_strClause, v_strErrorSource, v_strErrorMessage As String
            mv_strObjName = "SA.TRADING_RESULT"
            If (MessageBox.Show(ResourceManager.GetString("SAVE_CONFIRMATION"), gc_ApplicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                'TruongLD Comment when convert
                'v_ws.Timeout = gc_WEB_SERVICE_TIMEOUT
                Dim v_strSQL, v_strObjMsg, v_strValue As String
                Dim v_strBuffer As New System.Text.StringBuilder

                For i As Integer = 0 To SearchGrid.DataRows.Count - 1
                    With SearchGrid.DataRows(i)
                        For Each v_xColumn As Xceed.Grid.Column In SearchGrid.Columns

                            If Not .Cells(v_xColumn.FieldName).Value() Is DBNull.Value Then
                                v_strValue = CStr(.Cells(v_xColumn.FieldName).Value)
                            Else
                                v_strValue = ""
                            End If
                            v_strBuffer.Append("" & v_strValue & ",")
                        Next
                        v_strBuffer.Append("|")
                    End With
                Next
                v_strClause = v_strBuffer.ToString
                v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, mv_strObjName, _
                        gc_ActionAdhoc, , v_strClause, v_strFunctionName, , )
                Dim v_lngError As Long = v_ws.Message(v_strObjMsg)
                'TruongLD Comment when convert
                'v_ws.Dispose()
                If v_lngError <> ERR_SYSTEM_OK Then
                    'Thông báo lỗi
                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                    Cursor.Current = Cursors.Default
                    'MessageBox.Show(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, Me.Text, MessageBoxIcon.Error)
                    MessageBox.Show(v_strErrorMessage, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                Cursor.Current = Cursors.Default
                'check error here
                MessageBox.Show(mv_ResourceManager.GetString("frmReceiverData.ImportToDBSuccess"), Me.FormCaption, MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If
        Catch ex As Exception
            LogError.Write("Error source: @DIRECT.frmUpdateSecInfo.OnSave" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub OnClose()
        Me.Close()
    End Sub

#End Region

#Region "Form event"

    Private Sub RadioButton_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If (sender Is radioQuoteSvr) And (radioQuoteSvr.Checked) Then
            SetReadFromQuoteState()
        ElseIf (sender Is radioFiles) And (radioFiles.Checked) Then
            SetReadFromFileState()
        End If
    End Sub

    Private Sub SetReadFromQuoteState()
        Me.grbFiles.Visible = False
        Me.grbQuoteSvr.Visible = True
    End Sub

    Private Sub SetReadFromFileState()
        Me.grbFiles.Visible = True
        Me.grbQuoteSvr.Visible = False
    End Sub

    Private Sub Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If (sender Is btnSave) Then
                OnSave()
            ElseIf (sender Is btnCancel) Then
                OnClose()
            ElseIf (sender Is btnBrowser) Then
                OnBrowser()
            ElseIf (sender Is btnLoadData) Then
                OnRead()
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub frmReceiverData_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitDialog()
    End Sub

    Private Sub ReadSecInfoFromQuoteSvr()
        Try
            Dim v_strSymbol As String
            Dim v_decRefPrice, v_decOpenPrice, v_decFloorPrice, v_decCeilingPrice, v_decCurrPrice, v_decAvgPrice, v_decClosePrice As Decimal
            Dim v_strTradePlace As String
            Dim v_decTradeUnit As Decimal

            If (txtServerAddress.Text.Trim.Length > 0) Then
                GetTradingResultFromQuote()
            End If

        Catch ex As Exception
            LogError.Write("Error source: @DIRECT.frmUpdateSecInfo.ReadSecInfoFromQuoteSvr" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


#End Region

    Private Sub OnRead()
        Try
            If (radioQuoteSvr.Checked) And (Not radioFiles.Checked) Then
                'Read data from Quote Server
                GetTradingResultFromQuote()
            ElseIf (Not radioQuoteSvr.Checked) And (radioFiles.Checked) Then
                'Read data from files
                ReadTradingResultFromFiles()
            End If
        Catch ex As Exception
            LogError.Write("Error source: @DIRECT.frmUpdateSecInfo.OnRead" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub OnBrowser()
        Try

            Dim v_dlgOpen As New OpenFileDialog
            v_dlgOpen.Filter = "DAT files (*.dat)|*.dat|XML files (*.xml)|*.xml|All files (*.*)|*.*"
            v_dlgOpen.RestoreDirectory = True

            Dim v_res As DialogResult = v_dlgOpen.ShowDialog(Me)
            If v_res = DialogResult.OK Then
                mv_srcFileName = v_dlgOpen.FileName
                Me.txtFromFile.Text = mv_srcFileName
            End If
        Catch ex As Exception
            LogError.Write("Error source: @DIRECT.frmTradingResult.OnBrowser" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GetTradingResultFromQuote()
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim v_strSQL As String = "SELECT A.FLOOR_CODE, A.TRADING_DATE, A.CONFIRM_NO, A.B_ORDER_NO, " _
                                & " A.B_ORDER_DATE, A.S_ORDER_NO, A.S_ORDER_DATE, A.B_NEXT_CNFRM, " _
                                & " A.S_NEXT_CNFRM, A.MATCH_TIME, A.MATCH_DATE, A.B_TRADING_ID, " _
                                & " A.S_TRADING_ID, A.B_PC_FLAG, A.S_PC_FLAG, A.B_CODE_TRADE, " _
                                & " A.S_CODE_TRADE, A.STATUS, A.SEC_CODE, A.QUANTITY, A.PRICE, " _
                                & " A.B_ACCOUNT_NO, A.S_ACCOUNT_NO, A.SETT_TYPE, A.SETT_DATE FROM TRADING_RESULT@" & mv_strDBLinkName & " A " _
                                & " WHERE A.TRADING_DATE=TO_DATE('" & Me.BusDate & "','DD/MM/YYYY')" _
                                & " AND A.FLOOR_CODE = DECODE('" & mv_strReceiverData & "','HA','02','HO','10',A.FLOOR_CODE)"
            Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
            Dim v_strObjMsg As String = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TRADING_RESULT, gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)
            SearchGrid.DataRows.Clear()
            FillDataGrid(SearchGrid, v_strObjMsg, "")
            If SearchGrid.DataRows.Count > 0 Then
                MessageBox.Show(ResourceManager.GetString("READ_DATA_SUCCESSFULLY"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show(ResourceManager.GetString("NO_DATA_FOUND"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            LogError.Write("Error source: @DIRECT.frmTradingResult.GetTradingResultFromQuote" & vbNewLine _
                               & "Error code: System error!" & vbNewLine _
                               & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ReadTradingResultFromFiles()
        Try
            Dim v_strSymbol As String
            Dim v_decRefPrice, v_decOpenPrice, v_decFloorPrice, v_decCeilingPrice, v_decCurrPrice, v_decAvgPrice, v_decClosePrice As Decimal
            Dim v_strTradePlace As String
            Dim v_decTradeUnit As Decimal

            If (txtFromFile.Text.Trim.Length > 0) Then

                Dim v_strFileName As String = txtFromFile.Text.Trim()
                Dim v_strFileType As String = v_strFileName.Substring(v_strFileName.Length - 4).ToUpper()

                Select Case v_strFileType
                    Case c_FILE_FORMAT_TEXT.ToUpper()
                        If (MessageBox.Show(ResourceManager.GetString("READ_CONFIRMATION").Replace("@", v_strFileName), gc_ApplicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                            'Kiem tra file co ton tai hay khong
                            If (Not File.Exists(v_strFileName)) Then
                                MessageBox.Show(ResourceManager.GetString("FILENAME_MUST_VALID"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                txtFromFile.Focus()
                                Exit Sub
                            End If

                            'v_strTradePlace = c_TRADEPLACE_HOSTC
                            Dim v_blnIsBigLot As Boolean
                            If v_strFileName.IndexOf(c_FILE_ASTDL) > 0 Then
                                v_blnIsBigLot = False
                            ElseIf v_strFileName.IndexOf(c_FILE_ASTPT) > 0 Then
                                v_blnIsBigLot = True
                            Else
                                v_blnIsBigLot = False
                                MessageBox.Show(ResourceManager.GetString("FILENAME_MUST_VALID"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                txtFromFile.Focus()
                                Exit Sub
                            End If
                            'Doc file here va dua vao grid
                            Dim v_ds As New DataSet
                            If v_blnIsBigLot Then
                                v_ds = CreateDataSetFromASTPT()
                            Else
                                v_ds = CreateDataSetFromASTDL()
                            End If
                            If v_ds.Tables(0).Rows.Count > 0 Then
                                SearchGrid.DataRows.Clear()
                                FillDataFromASTDL(v_ds)
                                MessageBox.Show(ResourceManager.GetString("READ_FILE_SUCCESSFULLY").Replace("@", v_strFileName), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

                            End If
                        End If
                    Case c_FILE_FORMAT_XML.ToUpper()
                        If (MessageBox.Show(ResourceManager.GetString("READ_CONFIRMATION").Replace("@", v_strFileName), gc_ApplicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                            'Kiem tra file co ton tai hay khong
                            If (Not File.Exists(v_strFileName)) Then
                                MessageBox.Show(ResourceManager.GetString("FILENAME_MUST_VALID"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                txtFromFile.Focus()
                                Exit Sub
                            End If

                            v_strTradePlace = c_TRADEPLACE_HASTC
                            Dim v_ds As DataSet = CreateDatasetFromTRADING_RESULT()
                            If v_ds.Tables(0).Rows.Count > 0 Then
                                SearchGrid.DataRows.Clear()
                                FillDataFromTRADING_RESULT(v_ds)
                                MessageBox.Show(ResourceManager.GetString("READ_FILE_SUCCESSFULLY").Replace("@", v_strFileName), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If
                        End If
                    Case Else
                        MessageBox.Show(ResourceManager.GetString("FILENAME_MUST_VALID"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtFromFile.Focus()
                End Select
            Else
                MessageBox.Show(ResourceManager.GetString("FILENAME_MUST_VALID"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtFromFile.Focus()
            End If
        Catch ex As Exception
            LogError.Write("Error source: @DIRECT.frmUpdateSecInfo.ReadSecInfoFromFiles" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmReceiverData_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Select Case e.KeyCode
            Case Keys.Escape
                OnClose()
        End Select
    End Sub
End Class

