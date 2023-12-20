Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Public Class ISSUER_MEMBER
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "ISSUER_MEMBER"
    End Sub

#Region " Overrides functions "
    Overrides Function CheckBeforeAdd(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strCUSTID, v_strAUTOID As String
            Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE, v_strLICENSENO, v_strISSUERID As String
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
                        Case "CUSTID"
                            v_strCUSTID = Trim(v_strVALUE)
                        Case "LICENSENO"
                            v_strLICENSENO = Trim(v_strVALUE)
                        Case "AUTOID"
                            v_strAUTOID = Trim(v_strVALUE)
                        Case "ISSUERID"
                            v_strISSUERID = Trim(v_strVALUE)

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
            'Kiem tra ISSUERID Phai ton tai
            If v_strISSUERID <> "" Then
                v_strSQL = "SELECT COUNT (*) COUNTROW FROM ISSUERS WHERE ISSUERID = '" & v_strISSUERID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows(0)("COUNTROW") = 0 Then
                    Return ERR_SA_ISSUERID_NOTFOUND
                End If
            End If
            'Kiểm tra CUSTID phai ton tai
            If v_strCUSTID <> "" Then
                v_strSQL = "SELECT COUNT(CUSTID) FROM CFMAST WHERE  CUSTID  = '" & v_strCUSTID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count = 1 Then
                    If v_ds.Tables(0).Rows(0)(0) = 0 Then
                        Return ERR_SA_ISSUER_MEMBER_CUSTID_NOTFOUND
                    End If
                End If
            Else
                If v_strLICENSENO = "" Then
                    Return ERR_SA_LICENSENO_ISNOT_EMPTY
                End If
            End If
            v_strSQL = "SELECT * FROM ISSUER_MEMBER WHERE  CUSTID  = '" & v_strCUSTID & "' AND ISSUERID  = '" & v_strISSUERID & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                Return ERR_SA_ISSUERS_ISSUERID_DUPLICATED
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
            Dim v_strLocal, v_strCUSTID As String
            Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE, v_strISSUERID, v_strLICENSENO As String
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
                        Case "CUSTID"
                            v_strCUSTID = Trim(v_strVALUE)
                        Case "LICENSENO"
                            v_strLICENSENO = Trim(v_strVALUE)
                        Case "ISSUERID"
                            v_strISSUERID = Trim(v_strVALUE)
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
            'thunt-2019-07-11: thêm kt tổ chức phát hành khi sửa
            If v_strISSUERID <> "" Then
                v_strSQL = "SELECT COUNT (*) COUNTROW FROM ISSUERS WHERE ISSUERID = '" & v_strISSUERID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows(0)("COUNTROW") = 0 Then
                    Return ERR_SA_ISSUERID_NOTFOUND
                End If
            End If

            'Kiểm tra CUSTID phai ton tai
            If v_strCUSTID <> "" Then
                v_strSQL = "SELECT COUNT(CUSTID) FROM CFMAST WHERE  CUSTID  = '" & v_strCUSTID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count = 1 Then
                    If v_ds.Tables(0).Rows(0)(0) = 0 Then
                        Return ERR_SA_ISSUER_MEMBER_CUSTID_NOTFOUND
                    End If
                End If
            Else
                If v_strLICENSENO = "" Then
                    Return ERR_SA_LICENSENO_ISNOT_EMPTY
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
#End Region

End Class
