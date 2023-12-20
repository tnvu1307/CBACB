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
        ATTR_MODULE = "GL"
    End Sub

    'Hàm thực hiện chạy xử lý Batch của phân hệ nghiệp vụ
    Overrides Function ExecuteRouter(ByVal v_strBCHMDL As String, Optional ByVal v_strBCHFillter As String = "", Optional ByRef v_intMaxRow As Integer = 0) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = ATTR_MODULE & ".Batch.ExecuteRouter", v_strErrorMessage As String
        Dim v_strxmlMessage As String, v_xmlMessage As New Xml.XmlDocument
        Try
            'Chuyển đến các bước chạy xử lý của phân hệ nghiệp vụ
            Select Case v_strBCHMDL
                Case "GLEOD"
                    'Xử lý cuối ngày của phân hệ GL
                    v_lngErrCode = GLEOD()
                Case "GLEOM"
                    'Xử lý cuối tháng của phân hệ GL
                    v_lngErrCode = GLEOM()
                Case "GLEOY"
                    'Xử lý cuối năm của phân hệ GL
                    v_lngErrCode = GLEOY()
            End Select
            'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

#Region " Private function "

    Private Function GLEOD() As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = ATTR_MODULE & ".Batch.GLEOD", v_strErrorMessage As String
        Dim v_strSQL As String, v_ds As DataSet
        Dim v_obj As New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)
        Dim i, j As Integer, v_strFRTABLE, v_strTOTABLE As String
        Try
            'Lấy tham số hệ thống
            Dim v_strSYSVAR, v_strCURRDATE, v_strPREVDATE, v_strNEXTDATE As String
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "CURRDATE", v_strCURRDATE)
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "PREVDATE", v_strPREVDATE)
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "NEXTDATE", v_strNEXTDATE)
            If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode
            ''Generate postmap for offpostmap transaction
            'v_strSQL = "BEGIN GENOFFPOSTMAP; END;"
            'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            'Tính số dư trung bình
            v_strSQL = "UPDATE GLMAST SET YEARBAL=0,AVGBAL=(AVGBAL*" & DDMMYYYY_SystemDate(v_strCURRDATE).DayOfYear - 1 & "+BALANCE)/" & DDMMYYYY_SystemDate(v_strCURRDATE).DayOfYear
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            'Sao lưu cân đối cuối ngày
            v_strSQL = "INSERT INTO GLHIST (AUTOID,PERIOD,TXDATE,ACCTNO,BALANCE,AVGBAL,YEARBAL,DDR,DCR,MDR,MCR,YDR,YCR) " & ControlChars.CrLf _
                & "SELECT SEQ_GLHIST.NEXTVAL,'EOD',TO_DATE('" & v_strCURRDATE & "','" & gc_FORMAT_DATE & "'),ACCTNO,BALANCE,AVGBAL,YEARBAL,DDR,DCR,MDR,MCR,YDR,YCR FROM GLMAST"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            'Clear phát sinh DDR, DCR
            v_strSQL = "UPDATE GLMAST SET DDR=0, DCR=0"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function GLEOM() As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = ATTR_MODULE & ".Batch.GLEOM", v_strErrorMessage As String
        Dim v_strSQL As String, v_ds As DataSet
        Dim v_obj As New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)
        Dim i, j As Integer, v_strFRTABLE, v_strTOTABLE As String
        Try
            'Lấy tham số hệ thống
            Dim v_strSYSVAR, v_strCURRDATE, v_strPREVDATE, v_strNEXTDATE As String
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "PREVDATE", v_strPREVDATE)
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "CURRDATE", v_strCURRDATE)
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "NEXTDATE", v_strNEXTDATE)
            If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode

            'Sao lưu cân đối cuối ngày
            v_strSQL = "INSERT INTO GLHIST (AUTOID,PERIOD,TXDATE,ACCTNO,BALANCE,AVGBAL,YEARBAL,DDR,DCR,MDR,MCR,YDR,YCR) " & ControlChars.CrLf _
                & "SELECT SEQ_GLHIST.NEXTVAL,'EOM',TO_DATE('" & v_strCURRDATE & "','" & gc_FORMAT_DATE & "'),ACCTNO,BALANCE,AVGBAL,YEARBAL,DDR,DCR,MDR,MCR,YDR,YCR FROM GLMAST"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            'Clear phát sinh MDR, MCR
            v_strSQL = "UPDATE GLMAST SET MDR=0, MCR=0"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function GLEOY() As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = ATTR_MODULE & ".Batch.GLEOY", v_strErrorMessage As String
        Dim v_strSQL As String, v_ds As DataSet
        Dim v_obj As New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)
        Dim i, j As Integer, v_strFRTABLE, v_strTOTABLE As String
        Try
            'Lấy tham số hệ thống
            Dim v_strSYSVAR, v_strCURRDATE, v_strPREVDATE, v_strNEXTDATE As String
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "PREVDATE", v_strPREVDATE)
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "CURRDATE", v_strCURRDATE)
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "NEXTDATE", v_strNEXTDATE)
            If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode

            'Sao lưu cân đối cuối ngày
            v_strSQL = "INSERT INTO GLHIST (AUTOID,PERIOD,TXDATE,ACCTNO,BALANCE,AVGBAL,YEARBAL,DDR,DCR,MDR,MCR,YDR,YCR) " & ControlChars.CrLf _
                & "SELECT SEQ_GLHIST.NEXTVAL,'EOY',TO_DATE('" & v_strCURRDATE & "','" & gc_FORMAT_DATE & "'),ACCTNO,BALANCE,AVGBAL,YEARBAL,DDR,DCR,MDR,MCR,YDR,YCR FROM GLMAST"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            'Clear phát sinh YDR, YCR
            v_strSQL = "UPDATE GLMAST SET YDR=0, YCR=0"
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
