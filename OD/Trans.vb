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
        ATTR_MODULE = "OD"
    End Sub

#Region " Implement functions"
    Overrides Function txImpUpdate(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        'Xac dinh ma giao dich tuong ung
        Dim v_lngErrorCode As Long = ERR_SYSTEM_OK
        Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
        Dim v_strTLTXCD As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLTXCD), Xml.XmlAttribute).Value)
        Select Case v_strTLTXCD
            Case gc_OD_CORRECT_BUY_ORDER, gc_OD_CORRECT_SELL_ORDER, gc_OD_MOVE_BUY_DEAL, gc_OD_MOVE_SELL_DEAL
                v_lngErrorCode = CorrectOrder(pv_xmlDocument)
            Case gc_OD_SENDBUYORDER, gc_OD_SENDSELLORDER
                v_lngErrorCode = SendOrder(pv_xmlDocument)
            Case gc_OD_AMENDMENTBUYORDER, gc_OD_AMENDMENTSELLORDER, gc_OD_CANCELBUYORDER, gc_OD_CANCELSELLORDER
                v_lngErrorCode = CancelOrder(pv_xmlDocument)
            Case gc_OD_APPROVE_EDITBUYORDER, gc_OD_APPROVE_EDITSELLORDER
                v_lngErrorCode = ApproveCancelOrder(pv_xmlDocument)
            Case gc_OD_CLEARSELLORDER, gc_OD_CLEARBUYORDER, gc_OD_CLEARBUYSENDINGORDER, gc_OD_CLEARSELLSENDINGORDER
                v_lngErrorCode = ClearOrder(pv_xmlDocument)
            Case gc_OD_MATCHORDER, gc_OD_MANUAL_MATCHORDER
                v_lngErrorCode = MatchOrder(pv_xmlDocument)
            Case gc_OD_ALLOCATE_TRADING, gc_OD_HASTC_ALLOCATE_TRADING
                v_lngErrorCode = AllocateTrading(pv_xmlDocument)
            Case gc_OD_CISEND, gc_OD_CIRECEIVE, gc_OD_SESEND, gc_OD_SERECEIVE, gc_OD_SERECEIVE_T1T2, gc_OD_BATCH_CISEND, gc_OD_BATCH_CIRECEIVE, gc_OD_BATCH_SESEND, gc_OD_BATCH_SERECEIVE, gc_OD_BATCH_SUNRELY_CISEND
                v_lngErrorCode = SettlementOrder(pv_xmlDocument)
            Case gc_OD_OTC_BUY_SETTLEMENT, gc_OD_OTC_SELL_SETTLEMENT
                v_lngErrorCode = DealingOTCSettlementOrder(pv_xmlDocument)
            Case gc_OD_FINISHORDER
                ' v_lngErrorCode = FinishOrder(pv_xmlDocument)
            Case gc_OD_PLACENORMALBUYORDER, gc_OD_PLACENORMALSELLORDER, gc_OD_PLACENORMALBUYORDER_ADVANCED, gc_OD_PLACENORMALSELLORDER_ADVANCED
                v_lngErrorCode = PlaceOrder(pv_xmlDocument)
            Case gc_OD_RESEND_ORDER
                v_lngErrorCode = UpdateOodStatus(pv_xmlDocument)
            Case gc_OD_REFUSE_AMEND_ORDER
                v_lngErrorCode = RefuseAmendOrder(pv_xmlDocument)
            Case gc_OD_RELEASEBUYORDER, gc_OD_RELEASESELLORDER
                v_lngErrorCode = ReleaseOrder(pv_xmlDocument)
            Case gc_OD_OTC_ALLOCATETRADE
                v_lngErrorCode = OTCAllocateTrading(pv_xmlDocument)
            Case gc_OD_OTC_TRANSFER, gc_OD_OTC_RECEIVE
                v_lngErrorCode = OTCSettlementOrder(pv_xmlDocument)
            Case gc_OD_AMENDMENTELECTRICORDER
                v_lngErrorCode = AmendElectricOrder(pv_xmlDocument)
            Case "8833"
                v_lngErrorCode = EditOrder(pv_xmlDocument)
        End Select
        ''ContextUtil.SetComplete()
        'Tra ve ma loi
        Return v_lngErrorCode
    End Function

    Overrides Function txImpCheck(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        'Kiem tra cho truong hop huy lenh
        Dim v_lngErrorCode As Long = ERR_SYSTEM_OK
        Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
        Dim v_strTLTXCD As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLTXCD), Xml.XmlAttribute).Value)
        Select Case v_strTLTXCD
            Case gc_OD_PLACENORMALBUYORDER, gc_OD_PLACENORMALSELLORDER, gc_OD_PLACENORMALBUYORDER_ADVANCED, gc_OD_PLACENORMALSELLORDER_ADVANCED
                v_lngErrorCode = CheckBeforePlaceOrder(pv_xmlDocument)
            Case gc_OD_CIRECEIVE
                v_lngErrorCode = CheckBeforeSettlementOrder(pv_xmlDocument)
            Case "8882", "8883", "8884", "8885"
                v_lngErrorCode = CheckBeforeCancelOrder(pv_xmlDocument)
            Case gc_OD_MATCHORDER, gc_OD_MANUAL_MATCHORDER
                v_lngErrorCode = CheckMatchOrder(pv_xmlDocument)
        End Select
        ''ContextUtil.SetComplete()
        'Tra ve ma loi
        Return v_lngErrorCode
    End Function

    Overrides Function txImpMisc(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        'Xac dinh ma giao dich tuong ung
        Dim v_lngErrorCode As Long
        Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
        Dim v_strTLTXCD As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLTXCD), Xml.XmlAttribute).Value)

        Select Case v_strTLTXCD
            Case gc_OD_PLACEORDER
                v_lngErrorCode = PlaceOrder(pv_xmlDocument)
            Case gc_OD_ORDERINQUIRY
                v_lngErrorCode = InquiryOrder(pv_xmlDocument)
            Case gc_OD_ORDERHISTORY
                v_lngErrorCode = HistoryOrder(pv_xmlDocument)
            Case gc_OD_IBT_SETTLEMENT
                v_lngErrorCode = HistoryIBTSTS(pv_xmlDocument)
            Case gc_OD_CLEARINGINQUIRY
                v_lngErrorCode = ClearingScheduleInquiry(pv_xmlDocument)
            Case gc_OD_SENDORDER2STC
                v_lngErrorCode = SendOrder2TradingCenter(pv_xmlDocument)
            Case gc_OD_CANCELBUYORDER, gc_OD_CANCELSELLORDER
                v_lngErrorCode = CancelOrder(pv_xmlDocument)
        End Select
        ''ContextUtil.SetComplete()
        'Tra ve ma loi
        Return v_lngErrorCode
    End Function
#End Region

#Region " Private functions"
    Private Function OTCSettlementOrder(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "OD.Trans.SettlementOrder", v_strErrorMessage As String

        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, v_strSQL As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE As Double
            Dim v_strAUTOID As String
            Dim v_ds As DataSet
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_strBRID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXTIME As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTIME).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_blnREVERSAL As Boolean = IIf(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value = "Y", True, False)

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
                        Case "01" 'AUTOID
                            v_strAUTOID = v_dblVALUE.ToString()
                    End Select
                End With
            Next

            If Not v_blnREVERSAL Then   'Chuyen trang thai tu chua thanh toan thanh thanh toan
                v_strSQL = "SELECT STATUS,AFACCTNO,CODEID,to_char(to_date(TXDATE,'DD/MM/RRRR'),'DD/MM/RRRR') TXDATE,TXNUM,DUETYPE FROM STSCHD WHERE AUTOID = " & v_strAUTOID
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If Not v_ds.Tables(0).Rows.Count > 0 Then
                    v_lngErrCode = ERR_OD_STSCHD_NOTFOUND
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: Reversal." & v_blnREVERSAL.ToString() & "." & v_strAUTOID & "." & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                Else
                    If Trim(v_ds.Tables(0).Rows(0)("STATUS")) = "C" Then
                        v_lngErrCode = ERR_OD_STSCHD_IS_CLOSED
                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                     & "Error code: Reversal." & v_blnREVERSAL & "." & v_strAUTOID & "." & "." & Trim(v_ds.Tables(0).Rows(0)("STATUS")) & vbNewLine _
                                     & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                        Return v_lngErrCode
                    Else
                        v_strSQL = "UPDATE STSCHD SET STATUS='C' WHERE STATUS<>'C' AND TXNUM='" & v_ds.Tables(0).Rows(0)("TXNUM") & "' AND TXDATE=to_date('" & v_ds.Tables(0).Rows(0)("TXDATE") & "','DD/MM/RRRR')"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    End If
                End If
            Else    'Chuyen trang thai tu thanh toan thanh chua thanh toan
                v_strSQL = "SELECT STATUS,AFACCTNO,CODEID,to_char(to_date(TXDATE,'DD/MM/RRRR'),'DD/MM/RRRR') TXDATE,TXNUM,DUETYPE FROM STSCHD WHERE TRIM(AUTOID)=" & v_strAUTOID
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If Not v_ds.Tables(0).Rows.Count > 0 Then
                    v_lngErrCode = ERR_OD_STSCHD_NOTFOUND
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: Reversal." & v_blnREVERSAL.ToString() & "." & v_strAUTOID & "." & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                Else
                    If Trim(v_ds.Tables(0).Rows(0)("STATUS")) = "N" Then
                        v_lngErrCode = ERR_OD_STSCHD_STATUSINVALID
                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                     & "Error code: Reversal." & v_blnREVERSAL & "." & v_strAUTOID & "." & Trim(v_ds.Tables(0).Rows(0)("STATUS")) & vbNewLine _
                                     & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                        Return v_lngErrCode
                    Else
                        v_strSQL = "Update stschd set STATUS='N' where STATUS='C' AND TXNUM='" & v_ds.Tables(0).Rows(0)("TXNUM") & "' AND TXDATE=to_date('" & v_ds.Tables(0).Rows(0)("TXDATE") & "','DD/MM/RRRR')"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    End If
                End If
            End If
            ''ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            ''ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
    Private Function OTCAllocateTrading(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "DD.Trans.GoldAllocateTrading", v_strErrorMessage As String

        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, v_strSQL As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE, v_lngCLEARDAY As Double
            Dim v_strCODEID, v_strACTYPE, v_strORGORDERID, v_strREFORDERID, v_strREFCUSTCD, v_strSYMBOL, v_strCUSTODYCD,
                v_strAFACCTNO, v_strCIACCTNO, v_strSEACCTNO, v_strBORS, v_strNORP, v_strAORN, v_strCONFIRM_NO, v_strMATCH_DATE, v_strCLEARCD, v_strPRICETYPE, v_strDESC As String
            Dim v_dblPRICE, v_dblQTTY, v_dblEXPRICE, v_dblEXQTTY, v_dblCostprice As Double
            Dim v_ds As DataSet
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_strBRID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXTIME As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTIME).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_blnREVERSAL As Boolean = IIf(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value = "Y", True, False)

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
                        Case "03" 'ORGORDERID
                            v_strORGORDERID = v_strVALUE
                        Case "04" 'AFACCTNO
                            v_strAFACCTNO = v_strVALUE
                        Case "05" 'CIACCTNO
                            v_strCIACCTNO = v_strVALUE
                        Case "06" 'SEACCTNO
                            v_strSEACCTNO = v_strVALUE
                        Case "07" 'REFORDERID
                            v_strREFORDERID = v_strVALUE
                        Case "08" 'REFCUSTCD
                            v_strREFCUSTCD = v_strVALUE
                        Case "09" 'CLEARCD
                            v_strCLEARCD = v_strVALUE
                        Case "80" 'CODEID
                            v_strCODEID = v_strVALUE
                        Case "81" 'SYMBOL                                       
                            v_strSYMBOL = v_strVALUE
                        Case "82" 'CUSTODYCD                                       
                            v_strCUSTODYCD = v_strVALUE
                        Case "83" 'BORS                                       
                            v_strBORS = v_strVALUE
                        Case "84" 'NORP
                            v_strNORP = v_strVALUE
                        Case "85" 'AORN
                            v_strAORN = v_strVALUE
                        Case "10" 'PRICE                                         
                            v_dblPRICE = v_dblVALUE
                        Case "11" 'QTTY
                            v_dblQTTY = v_dblVALUE
                        Case "12" 'EXPRICE          
                            v_dblEXPRICE = v_dblVALUE
                        Case "13" 'EXQTTY                                      
                            v_dblEXQTTY = v_dblVALUE
                        Case "14" 'CLEARDAY 
                            v_lngCLEARDAY = v_dblVALUE
                        Case "16" 'CONFIRM_NO
                            v_strCONFIRM_NO = v_strVALUE
                        Case "17" 'MATCH_DATE
                            v_strMATCH_DATE = v_strVALUE
                        Case "30" 'DESC                                              
                            v_strDESC = v_strVALUE
                    End Select
                End With
            Next

            If Not v_blnREVERSAL Then   'Tao lenh khop
                'Kiem tra lenh da duoc day len san chua
                v_strSQL = "SELECT * FROM OOD WHERE OODSTATUS='S' AND ORGORDERID='" & v_strORGORDERID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If Not v_ds.Tables(0).Rows.Count > 0 Then
                    'Tra ve ma loi lenh chua duoc day len san
                    v_lngErrCode = ERR_OD_SENT_DOESNOTEXIST
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If
                v_dblCostprice = 0

                'Kiem tra Deal khop lenh da duoc thuc hien hay chua
                v_strSQL = "SELECT * FROM IOD WHERE BORS='" & v_strBORS & "' AND CONFIRM_NO='" & v_strCONFIRM_NO & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    'Tra ve ma loi lenh da duoc phan bo
                    v_lngErrCode = ERR_OD_STSCHD_ALLOCATED
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If

                'Ghi nhan vao so lenh nhan IOD
                v_strSQL = "INSERT INTO IOD (ORGORDERID,CODEID,SYMBOL,CUSTODYCD,BORS,NORP,TXDATE,TXNUM," & ControlChars.CrLf _
                                        & "AORN,PRICE,QTTY,EXORDERID,REFCUSTCD,MATCHPRICE,MATCHQTTY,CONFIRM_NO)" & ControlChars.CrLf _
                        & "VALUES ('" & v_strORGORDERID & "','" & v_strCODEID & "','" & v_strSYMBOL & "','" & v_strCUSTODYCD & "','" & v_strBORS & "','" & v_strNORP & "'" & ControlChars.CrLf _
                                        & ",TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'" & v_strTXNUM & "'" & ControlChars.CrLf _
                                        & ",'" & v_strAORN & "'," & v_dblEXPRICE & "," & v_dblEXQTTY & ",'" & v_strREFORDERID & "','" & v_strREFCUSTCD & "'," & v_dblPRICE & "," & v_dblQTTY & ",'" & v_strCONFIRM_NO & "')"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                'Tao lich thanh toan: Moi lenh khop tao 2 lich thanh toan (tien va chung khoan rieng)
                Dim v_strDUETYPE As String


                If v_strBORS = "B" Then 'Lenh mua
                    'Tao lich thanh toan chung khoan
                    v_strDUETYPE = "RS"
                    v_strSQL = "INSERT INTO STSCHD (AUTOID,ORGORDERID,CODEID,DUETYPE,AFACCTNO,ACCTNO,REFORDERID,TXNUM,TXDATE,CLEARDAY,CLEARCD," & ControlChars.CrLf _
                                            & "AMT,AAMT,QTTY,AQTTY,FAMT,STATUS,DELTD,COSTPRICE)" & ControlChars.CrLf _
                            & "VALUES (SEQ_STSCHD.NEXTVAL,'" & v_strORGORDERID & "','" & v_strCODEID & "','" & v_strDUETYPE & "','" & v_strAFACCTNO & "','" & v_strSEACCTNO & "','" & v_strREFORDERID & "','" & v_strTXNUM & "'" & ControlChars.CrLf _
                                            & ",TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')," & v_lngCLEARDAY & ",'" & v_strCLEARCD & "'" & ControlChars.CrLf _
                                            & "," & v_dblPRICE * v_dblQTTY & ",0," & v_dblQTTY & ",0,0,'N','N'," & v_dblCostprice & ")"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                    'Tao lich thanh toan tien
                    v_strDUETYPE = "SM"
                    v_strSQL = "INSERT INTO STSCHD (AUTOID,ORGORDERID,CODEID,DUETYPE,AFACCTNO,ACCTNO,REFORDERID,TXNUM,TXDATE,CLEARDAY,CLEARCD," & ControlChars.CrLf _
                                            & "AMT,AAMT,QTTY,AQTTY,FAMT,STATUS,DELTD,COSTPRICE)" & ControlChars.CrLf _
                            & "VALUES (SEQ_STSCHD.NEXTVAL,'" & v_strORGORDERID & "','" & v_strCODEID & "','" & v_strDUETYPE & "','" & v_strAFACCTNO & "','" & v_strCIACCTNO & "','" & v_strREFORDERID & "','" & v_strTXNUM & "'" & ControlChars.CrLf _
                                            & ",TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')," & v_lngCLEARDAY & ",'" & v_strCLEARCD & "'" & ControlChars.CrLf _
                                            & "," & v_dblPRICE * v_dblQTTY & ",0," & v_dblQTTY & ",0,0,'N','N'," & v_dblCostprice & ")"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                Else 'Lenh ban
                    'Tao lich thanh toan chung khoan
                    v_strDUETYPE = "SS"
                    v_strSQL = "INSERT INTO STSCHD (AUTOID,ORGORDERID,CODEID,DUETYPE,AFACCTNO,ACCTNO,REFORDERID,TXNUM,TXDATE,CLEARDAY,CLEARCD," & ControlChars.CrLf _
                                            & "AMT,AAMT,QTTY,AQTTY,FAMT,STATUS,DELTD,COSTPRICE)" & ControlChars.CrLf _
                            & "VALUES (SEQ_STSCHD.NEXTVAL,'" & v_strORGORDERID & "','" & v_strCODEID & "','" & v_strDUETYPE & "','" & v_strAFACCTNO & "','" & v_strSEACCTNO & "','" & v_strREFORDERID & "','" & v_strTXNUM & "'" & ControlChars.CrLf _
                                            & ",TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')," & v_lngCLEARDAY & ",'" & v_strCLEARCD & "'" & ControlChars.CrLf _
                                            & "," & v_dblPRICE * v_dblQTTY & ",0," & v_dblQTTY & ",0,0,'N','N'," & v_dblCostprice & ")"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                    'Tao lich thanh toan tien
                    v_strDUETYPE = "RM"
                    v_strSQL = "INSERT INTO STSCHD (AUTOID,ORGORDERID,CODEID,DUETYPE,AFACCTNO,ACCTNO,REFORDERID,TXNUM,TXDATE,CLEARDAY,CLEARCD," & ControlChars.CrLf _
                                            & "AMT,AAMT,QTTY,AQTTY,FAMT,STATUS,DELTD,COSTPRICE)" & ControlChars.CrLf _
                            & "VALUES (SEQ_STSCHD.NEXTVAL,'" & v_strORGORDERID & "','" & v_strCODEID & "','" & v_strDUETYPE & "','" & v_strAFACCTNO & "','" & v_strCIACCTNO & "','" & v_strREFORDERID & "','" & v_strTXNUM & "'" & ControlChars.CrLf _
                                            & ",TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')," & v_lngCLEARDAY & ",'" & v_strCLEARCD & "'" & ControlChars.CrLf _
                                            & "," & v_dblPRICE * v_dblQTTY & ",0," & v_dblQTTY & ",0,0,'N','N'," & v_dblCostprice & ")"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                End If

                'Day vao trong  STCTRADEALLOCATION
                v_strSQL = "INSERT INTO GXSTCTRADEALLOCATION (TXDATE,TXNUM,REFCONFIRMNUMBER,ORDERID,BORS,VOLUME,PRICE,DELTD)" & ControlChars.CrLf _
                           & "VALUES (TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'" & v_strTXNUM & "','" & v_strCONFIRM_NO & "','" & v_strORGORDERID & "','" & v_strBORS & "'," & v_dblPRICE & "," & v_dblQTTY & ",'N')"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            Else    'Xoa lenh khop
                'Kiem tra khong cho xoa neu khach hang da thuc hien ung truoc
                v_strSQL = "SELECT AAMT, AQTTY, FAMT, STATUS FROM STSCHD WHERE DELTD<>'Y' AND TXNUM='" & v_strTXNUM & "' AND TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    'Neu da hoan tat thanh toan
                    For i = 0 To v_ds.Tables(0).Rows.Count - 1
                        If Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("STATUS"))) = "C" Then
                            v_lngErrCode = ERR_OD_STSCHD_IS_CLOSED
                            LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                         & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                         & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                            Return v_lngErrCode
                        End If
                        'Neu da duoc ung truoc
                        If gf_CorrectNumericField(v_ds.Tables(0).Rows(i)("AAMT")) +
                                gf_CorrectNumericField(v_ds.Tables(0).Rows(i)("AQTTY")) +
                                gf_CorrectNumericField(v_ds.Tables(0).Rows(i)("FAMT")) > 0 Then
                            v_lngErrCode = ERR_OD_STSCHD_ADVANCED_PAYMENT_ALREADY
                            LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                         & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                         & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                            Return v_lngErrCode
                        End If
                    Next
                End If

                v_strSQL = "UPDATE IOD SET DELTD='Y' WHERE TXNUM='" & v_strTXNUM & "' AND TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                v_strSQL = "UPDATE STSCHD SET DELTD='Y' WHERE TXNUM='" & v_strTXNUM & "' AND TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                v_strSQL = "UPDATE GXSTCTRADEALLOCATION SET DELTD='Y' WHERE TXNUM='" & v_strTXNUM & "' AND TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            End If
            ''ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            ''ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function PlaceOrder(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "OD.Trans.PlaceOrder", v_strErrorMessage As String
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, v_strSQL As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE As Double
            Dim v_strCUSTID, v_strCODEID, v_strACTYPE, v_strAFACCTNO, v_strCIACCTNO, v_strAFSTATUS, v_strSEACCTNO, v_strCUSTODYCD, v_strTIMETYPE,
                v_strDFACCTNO, v_strVOUCHER, v_strCONSULTANT, v_strORDERID,
                v_strEXPDATE, v_strEFFDATE, v_strEXECTYPE, v_strNORK, v_strMATCHTYPE, v_strVIA, v_strCLEARCD, v_strPRICETYPE, v_strDESC, v_strMember, v_strContrafirm, v_strContrafirm2, v_strContraCus, v_strPutType, v_strTraderid, v_strClientID, v_strOutPriceAllow, v_strIsDisposal As String
            Dim v_strTRADEBUYSELL, v_strTRADEPLACE, v_strAdvIdRef As String
            Dim v_dblCLEARDAY, v_dblQUOTEPRICE, v_dblORDERQTTY, v_dblBRATIO, v_dblLIMITPRICE As Double
            Dim v_dblODTYPETRADELIMIT, v_dblAFTRADELIMIT, v_dblAFADVANCELIMIT, v_dblALLOWBRATIO, v_dblODBALANCE As Double
            Dim v_dblSecuredRatioMin, v_dblSecuredRatioMax, v_dblTyp_Bratio, v_dblAF_Bratio, mv_dblSecureRatio, v_dblRoom, v_dblTraderID As Double
            Dim v_ds, v_dsext, v_dsOdm As DataSet
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_strBRID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXTIME As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTIME).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strTLTXCD As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLTXCD), Xml.XmlAttribute).Value)
            'Doc nội dung giao dịch
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
                        Case "02" 'ACTYPE
                            v_strACTYPE = v_strVALUE
                        Case "03" 'AFACCTNO
                            v_strAFACCTNO = v_strVALUE
                        Case "20" 'TIMETYPE                                       
                            v_strTIMETYPE = v_strVALUE
                        Case "19" 'EFFDATE
                            v_strEFFDATE = v_strVALUE
                        Case "21" 'EXPDATE                                       
                            v_strEXPDATE = v_strVALUE
                        Case "22" 'EXECTYPE                                       
                            v_strEXECTYPE = v_strVALUE
                        Case "23" 'NORK                                       
                            v_strNORK = v_strVALUE
                        Case "24" 'MATCHTYPE                                       
                            v_strMATCHTYPE = v_strVALUE
                        Case "25" 'VIA                                       
                            v_strVIA = v_strVALUE
                        Case "26" 'CLEARCD                                       
                            v_strCLEARCD = v_strVALUE
                        Case "27" 'PRICETYPE                                       
                            v_strPRICETYPE = v_strVALUE
                        Case "10" 'CLEARDAY
                            v_dblCLEARDAY = v_dblVALUE
                        Case "11" 'QUOTEPRICE                                         
                            v_dblQUOTEPRICE = v_dblVALUE
                        Case "12" 'ORDERQTTY                                      
                            v_dblORDERQTTY = v_dblVALUE
                        Case "13" 'BRATIO                                      
                            v_dblBRATIO = v_dblVALUE
                        Case "14" 'LIMITPRICE
                            v_dblLIMITPRICE = v_dblVALUE
                        Case "28" 'VOUCHER
                            v_strVOUCHER = v_strVALUE
                        Case "29" 'CONSULTANT
                            v_strCONSULTANT = v_strVALUE
                        Case "04" 'ORDERID
                            v_strORDERID = v_strVALUE
                        Case "30" 'DESC                                              
                            v_strDESC = v_strVALUE
                        Case "50" 'Thong tin nguoi dat lenh
                            v_strMember = v_strVALUE
                        Case "31"
                            v_strContrafirm = v_strVALUE
                        Case "32"
                            v_strTraderid = v_strVALUE
                        Case "33"
                            v_strClientID = v_strVALUE
                        Case "34"
                            v_strOutPriceAllow = v_strVALUE
                        Case "35"
                            'Thanh NV sua Quang cao
                            v_strAdvIdRef = v_strVALUE
                        Case "71"
                            v_strContraCus = v_strVALUE
                        Case "72"
                            v_strPutType = v_strVALUE
                        Case "73"
                            v_strContrafirm2 = v_strVALUE
                        Case "74"
                            v_strIsDisposal = v_strVALUE
                        Case "95"
                            v_strDFACCTNO = v_strVALUE
                    End Select
                End With
            Next
            If v_strTIMETYPE = "G" And Strings.Left(v_strORDERID, 2) <> FO_PREFIXED Then
                'Neu la lenh Good till cancel, ma la lenh dat
                If v_blnReversal Then
                    v_strSQL = "SELECT * FROM FOMAST WHERE ACCTNO ='" & v_strORDERID & "' AND STATUS <> 'P' "
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count > 0 Then
                        'không thể xoá lệnh này
                        v_lngErrCode = gc_ERRCODE_FO_INVALID_STATUS
                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                     & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                     & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                        Return v_lngErrCode
                    End If
                    'Xoa giao dich
                    v_strSQL = "DELETE FROM FOMAST WHERE ACCTNO ='" & v_strORDERID & "'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                Else
                    'Day lenh vao FOMAST
                    'Lay ra ma chung khoan
                    Dim v_strSymbol As String
                    v_strSQL = "SELECT SYMBOL FROM SBSECURITIES WHERE CODEID ='" & v_strCODEID & "' "
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count > 0 Then
                        v_strSymbol = v_ds.Tables(0).Rows(0)("SYMBOL")
                    Else
                        v_strSymbol = ""
                    End If
                    Dim v_strFEEDBACKMSG As String = v_strDESC
                    v_strSQL = "INSERT INTO FOMAST (ACCTNO, ORGACCTNO, ACTYPE, AFACCTNO, STATUS, EXECTYPE, PRICETYPE, TIMETYPE, MATCHTYPE, NORK, CLEARCD, CODEID, SYMBOL, " & ControlChars.CrLf _
                        & "CONFIRMEDVIA, BOOK, FEEDBACKMSG, ACTIVATEDT, CREATEDDT, CLEARDAY, QUANTITY, PRICE, QUOTEPRICE, TRIGGERPRICE, EXECQTTY, EXECAMT, REMAINQTTY,EFFDATE,EXPDATE,BRATIO,VIA,OUTPRICEALLOW,TXNUM,TXDATE,DFACCTNO,ISDISPOSAL)" & ControlChars.CrLf _
                        & "VALUES ('" & v_strORDERID & "','" & v_strORDERID.Trim & "','" & v_strACTYPE.Trim & "','" & v_strAFACCTNO.Trim & "','P'," & ControlChars.CrLf _
                        & "'" & v_strEXECTYPE.Trim & "','" & v_strPRICETYPE.Trim & "','" & v_strTIMETYPE.Trim & "','" & v_strMATCHTYPE.Trim & "'," & ControlChars.CrLf _
                        & "'" & v_strNORK.Trim & "','" & v_strCLEARCD.Trim & "','" & v_strCODEID.Trim & "','" & v_strSymbol.Trim & "'," & ControlChars.CrLf _
                        & "'N','A','" & v_strFEEDBACKMSG.Trim & "',TO_CHAR(SYSDATE,'DD/MM/RRRR HH:MM:SS'),TO_CHAR(SYSDATE,'DD/MM/RRRR HH:MM:SS')," & ControlChars.CrLf _
                        & v_dblCLEARDAY & "," & v_dblORDERQTTY & "," & v_dblLIMITPRICE & "," & v_dblQUOTEPRICE & "," & 0 & "," & 0 & "," & 0 & "," & v_dblORDERQTTY & ",TO_DATE('" & v_strEFFDATE & "', '" & gc_FORMAT_DATE & "'),TO_DATE('" & v_strEXPDATE & "', '" & gc_FORMAT_DATE & "')," & v_dblBRATIO & ",'" & v_strVIA & "','" & v_strOutPriceAllow & "','" & v_strTXNUM & "',TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'" & v_strDFACCTNO & "','" & v_strIsDisposal & "')"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                End If
                Return v_lngErrCode
            End If

            'Lenh today hoac Intemediate or cancel
            'Hoac lenh GTC tu dong day vao he thong
            If v_blnReversal Then
                'Kiem tra neu lenh da co lenh huy sua thi khong cho phep xoa
                v_strSQL = "SELECT 1 FROM ODMAST WHERE REFORDERID ='" & v_strORDERID & "' "
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    'không thể xoá lệnh này
                    v_lngErrCode = ERR_OD_ODMAST_CANNOT_DELETE
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If

                'Kiểm tra xem lệnh có được phép xoá hay không
                v_strSQL = "SELECT 1 FROM ODMAST WHERE TXNUM='" & v_strTXNUM & "' AND TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') AND ORSTATUS IN ('1','2','8') "
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If Not v_ds.Tables(0).Rows.Count > 0 Then
                    'không thể xoá lệnh này
                    v_lngErrCode = ERR_OD_ODMAST_CANNOT_DELETE
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If
                'Xoá giao dịch
                v_strSQL = "UPDATE ODMAST SET DELTD='Y' WHERE TXNUM='" & v_strTXNUM & "' AND TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                v_strSQL = "UPDATE OOD SET DELTD='Y' WHERE TXNUM='" & v_strTXNUM & "' AND TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            Else


                'Kiểm tra mã loại hình hợp đồng có tồn tại không
                v_dblALLOWBRATIO = 1
                v_strSQL = "SELECT TRADELIMIT,BRATIO FROM ODTYPE WHERE STATUS='Y' AND ACTYPE='" & v_strACTYPE & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_dblODTYPETRADELIMIT = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("TRADELIMIT"))
                    v_dblALLOWBRATIO = v_dblALLOWBRATIO * gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("BRATIO")) / 100
                    v_dblTyp_Bratio = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("BRATIO"))
                Else
                    'Trả ve mã lỗi loại hình hợp đồng không tồn tại
                    v_lngErrCode = ERR_OD_ODTYPE_NOTFOUND
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: ERR_OD_ODTYPE_NOTFOUND", "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If

                'Kiểm tra mã hợp đồng đã tồn tại chưa
                v_strSQL = "SELECT * FROM AFMAST WHERE ACCTNO='" & v_strAFACCTNO & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_strCIACCTNO = CStr(v_ds.Tables(0).Rows(0)("CIACCTNO"))
                    v_strSEACCTNO = v_strAFACCTNO & v_strCODEID
                    v_strCUSTID = CStr(v_ds.Tables(0).Rows(0)("CUSTID"))
                    v_strAFSTATUS = CStr(v_ds.Tables(0).Rows(0)("STATUS"))
                    v_dblAFTRADELIMIT = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("TRADELINE"))
                    v_dblAFADVANCELIMIT = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("ADVANCELINE"))
                    v_dblALLOWBRATIO = v_dblALLOWBRATIO * gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("BRATIO")) / 100
                    v_dblAF_Bratio = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("BRATIO"))
                    If Trim(v_strAFSTATUS) <> "A" Then
                        v_lngErrCode = ERR_CF_AFMAST_STATUS_INVALIDE
                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                     & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                     & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                        Return v_lngErrCode
                    End If
                Else
                    'Trả ve mã lỗi không tồn tại mã hợp đồng
                    v_lngErrCode = ERR_CF_AFMAST_NOTFOUND
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If

                'Kiem tra ma khach hang co ton tai khong
                v_strSQL = "SELECT CUSTODYCD FROM CFMAST WHERE CUSTID='" & v_strCUSTID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_strCUSTODYCD = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("CUSTODYCD"))
                Else
                    v_lngErrCode = ERR_CF_CUSTOMER_NOTFOUND
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If

                Dim v_dblTradeLot, v_dblTradeUnit, v_dblFloorPrice, v_dblCeilingPrice, v_dblTickSize, v_dblFromPrice As Double, v_strSYMBOL As String
                v_strSQL = "SELECT * FROM SECURITIES_INFO WHERE CODEID='" & v_strCODEID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_dblTradeLot = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("TRADELOT"))
                    v_dblTradeUnit = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("TRADEUNIT"))
                    If v_dblTradeUnit > 0 Then
                        v_dblQUOTEPRICE = FRound(v_dblQUOTEPRICE * v_dblTradeUnit, 0)
                    End If
                    v_dblFloorPrice = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("FLOORPRICE"))
                    v_dblCeilingPrice = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("CEILINGPRICE"))
                    v_dblSecuredRatioMax = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("SECURERATIOMAX"))
                    v_dblSecuredRatioMin = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("SECURERATIOTMIN"))
                    v_dblRoom = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("CURRENT_ROOM"))
                    v_strSYMBOL = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("SYMBOL"))
                    ''Kiem tra lenh mua nha dau tu nuoc ngoai co con ROOM
                    'If v_strEXECTYPE = "NB" And (Left(Mid(v_strCUSTODYCD, 4), 1) = "F" Or Left(Mid(v_strCUSTODYCD, 4), 1) = "E") Then
                    '    If v_dblORDERQTTY > v_dblRoom Then
                    '        v_lngErrCode = ERR_OD_ROOM_NOT_ENOUGH
                    '        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                    '                     & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                    '                     & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    '        Return v_lngErrCode
                    '    End If
                    'End If
                    ''Kiểm tra khối lượng có chia hết cho TRADE_LOT không
                    'If v_dblTradeLot > 0 And v_strMATCHTYPE <> "P" Then
                    '    If v_dblORDERQTTY Mod v_dblTradeLot <> 0 Then
                    '        v_lngErrCode = ERR_OD_QTTY_TRADELOT_INCORRECT
                    '        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                    '                     & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                    '                     & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    '        Return v_lngErrCode
                    '    End If
                    'End If

                    ''Dối với lệnh LO thì giá phải nằm trong khoảng CEILING/FLOOR của bảng SECURITIES_INFO
                    'If v_strPRICETYPE = "LO" Then
                    '    If v_dblQUOTEPRICE < v_dblFloorPrice Or v_dblQUOTEPRICE > v_dblCeilingPrice Then
                    '        v_lngErrCode = ERR_OD_LO_PRICE_ISNOT_FLOOR_CEILLING
                    '        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                    '                     & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                    '                     & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    '        Return v_lngErrCode
                    '    End If
                    'End If

                    'Dối với lệnh LO (Limit Order), SL (Stop Limit Order) thì kiểm tra ticksize của giá
                    'If v_strPRICETYPE = "LO" Or v_strPRICETYPE = "SL" Then
                    '    v_strSQL = "SELECT FROMPRICE, TICKSIZE FROM SECURITIES_TICKSIZE WHERE TRIM(CODEID)='" & v_strCODEID & "' AND TRIM(STATUS)='Y' " _
                    '                            & "AND TOPRICE>=" & v_dblQUOTEPRICE & " AND FROMPRICE<=" & v_dblQUOTEPRICE
                    '    v_dsext = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    '    If v_dsext.Tables(0).Rows.Count > 0 Then
                    '        v_dblTickSize = gf_CorrectNumericField(v_dsext.Tables(0).Rows(0)("TICKSIZE"))
                    '        v_dblFromPrice = gf_CorrectNumericField(v_dsext.Tables(0).Rows(0)("FROMPRICE"))
                    '        If (v_dblQUOTEPRICE - v_dblFromPrice) Mod v_dblTickSize <> 0 And v_strMATCHTYPE <> "P" Then
                    '            'Không đúng với TICKSIZE
                    '            v_lngErrCode = ERR_OD_TICKSIZE_INCOMPLIANT
                    '            LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                    '                         & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                    '                         & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    '            Return v_lngErrCode
                    '        End If
                    '    Else
                    '        'Chưa định nghĩa TICKSIZE
                    '        v_lngErrCode = ERR_OD_TICKSIZE_UNDEFINED
                    '        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                    '                     & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                    '                     & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    '        Return v_lngErrCode
                    '    End If
                    'End If

                    'Kiểm tra chứng khoán có được phép vừa mua/bán trong ngày không TRADEBUYSELL của bảng SECURITIES_INFO

                    'v_strTRADEBUYSELL = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("TRADEBUYSELL"))
                    'If v_strTRADEBUYSELL = "N" Then
                    '    If v_strEXECTYPE = "NB" Or v_strEXECTYPE = "BC" Then
                    '        'Nếu là lệnh mua thì kiểm tra có lệnh bán nào không
                    '        'v_strSQL = "SELECT COUNT(*) CNT FROM ODMAST WHERE TRIM(CODEID)='" & v_strCODEID & "' AND TRIM(AFACCTNO)='" & v_strAFACCTNO & "' " _
                    '        '    & "AND (EXECTYPE='NS' OR EXECTYPE='SS') AND DELTD = 'N' AND EXPDATE >= TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')"
                    '        v_strSQL = "SELECT COUNT(*) CNT FROM ODMAST WHERE TRIM(CODEID)='" & v_strCODEID & "' AND TRIM(AFACCTNO) IN (SELECT ACCTNO FROM AFMAST WHERE CUSTID=(SELECT CUSTID FROM AFMAST WHERE ACCTNO='" & v_strAFACCTNO & "')) " _
                    '                & "AND (EXECTYPE='NS' OR EXECTYPE='SS' OR EXECTYPE='MS') AND DELTD = 'N' AND EXPDATE >= TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')  AND REMAINQTTY+EXECQTTY>0 "
                    '    Else
                    '        'Nếu là lệnh bán thì kiểm tra có lệnh mua nào không
                    '        'v_strSQL = "SELECT COUNT(*) CNT FROM ODMAST WHERE TRIM(CODEID)='" & v_strCODEID & "' AND TRIM(AFACCTNO)='" & v_strAFACCTNO & "' " _
                    '        '    & "AND (EXECTYPE='NB' OR EXECTYPE='BC') AND DELTD = 'N' AND EXPDATE >= TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')"
                    '        v_strSQL = "SELECT COUNT(*) CNT FROM ODMAST WHERE TRIM(CODEID)='" & v_strCODEID & "' AND TRIM(AFACCTNO) IN (SELECT ACCTNO FROM AFMAST WHERE CUSTID=(SELECT CUSTID FROM AFMAST WHERE ACCTNO='" & v_strAFACCTNO & "')) " _
                    '            & "AND (EXECTYPE='NB' OR EXECTYPE='BC') AND DELTD = 'N' AND EXPDATE >= TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')  AND REMAINQTTY+EXECQTTY>0 "
                    '    End If
                    '    v_dsext = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    '    If gf_CorrectNumericField(v_dsext.Tables(0).Rows(0)("CNT")) > 0 Then
                    '        'Báo lỗi không thể cùng mua cùng bán một chứng khoán trong cùng một ngày
                    '        v_lngErrCode = ERR_OD_BUYSELL_SAME_SECURITIES
                    '        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                    '                     & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                    '                     & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    '        Return v_lngErrCode
                    '    End If
                    'End If
                Else
                    'Báo lỗi chưa khai báo SECURITIES_INFO
                    v_lngErrCode = ERR_OD_SECURITIES_INFO_UNDEFINED
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If

                ''Nếu vượt hạn mức giao dịch của hợp đồng thì checker 1 duyệt
                'v_strSQL = "SELECT SUM(QUOTEPRICE*ORDERQTTY) AMT FROM ODMAST WHERE TRIM(AFACCTNO)='" & v_strAFACCTNO & "'"
                'v_dsext = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                'If v_dblQUOTEPRICE * v_dblORDERQTTY + gf_CorrectNumericField(v_dsext.Tables(0).Rows(0)("AMT")) > v_dblAFTRADELIMIT Then
                '    v_strOVRRQD = v_strOVRRQD & OVRRQS_AFTRADELIMIT
                '    pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value = v_strOVRRQD
                'End If

                ''Kiểm tra các đieu kiện ve duyệt giao dịch
                ''Xử lý trả ve nguyên nhân duyệt
                'If InStr(v_strTLTXCD, gc_OD_PLACENORMALBUYORDER_ADVANCED & "/" & gc_OD_PLACENORMALSELLORDER_ADVANCED) > 0 Then
                '    If Len(Trim(Replace(v_strOVRRQD, OVRRQS_CHECKER_CONTROL, vbNullString))) > 0 And Len(v_strCHKID) = 0 Then
                '        v_lngErrCode = ERR_SA_CHECKER1_OVR
                '    Else
                '        If InStr(v_strOVRRQD, OVRRQS_CHECKER_CONTROL) > 0 And Len(v_strOFFID) = 0 Then
                '            v_lngErrCode = ERR_SA_CHECKER2_OVR
                '        End If
                '    End If
                '    If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode
                'End If

                If Len(v_strMember) > 0 Then
                    v_strCUSTID = v_strMember
                End If

                'Cap nhat lai gio dat 
                v_strSQL = "SELECT TO_CHAR(SYSDATE,'HH24:MI:SS') TXTIME FROM DUAL"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_strTXTIME = v_ds.Tables(0).Rows(0)("TXTIME")
                End If

                Select Case v_strTLTXCD
                    Case gc_OD_PLACEORDER

                        'Ghi nhận vào sổ lệnh ODMAST với trạng thái là Open
                        v_strSQL = "INSERT INTO ODMAST (ORDERID,CUSTID,ACTYPE,CODEID,AFACCTNO,SEACCTNO,CIACCTNO," & ControlChars.CrLf _
                                                & "TXNUM,TXDATE,TXTIME,EXPDATE,BRATIO,TIMETYPE," & ControlChars.CrLf _
                                                & "EXECTYPE,NORK,MATCHTYPE,VIA,CLEARDAY,CLEARCD,ORSTATUS,PORSTATUS,PRICETYPE," & ControlChars.CrLf _
                                                & "QUOTEPRICE,STOPPRICE,LIMITPRICE,ORDERQTTY,REMAINQTTY," & ControlChars.CrLf _
                                                & "EXECQTTY,STANDQTTY,CANCELQTTY,ADJUSTQTTY,REJECTQTTY,REJECTCD,VOUCHER,CONSULTANT,CONTRAFIRM, TRADERID,CLIENTID,PUTTYPE,CONTRAORDERID,CONTRAFRM,DFACCTNO)" & ControlChars.CrLf _
                                & "VALUES ('" & v_strORDERID & "','" & v_strCUSTID & "','" & v_strACTYPE & "','" & v_strCODEID & "','" & v_strAFACCTNO & "','" & v_strSEACCTNO & "','" & v_strCIACCTNO & "'" & ControlChars.CrLf _
                                                & ",'" & v_strTXNUM & "',TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'" & v_strTXTIME & "'" & ControlChars.CrLf _
                                                & ",TO_DATE('" & v_strEXPDATE & "', '" & gc_FORMAT_DATE & "')," & v_dblBRATIO & ",'" & v_strTIMETYPE & "'" & ControlChars.CrLf _
                                                & ",'" & v_strEXECTYPE & "','" & v_strNORK & "','" & v_strMATCHTYPE & "','" & v_strVIA & "'" & ControlChars.CrLf _
                                                & "," & v_dblCLEARDAY & ",'" & v_strCLEARCD & "','1','1','" & v_strPRICETYPE & "'" & ControlChars.CrLf _
                                                & "," & v_dblQUOTEPRICE & ",0," & v_dblLIMITPRICE & "," & v_dblORDERQTTY & ",0,0,0,0,0,0,'001','" & v_strVOUCHER & "','" & v_strCONSULTANT & "','" & v_strContrafirm & "','" & v_strTraderid & "','" & v_strClientID & "','" & v_strPutType & "','" & v_strContraCus & "','" & v_strContrafirm2 & "','" & v_strDFACCTNO & "')"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                    Case gc_OD_PLACENORMALBUYORDER
                        'Ghi nhận vào sổ lệnh ODMAST với trạng thái là send va PORSTATUS='9'
                        v_strSQL = "INSERT INTO ODMAST (ORDERID,CUSTID,ACTYPE,CODEID,AFACCTNO,SEACCTNO,CIACCTNO," & ControlChars.CrLf _
                                                & "TXNUM,TXDATE,TXTIME,EXPDATE,BRATIO,TIMETYPE," & ControlChars.CrLf _
                                                & "EXECTYPE,NORK,MATCHTYPE,VIA,CLEARDAY,CLEARCD,ORSTATUS,PORSTATUS,PRICETYPE," & ControlChars.CrLf _
                                                & "QUOTEPRICE,STOPPRICE,LIMITPRICE,ORDERQTTY,REMAINQTTY,EXPRICE,EXQTTY,SECUREDAMT," & ControlChars.CrLf _
                                                & "EXECQTTY,STANDQTTY,CANCELQTTY,ADJUSTQTTY,REJECTQTTY,REJECTCD,VOUCHER,CONSULTANT,FOACCTNO,PUTTYPE,CONTRAORDERID,CONTRAFRM)" & ControlChars.CrLf _
                                & "VALUES ('" & v_strORDERID & "','" & v_strCUSTID & "','" & v_strACTYPE & "','" & v_strCODEID & "','" & v_strAFACCTNO & "','" & v_strSEACCTNO & "','" & v_strCIACCTNO & "'" & ControlChars.CrLf _
                                                & ",'" & v_strTXNUM & "',TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'" & v_strTXTIME & "'" & ControlChars.CrLf _
                                                & ",TO_DATE('" & v_strEXPDATE & "', '" & gc_FORMAT_DATE & "')," & v_dblBRATIO & ",'" & v_strTIMETYPE & "'" & ControlChars.CrLf _
                                                & ",'" & v_strEXECTYPE & "','" & v_strNORK & "','" & v_strMATCHTYPE & "','" & v_strVIA & "'" & ControlChars.CrLf _
                                                & "," & v_dblCLEARDAY & ",'" & v_strCLEARCD & "','8','9','" & v_strPRICETYPE & "'" & ControlChars.CrLf _
                                                & "," & v_dblQUOTEPRICE & ",0," & v_dblLIMITPRICE & "," & v_dblORDERQTTY & "," & v_dblORDERQTTY & "," & v_dblQUOTEPRICE & "," & v_dblORDERQTTY & ",0,0,0,0,0,0,'001','" & v_strVOUCHER & "','" & v_strCONSULTANT & "','" & IIf(v_strTIMETYPE = "G", v_strMember, "") & "','" & v_strPutType & "','" & v_strContraCus & "','" & v_strContrafirm2 & "')"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                        'Ghi nhận vào sổ lệnh đẩy đi
                        v_strSQL = "INSERT INTO OOD (ORGORDERID,CODEID,SYMBOL,CUSTODYCD," & ControlChars.CrLf _
                                                & "BORS,NORP,AORN,PRICE,QTTY,SECUREDRATIO,OODSTATUS,TXDATE,TXNUM,DELTD,BRID)" & ControlChars.CrLf _
                                & "VALUES ('" & v_strORDERID & "','" & v_strCODEID & "','" & v_strSYMBOL & "','" & v_strCUSTODYCD & "','B','" & v_strMATCHTYPE & "'" & ControlChars.CrLf _
                                                & ",'" & v_strNORK & "'," & v_dblQUOTEPRICE & "," & v_dblORDERQTTY & "," & v_dblBRATIO & ",'N',TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'" & v_strTXNUM & "','N','" & v_strBRID & "')"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                    Case gc_OD_PLACENORMALSELLORDER
                        'Ghi nhận vào sổ lệnh ODMAST với trạng thái là send va PORSTATUS='9'
                        v_strSQL = "INSERT INTO ODMAST (ORDERID,CUSTID,ACTYPE,CODEID,AFACCTNO,SEACCTNO,CIACCTNO," & ControlChars.CrLf _
                                                & "TXNUM,TXDATE,TXTIME,EXPDATE,BRATIO,TIMETYPE," & ControlChars.CrLf _
                                                & "EXECTYPE,NORK,MATCHTYPE,VIA,CLEARDAY,CLEARCD,ORSTATUS,PORSTATUS,PRICETYPE," & ControlChars.CrLf _
                                                & "QUOTEPRICE,STOPPRICE,LIMITPRICE,ORDERQTTY,REMAINQTTY,EXPRICE,EXQTTY," & ControlChars.CrLf _
                                                & "EXECQTTY,STANDQTTY,CANCELQTTY,ADJUSTQTTY,REJECTQTTY,REJECTCD,VOUCHER,CONSULTANT,FOACCTNO,PUTTYPE,CONTRAORDERID,CONTRAFRM,DFACCTNO, ISDISPOSAL)" & ControlChars.CrLf _
                                & "VALUES ('" & v_strORDERID & "','" & v_strCUSTID & "','" & v_strACTYPE & "','" & v_strCODEID & "','" & v_strAFACCTNO & "','" & v_strSEACCTNO & "','" & v_strCIACCTNO & "'" & ControlChars.CrLf _
                                                & ",'" & v_strTXNUM & "',TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'" & v_strTXTIME & "'" & ControlChars.CrLf _
                                                & ",TO_DATE('" & v_strEXPDATE & "', '" & gc_FORMAT_DATE & "')," & v_dblBRATIO & ",'" & v_strTIMETYPE & "'" & ControlChars.CrLf _
                                                & ",'" & v_strEXECTYPE & "','" & v_strNORK & "','" & v_strMATCHTYPE & "','" & v_strVIA & "'" & ControlChars.CrLf _
                                                & "," & v_dblCLEARDAY & ",'" & v_strCLEARCD & "','8','9','" & v_strPRICETYPE & "'" & ControlChars.CrLf _
                                                & "," & v_dblQUOTEPRICE & ",0," & v_dblLIMITPRICE & "," & v_dblORDERQTTY & "," & v_dblORDERQTTY & "," & v_dblQUOTEPRICE & "," & v_dblORDERQTTY & ",0,0,0,0,0,'001','" & v_strVOUCHER & "','" & v_strCONSULTANT & "','" & IIf(v_strTIMETYPE = "G", v_strMember, "") & "','" & v_strPutType & "','" & v_strContraCus & "','" & v_strContrafirm2 & "','" & v_strDFACCTNO & "','" & v_strIsDisposal & "')"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                        'Ghi nhận vào sổ lệnh đẩy đi
                        v_strSQL = "INSERT INTO OOD (ORGORDERID,CODEID,SYMBOL,CUSTODYCD," & ControlChars.CrLf _
                                              & "BORS,NORP,AORN,PRICE,QTTY,SECUREDRATIO,OODSTATUS,TXDATE,TXNUM,DELTD,BRID)" & ControlChars.CrLf _
                              & "VALUES ('" & v_strORDERID & "','" & v_strCODEID & "','" & v_strSYMBOL & "','" & v_strCUSTODYCD & "','S','" & v_strMATCHTYPE & "'" & ControlChars.CrLf _
                                              & ",'" & v_strNORK & "'," & v_dblQUOTEPRICE & "," & v_dblORDERQTTY & "," & v_dblBRATIO & ",'N',TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'" & v_strTXNUM & "','N','" & v_strBRID & "')"

                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                    Case gc_OD_PLACENORMALBUYORDER_ADVANCEd
                        'Ghi nhận vào sổ lệnh ODMAST với trạng thái là send
                        v_strSQL = "INSERT INTO ODMAST (ORDERID,CUSTID,ACTYPE,CODEID,AFACCTNO,SEACCTNO,CIACCTNO," & ControlChars.CrLf _
                                               & "TXNUM,TXDATE,TXTIME,EXPDATE,BRATIO,TIMETYPE," & ControlChars.CrLf _
                                               & "EXECTYPE,NORK,MATCHTYPE,VIA,CLEARDAY,CLEARCD,ORSTATUS,PORSTATUS,PRICETYPE," & ControlChars.CrLf _
                                               & "QUOTEPRICE,STOPPRICE,LIMITPRICE,ORDERQTTY,REMAINQTTY,EXPRICE,EXQTTY,SECUREDAMT," & ControlChars.CrLf _
                                               & "EXECQTTY,STANDQTTY,CANCELQTTY,ADJUSTQTTY,REJECTQTTY,REJECTCD,VOUCHER,CONSULTANT,CONTRAFIRM, TRADERID,CLIENTID,FOACCTNO,PUTTYPE,CONTRAORDERID,CONTRAFRM,ADVIDREF)" & ControlChars.CrLf _
                               & "VALUES ('" & v_strORDERID & "','" & v_strCUSTID & "','" & v_strACTYPE & "','" & v_strCODEID & "','" & v_strAFACCTNO & "','" & v_strSEACCTNO & "','" & v_strCIACCTNO & "'" & ControlChars.CrLf _
                                               & ",'" & v_strTXNUM & "',TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'" & v_strTXTIME & "'" & ControlChars.CrLf _
                                               & ",TO_DATE('" & v_strEXPDATE & "', '" & gc_FORMAT_DATE & "')," & v_dblBRATIO & ",'" & v_strTIMETYPE & "'" & ControlChars.CrLf _
                                               & ",'" & v_strEXECTYPE & "','" & v_strNORK & "','" & v_strMATCHTYPE & "','" & v_strVIA & "'" & ControlChars.CrLf _
                                               & "," & v_dblCLEARDAY & ",'" & v_strCLEARCD & "','8','8','" & v_strPRICETYPE & "'" & ControlChars.CrLf _
                                               & "," & v_dblQUOTEPRICE & ",0," & v_dblLIMITPRICE & "," & v_dblORDERQTTY & "," & v_dblORDERQTTY & "," & v_dblQUOTEPRICE & "," & v_dblORDERQTTY & ",0,0,0,0,0,0,'001','" & v_strVOUCHER & "','" & v_strCONSULTANT & "','" & v_strContrafirm & "','" & v_strTraderid & "','" & v_strClientID & "','" & IIf(v_strTIMETYPE = "G", v_strMember, "") & "','" & v_strPutType & "','" & v_strContraCus & "','" & v_strContrafirm2 & "','" & v_strAdvIdRef & "')"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                        'Ghi nhận vào sổ lệnh đẩy đi
                        v_strSQL = "INSERT INTO OOD (ORGORDERID,CODEID,SYMBOL,CUSTODYCD," & ControlChars.CrLf _
                                               & "BORS,NORP,AORN,PRICE,QTTY,SECUREDRATIO,OODSTATUS,TXDATE,TXNUM,DELTD,BRID)" & ControlChars.CrLf _
                               & "VALUES ('" & v_strORDERID & "','" & v_strCODEID & "','" & v_strSYMBOL & "','" & v_strCUSTODYCD & "','B','" & v_strMATCHTYPE & "'" & ControlChars.CrLf _
                                               & ",'" & v_strNORK & "'," & v_dblQUOTEPRICE & "," & v_dblORDERQTTY & "," & v_dblBRATIO & ",'N',TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'" & v_strTXNUM & "','N','" & v_strBRID & "')"

                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                    Case gc_OD_PLACENORMALSELLORDER_ADVANCEd
                        'Ghi nhận vào sổ lệnh ODMAST với trạng thái là send
                        v_strSQL = "INSERT INTO ODMAST (ORDERID,CUSTID,ACTYPE,CODEID,AFACCTNO,SEACCTNO,CIACCTNO," & ControlChars.CrLf _
                                                & "TXNUM,TXDATE,TXTIME,EXPDATE,BRATIO,TIMETYPE," & ControlChars.CrLf _
                                                & "EXECTYPE,NORK,MATCHTYPE,VIA,CLEARDAY,CLEARCD,ORSTATUS,PORSTATUS,PRICETYPE," & ControlChars.CrLf _
                                                & "QUOTEPRICE,STOPPRICE,LIMITPRICE,ORDERQTTY,REMAINQTTY,EXPRICE,EXQTTY," & ControlChars.CrLf _
                                                & "EXECQTTY,STANDQTTY,CANCELQTTY,ADJUSTQTTY,REJECTQTTY,REJECTCD,VOUCHER,CONSULTANT,CONTRAFIRM, TRADERID,CLIENTID,FOACCTNO,PUTTYPE,CONTRAORDERID,CONTRAFRM,ADVIDREF,DFACCTNO,ISDISPOSAL)" & ControlChars.CrLf _
                                & "VALUES ('" & v_strORDERID & "','" & v_strCUSTID & "','" & v_strACTYPE & "','" & v_strCODEID & "','" & v_strAFACCTNO & "','" & v_strSEACCTNO & "','" & v_strCIACCTNO & "'" & ControlChars.CrLf _
                                                & ",'" & v_strTXNUM & "',TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'" & v_strTXTIME & "'" & ControlChars.CrLf _
                                                & ",TO_DATE('" & v_strEXPDATE & "', '" & gc_FORMAT_DATE & "')," & v_dblBRATIO & ",'" & v_strTIMETYPE & "'" & ControlChars.CrLf _
                                                & ",'" & v_strEXECTYPE & "','" & v_strNORK & "','" & v_strMATCHTYPE & "','" & v_strVIA & "'" & ControlChars.CrLf _
                                                & "," & v_dblCLEARDAY & ",'" & v_strCLEARCD & "','8','8','" & v_strPRICETYPE & "'" & ControlChars.CrLf _
                                                & "," & v_dblQUOTEPRICE & ",0," & v_dblLIMITPRICE & "," & v_dblORDERQTTY & "," & v_dblORDERQTTY & "," & v_dblQUOTEPRICE & "," & v_dblORDERQTTY & ",0,0,0,0,0,'001','" & v_strVOUCHER & "','" & v_strCONSULTANT & "','" & v_strContrafirm & "','" & v_strTraderid & "','" & v_strClientID & "','" & IIf(v_strTIMETYPE = "G", v_strMember, "") & "','" & v_strPutType & "','" & v_strContraCus & "','" & v_strContrafirm2 & "','" & v_strAdvIdRef & "','" & v_strDFACCTNO & "','" & v_strIsDisposal & "')"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                        'Ghi nhận vào sổ lệnh đẩy đi
                        v_strSQL = "INSERT INTO OOD (ORGORDERID,CODEID,SYMBOL,CUSTODYCD," & ControlChars.CrLf _
                                               & "BORS,NORP,AORN,PRICE,QTTY,SECUREDRATIO,OODSTATUS,TXDATE,TXNUM,DELTD,BRID)" & ControlChars.CrLf _
                               & "VALUES ('" & v_strORDERID & "','" & v_strCODEID & "','" & v_strSYMBOL & "','" & v_strCUSTODYCD & "','S','" & v_strMATCHTYPE & "'" & ControlChars.CrLf _
                                               & ",'" & v_strNORK & "'," & v_dblQUOTEPRICE & "," & v_dblORDERQTTY & "," & v_dblBRATIO & ",'N',TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'" & v_strTXNUM & "','N','" & v_strBRID & "')"

                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                End Select

                ''ContextUtil.SetComplete()
            End If
            Return v_lngErrCode
        Catch ex As Exception
            ''ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function


    Private Function InquiryOrder(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "OD.Trans.InquiryOrder", v_strErrorMessage As String
        Dim v_strSQL As String = String.Empty
        Dim v_ds As DataSet
        Dim v_obj As New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE As Double, i As Integer
            'Doc noi dung giao dich
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            Dim v_strTLID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTLID).Value
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
                        Case "04" 'NEXT TRANSACTION                                            
                    End Select
                End With
            Next
            'Kiem tra ma hop dong co ton tai chua
            v_strSQL = "SELECT * FROM ODMAST WHERE TRIM(ORDERID)='" & ATTR_ACCTNO & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If Not v_ds.Tables(0).Rows.Count > 0 Then
                'Tra ve ma loi khong ton tai hop dong
                v_lngErrCode = ERR_OD_ORDERID_NOTDOUND
                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                             & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                             & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                Return v_lngErrCode
            Else
                If v_strTLID <> ADMIN_ID Then
                    Dim v_strAFAcctno As String = v_ds.Tables(0).Rows(0)("AFACCTNO")
                    v_strSQL = "SELECT * FROM AFMAST AF,CFMAST CF,TLGROUPS GRP,TLGRPUSERS TLGRP   " & ControlChars.CrLf _
                            & " WHERE AF.CUSTID=CF.CUSTID  AND CF.CAREBY=GRP.GRPID AND GRP.GRPID=TLGRP.GRPID AND TLGRP.TLID='" & v_strTLID & "' AND AF.ACCTNO='" & v_strAFAcctno & "'  " & ControlChars.CrLf
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If Not v_ds.Tables(0).Rows.Count > 0 Then
                        'Tra ve ma loi khong ton tai hop dong
                        v_lngErrCode = ERR_CF_NOT_CAREBY
                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                     & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                     & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                        Return v_lngErrCode
                    End If
                End If
            End If
            'Goi ham de lay du lieu vao, chan theo Care by
            If v_strTLID = ADMIN_ID Then
                ATTR_CMDMISCINQUIRY = "SELECT MST.ORDERID, MST.ACTYPE, MST.CODEID, CCY.SYMBOL, CCY.PARVALUE, MST.AFACCTNO, MST.SEACCTNO, MST.CIACCTNO,  " & ControlChars.CrLf _
                        & "CF.FULLNAME CUSTNAME, CF.CUSTODYCD, CF.ADDRESS, CF.IDCODE LICENSE, CI.RAMT, CI.AAMT, CI.RAMT-CI.AAMT AVLAMT, CI.BALANCE, CI.ODAMT, CI.BAMT, SE.SECURED,  " & ControlChars.CrLf _
                        & "MST.TXDATE,MST.TXTIME, MST.TXNUM, MST.EXPDATE, MST.BRATIO, MST.BRATIO/100 SRATIO, MST.CLEARDAY, MST.VOUCHER, MST.EXECAMT-MST.EXAMT AVLEXAMT, " & ControlChars.CrLf _
                        & "MST.QUOTEPRICE, MST.STOPPRICE, MST.LIMITPRICE, MST.EXPRICE, MST.EXQTTY, MST.EXECAMT, MST.EXAMT, MST.FEEAMT, MST.FEEACR, MST.RLSSECURED, MST.MATCHAMT, MST.SECUREDAMT," & ControlChars.CrLf _
                        & "(CASE WHEN MST.ORDERQTTY-MST.EXECQTTY-MST.ADJUSTQTTY-MST.CANCELQTTY>0 THEN MST.ORDERQTTY-MST.EXECQTTY-MST.ADJUSTQTTY-MST.CANCELQTTY ELSE 0 END) AVLCANCELQTTY, " & ControlChars.CrLf _
                        & "(CASE WHEN EXECTYPE='NB' OR EXECTYPE='BC' THEN 1 ELSE 0 END)*(CASE WHEN MST.SECUREDAMT-MST.MATCHAMT-MST.RLSSECURED>0 THEN MST.SECUREDAMT-MST.MATCHAMT-MST.RLSSECURED ELSE 0 END) AVLCANCELAMT, " & ControlChars.CrLf _
                        & "(CASE WHEN EXECTYPE='NB' OR EXECTYPE='BC' THEN 1 ELSE 0 END)*(CASE WHEN MST.SECUREDAMT-(MST.EXPRICE*MST.REMAINQTTY+MST.MATCHAMT)-MST.RLSSECURED>0 THEN MST.SECUREDAMT-(MST.EXPRICE*MST.REMAINQTTY+MST.MATCHAMT)-MST.RLSSECURED ELSE 0 END) AVLSECUREDAMT, " & ControlChars.CrLf _
                        & "(CASE WHEN EXECTYPE='NB' OR EXECTYPE='BC' THEN 1 ELSE 0 END)*(CASE WHEN MST.SECUREDAMT-(MST.MATCHAMT)-MST.RLSSECURED>0 THEN MST.SECUREDAMT-(MST.MATCHAMT)-MST.RLSSECURED ELSE 0 END) AVLNONSECUREDAMT, " & ControlChars.CrLf _
                        & "(CASE WHEN EXECTYPE='NB' OR EXECTYPE='BC' THEN 1 ELSE 1 END)*(CASE WHEN MST.SECUREDAMT-(MST.EXPRICE*MST.REMAINQTTY+MST.MATCHAMT+MST.FEEACR)-MST.RLSSECURED<0 THEN (MST.EXPRICE*MST.REMAINQTTY+MST.MATCHAMT+MST.FEEACR)+ MST.RLSSECURED-MST.SECUREDAMT ELSE 0 END) AVLDEPOSITAMT, " & ControlChars.CrLf _
                        & "(CASE WHEN MST.ORDERQTTY-MST.REMAINQTTY-MST.EXECQTTY-MST.ADJUSTQTTY-MST.CANCELQTTY>0 THEN MST.ORDERQTTY-MST.REMAINQTTY-MST.EXECQTTY-MST.ADJUSTQTTY-MST.CANCELQTTY ELSE 0 END) QTTY, " & ControlChars.CrLf _
                        & "(CASE WHEN EXECTYPE='NB' OR EXECTYPE='BC' THEN 'B' ELSE 'S' END) BORS, " & ControlChars.CrLf _
                        & "(CASE WHEN NORK='N' THEN 'N' ELSE 'A' END) AORN, " & ControlChars.CrLf _
                        & "(CASE WHEN MATCHTYPE='N' THEN 'N' ELSE 'P' END) NORP, " & ControlChars.CrLf _
                        & "MST.ORDERQTTY, MST.REMAINQTTY, MST.EXECQTTY, MST.STANDQTTY, MST.CANCELQTTY, MST.ADJUSTQTTY, MST.REJECTQTTY,  " & ControlChars.CrLf _
                        & "MST.TIMETYPE, MST.EXECTYPE, MST.NORK, MST.MATCHTYPE, MST.VIA, MST.CLEARCD, MST.ORSTATUS, MST.PRICETYPE, MST.REJECTCD,  " & ControlChars.CrLf _
                        & "CD1.CDCONTENT DESC_TIMETYPE, CD2.CDCONTENT DESC_EXECTYPE, CD3.CDCONTENT DESC_NORK, CD4.CDCONTENT DESC_MATCHTYPE,  " & ControlChars.CrLf _
                        & "CD5.CDCONTENT DESC_VIA, CD6.CDCONTENT DESC_CLEARCD, CD7.CDCONTENT DESC_ORSTATUS, CD8.CDCONTENT DESC_PRICETYPE, CD9.CDCONTENT DESC_REJECTCD  " & ControlChars.CrLf _
                    & "FROM ODMAST MST, AFMAST AF, CFMAST CF, SBSECURITIES CCY, CIMAST CI,SEMAST SE,  " & ControlChars.CrLf _
                    & "ALLCODE CD1, ALLCODE CD2, ALLCODE CD3, ALLCODE CD4, ALLCODE CD5, ALLCODE CD6, ALLCODE CD7, ALLCODE CD8, ALLCODE CD9  " & ControlChars.CrLf _
                    & "WHERE TRIM(MST.AFACCTNO) = TRIM(AF.ACCTNO) And TRIM(MST.CIACCTNO) = TRIM(CI.ACCTNO) AND TRIM(MST.SEACCTNO) = TRIM(SE.ACCTNO)  " & ControlChars.CrLf _
                        & "AND TRIM(AF.CUSTID) = TRIM(CF.CUSTID) AND TRIM(MST.CODEID) = TRIM(CCY.CODEID)  " & ControlChars.CrLf _
                        & "AND TRIM(MST.ORDERID) = '" & ATTR_ACCTNO & "'  " & ControlChars.CrLf _
                        & "AND CD1.CDTYPE='OD' AND CD1.CDNAME='TIMETYPE' AND CD1.CDVAL=MST.TIMETYPE  " & ControlChars.CrLf _
                        & "AND CD2.CDTYPE='OD' AND CD2.CDNAME='EXECTYPE' AND CD2.CDVAL=MST.EXECTYPE  " & ControlChars.CrLf _
                        & "AND CD3.CDTYPE='OD' AND CD3.CDNAME='NORK' AND CD3.CDVAL=MST.NORK  " & ControlChars.CrLf _
                        & "AND CD4.CDTYPE='OD' AND CD4.CDNAME='MATCHTYPE' AND CD4.CDVAL=MST.MATCHTYPE  " & ControlChars.CrLf _
                        & "AND CD5.CDTYPE='OD' AND CD5.CDNAME='VIA' AND CD5.CDVAL=MST.VIA  " & ControlChars.CrLf _
                        & "AND CD6.CDTYPE='OD' AND CD6.CDNAME='CLEARCD' AND CD6.CDVAL=MST.CLEARCD  " & ControlChars.CrLf _
                        & "AND CD7.CDTYPE='OD' AND CD7.CDNAME='ORSTATUS' AND CD7.CDVAL=MST.ORSTATUS  " & ControlChars.CrLf _
                        & "AND CD8.CDTYPE='OD' AND CD8.CDNAME='PRICETYPE' AND CD8.CDVAL=MST.PRICETYPE  " & ControlChars.CrLf _
                        & "AND CD9.CDTYPE='OD' AND CD9.CDNAME='REJECTCD' AND CD9.CDVAL=MST.REJECTCD " & ControlChars.CrLf

            Else
                ATTR_CMDMISCINQUIRY = "SELECT MST.ORDERID, MST.ACTYPE, MST.CODEID, CCY.SYMBOL, CCY.PARVALUE, MST.AFACCTNO, MST.SEACCTNO, MST.CIACCTNO,  " & ControlChars.CrLf _
                                        & "CF.FULLNAME CUSTNAME, CF.CUSTODYCD, CF.ADDRESS, CF.IDCODE LICENSE, CI.RAMT, CI.AAMT, CI.RAMT-CI.AAMT AVLAMT, CI.BALANCE, CI.ODAMT, CI.BAMT, SE.SECURED,  " & ControlChars.CrLf _
                                        & "MST.TXDATE,MST.TXTIME, MST.TXNUM, MST.EXPDATE, MST.BRATIO, MST.BRATIO/100 SRATIO, MST.CLEARDAY, MST.VOUCHER, MST.EXECAMT-MST.EXAMT AVLEXAMT, " & ControlChars.CrLf _
                                        & "MST.QUOTEPRICE, MST.STOPPRICE, MST.LIMITPRICE, MST.EXPRICE, MST.EXQTTY, MST.EXECAMT, MST.EXAMT, MST.FEEAMT, MST.FEEACR, MST.RLSSECURED, MST.MATCHAMT, MST.SECUREDAMT," & ControlChars.CrLf _
                                        & "(CASE WHEN MST.ORDERQTTY-MST.EXECQTTY-MST.ADJUSTQTTY-MST.CANCELQTTY>0 THEN MST.ORDERQTTY-MST.EXECQTTY-MST.ADJUSTQTTY-MST.CANCELQTTY ELSE 0 END) AVLCANCELQTTY, " & ControlChars.CrLf _
                                        & "(CASE WHEN EXECTYPE='NB' OR EXECTYPE='BC' THEN 1 ELSE 0 END)*(CASE WHEN MST.SECUREDAMT-MST.MATCHAMT-MST.RLSSECURED>0 THEN MST.SECUREDAMT-MST.MATCHAMT-MST.RLSSECURED ELSE 0 END) AVLCANCELAMT, " & ControlChars.CrLf _
                                        & "(CASE WHEN EXECTYPE='NB' OR EXECTYPE='BC' THEN 1 ELSE 0 END)*(CASE WHEN MST.SECUREDAMT-(MST.EXPRICE*MST.REMAINQTTY+MST.MATCHAMT)-MST.RLSSECURED>0 THEN MST.SECUREDAMT-(MST.EXPRICE*MST.REMAINQTTY+MST.MATCHAMT)-MST.RLSSECURED ELSE 0 END) AVLSECUREDAMT, " & ControlChars.CrLf _
                                        & "(CASE WHEN EXECTYPE='NB' OR EXECTYPE='BC' THEN 1 ELSE 0 END)*(CASE WHEN MST.SECUREDAMT-(MST.MATCHAMT)-MST.RLSSECURED>0 THEN MST.SECUREDAMT-(MST.MATCHAMT)-MST.RLSSECURED ELSE 0 END) AVLNONSECUREDAMT, " & ControlChars.CrLf _
                                        & "(CASE WHEN EXECTYPE='NB' OR EXECTYPE='BC' THEN 1 ELSE 1 END)*(CASE WHEN MST.SECUREDAMT-(MST.EXPRICE*MST.REMAINQTTY+MST.MATCHAMT+MST.FEEACR)-MST.RLSSECURED<0 THEN (MST.EXPRICE*MST.REMAINQTTY+MST.MATCHAMT+MST.FEEACR)+ MST.RLSSECURED-MST.SECUREDAMT ELSE 0 END) AVLDEPOSITAMT, " & ControlChars.CrLf _
                                        & "(CASE WHEN MST.ORDERQTTY-MST.REMAINQTTY-MST.EXECQTTY-MST.ADJUSTQTTY-MST.CANCELQTTY>0 THEN MST.ORDERQTTY-MST.REMAINQTTY-MST.EXECQTTY-MST.ADJUSTQTTY-MST.CANCELQTTY ELSE 0 END) QTTY, " & ControlChars.CrLf _
                                        & "(CASE WHEN EXECTYPE='NB' OR EXECTYPE='BC' THEN 'B' ELSE 'S' END) BORS, " & ControlChars.CrLf _
                                        & "(CASE WHEN NORK='N' THEN 'N' ELSE 'A' END) AORN, " & ControlChars.CrLf _
                                        & "(CASE WHEN MATCHTYPE='N' THEN 'N' ELSE 'P' END) NORP, " & ControlChars.CrLf _
                                        & "MST.ORDERQTTY, MST.REMAINQTTY, MST.EXECQTTY, MST.STANDQTTY, MST.CANCELQTTY, MST.ADJUSTQTTY, MST.REJECTQTTY,  " & ControlChars.CrLf _
                                        & "MST.TIMETYPE, MST.EXECTYPE, MST.NORK, MST.MATCHTYPE, MST.VIA, MST.CLEARCD, MST.ORSTATUS, MST.PRICETYPE, MST.REJECTCD,  " & ControlChars.CrLf _
                                        & "CD1.CDCONTENT DESC_TIMETYPE, CD2.CDCONTENT DESC_EXECTYPE, CD3.CDCONTENT DESC_NORK, CD4.CDCONTENT DESC_MATCHTYPE,  " & ControlChars.CrLf _
                                        & "CD5.CDCONTENT DESC_VIA, CD6.CDCONTENT DESC_CLEARCD, CD7.CDCONTENT DESC_ORSTATUS, CD8.CDCONTENT DESC_PRICETYPE, CD9.CDCONTENT DESC_REJECTCD  " & ControlChars.CrLf _
                                    & "FROM ODMAST MST, AFMAST AF, CFMAST CF,TLGROUPS GRP,TLGRPUSERS TLGRP, SBSECURITIES CCY, CIMAST CI,SEMAST SE,  " & ControlChars.CrLf _
                                    & "ALLCODE CD1, ALLCODE CD2, ALLCODE CD3, ALLCODE CD4, ALLCODE CD5, ALLCODE CD6, ALLCODE CD7, ALLCODE CD8, ALLCODE CD9  " & ControlChars.CrLf _
                                    & "WHERE TRIM(MST.AFACCTNO) = TRIM(AF.ACCTNO) And TRIM(MST.CIACCTNO) = TRIM(CI.ACCTNO) AND TRIM(MST.SEACCTNO) = TRIM(SE.ACCTNO)  " & ControlChars.CrLf _
                                        & "AND TRIM(AF.CUSTID) = TRIM(CF.CUSTID) AND TRIM(MST.CODEID) = TRIM(CCY.CODEID)  " & ControlChars.CrLf _
                                        & "AND TRIM(MST.ORDERID) = '" & ATTR_ACCTNO & "'  " & ControlChars.CrLf _
                                        & "AND CD1.CDTYPE='OD' AND CD1.CDNAME='TIMETYPE' AND CD1.CDVAL=MST.TIMETYPE  " & ControlChars.CrLf _
                                        & "AND CD2.CDTYPE='OD' AND CD2.CDNAME='EXECTYPE' AND CD2.CDVAL=MST.EXECTYPE  " & ControlChars.CrLf _
                                        & "AND CD3.CDTYPE='OD' AND CD3.CDNAME='NORK' AND CD3.CDVAL=MST.NORK  " & ControlChars.CrLf _
                                        & "AND CD4.CDTYPE='OD' AND CD4.CDNAME='MATCHTYPE' AND CD4.CDVAL=MST.MATCHTYPE  " & ControlChars.CrLf _
                                        & "AND CD5.CDTYPE='OD' AND CD5.CDNAME='VIA' AND CD5.CDVAL=MST.VIA  " & ControlChars.CrLf _
                                        & "AND CD6.CDTYPE='OD' AND CD6.CDNAME='CLEARCD' AND CD6.CDVAL=MST.CLEARCD  " & ControlChars.CrLf _
                                        & "AND CD7.CDTYPE='OD' AND CD7.CDNAME='ORSTATUS' AND CD7.CDVAL=MST.ORSTATUS  " & ControlChars.CrLf _
                                        & "AND CD8.CDTYPE='OD' AND CD8.CDNAME='PRICETYPE' AND CD8.CDVAL=MST.PRICETYPE  " & ControlChars.CrLf _
                                        & "AND CD9.CDTYPE='OD' AND CD9.CDNAME='REJECTCD' AND CD9.CDVAL=MST.REJECTCD " & ControlChars.CrLf _
                                        & "AND CF.CAREBY=GRP.GRPID AND GRP.GRPID=TLGRP.GRPID AND TLGRP.TLID='" & v_strTLID & "'"
            End If

            v_lngErrCode = Me.txCoreMiscInquiry(pv_xmlDocument)
            ''ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            ''ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
    Private Function RefuseAmendOrder(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "OD.Trans.FinishOrder", v_strErrorMessage As String
        Dim v_obj As New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)
        Dim v_strSQL As String = String.Empty
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE As Double, i As Integer
            Dim v_strorderid As String
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
                        Case "03" 'ORDERID
                            v_strorderid = v_strVALUE

                    End Select
                End With
            Next


            v_strSQL = "UPDATE OOD SET OODSTATUS = 'E' WHERE ORGORDERID = '" & v_strorderid & "'"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            'v_strSQL = "UPDATE ODMAST SET ORSTATUS = '0' WHERE ORDERID = '" & v_strorderid & "'"
            'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)


            ''ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            ''ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
    Private Function FinishOrder(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "OD.Trans.FinishOrder", v_strErrorMessage As String
        Dim v_obj As New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)
        Dim v_strSQL As String = String.Empty
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE As Double, i As Integer
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
                        Case "03" 'ORDERID
                            ATTR_ACCTNO = v_strVALUE
                        Case "05" 'ODSTATUS
                            Me.ATTR_FRDATE = v_strVALUE
                    End Select
                End With
            Next
            'Thuc hien chuyen lenh tu ODMAST sang ODMASTHIST
            v_strSQL = "INSERT INTO ODMASTHIST SELECT * FROM ODMAST WHERE ODMAST.ORDERID='" & ATTR_ACCTNO & "'"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            v_strSQL = "DELETE ODMAST WHERE ODMAST.ORDERID='" & ATTR_ACCTNO & "'"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            ''ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            ''ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function HistoryOrder(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "OD.Trans.HistoryOrder", v_strErrorMessage As String

        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE As Double, i As Integer
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
                        Case "03" 'ACCTNO
                            ATTR_ACCTNO = v_strVALUE
                        Case "05" 'FRDATE
                            Me.ATTR_FRDATE = v_strVALUE
                        Case "06" 'TODATE
                            Me.ATTR_TODATE = v_strVALUE
                    End Select
                End With
            Next
            'Goi ham de lay du lieu vao
            ATTR_CMDMISCINQUIRY = "SELECT * FROM " & ControlChars.CrLf _
                & "(SELECT DISTINCT LF.TXDATE, LF.TXNUM, LF.TLTXCD, LF.TXDESC, FLD.NVALUE AMT,TX.TXDESC TLTXDESC,TX.EN_TXDESC TLTXEN_DESC " & ControlChars.CrLf _
                & "FROM ODTRAN TRF, TLLOG LF, TLLOGFLD FLD, TLTX TX " & ControlChars.CrLf _
                & "WHERE TRF.TXNUM = LF.TXNUM AND TRF.TXDATE = LF.TXDATE AND LF.DELTD <> 'Y' " & ControlChars.CrLf _
                & "AND TX.TLTXCD = LF.TLTXCD AND LF.TXNUM=FLD.TXNUM AND LF.TXDATE=FLD.TXDATE AND TX.MSG_AMT=FLD.FLDCD " & ControlChars.CrLf _
                & "AND TRIM(TRF.ACCTNO)='" & ATTR_ACCTNO & "' " & ControlChars.CrLf _
                & "UNION ALL " & ControlChars.CrLf _
                & "SELECT DISTINCT LF.TXDATE, LF.TXNUM, LF.TLTXCD, LF.TXDESC, FLD.NVALUE AMT,TX.TXDESC TLTXDESC,TX.EN_TXDESC TLTXEN_DESC " & ControlChars.CrLf _
                & "FROM ODTRANA TRF, TLLOGALL LF, TLLOGFLDALL FLD, TLTX TX " & ControlChars.CrLf _
                & "WHERE TRF.TXNUM = LF.TXNUM AND TRF.TXDATE = LF.TXDATE AND LF.DELTD <> 'Y' " & ControlChars.CrLf _
                & "AND TX.TLTXCD = LF.TLTXCD AND LF.TXNUM=FLD.TXNUM AND LF.TXDATE=FLD.TXDATE AND TX.MSG_AMT=FLD.FLDCD " & ControlChars.CrLf _
                & "AND TRIM(TRF.ACCTNO)='" & ATTR_ACCTNO & "') LOGDATA " & ControlChars.CrLf _
                & "ORDER BY TXDATE, TXNUM"
            v_lngErrCode = Me.txCoreMiscInquiry(pv_xmlDocument)
            ''ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            ''ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function HistoryIBTSTS(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "OD.Trans.HistoryOrder", v_strErrorMessage As String

        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE As Double, i As Integer
            Dim v_strSTSBR, v_strTXBR As String
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
                        Case "01" 'FRDATE
                            ATTR_FRDATE = v_strVALUE
                        Case "02" 'TODATE
                            ATTR_TODATE = v_strVALUE
                        Case "04" 'STSBR
                            v_strSTSBR = v_strVALUE
                        Case "05" 'TXBR
                            v_strTXBR = v_strVALUE
                    End Select
                End With
            Next
            'Goi ham de lay du lieu vao
            If v_strSTSBR = "0000" Then
                v_strSTSBR = ""
            End If
            If v_strTXBR = "0000" Then
                v_strTXBR = ""
            End If
            ATTR_CMDMISCINQUIRY = "SELECT TO_DATE('" & ATTR_FRDATE & "', '" & gc_FORMAT_DATE & "') FRDATE,TO_DATE('" & ATTR_TODATE & "', '" & gc_FORMAT_DATE & "')TODATE, SUBSTR(ORGORDERID,1,4) TXBR,SUBSTR(AFACCTNO,1,4) STSBR, " & ControlChars.CrLf _
                & "SUM (CASE WHEN DUETYPE='RM' THEN AMT ELSE 0 END) RCVAMT,SUM (CASE WHEN DUETYPE='SM' THEN AMT ELSE 0 END) TRFAMT " & ControlChars.CrLf _
                & "FROM (SELECT * FROM STSCHDHIST UNION SELECT * FROM STSCHD) STSCHDHIST WHERE DUETYPE IN ('RM','SM') AND DELTD <> 'Y' AND STATUS='C' AND TXDATE >= TO_DATE('" & ATTR_FRDATE & "', '" & gc_FORMAT_DATE & "') AND TXDATE <=TO_DATE('" & ATTR_TODATE & "', '" & gc_FORMAT_DATE & "')  " & ControlChars.CrLf _
                & "AND SUBSTR(ORGORDERID,1,4) LIKE '%" & Trim(v_strSTSBR) & "%' AND SUBSTR(AFACCTNO,1,4) LIKE '%" & Trim(v_strTXBR) & "%' " & ControlChars.CrLf _
                & "GROUP BY SUBSTR(ORGORDERID,1,4),SUBSTR(AFACCTNO,1,4) " & ControlChars.CrLf _
                & "" & ControlChars.CrLf

            v_lngErrCode = Me.txCoreMiscInquiry(pv_xmlDocument)
            ''ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            ''ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function ClearingScheduleInquiry(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "OD.Trans.HistoryOrder", v_strErrorMessage As String

        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE As Double, i As Integer
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
                        Case "03" 'AFACCTNO
                            ATTR_ACCTNO = v_strVALUE
                        Case "05" 'FRDATE
                            Me.ATTR_FRDATE = v_strVALUE
                        Case "06" 'TODATE
                            Me.ATTR_TODATE = v_strVALUE
                    End Select
                End With
            Next
            'Goi ham lay du lieu vao
            ATTR_CMDMISCINQUIRY = "SELECT SCHD.AUTOID,GETDUEDATE(SCHD.TXDATE,SCHD.CLEARCD,SYM.TRADEPLACE,SCHD.CLEARDAY) GETDUEDATE, (CASE WHEN SCHD.DUETYPE='RS' OR SCHD.DUETYPE='SS' THEN 'SE' ELSE 'CI' END) MODCODE, SCHD.DUETYPE, " & ControlChars.CrLf _
                & "SYM.SYMBOL, SYM.CODEID, SYM.PARVALUE, SCHD.AFACCTNO, SCHD.AFACCTNO CIACCTNO, SCHD.AFACCTNO || SCHD.CODEID SEACCTNO, " & ControlChars.CrLf _
                & "A1.CDCONTENT DESC_DUETYPE,A2.CDCONTENT DESC_CLEARCD,A3.CDCONTENT DESC_STATUS,A4.CDCONTENT DESC_DELTD, " & ControlChars.CrLf _
                & "(CASE WHEN (SCHD.AMT + (OD.FEEACR-OD.FEEAMT) - (OD.SECUREDAMT-OD.RLSSECURED))>0 THEN (SCHD.AMT + (OD.FEEACR-OD.FEEAMT) - (OD.SECUREDAMT-OD.RLSSECURED)) ELSE 0 END) CRSECUREDAMT, " & ControlChars.CrLf _
                & "SCHD.STATUS, SCHD.DUETYPE, SCHD.TXDATE, SCHD.CLEARCD, SCHD.CLEARDAY, SCHD.AMT, SCHD.AAMT, SCHD.QTTY, SCHD.AQTTY, SCHD.FAMT, SCHD.AMT/SCHD.QTTY MATCHPRICE," & ControlChars.CrLf _
                & "SCHD.ORGORDERID ORDERID, OD.SECUREDAMT, OD.RLSSECURED, OD.FEEAMT, OD.FEEACR, OD.SECUREDAMT-OD.RLSSECURED AVLSECUREDAMT, OD.FEEACR-OD.FEEAMT AVLFEEAMT " & ControlChars.CrLf _
                & "FROM AFMAST AF, CFMAST CF, STSCHD SCHD, ODMAST OD, SBSECURITIES SYM, ALLCODE A1,ALLCODE A2,ALLCODE A3,ALLCODE A4 " & ControlChars.CrLf _
                & "WHERE SCHD.AFACCTNO = AF.ACCTNO AND AF.CUSTID = CF.CUSTID AND SCHD.ORGORDERID=OD.ORDERID AND SYM.CODEID=SCHD.CODEID " & ControlChars.CrLf _
                & "AND A1.CDTYPE = 'OD' AND A1.CDNAME = 'DUETYPE' AND A1.CDVAL= SCHD.DUETYPE " & ControlChars.CrLf _
                & "AND A2.CDTYPE = 'OD' AND A2.CDNAME = 'CLEARCD' AND A2.CDVAL= SCHD.CLEARCD " & ControlChars.CrLf _
                & "AND A3.CDTYPE = 'OD' AND A3.CDNAME = 'CALENDARSTATUS' AND A3.CDVAL= SCHD.STATUS " & ControlChars.CrLf _
                & "AND A4.CDTYPE = 'SY' AND A4.CDNAME = 'YESNO' AND A4.CDVAL= SCHD.DELTD " & ControlChars.CrLf _
                & "AND SCHD.AFACCTNO = '" & ATTR_ACCTNO & "'  " & ControlChars.CrLf _
                & "AND GETDUEDATE(SCHD.TXDATE,SCHD.CLEARCD,SYM.TRADEPLACE,SCHD.CLEARDAY)>=TO_DATE('" & ATTR_FRDATE & "', '" & gc_FORMAT_DATE & "') " & ControlChars.CrLf _
                & "AND SCHD.TXDATE<=TO_DATE('" & ATTR_TODATE & "', '" & gc_FORMAT_DATE & "') " & ControlChars.CrLf _
                & "AND SCHD.DELTD <> 'Y'" & ControlChars.CrLf _
                & "ORDER BY TXDATE, MODCODE"
            v_lngErrCode = Me.txCoreMiscInquiry(pv_xmlDocument)
            ''ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            ''ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function CancelOrder(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "OD.Trans.CancelOrder", v_strErrorMessage As String

        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, v_strSQL As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE As Double
            Dim v_strCUSTID, v_strCODEID, v_strACTYPE, v_strAFACCTNO, v_strCIACCTNO, v_strAFSTATUS, v_strSEACCTNO, v_strCUSTODYCD, v_strTIMETYPE,
                v_strVOUCHER, v_strCONSULTANT, v_strORDERID, v_strCUROODSTATUS,
                v_strEXPDATE, v_strEFFDATE, v_strEXECTYPE, v_strNORK, v_strMATCHTYPE, v_strVIA,
                v_strCLEARCD, v_strPRICETYPE, v_strSymbol, v_strDESC, v_strCancelOrderID, v_strOutPriceAllow, v_strCOREBANK As String
            Dim v_dblCLEARDAY, v_dblQUOTEPRICE, v_dblORDERQTTY, v_dblBRATIO, v_dblIsMortage, v_dblLIMITPRICE, v_dblAdvanceAmount As Double
            Dim v_dblODTYPETRADELIMIT, v_dblAFTRADELIMIT, v_dblALLOWBRATIO As Double
            Dim v_strSecuredAmt As Double
            Dim v_dblSecuredRatioMin, v_dblSecuedRatioMax, v_dblTyp_Bratio, v_dblAF_Bratio, mv_dblSecureRatio As Double
            Dim v_dblCorrecionNumber As Double
            Dim v_ds, v_dsext As DataSet
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)


            Dim v_strBRID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value
            Dim v_strTLTXCD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXTIME As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTIME).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_blnREVERSAL As Boolean = IIf(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value = "Y", True, False)
            Dim v_dblActualSecured As Double
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
                        Case "01" 'CODEID
                            v_strCODEID = v_strVALUE
                        Case "02" 'ACTYPE
                            v_strACTYPE = v_strVALUE
                        Case "03" 'AFACCTNO
                            v_strAFACCTNO = v_strVALUE
                        Case "20" 'TIMETYPE                                       
                            v_strTIMETYPE = v_strVALUE
                        Case "19" 'EFFDATE
                            v_strEFFDATE = v_strVALUE
                        Case "21" 'EXPDATE                                       
                            v_strEXPDATE = v_strVALUE
                        Case "22" 'EXECTYPE                                       
                            v_strEXECTYPE = v_strVALUE
                        Case "23" 'NORK                                       
                            v_strNORK = v_strVALUE
                        Case "24" 'MATCHTYPE                                       
                            v_strMATCHTYPE = v_strVALUE
                        Case "25" 'VIA                                       
                            v_strVIA = v_strVALUE
                        Case "26" 'CLEARCD                                       
                            v_strCLEARCD = v_strVALUE
                        Case "27" 'PRICETYPE                                       
                            v_strPRICETYPE = v_strVALUE
                        Case "10" 'CLEARDAY
                            v_dblCLEARDAY = v_dblVALUE
                        Case "11" 'QUOTEPRICE                                         
                            v_dblQUOTEPRICE = v_dblVALUE    'GIA YEU CAU HUY
                        Case "12" 'ORDERQTTY                                      
                            v_dblORDERQTTY = v_dblVALUE     'KHOI LUONG YEU CAU HUY
                        Case "13" 'BRATIO                                      
                            v_dblBRATIO = v_dblVALUE
                        Case "14" 'LIMITPRICE
                            v_dblLIMITPRICE = v_dblVALUE
                        Case "18" 'ADVAMT
                            v_dblAdvanceAmount = v_dblVALUE
                        Case "28" 'VOUCHER
                            v_strVOUCHER = v_strVALUE
                        Case "29" 'CONSULTANT
                            v_strCONSULTANT = v_strVALUE
                        Case "04" 'ORDERID
                            v_strORDERID = v_strVALUE
                        Case "07" 'Symbol
                            v_strSymbol = v_strVALUE
                        Case "08" 'Cancel Order ID
                            v_strCancelOrderID = v_strVALUE
                        Case "09"
                            v_strCUSTODYCD = v_strVALUE
                        Case "30" 'DESC                                              
                            v_strDESC = v_strVALUE
                        Case "60" 'Is Mortage
                            v_dblIsMortage = v_dblVALUE
                        Case "34"
                            v_strOutPriceAllow = v_strVALUE
                    End Select
                End With
            Next

            'TungNT added - lay thong tin tai khoan co phai la tk corebank hay ko
            v_strSQL = "SELECT CI.COREBANK FROM DDMAST CI WHERE AFACCTO='" & v_strAFACCTNO & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_strCOREBANK = v_ds.Tables(0).Rows(0)("COREBANK").ToString().Trim().ToUpper()
            Else
                v_lngErrCode = ERR_CI_AFACCTNO_NOTFOUND
                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                             & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                             & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                Return v_lngErrCode
            End If
            'End

            'Neu la lenh GTC thi 
            'Neu chua day vao he thong thi huy, sua luon
            'Neu da day vao he thong thi nhu binh thuong
            If v_strTIMETYPE = "G" Then
                If Not v_blnREVERSAL Then
                    If v_strTLTXCD = gc_OD_CANCELBUYORDER Or v_strTLTXCD = gc_OD_CANCELSELLORDER Or v_strTLTXCD = gc_OD_AMENDMENTBUYORDER Or v_strTLTXCD = gc_OD_AMENDMENTSELLORDER Then
                        v_strSQL = "SELECT 1 A,EXECTYPE FROM FOMAST WHERE ACCTNO='" & v_strCancelOrderID & "' AND DELTD<>'Y' AND STATUS<> 'A' UNION SELECT 0 A,EXECTYPE FROM ODMAST WHERE ORDERID='" & v_strCancelOrderID & "'"
                        v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                        If v_ds.Tables(0).Rows.Count > 0 Then
                            'Lenh da day vao he thong
                            If v_ds.Tables(0).Rows(0)("A") = 1 Then
                                'Lenh GTO trong FOMAST chua duoc day vao he thong
                                If v_strTLTXCD = gc_OD_CANCELBUYORDER Or v_strTLTXCD = gc_OD_CANCELSELLORDER Then
                                    'Lenh huy
                                    v_strSQL = "UPDATE FOMAST SET DELTD='Y',REFACCTNO='" & v_strORDERID & "' WHERE ACCTNO='" & v_strCancelOrderID & "'"
                                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                                    Return v_lngErrCode
                                Else
                                    'LENH SUA
                                    v_strSQL = "UPDATE FOMAST SET DELTD='Y',REFACCTNO='" & v_strORDERID & "' WHERE ACCTNO='" & v_strCancelOrderID & "'"
                                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                                    Dim v_strFEEDBACKMSG As String = v_strDESC
                                    v_strSQL = "INSERT INTO FOMAST (ACCTNO, ORGACCTNO, ACTYPE, AFACCTNO, STATUS, EXECTYPE, PRICETYPE, TIMETYPE, MATCHTYPE, NORK, CLEARCD, CODEID, SYMBOL, " & ControlChars.CrLf _
                                        & "CONFIRMEDVIA, BOOK, FEEDBACKMSG, ACTIVATEDT, CREATEDDT, CLEARDAY, QUANTITY, PRICE, QUOTEPRICE, TRIGGERPRICE, EXECQTTY, EXECAMT, REMAINQTTY,TXDATE,TXNUM,EFFDATE,EXPDATE,BRATIO,VIA,OUTPRICEALLOW)" & ControlChars.CrLf _
                                        & "VALUES ('" & v_strORDERID & "','" & v_strORDERID.Trim & "','" & v_strACTYPE.Trim & "','" & v_strAFACCTNO.Trim & "','P'," & ControlChars.CrLf _
                                        & "'" & v_ds.Tables(0).Rows(0)("EXECTYPE").Trim & "','" & v_strPRICETYPE.Trim & "','" & v_strTIMETYPE.Trim & "','" & v_strMATCHTYPE.Trim & "'," & ControlChars.CrLf _
                                        & "'" & v_strNORK.Trim & "','" & v_strCLEARCD.Trim & "','" & v_strCODEID.Trim & "','" & v_strSymbol.Trim & "'," & ControlChars.CrLf _
                                        & "'N','A','" & v_strFEEDBACKMSG.Trim & "',TO_CHAR(SYSDATE,'DD/MM/RRRR HH:MM:SS'),TO_CHAR(SYSDATE,'DD/MM/RRRR HH:MM:SS')," & ControlChars.CrLf _
                                        & v_dblCLEARDAY & "," & v_dblORDERQTTY & "," & v_dblLIMITPRICE & "," & v_dblQUOTEPRICE & "," & 0 & "," & 0 & "," & 0 & "," & v_dblORDERQTTY & ",TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'" & v_strTXNUM & "',TO_DATE('" & v_strEFFDATE & "', '" & gc_FORMAT_DATE & "'),TO_DATE('" & v_strEXPDATE & "', '" & gc_FORMAT_DATE & "')," & v_dblBRATIO & ",'" & v_strVIA & "','" & v_strOutPriceAllow & "')"
                                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                                    Return v_lngErrCode
                                End If
                            Else '=0
                                'Lenh GTO cua ODMAST
                                'Khong xu ly gi, xu ly nhu lenh binh thuong o phan sau
                            End If
                        Else
                            'Lenh GTC tu FOMAST da duoc day vao ODMAST
                            v_lngErrCode = ERR_OD_ORDER_SENDING
                            LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                         & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                         & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                            Return v_lngErrCode
                        End If
                    End If
                Else
                    If v_strTLTXCD = gc_OD_CANCELBUYORDER Or v_strTLTXCD = gc_OD_CANCELSELLORDER Or v_strTLTXCD = gc_OD_AMENDMENTBUYORDER Or v_strTLTXCD = gc_OD_AMENDMENTSELLORDER Then
                        v_strSQL = "SELECT 1 A FROM FOMAST WHERE ACCTNO='" & v_strCancelOrderID & "' AND DELTD='Y' AND STATUS<>'A' UNION SELECT 0 A FROM ODMAST WHERE ORDERID='" & v_strCancelOrderID & "'"
                        v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                        If v_ds.Tables(0).Rows.Count > 0 Then
                            'Lenh da day vao he thong
                            If v_ds.Tables(0).Rows(0)("A") = 1 Then
                                'Lenh GTC trong FOMAST chua duoc day vao he thong
                                If v_strTLTXCD = gc_OD_CANCELBUYORDER Or v_strTLTXCD = gc_OD_CANCELSELLORDER Then
                                    'Lenh huy
                                    v_strSQL = "UPDATE FOMAST SET DELTD='N',REFACCTNO='' WHERE ACCTNO='" & v_strCancelOrderID & "'"
                                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                                Else
                                    'KIEM TRA XEM LENH SUA MOI DA SEND DI CHUA
                                    v_strSQL = "SELECT 1 A FROM FOMAST WHERE ACCTNO='" & v_strORDERID & "' AND DELTD <> 'Y' AND STATUS='P' "
                                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                                    If v_ds.Tables(0).Rows.Count > 0 Then
                                        'LENH SUA
                                        v_strSQL = "UPDATE FOMAST SET DELTD='N',REFACCTNO='' WHERE ACCTNO='" & v_strCancelOrderID & "'"
                                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                                        v_strSQL = "DELETE FROM FOMAST WHERE ACCTNO='" & v_strORDERID & "'"
                                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                                    Else
                                        'Lenh GTC tu FOMAST da duoc day vao ODMAST
                                        v_lngErrCode = ERR_OD_ORDER_SENDING
                                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                                     & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                                     & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                                        Return v_lngErrCode
                                    End If

                                End If
                            Else '=0
                                'Lenh GTO cua ODMAST
                                'Khong xu ly gi, xu ly nhu lenh binh thuong o phan sau
                            End If
                        Else
                            'Lenh GTC tu FOMAST da duoc day vao ODMAST
                            v_lngErrCode = ERR_OD_ORDER_SENDING
                            LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                         & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                         & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                            Return v_lngErrCode
                        End If
                    End If
                End If
            End If
            'LENH KHAC GTC
            'HOAC LENH GTC DA DAY VAO HE THONG
            If Not v_blnREVERSAL Then
                'Kiem tra xem neu lenh huy chua doc ma dang o trang thai block cho doc thi khong cho phep huy
                If v_strTLTXCD = gc_OD_CANCELBUYORDER Or v_strTLTXCD = gc_OD_CANCELSELLORDER Or v_strTLTXCD = gc_OD_AMENDMENTBUYORDER Or v_strTLTXCD = gc_OD_AMENDMENTSELLORDER Then
                    v_strSQL = "SELECT A.OODSTATUS FROM OOD A, ODQUEUE B WHERE A.ORGORDERID=B.ORGORDERID  AND A.ORGORDERID='" & v_strCancelOrderID & "'"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count > 0 Then
                        v_strCUROODSTATUS = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("OODSTATUS"))
                        If v_strCUROODSTATUS = "B" Then
                            'Lenh dang view de send khong huy duoc, doi khi send xong hoac reject lai roi huy.
                            v_lngErrCode = ERR_OD_ORDER_SENDING
                            LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                         & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                         & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                            Return v_lngErrCode
                        ElseIf v_strCUROODSTATUS = "D" Then
                            'Lenh chua Send, khi view block ve trang thai D
                            v_strCUROODSTATUS = "N"
                        End If
                    Else
                        v_strCUROODSTATUS = "N"
                    End If
                End If
                'Kiem tra xem lenh da vuot qua so lan cho phep huy sua hay chua. Neu vuot qua bao loi
                'Lay ra so lan duoc phep
                v_lngErrCode = v_obj.GetSysVar("SYSTEM", "CORRECTIONNUMBER", v_strVALUE)
                v_dblCorrecionNumber = CDbl(v_strVALUE)
                v_strSQL = "SELECT CORRECTIONNUMBER FROM ODMAST WHERE ORDERID='" & v_strCancelOrderID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    If v_dblCorrecionNumber <= v_ds.Tables(0).Rows(0)("CORRECTIONNUMBER") Then
                        v_lngErrCode = ERR_OD_ORDER_OVER_NUMBER_CORRECTION
                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                     & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                     & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                        Return v_lngErrCode
                    End If
                Else
                    'KHONG TON TAI LENH 
                    v_lngErrCode = ERR_OD_ORDER_NOT_FOUND
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If

                'Kiem tra xem so luong yeu cau huy co phu hop khong
                v_strSQL = "SELECT ORDERQTTY-ADJUSTQTTY-CANCELQTTY-EXECQTTY " & ControlChars.CrLf _
                    & "FROM ODMAST WHERE ORDERID='" & v_strCancelOrderID & "'" & ControlChars.CrLf _
                    & "AND ADJUSTQTTY=0 AND CANCELQTTY=0 OR REMAINQTTY>=" & v_dblORDERQTTY
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

                If Not v_ds.Tables(0).Rows.Count > 0 Then
                    'So luong huy khong hop le: Lenh da bi HUY, SUA hoac So luong yeu cau huy lon hon so luong con lai
                    v_lngErrCode = ERR_OD_INVALID_CANCELQTTY
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If

                'Xac dinh gia
                Dim v_dblTradeUnit As Double
                v_strSQL = "SELECT TRADEUNIT FROM SECURITIES_INFO WHERE TRIM(CODEID)='" & v_strCODEID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_dblTradeUnit = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("TRADEUNIT"))
                    v_dblQUOTEPRICE = v_dblQUOTEPRICE * v_dblTradeUnit
                    v_dblLIMITPRICE = v_dblLIMITPRICE * v_dblTradeUnit
                End If

                'Tao lenh huy
                'Neu la lenh mua thi BORS = "D", ban BORS = "E"
                Dim v_strBORS As String = "D"
                Dim v_strOODStatus As String = "S"
                Dim v_strEDSTATUS As String = "N"
                Dim v_strWASEDSTATUS As String = "N"
                v_strOODStatus = "N"
                Select Case v_strTLTXCD
                    Case gc_OD_CANCELBUYORDER
                        v_strBORS = "D"
                        v_strEDSTATUS = "C"
                        v_strWASEDSTATUS = "W"
                    Case gc_OD_AMENDMENTBUYORDER
                        v_strBORS = "D"
                        v_strEDSTATUS = "A"
                        v_strWASEDSTATUS = "S"
                    Case gc_OD_CANCELSELLORDER
                        v_strBORS = "E"
                        v_strEDSTATUS = "C"
                        v_strWASEDSTATUS = "W"
                    Case gc_OD_AMENDMENTSELLORDER
                        v_strBORS = "E"
                        v_strEDSTATUS = "A"
                        v_strWASEDSTATUS = "S"
                End Select

                ''Ghi nhan vao so lenh day di
                v_strSEACCTNO = v_strAFACCTNO & v_strCODEID
                v_strCIACCTNO = v_strAFACCTNO
                v_strSecuredAmt = v_dblQUOTEPRICE * v_dblORDERQTTY * v_dblBRATIO / 100
                'Ghi nhan vao so lenh ODMAST voi trang thai la send
                v_strSQL = "INSERT INTO ODMAST (ORDERID,CUSTID,ACTYPE,CODEID,AFACCTNO,SEACCTNO,CIACCTNO," & ControlChars.CrLf _
                                        & "TXNUM,TXDATE,TXTIME,EXPDATE,BRATIO,TIMETYPE," & ControlChars.CrLf _
                                        & "EXECTYPE,NORK,MATCHTYPE,VIA,CLEARDAY,CLEARCD,ORSTATUS,PORSTATUS,PRICETYPE," & ControlChars.CrLf _
                                        & "QUOTEPRICE,STOPPRICE,LIMITPRICE,ORDERQTTY,REMAINQTTY,EXPRICE,EXQTTY,SECUREDAMT," & ControlChars.CrLf _
                                        & "EXECQTTY,STANDQTTY,CANCELQTTY,ADJUSTQTTY,REJECTQTTY,REJECTCD,VOUCHER,CONSULTANT,REFORDERID,EDSTATUS)" & ControlChars.CrLf _
                        & "VALUES ('" & v_strORDERID & "','" & v_strCUSTID & "','" & v_strACTYPE & "','" & v_strCODEID & "','" & v_strAFACCTNO & "','" & v_strSEACCTNO & "','" & v_strCIACCTNO & "'" & ControlChars.CrLf _
                                        & ",'" & v_strTXNUM & "',TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'" & v_strTXTIME & "'" & ControlChars.CrLf _
                                        & ",TO_DATE('" & v_strEXPDATE & "', '" & gc_FORMAT_DATE & "')," & v_dblBRATIO & ",'" & v_strTIMETYPE & "'" & ControlChars.CrLf _
                                        & ",'" & v_strEXECTYPE & "','" & v_strNORK & "','" & v_strMATCHTYPE & "','" & v_strVIA & "'" & ControlChars.CrLf _
                                        & "," & v_dblCLEARDAY & ",'" & v_strCLEARCD & "','7','7','" & v_strPRICETYPE & "'" & ControlChars.CrLf _
                                        & "," & v_dblQUOTEPRICE & ",0," & v_dblLIMITPRICE & "," & v_dblORDERQTTY & "," & v_dblORDERQTTY & "," & v_dblQUOTEPRICE & "," & v_dblORDERQTTY & ",0,0,0,0,0,0,'001','" & v_strVOUCHER & "','" & v_strCONSULTANT & "','" & v_strCancelOrderID & "','" & v_strEDSTATUS & "')"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                'Neu la lenh sua chua Send thi sinh them lenh moi vao trong he thong voi trang thai la send
                'Ghi nhan vao so lenh day di
                v_strSQL = "INSERT INTO OOD (ORGORDERID,CODEID,SYMBOL,CUSTODYCD," & ControlChars.CrLf _
                                        & "BORS,NORP,AORN,PRICE,QTTY,SECUREDRATIO,OODSTATUS,TXDATE,TXNUM,DELTD,BRID,reforderid)" & ControlChars.CrLf _
                        & "VALUES ('" & v_strORDERID & "','" & v_strCODEID & "','" & v_strSymbol & "','" & v_strCUSTODYCD.Replace(".", String.Empty) & "','" & v_strBORS & "','" & v_strMATCHTYPE & "'" & ControlChars.CrLf _
                                        & ",'" & v_strNORK & "'," & v_dblQUOTEPRICE & "," & v_dblORDERQTTY & "," & v_dblBRATIO & ",'" & v_strOODStatus & "',TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'" & v_strTXNUM & "','N','" & v_strBRID & "','" & v_strCancelOrderID & "')"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                'Ghi nhan vao ODCHANING de ngan khong cho lenh HUY/SUA khac nhap vao
                Try
                    v_strSQL = "INSERT INTO ODCHANGING (ORGORDERID, ORDERID) VALUES ('" & v_strCancelOrderID & "','" & v_strORDERID & "')"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                Catch ex As Exception
                    v_lngErrCode = ERR_OOD_STATUS_INVALID
                    LogError.WriteException(ex)
                Finally

                End Try
                If v_lngErrCode <> ERR_SYSTEM_OK Then
                    Return v_lngErrCode
                End If

                'If v_strTLTXCD = gc_OD_AMENDMENTBUYORDER Then
                '    'Tang ky quy voi lenh MUA can ky quy then
                '    v_strSQL = "UPDATE ODMAST SET SECUREDAMT=SECUREDAMT + " & v_dblAdvanceAmount & " WHERE ORDERID='" & v_strCancelOrderID & "'"
                '    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                'End If

                If v_strCUROODSTATUS = "N" Then
                    'Tao ban ghi trong ODQUEUE de ngan khong cho day len san: E-Huy, Sua ban, D-Huy,Sua mua
                    v_strSQL = " Update OOD SET OODSTATUS = '" & v_strBORS & "' " & ControlChars.CrLf _
                        & "WHERE ORGORDERID='" & v_strCancelOrderID & "'" & ControlChars.CrLf _
                        & "AND OODSTATUS = 'N'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    'Tao ban ghi trong ODQUEUE, ODQUEUE.OODSTATUS=v_strBORS
                    'v_strSQL = "INSERT INTO ODQUEUE SELECT * FROM OOD WHERE ORGORDERID = '" & v_strCancelOrderID & "'"
                    'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    If v_strTLTXCD = gc_OD_CANCELBUYORDER Or v_strTLTXCD = gc_OD_CANCELSELLORDER Then
                        'Lenh huy se complete luon: TRANG THAI OOD CUA LENH HUY se la (E-Huy ban, D-Huy mua) luon
                        v_strSQL = "UPDATE OOD SET OODSTATUS = '" & v_strBORS & "' " & ControlChars.CrLf _
                            & "WHERE ORGORDERID='" & v_strORDERID & "'"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    End If
                    'Giai toa ky quy lenh goc luon: Khong thuc hien o day ma se su dung STPServer de xu ly
                    'Note: Viec luan chuyen tien tu BALANCE-->BAMT va chung khoan tu TRADE-->SECURED khong kem theo hach toan ke toan
                    '       nen co the lam nhu the nay. Nhuwng giao dich co kem theo hach toan ke toan neu lam thi phan them hach toan ke toan kem theo
                    '       khi do khong nen lam theo cach nay
                    If String.Compare(v_strTLTXCD, gc_OD_CANCELBUYORDER) = 0 Then
                        'v_strSQL = "SELECT SECUREDAMT FROM ODMAST WHERE ORDERID='" & v_strCancelOrderID & "'"
                        'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                        'If v_ds.Tables(0).Rows.Count > 0 Then
                        '    v_dblActualSecured = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("SECUREDAMT"))
                        'End If
                        '1.Cap nhat trong odmast
                        'v_strSQL = "UPDATE ODMAST SET RLSSECURED=SECUREDAMT, REMAINQTTY=0, CANCELQTTY=ORDERQTTY, EDSTATUS='" & v_strWASEDSTATUS & "' WHERE ORDERID='" & v_strCancelOrderID & "'"

                        'TungNT added - tao yeu cau giai toa doi voi truong hop corebank
                        If v_strCOREBANK = "Y" Then
                            Dim v_objParam As StoreParameter
                            Dim v_arrParam(2) As StoreParameter

                            v_objParam = New StoreParameter
                            v_objParam.ParamName = "pv_strORDERID"
                            v_objParam.ParamValue = v_strCancelOrderID
                            v_objParam.ParamSize = 30
                            v_objParam.ParamType = "VARCHAR2"
                            v_objParam.ParamDirection = ParameterDirection.Input
                            v_arrParam(0) = v_objParam

                            v_objParam = New StoreParameter
                            v_objParam.ParamName = "pv_dblCancelQtty"
                            v_objParam.ParamValue = v_dblORDERQTTY
                            v_objParam.ParamSize = 30
                            v_objParam.ParamType = "VARCHAR2"
                            v_objParam.ParamDirection = ParameterDirection.Input
                            v_arrParam(1) = v_objParam

                            v_objParam = New StoreParameter
                            v_objParam.ParamName = "pv_strErrorCode"
                            v_objParam.ParamValue = 0
                            v_objParam.ParamSize = 30
                            v_objParam.ParamType = "VARCHAR2"
                            v_objParam.ParamDirection = ParameterDirection.InputOutput
                            v_arrParam(2) = v_objParam

                            v_obj.ExecuteStoredNonQuerry("cspks_odproc.pr_RM_UnholdCancelOD", v_arrParam)
                            v_lngErrCode = CLng(v_arrParam(2).ParamValue)
                            If v_lngErrCode <> ERR_SYSTEM_OK Then
                                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode & "!" & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                                Return v_lngErrCode
                            End If
                        End If
                        'End

                        v_strSQL = "UPDATE ODMAST SET REMAINQTTY=0, CANCELQTTY=ORDERQTTY, EDSTATUS='" & v_strWASEDSTATUS & "' WHERE ORDERID='" & v_strCancelOrderID & "'"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                        ''2.Cap nhat citran,setran
                        'v_strSQL = "INSERT INTO CITRAN (ACCTNO, TXNUM, TXDATE, TXCD, NAMT, CAMT, REF, DELTD,AUTOID) VALUES ('" _
                        '            & v_strCIACCTNO & "','" & v_strTXNUM & "',TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'0012'," & v_dblActualSecured & ",'','','N',SEQ_CITRAN.NEXTVAL)"
                        'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                        'v_strSQL = "INSERT INTO CITRAN (ACCTNO, TXNUM, TXDATE, TXCD, NAMT, CAMT, REF, DELTD,AUTOID) VALUES ('" _
                        '            & v_strCIACCTNO & "','" & v_strTXNUM & "',TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'0017'," & v_dblActualSecured & ",'','','N',SEQ_CITRAN.NEXTVAL)"
                        'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                        ''3.giai toa CI,SE
                        'v_strSQL = "UPDATE CIMAST SET BALANCE=BALANCE + " & v_dblActualSecured & ", BAMT=BAMT- " & v_dblActualSecured & " WHERE ACCTNO='" & v_strCIACCTNO & "'"
                        'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                        If v_strTIMETYPE = "G" Then
                            '4.Neu lenh GTC thi huy luon lenh yeu cau
                            'v_strSQL = "UPDATE FOMAST SET DELTD='Y',REFACCTNO='" & v_strORDERID & "' WHERE ORGACCTNO='" & v_strCancelOrderID & "'"
                            v_strSQL = "UPDATE FOMAST SET REMAINQTTY=REMAINQTTY - " & v_dblORDERQTTY & " ,CANCELQTTY=CANCELQTTY + " & v_dblORDERQTTY & " , REFACCTNO='" & v_strORDERID & "' WHERE ACCTNO = (SELECT FOACCTNO FROM ODMAST WHERE ORDERID='" & v_strCancelOrderID & "')"
                            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                        End If

                    ElseIf String.Compare(v_strTLTXCD, gc_OD_CANCELSELLORDER) = 0 Then
                        '1.Cap nhat trong odmast
                        v_strSQL = "UPDATE ODMAST SET REMAINQTTY=0, CANCELQTTY=ORDERQTTY, EDSTATUS='" & v_strWASEDSTATUS & "' WHERE ORDERID='" & v_strCancelOrderID & "'"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                        'If v_dblIsMortage = 1 Then
                        '    '2.Cap nhat citran,setran
                        '    v_strSQL = "INSERT INTO SETRAN (ACCTNO, TXNUM, TXDATE, TXCD, NAMT, CAMT, REF, DELTD,AUTOID) VALUES ('" _
                        '                & v_strSEACCTNO & "','" & v_strTXNUM & "',TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'0065'," & v_dblORDERQTTY & ",'','','N',SEQ_SETRAN.NEXTVAL)"
                        '    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                        '    v_strSQL = "INSERT INTO SETRAN (ACCTNO, TXNUM, TXDATE, TXCD, NAMT, CAMT, REF, DELTD,AUTOID) VALUES ('" _
                        '                & v_strSEACCTNO & "','" & v_strTXNUM & "',TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'0018'," & v_dblORDERQTTY & ",'','','N',SEQ_SETRAN.NEXTVAL)"
                        '    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                        '    '3.giai toa CI,SE
                        '    v_strSQL = "UPDATE SEMAST SET MORTAGE=MORTAGE + " & v_dblORDERQTTY & ", SECURED=SECURED- " & v_dblORDERQTTY & " WHERE ACCTNO='" & v_strSEACCTNO & "'"
                        '    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                        'Else
                        '    '2.Cap nhat citran,setran
                        '    v_strSQL = "INSERT INTO SETRAN (ACCTNO, TXNUM, TXDATE, TXCD, NAMT, CAMT, REF, DELTD,AUTOID) VALUES ('" _
                        '                & v_strSEACCTNO & "','" & v_strTXNUM & "',TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'0012'," & v_dblORDERQTTY & ",'','','N',SEQ_SETRAN.NEXTVAL)"
                        '    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                        '    v_strSQL = "INSERT INTO SETRAN (ACCTNO, TXNUM, TXDATE, TXCD, NAMT, CAMT, REF, DELTD,AUTOID) VALUES ('" _
                        '                & v_strSEACCTNO & "','" & v_strTXNUM & "',TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'0018'," & v_dblORDERQTTY & ",'','','N',SEQ_SETRAN.NEXTVAL)"
                        '    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                        '    '3.giai toa CI,SE
                        '    v_strSQL = "UPDATE SEMAST SET TRADE=TRADE + " & v_dblORDERQTTY & ", SECURED=SECURED- " & v_dblORDERQTTY & " WHERE ACCTNO='" & v_strSEACCTNO & "'"
                        '    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                        'End If
                        If v_strTIMETYPE = "G" Then
                            '4.Neu lenh GTC thi huy luon lenh yeu cau
                            'v_strSQL = "UPDATE FOMAST SET DELTD='Y',REFACCTNO='" & v_strORDERID & "' WHERE ORGACCTNO='" & v_strCancelOrderID & "'"
                            v_strSQL = "UPDATE FOMAST SET REMAINQTTY=REMAINQTTY - " & v_dblORDERQTTY & " ,CANCELQTTY=CANCELQTTY + " & v_dblORDERQTTY & " , REFACCTNO='" & v_strORDERID & "' WHERE ACCTNO = (SELECT FOACCTNO FROM ODMAST WHERE ORDERID='" & v_strCancelOrderID & "')"
                            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                        End If
                    End If

                End If
            Else
                'TungNT added - Neu tk corebank thi khong duoc phep xoa
                If v_strCOREBANK = "Y" Then
                    v_lngErrCode = ERR_OD_CANNOT_DELETE
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If
                'End

                'Xoa lenh day di
                v_strSQL = "UPDATE OOD SET DELTD='Y' WHERE TXNUM='" & v_strTXNUM & "' AND TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                'Xoa  ODCHANGING
                v_strSQL = "DELETE FROM ODCHANGING WHERE ORGORDERID='" & v_strCancelOrderID & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                'Neu truoc day da Block lenh goc khong cho day thi phai Unblock
                v_strSQL = "UPDATE OOD SET OODSTATUS = 'N' " & ControlChars.CrLf _
                    & "WHERE ORGORDERID='" & v_strCancelOrderID & "'" & ControlChars.CrLf _
                    & "AND (OODSTATUS = 'E' OR OODSTATUS = 'D')"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                'Xoa trong ODQUEUE, ODQUEUE.OODSTATUS=v_strBORS
                v_strSQL = "DELETE FROM ODQUEUE " & ControlChars.CrLf _
                    & "WHERE ORGORDERID='" & v_strCancelOrderID & "'" & ControlChars.CrLf _
                    & "AND (OODSTATUS = 'E' OR OODSTATUS = 'D')"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                'If v_strTLTXCD = gc_OD_AMENDMENTBUYORDER Then
                '    'GIAM ky quy voi lenh MUA can ky quy then
                '    v_strSQL = "UPDATE ODMAST SET SECUREDAMT=SECUREDAMT - " & v_dblAdvanceAmount & " WHERE ORDERID='" & v_strCancelOrderID & "'"
                '    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                'End If
                If v_strTIMETYPE = "G" Then
                    '4.Neu lenh GTC thi huy luon lenh yeu cau
                    v_strSQL = "UPDATE FOMAST SET DELTD='N',REFACCTNO='' WHERE ORGACCTNO='" & v_strCancelOrderID & "'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                End If
            End If

            'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            ''ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function AmendElectricOrder(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "OD.Trans.CancelOrder", v_strErrorMessage As String

        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, v_strSQL As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE As Double
            Dim v_strCUSTID, v_strCODEID, v_strACTYPE, v_strAFACCTNO, v_strCIACCTNO, v_strAFSTATUS, v_strSEACCTNO, v_strCUSTODYCD, v_strLIMITPRICE, v_strTIMETYPE,
                v_strVOUCHER, v_strCONSULTANT, v_strORDERID, v_strCUROODSTATUS,
                v_strEXPDATE, v_strNORK, v_strMATCHTYPE, v_strVIA,
                v_strCLEARCD, v_strPRICETYPE, v_strCLEARDAY, v_strSymbol, v_strDESC, v_strCancelOrderID As String
            Dim v_strPUTTYPE, v_strCONTRAORDERID, v_strCONTRAFRM As String
            Dim v_strREFORDERID, v_strTempOrderID, v_strQUOTEPRICE, v_strORDERQTTY, v_strBRATIO, v_strCANCELQTTY, v_strAMENDQTTY, v_strAMENDPRICE, v_strTRADEUNIT, v_strHUNDRED, v_strEXECTYPE As String
            Dim v_dblNumberCorrection As Double
            Dim v_ds, v_ds1, v_dsext As DataSet
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)


            Dim v_strBRID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value
            Dim v_strTLTXCD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXTIME As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTIME).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_blnREVERSAL As Boolean = IIf(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value = "Y", True, False)
            Dim v_strTellerID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTLID).Value
            Dim v_strIPADDRESS As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeIPADDRESS).Value

            'Doc noi dung giao dich
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    v_strVALUE = Trim(.InnerText)
                    Select Case v_strFLDCD
                        Case "01" 'CODEID
                            v_strSymbol = v_strVALUE
                        Case "03" 'AFACCTNO
                            v_strAFACCTNO = v_strVALUE
                        Case "04" 'ORDERID
                            v_strORDERID = v_strVALUE
                        Case "06" 'SEACCTNO
                            v_strSEACCTNO = v_strVALUE
                        Case "07" 'SYMBOL
                            v_strSymbol = v_strVALUE
                        Case "08" 'REFORDERID                                       
                            v_strREFORDERID = v_strVALUE
                        Case "11" 'QUOTEPRICE
                            v_strQUOTEPRICE = v_strVALUE
                        Case "12" 'ORDERQTTY
                            v_strORDERQTTY = v_strVALUE
                        Case "13" 'BRATIO
                            v_strBRATIO = v_strVALUE
                        Case "20" 'OLDBRATIO
                        Case "14" 'CANCELQTTY
                            v_strCANCELQTTY = v_strVALUE
                        Case "15" 'AMENDQTTY
                            v_strAMENDQTTY = v_strVALUE
                        Case "16" 'AMENDPRICE
                            v_strAMENDPRICE = v_strVALUE
                        Case "22" 'EXECTYPE                                      
                            v_strEXECTYPE = v_strVALUE
                        Case "98" 'TRADEUNIT
                            v_strTRADEUNIT = v_strVALUE
                        Case "99" 'HUNDRED
                            v_strHUNDRED = v_strVALUE
                        Case "30" 'DESC                                              
                            v_strDESC = v_strVALUE
                    End Select
                End With
            Next
            Dim v_strBORS As String = "D"
            Dim v_strOODStatus As String = "S"
            Dim v_strEDSTATUS As String = "N"

            v_strCODEID = Strings.Right(v_strSEACCTNO, 6)
            v_strCIACCTNO = v_strAFACCTNO
            v_strSQL = "SELECT ODMAST.*,OOD.CUSTODYCD,OOD.BORS FROM ODMAST,OOD WHERE ODMAST.ORDERID=OOD.ORGORDERID AND ORDERID='" & v_strREFORDERID & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_dblNumberCorrection = v_ds.Tables(0).Rows(0)("CORRECTIONNUMBER") + 1
                v_strEXECTYPE = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("EXECTYPE"))
                v_strCUSTID = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("CUSTID"))
                v_strACTYPE = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("ACTYPE"))
                v_strTIMETYPE = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("TIMETYPE"))
                v_strNORK = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("NORK"))
                v_strMATCHTYPE = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("MATCHTYPE"))
                v_strVIA = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("VIA"))
                v_strCLEARDAY = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("CLEARDAY"))
                v_strCLEARCD = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("CLEARCD"))
                v_strPRICETYPE = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("PRICETYPE"))
                v_strCUSTODYCD = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("CUSTODYCD"))
                v_strLIMITPRICE = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("LIMITPRICE"))
                v_strVOUCHER = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("VOUCHER"))
                v_strCONSULTANT = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("CONSULTANT"))
                v_strBORS = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("BORS"))
                v_strPUTTYPE = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("PUTTYPE"))
                v_strCONTRAORDERID = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("CONTRAORDERID"))
                v_strCONTRAFRM = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("CONTRAFRM"))
            End If

            If Not v_blnREVERSAL Then
                'Xac dinh gia
                Dim v_dblTradeUnit As Double
                v_dblTradeUnit = CDbl(v_strTRADEUNIT)
                v_strQUOTEPRICE = CInt(CDbl(v_strQUOTEPRICE) * CDbl(v_strTRADEUNIT)).ToString
                v_strAMENDPRICE = CInt(CDbl(v_strAMENDPRICE) * CDbl(v_strTRADEUNIT)).ToString
                v_strOODStatus = "S"

                'Neu la lenh sua thi sinh them lenh sua vao trong he thong 
                If CDbl(v_strAMENDQTTY) > 0 Then
                    v_strEDSTATUS = "S"
                Else
                    v_strEDSTATUS = "W"
                End If
                'Cap nhat trang thai
                v_strSQL = "UPDATE ODMAST SET EDSTATUS='" & v_strEDSTATUS & "',ORSTATUS='2' WHERE ORDERID='" & v_strREFORDERID & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                v_strSQL = "UPDATE OOD SET OODSTATUS='" & v_strOODStatus & "' WHERE ORGORDERID='" & v_strREFORDERID & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                Dim v_strAutoID As String
                'Tao 1 lenh send voi khoi luong la so luong sua
                If CDbl(v_strAMENDQTTY) > 0 Then
                    'Lay so hieu lenh moi
                    v_strSQL = "SELECT SEQ_ODMAST.NEXTVAL AUTOINV FROM DUAL"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count = 0 Then
                        v_strAutoID = "1"
                    Else
                        v_strAutoID = CStr(v_ds.Tables(0).Rows(0)("AUTOINV"))
                    End If
                    v_strORDERID = v_strBRID & Mid(Replace(v_strTXDATE, "/", vbNullString), 1, 4) & Mid(Replace(v_strTXDATE, "/", vbNullString), 7, 2) & Strings.Right(gc_FORMAT_ODAUTOId & CStr(v_strAutoID), Len(gc_FORMAT_ODAUTOId))

                    v_strSQL = "INSERT INTO ODMAST (ORDERID,CUSTID,ACTYPE,CODEID,AFACCTNO,SEACCTNO,CIACCTNO," & ControlChars.CrLf _
                                        & "TXNUM,TXDATE,TXTIME,EXPDATE,BRATIO,TIMETYPE," & ControlChars.CrLf _
                                        & "EXECTYPE,NORK,MATCHTYPE,VIA,CLEARDAY,CLEARCD,ORSTATUS,PORSTATUS,PRICETYPE," & ControlChars.CrLf _
                                        & "QUOTEPRICE,STOPPRICE,LIMITPRICE,ORDERQTTY,REMAINQTTY,EXPRICE,EXQTTY,SECUREDAMT," & ControlChars.CrLf _
                                        & "EXECQTTY,STANDQTTY,CANCELQTTY,ADJUSTQTTY,REJECTQTTY,REJECTCD,VOUCHER,CONSULTANT,REFORDERID,CORRECTIONNUMBER,CONTRAORDERID,PUTTYPE,CONTRAFRM)" & ControlChars.CrLf _
                        & "VALUES ('" & v_strORDERID & "','" & v_strCUSTID & "','" & v_strACTYPE & "','" & v_strCODEID & "','" & v_strAFACCTNO & "','" & v_strSEACCTNO & "','" & v_strCIACCTNO & "'" & ControlChars.CrLf _
                                        & ",'" & v_strTXNUM & "',TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'" & v_strTXTIME & "'" & ControlChars.CrLf _
                                        & ",TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')," & CDbl(v_strBRATIO) & ",'" & v_strTIMETYPE & "'" & ControlChars.CrLf _
                                        & ",'" & v_strEXECTYPE & "','" & v_strNORK & "','" & v_strMATCHTYPE & "','" & v_strVIA & "'" & ControlChars.CrLf _
                                        & "," & v_strCLEARDAY & ",'" & v_strCLEARCD & "','2','8','" & v_strPRICETYPE & "'" & ControlChars.CrLf _
                                        & "," & CDbl(v_strAMENDPRICE) & ",0," & CDbl(v_strLIMITPRICE) & "," & CDbl(v_strAMENDQTTY) & "," & CDbl(v_strAMENDQTTY) & "," & CDbl(v_strAMENDPRICE) & "," & CDbl(v_strAMENDQTTY) & ",0,0,0,0,0,0,'001','" & v_strVOUCHER & "','" & v_strCONSULTANT & "','" & v_strREFORDERID & "'," & v_dblNumberCorrection & ",'" & v_strCONTRAORDERID & " ','" & v_strPUTTYPE & "','" & v_strCONTRAFRM & "')"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                    'Ghi nhan vao so lenh day di
                    v_strSQL = "INSERT INTO OOD (ORGORDERID,CODEID,SYMBOL,CUSTODYCD," & ControlChars.CrLf _
                                            & "BORS,NORP,AORN,PRICE,QTTY,SECUREDRATIO,OODSTATUS,TXDATE,TXTIME,TXNUM,DELTD,BRID,REFORDERID,TLIDSENT,IPADDRESS)" & ControlChars.CrLf _
                            & "VALUES ('" & v_strORDERID & "','" & v_strCODEID & "','" & v_strSymbol & "','" & v_strCUSTODYCD.Replace(".", String.Empty) & "','" & v_strBORS & "','" & v_strMATCHTYPE & "'" & ControlChars.CrLf _
                                            & ",'" & v_strNORK & "'," & CDbl(v_strAMENDPRICE) & "," & CDbl(v_strAMENDQTTY) & "," & CDbl(v_strBRATIO) & ",'" & v_strOODStatus & "',TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'" & v_strTXTIME & "','" & v_strTXNUM & "','N','" & v_strBRID & "','" & v_strREFORDERID & "','" & v_strTellerID & "','" & v_strIPADDRESS & "')"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)



                    'Tao ban ghi trong ODQUEUE,ODQUEUELOG xac nhan lenh da day len san
                    v_strSQL = "INSERT INTO ODQUEUE SELECT * FROM OOD WHERE ORGORDERID = '" & v_strORDERID & "'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                    v_strSQL = "INSERT INTO ODQUEUELOG SELECT * FROM OOD WHERE ORGORDERID = '" & v_strORDERID & "'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                End If
                'Tao 1 lenh chua send voi khoi luong la so luong goc tru di so luong sua
                If CDbl(v_strORDERQTTY) - CDbl(v_strAMENDQTTY) > 0 Then
                    'Lay so hieu lenh moi
                    v_strSQL = "SELECT SEQ_ODMAST.NEXTVAL AUTOINV FROM DUAL"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count = 0 Then
                        v_strAutoID = "1"
                    Else
                        v_strAutoID = CStr(v_ds.Tables(0).Rows(0)("AUTOINV"))
                    End If
                    v_strORDERID = v_strBRID & Mid(Replace(v_strTXDATE, "/", vbNullString), 1, 4) & Mid(Replace(v_strTXDATE, "/", vbNullString), 7, 2) & Strings.Right(gc_FORMAT_ODAUTOId & CStr(v_strAutoID), Len(gc_FORMAT_ODAUTOId))

                    v_strAMENDQTTY = CStr(CDbl(v_strORDERQTTY) - CDbl(v_strAMENDQTTY))
                    v_strOODStatus = "N"
                    v_strSQL = "INSERT INTO ODMAST (ORDERID,CUSTID,ACTYPE,CODEID,AFACCTNO,SEACCTNO,CIACCTNO," & ControlChars.CrLf _
                                        & "TXNUM,TXDATE,TXTIME,EXPDATE,BRATIO,TIMETYPE," & ControlChars.CrLf _
                                        & "EXECTYPE,NORK,MATCHTYPE,VIA,CLEARDAY,CLEARCD,ORSTATUS,PORSTATUS,PRICETYPE," & ControlChars.CrLf _
                                        & "QUOTEPRICE,STOPPRICE,LIMITPRICE,ORDERQTTY,REMAINQTTY,EXPRICE,EXQTTY,SECUREDAMT," & ControlChars.CrLf _
                                        & "EXECQTTY,STANDQTTY,CANCELQTTY,ADJUSTQTTY,REJECTQTTY,REJECTCD,VOUCHER,CONSULTANT,REFORDERID,CORRECTIONNUMBER,CONTRAORDERID,PUTTYPE,CONTRAFRM)" & ControlChars.CrLf _
                        & "VALUES ('" & v_strORDERID & "','" & v_strCUSTID & "','" & v_strACTYPE & "','" & v_strCODEID & "','" & v_strAFACCTNO & "','" & v_strSEACCTNO & "','" & v_strCIACCTNO & "'" & ControlChars.CrLf _
                                        & ",'" & v_strTXNUM & "',TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'" & v_strTXTIME & "'" & ControlChars.CrLf _
                                        & ",TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')," & CDbl(v_strBRATIO) & ",'" & v_strTIMETYPE & "'" & ControlChars.CrLf _
                                        & ",'" & v_strEXECTYPE & "','" & v_strNORK & "','" & v_strMATCHTYPE & "','" & v_strVIA & "'" & ControlChars.CrLf _
                                        & "," & v_strCLEARDAY & ",'" & v_strCLEARCD & "','8','9','" & v_strPRICETYPE & "'" & ControlChars.CrLf _
                                        & "," & CDbl(v_strAMENDPRICE) & ",0," & CDbl(v_strLIMITPRICE) & "," & CDbl(v_strAMENDQTTY) & "," & CDbl(v_strAMENDQTTY) & "," & CDbl(v_strAMENDPRICE) & "," & CDbl(v_strAMENDQTTY) & ",0,0,0,0,0,0,'001','" & v_strVOUCHER & "','" & v_strCONSULTANT & "','" & v_strREFORDERID & "'," & v_dblNumberCorrection & ",'" & v_strCONTRAORDERID & " ','" & v_strPUTTYPE & "','" & v_strCONTRAFRM & "')"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                    'Ghi nhan vao so lenh day di
                    v_strSQL = "INSERT INTO OOD (ORGORDERID,CODEID,SYMBOL,CUSTODYCD," & ControlChars.CrLf _
                                            & "BORS,NORP,AORN,PRICE,QTTY,SECUREDRATIO,OODSTATUS,TXDATE,TXTIME,TXNUM,DELTD,BRID,REFORDERID)" & ControlChars.CrLf _
                            & "VALUES ('" & v_strORDERID & "','" & v_strCODEID & "','" & v_strSymbol & "','" & v_strCUSTODYCD.Replace(".", String.Empty) & "','" & v_strBORS & "','" & v_strMATCHTYPE & "'" & ControlChars.CrLf _
                                            & ",'" & v_strNORK & "'," & CDbl(v_strAMENDPRICE) & "," & CDbl(v_strAMENDQTTY) & "," & CDbl(v_strBRATIO) & ",'" & v_strOODStatus & "',TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'" & v_strTXTIME & "','" & v_strTXNUM & "','N','" & v_strBRID & "','" & v_strREFORDERID & "')"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                End If
            Else
                If CDbl(v_strAMENDQTTY) > 0 Then
                    'Xoa trong OOD
                    v_strSQL = "UPDATE OOD SET DELTD='Y' WHERE TXNUM='" & v_strTXNUM & "' AND TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    'Xoa trong ODMAST
                    v_strSQL = "UPDATE ODMAST SET DELTD='Y' WHERE TXNUM='" & v_strTXNUM & "' AND TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    'Xoa trong ODQUEUE
                    v_strSQL = "UPDATE ODQUEUE SET DELTD='Y' WHERE TXNUM='" & v_strTXNUM & "' AND TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    v_strSQL = "UPDATE ODQUEUELOG SET DELTD='Y' WHERE TXNUM='" & v_strTXNUM & "' AND TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                    v_strSQL = "UPDATE ODCANCEL SET DELTD='Y' WHERE TXNUM='" & v_strTXNUM & "' AND TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                End If
            End If

            'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            ''ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function ApproveCancelOrder(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "OD.Trans.CancelOrder", v_strErrorMessage As String

        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, v_strSQL As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE As Double
            Dim v_strCUSTID, v_strCODEID, v_strACTYPE, v_strAFACCTNO, v_strCIACCTNO, v_strAFSTATUS, v_strSEACCTNO, v_strCUSTODYCD, v_strLIMITPRICE, v_strTIMETYPE,
                v_strVOUCHER, v_strCONSULTANT, v_strORDERID, v_strCUROODSTATUS,
                v_strEXPDATE, v_strNORK, v_strMATCHTYPE, v_strVIA, v_strTLID,
                v_strCLEARCD, v_strPRICETYPE, v_strCLEARDAY, v_strSymbol, v_strDESC, v_strCancelOrderID As String
            Dim v_strREFORDERID, v_strTempOrderID, v_strQUOTEPRICE, v_strORDERQTTY,
            v_strBRATIO, v_strCANCELQTTY, v_strAMENDQTTY, v_strAMENDPRICE, v_strTRADEUNIT,
            v_strHUNDRED, v_strEXECTYPE, v_strCOREBANK, v_strALTERNATEACCT, v_strDFACCTNO, v_strMATCHEDQTTY As String

            Dim v_strISDISPOSAL As String

            Dim v_dblNumberCorrection As Double
            Dim v_ds, v_ds1, v_dsext As DataSet
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)

            Dim v_strBRID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value
            Dim v_strTLTXCD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXTIME As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTIME).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_blnREVERSAL As Boolean = IIf(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value = "Y", True, False)
            Dim v_strTellerID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTLID).Value
            Dim v_strIPADDRESS As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeIPADDRESS).Value

            'Doc noi dung giao dich
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    v_strVALUE = Trim(.InnerText)
                    Select Case v_strFLDCD
                        Case "01" 'CODEID
                            v_strSymbol = v_strVALUE
                        Case "03" 'AFACCTNO
                            v_strAFACCTNO = v_strVALUE
                        Case "04" 'ORDERID
                            v_strORDERID = v_strVALUE
                        Case "06" 'SEACCTNO
                            v_strSEACCTNO = v_strVALUE
                        Case "07" 'SYMBOL
                            v_strSymbol = v_strVALUE
                        Case "08" 'REFORDERID                                       
                            v_strREFORDERID = v_strVALUE
                        Case "11" 'QUOTEPRICE
                            v_strQUOTEPRICE = v_strVALUE
                        Case "12" 'ORDERQTTY
                            v_strORDERQTTY = v_strVALUE
                        Case "13" 'BRATIO
                            v_strBRATIO = v_strVALUE
                        Case "20" 'OLDBRATIO
                        Case "14" 'CANCELQTTY
                            v_strCANCELQTTY = v_strVALUE
                        Case "15" 'AMENDQTTY
                            v_strAMENDQTTY = v_strVALUE
                        Case "16" 'AMENDPRICE
                            v_strAMENDPRICE = v_strVALUE
                        Case "17" 'MATCHEDQTTY
                            v_strMATCHEDQTTY = v_strVALUE
                        Case "22" 'EXECTYPE                                      
                            v_strEXECTYPE = v_strVALUE
                        Case "98" 'TRADEUNIT
                            v_strTRADEUNIT = v_strVALUE
                        Case "99" 'HUNDRED
                            v_strHUNDRED = v_strVALUE
                        Case "30" 'DESC                                              
                            v_strDESC = v_strVALUE
                    End Select
                End With
            Next
            v_strCODEID = Strings.Right(v_strSEACCTNO, 6)
            v_strCIACCTNO = v_strAFACCTNO
            v_strSQL = "SELECT ODMAST.CORRECTIONNUMBER, ODMAST.EXECTYPE, ODMAST.DFACCTNO, nvl(ODMAST.ISDISPOSAL,'N') ISDISPOSAL,OOD.CUSTODYCD FROM ODMAST,OOD WHERE ODMAST.ORDERID=OOD.ORGORDERID AND ORDERID='" & v_strREFORDERID & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_dblNumberCorrection = v_ds.Tables(0).Rows(0)("CORRECTIONNUMBER") + 1
                v_strEXECTYPE = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("EXECTYPE"))
                v_strDFACCTNO = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("DFACCTNO"))
                v_strISDISPOSAL = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("ISDISPOSAL"))
            End If
            v_strSQL = "SELECT ODMAST.*,OOD.CUSTODYCD FROM ODMAST,OOD WHERE ODMAST.ORDERID=OOD.ORGORDERID AND ODMAST.REFORDERID='" & v_strREFORDERID & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_strTempOrderID = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("ORDERID"))
            End If
            v_strSQL = "SELECT ODMAST.*,OOD.CUSTODYCD FROM ODMAST,OOD WHERE ODMAST.ORDERID=OOD.ORGORDERID AND ORDERID='" & v_strTempOrderID & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_strCUSTID = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("CUSTID"))
                v_strACTYPE = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("ACTYPE"))
                v_strTIMETYPE = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("TIMETYPE"))
                v_strNORK = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("NORK"))
                v_strMATCHTYPE = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("MATCHTYPE"))
                v_strVIA = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("VIA"))
                v_strCLEARDAY = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("CLEARDAY"))
                v_strCLEARCD = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("CLEARCD"))
                v_strPRICETYPE = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("PRICETYPE"))
                v_strCUSTODYCD = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("CUSTODYCD"))
                v_strLIMITPRICE = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("LIMITPRICE"))
                v_strVOUCHER = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("VOUCHER"))
                v_strCONSULTANT = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("CONSULTANT"))
                'v_dblNumberCorrection = v_ds.Tables(0).Rows(0)("CORRECTIONNUMBER") + 1
                v_strTLID = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("TLID"))
            End If

            If Not v_blnREVERSAL Then
                'Xac dinh gia
                Dim v_dblTradeUnit As Double
                v_strSQL = "SELECT TRADEUNIT FROM SECURITIES_INFO WHERE TRIM(CODEID)='" & v_strCODEID & "'"
                v_ds1 = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds1.Tables(0).Rows.Count > 0 Then
                    v_dblTradeUnit = gf_CorrectNumericField(v_ds1.Tables(0).Rows(0)("TRADEUNIT"))
                    v_strQUOTEPRICE = CInt(CDbl(v_strQUOTEPRICE) * v_dblTradeUnit).ToString
                End If

                'Tao lenh huy
                'Neu la lenh mua thi BORS = "D", ban BORS = "E"
                Dim v_strBORS As String = "D"
                Dim v_strOODStatus As String = "S"
                Dim v_strEDSTATUS As String = "N"
                v_strOODStatus = "S"
                Select Case v_strTLTXCD
                    Case gc_OD_APPROVE_EDITBUYORDER
                        v_strBORS = "B"
                    Case gc_OD_APPROVE_EDITSELLORDER
                        v_strBORS = "S"
                End Select

                'Neu la lenh sua thi sinh them lenh sua vao trong he thong 
                If CDbl(v_strAMENDQTTY) > 0 Then 'Sua
                    v_strEDSTATUS = "S"
                    'Cap nhat trang thai
                    v_strSQL = "UPDATE ODMAST SET EDSTATUS='" & v_strEDSTATUS & "' WHERE ORDERID='" & v_strREFORDERID & "'"
                Else 'Huy
                    v_strEDSTATUS = "W"
                    'Cap nhat trang thai
                    v_strSQL = "UPDATE ODMAST SET EDSTATUS='" & v_strEDSTATUS & "', CANCELSTATUS='C' WHERE ORDERID='" & v_strREFORDERID & "'"
                End If
                ''Cap nhat trang thai
                'v_strSQL = "UPDATE ODMAST SET EDSTATUS='" & v_strEDSTATUS & "', CANCELSTATUS='C' WHERE ORDERID='" & v_strREFORDERID & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                'Cap nhat trang thai cho lenh huy sua thanh da send (Thay cho buoc onsend trong Sending Confirm)
                v_strSQL = "UPDATE OOD SET OODSTATUS = 'S', TXTIME = TO_CHAR(SYSDATE,'HH24:MI:SS'), TLIDSENT = '" & v_strTellerID & "' ,IPADDRESS = '" & v_strIPADDRESS & "' WHERE ORGORDERID = '" & v_strTempOrderID & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                v_strSQL = "UPDATE ODMAST SET ORSTATUS = '2' WHERE ORDERID = '" & v_strTempOrderID & "' AND ORSTATUS = '8'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                If v_strTIMETYPE = "G" Then
                    'lENH YEU CAU GTO SE BI HUY, DO LENH CON TREN SAN DA THAY DOI
                    'v_strSQL = "UPDATE FOMAST SET DELTD='Y' WHERE ORGACCTNO= '" & v_strREFORDERID & "'"
                    v_strSQL = "UPDATE FOMAST SET REMAINQTTY=REMAINQTTY - (" & CDbl(v_strCANCELQTTY) + CDbl(v_strAMENDQTTY) & ") ,CANCELQTTY=CANCELQTTY + " & v_strCANCELQTTY & " ,amendqtty = amendqtty + " & v_strAMENDQTTY & ", REFACCTNO='" & v_strORDERID & "' WHERE ACCTNO = (SELECT FOACCTNO FROM ODMAST WHERE ORDERID='" & v_strREFORDERID & "')"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    'Neu la lenh sua thi tao yeu cau GTC,SL cho lenh sua do
                    Dim v_strFEEDBACKMSG As String = v_strDESC
                    If CDbl(v_strAMENDQTTY) > 0 Then
                        v_strSQL = "INSERT INTO FOMAST (ACCTNO, ORGACCTNO, ACTYPE, AFACCTNO, STATUS, EXECTYPE, PRICETYPE, TIMETYPE, MATCHTYPE, NORK, CLEARCD, CODEID, SYMBOL, " & ControlChars.CrLf _
                                                & "CONFIRMEDVIA, BOOK, FEEDBACKMSG, ACTIVATEDT, CREATEDDT, CLEARDAY, QUANTITY, PRICE, QUOTEPRICE, TRIGGERPRICE, EXECQTTY, EXECAMT, REMAINQTTY,TXDATE,TXNUM,EFFDATE,EXPDATE,BRATIO,VIA,OUTPRICEALLOW)" & ControlChars.CrLf _
                                                & "SELECT '" & v_strORDERID & "','" & v_strORDERID.Trim & "','" & v_strACTYPE.Trim & "','" & v_strAFACCTNO.Trim & "','A'," & ControlChars.CrLf _
                                                & " EXECTYPE,'" & v_strPRICETYPE.Trim & "','" & v_strTIMETYPE.Trim & "','" & v_strMATCHTYPE.Trim & "'," & ControlChars.CrLf _
                                                & "'" & v_strNORK.Trim & "','" & v_strCLEARCD.Trim & "','" & v_strCODEID.Trim & "','" & v_strSymbol.Trim & "'," & ControlChars.CrLf _
                                                & "'N','A','" & v_strFEEDBACKMSG.Trim & "',TO_CHAR(SYSDATE,'DD/MM/RRRR HH:MM:SS'),TO_CHAR(SYSDATE,'DD/MM/RRRR HH:MM:SS')," & ControlChars.CrLf _
                                                & v_strCLEARDAY & "," & v_strAMENDQTTY & "," & v_strLIMITPRICE / v_dblTradeUnit & "," & v_strAMENDPRICE / v_dblTradeUnit & "," & 0 & "," & 0 & "," & 0 & "," & v_strAMENDQTTY & ",TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'" & v_strTXNUM & "',EFFDATE,EXPDATE," & v_strBRATIO & ",'" & v_strVIA & "',OUTPRICEALLOW FROM FOMAST WHERE ORGACCTNO= '" & v_strREFORDERID & "'"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    End If
                End If



                'Cap nhat lai lenh goc
                v_strSQL = "UPDATE ODMAST SET " & ControlChars.CrLf _
                        & "     REMAINQTTY = REMAINQTTY - (to_number('" & v_strORDERQTTY & "') - to_number('" & v_strMATCHEDQTTY & "')), " & ControlChars.CrLf _
                        & "     CANCELQTTY = CANCELQTTY + to_number('" & v_strCANCELQTTY & "'), " & ControlChars.CrLf _
                        & "     ADJUSTQTTY = ADJUSTQTTY + to_number('" & v_strAMENDQTTY & "') " & ControlChars.CrLf _
                        & " WHERE ORDERID='" & v_strREFORDERID & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                'Ghi nhan vao ODTRAN
                v_strSQL = "INSERT INTO odtran (TXNUM,TXDATE,ACCTNO,TXCD,NAMT,CAMT,ACCTREF,DELTD,REF,AUTOID,TLTXCD,BKDATE,TRDESC) " & ControlChars.CrLf _
                        & "VALUES('" & v_strTXNUM & "',TO_DATE('" & v_strTXDATE & "', 'DD/MM/YYYY'),'" & v_strORDERID & "','0011'," & ControlChars.CrLf _
                        & "     to_number('" & v_strORDERQTTY & "') - to_number('" & v_strMATCHEDQTTY & "'),NULL,'" & v_strORDERID & "','N','" & v_strORDERID & "',seq_odtran.NEXTVAL,'" & v_strTLTXCD & "',TO_DATE('" & v_strTXDATE & "', 'DD/MM/YYYY'),NULL)"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                v_strSQL = "INSERT INTO odtran (TXNUM,TXDATE,ACCTNO,TXCD,NAMT,CAMT,ACCTREF,DELTD,REF,AUTOID,TLTXCD,BKDATE,TRDESC) " & ControlChars.CrLf _
                        & "VALUES('" & v_strTXNUM & "',TO_DATE('" & v_strTXDATE & "', 'DD/MM/YYYY'),'" & v_strORDERID & "','0014'," & ControlChars.CrLf _
                        & "     to_number('" & v_strCANCELQTTY & "'),NULL,'" & v_strORDERID & "','N','" & v_strORDERID & "',seq_odtran.NEXTVAL,'" & v_strTLTXCD & "',TO_DATE('" & v_strTXDATE & "', 'DD/MM/YYYY'),NULL)"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                v_strSQL = "INSERT INTO odtran (TXNUM,TXDATE,ACCTNO,TXCD,NAMT,CAMT,ACCTREF,DELTD,REF,AUTOID,TLTXCD,BKDATE,TRDESC) " & ControlChars.CrLf _
                        & "VALUES('" & v_strTXNUM & "',TO_DATE('" & v_strTXDATE & "', 'DD/MM/YYYY'),'" & v_strORDERID & "','0016'," & ControlChars.CrLf _
                        & "     to_number('" & v_strAMENDQTTY & "'),NULL,'" & v_strORDERID & "','N','" & v_strORDERID & "',seq_odtran.NEXTVAL,'" & v_strTLTXCD & "',TO_DATE('" & v_strTXDATE & "', 'DD/MM/YYYY'),NULL)"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)



                If CDbl(v_strAMENDQTTY) > 0 Then

                    'v_strSQL = "INSERT INTO ODMAST (ORDERID,CUSTID,ACTYPE,CODEID,AFACCTNO,SEACCTNO,CIACCTNO," & ControlChars.CrLf _
                    '                                        & "TXNUM,TXDATE,TXTIME,EXPDATE,BRATIO,TIMETYPE," & ControlChars.CrLf _
                    '                                        & "EXECTYPE,NORK,MATCHTYPE,VIA,CLEARDAY,CLEARCD,ORSTATUS,PORSTATUS,PRICETYPE," & ControlChars.CrLf _
                    '                                        & "QUOTEPRICE,STOPPRICE,LIMITPRICE,ORDERQTTY,REMAINQTTY,EXPRICE,EXQTTY,SECUREDAMT," & ControlChars.CrLf _
                    '                                        & "EXECQTTY,STANDQTTY,CANCELQTTY,ADJUSTQTTY,REJECTQTTY,REJECTCD,VOUCHER,CONSULTANT,REFORDERID,CORRECTIONNUMBER)" & ControlChars.CrLf _
                    '                        & "VALUES ('" & v_strORDERID & "','" & v_strCUSTID & "','" & v_strACTYPE & "','" & v_strCODEID & "','" & v_strAFACCTNO & "','" & v_strSEACCTNO & "','" & v_strCIACCTNO & "'" & ControlChars.CrLf _
                    '                                        & ",'" & v_strTXNUM & "',TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'" & v_strTXTIME & "'" & ControlChars.CrLf _
                    '                                        & ",TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')," & CDbl(v_strBRATIO) & ",'" & v_strTIMETYPE & "'" & ControlChars.CrLf _
                    '                                        & ",'" & v_strEXECTYPE & "','" & v_strNORK & "','" & v_strMATCHTYPE & "','" & v_strVIA & "'" & ControlChars.CrLf _
                    '                                        & "," & v_strCLEARDAY & ",'" & v_strCLEARCD & "','2','2','" & v_strPRICETYPE & "'" & ControlChars.CrLf _
                    '                                        & "," & CDbl(v_strAMENDPRICE) & ",0," & CDbl(v_strLIMITPRICE) & "," & CDbl(v_strAMENDQTTY) & "," & CDbl(v_strAMENDQTTY) & "," & CDbl(v_strAMENDPRICE) & "," & CDbl(v_strAMENDQTTY) & "," & CDbl(v_strAMENDPRICE) * CDbl(v_strAMENDQTTY) * CDbl(v_strBRATIO) / 100 & ",0,0,0,0,0,'001','" & v_strVOUCHER & "','" & v_strCONSULTANT & "','" & v_strREFORDERID & "'," & v_dblNumberCorrection & ")"
                    v_strSQL = "INSERT INTO ODMAST (ORDERID,CUSTID,ACTYPE,CODEID,AFACCTNO,SEACCTNO,CIACCTNO," & ControlChars.CrLf _
                                        & "TXNUM,TXDATE,TXTIME,EXPDATE,BRATIO,TIMETYPE," & ControlChars.CrLf _
                                        & "EXECTYPE,NORK,MATCHTYPE,VIA,CLEARDAY,CLEARCD,ORSTATUS,PORSTATUS,PRICETYPE," & ControlChars.CrLf _
                                        & "QUOTEPRICE,STOPPRICE,LIMITPRICE,ORDERQTTY,REMAINQTTY,EXPRICE,EXQTTY,SECUREDAMT," & ControlChars.CrLf _
                                        & "EXECQTTY,STANDQTTY,CANCELQTTY,ADJUSTQTTY,REJECTQTTY,REJECTCD,VOUCHER,CONSULTANT,REFORDERID,CORRECTIONNUMBER,TLID,DFACCTNO,ISDISPOSAL)" & ControlChars.CrLf _
                        & "VALUES ('" & v_strORDERID & "','" & v_strCUSTID & "','" & v_strACTYPE & "','" & v_strCODEID & "','" & v_strAFACCTNO & "','" & v_strSEACCTNO & "','" & v_strCIACCTNO & "'" & ControlChars.CrLf _
                                        & ",'" & v_strTXNUM & "',TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'" & v_strTXTIME & "'" & ControlChars.CrLf _
                                        & ",TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')," & CDbl(v_strBRATIO) & ",'" & v_strTIMETYPE & "'" & ControlChars.CrLf _
                                        & ",'" & v_strEXECTYPE & "','" & v_strNORK & "','" & v_strMATCHTYPE & "','" & v_strVIA & "'" & ControlChars.CrLf _
                                        & "," & v_strCLEARDAY & ",'" & v_strCLEARCD & "','2','2','" & v_strPRICETYPE & "'" & ControlChars.CrLf _
                                        & "," & CDbl(v_strAMENDPRICE) & ",0," & CDbl(v_strLIMITPRICE) & "," & CDbl(v_strAMENDQTTY) & "," & CDbl(v_strAMENDQTTY) & "," & CDbl(v_strAMENDPRICE) & "," & CDbl(v_strAMENDQTTY) & ",0,0,0,0,0,0,'001','" & v_strVOUCHER & "','" & v_strCONSULTANT & "','" & v_strREFORDERID & "'," & v_dblNumberCorrection & ",'" & v_strTLID & "','" & v_strDFACCTNO & "', '" & v_strISDISPOSAL & "')"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                    'Ghi nhan vao so lenh day di
                    v_strSQL = "INSERT INTO OOD (ORGORDERID,CODEID,SYMBOL,CUSTODYCD," & ControlChars.CrLf _
                                            & "BORS,NORP,AORN,PRICE,QTTY,SECUREDRATIO,OODSTATUS,TXDATE,TXTIME,TXNUM,DELTD,BRID,REFORDERID)" & ControlChars.CrLf _
                            & "VALUES ('" & v_strORDERID & "','" & v_strCODEID & "','" & v_strSymbol & "','" & v_strCUSTODYCD.Replace(".", String.Empty) & "','" & v_strBORS & "','" & v_strMATCHTYPE & "'" & ControlChars.CrLf _
                                            & ",'" & v_strNORK & "'," & CDbl(v_strAMENDPRICE) & "," & CDbl(v_strAMENDQTTY) & "," & CDbl(v_strBRATIO) & ",'" & v_strOODStatus & "',TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'" & v_strTXTIME & "','" & v_strTXNUM & "','N','" & v_strBRID & "','" & v_strREFORDERID & "')"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)



                    'Tao ban ghi trong ODQUEUE,ODQUEUELOG xac nhan lenh da day len san
                    v_strSQL = "INSERT INTO ODQUEUE SELECT * FROM OOD WHERE ORGORDERID = '" & v_strORDERID & "'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                    v_strSQL = "INSERT INTO ODQUEUELOG SELECT * FROM OOD WHERE ORGORDERID = '" & v_strORDERID & "'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)



                End If

                '28/03/2016, TruongLD add, them Flag, check xem co Unhold truc tiep hay khong?
                'Mac dinh la Y: Co, --> Rieng PHS yeu cau la N: khong
                Dim v_UNHOLDREALTIME As String = "Y"
                Dim v_ErrCode As Long
                Try
                    v_ErrCode = v_obj.GetSysVar("SYSTEM", "UNHOLDREALTIME", v_UNHOLDREALTIME)
                Catch ex As Exception
                    LogError.WriteException(ex)
                    v_UNHOLDREALTIME = "N"
                End Try
                'End TruongLD

                'TungNT added - neu lenh huy send = tay thi phai sinh yeu cau unhold
                'If Convert.ToDouble(v_strCANCELQTTY) > 0 And v_strTLTXCD = gc_OD_APPROVE_EDITBUYORDER Then
                If Convert.ToDouble(v_strCANCELQTTY) > 0 And v_strTLTXCD = gc_OD_APPROVE_EDITBUYORDER And v_UNHOLDREALTIME = "Y" Then
                    v_strSQL = "select  af.corebank,af.alternateacct from afmast af where ACCTNO='" & v_strAFACCTNO & "'"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count > 0 Then
                        v_strCOREBANK = v_ds.Tables(0).Rows(0)("COREBANK").ToString().Trim().ToUpper()
                        v_strALTERNATEACCT = v_ds.Tables(0).Rows(0)("ALTERNATEACCT").ToString().Trim().ToUpper()

                        If v_strCOREBANK = "Y" Then
                            If v_strAMENDQTTY = 0 Then
                                Dim v_objParam As StoreParameter
                                Dim v_arrParam(2) As StoreParameter

                                v_objParam = New StoreParameter
                                v_objParam.ParamName = "pv_strORDERID"
                                v_objParam.ParamValue = v_strREFORDERID
                                v_objParam.ParamSize = 30
                                v_objParam.ParamType = GetType(System.String).Name
                                v_objParam.ParamDirection = ParameterDirection.Input
                                v_arrParam(0) = v_objParam

                                v_objParam = New StoreParameter
                                v_objParam.ParamName = "pv_dblCancelQtty"
                                v_objParam.ParamValue = Convert.ToDouble(v_strCANCELQTTY.Replace(",", ""))
                                v_objParam.ParamSize = 30
                                v_objParam.ParamType = GetType(Double).Name '"NUMBER"
                                v_objParam.ParamDirection = ParameterDirection.Input
                                v_arrParam(1) = v_objParam

                                v_objParam = New StoreParameter
                                v_objParam.ParamName = "pv_strErrorCode"
                                v_objParam.ParamValue = ""
                                v_objParam.ParamSize = 100
                                v_objParam.ParamType = GetType(System.String).Name
                                v_objParam.ParamDirection = ParameterDirection.InputOutput
                                v_arrParam(2) = v_objParam
                                v_lngErrCode = v_obj.ExecuteOracleStored("cspks_odproc.pr_RM_UnholdCancelOD", v_arrParam, 2)
                                'v_obj.ExecuteStoredNonQuerry("cspks_odproc.pr_RM_UnholdCancelOD", v_arrParam)
                                'v_lngErrCode = CLng(v_arrParam(2).ParamValue)
                                If v_lngErrCode <> ERR_SYSTEM_OK Then
                                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                     & "Error code: " & v_lngErrCode & "!" & vbNewLine _
                                     & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                                    Return v_lngErrCode
                                End If
                            End If
                        Else
                            If v_strALTERNATEACCT = "Y" Then ' Tai khoan phu
                                If v_strAMENDQTTY = 0 Then
                                    Dim v_objParam As StoreParameter
                                    Dim v_arrParam(1) As StoreParameter

                                    v_objParam = New StoreParameter
                                    v_objParam.ParamName = "pv_strACCTNO"
                                    v_objParam.ParamValue = v_strAFACCTNO
                                    v_objParam.ParamSize = 30
                                    v_objParam.ParamType = GetType(System.String).Name
                                    v_objParam.ParamDirection = ParameterDirection.Input
                                    v_arrParam(0) = v_objParam

                                    v_objParam = New StoreParameter
                                    v_objParam.ParamName = "pv_strErrorCode"
                                    v_objParam.ParamValue = ""
                                    v_objParam.ParamSize = 100
                                    v_objParam.ParamType = GetType(System.String).Name
                                    v_objParam.ParamDirection = ParameterDirection.InputOutput
                                    v_arrParam(1) = v_objParam
                                    v_lngErrCode = v_obj.ExecuteOracleStored("cspks_rmproc.pr_RM_UnholdAccount", v_arrParam, 1)
                                    'v_obj.ExecuteStoredNonQuerry("cspks_odproc.pr_RM_UnholdCancelOD", v_arrParam)
                                    'v_lngErrCode = CLng(v_arrParam(2).ParamValue)
                                    If v_lngErrCode <> ERR_SYSTEM_OK Then
                                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                         & "Error code: " & v_lngErrCode & "!" & vbNewLine _
                                         & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                                        Return v_lngErrCode
                                    End If
                                End If
                            End If
                        End If
                    Else
                        v_lngErrCode = ERR_CI_AFACCTNO_NOTFOUND
                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                         & "Error code: " & v_lngErrCode & "!" & vbNewLine _
                         & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                        Return v_lngErrCode
                    End If
                End If
                'End
                'TungNT added - neu lenh sua send = tay thi phai sinh yeu cau unhold
                'If Convert.ToDouble(v_strAMENDQTTY) > 0 And v_strTLTXCD = gc_OD_APPROVE_EDITBUYORDER Then
                If Convert.ToDouble(v_strAMENDQTTY) > 0 And v_strTLTXCD = gc_OD_APPROVE_EDITBUYORDER And v_UNHOLDREALTIME = "Y" Then
                    v_strSQL = "select  (case when af.corebank = 'Y' then af.corebank else af.alternateacct end) COREBANK from afmast af where ACCTNO='" & v_strAFACCTNO & "'"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count > 0 Then
                        v_strCOREBANK = v_ds.Tables(0).Rows(0)("COREBANK").ToString().Trim().ToUpper()
                        If v_strCOREBANK = "Y" Then
                            Dim v_objParam As StoreParameter
                            Dim v_arrParam(1) As StoreParameter

                            v_objParam = New StoreParameter
                            v_objParam.ParamName = "pv_strACCTNO"
                            v_objParam.ParamValue = v_strAFACCTNO
                            v_objParam.ParamSize = 30
                            v_objParam.ParamType = GetType(System.String).Name
                            v_objParam.ParamDirection = ParameterDirection.Input
                            v_arrParam(0) = v_objParam

                            v_objParam = New StoreParameter
                            v_objParam.ParamName = "pv_strErrorCode"
                            v_objParam.ParamValue = ""
                            v_objParam.ParamSize = 100
                            v_objParam.ParamType = GetType(System.String).Name
                            v_objParam.ParamDirection = ParameterDirection.InputOutput
                            v_arrParam(1) = v_objParam
                            v_lngErrCode = v_obj.ExecuteOracleStored("cspks_rmproc.pr_RM_UnholdAccount", v_arrParam, 1)
                            'v_obj.ExecuteStoredNonQuerry("cspks_odproc.pr_RM_UnholdCancelOD", v_arrParam)
                            'v_lngErrCode = CLng(v_arrParam(2).ParamValue)
                            If v_lngErrCode <> ERR_SYSTEM_OK Then
                                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode & "!" & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                                Return v_lngErrCode
                            End If
                        End If
                    Else
                        v_lngErrCode = ERR_CI_AFACCTNO_NOTFOUND
                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                         & "Error code: " & v_lngErrCode & "!" & vbNewLine _
                         & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                        Return v_lngErrCode
                    End If
                End If
                'End

            Else
                If v_strTIMETYPE = "G" Then
                    'lENH YEU CAU GTO SE BI HUY, DO LENH CON TREN SAN DA THAY DOI
                    'v_strSQL = "UPDATE FOMAST SET DELTD='N' WHERE ORGACCTNO= '" & v_strTempOrderID & "'"
                    v_strSQL = "UPDATE FOMAST SET REMAINQTTY=REMAINQTTY + (" & CDbl(v_strCANCELQTTY) + CDbl(v_strAMENDQTTY) & ") ,CANCELQTTY=CANCELQTTY - " & v_strCANCELQTTY & " ,amendqtty = amendqtty - " & v_strAMENDQTTY & ", REFACCTNO='' WHERE ACCTNO = (SELECT FOACCTNO FROM ODMAST WHERE ORDERID='" & v_strREFORDERID & "')"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                End If
                If CDbl(v_strAMENDQTTY) > 0 Then
                    'Xoa trong OOD
                    v_strSQL = "UPDATE OOD SET DELTD='Y' WHERE TXNUM='" & v_strTXNUM & "' AND TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    'Xoa trong ODMAST
                    v_strSQL = "UPDATE ODMAST SET DELTD='Y' WHERE TXNUM='" & v_strTXNUM & "' AND TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    'Xoa trong ODQUEUE
                    v_strSQL = "UPDATE ODQUEUE SET DELTD='Y' WHERE TXNUM='" & v_strTXNUM & "' AND TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    v_strSQL = "UPDATE ODQUEUELOG SET DELTD='Y' WHERE TXNUM='" & v_strTXNUM & "' AND TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                    v_strSQL = "UPDATE ODCANCEL SET DELTD='Y' WHERE TXNUM='" & v_strTXNUM & "' AND TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                End If
            End If

            'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            ''ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function ClearOrder(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "OD.Trans.ClearOrder", v_strErrorMessage As String

        Try


            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, v_strSQL As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE As Double
            Dim v_strCODEID, v_strACTYPE, v_strORGORDERID, v_strSYMBOL, v_strCUSTODYCD,
                v_strSEACCTNO, v_strCIACCTNO, v_strAFACCTNO,
                v_strBORS, v_strNORP, v_strAORN, v_strCLEARCD, v_strPRICETYPE, v_strDESC As String
            Dim v_dblAVLCANCELQTTY, v_dblAVLCANCELAMT, v_dblPARVALUE, v_dblBRATIO, v_dblEXPRICE, v_dblEXQTTY, v_dblIsMortage As Double
            Dim v_ds As DataSet
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_strBRID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXTIME As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTIME).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strTLTXCD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value
            Dim v_blnREVERSAL As Boolean = IIf(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value = "Y", True, False)


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
                        Case "03" 'ORGORDERID
                            v_strORGORDERID = v_strVALUE
                        Case "80" 'CODEID
                            v_strCODEID = v_strVALUE
                        Case "81" 'SYMBOL                                       
                            v_strSYMBOL = v_strVALUE
                        Case "82" 'CUSTODYCD                                       
                            v_strCUSTODYCD = v_strVALUE
                        Case "83" 'BORS                                       
                            v_strBORS = v_strVALUE
                        Case "84" 'NORP
                            v_strNORP = v_strVALUE
                        Case "85" 'AORN
                            v_strAORN = v_strVALUE
                        Case "05" 'CIACCTNO
                            v_strCIACCTNO = v_strVALUE
                        Case "06" 'SEACCTNO
                            v_strSEACCTNO = v_strVALUE
                        Case "07" 'AFACCTNO
                            v_strAFACCTNO = v_strVALUE
                        Case "10" 'AVLCANCELQTTY                                         
                            v_dblAVLCANCELQTTY = v_dblVALUE
                        Case "11" 'AVLCANCELAMT
                            v_dblAVLCANCELAMT = v_dblVALUE
                        Case "12" 'PARVALUE                                      
                            v_dblPARVALUE = v_dblVALUE
                        Case "13" 'EXPRICE
                            v_dblEXPRICE = v_dblVALUE
                        Case "30" 'DESC                                              
                            v_strDESC = v_strVALUE
                        Case "60" 'ismortage                                              
                            v_dblIsMortage = v_dblVALUE
                    End Select
                End With
            Next
            Dim v_strTIMETYPE As String
            Dim v_dblRemainQtty, v_dblEXECQTTY, v_dblEXECAMT, v_dblCANCELQTTY, v_dblADJUSTQTTY, v_dblQuotePrice, v_dblUnholdAmt As Double
            v_strSQL = "SELECT * FROM ODMAST " & ControlChars.CrLf _
                    & "WHERE TRIM(ORDERID)='" & v_strORGORDERID & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If Not v_ds.Tables(0).Rows.Count > 0 Then
                'So luong huy khong hop le
                v_lngErrCode = ERR_OD_ORDER_NOT_FOUND
                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                             & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                             & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                Return v_lngErrCode
            Else
                v_strTIMETYPE = v_ds.Tables(0).Rows(0)("TIMETYPE")
                v_dblRemainQtty = v_ds.Tables(0).Rows(0)("REMAINQTTY")
                v_dblEXECQTTY = v_ds.Tables(0).Rows(0)("EXECQTTY")
                v_dblEXECAMT = v_ds.Tables(0).Rows(0)("EXECAMT")
                v_dblCANCELQTTY = v_ds.Tables(0).Rows(0)("CANCELQTTY")
                v_dblADJUSTQTTY = v_ds.Tables(0).Rows(0)("ADJUSTQTTY")
            End If

            If Not v_blnREVERSAL Then
                'TungNT added - neu la truong hop corebank thi can phai sinh giao dich giai toa ra
                If v_strTLTXCD = gc_OD_CLEARBUYORDER Or v_strTLTXCD = gc_OD_CLEARBUYSENDINGORDER Then
                    v_strSQL = "SELECT COREBANK,HOLDBALANCE FROM CIMAST WHERE ACCTNO='" & v_strCIACCTNO & "'"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows(0)("COREBANK").ToString().Trim().ToUpper() = "Y" Then
                        'Chi giai toa phan gia tri chua khop, phan phi thi phai cho tinh va giai toa sau
                        v_dblUnholdAmt = v_dblAVLCANCELQTTY * v_dblQuotePrice
                        If Convert.ToDouble(v_ds.Tables(0).Rows(0)("HOLDBALANCE")) < v_dblUnholdAmt Then
                            v_lngErrCode = ERR_CR_HOLDBALANCE_NOT_ENOUGH
                            Return v_lngErrCode
                        Else
                            'Thuc hien giai toa
                            Dim v_objParam As New StoreParameter
                            Dim v_arrPara(2) As StoreParameter
                            v_objParam.ParamName = "pv_strORDERID"
                            v_objParam.ParamDirection = ParameterDirection.Input
                            v_objParam.ParamValue = v_strORGORDERID
                            v_objParam.ParamSize = 100
                            v_objParam.ParamType = GetType(System.String).Name
                            v_arrPara(0) = v_objParam

                            v_objParam = New StoreParameter
                            v_objParam.ParamName = "pv_dblCancelQtty"
                            v_objParam.ParamDirection = ParameterDirection.Input
                            v_objParam.ParamValue = v_dblAVLCANCELQTTY
                            v_objParam.ParamSize = 100
                            v_objParam.ParamType = GetType(System.Int64).Name
                            v_arrPara(1) = v_objParam

                            v_objParam = New StoreParameter
                            v_objParam.ParamName = "pv_strErrorCode"
                            v_objParam.ParamDirection = ParameterDirection.Output
                            v_objParam.ParamValue = ""
                            v_objParam.ParamSize = 100
                            v_objParam.ParamType = GetType(System.String).Name
                            v_arrPara(2) = v_objParam
                            v_lngErrCode = v_obj.ExecuteOracleStored("cspks_odproc.pr_RM_UnholdCancelOD", v_arrPara, 2)
                            If Not IsNumeric(v_arrPara(2).ParamValue) Then
                                v_lngErrCode = 0
                            Else
                                v_lngErrCode = CDec(v_arrPara(2).ParamValue)
                            End If
                        End If
                    End If
                End If
                'End

                'Kiem tra so luong yeu cau huy co phu hop khong
                v_strSQL = "SELECT * FROM ODMAST " & ControlChars.CrLf _
                    & "WHERE TRIM(ORDERID)='" & v_strORGORDERID & "'" & ControlChars.CrLf _
                    & "AND ORDERQTTY-ADJUSTQTTY-CANCELQTTY-EXECQTTY>=" & v_dblAVLCANCELQTTY
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If Not v_ds.Tables(0).Rows.Count > 0 Then
                    'So luong huy khong hop le
                    v_lngErrCode = ERR_OD_INVALID_CANCELQTTY
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If


                'Ghi nhan vao so lenh day di, trang thai OOD la E, Error khong cho phep day di
                v_strSQL = "SELECT * FROM OOD WHERE ORGORDERID='" & v_strORGORDERID & "' AND OODSTATUS<>'E'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                If Not v_ds.Tables(0).Rows.Count > 0 Then
                    'Lenh da duoc giai toa hoac chua duoc day di thi khong can cap nhat lai trang thai OOD
                Else
                    'Cap nhat trang thai cua OOD
                    v_strSQL = "UPDATE OOD SET OODSTATUS='E' WHERE ORGORDERID='" & v_strORGORDERID & "' AND OODSTATUS<>'E'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    'CAP NHAT TRANG THAI CUA ODQUEUE
                    v_strSQL = "UPDATE ODQUEUE SET DELTD='Y' WHERE ORGORDERID='" & v_strORGORDERID & "'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                End If
                If v_strTIMETYPE = "G" Then
                    'Cap nhat tro lai voi lenh GTC
                    v_strSQL = "SELECT * FROM FOMAST WHERE ORGACCTNO='" & v_strORGORDERID & "' AND DELTD<>'Y' AND TIMETYPE='G'"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count > 0 Then
                        v_strSQL = "UPDATE FOMAST SET STATUS='P',REMAINQTTY=" & v_dblRemainQtty & ",EXECQTTY=" & v_dblEXECQTTY & ",EXECAMT=" & v_dblEXECAMT & ",CANCELQTTY=" & v_dblCANCELQTTY & ",AMENDQTTY=" & v_dblADJUSTQTTY & " WHERE ACCTNO='" & v_ds.Tables(0).Rows(0)("ACCTNO") & "'"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    End If
                End If
            Else
                If v_strTLTXCD = gc_OD_CLEARBUYORDER Then
                    'TungNT added, neu la lenh mua corebank thi ko cho phep xoa
                    If v_strTLTXCD = gc_OD_CLEARBUYORDER Or v_strTLTXCD = gc_OD_CLEARBUYSENDINGORDER Then
                        v_strSQL = "SELECT COREBANK,HOLDBALANCE FROM CIMAST WHERE ACCTNO='" & v_strCIACCTNO & "'"
                        v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                        If v_ds.Tables(0).Rows(0)("COREBANK").ToString().Trim().ToUpper() = "Y" Then
                            v_lngErrCode = ERR_SA_CANNOT_DELETETRANSACTION
                            Return v_lngErrCode
                        End If
                    End If
                    'TungNT End

                    'xoa phai kiem tra balance 
                    v_strSQL = " SELECT  BALANCE - " & v_dblAVLCANCELAMT & " FROM CIMAST WHERE ACCTNO = '" & v_strAFACCTNO & "'"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows(0)(0) < 0 Then
                        'So luong huy khong hop le
                        v_lngErrCode = ERR_OD_CANCELAMT_NOT_ENOUGHT

                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                     & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                     & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                        Return v_lngErrCode
                    End If
                ElseIf v_strTLTXCD = gc_OD_CLEARSELLORDER Then
                    'xoa phai kiem tra TRADE , MORTAGE 
                    v_strSQL = " SELECT (CASE WHEN " & v_dblIsMortage & " = 0 THEN TRADE - " & v_dblAVLCANCELQTTY & " ELSE MORTAGE - " & v_dblAVLCANCELQTTY & " END ) amt FROM SEMAST WHERE ACCTNO = '" & v_strSEACCTNO & "'"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows(0)(0) < 0 Then
                        'So luong huy khong hop le
                        v_lngErrCode = ERR_OD_CANCELQTTY_NOT_ENOUGHT
                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                     & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                     & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                        Return v_lngErrCode
                    End If
                End If

                'Tra lai trang thai cho lenh outgoing
                v_strSQL = "SELECT * FROM OOD WHERE ORGORDERID='" & v_strORGORDERID & "' AND OODSTATUS='E'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If Not v_ds.Tables(0).Rows.Count > 0 Then
                    'Lenh da duoc giai toa hoac chua duoc day di thi khong can cap nhat lai trang thai OOD
                Else
                    'Cap nhat trang thai cua OOD
                    v_strSQL = "SELECT * FROM ODQUEUE WHERE ORGORDERID='" & v_strORGORDERID & "'"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If Not v_ds.Tables(0).Rows.Count > 0 Then
                        'NEU LENH GIAI TOA LA CHUA SEND THI VAO ODSEND
                        v_strSQL = "UPDATE OOD SET OODSTATUS='N' WHERE ORGORDERID='" & v_strORGORDERID & "' AND OODSTATUS='E'"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                    Else
                        'LENH SAU KHI GIAI TOA MA DA SEND THI KHONG DUOC XOA
                        If v_ds.Tables(0).Rows(0)("DELTD") <> "Y" Then
                            'LENH DA SEND, KHONG DUOC XOA
                            v_lngErrCode = ERR_OOD_STATUS_IS_SENT
                            LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                         & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                         & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                            Return v_lngErrCode

                        Else
                            'NEU LENH DA DAY ROI THI DUA VAO ODMATCH
                            v_strSQL = "UPDATE OOD SET OODSTATUS='S' WHERE ORGORDERID='" & v_strORGORDERID & "' AND OODSTATUS='E'"
                            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                            v_strSQL = "UPDATE ODQUEUE SET DELTD='N' WHERE ORGORDERID='" & v_strORGORDERID & "'"
                            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                        End If

                    End If

                End If
                If v_strTIMETYPE = "G" Then
                    'Cap nhat tro lai voi lenh GTC
                    v_strSQL = "SELECT * FROM FOMAST WHERE ORGACCTNO='" & v_strORGORDERID & "' AND DELTD<>'Y' AND TIMETYPE='G' AND STATUS='P'"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count > 0 Then
                        v_strSQL = "UPDATE FOMAST SET STATUS='A',REMAINQTTY=" & v_dblRemainQtty & ",EXECQTTY=" & v_dblEXECQTTY & ",EXECAMT=" & v_dblEXECAMT & ",CANCELQTTY=" & v_dblCANCELQTTY & ",AMENDQTTY=" & v_dblADJUSTQTTY & " WHERE ACCTNO='" & v_ds.Tables(0).Rows(0)("ACCTNO") & "'"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    Else
                        'Lenh yeu cau GTC da bi send di roi
                        v_lngErrCode = ERR_OD_SEND_ALREADY
                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                     & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                     & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                        Return v_lngErrCode
                    End If
                End If
            End If

            'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            ''ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function ReleaseOrder(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "OD.Trans.ReleaseOrder", v_strErrorMessage As String

        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, v_strSQL As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE As Double
            Dim v_strCODEID, v_strACTYPE, v_strORGORDERID, v_strSYMBOL, v_strCUSTODYCD,
                v_strSEACCTNO, v_strCIACCTNO, v_strAFACCTNO,
                v_strBORS, v_strNORP, v_strAORN, v_strCLEARCD, v_strPRICETYPE, v_strDESC As String
            Dim v_dblAVLCANCELQTTY, v_dblAVLCANCELAMT, v_dblPARVALUE, v_dblBRATIO, v_dblEXPRICE, v_dblEXQTTY, v_dblIsMortage As Double
            Dim v_ds As DataSet
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_strBRID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXTIME As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTIME).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strTLTXCD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value
            Dim v_blnREVERSAL As Boolean = IIf(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value = "Y", True, False)


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
                        Case "03" 'ORGORDERID
                            v_strORGORDERID = v_strVALUE
                        Case "80" 'CODEID
                            v_strCODEID = v_strVALUE
                        Case "05" 'CIACCTNO
                            v_strCIACCTNO = v_strVALUE
                        Case "06" 'SEACCTNO
                            v_strSEACCTNO = v_strVALUE
                        Case "07" 'AFACCTNO
                            v_strAFACCTNO = v_strVALUE
                        Case "10" 'REMAINQTTY
                            v_dblAVLCANCELQTTY = v_dblVALUE
                        Case "11" 'AVLCANCELAMT
                            v_dblAVLCANCELAMT = v_dblVALUE
                        Case "12" 'PARVALUE
                            v_dblPARVALUE = v_dblVALUE
                        Case "13" 'EXPRICE
                            v_dblEXPRICE = v_dblVALUE
                        Case "30" 'DESC                                              
                            v_strDESC = v_strVALUE
                        Case "60" 'Is Mortage
                            v_dblIsMortage = v_dblVALUE
                    End Select
                End With
            Next
            Dim v_strTIMETYPE As String
            Dim v_dblRemainQtty, v_dblEXECQTTY, v_dblEXECAMT, v_dblCANCELQTTY, v_dblADJUSTQTTY As Double
            v_strSQL = "SELECT * FROM ODMAST " & ControlChars.CrLf _
                    & "WHERE TRIM(ORDERID)='" & v_strORGORDERID & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_strTIMETYPE = v_ds.Tables(0).Rows(0)("TIMETYPE")
                v_dblRemainQtty = v_ds.Tables(0).Rows(0)("REMAINQTTY")
                v_dblEXECQTTY = v_ds.Tables(0).Rows(0)("EXECQTTY")
                v_dblEXECAMT = v_ds.Tables(0).Rows(0)("EXECAMT")
                v_dblCANCELQTTY = v_ds.Tables(0).Rows(0)("CANCELQTTY")
                v_dblADJUSTQTTY = v_ds.Tables(0).Rows(0)("ADJUSTQTTY")
            End If

            If Not v_blnREVERSAL Then
                If v_strTIMETYPE = "G" Then
                    'Cap nhat tro lai voi lenh GTC
                    v_strSQL = "SELECT * FROM FOMAST WHERE ORGACCTNO='" & v_strORGORDERID & "' AND DELTD<>'Y' AND TIMETYPE='G'"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count > 0 Then
                        v_strSQL = "UPDATE FOMAST SET STATUS='P',REMAINQTTY=" & v_dblRemainQtty & ",EXECQTTY=" & v_dblEXECQTTY & ",EXECAMT=" & v_dblEXECAMT & ",CANCELQTTY=" & v_dblCANCELQTTY & ",AMENDQTTY=" & v_dblADJUSTQTTY & " WHERE ACCTNO='" & v_ds.Tables(0).Rows(0)("ACCTNO") & "'"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    End If
                End If
            Else
                If v_strTIMETYPE = "G" Then
                    'Cap nhat tro lai voi lenh GTC
                    v_strSQL = "SELECT * FROM FOMAST WHERE ORGACCTNO='" & v_strORGORDERID & "' AND DELTD<>'Y' AND TIMETYPE='G' AND STATUS='P'"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count > 0 Then
                        v_strSQL = "UPDATE FOMAST SET STATUS='A',REMAINQTTY=" & v_dblRemainQtty & ",EXECQTTY=" & v_dblEXECQTTY & ",EXECAMT=" & v_dblEXECAMT & ",CANCELQTTY=" & v_dblCANCELQTTY & ",AMENDQTTY=" & v_dblADJUSTQTTY & " WHERE ACCTNO='" & v_ds.Tables(0).Rows(0)("ACCTNO") & "'"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    Else
                        'Lenh yeu cau GTC da bi send di roi
                        v_lngErrCode = ERR_OD_SEND_ALREADY
                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                     & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                     & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                        Return v_lngErrCode
                    End If
                End If
            End If

            'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            ''ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function


    Private Function SendOrder2TradingCenter(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "OD.Trans.SendOrder2TradingCenter", v_strErrorMessage As String

        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, v_strSQL As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE As Double
            Dim v_strCODEID, v_strACTYPE, v_strORGORDERID, v_strSYMBOL, v_strCUSTODYCD,
                v_strSEACCTNO, v_strCIACCTNO, v_strAFACCTNO,
                v_strBORS, v_strNORP, v_strAORN, v_strCLEARCD, v_strPRICETYPE, v_strDESC As String
            Dim v_dblPRICE, v_dblQTTY, v_dblPARVALUE, v_dblBRATIO As Double
            Dim v_ds As DataSet
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_strBRID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXTIME As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTIME).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_blnREVERSAL As Boolean = IIf(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value = "Y", True, False)

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
                        Case "03" 'ORGORDERID
                            v_strORGORDERID = v_strVALUE
                        Case "30" 'DESC                                              
                            v_strDESC = v_strVALUE
                    End Select
                End With
            Next

            If Not v_blnREVERSAL Then
                'Lenh da duoc doc len san
                v_strSQL = "UPDATE OOD SET OODSTATUS='S' WHERE TRIM(ORGORDERID)='" & v_strORGORDERID.Trim & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            Else
                'Xoa so lenh day di
                v_strSQL = "UPDATE OOD SET OODSTATUS='N' WHERE TRIM(ORGORDERID)='" & v_strORGORDERID.Trim & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            End If

            'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            ''ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function SendOrder(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "OD.Trans.SendOrder", v_strErrorMessage As String

        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, v_strSQL As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE As Double
            Dim v_strCODEID, v_strACTYPE, v_strORGORDERID, v_strSYMBOL, v_strCUSTODYCD,
                v_strSEACCTNO, v_strCIACCTNO, v_strAFACCTNO,
                v_strBORS, v_strNORP, v_strAORN, v_strCLEARCD, v_strPRICETYPE, v_strDESC As String
            Dim v_dblPRICE, v_dblQTTY, v_dblPARVALUE, v_dblBRATIO As Double
            Dim v_ds As DataSet
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_strBRID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXTIME As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTIME).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_blnREVERSAL As Boolean = IIf(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value = "Y", True, False)

            '?�?c n�ội dung giao dịch
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
                        Case "03" 'ORGORDERID
                            v_strORGORDERID = v_strVALUE
                        Case "80" 'CODEID
                            v_strCODEID = v_strVALUE
                        Case "81" 'SYMBOL                                       
                            v_strSYMBOL = v_strVALUE
                        Case "82" 'CUSTODYCD                                       
                            v_strCUSTODYCD = v_strVALUE
                        Case "83" 'BORS                                       
                            v_strBORS = v_strVALUE
                        Case "84" 'NORP
                            v_strNORP = v_strVALUE
                        Case "85" 'AORN
                            v_strAORN = v_strVALUE
                        Case "05" 'CIACCTNO
                            v_strCIACCTNO = v_strVALUE
                        Case "06" 'SEACCTNO
                            v_strSEACCTNO = v_strVALUE
                        Case "07" 'AORN
                            v_strAFACCTNO = v_strVALUE
                        Case "10" 'PRICE                                         
                            v_dblPRICE = v_dblVALUE
                        Case "11" 'QTTY
                            v_dblQTTY = v_dblVALUE
                        Case "12" 'PARVALUE                                      
                            v_dblPARVALUE = v_dblVALUE
                        Case "13" 'SRATIO                                      
                            v_dblBRATIO = v_dblVALUE
                        Case "30" 'DESC                                              
                            v_strDESC = v_strVALUE
                    End Select
                End With
            Next

            If Not v_blnREVERSAL Then   'Tạo lệnh khớp
                'Kiểm tra đã có lệnh đẩy lên sàn chưa
                v_strSQL = "SELECT * FROM OOD WHERE ORGORDERID='" & v_strORGORDERID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    'Trả v? m�ã lỗi lệnh đã đẩy lên sàn
                    v_lngErrCode = ERR_OD_SEND_ALREADY
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    BuildXMLErrorException(pv_xmlDocument, v_strErrorSource, v_lngErrCode, v_strErrorMessage)
                    Return v_lngErrCode
                End If

                Dim v_dblTradeLot, v_dblTradeUnit, v_dblFloorPrice, v_dblCeilingPrice, v_dblTickSize, v_dblFromPrice As Double, v_strTRADEBUYSELL As String
                'Kiểm tra chứng khoán có trong hệ thống hay không
                v_strSQL = "SELECT * FROM SECURITIES_INFO WHERE TRIM(CODEID)='" & v_strCODEID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_dblTradeLot = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("TRADELOT"))
                    v_dblTradeUnit = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("TRADEUNIT"))
                    v_strTRADEBUYSELL = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("TRADEBUYSELL"))
                    v_dblFloorPrice = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("FLOORPRICE"))
                    v_dblCeilingPrice = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("CEILINGPRICE"))
                Else
                    'Báo lỗi chưa khai báo SECURITIES_INFO
                    v_lngErrCode = ERR_OD_SECURITIES_INFO_UNDEFINED
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode

                End If

                'Kiểm tra khối lượng có chia hết cho TRADE_LOT không
                If v_dblTradeLot > 0 Then
                    If v_dblQTTY Mod v_dblTradeLot <> 0 Then
                        v_lngErrCode = ERR_OD_QTTY_TRADELOT_INCORRECT
                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                     & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                     & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                        Return v_lngErrCode
                    End If
                End If

                'Giá đặt lệnh phải nằm trong khoảng trần sàn
                If v_dblPRICE < v_dblFloorPrice Or v_dblPRICE > v_dblCeilingPrice Then
                    v_lngErrCode = ERR_OD_LO_PRICE_ISNOT_FLOOR_CEILLING
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If

                'Kiểm tra ticksize
                v_strSQL = "SELECT FROMPRICE, TICKSIZE FROM SECURITIES_TICKSIZE WHERE TRIM(CODEID)='" & v_strCODEID & "' AND TRIM(STATUS)='Y' " _
                    & "AND TOPRICE>=" & v_dblPRICE & " AND FROMPRICE<=" & v_dblPRICE
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_dblTickSize = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("TICKSIZE"))
                    v_dblFromPrice = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("FROMPRICE"))
                    If (v_dblPRICE - v_dblFromPrice) Mod v_dblTickSize <> 0 Then
                        'Không đúng với TICKSIZE
                        v_lngErrCode = ERR_OD_TICKSIZE_INCOMPLIANT
                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                     & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                     & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                        Return v_lngErrCode
                    End If
                Else
                    'Chưa định nghĩa TICKSIZE
                    v_lngErrCode = ERR_OD_TICKSIZE_UNDEFINED
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If

                'Kiểm tra chứng khoán có được phép vừa mua/bán trong ngày không TRADEBUYSELL của bảng SECURITIES_INFO
                If v_strTRADEBUYSELL = "N" Then
                    If v_strBORS = "B" Then
                        'Nếu là lệnh mua thì kiểm tra có lệnh bán nào không
                        v_strSQL = "SELECT COUNT(*) CNT FROM OOD, ODMAST WHERE OOD.ORGORDERID=ODMAST.ORDERID " & ControlChars.CrLf _
                            & "AND TRIM(OOD.CODEID)='" & v_strCODEID & "' AND TRIM(OOD.BORS)='S' AND (ODMAST.AFACCTNO)='" & v_strAFACCTNO & "'"
                    Else
                        'Nếu là lệnh bán thì kiểm tra có lệnh mua nào không
                        v_strSQL = "SELECT COUNT(*) CNT FROM OOD, ODMAST WHERE OOD.ORGORDERID=ODMAST.ORDERID " & ControlChars.CrLf _
                            & "AND TRIM(OOD.CODEID)='" & v_strCODEID & "' AND TRIM(OOD.BORS)='B' AND (ODMAST.AFACCTNO)='" & v_strAFACCTNO & "'"
                    End If
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("CNT")) > 0 Then
                        'Báo lỗi không thể cùng mua cùng bán một chứng khoán trong cùng một ngày
                        v_lngErrCode = ERR_OD_BUYSELL_SAME_SECURITIES
                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                     & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                     & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                        Return v_lngErrCode
                    End If
                End If

                'Ghi nhận vào sổ lệnh đẩy đi
                v_strSQL = "INSERT INTO OOD (ORGORDERID,CODEID,SYMBOL,CUSTODYCD," & ControlChars.CrLf _
                                        & "BORS,NORP,AORN,PRICE,QTTY,SECUREDRATIO,OODSTATUS,TXDATE,TXNUM,DELTD)" & ControlChars.CrLf _
                        & "VALUES ('" & v_strORGORDERID & "','" & v_strCODEID & "','" & v_strSYMBOL & "','" & v_strCUSTODYCD & "','" & v_strBORS & "','" & v_strNORP & "'" & ControlChars.CrLf _
                                        & ",'" & v_strAORN & "'," & v_dblPRICE & "," & v_dblQTTY & "," & v_dblBRATIO & ",'N',TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'" & v_strTXNUM & "','N')"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            Else
                'Xoá sổ lệnh đẩy đi
                v_strSQL = "UPDATE OOD SET DELTD='Y' WHERE TXNUM='" & v_strTXNUM & "' AND TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End If

            'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            ''ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function


    Private Function CorrectOrder(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "OD.Trans.SendOrder", v_strErrorMessage As String

        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, v_strSQL As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE As Double
            Dim v_strCODEID, v_strACTYPE, v_strORGORDERID, v_strSYMBOL, v_strCUSTODYCD,
                v_strSEACCTNO, v_strCIACCTNO, v_strAFACCTNO, v_strTO_AFACCTNO, v_strTO_CUSTODYCD,
                v_strBORS, v_strNORP, v_strAORN, v_strCLEARCD, v_strPRICETYPE, v_strDESC, v_strLOGTYPE As String
            Dim v_dblPRICE, v_dblQTTY, v_dblPARVALUE, v_dblBRATIO As Double
            Dim v_ds As DataSet
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_strBRID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXTIME As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTIME).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strTLTXCD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value
            Dim v_blnREVERSAL As Boolean = IIf(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value = "Y", True, False)

            'Set the log type
            Select Case v_strTLTXCD
                Case gc_OD_CORRECT_BUY_ORDER, gc_OD_CORRECT_SELL_ORDER
                    v_strLOGTYPE = "C"
                Case gc_OD_MOVE_BUY_DEAL, gc_OD_MOVE_SELL_DEAL
                    v_strLOGTYPE = "M"
                Case Else
                    v_strLOGTYPE = "N"
            End Select

            '?�?c n�ội dung giao dịch
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
                        Case "03" 'ORGORDERID
                            v_strORGORDERID = v_strVALUE
                        Case "05" 'CIACCTNO
                            v_strCIACCTNO = v_strVALUE
                        Case "06" 'SEACCTNO
                            v_strSEACCTNO = v_strVALUE
                        Case "07" 'AFACCTNO
                            v_strAFACCTNO = v_strVALUE

                        Case "08" 'NEW - AFACCTNO
                            v_strTO_AFACCTNO = v_strVALUE
                        Case "09" 'NEW - CUSTODYCD
                            v_strTO_CUSTODYCD = v_strVALUE

                        Case "80" 'CODEID
                            v_strCODEID = v_strVALUE
                        Case "81" 'SYMBOL                                       
                            v_strSYMBOL = v_strVALUE
                        Case "82" 'CUSTODYCD                                       
                            v_strCUSTODYCD = v_strVALUE
                        Case "83" 'BORS                                       
                            v_strBORS = v_strVALUE
                        Case "84" 'NORP
                            v_strNORP = v_strVALUE
                        Case "85" 'AORN
                            v_strAORN = v_strVALUE
                        Case "10" 'PRICE                                         
                            v_dblPRICE = v_dblVALUE
                        Case "11" 'QTTY
                            v_dblQTTY = v_dblVALUE
                        Case "12" 'PARVALUE                                      
                            v_dblPARVALUE = v_dblVALUE
                        Case "13" 'SRATIO                                      
                            v_dblBRATIO = v_dblVALUE
                        Case "30" 'DESC                                              
                            v_strDESC = v_strVALUE
                    End Select
                End With
            Next

            If Not v_blnREVERSAL Then   'Tạo lệnh khớp
                'Kiểm tra chỉ cho phép chuyển nếu chưa thực hiện thanh toán, chưa ứng trước hoặc forward chờ về
                v_strSQL = "SELECT COUNT(*) CNT FROM STSCHD WHERE (STATUS<>'N' OR AAMT>0 OR AQTTY>0) AND ORGORDERID='" & v_strORGORDERID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("CNT")) > 0 Then
                    'Không thể move lệnh đã thanh toán
                    v_lngErrCode = ERR_OD_STSCHD_STATUSINVALID
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If
                'Sao lưu sổ lệnh cũ
                v_strSQL = "INSERT INTO LOG_ODMAST (AUTOID, TXDATE, TXNUM, " _
                    & "LOGTYP, ORGORDERID, FRAFACCTNO, TOAFACCTNO, EXECTYPE, CODEID, QTTY, PRICE, AMOUNT, DELTD) " _
                    & "SELECT SEQ_LOG_ODMAST.NEXTVAL, TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'" & v_strTXNUM & "', " _
                    & "'" & v_strLOGTYPE & "', ORDERID, AFACCTNO, '" & v_strTO_AFACCTNO & "', EXECTYPE, CODEID, ORDERQTTY, QUOTEPRICE, QUOTEPRICE*ORDERQTTY*BRATIO, 'N' " _
                    & "FROM ODMAST WHERE ORDERID='" & v_strORGORDERID & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                v_strSQL = "UPDATE STSCHD SET AFACCTNO='" & v_strTO_AFACCTNO & "', ACCTNO='" & v_strTO_AFACCTNO _
                    & "' WHERE (DUETYPE='RM' OR DUETYPE='SM') AND ORGORDERID='" & v_strORGORDERID & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                v_strSQL = "UPDATE STSCHD SET AFACCTNO='" & v_strTO_AFACCTNO & "', ACCTNO='" & v_strTO_AFACCTNO & v_strCODEID _
                    & "' WHERE (DUETYPE='RS' OR DUETYPE='SS') AND ORGORDERID='" & v_strORGORDERID & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                'Cập nhật sổ lệnh với tài khoản mới
                v_strSQL = "UPDATE ODMAST SET AFACCTNO='" & v_strTO_AFACCTNO & "', SEACCTNO='" & v_strTO_AFACCTNO & v_strCODEID _
                    & "', CIACCTNO='" & v_strTO_AFACCTNO & "', BRATIO=" & v_dblBRATIO & " WHERE ORDERID='" & v_strORGORDERID & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            Else
                'Không cho phép xóa mà phải move ngược trở lại
                v_lngErrCode = ERR_OD_CANNOT_DELETE
                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                             & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                             & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                Return v_lngErrCode
            End If

            'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            ''ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function AllocateTrading(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "OD.Trans.MatchOrder", v_strErrorMessage As String

        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, v_strSQL As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE, v_lngCLEARDAY As Double
            Dim v_strCODEID, v_strACTYPE, v_strORGORDERID, v_strREFORDERID, v_strREFCUSTCD, v_strSYMBOL, v_strCUSTODYCD,
                v_strAFACCTNO, v_strCIACCTNO, v_strSEACCTNO, v_strBORS, v_strNORP, v_strAORN, v_strCONFIRM_NO, v_strMATCH_DATE, v_strCLEARCD, v_strPRICETYPE, v_strDESC As String
            Dim v_dblPRICE, v_dblQTTY, v_dblEXPRICE, v_dblEXQTTY, v_dblCostprice As Double
            Dim v_ds As DataSet
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_strBRID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXTIME As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTIME).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_blnREVERSAL As Boolean = IIf(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value = "Y", True, False)

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
                        Case "03" 'ORGORDERID
                            v_strORGORDERID = v_strVALUE
                        Case "04" 'AFACCTNO
                            v_strAFACCTNO = v_strVALUE
                        Case "05" 'CIACCTNO
                            v_strCIACCTNO = v_strVALUE
                        Case "06" 'SEACCTNO
                            v_strSEACCTNO = v_strVALUE
                        Case "07" 'REFORDERID
                            v_strREFORDERID = v_strVALUE
                        Case "08" 'REFCUSTCD
                            v_strREFCUSTCD = v_strVALUE
                        Case "09" 'CLEARCD
                            v_strCLEARCD = v_strVALUE
                        Case "80" 'CODEID
                            v_strCODEID = v_strVALUE
                        Case "81" 'SYMBOL                                       
                            v_strSYMBOL = v_strVALUE
                        Case "82" 'CUSTODYCD                                       
                            v_strCUSTODYCD = v_strVALUE
                        Case "83" 'BORS                                       
                            v_strBORS = v_strVALUE
                        Case "84" 'NORP
                            v_strNORP = v_strVALUE
                        Case "85" 'AORN
                            v_strAORN = v_strVALUE
                        Case "10" 'PRICE                                         
                            v_dblPRICE = v_dblVALUE
                        Case "11" 'QTTY
                            v_dblQTTY = v_dblVALUE
                        Case "12" 'EXPRICE          
                            v_dblEXPRICE = v_dblVALUE
                        Case "13" 'EXQTTY                                      
                            v_dblEXQTTY = v_dblVALUE
                        Case "14" 'CLEARDAY 
                            v_lngCLEARDAY = v_dblVALUE
                        Case "16" 'CONFIRM_NO
                            v_strCONFIRM_NO = v_strVALUE
                        Case "17" 'MATCH_DATE
                            v_strMATCH_DATE = v_strVALUE
                        Case "30" 'DESC                                              
                            v_strDESC = v_strVALUE
                    End Select
                End With
            Next

            If Not v_blnREVERSAL Then   'Tao lenh khop
                'Kiem tra lenh da duoc day len san chua
                v_strSQL = "SELECT * FROM OOD WHERE OODSTATUS='S' AND ORGORDERID='" & v_strORGORDERID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If Not v_ds.Tables(0).Rows.Count > 0 Then
                    'Tra ve ma loi lenh chua duoc day len san
                    v_lngErrCode = ERR_OD_SENT_DOESNOTEXIST
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If
                v_dblCostprice = 0
                'Kiem tra xem lenh nay da duoc khop hay chua
                'Neu da khop roi thi khong khop nua
                v_strSQL = "SELECT * FROM STCTRADEALLOCATION WHERE DELTD<>'Y' AND REFCONFIRMNUMBER='" & v_strCONFIRM_NO & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    'Tra ve ma loi lenh DA DUOC KHOP
                    v_lngErrCode = ERR_OD_ERROR_ORDER_MATCHED
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If

                ''Ghi nhan vao so lenh nhan IOD
                'v_strSQL = "INSERT INTO IOD (ORGORDERID,CODEID,SYMBOL,CUSTODYCD,BORS,NORP,TXDATE,TXNUM," & ControlChars.CrLf _
                '                        & "AORN,PRICE,QTTY,EXORDERID,REFCUSTCD,MATCHPRICE,MATCHQTTY,CONFIRM_NO)" & ControlChars.CrLf _
                '        & "VALUES ('" & v_strORGORDERID & "','" & v_strCODEID & "','" & v_strSYMBOL & "','" & v_strCUSTODYCD & "','" & v_strBORS & "','" & v_strNORP & "'" & ControlChars.CrLf _
                '                        & ",TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'" & v_strTXNUM & "'" & ControlChars.CrLf _
                '                        & ",'" & v_strAORN & "'," & v_dblEXPRICE & "," & v_dblEXQTTY & ",'" & v_strREFORDERID & "','" & v_strREFCUSTCD & "'," & v_dblPRICE & "," & v_dblQTTY & ",'" & v_strCONFIRM_NO & "')"
                'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                ''Tao lich thanh toan: Moi lenh khop tao 2 lich thanh toan (tien va chung khoan rieng)
                'Dim v_lngClearingTransfer As Long, v_strDUETYPE As String
                'v_strSQL = "SELECT VARVALUE FROM SYSVAR WHERE GRNAME='SYSTEM' AND VARNAME='CLEARINGTRF'"
                'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                'If Not v_ds.Tables(0).Rows.Count > 0 Then
                '    v_lngClearingTransfer = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)(0))
                'Else
                '    v_lngClearingTransfer = 0 'Mac dinh, thanh toan ngay trong ngay
                'End If

                'If v_strBORS = "B" Then 'Lenh mua
                '    'Tao lich thanh toan chung khoan
                '    v_strDUETYPE = "RS"
                '    v_strSQL = "INSERT INTO STSCHD (AUTOID,ORGORDERID,CODEID,DUETYPE,AFACCTNO,ACCTNO,REFORDERID,TXNUM,TXDATE,CLEARDAY,CLEARCD," & ControlChars.CrLf _
                '                            & "AMT,AAMT,QTTY,AQTTY,FAMT,STATUS,DELTD,COSTPRICE)" & ControlChars.CrLf _
                '            & "VALUES (SEQ_STSCHD.NEXTVAL,'" & v_strORGORDERID & "','" & v_strCODEID & "','" & v_strDUETYPE & "','" & v_strAFACCTNO & "','" & v_strSEACCTNO & "','" & v_strREFORDERID & "','" & v_strTXNUM & "'" & ControlChars.CrLf _
                '                            & ",TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')," & v_lngCLEARDAY & ",'" & v_strCLEARCD & "'" & ControlChars.CrLf _
                '                            & "," & v_dblPRICE * v_dblQTTY & ",0," & v_dblQTTY & ",0,0,'N','N'," & v_dblCostprice & ")"
                '    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                '    'Tao lich thanh toan tien
                '    v_strDUETYPE = "SM"
                '    v_strSQL = "INSERT INTO STSCHD (AUTOID,ORGORDERID,CODEID,DUETYPE,AFACCTNO,ACCTNO,REFORDERID,TXNUM,TXDATE,CLEARDAY,CLEARCD," & ControlChars.CrLf _
                '                            & "AMT,AAMT,QTTY,AQTTY,FAMT,STATUS,DELTD,COSTPRICE)" & ControlChars.CrLf _
                '            & "VALUES (SEQ_STSCHD.NEXTVAL,'" & v_strORGORDERID & "','" & v_strCODEID & "','" & v_strDUETYPE & "','" & v_strAFACCTNO & "','" & v_strCIACCTNO & "','" & v_strREFORDERID & "','" & v_strTXNUM & "'" & ControlChars.CrLf _
                '                            & ",TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')," & v_lngClearingTransfer & ",'" & v_strCLEARCD & "'" & ControlChars.CrLf _
                '                            & "," & v_dblPRICE * v_dblQTTY & ",0," & v_dblQTTY & ",0,0,'N','N'," & v_dblCostprice & ")"
                '    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                'Else 'Lenh ban
                '    'Tao lich thanh toan chung khoan
                '    v_strDUETYPE = "SS"
                '    v_strSQL = "INSERT INTO STSCHD (AUTOID,ORGORDERID,CODEID,DUETYPE,AFACCTNO,ACCTNO,REFORDERID,TXNUM,TXDATE,CLEARDAY,CLEARCD," & ControlChars.CrLf _
                '                            & "AMT,AAMT,QTTY,AQTTY,FAMT,STATUS,DELTD,COSTPRICE)" & ControlChars.CrLf _
                '            & "VALUES (SEQ_STSCHD.NEXTVAL,'" & v_strORGORDERID & "','" & v_strCODEID & "','" & v_strDUETYPE & "','" & v_strAFACCTNO & "','" & v_strSEACCTNO & "','" & v_strREFORDERID & "','" & v_strTXNUM & "'" & ControlChars.CrLf _
                '                            & ",TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')," & v_lngClearingTransfer & ",'" & v_strCLEARCD & "'" & ControlChars.CrLf _
                '                            & "," & v_dblPRICE * v_dblQTTY & ",0," & v_dblQTTY & ",0,0,'N','N'," & v_dblCostprice & ")"
                '    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                '    'Tao lich thanh toan tien
                '    v_strDUETYPE = "RM"
                '    v_strSQL = "INSERT INTO STSCHD (AUTOID,ORGORDERID,CODEID,DUETYPE,AFACCTNO,ACCTNO,REFORDERID,TXNUM,TXDATE,CLEARDAY,CLEARCD," & ControlChars.CrLf _
                '                            & "AMT,AAMT,QTTY,AQTTY,FAMT,STATUS,DELTD,COSTPRICE)" & ControlChars.CrLf _
                '            & "VALUES (SEQ_STSCHD.NEXTVAL,'" & v_strORGORDERID & "','" & v_strCODEID & "','" & v_strDUETYPE & "','" & v_strAFACCTNO & "','" & v_strCIACCTNO & "','" & v_strREFORDERID & "','" & v_strTXNUM & "'" & ControlChars.CrLf _
                '                            & ",TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')," & v_lngCLEARDAY & ",'" & v_strCLEARCD & "'" & ControlChars.CrLf _
                '                            & "," & v_dblPRICE * v_dblQTTY & ",0," & v_dblQTTY & ",0,0,'N','N'," & v_dblCostprice & ")"
                '    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                'End If

                'Kiem tra xem lenh goc da duoc khop lan nao hay chua.
                v_strSQL = "SELECT * FROM STSCHD WHERE ORGORDERID='" & v_strORGORDERID & "' AND DELTD <> 'Y'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                Dim v_blnMatched As Boolean = False
                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_blnMatched = True
                Else
                    v_blnMatched = False
                End If
                'Ghi nhan vao so lenh nhan IOD
                v_strSQL = "INSERT INTO IOD (ORGORDERID,CODEID,SYMBOL,CUSTODYCD,BORS,NORP,TXDATE,TXNUM," & ControlChars.CrLf _
                                        & "AORN,PRICE,QTTY,EXORDERID,REFCUSTCD,MATCHPRICE,MATCHQTTY,CONFIRM_NO,TXTIME)" & ControlChars.CrLf _
                        & "VALUES ('" & v_strORGORDERID & "','" & v_strCODEID & "','" & v_strSYMBOL & "','" & v_strCUSTODYCD & "','" & v_strBORS & "','" & v_strNORP & "'" & ControlChars.CrLf _
                                        & ",TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'" & v_strTXNUM & "'" & ControlChars.CrLf _
                                        & ",'" & v_strAORN & "'," & v_dblEXPRICE & "," & v_dblEXQTTY & ",'" & v_strREFORDERID & "','" & v_strREFCUSTCD & "'," & v_dblPRICE & "," & v_dblQTTY & ",'" & v_strCONFIRM_NO & "','" & v_strTXTIME & "')"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                'Tao lich thanh toan: Moi lenh khop tao 2 lich thanh toan (tien va chung khoan rieng)
                Dim v_lngClearingTransfer As Long, v_strDUETYPE As String
                v_strSQL = "SELECT VARVALUE FROM SYSVAR WHERE GRNAME='SYSTEM' AND VARNAME='CLEARINGTRF'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If Not v_ds.Tables(0).Rows.Count > 0 Then
                    v_lngClearingTransfer = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)(0))
                Else
                    v_lngClearingTransfer = 0 'Mac dinh, thanh toan ngay trong ngay
                End If

                If v_strBORS = "B" Then 'Lenh mua
                    'Tao lich thanh toan chung khoan
                    v_strDUETYPE = "RS"
                    If v_blnMatched Then
                        v_strSQL = "UPDATE STSCHD SET QTTY=QTTY+" & v_dblQTTY & ",AMT=AMT+ " & v_dblPRICE * v_dblQTTY & " WHERE ORGORDERID='" & v_strORGORDERID & "' AND DUETYPE='" & v_strDUETYPE & "'"
                    Else
                        v_strSQL = "INSERT INTO STSCHD (AUTOID,ORGORDERID,CODEID,DUETYPE,AFACCTNO,ACCTNO,REFORDERID,TXNUM,TXDATE,CLEARDAY,CLEARCD," & ControlChars.CrLf _
                                                                    & "AMT,AAMT,QTTY,AQTTY,FAMT,STATUS,DELTD,COSTPRICE)" & ControlChars.CrLf _
                                                    & "VALUES (SEQ_STSCHD.NEXTVAL,'" & v_strORGORDERID & "','" & v_strCODEID & "','" & v_strDUETYPE & "','" & v_strAFACCTNO & "','" & v_strSEACCTNO & "','" & v_strREFORDERID & "','" & v_strTXNUM & "'" & ControlChars.CrLf _
                                                                    & ",TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')," & v_lngCLEARDAY & ",'" & v_strCLEARCD & "'" & ControlChars.CrLf _
                                                                    & "," & v_dblPRICE * v_dblQTTY & ",0," & v_dblQTTY & ",0,0,'N','N'," & v_dblCostprice & ")"
                    End If
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                    'Tao lich thanh toan tien
                    v_strDUETYPE = "SM"
                    If v_blnMatched Then
                        v_strSQL = "UPDATE STSCHD SET QTTY=QTTY+" & v_dblQTTY & ",AMT=AMT+ " & v_dblPRICE * v_dblQTTY & " WHERE ORGORDERID='" & v_strORGORDERID & "' AND DUETYPE='" & v_strDUETYPE & "'"
                    Else
                        v_strSQL = "INSERT INTO STSCHD (AUTOID,ORGORDERID,CODEID,DUETYPE,AFACCTNO,ACCTNO,REFORDERID,TXNUM,TXDATE,CLEARDAY,CLEARCD," & ControlChars.CrLf _
                                                                    & "AMT,AAMT,QTTY,AQTTY,FAMT,STATUS,DELTD,COSTPRICE)" & ControlChars.CrLf _
                                                    & "VALUES (SEQ_STSCHD.NEXTVAL,'" & v_strORGORDERID & "','" & v_strCODEID & "','" & v_strDUETYPE & "','" & v_strAFACCTNO & "','" & v_strCIACCTNO & "','" & v_strREFORDERID & "','" & v_strTXNUM & "'" & ControlChars.CrLf _
                                                                    & ",TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')," & v_lngClearingTransfer & ",'" & v_strCLEARCD & "'" & ControlChars.CrLf _
                                                                    & "," & v_dblPRICE * v_dblQTTY & ",0," & v_dblQTTY & ",0,0,'N','N'," & v_dblCostprice & ")"
                    End If

                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                Else 'Lenh ban
                    'Tao lich thanh toan chung khoan
                    v_strDUETYPE = "SS"
                    If v_blnMatched Then
                        v_strSQL = "UPDATE STSCHD SET QTTY=QTTY+" & v_dblQTTY & ",AMT=AMT+ " & v_dblPRICE * v_dblQTTY & " WHERE ORGORDERID='" & v_strORGORDERID & "' AND DUETYPE='" & v_strDUETYPE & "'"
                    Else
                        v_strSQL = "INSERT INTO STSCHD (AUTOID,ORGORDERID,CODEID,DUETYPE,AFACCTNO,ACCTNO,REFORDERID,TXNUM,TXDATE,CLEARDAY,CLEARCD," & ControlChars.CrLf _
                                                & "AMT,AAMT,QTTY,AQTTY,FAMT,STATUS,DELTD,COSTPRICE)" & ControlChars.CrLf _
                                & "VALUES (SEQ_STSCHD.NEXTVAL,'" & v_strORGORDERID & "','" & v_strCODEID & "','" & v_strDUETYPE & "','" & v_strAFACCTNO & "','" & v_strSEACCTNO & "','" & v_strREFORDERID & "','" & v_strTXNUM & "'" & ControlChars.CrLf _
                                                & ",TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')," & v_lngClearingTransfer & ",'" & v_strCLEARCD & "'" & ControlChars.CrLf _
                                                & "," & v_dblPRICE * v_dblQTTY & ",0," & v_dblQTTY & ",0,0,'N','N'," & v_dblCostprice & ")"
                    End If
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                    'Tao lich thanh toan tien
                    v_strDUETYPE = "RM"
                    If v_blnMatched Then
                        v_strSQL = "UPDATE STSCHD SET QTTY=QTTY+" & v_dblQTTY & ",AMT=AMT+ " & v_dblPRICE * v_dblQTTY & " WHERE ORGORDERID='" & v_strORGORDERID & "' AND DUETYPE='" & v_strDUETYPE & "'"
                    Else
                        v_strSQL = "INSERT INTO STSCHD (AUTOID,ORGORDERID,CODEID,DUETYPE,AFACCTNO,ACCTNO,REFORDERID,TXNUM,TXDATE,CLEARDAY,CLEARCD," & ControlChars.CrLf _
                                                & "AMT,AAMT,QTTY,AQTTY,FAMT,STATUS,DELTD,COSTPRICE)" & ControlChars.CrLf _
                                & "VALUES (SEQ_STSCHD.NEXTVAL,'" & v_strORGORDERID & "','" & v_strCODEID & "','" & v_strDUETYPE & "','" & v_strAFACCTNO & "','" & v_strCIACCTNO & "','" & v_strREFORDERID & "','" & v_strTXNUM & "'" & ControlChars.CrLf _
                                                & ",TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')," & v_lngCLEARDAY & ",'" & v_strCLEARCD & "'" & ControlChars.CrLf _
                                                & "," & v_dblPRICE * v_dblQTTY & ",0," & v_dblQTTY & ",0,0,'N','N'," & v_dblCostprice & ")"
                    End If
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                End If

                'Day vao trong  STCTRADEALLOCATION
                v_strSQL = "INSERT INTO STCTRADEALLOCATION (TXDATE,TXNUM,REFCONFIRMNUMBER,ORDERID,BORS,VOLUME,PRICE,DELTD)" & ControlChars.CrLf _
                           & "VALUES (TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'" & v_strTXNUM & "','" & v_strCONFIRM_NO & "','" & v_strORGORDERID & "','" & v_strBORS & "'," & v_dblPRICE & "," & v_dblQTTY & ",'N')"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            Else    'Xoa lenh khop

                ' Check xem da xoa chua
                v_strSQL = "SELECT * FROM tllog where TXNUM='" & v_strTXNUM & "' AND TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') and deltd ='Y'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    'Tra ve ma loi lenh DA DUOC KHOP
                    v_lngErrCode = ERR_OD_CANNOT_DELETE
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If



                'Kiem tra khong cho xoa neu khach hang da thuc hien ung truoc
                v_strSQL = "SELECT AAMT, AQTTY, FAMT, STATUS FROM STSCHD WHERE DELTD<>'Y' AND TXNUM='" & v_strTXNUM & "' AND TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    'Neu da hoan tat thanh toan
                    For i = 0 To v_ds.Tables(0).Rows.Count - 1
                        If Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("STATUS"))) = "C" Then
                            v_lngErrCode = ERR_OD_STSCHD_IS_CLOSED
                            LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                         & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                         & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                            Return v_lngErrCode
                        End If
                        'Neu da duoc ung truoc
                        If gf_CorrectNumericField(v_ds.Tables(0).Rows(i)("AAMT")) +
                                gf_CorrectNumericField(v_ds.Tables(0).Rows(i)("AQTTY")) +
                                gf_CorrectNumericField(v_ds.Tables(0).Rows(i)("FAMT")) > 0 Then
                            v_lngErrCode = ERR_OD_STSCHD_ADVANCED_PAYMENT_ALREADY
                            LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                         & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                         & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                            Return v_lngErrCode
                        End If
                    Next
                End If

                v_strSQL = "UPDATE IOD SET DELTD='Y', TXTIME='" & Format(TimeOfDay, "HH:mm:ss") & "' WHERE TXNUM='" & v_strTXNUM & "' AND TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')"

                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                v_strSQL = "UPDATE STSCHD SET DELTD= (CASE WHEN QTTY=" & v_dblQTTY & " THEN 'Y' ELSE 'N' END),AMT=AMT-" & v_dblPRICE * v_dblQTTY & ",QTTY=QTTY-" & v_dblQTTY & " WHERE ORGORDERID='" & v_strORGORDERID & "' and  DELTD <>'Y'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                v_strSQL = "UPDATE STCTRADEALLOCATION SET DELTD='Y' WHERE TXNUM='" & v_strTXNUM & "' AND TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End If
            ''ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            ''ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function MatchOrder(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "OD.Trans.MatchOrder", v_strErrorMessage As String

        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, v_strSQL As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE, v_lngCLEARDAY As Double
            Dim v_strCODEID, v_strACTYPE, v_strORGORDERID, v_strREFORDERID, v_strREFCUSTCD, v_strSYMBOL, v_strCUSTODYCD,
                v_strAFACCTNO, v_strCIACCTNO, v_strSEACCTNO, v_strBORS, v_strNORP, v_strAORN, v_strCONFIRM_NO, v_strMATCH_DATE,
                v_strCLEARCD, v_strPRICETYPE, v_strDESC, v_strTRADEPLACE, v_strISTRFBUY As String
            Dim v_dblPRICE, v_dblQTTY, v_dblEXPRICE, v_dblEXQTTY, v_dblCostprice As Double
            Dim v_ds As DataSet
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_strBRID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXTIME As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTIME).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strTLTXCD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value
            Dim v_blnREVERSAL As Boolean = IIf(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value = "Y", True, False)
            Dim v_strExectype, v_strTimetype As String
            Dim v_dblMTRFDAY As Integer, v_dblTRFBUYEXT As Double = 0, v_strTRFSTATUS As String = "Y", v_dblCLEARDAY As Double = 0
            Dim v_dblRemainQtty, v_dblEXECQTTY, v_dblEXECAMT, v_dblCANCELQTTY, v_dblADJUSTQTTY As Double
            Dim v_strFOACCTNO As String
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
                        Case "03" 'ORGORDERID
                            v_strORGORDERID = v_strVALUE
                        Case "04" 'AFACCTNO
                            v_strAFACCTNO = v_strVALUE
                        Case "05" 'CIACCTNO
                            v_strCIACCTNO = v_strVALUE
                        Case "06" 'SEACCTNO
                            v_strSEACCTNO = v_strVALUE
                        Case "07" 'REFORDERID
                            v_strREFORDERID = v_strVALUE
                        Case "08" 'REFCUSTCD
                            v_strREFCUSTCD = v_strVALUE
                        Case "09" 'CLEARCD
                            v_strCLEARCD = v_strVALUE
                        Case "80" 'CODEID
                            v_strCODEID = v_strVALUE
                        Case "81" 'SYMBOL                                       
                            v_strSYMBOL = v_strVALUE
                        Case "82" 'CUSTODYCD                                       
                            v_strCUSTODYCD = v_strVALUE
                        Case "83" 'BORS                                       
                            v_strBORS = v_strVALUE
                        Case "84" 'NORP
                            v_strNORP = v_strVALUE
                        Case "85" 'AORN
                            v_strAORN = v_strVALUE
                        Case "10" 'PRICE                                         
                            v_dblPRICE = v_dblVALUE
                        Case "11" 'QTTY
                            v_dblQTTY = v_dblVALUE
                        Case "12" 'EXPRICE          
                            v_dblEXPRICE = v_dblVALUE
                        Case "13" 'EXQTTY                                      
                            v_dblEXQTTY = v_dblVALUE
                        Case "14" 'CLEARDAY 
                            v_lngCLEARDAY = v_dblVALUE
                        Case "16" 'CONFIRM_NO
                            v_strCONFIRM_NO = v_strVALUE
                        Case "17" 'MATCH_DATE
                            v_strMATCH_DATE = v_strVALUE
                        Case "18" 'TXTIME
                            If v_strTLTXCD = gc_OD_MANUAL_MATCHORDER And v_strVALUE.Length > 0 Then
                                v_strTXTIME = v_strVALUE
                            End If
                        Case "30" 'DESC                                              
                            v_strDESC = v_strVALUE
                    End Select
                End With
            Next
            'Kiem tra neu da thuc hien buoc xu ly truoc chay batch thi khong cho lam giao dich nay.
            v_strSQL = "select fn_check_after_batch A from dual"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                If v_ds.Tables(0).Rows(0)("A") > 0 Then
                    'Tra ve ma loi da thuc hien buoc xu ly truoc chay batch
                    v_lngErrCode = ERR_SA_RUN_BEFORE_BATCH
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If
            End If
            If Not v_blnREVERSAL Then   'Tao lenh khop
                'Kiem tra lenh da duoc day len san chua
                v_strSQL = "SELECT * FROM OOD WHERE OODSTATUS='S' AND ORGORDERID='" & v_strORGORDERID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If Not v_ds.Tables(0).Rows.Count > 0 Then
                    'Tra ve ma loi lenh chua duoc day len san
                    v_lngErrCode = ERR_OD_SENT_DOESNOTEXIST
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If

                'TungNT modified - get delayed buy money send cycle
                v_strSQL = "SELECT AFT.TRFBUYEXT, AFT.ISTRFBUY, OD.FOACCTNO,OD.TIMETYPE,od.REMAINQTTY,OD.EXECQTTY,OD.EXECAMT,OD.CANCELQTTY,OD.ADJUSTQTTY,TYP.MTRFDAY,OD.CLEARDAY,SB.TRADEPLACE,SB.SYMBOL FROM ODMAST OD,ODTYPE TYP,AFMAST AF, AFTYPE AFT, SBSECURITIES SB WHERE AF.ACTYPE = AFT.ACTYPE AND OD.ACTYPE = TYP.ACTYPE AND OD.CODEID=SB.CODEID AND OD.AFACCTNO =AF.ACCTNO AND OD.ORDERID='" & v_strORGORDERID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If Not v_ds.Tables(0).Rows.Count > 0 Then
                    'Tra ve ma loi lenh chua duoc day len san
                    v_lngErrCode = ERR_OD_ORDERID_NOTDOUND
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                Else
                    v_strTimetype = v_ds.Tables(0).Rows(0)("TIMETYPE")
                    v_dblMTRFDAY = v_ds.Tables(0).Rows(0)("MTRFDAY")
                    v_strTRADEPLACE = v_ds.Tables(0).Rows(0)("TRADEPLACE")
                    v_dblTRFBUYEXT = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("TRFBUYEXT"))
                    v_strISTRFBUY = v_ds.Tables(0).Rows(0)("ISTRFBUY")
                    If v_strISTRFBUY = "N" Then
                        v_dblTRFBUYEXT = 0
                    End If
                    v_dblCLEARDAY = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("CLEARDAY"))

                    If v_strTimetype = "G" Then
                        v_dblRemainQtty = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("REMAINQTTY"))
                        v_dblEXECQTTY = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("EXECQTTY"))
                        v_dblEXECAMT = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("EXECAMT"))
                        v_dblCANCELQTTY = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("CANCELQTTY"))
                        v_dblADJUSTQTTY = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("ADJUSTQTTY"))
                        v_strFOACCTNO = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("FOACCTNO"))

                        'Cap nhat tro lai voi lenh GTC
                        'v_strSQL = "UPDATE FOMAST SET REMAINQTTY=" & v_dblRemainQtty - v_dblQTTY & ",EXECQTTY=" & v_dblEXECQTTY + v_dblQTTY & ",EXECAMT=" & v_dblEXECAMT + v_dblQTTY * v_dblPRICE & ",CANCELQTTY=" & v_dblCANCELQTTY & ",AMENDQTTY=" & v_dblADJUSTQTTY & " WHERE ORGACCTNO='" & v_strORGORDERID & "'"
                        v_strSQL = "UPDATE FOMAST SET REMAINQTTY=REMAINQTTY-" & v_dblQTTY & ",EXECQTTY=EXECQTTY + " & v_dblQTTY & ",EXECAMT=EXECAMT + " & v_dblQTTY * v_dblPRICE & " WHERE ACCTNO='" & v_strFOACCTNO & "'"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    End If
                End If
                'End

                'Kiem tra xem lenh nay da duoc khop trong TRADING_RESULT hay chua
                If Len(v_strCONFIRM_NO) > 0 Then
                    If v_strBORS = "B" Then
                        v_strSQL = "SELECT * FROM TRADING_RESULT WHERE  QUANTITY-MATCHED_BQTTY>= " & v_dblQTTY & " AND " & ControlChars.CrLf _
                                    & "B_ACCOUNT_NO ='" & v_strCUSTODYCD & "' " & ControlChars.CrLf _
                                    & "AND SUBSTR(B_ACCOUNT_NO,1,3)=(select VARVALUE from SYSVAR WHERE GRNAME = 'SYSTEM' AND VARNAME = 'COMPANYCD') " & ControlChars.CrLf _
                                    & "AND SEC_CODE='" & v_strSYMBOL & "' AND CONFIRM_NO='" & v_strCONFIRM_NO & "' AND MATCH_DATE=TO_DATE('" & v_strMATCH_DATE & "','" & gc_FORMAT_DATE & "')"
                    Else
                        v_strSQL = "SELECT * FROM TRADING_RESULT WHERE  QUANTITY-MATCHED_SQTTY >= " & v_dblQTTY & " AND " & ControlChars.CrLf _
                                    & "S_ACCOUNT_NO ='" & v_strCUSTODYCD & "' " & ControlChars.CrLf _
                                    & "AND SUBSTR(S_ACCOUNT_NO,1,3)=(select VARVALUE from SYSVAR WHERE GRNAME = 'SYSTEM' AND VARNAME = 'COMPANYCD') " & ControlChars.CrLf _
                                    & "AND SEC_CODE='" & v_strSYMBOL & "' AND CONFIRM_NO='" & v_strCONFIRM_NO & "' AND MATCH_DATE=TO_DATE('" & v_strMATCH_DATE & "','" & gc_FORMAT_DATE & "')"
                    End If
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If Not v_ds.Tables(0).Rows.Count > 0 Then
                        'Tra ve ma loi lenh chua duoc day len san
                        v_lngErrCode = ERR_OD_INVALID_QTTY
                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                     & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                     & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                        Return v_lngErrCode
                    End If
                End If

                v_dblCostprice = 0

                'Cap nhat trang thai lenh duoc khop trong TRADING_RESULT
                If v_strBORS = "B" Then
                    v_strSQL = "UPDATE TRADING_RESULT SET MATCHED_BQTTY=MATCHED_BQTTY + " & v_dblQTTY & " WHERE " & ControlChars.CrLf _
                                & "B_ACCOUNT_NO ='" & v_strCUSTODYCD & "' " & ControlChars.CrLf _
                                & "AND SUBSTR(B_ACCOUNT_NO,1,3)=(select VARVALUE from SYSVAR WHERE GRNAME = 'SYSTEM' AND VARNAME = 'COMPANYCD') " & ControlChars.CrLf _
                                & "AND SEC_CODE='" & v_strSYMBOL & "' AND CONFIRM_NO='" & v_strCONFIRM_NO & "' AND MATCH_DATE=TO_DATE('" & v_strMATCH_DATE & "','" & gc_FORMAT_DATE & "')"
                Else
                    v_strSQL = "UPDATE TRADING_RESULT SET MATCHED_SQTTY=MATCHED_SQTTY + " & v_dblQTTY & " WHERE " & ControlChars.CrLf _
                                & "S_ACCOUNT_NO ='" & v_strCUSTODYCD & "' " & ControlChars.CrLf _
                                & "AND SUBSTR(S_ACCOUNT_NO,1,3)=(select VARVALUE from SYSVAR WHERE GRNAME = 'SYSTEM' AND VARNAME = 'COMPANYCD') " & ControlChars.CrLf _
                                & "AND SEC_CODE='" & v_strSYMBOL & "' AND CONFIRM_NO='" & v_strCONFIRM_NO & "' AND MATCH_DATE=TO_DATE('" & v_strMATCH_DATE & "','" & gc_FORMAT_DATE & "')"
                End If
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)



                ''Ghi nhan vao so lenh nhan IOD
                'v_strSQL = "INSERT INTO IOD (ORGORDERID,CODEID,SYMBOL,CUSTODYCD,BORS,NORP,TXDATE,TXNUM," & ControlChars.CrLf _
                '                        & "AORN,PRICE,QTTY,EXORDERID,REFCUSTCD,MATCHPRICE,MATCHQTTY,CONFIRM_NO)" & ControlChars.CrLf _
                '        & "VALUES ('" & v_strORGORDERID & "','" & v_strCODEID & "','" & v_strSYMBOL & "','" & v_strCUSTODYCD & "','" & v_strBORS & "','" & v_strNORP & "'" & ControlChars.CrLf _
                '                        & ",TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'" & v_strTXNUM & "'" & ControlChars.CrLf _
                '                        & ",'" & v_strAORN & "'," & v_dblEXPRICE & "," & v_dblEXQTTY & ",'" & v_strREFORDERID & "','" & v_strREFCUSTCD & "'," & v_dblPRICE & "," & v_dblQTTY & ",'" & v_strCONFIRM_NO & "')"
                'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                ''Tao lich thanh toan: Moi lenh khop tao 2 lich thanh toan (tien va chung khoan rieng)
                'Dim v_lngClearingTransfer As Long, v_strDUETYPE As String
                'v_strSQL = "SELECT VARVALUE FROM SYSVAR WHERE GRNAME='SYSTEM' AND VARNAME='CLEARINGTRF'"
                'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                'If Not v_ds.Tables(0).Rows.Count > 0 Then
                '    v_lngClearingTransfer = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)(0))
                'Else
                '    v_lngClearingTransfer = 0 'Mac dinh, thanh toan ngay trong ngay
                'End If

                'If v_strBORS = "B" Then 'Lenh mua
                '    'Tao lich thanh toan chung khoan
                '    v_strDUETYPE = "RS"
                '    v_strSQL = "INSERT INTO STSCHD (AUTOID,ORGORDERID,CODEID,DUETYPE,AFACCTNO,ACCTNO,REFORDERID,TXNUM,TXDATE,CLEARDAY,CLEARCD," & ControlChars.CrLf _
                '                            & "AMT,AAMT,QTTY,AQTTY,FAMT,STATUS,DELTD,COSTPRICE)" & ControlChars.CrLf _
                '            & "VALUES (SEQ_STSCHD.NEXTVAL,'" & v_strORGORDERID & "','" & v_strCODEID & "','" & v_strDUETYPE & "','" & v_strAFACCTNO & "','" & v_strSEACCTNO & "','" & v_strREFORDERID & "','" & v_strTXNUM & "'" & ControlChars.CrLf _
                '                            & ",TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')," & v_lngCLEARDAY & ",'" & v_strCLEARCD & "'" & ControlChars.CrLf _
                '                            & "," & v_dblPRICE * v_dblQTTY & ",0," & v_dblQTTY & ",0,0,'N','N'," & v_dblCostprice & ")"
                '    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                '    'Tao lich thanh toan tien
                '    v_strDUETYPE = "SM"
                '    v_strSQL = "INSERT INTO STSCHD (AUTOID,ORGORDERID,CODEID,DUETYPE,AFACCTNO,ACCTNO,REFORDERID,TXNUM,TXDATE,CLEARDAY,CLEARCD," & ControlChars.CrLf _
                '                            & "AMT,AAMT,QTTY,AQTTY,FAMT,STATUS,DELTD,COSTPRICE)" & ControlChars.CrLf _
                '            & "VALUES (SEQ_STSCHD.NEXTVAL,'" & v_strORGORDERID & "','" & v_strCODEID & "','" & v_strDUETYPE & "','" & v_strAFACCTNO & "','" & v_strCIACCTNO & "','" & v_strREFORDERID & "','" & v_strTXNUM & "'" & ControlChars.CrLf _
                '                            & ",TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')," & v_lngClearingTransfer & ",'" & v_strCLEARCD & "'" & ControlChars.CrLf _
                '                            & "," & v_dblPRICE * v_dblQTTY & ",0," & v_dblQTTY & ",0,0,'N','N'," & v_dblCostprice & ")"
                '    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                'Else 'Lenh ban
                '    'Tao lich thanh toan chung khoan
                '    v_strDUETYPE = "SS"
                '    v_strSQL = "INSERT INTO STSCHD (AUTOID,ORGORDERID,CODEID,DUETYPE,AFACCTNO,ACCTNO,REFORDERID,TXNUM,TXDATE,CLEARDAY,CLEARCD," & ControlChars.CrLf _
                '                            & "AMT,AAMT,QTTY,AQTTY,FAMT,STATUS,DELTD,COSTPRICE)" & ControlChars.CrLf _
                '            & "VALUES (SEQ_STSCHD.NEXTVAL,'" & v_strORGORDERID & "','" & v_strCODEID & "','" & v_strDUETYPE & "','" & v_strAFACCTNO & "','" & v_strSEACCTNO & "','" & v_strREFORDERID & "','" & v_strTXNUM & "'" & ControlChars.CrLf _
                '                            & ",TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')," & v_lngClearingTransfer & ",'" & v_strCLEARCD & "'" & ControlChars.CrLf _
                '                            & "," & v_dblPRICE * v_dblQTTY & ",0," & v_dblQTTY & ",0,0,'N','N'," & v_dblCostprice & ")"
                '    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                '    'Tao lich thanh toan tien
                '    v_strDUETYPE = "RM"
                '    v_strSQL = "INSERT INTO STSCHD (AUTOID,ORGORDERID,CODEID,DUETYPE,AFACCTNO,ACCTNO,REFORDERID,TXNUM,TXDATE,CLEARDAY,CLEARCD," & ControlChars.CrLf _
                '                            & "AMT,AAMT,QTTY,AQTTY,FAMT,STATUS,DELTD,COSTPRICE)" & ControlChars.CrLf _
                '            & "VALUES (SEQ_STSCHD.NEXTVAL,'" & v_strORGORDERID & "','" & v_strCODEID & "','" & v_strDUETYPE & "','" & v_strAFACCTNO & "','" & v_strCIACCTNO & "','" & v_strREFORDERID & "','" & v_strTXNUM & "'" & ControlChars.CrLf _
                '                            & ",TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')," & v_lngCLEARDAY & ",'" & v_strCLEARCD & "'" & ControlChars.CrLf _
                '                            & "," & v_dblPRICE * v_dblQTTY & ",0," & v_dblQTTY & ",0,0,'N','N'," & v_dblCostprice & ")"
                '    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                'End If

                'Kiem tra xem lenh goc da duoc khop lan nao hay chua.
                v_strSQL = "SELECT * FROM STSCHD WHERE ORGORDERID='" & v_strORGORDERID & "' AND DELTD <> 'Y'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                Dim v_blnMatched As Boolean = False
                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_blnMatched = True
                Else
                    v_blnMatched = False
                End If
                'Ghi nhan vao so lenh nhan IOD
                v_strSQL = "INSERT INTO IOD (ORGORDERID,CODEID,SYMBOL,CUSTODYCD,BORS,NORP,TXDATE,TXNUM," & ControlChars.CrLf _
                                        & "AORN,PRICE,QTTY,EXORDERID,REFCUSTCD,MATCHPRICE,MATCHQTTY,CONFIRM_NO,TXTIME)" & ControlChars.CrLf _
                        & "VALUES ('" & v_strORGORDERID & "','" & v_strCODEID & "','" & v_strSYMBOL & "','" & v_strCUSTODYCD & "','" & v_strBORS & "','" & v_strNORP & "'" & ControlChars.CrLf _
                                        & ",TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'" & v_strTXNUM & "'" & ControlChars.CrLf _
                                        & ",'" & v_strAORN & "'," & v_dblEXPRICE & "," & v_dblEXQTTY & ",'" & v_strREFORDERID & "','" & v_strREFCUSTCD & "'," & v_dblPRICE & "," & v_dblQTTY & ",'" & v_strCONFIRM_NO & "','" & v_strTXTIME & "')"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                'Tao lich thanh toan: Moi lenh khop tao 2 lich thanh toan (tien va chung khoan rieng)
                Dim v_lngClearingTransfer As Long, v_strDUETYPE As String
                v_strSQL = "SELECT VARVALUE FROM SYSVAR WHERE GRNAME='SYSTEM' AND VARNAME='CLEARINGTRF'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If Not v_ds.Tables(0).Rows.Count > 0 Then
                    v_lngClearingTransfer = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)(0))
                Else
                    v_lngClearingTransfer = 0 'Mac dinh, thanh toan ngay trong ngay
                End If

                'DungNH them phan tinh gia von.
                Dim v_objParam As StoreParameter
                Dim v_arrPara(11) As StoreParameter

                v_objParam = New StoreParameter
                v_objParam.ParamName = "PV_TXNUM"
                v_objParam.ParamValue = v_strTXNUM
                v_objParam.ParamSize = 20
                v_objParam.ParamType = "String"
                v_arrPara(0) = v_objParam

                v_objParam = New StoreParameter
                v_objParam.ParamName = "PV_TXDATE"
                v_objParam.ParamValue = v_strTXDATE
                v_objParam.ParamSize = 20
                v_objParam.ParamType = "String"
                v_arrPara(1) = v_objParam

                v_objParam = New StoreParameter
                v_objParam.ParamName = "PV_BUSDATE"
                v_objParam.ParamValue = v_strTXDATE
                v_objParam.ParamSize = 20
                v_objParam.ParamType = "String"
                v_arrPara(2) = v_objParam

                v_objParam = New StoreParameter
                v_objParam.ParamName = "PV_AFACCTNO"
                v_objParam.ParamValue = v_strAFACCTNO
                v_objParam.ParamSize = 20
                v_objParam.ParamType = "String"
                v_arrPara(3) = v_objParam

                v_objParam = New StoreParameter
                v_objParam.ParamName = "PV_SYMBOL"
                v_objParam.ParamValue = v_strCODEID
                v_objParam.ParamSize = 20
                v_objParam.ParamType = "String"
                v_arrPara(4) = v_objParam

                v_objParam = New StoreParameter
                v_objParam.ParamName = "PV_SECTYPE"
                v_objParam.ParamValue = "T"
                v_objParam.ParamSize = 5
                v_objParam.ParamType = "String"
                v_arrPara(5) = v_objParam

                If (v_strBORS = "B") Then 'lenh mua.
                    v_objParam = New StoreParameter
                    v_objParam.ParamName = "PV_PTYPE"
                    v_objParam.ParamValue = "I"
                    v_objParam.ParamSize = 5
                    v_objParam.ParamType = "String"
                    v_arrPara(6) = v_objParam
                Else 'lenh ban
                    v_objParam = New StoreParameter
                    v_objParam.ParamName = "PV_PTYPE"
                    v_objParam.ParamValue = "O"
                    v_objParam.ParamSize = 5
                    v_objParam.ParamType = "String"
                    v_arrPara(6) = v_objParam
                End If

                v_objParam = New StoreParameter
                v_objParam.ParamName = "PV_CAMASTID"
                v_objParam.ParamValue = " "
                v_objParam.ParamSize = 20
                v_objParam.ParamType = "String"
                v_arrPara(7) = v_objParam

                v_objParam = New StoreParameter
                v_objParam.ParamName = "PV_ORDERID"
                v_objParam.ParamValue = v_strORGORDERID
                v_objParam.ParamSize = 30
                v_objParam.ParamType = "String"
                v_arrPara(8) = v_objParam

                v_objParam = New StoreParameter
                v_objParam.ParamName = "PV_QTTY"
                v_objParam.ParamValue = v_dblQTTY
                v_objParam.ParamSize = 20
                v_objParam.ParamType = "Number"
                v_arrPara(9) = v_objParam

                v_objParam = New StoreParameter
                v_objParam.ParamName = "PV_COSTPRICE"
                v_objParam.ParamValue = v_dblPRICE
                v_objParam.ParamSize = 20
                v_objParam.ParamType = "Number"
                v_arrPara(10) = v_objParam

                If (v_strBORS = "B") Then 'lenh mua.
                    v_objParam = New StoreParameter
                    v_objParam.ParamName = "PV_MAPAVL"
                    v_objParam.ParamValue = "N"
                    v_objParam.ParamSize = 20
                    v_objParam.ParamType = "String"
                    v_arrPara(11) = v_objParam
                Else 'lenh ban
                    v_objParam = New StoreParameter
                    v_objParam.ParamName = "PV_MAPAVL"
                    v_objParam.ParamValue = "Y"
                    v_objParam.ParamSize = 20
                    v_objParam.ParamType = "String"
                    v_arrPara(11) = v_objParam
                End If

                v_obj.ExecuteStoredNonQuerry("SECMAST_GENERATE", v_arrPara)


                'DungNH end
                If v_strBORS = "B" Then 'Lenh mua
                    'Tao lich thanh toan chung khoan
                    v_strDUETYPE = "RS"
                    If v_blnMatched Then
                        v_strSQL = "UPDATE STSCHD SET QTTY=QTTY+" & v_dblQTTY & ",AMT=AMT+ " & v_dblPRICE * v_dblQTTY & " WHERE ORGORDERID='" & v_strORGORDERID & "' AND DUETYPE='" & v_strDUETYPE & "'"
                    Else
                        v_strSQL = "INSERT INTO STSCHD (AUTOID,ORGORDERID,CODEID,DUETYPE,AFACCTNO,ACCTNO,REFORDERID,TXNUM,TXDATE,CLEARDAY,CLEARCD," & ControlChars.CrLf _
                                                                    & "AMT,AAMT,QTTY,AQTTY,FAMT,STATUS,DELTD,COSTPRICE,CLEARDATE)" & ControlChars.CrLf _
                                                    & "VALUES (SEQ_STSCHD.NEXTVAL,'" & v_strORGORDERID & "','" & v_strCODEID & "','" & v_strDUETYPE & "','" & v_strAFACCTNO & "','" & v_strSEACCTNO & "','" & v_strREFORDERID & "','" & v_strTXNUM & "'" & ControlChars.CrLf _
                                                                    & ",TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')," & v_lngCLEARDAY & ",'" & v_strCLEARCD & "'" & ControlChars.CrLf _
                                                                    & "," & v_dblPRICE * v_dblQTTY & ",0," & v_dblQTTY & ",0,0,'N','N'," & v_dblCostprice & ",GETDUEDATE(TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'" & v_strCLEARCD & "','000'," & v_lngCLEARDAY & "))"
                    End If
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                    'DungNH them phan tinh gia von cua tu doanh
                    v_strSQL = "UPDATE SEMAST SET DCRAMT=DCRAMT+ " & v_dblPRICE * v_dblQTTY & " , DCRQTTY = DCRQTTY +" & v_dblQTTY & " WHERE afacctno = '" & v_strAFACCTNO & "' and codeid = '" & v_strCODEID & "'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                    'Tao lich thanh toan tien
                    'TungNT modified - for add delayed money send cycle
                    v_strDUETYPE = "SM"
                    If v_blnMatched Then
                        v_strSQL = "UPDATE STSCHD SET QTTY=QTTY+" & v_dblQTTY & ",AMT=AMT+ " & v_dblPRICE * v_dblQTTY & " WHERE ORGORDERID='" & v_strORGORDERID & "' AND DUETYPE='" & v_strDUETYPE & "'"
                    Else
                        v_strSQL = "INSERT INTO STSCHD (AUTOID,ORGORDERID,CODEID,DUETYPE,AFACCTNO,ACCTNO,REFORDERID,TXNUM,TXDATE,CLEARDAY,CLEARCD," & ControlChars.CrLf _
                                                                    & "AMT,AAMT,QTTY,AQTTY,FAMT,STATUS,DELTD,COSTPRICE,CLEARDATE)" & ControlChars.CrLf _
                                                    & "VALUES (SEQ_STSCHD.NEXTVAL,'" & v_strORGORDERID & "','" & v_strCODEID & "','" & v_strDUETYPE & "','" & v_strAFACCTNO & "','" & v_strCIACCTNO & "','" & v_strREFORDERID & "','" & v_strTXNUM & "'" & ControlChars.CrLf _
                                                                    & ",TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')," & Math.Min(v_lngCLEARDAY, v_dblTRFBUYEXT) & ",'" & v_strCLEARCD & "'" & ControlChars.CrLf _
                                                                    & "," & v_dblPRICE * v_dblQTTY & ",0," & v_dblQTTY & ",0,0,'N','N'," & v_dblCostprice & ",GETDUEDATE(TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'" & v_strCLEARCD & "','000'," & Math.Min(v_lngCLEARDAY, v_dblTRFBUYEXT) & ")" & ")"
                    End If
                    'end

                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                Else 'Lenh ban
                    'Tao lich thanh toan chung khoan
                    v_strDUETYPE = "SS"
                    If v_blnMatched Then
                        v_strSQL = "UPDATE STSCHD SET QTTY=QTTY+" & v_dblQTTY & ",AMT=AMT+ " & v_dblPRICE * v_dblQTTY & " WHERE ORGORDERID='" & v_strORGORDERID & "' AND DUETYPE='" & v_strDUETYPE & "'"
                    Else
                        v_strSQL = "INSERT INTO STSCHD (AUTOID,ORGORDERID,CODEID,DUETYPE,AFACCTNO,ACCTNO,REFORDERID,TXNUM,TXDATE,CLEARDAY,CLEARCD," & ControlChars.CrLf _
                                                & "AMT,AAMT,QTTY,AQTTY,FAMT,STATUS,DELTD,COSTPRICE,CLEARDATE)" & ControlChars.CrLf _
                                 & "VALUES (SEQ_STSCHD.NEXTVAL,'" & v_strORGORDERID & "','" & v_strCODEID & "','" & v_strDUETYPE & "','" & v_strAFACCTNO & "','" & v_strSEACCTNO & "','" & v_strREFORDERID & "','" & v_strTXNUM & "'" & ControlChars.CrLf _
                                                & ",TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')," & v_lngClearingTransfer & ",'" & v_strCLEARCD & "'" & ControlChars.CrLf _
                                                & "," & v_dblPRICE * v_dblQTTY & ",0," & v_dblQTTY & ",0,0,'N','N'," & v_dblCostprice & ",GETDUEDATE(TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'" & v_strCLEARCD & "','000'," & v_lngClearingTransfer & "))"
                    End If
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                    'DungNH them phan tinh gia von cua tu doanh
                    v_strSQL = "UPDATE SEMAST SET DDROUTAMT = DDROUTAMT+ " & v_dblPRICE * v_dblQTTY & " , DDROUTQTTY = DDROUTQTTY +" & v_dblQTTY & " WHERE afacctno = '" & v_strAFACCTNO & "' and codeid = '" & v_strCODEID & "'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                    'Tao lich thanh toan tien
                    v_strDUETYPE = "RM"
                    If v_blnMatched Then
                        v_strSQL = "UPDATE STSCHD SET QTTY=QTTY+" & v_dblQTTY & ",AMT=AMT+ " & v_dblPRICE * v_dblQTTY & " WHERE ORGORDERID='" & v_strORGORDERID & "' AND DUETYPE='" & v_strDUETYPE & "'"
                    Else
                        v_strSQL = "INSERT INTO STSCHD (AUTOID,ORGORDERID,CODEID,DUETYPE,AFACCTNO,ACCTNO,REFORDERID,TXNUM,TXDATE,CLEARDAY,CLEARCD," & ControlChars.CrLf _
                                                & "AMT,AAMT,QTTY,AQTTY,FAMT,STATUS,DELTD,COSTPRICE,CLEARDATE)" & ControlChars.CrLf _
                                 & "VALUES (SEQ_STSCHD.NEXTVAL,'" & v_strORGORDERID & "','" & v_strCODEID & "','" & v_strDUETYPE & "','" & v_strAFACCTNO & "','" & v_strCIACCTNO & "','" & v_strREFORDERID & "','" & v_strTXNUM & "'" & ControlChars.CrLf _
                                                & ",TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')," & v_lngCLEARDAY & ",'" & v_strCLEARCD & "'" & ControlChars.CrLf _
                                                & "," & v_dblPRICE * v_dblQTTY & ",0," & v_dblQTTY & ",0,0,'N','N'," & v_dblCostprice & ",GETDUEDATE(TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'" & v_strCLEARCD & "','000'," & v_lngCLEARDAY & "))"
                    End If
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                End If

                'GianhVG chuyen hach toan APPMAP vao day
                v_strSQL = "UPDATE ODMAST " & ControlChars.CrLf _
                            & "SET " & ControlChars.CrLf _
                            & " MATCHAMT = MATCHAMT + " & v_dblPRICE * v_dblQTTY & "," & ControlChars.CrLf _
                            & " EXECQTTY = EXECQTTY + " & v_dblQTTY & "," & ControlChars.CrLf _
                            & " REMAINQTTY = REMAINQTTY - " & v_dblQTTY & ", " & ControlChars.CrLf _
                            & " EXECAMT = EXECAMT + " & v_dblPRICE * v_dblQTTY & ", LAST_CHANGE = SYSTIMESTAMP " & ControlChars.CrLf _
                            & " WHERE ORDERID='" & v_strORGORDERID & "'"

                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                'End GianhVG chuyen hach toan APPMAP vao day

                '28/03/2016, TruongLD add, them Flag, check xem co Unhold truc tiep hay khong?
                'Mac dinh la Y: Co, --> Rieng PHS yeu cau la N: khong
                Dim v_UNHOLDREALTIME As String = "Y"
                Dim v_ErrCode As Long
                Try
                    v_ErrCode = v_obj.GetSysVar("SYSTEM", "UNHOLDREALTIME", v_UNHOLDREALTIME)
                Catch ex As Exception
                    LogError.WriteException(ex)
                    v_UNHOLDREALTIME = "N"
                End Try

                If v_UNHOLDREALTIME = "N" Then
                    Return v_lngErrCode
                End If
                'End TruongLD

                'Thuc hien giai toa lenh mua khop voi gia thap hon gia dat
                v_strSQL = "select  (case when af.corebank = 'Y' then af.corebank else af.alternateacct end) COREBANK from afmast af where ACCTNO='" & v_strAFACCTNO & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    Dim v_strCOREBANK As String = v_ds.Tables(0).Rows(0)("COREBANK").ToString().Trim().ToUpper()
                    If v_strCOREBANK = "Y" And v_strBORS = "B" And v_dblEXPRICE > v_dblPRICE Then
                        'Dim v_objParam As StoreParameter
                        Dim v_arrParam(1) As StoreParameter

                        v_objParam = New StoreParameter
                        v_objParam.ParamName = "pv_strACCTNO"
                        v_objParam.ParamValue = v_strAFACCTNO
                        v_objParam.ParamSize = 30
                        v_objParam.ParamType = GetType(System.String).Name
                        v_objParam.ParamDirection = ParameterDirection.Input
                        v_arrParam(0) = v_objParam

                        v_objParam = New StoreParameter
                        v_objParam.ParamName = "pv_strErrorCode"
                        v_objParam.ParamValue = ""
                        v_objParam.ParamSize = 100
                        v_objParam.ParamType = GetType(System.String).Name
                        v_objParam.ParamDirection = ParameterDirection.InputOutput
                        v_arrParam(1) = v_objParam
                        v_lngErrCode = v_obj.ExecuteOracleStored("cspks_rmproc.pr_RM_UnholdAccount", v_arrParam, 1)
                        'v_obj.ExecuteStoredNonQuerry("cspks_odproc.pr_RM_UnholdCancelOD", v_arrParam)
                        'v_lngErrCode = CLng(v_arrParam(2).ParamValue)
                        If v_lngErrCode <> ERR_SYSTEM_OK Then
                            LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                             & "Error code: " & v_lngErrCode & "!" & vbNewLine _
                             & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                            Return v_lngErrCode
                        End If
                    End If
                Else
                    v_lngErrCode = ERR_CI_AFACCTNO_NOTFOUND
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                     & "Error code: " & v_lngErrCode & "!" & vbNewLine _
                     & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If

            Else    'Xoa lenh khop


                v_strSQL = "SELECT * FROM ODMAST WHERE ORDERID='" & v_strORGORDERID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If Not v_ds.Tables(0).Rows.Count > 0 Then
                    'Tra ve ma loi lenh chua duoc day len san
                    v_lngErrCode = ERR_OD_ORDERID_NOTDOUND
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                Else
                    v_strTimetype = v_ds.Tables(0).Rows(0)("TIMETYPE")
                    If v_strTimetype = "G" Then
                        v_dblRemainQtty = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("REMAINQTTY"))
                        v_dblEXECQTTY = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("EXECQTTY"))
                        v_dblEXECAMT = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("EXECAMT"))
                        v_dblCANCELQTTY = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("CANCELQTTY"))
                        v_dblADJUSTQTTY = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("ADJUSTQTTY"))
                        v_strFOACCTNO = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("FOACCTNO"))
                        'Cap nhat tro lai voi lenh GTC
                        'v_strSQL = "UPDATE FOMAST SET REMAINQTTY=" & v_dblRemainQtty + v_dblQTTY & ",EXECQTTY=" & v_dblEXECQTTY - v_dblQTTY & ",EXECAMT=" & v_dblEXECAMT - v_dblQTTY * v_dblPRICE & ",CANCELQTTY=" & v_dblCANCELQTTY & ",AMENDQTTY=" & v_dblADJUSTQTTY & " WHERE ORGACCTNO='" & v_strORGORDERID & "'"
                        v_strSQL = "UPDATE FOMAST SET REMAINQTTY=REMAINQTTY - " & v_dblQTTY & ",EXECQTTY=EXECQTTY + " & v_dblQTTY & ",EXECAMT=EXECAMT+ " & v_dblQTTY * v_dblPRICE & " WHERE ACCTNO='" & v_strFOACCTNO & "'"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    End If
                End If
                'Kiem tra khong cho xoa neu khach hang da thuc hien ung truoc
                v_strSQL = "SELECT AAMT, AQTTY, FAMT, STATUS FROM STSCHD WHERE DELTD<>'Y' AND TXNUM='" & v_strTXNUM & "' AND TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    'Neu da hoan tat thanh toan
                    For i = 0 To v_ds.Tables(0).Rows.Count - 1
                        If Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("STATUS"))) = "C" Then
                            v_lngErrCode = ERR_OD_STSCHD_IS_CLOSED
                            LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                         & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                         & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                            Return v_lngErrCode
                        End If
                        'Neu da duoc ung truoc
                        If gf_CorrectNumericField(v_ds.Tables(0).Rows(i)("AAMT")) +
                                gf_CorrectNumericField(v_ds.Tables(0).Rows(i)("AQTTY")) +
                                gf_CorrectNumericField(v_ds.Tables(0).Rows(i)("FAMT")) > 0 Then
                            v_lngErrCode = ERR_OD_STSCHD_ADVANCED_PAYMENT_ALREADY
                            LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                         & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                         & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                            Return v_lngErrCode
                        End If
                    Next
                End If

                'DungNH them phan tinh gia von.
                Dim v_objParam As StoreParameter
                Dim v_arrPara(1) As StoreParameter

                v_objParam = New StoreParameter
                v_objParam.ParamName = "PV_TXNUM"
                v_objParam.ParamValue = v_strTXNUM
                v_objParam.ParamSize = 20
                v_objParam.ParamType = "String"
                v_arrPara(0) = v_objParam

                v_objParam = New StoreParameter
                v_objParam.ParamName = "PV_TXDATE"
                v_objParam.ParamValue = v_strTXDATE
                v_objParam.ParamSize = 20
                v_objParam.ParamType = "String"
                v_arrPara(1) = v_objParam

                v_obj.ExecuteStoredNonQuerry("SECNET_UN_MAP", v_arrPara)
                ' gia von cua tu doanh

                'DungNH end

                'Cap nhat trang thai lenh duoc khop trong TRADING_RESULT
                If v_strBORS = "B" Then
                    'DungNH them phan tinh gia von cua tu doanh
                    v_strSQL = "UPDATE SEMAST SET DCRAMT=DCRAMT- " & v_dblPRICE * v_dblQTTY & " , DCRQTTY = DCRQTTY -" & v_dblQTTY & " WHERE afacctno = '" & v_strAFACCTNO & "' and codeid = '" & v_strCODEID & "' and DCRQTTY > " & v_dblQTTY & " and DCRAMT > " & v_dblPRICE * v_dblQTTY
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                    v_strSQL = "UPDATE TRADING_RESULT SET MATCHED_BQTTY=MATCHED_BQTTY - " & v_dblQTTY & " WHERE " & ControlChars.CrLf _
                                & "B_ACCOUNT_NO ='" & v_strCUSTODYCD & "' " & ControlChars.CrLf _
                                & "AND SUBSTR(B_ACCOUNT_NO,1,3)=(select VARVALUE from SYSVAR WHERE GRNAME = 'SYSTEM' AND VARNAME = 'COMPANYCD') " & ControlChars.CrLf _
                                & "AND SEC_CODE='" & v_strSYMBOL & "' AND CONFIRM_NO='" & v_strCONFIRM_NO & "' AND MATCH_DATE=TO_DATE('" & v_strMATCH_DATE & "','" & gc_FORMAT_DATE & "')"
                Else
                    'DungNH them phan tinh gia von cua tu doanh
                    v_strSQL = "UPDATE SEMAST SET DDROUTAMT=DDROUTAMT- " & v_dblPRICE * v_dblQTTY & " , DDROUTQTTY = DDROUTQTTY -" & v_dblQTTY & " WHERE afacctno = '" & v_strAFACCTNO & "' and codeid = '" & v_strCODEID & "' and DDROUTQTTY > " & v_dblQTTY & " and DDROUTAMT > " & v_dblPRICE * v_dblQTTY
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                    v_strSQL = "UPDATE TRADING_RESULT SET MATCHED_SQTTY=MATCHED_SQTTY - " & v_dblQTTY & " WHERE " & ControlChars.CrLf _
                                & "S_ACCOUNT_NO ='" & v_strCUSTODYCD & "' " & ControlChars.CrLf _
                                & "AND SUBSTR(S_ACCOUNT_NO,1,3)=(select VARVALUE from SYSVAR WHERE GRNAME = 'SYSTEM' AND VARNAME = 'COMPANYCD') " & ControlChars.CrLf _
                                & "AND SEC_CODE='" & v_strSYMBOL & "' AND CONFIRM_NO='" & v_strCONFIRM_NO & "' AND MATCH_DATE=TO_DATE('" & v_strMATCH_DATE & "','" & gc_FORMAT_DATE & "')"
                End If
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                v_strSQL = "UPDATE IOD SET DELTD='Y', TXTIME='" & Format(TimeOfDay, "HH:mm:ss") & "' WHERE TXNUM='" & v_strTXNUM & "' AND TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                'v_strSQL = "UPDATE STSCHD SET DELTD='Y' WHERE TXNUM='" & v_strTXNUM & "' AND TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')"
                'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                v_strSQL = "UPDATE STSCHD SET DELTD= (CASE WHEN QTTY=" & v_dblQTTY & " THEN 'Y' ELSE 'N' END),AMT=AMT-" & v_dblPRICE * v_dblQTTY & ",QTTY=QTTY-" & v_dblQTTY & ", AUTOID=SEQ_STSCHD.NEXTVAL WHERE ORGORDERID='" & v_strORGORDERID & "' and  DELTD <>'Y'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                'GianhVG chuyen hach toan APPMAP vao day
                v_strSQL = "UPDATE ODMAST " & ControlChars.CrLf _
                           & "SET " & ControlChars.CrLf _
                           & " MATCHAMT=MATCHAMT - " & v_dblPRICE * v_dblQTTY & ", " & ControlChars.CrLf _
                           & " EXECQTTY=EXECQTTY - " & v_dblQTTY & ", " & ControlChars.CrLf _
                           & " REMAINQTTY=REMAINQTTY + " & v_dblQTTY & ", " & ControlChars.CrLf _
                           & " EXECAMT=EXECAMT - " & v_dblPRICE * v_dblQTTY & ", LAST_CHANGE = SYSTIMESTAMP " & ControlChars.CrLf _
                           & " WHERE ORDERID='" & v_strORGORDERID & "'"

                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                'End GianhVG chuyen hach toan APPMAP vao day

            End If
            ''ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            ''ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function CheckMatchOrder(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "OD.Trans.CheckMatchOrder", v_strErrorMessage As String

        Try
            Dim v_strSQL As String = String.Empty, i As Integer
            Dim v_ds As DataSet
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)

            'Kiem tra neu da thuc hien buoc xu ly truoc chay batch thi khong cho lam giao dich nay.
            v_strSQL = "select fn_check_after_batch A from dual"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                If v_ds.Tables(0).Rows(0)("A") > 0 Then
                    'Tra ve ma loi da thuc hien buoc xu ly truoc chay batch
                    v_lngErrCode = ERR_SA_RUN_BEFORE_BATCH
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If
            End If
            ''ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            ''ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function SettlementOrder(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "OD.Trans.SettlementOrder", v_strErrorMessage As String

        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, v_strSQL As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE, v_lngCLEARDAY As Double
            Dim v_strAUTOID, v_strORGORDERID As String
            Dim v_dblPRICE, v_dblQTTY, v_dblAQTTY, v_dblEXPRICE, v_dblEXQTTY, v_dblCostprice As Double
            Dim v_ds, v_dsCostprice As DataSet
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_strBRID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTLTXCD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value
            Dim v_strTXTIME As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTIME).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_blnREVERSAL As Boolean = IIf(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value = "Y", True, False)

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
                        Case "01" 'AUTOID
                            v_strAUTOID = v_dblVALUE.ToString()
                    End Select
                End With
            Next

            If Not v_blnREVERSAL Then   'Chuyen trang thai tu chua thanh toan thanh thanh toan
                v_strSQL = "SELECT STATUS,AFACCTNO,CODEID,to_char(to_date(TXDATE,'dd/mm/RRRR'),'dd/mm/RRRR') TXDATE,TXNUM,DUETYPE,AQTTY,ORGORDERID FROM STSCHD WHERE AUTOID = " & v_strAUTOID
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If Not v_ds.Tables(0).Rows.Count > 0 Then
                    v_lngErrCode = ERR_OD_STSCHD_NOTFOUND
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: Reversal." & v_blnREVERSAL.ToString() & "." & v_strAUTOID & "." & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                Else
                    If v_strTLTXCD = gc_OD_BATCH_SUNRELY_CISENd Then
                        'Xac nhan lenh da thuc giao
                        v_strSQL = "UPDATE STSCHD SET AAMT=AMT WHERE AUTOID=" & v_strAUTOID
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    Else
                        v_dblAQTTY = v_ds.Tables(0).Rows(0)("AQTTY")
                        v_strORGORDERID = v_ds.Tables(0).Rows(0)("ORGORDERID")
                        'Lay gia tri Costprice, gia von cho lenh ban. 
                        v_strSQL = "SELECT COSTPRICE FROM SEMAST WHERE  ACCTNO='" & v_ds.Tables(0).Rows(0)("AFACCTNO") & v_ds.Tables(0).Rows(0)("CODEID") & "'"
                        v_dsCostprice = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                        If Not v_dsCostprice.Tables(0).Rows.Count > 0 Then
                            'Tra ve ma loi lenh chua duoc day len san
                            v_lngErrCode = ERR_SE_AFACCTNO_NOTFOUND
                            LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                         & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                         & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                            Return v_lngErrCode
                        Else
                            v_dblCostprice = gf_CorrectNumericField(v_dsCostprice.Tables(0).Rows(0)(0))
                        End If

                        If Trim(v_ds.Tables(0).Rows(0)("STATUS")) = "C" Then
                            v_lngErrCode = ERR_OD_STSCHD_IS_CLOSED
                            LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                         & "Error code: Reversal." & v_blnREVERSAL & "." & v_strAUTOID & "." & "." & Trim(v_ds.Tables(0).Rows(0)("STATUS")) & vbNewLine _
                                         & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                            Return v_lngErrCode
                        Else
                            'Cap nhat gia von cho lenh ban.
                            If v_ds.Tables(0).Rows(0)("DUETYPE") = "SS" Then
                                v_strSQL = "UPDATE STSCHD SET COSTPRICE=" & v_dblCostprice & " WHERE TXDATE=TO_DATE('" & v_ds.Tables(0).Rows(0)("TXDATE") & "', '" & gc_FORMAT_DATE & "') AND TXNUM='" & v_ds.Tables(0).Rows(0)("TXNUM") & "'"
                                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                            End If

                            v_strSQL = "UPDATE STSCHD SET STATUS='C' WHERE STATUS<>'C' AND AUTOID=" & v_strAUTOID
                            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                        End If

                        If (v_strTLTXCD = gc_OD_SERECEIVE Or v_strTLTXCD = gc_OD_SERECEIVE_T1T2 Or v_strTLTXCD = gc_OD_BATCH_SERECEIVE) And v_dblAQTTY > 0 Then
                            'Thuc hien phong toa lai chung khoan ve giai toa chung khoan Block forward de cho phep ban.
                            Dim v_objParam As New StoreParameter
                            Dim v_arrPara(2) As StoreParameter

                            v_objParam = New StoreParameter
                            v_objParam.ParamName = "p_orderid"
                            v_objParam.ParamValue = v_strORGORDERID
                            v_objParam.ParamDirection = ParameterDirection.InputOutput
                            v_objParam.ParamSize = 32000
                            v_objParam.ParamType = GetType(System.String).Name
                            v_arrPara(0) = v_objParam

                            v_objParam = New StoreParameter
                            v_objParam.ParamName = "p_qtty"
                            v_objParam.ParamValue = v_dblAQTTY
                            v_objParam.ParamDirection = ParameterDirection.InputOutput
                            v_objParam.ParamSize = 32000
                            v_objParam.ParamType = GetType(System.Double).Name
                            v_arrPara(1) = v_objParam

                            v_objParam = New StoreParameter
                            v_objParam.ParamName = "p_err_code"
                            v_objParam.ParamDirection = ParameterDirection.Output
                            v_objParam.ParamValue = ""
                            v_objParam.ParamSize = 100
                            v_objParam.ParamType = GetType(System.String).Name
                            v_arrPara(2) = v_objParam
                            v_lngErrCode = v_obj.ExecuteOracleStored("CSPKS_DFPROC.pr_DealReceive", v_arrPara, 2)
                        End If
                        If v_lngErrCode <> ERR_SYSTEM_OK Then
                            v_lngErrCode = ERR_DF_CANNOT_BLOCK_RECEIVE_SEC
                            LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                         & "Error code: Reversal." & v_blnREVERSAL.ToString() & "." & v_strAUTOID & "." & vbNewLine _
                                         & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                            Return v_lngErrCode
                        End If
                    End If
                End If
            Else    'Chuyen trang thai tu thanh toan thanh chua thanh toan
                v_strSQL = "SELECT STATUS FROM STSCHD WHERE AUTOID=" & v_strAUTOID
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If Not v_ds.Tables(0).Rows.Count > 0 Then
                    v_lngErrCode = ERR_OD_STSCHD_NOTFOUND
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: Reversal." & v_blnREVERSAL.ToString() & "." & v_strAUTOID & "." & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                Else
                    If v_strTLTXCD = gc_OD_BATCH_SUNRELY_CISENd Then
                        'Huy Xac nhan lenh da thuc giao
                        v_strSQL = "UPDATE STSCHD SET AAMT=0 WHERE AUTOID=" & v_strAUTOID
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    Else
                        If Trim(v_ds.Tables(0).Rows(0)("STATUS")) = "N" Then
                            v_lngErrCode = ERR_OD_STSCHD_STATUSINVALID
                            LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                         & "Error code: Reversal." & v_blnREVERSAL & "." & v_strAUTOID & "." & Trim(v_ds.Tables(0).Rows(0)("STATUS")) & vbNewLine _
                                         & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                            Return v_lngErrCode
                        Else
                            v_strSQL = "Update stschd set STATUS='N' where STATUS='C' AND AUTOID=" & v_strAUTOID
                            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                        End If
                    End If
                End If
            End If

            ''ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            ''ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function DealingOTCSettlementOrder(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "OD.Trans.SettlementOrder", v_strErrorMessage As String

        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, v_strSQL As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE, v_lngCLEARDAY As Double
            Dim v_strAUTOID, v_strCODEID, v_strACTYPE, v_strORGORDERID, v_strREFORDERID, v_strREFCUSTCD, v_strSYMBOL, v_strCUSTODYCD,
                v_strAFACCTNO, v_strCIACCTNO, v_strSEACCTNO, v_strBORS, v_strNORP, v_strAORN, v_strCLEARCD, v_strPRICETYPE, v_strDESC As String
            Dim v_dblPRICE, v_dblQTTY, v_dblEXPRICE, v_dblEXQTTY, v_dblCostprice As Double
            Dim v_ds, v_dsCostprice As DataSet
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_strBRID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXTIME As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTIME).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_blnREVERSAL As Boolean = IIf(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value = "Y", True, False)

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
                        Case "03" 'ORGORDERID
                            v_strORGORDERID = v_strVALUE
                        Case "04"
                            v_strAFACCTNO = v_strVALUE
                        Case "06"
                            v_strSEACCTNO = v_strVALUE
                    End Select
                End With
            Next

            If Not v_blnREVERSAL Then   'Chuyen trang thai tu chua thanh toan thanh thanh toan
                v_strSQL = "SELECT STATUS,AFACCTNO,CODEID,to_char(to_date(TXDATE,'dd/mm/RRRR'),'dd/mm/RRRR') TXDATE,TXNUM,DUETYPE FROM STSCHD WHERE ORGORDERID = '" & v_strORGORDERID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If Not v_ds.Tables(0).Rows.Count > 0 Then
                    v_lngErrCode = ERR_OD_STSCHD_NOTFOUND
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: Reversal." & v_blnREVERSAL.ToString() & "." & v_strAUTOID & "." & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                Else

                    'Lay gia tri Costprice, gia von cho lenh ban. 
                    v_strSQL = "SELECT COSTPRICE FROM SEMAST WHERE  ACCTNO='" & v_strSEACCTNO & "'"
                    v_dsCostprice = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If Not v_dsCostprice.Tables(0).Rows.Count > 0 Then
                        'Tra ve ma loi lenh chua duoc day len san
                        v_lngErrCode = ERR_SE_AFACCTNO_NOTFOUND
                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                     & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                     & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                        Return v_lngErrCode
                    Else
                        v_dblCostprice = gf_CorrectNumericField(v_dsCostprice.Tables(0).Rows(0)(0))
                    End If

                    If Trim(v_ds.Tables(0).Rows(0)("STATUS")) = "C" Then
                        v_lngErrCode = ERR_OD_STSCHD_IS_CLOSED
                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                     & "Error code: Reversal." & v_blnREVERSAL & "." & v_strAUTOID & "." & "." & Trim(v_ds.Tables(0).Rows(0)("STATUS")) & vbNewLine _
                                     & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                        Return v_lngErrCode
                    Else
                        'Cap nhat gia von cho lenh ban.
                        If v_ds.Tables(0).Rows(0)("DUETYPE") = "SS" Or v_ds.Tables(0).Rows(0)("DUETYPE") = "RM" Then
                            v_strSQL = "UPDATE STSCHD SET COSTPRICE=" & v_dblCostprice & " WHERE ORGORDERID = '" & v_strORGORDERID & "'"
                            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                        End If

                        v_strSQL = "UPDATE STSCHD SET STATUS='C' WHERE STATUS<>'C' AND ORGORDERID = '" & v_strORGORDERID & "'"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    End If
                End If
            Else    'Chuyen trang thai tu thanh toan thanh chua thanh toan
                v_strSQL = "SELECT STATUS FROM STSCHD WHERE ORGORDERID = '" & v_strORGORDERID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If Not v_ds.Tables(0).Rows.Count > 0 Then
                    v_lngErrCode = ERR_OD_STSCHD_NOTFOUND
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: Reversal." & v_blnREVERSAL.ToString() & "." & v_strAUTOID & "." & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                Else
                    If Trim(v_ds.Tables(0).Rows(0)("STATUS")) = "N" Then
                        v_lngErrCode = ERR_OD_STSCHD_STATUSINVALID
                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                     & "Error code: Reversal." & v_blnREVERSAL & "." & v_strAUTOID & "." & Trim(v_ds.Tables(0).Rows(0)("STATUS")) & vbNewLine _
                                     & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                        Return v_lngErrCode
                    Else
                        v_strSQL = "Update stschd set STATUS='N' where ORGORDERID = '" & v_strORGORDERID & "'"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    End If
                End If
            End If
            ''ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            ''ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function CheckBeforePlaceOrder(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "OD.Trans.PlaceOrder", v_strErrorMessage As String

        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, v_strSQL As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE As Double, v_strTRADEBUYSELL As String
            Dim v_strCUSTID, v_strCODEID, v_strACTYPE, v_strAFACCTNO, v_strCIACCTNO, v_strAFSTATUS, v_strSEACCTNO, v_strCUSTODYCD, v_strTIMETYPE,
                v_strDFACCTNO, v_strVOUCHER, v_strCONSULTANT, v_strORDERID, v_strBORS,
                v_strContrafirm, v_strContrafirm2, v_strContraCus, v_strPutType,
                v_strEXPDATE, v_strEXECTYPE, v_strNORK, v_strMATCHTYPE, v_strVIA, v_strCLEARCD, v_strPRICETYPE, v_strDESC As String
            Dim v_strTRADEPLACE, v_strSYMBOL As String
            Dim v_strMarginType, v_strBUYIFOVERDUE, v_strAFTYPE, v_strSECTYPE As String
            Dim v_dblCLEARDAY, v_dblQUOTEPRICE, v_dblORDERQTTY, v_dblBRATIO, v_dblLIMITPRICE, v_dblAFADVANCELIMIT, v_dblODBALANCE As Double
            Dim v_dblODTYPETRADELIMIT, v_dblAFTRADELIMIT, v_dblALLOWBRATIO, v_dblDEFFEERATE, v_dblMarginRate As Double
            Dim v_dblSecuredRatioMin, v_dblSecuredRatioMax, v_dblTyp_Bratio, v_dblAF_Bratio, mv_dblSecureRatio, v_dblRoom, v_dblTraderID As Double
            Dim v_ds, v_dsext, v_dsOdm, v_dsSE As DataSet
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_strBRID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXTIME As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTIME).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strTLTXCD As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLTXCD), Xml.XmlAttribute).Value)
            Dim v_strPreventMinOrder As String
            Dim v_dblBuyMinAmount, v_dblSellMinAmount, v_dblCheckMinAmount As Double
            If v_blnReversal Then
                'Kiểm tra xem lệnh có được phép xoá hay không
                v_strSQL = "SELECT * FROM ODMAST WHERE TXNUM='" & v_strTXNUM & "' AND TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') AND ORSTATUS IN ('1','2','8')"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If Not v_ds.Tables(0).Rows.Count > 0 Then
                    'không thể xoá lệnh này
                    v_lngErrCode = ERR_OD_ODMAST_CANNOT_DELETE
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If
            Else
                'Doc nội dung giao dịch
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
                            Case "02" 'ACTYPE
                                v_strACTYPE = v_strVALUE
                            Case "03" 'AFACCTNO
                                v_strAFACCTNO = v_strVALUE
                            Case "20" 'TIMETYPE                                       
                                v_strTIMETYPE = v_strVALUE
                            Case "21" 'EXPDATE                                       
                                v_strEXPDATE = v_strVALUE
                            Case "22" 'EXECTYPE                                       
                                v_strEXECTYPE = v_strVALUE
                            Case "23" 'NORK                                       
                                v_strNORK = v_strVALUE
                            Case "24" 'MATCHTYPE                                       
                                v_strMATCHTYPE = v_strVALUE
                            Case "25" 'VIA                                       
                                v_strVIA = v_strVALUE
                            Case "26" 'CLEARCD                                       
                                v_strCLEARCD = v_strVALUE
                            Case "27" 'PRICETYPE                                       
                                v_strPRICETYPE = v_strVALUE
                            Case "10" 'CLEARDAY
                                v_dblCLEARDAY = v_dblVALUE
                            Case "11" 'QUOTEPRICE                                         
                                v_dblQUOTEPRICE = v_dblVALUE
                            Case "12" 'ORDERQTTY                                      
                                v_dblORDERQTTY = v_dblVALUE
                            Case "13" 'BRATIO                                      
                                v_dblBRATIO = v_dblVALUE
                            Case "14" 'LIMITPRICE
                                v_dblLIMITPRICE = v_dblVALUE
                            Case "28" 'VOUCHER
                                v_strVOUCHER = v_strVALUE
                            Case "29" 'CONSULTANT
                                v_strCONSULTANT = v_strVALUE
                            Case "04" 'ORDERID
                                v_strORDERID = v_strVALUE
                            Case "30" 'DESC                                              
                                v_strDESC = v_strVALUE
                                'TungNT added for check upcom
                            Case "31"
                                v_strContrafirm = v_strVALUE
                            Case "71"
                                v_strContraCus = v_strVALUE.Replace(".", "")
                            Case "72"
                                v_strPutType = v_strVALUE
                            Case "73"
                                v_strContrafirm2 = v_strVALUE
                            Case "95"
                                v_strDFACCTNO = v_strVALUE
                                'End
                        End Select
                    End With
                Next
                If v_strTIMETYPE = "G" And Strings.Left(v_strORDERID, 2) <> FO_PREFIXED Then
                    'Neu lenh Good till cancel thi cho qua luon
                    Return v_lngErrCode
                End If

                'Kiểm tra mã loại hình hợp đồng có tồn tại không
                v_dblALLOWBRATIO = 1
                'v_strSQL = "SELECT * FROM ODTYPE WHERE STATUS='Y' AND ACTYPE='" & v_strACTYPE & "'"
                v_strSQL = "SELECT TRADELIMIT,BRATIO,DEFFEERATE FROM ODTYPE WHERE STATUS='Y' AND ACTYPE='" & v_strACTYPE & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_dblODTYPETRADELIMIT = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("TRADELIMIT"))
                    v_dblALLOWBRATIO = v_dblALLOWBRATIO * gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("BRATIO")) / 100
                    v_dblDEFFEERATE = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("DEFFEERATE")) / 100
                Else
                    'Trả v? m�ã lỗi loại hình hợp đồng không tồn tại
                    v_lngErrCode = ERR_OD_ODTYPE_NOTFOUND
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: ERR_OD_ODTYPE_NOTFOUND", "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If

                'Kiểm tra mã hợp đồng đã tồn tại chưa
                'v_strSQL = "SELECT * FROM AFMAST WHERE ACCTNO='" & v_strAFACCTNO & "'"
                v_strSQL = "SELECT af.CUSTID,af.STATUS,af.TRADELINE,af.ADVANCELINE,af.BRATIO,af.MRIRATE,mrt.MRTYPE,MRT.BUYIFOVERDUE,af.ACTYPE AFTYPE FROM AFMAST af,AFTYPE aft, MRTYPE mrt WHERE ACCTNO='" & v_strAFACCTNO & "' AND af.ACTYPE=aft.ACTYPE and aft.MRTYPE=mrt.ACTYPE"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    'v_strCIACCTNO = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("CIACCTNO"))
                    v_strCIACCTNO = v_strAFACCTNO
                    v_strSEACCTNO = v_strAFACCTNO & v_strCODEID
                    v_strCUSTID = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("CUSTID"))
                    v_strAFSTATUS = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("STATUS"))
                    v_dblAFTRADELIMIT = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("TRADELINE"))
                    v_dblAFADVANCELIMIT = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("ADVANCELINE"))
                    v_dblMarginRate = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("MRIRATE"))
                    v_dblALLOWBRATIO = v_dblALLOWBRATIO * gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("BRATIO")) / 100
                    v_strMarginType = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("MRTYPE"))
                    v_strBUYIFOVERDUE = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("BUYIFOVERDUE"))
                    v_strAFTYPE = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("AFTYPE"))
                    If Trim(v_strAFSTATUS) <> "A" Then
                        v_lngErrCode = ERR_CF_AFMAST_STATUS_INVALIDE
                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                     & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                     & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                        Return v_lngErrCode
                    End If
                Else
                    'Trả v? m�ã lỗi không tồn tại mã hợp đồng
                    v_lngErrCode = ERR_CF_AFMAST_NOTFOUND
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If
                'Kiem tra tai khoan Margin ky han neu bi qua han va v_strBUYIFOVERDUE="N" thi khong cho dat lenh mua
                If (v_strEXECTYPE = "NB" Or v_strEXECTYPE = "BC") And v_strBUYIFOVERDUE = "N" Then
                    v_strSQL = "SELECT * FROM CIMAST CI WHERE OVAMT >0 AND CI.ACCTNO='" & v_strCIACCTNO & "'"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count > 0 Then
                        'TRA VE MA LOI NO QUA HAN KHONG DUOC MUA
                        v_lngErrCode = ERR_MR_ACCTNO_OVERDUE
                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                     & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                     & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                        Return v_lngErrCode
                    End If
                End If
                'Kiểm tra tài khoản CI có tồn tại không
                v_strSQL = "SELECT (BALANCE-ODAMT) ODBAL FROM CIMAST WHERE ACCTNO='" & v_strCIACCTNO & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If Not v_ds.Tables(0).Rows.Count > 0 Then
                    'Trả ve mã lỗi không tồn tại CIACCTNO
                    v_lngErrCode = ERR_CI_CIMAST_NOTFOUND
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                Else
                    v_dblODBALANCE = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("ODBAL"))
                End If

                'Kiểm tra tài khoản SE có tồn tại không
                v_strSQL = "SELECT ACCTNO FROM SEMAST WHERE ACCTNO='" & v_strSEACCTNO & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If Not v_ds.Tables(0).Rows.Count > 0 Then
                    'Tự động mở tài khoản SE nếu chưa có tài khoản này.
                    'v_strSQL = "INSERT INTO SEMAST (ACTYPE,CUSTID,ACCTNO,CODEID,AFACCTNO," & ControlChars.CrLf _
                    '                                           & "OPNDATE,LASTDATE,STATUS,IRTIED,IRCD," & ControlChars.CrLf _
                    '                                           & "COSTPRICE,TRADE,MORTAGE,MARGIN,NETTING," & ControlChars.CrLf _
                    '                                           & "STANDING,WITHDRAW,DEPOSIT,LOAN) " & ControlChars.CrLf _
                    '                               & "SELECT TYP.SETYPE, AF.CUSTID, '" & v_strSEACCTNO & "', '" & v_strCODEID & "','" & v_strAFACCTNO & "'," & ControlChars.CrLf _
                    '                               & "TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'A','Y','001'," & ControlChars.CrLf _
                    '                               & "0,0,0,0,0,0,0,0,0 " & ControlChars.CrLf _
                    '                               & "FROM AFMAST AF, AFTYPE TYP WHERE AF.ACTYPE=TYP.ACTYPE AND AF.ACCTNO='" & v_strAFACCTNO & "'"
                    'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                    'ThanhNV: Sua thay cau lenh Insert Select = Insert Values

                    v_strSQL = "SELECT TYP.SETYPE SETYPE, AF.CUSTID CUSTID FROM AFMAST AF, AFTYPE TYP WHERE AF.ACTYPE=TYP.ACTYPE AND AF.ACCTNO='" & v_strAFACCTNO & "'"
                    v_dsSE = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_dsSE.Tables(0).Rows.Count > 0 Then
                        v_strSECTYPE = v_dsSE.Tables(0).Rows(0)("SETYPE")
                        v_strCUSTID = v_dsSE.Tables(0).Rows(0)("CUSTID")
                        v_strSQL = "INSERT INTO SEMAST (ACTYPE,CUSTID,ACCTNO,CODEID,AFACCTNO," & ControlChars.CrLf _
                                                               & "OPNDATE,LASTDATE,STATUS,IRTIED,IRCD," & ControlChars.CrLf _
                                                               & "COSTPRICE,TRADE,MORTAGE,MARGIN,NETTING," & ControlChars.CrLf _
                                                               & "STANDING,WITHDRAW,DEPOSIT,LOAN) " & ControlChars.CrLf _
                                                   & " VALUES ('" & v_strSECTYPE & "', '" & v_strCUSTID & "', '" & v_strSEACCTNO & "', '" & v_strCODEID & "','" & v_strAFACCTNO & "'," & ControlChars.CrLf _
                                                   & "TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'A','Y','001'," & ControlChars.CrLf _
                                                   & "0,0,0,0,0,0,0,0,0 )"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    End If


                    'G?i h�àm phân hệ SE để Open SE account với mã hợp đồng đã có và CodeID
                End If

                v_strSQL = "SELECT CUSTODYCD FROM CFMAST WHERE CUSTID='" & v_strCUSTID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_strCUSTODYCD = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("CUSTODYCD"))
                Else
                    v_lngErrCode = ERR_CF_CUSTOMER_NOTFOUND
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If

                'KIEM TRA CHUNG KHOAN CO HALT HAY KHONG 
                Dim v_strHalt As String
                v_strSQL = "SELECT * FROM SBSECURITIES WHERE CODEID='" & v_strCODEID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_strHalt = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("HALT")), vbNullString, v_ds.Tables(0).Rows(0)("HALT"))
                    If v_strHalt = "Y" Then
                        v_lngErrCode = ERR_OD_CODEID_HALT
                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                     & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                     & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                        Return v_lngErrCode

                    End If
                    'Neu la san HCM kiem tra traderID co thoa man
                    v_strTRADEPLACE = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("TRADEPLACE"))
                    v_strSYMBOL = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("SYMBOL"))
                    'Kiểm tra nếu là chứng khoán niêm yết thì phải có số tài khoản lưu ký
                    If (v_strTRADEPLACE = gc_TRADEPLACE_HCMCSTc Or v_strTRADEPLACE = gc_TRADEPLACE_HNCSTc) And Len(Trim(v_strCUSTODYCD)) = 0 Then
                        v_lngErrCode = ERR_OD_LISTED_NEEDCUSTODYCD
                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                     & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                     & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                        Return v_lngErrCode
                    End If


                    If v_strTRADEPLACE = gc_TRADEPLACE_HCMCSTc And (v_strEXECTYPE = "NB" Or v_strEXECTYPE = "NS") Then

                        'Tham so ham Check TraderID
                        'FUNCTION FNC_CHECK_TRADERID( 
                        'v_Machtype IN varchar2, --P or N Putthourgh or Normal
                        'v_BORS IN varchar2,
                        'v_Via in varchar2 default null)

                        v_strSQL = "SELECT FNC_CHECK_TRADERID('" & v_strMATCHTYPE & "',substr('" & v_strEXECTYPE & "',2,1),'" & v_strVIA & "') TRD FROM DUAL"
                        v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                        v_dblTraderID = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("TRD"))
                        If v_dblTraderID = 0 Then
                            v_lngErrCode = ERR_OD_TRADERID_NOT_INVALID
                            LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                         & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                         & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                            Return v_lngErrCode
                        End If
                    End If

                    'TungNT added - Check contra sell order when place buy order (2PT)
                    If (v_strTRADEPLACE = gc_TRADEPLACE_UPCOm) And (v_strMATCHTYPE = "P") And (v_strPutType = "N") Then
                        Dim v_strCompanyFirm As String = ""
                        v_lngErrCode = v_obj.GetSysVar("SYSTEM", "COMPANYCD", v_strCompanyFirm)
                        If v_lngErrCode <> ERR_SYSTEM_OK Then
                            Return v_lngErrCode
                        End If
                        'Neu la lenh Upcom thoa thuan cung cong ty phai kiem tra
                        If v_strEXECTYPE = "NB" Then
                            If (v_strContrafirm2 = v_strCompanyFirm Or v_strContrafirm2 = "") Then
                                v_strContrafirm2 = v_strCompanyFirm
                                If v_strContraCus <> "" Then
                                    v_strSQL = "SELECT COUNT(ROWNUM) AS CNT FROM ODMAST OD,OOD OUTOD " & vbCrLf &
                                               " WHERE OD.orderid = OUTOD.orgorderid AND OD.orstatus IN ('1','2','8') " & vbCrLf &
                                               "AND OUTOD.oodstatus IN ('N','S') AND OD.orderid = '" & v_strContraCus & "' AND OD.EXECTYPE='NS' " & vbCrLf &
                                               "AND OD.matchtype='P' AND OD.CODEID='" & v_strCODEID & "' AND OD.QUOTEPRICE=" & CDbl(v_dblQUOTEPRICE) * 1000 & vbCrLf &
                                               "AND OD.ORDERQTTY=" & v_dblORDERQTTY & " AND OD.PUTTYPE='N' AND OD.CODEID IN (SELECT CODEID FROM SBSECURITIES WHERE TRADEPLACE='" & v_strTRADEPLACE & "')"
                                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                                    If Not v_ds.Tables(0).Rows(0)(0) Is DBNull.Value Then
                                        If CInt(v_ds.Tables(0).Rows(0)(0)) <= 0 Then
                                            v_lngErrCode = ERR_OD_CONTRA_ORDER_NOT_FOUND
                                        End If
                                    Else
                                        v_lngErrCode = ERR_OD_CONTRA_ORDER_NOT_FOUND
                                    End If
                                Else
                                    v_lngErrCode = ERR_OD_CONTRA_ORDER_NOT_FOUND
                                End If
                            End If
                        End If

                        If v_lngErrCode <> ERR_SYSTEM_OK Then
                            Return v_lngErrCode
                        End If
                    End If
                    'End

                    'Kiem tra neu la lenh OTC giao sau thi phai du dieu kien KQ
                    If v_strTRADEPLACE = gc_TRADEPLACE_GX And v_dblCLEARDAY >= 0 And v_strEXECTYPE = "NS" Then
                        Dim v_objRptParam As ReportParameters
                        Dim v_arrRptPara() As ReportParameters
                        ReDim v_arrRptPara(1)
                        '0. So hop dong
                        v_objRptParam = New ReportParameters
                        v_objRptParam.ParamName = "AFACCTNO"
                        v_objRptParam.ParamValue = v_strAFACCTNO
                        v_objRptParam.ParamSize = CStr(20)
                        v_objRptParam.ParamType = "VARCHAR2"
                        v_arrRptPara(0) = v_objRptParam

                        '1. Current Price String
                        v_objRptParam = New ReportParameters
                        v_objRptParam.ParamName = "INDATE"
                        v_objRptParam.ParamValue = v_strTXDATE
                        v_objRptParam.ParamSize = CStr(1000)
                        v_objRptParam.ParamType = "VARCHAR2"
                        v_arrRptPara(1) = v_objRptParam

                        v_ds = v_obj.ExecuteStoredReturnDataset("GETOTCSECINFO", v_arrRptPara)
                        Dim v_dblTradePlusT As Double = 0
                        If v_ds.Tables(0).Rows.Count > 0 Then
                            For i = 0 To v_ds.Tables(0).Rows.Count - 1
                                If v_ds.Tables(0).Rows(i)("CODEID") = v_strCODEID And v_ds.Tables(0).Rows(i)("CLEARDAY") = 0 Then
                                    v_dblTradePlusT += v_ds.Tables(0).Rows(i)("TRADE")
                                End If
                                If v_ds.Tables(0).Rows(i)("CLEARDAY") > 0 And v_ds.Tables(0).Rows(i)("CODEID") = v_strCODEID And v_ds.Tables(0).Rows(i)("CLEARCD") = v_strCLEARCD And v_ds.Tables(0).Rows(i)("CLEARDAY") = v_dblCLEARDAY Then
                                    v_dblTradePlusT += v_ds.Tables(0).Rows(i)("TRADE")
                                End If
                            Next
                        End If
                        If v_dblTradePlusT < v_dblORDERQTTY Then
                            v_lngErrCode = ERR_SE_TRADE_NOT_ENOUGHT
                            LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                         & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                         & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                            Return v_lngErrCode
                        End If
                    End If
                End If

                Dim v_dblTradeLot, v_dblTradeUnit, v_dblFloorPrice, v_dblCeilingPrice, v_dblTickSize, v_dblFromPrice, v_dblMarginMaxQuantity As Double
                v_strSQL = "SELECT INF.*, NVL(RSK.MRMAXQTTY,0) MRMAXQTTY FROM SECURITIES_INFO INF, SECURITIES_RISK RSK WHERE INF.CODEID='" & v_strCODEID & "' AND INF.CODEID=RSK.CODEID(+) "
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_dblTradeLot = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("TRADELOT"))
                    v_dblTradeUnit = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("TRADEUNIT"))
                    v_dblMarginMaxQuantity = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("MRMAXQTTY"))
                    'Kiem tra voi lenh mua sau khi dat ty le margin tai khoan khong duoc nho hon ty le ban dau
                    'hoac ty le sau khi dat phai lon hon ty le truoc khi dat
                    If (v_strEXECTYPE = "NB" Or v_strEXECTYPE = "BC") And v_strMarginType <> "N" Then
                        Dim v_dblBfAccoutMarginRate As Double
                        Dim v_dblAfAccoutMarginRate As Double
                        v_dblBfAccoutMarginRate = GetAccountMarginRate(v_strAFACCTNO, v_strTXDATE, 0, 0, 0, "")
                        v_dblAfAccoutMarginRate = GetAccountMarginRate(v_strAFACCTNO, v_strTXDATE, v_dblORDERQTTY, v_dblQUOTEPRICE * v_dblTradeUnit, 100 + v_dblDEFFEERATE * 100, v_strSYMBOL)
                        If (v_dblAfAccoutMarginRate < v_dblBfAccoutMarginRate) And v_dblAfAccoutMarginRate < v_dblMarginRate Then
                            v_lngErrCode = ERR_MR_ACCOUNT_MARGINRATE_UNDER_INITRATE
                            LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                         & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                         & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                            Return v_lngErrCode
                        End If
                    End If
                    'Kiem tra voi lenh mua sau khi dat tong khoi luong long chung khoan margin khong duoc vuot qua MRMAXQTTY
                    If (v_strEXECTYPE = "NB" Or v_strEXECTYPE = "BC") And v_strMarginType <> "N" And v_dblMarginMaxQuantity > 0 Then
                        If v_dblMarginMaxQuantity < GetSecuritiesLongPosition(v_strSYMBOL) + v_dblORDERQTTY Then
                            v_lngErrCode = ERR_MR_OVER_SYSTEM_LONG_POSSITION
                            LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                         & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                         & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                            Return v_lngErrCode
                        End If
                    End If
                    'Kiem tra chan min,max amount
                    If v_strPreventMinOrder = "Y" Then
                        v_dblBuyMinAmount = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("BMINAMT")), 0, v_ds.Tables(0).Rows(0)("BMINAMT"))
                        v_dblSellMinAmount = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("SMINAMT")), 0, v_ds.Tables(0).Rows(0)("SMINAMT"))
                        If v_strTLTXCD = gc_OD_PLACENORMALBUYORDER Or v_strTLTXCD = gc_OD_PLACENORMALBUYORDER_ADVANCEd Then 'Mua
                            v_dblCheckMinAmount = v_dblBuyMinAmount
                        Else 'Ban
                            v_dblCheckMinAmount = v_dblSellMinAmount
                        End If
                        If v_dblQUOTEPRICE * v_dblORDERQTTY * v_dblTradeUnit < v_dblCheckMinAmount Then
                            v_lngErrCode = ERR_OD_ORDER_UNDER_MIN_AMOUNT
                            LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                         & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                         & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                            Return v_lngErrCode
                        End If
                    End If

                    If v_dblTradeUnit > 0 Then
                        v_dblQUOTEPRICE = FRound(v_dblQUOTEPRICE * v_dblTradeUnit, 0)
                    End If
                    v_dblFloorPrice = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("FLOORPRICE"))
                    v_dblCeilingPrice = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("CEILINGPRICE"))
                    v_dblRoom = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("CURRENT_ROOM"))

                    'Kiem tra lenh mua nha dau tu nuoc ngoai co con ROOM
                    If v_strEXECTYPE = "NB" And (Left(Mid(v_strCUSTODYCD, 4), 1) = "F" Or Left(Mid(v_strCUSTODYCD, 4), 1) = "E") Then
                        If v_dblORDERQTTY > v_dblRoom Then
                            v_lngErrCode = ERR_OD_ROOM_NOT_ENOUGH
                            LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                         & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                         & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                            Return v_lngErrCode
                        End If
                    End If
                    'Kiểm tra khối lượng có chia hết cho TRADE_LOT không
                    If v_dblTradeLot > 0 And v_strMATCHTYPE <> "P" Then
                        If v_dblORDERQTTY Mod v_dblTradeLot <> 0 Then
                            v_lngErrCode = ERR_OD_QTTY_TRADELOT_INCORRECT
                            LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                         & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                         & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                            Return v_lngErrCode
                        End If
                    End If

                    '?�ối với lệnh LO thì giá phải nằm trong khoảng CEILING/FLOOR của bảng SECURITIES_INFO
                    If v_strPRICETYPE = "LO" Then
                        If v_dblQUOTEPRICE < v_dblFloorPrice Or v_dblQUOTEPRICE > v_dblCeilingPrice Then
                            v_lngErrCode = ERR_OD_LO_PRICE_ISNOT_FLOOR_CEILLING
                            LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                         & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                         & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                            Return v_lngErrCode
                        End If
                    End If

                    '?�ối với lệnh LO (Limit Order), SL (Stop Limit Order) thì kiểm tra ticksize của giá
                    If v_strPRICETYPE = "LO" Or v_strPRICETYPE = "SL" Then
                        v_strSQL = "SELECT FROMPRICE, TICKSIZE FROM SECURITIES_TICKSIZE WHERE CODEID='" & v_strCODEID & "' AND STATUS='Y' " _
                                                & "AND TOPRICE>=" & v_dblQUOTEPRICE & " AND FROMPRICE<=" & v_dblQUOTEPRICE
                        v_dsext = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                        If v_dsext.Tables(0).Rows.Count > 0 Then
                            v_dblTickSize = gf_CorrectNumericField(v_dsext.Tables(0).Rows(0)("TICKSIZE"))
                            v_dblFromPrice = gf_CorrectNumericField(v_dsext.Tables(0).Rows(0)("FROMPRICE"))
                            If (v_dblQUOTEPRICE - v_dblFromPrice) Mod v_dblTickSize <> 0 And v_strMATCHTYPE <> "P" Then
                                'Không đúng với TICKSIZE
                                v_lngErrCode = ERR_OD_TICKSIZE_INCOMPLIANT
                                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                             & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                             & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                                Return v_lngErrCode
                            End If
                        Else
                            'Chưa định nghĩa TICKSIZE
                            v_lngErrCode = ERR_OD_TICKSIZE_UNDEFINED
                            LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                         & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                         & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                            Return v_lngErrCode
                        End If
                    End If

                    'Kiểm tra chứng khoán có được phép vừa mua/bán trong ngày không TRADEBUYSELL của bảng SECURITIES_INFO
                    v_strTRADEBUYSELL = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("TRADEBUYSELL"))
                    If v_strTRADEBUYSELL = "N" Then

                        If v_strEXECTYPE = "NB" Or v_strEXECTYPE = "BC" Then
                            'Nếu là lệnh mua thì kiểm tra có lệnh bán nào không
                            'v_strSQL = "SELECT COUNT(*) CNT FROM ODMAST WHERE TRIM(CODEID)='" & v_strCODEID & "' AND TRIM(AFACCTNO)='" & v_strAFACCTNO & "' " _
                            '    & "AND (EXECTYPE='NS' OR EXECTYPE='SS') AND DELTD = 'N' AND EXPDATE >= TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')"
                            v_strSQL = "SELECT COUNT(*) CNT FROM ODMAST WHERE CODEID='" & v_strCODEID & "' AND AFACCTNO IN (SELECT ACCTNO FROM AFMAST WHERE CUSTID=(SELECT CUSTID FROM AFMAST WHERE ACCTNO='" & v_strAFACCTNO & "')) " _
                                    & "AND (EXECTYPE='NS' OR EXECTYPE='SS' OR EXECTYPE='MS') AND DELTD = 'N' AND EXPDATE >= TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') AND REMAINQTTY+EXECQTTY>0"
                        Else
                            'Nếu là lệnh bán thì kiểm tra có lệnh mua nào không
                            'v_strSQL = "SELECT COUNT(*) CNT FROM ODMAST WHERE TRIM(CODEID)='" & v_strCODEID & "' AND TRIM(AFACCTNO)='" & v_strAFACCTNO & "' " _
                            '    & "AND (EXECTYPE='NB' OR EXECTYPE='BC') AND DELTD = 'N' AND EXPDATE >= TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')"
                            v_strSQL = "SELECT COUNT(*) CNT FROM ODMAST WHERE CODEID='" & v_strCODEID & "' AND AFACCTNO IN (SELECT ACCTNO FROM AFMAST WHERE CUSTID=(SELECT CUSTID FROM AFMAST WHERE ACCTNO='" & v_strAFACCTNO & "')) " _
                                & "AND (EXECTYPE='NB' OR EXECTYPE='BC') AND DELTD = 'N' AND EXPDATE >= TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')  AND REMAINQTTY+EXECQTTY>0 "
                        End If

                        v_dsext = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                        If gf_CorrectNumericField(v_dsext.Tables(0).Rows(0)("CNT")) > 0 Then
                            'Báo lỗi không thể cùng mua cùng bán một chứng khoán trong cùng một ngày
                            v_lngErrCode = ERR_OD_BUYSELL_SAME_SECURITIES
                            LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                         & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                         & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                            Return v_lngErrCode
                        End If
                    End If
                Else
                    'Báo lỗi chưa khai báo SECURITIES_INFO
                    v_lngErrCode = ERR_OD_SECURITIES_INFO_UNDEFINED
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If

                'Kiểm tra các hạn mức giao dịch nếu quá hạn mức của loại hình lệnh thì checker 1 duyệt
                If v_dblQUOTEPRICE * v_dblORDERQTTY > v_dblODTYPETRADELIMIT Then
                    v_strOVRRQD = v_strOVRRQD & OVRRQS_ORDERTRADELIMIT
                    pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value = v_strOVRRQD
                End If

                'Kiểm tra nếu tỷ lệ ký quỹ nh? h�ơn qui định thì checker 1 duyệt
                If v_dblBRATIO < v_dblALLOWBRATIO Then
                    v_strOVRRQD = v_strOVRRQD & OVRRQS_ORDERSECURERATIO
                    pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value = v_strOVRRQD
                End If

                'Nếu vượt hạn mức giao dịch của hợp đồng thì checker 1 duyệt
                v_strSQL = "SELECT SUM(QUOTEPRICE*ORDERQTTY) AMT FROM ODMAST WHERE AFACCTNO='" & v_strAFACCTNO & "'"
                v_dsext = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_dblQUOTEPRICE * v_dblORDERQTTY + gf_CorrectNumericField(v_dsext.Tables(0).Rows(0)("AMT")) > v_dblAFTRADELIMIT Then
                    v_strOVRRQD = v_strOVRRQD & OVRRQS_AFTRADELIMIT
                    pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value = v_strOVRRQD
                End If

                'Kiem tra neu gia tri ung truoc vuot qua han muc ung truoc trong hop dong thi yeu cau checker duyet
                If (v_strTLTXCD = gc_OD_PLACENORMALBUYORDER Or v_strTLTXCD = gc_OD_PLACENORMALBUYORDER_ADVANCEd) And v_strMarginType = "N" Then
                    'v_strSQL = "SELECT SUM(QUOTEPRICE*REMAINQTTY*(1+TYP.DEFFEERATE/100)+EXECAMT+RLSSECURED-SECUREDAMT) ODAMT FROM ODMAST OD, ODTYPE TYP WHERE OD.ACTYPE=TYP.ACTYPE AND  OD.AFACCTNO='" & v_strAFACCTNO & "' AND OD.TXDATE= TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') AND DELTD <>'Y' AND OD.EXECTYPE IN ('NB','BC') "
                    v_strSQL = "SELECT SUM(QUOTEPRICE*REMAINQTTY*(1+TYP.DEFFEERATE/100)+EXECAMT) ODAMT FROM ODMAST OD, ODTYPE TYP WHERE OD.ACTYPE=TYP.ACTYPE AND  OD.AFACCTNO='" & v_strAFACCTNO & "' AND OD.TXDATE= TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') AND DELTD <>'Y' AND OD.EXECTYPE IN ('NB','BC') "
                    v_dsOdm = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_dblQUOTEPRICE * v_dblORDERQTTY + gf_CorrectNumericField(v_dsOdm.Tables(0).Rows(0)("ODAMT")) > v_dblAFADVANCELIMIT + v_dblODBALANCE Then
                        'v_strOVRRQD = OVRRQS_ADVANCELIMIT & v_strOVRRQD
                        'pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value = v_strOVRRQD
                        v_lngErrCode = ERR_OD_ADVANCELINE_OVER_LIMIT
                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                     & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                     & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                        Return v_lngErrCode
                    End If
                End If

                'Kiểm tra các đi?u ki�ện v? duy�ệt giao dịch
                'Xử lý trả v? nguy�ên nhân duyệt
                If Len(Trim(Replace(v_strOVRRQD, OVRRQS_CHECKER_CONTROL, vbNullString))) > 0 And Len(v_strCHKID) = 0 Then
                    v_lngErrCode = ERR_SA_CHECKER1_OVR
                Else
                    If InStr(v_strOVRRQD, OVRRQS_CHECKER_CONTROL) > 0 And Len(v_strOFFID) = 0 Then
                        v_lngErrCode = ERR_SA_CHECKER2_OVR
                    End If
                End If
                If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode

                ''ContextUtil.SetComplete()
            End If

            Return v_lngErrCode
        Catch ex As Exception
            ''ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
    Private Function GetAccountMarginRate(ByVal f_strAcctno As String, ByVal f_in_date As String, ByVal f_quantity As Double, ByVal f_price As Double, ByVal f_ratio As Double, ByVal f_symbol As String) As Double
        Try
            Dim v_ds, v_dsext, v_dsOdm As DataSet
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)

            Dim v_objRptParam As ReportParameters
            Dim v_arrRptPara() As ReportParameters
            ReDim v_arrRptPara(6)
            '0. So hop dong
            v_objRptParam = New ReportParameters
            v_objRptParam.ParamName = "f_acctno"
            v_objRptParam.ParamValue = f_strAcctno
            v_objRptParam.ParamSize = 20
            v_objRptParam.ParamType = "VARCHAR2"
            v_arrRptPara(0) = v_objRptParam

            '1. In Date
            v_objRptParam = New ReportParameters
            v_objRptParam.ParamName = "f_in_date"
            v_objRptParam.ParamValue = f_in_date
            v_objRptParam.ParamSize = 100
            v_objRptParam.ParamType = "VARCHAR2"
            v_arrRptPara(1) = v_objRptParam
            '2. f_quantity
            v_objRptParam = New ReportParameters
            v_objRptParam.ParamName = "f_quantity"
            v_objRptParam.ParamValue = f_quantity
            v_objRptParam.ParamSize = 20
            v_objRptParam.ParamType = "NUMBER"
            v_arrRptPara(2) = v_objRptParam
            '3. f_price
            v_objRptParam = New ReportParameters
            v_objRptParam.ParamName = "f_price"
            v_objRptParam.ParamValue = f_price
            v_objRptParam.ParamSize = 20
            v_objRptParam.ParamType = "NUMBER"
            v_arrRptPara(3) = v_objRptParam
            '4. f_ratio
            v_objRptParam = New ReportParameters
            v_objRptParam.ParamName = "f_ratio"
            v_objRptParam.ParamValue = f_ratio
            v_objRptParam.ParamSize = 20
            v_objRptParam.ParamType = "NUMBER"
            v_arrRptPara(4) = v_objRptParam
            '5. f_symbol
            v_objRptParam = New ReportParameters
            v_objRptParam.ParamName = "f_symbol"
            v_objRptParam.ParamValue = f_symbol
            v_objRptParam.ParamSize = 20
            v_objRptParam.ParamType = "VARCHAR2"
            v_arrRptPara(5) = v_objRptParam
            '6. f_symbol
            v_objRptParam = New ReportParameters
            v_objRptParam.ParamName = "f_rmacctno"
            v_objRptParam.ParamValue = ""
            v_objRptParam.ParamSize = 200
            v_objRptParam.ParamType = "VARCHAR2"
            v_arrRptPara(6) = v_objRptParam

            v_ds = v_obj.ExecuteStoredReturnDataset("GETACCOUNTMARGINRATE", v_arrRptPara)
            If v_ds.Tables(0).Rows.Count > 0 Then
                Return CDbl(v_ds.Tables(0).Rows(0)("MARGINRATE"))
            Else
                Return 0
            End If
        Catch ex As Exception

        End Try

    End Function

    Private Function GetSecuritiesLongPosition(ByVal f_symbol As String) As Double
        Try
            Dim v_ds, v_dsext, v_dsOdm As DataSet
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)

            Dim v_objRptParam As ReportParameters
            Dim v_arrRptPara() As ReportParameters
            ReDim v_arrRptPara(0)
            '0. chung khoan
            v_objRptParam = New ReportParameters
            v_objRptParam.ParamName = "f_symbol"
            v_objRptParam.ParamValue = f_symbol
            v_objRptParam.ParamSize = 20
            v_objRptParam.ParamType = "VARCHAR2"
            v_arrRptPara(0) = v_objRptParam
            v_ds = v_obj.ExecuteStoredReturnDataset("GETMARGINQUANTITYBYSYMBOL", v_arrRptPara)
            If v_ds.Tables(0).Rows.Count > 0 Then
                Return CDbl(v_ds.Tables(0).Rows(0)("SEQTTY"))
            Else
                Return 0
            End If
        Catch ex As Exception

        End Try
    End Function

    Private Function CheckBeforeCancelOrder(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "OD.Trans.CheckBeforeSettlementOrder", v_strErrorMessage As String

        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, v_strSQL As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE, v_lngCLEARDAY As Double
            Dim v_strAUTOID, v_strCODEID, v_strACTYPE, v_strORGORDERID, v_strREFORDERID, v_strREFCUSTCD, v_strSYMBOL, v_strCUSTODYCD,
                v_strAFACCTNO, v_strCIACCTNO, v_strSEACCTNO, v_strBORS, v_strNORP, v_strAORN, v_strCLEARCD, v_strPRICETYPE, v_strDESC,
                v_strEXECTYPE, v_strPUTTYPE, v_strMATCHTYPE, v_strContraCus, v_strContrafirm2, v_strOrgExectype As String
            Dim v_dblPRICE, v_dblQTTY, v_dblEXPRICE, v_dblEXQTTY As Double
            Dim v_ds As DataSet
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_strBRID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXTIME As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTIME).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_blnREVERSAL As Boolean = IIf(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value = "Y", True, False)
            Dim v_strTLTXCD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value

            Dim v_strORDERID As String, v_strTRADEPLACE As String, v_strTIMETYPE As String
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
                        Case "01" 'CODEID
                            v_strCODEID = v_strVALUE
                        Case "12"
                            v_dblQTTY = v_dblVALUE
                        Case "08"
                            v_strORGORDERID = v_strVALUE
                        Case "24" 'MATCHTYPE                                       
                            v_strMATCHTYPE = v_strVALUE
                        Case "22" 'EXECTYPE                                       
                            v_strEXECTYPE = v_strVALUE
                            'TungNT added for check upcom
                        Case "71"
                            v_strContraCus = v_strVALUE.Replace(".", "")
                        Case "72"
                            v_strPUTTYPE = v_strVALUE
                        Case "73"
                            v_strContrafirm2 = v_strVALUE
                            'End
                    End Select
                End With
            Next

            v_strSQL = "SELECT * FROM SBSECURITIES WHERE TRIM(CODEID)='" & v_strCODEID & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then

                v_strTRADEPLACE = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("TRADEPLACE"))

                'Check for upcom modified - cancel - Modified by TungNT
                If v_strTRADEPLACE = gc_TRADEPLACE_UPCOm And (v_strTLTXCD = "8882" Or v_strTLTXCD = "8883" Or v_strTLTXCD = "8884" Or v_strTLTXCD = "8885") And v_strMATCHTYPE = "P" Then
                    'Cac lenh da khop khong cho phep huy sua
                    v_strSQL = "SELECT COUNT(*) AS CNT,MAX(PUTTYPE) AS PUTTYPE FROM ODMAST WHERE ORDERID='" & v_strORGORDERID & "' AND MATCHTYPE = 'P' AND DELTD='N' AND EXECQTTY=0 AND REMAINQTTY>0 AND CODEID IN (SELECT CODEID FROM SBSECURITIES WHERE TRADEPLACE='" & v_strTRADEPLACE & "')"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If Convert.ToInt32(v_ds.Tables(0).Rows(0)(0)) <= 0 Then
                        v_lngErrCode = ERR_OD_ERROR_ORDER_MATCHED
                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                                         & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                                         & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                        Return v_lngErrCode
                    Else
                        v_strPUTTYPE = CStr(v_ds.Tables(0).Rows(0)("PUTTYPE"))
                    End If
                    'Cac lenh view o man hinh send thi ko cho huy sua (trang thai OOD=B)
                    v_strSQL = "SELECT COUNT(OOD.orgorderid) AS CNT FROM OOD,ODMAST OD WHERE OD.orderid = OOD.orgorderid AND OD.orderid ='" & v_strORGORDERID & "' AND OOD.oodstatus IN ('N','S') AND OD.deltd='N' AND OOD.DELTD='N'"
                    If Convert.ToInt32(v_ds.Tables(0).Rows(0)(0)) <= 0 Then
                        v_lngErrCode = ERR_OD_ERROR_ORDER_BLOCKED
                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                                         & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                                         & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                        Return v_lngErrCode
                    End If

                    If v_strPUTTYPE = "N" Then
                        'Kiem tra neu la upcom thoa thuan thi check ko cho phep sua, chi cho phep huy
                        If (v_strTLTXCD = "8884" Or v_strTLTXCD = "8885") Then
                            v_lngErrCode = ERR_OD_ERROR_UPCOM_CANNOT_AMEND
                            LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                                         & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                                         & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                            Return v_lngErrCode
                        End If
                        'Check phai huy lenh mua truoc,huy lenh ban sau doi voi lenh thoa thuan cung cong ty
                        Dim v_strCompanyFirm As String = ""
                        v_lngErrCode = v_obj.GetSysVar("SYSTEM", "COMPANYCD", v_strCompanyFirm)
                        If v_lngErrCode <> ERR_SYSTEM_OK Then
                            LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                                         & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                                         & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                            Return v_lngErrCode
                        End If

                        'Lay thong tin firm2 cua lenh goc
                        v_strSQL = "SELECT EXECTYPE,CONTRAFRM,CONTRAORDERID FROM ODMAST WHERE ORDERID='" & v_strORGORDERID & "' AND ROWNUM<=1"
                        v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                        If v_ds.Tables(0).Rows.Count > 0 Then
                            v_strContrafirm2 = CStr(IIf(v_ds.Tables(0).Rows(0)("CONTRAFRM") Is DBNull.Value, "", v_ds.Tables(0).Rows(0)("CONTRAFRM")))
                            v_strContraCus = CStr(IIf(v_ds.Tables(0).Rows(0)("CONTRAORDERID") Is DBNull.Value, "", v_ds.Tables(0).Rows(0)("CONTRAORDERID")))
                            v_strOrgExectype = CStr(v_ds.Tables(0).Rows(0)("EXECTYPE"))
                        End If

                        'Neu la lenh cung cong ty phai kiem tra huy lenh mua truoc
                        If (v_strContrafirm2 = v_strCompanyFirm Or v_strContrafirm2 = "") Then
                            If (v_strOrgExectype = "NS") Then
                                v_strSQL = "SELECT ORDERID,EXECQTTY,REMAINQTTY,ORDERQTTY,CANCELQTTY,ADJUSTQTTY,REJECTQTTY FROM ODMAST WHERE CONTRAORDERID='" & v_strORGORDERID & "'"
                                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                                If (v_ds.Tables(0).Rows.Count > 0) Then
                                    If CInt(v_ds.Tables(0).Rows(0)("REMAINQTTY")) > 0 Or CInt(v_ds.Tables(0).Rows(0)("EXECQTTY")) > 0 Then
                                        v_lngErrCode = ERR_OD_ERROR_UPCOM_CANCEL_BUY_FIRST
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
                'End

                v_strSQL = "SELECT VARVALUE FROM SYSVAR WHERE GRNAME ='SYSTEM' AND VARNAME ='HOSEGW'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                v_strVALUE = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("VARVALUE"))
                If v_strTRADEPLACE = gc_TRADEPLACE_HCMCSTc And v_strVALUE = "Y" And (v_strTLTXCD = "8885" Or v_strTLTXCD = "8884") Then
                    v_lngErrCode = ERR_OD_TRADEPLACE_HOSE_NOT_AMEND
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode

                End If
            Else
                v_lngErrCode = ERR_OD_ORDER_NOT_FOUND
                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                Return v_lngErrCode
            End If

            ''ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            ''ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function



    Private Function CheckBeforeSettlementOrder(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "OD.Trans.CheckBeforeSettlementOrder", v_strErrorMessage As String

        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, v_strSQL As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE, v_lngCLEARDAY As Double
            Dim v_strAUTOID, v_strCODEID, v_strACTYPE, v_strORGORDERID, v_strREFORDERID, v_strREFCUSTCD, v_strSYMBOL, v_strCUSTODYCD,
                v_strAFACCTNO, v_strCIACCTNO, v_strSEACCTNO, v_strBORS, v_strNORP, v_strAORN, v_strCLEARCD, v_strPRICETYPE, v_strDESC As String
            Dim v_dblPRICE, v_dblQTTY, v_dblEXPRICE, v_dblEXQTTY As Double
            Dim v_ds As DataSet
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_strBRID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXTIME As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTIME).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_blnREVERSAL As Boolean = IIf(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value = "Y", True, False)
            Dim v_dblFEE As Double, v_strORDERID As String
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
                        Case "01" 'AUTOID
                            v_strAUTOID = v_dblVALUE.ToString()
                        Case "12"
                            v_dblFEE = v_dblVALUE
                        Case "03"
                            v_strORDERID = v_strVALUE
                    End Select
                End With
            Next

            v_strSQL = "SELECT *  FROM ODMAST WHERE ORDERID = '" & v_strORDERID & "' AND FEEACR-FEEAMT-1<" & v_dblFEE
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If Not v_ds.Tables(0).Rows.Count > 0 Then
                v_lngErrCode = ERR_OD_INVALID_FEEAMT
                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                             & "Error code: Reversal." & v_blnREVERSAL.ToString() & "." & v_strAUTOID & "." & vbNewLine _
                             & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                Return v_lngErrCode
            End If

            ''ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            ''ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function UpdateOodStatus(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "OD.Trans.UpdateOodStatus", v_strErrorMessage As String

        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, v_strSQL As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE As Double
            Dim v_strORGORDERID As String
            Dim v_ds As DataSet
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_strBRID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXTIME As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTIME).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_blnREVERSAL As Boolean = IIf(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value = "Y", True, False)

            '?�?c n�ội dung giao dịch
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
                        Case "03" 'ORGORDERID
                            v_strORGORDERID = v_strVALUE
                    End Select
                End With
            Next
            'Update trang thai chua send: N
            v_strSQL = "DELETE FROM ODQUEUE WHERE ORGORDERID ='" & v_strORGORDERID & "'"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            v_strSQL = "UPDATE OOD SET OODSTATUS='N' WHERE ORGORDERID='" & v_strORGORDERID & "'"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            v_strSQL = "DELETE ORDERMAP WHERE ORGORDERID='" & v_strORGORDERID & "'"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            v_strSQL = "DELETE ORDERMAP_HA WHERE ORGORDERID='" & v_strORGORDERID & "'"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            Return v_lngErrCode
        Catch ex As Exception
            ''ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
    Private Function EditOrder(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "OD.Trans.EditOrder", v_strErrorMessage As String
        Dim v_obj As New DataAccess
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQL As String
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String
            Dim v_dblVALUE As Double
            Dim v_strORGORDERID As String, v_dblEditQtty As Double
            Dim v_strAfacctno As String, v_strDesAcctno As String, v_strRefcomfirmNumber As String
            Dim v_strBRID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXTIME As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTIME).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_blnREVERSAL As Boolean = IIf(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value = "Y", True, False)
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i As Integer = 0 To v_nodeList.Count - 1
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
                        Case "02"
                            v_strAfacctno = v_strVALUE
                        Case "03" 'ORGORDERID
                            v_strORGORDERID = v_strVALUE
                        Case "06"
                            v_dblEditQtty = v_dblVALUE
                        Case "07"
                            v_strDesAcctno = v_strVALUE
                        Case "08"
                            v_strRefcomfirmNumber = v_strVALUE
                    End Select
                End With
            Next
            Dim v_objParam As StoreParameter
            Dim v_arrParam(5) As StoreParameter

            v_objParam = New StoreParameter
            v_objParam.ParamName = "ORGORDERID"
            v_objParam.ParamValue = v_strORGORDERID
            v_objParam.ParamSize = 30
            v_objParam.ParamType = "VARCHAR2"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_arrParam(0) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "REFCONFIRMNUMBER"
            v_objParam.ParamValue = v_strRefcomfirmNumber
            v_objParam.ParamSize = 30
            v_objParam.ParamType = "VARCHAR2"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_arrParam(1) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "EDITEDQTTY"
            v_objParam.ParamValue = v_dblEditQtty
            v_objParam.ParamSize = 10
            v_objParam.ParamType = "NUMBER"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_arrParam(2) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "AFACCTNO"
            v_objParam.ParamValue = v_strAfacctno
            v_objParam.ParamSize = 20
            v_objParam.ParamType = "VARCHAR2"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_arrParam(3) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "DESACCTNO"
            v_objParam.ParamValue = v_strDesAcctno
            v_objParam.ParamSize = 20
            v_objParam.ParamType = "VARCHAR2"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_arrParam(4) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "V_ERRCODE"
            v_objParam.ParamValue = 0
            v_objParam.ParamSize = 30
            v_objParam.ParamType = "VARCHAR2"
            v_objParam.ParamDirection = ParameterDirection.InputOutput
            v_arrParam(5) = v_objParam
            v_obj.NewDBInstance(gc_MODULE_HOST)
            If Not v_blnREVERSAL Then
                v_obj.ExecuteStoredNonQuerry("txpks_editorder.edit_order", v_arrParam)
                v_lngErrCode = CLng(v_arrParam(5).ParamValue)
            End If
            v_obj = Nothing
            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            v_obj = Nothing
            Throw ex
        End Try
    End Function



#End Region

End Class
