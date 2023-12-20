Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Public Class FA
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "FA"
    End Sub

#Region " Overrides functions "
    Overrides Function CheckBeforeAdd(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strACCTNO, v_strBRID, v_strCCYCD, v_strCRGLDEPRAC, v_strDRGLEXPAC As String
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
                        Case "ACCTNO"
                            v_strACCTNO = Trim(v_strVALUE)
                        Case "BRID"
                            v_strBRID = Trim(v_strVALUE)
                        Case "CCYCD"
                            v_strCCYCD = Trim(v_strVALUE)
                        Case "CRGLDEPRAC"
                            v_strCRGLDEPRAC = Trim(v_strVALUE)
                        Case "DRGLEXPAC"
                            v_strDRGLEXPAC = Trim(v_strVALUE)
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

            'Kiểm tra ACCTNO không được trùng
            v_strSQL = "SELECT COUNT(ACCTNO) FROM " & ATTR_TABLE & " WHERE ACCTNO = '" & v_strACCTNO & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 1 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return gc_ERRCODE_GL_ACCTNO_DUPLICATED
                End If
            End If
            'Kiểm tra BRID phải tồn tại
            If v_strBRID.Length > 0 Then
                v_strSQL = "SELECT COUNT(BRID) FROM BRGRP WHERE BRID = '" & v_strBRID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count = 1 Then
                    If v_ds.Tables(0).Rows(0)(0) = 0 Then
                        Return gc_ERR_SA_BRID_NOTFOUND
                    End If
                End If
            End If
            'Kiểm tra CCYCD phải tồn tại
            If v_strCCYCD.Length > 0 Then
                v_strSQL = "SELECT COUNT(CCYCD) FROM SBCURRENCY WHERE CCYCD = '" & v_strCCYCD & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count = 1 Then
                    If v_ds.Tables(0).Rows(0)(0) = 0 Then
                        Return ERR_SA_CCYCD_NOTFOUND
                    End If
                End If
            End If
            'Kiểm tra CRGLDEPRAC phải tồn tại
            If v_strCRGLDEPRAC.Length > 0 Then
                v_strSQL = "SELECT COUNT(ACCTNO) FROM GLMAST WHERE ACCTNO = '" & v_strCRGLDEPRAC & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count = 1 Then
                    If v_ds.Tables(0).Rows(0)(0) = 0 Then
                        Return gc_ERRCODE_GL_CRGLDEPR_ACCTNO_DOESNOTEXIST
                    End If
                End If
            End If
            'Kiểm tra DRGLEXPAC phải tồn tại
            If v_strCCYCD.Length > 0 Then
                v_strSQL = "SELECT COUNT(ACCTNO) FROM GLMAST WHERE ACCTNO = '" & v_strDRGLEXPAC & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count = 1 Then
                    If v_ds.Tables(0).Rows(0)(0) = 0 Then
                        Return gc_ERRCODE_GL_DRGLEXP_ACCTNO_DOESNOTEXIST
                    End If
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
            Dim v_strLocal, v_strACCTNO, v_strBRID, v_strCCYCD, v_strCRGLDEPRAC, v_strDRGLEXPAC As String
            Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE, v_strAUTOID As String
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
                        Case "ACCTNO"
                            v_strACCTNO = Trim(v_strVALUE)
                        Case "BRID"
                            v_strBRID = Trim(v_strVALUE)
                        Case "CCYCD"
                            v_strCCYCD = Trim(v_strVALUE)
                        Case "AUTOID"
                            v_strAUTOID = Trim(v_strVALUE)
                        Case "CRGLDEPRAC"
                            v_strCRGLDEPRAC = Trim(v_strVALUE)
                        Case "DRGLEXPAC"
                            v_strDRGLEXPAC = Trim(v_strVALUE)
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
            'Kiểm tra ACCTNO không được trùng
            v_strSQL = "SELECT COUNT(ACCTNO) FROM " & ATTR_TABLE & " WHERE AUTOID <> '" & v_strAUTOID & "' AND ACCTNO = '" & v_strACCTNO & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 1 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return gc_ERRCODE_GL_ACCTNO_DUPLICATED
                End If
            End If
            'Kiểm tra BRID phải tồn tại
            If v_strBRID.Length > 0 Then
                v_strSQL = "SELECT COUNT(BRID) FROM BRGRP WHERE BRID = '" & v_strBRID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count = 1 Then
                    If v_ds.Tables(0).Rows(0)(0) = 0 Then
                        Return gc_ERR_SA_BRID_NOTFOUND
                    End If
                End If
            End If
            'Kiểm tra CCYCD phải tồn tại
            If v_strCCYCD.Length > 0 Then
                v_strSQL = "SELECT COUNT(CCYCD) FROM SBCURRENCY WHERE CCYCD = '" & v_strCCYCD & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count = 1 Then
                    If v_ds.Tables(0).Rows(0)(0) = 0 Then
                        Return ERR_SA_CCYCD_NOTFOUND
                    End If
                End If
            End If
            'Kiểm tra CRGLDEPRAC phải tồn tại
            If v_strCRGLDEPRAC.Length > 0 Then
                v_strSQL = "SELECT COUNT(ACCTNO) FROM GLMAST WHERE ACCTNO = '" & v_strCRGLDEPRAC & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count = 1 Then
                    If v_ds.Tables(0).Rows(0)(0) = 0 Then
                        Return gc_ERRCODE_GL_CRGLDEPR_ACCTNO_DOESNOTEXIST
                    End If
                End If
            End If
            'Kiểm tra DRGLEXPAC phải tồn tại
            If v_strCCYCD.Length > 0 Then
                v_strSQL = "SELECT COUNT(ACCTNO) FROM GLMAST WHERE ACCTNO = '" & v_strDRGLEXPAC & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count = 1 Then
                    If v_ds.Tables(0).Rows(0)(0) = 0 Then
                        Return gc_ERRCODE_GL_DRGLEXP_ACCTNO_DOESNOTEXIST
                    End If
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

    Overrides Function CheckBeforeDelete(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        'ContextUtil.SetComplete()
        Return ERR_SYSTEM_OK
    End Function
#End Region

End Class
