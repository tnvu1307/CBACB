Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Public Class ICCFTYPESCHDMAP
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "ICCFTYPESCHDMAP"
    End Sub


#Region " Overrides functions "


    Overrides Function SystemProcessBeforeDelete(ByRef v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_strObjMsg As String
        Dim v_strModCode As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strClause, v_strCurrentBdsid As String
            Dim v_strLocal As String
            Dim v_strSQL As String
            Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE, v_strACTYPE, v_strAUTOID, v_strREFID As String

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
                v_strCurrentBdsid = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeBRID), Xml.XmlAttribute).Value)
            Else
                v_strCurrentBdsid = String.Empty
            End If

            v_strSQL = "SELECT * FROM " & ATTR_TABLE & " " _
                & "WHERE 0=0 AND " & v_strClause
            v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, , gc_ActionInquiry, v_strSQL)
            Dim v_xmlDocument As New XmlDocumentEx
            If (Inquiry(v_strObjMsg) = ERR_SYSTEM_OK) Then
                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                    With v_nodeList.Item(0).ChildNodes(i)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strVALUE = .InnerText.ToString()

                        Select Case Trim(v_strFLDNAME)
                            Case "REFID"
                                v_strREFID = Trim(v_strVALUE)
                            Case "AUTOID"
                                v_strAUTOID = Trim(v_strVALUE)
                            Case "ACTYPE"
                                v_strACTYPE = Trim(v_strVALUE)
                        End Select
                    End With
                Next
            End If

            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
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


    Overrides Function CheckBeforeAdd(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_strObjMsg As String
        Dim v_strModCode As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strACTYPE, v_strREFID, v_strAUTOID, v_strEFFECTIVEDT, v_strEXPIREDDT As String

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
                        Case "ACTYPE"
                            v_strACTYPE = Trim(v_strVALUE)
                        Case "AUTOID"
                            v_strAUTOID = Trim(v_strVALUE)
                        Case "REFID"
                            v_strREFID = Trim(v_strVALUE)
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
            'Kiem tra mot loai hinh va mot lich khong duoc gan 2 lan
            v_strSQL = "SELECT COUNT(ACTYPE) FROM ICCFTYPESCHDMAP WHERE ACTYPE ='" & v_strACTYPE & "' AND REFID=" & v_strREFID & ""
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count >= 1 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_SA_ICCFTYPEDEF_DUPLICATED
                End If
            End If
            'Kiem tra mot loai hinh khong duoc gan 2 dong lich trung khoang thoi gian
            v_strSQL = "SELECT to_char(EXPIREDDT,'DD/MM/RRRR') EXPIREDDT,to_char(EFFECTIVEDT,'DD/MM/RRRR') EFFECTIVEDT FROM ICCFTYPESCHD DEF WHERE AUTOID ='" & v_strREFID & "' "
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            v_strEFFECTIVEDT = v_ds.Tables(0).Rows(0)("EFFECTIVEDT")
            v_strEXPIREDDT = v_ds.Tables(0).Rows(0)("EXPIREDDT")


            v_strSQL = "SELECT COUNT(map.ACTYPE) FROM ICCFTYPESCHDMAP MAP, ICCFTYPEschd DEF WHERE MAP.ACTYPE ='" & v_strACTYPE & "' " &
                        "and map.refid = def.autoid and ((DEF.effectivedt <= to_date('" & v_strEFFECTIVEDT & "','DD/MM/RRRR') and DEF.expireddt > to_date('" & v_strEFFECTIVEDT & "','DD/MM/RRRR')) or (DEF.effectivedt>=to_date('" & v_strEFFECTIVEDT & "','DD/MM/RRRR') and DEF.effectivedt < to_date('" & v_strEXPIREDDT & "','DD/MM/RRRR')))"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count >= 1 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_SA_ICCFSCHD_NESTED
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
        Dim v_strModCode As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strACTYPE, v_strREFID, v_strAUTOID, v_strEFFECTIVEDT, v_strEXPIREDDT As String

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
                        Case "ACTYPE"
                            v_strACTYPE = Trim(v_strVALUE)
                        Case "AUTOID"
                            v_strAUTOID = Trim(v_strVALUE)
                        Case "REFID"
                            v_strREFID = Trim(v_strVALUE)
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

            'Kiem tra mot loai hinh va mot lich khong duoc gan 2 lan
            v_strSQL = "SELECT COUNT(ACTYPE) FROM ICCFTYPESCHDMAP WHERE ACTYPE ='" & v_strACTYPE & "' AND REFID=" & v_strREFID & " AND AUTOID <> " & v_strAUTOID & ""
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count >= 1 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_SA_ICCFTYPEDEF_DUPLICATED
                End If
            End If
            'Kiem tra mot loai hinh khong duoc gan 2 dong lich trung khoang thoi gian
            v_strSQL = "SELECT to_char(EXPIREDDT,'DD/MM/RRRR') EXPIREDDT,to_char(EFFECTIVEDT,'DD/MM/RRRR') EFFECTIVEDT FROM ICCFTYPESCHD DEF WHERE AUTOID ='" & v_strREFID & "' "
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            v_strEFFECTIVEDT = v_ds.Tables(0).Rows(0)("EFFECTIVEDT")
            v_strEXPIREDDT = v_ds.Tables(0).Rows(0)("EXPIREDDT")


            v_strSQL = "SELECT COUNT(map.ACTYPE) FROM ICCFTYPESCHDMAP MAP, ICCFTYPEschd DEF WHERE MAP.ACTYPE ='" & v_strACTYPE & "' " &
                        "and map.refid = def.autoid and ((DEF.effectivedt <= to_date('" & v_strEFFECTIVEDT & "','DD/MM/RRRR') and DEF.expireddt > to_date('" & v_strEFFECTIVEDT & "','DD/MM/RRRR')) or (DEF.effectivedt>=to_date('" & v_strEFFECTIVEDT & "','DD/MM/RRRR') and DEF.effectivedt < to_date('" & v_strEXPIREDDT & "','DD/MM/RRRR'))) AND MAP.AUTOID <> " & v_strAUTOID & ""
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count >= 1 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_SA_ICCFSCHD_NESTED
                End If
            End If
            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
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

        Dim v_strObjMsg As String
        Dim v_strModCode As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strClause, v_strCurrentBdsid As String
            Dim v_strLocal As String
            Dim v_strSQL As String
            Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE, v_strACTYPE, v_strREFID, v_strAUTOID As String

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
                v_strCurrentBdsid = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeBRID), Xml.XmlAttribute).Value)
            Else
                v_strCurrentBdsid = String.Empty
            End If

            v_strSQL = "SELECT * FROM " & ATTR_TABLE & " " _
                & "WHERE 0=0 AND " & v_strClause
            v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, , gc_ActionInquiry, v_strSQL)
            Dim v_xmlDocument As New XmlDocumentEx
            If (Inquiry(v_strObjMsg) = ERR_SYSTEM_OK) Then
                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                    With v_nodeList.Item(0).ChildNodes(i)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strVALUE = .InnerText.ToString()

                        Select Case Trim(v_strFLDNAME)
                            Case "ACTYPE"
                                v_strACTYPE = Trim(v_strVALUE)
                            Case "AUTOID"
                                v_strAUTOID = Trim(v_strVALUE)
                            Case "REFID"
                                v_strREFID = Trim(v_strVALUE)
                        End Select
                    End With
                Next
            End If

            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            'BO DOAN CHECK NAY VI HIEN TAI CHI CHECK THEO LOAI HINH, KHONG CHECK THEO SU KIEN.

            'Kiểm tra ràng buộc khi xoá. 
            'v_strSQL = "SELECT COUNT(ACTYPE) FROM ICCFTIER WHERE DELTD = 'N' AND MODCODE = '" & v_strModCode & "'" & ControlChars.CrLf _
            '& " AND EVENTCODE = '" & v_strEVENTCODE & "' AND ACTYPE ='" & v_strACTYPE & "'"
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'If v_ds.Tables(0).Rows.Count >= 1 Then
            '    If v_ds.Tables(0).Rows(0)(0) > 0 Then
            '        Return ERR_SE_ACTYPE_CONSTRAINTS
            '    End If
            'End If


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
