Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data

Public Class BASKET
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "BASKET"
    End Sub

#Region " Overrides functions "
    Overrides Function CheckBeforeAdd(ByVal v_strMessage As String) As Long
        Dim v_strErrorSource, v_strErrorMessage As String
        v_strErrorSource = Me.ATTR_TABLE + ".CheckBeforeAdd"
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_ds As New DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strBASKETID As String
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
                        Case "BASKETID"
                            v_strBASKETID = Trim(v_strVALUE)
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

            v_strSQL = "SELECT COUNT(*) FROM BASKET WHERE BASKETID='" & v_strBASKETID & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If gf_CorrectNumericField(v_ds.Tables(0).Rows(0)(0)) > 0 Then
                Return ERR_SA_BASKETID_DUPLICATED
            End If

            Return ERR_SYSTEM_OK
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        Finally
            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If
        End Try
    End Function

    Overrides Function CheckBeforeDelete(ByVal v_strMessage As String) As Long
        Dim v_strErrorSource, v_strErrorMessage As String
        v_strErrorSource = Me.ATTR_TABLE + ".CheckBeforeDelete"
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_ds As New DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strBASKETID, v_strClause As String
            Dim v_strSQL, v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String

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

            'v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            'For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
            '    With v_nodeList.Item(0).ChildNodes(i)
            '        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
            '        v_strVALUE = .InnerText.ToString()

            '        Select Case Trim(v_strFLDNAME)
            '            Case "BASKETID"
            '                v_strBASKETID = Trim(v_strVALUE)
            '        End Select
            '    End With
            'Next

            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            'v_strSQL = "SELECT BASKETID FROM SECBASKET WHERE BASKETID='" & v_strBASKETID & "' UNION ALL " & ControlChars.CrLf _
            '    & "SELECT BASKETID FROM DFBASKET WHERE BASKETID='" & v_strBASKETID & "'"
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'If v_ds.Tables(0).Rows.Count > 0 Then
            '    Return ERR_SA_BASKETID_HAS_CONTRAINT
            'End If

            'v_strSQL = "SELECT BASKETID FROM afdfbasket WHERE BASKETID='" & v_strBASKETID & "' UNION ALL " & ControlChars.CrLf _
            '    & "SELECT BASKETID FROM afsebasket WHERE BASKETID='" & v_strBASKETID & "'"
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'If v_ds.Tables(0).Rows.Count > 0 Then
            '    Return ERR_SA_BASKETID_HAS_CONTRAINT
            'End If
            v_strSQL = "SELECT BASKETID FROM SECBASKET WHERE " & v_strClause & " UNION ALL " & ControlChars.CrLf _
                & "SELECT BASKETID FROM DFBASKET WHERE " & v_strClause
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                Return ERR_SA_BASKETID_HAS_CONTRAINT
            End If

            v_strSQL = "SELECT BASKETID FROM afdfbasket WHERE " & v_strClause & " UNION ALL " & ControlChars.CrLf _
                & "SELECT BASKETID FROM afsebasket WHERE " & v_strClause
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                Return ERR_SA_BASKETID_HAS_CONTRAINT
            End If

            Return ERR_SYSTEM_OK
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        Finally
            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If
        End Try
    End Function
#End Region

End Class
