Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Public Class CRPHYSAGREE
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "CRPHYSAGREE"
    End Sub

#Region " Overrides functions "
    Overrides Function CheckBeforeAdd(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal As String
            Dim v_strFLDNAME, v_strVALUE As String
            Dim v_strSQL As String
            Dim v_strACCTNO, v_strCODEID, v_strCUSTID, v_strCREATDATE As String
            Dim v_strQTTY As Integer

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
                        Case "ACCTNO"
                            v_strACCTNO = Trim(v_strVALUE)
                        Case "CODEID"
                            v_strCODEID = Trim(v_strVALUE)
                        Case "CREATDATE"
                            v_strCREATDATE = Trim(v_strVALUE)
                        Case "QTTY"
                            v_strQTTY = Trim(v_strVALUE)
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

            v_strSQL = "SELECT * FROM SEMAST WHERE ACCTNO = '" & v_strACCTNO & "" & v_strCODEID & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count <= 0 Then
                v_strSQL = "INSERT INTO SEMAST (ACTYPE,CUSTID,ACCTNO,CODEID,AFACCTNO," & ControlChars.CrLf _
                                                                           & "OPNDATE,LASTDATE,STATUS,IRTIED,IRCD," & ControlChars.CrLf _
                                                                           & "COSTPRICE,TRADE,MORTAGE,MARGIN,NETTING," & ControlChars.CrLf _
                                                                           & "STANDING,WITHDRAW,DEPOSIT,LOAN,RECEIVING) " & ControlChars.CrLf _
                                                               & " VALUES ('0000', '" & v_strACCTNO & "', '" & v_strACCTNO & "" & v_strCODEID & "', '" & v_strCODEID & "','" & v_strACCTNO & "'," & ControlChars.CrLf _
                                                               & "TO_DATE('" & v_strCREATDATE & "', '" & gc_FORMAT_DATE & "'),TO_DATE('" & v_strCREATDATE & "', '" & gc_FORMAT_DATE & "'),'A','Y','001'," & ControlChars.CrLf _
                                                               & "0,0,0,0,0,0,0,0,0," & v_strQTTY & ")"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            Else
                v_strSQL = "UPDATE SEMAST SET RECEIVING = RECEIVING + " & v_strQTTY & " WHERE ACCTNO = '" & v_strACCTNO & "" & v_strCODEID & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
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
            Dim v_strLocal As String
            Dim v_strFLDNAME, v_strVALUE As String
            Dim v_strSQL As String
            Dim v_strSYMBOL, v_strCRPHYSAGREEID, v_strCUSTODYCD As String

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
                        Case "CRPHYSAGREEID"
                            v_strCRPHYSAGREEID = Trim(v_strVALUE)
                        Case "SYMBOL"
                            v_strSYMBOL = Trim(v_strVALUE)
                        Case "CUSTODYCD"
                            v_strCUSTODYCD = Trim(v_strVALUE)
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

            'v_strSQL = "SELECT * FROM CRPHYSAGREE WHERE CRPHYSAGREEID = '" & v_strCRPHYSAGREEID & "' and PAYSTATUS <> 'P'"
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'If v_ds.Tables(0).Rows.Count > 0 Then
            '    Return ERR_AP_PAYSTATUS_CRPHYSAGREE
            'End If

            'If Not (v_ds Is Nothing) Then
            '    v_ds.Dispose()
            'End If

            'ContextUtil.SetComplete()
            Return ERR_SYSTEM_OK
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Overrides Function CheckBeforeDelete(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strClause, v_strACCTNO, v_strAPPLID, v_strACTYPE, v_strCCYCD, v_strGLBANK, v_strGLGRP As String
            Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String, v_dblAPRLIMIT As Double
            Dim v_strSQL As String

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

            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            'Kiểm tra xem Mã dữ liệu bị xoá có nằm trong bảng APPENDIX khác hay không
            v_strSQL = "SELECT COUNT(*) FROM APPENDIX WHERE 0=0 AND " & v_strClause
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_AP_CRPHYSAGREE_EXIT_APPENDIX
                End If
            End If

            Return ERR_SYSTEM_OK
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        Finally
            If Not (v_ds Is Nothing) Then v_ds.Dispose()
        End Try
    End Function

#End Region
End Class
