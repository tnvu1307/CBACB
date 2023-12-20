Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Public Class CFRELATION
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "CFRELATION"
    End Sub

#Region " Overrides functions "
    Overrides Function CheckBeforeAdd(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strCUSTID, v_strRECUSTID As String
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
                        Case "RECUSTID"
                            v_strRECUSTID = Trim(v_strVALUE)
                        Case "CUSTID"
                            v_strCUSTID = Trim(v_strVALUE)
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
            ''Kiem tra ma khach hang co quan he phai ton tai
            'v_strSQL = "SELECT COUNT(CUSTID) FROM CFMAST WHERE CUSTID = '" & Replace(v_strRECUSTID, ".", "") & "' And STATUS = 'A'"
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'If gf_CorrectNumericField(v_ds.Tables(0).Rows(0)(0)) = 0 Then
            '    Return ERR_CF_RECUSTID_NOTFOUND
            'End If

            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If
            'Check trung
            v_strSQL = "SELECT * FROM CFRELATION WHERE  CUSTID  = '" & v_strCUSTID & "' AND RECUSTID  = '" & v_strRECUSTID & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                Return ERR_CF_RELATION_DUPLICATE
            End If
            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If

            Return 0
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
        'Return 0
    End Function

    Overrides Function CheckBeforeEdit(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strCUSTID, v_strRECUSTID As String
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
                        Case "RECUSTID"
                            v_strRECUSTID = Trim(v_strVALUE)
                        Case "CUSTID"
                            v_strCUSTID = Trim(v_strVALUE)
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
            ''Kiem tra ma khach hang co quan he phai ton tai
            'v_strSQL = "SELECT COUNT(CUSTID) FROM CFMAST WHERE CUSTID = '" & Replace(v_strRECUSTID, ".", "") & "' And STATUS = 'A'"
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'If gf_CorrectNumericField(v_ds.Tables(0).Rows(0)(0)) = 0 Then
            '    Return ERR_CF_RECUSTID_NOTFOUND
            'End If

            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If
            ''Check trung
            'v_strSQL = "SELECT * FROM CFRELATION WHERE  CUSTID  = '" & v_strCUSTID & "' AND RECUSTID  = '" & v_strRECUSTID & "'"
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'If v_ds.Tables(0).Rows.Count > 0 Then
            '    Return ERR_CF_RELATION_DUPLICATE
            'End If
            'If Not (v_ds Is Nothing) Then
            '    v_ds.Dispose()
            'End If

            Return 0
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

#End Region

End Class
