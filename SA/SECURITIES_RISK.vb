Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Public Class SECURITIES_RISK
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "SECURITIES_RISK"
    End Sub
    Private Function ApplySystemParamDetail(ByRef v_strMessage As String) As Long
        Dim v_strErrorSource, v_strErrorMessage As String
        v_strErrorSource = Me.ATTR_TABLE + ".ApplySystemParamDetail"
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_ds As New DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strActionFlag, v_strCLAUSE, v_strAUTOID, v_strBASKETID, v_strSYMBOL As String
            Dim v_strSQL, v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String

            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If
            If Not (v_attrColl.GetNamedItem(gc_AtributeACTFLAG) Is Nothing) Then
                v_strActionFlag = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeACTFLAG), Xml.XmlAttribute).Value)
            Else
                v_strActionFlag = String.Empty
            End If
            If Not (v_attrColl.GetNamedItem(gc_AtributeCLAUSE) Is Nothing) Then
                v_strCLAUSE = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Else
                v_strCLAUSE = String.Empty
            End If

            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            'Begin apply lai chung khoan Margin
            Dim v_objParam As StoreParameter
            Dim v_arrParam(2) As StoreParameter

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_basketid"
            v_objParam.ParamValue = ""
            v_objParam.ParamSize = 30
            v_objParam.ParamType = GetType(System.String).Name
            v_objParam.ParamDirection = ParameterDirection.Input
            v_arrParam(0) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_symbol"
            v_objParam.ParamValue = ""
            v_objParam.ParamSize = 30
            v_objParam.ParamType = GetType(System.String).Name
            v_objParam.ParamDirection = ParameterDirection.Input
            v_arrParam(1) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_err_code"
            v_objParam.ParamValue = ""
            v_objParam.ParamSize = 100
            v_objParam.ParamType = GetType(System.String).Name
            v_objParam.ParamDirection = ParameterDirection.InputOutput
            v_arrParam(2) = v_objParam
            v_lngErrCode = v_obj.ExecuteOracleStored("cspks_saproc.fn_ApplySystemParamDetail", v_arrParam, 2)
            'v_obj.ExecuteStoredNonQuerry("cspks_odproc.pr_RM_UnholdCancelOD", v_arrParam)
            'v_lngErrCode = CLng(v_arrParam(2).ParamValue)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                 & "Error code: " & v_lngErrCode & "!" & vbNewLine _
                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                Return v_lngErrCode
            End If
            'End Apply chung khoan

            Return ERR_SYSTEM_OK
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
#Region " Overrides functions "
    Overrides Function CheckBeforeAdd(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strMRRATIORATE, v_strMRRATIOLOAN, v_strMRPRICERATE, v_strCODEID As String
            Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String
            Dim v_strSQL As String

            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If

            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strVALUE = .InnerText.ToString()
                    Select Case Trim(v_strFLDNAME)
                        Case "CODEID"
                            v_strCODEID = Trim(v_strVALUE)
                        Case "MRRATIORATE"
                            v_strMRRATIORATE = Trim(v_strVALUE)
                        Case "MRRATIOLOAN"
                            v_strMRRATIOLOAN = Trim(v_strVALUE)
                        Case "MRPRICERATE"
                            v_strMRPRICERATE = Trim(v_strVALUE)
                    End Select
                End With
            Next

            If v_strMRRATIORATE >= 100 Then
                Return ERR_MR_MRRATIORATE_INVALID
            End If
            If v_strMRRATIOLOAN >= 100 Then
                Return ERR_MR_MRRATIOLOAN_INVALID
            End If

            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            If v_strCODEID.Length > 0 Then
                v_strSQL = "SELECT COUNT(CODEID) FROM " & ATTR_TABLE & " WHERE CODEID = '" & v_strCODEID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count = 1 Then
                    If v_ds.Tables(0).Rows(0)(0) > 0 Then
                        Return ERR_SE_CODEID_DUPLICATE
                    End If
                End If
            End If


            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If

            'ContextUtil.SetComplete()
            Return 0
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try

    End Function

    Overrides Function CheckBeforeEdit(ByVal v_strMessage As String) As Long
        Dim v_strErrorSource, v_strErrorMessage As String
        v_strErrorSource = Me.ATTR_TABLE + ".CheckBeforeEdit"
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_ds As New DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strTLID, v_strBASKETID, v_strClause As String
            Dim v_strSQL, v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String

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
            If Not (v_attrColl.GetNamedItem(gc_AtributeCLAUSE) Is Nothing) Then
                v_strClause = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Else
                v_strClause = String.Empty
            End If

            'v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            'For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
            '    With v_nodeList.Item(0).ChildNodes(i)
            '        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
            '        v_strVALUE = .InnerText.ToString()

            '        Select Case Trim(v_strFLDNAME)
            '            Case "BASKETID"
            '                v_strBASKETID = Trim(v_strVALUE)
            '        End Select
            '    End With
            'Next

            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            'LONGNH
            'If v_strClause.Length > 0 Then
            '    v_strSQL = "insert into SECURITIES_RISKHIST " & ControlChars.CrLf _
            '                & " (CODEID,MRMAXQTTY,MRRATIORATE,MRRATIOLOAN,MRPRICERATE,MRPRICELOAN,backupdt, ISMARGINALLOW,AFMAXAMT,AFMAXAMTT3, OPENDATE,MAKERID, ACTION) " & ControlChars.CrLf _
            '                & " select CODEID,MRMAXQTTY,MRRATIORATE,MRRATIOLOAN,MRPRICERATE,MRPRICELOAN, to_char(sysdate,'DD/MM/YYYY:HH:MI:SS') backupdt, ISMARGINALLOW,AFMAXAMT,AFMAXAMTT3, OPENDATE, '" & v_strTLID & "', 'EDIT' ACTION " & ControlChars.CrLf _
            '                & " from SECURITIES_RISK WHERE " & v_strClause
            '    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            'End If

            v_strSQL = "insert into SECURITIES_RISKHIST" & ControlChars.CrLf _
            & "(CODEID,MRMAXQTTY,MRRATIORATE,MRRATIOLOAN,MRPRICERATE,MRPRICELOAN,backupdt, ISMARGINALLOW, AFMAXAMT,AFMAXAMTT3, OPENDATE,MAKERID, ACTION)" & ControlChars.CrLf _
            & "select CODEID, MRMAXQTTY" & ControlChars.CrLf _
            & ", MRRATIORATE, MRRATIOLOAN,MRPRICERATE,MRPRICELOAN, to_char(TO_DATE(TO_CHAR(getcurrdate)||':'||TO_CHAR(SUBSTR(CURRENT_TIMESTAMP,12,7)),'DD/MM/YYYY:HH24:MI:SS'),'DD/MM/YYYY:HH24:MI:SS') backupdt, " & ControlChars.CrLf _
            & "ISMARGINALLOW,AFMAXAMT,AFMAXAMTT3, OPENDATE, '" & v_strTLID & "', 'EDIT' ACTION " & ControlChars.CrLf _
            & "from SECURITIES_RISK" & ControlChars.CrLf _
            & "WHERE " & v_strClause
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            'ContextUtil.SetComplete()
            Return ERR_SYSTEM_OK
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        Finally
            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If
        End Try
    End Function

    Overrides Function CheckBeforeDelete(ByVal v_strMessage As String) As Long
        Dim v_strErrorSource, v_strErrorMessage As String
        v_strErrorSource = Me.ATTR_TABLE + ".CheckBeforeDelete"
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_ds As New DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strTLID, v_strBASKETID, v_strClause As String
            Dim v_strSQL, v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String

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
            If Not (v_attrColl.GetNamedItem(gc_AtributeCLAUSE) Is Nothing) Then
                v_strClause = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Else
                v_strClause = String.Empty
            End If

            'v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            'For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
            '    With v_nodeList.Item(0).ChildNodes(i)
            '        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
            '        v_strVALUE = .InnerText.ToString()

            '        Select Case Trim(v_strFLDNAME)
            '            Case "BASKETID"
            '                v_strBASKETID = Trim(v_strVALUE)
            '        End Select
            '    End With
            'Next

            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            If v_strClause.Length > 0 Then
                v_strSQL = "insert into SECURITIES_RISKHIST " & ControlChars.CrLf _
                            & " (CODEID,MRMAXQTTY,MRRATIORATE,MRRATIOLOAN,MRPRICERATE,MRPRICELOAN,backupdt, ISMARGINALLOW,AFMAXAMT,AFMAXAMTT3, OPENDATE,MAKERID, ACTION) " & ControlChars.CrLf _
                            & " select CODEID,MRMAXQTTY,MRRATIORATE,MRRATIOLOAN,MRPRICERATE,MRPRICELOAN, to_char(sysdate,'DD/MM/YYYY:HH:MI:SS') backupdt, ISMARGINALLOW,AFMAXAMT,AFMAXAMTT3, OPENDATE, '" & v_strTLID & "', 'DELETE' ACTION " & ControlChars.CrLf _
                            & " from SECURITIES_RISK WHERE " & v_strClause
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End If

            'ContextUtil.SetComplete()
            Return ERR_SYSTEM_OK
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        Finally
            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If
        End Try

    End Function
    Overrides Function ProcessAfterAdd(ByVal v_strMessage As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        v_lngErrCode = ApplySystemParamDetail(v_strMessage)
        Return v_lngErrCode
    End Function

    Overrides Function ProcessAfterEdit(ByVal v_strMessage As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        v_lngErrCode = ApplySystemParamDetail(v_strMessage)
        Return v_lngErrCode
    End Function
    Overrides Function ProcessAfterDelete(ByVal v_strMessage As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        v_lngErrCode = ApplySystemParamDetail(v_strMessage)
        Return v_lngErrCode
    End Function
#End Region

End Class
