Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Public Class CAVOTING
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "CAVOTING"
    End Sub
    Overrides Function CheckBeforeAdd(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strFLDNAME, v_strVALUE, v_VOTECODE, v_strSQL, v_CAMASTID As String
        Dim v_ds As DataSet
        Try
            Dim v_obj As DataAccess
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal As String
            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If
            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strVALUE = .InnerText.ToString()
                    Select Case Trim(v_strFLDNAME)
                        Case "VOTECODE"
                            v_VOTECODE = v_strVALUE
                        Case "CAMASTID"
                            v_CAMASTID = v_strVALUE
                    End Select
                End With
            Next
            v_strSQL = "SELECT  COUNT(VOTECODE) FROM CAVOTING WHERE CAMASTID = '" & v_CAMASTID & "' AND VOTECODE = '" & v_VOTECODE & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count >= 1 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_CA_VOTECODE_DUPLICATED
                End If
            End If

        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
    Overrides Function CheckBeforeEdit(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strFLDNAME, v_strVALUE, v_VOTECODE, v_strSQL, v_CAMASTID As String
        Dim v_ds As DataSet
        Dim v_AUTOID As Long
        Try
            Dim v_obj As DataAccess
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal As String
            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If
            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strVALUE = .InnerText.ToString()
                    Select Case Trim(v_strFLDNAME)
                        Case "AUTOID"
                            v_AUTOID = v_strVALUE
                        Case "VOTECODE"
                            v_VOTECODE = v_strVALUE
                        Case "CAMASTID"
                            v_CAMASTID = v_strVALUE
                    End Select
                End With
            Next
            v_strSQL = "SELECT VOTECODE FROM CAVOTING WHERE AUTOID = '" & v_AUTOID & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            v_strSQL = "SELECT  COUNT(VOTECODE) FROM CAVOTING WHERE CAMASTID = '" & v_CAMASTID & "' and VOTECODE = '" & v_VOTECODE & "' and VOTECODE != '" & v_ds.Tables(0).Rows(0)(0) & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count >= 1 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_CA_VOTECODE_DUPLICATED
                End If
            End If

        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
End Class
