Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data

Public Class OTRIGHT
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "OTRIGHT"
    End Sub

    'Overrides Function Add(ByRef v_strMessage As String) As Long
    '    Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
    '    Dim v_lngErrCode As Long

    '    Try
    '        v_lngErrCode = CoreAdd(pv_xmlDocument)
    '        If v_lngErrCode <> 0 Then
    '            Dim v_strErrorSource, v_strErrorMessage As String
    '            v_strErrorSource = "OTRIGHT.Add"
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
    '                     & "Error message: " & ex.Message, "EventLogEntryType.Error")
    '        Throw ex
    '    End Try
    'End Function

    Overrides Function Adhoc(ByRef v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strFuncName As String
        Dim v_strObjMsg As String

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            v_strFuncName = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeFUNCNAME), Xml.XmlAttribute).Value)

            v_strObjMsg = pv_xmlDocument.InnerXml
            Select Case Trim(v_strFuncName)
                Case "OTRIGHT_Addnew"
                    v_lngErrCode = OTRIGHT_Addnew(pv_xmlDocument)
                Case "OTRIGHT_Edit"
                    v_lngErrCode = OTRIGHT_Edit(pv_xmlDocument)
                Case "OTRIGHT_Delete"
                    v_lngErrCode = OTRIGHT_Delete(pv_xmlDocument)
            End Select
            pv_xmlDocument.LoadXml(v_strObjMsg)
            v_strMessage = pv_xmlDocument.InnerXml
            'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    'Overrides Function Edit(ByRef v_strMessage As String) As Long
    '    Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
    '    Dim v_lngErrCode As Long
    '    Try
    '        v_lngErrCode = CoreEdit(pv_xmlDocument)
    '        If v_lngErrCode <> 0 Then
    '            Dim v_strErrorSource, v_strErrorMessage As String

    '            v_strErrorSource = "OTRIGHT.Edit"
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
    '                     & "Error message: " & ex.Message, "EventLogEntryType.Error")
    '        Throw ex
    '    End Try
    'End Function

#Region " Overrides functions "
    'Overrides Function CheckBeforeAdd(ByVal v_strMessage As String) As Long
    '    Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

    '    ' Return 0
    '    Dim v_strObjMsg As String
    '    Dim v_ds As DataSet
    '    Dim v_nodeList As Xml.XmlNodeList
    '    Try
    '        Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
    '        Dim v_strLocal, v_strCUSTID As String
    '        Dim v_strFLDNAME, v_strVALUE As String
    '        Dim v_strVALDATE, v_strEXPDATE, v_strAFACCTNO, v_strAUTHAFACCTNO As String
    '        Dim v_strSQL As String
    '        If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
    '            v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
    '        Else
    '            v_strLocal = String.Empty
    '        End If
    '        v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
    '        For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
    '            With v_nodeList.Item(0).ChildNodes(i)
    '                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
    '                v_strVALUE = .InnerText.ToString()

    '                Select Case Trim(v_strFLDNAME)
    '                    Case "CUSTID"
    '                        v_strCUSTID = Trim(v_strVALUE)
    '                    Case "VALDATE"
    '                        v_strVALDATE = Trim(v_strVALUE)
    '                    Case "EXPDATE"
    '                        v_strEXPDATE = Trim(v_strVALUE)
    '                End Select
    '            End With
    '        Next

    '        Dim v_obj As DataAccess
    '        If v_strLocal = "Y" Then
    '            v_obj = New DataAccess
    '        ElseIf v_strLocal = "N" Then
    '            v_obj = New DataAccess
    '            v_obj.NewDBInstance(gc_MODULE_HOST)
    '        End If

    '        'Val Date<= exp date
    '        'Exp Date> Ngay lam viec cua he thong 
    '        v_strSQL = "SELECT VARVALUE  FROM SYSVAR WHERE VARNAME = 'CURRDATE'"
    '        v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
    '        'If DDMMYYYY_SystemDate(v_ds.Tables(0).Rows(0)("VARVALUE")) > DDMMYYYY_SystemDate(v_strVALDATE) Then
    '        '    Return ERR_CF_CURRDATE_SMALLER_THAN_VALDATE
    '        'End If
    '        If DDMMYYYY_SystemDate(v_ds.Tables(0).Rows(0)("VARVALUE")) > DDMMYYYY_SystemDate(v_strEXPDATE) Then
    '            Return ERR_CF_CURRDATE_SMALLER_THAN_EXPDATE
    '        End If
    '        If DDMMYYYY_SystemDate(v_strVALDATE) > DDMMYYYY_SystemDate(v_strEXPDATE) Then
    '            Return ERR_CF_CURRDATE_SMALLER_THAN_VALDATE
    '        End If
    '        'Kiem tra CUSTID phai ton tai
    '        If v_strCUSTID <> "" Then
    '            v_strSQL = "SELECT COUNT(CUSTID) FROM CFMAST WHERE  CUSTID  = '" & Replace(v_strCUSTID, ".", "") & "'"
    '            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
    '            If v_ds.Tables(0).Rows.Count = 1 Then
    '                If v_ds.Tables(0).Rows(0)(0) = 0 Then
    '                    Return ERR_CF_OTRIGHT_CUSTID_NOTFOUND
    '                End If
    '            End If
    '        End If

    '        If Not (v_ds Is Nothing) Then
    '            v_ds.Dispose()
    '        End If
    '        'ContextUtil.SetComplete()
    '        Return 0
    '    Catch ex As Exception
    '        'ContextUtil.SetAbort()
    '        LogError.Write("Error source: " & ex.Source & vbNewLine _
    '                     & "Error code: System error!" & vbNewLine _
    '                     & "Error message: " & ex.Message, "EventLogEntryType.Error")
    '        Throw ex
    '    End Try

    '    'Return 0
    'End Function

    'Overrides Function CheckBeforeEdit(ByVal v_strMessage As String) As Long
    '    Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

    '    Dim v_strObjMsg As String
    '    Dim v_ds As DataSet
    '    Dim v_nodeList As Xml.XmlNodeList
    '    Dim v_strAcctno As String
    '    Try
    '        Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
    '        Dim v_strLocal, v_strCUSTID As String
    '        Dim v_strFLDNAME, v_strFLDTYPE, v_strVALDATE, v_strEXPDATE, v_strVALUE As String
    '        Dim v_strSQL As String
    '        If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
    '            v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
    '        Else
    '            v_strLocal = String.Empty
    '        End If
    '        v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
    '        For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
    '            With v_nodeList.Item(0).ChildNodes(i)
    '                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
    '                v_strVALUE = .InnerText.ToString()

    '                Select Case Trim(v_strFLDNAME)
    '                    Case "CUSTID"
    '                        v_strCUSTID = Trim(v_strVALUE)
    '                    Case "VALDATE"
    '                        v_strVALDATE = Trim(v_strVALUE)
    '                    Case "EXPDATE"
    '                        v_strEXPDATE = Trim(v_strVALUE)
    '                    Case "ACCTNO"
    '                        v_strAcctno = Trim(v_strVALUE)

    '                End Select
    '            End With
    '        Next

    '        Dim v_obj As DataAccess
    '        If v_strLocal = "Y" Then
    '            v_obj = New DataAccess
    '        ElseIf v_strLocal = "N" Then
    '            v_obj = New DataAccess
    '            v_obj.NewDBInstance(gc_MODULE_HOST)
    '        End If
    '        'Val Date>=Ngay lam viec cua he thong.
    '        'Exp Date> Ngay lam viec cua he thong 
    '        v_strSQL = "SELECT VARVALUE  FROM SYSVAR WHERE VARNAME = 'CURRDATE'"
    '        v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
    '        'If DDMMYYYY_SystemDate(v_ds.Tables(0).Rows(0)("VARVALUE")) > DDMMYYYY_SystemDate(v_strVALDATE) Then
    '        '    Return ERR_CF_CURRDATE_SMALLER_THAN_VALDATE
    '        'End If
    '        If DDMMYYYY_SystemDate(v_ds.Tables(0).Rows(0)("VARVALUE")) > DDMMYYYY_SystemDate(v_strEXPDATE) Then
    '            Return ERR_CF_CURRDATE_SMALLER_THAN_EXPDATE
    '        End If
    '        If DDMMYYYY_SystemDate(v_strVALDATE) > DDMMYYYY_SystemDate(v_strEXPDATE) Then
    '            Return ERR_CF_CURRDATE_SMALLER_THAN_VALDATE ' su dung lai ma loi, thuc ra la check valdate va expdate
    '        End If
    '        'Ki?m tra CUSTID phai ton tai
    '        If v_strCUSTID <> "" Then
    '            v_strSQL = "SELECT COUNT(CUSTID) FROM CFMAST WHERE  CUSTID  = '" & v_strCUSTID & "'"
    '            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
    '            If v_ds.Tables(0).Rows.Count = 1 Then
    '                If v_ds.Tables(0).Rows(0)(0) = 0 Then
    '                    Return ERR_CF_OTRIGHT_CUSTID_NOTFOUND
    '                End If
    '            End If
    '        End If

    '        If Not (v_ds Is Nothing) Then
    '            v_ds.Dispose()
    '        End If
    '        'ContextUtil.SetComplete()
    '        Return 0
    '    Catch ex As Exception
    '        'ContextUtil.SetAbort()
    '        LogError.Write("Error source: " & ex.Source & vbNewLine _
    '                     & "Error code: System error!" & vbNewLine _
    '                     & "Error message: " & ex.Message, "EventLogEntryType.Error")
    '        Throw ex
    '    End Try
    'End Function

#End Region

#Region " Special Function "
    Private Function OTRIGHT_Addnew(ByRef pv_xmlDocument As XmlDocumentEx) As Long
        Try
            Dim v_lngErrorCode As Long = ERR_SYSTEM_OK
            Dim v_lngErrCode As Long = ERR_SYSTEM_OK

            Dim v_strErrorSource As String = "CF.OTRIGHT.OTRIGHT_Addnew", v_strErrorMessage As String

            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strClause As String
            Dim v_strLocal As String
            Dim v_strAutoId As String
            Dim l_datasourcesql As String
            Dim V_stremail As String
            Dim V_Via, v_strSerialNumSig As String
            Dim V_strusername, v_strFullname, V_mobilesms, v_strcustodycd As String
            Dim v_strPass, v_strPass2, v_strtypetrade, v_strtypetradeSMS, v_serial As String

            If Not (v_attrColl.GetNamedItem(gc_AtributeREFERENCE) Is Nothing) Then
                v_strClause = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)
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
            Dim v_strSQL, v_strSQLMEMO, v_strSQLTEMP As String
            Dim v_ds As DataSet

            'Get data to insert to DB
            Dim v_arrInfo(), v_arrGeneralInfo(), v_arrRightInfo() As String
            If v_strClause.Length > 0 Then
                v_arrInfo = v_strClause.Split("#")
                If v_arrInfo.Length > 0 Then
                    v_arrGeneralInfo = v_arrInfo(0).Split("|")
                    v_arrRightInfo = v_arrInfo(1).Split("$")
                End If
            End If
            Dim v_strCUSTID, v_strAUTHCUSTID, v_strAUTHTYPE, v_strVALDATE, v_strEXPDATE, v_strSERIALTOKEN As String
            If v_arrGeneralInfo.Length > 0 Then
                v_strCUSTID = v_arrGeneralInfo(0)
                v_strAUTHCUSTID = v_arrGeneralInfo(1)
                v_strAUTHTYPE = v_arrGeneralInfo(2)
                v_strVALDATE = v_arrGeneralInfo(3)
                v_strEXPDATE = v_arrGeneralInfo(4)
                v_strSERIALTOKEN = v_arrGeneralInfo(5)
                v_strcustodycd = v_arrGeneralInfo(6)
                V_stremail = v_arrGeneralInfo(7)
                V_mobilesms = v_arrGeneralInfo(8)
                v_strFullname = v_arrGeneralInfo(9)
                V_Via = v_arrGeneralInfo(11) '2.1.3.0|iss 1594

            End If

            If v_strAUTHTYPE = 1 Then
                v_strtypetrade = "Mật khẩu đặt lệnh của quý khách là:"
                v_strtypetradeSMS = "MK dat lenh:"
            ElseIf v_strAUTHTYPE = 2 Then
                v_strtypetrade = "Qúy khách sử dụng phương thức đặt lệnh bằng token:"
                v_strtypetradeSMS = "Serial Token:"
            ElseIf v_strAUTHTYPE = 3 Then
                v_strtypetrade = "Qúy khách sử dụng phương thức đặt lệnh bằng thẻ matrix:"
                v_strtypetradeSMS = "Serial Matrix:"
                'begin 2.1.3.0|1597
            ElseIf v_strAUTHTYPE = 4 Then
                v_strtypetrade = "Qúy khách sử dụng phương thức đặt lệnh bằng chứng thư số:"
                v_strtypetradeSMS = "Serial CTS:"
                v_strSerialNumSig = v_strSERIALTOKEN
            ElseIf v_strAUTHTYPE = 5 Then
                v_strtypetrade = "Qúy khách sử dụng phương thức đặt lệnh xác nhận OTP (SMS):"
                v_strtypetradeSMS = "PassWord OTP:"
            End If

            'Check before add

            'Voi moi loai kenh Khong cho khai bao nhieu hon 1 hinh thuc xac thuc
            v_strSQLTEMP = "SELECT * FROM OTRIGHT WHERE CFCUSTID = '" & v_strCUSTID & "' AND AUTHCUSTID = '" & v_strAUTHCUSTID & "' AND DELTD = 'N' and via='" & V_Via & "'" '2.1.3.0|iss 1594
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQLTEMP)
            If v_ds.Tables(0).Rows.Count > 0 Then
                Return ERR_CF_OTRIGHT_DUPLICATE
            End If
            'Yeu cau dang ky cho loai xac thuc voi kenh all truoc neu chua ton tai 
            v_strSQLTEMP = "SELECT * FROM OTRIGHT WHERE CFCUSTID = '" & v_strCUSTID & "' AND AUTHCUSTID = '" & v_strAUTHCUSTID & "' AND DELTD = 'N' and via='A'" '2.1.3.0|iss 1594
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQLTEMP)
            If v_ds.Tables(0).Rows.Count = 0 And V_Via <> "A" Then
                Return ERR_CF_OTRIGHT_ALL
            End If

            'Chi dang ky kenh ALL ca ONL
            If V_Via <> "A" And v_strAUTHTYPE = "1" Then
                Return ERR_CF_OTRIGHT_VIA_NOT_OTHER
            End If
            'Yeu cau dang ky xac thuc chi cho ONline
            If (V_Via <> "O" And V_Via <> "H" And V_Via <> "M") And (v_strAUTHTYPE = 4 Or v_strAUTHTYPE = 5) Then
                Return ERR_CF_OTRIGHT_ALL_NOT_NumSig
            End If
            'Yeu cau dang ky xac thuc chi cho ONline
            If (V_Via = "O" Or V_Via = "H" Or V_Via = "M") And v_strAUTHTYPE <> 4 And v_strAUTHTYPE <> 5 Then
                Return ERR_CF_OTRIGHT_ONL_AUTHTYPE
            End If

            'end 2.1.3.0|1597
            Dim v_arrTABLE(4) As String
            v_arrTABLE(0) = "OTRIGHT"
            v_arrTABLE(1) = "OTRIGHTDTL"
            v_arrTABLE(2) = "USERLOGIN"
            v_arrTABLE(3) = "EMAILLOG"
            v_arrTABLE(4) = "CFMAST"


            v_lngErrorCode = VerifyMemoTable(v_arrTABLE)
            If v_lngErrorCode <> ERR_SYSTEM_OK Then
                Rollback()
                Return v_lngErrorCode
            End If

            'Insert infor to OTRIGHT
            v_strSQL = "BEGIN "
            v_strSQLMEMO = "BEGIN "


            'Insert infor to OTRIGHT
            v_strSQL = v_strSQL & " INSERT INTO OTRIGHT (AUTOID, CFCUSTID, AUTHCUSTID, AUTHTYPE, VALDATE, EXPDATE, DELTD, LASTCHANGE, SERIALTOKEN,VIA, SERIALNUMSIG) " & ControlChars.CrLf _
                    & "SELECT SEQ_OTRIGHT.NEXTVAL, '" & v_strCUSTID & "', '" & v_strAUTHCUSTID & "', " & ControlChars.CrLf _
                & "     '" & v_strAUTHTYPE & "', TO_DATE('" & v_strVALDATE & "','DD/MM/YYYY'), TO_DATE('" & v_strEXPDATE & "','DD/MM/YYYY'), 'N', getcurrdate, '" & v_strSERIALTOKEN & "', '" & V_Via & "', '" & v_strSerialNumSig & "' FROM DUAL;"
            'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            v_strSQLMEMO = v_strSQLMEMO & " INSERT INTO OTRIGHTMEMO (AUTOID, CFCUSTID, AUTHCUSTID, AUTHTYPE, VALDATE, EXPDATE, DELTD, LASTCHANGE, SERIALTOKEN,VIA, SERIALNUMSIG) " & ControlChars.CrLf _
                    & "SELECT SEQ_OTRIGHT.NEXTVAL, '" & v_strCUSTID & "', '" & v_strAUTHCUSTID & "', " & ControlChars.CrLf _
                & "     '" & v_strAUTHTYPE & "', TO_DATE('" & v_strVALDATE & "','DD/MM/YYYY'), TO_DATE('" & v_strEXPDATE & "','DD/MM/YYYY'), 'N', getcurrdate, '" & v_strSERIALTOKEN & "', '" & V_Via & "', '" & v_strSerialNumSig & "' FROM DUAL;"

            'Insert rights detail
            Dim v_arrRightDetail() As String
            For i As Integer = 0 To v_arrRightInfo.Length - 2
                v_arrRightDetail = v_arrRightInfo(i).Split("|")
                'Insert
                v_strSQL = v_strSQL & " INSERT INTO OTRIGHTDTL (AUTOID, CFCUSTID, AUTHCUSTID, OTMNCODE, OTRIGHT, DELTD, VIA) " & ControlChars.CrLf _
                        & "VALUES (SEQ_OTRIGHTDTL.NEXTVAL, '" & v_strCUSTID & "', '" & v_strAUTHCUSTID & "', " & ControlChars.CrLf _
                        & "'" & v_arrRightDetail(0) & "', '" & v_arrRightDetail(1) & "', 'N', '" & V_Via & "');"

                v_strSQLMEMO = v_strSQLMEMO & " INSERT INTO OTRIGHTDTLMEMO (AUTOID, CFCUSTID, AUTHCUSTID, OTMNCODE, OTRIGHT, DELTD, VIA) " & ControlChars.CrLf _
                                        & "VALUES (SEQ_OTRIGHTDTL.NEXTVAL, '" & v_strCUSTID & "', '" & v_strAUTHCUSTID & "', " & ControlChars.CrLf _
                                        & "'" & v_arrRightDetail(0) & "', '" & v_arrRightDetail(1) & "', 'N', '" & V_Via & "');"
                'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            Next

            v_strSQL = v_strSQL & " END;"
            v_strSQLMEMO = v_strSQLMEMO & " END;"

            v_lngErrorCode = RunApprExecSql(pv_xmlDocument, gc_ActionAdd, v_strSQL, CommandType.Text, v_strSQLMEMO)

            v_strSQL = "BEGIN "
            v_strSQLMEMO = "BEGIN "

            v_strSQLTEMP = "select substr(sys_guid(),0,10) pass from dual  "
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQLTEMP)
            v_strPass = v_ds.Tables(0).Rows(0)("PASS")

            If v_strAUTHTYPE = 1 Then
                v_strSQLTEMP = "select substr(sys_guid(),0,10) pass from dual  "
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQLTEMP)
                v_strPass2 = v_ds.Tables(0).Rows(0)("PASS")
                v_serial = ""
            Else
                v_strPass2 = ""
                v_serial = v_strSERIALTOKEN
            End If

            v_strSQL = v_strSQL & " INSERT INTO USERLOGIN (USERNAME, LOGINPWD, AUTHTYPE, TRADINGPWD, STATUS, " & ControlChars.CrLf _
                        & "LASTLOGIN, LOGINSTATUS, LASTCHANGED, NUMBEROFDAY, ISMASTER, ISRESET, TOKENID) " & ControlChars.CrLf _
                        & "SELECT CUSTODYCD,GENENCRYPTPASSWORD('" & v_strPass & "'),'" & v_strAUTHTYPE & "',GENENCRYPTPASSWORD('" & v_strPass2 & "'), " & ControlChars.CrLf _
                        & "'A',SYSDATE,'O',SYSDATE,30,'N','Y','' FROM CFMAST where custid = '" & v_strCUSTID & "' and  NOT EXISTS (SELECT * FROM Userlogin WHERE username =custodycd AND status  = 'A');" '2.1.3.0|iss1594
            'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            v_strSQLMEMO = v_strSQLMEMO & " INSERT INTO USERLOGINMEMO (USERNAME, LOGINPWD, AUTHTYPE, TRADINGPWD, STATUS, " & ControlChars.CrLf _
                        & "LASTLOGIN, LOGINSTATUS, LASTCHANGED, NUMBEROFDAY, ISMASTER, ISRESET, TOKENID) " & ControlChars.CrLf _
                        & "SELECT CUSTODYCD,GENENCRYPTPASSWORD('" & v_strPass & "'),'" & v_strAUTHTYPE & "',GENENCRYPTPASSWORD('" & v_strPass2 & "'), " & ControlChars.CrLf _
                        & "'A',SYSDATE,'O',SYSDATE,30,'N','Y','' FROM CFMAST where custid = '" & v_strCUSTID & "' and  NOT EXISTS (SELECT * FROM USERLOGINMEMO WHERE username =custodycd AND status = 'A') ;" '2.1.3.0|iss1594


            v_strSQL = v_strSQL & " update CFMAST set username = custodycd, TRADEONLINE = 'Y' where custid = '" & v_strCUSTID & "' ;"
            v_strSQLMEMO = v_strSQLMEMO & " update CFMASTMEMO set username = custodycd, TRADEONLINE = 'Y' where custid = '" & v_strCUSTID & "' ;"
            'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)



            l_datasourcesql = "select ''" & v_strcustodycd & "'' username, ''" & v_strPass & "'' loginpwd ,''" & v_strPass2 & "'' tradingpwd, ''" & v_strFullname & "'' fullname,''" & v_strtypetrade & "'' typetrade, ''" & v_strtypetradeSMS & "'' typetradesms, ''" & v_serial & "'' numberserial, ''" & v_strcustodycd & "'' custodycode from dual"

            'v_strSQL = v_strSQL & " INSERT INTO emaillog (autoid, email, templateid, datasource, status,afacctno ,createtime)" & ControlChars.CrLf _
            '           & "VALUES(seq_emaillog.nextval,'" & V_stremail & "','0212','" & l_datasourcesql & "','P','" & v_strcustodycd & "',SYSDATE);"

            'v_strSQLMEMO = v_strSQLMEMO & " INSERT INTO emaillogmemo (autoid, email, templateid, datasource, status,afacctno ,createtime)" & ControlChars.CrLf _
            '           & "VALUES(seq_emaillog.nextval,'" & V_stremail & "','0212','" & l_datasourcesql & "','A','" & v_strcustodycd & "',SYSDATE);"
            ''v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            'v_strSQL = v_strSQL & " INSERT INTO emaillog (autoid, email, templateid, datasource, status,afacctno ,createtime)" & ControlChars.CrLf _
            '           & "VALUES(seq_emaillog.nextval,'" & V_mobilesms & "','0303','" & l_datasourcesql & "','P','" & v_strcustodycd & "',SYSDATE);"

            'v_strSQLMEMO = v_strSQLMEMO & " INSERT INTO emaillogmemo (autoid, email, templateid, datasource, status,afacctno ,createtime)" & ControlChars.CrLf _
            '           & "VALUES(seq_emaillog.nextval,'" & V_mobilesms & "','0303','" & l_datasourcesql & "','A','" & v_strcustodycd & "',SYSDATE);"
            'Insert rights detail

            v_strSQL = v_strSQL & " END;"
            v_strSQLMEMO = v_strSQLMEMO & " END;"
            Dim v_strObjMsg As String

            'v_strObjMsg = CallIDService("DELETEUSER", v_strcustodycd, v_strSERIALTOKEN, v_lngErrCode, v_strErrorMessage, 1)
            'v_strObjMsg = CallIDService("DELETEUSER", v_strcustodycd, v_strSERIALTOKEN, v_lngErrCode, v_strErrorMessage, 2)

            If v_strAUTHTYPE = gc_TokenType Then
                '3.Create User
                v_strObjMsg = CallIDService("CREATEUSER", v_strcustodycd, v_strSERIALTOKEN, v_lngErrCode, v_strErrorMessage, 1)
                'Assign Token
                v_strObjMsg = CallIDService("ADDTOKEN", v_strcustodycd, v_strSERIALTOKEN, v_lngErrCode, v_strErrorMessage)

            ElseIf v_strAUTHTYPE = gc_MatrixType Then
                '3.Create User
                v_strObjMsg = CallIDService("CREATEUSER", v_strcustodycd, v_strSERIALTOKEN, v_lngErrCode, v_strErrorMessage, 2)
                'Assign Matrix
                v_strObjMsg = CallIDService("ADDMATRIX", v_strcustodycd, v_strSERIALTOKEN, v_lngErrCode, v_strErrorMessage)
            End If

            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return -180066
                Exit Function
            End If

            v_lngErrorCode = RunApprExecSql(pv_xmlDocument, gc_ActionAdd, v_strSQL, CommandType.Text, v_strSQLMEMO)
            If v_lngErrorCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrorCode
                Exit Function
            End If


            'AnhVT Added - Maintenance Approval Retro        
            Dim result As Long
            result = Me.MaintainLog(pv_xmlDocument, gc_ActionAdd)
            If Not (result = ERR_APPROVE_REQUIRED Or result = ERR_SYSTEM_OK) Then
                Return result
            End If

            Return v_lngErrorCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function CallIDService(ByVal pv_strFunctionName As String,
                                   ByVal pv_strCustomerID As String,
                                   ByVal pv_strSerialNumber As String,
                                   ByRef out_lngErrorCode As Long,
                                   ByRef out_strErrorMessage As String,
                                   Optional ByVal pv_intFlag As Integer = 1
                                   ) As String
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Try
            Dim v_strObjMsg, v_strErrorCode As String
            Dim objEntryFunction = New ObjectMessageObjDataEntry
            Dim objEntryModule = New ObjectMessageObjDataEntry
            Dim objEntryCustID = New ObjectMessageObjDataEntry
            Dim objErrorCode = New ObjectMessageObjDataEntry
            Dim objErrorMessage = New ObjectMessageObjDataEntry
            Dim objEntryTokenSerial = New ObjectMessageObjDataEntry
            Dim objEntryAuthType = New ObjectMessageObjDataEntry
            Dim objEntryGroupUser = New ObjectMessageObjDataEntry
            Dim objEntries As ObjectMessageObjDataEntry()
            If pv_strFunctionName = "CREATEUSER" Or pv_strFunctionName = "DELETEUSER" Then
                objEntryGroupUser.fldname = "AUTHGROUP"
                objEntryGroupUser.fldtype = "P"
                If pv_intFlag = 1 Then ' Token 
                    objEntryGroupUser.Value = AUTH_GROUP_TOKEN
                Else
                    objEntryGroupUser.Value = AUTH_GROUP_MATRIX
                End If

                objEntries = New ObjectMessageObjDataEntry() {objEntryFunction,
                                                             objEntryModule,
                                                             objEntryCustID,
                                                             objErrorCode,
                                                             objErrorMessage,
                                                             objEntryGroupUser,
                                                             objEntryTokenSerial}
            Else
                objEntries = New ObjectMessageObjDataEntry() {objEntryFunction,
                                                             objEntryModule,
                                                             objEntryCustID,
                                                             objEntryTokenSerial,
                                                             objEntryAuthType,
                                                             objErrorCode,
                                                             objErrorMessage}
            End If

            Dim obj As ObjectMessage = New ObjectMessage()
            Dim v_xmlDocument As New Xml.XmlDocument

            'MODULE
            objEntryModule.fldname = "MODULE"
            objEntryModule.fldtype = "String"
            objEntryModule.Value = "ENTRUST"
            'FUNCTION
            objEntryFunction.fldname = "FUNCTION"
            objEntryFunction.fldtype = "String"
            objEntryFunction.Value = pv_strFunctionName
            'CUSTOMERID
            objEntryCustID.fldname = "customerId"
            objEntryCustID.fldtype = "P"
            objEntryCustID.Value = pv_strCustomerID
            'SERIALNUMBER
            objEntryTokenSerial.fldname = "serialNumer"
            objEntryTokenSerial.fldtype = "P"
            objEntryTokenSerial.Value = pv_strSerialNumber
            'ErrorCode
            objErrorCode.fldname = "p_err_code"
            objErrorCode.fldtype = "String"
            objErrorCode.Value = ERR_SYSTEM_OK
            'p_err_message
            objErrorMessage.fldname = "p_err_message"
            objErrorMessage.fldtype = "String"
            objErrorMessage.Value = String.Empty
            'AuthType
            If pv_strFunctionName = "UNLOCKUSER" Then
                objEntryAuthType.fldname = "authType"
                objEntryAuthType.fldtype = "P"

                If pv_intFlag = 1 Then ' Token 
                    objEntryTokenSerial.Value = AUTH_GROUP_TOKEN
                Else
                    objEntryTokenSerial.Value = AUTH_GROUP_MATRIX
                End If
            End If

            'Challenge
            'ObjMessage
            obj.OBJNAME = "BD.Router"
            obj.LOCAL = gc_IsNotLocalMsg
            obj.MSGTYPE = gc_MsgTypeObj
            obj.ACTIONFLAG = gc_ActionAdhoc
            obj.FUNCTIONNAME = "executeBOFunction"
            obj.ObjData = objEntries
            v_strObjMsg = SerializeObject(obj)

            v_xmlDocument.LoadXml(v_strObjMsg)
            Dim oAssembly As System.Reflection.Assembly = System.Reflection.Assembly.Load("BD")
            Dim aType As System.Type = oAssembly.GetType("BD.Router")
            Dim objrouter, retval As Object
            objrouter = Activator.CreateInstance(aType)
            Dim args() As Object = {v_xmlDocument.InnerXml}
            retval = aType.InvokeMember("Adhoc", Reflection.BindingFlags.InvokeMethod, Nothing, objrouter, args)
            out_lngErrorCode = CType(retval, Long)
            v_strObjMsg = CType(args(0), String)
            Return v_strObjMsg
        Catch ex As Exception
            'v_strErrorMessage = ex.Message
            Throw ex
            Return False
        End Try
    End Function


    Private Function OTRIGHT_Edit(ByRef pv_xmlDocument As XmlDocumentEx) As Long
        Try
            Dim v_lngErrorCode As Long = ERR_SYSTEM_OK

            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strClause As String
            Dim v_strLocal As String
            Dim v_strAutoId As String
            Dim v_strVia As String
            If Not (v_attrColl.GetNamedItem(gc_AtributeREFERENCE) Is Nothing) Then
                v_strClause = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)
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
            Dim v_strSQL, v_strSQLMEMO, v_strSQLTEMP As String
            Dim v_ds As DataSet

            'Get data to insert to DB
            Dim v_arrInfo(), v_arrGeneralInfo(), v_arrRightInfo() As String
            If v_strClause.Length > 0 Then
                v_arrInfo = v_strClause.Split("#")
                If v_arrInfo.Length > 0 Then
                    v_arrGeneralInfo = v_arrInfo(0).Split("|")
                    v_arrRightInfo = v_arrInfo(1).Split("$")
                End If
            End If
            Dim v_strCUSTID, v_strAUTHCUSTID, v_strAUTHTYPE, v_strVALDATE, v_strEXPDATE, v_strSERIALTOKEN As String
            If v_arrGeneralInfo.Length > 0 Then
                v_strCUSTID = v_arrGeneralInfo(0)
                v_strAUTHCUSTID = v_arrGeneralInfo(1)
                v_strAUTHTYPE = v_arrGeneralInfo(2)
                v_strVALDATE = v_arrGeneralInfo(3)
                v_strEXPDATE = v_arrGeneralInfo(4)
                v_strSERIALTOKEN = v_arrGeneralInfo(5)
                v_strVia = v_arrGeneralInfo(11)
            End If

            Dim v_arrTABLE(4) As String
            v_arrTABLE(0) = "OTRIGHT"
            v_arrTABLE(1) = "OTRIGHTDTL"
            v_arrTABLE(2) = "USERLOGIN"
            v_arrTABLE(3) = "EMAILLOG"
            v_arrTABLE(4) = "CFMAST"


            v_lngErrorCode = VerifyMemoTable(v_arrTABLE)
            If v_lngErrorCode <> ERR_SYSTEM_OK Then
                Rollback()
                Return v_lngErrorCode
            End If

            'Insert infor to OTRIGHT
            v_strSQL = "BEGIN "
            v_strSQLMEMO = "BEGIN "


            'Update infor to OTRIGHT
            v_strSQL = v_strSQL & " UPDATE OTRIGHT SET " & ControlChars.CrLf _
                    & "     AUTHTYPE = '" & v_strAUTHTYPE & "', " & ControlChars.CrLf _
                    & "     VALDATE = TO_DATE('" & v_strVALDATE & "','DD/MM/YYYY'), " & ControlChars.CrLf _
                    & "     EXPDATE = TO_DATE('" & v_strEXPDATE & "','DD/MM/YYYY')," & ControlChars.CrLf _
                    & "     LASTCHANGE = getcurrdate," & ControlChars.CrLf _
                    & "     SERIALTOKEN = '" & v_strSERIALTOKEN & "'" & ControlChars.CrLf _
                    & " WHERE CFCUSTID = '" & v_strCUSTID & "' AND AUTHCUSTID = '" & v_strAUTHCUSTID & "' AND DELTD = 'N' and  AUTHTYPE = '" & v_strAUTHTYPE & "' and via ='" & v_strVia & "'; " '2.1.3.0|iss 1594
            v_strSQLMEMO = v_strSQLMEMO & " UPDATE OTRIGHTMEMO SET " & ControlChars.CrLf _
                    & "     AUTHTYPE = '" & v_strAUTHTYPE & "', " & ControlChars.CrLf _
                    & "     VALDATE = TO_DATE('" & v_strVALDATE & "','DD/MM/YYYY'), " & ControlChars.CrLf _
                    & "     EXPDATE = TO_DATE('" & v_strEXPDATE & "','DD/MM/YYYY')," & ControlChars.CrLf _
                    & "     LASTCHANGE = getcurrdate," & ControlChars.CrLf _
                    & "     SERIALTOKEN = '" & v_strSERIALTOKEN & "'" & ControlChars.CrLf _
                    & " WHERE CFCUSTID = '" & v_strCUSTID & "' AND AUTHCUSTID = '" & v_strAUTHCUSTID & "' AND DELTD = 'N' and  AUTHTYPE = '" & v_strAUTHTYPE & "' and via ='" & v_strVia & "'; " '2.1.3.0|iss 1594


            'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            'Update UserLogin
            v_strSQL = v_strSQL & " UPDATE USERLOGIN SET " & ControlChars.CrLf _
            & "     TOKENID = '" & v_strSERIALTOKEN & "', AUTHTYPE ='1'  where USERNAME = (select custodycd from cfmast where custid ='" & v_strCUSTID & "') and STATUS = 'A'; " '30/08/2018 DieuNDA: Do bat buoc he thong phai co Autype = 1, do vay tam thoi mac dinh o day set autype = 1
            v_strSQLMEMO = v_strSQLMEMO & " UPDATE USERLOGINMEMO SET " & ControlChars.CrLf _
                                & "     TOKENID = '" & v_strSERIALTOKEN & "', AUTHTYPE ='" & v_strAUTHTYPE & "'  where USERNAME = (select custodycd from cfmast where custid ='" & v_strCUSTID & "') and STATUS = 'A'; "
            'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)


            'Update rights detail
            Dim v_arrRightDetail() As String
            Dim v_count As Integer
            For i As Integer = 0 To v_arrRightInfo.Length - 2
                v_arrRightDetail = v_arrRightInfo(i).Split("|")
                'Insert
                'Check neu co roi thi update, chua co thi them moi
                v_strSQLTEMP = "SELECT OTRIGHT FROM OTRIGHTDTL WHERE CFCUSTID = '" & v_strCUSTID & "' AND AUTHCUSTID = '" & v_strAUTHCUSTID & "' AND OTMNCODE = '" & v_arrRightDetail(0) & "' AND DELTD = 'N'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQLTEMP)


                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_strSQL = v_strSQL & " UPDATE OTRIGHTDTL SET " & ControlChars.CrLf _
                        & " OTRIGHT =  '" & v_arrRightDetail(1) & "' " & ControlChars.CrLf _
                        & " WHERE CFCUSTID = '" & v_strCUSTID & "' AND AUTHCUSTID = '" & v_strAUTHCUSTID & "' AND OTMNCODE = '" & v_arrRightDetail(0) & "' ;"
                    v_strSQLMEMO = v_strSQLMEMO & " UPDATE OTRIGHTDTLMEMO SET " & ControlChars.CrLf _
                                            & " OTRIGHT =  '" & v_arrRightDetail(1) & "' " & ControlChars.CrLf _
                                            & " WHERE CFCUSTID = '" & v_strCUSTID & "' AND AUTHCUSTID = '" & v_strAUTHCUSTID & "' AND OTMNCODE = '" & v_arrRightDetail(0) & "' AND VIA = '" & v_strVia & "';" '2.1.3.0|iss 1594
                    'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                Else
                    'Them moi
                    v_strSQL = v_strSQL & " INSERT INTO OTRIGHTDTL (AUTOID, CFCUSTID, AUTHCUSTID, OTMNCODE, OTRIGHT, DELTD) " & ControlChars.CrLf _
                        & "VALUES (SEQ_OTRIGHTDTL.NEXTVAL, '" & v_strCUSTID & "', '" & v_strAUTHCUSTID & "', " & ControlChars.CrLf _
                        & "'" & v_arrRightDetail(0) & "', '" & v_arrRightDetail(1) & "', 'N');"
                    v_strSQLMEMO = v_strSQLMEMO & " INSERT INTO OTRIGHTDTLMEMO (AUTOID, CFCUSTID, AUTHCUSTID, OTMNCODE, OTRIGHT, DELTD) " & ControlChars.CrLf _
                        & "VALUES (SEQ_OTRIGHTDTL.NEXTVAL, '" & v_strCUSTID & "', '" & v_strAUTHCUSTID & "', " & ControlChars.CrLf _
                        & "'" & v_arrRightDetail(0) & "', '" & v_arrRightDetail(1) & "', '" & v_arrRightDetail(1) & "', 'N','" & v_strVia & "');" '2.1.3.0|iss 1594
                    'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                End If
            Next

            v_strSQL = v_strSQL & " END;"
            v_strSQLMEMO = v_strSQLMEMO & " END;"

            v_lngErrorCode = RunApprExecSql(pv_xmlDocument, gc_ActionAdd, v_strSQL, CommandType.Text, v_strSQLMEMO)
            If v_lngErrorCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrorCode
                Exit Function
            End If


            Dim result As Long
            result = Me.MaintainLog(pv_xmlDocument, gc_ActionAdd)
            If Not (result = ERR_APPROVE_REQUIRED Or result = ERR_SYSTEM_OK) Then
                Return result
            End If

            Return v_lngErrorCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function OTRIGHT_Delete(ByRef pv_xmlDocument As XmlDocumentEx) As Long
        Try
            Dim v_lngErrorCode As Long = ERR_SYSTEM_OK

            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strClause As String
            Dim v_strLocal As String
            Dim v_strAutoId As String
            Dim v_strVia As String

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
            Dim v_strSQL, v_strSQLMEMO, v_strSQLTEMP As String

            'Get data to insert to DB
            Dim v_strCUSTID, v_strAUTHCUSTID As String
            Dim v_arrInfo() As String
            'If v_strClause.Length > 0 Then
            '    v_arrInfo = v_strClause.Split("|")
            '    If v_arrInfo.Length > 0 Then
            '        v_strCUSTID = v_arrInfo(0)
            '        v_strAUTHCUSTID = v_arrInfo(1)
            '    End If
            'End If


            Dim v_arrTABLE(4) As String
            v_arrTABLE(0) = "OTRIGHT"
            v_arrTABLE(1) = "OTRIGHTDTL"
            v_arrTABLE(2) = "USERLOGIN"
            v_arrTABLE(3) = "EMAILLOG"
            v_arrTABLE(4) = "CFMAST"


            v_lngErrorCode = VerifyMemoTable(v_arrTABLE)
            If v_lngErrorCode <> ERR_SYSTEM_OK Then
                Rollback()
                Return v_lngErrorCode
            End If

            'Insert infor to OTRIGHT
            v_strSQL = "BEGIN "
            v_strSQLMEMO = "BEGIN "


            v_strSQLTEMP = "select CFCUSTID,AUTHCUSTID, VIA  from OTRIGHT where " & v_strClause
            Dim v_ds As DataSet = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQLTEMP)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_strCUSTID = v_ds.Tables(0).Rows(0)("CFCUSTID")
                v_strAUTHCUSTID = v_ds.Tables(0).Rows(0)("AUTHCUSTID")
                v_strVia = v_ds.Tables(0).Rows(0)("VIA")
            End If
            'Update infor to OTRIGHT
            v_strSQL = v_strSQL & " UPDATE OTRIGHT SET " & ControlChars.CrLf _
                    & "     DELTD = 'Y', " & ControlChars.CrLf _
                    & "     LASTCHANGE = getcurrdate " & ControlChars.CrLf _
                    & "WHERE CFCUSTID = '" & v_strCUSTID & "' AND AUTHCUSTID = '" & v_strAUTHCUSTID & "' AND DELTD = 'N' and " & v_strClause & "; " '2.1.3.0|iss 1594
            v_strSQLMEMO = v_strSQLMEMO & " UPDATE OTRIGHT SET " & ControlChars.CrLf _
                    & "     DELTD = 'Y', " & ControlChars.CrLf _
                    & "     LASTCHANGE = getcurrdate " & ControlChars.CrLf _
                    & "WHERE CFCUSTID = '" & v_strCUSTID & "' AND AUTHCUSTID = '" & v_strAUTHCUSTID & "' AND DELTD = 'N' and " & v_strClause & "; " '2.1.3.0|iss 1594
            'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            'Update rights detail
            v_strSQL = v_strSQL & " UPDATE OTRIGHTDTL SET " & ControlChars.CrLf _
                    & "     DELTD = 'Y' " & ControlChars.CrLf _
                    & " WHERE CFCUSTID = '" & v_strCUSTID & "' AND AUTHCUSTID = '" & v_strAUTHCUSTID & "'AND VIA = '" & v_strVia & "';" '2.1.3.0|iss 1594

            v_strSQLMEMO = v_strSQLMEMO & " UPDATE OTRIGHTDTL SET " & ControlChars.CrLf _
                    & "     DELTD = 'Y' " & ControlChars.CrLf _
                    & " WHERE CFCUSTID = '" & v_strCUSTID & "' AND AUTHCUSTID = '" & v_strAUTHCUSTID & "'AND VIA = '" & v_strVia & "';" '2.1.3.0|iss 1594
            'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            'Update infor to Userlogin
            v_strSQL = v_strSQL & " UPDATE USERLOGIN SET " & ControlChars.CrLf _
                    & "     STATUS = 'E', " & ControlChars.CrLf _
                    & "     LASTCHANGED = getcurrdate " & ControlChars.CrLf _
                    & "WHERE USERNAME = (select custodycd from cfmast where custid = '" & v_strCUSTID & "') AND STATUS = 'A' " & ControlChars.CrLf _
                    & " and not exists (select CFCUSTID from OTRIGHT where CFCUSTID = '" & v_strCUSTID & "'  AND AUTHCUSTID = '" & v_strAUTHCUSTID & "' and deltd='N') ; " '2.1.3.0|iss1594
            v_strSQLMEMO = v_strSQLMEMO & " UPDATE USERLOGIN SET " & ControlChars.CrLf _
                                & "     STATUS = 'E', " & ControlChars.CrLf _
                                & "     LASTCHANGED = getcurrdate " & ControlChars.CrLf _
                                & "WHERE USERNAME = (select custodycd from cfmast where custid = '" & v_strCUSTID & "') AND STATUS = 'A' " & ControlChars.CrLf _
                                & " and not exists (select CFCUSTID from OTRIGHT where CFCUSTID = '" & v_strCUSTID & "'  AND AUTHCUSTID = '" & v_strAUTHCUSTID & "' and deltd='N') ; " '2.1.3.0|iss1594

            'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            v_strSQL = v_strSQL & " END;"
            v_strSQLMEMO = v_strSQLMEMO & " END;"

            v_lngErrorCode = RunApprExecSql(pv_xmlDocument, gc_ActionAdd, v_strSQL, CommandType.Text, v_strSQLMEMO)
            If v_lngErrorCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrorCode
                Exit Function
            End If

            Dim result As Long
            result = Me.MaintainLog(pv_xmlDocument, gc_ActionDeletE)
            If Not (result = ERR_APPROVE_REQUIRED Or result = ERR_SYSTEM_OK) Then
                Return result
            End If

            Return v_lngErrorCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
#End Region
End Class
