Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Public Class CFCUSTODYCD
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    '--CUSTTYPE=R, MỘT EXCHANGE: duy nhất không ai dược sử dụng
    '--CUSTTYPE=N, MỘT EXCHANGE, MỘT KHÁCH HÀNG, MỘT AFTYPSUBCD CHỈ CÓ MỘT TÀI KHOẢN LƯU KÝ
    '--CUSTTYPE=F, MỘT EXCHANGE, MỘT KHÁCH HÀNG, MỘT TYPESUBCD CHỈ CÓ MỘT TÀI KHOẢN LƯU KÝ

    Public Sub New()
        ATTR_TABLE = "CFCUSTODYCD"
    End Sub

#Region " Overrides functions "
    Overrides Function CheckBeforeAdd(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strErrorSource As String = ATTR_TABLE & ".CheckBeforeAdd"
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strAUTOID, v_strCUSTID, v_strCUSTODYCD, v_strEXCHANGECD, v_strCUSTTYPE, v_strTYPESUBCD, v_strAFTYPSUBCD As String
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
                        Case "CUSTID"
                            v_strCUSTID = v_strVALUE
                        Case "CUSTODYCD"
                            v_strCUSTODYCD = v_strVALUE
                        Case "EXCHANGECD"
                            v_strEXCHANGECD = v_strVALUE
                        Case "EXCHANGECD"
                            v_strEXCHANGECD = v_strVALUE
                        Case "CUSTTYPE"
                            v_strCUSTTYPE = v_strVALUE
                        Case "TYPESUBCD"
                            v_strTYPESUBCD = v_strVALUE
                        Case "AFTYPSUBCD"
                            v_strAFTYPSUBCD = v_strVALUE
                    End Select
                End With
            Next

            Dim v_obj As New DataAccess
            If v_strLocal = "N" Then
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            'Số tài khoản không được trùng cho từng Exchange
            v_strSQL = "SELECT COUNT(AUTOID) FROM CFCUSTODYCD WHERE STATUS NOT IN ('C','R') " & _
                 "AND EXCHANGECD IN ('" & v_strEXCHANGECD & "','ALL') AND CUSTODYCD='" & v_strCUSTODYCD & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows(0)(0) > 0 Then
                Return ERR_CF_CUSTODYCD_REGISTERED    'Số tài khoản lưu ký đã được đăng ký
            End If

            If String.Compare(v_strCUSTTYPE, "F") = 0 Then
                'Nếu là số lưu ký dự trữ thì xác định duy nhất cho từng Exchange
                v_strSQL = "SELECT COUNT(AUTOID) FROM CFCUSTODYCD WHERE CUSTID='" & v_strCUSTID & "' AND TYPESUBCD='" & v_strTYPESUBCD & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_CF_CUSTODYCD_REGISTERED_TYPESUBCD    'Khai báo trùng loại khách hàng cho số lưu ký
                End If
            ElseIf String.Compare(v_strCUSTTYPE, "N") = 0 Then
                'Nếu là số lưu ký của khách hàng thường thì không được khai báo trùng loại tiểu khoản AFTYPSUBCD
                v_strSQL = "SELECT COUNT(AUTOID) FROM CFCUSTODYCD WHERE CUSTID='" & v_strCUSTID & "' AND AFTYPSUBCD IN ('" & v_strAFTYPSUBCD & "','A')"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_CF_CUSTODYCD_REGISTERED_AFTYPSUBCD    'Khai báo trùng loại tiểu khoản cho số lưu ký
                End If
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
            Dim v_strLocal, v_strAUTOID, v_strCUSTID, v_strCUSTODYCD, v_strEXCHANGECD, v_strCUSTTYPE, v_strTYPESUBCD, v_strAFTYPSUBCD As String
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
                        Case "CUSTID"
                            v_strCUSTID = v_strVALUE
                        Case "CUSTODYCD"
                            v_strCUSTODYCD = v_strVALUE
                        Case "EXCHANGECD"
                            v_strEXCHANGECD = v_strVALUE
                        Case "EXCHANGECD"
                            v_strEXCHANGECD = v_strVALUE
                        Case "CUSTTYPE"
                            v_strCUSTTYPE = v_strVALUE
                        Case "TYPESUBCD"
                            v_strTYPESUBCD = v_strVALUE
                        Case "AFTYPSUBCD"
                            v_strAFTYPSUBCD = v_strVALUE
                    End Select
                End With
            Next

            Dim v_obj As New DataAccess
            If v_strLocal = "N" Then
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            'Số tài khoản không được trùng cho từng Exchange
            v_strSQL = "SELECT COUNT(AUTOID) FROM CFCUSTODYCD WHERE STATUS NOT IN ('C','R') " &
                 "AND EXCHANGECD IN ('" & v_strEXCHANGECD & "','ALL') AND CUSTODYCD='" & v_strCUSTODYCD & "' AND AUTOID<>" & v_strAUTOID
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows(0)(0) > 0 Then
                Return ERR_CF_CUSTODYCD_REGISTERED    'Số tài khoản lưu ký đã được đăng ký
            End If

            If String.Compare(v_strCUSTTYPE, "F") = 0 Then
                'Nếu là số lưu ký dự trữ thì xác định duy nhất cho từng Exchange
                v_strSQL = "SELECT COUNT(AUTOID) FROM CFCUSTODYCD WHERE CUSTID='" & v_strCUSTID & "' AND TYPESUBCD='" & v_strTYPESUBCD & "' AND AUTOID<>" & v_strAUTOID
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_CF_CUSTODYCD_REGISTERED_TYPESUBCD    'Khai báo trùng loại khách hàng cho số lưu ký
                End If
            ElseIf String.Compare(v_strCUSTTYPE, "N") = 0 Then
                'Nếu là số lưu ký của khách hàng thường thì không được khai báo trùng loại tiểu khoản AFTYPSUBCD
                v_strSQL = "SELECT COUNT(AUTOID) FROM CFCUSTODYCD WHERE CUSTID='" & v_strCUSTID & "' AND AFTYPSUBCD IN ('" & v_strAFTYPSUBCD & "','A')  AND AUTOID<>" & v_strAUTOID
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_CF_CUSTODYCD_REGISTERED_AFTYPSUBCD    'Khai báo trùng loại tiểu khoản cho số lưu ký
                End If
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


            'Tài khoản lưu ký đã map vào sub-account rồi thì không được xóa
            v_strSQL = "SELECT COUNT(AUTOID) FROM CFAFCUSTODYCD WHERE CUSTODYCDID=" & v_strClause
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