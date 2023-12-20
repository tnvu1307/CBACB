Imports HostCommonLibrary
Imports System.IO
Imports DataAccessLayer
Imports System.Text
Imports System.Data
Public Class TRADING_RESULT
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "TRADING_RESULT"
    End Sub

    Overrides Function Adhoc(ByRef v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strFuncName As String

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            v_strFuncName = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeFUNCNAME), Xml.XmlAttribute).Value)

            Select Case Trim(v_strFuncName)
                Case "ImportTradingResultToDB"
                    v_lngErrCode = ImportTrandingResultToDB(pv_xmlDocument)
                    If v_lngErrCode <> ERR_SYSTEM_OK Then
                        Return v_lngErrCode
                    End If

            End Select

            'ContextUtil.SetComplete()S
            v_strMessage = pv_xmlDocument.InnerXml
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function ImportTrandingResultToDB(ByRef pv_xmlDocument As XmlDocumentEx) As Long
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strClause As String
            Dim v_strLocal As String
            Dim v_strAutoId As String
            Dim v_intCount As Integer = 0
            Dim v_lngErrCode As Long = ERR_SYSTEM_OK
            Dim v_strErrorSource As String = "SA.TRADING_RESULT.ImportTrandingResultToDB", v_strErrorMessage As String

            If Not (v_attrColl.GetNamedItem(gc_AtributeCLAUSE) Is Nothing) Then
                v_strClause = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Else
                v_strClause = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeAUTOID) Is Nothing) Then
                v_strAutoId = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeAUTOID), Xml.XmlAttribute).Value)
            Else
                v_strAutoId = String.Empty
            End If

            Dim v_arrClause() As String
            v_arrClause = v_strClause.Split("|")

            'Inquiry data
            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If
            'Insert vao db
            Dim v_ds As New DataSet
            Dim v_sql As String
            v_sql = "select * from trading_result"

            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, "SELECT FLOOR_CODE,TRADING_DATE,CONFIRM_NO,B_ORDER_NO,B_ORDER_DATE,S_ORDER_NO,S_ORDER_DATE,B_NEXT_CNFRM,S_NEXT_CNFRM,MATCH_TIME,MATCH_DATE,B_TRADING_ID,S_TRADING_ID,B_PC_FLAG,S_PC_FLAG,B_CODE_TRADE,S_CODE_TRADE,STATUS,SEC_CODE,QUANTITY,PRICE,B_ACCOUNT_NO,S_ACCOUNT_NO,SETT_TYPE,SETT_DATE FROM TRADING_RESULT")
            Dim v_dschk As New DataSet
            'Check dòng đầu tiên xem custodycode xem có trong bảng kết quả khơpds lệnh hay chưa.
            'Nếu đã có trong bảng kết quả khớp lệnh thì tức là file kết quả đã được đọc rồi, không cho phép đọc lần 2
            Dim v_arrFld() As String = v_arrClause(0).Split(","c)
            Dim v_strCONFIRM_NO, v_strTrading_date, v_strSEC_CODE As String

            'Insert kết quả đọc được vào bảng kết quả khớp lệnh
            For i As Integer = 0 To v_arrClause.Length - 2
                Dim v_strValues As New StringBuilder
                Dim v_strColumnNames As New StringBuilder

                v_arrFld = v_arrClause(i).Split(","c)

                '1.Kiểm tra xem dòng này đã được đọc chưa nếu chưa đọc thì thêm vào trong csdl
                '1.1 Lấy ra CONFIRM_NO
                Dim j As Integer = 0
                For Each v_dc As DataColumn In v_ds.Tables(0).Columns
                    If v_dc.ColumnName = "CONFIRM_NO" Then
                        v_strCONFIRM_NO = v_arrFld(j)
                    End If
                    j += 1
                Next
                '1.2 Lấy ra TRADING_DATE
                'Lấy ra ngày hiện tại, chỉ cho phép nhập vào file của ngày hiện tại!
                Dim v_strCURRDATE As String
                v_lngErrCode = v_obj.GetSysVar("SYSTEM", "CURRDATE", v_strCURRDATE)
                j = 0
                For Each v_dc As DataColumn In v_ds.Tables(0).Columns
                    If v_dc.ColumnName = "TRADING_DATE" Then
                        v_strTrading_date = v_arrFld(j)
                    End If
                    j += 1
                Next
                ' Ducnv lay thong tin SEC_CODE
                j = 0
                For Each v_dc As DataColumn In v_ds.Tables(0).Columns
                    If v_dc.ColumnName = "SEC_CODE" Then
                        v_strSEC_CODE = v_arrFld(j)
                    End If
                    j += 1
                Next
                ' Ducnv kiem tra trung theo SEC_CODE, CONFIRM_NO 
                If v_strCURRDATE = v_strTrading_date Then
                    v_dschk = v_obj.ExecuteSQLReturnDataset(CommandType.Text, "SELECT * FROM TRADING_RESULT WHERE CONFIRM_NO='" & v_strCONFIRM_NO & "' AND TRADING_DATE=TO_DATE('" & v_strTrading_date & "','" & gc_FORMAT_DATE & "') AND SEC_CODE = '" & v_strSEC_CODE & "'")
                    If v_dschk.Tables(0).Rows.Count > 0 Then
                        'Kết quả này đã được đọc
                    Else
                        'Thêm vào trong csdl
                        j = 0
                        For Each v_dc As DataColumn In v_ds.Tables(0).Columns
                            v_strColumnNames.Append(v_dc.ColumnName & ",")
                            v_strValues.Append(ProcessData(v_dc, v_arrFld(j)))
                            j += 1
                        Next
                        Dim v_strSQLCMD_1 As String = "Insert into TRADING_RESULT (" & v_strColumnNames.ToString().Substring(0, v_strColumnNames.ToString().Length - 1) & ")" _
                                                        & " Values (" & v_strValues.ToString().Substring(0, v_strValues.ToString.Length - 1) & ")"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQLCMD_1)
                        v_intCount = v_intCount + 1
                    End If
                Else
                    v_lngErrCode = ERR_SA_TRADING_RESULT_INVALID_DATE
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If
            Next
            If v_intCount = 0 Then
                'Trả về lỗi file kết quả đã được đọc
                v_lngErrCode = ERR_SA_READ_TRADING_RESULT_TWICE
                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                             & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                             & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                Return v_lngErrCode
            End If
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function ProcessData(ByVal pv_dc As DataColumn,
                                    ByVal pv_strValue As String,
                                        Optional ByVal pv_UseFormatDate As Boolean = False) As String
        Try
            pv_strValue = Trim(pv_strValue)
            Select Case pv_dc.DataType.Name
                Case "String"
                    If pv_strValue <> "" Then
                        Return "N'" & pv_strValue & "'," 'Unicode
                    Else
                        Return "NULL,"
                    End If
                Case "DateTime"
                    If pv_strValue <> "" Then
                        If pv_UseFormatDate Then
                            'Dim v_date As DateTime = CDate(pv_strValue.Substring(0, 11).Trim)
                            If pv_strValue.Length >= 12 Then
                                Return "TO_DATE('" & pv_strValue.Substring(0, 11).Trim & "','" & gc_FORMAT_DATE & "')" & ","
                            Else
                                Return "NULL,"
                            End If

                        End If
                        Return "TO_DATE('" & pv_strValue & "','" & gc_FORMAT_DATE & "')" & ","
                    Else
                        Return "NULL,"
                    End If
                Case "Decimal", "Int16", "Long", "Int32"
                    If pv_strValue <> "" Then
                        Return pv_strValue & ","
                    Else
                        Return "NULL,"
                    End If
                Case Else
                    If pv_strValue <> "" Then
                        Return pv_strValue & ","
                    Else
                        Return "NULL,"
                    End If
            End Select
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
End Class