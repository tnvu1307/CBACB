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
        ATTR_MODULE = "CA"
    End Sub

#Region " Implement functions"
    Overrides Function txImpUpdate(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        'Xác định mã giao dịch tương ứng '''''''''''''''''''''''''''''''
        Dim v_lngErrorCode As Long = ERR_SYSTEM_OK
        Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
        Dim v_strTLTXCD As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLTXCD), Xml.XmlAttribute).Value)
        Select Case v_strTLTXCD
            Case gc_CA_APPROVE_CAEVENT
                v_lngErrorCode = ApproveCAEvent(pv_xmlDocument)
            Case gc_CA_REJECT_CAEVENT
                v_lngErrorCode = RejectCAEvent(pv_xmlDocument)
            Case gc_CA_SEND_CAEVENT, gc_CA_AUTO_SEND_CAEVENT
                v_lngErrorCode = SendCAEvent(pv_xmlDocument)
            Case gc_CA_AUTO_EXECUTE_CAEVENT
                v_lngErrorCode = ExecuteCAEvent(pv_xmlDocument)
            Case gc_CA_ADJUST_AFMAST_CAEVENT
                v_lngErrorCode = AdjustContractCAEvent(pv_xmlDocument)
            Case gc_CA_EXECUTE_AFMAST_CAEVENT, gc_CA_AUTO_EXECUTE_CHANGE_TRADING_CAEVENT, gc_CA_AUTO_EXECUTE_AFMAST_CAEVENT, gc_CA_AUTO_EXE_BOND_TO_SHARE, gc_CA_EXECUTE_CI_CAEVENT, gc_CA_EXECUTE_CI_CAEVENT_NOTTAX, gc_CA_EXECUTE_SE_CAEVENT, gc_CA_EXECUTE_CI_CAEVENT_PIT_AT_ISSUER
                v_lngErrorCode = ExecuteContractCAEvent(pv_xmlDocument)
            Case gc_CA_SEND_AFMAST_CAEVENT, gc_CA_AUTO_SEND_AFMAST_CAEVENT, gc_CA_AUTO_SEND_CHANGE_TRADING_CAEVENT
                v_lngErrorCode = SendContractCAEvent(pv_xmlDocument)
            Case gc_CA_STOCK_RIGHTOFF, gc_CA_TELE_STOCK_RIGHTOFF, gc_CA_STOCK_RIGHTOFF_NOT_BLOCK_MONEY
                v_lngErrorCode = Transfer_3384(pv_xmlDocument)
            Case gc_CA_CANCEL_STOCK_RIGHTOFF
                v_lngErrorCode = CancelStockRightoff(pv_xmlDocument)
            Case gc_CA_CANCEL_STOCK_RIGHTOFF_NO_MONEY
                v_lngErrorCode = CancelStockRightoffNoMoney(pv_xmlDocument)
            Case gc_CA_TRANSFER
                v_lngErrorCode = Transfer_3382(pv_xmlDocument)
            Case gc_CA_OUTWARD_TRANSFER
                v_lngErrorCode = Transfer_3383(pv_xmlDocument)
            Case gc_CA_INWARD_TRANSFER
                v_lngErrorCode = Transfer_3385(pv_xmlDocument)
            Case gc_CA_TRADE_RETAIL
                v_lngErrorCode = TRADE_RETAIL(pv_xmlDocument)
            Case gc_CA_BEFORE_EXECUTE
                v_lngErrorCode = ConfirmExecute(pv_xmlDocument)
            Case gc_CA_COMPLETE
                v_lngErrorCode = COMPLETE_CA(pv_xmlDocument)
            Case gc_CA_CUT_STOCK_EXCUTE
                v_lngErrorCode = CUT_STOCK_EXCUTE(pv_xmlDocument)
        End Select
        Return v_lngErrorCode
    End Function

    Overrides Function txImpCheck(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrorCode As Long = ERR_SYSTEM_OK
        Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
        Dim v_strTLTXCD As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLTXCD), Xml.XmlAttribute).Value)
        Select Case v_strTLTXCD
            Case gc_CA_APPROVE_CAEVENT
                v_lngErrorCode = CheckBeforeCAEvent(pv_xmlDocument)
            Case gc_CA_TRADE_RETAIL
                v_lngErrorCode = Check_3381(pv_xmlDocument)
            Case gc_CA_TRANSFER
                v_lngErrorCode = Check_3382(pv_xmlDocument)
            Case gc_CA_OUTWARD_TRANSFER
                v_lngErrorCode = Check_3383(pv_xmlDocument)
            Case gc_CA_STOCK_RIGHTOFF, gc_CA_TELE_STOCK_RIGHTOFF, gc_CA_STOCK_RIGHTOFF_NOT_BLOCK_MONEY
                v_lngErrorCode = Check_3384(pv_xmlDocument)
            Case gc_CA_INWARD_TRANSFER
                v_lngErrorCode = Check_3385(pv_xmlDocument)
            Case gc_CA_CANCEL_STOCK_RIGHTOFF
                v_lngErrorCode = Check_3386(pv_xmlDocument)
            Case gc_CA_BEFORE_EXECUTE 'Dien comment
                v_lngErrorCode = Check_3390(pv_xmlDocument)
            Case gc_CA_CANCEL_STOCK_RIGHTOFF_NO_MONEY
                v_lngErrorCode = Check_3393(pv_xmlDocument)
            Case gc_CA_ADJUST_AFMAST_CAEVENT
                v_lngErrorCode = Check3378(pv_xmlDocument)


        End Select
        'Trả v�? mã lỗi
        Return v_lngErrorCode
    End Function

    Overrides Function txImpMisc(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        'Xác định mã giao dịch tương ứng
        Dim v_lngErrorCode As Long
        Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
        Dim v_strTLTXCD As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLTXCD), Xml.XmlAttribute).Value)
        'Select Case v_strTLTXCD
        '    Case gc_SE_OPENACCOUNT
        '        v_lngErrorCode = OpenAccount(pv_xmlDocument)
        '    Case gc_SE_ACCOUNTINQUIRY
        '        v_lngErrorCode = InquiryAccount(pv_xmlDocument)
        '    Case gc_SE_ACCOUNTHISTORY
        '        v_lngErrorCode = HistoryAccount(pv_xmlDocument)
        'End Select
        'Trả v�? mã lỗi
        Return v_lngErrorCode
    End Function
#End Region

#Region " Private functions"
    Private Function Check3378(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = Me.ATTR_MODULE & ".Trans.Check3378", v_strErrorMessage As String
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strSQL, v_strFLDCD, v_strFLDTYPE, v_strVALUE As String, v_dblVALUE As Double, i As Integer
        Dim v_strAFACCTNO As String = ""
        Dim v_strNumber As Long
        Dim v_ds As DataSet
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
                        Case "03" 'CIACCTNO
                            v_strAFACCTNO = v_strVALUE
                    End Select
                End With
            Next

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
            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
    Private Function ApproveCAEvent(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CA.Trans.ApproveCAEvent", v_strErrorMessage As String
        Dim v_strSQLTmp As String = String.Empty, v_strSQL As String = String.Empty, i As Integer
        Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE, v_lngCLEARDAY As Double
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strCAMASTID, v_strCODEID, v_strEXCODEID, v_strCATYPE, v_strREPORTDATE, v_strACTIONDATE, v_strDUEDATE, v_strSTATUS, v_strOPTCODEID, v_strOPTSYMBOl, v_strFRTRADEPLACE, v_strTOTRADEPLACE As String
            Dim v_dblEXPRICE, v_dblINTERESTPERIOD, v_dblPARVALUE As Double
            Dim v_strEXRATE, v_strRIGHTOFFRATE, v_strDEVIDENTRATE, v_strDEVIDENTSHARES, v_strSPLITRATE, v_strINTERESTRATE As String
            Dim v_strLEFT_EXRATE, v_strLEFT_RIGHTOFFRATE, v_strLEFT_DEVIDENTRATE, v_strLEFT_DEVIDENTSHARES, v_strLEFT_SPLITRATE, v_strLEFT_INTERESTRATE As String
            Dim v_strRIGHT_EXRATE, v_strRIGHT_RIGHTOFFRATE, v_strRIGHT_DEVIDENTRATE, v_strRIGHT_DEVIDENTSHARES, v_strRIGHT_SPLITRATE, v_strRIGHT_INTERESTRATE, v_strTOCODEID As String
            Dim v_strQTTYEXP, v_strAMTEXP, v_strAQTTYEXP, v_strAAMTEXP, v_strROUNDTYPE, v_strROUNDVALUE, v_strREQTTYEXP, v_strREAQTTYEXP As String
            Dim v_dtREPORTDATE, v_dtTXDATE, v_dtACTIONDATE As DateTime
            Dim v_ds As DataSet
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_strBRID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXTIME As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTIME).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_blnREVERSAL As Boolean = IIf(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value = "Y", True, False)
            v_dtTXDATE = DDMMYYYY_SystemDate(v_strTXDATE)
            'LAY NOI DUNG GIAO DICH
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(gf_Numberic(.InnerText), gf_Cdbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If
                    Select Case v_strFLDCD
                        Case "03" 'CAMASTID
                            v_strCAMASTID = v_strVALUE
                        Case "06"
                            v_dtREPORTDATE = DDMMYYYY_SystemDate(v_strVALUE)
                        Case "07"
                            v_dtACTIONDATE = DDMMYYYY_SystemDate(v_strVALUE)
                    End Select
                End With
            Next

            'Kiem tra ngay thuc hien GD phai nam trong khoang tu ngay REPORTDATE den ngay ACTIONDATE
            If DDMMYYYY_SystemDate(v_strTXDATE) <= v_dtREPORTDATE Then
                v_lngErrCode = ERR_CA_TXDATE_INVALID
                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                             & "Error code: Reversal." & v_blnREVERSAL.ToString() & "." & v_strCAMASTID & "." & vbNewLine _
                             & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                Return v_lngErrCode
            End If
            If Not v_blnREVERSAL Then   'Nếu là duyệt: Tạo CASCHD tương ứng
                'XOA DU LIEU CU
                v_strSQL = "UPDATE CASCHD SET DELTD='Y' WHERE CAMASTID='" & v_strCAMASTID & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                'TAO DU LIEU MOI
                If Len(v_strCAMASTID) > 0 Then
                    'LAY THONG TIN DOT THUC HIEN QUYEN
                    v_strSQL = "SELECT * FROM CAMAST WHERE CAMASTID='" & v_strCAMASTID & "'"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count > 0 Then
                        v_strCODEID = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("CODEID")))
                        v_strEXCODEID = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("EXCODEID")))
                        v_strCATYPE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("CATYPE")))
                        v_strREPORTDATE = gf_CorrectStringField(Format(v_ds.Tables(0).Rows(0)("REPORTDATE"), gc_FORMAT_DATE))
                        v_strACTIONDATE = gf_CorrectStringField(Format(v_ds.Tables(0).Rows(0)("ACTIONDATE"), gc_FORMAT_DATE))
                        v_strDUEDATE = gf_CorrectStringField(Format(v_ds.Tables(0).Rows(0)("DUEDATE"), gc_FORMAT_DATE))
                        v_dblEXPRICE = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("EXPRICE"))
                        v_dblPARVALUE = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("PARVALUE"))
                        v_strEXRATE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("EXRATE")))
                        v_strLEFT_EXRATE = gf_FormatNumberToSring(v_strEXRATE, 0)
                        v_strRIGHT_EXRATE = gf_FormatNumberToSring(v_strEXRATE, 1)
                        v_strRIGHTOFFRATE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("RIGHTOFFRATE")))
                        v_strLEFT_RIGHTOFFRATE = gf_FormatNumberToSring(v_strRIGHTOFFRATE, 0)
                        v_strRIGHT_RIGHTOFFRATE = gf_FormatNumberToSring(v_strRIGHTOFFRATE, 1)
                        v_strDEVIDENTRATE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("DEVIDENTRATE")))
                        v_strLEFT_DEVIDENTRATE = gf_FormatNumberToSring(v_strDEVIDENTRATE, 0)
                        v_strRIGHT_DEVIDENTRATE = gf_FormatNumberToSring(v_strDEVIDENTRATE, 1)
                        v_strDEVIDENTSHARES = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("DEVIDENTSHARES")))
                        v_strLEFT_DEVIDENTSHARES = gf_FormatNumberToSring(v_strDEVIDENTSHARES, 0)
                        v_strRIGHT_DEVIDENTSHARES = gf_FormatNumberToSring(v_strDEVIDENTSHARES, 1)
                        v_strSPLITRATE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("SPLITRATE")))
                        v_strLEFT_SPLITRATE = gf_FormatNumberToSring(v_strSPLITRATE, 0)
                        v_strRIGHT_SPLITRATE = gf_FormatNumberToSring(v_strSPLITRATE, 1)
                        v_strINTERESTRATE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("INTERESTRATE")))
                        v_strLEFT_INTERESTRATE = gf_FormatNumberToSring(v_strINTERESTRATE, 0)
                        v_strRIGHT_INTERESTRATE = gf_FormatNumberToSring(v_strINTERESTRATE, 1)
                        v_dblINTERESTPERIOD = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("INTERESTPERIOD"))
                        v_strSTATUS = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("STATUS")))
                        v_strROUNDTYPE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("ROUNDTYPE")))
                        v_strOPTCODEID = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("OPTCODEID")))
                        v_strOPTSYMBOl = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("OPTSYMBOl")))
                        v_strFRTRADEPLACE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("FRTRADEPLACE")))
                        v_strTOTRADEPLACE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("TOTRADEPLACE")))
                        v_strTOCODEID = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("TOCODEID")))

                        v_strQTTYEXP = "0"
                        v_strAMTEXP = "0"
                        v_strAQTTYEXP = "0"
                        v_strAAMTEXP = "0"
                        v_strREQTTYEXP = "0"
                        v_strREAQTTYEXP = "0"
                        ' Tinh gia tri cho CK, tien cho ve.

                        '(SE.TRADE + SE.BLOCKED + se.secured + SE.WITHDRAW + SE.MORTAGE +NVL(SE.netting,0) + NVL(SE.dtoclose,0)
                        Select Case v_strCATYPE
                            Case gc_CA_CATYPE_KIND_DIVIDENd 'Kind dividend
                                'v_strQTTYEXP = "FLOOR((SUM(MST.TRADE + MST.MARGIN + MST.MORTAGE + MST.BLOCKED + MST.SECURED + MST.REPO+ MST.NETTING + MST.DTOCLOSE+MST.WITHDRAW)-SUM(TR.AMOUNT))*" & v_strEXRATE & ")"
                                'v_strROUNDTYPE = 0
                                v_strQTTYEXP = "FLOOR(((SUM(MST.TRADE + MST.MARGIN + MST.MORTAGE + MST.BLOCKED + MST.SECURED + MST.REPO + MST.NETTING+ MST.DTOCLOSE+MST.WITHDRAW)-SUM(TR.AMOUNT))*" & v_strRIGHT_DEVIDENTSHARES & ")/" & v_strLEFT_DEVIDENTSHARES & ")"
                                v_strAMTEXP = "(" & v_dblEXPRICE & "*MOD((SUM(MST.TRADE + MST.MARGIN + MST.MORTAGE + MST.BLOCKED + MST.SECURED + MST.REPO+ MST.NETTING+ MST.DTOCLOSE+MST.WITHDRAW)-SUM(TR.AMOUNT))*" & v_strRIGHT_DEVIDENTSHARES & " ," & v_strLEFT_DEVIDENTSHARES & "))/" & v_strLEFT_DEVIDENTSHARES
                            Case gc_CA_CATYPE_CASH_DIVIDENd 'Cash dividend(+QTTY,AMT)
                                v_strAMTEXP = "(SUM(MST.TRADE + MST.MARGIN + MST.MORTAGE + MST.BLOCKED + MST.SECURED + MST.REPO + MST.NETTING+ MST.DTOCLOSE+MST.WITHDRAW)-SUM(TR.AMOUNT))*MAX(SYM.PARVALUE)/100*" & v_strDEVIDENTRATE
                                v_strROUNDTYPE = 0
                            Case gc_CA_CATYPE_PAYING_INTERREST_BONd
                                v_strAMTEXP = "(SUM(MST.TRADE + MST.MARGIN + MST.MORTAGE + MST.BLOCKED + MST.SECURED + MST.REPO + MST.NETTING+ MST.DTOCLOSE+MST.WITHDRAW)-SUM(TR.AMOUNT))*MAX(SYM.PARVALUE)/100*" & v_strDEVIDENTRATE
                                v_strROUNDTYPE = 0
                            Case gc_CA_CATYPE_STOCK_DIVIDENd 'Stock dividend (+QTTY,AMT)
                                v_strQTTYEXP = "FLOOR(((SUM(MST.TRADE + MST.MARGIN + MST.MORTAGE + MST.BLOCKED + MST.SECURED + MST.REPO + MST.NETTING+ MST.DTOCLOSE+MST.WITHDRAW)-SUM(TR.AMOUNT))*" & v_strRIGHT_DEVIDENTSHARES & ")/" & v_strLEFT_DEVIDENTSHARES & ")"
                                v_strAMTEXP = "(" & v_dblEXPRICE & "*MOD((SUM(MST.TRADE + MST.MARGIN + MST.MORTAGE + MST.BLOCKED + MST.SECURED + MST.REPO+ MST.NETTING+ MST.DTOCLOSE+MST.WITHDRAW)-SUM(TR.AMOUNT))*" & v_strRIGHT_DEVIDENTSHARES & " ," & v_strLEFT_DEVIDENTSHARES & "))/" & v_strLEFT_DEVIDENTSHARES

                            Case gc_CA_CATYPE_PRINCIPLE_BONd
                                v_strAMTEXP = "(SUM(MST.TRADE + MST.MARGIN + MST.MORTAGE + MST.BLOCKED + MST.SECURED + MST.REPO + MST.NETTING+ MST.DTOCLOSE+MST.WITHDRAW)-SUM(TR.AMOUNT))*" & v_dblEXPRICE
                                v_strAQTTYEXP = "(SUM(MST.TRADE + MST.MARGIN + MST.MORTAGE + MST.BLOCKED + MST.SECURED + MST.REPO+ MST.NETTING+ MST.DTOCLOSE+MST.WITHDRAW)-SUM(TR.AMOUNT))"


                            Case gc_CA_CATYPE_KIND_STOCK
                                v_strQTTYEXP = "FLOOR(((SUM(MST.TRADE + MST.MARGIN + MST.MORTAGE + MST.BLOCKED + MST.SECURED + MST.REPO + MST.NETTING+ MST.DTOCLOSE+MST.WITHDRAW)-SUM(TR.AMOUNT))*" & v_strRIGHT_DEVIDENTSHARES & ")/" & v_strLEFT_DEVIDENTSHARES & ")"
                                v_strAMTEXP = "(" & v_dblEXPRICE & "*MOD((SUM(MST.TRADE + MST.MARGIN + MST.MORTAGE + MST.BLOCKED + MST.SECURED + MST.REPO+ MST.NETTING+ MST.DTOCLOSE+MST.WITHDRAW)-SUM(TR.AMOUNT))*" & v_strRIGHT_DEVIDENTSHARES & " ," & v_strLEFT_DEVIDENTSHARES & "))/" & v_strLEFT_DEVIDENTSHARES

                            Case gc_CA_CATYPE_CONVERT_STOCK
                                v_strQTTYEXP = "FLOOR(((SUM(MST.TRADE + MST.MARGIN + MST.MORTAGE + MST.BLOCKED + MST.SECURED + MST.REPO + MST.NETTING+ MST.DTOCLOSE+MST.WITHDRAW)-SUM(TR.AMOUNT))*" & v_strRIGHT_DEVIDENTSHARES & ")/" & v_strLEFT_DEVIDENTSHARES & ")"
                                v_strAQTTYEXP = "(SUM(MST.TRADE + MST.MARGIN + MST.MORTAGE + MST.BLOCKED + MST.SECURED + MST.REPO+ MST.NETTING+ MST.DTOCLOSE+MST.WITHDRAW)-SUM(TR.AMOUNT))"
                                v_strAMTEXP = "(" & v_dblEXPRICE & "*MOD((SUM(MST.TRADE + MST.MARGIN + MST.MORTAGE + MST.BLOCKED + MST.SECURED + MST.REPO+ MST.NETTING+ MST.DTOCLOSE+MST.WITHDRAW)-SUM(TR.AMOUNT))*" & v_strRIGHT_DEVIDENTSHARES & " ," & v_strLEFT_DEVIDENTSHARES & "))/" & v_strLEFT_DEVIDENTSHARES

                            Case gc_CA_CATYPE_KIND_OTHER_STOCK
                                v_strQTTYEXP = "FLOOR(((SUM(MST.TRADE + MST.MARGIN + MST.MORTAGE + MST.BLOCKED + MST.SECURED + MST.REPO + MST.NETTING+ MST.DTOCLOSE+MST.WITHDRAW)-SUM(TR.AMOUNT))*" & v_strRIGHT_DEVIDENTSHARES & ")/" & v_strLEFT_DEVIDENTSHARES & ")"
                                v_strAMTEXP = "(" & v_dblEXPRICE & "*MOD((SUM(MST.TRADE + MST.MARGIN + MST.MORTAGE + MST.BLOCKED + MST.SECURED + MST.REPO+ MST.NETTING+ MST.DTOCLOSE+MST.WITHDRAW)-SUM(TR.AMOUNT))*" & v_strRIGHT_DEVIDENTSHARES & " ," & v_strLEFT_DEVIDENTSHARES & "))/" & v_strLEFT_DEVIDENTSHARES


                            Case gc_CA_CATYPE_STOCK_SPLIT 'Stock Split(+ QTTY,AMT)
                                v_strQTTYEXP = "TRUNC((SUM(MST.TRADE + MST.MARGIN + MST.MORTAGE + MST.BLOCKED + MST.SECURED + MST.REPO + MST.NETTING+ MST.DTOCLOSE+MST.WITHDRAW)-SUM(TR.AMOUNT)) / (" & v_strSPLITRATE & ") - " & ControlChars.CrLf _
                                             & "(SUM(MST.TRADE + MST.MARGIN + MST.MORTAGE + MST.BLOCKED + MST.SECURED + MST.REPO + MST.NETTING+ MST.DTOCLOSE+MST.WITHDRAW)-SUM(TR.AMOUNT)), " & v_strROUNDTYPE & ")"

                                v_strAMTEXP = v_dblEXPRICE & "*((SUM(MST.TRADE + MST.MARGIN + MST.MORTAGE + MST.BLOCKED + MST.SECURED + MST.REPO + MST.NETTING+ MST.DTOCLOSE+MST.WITHDRAW)-SUM(TR.AMOUNT)) / (" & v_strSPLITRATE & ") - " & ControlChars.CrLf _
                                             & "(SUM(MST.TRADE + MST.MARGIN + MST.MORTAGE + MST.BLOCKED + MST.SECURED + MST.REPO + MST.NETTING+ MST.DTOCLOSE+MST.WITHDRAW)-SUM(TR.AMOUNT)) - " & ControlChars.CrLf _
                                             & v_strQTTYEXP & ")"
                                'v_strROUNDTYPE = 0 'linh comment

                            Case gc_CA_CATYPE_STOCK_MERGE 'Stock Merge(-AQTTY,+AMT)
                                v_strAQTTYEXP = "((SUM(MST.TRADE + MST.MARGIN + MST.MORTAGE + MST.BLOCKED + MST.SECURED + MST.REPO+ MST.NETTING+ MST.DTOCLOSE+MST.WITHDRAW)-SUM(TR.AMOUNT)) - " & ControlChars.CrLf _
                                    & "TRUNC((SUM(MST.TRADE + MST.MARGIN + MST.MORTAGE + MST.BLOCKED + MST.SECURED + MST.REPO+ MST.NETTING+ MST.DTOCLOSE+MST.WITHDRAW)-SUM(TR.AMOUNT)) / (" & v_strSPLITRATE & "), " & v_strROUNDTYPE & "))"

                                v_strAMTEXP = v_dblEXPRICE & "*( " & v_strAQTTYEXP & " - ((SUM(MST.TRADE + MST.MARGIN + MST.MORTAGE + MST.BLOCKED + MST.SECURED + MST.REPO + MST.NETTING+ MST.DTOCLOSE+MST.WITHDRAW)-SUM(TR.AMOUNT)) - " & ControlChars.CrLf _
                                    & "(SUM(MST.TRADE + MST.MARGIN + MST.MORTAGE + MST.BLOCKED + MST.SECURED + MST.REPO + MST.NETTING+ MST.DTOCLOSE+MST.WITHDRAW)-SUM(TR.AMOUNT)) / (" & v_strSPLITRATE & "))) "
                                'v_strROUNDTYPE = 0 'linh comment

                            Case gc_CA_CATYPE_STOCK_RIGHTOFF 'Stock Rightoff(+QTTY,-AAMT)
                                v_strQTTYEXP = "FLOOR(((SUM(MST.TRADE + MST.MARGIN + MST.MORTAGE + MST.BLOCKED + MST.SECURED + MST.REPO+ MST.NETTING+ MST.DTOCLOSE+MST.WITHDRAW)-SUM(TR.AMOUNT))*" & v_strRIGHT_RIGHTOFFRATE & "*" & v_strRIGHT_EXRATE & ")/(" & v_strLEFT_RIGHTOFFRATE & "*" & v_strLEFT_EXRATE & "))"
                                v_strAAMTEXP = v_dblEXPRICE & " * TRUNC( FLOOR((( SUM(MST.TRADE + MST.MARGIN + MST.MORTAGE + MST.BLOCKED + MST.SECURED + MST.REPO+ MST.NETTING+ MST.DTOCLOSE+MST.WITHDRAW)-SUM(TR.AMOUNT))*" & v_strRIGHT_RIGHTOFFRATE & "*" & v_strRIGHT_EXRATE & ")/(" & v_strLEFT_RIGHTOFFRATE & "*" & v_strLEFT_EXRATE & ")), " & v_strROUNDTYPE & ")"

                            Case gc_CA_CATYPE_BOND_PAY_INTEREST 'Bond pay interest, Lai suat theo thang, chu ky theo nam (+AMT)
                                v_strAMTEXP = "(SUM(MST.TRADE + MST.MARGIN + MST.MORTAGE + MST.BLOCKED + MST.SECURED + MST.REPO+ MST.NETTING+ MST.DTOCLOSE+MST.WITHDRAW)-SUM(TR.AMOUNT))*MAX(SYM.PARVALUE)/(100*12)*" & v_strINTERESTRATE & "*" & v_dblINTERESTPERIOD
                                v_strROUNDTYPE = 0
                            Case gc_CA_CATYPE_BOND_PAY_INTEREST_PRINCIPAL 'Bond pay interest & prin, Lai suat theo thang, chu ky theo nam (+AMT)
                                v_strAMTEXP = "(SUM(MST.TRADE + MST.MARGIN + MST.MORTAGE + MST.BLOCKED + MST.SECURED + MST.REPO+ MST.NETTING+ MST.DTOCLOSE+MST.WITHDRAW)-SUM(TR.AMOUNT))*MAX(SYM.PARVALUE) + " & ControlChars.CrLf _
                                    & "(SUM(MST.TRADE + MST.MARGIN + MST.MORTAGE + MST.BLOCKED + MST.SECURED + MST.REPO+ MST.NETTING+ MST.DTOCLOSE+MST.WITHDRAW)-SUM(TR.AMOUNT))*MAX(SYM.PARVALUE)/(100*12)*" & v_strINTERESTRATE & "*" & v_dblINTERESTPERIOD
                                v_strROUNDTYPE = 0
                            Case gc_CA_CATYPE_CONVERT_BOND_TO_SHARE 'Convert bond to share (+QTTY Share,-AQTTY Bound)
                                v_strQTTYEXP = "(SUM(MST.TRADE + MST.MARGIN + MST.MORTAGE + MST.BLOCKED + MST.SECURED + MST.REPO+ MST.NETTING+ MST.DTOCLOSE+MST.WITHDRAW)-SUM(TR.AMOUNT))/(" & v_strEXRATE & ")"
                                v_strAQTTYEXP = "(SUM(MST.TRADE + MST.MARGIN + MST.MORTAGE + MST.BLOCKED + MST.SECURED + MST.REPO+ MST.NETTING+ MST.DTOCLOSE+MST.WITHDRAW)-SUM(TR.AMOUNT))"
                                'v_strROUNDTYPE = 0 'linh comment

                            Case gc_CA_CATYPE_CONVERT_RIGHT_TO_SHARE 'Convert Right to share (+QTTY Share, -AQTTY Right)
                                v_strQTTYEXP = "(SUM(MST.TRADE + MST.MARGIN + MST.MORTAGE + MST.BLOCKED + MST.SECURED + MST.REPO+ MST.NETTING+ MST.DTOCLOSE+MST.WITHDRAW)-SUM(TR.AMOUNT))"
                                v_strAQTTYEXP = "(SUM(MST.TRADE + MST.MARGIN + MST.MORTAGE + MST.BLOCKED + MST.SECURED + MST.REPO+ MST.NETTING+ MST.DTOCLOSE+MST.WITHDRAW)-SUM(TR.AMOUNT))"
                                v_strROUNDTYPE = 0
                            Case gc_CA_CATYPE_CHANGE_TRADING_PLACE_STOCK 'Change trading place (+QTTY )
                                v_strQTTYEXP = "0"
                                v_strAMTEXP = "0"
                            Case Else 'EXCEPTION

                        End Select
                        'So chung khoan le
                        v_strREQTTYEXP = "(" & v_strQTTYEXP & " - TRUNC(" & v_strQTTYEXP & "," & v_strROUNDTYPE & "))"
                        If v_strCATYPE = gc_CA_CATYPE_CONVERT_BOND_TO_SHARE Or gc_CA_CATYPE_CONVERT_STOCK Then
                            v_strREAQTTYEXP = "(" & v_strAQTTYEXP & " - TRUNC(" & v_strAQTTYEXP & " ," & 0 & " ))"
                        Else
                            v_strREAQTTYEXP = "(" & v_strAQTTYEXP & " - TRUNC(" & v_strAQTTYEXP & " ," & v_strROUNDTYPE & " ))"
                        End If
                        'So chung khoan da lam tron
                        v_strQTTYEXP = "TRUNC(" & v_strQTTYEXP & "," & v_strROUNDTYPE & ")"
                        If v_strCATYPE = gc_CA_CATYPE_CONVERT_BOND_TO_SHARE Or gc_CA_CATYPE_CONVERT_STOCK Then
                            v_strAQTTYEXP = "TRUNC(" & v_strAQTTYEXP & "," & 0 & ")"
                        Else
                            v_strAQTTYEXP = "TRUNC(" & v_strAQTTYEXP & "," & v_strROUNDTYPE & ")"
                        End If
                        If v_strCATYPE = gc_CA_CATYPE_STOCK_DIVIDENd Or v_strCATYPE = gc_CA_CATYPE_KIND_DIVIDENd Then
                            v_strAMTEXP = "ROUND(" & v_strAMTEXP & " + " & v_strREQTTYEXP & " * " & v_dblEXPRICE & ")"
                        Else
                            v_strAMTEXP = v_strAMTEXP & " + " & v_strREQTTYEXP & " * " & v_dblEXPRICE
                        End If
                        v_strAAMTEXP = v_strAAMTEXP & " + " & v_strREAQTTYEXP & "*" & v_dblEXPRICE

                        '    v_strAAMTEXP = v_dblEXPRICE & "*" & v_strQTTYEXP & " + " & v_strREAQTTYEXP & "*" & v_dblEXPRICE


                        v_strREQTTYEXP = 0
                        v_strREAQTTYEXP = 0

                        If v_strCATYPE = gc_CA_CATYPE_STOCK_RIGHTOFF Then

                            v_strSQL = "INSERT INTO CASCHD (AUTOID, CAMASTID, AFACCTNO, CODEID, EXCODEID, BALANCE, QTTY, AMT, AQTTY, AAMT, STATUS,REQTTY,REAQTTY,RETAILBAL,PBALANCE, PQTTY,PAAMT)  " & ControlChars.CrLf _
                              & "SELECT SEQ_CASCHD.NEXTVAL,DAT.* " & ControlChars.CrLf _
                              & "FROM(SELECT MAX(CA.CAMASTID) CAMASTID, MST.AFACCTNO, MAX(SYM.CODEID) CODEID, MAX(CA.OPTCODEID) EXCODEID, " & ControlChars.CrLf _
                              & "0 BALANCE, 0  QTTY, 0 AMT, 0 AQTTY, 0 AAMT, 'A' STATUS," & v_strREQTTYEXP & "  REQTTY," & v_strREAQTTYEXP & "  REAQTTY " & ControlChars.CrLf _
                              & ",trunc ((SUM(MST.TRADE + MST.MARGIN + MST.MORTAGE + MST.BLOCKED + MST.SECURED + MST.REPO+ MST.NETTING+ MST.DTOCLOSE+MST.WITHDRAW) - SUM(TR.AMOUNT))*" & v_strRIGHT_EXRATE & "/" & v_strLEFT_EXRATE & ") RETAILBAL,  " & ControlChars.CrLf _
                              & "trunc ((SUM(MST.TRADE + MST.MARGIN + MST.MORTAGE + MST.BLOCKED + MST.SECURED + MST.REPO+ MST.NETTING+ MST.DTOCLOSE+MST.WITHDRAW) - SUM(TR.AMOUNT))*" & v_strRIGHT_EXRATE & "/" & v_strLEFT_EXRATE & ") PBALANCE,  " & ControlChars.CrLf _
                              & v_strQTTYEXP & "  PQTTY,  ROUND(" & v_strAAMTEXP & ",0) PAAMT" & ControlChars.CrLf _
                              & "FROM SBSECURITIES SYM, CAMAST CA, SEMAST MST,  " & ControlChars.CrLf _
                              & "( SELECT MST.ACCTNO, NVL(DTL.AMT,0) AMOUNT FROM SEMAST MST LEFT JOIN " & ControlChars.CrLf _
                              & "(select DTL.ACCTNO, sum(DTL.AMT) amt From " & ControlChars.CrLf _
                              & "(SELECT TR.ACCTNO, SUM((CASE WHEN TX.TXTYPE='D' THEN -TR.NAMT WHEN TX.TXTYPE='C' THEN TR.NAMT ELSE 0 END)) AMT  " & ControlChars.CrLf _
                              & "FROM APPTX TX, SETRAN TR ,TLLOG TL " & ControlChars.CrLf _
                              & "WHERE TX.APPTYPE='SE' AND TRIM(TX.FIELD) IN ('TRADE','MARGIN','MORTAGE','BLOCKED','SECURED','REPO','NETTING','DTOCLOSE','WITHDRAW')  " & ControlChars.CrLf _
                              & "AND TR.TXDATE=TL.TXDATE AND TR.TXNUM=TL.TXNUM AND TX.TXTYPE IN ('C', 'D') AND TL.DELTD <> 'Y' " & ControlChars.CrLf _
                              & "AND TX.TXCD=TR.TXCD AND TL.BUSDATE > TO_DATE('" & v_strREPORTDATE & "', 'dd/MM/yyyy') GROUP BY TR.ACCTNO  " & ControlChars.CrLf _
                              & "UNION ALL  " & ControlChars.CrLf _
                              & "SELECT TR.ACCTNO, SUM((CASE WHEN TX.TXTYPE='D' THEN -TR.NAMT WHEN TX.TXTYPE='C' THEN TR.NAMT ELSE 0 END)) AMT  " & ControlChars.CrLf _
                              & "FROM APPTX TX, SETRANA TR ,TLLOGALL TL  " & ControlChars.CrLf _
                              & "WHERE TX.APPTYPE='SE' AND TRIM(TX.FIELD) IN ('TRADE','MARGIN','MORTAGE','BLOCKED','SECURED','REPO','NETTING','DTOCLOSE','WITHDRAW')  " & ControlChars.CrLf _
                              & "AND TR.TXDATE=TL.TXDATE AND TR.TXNUM=TL.TXNUM AND TX.TXTYPE IN ('C', 'D') AND TL.DELTD <> 'Y' " & ControlChars.CrLf _
                              & "AND TX.TXCD=TR.TXCD AND TL.BUSDATE > TO_DATE('" & v_strREPORTDATE & "', 'dd/MM/yyyy') GROUP BY TR.ACCTNO)DTL group by DTL.acctno) DTL ON MST.ACCTNO=DTL.ACCTNO) TR " & ControlChars.CrLf _
                              & "WHERE MST.CODEID=SYM.CODEID AND CA.CODEID = SYM.CODEID AND SYM.CODEID = '" & v_strCODEID & "' AND MST.ACCTNO = TR.ACCTNO  AND CA.CAMASTID ='" & v_strCAMASTID & "'" & ControlChars.CrLf _
                              & "GROUP BY MST.AFACCTNO) DAT WHERE DAT.PBALANCE>0"


                        ElseIf v_strCATYPE = gc_CA_CATYPE_KIND_OTHER_STOCK Then

                            v_strSQL = "INSERT INTO CASCHD (AUTOID, CAMASTID, AFACCTNO, CODEID, EXCODEID, BALANCE, QTTY, AMT, AQTTY, AAMT, STATUS,REQTTY,REAQTTY,RETAILBAL)  " & ControlChars.CrLf _
                                                    & "SELECT SEQ_CASCHD.NEXTVAL,DAT.* " & ControlChars.CrLf _
                                                        & "FROM(SELECT MAX(CA.CAMASTID) CAMASTID, MST.AFACCTNO, '" & v_strTOCODEID & "' CODEID, MAX(CA.EXCODEID) EXCODEID, " & ControlChars.CrLf _
                                                        & "(SUM(MST.TRADE + MST.MARGIN + MST.MORTAGE + MST.BLOCKED + MST.SECURED + MST.REPO+ MST.NETTING+ MST.DTOCLOSE+MST.WITHDRAW) - SUM(TR.AMOUNT)) BALANCE, " & ControlChars.CrLf _
                                                        & v_strQTTYEXP & "  QTTY, ROUND(" & v_strAMTEXP & ",0) AMT, 0 AQTTY, ROUND(" & v_strAAMTEXP & ",0) AAMT, 'A' STATUS," & v_strREQTTYEXP & "  REQTTY," & v_strREAQTTYEXP & "  REAQTTY " & ControlChars.CrLf _
                                                        & ", 0  RETAILBAL  " & ControlChars.CrLf _
                                                        & "FROM SBSECURITIES SYM, CAMAST CA, SEMAST MST,  " & ControlChars.CrLf _
                                                        & "(SELECT MST.ACCTNO, NVL(DTL.AMT,0) AMOUNT FROM SEMAST MST LEFT JOIN " & ControlChars.CrLf _
                                                        & "(select DTL.ACCTNO, sum(DTL.AMT) amt From " & ControlChars.CrLf _
                                                        & "(SELECT TR.ACCTNO, SUM((CASE WHEN TX.TXTYPE='D' THEN -TR.NAMT WHEN TX.TXTYPE='C' THEN TR.NAMT ELSE 0 END)) AMT  " & ControlChars.CrLf _
                                                        & "FROM APPTX TX, SETRAN TR ,TLLOG TL " & ControlChars.CrLf _
                                                        & "WHERE TX.APPTYPE='SE' AND TRIM(TX.FIELD) IN ('TRADE','MARGIN','MORTAGE','BLOCKED','SECURED','REPO','NETTING','DTOCLOSE','WITHDRAW')  " & ControlChars.CrLf _
                                                        & "AND TR.TXDATE=TL.TXDATE AND TR.TXNUM=TL.TXNUM AND TX.TXTYPE IN ('C', 'D') AND TL.DELTD <> 'Y' " & ControlChars.CrLf _
                                                        & "AND TX.TXCD=TR.TXCD AND TL.BUSDATE > TO_DATE('" & v_strREPORTDATE & "', 'dd/MM/yyyy') GROUP BY TR.ACCTNO  " & ControlChars.CrLf _
                                                        & "UNION ALL  " & ControlChars.CrLf _
                                                        & "SELECT TR.ACCTNO, SUM((CASE WHEN TX.TXTYPE='D' THEN -TR.NAMT WHEN TX.TXTYPE='C' THEN TR.NAMT ELSE 0 END)) AMT  " & ControlChars.CrLf _
                                                        & "FROM APPTX TX, SETRANA TR ,TLLOGALL TL  " & ControlChars.CrLf _
                                                        & "WHERE TX.APPTYPE='SE' AND TRIM(TX.FIELD) IN ('TRADE','MARGIN','MORTAGE','BLOCKED','SECURED','REPO','NETTING','DTOCLOSE','WITHDRAW')  " & ControlChars.CrLf _
                                                        & "AND TR.TXDATE=TL.TXDATE AND TR.TXNUM=TL.TXNUM AND TX.TXTYPE IN ('C', 'D') AND TL.DELTD <> 'Y' " & ControlChars.CrLf _
                                                        & "AND TX.TXCD=TR.TXCD AND TL.BUSDATE > TO_DATE('" & v_strREPORTDATE & "', 'dd/MM/yyyy') GROUP BY TR.ACCTNO) DTL group by DTL.acctno) DTL ON MST.ACCTNO=DTL.ACCTNO) TR " & ControlChars.CrLf _
                                                        & "WHERE MST.CODEID=SYM.CODEID AND CA.CODEID = SYM.CODEID AND SYM.CODEID = '" & v_strCODEID & "' AND MST.ACCTNO = TR.ACCTNO  AND CA.CAMASTID ='" & v_strCAMASTID & "'" & ControlChars.CrLf _
                                                        & "GROUP BY MST.AFACCTNO) DAT WHERE DAT.BALANCE>0"

                        ElseIf v_strCATYPE = gc_CA_CATYPE_CONVERT_STOCK Then

                            v_strSQL = "INSERT INTO CASCHD (AUTOID, CAMASTID, AFACCTNO, CODEID, EXCODEID, BALANCE, QTTY, AMT, AQTTY, AAMT, STATUS,REQTTY,REAQTTY,RETAILBAL)  " & ControlChars.CrLf _
                                                    & "SELECT SEQ_CASCHD.NEXTVAL,DAT.* " & ControlChars.CrLf _
                                                        & "FROM(SELECT MAX(CA.CAMASTID) CAMASTID, MST.AFACCTNO, '" & v_strTOCODEID & "' CODEID, MAX(CA.CODEID) EXCODEID, " & ControlChars.CrLf _
                                                        & "(SUM(MST.TRADE + MST.MARGIN + MST.MORTAGE + MST.BLOCKED + MST.SECURED + MST.REPO+ MST.NETTING+ MST.DTOCLOSE+MST.WITHDRAW) - SUM(TR.AMOUNT)) BALANCE, " & ControlChars.CrLf _
                                                        & v_strQTTYEXP & "  QTTY, ROUND(" & v_strAMTEXP & ",0) AMT, " & v_strAQTTYEXP & " AQTTY, ROUND(" & v_strAAMTEXP & ",0) AAMT, 'A' STATUS," & v_strREQTTYEXP & "  REQTTY," & v_strREAQTTYEXP & "  REAQTTY " & ControlChars.CrLf _
                                                        & ", 0  RETAILBAL  " & ControlChars.CrLf _
                                                        & "FROM SBSECURITIES SYM, CAMAST CA, SEMAST MST,  " & ControlChars.CrLf _
                                                        & "(SELECT MST.ACCTNO, NVL(DTL.AMT,0) AMOUNT FROM SEMAST MST LEFT JOIN " & ControlChars.CrLf _
                                                        & "(select DTL.ACCTNO, sum(DTL.AMT) amt From " & ControlChars.CrLf _
                                                        & "(SELECT TR.ACCTNO, SUM((CASE WHEN TX.TXTYPE='D' THEN -TR.NAMT WHEN TX.TXTYPE='C' THEN TR.NAMT ELSE 0 END)) AMT  " & ControlChars.CrLf _
                                                        & "FROM APPTX TX, SETRAN TR ,TLLOG TL " & ControlChars.CrLf _
                                                        & "WHERE TX.APPTYPE='SE' AND TRIM(TX.FIELD) IN ('TRADE','MARGIN','MORTAGE','BLOCKED','SECURED','REPO','NETTING','DTOCLOSE','WITHDRAW')  " & ControlChars.CrLf _
                                                        & "AND TR.TXDATE=TL.TXDATE AND TR.TXNUM=TL.TXNUM AND TX.TXTYPE IN ('C', 'D') AND TL.DELTD <> 'Y' " & ControlChars.CrLf _
                                                        & "AND TX.TXCD=TR.TXCD AND TL.BUSDATE > TO_DATE('" & v_strREPORTDATE & "', 'dd/MM/yyyy') GROUP BY TR.ACCTNO  " & ControlChars.CrLf _
                                                        & "UNION ALL  " & ControlChars.CrLf _
                                                        & "SELECT TR.ACCTNO, SUM((CASE WHEN TX.TXTYPE='D' THEN -TR.NAMT WHEN TX.TXTYPE='C' THEN TR.NAMT ELSE 0 END)) AMT  " & ControlChars.CrLf _
                                                        & "FROM APPTX TX, SETRANA TR ,TLLOGALL TL  " & ControlChars.CrLf _
                                                        & "WHERE TX.APPTYPE='SE' AND TRIM(TX.FIELD) IN ('TRADE','MARGIN','MORTAGE','BLOCKED','SECURED','REPO','NETTING','DTOCLOSE','WITHDRAW')  " & ControlChars.CrLf _
                                                        & "AND TR.TXDATE=TL.TXDATE AND TR.TXNUM=TL.TXNUM AND TX.TXTYPE IN ('C', 'D') AND TL.DELTD <> 'Y' " & ControlChars.CrLf _
                                                        & "AND TX.TXCD=TR.TXCD AND TL.BUSDATE > TO_DATE('" & v_strREPORTDATE & "', 'dd/MM/yyyy') GROUP BY TR.ACCTNO) DTL group by DTL.acctno) DTL ON MST.ACCTNO=DTL.ACCTNO) TR " & ControlChars.CrLf _
                                                        & "WHERE MST.CODEID=SYM.CODEID AND CA.CODEID = SYM.CODEID AND SYM.CODEID = '" & v_strCODEID & "' AND MST.ACCTNO = TR.ACCTNO  AND CA.CAMASTID ='" & v_strCAMASTID & "'" & ControlChars.CrLf _
                                                        & "GROUP BY MST.AFACCTNO) DAT WHERE DAT.BALANCE>0"
                            'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                            'v_strSQL = "INSERT INTO CASCHD (AUTOID, CAMASTID, AFACCTNO, CODEID, EXCODEID, BALANCE, QTTY, AMT, AQTTY, AAMT, STATUS,REQTTY,REAQTTY,RETAILBAL)  " & ControlChars.CrLf _
                            '                            & "SELECT SEQ_CASCHD.NEXTVAL,DAT.* " & ControlChars.CrLf _
                            '                            & "FROM(SELECT MAX(CA.CAMASTID) CAMASTID, MST.AFACCTNO, MAX(SYM.CODEID) CODEID, MAX(CA.EXCODEID) EXCODEID, " & ControlChars.CrLf _
                            '                            & "(SUM(MST.TRADE + MST.MARGIN + MST.MORTAGE + MST.BLOCKED + MST.SECURED + MST.REPO+ MST.NETTING+ MST.DTOCLOSE+MST.WITHDRAW) - SUM(TR.AMOUNT)) BALANCE, " & ControlChars.CrLf _
                            '                            & "0  QTTY, 0 AMT, " & v_strAQTTYEXP & " AQTTY, ROUND(" & v_strAAMTEXP & ",0) AAMT, 'A' STATUS," & v_strREQTTYEXP & "  REQTTY," & v_strREAQTTYEXP & "  REAQTTY " & ControlChars.CrLf _
                            '                            & ", 0  RETAILBAL  " & ControlChars.CrLf _
                            '                            & "FROM SBSECURITIES SYM, CAMAST CA, SEMAST MST,  " & ControlChars.CrLf _
                            '                            & "(SELECT MST.ACCTNO, NVL(DTL.AMT,0) AMOUNT FROM SEMAST MST LEFT JOIN " & ControlChars.CrLf _
                            '                            & "(select DTL.ACCTNO, sum(DTL.AMT) amt From " & ControlChars.CrLf _
                            '                            & "(SELECT TR.ACCTNO, SUM((CASE WHEN TX.TXTYPE='D' THEN -TR.NAMT WHEN TX.TXTYPE='C' THEN TR.NAMT ELSE 0 END)) AMT  " & ControlChars.CrLf _
                            '                            & "FROM APPTX TX, SETRAN TR ,TLLOG TL " & ControlChars.CrLf _
                            '                            & "WHERE TX.APPTYPE='SE' AND TRIM(TX.FIELD) IN ('TRADE','MARGIN','MORTAGE','BLOCKED','SECURED','REPO','NETTING','DTOCLOSE','WITHDRAW')  " & ControlChars.CrLf _
                            '                            & "AND TR.TXDATE=TL.TXDATE AND TR.TXNUM=TL.TXNUM AND TX.TXTYPE IN ('C', 'D') AND TL.DELTD <> 'Y' " & ControlChars.CrLf _
                            '                            & "AND TX.TXCD=TR.TXCD AND TL.BUSDATE > TO_DATE('" & v_strREPORTDATE & "', 'dd/MM/yyyy') GROUP BY TR.ACCTNO  " & ControlChars.CrLf _
                            '                            & "UNION ALL  " & ControlChars.CrLf _
                            '                            & "SELECT TR.ACCTNO, SUM((CASE WHEN TX.TXTYPE='D' THEN -TR.NAMT WHEN TX.TXTYPE='C' THEN TR.NAMT ELSE 0 END)) AMT  " & ControlChars.CrLf _
                            '                            & "FROM APPTX TX, SETRANA TR ,TLLOGALL TL  " & ControlChars.CrLf _
                            '                            & "WHERE TX.APPTYPE='SE' AND TRIM(TX.FIELD) IN ('TRADE','MARGIN','MORTAGE','BLOCKED','SECURED','REPO','NETTING','DTOCLOSE','WITHDRAW')  " & ControlChars.CrLf _
                            '                            & "AND TR.TXDATE=TL.TXDATE AND TR.TXNUM=TL.TXNUM AND TX.TXTYPE IN ('C', 'D') AND TL.DELTD <> 'Y' " & ControlChars.CrLf _
                            '                            & "AND TX.TXCD=TR.TXCD AND TL.BUSDATE > TO_DATE('" & v_strREPORTDATE & "', 'dd/MM/yyyy') GROUP BY TR.ACCTNO) DTL group by DTL.acctno) DTL ON MST.ACCTNO=DTL.ACCTNO) TR " & ControlChars.CrLf _
                            '                            & "WHERE MST.CODEID=SYM.CODEID AND CA.CODEID = SYM.CODEID AND SYM.CODEID = '" & v_strCODEID & "' AND MST.ACCTNO = TR.ACCTNO  AND CA.CAMASTID ='" & v_strCAMASTID & "'" & ControlChars.CrLf _
                            '                            & "GROUP BY MST.AFACCTNO) DAT WHERE DAT.BALANCE>0"

                        Else
                            v_strSQL = "INSERT INTO CASCHD (AUTOID, CAMASTID, AFACCTNO, CODEID, EXCODEID, BALANCE, QTTY, AMT, AQTTY, AAMT, STATUS,REQTTY,REAQTTY,RETAILBAL)  " & ControlChars.CrLf _
                          & "SELECT SEQ_CASCHD.NEXTVAL,DAT.* " & ControlChars.CrLf _
                              & "FROM(SELECT MAX(CA.CAMASTID) CAMASTID, MST.AFACCTNO, MAX(SYM.CODEID) CODEID, MAX(CA.EXCODEID) EXCODEID, " & ControlChars.CrLf _
                              & "(SUM(MST.TRADE + MST.MARGIN + MST.MORTAGE + MST.BLOCKED + MST.SECURED + MST.REPO+ MST.NETTING+ MST.DTOCLOSE+MST.WITHDRAW) - SUM(TR.AMOUNT)) BALANCE, " & ControlChars.CrLf _
                              & v_strQTTYEXP & "  QTTY, ROUND(" & v_strAMTEXP & ",0) AMT, " & v_strAQTTYEXP & " AQTTY, ROUND(" & v_strAAMTEXP & ",0) AAMT, 'A' STATUS," & v_strREQTTYEXP & "  REQTTY," & v_strREAQTTYEXP & "  REAQTTY " & ControlChars.CrLf _
                              & ", 0  RETAILBAL  " & ControlChars.CrLf _
                              & "FROM SBSECURITIES SYM, CAMAST CA, SEMAST MST,  " & ControlChars.CrLf _
                              & "(SELECT MST.ACCTNO, NVL(DTL.AMT,0) AMOUNT FROM SEMAST MST LEFT JOIN " & ControlChars.CrLf _
                              & "(select DTL.ACCTNO, sum(DTL.AMT) amt From " & ControlChars.CrLf _
                              & "(SELECT TR.ACCTNO, SUM((CASE WHEN TX.TXTYPE='D' THEN -TR.NAMT WHEN TX.TXTYPE='C' THEN TR.NAMT ELSE 0 END)) AMT  " & ControlChars.CrLf _
                              & "FROM APPTX TX, SETRAN TR ,TLLOG TL " & ControlChars.CrLf _
                              & "WHERE TX.APPTYPE='SE' AND TRIM(TX.FIELD) IN ('TRADE','MARGIN','MORTAGE','BLOCKED','SECURED','REPO','NETTING','DTOCLOSE','WITHDRAW')  " & ControlChars.CrLf _
                              & "AND TR.TXDATE=TL.TXDATE AND TR.TXNUM=TL.TXNUM AND TX.TXTYPE IN ('C', 'D') AND TL.DELTD <> 'Y' " & ControlChars.CrLf _
                              & "AND TX.TXCD=TR.TXCD AND TL.BUSDATE > TO_DATE('" & v_strREPORTDATE & "', 'dd/MM/yyyy') GROUP BY TR.ACCTNO  " & ControlChars.CrLf _
                              & "UNION ALL  " & ControlChars.CrLf _
                              & "SELECT TR.ACCTNO, SUM((CASE WHEN TX.TXTYPE='D' THEN -TR.NAMT WHEN TX.TXTYPE='C' THEN TR.NAMT ELSE 0 END)) AMT  " & ControlChars.CrLf _
                              & "FROM APPTX TX, SETRANA TR ,TLLOGALL TL  " & ControlChars.CrLf _
                              & "WHERE TX.APPTYPE='SE' AND TRIM(TX.FIELD) IN ('TRADE','MARGIN','MORTAGE','BLOCKED','SECURED','REPO','NETTING','DTOCLOSE','WITHDRAW')  " & ControlChars.CrLf _
                              & "AND TR.TXDATE=TL.TXDATE AND TR.TXNUM=TL.TXNUM AND TX.TXTYPE IN ('C', 'D') AND TL.DELTD <> 'Y' " & ControlChars.CrLf _
                              & "AND TX.TXCD=TR.TXCD AND TL.BUSDATE > TO_DATE('" & v_strREPORTDATE & "', 'dd/MM/yyyy') GROUP BY TR.ACCTNO) DTL group by DTL.acctno) DTL ON MST.ACCTNO=DTL.ACCTNO) TR " & ControlChars.CrLf _
                              & "WHERE MST.CODEID=SYM.CODEID AND CA.CODEID = SYM.CODEID AND SYM.CODEID = '" & v_strCODEID & "' AND MST.ACCTNO = TR.ACCTNO  AND CA.CAMASTID ='" & v_strCAMASTID & "'" & ControlChars.CrLf _
                              & "GROUP BY MST.AFACCTNO) DAT WHERE DAT.BALANCE>0"


                        End If
                        'TAO DU LIEU CHO CASCHD
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)


                        If v_strCATYPE = gc_CA_CATYPE_STOCK_RIGHTOFF Then
                            'Mo tai khoan chung khoan phai sinh cho tai khoan do
                            Dim v_dsSB As New DataSet
                            v_strSQL = "Select Count(1) from semast se,caschd chd,camast ca " &
                                       "Where SE.afacctno=CHD.afacctno AND SE.codeid=CHD.excodeid AND " &
                                       "CHD.camastid=CA.camastid AND CA.camastid='" & v_strCAMASTID & "'"
                            v_dsSB = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                            'Fix loi truong hop duplicate o truong hop sau 
                            '1. Thuc hien GD 3375
                            '2. Thuc hien GD 3376
                            '3. Thuc hien lai GD 3375 --> duplicate key
                            '12/04/2010 - truongld them doan check neu da co roi thi khong insert nua
                            If v_dsSB.Tables(0).Rows(0)(0) = 0 Then

                                v_strSQL = " insert into semast  (ACTYPE,CUSTID,ACCTNO,CODEID,AFACCTNO,  " & ControlChars.CrLf _
                                        & " OPNDATE,LASTDATE,COSTDT,TBALDT,STATUS,IRTIED,IRCD,  " & ControlChars.CrLf _
                                        & " COSTPRICE,TRADE,MORTAGE,MARGIN,NETTING,  " & ControlChars.CrLf _
                                        & " STANDING,WITHDRAW,DEPOSIT,LOAN,QTTY_TRANSFER)  " & ControlChars.CrLf _
                                        & " select se.ACTYPE, se.CUSTID, se.afacctno || ca.optcodeid,ca.optcodeid,se.afacctno,  " & ControlChars.CrLf _
                                        & " SE.OPNDATE,SE.LASTDATE,SE.COSTDT, TBALDT, " & ControlChars.CrLf _
                                        & " 'A','Y','000',  " & ControlChars.CrLf _
                                        & " 0,chd.PBALANCE,0,0,0,0,0,0,0,ABS(chd.qtty * CA.TRANSFERTIMES)   " & ControlChars.CrLf _
                                        & " from semast se,caschd chd,camast ca " & ControlChars.CrLf _
                                        & " where SE.afacctno=CHD.afacctno AND SE.codeid=CHD.codeid AND CHD.camastid=CA.camastid AND CA.camastid='" & v_strCAMASTID & "' "

                                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                            End If
                            'End check

                            'Fix loi truong hop duplicate o truong hop sau 
                            '1. Thuc hien GD 3375
                            '2. Thuc hien GD 3376
                            '3. Thuc hien lai GD 3375 --> duplicate key
                            '12/04/2010 - truongld them doan check neu da co roi thi khong insert nua
                            v_strSQL = "Select Count(1) from sbsecurities where CODEID='" & v_strOPTCODEID & "' and SYMBOL='" & v_strOPTSYMBOl & "'"
                            v_dsSB = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

                            If v_dsSB.Tables(0).Rows(0)(0) = 0 Then

                                v_strSQL = "INSERT INTO sbsecurities (CODEID,ISSUERID,SYMBOL,SECTYPE,INVESTMENTTYPE,RISKTYPE,PARVALUE,FOREIGNRATE,STATUS,TRADEPLACE,DEPOSITORY,SECUREDRATIO,MORTAGERATIO,REPORATIO,ISSUEDATE,EXPDATE,INTPERIOD,INTRATE) " & ControlChars.CrLf _
                                    & " SELECT '" & v_strOPTCODEID & "',ISSUERID,'" & v_strOPTSYMBOl & "','004' SECTYPE,INVESTMENTTYPE,RISKTYPE,PARVALUE,FOREIGNRATE,STATUS,TRADEPLACE,DEPOSITORY,SECUREDRATIO,MORTAGERATIO,REPORATIO,ISSUEDATE,EXPDATE,INTPERIOD,INTRATE " & ControlChars.CrLf _
                                    & " FROM SBSECURITIES WHERE CODEID='" & v_strCODEID & "'"
                                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                                'Generate securities_info
                                v_strSQL = "INSERT INTO SECURITIES_INFO (AUTOID,CODEID,SYMBOL,TXDATE,LISTINGQTTY,TRADEUNIT,LISTINGSTATUS,ADJUSTQTTY,LISTTINGDATE,REFERENCESTATUS,ADJUSTRATE,REFERENCERATE,REFERENCEDATE,STATUS,BASICPRICE,OPENPRICE,PREVCLOSEPRICE,CURRPRICE)" & ControlChars.CrLf _
                                            & " SELECT SEQ_SECURITIES_INFO.NEXTVAL,'" & v_strOPTCODEID & "','" & v_strOPTSYMBOl & "',TXDATE,LISTINGQTTY,TRADEUNIT,LISTINGSTATUS,ADJUSTQTTY,LISTTINGDATE,REFERENCESTATUS,ADJUSTRATE,REFERENCERATE,REFERENCEDATE,STATUS,BASICPRICE,OPENPRICE,PREVCLOSEPRICE,CURRPRICE" & ControlChars.CrLf _
                                            & " FROM SECURITIES_INFO WHERE CODEID='" & v_strCODEID & "'"
                                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                                'Generate securities_ticksize
                                v_strSQL = "INSERT INTO SECURITIES_TICKSIZE (AUTOID,CODEID,SYMBOL,TICKSIZE,FROMPRICE,TOPRICE,STATUS)" & ControlChars.CrLf _
                                            & " SELECT SEQ_SECURITIES_TICKSIZE.NEXTVAL,'" & v_strOPTCODEID & "','" & v_strOPTSYMBOl & "',TICKSIZE,FROMPRICE,TOPRICE,STATUS" & ControlChars.CrLf _
                                            & " FROM SECURITIES_TICKSIZE  WHERE CODEID='" & v_strCODEID & "'"
                                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                            End If
                            'End Check
                        End If
                    Else
                        'THONG BAO LOI
                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                     & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                     & "Error message: CAMASTID." & v_strCAMASTID, "EventLogEntryType.Error")
                        Return v_lngErrCode
                    End If
                End If
            Else    'NEU XOA GIAO DICH

                v_strSQL = "SELECT COUNT(*) FROM CASCHD WHERE CAMASTID='" & v_strCAMASTID & "' AND STATUS IN ('S','C') AND DELTD = 'N'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    'BAO LOI DA� Send HOAC Complete!
                    v_lngErrCode = ERR_CA_CAMASTID_ALREADY_SEND_OR_COMPLETE
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: Reversal." & v_blnREVERSAL.ToString() & "." & v_strCAMASTID & "." & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                Else
                    'XOA LICH QUYEN
                    v_strSQL = "UPDATE CASCHD SET DELTD='Y' WHERE CAMASTID='" & v_strCAMASTID & "'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    If v_strCATYPE = gc_CA_CATYPE_STOCK_RIGHTOFF Then
                        'DELETE securities
                        v_strSQL = "DELETE FROM SBSECURITIES WHERE CODEID='" & v_strOPTCODEID & "'"
                        'DELETE securities_info
                        v_strSQL = "DELETE FROM SECURITIES_INFO WHERE CODEID='" & v_strOPTCODEID & "'"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                        'DELETE securities_ticksize
                        v_strSQL = "DELETE FROM SECURITIES_TICKSIZE WHERE CODEID='" & v_strOPTCODEID & "'"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                        'Delete sub securities acctno
                        v_strSQL = "DELETE FROM semast WHERE CODEID='" & v_strOPTCODEID & "'"
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
    Private Function ConfirmExecute(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CA.Trans.RejectCAEvent", v_strErrorMessage As String
        Dim v_strSQLTmp As String = String.Empty, v_strSQL As String = String.Empty, i As Integer
        Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE, v_lngCLEARDAY As Double
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strCAMASTID, v_strCATYPE, v_strCANCELDATE, v_strRECEIVEDATE As String
            Dim v_ds As DataSet
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_strBRID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXTIME As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTIME).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_blnREVERSAL As Boolean = IIf(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value = "Y", True, False)
            Dim v_strBUSDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBUSDATE).Value

            'LAY NOI DUNG GIAO DICH
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(gf_Numberic(.InnerText), gf_Cdbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If
                    Select Case v_strFLDCD
                        Case "03" 'CAMASTID
                            v_strCAMASTID = v_strVALUE
                        Case "05" 'CATYPE
                            v_strCATYPE = v_strVALUE
                        Case "26" 'CANCELDATE
                            v_strCANCELDATE = v_strVALUE
                        Case "27" 'RECEIVEDATE
                            v_strRECEIVEDATE = v_strVALUE
                    End Select
                End With
            Next
            If Not v_blnREVERSAL Then   'NEU DUYET CANCELDATE,RECEIVEDATE
                v_strSQL = "UPDATE CAMAST SET CANCELDATE = TO_DATE('" & v_strCANCELDATE & "','" & gc_FORMAT_DATE & "') , RECEIVEDATE = TO_DATE('" & v_strRECEIVEDATE & "','" & gc_FORMAT_DATE & "')  WHERE CAMASTID='" & v_strCAMASTID & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End If
            'Gianh Comment lai vi dung truong 07.Actiondate tren man hinh de cap nhat.
            'If Not v_blnREVERSAL Then   'NEU DUYET

            '    v_strSQL = "UPDATE CAMAST SET ACTIONDATE = TO_DATE('" & v_strBUSDATE & "','" & gc_FORMAT_DATE & "')  WHERE CAMASTID='" & v_strCAMASTID & "'"
            '    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            'Else


            'End If
            ''ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            ''ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function CUT_STOCK_EXCUTE(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CI.Trans.CUT_STOCK_EXCUTE", v_strErrorMessage As String
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strSQL, v_strFLDCD, v_strFLDTYPE, v_strVALUE As String, v_dblVALUE As Double, i As Integer
        Dim v_strGLACCTNO, v_strBENEFNAME, v_strBENEFACCT, v_strBENEFCUSTNAME, v_strBENEFLICENSE, v_strREFTXDATE, v_strREFTXNUM, v_strFEETYPE As String
        Dim v_strSTATUS = "A", v_strBANKID, v_strBANKNAME, v_strBANKACC, v_strBANKACCNAME As String
        Dim v_dblAMT, v_dblFEEAMT As Double
        Dim v_strPOTXNUM, v_strPOTXDATE, v_strPOTYPE, v_strDESC, v_strAFACCTNO, v_strCAMASTID, v_strIORO, v_strCITAD As String
        Dim v_ds As New DataSet
        Dim v_obj As New DataAccess
        Dim v_strCodeid As String
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
            v_obj.NewDBInstance(gc_MODULE_HOST)
            '�?�?c nội dung giao dịch tính lãi cộng dồn: 1160
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
                        Case "02"
                            v_strCAMASTID = v_strVALUE
                        Case "03"
                            v_strAFACCTNO = v_strVALUE
                        Case "15" 'ACCTNO
                            v_strGLACCTNO = v_strVALUE
                        Case "05"
                            v_strBANKID = v_strVALUE
                        Case "06" 'TXDATE
                            v_strREFTXDATE = v_strVALUE
                        Case "07" 'TXNUM
                            v_strREFTXNUM = v_strVALUE
                        Case "08" ''BANKACC
                            v_strBANKACC = v_strVALUE
                        Case "86" ''BANKACCNAME
                            v_strBANKACCNAME = v_strVALUE
                        Case "80" 'BENEFBANK
                            v_strBENEFNAME = v_strVALUE
                        Case "81" 'BENEFACCT
                            v_strBENEFACCT = v_strVALUE
                        Case "82" 'BENEFCUSTNAME
                            v_strBENEFCUSTNAME = v_strVALUE
                        Case "83" 'BENEFLICENSE
                            v_strBENEFLICENSE = v_strVALUE
                        Case "85" 'BANKNAME
                            v_strBANKNAME = v_strVALUE
                        Case "10" 'AMT
                            v_dblAMT = v_dblVALUE
                        Case "11" 'FEEAMT
                            v_dblFEEAMT = v_dblVALUE
                        Case "98" 'POTXDATE
                            v_strPOTXDATE = v_strVALUE
                        Case "99" 'POTXNUM
                            v_strPOTXNUM = v_strVALUE
                        Case "17" 'POTYPE
                            v_strPOTYPE = v_strVALUE
                        Case "27" 'CITAD
                            v_strCITAD = v_strVALUE
                        Case "31" 'DESC
                            v_strDESC = v_strVALUE
                        Case "32" 'IORO
                            v_strIORO = v_strVALUE
                        Case "22" 'IORO
                            v_strCodeid = v_strVALUE
                    End Select
                End With
            Next

            If Not v_blnReversal Then
                'Insert vao POMAST neu chua ton tai
                v_strSQL = "SELECT COUNT(1) FROM POMAST WHERE TXNUM = '" & v_strPOTXNUM & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows(0)(0) < 1 Then
                    v_strSQL = "INSERT INTO POMAST(TXDATE, TXNUM, AMT, BRID, STATUS, BANKID, BANKNAME, BANKACC, BANKACCNAME, GLACCTNO, FEETYPE, POTYPE, BENEFACCT, BENEFNAME, BENEFCUSTNAME, DESCRIPTION,CODEID) " &
                               "VALUES( TO_DATE('" & v_strPOTXDATE & "', '" & gc_FORMAT_DATE_Db & "'), '" & v_strPOTXNUM & "'," & v_dblAMT & ",'" & v_strBRID & "'," &
                               "'" & v_strSTATUS & "', '" & v_strBANKID & "', '" & v_strBANKNAME & "', '" & v_strBANKACC & "', '" & v_strBANKACCNAME & "', '" & v_strGLACCTNO & "','" & v_strIORO & "', '" & v_strPOTYPE & "','" & v_strBENEFACCT & "','" & v_strBENEFNAME & "','" & v_strBENEFCUSTNAME & "','" & v_strDESC & "','" & v_strCodeid & "')"
                Else
                    v_strSQL = "UPDATE POMAST SET AMT = AMT+" & v_dblAMT & " WHERE TXNUM='" & v_strPOTXNUM & "' AND TXDATE=TO_DATE('" & v_strPOTXDATE & "', '" & gc_FORMAT_DATE_Db & "')"
                End If
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                'INSERT INTO PODETAILS
                v_strSQL = "INSERT INTO PODETAILS(AUTOID, POTXNUM, POTXDATE, AFACCTNO, CAMASTID) " &
                           "VALUES(SEQ_PODETAILS.NEXTVAL, '" & v_strPOTXNUM & "', TO_DATE('" & v_strPOTXDATE & "', '" & gc_FORMAT_DATE_Db & "'), '" & v_strAFACCTNO & "','" & v_strCAMASTID & "')"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            End If

            'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        Finally
            v_ds.Dispose()
            v_obj = Nothing
        End Try
    End Function
    Private Function COMPLETE_CA(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CA.Trans.RejectCAEvent", v_strErrorMessage As String
        Dim v_strSQLTmp As String = String.Empty, v_strSQL As String = String.Empty, i As Integer
        Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE, v_lngCLEARDAY As Double

        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strCAMASTID As String
            Dim v_ds As DataSet
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_strBRID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXTIME As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTIME).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_blnREVERSAL As Boolean = IIf(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value = "Y", True, False)
            Dim v_strBUSDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBUSDATE).Value

            'LAY NOI DUNG GIAO DICH
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(gf_Numberic(.InnerText), gf_Cdbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If
                    Select Case v_strFLDCD
                        Case "03" 'CAMASTID
                            v_strCAMASTID = v_strVALUE

                    End Select
                End With
            Next

            If Not v_blnREVERSAL Then   'NEU DUYET

                v_strSQL = "UPDATE CASCHD SET STATUS = 'C'  WHERE CAMASTID='" & v_strCAMASTID & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                ' PhuongHT add: update lai menh ja voi tach/gop co phieu
                v_strSQL = "SELECT CAMAST.* FROM CAMAST WHERE CAMASTID='" & v_strCAMASTID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    Select Case v_ds.Tables(0).Rows(0)("CATYPE")
                        Case gc_CA_CATYPE_STOCK_SPLIT, gc_CA_CATYPE_STOCK_MERGE ' Tach,gop
                            'Neu tach, gop thi thay doi menh gia
                            Dim v_strPARVALUE, v_strSPLITRATE, v_strCODEID As String
                            'Dim v_strRightSplitRate, v_strLeftSplitRate As String
                            Dim v_dbSPLITRATE As Double
                            'v_strPARVALUE = Trim(v_ds.Tables(0).Rows(0)("PARVALUE"))
                            v_strSPLITRATE = Trim(v_ds.Tables(0).Rows(0)("SPLITRATE"))
                            v_strCODEID = Trim(v_ds.Tables(0).Rows(0)("CODEID"))
                            '  v_dbSPLITRATE = Trim(v_ds.Tables(0).Rows(0)("SPLITRATE"))
                            ' v_dbSPLITRATE = Double.Parse(v_strSPLITRATE.Substring(0, v_strSPLITRATE.IndexOf("/"))) / Double.Parse(v_strSPLITRATE.Substring(v_strSPLITRATE.IndexOf("/") + 1))
                            ' update lai costprice trong semast

                            v_strSQL = "UPDATE SBSECURITIES SET PARVALUE=round (PARVALUE * " & Double.Parse(v_strSPLITRATE.Substring(0, v_strSPLITRATE.IndexOf("/"))) & " / " & Double.Parse(v_strSPLITRATE.Substring(v_strSPLITRATE.IndexOf("/") + 1)) & ", 0) where CODEID =  '" & v_strCODEID & "'"
                            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                    End Select
                End If

                ' End of PhuongHT add

            Else
                v_strSQL = "UPDATE CASCHD SET STATUS = 'S'  WHERE CAMASTID='" & v_strCAMASTID & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                ' PhuongHT add: update lai menh ja voi tach/gop co phieu
                v_strSQL = "SELECT CAMAST.* FROM CAMAST WHERE CAMASTID='" & v_strCAMASTID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    Select Case v_ds.Tables(0).Rows(0)("CATYPE")
                        Case gc_CA_CATYPE_STOCK_SPLIT, gc_CA_CATYPE_STOCK_MERGE ' Tach,gop
                            'Neu tach, gop thi thay doi menh gia
                            Dim v_strPARVALUE, v_strSPLITRATE, v_strCODEID As String
                            'Dim v_strRightSplitRate, v_strLeftSplitRate As String
                            Dim v_dbSPLITRATE As Double
                            'v_strPARVALUE = Trim(v_ds.Tables(0).Rows(0)("PARVALUE"))
                            v_strSPLITRATE = Trim(v_ds.Tables(0).Rows(0)("SPLITRATE"))
                            v_strCODEID = Trim(v_ds.Tables(0).Rows(0)("CODEID"))
                            '  v_dbSPLITRATE = Trim(v_ds.Tables(0).Rows(0)("SPLITRATE"))
                            ' v_dbSPLITRATE = Double.Parse(v_strSPLITRATE.Substring(0, v_strSPLITRATE.IndexOf("/"))) / Double.Parse(v_strSPLITRATE.Substring(v_strSPLITRATE.IndexOf("/") + 1))
                            ' update lai costprice trong semast

                            v_strSQL = "UPDATE SBSECURITIES SET PARVALUE=round (PARVALUE / " & Double.Parse(v_strSPLITRATE.Substring(0, v_strSPLITRATE.IndexOf("/"))) & " * " & Double.Parse(v_strSPLITRATE.Substring(v_strSPLITRATE.IndexOf("/") + 1)) & ", 0) where CODEID =  '" & v_strCODEID & "'"
                            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                    End Select
                End If

                ' End of PhuongHT add
            End If
            ''ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            ''ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
    Private Function RejectCAEvent(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CA.Trans.RejectCAEvent", v_strErrorMessage As String
        Dim v_strSQLTmp As String = String.Empty, v_strSQL As String = String.Empty, i As Integer
        Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE, v_lngCLEARDAY As Double
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strCAMASTID As String
            Dim v_ds As DataSet
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_strBRID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXTIME As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTIME).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_blnREVERSAL As Boolean = IIf(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value = "Y", True, False)

            'LAY NOI DUNG GIAO DICH
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(gf_Numberic(.InnerText), gf_Cdbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If
                    Select Case v_strFLDCD
                        Case "03" 'CAMASTID
                            v_strCAMASTID = v_strVALUE
                    End Select
                End With
            Next

            If Not v_blnREVERSAL Then   'NEU DUYET
                v_strSQL = "SELECT COUNT(*) FROM CASCHD WHERE CAMASTID='" & v_strCAMASTID & "' AND STATUS IN ('S','C') AND DELTD= 'N'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    'BAO LOI
                    v_lngErrCode = ERR_CA_CAMASTID_ALREADY_SEND_OR_COMPLETE
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: Reversal." & v_blnREVERSAL.ToString() & "." & v_strCAMASTID & "." & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                Else
                    v_strSQL = "UPDATE CASCHD SET DELTD='Y' WHERE CAMASTID='" & v_strCAMASTID & "'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                End If
            Else
                'XOA GIAO DICH
                v_strSQL = "UPDATE CASCHD SET DELTD='N' WHERE CAMASTID='" & v_strCAMASTID & "'"
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
    Private Function TRADE_RETAIL(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CA.Trans.RejectCAEvent", v_strErrorMessage As String
        Dim v_strSQLTmp As String = String.Empty, v_strSQL As String = String.Empty, i As Integer
        Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE, v_lngCLEARDAY As Double
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strCAMASTID, v_strAfacctno As String
            Dim v_dblPrice, v_dblQtty As Double
            Dim v_ds As DataSet
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_strBRID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXTIME As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTIME).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_blnREVERSAL As Boolean = IIf(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value = "Y", True, False)

            'LAY NOI DUNG GIAO DICH
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(gf_Numberic(.InnerText), gf_Cdbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If
                    Select Case v_strFLDCD
                        Case "02" 'CAMASTID
                            v_strCAMASTID = v_strVALUE
                        Case "03" 'af acctno 
                            v_strAfacctno = v_strVALUE
                        Case "21" 'qtty
                            v_dblQtty = v_dblVALUE
                    End Select
                End With
            Next
            v_strSQL = "SELECT PRICE FROM CAMAST WHERE CAMASTID='" & v_strCAMASTID & "' AND DELTD= 'N'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows(0)(0) > 0 Then
                v_dblPrice = v_ds.Tables(0).Rows(0).Item("PRICE")
            End If

            If Not v_blnREVERSAL Then   'NEU DUYET
                v_strSQL = "SELECT COUNT(*) FROM CASCHD WHERE CAMASTID='" & v_strCAMASTID & "' AND STATUS IN ('S','C') AND DELTD= 'N'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    'BAO LOI
                    v_lngErrCode = ERR_CA_CAMASTID_ALREADY_SEND_OR_COMPLETE
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: Reversal." & v_blnREVERSAL.ToString() & "." & v_strCAMASTID & "." & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                Else
                    v_strSQL = "SELECT CATYPE,STATUS,RETAILSHARE FROM CAMAST WHERE CAMASTID='" & v_strCAMASTID & "'"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    Dim v_strCATYPE As String = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("CATYPE")), String.Empty, v_ds.Tables(0).Rows(0)("CATYPE"))
                    If v_strCATYPE = "011" Then
                        v_strSQL = "SELECT COUNT(*) COUNT FROM CASCHD CA, SECURITIES_INFO INFO WHERE CA.AFACCTNO='" & v_strAfacctno & "' AND CA.CODEID  = INFO.CODEID AND MOD(CA.QTTY,INFO.TRADELOT) < " & v_dblQtty & " AND CAMASTID = '" & v_strCAMASTID & "'"
                        v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    End If
                    Dim v_strCOUNT As Int16 = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("COUNT")), 0, v_ds.Tables(0).Rows(0)("COUNT"))
                    If v_strCOUNT > 0 Then
                        v_lngErrCode = ERR_CA_CAQTTY_SMALLER
                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                       & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                       & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                        Return v_lngErrCode
                    End If
                    v_strSQL = "UPDATE CASCHD SET AMT = AMT + " & v_dblPrice * v_dblQtty & ", QTTY = QTTY - " & v_dblQtty & "  WHERE CAMASTID='" & v_strCAMASTID & "' AND AFACCTNO = '" & v_strAfacctno & "' AND DELTD = 'N'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                End If
            Else
                'XOA GIAO DICH
                v_strSQL = "UPDATE CASCHD SET AMT = AMT - " & v_dblPrice * v_dblQtty & ", QTTY = QTTY + " & v_dblQtty & "  WHERE CAMASTID='" & v_strCAMASTID & "' AND AFACCTNO = '" & v_strAfacctno & "' AND DELTD = 'N'"
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

    Private Function CheckBeforeCAEvent(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CA.Trans.CheckBeforeCAEvent", v_strErrorMessage As String
        Dim v_strSQLTmp As String = String.Empty, v_strSQL As String = String.Empty, i As Integer
        Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE, v_lngCLEARDAY As Double
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strCAMASTID, v_strAFACCTNO, v_strCATYPE As String
            Dim v_dblQTTY As Double
            Dim v_ds As DataSet
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_strBRID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXTIME As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTIME).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_blnREVERSAL As Boolean = IIf(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value = "Y", True, False)

            'LAY NOI DUNG GIAO DICH
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(gf_Numberic(.InnerText), gf_Cdbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If
                    Select Case v_strFLDCD
                        Case "03" 'CAMASTID
                            v_strCAMASTID = v_strVALUE
                    End Select
                End With
            Next

            If Not v_blnREVERSAL Then
                'Kiem tra 
                If Len(v_strCAMASTID) > 0 Then
                    'LAY THONG TIN DOT THUC HIEN QUYEN
                    v_strSQL = "SELECT * FROM CAMAST WHERE CAMASTID='" & v_strCAMASTID & "'"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count > 0 Then
                        v_strCATYPE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("CATYPE")))
                    End If

                    Select Case v_strCATYPE
                        Case gc_CA_CATYPE_PRINCIPLE_BONd
                            v_strSQL = "SELECT count(1) FROM camast WHERE status = 'N' AND catype IN ('" & gc_CA_CATYPE_BOND_PAY_INTEREST & "')"
                            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                            If v_ds.Tables(0).Rows(0)(0) > 0 Then
                                v_lngErrCode = ERR_CA_BOND_PAY_INTEREST_MUSTBE_FINISHED
                                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                                & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                                & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                                Return v_lngErrCode
                            End If
                    End Select
                End If

            Else
                'XOA GIAO DICH
            End If
            ''ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            ''ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function


    Private Function Check_3381(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CA.Trans.RejectCAEvent", v_strErrorMessage As String
        Dim v_strSQLTmp As String = String.Empty, v_strSQL As String = String.Empty, i As Integer
        Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE, v_lngCLEARDAY As Double
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strCAMASTID, v_strAFACCTNO As String
            Dim v_dblQTTY As Double
            Dim v_ds As DataSet
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_strBRID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXTIME As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTIME).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_blnREVERSAL As Boolean = IIf(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value = "Y", True, False)

            'LAY NOI DUNG GIAO DICH
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(gf_Numberic(.InnerText), gf_Cdbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If
                    Select Case v_strFLDCD
                        Case "02" 'CAMASTID
                            v_strCAMASTID = v_strVALUE
                        Case "03"
                            v_strAFACCTNO = v_strVALUE
                        Case "21"
                            v_dblQTTY = v_dblVALUE
                    End Select
                End With
            Next

            If Not v_blnREVERSAL Then   'NEU DUYET
                'Kiem tra 
                v_strSQL = "SELECT CATYPE,STATUS,RETAILSHARE FROM CAMAST WHERE CAMASTID='" & v_strCAMASTID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                Dim v_strCATYPE As String = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("CATYPE")), String.Empty, v_ds.Tables(0).Rows(0)("CATYPE"))
                Dim v_strSTATUS As String = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("STATUS")), String.Empty, v_ds.Tables(0).Rows(0)("STATUS"))
                Dim v_strRETAILSHARE As String = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("RETAILSHARE")), String.Empty, v_ds.Tables(0).Rows(0)("RETAILSHARE"))
                If v_strCATYPE <> "018" And v_strCATYPE <> "012" And v_strCATYPE <> "013" And v_strCATYPE <> "014" And v_strCATYPE <> "011" Then
                    v_lngErrCode = ERR_CA_CANNOT_RETAIL
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                    & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                    & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If
                If v_strSTATUS <> "S" And v_strRETAILSHARE <> "Y" Then
                    v_lngErrCode = ERR_CAMAST_STATUS_INVALID
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                    & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                    & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If
                'Kiem tra ACCTNO co thuoc dot thuc hien quyen
                v_strSQL = "SELECT COUNT(*) COUNT FROM CASCHD WHERE AFACCTNO='" & v_strAFACCTNO & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                Dim v_strCOUNT As Int16 = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("COUNT")), 0, v_ds.Tables(0).Rows(0)("COUNT"))
                If v_strCOUNT <= 0 Then
                    v_lngErrCode = ERR_CF_AFMAST_NOTFOUND
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                    & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                    & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If
                'Kiem tra 
                v_strSQL = "SELECT CATYPE,STATUS,RETAILSHARE FROM CAMAST WHERE CAMASTID='" & v_strCAMASTID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                v_strCATYPE = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("CATYPE")), String.Empty, v_ds.Tables(0).Rows(0)("CATYPE"))
                If v_strCATYPE = "011" Then
                    v_strSQL = "SELECT COUNT(*) COUNT FROM CASCHD CA, SECURITIES_INFO INFO WHERE CA.AFACCTNO='" & v_strAFACCTNO & "' AND CA.CODEID  = INFO.CODEID AND MOD(CA.QTTY,INFO.TRADELOT) < " & v_dblQTTY & " AND CAMASTID = '" & v_strCAMASTID & "'"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                End If
                v_strCOUNT = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("COUNT")), 0, v_ds.Tables(0).Rows(0)("COUNT"))
                If v_strCOUNT > 0 Then
                    v_lngErrCode = ERR_CA_CAQTTY_SMALLER
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                   & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                   & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If
            Else
                'XOA GIAO DICH
            End If
            ''ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            ''ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
    Private Function Check_3382(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CA.Trans.RejectCAEvent", v_strErrorMessage As String
        Dim v_strSQLTmp As String = String.Empty, v_strSQL As String = String.Empty, i, v_strNumber As Integer
        Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE, v_lngCLEARDAY As Double
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strCAMASTID, v_strAFACCTNO, v_strAFACCTNO_CR, v_strSYMBOL As String
            Dim v_strRETAILBAL, v_dblQTTY As Int64
            Dim v_ds As DataSet
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_strBRID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXTIME As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTIME).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_blnREVERSAL As Boolean = IIf(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value = "Y", True, False)

            'LAY NOI DUNG GIAO DICH
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(gf_Numberic(.InnerText), gf_Cdbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If
                    Select Case v_strFLDCD
                        Case "06" 'CAMASTID
                            v_strCAMASTID = v_strVALUE
                        Case "02"
                            v_strAFACCTNO = v_strVALUE
                        Case "01"
                            v_strSYMBOL = v_strVALUE
                        Case "04"
                            v_strAFACCTNO_CR = v_strVALUE
                        Case "21"
                            v_dblQTTY = v_dblVALUE
                    End Select
                End With
            Next

            If Not v_blnREVERSAL Then   'NEU DUYET
                'Chi thuc hien voi su kien Stock RightOff 
                v_strSQL = "SELECT CATYPE,STATUS FROM CAMAST WHERE CAMASTID='" & v_strCAMASTID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                Dim v_strCATYPE As String = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("CATYPE")), String.Empty, v_ds.Tables(0).Rows(0)("CATYPE"))
                Dim v_strSTATUS As String = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("CATYPE")), String.Empty, v_ds.Tables(0).Rows(0)("CATYPE"))
                If v_strCATYPE <> "014" Then
                    v_lngErrCode = ERR_CA_CANNOT_RETAIL
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                    & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                    & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")

                    Return v_lngErrCode
                End If


                'Kiem tra ACCTNO co thuoc dot thuc hien quyen
                v_strSQL = "SELECT COUNT(*) COUNT FROM AFMAST WHERE ACCTNO='" & v_strAFACCTNO & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                Dim v_strCOUNT As Int16 = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("COUNT")), 0, v_ds.Tables(0).Rows(0)("COUNT"))
                If v_strCOUNT <= 0 Then
                    v_lngErrCode = ERR_CF_AFMAST_NOTFOUND
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                    & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                    & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If

                'Kiem tra ACCTNO1 co trong he thong
                v_strSQL = "SELECT COUNT(*) COUNT FROM AFMAST WHERE ACCTNO ='" & v_strAFACCTNO_CR & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                Dim v_strCOUNT1 As Int16 = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("COUNT")), 0, v_ds.Tables(0).Rows(0)("COUNT"))
                If v_strCOUNT1 <= 0 Then
                    v_lngErrCode = ERR_CA_CANNOT_RETAIL
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                    & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                    & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If


                'TransferTimes=1
                v_strSQL = "select TransferTimes ,TRFLIMIT  from CAMAST WHERE CAMASTID='" & v_strCAMASTID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                Dim v_strTransferTimes As Int16 = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("TransferTimes")), 0, v_ds.Tables(0).Rows(0)("TransferTimes"))
                Dim v_strTRFLIMIT As String = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("TRFLIMIT")), "", v_ds.Tables(0).Rows(0)("TRFLIMIT"))


                ' check xem quyen mua co dc chuyen nhuong hay khong
                If v_strTRFLIMIT = "Y" Then
                    v_strSQL = "SELECT RETAILBAL FROM CASCHD WHERE CAMASTID='" & v_strCAMASTID & "' AND AFACCTNO ='" & v_strAFACCTNO & "' and deltd <>'Y' "
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count > 0 Then
                        v_strRETAILBAL = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("RETAILBAL")), 0, v_ds.Tables(0).Rows(0)("RETAILBAL"))
                        If v_strRETAILBAL < v_dblQTTY Then
                            v_lngErrCode = ERR_CA_QTTY_TRANSFER
                            LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                    & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                    & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                            Return v_lngErrCode
                        End If
                    Else
                        v_lngErrCode = ERR_CA_SEMAST_NOTFOUND
                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                    & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                    & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                        Return v_lngErrCode
                    End If
                Else
                    v_lngErrCode = ERR_CA_CANNOT_RETAIL
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                    & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                    & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If


                'Kiem tra xem voi dang ky quyen mua. 
                v_strSQL = "SELECT COUNT(1) FROM CAMAST CA, SYSVAR SYS WHERE SYS.VARNAME = 'CURRDATE' AND SYS.GRNAME = 'SYSTEM' AND CATYPE = '014' AND TO_DATE (VARVALUE,'DD/MM/RRRR') >= FRDATETRANSFER AND camastid = '" & v_strCAMASTID & "' "
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows(0)(0) = 0 Then
                    'Khong cho phep thuc hien vi da den ngay.
                    v_lngErrCode = ERR_CA_DATE_CANNOT_EXECUTE
                End If
                'Kiem tra xem voi dang ky quyen mua. 
                v_strSQL = "SELECT COUNT(1) FROM CAMAST CA, SYSVAR SYS WHERE SYS.VARNAME = 'CURRDATE' AND SYS.GRNAME = 'SYSTEM' AND CATYPE = '014' AND TO_DATE (VARVALUE,'DD/MM/RRRR') <= TODATETRANSFER AND camastid = '" & v_strCAMASTID & "' "
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows(0)(0) = 0 Then
                    'Khong cho phep thuc hien vi da den ngay.
                    v_lngErrCode = ERR_CA_DATE_OUTOF_REGISTER
                End If

            Else
                'XOA GIAO DICH
            End If
            ''ContextUtil.SetComplete()

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
            Return v_lngErrCode
        Catch ex As Exception
            ''ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
    Private Function Check_3385(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CA.Trans.Check_3385", v_strErrorMessage As String
        Dim v_strSQLTmp As String = String.Empty, v_strSQL As String = String.Empty, i As Integer
        Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE, v_lngCLEARDAY As Double
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strCAMASTID, v_strAFACCTNO, v_strAFACCTNO_CR, v_strSYMBOL As String
            Dim v_strRETAILBAL, v_dblQTTY As Int64
            Dim v_ds As DataSet
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_strBRID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXTIME As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTIME).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_blnREVERSAL As Boolean = IIf(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value = "Y", True, False)

            'LAY NOI DUNG GIAO DICH
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(gf_Numberic(.InnerText), gf_Cdbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If
                    Select Case v_strFLDCD
                        Case "04"
                            v_strAFACCTNO_CR = v_strVALUE
                        Case "06" 'CAMASTID
                            v_strCAMASTID = v_strVALUE

                    End Select
                End With
            Next

            If Not v_blnREVERSAL Then   'NEU DUYET
                'Chi thuc hien voi su kien Stock RightOff 
                v_strSQL = "SELECT CATYPE,STATUS FROM CAMAST WHERE CAMASTID='" & v_strCAMASTID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                Dim v_strCATYPE As String = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("CATYPE")), String.Empty, v_ds.Tables(0).Rows(0)("CATYPE"))
                Dim v_strSTATUS As String = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("CATYPE")), String.Empty, v_ds.Tables(0).Rows(0)("CATYPE"))
                If v_strCATYPE <> "014" Then
                    v_lngErrCode = ERR_CA_CANNOT_RETAIL
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                    & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                    & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")

                    Return v_lngErrCode
                End If




                'Kiem tra ACCTNO1 co trong he thong
                v_strSQL = "SELECT COUNT(*) COUNT FROM AFMAST WHERE ACCTNO ='" & v_strAFACCTNO_CR & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                Dim v_strCOUNT1 As Int16 = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("COUNT")), 0, v_ds.Tables(0).Rows(0)("COUNT"))
                If v_strCOUNT1 <= 0 Then
                    v_lngErrCode = ERR_CA_CANNOT_RETAIL
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                    & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                    & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If


                'TransferTimes=1
                v_strSQL = "select TransferTimes ,TRFLIMIT  from CAMAST WHERE CAMASTID='" & v_strCAMASTID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                Dim v_strTransferTimes As Int16 = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("TransferTimes")), 0, v_ds.Tables(0).Rows(0)("TransferTimes"))
                Dim v_strTRFLIMIT As String = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("TRFLIMIT")), "", v_ds.Tables(0).Rows(0)("TRFLIMIT"))

                If v_strTRFLIMIT = "Y" Then

                    If v_strTransferTimes = 0 Then 'Khong duoc chuyen nhuong
                        v_lngErrCode = ERR_CA_CANNOT_RETAIL
                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                    & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                    & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                        Return v_lngErrCode

                    End If
                End If

                'Kiem tra xem voi dang ky quyen mua. 
                v_strSQL = "SELECT COUNT(1) FROM CAMAST CA, SYSVAR SYS WHERE SYS.VARNAME = 'CURRDATE' AND SYS.GRNAME = 'SYSTEM' AND CATYPE = '014' AND TO_DATE (VARVALUE,'DD/MM/RRRR') >= FRDATETRANSFER AND camastid = '" & v_strCAMASTID & "' "
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows(0)(0) = 0 Then
                    'Khong cho phep thuc hien vi da den ngay.
                    v_lngErrCode = ERR_CA_DATE_CANNOT_EXECUTE
                End If

            Else
                'XOA GIAO DICH
            End If
            ''ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            ''ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function Check_3386(ByRef pv_xmlDocument As Xml.XmlDocument) As Long

        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CA.Trans.Check_3386", v_strErrorMessage As String
        Dim v_strSQLTmp As String = String.Empty, v_strSQL As String = String.Empty, i, v_strNumber As Integer
        Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE, v_lngCLEARDAY As Double
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSYMBOL As String
            Dim v_strQTTY As Int64
            Dim v_dblEXPRICE As Double

            Dim v_strCAMASTID, v_strAFACCTNO, v_strAFACCTNO_CR, v_strEXCODEID, v_strCODEID, v_strREPORTDATE, v_strACTIONDATE, v_strDUEDATE, v_strSTATUS, v_strOPTCODEID, v_strOPTSYMBOl, v_strFRTRADEPLACE, v_strTOTRADEPLACE As String
            Dim v_dblINTERESTPERIOD, v_dblPARVALUE As Double
            Dim v_strEXRATE, v_strRIGHTOFFRATE, v_strDEVIDENTRATE, v_strDEVIDENTSHARES, v_strSPLITRATE, v_strINTERESTRATE As String
            Dim v_strLEFT_EXRATE, v_strLEFT_RIGHTOFFRATE, v_strLEFT_DEVIDENTRATE, v_strLEFT_DEVIDENTSHARES, v_strLEFT_SPLITRATE, v_strLEFT_INTERESTRATE As String
            Dim v_strRIGHT_EXRATE, v_strRIGHT_RIGHTOFFRATE, v_strRIGHT_DEVIDENTRATE, v_strRIGHT_DEVIDENTSHARES, v_strRIGHT_SPLITRATE, v_strRIGHT_INTERESTRATE As String
            Dim v_strQTTYEXP, v_strAMTEXP, v_strAQTTYEXP, v_strAAMTEXP, v_strROUNDTYPE, v_strROUNDVALUE, v_strREQTTYEXP, v_strREAQTTYEXP As String
            Dim v_dtREPORTDATE, v_dtTXDATE, v_dtACTIONDATE As DateTime
            Dim v_ds As DataSet
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_strBRID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXTIME As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTIME).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_blnREVERSAL As Boolean = IIf(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value = "Y", True, False)

            'LAY NOI DUNG GIAO DICH
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(gf_Numberic(.InnerText), gf_Cdbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If
                    Select Case v_strFLDCD
                        Case "02" 'CAMASTID
                            v_strCAMASTID = v_strVALUE
                        Case "03"
                            v_strAFACCTNO = v_strVALUE
                        Case "04"
                            v_strSYMBOL = v_strVALUE
                        Case "05"
                            v_dblEXPRICE = v_dblVALUE
                        Case "21"
                            v_strQTTY = v_dblVALUE
                    End Select
                End With
            Next


            'TAO DU LIEU MOI
            If Len(v_strCAMASTID) > 0 Then
                'LAY THONG TIN DOT THUC HIEN QUYEN
                v_strSQL = "SELECT * FROM CAMAST WHERE CAMASTID='" & v_strCAMASTID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_strCODEID = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("CODEID")))
                    v_strEXCODEID = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("EXCODEID")))
                    v_strREPORTDATE = gf_CorrectStringField(Format(v_ds.Tables(0).Rows(0)("REPORTDATE"), gc_FORMAT_DATE))
                    v_strACTIONDATE = gf_CorrectStringField(Format(v_ds.Tables(0).Rows(0)("ACTIONDATE"), gc_FORMAT_DATE))
                    v_strDUEDATE = gf_CorrectStringField(Format(v_ds.Tables(0).Rows(0)("DUEDATE"), gc_FORMAT_DATE))
                    v_dblEXPRICE = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("EXPRICE"))
                    v_dblPARVALUE = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("PARVALUE"))
                    v_strEXRATE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("EXRATE")))
                    v_strLEFT_EXRATE = gf_FormatNumberToSring(v_strEXRATE, 0)
                    v_strRIGHT_EXRATE = gf_FormatNumberToSring(v_strEXRATE, 1)
                    v_strRIGHTOFFRATE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("RIGHTOFFRATE")))
                    v_strLEFT_RIGHTOFFRATE = gf_FormatNumberToSring(v_strRIGHTOFFRATE, 0)
                    v_strRIGHT_RIGHTOFFRATE = gf_FormatNumberToSring(v_strRIGHTOFFRATE, 1)
                    v_strDEVIDENTRATE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("DEVIDENTRATE")))
                    v_strLEFT_DEVIDENTRATE = gf_FormatNumberToSring(v_strDEVIDENTRATE, 0)
                    v_strRIGHT_DEVIDENTRATE = gf_FormatNumberToSring(v_strDEVIDENTRATE, 1)
                    v_strDEVIDENTSHARES = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("DEVIDENTSHARES")))
                    v_strLEFT_DEVIDENTSHARES = gf_FormatNumberToSring(v_strDEVIDENTSHARES, 0)
                    v_strRIGHT_DEVIDENTSHARES = gf_FormatNumberToSring(v_strDEVIDENTSHARES, 1)
                    v_strSPLITRATE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("SPLITRATE")))
                    v_strLEFT_SPLITRATE = gf_FormatNumberToSring(v_strSPLITRATE, 0)
                    v_strRIGHT_SPLITRATE = gf_FormatNumberToSring(v_strSPLITRATE, 1)
                    v_strINTERESTRATE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("INTERESTRATE")))
                    v_strLEFT_INTERESTRATE = gf_FormatNumberToSring(v_strINTERESTRATE, 0)
                    v_strRIGHT_INTERESTRATE = gf_FormatNumberToSring(v_strINTERESTRATE, 1)
                    v_dblINTERESTPERIOD = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("INTERESTPERIOD"))
                    v_strSTATUS = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("STATUS")))
                    v_strROUNDTYPE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("ROUNDTYPE")))
                    v_strOPTCODEID = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("OPTCODEID")))
                    v_strOPTSYMBOl = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("OPTSYMBOl")))

                    v_strQTTYEXP = "0"
                    v_strAMTEXP = "0"
                    v_strAQTTYEXP = "0"
                    v_strAAMTEXP = "0"
                    v_strREQTTYEXP = "0"
                    v_strREAQTTYEXP = "0"
                    ' Tinh gia tri cho CK, tien cho ve.
                    v_strQTTYEXP = "FLOOR(( " & v_strQTTY & " * " & v_strRIGHT_RIGHTOFFRATE & ")/" & v_strLEFT_RIGHTOFFRATE & ")"
                    v_strAAMTEXP = v_dblEXPRICE & "*FLOOR(( " & v_strQTTY & " * " & v_strRIGHT_RIGHTOFFRATE & ")/" & v_strLEFT_RIGHTOFFRATE & ")"
                    'So chung khoan le
                    v_strREQTTYEXP = "(" & v_strQTTYEXP & " - TRUNC(" & v_strQTTYEXP & ", " & v_strROUNDTYPE & "))"
                    v_strREAQTTYEXP = "(" & v_strAQTTYEXP & " - TRUNC(" & v_strAQTTYEXP & ", " & v_strROUNDTYPE & "))"
                    'So chung khoan da lam tron
                    v_strQTTYEXP = "TRUNC(" & v_strQTTYEXP & "," & v_strROUNDTYPE & ")"
                    v_strAQTTYEXP = "TRUNC(" & v_strAQTTYEXP & "," & v_strROUNDTYPE & ")"
                    v_strAMTEXP = v_strAMTEXP & " + " & v_strREQTTYEXP & " * " & v_dblEXPRICE
                    v_strAAMTEXP = v_strAAMTEXP & " + " & v_strREAQTTYEXP & "*" & v_dblEXPRICE
                    v_strREQTTYEXP = 0
                    v_strREAQTTYEXP = 0
                End If

            End If


            If Not v_blnREVERSAL Then
                v_strSQL = "select count(1) from caschd where camastid = '" & v_strCAMASTID & "' and afacctno = '" & v_strAFACCTNO & "'" & ControlChars.CrLf _
                & " and (QTTY -NMQTTY- TQTTY - " & CDbl(v_strQTTY) & ") >= 0"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows(0)(0) = 0 Then
                    Return ERR_CA_CASCHD_OVER_CANCELREGISTER_QTTY
                End If

                v_strSQL = "select count(1) from caschd where camastid = '" & v_strCAMASTID & "' and afacctno = '" & v_strAFACCTNO & "'" & ControlChars.CrLf _
                & " and (QTTY - NMQTTY-DFQTTY - " & CDbl(v_strQTTY) & ") >= 0"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows(0)(0) = 0 Then
                    Return ERR_DF_EXIST_DFDEAL_OPTION
                End If
            Else


            End If
            ''ContextUtil.SetComplete()
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
            Return v_lngErrCode
        Catch ex As Exception
            ''ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
    Private Function Check_3393(ByRef pv_xmlDocument As Xml.XmlDocument) As Long

        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CA.Trans.Check_3393", v_strErrorMessage As String
        Dim v_strSQLTmp As String = String.Empty, v_strSQL As String = String.Empty, i As Integer
        Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE, v_lngCLEARDAY As Double
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSYMBOL As String
            Dim v_strQTTY As Int64
            Dim v_dblEXPRICE As Double

            Dim v_strCAMASTID, v_strAFACCTNO, v_strAFACCTNO_CR, v_strEXCODEID, v_strCODEID, v_strREPORTDATE, v_strACTIONDATE, v_strDUEDATE, v_strSTATUS, v_strOPTCODEID, v_strOPTSYMBOl, v_strFRTRADEPLACE, v_strTOTRADEPLACE As String
            Dim v_dblINTERESTPERIOD, v_dblPARVALUE As Double
            Dim v_strEXRATE, v_strRIGHTOFFRATE, v_strDEVIDENTRATE, v_strDEVIDENTSHARES, v_strSPLITRATE, v_strINTERESTRATE As String
            Dim v_strLEFT_EXRATE, v_strLEFT_RIGHTOFFRATE, v_strLEFT_DEVIDENTRATE, v_strLEFT_DEVIDENTSHARES, v_strLEFT_SPLITRATE, v_strLEFT_INTERESTRATE As String
            Dim v_strRIGHT_EXRATE, v_strRIGHT_RIGHTOFFRATE, v_strRIGHT_DEVIDENTRATE, v_strRIGHT_DEVIDENTSHARES, v_strRIGHT_SPLITRATE, v_strRIGHT_INTERESTRATE As String
            Dim v_strQTTYEXP, v_strAMTEXP, v_strAQTTYEXP, v_strAAMTEXP, v_strROUNDTYPE, v_strROUNDVALUE, v_strREQTTYEXP, v_strREAQTTYEXP As String
            Dim v_dtREPORTDATE, v_dtTXDATE, v_dtACTIONDATE As DateTime
            Dim v_ds As DataSet
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_strBRID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXTIME As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTIME).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_blnREVERSAL As Boolean = IIf(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value = "Y", True, False)

            'LAY NOI DUNG GIAO DICH
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(gf_Numberic(.InnerText), gf_Cdbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If
                    Select Case v_strFLDCD
                        Case "02" 'CAMASTID
                            v_strCAMASTID = v_strVALUE
                        Case "03"
                            v_strAFACCTNO = v_strVALUE
                        Case "04"
                            v_strSYMBOL = v_strVALUE
                        Case "05"
                            v_dblEXPRICE = v_dblVALUE
                        Case "21"
                            v_strQTTY = v_dblVALUE
                    End Select
                End With
            Next


            'TAO DU LIEU MOI
            If Len(v_strCAMASTID) > 0 Then
                'LAY THONG TIN DOT THUC HIEN QUYEN
                v_strSQL = "SELECT * FROM CAMAST WHERE CAMASTID='" & v_strCAMASTID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_strCODEID = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("CODEID")))
                    v_strEXCODEID = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("EXCODEID")))
                    v_strREPORTDATE = gf_CorrectStringField(Format(v_ds.Tables(0).Rows(0)("REPORTDATE"), gc_FORMAT_DATE))
                    v_strACTIONDATE = gf_CorrectStringField(Format(v_ds.Tables(0).Rows(0)("ACTIONDATE"), gc_FORMAT_DATE))
                    v_strDUEDATE = gf_CorrectStringField(Format(v_ds.Tables(0).Rows(0)("DUEDATE"), gc_FORMAT_DATE))
                    v_dblEXPRICE = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("EXPRICE"))
                    v_dblPARVALUE = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("PARVALUE"))
                    v_strEXRATE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("EXRATE")))
                    v_strLEFT_EXRATE = gf_FormatNumberToSring(v_strEXRATE, 0)
                    v_strRIGHT_EXRATE = gf_FormatNumberToSring(v_strEXRATE, 1)
                    v_strRIGHTOFFRATE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("RIGHTOFFRATE")))
                    v_strLEFT_RIGHTOFFRATE = gf_FormatNumberToSring(v_strRIGHTOFFRATE, 0)
                    v_strRIGHT_RIGHTOFFRATE = gf_FormatNumberToSring(v_strRIGHTOFFRATE, 1)
                    v_strDEVIDENTRATE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("DEVIDENTRATE")))
                    v_strLEFT_DEVIDENTRATE = gf_FormatNumberToSring(v_strDEVIDENTRATE, 0)
                    v_strRIGHT_DEVIDENTRATE = gf_FormatNumberToSring(v_strDEVIDENTRATE, 1)
                    v_strDEVIDENTSHARES = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("DEVIDENTSHARES")))
                    v_strLEFT_DEVIDENTSHARES = gf_FormatNumberToSring(v_strDEVIDENTSHARES, 0)
                    v_strRIGHT_DEVIDENTSHARES = gf_FormatNumberToSring(v_strDEVIDENTSHARES, 1)
                    v_strSPLITRATE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("SPLITRATE")))
                    v_strLEFT_SPLITRATE = gf_FormatNumberToSring(v_strSPLITRATE, 0)
                    v_strRIGHT_SPLITRATE = gf_FormatNumberToSring(v_strSPLITRATE, 1)
                    v_strINTERESTRATE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("INTERESTRATE")))
                    v_strLEFT_INTERESTRATE = gf_FormatNumberToSring(v_strINTERESTRATE, 0)
                    v_strRIGHT_INTERESTRATE = gf_FormatNumberToSring(v_strINTERESTRATE, 1)
                    v_dblINTERESTPERIOD = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("INTERESTPERIOD"))
                    v_strSTATUS = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("STATUS")))
                    v_strROUNDTYPE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("ROUNDTYPE")))
                    v_strOPTCODEID = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("OPTCODEID")))
                    v_strOPTSYMBOl = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("OPTSYMBOl")))

                    v_strQTTYEXP = "0"
                    v_strAMTEXP = "0"
                    v_strAQTTYEXP = "0"
                    v_strAAMTEXP = "0"
                    v_strREQTTYEXP = "0"
                    v_strREAQTTYEXP = "0"
                    ' Tinh gia tri cho CK, tien cho ve.
                    v_strQTTYEXP = "FLOOR(( " & v_strQTTY & " * " & v_strRIGHT_RIGHTOFFRATE & ")/" & v_strLEFT_RIGHTOFFRATE & ")"
                    v_strAAMTEXP = v_dblEXPRICE & "*FLOOR(( " & v_strQTTY & " * " & v_strRIGHT_RIGHTOFFRATE & ")/" & v_strLEFT_RIGHTOFFRATE & ")"
                    'So chung khoan le
                    v_strREQTTYEXP = "(" & v_strQTTYEXP & " - TRUNC(" & v_strQTTYEXP & ", " & v_strROUNDTYPE & "))"
                    v_strREAQTTYEXP = "(" & v_strAQTTYEXP & " - TRUNC(" & v_strAQTTYEXP & ", " & v_strROUNDTYPE & "))"
                    'So chung khoan da lam tron
                    v_strQTTYEXP = "TRUNC(" & v_strQTTYEXP & "," & v_strROUNDTYPE & ")"
                    v_strAQTTYEXP = "TRUNC(" & v_strAQTTYEXP & "," & v_strROUNDTYPE & ")"
                    v_strAMTEXP = v_strAMTEXP & " + " & v_strREQTTYEXP & " * " & v_dblEXPRICE
                    v_strAAMTEXP = v_strAAMTEXP & " + " & v_strREAQTTYEXP & "*" & v_dblEXPRICE
                    v_strREQTTYEXP = 0
                    v_strREAQTTYEXP = 0
                End If

            End If


            If Not v_blnREVERSAL Then
                v_strSQL = "select count(1) from caschd where camastid = '" & v_strCAMASTID & "' and afacctno = '" & v_strAFACCTNO & "'" & ControlChars.CrLf _
                & " and (NMQTTY  - " & CDbl(v_strQTTY) & ") >= 0"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows(0)(0) = 0 Then
                    Return ERR_CA_CASCHD_OVER_CANCELREGISTER_QTTY
                End If

                v_strSQL = "select count(1) from caschd where camastid = '" & v_strCAMASTID & "' and afacctno = '" & v_strAFACCTNO & "'" & ControlChars.CrLf _
                & " and (NMQTTY - DFQTTY - " & CDbl(v_strQTTY) & ") >= 0"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows(0)(0) = 0 Then
                    Return ERR_DF_EXIST_DFDEAL_OPTION
                End If
            Else


            End If
            ''ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            ''ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function Check_3383(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CA.Trans.RejectCAEvent", v_strErrorMessage As String
        Dim v_strSQLTmp As String = String.Empty, v_strSQL As String = String.Empty, i, v_strNumber As Integer
        Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE, v_lngCLEARDAY As Double
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strCAMASTID, v_strAFACCTNO, v_strAFACCTNO1, v_strSYMBOL, v_strSTATUS As String
            Dim v_strRETAILBAL, v_dblQTTY As Int64
            Dim v_ds As DataSet
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_strBRID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXTIME As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTIME).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_blnREVERSAL As Boolean = IIf(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value = "Y", True, False)

            'LAY NOI DUNG GIAO DICH
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(gf_Numberic(.InnerText), gf_Cdbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If
                    Select Case v_strFLDCD
                        Case "06" 'CAMASTID
                            v_strCAMASTID = v_strVALUE
                        Case "02"
                            v_strAFACCTNO = v_strVALUE

                        Case "21"
                            v_dblQTTY = v_dblVALUE
                    End Select
                End With
            Next

            If Not v_blnREVERSAL Then   'NEU DUYET
                'Chi thuc hien voi su kien Stock RightOff 
                'v_strSQL = "SELECT CATYPE,TRANSFERTIMES FROM CAMAST WHERE CAMASTID='" & v_strCAMASTID & "'"
                'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                'Dim v_strCATYPE As String = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("CATYPE")), String.Empty, v_ds.Tables(0).Rows(0)("CATYPE"))
                'Dim TRANSFERTIMES As String = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("TRANSFERTIMES")), 0, v_ds.Tables(0).Rows(0)("TRANSFERTIMES"))
                'If v_strCATYPE <> "014" Then
                '    Return v_lngErrCode = ERR_CA_NOTIN_STOCK_RIGHT_OFF
                'End If
                ''TransferTimes=1
                'v_strSQL = "select TransferTimes from CAMAST WHERE CAMASTID='" & v_strCAMASTID & "'"
                'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                'Dim v_strTransferTimes As Int16 = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("TransferTimes")), 0, v_ds.Tables(0).Rows(0)("TransferTimes"))
                'If v_strTransferTimes = 1 Then
                '    v_strSQL = "SELECT QTTY_Transfer from SEMAST WHERE AFACCTNO='" & v_strAFACCTNO & "' AND CODEID=(SELECT CODEID FROM SBSECURITiES WHERE SYMBOL like '" & v_strSYMBOL & "_%')"
                '    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                '    If v_ds.Tables(0).Rows.Count > 0 Then
                '        v_strQTTY_TRANSFER = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("QTTY_Transfer")), 0, v_ds.Tables(0).Rows(0)("QTTY_Transfer"))
                '        If v_strQTTY_TRANSFER < v_strQTTY Then
                '            Return v_lngErrCode = ERR_CA_QTTY_TRANSFER
                '        End If
                '    Else
                '        Return v_lngErrCode = ERR_CA_SEMAST_NOTFOUND
                '    End If
                'End If
                'If v_strTransferTimes = 0 Then
                '    Return v_lngErrCode = ERR_CA_CANNOT_RETAIL
                'End If
                ''Kiem tra trang thai dot thuc hien quyen
                'v_strSQL = "SELECT STATUS FROM CAMAST WHERE CAMASTID='" & v_strCAMASTID & "'"
                'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                'v_strSTATUS = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("STATUS")), 0, v_ds.Tables(0).Rows(0)("STATUS"))
                'If v_strSTATUS <> "A" Then
                '    Return ERR_CAMAST_STATUS_INVALID
                'End If
                ''Kiem tra ACCTNO co thuoc dot thuc hien quyen
                'v_strSQL = "SELECT COUNT(*) COUNT FROM (select * from CASCHD WHERE CAMASTID='" & v_strCAMASTID & "')T WHERE T.AFACCTNO='" & v_strAFACCTNO & "' "
                'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                'Dim v_strCOUNT As Int16 = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("COUNT")), 0, v_ds.Tables(0).Rows(0)("COUNT"))
                'If v_strCOUNT <= 0 Then
                '    Return v_lngErrCode = ERR_CF_AFMAST_NOTIN_CASCHD
                'End If
                'so luong nhap khong vuot qua qtty




                'TransferTimes=1
                v_strSQL = "select TransferTimes ,TRFLIMIT  from CAMAST WHERE CAMASTID='" & v_strCAMASTID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                Dim v_strTransferTimes As Int16 = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("TransferTimes")), 0, v_ds.Tables(0).Rows(0)("TransferTimes"))
                Dim v_strTRFLIMIT As String = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("TRFLIMIT")), "", v_ds.Tables(0).Rows(0)("TRFLIMIT"))

                ' check xem quyen mua co dc chuyen nhuong hay khong
                If v_strTRFLIMIT = "Y" Then
                    v_strSQL = "SELECT RETAILBAL FROM CASCHD WHERE CAMASTID='" & v_strCAMASTID & "' AND AFACCTNO ='" & v_strAFACCTNO & "' and deltd <>'Y' "
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count > 0 Then
                        v_strRETAILBAL = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("RETAILBAL")), 0, v_ds.Tables(0).Rows(0)("RETAILBAL"))
                        If v_strRETAILBAL < v_dblQTTY Then
                            v_lngErrCode = ERR_CA_QTTY_TRANSFER
                            LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                    & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                    & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                            Return v_lngErrCode
                        End If
                    Else
                        v_lngErrCode = ERR_CA_SEMAST_NOTFOUND
                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                    & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                    & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                        Return v_lngErrCode
                    End If
                Else
                    v_lngErrCode = ERR_CA_CANNOT_RETAIL
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                    & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                    & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If


                'Kiem tra xem voi dang ky quyen mua. 
                v_strSQL = "SELECT COUNT(1) FROM CAMAST CA, SYSVAR SYS WHERE SYS.VARNAME = 'CURRDATE' AND SYS.GRNAME = 'SYSTEM' AND CATYPE = '014' AND TO_DATE (VARVALUE,'DD/MM/RRRR') >= FRDATETRANSFER AND camastid = '" & v_strCAMASTID & "' "
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows(0)(0) = 0 Then
                    'Khong cho phep thuc hien vi da den ngay.
                    v_lngErrCode = ERR_CA_DATE_CANNOT_EXECUTE
                End If

            Else
                'XOA GIAO DICH
            End If

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
            ''ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            ''ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
    Private Function Check_3384(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CA.Trans.RejectCAEvent", v_strErrorMessage As String
        Dim v_strSQLTmp As String = String.Empty, v_strSQL As String = String.Empty, i, v_strNumber As Integer
        Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE, v_lngCLEARDAY As Double
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strCAMASTID, v_strAFACCTNO, v_strAFACCTNO1, v_strSYMBOL, v_strSTATUS As String
            Dim v_strQTTY_TRANSFER, v_dblQTTY As Int64
            Dim v_dblEXPRICE As Double
            Dim v_ds As DataSet
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_strBRID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXTIME As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTIME).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_blnREVERSAL As Boolean = IIf(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value = "Y", True, False)

            'LAY NOI DUNG GIAO DICH
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(gf_Numberic(.InnerText), gf_Cdbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If
                    Select Case v_strFLDCD
                        Case "02" 'CAMASTID
                            v_strCAMASTID = v_strVALUE
                        Case "03"
                            v_strAFACCTNO = v_strVALUE
                        Case "04"
                            v_strSYMBOL = v_strVALUE
                        Case "05"
                            v_dblEXPRICE = v_strVALUE
                        Case "21"
                            v_dblQTTY = v_dblVALUE
                    End Select
                End With
            Next

            If Not v_blnREVERSAL Then   'NEU DUYET
                'Chi thuc hien voi su kien Stock RightOff
                'v_strSQL = "SELECT CATYPE,TRANSFERTIMES FROM CAMAST WHERE CAMASTID='" & v_strCAMASTID & "'"
                'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                'Dim v_strCATYPE As String = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("CATYPE")), String.Empty, v_ds.Tables(0).Rows(0)("CATYPE"))
                'Dim TRANSFERTIMES As String = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("TRANSFERTIMES")), 0, v_ds.Tables(0).Rows(0)("TRANSFERTIMES"))
                'If v_strCATYPE <> "014" Then
                '    Return v_lngErrCode = ERR_CA_NOTIN_STOCK_RIGHT_OFF
                'End If
                ''TransferTimes=1
                'v_strSQL = "select TransferTimes from CAMAST WHERE CAMASTID='" & v_strCAMASTID & "'"
                'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                'Dim v_strTransferTimes As Int16 = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("TransferTimes")), 0, v_ds.Tables(0).Rows(0)("TransferTimes"))
                'If v_strTransferTimes = 1 Then
                '    v_strSQL = "SELECT QTTY_Transfer from SEMAST WHERE AFACCTNO='" & v_strAFACCTNO & "' AND CODEID=(SELECT CODEID FROM SBSECURITiES WHERE SYMBOL like '" & v_strSYMBOL & "_%')"
                '    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                '    If v_ds.Tables(0).Rows.Count > 0 Then
                '        v_strQTTY_TRANSFER = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("QTTY_Transfer")), 0, v_ds.Tables(0).Rows(0)("QTTY_Transfer"))
                '        If v_strQTTY_TRANSFER < v_strQTTY Then
                '            v_lngErrCode = ERR_CA_QTTY_TRANSFER
                '        End If
                '    Else
                '        Return v_lngErrCode = ERR_CA_SEMAST_NOTFOUND
                '    End If

                'End If
                'If v_strTransferTimes = 0 Then
                '    Return v_lngErrCode = ERR_CA_CANNOT_RETAIL
                'End If
                ''Kiem tra trang thai dot thuc hien quyen
                'v_strSQL = "SELECT STATUS FROM CAMAST WHERE CAMASTID='" & v_strCAMASTID & "'"
                'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                'v_strSTATUS = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("STATUS")), 0, v_ds.Tables(0).Rows(0)("STATUS"))
                'If v_strSTATUS <> "A" Then
                '    Return ERR_CAMAST_STATUS_INVALID
                'End If
                ''Kiem tra ACCTNO co thuoc dot thuc hien quyen
                'v_strSQL = "SELECT COUNT(*) COUNT FROM (select * from CASCHD WHERE CAMASTID='" & v_strCAMASTID & "')T WHERE T.AFACCTNO='" & v_strAFACCTNO & "' "
                'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                'Dim v_strCOUNT As Int16 = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("COUNT")), 0, v_ds.Tables(0).Rows(0)("COUNT"))
                'If v_strCOUNT <= 0 Then
                '    Return v_lngErrCode = ERR_CF_AFMAST_NOTIN_CASCHD
                'End If

                v_strSQL = "select PQTTY   from CASCHD WHERE CAMASTID='" & v_strCAMASTID & "' AND AFACCTNO ='" & v_strAFACCTNO & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                Dim v_dblqttymax As Double = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("PQTTY")), 0, v_ds.Tables(0).Rows(0)("PQTTY"))
                If v_dblqttymax < v_dblQTTY Then
                    v_lngErrCode = ERR_CA_CAQTTY_SMALLER
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                              & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                              & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If

                'Kiem tra xem voi dang ky quyen mua. 
                v_strSQL = "SELECT COUNT(1) FROM CAMAST CA, SYSVAR SYS WHERE SYS.VARNAME = 'CURRDATE' AND SYS.GRNAME = 'SYSTEM' AND CATYPE = '014' AND TO_DATE (VARVALUE,'DD/MM/RRRR') >= FRDATETRANSFER AND camastid = '" & v_strCAMASTID & "' "
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows(0)(0) = 0 Then
                    'Khong cho phep thuc hien vi da den ngay.
                    v_lngErrCode = ERR_CA_DATE_CANNOT_EXECUTE
                End If

                'Kiem tra xem voi dang ky quyen mua. 
                v_strSQL = "SELECT COUNT(1) FROM CAMAST CA, SYSVAR SYS WHERE SYS.VARNAME = 'CURRDATE' AND SYS.GRNAME = 'SYSTEM' AND CATYPE = '014' AND TO_DATE (VARVALUE,'DD/MM/RRRR') <= DUEDATE AND camastid = '" & v_strCAMASTID & "' "
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows(0)(0) = 0 Then
                    'Khong cho phep thuc hien vi da den ngay.
                    v_lngErrCode = ERR_CA_DATE_OUTOF_REGISTER
                End If
            Else
                'XOA GIAO DICH
            End If
            ''ContextUtil.SetComplete()
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
            Return v_lngErrCode
        Catch ex As Exception
            ''ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
    Private Function Check_3390(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CA.Trans.Check_3390", v_strErrorMessage As String
        Dim v_strSQL As String = String.Empty
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE, v_strCONFIRMPIN, v_strPIN As String, v_dblVALUE As Double
            Dim v_strPITRATEMETHOD, v_strPITRATE As String
            Dim v_strPIT_NO As String = "NO"

            Dim v_strPITRATEN As Double

            '�?�?c nội dung giao dịch
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
                        Case "11" '
                            v_strPITRATE = v_dblVALUE
                        Case "12" '
                            v_strPITRATEMETHOD = v_strVALUE
                    End Select
                End With
            Next

            v_strPITRATEN = CDbl(v_strPITRATE)

            If (v_strPITRATEN < 0 Or v_strPITRATEN > 100) Then
                Return ERR_NumberNotIn_1_100 'Muc thue nam trong 0 den 100
            End If
            If ((v_strPITRATEMETHOD = v_strPIT_NO) And v_strPITRATE <> 0) Then
                Return ERR_NotExchangePitrateWhenNotSC        'chi thay doi TTNCN khi loai quyen la chia co tuc bang tien
            End If


            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function CancelStockRightoff(ByRef pv_xmlDocument As Xml.XmlDocument) As Long

        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CA.Trans.RejectCAEvent", v_strErrorMessage As String
        Dim v_strSQLTmp As String = String.Empty, v_strSQL As String = String.Empty, i As Integer
        Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE, v_lngCLEARDAY As Double
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSYMBOL As String
            Dim v_strQTTY As Int64
            Dim v_dblEXPRICE As Double

            Dim v_strCAMASTID, v_strAFACCTNO, v_strAFACCTNO_CR, v_strEXCODEID, v_strCODEID, v_strREPORTDATE, v_strACTIONDATE, v_strDUEDATE, v_strSTATUS, v_strOPTCODEID, v_strOPTSYMBOl, v_strFRTRADEPLACE, v_strTOTRADEPLACE As String
            Dim v_dblINTERESTPERIOD, v_dblPARVALUE As Double
            Dim v_strEXRATE, v_strRIGHTOFFRATE, v_strDEVIDENTRATE, v_strDEVIDENTSHARES, v_strSPLITRATE, v_strINTERESTRATE As String
            Dim v_strLEFT_EXRATE, v_strLEFT_RIGHTOFFRATE, v_strLEFT_DEVIDENTRATE, v_strLEFT_DEVIDENTSHARES, v_strLEFT_SPLITRATE, v_strLEFT_INTERESTRATE As String
            Dim v_strRIGHT_EXRATE, v_strRIGHT_RIGHTOFFRATE, v_strRIGHT_DEVIDENTRATE, v_strRIGHT_DEVIDENTSHARES, v_strRIGHT_SPLITRATE, v_strRIGHT_INTERESTRATE As String
            Dim v_strQTTYEXP, v_strAMTEXP, v_strAQTTYEXP, v_strAAMTEXP, v_strROUNDTYPE, v_strROUNDVALUE, v_strREQTTYEXP, v_strREAQTTYEXP As String
            Dim v_dtREPORTDATE, v_dtTXDATE, v_dtACTIONDATE As DateTime
            Dim v_ds As DataSet
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_strBRID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXTIME As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTIME).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_blnREVERSAL As Boolean = IIf(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value = "Y", True, False)

            'LAY NOI DUNG GIAO DICH
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(gf_Numberic(.InnerText), gf_Cdbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If
                    Select Case v_strFLDCD
                        Case "02" 'CAMASTID
                            v_strCAMASTID = v_strVALUE
                        Case "03"
                            v_strAFACCTNO = v_strVALUE
                        Case "04"
                            v_strSYMBOL = v_strVALUE
                        Case "05"
                            v_dblEXPRICE = v_dblVALUE
                        Case "21"
                            v_strQTTY = v_dblVALUE
                    End Select
                End With
            Next


            'TAO DU LIEU MOI
            If Len(v_strCAMASTID) > 0 Then
                'LAY THONG TIN DOT THUC HIEN QUYEN
                v_strSQL = "SELECT * FROM CAMAST WHERE CAMASTID='" & v_strCAMASTID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_strCODEID = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("CODEID")))
                    v_strEXCODEID = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("EXCODEID")))
                    v_strREPORTDATE = gf_CorrectStringField(Format(v_ds.Tables(0).Rows(0)("REPORTDATE"), gc_FORMAT_DATE))
                    v_strACTIONDATE = gf_CorrectStringField(Format(v_ds.Tables(0).Rows(0)("ACTIONDATE"), gc_FORMAT_DATE))
                    v_strDUEDATE = gf_CorrectStringField(Format(v_ds.Tables(0).Rows(0)("DUEDATE"), gc_FORMAT_DATE))
                    v_dblEXPRICE = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("EXPRICE"))
                    v_dblPARVALUE = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("PARVALUE"))
                    v_strEXRATE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("EXRATE")))
                    v_strLEFT_EXRATE = gf_FormatNumberToSring(v_strEXRATE, 0)
                    v_strRIGHT_EXRATE = gf_FormatNumberToSring(v_strEXRATE, 1)
                    v_strRIGHTOFFRATE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("RIGHTOFFRATE")))
                    v_strLEFT_RIGHTOFFRATE = gf_FormatNumberToSring(v_strRIGHTOFFRATE, 0)
                    v_strRIGHT_RIGHTOFFRATE = gf_FormatNumberToSring(v_strRIGHTOFFRATE, 1)
                    v_strDEVIDENTRATE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("DEVIDENTRATE")))
                    v_strLEFT_DEVIDENTRATE = gf_FormatNumberToSring(v_strDEVIDENTRATE, 0)
                    v_strRIGHT_DEVIDENTRATE = gf_FormatNumberToSring(v_strDEVIDENTRATE, 1)
                    v_strDEVIDENTSHARES = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("DEVIDENTSHARES")))
                    v_strLEFT_DEVIDENTSHARES = gf_FormatNumberToSring(v_strDEVIDENTSHARES, 0)
                    v_strRIGHT_DEVIDENTSHARES = gf_FormatNumberToSring(v_strDEVIDENTSHARES, 1)
                    v_strSPLITRATE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("SPLITRATE")))
                    v_strLEFT_SPLITRATE = gf_FormatNumberToSring(v_strSPLITRATE, 0)
                    v_strRIGHT_SPLITRATE = gf_FormatNumberToSring(v_strSPLITRATE, 1)
                    v_strINTERESTRATE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("INTERESTRATE")))
                    v_strLEFT_INTERESTRATE = gf_FormatNumberToSring(v_strINTERESTRATE, 0)
                    v_strRIGHT_INTERESTRATE = gf_FormatNumberToSring(v_strINTERESTRATE, 1)
                    v_dblINTERESTPERIOD = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("INTERESTPERIOD"))
                    v_strSTATUS = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("STATUS")))
                    v_strROUNDTYPE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("ROUNDTYPE")))
                    v_strOPTCODEID = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("OPTCODEID")))
                    v_strOPTSYMBOl = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("OPTSYMBOl")))

                    v_strQTTYEXP = "0"
                    v_strAMTEXP = "0"
                    v_strAQTTYEXP = "0"
                    v_strAAMTEXP = "0"
                    v_strREQTTYEXP = "0"
                    v_strREAQTTYEXP = "0"
                    ' Tinh gia tri cho CK, tien cho ve.
                    v_strQTTYEXP = "FLOOR(( " & v_strQTTY & " * " & v_strRIGHT_RIGHTOFFRATE & ")/" & v_strLEFT_RIGHTOFFRATE & ")"
                    v_strAAMTEXP = v_dblEXPRICE & "*FLOOR(( " & v_strQTTY & " * " & v_strRIGHT_RIGHTOFFRATE & ")/" & v_strLEFT_RIGHTOFFRATE & ")"
                    'So chung khoan le
                    v_strREQTTYEXP = "(" & v_strQTTYEXP & " - TRUNC(" & v_strQTTYEXP & ", " & v_strROUNDTYPE & "))"
                    v_strREAQTTYEXP = "(" & v_strAQTTYEXP & " - TRUNC(" & v_strAQTTYEXP & ", " & v_strROUNDTYPE & "))"
                    'So chung khoan da lam tron
                    v_strQTTYEXP = "TRUNC(" & v_strQTTYEXP & "," & v_strROUNDTYPE & ")"
                    v_strAQTTYEXP = "TRUNC(" & v_strAQTTYEXP & "," & v_strROUNDTYPE & ")"
                    v_strAMTEXP = v_strAMTEXP & " + " & v_strREQTTYEXP & " * " & v_dblEXPRICE
                    v_strAAMTEXP = v_strAAMTEXP & " + " & v_strREAQTTYEXP & "*" & v_dblEXPRICE
                    v_strREQTTYEXP = 0
                    v_strREAQTTYEXP = 0
                End If

            End If


            If Not v_blnREVERSAL Then
                ' giam chung khoan phai sinh 



                'Cap nhat giam so tien nop cho quyen mua
                v_strSQL = "UPDATE CASCHD SET  BALANCE = BALANCE - " & " TRUNC(" & v_strQTTY * v_strLEFT_RIGHTOFFRATE / v_strRIGHT_RIGHTOFFRATE & ") ,AAMT= AAMT - " & v_dblEXPRICE * v_strQTTY & " ,QTTY= QTTY - " & v_strQTTY & ControlChars.CrLf _
                & " ,PAAMT= PAAMT + " & v_dblEXPRICE * v_strQTTY & " ,PQTTY= PQTTY + " & v_strQTTY & ",PBALANCE = PBALANCE + " & " TRUNC(" & v_strQTTY * v_strLEFT_RIGHTOFFRATE / v_strRIGHT_RIGHTOFFRATE & ")  WHERE AFACCTNO='" & v_strAFACCTNO & "' AND CAMASTID='" & v_strCAMASTID & "' AND DELTD = 'N'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            Else


            End If
            ''ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            ''ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function CancelStockRightoffNoMoney(ByRef pv_xmlDocument As Xml.XmlDocument) As Long

        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CA.Trans.RejectCAEvent", v_strErrorMessage As String
        Dim v_strSQLTmp As String = String.Empty, v_strSQL As String = String.Empty, i As Integer
        Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE, v_lngCLEARDAY As Double
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSYMBOL As String
            Dim v_strQTTY As Int64
            Dim v_dblEXPRICE As Double

            Dim v_strCAMASTID, v_strAFACCTNO, v_strAFACCTNO_CR, v_strEXCODEID, v_strCODEID, v_strREPORTDATE, v_strACTIONDATE, v_strDUEDATE, v_strSTATUS, v_strOPTCODEID, v_strOPTSYMBOl, v_strFRTRADEPLACE, v_strTOTRADEPLACE As String
            Dim v_dblINTERESTPERIOD, v_dblPARVALUE As Double
            Dim v_strEXRATE, v_strRIGHTOFFRATE, v_strDEVIDENTRATE, v_strDEVIDENTSHARES, v_strSPLITRATE, v_strINTERESTRATE As String
            Dim v_strLEFT_EXRATE, v_strLEFT_RIGHTOFFRATE, v_strLEFT_DEVIDENTRATE, v_strLEFT_DEVIDENTSHARES, v_strLEFT_SPLITRATE, v_strLEFT_INTERESTRATE As String
            Dim v_strRIGHT_EXRATE, v_strRIGHT_RIGHTOFFRATE, v_strRIGHT_DEVIDENTRATE, v_strRIGHT_DEVIDENTSHARES, v_strRIGHT_SPLITRATE, v_strRIGHT_INTERESTRATE As String
            Dim v_strQTTYEXP, v_strAMTEXP, v_strAQTTYEXP, v_strAAMTEXP, v_strROUNDTYPE, v_strROUNDVALUE, v_strREQTTYEXP, v_strREAQTTYEXP As String
            Dim v_dtREPORTDATE, v_dtTXDATE, v_dtACTIONDATE As DateTime
            Dim v_ds As DataSet
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_strBRID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXTIME As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTIME).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_blnREVERSAL As Boolean = IIf(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value = "Y", True, False)

            'LAY NOI DUNG GIAO DICH
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(gf_Numberic(.InnerText), gf_Cdbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If
                    Select Case v_strFLDCD
                        Case "02" 'CAMASTID
                            v_strCAMASTID = v_strVALUE
                        Case "03"
                            v_strAFACCTNO = v_strVALUE
                        Case "04"
                            v_strSYMBOL = v_strVALUE
                        Case "05"
                            v_dblEXPRICE = v_dblVALUE
                        Case "21"
                            v_strQTTY = v_dblVALUE
                    End Select
                End With
            Next


            'TAO DU LIEU MOI
            If Len(v_strCAMASTID) > 0 Then
                'LAY THONG TIN DOT THUC HIEN QUYEN
                v_strSQL = "SELECT * FROM CAMAST WHERE CAMASTID='" & v_strCAMASTID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_strCODEID = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("CODEID")))
                    v_strEXCODEID = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("EXCODEID")))
                    v_strREPORTDATE = gf_CorrectStringField(Format(v_ds.Tables(0).Rows(0)("REPORTDATE"), gc_FORMAT_DATE))
                    v_strACTIONDATE = gf_CorrectStringField(Format(v_ds.Tables(0).Rows(0)("ACTIONDATE"), gc_FORMAT_DATE))
                    v_strDUEDATE = gf_CorrectStringField(Format(v_ds.Tables(0).Rows(0)("DUEDATE"), gc_FORMAT_DATE))
                    v_dblEXPRICE = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("EXPRICE"))
                    v_dblPARVALUE = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("PARVALUE"))
                    v_strEXRATE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("EXRATE")))
                    v_strLEFT_EXRATE = gf_FormatNumberToSring(v_strEXRATE, 0)
                    v_strRIGHT_EXRATE = gf_FormatNumberToSring(v_strEXRATE, 1)
                    v_strRIGHTOFFRATE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("RIGHTOFFRATE")))
                    v_strLEFT_RIGHTOFFRATE = gf_FormatNumberToSring(v_strRIGHTOFFRATE, 0)
                    v_strRIGHT_RIGHTOFFRATE = gf_FormatNumberToSring(v_strRIGHTOFFRATE, 1)
                    v_strDEVIDENTRATE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("DEVIDENTRATE")))
                    v_strLEFT_DEVIDENTRATE = gf_FormatNumberToSring(v_strDEVIDENTRATE, 0)
                    v_strRIGHT_DEVIDENTRATE = gf_FormatNumberToSring(v_strDEVIDENTRATE, 1)
                    v_strDEVIDENTSHARES = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("DEVIDENTSHARES")))
                    v_strLEFT_DEVIDENTSHARES = gf_FormatNumberToSring(v_strDEVIDENTSHARES, 0)
                    v_strRIGHT_DEVIDENTSHARES = gf_FormatNumberToSring(v_strDEVIDENTSHARES, 1)
                    v_strSPLITRATE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("SPLITRATE")))
                    v_strLEFT_SPLITRATE = gf_FormatNumberToSring(v_strSPLITRATE, 0)
                    v_strRIGHT_SPLITRATE = gf_FormatNumberToSring(v_strSPLITRATE, 1)
                    v_strINTERESTRATE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("INTERESTRATE")))
                    v_strLEFT_INTERESTRATE = gf_FormatNumberToSring(v_strINTERESTRATE, 0)
                    v_strRIGHT_INTERESTRATE = gf_FormatNumberToSring(v_strINTERESTRATE, 1)
                    v_dblINTERESTPERIOD = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("INTERESTPERIOD"))
                    v_strSTATUS = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("STATUS")))
                    v_strROUNDTYPE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("ROUNDTYPE")))
                    v_strOPTCODEID = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("OPTCODEID")))
                    v_strOPTSYMBOl = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("OPTSYMBOl")))

                    v_strQTTYEXP = "0"
                    v_strAMTEXP = "0"
                    v_strAQTTYEXP = "0"
                    v_strAAMTEXP = "0"
                    v_strREQTTYEXP = "0"
                    v_strREAQTTYEXP = "0"
                    ' Tinh gia tri cho CK, tien cho ve.
                    v_strQTTYEXP = "FLOOR(( " & v_strQTTY & " * " & v_strRIGHT_RIGHTOFFRATE & ")/" & v_strLEFT_RIGHTOFFRATE & ")"
                    v_strAAMTEXP = v_dblEXPRICE & "*FLOOR(( " & v_strQTTY & " * " & v_strRIGHT_RIGHTOFFRATE & ")/" & v_strLEFT_RIGHTOFFRATE & ")"
                    'So chung khoan le
                    v_strREQTTYEXP = "(" & v_strQTTYEXP & " - TRUNC(" & v_strQTTYEXP & ", " & v_strROUNDTYPE & "))"
                    v_strREAQTTYEXP = "(" & v_strAQTTYEXP & " - TRUNC(" & v_strAQTTYEXP & ", " & v_strROUNDTYPE & "))"
                    'So chung khoan da lam tron
                    v_strQTTYEXP = "TRUNC(" & v_strQTTYEXP & "," & v_strROUNDTYPE & ")"
                    v_strAQTTYEXP = "TRUNC(" & v_strAQTTYEXP & "," & v_strROUNDTYPE & ")"
                    v_strAMTEXP = v_strAMTEXP & " + " & v_strREQTTYEXP & " * " & v_dblEXPRICE
                    v_strAAMTEXP = v_strAAMTEXP & " + " & v_strREAQTTYEXP & "*" & v_dblEXPRICE
                    v_strREQTTYEXP = 0
                    v_strREAQTTYEXP = 0
                End If

            End If


            If Not v_blnREVERSAL Then
                ' giam chung khoan phai sinh 



                'Cap nhat giam so tien nop cho quyen mua
                v_strSQL = "UPDATE CASCHD SET  BALANCE = BALANCE - " & " TRUNC(" & v_strQTTY * v_strLEFT_RIGHTOFFRATE / v_strRIGHT_RIGHTOFFRATE & ") ,AAMT= AAMT - " & v_dblEXPRICE * v_strQTTY & " ,QTTY= QTTY - " & v_strQTTY & " ,NMQTTY= NMQTTY - " & v_strQTTY & ControlChars.CrLf _
                & " ,PAAMT= PAAMT + " & v_dblEXPRICE * v_strQTTY & " ,PQTTY= PQTTY + " & v_strQTTY & ",PBALANCE = PBALANCE + " & " TRUNC(" & v_strQTTY * v_strLEFT_RIGHTOFFRATE / v_strRIGHT_RIGHTOFFRATE & ")  WHERE AFACCTNO='" & v_strAFACCTNO & "' AND CAMASTID='" & v_strCAMASTID & "' AND DELTD = 'N'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            Else


            End If
            ''ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            ''ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function Transfer_3384(ByRef pv_xmlDocument As Xml.XmlDocument) As Long

        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CA.Trans.RejectCAEvent", v_strErrorMessage As String
        Dim v_strSQLTmp As String = String.Empty, v_strSQL As String = String.Empty, i As Integer
        Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE, v_lngCLEARDAY As Double
        Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
        Dim v_strTLTXCD As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLTXCD), Xml.XmlAttribute).Value)
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSYMBOL, v_strSTS As String
            Dim v_strQTTY As Int64
            Dim v_dblEXPRICE As Double

            Dim v_strCAMASTID, v_strAFACCTNO, v_strAFACCTNO_CR, v_strEXCODEID, v_strCODEID, v_strREPORTDATE, v_strACTIONDATE, v_strDUEDATE, v_strSTATUS, v_strOPTCODEID, v_strOPTSYMBOl, v_strFRTRADEPLACE, v_strTOTRADEPLACE As String
            Dim v_dblINTERESTPERIOD, v_dblPARVALUE As Double
            Dim v_strEXRATE, v_strRIGHTOFFRATE, v_strDEVIDENTRATE, v_strDEVIDENTSHARES, v_strSPLITRATE, v_strINTERESTRATE As String
            Dim v_strLEFT_EXRATE, v_strLEFT_RIGHTOFFRATE, v_strLEFT_DEVIDENTRATE, v_strLEFT_DEVIDENTSHARES, v_strLEFT_SPLITRATE, v_strLEFT_INTERESTRATE As String
            Dim v_strRIGHT_EXRATE, v_strRIGHT_RIGHTOFFRATE, v_strRIGHT_DEVIDENTRATE, v_strRIGHT_DEVIDENTSHARES, v_strRIGHT_SPLITRATE, v_strRIGHT_INTERESTRATE As String
            Dim v_strQTTYEXP, v_strAMTEXP, v_strAQTTYEXP, v_strAAMTEXP, v_strROUNDTYPE, v_strROUNDVALUE, v_strREQTTYEXP, v_strREAQTTYEXP As String
            Dim v_dtREPORTDATE, v_dtTXDATE, v_dtACTIONDATE As DateTime
            Dim v_ds As DataSet
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_strBRID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXTIME As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTIME).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_blnREVERSAL As Boolean = IIf(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value = "Y", True, False)

            'LAY NOI DUNG GIAO DICH
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(gf_Numberic(.InnerText), gf_Cdbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If
                    Select Case v_strFLDCD
                        Case "02" 'CAMASTID
                            v_strCAMASTID = v_strVALUE
                        Case "03"
                            v_strAFACCTNO = v_strVALUE
                        Case "04"
                            v_strSYMBOL = v_strVALUE
                        Case "05"
                            v_dblEXPRICE = v_dblVALUE
                        Case "21"
                            v_strQTTY = v_dblVALUE
                        Case "40" 'STATUS
                            v_strSTS = v_strVALUE
                    End Select
                End With
            Next


            'TAO DU LIEU MOI
            If Len(v_strCAMASTID) > 0 Then
                'LAY THONG TIN DOT THUC HIEN QUYEN
                v_strSQL = "SELECT * FROM CAMAST WHERE CAMASTID='" & v_strCAMASTID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_strCODEID = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("CODEID")))
                    v_strEXCODEID = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("EXCODEID")))
                    v_strREPORTDATE = gf_CorrectStringField(Format(v_ds.Tables(0).Rows(0)("REPORTDATE"), gc_FORMAT_DATE))
                    v_strACTIONDATE = gf_CorrectStringField(Format(v_ds.Tables(0).Rows(0)("ACTIONDATE"), gc_FORMAT_DATE))
                    v_strDUEDATE = gf_CorrectStringField(Format(v_ds.Tables(0).Rows(0)("DUEDATE"), gc_FORMAT_DATE))
                    v_dblEXPRICE = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("EXPRICE"))
                    v_dblPARVALUE = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("PARVALUE"))
                    v_strEXRATE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("EXRATE")))
                    v_strLEFT_EXRATE = gf_FormatNumberToSring(v_strEXRATE, 0)
                    v_strRIGHT_EXRATE = gf_FormatNumberToSring(v_strEXRATE, 1)
                    v_strRIGHTOFFRATE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("RIGHTOFFRATE")))
                    v_strLEFT_RIGHTOFFRATE = gf_FormatNumberToSring(v_strRIGHTOFFRATE, 0)
                    v_strRIGHT_RIGHTOFFRATE = gf_FormatNumberToSring(v_strRIGHTOFFRATE, 1)
                    v_strDEVIDENTRATE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("DEVIDENTRATE")))
                    v_strLEFT_DEVIDENTRATE = gf_FormatNumberToSring(v_strDEVIDENTRATE, 0)
                    v_strRIGHT_DEVIDENTRATE = gf_FormatNumberToSring(v_strDEVIDENTRATE, 1)
                    v_strDEVIDENTSHARES = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("DEVIDENTSHARES")))
                    v_strLEFT_DEVIDENTSHARES = gf_FormatNumberToSring(v_strDEVIDENTSHARES, 0)
                    v_strRIGHT_DEVIDENTSHARES = gf_FormatNumberToSring(v_strDEVIDENTSHARES, 1)
                    v_strSPLITRATE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("SPLITRATE")))
                    v_strLEFT_SPLITRATE = gf_FormatNumberToSring(v_strSPLITRATE, 0)
                    v_strRIGHT_SPLITRATE = gf_FormatNumberToSring(v_strSPLITRATE, 1)
                    v_strINTERESTRATE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("INTERESTRATE")))
                    v_strLEFT_INTERESTRATE = gf_FormatNumberToSring(v_strINTERESTRATE, 0)
                    v_strRIGHT_INTERESTRATE = gf_FormatNumberToSring(v_strINTERESTRATE, 1)
                    v_dblINTERESTPERIOD = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("INTERESTPERIOD"))
                    v_strSTATUS = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("STATUS")))
                    v_strROUNDTYPE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("ROUNDTYPE")))
                    v_strOPTCODEID = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("OPTCODEID")))
                    v_strOPTSYMBOl = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("OPTSYMBOl")))

                    v_strQTTYEXP = "0"
                    v_strAMTEXP = "0"
                    v_strAQTTYEXP = "0"
                    v_strAAMTEXP = "0"
                    v_strREQTTYEXP = "0"
                    v_strREAQTTYEXP = "0"
                    ' Tinh gia tri cho CK, tien cho ve.
                    v_strQTTYEXP = "FLOOR(( " & v_strQTTY & " * " & v_strRIGHT_RIGHTOFFRATE & ")/" & v_strLEFT_RIGHTOFFRATE & ")"
                    v_strAAMTEXP = v_dblEXPRICE & "*FLOOR(( " & v_strQTTY & " * " & v_strRIGHT_RIGHTOFFRATE & ")/" & v_strLEFT_RIGHTOFFRATE & ")"
                    'So chung khoan le
                    v_strREQTTYEXP = "(" & v_strQTTYEXP & " - TRUNC(" & v_strQTTYEXP & ", " & v_strROUNDTYPE & "))"
                    v_strREAQTTYEXP = "(" & v_strAQTTYEXP & " - TRUNC(" & v_strAQTTYEXP & ", " & v_strROUNDTYPE & "))"
                    'So chung khoan da lam tron
                    v_strQTTYEXP = "TRUNC(" & v_strQTTYEXP & "," & v_strROUNDTYPE & ")"
                    v_strAQTTYEXP = "TRUNC(" & v_strAQTTYEXP & "," & v_strROUNDTYPE & ")"
                    v_strAMTEXP = v_strAMTEXP & " + " & v_strREQTTYEXP & " * " & v_dblEXPRICE
                    v_strAAMTEXP = v_strAAMTEXP & " + " & v_strREAQTTYEXP & "*" & v_dblEXPRICE
                    v_strREQTTYEXP = 0
                    v_strREAQTTYEXP = 0
                End If

            End If


            If Not v_blnREVERSAL Then
                ' giam chung khoan phai sinh 

                v_strSQL = "Update semast set trade = trade - TRUNC(" & v_strQTTY * v_strLEFT_RIGHTOFFRATE / v_strRIGHT_RIGHTOFFRATE & ") where acctno = '" & v_strAFACCTNO & v_strOPTCODEID & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)


                v_strSQL = "INSERT INTO SETRAN (ACCTNO, TXNUM, TXDATE, TXCD, NAMT, CAMT, REF, DELTD,AUTOID) VALUES ('" _
                                   & v_strAFACCTNO & v_strOPTCODEID & "','" & v_strTXNUM & "',TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'0012', TRUNC(" & v_strQTTY * v_strLEFT_RIGHTOFFRATE / v_strRIGHT_RIGHTOFFRATE & "),'','','N',SEQ_SETRAN.NEXTVAL)"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)


                v_strSQL = "UPDATE CASCHD SET STATUS='" & v_strSTS & "' WHERE AFACCTNO='" & v_strAFACCTNO & "' AND CAMASTID='" & v_strCAMASTID & "' AND DELTD = 'N'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                v_strSQL = "UPDATE CAMAST SET STATUS='" & v_strSTS & "' WHERE  CAMASTID='" & v_strCAMASTID & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                'Cap nhat giam so tien nop cho quyen mua

                ' neu la jao dich 3391: ghi nhan them vao truong NMBALANCE de phan biet

                If (v_strTLTXCD = gc_CA_STOCK_RIGHTOFF_NOT_BLOCK_MONEy) Then
                    v_strSQL = "UPDATE CASCHD SET TQTTY=TQTTY+" & v_strQTTY & " ,  NMQTTY = NMQTTY +  " & v_strQTTY _
                    & " , BALANCE = BALANCE + " & " TRUNC(" & v_strQTTY * v_strLEFT_RIGHTOFFRATE / v_strRIGHT_RIGHTOFFRATE & ") ,QTTY= QTTY + " & v_strQTTY & ControlChars.CrLf _
               & " ,PAAMT= PAAMT - " & v_dblEXPRICE * v_strQTTY & " ,PQTTY= PQTTY - " & v_strQTTY & ",PBALANCE = PBALANCE - " & " TRUNC(" & v_strQTTY * v_strLEFT_RIGHTOFFRATE / v_strRIGHT_RIGHTOFFRATE & "),RETAILBAL= RETAILBAL - " & " TRUNC(" & v_strQTTY * v_strLEFT_RIGHTOFFRATE / v_strRIGHT_RIGHTOFFRATE _
               & ")  WHERE AFACCTNO='" & v_strAFACCTNO & "' AND CAMASTID='" & v_strCAMASTID & "' AND DELTD = 'N'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                Else

                    v_strSQL = "UPDATE CASCHD SET BALANCE = BALANCE + " & " TRUNC(" & v_strQTTY * v_strLEFT_RIGHTOFFRATE / v_strRIGHT_RIGHTOFFRATE & ") ,AAMT= AAMT + " & v_dblEXPRICE * v_strQTTY & " ,QTTY= QTTY + " & v_strQTTY & ControlChars.CrLf _
                & " ,PAAMT= PAAMT - " & v_dblEXPRICE * v_strQTTY & " ,PQTTY= PQTTY - " & v_strQTTY & ",PBALANCE = PBALANCE - " & " TRUNC(" & v_strQTTY * v_strLEFT_RIGHTOFFRATE / v_strRIGHT_RIGHTOFFRATE & "),RETAILBAL= RETAILBAL - " & " TRUNC(" & v_strQTTY * v_strLEFT_RIGHTOFFRATE / v_strRIGHT_RIGHTOFFRATE _
                & ")  WHERE AFACCTNO='" & v_strAFACCTNO & "' AND CAMASTID='" & v_strCAMASTID & "' AND DELTD = 'N'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                End If

            Else
                'XOA GIAO DICH
                v_strSQL = "UPDATE CASCHD SET STATUS='A' WHERE AFACCTNO='" & v_strAFACCTNO & "' AND CAMASTID='" & v_strCAMASTID & "' AND DELTD = 'N'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                v_strSQL = "UPDATE CAMAST SET STATUS='A' WHERE  CAMASTID='" & v_strCAMASTID & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                'Cap nhat giam so tien nop cho quyen mua
                If (v_strTLTXCD = gc_CA_STOCK_RIGHTOFF_NOT_BLOCK_MONEy) Then
                    v_strSQL = "UPDATE CASCHD SET TQTTY=TQTTY-" & v_strQTTY & " ,  NMQTTY = NMQTTY -  " & v_strQTTY _
                    & " , BALANCE = BALANCE - " & " TRUNC(" & v_strQTTY * v_strLEFT_RIGHTOFFRATE / v_strRIGHT_RIGHTOFFRATE & ") ,QTTY= QTTY - " & v_strQTTY & ControlChars.CrLf _
               & " ,PAAMT= PAAMT + " & v_dblEXPRICE * v_strQTTY & " ,PQTTY= PQTTY + " & v_strQTTY & ",PBALANCE = PBALANCE + " & " TRUNC(" & v_strQTTY * v_strLEFT_RIGHTOFFRATE / v_strRIGHT_RIGHTOFFRATE & "),RETAILBAL= RETAILBAL + " & " TRUNC(" & v_strQTTY * v_strLEFT_RIGHTOFFRATE / v_strRIGHT_RIGHTOFFRATE _
               & ")  WHERE AFACCTNO='" & v_strAFACCTNO & "' AND CAMASTID='" & v_strCAMASTID & "' AND DELTD = 'N'"

                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                Else

                    v_strSQL = "UPDATE CASCHD SET BALANCE = BALANCE - " & " TRUNC(" & v_strQTTY * v_strLEFT_RIGHTOFFRATE / v_strRIGHT_RIGHTOFFRATE & ") ,AAMT= AAMT - " & v_dblEXPRICE * v_strQTTY & " ,QTTY= QTTY - " & v_strQTTY & ControlChars.CrLf _
                & " ,PAAMT= PAAMT + " & v_dblEXPRICE * v_strQTTY & " ,PQTTY= PQTTY + " & v_strQTTY & ",PBALANCE = PBALANCE + " & " TRUNC(" & v_strQTTY * v_strLEFT_RIGHTOFFRATE / v_strRIGHT_RIGHTOFFRATE & "),RETAILBAL= RETAILBAL + " & " TRUNC(" & v_strQTTY * v_strLEFT_RIGHTOFFRATE / v_strRIGHT_RIGHTOFFRATE _
                & ")  WHERE AFACCTNO='" & v_strAFACCTNO & "' AND CAMASTID='" & v_strCAMASTID & "' AND DELTD = 'N'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

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
    Private Function Transfer_3382(ByRef pv_xmlDocument As Xml.XmlDocument) As Long


        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CA.Trans.ApproveCAEvent", v_strErrorMessage As String
        Dim v_strSQLTmp As String = String.Empty, v_strSQL As String = String.Empty, i As Integer
        Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE, v_lngCLEARDAY As Double
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strCAMASTID, v_strAFACCTNO, v_strAFACCTNO_CR, v_strEXCODEID, v_strRETAILBAL, v_strQTTY, v_strCODEID, v_strREPORTDATE, v_strACTIONDATE, v_strDUEDATE, v_strSTATUS, v_strOPTCODEID, v_strOPTSYMBOl, v_strTRANSFERTIMES, v_strFRTRADEPLACE, v_strTOTRADEPLACE As String
            Dim v_dblEXPRICE, v_dblINTERESTPERIOD, v_dblPARVALUE As Double
            Dim v_strEXRATE, v_strRIGHTOFFRATE, v_strDEVIDENTRATE, v_strDEVIDENTSHARES, v_strSPLITRATE, v_strINTERESTRATE As String
            Dim v_strLEFT_EXRATE, v_strLEFT_RIGHTOFFRATE, v_strLEFT_DEVIDENTRATE, v_strLEFT_DEVIDENTSHARES, v_strLEFT_SPLITRATE, v_strLEFT_INTERESTRATE As String
            Dim v_strRIGHT_EXRATE, v_strRIGHT_RIGHTOFFRATE, v_strRIGHT_DEVIDENTRATE, v_strRIGHT_DEVIDENTSHARES, v_strRIGHT_SPLITRATE, v_strRIGHT_INTERESTRATE As String
            Dim v_strQTTYEXP, v_strAMTEXP, v_strAQTTYEXP, v_strAAMTEXP, v_strROUNDTYPE, v_strROUNDVALUE, v_strREQTTYEXP, v_strREAQTTYEXP As String
            Dim v_dtREPORTDATE, v_dtTXDATE, v_dtACTIONDATE As DateTime
            Dim v_ds As DataSet
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_strBRID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXTIME As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTIME).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_blnREVERSAL As Boolean = IIf(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value = "Y", True, False)
            v_dtTXDATE = DDMMYYYY_SystemDate(v_strTXDATE)
            'LAY NOI DUNG GIAO DICH
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(gf_Numberic(.InnerText), gf_Cdbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If
                    Select Case v_strFLDCD
                        Case "06" 'CAMASTID
                            v_strCAMASTID = v_strVALUE
                        Case "02"
                            v_strAFACCTNO = v_strVALUE
                        Case "04"
                            v_strAFACCTNO_CR = v_strVALUE
                        Case "21"
                            v_strQTTY = v_dblVALUE
                    End Select
                End With
            Next


            'TAO DU LIEU MOI
            If Len(v_strCAMASTID) > 0 Then
                'LAY THONG TIN DOT THUC HIEN QUYEN
                v_strSQL = "SELECT * FROM CAMAST WHERE CAMASTID='" & v_strCAMASTID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_strCODEID = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("CODEID")))
                    v_strEXCODEID = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("EXCODEID")))
                    v_strREPORTDATE = gf_CorrectStringField(Format(v_ds.Tables(0).Rows(0)("REPORTDATE"), gc_FORMAT_DATE))
                    v_strACTIONDATE = gf_CorrectStringField(Format(v_ds.Tables(0).Rows(0)("ACTIONDATE"), gc_FORMAT_DATE))
                    v_strDUEDATE = gf_CorrectStringField(Format(v_ds.Tables(0).Rows(0)("DUEDATE"), gc_FORMAT_DATE))
                    v_dblEXPRICE = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("EXPRICE"))
                    v_dblPARVALUE = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("PARVALUE"))
                    v_strEXRATE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("EXRATE")))
                    v_strLEFT_EXRATE = gf_FormatNumberToSring(v_strEXRATE, 0)
                    v_strRIGHT_EXRATE = gf_FormatNumberToSring(v_strEXRATE, 1)
                    v_strRIGHTOFFRATE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("RIGHTOFFRATE")))
                    v_strLEFT_RIGHTOFFRATE = gf_FormatNumberToSring(v_strRIGHTOFFRATE, 0)
                    v_strRIGHT_RIGHTOFFRATE = gf_FormatNumberToSring(v_strRIGHTOFFRATE, 1)
                    v_strDEVIDENTRATE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("DEVIDENTRATE")))
                    v_strLEFT_DEVIDENTRATE = gf_FormatNumberToSring(v_strDEVIDENTRATE, 0)
                    v_strRIGHT_DEVIDENTRATE = gf_FormatNumberToSring(v_strDEVIDENTRATE, 1)
                    v_strDEVIDENTSHARES = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("DEVIDENTSHARES")))
                    v_strLEFT_DEVIDENTSHARES = gf_FormatNumberToSring(v_strDEVIDENTSHARES, 0)
                    v_strRIGHT_DEVIDENTSHARES = gf_FormatNumberToSring(v_strDEVIDENTSHARES, 1)
                    v_strSPLITRATE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("SPLITRATE")))
                    v_strLEFT_SPLITRATE = gf_FormatNumberToSring(v_strSPLITRATE, 0)
                    v_strRIGHT_SPLITRATE = gf_FormatNumberToSring(v_strSPLITRATE, 1)
                    v_strINTERESTRATE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("INTERESTRATE")))
                    v_strLEFT_INTERESTRATE = gf_FormatNumberToSring(v_strINTERESTRATE, 0)
                    v_strRIGHT_INTERESTRATE = gf_FormatNumberToSring(v_strINTERESTRATE, 1)
                    v_dblINTERESTPERIOD = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("INTERESTPERIOD"))
                    v_strSTATUS = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("STATUS")))
                    v_strROUNDTYPE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("ROUNDTYPE")))
                    v_strOPTCODEID = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("OPTCODEID")))
                    v_strOPTSYMBOl = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("OPTSYMBOl")))
                    v_strTRANSFERTIMES = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("TRANSFERTIMES")))

                    v_strQTTYEXP = "0"
                    v_strAMTEXP = "0"
                    v_strAQTTYEXP = "0"
                    v_strAAMTEXP = "0"
                    v_strREQTTYEXP = "0"
                    v_strREAQTTYEXP = "0"
                    ' Tinh gia tri cho CK, tien cho ve.
                    v_strQTTYEXP = "FLOOR(( " & v_strQTTY & " * " & v_strRIGHT_RIGHTOFFRATE & ")/" & v_strLEFT_RIGHTOFFRATE & ")"
                    v_strAAMTEXP = v_dblEXPRICE & "*FLOOR(( " & v_strQTTY & " * " & v_strRIGHT_RIGHTOFFRATE & ")/" & v_strLEFT_RIGHTOFFRATE & ")"
                    'So chung khoan le
                    v_strREQTTYEXP = "(" & v_strQTTYEXP & " - TRUNC(" & v_strQTTYEXP & ", " & v_strROUNDTYPE & "))"
                    v_strREAQTTYEXP = "(" & v_strAQTTYEXP & " - TRUNC(" & v_strAQTTYEXP & ", " & v_strROUNDTYPE & "))"
                    'So chung khoan da lam tron
                    v_strQTTYEXP = "TRUNC(" & v_strQTTYEXP & "," & v_strROUNDTYPE & ")"
                    v_strAQTTYEXP = "TRUNC(" & v_strAQTTYEXP & "," & v_strROUNDTYPE & ")"
                    v_strAMTEXP = v_strAMTEXP & " + " & v_strREQTTYEXP & " * " & v_dblEXPRICE
                    v_strAAMTEXP = v_strAAMTEXP & " + " & v_strREAQTTYEXP & "*" & v_dblEXPRICE
                    v_strREQTTYEXP = 0
                    v_strREAQTTYEXP = 0
                End If

            End If

            If Not v_blnREVERSAL Then   'Nếu là duyệt: Tạo CASCHD tương ứng
                'INSERT DU LIEU CU TK PS CO

                v_strSQL = "select * from caschd where camastid = '" & v_strCAMASTID & "' and afacctno = '" & v_strAFACCTNO_CR & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

                'Neu quyen thuc hien cho phep thuc hien nhieu lan. set lai 
                If v_strTRANSFERTIMES = 1 Then
                    v_strRETAILBAL = 0
                ElseIf v_strTRANSFERTIMES = 2 Then
                    v_strRETAILBAL = v_strQTTY
                End If

                If v_ds.Tables(0).Rows.Count > 0 Then
                    'UPDATE DU LIEU CU TK PS CO
                    v_strSQL = " UPDATE CASCHD  SET PBALANCE = PBALANCE +" & v_strQTTY & " ,INBALANCE = INBALANCE +" & v_strQTTY & " , PQTTY = TRUNC( FLOOR(( (PBALANCE + " & v_strQTTY & ") * " & v_strRIGHT_RIGHTOFFRATE & ") / " & v_strLEFT_RIGHTOFFRATE & ")  ," & v_strROUNDTYPE & ") ,  PAAMT= " & v_dblEXPRICE & "* TRUNC(  FLOOR(( ( PBALANCE + " & v_strQTTY & ") * " & v_strRIGHT_RIGHTOFFRATE & ") / " & v_strLEFT_RIGHTOFFRATE & ")  ," & v_strROUNDTYPE & ") , RETAILBAL = RETAILBAL + " & v_strRETAILBAL & " " & ControlChars.CrLf _
                    & " WHERE AFACCTNO ='" & v_strAFACCTNO_CR & "' AND camastid = '" & v_strCAMASTID & "' and  deltd <> 'Y'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                Else

                    v_strSQL = "INSERT INTO CASCHD (AUTOID, CAMASTID, AFACCTNO, CODEID, EXCODEID, BALANCE, QTTY, AMT, AQTTY, AAMT, STATUS,REQTTY,REAQTTY ,DELTD, RETAILBAL ,PBALANCE,PQTTY,PAAMT,INBALANCE)  " & ControlChars.CrLf _
                    & "VALUES( SEQ_CASCHD.NEXTVAL, '" & v_strCAMASTID & "' ,'" & v_strAFACCTNO_CR & "' ,'" & v_strCODEID & "' ," & ControlChars.CrLf _
                    & " '" & v_strOPTCODEID & "' , 0 , 0 , 0 , 0  , " & ControlChars.CrLf _
                    & " 0 , 'A'  ,0 , 0 , 'N' , " & v_strRETAILBAL & " ," & v_strQTTY & " , TRUNC( FLOOR(( " & v_strQTTY & " * " & v_strRIGHT_RIGHTOFFRATE & ") / " & v_strLEFT_RIGHTOFFRATE & ")  ," & v_strROUNDTYPE & ")  ," & ControlChars.CrLf _
                    & v_dblEXPRICE & "* TRUNC(  FLOOR(( " & v_strQTTY & "  * " & v_strRIGHT_RIGHTOFFRATE & ") / " & v_strLEFT_RIGHTOFFRATE & ")  ," & v_strROUNDTYPE & ")," & v_strQTTY & " )"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                End If

                'UPDATE DU LIEU CU TK PS NO
                v_strSQL = " UPDATE CASCHD  SET PBALANCE = PBALANCE -" & v_strQTTY & " ,OUTBALANCE = OUTBALANCE +" & v_strQTTY & " , PQTTY = TRUNC( FLOOR(( (PBALANCE - " & v_strQTTY & ") * " & v_strRIGHT_RIGHTOFFRATE & ") / " & v_strLEFT_RIGHTOFFRATE & ")  ," & v_strROUNDTYPE & ") ,  PAAMT=  " & v_dblEXPRICE & " * TRUNC(  FLOOR(( ( PBALANCE - " & v_strQTTY & ") * " & v_strRIGHT_RIGHTOFFRATE & ") / " & v_strLEFT_RIGHTOFFRATE & ")  ," & v_strROUNDTYPE & ")  " & ControlChars.CrLf _
                & ", RETAILBAL =  RETAILBAL - " & v_strQTTY & ControlChars.CrLf _
                & " WHERE AFACCTNO ='" & v_strAFACCTNO & "' AND camastid = '" & v_strCAMASTID & "' and  deltd <> 'Y' "
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                v_strSQL = "INSERT INTO catransfer (AUTOID,TXDATE,TXNUM,CAMASTID,OPTSEACCTNOCR,OPTSEACCTNODR,CODEID,OPTCODEID,AMT,STATUS) " & ControlChars.CrLf _
                & "VALUES(seq_catransfer.nextval, TO_DATE('" & v_strTXDATE & "', 'DD/MM/RRRR'),'" & v_strTXNUM & "','" & v_strCAMASTID & "','" & v_strAFACCTNO_CR & v_strOPTCODEID & "','" & v_strAFACCTNO & v_strOPTCODEID & "','" & v_strCODEID & "','" & v_strOPTCODEID & "'," & v_strQTTY & ",'N')"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)


            Else    'NEU XOA GIAO DICH

                v_strSQL = " UPDATE CASCHD  SET PBALANCE = PBALANCE -" & v_strQTTY & " ,INBALANCE = INBALANCE -" & v_strQTTY & " , PQTTY = TRUNC( FLOOR(( (PBALANCE - " & v_strQTTY & ") * " & v_strRIGHT_RIGHTOFFRATE & ") / " & v_strLEFT_RIGHTOFFRATE & ")  ," & v_strROUNDTYPE & ") ,  PAAMT= " & v_dblEXPRICE & " * TRUNC(  FLOOR(( ( PBALANCE - " & v_strQTTY & ") * " & v_strRIGHT_RIGHTOFFRATE & ") / " & v_strLEFT_RIGHTOFFRATE & ")  ," & v_strROUNDTYPE & ")  " & ControlChars.CrLf _
                           & " WHERE AFACCTNO ='" & v_strAFACCTNO_CR & "' AND camastid = '" & v_strCAMASTID & "' and  deltd <> 'Y'"

                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)


                v_strSQL = " UPDATE CASCHD  SET PBALANCE = PBALANCE +" & v_strQTTY & " ,OUTBALANCE = OUTBALANCE -" & v_strQTTY & " , PQTTY = TRUNC( FLOOR(( (PBALANCE + " & v_strQTTY & ") * " & v_strRIGHT_RIGHTOFFRATE & ") / " & v_strLEFT_RIGHTOFFRATE & ")  ," & v_strROUNDTYPE & ") ,  PAAMT= " & v_dblEXPRICE & "* TRUNC(  FLOOR(( ( PBALANCE + " & v_strQTTY & ") * " & v_strRIGHT_RIGHTOFFRATE & ") / " & v_strLEFT_RIGHTOFFRATE & ")  ," & v_strROUNDTYPE & ")  " & ControlChars.CrLf _
                          & ", RETAILBAL =  RETAILBAL + " & v_strQTTY & ControlChars.CrLf _
                          & " WHERE AFACCTNO ='" & v_strAFACCTNO & "' AND camastid = '" & v_strCAMASTID & "' and  deltd <> 'Y' "
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                v_strSQL = " delete catransfer where txnum = '" & v_strTXNUM & "' and TO_DATE('" & v_strTXDATE & "', 'DD/MM/RRRR')"
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

    Private Function Transfer_3383(ByRef pv_xmlDocument As Xml.XmlDocument) As Long

        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CA.Trans.ApproveCAEvent", v_strErrorMessage As String
        Dim v_strSQLTmp As String = String.Empty, v_strSQL As String = String.Empty, i As Integer
        Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE, v_lngCLEARDAY As Double
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strCAMASTID, v_strAFACCTNO, v_strAFACCTNO_CR, v_strEXCODEID, v_strQTTY, v_strCODEID, v_strREPORTDATE, v_strACTIONDATE, v_strDUEDATE, v_strSTATUS, v_strOPTCODEID, v_strOPTSYMBOl, v_strFRTRADEPLACE, v_strTOTRADEPLACE As String
            Dim v_dblEXPRICE, v_dblINTERESTPERIOD, v_dblPARVALUE As Double
            Dim v_strEXRATE, v_strRIGHTOFFRATE, v_strDEVIDENTRATE, v_strDEVIDENTSHARES, v_strSPLITRATE, v_strINTERESTRATE As String
            Dim v_strLEFT_EXRATE, v_strLEFT_RIGHTOFFRATE, v_strLEFT_DEVIDENTRATE, v_strLEFT_DEVIDENTSHARES, v_strLEFT_SPLITRATE, v_strLEFT_INTERESTRATE As String
            Dim v_strRIGHT_EXRATE, v_strRIGHT_RIGHTOFFRATE, v_strRIGHT_DEVIDENTRATE, v_strRIGHT_DEVIDENTSHARES, v_strRIGHT_SPLITRATE, v_strRIGHT_INTERESTRATE As String
            Dim v_strQTTYEXP, v_strAMTEXP, v_strAQTTYEXP, v_strAAMTEXP, v_strROUNDTYPE, v_strROUNDVALUE, v_strREQTTYEXP, v_strREAQTTYEXP As String
            Dim v_dtREPORTDATE, v_dtTXDATE, v_dtACTIONDATE As DateTime
            Dim v_ds As DataSet
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_strBRID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXTIME As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTIME).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_blnREVERSAL As Boolean = IIf(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value = "Y", True, False)
            v_dtTXDATE = DDMMYYYY_SystemDate(v_strTXDATE)
            'LAY NOI DUNG GIAO DICH
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(gf_Numberic(.InnerText), gf_Cdbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If
                    Select Case v_strFLDCD
                        Case "06" 'CAMASTID
                            v_strCAMASTID = v_strVALUE
                        Case "02"
                            v_strAFACCTNO = v_strVALUE
                        Case "21"
                            v_strQTTY = v_dblVALUE
                    End Select
                End With
            Next


            'TAO DU LIEU MOI
            If Len(v_strCAMASTID) > 0 Then
                'LAY THONG TIN DOT THUC HIEN QUYEN
                v_strSQL = "SELECT * FROM CAMAST WHERE CAMASTID='" & v_strCAMASTID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_strCODEID = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("CODEID")))
                    v_strEXCODEID = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("EXCODEID")))
                    v_strREPORTDATE = gf_CorrectStringField(Format(v_ds.Tables(0).Rows(0)("REPORTDATE"), gc_FORMAT_DATE))
                    v_strACTIONDATE = gf_CorrectStringField(Format(v_ds.Tables(0).Rows(0)("ACTIONDATE"), gc_FORMAT_DATE))
                    v_strDUEDATE = gf_CorrectStringField(Format(v_ds.Tables(0).Rows(0)("DUEDATE"), gc_FORMAT_DATE))
                    v_dblEXPRICE = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("EXPRICE"))
                    v_dblPARVALUE = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("PARVALUE"))
                    v_strEXRATE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("EXRATE")))
                    v_strLEFT_EXRATE = gf_FormatNumberToSring(v_strEXRATE, 0)
                    v_strRIGHT_EXRATE = gf_FormatNumberToSring(v_strEXRATE, 1)
                    v_strRIGHTOFFRATE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("RIGHTOFFRATE")))
                    v_strLEFT_RIGHTOFFRATE = gf_FormatNumberToSring(v_strRIGHTOFFRATE, 0)
                    v_strRIGHT_RIGHTOFFRATE = gf_FormatNumberToSring(v_strRIGHTOFFRATE, 1)
                    v_strDEVIDENTRATE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("DEVIDENTRATE")))
                    v_strLEFT_DEVIDENTRATE = gf_FormatNumberToSring(v_strDEVIDENTRATE, 0)
                    v_strRIGHT_DEVIDENTRATE = gf_FormatNumberToSring(v_strDEVIDENTRATE, 1)
                    v_strDEVIDENTSHARES = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("DEVIDENTSHARES")))
                    v_strLEFT_DEVIDENTSHARES = gf_FormatNumberToSring(v_strDEVIDENTSHARES, 0)
                    v_strRIGHT_DEVIDENTSHARES = gf_FormatNumberToSring(v_strDEVIDENTSHARES, 1)
                    v_strSPLITRATE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("SPLITRATE")))
                    v_strLEFT_SPLITRATE = gf_FormatNumberToSring(v_strSPLITRATE, 0)
                    v_strRIGHT_SPLITRATE = gf_FormatNumberToSring(v_strSPLITRATE, 1)
                    v_strINTERESTRATE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("INTERESTRATE")))
                    v_strLEFT_INTERESTRATE = gf_FormatNumberToSring(v_strINTERESTRATE, 0)
                    v_strRIGHT_INTERESTRATE = gf_FormatNumberToSring(v_strINTERESTRATE, 1)
                    v_dblINTERESTPERIOD = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("INTERESTPERIOD"))
                    v_strSTATUS = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("STATUS")))
                    v_strROUNDTYPE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("ROUNDTYPE")))
                    v_strOPTCODEID = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("OPTCODEID")))
                    v_strOPTSYMBOl = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("OPTSYMBOl")))

                    v_strQTTYEXP = "0"
                    v_strAMTEXP = "0"
                    v_strAQTTYEXP = "0"
                    v_strAAMTEXP = "0"
                    v_strREQTTYEXP = "0"
                    v_strREAQTTYEXP = "0"
                    ' Tinh gia tri cho CK, tien cho ve.
                    v_strQTTYEXP = "FLOOR(( " & v_strQTTY & " * " & v_strRIGHT_RIGHTOFFRATE & ")/" & v_strLEFT_RIGHTOFFRATE & ")"
                    v_strAAMTEXP = v_dblEXPRICE & "*FLOOR(( " & v_strQTTY & " * " & v_strRIGHT_RIGHTOFFRATE & ")/" & v_strLEFT_RIGHTOFFRATE & ")"
                    'So chung khoan le
                    v_strREQTTYEXP = "(" & v_strQTTYEXP & " - TRUNC(" & v_strQTTYEXP & ", " & v_strROUNDTYPE & "))"
                    v_strREAQTTYEXP = "(" & v_strAQTTYEXP & " - TRUNC(" & v_strAQTTYEXP & ", " & v_strROUNDTYPE & "))"
                    'So chung khoan da lam tron
                    v_strQTTYEXP = "TRUNC(" & v_strQTTYEXP & "," & v_strROUNDTYPE & ")"
                    v_strAQTTYEXP = "TRUNC(" & v_strAQTTYEXP & "," & v_strROUNDTYPE & ")"
                    v_strAMTEXP = v_strAMTEXP & " + " & v_strREQTTYEXP & " * " & v_dblEXPRICE
                    v_strAAMTEXP = v_strAAMTEXP & " + " & v_strREAQTTYEXP & "*" & v_dblEXPRICE
                    v_strREQTTYEXP = 0
                    v_strREAQTTYEXP = 0
                End If

            End If

            If Not v_blnREVERSAL Then   'Nếu là duyệt: Tạo CASCHD tương ứng
                'UPDATE DU LIEU CU TK PS NO

                v_strSQL = " UPDATE CASCHD  SET PBALANCE = PBALANCE -" & v_strQTTY & " , OUTBALANCE = OUTBALANCE +" & v_strQTTY & " , PQTTY = TRUNC( FLOOR(( (PBALANCE - " & v_strQTTY & ") * " & v_strRIGHT_RIGHTOFFRATE & ") / " & v_strLEFT_RIGHTOFFRATE & ")  ," & v_strROUNDTYPE & ") ,  PAAMT= " & v_dblEXPRICE & "*  TRUNC( FLOOR(( ( PBALANCE - " & v_strQTTY & ") * " & v_strRIGHT_RIGHTOFFRATE & ") / " & v_strLEFT_RIGHTOFFRATE & ")  ," & v_strROUNDTYPE & ")  " & ControlChars.CrLf _
                & ", RETAILBAL =  RETAILBAL - " & v_strQTTY & ControlChars.CrLf _
                & " WHERE AFACCTNO ='" & v_strAFACCTNO & "' AND camastid = '" & v_strCAMASTID & "' and  deltd <> 'Y' "

                'TAO DU LIEU CHO CASCHD
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)



            Else    'NEU XOA GIAO DICH

                v_strSQL = " UPDATE CASCHD  SET PBALANCE = PBALANCE +" & v_strQTTY & " ,OUTBALANCE = OUTBALANCE -" & v_strQTTY & " , PQTTY = TRUNC( FLOOR(( (PBALANCE + " & v_strQTTY & ") * " & v_strRIGHT_RIGHTOFFRATE & ") / " & v_strLEFT_RIGHTOFFRATE & ")  ," & v_strROUNDTYPE & ") ,  PAAMT=  " & v_dblEXPRICE & " * TRUNC(  FLOOR(( ( PBALANCE + " & v_strQTTY & ") * " & v_strRIGHT_RIGHTOFFRATE & ") / " & v_strLEFT_RIGHTOFFRATE & ")  ," & v_strROUNDTYPE & ")  " & ControlChars.CrLf _
                & ", RETAILBAL =  RETAILBAL + " & v_strQTTY & ControlChars.CrLf _
                & " WHERE AFACCTNO ='" & v_strAFACCTNO & "' AND camastid = '" & v_strCAMASTID & "' and  deltd <> 'Y' "

                'TAO DU LIEU CHO CASCHD
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

    Private Function Transfer_3385(ByRef pv_xmlDocument As Xml.XmlDocument) As Long

        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CA.Trans.ApproveCAEvent", v_strErrorMessage As String
        Dim v_strSQLTmp As String = String.Empty, v_strSQL As String = String.Empty, i As Integer
        Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE, v_lngCLEARDAY As Double
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strCAMASTID, v_strAFACCTNO, v_strEXCODEID, v_strQTTY, v_strCODEID, v_strREPORTDATE, v_strACTIONDATE, v_strDUEDATE, v_strSTATUS, v_strOPTCODEID, v_strOPTSYMBOl, v_strFRTRADEPLACE, v_strTOTRADEPLACE As String
            Dim v_dblEXPRICE, v_dblINTERESTPERIOD, v_dblPARVALUE As Double
            Dim v_strEXRATE, v_strRIGHTOFFRATE, v_strDEVIDENTRATE, v_strDEVIDENTSHARES, v_strSPLITRATE, v_strINTERESTRATE As String
            Dim v_strLEFT_EXRATE, v_strLEFT_RIGHTOFFRATE, v_strLEFT_DEVIDENTRATE, v_strLEFT_DEVIDENTSHARES, v_strLEFT_SPLITRATE, v_strLEFT_INTERESTRATE As String
            Dim v_strRIGHT_EXRATE, v_strRIGHT_RIGHTOFFRATE, v_strRIGHT_DEVIDENTRATE, v_strRIGHT_DEVIDENTSHARES, v_strRIGHT_SPLITRATE, v_strRIGHT_INTERESTRATE As String
            Dim v_strQTTYEXP, v_strAMTEXP, v_strAQTTYEXP, v_strAAMTEXP, v_strROUNDTYPE, v_strROUNDVALUE, v_strREQTTYEXP, v_strREAQTTYEXP As String
            Dim v_dtREPORTDATE, v_dtTXDATE, v_dtACTIONDATE As DateTime
            Dim v_ds As DataSet
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_strBRID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXTIME As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTIME).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_blnREVERSAL As Boolean = IIf(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value = "Y", True, False)
            v_dtTXDATE = DDMMYYYY_SystemDate(v_strTXDATE)
            'LAY NOI DUNG GIAO DICH
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(gf_Numberic(.InnerText), gf_Cdbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If
                    Select Case v_strFLDCD
                        Case "06" 'CAMASTID
                            v_strCAMASTID = v_strVALUE
                        Case "04"
                            v_strAFACCTNO = v_strVALUE
                        Case "21"
                            v_strQTTY = v_dblVALUE
                    End Select
                End With
            Next


            'TAO DU LIEU MOI
            If Len(v_strCAMASTID) > 0 Then
                'LAY THONG TIN DOT THUC HIEN QUYEN
                v_strSQL = "SELECT * FROM CAMAST WHERE CAMASTID='" & v_strCAMASTID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_strCODEID = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("CODEID")))
                    v_strEXCODEID = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("EXCODEID")))
                    v_strREPORTDATE = gf_CorrectStringField(Format(v_ds.Tables(0).Rows(0)("REPORTDATE"), gc_FORMAT_DATE))
                    v_strACTIONDATE = gf_CorrectStringField(Format(v_ds.Tables(0).Rows(0)("ACTIONDATE"), gc_FORMAT_DATE))
                    v_strDUEDATE = gf_CorrectStringField(Format(v_ds.Tables(0).Rows(0)("DUEDATE"), gc_FORMAT_DATE))
                    v_dblEXPRICE = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("EXPRICE"))
                    v_dblPARVALUE = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("PARVALUE"))
                    v_strEXRATE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("EXRATE")))
                    v_strLEFT_EXRATE = gf_FormatNumberToSring(v_strEXRATE, 0)
                    v_strRIGHT_EXRATE = gf_FormatNumberToSring(v_strEXRATE, 1)
                    v_strRIGHTOFFRATE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("RIGHTOFFRATE")))
                    v_strLEFT_RIGHTOFFRATE = gf_FormatNumberToSring(v_strRIGHTOFFRATE, 0)
                    v_strRIGHT_RIGHTOFFRATE = gf_FormatNumberToSring(v_strRIGHTOFFRATE, 1)
                    v_strDEVIDENTRATE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("DEVIDENTRATE")))
                    v_strLEFT_DEVIDENTRATE = gf_FormatNumberToSring(v_strDEVIDENTRATE, 0)
                    v_strRIGHT_DEVIDENTRATE = gf_FormatNumberToSring(v_strDEVIDENTRATE, 1)
                    v_strDEVIDENTSHARES = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("DEVIDENTSHARES")))
                    v_strLEFT_DEVIDENTSHARES = gf_FormatNumberToSring(v_strDEVIDENTSHARES, 0)
                    v_strRIGHT_DEVIDENTSHARES = gf_FormatNumberToSring(v_strDEVIDENTSHARES, 1)
                    v_strSPLITRATE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("SPLITRATE")))
                    v_strLEFT_SPLITRATE = gf_FormatNumberToSring(v_strSPLITRATE, 0)
                    v_strRIGHT_SPLITRATE = gf_FormatNumberToSring(v_strSPLITRATE, 1)
                    v_strINTERESTRATE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("INTERESTRATE")))
                    v_strLEFT_INTERESTRATE = gf_FormatNumberToSring(v_strINTERESTRATE, 0)
                    v_strRIGHT_INTERESTRATE = gf_FormatNumberToSring(v_strINTERESTRATE, 1)
                    v_dblINTERESTPERIOD = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("INTERESTPERIOD"))
                    v_strSTATUS = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("STATUS")))
                    v_strROUNDTYPE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("ROUNDTYPE")))
                    v_strOPTCODEID = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("OPTCODEID")))
                    v_strOPTSYMBOl = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("OPTSYMBOl")))

                    v_strQTTYEXP = "0"
                    v_strAMTEXP = "0"
                    v_strAQTTYEXP = "0"
                    v_strAAMTEXP = "0"
                    v_strREQTTYEXP = "0"
                    v_strREAQTTYEXP = "0"
                    ' Tinh gia tri cho CK, tien cho ve.
                    v_strQTTYEXP = "FLOOR(( " & v_strQTTY & " * " & v_strRIGHT_RIGHTOFFRATE & ")/" & v_strLEFT_RIGHTOFFRATE & ")"
                    v_strAAMTEXP = v_dblEXPRICE & "*FLOOR(( " & v_strQTTY & " * " & v_strRIGHT_RIGHTOFFRATE & ")/" & v_strLEFT_RIGHTOFFRATE & ")"
                    'So chung khoan le
                    v_strREQTTYEXP = "(" & v_strQTTYEXP & " - TRUNC(" & v_strQTTYEXP & ", " & v_strROUNDTYPE & "))"
                    v_strREAQTTYEXP = "(" & v_strAQTTYEXP & " - TRUNC(" & v_strAQTTYEXP & ", " & v_strROUNDTYPE & "))"
                    'So chung khoan da lam tron
                    v_strQTTYEXP = "TRUNC(" & v_strQTTYEXP & "," & v_strROUNDTYPE & ")"
                    v_strAQTTYEXP = "TRUNC(" & v_strAQTTYEXP & "," & v_strROUNDTYPE & ")"
                    v_strAMTEXP = v_strAMTEXP & " + " & v_strREQTTYEXP & " * " & v_dblEXPRICE
                    v_strAAMTEXP = v_strAAMTEXP & " + " & v_strREAQTTYEXP & "*" & v_dblEXPRICE
                    v_strREQTTYEXP = 0
                    v_strREAQTTYEXP = 0
                End If

            End If

            If Not v_blnREVERSAL Then   'Nếu là duyệt: Tạo CASCHD tương ứng
                v_strSQL = "select * from caschd where camastid = '" & v_strCAMASTID & "' and afacctno = '" & v_strAFACCTNO & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)


                If v_ds.Tables(0).Rows.Count > 0 Then
                    'UPDATE DU LIEU CU TK PS CO
                    v_strSQL = " UPDATE CASCHD  SET PBALANCE = PBALANCE +" & v_strQTTY & " ,INBALANCE = INBALANCE +" & v_strQTTY & " , PQTTY = TRUNC( FLOOR(( (PBALANCE + " & v_strQTTY & ") * " & v_strRIGHT_RIGHTOFFRATE & ") / " & v_strLEFT_RIGHTOFFRATE & ")  ," & v_strROUNDTYPE & ") ,  PAAMT=  " & v_dblEXPRICE & " * TRUNC(  FLOOR(( ( PBALANCE + " & v_strQTTY & ") * " & v_strRIGHT_RIGHTOFFRATE & ") / " & v_strLEFT_RIGHTOFFRATE & ")  ," & v_strROUNDTYPE & ")  " & ControlChars.CrLf _
                    & " WHERE AFACCTNO ='" & v_strAFACCTNO & "' AND camastid = '" & v_strCAMASTID & "' and  deltd <> 'Y'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                Else

                    v_strSQL = "INSERT INTO CASCHD (AUTOID, CAMASTID, AFACCTNO, CODEID, EXCODEID, BALANCE, QTTY, AMT, AQTTY, AAMT, STATUS,REQTTY,REAQTTY ,DELTD,PBALANCE,PQTTY,PAAMT,INBALANCE)  " & ControlChars.CrLf _
                    & "VALUES( SEQ_CASCHD.NEXTVAL, '" & v_strCAMASTID & "' ,'" & v_strAFACCTNO & "' ,'" & v_strCODEID & "' ," & ControlChars.CrLf _
                    & " ' ' , 0 , 0 , 0 , 0  , " & ControlChars.CrLf _
                    & " 0 , 'V'  ,0 , 0 , 'N' ," & v_strQTTY & " , TRUNC( FLOOR(( " & v_strQTTY & " * " & v_strRIGHT_RIGHTOFFRATE & ") / " & v_strLEFT_RIGHTOFFRATE & ")  ," & v_strROUNDTYPE & ")  ," & ControlChars.CrLf _
                    & v_dblEXPRICE & "* TRUNC(  FLOOR(( " & v_strQTTY & "  * " & v_strRIGHT_RIGHTOFFRATE & ") / " & v_strLEFT_RIGHTOFFRATE & ")  ," & v_strROUNDTYPE & ")," & v_strQTTY & ")"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                End If

            Else    'NEU XOA GIAO DICH

                'UPDATE DU LIEU CU TK PS  CO
                v_strSQL = " UPDATE CASCHD  SET PBALANCE = PBALANCE - " & v_strQTTY & " ,INBALANCE = INBALANCE - " & v_strQTTY & " , PQTTY = TRUNC( FLOOR(( (PBALANCE - " & v_strQTTY & ") * " & v_strRIGHT_RIGHTOFFRATE & ") / " & v_strLEFT_RIGHTOFFRATE & ")  ," & v_strROUNDTYPE & ") ,  PAAMT= " & v_dblEXPRICE & "* TRUNC(  FLOOR(( ( PBALANCE - " & v_strQTTY & ") * " & v_strRIGHT_RIGHTOFFRATE & ") / " & v_strLEFT_RIGHTOFFRATE & ")  ," & v_strROUNDTYPE & ")  " & ControlChars.CrLf _
                 & " WHERE AFACCTNO ='" & v_strAFACCTNO & "' AND camastid = '" & v_strCAMASTID & "' and  deltd <> 'Y'"
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


    Private Function SendCAEvent(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CA.Trans.SendCAEvent", v_strErrorMessage As String
        Dim v_strSQLTmp As String = String.Empty, v_strSQL As String = String.Empty, i As Integer
        Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE, v_lngCLEARDAY As Double
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strCAMASTID, v_strCODEID, v_strEXCODEID, v_strCATYPE, v_strREPORTDATE, v_strACTIONDATE, v_strINTERESTPERIOD, v_strSTATUS As String
            Dim v_dblEXPRICE, v_dblEXRATE, v_dblRIGHTOFFRATE, v_dblDEVIDENTRATE, v_dblDEVIDENTSHARES, v_dblSPLITRATE, v_dblINTERESTRATE As Double
            Dim v_strQTTYEXP, v_strAMTEXP As String
            Dim v_ds As DataSet
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_strBRID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXTIME As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTIME).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_blnREVERSAL As Boolean = IIf(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value = "Y", True, False)

            'LAY NOI DUNG GIAO DICH
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
                        Case "03" 'CAMASTID
                            v_strCAMASTID = v_strVALUE
                    End Select
                End With
            Next
            If Not v_blnREVERSAL Then   'NEU DUYET
                v_strSQL = "SELECT * FROM CASCHD WHERE CAMASTID='" & v_strCAMASTID & "' AND STATUS IN('S','C') AND DELTD ='N'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    'BAO LOI
                    v_lngErrCode = ERR_CA_CAMASTID_ALREADY_SEND_OR_COMPLETE
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: Reversal." & v_blnREVERSAL.ToString() & "." & v_strCAMASTID & "." & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If
                'Update trang thai cho CASCHD la Send
                v_strSQL = "UPDATE CASCHD SET STATUS ='S' WHERE CAMASTID='" & v_strCAMASTID & "' AND DELTD = 'N'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            Else
                v_strSQL = "SELECT CASCHD.*,CAMAST.CATYPE FROM CASCHD,CAMAST WHERE CASCHD.CAMASTID=CAMAST.CAMASTID AND  CASCHD.CAMASTID='" & v_strCAMASTID & "' AND CASCHD.STATUS ='S' AND CASCHD.DELTD ='N'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If Not v_ds.Tables(0).Rows.Count > 0 Then
                    'BAO LOI
                    v_lngErrCode = ERR_CAMAST_STATUS_INVALID
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: Reversal." & v_blnREVERSAL.ToString() & "." & v_strCAMASTID & "." & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If
                'UPDATE INF trong CASCHD
                v_strSQL = "UPDATE CASCHD SET STATUS ='A' WHERE CAMASTID='" & v_strCAMASTID & "' AND DELTD = 'N'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            End If



            'AP DUNG CHO TRUONG HOP DAC BIET
            v_strSQL = "SELECT * FROM CAMAST WHERE CAMASTID='" & v_strCAMASTID & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                Select Case v_ds.Tables(0).Rows(0)("CATYPE")
                    Case gc_CA_CATYPE_STOCK_MERGE 'Merge
                    Case gc_CA_CATYPE_STOCK_SPLIT 'Split
                    Case gc_CA_CATYPE_KIND_DIVIDENd 'Kind dividend
                    Case gc_CA_CATYPE_CASH_DIVIDENd 'Cash dividend
                    Case gc_CA_CATYPE_STOCK_DIVIDENd 'Stock dividend 
                    Case gc_CA_CATYPE_STOCK_RIGHTOFF 'Stock Rightoff
                    Case gc_CA_CATYPE_BOND_PAY_INTEREST 'Bond pay interest
                    Case gc_CA_CATYPE_BOND_PAY_INTEREST_PRINCIPAL 'Bond pay interest & prin
                    Case gc_CA_CATYPE_CONVERT_BOND_TO_SHARE 'Convert bond to share
                    Case gc_CA_CATYPE_CONVERT_RIGHT_TO_SHARE 'Convert Right to share
                    Case gc_CA_CATYPE_CHANGE_TRADING_PLACE_STOCK
                        If Not v_blnREVERSAL Then
                            v_strSQL = "UPDATE CAMAST SET STATUS ='S' WHERE CAMASTID='" & v_strCAMASTID & "' AND DELTD = 'N'"
                            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                        End If
                    Case gc_CA_CATYPE_HALT 'Halt trading
                        If Not v_blnREVERSAL Then
                            'Update trang thai HALT cho SBSECURITIES la Y: Tam ngung giao dich
                            v_strSQL = "UPDATE SBSECURITIES SET HALT ='Y' WHERE CODEID='" & v_ds.Tables(0).Rows(0)("CODEID") & "'"
                            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                        Else
                            'Update trang thai HALT cho SBSECURITIES la N: Giao dich binh thuong
                            v_strSQL = "UPDATE SBSECURITIES SET HALT ='N' WHERE CODEID='" & v_ds.Tables(0).Rows(0)("CODEID") & "'"
                            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                        End If
                    Case Else 'EXCEPTION
                End Select

            End If

            ''ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            ''ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
    Private Function AdjustContractCAEvent(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CA.Trans.AdjustContractCAEvent", v_strErrorMessage As String
        Dim v_strSQLTmp As String = String.Empty, v_strSQL As String = String.Empty, i As Integer
        Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE, v_lngCLEARDAY As Double

        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strAUTOID As String
            Dim v_dblAMT, v_dblQTTY, v_dblAAMT, v_dblAQTTY As Double
            Dim v_dblOldAMT, v_dblOldQTTY, v_dblOldAAMT, v_dblOldAQTTY As Double

            Dim v_ds As DataSet
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_strBRID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXTIME As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTIME).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_blnREVERSAL As Boolean = IIf(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value = "Y", True, False)
            '�?�?c nội dung giao dịch 2278  
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
                            v_strAUTOID = v_strVALUE
                        Case "10" 'AMT
                            v_dblAMT = v_dblVALUE
                        Case "11" 'QTTY
                            v_dblQTTY = v_dblVALUE
                        Case "12" 'AAMT
                            v_dblAAMT = v_dblVALUE
                        Case "13" 'AQTTY
                            v_dblAQTTY = v_dblVALUE
                        Case "20" 'Old AMT
                            v_dblOldAMT = v_dblVALUE
                        Case "21" 'Old QTTY
                            v_dblOldQTTY = v_dblVALUE
                        Case "22" 'Old AAMT
                            v_dblOldAAMT = v_dblVALUE
                        Case "23" 'Old AQTTY
                            v_dblOldAQTTY = v_dblVALUE
                    End Select
                End With
            Next
            If Not v_blnREVERSAL Then   'Nếu là duyệt:�?i�?u chỉnh các thông số trong CASCHD
                v_strSQL = "UPDATE CASCHD SET AMT=" & v_dblAMT & ",QTTY=" & v_dblQTTY & ",AAMT=" & v_dblAAMT & ",AQTTY=" & v_dblQTTY & " WHERE AUTOID='" & v_strAUTOID & "' AND DELTD='N'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            Else
                '�?i�?u chỉnh
                v_strSQL = "UPDATE CASCHD SET AMT=" & v_dblOldAMT & ",QTTY=" & v_dblOldQTTY & ",AAMT=" & v_dblOldAAMT & ",AQTTY=" & v_dblOldQTTY & " WHERE AUTOID='" & v_strAUTOID & "' AND DELTD='N'"
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
    Private Function ExecuteContractCAEvent(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CA.Trans.ExecuteContractCAEvent", v_strErrorMessage As String
        Dim v_strSQLTmp As String = String.Empty, v_strSQL As String = String.Empty, i As Integer
        Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE, v_lngCLEARDAY As Double
        Dim v_dblDFQTTY As Double = 0
        Dim v_strSEACCTNO As String
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strAUTOID, v_strSTATUS, v_strCAMASTID As String
            Dim v_strRIGHTTYPE As String
            Dim v_ds, v_dsTEMP As DataSet
            Dim v_obj As New DataAccess
            Dim v_ds_2 As DataSet
            Dim v_obj_2 As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_strBRID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXTIME As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTIME).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_blnREVERSAL As Boolean = IIf(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value = "Y", True, False)
            Dim v_strTLTXCD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value


            'LAY NOI DUNG GIAO DICH
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
                            v_strAUTOID = v_strVALUE
                        Case "02" 'CAMASTID
                            v_strCAMASTID = v_strVALUE
                        Case "08" ' SEACCTNO : jao dich 3351
                            v_strSEACCTNO = v_strVALUE
                    End Select
                End With
            Next

            'HaiLT them de lay cac loai hinh quyen` convert chung khoan
            v_strSQL = "SELECT VARVALUE FROM SYSVAR WHERE VARNAME='RIGHTCONVERTTYPE'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_strRIGHTTYPE = v_ds.Tables(0).Rows(0)("VARVALUE")
            End If



            If Not v_blnREVERSAL Then   'NEU DUYET 
                'NEU LICH THUC HIEN QUYEN LA COMPLETED OR CLOSED THI THONG BAO LOI
                v_strSQL = "SELECT STATUS ,ISCI, ISSE, AMT, AAMT, QTTY, AQTTY,DFQTTY  FROM CASCHD WHERE AUTOID='" & v_strAUTOID & "' AND DELTD ='N'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    If v_ds.Tables(0).Rows(0)("STATUS") = "C" Then
                        'BAO LOI
                        v_lngErrCode = ERR_CA_CASCHD_ALREADY_EXECUTED
                        Return v_lngErrCode
                    Else

                        If v_strTLTXCD = gc_CA_EXECUTE_SE_CAEVENT Then
                            'HaiLT them de phan bo vao SEPITLOG
                            v_strSQL = "BEGIN insert into caexec_temp (TLAUTOID,txnum,autoid, balance, camastid, afacctno, catype, codeid," &
                                       " excodeid, qtty, amt, aqtty, aamt, symbol, status,seacctno, exseacctno, parvalue, exparvalue, reportdate," &
                                       " actiondate, postingdate, description, taskcd, dutyamt, " &
                                       " fullname, idcode, custodycd,custid,TRADEPLACE, SECTYPE, PITRATE, TOCODEID) " &
                                       " SELECT seq_tllog.NEXTVAL, '" & BATCH_PREFIXED & "' || LPAD (seq_BATCHTXNUM.NEXTVAL, 8, '0') txnum," &
                                       " CA.AUTOID, CA.BALANCE, replace(ca.CAMASTID,'.','') CAMASTID, CA.AFACCTNO,ca.catypevalue CATYPE, (CASE WHEN CA.ISWFT='Y' THEN (SELECT CODEID FROM SBSECURITIES WHERE REFCODEID =CA.CODEID ) ELSE CA.CODEID END) CODEID," &
                                       " CA.EXCODEID, CA.QTTY, ROUND(CA.AMT) AMT, ROUND(CA.AQTTY) AQTTY,ROUND(CA.AAMT) AAMT, CA.SYMBOL, mst.status," &
                                       " CA.SEACCTNO,CA.EXSEACCTNO,CA.PARVALUE, CA.EXPARVALUE, CA.REPORTDATE ,CA.ACTIONDATE ,CA.POSTINGDATE," &
                                       " CA.description, CA.taskcd, CA.DUTYAMT, CA.FULLNAME, CA.IDCODE, CA.CUSTODYCD, cf.custid, SYM.TRADEPLACE, SYM.SECTYPE, CA.PITRATE, CA.TOCODEID " &
                                       " FROM v_ca3351 ca,caschd mst, cfmast cf,sbsecurities sym where(CA.codeid = sym.codeid And CA.autoid = mst.autoid) " &
                                       " and replace(ca.CAMASTID,'.','')= '" & v_strCAMASTID & "' and ca.custodycd = cf.custodycd; "

                            v_strSQL = v_strSQL & "INSERT INTO SEPITLOG(AUTOID,TXDATE,TXNUM,QTTY,MAPQTTY,CODEID,CAMASTID,ACCTNO,MODIFIEDDATE,AFACCTNO,PRICE,PITRATE)" &
                                       " select SEQ_SEPITLOG.NEXTVAL, TO_DATE ('" & v_strTXDATE & "', 'DD/MM/RRRR'), rec.txnum,ROUND(rec.QTTY,0),0, " &
                                       " case when rec.catype IN ('009') then rec.tocodeid else rec.codeid end codeid, " &
                                       " rec.camastid, rec.afacctno||rec.codeid, TO_DATE ('" & v_strTXDATE & "', 'DD/MM/RRRR'), rec.afacctno,0, rec.pitrate " &
                                       " from caexec_temp rec where camastid = '" & v_strCAMASTID & "' and  " &
                                       " INSTR((SELECT VARVALUE FROM sysvar WHERE GRNAME='SYSTEM' AND VARNAME='RIGHTVATDUTY'),rec.catype) > 0;" &
                                       " delete from caexec_temp where camastid = '" & v_strCAMASTID & "' ; END; "

                            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                            'HaiLT them de update SEPITLOG doi voi cac ma chung khoan can chuyen doi
                            v_strSQL = "SELECT CAMAST.*,SBSECURITIES.SYMBOL FROM CAMAST,SBSECURITIES WHERE CAMASTID='" & v_strCAMASTID & "' AND CAMAST.CODEID=SBSECURITIES.CODEID "
                            v_dsTEMP = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                            If v_dsTEMP.Tables(0).Rows.Count > 0 Then
                                If InStr(v_strRIGHTTYPE, v_dsTEMP.Tables(0).Rows(0)("CATYPE")) > 0 Then
                                    v_strSQL = "UPDATE SEPITLOG SET PCAMASTID=CAMASTID, CAMASTID= '" & v_strCAMASTID & "', CODEID = '" & v_dsTEMP.Tables(0).Rows(0)("TOCODEID") & "' WHERE CODEID='" & v_dsTEMP.Tables(0).Rows(0)("CODEID") & "'"
                                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                                End If
                            End If
                            'End of HaiLT them de update SEPITLOG doi voi cac ma chung khoan can chuyen doi
                            'End of HaiLT them de phan bo vao SEPITLOG

                            '' PhuongHT add: tinh lai gia von va menh gia voi tach (gop) co phieu

                            'v_strSQL = "SELECT * FROM CAMAST WHERE CAMASTID = " & v_strCAMASTID & ""
                            'v_ds_2 = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                            'If v_ds_2.Tables(0).Rows.Count > 0 Then
                            '    Select Case v_ds_2.Tables(0).Rows(0)("CATYPE")
                            '        Case gc_CA_CATYPE_STOCK_SPLIT, gc_CA_CATYPE_STOCK_MERGE ' Tach,gop
                            '            'Neu tach, gop thi thay doi menh gia
                            '            Dim v_strPARVALUE, v_strSPLITRATE, v_strCODEID As String
                            '            Dim v_strRightSplitRate, v_strLeftSplitRate As String
                            '            Dim v_dbSPLITRATE As Double
                            '            'v_strPARVALUE = Trim(v_ds_2.Tables(0).Rows(0)("PARVALUE"))
                            '            v_strSPLITRATE = Trim(v_ds_2.Tables(0).Rows(0)("SPLITRATE"))
                            '            v_strCODEID = Trim(v_ds_2.Tables(0).Rows(0)("CODEID"))
                            '            '  v_dbSPLITRATE = Trim(v_ds_2.Tables(0).Rows(0)("SPLITRATE"))
                            '            'v_dbSPLITRATE = Double.Parse(v_strSPLITRATE.Substring(0, v_strSPLITRATE.IndexOf("/"))) / Double.Parse(v_strSPLITRATE.Substring(v_strSPLITRATE.IndexOf("/") + 1))
                            '            ' update lai costprice trong semast

                            '            v_strSQL = "UPDATE SEMAST SET COSTPRICE=round (COSTPRICE * " & Double.Parse(v_strSPLITRATE.Substring(0, v_strSPLITRATE.IndexOf("/"))) & " / " & Double.Parse(v_strSPLITRATE.Substring(v_strSPLITRATE.IndexOf("/") + 1)) & ", 2) where acctno =  '" & v_strSEACCTNO & "'"
                            '            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                            '    End Select
                            'End If

                            '' End of PhuongHT add

                        End If

                        v_dblDFQTTY = v_ds.Tables(0).Rows(0)("DFQTTY")
                        If v_dblDFQTTY > 0 And v_ds.Tables(0).Rows(0)("ISSE") = "N" Then
                            'Thuc hien phong toa lai chung khoan ve giai toa chung khoan Block forward de cho phep ban.
                            Dim v_objParam As New StoreParameter
                            Dim v_arrPara(2) As StoreParameter

                            v_objParam = New StoreParameter
                            v_objParam.ParamName = "p_refDealID"
                            v_objParam.ParamValue = v_strAUTOID
                            v_objParam.ParamDirection = ParameterDirection.InputOutput
                            v_objParam.ParamSize = 32000
                            v_objParam.ParamType = GetType(System.String).Name
                            v_arrPara(0) = v_objParam

                            v_objParam = New StoreParameter
                            v_objParam.ParamName = "p_qtty"
                            v_objParam.ParamValue = v_dblDFQTTY
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
                            v_lngErrCode = v_obj.ExecuteOracleStored("CSPKS_DFPROC.pr_CADealReceive", v_arrPara, 2)
                        End If
                        If v_strTLTXCD = gc_CA_EXECUTE_CI_CAEVENT Or v_strTLTXCD = gc_CA_EXECUTE_CI_CAEVENT_NOTTAX Or v_strTLTXCD = gc_CA_EXECUTE_CI_CAEVENT_PIT_AT_ISSUER Then
                            v_strSQL = "UPDATE CASCHD SET ISCI='Y' WHERE AUTOID='" & v_strAUTOID & "' AND DELTD ='N'"
                            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                        ElseIf v_strTLTXCD = gc_CA_EXECUTE_SE_CAEVENT Then
                            v_strSQL = "UPDATE CASCHD SET ISSE='Y' WHERE AUTOID='" & v_strAUTOID & "' AND DELTD ='N'"
                            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                        End If

                        If Not ((v_strTLTXCD = gc_CA_EXECUTE_CI_CAEVENT Or v_strTLTXCD = gc_CA_EXECUTE_CI_CAEVENT_NOTTAX Or v_strTLTXCD = gc_CA_EXECUTE_SE_CAEVENT Or v_strTLTXCD = gc_CA_EXECUTE_CI_CAEVENT_PIT_AT_ISSUER) _
                            And ((v_ds.Tables(0).Rows(0)("ISCI") = "N" And v_ds.Tables(0).Rows(0)("AMT") + v_ds.Tables(0).Rows(0)("AAMT") > 0) _
                             Or (v_ds.Tables(0).Rows(0)("ISSE") = "N") And v_ds.Tables(0).Rows(0)("QTTY") + v_ds.Tables(0).Rows(0)("AQTTY") > 0)) Then

                            'DANH DAU HOAN TAT LICH THUC HIEN QUYEN
                            v_strSQL = "UPDATE CASCHD SET STATUS='C' WHERE AUTOID='" & v_strAUTOID & "' AND DELTD ='N'"
                            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                        End If


                    End If
                End If
            Else
                'NEU XOA GIAO DICH
                v_strSQL = "UPDATE CASCHD SET STATUS='S' WHERE AUTOID='" & v_strAUTOID & "' AND DELTD ='N'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                If v_strTLTXCD = gc_CA_EXECUTE_CI_CAEVENT Or v_strTLTXCD = gc_CA_EXECUTE_CI_CAEVENT_NOTTAX Or v_strTLTXCD = gc_CA_EXECUTE_CI_CAEVENT_PIT_AT_ISSUER Then
                    v_strSQL = "UPDATE CASCHD SET ISCI='N' WHERE AUTOID='" & v_strAUTOID & "' AND DELTD ='N'"
                ElseIf v_strTLTXCD = gc_CA_EXECUTE_SE_CAEVENT Then
                    v_strSQL = "UPDATE CASCHD SET ISSE='N' WHERE AUTOID='" & v_strAUTOID & "' AND DELTD ='N'"
                End If

                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                If v_strTLTXCD = gc_CA_EXECUTE_SE_CAEVENT Then
                    'HaiLT them de xoa trong SEPITLOG khi xoa gd 3351
                    'HaiLT them de update lai SEPITLOG doi voi cac ma chung khoan can chuyen doi
                    v_strSQL = "SELECT CAS.*, CAM.TOCODEID FROM CASCHD CAS, CAMAST CAM WHERE CAS.AUTOID = '" & v_strAUTOID & "' AND CAS.CAMASTID=CAM.CAMASTID AND CAS.CAMASTID= '" & v_strCAMASTID & "'"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count > 0 Then
                        v_strSQL = "UPDATE SEPITLOG SET CAMASTID=PCAMASTID, PCAMASTID= '', CODEID = '" & v_ds.Tables(0).Rows(0)("CODEID") & "' WHERE CODEID='" & v_ds.Tables(0).Rows(0)("TOCODEID") & "'"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    End If
                    v_strSQL = "DELETE FROM SEPITLOG WHERE CAMASTID = '" & v_strCAMASTID & "'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                    'End of HaiLT de xoa trong SEPITLOG khi xoa gd 3351

                    ''PhuongHT add: revert lai costprice trong SEMAST
                    'v_strSQL = "SELECT * FROM CAMAST WHERE CAMASTID = '" & v_strCAMASTID & "'"
                    'v_ds_2 = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    'If v_ds_2.Tables(0).Rows.Count > 0 Then
                    '    Select Case v_ds_2.Tables(0).Rows(0)("CATYPE")
                    '        Case gc_CA_CATYPE_STOCK_SPLIT, gc_CA_CATYPE_STOCK_MERGE ' Tach,gop
                    '            'Neu tach, gop thi thay doi menh gia
                    '            Dim v_strPARVALUE, v_strSPLITRATE, v_strCODEID As String
                    '            Dim v_strRightSplitRate, v_strLeftSplitRate As String
                    '            Dim v_dbSPLITRATE As Double
                    '            'v_strPARVALUE = Trim(v_ds.Tables(0).Rows(0)("PARVALUE"))
                    '            v_strSPLITRATE = Trim(v_ds_2.Tables(0).Rows(0)("SPLITRATE"))
                    '            v_strCODEID = Trim(v_ds_2.Tables(0).Rows(0)("CODEID"))
                    '            '  v_dbSPLITRATE = Trim(v_ds.Tables(0).Rows(0)("SPLITRATE"))
                    '            'v_dbSPLITRATE = Double.Parse(v_strSPLITRATE.Substring(0, v_strSPLITRATE.IndexOf("/"))) / Double.Parse(v_strSPLITRATE.Substring(v_strSPLITRATE.IndexOf("/") + 1))
                    '            ' update lai costprice trong semast

                    '            v_strSQL = "UPDATE SEMAST SET COSTPRICE=round (COSTPRICE / " & Double.Parse(v_strSPLITRATE.Substring(0, v_strSPLITRATE.IndexOf("/"))) & " * " & Double.Parse(v_strSPLITRATE.Substring(v_strSPLITRATE.IndexOf("/") + 1)) & ", 2) where acctno =  '" & v_strSEACCTNO & "'"
                    '            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)


                    '    End Select
                    'End If

                    '' End of PhuongHT add
                End If

            End If

            If Not v_blnREVERSAL Then


                'Update trang thai cua CAMAST thanh Complete khi da hoan tat trong CASCHD
                v_strSQL = "SELECT CAMASTID FROM CASCHD WHERE STATUS<>'C' AND CAMASTID='" & v_strCAMASTID & "' AND DELTD ='N'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count = 0 Then
                    v_strSQL = "UPDATE CAMAST SET STATUS='C' WHERE CAMASTID='" & v_strCAMASTID & "'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                    'AP DUNG CHO TRUONG HOP DAC BIET
                    v_strSQL = "SELECT CAMAST.*,SBSECURITIES.SYMBOL, to_char(ACTIONDATE,'DD/MM/RRRR') ACTION_DATE FROM CAMAST,SBSECURITIES WHERE CAMASTID='" & v_strCAMASTID & "' AND CAMAST.CODEID=SBSECURITIES.CODEID "
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count > 0 Then
                        Select Case v_ds.Tables(0).Rows(0)("CATYPE")
                            Case gc_CA_CATYPE_STOCK_SPLIT, gc_CA_CATYPE_STOCK_MERGE ' Tach,gop
                                'Neu tach, gop thi thay doi menh gia
                                Dim v_strPARVALUE, v_strSPLITRATE, v_strCODEID As String
                                Dim v_dbSPLITRATE As Double
                                v_strPARVALUE = Trim(v_ds.Tables(0).Rows(0)("PARVALUE"))
                                v_strSPLITRATE = Trim(v_ds.Tables(0).Rows(0)("SPLITRATE"))
                                v_strCODEID = Trim(v_ds.Tables(0).Rows(0)("CODEID"))
                                '  v_dbSPLITRATE = Trim(v_ds.Tables(0).Rows(0)("SPLITRATE"))

                                If Not v_blnREVERSAL Then
                                    v_strSQL = "SELECT CAMASTID FROM CASCHD WHERE STATUS<>'C' AND CAMASTID='" & v_strCAMASTID & "' AND DELTD ='N'"
                                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                                    If v_ds.Tables(0).Rows.Count = 0 Then
                                        'Tach gop co phieu theo menh gia
                                        v_strSQL = "UPDATE SBSECURITIES SET PARVALUE = PARVALUE * (" & v_strSPLITRATE & ") WHERE CODEID='" & v_strCODEID & "'"
                                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                                    End If
                                Else
                                    v_strSQL = "UPDATE SBSECURITIES SET PARVALUE ='" & v_strPARVALUE & "' WHERE CODEID='" & v_strCODEID & "'"
                                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                                End If
                            Case gc_CA_CATYPE_CHANGE_TRADING_PLACE_STOCK 'Chang trading place
                                Dim v_strCODEID, v_strSYMBOL, v_strTOTRADEPLACE, v_strFRTRADEPLACE As String
                                v_strCODEID = Trim(v_ds.Tables(0).Rows(0)("CODEID"))
                                v_strSYMBOL = Trim(v_ds.Tables(0).Rows(0)("SYMBOL"))
                                v_strTOTRADEPLACE = Trim(v_ds.Tables(0).Rows(0)("TOTRADEPLACE"))
                                v_strFRTRADEPLACE = Trim(v_ds.Tables(0).Rows(0)("FRTRADEPLACE"))
                                'Chuyen san trong sbsecurities
                                v_strSQL = "UPDATE SBSECURITIES SET TRADEPLACE ='" & v_strTOTRADEPLACE & "' WHERE CODEID='" & v_strCODEID & "'"
                                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                                ' PhuongHT: log thay doi thong tin chuyen san
                                v_strSQL = "INSERT INTO SETRADEPLACE (AUTOID,TXDATE,CODEID,CTYPE,FRTRADEPLACE,TOTRADEPLACE) " _
                                            & " VALUES (SEQ_SETRADEPLACE.NEXTVAL,to_date('" & v_ds.Tables(0).Rows(0)("ACTION_DATE") & "','DD/MM/RRRR'),'" & v_strCODEID & "','CA','" & v_strFRTRADEPLACE & "','" & v_strTOTRADEPLACE & "')"
                                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                                ' end of log thong tin chuyen san

                                'Thay doi ticksize cho phu hop voi san
                                ''0.1 Xoa ticksize cu di
                                'v_strSQL = "DELETE SECURITIES_TICKSIZE WHERE CODEID='" & v_strCODEID & "'"
                                'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                                ''0.2 Them vao ticksize moi cho chung khoan do
                                'If v_strTOTRADEPLACE = gc_TRADEPLACE_HCMCSTC Then
                                '    v_strSQL = "INSERT INTO SECURITIES_TICKSIZE (AUTOID,CODEID,SYMBOL,TICKSIZE,FROMPRICE,TOPRICE,STATUS) VALUES (SEQ_SECURITIES_TICKSIZE.NEXTVAL,'" & v_strCODEID & "','" & v_strSYMBOL & "',10,0,9990,'Y')"
                                '    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                                '    v_strSQL = "INSERT INTO securities_ticksize (AUTOID,CODEID,SYMBOL,TICKSIZE,FROMPRICE,TOPRICE,STATUS) VALUES (SEQ_SECURITIES_TICKSIZE.NEXTVAL,'" & v_strCODEID & "','" & v_strSYMBOL & "',50,10000,49950,'Y')"
                                '    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                                '    v_strSQL = "INSERT INTO securities_ticksize (AUTOID,CODEID,SYMBOL,TICKSIZE,FROMPRICE,TOPRICE,STATUS) VALUES (SEQ_SECURITIES_TICKSIZE.NEXTVAL,'" & v_strCODEID & "','" & v_strSYMBOL & "',100,50000,100000000,'Y')"
                                '    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                                'ElseIf (v_strTOTRADEPLACE = gc_TRADEPLACE_HNCSTC Or v_strTOTRADEPLACE = gc_TRADEPLACE_OTC) Then
                                '    v_strSQL = "INSERT INTO securities_ticksize (AUTOID,CODEID,SYMBOL,TICKSIZE,FROMPRICE,TOPRICE,STATUS) VALUES (SEQ_SECURITIES_TICKSIZE.NEXTVAL,'" & v_strCODEID & "','" & v_strSYMBOL & "',100,0,1000000000,'Y')"
                                '    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                                'ElseIf v_strTOTRADEPLACE = gc_TRADEPLACE_UPCOM Then
                                '    v_strSQL = "INSERT INTO securities_ticksize (AUTOID,CODEID,SYMBOL,TICKSIZE,FROMPRICE,TOPRICE,STATUS) VALUES (SEQ_SECURITIES_TICKSIZE.NEXTVAL,'" & v_strCODEID & "','" & v_strSYMBOL & "',100,100,1000000000,'Y')"
                                '    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                                'End If

                                'If v_strTOTRADEPLACE = gc_TRADEPLACE_HCMCSTC Then
                                '    v_strSQL = "UPDATE  SECURITIES_INFO SET  TRADELOT ='10' WHERE CODEID = '" & v_strCODEID & "' "
                                '    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                                'ElseIf (v_strTOTRADEPLACE = gc_TRADEPLACE_HNCSTC Or v_strTOTRADEPLACE = gc_TRADEPLACE_OTC Or v_strTOTRADEPLACE = gc_TRADEPLACE_UPCOM) Then
                                '    v_strSQL = "UPDATE  SECURITIES_INFO SET  TRADELOT ='100' WHERE CODEID = '" & v_strCODEID & "' "
                                '    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                                'End If
                                v_strSQL = "SELECT * FROM SBSECURITIES WHERE CODEID='" & v_strCODEID & "'"
                                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                                If v_ds.Tables(0).Rows.Count > 0 Then
                                    'v_strOldTradeplace = v_ds.Tables(0).Rows(0)("TRADEPLACE").ToString()
                                    'If (v_strOldTradeplace <> v_strTRADEPLACE) Then
                                    'tu dong them du lieu 2 bang SECURITIES_TICKSIZE va SECURITIES_INFO
                                    Dim v_objRptParam As ReportParameters
                                    Dim v_arrRptPara() As ReportParameters

                                    ReDim v_arrRptPara(16)

                                    '0. Condition value
                                    v_objRptParam = New ReportParameters
                                    v_objRptParam.ParamName = "CODEID"
                                    v_objRptParam.ParamValue = v_strCODEID
                                    v_objRptParam.ParamSize = CStr(v_strCODEID.Length)
                                    v_objRptParam.ParamType = GetType(System.String).Name
                                    v_arrRptPara(0) = v_objRptParam

                                    v_objRptParam = New ReportParameters
                                    v_objRptParam.ParamName = "SYMBOL"
                                    v_objRptParam.ParamValue = v_strSYMBOL
                                    v_objRptParam.ParamSize = CStr(v_strSYMBOL.Length)
                                    v_objRptParam.ParamType = GetType(System.String).Name
                                    v_arrRptPara(1) = v_objRptParam

                                    v_objRptParam = New ReportParameters
                                    v_objRptParam.ParamName = "TRADEPLACE"
                                    v_objRptParam.ParamValue = v_ds.Tables(0).Rows(0)("TRADEPLACE").ToString()
                                    v_objRptParam.ParamSize = CStr(v_ds.Tables(0).Rows(0)("TRADEPLACE").ToString().Length)
                                    v_objRptParam.ParamType = GetType(System.String).Name
                                    v_arrRptPara(2) = v_objRptParam

                                    'SECTYPE
                                    v_objRptParam = New ReportParameters
                                    v_objRptParam.ParamName = "SECTYPE"
                                    v_objRptParam.ParamValue = v_ds.Tables(0).Rows(0)("SECTYPE").ToString()
                                    v_objRptParam.ParamSize = CStr(v_ds.Tables(0).Rows(0)("SECTYPE").ToString().Length)
                                    v_objRptParam.ParamType = GetType(System.String).Name
                                    v_arrRptPara(3) = v_objRptParam

                                    '
                                    v_objRptParam = New ReportParameters
                                    v_objRptParam.ParamName = "PARVALUE"
                                    v_objRptParam.ParamValue = v_ds.Tables(0).Rows(0)("PARVALUE").ToString()
                                    v_objRptParam.ParamSize = 100
                                    v_objRptParam.ParamType = "Double"
                                    v_arrRptPara(4) = v_objRptParam

                                    'INTRATE
                                    v_objRptParam = New ReportParameters
                                    v_objRptParam.ParamName = "INTRATE"
                                    v_objRptParam.ParamValue = v_ds.Tables(0).Rows(0)("INTRATE").ToString()
                                    v_objRptParam.ParamSize = 100
                                    v_objRptParam.ParamType = "Double"
                                    v_arrRptPara(5) = v_objRptParam

                                    'STATUS
                                    v_objRptParam = New ReportParameters
                                    v_objRptParam.ParamName = "STATUS"
                                    v_objRptParam.ParamValue = v_ds.Tables(0).Rows(0)("STATUS").ToString()
                                    v_objRptParam.ParamSize = CStr(v_ds.Tables(0).Rows(0)("STATUS").ToString().Length)
                                    v_objRptParam.ParamType = GetType(System.String).Name
                                    v_arrRptPara(6) = v_objRptParam

                                    'CAREBY
                                    v_objRptParam = New ReportParameters
                                    v_objRptParam.ParamName = "CAREBY"
                                    v_objRptParam.ParamValue = v_ds.Tables(0).Rows(0)("CAREBY").ToString()
                                    v_objRptParam.ParamSize = CStr(v_ds.Tables(0).Rows(0)("CAREBY").ToString().Length)
                                    v_objRptParam.ParamType = GetType(System.String).Name
                                    v_arrRptPara(7) = v_objRptParam

                                    v_objRptParam = New ReportParameters
                                    v_objRptParam.ParamName = "EXPDATE"
                                    v_objRptParam.ParamValue = v_ds.Tables(0).Rows(0)("EXPDATE").ToString()
                                    v_objRptParam.ParamSize = CStr(v_ds.Tables(0).Rows(0)("EXPDATE").ToString().Length)
                                    v_objRptParam.ParamType = GetType(System.String).Name
                                    v_arrRptPara(8) = v_objRptParam

                                    v_objRptParam = New ReportParameters
                                    v_objRptParam.ParamName = "DEPOSITORY"
                                    v_objRptParam.ParamValue = v_ds.Tables(0).Rows(0)("DEPOSITORY").ToString()
                                    v_objRptParam.ParamSize = CStr(v_ds.Tables(0).Rows(0)("DEPOSITORY").ToString().Length)
                                    v_objRptParam.ParamType = GetType(System.String).Name
                                    v_arrRptPara(9) = v_objRptParam

                                    'SECTYPE
                                    v_objRptParam = New ReportParameters
                                    v_objRptParam.ParamName = "CHKRATE"
                                    v_objRptParam.ParamValue = v_ds.Tables(0).Rows(0)("CHKRATE").ToString()
                                    v_objRptParam.ParamSize = 100
                                    v_objRptParam.ParamType = "Double"
                                    v_arrRptPara(10) = v_objRptParam

                                    'INTPERIOD
                                    v_objRptParam = New ReportParameters
                                    v_objRptParam.ParamName = "INTPERIOD"
                                    v_objRptParam.ParamValue = v_ds.Tables(0).Rows(0)("INTPERIOD").ToString()
                                    v_objRptParam.ParamSize = 100
                                    v_objRptParam.ParamType = "Double"
                                    v_arrRptPara(11) = v_objRptParam

                                    'ISSUEDATE
                                    v_objRptParam = New ReportParameters
                                    v_objRptParam.ParamName = "ISSUEDATE"
                                    v_objRptParam.ParamValue = v_ds.Tables(0).Rows(0)("ISSUEDATE").ToString()
                                    v_objRptParam.ParamSize = CStr(v_ds.Tables(0).Rows(0)("ISSUEDATE").ToString().Length)
                                    v_objRptParam.ParamType = GetType(System.String).Name
                                    v_arrRptPara(12) = v_objRptParam

                                    'ISSUERID
                                    v_objRptParam = New ReportParameters
                                    v_objRptParam.ParamName = "ISSUERID"
                                    v_objRptParam.ParamValue = v_ds.Tables(0).Rows(0)("ISSUEDATE").ToString()
                                    v_objRptParam.ParamSize = CStr(v_ds.Tables(0).Rows(0)("ISSUEDATE").ToString().Length)
                                    v_objRptParam.ParamType = GetType(System.String).Name
                                    v_arrRptPara(13) = v_objRptParam

                                    'FOREIGNRATE
                                    v_objRptParam = New ReportParameters
                                    v_objRptParam.ParamName = "FOREIGNRATE"
                                    v_objRptParam.ParamValue = v_ds.Tables(0).Rows(0)("FOREIGNRATE").ToString()
                                    v_objRptParam.ParamSize = 100
                                    v_objRptParam.ParamType = "Double"
                                    v_arrRptPara(14) = v_objRptParam

                                    'ISSEDEPOFEE
                                    v_objRptParam = New ReportParameters
                                    v_objRptParam.ParamName = "ISSEDEPOFEE"
                                    v_objRptParam.ParamValue = v_ds.Tables(0).Rows(0)("ISSEDEPOFEE").ToString()
                                    v_objRptParam.ParamSize = CStr(v_ds.Tables(0).Rows(0)("ISSEDEPOFEE").ToString().Length)
                                    v_objRptParam.ParamType = GetType(System.String).Name
                                    v_arrRptPara(15) = v_objRptParam
                                    'TLID
                                    v_objRptParam = New ReportParameters
                                    v_objRptParam.ParamName = "TLID"
                                    v_objRptParam.ParamValue = "0000"
                                    v_objRptParam.ParamSize = 6
                                    v_objRptParam.ParamType = GetType(System.String).Name
                                    v_arrRptPara(16) = v_objRptParam

                                    v_obj.ExecuteStoredNonQuerry("PRC_UPDATE_SEC_EDIT_TRAPLACE", v_arrRptPara)
                                    'Buld XML data
                                    'End If
                                End If

                            Case gc_CA_CATYPE_KIND_DIVIDENd 'Kind dividend
                            Case gc_CA_CATYPE_CASH_DIVIDENd 'Cash dividend
                            Case gc_CA_CATYPE_STOCK_DIVIDENd 'Stock dividend 
                            Case gc_CA_CATYPE_STOCK_RIGHTOFF 'Stock Rightoff
                            Case gc_CA_CATYPE_BOND_PAY_INTEREST 'Bond pay interest
                            Case gc_CA_CATYPE_BOND_PAY_INTEREST_PRINCIPAL 'Bond pay interest & prin
                            Case gc_CA_CATYPE_CONVERT_BOND_TO_SHARE 'Convert bond to share
                            Case gc_CA_CATYPE_CONVERT_RIGHT_TO_SHARE 'Convert Right to share
                            Case gc_CA_CATYPE_HALT 'Halt trading

                            Case Else 'EXCEPTION
                        End Select
                    End If
                End If
            Else
                'Update trang thai cua CAMAST thanh Complete khi da hoan tat trong CASCHD
                v_strSQL = "SELECT CAMASTID FROM CASCHD WHERE STATUS='C' AND CAMASTID='" & v_strCAMASTID & "' AND DELTD ='N'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count = 0 Then
                    v_strSQL = "UPDATE CAMAST SET STATUS='I' WHERE CAMASTID='" & v_strCAMASTID & "'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                    'AP DUNG CHO TRUONG HOP DAC BIET
                    v_strSQL = "SELECT CAMAST.*,SBSECURITIES.SYMBOL, to_char(ACTIONDATE,'DD/MM/RRRR') ACTION_DATE FROM CAMAST,SBSECURITIES WHERE CAMASTID='" & v_strCAMASTID & "' AND CAMAST.CODEID=SBSECURITIES.CODEID "
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count > 0 Then
                        Select Case v_ds.Tables(0).Rows(0)("CATYPE")
                            Case gc_CA_CATYPE_STOCK_SPLIT, gc_CA_CATYPE_STOCK_MERGE ' Tach,gop
                                'Neu tach, gop thi thay doi menh gia
                                Dim v_strPARVALUE, v_strEXPRICE, v_strCODEID As String
                                v_strPARVALUE = Trim(v_ds.Tables(0).Rows(0)("PARVALUE"))
                                v_strEXPRICE = Trim(v_ds.Tables(0).Rows(0)("EXPRICE"))
                                v_strCODEID = Trim(v_ds.Tables(0).Rows(0)("CODEID"))
                                If Not v_blnREVERSAL Then
                                    v_strSQL = "SELECT CAMASTID FROM CASCHD WHERE STATUS<>'C' AND CAMASTID='" & v_strCAMASTID & "' AND DELTD ='N'"
                                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                                    If v_ds.Tables(0).Rows.Count = 0 Then
                                        'Tach gop co phieu theo menh gia
                                        v_strSQL = "UPDATE SBSECURITIES SET PARVALUE ='" & v_strEXPRICE & "' WHERE CODEID='" & v_strCODEID & "'"
                                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                                    End If
                                Else
                                    v_strSQL = "UPDATE SBSECURITIES SET PARVALUE ='" & v_strPARVALUE & "' WHERE CODEID='" & v_strCODEID & "'"
                                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                                End If
                            Case gc_CA_CATYPE_CHANGE_TRADING_PLACE_STOCK 'Chang trading place
                                Dim v_strCODEID, v_strSYMBOL, v_strTOTRADEPLACE, v_strFRTRADEPLACE As String
                                v_strCODEID = Trim(v_ds.Tables(0).Rows(0)("CODEID"))
                                v_strSYMBOL = Trim(v_ds.Tables(0).Rows(0)("SYMBOL"))
                                v_strTOTRADEPLACE = Trim(v_ds.Tables(0).Rows(0)("TOTRADEPLACE"))
                                v_strFRTRADEPLACE = Trim(v_ds.Tables(0).Rows(0)("FRTRADEPLACE"))
                                'Chuyen san trong sbsecurities
                                v_strSQL = "UPDATE SBSECURITIES SET TRADEPLACE ='" & v_strFRTRADEPLACE & "' WHERE CODEID='" & v_strCODEID & "'"
                                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                                ' PhuongHT: log thay doi thong tin chuyen san
                                v_strSQL = "INSERT INTO SETRADEPLACE (AUTOID,TXDATE,CODEID,CTYPE,FRTRADEPLACE,TOTRADEPLACE) " _
                                            & " VALUES (SEQ_SETRADEPLACE.NEXTVAL,to_date('" & v_ds.Tables(0).Rows(0)("ACTION_DATE") & "','DD/MM/RRRR'),'" & v_strCODEID & "','CA','" & v_strFRTRADEPLACE & "','" & v_strTOTRADEPLACE & "')"
                                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                                ' end of log thong tin chuyen san

                                'Thay doi ticksize cho phu hop voi san
                                ''0.1 Xoa ticksize cu di
                                'v_strSQL = "DELETE SECURITIES_TICKSIZE WHERE CODEID='" & v_strCODEID & "'"
                                'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                                ''0.2 Them vao ticksize moi cho chung khoan do
                                'If v_strTOTRADEPLACE = gc_TRADEPLACE_HCMCSTC Then
                                '    v_strSQL = "INSERT INTO SECURITIES_TICKSIZE (AUTOID,CODEID,SYMBOL,TICKSIZE,FROMPRICE,TOPRICE,STATUS) VALUES (SEQ_SECURITIES_TICKSIZE.NEXTVAL,'" & v_strCODEID & "','" & v_strSYMBOL & "',100,0,49900,'Y')"
                                '    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                                '    v_strSQL = "INSERT INTO securities_ticksize (AUTOID,CODEID,SYMBOL,TICKSIZE,FROMPRICE,TOPRICE,STATUS) VALUES (SEQ_SECURITIES_TICKSIZE.NEXTVAL,'" & v_strCODEID & "','" & v_strSYMBOL & "',500,50000,99500,'Y')"
                                '    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                                '    v_strSQL = "INSERT INTO securities_ticksize (AUTOID,CODEID,SYMBOL,TICKSIZE,FROMPRICE,TOPRICE,STATUS) VALUES (SEQ_SECURITIES_TICKSIZE.NEXTVAL,'" & v_strCODEID & "','" & v_strSYMBOL & "',1000,100000,100000000000,'Y')"
                                '    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                                'ElseIf (v_strTOTRADEPLACE = gc_TRADEPLACE_HNCSTC Or v_strTOTRADEPLACE = gc_TRADEPLACE_OTC) Then
                                '    v_strSQL = "INSERT INTO securities_ticksize (AUTOID,CODEID,SYMBOL,TICKSIZE,FROMPRICE,TOPRICE,STATUS) VALUES (SEQ_SECURITIES_TICKSIZE.NEXTVAL,'" & v_strCODEID & "','" & v_strSYMBOL & "',100,0,1000000000,'Y')"
                                '    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                                'ElseIf v_strTOTRADEPLACE = gc_TRADEPLACE_UPCOM Then
                                '    v_strSQL = "INSERT INTO securities_ticksize (AUTOID,CODEID,SYMBOL,TICKSIZE,FROMPRICE,TOPRICE,STATUS) VALUES (SEQ_SECURITIES_TICKSIZE.NEXTVAL,'" & v_strCODEID & "','" & v_strSYMBOL & "',100,100,1000000000,'Y')"
                                '    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                                'End If
                                v_strSQL = "SELECT * FROM SBSECURITIES WHERE CODEID='" & v_strCODEID & "'"
                                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                                If v_ds.Tables(0).Rows.Count > 0 Then
                                    'v_strOldTradeplace = v_ds.Tables(0).Rows(0)("TRADEPLACE").ToString()
                                    'If (v_strOldTradeplace <> v_strTRADEPLACE) Then
                                    'tu dong them du lieu 2 bang SECURITIES_TICKSIZE va SECURITIES_INFO
                                    Dim v_objRptParam As ReportParameters
                                    Dim v_arrRptPara() As ReportParameters

                                    ReDim v_arrRptPara(16)

                                    '0. Condition value
                                    v_objRptParam = New ReportParameters
                                    v_objRptParam.ParamName = "CODEID"
                                    v_objRptParam.ParamValue = v_strCODEID
                                    v_objRptParam.ParamSize = CStr(v_strCODEID.Length)
                                    v_objRptParam.ParamType = GetType(System.String).Name
                                    v_arrRptPara(0) = v_objRptParam

                                    v_objRptParam = New ReportParameters
                                    v_objRptParam.ParamName = "SYMBOL"
                                    v_objRptParam.ParamValue = v_strSYMBOL
                                    v_objRptParam.ParamSize = CStr(v_strSYMBOL.Length)
                                    v_objRptParam.ParamType = GetType(System.String).Name
                                    v_arrRptPara(1) = v_objRptParam

                                    v_objRptParam = New ReportParameters
                                    v_objRptParam.ParamName = "TRADEPLACE"
                                    v_objRptParam.ParamValue = v_ds.Tables(0).Rows(0)("TRADEPLACE").ToString()
                                    v_objRptParam.ParamSize = CStr(v_ds.Tables(0).Rows(0)("TRADEPLACE").ToString().Length)
                                    v_objRptParam.ParamType = GetType(System.String).Name
                                    v_arrRptPara(2) = v_objRptParam

                                    'SECTYPE
                                    v_objRptParam = New ReportParameters
                                    v_objRptParam.ParamName = "SECTYPE"
                                    v_objRptParam.ParamValue = v_ds.Tables(0).Rows(0)("SECTYPE").ToString()
                                    v_objRptParam.ParamSize = CStr(v_ds.Tables(0).Rows(0)("SECTYPE").ToString().Length)
                                    v_objRptParam.ParamType = GetType(System.String).Name
                                    v_arrRptPara(3) = v_objRptParam

                                    '
                                    v_objRptParam = New ReportParameters
                                    v_objRptParam.ParamName = "PARVALUE"
                                    v_objRptParam.ParamValue = v_ds.Tables(0).Rows(0)("PARVALUE").ToString()
                                    v_objRptParam.ParamSize = 100
                                    v_objRptParam.ParamType = "Double"
                                    v_arrRptPara(4) = v_objRptParam

                                    'INTRATE
                                    v_objRptParam = New ReportParameters
                                    v_objRptParam.ParamName = "INTRATE"
                                    v_objRptParam.ParamValue = v_ds.Tables(0).Rows(0)("INTRATE").ToString()
                                    v_objRptParam.ParamSize = 100
                                    v_objRptParam.ParamType = "Double"
                                    v_arrRptPara(5) = v_objRptParam

                                    'STATUS
                                    v_objRptParam = New ReportParameters
                                    v_objRptParam.ParamName = "STATUS"
                                    v_objRptParam.ParamValue = v_ds.Tables(0).Rows(0)("STATUS").ToString()
                                    v_objRptParam.ParamSize = CStr(v_ds.Tables(0).Rows(0)("STATUS").ToString().Length)
                                    v_objRptParam.ParamType = GetType(System.String).Name
                                    v_arrRptPara(6) = v_objRptParam

                                    'CAREBY
                                    v_objRptParam = New ReportParameters
                                    v_objRptParam.ParamName = "CAREBY"
                                    v_objRptParam.ParamValue = v_ds.Tables(0).Rows(0)("CAREBY").ToString()
                                    v_objRptParam.ParamSize = CStr(v_ds.Tables(0).Rows(0)("CAREBY").ToString().Length)
                                    v_objRptParam.ParamType = GetType(System.String).Name
                                    v_arrRptPara(7) = v_objRptParam

                                    v_objRptParam = New ReportParameters
                                    v_objRptParam.ParamName = "EXPDATE"
                                    v_objRptParam.ParamValue = v_ds.Tables(0).Rows(0)("EXPDATE").ToString()
                                    v_objRptParam.ParamSize = CStr(v_ds.Tables(0).Rows(0)("EXPDATE").ToString().Length)
                                    v_objRptParam.ParamType = GetType(System.String).Name
                                    v_arrRptPara(8) = v_objRptParam

                                    v_objRptParam = New ReportParameters
                                    v_objRptParam.ParamName = "DEPOSITORY"
                                    v_objRptParam.ParamValue = v_ds.Tables(0).Rows(0)("DEPOSITORY").ToString()
                                    v_objRptParam.ParamSize = CStr(v_ds.Tables(0).Rows(0)("DEPOSITORY").ToString().Length)
                                    v_objRptParam.ParamType = GetType(System.String).Name
                                    v_arrRptPara(9) = v_objRptParam

                                    'SECTYPE
                                    v_objRptParam = New ReportParameters
                                    v_objRptParam.ParamName = "CHKRATE"
                                    v_objRptParam.ParamValue = v_ds.Tables(0).Rows(0)("CHKRATE").ToString()
                                    v_objRptParam.ParamSize = 100
                                    v_objRptParam.ParamType = "Double"
                                    v_arrRptPara(10) = v_objRptParam

                                    'INTPERIOD
                                    v_objRptParam = New ReportParameters
                                    v_objRptParam.ParamName = "INTPERIOD"
                                    v_objRptParam.ParamValue = v_ds.Tables(0).Rows(0)("INTPERIOD").ToString()
                                    v_objRptParam.ParamSize = 100
                                    v_objRptParam.ParamType = "Double"
                                    v_arrRptPara(11) = v_objRptParam

                                    'ISSUEDATE
                                    v_objRptParam = New ReportParameters
                                    v_objRptParam.ParamName = "ISSUEDATE"
                                    v_objRptParam.ParamValue = v_ds.Tables(0).Rows(0)("ISSUEDATE").ToString()
                                    v_objRptParam.ParamSize = CStr(v_ds.Tables(0).Rows(0)("ISSUEDATE").ToString().Length)
                                    v_objRptParam.ParamType = GetType(System.String).Name
                                    v_arrRptPara(12) = v_objRptParam

                                    'ISSUERID
                                    v_objRptParam = New ReportParameters
                                    v_objRptParam.ParamName = "ISSUERID"
                                    v_objRptParam.ParamValue = v_ds.Tables(0).Rows(0)("ISSUEDATE").ToString()
                                    v_objRptParam.ParamSize = CStr(v_ds.Tables(0).Rows(0)("ISSUEDATE").ToString().Length)
                                    v_objRptParam.ParamType = GetType(System.String).Name
                                    v_arrRptPara(13) = v_objRptParam

                                    'FOREIGNRATE
                                    v_objRptParam = New ReportParameters
                                    v_objRptParam.ParamName = "FOREIGNRATE"
                                    v_objRptParam.ParamValue = v_ds.Tables(0).Rows(0)("FOREIGNRATE").ToString()
                                    v_objRptParam.ParamSize = 100
                                    v_objRptParam.ParamType = "Double"
                                    v_arrRptPara(14) = v_objRptParam

                                    'ISSEDEPOFEE
                                    v_objRptParam = New ReportParameters
                                    v_objRptParam.ParamName = "ISSEDEPOFEE"
                                    v_objRptParam.ParamValue = v_ds.Tables(0).Rows(0)("ISSEDEPOFEE").ToString()
                                    v_objRptParam.ParamSize = CStr(v_ds.Tables(0).Rows(0)("ISSEDEPOFEE").ToString().Length)
                                    v_objRptParam.ParamType = GetType(System.String).Name
                                    v_arrRptPara(15) = v_objRptParam
                                    'TLID
                                    v_objRptParam = New ReportParameters
                                    v_objRptParam.ParamName = "TLID"
                                    v_objRptParam.ParamValue = "0000"
                                    v_objRptParam.ParamSize = 6
                                    v_objRptParam.ParamType = GetType(System.String).Name
                                    v_arrRptPara(16) = v_objRptParam

                                    v_obj.ExecuteStoredNonQuerry("PRC_UPDATE_SEC_EDIT_TRAPLACE", v_arrRptPara)
                                End If
                            Case gc_CA_CATYPE_KIND_DIVIDENd 'Kind dividend
                            Case gc_CA_CATYPE_CASH_DIVIDENd 'Cash dividend
                            Case gc_CA_CATYPE_STOCK_DIVIDENd 'Stock dividend 
                            Case gc_CA_CATYPE_STOCK_RIGHTOFF 'Stock Rightoff
                            Case gc_CA_CATYPE_BOND_PAY_INTEREST 'Bond pay interest
                            Case gc_CA_CATYPE_BOND_PAY_INTEREST_PRINCIPAL 'Bond pay interest & prin
                            Case gc_CA_CATYPE_CONVERT_BOND_TO_SHARE 'Convert bond to share
                            Case gc_CA_CATYPE_CONVERT_RIGHT_TO_SHARE 'Convert Right to share
                            Case gc_CA_CATYPE_HALT 'Halt trading

                            Case Else 'EXCEPTION
                        End Select
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
    Private Function ExecuteCAEvent(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CA.Trans.ExecuteContractCAEvent", v_strErrorMessage As String
        Dim v_strSQLTmp As String = String.Empty, v_strSQL As String = String.Empty, i As Integer
        Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE, v_lngCLEARDAY As Double
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strAUTOID, v_strSTATUS, v_strCAMASTID As String
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

            'LAY NOI DUNG GIAO DICH
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
                        Case "03" 'CAMASTID
                            v_strCAMASTID = v_strVALUE
                    End Select
                End With
            Next

            If Not v_blnREVERSAL Then   'NEU DUYET
                v_strSQL = "SELECT * FROM CASCHD WHERE CAMASTID='" & v_strCAMASTID & "' AND STATUS IN('C') AND DELTD ='N'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    'BAO LOI
                    v_lngErrCode = ERR_CA_CAMASTID_ALREADY_SEND_OR_COMPLETE
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: Reversal." & v_blnREVERSAL.ToString() & "." & v_strCAMASTID & "." & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If
                'Update trang thai cho CASCHD la Complete



                v_strSQL = "UPDATE CASCHD SET STATUS='C' WHERE AUTOID='" & v_strAUTOID & "' AND DELTD ='N'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            Else
                v_strSQL = "SELECT CASCHD.*,CAMAST.CATYPE FROM CASCHD,CAMAST WHERE CASCHD.CAMASTID=CAMAST.CAMASTID AND  CASCHD.CAMASTID='" & v_strCAMASTID & "' AND CASCHD.STATUS ='C' AND CASCHD.DELTD ='N'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If Not v_ds.Tables(0).Rows.Count > 0 Then
                    'BAO LOI
                    v_lngErrCode = ERR_CAMAST_STATUS_INVALID
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: Reversal." & v_blnREVERSAL.ToString() & "." & v_strCAMASTID & "." & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If
                'UPDATE INF trong CASCHD
                v_strSQL = "UPDATE CASCHD SET STATUS ='S' WHERE CAMASTID='" & v_strCAMASTID & "' AND DELTD = 'N'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            End If


            'AP DUNG CHO TRUONG HOP DAC BIET
            v_strSQL = "SELECT CAMAST.*,SBSECURITIES.SYMBOL,to_char(ACTIONDATE,'DD/MM/RRRR') ACTION_DATE FROM CAMAST,SBSECURITIES WHERE CAMASTID='" & v_strCAMASTID & "' AND CAMAST.CODEID=SBSECURITIES.CODEID "
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                Select Case v_ds.Tables(0).Rows(0)("CATYPE")
                    Case gc_CA_CATYPE_STOCK_SPLIT, gc_CA_CATYPE_STOCK_MERGE ' Tach,gop
                        'Neu tach, gop thi thay doi menh gia
                        Dim v_strPARVALUE, v_strEXPRICE, v_strCODEID As String
                        v_strPARVALUE = Trim(v_ds.Tables(0).Rows(0)("PARVALUE"))
                        v_strEXPRICE = Trim(v_ds.Tables(0).Rows(0)("EXPRICE"))
                        v_strCODEID = Trim(v_ds.Tables(0).Rows(0)("CODEID"))
                        If Not v_blnREVERSAL Then
                            v_strSQL = "SELECT CAMASTID FROM CASCHD WHERE STATUS<>'C' AND CAMASTID='" & v_strCAMASTID & "' AND DELTD ='N'"
                            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                            If v_ds.Tables(0).Rows.Count = 0 Then
                                'Tach gop co phieu theo menh gia
                                v_strSQL = "UPDATE SBSECURITIES SET PARVALUE ='" & v_strEXPRICE & "' WHERE CODEID='" & v_strCODEID & "'"
                                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                            End If
                        Else
                            v_strSQL = "UPDATE SBSECURITIES SET PARVALUE ='" & v_strPARVALUE & "' WHERE CODEID='" & v_strCODEID & "'"
                            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                        End If
                    Case gc_CA_CATYPE_CHANGE_TRADING_PLACE_STOCK 'Chang trading place
                        Dim v_strCODEID, v_strSYMBOL, v_strTOTRADEPLACE, v_strFRTRADEPLACE As String
                        v_strCODEID = Trim(v_ds.Tables(0).Rows(0)("CODEID"))
                        v_strSYMBOL = Trim(v_ds.Tables(0).Rows(0)("SYMBOL"))
                        v_strTOTRADEPLACE = Trim(v_ds.Tables(0).Rows(0)("TOTRADEPLACE"))
                        v_strFRTRADEPLACE = Trim(v_ds.Tables(0).Rows(0)("FRTRADEPLACE"))
                        'Chuyen san trong sbsecurities
                        v_strSQL = "UPDATE SBSECURITIES SET TRADEPLACE ='" & v_strTOTRADEPLACE & "' WHERE CODEID='" & v_strCODEID & "'"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                        ' PhuongHT: log thay doi thong tin chuyen san
                        v_strSQL = "INSERT INTO SETRADEPLACE (AUTOID,TXDATE,CODEID,CTYPE,FRTRADEPLACE,TOTRADEPLACE) " _
                                    & " VALUES (SEQ_SETRADEPLACE.NEXTVAL,to_date('" & v_ds.Tables(0).Rows(0)("ACTION_DATE") & "','DD/MM/RRRR'),'" & v_strCODEID & "','CA','" & v_strFRTRADEPLACE & "','" & v_strTOTRADEPLACE & "')"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                        ' end of log thong tin chuyen san
                        'Thay doi ticksize cho phu hop voi san
                        ''0.1 Xoa ticksize cu di
                        'v_strSQL = "DELETE SECURITIES_TICKSIZE WHERE CODEID='" & v_strCODEID & "'"
                        'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                        ''0.2 Them vao ticksize moi cho chung khoan do
                        'If v_strTOTRADEPLACE = gc_TRADEPLACE_HCMCSTC Then
                        '    v_strSQL = "INSERT INTO SECURITIES_TICKSIZE (AUTOID,CODEID,SYMBOL,TICKSIZE,FROMPRICE,TOPRICE,STATUS) VALUES (SEQ_SECURITIES_TICKSIZE.NEXTVAL,'" & v_strCODEID & "','" & v_strSYMBOL & "',100,0,49900,'Y')"
                        '    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                        '    v_strSQL = "INSERT INTO securities_ticksize (AUTOID,CODEID,SYMBOL,TICKSIZE,FROMPRICE,TOPRICE,STATUS) VALUES (SEQ_SECURITIES_TICKSIZE.NEXTVAL,'" & v_strCODEID & "','" & v_strSYMBOL & "',500,50000,99500,'Y')"
                        '    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                        '    v_strSQL = "INSERT INTO securities_ticksize (AUTOID,CODEID,SYMBOL,TICKSIZE,FROMPRICE,TOPRICE,STATUS) VALUES (SEQ_SECURITIES_TICKSIZE.NEXTVAL,'" & v_strCODEID & "','" & v_strSYMBOL & "',1000,100000,100000000000,'Y')"
                        '    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                        'ElseIf v_strTOTRADEPLACE = gc_TRADEPLACE_HNCSTC Then
                        '    v_strSQL = "INSERT INTO securities_ticksize (AUTOID,CODEID,SYMBOL,TICKSIZE,FROMPRICE,TOPRICE,STATUS) VALUES (SEQ_SECURITIES_TICKSIZE.NEXTVAL,'" & v_strCODEID & "','" & v_strSYMBOL & "',100,0,1000000000,'Y')"
                        '    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                        'End If
                        'If v_strTOTRADEPLACE = gc_TRADEPLACE_HCMCSTC Then
                        '    v_strSQL = "UPDATE SECURITIES_INFO set TRADELOT ='10'  WHERE CODEID='" & v_strCODEID & "'  "
                        '    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                        'Else
                        '    v_strSQL = "UPDATE SECURITIES_INFO set TRADELOT ='100' WHERE CODEID='" & v_strCODEID & "'  "
                        '    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                        'End If
                        v_strSQL = "SELECT * FROM SBSECURITIES WHERE CODEID='" & v_strCODEID & "'"
                        v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                        If v_ds.Tables(0).Rows.Count > 0 Then
                            'v_strOldTradeplace = v_ds.Tables(0).Rows(0)("TRADEPLACE").ToString()
                            'If (v_strOldTradeplace <> v_strTRADEPLACE) Then
                            'tu dong them du lieu 2 bang SECURITIES_TICKSIZE va SECURITIES_INFO
                            Dim v_objRptParam As ReportParameters
                            Dim v_arrRptPara() As ReportParameters

                            ReDim v_arrRptPara(16)

                            '0. Condition value
                            v_objRptParam = New ReportParameters
                            v_objRptParam.ParamName = "CODEID"
                            v_objRptParam.ParamValue = v_strCODEID
                            v_objRptParam.ParamSize = CStr(v_strCODEID.Length)
                            v_objRptParam.ParamType = GetType(System.String).Name
                            v_arrRptPara(0) = v_objRptParam

                            v_objRptParam = New ReportParameters
                            v_objRptParam.ParamName = "SYMBOL"
                            v_objRptParam.ParamValue = v_strSYMBOL
                            v_objRptParam.ParamSize = CStr(v_strSYMBOL.Length)
                            v_objRptParam.ParamType = GetType(System.String).Name
                            v_arrRptPara(1) = v_objRptParam

                            v_objRptParam = New ReportParameters
                            v_objRptParam.ParamName = "TRADEPLACE"
                            v_objRptParam.ParamValue = v_ds.Tables(0).Rows(0)("TRADEPLACE").ToString()
                            v_objRptParam.ParamSize = CStr(v_ds.Tables(0).Rows(0)("TRADEPLACE").ToString().Length)
                            v_objRptParam.ParamType = GetType(System.String).Name
                            v_arrRptPara(2) = v_objRptParam

                            'SECTYPE
                            v_objRptParam = New ReportParameters
                            v_objRptParam.ParamName = "SECTYPE"
                            v_objRptParam.ParamValue = v_ds.Tables(0).Rows(0)("SECTYPE").ToString()
                            v_objRptParam.ParamSize = CStr(v_ds.Tables(0).Rows(0)("SECTYPE").ToString().Length)
                            v_objRptParam.ParamType = GetType(System.String).Name
                            v_arrRptPara(3) = v_objRptParam

                            '
                            v_objRptParam = New ReportParameters
                            v_objRptParam.ParamName = "PARVALUE"
                            v_objRptParam.ParamValue = v_ds.Tables(0).Rows(0)("PARVALUE").ToString()
                            v_objRptParam.ParamSize = 100
                            v_objRptParam.ParamType = "Double"
                            v_arrRptPara(4) = v_objRptParam

                            'INTRATE
                            v_objRptParam = New ReportParameters
                            v_objRptParam.ParamName = "INTRATE"
                            v_objRptParam.ParamValue = v_ds.Tables(0).Rows(0)("INTRATE").ToString()
                            v_objRptParam.ParamSize = 100
                            v_objRptParam.ParamType = "Double"
                            v_arrRptPara(5) = v_objRptParam

                            'STATUS
                            v_objRptParam = New ReportParameters
                            v_objRptParam.ParamName = "STATUS"
                            v_objRptParam.ParamValue = v_ds.Tables(0).Rows(0)("STATUS").ToString()
                            v_objRptParam.ParamSize = CStr(v_ds.Tables(0).Rows(0)("STATUS").ToString().Length)
                            v_objRptParam.ParamType = GetType(System.String).Name
                            v_arrRptPara(6) = v_objRptParam

                            'CAREBY
                            v_objRptParam = New ReportParameters
                            v_objRptParam.ParamName = "CAREBY"
                            v_objRptParam.ParamValue = v_ds.Tables(0).Rows(0)("CAREBY").ToString()
                            v_objRptParam.ParamSize = CStr(v_ds.Tables(0).Rows(0)("CAREBY").ToString().Length)
                            v_objRptParam.ParamType = GetType(System.String).Name
                            v_arrRptPara(7) = v_objRptParam

                            v_objRptParam = New ReportParameters
                            v_objRptParam.ParamName = "EXPDATE"
                            v_objRptParam.ParamValue = v_ds.Tables(0).Rows(0)("EXPDATE").ToString()
                            v_objRptParam.ParamSize = CStr(v_ds.Tables(0).Rows(0)("EXPDATE").ToString().Length)
                            v_objRptParam.ParamType = GetType(System.String).Name
                            v_arrRptPara(8) = v_objRptParam

                            v_objRptParam = New ReportParameters
                            v_objRptParam.ParamName = "DEPOSITORY"
                            v_objRptParam.ParamValue = v_ds.Tables(0).Rows(0)("DEPOSITORY").ToString()
                            v_objRptParam.ParamSize = CStr(v_ds.Tables(0).Rows(0)("DEPOSITORY").ToString().Length)
                            v_objRptParam.ParamType = GetType(System.String).Name
                            v_arrRptPara(9) = v_objRptParam

                            'SECTYPE
                            v_objRptParam = New ReportParameters
                            v_objRptParam.ParamName = "CHKRATE"
                            v_objRptParam.ParamValue = v_ds.Tables(0).Rows(0)("CHKRATE").ToString()
                            v_objRptParam.ParamSize = 100
                            v_objRptParam.ParamType = "Double"
                            v_arrRptPara(10) = v_objRptParam

                            'INTPERIOD
                            v_objRptParam = New ReportParameters
                            v_objRptParam.ParamName = "INTPERIOD"
                            v_objRptParam.ParamValue = v_ds.Tables(0).Rows(0)("INTPERIOD").ToString()
                            v_objRptParam.ParamSize = 100
                            v_objRptParam.ParamType = "Double"
                            v_arrRptPara(11) = v_objRptParam

                            'ISSUEDATE
                            v_objRptParam = New ReportParameters
                            v_objRptParam.ParamName = "ISSUEDATE"
                            v_objRptParam.ParamValue = v_ds.Tables(0).Rows(0)("ISSUEDATE").ToString()
                            v_objRptParam.ParamSize = CStr(v_ds.Tables(0).Rows(0)("ISSUEDATE").ToString().Length)
                            v_objRptParam.ParamType = GetType(System.String).Name
                            v_arrRptPara(12) = v_objRptParam

                            'ISSUERID
                            v_objRptParam = New ReportParameters
                            v_objRptParam.ParamName = "ISSUERID"
                            v_objRptParam.ParamValue = v_ds.Tables(0).Rows(0)("ISSUEDATE").ToString()
                            v_objRptParam.ParamSize = CStr(v_ds.Tables(0).Rows(0)("ISSUEDATE").ToString().Length)
                            v_objRptParam.ParamType = GetType(System.String).Name
                            v_arrRptPara(13) = v_objRptParam

                            'FOREIGNRATE
                            v_objRptParam = New ReportParameters
                            v_objRptParam.ParamName = "FOREIGNRATE"
                            v_objRptParam.ParamValue = v_ds.Tables(0).Rows(0)("FOREIGNRATE").ToString()
                            v_objRptParam.ParamSize = 100
                            v_objRptParam.ParamType = "Double"
                            v_arrRptPara(14) = v_objRptParam

                            'ISSEDEPOFEE
                            v_objRptParam = New ReportParameters
                            v_objRptParam.ParamName = "ISSEDEPOFEE"
                            v_objRptParam.ParamValue = v_ds.Tables(0).Rows(0)("ISSEDEPOFEE").ToString()
                            v_objRptParam.ParamSize = CStr(v_ds.Tables(0).Rows(0)("ISSEDEPOFEE").ToString().Length)
                            v_objRptParam.ParamType = GetType(System.String).Name
                            v_arrRptPara(15) = v_objRptParam
                            'TLID
                            v_objRptParam = New ReportParameters
                            v_objRptParam.ParamName = "TLID"
                            v_objRptParam.ParamValue = "0000"
                            v_objRptParam.ParamSize = 6
                            v_objRptParam.ParamType = GetType(System.String).Name
                            v_arrRptPara(16) = v_objRptParam

                            v_obj.ExecuteStoredNonQuerry("PRC_UPDATE_SEC_EDIT_TRAPLACE", v_arrRptPara)
                        End If

                    Case gc_CA_CATYPE_KIND_DIVIDENd 'Kind dividend
                    Case gc_CA_CATYPE_CASH_DIVIDENd 'Cash dividend
                    Case gc_CA_CATYPE_STOCK_DIVIDENd 'Stock dividend 
                    Case gc_CA_CATYPE_STOCK_RIGHTOFF 'Stock Rightoff
                    Case gc_CA_CATYPE_BOND_PAY_INTEREST 'Bond pay interest
                    Case gc_CA_CATYPE_BOND_PAY_INTEREST_PRINCIPAL 'Bond pay interest & prin
                    Case gc_CA_CATYPE_CONVERT_BOND_TO_SHARE 'Convert bond to share
                    Case gc_CA_CATYPE_CONVERT_RIGHT_TO_SHARE 'Convert Right to share
                    Case gc_CA_CATYPE_HALT 'Halt trading

                    Case Else 'EXCEPTION
                End Select

            End If
            ''ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            ''ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
    Private Function SendContractCAEvent(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CA.Trans.SendContractCAEvent", v_strErrorMessage As String
        Dim v_strSQLTmp As String = String.Empty, v_strSQL As String = String.Empty, i As Integer
        Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE, v_lngCLEARDAY As Double
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strAUTOID, v_strCAMASTID, v_strCATYPE As String
            Dim v_strSTATUS As String, v_strNewSTATUS As String
            Dim v_ds As DataSet
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_strBRID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXTIME As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTIME).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_blnREVERSAL As Boolean = IIf(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value = "Y", True, False)

            '�?�?c nội dung giao dịch
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
                            v_strAUTOID = v_strVALUE
                        Case "02" 'CAMASTID
                            v_strCAMASTID = v_strVALUE
                        Case "40"
                            v_strSTATUS = v_strVALUE
                        Case "41"
                            v_strNewSTATUS = v_strVALUE
                    End Select
                End With
            Next

            If Not v_blnREVERSAL Then
                v_strSQL = "SELECT CASCHD.*,CAMAST.CATYPE FROM CASCHD,CAMAST WHERE CASCHD.camastid=CAMAST.camastid AND CASCHD.AUTOID='" & v_strAUTOID & "' AND CASCHD.DELTD ='N'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then

                    'Cap nhat trang thai CASCHD thanh send
                    v_strSQL = "UPDATE CASCHD SET STATUS='" & v_strNewSTATUS & "' WHERE AUTOID='" & v_strAUTOID & "' AND DELTD ='N'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                    ''Cap nhat trang thai CASCHD thanh send
                    'v_strSQL = "UPDATE CAMAST SET STATUS='" & v_strNewSTATUS & "' WHERE  CAMASTID='" & v_strCAMASTID & "' AND DELTD ='N'"
                    'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                End If
            Else
                'Neu xoa giao dich
                v_strSQL = "UPDATE CASCHD SET STATUS='" & v_strSTATUS & "'" & " WHERE AUTOID='" & v_strAUTOID & "' AND DELTD ='N'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            End If


            'Update trang thai cua CAMAST thanh Send va thuc hien cac cong viec khi da hoan tat trong CASCHD
            If Not v_blnREVERSAL Then
                v_strSQL = "SELECT CAMASTID FROM CASCHD WHERE STATUS='" & v_strSTATUS & "' AND CAMASTID='" & v_strCAMASTID & "' AND DELTD ='N'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count = 0 Then
                    v_strSQL = "UPDATE CAMAST SET STATUS='" & v_strNewSTATUS & "' WHERE CAMASTID='" & v_strCAMASTID & "'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    'AP DUNG CHO TRUONG HOP DAC BIET
                    v_strSQL = "SELECT * FROM CAMAST WHERE CAMASTID='" & v_strCAMASTID & "'"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count > 0 Then
                        Select Case v_ds.Tables(0).Rows(0)("CATYPE")
                            Case gc_CA_CATYPE_STOCK_MERGE 'Merge
                            Case gc_CA_CATYPE_STOCK_SPLIT 'Split
                            Case gc_CA_CATYPE_KIND_DIVIDENd 'Kind dividend
                            Case gc_CA_CATYPE_CASH_DIVIDENd 'Cash dividend
                            Case gc_CA_CATYPE_STOCK_DIVIDENd 'Stock dividend 
                            Case gc_CA_CATYPE_STOCK_RIGHTOFF 'Stock Rightoff
                            Case gc_CA_CATYPE_BOND_PAY_INTEREST 'Bond pay interest
                            Case gc_CA_CATYPE_BOND_PAY_INTEREST_PRINCIPAL 'Bond pay interest & prin
                            Case gc_CA_CATYPE_CONVERT_BOND_TO_SHARE 'Convert bond to share
                            Case gc_CA_CATYPE_CONVERT_RIGHT_TO_SHARE 'Convert Right to share
                            Case gc_CA_CATYPE_HALT 'Halt trading
                                'Update trang thai HALT cho SBSECURITIES la Y: Tam ngung giao dich
                                v_strSQL = "UPDATE SBSECURITIES SET HALT ='Y' WHERE CODEID='" & v_ds.Tables(0).Rows(0)("CODEID") & "'"
                                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                            Case Else 'EXCEPTION
                        End Select

                    End If


                End If
            Else
                'Revert
                v_strSQL = "SELECT CAMASTID FROM CASCHD WHERE STATUS='" & v_strSTATUS & "' AND CAMASTID='" & v_strCAMASTID & "' AND DELTD ='N'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_strSQL = "UPDATE CAMAST SET STATUS='" & v_strSTATUS & "' WHERE CAMASTID='" & v_strCAMASTID & "'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                    'AP DUNG CHO TRUONG HOP DAC BIET
                    v_strSQL = "SELECT * FROM CAMAST WHERE CAMASTID='" & v_strCAMASTID & "'"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count > 0 Then
                        Select Case v_ds.Tables(0).Rows(0)("CATYPE")
                            Case gc_CA_CATYPE_STOCK_MERGE 'Merge
                            Case gc_CA_CATYPE_STOCK_SPLIT 'Split
                            Case gc_CA_CATYPE_KIND_DIVIDENd 'Kind dividend
                            Case gc_CA_CATYPE_CASH_DIVIDENd 'Cash dividend
                            Case gc_CA_CATYPE_STOCK_DIVIDENd 'Stock dividend 
                            Case gc_CA_CATYPE_STOCK_RIGHTOFF 'Stock Rightoff
                            Case gc_CA_CATYPE_BOND_PAY_INTEREST 'Bond pay interest
                            Case gc_CA_CATYPE_BOND_PAY_INTEREST_PRINCIPAL 'Bond pay interest & prin
                            Case gc_CA_CATYPE_CONVERT_BOND_TO_SHARE 'Convert bond to share
                            Case gc_CA_CATYPE_CONVERT_RIGHT_TO_SHARE 'Convert Right to share
                            Case gc_CA_CATYPE_HALT 'Halt trading
                                'Update trang thai HALT cho SBSECURITIES la N: Giao dich binh thuong
                                v_strSQL = "UPDATE SBSECURITIES SET HALT ='N' WHERE CODEID='" & v_ds.Tables(0).Rows(0)("CODEID") & "'"
                                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                            Case Else 'EXCEPTION
                        End Select

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
#End Region

#Region " Overrides Methods "

#End Region

End Class
