Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Public Class AFTEMPLATES
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "AFTEMPLATES"
    End Sub

#Region " Overrides functions "

    Overrides Function CheckBeforeDelete(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_strObjMsg As String
        Dim v_ds As DataSet

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strClause, v_strBRID, v_strTellerId As String
            Dim v_strLocal As String
            Dim v_strSQL As String

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
            If Not (v_attrColl.GetNamedItem(gc_AtributeBRID) Is Nothing) Then
                v_strBRID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeBRID), Xml.XmlAttribute).Value)
            Else
                v_strBRID = String.Empty
            End If
            If Not (v_attrColl.GetNamedItem(gc_AtributeTLID) Is Nothing) Then
                v_strTellerId = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Else
                v_strTellerId = String.Empty
            End If

            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            '27/05/2018 Log lai dang ky SMS Email
            v_strSQL = "INSERT INTO aftemplateslog(autoid, custid, template_code, begindate, enddate, last_change, action,tlid) " & ControlChars.CrLf _
                            & "SELECT TL.AUTOID, tl.CUSTID, TL.template_code, CREATEDATE, getcurrdate, sysdate, 'DELETE', '" & v_strTellerId & "'" & ControlChars.CrLf _
                        & " FROM aftemplates TL WHERE  " & v_strClause & " "

            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)


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

    Overrides Function ProcessAfterApprove(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_strErrorSource As String = "CF.AFTEMPLATES.ProcessAfterApprove", v_strErrorMessage As String

        Dim v_strObjMsg As String
        Dim v_ds, v_dsFOR As DataSet
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strClause, v_strTellerId, v_strTXDATE, v_strBRID As String
            Dim v_strLocal As String
            Dim v_strSQL As String

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
            If Not (v_attrColl.GetNamedItem(gc_AtributeBRID) Is Nothing) Then
                v_strBRID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeBRID), Xml.XmlAttribute).Value)
            Else
                v_strBRID = String.Empty
            End If
            If Not (v_attrColl.GetNamedItem(gc_AtributeBRID) Is Nothing) Then
                v_strTellerId = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Else
                v_strTellerId = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeTXDATE) Is Nothing) Then
                v_strTXDATE = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXDATE), Xml.XmlAttribute).Value)
            Else
                v_strTXDATE = String.Empty
            End If

            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            '27/05/2018 Update ngay Duyet cua cac dong log chua Duyet
            v_strSQL = "update aftemplateslog set approvedate = getcurrdate where approvedate is null and " & v_strClause
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If
            Return ERR_SYSTEM_OK
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try

    End Function

    Overrides Function ProcessAfterAdd(ByVal v_strMessage As String) As Long
        Dim v_lngErrorCode As Long
        Dim v_strSYSVAR, v_strSQLTmp As String, v_DataAccess As New DataAccess
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        'Return ERR_SYSTEM_OK
        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Try

            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strAITOID, v_strCUSTID, v_strTEMPLATE_CODE As String
            Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String
            Dim v_strSQL, v_strTLID As String
            Dim v_BRID As String
            v_BRID = CStr(CType(v_attrColl.GetNamedItem("BRID"), Xml.XmlAttribute).Value)
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

            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strVALUE = .InnerText.ToString()
                    v_strVALUE = v_strVALUE.Replace("'", "''")
                    Select Case Trim(v_strFLDNAME)
                        Case "AITOID"
                            v_strAITOID = Trim(v_strVALUE)
                        Case "CUSTID"
                            v_strCUSTID = Trim(v_strVALUE)
                        Case "TEMPLATE_CODE"
                            v_strTEMPLATE_CODE = Trim(v_strVALUE)

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

            '27/05/2018 Log lai dang ky SMS Email
            '27/05/2018 Log lai dang ky SMS Email
            v_strSQL = "update aftemplates set createdate = getcurrdate  " & ControlChars.CrLf _
                        & " WHERE  CUSTID = '" & v_strCUSTID & "' and template_code = '" & v_strTEMPLATE_CODE & "' "

            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            v_strSQL = "INSERT INTO aftemplateslog(autoid, custid, template_code, begindate, enddate, last_change, action,tlid) " & ControlChars.CrLf _
                            & "SELECT TL.AUTOID, tl.CUSTID, TL.template_code, getcurrdate, null, sysdate, 'ADD', '" & v_strTLID & "'" & ControlChars.CrLf _
                        & " FROM aftemplates TL WHERE  CUSTID = '" & v_strCUSTID & "' and template_code = '" & v_strTEMPLATE_CODE & "' "

            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

        Catch ex As Exception
            Throw ex
        End Try

    End Function
   
#End Region

#Region "Private Methoad"

    
    
    
#End Region

End Class
