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
            Dim v_strDEFAULTACCT, v_strCFCUSTID As String

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
                        Case "DEFAULTACCT"
                            v_strDEFAULTACCT = Trim(v_strVALUE)
                        Case "CFCUSTID"
                            v_strCFCUSTID = Trim(v_strVALUE)
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
            'TanPN 30/1/2020 
            If v_strDEFAULTACCT = "Y" Then
                v_strSQL = "SELECT * FROM CFOTHERACC WHERE CFCUSTID = '" & v_strCFCUSTID & "' AND DEFAULTACCT = 'Y' AND DELTD = 'N'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    Return ERR_SA_EXIT_DEFAULTACCT
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

    Overrides Function CheckBeforeEdit(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strCCYCD As String
            Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String
            Dim v_strACCOUNT, v_strBANKACC, v_strAFACCTNO, v_strTYPE, v_strCUSTID, v_strFEECD, v_strAUTOID As String
            Dim v_strSQL As String
            Dim v_strDEFAULTACCT, v_strCFCUSTID As String

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
                        Case "DEFAULTACCT"
                            v_strDEFAULTACCT = Trim(v_strVALUE)
                        Case "CFCUSTID"
                            v_strCFCUSTID = Trim(v_strVALUE)
                        Case "AUTOID"
                            v_strAUTOID = Trim(v_strVALUE)
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

            If v_strDEFAULTACCT = "Y" Then
                v_strSQL = "SELECT * FROM CFOTHERACC WHERE CFCUSTID = '" & v_strCFCUSTID & "' AND DEFAULTACCT = 'Y' AND DELTD = 'N' AND AUTOID <> " & v_strAUTOID & ""
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    Return ERR_SA_EXIT_DEFAULTACCT
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
#End Region

End Class
