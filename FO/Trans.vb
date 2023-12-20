Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Public Class Trans
    Inherits CoreBusiness.txMaster

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_MODULE = "FO"
    End Sub

#Region " Implement functions"
    Overrides Function txImpUpdate(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        'Xác định mã giao dịch tương ứng
        Dim v_lngErrorCode As Long = ERR_SYSTEM_OK
        Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
        Dim v_strTLTXCD As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLTXCD), Xml.XmlAttribute).Value)
        Select Case v_strTLTXCD
        End Select
        'Trả v�? mã lỗi
        Return v_lngErrorCode
    End Function

    Overrides Function txImpCheck(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        'Xác định mã giao dịch tương ứng
        Dim v_lngErrorCode As Long = ERR_SYSTEM_OK
        Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
        Dim v_strTLTXCD As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLTXCD), Xml.XmlAttribute).Value)
        Select Case v_strTLTXCD
        End Select
        'Trả v�? mã lỗi
        Return v_lngErrorCode
    End Function

    Overrides Function txImpMisc(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        'Xác định mã giao dịch tương ứng
        Dim v_lngErrorCode As Long
        Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
        Dim v_strTLTXCD As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLTXCD), Xml.XmlAttribute).Value)
        Select Case v_strTLTXCD
            Case gc_FO_ORDERINQUIRY
                v_lngErrorCode = InquiryAccount(pv_xmlDocument)
            Case gc_FO_ORDERHISTORY
                v_lngErrorCode = HistoryAccount(pv_xmlDocument)
        End Select
        'Trả v�? mã lỗi
        Return v_lngErrorCode
    End Function
#End Region

#Region " Private functions"
    Private Function InquiryAccount(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = Me.ATTR_MODULE + ".Trans.InquiryAccount", v_strErrorMessage As String
        Dim v_strSQL As String = String.Empty
        Dim v_ds As DataSet
        Dim v_obj As New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE As Double, i As Integer
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
                        Case "03" 'ACCTNO
                            ATTR_ACCTNO = v_strVALUE
                        Case "04" 'NEXT TRANSACTION                                            
                    End Select
                End With
            Next
            'Kiểm tra mã hợp đồng đã tồn tại chưa
            v_strSQL = "SELECT * FROM FOMAST WHERE ACCTNO='" & ATTR_ACCTNO.Trim & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If Not v_ds.Tables(0).Rows.Count > 0 Then
                'Trả v�? mã lỗi không tồn tại mã hợp đồng
                v_lngErrCode = gc_ERRCODE_FO_FOMAST_NOTFOUND
                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                             & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                             & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                Return v_lngErrCode
            End If
            'G�?i hàm để lấy dữ liệu v�?
            ATTR_CMDMISCINQUIRY = "SELECT MST.ACTYPE, MST.ACCTNO, MST.AFACCTNO, MST.CCYCD, MST.LASTDATE,(MST.RAMT-MST.AAMT) CIPAMT, AF.TRADELINE, " & ControlChars.CrLf _
                    & "MST.BALANCE, MST.CRAMT, MST.DRAMT, MST.AVRBAL, MST.MDEBIT, MST.MCREDIT, MST.CRINTACR, MST.ODINTACR, MST.ADINTACR,MST.MINBAL, " & ControlChars.CrLf _
                    & "MST.AAMT, MST.RAMT, MST.BAMT, MST.EMKAMT, MST.ODLIMIT, MST.MMARGINBAL, MST.MARGINBAL, MST.ODAMT, " & ControlChars.CrLf _
                    & "CCY.SHORTCD, CD1.CDCONTENT DESC_STATUS " & ControlChars.CrLf _
                    & "FROM AFMAST AF, FOMAST MST, SBCURRENCY CCY, ALLCODE CD1 " & ControlChars.CrLf _
                    & "WHERE TRIM(AF.ACCTNO) = TRIM(MST.AFACCTNO) AND CCY.CCYCD=MST.CCYCD AND TRIM(MST.ACCTNO) = '" & ATTR_ACCTNO & "'  " & ControlChars.CrLf _
                    & "AND CD1.CDTYPE = 'CI' AND CD1.CDNAME='STATUS' AND MST.STATUS = CD1.CDVAL "
            v_lngErrCode = Me.txCoreMiscInquiry(pv_xmlDocument)

            'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            ex.Source = "CI.Trans.InquiryAccount"
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function HistoryAccount(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CI.Trans.HistoryAccount", v_strErrorMessage As String

        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE As Double, i As Integer
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
                        Case "03" 'ACCTNO
                            ATTR_ACCTNO = v_strVALUE
                        Case "05" 'FRDATE
                            Me.ATTR_FRDATE = v_strVALUE
                        Case "06" 'TODATE
                            Me.ATTR_TODATE = v_strVALUE
                    End Select
                End With
            Next
            'G�?i hàm để lấy dữ liệu v�?
            ''TRUONGLD COMMENT 16/04/2010
            'ATTR_CMDMISCINQUIRY = "SELECT * FROM  " & ControlChars.CrLf _
            '   & "(SELECT LF.TXDATE, LF.TXNUM, LF.BUSDATE, LF.TLTXCD, LF.TXDESC, LF.MSGAMT AMT,TX.TXDESC TLTXDESC,TX.EN_TXDESC TLTXEN_DESC,LF.DELTD  " & ControlChars.CrLf _
            '   & "FROM (SELECT DISTINCT TO_CHAR(TXDATE,'" & gc_FORMAT_DATE & "') || TXNUM VOUCHERCD  " & ControlChars.CrLf _
            '   & "FROM " & ATTR_MODULE & "TRAN WHERE TRIM(ACCTNO)='" & ATTR_ACCTNO & "'  " & ControlChars.CrLf _
            '   & "AND TXDATE>=TO_DATE('" & ATTR_FRDATE & "', '" & gc_FORMAT_DATE & "')  " & ControlChars.CrLf _
            '   & "AND TXDATE<=TO_DATE('" & ATTR_TODATE & "', '" & gc_FORMAT_DATE & "')) TRF, TLLOG LF, TLTX TX  " & ControlChars.CrLf _
            '   & "WHERE TRF.VOUCHERCD=TO_CHAR(TXDATE,'" & gc_FORMAT_DATE & "') || TXNUM AND DELTD<>'Y' AND LF.TLTXCD=TX.TLTXCD  " & ControlChars.CrLf _
            '   & "UNION ALL  " & ControlChars.CrLf _
            '   & "SELECT LF.TXDATE, LF.TXNUM, LF.BUSDATE, LF.TLTXCD, LF.TXDESC, LF.MSGAMT AMT,TX.TXDESC TLTXDESC,TX.EN_TXDESC TLTXEN_DESC,LF.DELTD  " & ControlChars.CrLf _
            '   & "FROM (SELECT DISTINCT TO_CHAR(TXDATE,'" & gc_FORMAT_DATE & "') || TXNUM VOUCHERCD  " & ControlChars.CrLf _
            '   & "FROM " & ATTR_MODULE & "TRANA WHERE TRIM(ACCTNO)='" & ATTR_ACCTNO & "'  " & ControlChars.CrLf _
            '   & "AND TXDATE>=TO_DATE('" & ATTR_FRDATE & "', '" & gc_FORMAT_DATE & "')  " & ControlChars.CrLf _
            '   & "AND TXDATE<=TO_DATE('" & ATTR_TODATE & "', '" & gc_FORMAT_DATE & "')) TRF, TLLOGALL LF, TLTX TX " & ControlChars.CrLf _
            '   & "WHERE TRF.VOUCHERCD=TO_CHAR(TXDATE,'" & gc_FORMAT_DATE & "') || TXNUM AND DELTD<>'Y' AND LF.TLTXCD=TX.TLTXCD) LOGDATA  " & ControlChars.CrLf _
            '   & "ORDER BY TXDATE, TXNUM "

            'v_lngErrCode = Me.txCoreMiscInquiry(pv_xmlDocument)
            ''END TRUONGLD

            v_lngErrCode = Me.StoreHistoryAccount(pv_xmlDocument, OBJNAME_FO_FOMAST)

            Return v_lngErrCode
        Catch ex As Exception
            ex.Source = "FO.Trans.HistoryAccount"
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
#End Region

#Region " Overwrite functions "

#End Region

End Class
