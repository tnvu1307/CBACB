Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Public Class ODPROBRKAF
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "ODPROBRKAF"
    End Sub

#Region " Overrides functions "
    Overrides Function CheckBeforeAdd(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strREFAUTOID, v_strAFACCTNO As String
            Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String
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
                        Case "REFAUTOID"
                            v_strREFAUTOID = Trim(v_strVALUE)
                        Case "AFACCTNO"
                            v_strAFACCTNO = Trim(v_strVALUE)
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

            v_strSQL = "select * from ODPROBRKMST mst,ODPROBRKMST mst1,ODPROBRKAF kaf where kaf.deltd<>'Y' and mst.autoid = kaf.REFAUTOID and kaf.AFACCTNO = " & v_strAFACCTNO & " and mst.PROBRKMSTTYPE = mst1.PROBRKMSTTYPE and mst1.autoid = " & v_strREFAUTOID & " "
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 1 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_SA_ODPROBRKAF_DUPLICATED
                End If
            End If

            v_strSQL = "select * from ODPROBRKMST mst, sysvar sys where sys.GRNAME = 'SYSTEM' AND sys.VARNAME ='CURRDATE' and to_date(sys.varvalue,'dd/MM/yyyy')<=mst.expdate and mst.autoid = " & v_strREFAUTOID
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 0 Then
                Return ERR_SA_ODPROBRKAF_CREATEDDATE_ERROR
            End If

            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If

            'ContextUtil.SetComplete()
            Return 0
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
            Dim v_strLocal, v_strREFAUTOID, v_strAFACCTNO As String
            Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String
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
                        Case "REFAUTOID"
                            v_strREFAUTOID = Trim(v_strVALUE)
                        Case "AFACCTNO"
                            v_strAFACCTNO = Trim(v_strVALUE)
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

            v_strSQL = "select * from ODPROBRKMST mst,ODPROBRKMST mst1,ODPROBRKAF kaf where mst.autoid = kaf.REFAUTOID and kaf.AFACCTNO = " & v_strAFACCTNO & " and mst.PROBRKMSTTYPE = mst1.PROBRKMSTTYPE and mst1.autoid = " & v_strREFAUTOID & " "
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 1 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_SA_ODPROBRKAF_DUPLICATED
                End If
            End If

            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If

            'ContextUtil.SetComplete()
            Return 0
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    '' DieuNDA add de luu vet thong tin tieu khoan dc add vao chinh sach
    Overridable Function Delete(ByRef v_strMessage As String) As Long
        Dim v_lngErrCode As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Try
            v_lngErrCode = CoreDeleteODPROBRKAF(pv_xmlDocument)
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

    Private Function CoreDeleteODPROBRKAF(ByRef pv_xmlDocument As XmlDocumentEx) As Long
        Dim v_lngErrorCode As Long
        Dim v_strSYSVAR As String, v_DataAccess As New DataAccess
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
        If v_strLocal = "Y" Then
            v_obj = New DataAccess
        ElseIf v_strLocal = "N" Then
            v_obj = New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
        End If

        Dim v_strSQL As String = "UPDATE " & ATTR_TABLE & " SET DELTD='Y', DELDDATE=getcurrdate WHERE 0=0 AND " & v_strClause

        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
        Complete() 'ContextUtil.SetComplete()


        Dim result As Long
        result = Me.MaintainLog(pv_xmlDocument, gc_ActionDelete)
        If Not (result = ERR_APPROVE_REQUIRED Or result = ERR_SYSTEM_OK) Then
            Return result
        End If

        Return ERR_SYSTEM_OK
    End Function
#End Region

End Class