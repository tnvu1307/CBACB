Imports CommonLibrary
Imports DataAccessLayer

Public Class CRPHYSAGREE
    Inherits CoreBusiness.Maintain
    Public Sub New()
        ATTR_TABLE = "CRPHYSAGREE"
    End Sub

   Overrides Function ProcessAfterAdd(ByVal v_strMessage As String) As Long
        Dim v_lngErrorCode, v_qtty, v_clvalue As Long
        Dim v_strSYSVAR, v_strSQLTmp As String, v_DataAccess As New DataAccess
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        'Return ERR_SYSTEM_OK
        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Try

            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strCLAUSE, v_strLocal, v_strCRPHYSAGREEID As String
            Dim v_strFLDNAME, v_strVALUE As String
            Dim v_strSQL, v_strTLID As String
            Dim v_BRID As String
            v_BRID = CStr(CType(v_attrColl.GetNamedItem("BRID"), Xml.XmlAttribute).Value)
            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If
            If Not (v_attrColl.GetNamedItem(gc_AtributeTLID) Is Nothing) Then
                v_strTLID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Else
                v_strTLID = String.Empty
            End If

            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If
            v_strSQL = "select max(AUTOID) from CRPHYSAGREE"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            v_strCRPHYSAGREEID = v_ds.Tables(0).Rows(0)(0)
            v_strSQL = "select QTTY,CLVALUE from CRPHYSAGREE where AUTOID=" & v_strCRPHYSAGREEID
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            v_qtty = v_ds.Tables(0).Rows(0)(0)
            v_clvalue = v_ds.Tables(0).Rows(0)(1)
            v_strSQL = "INSERT INTO CRPHYSAGREE_EX (AUTOID,CRPHYSAGREEID,CVALUE,CQTTY,REVALUE,REQTTY,REMVALUE,REMQTTY,STATUS) VALUES (seq_crphysagree_ex.NEXTVAL, " & v_strCRPHYSAGREEID & "," & v_clvalue & "," & v_qtty & ",0,0," & v_clvalue & "," & v_qtty & ",null)"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            v_strSQL = "UPDATE CRPHYSAGREE set REMQTTY = QTTY where AUTOID=" & v_strCRPHYSAGREEID
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Overridable Function ProcessAfterDelete(ByVal v_strMessage As String) As Long
        Try
            Dim v_lngErrCode As Long = 0, v_crphysagreeid As Long
            Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
            Dim v_strSYSVAR, v_strSQL As String, v_DataAccess As New DataAccess
            Dim v_ds As DataSet
            'Check HOST Active
            v_DataAccess.NewDBInstance(gc_MODULE_HOST)
            v_lngErrCode = v_DataAccess.GetSysVar("SYSTEM", "HOSTATUS", v_strSYSVAR)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            End If
            If v_strSYSVAR <> OPERATION_ACTIVE Then
                Rollback() 'ContextUtil.SetAbort()
                Return ERR_SA_HOST_OPERATION_ISINACTIVE
            End If

            Dim v_strSystemProcessMsg As String = pv_xmlDocument.InnerXml
            v_lngErrCode = CheckBeforeDelete(v_strSystemProcessMsg)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
                Exit Function
            End If
            v_lngErrCode = SystemProcessBeforeDelete(v_strSystemProcessMsg)

            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Return v_lngErrCode
            End If

            pv_xmlDocument.LoadXml(v_strSystemProcessMsg)

            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strClause As String
            Dim v_strLocal As String

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

            'Delete data
            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If
            v_strSQL = "select AUTOID from CRPHYSAGREE where " & v_strClause
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            v_crphysagreeid = v_ds.Tables(0).Rows(0)(0)
            v_strSQL = "DELETE FROM CRPHYSAGREE_EX WHERE CRPHYSAGREEID = " & v_crphysagreeid
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            Return v_lngErrCode
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            Throw ex
        End Try
    End Function
End Class

