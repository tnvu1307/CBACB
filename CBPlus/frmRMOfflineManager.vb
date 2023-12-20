Imports CommonLibrary
Imports System.IO
Imports AppCore
Imports System.Text
Imports System.Configuration
Imports System.Xml
Imports log4net
Public Class frmRMOfflineManager

#Region "Log Utils"
    Private ReadOnly Log As ILog = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
    Public Shared Function A(ByVal logString As String, ByVal ParamArray logParams As Object()) As String
        Dim sb As New StringBuilder
        sb.Append(logString).Append(".:")
        For Each s As Object In logParams
            sb.Append(", [").Append(s).Append("]")
        Next
        Return sb.ToString()
    End Function
#End Region

#Region " Windows Form Designer generated code "
    Public Sub New(ByVal pv_strLanguage As String)
        'MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        mv_strLanguage = pv_strLanguage
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        LoadResource(Me)
    End Sub
#End Region

#Region " Declare constant and variables "
    Const c_ResourceManager As String = "_DIRECT.frmRMOfflineManager-"
    Private mv_strSearchFilter As String
    Private mv_strSearchFilterStore As String
    Private mv_SearchData As DataSet
    Private mv_ResourceManager As Resources.ResourceManager
    Const c_GridSelectedColumn As String = "SELECT"
    Const c_GridSelectedValue As String = "X"
    Const c_DelimiterChar As String = "|"

    Private mv_strLocalObject As String
    Private mv_strBranchId As String
    Private mv_strTellerId As String
    Private mv_strTellerName As String
    Private mv_strIpAddress As String
    Private mv_strWsName As String
    Private mv_strBusDate As String
    Private mv_strModuleCode As String
    Private mv_strObjectName As String
    Private mv_strLanguage As String

    Private mv_srcFileName As String
    Private mv_srcFilePath As String
    Private mv_strObjName As String
    Private mv_strFileCode As String
    Private WithEvents SearchGrid As GridEx
    Private ResultGrid As GridEx
    Private mv_strFILEPATH As String = ""
    Private mv_strSHEETNAME As String = "1"
    Private mv_strEXTENTION As String = ".xls"
    Private mv_strFILEPATCH As String = "D:\EXPORT\"
    Private mv_strPROCNAME As String
    Private mv_strBANKNAME As String = String.Empty
    Private mv_strISSIGN As String = String.Empty
    Private mv_srcFileName_6614 As String
    Private mv_srcFilePath_6614 As String
    Private mv_strObjName_6614 As String
    Private mv_strFileCode_6614 As String
    Private mv_strFILEPATH_6614 As String = ""
    Private mv_strSHEETNAME_6614 As String = "1"
    Private mv_strEXTENTION_6614 As String = ".xls"
    Private mv_strFILEPATCH_6614 As String = "D:\EXPORT\"
    Private mv_strPROCNAME_6614 As String
    Private mv_strBANKNAME_6614 As String = String.Empty
    Private mv_strISSIGN_6614 As String = String.Empty
    Private mv_intROWTITLE As String = 1
    Private mv_intPAGE As String = 0
    Private mv_strTableName As String = 0
    Private mv_blnApprove As Boolean = False
    Private mv_blnIsImport As Boolean = False
    Private mv_blnIsCa As Boolean = False
    Private mv_strCAMASTID As String = String.Empty
    Private mv_blnIsFirstRun As Boolean = True
    Private mv_blnIsInitGrid As Boolean = False
    Private mv_blnIsAllowSave As Boolean = False
    Private mv_blnIsAllowApprove As Boolean = False
    Private mv_strSaveTableName As String
    Private mv_strCMDSQL As String
    Private mv_ISDIRECT As String
    Private mv_strCMDSQL_6614 As String
    Private mv_ISDIRECT_6614 As String
    Private mv_strKeyValue As String
    Private mv_arrObjXmlNode() As XmlNodeDictionary
    Private mv_arrObjXmlNode_6614() As XmlNodeDictionary
    Private mv_arrAutoID As String
    Private mv_strFileName As String
    Private mv_strBatchID As String
    Private mv_ds As New DataSet()
#End Region

#Region " Properties "
    Public Property IsApprove() As Boolean
        Get
            Return mv_blnApprove
        End Get
        Set(ByVal Value As Boolean)
            mv_blnApprove = Value
        End Set
    End Property

    Public Property IsImport() As Boolean
        Get
            Return mv_blnIsImport
        End Get
        Set(ByVal Value As Boolean)
            mv_blnIsImport = Value
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

    Public Property ModuleCode() As String
        Get
            Return mv_strModuleCode
        End Get
        Set(ByVal Value As String)
            mv_strModuleCode = Value
        End Set
    End Property

    Public Property ObjectName() As String
        Get
            Return mv_strObjectName
        End Get
        Set(ByVal Value As String)
            mv_strObjectName = Value
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

    Public Property TellerName() As String
        Get
            Return mv_strTellerName
        End Get
        Set(ByVal Value As String)
            mv_strTellerName = Value
        End Set
    End Property

    Public Property LocalObject() As String
        Get
            Return mv_strLocalObject
        End Get
        Set(ByVal Value As String)
            mv_strLocalObject = Value
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

    Public Property ResourceManager() As Resources.ResourceManager
        Get
            Return mv_ResourceManager
        End Get
        Set(ByVal Value As Resources.ResourceManager)
            mv_ResourceManager = Value
        End Set
    End Property


    Public Property KeyValue() As String
        Get
            Return mv_strKeyValue
        End Get
        Set(ByVal Value As String)
            mv_strKeyValue = Value
        End Set
    End Property

    Public Property BATCHID() As String
        Get
            Return mv_strBatchID
        End Get
        Set(ByVal Value As String)
            mv_strBatchID = Value
        End Set
    End Property
#End Region

#Region "Form events"

    Private Sub frmRMOfflineManager_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        Select Case e.KeyCode
            Case Keys.Escape
                OnClose()
        End Select
    End Sub

    Private Sub frmRMOfflineManager_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        OnInit()
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        OnBrowser()
    End Sub

    Private Sub cboFileType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFileType.SelectedIndexChanged
        If Me.cboFileType.Items.Count > 0 Then
            'InitGrid()
            If mv_blnIsFirstRun Then Exit Sub
            LoadDefaultData(cboFileType.SelectedValue)
            LoadDefaultData_6614(cboFileType.SelectedValue)
            mv_strFileCode = cboFileType.SelectedValue
            LoadScreen()
            LoadExportConfig
            LoadComboBox()
            OnReConfigButton()
        End If
    End Sub

    Private Sub cboBankName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboBankName.SelectedIndexChanged
        Try
            Dim v_ws As New BDSDeliveryManagement
            Dim v_strCmdSQL As String, v_strObjMsg As String
            If Not mv_blnIsFirstRun Then
                If Me.cboBankName.Items.Count > 0 Then
                    'Load Combo cboTranCode
                    v_strCmdSQL = "SELECT VARVALUE VALUE, VARVALUE || ': ' || VARDESC DISPLAY, VARVALUE || ': ' || EN_VARDESC EN_DISPLAY, LSTODR, ISUSER " & ControlChars.CrLf _
                              & "FROM BANKPARAMS WHERE ISUSER='Y' AND GRNAME ='RM' AND VARNAME = 'TRANCODE' AND REFVARVALUE = '" & mv_strBANKNAME & "'"
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
                    v_ws.Message(v_strObjMsg)
                    FillComboEx(v_strObjMsg, cboTranCode, "", Me.UserLanguage)
                Else
                    cboTranCode.Enabled = False
                End If
            End If
        Catch ex As Exception
            LogError.Write("Error source: @DIRECT.frmRMOfflineManager.cboBankName_SelectedIndexChanged" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            Throw ex
        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        OnClose()
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Try
            ExportToFile()
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub
    Private Sub btnExport1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click, btnExport1.Click
        Try
            ExportGridToExcel()

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub btnLoadData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadData.Click
        Try
            Dim v_lngReturn As Long
            v_lngReturn = OnLoadData()
            If v_lngReturn = ERR_SYSTEM_OK Then
                If mv_ISDIRECT = "Y" Then
                    mv_blnIsAllowApprove = True
                    mv_blnIsAllowSave = False
                Else
                    mv_blnIsAllowSave = True
                    mv_blnIsAllowApprove = False
                End If
                OnReConfigButton()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If mv_blnIsAllowSave Then
                OnSave(False)
                mv_blnIsAllowSave = False
                mv_blnIsAllowApprove = True
            Else
                MessageBox.Show(mv_ResourceManager.GetString("msg_Do_Not_Data_To_Save"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            OnReConfigButton()

        Catch ex As Exception
            MessageBox.Show(mv_ResourceManager.GetString("msg_Input_File_Invalid"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSync_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSync.Click
        Try
            OnSave(True)
            OnReConfigButton()
        Catch ex As Exception
            MessageBox.Show(mv_ResourceManager.GetString("msg_Input_File_Invalid"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            If mv_strCMDSQL.Length <> 0 Then
                OnSearch(mv_strCMDSQL)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SearchGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchGrid.DoubleClick
        Try

        Catch ex As Exception
        End Try
    End Sub

    Private Sub Grid_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            Select Case e.KeyCode
                Case Keys.Space
                    If Not SearchGrid.Columns("__TICK") Is Nothing Then

                        If CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("__TICK").Visible Then
                            If CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("__TICK").Value = "X" Then
                                CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("__TICK").Value = String.Empty
                            Else
                                CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("__TICK").Value = "X"
                            End If
                        End If
                    End If
                Case Keys.Control.A
                    If Not SearchGrid.Columns("__TICK") Is Nothing Then
                        For i As Integer = 0 To SearchGrid.DataRows.Count - 1
                            If SearchGrid.DataRows(i).Cells("__TICK").Visible Then
                                If SearchGrid.DataRows(i).Cells("__TICK").Value = "X" Then
                                    SearchGrid.DataRows(i).Cells("__TICK").Value = String.Empty
                                Else
                                    SearchGrid.DataRows(i).Cells("__TICK").Value = "X"
                                End If
                            End If
                        Next
                    End If

            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Protected Overridable Sub Grid_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not SearchGrid.CurrentColumn Is Nothing Then
            If SearchGrid.CurrentColumn.FieldName = "__TICK" Then
                If SearchGrid.CurrentCell.Visible Then
                    If SearchGrid.CurrentCell.Value = "X" Then
                        SearchGrid.CurrentCell.Value = String.Empty
                    Else
                        SearchGrid.CurrentCell.Value = "X"
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub mnuSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSelectAll.Click
        Dim v_intRow As Integer
        If Not SearchGrid Is Nothing Then
            If SearchGrid.DataRows.Count > 0 Then
                For v_intRow = 0 To SearchGrid.DataRows.Count - 1 Step 1
                    If SearchGrid.DataRows(v_intRow).Cells("__TICK").Visible = True Then
                        SearchGrid.DataRows(v_intRow).Cells("__TICK").Value = "X"
                    End If
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
#End Region

#Region "Private Function"

    Private Sub OnBIDVEncrypt()
        Try

        Catch ex As Exception
            LogError.Write("Error source: @DIRECT.frmRMOfflineManager.OnBIDVEncrypt" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            Throw ex
        End Try
    End Sub

    Private Sub OnBIDVVerify()
        Try

        Catch ex As Exception
            LogError.Write("Error source: @DIRECT.frmRMOfflineManager.OnBIDVVerify" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            Throw ex
        End Try
    End Sub

    Private Sub OnResetForm()
        Try
            Me.txtPath.Text = ""
            Me.dtpTXDATE.Value = DDMMYYYY_SystemDate(Me.BusDate.ToString)
            If IsApprove Then
                If IsImport Then
                    Me.btnSave.Text = mv_ResourceManager.GetString("btnAprove")
                    'Form Caption
                    Me.Text = mv_ResourceManager.GetString("Aprove_Import_Caption") '"Duyệt Import giao dịch"
                    Me.txtPath.Enabled = False
                    Me.btnBrowse.Enabled = False
                Else
                    Me.btnSave.Text = mv_ResourceManager.GetString("btnAprove")
                    'Form Caption
                    Me.Text = mv_ResourceManager.GetString("Aprove_Export_Caption") '"Duyệt đồng bộ số liệu"
                    Me.txtPath.Enabled = False
                    Me.btnBrowse.Enabled = False
                End If
            Else
                If IsImport Then
                    Me.btnSave.Text = mv_ResourceManager.GetString("btnSave")
                    'Form Caption
                    Me.Text = mv_ResourceManager.GetString("Import_Caption") '"Import giao dịch"
                Else
                    Me.btnSave.Text = mv_ResourceManager.GetString("btnSave")
                    'Form Caption
                    Me.Text = mv_ResourceManager.GetString("Export_Caption") ' "Đồng bộ số liệu"
                End If
            End If
        Catch ex As Exception
            LogError.Write("Error source: @DIRECT.frmRMOfflineManager.OnResetForm" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            Throw ex
        End Try
    End Sub

    Private Sub OnInit()

        Dim v_ws As New BDSDeliveryManagement
        Dim v_strCmdSQL As String, v_strObjMsg As String
        Try
            'Me.dtpBATCHDATE.Text = CDate(Me.BusDate)
            'Me.dtpEFFECTDATE.Text = CDate(Me.BusDate)
            Dim v_CMDSQL As String
            Dim v_strClause As String

            'Me.txtSCID.Text = ConfigurationManager.AppSettings("SCID")
            'Me.txtCurr.Text = ConfigurationManager.AppSettings("BASECCYCD")

            If IsImport Then
                v_strClause = " AND EORI IN ('I') "
                chkIsSigner.Text = mv_ResourceManager.GetString("chkIsVerify")
                tabIorE.Text = mv_ResourceManager.GetString("tabImport")
                chkAll.Visible = False
            Else
                v_strClause = " AND EORI IN ('E') "
                chkIsSigner.Text = mv_ResourceManager.GetString("chkIsSigner")
                tabIorE.Text = mv_ResourceManager.GetString("tabExport")
                chkAll.Text = mv_ResourceManager.GetString("chkAll")
            End If

            'Load combobox cboFileType
            v_strCmdSQL = "SELECT FILECODE VALUE, FILECODE || ' : ' || FILENAME DISPLAY, FILECODE || ': ' || FILENAME EN_DISPLAY, " & ControlChars.CrLf _
                              & "FILECODE, EXTENTION, CMDSQL, PROCNAME, OVRRQD, OBJNAME, BANKNAME, ISSIGN " & ControlChars.CrLf _
                              & "FROM CRBFILEMASTER WHERE  VISIBLE ='N' "
            v_strCmdSQL = v_strCmdSQL & v_strClause

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            FillComboEx(v_strObjMsg, cboFileType, "", Me.UserLanguage)

            'Load combo status
            v_strCmdSQL = "SELECT VALUE, DISPLAY, EN_DISPLAY, LSTODR FROM " & ControlChars.CrLf _
                          & "(" & ControlChars.CrLf _
                          & " SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, LSTODR " & ControlChars.CrLf _
                          & " FROM ALLCODE WHERE CDNAME ='TRFLOGSTS' AND CDTYPE='RM' " & ControlChars.CrLf _
                          & " UNION ALL " & ControlChars.CrLf _
                          & " SELECT 'ALL' VALUE, 'Tất cả' DISPLAY, 'A''' EN_DISPLAY, -1 LSTODR FROM DUAL" & ControlChars.CrLf _
                          & " ) ORDER BY LSTODR"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            'Load Combo cboStatus
            FillComboEx(v_strObjMsg, cboStatus, "", Me.UserLanguage)

            mv_blnIsFirstRun = False
            OnResetForm()

            LoadDefaultData(cboFileType.SelectedValue)
            LoadDefaultData_6614(cboFileType.SelectedValue)
            LoadComboBox()
            If IsImport Then
                InitGrid()
            Else
                LoadScreen()
            End If

            OnReConfigButton()

        Catch ex As Exception
            LogError.Write("Error source: @DIRECT.frmRMOfflineManager.OnInit" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            Throw ex
        End Try
    End Sub

    Private Sub InitGrid(Optional ByVal v_strXML As String = vbNullString)
        Dim v_objNode As XmlNodeDictionary
        Dim v_strXmlNodeID As String = String.Empty
        Dim v_strXmlPRNodeID As String = String.Empty
        Dim v_blnXmlLastNode As Boolean = False
        Dim v_blnXmlSumCalc As Boolean = False
        Dim v_blnIsNode As Boolean = False
        Dim v_intLevel As Integer = 0
        Dim v_strTableFldName As String = String.Empty
        Dim v_strDatatype As String = String.Empty
        Dim v_intWIDTH As Integer = 0
        Dim v_ws As New BDSDeliveryManagement
        Dim v_xmlDocument As New XmlDocumentEx
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strValue, v_strFLDNAME As String
        Dim v_FldName, v_FldCaption As String
        Dim v_FldWidth As Long
        Dim v_blnVISIBLE As Boolean
        Dim v_blnISPARAM As Boolean = False
        Dim v_cmrContactsHeader As New Xceed.Grid.ColumnManagerRow
        Try
            If mv_blnIsFirstRun Then
                Exit Sub
                btnSearch.Enabled = False
            End If
            v_cmrContactsHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
            v_cmrContactsHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            v_cmrContactsHeader.Height = 32
            If v_strXML = vbNullString Then
                Dim v_strSQL As String = "SELECT FILECODE, FILEFLDNAME, PRFILEFLDNAME, FILEFLDFORMAT, LEV, LASTNODE, " & ControlChars.CrLf _
                                       & "TBLFLDNAME, TBLFLDTYPE, CHANGETYPE, DISABLED, VISIBLE, ISPARAM, WIDTH, FIELDDESC " & ControlChars.CrLf _
                                       & "FROM CRBFILEMAP WHERE UPPER(FILECODE) = '" & cboFileType.SelectedValue & "' ORDER BY LSTODR"
                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                v_xmlDocument.LoadXml(v_strObjMsg)
            Else
                v_xmlDocument.LoadXml(v_strXML)
            End If

            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            If v_nodeList.Count = 0 Then
                Exit Sub
            End If

            SearchGrid = New GridEx
            SearchGrid.FixedHeaderRows.Add(v_cmrContactsHeader)
            SearchGrid.Columns.Add(New Xceed.Grid.Column("__TICK", GetType(System.String)))
            SearchGrid.Columns("__TICK").Width = "35"
            SearchGrid.Columns("__TICK").Title = mv_ResourceManager.GetString("_TICK")
            SearchGrid.Columns("__TICK").VerticalAlignment = Xceed.Grid.VerticalAlignment.Center
            SearchGrid.Columns("__TICK").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
     
            For i As Integer = 0 To v_nodeList.Count - 1
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "TBLFLDNAME"
                                v_FldName = v_strValue.Trim()
                            Case "FIELDDESC"
                                v_FldCaption = v_strValue.Trim()
                            Case "WIDTH"
                                v_FldWidth = CInt(v_strValue.Trim())
                            Case "VISIBLE"
                                If v_strValue.Trim = "N" Then
                                    v_blnVISIBLE = True
                                Else
                                    v_blnVISIBLE = False
                                End If
                            Case "ISPARAM"
                                If v_strValue.Trim = "Y" Then
                                    v_blnISPARAM = True
                                Else
                                    v_blnISPARAM = False
                                End If
                            Case "FILEFLDNAME"
                                v_strXmlNodeID = Trim(v_strValue)
                            Case "PRFILEFLDNAME"
                                v_strXmlPRNodeID = Trim(v_strValue)
                            Case "LASTNODE"
                                If Trim(v_strValue) = "Y" Then
                                    v_blnXmlLastNode = True
                                Else
                                    v_blnXmlLastNode = False
                                End If
                            Case "LEV"
                                v_intLevel = CInt(v_strValue)
                            Case "TBLFLDNAME"
                                v_strTableFldName = Trim(v_strValue)
                            Case "ISSUM"
                                If Trim(v_strValue) = "Y" Then
                                    v_blnXmlSumCalc = True
                                Else
                                    v_blnXmlSumCalc = False
                                End If
                            Case "DATATYPE"
                                v_strDatatype = Trim(v_strValue)
                            Case "WIDTH"
                                v_intWIDTH = CInt(v_strValue)
                            Case "ISNODE"
                                If Trim(v_strValue) = "Y" Then
                                    v_blnIsNode = True
                                Else
                                    v_blnIsNode = False
                                End If
                        End Select
                    End With
                Next
                If Not v_FldName Is Nothing AndAlso v_FldName.Length <> 0 And v_blnISPARAM Then
                    SearchGrid.Columns.Add(New Xceed.Grid.Column(v_FldName, GetType(System.String)))
                    SearchGrid.Columns(v_FldName).Width = v_FldWidth
                    SearchGrid.Columns(v_FldName).Title = v_FldCaption
                    SearchGrid.Columns(v_FldName).Visible = v_blnVISIBLE
                End If

              
            Next

            Me.pnsSearchResult.Controls.Clear()
            Me.pnsSearchResult.Controls.Add(SearchGrid)
            SearchGrid.Dock = DockStyle.Fill
            AddHandler SearchGrid.DoubleClick, AddressOf Me.Grid_Click
            If Me.SearchGrid.DataRowTemplate.Cells.Count >= 0 Then
                For i As Integer = 0 To Me.SearchGrid.DataRowTemplate.Cells.Count - 1
                    AddHandler SearchGrid.DataRowTemplate.Cells(i).Click, AddressOf Grid_Click
                Next
            End If

            AddHandler SearchGrid.DataRowTemplate.KeyUp, AddressOf Grid_KeyUp

            If Not SearchGrid.Columns("__TICK") Is Nothing Then
                SearchGrid.Columns("__TICK").Visible = True
                SearchGrid.ContextMenu = Me.mnuGrid
            End If

            mv_blnIsInitGrid = True
            btnSearch.Enabled = True

        Catch ex As Exception
            LogError.Write("Error source: @DIRECT.frmRMOfflineManager.InitGrid" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
        End Try
    End Sub

    Private Sub LoadResource(ByRef pv_ctrl As Windows.Forms.Control)
        Dim v_ctrl As Windows.Forms.Control
        Dim v_strControlTag As String
        Try
            For Each v_ctrl In pv_ctrl.Controls
                If Not v_ctrl.Tag Is Nothing Then
                    v_strControlTag = v_ctrl.Tag.ToString
                    If v_strControlTag.Trim.Length > 0 Then
                        If TypeOf (v_ctrl) Is Label Then
                            v_ctrl.Text = ResourceManager.GetString(v_strControlTag)
                        ElseIf TypeOf (v_ctrl) Is Button Then
                            v_ctrl.Text = ResourceManager.GetString(v_strControlTag)
                        ElseIf TypeOf (v_ctrl) Is Panel Then
                            LoadResource(v_ctrl)
                        ElseIf TypeOf (v_ctrl) Is SplitContainer Then
                            LoadResource(v_ctrl)
                        ElseIf TypeOf (v_ctrl) Is GroupBox Then
                            v_ctrl.Text = ResourceManager.GetString(v_strControlTag)
                            LoadResource(v_ctrl)
                        ElseIf TypeOf (v_ctrl) Is TabControl Then
                            For Each v_ctrlTmp As Control In CType(v_ctrl, TabControl).TabPages
                                v_strControlTag = v_ctrlTmp.Tag
                                v_ctrlTmp.Text = ResourceManager.GetString(v_strControlTag)
                            Next
                            LoadResource(v_ctrl)
                        ElseIf TypeOf (v_ctrl) Is TabPage Then
                            v_ctrl.BackColor = System.Drawing.SystemColors.InactiveCaptionText
                            v_ctrl.Text = ResourceManager.GetString(v_strControlTag)
                            LoadResource(v_ctrl)
                        ElseIf TypeOf (v_ctrl) Is CheckBox Then
                            v_ctrl.Text = ResourceManager.GetString(v_strControlTag)
                        End If
                    End If
                End If
            Next
            If (Me.Text.Trim() = String.Empty) Then
                Me.Text = ResourceManager.GetString(Me.Name)
            End If
        Catch ex As Exception
            LogError.Write("Error source: @DIRECT.frmRMOfflineManager.LoadResource" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            Throw ex
        End Try
    End Sub

    Private Sub OnBrowser()
        Try
            If mv_strEXTENTION.ToUpper = "XML" Then
                Dim v_dlgOpen As New OpenFileDialog
                v_dlgOpen.Filter = "XML files (*.Xml)|*.Xml|All files (*.*)|*.*"
                v_dlgOpen.RestoreDirectory = True
                v_dlgOpen.InitialDirectory = mv_srcFilePath
                Dim v_res As DialogResult = v_dlgOpen.ShowDialog(Me)
                If v_res = DialogResult.OK Then
                    mv_srcFileName = v_dlgOpen.FileName
                    Me.txtPath.Text = mv_srcFileName
                End If
            Else
                Dim v_dlgOpen As New OpenFileDialog
                v_dlgOpen.Filter = "Excel files(2003) (*.xls)|*.xls|Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*"
                v_dlgOpen.RestoreDirectory = True
                v_dlgOpen.InitialDirectory = mv_srcFilePath
                Dim v_res As DialogResult = v_dlgOpen.ShowDialog(Me)
                If v_res = DialogResult.OK Then
                    mv_srcFileName = v_dlgOpen.FileName
                    Me.txtPath.Text = mv_srcFileName
                End If
            End If

        Catch ex As Exception
            LogError.Write("Error source: @DIRECT.frmReadFile.OnBrowser" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadDefaultData(ByVal pv_CboValue As String)
        Try
            Dim v_ws As New BDSDeliveryManagement
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_strValue, v_strFLDNAME, v_strObjMsg, v_strCmdSQL, v_strClause As String, i, j As Integer

            mv_strFileCode = pv_CboValue
            v_strCmdSQL = "SELECT FILECODE VALUE, FILECODE || ' : ' || FILENAME DISPLAY, FILECODE || ': ' || FILENAME EN_DISPLAY, " & ControlChars.CrLf _
                              & "FILECODE, EXTENTION, CMDSQL, PROCNAME, OVRRQD, OBJNAME, BANKNAME, ISSIGN, FILEPATCH, ISDIRECT " & ControlChars.CrLf _
                              & "FROM CRBFILEMASTER WHERE  VISIBLE ='N' "
            v_strClause = " AND FILECODE= '" & pv_CboValue & "'"
            v_strCmdSQL = v_strCmdSQL & v_strClause

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)

            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i = 0 To v_nodeList.Count - 1
                For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "EXTENTION"
                                mv_strEXTENTION = Trim(v_strValue)
                            Case "FILEPATCH"
                                mv_strFILEPATCH = Trim(v_strValue)
                            Case "PROCNAME"
                                mv_strPROCNAME = Trim(v_strValue)
                            Case "BANKNAME"
                                mv_strBANKNAME = Trim(v_strValue)
                            Case "ISSIGN"
                                mv_strISSIGN = Trim(v_strValue)
                                If mv_strISSIGN = "Y" Then
                                    chkIsSigner.Checked = True
                                Else
                                    chkIsSigner.Checked = False
                                End If
                            Case "OBJNAME"
                                mv_strObjName = Trim(v_strValue)
                                mv_strSaveTableName = Trim(v_strValue)
                            Case "CMDSQL"
                                mv_strCMDSQL = Trim(v_strValue)
                            Case "ISDIRECT"
                                mv_ISDIRECT = Trim(v_strValue)
                        End Select
                    End With
                Next
            Next

            Me.txtPath.Text = mv_strFILEPATCH & YYYYMMDD_FormatDate(CDate(Me.BusDate))
            mv_srcFilePath = mv_strFILEPATCH & YYYYMMDD_FormatDate(CDate(Me.BusDate))
            If Not IO.Directory.Exists(mv_srcFilePath) Then
                IO.Directory.CreateDirectory(mv_srcFilePath)
            End If

        Catch ex As Exception
            LogError.Write("Error source: @DIRECT.frmRMOfflineManager.LoadDefaultData" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'AnTB LoadDefaultData_6614
    Private Sub LoadDefaultData_6614(ByVal pv_CboValue As String)
        Try
            Dim v_ws As New BDSDeliveryManagement
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_strValue, v_strFLDNAME, v_strObjMsg, v_strCmdSQL, v_strClause As String, i, j As Integer

            Dim v_strFileCode As String = pv_CboValue
            v_strFileCode = v_strFileCode.Remove(v_strFileCode.Length - 1, 1) & "1"

            v_strCmdSQL = "SELECT FILECODE VALUE, FILECODE || ' : ' || FILENAME DISPLAY, FILECODE || ': ' || FILENAME EN_DISPLAY, " & ControlChars.CrLf _
                              & "FILECODE, EXTENTION, CMDSQL, PROCNAME, OVRRQD, OBJNAME, BANKNAME, ISSIGN, FILEPATCH, ISDIRECT " & ControlChars.CrLf _
                              & "FROM CRBFILEMASTER WHERE  VISIBLE ='N' "
            v_strClause = " AND FILECODE= '" & v_strFileCode & "'"
            v_strCmdSQL = v_strCmdSQL & v_strClause

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)

            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i = 0 To v_nodeList.Count - 1
                For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "EXTENTION"
                                mv_strEXTENTION_6614 = Trim(v_strValue)
                            Case "FILEPATCH"
                                mv_strFILEPATCH_6614 = Trim(v_strValue)
                            Case "PROCNAME"
                                mv_strPROCNAME_6614 = Trim(v_strValue)
                            Case "BANKNAME"
                                mv_strBANKNAME_6614 = Trim(v_strValue)
                            Case "ISSIGN"
                                mv_strISSIGN_6614 = Trim(v_strValue)
                            Case "OBJNAME"
                                mv_strObjName_6614 = Trim(v_strValue)
                                mv_strSaveTableName = Trim(v_strValue)
                            Case "CMDSQL"
                                mv_strCMDSQL_6614 = Trim(v_strValue)
                            Case "ISDIRECT"
                                mv_ISDIRECT_6614 = Trim(v_strValue)
                        End Select
                    End With
                Next
            Next

            Me.txtPath.Text = mv_strFILEPATCH & YYYYMMDD_FormatDate(CDate(Me.BusDate))
            mv_srcFilePath_6614 = mv_strFILEPATCH & YYYYMMDD_FormatDate(CDate(Me.BusDate))
            If Not IO.Directory.Exists(mv_srcFilePath_6614) Then
                IO.Directory.CreateDirectory(mv_srcFilePath_6614)
            End If

        Catch ex As Exception
            LogError.Write("Error source: @DIRECT.frmRMOfflineManager.OnLoadDefaultData_6614" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub LoadScreen()
        Dim v_objNode As XmlNodeDictionary
        Dim v_ws As New BDSDeliveryManagement
        Dim v_strSQL As String = String.Empty
        Dim v_strObjName, v_strObjMsg, v_strValue, v_strFLDNAME As String
        Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode
        Dim i, j As Integer
        Dim v_strXmlNodeID As String = String.Empty
        Dim v_strXmlPRNodeID As String = String.Empty
        Dim v_blnXmlLastNode As Boolean = False
        Dim v_blnXmlSumCalc As Boolean = False
        Dim v_blnIsNode As Boolean = False
        Dim v_intLevel As Integer = 0
        Dim v_strTableFldName As String = String.Empty
        Dim v_strDatatype As String = String.Empty
        Dim v_intWIDTH As Integer = 0
        Try
            v_strSQL = "SELECT FILECODE, FILEFLDNAME, PRFILEFLDNAME, FILEFLDFORMAT, LEV, LASTNODE, ISNODE, ISSUM, " & ControlChars.CrLf _
                                   & "TBLFLDNAME, TBLFLDTYPE DATATYPE, CHANGETYPE, DISABLED, VISIBLE, ISPARAM, WIDTH, FIELDDESC " & ControlChars.CrLf _
                                   & "FROM CRBFILEMAP WHERE UPPER(FILECODE) = '" & cboFileType.SelectedValue & "' ORDER BY LSTODR"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)
            InitGrid(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            If v_nodeList.Count <> 0 Then
                ReDim mv_arrObjXmlNode(v_nodeList.Count)
                For i = 0 To v_nodeList.Count - 1
                    For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            v_strValue = .InnerText.ToString
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME)
                                Case "FILEFLDNAME"
                                    v_strXmlNodeID = Trim(v_strValue)
                                Case "PRFILEFLDNAME"
                                    v_strXmlPRNodeID = Trim(v_strValue)
                                Case "LASTNODE"
                                    If Trim(v_strValue) = "Y" Then
                                        v_blnXmlLastNode = True
                                    Else
                                        v_blnXmlLastNode = False
                                    End If
                                Case "LEV"
                                    v_intLevel = CInt(v_strValue)
                                Case "TBLFLDNAME"
                                    v_strTableFldName = Trim(v_strValue)
                                Case "ISSUM"
                                    If Trim(v_strValue) = "Y" Then
                                        v_blnXmlSumCalc = True
                                    Else
                                        v_blnXmlSumCalc = False
                                    End If
                                Case "DATATYPE"
                                    v_strDatatype = Trim(v_strValue)
                                Case "WIDTH"
                                    v_intWIDTH = CInt(v_strValue)
                                Case "ISNODE"
                                    If Trim(v_strValue) = "Y" Then
                                        v_blnIsNode = True
                                    Else
                                        v_blnIsNode = False
                                    End If
                            End Select
                        End With
                    Next
                    v_objNode = New XmlNodeDictionary
                    With v_objNode
                        v_objNode.XmlNodeID = v_strXmlNodeID
                        v_objNode.XmlPRNodeID = v_strXmlPRNodeID
                        v_objNode.XmlLastNode = v_blnXmlLastNode
                        v_objNode.TableFldName = v_strTableFldName
                        v_objNode.XmlLevel = v_intLevel
                        v_objNode.XmlSumCalc = v_blnXmlSumCalc
                        v_objNode.Datatype = v_strDatatype
                        v_objNode.WIDTH = v_intWIDTH
                        v_objNode.IsNode = v_blnIsNode
                    End With
                    mv_arrObjXmlNode(i) = v_objNode
                Next
            End If
        Catch ex As Exception
            LogError.Write("Error source: @DIRECT.frmRMOfflineManager.LoadScreen" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Throw ex
        End Try
    End Sub

    'Load config to export excel BIDV, ACB giong 6614

    Public Sub LoadExportConfig()
        Dim v_objNode As XmlNodeDictionary
        Dim v_ws As New BDSDeliveryManagement
        Dim v_strSQL As String = String.Empty
        Dim v_strObjName, v_strObjMsg, v_strValue, v_strFLDNAME As String
        Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode
        Dim i, j As Integer
        Dim v_strXmlNodeID As String = String.Empty
        Dim v_strXmlPRNodeID As String = String.Empty
        Dim v_blnXmlLastNode As Boolean = False
        Dim v_blnXmlSumCalc As Boolean = False
        Dim v_blnIsNode As Boolean = False
        Dim v_intLevel As Integer = 0
        Dim v_strTableFldName As String = String.Empty
        Dim v_strDatatype As String = String.Empty
        Dim v_intWIDTH As Integer = 0
        Dim v_strFileCode As String = cboFileType.SelectedValue
        v_strFileCode = v_strFileCode.Remove(v_strFileCode.Length - 1, 1) & "1"
        Try
            v_strSQL = "SELECT FILECODE, FILEFLDNAME, PRFILEFLDNAME, FILEFLDFORMAT, LEV, LASTNODE, ISNODE, ISSUM, " & ControlChars.CrLf _
                                   & "TBLFLDNAME, TBLFLDTYPE DATATYPE, CHANGETYPE, DISABLED, VISIBLE, ISPARAM, WIDTH, FIELDDESC " & ControlChars.CrLf _
                                   & "FROM CRBFILEMAP WHERE UPPER(FILECODE) = '" & v_strFileCode & "' ORDER BY LSTODR"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            If v_nodeList.Count <> 0 Then
                ReDim mv_arrObjXmlNode_6614(v_nodeList.Count)
                For i = 0 To v_nodeList.Count - 1
                    For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            v_strValue = .InnerText.ToString
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME)
                                Case "FILEFLDNAME"
                                    v_strXmlNodeID = Trim(v_strValue)
                                Case "PRFILEFLDNAME"
                                    v_strXmlPRNodeID = Trim(v_strValue)
                                Case "LASTNODE"
                                    If Trim(v_strValue) = "Y" Then
                                        v_blnXmlLastNode = True
                                    Else
                                        v_blnXmlLastNode = False
                                    End If
                                Case "LEV"
                                    v_intLevel = CInt(v_strValue)
                                Case "TBLFLDNAME"
                                    v_strTableFldName = Trim(v_strValue)
                                Case "ISSUM"
                                    If Trim(v_strValue) = "Y" Then
                                        v_blnXmlSumCalc = True
                                    Else
                                        v_blnXmlSumCalc = False
                                    End If
                                Case "DATATYPE"
                                    v_strDatatype = Trim(v_strValue)
                                Case "WIDTH"
                                    v_intWIDTH = CInt(v_strValue)
                                Case "ISNODE"
                                    If Trim(v_strValue) = "Y" Then
                                        v_blnIsNode = True
                                    Else
                                        v_blnIsNode = False
                                    End If
                            End Select
                        End With
                    Next
                    v_objNode = New XmlNodeDictionary
                    With v_objNode
                        v_objNode.XmlNodeID = v_strXmlNodeID
                        v_objNode.XmlPRNodeID = v_strXmlPRNodeID
                        v_objNode.XmlLastNode = v_blnXmlLastNode
                        v_objNode.TableFldName = v_strTableFldName
                        v_objNode.XmlLevel = v_intLevel
                        v_objNode.XmlSumCalc = v_blnXmlSumCalc
                        v_objNode.Datatype = v_strDatatype
                        v_objNode.WIDTH = v_intWIDTH
                        v_objNode.IsNode = v_blnIsNode
                    End With
                    mv_arrObjXmlNode_6614(i) = v_objNode
                Next
            End If
        Catch ex As Exception
            LogError.Write("Error source: @DIRECT.frmRMOfflineManager.LoadExportConfig" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Throw ex
        End Try
    End Sub


    Private Sub LoadComboBox()
        Dim v_ws As New BDSDeliveryManagement
        Dim v_strCmdSQL As String, v_strObjMsg As String
        Try
            If mv_strBANKNAME.Length > 0 Then
                v_strCmdSQL = "SELECT BANKCODE VALUE, BANKNAME DISPLAY, BANKNAME EN_DISPLAY " & ControlChars.CrLf _
                                  & "FROM CRBDEFBANK WHERE ROOTCODE = '" & mv_strBANKNAME & "'"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
                v_ws.Message(v_strObjMsg)
                'Load Combo cboBankName
                FillComboEx(v_strObjMsg, cboBankName, "", Me.UserLanguage)
            End If
            If Not IsImport Then
                If mv_strBANKNAME.Length > 0 Then
                    If mv_strBANKNAME = "PNB" Then
                        v_strCmdSQL = "SELECT VARVALUE VALUE, VARVALUE || ': ' || VARDESC DISPLAY, VARVALUE || ': ' || EN_VARDESC EN_DISPLAY, LSTODR, ISUSER " & ControlChars.CrLf _
                                 & "FROM BANKPARAMS WHERE ISUSER='Y' AND GRNAME ='RM' AND VARNAME = 'TRANCODE' AND REFVARVALUE = '" & mv_strBANKNAME & "'"
                    ElseIf mv_strBANKNAME = "ACB" Then
                        v_strCmdSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, LSTODR " & ControlChars.CrLf _
                                & " FROM  ALLCODE WHERE CDNAME='MSGDORC' AND CDVAL='ALL'"
                    Else
                        v_strCmdSQL = "SELECT VARVALUE VALUE, VARVALUE || ': ' || VARDESC DISPLAY, VARVALUE || ': ' || EN_VARDESC EN_DISPLAY, LSTODR, ISUSER " & ControlChars.CrLf _
                                 & "FROM BANKPARAMS WHERE ISUSER='Y' AND GRNAME ='RM' AND VARNAME = 'TRANCODE' AND REFVARVALUE = '" & mv_strBANKNAME & "'"
                    End If

                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
                    v_ws.Message(v_strObjMsg)
                    'Load Combo cboTranCode
                    FillComboEx(v_strObjMsg, cboTranCode, "", Me.UserLanguage)
                End If
            End If

            'Load combo status
            v_strCmdSQL = "SELECT TBLFLDNAME VALUE, FIELDDESC DISPLAY, FIELDDESC EN_DISPLAY FROM CRBFILEMAP WHERE FILECODE ='" & cboFileType.SelectedValue & "' AND ISSRCH='Y'"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            FillComboEx(v_strObjMsg, cboCondition, "", Me.UserLanguage)

        Catch ex As Exception
            LogError.Write("Error source: @DIRECT.frmRMOfflineManager.LoadComboBox" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Throw ex
        End Try
    End Sub

    Private Function OnLoadData() As Long
        Dim v_lngReturn As Long
        Dim v_ws As New BDSDeliveryManagement
        Dim v_strCmdSQL As String, v_strObjMsg As String
        Dim v_xmlDocument As New XmlDocumentEx
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strValue As String = ""
        Dim v_strFLDNAME As String = ""
        Dim v_strFormat As String = ""
        Dim v_dtCurrdate As Date = CDate(Me.BusDate)
        Dim v_strCurrdate As String = ""

        Try

            SearchGrid.Clear()
            'Chua chon file du lieu
            If Me.txtPath.Text.Trim.Length = 0 Or InStr(Me.txtPath.Text.Trim.ToUpper, mv_strEXTENTION.ToUpper) = 0 Then
                MessageBox.Show(mv_ResourceManager.GetString("msg_Please_Choose_File").Replace("@", mv_strEXTENTION), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.ActiveControl = Me.btnBrowse
                Return ERR_SYSTEM_START
                Exit Function
            End If
            'AnTB add phan check ngay cua file dau ngay
            v_strCmdSQL = "SELECT * FROM SYSVAR WHERE GRNAME = 'CRBOFFLINE' AND VARNAME = '" & mv_strBANKNAME & "DATEFORMAT'"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            For i As Integer = 0 To v_nodeList.Count - 1
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "VARVALUE"
                                v_strFormat = v_strValue.Trim()
                        End Select
                    End With
                Next
            Next
            'PNB file import dau ngay, ngay cua file = ngay hien tai - 1
            If mv_strBANKNAME = "PNB" Then
                v_dtCurrdate = CDate(Me.BusDate).AddDays(-1)
            End If

            v_strCurrdate = v_dtCurrdate.ToString(v_strFormat).Trim.ToUpper
            Dim v_arrFileName() As String = Me.txtPath.Text.Trim.ToUpper.Split("\")
            Dim v_strFileName As String = v_arrFileName(v_arrFileName.Length - 1)
            If Not v_strFileName.Contains(v_strCurrdate) Then
                MessageBox.Show(mv_ResourceManager.GetString("msg_Invalid_Import_File_Date"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.ActiveControl = Me.btnBrowse
                Return ERR_SYSTEM_START
                Exit Function
            End If

            If mv_strEXTENTION.ToUpper = "XML" Then
                v_lngReturn = OnLoadXmlData()
            Else
                v_lngReturn = OnLoadExcelData()
            End If
            If v_lngReturn = ERR_SYSTEM_OK Then
                mv_blnIsAllowSave = True
            End If

            Dim v_xColumn As Xceed.Grid.Column
            Dim v_strFNTxdate As String = String.Empty
            For Each v_xColumn In SearchGrid.Columns

                If v_xColumn.Title = "TXDATE" Then
                    v_strFNTxdate = v_xColumn.FieldName
                End If

            Next
            'Gan noi dung
            For i As Integer = 0 To SearchGrid.DataRows.Count - 1
                With SearchGrid.DataRows(i)

                    If Not v_strFNTxdate = String.Empty Then

                        '24/04/2017 DieuNDA: fix loi sai truong ngay thang khong vi phai vi tri dau tien
                        'If Not .Cells(1).Value() Is DBNull.Value Then
                        'If Not .Cells(1).Value() = Me.BusDate Then
                        If Not .Cells(v_strFNTxdate).Value() = Me.BusDate Then
                            MessageBox.Show(mv_ResourceManager.GetString("msg_Invalid_Import_File_Date"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Me.ActiveControl = Me.btnBrowse
                            Return ERR_SYSTEM_START
                            Exit Function
                        End If
                    End If
                End With
            Next


        Catch ex As Exception
            LogError.Write("Error source: @DIRECT.frmRMOfflineManager.OnLoadData" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Throw ex
        End Try

    End Function

    Private Function OnLoadXmlData() As Long

        Dim v_xmlBankDocument, pv_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList

        Dim v_strCmdSQL, v_strObjMsg, v_strFLDNAME, v_strFLDVALUE, v_strFLDTYPE As String
        Dim v_ws As New BDSDeliveryManagement
        Dim v_strScid, v_strBatchSigner, v_strBatchReceiver As String
        Dim v_strUserIDKey, v_strAccessKey, v_strPrivateKey As String
        Dim v_strSigner, v_strZip As String

        Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
        Dim v_strSTATUS As String
        Dim v_xmlDoc As New XmlDocument

        Try
            'Lay thong tin co ban
            If chkIsSigner.Checked = True Then
                v_strCmdSQL = "SELECT USERIDKEY, SIGNER, RECEIVER " & ControlChars.CrLf _
                            & "FROM CRBDEFBANK " & ControlChars.CrLf _
                            & "WHERE BANKCODE = '" & cboBankName.SelectedValue & "'"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_AFMAST, gc_ActionInquiry, v_strCmdSQL)
                v_ws.Message(v_strObjMsg)
                pv_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                For i As Integer = 0 To v_nodeList.Count - 1
                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        v_strFLDNAME = CStr(CType(v_nodeList.Item(i).ChildNodes(j).Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strFLDVALUE = v_nodeList.Item(i).ChildNodes(j).InnerText
                        Select Case v_strFLDNAME
                            Case "USERIDKEY"
                                v_strUserIDKey = v_strFLDVALUE
                            Case "SIGNER"  'BatchSigner
                                v_strAccessKey = v_strFLDVALUE
                            Case "RECEIVER" 'BatchReceiver
                                v_strPrivateKey = v_strFLDVALUE
                        End Select
                    Next
                Next
            End If

            'Doc file xml
            v_xmlBankDocument.Load(mv_srcFileName)

            'check SIGNER
            v_strSigner = v_xmlBankDocument.SelectSingleNode("DOCUMENT/SIGNER").InnerText
            If (v_strSigner <> v_strPrivateKey) Then
                MessageBox.Show(mv_ResourceManager.GetString("msg_Bank_BranchID_Not_The_Same"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.ActiveControl = Me.btnBrowse
                Return ERR_SYSTEM_START
                Exit Function
            End If

            'doc Zip data
            v_strZip = v_xmlBankDocument.SelectSingleNode("DOCUMENT/ZIP").InnerText
            v_strZip = CommonLibrary.ZipUtils.UnZipData(v_strZip)



            Dim v_strFunctionName As String = "SyncDataFromBIDVFile"
            mv_strObjName = "RM.CRB_OFFLINE_SYN"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , Me.TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, mv_strObjName, gc_ActionAdhoc, , mv_strFileCode, v_strFunctionName, , , v_strZip, "N")
            v_ws.Message(v_strObjMsg)
            v_xmlDoc.LoadXml(v_strObjMsg)

            If v_lngError <> ERR_SYSTEM_OK Then
                'Thong bao loi
                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage)
                Cursor.Current = Cursors.Default
                MessageBox.Show(v_strErrorMessage)
                Return v_lngError
                Exit Function
            Else
                InitGrid()
                OnSearch(mv_strCMDSQL)
            End If

            OnReConfigButton()
            Return ERR_SYSTEM_OK

        Catch ex As Exception
            LogError.Write("Error source: @DIRECT.frmRMOfflineManager.OnLoadXmlData" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return ERR_SYSTEM_START
        End Try
    End Function

    Private Function OnLoadExcelData() As Long
        Try
            If Me.txtPath.Text.Trim.Length = 0 Then
                MessageBox.Show(mv_ResourceManager.GetString("msg_Please_Choose_File").Replace("@", mv_strEXTENTION))
                Me.ActiveControl = Me.btnBrowse
                Exit Function
            End If

            SearchGrid = New GridEx
            Dim v_cmrContactsHeader As New Xceed.Grid.ColumnManagerRow
            v_cmrContactsHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
            v_cmrContactsHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            SearchGrid.FixedHeaderRows.Add(v_cmrContactsHeader)

            Dim xlApp As Excel.Application
            Dim xlWorkBook As Excel.Workbook
            Dim xlWorkSheet As Excel.Worksheet
            Dim range As Excel.Range
            Dim rCnt As Integer
            Dim cCnt As Integer
            Dim Obj As Object
            Dim v_xColumn As Xceed.Grid.Column
            'Chuyen doi cau hinh User Account Windows theo cau hinh cua Office
            Dim oldCI As Globalization.CultureInfo
            oldCI = System.Threading.Thread.CurrentThread.CurrentCulture
            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

            xlApp = New Excel.Application
            xlWorkBook = xlApp.Workbooks.Open(mv_srcFileName)
            If xlWorkBook Is Nothing Then
                MessageBox.Show(mv_ResourceManager.GetString("msg_PathFile_Invalid"))
                Me.ActiveControl = Me.btnBrowse
                Return ERR_SYSTEM_START
                Exit Function
            End If

            xlWorkSheet = xlWorkBook.Worksheets(CInt(mv_strSHEETNAME))

            range = xlWorkSheet.UsedRange
            If range.Columns.Count > 0 And range.Rows.Count > 1 Then
                For cCnt = 1 To range.Columns.Count
                    If Not CType(range.Cells(mv_intROWTITLE, cCnt), Excel.Range).Value Is Nothing Then
                        SearchGrid.Columns.Add(New Xceed.Grid.Column(cCnt.ToString, GetType(System.String)))
                        SearchGrid.Columns(cCnt.ToString).Title = gf_CorrectStringField(CType(range.Cells(mv_intROWTITLE, cCnt), Excel.Range).Value).Trim
                        SearchGrid.Columns(cCnt.ToString).HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
                        SearchGrid.Columns(cCnt.ToString).Width = 100
                    End If
                Next
            End If

            'InitGrid()

            SearchGrid.DataRows.Clear()
            SearchGrid.BeginInit()

            If range.Rows.Count >= mv_intROWTITLE + 1 Then
                For rCnt = mv_intROWTITLE + 1 To range.Rows.Count
                    Dim v_xDataRow As Xceed.Grid.DataRow = SearchGrid.DataRows.AddNew()
                    For Each v_xColumn In SearchGrid.Columns
                        v_xDataRow.Cells(v_xColumn.FieldName).Value = gf_CorrectStringField(CType(range.Cells(rCnt, CInt(v_xColumn.FieldName)), Excel.Range).Value)
                    Next
                    v_xDataRow.EndEdit()
                Next
            End If
            Dim msg_Read_From_File As String
            msg_Read_From_File = mv_ResourceManager.GetString("msg_Read_From_File")
            msg_Read_From_File = msg_Read_From_File.Replace("@", range.Rows.Count - mv_intROWTITLE)
            Dim v_frSearchGrid = New Xceed.Grid.TextRow(msg_Read_From_File)
            v_frSearchGrid.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
            v_frSearchGrid.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic)
            SearchGrid.FixedFooterRows.Clear()
            SearchGrid.FixedFooterRows.Add(v_frSearchGrid)

            SearchGrid.EndInit()
            xlWorkBook.Close()
            xlApp.Quit()

            ReleaseObject(xlApp)
            ReleaseObject(xlWorkBook)
            ReleaseObject(xlWorkSheet)

            Me.pnsSearchResult.Controls.Clear()
            Me.pnsSearchResult.Controls.Add(SearchGrid)
            SearchGrid.Dock = System.Windows.Forms.DockStyle.Fill
            'Tra lai cau hinh User Account Windows theo mac dinh cua chuong trinh
            System.Threading.Thread.CurrentThread.CurrentCulture = oldCI

            Return ERR_SYSTEM_OK
        Catch ex As Exception
            LogError.Write("Error source: @DIRECT.frmRMOfflineManager.OnLoadExcelData" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            'MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            MessageBox.Show(mv_ResourceManager.GetString("msg_Format_File_Invalid"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return ERR_SYSTEM_START
        End Try
    End Function

    Private Sub ReleaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Sub OnClose()
        Me.Dispose()
    End Sub

    Private Function ExportToFile() As Int32
        Dim v_lngError As Long = ERR_SYSTEM_OK
        Dim v_strFunctionName As String
        Dim v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement
        Dim v_strBankCode As String
        Dim v_strVersion As String
        Dim v_strTxDate As String
        Dim v_strExp As String = String.Empty
        Dim v_attrColl As Xml.XmlAttributeCollection
        Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument

        Try
            mv_strObjName = "RM.CRB_OFFLINE_SYN"

            ''Tao Key cho lan Export
            'v_strFunctionName = "GEN_IDKEY"
            'v_strObjMsg = BuildXMLObjMsg(, BranchId, , Me.TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, mv_strObjName, gc_ActionAdhoc, , , v_strFunctionName, , , , v_strTxDate)
            'v_ws.Message(v_strObjMsg)
            'v_xmlDocument.LoadXml(v_strObjMsg)
            'v_attrColl = v_xmlDocument.DocumentElement.Attributes
            'mv_strKeyValue = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeRESERVER), Xml.XmlAttribute).Value)

            If mv_strEXTENTION.ToUpper = "XML" Then
                v_lngError = ExportToXML()
            Else
                v_lngError = ExportToExcel()
            End If

            If v_lngError = ERR_SYSTEM_OK Then
                ''Cap nhat Batchid và Trang thai 'ES' luc xuat bang ke
                v_strFunctionName = "UpdateInfoAftExport"
                v_strTxDate = Me.BusDate

                v_strObjMsg = BuildXMLObjMsg(v_strTxDate, BranchId, , Me.TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, mv_strObjName, gc_ActionAdhoc, , mv_arrAutoID, v_strFunctionName, , , mv_strFileName)
                v_ws.Message(v_strObjMsg)

                'Xuat ra excel file xml
                If mv_strEXTENTION.ToUpper = "XML" Then
                    OnLoadExportExcel(mv_strCMDSQL_6614)
                    ExportToExcel_6614()
                End If

                MsgBox(mv_ResourceManager.GetString("msg_Export_Data_Complete"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            Else

            End If

            mv_arrAutoID = String.Empty
            Return v_lngError


        Catch ex As Exception
            LogError.Write("Error source: @DIRECT.frmRMOfflineManager.ExportToFile" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            v_lngError = ERR_SYSTEM_START
            mv_arrAutoID = ""
            Return v_lngError
        End Try

    End Function

    Protected Function ExportToExcel() As Int32
        Dim v_lngError As Long = ERR_SYSTEM_OK
        Try
            Dim v_dlgSave As New SaveFileDialog
            Dim v_strTemp As String
            v_dlgSave.Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*"
            Dim v_intIndex As Integer
            'Dim v_res As DialogResult = v_dlgSave.ShowDialog(Me)
            Dim v_NodeItem, v_fldName, v_fldValue As String
            Dim v_dblTotalAmount As Double
            Dim v_intTotalNameCol As Integer
            Dim v_intTotalAmountCol As Integer
            Dim v_dblTotalName As String
            Dim v_intTotalRow As String
            Dim v_FileFullPath As String = "D:\EXPORT\PNB.xsl"
            Dim v_intFile As Integer = 1
            Dim v_strFileName
            If (SearchGrid.DataRows.Count = 0) Then
                MsgBox(mv_ResourceManager.GetString("msg_Do_Not_Data_To_Export"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                v_lngError = ERR_SYSTEM_START
                Return v_lngError
            End If

            v_strFileName = cboTranCode.SelectedValue & YYYYMMDD_FormatDate(Me.BusDate).ToString
            v_strFileName = txtPath.Text & "\" & v_strFileName
            v_FileFullPath = chkExistFile(v_strFileName, v_intFile, mv_strEXTENTION)
            v_strFileName = v_FileFullPath

            mv_strFileName = v_strFileName

            If v_intFile > 1 Then
                If MsgBox(mv_ResourceManager.GetString("msg_File_Does_Exist").Replace("@", v_intFile - 1), MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    v_lngError = ERR_SYSTEM_START
                    Return v_lngError
                End If
            End If

            mv_arrAutoID = String.Empty

            If UCase(Mid(v_FileFullPath, Len(v_FileFullPath) - 3)) <> ".XLS" Then
                Dim v_strData As String
                Dim v_streamWriter As New StreamWriter(v_FileFullPath, False, System.Text.Encoding.Unicode)

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
                        If SearchGrid.DataRows(i).Cells("__TICK").Value = "X" Then
                            mv_arrAutoID &= SearchGrid.DataRows(i).Cells("DTLAUTOID").Value.ToString.Trim & "|"
                            v_strData = String.Empty
                            For j As Integer = 0 To SearchGrid.DataRows(i).Cells.Count - 1
                                If SearchGrid.Columns(j).Visible Then
                                    v_strTemp = "@" & CStr(SearchGrid.DataRows(i).Cells(j).Value)
                                    v_strData &= v_strTemp & vbTab
                                End If
                            Next
                            'Write data to the file
                            v_streamWriter.WriteLine(v_strData)
                        End If
                    Next
                Else
                    MsgBox(mv_ResourceManager.GetString("msg_Do_Not_Data_To_Export"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    v_lngError = ERR_SYSTEM_START
                    Return v_lngError
                End If

                'Close StreamWriter
                v_streamWriter.Close()
            Else

                'Ghi file excel
                'Chuyen doi cau hinh User Account Windows theo cau hinh cua Office
                Dim oldCI As Globalization.CultureInfo
                oldCI = System.Threading.Thread.CurrentThread.CurrentCulture
                System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")


                Dim objExcel As Excel.Application ' Excel object
                Dim objWorkbook As Excel.Workbook 'Workbook object 
                Dim objWorksheet As Excel.Worksheet 'Worksheet object 


                objExcel = CreateObject("Excel.Application")
                'Add a new workbook 
                objWorkbook = objExcel.Workbooks.Add()

                'Set the Wwrksheet object to the sheet in the workbook you want to use 
                'Note: You can use an Index number as well as specifying the name of the sheet 
                objWorksheet = objWorkbook.ActiveSheet() 'CType(objWorkbook.Worksheets.Item("Sheet1"), Excel.Worksheet)

                Dim varInt_StartRow As Integer
                If System.IO.File.Exists(v_FileFullPath) = True Then 'Check to see if file exists
                    objWorkbook = objExcel.Workbooks.Open(v_FileFullPath)
                    objWorksheet = objWorkbook.ActiveSheet() 'objWorkbook.Worksheets.Item("Sheet1")

                    'Find last empty cell
                    varInt_StartRow = objWorksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row
                Else
                    varInt_StartRow = 0
                End If
                If (SearchGrid.DataRows.Count > 0) Then
                    Dim i, j As Integer
                    'Write header
                    If mv_arrObjXmlNode.GetLength(0) > 0 Then
                        For v_intIndex = 0 To mv_arrObjXmlNode.GetLength(0) - 1 Step 1
                            If mv_arrObjXmlNode(v_intIndex).XmlLastNode = True Then
                                'CType(objWorksheet.Cells(1, i + 1), Excel.Range).EntireColumn.NumberFormat = "@"
                                With objWorksheet.Range(objWorksheet.Cells(1, i + 1), objWorksheet.Cells(1, i + 1))
                                    .Value = mv_arrObjXmlNode(v_intIndex).XmlNodeID
                                    .Font.Size = 10
                                    .Font.Name = "VNI-Times"
                                    .Font.Bold = True
                                    '.VerticalAlignment = Excel.Constants.xlTop
                                    '.HorizontalAlignment = Excel.Constants.xlCenter
                                    .Select()
                                    i = i + 1
                                End With
                            Else
                                Exit For
                            End If
                        Next
                    End If

                    'Write data
                    For j = 0 To SearchGrid.DataRows.Count - 1
                        If SearchGrid.DataRows(j).Cells("__TICK").Value = "X" Then
                            mv_arrAutoID &= SearchGrid.DataRows(j).Cells("DTLAUTOID").Value.ToString.Trim & "|"
                            i = 0
                            If mv_arrObjXmlNode.GetLength(0) > 0 Then
                                For v_intIndex = 0 To mv_arrObjXmlNode.GetLength(0) - 1 Step 1
                                    If mv_arrObjXmlNode(v_intIndex).XmlLastNode = True Then
                                        v_NodeItem = mv_arrObjXmlNode(v_intIndex).XmlNodeID.Trim
                                        v_fldName = mv_arrObjXmlNode(v_intIndex).TableFldName.Trim
                                        If v_fldName.Length <> 0 Then
                                            v_fldValue = ""
                                            If SearchGrid.DataRows(j).Cells(v_fldName).Value IsNot Nothing Then
                                                v_fldValue = SearchGrid.DataRows(j).Cells(v_fldName).Value.ToString.Trim
                                            End If
                                        End If

                                        If mv_arrObjXmlNode(v_intIndex).Datatype = "C" Then
                                            With objWorksheet.Range(objWorksheet.Cells(j + 2, i + 1), objWorksheet.Cells(j + 2, i + 1))
                                                .Value = "'" & v_fldValue
                                                .Font.Size = 10
                                                .Font.Name = "VNI-Times"
                                                '.NumberFormat = "@"
                                            End With
                                        ElseIf mv_arrObjXmlNode(v_intIndex).Datatype = "N" Then
                                            v_fldValue = IIf(v_fldValue.Length > 0, v_fldValue, 0)
                                            With objWorksheet.Range(objWorksheet.Cells(j + 2, i + 1), objWorksheet.Cells(j + 2, i + 1))
                                                .Value = CDbl(v_fldValue)
                                                .Font.Size = 10
                                                .Font.Name = "VNI-Times"
                                                '.NumberFormat = "0"
                                            End With
                                        End If

                                        'Lay thong tin de chuan bi buil row tong cong
                                        If mv_arrObjXmlNode(v_intIndex).XmlSumCalc Then
                                            If mv_arrObjXmlNode(v_intIndex).Datatype = "C" Then
                                                v_dblTotalName = mv_arrObjXmlNode(v_intIndex).XmlPRNodeID
                                                v_intTotalNameCol = i + 1
                                            ElseIf mv_arrObjXmlNode(v_intIndex).Datatype = "N" Then
                                                v_dblTotalAmount += CDbl(v_fldValue)
                                                v_intTotalAmountCol = i + 1
                                            End If
                                        End If
                                        i = i + 1
                                    Else
                                        Exit For
                                    End If
                                Next
                                v_intTotalRow = j
                            End If
                        End If
                    Next

                    'Write Sum
                    If Me.chkisSum.Checked Then
                        v_intTotalRow += 3
                        'Write Name
                        With objWorksheet.Range(objWorksheet.Cells(v_intTotalRow, v_intTotalNameCol), objWorksheet.Cells(v_intTotalRow, v_intTotalNameCol))
                            .Value = v_dblTotalName
                            '.NumberFormat = "@"
                            .Font.Size = 10
                            .Font.Name = "VNI-Times"
                            .Font.Bold = True
                        End With

                        'Write Value
                        With objWorksheet.Range(objWorksheet.Cells(v_intTotalRow, v_intTotalAmountCol), objWorksheet.Cells(v_intTotalRow, v_intTotalAmountCol))
                            .Value = CDbl(v_dblTotalAmount)
                            '.NumberFormat = "0"
                            .Font.Size = 10
                            .Font.Name = "VNI-Times"
                            .Font.Bold = True
                        End With
                    End If

                    'Save workbook before closing
                    'objExcel.SaveWorkspace(v_FileFullPath)
                    objWorkbook.SaveAs(v_FileFullPath, Excel.XlFileFormat.xlExcel5)

                Else
                    MsgBox(mv_ResourceManager.GetString("msg_Do_Not_Data_To_Export"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    Exit Function
                End If

                'Close the workbook and Excel 
                objWorkbook.Close(True, "", Nothing)
                objWorkbook = Nothing
                objExcel.Quit()
                System.Runtime.InteropServices.Marshal.ReleaseComObject(objExcel)
                objExcel = Nothing

                'Tra lai cau hinh User Account Windows theo mac dinh cua chuong trinh
                System.Threading.Thread.CurrentThread.CurrentCulture = oldCI



            End If


            'MsgBox(mv_ResourceManager.GetString("msg_Export_Data_Complete"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            Return v_lngError


        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            v_lngError = ERR_SYSTEM_START
            Return v_lngError
        End Try
    End Function

    Protected Function ExportGridToExcel() As Int32
        Dim v_lngError As Long = ERR_SYSTEM_OK
        Try
            Dim v_dlgSave As New SaveFileDialog
            Dim v_strTemp As String
            v_dlgSave.Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*"
            Dim v_intIndex As Integer
            'Dim v_res As DialogResult = v_dlgSave.ShowDialog(Me)
            Dim v_NodeItem, v_fldName, v_fldValue As String
            Dim v_dblTotalAmount As Double
            Dim v_intTotalNameCol As Integer
            Dim v_intTotalAmountCol As Integer
            Dim v_dblTotalName As String
            Dim v_intTotalRow As String
            Dim v_FileFullPath As String = "D:\EXPORT\Grid.xsl"
            Dim v_intFile As Integer = 1
            Dim v_strFileName
            If (SearchGrid.DataRows.Count = 0) Then
                MsgBox(mv_ResourceManager.GetString("msg_Do_Not_Data_To_Export"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                v_lngError = ERR_SYSTEM_START
                Return v_lngError
            End If
            v_strFileName = cboTranCode.SelectedValue & YYYYMMDD_FormatDate(Me.BusDate).ToString

            Dim fbd As New FolderBrowserDialog
            If fbd.ShowDialog = Windows.Forms.DialogResult.OK Then
                v_strFileName = fbd.SelectedPath & "\" & v_strFileName
            Else
                Return v_lngError
            End If



            v_FileFullPath = chkExistFile(v_strFileName, v_intFile, mv_strEXTENTION)
            v_strFileName = v_FileFullPath

            mv_strFileName = v_strFileName

            If v_intFile > 1 Then
                If MsgBox(mv_ResourceManager.GetString("msg_File_Does_Exist").Replace("@", v_intFile - 1), MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    v_lngError = ERR_SYSTEM_START
                    Return v_lngError
                End If
            End If

            mv_arrAutoID = String.Empty

            If UCase(Mid(v_FileFullPath, Len(v_FileFullPath) - 3)) <> ".XLS" Then
                Dim v_strData As String
                Dim v_streamWriter As New StreamWriter(v_FileFullPath, False, System.Text.Encoding.Unicode)

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
                        If SearchGrid.DataRows(i).Cells("__TICK").Value = "X" Then
                            ' mv_arrAutoID &= SearchGrid.DataRows(i).Cells("DTLAUTOID").Value.ToString.Trim & "|"
                            v_strData = String.Empty
                            For j As Integer = 0 To SearchGrid.DataRows(i).Cells.Count - 1
                                If SearchGrid.Columns(j).Visible Then
                                    v_strTemp = "@" & CStr(SearchGrid.DataRows(i).Cells(j).Value)
                                    v_strData &= v_strTemp & vbTab
                                End If
                            Next
                            'Write data to the file
                            v_streamWriter.WriteLine(v_strData)
                        End If
                    Next
                Else
                    MsgBox(mv_ResourceManager.GetString("msg_Do_Not_Data_To_Export"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    v_lngError = ERR_SYSTEM_START
                    Return v_lngError
                End If

                'Close StreamWriter
                v_streamWriter.Close()
            Else

                'Ghi file excel
                'Chuyen doi cau hinh User Account Windows theo cau hinh cua Office
                Dim oldCI As Globalization.CultureInfo
                oldCI = System.Threading.Thread.CurrentThread.CurrentCulture
                System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")


                Dim objExcel As Excel.Application ' Excel object
                Dim objWorkbook As Excel.Workbook 'Workbook object 
                Dim objWorksheet As Excel.Worksheet 'Worksheet object 


                objExcel = CreateObject("Excel.Application")
                'Add a new workbook 
                objWorkbook = objExcel.Workbooks.Add()

                'Set the Wwrksheet object to the sheet in the workbook you want to use 
                'Note: You can use an Index number as well as specifying the name of the sheet 
                objWorksheet = objWorkbook.ActiveSheet() 'CType(objWorkbook.Worksheets.Item("Sheet1"), Excel.Worksheet)

                Dim varInt_StartRow As Integer
                If System.IO.File.Exists(v_FileFullPath) = True Then 'Check to see if file exists
                    objWorkbook = objExcel.Workbooks.Open(v_FileFullPath)
                    objWorksheet = objWorkbook.ActiveSheet() 'objWorkbook.Worksheets.Item("Sheet1")

                    'Find last empty cell
                    varInt_StartRow = objWorksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row
                Else
                    varInt_StartRow = 0
                End If
                If (SearchGrid.DataRows.Count > 0) Then
                    Dim i, j As Integer
                    ' Write(header)
                    If SearchGrid.Columns.Count > 0 Then
                        For v_intIndex = 1 To SearchGrid.Columns.Count - 1 Step 1

                            With objWorksheet.Range(objWorksheet.Cells(1, v_intIndex), objWorksheet.Cells(1, v_intIndex))
                                .Value = SearchGrid.Columns(v_intIndex).FieldName.ToString()
                                .Font.Size = 10
                                .Font.Name = "VNI-Times"
                                .Font.Bold = True
                                '.VerticalAlignment = Excel.Constants.xlTop
                                '.HorizontalAlignment = Excel.Constants.xlCenter
                                .Select()
                                i = i + 1
                            End With

                        Next
                    End If

                    'Write data
                    For j = 0 To SearchGrid.DataRows.Count - 1
                        ' If SearchGrid.DataRows(j).Cells("__TICK").Value = "X" Then
                        ' mv_arrAutoID &= SearchGrid.DataRows(j).Cells("DTLAUTOID").Value.ToString.Trim & "|"
                        i = 0
                        If SearchGrid.DataRows(j).Cells.Count > 0 Then
                            For v_intIndex = 1 To SearchGrid.DataRows(j).Cells.Count - 1 Step 1
                                If SearchGrid.DataRows(j).Cells(v_intIndex).Value IsNot Nothing Then
                                    v_fldValue = SearchGrid.DataRows(j).Cells(v_intIndex).Value.ToString.Trim
                                End If

                                With objWorksheet.Range(objWorksheet.Cells(j + 2, v_intIndex), objWorksheet.Cells(j + 2, v_intIndex))
                                    .Value = "'" & v_fldValue
                                    .Font.Size = 10
                                    .Font.Name = "VNI-Times"
                                    '.NumberFormat = "@"
                                End With
                            Next
                            v_intTotalRow = j
                        End If
                        'End If
                    Next




                    objWorkbook.SaveAs(v_FileFullPath, Excel.XlFileFormat.xlExcel5)

                Else
                    MsgBox(mv_ResourceManager.GetString("msg_Do_Not_Data_To_Export"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    Exit Function
                End If

                'Close the workbook and Excel 
                objWorkbook.Close(True, "", Nothing)
                objWorkbook = Nothing
                objExcel.Quit()
                System.Runtime.InteropServices.Marshal.ReleaseComObject(objExcel)
                objExcel = Nothing

                'Tra lai cau hinh User Account Windows theo mac dinh cua chuong trinh
                System.Threading.Thread.CurrentThread.CurrentCulture = oldCI



            End If


            'MsgBox(mv_ResourceManager.GetString("msg_Export_Data_Complete"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            Return v_lngError


        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            v_lngError = ERR_SYSTEM_START
            Return v_lngError
        End Try
    End Function

    'AnTB Them Export giong 6614 cho BIDV, ACB
    Protected Function ExportToExcel_6614() As Int32
        Dim v_lngError As Long = ERR_SYSTEM_OK
        Try
            Dim v_dlgSave As New SaveFileDialog
            Dim v_strTemp As String
            v_dlgSave.Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*"
            Dim v_intIndex As Integer
            'Dim v_res As DialogResult = v_dlgSave.ShowDialog(Me)
            Dim v_NodeItem, v_fldName, v_fldValue As String
            Dim v_dblTotalAmount As Double
            Dim v_intTotalNameCol As Integer
            Dim v_intTotalAmountCol As Integer
            Dim v_dblTotalName As String
            Dim v_intTotalRow As String
            Dim v_FileFullPath As String = "D:\EXPORT\PNB.xsl"
            Dim v_intFile As Integer = 1
            Dim v_strFileName
            If (mv_ds.Tables(0).Rows.Count = 0) Then
                MsgBox(mv_ResourceManager.GetString("msg_Do_Not_Data_To_Export"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                v_lngError = ERR_SYSTEM_START
                Return v_lngError
            End If

            v_strFileName = cboTranCode.SelectedValue & YYYYMMDD_FormatDate(Me.BusDate).ToString
            v_strFileName = txtPath.Text & "\" & v_strFileName
            v_FileFullPath = chkExistFile(v_strFileName, v_intFile, "XLS")
            v_strFileName = v_FileFullPath

            mv_strFileName = v_strFileName

            'If v_intFile > 1 Then
            '    If MsgBox(mv_ResourceManager.GetString("msg_File_Does_Exist").Replace("@", v_intFile - 1), MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            '        v_lngError = ERR_SYSTEM_START
            '        Return v_lngError
            '    End If
            'End If

            If UCase(Mid(v_FileFullPath, Len(v_FileFullPath) - 3)) <> ".XLS" Then
                Dim v_strData As String
                Dim v_streamWriter As New StreamWriter(v_FileFullPath, False, System.Text.Encoding.Unicode)

                If (mv_ds.Tables(0).Rows.Count > 0) Then
                    'Write file's header
                    v_strData = String.Empty
                    For idx As Integer = 0 To mv_ds.Tables(0).Columns.Count - 1
                        v_strData &= mv_ds.Tables(0).Columns(idx).ColumnName & vbTab
                    Next
                    v_streamWriter.WriteLine(v_strData)

                    'Write data
                    For i As Integer = 0 To mv_ds.Tables(0).Rows.Count - 1
                        If Not mv_ds.Tables(0).Rows(i)(0) Is Nothing Then
                            v_strData = String.Empty
                            For j As Integer = 0 To mv_ds.Tables(0).Columns.Count - 1
                                v_strTemp = "@" & CStr(mv_ds.Tables(0).Rows(i)(j).Value.ToString)
                                v_strData &= v_strTemp & vbTab
                            Next
                            'Write data to the file
                            v_streamWriter.WriteLine(v_strData)
                        End If
                    Next
                Else
                    MsgBox(mv_ResourceManager.GetString("msg_Do_Not_Data_To_Export"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    v_lngError = ERR_SYSTEM_START
                    Return v_lngError
                End If

                'Close StreamWriter
                v_streamWriter.Close()
            Else

                'Ghi file excel
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
                If System.IO.File.Exists(v_FileFullPath) = True Then 'Check to see if file exists
                    objWorkbook = objExcel.Workbooks.Open(v_FileFullPath)
                    objWorksheet = objWorkbook.ActiveSheet() 'objWorkbook.Worksheets.Item("Sheet1")

                    'Find last empty cell
                    varInt_StartRow = objWorksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row
                Else
                    varInt_StartRow = 0
                End If
                If (mv_ds.Tables(0).Rows.Count > 0) Then
                    Dim i, j As Integer
                    'Write header
                    If mv_arrObjXmlNode_6614.GetLength(0) > 0 Then
                        For v_intIndex = 0 To mv_arrObjXmlNode_6614.GetLength(0) - 1 Step 1
                            If mv_arrObjXmlNode_6614(v_intIndex).XmlLastNode = True Then
                                'CType(objWorksheet.Cells(1, i + 1), Excel.Range).EntireColumn.NumberFormat = "@"
                                With objWorksheet.Range(objWorksheet.Cells(1, i + 1), objWorksheet.Cells(1, i + 1))
                                    .Value = CStr(mv_arrObjXmlNode_6614(v_intIndex).XmlNodeID)
                                    .Font.Size = 10
                                    .Font.Name = "Times New Roman"
                                    .Font.Bold = True
                                    '.VerticalAlignment = Excel.Constants.xlTop
                                    '.HorizontalAlignment = Excel.Constants.xlCenter
                                    .Select()
                                    i = i + 1
                                End With
                            Else
                                Exit For
                            End If
                        Next
                    End If

                    'Write data
                    For j = 0 To mv_ds.Tables(0).Rows.Count - 1
                        If Not mv_ds.Tables(0).Rows(j)(0) Is Nothing Then
                            i = 0
                            If mv_arrObjXmlNode_6614.GetLength(0) > 0 Then
                                For v_intIndex = 0 To mv_arrObjXmlNode_6614.GetLength(0) - 1 Step 1
                                    If mv_arrObjXmlNode_6614(v_intIndex).XmlLastNode = True Then
                                        v_NodeItem = mv_arrObjXmlNode_6614(v_intIndex).XmlNodeID.Trim
                                        v_fldName = mv_arrObjXmlNode_6614(v_intIndex).TableFldName.Trim
                                        If v_fldName.Length <> 0 Then
                                            v_fldValue = ""
                                            If Not mv_ds.Tables(0).Rows(j)(v_fldName) Is Nothing Then
                                                v_fldValue = CStr(mv_ds.Tables(0).Rows(j)(v_fldName).ToString)
                                            End If
                                        End If

                                        If mv_arrObjXmlNode_6614(v_intIndex).Datatype = "C" Then
                                            With objWorksheet.Range(objWorksheet.Cells(j + 2, i + 1), objWorksheet.Cells(j + 2, i + 1))
                                                .Value = "'" & CStr(v_fldValue)
                                                .Font.Size = 10
                                                .Font.Name = "Times New Roman"
                                                '.NumberFormat = "@"
                                            End With
                                        ElseIf mv_arrObjXmlNode_6614(v_intIndex).Datatype = "N" Then
                                            v_fldValue = IIf(v_fldValue.Length > 0, v_fldValue, 0)
                                            With objWorksheet.Range(objWorksheet.Cells(j + 2, i + 1), objWorksheet.Cells(j + 2, i + 1))
                                                .Value = CDbl(v_fldValue)
                                                .Font.Size = 10
                                                .Font.Name = "Times New Roman"
                                                '.NumberFormat = "0"
                                            End With
                                        End If

                                        'Lay thong tin de chuan bi buil row tong cong
                                        'If mv_arrObjXmlNode_6614(v_intIndex).XmlSumCalc Then
                                        '    If mv_arrObjXmlNode_6614(v_intIndex).Datatype = "C" Then
                                        '        v_dblTotalName = CStr(mv_arrObjXmlNode_6614(v_intIndex).XmlPRNodeID)
                                        '        v_intTotalNameCol = i + 1
                                        '    ElseIf mv_arrObjXmlNode_6614(v_intIndex).Datatype = "N" Then
                                        '        v_dblTotalAmount += CDbl(v_fldValue)
                                        '        v_intTotalAmountCol = i + 1
                                        '    End If
                                        'End If
                                        i = i + 1
                                    Else
                                        Exit For
                                    End If
                                Next
                                v_intTotalRow = j
                            End If
                        End If
                    Next

                    'Write Sum
                    'If Me.chkisSum.Checked Then
                    '    v_intTotalRow += 3
                    '    'Write Name
                    '    With objWorksheet.Range(objWorksheet.Cells(v_intTotalRow, v_intTotalNameCol), objWorksheet.Cells(v_intTotalRow, v_intTotalNameCol))
                    '        .Value = CStr(v_dblTotalName)
                    '        '.NumberFormat = "@"
                    '        .Font.Size = 10
                    '        .Font.Name = "Times New Roman"
                    '        .Font.Bold = True
                    '    End With

                    '    'Write Value
                    '    With objWorksheet.Range(objWorksheet.Cells(v_intTotalRow, v_intTotalAmountCol), objWorksheet.Cells(v_intTotalRow, v_intTotalAmountCol))
                    '        .Value = CDbl(v_dblTotalAmount)
                    '        '.NumberFormat = "0"
                    '        .Font.Size = 10
                    '        .Font.Name = "Times New Roman"
                    '        .Font.Bold = True
                    '    End With
                    'End If

                    'Save workbook before closing
                    'objExcel.SaveWorkspace(v_FileFullPath)
                    objWorkbook.SaveAs(v_FileFullPath)

                Else
                    MsgBox(mv_ResourceManager.GetString("msg_Do_Not_Data_To_Export"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    Exit Function
                End If

                'Close the workbook and Excel 
                objWorkbook.Close(True, "", Nothing)
                objWorkbook = Nothing
                objExcel.Quit()
                System.Runtime.InteropServices.Marshal.ReleaseComObject(objExcel)
                objExcel = Nothing

                'Tra lai cau hinh User Account Windows theo mac dinh cua chuong trinh
                System.Threading.Thread.CurrentThread.CurrentCulture = oldCI



            End If


            'MsgBox(mv_ResourceManager.GetString("msg_Export_Data_Complete"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            Return v_lngError


        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            v_lngError = ERR_SYSTEM_START
            Return v_lngError
        End Try
    End Function

    Private Function ExportToBIDVXML() As Int32
        Dim v_strSQL As String = String.Empty
        Dim v_strObjMsg As String = String.Empty
        Dim v_ws As New BDSDeliveryManagement
        Dim v_xmlDoc As New XmlDocument
        Dim v_nodeList As XmlNodeList = Nothing
        Dim v_strValue, v_strFLDNAME, v_strResult As String, v_strSrcErrorCode As String, i, j As Integer
        Dim v_strRootCode, v_strSCID, v_strUserName, v_strPassword, v_strSignerID, v_strReceiverID As String
        Dim v_intIndex, v_lngPIndex As Long
        Dim v_sbMsg As New StringBuilder()
        Dim v_sbMsgRoot As New StringBuilder()
        Dim v_sbMsgDetails As New StringBuilder()
        Dim v_fldName, v_NodeItem, v_NodeValue, v_strPNodeItem, v_strPrevPNodeItem, v_strRootNode As String
        Dim v_IsRun As Boolean = True
        Dim v_IsNode As Boolean = True
        Dim v_lngError As Long = ERR_SYSTEM_OK

        Try
            If Log.IsDebugEnabled Then
                Log.Debug("::MessageByte:: [BEGIN]")
            End If

            If (SearchGrid.DataRows.Count = 0) Then
                MsgBox(mv_ResourceManager.GetString("msg_Do_Not_Data_To_Export"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                v_lngError = ERR_SYSTEM_START
                Return v_lngError
            End If


            '1- Lay thong tin lien quan den ngan hang 
            v_strSQL = "SELECT BANKCODE, ROOTCODE, BANKNAME, USERIDKEY," & ControlChars.CrLf _
                        & "ACCESSKEY, PRIVATEKEY, PFXKEYNAME, PFXKEYPASS," & ControlChars.CrLf _
                        & "SIGNER, SIGNERPASS, RECEIVER, MINAMOUNTI, MINAMOUNTG, STATUS" & ControlChars.CrLf _
                        & "FROM CRBDEFBANK WHERE BANKCODE = '" & cboBankName.SelectedValue & "'"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)

            If Log.IsDebugEnabled Then
                Log.Debug(String.Format("::MessageByte:: [MSGTYPE] [{0}] [BEGIN]", v_strObjMsg))
            End If

            v_xmlDoc.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDoc.SelectNodes("/ObjectMessage/ObjData")
            If v_nodeList.Count > 0 Then
                For i = 0 To v_nodeList.Count - 1
                    For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            'Ghi nhận thuật toán để kiểm tra và tính toán cho tung field cua giao dịch
                            v_strValue = .InnerText.ToString
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME)
                                Case "ROOTCODE"
                                    v_strRootCode = Trim(v_strValue)
                                Case "USERIDKEY"
                                    v_strSCID = Trim(v_strValue)
                                Case "ACCESSKEY"
                                    v_strUserName = Trim(v_strValue)
                                Case "PRIVATEKEY"
                                    v_strPassword = Trim(v_strValue)
                                Case "SIGNER"
                                    v_strSignerID = Trim(v_strValue)
                                Case "RECEIVER"
                                    v_strReceiverID = Trim(v_strValue)
                            End Select
                        End With
                    Next
                Next
            Else
                MsgBox(mv_ResourceManager.GetString("msg_Do_Not_Data_To_Export"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                Exit Function
            End If

            'root node
            mv_arrAutoID = String.Empty
            If Me.SearchGrid.DataRows.Count > 0 Then
                For i = 0 To Me.SearchGrid.DataRows.Count - 1
                    If v_IsRun = False Then
                        Exit For
                    End If
                    'mv_arrAutoID &= SearchGrid.DataRows(i).Cells("DTLAUTOID").Value.ToString.Trim & "|"
                    If mv_arrObjXmlNode.GetLength(0) > 0 Then
                        For v_intIndex = 0 To mv_arrObjXmlNode.GetLength(0) - 1 Step 1
                            If Not mv_arrObjXmlNode(v_intIndex) Is Nothing Then
                                v_IsNode = mv_arrObjXmlNode(v_intIndex).IsNode
                                v_strPNodeItem = mv_arrObjXmlNode(v_intIndex).XmlPRNodeID
                                v_NodeItem = mv_arrObjXmlNode(v_intIndex).XmlNodeID
                                v_fldName = mv_arrObjXmlNode(v_intIndex).TableFldName
                                If Log.IsDebugEnabled Then
                                    Log.Debug(String.Format("::MessageByte:: [MSGTYPE] [{0}] [FledName]", v_fldName))
                                End If
                                If v_fldName.Length <> 0 Then
                                    If v_fldName = "BATCHDATE" Or v_fldName = "EFFECTDATE" Then
                                        v_NodeValue = DDMMYYYY_SystemDate(SearchGrid.DataRows(i).Cells(v_fldName).Value.ToString()).ToString("dd-MM-yyyy")
                                    Else
                                        v_NodeValue = SearchGrid.DataRows(i).Cells(v_fldName).Value.ToString.Trim
                                    End If
                                    'v_NodeValue = SearchGrid.DataRows(i).Cells(v_fldName).Value.ToString.Trim
                                    If Log.IsDebugEnabled Then
                                        Log.Debug(String.Format("::MessageByte:: [MSGTYPE] [{0}] [NodeValue]", v_NodeValue))
                                    End If
                                End If

                                If mv_arrObjXmlNode(v_intIndex).XmlLevel = 0 And v_IsNode Then
                                    v_strRootNode = mv_arrObjXmlNode(v_intIndex).XmlNodeID
                                    'Root node
                                    v_sbMsgRoot.AppendLine("<" & v_strRootNode & ">")
                                ElseIf mv_arrObjXmlNode(v_intIndex).XmlLastNode And v_strRootNode = v_strPNodeItem And v_IsNode Then
                                    'Node by root node
                                    v_sbMsgRoot.AppendLine("<" & v_NodeItem & ">" & v_NodeValue & "</" & v_NodeItem & ">")
                                Else
                                    v_IsRun = False
                                    v_lngPIndex = v_intIndex
                                    Exit For
                                End If
                            End If
                        Next
                    End If
                Next
            Else
                MsgBox(mv_ResourceManager.GetString("msg_Do_Not_Data_To_Export"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                v_lngError = ERR_SYSTEM_START
                Return v_lngError
            End If

            v_sbMsgRoot.AppendLine("<@Details>")
            'Write end root node
            v_sbMsgRoot.AppendLine("</" & v_strRootNode & ">")

            If Me.SearchGrid.DataRows.Count > 0 Then
                For i = 0 To Me.SearchGrid.DataRows.Count - 1
                    If SearchGrid.DataRows(i).Cells("__TICK").Value = "X" Then
                        mv_arrAutoID &= SearchGrid.DataRows(i).Cells("DTLAUTOID").Value.ToString.Trim & "|"
                        Dim v_strPNode As String
                        If mv_arrObjXmlNode.GetLength(0) > 0 Then
                            For v_intIndex = v_lngPIndex To mv_arrObjXmlNode.GetLength(0) - 1 Step 1
                                If Not mv_arrObjXmlNode(v_intIndex) Is Nothing Then
                                    v_IsNode = mv_arrObjXmlNode(v_intIndex).IsNode
                                    v_strPNodeItem = mv_arrObjXmlNode(v_intIndex).XmlPRNodeID
                                    v_NodeItem = mv_arrObjXmlNode(v_intIndex).XmlNodeID
                                    v_fldName = mv_arrObjXmlNode(v_intIndex).TableFldName
                                    If Log.IsDebugEnabled Then
                                        Log.Debug(String.Format("::MessageByte:: [MSGTYPE] [{0}] [FledName]", v_fldName))
                                    End If
                                    If v_fldName.Length <> 0 Then
                                        If Log.IsDebugEnabled Then
                                            Log.Debug(String.Format("::MessageByte:: [MSGTYPE] [{0}] [NodeValue]", v_NodeValue))
                                        End If
                                        v_NodeValue = SearchGrid.DataRows(i).Cells(v_fldName).Value.ToString.Trim

                                    End If

                                    If v_strPNodeItem <> v_strRootNode And v_IsNode Then
                                        If v_strPNodeItem = v_NodeItem And mv_arrObjXmlNode(v_intIndex).XmlLastNode = False Then
                                            'Parent node
                                            v_strPNode = v_strPNodeItem
                                            v_sbMsgDetails.AppendLine("<" & v_strPNode & ">")
                                        Else
                                            'Details node
                                            v_sbMsgDetails.AppendLine("<" & v_NodeItem & ">" & v_NodeValue & "</" & v_NodeItem & ">")
                                        End If
                                    End If
                                End If
                            Next
                        End If
                        v_sbMsgDetails.AppendLine("</" & v_strPNode & ">")
                    End If
                Next
            Else
                MsgBox(mv_ResourceManager.GetString("msg_Do_Not_Data_To_Export"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                v_lngError = ERR_SYSTEM_START
                Return v_lngError
            End If

            v_sbMsg = v_sbMsgRoot
            v_sbMsg.Replace("<@Details>", v_sbMsgDetails.ToString.Trim)
            'Dim v_BidvKey As New BIDVIKey
            Dim v_strSignedKey As String
            Dim v_strEncData As String
            If chkIsSigner.Checked Then
                '''Xu ly xuat bang ke do ngay tai day
                '- Ký mã hóa file
                If Log.IsDebugEnabled Then
                    Log.Debug(String.Format("::Data Before SignAndEncrypt :: [MSGTYPE] [{0}] [sbMsg]", v_sbMsg))
                End If
                'Dim v_blResult As Boolean = v_BidvKey.SignAndEncrypt(v_sbMsg.ToString(), v_strSignerID, v_strReceiverID, v_strSignedKey, v_strEncData)
                If Log.IsDebugEnabled Then
                    Log.Debug(String.Format("::MessageByte:: [MSGTYPE] [{0}] [SignerID]", v_strSignerID))
                    Log.Debug(String.Format("::MessageByte:: [MSGTYPE] [{0}] [SignedKey]", v_strSignedKey))
                    Log.Debug(String.Format("::MessageByte:: [MSGTYPE] [{0}] [EncData]", v_strEncData))
                End If

                v_sbMsgDetails.AppendLine("<SIGNER>" & v_strSignerID & "</SIGNER>")
                v_sbMsgDetails.AppendLine("<SIGNATURE>" + v_strSignedKey & "</SIGNATURE>")
                v_sbMsgDetails.AppendLine("<ENCRYPTDATA>" + v_strEncData & "</ENCRYPTDATA>")

                v_sbMsg = v_sbMsgRoot
                v_sbMsg.Replace("<@Details>", v_sbMsgDetails.ToString.Trim)
            End If

            Dim v_FileFullPath As String = "D:\EXPORT\BIDVXML.xml"
            Dim v_intFile As Integer = 1

            Dim v_strFileName As String = ConfigurationManager.AppSettings("BIDVFormatFileName")
            v_strFileName = txtPath.Text & v_strFileName
            v_strFileName = v_strFileName.Replace("####", cboTranCode.SelectedValue.ToString())
            v_FileFullPath = chkExistFile(v_strFileName, v_intFile, mv_strEXTENTION)
            v_strFileName = v_FileFullPath

            If v_intFile > 1 Then
                If MsgBox(mv_ResourceManager.GetString("msg_File_Does_Exist").Replace("@", v_intFile - 1), MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    v_lngError = ERR_SYSTEM_START
                    Return v_lngError
                End If
            End If

            mv_strFileName = v_strFileName
            Dim objWriterData As New System.IO.StreamWriter(v_strFileName, False)

            objWriterData.Write(v_sbMsg.ToString().Trim)
            objWriterData.Close()

            If Log.IsDebugEnabled Then
                Log.Debug(String.Format("::MessageByte:: [MSGTYPE] [{0}] [END]", v_sbMsg))
            End If

            'MsgBox(mv_ResourceManager.GetString("msg_Export_Data_Complete"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            Return v_lngError

        Catch ex As Exception
            Log.Debug(String.Format("::ExportToBIDVXML:: [MESSAGE] [{0}]", ex.Message))
            LogError.Write("Error source: @DIRECT.frmRMOfflineManager.ExportToBIDVXML" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            Throw ex
            v_lngError = ERR_SYSTEM_START
            Return v_lngError
        End Try
    End Function

    Private Function ExportToACBXML() As Int32
        Dim settings As XmlWriterSettings = New XmlWriterSettings()
        Dim v_lngError As Long = ERR_SYSTEM_OK
        Try
            settings.Indent = True
            settings.Encoding = New UTF8Encoding(False) 'Encoding.ASCII
            'settings.NewLineOnAttributes = True
            'settings.OmitXmlDeclaration = True
            'settings.NewLineHandling = NewLineHandling.None

            Dim XMLDocumentMessage As New XmlDocumentEx
            Dim dataElement As Xml.XmlElement

            Dim v_intIndex, i As Long
            Dim v_fldName, v_NodeItem, v_fldValue, v_strPNodeItem As String
            Dim v_blnIsFirst As Boolean = True
            Dim v_FileFullPath As String = "D:\EXPORT\ACBXML.xml"
            Dim v_intFile As Integer = 1
            'Create XmlWriterSettings.
            'Create XmlWriter.

            If Log.IsDebugEnabled Then
                Log.Debug("::MessageByte:: [BEGIN]")
            End If

            If (SearchGrid.DataRows.Count = 0) Then
                MsgBox(mv_ResourceManager.GetString("msg_Do_Not_Data_To_Export"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                v_lngError = ERR_SYSTEM_START
                Return v_lngError
            End If

            Dim v_strFileName As String = ConfigurationManager.AppSettings("ACBFormatFileName")
            v_strFileName = txtPath.Text & v_strFileName
            v_strFileName = v_strFileName.Replace("########", YYYYMMDD_FormatDate(Me.BusDate).ToString)
            v_FileFullPath = chkExistFile(v_strFileName, v_intFile, mv_strEXTENTION)
            v_strFileName = v_FileFullPath

            If v_intFile > 1 Then
                If MsgBox(mv_ResourceManager.GetString("msg_File_Does_Exist").Replace("@", v_intFile - 1), MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    v_lngError = ERR_SYSTEM_START
                    Return v_lngError
                End If
            End If

            mv_strFileName = v_strFileName

            Using writer As XmlWriter = XmlWriter.Create(v_strFileName, settings)
                If Not mv_arrObjXmlNode(v_intIndex) Is Nothing Then
                    For v_intIndex = 0 To mv_arrObjXmlNode.GetLength(0) - 1 Step 1
                        If mv_arrObjXmlNode(v_intIndex).XmlLastNode = False And mv_arrObjXmlNode(v_intIndex).XmlLevel = 0 Then
                            ' Begin writing.
                            writer.WriteStartDocument()
                            writer.WriteStartElement(mv_arrObjXmlNode(v_intIndex).XmlNodeID) ' Root.
                            Exit For
                        End If
                    Next
                End If
                mv_arrAutoID = String.Empty
                If Me.SearchGrid.DataRows.Count > 0 Then
                    For i = 0 To Me.SearchGrid.DataRows.Count - 1
                        If SearchGrid.DataRows(i).Cells("__TICK").Value = "X" Then
                            mv_arrAutoID &= SearchGrid.DataRows(i).Cells("DTLAUTOID").Value.ToString.Trim & "|"
                            If mv_arrObjXmlNode.GetLength(0) > 0 Then
                                For v_intIndex = 0 To mv_arrObjXmlNode.GetLength(0) - 1 Step 1
                                    If Not mv_arrObjXmlNode(v_intIndex) Is Nothing Then
                                        If mv_arrObjXmlNode(v_intIndex).XmlLastNode = True Then
                                            'Neu la Item dau tien thi add them the 
                                            If v_blnIsFirst Then
                                                v_strPNodeItem = mv_arrObjXmlNode(v_intIndex).XmlPRNodeID
                                                writer.WriteStartElement(v_strPNodeItem)
                                            End If
                                            v_blnIsFirst = False
                                            v_NodeItem = mv_arrObjXmlNode(v_intIndex).XmlNodeID.Trim
                                            v_fldName = mv_arrObjXmlNode(v_intIndex).TableFldName.Trim
                                            If Log.IsDebugEnabled Then
                                                Log.Debug(String.Format("::MessageByte:: [MSGTYPE] [{0}] [FledName]", v_fldName))
                                            End If
                                            If v_fldName.Length <> 0 Then
                                                v_fldValue = SearchGrid.DataRows(i).Cells(v_fldName).Value.ToString.Trim
                                                If Not v_strPNodeItem Is Nothing AndAlso v_strPNodeItem.Length <> 0 Then
                                                    'Ghi cac Item chi tiet cua XML
                                                    If Log.IsDebugEnabled Then
                                                        Log.Debug(String.Format("::MessageByte:: [MSGTYPE] [{0}] [FledValue]", v_fldValue))
                                                    End If
                                                    writer.WriteAttributeString(v_NodeItem, v_fldValue)
                                                End If
                                            End If
                                        End If
                                    End If
                                Next
                            End If
                            writer.WriteEndElement()
                            v_blnIsFirst = True
                            v_strPNodeItem = vbNullString
                        End If
                    Next
                Else
                    MsgBox(mv_ResourceManager.GetString("msg_Do_Not_Data_To_Export"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    v_lngError = ERR_SYSTEM_START
                    Return v_lngError
                End If
                ' End document.
                writer.WriteEndElement()
                writer.WriteEndDocument()
                writer.Flush()
                writer.Close()
            End Using

            If Log.IsDebugEnabled Then
                Log.Debug("::MessageByte:: [MSGTYPE] [{0}] [END]")
            End If

            'MsgBox(mv_ResourceManager.GetString("msg_Export_Data_Complete"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            Return v_lngError

        Catch ex As Exception
            LogError.Write("Error source: @DIRECT.frmRMOfflineManager.ExportToACBXML" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            Throw ex
            v_lngError = ERR_SYSTEM_START
            Return v_lngError
        Finally
            settings.Reset()
        End Try
    End Function

    Private Function ExportToXML() As Int32
        Dim v_lngError = ERR_SYSTEM_OK
        Try

            If mv_strBANKNAME = "BIDV" Then
                v_lngError = ExportToBIDVXML()
            ElseIf mv_strBANKNAME = "ACB" Then
                v_lngError = ExportToACBXML()
            End If

            Return v_lngError

        Catch ex As Exception
            v_lngError = ERR_SYSTEM_START
            Return v_lngError
        End Try
    End Function

    Private Function GetBatchNo(ByVal pv_strBankCode As String, ByVal pv_strMSGID As String, ByVal pv_strTXDate As String) As String
        Dim v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As XmlNodeList = Nothing
        Dim v_strSQLString, v_strClause, v_strValue, v_strFLDNAME As String, i, j As Integer
        Dim v_strRETVAL As String = String.Empty

        Try
            v_strSQLString = "Select cspks_rmproc.fn_get_seq_gwtBatchNo('" & cboBankName.SelectedValue & "','" & cboTranCode.SelectedValue & "','" & pv_strTXDate & "') RETVAL FROM DUAL"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_ALLCODE, gc_ActionInquiry, v_strSQLString, , , , , , , , gc_CommandText)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i = 0 To v_nodeList.Count - 1
                For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "RETVAL"
                                v_strRETVAL = Trim(v_strValue)
                        End Select
                    End With
                Next
            Next
            Return v_strRETVAL

        Catch ex As Exception
            LogError.Write("Error source: @DIRECT.frmRMOfflineManager.GetBatchNo" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            Throw ex
            Return String.Empty
        End Try
    End Function

    Private Sub GetDataFromBO()
        Dim v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim rownumber, v_intFrom, v_intTo As Long
        Try
            'Neu la lan dau chay thi thoat luon
            If mv_blnIsFirstRun Then Exit Sub
            v_intFrom = 0
            v_intTo = 999999999
            'Cache thong tin ve chung khoan
            Dim v_strSQLString, v_strClause As String, i, j As Integer

            'get cash information
            v_strSQLString = "cspks_rmproc.pr_GetDataToExport"
            v_strClause = "p_bankcode!" & cboBankName.SelectedValue & "!varchar2!20"
            v_strClause = v_strClause & "^p_txdate!" & Me.BusDate & "!varchar2!20"
            v_strClause = v_strClause & "^p_status!" & "P" & "!varchar2!20"
            v_strClause = v_strClause & "^p_msgid!" & cboTranCode.SelectedValue & "!varchar2!50"
            v_strClause = v_strClause & "^pv_batchid!" & cboBankName.SelectedValue & "!varchar2!50"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_ALLCODE, gc_ActionInquiry, v_strSQLString, v_strClause, , , , , , , gc_CommandProcedure)
            v_ws.Message(v_strObjMsg)
            FillDataGrid(SearchGrid, v_strObjMsg, "")

        Catch ex As Exception
            LogError.Write("Error source: @DIRECT.frmRMOfflineManager.GetDataFromBO" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            Throw ex
        Finally
            v_ws = Nothing
        End Try
    End Sub

    Private Sub OnSearch(ByVal pv_CMDSQL As String)
        Dim v_strObjMsg, v_strCmdSQL As String
        Dim v_ws As New BDSDeliveryManagement
        Dim v_xmlTemporary As New XmlDocumentEx
        Dim v_xmlDocument As New Xml.XmlDocument
        'Dim rownumber, v_intFrom, v_intTo As Long
        Dim v_ConditionName As String
        Dim v_ConditionValue As String
        Try
            'Neu la lan dau chay thi thoat luon
            If mv_blnIsFirstRun Then Exit Sub
            InitGrid()

            'Neu la BIDV truoc khi search --> thuc hien gen BatCHID
            If InStr(cboBankName.SelectedValue, "BIDV") Then
                mv_strBatchID = GenBIDVBATCHID(Me.BusDate, cboBankName.SelectedValue, Me.cboTranCode.SelectedValue)
                If InStr(mv_strBatchID, Me.cboTranCode.SelectedValue) = 0 Then
                    MessageBox.Show(mv_ResourceManager.GetString("msg_Can_Not_Create_BatchID"))
                    Exit Sub
                End If
            End If

            'v_intFrom = 0
            'v_intTo = 999999999
            Dim v_strSQLString, v_strClause As String, i, j As Integer
            v_strCmdSQL = pv_CMDSQL
            v_strCmdSQL = v_strCmdSQL.Replace("<@BANKCODE>", mv_strBANKNAME)
            v_strCmdSQL = v_strCmdSQL.Replace("<@MSGID>", cboTranCode.SelectedValue)
            'v_strCmdSQL = v_strCmdSQL.Replace("<@MSGDORC>", cboTranCode.SelectedValue)
            v_strCmdSQL = v_strCmdSQL.Replace("<$BUSDATE>", DDMMYYYY_SystemDate(dtpTXDATE.Value.ToString()))
            v_strCmdSQL = v_strCmdSQL.Replace("<$BATCHID>", Me.BATCHID)

            If txtCondition.Text.Length <> 0 AndAlso Not (txtCondition.Text.Length = vbNullString) Then
                v_ConditionName = cboCondition.SelectedValue
                v_ConditionValue = txtCondition.Text.Trim
                txtCondition.Text = String.Empty
                v_strCmdSQL = v_strCmdSQL & " AND " & v_ConditionName & " LIKE '%" & v_ConditionValue & "%'"
            End If

            If cboStatus.SelectedValue.ToString.ToUpper <> "ALL" Then
                v_strCmdSQL = v_strCmdSQL & " AND STATUS LIKE '%" & cboStatus.SelectedValue & "%'"
            End If

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            FillDataGrid(SearchGrid, v_strObjMsg, "")

            mv_blnIsAllowApprove = True
            OnReConfigButton()

        Catch ex As Exception
            LogError.Write("Error source: @DIRECT.frmRMOfflineManager.OnSearch" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            Throw ex
        Finally
            v_xmlTemporary = Nothing
            v_ws = Nothing
        End Try
    End Sub

    'AnTB them OnLoadExportExcel

    Private Sub OnLoadExportExcel(ByVal pv_CMDSQL As String)
        Dim v_strObjMsg, v_strCmdSQL As String
        Dim v_ws As New BDSDeliveryManagement
        Dim v_xmlTemporary As New XmlDocumentEx
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_xmlDoc As New Xml.XmlDocument
        Dim v_nodelist As Xml.XmlNodeList
        'Dim rownumber, v_intFrom, v_intTo As Long
        Dim v_ConditionName As String
        Dim v_ConditionValue As String
        Try
            'v_intFrom = 0
            'v_intTo = 999999999
            Dim v_strSQLString, v_strClause As String, i, j As Integer
            v_strCmdSQL = pv_CMDSQL
            v_strCmdSQL = v_strCmdSQL.Replace("<@BANKCODE>", mv_strBANKNAME_6614)
            v_strCmdSQL = v_strCmdSQL.Replace("<@MSGID>", cboTranCode.SelectedValue)
            'v_strCmdSQL = v_strCmdSQL.Replace("<@MSGDORC>", cboTranCode.SelectedValue)
            v_strCmdSQL = v_strCmdSQL.Replace("<$BUSDATE>", DDMMYYYY_SystemDate(dtpTXDATE.Value.ToString()))

            If txtCondition.Text.Length <> 0 AndAlso Not (txtCondition.Text.Length = vbNullString) Then
                v_ConditionName = cboCondition.SelectedValue
                v_ConditionValue = txtCondition.Text.Trim
                txtCondition.Text = String.Empty
                v_strCmdSQL = v_strCmdSQL & " AND " & v_ConditionName & " LIKE '%" & v_ConditionValue & "%'"
            End If

            If cboStatus.SelectedValue.ToString.ToUpper <> "ALL" Then
                v_strCmdSQL = v_strCmdSQL & " AND STATUS LIKE '%" & cboStatus.SelectedValue & "%'"
            End If

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)

            v_xmlDoc.LoadXml(v_strObjMsg)

            v_nodelist = v_xmlDoc.SelectNodes("/ObjectMessage/ObjData")

            Dim v_dt As DataTable
            v_dt = XmlToDataTable(v_nodelist)

            mv_ds.Tables.Add(v_dt)

        Catch ex As Exception
            LogError.Write("Error source: @DIRECT.frmRMOfflineManager.OnLoadExportExcel" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            Throw ex
        Finally
            v_xmlTemporary = Nothing
            v_ws = Nothing
        End Try
    End Sub

    Private Sub OnSave(ByVal pv_Approve As Boolean)
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim v_strFunctionName As String = "ImportXMLFileToDB"
            Dim v_strClause, v_strErrorSource, v_strErrorMessage As String
            Dim v_grid As New AppCore.GridEx
            If Not IsApprove Then
                v_grid = SearchGrid
            Else
                v_grid = ResultGrid
            End If
            mv_strObjName = "RM.CRB_OFFLINE_SYN"
            'mv_strFileCode = mv_strFileCode
            If (MessageBox.Show(mv_ResourceManager.GetString("msg_Write_Data_Now"), gc_ApplicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                'TruongLD Comment when convert
                'v_ws.Timeout = gc_WEB_SERVICE_TIMEOUT
                Dim v_strSQL, v_strObjMsg, v_strValue As String
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
                            Else
                                v_strValue = ""
                            End If
                            v_strBuffer.Append("" & v_strValue & "~")
                        Next
                        v_strBuffer.Append("|")
                    End With
                Next
                'Kiem tra ngay cua file import ACB
                'locpt remove check with new template
                'If mv_strBANKNAME = "ACB" Then
                '    'Gan noi dung
                '    For i As Integer = 0 To SearchGrid.DataRows.Count - 1
                '        With SearchGrid.DataRows(i)
                '            If Not .Cells(2).Value() Is DBNull.Value Then
                '                If Not .Cells(2).Value() = Me.BusDate Then
                '                    MessageBox.Show(mv_ResourceManager.GetString("msg_Invalid_Import_File_Date"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                '                    Me.ActiveControl = Me.btnBrowse
                '                    Exit Sub
                '                End If
                '            End If
                '        End With
                '    Next

                'End If

                v_strClause = v_strBuffer.ToString
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, mv_strObjName, _
                        gc_ActionAdhoc, , v_strClause, v_strFunctionName, , , mv_strFileCode, IIf(pv_Approve, "Y", "N"))
                Dim v_lngError As Long = v_ws.Message(v_strObjMsg)
                'TruongLD Comment when convert
                'v_ws.Dispose()
                If v_lngError <> ERR_SYSTEM_OK Then
                    'Load lai du lieu de biet loi~ o dau trong truong hop Return ra ma loi~
                    If mv_strSaveTableName.Length > 0 Then
                        'LoadSaveData(mv_strSaveTableName)
                        OnSearch(mv_strCMDSQL)
                    End If
                    'Thông báo lỗi
                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage)
                    Cursor.Current = Cursors.Default
                    'MessageBox.Show(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, Me.Text, MessageBoxIcon.Error)
                    MessageBox.Show(v_strErrorMessage, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                Dim pv_xmlDocument As New Xml.XmlDocument
                pv_xmlDocument.LoadXml(v_strObjMsg)
                Dim v_strFeedBackMessage As String = pv_xmlDocument.DocumentElement.Attributes.GetNamedItem(gc_AtributeRESERVER).Value
                pv_xmlDocument = Nothing
                Cursor.Current = Cursors.Default
                'check error here
                If v_strFeedBackMessage.Trim.Length = 0 Then
                    MessageBox.Show(mv_ResourceManager.GetString("msg_Write_Data_Successfull"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show(mv_ResourceManager.GetString("msg_Write_Data_Successfull") & ControlChars.CrLf & v_strFeedBackMessage, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                'LOAD LAI DU LIEU DA SAVE DE KIEM TRA
                If mv_strSaveTableName.Length > 0 And mv_strSaveTableName <> "CADTLIMP" Then
                    'LoadSaveData(mv_strSaveTableName)
                    OnSearch(mv_strCMDSQL)
                End If

                mv_blnIsAllowApprove = True
                OnReConfigButton()

            End If
        Catch ex As Exception
            LogError.Write("Error source: @DIRECT.frmRMOfflineManager.OnSave" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(mv_ResourceManager.GetString("msg_Input_File_Invalid"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadSaveData(ByVal mv_strSaveTableName As String)
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_strValue, v_strFLDNAME, v_strFLDTYPE, v_strTEXT As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strCmdSQL As String, v_strObjMsg As String
        Try
            v_strCmdSQL = "SELECT * FROM " & mv_strSaveTableName
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            If v_nodeList.Count > 0 Then
                'Lay tieu de grid
                ResultGrid = New GridEx
                Dim v_cmrODBuyGrid As New Xceed.Grid.ColumnManagerRow
                v_cmrODBuyGrid.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
                v_cmrODBuyGrid.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
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
                                    v_xDataRow.Cells(v_strFLDNAME).Value = IIf(v_strValue Is DBNull.Value, 0, CDbl(v_strValue))
                            End Select
                        End With
                    Next
                    v_xDataRow.EndEdit()
                Next

                Dim v_strMSG As String = mv_ResourceManager.GetString("msg_Syn_Result").Replace("@", v_nodeList.Count)
                Dim v_frResultGrid = New Xceed.Grid.TextRow(v_strMSG)
                v_frResultGrid.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
                v_frResultGrid.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic)
                ResultGrid.FixedFooterRows.Clear()
                ResultGrid.FixedFooterRows.Add(v_frResultGrid)

                Me.pnsSearchResult.Controls.Clear()
                Me.pnsSearchResult.Controls.Add(ResultGrid)
                ResultGrid.Dock = System.Windows.Forms.DockStyle.Fill
            Else
                MessageBox.Show(mv_ResourceManager.GetString("msg_Do_Not_Data_To_Sync"))
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OnReConfigButton()
        'Neu ghi du lieu truc tiep sau khi doc file thi an nut ghi du lieu di khong cho ghi nua.

        Me.btnSync.Enabled = mv_blnIsAllowApprove
        Me.btnSave.Enabled = mv_blnIsAllowSave

        If mv_ISDIRECT = "Y" Then
            Me.btnSave.Enabled = False
        Else
            Me.btnSave.Enabled = True
        End If

        If mv_strBANKNAME = "BIDV" Then
            chkIsSigner.Visible = False
        Else
            chkIsSigner.Visible = True
        End If

        If IsImport Then
            Me.btnLoadData.Enabled = True
            Me.btnExport.Visible = False
            Me.btnExport1.Visible = True
            Me.cboBankName.Enabled = False
            Me.cboCondition.Enabled = False
            Me.cboStatus.Enabled = False
            Me.cboTranCode.Enabled = False
            Me.txtCondition.Enabled = False
            Me.btnSearch.Enabled = False
            Me.chkIsSigner.Enabled = False
            Me.dtpTXDATE.Enabled = False
        Else
            Me.btnLoadData.Enabled = False

            Me.btnExport.Visible = True
            Me.btnExport1.Visible = False
            Me.cboBankName.Enabled = True
            Me.cboCondition.Enabled = True
            Me.cboStatus.Enabled = True
            Me.cboTranCode.Enabled = True
            Me.txtCondition.Enabled = True
            Me.btnSearch.Enabled = True
            Me.chkIsSigner.Enabled = True
            Me.dtpTXDATE.Enabled = True
            Me.btnSync.Enabled = False
            Me.btnSave.Enabled = False
        End If
    End Sub

    Private Function chkExistFile(ByVal pv_FileName As String, ByRef pv_intFile As Integer, Optional ByVal pv_EXTENTION As String = "xls") As String
        Dim v_Count As Integer
        Dim v_strFileName As String
        v_strFileName = pv_FileName

        Try
            v_Count = pv_intFile
            If v_Count < 10 Then
                v_strFileName = v_strFileName & "0" & v_Count & "." & pv_EXTENTION
            Else
                v_strFileName = v_strFileName & v_Count & "." & pv_EXTENTION
            End If

            While IO.File.Exists(v_strFileName)
                v_Count += 1
                pv_intFile = v_Count
                If v_Count < 10 Then
                    v_strFileName = pv_FileName & "0" & v_Count & "." & pv_EXTENTION
                Else
                    v_strFileName = pv_FileName & v_Count & "." & pv_EXTENTION
                End If
            End While
            Return v_strFileName
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Function GenBIDVBATCHID(ByVal pv_strTXDate As String, ByVal pv_strBankCode As String, ByVal pv_strMSGID As String)
        Dim v_strObjName = "RM.CRB_OFFLINE_SYN"
        Dim v_strFunctionName = "GenBIDVBATCHID"
        Dim v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement
        Dim v_strTxDate As String = pv_strTXDate
        Dim v_strBankCode As String
        Dim v_strMSGID As String
        Dim v_strBatchID As String
        Dim pv_xmlDocument As New Xml.XmlDocument
        Try

            If InStr(pv_strBankCode, "BIDV") > 0 Then
                'Neu la BIDV --> sinh BatchID
                v_strBankCode = pv_strBankCode
                v_strMSGID = pv_strMSGID

                v_strObjMsg = BuildXMLObjMsg(v_strTxDate, BranchId, , Me.TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, v_strObjName, gc_ActionAdhoc, , v_strBankCode, v_strFunctionName, , , v_strMSGID)
                Dim v_lngError As Long = v_ws.Message(v_strObjMsg)
                pv_xmlDocument.LoadXml(v_strObjMsg)
                v_strBatchID = pv_xmlDocument.DocumentElement.Attributes.GetNamedItem(gc_AtributeRESERVER).Value
                Return v_strBatchID
            End If
        Catch ex As Exception

            LogError.Write("Error source: @DIRECT.frmRMOfflineManager.GenBIDVBATCHID" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            Return ""
        Finally
            v_ws = Nothing
        End Try
    End Function

#End Region

    
    Private Sub chkAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAll.CheckedChanged
        If chkAll.Checked Then
            For i As Integer = 0 To SearchGrid.DataRows.Count - 1
                SearchGrid.DataRows(i).Cells("__TICK").Value = "X"
            Next
        Else
            For i As Integer = 0 To SearchGrid.DataRows.Count - 1
                SearchGrid.DataRows(i).Cells("__TICK").Value = String.Empty
            Next
        End If
    End Sub

    Private Sub cboTranCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTranCode.SelectedIndexChanged
        If mv_strBANKNAME <> "ACB" Then
            LoadScreen()
        End If
    End Sub
End Class