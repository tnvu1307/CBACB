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

    'Vị trí của GLBANK.
    Const POS_GLBANK = 10
    Const LEN_GLBANK = 5

#Region " Constructor"
    Public Sub New()
        ATTR_MODULE = "GL"
    End Sub
#End Region

#Region " Implement functions"
    Overrides Function txImpUpdate(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Return 0
    End Function

    Overrides Function txImpCheck(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        'ContextUtil.SetComplete()
        Return 0
    End Function

    Overrides Function txImpMisc(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        'Xác định mã giao dịch tương ứng
        Dim v_lngErrorCode As Long
        Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
        Dim v_strTLTXCD As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLTXCD), Xml.XmlAttribute).Value)
        Select Case v_strTLTXCD
            Case gc_GL_ACCOUNTINQUIRY
                v_lngErrorCode = InquiryAccount(pv_xmlDocument)
            Case gc_GL_ACCOUNTHISTORY
                v_lngErrorCode = HistoryAccount(pv_xmlDocument)
            Case gc_GL_ADJUSTMITRAN
                v_lngErrorCode = AdjustMITRAN(pv_xmlDocument)
            Case gc_GL_REVERSE9900
                v_lngErrorCode = Reverse9900(pv_xmlDocument)
        End Select
        'Trả về mã lỗi
        'ContextUtil.SetComplete()
        Return v_lngErrorCode
    End Function
#End Region

#Region " Private functions"
    Private Function AdjustMITRAN(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "GL.Trans.AdjustMITRAN", v_strErrorMessage As String
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strSQL, v_strFLDCD, v_strFLDTYPE, v_strVALUE As String, v_dblVALUE As Double, i As Integer
        Dim v_strACCTNO, v_strREFTXDATE, v_strREFTXNUM, v_strREFSUBTXNO, v_strREFDORC, v_strREFCUSTID, _
            v_strREFCUSTNAME, v_strREFTASKCD, v_strREFDEPTCD, v_strREFMICD, v_strDESCRIPTION As String

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
            'Đọc nội dung giao dịch tính lãi cộng dồn: 1160
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
                        Case "90" 'TXDATE
                            v_strREFTXDATE = v_strVALUE
                        Case "91" 'TXNUM
                            v_strREFTXNUM = v_strVALUE
                        Case "92" 'SUBTXNO
                            v_strREFSUBTXNO = v_strVALUE
                        Case "93" 'DORC
                            v_strREFDORC = v_strVALUE
                        Case "03" 'ACCTNO
                            v_strACCTNO = v_strVALUE
                        Case "05" 'CUSTID
                            v_strREFCUSTID = v_strVALUE
                        Case "11" 'CUSTNAME
                            v_strREFCUSTNAME = v_strVALUE
                        Case "12" 'TASKCD
                            v_strREFTASKCD = v_strVALUE
                        Case "13" 'DEPTCD
                            v_strREFDEPTCD = v_strVALUE
                        Case "14" 'MICD
                            v_strREFMICD = v_strVALUE
                        Case "30" 'DESCRIPTION
                            v_strDESCRIPTION = v_strVALUE
                    End Select
                End With
            Next

            v_strSQL = "UPDATE MITRAN SET CUSTID='" & v_strREFCUSTID & "',CUSTNAME='" & v_strREFCUSTNAME & "',TASKCD='" & v_strREFTASKCD & "',DEPTCD='" & v_strREFDEPTCD & "',MICD='" & v_strREFMICD & "',DESCRIPTION='" & v_strDESCRIPTION & "' " & ControlChars.CrLf _
                & " WHERE TXDATE=TO_DATE('" & v_strREFTXDATE & "','" & gc_FORMAT_DATE & "') AND RTRIM(TXNUM)='" & v_strREFTXNUM & "' AND RTRIM(SUBTXNO)='" & v_strREFSUBTXNO & "' AND RTRIM(DORC)='" & v_strREFDORC & "' AND RTRIM(ACCTNO)='" & v_strACCTNO & "'"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            v_strSQL = "UPDATE MITRANA SET CUSTID='" & v_strREFCUSTID & "',CUSTNAME='" & v_strREFCUSTNAME & "',TASKCD='" & v_strREFTASKCD & "',DEPTCD='" & v_strREFDEPTCD & "',MICD='" & v_strREFMICD & "',DESCRIPTION='" & v_strDESCRIPTION & "' " & ControlChars.CrLf _
                & " WHERE TXDATE=TO_DATE('" & v_strREFTXDATE & "','" & gc_FORMAT_DATE & "') AND RTRIM(TXNUM)='" & v_strREFTXNUM & "' AND RTRIM(SUBTXNO)='" & v_strREFSUBTXNO & "' AND RTRIM(DORC)='" & v_strREFDORC & "' AND RTRIM(ACCTNO)='" & v_strACCTNO & "'"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function OpenAccount(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "GL.Trans.OpenAccount", v_strErrorMessage As String

        Try
            'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function InquiryAccount(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "GL.Trans.InquiryAccount", v_strErrorMessage As String

        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE As Double, i As Integer
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
                        Case "03" 'ACCTNO
                            ATTR_ACCTNO = v_strVALUE
                        Case "04" 'NEXT TRANSACTION                                            
                    End Select
                End With
            Next
            'Gọi hàm để lấy dữ liệu về
            'TRUONGLD COMMENT 16/04/2010
            'ATTR_CMDMISCINQUIRY = "SELECT MST.GLBANK, MST.ACCTNO, MST.CCYCD, MST.SUBCD, MST.ACNAME,  " & ControlChars.CrLf _
            '        & "MST.BALANCE, MST.AVGBAL, MST.YEARBAL, MST.INTRATE, MST.DDR, MST.DCR,  " & ControlChars.CrLf _
            '        & "MST.MDR, MST.MCR, MST.YDR, MST.YCR, MST.DTXCOUNT, MST.YTXCOUNT, " & ControlChars.CrLf _
            '        & "CCY.SHORTCD, MST.LSTDATE " & ControlChars.CrLf _
            '        & "FROM GLMAST MST, SBCURRENCY CCY " & ControlChars.CrLf _
            '        & "WHERE CCY.CCYCD=MST.CCYCD AND TRIM(MST.ACCTNO) = '" & ATTR_ACCTNO & "'"

            'ATTR_CMDACCOUNTINQUIRY = "SELECT MST.GLBANK, MST.ACCTNO, MST.CCYCD, MST.SUBCD, MST.ACNAME,  " & ControlChars.CrLf _
            '       & "MST.BALANCE, MST.AVGBAL, MST.YEARBAL, MST.INTRATE, MST.DDR, MST.DCR,  " & ControlChars.CrLf _
            '       & "MST.MDR, MST.MCR, MST.YDR, MST.YCR, MST.DTXCOUNT, MST.YTXCOUNT, " & ControlChars.CrLf _
            '       & "CCY.SHORTCD, MST.LSTDATE, case when MST.BALANCE >=0 then MST.BALANCE else 0 end CREDIT_BAL, " & ControlChars.CrLf _
            '       & "case when MST.BALANCE < 0 then abs(MST.BALANCE) else 0 end DEBIT_BAL " & vbCrLf _
            '       & "FROM GLMAST MST, SBCURRENCY CCY " & ControlChars.CrLf _
            '       & "WHERE CCY.CCYCD=MST.CCYCD AND MST.ACCTNO = :ACCTNO"

            'v_lngErrCode = Me.txCoreMiscInquiry(pv_xmlDocument)
            'END TRUONGLD
            v_lngErrCode = Me.StoreInquiryAccount(pv_xmlDocument, "GLMAST")
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function


    Private Function HistoryAccount(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "GL.Trans.HistoryAccount", v_strErrorMessage As String

        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE As Double, i As Integer
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
                        Case "03" 'ACCTNO
                            ATTR_ACCTNO = v_strVALUE
                        Case "05" 'FRDATE
                            Me.ATTR_FRDATE = v_strVALUE
                        Case "06" 'TODATE
                            Me.ATTR_TODATE = v_strVALUE
                    End Select
                End With
            Next
            'Gọi hàm để lấy dữ liệu về
            'ATTR_CMDMISCINQUIRY = "SELECT * FROM " & ControlChars.CrLf _
            '    & "(SELECT LF.TXDATE, LF.TXNUM, LF.TLTXCD || '.' || TRF.DORC TLTXCD, LF.TXDESC, TRF.AMT,LF.TXDESC TLTXDESC,LF.TXDESC TLTXEN_DESC " & ControlChars.CrLf _
            '    & "FROM GLTRAN TRF, TLLOG LF " & ControlChars.CrLf _
            '    & "WHERE TRF.TXNUM = LF.TXNUM AND TRF.TXDATE = LF.TXDATE AND LF.DELTD <> 'Y' " & ControlChars.CrLf _
            '    & "AND TRF.ACCTNO='" & ATTR_ACCTNO & "' " & ControlChars.CrLf _
            '    & "AND TRF.TXDATE>=TO_DATE('" & ATTR_FRDATE & "', '" & gc_FORMAT_DATE & "') " & ControlChars.CrLf _
            '    & "AND TRF.TXDATE<=TO_DATE('" & ATTR_TODATE & "', '" & gc_FORMAT_DATE & "') " & ControlChars.CrLf _
            '    & "UNION ALL " & ControlChars.CrLf _
            '    & "SELECT LF.TXDATE, LF.TXNUM, LF.TLTXCD || '.' || TRF.DORC TLTXCD, LF.TXDESC, TRF.AMT,LF.TXDESC TLTXDESC,LF.TXDESC TLTXEN_DESC  " & ControlChars.CrLf _
            '    & "FROM GLTRANA TRF, TLLOGALL LF " & ControlChars.CrLf _
            '    & "WHERE TRF.TXNUM = LF.TXNUM AND TRF.TXDATE = LF.TXDATE AND LF.DELTD <> 'Y' " & ControlChars.CrLf _
            '    & "AND TRF.ACCTNO='" & ATTR_ACCTNO & "' " & ControlChars.CrLf _
            '    & "AND TRF.TXDATE>=TO_DATE('" & ATTR_FRDATE & "', '" & gc_FORMAT_DATE & "') " & ControlChars.CrLf _
            '    & "AND TRF.TXDATE<=TO_DATE('" & ATTR_TODATE & "', '" & gc_FORMAT_DATE & "')) LOGDATA " & ControlChars.CrLf _
            '    & "ORDER BY TXDATE, TXNUM"

            ''TRUONGLD COMMENT 16/04/2010
            'ATTR_CMDMISCINQUIRY = "SELECT DISTINCT * FROM " & ControlChars.CrLf _
            '                & "(SELECT LF.TXDATE,LF.BUSDATE, LF.TXNUM, LF.TLTXCD, LF.TXDESC, TRF.AMT,TX.TXDESC TLTXDESC,TX.EN_TXDESC TLTXEN_DESC,LF.DELTD " & ControlChars.CrLf _
            '                & "FROM (SELECT TO_CHAR(TXDATE,'" & gc_FORMAT_DATE & "') || TXNUM VOUCHERCD, AMT " & ControlChars.CrLf _
            '                & "FROM GLTRAN WHERE TRIM(ACCTNO)='" & ATTR_ACCTNO & "' " & ControlChars.CrLf _
            '                & "AND TXDATE>=TO_DATE('" & ATTR_FRDATE & "', '" & gc_FORMAT_DATE & "') " & ControlChars.CrLf _
            '                & "AND TXDATE<=TO_DATE('" & ATTR_TODATE & "', '" & gc_FORMAT_DATE & "')) TRF, TLLOG LF, TLTX TX " & ControlChars.CrLf _
            '                & "WHERE TRF.VOUCHERCD=TO_CHAR(TXDATE,'" & gc_FORMAT_DATE & "') || TXNUM AND DELTD<>'Y' AND LF.TLTXCD=TX.TLTXCD " & ControlChars.CrLf _
            '                & "UNION ALL " & ControlChars.CrLf _
            '                & "SELECT LF.TXDATE,LF.BUSDATE, LF.TXNUM, LF.TLTXCD, LF.TXDESC, TRF.AMT,TX.TXDESC TLTXDESC,TX.EN_TXDESC TLTXEN_DESC,LF.DELTD " & ControlChars.CrLf _
            '                & "FROM (SELECT TO_CHAR(TXDATE,'" & gc_FORMAT_DATE & "') || TXNUM VOUCHERCD, AMT " & ControlChars.CrLf _
            '                & "FROM GLTRANA WHERE TRIM(ACCTNO)='" & ATTR_ACCTNO & "' " & ControlChars.CrLf _
            '                & "AND TXDATE>=TO_DATE('" & ATTR_FRDATE & "', '" & gc_FORMAT_DATE & "') " & ControlChars.CrLf _
            '                & "AND TXDATE<=TO_DATE('" & ATTR_TODATE & "', '" & gc_FORMAT_DATE & "')) TRF, TLLOGALL LF, TLTX TX " & ControlChars.CrLf _
            '                & "WHERE TRF.VOUCHERCD=TO_CHAR(TXDATE,'" & gc_FORMAT_DATE & "') || TXNUM AND DELTD<>'Y' AND LF.TLTXCD=TX.TLTXCD) LOGDATA " & ControlChars.CrLf _
            '                & "ORDER BY TXDATE, TXNUM"

            'Dim v_strPAGENO As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributePAGENO).Value
            'If IsNumeric(v_strPAGENO) Then
            '    Me.ATTR_PAGENUMBER = CInt(v_strPAGENO)
            'Else
            '    Me.ATTR_PAGENUMBER = 1
            'End If
            'Dim v_intFrom, v_intTo As Integer
            'v_intFrom = (Me.ATTR_PAGENUMBER - 1) * ROWS_PER_PAGE + 1
            'v_intTo = Me.ATTR_PAGENUMBER * ROWS_PER_PAGE
            'ATTR_CMDHISTORYINQUIRY = "SELECT * FROM (SELECT LOGDATA.*, ROWNUM RN FROM " & ControlChars.CrLf _
            '                & "(SELECT DISTINCT LF.TXDATE,LF.BUSDATE, LF.TXNUM, LF.TLTXCD, LF.TXDESC, TRF.AMT,TX.TXDESC TLTXDESC,TX.EN_TXDESC TLTXEN_DESC,LF.DELTD " & ControlChars.CrLf _
            '                & "FROM (SELECT TO_CHAR(TXDATE,'" & gc_FORMAT_DATE & "') || TXNUM VOUCHERCD, AMT " & ControlChars.CrLf _
            '                & "FROM GLTRAN WHERE ACCTNO=:ACCTNO " & ControlChars.CrLf _
            '                & "AND TXDATE>=TO_DATE(:FRDATE, '" & gc_FORMAT_DATE & "') " & ControlChars.CrLf _
            '                & "AND TXDATE<=TO_DATE(:TODATE, '" & gc_FORMAT_DATE & "')) TRF, TLLOG LF, TLTX TX " & ControlChars.CrLf _
            '                & "WHERE TRF.VOUCHERCD=TO_CHAR(TXDATE,'" & gc_FORMAT_DATE & "') || TXNUM AND DELTD<>'Y' AND LF.TLTXCD=TX.TLTXCD " & ControlChars.CrLf _
            '                & "UNION ALL " & ControlChars.CrLf _
            '                & "SELECT DISTINCT LF.TXDATE,LF.BUSDATE, LF.TXNUM, LF.TLTXCD, LF.TXDESC, TRF.AMT,TX.TXDESC TLTXDESC,TX.EN_TXDESC TLTXEN_DESC,LF.DELTD " & ControlChars.CrLf _
            '                & "FROM (SELECT TO_CHAR(TXDATE,'" & gc_FORMAT_DATE & "') || TXNUM VOUCHERCD, AMT " & ControlChars.CrLf _
            '                & "FROM GLTRANA WHERE ACCTNO=:ACCTNO " & ControlChars.CrLf _
            '                & "AND TXDATE>=TO_DATE(:FRDATE, '" & gc_FORMAT_DATE & "') " & ControlChars.CrLf _
            '                & "AND TXDATE<=TO_DATE(:TODATE, '" & gc_FORMAT_DATE & "')) TRF, TLLOGALL LF, TLTX TX " & ControlChars.CrLf _
            '                & "WHERE TRF.VOUCHERCD=TO_CHAR(TXDATE,'" & gc_FORMAT_DATE & "') || TXNUM AND DELTD<>'Y' AND LF.TLTXCD=TX.TLTXCD) LOGDATA) T1 " & ControlChars.CrLf _
            '                & "WHERE RN BETWEEN " & v_intFrom & " AND " & v_intTo & " " & ControlChars.CrLf _
            '                & "ORDER BY TXDATE, TXNUM"

            'v_lngErrCode = Me.txCoreMiscInquiry(pv_xmlDocument)
            ''END TRUONGLD

            v_lngErrCode = Me.StoreHistoryAccount(pv_xmlDocument, OBJNAME_GL_GLMAST)

            'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function Reverse9900(ByRef pv_xmlDocument As Xml.XmlDocument) As Long

        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "GL.Trans.Reverse9900", v_strErrorMessage As String

        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE As Double, i As Integer
            Dim v_strTXDATE, v_strTXNUM, v_strBUSDATE, v_strSQL As String
            Dim v_ds As DataSet
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
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
                        Case "90" 'TXDATE
                            v_strTXDATE = v_strVALUE
                        Case "91" 'TXNUM
                            v_strTXNUM = v_strVALUE
                    End Select
                End With
            Next
            'Gọi hàm để lấy dữ liệu về
            v_strSQL = "SELECT * FROM TLLOGALL WHERE TXDATE=TO_DATE('" & v_strTXDATE & "','DD/MM/YYYY') AND TXNUM='" & v_strTXNUM & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                'lay ra txdate, thuc hien reverse
                v_strBUSDATE = gf_CorrectDateField(v_ds.Tables(0).Rows(0)("BUSDATE")).Day & "/" & gf_CorrectDateField(v_ds.Tables(0).Rows(0)("BUSDATE")).Month & "/" & gf_CorrectDateField(v_ds.Tables(0).Rows(0)("BUSDATE")).Year
                v_strSQL = "SELECT * FROM GLTRANA WHERE TXDATE=TO_DATE('" & v_strTXDATE & "','DD/MM/YYYY') AND TXNUM='" & v_strTXNUM & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    For i = 0 To v_ds.Tables(0).Rows.Count - 1
                        Dim v_strDORC, v_strACCTNO As String, v_dblAMT As Double
                        v_strDORC = CStr(v_ds.Tables(0).Rows(i)("DORC"))
                        v_strACCTNO = CStr(v_ds.Tables(0).Rows(i)("ACCTNO"))
                        v_dblAMT = CStr(v_ds.Tables(0).Rows(i)("AMT"))
                        'Cap nhat lai so du trong glmast
                        If v_strDORC = "D" Then
                            v_strSQL = "UPDATE GLMAST SET BALANCE=NVL(BALANCE,0)+(" & v_dblAMT & "),DDR=NVL(DDR,0)-(" & v_dblAMT & "),MDR=NVL(MDR,0)-(" & v_dblAMT _
                                & "),YDR=NVL(YDR,0)-(" & v_dblAMT & ") WHERE ACCTNO='" & v_strACCTNO & "'"
                        ElseIf v_strDORC = "C" Then
                            v_strSQL = "UPDATE GLMAST SET BALANCE=NVL(BALANCE,0)-(" & v_dblAMT & "),DCR=NVL(DCR,0)-(" & v_dblAMT & "),MCR=NVL(MCR,0)-(" & v_dblAMT _
                                & "),YCR=NVL(YCR,0)-(" & v_dblAMT & ") WHERE ACCTNO='" & v_strACCTNO & "'"
                        End If
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                        'Cap nhat lai so du trong GLHIST
                        If v_strBUSDATE <> v_strTXDATE Then
                            If v_strDORC = "D" Then
                                v_strSQL = "UPDATE GLHIST SET BALANCE=NVL(BALANCE,0)+(" & v_dblAMT & "),DDR=NVL(DDR,0)-(" & v_dblAMT & "),MDR=NVL(MDR,0)-(" & v_dblAMT _
                                    & "),YDR=NVL(YDR,0)-(" & v_dblAMT & ") WHERE ACCTNO='" & v_strACCTNO & "' AND TXDATE >= TO_DATE('" & v_strBUSDATE & "','" & gc_FORMAT_DATE & "')"
                            ElseIf v_strDORC = "C" Then
                                v_strSQL = "UPDATE GLHIST SET BALANCE=NVL(BALANCE,0)-(" & v_dblAMT & "),DCR=NVL(DCR,0)-(" & v_dblAMT & "),MCR=NVL(MCR,0)-(" & v_dblAMT _
                                    & "),YCR=NVL(YCR,0)-(" & v_dblAMT & ") WHERE ACCTNO='" & v_strACCTNO & "' AND TXDATE >= TO_DATE('" & v_strBUSDATE & "','" & gc_FORMAT_DATE & "')"
                            End If
                            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                        End If
                    Next
                    'Xoa GLTRANA
                    v_strSQL = "UPDATE GLTRANA SET DELTD='Y' WHERE TXNUM='" & v_strTXNUM & "' AND " _
                                                & " TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    'Xoa TLLOGALL
                    v_strSQL = "UPDATE TLLOGALL SET DELTD='Y' WHERE TXNUM='" & v_strTXNUM & "' AND " _
                                                & " TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                End If
            Else
                'Bao loi
            End If
            'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

#End Region

#Region " Overwrite functions"
    'Phân hệ GL phải xử lý phần Check và Update đặc biệt so với các nghiệp vụ thông thường khác
    'Các hàm ở đây sẽ Overwrite các hàm được viết trong txMaster

    Overrides Function txUpdate(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "GL.Trans.txUpdate", v_strErrorMessage As String = String.Empty

        Try
            Dim v_strSQL As String, v_ds As DataSet, v_dsCheckBalanceType As DataSet
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)

            'Lấy danh sách tài khoản tiền mặt
            Dim v_strListOfCashAccount As String
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "CASHACCT", v_strListOfCashAccount)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Return v_lngErrCode
            End If

            Dim v_strListGLAccount As String = String.Empty, v_blnOnBalanceSheet As Boolean = True
            Dim v_nodeList As Xml.XmlNodeList, v_strOldSUBTXNO As String, v_strOldCCYCD As String, v_dblDrAmt As Double, v_dblCrAmt As Double
            Dim v_strSUBTXNO, v_strDORC, v_strCCYCD, v_strACCTNO, v_strCHACCTNO, v_strGLGRP As String, v_dblAMT As Double, i, v_intCount As Integer
            Dim v_strCUSTID, v_strCUSTNAME, v_strTASKCD, v_strDEPTCD, v_strMICD, v_strCASHID As String

            Dim v_strBKDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBUSDATE).Value.ToString
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value.ToString
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value.ToString
            Dim v_strTLTXCD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value.ToString
            Dim v_strBRID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value.ToString
            Dim v_strTLID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTLID).Value.ToString
            Dim v_strCHID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHID).Value.ToString
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value.ToString
            Dim v_strGLGP As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeGLGP).Value.ToString
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False)

            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/postmap/entry")
            If v_nodeList.Count > 0 Then
                For i = 0 To v_nodeList.Count - 1 Step 1
                    'Lấy tham số hạch toán
                    With v_nodeList.Item(i)
                        v_strSUBTXNO = CStr(CType(.Attributes.GetNamedItem("subtxno"), Xml.XmlAttribute).Value)
                        v_strDORC = CStr(CType(.Attributes.GetNamedItem("dorc"), Xml.XmlAttribute).Value)
                        v_strCCYCD = CStr(CType(.Attributes.GetNamedItem("ccycd"), Xml.XmlAttribute).Value)
                        v_strACCTNO = CStr(CType(.Attributes.GetNamedItem("acctno"), Xml.XmlAttribute).Value)
                        If v_strGLGP = "Y" Then
                            v_strGLGRP = CStr(CType(.Attributes.GetNamedItem("glgrp"), Xml.XmlAttribute).Value)
                        End If
                        If InStr(v_strListOfCashAccount, v_strACCTNO.Substring(POS_GLBANK - 1, LEN_GLBANK)) > 0 Then
                            'Có phải là tài khoản tiền mặt không
                            v_strCHACCTNO = v_strBRID & v_strCCYCD & IIf(v_strCHID.Trim.Length > 0, v_strCHID.Trim, v_strTLID.Trim)
                            v_strCASHID = IIf(v_strCHID.Trim.Length > 0, v_strCHID.Trim, v_strTLID.Trim)
                        Else
                            v_strCHACCTNO = String.Empty
                            v_strCASHID = String.Empty
                        End If
                        v_dblAMT = CDbl(.InnerXml)
                    End With
                    If v_blnReversal Then 'Nếu là xoá giao dịch
                        'Xoá GLTRAN/MITRAN/CHTRAN
                        If v_strGLGP = "Y" Then
                            v_strSQL = "UPDATE GLTRANDTL SET DELTD='Y' WHERE TXNUM='" & v_strTXNUM & "' AND " _
                                & " TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')"
                            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                            v_strSQL = "UPDATE MITRANDTL SET DELTD='Y' WHERE TXNUM='" & v_strTXNUM & "' AND " _
                                & " TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')"
                            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                        Else
                            v_strSQL = "UPDATE GLTRAN SET DELTD='Y' WHERE TXNUM='" & v_strTXNUM & "' AND " _
                            & " TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')"
                            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                            v_strSQL = "UPDATE MITRAN SET DELTD='Y' WHERE TXNUM='" & v_strTXNUM & "' AND " _
                                & " TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')"
                            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                        End If


                        v_strSQL = "UPDATE CHTRAN SET DELTD='Y' WHERE TXNUM='" & v_strTXNUM & "' AND " _
                            & " TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                        'Cập nhật số dư
                        If v_strDORC = "D" Then
                            v_strSQL = "UPDATE GLMAST SET BALANCE=NVL(BALANCE,0)+(" & v_dblAMT & "),DDR=NVL(DDR,0)-(" & v_dblAMT & "),MDR=NVL(MDR,0)-(" & v_dblAMT _
                                & "),YDR=NVL(YDR,0)-(" & v_dblAMT & ") WHERE ACCTNO='" & v_strACCTNO & "'"
                        ElseIf v_strDORC = "C" Then
                            v_strSQL = "UPDATE GLMAST SET BALANCE=NVL(BALANCE,0)-(" & v_dblAMT & "),DCR=NVL(DCR,0)-(" & v_dblAMT & "),MCR=NVL(MCR,0)-(" & v_dblAMT _
                                & "),YCR=NVL(YCR,0)-(" & v_dblAMT & ") WHERE ACCTNO='" & v_strACCTNO & "'"
                        End If
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                        'Cập nhật GLHIST
                        If v_strBKDATE <> v_strTXDATE Then
                            If v_strDORC = "D" Then
                                v_strSQL = "UPDATE GLHIST SET BALANCE=NVL(BALANCE,0)+(" & v_dblAMT & "),DDR=NVL(DDR,0)-(" & v_dblAMT & "),MDR=NVL(MDR,0)-(" & v_dblAMT _
                                    & "),YDR=NVL(YDR,0)-(" & v_dblAMT & ") WHERE ACCTNO='" & v_strACCTNO & "' AND TXDATE >= TO_DATE('" & v_strBKDATE & "','" & gc_FORMAT_DATE & "')"
                            ElseIf v_strDORC = "C" Then
                                v_strSQL = "UPDATE GLHIST SET BALANCE=NVL(BALANCE,0)-(" & v_dblAMT & "),DCR=NVL(DCR,0)-(" & v_dblAMT & "),MCR=NVL(MCR,0)-(" & v_dblAMT _
                                    & "),YCR=NVL(YCR,0)-(" & v_dblAMT & ") WHERE ACCTNO='" & v_strACCTNO & "' AND TXDATE >= TO_DATE('" & v_strBKDATE & "','" & gc_FORMAT_DATE & "')"
                            End If
                            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                        End If
                        'Cập nhật số dư Cash
                        If v_strCHACCTNO.Length > 0 Then
                            'Cập nhật số dư: Ghi Nợ -> tăng, Ghi Có -> giảm
                            v_strSQL = "UPDATE CHMAST SET BALANCE=NVL(BALANCE,0)-(" & IIf(v_strDORC = "D", v_dblAMT, -v_dblAMT) & ") WHERE ACCTNO='" & v_strCHACCTNO & "'"
                            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                            'v_ds.Dispose()
                        End If
                    Else 'Nếu là giao dịch bình thường
                        'Tạo GLTRAN
                        'v_strSQL = "INSERT INTO GLTRAN (AUTOID,ACCTNO, TXDATE, TXNUM, BKDATE, CCYCD, DORC, SUBTXNO, AMT, DELTD) " _
                        '    & "VALUES (SEQ_GLTRAN.NEXTVAL,'" & v_strACCTNO & "',TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'" _
                        '    & v_strTXNUM & "',TO_DATE('" & v_strBKDATE & "', '" & gc_FORMAT_DATE & "'),'" _
                        '    & v_strCCYCD & "','" & v_strDORC & "','" & v_strSUBTXNO & "'," & v_dblAMT & ",'N')"
                        'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                        'Tạo GLTRAN
                        If v_strGLGP = "Y" Then
                            v_strSQL = "INSERT INTO GLTRANDTL (AUTOID,ACCTNO, TXDATE, TXNUM, BKDATE, CCYCD, DORC, SUBTXNO, AMT,GLGRP, DELTD) " _
                                     & "VALUES (SEQ_GLTRAN.NEXTVAL,'" & v_strACCTNO & "',TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'" _
                                     & v_strTXNUM & "',TO_DATE('" & v_strBKDATE & "', '" & gc_FORMAT_DATE & "'),'" _
                                     & v_strCCYCD & "','" & v_strDORC & "','" & v_strSUBTXNO & "'," & v_dblAMT & ",'" & v_strGLGRP & "' ,'N')"
                        Else
                            v_strSQL = "INSERT INTO GLTRAN (AUTOID,ACCTNO, TXDATE, TXNUM, BKDATE, CCYCD, DORC, SUBTXNO, AMT, DELTD,tltxcd) " _
                                    & "VALUES (SEQ_GLTRAN.NEXTVAL,'" & v_strACCTNO & "',TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'" _
                                    & v_strTXNUM & "',TO_DATE('" & v_strBKDATE & "', '" & gc_FORMAT_DATE & "'),'" _
                                    & v_strCCYCD & "','" & v_strDORC & "','" & v_strSUBTXNO & "'," & v_dblAMT & ",'N','" & v_strTLTXCD & "')"
                        End If
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                        'Cập nhật số dư
                        If v_strDORC = "D" Then
                            v_strSQL = "UPDATE GLMAST SET LSTDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'), BALANCE=NVL(BALANCE,0)-(" & v_dblAMT & "),DDR=NVL(DDR,0)+(" & v_dblAMT & "),MDR=NVL(MDR,0)+(" & v_dblAMT _
                                    & "),YDR=NVL(YDR,0)+(" & v_dblAMT & ") WHERE ACCTNO='" & v_strACCTNO & "'"
                        ElseIf v_strDORC = "C" Then
                            v_strSQL = "UPDATE GLMAST SET LSTDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'), BALANCE=NVL(BALANCE,0)+(" & v_dblAMT & "),DCR=NVL(DCR,0)+(" & v_dblAMT & "),MCR=NVL(MCR,0)+(" & v_dblAMT _
                                    & "),YCR=NVL(YCR,0)+(" & v_dblAMT & ") WHERE ACCTNO='" & v_strACCTNO & "'"
                        End If
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                        'Cập nhật GLHIST
                        If v_strBKDATE <> v_strTXDATE Then
                            'Kiểm tra nếu trong giao dịch back date mà trong ngày back date chưa có tài khoản GL thì tự đông đẩy vào
                            Dim v_date As String
                            Dim v_i As Integer = 0
                            Do
                                v_date = Format(DateAdd(DateInterval.Day, v_i, DDMMYYYY_SystemDate(v_strBKDATE)), gc_FORMAT_DATE)
                                If DDMMYYYY_SystemDate(v_date) >= DDMMYYYY_SystemDate(v_strTXDATE) Then
                                    Exit Do
                                End If
                                'Kiểm tra xem nếu không là ngày nghỉ thì kiểm tra xem có cần đưa tài khoản vào trong GLHIST không?
                                v_strSQL = "SELECT COUNT(*) FROM GLHIST WHERE  TXDATE=TO_DATE('" & v_date & "','" & gc_FORMAT_DATE & "')"
                                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                                    v_strSQL = "SELECT * FROM GLHIST WHERE ACCTNO='" & v_strACCTNO & "' AND TXDATE=TO_DATE('" & v_date & "','" & gc_FORMAT_DATE & "')"
                                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                                    If v_ds.Tables(0).Rows.Count = 0 Then
                                        v_strSQL = "INSERT INTO GLHIST (AUTOID,PERIOD,TXDATE,ACCTNO,BALANCE,AVGBAL,YEARBAL,DDR,DCR,MDR,MCR,YDR,YCR) " & ControlChars.CrLf _
                                                        & "SELECT SEQ_GLHIST.NEXTVAL,'EOD',TO_DATE('" & v_date & "','" & gc_FORMAT_DATE & "'),ACCTNO,0,0,0,0,0,0,0,0,0 FROM GLMAST WHERE ACCTNO='" & v_strACCTNO & "'"
                                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                                    Else
                                        Exit Do
                                    End If
                                End If
                                v_i = v_i + 1
                            Loop

                            'Cập nhập GLHIST cho các giao dịch back date
                            If v_strDORC = "D" Then
                                v_strSQL = "UPDATE GLHIST SET BALANCE=NVL(BALANCE,0)-(" & v_dblAMT & "),DDR=NVL(DDR,0)+(" & v_dblAMT & "),MDR=NVL(MDR,0)+(" & v_dblAMT _
                                        & "),YDR=NVL(YDR,0)+(" & v_dblAMT & ") WHERE ACCTNO='" & v_strACCTNO & "' AND TXDATE >= TO_DATE('" & v_strBKDATE & "','" & gc_FORMAT_DATE & "')"
                            ElseIf v_strDORC = "C" Then
                                v_strSQL = "UPDATE GLHIST SET BALANCE=NVL(BALANCE,0)+(" & v_dblAMT & "),DCR=NVL(DCR,0)+(" & v_dblAMT & "),MCR=NVL(MCR,0)+(" & v_dblAMT _
                                        & "),YCR=NVL(YCR,0)+(" & v_dblAMT & ") WHERE ACCTNO='" & v_strACCTNO & "' AND TXDATE >= TO_DATE('" & v_strBKDATE & "','" & gc_FORMAT_DATE & "')"
                            End If
                            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                        End If
                        'Cập nhật số dư Cash
                        If v_strCHACCTNO.Length > 0 Then
                            'Ghi nhận vào bảng CHTRAN
                            v_strSQL = " INSERT INTO CHTRAN " _
                                            & " (AUTOID,TXDATE,TXNUM,SUBTXNO,DORC,ACCTNO,AMT,REF,DELTD) " _
                                            & " VALUES " _
                                            & " (SEQ_CHTRAN.NEXTVAL,TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'" & v_strTXNUM & "'," _
                                            & v_strSUBTXNO & ",'" & IIf(v_strDORC = "D", "C", "D") & "','" & v_strCHACCTNO & "'," _
                                            & v_dblAMT & ",'" & v_strACCTNO & "','N') "
                            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                            'Kiểm tra nếu chưa có bản ghi trong CHMAST thì tạo mới
                            v_strSQL = "SELECT * FROM CHMAST WHERE ACCTNO='" & v_strCHACCTNO & "'"
                            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                            If v_ds.Tables(0).Rows.Count > 0 Then
                                'Cập nhật số dư: Ghi Nợ -> tăng, Ghi Có -> giảm
                                v_strSQL = "UPDATE CHMAST SET BALANCE=NVL(BALANCE,0)+(" & IIf(v_strDORC = "D", v_dblAMT, -v_dblAMT) & ") WHERE ACCTNO='" & v_strCHACCTNO & "'"
                            Else
                                'Tạo bản ghi mới
                                v_strSQL = "INSERT INTO CHMAST (ACCTNO, BRID, CCYCD, TLID, BALANCE) VALUES ('" & v_strCHACCTNO & "','" & v_strBRID & "','" & v_strCCYCD & "','" & v_strCASHID & "'," & IIf(v_strDORC = "D", v_dblAMT, -v_dblAMT) & ")"
                            End If
                            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                            'v_ds.Dispose()
                        End If
                    End If
                    'Kiểm tra nếu tài khoản có tính chất dư nợ mà dư có hoặc tính chất dư có mà dư nợ thì báo lỗi
                    v_strSQL = "SELECT * FROM GLMAST WHERE ACCTNO='" & v_strACCTNO & "'" & ControlChars.CrLf _
                            & "AND (CASE WHEN BALTYPE='D' THEN -BALANCE WHEN BALTYPE='C' THEN BALANCE ELSE 0 END) < 0"
                    v_dsCheckBalanceType = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_dsCheckBalanceType.Tables(0).Rows.Count > 0 Then
                        v_lngErrCode = gc_ERRCODE_GL_INVALID_BALANCETYPE
                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                         & "Error code: " & v_strSQL & vbNewLine _
                                         & "Error message: " & v_strTXDATE & "." & v_strTXNUM & "." & v_strSUBTXNO & "." & "." & v_strDORC & "." & v_strACCTNO, "EventLogEntryType.Error")
                        Return v_lngErrCode
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

    'Luật kiểm tra như sau:
    'Tài khoản kế toán phải tồn tại
    'Một cặp bút toán kế toán phải cùng một loại tiền
    'Nếu tài khoản nội bảng: Tổng nợ = Tổng có
    'Nếu tài khoản ngoại bảng: Chỉ được hạch toán 01 vế.
    Overrides Function txCheck(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "GL.Trans.txCheck", v_strErrorMessage As String = String.Empty
        Dim v_strBKDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBUSDATE).Value.ToString
        Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value.ToString
        Try
            Dim v_strSQL As String, v_ds As DataSet
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_strListGLAccount As String = String.Empty, v_blnOnBalanceSheet As Boolean = True, v_blnOldOnBalanceSheet As Boolean = False
            Dim v_nodeList As Xml.XmlNodeList, v_strOldSUBTXNO As String, v_strOldCCYCD As String, v_strOldBRANCH As String, v_dblDrAmt As Double, v_dblCrAmt As Double
            Dim v_strSUBTXNO, v_strDORC, v_strCCYCD, v_strBRANCH, v_strACCTNO As String, v_dblAMT As Double, i, v_intCount As Integer
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/postmap/entry")
            If v_nodeList.Count > 0 Then
                v_intCount = 0
                v_strOldSUBTXNO = vbNullString
                v_strOldCCYCD = vbNullString
                v_strOldBRANCH = vbNullString
                v_dblDrAmt = 0
                v_dblCrAmt = 0

                'kiem tra ngay busdate co phai ngay le khong
                If v_strBKDATE <> v_strTXDATE Then

                    v_strSQL = "SELECT * FROM SBCLDR WHERE SBDATE = TO_DATE('" & v_strBKDATE & "', '" & gc_FORMAT_DATE & "') and HOLIDAY ='Y'"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count > 0 Then
                        v_lngErrCode = ERR_GL_BKDATE_IN_HOLIDAY
                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                     & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                     & "Error message: " & v_strListGLAccount, "EventLogEntryType.Error")
                        Return v_lngErrCode
                    End If
                End If


                For i = 0 To v_nodeList.Count - 1 Step 1
                    'Lấy tham số hạch toán
                    With v_nodeList.Item(i)
                        v_strSUBTXNO = Trim(CStr(CType(.Attributes.GetNamedItem("subtxno"), Xml.XmlAttribute).Value))
                        v_strDORC = Trim(CStr(CType(.Attributes.GetNamedItem("dorc"), Xml.XmlAttribute).Value))
                        v_strCCYCD = Trim(CStr(CType(.Attributes.GetNamedItem("ccycd"), Xml.XmlAttribute).Value))
                        v_strACCTNO = Trim(CStr(CType(.Attributes.GetNamedItem("acctno"), Xml.XmlAttribute).Value))
                        v_strBRANCH = Strings.Left(v_strACCTNO, 4)
                        v_dblAMT = CDbl(.InnerXml)
                        If Mid(v_strACCTNO, POS_GLBANK, 1) = "0" Then
                            'Tài khoản ngoại bảng
                            v_blnOnBalanceSheet = False
                        Else
                            'Tài khoản nội bảng
                            v_blnOnBalanceSheet = True
                        End If
                    End With



                    'Kiểm tra số tiền hạch toán
                    If v_strOldSUBTXNO <> v_strSUBTXNO Then
                        'Kiểm tra tổng nợ bằng tổng có của tài khoản nội bảng
                        If v_dblDrAmt <> v_dblCrAmt And v_blnOldOnBalanceSheet Then
                            v_lngErrCode = gc_ERRCODE_GL_ACCTENTRY_DOESNOTBALANCE
                            LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                         & "Error code: " & v_dblDrAmt & "." & v_dblCrAmt & vbNewLine _
                                         & "Error message: " & v_strSUBTXNO & "." & v_strDORC & "." & v_strACCTNO & "." & v_dblAMT, "EventLogEntryType.Error")
                            Return v_lngErrCode
                        Else
                            v_blnOldOnBalanceSheet = v_blnOnBalanceSheet
                            v_strOldSUBTXNO = v_strSUBTXNO
                            v_strOldCCYCD = v_strCCYCD
                            v_strOldBRANCH = v_strBRANCH
                            v_dblDrAmt = 0
                            v_dblCrAmt = 0

                            If v_strDORC = "D" Then v_dblDrAmt += v_dblAMT
                            If v_strDORC = "C" Then v_dblCrAmt += v_dblAMT
                        End If
                    Else
                        'Kiểm tra trong cùng 01 bút toán không được phép có 02 loại tiền
                        If Not v_strOldCCYCD = v_strCCYCD Then
                            v_lngErrCode = gc_ERRCODE_GL_ACCTENTRY_NOTSAMECCYCD
                            LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                         & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                         & "Error message: " & v_strOldCCYCD & "." & v_strCCYCD, "EventLogEntryType.Error")
                            Return v_lngErrCode
                        End If
                        'Kiem tra trong cung but toan khong duoc lech chi nhanh
                        If Not v_strOldBRANCH = v_strBRANCH Then
                            v_lngErrCode = gc_ERRCODE_GL_ACCTENTRY_NOTSAME_BRID
                            LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                         & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                         & "Error message: " & v_strOldBRANCH & "." & v_strBRANCH, "EventLogEntryType.Error")
                            Return v_lngErrCode
                        End If

                        If v_strDORC = "D" Then v_dblDrAmt = v_dblDrAmt + v_dblAMT
                        If v_strDORC = "C" Then v_dblCrAmt = v_dblCrAmt + v_dblAMT
                        'Kiểm tra trong cùng một bút toán ngoại bảng không thể vừa ghi nợ vừa ghi có
                        If Not v_blnOnBalanceSheet And v_dblCrAmt > 0 And v_dblDrAmt > 0 Then
                            v_lngErrCode = gc_ERRCODE_GL_ACCTENTRY_OFFBALANCESHEET
                            LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                         & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                         & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                            Return v_lngErrCode
                        End If
                    End If

                    'Lấy danh sách các tài khoản cần kiểm tra
                    If InStr(v_strListGLAccount, v_strACCTNO) <= 0 Then
                        If Len(v_strListGLAccount) = 0 Then
                            v_intCount = 1
                            v_strListGLAccount = "'" & v_strACCTNO & "'"
                        Else
                            v_intCount = v_intCount + 1
                            v_strListGLAccount = v_strListGLAccount & ",'" & v_strACCTNO & "'"
                        End If
                    End If
                Next
                If Len(v_strListGLAccount) > 0 Then v_strListGLAccount = "(" & v_strListGLAccount & ")"
                'Thuật toán là: số bản ghi tìm thấy phải bằng số tài khoản trong danh sách
                v_strSQL = "SELECT COUNT(*) ACCTCNT FROM GLMAST WHERE ACCTNO IN " & v_strListGLAccount
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows(0)(0) < v_intCount Then
                    v_lngErrCode = gc_ERRCODE_GL_ACCTNO_DOESNOTEXIST
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strListGLAccount, "EventLogEntryType.Error")
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

    Overrides Function txMisc(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long

        Try
            v_lngErrCode = txCoreMisc(pv_xmlDocument)
            If v_lngErrCode <> 0 Then
                Dim v_strErrorSource, v_strErrorMessage As String

                v_strErrorSource = ATTR_MODULE & ".txMisc"
                v_strErrorMessage = String.Empty

                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                             & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                             & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                BuildXMLErrorException(pv_xmlDocument, v_strErrorSource, v_lngErrCode, v_strErrorMessage)
            End If
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
