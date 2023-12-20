Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Public Class SECBASKET
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "SECBASKET"
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

            If v_strActionFlag = "DELETE" Then
                v_strBASKETID = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeREFERENCE).Value
                v_strSYMBOL = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeRESERVER).Value
            Else
                v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                    With v_nodeList.Item(0).ChildNodes(i)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strVALUE = .InnerText.ToString()

                        Select Case Trim(v_strFLDNAME)
                            Case "AUTOID"
                                v_strAUTOID = Trim(v_strVALUE)
                            Case "BASKETID"
                                v_strBASKETID = Trim(v_strVALUE)
                            Case "SYMBOL"
                                v_strSYMBOL = Trim(v_strVALUE)
                        End Select
                    End With
                Next
            End If

            'Begin apply lai chung khoan Margin
            Dim v_objParam As StoreParameter
            Dim v_arrParam(2) As StoreParameter

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_basketid"
            v_objParam.ParamValue = v_strBASKETID
            v_objParam.ParamSize = 30
            v_objParam.ParamType = GetType(System.String).Name
            v_objParam.ParamDirection = ParameterDirection.Input
            v_arrParam(0) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_symbol"
            v_objParam.ParamValue = v_strSYMBOL
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
        Dim v_strErrorSource, v_strErrorMessage As String
        v_strErrorSource = Me.ATTR_TABLE + ".CheckBeforeAdd"
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_ds As New DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strTLID, v_strBASKETID, v_strSYMBOL As String
            Dim v_strSQL, v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String
            Dim v_dblMRPRICELOAN, v_dblMRPRICERATE, v_dblMRRATIOLOAN, v_dblMRRATIORATE As Double

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

            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strVALUE = .InnerText.ToString()
                    Select Case Trim(v_strFLDNAME)
                        Case "BASKETID"
                            v_strBASKETID = Trim(v_strVALUE)
                        Case "SYMBOL"
                            v_strSYMBOL = Trim(v_strVALUE)
                        Case "MRPRICELOAN"    'MRPRICELOAN
                            v_dblMRPRICELOAN = CDbl(v_strVALUE)
                        Case "MRPRICERATE"    'MRPRICERATE
                            v_dblMRPRICERATE = CDbl(v_strVALUE)
                        Case "MRRATIOLOAN"    'MRRATIOLOAN
                            v_dblMRRATIOLOAN = CDbl(v_strVALUE)
                        Case "MRRATIORATE"    'MRRATIORATE
                            v_dblMRRATIORATE = CDbl(v_strVALUE)
                    End Select
                End With
            Next

            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            If v_dblMRRATIORATE * v_dblMRPRICERATE < v_dblMRRATIOLOAN * v_dblMRPRICELOAN Then
                Return ERR_SA_LNRATE_GREATER_THAN_PPRATE
            End If

            v_strSQL = "SELECT COUNT(*) FROM SECBASKET WHERE BASKETID='" _
                & v_strBASKETID & "' AND SYMBOL='" & v_strSYMBOL & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If gf_CorrectNumericField(v_ds.Tables(0).Rows(0)(0)) > 0 Then
                Return ERR_SA_SECBASKETID_SYMBOL_DUPLICATED
            End If


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

    Overrides Function CheckBeforeEdit(ByVal v_strMessage As String) As Long
        Dim v_strErrorSource, v_strErrorMessage As String
        v_strErrorSource = Me.ATTR_TABLE + ".CheckBeforeEdit"
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_ds As New DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strTLID, v_strAUTOID, v_strBASKETID, v_strSYMBOL As String
            Dim v_strSQL, v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String
            Dim v_dblMRPRICELOAN, v_dblMRPRICERATE, v_dblMRRATIOLOAN, v_dblMRRATIORATE As Double

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
            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strVALUE = .InnerText.ToString()

                    Select Case Trim(v_strFLDNAME)
                        Case "AUTOID"
                            v_strAUTOID = Trim(v_strVALUE)
                        Case "BASKETID"
                            v_strBASKETID = Trim(v_strVALUE)
                        Case "SYMBOL"
                            v_strSYMBOL = Trim(v_strVALUE)
                        Case "MRPRICELOAN"    'MRPRICELOAN
                            v_dblMRPRICELOAN = CDbl(v_strVALUE)
                        Case "MRPRICERATE"    'MRPRICERATE
                            v_dblMRPRICERATE = CDbl(v_strVALUE)
                        Case "MRRATIOLOAN"    'MRRATIOLOAN
                            v_dblMRRATIOLOAN = CDbl(v_strVALUE)
                        Case "MRRATIORATE"    'MRRATIORATE
                            v_dblMRRATIORATE = CDbl(v_strVALUE)
                    End Select
                End With
            Next

            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If


            If v_dblMRRATIORATE * v_dblMRPRICERATE < v_dblMRRATIOLOAN * v_dblMRPRICELOAN Then
                Return ERR_SA_LNRATE_GREATER_THAN_PPRATE
            End If

            v_strSQL = "SELECT COUNT(*) FROM SECBASKET WHERE AUTOID<>'" & v_strAUTOID & "' AND BASKETID='" _
                & v_strBASKETID & "' AND SYMBOL='" & v_strSYMBOL & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If gf_CorrectNumericField(v_ds.Tables(0).Rows(0)(0)) > 0 Then
                Return ERR_SA_SECBASKETID_SYMBOL_DUPLICATED
            End If

            'Neu OK thi luu vet vao bang HIST
            v_strSQL = "insert into secbaskethist " _
                        & "(autoid,basketid, symbol, mrratiorate, mrratioloan, " _
                        & "       mrpricerate, mrpriceloan, description, backupdt,importdt, makerid, action) " _
                        & "select autoid,basketid, symbol, mrratiorate, mrratioloan, " _
                        & "       mrpricerate, mrpriceloan, description, to_char(getcurrdate,'DD/MM/YYYY:HH:MI:SS') backupdt,importdt, '" & v_strTLID & "' makerid, 'EDIT' " _
                        & "from secbasket where autoid = '" & v_strAUTOID & "' "
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

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

    Overrides Function SystemProcessBeforeDelete(ByRef v_strMessage As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource, v_strErrorMessage As String
        v_strErrorSource = Me.ATTR_TABLE + ".SystemProcessBeforeDelete"
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_ds As New DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Try


            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strTLID, v_strActionFlag, v_strCLAUSE, v_strAUTOID, v_strBASKETID, v_strSYMBOL As String
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

            v_strSQL = "SELECT * FROM " & ATTR_TABLE & " WHERE " & v_strCLAUSE & " "
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            v_strAUTOID = v_ds.Tables(0).Rows(0)("AUTOID")
            v_strBASKETID = v_ds.Tables(0).Rows(0)("BASKETID")
            v_strSYMBOL = v_ds.Tables(0).Rows(0)("SYMBOL")
            pv_xmlDocument.DocumentElement.Attributes(gc_AtributeREFERENCE).Value = v_strBASKETID
            pv_xmlDocument.DocumentElement.Attributes(gc_AtributeRESERVER).Value = v_strSYMBOL
            v_strMessage = pv_xmlDocument.InnerXml

            'Neu OK thi luu vet vao bang HIST
            v_strSQL = "insert into secbaskethist " _
                        & "(autoid,basketid, symbol, mrratiorate, mrratioloan, " _
                        & "       mrpricerate, mrpriceloan, description, backupdt,importdt, makerid, action) " _
                        & "select autoid,basketid, symbol, mrratiorate, mrratioloan, " _
                        & "       mrpricerate, mrpriceloan, description, to_char(getcurrdate,'DD/MM/YYYY:HH:MI:SS') backupdt,importdt, '" & v_strTLID & "' makerid, 'DELETE' " _
                        & "from secbasket where autoid = '" & v_strAUTOID & "' "
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
#End Region

End Class
