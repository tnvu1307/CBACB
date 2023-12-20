Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data

Public Class CFAUTH
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "CFAUTH"
    End Sub

    Overrides Function Add(ByRef v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_lngErrCode As Long
        Try
            v_lngErrCode = AUTH_CoreAdd(pv_xmlDocument)
            If v_lngErrCode <> 0 Then
                Dim v_strErrorSource, v_strErrorMessage As String
                v_strErrorSource = "CFAUTH.Add"
                v_strErrorMessage = String.Empty

                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                             & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                             & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                BuildXMLErrorException(pv_xmlDocument, v_strErrorSource, v_lngErrCode, v_strErrorMessage)
            End If
            'ContextUtil.SetComplete()
            v_strMessage = pv_xmlDocument.InnerXml
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Overrides Function Adhoc(ByRef v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strSQL, v_strClause, v_strLocal, v_strAutoId, v_strLinkAuth As String
            Dim v_intCount As Integer = 0
            Dim v_lngErrCode As Long = ERR_SYSTEM_OK

            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If
            If Not (v_attrColl.GetNamedItem(gc_AtributeREFERENCE) Is Nothing) Then
                v_strLinkAuth = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)
            Else
                v_strLinkAuth = String.Empty
            End If
            If Not (v_attrColl.GetNamedItem(gc_AtributeCLAUSE) Is Nothing) Then
                v_strAutoId = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value).Trim
            Else
                v_strAutoId = String.Empty
            End If

            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            If Len(v_strAutoId) > 0 Then
                v_strSQL = "UPDATE CFAUTH SET LINKAUTH ='" & v_strLinkAuth & "' WHERE  AUTOID ='" & v_strAutoId & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End If

            v_strMessage = pv_xmlDocument.InnerXml
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    'HaiLT bo de Edit di theo luo`ng Maintain
    Overrides Function Edit(ByRef v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_lngErrCode As Long
        Try
            v_lngErrCode = CFAUTH_CoreEdit(pv_xmlDocument)
            If v_lngErrCode <> 0 Then
                Dim v_strErrorSource, v_strErrorMessage As String

                v_strErrorSource = "CFAUTH.Edit"
                v_strErrorMessage = String.Empty

                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                            & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                             & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                BuildXMLErrorException(pv_xmlDocument, v_strErrorSource, v_lngErrCode, v_strErrorMessage)
            End If
            'ContextUtil.SetComplete()
            v_strMessage = pv_xmlDocument.InnerXml
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

#Region " Overrides functions "
    Overrides Function CheckBeforeAdd(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        ' Return 0
        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strCUSTID As String
            Dim v_strFLDNAME, v_strFLDTYPE, v_strVALDATE, v_strEXPDATE, v_strVALUE As String
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
                        Case "CUSTID"
                            v_strCUSTID = Trim(v_strVALUE)
                        Case "VALDATE"
                            v_strVALDATE = Trim(v_strVALUE)
                        Case "EXPDATE"
                            v_strEXPDATE = Trim(v_strVALUE)



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

            'Val Date<= exp date
            'Exp Date> Ngay lam viec cua he thong 
            v_strSQL = "SELECT VARVALUE  FROM SYSVAR WHERE VARNAME = 'CURRDATE'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'If DDMMYYYY_SystemDate(v_ds.Tables(0).Rows(0)("VARVALUE")) > DDMMYYYY_SystemDate(v_strVALDATE) Then
            '    Return ERR_CF_CURRDATE_SMALLER_THAN_VALDATE
            'End If
            If DDMMYYYY_SystemDate(v_ds.Tables(0).Rows(0)("VARVALUE")) > DDMMYYYY_SystemDate(v_strEXPDATE) Then
                Return ERR_CF_CURRDATE_SMALLER_THAN_EXPDATE
            End If
            If DDMMYYYY_SystemDate(v_strVALDATE) > DDMMYYYY_SystemDate(v_strEXPDATE) Then
                Return ERR_CF_CURRDATE_SMALLER_THAN_VALDATE
            End If
            'Kiem tra CUSTID phai ton tai
            If v_strCUSTID <> "" Then
                v_strSQL = "SELECT COUNT(CUSTID) FROM CFMAST WHERE  CUSTID  = '" & Replace(v_strCUSTID, ".", "") & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count = 1 Then
                    If v_ds.Tables(0).Rows(0)(0) = 0 Then
                        Return ERR_CF_CFAUTH_CUSTID_NOTFOUND
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

        'Return 0
    End Function

    Overrides Function CheckBeforeEdit(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strAcctno As String
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strCUSTID As String
            Dim v_strFLDNAME, v_strFLDTYPE, v_strVALDATE, v_strEXPDATE, v_strVALUE As String
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
                        Case "CUSTID"
                            v_strCUSTID = Trim(v_strVALUE)
                        Case "VALDATE"
                            v_strVALDATE = Trim(v_strVALUE)
                        Case "EXPDATE"
                            v_strEXPDATE = Trim(v_strVALUE)
                        Case "ACCTNO"
                            v_strAcctno = Trim(v_strVALUE)

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
            'Val Date>=Ngay lam viec cua he thong.
            'Exp Date> Ngay lam viec cua he thong 
            v_strSQL = "SELECT VARVALUE  FROM SYSVAR WHERE VARNAME = 'CURRDATE'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'If DDMMYYYY_SystemDate(v_ds.Tables(0).Rows(0)("VARVALUE")) > DDMMYYYY_SystemDate(v_strVALDATE) Then
            '    Return ERR_CF_CURRDATE_SMALLER_THAN_VALDATE
            'End If
            If DDMMYYYY_SystemDate(v_ds.Tables(0).Rows(0)("VARVALUE")) > DDMMYYYY_SystemDate(v_strEXPDATE) Then
                Return ERR_CF_CURRDATE_SMALLER_THAN_EXPDATE
            End If
            If DDMMYYYY_SystemDate(v_strVALDATE) > DDMMYYYY_SystemDate(v_strEXPDATE) Then
                Return ERR_CF_CURRDATE_SMALLER_THAN_VALDATE ' su dung lai ma loi, thuc ra la check valdate va expdate
            End If
            'Ki?m tra CUSTID phai ton tai
            If v_strCUSTID <> "" Then
                v_strSQL = "SELECT COUNT(CUSTID) FROM CFMAST WHERE  CUSTID  = '" & v_strCUSTID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count = 1 Then
                    If v_ds.Tables(0).Rows(0)(0) = 0 Then
                        Return ERR_CF_CFAUTH_CUSTID_NOTFOUND
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

#End Region

#Region " Special Function "
    Private Function AUTH_CoreAdd(ByRef pv_xmlDocument As XmlDocumentEx) As Long
        Dim v_lngErrorCode As Long

        v_lngErrorCode = CheckBeforeAdd(pv_xmlDocument.InnerXml)

        If v_lngErrorCode <> 0 Then
            Return v_lngErrorCode
            Exit Function
        End If

        Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
        Dim v_strClause As String
        Dim v_strLocal As String
        Dim v_strAutoId As String

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

        'Inquiry data
        Dim v_obj As DataAccess
        If v_strLocal = "Y" Then
            v_obj = New DataAccess
        ElseIf v_strLocal = "N" Then
            v_obj = New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
        End If

        Dim v_ds As DataSet

        Dim v_strSQL As String = "INSERT INTO " & ATTR_TABLE
        Dim v_strListOfFields As String = vbNullString
        Dim v_strListOfValues As String = vbNullString
        Dim v_strSignature As String = String.Empty
        Dim v_strCustID As String = String.Empty


        Dim v_decID As Decimal
        If (v_strAutoId = gc_AutoIdUsed) Then
            v_decID = v_obj.GetIDValue(ATTR_TABLE)
        End If

        'C?p nh?t vào CSDL
        Dim v_nodeList As Xml.XmlNodeList, i As Integer
        Dim v_strNewValue As String, v_strOldValue As String, v_strFLDNAME As String, v_strFLDTYPE As String

        v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

        For i = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
            With v_nodeList.Item(0).ChildNodes(i)
                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                v_strFLDTYPE = CStr(CType(.Attributes.GetNamedItem("fldtype"), Xml.XmlAttribute).Value)
                If v_strFLDNAME <> "SIGNATURE" Then
                    If v_strFLDNAME = "AUTOID" Then
                        v_strNewValue = v_decID
                        Me.autoidCFAuth = v_decID
                    Else
                        v_strNewValue = .InnerText.ToString
                    End If

                    If Len(v_strNewValue) > 0 Then
                        If Len(v_strListOfFields) = 0 Then
                            v_strListOfFields = "(" & v_strFLDNAME
                            Select Case v_strFLDTYPE
                                Case "System.String"
                                    v_strListOfValues = "('" & v_strNewValue.Replace("'", "''") & "'"
                                Case "System.Date"
                                    v_strListOfValues = "('" & v_strNewValue & "'"
                                Case "System.DateTime"
                                    v_strListOfValues = "(TO_DATE('" & v_strNewValue & "', '" & gc_FORMAT_DATE & "')"
                                Case Else
                                    v_strListOfValues = "(" & v_strNewValue
                            End Select
                        Else
                            v_strListOfFields = v_strListOfFields & "," & v_strFLDNAME
                            Select Case v_strFLDTYPE
                                Case "System.String"
                                    v_strListOfValues = v_strListOfValues & ",'" & v_strNewValue.Replace("'", "''") & "'"
                                Case "System.DateTime"
                                    v_strListOfValues = v_strListOfValues & ",TO_DATE('" & v_strNewValue & "', '" & gc_FORMAT_DATE & "')"
                                Case GetType(Double).Name
                                    v_strListOfValues = v_strListOfValues & "," & Replace(v_strNewValue, ",", "")
                                Case Else
                                    v_strListOfValues = v_strListOfValues & "," & v_strNewValue
                            End Select
                        End If
                    End If
                Else
                    'v_strSignature = v_strNewValue
                    v_strSignature = .InnerText.ToString()
                End If
            End With
        Next

        If Len(v_strListOfFields) <> 0 Then
            v_strListOfFields = v_strListOfFields & ")"
            v_strListOfValues = v_strListOfValues & ")"
            v_strSQL = v_strSQL & " " & v_strListOfFields & " VALUES " & v_strListOfValues
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
        End If

        'For i = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
        '    With v_nodeList.Item(0).ChildNodes(i)
        '        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
        '        v_strFLDTYPE = CStr(CType(.Attributes.GetNamedItem("fldtype"), Xml.XmlAttribute).Value)
        '        If v_strFLDNAME = "SIGNATURE" Then
        '            v_strSignature = .InnerText.ToString
        '        End If
        '    End With
        'Next
        'With v_nodeList.Item(0).ChildNodes(v_nodeList.Item(0).ChildNodes.Count - 1)
        '    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
        '    v_strFLDTYPE = CStr(CType(.Attributes.GetNamedItem("fldtype"), Xml.XmlAttribute).Value)
        '    If v_strFLDNAME = "SIGNATURE" Then
        '        v_strSignature = .InnerText.ToString
        '    End If
        'End With
        Dim result As Long

        If v_strSignature.Length > 0 Then

            Dim v_arrParamValues As Object()
            Dim v_arrParamNames As Object()
            Dim v_arrParamTypes As Object()

            ReDim v_arrParamValues(1)
            ReDim v_arrParamNames(1)
            ReDim v_arrParamTypes(1)

            v_arrParamValues(0) = v_decID
            v_arrParamValues(1) = v_strSignature

            v_arrParamNames(0) = "AUTOID"
            v_arrParamNames(1) = "SIGNATURE"

            v_arrParamTypes(0) = "OracleDbType.Varchar2"
            v_arrParamTypes(1) = "OracleDbType.Varchar2"

            v_obj.ExecuteNonQuery("INSERT_CFAUTH_SIGN", v_arrParamNames, v_arrParamValues, v_arrParamTypes)

            ''AnhVT Added - Maintenance Approval Retro            
            'result = Me.MaintainLog(pv_xmlDocument, gc_ActionAdd)
            'If Not (result = ERR_APPROVE_REQUIRED Or result = ERR_SYSTEM_OK) Then
            '    Return result
            'End If

        End If

        'AnhVT Added - Maintenance Approval Retro        
        result = Me.MaintainLog(pv_xmlDocument, gc_ActionAdd)
        If Not (result = ERR_APPROVE_REQUIRED Or result = ERR_SYSTEM_OK) Then
            Return result
        End If

        Return 0
    End Function

    Private Function CFAUTH_CoreEdit(ByRef pv_xmlDocument As XmlDocumentEx) As Long

        Dim v_lngErrorCode As Long

        v_lngErrorCode = CheckBeforeEdit(pv_xmlDocument.InnerXml)
        If v_lngErrorCode <> 0 Then
            Return v_lngErrorCode
            Exit Function
        End If

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

        'Update data
        Dim v_obj As DataAccess
        If v_strLocal = "Y" Then
            v_obj = New DataAccess
        ElseIf v_strLocal = "N" Then
            v_obj = New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
        End If

        Dim v_ds As DataSet
        Dim v_strSQL As String = "UPDATE " & ATTR_TABLE & " SET ", v_strUPD As String = vbNullString, v_strUPDTMP As String = vbNullString

        Dim v_nodeList As Xml.XmlNodeList, i As Integer
        Dim v_strNewValue As String, v_strOldValue As String, v_strFLDNAME As String, v_strFLDTYPE As String
        Dim v_strAutoID, v_strSignature As String
        v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

        For i = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
            With v_nodeList.Item(0).ChildNodes(i)
                v_strOldValue = CStr(CType(v_nodeList.Item(0).ChildNodes(i).Attributes.GetNamedItem("oldval"), Xml.XmlAttribute).Value)
                v_strNewValue = .InnerText.ToString
                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                v_strFLDTYPE = CStr(CType(.Attributes.GetNamedItem("fldtype"), Xml.XmlAttribute).Value)
                If v_strFLDNAME <> "SIGNATURE" Then

                    If v_strFLDNAME = "AUTOID" Then
                        v_strAutoID = v_strNewValue
                    End If
                    If Trim(v_strOldValue) <> Trim(v_strNewValue) Then
                        v_strFLDNAME = CStr(CType(v_nodeList.Item(0).ChildNodes(i).Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strFLDTYPE = CStr(CType(v_nodeList.Item(0).ChildNodes(i).Attributes.GetNamedItem("fldtype"), Xml.XmlAttribute).Value)

                        Select Case v_strFLDTYPE
                            Case "System.String"
                                v_strUPDTMP = v_strFLDNAME & " = '" & v_strNewValue & "'"
                            Case "System.DateTime"
                                v_strUPDTMP = v_strFLDNAME & " = TO_DATE('" & v_strNewValue & "', '" & gc_FORMAT_DATE & "')"
                            Case GetType(Double).Name
                                v_strUPDTMP = v_strFLDNAME & "=" & Replace(v_strNewValue, ",", "")
                            Case Else
                                v_strUPDTMP = v_strFLDNAME & "=" & v_strNewValue
                        End Select

                        If Len(v_strUPD) = 0 Then
                            v_strUPD = v_strUPDTMP
                        Else
                            v_strUPD = v_strUPD & ", " & v_strUPDTMP
                        End If
                    Else
                        v_strFLDNAME = CStr(CType(v_nodeList.Item(0).ChildNodes(i).Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strFLDTYPE = CStr(CType(v_nodeList.Item(0).ChildNodes(i).Attributes.GetNamedItem("fldtype"), Xml.XmlAttribute).Value)
                    End If
                Else
                    v_strSignature = v_strNewValue
                End If
            End With
        Next

        If Len(v_strUPD) <> 0 Then
            v_strSQL = v_strSQL & v_strUPD & " WHERE 0=0 AND " & v_strClause
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
        End If


        'For i = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
        '    With v_nodeList.Item(0).ChildNodes(i)
        '        v_strOldValue = CStr(CType(v_nodeList.Item(0).ChildNodes(i).Attributes.GetNamedItem("oldval"), Xml.XmlAttribute).Value)
        '        v_strNewValue = .InnerText.ToString
        '        If Trim(v_strOldValue) <> Trim(v_strNewValue) Then
        '            v_strFLDNAME = CStr(CType(v_nodeList.Item(0).ChildNodes(i).Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
        '            v_strFLDTYPE = CStr(CType(v_nodeList.Item(0).ChildNodes(i).Attributes.GetNamedItem("fldtype"), Xml.XmlAttribute).Value)
        '            If v_strFLDNAME = "SIGNATURE" Then
        '                v_strSignature = v_strNewValue
        '                Dim v_arrParamValues As Object()
        '                Dim v_arrParamNames As Object()
        '                Dim v_arrParamTypes As Object()

        '                ReDim v_arrParamValues(1)
        '                ReDim v_arrParamNames(1)
        '                ReDim v_arrParamTypes(1)

        '                v_arrParamValues(0) = v_strAutoID
        '                v_arrParamValues(1) = v_strSignature

        '                v_arrParamNames(0) = "AUTOID"
        '                v_arrParamNames(1) = "SIGNATURE"

        '                v_arrParamTypes(0) = "OracleDbType.Number"
        '                v_arrParamTypes(1) = "OracleDbType.Varchar2"

        '                v_obj.ExecuteNonQuery("INSERT_CFAUTH_SIGN", v_arrParamNames, v_arrParamValues, v_arrParamTypes)

        '            End If
        '        End If
        '    End With
        'Next

        If v_strSignature.Length > 0 Then

            Dim v_arrParamValues As Object()
            Dim v_arrParamNames As Object()
            Dim v_arrParamTypes As Object()

            ReDim v_arrParamValues(1)
            ReDim v_arrParamNames(1)
            ReDim v_arrParamTypes(1)

            v_arrParamValues(0) = v_strAutoID
            v_arrParamValues(1) = v_strSignature

            v_arrParamNames(0) = "AUTOID"
            v_arrParamNames(1) = "SIGNATURE"

            v_arrParamTypes(0) = "OracleDbType.Number"
            v_arrParamTypes(1) = "OracleDbType.Varchar2"

            v_obj.ExecuteNonQuery("INSERT_CFAUTH_SIGN", v_arrParamNames, v_arrParamValues, v_arrParamTypes)

            'AnhVT Added - Maintenance Approval Retro

        End If

        Dim result As Long
        result = Me.MaintainLog(pv_xmlDocument, gc_ActionEdiT)
        If Not (result = ERR_APPROVE_REQUIRED Or result = ERR_SYSTEM_OK) Then
            Return result
        End If

        Return 0
    End Function

    'HaiLT bo de DELETE di theo luo`ng Maintain

    '' PhuongHT add de luu vet thong tin nguoi uy quyen
    Overridable Function Delete(ByRef v_strMessage As String) As Long
        Dim v_lngErrCode As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Try
            v_lngErrCode = CFAUTH_CoreDelete(pv_xmlDocument)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Dim v_strErrorSource, v_strErrorMessage As String
                v_strErrorSource = Me.ATTR_TABLE + ".Delete"
                v_strErrorMessage = String.Empty

                LogError.Write("Error source: " + v_strErrorSource + vbNewLine _
                            + "Error code: " + v_lngErrCode.ToString() + vbNewLine _
                            + "Error message: " + v_strErrorMessage, "EventLogEntryType.Error")
                BuildXMLErrorException(pv_xmlDocument, v_strErrorSource, v_lngErrCode, v_strErrorMessage)
            End If
            v_strMessage = pv_xmlDocument.InnerXml
            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function CFAUTH_CoreDelete(ByRef pv_xmlDocument As XmlDocumentEx) As Long
        Dim v_lngErrorCode As Long
        Dim v_strSYSVAR As String, v_DataAccess As New DataAccess
        'Check HOST Active
        v_DataAccess.NewDBInstance(gc_MODULE_HOST)
        v_lngErrorCode = v_DataAccess.GetSysVar("SYSTEM", "HOSTATUS", v_strSYSVAR)
        If v_lngErrorCode <> ERR_SYSTEM_OK Then
            Rollback() 'ContextUtil.SetAbort()
            Return v_lngErrorCode
        End If
        If v_strSYSVAR <> OPERATION_ACTIVE Then
            Rollback() 'ContextUtil.SetAbort()
            Return ERR_SA_HOST_OPERATION_ISINACTIVE
        End If

        Dim v_strSystemProcessMsg As String = pv_xmlDocument.InnerXml
        v_lngErrorCode = CheckBeforeDelete(v_strSystemProcessMsg)
        If v_lngErrorCode <> ERR_SYSTEM_OK Then
            Rollback() 'ContextUtil.SetAbort()
            Return v_lngErrorCode
            Exit Function
        End If
        v_lngErrorCode = SystemProcessBeforeDelete(v_strSystemProcessMsg)

        If v_lngErrorCode <> ERR_SYSTEM_OK Then
            Return v_lngErrorCode
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

        Dim v_strSQL As String = "UPDATE " & ATTR_TABLE & " SET DELTD='Y' WHERE 0=0 AND " & v_strClause

        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
        Complete() 'ContextUtil.SetComplete()

        'TheNN added, 03-Mar-2012
        Dim result As Long
        result = Me.MaintainLog(pv_xmlDocument, gc_ActionDelete)
        If Not (result = ERR_APPROVE_REQUIRED Or result = ERR_SYSTEM_OK) Then
            Return result
        End If

        Return ERR_SYSTEM_OK
    End Function
#End Region
End Class
