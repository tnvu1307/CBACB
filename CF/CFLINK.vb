Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Public Class CFLINK
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "CFLINK"
    End Sub

    Overrides Function Adhoc(ByRef v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strFuncName As String
        Dim v_strObjMsg As String
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            v_strFuncName = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeFUNCNAME), Xml.XmlAttribute).Value)
            Select Case Trim(v_strFuncName)
                Case "ADDCFLINK"
                    v_lngErrCode = ADDCFLINK(pv_xmlDocument)
                Case "EDITCFLINK"
                    v_lngErrCode = EDITCFLINK(pv_xmlDocument)

            End Select
            v_strMessage = pv_xmlDocument.InnerXml
            'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            Throw ex
        End Try
    End Function

    Private Function EDITCFLINK(ByRef pv_xmlDocument As XmlDocumentEx) As Long
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strClause As String
            Dim v_strLocal As String
            Dim v_strTellerId As String
            Dim v_strCmdupdateSQL As String

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
                v_strTellerId = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Else
                v_strTellerId = String.Empty
            End If


            'Inquiry data
            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If
            Dim v_arrCFLINK() As String
            ReDim v_arrCFLINK(5)
            v_arrCFLINK = v_strClause.Split("$")
            'check điều kiện add
            Dim v_lngErrorCode As Long
            Dim v_strsql As String
            Dim v_ds As DataSet
            v_strsql = "SELECT COUNT(CUSTID) FROM CFMAST WHERE  CUSTID  = '" & v_arrCFLINK(1) & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strsql)
            If v_ds.Tables(0).Rows.Count = 1 Then
                If v_ds.Tables(0).Rows(0)(0) = 0 Then
                    Return ERR_CF_CFLINK_CUSTID_NOTFOUND
                End If
            End If

            If v_lngErrorCode <> 0 Then
                Return v_lngErrorCode
                Exit Function
            End If
            v_strCmdupdateSQL = "UPDATE CFLINK SET  CUSTID='" & v_arrCFLINK(1).Replace("'", "''") & "', ACCTNO='" & v_arrCFLINK(2).Replace("'", "''") & "', LINKTYPE='" & v_arrCFLINK(3).Replace("'", "''") & "', DESCRIPTION='" & v_arrCFLINK(4).Replace("'", "''") & "', LINKAUTH ='" & v_arrCFLINK(5).Replace("'", "''") & "' WHERE AUTOID= '" & v_arrCFLINK(0) & "' "

            v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdupdateSQL)

            'AnhVT Added - Maintenance Approval Retro
            Dim result As New Long
            result = Me.MaintainLog(pv_xmlDocument, gc_ActionAdd)
            If Not (result = ERR_APPROVE_REQUIRED Or result = ERR_SYSTEM_OK) Then
                Return result
            End If

            Return 0
            'ContextUtil.SetComplete()
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function ADDCFLINK(ByRef pv_xmlDocument As XmlDocumentEx) As Long

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strClause As String
            Dim v_strLocal As String
            Dim v_strTellerId As String
            Dim v_strCmdInsertSQL As String

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
                v_strTellerId = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Else
                v_strTellerId = String.Empty
            End If


            'Inquiry data
            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If


            Dim v_arrCFLINK() As String
            ReDim v_arrCFLINK(4)
            v_arrCFLINK = v_strClause.Split("$")
            'check điều kiện add
            Dim v_lngErrorCode As Long
            Dim v_strsql As String
            Dim v_ds As DataSet
            v_strsql = "SELECT COUNT(CUSTID) FROM CFMAST WHERE  CUSTID  = '" & v_arrCFLINK(0) & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strsql)
            If v_ds.Tables(0).Rows.Count = 1 Then
                If v_ds.Tables(0).Rows(0)(0) = 0 Then
                    Return ERR_CF_CFLINK_CUSTID_NOTFOUND
                End If
            End If


            If v_lngErrorCode <> 0 Then
                Return v_lngErrorCode
                Exit Function
            End If



            v_strCmdInsertSQL = "INSERT INTO CFLINK(AUTOID, CUSTID, ACCTNO, LINKTYPE, DESCRIPTION, LINKAUTH ) " _
                                  & "VALUES(SEQ_CFLINK.NEXTVAL,'" & v_arrCFLINK(0).Replace("'", "''") & "', '" & v_arrCFLINK(1).Replace("'", "''") & "', '" & v_arrCFLINK(2).Replace("'", "''") & "', '" & v_arrCFLINK(3).Replace("'", "''") & "', '" & v_arrCFLINK(4).Replace("'", "''") & "')"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdInsertSQL)

            'AnhVT Added - Maintenance Approval Retro
            Dim result As New Long
            result = Me.MaintainLog(pv_xmlDocument, gc_ActionAdd)
            If Not (result = ERR_APPROVE_REQUIRED Or result = ERR_SYSTEM_OK) Then
                Return result
            End If
            Return 0
            'ContextUtil.SetComplete()
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
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
            Dim v_strLocal, v_strCUSTID As String
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
                        Case "CUSTID"
                            v_strCUSTID = Trim(v_strVALUE)

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

            'Kiểm tra CUSTID phai ton tai
            v_strSQL = "SELECT COUNT(CUSTID) FROM CFMAST WHERE  CUSTID  = '" & v_strCUSTID & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 1 Then
                If v_ds.Tables(0).Rows(0)(0) = 0 Then
                    Return ERR_CF_CFLINK_CUSTID_NOTFOUND
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
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strCUSTID As String
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
                        Case "SETYPE"
                            v_strCUSTID = Trim(v_strVALUE)
                        Case "CITYPE"
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

            'Kiểm tra CUSTID phai ton tai
            v_strSQL = "SELECT COUNT(CUSTID) FROM CFMAST WHERE  CUSTID  = '" & v_strCUSTID & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 1 Then
                If v_ds.Tables(0).Rows(0)(0) = 0 Then
                    Return ERR_CF_CFLINK_CUSTID_NOTFOUND
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
#End Region

End Class
