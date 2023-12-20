Imports HostCommonLibrary
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
        ATTR_MODULE = "SE"
    End Sub

    'Hàm thực hiện chạy xử lý Batch của phân hệ nghiệp vụ
    Overrides Function ExecuteRouter(ByVal v_strBCHMDL As String, Optional ByVal v_strBCHFillter As String = "", Optional ByRef v_intMaxRow As Integer = 0) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = ATTR_MODULE & ".Batch.ExecuteRouter", v_strErrorMessage As String
        Dim v_strxmlMessage As String, v_xmlMessage As New Xml.XmlDocument
        Try
            'Chuyển đến các bước chạy xử lý của phân hệ nghiệp vụ
            Select Case v_strBCHMDL
                Case "SEICCF"
                    'Tính giá vốn & phí lưu ký cộng dồn cho tài khoản SE
                    v_lngErrCode = ICCFCalculate(v_strBCHMDL, v_strBCHFillter, v_intMaxRow)
                Case "SECALC"
                    'Tính giá vốn & phí lưu ký cộng dồn cho tài khoản SE
                    v_lngErrCode = SECostPriceCalculate()
            End Select
            'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
#Region " Private Function "
    Private Function SECostPriceCalculate() As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = ATTR_MODULE & ".Batch.ExecuteBatchName", v_strErrorMessage As String
        Dim v_strSQL As String, v_ds As DataSet
        Dim v_obj As New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)

        Dim i, j As Integer, v_strFRTABLE, v_strTOTABLE As String
        Try
            'Xây dựng các tham số hệ thống
            Dim v_strSYSVAR, v_strCURRDATE, v_strPREVDATE, v_strNEXTDATE As String
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "CURRDATE", v_strCURRDATE)
            If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "NEXTDATE", v_strNEXTDATE)
            If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode

            'Tinh lai gia von va so du luu ky cua tai khoan SE
            'Ghi nhan gia von thay doi
            v_strSQL = "INSERT INTO SECOSTPRICE (AUTOID, ACCTNO, TXDATE, COSTPRICE, PREVCOSTPRICE, DCRAMT, DCRQTTY, DELTD) " & ControlChars.CrLf _
                & "SELECT SEQ_SECOSTPRICE.NEXTVAL, ACCTNO, TO_DATE('" & v_strNEXTDATE & "', '" & gc_FORMAT_DATE & "'), " & ControlChars.CrLf _
                & "ROUND((PREVQTTY*COSTPRICE+DCRAMT-DDROUTAMT)/(DCRQTTY+PREVQTTY-DDROUTQTTY),4), ROUND(COSTPRICE,4), DCRAMT, DCRQTTY, 'N'" & ControlChars.CrLf _
                & "FROM SEMAST WHERE DCRAMT+DDROUTAMT+DCRQTTY+DDROUTQTTY>0 AND DCRQTTY+PREVQTTY-DDROUTQTTY>0 AND STATUS<>'C'"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)


            'Cap nhat thong tin gia von
            v_strSQL = "UPDATE SEMAST SET COSTPRICE=ROUND((PREVQTTY*COSTPRICE+DCRAMT-DDROUTAMT)/(DCRQTTY+PREVQTTY-DDROUTQTTY),4)," & ControlChars.CrLf _
                & " COSTDT=TO_DATE('" & v_strNEXTDATE & "', '" & gc_FORMAT_DATE & "')" & ControlChars.CrLf _
                & " WHERE DCRAMT+DDROUTAMT+DCRQTTY+DDROUTQTTY>0 AND DCRQTTY+PREVQTTY-DDROUTQTTY>0 AND STATUS<>'C'"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            ''Cap nhat thong tin chung khoan dau ngay.
            'v_strSQL = "UPDATE SEMAST SET PREVQTTY=TRADE+MORTAGE+MARGIN+SECURED+BLOCKED+WITHDRAW " & ControlChars.CrLf _
            '    & " WHERE STATUS<>'C'"
            'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            'Ghi lai thay doi so du luu ky cong don
            v_strSQL = "INSERT INTO SEDEPOBAL (AUTOID, ACCTNO, TXDATE, DAYS, QTTY, DELTD) " & ControlChars.CrLf _
                & "SELECT SEQ_SEDEPOBAL.NEXTVAL, ACCTNO, TO_DATE('" & v_strNEXTDATE & "', '" & gc_FORMAT_DATE & "'), " & ControlChars.CrLf _
                & "TO_DATE('" & v_strNEXTDATE & "', '" & gc_FORMAT_DATE & "')-TO_DATE('" & v_strCURRDATE & "', '" & gc_FORMAT_DATE & "'), TRADE+MORTAGE+MARGIN+WITHDRAW+DEPOSIT+SENDDEPOSIT+BLOCKED+SECURED, 'N'" & ControlChars.CrLf _
                & "FROM SEMAST WHERE STATUS<>'C' AND TRADE+MORTAGE+MARGIN+WITHDRAW+DEPOSIT+SENDDEPOSIT+BLOCKED+SECURED>0"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            'Cap nhat so du lu ky cong don
            v_strSQL = "UPDATE SEMAST SET TBALDEPO=TBALDEPO+(TRADE+MORTAGE+MARGIN+WITHDRAW+DEPOSIT+SENDDEPOSIT+BLOCKED+SECURED)*(TO_DATE('" & v_strNEXTDATE & "', '" & gc_FORMAT_DATE & "')-TO_DATE('" & v_strCURRDATE & "', '" & gc_FORMAT_DATE & "'))" & ControlChars.CrLf _
                & " WHERE STATUS<>'C' AND TRADE+MORTAGE+MARGIN+WITHDRAW+DEPOSIT+SENDDEPOSIT+BLOCKED+SECURED>0"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            'Cap nhat lai ngay
            v_strSQL = "UPDATE SEMAST SET DCRAMT=0,DCRQTTY=0,DDROUTQTTY=0,DDROUTAMT=0, " & ControlChars.CrLf _
                & "TBALDT=TO_DATE('" & v_strNEXTDATE & "', '" & gc_FORMAT_DATE & "'), " & ControlChars.CrLf _
                & "COSTDT=TO_DATE('" & v_strNEXTDATE & "', '" & gc_FORMAT_DATE & "'), " & ControlChars.CrLf _
                & "LASTDATE=TO_DATE('" & v_strNEXTDATE & "', '" & gc_FORMAT_DATE & "') WHERE STATUS<>'C'"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

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
