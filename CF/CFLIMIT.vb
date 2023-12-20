Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data

Public Class CFLIMIT
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "CFLIMIT"
    End Sub

    Overrides Function CheckBeforeAdd(ByVal v_strMessage As String) As Long
        Dim v_obj As New DataAccess
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        ' Return 0
        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strBANKID, v_strCUSTID, v_strLMTYP, v_strLMSUBTYPE As String
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
                        Case "BANKID"
                            v_strBANKID = Trim(v_strVALUE)
                        Case "CUSTID"
                            v_strCUSTID = Trim(v_strVALUE)
                        Case "LMTYP"
                            v_strLMTYP = Trim(v_strVALUE)
                        Case "LMSUBTYPE"
                            v_strLMSUBTYPE = Trim(v_strVALUE)
                    End Select
                End With
            Next

            v_obj.NewDBInstance(gc_MODULE_HOST)
            'Cùng một BankID không được trùng LMTYP * LMSUBTYPE
            v_strSQL = "SELECT COUNT(ROWNUM) FROM " & ATTR_TABLE & " WHERE BANKID='" & v_strBANKID & "' AND LMTYP='" & v_strLMTYP & "' AND LMSUBTYPE='" & v_strLMSUBTYPE & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If gf_CorrectNumericField(v_ds.Tables(0).Rows(0)(0)) > 0 Then
                Return ERR_SA_FIELD_DUPLICATED
            End If

            v_strSQL = "SELECT COUNT(1) EXISTSVAL FROM CFMAST WHERE ISBANKING='Y' and custid = '" & v_strBANKID & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If Not gf_CorrectNumericField(v_ds.Tables(0).Rows(0)(0)) > 0 Then
                Return ERR_CF_CUSTOMER_NOTBANKING
            End If

            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If

            Return 0
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        Finally
            v_obj = Nothing
        End Try

    End Function
End Class
