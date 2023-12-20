Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Public Class STCSE
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "STCSE"
    End Sub

    Overrides Function Adhoc(ByRef v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Try
            Dim v_obj As New DataAccess
            Dim v_strSQL, v_strSTCNAME As String
            v_obj.NewDBInstance(gc_MODULE_HOST)

            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            If Not (v_attrColl.GetNamedItem(gc_AtributeOBJNAME) Is Nothing) Then
                v_strSTCNAME = Trim(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)
            Else
                v_strSTCNAME = String.Empty
            End If
            v_strSQL = "DELETE FROM STCTICKSIZE WHERE STCNAME = '" & v_strSTCNAME & "'"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#Region " Overrides functions "
    Overrides Function CheckBeforeAdd(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_strObjMsg As String
        Dim v_strModCode As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strTRADEPLACE, v_strSECTYPE, v_strNORP, v_strCLEARCD, v_strSTCNAME As String
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
                        Case "TRADEPLACE"
                            v_strTRADEPLACE = Trim(v_strVALUE)
                        Case "SECTYPE"
                            v_strSECTYPE = Trim(v_strVALUE)
                        Case "NORP"
                            v_strNORP = Trim(v_strVALUE)
                        Case "CLEARCD"
                            v_strCLEARCD = Trim(v_strVALUE)
                        Case "STCNAME"
                            v_strSTCNAME = Trim(v_strVALUE)
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

            'Kiem tra STCNAME khong duoc trung
            v_strSQL = "SELECT COUNT(STCNAME) FROM STCSE WHERE STCNAME = '" & v_strSTCNAME & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 1 Then
                If v_ds.Tables(0).Rows(0)(0) <> 0 Then
                    Return ERR_SA_STCSE_DUPLICATED
                End If
            End If

            'Kiểm tra TRADEPLACE,SECTYPE,NORP,CLEARCD không được trùng
            v_strSQL = "SELECT COUNT(TRADEPLACE) FROM STCSE WHERE TRADEPLACE = '" & v_strTRADEPLACE & "' AND SECTYPE = '" & v_strSECTYPE & "' AND NORP = '" & v_strNORP & "' AND CLEARCD ='" & v_strCLEARCD & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 1 Then
                If v_ds.Tables(0).Rows(0)(0) <> 0 Then
                    Return ERR_SA_STCSE_DUPLICATED
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
