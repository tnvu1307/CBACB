Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Configuration
Imports System.Xml
Imports System.Net
Imports System.Data

'Imports System.EnterpriseServices
'<JustInTimeActivation(False), _
'Transaction(TransactionOption.Supported), _
'ObjectPooling(Enabled:=True, MinPoolSize:=30)> _
Public Class Trans
    Inherits CoreBusiness.txMaster

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_MODULE = "RM"
    End Sub

#Region " Implement functions"

    Overrides Function txImpUpdate(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        'Xac dinh ma giao dich tuong ung
        Dim v_lngErrorCode As Long = ERR_SYSTEM_OK
        Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
        Dim v_strTLTXCD As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLTXCD), Xml.XmlAttribute).Value)
        Select Case v_strTLTXCD
            Case gc_RM_CHANGE_BANK_STATUS
                v_lngErrorCode = CoreBankUpdateBankStatus(pv_xmlDocument)
            Case gc_RM_HOLD_DIRECT
                v_lngErrorCode = CoreBankHold(pv_xmlDocument)
            Case gc_RM_UNHOLD_DIRECT
                v_lngErrorCode = CoreBankUnHold(pv_xmlDocument)
            Case Else
                v_lngErrorCode = BasedCoreBankProcess(pv_xmlDocument)
                'Case gc_RM_RCV_HOLD, gc_RM_RCV_UNHOLD, gc_RM_REVERT_HOLD, gc_RM_REVERT_UNHOLD, gc_RM_PROCESS_COLLECT_DEPOFEE
                '    v_lngErrorCode = BasedCoreBankProcess(pv_xmlDocument)
                'Case gc_RM_HOLD
                '    v_lngErrorCode = CoreBankHold(pv_xmlDocument)
                'Case gc_RM_UNHOLD
                '    v_lngErrorCode = CoreBankUnHold(pv_xmlDocument)
                'Case gc_RM_TRANSFER, gc_RM_TRANSFER_2
                '    v_lngErrorCode = CoreBankExecuteCAEvent(pv_xmlDocument)
                'Case gc_RM_TRANSFER_OTHER, gc_RM_TRANSFER_OTHER_2
                '    v_lngErrorCode = CoreBankExecuteTransfer(pv_xmlDocument)

                'Case gc_RM_BUY_AMOUNT_TRANSFER
                '    v_lngErrorCode = CoreBankBuyAmountTransfer(pv_xmlDocument)
                'Case gc_RM_BUY_FEE_TRANSFER
                '    v_lngErrorCode = CoreBankBuyFeeTransfer(pv_xmlDocument)
                'Case gc_RM_SALE_AMOUNT_TRANSFER
                '    v_lngErrorCode = CoreBankSaleAmountTransfer(pv_xmlDocument)
                'Case gc_RM_SALE_FEE_TRANSFER
                '    v_lngErrorCode = CoreBankSaleFeeTransfer(pv_xmlDocument)
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

        'Select Case v_strTLTXCD
        '    Case gc_RM_INQUIRY
        '        v_lngErrorCode = InqAccount(pv_xmlDocument)
        '    Case gc_RM_HOLD, gc_RM_HOLD_DIRECT
        '        v_lngErrorCode = CheckCoreBankHold(pv_xmlDocument)
        '        'Case gc_OD_PLACENORMALBUYORDER, gc_OD_PLACENORMALSELLORDER, gc_OD_PLACENORMALBUYORDER_ADVANCED, gc_OD_PLACENORMALSELLORDER_ADVANCED
        '        'v_lngErrorCode = CheckAutoHold(pv_xmlDocument)
        'End Select
        ''ContextUtil.SetComplete()
        'Tra ve ma loi
        Return v_lngErrorCode
    End Function

    Overrides Function txImpMisc(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        'Xac dinh ma giao dich tuong ung
        Dim v_lngErrorCode As Long
        Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
        Dim v_strTLTXCD As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLTXCD), Xml.XmlAttribute).Value)

        'Select Case v_strTLTXCD
        '    Case gc_RM_INQUIRY
        '        v_lngErrorCode = InqAccount(pv_xmlDocument)
        '    Case gc_RM_HISTORY
        '        v_lngErrorCode = HistoryAccount(pv_xmlDocument)
        '    Case gc_RM_INQUIRYAUTO
        '        v_lngErrorCode = CoreBankGetBalance(pv_xmlDocument)
        'End Select
        ''ContextUtil.SetComplete()
        'Tra ve ma loi
        Return v_lngErrorCode
    End Function

#End Region

#Region " Private functions "

    Private Function BasedCoreBankProcess(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "RM.Trans.BasedCoreBankProcess", v_strErrorMessage As String
        Dim v_ds As DataSet
        Dim v_obj As New DataAccess
        Dim v_objParam As New StoreParameter
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strFLDCD, v_strFLDTYPE, v_strVALUE As String, v_dblVALUE As Double, i As Integer
            Dim v_strSQL, v_strTLTXCD, v_strAcctno, v_strREFTXDATE, v_strREFTXNUM, v_strTXDATE, v_strTXNUM, v_strLOGDTLID, v_strREQID, v_strDONESTS, v_strTRFLOGSTS As String
            Dim v_strOBJTYPE, v_strOBJNAME, v_strREFCODE, v_strREFMSG As String
            v_obj.NewDBInstance(gc_MODULE_HOST)
            v_strTLTXCD = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value
            v_strREFTXDATE = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            v_strREFTXNUM = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            v_strREFMSG = v_strREFTXDATE & "." & v_strREFTXNUM

            v_strDONESTS = "0"
            v_strTRFLOGSTS = "C"
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
                        Case "03" 'Acctno
                            v_strAcctno = v_strVALUE
                        Case "20" 'Txdate
                            v_strTXDATE = v_strVALUE
                        Case "21" 'Txnum
                            v_strTXNUM = v_strVALUE
                        Case "22" 'ReqquestID
                            v_strREQID = v_strVALUE
                        Case "23" 'TRFLOGSTS
                            v_strTRFLOGSTS = v_strVALUE
                        Case "24" 'DONESTS
                            v_strDONESTS = v_strVALUE
                    End Select
                End With
            Next

            Select Case v_strTLTXCD
                Case gc_RM_RCV_HOLD
                    'Xử lý cho trường hợp là Hold và sinh ra từ số hiệu lệnh của FOMAST thì gọi hàm đẩy lệnh luôn
                    v_strSQL = "SELECT REQID, BANKCODE, BANKACCT, REFCODE, OBJTYPE, OBJNAME, TRFCODE, TXDATE, OBJKEY, AFACCTNO FROM CRBTXREQ WHERE REQID=" & v_strREQID
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count > 0 Then
                        v_strOBJTYPE = v_ds.Tables(0).Rows(0)("OBJTYPE").ToString().Trim
                        v_strOBJNAME = v_ds.Tables(0).Rows(0)("OBJNAME").ToString().Trim
                        v_strREFCODE = v_ds.Tables(0).Rows(0)("REFCODE").ToString().Trim
                    End If

                    'Đẩy lệnh
                    If v_strOBJTYPE = "V" And v_strOBJNAME = "FOMAST" Then
                        'Đánh dấu lệnh sẵn sàng đẩy đi
                        v_strSQL = "UPDATE FOMAST SET DIRECT='N', STATUS='P' WHERE ACCTNO='" + v_strREFCODE + "'"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    End If
                    v_strSQL = "UPDATE CRBTXREQ SET STATUS='C', REFTXDATE=TO_DATE('" & v_strTXDATE & "','DD/MM/RRRR'), REFTXNUM='" & v_strTXNUM & "' WHERE REQID=" & v_strREQID

                Case gc_RM_RCV_UNHOLD
                    v_strSQL = "UPDATE CRBTXREQ SET STATUS='C', REFTXDATE=TO_DATE('" & v_strTXDATE & "','DD/MM/RRRR'), REFTXNUM='" & v_strTXNUM & "' WHERE REQID=" & v_strREQID

                Case gc_RM_REVERT_HOLD
                    v_strSQL = "SELECT REQID, BANKCODE, BANKACCT, REFCODE, OBJTYPE, OBJNAME, TRFCODE, TXDATE, OBJKEY, AFACCTNO FROM CRBTXREQ WHERE REQID=" & v_strREQID
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count > 0 Then
                        v_strOBJTYPE = v_ds.Tables(0).Rows(0)("OBJTYPE").ToString().Trim
                        v_strOBJNAME = v_ds.Tables(0).Rows(0)("OBJNAME").ToString().Trim
                        v_strREFCODE = v_ds.Tables(0).Rows(0)("REFCODE").ToString().Trim
                    End If
                    If v_strOBJTYPE = "V" And v_strOBJNAME = "FOMAST" Then
                        'Lệnh bị từ chối
                        v_strSQL = "UPDATE FOMAST SET FEEDBACKMSG='REVERT HOLD: " & v_strREFMSG & "', STATUS='R' WHERE ACCTNO='" + v_strREFCODE + "'"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    End If
                    v_strSQL = "UPDATE CRBTXREQ SET STATUS='E', REFTXDATE=TO_DATE('" & v_strTXDATE & "','DD/MM/RRRR'), REFTXNUM='" & v_strTXNUM & "' WHERE REQID=" & v_strREQID

                Case gc_RM_REVERT_UNHOLD
                    v_strSQL = "UPDATE CRBTXREQ SET STATUS='E', REFTXDATE=TO_DATE('" & v_strTXDATE & "','DD/MM/RRRR'), REFTXNUM='" & v_strTXNUM & "' WHERE REQID=" & v_strREQID

                Case Else
                    'Gọi StoredProcedure để xử lý chung khi có tín hiệu phản hồi từ ngân hàng
                    Dim v_arrPara(5) As StoreParameter
                    v_objParam = New StoreParameter
                    v_objParam.ParamName = "p_err_code"
                    v_objParam.ParamValue = "0"
                    v_objParam.ParamDirection = ParameterDirection.Output
                    v_objParam.ParamSize = 10
                    v_objParam.ParamType = GetType(System.String).Name
                    v_arrPara(0) = v_objParam

                    v_objParam = New StoreParameter
                    v_objParam.ParamName = "p_txdate"
                    v_objParam.ParamValue = v_strREFTXDATE
                    v_objParam.ParamDirection = ParameterDirection.Input
                    v_objParam.ParamSize = 10
                    v_objParam.ParamType = GetType(System.String).Name
                    v_arrPara(1) = v_objParam

                    v_objParam = New StoreParameter
                    v_objParam.ParamName = "p_txnum"
                    v_objParam.ParamValue = v_strREFTXNUM
                    v_objParam.ParamDirection = ParameterDirection.Input
                    v_objParam.ParamSize = 10
                    v_objParam.ParamType = GetType(System.String).Name
                    v_arrPara(2) = v_objParam

                    v_objParam = New StoreParameter
                    v_objParam.ParamName = "p_tltxcd"
                    v_objParam.ParamValue = v_strTLTXCD
                    v_objParam.ParamDirection = ParameterDirection.Input
                    v_objParam.ParamSize = 4
                    v_objParam.ParamType = GetType(System.String).Name
                    v_arrPara(3) = v_objParam

                    v_objParam = New StoreParameter
                    v_objParam.ParamName = "p_reqid"
                    v_objParam.ParamValue = v_strREQID
                    v_objParam.ParamDirection = ParameterDirection.Input
                    v_objParam.ParamSize = 50
                    v_objParam.ParamType = GetType(System.String).Name
                    v_arrPara(4) = v_objParam

                    v_objParam = New StoreParameter
                    v_objParam.ParamName = "p_flagprocess"
                    v_objParam.ParamValue = IIf(v_strDONESTS = "1", "Y", "N")
                    v_objParam.ParamDirection = ParameterDirection.Input
                    v_objParam.ParamSize = 1
                    v_objParam.ParamType = GetType(System.String).Name
                    v_arrPara(5) = v_objParam

                    v_lngErrCode = v_obj.ExecuteOracleStored("SP_EXEC_PROCESS_CRBTRFLOGDTL", v_arrPara, 0)
                    v_strSQL = String.Empty
            End Select

            If v_strSQL.Length > 0 Then
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End If

            'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        Finally
            v_objParam = Nothing
            v_obj = Nothing
        End Try
    End Function

    Private Function CheckCoreBankHold(ByRef pv_xmlDocument As Xml.XmlDocument) As Long


    End Function

    Private Function CoreBankUpdateBankStatus(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "RM.Trans.HistoryAccount", v_strErrorMessage As String
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE As Double, i As Integer
        Dim v_strSQL, v_strBankCode, v_strStatus As String
        Dim v_obj As New DataAccess

        Try
            v_obj.NewDBInstance(gc_MODULE_HOST)
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
                        Case "01" 'BankCode
                            v_strBankCode = v_strVALUE
                        Case "02" 'Status
                            v_strStatus = v_strVALUE
                    End Select
                End With
            Next

            'Doc trang thai hien tai cua CRBTRFLOG
            v_strSQL = "UPDATE CRBDEFBANK SET STATUS='" & v_strStatus & "' WHERE BANKCODE='" & v_strBankCode & "'"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        Finally
            v_obj = Nothing
        End Try
    End Function

    Private Function HistoryAccount(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "RM.Trans.HistoryAccount", v_strErrorMessage As String

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
                            Me.ATTR_FRDATE = v_strVALUE
                        Case "06" 'TODATE
                            Me.ATTR_TODATE = v_strVALUE
                    End Select
                End With
            Next

            ATTR_CMDMISCINQUIRY = "SELECT * FROM  " & ControlChars.CrLf _
               & "(SELECT LF.TXDATE, LF.TXNUM, LF.BUSDATE, LF.TLTXCD, LF.TXDESC, LF.MSGAMT AMT,TX.TXDESC TLTXDESC,TX.EN_TXDESC TLTXEN_DESC,LF.DELTD,TLP.TLNAME MAKER,nvl(TLP1.TLNAME,TLP.TLNAME) CHECKER  " & ControlChars.CrLf _
               & "FROM (SELECT DISTINCT TO_CHAR(TXDATE,'" & gc_FORMAT_DATE & "') || TXNUM VOUCHERCD  " & ControlChars.CrLf _
               & "FROM CITRAN WHERE ACCTNO='" & ATTR_ACCTNO & "'  " & ControlChars.CrLf _
               & "AND TXDATE>=TO_DATE('" & ATTR_FRDATE & "', '" & gc_FORMAT_DATE & "')  " & ControlChars.CrLf _
               & "AND TXDATE<=TO_DATE('" & ATTR_TODATE & "', '" & gc_FORMAT_DATE & "')) TRF, TLLOG LF, TLTX TX,TLPROFILES TLP,TLPROFILES TLP1  " & ControlChars.CrLf _
               & "WHERE TRF.VOUCHERCD=TO_CHAR(TXDATE,'" & gc_FORMAT_DATE & "') || TXNUM AND DELTD<>'Y' AND LF.TLTXCD=TX.TLTXCD AND LF.TLTXCD LIKE '66__' AND LF.TLID =TLP.TLID (+) AND  LF.OFFID=TLP1.TLID (+) " & ControlChars.CrLf _
               & "UNION ALL  " & ControlChars.CrLf _
               & "SELECT LF.TXDATE, LF.TXNUM, LF.BUSDATE, LF.TLTXCD, LF.TXDESC, LF.MSGAMT AMT,TX.TXDESC TLTXDESC,TX.EN_TXDESC TLTXEN_DESC,LF.DELTD,TLP.TLNAME MAKER,nvl(TLP1.TLNAME,TLP.TLNAME) CHECKER  " & ControlChars.CrLf _
               & "FROM (SELECT DISTINCT TO_CHAR(TXDATE,'" & gc_FORMAT_DATE & "') || TXNUM VOUCHERCD  " & ControlChars.CrLf _
               & "FROM CITRANA WHERE ACCTNO='" & ATTR_ACCTNO & "'  " & ControlChars.CrLf _
               & "AND TXDATE>=TO_DATE('" & ATTR_FRDATE & "', '" & gc_FORMAT_DATE & "')  " & ControlChars.CrLf _
               & "AND TXDATE<=TO_DATE('" & ATTR_TODATE & "', '" & gc_FORMAT_DATE & "')) TRF, TLLOGALL LF, TLTX TX,TLPROFILES TLP,TLPROFILES TLP1 " & ControlChars.CrLf _
               & "WHERE TRF.VOUCHERCD=TO_CHAR(TXDATE,'" & gc_FORMAT_DATE & "') || TXNUM AND DELTD<>'Y' AND LF.TLTXCD=TX.TLTXCD AND LF.TLTXCD LIKE '66__' AND LF.TLID =TLP.TLID (+) AND  LF.OFFID=TLP1.TLID (+)) LOGDATA  " & ControlChars.CrLf _
               & "ORDER BY TXDATE, TXNUM "
            v_lngErrCode = Me.txCoreMiscInquiry(pv_xmlDocument)
            'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function InqAccount(ByRef pv_xmlDocument As Xml.XmlDocument) As Long

    End Function

    Private Function CoreBankHold(ByRef pv_xmlDocument As Xml.XmlDocument) As Long

    End Function

    Private Function CoreBankUnHold(ByRef pv_xmlDocument As Xml.XmlDocument) As Long


    End Function

    Private Function CoreBankUpdate(ByRef pv_xmlDocument As Xml.XmlDocument) As Long

    End Function

    Private Function CoreBankComplete(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "RM.Trans.HistoryAccount", v_strErrorMessage As String

        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE As Double, i As Integer
            Dim v_strSQL, v_strAcctno, v_strTXDATE, v_strTXNUM As String
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            'Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            'Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value

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
                        Case "03" 'Acctno
                            v_strAcctno = v_strVALUE
                        Case "20" 'Txdate
                            v_strTXDATE = v_strVALUE
                        Case "21" 'Txnum
                            v_strTXNUM = v_strVALUE
                    End Select
                End With
            Next

            v_strSQL = "UPDATE AITRANLOG SET STATUS='C' WHERE TXNUM='" & v_strTXNUM & "' and TXDATE=TO_DATE('" & v_strTXDATE & "','" & gc_FORMAT_DATE & "')"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function CoreBankGetBalance(ByRef pv_xmlDocument As Xml.XmlDocument) As Long

    End Function

#End Region

#Region "Bank Connection"

    Public Function CorebankRegUnreg(ByVal pv_strRegType As String, ByVal pv_strBankCode As String, ByVal pv_strBankAcctno As String,
                                     ByVal pv_strCustodyCD As String, ByVal pv_strIDCode As String) As Long

    End Function

    Public Function CorebankCheckAcct(ByVal pv_strBankCode As String, ByVal pv_strBankAcctno As String, ByVal pv_strCustodyCD As String, ByVal pv_strIDCODE As String) As Long

    End Function

#End Region

#Region " Utils Methods "

    Private Function GetErrorDesc(ByVal pv_lngErrCode As Long, ByVal pv_strLanguage As String) As String
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "RM.Trans.HistoryAccount", v_strErrorMessage As String
        Dim v_strRet, v_strSQL As String, v_ds As DataSet
        Dim v_obj As New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)
        Try
            v_strSQL = "SELECT ERRDESC, EN_ERRDESC FROM DEFERROR WHERE ERRNUM=" & pv_lngErrCode
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                If pv_strLanguage = "VN" Then
                    v_strRet = v_ds.Tables(0).Rows(0)("ERRDESC").ToString()
                Else
                    v_strRet = v_ds.Tables(0).Rows(0)("EN_ERRDESC").ToString()
                End If
            Else
                v_strRet = "[" & pv_lngErrCode.ToString() & "]-Unknown error"
            End If
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        Finally
            v_ds = Nothing
        End Try
        Return v_strRet
    End Function

#End Region

End Class
