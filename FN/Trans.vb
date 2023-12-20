Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Public Class Trans
    Inherits CoreBusiness.txMaster

    Dim LogError As LogError = New LogError()

#Region " Constructor"
    Public Sub New()
        ATTR_MODULE = "FN"
    End Sub
#End Region

#Region " Implement functions"
    Overrides Function txImpUpdate(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        'Xác định mã giao dịch tương ứng
        Dim v_lngErrorCode As Long
        Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
        Dim v_strTLTXCD As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLTXCD), Xml.XmlAttribute).Value)
        Select Case v_strTLTXCD
            Case gc_FN_REGISTER_SECURITIES, gc_FN_UNREGISTER_SECURITIES

        End Select

        'Trả về mã lỗi        
        Return v_lngErrorCode
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
            Case gc_FN_OPEN_ACCOUNT
                v_lngErrorCode = OpenAccount(pv_xmlDocument)
            Case gc_FN_INQUERY_ACCOUNT
                v_lngErrorCode = BasedInquiryAccount(pv_xmlDocument)
            Case gc_FN_INQUERY_HISTORY
                v_lngErrorCode = BasedHistoryAccount(pv_xmlDocument)
        End Select

        'Trả về mã lỗi        
        Return v_lngErrorCode
    End Function
#End Region

#Region " Private functions"
    Private Function OpenAccount(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "FN.Trans.OpenAccount"
        Dim v_strErrorMessage As String = String.Empty

        Dim v_ds As DataSet = Nothing

        Dim v_strBRID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value
        Dim v_strTxDate As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value

        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strFLDCD As String = String.Empty
        Dim v_strFLDTYPE As String = String.Empty
        Dim v_strVALUE As String = String.Empty

        Dim v_strRefAccountNo As String = String.Empty
        Dim v_strAccountType As String = String.Empty
        Dim v_strAccountNo As String = String.Empty
        Dim v_strCustomerID As String = String.Empty
        Dim v_strRunning As String = String.Empty
        Dim v_strExpiredDate As String = String.Empty
        Dim v_strNotes As String = String.Empty

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
                        Case "01" 'AFMAST.master
                            v_strAccountNo = v_strVALUE
                        Case "02" 'CUSTID
                            v_strCustomerID = v_strVALUE
                        Case "03" 'ACTYPE
                            v_strAccountType = v_strVALUE
                        Case "04" 'EXPDATE
                            v_strExpiredDate = v_strVALUE
                        Case "05" 'Reference customer sub-account
                            v_strRefAccountNo = v_strVALUE
                        Case "30" ' DESCRIPTION
                            v_strNotes = v_strVALUE
                    End Select
                End With
            Next


            'Kiểm tra nếu là Ủy thác đầu tư thì chỉ cho phép sử dụng 01 AFMAST

            'Lấy số tự tăng 
            v_strSQL = "SELECT SUBSTR(INVACCT,1,10), MAX(ODR)+1 AUTOINV FROM " & ControlChars.CrLf _
                & "(SELECT ROWNUM ODR, INVACCT " & ControlChars.CrLf _
                & "FROM (SELECT ACCTNO INVACCT FROM FNMAST WHERE SUBSTR(ACCTNO,1,10)='" & v_strAccountNo & "' ORDER BY ACCTNO) DAT " & ControlChars.CrLf _
                & "WHERE TO_NUMBER(SUBSTR(INVACCT,11,6))=ROWNUM) INVTAB " & ControlChars.CrLf _
                & "GROUP BY SUBSTR(INVACCT,1,10)"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 0 Then
                v_strRunning = "1"
            Else
                v_strRunning = CStr(v_ds.Tables(0).Rows(0)("AUTOINV"))
            End If

            'Update data
            v_strSQL = "INSERT INTO FNMAST (ACTYPE,CUSTID,AFACCTNO,REFAFACCTNO,ACCTNO,CBCUSTODYCD,STATUS,OPNDATE,FRDATE,TODATE," & _
                    "MINBAL,BALANCE,PRINCIPAL,AVLBAL,CRINTACR,CRINTDT,CRINTACCRUAL,CRINTDUE,CRINTPAID,PROFACCRUAL,PROFPAID,DESCRIPTION) " & ControlChars.CrLf _
                    & "VALUES ('" & v_strAccountType & "', '" & v_strCustomerID & "', '" & v_strAccountNo & "', '" & v_strRefAccountNo & "', '" _
                    & v_strAccountNo & "' || LPAD('" & v_strRunning & "'," & gc_FN_SUB_ACCOUNT_LENGTH & ",'0') , NULL, 'P', TO_DATE('" & v_strTxDate & "','DD/MM/RRRR'),TO_DATE('" & v_strTxDate & "','DD/MM/RRRR'),TO_DATE('" & v_strExpiredDate & "','DD/MM/RRRR'),0,0,0,0,0,TO_DATE('" & v_strTxDate & "','DD/MM/RRRR'),0,0,0,0,0,'" & v_strNotes & "')"

            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            ex.Source = "CI.Trans.OpenAccount"
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

#End Region

End Class
