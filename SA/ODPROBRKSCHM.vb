Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Public Class ODPROBRKSCHM
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "ODPROBRKSCHM"
    End Sub

#Region " Overrides functions "
    Overrides Function CheckBeforeAdd(ByVal v_strMessage As String) As Long
        Dim v_strErrorSource, v_strErrorMessage As String
        v_strErrorSource = Me.ATTR_TABLE + ".CheckBeforeAdd"
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_ds As New DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strAUTOID, v_strACTYPE As String, v_dblFRAMT, v_dblTOAMT, v_dblFRTERM, v_dblTOTERM As Double
            Dim v_strSQL, v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String

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
                        Case "REFAUTOID"
                            v_strAUTOID = v_strVALUE.Trim
                        Case "FULLNAME"
                            v_strACTYPE = v_strVALUE.Trim
                        Case "FRAMT"
                            v_dblFRAMT = CDbl(v_strVALUE)
                        Case "TOAMT"
                            v_dblTOAMT = CDbl(v_strVALUE)
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
            Dim v_lnResult As Long
            v_strSQL = "SELECT AUTOID, REFAUTOID, FRAMT, TOAMT, VALAMT  FROM ODPROBRKSCHM WHERE REFAUTOID='" & v_strAUTOID & "' ORDER BY FRAMT"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            v_lnResult = chkAddTier(v_ds, v_dblFRAMT, v_dblTOAMT)
            If v_lnResult <> 0 Then
                Return v_lnResult
            End If


            Return ERR_SYSTEM_OK
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Overrides Function CheckBeforeEdit(ByVal v_strMessage As String) As Long
        Dim v_strErrorSource, v_strErrorMessage As String
        v_strErrorSource = Me.ATTR_TABLE + ".CheckBeforeEdit"
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_ds As New DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strAUTOID, v_strREFAUTOID, v_strACTYPE As String, v_dblFRAMT, v_dblTOAMT, v_dblFRTERM, v_dblTOTERM As Double
            Dim v_strSQL, v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String

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
                        Case "AUTOID"
                            v_strAUTOID = v_strVALUE.Trim
                        Case "REFAUTOID"
                            v_strREFAUTOID = v_strVALUE.Trim
                        Case "FULLNAME"
                            v_strACTYPE = v_strVALUE.Trim
                        Case "FRAMT"
                            v_dblFRAMT = CDbl(v_strVALUE)
                        Case "TOAMT"
                            v_dblTOAMT = CDbl(v_strVALUE)
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


            Dim v_lnResult As Long
            v_strSQL = "SELECT AUTOID, REFAUTOID, FRAMT, TOAMT, VALAMT  FROM ODPROBRKSCHM WHERE REFAUTOID='" & v_strREFAUTOID & "' ORDER BY FRAMT"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            v_lnResult = chkEditTier(v_ds, v_dblFRAMT, v_dblTOAMT)
            If v_lnResult <> 0 Then
                Return v_lnResult
            End If


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
            Dim v_strClause, v_strCCYCD, v_strCODEID, v_strSYMBOL As String
            Dim v_dblFromPrice, v_dblToPrice As Double
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
            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            'Tính các thông số
            Dim v_lnResult As Long
            v_strSQL = "SELECT AUTOID, REFAUTOID, FRAMT, TOAMT, VALAMT  FROM ODPROBRKSCHM WHERE " & v_strClause
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count >= 1 Then
                v_dblFromPrice = CDbl(v_ds.Tables(0).Rows(0)("FRAMT"))
                v_dblToPrice = CDbl(v_ds.Tables(0).Rows(0)("TOAMT"))

                v_strSQL = "SELECT AUTOID, REFAUTOID, FRAMT, TOAMT, VALAMT  FROM ODPROBRKSCHM WHERE REFAUTOID='" & v_ds.Tables(0).Rows(0)("REFAUTOID") & "' ORDER BY FRAMT"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                v_lnResult = chkDeleteTier(v_ds, v_dblFromPrice, v_dblToPrice)
                If v_lnResult <> 0 Then
                    Return v_lnResult
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