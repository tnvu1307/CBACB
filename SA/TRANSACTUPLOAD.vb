Imports HostCommonLibrary
Imports System.IO
Imports DataAccessLayer
Imports System.Text
Imports System.Data
Public Class TRANSACTUPLOAD
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "TRANSACTUPLOAD"
    End Sub

    Overrides Function Adhoc(ByRef v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strFuncName As String

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            v_strFuncName = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeFUNCNAME), Xml.XmlAttribute).Value)

            Select Case Trim(v_strFuncName)
                Case "ImportXMLFileToDBTable"
                    v_lngErrCode = ImportXMLFileToDBTable(pv_xmlDocument)
                    If v_lngErrCode <> ERR_SYSTEM_OK Then
                        Return v_lngErrCode
                    End If
                Case "PrepareData"
                    v_lngErrCode = PrepareData(pv_xmlDocument)
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

    Private Function ImportXMLFileToDBTable(ByRef pv_xmlDocument As XmlDocumentEx) As Long
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strFileCode As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)
            Dim v_strClause, v_strStoredName, v_strFileID As String
            Dim v_strLocal, v_strBUSDATE As String
            Dim v_intCount As Integer = 0
            Dim v_lngErrCode As Long = ERR_SYSTEM_OK
            Dim v_strErrorSource As String = "SA.TRANSACTUPLOAD.ImportXMLFileToDBTable", v_strErrorMessage As String
            Dim v_strFeedBackMsg As String
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
                v_strFileID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeAUTOID), Xml.XmlAttribute).Value)
            Else
                v_strFileID = String.Empty
            End If


            Dim v_arrClause() As String
            v_arrClause = v_strClause.Split("|")
            Dim v_TitleClause As String = v_arrClause(0)
            Dim v_arrTitleClause() As String
            Dim v_arrTypeClause() As String
            Dim v_arrSumAmount() As Double
            v_arrTitleClause = v_TitleClause.Split("~")
            ReDim v_arrTypeClause(v_arrTitleClause.GetLength(0))
            ReDim v_arrSumAmount(v_arrTitleClause.GetLength(0))
            For ik As Integer = 0 To v_arrTitleClause.GetLength(0) - 1
                v_arrSumAmount(ik) = 0
            Next
            'Inquiry data
            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If
            v_obj.GetSysVar("SYSTEM", "CURRDATE", v_strBUSDATE)
            'Insert vao db
            Dim v_ds As New DataSet
            Dim v_sql As String
            Dim v_strTablename As String
            Dim v_strProcname As String
            Dim v_IntRowtitle As Integer
            v_sql = "SELECT * FROM filemaster WHERE filecode='" & v_strFileCode & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_sql)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_strTablename = v_ds.Tables(0).Rows(0)("TABLENAME")
                v_IntRowtitle = v_ds.Tables(0).Rows(0)("ROWTITLE")
                v_strProcname = v_ds.Tables(0).Rows(0)("PROCNAME")
            Else
                'Tra ve ma loi
                Return -1
            End If

            Dim v_strBeginInsertClause As String
            v_strBeginInsertClause = "INSERT INTO " & v_strTablename & " (AUTOID,"

            v_sql = "SELECT * FROM filemap WHERE filecode='" & v_strFileCode & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_sql)
            If v_ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To v_arrTitleClause.GetLength(0) - 1
                    Dim v_strFileFld, v_strTblFld As String
                    v_strFileFld = v_arrTitleClause(i)
                    For j As Integer = 0 To v_ds.Tables(0).Rows.Count - 1
                        If v_strFileFld.ToUpper = CStr(v_ds.Tables(0).Rows(j)("FILEROWNAME")).ToUpper Then
                            v_strTblFld = v_ds.Tables(0).Rows(j)("tblrowname")
                            v_arrTypeClause(i) = v_ds.Tables(0).Rows(j)("tblrowtype")
                            v_strBeginInsertClause = v_strBeginInsertClause & v_strTblFld & ","
                            Exit For
                        End If
                    Next
                Next
                v_strBeginInsertClause = Strings.Left(v_strBeginInsertClause, v_strBeginInsertClause.Length - 1) & ")"
            Else
                'Tra ve ma loi
                Return -1
            End If
            Dim v_strEndInsertClause, v_strInsertClause As String
            Dim v_strValueClause As String
            Dim v_strArrValue() As String


            'Backup old data
            v_sql = "select count(1) from " & v_strTablename & " where status = 'C' and fileid = '" & v_strFileID & "' "
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_sql)
            If v_ds.Tables(0).Rows(0)(0) = "0" Then 'Clean old data
                v_sql = "delete " & v_strTablename & " where fileid = '" & v_strFileID & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_sql)
            End If

            'Kiem tra xem fileid co duy nhat hay ko?
            v_sql = "select count(1) from " & v_strTablename & " where fileid = '" & v_strFileID & "' and txdate = to_date('" & v_strBUSDATE & "','DD/MM/RRRR') "
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_sql)
            If v_ds.Tables(0).Rows(0)(0) > 0 Then
                Return ERR_SA_FILEID_DUPLICATED
            End If
            'Kiem tra xem fileid co duy nhat hay ko?
            v_sql = "select count(1) from " & v_strTablename & "HIST" & " where fileid = '" & v_strFileID & "' and txdate = to_date('" & v_strBUSDATE & "','DD/MM/RRRR') "
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_sql)
            If v_ds.Tables(0).Rows(0)(0) > 0 Then
                Return ERR_SA_FILEID_DUPLICATED
            End If

            For i As Integer = 1 To v_arrClause.GetLength(0) - 2
                v_strEndInsertClause = " VALUES (seq_" & v_strTablename & ".nextval,"
                v_strValueClause = v_arrClause(i)
                v_strArrValue = v_strValueClause.Split("~")
                For j As Integer = 0 To v_strArrValue.GetLength(0) - 2
                    Select Case v_arrTypeClause(j)
                        Case "C"
                            v_strEndInsertClause = v_strEndInsertClause & "'" & v_strArrValue(j) & "',"
                        Case "N"
                            v_strEndInsertClause = v_strEndInsertClause & CDbl(IIf(v_strArrValue(j) Is DBNull.Value Or v_strArrValue(j) = String.Empty Or Not IsNumeric(v_strArrValue(j)), "0", v_strArrValue(j))) & ","
                            v_arrSumAmount(j) = v_arrSumAmount(j) + CDbl(IIf(v_strArrValue(j) Is DBNull.Value Or v_strArrValue(j) = String.Empty Or Not IsNumeric(v_strArrValue(j)), "0", v_strArrValue(j)))
                        Case "D"
                            v_strEndInsertClause = v_strEndInsertClause & "TO_DATE('" & v_strArrValue(j) & "','" & gc_FORMAT_DATE & "')" & ","
                    End Select
                Next
                v_strEndInsertClause = Strings.Left(v_strEndInsertClause, v_strEndInsertClause.Length - 1) & ")"
                v_strInsertClause = v_strBeginInsertClause & v_strEndInsertClause
                v_obj.ExecuteNonQuery(CommandType.Text, v_strInsertClause)
            Next
            v_lngErrCode = PrepareData(pv_xmlDocument)

            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function PrepareData(ByRef pv_xmlDocument As XmlDocumentEx) As Long
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strFileCode As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)
            Dim v_lngErrCode As Long = ERR_SYSTEM_OK
            Dim v_strErrorSource As String = "SA.TRANSACTUPLOAD.PrepareData", v_strErrorMessage, v_strStoredName, v_strProcname As String
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_strFileID As String = String.Empty


            If Not (v_attrColl.GetNamedItem(gc_AtributeAUTOID) Is Nothing) Then
                v_strFileID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeAUTOID), Xml.XmlAttribute).Value)
            Else
                v_strFileID = String.Empty
            End If

            'Insert vao db
            Dim v_ds As New DataSet
            Dim v_sql As String
            v_sql = "SELECT * FROM filemaster WHERE filecode='" & v_strFileCode & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_sql)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_strProcname = v_ds.Tables(0).Rows(0)("PROCNAME")
            Else
                'Tra ve ma loi
                Return -1
            End If

            v_strStoredName = "cspks_filemaster." & v_strProcname
            Dim v_objParam As New StoreParameter
            Dim v_arrPara(2) As StoreParameter

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_fileid"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamValue = v_strFileID
            v_objParam.ParamSize = 100
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(0) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_err_code"
            v_objParam.ParamDirection = ParameterDirection.Output
            v_objParam.ParamValue = ""
            v_objParam.ParamSize = 100
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(1) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_err_param"
            v_objParam.ParamDirection = ParameterDirection.Output
            v_objParam.ParamValue = ""
            v_objParam.ParamSize = 100
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(2) = v_objParam

            v_lngErrCode = v_obj.ExecuteOracleStored(v_strStoredName, v_arrPara, 1)

            If Not IsNumeric(v_arrPara(2).ParamValue) Then
                v_lngErrCode = 0
            Else
                v_lngErrCode = CDec(v_arrPara(2).ParamValue)
            End If
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            End If
            Complete()

            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

End Class
