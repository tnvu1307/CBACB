Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Public Class ICCFTIER
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "ICCFTIER"
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
            v_strSQL = "UPDATE ICCFTIER SET DELTD='Y' WHERE TRIM(AUTOID)='" & v_strAUTOID & "'"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Function

#Region " Overrides functions "
    Overrides Function CheckBeforeAdd(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal As String
            Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE, v_strMODCODE, v_strACTYPE, v_strEVENTCODE As String
            Dim v_strSQL As String


            Dim v_numTOAMT, v_numFAMT As Decimal

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
                        Case "TOAMT"
                            v_numTOAMT = Trim(v_strVALUE)
                        Case "FRAMT"
                            v_numFAMT = Trim(v_strVALUE)
                        Case "MODCODE"
                            v_strMODCODE = Trim(v_strVALUE)
                        Case "ACTYPE"
                            v_strACTYPE = Trim(v_strVALUE)
                        Case "EVENTCODE"
                            v_strEVENTCODE = Trim(v_strVALUE)
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
            v_strSQL = "SELECT AUTOID, MODCODE, ACTYPE, EVENTCODE, TIERNAME, FRAMT, TOAMT, DELTA, ICCFSTATUS, DELTD  FROM ICCFTIER A WHERE MODCODE='" & v_strMODCODE & "' AND ACTYPE = '" & v_strACTYPE & "' AND EVENTCODE ='" & v_strEVENTCODE & "' ORDER BY FRAMT"

            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            v_lnResult = chkAddTier(v_ds, v_numFAMT, v_numTOAMT)
            If v_lnResult <> 0 Then
                Return v_lnResult
            End If

            Return ERR_SYSTEM_OK
            'ContextUtil.SetComplete()
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
            Dim v_strLocal, v_strClause, v_strTLID As String
            Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE, v_strMODCODE, v_strACTYPE, v_strEVENTCODE As String
            Dim v_strSQL As String
            Dim v_numTOAMT, v_numFAMT As Decimal

            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If
            If Not (v_attrColl.GetNamedItem(gc_AtributeCLAUSE) Is Nothing) Then
                v_strClause = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Else
                v_strClause = String.Empty
            End If
            If Not (v_attrColl.GetNamedItem(gc_AtributeTLID) Is Nothing) Then
                v_strTLID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Else
                v_strTLID = String.Empty
            End If
            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strVALUE = .InnerText.ToString()

                    Select Case Trim(v_strFLDNAME)
                        Case "TOAMT"
                            v_numTOAMT = Trim(v_strVALUE)
                        Case "FRAMT"
                            v_numFAMT = Trim(v_strVALUE)
                        Case "MODCODE"
                            v_strMODCODE = Trim(v_strVALUE)
                        Case "ACTYPE"
                            v_strACTYPE = Trim(v_strVALUE)
                        Case "EVENTCODE"
                            v_strEVENTCODE = Trim(v_strVALUE)
                    End Select
                End With
            Next
            '  Return ERR_SA_ICCFTYPEDEF_DUPLICATED


            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            Dim v_lnResult As Long
            v_strSQL = "SELECT AUTOID, MODCODE, ACTYPE, EVENTCODE, TIERNAME, FRAMT, TOAMT, DELTA, ICCFSTATUS, DELTD  FROM ICCFTIER A WHERE MODCODE='" & v_strMODCODE & "' AND ACTYPE = '" & v_strACTYPE & "' AND EVENTCODE ='" & v_strEVENTCODE & "' ORDER BY FRAMT"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            v_lnResult = chkEditTier(v_ds, v_numFAMT, v_numTOAMT)
            If v_lnResult <> 0 Then
                Return v_lnResult
            End If
            If v_strClause.Length > 0 Then
                v_strSQL = "insert into iccftier_hist " & ControlChars.CrLf _
                            & " (AUTOID,MODCODE,ACTYPE,EVENTCODE,TIERNAME,FRAMT,TOAMT,DELTA,ICCFSTATUS,DELTD,BACKUPDT,MAKERID,ACTION) " & ControlChars.CrLf _
                            & " select AUTOID,MODCODE,ACTYPE,EVENTCODE,TIERNAME,FRAMT,TOAMT,DELTA,ICCFSTATUS,DELTD,to_char(sysdate,'DD/MM/RRRR:HH24:MI:SS'), '" & v_strTLID & "', 'EDIT' ACTION " & ControlChars.CrLf _
                            & " from iccftier WHERE " & v_strClause
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End If
            'ContextUtil.SetComplete()
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
            Dim v_strClause, v_strTLID, v_strCCYCD, v_strCODEID, v_strSYMBOL As String
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
            If Not (v_attrColl.GetNamedItem(gc_AtributeTLID) Is Nothing) Then
                v_strTLID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Else
                v_strTLID = String.Empty
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
            v_strSQL = "SELECT AUTOID, MODCODE, ACTYPE, EVENTCODE, TIERNAME, FRAMT, TOAMT, DELTA, ICCFSTATUS, DELTD  FROM ICCFTIER WHERE " & v_strClause
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count >= 1 Then
                v_dblFromPrice = CDbl(v_ds.Tables(0).Rows(0)("FRAMT"))
                v_dblToPrice = CDbl(v_ds.Tables(0).Rows(0)("TOAMT"))

                v_strSQL = "SELECT AUTOID, MODCODE, ACTYPE, EVENTCODE, TIERNAME, FRAMT, TOAMT, DELTA, ICCFSTATUS, DELTD  FROM ICCFTIER A WHERE MODCODE='" & v_ds.Tables(0).Rows(0)("MODCODE") & "' AND ACTYPE = '" & v_ds.Tables(0).Rows(0)("ACTYPE") & "' AND EVENTCODE ='" & v_ds.Tables(0).Rows(0)("EVENTCODE") & "' ORDER BY FRAMT"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                v_lnResult = chkDeleteTier(v_ds, v_dblFromPrice, v_dblToPrice)
                If v_lnResult <> 0 Then
                    Return v_lnResult
                End If

            End If


            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If

            If v_strClause.Length > 0 Then
                v_strSQL = "insert into iccftier_hist " & ControlChars.CrLf _
                            & " (AUTOID,MODCODE,ACTYPE,EVENTCODE,TIERNAME,FRAMT,TOAMT,DELTA,ICCFSTATUS,DELTD,BACKUPDT,MAKERID,ACTION) " & ControlChars.CrLf _
                            & " select AUTOID,MODCODE,ACTYPE,EVENTCODE,TIERNAME,FRAMT,TOAMT,DELTA,ICCFSTATUS,DELTD,to_char(sysdate,'DD/MM/RRRR:HH24:MI:SS'), '" & v_strTLID & "', 'DELETE' ACTION " & ControlChars.CrLf _
                            & " from iccftier WHERE " & v_strClause
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
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
