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
        ATTR_MODULE = "SE"
    End Sub

#Region " Implement functions"
    Overrides Function txImpUpdate(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        'XÃ¡c Ä‘á»‹nh mÃ£ giao dá»‹ch tÆ°Æ¡ng á»©ng
        Dim v_lngErrorCode As Long
        Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
        Dim v_strTLTXCD As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLTXCD), Xml.XmlAttribute).Value)
        Select Case v_strTLTXCD
            'HaiLT bo doan nay
            'Case gc_CA_EXECUTE_SE_CAEVENT
            '    v_lngErrorCode = DoPitLogTrans(pv_xmlDocument)
            'End of HaiLT bo doan nay
            Case gc_FN_REGISTER_SECURITIES, gc_FN_UNREGISTER_SECURITIES
                v_lngErrorCode = Register_UnRegister(pv_xmlDocument)
            Case gc_SE_WITHDRAW
                v_lngErrorCode = withdrawSecurities(pv_xmlDocument)
            Case gc_SE_SURELY_WITHDRAW
                v_lngErrorCode = withdrawSurelySecurities(pv_xmlDocument)
                'Case gc_SE_CONFIRM_WITHDRAW
                '    v_lngErrorCode = confirmWithdrawSecurities(pv_xmlDocument)
            Case gc_SE_REVERT_WITHDRAW
                v_lngErrorCode = revertWithdrawSecurities(pv_xmlDocument)
                'Case gc_SE_REVERT_2292
                '    v_lngErrorCode = revertConfirmWithdrawSecurities(pv_xmlDocument)
            Case gc_SE_RESEVERSE_MORTAGE_RELEASE
                v_lngErrorCode = reserveMortageSecurities(pv_xmlDocument)
            Case gc_SE_BLOCK
                v_lngErrorCode = BlockSecurities(pv_xmlDocument)
            Case gc_SE_UNBLOCK
                'Check before commit deleting
                v_lngErrorCode = SecuritiesDepositRevert(pv_xmlDocument)
                v_lngErrorCode = UnBlockSecurities(pv_xmlDocument)
            Case gc_OD_TRADE_LOT_RETAIL
                v_lngErrorCode = BlockSecuritiesRetail(pv_xmlDocument)
            Case gc_OD_MATCH_TRADE_LOT_RETAIL
                v_lngErrorCode = UnBlockSecuritiesRetail(pv_xmlDocument)
            Case gc_SE_DEPOSIT
                v_lngErrorCode = DepositSecurities(pv_xmlDocument)
            Case gc_SE_REVERT_DEPOSIT
                v_lngErrorCode = RevertDepositSecurities(pv_xmlDocument)
            Case gc_SE_SEND_DEPOSIT
                v_lngErrorCode = SendDepositSecurities(pv_xmlDocument)
            Case gc_SE_REVERT_SEND_DEPOSIT
                v_lngErrorCode = RevertSendDepositSecurities(pv_xmlDocument)
            Case gc_SE_COMPLETE_DEPOSIT
                'Check before commit deleting
                v_lngErrorCode = SecuritiesDepositRevert(pv_xmlDocument)

                v_lngErrorCode = CompleteDepositSecurities(pv_xmlDocument)
            Case gc_SE_ADJUST_COSTPRICE
                v_lngErrorCode = AdjustCostprice(pv_xmlDocument)
            Case gc_SE_MORTAGE_RELEASE, gc_SE_MORTAGE_RELEASE_TOSELL, gc_SE_TRF_SE2SE, gc_SE_INWARD_SETRF
                'Check before commit deleting
                v_lngErrorCode = SecuritiesDepositRevert(pv_xmlDocument)
            Case gc_SE_SEND_DTOCLOSE
                v_lngErrorCode = TransferDTOCLOSE(pv_xmlDocument)
            Case gc_SE_COMPLATE_SDTOCLOSE
                v_lngErrorCode = CompleteSDtoclose(pv_xmlDocument)
            Case gc_SE_SEND_RETAIL
                v_lngErrorCode = SendSecuritiesRetail(pv_xmlDocument)
            Case gc_SE_CANCEL_SEND_RETAIL
                v_lngErrorCode = CancelSendSecuritiesRetail(pv_xmlDocument)
            Case gc_SE_CANCEL_RETAIL
                v_lngErrorCode = CancelSecuritiesRetail(pv_xmlDocument)

        End Select
        'Tráº£ vá»? mÃ£ lá»—i
        Return v_lngErrorCode
    End Function

    Overrides Function txImpCheck(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrorCode As Long
        Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
        Dim v_strTLTXCD As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLTXCD), Xml.XmlAttribute).Value)
        Select Case v_strTLTXCD
            Case gc_CI_TRANSFER2BANK
                'Chuyển khoản ra ngân hàng
                v_lngErrorCode = CHECKGenRemittanceTrans(pv_xmlDocument)
            Case gc_SE_COMPLATE_SDTOCLOSE
                v_lngErrorCode = CheckCI(pv_xmlDocument)
                'Case "2200", "2201"
                '    v_lngErrorCode = CheckSEStatus(pv_xmlDocument)
            Case gc_SE_COMPLETE_TOCLOSE
                v_lngErrorCode = CheckCIBalance(pv_xmlDocument)
            Case gc_SE_OTCPRIVATE_TRANSFER
                v_lngErrorCode = CheckOTCPrivateTransfer(pv_xmlDocument)
                'Phuong add
            Case gc_SE_UNBLOCK
                v_lngErrorCode = CheckUnBlockSecurities(pv_xmlDocument)
            Case gc_OD_TRADE_LOT_RETAIL
                v_lngErrorCode = CheckTradeLotRetail(pv_xmlDocument)
            Case gc_SE_REVERT_DEPOSIT, gc_SE_REVERT_SEND_DEPOSIT
                v_lngErrorCode = CheckRevertDeposit(pv_xmlDocument)
           
        End Select
        Return v_lngErrorCode

    End Function

    Overrides Function txImpMisc(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        'XÃ¡c Ä‘á»‹nh mÃ£ giao dá»‹ch tÆ°Æ¡ng á»©ng
        Dim v_lngErrorCode As Long
        Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
        Dim v_strTLTXCD As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLTXCD), Xml.XmlAttribute).Value)
        Select Case v_strTLTXCD
            Case gc_SE_OPENACCOUNT
                v_lngErrorCode = OpenAccount(pv_xmlDocument)
            Case gc_SE_ACCOUNTINQUIRY
                v_lngErrorCode = InquiryAccount(pv_xmlDocument)
            Case gc_SE_ACCOUNTHISTORY
                v_lngErrorCode = HistoryAccount(pv_xmlDocument)
            Case gc_SE_COSTPRICE_HISTORY
                v_lngErrorCode = HistoryCostprice(pv_xmlDocument)

        End Select
        'Tráº£ vá»? mÃ£ lá»—i
        Return v_lngErrorCode
    End Function
#End Region

#Region " Private functions"
    Private Function Register_UnRegister(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "SE.Trans.Register_UnRegister"
        Dim v_strErrorMessage As String = String.Empty

        Dim v_ds As DataSet = Nothing

        Dim v_strBRID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value
        Dim v_strTxDate As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
        Dim v_strTLTXCD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value
        Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
        Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False

        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strFLDCD As String = String.Empty
        Dim v_strFLDTYPE As String = String.Empty
        Dim v_strVALUE As String = String.Empty

        Dim v_strCodeID As String = String.Empty
        Dim v_strQtty As String = String.Empty

        Dim v_strSQL As String = String.Empty

        Dim v_obj As New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)

        Dim v_dblVALUE As Double = 0D
        Dim i As Integer = 0I

        Try

            'Đọc nội dung giao dịch
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
                        Case "01" 'CodeID
                            v_strCodeID = v_strVALUE
                        Case "10" 'QTTY
                            v_strQtty = v_dblVALUE

                    End Select
                End With
            Next

            'Phát hành chứng chỉ quỹ
            If (Not v_blnReversal And v_strTLTXCD = gc_FN_REGISTER_SECURITIES) _
                Or (v_blnReversal And v_strTLTXCD = gc_FN_UNREGISTER_SECURITIES) Then
                v_strSQL = "UPDATE SBSECURITIES SET ISSQTTY=ISSQTTY+" & v_strQtty & " WHERE CODEID='" & v_strCodeID & "'"
            ElseIf (v_blnReversal And v_strTLTXCD = gc_FN_REGISTER_SECURITIES) _
                Or (Not v_blnReversal And v_strTLTXCD = gc_FN_UNREGISTER_SECURITIES) Then
                v_strSQL = "UPDATE SBSECURITIES SET ISSQTTY=ISSQTTY-" & v_strQtty & " WHERE CODEID='" & v_strCodeID & "'"
            End If

            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Thuc hien ghi vao SEPITLOG giao dich THQ 3351 chia co tuc = co phieu
    ''' Chi log vao SEPITLOG khi THQ la co tuc = co phieu
    ''' Added by: KhanhND 05/04/2011
    ''' </summary>
    ''' <param name="pv_xmlDocument">noi dung giao dich 3351</param>
    ''' <returns>0: Successed
    ''' Other: Failed</returns>
    ''' <remarks></remarks>
    Private Function DoPitLogTrans(ByVal pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "SE.Trans.DoPitLogTrans", v_strErrorMessage As String
        Dim v_obj As New DataAccess, v_ds As DataSet
        Dim v_strSQL As String = String.Empty, i As Integer
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE, v_dblQTTY As Double
            Dim v_strCODEID, v_strACCTNO, v_strSEACCTNO As String
            Dim v_strCAMASTID As String
            Dim v_dblTPRICE As Double
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_strCATYPEVALUE As String = String.Empty
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False
            v_obj.NewDBInstance(gc_MODULE_HOST)
            'Lay noi dung giao dich
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
                        Case "02" 'CAMASTID
                            v_strCAMASTID = v_strVALUE
                        Case "03" 'ACCTNO
                            v_strACCTNO = v_strVALUE
                        Case "08" 'SEACCTNO
                            v_strSEACCTNO = v_strVALUE
                            v_strCODEID = v_strVALUE.ToString.Substring(10)
                        Case "11" 'QTTY
                            v_dblQTTY = v_dblVALUE
                        Case "21" 'PRICEACCOUNTING
                            v_dblTPRICE = v_dblVALUE
                        Case "22" 'CATYPEVALUE
                            v_strCATYPEVALUE = v_strVALUE
                    End Select
                End With
            Next

            If Not v_blnReversal Then
                ' Chi lay nhung TK nao co VAT = 'Y' trong AFTYPE thi moi tinh thue TNCN ban CK quyen

                v_strSQL = "SELECT VAT FROM AFTYPE WHERE ACTYPE IN (SELECT ACTYPE FROM AFMAST WHERE ACCTNO='" & v_strACCTNO & "')"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If Not v_ds.Tables(0).Rows.Count > 0 Then

                    v_lngErrCode = ERR_CF_ACCTNO_INVALID
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If

                'Log into SEPITLOG when CATYPE is gc_CA_CATYPE_STOCK_DIVIDEND OR gc_CA_CATYPE_KIND_STOCK
                If (v_ds.Tables(0).Rows(0)("VAT") = "Y") And ((v_strCATYPEVALUE = gc_CA_CATYPE_STOCK_DIVIDENd) Or (v_strCATYPEVALUE = gc_CA_CATYPE_KIND_STOCK)) Then

                    v_strSQL = "INSERT INTO SEPITLOG(AUTOID,TXDATE,TXNUM,QTTY,MAPQTTY,CODEID,CAMASTID,ACCTNO,MODIFIEDDATE,AFACCTNO,PRICE) " _
                        & " VALUES (SEQ_SEPITLOG.NEXTVAL,TO_DATE('" & v_strTXDATE & "','" & gc_FORMAT_DATE & "'),'" & v_strTXNUM & "', " & v_dblQTTY & ",0,'" & v_strCODEID & "', " _
                        & " '" & v_strCAMASTID & "', '" & v_strSEACCTNO & "',TO_DATE('" & v_strTXDATE & "','" & gc_FORMAT_DATE & "'),'" & v_strACCTNO & "'," & v_dblTPRICE & ")"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                End If
            End If
            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function



    Private Function CompleteSDtoclose(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "SE.Trans.DepositSecurities", v_strErrorMessage As String
        Dim v_obj As New DataAccess, v_ds As DataSet
        Dim v_strSQL As String = String.Empty, i As Integer
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE, v_dblQTTY, v_dblSUMSDTC, v_dblSUMDTC As Double
            Dim v_strCODEID, v_strAPPLID, v_strSEACCTNO, v_strDESC, v_strAFACCTNO, v_strACCTNO As String
            Dim v_dblDEPOSITQTTY, v_dblDEPOSITPRICE, v_dblAMT As Double
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
                        Case "10" 'AMT
                            v_dblAMT = v_dblVALUE
                    End Select
                End With
            Next
            'kiem tra
            If Not v_blnReversal Then
                v_strSQL = "SELECT * FROM SEMAST WHERE AFACCTNO= '" & v_strAFACCTNO & "' AND ACCTNO='" & v_strACCTNO & "' AND DTOCLOSE >=" & v_dblAMT & ""
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If Not v_ds.Tables(0).Rows.Count > 0 Then

                    v_lngErrCode = ERR_SE_TRANSFER
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If
            End If
            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
    Private Function CHECKGenRemittanceTrans(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CI.Trans.GenRemittanceTrans", v_strErrorMessage As String
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strSQL, v_strFLDCD, v_strFLDTYPE, v_strVALUE As String, v_dateVALUE As String, v_dblVALUE As Double, i As Integer
        Dim v_strAUTOID, v_strACCTNO, v_strBANKID, v_strBENEFBANK, v_strBENEFACCT, v_strBENEFCUSTNAME, v_strBENEFLICENSE, v_strBENEFIDDATE, v_strBENEFIDPLACE, v_strFEETYPE, v_strFEECD As String
        Dim v_dblAMT, v_dblFEEAMT, v_dblVATAMT As Double

        Try
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

            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            'Ä?á»?c ná»™i dung giao dá»‹ch tÃ­nh lÃ£i cá»™ng dá»“n: 1160
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                        'TruongLD them 02/04/2010
                    ElseIf v_strFLDTYPE = "D" Then
                        If (Trim(.InnerText).Length > 0) And (Trim(.InnerText) <> gc_NULL_DATE) Then
                            v_dateVALUE = CStr(.InnerText)
                        Else
                            v_dateVALUE = v_strTXDATE
                        End If
                        v_strVALUE = vbNullString
                        v_dblVALUE = 0
                        'End TruongLD
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If

                    Select Case v_strFLDCD
                        Case "01" 'AUTOID: SU DUNG CHO GIAO DICH 1119, yeu cau chuyen tien ra ngoai tu internet
                            v_strAUTOID = v_dblVALUE.ToString
                        Case "03" 'ACCTNO
                            v_strACCTNO = v_strVALUE
                        Case "05" 'BANKID
                            v_strBANKID = v_strVALUE
                        Case "80" 'BENEFBANK
                            v_strBENEFBANK = v_strVALUE
                        Case "81" 'BENEFACCT
                            v_strBENEFACCT = v_strVALUE
                        Case "82" 'BENEFCUSTNAME
                            v_strBENEFCUSTNAME = v_strVALUE
                        Case "83" 'BENEFLICENSE
                            v_strBENEFLICENSE = v_strVALUE
                        Case "10" 'AMT
                            v_dblAMT = v_dblVALUE
                        Case "11" 'FEEAMT
                            v_dblFEEAMT = v_dblVALUE
                        Case "12" 'VATAMT
                            v_dblVATAMT = v_dblVALUE
                            'TRUONGLD THEM 01/04/2010
                        Case "95" 'BENEFIDDATE
                            v_strBENEFIDDATE = v_dateVALUE
                        Case "96" 'BENEFIDPLACE 
                            v_strBENEFIDPLACE = v_strVALUE
                            'End TruongLD
                        Case "09" 'FEETYPE
                            v_strFEETYPE = CStr(v_strVALUE)
                        Case "66" 'FEECD
                            v_strFEECD = CStr(v_strVALUE)

                    End Select
                End With
            Next
            v_dblFEEAMT = v_dblFEEAMT + v_dblVATAMT
            Dim v_ds As DataSet


            If v_strFEETYPE = 1 And Len(v_strFEECD) = 0 Then
                v_lngErrCode = ERR_CI_REMITTANCE_CLOSE
                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                             & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                             & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                Return v_lngErrCode
            End If


            'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
    Private Function CheckUnBlockSecurities(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "SE.Trans.CheckUnBlockSecurities", v_strErrorMessage As String
        Dim v_obj As New DataAccess, v_ds As DataSet
        Dim v_strSQL As String = String.Empty, i As Integer
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE, v_dblQTTY As Double
            Dim v_strCODEID, v_strAPPLID, v_strSEACCTNO, v_strQTTYTYPE, v_strDESC, v_strBLKDATE, v_strBLKNUM As String
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
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
                            v_strSEACCTNO = v_strVALUE.Replace(".", "")
                        Case "10" 'QTTY
                            v_dblQTTY = v_dblVALUE
                        Case "12" 'QTTYTYPE
                            v_strQTTYTYPE = v_strVALUE
                        Case "06" 'blocked date
                            v_strBLKDATE = v_strVALUE
                        Case "07" 'blocked number
                            v_strBLKNUM = v_strVALUE
                    End Select
                End With
            Next

            If Not v_blnReversal Then
                v_obj.NewDBInstance(gc_MODULE_HOST)
                v_strSQL = "SELECT * FROM SEMASTDTL WHERE acctno= '" & v_strSEACCTNO & "' and TXNUM='" & v_strBLKNUM & "' and TXDATE=TO_DATE('" & v_strBLKDATE & "','" & gc_FORMAT_DATE & "')"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    If v_ds.Tables(0).Rows(0)("QTTY") < v_dblQTTY Then
                        'BÃ¡o lá»—i khÃ´ng Ä‘á»§ sá»‘ dÆ°
                        v_lngErrCode = ERR_SE_SEMASTDTL_NOT_ENOUGTH
                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                     & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                     & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    End If
                End If

            End If
            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
    Private Function CheckRevertDeposit(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "SE.Trans.CheckRevertDeposit", v_strErrorMessage As String
        Dim v_obj As New DataAccess, v_ds As DataSet
        Dim v_strSQL As String = String.Empty, i As Integer
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE, v_dblQTTY As Double
            Dim v_dblAUTOID As Double
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strBUSDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBUSDATE).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_strTLTXCD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value
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
                        Case "05" 'AUTOID
                            v_dblAUTOID = v_dblVALUE
                    End Select
                End With
            Next

            If Not v_blnReversal Then
                v_obj.NewDBInstance(gc_MODULE_HOST)
                Select Case v_strTLTXCD
                    Case gc_SE_REVERT_DEPOSIT
                        v_strSQL = "select count(1) CNT from SEDEPOSIT where autoid = " & v_dblAUTOID & "  and depodate >  to_date('" & v_strBUSDATE & "','" & gc_FORMAT_DATE & "') "
                        v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                        If v_ds.Tables(0).Rows.Count > 0 Then
                            If v_ds.Tables(0).Rows(0)("CNT") > 0 Then
                                'BÃ¡o lá»—i khÃ´ng Ä‘á»§ sá»‘ dÆ°
                                v_lngErrCode = ERR_SE_TXDATE_HAS_CONSTRAINTS
                                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                             & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                             & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                            End If
                        End If
                    Case gc_SE_REVERT_SEND_DEPOSIT
                        v_strSQL = "select count(1) CNT from SEDEPOSIT where autoid = " & v_dblAUTOID & "  and SENDDEPODATE >  to_date('" & v_strBUSDATE & "','" & gc_FORMAT_DATE & "') "
                        v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                        If v_ds.Tables(0).Rows.Count > 0 Then
                            If v_ds.Tables(0).Rows(0)("CNT") > 0 Then
                                'BÃ¡o lá»—i khÃ´ng Ä‘á»§ sá»‘ dÆ°
                                v_lngErrCode = ERR_SE_TXDATE_HAS_CONSTRAINTS
                                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                             & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                             & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                            End If
                        End If
                End Select

            End If
            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
    Private Function CheckTradeLotRetail(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "SE.Trans.CheckTradeLotRetail", v_strErrorMessage As String
        Dim v_obj As New DataAccess, v_ds As DataSet
        Dim v_strSQL As String = String.Empty, i As Integer
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE As Double
            Dim v_strAFACCTNO As String
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False
            Dim v_strNumber As Long
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
                        Case "08" 'REFAFACCTNO
                            v_strAFACCTNO = v_strVALUE
                    End Select
                End With
            Next
            v_obj.NewDBInstance(gc_MODULE_HOST)
            'Kiem tra ngay het hang CMND
            v_strSQL = "select count(1) EXISTSVAL " & ControlChars.CrLf _
                    & "from cfmast cf, afmast af " & ControlChars.CrLf _
                    & "where cf.custid = af.custid and af.acctno = '" & v_strAFACCTNO & "' " & ControlChars.CrLf _
                    & "and cf.idexpired <= (select to_date(varvalue,'DD/MM/RRRR') from sysvar where varname = 'CURRDATE')"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

            If v_ds.Tables(0).Rows(0)("EXISTSVAL") > 0 Then
                v_lngErrCode = ERR_CF_AFMAST_GROUPLEADER_NOTMATCHED
                Return v_lngErrCode
            End If

            If Not v_blnReversal Then
                'Kiá»ƒm tra cÃ³ báº£n ghi chÆ°a
                v_obj.NewDBInstance(gc_MODULE_HOST)
                v_strSQL = "SELECT count(1) FROM afmast af, cfmast cf WHERE af.custid = cf.custid and af.acctno = '" & v_strAFACCTNO & "' AND substr(cf.custodycd,1,4) = (select to_char(varvalue) from sysvar where grname ='SYSTEM' and varname ='DEALINGCUSTODYCD')"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If Not v_ds.Tables(0).Rows(0)(0) > 0 Then

                    v_lngErrCode = ERR_AF_COMPANY_ACCTNO_NOTFOUND
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                End If
            End If
            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function CheckCIBalance(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "SE.Trans.CheckCIBalance", v_strErrorMessage As String
        Dim v_obj As New DataAccess, v_ds As DataSet
        Dim v_strSQL As String = String.Empty, i As Integer
        Dim v_dblCount As Integer
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE, v_dblQTTY, v_dblSUMSDTC, v_dblSUMDTC As Double
            Dim v_strCODEID, v_strAPPLID, v_strSEACCTNO, v_strDESC, v_strAFACCTNO, v_strACCTNO As String
            Dim v_dblDEPOSITQTTY, v_dblDEPOSITPRICE, v_dblCIBALANCE, v_dblDRAMT, v_dblFLOATAMT As Double
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
            v_strSQL = "SELECT ROUND(BALANCE,0) CIBALANCE,ROUND(FLOATAMT,0) FLOATAMT FROM CIMAST WHERE ACCTNO= '" & v_strAFACCTNO & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_dblCIBALANCE = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("CIBALANCE")), 0, v_ds.Tables(0).Rows(0)("CIBALANCE"))
                v_dblFLOATAMT = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("FLOATAMT")), 0, v_ds.Tables(0).Rows(0)("FLOATAMT"))
                If v_dblCIBALANCE > 0 Then
                    v_lngErrCode = ERR_SE_CIBALANCE
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode

                End If
                If v_dblFLOATAMT > 0 Then
                    v_lngErrCode = ERR_SE_1104_REMAIN
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode

                End If
            End If
            v_strSQL = "SELECT SUM(TRADE+MORTAGE+SENDDEPOSIT+DTOCLOSE)SEBALANCE FROM SEMAST WHERE AFACCTNO= '" & v_strAFACCTNO & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_dblCIBALANCE = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("SEBALANCE")), 0, v_ds.Tables(0).Rows(0)("SEBALANCE"))
                If v_dblCIBALANCE > 0 Then
                    v_lngErrCode = ERR_SE_EXSIT
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If
            End If

            v_strSQL = "SELECT COUNT(*) COUNT FROM(caschd) WHERE deltd='N' AND isexec='Y'" _
                        & " AND ((isse='N' AND qtty>0)or(isci='N' AND amt>0)) AND afacctno= '" & v_strAFACCTNO & "'"

            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_dblCount = v_ds.Tables(0).Rows(0)("COUNT")
                If v_dblCount > 0 Then
                    v_lngErrCode = ERR_SE_IS_CAWAITING
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If
            End If
            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
    Private Function CheckSEStatus(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CF.Trans.CloseContract", v_strErrorMessage As String
        Dim v_strSQL As String = String.Empty
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE As Double
            Dim v_strACCTNO As String
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_ds As DataSet
            Dim v_dblSumCI As Double
            Dim v_dblSumCount As Double
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
                    End Select
                End With
            Next
            v_strSQL = "SELECT DISTINCT STATUS FROM SEMAST WHERE AFACCTNO='" & v_strACCTNO & "' "
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then 'CI lam tron toi 100.VND
                v_strStatus = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("STATUS")), vbNullString, v_ds.Tables(0).Rows(0)("STATUS"))
                If v_strStatus <> "A" And v_strStatus <> "N" Then
                    v_lngErrCode = ERR_SE_STATUS
                    Return v_lngErrCode
                End If
            End If
            If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
    Private Function CheckCI(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "SE.Trans.DepositSecurities", v_strErrorMessage As String
        Dim v_obj As New DataAccess, v_ds As DataSet
        Dim v_strSQL As String = String.Empty, i As Integer
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE, v_dblQTTY As Double
            Dim v_strCODEID, v_strAPPLID, v_strSEACCTNO, v_strDESC, v_strAFACCTNO, v_strACCTNO As String
            Dim v_dblDEPOSITQTTY, v_dblDEPOSITPRICE As Double
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
            'phint thu
            'v_strSQL = "SELECT ROUND(BALANCE,0) CIBALANCE FROM CIMAST WHERE ACCTNO= '" & v_strAFACCTNO & "'"
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'If v_ds.Tables(0).Rows.Count > 0 Then
            '    Dim CIBALANCE As Double = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("CIBALANCE")), 0, v_ds.Tables(0).Rows(0)("CIBALANCE"))
            '    If CIBALANCE > 0 Then
            '        v_lngErrCode = ERR_SE_CIBALANCE 'Van con so du CI
            '    End If
            'End If

            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
    Private Function TransferDTOCLOSE(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "SE.Trans.DepositSecurities", v_strErrorMessage As String
        Dim v_obj As New DataAccess, v_ds As DataSet
        Dim v_strSQL As String = String.Empty, i As Integer
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE, v_dblQTTY As Double
            Dim v_strCODEID, v_strAPPLID, v_strSEACCTNO, v_strDESC, v_strAFACCTNO, v_strACCTNO As String
            Dim v_dblDEPOSITQTTY, v_dblDEPOSITPRICE, v_dblAMT As Double
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
                        Case "10" 'ACCTNO
                            v_dblAMT = v_dblVALUE
                    End Select
                End With
            Next

            'Kiem tra co co trong chu ki thanh toan khong
            v_strSQL = "SELECT COUNT(*) count FROM STSCHD WHERE SUBSTR(ACCTNO,1,10)='" & v_strAFACCTNO & "' AND STATUS<>'C' AND DELTD<>'Y' AND DUETYPE ='RM'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                Dim count As Int32 = v_ds.Tables(0).Rows(0)("COUNT")
                If count > 0 Then
                    v_lngErrCode = ERR_CI_RM 'van con tien nhan tien
                    Return v_lngErrCode
                End If
            End If
            v_strSQL = "SELECT COUNT(*) count FROM STSCHD WHERE SUBSTR(ACCTNO,1,10)='" & v_strAFACCTNO & "' AND STATUS<>'C' AND DELTD<>'Y' AND DUETYPE ='RS'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                Dim count As Int32 = v_ds.Tables(0).Rows(0)("COUNT")
                If count > 0 Then
                    v_lngErrCode = ERR_CI_RS 'van con chung khoan cho ve
                    Return v_lngErrCode
                End If
            End If

            If Not v_blnReversal Then
                v_strSQL = " SELECT * FROM SEMAST WHERE AFACCTNO= '" & v_strAFACCTNO & "' AND ACCTNO='" & v_strACCTNO & "' AND TRADE >=" & v_dblAMT & ""
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If Not v_ds.Tables(0).Rows.Count > 0 Then

                    v_lngErrCode = ERR_SE_TRADE_NOT_ENOUGHT
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If
            Else
                v_strSQL = " SELECT * FROM SEMAST WHERE AFACCTNO= '" & v_strAFACCTNO & "' AND ACCTNO='" & v_strACCTNO & "' AND DTOCLOSE >=" & v_dblAMT & ""
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If Not v_ds.Tables(0).Rows.Count > 0 Then

                    v_lngErrCode = ERR_SE_TRANSFER
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If
            End If
            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
    Private Function SecuritiesDepositRevert(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CI.Trans.PaidAdvancedPayment", v_strErrorMessage As String
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strSQL, v_strFLDCD, v_strFLDTYPE, v_strVALUE As String, v_dblVALUE As Double, i As Integer
        Dim v_strACCTNO, v_strORGORDERID, v_strORDERDATE, v_strCODEID, v_strAFACCTNO, v_strSYMBOL As String
        Dim v_dblAMT, v_dblFEEAMT, v_dblPAIDFEEAMT, v_dblINTRATE, v_dblDAYS, v_dblSTSCHDAUTOID As Double

        Try
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
            Dim v_strACCFLD As String
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            If v_strTLTXCD = gc_SE_UNBLOCK Or v_strTLTXCD = gc_SE_COMPLETE_DEPOSIT Or v_strTLTXCD = gc_SE_MORTAGE_RELEASE Or v_strTLTXCD = gc_SE_MORTAGE_RELEASE_TOSELL Then
                v_strACCFLD = "03"
            ElseIf v_strTLTXCD = gc_SE_TRF_SE2SE Or v_strTLTXCD = gc_SE_INWARD_SETRF Then
                v_strACCFLD = "05"
            End If


            'Ã„?Ã¡Â»?c nÃ¡Â»â„¢i dung giao dÃ¡Â»â€¹ch ung truoc tien ban: 1143
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
                        Case v_strACCFLD 'ACCTNO
                            v_strACCTNO = v_strVALUE
                        Case "10" 'AMT
                            v_dblAMT = v_dblVALUE
                    End Select
                End With
            Next

            'Kiem tra xem lich co thoa man de ung truoc khong?
            Dim v_ds As DataSet
            If v_blnReversal Then
                v_strSQL = " SELECT * FROM SEMAST WHERE ACCTNO='" & v_strACCTNO & "' AND TRADE >=" & v_dblAMT & ""
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If Not v_ds.Tables(0).Rows.Count > 0 Then
                    'khÃƒÂ´ng co lich nay
                    v_lngErrCode = ERR_SE_TRADE_NOT_ENOUGHT
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If

                If v_strTLTXCD = gc_SE_MORTAGE_RELEASE_TOSELL Then
                    'Neu da lam 2296, tuc là status trong semortagedtl = C thi khong cho xoa.
                    v_strSQL = " SELECT STATUS FROM SEMORTAGEDTL WHERE STATUS = 'C' AND TXNUM='" & v_strTXNUM & "' AND TXDATE=TO_DATE('" & v_strTXDATE & "','" & gc_FORMAT_DATE & "')"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count > 0 Then
                        v_lngErrCode = ERR_SE_CANNOT_DELETE_2253
                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                     & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                     & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                        Return v_lngErrCode
                    Else
                        v_strSQL = "UPDATE SEMORTAGEDTL SET DELTD='Y', STATUS = 'S', PSTATUS = SUBSTR(PSTATUS, 1, LENGTH(PSTATUS) - 1) WHERE TXNUM='" & v_strTXNUM & "' AND TXDATE=TO_DATE('" & v_strTXDATE & "','" & gc_FORMAT_DATE & "')"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    End If
                End If

            Else

                If v_strTLTXCD = gc_SE_MORTAGE_RELEASE_TOSELL Then
                    v_strSQL = " SELECT SYMBOL FROM SECURITIES_INFO WHERE CODEID='" & v_strCODEID & "'"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count > 0 Then
                        v_strSYMBOL = v_ds.Tables(0).Rows(0)("SYMBOL")
                    End If

                    v_strSQL = "INSERT INTO SEMORTAGEDTL (TXDATE,TXNUM, ACCTNO, AFACCTNO, CODEID, MORTAGE, STATUS, DELTD, TXDATETXNUM) VALUES (TO_DATE('" & v_strTXDATE & "','" & gc_FORMAT_DATE & "'),'" & v_strTXNUM & "', '" & v_strACCTNO & "', '" & v_strAFACCTNO & "', '" & v_strSYMBOL & "', " & v_dblAMT & ", 'S', 'N', '" & v_strTXDATE & v_strTXNUM & "')"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
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
    Private Function DepositSecurities(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "SE.Trans.DepositSecurities", v_strErrorMessage As String
        Dim v_obj As New DataAccess, v_ds As DataSet
        Dim v_strSQL As String = String.Empty, i As Integer
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE, v_dblQTTY As Double
            Dim v_strCODEID, v_strAPPLID, v_strSEACCTNO, v_strDESC As String
            Dim v_dblDEPOSITQTTY, v_dblDEPOSITPRICE As Double
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strBUSDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBUSDATE).Value
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
                        Case "03" 'SEACCTNO
                            v_strSEACCTNO = v_strVALUE
                        Case "10" 'DEPOSITQTTY
                            v_dblDEPOSITQTTY = v_dblVALUE
                        Case "09" 'PRICE
                            v_dblDEPOSITPRICE = v_dblVALUE
                        Case "30" 'DESC
                            v_strDESC = v_strVALUE
                    End Select
                End With
            Next

            If Not v_blnReversal Then
                'ghi nhan luu ky
                v_strSQL = "INSERT INTO SEDEPOSIT (AUTOID,ACCTNO,TXNUM,TXDATE,DEPOSITPRICE,DEPOSITQTTY,STATUS,DELTD,DESCRIPTION,DEPODATE) VALUES (SEQ_SEDEPOSIT.NEXTVAL,'" & v_strSEACCTNO & "','" & v_strTXNUM & "',TO_DATE('" & v_strTXDATE & "','DD/MM/YYYY')," & v_dblDEPOSITPRICE & "," & v_dblDEPOSITQTTY & ",'D','N','" & v_strTXDESC & "',TO_DATE('" & v_strBUSDATE & "','" & gc_FORMAT_DATE_Db & "'))"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            Else
                'Xoa luu ky
                v_strSQL = "SELECT * FROM SEMAST WHERE TRIM(ACCTNO)='" & v_strSEACCTNO & "' AND DEPOSIT>=" & v_dblDEPOSITQTTY
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count < 1 Then
                    v_lngErrCode = ERR_SE_DEPOSIT
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If

                v_strSQL = "UPDATE SEDEPOSIT SET DELTD='Y' WHERE TXNUM='" & v_strTXNUM & "' AND TXDATE=TO_DATE('" & v_strTXDATE & "','DD/MM/YYYY')"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End If

            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function RevertDepositSecurities(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "SE.Trans.DepositSecurities", v_strErrorMessage As String
        Dim v_obj As New DataAccess, v_ds As DataSet
        Dim v_strSQL As String = String.Empty, i As Integer
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE, v_dblQTTY As Double
            Dim v_strCODEID, v_strAPPLID, v_strSEACCTNO, v_strDESC As String
            Dim v_dblDEPOSITQTTY, v_dblDEPOSITPRICE, v_dblAUTOID As Double
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
                        Case "05" 'SEACCTNO
                            v_dblAUTOID = v_dblVALUE
                        Case "03" 'SEACCTNO
                            v_strSEACCTNO = v_strVALUE
                        Case "10" 'DEPOSITQTTY
                            v_dblDEPOSITQTTY = v_dblVALUE
                        Case "09" 'PRICE
                            v_dblDEPOSITPRICE = v_dblVALUE
                        Case "30" 'DESC
                            v_strDESC = v_strVALUE
                    End Select
                End With
            Next

            If Not v_blnReversal Then
                'ghi nhan luu ky
                v_strSQL = "UPDATE SEDEPOSIT SET DELTD='Y' WHERE AUTOID=" & v_dblAUTOID
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            Else
                'Xoa REVERT luu ky
                v_strSQL = "UPDATE SEDEPOSIT SET DELTD='N' WHERE AUTOID=" & v_dblAUTOID
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End If

            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function SendDepositSecurities(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "SE.Trans.DepositSecurities", v_strErrorMessage As String
        Dim v_obj As New DataAccess, v_ds As DataSet
        Dim v_strSQL As String = String.Empty, i As Integer
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE, v_dblQTTY As Double
            Dim v_strCODEID, v_strAPPLID, v_strSEACCTNO, v_strDESC As String
            Dim v_dblSENDDEPOSITQTTY, v_dblAutoID, v_dblDEPOSITPRICE As Double
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strBUSDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBUSDATE).Value
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
                        Case "03" 'SEACCTNO
                            v_strSEACCTNO = v_strVALUE
                        Case "05" 'AUTOID
                            v_dblAutoID = v_dblVALUE
                        Case "10" 'QTTY
                            v_dblSENDDEPOSITQTTY = v_dblVALUE
                    End Select
                End With
            Next

            If Not v_blnReversal Then
                'ghi nhan luu ky
                v_strSQL = "UPDATE SEDEPOSIT SET STATUS='S', SENDDEPODATE=TO_DATE('" & v_strBUSDATE & "','" & gc_FORMAT_DATE_Db & "') WHERE AUTOID=" & v_dblAutoID & ""
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            Else
                'Xoa luu ky
                v_strSQL = "SELECT * FROM SEMAST WHERE TRIM(ACCTNO)='" & v_strSEACCTNO & "' AND SENDDEPOSIT>=" & v_dblSENDDEPOSITQTTY
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count < 1 Then
                    v_lngErrCode = ERR_SE_SENDDEPOSIT
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If
                v_strSQL = "UPDATE SEDEPOSIT SET STATUS='D', SENDDEPODATE=NULL WHERE AUTOID=" & v_dblAutoID & ""
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End If

            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function RevertSendDepositSecurities(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "SE.Trans.DepositSecurities", v_strErrorMessage As String
        Dim v_obj As New DataAccess, v_ds As DataSet
        Dim v_strSQL As String = String.Empty, i As Integer
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE, v_dblQTTY As Double
            Dim v_strCODEID, v_strAPPLID, v_strSEACCTNO, v_strDESC As String
            Dim v_dblSENDDEPOSITQTTY, v_dblAutoID, v_dblDEPOSITPRICE As Double
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
                        Case "03" 'SEACCTNO
                            v_strSEACCTNO = v_strVALUE
                        Case "05" 'AUTOID
                            v_dblAutoID = v_dblVALUE
                        Case "10" 'QTTY
                            v_dblSENDDEPOSITQTTY = v_dblVALUE
                    End Select
                End With
            Next

            If Not v_blnReversal Then
                'ghi nhan luu ky
                v_strSQL = "UPDATE SEDEPOSIT SET STATUS='D' WHERE AUTOID=" & v_dblAutoID & ""
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            Else
                'Xoa luu ky
                v_strSQL = "SELECT * FROM SEMAST WHERE TRIM(ACCTNO)='" & v_strSEACCTNO & "' AND DEPOSIT>=" & v_dblSENDDEPOSITQTTY
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count < 1 Then
                    v_lngErrCode = ERR_SE_SENDDEPOSIT
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If
                v_strSQL = "UPDATE SEDEPOSIT SET STATUS='S' WHERE AUTOID=" & v_dblAutoID & ""
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End If

            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function CompleteDepositSecurities(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "SE.Trans.DepositSecurities", v_strErrorMessage As String
        Dim v_obj As New DataAccess, v_ds As DataSet
        Dim v_strSQL As String = String.Empty, i As Integer
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE, v_dblQTTY As Double
            Dim v_strCODEID, v_strAPPLID, v_strSEACCTNO, v_strDESC As String
            Dim v_dblAutoID, v_dblDEPOSITPRICE As Double
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
                        Case "03" 'SEACCTNO
                            v_strSEACCTNO = v_strVALUE
                        Case "05" 'AUTOID
                            v_dblAutoID = v_dblVALUE
                        Case "10"
                            v_dblQTTY = v_dblVALUE
                    End Select
                End With
            Next

            If Not v_blnReversal Then
                'ghi nhan luu ky
                v_strSQL = "UPDATE SEDEPOSIT SET STATUS='C' WHERE AUTOID=" & v_dblAutoID & ""
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            Else
                'Xoa luu ky
                v_strSQL = "SELECT * FROM SEMAST WHERE TRIM(ACCTNO)='" & v_strSEACCTNO & "' AND TRADE>=" & v_dblQTTY
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count < 1 Then
                    v_lngErrCode = ERR_SE_TRADE_NOT_ENOUGHT
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If
                v_strSQL = "UPDATE SEDEPOSIT SET STATUS='S' WHERE AUTOID=" & v_dblAutoID & ""
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End If

            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function BlockSecurities(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "SE.Trans.BlockSecurities", v_strErrorMessage As String
        Dim v_obj As New DataAccess, v_ds As DataSet
        Dim v_strSQL As String = String.Empty, i As Integer
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE, v_dblQTTY As Double
            Dim v_strCODEID, v_strAPPLID, v_strSEACCTNO, v_strQTTYTYPE, v_strDESC As String
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
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
                        Case "03" 'SEACCTNO
                            v_strSEACCTNO = v_strVALUE
                        Case "10" 'QTTY
                            v_dblQTTY = v_dblVALUE
                        Case "12" 'QTTYTYPE
                            v_strQTTYTYPE = v_strVALUE
                    End Select
                End With
            Next
            v_obj.NewDBInstance(gc_MODULE_HOST)
            If Not v_blnReversal Then
                'Kiá»ƒm tra cÃ³ báº£n ghi chÆ°a
                v_strSQL = "INSERT INTO SEMASTDTL (ACCTNO,QTTY,QTTYTYPE,TXDATE,TXNUM,AUTOID) VALUES ('" & v_strSEACCTNO & "'," & v_dblQTTY & ",'" & v_strQTTYTYPE & "',TO_DATE('" & v_strTXDATE & "','" & gc_FORMAT_DATE & "'),'" & v_strTXNUM & "', SEQ_SEMASTDTL.NEXTVAL)"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            Else
                'Reverse láº¡i sá»‘ dÆ°
                v_strSQL = "UPDATE SEMASTDTL SET DELTD='Y' WHERE TXNUM='" & v_strTXNUM & "' AND TXDATE=TO_DATE('" & v_strTXDATE & "','" & gc_FORMAT_DATE & "')"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End If

            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function UnBlockSecurities(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "SE.Trans.UnBlockSecurities", v_strErrorMessage As String
        Dim v_obj As New DataAccess, v_ds As DataSet
        Dim v_objTmp As New DataAccess, v_dsTmp As DataSet
        Dim v_strSQL As String = String.Empty, i As Integer
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE, v_dblQTTY, v_dblDFQTTY, v_dblDFAQTTY, v_dblTRADEQTTY As Double
            Dim v_strCODEID, v_strAPPLID, v_strSEACCTNO, v_strQTTYTYPE, v_strDESC, v_strBLKDATE, v_strBLKNUM As String
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
                        Case "03" 'SEACCTNO
                            v_strSEACCTNO = v_strVALUE
                        Case "10" 'QTTY
                            v_dblQTTY = v_dblVALUE
                        Case "14" 'TRADEQTTY
                            v_dblTRADEQTTY = v_dblVALUE
                        Case "15" 'DFQTTY
                            v_dblDFQTTY = v_dblVALUE
                        Case "16" 'DFAQTTY
                            v_dblDFAQTTY = v_dblVALUE
                        Case "12" 'QTTYTYPE
                            v_strQTTYTYPE = v_strVALUE
                        Case "06" 'blocked date
                            v_strBLKDATE = v_strVALUE
                        Case "07" 'blocked number
                            v_strBLKNUM = v_strVALUE
                    End Select
                End With
            Next

            v_obj.NewDBInstance(gc_MODULE_HOST)
            v_objTmp.NewDBInstance(gc_MODULE_HOST)

            If Not v_blnReversal Then
                ''Kiem tra xem co phai phan bo theo tong
                'If Not IsDBNull(v_strBLKDATE) And v_strBLKDATE.Length > 0 Then
                '    'Kiem tra neu vuot qua ck vay thi ko cho phep thuc hien tiep
                '    v_strSQL = "select sum(nvl(QTTY,0)) QTTY, SUM(NVL(DFQTTY,0)) DFQTTY FROM  SEMASTDTL WHERE ACCTNO ='" & v_strSEACCTNO & "'  and status ='N' and deltd ='N' "
                '    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                '    If v_ds.Tables(0).Rows.Count > 0 Then
                '        If v_ds.Tables(0).Rows(0)("QTTY") < v_dblQTTY Or v_ds.Tables(0).Rows(0)("QTTY") < v_dblDFQTTY Then
                '            Return ERR_SE_SEMASTDTL_UNBLOCK_NOT_MATCH
                '        End If
                '    End If

                'Else
                'Neu phan bo theo tong so luong
                'Kiem tra neu vuot qua ck vay thi ko cho phep thuc hien tiep
                v_strSQL = "select count(1) QTTYENOUGHT from semastdtl WHERE acctno= '" & v_strSEACCTNO & "' and TXNUM='" & v_strBLKNUM & "' and TXDATE=TO_DATE('" & v_strBLKDATE & "','" & gc_FORMAT_DATE & "') and QTTY >= " & v_dblQTTY & ""
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows(0)(0) = 0 Then
                    Return ERR_SE_SEMASTDTL_UNBLOCK_NOT_MATCH
                End If
                'Kiem tra neu vuot qua ck vay thi ko cho phep thuc hien tiep
                v_strSQL = "select count(1) DFQTTYENOUGHT from semastdtl WHERE acctno= '" & v_strSEACCTNO & "' and TXNUM='" & v_strBLKNUM & "' and TXDATE=TO_DATE('" & v_strBLKDATE & "','" & gc_FORMAT_DATE & "') and dfqtty >= " & v_dblDFAQTTY & ""
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_dblDFAQTTY > 0 AndAlso v_ds.Tables(0).Rows(0)(0) = 0 Then
                    Return ERR_SE_SEMASTDTL_UNBLOCK_NOT_MATCH
                End If
                'Kiem tra neu chung khoan co lam deal blocked thi thuc hien giai phong toa phan deal.-> chuyen sang deal trade.
                v_strSQL = "UPDATE SEMASTDTL SET QTTY=QTTY-(" & v_dblDFAQTTY & "), DFQTTY=DFQTTY-(" & v_dblDFAQTTY & ") WHERE acctno= '" & v_strSEACCTNO & "' and TXNUM='" & v_strBLKNUM & "' and TXDATE=TO_DATE('" & v_strBLKDATE & "','" & gc_FORMAT_DATE & "')"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                'Dieu chinh trong DFMAST, dieu chinh thu tu uu tien.
                v_strSQL = "SELECT df.* " & ControlChars.CrLf _
                        & " FROM dfmast df,lnschd ln, securities_info se, " & ControlChars.CrLf _
                        & " (SELECT to_date(varvalue,'DD/MM/RRRR') currdate FROM sysvar WHERE varname = 'CURRDATE' AND grname = 'SYSTEM') sys " & ControlChars.CrLf _
                        & "                 WHERE df.codeid = SE.codeid And ln.acctno(+) = df.lnacctno and ln.reftype='P' " & ControlChars.CrLf _
                        & "                 and df.afacctno || df.codeid = '" & v_strSEACCTNO & "' and df.dfref = '" & v_strBLKNUM & v_strBLKDATE & "' and df.blockqtty > 0 " & ControlChars.CrLf _
                        & " order BY (CASE WHEN df.lnacctno IS NULL THEN 0 ELSE 1 END) DESC, (CASE WHEN (se.basicprice - df.triggerprice) < 0 THEN (se.basicprice - df.triggerprice) ELSE 0 END) ASC, (ln.overduedate - sys.currdate) ASC, df.amt DESC  , ln.rlsdate ASC, (CASE WHEN df.blockqtty > 0 AND df.rlsqtty > 0 THEN 1 ELSE 0 END) DESC "
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                Dim v_dblREAMAINDFAQTTY As Double = v_dblDFAQTTY
                Dim v_dblEXECDFAQTTY As Double = 0
                If v_ds.Tables(0).Rows.Count > 0 Then
                    For j As Integer = 0 To v_ds.Tables(0).Rows.Count - 1 Step 1
                        v_dblEXECDFAQTTY = Math.Min(v_dblREAMAINDFAQTTY, CDbl(v_ds.Tables(0).Rows(j)("BLOCKQTTY")))

                        v_strSQL = " BEGIN UPDATE DFMAST SET BLOCKQTTY=BLOCKQTTY-(" & v_dblEXECDFAQTTY & ") " & ControlChars.CrLf _
                        & ", AMT = AMT - (" & v_dblEXECDFAQTTY & " * REFPRICE * DFRATE /100) WHERE acctno='" & v_ds.Tables(0).Rows(j)("ACCTNO") & "'; "

                        ' Kiem tra neu' DFGROUP co TRADE cua chung khoan nay, co' REFPRICE va DFRATE giong nhau thi se phai tang TRADE len khong sinh dong` moi
                        v_strSQLTmp = "SELECT * FROM DFMAST WHERE GROUPID='" & v_ds.Tables(0).Rows(j)("GROUPID") & "' AND CODEID='" & Mid(v_strSEACCTNO, 11, 6) & "' AND REFPRICE = '" & v_ds.Tables(0).Rows(j)("REFPRICE") & "' AND DFRATE = '" & v_ds.Tables(0).Rows(j)("DFRATE") & "' AND ACCTNO NOT LIKE '%" & v_ds.Tables(0).Rows(j)("ACCTNO") & "%'"
                        v_dsTmp = v_objTmp.ExecuteSQLReturnDataset(CommandType.Text, v_strSQLTmp)
                        If v_dsTmp.Tables(0).Rows.Count > 0 Then

                            v_strSQL = v_strSQL & "UPDATE DFMAST SET DFQTTY = DFQTTY + (" & v_dblEXECDFAQTTY & "), AMT = AMT +  (" & v_dblEXECDFAQTTY & " * REFPRICE * DFRATE /100 )  WHERE acctno='" & v_dsTmp.Tables(0).Rows(0)("ACCTNO") & "'; END;"

                        Else
                            v_strSQL = v_strSQL & " INSERT INTO DFMAST (ACCTNO, AFACCTNO, LNACCTNO, TXDATE, TXNUM, TXTIME, " &
                                " ACTYPE, RRTYPE, DFTYPE, CUSTBANK, LNTYPE, FEE, FEEMIN, TAX, AMTMIN, CODEID, REFPRICE, DFPRICE, " &
                                " TRIGGERPRICE, DFRATE, IRATE, MRATE, LRATE, CallType, DFQTTY, RCVQTTY, BLOCKQTTY, CARCVQTTY, BQTTY, " &
                                " RLSQTTY, DFAMT, RLSAMT, AMT, INTAMTACR, FEEAMT, RLSFEEAMT, STATUS, DFREF, DESCRIPTION, PSTATUS, " &
                                " CIACCTNO, LAST_CHANGE, LIMITCHK, FLAGTRIGGER, ORGAMT, AUTOPAID, TRIGGERDATE, TLID, CISVRFEE, GROUPID, " &
                                " DEALTYPE, GRPORDAMT, CACASHQTTY) " &
                                "   SELECT  substr(afacctno,1,4)|| substr(to_char((select varvalue from sysvar where varname='CURRDATE')),1,2) " &
                                "|| substr(to_char((select varvalue from sysvar where varname='CURRDATE')),4,2) " &
                                "|| substr(to_char((select varvalue from sysvar where varname='CURRDATE')),9,2) " &
                                "|| substr('000000' || seq_dfmast.NEXTVAL,length('000000' || seq_dfmast.NEXTVAL)-5,6) acctno, AFACCTNO, LNACCTNO, TXDATE, TXNUM, TXTIME,ACTYPE, RRTYPE, DFTYPE, CUSTBANK, LNTYPE, FEE, " &
                                " FEEMIN, TAX, AMTMIN, CODEID, REFPRICE, DFPRICE, TRIGGERPRICE, DFRATE, IRATE, MRATE, LRATE, CALLTYPE, " &
                                " DFQTTY + " & v_dblEXECDFAQTTY & " DFQTTY, 0 RCVQTTY,0 BLOCKQTTY,0 CARCVQTTY ,0 BQTTY,0 RLSQTTY, DFAMT,0 RLSAMT, (DFQTTY + " & v_dblEXECDFAQTTY & " * REFPRICE * DFRATE /100) AMT, INTAMTACR, FEEAMT, " &
                                " RLSFEEAMT, STATUS, '" & v_ds.Tables(0).Rows(j)("ACCTNO") & "' DFREF, DESCRIPTION, PSTATUS, CIACCTNO, LAST_CHANGE, LIMITCHK, FLAGTRIGGER, ORGAMT, " &
                                " AUTOPAID, TRIGGERDATE, TLID, CISVRFEE, GROUPID, 'N' DEALTYPE, GRPORDAMT,0 CACASHQTTY " &
                                " FROM DFMAST A WHERE ACCTNO='" & v_ds.Tables(0).Rows(j)("ACCTNO") & "'; END; "

                        End If

                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                        v_dblREAMAINDFAQTTY = v_dblREAMAINDFAQTTY - v_dblEXECDFAQTTY
                        If v_dblREAMAINDFAQTTY = 0 Then
                            Exit For
                        End If

                    Next
                    'End If
                End If
                'Chuyen ra ngoai If
                If v_dblTRADEQTTY > 0 Then
                    v_strSQL = "UPDATE SEMASTDTL SET QTTY=QTTY-(" & v_dblTRADEQTTY & ")  WHERE acctno= '" & v_strSEACCTNO & "' AND TXNUM='" & v_strBLKNUM & "' and TXDATE=TO_DATE('" & v_strBLKDATE & "','" & gc_FORMAT_DATE & "')"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                End If

            Else
                'Khong cho xoa.
                ''Reverse
                'v_strSQL = "UPDATE SEMASTDTL SET QTTY=QTTY+(" & v_dblQTTY & ") WHERE TXNUM='" & v_strBLKNUM & "' and TXDATE=TO_DATE('" & v_strBLKDATE & "','" & gc_FORMAT_DATE & "')"
                'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                'Kiem tra neu chung khoan co lam deal blocked thi thuc hien giai phong toa phan deal.-> chuyen sang deal trade.
                v_strSQL = "UPDATE SEMASTDTL SET QTTY=QTTY+(" & v_dblDFAQTTY & "), DFQTTY=DFQTTY-(" & v_dblDFAQTTY & ") WHERE acctno= '" & v_strSEACCTNO & "' and TXNUM='" & v_strBLKNUM & "' and TXDATE=TO_DATE('" & v_strBLKDATE & "','" & gc_FORMAT_DATE & "')"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                'Dieu chinh trong DFMAST, dieu chinh thu tu uu tien.
                v_strSQL = "SELECT df.* " & ControlChars.CrLf _
                        & " FROM dfmast df,lnschd ln, securities_info se, " & ControlChars.CrLf _
                        & " (SELECT to_date(varvalue,'DD/MM/RRRR') currdate FROM sysvar WHERE varname = 'CURRDATE' AND grname = 'SYSTEM') sys " & ControlChars.CrLf _
                        & "                 WHERE df.codeid = SE.codeid And ln.acctno(+) = df.lnacctno " & ControlChars.CrLf _
                        & "                 and df.afacctno || df.codeid = '" & v_strSEACCTNO & "'  and df.dfref = '" & v_strBLKNUM & v_strBLKDATE & "'  and df.dfqtty > 0 " & ControlChars.CrLf _
                        & " order BY (CASE WHEN df.lnacctno IS NULL THEN 0 ELSE 1 END) DESC, (CASE WHEN (se.basicprice - df.triggerprice) < 0 THEN (se.basicprice - df.triggerprice) ELSE 0 END) ASC, (ln.overduedate - sys.currdate) ASC, df.amt DESC  , ln.rlsdate ASC, (CASE WHEN df.blockqtty > 0 AND df.rlsqtty > 0 THEN 1 ELSE 0 END) DESC "
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                Dim v_dblREAMAINDFAQTTY As Double = v_dblDFAQTTY
                Dim v_dblEXECDFAQTTY As Double = 0
                If v_ds.Tables(0).Rows.Count > 0 Then
                    For j As Integer = 0 To v_ds.Tables(0).Rows.Count - 1 Step 1
                        v_dblEXECDFAQTTY = Math.Min(v_dblREAMAINDFAQTTY, CDbl(v_ds.Tables(0).Rows(j)("DFQTTY")))
                        v_strSQL = "UPDATE DFMAST SET DFQTTY=DFQTTY-(" & v_dblEXECDFAQTTY & "), BLOCKQTTY=BLOCKQTTY+(" & v_dblEXECDFAQTTY & ") " & ControlChars.CrLf _
                            & "WHERE acctno='" & v_ds.Tables(0).Rows(j)("ACCTNO") & "'"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                        v_dblREAMAINDFAQTTY = v_dblREAMAINDFAQTTY - v_dblEXECDFAQTTY
                        If v_dblREAMAINDFAQTTY = 0 Then
                            Exit For
                        End If
                    Next
                End If

                If v_dblTRADEQTTY > 0 Then
                    v_strSQL = "UPDATE SEMASTDTL SET QTTY=QTTY+(" & v_dblTRADEQTTY & ")  WHERE acctno= '" & v_strSEACCTNO & "' and TXNUM='" & v_strBLKNUM & "' and TXDATE=TO_DATE('" & v_strBLKDATE & "','" & gc_FORMAT_DATE & "')"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                End If
            End If
            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
    Private Function BlockSecuritiesRetail(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "SE.Trans.BlockSecurities", v_strErrorMessage As String
        Dim v_obj As New DataAccess, v_ds As DataSet
        Dim v_strSQL As String = String.Empty, i As Integer
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE, v_dblQTTY, v_dblPrice, v_dblFeeamt As Double
            Dim v_strCODEID, v_strAPPLID, v_strSEACCTNO, v_strDESACCTNO, v_strDESC As String
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
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
                        Case "03" 'SEACCTNO
                            v_strSEACCTNO = v_strVALUE
                        Case "10" 'QTTY
                            v_dblQTTY = v_dblVALUE
                        Case "11" 'PRICE
                            v_dblPrice = v_dblVALUE
                        Case "09"
                            v_strDESACCTNO = v_strVALUE
                        Case "22" 'FEEAMT
                            v_dblFeeamt = v_dblVALUE
                    End Select
                End With
            Next

            'Kiá»ƒm tra cÃ³ báº£n ghi chÆ°a
            v_obj.NewDBInstance(gc_MODULE_HOST)

            If Not v_blnReversal Then
                'Náº¿u chÆ°a cÃ³ thÃ¬ táº¡o báº£n ghi
                v_strSQL = "INSERT INTO SERETAIL (TXDATE,TXNUM,ACCTNO,PRICE,QTTY,desacctno,feeamt) VALUES (TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'" & v_strTXNUM & "','" & v_strSEACCTNO & "'," & v_dblPrice & ",'" & v_dblQTTY & "','" & v_strDESACCTNO & "'," & v_dblFeeamt & ")"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            Else
                'XoÃ¡ giao dá»‹ch
                v_strSQL = "DELETE SERETAIL WHERE TXDATE = TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') AND TRIM(TXNUM) = '" & v_strTXNUM & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End If

            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function CancelSecuritiesRetail(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "SE.Trans.BlockSecurities", v_strErrorMessage As String
        Dim v_obj As New DataAccess, v_ds As DataSet
        Dim v_strSQL As String = String.Empty, i As Integer
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE, v_dblQTTY, v_dblPrice As Double
            Dim v_strCODEID, v_strAPPLID, v_strSEACCTNO, v_strDESC As String
            Dim v_strTXDATE As String '= pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String '= pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
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
                        Case "03" 'SEACCTNO
                            v_strSEACCTNO = v_strVALUE
                        Case "10" 'QTTY
                            v_dblQTTY = v_dblVALUE
                        Case "11" 'PRICE
                            v_dblPrice = v_dblVALUE
                        Case "04" 'TXDATE
                            v_strTXDATE = v_strVALUE
                        Case "05" 'TXNUM
                            v_strTXNUM = v_strVALUE
                    End Select
                End With
            Next

            'Kiá»ƒm tra cÃ³ báº£n ghi chÆ°a
            v_obj.NewDBInstance(gc_MODULE_HOST)

            If Not v_blnReversal Then
                v_strSQL = "UPDATE SERETAIL SET STATUS='R' , QTTY = QTTY - " & v_dblQTTY & " WHERE TXDATE = TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') AND TRIM(TXNUM) = '" & v_strTXNUM & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            Else
                'XoÃ¡ giao dá»‹ch
                v_strSQL = "UPDATE SERETAIL SET STATUS='N' , QTTY = QTTY + " & v_dblQTTY & " WHERE TXDATE = TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') AND TRIM(TXNUM) = '" & v_strTXNUM & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End If

            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function


    Private Function UnBlockSecuritiesRetail(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "SE.Trans.BlockSecurities", v_strErrorMessage As String
        Dim v_obj As New DataAccess, v_ds As DataSet
        Dim v_strSQL As String = String.Empty, i As Integer
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE, v_dblQTTY, v_dblPrice As Double
            Dim v_strCODEID, v_strAPPLID, v_strSEACCTNO, v_strDESC As String
            Dim v_strTXDATE As String '= pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String '= pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
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
                        Case "03" 'SEACCTNO
                            v_strSEACCTNO = v_strVALUE
                        Case "10" 'QTTY
                            v_dblQTTY = v_dblVALUE
                        Case "11" 'PRICE
                            v_dblPrice = v_dblVALUE
                        Case "04" 'TXDATE
                            v_strTXDATE = v_strVALUE
                        Case "05" 'TXNUM
                            v_strTXNUM = v_strVALUE
                    End Select
                End With
            Next

            'Kiá»ƒm tra cÃ³ báº£n ghi chÆ°a
            v_obj.NewDBInstance(gc_MODULE_HOST)

            If Not v_blnReversal Then
                v_strSQL = "UPDATE SERETAIL SET STATUS='C' , QTTY = QTTY - " & v_dblQTTY & " WHERE TXDATE = TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') AND TRIM(TXNUM) = '" & v_strTXNUM & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            Else
                'XoÃ¡ giao dá»‹ch
                v_strSQL = "UPDATE SERETAIL SET STATUS='S' , QTTY = QTTY + " & v_dblQTTY & " WHERE TXDATE = TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') AND TRIM(TXNUM) = '" & v_strTXNUM & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End If

            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function CancelSendSecuritiesRetail(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "SE.Trans.BlockSecurities", v_strErrorMessage As String
        Dim v_obj As New DataAccess, v_ds As DataSet
        Dim v_strSQL As String = String.Empty, i As Integer
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE, v_dblQTTY, v_dblPrice As Double
            Dim v_strCODEID, v_strAPPLID, v_strSEACCTNO, v_strDESC As String
            Dim v_strTXDATE As String '= pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String '= pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
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
                        Case "03" 'SEACCTNO
                            v_strSEACCTNO = v_strVALUE
                        Case "10" 'QTTY
                            v_dblQTTY = v_dblVALUE
                        Case "11" 'PRICE
                            v_dblPrice = v_dblVALUE
                        Case "04" 'TXDATE
                            v_strTXDATE = v_strVALUE
                        Case "05" 'TXNUM
                            v_strTXNUM = v_strVALUE
                    End Select
                End With
            Next

            'Kiá»ƒm tra cÃ³ báº£n ghi chÆ°a
            v_obj.NewDBInstance(gc_MODULE_HOST)

            If Not v_blnReversal Then
                v_strSQL = "UPDATE SERETAIL SET status ='N' WHERE TXDATE = TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') AND TRIM(TXNUM) = '" & v_strTXNUM & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            Else
                'XoÃ¡ giao dá»‹ch
                v_strSQL = "UPDATE SERETAIL SET status ='S' WHERE TXDATE = TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') AND TRIM(TXNUM) = '" & v_strTXNUM & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End If

            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function SendSecuritiesRetail(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "SE.Trans.BlockSecurities", v_strErrorMessage As String
        Dim v_obj As New DataAccess, v_ds As DataSet
        Dim v_strSQL As String = String.Empty, i As Integer
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE, v_dblQTTY, v_dblPrice, v_dblCURRPRICE As Double
            Dim v_strCODEID, v_strAPPLID, v_strSEACCTNO, v_strDESC As String
            Dim v_strTXDATE As String '= pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String '= pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_strBUSDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBUSDATE).Value
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
                        Case "03" 'SEACCTNO
                            v_strSEACCTNO = v_strVALUE
                        Case "10" 'QTTY
                            v_dblQTTY = v_dblVALUE
                        Case "11" 'PRICE
                            v_dblPrice = v_dblVALUE
                        Case "04" 'TXDATE
                            v_strTXDATE = v_strVALUE
                        Case "05" 'TXNUM
                            v_strTXNUM = v_strVALUE
                        Case "13"  ' CURRPRICE
                            v_dblCURRPRICE = v_dblVALUE
                    End Select
                End With
            Next

            'Kiá»ƒm tra cÃ³ báº£n ghi chÆ°a
            v_obj.NewDBInstance(gc_MODULE_HOST)

            If Not v_blnReversal Then
                'Ducnv sua update price=                
                v_strSQL = "UPDATE SERETAIL SET status ='S',vdate=  TO_DATE('" & v_strBUSDATE & "', '" & gc_FORMAT_DATE & "') WHERE TXDATE = TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') AND TRIM(TXNUM) = '" & v_strTXNUM & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            Else
                'XoÃ¡ giao dá»‹ch
                v_strSQL = "UPDATE SERETAIL SET status ='N' WHERE TXDATE = TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') AND TRIM(TXNUM) = '" & v_strTXNUM & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End If

            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function


    Private Function OpenAccount(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "SE.Trans.OpenAccount", v_strErrorMessage As String
        Dim v_obj As New DataAccess, v_ds As DataSet
        Dim v_strSQL As String = String.Empty, i As Integer
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE As Double
            Dim v_strCODEID, v_strAPPLID, v_strSEACCTNO, v_strDESC, v_strSECTYPE, v_strCUSTID As String
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
                        Case "01" 'CODEID
                            v_strCODEID = v_strVALUE
                        Case "02" 'AFACCTNO
                            v_strAPPLID = v_strVALUE
                        Case "03" 'SEACCTNO
                            v_strSEACCTNO = v_strVALUE
                        Case "30" 'DESC                                              
                            v_strDESC = v_strVALUE
                    End Select
                End With
            Next
            v_obj.NewDBInstance(gc_MODULE_HOST)
            'Check xem co bi trung khong?
            v_strSQL = "SELECT * FROM SEMAST WHERE ACCTNO ='" & v_strSEACCTNO & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then

                v_lngErrCode = ERR_SE_ACCTNO_DUPLICATED
                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                             & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                             & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                Return v_lngErrCode
            Else
                'ThanhNV: Sua thay cau lenh Insert Select = Insert Values

                'v_strSQL = "INSERT INTO SEMAST (ACTYPE,CUSTID,ACCTNO,CODEID,AFACCTNO," & ControlChars.CrLf _
                '                                       & "OPNDATE,LASTDATE,STATUS,IRTIED,IRCD," & ControlChars.CrLf _
                '                                       & "COSTPRICE,TRADE,MORTAGE,MARGIN,NETTING," & ControlChars.CrLf _
                '                                       & "STANDING,WITHDRAW,DEPOSIT,LOAN) " & ControlChars.CrLf _
                '                           & "SELECT TYP.SETYPE, AF.CUSTID, '" & v_strSEACCTNO & "', '" & v_strCODEID & "','" & v_strAPPLID & "'," & ControlChars.CrLf _
                '                           & "TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'A','Y','001'," & ControlChars.CrLf _
                '                           & "0,0,0,0,0,0,0,0,0 " & ControlChars.CrLf _
                '                           & "FROM AFMAST AF, AFTYPE TYP WHERE AF.ACTYPE=TYP.ACTYPE AND AF.ACCTNO='" & v_strAPPLID & "'"
                'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                v_strSQL = "SELECT TYP.SETYPE SETYPE, AF.CUSTID CUSTID FROM AFMAST AF, AFTYPE TYP WHERE AF.ACTYPE=TYP.ACTYPE AND AF.ACCTNO='" & v_strAPPLID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_strSECTYPE = v_ds.Tables(0).Rows(0)("SETYPE")
                    v_strCUSTID = v_ds.Tables(0).Rows(0)("CUSTID")
                    v_strSQL = "INSERT INTO SEMAST (ACTYPE,CUSTID,ACCTNO,CODEID,AFACCTNO," & ControlChars.CrLf _
                                                           & "OPNDATE,LASTDATE,STATUS,IRTIED,IRCD," & ControlChars.CrLf _
                                                           & "COSTPRICE,TRADE,MORTAGE,MARGIN,NETTING," & ControlChars.CrLf _
                                                           & "STANDING,WITHDRAW,DEPOSIT,LOAN) " & ControlChars.CrLf _
                                               & " VALUES ('" & v_strSECTYPE & "', '" & v_strCUSTID & "', '" & v_strSEACCTNO & "', '" & v_strCODEID & "','" & v_strAPPLID & "'," & ControlChars.CrLf _
                                               & "TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'A','Y','001'," & ControlChars.CrLf _
                                               & "0,0,0,0,0,0,0,0,0 )"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                End If
            End If
            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function InquiryAccount(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "SE.Trans.InquiryAccount", v_strErrorMessage As String
        Dim v_strSQL As String = String.Empty
        Dim v_ds As DataSet
        Dim v_obj As New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE As Double, i As Integer
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
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
                        Case "04" 'NEXT TRANSACTION                                            
                    End Select
                End With
            Next
            'Kiá»ƒm tra mÃ£ há»£p Ä‘á»“ng Ä‘Ã£ tá»“n táº¡i chÆ°a
            v_strSQL = "SELECT * FROM SEMAST WHERE TRIM(ACCTNO)='" & ATTR_ACCTNO & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If Not v_ds.Tables(0).Rows.Count > 0 Then
                'Tráº£ vá»? mÃ£ lá»—i khÃ´ng tá»“n táº¡i mÃ£ há»£p Ä‘á»“ng
                v_lngErrCode = ERR_SE_AFACCTNO_NOTFOUND
                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                             & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                             & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                Return v_lngErrCode
            End If
            ''Gá»?i hÃ m Ä‘á»ƒ láº¥y dá»¯ liá»‡u vá»?
            'ATTR_CMDMISCINQUIRY = "SELECT MST.ACTYPE, MST.ACCTNO, MST.AFACCTNO, MST.LASTDATE, MST.CODEID, MST.IRCD, MST.STATUS,  " & ControlChars.CrLf _
            '        & "MST.COSTPRICE, MST.TRADE, MST.MORTAGE, MST.MARGIN, MST.NETTING, MST.STANDING, MST.SECURED,  " & ControlChars.CrLf _
            '        & "MST.WITHDRAW, MST.BLOCKED, MST.DEPOSIT, MST.LOAN,MST.PREVQTTY,MST.DTOCLOSE,MST.SDTOCLOSE,MST.DCRQTTY,MST.DCRAMT,MST.DEPOFEEACR, MST.RECEIVING, " & ControlChars.CrLf _
            '        & "CCY.SYMBOL, CCY.PARVALUE,SE_INF.PREVCLOSEPRICE PRICE, CD1.CDCONTENT DESC_STATUS " & ControlChars.CrLf _
            '        & "FROM AFMAST AF, SEMAST MST, SBSECURITIES CCY, SECURITIES_INFO SE_INF, ALLCODE CD1 " & ControlChars.CrLf _
            '        & "WHERE TRIM(AF.ACCTNO) = TRIM(MST.AFACCTNO) AND TRIM(CCY.CODEID)=TRIM(MST.CODEID) AND TRIM(MST.ACCTNO) = '" & ATTR_ACCTNO & "'  " & ControlChars.CrLf _
            '        & "AND TRIM(CD1.CDTYPE) = 'SE' AND SE_INF.CODEID=CCY.CODEID AND TRIM(CD1.CDNAME)='STATUS' AND TRIM(MST.STATUS) = TRIM(CD1.CDVAL) "
            ''ATTR_CMDACCOUNTINQUIRY = "SELECT MST.ACTYPE, MST.ACCTNO, MST.AFACCTNO, MST.LASTDATE, MST.CODEID, MST.IRCD, MST.STATUS,  " & ControlChars.CrLf _
            ''        & "MST.COSTPRICE, MST.TRADE, MST.MORTAGE, MST.MARGIN, MST.NETTING, MST.STANDING, MST.SECURED,  " & ControlChars.CrLf _
            ''        & "MST.WITHDRAW, MST.BLOCKED, MST.DEPOSIT, MST.LOAN,MST.PREVQTTY,MST.DTOCLOSE,MST.SDTOCLOSE,MST.DCRQTTY,MST.DCRAMT,MST.DEPOFEEACR, MST.RECEIVING,  " & ControlChars.CrLf _
            ''        & "CCY.SYMBOL, CCY.PARVALUE,SE_INF.PREVCLOSEPRICE PRICE, CD1.CDCONTENT DESC_STATUS " & ControlChars.CrLf _
            ''        & "FROM AFMAST AF, SEMAST MST, SBSECURITIES CCY, SECURITIES_INFO SE_INF, ALLCODE CD1 " & ControlChars.CrLf _
            ''        & "WHERE AF.ACCTNO = MST.AFACCTNO AND CCY.CODEID=MST.CODEID AND MST.ACCTNO = :ACCTNO  " & ControlChars.CrLf _
            ''        & "AND TRIM(CD1.CDTYPE) = 'SE' AND SE_INF.CODEID=CCY.CODEID AND TRIM(CD1.CDNAME)='STATUS' AND TRIM(MST.STATUS) = TRIM(CD1.CDVAL) "
            'ATTR_CMDACCOUNTINQUIRY = " SELECT MST.ACTYPE, MST.ACCTNO, MST.AFACCTNO, MST.LASTDATE, MST.CODEID, MST.IRCD, MST.STATUS,   " & ControlChars.CrLf _
            '                & " MST.COSTPRICE, MST.TRADE-NVL(B.SECUREAMT,0) TRADE, MST.MORTAGE-NVL(B.SECUREMTG,0) MORTAGE , MST.MARGIN, MST.NETTING, MST.STANDING,NVL(B.SECUREAMT,0)+NVL(B.SECUREMTG,0) SECURED,   " & ControlChars.CrLf _
            '                & " MST.WITHDRAW, MST.BLOCKED, MST.DEPOSIT, MST.LOAN,MST.PREVQTTY,MST.DTOCLOSE,MST.SDTOCLOSE,MST.DCRQTTY,MST.DCRAMT,MST.DEPOFEEACR, MST.RECEIVING,   " & ControlChars.CrLf _
            '                & " CCY.SYMBOL, CCY.PARVALUE,SE_INF.PREVCLOSEPRICE PRICE, CD1.CDCONTENT DESC_STATUS  " & ControlChars.CrLf _
            '                & " FROM AFMAST AF, SEMAST MST, SBSECURITIES CCY, SECURITIES_INFO SE_INF, ALLCODE CD1,  " & ControlChars.CrLf _
            '                & "     (SELECT    MAX(SEACCTNO) SEACCTNO ,  SUM (CASE WHEN OD.EXECTYPE IN ('NS', 'SS') THEN REMAINQTTY + EXECQTTY ELSE 0 END)  SECUREAMT, " & ControlChars.CrLf _
            '                & "              SUM (CASE WHEN OD.EXECTYPE ='MS' THEN REMAINQTTY + EXECQTTY ELSE 0 END)  SECUREMTG " & ControlChars.CrLf _
            '                & "      FROM ODMAST OD " & ControlChars.CrLf _
            '                & "      WHERE OD.SEACCTNO = :ACCTNO  " & ControlChars.CrLf _
            '                & "                AND OD.TXDATE =TO_DATE ('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')  " & ControlChars.CrLf _
            '                & "                AND DELTD <> 'Y'  AND OD.EXECTYPE IN ('NS', 'SS','MS')) B " & ControlChars.CrLf _
            '                & " WHERE AF.ACCTNO = MST.AFACCTNO AND MST.ACCTNO=B.SEACCTNO(+) AND CCY.CODEID=MST.CODEID AND MST.ACCTNO = :ACCTNO   " & ControlChars.CrLf _
            '                & " AND TRIM(CD1.CDTYPE) = 'SE' AND SE_INF.CODEID=CCY.CODEID AND TRIM(CD1.CDNAME)='STATUS' AND TRIM(MST.STATUS) = TRIM(CD1.CDVAL)  " & ControlChars.CrLf

            'v_lngErrCode = Me.txCoreMiscInquiry(pv_xmlDocument)

            'TRUONGLD COMMENT 16/04/2010
            'Dim v_objRptParam As ReportParameters
            'Dim v_arrRptPara() As ReportParameters
            'ReDim v_arrRptPara(3)
            ''0. table
            'v_objRptParam = New ReportParameters
            'v_objRptParam.ParamName = "f_TABLENAME"
            'v_objRptParam.ParamValue = "SEMAST"
            'v_objRptParam.ParamSize = 20
            'v_objRptParam.ParamType = "NUMBER"
            'v_arrRptPara(0) = v_objRptParam
            ''1.Account
            'v_objRptParam = New ReportParameters
            'v_objRptParam.ParamName = "f_ACCTNO"
            'v_objRptParam.ParamValue = ATTR_ACCTNO
            'v_objRptParam.ParamSize = 20
            'v_objRptParam.ParamType = "VARCHAR2"
            'v_arrRptPara(1) = v_objRptParam
            ''2. In Date
            'v_objRptParam = New ReportParameters
            'v_objRptParam.ParamName = "f_INDATE"
            'v_objRptParam.ParamValue = v_strTXDATE
            'v_objRptParam.ParamSize = 100
            'v_objRptParam.ParamType = "VARCHAR2"
            'v_arrRptPara(2) = v_objRptParam
            ''3. Type
            'v_objRptParam = New ReportParameters
            'v_objRptParam.ParamName = "f_TYPE"
            'v_objRptParam.ParamValue = "U"
            'v_objRptParam.ParamSize = 100
            'v_objRptParam.ParamType = "VARCHAR2"
            'v_arrRptPara(3) = v_objRptParam
            'v_ds = v_obj.ExecuteStoredReturnDataset("InquiryAccount", v_arrRptPara)
            'Dim v_strXMLMessage As String
            'v_strXMLMessage = pv_xmlDocument.InnerXml
            'BuildXMLObjData(v_ds, v_strXMLMessage)
            'pv_xmlDocument.LoadXml(v_strXMLMessage)

            'END TRUONGLD

            v_lngErrCode = Me.StoreInquiryAccount(pv_xmlDocument, "SEMAST", v_strTXDATE)

            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function


    Private Function HistoryAccount(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "SE.Trans.HistoryAccount", v_strErrorMessage As String

        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE As Double, i As Integer
            Dim v_strCodeid, v_strCAREBY, v_strAFAccount As String
            'Ä?á»?c ná»™i dung giao dá»‹ch
            If Not pv_xmlDocument.SelectSingleNode("/TransactMessage").Attributes(gc_AtributeCAREBY) Is Nothing Then
                v_strCAREBY = pv_xmlDocument.SelectSingleNode("/TransactMessage").Attributes(gc_AtributeCAREBY).Value
            Else
                v_strCAREBY = String.Empty
            End If
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
                            v_strCodeid = v_strVALUE
                        Case "02" 'AFACCTNO
                            v_strAFAccount = v_strVALUE
                        Case "03" 'ACCTNO
                            ATTR_ACCTNO = v_strVALUE
                        Case "05" 'FRDATE
                            Me.ATTR_FRDATE = v_strVALUE
                        Case "06" 'TODATE
                            Me.ATTR_TODATE = v_strVALUE
                    End Select
                End With
            Next

            'Gá»?i hÃ m Ä‘á»ƒ láº¥y dá»¯ liá»‡u vá»?

            'TRUONGLD COMMENT 16/04/2010
            'If v_strCodeid = "0000" Then
            '    ATTR_CMDMISCINQUIRY = "SELECT * FROM  " & ControlChars.CrLf _
            '                & "(SELECT LF.TXDATE, LF.TXNUM, LF.BUSDATE, LF.TLTXCD, LF.TXDESC, (CASE WHEN SUBSTR(LF.TLTXCD,1,2)='33'THEN TRF.NAMT ELSE LF.MSGAMT END )AMT ,TX.TXDESC TLTXDESC,TX.EN_TXDESC TLTXEN_DESC,LF.DELTD, SEINFO.SYMBOL  " & ControlChars.CrLf _
            '                & "FROM (SELECT  TO_CHAR(TXDATE,'" & gc_FORMAT_DATE & "') || TXNUM VOUCHERCD,MAX(NAMT) NAMT, SUBSTR(ACCTNO, 11, 6) CODEID  " & ControlChars.CrLf _
            '                & "FROM " & ATTR_MODULE & "TRAN WHERE TRIM(ACCTNO) like '" & v_strAFAccount & "%'  " & ControlChars.CrLf _
            '                & "AND TXDATE>=TO_DATE('" & ATTR_FRDATE & "', '" & gc_FORMAT_DATE & "')  " & ControlChars.CrLf _
            '                & "AND TXDATE<=TO_DATE('" & ATTR_TODATE & "', '" & gc_FORMAT_DATE & "') GROUP BY TXDATE ,TXNUM, SUBSTR(ACCTNO, 11, 6) ) TRF, TLLOG LF, TLTX TX, SECURITIES_INFO SEINFO  " & ControlChars.CrLf _
            '                & "WHERE TRF.VOUCHERCD=TO_CHAR(LF.TXDATE,'" & gc_FORMAT_DATE & "') || LF.TXNUM AND LF.DELTD<>'Y' AND LF.TLTXCD=TX.TLTXCD  AND TRF.CODEID = SEINFO.CODEID " & ControlChars.CrLf _
            '                & "UNION ALL  " & ControlChars.CrLf _
            '                & "SELECT LF.TXDATE, LF.TXNUM, LF.BUSDATE, LF.TLTXCD, LF.TXDESC, (CASE WHEN SUBSTR(LF.TLTXCD,1,2)='33'THEN TRF.NAMT ELSE LF.MSGAMT END )AMT ,TX.TXDESC TLTXDESC,TX.EN_TXDESC TLTXEN_DESC,LF.DELTD, SEINFO.SYMBOL  " & ControlChars.CrLf _
            '                & "FROM (SELECT DISTINCT TO_CHAR(TXDATE,'" & gc_FORMAT_DATE & "') || TXNUM VOUCHERCD,MAX(NAMT) NAMT, SUBSTR(ACCTNO, 11, 6) CODEID  " & ControlChars.CrLf _
            '                & "FROM " & ATTR_MODULE & "TRANA WHERE TRIM(ACCTNO) like '" & v_strAFAccount & "%'  " & ControlChars.CrLf _
            '                & "AND TXDATE>=TO_DATE('" & ATTR_FRDATE & "', '" & gc_FORMAT_DATE & "')  " & ControlChars.CrLf _
            '                & "AND TXDATE<=TO_DATE('" & ATTR_TODATE & "', '" & gc_FORMAT_DATE & "') GROUP BY TXDATE ,TXNUM, SUBSTR(ACCTNO, 11, 6) ) TRF, TLLOGALL LF, TLTX TX, SECURITIES_INFO SEINFO " & ControlChars.CrLf _
            '                & "WHERE TRF.VOUCHERCD=TO_CHAR(LF.TXDATE,'" & gc_FORMAT_DATE & "') || LF.TXNUM AND LF.DELTD<>'Y' AND LF.TLTXCD=TX.TLTXCD AND TRF.CODEID = SEINFO.CODEID ) LOGDATA  " & ControlChars.CrLf _
            '                & "ORDER BY TXDATE, TXNUM "
            'Else
            '    ATTR_CMDMISCINQUIRY = "SELECT * FROM  " & ControlChars.CrLf _
            '                  & "(SELECT LF.TXDATE, LF.TXNUM, LF.BUSDATE, LF.TLTXCD, LF.TXDESC, (CASE WHEN SUBSTR(LF.TLTXCD,1,2)='33'THEN TRF.NAMT ELSE LF.MSGAMT END )AMT,TX.TXDESC TLTXDESC,TX.EN_TXDESC TLTXEN_DESC,LF.DELTD, SEINFO.SYMBOL   " & ControlChars.CrLf _
            '                  & "FROM (SELECT  TO_CHAR(TXDATE,'" & gc_FORMAT_DATE & "') || TXNUM VOUCHERCD ,MAX(NAMT) NAMT, SUBSTR(ACCTNO, 11, 6) CODEID  " & ControlChars.CrLf _
            '                  & "FROM " & ATTR_MODULE & "TRAN WHERE TRIM(ACCTNO) = '" & ATTR_ACCTNO & "'  " & ControlChars.CrLf _
            '                  & "AND TXDATE>=TO_DATE('" & ATTR_FRDATE & "', '" & gc_FORMAT_DATE & "')  " & ControlChars.CrLf _
            '                  & "AND TXDATE<=TO_DATE('" & ATTR_TODATE & "', '" & gc_FORMAT_DATE & "')GROUP BY TXDATE ,TXNUM, SUBSTR(ACCTNO, 11, 6)) TRF, TLLOG LF, TLTX TX, SECURITIES_INFO SEINFO  " & ControlChars.CrLf _
            '                  & "WHERE TRF.VOUCHERCD=TO_CHAR(LF.TXDATE,'" & gc_FORMAT_DATE & "') || TLF.XNUM AND LF.DELTD<>'Y' AND LF.TLTXCD=TX.TLTXCD  AND TRF.CODEID = SEINFO.CODEID " & ControlChars.CrLf _
            '                  & "UNION ALL  " & ControlChars.CrLf _
            '                  & "SELECT LF.TXDATE, LF.TXNUM, LF.BUSDATE, LF.TLTXCD, LF.TXDESC, (CASE WHEN SUBSTR(LF.TLTXCD,1,2)='33'THEN TRF.NAMT ELSE LF.MSGAMT END )AMT ,TX.TXDESC TLTXDESC,TX.EN_TXDESC TLTXEN_DESC,LF.DELTD, SEINFO.SYMBOL   " & ControlChars.CrLf _
            '                  & "FROM (SELECT  TO_CHAR(TXDATE,'" & gc_FORMAT_DATE & "') || TXNUM VOUCHERCD ,MAX(NAMT) NAMT, SUBSTR(ACCTNO, 11, 6) CODEID  " & ControlChars.CrLf _
            '                  & "FROM " & ATTR_MODULE & "TRANA WHERE TRIM(ACCTNO) = '" & ATTR_ACCTNO & "'  " & ControlChars.CrLf _
            '                  & "AND TXDATE>=TO_DATE('" & ATTR_FRDATE & "', '" & gc_FORMAT_DATE & "')  " & ControlChars.CrLf _
            '                  & "AND TXDATE<=TO_DATE('" & ATTR_TODATE & "', '" & gc_FORMAT_DATE & "')GROUP BY TXDATE ,TXNUM, SUBSTR(ACCTNO, 11, 6)) TRF, TLLOGALL LF, TLTX TX, SECURITIES_INFO SEINFO   " & ControlChars.CrLf _
            '                  & "WHERE TRF.VOUCHERCD=TO_CHAR(LF.TXDATE,'" & gc_FORMAT_DATE & "') || LF.TXNUM AND LF.DELTD<>'Y' AND LF.TLTXCD=TX.TLTXCD AND TRF.CODEID = SEINFO.CODEID ) LOGDATA  " & ControlChars.CrLf _
            '                  & "ORDER BY TXDATE, TXNUM "

            '    Dim v_strPAGENO As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributePAGENO).Value
            '    If IsNumeric(v_strPAGENO) Then
            '        Me.ATTR_PAGENUMBER = CInt(v_strPAGENO)
            '    Else
            '        Me.ATTR_PAGENUMBER = 1
            '    End If
            '    Dim v_intFrom, v_intTo As Integer
            '    v_intFrom = (Me.ATTR_PAGENUMBER - 1) * ROWS_PER_PAGE + 1
            '    v_intTo = Me.ATTR_PAGENUMBER * ROWS_PER_PAGE

            '    ATTR_CMDHISTORYINQUIRY = "SELECT * FROM (SELECT LOGDATA.*, ROWNUM RN FROM  " & ControlChars.CrLf _
            '                  & "(SELECT LF.TXDATE, LF.TXNUM, LF.BUSDATE, LF.TLTXCD, LF.TXDESC, (CASE WHEN SUBSTR(LF.TLTXCD,1,2)='33'THEN TRF.NAMT ELSE LF.MSGAMT END )AMT,TX.TXDESC TLTXDESC,TX.EN_TXDESC TLTXEN_DESC,LF.DELTD, SEINFO.SYMBOL  " & ControlChars.CrLf _
            '                  & "FROM (SELECT  TO_CHAR(TXDATE,'" & gc_FORMAT_DATE & "') || TXNUM VOUCHERCD ,MAX(NAMT) NAMT, SUBSTR(ACCTNO, 11, 6) CODEID  " & ControlChars.CrLf _
            '                  & "FROM " & ATTR_MODULE & "TRAN WHERE TRIM(ACCTNO) = '" & ATTR_ACCTNO & "'  " & ControlChars.CrLf _
            '                  & "AND TXDATE>=TO_DATE('" & ATTR_FRDATE & "', '" & gc_FORMAT_DATE & "')  " & ControlChars.CrLf _
            '                  & "AND TXDATE<=TO_DATE('" & ATTR_TODATE & "', '" & gc_FORMAT_DATE & "')GROUP BY TXDATE ,TXNUM, SUBSTR(ACCTNO, 11, 6)) TRF, TLLOG LF, TLTX TX, SECURITIES_INFO SEINFO  " & ControlChars.CrLf _
            '                  & "WHERE TRF.VOUCHERCD=TO_CHAR(LF.TXDATE,'" & gc_FORMAT_DATE & "') || LF.TXNUM AND LF.DELTD<>'Y' AND LF.TLTXCD=TX.TLTXCD AND TRF.CODEID = SEINFO.CODEID " & ControlChars.CrLf _
            '                  & "UNION ALL  " & ControlChars.CrLf _
            '                  & "SELECT LF.TXDATE, LF.TXNUM, LF.BUSDATE, LF.TLTXCD, LF.TXDESC, (CASE WHEN SUBSTR(LF.TLTXCD,1,2)='33'THEN TRF.NAMT ELSE LF.MSGAMT END )AMT,TX.TXDESC TLTXDESC,TX.EN_TXDESC TLTXEN_DESC,LF.DELTD, SEINFO.SYMBOL  " & ControlChars.CrLf _
            '                  & "FROM (SELECT  TO_CHAR(TXDATE,'" & gc_FORMAT_DATE & "') || TXNUM VOUCHERCD ,MAX(NAMT) NAMT, SUBSTR(ACCTNO, 11, 6) CODEID  " & ControlChars.CrLf _
            '                  & "FROM " & ATTR_MODULE & "TRANA WHERE TRIM(ACCTNO) = '" & ATTR_ACCTNO & "'  " & ControlChars.CrLf _
            '                  & "AND TXDATE>=TO_DATE('" & ATTR_FRDATE & "', '" & gc_FORMAT_DATE & "')  " & ControlChars.CrLf _
            '                  & "AND TXDATE<=TO_DATE('" & ATTR_TODATE & "', '" & gc_FORMAT_DATE & "')GROUP BY TXDATE ,TXNUM, SUBSTR(ACCTNO, 11, 6)) TRF, TLLOGALL LF, TLTX TX, SECURITIES_INFO SEINFO " & ControlChars.CrLf _
            '                  & "WHERE TRF.VOUCHERCD=TO_CHAR(LF.TXDATE,'" & gc_FORMAT_DATE & "') || LF.TXNUM AND LF.DELTD<>'Y' AND LF.TLTXCD=TX.TLTXCD  AND TRF.CODEID = SEINFO.CODEID ) LOGDATA ORDER BY TXDATE, TXNUM ) T1  " & ControlChars.CrLf _
            '                  & "WHERE RN BETWEEN " & v_intFrom & " AND " & v_intTo & " "

            'End If

            'v_lngErrCode = Me.txCoreMiscInquiry(pv_xmlDocument)
            'END TRUONGLD

            v_lngErrCode = Me.StoreHistoryAccount(pv_xmlDocument, OBJNAME_SE_SEMAST, v_strAFAccount, v_strCAREBY, v_strCodeid)

            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function HistoryCostprice(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "SE.Trans.HistoryAccount", v_strErrorMessage As String

        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE As Double, i As Integer
            Dim v_strCodeid, v_strAFAccount As String
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
                            v_strCodeid = v_strVALUE
                        Case "02" 'AFACCTNO
                            v_strAFAccount = v_strVALUE
                        Case "03" 'ACCTNO
                            ATTR_ACCTNO = v_strVALUE
                        Case "05" 'FRDATE
                            Me.ATTR_FRDATE = v_strVALUE
                        Case "06" 'TODATE
                            Me.ATTR_TODATE = v_strVALUE
                    End Select
                End With
            Next
            'Gá»?i hÃ m Ä‘á»ƒ láº¥y dá»¯ liá»‡u vá»?
            If v_strCodeid = "0000" Then
                ATTR_CMDMISCINQUIRY = "SELECT TXDATE, SUBSTR(ACCTNO,1,10) AFACCTNO, B.SYMBOL, ROUND(A.COSTPRICE) COSTPRICE FROM SECOSTPRICE A, SBSECURITIES B WHERE A.ACCTNO LIKE '" & v_strAFAccount & "%' AND TXDATE >=TO_DATE('" & ATTR_FRDATE & "', '" & gc_FORMAT_DATE & "') AND TXDATE <=TO_DATE('" & ATTR_TODATE & "', '" & gc_FORMAT_DATE & "') AND DELTD <> 'Y'" & ControlChars.CrLf _
                            & "AND SUBSTR(A.ACCTNO,11,6)=B.CODEID "
            Else
                ATTR_CMDMISCINQUIRY = "SELECT TXDATE, SUBSTR(ACCTNO,1,10) AFACCTNO, B.SYMBOL, ROUND(A.COSTPRICE) COSTPRICE FROM SECOSTPRICE A, SBSECURITIES B WHERE A.ACCTNO= '" & ATTR_ACCTNO & "' AND TXDATE >=TO_DATE('" & ATTR_FRDATE & "', '" & gc_FORMAT_DATE & "') AND TXDATE <=TO_DATE('" & ATTR_TODATE & "', '" & gc_FORMAT_DATE & "') AND DELTD <> 'Y'" & ControlChars.CrLf _
                            & "AND SUBSTR(A.ACCTNO,11,6)=B.CODEID "
            End If

            v_lngErrCode = Me.txCoreMiscInquiry(pv_xmlDocument)
            'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function AdjustCostprice(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "SE.Trans.DepositSecurities", v_strErrorMessage As String
        Dim v_obj As New DataAccess, v_ds As DataSet
        Dim v_strSQL As String = String.Empty, i As Integer
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE, v_dblQTTY As Double
            Dim v_strCODEID, v_strAPPLID, v_strSEACCTNO, v_strDESC As String
            Dim v_dblDEPOSITQTTY, v_dblAmount, v_dblQuantity, v_dblCostprice, v_dblPreQtty, v_dblNewCostprice As Double
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
                        Case "03" 'SEACCTNO
                            v_strSEACCTNO = v_strVALUE
                        Case "10" 'Quantity
                            v_dblQuantity = v_dblVALUE
                        Case "11" 'Adjust amt
                            v_dblAmount = v_dblVALUE
                    End Select
                End With
            Next

            If Not v_blnReversal Then
                'Check costprice
                v_strSQL = "SELECT * FROM SEMAST WHERE TRIM(ACCTNO)='" & v_strSEACCTNO & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If Not v_ds.Tables(0).Rows.Count > 0 Then
                    'Tráº£ vá»? mÃ£ lá»—i khÃ´ng tá»“n táº¡i mÃ£ há»£p Ä‘á»“ng
                    v_lngErrCode = ERR_SE_AFACCTNO_NOTFOUND
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                Else
                    v_dblCostprice = v_ds.Tables(0).Rows(0)("COSTPRICE")
                    v_dblPreQtty = v_ds.Tables(0).Rows(0)("PREVQTTY")
                    If v_dblPreQtty <= 0 Then
                        'Tráº£ vá»? mÃ£ lá»—i khong the dieu chinh gia von
                        v_lngErrCode = ERR_SE_CANNOT_ADJUST_COSTPRICE
                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                     & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                     & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                        Return v_lngErrCode
                    Else
                        v_dblNewCostprice = v_dblCostprice + v_dblAmount * v_dblQuantity / v_dblPreQtty
                        If v_dblNewCostprice < 0 Then
                            'Tráº£ vá»? mÃ£ lá»—i Dieu chinh gia von vuot pham vi
                            v_lngErrCode = ERR_SE_OUTRANGE_COSTPRICE_ADJUST
                            LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                         & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                         & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                            Return v_lngErrCode
                        End If
                    End If

                End If

                v_strSQL = "INSERT INTO SECOSTPRICE (AUTOID, ACCTNO, TXDATE, COSTPRICE, PREVCOSTPRICE, DCRAMT, DCRQTTY, DELTD) " & ControlChars.CrLf _
                & "SELECT SEQ_SECOSTPRICE.NEXTVAL, ACCTNO, TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'), " & ControlChars.CrLf _
                & "COSTPRICE+(" & v_dblQuantity * v_dblAmount & ")/PREVQTTY, ROUND(COSTPRICE,4), " & v_dblAmount & ", " & v_dblQuantity & ", 'N'" & ControlChars.CrLf _
                & "FROM SEMAST WHERE ACCTNO='" & v_strSEACCTNO & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                'ghi nhan luu ky
                v_strSQL = "UPDATE SEMAST SET COSTPRICE=COSTPRICE+(" & v_dblQuantity * v_dblAmount & ")/PREVQTTY WHERE ACCTNO='" & v_strSEACCTNO & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            Else
                'Xoa luu ky
                v_strSQL = "UPDATE SEMAST SET COSTPRICE=COSTPRICE-(" & v_dblQuantity * v_dblAmount & ")/PREVQTTY WHERE ACCTNO='" & v_strSEACCTNO & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                v_strSQL = "UPDATE SECOSTPRICE SET DELTD='Y' WHERE ACCTNO='" & v_strSEACCTNO & "' AND TXDATE =TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') AND DCRAMT=" & v_dblAmount & " AND DCRQTTY=" & v_dblAmount & ""
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            End If

            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function


    Private Function CheckOTCPrivateTransfer(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "SE.Trans.CheckOTCPrivateTransfer", v_strErrorMessage As String
        Dim v_obj As New DataAccess, v_ds As DataSet
        Dim v_strSQL As String = String.Empty, i As Integer
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE, v_dblQTTY, v_dblSUMSDTC, v_dblSUMDTC As Double
            Dim v_strCODEID, v_strTransferAFACCTNO, v_strReceiveACCTNO, v_strOVRRQS As String
            Dim v_dblQUANTITY, v_dblPARVALUE, v_dblAMT, v_dblCapitalAmount, v_dblMonitorRate As Double
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False
            v_obj.NewDBInstance(gc_MODULE_HOST)

            'Doc noi dung cua giao dich
            v_strOVRRQS = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
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
                        Case "02" 'Transfer account
                            v_strTransferAFACCTNO = v_strVALUE
                        Case "04" 'Receive account
                            v_strReceiveACCTNO = v_strVALUE
                        Case "10" 'QUANTITY
                            v_dblQUANTITY = v_dblVALUE
                        Case "11" 'PARVALUE
                            v_dblPARVALUE = v_dblVALUE
                    End Select
                End With
            Next

            'kiem tra
            If Not v_blnReversal Then
                'Kiem tra nguoi bi kiem soat chuyen nhuong
                v_strSQL = "SELECT COUNT(*) FROM AFMAST AF, ISSUER_MEMBER ISS, SBSECURITIES DTL " & ControlChars.CrLf _
                        & "WHERE (AF.ACCTNO= '" & v_strTransferAFACCTNO & "' OR ACCTNO='" & v_strReceiveACCTNO & "') " & ControlChars.CrLf _
                        & "AND AF.CUSTID=ISS.CUSTID AND ISS.ISSUERID=DTL.ISSUERID AND DTL.CODEID='" & v_strCODEID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    v_strOVRRQS = OVRRQS_ISSUERCONTROLLIST & v_strOVRRQS
                    v_lngErrCode = ERR_SA_CHECKER1_OVR
                End If
                'Kiem tra han muc monito rate
                v_strSQL = "SELECT MST.SHARECAPITAL, DTL.CHKRATE FROM ISSUERS MST, SBSECURITIES DTL " & ControlChars.CrLf _
                        & "WHERE MST.ISSUERID=DTL.ISSUERID AND DTL.CODEID='" & v_strCODEID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_dblCapitalAmount = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("SHARECAPITAL"))
                    v_dblMonitorRate = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("CHKRATE"))
                    If v_dblMonitorRate > 0 And v_dblMonitorRate < 100 And v_dblCapitalAmount > 0 Then
                        If (v_dblCapitalAmount * v_dblMonitorRate / 100) < v_dblQUANTITY * v_dblPARVALUE Then
                            v_strOVRRQS = OVRRQS_OVERMONITORRATE & v_strOVRRQS
                            v_lngErrCode = ERR_SA_CHECKER1_OVR
                        End If
                    End If
                Else
                    v_lngErrCode = ERR_SE_CODEID_NOTFOUND
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If
            End If
            pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value = v_strOVRRQS
            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        Finally
            v_obj = Nothing
        End Try
    End Function

    'Ham nay dung de them 1 dong vào SEWITHDRAWDTL khi thuc hien giao dich xin rut chung khoan 2200
    Private Function withdrawSecurities(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "SE.Trans.withdrawSecurities", v_strErrorMessage As String
        Dim v_obj As New DataAccess, v_ds As DataSet
        Dim v_strSQL As String = String.Empty, i As Integer
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE, v_dblQTTY, v_dblPRICE, v_dblWITHDRAW As Double
            Dim v_strCODEID, v_strAPPLID, v_strSEACCTNO, v_strQTTYTYPE, v_strDESC, v_strAFACCTNO, v_strTXDATETXNUM As String
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
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
                        Case "01" 'CODEID
                            v_strCODEID = v_strVALUE
                        Case "02" 'AFACCTNO
                            v_strAFACCTNO = v_strVALUE
                        Case "03" 'SEACCTNO
                            v_strSEACCTNO = v_strVALUE
                        Case "09" 'PRICE
                            v_dblPRICE = v_dblVALUE
                        Case "10" 'WITHDRAW
                            v_dblWITHDRAW = v_dblVALUE
                    End Select
                End With
            Next

            v_strTXDATETXNUM = v_strTXDATE & v_strTXNUM

            v_obj.NewDBInstance(gc_MODULE_HOST)
            If Not v_blnReversal Then
                'Kiá»ƒm tra cÃ³ báº£n ghi chÆ°a
                v_obj.NewDBInstance(gc_MODULE_HOST)
                v_strSQL = "SELECT * FROM SEWITHDRAWDTL WHERE TXDATETXNUM='" & v_strTXDATETXNUM & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    'Dung trong truong hop sua giao dich (neu co)
                    v_strSQL = "UPDATE SEWITHDRAWDTL SET WITHDRAW=" & v_dblWITHDRAW & ", STATUS = 'P' WHERE TXDATETXNUM='" & v_strTXDATETXNUM & "'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                Else
                    'Kiá»ƒm tra cÃ³ báº£n ghi chÆ°a
                    v_strSQL = "INSERT INTO SEWITHDRAWDTL (TXDATE, ACCTNO, CODEID, AFACCTNO, STATUS, PRICE, WITHDRAW, DELTD, TXNUM, TXDATETXNUM) VALUES (TO_DATE('" & v_strTXDATE & "','" & gc_FORMAT_DATE & "'), '" & v_strSEACCTNO & "', '" & v_strCODEID & "', '" & v_strAFACCTNO & "', 'P', " & v_dblPRICE & ", " & v_dblWITHDRAW & ", 'N', '" & v_strTXNUM & "', '" & v_strTXDATETXNUM & "')"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                End If
            Else
                'Reverse láº¡i sá»‘ dÆ°
                v_obj.NewDBInstance(gc_MODULE_HOST)
                v_strSQL = "SELECT * FROM SEWITHDRAWDTL WHERE TXDATETXNUM='" & v_strTXDATETXNUM & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                'Neu chua thuc hien giao dich 2292 thi moi cho xoa giao dich 2200
                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_strSQL = "UPDATE SEWITHDRAWDTL SET DELTD='Y' WHERE STATUS = 'P' AND DELTD = 'N' AND TXDATETXNUM='" & v_strTXDATETXNUM & "'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                Else
                    v_lngErrCode = ERR_SE_CONFIRMED_WITHDRAW
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If

            End If

            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    'Ham nay dùng cap nhat trang thai trong SEWITHDRAWDTL viec rut chung khoan da duoc thuc hien hoan tat: giao dich 2201
    Private Function withdrawSurelySecurities(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "SE.Trans.withdrawSurelySecurities", v_strErrorMessage As String
        Dim v_obj As New DataAccess, v_ds As DataSet
        Dim v_strSQL As String = String.Empty, i As Integer
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE As Double
            Dim v_strAPPLID, v_strSEACCTNO, v_strTXDATETXNUM As String
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
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
                        Case "03" 'SEACCTNO
                            v_strSEACCTNO = v_strVALUE
                        Case "07" 'TXDATETXNUM
                            v_strTXDATETXNUM = v_strVALUE
                    End Select
                End With
            Next
            v_obj.NewDBInstance(gc_MODULE_HOST)
            If Not v_blnReversal Then
                'Kiá»ƒm tra cÃ³ báº£n ghi chÆ°a
                v_obj.NewDBInstance(gc_MODULE_HOST)
                v_strSQL = "SELECT * FROM SEWITHDRAWDTL WHERE TXDATETXNUM='" & v_strTXDATETXNUM & "' and STATUS = 'A'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_strSQL = "UPDATE SEWITHDRAWDTL SET STATUS='C', PSTATUS=PSTATUS || STATUS WHERE TXDATETXNUM='" & v_strTXDATETXNUM & "' and STATUS = 'A'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                Else
                    v_lngErrCode = ERR_SE_INVALID_STATUS_SEWITHDRAWDTL
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If
            Else
                'Reverse láº¡i sá»‘ dÆ°
                v_obj.NewDBInstance(gc_MODULE_HOST)
                v_strSQL = "SELECT * FROM SEWITHDRAWDTL WHERE TXDATETXNUM='" & v_strTXDATETXNUM & "' and STATUS = 'C'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                'Chi cho xoa 2201 khi ma duoc thuc hien trong ngay (the hien o dk TXDATE cua Where clause)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_strSQL = "UPDATE SEWITHDRAWDTL SET STATUS = 'A', PSTATUS = substr(pstatus, 0, length(pstatus)-1) WHERE TXDATETXNUM='" & v_strTXDATETXNUM & "' and STATUS = 'C'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                Else
                    v_lngErrCode = ERR_SE_INVALID_2201_SEWITHDRAWDTL
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If

            End If

            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    'Ham nay dung de xac nhan giao dich rut CK, chuyen trang thai cua giao dich rut 2200 sang A, bang SEWITHDRAWDTL
    Private Function confirmWithdrawSecurities(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "SE.Trans.confirmWithdrawSecurities", v_strErrorMessage As String
        Dim v_obj As New DataAccess, v_ds As DataSet
        Dim v_strSQL As String = String.Empty, i As Integer
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE As Double
            Dim v_strAPPLID, v_strSEACCTNO, v_strTXDATETXNUM As String
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
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
                        Case "03" 'SEACCTNO
                            v_strSEACCTNO = v_strVALUE
                        Case "07" 'TXDATETXNUM
                            v_strTXDATETXNUM = v_strVALUE
                    End Select
                End With
            Next
            v_obj.NewDBInstance(gc_MODULE_HOST)
            If Not v_blnReversal Then
                'Kiá»ƒm tra cÃ³ báº£n ghi chÆ°a
                'v_obj.NewDBInstance(gc_MODULE_HOST)
                'v_strSQL = "SELECT * FROM SEWITHDRAWDTL WHERE ACCTNO='" & v_strSEACCTNO & "' and STATUS = 'P'"
                'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                'If v_ds.Tables(0).Rows.Count > 0 Then
                '    v_strSQL = "UPDATE SEWITHDRAWDTL SET STATUS='A', PSTATUS=PSTATUS || STATUS, DELTD='N' WHERE ACCTNO='" & v_strSEACCTNO & "' and STATUS = 'P'"
                '    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                'Else
                '    v_lngErrCode = ERR_SE_DULICATED_STATUS_SEWITHDRAWDTL
                '    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                '                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                '                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                Return v_lngErrCode
                'End If
            Else
                'Reverse láº¡i sá»‘ dÆ°
                'v_obj.NewDBInstance(gc_MODULE_HOST)
                'v_strSQL = "SELECT * FROM SEWITHDRAWDTL WHERE TXDATETXNUM='" & v_strTXDATETXNUM & "' and STATUS = 'A' and DELTD = 'N'"
                'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                ''Neu chua thuc hien giao dich 2201 thi moi cho xoa giao dich 2292
                'If v_ds.Tables(0).Rows.Count > 0 Then
                '    v_strSQL = "UPDATE SEWITHDRAWDTL SET DELTD='Y', STATUS = 'P', PSTATUS = substr(pstatus, 1, length(pstatus)-1) WHERE TXDATETXNUM='" & v_strTXDATETXNUM & "'"
                '    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                'Else
                '    v_lngErrCode = ERR_SE_CANNOT_DELETE_2292
                '    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                '                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                '                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                Return v_lngErrCode
                'End If

            End If

            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    'Khi revert giao dich 2200 thì can phai chuyen trang thai cua giao dich ay trong SEWITHDRAWDTL sang R (Reject)
    Private Function revertWithdrawSecurities(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "SE.Trans.revertWithdrawSecurities", v_strErrorMessage As String
        Dim v_obj As New DataAccess, v_ds As DataSet
        Dim v_strSQL As String = String.Empty, i As Integer
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE As Double
            Dim v_strAPPLID, v_strSEACCTNO, v_strTXTDATETXNUM As String
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
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
                        Case "03" 'SEACCTNO
                            v_strSEACCTNO = v_strVALUE
                        Case "07" 'TXTDATETXNUM
                            v_strTXTDATETXNUM = v_strVALUE
                    End Select
                End With
            Next
            v_obj.NewDBInstance(gc_MODULE_HOST)
            If Not v_blnReversal Then
                'Kiá»ƒm tra cÃ³ báº£n ghi chÆ°a
                v_obj.NewDBInstance(gc_MODULE_HOST)
                v_strSQL = "SELECT * FROM SEWITHDRAWDTL WHERE TXDATETXNUM ='" & v_strTXTDATETXNUM & "' and STATUS = 'P'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_strSQL = "UPDATE SEWITHDRAWDTL SET STATUS='R', PSTATUS=PSTATUS || STATUS, DELTD='N' WHERE TXDATETXNUM ='" & v_strTXTDATETXNUM & "' and STATUS = 'P'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                Else
                    v_lngErrCode = ERR_SE_DULICATED_STATUS_SEWITHDRAWDTL
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If
            Else
                'Reverse láº¡i sá»‘ dÆ°
                v_obj.NewDBInstance(gc_MODULE_HOST)
                v_strSQL = "SELECT * FROM SEWITHDRAWDTL WHERE TXDATETXNUM ='" & v_strTXTDATETXNUM & "' and STATUS = 'R'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_strSQL = "UPDATE SEWITHDRAWDTL SET DELTD='Y', STATUS = 'P', PSTATUS = substr(pstatus, 0, length(pstatus)-1) WHERE TXDATETXNUM ='" & v_strTXTDATETXNUM & "' and STATUS = 'R'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                Else
                    v_lngErrCode = ERR_SE_DULICATED_STATUS_SEWITHDRAWDTL
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If

            End If

            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    'Ham nay dung de revert lai giao dich 2292, chi don gian chuyen trang thai trong SEWITHDRAW tu A sang P
    Private Function revertConfirmWithdrawSecurities(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "SE.Trans.revertConfirmWithdrawSecurities", v_strErrorMessage As String
        Dim v_obj As New DataAccess, v_ds As DataSet
        Dim v_strSQL As String = String.Empty, i As Integer
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE As Double
            Dim v_strAPPLID, v_strSEACCTNO As String
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
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
                        Case "03" 'SEACCTNO
                            v_strSEACCTNO = v_strVALUE
                    End Select
                End With
            Next
            v_obj.NewDBInstance(gc_MODULE_HOST)
            If Not v_blnReversal Then
                'Kiá»ƒm tra cÃ³ báº£n ghi chÆ°a
                v_obj.NewDBInstance(gc_MODULE_HOST)
                v_strSQL = "SELECT * FROM SEWITHDRAWDTL WHERE ACCTNO='" & v_strSEACCTNO & "' and STATUS = 'A'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_strSQL = "UPDATE SEWITHDRAWDTL SET STATUS='P', PSTATUS=PSTATUS || STATUS, DELTD='N' WHERE ACCTNO='" & v_strSEACCTNO & "' and STATUS = 'A'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                Else
                    v_lngErrCode = ERR_SE_DULICATED_STATUS_SEWITHDRAWDTL
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If
            Else
                'Reverse láº¡i sá»‘ dÆ°
                v_obj.NewDBInstance(gc_MODULE_HOST)
                v_strSQL = "SELECT * FROM SEWITHDRAWDTL WHERE ACCTNO='" & v_strSEACCTNO & "' and STATUS = 'P' and substr(PSTATUS,length(pstatus),1) = 'A' and DELTD = 'N'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_strSQL = "UPDATE SEWITHDRAWDTL SET DELTD='Y', STATUS = 'A', PSTATUS = substr(pstatus, 0, length(pstatus)-1) WHERE ACCTNO='" & v_strSEACCTNO & "' and STATUS = 'P' and substr(PSTATUS,length(pstatus),1) = 'A' and DELTD = 'N'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                Else
                    v_lngErrCode = ERR_SE_CANNOT_DELETE_2294
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If

            End If

            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    'Ham nay dung de them 1 dong vào semortagedtl khi thuc hien giao dich 2251
    Private Function reserveMortageSecurities(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "SE.Trans.reserveMortageSecurities", v_strErrorMessage As String
        Dim v_obj As New DataAccess, v_ds As DataSet
        Dim v_strSQL As String = String.Empty, i As Integer
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE, v_dblQtty As Double
            Dim v_strCODEID, v_strAPPLID, v_strSEACCTNO, v_strAFACCTNO, v_strDESC, v_strSYMBOL As String
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
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
                        Case "01" 'CODEID
                            v_strCODEID = v_strVALUE
                        Case "02" 'AFACCTNO
                            v_strAFACCTNO = v_strVALUE
                        Case "03" 'SEACCTNO
                            v_strSEACCTNO = v_strVALUE
                        Case "10" 'MORTAGE AMOUNT
                            v_dblQtty = v_dblVALUE
                    End Select
                End With
            Next
            v_obj.NewDBInstance(gc_MODULE_HOST)
            If Not v_blnReversal Then
                'Kiá»ƒm tra cÃ³ báº£n ghi chÆ°a
                v_strSQL = " SELECT SYMBOL FROM SECURITIES_INFO WHERE CODEID='" & v_strCODEID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_strSYMBOL = v_ds.Tables(0).Rows(0)("SYMBOL")
                End If
                v_strSQL = "INSERT INTO SEMORTAGEDTL (TXDATE,TXNUM, ACCTNO, AFACCTNO, CODEID, MORTAGE, STATUS, DELTD, TXDATETXNUM) VALUES (TO_DATE('" & v_strTXDATE & "','" & gc_FORMAT_DATE & "'),'" & v_strTXNUM & "', '" & v_strSEACCTNO & "', '" & v_strAFACCTNO & "', '" & v_strSYMBOL & "', " & v_dblQtty & ", 'P', 'N', '" & v_strTXDATE & v_strTXNUM & "')"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            Else
                'Neu da lam 2295, tuc là status trong semortagedtl = A thi khong cho xoa.
                v_strSQL = " SELECT STATUS FROM SEMORTAGEDTL WHERE STATUS = 'A' AND TXNUM='" & v_strTXNUM & "' AND TXDATE=TO_DATE('" & v_strTXDATE & "','" & gc_FORMAT_DATE & "')"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_lngErrCode = ERR_SE_CANNOT_DELETE_2251
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                Else
                    v_strSQL = "UPDATE SEMORTAGEDTL SET DELTD='Y', STATUS = 'P', PSTATUS = SUBSTR(PSTATUS, 1, LENGTH(PSTATUS) - 1) WHERE TXNUM='" & v_strTXNUM & "' AND TXDATE=TO_DATE('" & v_strTXDATE & "','" & gc_FORMAT_DATE & "')"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                End If
            End If

            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
#End Region

#Region " Overrides Methods "

#End Region

End Class
