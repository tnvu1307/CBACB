Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data

Public Class CFSIGN
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "CFSIGN"
    End Sub

    'Overrides Function Add(ByRef v_strMessage As String) As Long
    '    Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
    '    Dim v_lngErrCode As Long

    '    Try
    '        v_lngErrCode = MyCoreAdd(pv_xmlDocument) 'Xu ly dac biet
    '        If v_lngErrCode <> 0 Then
    '            Dim v_strErrorSource, v_strErrorMessage As String

    '            v_strErrorSource = "CFSIGN.Add"
    '            v_strErrorMessage = String.Empty

    '            LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
    '                         & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
    '                         & "Error message: " & v_strErrorMessage, EventLogEntryType.Information)
    '            BuildXMLErrorException(pv_xmlDocument, v_strErrorSource, v_lngErrCode, v_strErrorMessage)
    '        End If
    '        'ContextUtil.SetComplete()
    '        v_strMessage = pv_xmlDocument.InnerXml
    '        Return v_lngErrCode
    '    Catch ex As Exception
    '        'ContextUtil.SetAbort()
    '        LogError.Write("Error source: " & ex.Source & vbNewLine _
    '                     & "Error code: System error!" & vbNewLine _
    '                     & "Error message: " & ex.Message,"EventLogEntryType.Error")
    '        Throw ex
    '    End Try
    'End Function

    'HaiLT bo de Edit di theo luo`ng Maintain

    'Overrides Function Edit(ByRef v_strMessage As String) As Long
    '    Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

    '    Dim v_lngErrCode As Long

    '    Try
    '        v_lngErrCode = MyCoreEdit(pv_xmlDocument) 'Xu ly dac biet
    '        If v_lngErrCode <> 0 Then
    '            Dim v_strErrorSource, v_strErrorMessage As String

    '            v_strErrorSource = "CFSIGN.Edit"
    '            v_strErrorMessage = String.Empty

    '            LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
    '                         & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
    '                         & "Error message: " & v_strErrorMessage, EventLogEntryType.Information)
    '            BuildXMLErrorException(pv_xmlDocument, v_strErrorSource, v_lngErrCode, v_strErrorMessage)
    '        End If
    '        'ContextUtil.SetComplete()
    '        v_strMessage = pv_xmlDocument.InnerXml
    '        Return v_lngErrCode
    '    Catch ex As Exception
    '        LogError.Write("Error source: " & ex.Source & vbNewLine _
    '                     & "Error code: System error!" & vbNewLine _
    '                     & "Error message: " & ex.Message,"EventLogEntryType.Error")
    '        Throw ex
    '    End Try
    'End Function

#Region " Special Function "
    Private Function MyCoreAdd(ByRef pv_xmlDocument As XmlDocumentEx) As Long
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
        Dim v_strVALDATE As String = String.Empty
        Dim v_strEXPDATE As String = String.Empty
        Dim v_strDESCRIPTION As String = String.Empty


        Dim v_decID As Decimal
        If (v_strAutoId = gc_AutoIdUsed) Then
            v_decID = v_obj.GetIDValue(ATTR_TABLE)
        End If

        'Cập nhật vào CSDL
        Dim v_nodeList As Xml.XmlNodeList, i As Integer
        Dim v_strNewValue As String, v_strOldValue As String, v_strFLDNAME As String, v_strFLDTYPE As String

        v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

        For i = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
            With v_nodeList.Item(0).ChildNodes(i)
                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                v_strFLDTYPE = CStr(CType(.Attributes.GetNamedItem("fldtype"), Xml.XmlAttribute).Value)

                If v_strFLDNAME = "AUTOID" Then
                    v_strNewValue = v_decID
                Else
                    v_strNewValue = .InnerText.ToString
                End If

                If v_strFLDNAME = "SIGNATURE" Then
                    v_strSignature = .InnerText.ToString
                End If
                If v_strFLDNAME = "CUSTID" Then
                    v_strCustID = .InnerText.ToString
                End If
                If v_strFLDNAME = "VALDATE" Then
                    v_strVALDATE = .InnerText.ToString
                End If
                If v_strFLDNAME = "EXPDATE" Then
                    v_strEXPDATE = .InnerText.ToString
                End If
                If v_strFLDNAME = "DESCRIPTION" Then
                    v_strDESCRIPTION = .InnerText.ToString
                End If

                If Len(v_strNewValue) > 0 Then
                    If Len(v_strListOfFields) = 0 Then
                        v_strListOfFields = "(" & v_strFLDNAME
                        Select Case v_strFLDTYPE
                            Case "System.String"
                                v_strListOfValues = "('" & v_strNewValue & "'"
                            Case "System.Date"
                                v_strListOfValues = "('" & v_strNewValue & "'"
                            Case Else
                                v_strListOfValues = "(" & v_strNewValue
                        End Select
                    Else
                        v_strListOfFields = v_strListOfFields & "," & v_strFLDNAME
                        Select Case v_strFLDTYPE
                            Case "System.String"
                                v_strListOfValues = v_strListOfValues & ",'" & v_strNewValue & "'"
                            Case "System.DateTime"
                                v_strListOfValues = v_strListOfValues & ",TO_DATE('" & v_strNewValue & "', '" & gc_FORMAT_DATE & "')"
                            Case GetType(Double).Name
                                v_strListOfValues = v_strListOfValues & "," & Replace(v_strNewValue, ",", "")
                            Case Else
                                v_strListOfValues = v_strListOfValues & "," & v_strNewValue
                        End Select
                    End If
                End If
            End With
        Next
        Dim v_arrParamValues As Object()
        Dim v_arrParamNames As Object()
        Dim v_arrParamTypes As Object()

        ReDim v_arrParamValues(4)
        ReDim v_arrParamNames(4)
        ReDim v_arrParamTypes(4)

        v_arrParamValues(0) = v_strCustID
        v_arrParamValues(1) = v_strSignature
        v_arrParamValues(2) = v_strVALDATE
        v_arrParamValues(3) = v_strEXPDATE
        v_arrParamValues(4) = v_strDESCRIPTION

        v_arrParamNames(0) = "CUSTID"
        v_arrParamNames(1) = "SIGNATURE"
        v_arrParamNames(2) = "VALDATE"
        v_arrParamNames(3) = "EXPDATE"
        v_arrParamNames(4) = "DESCRIPTION"

        v_arrParamTypes(0) = "OracleDbType.Varchar2"
        v_arrParamTypes(1) = "OracleDbType.Varchar2"
        v_arrParamTypes(2) = "OracleDbType.Varchar2"
        v_arrParamTypes(3) = "OracleDbType.Varchar2"
        v_arrParamTypes(4) = "OracleDbType.Varchar2"

        v_obj.ExecuteNonQuery("INSERT_SIGNATURE", v_arrParamNames, v_arrParamValues, v_arrParamTypes)

        'AnhVT Added - Maintenance Approval Retro
        Dim result As Long
        result = Me.MaintainLog(pv_xmlDocument, gc_ActionAdd)
        If Not (result = ERR_APPROVE_REQUIRED Or result = ERR_SYSTEM_OK) Then
            Return result
        End If
        Return 0

    End Function

    Private Function MyCoreEdit(ByRef pv_xmlDocument As XmlDocumentEx) As Long
        Dim v_lngErrorCode As Long
        Dim v_strSignature As String = String.Empty
        Dim v_strAUTOID As String = String.Empty
        Dim v_strVALDATE As String = String.Empty
        Dim v_strEXPDATE As String = String.Empty
        Dim v_strDESCRIPTION As String = String.Empty

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

        'Dim v_ds As DataSet
        'Dim v_strSQL As String = "UPDATE " & ATTR_TABLE & " SET ", v_strUPD As String = vbNullString, v_strUPDTMP As String = vbNullString

        Dim v_nodeList As Xml.XmlNodeList, i As Integer
        Dim v_strNewValue As String, v_strOldValue As String, v_strFLDNAME As String, v_strFLDTYPE As String

        v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

        For i = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
            With v_nodeList.Item(0).ChildNodes(i)
                'v_strOldValue = CStr(CType(v_nodeList.Item(0).ChildNodes(i).Attributes.GetNamedItem("oldval"), Xml.XmlAttribute).Value)
                'v_strNewValue = .InnerText.ToString
                'If Trim(v_strOldValue) <> Trim(v_strNewValue) Then
                'v_strFLDNAME = CStr(CType(v_nodeList.Item(0).ChildNodes(i).Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                'v_strFLDTYPE = CStr(CType(v_nodeList.Item(0).ChildNodes(i).Attributes.GetNamedItem("fldtype"), Xml.XmlAttribute).Value)

                'If v_strFLDNAME = "SIGNATURE" Then
                '    v_strSignature = .InnerText.ToString
                'End If
                'Select Case v_strFLDTYPE
                '    Case "System.String"
                '        v_strUPDTMP = v_strFLDNAME & " = '" & v_strNewValue & "'"
                '    Case "System.DateTime"
                '        v_strUPDTMP = v_strFLDNAME & " = TO_DATE('" & v_strNewValue & "', '" & gc_FORMAT_DATE & "')"
                '    Case GetType(Double).Name
                '        v_strUPDTMP = v_strFLDNAME & "=" & Replace(v_strNewValue, ",", "")
                '    Case Else
                '        v_strUPDTMP = v_strFLDNAME & "=" & v_strNewValue
                'End Select

                'If Len(v_strUPD) = 0 Then
                '    v_strUPD = v_strUPDTMP
                'Else
                '    v_strUPD = v_strUPD & ", " & v_strUPDTMP
                'End If
                'Else
                v_strFLDNAME = CStr(CType(v_nodeList.Item(0).ChildNodes(i).Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                v_strFLDTYPE = CStr(CType(v_nodeList.Item(0).ChildNodes(i).Attributes.GetNamedItem("fldtype"), Xml.XmlAttribute).Value)
                If v_strFLDNAME = "AUTOID" Then
                    v_strAUTOID = .InnerText.ToString
                ElseIf v_strFLDNAME = "VALDATE" Then
                    v_strVALDATE = .InnerText.ToString
                ElseIf v_strFLDNAME = "EXPDATE" Then
                    v_strEXPDATE = .InnerText.ToString
                ElseIf v_strFLDNAME = "SIGNATURE" Then
                    v_strSignature = .InnerText.ToString
                ElseIf v_strFLDNAME = "DESCRIPTION" Then
                    v_strDESCRIPTION = .InnerText.ToString
                End If
            End With
        Next
        Dim v_arrParamValues As Object()
        Dim v_arrParamNames As Object()
        Dim v_arrParamTypes As Object()

        ReDim v_arrParamValues(4)
        ReDim v_arrParamNames(4)
        ReDim v_arrParamTypes(4)

        v_arrParamValues(0) = v_strAUTOID
        v_arrParamValues(1) = v_strSignature
        v_arrParamValues(2) = v_strVALDATE
        v_arrParamValues(3) = v_strEXPDATE
        v_arrParamValues(4) = v_strDESCRIPTION

        v_arrParamNames(0) = "AUTOID"
        v_arrParamNames(1) = "SIGNATURE"
        v_arrParamNames(2) = "VALDATE"
        v_arrParamNames(3) = "EXPDATE"
        v_arrParamNames(4) = "DESCRIPTION"

        v_arrParamTypes(0) = "OracleDbType.Number"
        v_arrParamTypes(1) = "OracleDbType.Varchar2"
        v_arrParamTypes(2) = "OracleDbType.Varchar2"
        v_arrParamTypes(3) = "OracleDbType.Varchar2"
        v_arrParamTypes(4) = "OracleDbType.Varchar2"

        v_obj.ExecuteNonQuery("UPDATE_SIGNATURE", v_arrParamNames, v_arrParamValues, v_arrParamTypes)

        'AnhVT Added - Maintenance Approval Retro
        Dim result As Long
        result = Me.MaintainLog(pv_xmlDocument, gc_ActionAdd)
        If Not (result = ERR_APPROVE_REQUIRED Or result = ERR_SYSTEM_OK) Then
            Return result
        End If

        Return 0
    End Function
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

            '
            'Exp Date>= Ngay lam viec cua he thong 
            v_strSQL = "SELECT VARVALUE  FROM SYSVAR WHERE VARNAME = 'CURRDATE'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'If DDMMYYYY_SystemDate(v_ds.Tables(0).Rows(0)("VARVALUE")) > DDMMYYYY_SystemDate(v_strVALDATE) Then
            '    Return ERR_CF_CURRDATE_SMALLER_THAN_VALDATE
            'End If
            'If DDMMYYYY_SystemDate(v_ds.Tables(0).Rows(0)("VARVALUE")) > DDMMYYYY_SystemDate(v_strEXPDATE) Then
            '    Return ERR_CF_CURRDATE_SMALLER_THAN_EXPDATE
            'End If
            If DDMMYYYY_SystemDate(v_strVALDATE) > DDMMYYYY_SystemDate(v_strEXPDATE) Then
                Return ERR_CF_CURRDATE_SMALLER_THAN_VALDATE ' su dung lai ma loi, thuc ra la check valdate va expdate
            End If

            ' phuongHT add check tai mot thoi diem chi dc mot chu ky hieu luc
            ' CHI CHECK VOI NHUNG CHU KY CO NGAY EXPDATE>=NGAY HIEN TAI
            ' HaiLT bo kiem tra 1 chu ky tai 1 thoi diem, Neu khach hang la Ca nhan khi them moi se cap nhap het han doi voi cac chu ky cu
            ' Neu khach hang la to chuc thi them moi binh thuong

            'If (DDMMYYYY_SystemDate(v_strEXPDATE) >= DDMMYYYY_SystemDate(v_ds.Tables(0).Rows(0)("VARVALUE"))) Then
            '    v_strSQL = "SELECT COUNT(*) COUNT FROM CFSIGN cfs, cfmast cf  WHERE cfs.CUSTID='" & v_strCUSTID _
            '                & "' and cf.custid = cfs.custid and cf.custtype = 'I' AND ( (EXPDATE >= TO_DATE('" & v_strVALDATE & "', '" & gc_FORMAT_DATE_DB & "') AND VALDATE <= TO_DATE('" & v_strVALDATE & "' ,'" & gc_FORMAT_DATE_DB & "') )" _
            '                & " OR (EXPDATE >= TO_DATE('" & v_strEXPDATE & "', '" & gc_FORMAT_DATE_DB & "') AND VALDATE <= TO_DATE('" & v_strEXPDATE & "' ,'" & gc_FORMAT_DATE_DB & "')) " _
            '                & " OR (EXPDATE <= TO_DATE('" & v_strEXPDATE & "', '" & gc_FORMAT_DATE_DB & "') AND VALDATE >= TO_DATE('" & v_strVALDATE & "' ,'" & gc_FORMAT_DATE_DB & "'))) " _
            '                & " AND EXPDATE >= GETCURRDATE()"

            '    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            '    If (v_ds.Tables(0).Rows(0)("COUNT")) > 0 Then
            '        Return ERR_CF_CFSIGN_DUPLICATE
            '    End If
            'End If


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

        ' Return 0
        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strCUSTID As String
            Dim v_strFLDNAME, v_strFLDTYPE, v_strVALDATE, v_strEXPDATE, v_strVALUE, strAutoID As String
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
                        Case "AUTOID"
                            strAutoID = Trim(v_strVALUE)

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

            '
            'Exp Date>= Ngay lam viec cua he thong 
            v_strSQL = "SELECT VARVALUE  FROM SYSVAR WHERE VARNAME = 'CURRDATE'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'If DDMMYYYY_SystemDate(v_ds.Tables(0).Rows(0)("VARVALUE")) > DDMMYYYY_SystemDate(v_strVALDATE) Then
            '    Return ERR_CF_CURRDATE_SMALLER_THAN_VALDATE
            'End If
            'If DDMMYYYY_SystemDate(v_ds.Tables(0).Rows(0)("VARVALUE")) > DDMMYYYY_SystemDate(v_strEXPDATE) Then
            '    Return ERR_CF_CURRDATE_SMALLER_THAN_EXPDATE
            'End If
            If DDMMYYYY_SystemDate(v_strVALDATE) > DDMMYYYY_SystemDate(v_strEXPDATE) Then
                Return ERR_CF_CURRDATE_SMALLER_THAN_VALDATE ' su dung lai ma loi, thuc ra la check valdate va expdate
            End If

            ' phuongHT add check tai mot thoi diem chi dc mot chu ky hieu luc
            ' CHI CHECK VOI NHUNG CHU KY CO NGAY EXPDATE>=NGAY HIEN TAI
            If (DDMMYYYY_SystemDate(v_strEXPDATE) >= DDMMYYYY_SystemDate(v_ds.Tables(0).Rows(0)("VARVALUE"))) Then
                v_strSQL = "SELECT COUNT(*) COUNT FROM CFSIGN cfs, cfmast cf  WHERE cfs.CUSTID='" & v_strCUSTID _
                             & "'  and cf.custid = cfs.custid and cf.custtype = 'I' AND ( (EXPDATE >= TO_DATE('" & v_strVALDATE & "', '" & gc_FORMAT_DATE_Db & "') AND VALDATE <= TO_DATE('" & v_strVALDATE & "' ,'" & gc_FORMAT_DATE_Db & "') )" _
                            & "OR (EXPDATE >= TO_DATE('" & v_strEXPDATE & "', '" & gc_FORMAT_DATE_Db & "') AND VALDATE <= TO_DATE('" & v_strEXPDATE & "' ,'" & gc_FORMAT_DATE_Db & "')) " _
                             & "OR (EXPDATE <= TO_DATE('" & v_strEXPDATE & "', '" & gc_FORMAT_DATE_Db & "') AND VALDATE >= TO_DATE('" & v_strVALDATE & "' ,'" & gc_FORMAT_DATE_Db & "')) ) " _
                            & " AND AUTOID <> '" & strAutoID & "' AND EXPDATE >= GETCURRDATE()"

                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If (v_ds.Tables(0).Rows(0)("COUNT")) > 0 Then
                    Return ERR_CF_CFSIGN_DUPLICATE
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

    Overrides Function CheckBeforeDelete(ByVal v_strMessage As String) As Long
        Dim v_strErrorSource, v_strErrorMessage As String
        v_strErrorSource = Me.ATTR_TABLE + ".CheckBeforeDelete"
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_ds As New DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Try
            Return ERR_CF_DO_NOT_DELETE_CFSIGNATURE
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        Finally
            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If
        End Try
    End Function
#End Region

End Class
