Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data

'Imports System.EnterpriseServices
'<JustInTimeActivation(False), _
'Transaction(TransactionOption.Supported), _
'ObjectPooling(Enabled:=True, MinPoolSize:=30)> _
Public Class Trans
    Inherits CoreBusiness.txMaster

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_MODULE = "CF"
    End Sub

#Region " Implement functions"
    Overrides Function txImpUpdate(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        'XÃ¡c Ä‘á»‹nh mÃ£ giao dá»‹ch tÆ°Æ¡ng á»©ng
        Dim v_lngErrorCode As Long
        Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
        Dim v_strTLTXCD As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLTXCD), Xml.XmlAttribute).Value)
        Select Case v_strTLTXCD
            'Thay hang so
            Case gc_CF_APPROVECONTRACT
                v_lngErrorCode = ApproveContract(pv_xmlDocument)
            Case "0060", "0061", "0062", "0090", "0091", "0092", "0093", "0094"
                v_lngErrorCode = Change_Risk_Paramater(pv_xmlDocument)
            Case gc_CF_CLOSECONTRACT
                v_lngErrorCode = CloseContract(pv_xmlDocument)
            Case gc_CF_CHANGE_AFTYPE
                v_lngErrorCode = fncChangeAftype(pv_xmlDocument)
            Case gc_CF_REQUEST_CHANGE_AFTYPE_TO_COREBANK
                v_lngErrorCode = RChangeAftypeToCorebank(pv_xmlDocument)
            Case gc_CF_CHANGE_AFTYPE_TO_COREBANK_TEMPORARY
                v_lngErrorCode = ChangeAftypeToCorebankTemporary(pv_xmlDocument)
            Case gc_CF_CHANGE_AFTYPE_TO_COREBANK
                v_lngErrorCode = ChangeAftypeToCorebank(pv_xmlDocument)
            Case gc_CF_REMOVE_MAP_BANKACCT
                v_lngErrorCode = RemoveMapBankAcct(pv_xmlDocument)
            Case gc_SE_COMPLETE_TOCLOSE
                v_lngErrorCode = CompleteCloseComtract(pv_xmlDocument)
            Case gc_CF_ACTIVECONTRACT
                v_lngErrorCode = fncActiveContract(pv_xmlDocument)
            Case gc_CI_ContractCloseRequest
                v_lngErrorCode = CloseRequest(pv_xmlDocument)
            Case gc_CF_CONFIRMCONTRACTTYPE
                v_lngErrorCode = ConfirmAFTYPE(pv_xmlDocument)
            Case gc_CF_CHANGE_SYSTEM_BOUNDARY
                v_lngErrorCode = ChangeSystemBoundary(pv_xmlDocument)
            Case gc_CF_CHANGE_CUSTOMIZE_AMPLITUDE
                v_lngErrorCode = ChangeCustomizeAmplitude(pv_xmlDocument)
            Case gc_CF_CHANGE_AUTHORIZE
                v_lngErrorCode = ChangeAuthorizeInfo(pv_xmlDocument)
            Case gc_CF_INSERT_AUTHORIZE
                v_lngErrorCode = InsertAuthorizeInfo(pv_xmlDocument)
            Case gc_CF_DELETE_AUTHORIZE
                v_lngErrorCode = DeleteAuthorizeInfo(pv_xmlDocument)
            Case gc_CF_CUSTOMIZE_ICCF
                v_lngErrorCode = CustomizeICCF(pv_xmlDocument)
            Case gc_CF_ALLOCATE_MARGIN_LIMIT
                v_lngErrorCode = InsertAllocateMarginLimit(pv_xmlDocument)
            Case gc_CF_RETRIEVE_MARGIN_LIMIT
                v_lngErrorCode = InsertRetrieveMarginLimit(pv_xmlDocument)

            Case gc_CF_USERLIMIT
                v_lngErrorCode = AllocateUserLimit(pv_xmlDocument)
            Case gc_CF_T0USERLIMIT
                v_lngErrorCode = AllocateT0UserLimit(pv_xmlDocument)
            Case gc_CF_REMAP_TOKEN
                v_lngErrorCode = RemapTokenMatrix(pv_xmlDocument)
        End Select
        'Tráº£ vá»? mÃ£ lá»—i
        Return v_lngErrorCode
    End Function

    Overrides Function txImpCheck(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrorCode As Long = ERR_SYSTEM_OK
        Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
        Dim v_strTLTXCD As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLTXCD), Xml.XmlAttribute).Value)
        Select Case v_strTLTXCD
            Case gc_CF_CHANGE_OTC
                v_lngErrorCode = SetCUSTODY_TO_CONTRACT(pv_xmlDocument)
            Case "0084"
                v_lngErrorCode = REFUSECONTRACT(pv_xmlDocument)
            Case "0085"
                v_lngErrorCode = CheckPIN(pv_xmlDocument)
            Case gc_CF_ACTIVECONTRACT
                v_lngErrorCode = chkActiveContract(pv_xmlDocument)
            Case gc_CF_CLOSE_CUSTODYCD
                v_lngErrorCode = chkCloseCustodyCode(pv_xmlDocument)
            Case gc_CF_CHANGE_IDCODE
                v_lngErrorCode = Check_ChangeIdcode(pv_xmlDocument)
            Case gc_CF_MAP_BANKACCT, gc_CF_REMOVE_MAP_BANKACCT
                v_lngErrorCode = ChkBalanceStschd(pv_xmlDocument)
            Case gc_CF_CHANGE_AFTYPE
                v_lngErrorCode = CheckChangeAftype(pv_xmlDocument)
            Case gc_CF_ALLOCATE_MARGIN_LIMIT
                v_lngErrorCode = CheckAllocateMarginLimit(pv_xmlDocument)
            Case gc_CF_RETRIEVE_MARGIN_LIMIT
                v_lngErrorCode = CheckRetrieveMarginLimit(pv_xmlDocument)
            Case gc_CI_ContractCloseRequest
                v_lngErrorCode = CheckMarginContractCloseRequest(pv_xmlDocument)
            Case gc_CF_USERLIMIT
                v_lngErrorCode = CheckAllocateUserLimit(pv_xmlDocument)
            Case gc_CF_T0USERLIMIT
                v_lngErrorCode = CheckAllocateT0UserLimit(pv_xmlDocument)

            Case gc_CF_CHKLIMIT
                v_lngErrorCode = Check_ChangeService(pv_xmlDocument)
            Case gc_CF_CHKTLID 'Dien comment
                v_lngErrorCode = Check_TLID(pv_xmlDocument) 'Dien comment
            Case gc_CF_ACTIVE_CUSTODYCODE
                v_lngErrorCode = check_0067(pv_xmlDocument)
        End Select
        'Tráº£ vá»? mÃ£ lá»—i
        Return v_lngErrorCode
    End Function

    Overrides Function txImpMisc(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        'XÃ¡c Ä‘á»‹nh mÃ£ giao dá»‹ch tÆ°Æ¡ng á»©ng
        Dim v_lngErrorCode As Long
        Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
        Dim v_strTLTXCD As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLTXCD), Xml.XmlAttribute).Value)
        Select Case v_strTLTXCD
            Case gc_CF_OPENCONTRACT
                v_lngErrorCode = OpenContract(pv_xmlDocument)
            Case gc_CF_CONTRACTINQUIRY
                v_lngErrorCode = InquiryContract(pv_xmlDocument)
            Case gc_CF_CONTRACTHISTORY
                v_lngErrorCode = HistoryContract(pv_xmlDocument)
            Case gc_CF_USERLOGIN
                v_lngErrorCode = MaintainUserLogin(pv_xmlDocument)

                'Case gc_CF_USERAFLIMIT
                '    v_lngErrorCode = AllocateUserAfLimit(pv_xmlDocument)
            Case gc_CF_RESET_TRADING_PASSWORD
                v_lngErrorCode = ResetTradingPassword(pv_xmlDocument)
            Case gc_CF_CHANGE_TRADING_PASSWORD
                v_lngErrorCode = ChangeTradingPassword(pv_xmlDocument)
            Case gc_CF_ISSUE_CUSTODYCD
                v_lngErrorCode = IssueCustodyCode2Customer(pv_xmlDocument)
            Case gc_CF_CUSTINFO_INQ
                v_lngErrorCode = InquiryCustInfo(pv_xmlDocument)
        End Select
        'Tráº£ vá»? mÃ£ lá»—i
        Return v_lngErrorCode
    End Function
#End Region

#Region " Private functions"
    Private Function ResetTradingPassword(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CF.Trans.MaintainUserLogin", v_strErrorMessage As String
        Dim v_strSQL As String = String.Empty
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE As Double
            Dim v_strCUSTID, v_strUSERNAME, v_strPIN, v_strCONFIRMPIN As String
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_ds As DataSet
            Dim v_dblSumSEDETAIL, v_dblDTOCLOSE, v_dblSDTOCLOSE As Int64
            Dim v_strSEACCTNO As String
            Dim v_dblSumCI As Double
            Dim v_dblSumSE As Double
            Dim v_strStatus As String
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False

            'Ä?á»?c ná»™i dung giao dá»‹ch
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If

                    Select Case v_strFLDCD
                        Case "03" 'CUSTID
                            v_strCUSTID = v_strVALUE
                        Case "29" 'PIN
                            v_strPIN = v_strVALUE
                        Case "33" 'CONFIRMPIN
                            v_strCONFIRMPIN = v_strVALUE
                    End Select
                End With
            Next

            'Lay thong tin user
            v_strSQL = "SELECT CUSTID FROM CFMAST WHERE CUSTID='" & v_strCUSTID.Trim & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                'v_strSQL = "UPDATE CFMAST SET PIN=GENENCRYPTPASSWORD(UPPER('" & v_strPIN.Trim.ToUpper & "')) WHERE CUSTID='" & v_strCUSTID & "'"
                v_strSQL = "UPDATE CFMAST SET PIN=UPPER('" & v_strPIN.Trim.ToUpper & "') WHERE CUSTID='" & v_strCUSTID & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            Else
                v_lngErrCode = ERR_CF_RECUSTID_NOTFOUND
            End If
            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function ChangeTradingPassword(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CF.Trans.MaintainUserLogin", v_strErrorMessage As String
        Dim v_strSQL As String = String.Empty
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE As Double
            Dim v_strCUSTID, v_strUSERNAME, v_strPIN, v_strOLDPIN, v_strCONFIRMPIN, v_strCONFIRMOLDPIN As String
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_ds As DataSet
            Dim v_dblSumSEDETAIL, v_dblDTOCLOSE, v_dblSDTOCLOSE As Int64
            Dim v_strSEACCTNO As String
            Dim v_dblSumCI As Double
            Dim v_dblSumSE As Double
            Dim v_strStatus As String
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False

            'Ä?á»?c ná»™i dung giao dá»‹ch
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If

                    Select Case v_strFLDCD
                        Case "03" 'CUSTID
                            v_strCUSTID = v_strVALUE
                        Case "27" 'PIN
                            v_strOLDPIN = v_strVALUE
                        Case "28" 'PIN
                            v_strCONFIRMOLDPIN = v_strVALUE
                        Case "29" 'PIN
                            v_strPIN = v_strVALUE
                        Case "33" 'CONFIRMPIN
                            v_strCONFIRMPIN = v_strVALUE
                    End Select
                End With
            Next

            'Lay thong tin user
            v_strSQL = "SELECT PIN FROM CFMAST WHERE CUSTID='" & v_strCUSTID.Trim & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                If v_ds.Tables(0).Rows(0)("PIN") = v_strOLDPIN.ToUpper Then
                    'v_strSQL = "UPDATE CFMAST SET PIN=GENENCRYPTPASSWORD(UPPER('" & v_strPIN.Trim.ToUpper & "')) WHERE CUSTID='" & v_strCUSTID & "'"
                    v_strSQL = "UPDATE CFMAST SET PIN=UPPER('" & v_strPIN.Trim.ToUpper & "') WHERE CUSTID='" & v_strCUSTID & "'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                Else
                    v_lngErrCode = ERR_CF_PIN_DIFFRENCE
                End If
            Else
                v_lngErrCode = ERR_CF_RECUSTID_NOTFOUND
            End If
            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function MaintainUserLogin(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CF.Trans.MaintainUserLogin"
        Dim v_strSQL As String = String.Empty
        Dim v_strDataSourceSQL As String = "select ''[username]'' username, ''[loginpwd]'' loginpwd, ''[tradingpwd]'' tradingpwd, ''[fullname]'' fullname, ''[custodycode]'' custodycode from dual"
        Dim v_strFullname As String = String.Empty
        Dim v_strCustodyCode As String = String.Empty
        Dim v_nodeList As Xml.XmlNodeList
        Dim i As Integer
        Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE As Double
        Dim v_strCUSTID, v_strUserLogin, v_strUSERNAME, v_strOldUsername, v_strLOGINPWD, v_strTRADINGPWD, v_strAUTHTYPE, v_strDAYS As String
        Dim v_strTemplateId As String = "0212" 'Mau template email thong bao cap tai khoan giao dich online
        Dim v_strIsMaster As String = "N"
        Dim v_strTokenId As String = String.Empty
        Dim v_strEmail As String
        Dim v_obj As New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)
        Dim v_ds As DataSet

        Try

            'Dim v_dblSDTOCLOSE As Int64
            'Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value

            'Ä?á»?c ná»™i dung giao dá»‹ch
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If

                    Select Case v_strFLDCD
                        Case "03" 'CUSTID
                            v_strCUSTID = v_strVALUE.Replace(".", "").Trim()
                        Case "05" 'Username
                            v_strUserLogin = v_strVALUE.Trim().ToUpper()
                        Case "10" 'LOGINPWD
                            v_strLOGINPWD = v_strVALUE.Trim()
                        Case "11" 'AUTHTYPE
                            v_strAUTHTYPE = v_strVALUE
                        Case "12" 'TRADINGPWD
                            v_strTRADINGPWD = v_strVALUE.Trim()
                        Case "13" 'DAYS
                            v_strDAYS = v_strVALUE
                        Case "06" 'Email
                            v_strEmail = v_strVALUE
                        Case "14" 'Master account
                            v_strIsMaster = v_strVALUE
                        Case "15"
                            v_strTokenId = v_strVALUE
                            'Case "20" 'HEADEREMAIL
                            '    v_strHEADEREMAIL = v_strVALUE
                            'Case "21" 'BODYTEMPATE
                            '    v_strBODYTEMPLATE = v_strVALUE
                    End Select
                End With
            Next

            'TruongLD add 2011/09/21 
            'Xu ly Fill thông tin tai khoan và password vào Email Template
            v_strDataSourceSQL = v_strDataSourceSQL.Replace("[username]", v_strUserLogin).Replace("[loginpwd]", v_strLOGINPWD).Replace("[tradingpwd]", v_strTRADINGPWD)
            'End TruongLD

            'Kiem tra xem khach hang nay da co username hay chua
            v_strSQL = "SELECT USERNAME, FULLNAME, CUSTODYCD FROM CFMAST WHERE CUSTID = '" & v_strCUSTID & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If Not v_ds.Tables(0).Rows.Count > 0 Then
                v_lngErrCode = ERR_CF_CUSTOMER_NOTFOUND
                Return v_lngErrCode
            Else
                v_strOldUsername = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("USERNAME"))
                v_strFullname = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("FULLNAME"))
                v_strCustodyCode = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("CUSTODYCD"))
            End If

            v_strDataSourceSQL = v_strDataSourceSQL.Replace("[fullname]", v_strFullname).Replace("[custodycode]", v_strCustodyCode)

            'Lay thong tin username
            v_strSQL = "SELECT USERNAME FROM CFMAST WHERE USERNAME='" & v_strUserLogin & "' and CUSTID <> '" & v_strCUSTID & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If Not v_ds.Tables(0).Rows.Count > 0 Then

                v_strUSERNAME = v_strUserLogin
                If v_strUSERNAME <> v_strOldUsername Then
                    'Xoa username cu di
                    v_strSQL = "DELETE FROM USERLOGIN WHERE USERNAME='" & v_strOldUsername & "'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                End If
                v_strSQL = "SELECT * FROM USERLOGIN WHERE USERNAME='" & v_strUSERNAME & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count = 0 Then
                    v_strSQL = "INSERT INTO USERLOGIN (USERNAME, LOGINPWD, AUTHTYPE, TRADINGPWD, STATUS, LASTLOGIN, LOGINSTATUS, LASTCHANGED, NUMBEROFDAY, ISMASTER, ISRESET, TOKENID) " & ControlChars.CrLf _
                        & "SELECT '" & v_strUSERNAME & "',GENENCRYPTPASSWORD(UPPER('" & v_strLOGINPWD & "')),'" & v_strAUTHTYPE & "',GENENCRYPTPASSWORD(UPPER('" & v_strTRADINGPWD & "'))," & ControlChars.CrLf _
                        & "'A',SYSDATE,'O',SYSDATE," & v_strDAYS & ",'" & v_strIsMaster & "','Y','" & v_strTokenId & "' FROM DUAL"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    v_strSQL = "UPDATE CFMAST SET USERNAME ='" & v_strUserLogin & "' WHERE CUSTID = '" & v_strCUSTID & "'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                Else
                    v_strTemplateId = "0213" 'Mau template email thong bao reset mat khau cua tai khoan giao dich online

                    v_strSQL = "UPDATE USERLOGIN SET ISRESET = 'Y', ISMASTER = '" & v_strIsMaster & "', TOKENID = '" & v_strTokenId & "', LASTCHANGED=SYSDATE, NUMBEROFDAY=" & v_strDAYS & ", LOGINPWD=GENENCRYPTPASSWORD(UPPER('" & v_strLOGINPWD & "')),AUTHTYPE='" & v_strAUTHTYPE & "',TRADINGPWD=GENENCRYPTPASSWORD(UPPER('" & v_strTRADINGPWD & "')) WHERE UPPER(USERNAME)='" & v_strUSERNAME & "'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                    v_strSQL = "UPDATE CFMAST SET USERNAME ='" & v_strUserLogin & "' WHERE CUSTID = '" & v_strCUSTID & "'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                End If

                'Log thong tin truoc khi gui mail
                v_strSQL = "INSERT INTO emaillog (autoid, email, templateid, datasource, status, createtime) " _
                         & "VALUES(seq_emaillog.nextval,'" & v_strEmail & "','" & v_strTemplateId & "','" & v_strDataSourceSQL & "','A', SYSDATE)"

                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                'v_lngErrCode = SendEMAIL(v_strObjMsg, v_strEmail)
            Else
                v_lngErrCode = ERR_CF_USERNAME_DUPLICATE
            End If
            Return v_lngErrCode

        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
    Private Function AllocateUserLimit(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CF.Trans.UserLimit", v_strErrorMessage As String
        Dim v_strSQL As String = String.Empty
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE, v_dblchkT0 As Double
            Dim v_strTLIDUSER, v_strUSERNAME, v_strActive, v_strUSERTYPE As String
            Dim v_dblALLOCATELIMMIT, v_dblchkALLOCATELIMMIT, v_dblALLOCATELIMMITOLD, v_dblUSEDLIMMIT, v_dblACCTLIMIT As Double
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_ds As DataSet
            Dim v_dblSumSEDETAIL, v_dblDTOCLOSE, v_dblSDTOCLOSE As Int64
            Dim v_strSEACCTNO As String
            Dim v_dblSumCI As Double
            Dim v_dblSumSE As Double
            Dim v_strStatus As String
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strOFFTIME As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFTIME).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value

            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False

            'Ä?á»?c ná»™i dung giao dá»‹ch
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If

                    Select Case v_strFLDCD
                        Case "03" 'TLIDUSER
                            v_strTLIDUSER = v_strVALUE
                        Case "04" 'USERNAME
                            v_strUSERNAME = v_strVALUE
                        Case "10" 'ALLOCATELIMMIT
                            v_dblALLOCATELIMMIT = v_dblVALUE
                        Case "11" 'ALLOCATELIMMITOLD
                            v_dblALLOCATELIMMITOLD = v_dblVALUE
                        Case "13" 'USEDLIMMIT
                            v_dblUSEDLIMMIT = v_dblVALUE
                        Case "20" 'ACCTLIMIT
                            v_dblACCTLIMIT = v_dblVALUE
                        Case "25" 'USERTYPE
                            v_strUSERTYPE = v_strVALUE
                    End Select
                End With
            Next

            'Tim nguoc lai chinh xac TLIDUSER vi co the bi Replace dau '.'
            v_strSQL = "Select TLIDUSER from v_userlimit Where Replace(tliduser,'.','') = Replace('" & v_strTLIDUSER & "','.','')"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            v_strTLIDUSER = v_ds.Tables(0).Rows(0)("TLIDUSER")

            If v_dblALLOCATELIMMIT < 0 Then
                v_lngErrCode = ERR_CF_USER_LIMIT_GREATER_ZERO
            Else


                v_strSQL = " Select ACTIVE FROM (" _
                    & " SELECT ACTIVE FROM TLPROFILES WHERE TLID ='" & v_strTLIDUSER.Trim & "' " _
                    & " UNION ALL " _
                    & " SELECT DECODE(STATUS,'A','Y',STATUS)  FROM USERLOGIN WHERE  USERNAME ='" & v_strTLIDUSER.Trim & "' " _
                    & " ) "
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_strActive = v_ds.Tables(0).Rows(0)("ACTIVE")
                    If Not v_strActive = "Y" Then
                        v_lngErrCode = ERR_CF_USER_NOT_ACTIVE
                    End If
                End If
                'Kiem tra xem neu: 
                '                 USER BO thi User trong BD  phai chua duoc cap han muc
                '                 USER BD thi User trong BO  phai chua duoc cap han muc.
                v_dblchkALLOCATELIMMIT = 0
                If v_strUSERTYPE = "BO" Then

                    ' User BD khong duoc cap han muc To
                    v_strSQL = " SELECT NVL(SUM(T0),0) T0" _
                             & " FROM USERLIMIT,USERLOGIN U, CFMAST CF WHERE TLIDUSER(+) = U.USERNAME and U.USERname =cf.username " _
                             & " and cf.idcode in (Select idcode from tlprofiles where tlid = '" & v_strTLIDUSER & "')"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count > 0 Then
                        v_dblchkT0 = v_ds.Tables(0).Rows(0)("T0")
                        If v_dblchkT0 > 0 Then
                            v_lngErrCode = ERR_CF_USER_BD_ALREADY_ALLOCATE_LIMIT
                        End If
                    End If

                    ' User BD khong duoc cap han muc Margin
                    v_strSQL = " SELECT NVL(SUM(ALLOCATELIMMIT),0) ALLOCATELIMMIT" _
                             & " FROM USERLIMIT,USERLOGIN U, CFMAST CF WHERE TLIDUSER(+) = U.USERNAME and U.USERname =cf.username " _
                             & " and cf.idcode in (Select idcode from tlprofiles where tlid = '" & v_strTLIDUSER & "')"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count > 0 Then
                        v_dblchkALLOCATELIMMIT = v_ds.Tables(0).Rows(0)("ALLOCATELIMMIT")
                        If v_dblchkALLOCATELIMMIT > 0 Then
                            v_lngErrCode = ERR_CF_USER_BD_ALREADY_ALLOCATE_LIMIT
                        End If
                    End If


                Else ' v_strUSERTYPE = "BD" 
                    v_strSQL = "SELECT NVL(SUM(T0),0) T0" _
                               & " FROM USERLIMIT,TLPROFILES TL WHERE TLIDUSER(+) = TLID" _
                             & " AND TL.idcode in (SELECT cf.idcode  idcode FROM CFMAST CF " _
                             & " WHERE cf.username = '" & v_strTLIDUSER & "')"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count > 0 Then
                        v_dblchkT0 = v_ds.Tables(0).Rows(0)("T0")
                        If v_dblchkT0 > 0 Then
                            v_lngErrCode = ERR_CF_USER_BO_ALREADY_ALLOCATE_LIMIT
                        End If
                    End If

                    'User BO khong duoc cap han muc Margin
                    v_strSQL = "SELECT NVL(SUM(ALLOCATELIMMIT),0) ALLOCATELIMMIT" _
                             & " FROM USERLIMIT,TLPROFILES TL WHERE TLIDUSER(+) = TLID" _
                             & " AND TL.idcode in (SELECT cf.idcode  idcode FROM CFMAST CF " _
                             & " WHERE cf.username = '" & v_strTLIDUSER & "')"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count > 0 Then
                        v_dblchkALLOCATELIMMIT = v_ds.Tables(0).Rows(0)("ALLOCATELIMMIT")
                        If v_dblchkALLOCATELIMMIT > 0 Then
                            v_lngErrCode = ERR_CF_USER_BO_ALREADY_ALLOCATE_LIMIT
                        End If
                    End If
                End If

                'Kiem tra xem khach hang da duoc cap han muc hay chua, neu chua co thi insert, co roi thi Update.
                v_strSQL = "SELECT * FROM USERLIMIT WHERE TLIDUSER = '" & v_strTLIDUSER.Trim & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If Not v_ds.Tables(0).Rows.Count > 0 Then
                    v_strSQL = "INSERT INTO USERLIMIT (TLIDUSER, ALLOCATELIMMIT, USEDLIMMIT, ACCTLIMIT, USERTYPE) " & ControlChars.CrLf _
                        & " VALUES ('" & v_strTLIDUSER.Trim & "'," & v_dblALLOCATELIMMIT & "," & v_dblUSEDLIMMIT & "," & v_dblACCTLIMIT & ", '" & v_strUSERTYPE & "')"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                Else

                    v_dblALLOCATELIMMITOLD = v_ds.Tables(0).Rows(0)("ALLOCATELIMMIT")
                    'v_dblALLOCATELIMMIT = v_ds.Tables(0).Rows(0)("ALLOCATELIMMIT")
                    v_dblUSEDLIMMIT = v_ds.Tables(0).Rows(0)("USEDLIMMIT")

                    If Not (IsDBNull(v_ds.Tables(0).Rows(0)("USERTYPE"))) Then
                        v_strUSERTYPE = v_ds.Tables(0).Rows(0)("USERTYPE")
                    Else
                        v_strUSERTYPE = ""
                    End If


                    'If v_dblALLOCATELIMMIT < v_dblUSEDLIMMIT Then
                    '    v_lngErrCode = ERR_CF_USER_LIMIT_GREATER_USEDLIMIT
                    'Else
                    If v_dblACCTLIMIT < 0 Then
                        v_lngErrCode = ERR_CF_ACCOUNT_LIMIT_SMALLER_THAN_ZERO
                    End If
                    v_strSQL = "UPDATE USERLIMIT SET ALLOCATELIMMIT= " & v_dblALLOCATELIMMIT & ", ACCTLIMIT = " & v_dblACCTLIMIT & " WHERE TLIDUSER = '" & v_strTLIDUSER & "'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                End If

                ' Cap nhat vao bang Userlimit log ------------------
                v_strSQL = "INSERT INTO USERLIMITLOG (TXDATE,TXNUM,TLIDUSER, ALLOCATELIMMIT, USEDLIMMIT, ACCTLIMIT, USERTYPE,TYPERECEIVE,OFFTIME) " & ControlChars.CrLf _
                    & " VALUES (" & "TO_DATE('" & v_strTXDATE & "','" & gc_FORMAT_DATE & "')" & ",'" & v_strTXNUM & "','" & v_strTLIDUSER.Trim & "'," & v_dblALLOCATELIMMIT & "," & v_dblUSEDLIMMIT & "," & v_dblACCTLIMIT & ", '" & v_strUSERTYPE & "','MR','" & v_strOFFTIME & "')"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            End If
            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
    Private Function AllocateT0UserLimit(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CF.Trans.UserLimit", v_strErrorMessage As String
        Dim v_strSQL As String = String.Empty
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE, v_dblchkALLOCATELIMMIT As Double
            Dim v_strTLIDUSER, v_strUSERNAME, v_strActive, v_strUSERTYPE As String
            Dim v_dblT0, v_dblchkT0, v_dblT0OLD, v_dblT0MAX As Double
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_ds As DataSet
            Dim v_dblSumSEDETAIL, v_dblDTOCLOSE, v_dblSDTOCLOSE As Int64
            Dim v_strSEACCTNO As String
            Dim v_dblSumCI As Double
            Dim v_dblSumSE As Double
            Dim v_strStatus As String
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strOFFTIME As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFTIME).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False

            'Ä?á»?c ná»™i dung giao dá»‹ch
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If

                    Select Case v_strFLDCD
                        Case "03" 'TLIDUSER
                            v_strTLIDUSER = v_strVALUE
                        Case "04" 'USERNAME
                            v_strUSERNAME = v_strVALUE
                        Case "16" 'T0
                            v_dblT0 = v_dblVALUE
                        Case "17" 'T0OLD
                            v_dblT0OLD = v_dblVALUE
                        Case "18" 'T0MAX
                            v_dblT0MAX = v_dblVALUE
                        Case "25" 'USERTYPE
                            v_strUSERTYPE = v_strVALUE
                    End Select
                End With
            Next

            'Tim nguoc lai chinh xac TLIDUSER vi co the bi Replace dau '.'
            v_strSQL = "Select TLIDUSER from v_userlimit Where Replace(tliduser,'.','') = Replace('" & v_strTLIDUSER & "','.','')"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            v_strTLIDUSER = v_ds.Tables(0).Rows(0)("TLIDUSER")

            If v_dblT0 < 0 Then
                v_lngErrCode = ERR_CF_T0_USER_LIMIT_GREATER_ZERO
            Else


                v_strSQL = " Select ACTIVE FROM (" _
                    & " SELECT ACTIVE FROM TLPROFILES WHERE TLID ='" & v_strTLIDUSER.Trim & "' " _
                    & " UNION ALL " _
                    & " SELECT DECODE(STATUS,'A','Y',STATUS)  FROM USERLOGIN WHERE  USERNAME ='" & v_strTLIDUSER.Trim & "' " _
                    & " ) "
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_strActive = v_ds.Tables(0).Rows(0)("ACTIVE")
                    If Not v_strActive = "Y" Then
                        v_lngErrCode = ERR_CF_USER_NOT_ACTIVE
                    End If
                End If
                'Kiem tra xem neu: 
                '                 USER BO thi User trong BD  phai chua duoc cap han muc
                '                 USER BD thi User trong BO  phai chua duoc cap han muc.
                v_dblchkT0 = 0
                If v_strUSERTYPE = "BO" Then

                    ' User BD khong duoc cap han muc To
                    v_strSQL = " SELECT NVL(SUM(T0),0) T0" _
                             & " FROM USERLIMIT,USERLOGIN U, CFMAST CF WHERE TLIDUSER(+) = U.USERNAME and U.USERname =cf.username " _
                             & " and cf.idcode in (Select idcode from tlprofiles where tlid = '" & v_strTLIDUSER & "')"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count > 0 Then
                        v_dblchkT0 = v_ds.Tables(0).Rows(0)("T0")
                        If v_dblchkT0 > 0 Then
                            v_lngErrCode = ERR_CF_USER_BD_ALREADY_ALLOCATE_LIMIT
                        End If
                    End If

                    ' User BD khong duoc cap han muc Margin
                    v_strSQL = " SELECT NVL(SUM(ALLOCATELIMMIT),0) ALLOCATELIMMIT" _
                             & " FROM USERLIMIT,USERLOGIN U, CFMAST CF WHERE TLIDUSER(+) = U.USERNAME and U.USERname =cf.username " _
                             & " and cf.idcode in (Select idcode from tlprofiles where tlid = '" & v_strTLIDUSER & "')"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count > 0 Then
                        v_dblchkALLOCATELIMMIT = v_ds.Tables(0).Rows(0)("ALLOCATELIMMIT")
                        If v_dblchkALLOCATELIMMIT > 0 Then
                            v_lngErrCode = ERR_CF_USER_BD_ALREADY_ALLOCATE_LIMIT
                        End If
                    End If


                Else ' v_strUSERTYPE = "BD" 
                    v_strSQL = "SELECT NVL(SUM(T0),0) T0" _
                               & " FROM USERLIMIT,TLPROFILES TL WHERE TLIDUSER(+) = TLID" _
                               & " AND TL.idcode in (SELECT cf.idcode  idcode FROM CFMAST CF " _
                               & " WHERE cf.username = '" & v_strTLIDUSER & "')"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count > 0 Then
                        v_dblchkT0 = v_ds.Tables(0).Rows(0)("T0")
                        If v_dblchkT0 > 0 Then
                            v_lngErrCode = ERR_CF_USER_BO_ALREADY_ALLOCATE_LIMIT
                        End If
                    End If

                    'User BO khong duoc cap han muc Margin
                    v_strSQL = "SELECT NVL(SUM(ALLOCATELIMMIT),0) ALLOCATELIMMIT" _
                             & " FROM USERLIMIT,TLPROFILES TL WHERE TLIDUSER(+) = TLID" _
                             & " AND TL.idcode in (SELECT cf.idcode  idcode FROM CFMAST CF " _
                             & " WHERE cf.username = '" & v_strTLIDUSER & "')"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count > 0 Then
                        v_dblchkALLOCATELIMMIT = v_ds.Tables(0).Rows(0)("ALLOCATELIMMIT")
                        If v_dblchkALLOCATELIMMIT > 0 Then
                            v_lngErrCode = ERR_CF_USER_BO_ALREADY_ALLOCATE_LIMIT
                        End If
                    End If
                End If

                'Kiem tra xem khach hang da duoc cap han muc hay chua, neu chua co thi insert, co roi thi Update.
                v_strSQL = "SELECT * FROM USERLIMIT WHERE TLIDUSER = '" & v_strTLIDUSER.Trim & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If Not v_ds.Tables(0).Rows.Count > 0 Then
                    v_strSQL = "INSERT INTO USERLIMIT (TLIDUSER, T0, T0MAX, USERTYPE) " & ControlChars.CrLf _
                        & " VALUES ('" & v_strTLIDUSER.Trim & "'," & v_dblT0 & "," & v_dblT0MAX & ", '" & v_strUSERTYPE & "')"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                Else

                    v_dblT0OLD = v_ds.Tables(0).Rows(0)("T0")

                    If Not (IsDBNull(v_ds.Tables(0).Rows(0)("USERTYPE"))) Then
                        v_strUSERTYPE = v_ds.Tables(0).Rows(0)("USERTYPE")
                    Else
                        v_strUSERTYPE = ""
                    End If


                    If v_dblT0MAX < 0 Then
                        v_lngErrCode = ERR_CF_T0_MAX_SMALLER_THAN_ZERO
                    End If

                    v_strSQL = "UPDATE USERLIMIT SET T0= " & v_dblT0 & ", T0MAX = " & v_dblT0MAX & " WHERE TLIDUSER = '" & v_strTLIDUSER & "'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                End If
                ' Cap nhat vao bang Userlimit log ------------------
                v_strSQL = "INSERT INTO USERLIMITLOG (TXDATE,TXNUM,TLIDUSER,T0, T0MAX, USERTYPE,TYPERECEIVE,OFFTIME) " & ControlChars.CrLf _
                    & " VALUES (" & "TO_DATE('" & v_strTXDATE & "','" & gc_FORMAT_DATE & "')" & ",'" & v_strTXNUM & "','" & v_strTLIDUSER.Trim & "'," & v_dblT0 & "," & v_dblT0MAX & ", '" & v_strUSERTYPE & "','T0','" & v_strOFFTIME & "')"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End If
            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function CheckAllocateUserLimit(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CF.Trans.UserLimit", v_strErrorMessage As String
        Dim v_strSQL As String = String.Empty
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE As Double
            Dim v_strTLIDUSER, v_strUSERNAME, v_strActive, v_strUSERTYPE As String
            Dim v_dblALLOCATELIMMIT, v_dblchkALLOCATELIMMIT, v_dblALLOCATELIMMITOLD, v_dblUSEDLIMMIT, v_dblACCTLIMIT, v_dblchkT0 As Double
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_ds As DataSet
            Dim v_dblSumSEDETAIL, v_dblDTOCLOSE, v_dblSDTOCLOSE As Int64
            Dim v_strSEACCTNO As String
            Dim v_dblSumCI As Double
            Dim v_dblSumSE As Double
            Dim v_strStatus As String
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False

            'Ä?á»?c ná»™i dung giao dá»‹ch
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If

                    Select Case v_strFLDCD
                        Case "03" 'TLIDUSER
                            v_strTLIDUSER = v_strVALUE
                        Case "04" 'USERNAME
                            v_strUSERNAME = v_strVALUE
                        Case "10" 'ALLOCATELIMMIT
                            v_dblALLOCATELIMMIT = v_dblVALUE
                        Case "11" 'ALLOCATELIMMITOLD
                            v_dblALLOCATELIMMITOLD = v_dblVALUE
                        Case "13" 'USEDLIMMIT
                            v_dblUSEDLIMMIT = v_dblVALUE
                        Case "20" 'ACCTLIMIT
                            v_dblACCTLIMIT = v_dblVALUE
                        Case "25" 'USERTYPE
                            v_strUSERTYPE = v_strVALUE
                    End Select
                End With
            Next

            'Tim nguoc lai chinh xac TLIDUSER vi co the bi Replace dau '.'
            v_strSQL = "Select TLIDUSER from v_userlimit Where Replace(tliduser,'.','') = Replace('" & v_strTLIDUSER & "','.','')"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            v_strTLIDUSER = v_ds.Tables(0).Rows(0)("TLIDUSER")

            If v_dblALLOCATELIMMIT < 0 Then
                v_lngErrCode = ERR_CF_USER_LIMIT_GREATER_ZERO
            Else


                v_strSQL = " Select ACTIVE FROM (" _
                    & " SELECT ACTIVE FROM TLPROFILES WHERE TLID ='" & v_strTLIDUSER.Trim & "' " _
                    & " UNION ALL " _
                    & " SELECT DECODE(STATUS,'A','Y',STATUS)  FROM USERLOGIN WHERE  USERNAME ='" & v_strTLIDUSER.Trim & "' " _
                    & " ) "
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_strActive = v_ds.Tables(0).Rows(0)("ACTIVE")
                    If Not v_strActive = "Y" Then
                        v_lngErrCode = ERR_CF_USER_NOT_ACTIVE
                    End If
                End If
                'Kiem tra xem neu: 
                '                 USER BO thi User trong BD  phai chua duoc cap han muc
                '                 USER BD thi User trong BO  phai chua duoc cap han muc.
                v_dblchkALLOCATELIMMIT = 0
                If v_strUSERTYPE = "BO" Then

                    ' User BD khong duoc cap han muc To
                    v_strSQL = " SELECT NVL(SUM(T0),0) T0" _
                             & " FROM USERLIMIT,USERLOGIN U, CFMAST CF WHERE TLIDUSER(+) = U.USERNAME and U.USERname =cf.username " _
                             & " and cf.idcode in (Select idcode from tlprofiles where tlid = '" & v_strTLIDUSER & "')"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count > 0 Then
                        v_dblchkT0 = v_ds.Tables(0).Rows(0)("T0")
                        If v_dblchkT0 > 0 Then
                            v_lngErrCode = ERR_CF_USER_BD_ALREADY_ALLOCATE_LIMIT
                        End If
                    End If

                    ' User BD khong duoc cap han muc Margin
                    v_strSQL = " SELECT NVL(SUM(ALLOCATELIMMIT),0) ALLOCATELIMMIT" _
                             & " FROM USERLIMIT,USERLOGIN U, CFMAST CF WHERE TLIDUSER(+) = U.USERNAME and U.USERname =cf.username " _
                             & " and cf.idcode in (Select idcode from tlprofiles where tlid = '" & v_strTLIDUSER & "')"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count > 0 Then
                        v_dblchkALLOCATELIMMIT = v_ds.Tables(0).Rows(0)("ALLOCATELIMMIT")
                        If v_dblchkALLOCATELIMMIT > 0 Then
                            v_lngErrCode = ERR_CF_USER_BD_ALREADY_ALLOCATE_LIMIT
                        End If
                    End If


                Else ' v_strUSERTYPE = "BD" 
                    v_strSQL = "SELECT NVL(SUM(T0),0) T0" _
                               & " FROM USERLIMIT,TLPROFILES TL WHERE TLIDUSER(+) = TLID" _
                               & " AND TL.idcode in (SELECT cf.idcode  idcode FROM CFMAST CF " _
                               & " WHERE cf.username = '" & v_strTLIDUSER & "')"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    'If v_ds.Tables(0).Rows.Count > 0 Then
                    v_dblchkT0 = v_ds.Tables(0).Rows(0)("T0")
                    If v_dblchkT0 > 0 Then
                        v_lngErrCode = ERR_CF_USER_BO_ALREADY_ALLOCATE_LIMIT
                    End If
                    'End If

                    'User BO khong duoc cap han muc Margin
                    v_strSQL = "SELECT NVL(SUM(ALLOCATELIMMIT),0) ALLOCATELIMMIT" _
                             & " FROM USERLIMIT,TLPROFILES TL WHERE TLIDUSER(+) = TLID " _
                             & " AND TL.idcode in (SELECT cf.idcode  idcode FROM CFMAST CF " _
                             & " WHERE cf.username = '" & v_strTLIDUSER & "')"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count > 0 Then
                        v_dblchkALLOCATELIMMIT = v_ds.Tables(0).Rows(0)("ALLOCATELIMMIT")
                        If v_dblchkALLOCATELIMMIT > 0 Then
                            v_lngErrCode = ERR_CF_USER_BO_ALREADY_ALLOCATE_LIMIT
                        End If
                    End If
                End If

                'Kiem tra xem khach hang da duoc cap han muc hay chua, neu chua co thi insert, co roi thi Update.
                v_strSQL = "SELECT * FROM USERLIMIT WHERE TLIDUSER = '" & v_strTLIDUSER.Trim & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_dblALLOCATELIMMITOLD = v_ds.Tables(0).Rows(0)("ALLOCATELIMMIT")
                    v_dblUSEDLIMMIT = v_ds.Tables(0).Rows(0)("USEDLIMMIT")

                    If Not (IsDBNull(v_ds.Tables(0).Rows(0)("USERTYPE"))) Then
                        v_strUSERTYPE = v_ds.Tables(0).Rows(0)("USERTYPE")
                    Else
                        v_strUSERTYPE = ""
                    End If


                    'If v_dblALLOCATELIMMIT < v_dblUSEDLIMMIT Then
                    '    v_lngErrCode = ERR_CF_USER_LIMIT_GREATER_USEDLIMIT
                    'Else
                    If v_dblACCTLIMIT < 0 Then
                        v_lngErrCode = ERR_CF_ACCOUNT_LIMIT_SMALLER_THAN_ZERO
                    End If

                End If
            End If
            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
    Private Function CheckAllocateT0UserLimit(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CF.Trans.UserLimit", v_strErrorMessage As String
        Dim v_strSQL As String = String.Empty
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE As Double
            Dim v_strTLIDUSER, v_strUSERNAME, v_strActive, v_strUSERTYPE As String
            Dim v_dblT0, v_dblchkT0, v_dblT0OLD, v_dblT0MAX, v_dblchkALLOCATELIMMIT As Double
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_ds As DataSet
            Dim v_dblSumSEDETAIL, v_dblDTOCLOSE, v_dblSDTOCLOSE As Int64
            Dim v_strSEACCTNO As String
            Dim v_dblSumCI As Double
            Dim v_dblSumSE As Double
            Dim v_strStatus As String
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False

            'Ä?á»?c ná»™i dung giao dá»‹ch
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If

                    Select Case v_strFLDCD
                        Case "03" 'TLIDUSER
                            v_strTLIDUSER = v_strVALUE
                        Case "04" 'USERNAME
                            v_strUSERNAME = v_strVALUE
                        Case "16" 'T0
                            v_dblT0 = v_dblVALUE
                        Case "17" 'T0OLD
                            v_dblT0OLD = v_dblVALUE
                        Case "18" 'T0MAX
                            v_dblT0MAX = v_dblVALUE
                        Case "25" 'USERTYPE
                            v_strUSERTYPE = v_strVALUE
                    End Select
                End With
            Next

            'Tim nguoc lai chinh xac TLIDUSER vi co the bi Replace dau '.'
            v_strSQL = "Select TLIDUSER from v_userlimit Where Replace(tliduser,'.','') = Replace('" & v_strTLIDUSER & "','.','')"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            v_strTLIDUSER = v_ds.Tables(0).Rows(0)("TLIDUSER")

            If v_dblT0 < 0 Then
                v_lngErrCode = ERR_CF_T0_USER_LIMIT_GREATER_ZERO
            Else


                v_strSQL = " Select ACTIVE FROM (" _
                    & " SELECT ACTIVE FROM TLPROFILES WHERE TLID ='" & v_strTLIDUSER.Trim & "' " _
                    & " UNION ALL " _
                    & " SELECT DECODE(STATUS,'A','Y',STATUS)  FROM USERLOGIN WHERE  USERNAME ='" & v_strTLIDUSER.Trim & "' " _
                    & " ) "
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_strActive = v_ds.Tables(0).Rows(0)("ACTIVE")
                    If Not v_strActive = "Y" Then
                        v_lngErrCode = ERR_CF_USER_NOT_ACTIVE
                    End If
                End If
                'Kiem tra xem neu: 
                '                 USER BO thi User trong BD  phai chua duoc cap han muc Margin va han muc T0
                '                 USER BD thi User trong BO  phai chua duoc cap han muc Margin va han muc T0
                v_dblchkT0 = 0
                If v_strUSERTYPE = "BO" Then

                    ' User BD khong duoc cap han muc To
                    v_strSQL = " SELECT NVL(SUM(T0),0) T0" _
                             & " FROM USERLIMIT,USERLOGIN U, CFMAST CF WHERE TLIDUSER(+) = U.USERNAME and U.USERname =cf.username " _
                             & " and cf.idcode in (Select idcode from tlprofiles where tlid = '" & v_strTLIDUSER & "')"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count > 0 Then
                        v_dblchkT0 = v_ds.Tables(0).Rows(0)("T0")
                        If v_dblchkT0 > 0 Then
                            v_lngErrCode = ERR_CF_USER_BD_ALREADY_ALLOCATE_LIMIT
                        End If
                    End If

                    ' User BD khong duoc cap han muc Margin
                    v_strSQL = " SELECT NVL(SUM(ALLOCATELIMMIT),0) ALLOCATELIMMIT" _
                             & " FROM USERLIMIT,USERLOGIN U, CFMAST CF WHERE TLIDUSER(+) = U.USERNAME and U.USERname =cf.username " _
                             & " and cf.idcode in (Select idcode from tlprofiles where tlid = '" & v_strTLIDUSER & "')"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count > 0 Then
                        v_dblchkALLOCATELIMMIT = v_ds.Tables(0).Rows(0)("ALLOCATELIMMIT")
                        If v_dblchkALLOCATELIMMIT > 0 Then
                            v_lngErrCode = ERR_CF_USER_BD_ALREADY_ALLOCATE_LIMIT
                        End If
                    End If


                Else ' v_strUSERTYPE = "BD" 
                    v_strSQL = "SELECT NVL(SUM(T0),0) T0" _
                               & " FROM USERLIMIT,TLPROFILES TL WHERE TLIDUSER(+) = TLID" _
                               & " AND TL.idcode in (SELECT cf.idcode  idcode FROM CFMAST CF " _
                               & " WHERE cf.username = '" & v_strTLIDUSER & "')"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count > 0 Then
                        v_dblchkT0 = v_ds.Tables(0).Rows(0)("T0")
                        If v_dblchkT0 > 0 Then
                            v_lngErrCode = ERR_CF_USER_BO_ALREADY_ALLOCATE_LIMIT
                        End If
                    End If

                    'User BO khong duoc cap han muc Margin
                    v_strSQL = "SELECT NVL(SUM(ALLOCATELIMMIT),0) ALLOCATELIMMIT" _
                             & " FROM USERLIMIT,TLPROFILES TL WHERE TLIDUSER(+) = TLID" _
                             & " AND TL.idcode in (SELECT cf.idcode  idcode FROM CFMAST CF " _
                             & " WHERE cf.username = '" & v_strTLIDUSER & "')"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count > 0 Then
                        v_dblchkALLOCATELIMMIT = v_ds.Tables(0).Rows(0)("ALLOCATELIMMIT")
                        If v_dblchkALLOCATELIMMIT > 0 Then
                            v_lngErrCode = ERR_CF_USER_BO_ALREADY_ALLOCATE_LIMIT
                        End If
                    End If
                End If

                'Kiem tra xem khach hang da duoc cap han muc hay chua, neu chua co thi insert, co roi thi Update.
                v_strSQL = "SELECT * FROM USERLIMIT WHERE TLIDUSER = '" & v_strTLIDUSER.Trim & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_dblT0OLD = v_ds.Tables(0).Rows(0)("T0")


                    If Not (IsDBNull(v_ds.Tables(0).Rows(0)("USERTYPE"))) Then
                        v_strUSERTYPE = v_ds.Tables(0).Rows(0)("USERTYPE")
                    Else
                        v_strUSERTYPE = ""
                    End If


                    If v_dblT0MAX < 0 Then
                        v_lngErrCode = ERR_CF_T0_MAX_SMALLER_THAN_ZERO
                    End If

                End If
            End If
            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
    Private Function AllocateUserAfLimit(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CF.Trans.UserAfLimit", v_strErrorMessage As String
        Dim v_strSQL As String = String.Empty
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE As Double
            Dim v_dblACCLIMIT, v_dblMRCRLIMITMAX As Double
            Dim v_strACCTNO As String
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_ds As DataSet
            Dim v_dblSumSEDETAIL, v_dblDTOCLOSE, v_dblSDTOCLOSE As Int64
            Dim v_strSEACCTNO As String
            Dim v_dblSumCI As Double
            Dim v_dblSumSE As Double
            Dim v_strStatus As String
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False

            'Ä?á»?c ná»™i dung giao dá»‹ch
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If

                    Select Case v_strFLDCD
                        Case "03" 'ACCTNO
                            v_strACCTNO = v_strVALUE
                        Case "10" 'ACCLIMIT
                            v_dblACCLIMIT = v_strVALUE
                        Case "11" 'MRCRLIMITMAX
                            v_dblMRCRLIMITMAX = v_dblVALUE

                    End Select
                End With
            Next
            'If v_dblALLOCATELIMMIT < 0 Then
            '    v_lngErrCode = ERR_CF_USER_LIMIT_GREATER_ZERO
            'Else

            '    'Kiem tra xem khach hang da duoc cap han muc hay chua, neu chua co thi insert, co roi thi Update.
            '    v_strSQL = "SELECT * FROM USERLIMIT WHERE TLIDUSER = '" & v_strTLIDUSER.Trim & "'"
            '    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            '    If Not v_ds.Tables(0).Rows.Count > 0 Then
            '        v_strSQL = "INSERT INTO USERLIMIT (TLIDUSER, ALLOCATELIMMIT, USEDLIMMIT) " & ControlChars.CrLf _
            '            & " VALUES ('" & v_strTLIDUSER.Trim & "'," & v_dblALLOCATELIMMIT & "," & v_dblUSEDLIMMIT & ")"
            '        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            '    Else

            '        v_dblALLOCATELIMMITOLD = v_ds.Tables(0).Rows(0)("ALLOCATELIMMIT")
            '        v_dblUSEDLIMMIT = v_ds.Tables(0).Rows(0)("USEDLIMMIT")

            '        If v_dblALLOCATELIMMIT < v_dblUSEDLIMMIT Then
            '            v_lngErrCode = ERR_CF_USER_LIMIT_GREATER_USEDLIMIT
            '        End If

            '        v_strSQL = "UPDATE USERLIMIT SET ALLOCATELIMMIT =" & v_dblALLOCATELIMMIT & "  WHERE TLIDUSER = '" & v_strTLIDUSER & "'"
            '        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            '    End If
            'End If
            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
    Private Function CheckLimit(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Try


            Dim APPLID, v_strFLDCD, v_strFLDTYPE, v_strVALUE, v_strAFACCTNO As String, i As Int32
            Dim v_nodeList As Xml.XmlNodeList
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    v_strVALUE = Trim(.InnerText.ToString)
                    Select Case v_strFLDCD
                        Case "03" 'AFACCTNO
                            v_strAFACCTNO = v_strVALUE
                    End Select
                End With
            Next



            Dim v_strSQL As String = String.Empty
            Dim v_strMARGINLIMIT, v_strADVANCELIMIT, v_strREPOLIMIT, v_strDEPOSITLIMIT, v_strTRADELIMIT As String
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_ds As DataSet
            v_strSQL = " select MARGINLIMIT ,TRADELIMIT ,ADVANCELIMIT,REPOLIMIT ,DEPOSITLIMIT  FROM CFMAST WHERE CUSTID=(select CUSTID from AFMAST WHERE ACCTNO='" & v_strAFACCTNO & "')"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If Not (IsDBNull(v_ds.Tables(0).Rows(0)("MARGINLIMIT"))) Then
                v_strMARGINLIMIT = v_ds.Tables(0).Rows(0)("MARGINLIMIT")
            Else
                v_strMARGINLIMIT = "0"
            End If
            If Not (IsDBNull(v_ds.Tables(0).Rows(0)("TRADELIMIT"))) Then
                v_strTRADELIMIT = v_ds.Tables(0).Rows(0)("TRADELIMIT")
            Else
                v_strTRADELIMIT = "0"
            End If
            If Not (IsDBNull(v_ds.Tables(0).Rows(0)("ADVANCELIMIT"))) Then
                v_strADVANCELIMIT = v_ds.Tables(0).Rows(0)("ADVANCELIMIT")
            Else
                v_strADVANCELIMIT = "0"
            End If
            If Not (IsDBNull(v_ds.Tables(0).Rows(0)("REPOLIMIT"))) Then
                v_strREPOLIMIT = v_ds.Tables(0).Rows(0)("REPOLIMIT")
            Else
                v_strREPOLIMIT = "0"
            End If
            If Not (IsDBNull(v_ds.Tables(0).Rows(0)("DEPOSITLIMIT"))) Then
                v_strDEPOSITLIMIT = v_ds.Tables(0).Rows(0)("DEPOSITLIMIT")
            Else
                v_strDEPOSITLIMIT = "0"
            End If

            v_strSQL = "select Sum(MARGINLINE) SMARGINLINE,Sum(TRADELINE) STRADELINE,SUM(ADVANCELINE) SADVANCELINE," &
                                                                                    "SUM(REPOLINE) SREPOLINE,SUM(DEPOSITLINE) SDEPOSITLINE from AFMAST where CUSTID=(select CUSTID from AFMAST WHERE ACCTNO='" & v_strAFACCTNO & "')"

            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count >= 1 Then

                If Not (IsDBNull(v_ds.Tables(0).Rows(0)("SMARGINLINE"))) Then
                    If v_ds.Tables(0).Rows(0)("SMARGINLINE") > CDbl(v_strMARGINLIMIT) Then
                        Return ERR_CF_OVER_MARGINLIMIT
                    End If
                End If
                If Not (IsDBNull(v_ds.Tables(0).Rows(0)("SADVANCELINE"))) Then
                    If v_ds.Tables(0).Rows(0)("SADVANCELINE") > CDbl(v_strADVANCELIMIT) Then
                        Return ERR_CF_OVER_ADVANCELIMIT
                    End If
                End If
                If Not (IsDBNull(v_ds.Tables(0).Rows(0)("SREPOLINE"))) Then
                    If v_ds.Tables(0).Rows(0)("SREPOLINE") > CDbl(v_strREPOLIMIT) Then
                        Return ERR_CF_OVER_REPOLIMIT
                    End If
                End If
                If Not (IsDBNull(v_ds.Tables(0).Rows(0)("SDEPOSITLINE"))) Then
                    If v_ds.Tables(0).Rows(0)("SDEPOSITLINE") > CDbl(v_strDEPOSITLIMIT) Then
                        Return ERR_CF_OVER_DEPOSITLIMIT
                    End If
                End If
                If Not (IsDBNull(v_ds.Tables(0).Rows(0)("STRADELINE"))) Then
                    If v_ds.Tables(0).Rows(0)("STRADELINE") > CDbl(v_strTRADELIMIT) Then
                        Return ERR_CF_OVER_TRADELIMIT
                    End If
                End If
            End If



        Catch ex As Exception
            Throw ex
        End Try



    End Function
    Private Function CloseContract(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CF.Trans.CloseContract", v_strErrorMessage As String
        Dim v_strSQL As String = String.Empty
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE As Double
            Dim v_strAFACCTNO As String
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_ds As DataSet
            Dim v_dblSumCI As Double
            Dim v_dblSumSE As Double
            Dim v_roundValue As Integer
            Dim v_strStatus As String
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False
            'Ä?á»?c ná»™i dung giao dá»‹ch
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If

                    Select Case v_strFLDCD
                        Case "03" 'AFACCTNO
                            v_strAFACCTNO = v_strVALUE
                    End Select
                End With
            Next
            If v_blnReversal Then 'Náº¿u há»£p Ä‘á»“ng Ä‘ang Ä‘Ã³ng thÃ¬ active láº¡i há»£p Ä‘á»“ng
                v_strSQL = "select STATUS from AFMAST where ACCTNO='" & v_strAFACCTNO & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_strStatus = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("STATUS")), vbNullString, v_ds.Tables(0).Rows(0)("STATUS"))
                    If v_strStatus <> "C" Then
                        v_lngErrCode = ERR_CF_AFMAST_STATUS_INVALIDE
                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                     & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                     & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                        Return v_lngErrCode
                    End If
                Else
                    'Tráº£ vá»? mÃ£ lá»—i loáº¡i hÃ¬nh há»£p Ä‘á»“ng khÃ´ng tá»“n táº¡i
                    v_lngErrCode = ERR_CF_AFMAST_NOTFOUND
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If
                'ThÃ´i Ä?Ã³ng há»£p Ä‘á»“ng CI
                v_strSQL = "UPDATE CIMAST SET STATUS='A',PSTATUS=PSTATUS || STATUS,LASTDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') WHERE AFACCTNO='" & v_strAFACCTNO & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                'ThÃ´i Ä?Ã³ng há»£p Ä‘á»“ng SE
                v_strSQL = "UPDATE SEMAST SET STATUS='A',PSTATUS=PSTATUS || STATUS,LASTDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') WHERE AFACCTNO='" & v_strAFACCTNO & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                'ThÃ´i Ä?Ã³ng há»£p Ä‘á»“ng AF
                v_strSQL = "UPDATE AFMAST SET STATUS='A',PSTATUS=PSTATUS || STATUS,LASTDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') WHERE ACCTNO='" & v_strAFACCTNO & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            Else 'Thá»±c hiá»‡n kiá»ƒm tra xem cÃ³ Ä‘Ã³ng Ä‘Æ°á»£c há»£p Ä‘á»“ng hay khÃ´ng
                'Kiá»ƒm tra tÃ i khoáº£n CI,SE cÃ³ Ä‘Æ°á»£c phÃ©p Ä‘Ã³ng
                v_strSQL = "select SUMCI,SUMSE, AF.STATUS from " &
                            " (Select (BALANCE+ODAMT+CRINTACR+ODINTACR+AAMT+RAMT+BAMT+NAMT+EMKAMT+MMARGINBAL+MARGINBAL+ADINTACR + HOLDBALANCE + PENDINGHOLD +PENDINGUNHOLD)SUMCI from cimast where AFACCTNO='" & v_strAFACCTNO & "')CI," &
                            " (Select SUM(TRADE+MORTAGE+MARGIN+NETTING+STANDING+SECURED+WITHDRAW+DEPOSIT+LOAN+BLOCKED+REPO+PENDING+TRANSFER) SUMSE from semast where AFACCTNO='" & v_strAFACCTNO & "')SE," &
                            " AFMAST AF " &
                            " where ACCTNO='" & v_strAFACCTNO & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_strStatus = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("STATUS")), vbNullString, v_ds.Tables(0).Rows(0)("STATUS"))
                    v_dblSumCI = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("SUMCI"))
                    v_dblSumSE = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("SUMSE"))
                    If v_strStatus <> "A" Then
                        v_lngErrCode = ERR_CF_AFMAST_STATUS_INVALIDE
                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                     & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                     & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                        Return v_lngErrCode
                    End If
                    v_strSQL = "SELECT VARVALUE FROM  SYSVAR WHERE GRNAME ='SYSTEM' AND VARNAME ='ROUND_VALUE'"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count > 0 Then
                        v_roundValue = v_ds.Tables(0).Rows(0)("VARVALUE")
                    Else
                        v_roundValue = 0
                    End If
                    If v_dblSumSE > 0 Or (v_dblSumCI > v_roundValue) Then
                        v_lngErrCode = ERR_CF_CANNOT_CLOSE
                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                     & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                     & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                        Return v_lngErrCode
                    End If
                Else
                    'Tráº£ vá»? mÃ£ lá»—i loáº¡i hÃ¬nh há»£p Ä‘á»“ng khÃ´ng tá»“n táº¡i
                    v_lngErrCode = ERR_CF_AFMAST_NOTFOUND
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If

                'Ä?Ã³ng há»£p Ä‘á»“ng CI
                v_strSQL = "UPDATE CIMAST SET STATUS='C',PSTATUS=PSTATUS || STATUS,LASTDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') WHERE AFACCTNO='" & v_strAFACCTNO & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                'Ä?Ã³ng há»£p Ä‘á»“ng SE
                v_strSQL = "UPDATE SEMAST SET STATUS='C',PSTATUS=PSTATUS || STATUS,LASTDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') WHERE AFACCTNO='" & v_strAFACCTNO & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                'Ä?Ã³ng há»£p Ä‘á»“ng AF
                v_strSQL = "UPDATE AFMAST SET STATUS='C',PSTATUS=PSTATUS || STATUS,LASTDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') WHERE ACCTNO='" & v_strAFACCTNO & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                'Bat check 
                If Len(Trim(Replace(v_strOVRRQD, OVRRQS_CHECKER_CONTROL, vbNullString))) > 0 And Len(v_strCHKID) = 0 Then
                    v_lngErrCode = ERR_SA_CHECKER1_OVR
                Else
                    If InStr(v_strOVRRQD, OVRRQS_CHECKER_CONTROL) > 0 And Len(v_strOFFID) = 0 Then
                        v_lngErrCode = ERR_SA_CHECKER2_OVR
                    End If
                End If
                If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode
            End If
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function OpenContract(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CF.Trans.OpenContract", v_strErrorMessage As String
        Dim v_strSQL As String = String.Empty
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE As Double
            Dim v_strCUSTID, v_strACTYPE, v_strAPPLID, v_strAUTOOPEN, v_strDESC, v_strSTMCYCLE, v_strISOTC, v_strCorebank, v_strCONSULTANT As String
            Dim v_dblMARGINLIMIT, v_dblREPOLIMIT, v_dblADVANCELIMIT, v_dblDEPOSITLIMIT, v_dblTRADELIMIT, v_dblTRADERATE, v_dblDEPORATE, v_dblMISCRATE,
                v_dblFLOORLIMIT, v_dblBRANCHLIMIT, v_dblTELELIMIT, v_dblONLINELIMIT, v_dblBRATIO, v_dblCFTELELIMIT, v_dblCFONLINELIMIT As Double
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False

            'Ä?á»?c ná»™i dung giao dá»‹ch
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If

                    Select Case v_strFLDCD
                        Case "01" 'CFID
                            v_strCUSTID = v_strVALUE
                        Case "02" 'ACTYPE
                            v_strACTYPE = v_strVALUE
                        Case "03" 'APPLID
                            v_strAPPLID = v_strVALUE
                        Case "10" 'MARGINLIMIT
                            v_dblMARGINLIMIT = v_dblVALUE
                        Case "11" 'REPOLI MIT                                         
                            v_dblREPOLIMIT = v_dblVALUE
                        Case "12" 'ADVANCELIMIT                                      
                            v_dblADVANCELIMIT = v_dblVALUE
                        Case "13" 'DEPOSITLIMIT                                      
                            v_dblDEPOSITLIMIT = v_dblVALUE
                        Case "14" 'TRADELIMIT                                      
                            v_dblTRADELIMIT = v_dblVALUE
                        Case "16" 'TELELIMIT
                            v_dblTELELIMIT = v_dblVALUE
                        Case "17" 'ONLINELIMIT
                            v_dblONLINELIMIT = v_dblVALUE
                        Case "18" 'BRATIO                                      
                            v_dblBRATIO = v_dblVALUE
                        Case "19" 'CFTELELIMIT                                      
                            v_dblCFTELELIMIT = v_dblVALUE
                        Case "20" 'CFONLINELIMIT                                      
                            v_dblCFONLINELIMIT = v_dblVALUE
                        Case "21" 'TRADERATE                                      
                            v_dblTRADERATE = v_dblVALUE
                        Case "22" 'DEPORATE                                      
                            v_dblDEPORATE = v_dblVALUE
                        Case "23" 'MISCRATE                                      
                            v_dblMISCRATE = v_dblVALUE
                        Case "31" 'AUTOOPEN                                       
                            v_strAUTOOPEN = v_strVALUE
                        Case "30" 'DESC                                              
                            v_strDESC = v_strVALUE
                    End Select
                End With
            Next

            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_ds As DataSet
            Dim v_dblCFMarginLimit, v_dblCFTradeLimit, v_dblCFAdvanceLimit, v_dblCFRepoLimit, v_dblCFDepositLimit As Double

            If v_blnReversal Then
                'Kiá»ƒm tra náº¿u Ä‘Ã£ cÃ³ giao dá»‹ch liÃªn quan Ä‘áº¿n há»£p Ä‘á»“ng thÃ¬ khÃ´ng Ä‘Æ°á»£c phÃ©p xoÃ¡
                v_strSQL = "SELECT DISTINCT TR.TXDATE, TR.TXNUM " & ControlChars.CrLf _
                    & "FROM TLLOG TL, AFTRAN TR, AFMAST MST WHERE TL.DELTD<>'Y' AND (TL.TXSTATUS=1 OR TL.TXSTATUS=3) " & ControlChars.CrLf _
                    & "AND TL.TXNUM=TR.TXNUM AND TL.TXDATE=TR.TXDATE AND TR.ACCTNO=MST.ACCTNO AND MST.ACCTNO = '" & v_strAPPLID & "' " & ControlChars.CrLf _
                    & "UNION ALL " & ControlChars.CrLf _
                    & "SELECT DISTINCT TR.TXDATE, TR.TXNUM " & ControlChars.CrLf _
                    & "FROM TLLOG TL, SETRAN TR, SEMAST MST WHERE TL.DELTD<>'Y' AND (TL.TXSTATUS=1 OR TL.TXSTATUS=3)  " & ControlChars.CrLf _
                    & "AND TL.TXNUM=TR.TXNUM AND TL.TXDATE=TR.TXDATE AND TR.ACCTNO=MST.ACCTNO AND MST.AFACCTNO = '" & v_strAPPLID & "' " & ControlChars.CrLf _
                    & "UNION ALL " & ControlChars.CrLf _
                    & "SELECT DISTINCT TR.TXDATE, TR.TXNUM " & ControlChars.CrLf _
                    & "FROM TLLOG TL, CITRAN TR, CIMAST MST WHERE TL.DELTD<>'Y' AND (TL.TXSTATUS=1 OR TL.TXSTATUS=3)  " & ControlChars.CrLf _
                    & "AND TL.TXNUM=TR.TXNUM AND TL.TXDATE=TR.TXDATE AND TR.ACCTNO=MST.ACCTNO AND MST.AFACCTNO = '" & v_strAPPLID & "' "
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    'Tráº£ vá»? mÃ£ lá»—i khÃ´ng xoÃ¡ Ä‘Æ°á»£c há»£p Ä‘á»“ng khi Ä‘Ã£ cÃ³ giao dá»‹ch phÃ¡t sinh 
                    'trong cÃ¡c há»£p Ä‘á»“ng liÃªn quan
                    v_lngErrCode = ERR_CF_CONTRACT_HAS_TRANSACTION
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                Else
                    'Thá»±c hiá»‡n xoÃ¡ giao dá»‹ch
                    v_strSQL = "DELETE FROM AFMAST WHERE TRIM(ACCTNO)='" & v_strAPPLID & "'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    v_strSQL = "DELETE FROM CIMAST WHERE TRIM(AFACCTNO)='" & v_strAPPLID & "'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    v_strSQL = "DELETE FROM SEMAST WHERE TRIM(AFACCTNO)='" & v_strAPPLID & "'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                End If
            Else

                'Kiá»ƒm tra mÃ£ loáº¡i hÃ¬nh há»£p Ä‘á»“ng cÃ³ tá»“n táº¡i khÃ´ng
                Dim v_strAFTYPE, v_strIFRULECD, v_strAPPROVECD, v_strLINETIED, v_strCITYPE, v_strSETYPE As String
                v_strSQL = "SELECT * FROM AFTYPE WHERE STATUS='Y' AND ACTYPE='" & v_strACTYPE & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    'Láº¥y cÃ¡c thÃ´ng tin cáº§n thiáº¿t Ä‘á»ƒ má»Ÿ há»£p Ä‘á»“ng
                    v_strAFTYPE = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("AFTYPE")), vbNullString, v_ds.Tables(0).Rows(0)("AFTYPE"))
                    v_strIFRULECD = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("IFRULECD")), vbNullString, v_ds.Tables(0).Rows(0)("IFRULECD"))
                    v_strAPPROVECD = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("APPROVECD")), vbNullString, v_ds.Tables(0).Rows(0)("APPROVECD"))
                    v_strLINETIED = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("LINETIED")), vbNullString, v_ds.Tables(0).Rows(0)("LINETIED"))
                    v_strCITYPE = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("CITYPE")), vbNullString, v_ds.Tables(0).Rows(0)("CITYPE"))
                    v_strSETYPE = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("SETYPE")), vbNullString, v_ds.Tables(0).Rows(0)("SETYPE"))
                    v_strSTMCYCLE = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("STMCYCLE")), vbNullString, v_ds.Tables(0).Rows(0)("STMCYCLE"))
                    v_strISOTC = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("ISOTC")), vbNullString, v_ds.Tables(0).Rows(0)("ISOTC"))
                    v_strCONSULTANT = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("CONSULTANT")), vbNullString, v_ds.Tables(0).Rows(0)("CONSULTANT"))
                    v_strCorebank = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("CONSULTANT")), vbNullString, v_ds.Tables(0).Rows(0)("COREBANK"))


                    'Kiá»ƒm tra cÃ¡c háº¡n má»©c Ä‘Æ°á»£c má»Ÿ cÃ³ phÃ¹ há»£p vá»›i loÃ i hÃ¬nh khÃ´ng
                    Dim v_dblTYPEFLOORLIMIT, v_dblTYPEBRANCHLIMIT, v_dblTYPETELELIMIT, v_dblTYPEONLINELIMIT, v_dblTYPEMARGINLINE,
                        v_dblTYPEREPOLINE, v_dblTYPEADVANCEDLINE, v_dblTYPEBRATIO, v_dblTYPEDEPOSITLINE As Long
                    Dim v_dblTYPETRADERATE, v_dblTYPEDEPORATE, v_dblTYPEMISCRATE As Double
                    v_dblTYPEFLOORLIMIT = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("FLOORLIMIT"))
                    v_dblTYPEBRANCHLIMIT = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("BRANCHLIMIT"))
                    v_dblTYPETELELIMIT = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("TELELIMIT"))
                    v_dblTYPEONLINELIMIT = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("ONLINELIMIT"))
                    v_dblTYPEMARGINLINE = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("MARGINLINE"))
                    v_dblTYPEREPOLINE = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("REPOLINE"))
                    v_dblTYPEADVANCEDLINE = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("ADVANCEDLINE"))
                    v_dblTYPEBRATIO = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("BRATIO"))
                    v_dblTYPEDEPOSITLINE = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("DEPOSITLINE"))
                    v_dblTYPETRADERATE = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("TRADERATE"))
                    v_dblTYPEDEPORATE = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("DEPORATE"))
                    v_dblTYPEMISCRATE = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("MISCRATE"))
                    If v_dblTYPEBRATIO > v_dblBRATIO Then
                        'Tráº£ vá»? mÃ£ lá»—i cÃ¡c tham sá»‘ rá»§i ro cá»§a há»£p Ä‘á»“ng vÆ°á»£t quÃ¡ loáº¡i hÃ¬nh
                        v_lngErrCode = ERR_CF_AFMAST_RISKOVER_AFTYPE
                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                     & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                     & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                        Return v_lngErrCode
                    End If
                    If v_dblTYPETRADERATE < v_dblTRADERATE Then
                        'Tráº£ vá»? mÃ£ lá»—i tá»‰ lá»‡ kháº¥u trá»« phÃ­ giao dá»‹ch cá»§a há»£p Ä‘á»“ng vÆ°á»£t quÃ¡ loáº¡i hÃ¬nh
                        v_lngErrCode = ERR_CF_AFMAST_TRADERATE_OVER_AFTYPE
                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                     & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                     & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                        Return v_lngErrCode
                    End If
                    If v_dblTYPEDEPORATE < v_dblDEPORATE Then
                        'Tráº£ vá»? mÃ£ lá»—i tá»‰ lá»‡ kháº¥u trá»« phÃ­ giao dá»‹ch cá»§a há»£p Ä‘á»“ng vÆ°á»£t quÃ¡ loáº¡i hÃ¬nh
                        v_lngErrCode = ERR_CF_AFMAST_DEPORATE_OVER_AFTYPE
                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                     & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                     & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                        Return v_lngErrCode
                    End If
                    If v_dblTYPEMISCRATE < v_dblMISCRATE Then
                        'Tráº£ vá»? mÃ£ lá»—i tá»‰ lá»‡ kháº¥u trá»« phÃ­ giao dá»‹ch cá»§a há»£p Ä‘á»“ng vÆ°á»£t quÃ¡ loáº¡i hÃ¬nh
                        v_lngErrCode = ERR_CF_AFMAST_MISCRATE_OVER_AFTYPE
                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                     & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                     & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                        Return v_lngErrCode
                    End If
                Else
                    'Tráº£ vá»? mÃ£ lá»—i loáº¡i hÃ¬nh há»£p Ä‘á»“ng khÃ´ng tá»“n táº¡i
                    v_lngErrCode = ERR_CF_AFTYPE_NOTFOUND
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If

                'Kiá»ƒm tra mÃ£ há»£p Ä‘á»“ng Ä‘Ã£ tá»“n táº¡i chÆ°a
                v_strSQL = "SELECT * FROM AFMAST WHERE ACCTNO='" & v_strAPPLID & "'"

                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    'Tráº£ vá»? mÃ£ lá»—i loáº¡i hÃ¬nh há»£p Ä‘á»“ng khÃ´ng tá»“n táº¡i
                    v_lngErrCode = ERR_CF_AFMAST_ALREADY_EXIST

                    'Kiem tra neu trung sequence thi tra ve loi                     
                    'Dim v_strCheckSequency As String = "SELECT SEQ_AFMAST.CURRVAL FROM DUAL"
                    'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strCheckSequency)
                    'If gf_CorrectNumericField(v_ds.Tables(0).Rows(0)(0)).ToString.Equals(v_strAPPLID) Then
                    '    'Return loi trung seq
                    'Else
                    '    v_lngErrCode = ERR_CF_AFMAST_ALREADY_EXIST
                    'End If

                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If

                'Kiá»ƒm tra mÃ£ há»£p Ä‘á»“ng CI Ä‘Ã£ tá»“n táº¡i chÆ°a
                v_strSQL = "SELECT * FROM CIMAST WHERE ACCTNO='" & v_strAPPLID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    'Tráº£ vá»? mÃ£ lá»—i loáº¡i hÃ¬nh há»£p Ä‘á»“ng khÃ´ng tá»“n táº¡i
                    v_lngErrCode = ERR_CI_CIMAST_ALREADY_EXIST
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If

                'Kiá»ƒm tra mÃ£ khÃ¡ch hÃ ng cÃ³ tá»“n táº¡i khÃ´ng
                Dim v_strLANGUAGE, v_strBANKACCOUNT, v_strBANKCODE, v_strEMAIL, v_strFAX, v_strPHONE, v_strADDRESS, v_strSTATUS As String
                v_strSQL = "SELECT * FROM CFMAST WHERE CUSTID='" & v_strCUSTID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    'Láº¥y cÃ¡c thÃ´ng tin cáº§n thiáº¿t Ä‘á»ƒ má»Ÿ há»£p Ä‘á»“ng
                    v_dblCFMarginLimit = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("MARGINLIMIT")), 0, v_ds.Tables(0).Rows(0)("MARGINLIMIT"))
                    v_dblCFTradeLimit = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("TRADELIMIT")), 0, v_ds.Tables(0).Rows(0)("TRADELIMIT"))
                    v_dblCFAdvanceLimit = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("ADVANCELIMIT")), 0, v_ds.Tables(0).Rows(0)("ADVANCELIMIT"))
                    v_dblCFRepoLimit = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("REPOLIMIT")), 0, v_ds.Tables(0).Rows(0)("REPOLIMIT"))
                    v_dblCFDepositLimit = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("DEPOSITLIMIT")), 0, v_ds.Tables(0).Rows(0)("DEPOSITLIMIT"))
                    v_strLANGUAGE = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("LANGUAGE")), vbNullString, v_ds.Tables(0).Rows(0)("LANGUAGE"))
                    v_strBANKACCOUNT = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("BANKACCTNO")), vbNullString, v_ds.Tables(0).Rows(0)("BANKACCTNO"))
                    v_strBANKCODE = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("BANKCODE")), vbNullString, v_ds.Tables(0).Rows(0)("BANKCODE"))
                    v_strEMAIL = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("EMAIL")), vbNullString, v_ds.Tables(0).Rows(0)("EMAIL"))
                    v_strFAX = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("FAX")), vbNullString, v_ds.Tables(0).Rows(0)("FAX"))
                    v_strPHONE = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("PHONE")), vbNullString, v_ds.Tables(0).Rows(0)("PHONE"))
                    v_strADDRESS = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("ADDRESS")), vbNullString, v_ds.Tables(0).Rows(0)("ADDRESS"))
                    v_strADDRESS = Replace(v_strADDRESS, "'", "''")
                    v_strSTATUS = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("STATUS")), vbNullString, v_ds.Tables(0).Rows(0)("STATUS"))
                    If v_strSTATUS <> "A" Then
                        'Tráº£ vá»? mÃ£ lá»—i vá»? tráº¡ng thÃ¡i khÃ¡ch hÃ ng
                        v_lngErrCode = ERR_INVALID_CFMAST_STATUS
                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                     & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                     & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                        Return v_lngErrCode
                    End If
                Else
                    'Tráº£ vá»? mÃ£ lá»—i khÃ¡ch hÃ ng khÃ´ng tá»“n táº¡i
                    v_lngErrCode = ERR_CF_CUSTOMER_NOTFOUND
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If

                'Kiá»ƒm tra khach hang da co hop Ä‘á»“ng individual nao chÆ°a
                If v_strAFTYPE = "001" Then 'loai hinh individual
                    v_strSQL = "SELECT * FROM AFMAST WHERE CUSTID='" & v_strCUSTID & "' AND AFTYPE='001'"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count > 0 Then
                        'Tráº£ vá»? mÃ£ lá»—i da co hop Ä‘á»“ng individual
                        v_lngErrCode = ERR_CF_ACTYPE_HAS_CONTRACT
                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                     & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                     & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                        Return v_lngErrCode
                    End If
                End If
                'Kiá»ƒm tra cÃ¡c háº¡n má»©c há»£p Ä‘á»“ng cÃ³ phÃ¹ há»£p khÃ´ng
                v_strSQL = "SELECT SUM(AF.MARGINLINE) MARGIN, SUM(AF.TRADELINE) TRADE, SUM(AF.ADVANCELINE) ADVANCE, SUM(AF.REPOLINE) REPO, SUM(AF.DEPOSITLINE) DEPOSIT " _
                    & " FROM AFMAST AF WHERE CUSTID='" & v_strCUSTID & "' AND ACCTNO <> '" & v_strAPPLID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    'Láº¥y cÃ¡c thÃ´ng tin cáº§n thiáº¿t Ä‘á»ƒ má»Ÿ há»£p Ä‘á»“ng
                    If v_dblCFMarginLimit < IIf(IsDBNull(v_ds.Tables(0).Rows(0)("MARGIN")), 0, v_ds.Tables(0).Rows(0)("MARGIN")) + v_dblMARGINLIMIT Then
                        v_lngErrCode = ERR_CF_AFMAST_OVER_MARGINLIMIT
                        v_strOVRRQD = v_strOVRRQD & OVRRQS_MARGINLIMIT
                    End If

                    If v_dblCFTradeLimit < IIf(IsDBNull(v_ds.Tables(0).Rows(0)("TRADE")), 0, v_ds.Tables(0).Rows(0)("TRADE")) + v_dblTRADELIMIT Then
                        v_lngErrCode = ERR_CF_AFMAST_OVER_TRADELIMIT
                        v_strOVRRQD = v_strOVRRQD & OVRRQS_TRADELIMIT
                    End If

                    If v_dblCFAdvanceLimit < IIf(IsDBNull(v_ds.Tables(0).Rows(0)("ADVANCE")), 0, v_ds.Tables(0).Rows(0)("ADVANCE")) + v_dblADVANCELIMIT Then
                        v_lngErrCode = ERR_CF_AFMAST_OVER_ADVANCELIMIT
                        v_strOVRRQD = v_strOVRRQD & OVRRQS_ADVANCELIMIT
                    End If

                    If v_dblCFRepoLimit < IIf(IsDBNull(v_ds.Tables(0).Rows(0)("REPO")), 0, v_ds.Tables(0).Rows(0)("REPO")) + v_dblREPOLIMIT Then
                        v_lngErrCode = ERR_CF_AFMAST_OVER_REPOLIMIT
                        v_strOVRRQD = v_strOVRRQD & OVRRQS_REPOLIMIT
                    End If

                    If v_dblCFDepositLimit < IIf(IsDBNull(v_ds.Tables(0).Rows(0)("DEPOSIT")), 0, v_ds.Tables(0).Rows(0)("DEPOSIT")) + v_dblDEPOSITLIMIT Then
                        v_lngErrCode = ERR_CF_AFMAST_OVER_DEPOSITLIMIT
                        v_strOVRRQD = v_strOVRRQD & OVRRQS_DEPOSITLIMIT
                    End If

                    'Tráº£ vá»? mÃ£ lá»—i vÆ°á»£t háº¡n má»©c
                    If v_lngErrCode <> ERR_SYSTEM_OK Then
                        'VÆ°á»£t háº¡n má»©c sáº½ do checker 1 duyá»‡t
                        pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value = v_strOVRRQD
                        v_lngErrCode = ERR_SYSTEM_OK
                    End If
                End If

                'Kiá»ƒm tra cÃ¡c Ä‘iá»?u kiá»‡n vá»? duyá»‡t giao dá»‹ch
                'Xá»­ lÃ½ tráº£ vá»? nguyÃªn nhÃ¢n duyá»‡t
                If Len(Trim(Replace(v_strOVRRQD, OVRRQS_CHECKER_CONTROL, vbNullString))) > 0 And Len(v_strCHKID) = 0 Then
                    v_lngErrCode = ERR_SA_CHECKER1_OVR
                Else
                    If InStr(v_strOVRRQD, OVRRQS_CHECKER_CONTROL) > 0 And Len(v_strOFFID) = 0 Then
                        v_lngErrCode = ERR_SA_CHECKER2_OVR
                    End If
                End If
                If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode

                'Má»Ÿ tÃ i khoáº£n CI cho há»£p Ä‘á»“ng
                Dim v_strCIACCTNO, v_strCCYCD, v_strICCFCD, v_strICCFTIED As String
                Dim v_dblMINBAL As Long
                v_strSQL = "SELECT * FROM CITYPE WHERE STATUS='Y' AND ACTYPE='" & v_strCITYPE & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    'Láº¥y cÃ¡c thÃ´ng tin cáº§n thiáº¿t Ä‘á»ƒ má»Ÿ há»£p Ä‘á»“ng
                    v_strCCYCD = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("CCYCD")), vbNullString, v_ds.Tables(0).Rows(0)("CCYCD"))
                    v_strICCFCD = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("ICCFCD")), vbNullString, v_ds.Tables(0).Rows(0)("ICCFCD"))
                    v_strICCFTIED = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("ICCFTIED")), vbNullString, v_ds.Tables(0).Rows(0)("ICCFTIED"))
                    'v_strCIACCTNO = v_strAPPLID & v_strCITYPE & v_strCCYCD
                    v_strCIACCTNO = v_strAPPLID
                    v_dblMINBAL = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("MINBAL"))
                    'Má»Ÿ tÃ i khoáº£n CI. Sáº½ dÃ¹ng lá»‡nh SQL má»Ÿ trá»±c tiáº¿p á»Ÿ Ä‘Ã¢y luÃ´n

                    'Má»Ÿ tÃ i khoáº£n CI
                    v_strSQL = "INSERT INTO CIMAST (ACTYPE,CUSTID,ACCTNO,CCYCD,AFACCTNO,OPNDATE," & ControlChars.CrLf _
                                            & "LASTDATE,STATUS,BALANCE,CRAMT,DRAMT," & ControlChars.CrLf _
                                            & "CRINTACR,ODINTACR,AVRBAL,MDEBIT,MCREDIT," & ControlChars.CrLf _
                                            & "AAMT,BAMT,EMKAMT,MMARGINBAL,MARGINBAL,CRINTDT," & ControlChars.CrLf _
                                            & "ODINTDT,RAMT,ICCFCD,ICCFTIED,ODLIMIT,MINBAL,COREBANK,MCRINTDT)" & ControlChars.CrLf _
                            & "VALUES ('" & v_strCITYPE & "','" & v_strCUSTID & "','" & v_strCIACCTNO & "','" & v_strCCYCD & "','" & v_strAPPLID & "',TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')," & ControlChars.CrLf _
                                            & "TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'" & v_strAPPROVECD & "',0,0,0," & ControlChars.CrLf _
                                            & "0,0,0,0,0,0,0,0,0,0,TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),0,'" & v_strICCFCD & "','" & v_strICCFTIED & "',0," & v_dblMINBAL & ",'" & v_strCorebank & "', TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') )"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                Else
                    'Tráº£ vá»? mÃ£ lá»—i loáº¡i hÃ¬nh há»£p Ä‘á»“ng khÃ´ng tá»“n táº¡i
                    v_lngErrCode = ERR_CF_AFTYPE_NOTFOUND
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If

                'Má»Ÿ tÃ i khoáº£n SE cho há»£p Ä‘á»“ng
                If v_strAUTOOPEN = "Y" Then
                    'Má»Ÿ tÃ i khoáº£n SE
                    v_strSQL = "INSERT INTO SEMAST (ACTYPE,CUSTID,ACCTNO,CODEID,AFACCTNO," & ControlChars.CrLf _
                                            & "OPNDATE,LASTDATE,COSTDT,TBALDT,STATUS,IRTIED,IRCD," & ControlChars.CrLf _
                                            & "COSTPRICE,TRADE,MORTAGE,MARGIN,NETTING," & ControlChars.CrLf _
                                            & "STANDING,WITHDRAW,DEPOSIT,LOAN) " & ControlChars.CrLf _
                                & "SELECT '" & v_strSETYPE & "','" & v_strCUSTID & "','" & v_strAPPLID & "' || TRIM(CCY.CODEID), TRIM(CCY.CODEID),'" & v_strAPPLID & "'," & ControlChars.CrLf _
                                & "TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')," & ControlChars.CrLf _
                                & "'A','Y',TYP.IRCD," & ControlChars.CrLf _
                                & "0,0,0,0,0,0,0,0,0 " & ControlChars.CrLf _
                                & "FROM SETYPE TYP, SBSECURITIES CCY WHERE TYP.STATUS='Y' AND CCY.STATUS='Y' AND TYP.ACTYPE='" & v_strSETYPE & "'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                End If

                'Táº¡o PIN cá»§a há»£p Ä‘á»“ng
                Dim strPIN As String
                strPIN = gf_GeneratePIN()

                'Má»Ÿ má»›i há»£p Ä‘á»“ng 
                v_strSQL = "INSERT INTO AFMAST (ACTYPE,CUSTID,ACCTNO,AFTYPE,TERMOFUSE," & ControlChars.CrLf _
                                        & "TRADEFLOOR,TRADETELEPHONE,TRADEONLINE,PIN,LANGUAGE," & ControlChars.CrLf _
                                        & "TRADEPHONE,ALLOWDEBIT,BANKACCTNO,SWIFTCODE,BANKNAME," & ControlChars.CrLf _
                                        & "RECEIVEVIA,EMAIL,ADDRESS,FAX,CIACCTNO,IFRULECD," & ControlChars.CrLf _
                                        & "TELELIMIT,ONLINELIMIT,CFTELELIMIT,CFONLINELIMIT," & ControlChars.CrLf _
                                        & "MARGINLINE,TRADELINE,ADVANCELINE,REPOLINE,DEPOSITLINE,BRATIO,TRADERATE,DEPORATE,MISCRATE," & ControlChars.CrLf _
                                        & "LASTDATE,STATUS,STMCYCLE,ISOTC,CONSULTANT,DESCRIPTION,COREBANK, OPNDATE) " & ControlChars.CrLf _
                            & "VALUES ('" & v_strACTYPE & "','" & v_strCUSTID & "','" & v_strAPPLID & "','" & v_strAFTYPE & "','001'," & ControlChars.CrLf _
                                        & "'Y','Y','Y','" & strPIN & "','" & v_strLANGUAGE & "'," & ControlChars.CrLf _
                                        & "'" & v_strPHONE & "','N','" & v_strBANKACCOUNT & "','','" & v_strBANKCODE & "','D'," & ControlChars.CrLf _
                                        & "'" & v_strEMAIL & "','" & v_strADDRESS & "','" & v_strFAX & "','" & v_strCIACCTNO & "','" & v_strIFRULECD & "'," & ControlChars.CrLf _
                                        & v_dblTELELIMIT & "," & v_dblONLINELIMIT & "," & v_dblCFTELELIMIT & "," & v_dblCFONLINELIMIT & "," & ControlChars.CrLf _
                                        & v_dblMARGINLIMIT & "," & v_dblTRADELIMIT & "," & v_dblADVANCELIMIT & "," & v_dblREPOLIMIT & "," & v_dblREPOLIMIT & "," & v_dblBRATIO & "," & v_dblTRADERATE & "," & v_dblDEPORATE & "," & v_dblMISCRATE & "," & ControlChars.CrLf _
                                        & "TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'" & v_strAPPROVECD & "','" & v_strSTMCYCLE & "','" & v_strISOTC & "','" & v_strCONSULTANT & "','" & v_strDESC & "' ,'" & v_strCorebank & "', TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'))"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End If
            'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function ApproveContract(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CF.Trans.ApproveContract", v_strErrorMessage As String
        Dim v_strSQL As String = String.Empty
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE As Double
            Dim v_strCUSTID, v_strACTYPE, v_strAPPLID, v_strAUTOOPEN, v_strDESC, v_strSTMCYCLE, v_strISOTC, v_strCONSULTANT As String
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False

            'Láº¥y tÃ i khoáº£n
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If
                    Select Case v_strFLDCD
                        Case "03" 'ACCTNO
                            v_strAPPLID = v_strVALUE
                        Case "01" 'CFID
                            v_strCUSTID = v_strVALUE
                        Case "02" 'ACTYPE
                            v_strACTYPE = v_strVALUE
                    End Select
                End With
            Next

            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_ds As DataSet
            If v_blnReversal Then
                'Kiá»ƒm tra náº¿u Ä‘Ã£ cÃ³ giao dá»‹ch liÃªn quan Ä‘áº¿n há»£p Ä‘á»“ng thÃ¬ khÃ´ng Ä‘Æ°á»£c phÃ©p xoÃ¡
                v_strSQL = "SELECT DISTINCT TR.TXDATE, TR.TXNUM " & ControlChars.CrLf _
                    & "FROM TLLOG TL, AFTRAN TR, AFMAST MST WHERE TL.DELTD<>'Y' AND (TL.TXSTATUS=1 OR TL.TXSTATUS=3) " & ControlChars.CrLf _
                    & "AND TL.TXNUM=TR.TXNUM AND TL.TXDATE=TR.TXDATE AND TR.ACCTNO=MST.ACCTNO AND MST.ACCTNO = '" & v_strAPPLID & "' " & ControlChars.CrLf _
                    & "UNION ALL " & ControlChars.CrLf _
                    & "SELECT DISTINCT TR.TXDATE, TR.TXNUM " & ControlChars.CrLf _
                    & "FROM TLLOG TL, SETRAN TR, SEMAST MST WHERE TL.DELTD<>'Y' AND (TL.TXSTATUS=1 OR TL.TXSTATUS=3)  " & ControlChars.CrLf _
                    & "AND TL.TXNUM=TR.TXNUM AND TL.TXDATE=TR.TXDATE AND TR.ACCTNO=MST.ACCTNO AND MST.AFACCTNO = '" & v_strAPPLID & "' " & ControlChars.CrLf _
                    & "UNION ALL " & ControlChars.CrLf _
                    & "SELECT DISTINCT TR.TXDATE, TR.TXNUM " & ControlChars.CrLf _
                    & "FROM TLLOG TL, CITRAN TR, CIMAST MST WHERE TL.DELTD<>'Y' AND (TL.TXSTATUS=1 OR TL.TXSTATUS=3)  " & ControlChars.CrLf _
                    & "AND TL.TXNUM=TR.TXNUM AND TL.TXDATE=TR.TXDATE AND TR.ACCTNO=MST.ACCTNO AND MST.AFACCTNO = '" & v_strAPPLID & "' "
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    'Tráº£ vá»? mÃ£ lá»—i khÃ´ng xoÃ¡ Ä‘Æ°á»£c há»£p Ä‘á»“ng khi Ä‘Ã£ cÃ³ giao dá»‹ch phÃ¡t sinh 
                    'trong cÃ¡c há»£p Ä‘á»“ng liÃªn quan
                    v_lngErrCode = ERR_CF_CONTRACT_HAS_TRANSACTION
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                Else
                    'Thá»±c hiá»‡n xoÃ¡ giao dá»‹ch
                    v_strSQL = "UPDATE AFMAST SET STATUS='P' WHERE TRIM(ACCTNO)='" & v_strAPPLID & "'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    v_strSQL = "DELETE FROM CIMAST WHERE TRIM(AFACCTNO)='" & v_strAPPLID & "'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    v_strSQL = "DELETE FROM SEMAST WHERE TRIM(AFACCTNO)='" & v_strAPPLID & "'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                End If
            Else
                '---------check
                'Kiá»ƒm tra mÃ£ loáº¡i hÃ¬nh há»£p Ä‘á»“ng cÃ³ tá»“n táº¡i khÃ´ng
                Dim v_strAFTYPE, v_strCITYPE, v_strSETYPE, v_strMarginType, v_strcorebank As String
                v_strSQL = "SELECT AF.*,MR.MRTYPE MARGINTYPE FROM AFTYPE AF,MRTYPE MR WHERE AF.MRTYPE=MR.ACTYPE AND AF.STATUS='Y' AND AF.ACTYPE='" & v_strACTYPE & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    'Láº¥y cÃ¡c thÃ´ng tin cáº§n thiáº¿t Ä‘á»ƒ má»Ÿ há»£p Ä‘á»“ng
                    v_strAFTYPE = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("AFTYPE")), vbNullString, v_ds.Tables(0).Rows(0)("AFTYPE"))
                    v_strCITYPE = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("CITYPE")), vbNullString, v_ds.Tables(0).Rows(0)("CITYPE"))
                    v_strSETYPE = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("SETYPE")), vbNullString, v_ds.Tables(0).Rows(0)("SETYPE"))
                    v_strMarginType = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("MARGINTYPE")), vbNullString, v_ds.Tables(0).Rows(0)("MARGINTYPE"))
                    v_strcorebank = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("COREBANK")), vbNullString, v_ds.Tables(0).Rows(0)("COREBANK"))

                Else
                    'Tráº£ vá»? mÃ£ lá»—i loáº¡i hÃ¬nh há»£p Ä‘á»“ng khÃ´ng tá»“n táº¡i
                    v_lngErrCode = ERR_CF_AFTYPE_NOTFOUND
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If

                'Kiá»ƒm tra mÃ£ há»£p Ä‘á»“ng Ä‘Ã£ tá»“n táº¡i chÆ°a
                v_strSQL = "SELECT * FROM AFMAST WHERE ACCTNO='" & v_strAPPLID & "' AND STATUS ='A'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    'Tráº£ vá»? mÃ£ lá»—i loáº¡i hÃ¬nh há»£p Ä‘á»“ng khÃ´ng tá»“n táº¡i
                    v_lngErrCode = ERR_CF_ACCTNO_DUPLICATE
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If

                'Kiá»ƒm tra mÃ£ há»£p Ä‘á»“ng CI Ä‘Ã£ tá»“n táº¡i chÆ°a
                v_strSQL = "SELECT * FROM CIMAST WHERE ACCTNO='" & v_strAPPLID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    'Tráº£ vá»? mÃ£ lá»—i loáº¡i hÃ¬nh há»£p Ä‘á»“ng khÃ´ng tá»“n táº¡i
                    v_lngErrCode = ERR_CI_CIMAST_ALREADY_EXIST
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If

                'Kiá»ƒm tra mÃ£ khÃ¡ch hÃ ng cÃ³ tá»“n táº¡i khÃ´ng
                Dim v_strSTATUS As String
                v_strSQL = "SELECT * FROM CFMAST WHERE CUSTID='" & v_strCUSTID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    'Láº¥y cÃ¡c thÃ´ng tin cáº§n thiáº¿t Ä‘á»ƒ má»Ÿ há»£p Ä‘á»“ng
                    v_strSTATUS = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("STATUS")), vbNullString, v_ds.Tables(0).Rows(0)("STATUS"))
                    If v_strSTATUS <> "A" Then
                        'Tráº£ vá»? mÃ£ lá»—i vá»? tráº¡ng thÃ¡i khÃ¡ch hÃ ng
                        v_lngErrCode = ERR_INVALID_CFMAST_STATUS
                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                     & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                     & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                        Return v_lngErrCode
                    End If
                Else
                    'Tráº£ vá»? mÃ£ lá»—i khÃ¡ch hÃ ng khÃ´ng tá»“n táº¡i
                    v_lngErrCode = ERR_CF_CUSTOMER_NOTFOUND
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If

                'Má»Ÿ tÃ i khoáº£n CI cho há»£p Ä‘á»“ng
                Dim v_strCIACCTNO, v_strCCYCD, v_strICCFCD, v_strICCFTIED As String
                Dim v_dblMINBAL As Long
                'Láº¥y thÃ´ng tin loáº¡i hÃ¬nh CI vÃ  SE
                v_strSQL = "SELECT * FROM CITYPE WHERE STATUS='Y' AND ACTYPE='" & v_strCITYPE & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    'Láº¥y cÃ¡c thÃ´ng tin cáº§n thiáº¿t Ä‘á»ƒ má»Ÿ há»£p Ä‘á»“ng
                    v_strCCYCD = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("CCYCD")), vbNullString, v_ds.Tables(0).Rows(0)("CCYCD"))
                    v_strICCFCD = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("ICCFCD")), vbNullString, v_ds.Tables(0).Rows(0)("ICCFCD"))
                    v_strICCFTIED = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("ICCFTIED")), vbNullString, v_ds.Tables(0).Rows(0)("ICCFTIED"))
                    v_strCIACCTNO = v_strAPPLID
                    v_dblMINBAL = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("MINBAL"))
                    'Má»Ÿ tÃ i khoáº£n CI. Sáº½ dÃ¹ng lá»‡nh SQL má»Ÿ trá»±c tiáº¿p á»Ÿ Ä‘Ã¢y luÃ´n
                    'Má»Ÿ tÃ i khoáº£n CI
                    v_strSQL = "INSERT INTO CIMAST (ACTYPE,CUSTID,ACCTNO,CCYCD,AFACCTNO,OPNDATE," & ControlChars.CrLf _
                                            & "LASTDATE,STATUS,BALANCE,CRAMT,DRAMT," & ControlChars.CrLf _
                                            & "CRINTACR,ODINTACR,AVRBAL,MDEBIT,MCREDIT," & ControlChars.CrLf _
                                            & "AAMT,BAMT,EMKAMT,MMARGINBAL,MARGINBAL,CRINTDT," & ControlChars.CrLf _
                                            & "ODINTDT,RAMT,ICCFCD,ICCFTIED,ODLIMIT,MINBAL,COREBANK,MCRINTDT)" & ControlChars.CrLf _
                            & "VALUES ('" & v_strCITYPE & "','" & v_strCUSTID & "','" & v_strCIACCTNO & "','" & v_strCCYCD & "','" & v_strAPPLID & "',TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')," & ControlChars.CrLf _
                                            & "TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'A',0,0,0," & ControlChars.CrLf _
                                            & "0,0,0,0,0,0,0,0,0,0,TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),0,'" & v_strICCFCD & "','" & v_strICCFTIED & "',0," & v_dblMINBAL & ",'" & v_strcorebank & "', TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'))"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    '++++Hien tai khong can mo SE nua!++++++
                    'Má»Ÿ tÃ i khoáº£n SE
                    'v_strSQL = "INSERT INTO SEMAST (ACTYPE,CUSTID,ACCTNO,CODEID,AFACCTNO," & ControlChars.CrLf _
                    '                        & "OPNDATE,LASTDATE,COSTDT,TBALDT,STATUS,IRTIED,IRCD," & ControlChars.CrLf _
                    '                        & "COSTPRICE,TRADE,MORTAGE,MARGIN,NETTING," & ControlChars.CrLf _
                    '                        & "STANDING,WITHDRAW,DEPOSIT,LOAN) " & ControlChars.CrLf _
                    '            & "SELECT '" & v_strSETYPE & "','" & v_strCUSTID & "','" & v_strAPPLID & "' || TRIM(CCY.CODEID), TRIM(CCY.CODEID),'" & v_strAPPLID & "'," & ControlChars.CrLf _
                    '            & "TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')," & ControlChars.CrLf _
                    '            & "'A','Y',TYP.IRCD," & ControlChars.CrLf _
                    '            & "0,0,0,0,0,0,0,0,0 " & ControlChars.CrLf _
                    '            & "FROM SETYPE TYP, SBSECURITIES CCY WHERE TYP.STATUS='Y' AND CCY.STATUS='Y' AND TYP.ACTYPE='" & v_strSETYPE & "'"
                    'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    'Cáº­p nháº­t láº¡i sá»‘ tÃ i khoáº£n CI cá»§a há»£p Ä‘á»“ng cho AFMAST
                Else
                    'Tráº£ vá»? mÃ£ lá»—i loáº¡i hÃ¬nh há»£p Ä‘á»“ng khÃ´ng tá»“n táº¡i
                    v_lngErrCode = ERR_CF_AFTYPE_NOTFOUND
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If

            End If
            'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function InquiryContract(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CF.Trans.InquiryContract", v_strErrorMessage As String
        Dim v_strSQL As String = String.Empty
        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_obj As New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE As Double, i As Integer
            'Ä?á»?c ná»™i dung giao dá»‹ch
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If

                    Select Case v_strFLDCD
                        Case "88" 'ACCTNO
                            ATTR_ACCTNO = v_strVALUE
                        Case "04" 'NEXT TRANSACTION                                            
                    End Select
                End With
            Next
            v_strObjMsg = CallIDService("EXISTUSER", ATTR_ACCTNO, "", v_lngErrCode, v_strErrorMessage, 1)
            ' 0 User khong ton tai
            ' 1 User ton tai khong lock
            ' -2 User locked
            'v_strSQL = "SELECT CASE WHEN " & v_lngErrCode & " = 1 THEN '1 - User actived' " & _
            '           " WHEN " & v_lngErrCode & " = -2 THEN '-2 - User locked' " & _
            '           " ELSE ' User not exist' end status from dual"


            ' v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

            Dim v_arrInquiryPara() As ReportParameters
            Dim v_objInquiryParam As ReportParameters

            'Doc du liệu tìm kiếm
            v_obj = New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_objRptParam As ReportParameters
            Dim v_arrRptPara() As ReportParameters
            ReDim v_arrRptPara(0)

            '0. lngErrCode
            v_objRptParam = New ReportParameters
            v_objRptParam.ParamName = "f_ERRNUM"
            v_objRptParam.ParamValue = v_lngErrCode
            v_objRptParam.ParamType = "NUMBER"
            v_arrRptPara(0) = v_objRptParam




            v_ds = v_obj.ExecuteStoredReturnDataset("CHECKLOCKCARD", v_arrRptPara)

            Dim v_strXMLMessage As String
            v_strXMLMessage = pv_xmlDocument.InnerXml
            BuildXMLObjData(v_ds, v_strXMLMessage)
            pv_xmlDocument.LoadXml(v_strXMLMessage)

            v_lngErrCode = ERR_SYSTEM_OK


            Return v_lngErrCode
            'ContextUtil.SetComplete()
        Catch ex As Exception
            'ContextUtil.SetAbort()
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

    Private Function InquiryCustInfo(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CF.Trans.InquiryCustInfo", v_strErrorMessage As String
        Dim v_strSQL As String = String.Empty
        Dim v_ds As DataSet
        Dim v_obj As New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)
        Dim v_strCUSTID As String
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE As Double, i As Integer
            'Ä?á»?c ná»™i dung giao dá»‹ch
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If

                    Select Case v_strFLDCD
                        Case "03" 'ACCTNO
                            v_strCUSTID = v_strVALUE
                        Case "04" 'NEXT TRANSACTION                                            
                    End Select
                End With
            Next

            'Kiá»ƒm tra mÃ£ há»£p Ä‘á»“ng Ä‘Ã£ tá»“n táº¡i chÆ°a
            v_strSQL = "SELECT STATUS FROM CFMAST WHERE CUSTID='" & v_strCUSTID & "' "
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If Not v_ds.Tables(0).Rows.Count > 0 Then
                'Tráº£ vá»? mÃ£ lá»—i khÃ´ng tá»“n táº¡i mÃ£ há»£p Ä‘á»“ng
                v_lngErrCode = ERR_CF_CUSTOM_NOTFOUND
                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                             & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                             & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                Return v_lngErrCode
            ElseIf gf_CorrectStringField(v_ds.Tables(0).Rows(0)("STATUS")) <> "A" Then
                v_lngErrCode = ERR_CF_CFMAST_STATUS_INVALID
                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                             & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                             & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                Return v_lngErrCode
            End If
            'Gá»?i hÃ m Ä‘á»ƒ láº¥y dá»¯ liá»‡u vá»?
            'ATTR_CMDMISCINQUIRY = "SELECT CF.SHORTNAME, CF.FULLNAME, TO_CHAR(CF.DATEOFBIRTH,'" & gc_FORMAT_DATE & "') DATEOFBIRTH, CF.SEX, CF.IDTYPE, CF.IDCODE, CF.IDPLACE , TO_CHAR(CF.IDDATE,'" & gc_FORMAT_DATE & "') IDDATE, CF.IDEXPIRED, " & _
            '                "CF.TAXCODE, CF.ADDRESS, CF.PHONE, CF.FAX, CF.MOBILE, CF.EMAIL, CF.ORGINF, CF.PIN FROM CFMAST CF WHERE CF.CUSTID='" & v_strCUSTID & "' "
            v_strSQL = "SELECT S.SEARCHCMDSQL FROM SEARCH S, TLTX T WHERE T.MNEM = S.SEARCHCODE AND T.TLTXCD = '" & gc_CF_CUSTINFO_INq & "' "
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                ATTR_CMDMISCINQUIRY = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("SEARCHCMDSQL"))
                ATTR_CMDMISCINQUIRY = ATTR_CMDMISCINQUIRY.Replace("<$KEYVAL>", v_strCUSTID)
            End If

            v_lngErrCode = Me.txCoreMiscInquiry(pv_xmlDocument)
            Return v_lngErrCode
            'ContextUtil.SetComplete()
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function


    Private Function HistoryContract(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CF.Trans.HistoryContract", v_strErrorMessage As String

        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE As Double, i As Integer
            'Ä?á»?c ná»™i dung giao dá»‹ch
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If

                    Select Case v_strFLDCD
                        Case "03" 'ACCTNO
                            ATTR_ACCTNO = v_strVALUE
                        Case "05" 'FRDATE
                            ATTR_FRDATE = v_strVALUE
                        Case "06" 'TODATE
                            ATTR_TODATE = v_strVALUE
                    End Select
                End With
            Next
            'Gá»?i hÃ m Ä‘á»ƒ láº¥y dá»¯ liá»‡u vá»?
            'ATTR_CMDMISCINQUIRY = "SELECT * FROM " & ControlChars.CrLf _
            '    & "(SELECT DISTINCT LF.TXDATE, LF.TXNUM, LF.TLTXCD, LF.TXDESC, FLD.NVALUE AMT,TX.TXDESC TLTXDESC,TX.EN_TXDESC TLTXEN_DESC " & ControlChars.CrLf _
            '    & "FROM AFTRAN TRF, TLLOG LF, TLLOGFLD FLD, TLTX TX " & ControlChars.CrLf _
            '    & "WHERE TRF.TXNUM = LF.TXNUM AND TRF.TXDATE = LF.TXDATE AND LF.DELTD <> 'Y' " & ControlChars.CrLf _
            '    & "AND TX.TLTXCD = LF.TLTXCD AND LF.TXNUM=FLD.TXNUM AND LF.TXDATE=FLD.TXDATE AND TX.MSG_AMT=FLD.FLDCD " & ControlChars.CrLf _
            '    & "AND TRIM(TRF.ACCTNO)='" & ATTR_ACCTNO & "' " & ControlChars.CrLf _
            '    & "AND TRF.TXDATE>=TO_DATE('" & ATTR_FRDATE & "', '" & gc_FORMAT_DATE & "') " & ControlChars.CrLf _
            '    & "AND TRF.TXDATE<=TO_DATE('" & ATTR_TODATE & "', '" & gc_FORMAT_DATE & "') " & ControlChars.CrLf _
            '    & "UNION ALL " & ControlChars.CrLf _
            '    & "SELECT DISTINCT LF.TXDATE, LF.TXNUM, LF.TLTXCD, LF.TXDESC, FLD.NVALUE AMT,TX.TXDESC TLTXDESC,TX.EN_TXDESC TLTXEN_DESC " & ControlChars.CrLf _
            '    & "FROM AFTRANA TRF, TLLOGALL LF, TLLOGFLDALL FLD, TLTX TX " & ControlChars.CrLf _
            '    & "WHERE TRF.TXNUM = LF.TXNUM AND TRF.TXDATE = LF.TXDATE AND LF.DELTD <> 'Y' " & ControlChars.CrLf _
            '    & "AND TX.TLTXCD = LF.TLTXCD AND LF.TXNUM=FLD.TXNUM AND LF.TXDATE=FLD.TXDATE AND TX.MSG_AMT=FLD.FLDCD " & ControlChars.CrLf _
            '    & "AND TRIM(TRF.ACCTNO)='" & ATTR_ACCTNO & "' " & ControlChars.CrLf _
            '    & "AND TRF.TXDATE>=TO_DATE('" & ATTR_FRDATE & "', '" & gc_FORMAT_DATE & "') " & ControlChars.CrLf _
            '    & "AND TRF.TXDATE<=TO_DATE('" & ATTR_TODATE & "', '" & gc_FORMAT_DATE & "')) LOGDATA " & ControlChars.CrLf _
            '    & "ORDER BY TXDATE, TXNUM"

            'ATTR_CMDMISCINQUIRY = "SELECT * FROM  " & ControlChars.CrLf _
            '   & "(SELECT LF.TXDATE, LF.TXNUM, LF.BUSDATE, LF.TLTXCD, LF.TXDESC, LF.MSGAMT AMT,TX.TXDESC TLTXDESC,TX.EN_TXDESC TLTXEN_DESC,LF.DELTD  " & ControlChars.CrLf _
            '   & "FROM (SELECT DISTINCT TO_CHAR(TXDATE,'" & gc_FORMAT_DATE & "') || TXNUM VOUCHERCD  " & ControlChars.CrLf _
            '   & "FROM AFTRAN WHERE TRIM(ACCTNO)='" & ATTR_ACCTNO & "'  " & ControlChars.CrLf _
            '   & "AND TXDATE>=TO_DATE('" & ATTR_FRDATE & "', '" & gc_FORMAT_DATE & "')  " & ControlChars.CrLf _
            '   & "AND TXDATE<=TO_DATE('" & ATTR_TODATE & "', '" & gc_FORMAT_DATE & "')) TRF, TLLOG LF, TLTX TX  " & ControlChars.CrLf _
            '   & "WHERE TRF.VOUCHERCD=TO_CHAR(TXDATE,'" & gc_FORMAT_DATE & "') || TXNUM AND DELTD<>'Y' AND LF.TLTXCD=TX.TLTXCD  " & ControlChars.CrLf _
            '   & "UNION ALL  " & ControlChars.CrLf _
            '   & "SELECT LF.TXDATE, LF.TXNUM, LF.BUSDATE, LF.TLTXCD, LF.TXDESC, LF.MSGAMT AMT,TX.TXDESC TLTXDESC,TX.EN_TXDESC TLTXEN_DESC,LF.DELTD  " & ControlChars.CrLf _
            '   & "FROM (SELECT DISTINCT TO_CHAR(TXDATE,'" & gc_FORMAT_DATE & "') || TXNUM VOUCHERCD  " & ControlChars.CrLf _
            '   & "FROM AFTRANA WHERE TRIM(ACCTNO)='" & ATTR_ACCTNO & "'  " & ControlChars.CrLf _
            '   & "AND TXDATE>=TO_DATE('" & ATTR_FRDATE & "', '" & gc_FORMAT_DATE & "')  " & ControlChars.CrLf _
            '   & "AND TXDATE<=TO_DATE('" & ATTR_TODATE & "', '" & gc_FORMAT_DATE & "')) TRF, TLLOGALL LF, TLTX TX " & ControlChars.CrLf _
            '   & "WHERE TRF.VOUCHERCD=TO_CHAR(TXDATE,'" & gc_FORMAT_DATE & "') || TXNUM AND DELTD<>'Y' AND LF.TLTXCD=TX.TLTXCD) LOGDATA  " & ControlChars.CrLf _
            '   & "ORDER BY TXDATE, TXNUM "

            'TRUONGLD COMMENT 16/04/2010
            'Dim v_strPAGENO As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributePAGENO).Value
            'If IsNumeric(v_strPAGENO) Then
            '    Me.ATTR_PAGENUMBER = CInt(v_strPAGENO)
            'Else
            '    Me.ATTR_PAGENUMBER = 1
            'End If
            'Dim v_intFrom, v_intTo As Integer
            'v_intFrom = (Me.ATTR_PAGENUMBER - 1) * ROWS_PER_PAGE + 1
            'v_intTo = Me.ATTR_PAGENUMBER * ROWS_PER_PAGE

            'ATTR_CMDMISCINQUIRY = "SELECT * FROM (SELECT LOGDATA.*, ROWNUM RN FROM  " & ControlChars.CrLf _
            '   & "(SELECT LF.TXDATE, LF.TXNUM, LF.BUSDATE, LF.TLTXCD, LF.TXDESC, LF.MSGAMT AMT,TX.TXDESC TLTXDESC,TX.EN_TXDESC TLTXEN_DESC,LF.DELTD  " & ControlChars.CrLf _
            '   & "FROM (SELECT DISTINCT TO_CHAR(TXDATE,'" & gc_FORMAT_DATE & "') || TXNUM VOUCHERCD  " & ControlChars.CrLf _
            '   & "FROM AFTRAN WHERE ACCTNO IN (SELECT ACCTNO FROM afmast WHERE ACCTNO = '" & ATTR_ACCTNO & "'   UNION ALL SELECT CF.CUSTID FROM cfmast CF, afmast AF WHERE CF.CUSTID = AF.CUSTID  AND AF.ACCTNO = '" & ATTR_ACCTNO & "' )" & ControlChars.CrLf _
            '   & "AND TXDATE>=TO_DATE('" & ATTR_FRDATE & "', '" & gc_FORMAT_DATE & "')  " & ControlChars.CrLf _
            '   & "AND TXDATE<=TO_DATE('" & ATTR_TODATE & "', '" & gc_FORMAT_DATE & "')) TRF, TLLOG LF, TLTX TX  " & ControlChars.CrLf _
            '   & "WHERE TRF.VOUCHERCD=TO_CHAR(TXDATE,'" & gc_FORMAT_DATE & "') || TXNUM AND DELTD<>'Y' AND LF.TLTXCD=TX.TLTXCD  " & ControlChars.CrLf _
            '   & "UNION ALL  " & ControlChars.CrLf _
            '   & "SELECT LF.TXDATE, LF.TXNUM, LF.BUSDATE, LF.TLTXCD, LF.TXDESC, LF.MSGAMT AMT,TX.TXDESC TLTXDESC,TX.EN_TXDESC TLTXEN_DESC,LF.DELTD  " & ControlChars.CrLf _
            '   & "FROM (SELECT DISTINCT TO_CHAR(TXDATE,'" & gc_FORMAT_DATE & "') || TXNUM VOUCHERCD  " & ControlChars.CrLf _
            '   & "FROM AFTRANA WHERE ACCTNO IN (SELECT ACCTNO FROM afmast WHERE ACCTNO = '" & ATTR_ACCTNO & "'   UNION ALL SELECT CF.CUSTID FROM cfmast CF, afmast AF WHERE CF.CUSTID = AF.CUSTID  AND AF.ACCTNO = '" & ATTR_ACCTNO & "'  )  " & ControlChars.CrLf _
            '   & "AND TXDATE>=TO_DATE('" & ATTR_FRDATE & "', '" & gc_FORMAT_DATE & "')   " & ControlChars.CrLf _
            '   & "AND TXDATE<=TO_DATE('" & ATTR_TODATE & "', '" & gc_FORMAT_DATE & "')) TRF, TLLOGALL LF, TLTX TX " & ControlChars.CrLf _
            '   & "WHERE TRF.VOUCHERCD=TO_CHAR(TXDATE,'" & gc_FORMAT_DATE & "') || TXNUM AND DELTD<>'Y' AND LF.TLTXCD=TX.TLTXCD) LOGDATA) T1  " & ControlChars.CrLf _
            '   & "WHERE RN BETWEEN " & v_intFrom & " AND " & v_intTo & " " & ControlChars.CrLf _
            '   & "ORDER BY TXDATE, TXNUM "
            'v_lngErrCode = Me.txCoreMiscInquiry(pv_xmlDocument)
            'END TRUONGLD

            v_lngErrCode = Me.StoreHistoryAccount(pv_xmlDocument, OBJNAME_CF_CFMAST)

            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
    Private Function IssueCustodyCode2Customer(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CF.Trans.IssueCustodyCode2Customer", v_strErrorMessage As String
        Dim v_strSQL As String = String.Empty
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE As Double
            Dim v_strCUSTID, v_strCUSTODYCD, v_strDESC As String

            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False

            'Ä?á»?c ná»™i dung giao dá»‹ch
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If

                    Select Case v_strFLDCD
                        Case "03" 'CUSTID
                            v_strCUSTID = v_strVALUE
                        Case "05" 'ISOTC
                            v_strCUSTODYCD = v_strVALUE
                        Case "30" 'DESC                                              
                            v_strDESC = v_strVALUE
                    End Select
                End With
            Next

            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)

            If v_blnReversal Then
                'XoÃ¡ giao dá»‹ch
                v_strSQL = "UPDATE CFMAST SET CUSTODYCD='' WHERE CUSTID='" & v_strCUSTID & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            Else
                'Thá»±c hiá»‡n giao dá»‹ch
                v_strSQL = "UPDATE CFMAST SET CUSTODYCD='" & v_strCUSTODYCD & "' WHERE CUSTID='" & v_strCUSTID & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End If
            'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
    Private Function ChangeSystemParamater(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CF.Trans.CloseContract", v_strErrorMessage As String
        Dim v_strSQL As String = String.Empty
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE As Double
            Dim v_strGRNAME, v_strVARNAME, v_strVARVALUE, v_strVARDESC, v_strEN_VARDESC, v_strOLD_VARVALUE, v_strOLD_VARDESC, v_strOLD_EN_VARDESC As String
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_ds As DataSet
            Dim v_dblSumCISE As Double
            Dim v_strStatus As String
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False
            'Ä?á»?c ná»™i dung giao dá»‹ch
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If
                    Select Case v_strFLDCD
                        Case "03"
                            v_strGRNAME = v_strVALUE
                        Case "05"
                            v_strVARNAME = v_strVALUE
                        Case "10"
                            v_strVARVALUE = v_strVALUE
                        Case "21"
                            v_strVARDESC = v_strVALUE
                        Case "22"
                            v_strEN_VARDESC = v_strVALUE
                        Case "11"
                            v_strOLD_VARVALUE = v_strVALUE
                        Case "23"
                            v_strOLD_VARDESC = v_strVALUE
                        Case "25"
                            v_strOLD_EN_VARDESC = v_strVALUE
                    End Select
                End With
            Next


            If Not v_blnReversal Then   '

                v_strSQL = "UPDATE SYSVAR SET VARVALUE='" & v_strVARVALUE & "',VARDESC='" & v_strVARDESC & "',EN_VARDESC='" & v_strEN_VARDESC & "' WHERE GRNAME='" & v_strGRNAME & "' AND VARNAME='" & v_strVARNAME & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            Else
                v_strSQL = "UPDATE SYSVAR SET VARVALUE='" & v_strOLD_VARVALUE & "',VARDESC='" & v_strOLD_VARDESC & "',EN_VARDESC='" & v_strOLD_EN_VARDESC & "' WHERE GRNAME='" & v_strGRNAME & "' AND VARNAME='" & v_strVARNAME & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End If
            ''ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
    Private Function Change_Risk_Paramater(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CF.Trans.Change_Risk_Paramater", v_strErrorMessage As String
        Dim v_strSQL As String = String.Empty
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE As Double
            Dim v_strTLTXCD As String
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_ds As DataSet
            Dim v_dblSumCISE As Double
            Dim v_strStatus As String
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False
            'Ä?á»?c ná»™i dung giao dá»‹ch
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    If v_strFLDCD = "11" Then ' Lay ma giao dich
                        v_strTLTXCD = Trim(.InnerText)
                    End If
                End With
            Next

            Select Case v_strTLTXCD
                Case "0060" ' Adjust SYSVAR parameter
                    Dim v_strGRNAME, v_strVARNAME, v_strVARVALUE, v_strVARDESC, v_strEN_VARDESC As String
                    v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
                    For i = 0 To v_nodeList.Count - 1
                        With v_nodeList.Item(i)
                            v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                            v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                            If v_strFLDTYPE = "N" Then
                                v_strVALUE = vbNullString
                                v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                            Else
                                v_strVALUE = Trim(.InnerText)
                                v_dblVALUE = 0
                            End If
                            Select Case v_strFLDCD
                                Case "03"
                                    v_strGRNAME = v_strVALUE
                                Case "05"
                                    v_strVARNAME = v_strVALUE
                                Case "10"
                                    v_strVARVALUE = v_strVALUE
                                Case "21"
                                    v_strVARDESC = v_strVALUE
                                Case "22"
                                    v_strEN_VARDESC = v_strVALUE
                            End Select
                        End With
                    Next
                    v_strSQL = "UPDATE SYSVAR SET VARVALUE='" & v_strVARVALUE & "',VARDESC='" & v_strVARDESC & "',EN_VARDESC='" & v_strEN_VARDESC & "' WHERE GRNAME='" & v_strGRNAME & "' AND VARNAME='" & v_strVARNAME & "'"

                Case "0061" ' Adjust securites risk parameter
                    Dim v_strCODEID, v_strSYMBOL, v_strTRADEUNIT, v_strBASICPRICE, v_strOPENPRICE As String
                    Dim v_strPREVCLOSEPRICE, v_strCURRPRICE, v_strCEILINGPRICE, v_strFLOORPRICE As String
                    Dim v_strINTERNALBIDPRICE, v_strINTERNALASKPRICE, v_strDEPOFEELOT, v_strDEPOFEEUNIT As String
                    Dim v_strTRADELOT, v_strTRADEBUYSELL, v_strTELELIMITMIN, v_strTELELIMITMAX As String
                    Dim v_strREPOLIMITMIN, v_strREPOLIMITMAX, v_strADVANCEDLIMITMIN, v_strADVANCEDLIMITMAX As String
                    Dim v_strONLINELIMITMIN, v_strONLINELIMITMAX, v_strMARGINLIMITMIN, v_strMARGINLIMITMAX As String
                    Dim v_strSECUREDRATIOMIN, v_strSECUREDRATIOMAX, v_strMORTAGERATIOMIN, v_strMORTAGERATIOMAX As String

                    v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
                    For i = 0 To v_nodeList.Count - 1
                        With v_nodeList.Item(i)
                            v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                            v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                            If v_strFLDTYPE = "N" Then
                                v_strVALUE = vbNullString
                                v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                            Else
                                v_strVALUE = Trim(.InnerText)
                                v_dblVALUE = 0
                            End If

                            Select Case v_strFLDCD
                                Case "03"
                                    v_strCODEID = v_strVALUE
                                Case "05"
                                    v_strSYMBOL = v_strVALUE
                                Case "22"
                                    v_strTRADEUNIT = v_dblVALUE
                                Case "25"
                                    v_strBASICPRICE = v_dblVALUE
                                Case "26"
                                    v_strOPENPRICE = v_dblVALUE
                                Case "27"
                                    v_strPREVCLOSEPRICE = v_dblVALUE
                                Case "28"
                                    v_strCURRPRICE = v_dblVALUE
                                Case "29"
                                    v_strCEILINGPRICE = v_dblVALUE
                                Case "31"
                                    v_strFLOORPRICE = v_dblVALUE
                                Case "32"
                                    v_strINTERNALBIDPRICE = v_dblVALUE
                                Case "33"
                                    v_strINTERNALASKPRICE = v_dblVALUE
                                Case "20"
                                    v_strDEPOFEEUNIT = v_dblVALUE
                                Case "21"
                                    v_strDEPOFEELOT = v_dblVALUE
                                Case "23"
                                    v_strTRADELOT = v_dblVALUE
                                Case "24"
                                    v_strTRADEBUYSELL = v_dblVALUE
                                Case "34"
                                    v_strTELELIMITMIN = v_dblVALUE
                                Case "35"
                                    v_strTELELIMITMAX = v_dblVALUE
                                Case "38"
                                    v_strREPOLIMITMIN = v_dblVALUE
                                Case "39"
                                    v_strREPOLIMITMAX = v_dblVALUE
                                Case "40"
                                    v_strADVANCEDLIMITMIN = v_dblVALUE
                                Case "41"
                                    v_strADVANCEDLIMITMAX = v_dblVALUE
                                Case "36"
                                    v_strONLINELIMITMIN = v_dblVALUE
                                Case "37"
                                    v_strONLINELIMITMAX = v_dblVALUE
                                Case "42"
                                    v_strMARGINLIMITMIN = v_dblVALUE
                                Case "43"
                                    v_strMARGINLIMITMAX = v_dblVALUE
                                Case "44"
                                    v_strSECUREDRATIOMIN = v_dblVALUE
                                Case "45"
                                    v_strSECUREDRATIOMAX = v_dblVALUE
                                Case "46"
                                    v_strMORTAGERATIOMIN = v_dblVALUE
                                Case "47"
                                    v_strMORTAGERATIOMAX = v_dblVALUE
                            End Select
                        End With
                    Next
                    v_strSQL = "UPDATE SECURITIES_INFO SET TRADEUNIT = " & CDbl(v_strTRADEUNIT) & ", " &
                            " BASICPRICE = " & CDbl(v_strBASICPRICE) & ", OPENPRICE = " & CDbl(v_strOPENPRICE) & ", " &
                            " PREVCLOSEPRICE = " & CDbl(v_strPREVCLOSEPRICE) & ", CURRPRICE = " & CDbl(v_strCURRPRICE) & ", " &
                            " CEILINGPRICE = " & CDbl(v_strCEILINGPRICE) & ", FLOORPRICE = " & CDbl(v_strFLOORPRICE) & ", " &
                            " INTERNALBIDPRICE = " & CDbl(v_strINTERNALBIDPRICE) & ", INTERNALASKPRICE = " & CDbl(v_strINTERNALASKPRICE) & ", " &
                            " DEPOFEELOT = " & CDbl(v_strDEPOFEELOT) & ", DEPOFEEUNIT = " & CDbl(v_strDEPOFEEUNIT) & ", " &
                            " TRADELOT = " & CDbl(v_strTRADELOT) & ", TRADEBUYSELL = '" & v_strTRADEBUYSELL & "', " &
                            " TELELIMITMIN = " & CDbl(v_strTELELIMITMIN) & ", TELELIMITMAX = " & CDbl(v_strTELELIMITMAX) & ", " &
                            " REPOLIMITMIN = " & CDbl(v_strREPOLIMITMIN) & ", REPOLIMITMAX = " & CDbl(v_strREPOLIMITMAX) & ", " &
                            " ADVANCEDLIMITMIN = " & CDbl(v_strADVANCEDLIMITMIN) & ", ADVANCEDLIMITMAX = " & CDbl(v_strADVANCEDLIMITMAX) & ", " &
                            " ONLINELIMITMIN = " & CDbl(v_strONLINELIMITMIN) & ", ONLINELIMITMAX = " & CDbl(v_strONLINELIMITMAX) & ", " &
                            " MARGINLIMITMIN = " & CDbl(v_strMARGINLIMITMIN) & ", MARGINLIMITMAX = " & CDbl(v_strMARGINLIMITMAX) & ", " &
                            " SECUREDRATIOMIN = " & CDbl(v_strSECUREDRATIOMIN) & ", SECUREDRATIOMAX = " & CDbl(v_strSECUREDRATIOMAX) & ", " &
                            " MORTAGERATIOMIN = " & CDbl(v_strMORTAGERATIOMIN) & ", MORTAGERATIOMAX = " & CDbl(v_strMORTAGERATIOMAX) &
                            " WHERE CODEID = '" & v_strCODEID & "' AND SYMBOL = '" & v_strSYMBOL & "' "

                Case "0062" ' Adjust Interest/Commission/Charge/Fee information (day vao Hist)
                    Dim v_strRATEID, v_strCCYCD, v_strRATE, v_strFLRRATE, v_strCELRATE, v_strEFFECTIVEDT, v_strRATETYPE, v_strMODCODE, v_strRATETERM, v_strRATENAME As String
                    v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
                    For i = 0 To v_nodeList.Count - 1
                        With v_nodeList.Item(i)
                            v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                            v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                            If v_strFLDTYPE = "N" Then
                                v_strVALUE = vbNullString
                                v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                            Else
                                v_strVALUE = Trim(.InnerText)
                                v_dblVALUE = 0
                            End If

                            Select Case v_strFLDCD
                                Case "03"
                                    v_strRATEID = v_strVALUE
                                Case "20"
                                    v_strCCYCD = v_strVALUE
                                Case "21"
                                    v_strRATE = v_dblVALUE
                                Case "22"
                                    v_strFLRRATE = v_dblVALUE
                                Case "23"
                                    v_strCELRATE = v_dblVALUE
                                Case "24"
                                    v_strEFFECTIVEDT = v_strVALUE
                                Case "26"
                                    v_strRATETERM = v_strVALUE
                            End Select
                        End With
                    Next

                    'Neu ngay hieu luc nho hon hay bang ngay hien tai thi active ngay trong irrate
                    'neu khong thi day vao trong irrateschd doi den ngay hieu luc
                    If DDMMYYYY_SystemDate(v_strEFFECTIVEDT) <= DDMMYYYY_SystemDate(v_strTXDATE) Then
                        v_strSQL = "INSERT INTO IRRATEHIST (AUTOID,RATEID,RATENAME,CCYCD,RATE,FLRRATE,CELRATE,RATETERM,LASTDATE,EFFECTIVEDT,RATETYPE,MODCODE,STATUS) " & ControlChars.CrLf _
                                                       & "SELECT SEQ_IRRATEHIST.NEXTVAL AUTOID,RATEID ,RATENAME,CCYCD,RATE,FLRRATE,CELRATE,RATETERM,TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') LASTDATE,EFFECTIVEDT,RATETYPE,MODCODE,STATUS FROM IRRATE WHERE RATEID='" & v_strRATEID & "'"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                        v_strSQL = "UPDATE IRRATE SET RATEID='" & v_strRATEID & "',RATE=" & v_strRATE & ",CCYCD='" & v_strCCYCD & "',FLRRATE=" & v_strFLRRATE & ",CELRATE=" & v_strCELRATE & ",RATETERM='" & v_strRATETERM & "',EFFECTIVEDT=TO_DATE('" & v_strEFFECTIVEDT & "', '" & gc_FORMAT_DATE & "') WHERE RATEID='" & v_strRATEID & "'"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    Else 'Hieu luc trong tuong lai
                        v_strSQL = "INSERT INTO IRRATESCHD (AUTOID,RATEID,RATENAME,CCYCD,RATE,FLRRATE,CELRATE,RATETERM,LASTDATE,EFFECTIVEDT,RATETYPE,MODCODE,STATUS) " & ControlChars.CrLf _
                                   & "SELECT SEQ_IRRATESCHD.NEXTVAL AUTOID,'" & v_strRATEID & "' RATEID,RATENAME,'" & v_strCCYCD & "' CCYCD,'" & v_strRATE & "' RATE,'" & v_strFLRRATE & "' FLRRATE,'" & v_strCELRATE & "' CELRATE,'" & v_strRATETERM & "' RATETERM,TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') LASTDATE,TO_DATE('" & v_strEFFECTIVEDT & "', '" & gc_FORMAT_DATE & "') EFFECTIVEDT,RATETYPE,MODCODE,STATUS FROM IRRATE WHERE RATEID='" & v_strRATEID & "'"
                    End If
                Case "0090" ' Adjust AFTYPE risk parameter
                    Dim v_strAF_ACTYPE, v_strFLOORLIMIT, v_strBRANCHLIMIT, v_strTELELIMIT, v_strONLINELIMIT, v_strADVANCEDLINE, v_strREPOLINE, v_strBRATIO, v_strTRADERATE, v_strMISCRATE, v_strMINBAL, v_strTIEDDELTA As String
                    v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
                    For i = 0 To v_nodeList.Count - 1
                        With v_nodeList.Item(i)
                            v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                            v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                            If v_strFLDTYPE = "N" Then
                                v_strVALUE = vbNullString
                                v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                            Else
                                v_strVALUE = Trim(.InnerText)
                                v_dblVALUE = 0
                            End If
                            Select Case v_strFLDCD
                                Case "03"
                                    v_strAF_ACTYPE = v_strVALUE
                                Case "22"
                                    v_strFLOORLIMIT = v_dblVALUE
                                Case "23"
                                    v_strBRANCHLIMIT = v_dblVALUE
                                Case "24"
                                    v_strTELELIMIT = v_dblVALUE
                                Case "25"
                                    v_strONLINELIMIT = v_dblVALUE
                                Case "26"
                                    v_strREPOLINE = v_dblVALUE
                                Case "27"
                                    v_strONLINELIMIT = v_dblVALUE
                                Case "28"
                                    v_strADVANCEDLINE = v_dblVALUE
                                Case "29"
                                    v_strBRATIO = v_dblVALUE
                                Case "34"
                                    v_strTRADERATE = v_dblVALUE
                                Case "32"
                                    v_strMISCRATE = v_dblVALUE
                                Case "33"
                                    v_strMINBAL = v_dblVALUE
                                Case "21"
                                    v_strTIEDDELTA = v_dblVALUE
                            End Select
                        End With
                    Next
                    v_strSQL = "UPDATE AFTYPE SET FLOORLIMIT='" & v_strFLOORLIMIT & "',BRANCHLIMIT='" & v_strBRANCHLIMIT & "',TELELIMIT='" & v_strTELELIMIT & "',ONLINELIMIT ='" & v_strONLINELIMIT & "',REPOLINE='" & v_strREPOLINE & "',ADVANCEDLINE ='" & v_strADVANCEDLINE & "',BRATIO ='" & v_strBRATIO & "',TRADERATE ='" & v_strTRADERATE & "',MISCRATE='" & v_strMISCRATE & "',MINBAL='" & v_strMINBAL & "',TIEDDELTA='" & v_strTIEDDELTA & "' WHERE TRIM(ACTYPE) ='" & v_strAF_ACTYPE & "'"
                Case "0091" ' Adjust CITYPE risk parameter
                    Dim v_strDORMDAY, v_strMINBAL, v_strCI_ACTYPE As String
                    v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
                    For i = 0 To v_nodeList.Count - 1
                        With v_nodeList.Item(i)
                            v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                            v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                            If v_strFLDTYPE = "N" Then
                                v_strVALUE = vbNullString
                                v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                            Else
                                v_strVALUE = Trim(.InnerText)
                                v_dblVALUE = 0
                            End If
                            Select Case v_strFLDCD
                                Case "03"
                                    v_strCI_ACTYPE = v_strVALUE
                                Case "21"
                                    v_strDORMDAY = v_dblVALUE
                                Case "22"
                                    v_strMINBAL = v_dblVALUE
                            End Select
                        End With
                    Next
                    v_strSQL = "UPDATE CITYPE SET DORMDAY='" & v_strDORMDAY & "',MINBAL='" & v_strMINBAL & "' WHERE TRIM(ACTYPE)= '" & v_strCI_ACTYPE & "'"
                Case "0092" ' Adjust SETYPE risk parameter
                    Dim v_strMARGINRATE, v_strMORTAGERATE, v_strSE_ACTYPE, v_strTPR, v_strBRATIO, v_strALPHABETA As String
                    v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
                    For i = 0 To v_nodeList.Count - 1
                        With v_nodeList.Item(i)
                            v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                            v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                            If v_strFLDTYPE = "N" Then
                                v_strVALUE = vbNullString
                                v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                            Else
                                v_strVALUE = Trim(.InnerText)
                                v_dblVALUE = 0
                            End If
                            Select Case v_strFLDCD
                                Case "03"
                                    v_strSE_ACTYPE = v_strVALUE
                                Case "21"
                                    v_strMARGINRATE = v_dblVALUE
                                Case "22"
                                    v_strMORTAGERATE = v_dblVALUE
                                Case "20"
                                    v_strTPR = v_dblVALUE
                                Case "23"
                                    v_strBRATIO = v_dblVALUE
                                Case "24"
                                    v_strALPHABETA = v_dblVALUE
                            End Select
                        End With
                    Next
                    v_strSQL = "UPDATE SETYPE SET TPR='" & v_strTPR & "',MARGINRATE='" & v_strMARGINRATE & "',MORTAGERATE='" & v_strMORTAGERATE & "',BRATIO='" & v_strBRATIO & "',ALPHABETA='" & v_strALPHABETA & "' WHERE TRIM(ACTYPE)='" & v_strSE_ACTYPE & "'"
                Case "0093" ' Adjust ODTYPE risk parameter
                    Dim v_strOD_BRATIO, v_strTRADELIMIT, v_strOD_ACTYPE, v_strFEERATE, v_strVATRATE, v_strDEFFEERATE As String
                    v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
                    For i = 0 To v_nodeList.Count - 1
                        With v_nodeList.Item(i)
                            v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                            v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                            If v_strFLDTYPE = "N" Then
                                v_strVALUE = vbNullString
                                v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                            Else
                                v_strVALUE = Trim(.InnerText)
                                v_dblVALUE = 0
                            End If
                            Select Case v_strFLDCD
                                Case "03"
                                    v_strOD_ACTYPE = v_strVALUE
                                Case "20"
                                    v_strOD_BRATIO = v_dblVALUE
                                Case "21"
                                    v_strTRADELIMIT = v_dblVALUE
                                Case "22"
                                    v_strFEERATE = v_dblVALUE
                                Case "23"
                                    v_strVATRATE = v_dblVALUE
                                Case "24"
                                    v_strDEFFEERATE = v_dblVALUE
                            End Select
                        End With
                    Next
                    v_strSQL = "UPDATE ODTYPE SET BRATIO='" & v_strOD_BRATIO & "',TRADELIMIT='" & v_strTRADELIMIT & "',FEERATE='" & v_strFEERATE & "',VATRATE='" & v_strVATRATE & "',DEFFEERATE='" & v_strDEFFEERATE & "' WHERE TRIM(ACTYPE)='" & v_strOD_ACTYPE & "'"
                Case "0094" ' Adjust ICCF
                    Dim v_strDORMDAY, v_strMINBAL, v_strACTYPE, v_strTPR As String
                    v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
                    For i = 0 To v_nodeList.Count - 1
                        With v_nodeList.Item(i)
                            v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                            v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                            If v_strFLDTYPE = "N" Then
                                v_strVALUE = vbNullString
                                v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                            Else
                                v_strVALUE = Trim(.InnerText)
                                v_dblVALUE = 0
                            End If
                            Select Case v_strFLDCD
                                Case "03"
                                    v_strACTYPE = v_strVALUE
                                Case "21"
                                    v_strDORMDAY = v_dblVALUE
                                Case "22"
                                    v_strMINBAL = v_dblVALUE
                                Case "20"
                                    v_strTPR = v_dblVALUE
                            End Select
                        End With
                    Next
                    v_strSQL = "UPDATE CITYPE SET DORMDAY='" & v_strDORMDAY & "',MINBAL='" & v_strMINBAL & "' WHERE TRIM(ACTYPE)= '" & v_strACTYPE & "'"
            End Select
            If Not v_blnReversal Then
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End If
            ''ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function SetCUSTODY_TO_CONTRACT(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CF.Trans.IssueCustodyCode2Customer", v_strErrorMessage As String
        Dim v_strSQL As String = String.Empty
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE As Double
            Dim v_strACCTNO, v_strCUSTODYCD, v_strAFTYPE As String
            Dim v_DataAccess As New DataAccess, v_ds As DataSet

            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False

            'Ä?á»?c ná»™i dung giao dá»‹ch
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If

                    Select Case v_strFLDCD
                        Case "03" 'So HD
                            v_strACCTNO = v_strVALUE
                    End Select
                End With
            Next

            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            'Update vao CFMAST 
            v_strCUSTODYCD = "SHVC" & Strings.Right("000000" & CStr(GetCUSTODYCD()), Len("000000"))
            'v_strCUSTODYCD = GetCUSTODYCD()
            v_strSQL = "UPDATE CFMAST SET CUSTODYCD='" & v_strCUSTODYCD & "' WHERE CUSTID=(SELECT CUSTID FROM AFMAST WHERE ACCTNO='" & v_strACCTNO & "')"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            'Lay loai hinh HD
            v_strSQL = "SELECT AFTYPE FROM AFMAST WHERE ACCTNO='" & v_strACCTNO & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            v_strAFTYPE = CStr(v_ds.Tables(0).Rows(0)("AFTYPE"))
            Select Case v_strAFTYPE
                Case "0002"
                    v_strAFTYPE = "0001"
                Case "0004"
                    v_strAFTYPE = "0003"
                Case "0008"
                    v_strAFTYPE = "0007"
                Case "0006"
                    v_strAFTYPE = "0005"
                Case "1001"
                    v_strAFTYPE = "0015"
            End Select
            v_strSQL = "UPDATE AFMAST SET AFTYPE='" & v_strAFTYPE & "' WHERE ACCTNO ='" & v_strACCTNO & "'"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
    Private Function REFUSECONTRACT(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CF.Trans.IssueCustodyCode2Customer", v_strErrorMessage As String
        Dim v_strSQL As String = String.Empty
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE As Double
            Dim v_strACCTNO, v_strCUSTODYCD, v_strAFTYPE As String
            Dim v_DataAccess As New DataAccess, v_ds As DataSet

            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False

            'Ä?á»?c ná»™i dung giao dá»‹ch
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If

                    Select Case v_strFLDCD
                        Case "03" 'So HD
                            v_strACCTNO = v_strVALUE
                    End Select
                End With
            Next

            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            'Xoa CUSTODYCD
            'Neu chi co 1 hop dong thi moi duoc xoa !
            v_strSQL = "SELECT COUNT(*) COUNT FROM AFMAST WHERE  STATUS IN ('A','E','P') AND CUSTID=(SELECT CUSTID FROM AFMAST WHERE ACCTNO='" & v_strACCTNO & "')"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            Dim Count As Int16 = v_ds.Tables(0).Rows(0)("COUNT")
            If Count = 1 Then
                v_strSQL = "UPDATE CFMAST SET CUSTODYCD='' WHERE CUSTID= (SELECT CUSTID FROM AFMAST WHERE ACCTNO='" & v_strACCTNO & "')"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End If
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function Check_ChangeService(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CF.Trans.Check_ChangeService", v_strErrorMessage As String
        Dim v_strSQL As String = String.Empty
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE, v_strCONFIRMPIN, v_strPIN As String, v_dblVALUE As Double
            Dim v_strACCTNO, v_strCUSTODYCD, v_strAFTYPE As String
            Dim v_DataAccess As New DataAccess, v_ds As DataSet
            'Ä?á»?c ná»™i dung giao dá»‹ch
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If

                    Select Case v_strFLDCD
                        Case "03" 'So HD
                            v_strACCTNO = v_strVALUE
                    End Select
                End With
            Next

            Dim v_obj As New DataAccess
            Dim v_strMarginType As String
            v_obj.NewDBInstance(gc_MODULE_HOST)
            v_strSQL = "SELECT MRTYPE.MRTYPE  FROM AFMAST,AFTYPE,MRTYPE  WHERE  ACCTNO ='" & v_strACCTNO & "' AND AFMAST.ACTYPE=AFTYPE.ACTYPE AND AFTYPE.MRTYPE=MRTYPE.ACTYPE"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_strMarginType = v_ds.Tables(0).Rows(0)("MRTYPE")
                If v_strMarginType <> "N" Then 'Tai khoan khong Margin
                    Return ERR_MR_CANNOT_CHANGE_MARGIN_ACCOUNT
                End If
            Else
                'Loai hinh MR khong ton tai
                Return ERR_MR_MRTYPE_NOT_FOUND
            End If
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
    Private Function CheckPIN(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CF.Trans.IssueCustodyCode2Customer", v_strErrorMessage As String
        Dim v_strSQL As String = String.Empty
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE, v_strCONFIRMPIN, v_strPIN As String, v_dblVALUE As Double
            Dim v_strACCTNO, v_strCUSTODYCD, v_strAFTYPE As String
            Dim v_DataAccess As New DataAccess, v_ds As DataSet

            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False

            'Ä?á»?c ná»™i dung giao dá»‹ch
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If

                    Select Case v_strFLDCD
                        Case "03" 'So HD
                            v_strACCTNO = v_strVALUE
                        Case "29"
                            v_strPIN = v_strVALUE
                        Case "33"
                            v_strCONFIRMPIN = v_strVALUE

                    End Select
                End With
            Next

            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            'Kien tra PIN co bang ConfirmPin hay khong
            If v_strPIN <> v_strCONFIRMPIN Then
                Return ERR_CF_PIN_DIFFRENCE
            End If
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function fncChangeAftype(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CF.Trans.fncChangeAftype", v_strErrorMessage As String
        Dim v_strSQL As String = String.Empty
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE, v_strCONFIRMPIN, v_strPIN As String, v_dblVALUE As Double
            Dim v_strACCTNO, v_strCUSTODYCD, v_strAFTYPE As String
            Dim v_DataAccess As New DataAccess, v_ds As DataSet

            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False

            'Ä?á»?c ná»™i dung giao dá»‹ch
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If

                    Select Case v_strFLDCD
                        Case "03" 'So HD
                            v_strACCTNO = v_strVALUE
                        Case "40"
                            v_strAFTYPE = v_strVALUE
                    End Select
                End With
            Next

            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            'Kien tra co so du chung khoan niem yet, chung khoan niem yet cho ve
            v_strSQL = "SELECT count(*) FROM AFMAST WHERE  ACCTNO ='" & v_strACCTNO & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count <= 0 Then
                Return ERR_CF_AFMAST_NOTFOUND
            End If
            'Kiem tra neu khong cung GLGRP thi khong cho phep chuyen.
            Dim v_strCIGRP, v_strSEGRP, v_strMarginType, v_strAccountType, v_strLNGRP, v_strLoanType As String
            v_strSQL = "SELECT AFTYPE.AFTYPE,CITYPE.GLGRP CIGRP, SETYPE.GLGRP SEGRP,MRTYPE.MRTYPE,LNTYPE.LNTYPE, LNTYPE.GLGRP LNGRP  FROM AFMAST,AFTYPE,CITYPE,SETYPE,MRTYPE, LNTYPE  WHERE  ACCTNO ='" & v_strACCTNO & "' AND AFMAST.ACTYPE=AFTYPE.ACTYPE AND AFTYPE.CITYPE=CITYPE.ACTYPE AND AFTYPE.SETYPE=SETYPE.ACTYPE AND AFTYPE.MRTYPE=MRTYPE.ACTYPE AND AFTYPE.LNTYPE=LNTYPE.ACTYPE"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_strCIGRP = v_ds.Tables(0).Rows(0)("CIGRP")
                v_strSEGRP = v_ds.Tables(0).Rows(0)("SEGRP")
                v_strLNGRP = v_ds.Tables(0).Rows(0)("LNGRP")
                v_strMarginType = v_ds.Tables(0).Rows(0)("MRTYPE")
                v_strAccountType = v_ds.Tables(0).Rows(0)("AFTYPE")
                v_strLoanType = v_ds.Tables(0).Rows(0)("LNTYPE")
                'Kiem tra xem loai hinh moi, co cung GLGRP noi bang tien gui
                v_strSQL = "SELECT CITYPE.GLGRP FROM AFTYPE,CITYPE WHERE  AFTYPE.ACTYPE ='" & v_strAFTYPE & "' AND AFTYPE.CITYPE=CITYPE.ACTYPE"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    If v_ds.Tables(0).Rows(0)("GLGRP") <> v_strCIGRP Then
                        'Tra ve ma loi khong cung nhom ke toan
                        Return ERR_SA_CANNOT_CHANGE_GLGRP
                    End If
                Else
                    'Loai hinh CI khong ton tai
                    Return ERR_CI_AFTYPE_NOTFOUND
                End If
                'Kiem tra xem loai hinh moi, co cung GLGRP ngoai bang chung khoan
                v_strSQL = "SELECT SETYPE.GLGRP FROM AFTYPE,SETYPE WHERE  AFTYPE.ACTYPE ='" & v_strAFTYPE & "' AND AFTYPE.SETYPE=SETYPE.ACTYPE"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    If v_ds.Tables(0).Rows(0)("GLGRP") <> v_strSEGRP Then
                        'Tra ve ma loi khong cung nhom ke toan
                        Return ERR_SA_CANNOT_CHANGE_GLGRP
                    End If
                Else
                    'Loai hinh SE khong ton tai
                    Return ERR_SE_ACTYPE_NOTFOUND
                End If
                'Kiem tra xem loai hinh moi, co cung GLGRP voi loai hinh vay moi khong
                v_strSQL = "SELECT LNTYPE.GLGRP FROM AFTYPE,LNTYPE WHERE  AFTYPE.ACTYPE ='" & v_strAFTYPE & "' AND AFTYPE.LNTYPE=LNTYPE.ACTYPE"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    If v_ds.Tables(0).Rows(0)("GLGRP") <> v_strLNGRP Then
                        'Tra ve ma loi khong cung nhom ke toan
                        Return ERR_SA_CANNOT_CHANGE_GLGRP
                    End If
                Else
                    'Loai hinh LN khong ton tai
                    Return ERR_LN_ACTYPE_NOT_FOUND
                End If

                'Kiem tra xem loai hinh moi, co cung Margintype voi loai hinh moi khong
                v_strSQL = "SELECT MRTYPE.MRTYPE FROM AFTYPE,MRTYPE WHERE  AFTYPE.ACTYPE ='" & v_strAFTYPE & "' AND AFTYPE.MRTYPE=MRTYPE.ACTYPE"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    If v_ds.Tables(0).Rows(0)("MRTYPE") = "N" And v_strMarginType <> "N" Then
                        'Tra ve ma loi khong cung loai hinh margin
                        Return ERR_SA_CANNOT_CHANGE_MRTYPE
                    End If
                Else
                    'Loai hinh MR khong ton tai
                    Return ERR_MR_MRTYPE_NOT_FOUND
                End If

                'Kiem tra xem loai hinh moi, co cung Loantype voi loai hinh moi khong
                v_strSQL = "SELECT LNTYPE.LNTYPE FROM AFTYPE,LNTYPE WHERE  AFTYPE.ACTYPE ='" & v_strAFTYPE & "' AND AFTYPE.LNTYPE=LNTYPE.ACTYPE"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    If v_ds.Tables(0).Rows(0)("LNTYPE") = "N" And v_strLoanType <> "N" Then
                        'Tra ve ma loi khong cung loai hinh loan
                        Return ERR_SA_CANNOT_CHANGE_LNTYPE
                    End If
                Else
                    'Loai hinh LN khong ton tai
                    Return ERR_LN_ACTYPE_NOT_FOUND
                End If

                'Kiem tra xem loai hinh moi, co cung AFTYPE voi loai hinh moi khong
                v_strSQL = "SELECT AFTYPE.AFTYPE FROM AFTYPE WHERE  AFTYPE.ACTYPE ='" & v_strAFTYPE & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    If v_ds.Tables(0).Rows(0)("AFTYPE") <> v_strAccountType Then
                        'Tra ve ma loi khong cung loai hinh margin
                        Return ERR_SA_CANNOT_CHANGE_AFTYPE
                    End If
                Else
                    'Loai hinh MR khong ton tai
                    Return ERR_CF_AFTYPE_NOTFOUND
                End If
            End If


            v_strSQL = "SELECT AFTYPE.*,MRTYPE.MRIRATE,MRTYPE.MRMRATE,MRTYPE.MRLRATE,MRTYPE.DUEDAY,MRTYPE.EXTDAY," &
                    "LNTYPE.CCYCD,LNTYPE.LNTYPE LOANTYPE, LNTYPE.LNCLDR,LNTYPE.PRINFRQ,LNTYPE.PRINPERIOD,LNTYPE.INTFRQCD,LNTYPE.INTDAY,LNTYPE.INTPERIOD," &
                    "LNTYPE.NINTCD,LNTYPE.OINTCD,LNTYPE.RATE1,LNTYPE.RATE2,LNTYPE.RATE3," &
                    "LNTYPE.OPRINFRQ,LNTYPE.OPRINPERIOD,LNTYPE.OINTFRQCD,LNTYPE.OINTDAY,LNTYPE.ORATE1,LNTYPE.ORATE2,LNTYPE.ORATE3,LNTYPE.DRATE,LNTYPE.ADVPAY,LNTYPE.ADVPAYFEE " &
                    "FROM AFTYPE,MRTYPE,LNTYPE " &
                    "WHERE  AFTYPE.ACTYPE ='" & v_strAFTYPE & "' AND AFTYPE.MRTYPE=MRTYPE.ACTYPE AND AFTYPE.LNTYPE=LNTYPE.ACTYPE"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                'CAP NHAT HAN MUC
                v_strSQL = "UPDATE AFMAST " &
                            "SET TELELIMIT = '" & v_ds.Tables(0).Rows(0).Item("TELELIMIT") & "'" &
                            ", ONLINELIMIT = '" & v_ds.Tables(0).Rows(0).Item("ONLINELIMIT") & "'" &
                            ", DEPOSITLINE = '" & v_ds.Tables(0).Rows(0).Item("DEPOSITLINE") & "'" &
                            ", DEPORATE = '" & v_ds.Tables(0).Rows(0).Item("DEPORATE") & "'" &
                            ", TRADERATE = '" & v_ds.Tables(0).Rows(0).Item("TRADERATE") & "'" &
                            ", MISCRATE = '" & v_ds.Tables(0).Rows(0).Item("MISCRATE") & "'" &
                            ", MARGINLINE = '" & v_ds.Tables(0).Rows(0).Item("MARGINLINE") & "'" &
                            ", REPOLINE = '" & v_ds.Tables(0).Rows(0).Item("REPOLINE") & "'" &
                            ", ADVANCELINE = '" & v_ds.Tables(0).Rows(0).Item("ADVANCEDLINE") & "'" &
                            ", BRATIO = '" & v_ds.Tables(0).Rows(0).Item("BRATIO") & "'" &
                            ", AFTYPE = '" & v_ds.Tables(0).Rows(0).Item("AFTYPE") & "'" &
                            ", MRIRATE = '" & v_ds.Tables(0).Rows(0).Item("MRIRATE") & "'" &
                            ", MRMRATE = '" & v_ds.Tables(0).Rows(0).Item("MRMRATE") & "'" &
                            ", MRLRATE = '" & v_ds.Tables(0).Rows(0).Item("MRLRATE") & "'" &
                            ", MRDUEDAY = '" & v_ds.Tables(0).Rows(0).Item("DUEDAY") & "'" &
                            ", MREXTDAY = '" & v_ds.Tables(0).Rows(0).Item("EXTDAY") & "'" &
                            " WHERE ACCTNO ='" & v_strACCTNO & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                'CAP NHAT LNMAST
                v_strSQL = "UPDATE LNMAST " &
                            "SET ACTYPE = '" & v_ds.Tables(0).Rows(0).Item("LNTYPE") & "'" &
                            ", CCYCD = '" & v_ds.Tables(0).Rows(0).Item("CCYCD") & "'" &
                            ", LNTYPE = '" & v_ds.Tables(0).Rows(0).Item("LOANTYPE") & "'" &
                            ", LNCLDR = '" & v_ds.Tables(0).Rows(0).Item("LNCLDR") & "'" &
                            ", PRINFRQ = " & v_ds.Tables(0).Rows(0).Item("PRINFRQ") &
                            ", PRINPERIOD = " & v_ds.Tables(0).Rows(0).Item("PRINPERIOD") &
                            ", INTFRGCD = '" & v_ds.Tables(0).Rows(0).Item("INTFRQCD") & "'" &
                            ", INTDAY = " & v_ds.Tables(0).Rows(0).Item("INTDAY") &
                            ", INTPERIOD = " & v_ds.Tables(0).Rows(0).Item("INTPERIOD") &
                            ", NINTCD = '" & v_ds.Tables(0).Rows(0).Item("NINTCD") & "'" &
                            ", OINTCD = '" & v_ds.Tables(0).Rows(0).Item("OINTCD") & "'" &
                            ", RATE1 = " & v_ds.Tables(0).Rows(0).Item("RATE1") &
                            ", RATE2 = " & v_ds.Tables(0).Rows(0).Item("RATE2") &
                            ", RATE3 = " & v_ds.Tables(0).Rows(0).Item("RATE3") &
                            ", OPRINFRQ = " & v_ds.Tables(0).Rows(0).Item("OPRINFRQ") &
                            ", OPRINPERIOD =" & v_ds.Tables(0).Rows(0).Item("OPRINPERIOD") &
                            ", OINTFRQCD = '" & v_ds.Tables(0).Rows(0).Item("OINTFRQCD") & "'" &
                            ", OINTDAY = " & v_ds.Tables(0).Rows(0).Item("OINTDAY") &
                            ", ORATE1 = " & v_ds.Tables(0).Rows(0).Item("ORATE1") &
                            ", ORATE2 = " & v_ds.Tables(0).Rows(0).Item("ORATE2") &
                            ", ORATE3 = " & v_ds.Tables(0).Rows(0).Item("ORATE3") &
                            ", DRATE = '" & v_ds.Tables(0).Rows(0).Item("DRATE") & "'" &
                            ", ADVPAY = '" & v_ds.Tables(0).Rows(0).Item("ADVPAY") & "'" &
                            ", ADVPAYFEE = " & v_ds.Tables(0).Rows(0).Item("ADVPAYFEE") &
                            " WHERE TRFACCTNO = '" & v_strACCTNO & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                'DOI LOAI HINH TREN TAI KHOAN CI
                v_strSQL = "UPDATE CIMAST SET ACTYPE='" & v_ds.Tables(0).Rows(0).Item("CITYPE") & "'  WHERE ACCTNO='" & v_strACCTNO & "' "
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                'DOI LOAI HINH TREN TAI KHOAN SE
                v_strSQL = "UPDATE SEMAST SET ACTYPE='" & v_ds.Tables(0).Rows(0).Item("SETYPE") & "' WHERE AFACCTNO='" & v_strACCTNO & "' "
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            Else
                Return ERR_CF_AFTYPE_NOTFOUND
            End If
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
    Private Function RemoveMapBankAcct(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CF.Trans.ChangeAftypeToCorebank", v_strErrorMessage As String
        Dim v_strSQL As String = String.Empty
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE, v_strCONFIRMPIN, v_strPIN As String, v_dblVALUE, v_roundValue As Double
            Dim v_strACCTNO, v_strCUSTODYCD, v_strAFTYPE, v_stroldAFTYPE As String
            Dim v_DataAccess As New DataAccess, v_ds As DataSet

            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False

            'Ä?á»?c ná»™i dung giao dá»‹ch
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If

                    Select Case v_strFLDCD
                        Case "03" 'So HD
                            v_strACCTNO = v_strVALUE
                        Case "40"
                            v_strAFTYPE = v_strVALUE


                    End Select
                End With
            Next

            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)

            v_strSQL = "SELECT VARVALUE FROM  SYSVAR WHERE GRNAME ='SYSTEM' AND VARNAME ='ROUND_VALUE'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_roundValue = v_ds.Tables(0).Rows(0)("VARVALUE")
            Else
                v_roundValue = 0
            End If

            'Kien tra co so du chung khoan niem yet, chung khoan niem yet cho ve
            v_strSQL = "SELECT count(*) FROM AFMAST WHERE  ACCTNO ='" & v_strACCTNO & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count <= 0 Then
                Return ERR_CF_AFMAST_NOTFOUND
            End If

            'Kiem tra AFTYPE
            v_strSQL = " select * from aftype where ACTYPE = '" & v_strAFTYPE & "' and  COREBANK = 'N'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

            If v_ds.Tables(0).Rows.Count < 1 Then
                v_lngErrCode = ERR_CI_AFTYPE_IS_NOT_CORRCECT
                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                             & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                             & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                Return v_lngErrCode
            End If

            'Khiem tra balance <1
            v_strSQL = " select round(balance) balance from cimast where acctno ='" & v_strACCTNO & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

            If v_ds.Tables(0).Rows(0)(0) > v_roundValue Then
                v_lngErrCode = ERR_CI_BALANCE
                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                             & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                             & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                Return v_lngErrCode
            End If


            'Kiem tra neu khong cung GLGRP thi khong cho phep chuyen.
            'Dim v_strCIGRP, v_strSEGRP As String
            'v_strSQL = "SELECT CITYPE.GLGRP CIGRP, SETYPE.GLGRP SEGRP FROM AFMAST,AFTYPE,CITYPE,SETYPE WHERE  ACCTNO ='" & v_strACCTNO & "' AND AFMAST.ACTYPE=AFTYPE.ACTYPE AND AFTYPE.CITYPE=CITYPE.ACTYPE AND AFTYPE.SETYPE=SETYPE.ACTYPE"
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'If v_ds.Tables(0).Rows.Count > 0 Then
            '    v_strCIGRP = v_ds.Tables(0).Rows(0)("CIGRP")
            '    v_strSEGRP = v_ds.Tables(0).Rows(0)("SEGRP")
            '    'Kiem tra xem loai hinh moi, co cung GLGRP noi bang tien gui
            '    v_strSQL = "SELECT CITYPE.GLGRP FROM AFTYPE,CITYPE WHERE  AFTYPE.ACTYPE ='" & v_strAFTYPE & "' AND AFTYPE.CITYPE=CITYPE.ACTYPE"
            '    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            '    If v_ds.Tables(0).Rows.Count > 0 Then
            '        If v_ds.Tables(0).Rows(0)("GLGRP") <> v_strCIGRP Then
            '            'Tra ve ma loi khong cung nhom ke toan
            '            Return ERR_SA_CANNOT_CHANGE_GLGRP
            '        End If
            '    Else
            '        'Loai hinh CI khong ton tai
            '        Return ERR_CI_AFTYPE_NOTFOUND
            '    End If
            'Kiem tra xem loai hinh moi, co cung GLGRP ngoai bang chung khoan
            'v_strSQL = "SELECT SETYPE.GLGRP FROM AFTYPE,SETYPE WHERE  AFTYPE.ACTYPE ='" & v_strAFTYPE & "' AND AFTYPE.SETYPE=SETYPE.ACTYPE"
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            '    If v_ds.Tables(0).Rows.Count > 0 Then
            '        If v_ds.Tables(0).Rows(0)("GLGRP") <> v_strSEGRP Then
            '            'Tra ve ma loi khong cung nhom ke toan
            '            Return ERR_SA_CANNOT_CHANGE_GLGRP
            '        End If
            '    Else
            '        'Loai hinh SE khong ton tai
            '        Return ERR_SE_ACTYPE_NOTFOUND
            '    End If
            'End If


            v_strSQL = "SELECT * FROM AFTYPE WHERE  ACTYPE ='" & v_strAFTYPE & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                'CAP NHAT HAN MUC
                v_strSQL = "UPDATE AFMAST " &
                            "SET TELELIMIT = '" & v_ds.Tables(0).Rows(0).Item("TELELIMIT") & "'" &
                            ", ONLINELIMIT = '" & v_ds.Tables(0).Rows(0).Item("ONLINELIMIT") & "'" &
                            ", DEPOSITLINE = '" & v_ds.Tables(0).Rows(0).Item("DEPOSITLINE") & "'" &
                            ", DEPORATE = '" & v_ds.Tables(0).Rows(0).Item("DEPORATE") & "'" &
                            ", TRADERATE = '" & v_ds.Tables(0).Rows(0).Item("TRADERATE") & "'" &
                            ", MISCRATE = '" & v_ds.Tables(0).Rows(0).Item("MISCRATE") & "'" &
                            ", MARGINLINE = '" & v_ds.Tables(0).Rows(0).Item("MARGINLINE") & "'" &
                            ", REPOLINE = '" & v_ds.Tables(0).Rows(0).Item("REPOLINE") & "'" &
                            ", ADVANCELINE = '" & v_ds.Tables(0).Rows(0).Item("ADVANCEDLINE") & "'" &
                            ", BRATIO = '" & v_ds.Tables(0).Rows(0).Item("BRATIO") & "'" &
                            " WHERE ACCTNO ='" & v_strACCTNO & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                'DOI LOAI HINH TREN TAI KHOAN CI
                v_strSQL = "UPDATE CIMAST SET ACTYPE='" & v_ds.Tables(0).Rows(0).Item("CITYPE") & "'  WHERE ACCTNO='" & v_strACCTNO & "' "
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                'DOI LOAI HINH TREN TAI KHOAN SE
                v_strSQL = "UPDATE SEMAST SET ACTYPE='" & v_ds.Tables(0).Rows(0).Item("SETYPE") & "' WHERE AFACCTNO='" & v_strACCTNO & "' "
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)



            Else
                Return ERR_CF_AFTYPE_NOTFOUND
            End If
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
    Private Function ChangeAftypeToCorebank(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CF.Trans.ChangeAftypeToCorebank", v_strErrorMessage As String
        Dim v_strSQL As String = String.Empty
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE, v_strCONFIRMPIN, v_strPIN As String, v_dblVALUE, v_roundValue As Double
            Dim v_strACCTNO, v_strCUSTODYCD, v_strAFTYPE, v_stroldAFTYPE As String
            Dim v_DataAccess As New DataAccess, v_ds As DataSet

            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False

            'Ä?á»?c ná»™i dung giao dá»‹ch
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If

                    Select Case v_strFLDCD
                        Case "03" 'So HD
                            v_strACCTNO = v_strVALUE
                        Case "40"
                            v_strAFTYPE = v_strVALUE
                        Case "39"
                            v_stroldAFTYPE = v_strVALUE


                    End Select
                End With
            Next

            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)

            v_strSQL = "SELECT VARVALUE FROM  SYSVAR WHERE GRNAME ='SYSTEM' AND VARNAME ='ROUND_VALUE'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_roundValue = v_ds.Tables(0).Rows(0)("VARVALUE")
            Else
                v_roundValue = 0
            End If

            'Kien tra co so du chung khoan niem yet, chung khoan niem yet cho ve
            v_strSQL = "SELECT count(*) FROM AFMAST WHERE  ACCTNO ='" & v_strACCTNO & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count <= 0 Then
                Return ERR_CF_AFMAST_NOTFOUND
            End If

            'Khiem tra AFTYPE
            v_strSQL = " select * from aftype where ACTYPE = '" & v_strAFTYPE & "' and  COREBANK = 'Y'  union all select * from aftype where ACTYPE = '" & v_stroldAFTYPE & "' and  COREBANK = 'N' "
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

            If v_ds.Tables(0).Rows.Count <= 1 Then
                v_lngErrCode = ERR_CI_AFTYPE_IS_NOT_CORRCECT
                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                             & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                             & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                Return v_lngErrCode
            End If

            'Khiem tra balance <1
            v_strSQL = " select round(balance) balance from cimast where acctno ='" & v_strACCTNO & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

            If v_ds.Tables(0).Rows(0)(0) > v_roundValue Then
                v_lngErrCode = ERR_CI_BALANCE
                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                             & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                             & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                Return v_lngErrCode
            End If


            'Kiem tra neu khong cung GLGRP thi khong cho phep chuyen.
            'Dim v_strCIGRP, v_strSEGRP As String
            'v_strSQL = "SELECT CITYPE.GLGRP CIGRP, SETYPE.GLGRP SEGRP FROM AFMAST,AFTYPE,CITYPE,SETYPE WHERE  ACCTNO ='" & v_strACCTNO & "' AND AFMAST.ACTYPE=AFTYPE.ACTYPE AND AFTYPE.CITYPE=CITYPE.ACTYPE AND AFTYPE.SETYPE=SETYPE.ACTYPE"
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'If v_ds.Tables(0).Rows.Count > 0 Then
            '    v_strCIGRP = v_ds.Tables(0).Rows(0)("CIGRP")
            '    v_strSEGRP = v_ds.Tables(0).Rows(0)("SEGRP")
            '    'Kiem tra xem loai hinh moi, co cung GLGRP noi bang tien gui
            '    v_strSQL = "SELECT CITYPE.GLGRP FROM AFTYPE,CITYPE WHERE  AFTYPE.ACTYPE ='" & v_strAFTYPE & "' AND AFTYPE.CITYPE=CITYPE.ACTYPE"
            '    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            '    If v_ds.Tables(0).Rows.Count > 0 Then
            '        If v_ds.Tables(0).Rows(0)("GLGRP") <> v_strCIGRP Then
            '            'Tra ve ma loi khong cung nhom ke toan
            '            Return ERR_SA_CANNOT_CHANGE_GLGRP
            '        End If
            '    Else
            '        'Loai hinh CI khong ton tai
            '        Return ERR_CI_AFTYPE_NOTFOUND
            '    End If
            'Kiem tra xem loai hinh moi, co cung GLGRP ngoai bang chung khoan
            'v_strSQL = "SELECT SETYPE.GLGRP FROM AFTYPE,SETYPE WHERE  AFTYPE.ACTYPE ='" & v_strAFTYPE & "' AND AFTYPE.SETYPE=SETYPE.ACTYPE"
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            '    If v_ds.Tables(0).Rows.Count > 0 Then
            '        If v_ds.Tables(0).Rows(0)("GLGRP") <> v_strSEGRP Then
            '            'Tra ve ma loi khong cung nhom ke toan
            '            Return ERR_SA_CANNOT_CHANGE_GLGRP
            '        End If
            '    Else
            '        'Loai hinh SE khong ton tai
            '        Return ERR_SE_ACTYPE_NOTFOUND
            '    End If
            'End If


            v_strSQL = "SELECT * FROM AFTYPE WHERE  ACTYPE ='" & v_strAFTYPE & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                'CAP NHAT HAN MUC
                v_strSQL = "UPDATE AFMAST " &
                            "SET TELELIMIT = '" & v_ds.Tables(0).Rows(0).Item("TELELIMIT") & "'" &
                            ", ONLINELIMIT = '" & v_ds.Tables(0).Rows(0).Item("ONLINELIMIT") & "'" &
                            ", DEPOSITLINE = '" & v_ds.Tables(0).Rows(0).Item("DEPOSITLINE") & "'" &
                            ", DEPORATE = '" & v_ds.Tables(0).Rows(0).Item("DEPORATE") & "'" &
                            ", TRADERATE = '" & v_ds.Tables(0).Rows(0).Item("TRADERATE") & "'" &
                            ", MISCRATE = '" & v_ds.Tables(0).Rows(0).Item("MISCRATE") & "'" &
                            ", MARGINLINE = '" & v_ds.Tables(0).Rows(0).Item("MARGINLINE") & "'" &
                            ", REPOLINE = '" & v_ds.Tables(0).Rows(0).Item("REPOLINE") & "'" &
                            ", ADVANCELINE = '" & v_ds.Tables(0).Rows(0).Item("ADVANCEDLINE") & "'" &
                            ", BRATIO = '" & v_ds.Tables(0).Rows(0).Item("BRATIO") & "'" &
                            " WHERE ACCTNO ='" & v_strACCTNO & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                'DOI LOAI HINH TREN TAI KHOAN CI
                v_strSQL = "UPDATE CIMAST SET ACTYPE='" & v_ds.Tables(0).Rows(0).Item("CITYPE") & "'  WHERE ACCTNO='" & v_strACCTNO & "' "
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                'DOI LOAI HINH TREN TAI KHOAN SE
                v_strSQL = "UPDATE SEMAST SET ACTYPE='" & v_ds.Tables(0).Rows(0).Item("SETYPE") & "' WHERE AFACCTNO='" & v_strACCTNO & "' "
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                'DOI LOAI HINH TREN TAI KHOAN CI
                v_strSQL = "UPDATE CIMAST SET COREBANK ='Y' WHERE ACCTNO='" & v_strACCTNO & "' "
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                'DOI LOAI HINH TREN TAI KHOAN af
                v_strSQL = "UPDATE AFMAST SET COREBANK ='Y' WHERE ACCTNO='" & v_strACCTNO & "' "
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)


            Else
                Return ERR_CF_AFTYPE_NOTFOUND
            End If
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function ChangeAftypeToCorebankTemporary(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CF.Trans.ChangeAftypeToCorebank", v_strErrorMessage As String
        Dim v_strSQL As String = String.Empty
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE, v_strCONFIRMPIN, v_strPIN As String, v_dblVALUE, v_roundValue As Double
            Dim v_strACCTNO, v_strCUSTODYCD, v_strAFTYPE, v_stroldAFTYPE As String
            Dim v_DataAccess As New DataAccess, v_ds As DataSet

            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False

            'Ä?á»?c ná»™i dung giao dá»‹ch
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If

                    Select Case v_strFLDCD
                        Case "03" 'So HD
                            v_strACCTNO = v_strVALUE
                        Case "40"
                            v_strAFTYPE = v_strVALUE
                        Case "39"
                            v_stroldAFTYPE = v_strVALUE


                    End Select
                End With
            Next

            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)

            v_strSQL = "SELECT VARVALUE FROM  SYSVAR WHERE GRNAME ='SYSTEM' AND VARNAME ='ROUND_VALUE'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_roundValue = v_ds.Tables(0).Rows(0)("VARVALUE")
            Else
                v_roundValue = 0
            End If

            'Kien tra co so du chung khoan niem yet, chung khoan niem yet cho ve
            v_strSQL = "SELECT count(*) FROM AFMAST WHERE  ACCTNO ='" & v_strACCTNO & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count <= 0 Then
                Return ERR_CF_AFMAST_NOTFOUND
            End If

            'Khiem tra AFTYPE
            v_strSQL = " select * from aftype where ACTYPE = '" & v_strAFTYPE & "' and  COREBANK = 'Y'  union all select * from aftype where ACTYPE = '" & v_stroldAFTYPE & "' and  COREBANK = 'N' "
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

            If v_ds.Tables(0).Rows.Count <= 1 Then
                v_lngErrCode = ERR_CI_AFTYPE_IS_NOT_CORRCECT
                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                             & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                             & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                Return v_lngErrCode
            End If


            v_strSQL = "SELECT * FROM AFTYPE WHERE  ACTYPE ='" & v_strAFTYPE & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                'CAP NHAT HAN MUC
                v_strSQL = "UPDATE AFMAST " &
                            "SET TELELIMIT = '" & v_ds.Tables(0).Rows(0).Item("TELELIMIT") & "'" &
                            ", ONLINELIMIT = '" & v_ds.Tables(0).Rows(0).Item("ONLINELIMIT") & "'" &
                            ", DEPOSITLINE = '" & v_ds.Tables(0).Rows(0).Item("DEPOSITLINE") & "'" &
                            ", DEPORATE = '" & v_ds.Tables(0).Rows(0).Item("DEPORATE") & "'" &
                            ", TRADERATE = '" & v_ds.Tables(0).Rows(0).Item("TRADERATE") & "'" &
                            ", MISCRATE = '" & v_ds.Tables(0).Rows(0).Item("MISCRATE") & "'" &
                            ", MARGINLINE = '" & v_ds.Tables(0).Rows(0).Item("MARGINLINE") & "'" &
                            ", REPOLINE = '" & v_ds.Tables(0).Rows(0).Item("REPOLINE") & "'" &
                            ", ADVANCELINE = '" & v_ds.Tables(0).Rows(0).Item("ADVANCEDLINE") & "'" &
                            ", BRATIO = '" & v_ds.Tables(0).Rows(0).Item("BRATIO") & "'" &
                            " WHERE ACCTNO ='" & v_strACCTNO & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                'DOI LOAI HINH TREN TAI KHOAN CI
                v_strSQL = "UPDATE CIMAST SET ACTYPE='" & v_ds.Tables(0).Rows(0).Item("CITYPE") & "'  WHERE ACCTNO='" & v_strACCTNO & "' "
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                'DOI LOAI HINH TREN TAI KHOAN SE
                v_strSQL = "UPDATE SEMAST SET ACTYPE='" & v_ds.Tables(0).Rows(0).Item("SETYPE") & "' WHERE AFACCTNO='" & v_strACCTNO & "' "
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                'DOI LOAI HINH TREN TAI KHOAN CI
                v_strSQL = "UPDATE CIMAST SET COREBANK ='Y' WHERE ACCTNO='" & v_strACCTNO & "' "
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                'DOI LOAI HINH TREN TAI KHOAN af
                v_strSQL = "UPDATE AFMAST SET COREBANK ='Y' WHERE ACCTNO='" & v_strACCTNO & "' "
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            Else
                Return ERR_CF_AFTYPE_NOTFOUND
            End If
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function RChangeAftypeToCorebank(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CF.Trans.ChangeAftypeToCorebank", v_strErrorMessage As String
        Dim v_strSQL As String = String.Empty
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE, v_strCONFIRMPIN, v_strPIN As String, v_dblVALUE, v_roundValue As Double
            Dim v_strACCTNO, v_strCUSTODYCD, v_strAFTYPE As String
            Dim v_DataAccess As New DataAccess, v_ds As DataSet

            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False

            'Ä?á»?c ná»™i dung giao dá»‹ch
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If

                    Select Case v_strFLDCD
                        Case "03" 'So HD
                            v_strACCTNO = v_strVALUE

                    End Select
                End With
            Next

            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)



            v_strSQL = "SELECT VARVALUE FROM  SYSVAR WHERE GRNAME ='SYSTEM' AND VARNAME ='ROUND_VALUE'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_roundValue = v_ds.Tables(0).Rows(0)("VARVALUE")
            Else
                v_roundValue = 0
            End If

            'Kien tra co con trong thanh toan bu tru khogn 
            v_strSQL = "SELECT SUM(AMT) AMT fROM STSCHD WHERE  AFACCTNO = '" & v_strACCTNO & "' AND STATUS <>'C' AND DELTD<>'Y'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

            If v_ds.Tables(0).Rows.Count > 1 Then
                If v_ds.Tables(0).Rows(0)(0) > v_roundValue Then
                    v_lngErrCode = ERR_CF_HAS_IN_STSCHD
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If
            End If

            'Khiem tra xem co CI
            v_strSQL = "SELECT SUM(EMKAMT+ MBLOCK) AMT FROM cimast WHERE  AFACCTNO = '" & v_strACCTNO & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

            If v_ds.Tables(0).Rows(0)(0) > v_roundValue Then
                v_lngErrCode = ERR_CI_EXIST
                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                             & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                             & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                Return v_lngErrCode
            End If



        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function CheckChangeAftype(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CF.Trans.fncChangeAftype", v_strErrorMessage As String
        Dim v_strSQL As String = String.Empty
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE, v_strCONFIRMPIN, v_strPIN As String, v_dblVALUE As Double
            Dim v_strACCTNO, v_strCUSTODYCD, v_strAFTYPE As String
            Dim v_DataAccess As New DataAccess, v_ds As DataSet

            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False

            'Ä?á»?c ná»™i dung giao dá»‹ch
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If

                    Select Case v_strFLDCD
                        Case "03" 'So HD
                            v_strACCTNO = v_strVALUE
                        Case "40"
                            v_strAFTYPE = v_strVALUE
                    End Select
                End With
            Next

            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            'Kien tra co so du chung khoan niem yet, chung khoan niem yet cho ve
            v_strSQL = "SELECT count(*) FROM AFMAST WHERE  ACCTNO ='" & v_strACCTNO & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count <= 0 Then
                Return ERR_CF_AFMAST_NOTFOUND
            End If
            'Kiem tra neu khong cung GLGRP thi khong cho phep chuyen.
            Dim v_strCoreBank, v_strCIGRP, v_strSEGRP, v_strMarginType, v_strAccountType, v_strLNGRP, v_strLoanType As String
            v_strSQL = "SELECT AFTYPE.COREBANK,AFTYPE.AFTYPE,CITYPE.GLGRP CIGRP, SETYPE.GLGRP SEGRP,MRTYPE.MRTYPE,LNTYPE.LNTYPE, LNTYPE.GLGRP LNGRP  FROM AFMAST,AFTYPE,CITYPE,SETYPE,MRTYPE, LNTYPE  WHERE  ACCTNO ='" & v_strACCTNO & "' AND AFMAST.ACTYPE=AFTYPE.ACTYPE AND AFTYPE.CITYPE=CITYPE.ACTYPE AND AFTYPE.SETYPE=SETYPE.ACTYPE AND AFTYPE.MRTYPE=MRTYPE.ACTYPE AND AFTYPE.LNTYPE=LNTYPE.ACTYPE"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_strCIGRP = v_ds.Tables(0).Rows(0)("CIGRP")
                v_strSEGRP = v_ds.Tables(0).Rows(0)("SEGRP")
                v_strLNGRP = v_ds.Tables(0).Rows(0)("LNGRP")
                v_strMarginType = v_ds.Tables(0).Rows(0)("MRTYPE")
                v_strAccountType = v_ds.Tables(0).Rows(0)("AFTYPE")
                v_strLoanType = v_ds.Tables(0).Rows(0)("LNTYPE")
                v_strCoreBank = v_ds.Tables(0).Rows(0)("COREBANK")
                'Kiem tra xem loai hinh moi, co cung GLGRP noi bang tien gui
                v_strSQL = "SELECT CITYPE.GLGRP FROM AFTYPE,CITYPE WHERE  AFTYPE.ACTYPE ='" & v_strAFTYPE & "' AND AFTYPE.CITYPE=CITYPE.ACTYPE"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    If v_ds.Tables(0).Rows(0)("GLGRP") <> v_strCIGRP Then
                        'Tra ve ma loi khong cung nhom ke toan
                        Return ERR_SA_CANNOT_CHANGE_GLGRP
                    End If
                Else
                    'Loai hinh CI khong ton tai
                    Return ERR_CI_AFTYPE_NOTFOUND
                End If
                'Kiem tra xem loai hinh moi, co cung GLGRP ngoai bang chung khoan
                v_strSQL = "SELECT SETYPE.GLGRP FROM AFTYPE,SETYPE WHERE  AFTYPE.ACTYPE ='" & v_strAFTYPE & "' AND AFTYPE.SETYPE=SETYPE.ACTYPE"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    If v_ds.Tables(0).Rows(0)("GLGRP") <> v_strSEGRP Then
                        'Tra ve ma loi khong cung nhom ke toan
                        Return ERR_SA_CANNOT_CHANGE_GLGRP
                    End If
                Else
                    'Loai hinh SE khong ton tai
                    Return ERR_SE_ACTYPE_NOTFOUND
                End If
                'Kiem tra xem loai hinh moi, co cung GLGRP voi loai hinh vay moi khong
                v_strSQL = "SELECT LNTYPE.GLGRP FROM AFTYPE,LNTYPE WHERE  AFTYPE.ACTYPE ='" & v_strAFTYPE & "' AND AFTYPE.LNTYPE=LNTYPE.ACTYPE"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    If v_ds.Tables(0).Rows(0)("GLGRP") <> v_strLNGRP Then
                        'Tra ve ma loi khong cung nhom ke toan
                        Return ERR_SA_CANNOT_CHANGE_GLGRP
                    End If
                Else
                    'Loai hinh LN khong ton tai
                    Return ERR_LN_ACTYPE_NOT_FOUND
                End If

                'Kiem tra xem loai hinh moi, neu la margin thi khong cho chuyen , co cung Margintype voi loai hinh moi khong
                v_strSQL = "SELECT MRTYPE.MRTYPE FROM AFTYPE,MRTYPE WHERE  AFTYPE.ACTYPE ='" & v_strAFTYPE & "' AND AFTYPE.MRTYPE=MRTYPE.ACTYPE"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    If v_ds.Tables(0).Rows(0)("MRTYPE") = "N" And v_strMarginType <> "N" Then
                        'Tra ve ma loi khong cung loai hinh margin
                        Return ERR_SA_CANNOT_CHANGE_MRTYPE
                    End If
                    If v_ds.Tables(0).Rows(0)("MRTYPE") <> "N" And v_strMarginType = "N" Then
                        'Neu chuyen tu khong Margin sang margin, phai kiem tra tai khoan khong co No
                        v_strSQL = "SELECT ODAMT FROM CIMAST WHERE ACCTNO ='" & v_strACCTNO & "'"
                        v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                        If v_ds.Tables(0).Rows(0)("ODAMT") > 0 Then
                            'Tai khoan dang vay
                            Return ERR_CI_ODAMT_REMAIN
                        End If
                    End If
                Else
                    'Loai hinh MR khong ton tai
                    Return ERR_MR_MRTYPE_NOT_FOUND
                End If

                'Kiem tra xem loai hinh moi, co cung Loantype voi loai hinh moi khong
                v_strSQL = "SELECT LNTYPE.LNTYPE FROM AFTYPE,LNTYPE WHERE  AFTYPE.ACTYPE ='" & v_strAFTYPE & "' AND AFTYPE.LNTYPE=LNTYPE.ACTYPE"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    If v_ds.Tables(0).Rows(0)("LNTYPE") = "N" And v_strLoanType <> "N" Then
                        'Tra ve ma loi khong cung loai hinh loan
                        Return ERR_SA_CANNOT_CHANGE_LNTYPE
                    End If
                Else
                    'Loai hinh LN khong ton tai
                    Return ERR_LN_ACTYPE_NOT_FOUND
                End If

                'Kiem tra xem loai hinh moi, co cung AFTYPE voi loai hinh moi khong
                v_strSQL = "SELECT AFTYPE.AFTYPE, AFTYPE.COREBANK FROM AFTYPE WHERE  AFTYPE.ACTYPE ='" & v_strAFTYPE & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    If v_ds.Tables(0).Rows(0)("AFTYPE") <> v_strAccountType Then
                        'Tra ve ma loi khong cung loai hinh margin
                        Return ERR_SA_CANNOT_CHANGE_AFTYPE
                    End If
                    If v_ds.Tables(0).Rows(0)("COREBANK") <> v_strCoreBank Then
                        Return ERR_SA_CANNOT_CHANGE_COREBANK_TYPE
                    End If
                Else
                    'Loai hinh MR khong ton tai
                    Return ERR_CF_AFTYPE_NOTFOUND
                End If
            Else
                Return ERR_CF_AFTYPE_NOTFOUND
            End If
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function CheckAllocateMarginLimit(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CF.Trans.CheckAllocateMarginLimit", v_strErrorMessage As String
        Dim v_strSQL As String = String.Empty
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE, v_strCONFIRMPIN, v_strPIN As String, v_dblVALUE As Double
            Dim v_strACCTNO, v_strUserID As String
            Dim v_dblAmount, v_acclimit_user, v_dbGOTAMT, v_dbMAXDEBTCF As Double   ' v_acclimit_user la muc toi da user co the cap cho 1 hop dong
            Dim v_DataAccess As New DataAccess, v_ds As DataSet

            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False

            'Ã„?Ã¡Â»?c nÃ¡Â»â„¢i dung giao dÃ¡Â»â€¹ch
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If

                    Select Case v_strFLDCD
                        Case "01" 'UserID
                            v_strUserID = v_strVALUE
                        Case "03" 'ACCTNO
                            v_strACCTNO = v_strVALUE
                        Case "10" 'ACCLIMIT
                            v_dblAmount = v_dblVALUE
                        Case "11" 'MRCRLIMITMAX
                            v_dbGOTAMT = v_dblVALUE

                    End Select
                End With
            Next

            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            ' ------------------------------------So hop dong phai active ----------- 
            v_strSQL = "Select AF.STATUS status from AFMAST AF, aftype a where AF.actype=a.actype and ACCTNO ='" + v_strACCTNO + "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows(0)("status") <> "A" Then ' 
                'so hop dong ko o active
                Return ERR_SA_ACCTNO_NOT_ACTIVE
            End If
            '' ------------------------------------So hop dong phai la hop dong margin ----------- 
            'v_strSQL = "Select Mr.mrtype MRTYPE from AFMAST AF, aftype a , MRtype MR  where  AF.actype=a.actype and a.MRTYPE  = MR.actype and ACCTNO ='" + v_strACCTNO + "'"
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'If v_ds.Tables(0).Rows(0)("MRTYPE") = "N" Then
            '    Return ERR_SA_ACCTNO_NOT_IN_MARGIN_TYPE
            'End If
            '------------------------------------Kien tra han muc cap phai nho hon han muc con lai cua user---------------
            v_strSQL = "SELECT NVL(ACCTLIMIT,0) ACCTLIMIT, ALLOCATELIMMIT-USEDLIMMIT AVLLIMIT FROM USERLIMIT WHERE  TLIDUSER ='" & v_strUserID & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count <= 0 Then
                Return ERR_SA_USERID_NOTFOUND
            Else
                v_acclimit_user = v_ds.Tables(0).Rows(0)("ACCTLIMIT")
                If v_dblAmount > v_ds.Tables(0).Rows(0)("AVLLIMIT") Then
                    'bAO LOI CAP QUA HAN MUC CUA USER
                    Return ERR_SA_ALLOCATE_OVER_AVAILABLE_USER_LIMIT
                End If
            End If
            ' ------------------------------------Kiem tra  han muc cap them + han muc da cap < han muc toi da cua 1 user cap cho hop dong ----------- 
            v_strSQL = "SELECT ACCLIMIT FROM USERAFLIMIT WHERE  TYPERECEIVE='MR' and TLIDUSER ='" & v_strUserID & "' and ACCTNO ='" + v_strACCTNO + "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count <= 0 Then ' Neu user chua cap lan nao ( se them moi chu ko update)
                If v_dblAmount > v_acclimit_user Then
                    'bAO LOI CAP QUA HAN MUC CUA USER DOI VOI 1 HOP DONG 
                    Return ERR_SA_ALLOCATE_OVER_AVAILABLE_USER_LIMIT_TO_AF
                End If
            Else  '-----------Neu nhu da cap
                If v_dblAmount + v_ds.Tables(0).Rows(0)("ACCLIMIT") > v_acclimit_user Then
                    'bAO LOI CAP QUA HAN MUC CUA USER DOI VOI 1 HOP DONG 
                    Return ERR_SA_ALLOCATE_OVER_AVAILABLE_USER_LIMIT_TO_AF
                End If
            End If
            '-------------------------------------Kiem tra han muc thu hoi ko vuot qua han muc da cap--------------------------------------------------
            v_strSQL = "SELECT ACCLIMIT FROM USERAFLIMIT WHERE  TYPERECEIVE='MR' and  TLIDUSER ='" & v_strUserID & "' and ACCTNO ='" + v_strACCTNO + "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count <= 0 Then ' Neu user chua cap lan nao ( se them moi chu ko update)
                If v_dblAmount < 0 Then
                    'chua cap da thu
                    Return ERR_SA_CAN_NOT_RETRIEVE
                End If
            Else  '-----------Neu nhu da cap
                If v_dblAmount + v_ds.Tables(0).Rows(0)("ACCLIMIT") < 0 Then
                    'Thu vuot qua so da cap 
                    Return ERR_SA_RETRIEVE_OVER_ALLOCATE
                End If
            End If

            '-------------------------------------------------------------------------------------------------------------------------------------------

            '-------------------------------------Kiem tra tong han muc cua cac hop dong phai nho hon han muc cua khach hang khi da cap--------------------------------------------------
            v_strSQL = "select sum(acclimit) MR_allocated , CF.mrloanlimit MR_loanLImit, (Select sum(af.advanceline) from AFMAST af  where  af.custid = (select CUSTID  from afmast where acctno='" + v_strACCTNO + "')) ADVANCELINE from useraflimit us , afmast af ,CFMAST CF where TYPERECEIVE='MR' and af.acctno = us.acctno and af.custid = CF.custid and af.custid = (select CUSTID  from afmast where acctno='" + v_strACCTNO + "')group by  CF.mrloanlimit"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count <= 0 Then
            Else
                If v_ds.Tables(0).Rows(0)("MR_allocated") + +v_ds.Tables(0).Rows(0)("ADVANCELINE") + v_dblAmount > v_ds.Tables(0).Rows(0)("MR_loanLImit") Then
                    'tong so han muc + cap them > han muc cua khach hang 
                    Return ERR_SA_ALLOCATE_OVER_MRLOANLIMIT
                End If
            End If
            '-------------------------------------Kiem tra tong han muc cua cac hop dong phai nho hon han muc cua khach hang khi cap lan dau tien--------------------------------------------------
            v_strSQL = "select CF.mrloanlimit MR_loanLImit,(Select sum(af.advanceline) from AFMAST af  where  af.custid = (select CUSTID  from afmast where acctno='" + v_strACCTNO + "')) ADVANCELINE from afmast af ,CFMAST CF where af.custid = CF.custid and af.custid = (select CUSTID  from afmast where acctno='" + v_strACCTNO + "')group by CF.mrloanlimit"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count <= 0 Then
            Else
                If v_dblAmount + v_ds.Tables(0).Rows(0)("ADVANCELINE") > v_ds.Tables(0).Rows(0)("MR_loanLImit") Then
                    'tong so han muc + cap them > han muc cua khach hang 
                    Return ERR_SA_ALLOCATE_OVER_MRLOANLIMIT
                End If
            End If
            '--------------------------------------------------------------------

            '</ TruongLD Add 26/10/2011 Margin 74
            '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            '----------------------------------- Kiem tra han muc vay duoc cap phai nho hon hoac bang Han muc toi da cua KH tren Sysvar - han muc da duoc cap ---------------------------------
            v_strSQL = "SELECT VARVALUE FROM SYSVAR WHERE GRNAME = 'MARGIN' AND VARNAME = 'MAXDEBTCF'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count <= 0 Then
            Else
                v_dbMAXDEBTCF = v_ds.Tables(0).Rows(0)("VARVALUE")
                If v_dblAmount > v_dbMAXDEBTCF - v_dbGOTAMT Then
                    'han muc cap > han muc tran Sysvar - han muc da cap
                    Return ERR_SA_ALLOCATE_OVER_MRLOANLIMIT
                End If
            End If
            'TruongLD />

            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function CheckRetrieveMarginLimit(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CF.Trans.CheckAllocateMarginLimit", v_strErrorMessage As String
        Dim v_strSQL As String = String.Empty
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE, v_strCONFIRMPIN, v_strPIN As String, v_dblVALUE As Double
            Dim v_strACCTNO, v_strUserID As String
            Dim v_dblAmount, v_acclimit_user As Double   ' v_acclimit_user la muc toi da user co the cap cho 1 hop dong
            Dim v_DataAccess As New DataAccess, v_ds As DataSet

            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False

            'Ã„?Ã¡Â»?c nÃ¡Â»â„¢i dung giao dÃ¡Â»â€¹ch
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If

                    Select Case v_strFLDCD
                        Case "01" 'UserID
                            v_strUserID = v_strVALUE
                        Case "03" 'ACCTNO
                            v_strACCTNO = v_strVALUE
                        Case "10" 'ACCLIMIT
                            v_dblAmount = v_dblVALUE
                    End Select
                End With
            Next
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            ' ------------------------------------So hop dong phai active ----------- 
            v_strSQL = "Select AF.STATUS status from AFMAST AF, aftype a where AF.actype=a.actype and ACCTNO ='" + v_strACCTNO + "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows(0)("status") <> "A" Then ' 
                'so hop dong ko o active
                Return ERR_SA_ACCTNO_NOT_ACTIVE
            End If
            ' ------------------------------------So hop dong phai la hop dong margin ----------- 
            ''2010-07-09 - TruongLD commented 
            'v_strSQL = "Select Mr.mrtype MRTYPE from AFMAST AF, aftype a , MRtype MR  where  AF.actype=a.actype and a.MRTYPE  = MR.actype and ACCTNO ='" + v_strACCTNO + "'"
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'If v_ds.Tables(0).Rows(0)("MRTYPE") = "N" Then
            '    Return ERR_SA_ACCTNO_NOT_IN_MARGIN_TYPE
            'End If
            '-------------------------------------Kiem tra han muc thu hoi ko vuot qua han muc da cap--------------------------------------------------
            v_strSQL = "SELECT ACCLIMIT FROM USERAFLIMIT WHERE TYPERECEIVE='MR' and  TLIDUSER ='" & v_strUserID & "' and ACCTNO ='" + v_strACCTNO + "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count <= 0 Then ' Neu user chua cap lan nao ( se them moi chu ko update)
                If v_dblAmount < 0 Then
                    'chua cap da thu
                    Return ERR_SA_CAN_NOT_RETRIEVE
                End If
            Else  '-----------Neu nhu da cap
                If v_ds.Tables(0).Rows(0)("ACCLIMIT") - v_dblAmount < 0 Then
                    'Thu vuot qua so da cap 
                    Return ERR_SA_RETRIEVE_OVER_ALLOCATE
                End If
            End If
            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function



    Private Function CheckMarginContractCloseRequest(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CF.Trans.CheckAllocateMarginLimit", v_strErrorMessage As String
        Dim v_strSQL As String = String.Empty
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE, v_strCONFIRMPIN, v_strPIN As String, v_dblVALUE As Double
            Dim v_strACCTNO, v_dblODAMT, v_strUserID As String
            Dim v_dblAmount, v_acclimit_user As Double   ' v_acclimit_user la muc toi da user co the cap cho 1 hop dong
            Dim v_DataAccess As New DataAccess, v_ds As DataSet

            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False

            'Ã„?Ã¡Â»?c nÃ¡Â»â„¢i dung giao dÃ¡Â»â€¹ch
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If

                    Select Case v_strFLDCD
                        Case "03" 'ACCTNO
                            v_strACCTNO = v_strVALUE
                        Case "06" 'ODAMT
                            v_dblODAMT = v_dblVALUE
                    End Select



                End With
            Next

            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            v_strSQL = "Select Mr.mrtype MRTYPE from AFMAST AF, aftype a , MRtype MR  where  AF.actype=a.actype and a.MRTYPE  = MR.actype and ACCTNO ='" + v_strACCTNO + "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows(0)("MRTYPE") <> "N" Then
                '-----------------------------------------------------------Neu la hop dong margin thi check----------------------------------------------------
                ' ------------------------------------So hop dong phai active ----------- 
                v_strSQL = "Select AF.Status from AFMAST AF where acctno='" + v_strACCTNO + "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows(0)("status") <> "A" Then ' 
                    'so hop dong ko o active
                    Return ERR_SA_ACCTNO_NOT_ACTIVE
                End If
                ' ------------------------------------Kiem tra AF phai tat toan cac khoan vay ----------- 
                v_strSQL = "Select CI.odamt ODAMT from CIMAST CI where ACCTNO='" + v_strACCTNO + "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If Not IsDBNull(v_ds.Tables(0).Rows(0)) Then
                    If v_ds.Tables(0).Rows(0)("ODAMT") <> "0" Then ' Neu chua tat toan
                        Return ERR_SA_AF_HAVE_NOT_COMPLETE_PAYMENT
                    End If
                Else
                End If
                ' ------------------------------------Kiem tra AF ko o nhom margin nao ----------- 
                v_strSQL = " Select AF.acctno from AFMAST AF where AF.groupleader IS NULL and  acctno='" + v_strACCTNO + "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count <= 0 Then
                    Return ERR_SA_AF_IN_MARGIN_GROUP
                End If
                ' ------------------------------------Kiem tra AF da thu hoi het han muc chua ----------- 
                v_strSQL = " Select af.MRCRLIMITMAX  LIMITMAX from afmast af where af.acctno='" + v_strACCTNO + "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows(0)("LIMITMAX") <> 0 Then
                    Return ERR_SA_NOT_RETRIEVE_ALL_MARGIN_LIMIT
                End If
                ' ------------------------------------Kiem tra AF da thu hoi het han muc T0 chua ----------- 
                v_strSQL = " Select af.acctno from afmast af where af.advanceline =0 and af.T0AMT=0 and af.MRCRLIMIT=0 and af.acctno='" + v_strACCTNO + "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count <= 0 Then
                    Return ERR_SA_NOT_RETRIEVE_ALL_MARGIN_LIMIT_To
                End If
                ' ------------------------------------Kiem tra AF da thu hoi het han muc T0 chua ----------- 
                v_strSQL = " Select af.acctno from afmast af where af.MRCRLIMIT = 0 and af.acctno='" + v_strACCTNO + "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count <= 0 Then
                    Return ERR_SA_NOT_RETRIEVE_ALL_MRCRLIMIT_invalid
                End If
                '-------------------------------------------------------------AND CHECK-------------------------------------------------
            End If

            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function Check_ChangeIdcode(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CF.Trans.fncChangeAftype", v_strErrorMessage As String
        Dim v_strSQL As String = String.Empty
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE, v_strCONFIRMPIN, v_strPIN As String, v_dblVALUE As Double
            Dim v_strCUSTID, v_strIDCODE As String
            Dim v_DataAccess As New DataAccess, v_ds As DataSet

            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False

            'Ä?á»?c ná»™i dung giao dá»‹ch
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If

                    Select Case v_strFLDCD
                        Case "03" 'So HD
                            v_strCUSTID = v_strVALUE
                        Case "10"
                            v_strIDCODE = v_strVALUE
                    End Select
                End With
            Next

            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            'Kien tra co so du chung khoan niem yet, chung khoan niem yet cho ve
            v_strSQL = "SELECT * FROM CFMAST WHERE IDTYPE||IDCODE IN( SELECT IDTYPE|| '" & v_strIDCODE & "' FROM CFMAST where CUSTID ='" & v_strCUSTID & "' and status ='A' )"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                Return ERR_CF_IDCOE_DUPLICATE
            End If



            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function



    Private Function ChangeSystemBoundary(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CF.Trans.fncChangeAftype", v_strErrorMessage As String
        Dim v_strSQL As String = String.Empty
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE, v_strCONFIRMPIN, v_strPIN As String, v_dblVALUE As Double
            Dim v_strModcode, v_strEventCode As String
            Dim v_dblFlrRate, v_dblCelRate, v_dblCelAmt, v_dblFlrAmt As Double
            Dim v_DataAccess As New DataAccess, v_ds As DataSet

            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            Dim v_strTLID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTLID).Value
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If

                    Select Case v_strFLDCD
                        Case "01" 'Modcode
                            v_strModcode = v_strVALUE
                        Case "02" 'Eventcode
                            v_strEventCode = v_strVALUE
                        Case "10" 'Floor rate
                            v_dblFlrRate = v_dblVALUE
                        Case "11" 'Ceiling rate
                            v_dblCelRate = v_dblVALUE
                        Case "12" 'Floor Amount
                            v_dblFlrAmt = v_dblVALUE
                        Case "13" 'Ceiling amount
                            v_dblCelAmt = v_dblVALUE
                    End Select
                End With
            Next
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            v_strSQL = "SELECT * FROM APPEVENTS WHERE  MODCODE='" & v_strModcode & "' AND EVENTCODE='" & v_strEventCode & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If Not v_ds.Tables(0).Rows.Count > 0 Then
                Return ERR_SA_EVENT_DOESNOT_EXITS
            End If
            v_strSQL = "SELECT * FROM EVENTSYS WHERE  MODCODE='" & v_strModcode & "' AND EVENTCODE='" & v_strEventCode & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                'CAP NHAT DU LIEU, DAY THONG TIN VAO LOG
                v_strSQL = "INSERT INTO EVENTSYSLOG (txnum, txdate, modcode, eventcode, flrrate, celrate," _
                            & "flramt, celamt, deltd, status, createdby, createddt, " _
                            & "approvedby, approveddt)  " _
                            & "SELECT '" & v_strTXNUM & "' TXNUM,TO_DATE('" & v_strTXDATE & "','" & gc_FORMAT_DATE & "') TXDATE,modcode, eventcode, flrrate, celrate," _
                            & "flramt, celamt, deltd, status, createdby, createddt, " _
                            & "approvedby, approveddt FROM EVENTSYS WHERE  MODCODE='" & v_strModcode & "' AND EVENTCODE='" & v_strEventCode & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                v_strSQL = "UPDATE EVENTSYS SET flrrate=" & v_dblFlrRate & ",celrate=" & v_dblCelRate & ",flramt=" & v_dblFlrAmt & ",celamt=" & v_dblCelAmt _
                            & ", createdby='" & v_strTLID & "',createddt=SYSDATE,approvedby='" & v_strOFFID & "',approveddt=SYSDATE " _
                            & " WHERE  MODCODE='" & v_strModcode & "' AND EVENTCODE='" & v_strEventCode & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            Else
                'KHAI BAO DU LIEU MOI
                v_strSQL = "INSERT INTO EVENTSYS (modcode, eventcode, flrrate, celrate," _
                            & "flramt, celamt, deltd, status, createdby, createddt, " _
                            & "approvedby, approveddt)  " _
                            & "VALUES ('" & v_strModcode & "', '" & v_strEventCode & "', " & v_dblFlrRate & ", " & v_dblCelRate & "," _
                            & "" & v_dblFlrAmt & ", " & v_dblCelAmt & ", 'N', 'A', '" & v_strTLID & "', SYSDATE, " _
                            & "'" & v_strOFFID & "', SYSDATE) "
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End If
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function ChangeCustomizeAmplitude(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CF.Trans.ChangeCustomizeAmplitude", v_strErrorMessage As String
        Dim v_strSQL As String = String.Empty
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE, v_strCONFIRMPIN, v_strPIN As String, v_dblVALUE As Double
            Dim v_strModcode, v_strEventCode, v_strActype As String
            Dim v_dblFlrRate, v_dblCelRate, v_dblCelAmt, v_dblFlrAmt As Double
            Dim v_DataAccess As New DataAccess, v_ds As DataSet

            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            Dim v_strTLID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTLID).Value
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If

                    Select Case v_strFLDCD
                        Case "01" 'Modcode
                            v_strModcode = v_strVALUE
                        Case "02" 'Eventcode
                            v_strEventCode = v_strVALUE
                        Case "03" 'Eventcode
                            v_strActype = v_strVALUE
                        Case "10" 'Floor amplitude
                            v_dblFlrRate = v_dblVALUE
                        Case "11" 'Ceiling amplitude
                            v_dblCelRate = v_dblVALUE
                    End Select
                End With
            Next
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            v_strSQL = "SELECT * FROM APPEVENTS WHERE  MODCODE='" & v_strModcode & "' AND EVENTCODE='" & v_strEventCode & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If Not v_ds.Tables(0).Rows.Count > 0 Then
                Return ERR_SA_EVENT_DOESNOT_EXITS
            End If
            v_strSQL = "SELECT * FROM AFTYPE WHERE  ACTYPE='" & v_strActype & "' "
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If Not v_ds.Tables(0).Rows.Count > 0 Then
                Return ERR_CF_AFTYPE_NOTFOUND
            End If
            v_strSQL = "SELECT * FROM TYPELINE WHERE  MODCODE='" & v_strModcode & "' AND EVENTCODE='" & v_strEventCode & "' AND ACTYPE='" & v_strActype & "' "
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                'CAP NHAT DU LIEU, DAY THONG TIN VAO LOG
                v_strSQL = "INSERT INTO TYPELINELOG (txnum, txdate, modcode, eventcode,actype, flooramp, ceilamp, " _
                            & "deltd, status, createdby, createddt, " _
                            & "approvedby, approveddt)  " _
                            & "SELECT '" & v_strTXNUM & "' TXNUM,TO_DATE('" & v_strTXDATE & "','" & gc_FORMAT_DATE & "') TXDATE,modcode, eventcode,actype, flooramp, ceilamp," _
                            & " deltd, status, createdby, createddt, " _
                            & "approvedby, approveddt FROM TYPELINE WHERE  MODCODE='" & v_strModcode & "' AND EVENTCODE='" & v_strEventCode & "' AND ACTYPE='" & v_strActype & "' "
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                v_strSQL = "UPDATE TYPELINE SET flooramp=" & v_dblFlrRate & ",ceilamp=" & v_dblCelRate _
                            & ", createdby='" & v_strTLID & "',createddt=SYSDATE,approvedby='" & v_strOFFID & "',approveddt=SYSDATE " _
                            & " WHERE  MODCODE='" & v_strModcode & "' AND EVENTCODE='" & v_strEventCode & "' AND ACTYPE='" & v_strActype & "' "
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            Else
                'KHAI BAO DU LIEU MOI
                v_strSQL = "INSERT INTO TYPELINE (modcode, eventcode,actype, flooramp, ceilamp," _
                            & " deltd, status, createdby, createddt, " _
                            & "approvedby, approveddt)  " _
                            & "VALUES ('" & v_strModcode & "', '" & v_strEventCode & "', '" & v_strActype & "', " & v_dblFlrRate & ", " & v_dblCelRate & "," _
                            & " 'N', 'A', '" & v_strTLID & "', SYSDATE, " _
                            & "'" & v_strOFFID & "', SYSDATE) "
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End If
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function CustomizeICCF(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CF.Trans.CustomizeICCF", v_strErrorMessage As String
        Dim v_strSQL As String = String.Empty
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE, v_strCONFIRMPIN, v_strPIN As String, v_dblVALUE As Double
            Dim v_strModcode, v_strEventCode, v_strAFACCTNO, v_strEFFECTIVEDT, v_strEXPDATE, v_strEXTYPE, v_strOPERAND As String
            Dim v_dblDelta As Double
            Dim v_DataAccess As New DataAccess, v_ds As DataSet

            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            Dim v_strTLID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTLID).Value
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If

                    Select Case v_strFLDCD
                        Case "01" 'Modcode
                            v_strModcode = v_strVALUE
                        Case "02" 'Eventcode
                            v_strEventCode = v_strVALUE
                        Case "03" 'AFACCTNO
                            v_strAFACCTNO = v_strVALUE
                        Case "08" 'EFFECTIVEDT
                            v_strEFFECTIVEDT = v_strVALUE
                        Case "09" 'EXPDATE
                            v_strEXPDATE = v_strVALUE
                        Case "10" 'EXTYPE
                            v_strEXTYPE = v_strVALUE
                        Case "11" 'OPERAND
                            v_strOPERAND = v_strVALUE
                        Case "12" 'DELTA
                            v_dblDelta = v_dblVALUE
                    End Select
                End With
            Next
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            v_strSQL = "SELECT * FROM APPEVENTS WHERE  MODCODE='" & v_strModcode & "' AND EVENTCODE='" & v_strEventCode & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If Not v_ds.Tables(0).Rows.Count > 0 Then
                Return ERR_SA_EVENT_DOESNOT_EXITS
            End If
            If DDMMYYYY_SystemDate(v_strEFFECTIVEDT) <= DDMMYYYY_SystemDate(v_strTXDATE) Then
                'Insert vao EXAFMAST
                v_strSQL = " INSERT INTO exafmast " &
                        "(AUTOID,EVENTCODE,AFACCTNO,EXPDATE,EXCYCLE,OPERAND,DELTA,MINVAL,MAXVAL,STATUS,CURRRATE,EFFECTIVEDT,EXTYPE,MODCODE)" &
                        " VALUES " &
                        "(SEQ_exafmast.NEXTVAL,'" & v_strEventCode & "','" & v_strAFACCTNO & "',TO_DATE('" & v_strEXPDATE & "','" & gc_FORMAT_DATE & "'),NULL,'" & v_strOPERAND & "'," & v_dblDelta & ",NULL,NULL,'C',NULL,TO_DATE('" & v_strEFFECTIVEDT & "','" & gc_FORMAT_DATE & "'),'" & v_strEXTYPE & "','" & v_strModcode & "')"
            Else
                'Insert vao EXAFSCHD
                v_strSQL = " INSERT INTO exafschd " &
                        "(AUTOID,EVENTCODE,AFACCTNO,EXPDATE,EXCYCLE,OPERAND,DELTA,MINVAL,MAXVAL,STATUS,CURRRATE,EFFECTIVEDT,EXTYPE,MODCODE)" &
                        " VALUES " &
                        "(SEQ_exafschd.NEXTVAL,'" & v_strEventCode & "','" & v_strAFACCTNO & "',TO_DATE('" & v_strEXPDATE & "','" & gc_FORMAT_DATE & "'),NULL,'" & v_strOPERAND & "'," & v_dblDelta & ",NULL,NULL,'C',NULL,TO_DATE('" & v_strEFFECTIVEDT & "','" & gc_FORMAT_DATE & "'),'" & v_strEXTYPE & "','" & v_strModcode & "')"
            End If
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function ChangeAuthorizeInfo(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CF.Trans.ChangeAuthorizeInfo", v_strErrorMessage As String
        Dim v_strSQL As String = String.Empty
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE, v_strCONFIRMPIN, v_strPIN As String, v_dblVALUE As Double
            Dim v_strACCTNO, v_strAUTHID, v_strAUTHNAME, v_strLICENSE, v_strVALDATE, v_strEXPDATE, v_strVIEWS, v_strRPT, v_strCASH, v_strBUY, v_strSELL, v_strSIGN, v_strTRANSFER, v_strBANKACC, v_strBANKNAME, v_strAUTHSERVED5, v_strAUTHSERVED6, v_strRIGHTOFF As String
            Dim v_DataAccess As New DataAccess, v_ds As DataSet

            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            Dim v_strTLID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTLID).Value
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If

                    Select Case v_strFLDCD
                        Case "03" 'ACCTNO
                            v_strACCTNO = v_strVALUE
                        Case "05" 'AUTHID
                            v_strAUTHID = v_strVALUE
                        Case "06" 'AUTHNAME
                            v_strAUTHNAME = v_strVALUE
                        Case "07" 'LICENSE
                            v_strLICENSE = v_strVALUE
                        Case "08" 'VALDATE
                            v_strVALDATE = v_strVALUE
                        Case "09" 'EXPDATE
                            v_strEXPDATE = v_strVALUE
                        Case "10" 'VIEWS
                            v_strVIEWS = v_strVALUE
                        Case "11" 'RPT
                            v_strRPT = v_strVALUE
                        Case "12" 'CASH
                            v_strCASH = v_strVALUE
                        Case "13" 'BUY
                            v_strBUY = v_strVALUE
                        Case "14" 'SELL
                            v_strSELL = v_strVALUE
                        Case "15" 'SIGN
                            v_strSIGN = v_strVALUE
                        Case "16" 'TRANSFER
                            v_strTRANSFER = v_strVALUE
                        Case "17" 'AUTHSERVED5
                            v_strAUTHSERVED5 = v_strVALUE
                        Case "18" 'RIGHTOFF
                            v_strRIGHTOFF = v_strVALUE
                        Case "19" 'AUTHSERVED6
                            v_strAUTHSERVED6 = v_strVALUE
                        Case "20" 'BANKACC
                            v_strBANKACC = v_strVALUE
                        Case "21" 'BANKNAME
                            v_strBANKNAME = v_strVALUE
                    End Select
                End With
            Next
            Dim v_obj As New DataAccess
            Dim v_strLINKAUTH As String
            v_strLINKAUTH = v_strVIEWS & v_strRPT & v_strCASH & v_strBUY & v_strSELL & v_strSIGN & v_strTRANSFER & v_strAUTHSERVED5 & v_strRIGHTOFF & v_strAUTHSERVED6
            v_obj.NewDBInstance(gc_MODULE_HOST)
            v_strSQL = "SELECT * FROM CFAUTH WHERE  ACCTNO='" & v_strACCTNO & "' AND CUSTID='" & v_strAUTHID & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                'Update thong tin
                v_strSQL = "UPDATE CFAUTH SET LINKAUTH='" & v_strLINKAUTH & "',FULLNAME='" & v_strAUTHNAME & "',LICENSENO='" & v_strLICENSE & "',VALDATE=TO_DATE('" & v_strVALDATE & "','" & gc_FORMAT_DATE & "'),EXPDATE=TO_DATE('" & v_strEXPDATE & "','" & gc_FORMAT_DATE & "'),BANKACCOUNT='" & v_strBANKACC & "',BANKNAME='" & v_strBANKNAME & "' WHERE  ACCTNO='" & v_strACCTNO & "' AND CUSTID='" & v_strAUTHID & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            Else
                'Them moi thong tin
                Return ERR_CF_CFAUTH_CUSTID_NOTFOUND
            End If
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function InsertAuthorizeInfo(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CF.Trans.InsertAuthorizeInfo", v_strErrorMessage As String
        Dim v_strSQL As String = String.Empty
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE, v_strCONFIRMPIN, v_strPIN As String, v_dblVALUE As Double
            Dim v_strACCTNO, v_strAUTHID, v_strAUTHNAME, v_strLICENSE, v_strVALDATE, v_strEXPDATE, v_strVIEWS, v_strRPT, v_strCASH, v_strBUY, v_strSELL, v_strSIGN, v_strTRANSFER, v_strBANKACC, v_strBANKNAME, v_strADDRESS, v_strTELEPHONE, v_strACCOUNTNAME, v_strSIGNATURE, v_strAuthReserved5, v_strAuthReserved6, v_strRIGHTOFF As String
            Dim v_strLNPLACE, v_strLNDATE, strLNIDDATE As String
            Dim v_DataAccess As New DataAccess, v_ds As DataSet

            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            Dim v_strTLID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTLID).Value
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If

                    Select Case v_strFLDCD
                        Case "03" 'ACCTNO
                            v_strACCTNO = v_strVALUE
                        Case "05" 'AUTHID
                            v_strAUTHID = v_strVALUE
                        Case "06" 'AUTHNAME
                            v_strAUTHNAME = v_strVALUE
                        Case "07" 'ADDRESS
                            v_strADDRESS = v_strVALUE
                        Case "08" 'TELEPHONE
                            v_strTELEPHONE = v_strVALUE
                        Case "09" 'LICENSENO
                            v_strLICENSE = v_strVALUE
                        Case "10" 'VALDATE
                            v_strVALDATE = v_strVALUE
                        Case "11" 'EXPDATE
                            v_strEXPDATE = v_strVALUE
                        Case "12" 'VIEWS
                            v_strVIEWS = v_strVALUE
                        Case "13" 'RPT
                            v_strRPT = v_strVALUE
                        Case "14" 'CASH
                            v_strCASH = v_strVALUE
                        Case "15" 'BUY
                            v_strBUY = v_strVALUE
                        Case "16" 'SELL
                            v_strSELL = v_strVALUE
                        Case "17" 'SIGN
                            v_strSIGN = v_strVALUE
                        Case "18" 'TRANSFER
                            v_strTRANSFER = v_strVALUE
                        Case "19" 'AUTH_RESERVERD5
                            v_strAuthReserved5 = v_strVALUE
                        Case "20" 'RIGHTOFF
                            v_strRIGHTOFF = v_strVALUE
                        Case "21" 'AUTH_RESERVERD6
                            v_strAuthReserved6 = v_strVALUE
                        Case "22" 'SIGN
                            v_strSIGNATURE = v_strVALUE
                        Case "23" 'ACCOUNTNAME
                            v_strACCOUNTNAME = v_strVALUE
                        Case "24" 'BANKACC
                            v_strBANKACC = v_strVALUE
                        Case "25" 'BANKNAME
                            v_strBANKNAME = v_strVALUE
                            'huynq
                        Case "41" 'LNPLACE
                            v_strLNPLACE = v_strVALUE
                        Case "42" 'LNIDDATE
                            strLNIDDATE = v_strVALUE

                            'end huynq
                    End Select
                End With
            Next
            Dim v_obj As New DataAccess
            Dim v_strLINKAUTH As String
            v_strLINKAUTH = v_strVIEWS & v_strRPT & v_strCASH & v_strBUY & v_strSELL & v_strSIGN & v_strTRANSFER & v_strAuthReserved5 & v_strRIGHTOFF & v_strAuthReserved6
            v_obj.NewDBInstance(gc_MODULE_HOST)
            v_strSQL = "SELECT * FROM CFAUTH WHERE  ACCTNO='" & v_strACCTNO & "' AND CUSTID='" & v_strAUTHID & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                'Neu ton tai thi bao loi
                Return ERR_CF_CFAUTH_CUSTID_EXISTED
            Else
                'Them moi thong tin
                v_strSQL = "INSERT INTO CFAUTH(AUTOID,ACCTNO,CUSTID,FULLNAME,ADDRESS,TELEPHONE,LICENSENO,VALDATE,EXPDATE,DELTD,LINKAUTH,SIGNATURE,ACCOUNTNAME,BANKACCOUNT,BANKNAME,LNPLACE,LNIDDATE)" & vbCrLf &
                           "VALUES(SEQ_CFAUTH.NEXTVAL,'" & v_strACCTNO & "','" & v_strAUTHID & "','" & v_strAUTHNAME & "','" & v_strADDRESS & "','" & v_strTELEPHONE & "','" & v_strLICENSE & "',TO_DATE('" & v_strVALDATE & "','" & gc_FORMAT_DATE & "'),TO_DATE('" & v_strEXPDATE & "','" & gc_FORMAT_DATE & "'),'" & v_strDELTD & "','" & v_strLINKAUTH & "','" & v_strSIGNATURE & "','" & v_strACCOUNTNAME & "','" & v_strBANKACC & "','" & v_strBANKNAME & "','" & v_strLNPLACE & "'" & ", TO_DATE('" & strLNIDDATE & "','" & gc_FORMAT_DATE & "') )"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End If
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function InsertAllocateMarginLimit(ByRef pv_xmlDocument As Xml.XmlDocument) As Long ' 
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CF.Trans.InsertAuthorizeInfo", v_strErrorMessage As String
        Dim v_strSQL As String = String.Empty
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE, v_strCONFIRMPIN, v_strPIN As String, v_dblVALUE As Double
            Dim v_strACCTNO, v_strAUTHID, v_strAUTHNAME, v_strLICENSE, v_strVALDATE, v_strEXPDATE, v_strVIEWS, v_strRPT, v_strCASH, v_strBUY, v_strSELL, v_strSIGN, v_strTRANSFER, v_strBANKACC, v_strBANKNAME, v_strADDRESS, v_strTELEPHONE, v_strACCOUNTNAME, v_strSIGNATURE, v_strAuthReserved5, v_strAuthReserved6, v_strRIGHTOFF As String
            Dim v_DataAccess As New DataAccess, v_ds As DataSet
            Dim v_strUserID, v_strUsertype As String
            Dim v_dblAmount, v_update_to_user_Limit As Double

            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            Dim v_strTLID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTLID).Value
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If

                    Select Case v_strFLDCD
                        Case "01" 'UserID
                            v_strUserID = v_strVALUE
                        Case "02" 'Usertype
                            v_strUsertype = v_strVALUE
                        Case "03" 'ACCTNO
                            v_strACCTNO = v_strVALUE
                        Case "10" 'ACCLIMIT
                            v_dblAmount = v_dblVALUE
                    End Select
                End With
            Next
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            If Not v_blnReversal Then 'Lam giao dich chieu xuoi
                v_strSQL = "SELECT * FROM USERAFLIMIT WHERE TYPERECEIVE='MR' AND ACCTNO='" & v_strACCTNO & "' AND TLIDUSER='" & v_strUserID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                ' cap nhat du lieu vao bang useraflimit
                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_strSQL = "UPDATE USERAFLIMIT " &
                                 "SET ACCLIMIT = ACCLIMIT + '" & v_dblAmount & "'" &
                                 " WHERE TYPERECEIVE='MR' and  ACCTNO ='" & v_strACCTNO & "' and TLIDUSER = '" & v_strUserID & "'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                Else
                    'Them moi thong tin
                    v_strSQL = "INSERT INTO USERAFLIMIT(ACCTNO,ACCLIMIT,TLIDUSER,TYPEALLOCATE,TYPERECEIVE)" & vbCrLf &
                               "VALUES('" & v_strACCTNO & "','" & v_dblAmount & "','" & v_strUserID & "','" & v_strUsertype & "','MR')"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                End If

                'Cap nhat du lieu vao bang userlimit
                v_strSQL = "UPDATE USERLIMIT " &
                                 "SET USEDLIMMIT = USEDLIMMIT + '" & v_dblAmount & "'" &
                                 " WHERE TLIDUSER ='" & v_strUserID & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                ' Cap nhat vao bang useraflimitlog
                v_strSQL = "INSERT INTO USERAFLIMITLOG(TXDATE,TXNUM,ACCTNO,ACCLIMIT,TLIDUSER,TYPEALLOCATE,TYPERECEIVE)" & vbCrLf &
                             "VALUES(" & "TO_DATE('" & v_strTXDATE & "','" & gc_FORMAT_DATE & "')" & ",'" & v_strTXNUM & "','" & v_strACCTNO & "','" & v_dblAmount & "','" & v_strUserID & "','" & v_strUsertype & "','MR')"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            Else
                'Trong truong hop xoa giao dich
            End If

            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function InsertRetrieveMarginLimit(ByRef pv_xmlDocument As Xml.XmlDocument) As Long ' 
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CF.Trans.InsertAuthorizeInfo", v_strErrorMessage As String
        Dim v_strSQL As String = String.Empty
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE, v_strCONFIRMPIN, v_strPIN As String, v_dblVALUE As Double
            Dim v_strACCTNO, v_strAUTHID, v_strAUTHNAME, v_strLICENSE, v_strVALDATE, v_strEXPDATE, v_strVIEWS, v_strRPT, v_strCASH, v_strBUY, v_strSELL, v_strSIGN, v_strTRANSFER, v_strBANKACC, v_strBANKNAME, v_strADDRESS, v_strTELEPHONE, v_strACCOUNTNAME, v_strSIGNATURE, v_strAuthReserved5, v_strAuthReserved6, v_strRIGHTOFF As String
            Dim v_DataAccess As New DataAccess, v_ds As DataSet
            Dim v_strUserID As String
            Dim v_dblAmount, v_update_to_user_Limit As Double

            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            Dim v_strTLID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTLID).Value
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If

                    Select Case v_strFLDCD
                        Case "01" 'UserID
                            v_strUserID = v_strVALUE
                        Case "03" 'ACCTNO
                            v_strACCTNO = v_strVALUE
                        Case "10" 'ACCLIMIT
                            v_dblAmount = v_dblVALUE
                    End Select
                End With
            Next
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            If Not v_blnReversal Then 'Lam giao dich chieu xuoi
                v_strSQL = "SELECT * FROM USERAFLIMIT WHERE TYPERECEIVE='MR' AND ACCTNO='" & v_strACCTNO & "' AND TLIDUSER='" & v_strUserID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                ' cap nhat du lieu vao bang useraflimit
                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_strSQL = "UPDATE USERAFLIMIT " &
                                 "SET ACCLIMIT = ACCLIMIT - '" & v_dblAmount & "'" &
                                 " WHERE  TYPERECEIVE='MR' AND ACCTNO ='" & v_strACCTNO & "' and TLIDUSER = '" & v_strUserID & "'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                Else
                    'Them moi thong tin
                    v_strSQL = "INSERT INTO USERAFLIMIT(ACCTNO,ACCLIMIT,TLIDUSER,TYPERECEIVE)" & vbCrLf &
                               "VALUES('" & v_strACCTNO & "','" & v_dblAmount & "','" & v_strUserID & "','MR')"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                End If

                'Cap nhat du lieu vao bang userlimit
                v_strSQL = "UPDATE USERLIMIT " &
                                 "SET USEDLIMMIT = USEDLIMMIT - '" & v_dblAmount & "'" &
                                 " WHERE TLIDUSER ='" & v_strUserID & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                ' Cap nhat vao bang useraflimitlog
                v_strSQL = "INSERT INTO USERAFLIMITLOG(TXDATE,TXNUM,ACCTNO,ACCLIMIT,TLIDUSER,TYPERECEIVE)" & vbCrLf &
                             "VALUES(" & "TO_DATE('" & v_strTXDATE & "','" & gc_FORMAT_DATE & "')" & ",'" & v_strTXNUM & "','" & v_strACCTNO & "','" & -1 * v_dblAmount & "','" & v_strUserID & "','MR')"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            Else
                'Trong truong hop xoa giao dich
            End If

            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function DeleteAuthorizeInfo(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CF.Trans.DeleteAuthorizeInfo", v_strErrorMessage As String
        Dim v_strSQL As String = String.Empty
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE, v_strCONFIRMPIN, v_strPIN As String, v_dblVALUE As Double
            Dim v_strACCTNO, v_strAUTHID As String
            Dim v_DataAccess As New DataAccess, v_ds As DataSet

            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            Dim v_strTLID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTLID).Value
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If

                    Select Case v_strFLDCD
                        Case "03" 'ACCTNO
                            v_strACCTNO = v_strVALUE
                        Case "05" 'AUTHID
                            v_strAUTHID = v_strVALUE
                    End Select
                End With
            Next
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            v_strSQL = "SELECT * FROM CFAUTH WHERE  ACCTNO='" & v_strACCTNO & "' AND CUSTID='" & v_strAUTHID & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                'Xoa moi thong tin
                v_strSQL = "DELETE FROM CFAUTH WHERE ACCTNO='" & v_strACCTNO & "' AND CUSTID='" & v_strAUTHID & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            Else
                'Neu khong ton tai thi bao loi
                Return ERR_CF_CFAUTH_CUSTID_NOTFOUND
            End If
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function ConfirmAFTYPE(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CF.Trans.fncChangeAftype", v_strErrorMessage As String
        Dim v_strSQL As String = String.Empty
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE, v_strCONFIRMPIN, v_strPIN As String, v_dblVALUE As Double
            Dim v_strACTYPE, v_strAction, v_strApproveCD As String
            Dim v_DataAccess As New DataAccess, v_ds As DataSet

            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False

            'Ä?á»?c ná»™i dung giao dá»‹ch
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If

                    Select Case v_strFLDCD
                        Case "03" 'Type
                            v_strACTYPE = v_strVALUE
                        Case "07" 'Action
                            v_strAction = v_strVALUE
                    End Select
                End With
            Next

            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Select Case v_strAction
                Case "Approve"
                    v_strApproveCD = "A"
                Case "Reject"
                    v_strApproveCD = "R"
                Case "Refuse"
                    v_strApproveCD = "E"
            End Select
            v_strSQL = "SELECT * FROM AFTYPE WHERE  ACTYPE ='" & v_strACTYPE & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                'CAP NHAT HAN MUC
                v_strSQL = "UPDATE AFTYPE " &
                            "SET APPROVECD = '" & v_strApproveCD & "'" &
                            " WHERE ACTYPE ='" & v_strACTYPE & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            Else
                Return ERR_CF_AFTYPE_NOTFOUND
            End If
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function GetCUSTODYCD() As String
        Try
            Dim v_lngErrCode As Long = ERR_SYSTEM_OK
            Dim v_strSYSVAR, v_strSQL As String
            Dim v_DataAccess As New DataAccess, v_ds As DataSet
            v_DataAccess.NewDBInstance(gc_MODULE_HOST)
            v_lngErrCode = v_DataAccess.GetSysVar("SYSTEM", "COMPANYCD", v_strSYSVAR)
            v_strSQL = "SELECT SUBSTR(INVACCT,1,4), MAX(ODR)+1 AUTOINV FROM " & ControlChars.CrLf _
                           & "(SELECT ROWNUM ODR, INVACCT " & ControlChars.CrLf _
                           & "FROM (SELECT CUSTODYCD INVACCT FROM CFMAST WHERE SUBSTR(CUSTODYCD,1,3)='" & v_strSYSVAR & "' AND TRIM(TO_CHAR(TRANSLATE(SUBSTR(CUSTODYCD,5,6),'0123456789',' '))) IS NULL ORDER BY CUSTODYCD) DAT " & ControlChars.CrLf _
                           & "WHERE TO_NUMBER(SUBSTR(INVACCT,5,6))=ROWNUM) INVTAB " & ControlChars.CrLf _
                           & "GROUP BY SUBSTR(INVACCT,1,4)"

            v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            Return CStr(v_ds.Tables(0).Rows(0)("AUTOINV"))
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function CloseRequest(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CF.Trans.CloseContract", v_strErrorMessage As String
        Dim v_strSQL As String = String.Empty
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE As Double
            Dim v_strAFACCTNO, v_dblSumREPO As String
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_ds As DataSet
            Dim v_dblSumSEDETAIL, v_dblDTOCLOSE, v_dblSDTOCLOSE As Int64
            Dim v_strSEACCTNO As String
            Dim v_dblSumCI As Double
            Dim v_dblSumSE As Double
            Dim v_dblODINT As Double
            Dim v_dblODAMT As Double
            Dim v_strStatus As String
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False
            'Ä?á»?c ná»™i dung giao dá»‹ch
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If

                    Select Case v_strFLDCD
                        Case "03" 'AFACCTNO
                            v_strAFACCTNO = v_strVALUE
                        Case "05" 'ODINT
                            v_dblODINT = v_dblVALUE
                        Case "06" 'ODAMT
                            v_dblODINT = v_dblVALUE
                    End Select
                End With
            Next

            'check se SENDDEPOSIT

            v_strSQL = "Select  sum( NVL(SENDDEPOSIT,0))) SENDDEPOSIT  from semast where AFACCTNO='" & v_strAFACCTNO & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

            If IIf(IsDBNull(v_ds.Tables(0).Rows(0)("SENDDEPOSIT")), -1, v_ds.Tables(0).Rows(0)("SENDDEPOSIT")) > 0 Then

                v_lngErrCode = ERR_CF_SENDDEPOSIT
                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                             & "Error code: Reversal." & v_blnReversal.ToString() & "." & v_strAFACCTNO & "." & vbNewLine _
                             & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                Return v_lngErrCode

            End If




            'Thay doi trang thai SE sang pending to close
            v_strSQL = "Select (NVL(MORTAGE,0)+ NVL(TRADE,0)+NVL(DTOCLOSE,0) +NVL(MARGIN,0)+NVL(NETTING,0)+NVL(STANDING,0)+NVL(SECURED,0)+ NVL(WITHDRAW,0)+NVL(DEPOSIT,0)+NVL(LOAN,0)+NVL(BLOCKED,0)+NVL(REPO,0)+ NVL(PENDING,0)+NVL(TRANSFER,0) + NVL(SENDDEPOSIT,0)) SUMSEDETAIL,ACCTNO  from semast where AFACCTNO='" & v_strAFACCTNO & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                For j As Integer = 0 To v_ds.Tables(0).Rows.Count - 1
                    v_dblSumSEDETAIL = IIf(IsDBNull(v_ds.Tables(0).Rows(j)("SUMSEDETAIL")), -1, v_ds.Tables(0).Rows(j)("SUMSEDETAIL"))
                    v_strSEACCTNO = IIf(IsDBNull(v_ds.Tables(0).Rows(j)("ACCTNO")), "-1", v_ds.Tables(0).Rows(j)("ACCTNO"))
                    If v_dblSumSEDETAIL = 0 Then
                        v_strSQL = "UPDATE SEMAST SET STATUS='N',PSTATUS=PSTATUS || STATUS,LASTDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') WHERE ACCTNO='" & v_strSEACCTNO & "'"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                    End If
                Next
            End If

            'Kiem tra neu tai khoan la margin co ky han thi neu ODINT + ODAMT > 0 thi khong cho lam.
            'Bat phai tra no het theo ky han thi moi duoc lam
            If v_dblODINT + v_dblODAMT > 0 Then
                v_strSQL = "SELECT MT.MRTYPE FROM AFMAST AF, AFTYPE AT, MRTYPE MT  where AF.ACCTNO='" & v_strAFACCTNO & "' AND AF.ACTYPE =AT.ACTYPE AND AT.MRTYPE = MT.ACTYPE AND MT.MRTYPE ='T'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    'BAO LOI
                    v_lngErrCode = ERR_CF_ACCOUNT_MARGIN_TERM_HAS_DUE
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: Reversal." & v_blnReversal.ToString() & "." & v_strAFACCTNO & "." & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If
            End If
            'End If
            If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
    Private Function CompleteCloseComtract(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CF.Trans.CompleteCloseComtract", v_strErrorMessage As String
        Dim v_obj As New DataAccess, v_ds As DataSet
        Dim v_strSQL As String = String.Empty, i As Integer
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE, v_dblQTTY, v_dblSUMSDTC, v_dblSUMDTC As Double
            Dim v_strCODEID, v_strAPPLID, v_strSEACCTNO, v_strDESC, v_strAFACCTNO, v_strACCTNO As String
            Dim v_dblDEPOSITQTTY, v_dblDEPOSITPRICE, v_roundValue As Double
            Dim v_dblSumSEDETAIL, v_dblDTOCLOSE, v_dblSDTOCLOSE As Int64
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False
            v_obj.NewDBInstance(gc_MODULE_HOST)
            'Ä?á»?c ná»™i dung giao dá»‹ch
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If

                    Select Case v_strFLDCD
                        Case "01" 'CODEID
                            v_strCODEID = v_strVALUE
                        Case "02" 'AFACCTNO
                            v_strAFACCTNO = v_strVALUE
                        Case "03" 'ACCTNO
                            v_strACCTNO = v_strVALUE
                    End Select
                End With
            Next
            ''Chuyen trang thai dong voi  SE
            ''Kiem tra neu thoa mam dieu kien moi thuc hien
            ''Kiem tra tien 
            'v_strSQL = "SELECT (ROUND(BALANCE,0)+ ROUND(FLOATAMT,0)) CIBALANCE FROM CIMAST WHERE ACCTNO= '" & v_strAFACCTNO & "'"
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'If v_ds.Tables(0).Rows.Count > 0 Then
            '    Dim CIBALANCE As Double = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("CIBALANCE")), 0, v_ds.Tables(0).Rows(0)("CIBALANCE"))
            '    If CIBALANCE > 0 Then
            '        v_lngErrCode = ERR_SE_CIBALANCE 'Van con so du CI
            '    Else
            '        v_strSQL = "UPDATE CIMAST SET STATUS='C',PSTATUS=PSTATUS || STATUS,LASTDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') WHERE ACCTNO='" & v_strAFACCTNO & "'"
            '        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            '        v_strSQL = "UPDATE AFMAST SET STATUS='C',PSTATUS=PSTATUS || STATUS,LASTDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') WHERE ACCTNO='" & v_strAFACCTNO & "'"
            '        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            '    End If
            'End If
            If Not v_blnReversal Then

                v_strSQL = " select  * from tllog where tltxcd ='1100' and deltd <>'Y' and TXSTATUS in ('3','4','5') and MSGACCT ='" & v_strAFACCTNO & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_lngErrCode = gc_OD_CI_1100_IS_NOT_COMPLETE
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If




                'Check SE
                v_strSQL = "Select (NVL(MORTAGE,0)+ NVL(TRADE,0)+NVL(DTOCLOSE,0) +NVL(MARGIN,0)+NVL(NETTING,0)+NVL(STANDING,0)+NVL(SECURED,0)+NVL(RECEIVING,0)+ NVL(WITHDRAW,0)+NVL(DEPOSIT,0)+NVL(SENDDEPOSIT,0)+NVL(LOAN,0)+NVL(BLOCKED,0)+NVL(REPO,0)+ NVL(PENDING,0)+NVL(TRANSFER,0)) SUMSEDETAIL,ACCTNO,sb.SECTYPE, SE.CODEID  from semast se, sbsecurities sb  where AFACCTNO='" & v_strAFACCTNO & "'  AND se.codeid = sb.codeid "
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    For j As Integer = 0 To v_ds.Tables(0).Rows.Count - 1

                        v_dblSumSEDETAIL = IIf(IsDBNull(v_ds.Tables(0).Rows(j)("SUMSEDETAIL")), -1, v_ds.Tables(0).Rows(j)("SUMSEDETAIL"))
                        v_strSEACCTNO = IIf(IsDBNull(v_ds.Tables(0).Rows(j)("ACCTNO")), "-1", v_ds.Tables(0).Rows(j)("ACCTNO"))
                        If v_dblSumSEDETAIL > 0 Then
                            If v_ds.Tables(0).Rows(j)("SECTYPE") = "004" Then
                                v_strSQL = "SELECT count(1) FROM caschd s, camast c WHERE s.afacctno = '" & v_strAFACCTNO & "' AND s.camastid = c.camastid AND actiondate >= (SELECT to_date(varvalue,'DD/MM/RRRR') FROM sysvar WHERE varname = 'CURRDATE') and s.excodeid = '" & v_ds.Tables(0).Rows(j)("CODEID") & "'"
                                Dim v_dsCA As DataSet = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                                If v_dsCA.Tables(0).Rows(0)(0) <> "0" Then
                                    v_lngErrCode = ERR_SE_EXSIT
                                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                                    Return v_lngErrCode
                                End If
                            Else
                                v_lngErrCode = ERR_SE_EXSIT
                                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                             & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                             & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                                Return v_lngErrCode
                            End If
                        End If
                    Next
                End If

                'Check CI
                v_strSQL = "SELECT VARVALUE FROM  SYSVAR WHERE GRNAME ='SYSTEM' AND VARNAME ='ROUND_VALUE'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_roundValue = v_ds.Tables(0).Rows(0)("VARVALUE")
                Else
                    v_roundValue = 0
                End If

                v_strSQL = "SELECT  (TRUNC(BALANCE,0)+ TRUNC(AAMT,0) + TRUNC(RAMT,0) + TRUNC(BAMT,0)+ TRUNC(NAMT,0) + TRUNC(EMKAMT,0) + TRUNC(FLOATAMT,0)) SUMCI FROM CIMAST where AFACCTNO='" & v_strAFACCTNO & "' "
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    Dim v_dblSumCI As Long
                    v_dblSumCI = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("SUMCI")), 0, v_ds.Tables(0).Rows(0)("SUMCI"))
                    If v_dblSumCI > v_roundValue Then
                        v_lngErrCode = ERR_CI_EXIST
                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                     & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                     & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                        Return v_lngErrCode
                    End If
                End If

                v_strSQL = "UPDATE SEMAST SET STATUS='C',PSTATUS=PSTATUS || STATUS,LASTDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') WHERE AFACCTNO='" & v_strAFACCTNO & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            End If

            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
    Private Function fncActiveContract(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CF.Trans.fncActiveContract", v_strErrorMessage As String
        Dim v_strSQL As String = String.Empty
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE, v_strCONFIRMPIN, v_strPIN As String, v_dblVALUE As Double
            Dim v_strACCTNO, v_strCUSTODYCD, v_strAFTYPE As String
            Dim v_DataAccess As New DataAccess, v_ds As DataSet

            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False

            'Ä?á»?c ná»™i dung giao dá»‹ch
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If

                    Select Case v_strFLDCD
                        Case "03" 'So HD
                            v_strACCTNO = v_strVALUE
                    End Select
                End With
            Next

            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)

            'v_strSQL = "SELECT count(*) FROM AFMAST WHERE  ACCTNO ='" & v_strACCTNO & "'"
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'If v_ds.Tables(0).Rows.Count <= 0 Then
            '    Return ERR_CF_AFMAST_NOTFOUND
            'Else
            '    v_strSQL = "UPDATE AFMAST SET STATUS='A',PSTATUS=PSTATUS || STATUS,LASTDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') WHERE ACCTNO='" & v_strACCTNO & "'"
            '    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            'End If

            'v_ds.Clear()

            'v_strSQL = "SELECT count(*) FROM CIMAST WHERE  ACCTNO ='" & v_strACCTNO & "'"
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'If v_ds.Tables(0).Rows.Count <= 0 Then
            '    Return ERR_CI_CIMAST_NOTFOUND
            'Else
            '    v_strSQL = "UPDATE CIMAST SET STATUS='A',PSTATUS=PSTATUS || STATUS,LASTDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') WHERE AFACCTNO='" & v_strACCTNO & "'"
            '    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            'End If

            If Not v_blnReversal Then
                'check da thuc hien 2247, 2248 chua

                v_strSQL = " SELECT SUM(TRADE + DTOCLOSE) TRADE  FROM SEMAST WHERE AFACCTNO = '" & v_strACCTNO & "' and STATUS ='N' "
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

                If IIf(IsDBNull(v_ds.Tables(0).Rows(0)("TRADE")), 0, v_ds.Tables(0).Rows(0)("TRADE")) > 0 Then
                    v_lngErrCode = ERR_CF_CANNOT_ACTIVE
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If


                v_strSQL = "UPDATE SEMAST SET STATUS='A',PSTATUS=PSTATUS || STATUS,LASTDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') WHERE AFACCTNO='" & v_strACCTNO & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            Else
                v_strSQL = "UPDATE SEMAST SET STATUS = substr(PSTATUS,length(PSTATUS),1),PSTATUS = substr(PSTATUS,1,length(PSTATUS)-1),LASTDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') WHERE AFACCTNO='" & v_strACCTNO & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End If


            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
    Private Function chkActiveContract(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CF.Trans.fncActiveContract", v_strErrorMessage As String
        Dim v_strSQL As String = String.Empty
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE, v_strCONFIRMPIN, v_strPIN As String, v_dblVALUE As Double
            Dim v_strACCTNO, v_strCUSTODYCD, v_strAFTYPE As String
            Dim v_DataAccess As New DataAccess, v_ds As DataSet

            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False

            'Ä?á»?c ná»™i dung giao dá»‹ch
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If

                    Select Case v_strFLDCD
                        Case "03" 'So HD
                            v_strACCTNO = v_strVALUE
                    End Select
                End With
            Next

            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)


            If Not v_blnReversal Then
                'check co hop dong nao active ko
                'Kiá»ƒm tra khach hang da co hop Ä‘á»“ng individual nao chÆ°a
                v_strSQL = "SELECT * FROM AFMAST AF WHERE  AF.STATUS = 'A' AND AF.AFTYPE ='001' AND AF.CUSTID IN (SELECT CUSTID FROM AFMAST AM WHERE AM.ACCTNO = '" & v_strACCTNO & "') "
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    'Tráº£ vá»? mÃ£ lá»—i da co hop Ä‘á»“ng individual
                    v_lngErrCode = ERR_CF_ACTYPE_HAS_CONTRACT
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If

            Else
            End If


            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function chkCloseCustodyCode(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CF.Trans.chkCloseCustodyCode", v_strErrorMessage As String
        Dim v_strSQL As String = String.Empty
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE, v_strCONFIRMPIN, v_strPIN As String, v_dblVALUE As Double
            Dim v_strACCTNO, v_strCUSTODYCD, v_strCUSTID, v_strAFTYPE As String
            Dim v_DataAccess As New DataAccess, v_ds As DataSet

            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False

            'Doc noi dung giao dich
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If

                    Select Case v_strFLDCD
                        Case "03" 'Ma khach hang
                            v_strCUSTID = v_strVALUE
                    End Select
                End With
            Next

            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)

            Dim v_objParam As New StoreParameter
            Dim v_arrPara(1) As StoreParameter

            v_objParam.ParamName = "return"
            v_objParam.ParamDirection = ParameterDirection.ReturnValue
            v_objParam.ParamValue = 0
            v_objParam.ParamSize = 1000
            v_objParam.ParamType = GetType(System.Double).Name
            v_arrPara(0) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_custid"
            v_objParam.ParamValue = v_strCUSTID
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamSize = 20
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(1) = v_objParam

            v_lngErrCode = v_obj.ExecuteOracleStored("sapks_system.fn_CheckCloseCustodyAccount", v_arrPara, 0)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Return ERR_CF_ALREADY_HAS_INUSED_AFMAST
            End If

            v_lngErrCode = v_obj.ExecuteOracleStored("sapks_system.fn_CheckCloseCustodyCA", v_arrPara, 0)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Return v_lngErrCode
            End If

            Return ERR_SYSTEM_OK



        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
            Return ERR_SYSTEM_START
        End Try
    End Function
    Private Function check_0067(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CF.Trans.chk0067", v_strErrorMessage As String
        Dim v_strSQL As String = String.Empty
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE, v_strCONFIRMPIN, v_strPIN As String, v_dblVALUE As Double
            Dim v_strACCTNO, v_strCUSTODYCD, v_strCUSTID, v_strAFTYPE As String
            Dim v_DataAccess As New DataAccess, v_ds As DataSet
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False

            'Doc noi dung giao dich
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If

                    Select Case v_strFLDCD
                        Case "03" 'Ma khach hang
                            v_strCUSTID = v_strVALUE
                    End Select
                End With
            Next

            v_strSQL = "SELECT * FROM CFMAST CF1, (SELECT IDCODE,CUSTTYPE FROM CFMAST WHERE CUSTID='" & v_strCUSTID _
                        & "') CF2 WHERE CF1.STATUS<> 'C' and CF1.IDCODE=CF2.IDCODE and CF1.CUSTTYPE=CF2.CUSTTYPE  "
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_lngErrCode = ERR_CF_IDTYPE_DUPLICATED
                Return v_lngErrCode
            End If
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
            Return ERR_SYSTEM_START
        End Try
    End Function

    Private Function ChkBalanceStschd(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CF.Trans.fncActiveContract", v_strErrorMessage As String
        Dim v_strSQL As String = String.Empty
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE, v_strCONFIRMPIN, v_strPIN As String, v_dblVALUE As Double
            Dim v_strACCTNO, v_strCUSTODYCD, v_strAFTYPE As String
            Dim v_DataAccess As New DataAccess, v_ds As DataSet
            Dim v_roundValue As Integer

            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False

            'Ä?á»?c ná»™i dung giao dá»‹ch
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If
                    Select Case v_strFLDCD
                        Case "03" 'So HD
                            v_strACCTNO = v_strVALUE
                    End Select

                End With
            Next

            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)

            v_strSQL = "SELECT VARVALUE FROM  SYSVAR WHERE GRNAME ='SYSTEM' AND VARNAME ='ROUND_VALUE'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_roundValue = v_ds.Tables(0).Rows(0)("VARVALUE")
            Else
                v_roundValue = 0
            End If

            'Kiem tra la itien gui, lai thau chi neu lon hon gia tri lam tron cho phep thi khong cho thuc hien
            'Yeu cau phai rut, tra lai thau chi thi moi cho lam
            'Check Balance
            v_strSQL = "SELECT NVL(CRINTACR,0) INTACR , NVL(ODINTACR,0) ODINTACR, NVL(balance,0) BALANCE FROM CIMAST CI WHERE  CI.ACCTNO  = '" & v_strACCTNO & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                If v_ds.Tables(0).Rows(0)("INTACR") > v_roundValue Then
                    'Lai tien gui van con
                    v_lngErrCode = ERR_CI_CRINTACR_REMAIN
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If

                If v_ds.Tables(0).Rows(0)("BALANCE") > v_roundValue Then
                    'Lai tien gui van con
                    v_lngErrCode = ERR_CI_BALANCE
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If

                If v_ds.Tables(0).Rows(0)("ODINTACR") > v_roundValue Then
                    'Lai thau chi van con
                    v_lngErrCode = ERR_CI_ODINTACR_REMAIN
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If
            Else
                'Tai khoan khong ton tai
                v_lngErrCode = ERR_CI_CIMAST_NOTFOUND
                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                             & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                             & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                Return v_lngErrCode
            End If
            'Check Balance
            v_strSQL = "SELECT NVL(SUM(BALANCE),0) + NVL(SUM(BAMT),0) BA FROM CIMAST CI WHERE  CI.ACCTNO  = '" & v_strACCTNO & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows(0)("BA") > v_roundValue Then
                'Tráº£ vá»? mÃ£ lá»—i da co hop Ä‘á»“ng individual
                v_lngErrCode = ERR_CI_BALANCE
                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                             & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                             & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                Return v_lngErrCode
            End If
            'Check Hold Balance
            v_strSQL = "SELECT NVL(SUM(HOLDBALANCE),0) BA FROM CIMAST CI WHERE  CI.ACCTNO  = '" & v_strACCTNO & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows(0)("BA") > v_roundValue Then
                'Tráº£ vá»? mÃ£ lá»—i da co hop Ä‘á»“ng individual
                v_lngErrCode = ERR_CI_HOLDBALANCE
                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                             & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                             & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                Return v_lngErrCode
            End If

            'Check PendingHold Balance
            v_strSQL = "SELECT NVL(SUM(PENDINGHOLD),0) BA FROM CIMAST CI WHERE  CI.ACCTNO  = '" & v_strACCTNO & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows(0)("BA") > v_roundValue Then
                'Tráº£ vá»? mÃ£ lá»—i da co hop Ä‘á»“ng individual
                v_lngErrCode = ERR_CI_PENDINGHOLDBALANCE
                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                             & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                             & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                Return v_lngErrCode
            End If

            'Check PendingUnHold Balance
            v_strSQL = "SELECT NVL(SUM(PENDINGUNHOLD),0) BA FROM CIMAST CI WHERE  CI.ACCTNO  = '" & v_strACCTNO & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows(0)("BA") > v_roundValue Then
                'Tráº£ vá»? mÃ£ lá»—i da co hop Ä‘á»“ng individual
                v_lngErrCode = ERR_CI_PENDINGUNHOLDBALANCE
                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                             & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                             & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                Return v_lngErrCode
            End If


            v_strSQL = "SELECT NVL(SUM(AMT),0) BA FROM STSCHD WHERE DUETYPE in ('RM','SM') AND ACCTNO  = '" & v_strACCTNO & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows(0)("BA") > v_roundValue Then
                'Tráº£ vá»? mÃ£ lá»—i da co hop Ä‘á»“ng individual
                v_lngErrCode = ERR_CI_AAMT
                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                             & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                             & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                Return v_lngErrCode
            End If





            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function Check_TLID(ByRef pv_xmlDocument As Xml.XmlDocument) As Long 'Dien 18-10-2010
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CF.Trans.Check_ChangeService", v_strErrorMessage As String
        Dim v_strSQL As String = String.Empty
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE, v_strCONFIRMPIN, v_strPIN As String, v_dblVALUE As Double
            Dim v_strCAREBYID, v_strTLID As String
            Dim v_DataAccess As New DataAccess, v_ds As DataSet
            'Ä?á»?c ná»™i dung giao dá»‹ch
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If

                    Select Case v_strFLDCD
                        Case "09" 'TLID moi
                            v_strTLID = v_strVALUE
                        Case "11" 'Nhom Careby
                            v_strCAREBYID = v_strVALUE
                    End Select
                End With
            Next

            Dim v_obj As New DataAccess
            Dim v_strMarginType As String
            v_obj.NewDBInstance(gc_MODULE_HOST)
            v_strSQL = "select tp.active ACTIVE from tlgrpusers tgu, tlprofiles tp, tlgroups tg where tgu.tlid = tp.tlid and  tgu.grpid=tg.grpid and tgu.grpid='" & v_strCAREBYID & "'and tgu.tlid='" & v_strTLID & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_strMarginType = v_ds.Tables(0).Rows(0)("ACTIVE")
                If v_strMarginType <> "Y" Then
                    Return ERR_EXITS_USER ' User ở trạng thái Chưa áp dụng
                End If
            Else
                'User không thuộc nhóm careby
                Return ERR_CF_USER_NOT_IN_CAREBY
            End If


            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function SendEMAIL(ByRef pv_strObjMsg As String, Optional ByVal pv_strEmail As String = "") As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CF.Tran.SendEMAIL"
        Dim v_DataAccess As New DataAccess
        Dim v_ds As DataSet
        Dim v_strSQL As String
        Dim i As Integer

        Dim v_strMAILSERVER, v_strFRFULLNAME, v_strMAILUSER,
            v_strMAILPASS, v_strFREMAIL, v_strSIGNATURE As String
        Dim v_strTOEMAIL, v_strHEADER, v_strBODYTEMPLATE, v_strAUTOID As String
        Dim v_dblAUTOID As Double

        Try

            v_DataAccess.NewDBInstance(gc_MODULE_HOST)

            'XAC DINH THAM SO GUI EMAIL
            '=============================================================================================================================================
            v_strSQL = "SELECT (SELECT VARVALUE FROM SYSVAR WHERE GRNAME = 'SYSTEM' AND VARNAME = 'SYSMAILSERVER') SYSMAILSERVER " _
                            & ", (SELECT VARVALUE FROM SYSVAR WHERE GRNAME = 'SYSTEM' AND VARNAME = 'SYSSIGNATURE') SYSSIGNATURE " _
                            & ", (SELECT VARVALUE FROM SYSVAR WHERE GRNAME = 'SYSTEM' AND VARNAME = 'SYSUSEREMAIL') SYSUSEREMAIL " _
                            & ", (SELECT VARVALUE FROM SYSVAR WHERE GRNAME = 'SYSTEM' AND VARNAME = 'SYSUERPASS') SYSUERPASS " _
                            & ", (SELECT VARVALUE FROM SYSVAR WHERE GRNAME = 'SYSTEM' AND VARNAME = 'SYSUERNAME') SYSUERNAME FROM DUAL"

            v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

            If (v_ds.Tables(0).Rows.Count > 0) Then
                v_strMAILSERVER = Trim(v_ds.Tables(0).Rows(0)("SYSMAILSERVER"))
                v_strFRFULLNAME = Trim(v_ds.Tables(0).Rows(0)("SYSUERNAME"))
                v_strMAILUSER = v_strFRFULLNAME
                v_strMAILPASS = Trim(v_ds.Tables(0).Rows(0)("SYSUERPASS"))
                v_strFREMAIL = Trim(v_ds.Tables(0).Rows(0)("SYSUSEREMAIL"))
                v_strSIGNATURE = Trim(v_ds.Tables(0).Rows(0)("SYSSIGNATURE"))
            End If

            'LAY THONG TIN NHUNG MAIL CAN GUI DI TRONG TABLE EMAILLOG CO TRANG THAI LA 'A'
            '===============================================================================================================================================
            If pv_strEmail = "" Then
                v_strSQL = "SELECT AUTOID, EMAIL, HEADEREMAIL HEADER, BODYTEMPLATE BODY, CREATEDATE, CREATETIME FROM EMAILLOG WHERE STATUS = 'A'"
            Else
                v_strSQL = "SELECT AUTOID, EMAIL, HEADEREMAIL HEADER, BODYTEMPLATE BODY, CREATEDATE, CREATETIME FROM EMAILLOG WHERE STATUS = 'A' AND EMAIL= '" & pv_strEmail & "'"
            End If

            v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

            If v_ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To v_ds.Tables(0).Rows.Count - 1 Step 1
                    v_strTOEMAIL = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("EMAIL"))
                    v_strHEADER = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("HEADER"))
                    v_strBODYTEMPLATE = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("BODY"))
                    v_strAUTOID = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("AUTOID"))
                    v_dblAUTOID = CDbl(v_strAUTOID)

                    'GUI MAIL
                    Delivery.SendMail(v_strSIGNATURE, v_strFREMAIL, v_strTOEMAIL, v_strHEADER, v_strMAILUSER, v_strMAILPASS, v_strBODYTEMPLATE, v_strMAILSERVER, , v_strHEADER)

                    'CAP NHAT TRANG THAI EMAILLOG
                    v_strSQL = "UPDATE EMAILLOG SET STATUS = 'S' WHERE AUTOID =" & v_dblAUTOID
                    v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)

                Next
            End If

            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        Finally
            v_DataAccess = Nothing
        End Try
    End Function
    Private Function RemapTokenMatrix(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CF.Trans.RemapTokenMatrix"
        Dim v_strSQL, v_strSQL1 As String

        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE, v_strCONFIRMPIN, v_strPIN As String, v_dblVALUE As Double
            Dim v_strCustodyCD, v_strCurrType, v_strCurrTokenId, v_strNewType, v_strNewTokenId, v_strCustID As String
            Dim v_DataAccess As New DataAccess, v_ds As DataSet
            Dim V_stremail, v_strFullname, V_strusername, v_strmobilesms, l_datasourcesql As String
            Dim v_strtype_old, v_strtype_new, v_strserial_oll, v_strserial_new, v_strSQLTEMP, v_strPass As String


            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False
            Dim v_blnActionDone As Boolean
            'Ä?á»?c ná»™i dung giao dá»‹ch
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If

                    Select Case v_strFLDCD
                        Case "88" 'Custodycd
                            v_strCustodyCD = v_strVALUE
                        Case "09" 'CurrAuthType
                            v_strCurrType = v_strVALUE
                        Case "11" 'CurrTokenId
                            v_strCurrTokenId = v_strVALUE
                        Case "12" 'NewAuthType
                            v_strNewType = v_strVALUE
                        Case "15" 'NewTokenId
                            v_strNewTokenId = v_strVALUE
                        Case "03" 'Custid
                            v_strCustID = v_strVALUE.Replace(".", "")
                    End Select
                End With
            Next

            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            'Kien tra co so du chung khoan niem yet, chung khoan niem yet cho ve
            v_strSQL = "SELECT COUNT(*) ROWCOUNT FROM userlogin WHERE username = '" & v_strCustodyCD & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

            If v_ds.Tables(0).Rows.Count > 0 Then
                If CDbl(v_ds.Tables(0).Rows(0)(0).ToString) <= 0 Then
                    v_lngErrCode = ERR_CF_ONLINE_SERVICES_NOTFOUND
                End If
            End If
            v_strSQL = "BEGIN "
            If v_strNewType = gc_TokenType Or v_strNewType = gc_MatrixType Then
                v_strSQL = v_strSQL & " Update Otright SET authtype = '" & v_strNewType & "', serialtoken = '" & v_strNewTokenId & "' "
                v_strSQL = v_strSQL & " WHERE cfcustid = '" & v_strCustID & "'; "

                v_strSQL = v_strSQL & " Update userlogin SET authtype = '" & v_strNewType & "', TOKENID = '" & v_strNewTokenId & "' "
                v_strSQL = v_strSQL & " WHERE username = '" & v_strCustodyCD & "'; "
            Else


                v_strSQLTEMP = "select substr(sys_guid(),0,10) pass from dual  "
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQLTEMP)
                v_strPass = v_ds.Tables(0).Rows(0)("PASS")


                v_strSQL = v_strSQL & " Update Otright SET authtype = '" & v_strNewType & "', serialtoken = '' "
                v_strSQL = v_strSQL & " WHERE cfcustid = '" & v_strCustID & "'; "

                v_strSQL = v_strSQL & " Update userlogin SET authtype = '" & v_strNewType & "', TOKENID = '', tradingpwd=GENENCRYPTPASSWORD('" & v_strPass & "') "
                v_strSQL = v_strSQL & " WHERE username = '" & v_strCustodyCD & "'; "
            End If

            Dim v_arrRightDetail(), v_arrRightInfo(16) As String
            Dim v_strAUTHCUSTID, v_strAUTH As String
            Dim v_count As Integer

            If v_strNewType = gc_TokenType Then
                v_strAUTH = "YYYYNYN"
            ElseIf v_strNewType = gc_MatrixType Then
                v_strAUTH = "YYYYNNY"
            Else
                v_strAUTH = "YYYYYNN"
            End If

            v_arrRightInfo(0) = "CASHTRANS" & "|" & v_strAUTH
            v_arrRightInfo(1) = "STOCKTRANS" & "|" & v_strAUTH
            v_arrRightInfo(2) = "ADWINPUT" & "|" & v_strAUTH
            v_arrRightInfo(3) = "ISSUEINPUT" & "|" & v_strAUTH
            v_arrRightInfo(4) = "MORTGAGE" & "|" & v_strAUTH
            v_arrRightInfo(5) = "ORDINPUT" & "|" & v_strAUTH
            v_arrRightInfo(6) = "COND_ORDER" & "|" & v_strAUTH
            v_arrRightInfo(7) = "GROUP_ORDER" & "|" & v_strAUTH
            v_arrRightInfo(8) = "DEPOSIT" & "|" & v_strAUTH
            v_arrRightInfo(9) = "SMARTALERT" & "|" & v_strAUTH
            v_arrRightInfo(10) = "MARKETALERT" & "|" & v_strAUTH
            v_arrRightInfo(11) = "COMPANYALERT" & "|" & v_strAUTH
            v_arrRightInfo(12) = "BONDSTOSHARES" & "|" & v_strAUTH
            v_arrRightInfo(13) = "TERMDEPOSIT" & "|" & v_strAUTH
            v_arrRightInfo(14) = "ADMINMESSAGES" & "|" & v_strAUTH
            v_arrRightInfo(15) = "ADMINBRANCH" & "|" & v_strAUTH
            v_arrRightInfo(16) = "AGENTSETTING" & "|" & v_strAUTH

            'v_strSQL = "BEGIN "

            v_strAUTHCUSTID = v_strCustID

            For i = 0 To v_arrRightInfo.Length - 2
                v_arrRightDetail = v_arrRightInfo(i).Split("|")
                'Insert
                'Check neu co roi thi update, chua co thi them moi
                v_strSQLTEMP = "SELECT OTRIGHT FROM OTRIGHTDTL WHERE CFCUSTID = '" & v_strCustID & "' AND AUTHCUSTID = '" & v_strAUTHCUSTID & "' AND OTMNCODE = '" & v_arrRightDetail(0) & "' AND DELTD = 'N'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQLTEMP)


                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_strSQL = v_strSQL & " UPDATE OTRIGHTDTL SET " & ControlChars.CrLf _
                        & " OTRIGHT =  '" & v_arrRightDetail(1) & "' " & ControlChars.CrLf _
                        & " WHERE CFCUSTID = '" & v_strCustID & "' AND AUTHCUSTID = '" & v_strAUTHCUSTID & "' AND OTMNCODE = '" & v_arrRightDetail(0) & "' ;"
                Else
                    'Them moi
                    v_strSQL = v_strSQL & " INSERT INTO OTRIGHTDTL (AUTOID, CFCUSTID, AUTHCUSTID, OTMNCODE, OTRIGHT, DELTD) " & ControlChars.CrLf _
                        & "VALUES (SEQ_OTRIGHTDTL.NEXTVAL, '" & v_strCustID & "', '" & v_strAUTHCUSTID & "', " & ControlChars.CrLf _
                        & "'" & v_arrRightDetail(0) & "', '" & v_arrRightDetail(1) & "', 'N');"
                End If
            Next

            v_strSQL = v_strSQL & " END;"

            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            v_strSQL = "select typeold.cdcontent typeold, typenew.cdcontent typenew  from " & ControlChars.CrLf _
                             & "(SELECT   cdcontent FROM ALLCODE WHERE CDTYPE = 'CF' AND CDNAME = 'OTAUTHTYPE' and cdval = '" & v_strCurrType & "') typeold," & ControlChars.CrLf _
                             & "(SELECT   cdcontent FROM ALLCODE WHERE CDTYPE = 'CF' AND CDNAME = 'OTAUTHTYPE' and cdval = '" & v_strNewType & "') typenew   "
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

            v_strtype_old = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("typeold"))
            v_strtype_new = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("typenew"))


            v_strSQL = "SELECT * FROM vw_CFMAST_SMS WHERE  custid = '" & v_strCustID & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

            V_stremail = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("EMAIL"))
            v_strFullname = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("FULLNAME"))
            V_strusername = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("CUSTODYCD"))
            v_strmobilesms = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("MOBILESMS"))

            If v_strNewType = gc_PinType Then
                v_strNewTokenId = v_strPass
            End If


            l_datasourcesql = "select ''" & V_strusername & "'' username, ''" & v_strtype_old & "'' typeold ,''" & v_strtype_new & "'' typenew, ''" & v_strCurrTokenId & "'' serialold ,''" & v_strNewTokenId & "'' serialnew, ''" & v_strFullname & "'' fullname, ''" & V_strusername & "'' custodycode from dual"

            v_strSQL = " INSERT INTO emaillog (autoid, email, templateid, datasource, status,afacctno ,createtime)" & ControlChars.CrLf _
                       & "VALUES(seq_emaillog.nextval,'" & V_stremail & "','0210','" & l_datasourcesql & "','A','" & V_strusername & "',SYSDATE)"
            v_strSQL1 = " INSERT INTO emaillog (autoid, email, templateid, datasource, status,afacctno ,createtime)" & ControlChars.CrLf _
                       & "VALUES(seq_emaillog.nextval,'" & v_strmobilesms & "','0305','" & l_datasourcesql & "','A','" & V_strusername & "',SYSDATE)"

            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL1)

            Return v_lngErrCode

        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
#End Region

End Class
