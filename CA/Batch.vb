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
        ATTR_MODULE = "CA"
    End Sub

    'Hàm thực hiện chạy xử lý Batch của phân hệ nghiệp vụ
    Overrides Function ExecuteRouter(ByVal v_strBCHMDL As String, Optional ByVal v_strBCHFillter As String = "", Optional ByRef v_intMaxRow As Integer = 0) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = ATTR_MODULE & ".Batch.ExecuteRouter", v_strErrorMessage As String
        Dim v_strxmlMessage As String, v_xmlMessage As New Xml.XmlDocument
        Try
            'Chuyển đến các bước chạy xử lý của phân hệ nghiệp vụ
            Select Case v_strBCHMDL
                Case "CAEXEC"
                    'Thực hiện quy�?n
                    v_lngErrCode = CAExecution(v_strBCHMDL)
                Case "CASEND"
                    'Send 
                    v_lngErrCode = CASend(v_strBCHMDL)
            End Select
            'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
    Private Function CAExecution(ByVal v_strBATCHNAME As String, Optional ByVal v_strBCHFillter As String = "", Optional ByRef v_intMaxRow As Integer = 0) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = ATTR_MODULE & ".Batch.CAExecution", v_strErrorMessage As String
        Dim v_strSQL As String, v_ds, v_dsHalt, v_dsTLLOG As DataSet, v_objMessageLog As New MessageLog
        v_objMessageLog.NewDBInstance(gc_MODULE_HOST)
        Dim v_obj As New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)
        Dim i, j As Integer, v_strFRTABLE, v_strTOTABLE As String
        Dim v_xmlDocument As New Xml.XmlDocument, v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
        Dim v_strVALEXP, v_strVALUE, v_strFLDNAME, v_strDEFNAME, v_strFLDTYPE As String
        Dim v_attrFLDNAME, v_attrDATATYPE As Xml.XmlAttribute
        Dim v_strTLTXCD As String
        Try
            v_strSQL = "SELECT COUNT(*) MAXROW FROM  CASCHD"
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



            'Chi cho phep thuc hien batch tu dong cho cac su kien gc_CA_CATYPE_CHANGE_TRADING_PLACE_STOCK 
            v_strSQL = "SELECT SCHD.AUTOID,SCHD.CAMASTID, SCHD.AFACCTNO, SCHD.BALANCE, SCHD.AMT, SCHD.QTTY, SCHD.AAMT, SCHD.AQTTY, SCHD.STATUS, " & ControlChars.CrLf _
                & " SYM.SYMBOL, SYM.CODEID, SYM.PARVALUE, EXSYM.CODEID EXCODEID, EXSYM.PARVALUE EXPARVALUE, " & ControlChars.CrLf _
                & " SCHD.AFACCTNO CIACCTNO, SCHD.AFACCTNO || SYM.CODEID SEACCTNO, SCHD.AFACCTNO || EXSYM.CODEID EXSEACCTNO, " & ControlChars.CrLf _
                & " CA.CATYPE, CA.REPORTDATE, CA.ACTIONDATE, CA.DUEDATE, CA.EXPRICE, CA.INTERESTPERIOD,  " & ControlChars.CrLf _
                & " CA.EXRATE, CA.RIGHTOFFRATE, CA.DEVIDENTRATE, CA.DEVIDENTSHARES, CA.SPLITRATE, CA.INTERESTRATE " & ControlChars.CrLf _
                & " FROM CAMAST CA, (SELECT MOD.* FROM (SELECT ROWNUM INDEXROW,CASCHD.* FROM CASCHD) MOD WHERE 0=0 " & v_strBCHFillter & ") SCHD, SBSECURITIES SYM, SBSECURITIES EXSYM  " & ControlChars.CrLf _
                & " WHERE CA.CODEID=SYM.CODEID AND (CASE WHEN CA.EXCODEID IS NOT NULL THEN CA.EXCODEID ELSE CA.CODEID END)=EXSYM.CODEID " & ControlChars.CrLf _
                & " AND CA.CATYPE in ('" & gc_CA_CATYPE_CHANGE_TRADING_PLACE_STOCK & "','" & gc_CA_CATYPE_HALT & "') " & ControlChars.CrLf _
                & " AND CA.CAMASTID=SCHD.CAMASTID AND SCHD.STATUS<>'C' AND SCHD.DELTD<>'Y' " & ControlChars.CrLf _
                & " AND CA.STATUS='S' AND CA.ACTIONDATE <= TO_DATE('" & v_strCURRDATE & "','" & gc_FORMAT_DATE & "')"

            'Thứ tự ORDER BY là quan tr�?ng
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To v_ds.Tables(0).Rows.Count - 1 Step 1
                    v_lngErrCode = BuildBatchTxMsg(v_xmlDocument, v_strBATCHNAME)
                    v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value = gc_CA_AUTO_EXECUTE_CHANGE_TRADING_CAEVENT
                    'Modified by MinhTK, 17-Apr-07: Khach hang cua chi nhanh nao thi GD phai thuoc chi nhanh do
                    v_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("AFACCTNO")).Substring(0, 4)
                    'End of modified by MinhTK, 7-Apr-07
                    v_strTXDESC = "Coporate action auto-execution"
                    v_strTLTXCD = v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value

                    'Nạp giao dịch
                    v_strSQL = "SELECT FLDNAME, FLDTYPE, DEFNAME FROM FLDMASTER " & ControlChars.CrLf _
                        & "WHERE TRIM(OBJNAME)='" & Trim(v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value) & "' ORDER BY ODRNUM" 'Thứ tự ODRER BY là quan tr�?ng
                    v_dsTLLOG = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_dsTLLOG.Tables(0).Rows.Count > 0 Then
                        v_dataElement = v_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "fields", "")

                        'Tạo phần nội dung của giao dịch
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
                                    v_strVALUE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("AUTOID")))
                                Case "02" 'CAMASTID
                                    v_strVALUE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("CAMASTID")))
                                Case "03" 'AFACCTNO,CIACCTNO
                                    v_strVALUE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("AFACCTNO")))
                                Case "04" 'SYMBOL
                                    v_strVALUE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("SYMBOL")))
                                Case "05" 'CATYPE
                                    v_strVALUE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("CATYPE")))
                                Case "06" 'REPORTDATE
                                    v_strVALUE = Trim(Format(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("REPORTDATE")), gc_FORMAT_DATE))
                                Case "07" 'ACTIONDATE
                                    v_strVALUE = Trim(Format(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("ACTIONDATE")), gc_FORMAT_DATE))
                                Case "08" 'SEACCTNO
                                    v_strVALUE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("SEACCTNO")))
                                Case "09" 'EXSEACCTNO
                                    v_strVALUE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("EXSEACCTNO")))
                                Case "10" 'AMT
                                    v_strVALUE = Trim(gf_CorrectNumericField(v_ds.Tables(0).Rows(i)("AMT")))
                                Case "11" 'QTTY
                                    v_strVALUE = Trim(gf_CorrectNumericField(v_ds.Tables(0).Rows(i)("QTTY")))
                                Case "12" 'AAMT
                                    v_strVALUE = Trim(gf_CorrectNumericField(v_ds.Tables(0).Rows(i)("AAMT")))
                                Case "13" 'AQTTY
                                    v_strVALUE = Trim(gf_CorrectNumericField(v_ds.Tables(0).Rows(i)("AQTTY")))
                                Case "14" 'PARVALUE
                                    v_strVALUE = Trim(gf_CorrectNumericField(v_ds.Tables(0).Rows(i)("PARVALUE")))
                                Case "15" 'EXPARVALUE
                                    v_strVALUE = Trim(gf_CorrectNumericField(v_ds.Tables(0).Rows(i)("EXPARVALUE")))
                                Case "30" 'DESC                                              
                                    v_strVALUE = v_strTXDESC
                            End Select
                            v_entryNode.InnerText = v_strVALUE
                            v_dataElement.AppendChild(v_entryNode)
                        Next
                        v_xmlDocument.DocumentElement.AppendChild(v_dataElement)
                        'Ghi nhận giao dịch vào TLLOG
                        v_lngErrCode = v_objMessageLog.TransLog(v_xmlDocument)
                        If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode
                    End If
                Next
            End If

            ' batch tu dong cho cac su kien gc_CA_CATYPE_CONVERT_BOND_TO_SHARE 
            v_strSQL = "SELECT SCHD.AUTOID,SCHD.CAMASTID, SCHD.AFACCTNO, SCHD.BALANCE, SCHD.AMT, SCHD.QTTY, SCHD.AAMT, SCHD.AQTTY, SCHD.STATUS, " & ControlChars.CrLf _
                & " SYM.SYMBOL, SYM.CODEID, SYM.PARVALUE, EXSYM.CODEID EXCODEID, EXSYM.PARVALUE EXPARVALUE, " & ControlChars.CrLf _
                & " SCHD.AFACCTNO CIACCTNO, SCHD.AFACCTNO || SYM.CODEID SEACCTNO, SCHD.AFACCTNO || EXSYM.CODEID EXSEACCTNO, " & ControlChars.CrLf _
                & " CA.CATYPE, CA.REPORTDATE, CA.ACTIONDATE, CA.DUEDATE, CA.EXPRICE, CA.INTERESTPERIOD,  " & ControlChars.CrLf _
                & " CA.EXRATE, CA.RIGHTOFFRATE, CA.DEVIDENTRATE, CA.DEVIDENTSHARES, CA.SPLITRATE, CA.INTERESTRATE " & ControlChars.CrLf _
                & " FROM CAMAST CA, (SELECT MOD.* FROM (SELECT ROWNUM INDEXROW,CASCHD.* FROM CASCHD) MOD WHERE 0=0 " & v_strBCHFillter & ") SCHD, SBSECURITIES SYM, SBSECURITIES EXSYM  " & ControlChars.CrLf _
                & " WHERE CA.CODEID=SYM.CODEID AND CA.EXCODEID=EXSYM.CODEID " & ControlChars.CrLf _
                & " AND CA.CATYPE ='" & gc_CA_CATYPE_CONVERT_BOND_TO_SHARE & "' " & ControlChars.CrLf _
                & " AND CA.CAMASTID=SCHD.CAMASTID AND SCHD.STATUS<>'C' AND SCHD.DELTD<>'Y' " & ControlChars.CrLf _
                & " AND CA.STATUS='S' AND CA.ACTIONDATE <= TO_DATE('" & v_strCURRDATE & "','" & gc_FORMAT_DATE_Db & "')"

            'Thá»© tá»± ORDER BY lÃ  quan trá»?ng
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                Dim v_strSQLSE As String
                Dim v_dsSE As DataSet
                For i = 0 To v_ds.Tables(0).Rows.Count - 1 Step 1
                    'Kiểm tra tài khoản SE có tồn tại không

                    v_strSQLSE = "SELECT * FROM SEMAST WHERE TRIM(ACCTNO)='" & Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("EXSEACCTNO"))) & "'"
                    v_dsSE = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQLSE)
                    If Not v_dsSE.Tables(0).Rows.Count > 0 Then
                        'Tự động mở tài khoản SE nếu chưa có tài khoản này.
                        v_strSQLSE = "INSERT INTO SEMAST (ACTYPE,CUSTID,ACCTNO,CODEID,AFACCTNO," & ControlChars.CrLf _
                                                                   & "OPNDATE,LASTDATE,STATUS,IRTIED,IRCD," & ControlChars.CrLf _
                                                                   & "COSTPRICE,TRADE,MORTAGE,MARGIN,NETTING," & ControlChars.CrLf _
                                                                   & "STANDING,WITHDRAW,DEPOSIT,LOAN) " & ControlChars.CrLf _
                                                       & "SELECT TYP.SETYPE, AF.CUSTID, '" & Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("EXSEACCTNO"))) & "', '" & Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("EXCODEID"))) & "','" & Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("AFACCTNO"))) & "'," & ControlChars.CrLf _
                                                       & "TO_DATE('" & v_strCURRDATE & "', '" & gc_FORMAT_DATE & "'),TO_DATE('" & v_strCURRDATE & "', '" & gc_FORMAT_DATE & "'),'A','Y','001'," & ControlChars.CrLf _
                                                       & "0,0,0,0,0,0,0,0,0 " & ControlChars.CrLf _
                                                       & "FROM AFMAST AF, AFTYPE TYP WHERE AF.ACTYPE=TYP.ACTYPE AND AF.ACCTNO='" & Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("AFACCTNO"))) & "'"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQLSE)
                    End If

                    v_lngErrCode = BuildBatchTxMsg(v_xmlDocument, v_strBATCHNAME)
                    v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value = gc_CA_AUTO_EXE_BOND_TO_SHARE
                    'Modified by MinhTK, 17-Apr-07: Khach hang cua chi nhanh nao thi GD phai thuoc chi nhanh do
                    v_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("AFACCTNO")).Substring(0, 4)
                    'End of modified by MinhTK, 7-Apr-07
                    v_strTXDESC = "Coporate action auto-execution"
                    v_strTLTXCD = v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value

                    'Náº¡p giao dá»‹ch
                    v_strSQL = "SELECT FLDNAME, FLDTYPE, DEFNAME FROM FLDMASTER " & ControlChars.CrLf _
                        & "WHERE TRIM(OBJNAME)='" & Trim(v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value) & "' ORDER BY ODRNUM" 'Thá»© tá»± ODRER BY lÃ  quan trá»?ng
                    v_dsTLLOG = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_dsTLLOG.Tables(0).Rows.Count > 0 Then
                        v_dataElement = v_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "fields", "")

                        'Táº¡o pháº§n ná»™i dung cá»§a giao dá»‹ch
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
                                    v_strVALUE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("AUTOID")))
                                Case "02" 'CAMASTID
                                    v_strVALUE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("CAMASTID")))
                                Case "03" 'AFACCTNO,CIACCTNO
                                    v_strVALUE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("AFACCTNO")))
                                Case "04" 'SYMBOL
                                    v_strVALUE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("SYMBOL")))
                                Case "05" 'CATYPE
                                    v_strVALUE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("CATYPE")))
                                Case "06" 'REPORTDATE
                                    v_strVALUE = Trim(Format(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("REPORTDATE")), gc_FORMAT_DATE))
                                Case "07" 'ACTIONDATE
                                    v_strVALUE = Trim(Format(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("ACTIONDATE")), gc_FORMAT_DATE))
                                Case "08" 'SEACCTNO
                                    v_strVALUE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("SEACCTNO")))
                                Case "09" 'EXSEACCTNO
                                    v_strVALUE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("EXSEACCTNO")))
                                Case "10" 'AMT
                                    v_strVALUE = Trim(gf_CorrectNumericField(v_ds.Tables(0).Rows(i)("AMT")))
                                Case "11" 'QTTY
                                    v_strVALUE = Trim(gf_CorrectNumericField(v_ds.Tables(0).Rows(i)("QTTY")))
                                Case "12" 'AAMT
                                    v_strVALUE = Trim(gf_CorrectNumericField(v_ds.Tables(0).Rows(i)("AAMT")))
                                Case "13" 'AQTTY
                                    v_strVALUE = Trim(gf_CorrectNumericField(v_ds.Tables(0).Rows(i)("AQTTY")))
                                Case "14" 'PARVALUE
                                    v_strVALUE = Trim(gf_CorrectNumericField(v_ds.Tables(0).Rows(i)("PARVALUE")))
                                Case "15" 'EXPARVALUE
                                    v_strVALUE = Trim(gf_CorrectNumericField(v_ds.Tables(0).Rows(i)("EXPARVALUE")))
                                Case "30" 'DESC                                              
                                    v_strVALUE = v_strTXDESC
                            End Select
                            v_entryNode.InnerText = v_strVALUE
                            v_dataElement.AppendChild(v_entryNode)
                        Next
                        v_xmlDocument.DocumentElement.AppendChild(v_dataElement)
                        'Ghi nháº­n giao dá»‹ch vÃ o TLLOG
                        v_lngErrCode = v_objMessageLog.TransLog(v_xmlDocument)
                        If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode
                    End If
                Next
            End If
            'Dim v_strSYMBOL, v_strTOTRADEPLACE, v_strFRTRADEPLACE As String
            'v_strCODEID = Trim(v_ds.Tables(0).Rows(0)("CODEID"))
            'v_strSYMBOL = Trim(v_ds.Tables(0).Rows(0)("SYMBOL"))
            'v_strTOTRADEPLACE = Trim(v_ds.Tables(0).Rows(0)("TOTRADEPLACE"))
            'v_strFRTRADEPLACE = Trim(v_ds.Tables(0).Rows(0)("FRTRADEPLACE"))
            ''Chuyen san trong sbsecurities
            'v_strSQL = "UPDATE SBSECURITIES SET TRADEPLACE ='" & v_strFRTRADEPLACE & "' WHERE CODEID='" & v_strCODEID & "'"
            'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            ''Thay doi ticksize cho phu hop voi san
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

            'Khi nhung giao dich khong can execute contract thi thuc hien send CA event
            v_strSQL = "SELECT * FROM CAMAST WHERE STATUS='S' AND (SELECT COUNT(*) FROM CASCHD WHERE STATUS='S' AND CASCHD.CAMASTID=CAMAST.CAMASTID)=0"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To v_ds.Tables(0).Rows.Count - 1 Step 1
                    v_lngErrCode = BuildBatchTxMsg(v_xmlDocument, v_strBATCHNAME)
                    v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value = gc_CA_AUTO_EXECUTE_CAEVENT
                    v_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("CAMASTID")).Substring(0, 4)
                    v_strTXDESC = "Coporate action auto execute"
                    v_strTLTXCD = v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value

                    'nap giao dich
                    v_strSQL = "SELECT FLDNAME, FLDTYPE, DEFNAME FROM FLDMASTER " & ControlChars.CrLf _
                        & "WHERE TRIM(OBJNAME)='" & Trim(v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value) & "' ORDER BY ODRNUM" 'Thứ tự ODRER BY là quan tr�?ng
                    v_dsTLLOG = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_dsTLLOG.Tables(0).Rows.Count > 0 Then
                        v_dataElement = v_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "fields", "")

                        'Tao noi dung giao dich
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
                                Case "03" 'CAMASTID
                                    v_strVALUE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("CAMASTID")))
                                Case "04" 'SYMBOL
                                    v_strVALUE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("CODEID")))
                                Case "05" 'CATYPE
                                    v_strVALUE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("CATYPE")))
                                Case "06" 'REPORTDATE
                                    v_strVALUE = Trim(Format(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("REPORTDATE")), gc_FORMAT_DATE))
                                Case "07" 'ACTIONDATE
                                    v_strVALUE = Trim(Format(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("ACTIONDATE")), gc_FORMAT_DATE))
                                Case "10" 'RATE
                                    v_strVALUE = Trim(gf_CorrectNumericField(v_ds.Tables(0).Rows(i)("RATE")))
                                Case "30" 'DESC                                              
                                    v_strVALUE = v_strTXDESC
                                Case "40" 'Status                                              
                                    v_strVALUE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("STATUS")))
                            End Select
                            v_entryNode.InnerText = v_strVALUE
                            v_dataElement.AppendChild(v_entryNode)
                        Next
                        v_xmlDocument.DocumentElement.AppendChild(v_dataElement)
                        'Ghi nhận giao dịch vào TLLOG
                        v_lngErrCode = v_objMessageLog.TransLog(v_xmlDocument)
                        If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode
                    End If
                Next
            End If

            'Cho gc_CA_CATYPE_HALT
            'Neu den ngay tam ngung giao dich thi HALT lai chung khoan.
            v_strSQL = "SELECT CAMAST.* FROM CAMAST,SBSECURITIES SEC WHERE CAMAST.CATYPE='" & gc_CA_CATYPE_HALT & "'  AND CAMAST.ACTIONDATE  <= TO_DATE('" & v_strCURRDATE & "','" & gc_FORMAT_DATE & "') AND CAMAST.CODEID=SEC.CODEID AND SEC.HALT='N' AND CAMAST.STATUS ='A' ORDER BY CAMASTID"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To v_ds.Tables(0).Rows.Count - 1 Step 1
                    v_strSQL = "UPDATE SBSECURITIES SET HALT='Y' WHERE CODEID='" & v_ds.Tables(0).Rows(i)("CODEID") & "'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                Next
            End If


            'Cho gc_CA_CATYPE_HALT
            'Neu den ngay ket thuc tam ngung giao dich thi active lai chung khoan.
            v_strSQL = "SELECT CAMAST.* FROM CAMAST,SBSECURITIES SEC WHERE CAMAST.CATYPE='" & gc_CA_CATYPE_HALT & "'  AND CAMAST.TRADEDATE <= TO_DATE('" & v_strCURRDATE & "','" & gc_FORMAT_DATE & "') AND CAMAST.CODEID=SEC.CODEID AND SEC.HALT='Y' AND CAMAST.STATUS ='A' ORDER BY CAMASTID"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To v_ds.Tables(0).Rows.Count - 1 Step 1
                    v_strSQL = "UPDATE SBSECURITIES SET HALT='N' WHERE CODEID='" & v_ds.Tables(0).Rows(i)("CODEID") & "'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                    v_strSQL = "UPDATE CAMAST SET STATUS='C' WHERE CODEID='" & v_ds.Tables(0).Rows(i)("CODEID") & "' AND CAMAST.CATYPE='" & gc_CA_CATYPE_HALT & "'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                Next
            End If


            ''Khi nhung giao dich khong can execute contract thi thuc hien execute CA event
            'v_strSQL = "SELECT * FROM CAMAST WHERE STATUS='S' AND (SELECT COUNT(*) FROM CASCHD WHERE STATUS='S' AND CASCHD.CAMASTID=CAMAST.CAMASTID)=0"
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'If v_ds.Tables(0).Rows.Count > 0 Then
            '    For i = 0 To v_ds.Tables(0).Rows.Count - 1 Step 1
            '        '1. Cap nhat trang thai cua CA event
            '        v_strSQL = "UPDATE CAMAST SET STATUS='C' WHERE TRIM(CAMASTID)='" & Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("CAMASTID"))) & "'"
            '        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            '    Next
            'End If
            'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
    Private Function CASend(ByVal v_strBATCHNAME As String, Optional ByVal v_strBCHFillter As String = "", Optional ByRef v_intMaxRow As Integer = 0) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = ATTR_MODULE & ".Batch.CASend", v_strErrorMessage As String
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
            'Lấy tham số hệ thống
            v_strSQL = "SELECT COUNT(*) MAXROW FROM  CASCHD"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            v_intMaxRow = v_ds.Tables(0).Rows(0)("MAXROW")

            Dim v_strSYSVAR, v_strCURRDATE, v_strPREVDATE, v_strNEXTDATE As String
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "CURRDATE", v_strCURRDATE)
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "PREVDATE", v_strPREVDATE)
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "NEXTDATE", v_strNEXTDATE)
            If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode

            Dim v_dblOrderTradingFee, v_dblCIAvailable, v_dblCIBAmt, v_dblCIODAmt, v_dblCISecuredAmt, v_dblODFeeAmt, v_dblODFeeAcr, v_dblFeeRate, v_dblVatRate As Double
            Dim v_strOrgOrderID, v_strCodeID, v_strAFAcctno, v_strCIAcctno, v_strTXDESC As String





            'Chi cho phep thuc hien batch tu dong cho cac su kien  gc_CA_CATYPE_CHANGE_TRADING_PLACE_STOCK 
            v_strSQL = "SELECT SCHD.AUTOID,SCHD.CAMASTID, SCHD.AFACCTNO, SCHD.BALANCE, SCHD.AMT, SCHD.QTTY, SCHD.AAMT, SCHD.AQTTY, SCHD.STATUS, " & ControlChars.CrLf _
                    & " SYM.SYMBOL, SYM.CODEID, SYM.PARVALUE, EXSYM.CODEID EXCODEID, EXSYM.PARVALUE EXPARVALUE, " & ControlChars.CrLf _
                    & " SCHD.AFACCTNO CIACCTNO, SCHD.AFACCTNO || SYM.CODEID SEACCTNO, SCHD.AFACCTNO || EXSYM.CODEID EXSEACCTNO, " & ControlChars.CrLf _
                    & " CA.CATYPE, CA.REPORTDATE, CA.ACTIONDATE, CA.DUEDATE, CA.EXPRICE, CA.INTERESTPERIOD, " & ControlChars.CrLf _
                    & " CA.EXRATE, CA.RIGHTOFFRATE, CA.DEVIDENTRATE, CA.DEVIDENTSHARES, CA.SPLITRATE, CA.INTERESTRATE " & ControlChars.CrLf _
                    & " FROM CAMAST CA, (SELECT MOD.* FROM (SELECT ROWNUM INDEXROW,CASCHD.* FROM CASCHD) MOD WHERE 0=0 " & v_strBCHFillter & ") SCHD, SBSECURITIES SYM, SBSECURITIES EXSYM " & ControlChars.CrLf _
                    & " WHERE CA.CODEID=SYM.CODEID AND (CASE WHEN CA.EXCODEID IS NOT NULL THEN CA.EXCODEID ELSE CA.CODEID END)=EXSYM.CODEID " & ControlChars.CrLf _
                    & " AND CA.CATYPE ='" & gc_CA_CATYPE_CHANGE_TRADING_PLACE_STOCK & "' " & ControlChars.CrLf _
                    & " AND CA.CAMASTID=SCHD.CAMASTID AND SCHD.STATUS='A' AND SCHD.DELTD<>'Y' " & ControlChars.CrLf _
                    & " AND CA.STATUS='A' AND CA.ACTIONDATE <= TO_DATE('" & v_strCURRDATE & "','" & gc_FORMAT_DATE & "') " & ControlChars.CrLf


            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To v_ds.Tables(0).Rows.Count - 1 Step 1
                    v_lngErrCode = BuildBatchTxMsg(v_xmlDocument, v_strBATCHNAME)
                    v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value = gc_CA_AUTO_SEND_CHANGE_TRADING_CAEVENT
                    v_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("AFACCTNO")).Substring(0, 4)
                    v_strTXDESC = "Coporate action auto send"
                    v_strTLTXCD = v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value

                    'Nạp giao dịch
                    v_strSQL = "SELECT FLDNAME, FLDTYPE, DEFNAME FROM FLDMASTER " & ControlChars.CrLf _
                        & "WHERE TRIM(OBJNAME)='" & Trim(v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value) & "' ORDER BY ODRNUM" 'Thứ tự ODRER BY là quan tr�?ng
                    v_dsTLLOG = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_dsTLLOG.Tables(0).Rows.Count > 0 Then
                        v_dataElement = v_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "fields", "")

                        'Tạo phần nội dung của giao dịch
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
                                    v_strVALUE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("AUTOID")))
                                Case "02" 'CAMASTID
                                    v_strVALUE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("CAMASTID")))
                                Case "03" 'AFACCTNO,CIACCTNO
                                    v_strVALUE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("AFACCTNO")))
                                Case "04" 'SYMBOL
                                    v_strVALUE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("SYMBOL")))
                                Case "05" 'CATYPE
                                    v_strVALUE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("CATYPE")))
                                Case "06" 'REPORTDATE
                                    v_strVALUE = Trim(Format(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("REPORTDATE")), gc_FORMAT_DATE))
                                Case "07" 'ACTIONDATE
                                    v_strVALUE = Trim(Format(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("ACTIONDATE")), gc_FORMAT_DATE))
                                Case "08" 'SEACCTNO
                                    v_strVALUE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("SEACCTNO")))
                                Case "09" 'EXSEACCTNO
                                    v_strVALUE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("EXSEACCTNO")))
                                Case "10" 'AMT
                                    v_strVALUE = Trim(gf_CorrectNumericField(v_ds.Tables(0).Rows(i)("AMT")))
                                Case "11" 'QTTY
                                    v_strVALUE = Trim(gf_CorrectNumericField(v_ds.Tables(0).Rows(i)("QTTY")))
                                Case "12" 'AAMT
                                    v_strVALUE = Trim(gf_CorrectNumericField(v_ds.Tables(0).Rows(i)("AAMT")))
                                Case "13" 'AQTTY
                                    v_strVALUE = Trim(gf_CorrectNumericField(v_ds.Tables(0).Rows(i)("AQTTY")))
                                Case "14" 'PARVALUE
                                    v_strVALUE = Trim(gf_CorrectNumericField(v_ds.Tables(0).Rows(i)("PARVALUE")))
                                Case "15" 'EXPARVALUE
                                    v_strVALUE = Trim(gf_CorrectNumericField(v_ds.Tables(0).Rows(i)("EXPARVALUE")))
                                Case "30" 'DESC                                              
                                    v_strVALUE = v_strTXDESC
                                Case "40" 'Status                                              
                                    v_strVALUE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("STATUS")))
                                Case "41" 'v_strNewSTATUS                                              
                                    v_strVALUE = "S"
                            End Select
                            v_entryNode.InnerText = v_strVALUE
                            v_dataElement.AppendChild(v_entryNode)
                        Next
                        v_xmlDocument.DocumentElement.AppendChild(v_dataElement)
                        'Ghi nhận giao dịch vào TLLOG
                        v_lngErrCode = v_objMessageLog.TransLog(v_xmlDocument)
                        If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode
                    End If
                Next
            End If


            'Khi nhung giao dich khong can send contract thi thuc hien send CA event
            v_strSQL = "SELECT * FROM CAMAST WHERE STATUS in ('A','B') AND (SELECT COUNT(*) FROM CASCHD WHERE STATUS='A' AND CASCHD.CAMASTID=CAMAST.CAMASTID)=0"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To v_ds.Tables(0).Rows.Count - 1 Step 1
                    v_lngErrCode = BuildBatchTxMsg(v_xmlDocument, v_strBATCHNAME)
                    v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value = gc_CA_AUTO_SEND_CAEVENT
                    v_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("CAMASTID")).Substring(0, 4)
                    v_strTXDESC = "Coporate action auto send"
                    v_strTLTXCD = v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value

                    'nap giao dich
                    v_strSQL = "SELECT FLDNAME, FLDTYPE, DEFNAME FROM FLDMASTER " & ControlChars.CrLf _
                        & "WHERE TRIM(OBJNAME)='" & Trim(v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value) & "' ORDER BY ODRNUM" 'Thứ tự ODRER BY là quan tr�?ng
                    v_dsTLLOG = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_dsTLLOG.Tables(0).Rows.Count > 0 Then
                        v_dataElement = v_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "fields", "")

                        'Tao noi dung giao dich
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
                                Case "03" 'CAMASTID
                                    v_strVALUE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("CAMASTID")))
                                Case "04" 'SYMBOL
                                    v_strVALUE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("CODEID")))
                                Case "05" 'CATYPE
                                    v_strVALUE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("CATYPE")))
                                Case "06" 'REPORTDATE
                                    v_strVALUE = Trim(Format(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("REPORTDATE")), gc_FORMAT_DATE))
                                Case "07" 'ACTIONDATE
                                    v_strVALUE = Trim(Format(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("ACTIONDATE")), gc_FORMAT_DATE))
                                Case "10" 'RATE
                                    v_strVALUE = Trim(gf_CorrectNumericField(v_ds.Tables(0).Rows(i)("RATE")))
                                Case "30" 'DESC                                              
                                    v_strVALUE = v_strTXDESC
                                Case "40" 'Status                                              
                                    v_strVALUE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("STATUS")))
                            End Select
                            v_entryNode.InnerText = v_strVALUE
                            v_dataElement.AppendChild(v_entryNode)
                        Next
                        v_xmlDocument.DocumentElement.AppendChild(v_dataElement)
                        'Ghi nhận giao dịch vào TLLOG
                        v_lngErrCode = v_objMessageLog.TransLog(v_xmlDocument)
                        If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode
                    End If
                Next
            End If

            ''Khi nhung giao dich khong can send contract thi thuc hien send CA event
            'v_strSQL = "SELECT * FROM CAMAST WHERE STATUS='A' AND (SELECT COUNT(*) FROM CASCHD WHERE STATUS='A' AND CASCHD.CAMASTID=CAMAST.CAMASTID)=0"
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'If v_ds.Tables(0).Rows.Count > 0 Then
            '    For i = 0 To v_ds.Tables(0).Rows.Count - 1 Step 1
            '        '1. Cap nhat trang thai cua CA event
            '        v_strSQL = "UPDATE CAMAST SET STATUS='S' WHERE TRIM(CAMASTID)='" & Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("CAMASTID"))) & "'"
            '        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            '    Next
            'End If

            'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
End Class
