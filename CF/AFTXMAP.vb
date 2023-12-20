Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Public Class AFTXMAP
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "AFTXMAP"
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
            Dim v_dtpEXPDATE, v_dtpEFFDATE As Date
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
                        Case "AFACCTNO"
                            v_strafacctno = Trim(v_strVALUE)
                        Case "TLTXCD"
                            v_strTLTXCD = Trim(v_strVALUE)
                        Case "ACTYPE"
                            v_strACTYPE = Trim(v_strVALUE)
                            'Case "EFFDATE"
                            '    v_dtpEFFDATE = gf_CorrectDateField(Trim(v_strVALUE))
                            'Case "EXPDATE"
                            '    v_dtpEXPDATE = gf_CorrectDateField(Trim(v_strVALUE))
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
            'If v_dtpEXPDATE < v_dtpEFFDATE Then
            '    Return ERR_SA_TXMAP_INVALID_EXPDATE
            'End If
            'Kiem tra ma bao cao phai co quan he phai ton tai
            v_strSQL = "SELECT COUNT(ROWNUM) FROM TLTX WHERE TLTXCD ='" & v_strTLTXCD & "' and restrictallow='Y'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If gf_CorrectNumericField(v_ds.Tables(0).Rows(0)(0)) = 0 Then
                Return ERR_SA_TLTXCD_NOTFOUND
            End If

            If UCase(v_strafacctno) = "ALL" Then
                v_strSQL = "SELECT COUNT(ROWNUM) FROM AFTXMAP WHERE TLTXCD ='" & v_strTLTXCD & "' and AFACCTNO='" & v_strafacctno & "' AND DELTD<>'Y' AND ACTYPE='" & v_strACTYPE & "' "
            Else
                v_strSQL = "SELECT COUNT(ROWNUM) FROM AFTXMAP WHERE TLTXCD ='" & v_strTLTXCD & "' and AFACCTNO='" & v_strafacctno & "' AND DELTD<>'Y'"
            End If

            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If gf_CorrectNumericField(v_ds.Tables(0).Rows(0)(0)) > 0 Then
                Return ERR_SA_TXMAP_DUPPLICATE_TLTXCD
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

        '  Return 0
        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strAUTOID, v_strAFAcctno, v_strTLTXCD, v_strACTYPE As String
            Dim v_dtpEXPDATE, v_dtpEFFDATE As DateTime
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
                        Case "AUTOID"
                            v_strAUTOID = Trim(v_strVALUE)
                        Case "AFACCTNO"
                            v_strAFAcctno = Trim(v_strVALUE)
                        Case "TLTXCD"
                            v_strTLTXCD = Trim(v_strVALUE)
                        Case "EFFDATE"
                            v_dtpEFFDATE = DDMMYYYY_SystemDate(Trim(v_strVALUE))
                        Case "EXPDATE"
                            v_dtpEXPDATE = DDMMYYYY_SystemDate(Trim(v_strVALUE))
                        Case "ACTYPE"
                            v_strACTYPE = Trim(v_strVALUE)
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

            If v_dtpEXPDATE < v_dtpEFFDATE Then
                Return ERR_SA_TXMAP_INVALID_EXPDATE
            End If
            'Kiem tra ma bao cao phai co quan he phai ton tai
            v_strSQL = "SELECT COUNT(ROWNUM) FROM TLTX WHERE TLTXCD ='" & v_strTLTXCD & "' "
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If gf_CorrectNumericField(v_ds.Tables(0).Rows(0)(0)) = 0 Then
                Return ERR_SA_TLTXCD_NOTFOUND
            End If

            'If UCase(v_strAFAcctno) = "ALL" Then

            'End If
            If UCase(v_strAFAcctno) = "ALL" Then
                v_strSQL = "SELECT COUNT(ROWNUM) FROM AFTXMAP WHERE TLTXCD ='" & v_strTLTXCD & "' and AFACCTNO='" & v_strAFAcctno & "' AND DELTD<>'Y' AND ACTYPE='" & v_strACTYPE & "' AND AUTOID <> " & v_strAUTOID & ""
            Else
                v_strSQL = "SELECT COUNT(ROWNUM) FROM AFTXMAP WHERE TLTXCD ='" & v_strTLTXCD & "' and AFACCTNO='" & v_strAFAcctno & "' AND DELTD<>'Y' AND AUTOID <> " & v_strAUTOID & ""
            End If

            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If gf_CorrectNumericField(v_ds.Tables(0).Rows(0)(0)) > 0 Then
                Return ERR_SA_TXMAP_DUPPLICATE_TLTXCD
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
