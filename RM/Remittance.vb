Imports HostCommonLibrary
Imports DataAccessLayer
Imports CoreBusiness
Imports System.Data
'Imports System.EnterpriseServices
'<JustInTimeActivation(False), _
'Transaction(TransactionOption.Disabled), _
'ObjectPooling(Enabled:=True, MinPoolSize:=30)> _
Public Class Remittance
    'Inherits ServicedComponent
    Inherits TxScope

    Dim LogError As LogError = New LogError()

    Function ExecuteRouter(ByRef pv_strObjMessage As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "RM.Batch.ExecuteRouter", v_strErrorMessage As String
        Dim v_strxmlMessage As String, v_xmlMessage As New Xml.XmlDocument
        Try
            v_xmlMessage.LoadXml(pv_strObjMessage)
            Dim v_strTLTXCD = v_xmlMessage.DocumentElement.Attributes(gc_AtributeTLTXCD).Value
            Select Case v_strTLTXCD
                Case gc_RM_RCV_HOLD, gc_RM_RCV_UNHOLD, gc_RM_RCV_TRANSFER
                    v_lngErrCode = ExecuteRemittance(pv_strObjMessage)
            End Select
            'Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            'Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function ExecuteRemittance(ByRef pv_strMessage As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "RM.Remittance.ExecuteHold", v_strErrorMessage As String
        Dim v_strSQL As String, v_ds, v_dsTLLOG As DataSet, v_objMessageLog As New MessageLog
        v_objMessageLog.NewDBInstance(gc_MODULE_HOST)
        Dim v_obj As New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)
        Dim i, j As Integer
        Dim v_xmlRcvDocument As New Xml.XmlDocument
        Dim v_xmlDocument As New Xml.XmlDocument, v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
        Dim v_strVALEXP, v_strVALUE, v_strFLDNAME, v_strDEFNAME, v_strFLDTYPE As String
        Dim v_attrFLDNAME, v_attrDATATYPE As Xml.XmlAttribute
        Dim v_strTLTXCD As String
        Dim v_nodetxData As Xml.XmlNode
        Try
            Dim v_strSYSVAR, v_strCURRDATE, v_strPREVDATE, v_strNEXTDATE As String
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "CURRDATE", v_strCURRDATE)
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "PREVDATE", v_strPREVDATE)
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "NEXTDATE", v_strNEXTDATE)
            If v_lngErrCode <> ERR_SYSTEM_OK Then Return v_lngErrCode

            Dim v_strTXDESC As String
            v_xmlRcvDocument.LoadXml(pv_strMessage)
            v_strTLTXCD = v_xmlRcvDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value
            v_lngErrCode = BuildCoreBankTxMsg(v_xmlDocument, "BANK")
            v_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value = v_strTLTXCD
            v_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value = v_xmlRcvDocument.DocumentElement.Attributes(gc_AtributeBRID).Value.ToString
            v_nodetxData = v_xmlRcvDocument.SelectSingleNode("/TransactMessage/fields")
            v_dataElement = v_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "fields", "")
            v_dataElement.InnerXml = v_nodetxData.InnerXml
            v_xmlDocument.DocumentElement.AppendChild(v_dataElement)
            v_lngErrCode = v_objMessageLog.TransLog(v_xmlDocument)
            pv_strMessage = v_xmlDocument.InnerXml
            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode

        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function


    Overridable Function BuildCoreBankTxMsg(ByRef v_xmlDocument As Xml.XmlDocument, ByVal v_strDetailName As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CoreBusiness.Batch.BuildBatchTxMsg", v_strErrorMessage As String
        Dim v_strSQL As String, v_ds As DataSet, v_obj As New DataAccess
        Dim v_strTxMsg, v_strTxNum, v_strTxDate, v_strPrevDate, v_strNextDate As String
        Try
            v_obj.NewDBInstance(gc_MODULE_HOST)
            'Lấy số chứng từ
            v_strTxNum = COREBANK_PREFIXED & Right(gc_FORMAT_BATCHTXNUm & CStr(v_obj.GetIDValue("COREBANKTXNUM")), Len(gc_FORMAT_BATCHTXNUm) - Len(COREBANK_PREFIXED))
            'Lấy ngày làm việc hiện tại
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "CURRDATE", v_strTxDate)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            End If

            'Tạo message trả v�?
            v_strTxMsg = BuildXMLTxMsg(gc_MsgTypeTranS, gc_IsNotLocalMsg, , "0000", "0000", "HOST", "HOST")
            v_xmlDocument.LoadXml(v_strTxMsg)
            v_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value = v_strTxNum
            v_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value = v_strTxDate
            v_xmlDocument.DocumentElement.Attributes(gc_AtributeBATCHNAME).Value = v_strDetailName
            v_xmlDocument.DocumentElement.Attributes(gc_AtributeSTATUS).Value = CStr(TransactStatus.Logged)
            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
End Class
