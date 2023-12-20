Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Public Class CFAFCUSTODYCD
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    'Một sub-account AFMAST và một exchange chỉ có 01 số tài khoản lưu ký

    Public Sub New()
        ATTR_TABLE = "CFAFCUSTODYCD"
    End Sub

#Region " Overrides functions "
    Overrides Function CheckBeforeAdd(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strErrorSource As String = ATTR_TABLE & ".CheckBeforeAdd"
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strAUTOID, v_strAFACCTNO, v_strCUSTODYCDID As String
            Dim v_strSQL, v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String
            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If

            'Xác định các biến
            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strVALUE = .InnerText.ToString().Trim

                    Select Case Trim(v_strFLDNAME)
                        Case "AUTOID"
                            v_strAUTOID = v_strVALUE
                        Case "AFACCTNO"
                            v_strAFACCTNO = v_strVALUE
                        Case "CUSTODYCDID"
                            v_strCUSTODYCDID = v_strVALUE
                    End Select
                End With
            Next

            Dim v_obj As New DataAccess
            If v_strLocal = "N" Then
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            'Một sub-account, một exchange chỉ có một số lưu ký
            v_strSQL = "SELECT COUNT(MST.AUTOID) FROM CFCUSTODYCD RF, CFCUSTODYCD MST, CFAFCUSTODYCD DTL WHERE MST.AUTOID=DTL.CUSTODYCDID " & _
                 " AND DTL.AFACCTNO='" & v_strAFACCTNO & "' AND RF.AUTOID=" & v_strCUSTODYCDID & _
                 " AND (CASE WHEN MST.EXCHANGECD='ALL' THEN RF.EXCHANGECD ELSE DECODE(MST.EXCHANGECD,'ALL','ALL',MST.EXCHANGECD) END) <> RF.EXCHANGECD"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows(0)(0) > 0 Then
                Return ERR_CF_CUSTODYCD_ALREADY_MAP2AFMAST    'Số tài khoản lưu ký đã được đăng ký
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

    Overrides Function CheckBeforeEdit(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strErrorSource As String = ATTR_TABLE & ".CheckBeforeEdit"
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strAUTOID, v_strAFACCTNO, v_strCUSTODYCDID As String
            Dim v_strSQL, v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String
            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If

            'Xác định các biến
            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strVALUE = .InnerText.ToString().Trim

                    Select Case Trim(v_strFLDNAME)
                        Case "AUTOID"
                            v_strAUTOID = v_strVALUE
                        Case "AFACCTNO"
                            v_strAFACCTNO = v_strVALUE
                        Case "CUSTODYCDID"
                            v_strCUSTODYCDID = v_strVALUE
                    End Select
                End With
            Next

            Dim v_obj As New DataAccess
            If v_strLocal = "N" Then
                v_obj.NewDBInstance(gc_MODULE_HOST)
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
        Dim v_strErrorSource As String = ATTR_TABLE & ".CheckBeforeDelete"
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strClause, v_strLocal, v_strSQL As String

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

            Dim v_obj As New DataAccess
            If v_strLocal = "N" Then
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If


            'Tài khoản lưu ký đã map vào sub-account rồi chỉ xóa nếu chưa có lệnh
            v_strSQL = "SELECT COUNT(VAL) FROM (SELECT MST.ORDERID VAL FROM ODMAST MST, CFAFCUSTODYCD DTL WHERE MST.AFACCTNO=DTL.AFACCTNO AND DTL." & v_strClause &
                " UNION ALL SELECT MST.ORDERID VAL FROM ODMASTHIST MST, CFAFCUSTODYCD DTL WHERE MST.AFACCTNO=DTL.AFACCTNO AND DTL." & v_strClause & ")"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows(0)(0) > 0 Then
                Return ERR_CF_CUSTODYCD_ALREADY_MAP2AFMAST    'Số tài khoản lưu ký đã được đăng ký
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