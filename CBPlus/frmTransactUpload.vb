Imports System.Windows.Forms
Imports Xceed.SmartUI.Controls
Imports CommonLibrary
Imports System.Collections
Imports Microsoft.Office.Core
Imports AppCore
Imports AppCore.modCoreLib

'Imports Microsoft.Office.Interop
Public Class frmTransactUpload

#Region "Private Variables"

    Const c_ResourceManager = gc_RootNamespace & "." & "frmTransactUpload-"
    Private mv_ResourceManager As Resources.ResourceManager
    Private mv_strBusDate As String
    Private mv_strAuthCode As String
    Private mv_strTableName As String
    Private mv_strLanguage As String
    Private mv_strObjName As String
    Private mv_strIsLocalSearch As String
    Private mv_strModuleCode As String
    Private mv_strCaption As String
    Private mv_strFILEPATH As String = String.Empty
    Private mv_strENABLEDCOLUMN As String = String.Empty
    Private mv_strKEYCOLUMN As String = String.Empty
    Private mv_strAMTFLDCOLUMN As String = String.Empty
    Private mv_strSHEETNAME As String = "1"
    Private mv_strEXTENTION As String = ".xls"
    Private mv_strFILEID As String = String.Empty
    Private mv_strFileName As String
    Private mv_strFileCode As String
    Private DataGrid As GridEx
    Private UploadedGrid As GridEx
    Private mv_intROWTITLE As Integer = 1
    Private mv_intPAGE As Integer
    Private mv_blnUpdate As Boolean = False
    Private mv_strObjMsg As String = String.Empty
    Private mv_arrSrtblRowName, mv_arrSrtblRowType, mv_arrSrAcctnoFld, mv_arrSrtblRowMaxLength, mv_arrSrDisabled, mv_arrSrVisible, mv_arrSrFieldDesc As String()

#End Region

#Region "Properties"
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


#Region " Windows Form Designer generated code "

    Public Sub New(ByVal pv_strLanguage As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        Me.UserLanguage = pv_strLanguage

        'Add any initialization after the InitializeComponent() call

    End Sub

#End Region

#Region "Private functions"
    Private Sub InitDialog()
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & Me.UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        LoadResource(Me)

        AddHandler btnCancel.Click, AddressOf Button_Click
        AddHandler btnWrite.Click, AddressOf Button_Click
        AddHandler btnBrowse.Click, AddressOf Button_Click
        AddHandler btnRead.Click, AddressOf Button_Click

        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strCmdSQL As String, v_strObjMsg As String
        'Load combobox
        v_strCmdSQL = "SELECT filecode VALUE, filename DISPLAY, filename EN_DISPLAY, filecode LSTODR FROM filemaster WHERE DELTD<>'Y' and eori = 'T' ORDER BY filecode"
        v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
        v_ws.Message(v_strObjMsg)
        FillComboEx(v_strObjMsg, cboFileType, "", Me.UserLanguage)
    End Sub

    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Sub Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v_strValue, v_strValueDisplay As String
        Dim v_objResult As Object
        Dim v_strFilterTmp As String
        Dim v_strSearchKey As String
        Dim v_blnSearchKeyAdded As Boolean

        Try
            If (sender Is btnCancel) Then
                OnClose()
            ElseIf (sender Is btnWrite) Then
                OnWrite()
                Me.tcrtData.SelectedTab = Me.tpg2
            ElseIf (sender Is btnBrowse) Then
                OnBrowse()
            ElseIf (sender Is btnRead) Then
                OnRead()
                Me.tcrtData.SelectedTab = Me.tpg1
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            Throw ex
        End Try
    End Sub

    Private Sub LoadResource(ByRef pv_ctrl As Windows.Forms.Control)
        Dim v_ctrl As Windows.Forms.Control

        For Each v_ctrl In pv_ctrl.Controls
            If TypeOf (v_ctrl) Is Label Then
                CType(v_ctrl, Label).Text = mv_ResourceManager.GetString(v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is GroupBox Then
                CType(v_ctrl, GroupBox).Text = mv_ResourceManager.GetString(v_ctrl.Name)
                LoadResource(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is TabControl Then
                LoadResource(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is TabPage Then
                CType(v_ctrl, TabPage).Text = mv_ResourceManager.GetString(v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is Button Then
                CType(v_ctrl, Button).Text = mv_ResourceManager.GetString(v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is Panel Then
                LoadResource(v_ctrl)
            End If
        Next
        Me.Text = mv_ResourceManager.GetString(Me.Name)
    End Sub

    Private Sub OnClose()
        Me.Dispose()
    End Sub

    Private Sub OnBrowse()
        Try
            Dim v_dlgOpen As New OpenFileDialog
            v_dlgOpen.Filter = "Open files (*" & mv_strEXTENTION & ")|*" & mv_strEXTENTION & ""
            v_dlgOpen.RestoreDirectory = True

            Dim v_res As DialogResult = v_dlgOpen.ShowDialog(Me)
            If v_res = DialogResult.OK Then
                mv_strFileName = v_dlgOpen.FileName
                Me.txtPath.Text = mv_strFileName
            End If
        Catch ex As Exception
            LogError.Write("Error source: @DIRECT.frmTransactUpload.OnBrowser" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub OnWrite()
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim v_strFunctionName As String = "ImportXMLFileToDBTable"
            Dim v_strClause, v_strErrorSource, v_strErrorMessage As String
            mv_strObjName = "SA.TRANSACTUPLOAD"
            'mv_strFileCode = mv_strFileCode
            If (MessageBox.Show("Bạn có muốn ghi dữ liệu bây giờ?", gc_ApplicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                Dim v_ws As New BDSDeliveryManagement
                Dim v_strSQL, v_strObjMsg, v_strValue As String
                Dim v_strBuffer As New System.Text.StringBuilder
                'Gan title
                For Each v_xColumn As Xceed.Grid.Column In DataGrid.Columns
                    If Not CType(v_xColumn, Xceed.Grid.Column).Title Is DBNull.Value Then
                        v_strValue = CType(v_xColumn, Xceed.Grid.Column).Title
                    Else
                        v_strValue = ""
                    End If
                    v_strBuffer.Append("" & v_strValue & "~")
                Next
                v_strBuffer.Append("|")
                'Gan noi dung
                For i As Integer = 0 To DataGrid.DataRows.Count - 1
                    With DataGrid.DataRows(i)
                        For Each v_xColumn As Xceed.Grid.Column In DataGrid.Columns

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
                v_strClause = v_strBuffer.ToString
                v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, mv_strObjName, _
                        gc_ActionAdhoc, , v_strClause, v_strFunctionName, mv_strFILEID, , mv_strFileCode)
                Dim v_lngError As Long = v_ws.Message(v_strObjMsg)

                If v_lngError <> ERR_SYSTEM_OK Then
                    'Thông báo lỗi
                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
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
                    MessageBox.Show("Ghi dữ liệu thành công", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Ghi dữ liệu thành công" & ControlChars.CrLf & v_strFeedBackMessage, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                'LOAD LAI DU LIEU DA SAVE DE KIEM TRA
                If mv_strTableName.Length > 0 Then
                    OnRefresh()
                End If

            End If
        Catch ex As Exception
            LogError.Write("Error source: @DIRECT.frmTransactUpload.OnWrite" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show("File dư liệu đầu vào không hợp lệ!!", gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub OnRead()
        mv_strFILEID = String.Empty
        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet
        Dim range As Excel.Range
        Try
            Me.txtFileID.Text = String.Empty

            If Me.txtPath.Text.Trim.Length = 0 Then
                MessageBox.Show("Vui lòng chọn đường dẫn đến file.xsl cần thực hiện!")
                Me.ActiveControl = Me.btnBrowse
                Exit Sub
            End If
            DataGrid = New GridEx
            Dim v_cmrContactsHeader As New Xceed.Grid.ColumnManagerRow
            v_cmrContactsHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
            v_cmrContactsHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            DataGrid.FixedHeaderRows.Add(v_cmrContactsHeader)

            Dim rCnt As Integer
            Dim cCnt As Integer
            Dim Obj As Object
            Dim v_xColumn As Xceed.Grid.Column
            xlApp = New Excel.Application
            xlWorkBook = xlApp.Workbooks.Open(mv_strFileName)
            If xlWorkBook Is Nothing Then
                MessageBox.Show("Đường dẫn không hợp lệ, vui lòng chọn lại đường dẫn!")
                Me.ActiveControl = Me.btnBrowse
                Exit Sub
            End If

            xlWorkSheet = xlWorkBook.Worksheets(CInt(mv_strSHEETNAME))

            range = xlWorkSheet.UsedRange
            If range.Columns.Count > 0 And range.Rows.Count > 1 Then
                For cCnt = 1 To range.Columns.Count
                    DataGrid.Columns.Add(New Xceed.Grid.Column(cCnt.ToString, GetType(System.String)))
                    DataGrid.Columns(cCnt.ToString).Title = gf_CorrectStringField(CType(range.Cells(mv_intROWTITLE, cCnt), Excel.Range).Value)
                    DataGrid.Columns(cCnt.ToString).HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
                    DataGrid.Columns(cCnt.ToString).Width = 100
                Next
            End If
            DataGrid.DataRows.Clear()
            DataGrid.BeginInit()

            If range.Rows.Count >= mv_intROWTITLE + 1 Then
                For rCnt = mv_intROWTITLE + 1 To range.Rows.Count
                    Dim v_xDataRow As Xceed.Grid.DataRow = DataGrid.DataRows.AddNew()
                    For Each v_xColumn In DataGrid.Columns
                        If v_xColumn.FieldName = 1 Then
                            If gf_CorrectStringField(CType(range.Cells(rCnt, CInt(v_xColumn.FieldName)), Excel.Range).Value) <> String.Empty Then
                                If mv_strFILEID = String.Empty Then
                                    mv_strFILEID = gf_CorrectStringField(CType(range.Cells(rCnt, CInt(v_xColumn.FieldName)), Excel.Range).Value)

                                ElseIf mv_strFILEID <> gf_CorrectStringField(CType(range.Cells(rCnt, CInt(v_xColumn.FieldName)), Excel.Range).Value) Then
                                    'Loi xuat hien 2 file id
                                    MessageBox.Show(mv_ResourceManager.GetString("FileIDIsUnique"))
                                    Exit Sub
                                End If
                                v_xDataRow.Cells(v_xColumn.FieldName).Value = gf_CorrectStringField(CType(range.Cells(rCnt, CInt(v_xColumn.FieldName)), Excel.Range).Value)
                            Else
                                'loi file id can not be null
                                MessageBox.Show(mv_ResourceManager.GetString("FileIDIsUnique"))
                                Exit Sub
                            End If
                        Else
                            v_xDataRow.Cells(v_xColumn.FieldName).Value = gf_CorrectStringField(CType(range.Cells(rCnt, CInt(v_xColumn.FieldName)), Excel.Range).Value)
                        End If
                    Next
                    v_xDataRow.EndEdit()
                Next

            End If

            Dim v_frSearchGrid = New Xceed.Grid.TextRow("Dữ liệu nhận từ file " & range.Rows.Count - mv_intROWTITLE & " dòng!")
            v_frSearchGrid.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
            v_frSearchGrid.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic)
            DataGrid.FixedFooterRows.Clear()
            DataGrid.FixedFooterRows.Add(v_frSearchGrid)

            DataGrid.EndInit()
            xlWorkBook.Close()
            xlApp.Quit()

            Me.pnlUploadData.Controls.Clear()
            Me.pnlUploadData.Controls.Add(DataGrid)
            DataGrid.Dock = System.Windows.Forms.DockStyle.Fill

            Me.txtFileID.Text = mv_strFILEID
        Catch ex As Exception
            LogError.Write("Error source: @DIRECT.frmTransactUpload.OnImport" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            releaseObject(xlApp)
            releaseObject(xlWorkBook)
            releaseObject(xlWorkSheet)
            releaseObject(range)

        End Try
    End Sub

    Private Sub PrepareSearchParams(ByRef pv_intSearchNum As Integer, ByVal pv_strObjMsg As String, ByRef pv_arrSrtblrowname() As String, _
                               ByRef pv_arrSrtblrowtype() As String, ByRef pv_arrSracctnofld() As String, _
                               ByRef pv_arrSrtblrowmaxlength() As String, ByRef pv_arrSrdisabled() As String, _
                               ByRef pv_arrSrvisible() As String, ByRef pv_arrSrfielddesc() As String)
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strFLDNAME, v_strValue As String
        Dim v_strSrsumamt, v_strSrtblrowname, v_strSrtblrowtype, v_strSracctnofld, v_strSrtblrowmaxlength, v_strdisabled, v_strSrvisible, v_strSrfielddesc As String
        Try
            mv_strENABLEDCOLUMN = String.Empty
            mv_strKEYCOLUMN = String.Empty
            mv_strAMTFLDCOLUMN = String.Empty
            pv_intSearchNum = 0

            v_xmlDocument.LoadXml(pv_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            'tblrowname,tblrowtype,acctnofld,tblrowmaxlength,disabled,visible
            ReDim pv_arrSrtblrowname(v_nodeList.Count)
            ReDim pv_arrSrtblrowtype(v_nodeList.Count)
            ReDim pv_arrSracctnofld(v_nodeList.Count)
            ReDim pv_arrSrtblrowmaxlength(v_nodeList.Count)
            ReDim pv_arrSrdisabled(v_nodeList.Count)
            ReDim pv_arrSrvisible(v_nodeList.Count)
            ReDim pv_arrSrfielddesc(v_nodeList.Count)

            For i As Integer = 0 To v_nodeList.Count - 1
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strValue = .InnerText.ToString

                        Select Case Trim(v_strFLDNAME)
                            Case "TBLROWNAME"
                                v_strSrtblrowname = Trim(v_strValue)
                            Case "TBLROWTYPE"
                                v_strSrtblrowtype = Trim(v_strValue)
                            Case "ACCTNOFLD"
                                v_strSracctnofld = Trim(v_strValue)
                            Case "TBLROWMAXLENGTH"
                                v_strSrtblrowmaxlength = Trim(v_strValue)
                            Case "DISABLED"
                                v_strdisabled = Trim(v_strValue)
                            Case "VISIBLE"
                                v_strSrvisible = Trim(v_strValue)
                            Case "FIELDDESC"
                                v_strSrfielddesc = Trim(v_strValue)
                            Case "SUMAMT"
                                v_strSrsumamt = Trim(v_strValue)
                        End Select
                    End With
                Next
                pv_arrSrtblrowname(i) = v_strSrtblrowname
                pv_arrSrtblrowtype(i) = v_strSrtblrowtype
                pv_arrSracctnofld(i) = v_strSracctnofld
                pv_arrSrtblrowmaxlength(i) = v_strSrtblrowmaxlength
                pv_arrSrdisabled(i) = v_strdisabled
                pv_arrSrvisible(i) = v_strSrvisible
                pv_arrSrfielddesc(i) = v_strSrfielddesc
                pv_intSearchNum += 1
                'Lay danh sach dang chuoi:
                If v_strdisabled = "N" Then
                    mv_strENABLEDCOLUMN = mv_strENABLEDCOLUMN & "|" & v_strSrtblrowname
                End If
                If v_strSracctnofld = "Y" Then
                    mv_strKEYCOLUMN = mv_strKEYCOLUMN & "|" & v_strSrtblrowname
                End If
                If v_strSrsumamt = "Y" Then
                    mv_strAMTFLDCOLUMN = v_strSrtblrowname
                End If

            Next

            If pv_intSearchNum > 0 Then

                ReDim Preserve pv_arrSrtblrowname(pv_intSearchNum)
                ReDim Preserve pv_arrSrtblrowtype(pv_intSearchNum)
                ReDim Preserve pv_arrSracctnofld(pv_intSearchNum)
                ReDim Preserve pv_arrSrtblrowmaxlength(pv_intSearchNum)
                ReDim Preserve pv_arrSrdisabled(pv_intSearchNum)
                ReDim Preserve pv_arrSrvisible(pv_intSearchNum)
                ReDim Preserve pv_arrSrfielddesc(pv_intSearchNum)

            End If
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            Throw ex
        End Try
    End Sub

    Private Sub OnRefresh()
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_strValue, v_strFLDNAME, v_strFLDTYPE, v_strTEXT, v_strListField As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strCmdSQL As String, v_strObjMsg As String
        Dim v_strErrorSource, v_strErrorMessage As String
        Dim v_intSearchNum As Integer
        Dim v_dblTotalAmt As Double = 0
        Dim v_dblExecAmt As Double = 0
        Dim v_arrENABLECOLUMN As String()
        Try
            v_strCmdSQL = "SELECT * FROM filemap WHERE filecode = '" & mv_strFileCode & "' order BY lstodr"
            v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_TLLOG, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)

            UploadedGrid = New GridEx

            PrepareSearchParams(v_intSearchNum, v_strObjMsg, mv_arrSrtblrowname, mv_arrSrtblrowtype, mv_arrSracctnofld, mv_arrSrtblrowmaxlength, mv_arrSrdisabled, mv_arrSrvisible, mv_arrSrfielddesc)

            Dim v_cmrUploadedGrid As New Xceed.Grid.ColumnManagerRow
            v_cmrUploadedGrid.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
            v_cmrUploadedGrid.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            UploadedGrid.FixedHeaderRows.Add(v_cmrUploadedGrid)


            UploadedGrid.Columns.Add(New Xceed.Grid.Column("SELECT", GetType(System.String)))
            UploadedGrid.Columns("SELECT").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
            UploadedGrid.Columns("SELECT").Title = String.Empty
            UploadedGrid.Columns("SELECT").Width = 10
            For k As Integer = 0 To v_intSearchNum - 1 Step 1
                'Create field
                Select Case mv_arrSrtblRowType(k)
                    Case "N"
                        UploadedGrid.Columns.Add(New Xceed.Grid.Column(mv_arrSrtblRowName(k), GetType(System.Double)))
                        UploadedGrid.Columns(mv_arrSrtblRowName(k)).HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
                        If mv_arrSrtblRowName(k).ToString <> "AUTOID" Then
                            UploadedGrid.Columns(mv_arrSrtblRowName(k)).FormatSpecifier = "###,##0"
                        End If
                    Case "D"
                        UploadedGrid.Columns.Add(New Xceed.Grid.Column(mv_arrSrtblRowName(k), GetType(System.String)))
                        UploadedGrid.Columns(mv_arrSrtblRowName(k)).HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
                    Case Else
                        UploadedGrid.Columns.Add(New Xceed.Grid.Column(mv_arrSrtblRowName(k), GetType(System.String)))
                        UploadedGrid.Columns(mv_arrSrtblRowName(k)).HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
                End Select
                v_strListField = String.Empty & v_strListField & "," & mv_arrSrtblRowName(k).ToString

                UploadedGrid.Columns(mv_arrSrtblRowName(k)).Title = mv_arrSrFieldDesc(k)
                UploadedGrid.Columns(mv_arrSrtblRowName(k)).Width = mv_arrSrtblRowMaxLength(k)
                UploadedGrid.Columns(mv_arrSrtblRowName(k)).Visible = IIf(mv_arrSrVisible(k).IndexOf("Y") <> -1, True, False)
            Next

            'Fill du lieu vao grid
            v_strCmdSQL = "SELECT " & v_strListField.Trim(",") & " FROM " & mv_strTableName & " WHERE FILEID = '" & txtFileID.Text.Trim & "'"
            v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            If v_nodeList.Count > 0 Then
                'Lay tieu de grid
                'Fill du lieu vao Grid
                For i As Integer = 0 To v_nodeList.Count - 1
                    v_strTEXT = String.Empty
                    Dim v_xDataRow As Xceed.Grid.DataRow = UploadedGrid.DataRows.AddNew()

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
                    If v_xDataRow.Cells("STATUS").Value = "C" Then
                        v_xDataRow.BackColor = Color.DarkGreen
                        v_xDataRow.ReadOnly = True
                    ElseIf v_xDataRow.Cells("STATUS").Value = "A" Then
                        v_xDataRow.BackColor = Color.LightGreen
                        v_xDataRow.Cells("SELECT").Value = "X"
                    ElseIf v_xDataRow.Cells("STATUS").Value = "E" Then
                        v_xDataRow.BackColor = Color.Yellow
                    End If
                    If v_xDataRow.Cells("DELTD").Value = "Y" Then
                        v_xDataRow.BackColor = Color.Gray
                        v_xDataRow.ReadOnly = True
                    End If
                    If v_xDataRow.Cells("DELTD").Value <> "Y" And v_xDataRow.Cells("STATUS").Value <> "C" Then
                        v_arrENABLECOLUMN = mv_strENABLEDCOLUMN.Trim("|").Split("|")
                        For e As Integer = 0 To v_arrENABLECOLUMN.Length - 1
                            v_xDataRow.Cells(v_arrENABLECOLUMN(e)).ReadOnly = False
                            v_xDataRow.Cells(v_arrENABLECOLUMN(e)).ForeColor = Color.Brown
                            v_xDataRow.Cells(v_arrENABLECOLUMN(e)).BackColor = Color.White
                        Next
                    End If

                    v_dblTotalAmt = v_dblTotalAmt + CDbl(v_xDataRow.Cells(mv_strAMTFLDCOLUMN).Value)

                    If v_xDataRow.Cells("STATUS").Value = "C" Then
                        v_dblExecAmt = v_dblExecAmt + CDbl(v_xDataRow.Cells(mv_strAMTFLDCOLUMN).Value)
                    End If

                    v_xDataRow.EndEdit()
                Next
            End If

            mv_strObjMsg = v_strObjMsg

            Dim v_fr1UploadedGrid = New Xceed.Grid.TextRow("Đồng bộ dữ liệu " & v_nodeList.Count & " dòng!")
            v_fr1UploadedGrid.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
            v_fr1UploadedGrid.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic)

            Dim v_fr2UploadedGrid = New Xceed.Grid.TextRow("Tổng giá trị giao dịch đã thực hiện: " & FormatNumber(v_dblExecAmt, 0) & " đồng!")
            v_fr2UploadedGrid.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
            v_fr2UploadedGrid.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)

            Dim v_fr3UploadedGrid = New Xceed.Grid.TextRow("Tổng giá trị: " & FormatNumber(v_dblTotalAmt, 0) & " đồng!")
            v_fr3UploadedGrid.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
            v_fr3UploadedGrid.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            UploadedGrid.FixedFooterRows.Clear()
            UploadedGrid.FixedFooterRows.Add(v_fr1UploadedGrid)
            UploadedGrid.FixedFooterRows.Add(v_fr2UploadedGrid)
            UploadedGrid.FixedFooterRows.Add(v_fr3UploadedGrid)
            Me.pnlUploadedData.Controls.Clear()
            Me.pnlUploadedData.Controls.Add(UploadedGrid)
            UploadedGrid.Dock = System.Windows.Forms.DockStyle.Fill
            If Me.UploadedGrid.DataRowTemplate.Cells.Count >= 0 Then
                For i As Integer = 0 To Me.UploadedGrid.DataRowTemplate.Cells.Count - 1
                    AddHandler UploadedGrid.DataRowTemplate.Cells(i).MouseUp, AddressOf dgData_MouseUp
                Next
            End If
            UploadedGrid.SelectionMode = SelectionMode.MultiSimple
            AddHandler UploadedGrid.SelectedRowsChanged, AddressOf dgData_MultiSelectChanged
            AddHandler UploadedGrid.MouseUp, AddressOf dgData_MouseUp

        Catch ex As Exception
            LogError.Write("Error source: @DIRECT.frmTransactUpload.OnRefresh" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            Throw ex
        End Try
    End Sub

    Private Sub GetFileInfo(ByVal pv_strFile As String)
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_strValue, v_strFLDNAME, v_strTEXT As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strCmdSQL As String, v_strObjMsg As String
        Try
            v_strCmdSQL = "SELECT * FROM filemaster WHERE filecode='" & pv_strFile & "'"
            v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
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
                                Me.txtPath.Text = v_strValue
                            Case "SHEETNAME"
                                mv_strSHEETNAME = v_strValue
                            Case "ROWTITLE"
                                mv_intROWTITLE = CInt(v_strValue)
                            Case "EXTENTION"
                                mv_strEXTENTION = v_strValue
                            Case "PAGE"
                                mv_intPAGE = CInt(v_strValue)
                            Case "TABLENAME"
                                mv_strTableName = v_strValue
                        End Select
                    End With
                Next
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


#End Region

    Private Sub frmTransactUpload_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        InitDialog()
    End Sub

    Private Sub cboFileType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFileType.SelectedIndexChanged
        If Not Me.cboFileType.SelectedValue Is Nothing Then
            Dim v_strFile As String
            mv_strFileCode = Me.cboFileType.SelectedValue.ToString
            v_strFile = mv_strFileCode
            GetFileInfo(v_strFile)
        End If
    End Sub

    Private Sub dgData_MultiSelectChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.ActiveControl Is Me.UploadedGrid Then
            For i As Integer = 0 To UploadedGrid.DataRows.Count - 1 Step 1
                If UploadedGrid.DataRows(i).IsSelected _
                        AndAlso UploadedGrid.DataRows(i).Cells("STATUS").Value <> "C" _
                        AndAlso UploadedGrid.DataRows(i).Cells("STATUS").Value <> "E" _
                        AndAlso UploadedGrid.DataRows(i).Cells("DELTD").Value <> "Y" Then
                    UploadedGrid.DataRows(i).Cells("SELECT").Value = "X"
                    UploadedGrid.DataRows(i).IsSelected = True
                Else
                    UploadedGrid.DataRows(i).Cells("SELECT").Value = String.Empty
                    UploadedGrid.DataRows(i).IsSelected = False
                End If
            Next
        End If
    End Sub

    Private Sub ToolStripMenuItemSelectedAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemSelectedAll.Click
        For i As Integer = 0 To UploadedGrid.DataRows.Count - 1 Step 1
            If UploadedGrid.DataRows(i).Cells("STATUS").Value <> "C" _
                        AndAlso UploadedGrid.DataRows(i).Cells("STATUS").Value <> "E" _
                        AndAlso UploadedGrid.DataRows(i).Cells("DELTD").Value <> "Y" Then
                UploadedGrid.DataRows(i).Cells("SELECT").Value = "X"
                UploadedGrid.DataRows(i).IsSelected = True
            End If
        Next
    End Sub

    Private Sub ToolStripMenuItemUnSelectedAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemUnSelectedAll.Click
        For i As Integer = 0 To UploadedGrid.DataRows.Count - 1 Step 1
            UploadedGrid.DataRows(i).Cells("SELECT").Value = String.Empty
            UploadedGrid.DataRows(i).IsSelected = False
        Next
    End Sub

    Private Sub dgData_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        Try
            If e.Button = MouseButtons.Right Then
                Me.cmsSelectedAll.Show(UploadedGrid, New Point(e.X, e.Y))
            End If
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Sub

    Private Sub frmTransactUpload_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Select Case e.KeyCode
            Case Keys.Escape
                OnClose()
        End Select
    End Sub
End Class