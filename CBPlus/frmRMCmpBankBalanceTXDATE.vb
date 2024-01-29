Imports AppCore
Imports CommonLibrary
Imports DevExpress.XtraBars
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.Utils
Imports DevExpress.XtraEditors.Repository
Imports System.IO

Public Class frmRMCmpBankBalanceTXDATE
    Inherits FormBase
#Region " Contructor "
    Public Sub New()

        DevExpress.UserSkins.BonusSkins.Register()
        DevExpress.Skins.SkinManager.EnableFormSkins()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mv_strLanguage = gc_LANG_VIETNAMESE
    End Sub

    Public Sub New(ByVal pv_strLanguage As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mv_strLanguage = pv_strLanguage

        OnInit()

    End Sub
#End Region

#Region " Khai báo hằng, biến "

    Private mv_strCmdMenu As String
    Private mv_strIpAddress As String
    Private mv_strWsName As String
    Private mv_strBusDate As String
    Private mv_strObjName, mv_strAuthCode As String
    Private mv_strBranchId As String
    Private mv_strTellerId As String
    Private mv_strLanguage As String
    Private mv_resourceManager As Resources.ResourceManager
    Private mv_strBankRequestId As String = "-"
    Private mv_strCmdSql As String = ""
    Private gvSearchSelection As GridCheckMarksSelection
    Protected mv_intpage As Int32 = 1
    Dim v_dblInterval As Int32 = 1
    Protected mv_rowpage As Int32 = 0
    Private mv_strCommandType As String = gc_CommandText
    Private mv_strBANKINQ As String = ""
    Private mv_strBANKACCT As String = ""
    Private mv_strCondDefFld As String = ""
    Private mv_strStoreName As String = ""
    Private mv_strStoreParam As String = ""
    Private mv_blnLoadLastSearch As Boolean = True
    Private mv_strCMDTYPE As String
    Protected mv_strTableName As String
    Private mv_strCaption As String
    Private mv_strEnCaption As String
    Private mv_strKeyColumn As String
    Private mv_strKeyFieldType As String
    Private mv_strRefColumn As String
    Private mv_strRefFieldType As String
    Protected mv_ISFLTCODEID As String = "N"
    Protected mv_ISFLTMBCODE As String = "N"
    Protected mv_strCmdSqlTemp As String
    Private mv_strTLTXCD As String
    Protected mv_strSrOderByCmd As String
    Private mv_strSearchAuthCode As String = ""
    Private mv_strRowLimit As String
    Private mv_strMenuType As String
    Private mv_strFormName As String
    Private mv_intSearchNum As Integer
    Private mv_strModuleCode As String
    Private mv_strIsLocalSearch As String
    Public mv_strCMDID As String
    Private mv_blnSearchOnInit As Boolean
    Public mv_strAuthString As String
    Private mv_strSearchByTransact As Boolean = False
    Private mv_strIsLookup As String = "N"
    Private mv_strReturnValue As String
    Private mv_strRefValue As String
    Private mv_strReturnData As String
    Private mv_strXMLData As String
    Private mv_intDblGrid As Integer = 0
    Private mv_isAutoSubmitWhenExecue As Boolean = False
    Private mv_isQuickSearch As Boolean = False

    Private mv_arrSrFieldOperator() As String                   'Danh sách các toán tử đi?u kiện
    Private mv_arrSrOperator() As String                        'Mảng các toán tử đi?u kiện
    Private mv_arrSrSQLRef() As String                          'Câu lệnh SQL liên quan
    Private mv_arrSrFieldType() As String                       'Loại dữ liệu của trư?ng
    Protected mv_arrSrFieldSrch() As String                       'Tên các trư?ng làm tiêu chí để tìm kiếm
    Private mv_arrSrFieldDisp() As String                       'Tên các trư?ng sẽ hiển thị trên Combo
    Private mv_arrSrFieldMask() As String                       'Mặt nạ nhập dữ liệu
    Private mv_arrStFieldDefValue() As String                   'Giá trị mặc định
    Protected mv_arrSrFieldFormat() As String                     '?ịnh dạng dữ liệu
    Private mv_arrSrFieldDisplay() As String                    'Có hiển thị trên lưới không
    Private mv_arrSrFieldWidth() As Integer                     'Dộ rộng hiển thị trên lưới
    Private mv_arrStrTLTXCD() As String
    Private mv_arrStrTLTXNAME As Hashtable
    Private mv_arrStrTLTXMAPFLD As Hashtable                    'Mapping giao dich
    Private mv_arrStrTLTXNAMEREF As Hashtable                   'Cho filter
    Private mv_arrStrTLTXMAPFLDREF As Hashtable

    Private mv_arrStFieldMandartory() As String                  'Có bắt buộc nhập điều kiện tìm kiếm không M. Mandartory, Y. Yes but optional
    Private mv_arrStFieldMultiLang() As String                   'Có đa ngôn ngữ không
    Private mv_arrStFieldRefCDType() As String                   '
    Private mv_arrStFieldRefCDName() As String                   '
    Private mv_arrStQuickSearch() As String                   '
    Private mv_arrStSummaryCode() As String                   '


    Protected mv_intInterval As Int32 = 0
    Private mv_strTimesearch As String
    Private mv_strCUSTID As String
    Private mv_strAFACCTNO As String


    Private mv_SelectedRow As Xceed.Grid.Row

    Private mv_strEnableSearchFilter As Boolean = True
    Private mv_strLinkValue As String
    Private mv_strLinkFieldSrc As String
    Private mv_strLinkFieldDes As String
    Private mv_strNextDate As String
    Private mv_strCompanyCode As String
    Private mv_strCompanyName As String
    Private mv_strParentObjName As String
    Private mv_strParentClause As String

    Private mv_strDefaultSearchFilter As String = String.Empty

    Public mv_frmSearchScreen As frmSearch

    'Variables used for CareBy filter - Modified by TungNT
    Protected mv_isCareBy As Boolean = False
    'End Modified
    Protected mv_strSymbolList As String
    Protected mv_SymbolTable As New DataTable

    Private mv_strIsSMS As String
    Private mv_strIsEMAIL As String
    Private mv_SearchData As DataSet

    Private mv_SearchDataTABLE As DataTable
    Private mv_intTotalRow As Integer
    Private mv_intTotalCountRow As Integer
    Public mv_strSearchClause As String = ""
    Public mv_strTellerName As String
    Private v_strObjMsg_search As String = ""

    Dim mv_arrformatDic As New Dictionary(Of String, String())()
    Dim mv_arrWithDic As New Dictionary(Of String, Integer())()
    Dim mv_arrstrSearch As New Dictionary(Of String, String)()
    Dim mv_arrDataSource As New Dictionary(Of String, DataTable)()
    Private thread As Threading.Timer = New Threading.Timer(AddressOf AutoSearch, Nothing, -1, -1)


#End Region

#Region " Các thuộc tính của form "
    Public Property CMDMenu() As String
        Get
            Return mv_strCmdMenu
        End Get
        Set(ByVal Value As String)
            mv_strCmdMenu = Value
        End Set
    End Property '

    Public Property AuthCode() As String
        Get
            Return mv_strAuthCode
        End Get
        Set(ByVal Value As String)
            mv_strAuthCode = Value
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

    Public Property BusDate() As String
        Get
            Return mv_strBusDate
        End Get
        Set(ByVal Value As String)
            mv_strBusDate = Value
        End Set
    End Property

    Public Property ObjectName() As String
        Get
            Return mv_strObjName
        End Get
        Set(ByVal Value As String)
            mv_strObjName = Value
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
            Return mv_resourceManager
        End Get
        Set(ByVal Value As Resources.ResourceManager)
            mv_resourceManager = Value
        End Set
    End Property
#End Region

#Region " Các sự kiện của form "

    Private Sub frmRMCmpBankBalanceTXDATE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        MyBase.CloseTab()
    End Sub

    Private Sub frmRMCmpBankBalanceTXDATE_Load(sender As Object, e As EventArgs) Handles Me.Load
        dtpTXDATE.Value = DateTime.ParseExact(BusDate, "dd/MM/yyyy", Nothing).AddDays(-1)
        InitExternal()
    End Sub

    Private Sub bciRefeshAuto1_CheckedChanged(sender As Object, e As ItemClickEventArgs) Handles bciRefeshAuto1.CheckedChanged
        initRefeshAuto()

    End Sub

    Private Sub tmAutoProcess_Tick(sender As Object, e As EventArgs) Handles tmAutoProcess.Tick
        If bciRefeshAuto1.Checked Then
            OnCompare()
        End If
    End Sub

    Private Sub bbiBalanceCompare_ItemClick(sender As Object, e As ItemClickEventArgs)
        Cursor.Current = Cursors.WaitCursor
        Cursor.Show()

        CType(e.Item, BarButtonItem).Enabled = False

        tmAutoProcess.Enabled = False
        If bciRefeshAuto1.Checked Then
            tmAutoProcess.Enabled = True

        End If

        initRefeshAuto()
        OnCompare()
        CType(e.Item, BarButtonItem).Enabled = True
    End Sub

    Private Sub bbiInqBank_ItemClick(sender As Object, e As ItemClickEventArgs)
        Cursor.Current = Cursors.WaitCursor
        Cursor.Show()
        CType(e.Item, BarButtonItem).Enabled = False

        BankRequest()
        'gvSearchSelection.ClearSelection()
        'bbiBalanceCompare.Enabled = True

        CType(e.Item, BarButtonItem).Enabled = True
    End Sub

    Private Sub bbiClose_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiClose.ItemClick
        Onclose()
    End Sub

    Private Sub bbiExport_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiExport.ItemClick
        OnExport()
    End Sub
#End Region

#Region " Other methods "
    Protected Sub OnInit()
        ResourceManager = New Resources.ResourceManager(gc_RootNamespace & "." & Me.Name & "-" & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        'Me.OnInit()
        LoadResource(Me)
        bciRefeshAuto1.Visibility = BarItemVisibility.Never
    End Sub

    Private Sub initRefeshAuto()
        Dim v_strSQL, v_strObjMsg, v_strValue, v_strFLDNAME As String
        Dim v_dblInterval As Double = 180
        Try
            v_strSQL = "select INTERVAL, SEARCHCMDSQL from search where searchcode = '" & mv_strObjName & "' "
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_TLLOG, gc_ActionInquiry, v_strSQL)
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            v_ws.Message(v_strObjMsg)

            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_nodeList As Xml.XmlNodeList
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            If v_nodeList.Count = 1 Then
                For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                    With v_nodeList.Item(0).ChildNodes(i)
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "INTERVAL"
                                v_dblInterval = CDbl(Trim(v_strValue))
                            Case "SEARCHCMDSQL"
                                mv_strCmdSql = v_strValue
                        End Select
                    End With
                Next

            End If

            If bciRefeshAuto1.Checked Then
                Me.tmAutoProcess.Interval = v_dblInterval * 1000
            Else
                tmAutoProcess.Enabled = False
            End If

            If mv_strLanguage = gc_LANG_ENGLISH Then
                mv_strCmdSql = mv_strCmdSql.Replace("<@CDCONTENT>", "EN_CDCONTENT")
                mv_strCmdSql = mv_strCmdSql.Replace("<@DESCRIPTION>", "EN_DESCRIPTION")
            Else
                mv_strCmdSql = mv_strCmdSql.Replace("<@CDCONTENT>", "CDCONTENT")
                mv_strCmdSql = mv_strCmdSql.Replace("<@DESCRIPTION>", "DESCRIPTION")
            End If

        Catch ex As Exception
            LogError.Write("frmRMCmpBankBalanceTXDATE.initRefeshAuto. Error: " & vbNewLine & ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            Throw ex
        Finally
        End Try
    End Sub

    Private Sub Onclose()
        Me.Close()
        Me.tmAutoProcess.Enabled = False
    End Sub

    Private Sub OnExport()
        Try
            Dim v_dlgSave As New SaveFileDialog
            Dim v_strTemp As String
            v_dlgSave.Filter = "Excel files (*.xls)|*.xls|Excel files (*.xlsx)|*.xlsx|Pdf files (*.pdf)|*.pdf|CSV files (*.csv)|*.csv|Text files (*.txt)|*.txt|All files (*.*)|*.*"
            v_dlgSave.RestoreDirectory = True
            Dim v_res As DialogResult = v_dlgSave.ShowDialog(Me)
            Dim v_filetype As String
            'CreateExcelFile.CreateExcelDocument(ds, targetFilename)

            If v_res = DialogResult.OK Then
                Dim v_strFileName As String = v_dlgSave.FileName

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
                        MsgBox(mv_resourceManager.GetString("NothingToExport"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                        Exit Sub
                    End If

                    'Close StreamWriter
                    v_streamWriter.Close()
                Else
                    'Ghi file excel
                    Dim v_Ew As New ExcelLib
                    v_Ew.ExportData(v_strFileName, gridResult, v_filetype)
                End If
                MsgBox(mv_resourceManager.GetString("ExportSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            End If

            Exit Sub

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    'Private Sub BarButtonItem_Click(sender As Object, e As ItemClickEventArgs)
    '    Cursor.Current = Cursors.WaitCursor
    '    Cursor.Show()
    '    CType(e.Item, BarButtonItem).Enabled = False
    '    If (e.Item Is bbiInqBank) Then
    '        BankRequest()
    '        bbiBalanceCompare.Enabled = True
    '    ElseIf (e.Item Is bbiBalanceCompare) Then
    '        tmAutoProcess.Enabled = False
    '        If bciRefeshAuto1.Checked Then
    '            tmAutoProcess.Enabled = True
    '            initRefeshAuto()
    '        End If
    '        OnCompare()

    '    End If
    '    CType(e.Item, BarButtonItem).Enabled = True
    'End Sub

    Protected Overridable Sub LoadResource(ByRef pv_ctrl As Windows.Forms.Control)
        Dim v_ctrl As Windows.Forms.Control

        For Each v_ctrl In pv_ctrl.Controls
            If TypeOf (v_ctrl) Is Label Then
                CType(v_ctrl, Label).Text = mv_resourceManager.GetString(v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is GroupBox Then
                CType(v_ctrl, GroupBox).Text = mv_resourceManager.GetString(v_ctrl.Name)
                LoadResource(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is Button Then
                CType(v_ctrl, Button).Text = mv_resourceManager.GetString(v_ctrl.Name)
            End If
        Next

        'bbiInqBank.Caption = ResourceManager.GetString(bbiInqBank.Name)
        'bbiBalanceCompare.Caption = ResourceManager.GetString(bbiBalanceCompare.Name)
        'bbiBalanceCompare.Enabled = False
        bbiClose.Caption = ResourceManager.GetString(bbiClose.Name)
        bbiExport.Caption = ResourceManager.GetString(bbiExport.Name)
        bciRefeshAuto1.Caption = ResourceManager.GetString(bciRefeshAuto1.Name)

        gcResult.Text = ResourceManager.GetString(gcResult.Name)
        rpBankMenu.Text = ResourceManager.GetString(rpBankMenu.Name)
        lblTXDATE.Text = ResourceManager.GetString(lblTXDATE.Tag)

    End Sub



    Private Sub gvResult_RowCellStyle(sender As Object, e As RowCellStyleEventArgs)
        Dim gv As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        If gv.Name.ToUpper() = "GVRESULT" Then
            If e.Column.FieldName = "MATCHSTS" AndAlso e.RowHandle >= 0 Then

                If gv.GetRowCellValue(e.RowHandle, "STATUS").ToString = "Y" Then
                    e.Appearance.BackColor = ColorTranslator.FromHtml("#56B81D")
                ElseIf gv.GetRowCellValue(e.RowHandle, "STATUS").ToString = "N" Then
                    e.Appearance.BackColor = ColorTranslator.FromHtml("#E3CB32")
                ElseIf gv.GetRowCellValue(e.RowHandle, "STATUS").ToString = "P" Then
                    e.Appearance.BackColor = ColorTranslator.FromHtml("#D3D4BC")
                ElseIf gv.GetRowCellValue(e.RowHandle, "STATUS").ToString = "E" Then
                    e.Appearance.BackColor = ColorTranslator.FromHtml("#F51D1D")
                    'ElseIf gv.GetRowCellValue(e.RowHandle, "STATUS").ToString = "ZZ" Then
                    '    e.Appearance.BackColor = ColorTranslator.FromHtml("#FFFFFF")

                End If
            End If

        End If



    End Sub

    Protected Overridable Sub Grid_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'Dim gv As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        'btnCashUnhold1.Enabled = False
        'btnUnholdSE.Enabled = False
        'If Not gv.GetFocusedDataRow() Is Nothing Then
        '    If gv.Columns.Contains(gvResult.Columns("APRALLOW")) = True Then
        '        Dim v_strUNHOLDALLOW As String = gvResult.GetFocusedDataRow()("APRALLOW").ToString
        '        If v_strUNHOLDALLOW = "Y" Then
        '            If (gvResult.Name.Contains("CASHHOLD")) Then
        '                btnCashUnhold1.Enabled = True
        '            ElseIf (gvResult.Name.Contains("SEHOLD")) Then
        '                btnUnholdSE.Enabled = False
        '            End If

        '        End If
        '    End If

        'End If
    End Sub
    Public Sub PrepareSearchParamsAdv(ByVal pv_strUserLanguage As String, ByVal pv_strObjMsg As String, ByRef pv_strSrTitle As String, ByRef pv_strSrEnTitle As String, _
                                   ByRef pv_strSrCmd As String, ByRef pv_strSrObjName As String, _
                                   ByRef pv_strFrmName As String, ByRef pv_arrSrFieldCode() As String, _
                                   ByRef pv_arrSrFieldName() As String, ByRef pv_arrSrFieldType() As String, _
                                   ByRef pv_arrSrFieldMask() As String, ByRef pv_arrSrFieldDefValue() As String, ByRef pv_arrSrFieldOperator() As String, _
                                   ByRef pv_arrSrFieldFormat() As String, ByRef pv_arrSrFieldDisplay() As String, _
                                   ByRef pv_arrSrFieldWidth() As Integer, ByRef pv_arrSrLookupSql() As String, ByRef pv_arrSrFieldMultiLang() As String, _
                                   ByRef pv_arrSrFieldMandatory() As String, ByRef pv_arrSrRefCDType() As String, ByRef pv_arrSrRefCDName() As String, _
                                   ByRef pv_arrSrQuickSearch() As String, ByRef pv_arrSrSummaryCode() As String, _
                                   ByRef pv_strKeyColumn As String, ByRef pv_strKeyFieldType As String, ByRef pv_intSearchNum As Integer, _
                                   ByRef pv_strRefColumn As String, ByRef pv_strRefFieldType As String, Optional ByRef pv_strSrOderByCmd As String = "", _
                                   Optional ByRef pv_strTLTXCD As String = "", Optional ByRef pv_strISSMS As String = "N", _
                                   Optional ByRef pv_strISEMAIL As String = "N", Optional ByRef pv_intRowPerPage As Integer = 0, Optional ByRef pv_strAUTHCODE As String = "", _
                                   Optional ByRef pv_strROWLIMIT As String = "Y", Optional ByRef pv_strCMDTYPE As String = "T", Optional ByRef pv_strCondDefFld As String = "", _
                                   Optional ByRef pv_strBANKINQ As String = "N", Optional ByRef pv_strBANKACCT As String = "",
                                   Optional ByRef pv_ISFLTCODEID As String = "N", Optional ByRef pv_ISFLTMBCODE As String = "N",
                                   Optional ByRef pv_QUICKSRCH As String = "N", Optional ByRef pv_SUMMARYCD As String = "", Optional ByRef pv_intInterval As Integer = 0)

        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strFLDNAME, v_strValue As String
        Dim v_strKeyValue, v_strSrch, v_strRefValue As String
        Dim v_strOderbycmdsql, v_strSrTitle, v_strSrEnTitle, v_strSrCmd, v_strSrObjName, v_strFrmName, v_strSrFieldCode, v_strSrFieldMultiLang, _
            v_strSrFieldName, v_strSrEnFieldName, v_strSrFieldType, v_strSrFieldMask, v_strSrFieldDefValue, v_strSrFieldOperator, v_strSrFieldFormat As String
        Dim v_strSrFieldDisplay, v_strSrLookupSql, v_strSrRefACDType, v_strSrRefACDName, v_strSrQuickSearch, v_strSrSummaryCode As String
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
            ReDim pv_arrSrQuickSearch(v_intFieldCount)
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
                            Case "ISFLTCODEID"
                                pv_ISFLTCODEID = Trim(v_strValue)
                            Case "ISFLTMBCODE"
                                pv_ISFLTMBCODE = Trim(v_strValue)
                            Case "QUICKSRCH"
                                v_strSrQuickSearch = Trim(v_strValue)
                            Case "SUMMARYCD"
                                v_strSrSummaryCode = Trim(v_strValue)
                            Case "INTERVAL"
                                If IsNumeric(v_strValue) Then
                                    pv_intInterval = CInt(v_strValue)
                                Else
                                    pv_intInterval = 0
                                End If
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
                    pv_arrSrQuickSearch(pv_intSearchNum) = v_strSrQuickSearch
                    pv_arrSrSummaryCode(pv_intSearchNum) = v_strSrSummaryCode
                    pv_arrSrRefCDType(v_intFieldCount) = v_strSrRefACDType
                    pv_arrSrRefCDName(v_intFieldCount) = v_strSrRefACDName
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
                ReDim Preserve pv_arrSrQuickSearch(pv_intSearchNum)
                ReDim Preserve pv_arrSrSummaryCode(pv_intSearchNum)
                ReDim Preserve pv_arrSrRefCDType(v_intFieldCount)
                ReDim Preserve pv_arrSrRefCDName(v_intFieldCount)
            End If

        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            Throw ex
        End Try
    End Sub

    Private Sub InitExternal()
        Dim v_strSQL, v_strObjMsg, v_strValue, v_strFLDNAME As String
        Dim v_strCMDNAME, v_strEN_CMDNAME As String
        Try


            'initGrid(gridResult, ObjectName, True)
            InitGridFromSearchCode(ObjectName, gridResult, gvResult, "", "Y", dtpTXDATE.Value.ToString("dd/MM/yyyy"), UserLanguage)

            Dim v_strCmdInquiry As String = "SELECT * FROM V_SEARCHCD WHERE 0=0 "
            Dim v_strClause As String = " UPPER(SEARCHCODE) = '" & ObjectName & "' ORDER BY POSITION"
            v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_SEARCHFLD, gc_ActionInquiry, v_strCmdInquiry, v_strClause, )

            Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
            v_ws.Message(v_strObjMsg)
            PrepareSearchParamsAdv(UserLanguage, v_strObjMsg, mv_strCaption, mv_strEnCaption, mv_strCmdSql, mv_strObjName, _
                mv_strFormName, mv_arrSrFieldSrch, mv_arrSrFieldDisp, mv_arrSrFieldType, mv_arrSrFieldMask, _
                mv_arrStFieldDefValue, mv_arrSrFieldOperator, mv_arrSrFieldFormat, mv_arrSrFieldDisplay, mv_arrSrFieldWidth, _
                mv_arrSrSQLRef, mv_arrStFieldMultiLang, mv_arrStFieldMandartory, mv_arrStFieldRefCDType, mv_arrStFieldRefCDName, _
                mv_arrStQuickSearch, mv_arrStSummaryCode,
                mv_strKeyColumn, mv_strKeyFieldType, mv_intSearchNum, mv_strRefColumn, mv_strRefFieldType, _
                mv_strSrOderByCmd, mv_strTLTXCD, mv_strIsSMS, mv_strIsEMAIL, mv_rowpage, mv_strSearchAuthCode, _
                mv_strRowLimit, mv_strCommandType, mv_strCondDefFld, mv_strBANKINQ, mv_strBANKACCT, mv_ISFLTCODEID, mv_ISFLTMBCODE, , , mv_intInterval)

            'Formatgid
            XtraGridFormatSummary(Me.gvResult, "", mv_arrSrFieldSrch, mv_arrSrFieldFormat, mv_arrSrFieldWidth, mv_arrSrFieldDisp, mv_arrSrFieldDisplay, mv_arrStSummaryCode)
            'create filter control

            'If Not gvResult.Columns.Contains(gvResult.Columns("CheckMarkSelection")) Then
            '    gvSearchSelection = New GridCheckMarksSelection(gvResult)
            '    gvSearchSelection.CheckMarkColumn.VisibleIndex = 0
            '    gvSearchSelection.CheckMarkColumn.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False
            '    gvSearchSelection.CheckMarkColumn.Visible = True
            '    gvResult.OptionsSelection.MultiSelect = True
            '    gvResult.Columns("CheckMarkSelection").UnboundType = DevExpress.Data.UnboundColumnType.Boolean
            '    gvResult.Columns("CheckMarkSelection").OptionsColumn.ShowCaption = False
            '    gvSearchSelection.SelectAll()
            'End If


            gridResult.Dock = System.Windows.Forms.DockStyle.Fill
            AddHandler gridResult.Click, AddressOf Grid_Click
            AddHandler gvResult.RowCellStyle, AddressOf gvResult_RowCellStyle


            v_strSQL = "select CMDNAME, EN_CMDNAME from cmdmenu where cmdid = '" & CMDMenu & "' "
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_TLLOG, gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)

            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_nodeList As Xml.XmlNodeList
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            If v_nodeList.Count = 1 Then
                For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                    With v_nodeList.Item(0).ChildNodes(i)
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "CMDNAME"
                                v_strCMDNAME = Trim(v_strValue)
                            Case "EN_CMDNAME"
                                v_strEN_CMDNAME = Trim(v_strValue)
                        End Select
                    End With
                Next
            End If
            If mv_strLanguage = "EN" Then
                Me.Text = v_strEN_CMDNAME
            Else
                Me.Text = v_strCMDNAME
            End If

        Catch ex As Exception
            LogError.Write("frmRMCmpBankBalanceTXDATE.InitExternal Error: " & vbNewLine & ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            Throw ex
        Finally
        End Try
    End Sub

    Private Function genBankRequestId() As String
        Dim v_ws As New BDSDeliveryManagement
        Dim v_strSQL, v_strObjMsg, v_strValue, v_strFLDNAME As String
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_result As String
        'Gen Request ID
        'v_strSQL = "SELECT to_char(GETCURRDATE,'DD/MM/RRRR') || '" & BATCH_PREFIXED & "' || LPAD (seq_BATCHTXNUM.NEXTVAL, 8, '0') REQID FROM DUAL"
        'v_strSQL = "SELECT fn_gen_reqkey REQID FROM DUAL"
        v_strSQL = "SELECT fn_getglobalid(GETCURRDATE, '" & BATCH_PREFIXED & "' || LPAD (seq_BATCHTXNUM.NEXTVAL, 8, '0')) REQID FROM DUAL"

        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_TLLOG, gc_ActionInquiry, v_strSQL)
        v_ws.Message(v_strObjMsg)

        v_xmlDocument.LoadXml(v_strObjMsg)
        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
        If v_nodeList.Count = 1 Then
            For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(i)
                    v_strValue = .InnerText.ToString
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    Select Case Trim(v_strFLDNAME)
                        Case "REQID"
                            v_result = Trim(v_strValue)
                    End Select
                End With
            Next
        End If

        Return v_result
    End Function

    Private Sub BankRequest()
        Dim v_strSQL, v_strObjMsg, v_strValue, v_strFLDNAME As String
        Dim v_strCMDNAME, v_strEN_CMDNAME As String
        Dim v_strFunctionName, v_strParameters As String
        Dim v_lngCnt As Long = 0
        Dim v_strDDACCTList As String
        Dim v_ws As New BDSDeliveryManagement
        Try
            If Not gridResult Is Nothing Then
                If gvResult.RowCount > 0 Then
                    For v_intRow = 0 To gvSearchSelection.SelectedCount - 1
                        If Not gvSearchSelection.GetSelectedRow(v_intRow) Is Nothing Then

                            mv_strBankRequestId = genBankRequestId()

                            'If v_lngCnt = 0 Then
                            '    v_strDDACCTList = gf_CorrectStringField(gvSearchSelection.GetSelectedRow(v_intRow)("ACCTNO")).Trim
                            'Else
                            '    v_strDDACCTList &= "," & gf_CorrectStringField(gvSearchSelection.GetSelectedRow(v_intRow)("ACCTNO")).Trim
                            'End If
                            v_strDDACCTList = gf_CorrectStringField(gvSearchSelection.GetSelectedRow(v_intRow)("ACCTNO")).Trim
                            v_lngCnt += 1

                            v_strFunctionName = "pck_bankapi.Bank_Inquiry_List"
                            'v_strParameters = "'ALL', '" & mv_strBankRequestId & "', 'Compare bank balance','" & TellerId & "'"
                            v_strParameters = "P_DDACCTNO!" & v_strDDACCTList & "!varchar2!200^P_REQKEY!" & mv_strBankRequestId & "!varchar2!50^P_DESC!" & "Compare bank balance" & "!Varchar2!20000^P_TLID!" & TellerId & "!Varchar2!20^P_ERR_CODE!" & "" & "!Varchar2!20000"

                            'v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, v_strFunctionName, v_strParameters, "ExecDBFunction")
                            'v_ws.Message(v_strObjMsg)
                            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionExec, v_strFunctionName, v_strParameters, , , , , , , gc_CommandProcedure)
                            Dim v_lngError As Long
                            Dim v_strErrorSource, v_strErrorMessage As String
                            v_lngError = v_ws.Message(v_strObjMsg)
                            If v_lngError <> ERR_SYSTEM_OK Then
                                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                                MessageBox.Show(v_strErrorMessage, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If
                        End If
                    Next

                End If
            End If

            'BDSDelivery.BDSDelivery

            If v_lngCnt > 0 Then

                'v_strFunctionName = "pck_bankapi.Bank_Inquiry_List"
                ''v_strParameters = "'ALL', '" & mv_strBankRequestId & "', 'Compare bank balance','" & TellerId & "'"
                'v_strParameters = "P_DDACCTNO!" & v_strDDACCTList & "!clob!80000^P_REQKEY!" & mv_strBankRequestId & "!varchar2!20^P_DESC!" & "Compare bank balance" & "!Varchar2!20000^P_TLID!" & TellerId & "!Varchar2!20^P_ERR_CODE!" & "" & "!Varchar2!20000"

                ''v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, v_strFunctionName, v_strParameters, "ExecDBFunction")
                ''v_ws.Message(v_strObjMsg)
                'v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionExec, v_strFunctionName, v_strParameters, , , , , , , gc_CommandProcedure)
                'Dim v_lngError As Long
                'Dim v_strErrorSource, v_strErrorMessage As String
                'v_lngError = v_ws.Message(v_strObjMsg)
                'If v_lngError <> ERR_SYSTEM_OK Then
                '    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                '    MessageBox.Show(v_strErrorMessage, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                '    Exit Sub
                'End If

                MessageBox.Show(mv_resourceManager.GetString("BankInqSuccess"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show(mv_resourceManager.GetString("NotChooseAcct"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            LogError.Write("frmRMCmpBankBalanceTXDATE.BankRequest Error: " & vbNewLine & ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            Throw ex
        Finally

        End Try
    End Sub

    Private Sub OnCompare()
        Dim v_strSQL, v_strObjMsg, v_strValue, v_strFLDNAME As String
        Dim v_strCMDNAME, v_strEN_CMDNAME As String
        Dim v_strFunctionName, v_strParameters As String
        Dim v_strCmdSql As String
        Try
            v_strCmdSql = mv_strCmdSql
            If mv_strBankRequestId.Length > 0 Then
                v_strCmdSql = v_strCmdSql.Replace("<@KEYVALUE>", mv_strBankRequestId)
                v_strCmdSql = v_strCmdSql.Replace("<$KEYVAL>", mv_strBankRequestId)
            End If

            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            'Build data
            v_strObjMsg = BuildXMLObjMsg(, , , , "N", gc_MsgTypeObj, OBJNAME_SY_SEARCHFLD, gc_ActionInquiry, v_strCmdSql)
            v_strObjMsg_search = v_strObjMsg
            v_ws.Message(v_strObjMsg)


            mv_SearchDataTABLE = New DataTable()
            mv_SearchDataTABLE = ObjDataToDataset(v_strObjMsg, , mv_strObjName)

            gridResult.DataSource = mv_SearchDataTABLE

            gvSearchSelection.ClearSelection()
            'Fill data to grid
            'FillDataXtraGrid(gridResult, v_strObjMsg, "", mv_strObjName, , 0, 100000, 0)


        Catch ex As Exception
            LogError.Write("frmRMCmpBankBalanceTXDATE.OnCompare Error: " & vbNewLine & ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            Throw ex
        Finally
        End Try
    End Sub


    Private Function ConvertXmlDocToDataSet(ByVal pv_xmlDoc As Xml.XmlDocument) As DataSet
        Try
            Dim v_ds As New DataSet("Object")
            Dim v_dr As DataRow
            Dim v_dc As DataColumn
            Dim v_intCountCol As Integer

            Dim v_nodeXSD, v_nodeXML As Xml.XmlNode
            Dim v_strDataXSD, v_strDataXML, v_strBuilder As String
            Dim v_arrXSDByteMessage(), v_arrXMLByteMessage() As Byte
            Dim v_Encoded As Char()

            v_nodeXSD = pv_xmlDoc.SelectSingleNode("/ObjectMessage/ObjDataXSD")
            v_nodeXML = pv_xmlDoc.SelectSingleNode("/ObjectMessage/ObjDataXML")
            v_strDataXSD = v_nodeXSD.InnerText
            v_strDataXML = v_nodeXML.InnerText
            'Get schema
            Dim v_XSD As New TestBase64.Base64Decoder(v_strDataXSD)
            v_arrXSDByteMessage = v_XSD.GetDecoded()
            v_strDataXSD = ZetaCompressionLibrary.CompressionHelper.DecompressString(v_arrXSDByteMessage)
            'Get data
            Dim v_XML As New TestBase64.Base64Decoder(v_strDataXML)
            v_arrXMLByteMessage = v_XML.GetDecoded()
            v_strDataXML = ZetaCompressionLibrary.CompressionHelper.DecompressString(v_arrXMLByteMessage)
            'Create dataset
            Dim v_XMLREADER, v_XSDREADER As System.IO.StringReader
            v_XMLREADER = New System.IO.StringReader(v_strDataXML)
            v_XSDREADER = New System.IO.StringReader(v_strDataXSD)
            If v_ds Is Nothing Then v_ds = New DataSet
            v_ds.Tables.Clear()
            v_ds.ReadXmlSchema(v_XSDREADER)
            v_ds.ReadXml(v_XMLREADER)
            v_ds.Tables(0).TableName = "ObjData"
            Return v_ds
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Sub UpdateDataset(ByVal ds As DataTable)


        Try
            gridResult.Invoke(Sub(d As DataTable)
                                  Dim key() As DataColumn = {mv_SearchDataTABLE.Columns("RN")}
                                  mv_SearchDataTABLE.PrimaryKey = key
                                  mv_SearchDataTABLE.Merge(d)
                              End Sub, ds)
        Catch ex As Exception
            LogError.Write("Error source: AppCore.frmSearch.LoadLastSearch" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
        End Try

    End Sub

    Private Sub AutoSearch(ByVal state As Object)

        Dim i As Integer
        Dim v_strFLDNAME, v_KeyValue As String
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Dim strRow, v_strMessage As String
        Dim v_intFrom, v_intTo As Int32
        Try
            If v_strObjMsg_search = "" Then
                Exit Sub
            Else
                Dim v_strObjMsg As String = v_strObjMsg_search
                v_ws.Message(v_strObjMsg)

                UpdateDataset(ObjDataToDataset(v_strObjMsg, , mv_strObjName))
            End If
        Catch ex As Exception
            LogError.Write("Error source: AppCore.frmSearch.LoadLastSearch" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
        End Try
    End Sub
#End Region

    Private Sub cbauto_CheckedChanged(sender As Object, e As ItemClickEventArgs) Handles cbauto.CheckedChanged
        If cbauto.Checked Then
            initRefeshAuto()
            'If v_strObjMsg_search = "" Then
            '    mv_intpage = 1
            '    OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
            'End If
            thread.Change(v_dblInterval * 1000, v_dblInterval * 1000)
        Else
            thread.Change(0, 0)
        End If
    End Sub

    Private Sub gvResult_CustomDrawFooter(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs) Handles gvResult.CustomDrawFooter
        Dim intTotalRows As Integer = gvResult.DataRowCount

        Dim rowSelected As Integer = 0

        If Not gvSearchSelection Is Nothing Then
            rowSelected = gvSearchSelection.SelectedCount
        End If
        Dim strFootText As String
        If UserLanguage = "VN" Then
            strFootText = String.Format("Số bản ghi được chọn/Tổng số bản ghi tìm thấy: {0}/{1}", rowSelected, intTotalRows)
        Else
            strFootText = String.Format("Number of records selected/Total records found: {0}/{1}", rowSelected, intTotalRows)
        End If


        Dim TextSize As SizeF = e.Graphics.MeasureString(strFootText, e.Appearance.Font)

        e.Appearance.DrawBackground(e.Cache, e.Bounds)

        e.Appearance.DrawString(e.Cache, strFootText, New Rectangle(e.Bounds.Left, e.Bounds.Top + 5, CInt(TextSize.Width), CInt(TextSize.Height)))

        e.Handled = True
    End Sub

    Private Sub gvResult_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles gvResult.CustomDrawRowIndicator
        If e.RowHandle >= 0 Then
            e.Info.DisplayText = e.RowHandle.ToString()
        End If
    End Sub

    Private Sub dtpTXDATE_ValueChanged(sender As Object, e As EventArgs) Handles dtpTXDATE.ValueChanged
        If Not BusDate Is Nothing Then
            InitExternal()
        End If
    End Sub
End Class