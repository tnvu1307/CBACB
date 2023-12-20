Imports HostCommonLibrary
Imports CoreBusiness
Imports DataAccessLayer
Imports System.Data
'Imports System.EnterpriseServices
'<JustInTimeActivation(False), _
'Transaction(TransactionOption.Disabled), _
'ObjectPooling(Enabled:=True, MinPoolSize:=30)> _
Public Class Batch
    Inherits CoreBusiness.Batch

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_MODULE = "OD"
        ATTR_TABLE = "ODMAST"
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Overrides Function ExecuteRouter(ByVal v_strBCHMDL As String, Optional ByVal v_strBCHFillter As String = "", Optional ByRef v_intMaxRow As Integer = 0) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = ATTR_MODULE & ".Batch.ExecuteRouter", v_strErrorMessage As String
        Dim v_strxmlMessage As String, v_xmlMessage As New Xml.XmlDocument
        Try
            Select Case v_strBCHMDL
                Case "ODICCF"
                    'Tinh phi lenh khai bao trong ICCF
                    v_lngErrCode = ICCFCalculate(v_strBCHMDL, v_strBCHFillter, v_intMaxRow)
                Case "SODICCF"
                    'Tinh phi lenh khai bao trong ICCF theo kieu don gian F,T
                    v_lngErrCode = SimpleTradingFeeCalculate()
                Case "ODTRFM"
                    'Giao tien, chung khoan
                    v_lngErrCode = ODSettlementTransferMoney(v_strBCHMDL, v_strBCHFillter, v_intMaxRow)
                Case "ODTRFMS"
                    'Giao tien, chung khoan
                    v_lngErrCode = ODSurelySettlementTransferMoney(v_strBCHMDL, v_strBCHFillter, v_intMaxRow)
                Case "ODTRFS"
                    'Giao tien, chung khoan
                    v_lngErrCode = ODSettlementTransferSec(v_strBCHMDL, v_strBCHFillter, v_intMaxRow)
                Case "ODCLN"
                    v_lngErrCode = OrderCleanUp()
                Case "ODRCVM", "ODRCVMT3"
                    'Nhan tien ve 
                    v_lngErrCode = ODSettlementReceive(v_strBCHMDL, "RM", v_strBCHFillter, v_intMaxRow)
                Case "ODPAIDSF", "ODPAIDSFT3"
                    'Tra phi ban
                    v_lngErrCode = ODSellFee(v_strBCHMDL, v_strBCHFillter, v_intMaxRow)
                Case "ODPAIDBF"
                    'Tra phi mua
                    v_lngErrCode = ODBuyFee(v_strBCHMDL, v_strBCHFillter, v_intMaxRow)
                Case "ODRCVS"
                    'Nhan chung khoan ve
                    v_lngErrCode = ODSettlementReceive(v_strBCHMDL, "RS", v_strBCHFillter, v_intMaxRow)
                Case "ODRLSADV", "ODRLSADVT3"
                    'Tra ung truoc tien ban
                    v_lngErrCode = ODDayReleaseAdvanced(v_strBCHMDL, v_strBCHFillter, v_intMaxRow)
                Case "ODRLSBADV"
                    'Tra ung truoc tien ban
                    v_lngErrCode = ODReleaseBlockAdvanced(v_strBCHMDL, v_strBCHFillter, v_intMaxRow)

                Case "ODBAK"
                    'Backup lenh da het hieu luc hoac thanh toan xong
                    v_lngErrCode = ODBackUp(v_strBCHMDL, v_strBCHFillter, v_intMaxRow)

                Case "ODFSH"
                    v_lngErrCode = OrderFinish()
            End Select
            'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

#Region " Private function"


    Private Function ODSellFee(ByVal v_strBATCHNAME As String, Optional ByVal v_strBCHFillter As String = "", Optional ByRef v_intMaxRow As Integer = 0) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = ATTR_MODULE & ".Batch.ODSettlementReceive", v_strErrorMessage As String
        Dim v_strSQL As String, v_ds, v_dsCNT, v_dsTLLOG, v_dsDealing, v_dsCostPrice As DataSet, v_objMessageLog As New MessageLog
        v_objMessageLog.NewDBInstance(gc_MODULE_HOST)
        Dim v_obj As New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)
        Dim i, j As Integer, v_strFRTABLE, v_strTOTABLE As String
        Dim v_dblCostprice, v_dblProfit, v_dblLoss As Double
        Dim v_xmlDocument As New Xml.XmlDocument, v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
        Dim v_strVALEXP, v_strVALUE, v_strFLDNAME, v_strDEFNAME, v_strFLDTYPE As String
        Dim v_attrFLDNAME, v_attrDATATYPE As Xml.XmlAttribute
        Dim v_strTLTXCD, v_strORGORDERID As String, v_dblFEEAMT, v_dblFeeTemp, v_dblAVLFEEAMT, v_dblAVLRCVAMT, v_dblVATRATE As Double
        Dim v_str8856Desc, v_str8856EN_Desc, v_str8866Desc, v_str8866EN_Desc, v_str8868Desc, v_str8868EN_Desc As String
        Dim v_blnVietnamese As Boolean 'Yes/No
        Dim v_strRCVMDAY As String
        Try
            'LÃ¡ÂºÂ¥y giÃƒÂ¡ trÃ¡Â»â€¹ cÃ¡Â»Â±c Ã„â€˜Ã¡ÂºÂ¡i trÃ¡ÂºÂ£ vÃ¡Â»? trong phÃƒÂ¢n trang
            v_strSQL = "SELECT COUNT(*) MAXROW FROM  STSCHD"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            v_intMaxRow = v_ds.Tables(0).Rows(0)("MAXROW")
            'LÃ¡ÂºÂ¥y tham sÃ¡Â»â€˜ hÃ¡Â»â€¡ thÃ¡Â»â€˜ng
            Dim v_strSYSVAR, v_strCURRDATE, v_strPREVDATE, v_strNEXTDATE As String
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "CURRDATE", v_strCURRDATE)
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "PREVDATE", v_strPREVDATE)
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "NEXTDATE", v_strNEXTDATE)
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "RCVMDAY", v_strRCVMDAY)
            If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode

            'Lay ra cac dien giai mac dinh cho cac giao dich
            'Dien giai 8856
            v_strSQL = "SELECT TXDESC,EN_TXDESC FROM  TLTX WHERE TLTXCD='" & gc_OD_BATCH_CIRECEIVE_FEE & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            v_str8856Desc = v_ds.Tables(0).Rows(0)("TXDESC")
            v_str8856EN_Desc = v_ds.Tables(0).Rows(0)("EN_TXDESC")

            Dim v_strCond As String
            If v_strBATCHNAME = "ODPAIDSF" Then
                v_strCond = "AND MST.CLEARDAY <> " & v_strRCVMDAY & " "
            ElseIf v_strBATCHNAME = "ODPAIDSFT3" Then
                v_strCond = "AND MST.CLEARDAY = " & v_strRCVMDAY & " "
            End If

            v_strSQL = "SELECT SUBSTR(MAX(CUSTODYCD),4,1) CUSTODYCD,MAX(COSTPRICE) COSTPRICE , CLR2.SBDATE, TO_DATE('" & v_strCURRDATE & "','" & gc_FORMAT_DATE & "') CURRDATE, " & ControlChars.CrLf _
                & "SUM(CASE WHEN CLR1.HOLIDAY='Y' THEN 0 ELSE 1 END) WITHHOLIDAY,  " & ControlChars.CrLf _
                & "SUM(CASE WHEN CLR1.HOLIDAY='Y' THEN 1 ELSE 1 END) WITHOUTHOLIDAY, " & ControlChars.CrLf _
                & "MST.AUTOID, MST.AFACCTNO,MAX(ODMST.ORDERQTTY) ORGORDERQTTY,MAX(ODMST.EXECTYPE) EXECTYPE,MAX(ODMST.QUOTEPRICE) ORGQUOTEPRICE, MST.ACCTNO, MIN(MST.DUETYPE) DUETYPE, MIN(MST.TXDATE) TXDATE, MIN(MST.ORGORDERID) ORGORDERID, MIN(MST.CLEARCD) CLEARCD, MIN(MST.CLEARDAY) CLEARDAY, " & ControlChars.CrLf _
                & "MIN(SEC.CODEID) CODEID, MIN(SEC.SYMBOL) SYMBOL, MIN(SEC.PARVALUE) PARVALUE, MIN(TYP.VATRATE) VATRATE, MIN(ODMST.FEEACR-ODMST.FEEAMT) AVLFEEAMT, " & ControlChars.CrLf _
                & "MIN(MST.AMT) AMT, MIN(MST.AAMT) AAMT, MIN(MST.FAMT) FAMT, MIN(MST.QTTY) QTTY,MIN(ODMST.EXECQTTY) SQTTY , MIN(MST.AQTTY) AQTTY, ROUND(MIN(MST.AMT/MST.QTTY),4) MATCHPRICE " & ControlChars.CrLf _
                & "FROM SBCLDR CLR1, SBCLDR CLR2, (SELECT MOD.* FROM (SELECT ROWNUM INDEXROW,STSCHD.* FROM STSCHD) MOD WHERE 0=0 " & v_strBCHFillter & ") MST, ODMAST ODMST,AFMAST AF,CFMAST CF, ODTYPE TYP, SBSECURITIES SEC " & ControlChars.CrLf _
                & "WHERE ODMST.AFACCTNO=AF.ACCTNO AND AF.CUSTID=CF.CUSTID AND CLR1.SBDATE>=MST.TXDATE AND CLR1.SBDATE<CLR2.SBDATE AND CLR2.SBDATE>=MST.TXDATE " & ControlChars.CrLf _
                & "AND CLR1.CLDRTYPE=SEC.TRADEPLACE AND CLR2.CLDRTYPE=SEC.TRADEPLACE " & ControlChars.CrLf _
                & "AND ODMST.ACTYPE=TYP.ACTYPE AND MST.ORGORDERID=ODMST.ORDERID AND MST.CODEID=SEC.CODEID AND SEC.TRADEPLACE <> '" & gc_TRADEPLACE_OTc & "' " & ControlChars.CrLf _
                & "AND CLR2.SBDATE=TO_DATE('" & v_strCURRDATE & "','" & gc_FORMAT_DATE & "') AND ODMST.FEEACR>ODMST.FEEAMT AND MST.DELTD<>'Y' " & ControlChars.CrLf _
                & "AND (MST.DUETYPE='RM') " & ControlChars.CrLf _
                & v_strCond & ControlChars.CrLf _
                & "GROUP BY MST.AUTOID, CLR2.SBDATE, MST.AFACCTNO, MST.ACCTNO " & ControlChars.CrLf _
                & "HAVING MIN(MST.CLEARDAY)<= " & ControlChars.CrLf _
                & "(CASE WHEN MIN(MST.CLEARCD)='B' THEN SUM(CASE WHEN CLR1.HOLIDAY='Y' THEN 0 ELSE 1 END) ELSE SUM(CASE WHEN CLR1.HOLIDAY='Y' THEN 1 ELSE 1 END) END)  " & ControlChars.CrLf _
                & "ORDER BY ORGORDERID"             'ThÃ¡Â»Â© tÃ¡Â»Â± ORDER BY lÃƒÂ  quan trÃ¡Â»?ng
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

            If v_ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To v_ds.Tables(0).Rows.Count - 1 Step 1
                    If v_ds.Tables(0).Rows(i)("CUSTODYCD") = "F" Then
                        v_blnVietnamese = False
                    Else
                        v_blnVietnamese = True
                    End If

                    If v_strORGORDERID <> Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("ORGORDERID"))) Then
                        v_strORGORDERID = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("ORGORDERID")))
                        v_dblAVLFEEAMT = gf_CorrectNumericField(v_ds.Tables(0).Rows(i)("AVLFEEAMT"))
                    End If
                    v_dblAVLRCVAMT = gf_CorrectNumericField(v_ds.Tables(0).Rows(i)("AMT"))
                    v_dblVATRATE = gf_CorrectNumericField(v_ds.Tables(0).Rows(i)("VATRATE"))

                    If Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("DUETYPE"))) = "RM" Then
                        If v_dblAVLFEEAMT <= v_dblAVLRCVAMT Then
                            v_dblFeeTemp = v_dblAVLFEEAMT
                        Else
                            v_dblFeeTemp = v_dblAVLRCVAMT
                        End If
                        If v_dblFeeTemp > 0 Then
                            'Giao Phi
                            v_lngErrCode = BuildBatchTxMsg(v_xmlDocument, v_strBATCHNAME)

                            v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value = gc_OD_BATCH_CIRECEIVE_FEE

                            v_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("AFACCTNO")).Substring(0, 4)
                            v_strTLTXCD = v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value
                            'Nap giao dich
                            v_strSQL = "SELECT FLDNAME, FLDTYPE, DEFNAME FROM FLDMASTER WHERE OBJNAME='" & Trim(v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value) & "' ORDER BY ODRNUM"
                            v_dsTLLOG = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

                            If v_dsTLLOG.Tables(0).Rows.Count > 0 Then
                                v_dataElement = v_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "fields", "")

                                'Create transaction contents
                                For j = 0 To v_dsTLLOG.Tables(0).Rows.Count - 1 Step 1
                                    v_strDEFNAME = Trim(gf_CorrectStringField(v_dsTLLOG.Tables(0).Rows(j)("DEFNAME")))
                                    v_strFLDNAME = Trim(gf_CorrectStringField(v_dsTLLOG.Tables(0).Rows(j)("FLDNAME")))
                                    v_strFLDTYPE = Trim(gf_CorrectStringField(v_dsTLLOG.Tables(0).Rows(j)("FLDTYPE")))

                                    v_entryNode = v_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "entry", "")
                                    'Add field name
                                    v_attrFLDNAME = v_xmlDocument.CreateAttribute(gc_AtributeFLDNAME)
                                    v_attrFLDNAME.Value = v_strFLDNAME
                                    v_entryNode.Attributes.Append(v_attrFLDNAME)

                                    'Add field type
                                    v_attrDATATYPE = v_xmlDocument.CreateAttribute(gc_AtributeFLDTYPE)
                                    v_attrDATATYPE.Value = v_strFLDTYPE
                                    v_entryNode.Attributes.Append(v_attrDATATYPE)

                                    'Set value
                                    Select Case v_strFLDNAME
                                        Case "01" 'AUTOID
                                            v_strVALUE = v_ds.Tables(0).Rows(i).Item("AUTOID")
                                        Case "03" 'ORGORDERID
                                            v_strVALUE = v_ds.Tables(0).Rows(i).Item("ORGORDERID")
                                        Case "04" 'AFACCTNO
                                            v_strVALUE = v_ds.Tables(0).Rows(i).Item("AFACCTNO")
                                        Case "05" 'CIACCTNO
                                            v_strVALUE = v_ds.Tables(0).Rows(i).Item("ACCTNO")
                                        Case "06" 'SEACCTNO
                                            v_strVALUE = v_ds.Tables(0).Rows(i).Item("AFACCTNO") & v_ds.Tables(0).Rows(i).Item("CODEID")
                                        Case "07" 'SYMBOL
                                            v_strVALUE = v_ds.Tables(0).Rows(i).Item("SYMBOL")
                                        Case "08" 'AMT
                                            v_strVALUE = 0
                                        Case "09" 'QTTY
                                            v_strVALUE = v_ds.Tables(0).Rows(i).Item("QTTY")
                                        Case "10" 'AMT
                                            v_strVALUE = 0

                                        Case "11" 'AAMT
                                            v_strVALUE = 0

                                        Case "12" 'FEEAMT
                                            If v_dblAVLFEEAMT <= v_dblAVLRCVAMT Then
                                                v_dblFEEAMT = v_dblAVLFEEAMT
                                                v_dblAVLFEEAMT = 0
                                            Else
                                                v_dblFEEAMT = v_dblAVLRCVAMT
                                                v_dblAVLFEEAMT = v_dblAVLFEEAMT - v_dblAVLRCVAMT
                                            End If
                                            v_strVALUE = v_dblFEEAMT

                                        Case "13" 'VAT
                                            v_strVALUE = v_dblVATRATE * v_dblFEEAMT
                                        Case "30" 'DESC                                              
                                            If v_blnVietnamese = True Then
                                                'nGUOI VIET
                                                v_strVALUE = v_str8856Desc & " " & v_ds.Tables(0).Rows(i).Item("SQTTY") & " " & v_ds.Tables(0).Rows(i).Item("SYMBOL") & " " & Strings.Mid(v_ds.Tables(0).Rows(i).Item("ORGORDERID"), 5, 2) & "/" & Strings.Mid(v_ds.Tables(0).Rows(i).Item("ORGORDERID"), 7, 2) & "/" & Strings.Mid(v_ds.Tables(0).Rows(i).Item("ORGORDERID"), 9, 2)
                                            Else
                                                'NGUOI ANH
                                                v_strVALUE = v_str8856EN_Desc & " " & v_ds.Tables(0).Rows(i).Item("SQTTY") & " " & v_ds.Tables(0).Rows(i).Item("SYMBOL") & " " & Strings.Mid(v_ds.Tables(0).Rows(i).Item("ORGORDERID"), 5, 2) & "/" & Strings.Mid(v_ds.Tables(0).Rows(i).Item("ORGORDERID"), 7, 2) & "/" & Strings.Mid(v_ds.Tables(0).Rows(i).Item("ORGORDERID"), 9, 2)
                                            End If
                                        Case "44" 'PARVALUE
                                            v_strVALUE = v_ds.Tables(0).Rows(i).Item("PARVALUE")
                                        Case "53" 'MICD
                                            v_strVALUE = "53"
                                        Case "60" 'Is mortage
                                            v_strVALUE = IIf(v_ds.Tables(0).Rows(i).Item("EXECTYPE") = "MS", "1", "0")
                                    End Select
                                    v_entryNode.InnerText = v_strVALUE

                                    v_dataElement.AppendChild(v_entryNode)
                                Next

                                v_xmlDocument.DocumentElement.AppendChild(v_dataElement)
                                'Ghi nhÃ¡ÂºÂ­n giao dÃ¡Â»â€¹ch vÃƒÂ o TLLOG
                                v_lngErrCode = v_objMessageLog.TransLog(v_xmlDocument)

                                If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode
                            End If
                        End If

                    End If
                Next
            End If

            'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function


    Private Function ODBuyFee(ByVal v_strBATCHNAME As String, Optional ByVal v_strBCHFillter As String = "", Optional ByRef v_intMaxRow As Integer = 0) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = ATTR_MODULE & ".Batch.ODSettlementTransfer", v_strErrorMessage As String
        Dim v_strSQL As String, v_ds, v_dsTLLOG, v_dsCNT As DataSet, v_objMessageLog As New MessageLog
        v_objMessageLog.NewDBInstance(gc_MODULE_HOST)
        Dim v_obj As New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)
        Dim i, j As Integer, v_strFRTABLE, v_strTOTABLE As String
        Dim v_xmlDocument As New Xml.XmlDocument, v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
        Dim v_strVALEXP, v_strVALUE, v_strFLDNAME, v_strDEFNAME, v_strFLDTYPE As String
        Dim v_attrFLDNAME, v_attrDATATYPE As Xml.XmlAttribute
        Dim v_strTLTXCD As String
        Dim v_str8855Desc, v_str8865Desc, v_str8867Desc, v_str8855ENDesc, v_str8865ENDesc, v_str8867ENDesc As String
        Dim v_blnVietnamese As Boolean 'Yes/No
        Try
            'LÃ¡ÂºÂ¥y giÃƒÂ¡ trÃ¡Â»â€¹ cÃ¡Â»Â±c Ã„â€˜Ã¡ÂºÂ¡i trÃ¡ÂºÂ£ vÃ¡Â»? trong phÃƒÂ¢n trang
            'v_strSQL = "SELECT COUNT(*) MAXROW FROM  STSCHD"
            v_strSQL = "SELECT COUNT(1) MAXROW FROM  ODMAST"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            v_intMaxRow = v_ds.Tables(0).Rows(0)("MAXROW")
            'LÃ¡ÂºÂ¥y tham sÃ¡Â»â€˜ hÃ¡Â»â€¡ thÃ¡Â»â€˜ng
            Dim v_strSYSVAR, v_strCURRDATE, v_strPREVDATE, v_strNEXTDATE As String
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "CURRDATE", v_strCURRDATE)
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "PREVDATE", v_strPREVDATE)
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "NEXTDATE", v_strNEXTDATE)
            If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode

            Dim v_dblOrderTradingFee, v_dblCIAvailable, v_dblCIBAmt, v_dblCIODAmt, v_dblCISecuredAmt,
                v_dblODSecuredAmt, v_dblODRlsSecured, v_dblODFeeAmt, v_dblODFeeAcr, v_dblFeeRate, v_dblVatRate, v_dblPARVALUE As Double
            Dim v_strOrgOrderID, v_strCodeID, v_strAFAcctno, v_strCIAcctno As String

            'Lay ra cac dien giai mac dinh cho cac giao dich
            'Dien giai 8855
            v_strSQL = "SELECT TXDESC,EN_TXDESC FROM  TLTX WHERE TLTXCD='" & gc_OD_BATCH_CISEND_FEE & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            v_str8855Desc = v_ds.Tables(0).Rows(0)("TXDESC")
            v_str8855ENDesc = v_ds.Tables(0).Rows(0)("EN_TXDESC")

            '1. XÃ¡Â»Â­ lÃƒÂ½ thanh toÃƒÂ¡n bÃƒÂ¹ trÃ¡Â»Â« tÃ¡Â»Â± Ã„â€˜Ã¡Â»â„¢ng theo lÃ¡Â»â€¹ch STSCHD: T+0: 
            '------------------------------------------------------------------------------------------------------------------------------------
            '1.1 Giao tiÃ¡Â»?n Ã„â€˜Ã¡Â»â€˜i vÃ¡Â»â€ºi cÃƒÂ¡c lÃ¡Â»â€¡nh khÃƒÂ´ng phÃ¡ÂºÂ£i OTC
            v_strSQL = " SELECT SUBSTR(CF.CUSTODYCD,4,1) CUSTODYCD, MST.TXDATE, MST.ORDERID ORGORDERID,MST.AFACCTNO, CI.ACCTNO CIACCTNO, " & ControlChars.CrLf _
                    & " MST.FEEAMT, MST.ORDERQTTY ORGORDERQTTY, MST.QUOTEPRICE ORGQUOTEPRICE, MST.FEEACR, TYP.FEERATE, TYP.VATRATE, SEC.PARVALUE, SEC.CODEID, " & ControlChars.CrLf _
                    & " MST.SECUREDAMT, MST.RLSSECURED, SEC.SYMBOL,MST.EXECQTTY SQTTY " & ControlChars.CrLf _
                    & " FROM (SELECT MOD.* FROM (SELECT ROWNUM INDEXROW,ODMAST.* FROM ODMAST) MOD WHERE 0=0 " & v_strBCHFillter & ") MST,SBSECURITIES SEC, AFMAST AF,CFMAST CF, CIMAST CI,  ODTYPE TYP " & ControlChars.CrLf _
                    & " WHERE AF.CUSTID=CF.CUSTID AND MST.CODEID=SEC.CODEID AND SEC.TRADEPLACE <> '" & gc_TRADEPLACE_OTc & "' " & ControlChars.CrLf _
                    & " AND MST.FEEACR>MST.FEEAMT AND MST.DELTD<>'Y' " & ControlChars.CrLf _
                    & " AND MST.AFACCTNO=AF.ACCTNO AND AF.ACCTNO=CI.ACCTNO AND MST.ACTYPE=TYP.ACTYPE AND FEEACR>FEEAMT AND MST.EXECTYPE IN ('NB','BC')" & ControlChars.CrLf _
                    & " ORDER BY CIACCTNO, MST.ORDERID " & ControlChars.CrLf
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To v_ds.Tables(0).Rows.Count - 1 Step 1
                    If v_ds.Tables(0).Rows(i)("CUSTODYCD") = "F" Then
                        v_blnVietnamese = False
                    Else
                        v_blnVietnamese = True
                    End If

                    v_strCodeID = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("CODEID")))
                    v_strAFAcctno = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("AFACCTNO")))
                    v_dblFeeRate = gf_CorrectNumericField(v_ds.Tables(0).Rows(i)("FEERATE"))
                    v_dblVatRate = gf_CorrectNumericField(v_ds.Tables(0).Rows(i)("VATRATE")) / 100
                    v_dblPARVALUE = gf_CorrectNumericField(v_ds.Tables(0).Rows(i)("PARVALUE"))
                    v_strOrgOrderID = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("ORGORDERID")))
                    v_strCIAcctno = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("CIACCTNO")))

                    v_dblODFeeAmt = gf_CorrectNumericField(v_ds.Tables(0).Rows(i)("FEEAMT"))
                    v_dblODFeeAcr = gf_CorrectNumericField(v_ds.Tables(0).Rows(i)("FEEACR"))
                    v_dblOrderTradingFee = IIf(v_dblODFeeAcr - v_dblODFeeAmt > 0, v_dblODFeeAcr - v_dblODFeeAmt, 0)

                    If v_dblOrderTradingFee > 0 Then
                        'Fee payment
                        v_lngErrCode = BuildBatchTxMsg(v_xmlDocument, v_strBATCHNAME)
                        v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value = gc_OD_BATCH_CISEND_FEE
                        v_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value = v_strAFAcctno.Substring(0, 4)
                        v_strTLTXCD = v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value

                        'Filling Transaction
                        v_strSQL = "SELECT FLDNAME, FLDTYPE, DEFNAME FROM FLDMASTER " & ControlChars.CrLf _
                            & "WHERE OBJNAME='" & Trim(v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value) & "' ORDER BY ODRNUM" 'ThÃ¡Â»Â© tÃ¡Â»Â± ODRER BY lÃƒÂ  quan trÃ¡Â»?ng
                        v_dsTLLOG = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

                        If v_dsTLLOG.Tables(0).Rows.Count > 0 Then
                            v_dataElement = v_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "fields", "")

                            'Create Transaction contents
                            For j = 0 To v_dsTLLOG.Tables(0).Rows.Count - 1 Step 1
                                v_strDEFNAME = Trim(gf_CorrectStringField(v_dsTLLOG.Tables(0).Rows(j)("DEFNAME")))
                                v_strFLDNAME = Trim(gf_CorrectStringField(v_dsTLLOG.Tables(0).Rows(j)("FLDNAME")))
                                v_strFLDTYPE = Trim(gf_CorrectStringField(v_dsTLLOG.Tables(0).Rows(j)("FLDTYPE")))

                                v_entryNode = v_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "entry", "")
                                'Add field name
                                v_attrFLDNAME = v_xmlDocument.CreateAttribute(gc_AtributeFLDNAME)
                                v_attrFLDNAME.Value = v_strFLDNAME
                                v_entryNode.Attributes.Append(v_attrFLDNAME)

                                'Add field type
                                v_attrDATATYPE = v_xmlDocument.CreateAttribute(gc_AtributeFLDTYPE)
                                v_attrDATATYPE.Value = v_strFLDTYPE
                                v_entryNode.Attributes.Append(v_attrDATATYPE)

                                'Set value
                                Select Case v_strFLDNAME
                                    'Case "01" 'AUTOID
                                    '    v_strVALUE = v_ds.Tables(0).Rows(i).Item("AUTOID")
                                    Case "03" 'ORGORDERID
                                        v_strVALUE = v_strOrgOrderID
                                    Case "04" 'AFACCTNO
                                        v_strVALUE = v_strAFAcctno
                                    Case "05" 'CIACCTNO
                                        v_strVALUE = v_strCIAcctno
                                    Case "06" 'SEACCTNO
                                        v_strVALUE = v_strAFAcctno & v_strCodeID
                                    Case "07" 'CODEID
                                        v_strVALUE = v_strCodeID

                                    Case "12" 'FEEAMT
                                        'Phi giao dich phai giao di
                                        v_strVALUE = v_dblOrderTradingFee
                                    Case "13" 'VATAMT
                                        'So tien VAT
                                        v_strVALUE = v_dblVatRate * v_dblOrderTradingFee
                                        'Case "14" 'CRSECUREDAMT
                                        '    v_strVALUE = v_dblCIODAmt
                                    Case "30" 'DESC                                              
                                        If v_blnVietnamese = True Then
                                            'nGUOI VIET
                                            v_strVALUE = v_str8855Desc & " " & v_ds.Tables(0).Rows(i).Item("SQTTY") & " " & v_ds.Tables(0).Rows(i).Item("SYMBOL") & " " & Strings.Mid(v_strOrgOrderID, 5, 2) & "/" & Strings.Mid(v_strOrgOrderID, 7, 2) & "/" & Strings.Mid(v_strOrgOrderID, 9, 2)
                                        Else
                                            'NGUOI ANH
                                            v_strVALUE = v_str8855ENDesc & " " & v_ds.Tables(0).Rows(i).Item("SQTTY") & " " & v_ds.Tables(0).Rows(i).Item("SYMBOL") & " " & Strings.Mid(v_strOrgOrderID, 5, 2) & "/" & Strings.Mid(v_strOrgOrderID, 7, 2) & "/" & Strings.Mid(v_strOrgOrderID, 9, 2)
                                        End If
                                    Case "44" 'PARVALUE
                                        v_strVALUE = v_dblPARVALUE
                                End Select
                                v_entryNode.InnerText = v_strVALUE

                                v_dataElement.AppendChild(v_entryNode)
                            Next

                            v_xmlDocument.DocumentElement.AppendChild(v_dataElement)
                            'Ghi nhÃ¡ÂºÂ­n giao dÃ¡Â»â€¹ch vÃƒÂ o TLLOG
                            v_lngErrCode = v_objMessageLog.TransLog(v_xmlDocument)

                            If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode
                        End If
                    End If
                Next
            End If
            'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function


    Private Function ODSettlementTransferSec(ByVal v_strBATCHNAME As String, Optional ByVal v_strBCHFillter As String = "", Optional ByRef v_intMaxRow As Integer = 0) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = ATTR_MODULE & ".Batch.ODSettlementTransferSec", v_strErrorMessage As String
        Dim v_strSQL As String, v_ds, v_dsTLLOG, v_dsCNT As DataSet, v_objMessageLog As New MessageLog
        v_objMessageLog.NewDBInstance(gc_MODULE_HOST)
        Dim v_obj As New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)
        Dim i, j As Integer, v_strFRTABLE, v_strTOTABLE As String
        Dim v_xmlDocument As New Xml.XmlDocument, v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
        Dim v_strVALEXP, v_strVALUE, v_strFLDNAME, v_strDEFNAME, v_strFLDTYPE As String
        Dim v_attrFLDNAME, v_attrDATATYPE As Xml.XmlAttribute
        Dim v_strTLTXCD As String
        Dim v_str8867Desc, v_str8867ENDesc As String
        Dim v_blnVietnamese As Boolean 'Yes/No
        Dim v_strOrgOrderID, v_strCodeID, v_strAFAcctno, v_strCIAcctno As String
        Dim v_dblPARVALUE As Double
        Try
            'Xac dinh so dong de phan trang
            v_strSQL = "SELECT COUNT(*) MAXROW FROM  STSCHD"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            v_intMaxRow = v_ds.Tables(0).Rows(0)("MAXROW")
            'Lay ngay he thong
            Dim v_strSYSVAR, v_strCURRDATE, v_strPREVDATE, v_strNEXTDATE As String
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "CURRDATE", v_strCURRDATE)
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "PREVDATE", v_strPREVDATE)
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "NEXTDATE", v_strNEXTDATE)
            If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode
            'Dien giai 8867
            v_strSQL = "SELECT TXDESC,EN_TXDESC FROM  TLTX WHERE TLTXCD='" & gc_OD_BATCH_SESENd & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            v_str8867Desc = v_ds.Tables(0).Rows(0)("TXDESC")
            v_str8867ENDesc = v_ds.Tables(0).Rows(0)("EN_TXDESC")

            '1.2 Giao chung khoan lenh ban niem yet
            v_strSQL = "SELECT SUBSTR(CF.CUSTODYCD,4,1) CUSTODYCD, MST.AUTOID, MST.DUETYPE, MST.TXDATE, MST.ORGORDERID, MST.CLEARCD, MST.CLEARDAY, " & ControlChars.CrLf _
                & "MST.AFACCTNO, OD.ORDERQTTY ORGORDERQTTY, OD.QUOTEPRICE ORGQUOTEPRICE, MST.ACCTNO, SEC.PARVALUE, SEC.SYMBOL, SEC.CODEID, MST.AMT, MST.AAMT, MST.FAMT, MST.QTTY,OD.EXECQTTY SQTTY,OD.EXECTYPE, MST.AQTTY" & ControlChars.CrLf _
                & "FROM (SELECT MOD.* FROM (SELECT ROWNUM INDEXROW,STSCHD.* FROM STSCHD) MOD WHERE 0=0 " & v_strBCHFillter & ") MST, SBSECURITIES SEC,ODMAST OD, AFMAST AF, CFMAST CF " & ControlChars.CrLf _
                & "WHERE OD.AFACCTNO =AF.ACCTNO AND AF.CUSTID=CF.CUSTID AND MST.CODEID=SEC.CODEID AND MST.ORGORDERID=OD.ORDERID AND SEC.TRADEPLACE <> '" & gc_TRADEPLACE_OTc & "' " & ControlChars.CrLf _
                & "AND MST.DUETYPE='SS' AND MST.STATUS='N' AND MST.DELTD<>'Y' " & ControlChars.CrLf _
                & "ORDER BY ORGORDERID, DUETYPE"  'ThÃ¡Â»Â© tÃ¡Â»Â± ORDER BY lÃƒÂ  quan trÃ¡Â»?ng
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To v_ds.Tables(0).Rows.Count - 1 Step 1
                    If v_ds.Tables(0).Rows(i)("CUSTODYCD") = "F" Then
                        v_blnVietnamese = False
                    Else
                        v_blnVietnamese = True
                    End If

                    v_lngErrCode = BuildBatchTxMsg(v_xmlDocument, v_strBATCHNAME)
                    v_strOrgOrderID = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("ORGORDERID")))
                    v_strCodeID = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("CODEID")))
                    v_strAFAcctno = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("AFACCTNO")))
                    v_dblPARVALUE = gf_CorrectNumericField(v_ds.Tables(0).Rows(i)("PARVALUE"))
                    'Giao chÃ¡Â»Â©ng khoÃƒÂ¡n
                    v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value = gc_OD_BATCH_SESENd
                    'Modified by MinhTK, 17-Apr-07: Khach hang cua chi nhanh nao thi GD phai thuoc chi nhanh do
                    v_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value = v_strAFAcctno.Substring(0, 4)
                    'End of modified by MinhTK, 7-Apr-07
                    v_strTLTXCD = v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value

                    'NÃ¡ÂºÂ¡p giao dÃ¡Â»â€¹ch
                    v_strSQL = "SELECT FLDNAME, FLDTYPE, DEFNAME FROM FLDMASTER " & ControlChars.CrLf _
                        & "WHERE OBJNAME='" & Trim(v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value) & "' ORDER BY ODRNUM" 'ThÃ¡Â»Â© tÃ¡Â»Â± ODRER BY lÃƒÂ  quan trÃ¡Â»?ng
                    v_dsTLLOG = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

                    If v_dsTLLOG.Tables(0).Rows.Count > 0 Then
                        v_dataElement = v_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "fields", "")

                        'TÃ¡ÂºÂ¡o phÃ¡ÂºÂ§n nÃ¡Â»â„¢i dung cÃ¡Â»Â§a giao dÃ¡Â»â€¹ch
                        For j = 0 To v_dsTLLOG.Tables(0).Rows.Count - 1 Step 1
                            v_strDEFNAME = Trim(gf_CorrectStringField(v_dsTLLOG.Tables(0).Rows(j)("DEFNAME")))
                            v_strFLDNAME = Trim(gf_CorrectStringField(v_dsTLLOG.Tables(0).Rows(j)("FLDNAME")))
                            v_strFLDTYPE = Trim(gf_CorrectStringField(v_dsTLLOG.Tables(0).Rows(j)("FLDTYPE")))

                            v_entryNode = v_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "entry", "")
                            'Add field name
                            v_attrFLDNAME = v_xmlDocument.CreateAttribute(gc_AtributeFLDNAME)
                            v_attrFLDNAME.Value = v_strFLDNAME
                            v_entryNode.Attributes.Append(v_attrFLDNAME)

                            'Add field type
                            v_attrDATATYPE = v_xmlDocument.CreateAttribute(gc_AtributeFLDTYPE)
                            v_attrDATATYPE.Value = v_strFLDTYPE
                            v_entryNode.Attributes.Append(v_attrDATATYPE)

                            'Set value
                            Select Case v_strFLDNAME
                                Case "01" 'AUTOID
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("AUTOID")
                                Case "03" 'ORGORDERID
                                    v_strVALUE = v_strOrgOrderID
                                Case "04" 'AFACCTNO
                                    v_strVALUE = v_strAFAcctno
                                Case "06" 'SEACCTNO
                                    v_strVALUE = v_strAFAcctno & v_strCodeID
                                Case "07" 'CODEID
                                    v_strVALUE = v_strCodeID
                                Case "08" 'AMT
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("AMT")
                                Case "09" 'QTTY
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("QTTY")
                                    'Case "10" 'SECUREDAMT
                                    '    'SÃ¡Â»â€˜ chÃ¡Â»Â©ng khoÃƒÂ¡n Ã„â€˜ÃƒÂ£ kÃƒÂ½ quÃ¡Â»Â¹
                                    '    v_strVALUE = v_ds.Tables(0).Rows(i).Item("QTTY")
                                Case "10" 'PARVALUE
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("PARVALUE")
                                Case "11" 'TRFAMT: SÃ¡Â»â€˜ tiÃ¡Â»?n chÃ¡Â»Â©ng khoÃƒÂ¡n phÃ¡ÂºÂ£i giao
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("QTTY")
                                Case "30" 'DESC                                              
                                    If v_blnVietnamese = True Then
                                        'nGUOI VIET
                                        v_strVALUE = v_str8867Desc & " " & v_ds.Tables(0).Rows(i).Item("SQTTY") & " " & v_ds.Tables(0).Rows(i).Item("SYMBOL") & " " & Strings.Mid(v_strOrgOrderID, 5, 2) & "/" & Strings.Mid(v_strOrgOrderID, 7, 2) & "/" & Strings.Mid(v_strOrgOrderID, 9, 2)
                                    Else
                                        'NGUOI ANH
                                        v_strVALUE = v_str8867ENDesc & " " & v_ds.Tables(0).Rows(i).Item("SQTTY") & " " & v_ds.Tables(0).Rows(i).Item("SYMBOL") & " " & Strings.Mid(v_strOrgOrderID, 5, 2) & "/" & Strings.Mid(v_strOrgOrderID, 7, 2) & "/" & Strings.Mid(v_strOrgOrderID, 9, 2)
                                    End If
                                Case "44" 'PARVALUE
                                    v_strVALUE = v_dblPARVALUE
                                Case "60" 'Is Mortage
                                    v_strVALUE = IIf(v_ds.Tables(0).Rows(i).Item("EXECTYPE") = "MS", "1", "0")
                            End Select
                            v_entryNode.InnerText = v_strVALUE

                            v_dataElement.AppendChild(v_entryNode)
                        Next

                        v_xmlDocument.DocumentElement.AppendChild(v_dataElement)
                        'Ghi nhÃ¡ÂºÂ­n giao dÃ¡Â»â€¹ch vÃƒÂ o TLLOG
                        v_lngErrCode = v_objMessageLog.TransLog(v_xmlDocument)

                        If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode
                    End If

                Next
            End If

            'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function ODSettlementTransferMoney(ByVal v_strBATCHNAME As String, Optional ByVal v_strBCHFillter As String = "", Optional ByRef v_intMaxRow As Integer = 0) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = ATTR_MODULE & ".Batch.ODSettlementTransfer", v_strErrorMessage As String
        Dim v_strSQL As String, v_ds, v_dsTLLOG, v_dsCNT As DataSet, v_objMessageLog As New MessageLog
        v_objMessageLog.NewDBInstance(gc_MODULE_HOST)
        Dim v_obj As New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)
        Dim i, j As Integer, v_strFRTABLE, v_strTOTABLE As String
        Dim v_xmlDocument As New Xml.XmlDocument, v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
        Dim v_strVALEXP, v_strVALUE, v_strFLDNAME, v_strDEFNAME, v_strFLDTYPE As String
        Dim v_attrFLDNAME, v_attrDATATYPE As Xml.XmlAttribute
        Dim v_strTLTXCD As String
        Dim v_str8865Desc, v_str8865ENDesc As String
        Dim v_blnVietnamese As Boolean 'Yes/No
        Try
            'Xac dinh so dong de phan trang
            v_strSQL = "SELECT COUNT(*) MAXROW FROM  STSCHD"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            v_intMaxRow = v_ds.Tables(0).Rows(0)("MAXROW")
            'Lay ngay he thong
            Dim v_strSYSVAR, v_strCURRDATE, v_strPREVDATE, v_strNEXTDATE As String
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "CURRDATE", v_strCURRDATE)
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "PREVDATE", v_strPREVDATE)
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "NEXTDATE", v_strNEXTDATE)
            If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode

            Dim v_dblOrderTradingFee, v_dblCIAvailable, v_dblCIBAmt, v_dblCIODAmt, v_dblCISecuredAmt,
                v_dblODSecuredAmt, v_dblODRlsSecured, v_dblODFeeAmt, v_dblODFeeAcr, v_dblFeeRate, v_dblVatRate, v_dblPARVALUE As Double
            Dim v_strOrgOrderID, v_strCodeID, v_strAFAcctno, v_strCIAcctno As String

            'Lay ra cac dien giai mac dinh cho cac giao dich
            'Dien giai 8865
            v_strSQL = "SELECT TXDESC,EN_TXDESC FROM  TLTX WHERE TLTXCD='" & gc_OD_BATCH_CISENd & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            v_str8865Desc = v_ds.Tables(0).Rows(0)("TXDESC")
            v_str8865ENDesc = v_ds.Tables(0).Rows(0)("EN_TXDESC")

            '1. XÃ¡Â»Â­ lÃƒÂ½ thanh toÃƒÂ¡n bÃƒÂ¹ trÃ¡Â»Â« tÃ¡Â»Â± Ã„â€˜Ã¡Â»â„¢ng theo lÃ¡Â»â€¹ch STSCHD: T+0: 
            '------------------------------------------------------------------------------------------------------------------------------------
            '1.1 Giao tiÃ¡Â»?n Ã„â€˜Ã¡Â»â€˜i vÃ¡Â»â€ºi cÃƒÂ¡c lÃ¡Â»â€¡nh khÃƒÂ´ng phÃ¡ÂºÂ£i OTC
            v_strSQL = "SELECT SUBSTR(CUSTODYCD,4,1) CUSTODYCD, MST.AUTOID, MST.DUETYPE, MST.TXDATE, MST.ORGORDERID, MST.CLEARCD, MST.CLEARDAY, " & ControlChars.CrLf _
                & "MST.AFACCTNO, MST.ACCTNO, CI.ACCTNO CIACCTNO, ROUND(CI.BALANCE,4) CIBALANCE, ROUND(CI.BAMT,4) CIBAMT, " & ControlChars.CrLf _
                & "OD.FEEAMT, OD.ORDERQTTY ORGORDERQTTY, OD.QUOTEPRICE ORGQUOTEPRICE, OD.FEEACR, TYP.FEERATE, TYP.VATRATE, SEC.PARVALUE, SEC.CODEID, " & ControlChars.CrLf _
                & "OD.SECUREDAMT, OD.RLSSECURED, SEC.SYMBOL, MST.AMT, MST.AAMT, MST.FAMT, MST.QTTY ,OD.EXECQTTY SQTTY , MST.AQTTY" & ControlChars.CrLf _
                & "FROM (SELECT MOD.* FROM (SELECT ROWNUM INDEXROW,STSCHD.* FROM STSCHD) MOD WHERE 0=0 " & v_strBCHFillter & ") MST, SBSECURITIES SEC, AFMAST AF, CIMAST CI,CFMAST CF, ODMAST OD, ODTYPE TYP " & ControlChars.CrLf _
                & "WHERE AF.CUSTID=CF.CUSTID AND MST.CODEID=SEC.CODEID AND SEC.TRADEPLACE  <> '" & gc_TRADEPLACE_OTc & "' " & ControlChars.CrLf _
                & "AND MST.DUETYPE='SM' AND MST.STATUS='N' AND MST.DELTD<>'Y' " & ControlChars.CrLf _
                & "AND MST.AFACCTNO=AF.ACCTNO AND AF.ACCTNO=CI.ACCTNO AND MST.ORGORDERID=OD.ORDERID AND OD.ACTYPE=TYP.ACTYPE " & ControlChars.CrLf _
                & "ORDER BY CIACCTNO, ORGORDERID, DUETYPE"  'ThÃ¡Â»Â© tÃ¡Â»Â± ORDER BY lÃƒÂ  quan trÃ¡Â»?ng
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To v_ds.Tables(0).Rows.Count - 1 Step 1
                    If v_ds.Tables(0).Rows(i)("CUSTODYCD") = "F" Then
                        v_blnVietnamese = False
                    Else
                        v_blnVietnamese = True
                    End If

                    v_strCodeID = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("CODEID")))
                    v_strAFAcctno = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("AFACCTNO")))
                    v_dblFeeRate = gf_CorrectNumericField(v_ds.Tables(0).Rows(i)("FEERATE"))
                    v_dblVatRate = gf_CorrectNumericField(v_ds.Tables(0).Rows(i)("VATRATE")) / 100
                    v_dblPARVALUE = gf_CorrectNumericField(v_ds.Tables(0).Rows(i)("PARVALUE"))
                    v_strOrgOrderID = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("ORGORDERID")))
                    v_strCIAcctno = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("CIACCTNO")))

                    'Money payment
                    v_lngErrCode = BuildBatchTxMsg(v_xmlDocument, v_strBATCHNAME)
                    v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value = gc_OD_BATCH_CISENd
                    v_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value = v_strAFAcctno.Substring(0, 4)
                    v_strTLTXCD = v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value

                    'NÃ¡ÂºÂ¡p giao dÃ¡Â»â€¹ch
                    v_strSQL = "SELECT FLDNAME, FLDTYPE, DEFNAME FROM FLDMASTER " & ControlChars.CrLf _
                        & "WHERE OBJNAME='" & Trim(v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value) & "' ORDER BY ODRNUM" 'ThÃ¡Â»Â© tÃ¡Â»Â± ODRER BY lÃƒÂ  quan trÃ¡Â»?ng
                    v_dsTLLOG = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

                    If v_dsTLLOG.Tables(0).Rows.Count > 0 Then
                        v_dataElement = v_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "fields", "")

                        'TÃ¡ÂºÂ¡o phÃ¡ÂºÂ§n nÃ¡Â»â„¢i dung cÃ¡Â»Â§a giao dÃ¡Â»â€¹ch
                        For j = 0 To v_dsTLLOG.Tables(0).Rows.Count - 1 Step 1
                            v_strDEFNAME = Trim(gf_CorrectStringField(v_dsTLLOG.Tables(0).Rows(j)("DEFNAME")))
                            v_strFLDNAME = Trim(gf_CorrectStringField(v_dsTLLOG.Tables(0).Rows(j)("FLDNAME")))
                            v_strFLDTYPE = Trim(gf_CorrectStringField(v_dsTLLOG.Tables(0).Rows(j)("FLDTYPE")))

                            v_entryNode = v_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "entry", "")
                            'Add field name
                            v_attrFLDNAME = v_xmlDocument.CreateAttribute(gc_AtributeFLDNAME)
                            v_attrFLDNAME.Value = v_strFLDNAME
                            v_entryNode.Attributes.Append(v_attrFLDNAME)

                            'Add field type
                            v_attrDATATYPE = v_xmlDocument.CreateAttribute(gc_AtributeFLDTYPE)
                            v_attrDATATYPE.Value = v_strFLDTYPE
                            v_entryNode.Attributes.Append(v_attrDATATYPE)

                            'Set value
                            Select Case v_strFLDNAME
                                Case "01" 'AUTOID
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("AUTOID")
                                Case "03" 'ORGORDERID
                                    v_strVALUE = v_strOrgOrderID
                                    'Case "04" 'AFACCTNO
                                    '    v_strVALUE = v_strAFAcctno
                                Case "05" 'CIACCTNO
                                    v_strVALUE = v_strCIAcctno
                                Case "06" 'SEACCTNO
                                    v_strVALUE = v_strAFAcctno & v_strCodeID
                                Case "07" 'CODEID
                                    v_strVALUE = v_strCodeID
                                    'Case "08" 'AMT
                                    '    v_strVALUE = v_ds.Tables(0).Rows(i).Item("AMT")
                                Case "09" 'QTTY
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("QTTY")
                                    'Case "10" 'SECUREDAMT
                                    '    'SÃ¡Â»â€˜ tiÃ¡Â»?n kÃƒÂ½ quÃ¡Â»Â¹ cÃ¡Â»Â§a lÃ¡Â»â€¡nh Ã„â€˜Ã†Â°Ã¡Â»Â£c phÃƒÂ¢n bÃ¡Â»â€¢
                                    '    v_strVALUE = v_dblCISecuredAmt
                                Case "11" 'TRFAMT: SÃ¡Â»â€˜ tiÃ¡Â»?n giao dÃ¡Â»â€¹ch phÃ¡ÂºÂ£i giao
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("AMT")
                                    'Case "12" 'FEEAMT
                                    '    'Phi da thu roi khong thu nua
                                    '    v_strVALUE = 0
                                    'Case "13" 'VATAMT
                                    '    'VAT da tinh roi khong tinh nua
                                    '    v_strVALUE = 0
                                    'Case "14" 'CRSECUREDAMT
                                    '    v_strVALUE = v_dblCIODAmt
                                Case "30" 'DESC                                              
                                    If v_blnVietnamese = True Then
                                        'nGUOI VIET
                                        v_strVALUE = v_str8865Desc & " " & v_ds.Tables(0).Rows(i).Item("SQTTY") & " " & v_ds.Tables(0).Rows(i).Item("SYMBOL") & " " & Strings.Mid(v_strOrgOrderID, 5, 2) & "/" & Strings.Mid(v_strOrgOrderID, 7, 2) & "/" & Strings.Mid(v_strOrgOrderID, 9, 2)
                                    Else
                                        'NGUOI ANH
                                        v_strVALUE = v_str8865ENDesc & " " & v_ds.Tables(0).Rows(i).Item("SQTTY") & " " & v_ds.Tables(0).Rows(i).Item("SYMBOL") & " " & Strings.Mid(v_strOrgOrderID, 5, 2) & "/" & Strings.Mid(v_strOrgOrderID, 7, 2) & "/" & Strings.Mid(v_strOrgOrderID, 9, 2)
                                    End If

                                Case "44" 'PARVALUE
                                    v_strVALUE = v_dblPARVALUE
                            End Select
                            v_entryNode.InnerText = v_strVALUE

                            v_dataElement.AppendChild(v_entryNode)
                        Next

                        v_xmlDocument.DocumentElement.AppendChild(v_dataElement)
                        'Ghi nhÃ¡ÂºÂ­n giao dÃ¡Â»â€¹ch vÃƒÂ o TLLOG
                        v_lngErrCode = v_objMessageLog.TransLog(v_xmlDocument)

                        If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode
                    End If

                Next
            End If
            'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
    Private Function ODSurelySettlementTransferMoney(ByVal v_strBATCHNAME As String, Optional ByVal v_strBCHFillter As String = "", Optional ByRef v_intMaxRow As Integer = 0) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = ATTR_MODULE & ".Batch.ODSurelySettlementTransferMoney", v_strErrorMessage As String
        Dim v_strSQL As String, v_ds, v_dsTLLOG, v_dsCNT As DataSet, v_objMessageLog As New MessageLog
        v_objMessageLog.NewDBInstance(gc_MODULE_HOST)
        Dim v_obj As New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)
        Dim i, j As Integer, v_strFRTABLE, v_strTOTABLE As String
        Dim v_xmlDocument As New Xml.XmlDocument, v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
        Dim v_strVALEXP, v_strVALUE, v_strFLDNAME, v_strDEFNAME, v_strFLDTYPE As String
        Dim v_attrFLDNAME, v_attrDATATYPE As Xml.XmlAttribute
        Dim v_strTLTXCD As String
        Dim v_str8827Desc, v_str8827ENDesc As String
        Dim v_blnVietnamese As Boolean 'Yes/No
        Try
            'Xac dinh so dong de phan trang
            v_strSQL = "SELECT COUNT(*) MAXROW FROM  STSCHD"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            v_intMaxRow = v_ds.Tables(0).Rows(0)("MAXROW")
            'Lay ngay he thong
            Dim v_strSYSVAR, v_strCURRDATE, v_strPREVDATE, v_strNEXTDATE As String
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "CURRDATE", v_strCURRDATE)
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "PREVDATE", v_strPREVDATE)
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "NEXTDATE", v_strNEXTDATE)
            If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode
            'Lay ra cac dien giai mac dinh cho cac giao dich
            'Dien giai 8865
            v_strSQL = "SELECT TXDESC,EN_TXDESC FROM  TLTX WHERE TLTXCD='" & gc_OD_BATCH_SUNRELY_CISENd & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            v_str8827Desc = v_ds.Tables(0).Rows(0)("TXDESC")
            v_str8827ENDesc = v_ds.Tables(0).Rows(0)("EN_TXDESC")

            v_strSQL = "SELECT SUBSTR(CUSTODYCD,4,1) CUSTODYCD, MST.AUTOID, MST.DUETYPE, MST.TXDATE, MST.ORGORDERID, MST.CLEARCD, MST.CLEARDAY, " & ControlChars.CrLf _
                & "MST.AFACCTNO, MST.ACCTNO, MST.ACCTNO CIACCTNO, " & ControlChars.CrLf _
                & "OD.FEEAMT, OD.ORDERQTTY ORGORDERQTTY, OD.QUOTEPRICE ORGQUOTEPRICE, OD.FEEACR, TYP.FEERATE, TYP.VATRATE, SEC.PARVALUE, SEC.CODEID, " & ControlChars.CrLf _
                & "OD.SECUREDAMT, OD.RLSSECURED, SEC.SYMBOL, MST.AMT, MST.AAMT, MST.FAMT, MST.QTTY ,OD.EXECQTTY SQTTY , MST.AQTTY" & ControlChars.CrLf _
                & "FROM (SELECT MOD.* FROM (SELECT ROWNUM INDEXROW,STSCHD.* FROM STSCHD) MOD WHERE 0=0 " & v_strBCHFillter & ") MST, SBSECURITIES SEC, AFMAST AF, CFMAST CF, ODMAST OD, ODTYPE TYP " & ControlChars.CrLf _
                & "WHERE AF.CUSTID=CF.CUSTID AND MST.CODEID=SEC.CODEID AND SEC.TRADEPLACE  <> '" & gc_TRADEPLACE_OTc & "' " & ControlChars.CrLf _
                & "AND MST.DUETYPE='SM' AND MST.AAMT<MST.AMT AND MST.DELTD<>'Y' " & ControlChars.CrLf _
                & " and getduedate  (mst.TXDATE,mst.clearcd,sec.tradeplace ,mst.clearday)<=to_date('" & v_strCURRDATE & "','" & gc_FORMAT_DATE & "') " & ControlChars.CrLf _
                & "AND MST.AFACCTNO=AF.ACCTNO AND MST.ORGORDERID=OD.ORDERID AND OD.ACTYPE=TYP.ACTYPE " & ControlChars.CrLf _
                & "ORDER BY CIACCTNO, ORGORDERID, DUETYPE"  'Thu tu order by de nguyen
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To v_ds.Tables(0).Rows.Count - 1 Step 1
                    If v_ds.Tables(0).Rows(i)("CUSTODYCD") = "F" Then
                        v_blnVietnamese = False
                    Else
                        v_blnVietnamese = True
                    End If
                    'Surely Money payment
                    v_lngErrCode = BuildBatchTxMsg(v_xmlDocument, v_strBATCHNAME)
                    v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value = gc_OD_BATCH_SUNRELY_CISENd
                    v_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value = v_ds.Tables(0).Rows(i)("AFACCTNO").Substring(0, 4)
                    v_strTLTXCD = v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value

                    'nap giao dich
                    v_strSQL = "SELECT FLDNAME, FLDTYPE, DEFNAME FROM FLDMASTER " & ControlChars.CrLf _
                        & "WHERE OBJNAME='" & Trim(v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value) & "' ORDER BY ODRNUM" 'ThÃ¡Â»Â© tÃ¡Â»Â± ODRER BY lÃƒÂ  quan trÃ¡Â»?ng
                    v_dsTLLOG = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

                    If v_dsTLLOG.Tables(0).Rows.Count > 0 Then
                        v_dataElement = v_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "fields", "")

                        'TÃ¡ÂºÂ¡o phÃ¡ÂºÂ§n nÃ¡Â»â„¢i dung cÃ¡Â»Â§a giao dÃ¡Â»â€¹ch
                        For j = 0 To v_dsTLLOG.Tables(0).Rows.Count - 1 Step 1
                            v_strDEFNAME = Trim(gf_CorrectStringField(v_dsTLLOG.Tables(0).Rows(j)("DEFNAME")))
                            v_strFLDNAME = Trim(gf_CorrectStringField(v_dsTLLOG.Tables(0).Rows(j)("FLDNAME")))
                            v_strFLDTYPE = Trim(gf_CorrectStringField(v_dsTLLOG.Tables(0).Rows(j)("FLDTYPE")))

                            v_entryNode = v_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "entry", "")
                            'Add field name
                            v_attrFLDNAME = v_xmlDocument.CreateAttribute(gc_AtributeFLDNAME)
                            v_attrFLDNAME.Value = v_strFLDNAME
                            v_entryNode.Attributes.Append(v_attrFLDNAME)

                            'Add field type
                            v_attrDATATYPE = v_xmlDocument.CreateAttribute(gc_AtributeFLDTYPE)
                            v_attrDATATYPE.Value = v_strFLDTYPE
                            v_entryNode.Attributes.Append(v_attrDATATYPE)

                            'Set value
                            Select Case v_strFLDNAME
                                Case "01" 'AUTOID
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("AUTOID")
                                Case "03" 'ORGORDERID
                                    v_strVALUE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("ORGORDERID")))
                                Case "05" 'CIACCTNO
                                    v_strVALUE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("CIACCTNO")))
                                Case "11" 'TRFAMT
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("AMT")
                                Case "30" 'DESC                                              
                                    If v_blnVietnamese = True Then
                                        'nGUOI VIET
                                        v_strVALUE = v_str8827Desc & " " & v_ds.Tables(0).Rows(i).Item("SQTTY") & " " & v_ds.Tables(0).Rows(i).Item("SYMBOL")
                                    Else
                                        'NGUOI ANH
                                        v_strVALUE = v_str8827ENDesc & " " & v_ds.Tables(0).Rows(i).Item("SQTTY") & " " & v_ds.Tables(0).Rows(i).Item("SYMBOL")
                                    End If
                            End Select
                            v_entryNode.InnerText = v_strVALUE

                            v_dataElement.AppendChild(v_entryNode)
                        Next

                        v_xmlDocument.DocumentElement.AppendChild(v_dataElement)
                        'Ghi nhÃ¡ÂºÂ­n giao dÃ¡Â»â€¹ch vÃƒÂ o TLLOG
                        v_lngErrCode = v_objMessageLog.TransLog(v_xmlDocument)

                        If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode
                    End If

                Next
            End If
            'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function ODBackUp(ByVal v_strBATCHNAME As String, Optional ByVal v_strBCHFillter As String = "", Optional ByRef v_intMaxRow As Integer = 0) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = ATTR_MODULE & ".Batch.ODBackUp", v_strErrorMessage As String
        Dim v_strSQL As String, v_ds As DataSet
        Dim v_obj As New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)
        Dim i, j As Integer
        Dim v_intdays As Integer
        Dim v_strErr_Out As String
        Dim v_strMessage As String
        Try
            'X�y d?ng c�c tham s? h? th?ng
            Dim v_strCURRDATE As String
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "CURRDATE", v_strCURRDATE)
            If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode
            'Goi thu tuc de thuc hien day vao he thong giao dich luon.
            Dim v_objParam As StoreParameter
            Dim v_arrPara(1) As StoreParameter
            v_objParam = New StoreParameter
            v_objParam.ParamName = "INDATE"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamValue = v_strCURRDATE
            v_objParam.ParamSize = 10
            v_objParam.ParamType = "String"
            v_arrPara(0) = v_objParam
            v_objParam = New StoreParameter
            v_objParam.ParamName = "ERR_CODE"
            v_objParam.ParamDirection = ParameterDirection.Output
            v_objParam.ParamValue = v_strErr_Out
            v_objParam.ParamSize = 20
            v_objParam.ParamType = "String"
            v_arrPara(1) = v_objParam
            v_strMessage = v_obj.ExecuteOracleStored("BATCHORDERBACKUP", v_arrPara, 1)
            v_lngErrCode = CDbl(v_strMessage)
            'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function ODFinish(ByVal v_strBATCHNAME As String, Optional ByVal v_strBCHFillter As String = "", Optional ByRef v_intMaxRow As Integer = 0) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = ATTR_MODULE & ".Batch.ODBackUp", v_strErrorMessage As String
        Dim v_strSQL As String, v_ds, v_dsTLLOG As DataSet, v_objMessageLog As New MessageLog
        v_objMessageLog.NewDBInstance(gc_MODULE_HOST)
        Dim v_obj As New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)
        Dim i, j As Integer, v_strFRTABLE, v_strTOTABLE As String
        Dim v_xmlDocument As New Xml.XmlDocument, v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
        Dim v_strVALEXP, v_strVALUE, v_strFLDNAME, v_strDEFNAME, v_strFLDTYPE As String
        Dim v_attrFLDNAME, v_attrDATATYPE As Xml.XmlAttribute
        Dim v_strTLTXCD As String
        Try
            'Lấy giá trị cực đại trả v�? trong phân trang
            v_strSQL = "SELECT COUNT(*) MAXROW FROM  ODMAST"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            v_intMaxRow = v_ds.Tables(0).Rows(0)("MAXROW")

            'Lấy tham số hệ thống
            Dim v_strSYSVAR, v_strCURRDATE, v_strPREVDATE, v_strNEXTDATE As String
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "CURRDATE", v_strCURRDATE)
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "PREVDATE", v_strPREVDATE)
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "NEXTDATE", v_strNEXTDATE)
            If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode

            Dim v_dblOrderTradingFee, v_dblCIAvailable, v_dblCIBAmt, v_dblCIODAmt, v_dblCISecuredAmt, v_dblODFeeAmt, v_dblODFeeAcr, v_dblFeeRate, v_dblVatRate As Double
            Dim v_strOrgOrderID, v_strCodeID, v_strAFAcctno, v_strCIAcctno, v_strTXDESC As String

            'v_strSQL = "SELECT ORDERID,( CASE WHEN (REMAINQTTY=0 AND  (SELECT COUNT(ORGORDERID) FROM STSCHD WHERE STSCHD.ORGORDERID=ORDERID AND  STSCHD.STATUS<>'C')=0) THEN '7' ELSE '5' END) ODSTATUS " & _
            '            " FROM (SELECT MOD.* FROM (SELECT ROWNUM INDEXROW,ODMAST.* FROM ODMAST) MOD WHERE 0=0 " & v_strBCHFillter & " ) WHERE ORSTATUS <> '5' AND ORSTATUS <> '7'" & _
            '            " AND " & _
            '            " (EXPDATE < TO_DATE('" & v_strCURRDATE & "','" & gc_FORMAT_DATE & "')) " & _
            '            " OR " & _
            '            " (REMAINQTTY=0 AND  (SELECT COUNT(ORGORDERID) FROM STSCHD WHERE STSCHD.ORGORDERID=ORDERID AND  STSCHD.STATUS<>'C')=0)"


            v_strSQL = " SELECT ORDERID,(CASE WHEN (REMAINQTTY = 0 " & ControlChars.CrLf _
                & " AND (SELECT COUNT (ORGORDERID) FROM STSCHD WHERE STSCHD.ORGORDERID = ORDERID AND STSCHD.STATUS <> 'C') = 0 " & ControlChars.CrLf _
                & " AND (SELECT COUNT (ORGORDERID) FROM STSCHD WHERE STSCHD.ORGORDERID = ORDERID) > 0)THEN '7' " & ControlChars.CrLf _
                & " WHEN ((EXECQTTY > 0 AND EXECQTTY <= ORDERQTTY) " & ControlChars.CrLf _
                & " AND (SELECT COUNT (ORGORDERID) FROM STSCHD WHERE STSCHD.ORGORDERID = ORDERID) > 0)THEN '4' " & ControlChars.CrLf _
                & " ELSE '5' END) ODSTATUS " & ControlChars.CrLf _
                & " FROM (SELECT MOD.* FROM (SELECT ROWNUM INDEXROW, ODMAST.* FROM ODMAST) MOD WHERE 0 = 0 " & v_strBCHFillter & " ) " & ControlChars.CrLf _
                & " WHERE ORSTATUS <> '5' AND ORSTATUS <> '7' AND (EXPDATE < TO_DATE('" & v_strCURRDATE & "','" & gc_FORMAT_DATE & "')) " & ControlChars.CrLf _
                & " OR (REMAINQTTY = 0 AND (SELECT COUNT (ORGORDERID) FROM STSCHD WHERE STSCHD.ORGORDERID = ORDERID AND STSCHD.STATUS <> 'C') =0) " & ControlChars.CrLf

            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To v_ds.Tables(0).Rows.Count - 1 Step 1
                    v_lngErrCode = BuildBatchTxMsg(v_xmlDocument, v_strBATCHNAME)
                    v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value = gc_OD_FINISHORDER
                    'Modified by MinhTK, 17-Apr-07: Khach hang cua chi nhanh nao thi GD phai thuoc chi nhanh do
                    v_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("ORDERID")).Substring(0, 4)
                    'End of modified by MinhTK, 7-Apr-07
                    v_strTXDESC = "Finish order"
                    v_strTLTXCD = v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value

                    'NÃ¡ÂºÂ¡p giao dÃ¡Â»â€¹ch
                    v_strSQL = "SELECT FLDNAME, FLDTYPE, DEFNAME FROM FLDMASTER " & ControlChars.CrLf _
                        & "WHERE OBJNAME='" & Trim(v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value) & "' ORDER BY ODRNUM" 'Thứ tự ODRER BY là quan tr�?ng
                    v_dsTLLOG = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_dsTLLOG.Tables(0).Rows.Count > 0 Then
                        v_dataElement = v_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "fields", "")

                        'TÃ¡ÂºÂ¡o phÃ¡ÂºÂ§n nÃ¡Â»â„¢i dung cÃ¡Â»Â§a giao dÃ¡Â»â€¹ch
                        For j = 0 To v_dsTLLOG.Tables(0).Rows.Count - 1 Step 1
                            v_strDEFNAME = Trim(gf_CorrectStringField(v_dsTLLOG.Tables(0).Rows(j)("DEFNAME")))
                            v_strFLDNAME = Trim(gf_CorrectStringField(v_dsTLLOG.Tables(0).Rows(j)("FLDNAME")))
                            v_strFLDTYPE = Trim(gf_CorrectStringField(v_dsTLLOG.Tables(0).Rows(j)("FLDTYPE")))

                            v_entryNode = v_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "entry", "")
                            'Add field name
                            v_attrFLDNAME = v_xmlDocument.CreateAttribute(gc_AtributeFLDNAME)
                            v_attrFLDNAME.Value = v_strFLDNAME
                            v_entryNode.Attributes.Append(v_attrFLDNAME)

                            'Add field type
                            v_attrDATATYPE = v_xmlDocument.CreateAttribute(gc_AtributeFLDTYPE)
                            v_attrDATATYPE.Value = v_strFLDTYPE
                            v_entryNode.Attributes.Append(v_attrDATATYPE)

                            'Set value
                            Select Case v_strFLDNAME
                                Case "03" 'ORGORDERID
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("ORDERID")
                                Case "05" 'ODSTATUS
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("ODSTATUS")
                                Case "30" 'DESC                                              
                                    v_strVALUE = v_strTXDESC
                            End Select
                            v_entryNode.InnerText = v_strVALUE

                            v_dataElement.AppendChild(v_entryNode)
                        Next
                        v_xmlDocument.DocumentElement.AppendChild(v_dataElement)
                        'Ghi nhÃ¡ÂºÂ­n giao dÃ¡Â»â€¹ch vÃƒÂ o TLLOG
                        v_lngErrCode = v_objMessageLog.TransLog(v_xmlDocument)
                        If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode
                    End If
                Next
            End If

            'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function ODDeposit(ByVal v_strBATCHNAME As String, Optional ByVal v_strBCHFillter As String = "", Optional ByRef v_intMaxRow As Integer = 0) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = ATTR_MODULE & ".Batch.ODDeposit", v_strErrorMessage As String
        Dim v_strSQL As String, v_ds, v_dsTLLOG As DataSet, v_objMessageLog As New MessageLog
        v_objMessageLog.NewDBInstance(gc_MODULE_HOST)
        Dim v_obj As New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)
        Dim i, j As Integer, v_strFRTABLE, v_strTOTABLE As String
        Dim v_xmlDocument As New Xml.XmlDocument, v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
        Dim v_strVALEXP, v_strVALUE, v_strFLDNAME, v_strDEFNAME, v_strFLDTYPE, v_str8869Desc As String
        Dim v_attrFLDNAME, v_attrDATATYPE As Xml.XmlAttribute
        Dim v_strTLTXCD As String
        Try
            'LÃ¡ÂºÂ¥y giÃƒÂ¡ trÃ¡Â»â€¹ cÃ¡Â»Â±c Ã„â€˜Ã¡ÂºÂ¡i trÃ¡ÂºÂ£ vÃ¡Â»? trong phÃƒÂ¢n trang
            v_strSQL = "SELECT COUNT(*) MAXROW FROM  ODMAST"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            v_intMaxRow = v_ds.Tables(0).Rows(0)("MAXROW")

            'LÃ¡ÂºÂ¥y tham sÃ¡Â»â€˜ hÃ¡Â»â€¡ thÃ¡Â»â€˜ng
            Dim v_strSYSVAR, v_strCURRDATE, v_strPREVDATE, v_strNEXTDATE As String
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "CURRDATE", v_strCURRDATE)
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "PREVDATE", v_strPREVDATE)
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "NEXTDATE", v_strNEXTDATE)
            If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode

            Dim v_dblOrderTradingFee, v_dblCIAvailable, v_dblCIBAmt, v_dblCIODAmt, v_dblCISecuredAmt, v_dblODFeeAmt, v_dblODFeeAcr, v_dblFeeRate, v_dblVatRate As Double
            Dim v_strOrgOrderID, v_strCodeID, v_strAFAcctno, v_strCIAcctno, v_strTXDESC As String

            v_strSQL = "SELECT TXDESC,EN_TXDESC FROM  TLTX WHERE TLTXCD='" & gc_OD_BATCH_DEPOSIT & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            v_str8869Desc = v_ds.Tables(0).Rows(0)("TXDESC")

            'ThÃ¡Â»Â±c hiÃ¡Â»â€¡n kÃƒÂ­ quÃ¡Â»Â¹ thÃƒÂªm vÃ¡Â»â€ºi cÃƒÂ¡c lÃ¡Â»â€¡nh cÃƒÂ²n thiÃ¡ÂºÂ¿u kÃƒÂ­ qÃ…Â©y
            v_strSQL = "SELECT OD.ORDERID, OD.ORDERQTTY, OD.QUOTEPRICE, OD.CODEID, OD.AFACCTNO, OD.SEACCTNO, OD.CIACCTNO, OD.EXECTYPE, OD.ORSTATUS, " & ControlChars.CrLf _
                        & " OD.SECUREDAMT, OD.MATCHAMT, OD.RLSSECURED, OD.FEEACR, OD.FEEAMT, CCY.SYMBOL, " & ControlChars.CrLf _
                        & " (OD.MATCHAMT-OD.SECUREDAMT+OD.RLSSECURED+OD.FEEACR-OD.FEEAMT) AVLDEPOSITAMT   " & ControlChars.CrLf _
                        & " FROM (SELECT MOD.* FROM (SELECT ROWNUM INDEXROW,ODMAST.* FROM ODMAST) MOD WHERE 0=0 " & v_strBCHFillter & ") OD, SBSECURITIES CCY" & ControlChars.CrLf _
                        & " WHERE (OD.MATCHAMT-OD.SECUREDAMT+OD.RLSSECURED+OD.FEEACR-OD.FEEAMT)>0 AND OD.DELTD<>'Y' AND OD.ORSTATUS IN ('1','2','4') " & ControlChars.CrLf _
                        & " AND OD.CODEID=CCY.CODEID AND CCY.TRADEPLACE IN ('" & gc_TRADEPLACE_HNCSTc & "','" & gc_TRADEPLACE_HCMCSTc & "') " & ControlChars.CrLf _
                        & " AND OD.EXECTYPE IN ('NB','BC') ORDER BY OD.CIACCTNO, OD.ORDERID "
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To v_ds.Tables(0).Rows.Count - 1 Step 1
                    v_lngErrCode = BuildBatchTxMsg(v_xmlDocument, v_strBATCHNAME)
                    v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value = gc_OD_BATCH_DEPOSIT
                    'Modified by MinhTK, 17-Apr-07: Khach hang cua chi nhanh nao thi GD phai thuoc chi nhanh do
                    v_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("AFACCTNO")).Substring(0, 4)
                    'End of modified by MinhTK, 7-Apr-07
                    v_strTXDESC = "Batch secured deposit"
                    v_strTLTXCD = v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value



                    'NÃ¡ÂºÂ¡p giao dÃ¡Â»â€¹ch
                    v_strSQL = "SELECT FLDNAME, FLDTYPE, DEFNAME FROM FLDMASTER " & ControlChars.CrLf _
                        & "WHERE OBJNAME='" & Trim(v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value) & "' ORDER BY ODRNUM" 'ThÃ¡Â»Â© tÃ¡Â»Â± ODRER BY lÃƒÂ  quan trÃ¡Â»?ng
                    v_dsTLLOG = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_dsTLLOG.Tables(0).Rows.Count > 0 Then
                        v_dataElement = v_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "fields", "")

                        'TÃ¡ÂºÂ¡o phÃ¡ÂºÂ§n nÃ¡Â»â„¢i dung cÃ¡Â»Â§a giao dÃ¡Â»â€¹ch
                        For j = 0 To v_dsTLLOG.Tables(0).Rows.Count - 1 Step 1
                            v_strDEFNAME = Trim(gf_CorrectStringField(v_dsTLLOG.Tables(0).Rows(j)("DEFNAME")))
                            v_strFLDNAME = Trim(gf_CorrectStringField(v_dsTLLOG.Tables(0).Rows(j)("FLDNAME")))
                            v_strFLDTYPE = Trim(gf_CorrectStringField(v_dsTLLOG.Tables(0).Rows(j)("FLDTYPE")))

                            v_entryNode = v_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "entry", "")
                            'Add field name
                            v_attrFLDNAME = v_xmlDocument.CreateAttribute(gc_AtributeFLDNAME)
                            v_attrFLDNAME.Value = v_strFLDNAME
                            v_entryNode.Attributes.Append(v_attrFLDNAME)

                            'Add field type
                            v_attrDATATYPE = v_xmlDocument.CreateAttribute(gc_AtributeFLDTYPE)
                            v_attrDATATYPE.Value = v_strFLDTYPE
                            v_entryNode.Attributes.Append(v_attrDATATYPE)

                            'Set value
                            Select Case v_strFLDNAME
                                Case "03" 'ORGORDERID
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("ORDERID")
                                Case "05" 'CIACCTNO
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("CIACCTNO")
                                Case "06" 'SEACCTNO
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("SEACCTNO")
                                Case "07" 'AFACCTNO
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("AFACCTNO")
                                Case "10" 'SECUREDAMT
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("AVLDEPOSITAMT")
                                Case "11" 'AVLDEPOSITAMT
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("AVLDEPOSITAMT")
                                Case "30" 'DESC                                              
                                    v_strVALUE = v_str8869Desc & " : " & v_ds.Tables(0).Rows(i).Item("SYMBOL") & " [" & v_ds.Tables(0).Rows(i).Item("ORDERQTTY") & ":" & v_ds.Tables(0).Rows(i).Item("QUOTEPRICE") & "]"
                            End Select
                            v_entryNode.InnerText = v_strVALUE

                            v_dataElement.AppendChild(v_entryNode)
                        Next
                        v_xmlDocument.DocumentElement.AppendChild(v_dataElement)
                        'Ghi nhÃ¡ÂºÂ­n giao dÃ¡Â»â€¹ch vÃƒÂ o TLLOG
                        v_lngErrCode = v_objMessageLog.TransLog(v_xmlDocument)
                        If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode
                    End If
                Next
            End If

            'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function ODCleanUp(ByVal v_strBATCHNAME As String, Optional ByVal v_strBCHFillter As String = "", Optional ByRef v_intMaxRow As Integer = 0) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = ATTR_MODULE & ".Batch.ODCleanUp", v_strErrorMessage As String
        Dim v_strSQL As String, v_ds, v_dsTLLOG As DataSet, v_objMessageLog As New MessageLog
        v_objMessageLog.NewDBInstance(gc_MODULE_HOST)
        Dim v_obj As New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)
        Dim i, j As Integer, v_strFRTABLE, v_strTOTABLE As String
        Dim v_xmlDocument As New Xml.XmlDocument, v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
        Dim v_strVALEXP, v_strVALUE, v_strFLDNAME, v_strDEFNAME, v_strFLDTYPE As String
        Dim v_attrFLDNAME, v_attrDATATYPE As Xml.XmlAttribute
        Dim v_strTLTXCD As String
        Try
            'LÃ¡ÂºÂ¥y giÃƒÂ¡ trÃ¡Â»â€¹ cÃ¡Â»Â±c Ã„â€˜Ã¡ÂºÂ¡i trÃ¡ÂºÂ£ vÃ¡Â»? trong phÃƒÂ¢n trang
            v_strSQL = "SELECT COUNT(*) MAXROW FROM  ODMAST"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            v_intMaxRow = v_ds.Tables(0).Rows(0)("MAXROW")

            'LÃ¡ÂºÂ¥y tham sÃ¡Â»â€˜ hÃ¡Â»â€¡ thÃ¡Â»â€˜ng
            Dim v_strSYSVAR, v_strCURRDATE, v_strPREVDATE, v_strNEXTDATE As String
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "CURRDATE", v_strCURRDATE)
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "PREVDATE", v_strPREVDATE)
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "NEXTDATE", v_strNEXTDATE)
            If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode

            Dim v_dblOrderTradingFee, v_dblCIAvailable, v_dblCIBAmt, v_dblCIODAmt, v_dblCISecuredAmt, v_dblODFeeAmt, v_dblODFeeAcr, v_dblFeeRate, v_dblVatRate As Double
            Dim v_strOrgOrderID, v_strCodeID, v_strAFAcctno, v_strCIAcctno, v_strTXDESC As String
            'GiÃ¡ÂºÂ£i toÃ¡ÂºÂ£ kÃƒÂ½ quÃ¡Â»Â¹ Ã„â€˜Ã¡Â»â€˜i vÃ¡Â»â€ºi cÃƒÂ¡c lÃ¡Â»â€¡nh khÃƒÂ´ng Ã„â€˜Ã†Â°Ã¡Â»Â£c khÃ¡Â»â€ºp trong ngÃƒÂ y, chÃ¡Â»â€° quan tÃƒÂ¢m Ã„â€˜Ã¡ÂºÂ¿n cÃƒÂ¡c lÃ¡Â»â€¡nh Ã„â€˜ÃƒÂ£ Ã„â€˜Ã†Â°Ã¡Â»Â£c Ã„â€˜Ã¡ÂºÂ©y lÃƒÂªn hÃ¡Â»â€¡ thÃ¡Â»â€˜ng giao dÃ¡Â»â€¹ch
            v_strSQL = "SELECT MST.ORDERID, MST.ACTYPE, MST.CODEID, CCY.SYMBOL, CCY.PARVALUE, MST.AFACCTNO, AF.ACCTNO || MST.CODEID SEACCTNO, AF.ACCTNO CIACCTNO,  " & ControlChars.CrLf _
                        & "CF.FULLNAME CUSTNAME, CF.CUSTODYCD, CF.ADDRESS, CF.IDCODE LICENSE, CI.RAMT, CI.AAMT, CI.RAMT-CI.AAMT AVLAMT, CI.BALANCE, CI.ODAMT, CI.BAMT, SE.SECURED,  " & ControlChars.CrLf _
                        & "MST.TXDATE, MST.TXNUM, MST.EXPDATE, MST.BRATIO, MST.BRATIO/100 SRATIO, MST.CLEARDAY, MST.VOUCHER, MST.EXECAMT-MST.EXAMT AVLEXAMT, " & ControlChars.CrLf _
                        & "MST.QUOTEPRICE, MST.STOPPRICE, MST.LIMITPRICE, MST.EXPRICE, MST.EXQTTY, MST.EXECAMT, MST.EXAMT, MST.FEEAMT, MST.FEEACR, MST.RLSSECURED, MST.MATCHAMT, MST.SECUREDAMT," & ControlChars.CrLf _
                        & "(CASE WHEN MST.ORDERQTTY-MST.EXECQTTY-MST.ADJUSTQTTY-MST.CANCELQTTY>0 THEN MST.ORDERQTTY-MST.EXECQTTY-MST.ADJUSTQTTY-MST.CANCELQTTY ELSE 0 END) AVLCANCELQTTY, " & ControlChars.CrLf _
                        & "(CASE WHEN EXECTYPE='NB' OR EXECTYPE='BC' THEN 1 ELSE 0 END)*(CASE WHEN MST.SECUREDAMT-MST.MATCHAMT-MST.RLSSECURED>0 THEN MST.SECUREDAMT-MST.MATCHAMT-MST.RLSSECURED ELSE 0 END) AVLCANCELAMT, " & ControlChars.CrLf _
                        & "(CASE WHEN EXECTYPE='NB' OR EXECTYPE='BC' THEN 1 ELSE 0 END)*(CASE WHEN MST.SECUREDAMT-(MST.EXPRICE*MST.REMAINQTTY+MST.MATCHAMT)-MST.RLSSECURED>0 THEN MST.SECUREDAMT-(MST.EXPRICE*MST.REMAINQTTY+MST.MATCHAMT)-MST.RLSSECURED ELSE 0 END) AVLSECUREDAMT, " & ControlChars.CrLf _
                        & "(CASE WHEN MST.ORDERQTTY-MST.REMAINQTTY-MST.EXECQTTY-MST.ADJUSTQTTY-MST.CANCELQTTY>0 THEN MST.ORDERQTTY-MST.REMAINQTTY-MST.EXECQTTY-MST.ADJUSTQTTY-MST.CANCELQTTY ELSE 0 END) QTTY, " & ControlChars.CrLf _
                        & "(CASE WHEN EXECTYPE='NB' OR EXECTYPE='BC' THEN 'B' ELSE 'S' END) BORS, " & ControlChars.CrLf _
                        & "(CASE WHEN NORK='N' THEN 'N' ELSE 'A' END) AORN, " & ControlChars.CrLf _
                        & "(CASE WHEN MATCHTYPE='N' THEN 'N' ELSE 'P' END) NORP, " & ControlChars.CrLf _
                        & "MST.ORDERQTTY, MST.REMAINQTTY, MST.EXECQTTY, MST.STANDQTTY, MST.CANCELQTTY, MST.ADJUSTQTTY, MST.REJECTQTTY,  " & ControlChars.CrLf _
                        & "MST.TIMETYPE, MST.EXECTYPE, MST.NORK, MST.MATCHTYPE, MST.VIA, MST.CLEARCD, MST.ORSTATUS, MST.PRICETYPE, MST.REJECTCD,  " & ControlChars.CrLf _
                        & "CD1.CDCONTENT DESC_TIMETYPE, CD2.CDCONTENT DESC_EXECTYPE, CD3.CDCONTENT DESC_NORK, CD4.CDCONTENT DESC_MATCHTYPE,  " & ControlChars.CrLf _
                        & "CD5.CDCONTENT DESC_VIA, CD6.CDCONTENT DESC_CLEARCD, CD7.CDCONTENT DESC_ORSTATUS, CD8.CDCONTENT DESC_PRICETYPE, CD9.CDCONTENT DESC_REJECTCD  " & ControlChars.CrLf _
                    & "FROM (SELECT MOD.* FROM (SELECT ROWNUM INDEXROW,ODMAST.* FROM ODMAST) MOD WHERE 0=0 " & v_strBCHFillter & ") MST, AFMAST AF, CFMAST CF, SBSECURITIES CCY, CIMAST CI,SEMAST SE,  " & ControlChars.CrLf _
                    & "ALLCODE CD1, ALLCODE CD2, ALLCODE CD3, ALLCODE CD4, ALLCODE CD5, ALLCODE CD6, ALLCODE CD7, ALLCODE CD8, ALLCODE CD9  " & ControlChars.CrLf _
                    & "WHERE (MST.REMAINQTTY>0 OR MST.SECUREDAMT-MST.RLSSECURED-MST.MATCHAMT-MST.FEEACR+MST.FEEAMT>0) AND MST.DELTD<>'Y' " & ControlChars.CrLf _
                        & "AND MST.AFACCTNO = AF.ACCTNO And MST.CIACCTNO = CI.ACCTNO AND MST.SEACCTNO = SE.ACCTNO  " & ControlChars.CrLf _
                        & "AND AF.CUSTID = CF.CUSTID AND MST.CODEID = CCY.CODEID  " & ControlChars.CrLf _
                        & "AND MST.ORSTATUS IN ('1','2','4','8','9') AND CCY.TRADEPLACE <> '" & gc_TRADEPLACE_OTc & "' " & ControlChars.CrLf _
                        & "AND CD1.CDTYPE='OD' AND CD1.CDNAME='TIMETYPE' AND CD1.CDVAL=MST.TIMETYPE  " & ControlChars.CrLf _
                        & "AND CD2.CDTYPE='OD' AND CD2.CDNAME='EXECTYPE' AND CD2.CDVAL=MST.EXECTYPE  " & ControlChars.CrLf _
                        & "AND CD3.CDTYPE='OD' AND CD3.CDNAME='NORK' AND CD3.CDVAL=MST.NORK  " & ControlChars.CrLf _
                        & "AND CD4.CDTYPE='OD' AND CD4.CDNAME='MATCHTYPE' AND CD4.CDVAL=MST.MATCHTYPE  " & ControlChars.CrLf _
                        & "AND CD5.CDTYPE='OD' AND CD5.CDNAME='VIA' AND CD5.CDVAL=MST.VIA  " & ControlChars.CrLf _
                        & "AND CD6.CDTYPE='OD' AND CD6.CDNAME='CLEARCD' AND CD6.CDVAL=MST.CLEARCD  " & ControlChars.CrLf _
                        & "AND CD7.CDTYPE='OD' AND CD7.CDNAME='ORSTATUS' AND CD7.CDVAL=MST.ORSTATUS  " & ControlChars.CrLf _
                        & "AND CD8.CDTYPE='OD' AND CD8.CDNAME='PRICETYPE' AND CD8.CDVAL=MST.PRICETYPE  " & ControlChars.CrLf _
                        & "AND CD9.CDTYPE='OD' AND CD9.CDNAME='REJECTCD' AND CD9.CDVAL=MST.REJECTCD " & ControlChars.CrLf _
                        & "AND MST.EXECTYPE NOT IN ('AS', 'AB', 'CS', 'CB')" & ControlChars.CrLf _
                        & "ORDER BY AF.ACCTNO, MST.ORDERID" 'ThÃ¡Â»Â© tÃ¡Â»Â± ORDER BY lÃƒÂ  quan trÃ¡Â»?ng
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To v_ds.Tables(0).Rows.Count - 1 Step 1
                    v_lngErrCode = BuildBatchTxMsg(v_xmlDocument, v_strBATCHNAME)
                    v_strCodeID = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("CODEID")))
                    v_strAFAcctno = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("AFACCTNO")))
                    If v_strCIAcctno <> Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("CIACCTNO"))) Then
                        'XÃƒÂ¡c Ã„â€˜Ã¡Â»â€¹nh sÃ¡Â»â€˜ dÃ†Â° kÃƒÂ½ quÃ¡Â»Â¹ cÃƒÂ²n lÃ¡ÂºÂ¡i cÃ¡Â»Â§a tÃƒÂ i khoÃ¡ÂºÂ£n CI
                        v_strCIAcctno = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("CIACCTNO")))
                        v_dblCIBAmt = gf_CorrectNumericField(v_ds.Tables(0).Rows(i)("BAMT"))
                    End If
                    If Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("BORS"))) = "B" Then
                        '2.1 GiÃ¡ÂºÂ£i toÃ¡ÂºÂ£ lÃ¡Â»â€¡nh mua: 8862
                        v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value = gc_OD_RELEASEBUYORDER
                        v_strTXDESC = "Release secured deposit buy order"
                    Else
                        '2.2 GiÃ¡ÂºÂ£i toÃ¡ÂºÂ£ lÃ¡Â»â€¡nh bÃƒÂ¡n: 8863
                        v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value = gc_OD_RELEASESELLORDER
                        v_strTXDESC = "Release secured deposit sell order"
                    End If
                    'Modified by MinhTK, 17-Apr-07: Khach hang cua chi nhanh nao thi GD phai thuoc chi nhanh do
                    v_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value = v_strAFAcctno.Substring(0, 4)
                    'End of modified by MinhTK, 7-Apr-07
                    v_strTLTXCD = v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value


                    'NÃ¡ÂºÂ¡p giao dÃ¡Â»â€¹ch
                    v_strSQL = "SELECT FLDNAME, FLDTYPE, DEFNAME FROM FLDMASTER " & ControlChars.CrLf _
                        & "WHERE OBJNAME='" & Trim(v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value) & "' ORDER BY ODRNUM" 'ThÃ¡Â»Â© tÃ¡Â»Â± ODRER BY lÃƒÂ  quan trÃ¡Â»?ng
                    v_dsTLLOG = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_dsTLLOG.Tables(0).Rows.Count > 0 Then
                        v_dataElement = v_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "fields", "")

                        'TÃ¡ÂºÂ¡o phÃ¡ÂºÂ§n nÃ¡Â»â„¢i dung cÃ¡Â»Â§a giao dÃ¡Â»â€¹ch
                        For j = 0 To v_dsTLLOG.Tables(0).Rows.Count - 1 Step 1
                            v_strDEFNAME = Trim(gf_CorrectStringField(v_dsTLLOG.Tables(0).Rows(j)("DEFNAME")))
                            v_strFLDNAME = Trim(gf_CorrectStringField(v_dsTLLOG.Tables(0).Rows(j)("FLDNAME")))
                            v_strFLDTYPE = Trim(gf_CorrectStringField(v_dsTLLOG.Tables(0).Rows(j)("FLDTYPE")))

                            v_entryNode = v_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "entry", "")
                            'Add field name
                            v_attrFLDNAME = v_xmlDocument.CreateAttribute(gc_AtributeFLDNAME)
                            v_attrFLDNAME.Value = v_strFLDNAME
                            v_entryNode.Attributes.Append(v_attrFLDNAME)

                            'Add field type
                            v_attrDATATYPE = v_xmlDocument.CreateAttribute(gc_AtributeFLDTYPE)
                            v_attrDATATYPE.Value = v_strFLDTYPE
                            v_entryNode.Attributes.Append(v_attrDATATYPE)

                            'Set value
                            Select Case v_strFLDNAME
                                Case "03" 'ORGORDERID
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("ORDERID")
                                Case "80" 'CODEID
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("CODEID")
                                Case "05" 'CIACCTNO
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("CIACCTNO")
                                Case "06" 'SEACCTNO
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("SEACCTNO")
                                Case "07" 'AFACCTNO
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("AFACCTNO")
                                Case "10" 'REMAINQTTY
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("REMAINQTTY")
                                Case "11" 'AVLCANCELAMT
                                    If v_dblCIBAmt > v_ds.Tables(0).Rows(i).Item("AVLCANCELAMT") Then
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("AVLCANCELAMT")
                                        v_dblCIBAmt = v_dblCIBAmt - v_ds.Tables(0).Rows(i).Item("AVLCANCELAMT")
                                    Else
                                        v_strVALUE = v_dblCIBAmt
                                        v_dblCIBAmt = 0
                                    End If

                                Case "12" 'PARVALUE
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("PARVALUE")
                                Case "13" 'EXPRICE
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("EXPRICE")
                                Case "14" 'EXQTTY
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("EXQTTY")
                                Case "15" 'CANCELQTTY
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("CANCELQTTY")
                                Case "16" 'ADJUSTQTTY
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("ADJUSTQTTY")
                                Case "17" 'REJECTQTTY
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("REJECTQTTY")
                                Case "18" 'MATCHAMT
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("MATCHAMT")
                                Case "19" 'SECUREDAMT
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("SECUREDAMT")
                                Case "20" 'RLSSECURED
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("RLSSECURED")
                                Case "30" 'DESC                                              
                                    v_strVALUE = v_strTXDESC & ": " & v_ds.Tables(0).Rows(i).Item("ORDERID") & ". " & v_ds.Tables(0).Rows(i).Item("ORDERQTTY") & "." & v_ds.Tables(0).Rows(i).Item("SYMBOL") & "X" & v_ds.Tables(0).Rows(i).Item("QUOTEPRICE")
                                Case "60" 'Is Mortage
                                    v_strVALUE = IIf(v_ds.Tables(0).Rows(i).Item("EXECTYPE") = "MS", "1", "0")
                            End Select
                            v_entryNode.InnerText = v_strVALUE

                            v_dataElement.AppendChild(v_entryNode)
                        Next

                        v_xmlDocument.DocumentElement.AppendChild(v_dataElement)
                        'Ghi nhÃ¡ÂºÂ­n giao dÃ¡Â»â€¹ch vÃƒÂ o TLLOG
                        v_lngErrCode = v_objMessageLog.TransLog(v_xmlDocument)

                        If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode
                    End If
                Next
            End If


            'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function ODSettlementReceive(ByVal v_strBATCHNAME As String, ByVal v_strDUETYPE As String, Optional ByVal v_strBCHFillter As String = "", Optional ByRef v_intMaxRow As Integer = 0) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = ATTR_MODULE & ".Batch.ODSettlementReceive", v_strErrorMessage As String
        Dim v_strSQL As String, v_ds, v_dsCNT, v_dsTLLOG, v_dsDealing, v_dsCostPrice As DataSet, v_objMessageLog As New MessageLog
        v_objMessageLog.NewDBInstance(gc_MODULE_HOST)
        Dim v_obj As New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)
        Dim i, j As Integer, v_strFRTABLE, v_strTOTABLE As String
        Dim v_dblCostprice, v_dblProfit, v_dblLoss As Double
        Dim v_xmlDocument As New Xml.XmlDocument, v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
        Dim v_strVALEXP, v_strVALUE, v_strFLDNAME, v_strDEFNAME, v_strFLDTYPE As String
        Dim v_attrFLDNAME, v_attrDATATYPE As Xml.XmlAttribute
        Dim v_strTLTXCD, v_strORGORDERID As String, v_dblFEEAMT, v_dblFeeTemp, v_dblAVLFEEAMT, v_dblAVLRCVAMT, v_dblVATRATE As Double
        Dim v_str8856Desc, v_str8856EN_Desc, v_str8866Desc, v_str8866EN_Desc, v_str8868Desc, v_str8868EN_Desc As String
        Dim v_blnVietnamese As Boolean 'Yes/No
        Dim v_strRCVMDAY As Integer
        Try
            'Gan gia tri truoc ko se bi NULL.
            v_dblProfit = 0
            v_dblLoss = 0

            'LÃ¡ÂºÂ¥y giÃƒÂ¡ trÃ¡Â»â€¹ cÃ¡Â»Â±c Ã„â€˜Ã¡ÂºÂ¡i trÃ¡ÂºÂ£ vÃ¡Â»? trong phÃƒÂ¢n trang
            v_strSQL = "SELECT COUNT(*) MAXROW FROM  STSCHD"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            v_intMaxRow = v_ds.Tables(0).Rows(0)("MAXROW")
            'LÃ¡ÂºÂ¥y tham sÃ¡Â»â€˜ hÃ¡Â»â€¡ thÃ¡Â»â€˜ng
            Dim v_strSYSVAR, v_strCURRDATE, v_strPREVDATE, v_strNEXTDATE As String
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "CURRDATE", v_strCURRDATE)
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "PREVDATE", v_strPREVDATE)
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "NEXTDATE", v_strNEXTDATE)
            'Them tham so de thuc hien thanh toan tien ban dau ngay T+RCVMDAY doi voi cac lenh ban co lich thanh toan la T+RCVMDAY (hien tai la T+3)
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "RCVMDAY", v_strRCVMDAY)
            If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode

            'Lay ra cac dien giai mac dinh cho cac giao dich
            'Dien giai 8856
            v_strSQL = "SELECT TXDESC,EN_TXDESC FROM  TLTX WHERE TLTXCD='" & gc_OD_BATCH_CIRECEIVE_FEE & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            v_str8856Desc = v_ds.Tables(0).Rows(0)("TXDESC")
            v_str8856EN_Desc = v_ds.Tables(0).Rows(0)("EN_TXDESC")
            'Dien giai 8866
            v_strSQL = "SELECT TXDESC,EN_TXDESC FROM  TLTX WHERE TLTXCD='" & gc_OD_BATCH_CIRECEIVE & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            v_str8866Desc = v_ds.Tables(0).Rows(0)("TXDESC")
            v_str8866EN_Desc = v_ds.Tables(0).Rows(0)("EN_TXDESC")
            'Dien giai 8868
            v_strSQL = "SELECT TXDESC,EN_TXDESC FROM  TLTX WHERE TLTXCD='" & gc_OD_BATCH_SERECEIVE & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            v_str8868Desc = v_ds.Tables(0).Rows(0)("TXDESC")
            v_str8868EN_Desc = v_ds.Tables(0).Rows(0)("EN_TXDESC")

            Dim v_strCond As String
            If v_strBATCHNAME = "ODRCVM" Then
                v_strCond = "AND MST.CLEARDAY <> " & v_strRCVMDAY & " "
            ElseIf v_strBATCHNAME = "ODRCVMT3" Then
                v_strCond = "AND MST.CLEARDAY = " & v_strRCVMDAY & " "
            End If

            'v_strSQL = "SELECT SUBSTR(MAX(CUSTODYCD),4,1) CUSTODYCD,MAX(COSTPRICE) COSTPRICE ,CLR2.SBDATE, TO_DATE('" & v_strCURRDATE & "','" & gc_FORMAT_DATE & "') CURRDATE, " & ControlChars.CrLf _
            '    & "SUM(CASE WHEN CLR1.HOLIDAY='Y' THEN 0 ELSE 1 END) WITHHOLIDAY,  " & ControlChars.CrLf _
            '    & "SUM(CASE WHEN CLR1.HOLIDAY='Y' THEN 1 ELSE 1 END) WITHOUTHOLIDAY, " & ControlChars.CrLf _
            '    & "MST.AUTOID, MST.AFACCTNO,MAX(ODMST.ORDERQTTY) ORGORDERQTTY,MAX(ODMST.EXECTYPE) EXECTYPE,MAX(ODMST.QUOTEPRICE) ORGQUOTEPRICE, MST.ACCTNO, MIN(MST.DUETYPE) DUETYPE, MIN(MST.TXDATE) TXDATE, MIN(MST.ORGORDERID) ORGORDERID, MIN(MST.CLEARCD) CLEARCD, MIN(MST.CLEARDAY) CLEARDAY, " & ControlChars.CrLf _
            '    & "MIN(SEC.CODEID) CODEID, MIN(SEC.SYMBOL) SYMBOL, MIN(SEC.PARVALUE) PARVALUE, MIN(TYP.VATRATE) VATRATE, MIN(ODMST.FEEACR-ODMST.FEEAMT) AVLFEEAMT, " & ControlChars.CrLf _
            '    & "MIN(MST.AMT) AMT, MIN(MST.AAMT) AAMT, MIN(MST.FAMT) FAMT, MIN(MST.QTTY) QTTY,MIN(ODMST.EXECQTTY) SQTTY , MIN(MST.AQTTY) AQTTY, ROUND(MIN(MST.AMT/MST.QTTY),4) MATCHPRICE " & ControlChars.CrLf _
            '    & "FROM SBCLDR CLR1, SBCLDR CLR2, (SELECT MOD.* FROM (SELECT ROWNUM INDEXROW,STSCHD.* FROM STSCHD) MOD WHERE 0=0 " & v_strBCHFillter & ") MST, ODMAST ODMST,AFMAST AF,CFMAST CF, ODTYPE TYP, SBSECURITIES SEC " & ControlChars.CrLf _
            '    & "WHERE ODMST.AFACCTNO=AF.ACCTNO AND AF.CUSTID=CF.CUSTID AND  CLR1.SBDATE>=MST.TXDATE AND CLR1.SBDATE<CLR2.SBDATE AND CLR2.SBDATE>=MST.TXDATE " & ControlChars.CrLf _
            '    & "AND CLR1.CLDRTYPE=SEC.TRADEPLACE AND CLR2.CLDRTYPE=SEC.TRADEPLACE " & ControlChars.CrLf _
            '    & "AND ODMST.ACTYPE=TYP.ACTYPE AND MST.ORGORDERID=ODMST.ORDERID AND MST.CODEID=SEC.CODEID AND SEC.TRADEPLACE <> '" & gc_TRADEPLACE_OTC & "' " & ControlChars.CrLf _
            '    & "AND CLR2.SBDATE=TO_DATE('" & v_strCURRDATE & "','" & gc_FORMAT_DATE & "') AND MST.STATUS='N' AND MST.DELTD<>'Y' " & ControlChars.CrLf _
            '    & "AND (MST.DUETYPE='" & v_strDUETYPE & "' ) " & ControlChars.CrLf _
            '    & "GROUP BY MST.AUTOID, CLR2.SBDATE, MST.AFACCTNO, MST.ACCTNO " & ControlChars.CrLf _
            '    & "HAVING MIN(MST.CLEARDAY)<= " & ControlChars.CrLf _
            '    & "(CASE WHEN MIN(MST.CLEARCD)='B' THEN SUM(CASE WHEN CLR1.HOLIDAY='Y' THEN 0 ELSE 1 END) ELSE SUM(CASE WHEN CLR1.HOLIDAY='Y' THEN 1 ELSE 1 END) END)  " & ControlChars.CrLf _
            '    & "ORDER BY ORGORDERID"             'ThÃ¡Â»Â© tÃ¡Â»Â± ORDER BY lÃƒÂ  quan trÃ¡Â»?ng

            v_strSQL = "SELECT SUBSTR(MAX(CUSTODYCD),4,1) CUSTODYCD,MAX(COSTPRICE) COSTPRICE ,CLR2.SBDATE, TO_DATE('" & v_strCURRDATE & "','" & gc_FORMAT_DATE & "') CURRDATE, " & ControlChars.CrLf _
                & "SUM(CASE WHEN CLR1.HOLIDAY='Y' THEN 0 ELSE 1 END) WITHHOLIDAY,  " & ControlChars.CrLf _
                & "SUM(CASE WHEN CLR1.HOLIDAY='Y' THEN 1 ELSE 1 END) WITHOUTHOLIDAY, " & ControlChars.CrLf _
                & "MST.AUTOID, MST.AFACCTNO,MAX(ODMST.ORDERQTTY) ORGORDERQTTY,MAX(ODMST.EXECTYPE) EXECTYPE,MAX(ODMST.QUOTEPRICE) ORGQUOTEPRICE, MST.ACCTNO, MIN(MST.DUETYPE) DUETYPE, MIN(MST.TXDATE) TXDATE, MIN(MST.ORGORDERID) ORGORDERID, MIN(MST.CLEARCD) CLEARCD, MIN(MST.CLEARDAY) CLEARDAY, " & ControlChars.CrLf _
                & "MIN(SEC.CODEID) CODEID, MIN(SEC.SYMBOL) SYMBOL, MIN(SEC.PARVALUE) PARVALUE, MIN(TYP.VATRATE) VATRATE, MIN(ODMST.FEEACR-ODMST.FEEAMT) AVLFEEAMT, " & ControlChars.CrLf _
                & "MIN(MST.AMT) AMT, MIN(MST.AAMT) AAMT, MIN(MST.FAMT) FAMT, MIN(MST.QTTY) QTTY,MIN(ODMST.EXECQTTY) SQTTY , MIN(MST.AQTTY) AQTTY, ROUND(MIN(MST.AMT/MST.QTTY),4) MATCHPRICE " & ControlChars.CrLf _
                & "FROM SBCLDR CLR1, SBCLDR CLR2, (SELECT MOD.* FROM (SELECT ROWNUM INDEXROW,STSCHD.* FROM STSCHD) MOD WHERE 0=0 " & v_strBCHFillter & ") MST, ODMAST ODMST,AFMAST AF,CFMAST CF, ODTYPE TYP, SBSECURITIES SEC " & ControlChars.CrLf _
                & "WHERE ODMST.AFACCTNO=AF.ACCTNO AND AF.CUSTID=CF.CUSTID AND  CLR1.SBDATE>=MST.TXDATE AND CLR1.SBDATE<CLR2.SBDATE AND CLR2.SBDATE>=MST.TXDATE " & ControlChars.CrLf _
                & "AND CLR1.CLDRTYPE=SEC.TRADEPLACE AND CLR2.CLDRTYPE=SEC.TRADEPLACE " & ControlChars.CrLf _
                & "AND ODMST.ACTYPE=TYP.ACTYPE AND MST.ORGORDERID=ODMST.ORDERID AND MST.CODEID=SEC.CODEID AND SEC.TRADEPLACE <> '" & gc_TRADEPLACE_OTc & "' " & ControlChars.CrLf _
                & "AND CLR2.SBDATE=TO_DATE('" & v_strCURRDATE & "','" & gc_FORMAT_DATE & "') AND MST.STATUS='N' AND MST.DELTD<>'Y' " & ControlChars.CrLf _
                & "AND (MST.DUETYPE='" & v_strDUETYPE & "' ) " & ControlChars.CrLf _
                & v_strCond & ControlChars.CrLf _
                & "GROUP BY MST.AUTOID, CLR2.SBDATE, MST.AFACCTNO, MST.ACCTNO " & ControlChars.CrLf _
                & "HAVING MIN(MST.CLEARDAY)<= " & ControlChars.CrLf _
                & "(CASE WHEN MIN(MST.CLEARCD)='B' THEN SUM(CASE WHEN CLR1.HOLIDAY='Y' THEN 0 ELSE 1 END) ELSE SUM(CASE WHEN CLR1.HOLIDAY='Y' THEN 1 ELSE 1 END) END)  " & ControlChars.CrLf _
                & "ORDER BY ORGORDERID"             'ThÃ¡Â»Â© tÃ¡Â»Â± ORDER BY lÃƒÂ  quan trÃ¡Â»?ng
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

            If v_ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To v_ds.Tables(0).Rows.Count - 1 Step 1
                    'Xac dinh quoc tich
                    'v_strSQL = "SELECT SUBSTR(CUSTODYCD,4,1) CUSTODYCD FROM CFMAST CF,AFMAST AF WHERE CF.CUSTID=AF.CUSTID AND AF.ACCTNO='" & v_ds.Tables(0).Rows(i).Item("AFACCTNO") & "'"
                    'v_dsCNT = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    'If v_dsCNT.Tables(0).Rows.Count > 0 Then
                    '    If v_dsCNT.Tables(0).Rows(0)("CUSTODYCD") = "F" Then
                    '        v_blnVietnamese = False
                    '    Else
                    '        v_blnVietnamese = True
                    '    End If
                    'Else
                    '    v_blnVietnamese = True
                    'End If
                    If v_ds.Tables(0).Rows(i)("CUSTODYCD") = "F" Then
                        v_blnVietnamese = False
                    Else
                        v_blnVietnamese = True
                    End If

                    If v_strORGORDERID <> Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("ORGORDERID"))) Then
                        v_strORGORDERID = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("ORGORDERID")))
                        v_dblAVLFEEAMT = gf_CorrectNumericField(v_ds.Tables(0).Rows(i)("AVLFEEAMT"))
                    End If
                    v_dblAVLRCVAMT = gf_CorrectNumericField(v_ds.Tables(0).Rows(i)("AMT"))
                    v_dblVATRATE = gf_CorrectNumericField(v_ds.Tables(0).Rows(i)("VATRATE"))
                    'Tinh gia tri lai lo cho tu doanh
                    If v_ds.Tables(0).Rows(i)("CUSTODYCD") = "P" And v_strDUETYPE = "RM" Then
                        'Lay gia von tu doanh
                        v_dblCostprice = v_ds.Tables(0).Rows(i)("COSTPRICE")
                        If v_ds.Tables(0).Rows(i).Item("AMT") > v_dblCostprice * v_ds.Tables(0).Rows(i).Item("QTTY") Then
                            v_dblProfit = v_ds.Tables(0).Rows(i).Item("AMT") - v_dblCostprice * v_ds.Tables(0).Rows(i).Item("QTTY")
                            v_dblLoss = 0
                        Else
                            v_dblProfit = 0
                            v_dblLoss = v_dblCostprice * v_ds.Tables(0).Rows(i).Item("QTTY") - v_ds.Tables(0).Rows(i).Item("AMT")
                        End If
                    Else
                        v_dblCostprice = 0
                        v_dblProfit = 0
                        v_dblLoss = 0
                    End If
                    'If Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("DUETYPE"))) = "RM" Then
                    '    v_strSQL = "SELECT * FROM AFMAST AF,CFMAST CF,SYSVAR SYS WHERE ACCTNO='" & v_ds.Tables(0).Rows(i)("AFACCTNO") & "' AND AF.CUSTID=CF.CUSTID AND SUBSTR(CF.CUSTODYCD,1,4)=SYS.VARVALUE AND SYS.GRNAME='SYSTEM' AND SYS.VARNAME='DEALINGCUSTODYCD'"
                    '    v_dsDealing = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    '    If v_dsDealing.Tables(0).Rows.Count > 0 Then
                    '        'Lay gia von tu doanh
                    '        v_strSQL = "SELECT COSTPRICE FROM STSCHD WHERE AUTOID=" & v_ds.Tables(0).Rows(i).Item("AUTOID")
                    '        v_dsCostPrice = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    '        If v_dsCostPrice.Tables(0).Rows.Count > 0 Then
                    '            v_dblCostprice = v_dsCostPrice.Tables(0).Rows(0)("COSTPRICE")
                    '            If v_ds.Tables(0).Rows(i).Item("AMT") > v_dblCostprice * v_ds.Tables(0).Rows(i).Item("QTTY") Then
                    '                v_dblProfit = v_ds.Tables(0).Rows(i).Item("AMT") - v_dblCostprice * v_ds.Tables(0).Rows(i).Item("QTTY")
                    '                v_dblLoss = 0
                    '            Else
                    '                v_dblProfit = 0
                    '                v_dblLoss = v_dblCostprice * v_ds.Tables(0).Rows(i).Item("QTTY") - v_ds.Tables(0).Rows(i).Item("AMT")
                    '            End If
                    '        End If
                    '    End If
                    'Else
                    '    v_dblCostprice = 0
                    '    v_dblProfit = 0
                    '    v_dblLoss = 0
                    'End If



                    v_lngErrCode = BuildBatchTxMsg(v_xmlDocument, v_strBATCHNAME)
                    If Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("DUETYPE"))) = "RM" Then
                        'Nhan tien
                        v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value = gc_OD_BATCH_CIRECEIVE
                    ElseIf Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("DUETYPE"))) = "RS" Then
                        'Nhan chung khoan
                        v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value = gc_OD_BATCH_SERECEIVE
                    End If
                    'Modified by MinhTK, 17-Apr-07: Khach hang cua chi nhanh nao thi GD phai thuoc chi nhanh do
                    v_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("AFACCTNO")).Substring(0, 4)
                    'End of modified by MinhTK, 7-Apr-07
                    v_strTLTXCD = v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value
                    'Nap giao dich
                    v_strSQL = "SELECT FLDNAME, FLDTYPE, DEFNAME FROM FLDMASTER WHERE OBJNAME='" & Trim(v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value) & "' ORDER BY ODRNUM"
                    v_dsTLLOG = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

                    If v_dsTLLOG.Tables(0).Rows.Count > 0 Then
                        v_dataElement = v_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "fields", "")

                        'TÃ¡ÂºÂ¡o phÃ¡ÂºÂ§n nÃ¡Â»â„¢i dung cÃ¡Â»Â§a giao dÃ¡Â»â€¹ch
                        For j = 0 To v_dsTLLOG.Tables(0).Rows.Count - 1 Step 1
                            v_strDEFNAME = Trim(gf_CorrectStringField(v_dsTLLOG.Tables(0).Rows(j)("DEFNAME")))
                            v_strFLDNAME = Trim(gf_CorrectStringField(v_dsTLLOG.Tables(0).Rows(j)("FLDNAME")))
                            v_strFLDTYPE = Trim(gf_CorrectStringField(v_dsTLLOG.Tables(0).Rows(j)("FLDTYPE")))

                            v_entryNode = v_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "entry", "")
                            'Add field name
                            v_attrFLDNAME = v_xmlDocument.CreateAttribute(gc_AtributeFLDNAME)
                            v_attrFLDNAME.Value = v_strFLDNAME
                            v_entryNode.Attributes.Append(v_attrFLDNAME)

                            'Add field type
                            v_attrDATATYPE = v_xmlDocument.CreateAttribute(gc_AtributeFLDTYPE)
                            v_attrDATATYPE.Value = v_strFLDTYPE
                            v_entryNode.Attributes.Append(v_attrDATATYPE)

                            'Set value
                            Select Case v_strFLDNAME
                                Case "01" 'AUTOID
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("AUTOID")
                                Case "03" 'ORGORDERID
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("ORGORDERID")
                                Case "04" 'AFACCTNO
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("AFACCTNO")
                                Case "05" 'CIACCTNO
                                    Select Case v_strTLTXCD
                                        Case gc_OD_BATCH_CIRECEIVE
                                            v_strVALUE = v_ds.Tables(0).Rows(i).Item("ACCTNO")
                                        Case gc_OD_BATCH_SERECEIVE
                                            v_strVALUE = v_ds.Tables(0).Rows(i).Item("AFACCTNO")
                                    End Select
                                Case "06" 'SEACCTNO
                                    Select Case v_strTLTXCD
                                        Case gc_OD_BATCH_CIRECEIVE
                                            v_strVALUE = v_ds.Tables(0).Rows(i).Item("AFACCTNO") & v_ds.Tables(0).Rows(i).Item("CODEID")
                                        Case gc_OD_BATCH_SERECEIVE
                                            v_strVALUE = v_ds.Tables(0).Rows(i).Item("ACCTNO")
                                    End Select
                                Case "07" 'SYMBOL
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("SYMBOL")
                                Case "08" 'AMT
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("AMT")
                                Case "09" 'QTTY
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("QTTY")
                                Case "10" 'gc_OD_BATCH_SERECEIVE.MATCHPRICE,gc_OD_BATCH_CIRECEIVE.AMT
                                    Select Case v_strTLTXCD
                                        Case gc_OD_BATCH_CIRECEIVE
                                            v_strVALUE = v_ds.Tables(0).Rows(i).Item("AMT")
                                        Case gc_OD_BATCH_SERECEIVE
                                            v_strVALUE = v_ds.Tables(0).Rows(i).Item("MATCHPRICE")
                                    End Select
                                Case "11" 'gc_OD_BATCH_SERECEIVE.QTTY,gc_OD_BATCH_CIRECEIVE.AAMT
                                    Select Case v_strTLTXCD
                                        Case gc_OD_BATCH_CIRECEIVE
                                            v_strVALUE = v_ds.Tables(0).Rows(i).Item("AAMT")
                                        Case gc_OD_BATCH_SERECEIVE
                                            v_strVALUE = v_ds.Tables(0).Rows(i).Item("QTTY")
                                    End Select
                                Case "12" 'gc_OD_BATCH_SERECEIVE.PARVALUE,gc_OD_BATCH_CIRECEIVE.FEEAMT
                                    Select Case v_strTLTXCD
                                        Case gc_OD_BATCH_CIRECEIVE
                                            'If v_dblAVLFEEAMT <= v_dblAVLRCVAMT Then
                                            '    v_dblFEEAMT = v_dblAVLFEEAMT
                                            '    v_dblAVLFEEAMT = 0
                                            'Else
                                            '    v_dblFEEAMT = v_dblAVLRCVAMT
                                            '    v_dblAVLFEEAMT = v_dblAVLFEEAMT - v_dblAVLRCVAMT
                                            'End If
                                            'v_strVALUE = v_dblFEEAMT
                                            v_strVALUE = 0
                                        Case gc_OD_BATCH_SERECEIVE
                                            v_strVALUE = v_ds.Tables(0).Rows(i).Item("PARVALUE")
                                    End Select
                                Case "13" 'VAT
                                    'v_strVALUE = v_dblVATRATE * v_dblFEEAMT
                                    v_strVALUE = 0
                                Case "14" 'PROFITAMT
                                    v_strVALUE = IIf(v_dblProfit.ToString = "", "0", v_dblProfit.ToString)
                                Case "15" 'LOSSAMT
                                    v_strVALUE = IIf(v_dblLoss.ToString = "", "0", v_dblLoss.ToString)

                                Case "16" 'COSTPRICE
                                    v_strVALUE = v_dblCostprice

                                Case "30" 'DESC                                              
                                    Select Case v_strTLTXCD
                                        Case gc_OD_BATCH_CIRECEIVE
                                            If v_blnVietnamese = True Then
                                                v_strVALUE = v_str8866Desc & " " & v_ds.Tables(0).Rows(i).Item("SQTTY") & " " & v_ds.Tables(0).Rows(i).Item("SYMBOL") & " " & Strings.Mid(v_ds.Tables(0).Rows(i).Item("ORGORDERID"), 5, 2) & "/" & Strings.Mid(v_ds.Tables(0).Rows(i).Item("ORGORDERID"), 7, 2) & "/" & Strings.Mid(v_ds.Tables(0).Rows(i).Item("ORGORDERID"), 9, 2)
                                            Else
                                                v_strVALUE = v_str8866EN_Desc & " " & v_ds.Tables(0).Rows(i).Item("SQTTY") & " " & v_ds.Tables(0).Rows(i).Item("SYMBOL") & " " & Strings.Mid(v_ds.Tables(0).Rows(i).Item("ORGORDERID"), 5, 2) & "/" & Strings.Mid(v_ds.Tables(0).Rows(i).Item("ORGORDERID"), 7, 2) & "/" & Strings.Mid(v_ds.Tables(0).Rows(i).Item("ORGORDERID"), 9, 2)
                                            End If
                                        Case gc_OD_BATCH_SERECEIVE
                                            If v_blnVietnamese = True Then
                                                v_strVALUE = v_str8868Desc & " " & v_ds.Tables(0).Rows(i).Item("SQTTY") & " " & v_ds.Tables(0).Rows(i).Item("SYMBOL") & " " & Strings.Mid(v_ds.Tables(0).Rows(i).Item("ORGORDERID"), 5, 2) & "/" & Strings.Mid(v_ds.Tables(0).Rows(i).Item("ORGORDERID"), 7, 2) & "/" & Strings.Mid(v_ds.Tables(0).Rows(i).Item("ORGORDERID"), 9, 2)
                                            Else
                                                v_strVALUE = v_str8868EN_Desc & " " & v_ds.Tables(0).Rows(i).Item("SQTTY") & " " & v_ds.Tables(0).Rows(i).Item("SYMBOL") & " " & Strings.Mid(v_ds.Tables(0).Rows(i).Item("ORGORDERID"), 5, 2) & "/" & Strings.Mid(v_ds.Tables(0).Rows(i).Item("ORGORDERID"), 7, 2) & "/" & Strings.Mid(v_ds.Tables(0).Rows(i).Item("ORGORDERID"), 9, 2)
                                            End If
                                    End Select
                                Case "44" 'PARVALUE
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("PARVALUE")
                                Case "60" 'Is mortage
                                    v_strVALUE = IIf(v_ds.Tables(0).Rows(i).Item("EXECTYPE") = "MS", "1", "0")
                            End Select
                            v_entryNode.InnerText = v_strVALUE

                            v_dataElement.AppendChild(v_entryNode)
                        Next

                        v_xmlDocument.DocumentElement.AppendChild(v_dataElement)
                        'Ghi nhÃ¡ÂºÂ­n giao dÃ¡Â»â€¹ch vÃƒÂ o TLLOG
                        v_lngErrCode = v_objMessageLog.TransLog(v_xmlDocument)

                        If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode
                    End If

                Next
            End If

            'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
    Private Function ODDayReleaseAdvanced(ByVal v_strBATCHNAME As String, Optional ByVal v_strBCHFillter As String = "", Optional ByRef v_intMaxRow As Integer = 0) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = ATTR_MODULE & ".Batch.ODSettlementReceive", v_strErrorMessage As String
        Dim v_strSQL As String, v_ds, v_dsTLLOG, v_dsCNT As DataSet, v_objMessageLog As New MessageLog
        v_objMessageLog.NewDBInstance(gc_MODULE_HOST)
        Dim v_obj As New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)
        Dim i, j As Integer, v_strFRTABLE, v_strTOTABLE As String
        Dim v_xmlDocument As New Xml.XmlDocument, v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
        Dim v_strVALEXP, v_strVALUE, v_strFLDNAME, v_strDEFNAME, v_strFLDTYPE As String
        Dim v_attrFLDNAME, v_attrDATATYPE As Xml.XmlAttribute
        Dim v_strTLTXCD, v_strORGORDERID As String, v_dblFEEAMT, v_dblAVLFEEAMT, v_dblAVLRCVAMT, v_dblVATRATE As Double
        Dim v_blnVietnamese As Boolean 'Yes/No
        Try
            v_strSQL = "SELECT COUNT(*) MAXROW FROM  ADSCHD"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            v_intMaxRow = v_ds.Tables(0).Rows(0)("MAXROW")

            Dim v_strSYSVAR, v_strCURRDATE, v_strPREVDATE, v_strNEXTDATE As String
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "CURRDATE", v_strCURRDATE)
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "PREVDATE", v_strPREVDATE)
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "NEXTDATE", v_strNEXTDATE)
            If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode

            v_strSQL = "SELECT MST.AUTOID,MST.ACCTNO,MST.ISMORTAGE,MST.AMT,MST.FEEAMT+MST.BANKFEE FEEAMT,MST.VATAMT,TO_CHAR(MST.TXDATE,'DD/MM/YYYY') TXDATE FROM (SELECT MOD.* FROM (SELECT ROWNUM INDEXROW,ADSCHD.* FROM ADSCHD WHERE DELTD<>'Y') MOD WHERE 0=0 " & v_strBCHFillter & ") MST " &
                        "WHERE STATUS='N' AND CLEARDT<= TO_DATE('" & v_strCURRDATE & "','DD/MM/YYYY')  " &
                        "ORDER BY MST.AUTOID "
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

            If v_ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To v_ds.Tables(0).Rows.Count - 1 Step 1
                    'Xac dinh quoc tich
                    v_strSQL = "SELECT SUBSTR(CUSTODYCD,4,1) CUSTODYCD FROM CFMAST CF,AFMAST AF WHERE CF.CUSTID=AF.CUSTID AND AF.ACCTNO='" & v_ds.Tables(0).Rows(i).Item("ACCTNO") & "'"
                    v_dsCNT = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_dsCNT.Tables(0).Rows.Count > 0 Then
                        If v_dsCNT.Tables(0).Rows(0)("CUSTODYCD") = "F" Then
                            v_blnVietnamese = False
                        Else
                            v_blnVietnamese = True
                        End If
                    Else
                        v_blnVietnamese = True
                    End If
                    v_lngErrCode = BuildBatchTxMsg(v_xmlDocument, v_strBATCHNAME)
                    v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value = gc_OD_BATCH_RLS_DAY_ADVANCEd
                    v_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("ACCTNO")).Substring(0, 4)
                    v_strTLTXCD = v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value


                    v_strSQL = "SELECT FLDNAME, FLDTYPE, DEFNAME FROM FLDMASTER WHERE TRIM(OBJNAME)='" & Trim(v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value) & "' ORDER BY ODRNUM"
                    v_dsTLLOG = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_dsTLLOG.Tables(0).Rows.Count > 0 Then
                        v_dataElement = v_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "fields", "")

                        For j = 0 To v_dsTLLOG.Tables(0).Rows.Count - 1 Step 1
                            v_strDEFNAME = Trim(gf_CorrectStringField(v_dsTLLOG.Tables(0).Rows(j)("DEFNAME")))
                            v_strFLDNAME = Trim(gf_CorrectStringField(v_dsTLLOG.Tables(0).Rows(j)("FLDNAME")))
                            v_strFLDTYPE = Trim(gf_CorrectStringField(v_dsTLLOG.Tables(0).Rows(j)("FLDTYPE")))

                            v_entryNode = v_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "entry", "")
                            'Add field name
                            v_attrFLDNAME = v_xmlDocument.CreateAttribute(gc_AtributeFLDNAME)
                            v_attrFLDNAME.Value = v_strFLDNAME
                            v_entryNode.Attributes.Append(v_attrFLDNAME)

                            'Add field type
                            v_attrDATATYPE = v_xmlDocument.CreateAttribute(gc_AtributeFLDTYPE)
                            v_attrDATATYPE.Value = v_strFLDTYPE
                            v_entryNode.Attributes.Append(v_attrDATATYPE)

                            'Set value
                            Select Case v_strFLDNAME
                                Case "09" 'AUTOID
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("AUTOID")
                                Case "03" 'ACCTNO
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("ACCTNO")
                                Case "10" 'PAIDAMT
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("AMT")
                                Case "11" 'PAIDFEEAMT
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("FEEAMT")
                                Case "30" 'DESC                                              
                                    If v_blnVietnamese = True Then
                                        'nGUOI VIET
                                        v_strVALUE = "Tra UTTB ngay " & v_ds.Tables(0).Rows(i).Item("TXDATE")
                                    Else
                                        'NGUOI ANH
                                        v_strVALUE = "Advanced payment" & " " & v_ds.Tables(0).Rows(i).Item("TXDATE")
                                    End If
                                Case "60" 'Is Mortage
                                    'v_strVALUE = IIf(v_ds.Tables(0).Rows(i).Item("ISMORTAGE") = "Y", "1", "0")
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("ISMORTAGE")
                            End Select
                            v_entryNode.InnerText = v_strVALUE
                            v_dataElement.AppendChild(v_entryNode)
                        Next
                        v_xmlDocument.DocumentElement.AppendChild(v_dataElement)
                        'Ghi nhÃ¡ÂºÂ­n giao dÃ¡Â»â€¹ch vÃƒÂ� o TLLOG
                        v_lngErrCode = v_objMessageLog.TransLog(v_xmlDocument)

                        If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode
                    End If
                Next
            End If
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function ODReleaseBlockAdvanced(ByVal v_strBATCHNAME As String, Optional ByVal v_strBCHFillter As String = "", Optional ByRef v_intMaxRow As Integer = 0) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = ATTR_MODULE & ".Batch.ODReleaseBlockAdvanced", v_strErrorMessage As String
        Dim v_strSQL As String, v_ds, v_dsTLLOG, v_dsCNT As DataSet, v_objMessageLog As New MessageLog
        v_objMessageLog.NewDBInstance(gc_MODULE_HOST)
        Dim v_obj As New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)
        Dim i, j As Integer, v_strFRTABLE, v_strTOTABLE As String
        Dim v_xmlDocument As New Xml.XmlDocument, v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
        Dim v_strVALEXP, v_strVALUE, v_strFLDNAME, v_strDEFNAME, v_strFLDTYPE As String
        Dim v_attrFLDNAME, v_attrDATATYPE As Xml.XmlAttribute
        Dim v_strTLTXCD, v_strORGORDERID As String, v_dblFEEAMT, v_dblAVLFEEAMT, v_dblAVLRCVAMT, v_dblVATRATE As Double
        Dim v_str8861Desc, v_str8861ENDesc As String
        Dim v_blnVietnamese As Boolean 'Yes/No
        Dim v_strRCVMDAY As String
        Try
            'LÃ¡ÂºÂ¥y giÃƒÂ¡ trÃ¡Â»â€¹ cÃ¡Â»Â±c Ã„â€˜Ã¡ÂºÂ¡i trÃ¡ÂºÂ£ vÃ¡Â»? trong phÃƒÂ¢n trang
            v_strSQL = "SELECT COUNT(*) MAXROW FROM  STSCHD"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            v_intMaxRow = v_ds.Tables(0).Rows(0)("MAXROW")
            'LÃ¡ÂºÂ¥y tham sÃ¡Â»â€˜ hÃ¡Â»â€¡ thÃ¡Â»â€˜ng
            Dim v_strSYSVAR, v_strCURRDATE, v_strPREVDATE, v_strNEXTDATE As String
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "CURRDATE", v_strCURRDATE)
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "PREVDATE", v_strPREVDATE)
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "NEXTDATE", v_strNEXTDATE)
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "RCVMDAY", v_strRCVMDAY)
            If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode
            'Lay ra cac dien giai mac dinh cho cac giao dich
            'Dien giai 8861
            v_strSQL = "SELECT TXDESC,EN_TXDESC FROM  TLTX WHERE TLTXCD='" & gc_OD_BATCH_RLS_ADVANCEd & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            v_str8861Desc = v_ds.Tables(0).Rows(0)("TXDESC")
            v_str8861ENDesc = v_ds.Tables(0).Rows(0)("EN_TXDESC")

            Dim v_strCond As String
            If v_strBATCHNAME = "ODRLSADV" Then
                v_strCond = "AND MST.CLEARDAY <> " & v_strRCVMDAY & " "
            ElseIf v_strBATCHNAME = "ODRLSADVT3" Then
                v_strCond = "AND MST.CLEARDAY = " & v_strRCVMDAY & " "
            End If

            '1. XÃ¡Â»Â­ lÃƒÂ½ giÃ¡ÂºÂ£i toÃ¡ÂºÂ£ Ã¡Â»Â©ng trÃ†Â°Ã¡Â»â€ºc theo lÃ¡Â»â€¹ch STSCHD: T+x

            v_strSQL = "SELECT MST.AUTOID,MST.ORGORDERID,SB.SYMBOL,MST.QTTY,ODMST.EXECQTTY SQTTY ,MST.AFACCTNO,MST.AAMT-MST.PAIDAMT AMT,MST.FAMT-MST.PAIDFEEAMT FEEAMT,ODMST.TXDATE,ODMST.EXECTYPE " &
                       "FROM (SELECT MOD.* FROM (SELECT ROWNUM INDEXROW,STSCHD.* FROM STSCHD) MOD WHERE 0=0 " & v_strBCHFillter & ") MST,ODMAST ODMST,SBSECURITIES SB WHERE DUETYPE='RM' AND MST.STATUS='C' AND MST.AAMT-MST.PAIDAMT+MST.FAMT-MST.PAIDFEEAMT>0" &
                       "AND MST.DELTD<>'Y' AND MST.CODEID=SB.CODEID and MST.ORGORDERID=ODMST.ORDERID AND ODMST.EXECTYPE = 'MS' " &
                       "AND GETDUEDATE(MST.TXDATE,MST.CLEARCD,SB.TRADEPLACE,MST.CLEARDAY)>=TO_DATE('" & v_strCURRDATE & "','DD/MM/YYYY') " & v_strCond &
                       "ORDER BY MST.ORGORDERID" 'ThÃ¡Â»Â© tÃ¡Â»Â± ORDER BY lÃƒÂ  quan trÃ¡Â»?ng
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

            If v_ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To v_ds.Tables(0).Rows.Count - 1 Step 1
                    'Xac dinh quoc tich
                    v_strSQL = "SELECT SUBSTR(CUSTODYCD,4,1) CUSTODYCD FROM CFMAST CF,AFMAST AF WHERE CF.CUSTID=AF.CUSTID AND AF.ACCTNO='" & v_ds.Tables(0).Rows(i).Item("AFACCTNO") & "'"
                    v_dsCNT = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_dsCNT.Tables(0).Rows.Count > 0 Then
                        If v_dsCNT.Tables(0).Rows(0)("CUSTODYCD") = "F" Then
                            v_blnVietnamese = False
                        Else
                            v_blnVietnamese = True
                        End If
                    Else
                        v_blnVietnamese = True
                    End If
                    v_lngErrCode = BuildBatchTxMsg(v_xmlDocument, v_strBATCHNAME)
                    v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value = gc_OD_BATCH_RLS_ADVANCEd
                    'Modified by MinhTK, 17-Apr-07: Khach hang cua chi nhanh nao thi GD phai thuoc chi nhanh do
                    v_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("AFACCTNO")).Substring(0, 4)
                    'End of modified by MinhTK, 7-Apr-07
                    v_strTLTXCD = v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value

                    'NÃ¡ÂºÂ¡p giao dÃ¡Â»â€¹ch
                    v_strSQL = "SELECT FLDNAME, FLDTYPE, DEFNAME FROM FLDMASTER WHERE OBJNAME='" & Trim(v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value) & "' ORDER BY ODRNUM"
                    v_dsTLLOG = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_dsTLLOG.Tables(0).Rows.Count > 0 Then
                        v_dataElement = v_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "fields", "")

                        'TÃ¡ÂºÂ¡o phÃ¡ÂºÂ§n nÃ¡Â»â„¢i dung cÃ¡Â»Â§a giao dÃ¡Â»â€¹ch
                        For j = 0 To v_dsTLLOG.Tables(0).Rows.Count - 1 Step 1
                            v_strDEFNAME = Trim(gf_CorrectStringField(v_dsTLLOG.Tables(0).Rows(j)("DEFNAME")))
                            v_strFLDNAME = Trim(gf_CorrectStringField(v_dsTLLOG.Tables(0).Rows(j)("FLDNAME")))
                            v_strFLDTYPE = Trim(gf_CorrectStringField(v_dsTLLOG.Tables(0).Rows(j)("FLDTYPE")))

                            v_entryNode = v_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "entry", "")
                            'Add field name
                            v_attrFLDNAME = v_xmlDocument.CreateAttribute(gc_AtributeFLDNAME)
                            v_attrFLDNAME.Value = v_strFLDNAME
                            v_entryNode.Attributes.Append(v_attrFLDNAME)

                            'Add field type
                            v_attrDATATYPE = v_xmlDocument.CreateAttribute(gc_AtributeFLDTYPE)
                            v_attrDATATYPE.Value = v_strFLDTYPE
                            v_entryNode.Attributes.Append(v_attrDATATYPE)

                            'Set value
                            Select Case v_strFLDNAME
                                Case "09" 'AUTOID
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("AUTOID")
                                Case "05" 'ORGORDERID
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("ORGORDERID")
                                Case "03" 'ACCTNO
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("AFACCTNO")
                                Case "10" 'PAIDAMT
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("AMT")
                                Case "11" 'PAIDFEEAMT
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("FEEAMT")
                                Case "30" 'DESC                                              

                                    If v_blnVietnamese = True Then
                                        'nGUOI VIET
                                        v_strVALUE = "Tra UTTB cua lenh " & v_ds.Tables(0).Rows(i).Item("SYMBOL") & " so " & Strings.Right(v_ds.Tables(0).Rows(i).Item("ORGORDERID"), 6) & " khop ngay " & v_ds.Tables(0).Rows(i).Item("TXDATE")
                                    Else
                                        'NGUOI ANH
                                        v_strVALUE = v_str8861ENDesc & " " & v_ds.Tables(0).Rows(i).Item("SQTTY") & " " & v_ds.Tables(0).Rows(i).Item("SYMBOL") & " " & Strings.Mid(v_ds.Tables(0).Rows(i).Item("ORGORDERID"), 5, 2) & "/" & Strings.Mid(v_ds.Tables(0).Rows(i).Item("ORGORDERID"), 7, 2) & "/" & Strings.Mid(v_ds.Tables(0).Rows(i).Item("ORGORDERID"), 9, 2)
                                    End If
                                Case "60" 'Is Mortage
                                    v_strVALUE = IIf(v_ds.Tables(0).Rows(i).Item("EXECTYPE") = "MS", "1", "0")
                            End Select
                            v_entryNode.InnerText = v_strVALUE
                            v_dataElement.AppendChild(v_entryNode)
                        Next
                        v_xmlDocument.DocumentElement.AppendChild(v_dataElement)
                        'Ghi nhÃ¡ÂºÂ­n giao dÃ¡Â»â€¹ch vÃƒÂ o TLLOG
                        v_lngErrCode = v_objMessageLog.TransLog(v_xmlDocument)

                        If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode
                    End If
                Next
            End If
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function ODReleaseAdvanced(ByVal v_strBATCHNAME As String, Optional ByVal v_strBCHFillter As String = "", Optional ByRef v_intMaxRow As Integer = 0) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = ATTR_MODULE & ".Batch.ODSettlementReceive", v_strErrorMessage As String
        Dim v_strSQL As String, v_ds, v_dsTLLOG, v_dsCNT As DataSet, v_objMessageLog As New MessageLog
        v_objMessageLog.NewDBInstance(gc_MODULE_HOST)
        Dim v_obj As New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)
        Dim i, j As Integer, v_strFRTABLE, v_strTOTABLE As String
        Dim v_xmlDocument As New Xml.XmlDocument, v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
        Dim v_strVALEXP, v_strVALUE, v_strFLDNAME, v_strDEFNAME, v_strFLDTYPE As String
        Dim v_attrFLDNAME, v_attrDATATYPE As Xml.XmlAttribute
        Dim v_strTLTXCD, v_strORGORDERID As String, v_dblFEEAMT, v_dblAVLFEEAMT, v_dblAVLRCVAMT, v_dblVATRATE As Double
        Dim v_str8861Desc, v_str8861ENDesc As String
        Dim v_blnVietnamese As Boolean 'Yes/No
        Dim v_strRCVMDAY As String
        Try
            'LÃ¡ÂºÂ¥y giÃƒÂ¡ trÃ¡Â»â€¹ cÃ¡Â»Â±c Ã„â€˜Ã¡ÂºÂ¡i trÃ¡ÂºÂ£ vÃ¡Â»? trong phÃƒÂ¢n trang
            v_strSQL = "SELECT COUNT(*) MAXROW FROM  STSCHD"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            v_intMaxRow = v_ds.Tables(0).Rows(0)("MAXROW")
            'LÃ¡ÂºÂ¥y tham sÃ¡Â»â€˜ hÃ¡Â»â€¡ thÃ¡Â»â€˜ng
            Dim v_strSYSVAR, v_strCURRDATE, v_strPREVDATE, v_strNEXTDATE As String
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "CURRDATE", v_strCURRDATE)
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "PREVDATE", v_strPREVDATE)
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "NEXTDATE", v_strNEXTDATE)
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "RCVMDAY", v_strRCVMDAY)
            If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode
            'Lay ra cac dien giai mac dinh cho cac giao dich
            'Dien giai 8861
            v_strSQL = "SELECT TXDESC,EN_TXDESC FROM  TLTX WHERE TLTXCD='" & gc_OD_BATCH_RLS_ADVANCEd & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            v_str8861Desc = v_ds.Tables(0).Rows(0)("TXDESC")
            v_str8861ENDesc = v_ds.Tables(0).Rows(0)("EN_TXDESC")

            Dim v_strCond As String
            If v_strBATCHNAME = "ODRLSADV" Then
                v_strCond = "AND MST.CLEARDAY <> " & v_strRCVMDAY & " "
            ElseIf v_strBATCHNAME = "ODRLSADVT3" Then
                v_strCond = "AND MST.CLEARDAY = " & v_strRCVMDAY & " "
            End If

            '1. XÃ¡Â»Â­ lÃƒÂ½ giÃ¡ÂºÂ£i toÃ¡ÂºÂ£ Ã¡Â»Â©ng trÃ†Â°Ã¡Â»â€ºc theo lÃ¡Â»â€¹ch STSCHD: T+x

            v_strSQL = "SELECT MST.AUTOID,MST.ORGORDERID,SB.SYMBOL,MST.QTTY,ODMST.EXECQTTY SQTTY ,MST.AFACCTNO,MST.AAMT-MST.PAIDAMT AMT,MST.FAMT-MST.PAIDFEEAMT FEEAMT,ODMST.TXDATE,ODMST.EXECTYPE " &
                       "FROM (SELECT MOD.* FROM (SELECT ROWNUM INDEXROW,STSCHD.* FROM STSCHD) MOD WHERE 0=0 " & v_strBCHFillter & ") MST,ODMAST ODMST,SBSECURITIES SB WHERE DUETYPE='RM' AND MST.STATUS='C' AND MST.AAMT-MST.PAIDAMT+MST.FAMT-MST.PAIDFEEAMT>0" &
                       "AND MST.DELTD<>'Y' AND MST.CODEID=SB.CODEID and MST.ORGORDERID=ODMST.ORDERID " &
                       "AND GETDUEDATE(MST.TXDATE,MST.CLEARCD,SB.TRADEPLACE,MST.CLEARDAY)>=TO_DATE('" & v_strCURRDATE & "','DD/MM/YYYY') " & v_strCond &
                       "ORDER BY MST.ORGORDERID" 'ThÃ¡Â»Â© tÃ¡Â»Â± ORDER BY lÃƒÂ  quan trÃ¡Â»?ng
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

            If v_ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To v_ds.Tables(0).Rows.Count - 1 Step 1
                    'Xac dinh quoc tich
                    v_strSQL = "SELECT SUBSTR(CUSTODYCD,4,1) CUSTODYCD FROM CFMAST CF,AFMAST AF WHERE CF.CUSTID=AF.CUSTID AND AF.ACCTNO='" & v_ds.Tables(0).Rows(i).Item("AFACCTNO") & "'"
                    v_dsCNT = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_dsCNT.Tables(0).Rows.Count > 0 Then
                        If v_dsCNT.Tables(0).Rows(0)("CUSTODYCD") = "F" Then
                            v_blnVietnamese = False
                        Else
                            v_blnVietnamese = True
                        End If
                    Else
                        v_blnVietnamese = True
                    End If
                    v_lngErrCode = BuildBatchTxMsg(v_xmlDocument, v_strBATCHNAME)
                    v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value = gc_OD_BATCH_RLS_ADVANCEd
                    'Modified by MinhTK, 17-Apr-07: Khach hang cua chi nhanh nao thi GD phai thuoc chi nhanh do
                    v_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("AFACCTNO")).Substring(0, 4)
                    'End of modified by MinhTK, 7-Apr-07
                    v_strTLTXCD = v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value

                    'NÃ¡ÂºÂ¡p giao dÃ¡Â»â€¹ch
                    v_strSQL = "SELECT FLDNAME, FLDTYPE, DEFNAME FROM FLDMASTER WHERE OBJNAME='" & Trim(v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value) & "' ORDER BY ODRNUM"
                    v_dsTLLOG = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_dsTLLOG.Tables(0).Rows.Count > 0 Then
                        v_dataElement = v_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "fields", "")

                        'TÃ¡ÂºÂ¡o phÃ¡ÂºÂ§n nÃ¡Â»â„¢i dung cÃ¡Â»Â§a giao dÃ¡Â»â€¹ch
                        For j = 0 To v_dsTLLOG.Tables(0).Rows.Count - 1 Step 1
                            v_strDEFNAME = Trim(gf_CorrectStringField(v_dsTLLOG.Tables(0).Rows(j)("DEFNAME")))
                            v_strFLDNAME = Trim(gf_CorrectStringField(v_dsTLLOG.Tables(0).Rows(j)("FLDNAME")))
                            v_strFLDTYPE = Trim(gf_CorrectStringField(v_dsTLLOG.Tables(0).Rows(j)("FLDTYPE")))

                            v_entryNode = v_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "entry", "")
                            'Add field name
                            v_attrFLDNAME = v_xmlDocument.CreateAttribute(gc_AtributeFLDNAME)
                            v_attrFLDNAME.Value = v_strFLDNAME
                            v_entryNode.Attributes.Append(v_attrFLDNAME)

                            'Add field type
                            v_attrDATATYPE = v_xmlDocument.CreateAttribute(gc_AtributeFLDTYPE)
                            v_attrDATATYPE.Value = v_strFLDTYPE
                            v_entryNode.Attributes.Append(v_attrDATATYPE)

                            'Set value
                            Select Case v_strFLDNAME
                                Case "09" 'AUTOID
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("AUTOID")
                                Case "05" 'ORGORDERID
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("ORGORDERID")
                                Case "03" 'ACCTNO
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("AFACCTNO")
                                Case "10" 'PAIDAMT
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("AMT")
                                Case "11" 'PAIDFEEAMT
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("FEEAMT")
                                Case "30" 'DESC                                              

                                    If v_blnVietnamese = True Then
                                        'nGUOI VIET
                                        'v_strVALUE = v_str8861Desc & " " & v_ds.Tables(0).Rows(i).Item("SQTTY") & " " & v_ds.Tables(0).Rows(i).Item("SYMBOL") & " " & Strings.Mid(v_ds.Tables(0).Rows(i).Item("ORGORDERID"), 5, 2) & "/" & Strings.Mid(v_ds.Tables(0).Rows(i).Item("ORGORDERID"), 7, 2) & "/" & Strings.Mid(v_ds.Tables(0).Rows(i).Item("ORGORDERID"), 9, 2)
                                        v_strVALUE = "Tra UTTB cua lenh " & v_ds.Tables(0).Rows(i).Item("SYMBOL") & " so " & Strings.Right(v_ds.Tables(0).Rows(i).Item("ORGORDERID"), 6) & " khop ngay " & v_ds.Tables(0).Rows(i).Item("TXDATE")
                                    Else
                                        'NGUOI ANH
                                        v_strVALUE = v_str8861ENDesc & " " & v_ds.Tables(0).Rows(i).Item("SQTTY") & " " & v_ds.Tables(0).Rows(i).Item("SYMBOL") & " " & Strings.Mid(v_ds.Tables(0).Rows(i).Item("ORGORDERID"), 5, 2) & "/" & Strings.Mid(v_ds.Tables(0).Rows(i).Item("ORGORDERID"), 7, 2) & "/" & Strings.Mid(v_ds.Tables(0).Rows(i).Item("ORGORDERID"), 9, 2)
                                        'v_strVALUE = "Paid UTTB cua lenh " & v_ds.Tables(0).Rows(i).Item("SYMBOL") & " so " & Strings.Right(v_ds.Tables(0).Rows(i).Item("ORGORDERID"), 6) & " khop ngay " & v_ds.Tables(0).Rows(i).Item("TXDATE")
                                    End If
                                Case "60" 'Is Mortage
                                    v_strVALUE = IIf(v_ds.Tables(0).Rows(i).Item("EXECTYPE") = "MS", "1", "0")
                            End Select
                            v_entryNode.InnerText = v_strVALUE
                            v_dataElement.AppendChild(v_entryNode)
                        Next
                        v_xmlDocument.DocumentElement.AppendChild(v_dataElement)
                        'Ghi nhÃ¡ÂºÂ­n giao dÃ¡Â»â€¹ch vÃƒÂ o TLLOG
                        v_lngErrCode = v_objMessageLog.TransLog(v_xmlDocument)

                        If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode
                    End If
                Next
            End If
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function OrderFinish() As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = ATTR_MODULE & ".Batch.OrderFisish", v_strErrorMessage As String
        Dim v_strSQL As String, v_ds As DataSet
        Dim v_obj As New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)
        Dim i, j As Integer
        Dim v_intdays As Integer
        Dim v_strErr_Out As String
        Dim v_strMessage As String
        Try
            'X�y d?ng c�c tham s? h? th?ng
            Dim v_strCURRDATE As String
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "CURRDATE", v_strCURRDATE)
            If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode
            'Goi thu tuc de thuc hien day vao he thong giao dich luon.
            Dim v_objParam As StoreParameter
            Dim v_arrPara(1) As StoreParameter
            v_objParam = New StoreParameter
            v_objParam.ParamName = "INDATE"
            v_objParam.ParamValue = v_strCURRDATE
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamSize = 10
            v_objParam.ParamType = "String"
            v_arrPara(0) = v_objParam
            v_objParam = New StoreParameter
            v_objParam.ParamName = "ERR_CODE"
            v_objParam.ParamDirection = ParameterDirection.Output
            v_objParam.ParamValue = v_strErr_Out
            v_objParam.ParamSize = 20
            v_objParam.ParamType = "String"
            v_arrPara(1) = v_objParam
            'v_obj.ExecuteStoredNonQuerry("BATCHORDERFINISH", v_arrPara)
            v_strMessage = v_obj.ExecuteOracleStored("BATCHORDERFINISH", v_arrPara, 1)
            v_lngErrCode = CDbl(v_strMessage)
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function OrderCleanUp() As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = ATTR_MODULE & ".Batch.OrderCleanUp", v_strErrorMessage As String
        Dim v_strSQL As String, v_ds As DataSet
        Dim v_obj As New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)
        Dim i, j As Integer
        Dim v_intdays As Integer
        Dim v_strErr_Out As String
        Dim v_strMessage As String
        Try
            'X�y d?ng c�c tham s? h? th?ng
            Dim v_strCURRDATE As String
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "CURRDATE", v_strCURRDATE)
            If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode
            'Goi thu tuc de thuc hien day vao he thong giao dich luon.
            Dim v_objParam As StoreParameter
            Dim v_arrPara(1) As StoreParameter
            v_objParam = New StoreParameter
            v_objParam.ParamName = "INDATE"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamValue = v_strCURRDATE
            v_objParam.ParamSize = 10
            v_objParam.ParamType = "String"
            v_arrPara(0) = v_objParam
            'v_obj.ExecuteStoredNonQuerry("ORDERCLEANUP", v_arrPara)
            v_objParam = New StoreParameter
            v_objParam.ParamName = "ERR_CODE"
            v_objParam.ParamDirection = ParameterDirection.Output
            v_objParam.ParamValue = v_strErr_Out
            v_objParam.ParamSize = 20
            v_objParam.ParamType = "String"
            v_arrPara(1) = v_objParam
            v_strMessage = v_obj.ExecuteOracleStored("ORDERCLEANUP", v_arrPara, 1)
            v_lngErrCode = CDbl(v_strMessage)
            'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function


    Private Function SimpleTradingFeeCalculate() As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = ATTR_MODULE & ".Batch.OrderCleanUp", v_strErrorMessage As String
        Dim v_strSQL As String, v_ds As DataSet
        Dim v_obj As New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)
        Dim i, j As Integer
        Dim v_intdays As Integer
        Dim v_strErr_Out As String
        Dim v_strMessage As String
        Try
            'X�y d?ng c�c tham s? h? th?ng
            Dim v_strCURRDATE As String
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "CURRDATE", v_strCURRDATE)
            If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode
            'Goi thu tuc de thuc hien day vao he thong giao dich luon.
            Dim v_objParam As StoreParameter
            Dim v_arrPara(1) As StoreParameter
            v_objParam = New StoreParameter
            v_objParam.ParamName = "INDATE"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamValue = v_strCURRDATE
            v_objParam.ParamSize = 10
            v_objParam.ParamType = "String"
            v_arrPara(0) = v_objParam
            'v_obj.ExecuteStoredNonQuerry("SIMPLEORDERFEECALCULATE", v_arrPara)
            v_objParam = New StoreParameter
            v_objParam.ParamName = "ERR_CODE"
            v_objParam.ParamDirection = ParameterDirection.Output
            v_objParam.ParamValue = v_strErr_Out
            v_objParam.ParamSize = 20
            v_objParam.ParamType = "String"
            v_arrPara(1) = v_objParam
            v_strMessage = v_obj.ExecuteOracleStored("SIMPLEORDERFEECALCULATE", v_arrPara, 1)
            v_lngErrCode = CDbl(v_strMessage)
            'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

#End Region

End Class
