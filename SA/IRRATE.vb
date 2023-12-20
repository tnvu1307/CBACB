Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Public Class IRRATE
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "IRRATE"
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

            'kiểm tra RATEID không được trùng
            v_strSQL = "SELECT COUNT(RATEID) FROM " & ATTR_TABLE & " WHERE RATEID = '" & v_strRateID & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 1 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_LN_IRRATEID_DUPLICATED
                End If
            End If

            'Trường Effective Date không được nhỏ hơn ngày hiện tại
            v_strSQL = "SELECT VARVALUE  FROM SYSVAR WHERE VARNAME = 'CURRDATE'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If Not v_strEFFECTIVEDT Is Nothing Then
                If DDMMYYYY_SystemDate(v_ds.Tables(0).Rows(0)("VARVALUE")) > DDMMYYYY_SystemDate(v_strEFFECTIVEDT) Then
                    Return ERR_SA_CURRDATE_SMALLER_THAN_EFFECTIVEDT
                End If
            End If

            'Kiểm tra CCYCD phải tồn tại
            If v_strCCYCD.Length > 0 Then
                v_strSQL = "SELECT COUNT(CCYCD) FROM SBCURRENCY WHERE CCYCD = '" & v_strCCYCD & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count = 1 Then
                    If v_ds.Tables(0).Rows(0)(0) = 0 Then
                        Return ERR_LN_CCYCD_NOTFOUND
                    End If
                End If
            End If

            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If

            'ContextUtil.SetComplete()
            Return ERR_SYSTEM_OK
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
            Dim v_strLocal, v_strCCYCD, v_strRATE, v_strFLRRATE, v_strCELRATE As String
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
                        Case "RATE"
                            v_strRATE = Trim(v_strVALUE)
                        Case "CCYCD"
                            v_strCCYCD = Trim(v_strVALUE)
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

            'Kiểm tra CCYCD phải tồn tại
            If v_strCCYCD.Length > 0 Then
                v_strSQL = "SELECT COUNT(CCYCD) FROM SBCURRENCY WHERE CCYCD = '" & v_strCCYCD & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count = 1 Then
                    If v_ds.Tables(0).Rows(0)(0) = 0 Then
                        Return ERR_LN_CCYCD_NOTFOUND
                    End If
                End If
            End If

            'Trường Effective Date không được nhỏ hơn ngày hiện tại
            v_strSQL = "SELECT VARVALUE  FROM SYSVAR WHERE VARNAME = 'CURRDATE'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If Not v_strEFFECTIVEDT Is Nothing Then
                If DDMMYYYY_SystemDate(v_ds.Tables(0).Rows(0)("VARVALUE")) > DDMMYYYY_SystemDate(v_strEFFECTIVEDT) Then
                    Return ERR_SA_CURRDATE_SMALLER_THAN_EFFECTIVEDT
                End If
            End If

            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If

            'ContextUtil.SetComplete()
            Return ERR_SYSTEM_OK
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

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strClause, v_strRateID As String
            Dim v_strLocal As String
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
            If Not (v_attrColl.GetNamedItem(gc_AtributeBRID) Is Nothing) Then
                v_strRateID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeBRID), Xml.XmlAttribute).Value)
            Else
                v_strRateID = String.Empty
            End If

            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            'Không cho phép xoá nếu còn dữ liệu trong bảng LNType
            If v_strRateID <> String.Empty Then
                v_strSQL = "SELECT COUNT(ACTYPE) FROM CITYPE WHERE 0=0 AND " & v_strClause

                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count = 1 Then
                    If v_ds.Tables(0).Rows(0)(0) > 0 Then
                        Return ERR_LN_RATEID_CONSTRAINTS
                    End If
                End If
            End If
            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If

            'ContextUtil.SetComplete()
            Return ERR_SYSTEM_OK

        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try

    End Function
#End Region

End Class
