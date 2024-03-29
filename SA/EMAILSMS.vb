Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data

Public Class EMAILSMS
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "EMAILSMS"
    End Sub


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
                Case "EMAILSMS_Addnew"
                    v_lngErrCode = EMAILSMS_Addnew(pv_xmlDocument)
                Case "EMAILSMS_Edit"
                    v_lngErrCode = EMAILSMS_Edit(pv_xmlDocument)
                Case "EMAILSMS_Delete"
                    v_lngErrCode = EMAILSMS_Delete(pv_xmlDocument)
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

#Region " Overrides functions "

#End Region

#Region " Special Function "
    Private Function EMAILSMS_Addnew(ByRef pv_xmlDocument As XmlDocumentEx) As Long
        Try
            Dim v_lngErrorCode As Long = ERR_SYSTEM_OK
            Dim v_lngErrCode As Long = ERR_SYSTEM_OK

            Dim v_strErrorSource As String = "CF.EMAILSMS.EMAILSMS_Addnew", v_strErrorMessage As String

            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strClause As String
            Dim v_strLocal As String
            Dim v_strAutoId As String
            Dim l_datasourcesql As String
            Dim V_stremail As String
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
            End If

            'Check before add
            'v_strSQLTEMP = "SELECT * FROM EMAILSMS WHERE CFCUSTID = '" & v_strCUSTID & "' AND AUTHCUSTID = '" & v_strAUTHCUSTID & "' AND DELTD = 'N'"
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQLTEMP)
            'If v_ds.Tables(0).Rows.Count > 0 Then
            '    Return ERR_CF_EMAILSMS_DUPLICATE
            'End If

            Dim v_arrTABLE(4) As String
            v_arrTABLE(0) = "EMAILSMS"
            v_arrTABLE(1) = "EMAILSMSDTL"
            v_arrTABLE(2) = "USERLOGIN"
            v_arrTABLE(3) = "EMAILLOG"
            v_arrTABLE(4) = "CFMAST"


            v_lngErrorCode = VerifyMemoTable(v_arrTABLE)
            If v_lngErrorCode <> ERR_SYSTEM_OK Then
                Rollback()
                Return v_lngErrorCode
            End If

            'Insert infor to EMAILSMS
            v_strSQL = "BEGIN "
            v_strSQLMEMO = "BEGIN "


            'Insert infor to EMAILSMS
            v_strSQL = v_strSQL & " INSERT INTO EMAILSMS (AUTOID, CFCUSTID, AUTHCUSTID, AUTHTYPE, VALDATE, EXPDATE, DELTD, LASTCHANGE, SERIALTOKEN) " & ControlChars.CrLf _
                    & "SELECT SEQ_EMAILSMS.NEXTVAL, '" & v_strCUSTID & "', '" & v_strAUTHCUSTID & "', " & ControlChars.CrLf _
                & "     '" & v_strAUTHTYPE & "', TO_DATE('" & v_strVALDATE & "','DD/MM/YYYY'), TO_DATE('" & v_strEXPDATE & "','DD/MM/YYYY'), 'N', getcurrdate, '" & v_strSERIALTOKEN & "' FROM DUAL;"
            'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            v_strSQLMEMO = v_strSQLMEMO & " INSERT INTO EMAILSMSMEMO (AUTOID, CFCUSTID, AUTHCUSTID, AUTHTYPE, VALDATE, EXPDATE, DELTD, LASTCHANGE, SERIALTOKEN) " & ControlChars.CrLf _
                    & "SELECT SEQ_EMAILSMS.NEXTVAL, '" & v_strCUSTID & "', '" & v_strAUTHCUSTID & "', " & ControlChars.CrLf _
                & "     '" & v_strAUTHTYPE & "', TO_DATE('" & v_strVALDATE & "','DD/MM/YYYY'), TO_DATE('" & v_strEXPDATE & "','DD/MM/YYYY'), 'N', getcurrdate, '" & v_strSERIALTOKEN & "' FROM DUAL;"

            'Insert rights detail
            Dim v_arrRightDetail() As String
            For i As Integer = 0 To v_arrRightInfo.Length - 2
                v_arrRightDetail = v_arrRightInfo(i).Split("|")
                'Insert
                v_strSQL = v_strSQL & " INSERT INTO EMAILSMSDTL (AUTOID, CFCUSTID, AUTHCUSTID, OTMNCODE, EMAILSMS, DELTD) " & ControlChars.CrLf _
                        & "VALUES (SEQ_EMAILSMSDTL.NEXTVAL, '" & v_strCUSTID & "', '" & v_strAUTHCUSTID & "', " & ControlChars.CrLf _
                        & "'" & v_arrRightDetail(0) & "', '" & v_arrRightDetail(1) & "', 'N');"

                v_strSQLMEMO = v_strSQLMEMO & " INSERT INTO EMAILSMSDTLMEMO (AUTOID, CFCUSTID, AUTHCUSTID, OTMNCODE, EMAILSMS, DELTD) " & ControlChars.CrLf _
                                        & "VALUES (SEQ_EMAILSMSDTL.NEXTVAL, '" & v_strCUSTID & "', '" & v_strAUTHCUSTID & "', " & ControlChars.CrLf _
                                        & "'" & v_arrRightDetail(0) & "', '" & v_arrRightDetail(1) & "', 'N');"
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
                        & "'A',SYSDATE,'O',SYSDATE,30,'N','Y','" & v_strSERIALTOKEN & "' FROM CFMAST where custid = '" & v_strCUSTID & "' ;"
            'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            v_strSQLMEMO = v_strSQLMEMO & " INSERT INTO USERLOGINMEMO (USERNAME, LOGINPWD, AUTHTYPE, TRADINGPWD, STATUS, " & ControlChars.CrLf _
                        & "LASTLOGIN, LOGINSTATUS, LASTCHANGED, NUMBEROFDAY, ISMASTER, ISRESET, TOKENID) " & ControlChars.CrLf _
                        & "SELECT CUSTODYCD,GENENCRYPTPASSWORD('" & v_strPass & "'),'" & v_strAUTHTYPE & "',GENENCRYPTPASSWORD('" & v_strPass2 & "'), " & ControlChars.CrLf _
                        & "'A',SYSDATE,'O',SYSDATE,30,'N','Y','" & v_strSERIALTOKEN & "' FROM CFMAST where custid = '" & v_strCUSTID & "' ;"


            v_strSQL = v_strSQL & " update CFMAST set username = custodycd, TRADEONLINE = 'Y' where custid = '" & v_strCUSTID & "' ;"
            v_strSQLMEMO = v_strSQLMEMO & " update CFMASTMEMO set username = custodycd, TRADEONLINE = 'Y' where custid = '" & v_strCUSTID & "' ;"
            'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)



            l_datasourcesql = "select ''" & v_strcustodycd & "'' username, ''" & v_strPass & "'' loginpwd ,''" & v_strPass2 & "'' tradingpwd, ''" & v_strFullname & "'' fullname,''" & v_strtypetrade & "'' typetrade, ''" & v_strtypetradeSMS & "'' typetradesms, ''" & v_serial & "'' numberserial, ''" & v_strcustodycd & "'' custodycode from dual"

            v_strSQL = v_strSQL & " INSERT INTO emaillog (autoid, email, templateid, datasource, status,afacctno ,createtime)" & ControlChars.CrLf _
                       & "VALUES(seq_emaillog.nextval,'" & V_stremail & "','0212','" & l_datasourcesql & "','P','" & v_strcustodycd & "',SYSDATE);"

            v_strSQLMEMO = v_strSQLMEMO & " INSERT INTO emaillogmemo (autoid, email, templateid, datasource, status,afacctno ,createtime)" & ControlChars.CrLf _
                       & "VALUES(seq_emaillog.nextval,'" & V_stremail & "','0212','" & l_datasourcesql & "','A','" & v_strcustodycd & "',SYSDATE);"
            'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            v_strSQL = v_strSQL & " INSERT INTO emaillog (autoid, email, templateid, datasource, status,afacctno ,createtime)" & ControlChars.CrLf _
                       & "VALUES(seq_emaillog.nextval,'" & V_mobilesms & "','0303','" & l_datasourcesql & "','P','" & v_strcustodycd & "',SYSDATE);"

            v_strSQLMEMO = v_strSQLMEMO & " INSERT INTO emaillogmemo (autoid, email, templateid, datasource, status,afacctno ,createtime)" & ControlChars.CrLf _
                       & "VALUES(seq_emaillog.nextval,'" & V_mobilesms & "','0303','" & l_datasourcesql & "','A','" & v_strcustodycd & "',SYSDATE);"

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


    Private Function EMAILSMS_Edit(ByRef pv_xmlDocument As XmlDocumentEx) As Long
        Try
            Dim v_lngErrorCode As Long = ERR_SYSTEM_OK

            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strClause As String
            Dim v_strLocal As String
            Dim v_strAutoId As String

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
            End If

            Dim v_arrTABLE(4) As String
            v_arrTABLE(0) = "EMAILSMS"
            v_arrTABLE(1) = "EMAILSMSDTL"
            v_arrTABLE(2) = "USERLOGIN"
            v_arrTABLE(3) = "EMAILLOG"
            v_arrTABLE(4) = "CFMAST"


            v_lngErrorCode = VerifyMemoTable(v_arrTABLE)
            If v_lngErrorCode <> ERR_SYSTEM_OK Then
                Rollback()
                Return v_lngErrorCode
            End If

            'Insert infor to EMAILSMS
            v_strSQL = "BEGIN "
            v_strSQLMEMO = "BEGIN "


            'Update infor to EMAILSMS
            v_strSQL = v_strSQL & " UPDATE EMAILSMS SET " & ControlChars.CrLf _
                    & "     AUTHTYPE = '" & v_strAUTHTYPE & "', " & ControlChars.CrLf _
                    & "     VALDATE = TO_DATE('" & v_strVALDATE & "','DD/MM/YYYY'), " & ControlChars.CrLf _
                    & "     EXPDATE = TO_DATE('" & v_strEXPDATE & "','DD/MM/YYYY')," & ControlChars.CrLf _
                    & "     LASTCHANGE = getcurrdate," & ControlChars.CrLf _
                    & "     SERIALTOKEN = '" & v_strSERIALTOKEN & "'" & ControlChars.CrLf _
                    & " WHERE CFCUSTID = '" & v_strCUSTID & "' AND AUTHCUSTID = '" & v_strAUTHCUSTID & "' AND DELTD = 'N'; "

            v_strSQLMEMO = v_strSQLMEMO & " UPDATE EMAILSMSMEMO SET " & ControlChars.CrLf _
                    & "     AUTHTYPE = '" & v_strAUTHTYPE & "', " & ControlChars.CrLf _
                    & "     VALDATE = TO_DATE('" & v_strVALDATE & "','DD/MM/YYYY'), " & ControlChars.CrLf _
                    & "     EXPDATE = TO_DATE('" & v_strEXPDATE & "','DD/MM/YYYY')," & ControlChars.CrLf _
                    & "     LASTCHANGE = getcurrdate," & ControlChars.CrLf _
                    & "     SERIALTOKEN = '" & v_strSERIALTOKEN & "'" & ControlChars.CrLf _
                    & " WHERE CFCUSTID = '" & v_strCUSTID & "' AND AUTHCUSTID = '" & v_strAUTHCUSTID & "' AND DELTD = 'N'; "


            'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            'Update UserLogin
            v_strSQL = v_strSQL & " UPDATE USERLOGIN SET " & ControlChars.CrLf _
                    & "     TOKENID = '" & v_strSERIALTOKEN & "', AUTHTYPE ='" & v_strAUTHTYPE & "'  where USERNAME = (select custodycd from cfmast where custid ='" & v_strCUSTID & "') and STATUS = 'A'; "
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
                v_strSQLTEMP = "SELECT EMAILSMS FROM EMAILSMSDTL WHERE CFCUSTID = '" & v_strCUSTID & "' AND AUTHCUSTID = '" & v_strAUTHCUSTID & "' AND OTMNCODE = '" & v_arrRightDetail(0) & "' AND DELTD = 'N'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQLTEMP)


                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_strSQL = v_strSQL & " UPDATE EMAILSMSDTL SET " & ControlChars.CrLf _
                        & " EMAILSMS =  '" & v_arrRightDetail(1) & "' " & ControlChars.CrLf _
                        & " WHERE CFCUSTID = '" & v_strCUSTID & "' AND AUTHCUSTID = '" & v_strAUTHCUSTID & "' AND OTMNCODE = '" & v_arrRightDetail(0) & "' ;"
                    v_strSQLMEMO = v_strSQLMEMO & " UPDATE EMAILSMSDTLMEMO SET " & ControlChars.CrLf _
                                            & " EMAILSMS =  '" & v_arrRightDetail(1) & "' " & ControlChars.CrLf _
                                            & " WHERE CFCUSTID = '" & v_strCUSTID & "' AND AUTHCUSTID = '" & v_strAUTHCUSTID & "' AND OTMNCODE = '" & v_arrRightDetail(0) & "' ;"
                    'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                Else
                    'Them moi
                    v_strSQL = v_strSQL & " INSERT INTO EMAILSMSDTL (AUTOID, CFCUSTID, AUTHCUSTID, OTMNCODE, EMAILSMS, DELTD) " & ControlChars.CrLf _
                        & "VALUES (SEQ_EMAILSMSDTL.NEXTVAL, '" & v_strCUSTID & "', '" & v_strAUTHCUSTID & "', " & ControlChars.CrLf _
                        & "'" & v_arrRightDetail(0) & "', '" & v_arrRightDetail(1) & "', 'N');"
                    v_strSQLMEMO = v_strSQLMEMO & " INSERT INTO EMAILSMSDTLMEMO (AUTOID, CFCUSTID, AUTHCUSTID, OTMNCODE, EMAILSMS, DELTD) " & ControlChars.CrLf _
                        & "VALUES (SEQ_EMAILSMSDTL.NEXTVAL, '" & v_strCUSTID & "', '" & v_strAUTHCUSTID & "', " & ControlChars.CrLf _
                        & "'" & v_arrRightDetail(0) & "', '" & v_arrRightDetail(1) & "', 'N');"
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

    Private Function EMAILSMS_Delete(ByRef pv_xmlDocument As XmlDocumentEx) As Long
        Try
            Dim v_lngErrorCode As Long = ERR_SYSTEM_OK

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
            v_arrTABLE(0) = "EMAILSMS"
            v_arrTABLE(1) = "EMAILSMSDTL"
            v_arrTABLE(2) = "USERLOGIN"
            v_arrTABLE(3) = "EMAILLOG"
            v_arrTABLE(4) = "CFMAST"


            v_lngErrorCode = VerifyMemoTable(v_arrTABLE)
            If v_lngErrorCode <> ERR_SYSTEM_OK Then
                Rollback()
                Return v_lngErrorCode
            End If

            'Insert infor to EMAILSMS
            v_strSQL = "BEGIN "
            v_strSQLMEMO = "BEGIN "


            v_strSQLTEMP = "select CFCUSTID,AUTHCUSTID from EMAILSMS where " & v_strClause
            Dim v_ds As DataSet = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQLTEMP)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_strCUSTID = v_ds.Tables(0).Rows(0)("CFCUSTID")
                v_strAUTHCUSTID = v_ds.Tables(0).Rows(0)("AUTHCUSTID")
            End If
            'Update infor to EMAILSMS
            v_strSQL = v_strSQL & " UPDATE EMAILSMS SET " & ControlChars.CrLf _
                    & "     DELTD = 'Y', " & ControlChars.CrLf _
                    & "     LASTCHANGE = getcurrdate " & ControlChars.CrLf _
                    & "WHERE CFCUSTID = '" & v_strCUSTID & "' AND AUTHCUSTID = '" & v_strAUTHCUSTID & "' AND DELTD = 'N'; "
            v_strSQLMEMO = v_strSQLMEMO & " UPDATE EMAILSMS SET " & ControlChars.CrLf _
                    & "     DELTD = 'Y', " & ControlChars.CrLf _
                    & "     LASTCHANGE = getcurrdate " & ControlChars.CrLf _
                    & "WHERE CFCUSTID = '" & v_strCUSTID & "' AND AUTHCUSTID = '" & v_strAUTHCUSTID & "' AND DELTD = 'N'; "
            'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            'Update rights detail
            v_strSQL = v_strSQL & " UPDATE EMAILSMSDTL SET " & ControlChars.CrLf _
                    & "     DELTD = 'Y' " & ControlChars.CrLf _
                    & " WHERE CFCUSTID = '" & v_strCUSTID & "' AND AUTHCUSTID = '" & v_strAUTHCUSTID & "';"

            v_strSQLMEMO = v_strSQLMEMO & " UPDATE EMAILSMSDTL SET " & ControlChars.CrLf _
                    & "     DELTD = 'Y' " & ControlChars.CrLf _
                    & " WHERE CFCUSTID = '" & v_strCUSTID & "' AND AUTHCUSTID = '" & v_strAUTHCUSTID & "' ;"
            'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            'Update infor to Userlogin
            v_strSQL = v_strSQL & " UPDATE USERLOGIN SET " & ControlChars.CrLf _
                    & "     STATUS = 'E', " & ControlChars.CrLf _
                    & "     LASTCHANGED = getcurrdate " & ControlChars.CrLf _
                    & "WHERE USERNAME = (select custodycd from cfmast where custid = '" & v_strCUSTID & "') AND STATUS = 'A'; "
            v_strSQLMEMO = v_strSQLMEMO & " UPDATE USERLOGIN SET " & ControlChars.CrLf _
                                & "     STATUS = 'E', " & ControlChars.CrLf _
                                & "     LASTCHANGED = getcurrdate " & ControlChars.CrLf _
                                & "WHERE USERNAME = (select custodycd from cfmast where custid = '" & v_strCUSTID & "') AND STATUS = 'A'; "

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
