Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data

Public Class EXAFMAST
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "EXAFMAST"
    End Sub


#Region " Overrides functions "
    'Overrides Function CheckBeforeAdd(ByVal pv_xmlDocument As CommonLibrary.XmlDocumentEx) As Long
    Overrides Function CheckBeforeAdd(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strAFACCTNO, v_strMODCODE, v_strEVENTCODE, v_strEXTYPE As String
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
                            v_strAFACCTNO = Trim(v_strVALUE)
                        Case "MODCODE"
                            v_strMODCODE = Trim(v_strVALUE)
                        Case "EVENTCODE"
                            v_strEVENTCODE = Trim(v_strVALUE)
                        Case "EXTYPE"
                            v_strEXTYPE = Trim(v_strVALUE)
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

            v_strSQL = "SELECT COUNT(AFACCTNO) FROM " & ATTR_TABLE & _
                        " WHERE AFACCTNO = '" & v_strAFACCTNO & "' " & _
                        " AND MODCODE = '" & v_strMODCODE & "' " & _
                        " AND EVENTCODE = '" & v_strEVENTCODE & "' " & _
                        " AND EXTYPE = '" & v_strEXTYPE & "' "
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 1 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_CF_EXAFMAST_DUPLICATED
                End If
            End If
            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If

            v_strSQL = "SELECT ACCTNO FROM V_LOOKUP_ICCF " & _
                      "WHERE ACCTNO='" & v_strAFACCTNO & "' " & _
                      " AND MODCODE = '" & v_strMODCODE & "' " & _
                      " AND VALUE = '" & v_strEVENTCODE & "' "
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count <= 0 Then
                Return ERR_CF_EVENTCODE_INVALID
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

    'Public Overrides Function CheckBeforeEdit(ByVal pv_xmlDocument As CommonLibrary.XmlDocumentEx) As Long
    Overrides Function CheckBeforeEdit(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_lngErrCode As Long
        Try
            v_lngErrCode = CheckSystemRate(pv_xmlDocument)
            If v_lngErrCode <> 0 Then
                Dim v_strErrorSource, v_strErrorMessage As String

                v_strErrorSource = "EXAFMAST.Inquiry"
                v_strErrorMessage = String.Empty

                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                             & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                             & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                BuildXMLErrorException(pv_xmlDocument, v_strErrorSource, v_lngErrCode, v_strErrorMessage)
            End If
            'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function CheckSystemRate(ByVal pv_xmlDocument As HostCommonLibrary.XmlDocumentEx) As Long
        'Return ERR_SYSTEM_OK
        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strCUSTID, v_strCUSTODYCD, v_strCAREBY, v_strIDTYPE, v_strIDCODE, v_strREFNAME As String
            Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE, v_strDATEOFBIRTH, v_strIDEXPIRED As String
            Dim v_strSQL, v_strCUSTTYPE, v_strTAXCODE As String
            Dim v_BRID As String
            v_BRID = CStr(CType(v_attrColl.GetNamedItem("BRID"), Xml.XmlAttribute).Value)
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
                        Case "CUSTID"
                            v_strCUSTID = Trim(v_strVALUE)
                        Case "CUSTODYCD"
                            v_strCUSTODYCD = Trim(v_strVALUE)
                        Case "CAREBY"
                            v_strCAREBY = Trim(v_strVALUE)
                        Case "IDTYPE"
                            v_strIDTYPE = Trim(v_strVALUE)
                        Case "IDCODE"
                            v_strIDCODE = Trim(v_strVALUE)
                        Case "DATEOFBIRTH"
                            v_strDATEOFBIRTH = Trim(v_strVALUE)
                        Case "IDEXPIRED"
                            v_strIDEXPIRED = Trim(v_strVALUE)
                        Case "CUSTTYPE"
                            v_strCUSTTYPE = Trim(v_strVALUE)
                        Case "TAXCODE"
                            v_strTAXCODE = Trim(v_strVALUE)
                        Case "REFNAME"
                            v_strREFNAME = Trim(Replace(v_strVALUE, ".", ""))
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
            Return 0
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Overrides Function Delete(ByRef v_strMessage As String) As Long
        Try
            Dim v_lngErrCode As Long
            Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strClause As String
            Dim v_strLocal As String

            If Not (v_attrColl.GetNamedItem(gc_AtributeCLAUSE) Is Nothing) Then
                v_strClause = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value).Replace("'", "")
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

            Dim v_strSQL As String
            v_strSQL = "INSERT INTO EXAFMASTHIST(AUTOID, EVENTCODE, AFACCTNO, EXPDATE, EXCYCLE, OPERAND, DELTA, MINVAL, MAXVAL, STATUS, CURRRATE, EFFECTIVEDT, MODCODE, EXTYPE) " &
                        " SELECT AUTOID, EVENTCODE, AFACCTNO, EXPDATE, EXCYCLE, OPERAND, DELTA, MINVAL, MAXVAL, STATUS, CURRRATE, EFFECTIVEDT, MODCODE, EXTYPE " &
                        " FROM " & ATTR_TABLE &
                        " WHERE 0=0 AND " & v_strClause
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            v_lngErrCode = MyBase.Delete(v_strMessage)
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try

    End Function

#End Region

    
End Class
