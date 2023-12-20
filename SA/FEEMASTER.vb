Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Public Class FEEMASTER
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "FEEMASTER"
    End Sub

#Region " Overrides functions "
    Overrides Function CheckBeforeAdd(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strFEECD, v_strGLACCTNO, v_strREFCODE, v_strSUBTYPE, v_strsSTATUS As String
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
                        Case "FEECD"
                            v_strFEECD = Trim(v_strVALUE)
                        Case "GLACCTNO"
                            v_strGLACCTNO = Trim(v_strVALUE)
						Case "REFCODE"
                            v_strREFCODE = Trim(v_strVALUE)
                        Case "SUBTYPE"
                            v_strSUBTYPE = Trim(v_strVALUE)
                        Case "STATUS"
                            v_strsSTATUS = Trim(v_strVALUE)
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

            'Kiểm tra FEECD không được trùng
            v_strSQL = "SELECT COUNT(FEECD) FROM " & ATTR_TABLE & " WHERE FEECD = '" & v_strFEECD & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 1 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_SA_FEEMASTER_DUPLICATED
                End If
            End If

            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If

            If v_strGLACCTNO.Length > 0 Then
                'Kiem tra ma tai khoan ke toan
                v_strSQL = "SELECT SUBSTR(ACCTNO,5) ACCTNO FROM GLMAST WHERE SUBSTR(ACCTNO,5) = '" & v_strGLACCTNO.Substring(4) & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count <= 0 Then
                    Return ERR_SA_GLACCTNO_NOTFOUND
                End If

                If Not (v_ds Is Nothing) Then
                    v_ds.Dispose()
                End If

                Dim v_strBranchID As String = v_strGLACCTNO.Substring(0, 4)
                If v_strBranchID <> "####" And v_strBranchID <> "____" Then
                    v_strSQL = "SELECT SUBSTR(ACCTNO,0,4) ACCTNO FROM GLMAST WHERE SUBSTR(ACCTNO,0,4) = '" & v_strBranchID & "'"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count <= 0 Then
                        Return gc_ERR_SA_BRID_NOTFOUND
                    End If

                    If Not (v_ds Is Nothing) Then
                        v_ds.Dispose()
                    End If
                End If
            End If
			
			'Kiểm tra không được trùng subtype co status = 'Y'
            v_strSQL = "SELECT COUNT(FEECD) FROM " & ATTR_TABLE & " WHERE REFCODE = '" & v_strREFCODE & "' AND SUBTYPE = '" & v_strSUBTYPE & "' AND STATUS = 'Y'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 1 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_SA_FEEMASTER_SUBTYPEDUPLICATED
                End If
            End If

            'ContextUtil.SetComplete()
            Return 0
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Overrides Function CheckBeforeDelete(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strClause, v_strFEECD, v_strGLACCTNO As String
            Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String
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

            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            'Kiểm tra FEECD không được phep khai bao map vao giao dich nao
            v_strSQL = "SELECT COUNT(FEECD) FROM FEEMAP WHERE 0 = 0 AND " & v_strClause
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 1 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_SA_FEEMASTER_ALREADYMAP
                End If
            End If

            'Kiểm tra FEECD không được phep khai bao bieu phi bac thang
            v_strSQL = "SELECT COUNT(FEECD) FROM FEETIER WHERE 0 = 0 AND " & v_strClause
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 1 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_SA_FEEMASTER_ALREADYTIER
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
            Dim v_strLocal, v_strFEECD, v_strGLACCTNO, v_strREFCODE, v_strSUBTYPE, v_strsSTATUS As String
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
                        Case "FEECD"
                            v_strFEECD = Trim(v_strVALUE)
                        Case "GLACCTNO"
                            v_strGLACCTNO = Trim(v_strVALUE)
                        Case "REFCODE"
                            v_strREFCODE = Trim(v_strVALUE)
                        Case "SUBTYPE"
                            v_strSUBTYPE = Trim(v_strVALUE)
                        Case "STATUS"
                            v_strsSTATUS = Trim(v_strVALUE)
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

            If v_strGLACCTNO.Length > 0 Then
                'Kiem tra ma tai khoan ke toan
                v_strSQL = "SELECT SUBSTR(ACCTNO,5) ACCTNO FROM GLMAST WHERE SUBSTR(ACCTNO,5) = '" & v_strGLACCTNO.Substring(4) & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count <= 0 Then
                    Return ERR_SA_GLACCTNO_NOTFOUND
                End If

                If Not (v_ds Is Nothing) Then
                    v_ds.Dispose()
                End If

                Dim v_strBranchID As String = v_strGLACCTNO.Substring(0, 4)
                If v_strBranchID <> "####" And v_strBranchID <> "____" Then
                    v_strSQL = "SELECT SUBSTR(ACCTNO,0,4) ACCTNO FROM GLMAST WHERE SUBSTR(ACCTNO,0,4) = '" & v_strBranchID & "'"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count <= 0 Then
                        Return gc_ERR_SA_BRID_NOTFOUND
                    End If

                    If Not (v_ds Is Nothing) Then
                        v_ds.Dispose()
                    End If
                End If
            End If

            'Kiểm tra không được trùng subtype co status = 'Y'
            v_strSQL = "SELECT COUNT(FEECD) FROM " & ATTR_TABLE & " WHERE REFCODE = '" & v_strREFCODE & "' AND SUBTYPE = '" & v_strSUBTYPE & "' AND STATUS = 'Y' AND FEECD <> '" & v_strFEECD & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 1 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_SA_FEEMASTER_SUBTYPEDUPLICATED
                End If
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
