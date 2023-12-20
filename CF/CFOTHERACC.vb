Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
'Imports System.EnterpriseServices

'<JustInTimeActivation(False), _
'Transaction(TransactionOption.Supported), _
'ObjectPooling(Enabled:=True, MinPoolSize:=30)> _
Public Class CFOTHERACC
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "CFOTHERACC"
        'ContextUtil.SetComplete()
    End Sub
#Region " Overrides functions "
    Overrides Function CheckBeforeAdd(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strCCYCD As String
            Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String
            Dim v_strACCOUNT, v_strBANKACC, v_strAFACCTNO, v_strTYPE, v_strCUSTID, v_strFEECD As String
            Dim v_strSQL As String

            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If

            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strVALUE = .InnerText.ToString()

                    Select Case Trim(v_strFLDNAME)
                        Case "CIACCOUNT"
                            v_strACCOUNT = Trim(v_strVALUE)
                        Case "BANKACC"
                            v_strBANKACC = Trim(v_strVALUE)
                        Case "CUSTID"
                            v_strCUSTID = Trim(v_strVALUE)
                        Case "AFACCTNO"
                            v_strAFACCTNO = Trim(v_strVALUE)
                        Case "TYPE"
                            v_strTYPE = Trim(v_strVALUE)
                        Case "FEECD"
                            v_strFEECD = Trim(v_strVALUE)
                    End Select
                End With
            Next

            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If


            If v_strTYPE = "0" Then
                v_strSQL = "SELECT * FROM AFMAST WHERE ACCTNO = '" & v_strACCOUNT & "' and status IN('A','B')"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count = 0 Then
                    Return ERR_SA_CIACCOUNT_NOTFOUND
                End If
            End If
            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If

            'ContextUtil.SetComplete()
            Return ERR_SYSTEM_OK
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    'AnTB added 13/02/2015
    Overrides Function SystemProcessBeforeAdd(ByRef v_strMessage As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = ATTR_TABLE & ".SystemProcessBeforeAdd"
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Try
            v_lngErrCode = CheckAddEditData(v_strMessage)
            'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    'AnTB added 13/02/2015
    Overrides Function SystemProcessBeforeEdit(ByRef v_strMessage As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = ATTR_TABLE & ".SystemProcessBeforeEdit"
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Try
            v_lngErrCode = CheckAddEditData(v_strMessage)
            'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function


    Overrides Function CheckBeforeEdit(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strCCYCD As String
            Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE, v_strClause As String
            Dim v_strACCOUNT, v_strBANKACC, v_strAFACCTNO, v_strTYPE, v_strCUSTID, v_strFEECD As String
            Dim v_strSQL, v_strTLID, v_strTXDATE As String

            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeCLAUSE) Is Nothing) Then
                v_strClause = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Else
                v_strClause = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeTLID) Is Nothing) Then
                v_strTLID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Else
                v_strTLID = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeTXDATE) Is Nothing) Then
                v_strTXDATE = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXDATE), Xml.XmlAttribute).Value)
            Else
                v_strTXDATE = String.Empty
            End If

            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strVALUE = .InnerText.ToString()

                    Select Case Trim(v_strFLDNAME)
                        Case "CIACCOUNT"
                            v_strACCOUNT = Trim(v_strVALUE)
                        Case "BANKACC"
                            v_strBANKACC = Trim(v_strVALUE)
                        Case "CUSTID"
                            v_strCUSTID = Trim(v_strVALUE)
                        Case "AFACCTNO"
                            v_strAFACCTNO = Trim(v_strVALUE)
                        Case "TYPE"
                            v_strTYPE = Trim(v_strVALUE)
                        Case "FEECD"
                            v_strFEECD = Trim(v_strVALUE)
                    End Select
                End With
            Next

            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            If v_strTYPE = "0" Then
                v_strSQL = "SELECT * FROM AFMAST WHERE ACCTNO = '" & v_strACCOUNT & "' and status = 'A'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count = 0 Then
                    Return ERR_SA_CIACCOUNT_NOTFOUND
                End If
            End If

            v_strSQL = "UPDATE CFOTHERACC SET LAST_MKID = '" & v_strTLID & "', LAST_CHANGE = SYSTIMESTAMP WHERE " & v_strClause
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If

            'ContextUtil.SetComplete()
            Return ERR_SYSTEM_OK
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Overrides Function CheckBeforeApprove(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strCCYCD As String
            Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE, v_strClause As String
            Dim v_strACCOUNT, v_strBANKACC, v_strAFACCTNO, v_strTYPE, v_strCUSTID, v_strFEECD As String
            Dim v_strSQL As String
            Dim v_strTLID As String
            Dim v_strAPPRVDT As String

            If Not (v_attrColl.GetNamedItem(gc_AtributeCLAUSE) Is Nothing) Then
                v_strClause = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Else
                v_strClause = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeTLID) Is Nothing) Then
                v_strTLID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Else
                v_strTLID = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeTXDATE) Is Nothing) Then
                v_strAPPRVDT = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXDATE), Xml.XmlAttribute).Value)
            Else
                v_strAPPRVDT = String.Empty
            End If

            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            v_strSQL = "SELECT * FROM CFOTHERACC WHERE " & v_strClause
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                If v_ds.Tables(0).Rows(0)("OFFID").ToString <> "---" And Not v_ds.Tables(0).Rows(0)("APPRVDT").ToString Is Nothing Then
                    v_strSQL = "UPDATE CFOTHERACC SET LAST_OFFID = '" & v_strTLID &
                            "', LAST_APPRVDT = TO_DATE('" & v_strAPPRVDT & "','DD/MM/RRRR') " &
                            " WHERE " & v_strClause
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                Else
                    v_strSQL = "UPDATE CFOTHERACC SET OFFID = '" & v_strTLID & "', APPRVDT = TO_DATE('" & v_strAPPRVDT & "','DD/MM/RRRR'), " &
                    " LAST_OFFID = '" & v_strTLID & "', LAST_APPRVDT = TO_DATE('" & v_strAPPRVDT & "','DD/MM/RRRR') " &
                    " WHERE " & v_strClause
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                End If
            End If

            'ContextUtil.SetComplete()
            Return ERR_SYSTEM_OK
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Overrides Function Delete(ByRef v_strMessage As String) As Long
        Dim v_lngErrCode As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Try
            v_lngErrCode = CoreDeleteCFOTHERACC(pv_xmlDocument)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Dim v_strErrorSource, v_strErrorMessage As String
                v_strErrorSource = Me.ATTR_TABLE + ".Delete"
                v_strErrorMessage = String.Empty

                LogError.Write("Error source: " + v_strErrorSource + vbNewLine _
                             + "Error code: " + v_lngErrCode.ToString() + vbNewLine _
                             + "Error message: " + v_strErrorMessage, "EventLogEntryType.Error")
                BuildXMLErrorException(pv_xmlDocument, v_strErrorSource, v_lngErrCode, v_strErrorMessage)
            End If
            v_strMessage = pv_xmlDocument.InnerXml
            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function CoreDeleteCFOTHERACC(ByRef pv_xmlDocument As XmlDocumentEx) As Long
        Dim v_lngErrorCode As Long
        Dim v_strSYSVAR As String, v_DataAccess As New DataAccess
        Try
            'Check HOST Active
            v_DataAccess.NewDBInstance(gc_MODULE_HOST)
            v_lngErrorCode = v_DataAccess.GetSysVar("SYSTEM", "HOSTATUS", v_strSYSVAR)
            If v_lngErrorCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrorCode
            End If
            If v_strSYSVAR <> OPERATION_ACTIVE Then
                Rollback() 'ContextUtil.SetAbort()
                Return ERR_SA_HOST_OPERATION_ISINACTIVE
            End If

            'Verify memo table
            v_lngErrorCode = VerifyMemoTable()
            If v_lngErrorCode <> ERR_SYSTEM_OK Then
                Rollback()
                Return v_lngErrorCode
            End If

            Dim v_strSystemProcessMsg As String = pv_xmlDocument.InnerXml
            v_lngErrorCode = CheckBeforeDelete(v_strSystemProcessMsg)
            If v_lngErrorCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrorCode
                Exit Function
            End If
            v_lngErrorCode = SystemProcessBeforeDelete(v_strSystemProcessMsg)

            If v_lngErrorCode <> ERR_SYSTEM_OK Then
                Return v_lngErrorCode
            End If

            pv_xmlDocument.LoadXml(v_strSystemProcessMsg)

            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strClause As String
            Dim v_strLocal As String

            If Not (v_attrColl.GetNamedItem(gc_AtributeCLAUSE) Is Nothing) Then
                v_strClause = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Else
                v_strClause = String.Empty
            End If
            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If

            'Delete data
            Dim v_obj As DataAccess
            Dim v_strSQL As String
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If


            v_strSQL = "UPDATE " & ATTR_TABLE & " SET DELTD='Y' WHERE 0=0 AND " & v_strClause



            'Copy lại bản ghi cũ
            Dim v_strSQLMEMO As String = "INSERT INTO " & ATTR_TABLE & "MEMO SELECT * FROM " & ATTR_TABLE & " WHERE 0=0 AND " & v_strClause
            'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            v_lngErrorCode = RunApprExecSql(pv_xmlDocument, gc_ActionDeletE, v_strSQL, CommandType.Text, v_strSQLMEMO)
            If v_lngErrorCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrorCode
                Exit Function
            End If

            Dim result As Long
            result = Me.MaintainLog(pv_xmlDocument, gc_ActionDeletE)
            If Not (result = ERR_APPROVE_REQUIRED Or result = ERR_SYSTEM_OK) Then
                Return result
            End If


            v_strSystemProcessMsg = pv_xmlDocument.InnerXml
            v_lngErrorCode = ProcessAfterDelete(v_strSystemProcessMsg)
            If v_lngErrorCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrorCode
                Exit Function
            End If
            pv_xmlDocument.LoadXml(v_strSystemProcessMsg)

            Complete() 'ContextUtil.SetComplete()
            Return ERR_SYSTEM_OK
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        Finally
        End Try
    End Function

    'AnTB added 13/02/2015
    Private Function CheckAddEditData(ByRef v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_strObjMsg As String
        Dim v_lngErrCode As Long
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strCCYCD As String
            Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String
            Dim v_strCFCUSTID As String = "", v_strACCOUNT As String = "", v_strBANKACC As String = "", v_strAFACCTNO As String = ""
            Dim v_strTYPE As String = "", v_strCUSTID As String = "", v_strIDCODE As String = "", v_strFEECD As String = ""
            Dim v_strWarningMessage As String
            Dim v_strSQL As String

            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If

            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strVALUE = .InnerText.ToString()

                    Select Case Trim(v_strFLDNAME)
                        Case "CFCUSTID"
                            v_strCFCUSTID = Trim(v_strVALUE)
                        Case "CIACCOUNT"
                            v_strACCOUNT = Trim(v_strVALUE)
                        Case "BANKACC"
                            v_strBANKACC = Trim(v_strVALUE)
                        Case "CUSTID"
                            v_strCUSTID = Trim(v_strVALUE)
                        Case "AFACCTNO"
                            v_strAFACCTNO = Trim(v_strVALUE)
                        Case "ACNIDCODE"
                            v_strIDCODE = Trim(v_strVALUE)
                        Case "TYPE"
                            v_strTYPE = Trim(v_strVALUE)
                        Case "FEECD"
                            v_strFEECD = Trim(v_strVALUE)
                    End Select
                End With
            Next

            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            'Goi store procedure fillter neu co khai bao can fillter
            Dim v_objParam As New StoreParameter
            Dim v_arrPara(6) As StoreParameter
            v_objParam.ParamName = "p_type"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamValue = v_strTYPE
            v_objParam.ParamSize = 100
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(0) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_cfcustid"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamValue = v_strCFCUSTID
            v_objParam.ParamSize = 100
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(1) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_ciaccount"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamValue = v_strACCOUNT
            v_objParam.ParamSize = 100
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(2) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_custid"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamValue = v_strCUSTID
            v_objParam.ParamSize = 100
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(3) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_bankacct"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamValue = v_strBANKACC
            v_objParam.ParamSize = 100
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(4) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_err_param"
            v_objParam.ParamDirection = ParameterDirection.Output
            v_objParam.ParamValue = ""
            v_objParam.ParamSize = 100
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(5) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_warning_message"
            v_objParam.ParamDirection = ParameterDirection.Output
            v_objParam.ParamValue = ""
            v_objParam.ParamSize = 100
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(6) = v_objParam

            v_strWarningMessage = v_obj.ExecuteOracleStored("PRC_CHECK_CFOTHERACC", v_arrPara, 6)

            If Not IsNumeric(v_arrPara(5).ParamValue) Then
                v_lngErrCode = 0
                'v_strWarningMessage = CDec(v_arrPara(6).ParamValue)
                'AnTB added 13/02/2015 Kiem tra co warning message không
                If IsNumeric(v_strWarningMessage) Then
                    Dim v_strErrorSQL, v_strErrorMessage, v_strErrorSource As String
                    Dim v_lngErrNumber As Long = CDec(v_strWarningMessage)
                    Dim v_ErrorDS As DataSet
                    'Neu co warning message gan gc_AtributeWARNING = "Y"
                    pv_xmlDocument.SelectSingleNode(gc_SCHEMA_OBJMESSAGE_ROOT).Attributes(gc_AtributeWARNING).Value = "Y"

                    v_strErrorSQL = "SELECT ERRDESC FROM DEFERROR WHERE ERRNUM = '" & v_lngErrNumber.ToString & "'"
                    Try
                        v_ErrorDS = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strErrorSQL)
                        v_strErrorMessage = v_ErrorDS.Tables(0).Rows(0)("ERRDESC")
                    Catch ex As Exception
                        v_strErrorMessage = "[" & v_lngErrNumber.ToString() & "]: Undefined error!"
                    End Try
                    BuildXMLWarningException(pv_xmlDocument, v_strErrorSource, v_lngErrNumber, v_strErrorMessage, gc_WARNING_MESSAGE)
                    v_strMessage = pv_xmlDocument.InnerXml
                End If
            Else
                v_lngErrCode = CDec(v_arrPara(5).ParamValue)
                If v_lngErrCode <> ERR_SYSTEM_OK Then
                    'Tra ve ma loi xuat ra tu function
                    Return v_lngErrCode
                Else
                    'Kiem tra co warning message không
                    If IsNumeric(v_strWarningMessage) Then
                        Dim v_strErrorSQL, v_strErrorMessage, v_strErrorSource As String
                        Dim v_lngErrNumber As Long = CDec(v_strWarningMessage)
                        Dim v_ErrorDS As DataSet

                        'Neu co warning message gan gc_AtributeWARNING = "Y"
                        pv_xmlDocument.SelectSingleNode(gc_SCHEMA_OBJMESSAGE_ROOT).Attributes(gc_AtributeWARNING).Value = "Y"

                        v_strErrorSQL = "SELECT ERRDESC FROM DEFERROR WHERE ERRNUM = '" & v_lngErrNumber.ToString & "'"
                        Try
                            v_ErrorDS = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strErrorSQL)
                            v_strErrorMessage = v_ErrorDS.Tables(0).Rows(0)("ERRDESC")
                        Catch ex As Exception
                            v_strErrorMessage = "[" & v_lngErrNumber.ToString() & "]: Undefined error!"
                        End Try
                        BuildXMLWarningException(pv_xmlDocument, v_strErrorSource, v_lngErrNumber, v_strErrorMessage, gc_WARNING_MESSAGE)
                        v_strMessage = pv_xmlDocument.InnerXml
                    End If

                End If

            End If

            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If

            'ContextUtil.SetComplete()
            Return ERR_SYSTEM_OK
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    'AnTB added 13/02/2015
    Private Function CheckApproveData(ByRef v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_strObjMsg As String
        Dim v_lngErrCode As Long
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strClause, v_strCCYCD As String
            Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String
            Dim v_strAUTOID As String = "", v_strCFCUSTID As String = "", v_strACCOUNT As String = "", v_strBANKACC As String = "", v_strAFACCTNO As String = ""
            Dim v_strTYPE As String = "", v_strCUSTID As String = "", v_strIDCODE As String = "", v_strFEECD As String = ""
            Dim v_strWarningMessage As String
            Dim v_strSQL As String

            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strClause = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Else
                v_strClause = String.Empty
            End If


            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            'Get value 
            v_strSQL = "SELECT * FROM CFOTHERACC WHERE " & v_strClause & ""
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

            If v_ds.Tables(0).Rows.Count > 0 Then
                v_strCFCUSTID = Trim(v_ds.Tables(0).Rows(0)("CFCUSTID").ToString)
                v_strACCOUNT = Trim(v_ds.Tables(0).Rows(0)("CIACCOUNT").ToString)
                v_strBANKACC = Trim(v_ds.Tables(0).Rows(0)("BANKACC").ToString)
                v_strCUSTID = Trim(v_ds.Tables(0).Rows(0)("CUSTID").ToString)
                v_strIDCODE = Trim(v_ds.Tables(0).Rows(0)("ACNIDCODE").ToString)
                v_strTYPE = Trim(v_ds.Tables(0).Rows(0)("TYPE").ToString)
                v_strFEECD = Trim(v_ds.Tables(0).Rows(0)("FEECD").ToString)
            End If

            'Goi store procedure fillter neu co khai bao can fillter
            Dim v_objParam As New StoreParameter
            Dim v_arrPara(6) As StoreParameter
            v_objParam.ParamName = "p_type"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamValue = v_strTYPE
            v_objParam.ParamSize = 100
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(0) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_cfcustid"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamValue = v_strCFCUSTID
            v_objParam.ParamSize = 100
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(1) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_ciaccount"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamValue = v_strACCOUNT
            v_objParam.ParamSize = 100
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(2) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_custid"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamValue = v_strCUSTID
            v_objParam.ParamSize = 100
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(3) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_bankacct"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamValue = v_strBANKACC
            v_objParam.ParamSize = 100
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(4) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_err_param"
            v_objParam.ParamDirection = ParameterDirection.Output
            v_objParam.ParamValue = ""
            v_objParam.ParamSize = 100
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(5) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_warning_message"
            v_objParam.ParamDirection = ParameterDirection.Output
            v_objParam.ParamValue = ""
            v_objParam.ParamSize = 100
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(6) = v_objParam

            v_strWarningMessage = v_obj.ExecuteOracleStored("PRC_CHECK_CFOTHERACC", v_arrPara, 6)

            If Not IsNumeric(v_arrPara(5).ParamValue) Then
                v_lngErrCode = 0
                'v_strWarningMessage = CDec(v_arrPara(6).ParamValue)
                'AnTB added 13/02/2015 Kiem tra co warning message không
                If IsNumeric(v_strWarningMessage) Then
                    Dim v_strErrorSQL, v_strErrorMessage, v_strErrorSource As String
                    Dim v_lngErrNumber As Long = CDec(v_strWarningMessage)
                    Dim v_ErrorDS As DataSet
                    'Neu co warning message gan gc_AtributeWARNING = "Y"
                    pv_xmlDocument.SelectSingleNode(gc_SCHEMA_OBJMESSAGE_ROOT).Attributes(gc_AtributeWARNING).Value = "Y"

                    v_strErrorSQL = "SELECT ERRDESC FROM DEFERROR WHERE ERRNUM = '" & v_lngErrNumber.ToString & "'"
                    Try
                        v_ErrorDS = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strErrorSQL)
                        v_strErrorMessage = v_ErrorDS.Tables(0).Rows(0)("ERRDESC")
                    Catch ex As Exception
                        v_strErrorMessage = "[" & v_lngErrNumber.ToString() & "]: Undefined error!"
                    End Try
                    BuildXMLWarningException(pv_xmlDocument, v_strErrorSource, v_lngErrNumber, v_strErrorMessage, gc_WARNING_MESSAGE)
                    v_strMessage = pv_xmlDocument.InnerXml
                End If
            Else
                v_lngErrCode = CDec(v_arrPara(5).ParamValue)
                If v_lngErrCode <> ERR_SYSTEM_OK Then
                    'Tra ve ma loi xuat ra tu function
                    Return v_lngErrCode
                Else
                    'Kiem tra co warning message không
                    If IsNumeric(v_strWarningMessage) Then
                        Dim v_strErrorSQL, v_strErrorMessage, v_strErrorSource As String
                        Dim v_lngErrNumber As Long = CDec(v_strWarningMessage)
                        Dim v_ErrorDS As DataSet

                        'Neu co warning message gan gc_AtributeWARNING = "Y"
                        pv_xmlDocument.SelectSingleNode(gc_SCHEMA_OBJMESSAGE_ROOT).Attributes(gc_AtributeWARNING).Value = "Y"

                        v_strErrorSQL = "SELECT ERRDESC FROM DEFERROR WHERE ERRNUM = '" & v_lngErrNumber.ToString & "'"
                        Try
                            v_ErrorDS = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strErrorSQL)
                            v_strErrorMessage = v_ErrorDS.Tables(0).Rows(0)("ERRDESC")
                        Catch ex As Exception
                            v_strErrorMessage = "[" & v_lngErrNumber.ToString() & "]: Undefined error!"
                        End Try
                        BuildXMLWarningException(pv_xmlDocument, v_strErrorSource, v_lngErrNumber, v_strErrorMessage, gc_WARNING_MESSAGE)
                        v_strMessage = pv_xmlDocument.InnerXml
                    End If

                End If

            End If

            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If

            'ContextUtil.SetComplete()
            Return ERR_SYSTEM_OK
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
#End Region
    

End Class
