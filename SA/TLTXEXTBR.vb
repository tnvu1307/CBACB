Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Public Class TLTXEXTBR
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "TLTXEXTBR"
    End Sub

#Region " Overrides functions "
    Overrides Function CheckBeforeAdd(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strTLTYPE, v_strTLTXCD, v_strBRID, v_strTLCODE As String
            Dim v_strSQL, v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String

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
                        Case "TLTYPE"
                            v_strTLTYPE = Trim(v_strVALUE)
                        Case "TLCODE"
                            v_strTLCODE = Trim(v_strVALUE)
                        Case "TLTXCD"
                            v_strTLTXCD = Trim(v_strVALUE)
                        Case "BRID"
                            v_strBRID = Trim(v_strVALUE)
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

            v_strSQL = "SELECT COUNT(*) FROM " & ATTR_TABLE & " WHERE BRID='" & v_strBRID & "' AND TLTYPE='" & v_strTLTYPE & "' AND TLCODE='" & v_strTLCODE & "' AND TLTXCD='" & v_strTLTXCD & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If gf_CorrectNumericField(v_ds.Tables(0).Rows(0)(0)) > 0 Then
                Return ERR_SA_TLTX_TL_GRP_DUPLICATE_BRANCH
            End If

            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If
            Return ERR_SYSTEM_OK
        Catch ex As Exception
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
            Dim v_strLocal, v_strAutoID, v_strTLTYPE, v_strTLTXCD, v_strBRID, v_strTLCODE As String
            Dim v_strSQL, v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String

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
                        Case "AUTOID"
                            v_strAutoID = Trim(v_strVALUE)
                        Case "TLTYPE"
                            v_strTLTYPE = Trim(v_strVALUE)
                        Case "TLCODE"
                            v_strTLCODE = Trim(v_strVALUE)
                        Case "TLTXCD"
                            v_strTLTXCD = Trim(v_strVALUE)
                        Case "BRID"
                            v_strBRID = Trim(v_strVALUE)
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

            v_strSQL = "SELECT COUNT(*) FROM " & ATTR_TABLE & " WHERE BRID='" & v_strBRID & "' AND TLTYPE='" & v_strTLTYPE & "' AND TLCODE='" & v_strTLCODE & "' AND TLTXCD='" & v_strTLTXCD & "' AND AUTOID <> " & v_strAutoID
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If gf_CorrectNumericField(v_ds.Tables(0).Rows(0)(0)) > 0 Then
                Return ERR_SA_TLTX_TL_GRP_DUPLICATE_BRANCH
            End If

            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If
            Return ERR_SYSTEM_OK
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

#End Region
End Class
