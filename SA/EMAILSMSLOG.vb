Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Public Class EMAILSMSLOG
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "EMAILSMSLOG"
    End Sub

#Region " Overrides functions "

    Overrides Function Add(ByRef v_strMessage As String) As Long
        Dim v_lngErrCode As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_nodeList As Xml.XmlNodeList, i, v_intemlcount As Integer
        Dim v_strNewValue As String, v_strOldValue As String, v_strFLDNAME As String, v_strFLDTYPE As String
        Dim v_strListOfFields As String = vbNullString
        Dim v_strListOfValues As String = vbNullString
        Dim v_strTxdate, v_strTxtime, v_strAcctno, v_strReportname, v_strNote, v_strSQLCHECK As String
        Dim v_strSQL As String = ""
        Dim v_obj As DataAccess
        Dim v_ds As DataSet
        Try
            v_obj = New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)

            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strFLDTYPE = CStr(CType(.Attributes.GetNamedItem("fldtype"), Xml.XmlAttribute).Value)
                    v_strNewValue = .InnerText.ToString

                    'If Len(v_strListOfFields) = 0 Then
                    '    v_strListOfFields = "(" & v_strFLDNAME
                    '    Select Case v_strFLDTYPE
                    '        Case "System.String"
                    '            v_strListOfValues = "('" & v_strNewValue.Replace("'", "''") & "'"
                    '        Case "System.Date"
                    '            v_strListOfValues = "(TO_DATE('" & v_strNewValue & "', '" & gc_FORMAT_DATE & "')"
                    '        Case Else
                    '            v_strListOfValues = "(" & v_strNewValue
                    '    End Select
                    'Else
                    '    v_strListOfFields = v_strListOfFields & "," & v_strFLDNAME
                    '    Select Case v_strFLDTYPE
                    '        Case "System.String"
                    '            v_strListOfValues = v_strListOfValues & ",'" & v_strNewValue.Replace("'", "''") & "'"
                    '        Case "System.Date"
                    '            v_strListOfValues = v_strListOfValues & ",TO_DATE('" & v_strNewValue & "', '" & gc_FORMAT_DATE & "')"
                    '        Case GetType(Double).Name
                    '            v_strListOfValues = v_strListOfValues & "," & Replace(v_strNewValue, ",", "")
                    '        Case Else
                    '            v_strListOfValues = v_strListOfValues & "," & v_strNewValue
                    '    End Select
                    'End If

                    Select Case Trim(v_strFLDNAME)
                        Case "TXDATE"
                            v_strTxdate = Trim(v_strNewValue)
                        Case "TXTIME"
                            v_strTxtime = Trim(v_strNewValue)
                        Case "ACCTNO"
                            v_strAcctno = Trim(v_strNewValue)
                        Case "REPORTNAME"
                            v_strReportname = Trim(v_strNewValue)
                        Case "NOTE"
                            v_strNote = Trim(v_strNewValue)
                    End Select

                End With
            Next

            v_strSQLCHECK = "SELECT EMAILCOUNT FROM " & ATTR_TABLE & " WHERE acctno = '" & v_strAcctno & "' and REPORTNAME = '" & v_strReportname & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQLCHECK)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_intemlcount = v_ds.Tables(0).Rows(0)(0)
                v_intemlcount = v_intemlcount + 1
                v_strSQL = "UPDATE EMAILSMSLOG SET EMAILCOUNT = " & v_intemlcount.ToString() & ", TXTIME = '" & v_strTxtime & "', TXDATE = TO_DATE('" & v_strTxdate & "', 'DD/MM/RRRR') WHERE acctno = '" & v_strAcctno & "' and REPORTNAME = '" & v_strReportname & "'"
            Else
                v_strSQL = "INSERT INTO EMAILSMSLOG (TXDATE,TXTIME,ACCTNO,REPORTNAME,NOTE,EMAILCOUNT) VALUES (TO_DATE('" & v_strTxdate _
                                                & "', 'dd/MM/RRRR'),'" & v_strTxtime & "','" & v_strAcctno & "','" & v_strReportname & "','" & v_strNote & "',1)"
            End If

            If Len(v_strSQL) <> 0 Then
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End If

            Return ERR_SYSTEM_OK
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

#End Region
End Class