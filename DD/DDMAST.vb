Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Public Class DDMAST
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "DDMAST"
    End Sub
    'thunt add new fucntion
    Overrides Function Add(ByRef v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_lngErrCode As Long
        Try
            v_lngErrCode = CoreAdd(pv_xmlDocument)
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

        Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
        Dim v_strSQL, v_strClause, v_strLocal, v_strFuncName, v_strAutoId, v_strTellerID, v_strOrderID As String
        Dim v_intCount As Integer = 0
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK


        If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
            v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
        Else
            v_strLocal = String.Empty
        End If
        If Not (v_attrColl.GetNamedItem(gc_AtributeCMDINQUIRY) Is Nothing) Then
            v_strClause = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCMDINQUIRY), Xml.XmlAttribute).Value)
        Else
            v_strClause = String.Empty
        End If
        If Not (v_attrColl.GetNamedItem(gc_AtributeFUNCNAME) Is Nothing) Then
            v_strFuncName = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeFUNCNAME), Xml.XmlAttribute).Value)
        Else
            v_strFuncName = String.Empty
        End If
        If Not (v_attrColl.GetNamedItem(gc_AtributeTLID) Is Nothing) Then
            v_strTellerID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
        Else
            v_strTellerID = String.Empty
        End If
        v_strOrderID = v_strClause.Trim

        Dim v_obj As DataAccess
        If v_strLocal = "Y" Then
            v_obj = New DataAccess
        ElseIf v_strLocal = "N" Then
            v_obj = New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
        End If
        Try
            'Select Case Trim(v_strFuncName)
            '    Case "ADD"
            '        v_lngErrCode = Add(pv_xmlDocument)
            '    Case "EDIT"
            '        v_lngErrCode = Edit(pv_xmlDocument)
            '    Case "DELETE"
            '        v_lngErrCode = Delete(pv_xmlDocument)
            'End Select
            'v_strMessage = pv_xmlDocument.InnerXml
            ''ContextUtil.SetComplete()
            'Return v_lngErrCode

        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
    Overrides Function CheckBeforeAdd(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_strCmdSQL, v_strObjMsg, v_strFLDNAME, v_strREFCASAACCT, v_strClause, v_strCCYCD, v_strACCOUNTTYPE, v_strISDEFAULT, v_strVALUE, v_strRESULT, v_strPAYMENTFEE As String
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_ds As DataSet
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strACCTNO, v_strCUSTID, v_strAUTOADV As String
            Dim v_strSQL As String
            Dim v_strBRID, v_strTXDATE, v_strTLID, v_strAUTOID As String

            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strTLID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Else
                v_strTLID = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeTXDATE) Is Nothing) Then
                v_strTXDATE = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXDATE), Xml.XmlAttribute).Value)
            Else
                v_strTXDATE = String.Empty
            End If

            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strVALUE = .InnerText.ToString()

                    Select Case Trim(v_strFLDNAME)
                        Case "AFACCTNO"
                            v_strACCTNO = Trim(v_strVALUE)
                        Case "CUSTID"
                            v_strCUSTID = Trim(v_strVALUE)
                        Case "REFCASAACCT"
                            v_strREFCASAACCT = Trim(v_strVALUE)
                        Case "ISDEFAULT"
                            v_strISDEFAULT = Trim(v_strVALUE)
                        Case "CCYCD"
                            v_strCCYCD = Trim(v_strVALUE)
                        Case "ACCOUNTTYPE"
                            v_strACCOUNTTYPE = Trim(v_strVALUE)
                        Case "PAYMENTFEE"
                            v_strPAYMENTFEE = Trim(v_strVALUE)
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


            'v_strCmdSQL = "Select COUNT(*) from DDMAST where  CUSTID = '" & v_strCUSTID & "'  and ACCOUNTTYPE='" & v_strACCOUNTTYPE & "' and CCYCD='" & v_strCCYCD & "'  and STATUS='A'"
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strCmdSQL)
            'If v_ds.Tables(0).Rows.Count > 0 Then
            '    If v_ds.Tables(0).Rows(0)(0) > 0 Then
            '        Return ERR_DD_ACCBANK_DUPLICATE
            '    End If
            'End If
            'If v_strCCYCD = "VND" Then
            v_strCmdSQL = "Select COUNT(*)  from DDMAST where CUSTID = '" & v_strCUSTID & "' and REFCASAACCT='" & v_strREFCASAACCT & "'  and ACCOUNTTYPE = '" & v_strACCOUNTTYPE & "' and CCYCD='" & v_strCCYCD & "'   and STATUS <> 'C'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strCmdSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_DD_ACCBANK_DUPLICATE
                End If
            End If

            v_strCmdSQL = "Select COUNT(*)  from DDMAST where CUSTID = '" & v_strCUSTID & "' and REFCASAACCT='" & v_strREFCASAACCT & "' and STATUS <> 'C'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strCmdSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_DD_ACCBANK_DUPLICATE
                End If
            End If

            v_strCmdSQL = "Select COUNT(*)  from DDMAST where CUSTID <> '" & v_strCUSTID & "' and REFCASAACCT='" & v_strREFCASAACCT & "' and STATUS <> 'C'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strCmdSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_DD_ACCBANK_DUPLICATE
                End If
            End If

            'v_strCmdSQL = "Select COUNT(*)  from DDMAST where CUSTID = '" & v_strCUSTID & "' and ACCOUNTTYPE = '" & v_strACCOUNTTYPE & "' and CCYCD='" & v_strCCYCD & "' and STATUS <> 'A'"
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strCmdSQL)
            'If v_ds.Tables(0).Rows.Count > 0 Then
            '    If v_ds.Tables(0).Rows(0)(0) > 0 Then
            '        Return ERR_DD_ACCBANK_DUPLICATE
            '    End If
            'End If

            If v_strCCYCD <> "VND" And v_strISDEFAULT = "Y" Then
                Return ERR_DD_DDTYPE_CCYCD_NOTFOUND
            End If

            If v_strISDEFAULT = "Y" Then
                v_strCmdSQL = "Select COUNT(*) from DDMAST where CUSTID = '" & v_strCUSTID & "' /*and REFCASAACCT = '" & v_strREFCASAACCT & "'*/ and ISDEFAULT = 'Y' and STATUS <> 'C'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strCmdSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    If v_ds.Tables(0).Rows(0)(0) > 0 Then
                        Return ERR_DD_ACCBANK_ISDEFAULT_DUPLICATE
                    End If
                End If

            End If

            If v_strPAYMENTFEE = "Y" Then
                v_strCmdSQL = "Select COUNT(*) from DDMAST where CUSTID = '" & v_strCUSTID & "' and PAYMENTFEE = 'Y' and STATUS <> 'C'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strCmdSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    If v_ds.Tables(0).Rows(0)(0) > 0 Then
                        Return -130015
                    End If
                End If
            End If

            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If

            Return 0
        Catch ex As Exception
            ''ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
        'Return 0
    End Function
    Private Function CoreAdd(ByRef pv_xmlDocument As XmlDocumentEx) As Long
        Dim v_strCmdSQL, v_strObjMsg, v_strFLDNAME, v_strREFCASAACCT, v_strISDEFAULT, v_strVALUE, v_strRESULT As String
        Dim v_strCUSTODYCD, v_strCCYCD, v_strACCOUNTTYPE As String
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_ds As DataSet
        Dim v_lngErrorCode As Long

        v_lngErrorCode = CheckBeforeAdd(pv_xmlDocument.InnerXml)

        If v_lngErrorCode <> 0 Then
            Return v_lngErrorCode
            Exit Function
        End If
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strACCTNO, v_strCUSTID, v_strAUTOADV As String
            Dim v_strSQL, v_strAutoId As String
            Dim v_strBRID, v_strTXDATE, v_strTLID As String

            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strTLID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Else
                v_strTLID = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeTXDATE) Is Nothing) Then
                v_strTXDATE = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXDATE), Xml.XmlAttribute).Value)
            Else
                v_strTXDATE = String.Empty
            End If
            If Not (v_attrColl.GetNamedItem(gc_AtributeAUTOID) Is Nothing) Then
                v_strAutoId = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeAUTOID), Xml.XmlAttribute).Value)
            Else
                v_strAutoId = String.Empty
            End If

            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strVALUE = .InnerText.ToString()

                    Select Case Trim(v_strFLDNAME)
                        Case "AFACCTNO"
                            v_strACCTNO = Trim(v_strVALUE)
                        Case "CUSTID"
                            v_strCUSTID = Trim(v_strVALUE)
                        Case "REFCASAACCT"
                            v_strREFCASAACCT = Trim(v_strVALUE)
                        Case "ISDEFAULT"
                            v_strISDEFAULT = Trim(v_strVALUE)
                        Case "CUSTODYCD"
                            v_strCUSTODYCD = Trim(v_strVALUE)
                        Case "CCYCD"
                            v_strCCYCD = Trim(v_strVALUE)
                        Case "ACCOUNTTYPE"
                            v_strACCOUNTTYPE = Trim(v_strVALUE)
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

            'v_strSQL = "INSERT INTO ddmast (AUTOID,ACTYPE,CUSTID,AFACCTNO,CUSTODYCD,ACCTNO,CCYCD,REFCASAACCT,BALANCE,ACRAMT,ADRAMT,MCRAMT,MDRAMT,HOLDBALANCE,BLOCKAMT,RECEIVING,NETTING,STATUS,PSTATUS,OPNDATE,ACCOUNTTYPE,ISDEFAULT,CLSDATE,LAST_CHANGE,DEPOLASTDT,COREBANK)" & ControlChars.CrLf _
            '        & "VALUES(SEQ_DDMAST.nextval,'0000','" & v_strCUSTID & "','" & v_strACCTNO & "','" & v_strCUSTODYCD & "' ,to_char(LPAD (SEQ_DDMAST.NEXTVAL, 18, to_char(getcurrdate,'ddmmyyyy')||'0001') ),'" & v_strCCYCD & "','" & v_strREFCASAACCT & "',0,0,0,0,0,0,0,0,0,'A','A',getcurrdate,'" & v_strACCOUNTTYPE & "','" & v_strISDEFAULT & "',null,null,null,null)"
            'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            ''insert vào bảng FAACCTBANK
            'Dim v_strSQLxml As String = "insert into FAACCTBANK (AUTOID, CUSTID, CUSTODYCD, CCYCD, MAPACCTNO, BANKACCTNO)" & ControlChars.CrLf _
            '                        & "VALUES(SEQ_FAACCTBANK.nextval,'" & v_strCUSTID & "','" & v_strCUSTODYCD & "','" & v_strCCYCD & "','" & v_strACCTNO & "','" & v_strREFCASAACCT & "')"
            'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQLxml)
            v_strSQL = "INSERT INTO " & ATTR_TABLE
            Dim v_strListOfFields As String = vbNullString
            Dim v_strListOfValues As String = vbNullString
            Dim v_strSignature As String = String.Empty
            Dim result As Long
            'Dim v_strCustID As String = String.Empty


            Dim v_decID As Decimal
            If (v_strAutoId = gc_AutoIdUsed) Then
                v_decID = v_obj.GetIDValue(ATTR_TABLE)
            End If

            'C?p nh?t vào CSDL
            Dim j As Integer
            Dim v_strNewValue As String, v_strOldValue As String, v_strFLDTYPE As String

            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            For j = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(j)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strFLDTYPE = CStr(CType(.Attributes.GetNamedItem("fldtype"), Xml.XmlAttribute).Value)

                    If v_strFLDNAME = "AUTOID" Then
                        v_strNewValue = v_decID
                        Me.autoidDdmast = v_decID
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

                End With
            Next

            If Len(v_strListOfFields) <> 0 Then
                v_strListOfFields = v_strListOfFields & ")"
                v_strListOfValues = v_strListOfValues & ")"
                v_strSQL = v_strSQL & " " & v_strListOfFields & " VALUES " & v_strListOfValues
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End If
            result = Me.MaintainLog(pv_xmlDocument, gc_ActionAdd)
            If Not (result = ERR_APPROVE_REQUIRED Or result = ERR_SYSTEM_OK) Then
                Return result
            End If

            'v_strSQL = "UPDATE cfmast SET STATUS='P' WHERE CUSTID='" & v_strCUSTID & "' AND STATUS='A'"
            'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If
            v_strSQL = "UPDATE ddmast SET STATUS = 'A', acctno = to_char(getcurrdate,'ddmmyyyy') || to_char(LPAD (SEQ_DDMAST_ACCTNO.NEXTVAL, 6,'0'  )) WHERE CUSTID='" & v_strCUSTID & "' AND REFCASAACCT='" & v_strREFCASAACCT & "' AND CUSTODYCD='" & v_strCUSTODYCD & "' and acctno is null"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            Return 0
        Catch ex As Exception
            ''ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
        'Return 0
    End Function

    Overrides Function CheckBeforeEdit(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_strCmdSQL, v_strObjMsg, v_strFLDNAME, v_strCCYCD, v_strAUTOID, v_strACCOUNTTYPE, v_strREFCASAACCT, v_strISDEFAULT, v_strVALUE, v_strRESULT, v_strPAYMENTFEE As String
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_ds As DataSet
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strACCTNO, v_strCUSTID, v_strAUTOADV As String
            Dim v_strSQL As String
            Dim v_strBRID, v_strTXDATE, v_strTLID, v_strClause As String

            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strTLID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Else
                v_strTLID = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeTXDATE) Is Nothing) Then
                v_strTXDATE = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXDATE), Xml.XmlAttribute).Value)
            Else
                v_strTXDATE = String.Empty
            End If
            If Not (v_attrColl.GetNamedItem(gc_AtributeCLAUSE) Is Nothing) Then
                v_strClause = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Else
                v_strClause = String.Empty
            End If

            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strVALUE = .InnerText.ToString()

                    Select Case Trim(v_strFLDNAME)
                        Case "AFACCTNO"
                            v_strACCTNO = Trim(v_strVALUE)
                        Case "CUSTID"
                            v_strCUSTID = Trim(v_strVALUE)
                        Case "REFCASAACCT"
                            v_strREFCASAACCT = Trim(v_strVALUE)
                        Case "ISDEFAULT"
                            v_strISDEFAULT = Trim(v_strVALUE)
                        Case "CCYCD"
                            v_strCCYCD = Trim(v_strVALUE)
                        Case "ACCOUNTTYPE"
                            v_strACCOUNTTYPE = Trim(v_strVALUE)
                        Case "PAYMENTFEE"
                            v_strPAYMENTFEE = Trim(v_strVALUE)
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
            v_strCmdSQL = "Select AUTOID from DDMAST where " & v_strClause
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strCmdSQL)
            v_strAUTOID = v_ds.Tables(0).Rows(0)("AUTOID").ToString

            'trung.luu: 09-09-2020
            'v_strCmdSQL = "Select COUNT(*)  from DDMAST where CUSTID = '" & v_strCUSTID & "' and ACCOUNTTYPE = '" & v_strACCOUNTTYPE & "' and CCYCD='" & v_strCCYCD & "'   and AUTOID <> '" & v_strAUTOID & "'  and STATUS <> 'C'"
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strCmdSQL)
            'If v_ds.Tables(0).Rows.Count > 0 Then
            '    If v_ds.Tables(0).Rows(0)(0) > 0 Then
            '        Return ERR_DD_ACCBANK_DUPLICATE
            '    End If
            'End If
            v_strCmdSQL = "Select COUNT(*)  from DDMAST where CUSTID = '" & v_strCUSTID & "' and REFCASAACCT='" & v_strREFCASAACCT & "'  and ACCOUNTTYPE='" & v_strACCOUNTTYPE & "' and CCYCD='" & v_strCCYCD & "' and AUTOID <> '" & v_strAUTOID & "' and STATUS <> 'C'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strCmdSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_DD_ACCBANK_DUPLICATE
                End If
            End If

            v_strCmdSQL = "Select COUNT(*)  from DDMAST where CUSTID = '" & v_strCUSTID & "' and REFCASAACCT='" & v_strREFCASAACCT & "' and AUTOID <> '" & v_strAUTOID & "' and STATUS <> 'C'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strCmdSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_DD_ACCBANK_DUPLICATE
                End If
            End If

            v_strCmdSQL = "Select COUNT(*)  from DDMAST where CUSTID <> '" & v_strCUSTID & "' and REFCASAACCT='" & v_strREFCASAACCT & "' and STATUS <> 'C'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strCmdSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_DD_ACCBANK_DUPLICATE
                End If
            End If

            If v_strCCYCD <> "VND" And v_strISDEFAULT = "Y" Then
                Return ERR_DD_DDTYPE_CCYCD_NOTFOUND
            End If

            If v_strISDEFAULT = "Y" Then
                v_strCmdSQL = "Select COUNT(*) from DDMAST where CUSTID = '" & v_strCUSTID & "' and AUTOID <> '" & v_strAUTOID & "' and ISDEFAULT = 'Y' and STATUS <> 'C'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strCmdSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    If v_ds.Tables(0).Rows(0)(0) > 0 Then
                        Return ERR_DD_ACCBANK_ISDEFAULT_DUPLICATE
                    End If
                End If

            End If

            If v_strPAYMENTFEE = "Y" Then
                v_strCmdSQL = "Select COUNT(*) from DDMAST where CUSTID = '" & v_strCUSTID & "' and AUTOID <> '" & v_strAUTOID & "' and PAYMENTFEE = 'Y' and STATUS <> 'C'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strCmdSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    If v_ds.Tables(0).Rows(0)(0) > 0 Then
                        Return -130015
                    End If
                End If
            End If

            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If

            Return 0
        Catch ex As Exception
            ''ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
        'Return 0
    End Function
    Overrides Function Edit(ByRef v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_lngErrCode As Long
        Try
            v_lngErrCode = CoreEdit(pv_xmlDocument)
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
    Private Function CoreEdit(ByRef pv_xmlDocument As XmlDocumentEx) As Long
        Dim v_strCmdSQL, v_strObjMsg, v_strFLDNAME, v_strREFCASAACCT, v_strISDEFAULT, v_strVALUE, v_strRESULT As String
        Dim v_strCUSTODYCD, v_strCCYCD, v_strBANACC, v_strACCOUNTTYPE, v_strACCOUNTTYLEOLD As String
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_ds As DataSet
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_lngErrorCode As Long

        v_lngErrorCode = CheckBeforeEdit(pv_xmlDocument.InnerXml)

        If v_lngErrorCode <> 0 Then
            Return v_lngErrorCode
            Exit Function
        End If
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strACCTNO, v_strCUSTID, v_strAUTOADV As String
            Dim v_strSQL, v_strClause As String
            Dim v_strBRID, v_strTXDATE, v_strTLID As String

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

            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strTLID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Else
                v_strTLID = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeTXDATE) Is Nothing) Then
                v_strTXDATE = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXDATE), Xml.XmlAttribute).Value)
            Else
                v_strTXDATE = String.Empty
            End If

            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strVALUE = .InnerText.ToString()

                    Select Case Trim(v_strFLDNAME)
                        Case "AFACCTNO"
                            v_strACCTNO = Trim(v_strVALUE)
                        Case "CUSTID"
                            v_strCUSTID = Trim(v_strVALUE)
                        Case "REFCASAACCT"
                            v_strREFCASAACCT = Trim(v_strVALUE)
                        Case "ISDEFAULT"
                            v_strISDEFAULT = Trim(v_strVALUE)
                        Case "CUSTODYCD"
                            v_strCUSTODYCD = Trim(v_strVALUE)
                        Case "CCYCD"
                            v_strCCYCD = Trim(v_strVALUE)
                        Case "ACCOUNTTYPE"
                            v_strACCOUNTTYPE = Trim(v_strVALUE)
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
            'If v_strCCYCD = "VND" Then
            '    v_strCmdSQL = "Select ACCOUNTTYPE from DDMAST where CUSTID = '" & v_strCUSTID & "' and status='A' "
            '    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strCmdSQL)
            '    v_strACCOUNTTYLEOLD = v_ds.Tables(0).Rows(0)("ACCOUNTTYPE").ToString
            '    If v_strACCOUNTTYLEOLD = v_strACCOUNTTYPE Or v_strBANACC = v_strREFCASAACCT Then
            '        Return ERR_DD_ACCBANK_DUPLICATE
            '        Exit Function
            '    End If
            'End If


            'Thay đổi tài khoản mặc định thì vào đây
            If v_strISDEFAULT = "Y" Then
                'kt tra tk thay doi co phai tk phu, neu la tk mac dinh thi cho qua
                v_strCmdSQL = "Select REFCASAACCT from DDMAST where CUSTID = '" & v_strCUSTID & "' and ISDEFAULT = 'N'  and status <> 'C'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strCmdSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    If v_ds.Tables(0).Rows(0)(0) > 0 Then
                        v_strCmdSQL = "Select REFCASAACCT from DDMAST where CUSTID = '" & v_strCUSTID & "' and ISDEFAULT = 'Y'  and status <> 'C'"
                        v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strCmdSQL)
                        If v_ds.Tables(0).Rows.Count > 0 Then
                            If v_ds.Tables(0).Rows(0)(0) > 0 Then
                                v_strBANACC = v_ds.Tables(0).Rows(0)("REFCASAACCT").ToString
                                'CHuyển tk mặc định thành tk phụ

                                If v_strBANACC <> v_strREFCASAACCT Then

                                    v_strSQL = "UPDATE ddmast SET ISDEFAULT='N' WHERE CUSTID='" & v_strCUSTID & "' AND REFCASAACCT='" & v_strBANACC & "' AND ISDEFAULT='Y'"
                                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                                    'update  tk phụ cần set thành tk mặc định
                                    v_strSQL = "UPDATE ddmast SET ISDEFAULT='Y' WHERE CUSTID='" & v_strCUSTID & "' AND REFCASAACCT='" & v_strREFCASAACCT & "' AND ISDEFAULT='N'"
                                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                                End If
                            End If
                        End If
                    End If
                End If
            End If

            'end
            'v_strSQL = "UPDATE ddmast SET STATUS='C' WHERE CUSTID='" & v_strCUSTID & "' AND REFCASAACCT='" & v_strREFCASAACCT & "' AND CUSTODYCD='" & v_strCUSTODYCD & "'"
            'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            'v_strSQL = "INSERT INTO ddmast (AUTOID,ACTYPE,CUSTID,AFACCTNO,CUSTODYCD,ACCTNO,CCYCD,REFCASAACCT,BALANCE,ACRAMT,ADRAMT,MCRAMT,MDRAMT,HOLDBALANCE,BLOCKAMT,RECEIVING,NETTING,STATUS,PSTATUS,OPNDATE,ACCOUNTTYPE,ISDEFAULT,CLSDATE,LAST_CHANGE,DEPOLASTDT,COREBANK)" & ControlChars.CrLf _
            '        & "VALUES(SEQ_DDMAST.nextval,'0000','" & v_strCUSTID & "','" & v_strACCTNO & "','" & v_strCUSTODYCD & "' ,to_char(LPAD (SEQ_DDMAST.NEXTVAL, 18, to_char(getcurrdate,'ddmmyyyy')||'0001') ),'" & v_strCCYCD & "','" & v_strREFCASAACCT & "',0,0,0,0,0,0,0,0,0,'A','A',getcurrdate,'" & v_strACCOUNTTYPE & "','" & v_strISDEFAULT & "',null,null,null,null)"
            'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            'v_strSQL = "DELETE FROM FAACCTBANK WHERE CUSTID='" & v_strCUSTID & "' AND BANKACCTNO='" & v_strREFCASAACCT & "' AND CUSTODYCD='" & v_strCUSTODYCD & "'"
            'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            ''insert lại vào bảng FAACCTBANK
            'Dim v_strSQLxml As String = "insert into FAACCTBANK (AUTOID, CUSTID, CUSTODYCD, CCYCD, MAPACCTNO, BANKACCTNO)" & ControlChars.CrLf _
            '                        & "VALUES(SEQ_FAACCTBANK.nextval,'" & v_strCUSTID & "','" & v_strCUSTODYCD & "','" & v_strCCYCD & "','" & v_strACCTNO & "','" & v_strREFCASAACCT & "')"
            'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQLxml)


            v_strSQL = "UPDATE " & ATTR_TABLE & " SET "
            Dim v_strUPD As String = vbNullString, v_strUPDTMP As String = vbNullString
            Dim result As Long
            Dim j As Integer
            Dim v_strNewValue As String, v_strOldValue As String, v_strFLDTYPE As String
            Dim v_strAutoID, v_strSignature As String
            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            For j = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(j)
                    v_strOldValue = CStr(CType(v_nodeList.Item(0).ChildNodes(j).Attributes.GetNamedItem("oldval"), Xml.XmlAttribute).Value)
                    v_strNewValue = .InnerText.ToString
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strFLDTYPE = CStr(CType(.Attributes.GetNamedItem("fldtype"), Xml.XmlAttribute).Value)

                    If v_strFLDNAME = "AUTOID" Then
                        v_strAutoID = v_strNewValue
                    End If
                    If Trim(v_strOldValue) <> Trim(v_strNewValue) Then
                        v_strFLDNAME = CStr(CType(v_nodeList.Item(0).ChildNodes(j).Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strFLDTYPE = CStr(CType(v_nodeList.Item(0).ChildNodes(j).Attributes.GetNamedItem("fldtype"), Xml.XmlAttribute).Value)

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
                        v_strFLDNAME = CStr(CType(v_nodeList.Item(0).ChildNodes(j).Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strFLDTYPE = CStr(CType(v_nodeList.Item(0).ChildNodes(j).Attributes.GetNamedItem("fldtype"), Xml.XmlAttribute).Value)
                    End If

                End With
            Next

            If Len(v_strUPD) <> 0 Then
                v_strSQL = v_strSQL & v_strUPD & " WHERE 0=0 AND " & v_strClause
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End If
            result = Me.MaintainLog(pv_xmlDocument, gc_ActionAdd)
            If Not (result = ERR_APPROVE_REQUIRED Or result = ERR_SYSTEM_OK) Then
                Return result
            End If
            v_strSQL = "UPDATE ddmast SET STATUS='A' WHERE CUSTID='" & v_strCUSTID & "' and REFCASAACCT='" & v_strREFCASAACCT & "' and ISDEFAULT='" & v_strISDEFAULT & "' and status is null"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            v_strSQL = "UPDATE cfmast SET STATUS='P' WHERE CUSTID='" & v_strCUSTID & "' AND STATUS='A'"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If

            Return 0
        Catch ex As Exception
            ''ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
        'Return 0
    End Function
    Overridable Function Delete(ByRef v_strMessage As String) As Long
        Dim v_lngErrCode As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Try
            v_lngErrCode = CoreDelete(pv_xmlDocument)
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

    Private Function CoreDelete(ByRef pv_xmlDocument As XmlDocumentEx) As Long
        Dim v_lngErrorCode As Long
        Dim v_strSYSVAR As String, v_DataAccess As New DataAccess
        Dim v_strCmdSQL, v_strObjMsg, v_strFLDNAME, v_strREFCASAACCT As String
        Dim v_strCUSTODYCD, v_strVALUE, v_strCUSTID As String
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_ds As DataSet
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
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
        Dim v_obj As DataAccess
        If v_strLocal = "Y" Then
            v_obj = New DataAccess
        ElseIf v_strLocal = "N" Then
            v_obj = New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
        End If
        'v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
        'For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
        '    With v_nodeList.Item(0).ChildNodes(i)
        '        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
        '        v_strVALUE = .InnerText.ToString()

        '        Select Case Trim(v_strFLDNAME)
        '            Case "CUSTID"
        '                v_strCUSTID = Trim(v_strVALUE)
        '            Case "REFCASAACCT"
        '                v_strREFCASAACCT = Trim(v_strVALUE)
        '            Case "CUSTODYCD"
        '                v_strCUSTODYCD = Trim(v_strVALUE)
        '        End Select
        '    End With
        'Next

        'Dim v_strSQL As String = "UPDATE " & ATTR_TABLE & " SET STATUS='C' WHERE 0=0 AND " & v_strClause
        'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

        Dim v_strSQL As String = "SELECT COUNT(1) FROM " & ATTR_TABLE & " WHERE (status = 'A' or INSTR(PSTATUS,'A') > 0) AND " & v_strClause
        v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
        If CInt(v_ds.Tables(0).Rows(0)(0).ToString) > 0 Then
            Return ERR_DD_DELETE_APPROVED_ACCOUNT
        End If

        'v_strSQL = "DELETE FROM FAACCTBANK WHERE CUSTID='" & v_strCUSTID & "' AND BANKACCTNO='" & v_strREFCASAACCT & "' AND CUSTODYCD='" & v_strCUSTODYCD & "'"
        'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
        Complete()

        Dim result As Long
        result = Me.MaintainLog(pv_xmlDocument, gc_ActionDelete)
        If Not (result = ERR_APPROVE_REQUIRED Or result = ERR_SYSTEM_OK) Then
            Return result
        End If

        Return ERR_SYSTEM_OK
    End Function
    'thunt-end
End Class
