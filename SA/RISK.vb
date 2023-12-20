Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Public Class RISK
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "SECURITIES_INFO"
    End Sub

#Region " Overrides functions "
    Overrides Function CheckBeforeAdd(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strCODEID, v_dblFromPrice, v_dblToPrice, v_strSymbol As String
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
                        Case "CODEID"
                            v_strCODEID = Trim(v_strVALUE)
                        Case "FROMPRICE"
                            v_dblFromPrice = CDbl(v_strVALUE.Trim())
                        Case "TOPRICE"
                            v_dblToPrice = CDbl(v_strVALUE.Trim())
                        Case "SYMBOL"
                            v_strSymbol = Trim(v_strVALUE.Trim())
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

            'Kiểm tra trường CODEID có tồn tại hay không
            If v_strCODEID.Length > 0 Then
                v_strSQL = "SELECT COUNT(CODEID) FROM SBSECURITIES WHERE CODEID = '" & v_strCODEID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count = 1 Then
                    If v_ds.Tables(0).Rows(0)(0) = 0 Then
                        Return ERR_SE_CODEID_NOTFOUND
                    End If
                End If
            End If
            'Kiểm tra trường Symbol có tồn tại hay không
            If v_strCODEID.Length > 0 Then
                v_strSQL = "SELECT COUNT(SYMBOL) FROM SBSECURITIES WHERE SYMBOL = '" & v_strSymbol & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count = 1 Then
                    If v_ds.Tables(0).Rows(0)(0) = 0 Then
                        Return ERR_SE_SYMBOL_NOTFOUND
                    End If
                End If
            End If
            'Kiểm tra khoảng giá tương ứng với mỗi chứng khoán không được trùng
            v_strSQL = "SELECT COUNT(*) FROM " & ATTR_TABLE & " WHERE RTRIM(CODEID) = '" & v_strCODEID & "' " _
                & "AND STATUS = 'Y' " _
                & "AND TOPRICE >= " & v_dblFromPrice.ToString() & " AND FROMPRICE <= " & v_dblFromPrice.ToString()
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 1 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_SA_SECTICKSIZE_DUPLICATE
                End If
            End If
            v_strSQL = "SELECT COUNT(*) FROM " & ATTR_TABLE & " WHERE RTRIM(CODEID) = '" & v_strCODEID & "' " _
                & "AND STATUS = 'Y' " _
                & "AND TOPRICE >= " & v_dblToPrice.ToString() & " AND FROMPRICE <= " & v_dblToPrice.ToString()
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 1 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_SA_SECTICKSIZE_DUPLICATE
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

    Overrides Function CheckBeforeEdit(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strCODEID, v_dblFromPrice, v_dblToPrice, v_strSymbol As String
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
                        Case "CODEID"
                            v_strCODEID = Trim(v_strVALUE)
                        Case "FROMPRICE"
                            v_dblFromPrice = CDbl(v_strVALUE.Trim())
                        Case "TOPRICE"
                            v_dblToPrice = CDbl(v_strVALUE.Trim())
                        Case "SYMBOL"
                            v_strSymbol = Trim(v_strVALUE.Trim())
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

            'Kiểm tra trường CODEID có tồn tại hay không
            If v_strCODEID.Length > 0 Then
                v_strSQL = "SELECT COUNT(CODEID) FROM SBSECURITIES WHERE CODEID = '" & v_strCODEID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count = 1 Then
                    If v_ds.Tables(0).Rows(0)(0) = 0 Then
                        Return ERR_SE_CODEID_NOTFOUND
                    End If
                End If
            End If
            'Kiểm tra trường Symbol có tồn tại hay không
            If v_strCODEID.Length > 0 Then
                v_strSQL = "SELECT COUNT(SYMBOL) FROM SBSECURITIES WHERE SYMBOL = '" & v_strSymbol & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count = 1 Then
                    If v_ds.Tables(0).Rows(0)(0) = 0 Then
                        Return ERR_SE_SYMBOL_NOTFOUND
                    End If
                End If
            End If
            'Kiểm tra khoảng giá tương ứng với mỗi chứng khoán không được trùng
            v_strSQL = "SELECT COUNT(*) FROM " & ATTR_TABLE & " WHERE RTRIM(CODEID) = '" & v_strCODEID & "' " _
                & "AND STATUS = 'Y' " _
                & "AND TOPRICE >= " & v_dblFromPrice.ToString() & " AND FROMPRICE <= " & v_dblFromPrice.ToString()
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 1 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_SA_SECTICKSIZE_DUPLICATE
                End If
            End If
            v_strSQL = "SELECT COUNT(*) FROM " & ATTR_TABLE & " WHERE RTRIM(CODEID) = '" & v_strCODEID & "' " _
                & "AND STATUS = 'Y' " _
                & "AND TOPRICE >= " & v_dblToPrice.ToString() & " AND FROMPRICE <= " & v_dblToPrice.ToString()
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 1 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_SA_SECTICKSIZE_DUPLICATE
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
