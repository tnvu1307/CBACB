Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Public Class IRRATESCHD
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "IRRATESCHD"
    End Sub

#Region " Overrides functions "
    Overrides Function CheckBeforeAdd(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strRateID, v_strCCYCD, v_strRATE, v_strFLRRATE, v_strCELRATE As String
            Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE, v_strEFFECTIVEDT As String
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
                        Case "RATEID"
                            v_strRateID = Trim(v_strVALUE)
                        Case "CCYCD"
                            v_strCCYCD = Trim(v_strVALUE)
                        Case "RATE"
                            v_strRATE = Trim(v_strVALUE)
                        Case "FLRRATE"
                            v_strFLRRATE = Trim(v_strVALUE)
                        Case "CELRATE"
                            v_strCELRATE = Trim(v_strVALUE)
                        Case "EFFECTIVEDT"
                            v_strEFFECTIVEDT = Trim(v_strVALUE)
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

            'kiểm tra không được add trùng nếu ngày effective đã có schedule cho RateID này
            v_strSQL = "SELECT RATEID FROM " & ATTR_TABLE & " WHERE RATEID = '" & v_strRateID & "' AND EFFECTIVEDT = to_date('" & v_strEFFECTIVEDT & "','dd/mm/yyyy') "
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 1 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_LN_IRRATEID_DUPLICATED
                End If
            End If

            'ContextUtil.SetComplete()
            Return ERR_SYSTEM_OK
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, "EventLogEntryType.Error")
            Throw ex
        End Try

    End Function

#End Region


End Class
