Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Public Class ICCFTYPESCHD
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "ICCFTYPESCHD"
    End Sub

    Overrides Function Adhoc(ByRef v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Try
            Dim v_obj As New DataAccess
            Dim v_strSQL, v_strAUTOID As String
            v_obj.NewDBInstance(gc_MODULE_HOST)

            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            If Not (v_attrColl.GetNamedItem(gc_AtributeOBJNAME) Is Nothing) Then
                v_strAUTOID = Trim(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)
            Else
                v_strAUTOID = String.Empty
            End If
            v_strSQL = "UPDATE ICCFTYPESCHD SET DELTD='Y' WHERE TRIM(AUTOID)='" & v_strAUTOID & "'"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

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
            Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE, v_strACTYPE, v_strEVENTCODE As String

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

            v_strSQL = "SELECT ACTYPE, MODCODE, EVENTCODE FROM " & ATTR_TABLE & " " _
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
                            Case "EVENTCODE"
                                v_strEVENTCODE = Trim(v_strVALUE)
                            Case "MODCODE"
                                v_strModCode = Trim(v_strVALUE)
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


            'Kiểm tra ràng buộc khi xoá. 
            v_strSQL = "DELETE FROM ICCFTIER WHERE MODCODE = '" & v_strModCode & "'" & ControlChars.CrLf _
            & " AND EVENTCODE = '" & v_strEVENTCODE & "' AND ACTYPE ='" & v_strACTYPE & "'"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            v_strSQL = "insert into iccftypeschdhist (autoid, modcode, actype, glacctno, eventcode," & _
                           " ruletype, monthday, yearday, period, periodday," & _
                           " ictype, icflat, icratecd, icrateid, icrate, minval," & _
                           " maxval, varrate, iccfstatus, deltd, operand, line," & _
                           " flrate, cerate, effectivedt, acname, expireddt)" & _
                           " select autoid, modcode, actype, glacctno, eventcode," & _
                           " ruletype, monthday, yearday, period, periodday," & _
                           " ictype, icflat, icratecd, icrateid, icrate, minval," & _
                           " maxval, varrate, iccfstatus, deltd, operand, line," & _
                           " flrate, cerate, effectivedt, acname, expireddt" & _
                           " FROM iccftypeschd where ACTYPE=" & v_strACTYPE & ""
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

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
        Dim v_dblFLRate, v_dblCERate, v_dblICRATE, v_dblProductRate As Double
        Dim v_strRateCD, v_strOperand As String
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strACTYPE, v_strEVENTCODE, v_strAUTOID As String

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
                        Case "EVENTCODE"
                            v_strEVENTCODE = Trim(v_strVALUE)
                        Case "MODCODE"
                            v_strModCode = Trim(v_strVALUE)
                        Case "FLRATE"
                            v_dblFLRate = CDbl(v_strVALUE)
                        Case "CERATE"
                            v_dblCERate = CDbl(v_strVALUE)
                        Case "ICRATECD"
                            v_strRateCD = Trim(v_strVALUE)
                        Case "ICRATE"
                            v_dblICRATE = CDbl(v_strVALUE)
                        Case "OPERAND"
                            v_strOperand = Trim(v_strVALUE)
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

            'Kiểm tra (EVENTCODE, ACTYPE, MODCODE) không được trùng
            If v_strEVENTCODE.Length > 0 Then
                v_strSQL = "SELECT COUNT(ACTYPE) FROM ICCFTYPESCHD WHERE ACTYPE ='" & v_strACTYPE & "' AND DELTD ='N'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count >= 1 Then
                    If v_ds.Tables(0).Rows(0)(0) > 0 Then
                        Return ERR_SA_ICCFTYPEDEF_DUPLICATED
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
        Dim v_strModCode As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strACTYPE, v_strEVENTCODE, v_strAUTOID As String

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
                        Case "EVENTCODE"
                            v_strEVENTCODE = Trim(v_strVALUE)
                        Case "MODCODE"
                            v_strModCode = Trim(v_strVALUE)
                        Case "AUTOID"
                            v_strAUTOID = Trim(v_strVALUE)

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

            'Kiểm tra (EVENTCODE, ACTYPE, MODCODE) không được trùng
            If v_strEVENTCODE.Length > 0 Then
                v_strSQL = "SELECT COUNT(ACTYPE) FROM ICCFTYPESCHD WHERE DELTD ='N' AND MODCODE = '" & v_strModCode & "'" & ControlChars.CrLf _
                 & " AND AUTOID <> '" & v_strAUTOID & "'AND EVENTCODE = '" & v_strEVENTCODE & "' AND ACTYPE ='" & v_strACTYPE & "'" ' AND DELTD ='N'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count >= 1 Then
                    If v_ds.Tables(0).Rows(0)(0) > 0 Then
                        Return ERR_SA_ICCFTYPEDEF_DUPLICATED
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

        Dim v_strObjMsg As String
        Dim v_strModCode As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strClause, v_strCurrentBdsid As String
            Dim v_strLocal As String
            Dim v_strSQL As String
            Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE, v_strACTYPE, v_strEVENTCODE As String

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

            v_strSQL = "SELECT ACTYPE, MODCODE, EVENTCODE FROM " & ATTR_TABLE & " " _
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
                            Case "EVENTCODE"
                                v_strEVENTCODE = Trim(v_strVALUE)
                            Case "MODCODE"
                                v_strModCode = Trim(v_strVALUE)
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
