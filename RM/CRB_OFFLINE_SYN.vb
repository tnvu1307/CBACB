Imports HostCommonLibrary
Imports System.IO
Imports DataAccessLayer
Imports System.Text
Imports System.Xml
Imports System.Data
Public Class CRB_OFFLINE_SYN
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Private mDelimiterRows As Char = "|"
    Private mDelimiterItems As Char = "~"

    Public Sub New()
        ATTR_TABLE = "CRB_OFFLINE_SYN"
    End Sub

    Overrides Function Adhoc(ByRef v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strFuncName As String
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            v_strFuncName = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeFUNCNAME), Xml.XmlAttribute).Value)

            Select Case Trim(v_strFuncName)
                Case "ImportXMLFileToDB"
                    v_lngErrCode = ImportXMLFileToDB(pv_xmlDocument)
                    If v_lngErrCode <> ERR_SYSTEM_OK Then
                        Return v_lngErrCode
                    End If
                Case "SyncDataFromBIDVFile"
                    v_lngErrCode = SyncDataFromBIDVFile(pv_xmlDocument)
                    If v_lngErrCode <> ERR_SYSTEM_OK Then
                        Return v_lngErrCode
                    End If
                Case "UpdateInfoAftExport"
                    v_lngErrCode = UpdateInfoAftExport(pv_xmlDocument)
                    If v_lngErrCode <> ERR_SYSTEM_OK Then
                        Return v_lngErrCode
                    End If
                Case "GenBIDVBATCHID"
                    v_lngErrCode = GenBIDVBATCHID(pv_xmlDocument)
                    If v_lngErrCode <> ERR_SYSTEM_OK Then
                        Return v_lngErrCode
                    End If
            End Select

            'ContextUtil.SetComplete()S
            v_strMessage = pv_xmlDocument.InnerXml
            Return v_lngErrCode
        Catch ex As Exception

        End Try
    End Function

    Private Function ExecuteProcApprove(ByVal v_strAprProcname As String, ByVal v_strBankCode As String, _
                                        ByVal v_strTellerID As String, ByRef v_strFeedBackMsg As String) As Long
        Try
            Dim v_lngErrCode As Long
            Dim v_obj As DataAccess
            v_obj = New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_arrPara(3) As StoreParameter
            Dim v_objParam As New StoreParameter
            v_objParam.ParamName = "p_BankCode"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamValue = v_strBankCode
            v_objParam.ParamSize = 100
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(0) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_tlid"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamValue = v_strTellerID
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

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_err_message"
            v_objParam.ParamDirection = ParameterDirection.Output
            v_objParam.ParamValue = ""
            v_objParam.ParamSize = 100
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(3) = v_objParam
            v_strFeedBackMsg = v_obj.ExecuteOracleStored("cspks_rmproc." & v_strAprProcname, v_arrPara, 3)

            If Not IsNumeric(v_arrPara(2).ParamValue) Then
                v_lngErrCode = 0
            Else
                v_lngErrCode = CDec(v_arrPara(2).ParamValue)
            End If
            v_strFeedBackMsg = CStr(v_arrPara(3).ParamValue)
            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Return ERR_SA_IMPORT_FILE_INVALID 'File du lieu dau vao khong hop le
            Throw ex
        End Try
    End Function

    Private Function ExecuteProcFillter(ByVal v_strProcFillter As String, ByVal v_strBankCode As String,
                                        ByVal v_strTellerID As String, ByRef v_strFeedBackMsg As String) As Long
        Try
            Dim v_lngErrCode As Long
            Dim v_obj As DataAccess
            v_obj = New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)

            If Len(Trim(v_strProcFillter)) > 0 Then
                'Goi store procedure fillter neu co khai bao can fillter
                Dim v_arrPara(3) As StoreParameter

                Dim v_objParam As New StoreParameter
                v_objParam.ParamName = "p_BankCode"
                v_objParam.ParamDirection = ParameterDirection.Input
                v_objParam.ParamValue = v_strBankCode
                v_objParam.ParamSize = 100
                v_objParam.ParamType = GetType(System.String).Name
                v_arrPara(0) = v_objParam

                v_objParam = New StoreParameter
                v_objParam.ParamName = "p_tlid"
                v_objParam.ParamDirection = ParameterDirection.Input
                v_objParam.ParamValue = v_strTellerID
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

                v_objParam = New StoreParameter
                v_objParam.ParamName = "p_err_message"
                v_objParam.ParamDirection = ParameterDirection.Output
                v_objParam.ParamValue = ""
                v_objParam.ParamSize = 100
                v_objParam.ParamType = GetType(System.String).Name
                v_arrPara(3) = v_objParam
                v_strFeedBackMsg = v_obj.ExecuteOracleStored("cspks_rmproc." & v_strProcFillter, v_arrPara, 3)

                If Not IsNumeric(v_arrPara(2).ParamValue) Then
                    v_lngErrCode = 0
                Else
                    v_lngErrCode = CDec(v_arrPara(2).ParamValue)
                End If
                v_strFeedBackMsg = CStr(v_arrPara(3).ParamValue)
                Return v_lngErrCode
            End If
        Catch ex As Exception
            LogError.WriteException(ex)
            Return ERR_SA_IMPORT_FILE_INVALID 'File du lieu dau vao khong hop le
            Throw ex
        End Try
    End Function

    Private Function UpdateInfoAftExport(ByRef pv_xmlDocument As XmlDocumentEx) As Long
        Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
        Dim v_strFileCode As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)
        Dim v_strClause As String
        Dim v_strTxDate As String
        Dim v_strFileName As String
        Dim v_strFeedBackMsg As String
        Try

            If Not (v_attrColl.GetNamedItem(gc_AtributeTXDATE) Is Nothing) Then
                v_strTxDate = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXDATE), Xml.XmlAttribute).Value)
            Else
                v_strTxDate = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeCLAUSE) Is Nothing) Then
                v_strClause = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Else
                v_strClause = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeREFERENCE) Is Nothing) Then
                v_strFileName = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)
            Else
                v_strFileName = String.Empty
            End If

            Dim v_lngErrCode As Long
            Dim v_obj As DataAccess
            v_obj = New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_arrPara(4) As StoreParameter
            Dim v_objParam As New StoreParameter
            v_objParam.ParamName = "p_TxDate"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamValue = v_strTxDate
            v_objParam.ParamSize = 100
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(0) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_arrAutoID"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamValue = v_strClause
            v_objParam.ParamSize = 3500
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(1) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_FileName"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamValue = v_strFileName
            v_objParam.ParamSize = 100
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(2) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_err_code"
            v_objParam.ParamDirection = ParameterDirection.Output
            v_objParam.ParamValue = ""
            v_objParam.ParamSize = 100
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(3) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_msg_err"
            v_objParam.ParamDirection = ParameterDirection.Output
            v_objParam.ParamValue = ""
            v_objParam.ParamSize = 100
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(4) = v_objParam

            v_lngErrCode = v_obj.ExecuteOracleStored("cspks_rmproc.pr_UpdateInfoAftExport", v_arrPara, 3)

            If Not IsNumeric(v_arrPara(3).ParamValue) Then
                v_lngErrCode = 0
            Else
                v_lngErrCode = CDec(v_arrPara(3).ParamValue)
            End If

            v_strFeedBackMsg = CStr(v_arrPara(4).ParamValue)
            pv_xmlDocument.DocumentElement.Attributes.GetNamedItem(gc_AtributeRESERVER).Value = v_strFeedBackMsg

            Return v_lngErrCode

        Catch ex As Exception
            LogError.WriteException(ex)
            Return ERR_SYSTEM_START 'File du lieu dau vao khong hop le
        End Try
    End Function

    Private Function GenBIDVBATCHID(ByRef pv_xmlDocument As XmlDocumentEx) As Long
        Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
        Dim v_strFileCode As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)
        Dim v_strBankCode As String
        Dim v_strMSGID As String
        Dim v_strTxDate As String
        Dim v_strBatchID As String
        Try

            If Not (v_attrColl.GetNamedItem(gc_AtributeTXDATE) Is Nothing) Then
                v_strTxDate = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXDATE), Xml.XmlAttribute).Value)
            Else
                v_strTxDate = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeCLAUSE) Is Nothing) Then
                v_strBankCode = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Else
                v_strBankCode = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeREFERENCE) Is Nothing) Then
                v_strMSGID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)
            Else
                v_strMSGID = String.Empty
            End If

            Dim v_lngErrCode As Long
            Dim v_obj As DataAccess
            v_obj = New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_arrPara(4) As StoreParameter
            Dim v_objParam As New StoreParameter
            v_objParam.ParamName = "pv_txdate"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamValue = v_strTxDate
            v_objParam.ParamSize = 100
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(0) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "pv_BankCode"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamValue = v_strBankCode
            v_objParam.ParamSize = 100
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(1) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "pv_msgid"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamValue = v_strMSGID
            v_objParam.ParamSize = 100
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(2) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "pv_BathcID"
            v_objParam.ParamDirection = ParameterDirection.Output
            v_objParam.ParamValue = ""
            v_objParam.ParamSize = 100
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(3) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_err_code"
            v_objParam.ParamDirection = ParameterDirection.Output
            v_objParam.ParamValue = ""
            v_objParam.ParamSize = 100
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(4) = v_objParam

            v_lngErrCode = v_obj.ExecuteOracleStored("cspks_rmproc.fn_CreateAndGetBatchID", v_arrPara, 4)

            If Not IsNumeric(v_arrPara(4).ParamValue) Then
                v_lngErrCode = 0
            Else
                v_lngErrCode = CDec(v_arrPara(4).ParamValue)
            End If

            v_strBatchID = CStr(v_arrPara(3).ParamValue)
            pv_xmlDocument.DocumentElement.Attributes.GetNamedItem(gc_AtributeRESERVER).Value = v_strBatchID

            Return v_lngErrCode

        Catch ex As Exception
            LogError.WriteException(ex)
            Return ERR_SYSTEM_START 'File du lieu dau vao khong hop le
        End Try
    End Function

    Private Function ImportXMLFileToDB(ByRef pv_xmlDocument As XmlDocumentEx) As Long
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strFileCode As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)
            Dim v_strClause As String
            Dim v_strLocal As String
            Dim v_strAutoId As String
            Dim v_intCount As Integer = 0
            Dim v_lngErrCode As Long = ERR_SYSTEM_OK
            Dim v_strErrorSource As String = "RM.CRB_OFFLINE_SYN.ImportXMLFileToDB", v_strErrorMessage As String
            Dim v_strFeedBackMsg As String = String.Empty
            Dim v_strIsApprove As String
            Dim v_strOVRRQD As String
            Dim v_strBankCode As String
            Dim v_strTellerID As String

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

            If Not (v_attrColl.GetNamedItem(gc_AtributeRESERVER) Is Nothing) Then
                v_strIsApprove = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeRESERVER), Xml.XmlAttribute).Value)
            Else
                v_strIsApprove = "N"
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeAUTOID) Is Nothing) Then
                v_strAutoId = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeAUTOID), Xml.XmlAttribute).Value)
            Else
                v_strAutoId = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeTLID) Is Nothing) Then
                v_strTellerID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Else
                v_strTellerID = String.Empty
            End If

            Dim v_arrClause() As String
            v_arrClause = v_strClause.Split(mDelimiterRows)
            Dim v_TitleClause As String = v_arrClause(0)
            Dim v_arrTitleClause() As String
            Dim v_arrTypeClause() As String
            v_arrTitleClause = v_TitleClause.Split(mDelimiterItems)
            ReDim v_arrTypeClause(v_arrTitleClause.GetLength(0))
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
            Dim v_strTablename As String
            Dim v_strProcname As String
            Dim v_strProcFillter As String
            Dim v_IntRowtitle As Integer
            v_sql = "SELECT * FROM CRBFILEMASTER WHERE FILECODE='" & v_strFileCode & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_sql)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_strTablename = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("OBJNAME"))
                v_strProcname = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("PROCNAME"))
                v_strProcFillter = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("PROCFILLTER"))
                v_IntRowtitle = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("ROWTITLE"))
                v_strOVRRQD = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("OVRRQD"))
                v_strBankCode = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("BANKNAME"))
            Else
                'Tra ve ma loi
                Return -1
            End If
            If v_strIsApprove = "N" Then
                'Khong can duyet thong tin thi se thuc hien import du lieu vao file temp
                Dim v_strBeginInsertClause As String
                v_strBeginInsertClause = "INSERT INTO " & v_strTablename & " ("
                v_sql = "SELECT * FROM CRBFILEMAP WHERE  FILECODE='" & v_strFileCode & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_sql)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    For i As Integer = 0 To v_arrTitleClause.GetLength(0) - 1
                        Dim v_strFileFld, v_strTblFld As String
                        v_strFileFld = v_arrTitleClause(i)
                        For j As Integer = 0 To v_ds.Tables(0).Rows.Count - 1
                            If v_strFileFld.ToUpper = CStr(v_ds.Tables(0).Rows(j)("FILEFLDNAME")).ToUpper Then
                                v_strTblFld = v_ds.Tables(0).Rows(j)("TBLFLDNAME")
                                v_arrTypeClause(i) = v_ds.Tables(0).Rows(j)("TBLFLDTYPE")
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
                Dim v_strSQL As String
                Dim v_strValueClause As String
                Dim v_strArrValue() As String

                'Clean old data
                v_sql = "TRUNCATE TABLE " & v_strTablename
                v_obj.ExecuteNonQuery(CommandType.Text, v_sql)

                For i As Integer = 1 To v_arrClause.GetLength(0) - 2
                    v_strEndInsertClause = " VALUES ("
                    v_strValueClause = v_arrClause(i)
                    v_strArrValue = v_strValueClause.Split(mDelimiterItems)
                    For j As Integer = 0 To v_strArrValue.GetLength(0) - 2
                        Select Case v_arrTypeClause(j)
                            Case "C"
                                v_strEndInsertClause = v_strEndInsertClause & "'" & gf_CorrectStringField(v_strArrValue(j)) & "',"
                            Case "N"
                                'QuangVD: sua de tranh loi convert string "" to decimal
                                If (v_strArrValue(j).ToString = "") Then
                                    v_strEndInsertClause = v_strEndInsertClause & "0" & ","
                                Else
                                    v_strEndInsertClause = v_strEndInsertClause & gf_CorrectNumericField(v_strArrValue(j)) & ","
                                End If
                                'QuangVD: end here
                            Case "D"
                                v_strEndInsertClause = v_strEndInsertClause & "TO_DATE('" & gf_CorrectStringField(v_strArrValue(j)) & "','" & gc_FORMAT_DATE & "')" & ","
                        End Select
                    Next
                    v_strEndInsertClause = Strings.Left(v_strEndInsertClause, v_strEndInsertClause.Length - 1) & "); "
                    v_strInsertClause = v_strBeginInsertClause & v_strEndInsertClause & vbCrLf

                    v_strSQL = v_strSQL & v_strInsertClause

                    If i Mod gc_EXECUTE_ROWS = 0 Then
                        v_strSQL = "BEGIN " & v_strSQL & " END; "
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                        v_strSQL = String.Empty
                    End If

                Next

                If v_strSQL <> String.Empty Then
                    v_strSQL = "BEGIN " & v_strSQL & " END; "
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    v_strSQL = String.Empty
                End If

                v_strFeedBackMsg = "Total records: " & v_arrClause.GetLength(0) - 2 & ControlChars.CrLf
                pv_xmlDocument.DocumentElement.Attributes.GetNamedItem(gc_AtributeRESERVER).Value = v_strFeedBackMsg

            End If

            If v_strProcFillter.Length > 0 And v_strIsApprove = "N" Then
                v_lngErrCode = ExecuteProcFillter(v_strProcFillter, v_strBankCode, v_strTellerID, v_strFeedBackMsg)
            End If

            If v_strIsApprove = "Y" And v_strOVRRQD = "Y" Then
                'Neu khong can duyet thong tin hoac dang o buoc duyet thi thuc hien ghi du lieu tu Temp sang dile du lieu
                'Sau khi insert xong, thuc hien dong bo du lieu 
                'Goi store procedure
                v_lngErrCode = ExecuteProcApprove(v_strProcname, v_strBankCode, v_strTellerID, v_strFeedBackMsg)
                pv_xmlDocument.DocumentElement.Attributes.GetNamedItem(gc_AtributeRESERVER).Value = "Tổng số dòng đồng bộ thành công: " & v_strFeedBackMsg & ControlChars.CrLf

            End If

            If v_lngErrCode <> ERR_SYSTEM_OK Then
                'Tra ve ma loi xuat ra tu function
                pv_xmlDocument.DocumentElement.Attributes.GetNamedItem(gc_AtributeRESERVER).Value = v_strFeedBackMsg
            End If
            Return v_lngErrCode

        Catch ex As Exception
            LogError.WriteException(ex)
            Return ERR_SA_IMPORT_FILE_INVALID 'File du lieu dau vao khong hop le
            Throw ex
        End Try


    End Function

    Public Function SyncDataFromBIDVFile(ByRef pv_strObjMsg As XmlDocumentEx) As Long
        Dim v_attrColl As Xml.XmlAttributeCollection = pv_strObjMsg.DocumentElement.Attributes
        Dim v_strFileCode As String
        Dim v_strClause As String
        Dim v_strLocal As String
        Dim v_strAutoId As String
        Dim v_intCount As Integer = 0
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "RM.CRB_OFFLINE_SYN.SyncDataFromBIDVFile", v_strErrorMessage As String
        Dim v_strFeedBackMsg As String = String.Empty
        Dim v_strIsApprove As String
        Dim v_strOVRRQD As String
        Dim v_strBankCode As String
        Dim v_strTellerID As String
        Dim v_strInsertClause As String
        Dim v_obj As DataAccess
        v_obj = New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)
        Dim v_arrClause() As String
        'Dim v_TitleClause As String = v_arrClause(0)
        'Dim v_arrTitleClause() As String
        'Dim v_arrTypeClause() As String
        Dim v_ds As New DataSet
        Dim v_SQL, v_SQL2 As String
        Dim v_strTablename As String
        Dim v_strProcname As String
        Dim v_strProcFillter As String
        Dim v_IntRowtitle As Integer
        Dim v_strZip As String
        Dim v_arrZipBIDV() As String
        Dim v_arrZipBIDVSub() As String
        Dim v_XMLMessage As New XmlDocument
        Dim v_strCurrdate As String
        Try
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

            If Not (v_attrColl.GetNamedItem(gc_AtributeTLID) Is Nothing) Then
                v_strTellerID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Else
                v_strTellerID = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeREFERENCE) Is Nothing) Then
                v_strZip = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value) 'v_XMLMessage.DocumentElement.SelectSingleNode("/ObjectMessage").Attributes(gc_AtributeREFERENCE).Value()
            Else
                v_strZip = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeCLAUSE) Is Nothing) Then
                v_strFileCode = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Else
                v_strFileCode = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeRESERVER) Is Nothing) Then
                v_strIsApprove = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeRESERVER), Xml.XmlAttribute).Value)
            Else
                v_strIsApprove = "N"
            End If

            v_SQL2 = "SELECT VARVALUE FROM SYSVAR WHERE VARNAME = 'CURRDATE' AND GRNAME='SYSTEM' "
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_SQL2)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_strCurrdate = v_ds.Tables(0).Rows(0)("VARVALUE")
            End If

            v_SQL = "SELECT * FROM CRBFILEMASTER WHERE FILECODE='" & v_strFileCode & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_SQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_strTablename = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("OBJNAME"))
                v_strProcname = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("PROCNAME"))
                v_strProcFillter = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("PROCFILLTER"))
                v_IntRowtitle = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("ROWTITLE"))
                v_strOVRRQD = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("OVRRQD"))
                v_strBankCode = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("BANKNAME"))
            Else
                'Tra ve ma loi
                Return -1
            End If



            v_strZip = v_strZip.Replace("&#xD;&#xA;", String.Empty)
            v_arrZipBIDV = v_strZip.Split(vbNewLine)
            If (v_arrZipBIDV.Length() <> 0) Then

                v_SQL = "TRUNCATE TABLE " & v_strTablename
                v_obj.ExecuteNonQuery(CommandType.Text, v_SQL)

                'insert data vao T_CRB_OFFLINE_BODSYNC
                v_SQL = String.Empty
                For i As Integer = 0 To v_arrZipBIDV.Length() - 1 Step 1
                    v_strInsertClause = String.Empty
                    If (v_arrZipBIDV(i).ToString.Trim() <> String.Empty) Then
                        v_arrZipBIDVSub = v_arrZipBIDV(i).ToString.Trim().Split(",")
                        v_strInsertClause = "INSERT INTO T_CRB_OFFLINE_BODSYNC (BANKCODE, BANKACCOUNT, CUSTOMERNAME, BALANCE, AVLBALANCE,CREATEDATE,STATUS) " & ControlChars.CrLf _
                                 & "VALUES ('" & v_strBankCode & "','" & v_arrZipBIDVSub(0).ToString().Trim() & "', '" & v_arrZipBIDVSub(1).ToString().Trim() & "', " & v_arrZipBIDVSub(2).ToString().Trim() & ", " & v_arrZipBIDVSub(3).ToString().Trim() & ", to_date('" & v_strCurrdate & "','" & gc_FORMAT_DATE & "'),'P');"

                    End If
                    If v_strInsertClause.Length <> 0 Then
                        v_SQL = v_SQL & v_strInsertClause
                    End If
                    If i Mod gc_EXECUTE_ROWS = 0 Then
                        v_SQL = "BEGIN " & v_SQL & " END; "
                        v_obj.ExecuteNonQuery(CommandType.Text, v_SQL)
                        v_SQL = String.Empty
                    End If
                Next
                If v_SQL <> String.Empty Then
                    v_SQL = "BEGIN " & v_SQL & " END; "
                    v_obj.ExecuteNonQuery(CommandType.Text, v_SQL)
                    v_SQL = String.Empty
                End If
            End If

            If v_strProcFillter.Length > 0 And v_strIsApprove = "N" Then
                v_lngErrCode = ExecuteProcFillter(v_strProcFillter, v_strBankCode, v_strTellerID, v_strFeedBackMsg)
            End If

            If v_strIsApprove = "Y" And v_strOVRRQD = "Y" Then
                'Neu khong can duyet thong tin hoac dang o buoc duyet thi thuc hien ghi du lieu tu Temp sang dile du lieu
                'Sau khi insert xong, thuc hien dong bo du lieu 
                'Goi store procedure
                v_lngErrCode = ExecuteProcApprove(v_strProcname, v_strBankCode, v_strTellerID, v_strFeedBackMsg)

            End If

            If v_lngErrCode <> ERR_SYSTEM_OK Then
                'Tra ve ma loi xuat ra tu function
                pv_strObjMsg.DocumentElement.Attributes.GetNamedItem(gc_AtributeRESERVER).Value = v_strFeedBackMsg
            End If
            Return v_lngErrCode


            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        Finally
            v_obj = Nothing
        End Try
    End Function

End Class
