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
        ATTR_MODULE = "RM"
    End Sub

    'Hàm thực hiện chạy xử lý Batch của phân hệ nghiệp vụ
    Overrides Function ExecuteRouter(ByVal v_strBCHMDL As String, Optional ByVal v_strBCHFillter As String = "", Optional ByRef v_intMaxRow As Integer = 0) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = ATTR_MODULE & ".Batch.ExecuteRouter", v_strErrorMessage As String
        Dim v_strxmlMessage As String, v_xmlMessage As New Xml.XmlDocument
        Try
            'Chuyển đến các bước chạy xử lý của phân hệ nghiệp vụ
            Select Case v_strBCHMDL
                Case "BAMTTRF"
                    v_lngErrCode = BuyAmountTransfer(v_strBCHMDL, v_strBCHFillter, v_intMaxRow)
                Case "SAMTTRF"
                    v_lngErrCode = SaleAmountTransfer(v_strBCHMDL, v_strBCHFillter, v_intMaxRow)
                Case "BFEETRF"
                    v_lngErrCode = BuyFeeTransfer(v_strBCHMDL, v_strBCHFillter, v_intMaxRow)
                Case "SFEETRF"
                    v_lngErrCode = SaleFeeTransfer(v_strBCHMDL, v_strBCHFillter, v_intMaxRow)
                Case "RMEXCA3384"
                    v_lngErrCode = Execute3384(v_strBCHMDL, v_strBCHFillter, v_intMaxRow)
                Case "RMEXCA3386"
                    v_lngErrCode = Execute3386(v_strBCHMDL, v_strBCHFillter, v_intMaxRow)
                Case "RMEXCA3350"
                    v_lngErrCode = Execute33503354(v_strBCHMDL, v_strBCHFillter, v_intMaxRow)
                Case "RMEXCA3350DF"
                    v_lngErrCode = Execute33503354DutyFee(v_strBCHMDL, v_strBCHFillter, v_intMaxRow)
                Case "RMEX8879"
                    v_lngErrCode = Execute8879(v_strBCHMDL, v_strBCHFillter, v_intMaxRow)
                Case "RMEX8879DF"
                    v_lngErrCode = Execute8879DutyFee(v_strBCHMDL, v_strBCHFillter, v_intMaxRow)
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
    Public Function BuyAmountTransfer(ByVal v_strBATCHNAME As String, Optional ByVal v_strBCHFillter As String = "", Optional ByRef v_intMaxRow As Integer = 0) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = ATTR_MODULE & ".Batch.BuyAmountTransfer", v_strErrorMessage As String
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
        Dim v_htAmount As New Hashtable
        Dim v_dblRemain, v_dblAmount, v_dblQueue As Double

        Try
            'Lay thong tin phan trang
            v_strSQL = "SELECT COUNT(*) MAXROW FROM  ODMAST"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            v_intMaxRow = v_ds.Tables(0).Rows(0)("MAXROW")
            'Lay thong tin sysvar
            Dim v_strSYSVAR, v_strCURRDATE, v_strPREVDATE, v_strNEXTDATE As String
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "CURRDATE", v_strCURRDATE)
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "PREVDATE", v_strPREVDATE)
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "NEXTDATE", v_strNEXTDATE)
            If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode

            Dim v_strBeginDate As String = GetConfigValue("SYSTEMSTARTDATE", DateTime.Now.AddDays(-30).ToString("dd/MM/yyyy"))

            v_strSQL = "SELECT * FROM" & vbCrLf &
                        "(" & vbCrLf &
                        "    SELECT CRA.TRFCODE TRFTYPE,CIT.REF ORDERID,SB.SYMBOL,OD.EXECQTTY," & vbCrLf &
                        "    CIT.ACCTNO AFACCTNO,AF.ACCTNO||OD.CODEID SEACCTNO,AF.BANKACCTNO,CRA.REFACCTNO DESACCTNO," & vbCrLf &
                        "    AF.BANKNAME BANKCODE,AF.BANKNAME || ':' || CRB.BANKNAME BANKNAME,CIT.NAMT AMOUNT" & vbCrLf &
                        "    FROM (" & vbCrLf &
                        "        SELECT TXDATE,TXNUM,ACCTNO,TXCD,REF,AUTOID,TLTXCD,NAMT FROM CITRAN" & vbCrLf &
                        "        WHERE DELTD='N' AND TLTXCD='8889' AND TXCD='0011'" & vbCrLf &
                        "        UNION ALL" & vbCrLf &
                        "        SELECT TXDATE,TXNUM,ACCTNO,TXCD,REF,AUTOID,TLTXCD,NAMT FROM CITRANA" & vbCrLf &
                        "        WHERE DELTD='N' AND TLTXCD='8889' AND TXCD='0011' " & vbCrLf &
                        "        AND TXDATE>=TO_DATE('" & v_strBeginDate & "','DD/MM/RRRR')" & vbCrLf &
                        "    ) CIT, (" & vbCrLf &
                        "        SELECT ORDERID,CODEID,TXDATE,TXNUM,EXECQTTY FROM ODMAST" & vbCrLf &
                        "        WHERE DELTD='N' AND EXECTYPE IN ('NB','BC','NS','MS')" & vbCrLf &
                        "        UNION ALL" & vbCrLf &
                        "        SELECT ORDERID,CODEID,TXDATE,TXNUM,EXECQTTY FROM ODMASTHIST" & vbCrLf &
                        "        WHERE DELTD='N' AND EXECTYPE IN ('NB','BC','NS','MS')" & vbCrLf &
                        "        AND TXDATE>=TO_DATE('" & v_strBeginDate & "','DD/MM/RRRR')" & vbCrLf &
                        "    ) OD,SECURITIES_INFO SB,AFMAST AF,CRBDEFACCT CRA,CRBDEFBANK CRB, CIMAST CI" & vbCrLf &
                        "    WHERE CIT.ACCTNO=AF.ACCTNO AND CI.AFACCTNO=AF.ACCTNO AND CI.COREBANK='Y'" & vbCrLf &
                        "    AND AF.BANKNAME=CRA.REFBANK AND CRA.TRFCODE='TRFODBUY'" & vbCrLf &
                        "    AND AF.BANKNAME=CRB.BANKCODE AND CIT.REF=OD.ORDERID" & vbCrLf &
                        "    AND OD.CODEID=SB.CODEID AND CIT.REF NOT IN" & vbCrLf &
                        "    (" & vbCrLf &
                        "            SELECT REQX.CVAL ORDERID" & vbCrLf &
                        "            FROM CRBTXREQDTL REQX,CRBTXREQ REQ" & vbCrLf &
                        "            WHERE REQX.REQID=REQ.REQID AND REQX.FLDNAME='ORDERID'" & vbCrLf &
                        "            AND REQ.STATUS IN ('C','P') " & vbCrLf &
                        "            AND REQ.TRFCODE ='TRFODBUY'" & vbCrLf &
                        "    )" & vbCrLf &
                        "    UNION ALL" & vbCrLf &
                        "    SELECT CRA.TRFCODE TRFTYPE,CIT.REF ORDERID,SB.SYMBOL,OD.EXECQTTY," & vbCrLf &
                        "    CIT.ACCTNO AFACCTNO,AF.ACCTNO||OD.CODEID SEACCTNO,AF.BANKACCTNO,CRA.REFACCTNO DESACCTNO," & vbCrLf &
                        "    AF.BANKNAME BANKCODE,AF.BANKNAME || ':' || CRB.BANKNAME BANKNAME,CIT.NAMT AMOUNT" & vbCrLf &
                        "    FROM (" & vbCrLf &
                        "        SELECT TXDATE,TXNUM,ACCTNO,TXCD,REF,AUTOID,TLTXCD,NAMT FROM CITRAN" & vbCrLf &
                        "        WHERE DELTD='N' AND TLTXCD='8865' AND TXCD='0011'" & vbCrLf &
                        "        UNION ALL" & vbCrLf &
                        "        SELECT TXDATE,TXNUM,ACCTNO,TXCD,REF,AUTOID,TLTXCD,NAMT FROM CITRANA" & vbCrLf &
                        "        WHERE DELTD='N' AND TLTXCD='8865' AND TXCD='0011' " & vbCrLf &
                        "        AND TXDATE>=TO_DATE('" & v_strBeginDate & "','DD/MM/RRRR')" & vbCrLf &
                        "    ) CIT, (" & vbCrLf &
                        "        SELECT ORDERID,CODEID,TXDATE,TXNUM,EXECQTTY FROM ODMAST" & vbCrLf &
                        "        WHERE DELTD='N' AND EXECTYPE IN ('NB','BC','NS','MS')" & vbCrLf &
                        "        UNION ALL" & vbCrLf &
                        "        SELECT ORDERID,CODEID,TXDATE,TXNUM,EXECQTTY FROM ODMASTHIST" & vbCrLf &
                        "        WHERE DELTD='N' AND EXECTYPE IN ('NB','BC','NS','MS')" & vbCrLf &
                        "        AND TXDATE>=TO_DATE('" & v_strBeginDate & "','DD/MM/RRRR')" & vbCrLf &
                        "    ) OD,SECURITIES_INFO SB,AFMAST AF,CRBDEFACCT CRA,CRBDEFBANK CRB, CIMAST CI" & vbCrLf &
                        "    WHERE CIT.ACCTNO=AF.ACCTNO AND CI.AFACCTNO=AF.ACCTNO AND CI.COREBANK='Y'" & vbCrLf &
                        "    AND AF.BANKNAME=CRA.REFBANK AND CRA.TRFCODE='TRFODBUY'" & vbCrLf &
                        "    AND AF.BANKNAME=CRB.BANKCODE AND CIT.REF=OD.ORDERID" & vbCrLf &
                        "    AND OD.CODEID=SB.CODEID AND CIT.REF NOT IN" & vbCrLf &
                        "    (" & vbCrLf &
                        "            SELECT REQX.CVAL ORDERID" & vbCrLf &
                        "            FROM CRBTXREQDTL REQX,CRBTXREQ REQ" & vbCrLf &
                        "            WHERE REQX.REQID=REQ.REQID AND REQX.FLDNAME='ORDERID'" & vbCrLf &
                        "            AND REQ.STATUS IN ('C','P') " & vbCrLf &
                        "            AND REQ.TRFCODE ='TRFODBUY'" & vbCrLf &
                        "    )" & vbCrLf &
                        ") ORDER BY ORDERID DESC"

            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

            If v_ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To v_ds.Tables(0).Rows.Count - 1 Step 1
                    v_lngErrCode = BuildBatchTxMsg(v_xmlDocument, v_strBATCHNAME)
                    v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value = gc_RM_BUY_AMOUNT_TRANSFER
                    v_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("AFACCTNO")).Substring(0, 4)
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

                                Case "04" 'ORGORDERID
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("ORDERID")
                                Case "03" 'AFCACCTNO
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("AFACCTNO")
                                Case "05" 'DESACCTNO
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("DESACCTNO")
                                Case "06" 'TRFTYPE
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("TRFTYPE")
                                Case "10" 'Amount
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("AMOUNT")
                                Case "20" 'SEACCTNO
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("SEACCTNO")
                                Case "93" 'BANACCOUNT
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("BANKACCTNO")
                                Case "94" 'BANKNAME
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("BANKNAME")
                                Case "95" 'BANKQUE
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("BANKCODE")
                                Case "30" 'DESC                                              
                                    v_strVALUE = "Chuyen tien mua " & "  " & v_ds.Tables(0).Rows(i).Item("EXECQTTY") & "  " & v_ds.Tables(0).Rows(i).Item("SYMBOL") & " " & v_ds.Tables(0).Rows(i).Item("ORDERID")
                                Case Else
                                    v_strVALUE = ""
                            End Select
                            v_entryNode.InnerText = v_strVALUE

                            v_dataElement.AppendChild(v_entryNode)
                        Next

                        v_xmlDocument.DocumentElement.AppendChild(v_dataElement)
                        'Ghi nhÃƒÂ¡Ã‚ÂºÃ‚Â­n giao dÃƒÂ¡Ã‚Â»Ã¢â‚¬Â¹ch vÃƒÆ’Ã‚Â o TLLOG
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

    Public Function BuyFeeTransfer(ByVal v_strBATCHNAME As String, Optional ByVal v_strBCHFillter As String = "", Optional ByRef v_intMaxRow As Integer = 0) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = ATTR_MODULE & ".Batch.BuyFeeTransfer", v_strErrorMessage As String
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
        Dim v_htAmount As New Hashtable
        Dim v_dblRemain, v_dblAmount, v_dblQueue As Double
        Try
            'Lay thong tin phan trang
            v_strSQL = "SELECT COUNT(*) MAXROW FROM  ODMAST"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            v_intMaxRow = v_ds.Tables(0).Rows(0)("MAXROW")
            'Lay thong tin sysvar
            Dim v_strSYSVAR, v_strCURRDATE, v_strPREVDATE, v_strNEXTDATE As String
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "CURRDATE", v_strCURRDATE)
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "PREVDATE", v_strPREVDATE)
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "NEXTDATE", v_strNEXTDATE)
            If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode

            Dim v_strBeginDate As String = GetConfigValue("SYSTEMSTARTDATE", DateTime.Now.AddDays(-30).ToString("dd/MM/yyyy"))
            v_strSQL = "SELECT CRA.TRFCODE TRFTYPE,CIT.REF ORDERID,SB.SYMBOL,OD.EXECQTTY," & vbCrLf &
                        "CIT.ACCTNO AFACCTNO,AF.ACCTNO||OD.CODEID SEACCTNO,AF.BANKACCTNO,CRA.REFACCTNO DESACCTNO," & vbCrLf &
                        "AF.BANKNAME BANKCODE,AF.BANKNAME || ':' || CRB.BANKNAME BANKNAME,CIT.NAMT AMOUNT" & vbCrLf &
                        "FROM (" & vbCrLf &
                        "    SELECT TXDATE,TXNUM,ACCTNO,TXCD,REF,AUTOID,TLTXCD,NAMT FROM CITRAN" & vbCrLf &
                        "    WHERE DELTD='N' AND TLTXCD='8855' AND TXCD='0011'" & vbCrLf &
                        "    UNION ALL" & vbCrLf &
                        "    SELECT TXDATE,TXNUM,ACCTNO,TXCD,REF,AUTOID,TLTXCD,NAMT FROM CITRANA" & vbCrLf &
                        "    WHERE DELTD='N' AND TLTXCD='8855' AND TXCD='0011'" & vbCrLf &
                        "    AND TXDATE>=TO_DATE('" & v_strBeginDate & "','DD/MM/RRRR')" & vbCrLf &
                        ") CIT, (" & vbCrLf &
                        "    SELECT ORDERID,CODEID,TXDATE,TXNUM,EXECQTTY FROM ODMAST" & vbCrLf &
                        "    WHERE DELTD='N' AND EXECTYPE IN ('NB','BC')" & vbCrLf &
                        "    UNION ALL" & vbCrLf &
                        "    SELECT ORDERID,CODEID,TXDATE,TXNUM,EXECQTTY FROM ODMASTHIST" & vbCrLf &
                        "    WHERE DELTD='N' AND EXECTYPE IN ('NB','BC')" & vbCrLf &
                        "    AND TXDATE>=TO_DATE('" & v_strBeginDate & "','DD/MM/RRRR')" & vbCrLf &
                        ") OD,SECURITIES_INFO SB,AFMAST AF,CRBDEFACCT CRA,CRBDEFBANK CRB, CIMAST CI" & vbCrLf &
                        "WHERE CIT.ACCTNO=AF.ACCTNO AND CI.AFACCTNO=AF.ACCTNO AND CI.COREBANK='Y'" & vbCrLf &
                        "AND AF.BANKNAME=CRA.REFBANK AND CRA.TRFCODE='TRFODBFEE'" & vbCrLf &
                        "AND AF.BANKNAME=CRB.BANKCODE AND CIT.REF=OD.ORDERID" & vbCrLf &
                        "AND OD.CODEID=SB.CODEID AND CIT.REF NOT IN" & vbCrLf &
                        "(" & vbCrLf &
                        "        SELECT REQX.CVAL ORDERID" & vbCrLf &
                        "        FROM CRBTXREQDTL REQX,CRBTXREQ REQ" & vbCrLf &
                        "        WHERE REQX.REQID=REQ.REQID AND REQX.FLDNAME='ORDERID'" & vbCrLf &
                        "        AND REQ.STATUS IN ('C','P') " & vbCrLf &
                        "        AND REQ.TRFCODE='TRFODBFEE'" & vbCrLf &
                        ") ORDER BY CIT.TXDATE DESC,CIT.TXNUM DESC"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

            If v_ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To v_ds.Tables(0).Rows.Count - 1 Step 1
                    v_lngErrCode = BuildBatchTxMsg(v_xmlDocument, v_strBATCHNAME)
                    v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value = gc_RM_BUY_FEE_TRANSFER
                    v_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("AFACCTNO")).Substring(0, 4)
                    v_strTLTXCD = v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value


                    'Nap giao dich
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

                                Case "04" 'ORGORDERID
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("ORDERID")
                                Case "03" 'SECACCTNO
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("AFACCTNO")
                                Case "05" 'DESACCTNO
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("DESACCTNO")
                                Case "06" 'TRFTYPE
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("TRFTYPE")
                                Case "10" 'Amount
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("AMOUNT")
                                    'Case "20" 'Acctno
                                    '    v_strVALUE = v_ds.Tables(0).Rows(i).Item("SEACCTNO")
                                Case "93" 'BANACCOUNT
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("BANKACCTNO")
                                Case "94" 'BANKNAME
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("BANKNAME")
                                Case "95" 'BANKQUE
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("BANKCODE")
                                Case "30" 'DESC                                              
                                    v_strVALUE = "Chuyen phi mua " & "  " & v_ds.Tables(0).Rows(i).Item("EXECQTTY") & "  " & v_ds.Tables(0).Rows(i).Item("SYMBOL") & " " & v_ds.Tables(0).Rows(i).Item("ORDERID")
                                Case Else
                                    v_strVALUE = ""
                            End Select
                            v_entryNode.InnerText = v_strVALUE

                            v_dataElement.AppendChild(v_entryNode)
                        Next

                        v_xmlDocument.DocumentElement.AppendChild(v_dataElement)
                        'Ghi nhÃƒÂ¡Ã‚ÂºÃ‚Â­n giao dÃƒÂ¡Ã‚Â»Ã¢â‚¬Â¹ch vÃƒÆ’Ã‚Â o TLLOG
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

    Public Function SaleAmountTransfer(ByVal v_strBATCHNAME As String, Optional ByVal v_strBCHFillter As String = "", Optional ByRef v_intMaxRow As Integer = 0) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = ATTR_MODULE & ".Batch.SaleAmountTransfer", v_strErrorMessage As String
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
        Try
            'Lay thong tin phan trang
            v_strSQL = "SELECT COUNT(*) MAXROW FROM  ODMAST"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            v_intMaxRow = v_ds.Tables(0).Rows(0)("MAXROW")
            'Lay thong tin sysvar
            Dim v_strSYSVAR, v_strCURRDATE, v_strPREVDATE, v_strNEXTDATE As String
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "CURRDATE", v_strCURRDATE)
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "PREVDATE", v_strPREVDATE)
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "NEXTDATE", v_strNEXTDATE)
            If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode

            Dim v_strBeginDate As String = GetConfigValue("SYSTEMSTARTDATE", DateTime.Now.AddDays(-30).ToString("dd/MM/yyyy"))
            v_strSQL = "SELECT OD.TXNUM,CRA.TRFCODE TRFTYPE,CIT.REF ORDERID,SB.SYMBOL,OD.EXECQTTY," & vbCrLf &
                        "CIT.ACCTNO AFACCTNO,AF.ACCTNO||OD.CODEID SEACCTNO,AF.BANKACCTNO,CRA.REFACCTNO DESACCTNO," & vbCrLf &
                        "AF.BANKNAME BANKCODE,AF.BANKNAME || ':' || CRB.BANKNAME BANKNAME,CIT.NAMT AMOUNT" & vbCrLf &
                        "FROM (" & vbCrLf &
                        "    SELECT TXDATE,TXNUM,ACCTNO,TXCD,REF,AUTOID,TLTXCD,NAMT FROM CITRAN" & vbCrLf &
                        "    WHERE DELTD='N' AND TLTXCD='8866' AND TXCD='0029'" & vbCrLf &
                        "    UNION ALL" & vbCrLf &
                        "    SELECT TXDATE,TXNUM,ACCTNO,TXCD,REF,AUTOID,TLTXCD,NAMT FROM CITRANA" & vbCrLf &
                        "    WHERE DELTD='N' AND TLTXCD='8866' AND TXCD='0029' " & vbCrLf &
                        "    AND TXDATE>=TO_DATE('" & v_strBeginDate & "','DD/MM/RRRR')" & vbCrLf &
                        ") CIT, (" & vbCrLf &
                        "    SELECT ORDERID,CODEID,TXDATE,TXNUM,EXECQTTY FROM ODMAST" & vbCrLf &
                        "    WHERE DELTD='N' AND EXECTYPE IN ('NS','MS','SS')" & vbCrLf &
                        "    UNION ALL" & vbCrLf &
                        "    SELECT ORDERID,CODEID,TXDATE,TXNUM,EXECQTTY FROM ODMASTHIST" & vbCrLf &
                        "    WHERE DELTD='N' AND EXECTYPE IN ('NS','MS','SS')" & vbCrLf &
                        "    AND TXDATE>=TO_DATE('" & v_strBeginDate & "','DD/MM/RRRR')" & vbCrLf &
                        ") OD,SECURITIES_INFO SB,AFMAST AF,CRBDEFACCT CRA,CRBDEFBANK CRB, CIMAST CI" & vbCrLf &
                        "WHERE CIT.ACCTNO=AF.ACCTNO AND CI.AFACCTNO=AF.ACCTNO AND CI.COREBANK='Y'" & vbCrLf &
                        "AND AF.BANKNAME=CRA.REFBANK AND CRA.TRFCODE='TRFODSELL'" & vbCrLf &
                        "AND AF.BANKNAME=CRB.BANKCODE AND CIT.REF=OD.ORDERID" & vbCrLf &
                        "AND OD.CODEID=SB.CODEID AND CIT.REF NOT IN" & vbCrLf &
                        "(" & vbCrLf &
                        "        SELECT REQX.CVAL ORDERID" & vbCrLf &
                        "        FROM CRBTXREQDTL REQX,CRBTXREQ REQ" & vbCrLf &
                        "        WHERE REQX.REQID=REQ.REQID AND REQX.FLDNAME='ORDERID'" & vbCrLf &
                        "        AND REQ.STATUS IN ('C','P') " & vbCrLf &
                        "        AND REQ.TRFCODE='TRFODSELL'" & vbCrLf &
                        ") ORDER BY CIT.TXDATE DESC,CIT.TXNUM DESC"

            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

            If v_ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To v_ds.Tables(0).Rows.Count - 1 Step 1
                    v_lngErrCode = BuildBatchTxMsg(v_xmlDocument, v_strBATCHNAME)
                    v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value = gc_RM_SALE_AMOUNT_TRANSFER
                    v_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("AFACCTNO")).Substring(0, 4)
                    v_strTLTXCD = v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value
                    'Nap giao dich
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

                                Case "04" 'ORGORDERID
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("ORDERID")
                                Case "03" 'SECACCTNO
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("AFACCTNO")
                                Case "05" 'DESACCTNO
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("DESACCTNO")
                                Case "06" 'TRFTYPE
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("TRFTYPE")
                                Case "10" 'Amount
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("AMOUNT")
                                Case "11" 'Amount
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("TXNUM")
                                    'Case "20" 'Acctno
                                    '    v_strVALUE = v_ds.Tables(0).Rows(i).Item("ACCTNO")
                                Case "93" 'BANACCOUNT
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("BANKACCTNO")
                                Case "94" 'BANKNAME
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("BANKNAME")
                                Case "95" 'BANKQUE
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("BANKCODE")
                                Case "30" 'DESC                                              
                                    v_strVALUE = "Chuyen tien ban" & "  " & v_ds.Tables(0).Rows(i).Item("EXECQTTY") & "  " & v_ds.Tables(0).Rows(i).Item("SYMBOL") & " " & v_ds.Tables(0).Rows(i).Item("ORDERID")
                                Case Else
                                    v_strVALUE = ""
                            End Select
                            v_entryNode.InnerText = v_strVALUE

                            v_dataElement.AppendChild(v_entryNode)
                        Next

                        v_xmlDocument.DocumentElement.AppendChild(v_dataElement)
                        'Ghi nhÃƒÂ¡Ã‚ÂºÃ‚Â­n giao dÃƒÂ¡Ã‚Â»Ã¢â‚¬Â¹ch vÃƒÆ’Ã‚Â o TLLOG
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

    Public Function SaleFeeTransfer(ByVal v_strBATCHNAME As String, Optional ByVal v_strBCHFillter As String = "", Optional ByRef v_intMaxRow As Integer = 0) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = ATTR_MODULE & ".Batch.SaleFeeTransfer", v_strErrorMessage As String
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
        Try
            'Lay thong tin phan trang
            v_strSQL = "SELECT COUNT(*) MAXROW FROM  ODMAST"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            v_intMaxRow = v_ds.Tables(0).Rows(0)("MAXROW")
            'Lay thong tin sysvar
            Dim v_strSYSVAR, v_strCURRDATE, v_strPREVDATE, v_strNEXTDATE As String
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "CURRDATE", v_strCURRDATE)
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "PREVDATE", v_strPREVDATE)
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "NEXTDATE", v_strNEXTDATE)
            If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode

            Dim v_strBeginDate As String = GetConfigValue("SYSTEMSTARTDATE", DateTime.Now.AddDays(-30).ToString("dd/MM/yyyy"))
            v_strSQL = "SELECT OD.TXNUM,CRA.TRFCODE TRFTYPE,CIT.REF ORDERID,SB.SYMBOL,OD.EXECQTTY," & vbCrLf &
                        "CIT.ACCTNO AFACCTNO,AF.ACCTNO||OD.CODEID SEACCTNO,AF.BANKACCTNO,CRA.REFACCTNO DESACCTNO," & vbCrLf &
                        "AF.BANKNAME BANKCODE,AF.BANKNAME || ':' || CRB.BANKNAME BANKNAME,CIT.NAMT AMOUNT" & vbCrLf &
                        "FROM (" & vbCrLf &
                        "    SELECT TXDATE,TXNUM,ACCTNO,TXCD,REF,AUTOID,TLTXCD,NAMT FROM CITRAN" & vbCrLf &
                        "    WHERE DELTD='N' AND TLTXCD='8856' AND TXCD='0028'" & vbCrLf &
                        "    UNION ALL" & vbCrLf &
                        "    SELECT TXDATE,TXNUM,ACCTNO,TXCD,REF,AUTOID,TLTXCD,NAMT FROM CITRANA" & vbCrLf &
                        "    WHERE DELTD='N' AND TLTXCD='8856' AND TXCD='0028' " & vbCrLf &
                        "    AND TXDATE>=TO_DATE('" & v_strBeginDate & "','DD/MM/RRRR')" & vbCrLf &
                        ") CIT, (" & vbCrLf &
                        "    SELECT ORDERID,CODEID,TXDATE,TXNUM,EXECQTTY FROM ODMAST" & vbCrLf &
                        "    WHERE DELTD='N' AND EXECTYPE IN ('NS','MS','SS')" & vbCrLf &
                        "    UNION ALL" & vbCrLf &
                        "    SELECT ORDERID,CODEID,TXDATE,TXNUM,EXECQTTY FROM ODMASTHIST" & vbCrLf &
                        "    WHERE DELTD='N' AND EXECTYPE IN ('NS','MS','SS')" & vbCrLf &
                        "    AND TXDATE>=TO_DATE('" & v_strBeginDate & "','DD/MM/RRRR')" & vbCrLf &
                        ") OD,SECURITIES_INFO SB,AFMAST AF,CRBDEFACCT CRA,CRBDEFBANK CRB,CIMAST CI" & vbCrLf &
                        "WHERE CIT.ACCTNO=AF.ACCTNO AND CI.AFACCTNO=AF.ACCTNO AND CI.COREBANK='Y'" & vbCrLf &
                        "AND AF.BANKNAME=CRA.REFBANK AND CRA.TRFCODE='TRFODSFEE'" & vbCrLf &
                        "AND AF.BANKNAME=CRB.BANKCODE AND CIT.REF=OD.ORDERID" & vbCrLf &
                        "AND OD.CODEID=SB.CODEID AND CIT.REF NOT IN" & vbCrLf &
                        "(" & vbCrLf &
                        "        SELECT REQX.CVAL ORDERID" & vbCrLf &
                        "        FROM CRBTXREQDTL REQX,CRBTXREQ REQ" & vbCrLf &
                        "        WHERE REQX.REQID=REQ.REQID AND REQX.FLDNAME='ORDERID'" & vbCrLf &
                        "        AND REQ.STATUS IN ('C','P') " & vbCrLf &
                        "        AND REQ.TRFCODE='TRFODSFEE'" & vbCrLf &
                        ") ORDER BY CIT.TXDATE DESC,CIT.TXNUM DESC"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

            If v_ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To v_ds.Tables(0).Rows.Count - 1 Step 1
                    v_lngErrCode = BuildBatchTxMsg(v_xmlDocument, v_strBATCHNAME)
                    v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value = gc_RM_SALE_FEE_TRANSFER
                    v_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("AFACCTNO")).Substring(0, 4)
                    v_strTLTXCD = v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value
                    'Nap giao dich
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

                                Case "04" 'ORGORDERID
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("ORDERID")
                                Case "03" 'SECACCTNO
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("AFACCTNO")
                                Case "05" 'DESACCTNO
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("DESACCTNO")
                                Case "06" 'TRFTYPE
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("TRFTYPE")
                                Case "10" 'Amount
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("AMOUNT")
                                Case "11" 'Amount
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("TXNUM")
                                    'Case "20" 'Acctno
                                    '    v_strVALUE = v_ds.Tables(0).Rows(i).Item("ACCTNO")
                                Case "93" 'BANACCOUNT
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("BANKACCTNO")
                                Case "94" 'BANKNAME
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("BANKNAME")
                                Case "95" 'BANKQUE
                                    v_strVALUE = v_ds.Tables(0).Rows(i).Item("BANKCODE")
                                Case "30" 'DESC                       
                                    v_strVALUE = "Chuyen phi ban" & "  " & v_ds.Tables(0).Rows(i).Item("EXECQTTY") & "  " & v_ds.Tables(0).Rows(i).Item("SYMBOL") & " " & v_ds.Tables(0).Rows(i).Item("ORDERID")
                                Case Else
                                    v_strVALUE = ""
                            End Select
                            v_entryNode.InnerText = v_strVALUE

                            v_dataElement.AppendChild(v_entryNode)
                        Next

                        v_xmlDocument.DocumentElement.AppendChild(v_dataElement)
                        'Ghi nhÃƒÂ¡Ã‚ÂºÃ‚Â­n giao dÃƒÂ¡Ã‚Â»Ã¢â‚¬Â¹ch vÃƒÆ’Ã‚Â o TLLOG
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

    Public Function Execute3384(ByVal v_strBATCHNAME As String, Optional ByVal v_strBCHFillter As String = "", Optional ByRef v_intMaxRow As Integer = 0) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = ATTR_MODULE & ".Batch.Execute3384", v_strErrorMessage As String
        Dim v_strSQL As String, v_ds, v_dsTLLOG As DataSet, v_objMessageLog As New MessageLog
        v_objMessageLog.NewDBInstance(gc_MODULE_HOST)
        Dim v_obj As New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)
        Dim i, j As Integer, v_strFRTABLE, v_strTOTABLE As String
        Dim v_xmlDocument As New Xml.XmlDocument, v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
        Dim v_strVALEXP, v_strVALUE, v_strFLDNAME, v_strDEFNAME, v_strFLDTYPE As String
        Dim v_attrFLDNAME, v_attrDATATYPE As Xml.XmlAttribute
        Dim v_strTLTXCD As Double
        Dim v_strOrgTxNum As String = ""
        Try
            'Lay thong tin sysvar
            Dim v_strSYSVAR, v_strCURRDATE, v_strPREVDATE, v_strNEXTDATE As String
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "CURRDATE", v_strCURRDATE)
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "PREVDATE", v_strPREVDATE)
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "NEXTDATE", v_strNEXTDATE)
            If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode

            v_strSQL = "SELECT LOG.TXNUM,LOG.TXDATE,TLF.CVALUE CAMASTID,AF.ACCTNO AFACCTNO,CF.FULLNAME," & vbCrLf &
                        "CF.ADDRESS,CF.IDCODE,LOG.MSGAMT AMOUNT,'TRFCAREG' TRFTYPE," & vbCrLf &
                        "CRA.REFACCTNO DESCACCTNO,AF.BANKACCTNO BANACCTNO,(AF.BANKNAME || ':' || CRB.BANKNAME) BANKNAME," & vbCrLf &
                        "CRB.BANKCODE BANKQUE,LOG.MSGACCT ACCTNO,CF.CUSTODYCD,TLF1.CVALUE DEST" & vbCrLf &
                        "FROM " & vbCrLf &
                        "TLLOG LOG,TLLOGFLD TLF,TLLOGFLD TLF1,AFMAST AF," & vbCrLf &
                        "CFMAST CF,CIMAST CI,CRBDEFACCT CRA,CRBDEFBANK CRB" & vbCrLf &
                        "WHERE AF.ACCTNO = LOG.MSGACCT AND CI.AFACCTNO = AF.ACCTNO AND AF.CUSTID=CF.CUSTID " & vbCrLf &
                        "AND LOG.TXNUM=TLF.TXNUM AND LOG.TXDATE=TLF.TXDATE AND TLF.FLDCD='02' " & vbCrLf &
                        "AND LOG.TXNUM=TLF1.TXNUM AND LOG.TXDATE=TLF1.TXDATE AND TLF1.FLDCD='30' " & vbCrLf &
                        "AND AF.BANKNAME=CRA.REFBANK AND CRA.TRFCODE='TRFCAREG'" & vbCrLf &
                        "AND AF.BANKNAME=CRB.BANKCODE AND CI.COREBANK='Y' AND LOG.DELTD<>'Y' " & vbCrLf &
                        "AND AF.BANKACCTNO IS NOT NULL AND LOG.TLTXCD='" & gc_CA_STOCK_RIGHTOFF & "'" & vbCrLf &
                        "AND LOG.TXNUM NOT IN " & vbCrLf &
                        "(" & vbCrLf &
                        "   SELECT REQX.CVAL CATXNUM" & vbCrLf &
                        "   FROM CRBTXREQDTL REQX,CRBTXREQ REQ" & vbCrLf &
                        "   WHERE REQX.REQID=REQ.REQID AND REQX.FLDNAME='CATXNUM'" & vbCrLf &
                        "   AND REQ.STATUS IN ('C','P') " & vbCrLf &
                        "   AND REQ.TRFCODE='TRFCAREG'" & vbCrLf &
                        ")" & vbCrLf &
                        "ORDER BY LOG.AUTOID ASC"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If Not v_ds Is Nothing Then
                If v_ds.Tables.Count > 0 Then
                    For i = 0 To v_ds.Tables(0).Rows.Count - 1
                        'Sinh giao dich gen ra transferlog
                        v_lngErrCode = BuildBatchTxMsg(v_xmlDocument, v_strBATCHNAME)
                        v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value = gc_RM_TRANSFER
                        v_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("AFACCTNO")).Substring(0, 4)
                        v_strTLTXCD = v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value
                        'Nap giao dich
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
                                v_strVALUE = ""
                                Select Case v_strFLDNAME
                                    Case "03" 'SECACCTNO
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("AFACCTNO")
                                    Case "05" 'DESACCTNO
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("DESCACCTNO")
                                    Case "06" 'TRFTYPE
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("TRFTYPE")
                                    Case "11" 'CAMASTID
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("CAMASTID")
                                    Case "90" 'CUSTNAME
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("FULLNAME")
                                    Case "91" 'ADDRESS
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("ADDRESS")
                                    Case "92" 'LICENSE
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("IDCODE")
                                    Case "93" 'BANACCOUNT
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("BANACCTNO")
                                    Case "94" 'BANKNAME
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("BANKNAME")
                                    Case "95" 'BANKQUE
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("BANKQUE")
                                    Case "02" 'CATXNUM
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("TXNUM")
                                    Case "10" 'Amount
                                        v_strVALUE = Convert.ToString(Convert.ToDecimal(v_ds.Tables(0).Rows(i).Item("AMOUNT")))
                                    Case "30" 'DESC                       
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("DEST") & " TK " & v_ds.Tables(0).Rows(i).Item("CUSTODYCD")
                                    Case Else
                                        v_strVALUE = ""
                                End Select

                                v_entryNode.InnerText = v_strVALUE
                                v_dataElement.AppendChild(v_entryNode)
                            Next

                            v_xmlDocument.DocumentElement.AppendChild(v_dataElement)
                            'Ghi nhÃƒÂ¡Ã‚ÂºÃ‚Â­n giao dÃƒÂ¡Ã‚Â»Ã¢â‚¬Â¹ch vÃƒÆ’Ã‚Â o TLLOG
                            v_lngErrCode = v_objMessageLog.TransLog(v_xmlDocument)

                            If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode
                        End If
                    Next
                End If
            End If

            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function Execute3386(ByVal v_strBATCHNAME As String, Optional ByVal v_strBCHFillter As String = "", Optional ByRef v_intMaxRow As Integer = 0) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = ATTR_MODULE & ".Batch.Execute3386", v_strErrorMessage As String
        Dim v_strSQL As String, v_ds, v_dsTLLOG As DataSet, v_objMessageLog As New MessageLog
        v_objMessageLog.NewDBInstance(gc_MODULE_HOST)
        Dim v_obj As New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)
        Dim i, j As Integer, v_strFRTABLE, v_strTOTABLE As String
        Dim v_xmlDocument As New Xml.XmlDocument, v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
        Dim v_strVALEXP, v_strVALUE, v_strFLDNAME, v_strDEFNAME, v_strFLDTYPE As String
        Dim v_attrFLDNAME, v_attrDATATYPE As Xml.XmlAttribute
        Dim v_strTLTXCD As Double
        Dim v_strOrgTxNum As String = ""
        Try
            'Lay thong tin sysvar
            Dim v_strSYSVAR, v_strCURRDATE, v_strPREVDATE, v_strNEXTDATE As String
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "CURRDATE", v_strCURRDATE)
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "PREVDATE", v_strPREVDATE)
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "NEXTDATE", v_strNEXTDATE)
            If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode

            v_strSQL = "SELECT LOG.TXNUM,LOG.TXDATE,TLF.CVALUE CAMASTID,AF.ACCTNO AFACCTNO,CF.FULLNAME," & vbCrLf &
                   "CF.ADDRESS,CF.IDCODE,LOG.MSGAMT*TLF1.NVALUE AMOUNT,'TRFCAUNREG' TRFTYPE," & vbCrLf &
                   "CRA.REFACCTNO DESCACCTNO,AF.BANKACCTNO BANACCTNO,CRB.BANKCODE BANKQUE," & vbCrLf &
                   "(AF.bankname || ':' || CRB.BANKNAME) BANKNAME,LOG.MSGACCT ACCTNO,CF.CUSTODYCD,TLF2.CVALUE DEST" & vbCrLf &
                   "FROM " & vbCrLf &
                   "TLLOG LOG,TLLOGFLD TLF,TLLOGFLD TLF1,TLLOGFLD TLF2," & vbCrLf &
                   "AFMAST AF,CFMAST CF,CIMAST CI,CRBDEFACCT CRA,CRBDEFBANK CRB" & vbCrLf &
                   "WHERE AF.ACCTNO = LOG.MSGACCT AND CI.AFACCTNO = AF.ACCTNO AND AF.CUSTID=CF.CUSTID " & vbCrLf &
                   "AND LOG.TXNUM=TLF.TXNUM AND LOG.TXDATE=TLF.TXDATE AND TLF.FLDCD='02' " & vbCrLf &
                   "AND LOG.TXNUM=TLF1.TXNUM AND LOG.TXDATE=TLF1.TXDATE AND TLF1.FLDCD='05' " & vbCrLf &
                   "AND LOG.TXNUM=TLF2.TXNUM AND LOG.TXDATE=TLF2.TXDATE AND TLF2.FLDCD='30' " & vbCrLf &
                   "AND AF.BANKNAME=CRA.REFBANK AND CRA.TRFCODE='TRFCAUNREG'" & vbCrLf &
                   "AND AF.BANKNAME=CRB.BANKCODE AND CI.corebank='Y' AND LOG.DELTD<>'Y'" & vbCrLf &
                   "AND AF.BANKACCTNO IS NOT NULL AND LOG.TLTXCD='" & gc_CA_CANCEL_STOCK_RIGHTOFF & "'" & vbCrLf &
                   "AND LOG.TXNUM NOT IN " & vbCrLf &
                   "(" & vbCrLf &
                   "   SELECT REQX.CVAL CATXNUM" & vbCrLf &
                   "   FROM CRBTXREQDTL REQX,CRBTXREQ REQ" & vbCrLf &
                   "   WHERE REQX.REQID=REQ.REQID AND REQX.FLDNAME='CATXNUM'" & vbCrLf &
                   "   AND REQ.STATUS IN ('C','P') " & vbCrLf &
                   "   AND REQ.TRFCODE='TRFCAUNREG'" & vbCrLf &
                   ")" & vbCrLf &
                   "ORDER BY LOG.AUTOID ASC"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If Not v_ds Is Nothing Then
                If v_ds.Tables.Count > 0 Then
                    For i = 0 To v_ds.Tables(0).Rows.Count - 1
                        'Sinh giao dich gen ra transferlog
                        v_lngErrCode = BuildBatchTxMsg(v_xmlDocument, v_strBATCHNAME)
                        v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value = gc_RM_TRANSFER_2
                        v_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("AFACCTNO")).Substring(0, 4)
                        v_strTLTXCD = v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value
                        'Nap giao dich
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
                                v_strVALUE = ""
                                Select Case v_strFLDNAME
                                    Case "03" 'SECACCTNO
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("AFACCTNO")
                                    Case "05" 'DESACCTNO
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("DESCACCTNO")
                                    Case "06" 'TRFTYPE
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("TRFTYPE")
                                    Case "11" 'CAMASTID
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("CAMASTID")
                                    Case "90" 'CUSTNAME
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("FULLNAME")
                                    Case "91" 'ADDRESS
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("ADDRESS")
                                    Case "92" 'LICENSE
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("IDCODE")
                                    Case "93" 'BANACCOUNT
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("BANACCTNO")
                                    Case "94" 'BANKNAME
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("BANKNAME")
                                    Case "95" 'BANKQUE
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("BANKQUE")
                                    Case "02" 'CATXNUM
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("TXNUM")
                                    Case "10" 'Amount
                                        v_strVALUE = Convert.ToString(Convert.ToDecimal(v_ds.Tables(0).Rows(i).Item("AMOUNT")))
                                    Case "30" 'DESC                       
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("DEST") & " TK " & v_ds.Tables(0).Rows(i).Item("CUSTODYCD")
                                    Case Else
                                        v_strVALUE = ""
                                End Select

                                v_entryNode.InnerText = v_strVALUE
                                v_dataElement.AppendChild(v_entryNode)
                            Next

                            v_xmlDocument.DocumentElement.AppendChild(v_dataElement)
                            'Ghi nhÃƒÂ¡Ã‚ÂºÃ‚Â­n giao dÃƒÂ¡Ã‚Â»Ã¢â‚¬Â¹ch vÃƒÆ’Ã‚Â o TLLOG
                            v_lngErrCode = v_objMessageLog.TransLog(v_xmlDocument)

                            If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode
                        End If
                    Next
                End If
            End If

            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function Execute33503354(ByVal v_strBATCHNAME As String, Optional ByVal v_strBCHFillter As String = "", Optional ByRef v_intMaxRow As Integer = 0) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = ATTR_MODULE & ".Batch.Execute33503354", v_strErrorMessage As String
        Dim v_strSQL As String, v_ds, v_dsTLLOG As DataSet, v_objMessageLog As New MessageLog
        v_objMessageLog.NewDBInstance(gc_MODULE_HOST)
        Dim v_obj As New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)
        Dim i, j As Integer, v_strFRTABLE, v_strTOTABLE As String
        Dim v_xmlDocument As New Xml.XmlDocument, v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
        Dim v_strVALEXP, v_strVALUE, v_strFLDNAME, v_strDEFNAME, v_strFLDTYPE As String
        Dim v_attrFLDNAME, v_attrDATATYPE As Xml.XmlAttribute
        Dim v_strTLTXCD As Double
        Dim v_strOrgTxNum As String = ""
        Dim v_strDesc As String = ""
        Try
            'Lay thong tin sysvar
            Dim v_strSYSVAR, v_strCURRDATE, v_strPREVDATE, v_strNEXTDATE As String
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "CURRDATE", v_strCURRDATE)
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "PREVDATE", v_strPREVDATE)
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "NEXTDATE", v_strNEXTDATE)
            If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode

            v_strSQL = "SELECT LOG.TXNUM,LOG.TXDATE,LOG.TLTXCD,TLF.CVALUE CAMASTID,AF.ACCTNO AFACCTNO,CF.FULLNAME," & vbCrLf &
                        "CF.ADDRESS,CF.IDCODE,LOG.MSGAMT AMOUNT,TLF1.NVALUE DUTYAMT,'TRFCACASH' TRFTYPE,CRB.BANKCODE BANKQUE," & vbCrLf &
                        "CRA.REFACCTNO DESCACCTNO,AF.BANKACCTNO BANACCTNO,(AF.bankname || ':' || CRB.BANKNAME) BANKNAME," & vbCrLf &
                        "LOG.MSGACCT ACCTNO,CF.CUSTODYCD,TLF2.CVALUE DEST" & vbCrLf &
                        "FROM " & vbCrLf &
                        "TLLOG LOG,TLLOGFLD TLF,TLLOGFLD TLF1,TLLOGFLD TLF2," & vbCrLf &
                        "AFMAST AF,CFMAST CF,CIMAST CI,CRBDEFACCT CRA,CRBDEFBANK CRB" & vbCrLf &
                        "WHERE AF.ACCTNO = LOG.MSGACCT AND CI.AFACCTNO = AF.ACCTNO AND AF.CUSTID=CF.CUSTID " & vbCrLf &
                        "AND LOG.TXNUM=TLF.TXNUM AND LOG.TXDATE=TLF.TXDATE AND TLF.FLDCD='02' " & vbCrLf &
                        "AND LOG.TXNUM=TLF1.TXNUM AND LOG.TXDATE=TLF1.TXDATE AND TLF1.FLDCD='20' " & vbCrLf &
                        "AND LOG.TXNUM=TLF2.TXNUM AND LOG.TXDATE=TLF2.TXDATE AND TLF2.FLDCD='30' " & vbCrLf &
                        "AND AF.BANKNAME=CRA.REFBANK AND CRA.TRFCODE='TRFCACASH' AND AF.BANKNAME=CRB.BANKCODE" & vbCrLf &
                        "AND CI.corebank='Y' AND LOG.DELTD<>'Y'" & vbCrLf &
                        "AND AF.BANKACCTNO IS NOT NULL AND LOG.TLTXCD IN ('" & gc_CA_EXECUTE_CI_CAEVENT & "','" & gc_CA_EXECUTE_CI_CAEVENT_PIT_AT_ISSUER & "')" & vbCrLf &
                        "AND LOG.TXNUM NOT IN " & vbCrLf &
                        "(" & vbCrLf &
                        "   SELECT REQX.CVAL CATXNUM" & vbCrLf &
                        "   FROM CRBTXREQDTL REQX,CRBTXREQ REQ" & vbCrLf &
                        "   WHERE REQX.REQID=REQ.REQID AND REQX.FLDNAME='CATXNUM'" & vbCrLf &
                        "   AND REQ.STATUS IN ('C','P') " & vbCrLf &
                        "   AND REQ.TRFCODE='TRFCACASH'" & vbCrLf &
                        ")" & vbCrLf &
                        "ORDER BY LOG.AUTOID ASC"

            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If Not v_ds Is Nothing Then
                If v_ds.Tables.Count > 0 Then
                    For i = 0 To v_ds.Tables(0).Rows.Count - 1

                        'Sinh giao dich gen ra transferlog
                        v_lngErrCode = BuildBatchTxMsg(v_xmlDocument, v_strBATCHNAME)
                        v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value = gc_RM_TRANSFER_2
                        v_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("AFACCTNO")).Substring(0, 4)
                        v_strTLTXCD = v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value
                        'Nap giao dich
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
                                v_strVALUE = ""
                                Select Case v_strFLDNAME
                                    Case "03" 'SECACCTNO
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("AFACCTNO")
                                    Case "05" 'DESACCTNO
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("DESCACCTNO")
                                    Case "06" 'TRFTYPE
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("TRFTYPE")
                                    Case "11" 'CAMASTID
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("CAMASTID")
                                    Case "90" 'CUSTNAME
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("FULLNAME")
                                    Case "91" 'ADDRESS
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("ADDRESS")
                                    Case "92" 'LICENSE
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("IDCODE")
                                    Case "93" 'BANACCOUNT
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("BANACCTNO")
                                    Case "94" 'BANKNAME
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("BANKNAME")
                                    Case "95" 'BANKQUE
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("BANKQUE")
                                    Case "02" 'CATXNUM
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("TXNUM")
                                    Case "10" 'Amount
                                        If v_ds.Tables(0).Rows(i).Item("TLTXCD").ToString() = "3350" Then
                                            v_strVALUE = Convert.ToString(Convert.ToDecimal(v_ds.Tables(0).Rows(i).Item("AMOUNT")))
                                        Else
                                            v_strVALUE = Convert.ToString(Convert.ToDecimal(v_ds.Tables(0).Rows(i).Item("AMOUNT")) - Convert.ToDecimal(v_ds.Tables(0).Rows(i).Item("DUTYAMT")))
                                        End If
                                    Case "30" 'DESC                       
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("DEST") & " TK " & v_ds.Tables(0).Rows(i).Item("CUSTODYCD")
                                    Case Else
                                        v_strVALUE = ""
                                End Select

                                v_entryNode.InnerText = v_strVALUE
                                v_dataElement.AppendChild(v_entryNode)
                            Next

                            v_xmlDocument.DocumentElement.AppendChild(v_dataElement)
                            'Ghi nhÃƒÂ¡Ã‚ÂºÃ‚Â­n giao dÃƒÂ¡Ã‚Â»Ã¢â‚¬Â¹ch vÃƒÆ’Ã‚Â o TLLOG
                            v_lngErrCode = v_objMessageLog.TransLog(v_xmlDocument)

                            If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode
                        End If
                    Next
                End If
            End If

            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function Execute33503354DutyFee(ByVal v_strBATCHNAME As String, Optional ByVal v_strBCHFillter As String = "", Optional ByRef v_intMaxRow As Integer = 0) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = ATTR_MODULE & ".Batch.Execute33503354", v_strErrorMessage As String
        Dim v_strSQL As String, v_ds, v_dsTLLOG As DataSet, v_objMessageLog As New MessageLog
        v_objMessageLog.NewDBInstance(gc_MODULE_HOST)
        Dim v_obj As New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)
        Dim i, j As Integer, v_strFRTABLE, v_strTOTABLE As String
        Dim v_xmlDocument As New Xml.XmlDocument, v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
        Dim v_strVALEXP, v_strVALUE, v_strFLDNAME, v_strDEFNAME, v_strFLDTYPE As String
        Dim v_attrFLDNAME, v_attrDATATYPE As Xml.XmlAttribute
        Dim v_strTLTXCD As Double
        Dim v_strOrgTxNum As String = ""
        Dim v_strDesc As String = ""
        Try
            'Lay thong tin sysvar
            Dim v_strSYSVAR, v_strCURRDATE, v_strPREVDATE, v_strNEXTDATE As String
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "CURRDATE", v_strCURRDATE)
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "PREVDATE", v_strPREVDATE)
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "NEXTDATE", v_strNEXTDATE)
            If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode

            v_strSQL = "SELECT LOG.TXNUM,LOG.TXDATE,TLF.CVALUE CAMASTID,AF.ACCTNO AFACCTNO,CF.FULLNAME," & vbCrLf &
                        "CF.ADDRESS,CF.IDCODE,LOG.MSGAMT AMOUNT,TLF1.NVALUE DUTYAMT,'TRFCATAX' TRFTYPE,CRB.BANKCODE BANKQUE," & vbCrLf &
                        "CRA.REFACCTNO DESCACCTNO,AF.BANKACCTNO BANACCTNO,(AF.bankname || ':' || CRB.BANKNAME) BANKNAME," & vbCrLf &
                        "LOG.MSGACCT ACCTNO,CF.CUSTODYCD,TLF2.CVALUE DEST" & vbCrLf &
                        "FROM " & vbCrLf &
                        "TLLOG LOG,TLLOGFLD TLF,TLLOGFLD TLF1,TLLOGFLD TLF2," & vbCrLf &
                        "AFMAST AF,CFMAST CF,CIMAST CI,CRBDEFACCT CRA,CRBDEFBANK CRB" & vbCrLf &
                        "WHERE AF.ACCTNO = LOG.MSGACCT AND CI.AFACCTNO = AF.ACCTNO AND AF.CUSTID=CF.CUSTID " & vbCrLf &
                        "AND LOG.TXNUM=TLF.TXNUM AND LOG.TXDATE=TLF.TXDATE AND TLF.FLDCD='02' " & vbCrLf &
                        "AND LOG.TXNUM=TLF1.TXNUM AND LOG.TXDATE=TLF1.TXDATE AND TLF1.FLDCD='20' " & vbCrLf &
                        "AND LOG.TXNUM=TLF2.TXNUM AND LOG.TXDATE=TLF2.TXDATE AND TLF2.FLDCD='30' " & vbCrLf &
                        "AND AF.BANKNAME=CRA.REFBANK AND CRA.TRFCODE='TRFCATAX' " & vbCrLf &
                        "AND AF.BANKNAME=CRB.BANKCODE AND CI.corebank='Y' AND LOG.DELTD<>'Y'" & vbCrLf &
                        "AND AF.BANKACCTNO IS NOT NULL AND LOG.MSGAMT>0 AND LOG.TLTXCD IN ('" & gc_CA_EXECUTE_CI_CAEVENT & "')" & vbCrLf &
                        "AND TLF1.NVALUE>0 AND LOG.TXNUM NOT IN " & vbCrLf &
                        "(" & vbCrLf &
                        "   SELECT REQX.CVAL CATXNUM" & vbCrLf &
                        "   FROM CRBTXREQDTL REQX,CRBTXREQ REQ" & vbCrLf &
                        "   WHERE REQX.REQID=REQ.REQID AND REQX.FLDNAME='CATXNUM'" & vbCrLf &
                        "   AND REQ.STATUS IN ('C','P') " & vbCrLf &
                        "   AND REQ.TRFCODE='TRFCATAX'" & vbCrLf &
                        ")" & vbCrLf &
                        "ORDER BY LOG.AUTOID ASC"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If Not v_ds Is Nothing Then
                If v_ds.Tables.Count > 0 Then
                    For i = 0 To v_ds.Tables(0).Rows.Count - 1

                        'Sinh giao dich gen ra transferlog
                        v_lngErrCode = BuildBatchTxMsg(v_xmlDocument, v_strBATCHNAME)
                        v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value = gc_RM_TRANSFER_2
                        v_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("AFACCTNO")).Substring(0, 4)
                        v_strTLTXCD = v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value
                        'Nap giao dich
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
                                v_strVALUE = ""
                                Select Case v_strFLDNAME
                                    Case "03" 'SECACCTNO
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("AFACCTNO")
                                    Case "05" 'DESACCTNO
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("DESCACCTNO")
                                    Case "06" 'TRFTYPE
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("TRFTYPE")
                                    Case "11" 'CAMASTID
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("CAMASTID")
                                    Case "90" 'CUSTNAME
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("FULLNAME")
                                    Case "91" 'ADDRESS
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("ADDRESS")
                                    Case "92" 'LICENSE
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("IDCODE")
                                    Case "93" 'BANACCOUNT
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("BANACCTNO")
                                    Case "94" 'BANKNAME
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("BANKNAME")
                                    Case "95" 'BANKQUE
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("BANKQUE")
                                    Case "02" 'CATXNUM
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("TXNUM")
                                    Case "10" 'Amount
                                        v_strVALUE = Convert.ToDecimal(v_ds.Tables(0).Rows(i).Item("DUTYAMT"))
                                    Case "30" 'DESC                       
                                        v_strVALUE = "Thu thuế bán CK lô lẻ ngày : " & v_strCURRDATE & " - TK : " & v_ds.Tables(0).Rows(i).Item("CUSTODYCD")
                                    Case Else
                                        v_strVALUE = ""
                                End Select

                                v_entryNode.InnerText = v_strVALUE
                                v_dataElement.AppendChild(v_entryNode)
                            Next

                            v_xmlDocument.DocumentElement.AppendChild(v_dataElement)
                            'Ghi nhÃƒÂ¡Ã‚ÂºÃ‚Â­n giao dÃƒÂ¡Ã‚Â»Ã¢â‚¬Â¹ch vÃƒÆ’Ã‚Â o TLLOG
                            v_lngErrCode = v_objMessageLog.TransLog(v_xmlDocument)

                            If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode
                        End If
                    Next
                End If
            End If

            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function Execute8879(ByVal v_strBATCHNAME As String, Optional ByVal v_strBCHFillter As String = "", Optional ByRef v_intMaxRow As Integer = 0) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = ATTR_MODULE & ".Batch.Execute8879", v_strErrorMessage As String
        Dim v_strSQL As String, v_ds, v_dsTLLOG As DataSet, v_objMessageLog As New MessageLog
        v_objMessageLog.NewDBInstance(gc_MODULE_HOST)
        Dim v_obj As New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)
        Dim i, j As Integer, v_strFRTABLE, v_strTOTABLE As String
        Dim v_xmlDocument As New Xml.XmlDocument, v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
        Dim v_strVALEXP, v_strVALUE, v_strFLDNAME, v_strDEFNAME, v_strFLDTYPE As String
        Dim v_attrFLDNAME, v_attrDATATYPE As Xml.XmlAttribute
        Dim v_strTLTXCD As Double
        Dim v_strOrgTxNum As String = ""
        Try
            'Lay thong tin sysvar
            Dim v_strSYSVAR, v_strCURRDATE, v_strPREVDATE, v_strNEXTDATE As String
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "CURRDATE", v_strCURRDATE)
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "PREVDATE", v_strPREVDATE)
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "NEXTDATE", v_strNEXTDATE)
            If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode

            v_strSQL = "SELECT LOG.TXNUM,LOG.TXDATE,CF.CUSTODYCD,AF.ACCTNO AFACCTNO,CF.FULLNAME," & vbCrLf &
                        "CF.ADDRESS,CF.IDCODE,TLF.NVALUE*TLF1.NVALUE AMOUNT,TLF2.NVALUE DUTYAMT," & vbCrLf &
                        "TLF3.NVALUE FEEAMT,'TRFODSRTL' TRFTYPE,CRA.REFACCTNO DESCACCTNO,CRB.BANKCODE BANKQUE," & vbCrLf &
                        "AF.BANKACCTNO BANACCTNO,(AF.bankname || ':' || CRB.BANKNAME) BANKNAME," & vbCrLf &
                        "CRA.REFACCTNO DESACCOUNTNAME,LOG.MSGACCT ACCTNO" & vbCrLf &
                        "FROM " & vbCrLf &
                        "TLLOG LOG,TLLOGFLD TLF,TLLOGFLD TLF1,TLLOGFLD TLF2,TLLOGFLD TLF3,TLLOGFLD TLF4," & vbCrLf &
                        "AFMAST AF,CFMAST CF,CIMAST CI,CRBDEFACCT CRA,CRBDEFBANK CRB" & vbCrLf &
                        "WHERE AF.ACCTNO = TLF4.CVALUE AND CI.AFACCTNO = AF.ACCTNO AND AF.CUSTID=CF.CUSTID " & vbCrLf &
                        "AND LOG.TXNUM=TLF.TXNUM AND LOG.TXDATE=TLF.TXDATE AND TLF.FLDCD='10' " & vbCrLf &
                        "AND LOG.TXNUM=TLF1.TXNUM AND LOG.TXDATE=TLF1.TXDATE AND TLF1.FLDCD='11' " & vbCrLf &
                        "AND LOG.TXNUM=TLF2.TXNUM AND LOG.TXDATE=TLF2.TXDATE AND TLF2.FLDCD='14' " & vbCrLf &
                        "AND LOG.TXNUM=TLF3.TXNUM AND LOG.TXDATE=TLF3.TXDATE AND TLF3.FLDCD='22' " & vbCrLf &
                        "AND LOG.TXNUM=TLF4.TXNUM AND LOG.TXDATE=TLF4.TXDATE AND TLF4.FLDCD='02' " & vbCrLf &
                        "AND AF.BANKNAME=CRA.REFBANK AND CRA.TRFCODE='TRFODSRTL'" & vbCrLf &
                        "AND AF.BANKNAME=CRB.BANKCODE AND LOG.TLTXCD ='" & gc_OD_MATCH_TRADE_LOT_RETAIL & "'" & vbCrLf &
                        "AND CI.corebank='Y' AND LOG.DELTD<>'Y' " & vbCrLf &
                        "AND LOG.TXNUM NOT IN" & vbCrLf &
                        "(" & vbCrLf &
                        "   SELECT REQX.CVAL CATXNUM" & vbCrLf &
                        "   FROM CRBTXREQDTL REQX,CRBTXREQ REQ" & vbCrLf &
                        "   WHERE REQX.REQID=REQ.REQID AND REQX.FLDNAME='CATXNUM'" & vbCrLf &
                        "   AND REQ.STATUS IN ('C','P') " & vbCrLf &
                        "   AND REQ.TRFCODE='TRFODSRTL'" & vbCrLf &
                        ")" & vbCrLf &
                        "ORDER BY LOG.AUTOID ASC"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If Not v_ds Is Nothing Then
                If v_ds.Tables.Count > 0 Then
                    For i = 0 To v_ds.Tables(0).Rows.Count - 1
                        'Sinh giao dich gen ra transferlog
                        v_lngErrCode = BuildBatchTxMsg(v_xmlDocument, v_strBATCHNAME)
                        v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value = gc_RM_TRANSFER_OTHER_2
                        v_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("AFACCTNO")).Substring(0, 4)
                        v_strTLTXCD = v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value
                        'Nap giao dich
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
                                v_strVALUE = ""
                                Select Case v_strFLDNAME
                                    Case "03" 'SECACCTNO
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("AFACCTNO")
                                    Case "05" 'DESACCTNO
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("DESCACCTNO")
                                    Case "07" 'DESACCOUNTNAME
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("DESACCOUNTNAME")
                                    Case "06" 'TRFTYPE
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("TRFTYPE")
                                    Case "90" 'CUSTNAME
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("FULLNAME")
                                    Case "91" 'ADDRESS
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("ADDRESS")
                                    Case "92" 'LICENSE
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("IDCODE")
                                    Case "93" 'BANACCOUNT
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("BANACCTNO")
                                    Case "94" 'BANKNAME
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("BANKNAME")
                                    Case "95" 'BANKQUE
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("BANKQUE")
                                    Case "02" 'CATXNUM
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("TXNUM")
                                    Case "10" 'Amount
                                        v_strVALUE = Convert.ToString(Convert.ToDecimal(v_ds.Tables(0).Rows(i).Item("AMOUNT")) - Convert.ToDecimal(v_ds.Tables(0).Rows(i).Item("FEEAMT")))
                                    Case "30" 'DESC                       
                                        v_strVALUE = "Thu tiền bán CK lô lẻ - TK : " &
                                                    v_ds.Tables(0).Rows(i).Item("CUSTODYCD") &
                                                    ", số tiền : " &
                                                    Convert.ToString(Convert.ToDecimal(
                                                                     v_ds.Tables(0).Rows(i).Item("AMOUNT")) -
                                                                     Convert.ToDecimal(v_ds.Tables(0).Rows(i).Item("FEEAMT")))
                                    Case Else
                                        v_strVALUE = ""
                                End Select

                                v_entryNode.InnerText = v_strVALUE
                                v_dataElement.AppendChild(v_entryNode)
                            Next

                            v_xmlDocument.DocumentElement.AppendChild(v_dataElement)
                            'Ghi nhÃƒÂ¡Ã‚ÂºÃ‚Â­n giao dÃƒÂ¡Ã‚Â»Ã¢â‚¬Â¹ch vÃƒÆ’Ã‚Â o TLLOG
                            v_lngErrCode = v_objMessageLog.TransLog(v_xmlDocument)

                            If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode
                        End If
                    Next
                End If
            End If

            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function Execute8879DutyFee(ByVal v_strBATCHNAME As String, Optional ByVal v_strBCHFillter As String = "", Optional ByRef v_intMaxRow As Integer = 0) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = ATTR_MODULE & ".Batch.Execute8879DutyFee", v_strErrorMessage As String
        Dim v_strSQL As String, v_ds, v_dsTLLOG As DataSet, v_objMessageLog As New MessageLog
        v_objMessageLog.NewDBInstance(gc_MODULE_HOST)
        Dim v_obj As New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)
        Dim i, j As Integer, v_strFRTABLE, v_strTOTABLE As String
        Dim v_xmlDocument As New Xml.XmlDocument, v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
        Dim v_strVALEXP, v_strVALUE, v_strFLDNAME, v_strDEFNAME, v_strFLDTYPE As String
        Dim v_attrFLDNAME, v_attrDATATYPE As Xml.XmlAttribute
        Dim v_strTLTXCD As Double
        Dim v_strOrgTxNum As String = ""
        Try
            'Lay thong tin sysvar
            Dim v_strSYSVAR, v_strCURRDATE, v_strPREVDATE, v_strNEXTDATE As String
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "CURRDATE", v_strCURRDATE)
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "PREVDATE", v_strPREVDATE)
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "NEXTDATE", v_strNEXTDATE)
            If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode

            v_strSQL = "SELECT LOG.TXNUM,LOG.TXDATE,CF.CUSTODYCD,AF.ACCTNO AFACCTNO,CF.FULLNAME," & vbCrLf &
                        "CF.ADDRESS,CF.IDCODE,TLF.NVALUE*TLF1.NVALUE AMOUNT,TLF2.NVALUE DUTYAMT," & vbCrLf &
                        "TLF3.NVALUE FEEAMT,'TRFODSRTDF' TRFTYPE,CRA.REFACCTNO DESCACCTNO,CRB.BANKCODE BANKQUE," & vbCrLf &
                        "AF.BANKACCTNO BANACCTNO,(AF.BANKNAME || ':' || CRB.BANKNAME) BANKNAME," & vbCrLf &
                        "CRA.REFACCTNAME DESACCOUNTNAME,LOG.MSGACCT ACCTNO" & vbCrLf &
                        "FROM " & vbCrLf &
                        "TLLOG LOG,TLLOGFLD TLF,TLLOGFLD TLF1,TLLOGFLD TLF2,TLLOGFLD TLF3,TLLOGFLD TLF4," & vbCrLf &
                        "AFMAST AF,CFMAST CF,CIMAST CI,CRBDEFACCT CRA,CRBDEFBANK CRB" & vbCrLf &
                        "WHERE AF.ACCTNO = TLF4.CVALUE AND CI.AFACCTNO = AF.ACCTNO AND AF.CUSTID=CF.CUSTID " & vbCrLf &
                        "AND LOG.TXNUM=TLF.TXNUM AND LOG.TXDATE=TLF.TXDATE AND TLF.FLDCD='10' " & vbCrLf &
                        "AND LOG.TXNUM=TLF1.TXNUM AND LOG.TXDATE=TLF1.TXDATE AND TLF1.FLDCD='11' " & vbCrLf &
                        "AND LOG.TXNUM=TLF2.TXNUM AND LOG.TXDATE=TLF2.TXDATE AND TLF2.FLDCD='14' " & vbCrLf &
                        "AND LOG.TXNUM=TLF3.TXNUM AND LOG.TXDATE=TLF3.TXDATE AND TLF3.FLDCD='22' " & vbCrLf &
                        "AND LOG.TXNUM=TLF4.TXNUM AND LOG.TXDATE=TLF4.TXDATE AND TLF4.FLDCD='02' " & vbCrLf &
                        "AND AF.BANKNAME=CRA.REFBANK AND CRA.TRFCODE='TRFODSRTDF'" & vbCrLf &
                        "AND AF.BANKNAME=CRB.BANKCODE AND LOG.TLTXCD ='" & gc_OD_MATCH_TRADE_LOT_RETAIL & "'" & vbCrLf &
                        "AND CI.corebank='Y' AND LOG.DELTD<>'Y' " & vbCrLf &
                        "AND LOG.TXNUM NOT IN" & vbCrLf &
                        "(" & vbCrLf &
                        "   SELECT REQX.CVAL CATXNUM" & vbCrLf &
                        "   FROM CRBTXREQDTL REQX,CRBTXREQ REQ" & vbCrLf &
                        "   WHERE REQX.REQID=REQ.REQID AND REQX.FLDNAME='CATXNUM'" & vbCrLf &
                        "   AND REQ.STATUS IN ('C','P') " & vbCrLf &
                        "   AND REQ.TRFCODE='TRFODSRTDF'" & vbCrLf &
                        ")" & vbCrLf &
                        "ORDER BY LOG.AUTOID ASC"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If Not v_ds Is Nothing Then
                If v_ds.Tables.Count > 0 Then
                    For i = 0 To v_ds.Tables(0).Rows.Count - 1
                        'Sinh giao dich gen ra transferlog
                        v_lngErrCode = BuildBatchTxMsg(v_xmlDocument, v_strBATCHNAME)
                        v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value = gc_RM_TRANSFER_OTHER_2
                        v_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("AFACCTNO")).Substring(0, 4)
                        v_strTLTXCD = v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value
                        'Nap giao dich
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
                                v_strVALUE = ""
                                Select Case v_strFLDNAME
                                    Case "03" 'SECACCTNO
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("AFACCTNO")
                                    Case "05" 'DESACCTNO
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("DESCACCTNO")
                                    Case "07" 'DESACCOUNTNAME
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("DESACCOUNTNAME")
                                    Case "06" 'TRFTYPE
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("TRFTYPE")
                                    Case "90" 'CUSTNAME
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("FULLNAME")
                                    Case "91" 'ADDRESS
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("ADDRESS")
                                    Case "92" 'LICENSE
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("IDCODE")
                                    Case "93" 'BANACCOUNT
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("BANACCTNO")
                                    Case "94" 'BANKNAME
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("BANKNAME")
                                    Case "95" 'BANKQUE
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("BANKQUE")
                                    Case "02" 'CATXNUM
                                        v_strVALUE = v_ds.Tables(0).Rows(i).Item("TXNUM")
                                    Case "10" 'Amount
                                        v_strVALUE = Convert.ToDecimal(v_ds.Tables(0).Rows(i).Item("DUTYAMT")).ToString()
                                    Case "30" 'DESC                       
                                        v_strVALUE = "Thu tiền bán CK lô lẻ - TK : " &
                                                    v_ds.Tables(0).Rows(i).Item("CUSTODYCD") &
                                                    ", số tiền : " &
                                                    Convert.ToString(Convert.ToDecimal(
                                                                     v_ds.Tables(0).Rows(i).Item("AMOUNT")) -
                                                                     Convert.ToDecimal(v_ds.Tables(0).Rows(i).Item("FEEAMT")))
                                    Case Else
                                        v_strVALUE = ""
                                End Select

                                v_entryNode.InnerText = v_strVALUE
                                v_dataElement.AppendChild(v_entryNode)
                            Next

                            v_xmlDocument.DocumentElement.AppendChild(v_dataElement)
                            'Ghi nhÃƒÂ¡Ã‚ÂºÃ‚Â­n giao dÃƒÂ¡Ã‚Â»Ã¢â‚¬Â¹ch vÃƒÆ’Ã‚Â o TLLOG
                            v_lngErrCode = v_objMessageLog.TransLog(v_xmlDocument)

                            If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode
                        End If
                    Next
                End If
            End If

            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

#End Region

End Class
