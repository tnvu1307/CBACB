Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Public Class AFSERULE
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "AFSERULE"
    End Sub

#Region " Overrides functions "
    Overrides Function CheckBeforeAdd(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        ' Return 0
        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strafacctno, v_strTLTXCD, v_strACTYPE As String
            Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE, v_strEXPDATE, v_strEFFDATE As String
            Dim v_strSQL As String
            Dim v_strTYPORMST, v_strREFID, v_strCODEID, v_strBORS, v_strFOA As String

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
                        Case "EFFDATE"
                            v_strEFFDATE = v_strVALUE
                        Case "EXPDATE"
                            v_strEXPDATE = v_strVALUE
                        Case "TYPORMST"
                            v_strTYPORMST = v_strVALUE
                        Case "REFID"
                            v_strREFID = v_strVALUE
                        Case "BORS"
                            v_strBORS = v_strVALUE
                        Case "CODEID"
                            v_strCODEID = v_strVALUE
                        Case "FOA"
                            v_strFOA = v_strVALUE
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

            v_strSQL = "SELECT COUNT(1) RCOUNT FROM afserule WHERE REFID = '" & v_strREFID & "' and CODEID = '" & v_strCODEID & "' and BORS = '" & v_strBORS & "' and FOA = '" & v_strFOA & "' " _
                    & " and ((to_date('" & v_strEFFDATE & "','DD/MM/RRRR') between EFFDATE and EXPDATE) or (to_date('" & v_strEXPDATE & "','DD/MM/RRRR') between EFFDATE and EXPDATE))"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("RCOUNT")) > 0 Then
                Return -200409
            End If

            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If

            Return 0
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try

    End Function

    Overrides Function CheckBeforeEdit(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strTYPORMST, v_strREFID, v_strCODEID, v_strBORS, v_strFOA As String

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strAUTOID, v_strAFAcctno, v_strTLTXCD, v_strACTYPE As String
            Dim v_strEXPDATE, v_strEFFDATE, v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String
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
                        Case "AUTOID"
                            v_strAUTOID = v_strVALUE
                        Case "EFFDATE"
                            v_strEFFDATE = v_strVALUE
                        Case "EXPDATE"
                            v_strEXPDATE = v_strVALUE
                        Case "TYPORMST"
                            v_strTYPORMST = v_strVALUE
                        Case "REFID"
                            v_strREFID = v_strVALUE
                        Case "BORS"
                            v_strBORS = v_strVALUE
                        Case "CODEID"
                            v_strCODEID = v_strVALUE
                        Case "FOA"
                            v_strFOA = v_strVALUE
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


            v_strSQL = "SELECT COUNT(1) RCOUNT FROM afserule WHERE AUTOID <> '" & v_strAUTOID & "' AND REFID = '" & v_strREFID & "' and CODEID = '" & v_strCODEID & "' and BORS = '" & v_strBORS & "' and FOA = '" & v_strFOA & "' " _
                    & " and ((to_date('" & v_strEFFDATE & "','DD/MM/RRRR') between EFFDATE and EXPDATE) or (to_date('" & v_strEXPDATE & "','DD/MM/RRRR') between EFFDATE and EXPDATE))"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("RCOUNT")) > 0 Then
                Return -200409
            End If

            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If

            Return 0
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try

    End Function
#End Region

End Class
