Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Public Class GLMAST
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "GLMAST"
    End Sub

#Region " Overrides functions "

    Overrides Function CheckBeforeAdd(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strAcctNo, v_strGLBANK, v_strSUBCD2 As String
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
                        Case "GLBANK"
                            v_strGLBANK = Trim(v_strVALUE)
                        Case "SUBCD2"
                            v_strSUBCD2 = Trim(v_strVALUE)

                    End Select
                End With
            Next

            Dim v_obj As New DataAccess
            If v_strLocal = "N" Then
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            'Kiem tra Chieu Dai GLBANK (7 ki tu)
            If v_strGLBANK.Length <> 7 Then
                Return gc_ERRCODE_GL_GLBANK_LENGTH
            End If

            'Kiem tra Chieu Dai SUBCD2 (3 ki tu)
            If v_strSUBCD2.Length <> 3 Then
                Return gc_ERRCODE_GL_SUBCD2_LENGTH
            End If

            'Kiểm tra ACCTNO không được trùng
            Dim v_strSystemProcessMsg As String = pv_xmlDocument.InnerXml
            v_strAcctNo = GetAcctNo(v_strSystemProcessMsg)

            v_strSQL = "SELECT COUNT(ACCTNO) FROM " & ATTR_TABLE & " WHERE ACCTNO = '" & v_strAcctNo & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

            If v_ds.Tables(0).Rows.Count = 1 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return gc_ERRCODE_GL_ACCTNO_DUPLICATE
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
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK

        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_ds, v_ds1, v_ds2 As DataSet
        Dim v_obj As DataAccess
        Dim v_strSQL, v_strSQL1, v_strSQL2 As String

        Dim v_strLocal, v_strClause As String
        Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes

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

            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            'Kiểm tra trong bảng GLTRAN
            v_strSQL = "SELECT COUNT(ACCTNO) FROM GLTRAN WHERE ACCTNO " & Mid(v_strClause, InStr(v_strClause, "="))
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 1 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return gc_ERRCODE_GL_BDS_HAS_CHILD
                End If
            End If

            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If

            'Kiểm tra trong bảng GLTRANA
            v_strSQL1 = "SELECT COUNT(ACCTNO) FROM GLTRANA WHERE ACCTNO " & Mid(v_strClause, InStr(v_strClause, "="))
            v_ds1 = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL1)
            If v_ds1.Tables(0).Rows.Count = 1 Then
                If v_ds1.Tables(0).Rows(0)(0) > 0 Then
                    Return gc_ERRCODE_GL_BDS_HAS_CHILD
                End If
            End If

            If Not (v_ds1 Is Nothing) Then
                v_ds1.Dispose()
            End If

            'Kiểm tra trong bảng BANKNOSTRO
            v_strSQL2 = "SELECT COUNT(GLACCOUNT) FROM BANKNOSTRO WHERE GLACCOUNT " & Mid(v_strClause, InStr(v_strClause, "="))
            v_ds2 = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL2)
            If v_ds2.Tables(0).Rows.Count = 1 Then
                If v_ds2.Tables(0).Rows(0)(0) > 0 Then
                    Return gc_ERRCODE_GL_BDS_HAS_CHILD
                End If
            End If

            If Not (v_ds2 Is Nothing) Then
                v_ds2.Dispose()
            End If

            Return ERR_SYSTEM_OK
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try

    End Function

    Public Overrides Function Add(ByRef v_strMessage As String) As Long
        Dim v_lngErrCode As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Try
            v_lngErrCode = CoreAddAcctNo(pv_xmlDocument)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Dim v_strErrorSource, v_strErrorMessage As String
                v_strErrorSource = Me.ATTR_TABLE + ".Add"
                v_strErrorMessage = String.Empty

                LogError.Write("Error source: " + v_strErrorSource + vbNewLine _
                             + "Error code: " + v_lngErrCode.ToString() + vbNewLine _
                             + "Error message: " + v_strErrorMessage, "EventLogEntryType.Error")
                BuildXMLErrorException(pv_xmlDocument, v_strErrorSource, v_lngErrCode, v_strErrorMessage)
            End If
            v_strMessage = pv_xmlDocument.InnerXml
            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function CoreAddAcctNo(ByRef pv_xmlDocument As XmlDocumentEx) As Long
        'Core Add
        Dim v_strErrorSource As String = ATTR_TABLE & ".CoreAdd"
        Dim v_lngErrorCode As Long
        Dim v_strSYSVAR As String, v_DataAccess As New DataAccess
        Dim v_strSQL As String = "INSERT INTO " & ATTR_TABLE
        Dim v_strListOfFields As String = vbNullString
        Dim v_strListOfValues As String = vbNullString
        Dim v_strSignature As String = String.Empty
        Dim v_strCustID As String = String.Empty
        Try
            'Check HOST Active
            v_DataAccess.NewDBInstance(gc_MODULE_HOST)
            v_lngErrorCode = v_DataAccess.GetSysVar("SYSTEM", "HOSTATUS", v_strSYSVAR)
            If v_lngErrorCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrorCode
            End If
            If v_strSYSVAR <> OPERATION_ACTIVE Then
                Rollback() 'ContextUtil.SetAbort()
                Return ERR_SA_HOST_OPERATION_ISINACTIVE
            End If

            Dim v_strSystemProcessMsg As String = pv_xmlDocument.InnerXml

            v_lngErrorCode = CheckBeforeAdd(v_strSystemProcessMsg)

            If v_lngErrorCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrorCode
                Exit Function
            End If

            v_lngErrorCode = SystemProcessBeforeAdd(v_strSystemProcessMsg)

            If v_lngErrorCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrorCode
            End If

            pv_xmlDocument.LoadXml(v_strSystemProcessMsg)

            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strClause As String
            Dim v_strLocal As String
            Dim v_strAutoId As String

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
            If Not (v_attrColl.GetNamedItem(gc_AtributeAUTOID) Is Nothing) Then
                v_strAutoId = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeAUTOID), Xml.XmlAttribute).Value)
            Else
                v_strAutoId = String.Empty
            End If

            'Inquiry data
            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            Dim v_ds As DataSet
            Dim v_decID As Decimal
            If (v_strAutoId = gc_AutoIdUsed) Then
                v_decID = v_obj.GetIDValue(ATTR_TABLE)
            End If

            'Cập nhật vào CSDL
            Dim v_nodeList As Xml.XmlNodeList, i As Integer
            Dim v_strNewValue As String, v_strOldValue As String, v_strFLDNAME As String, v_strFLDTYPE As String

            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            For i = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strFLDTYPE = CStr(CType(.Attributes.GetNamedItem("fldtype"), Xml.XmlAttribute).Value)

                    If v_strFLDNAME = "AUTOID" Then
                        v_strNewValue = v_decID
                        'AnhVT Added for approval                        
                        Dim xmlMsg As Xml.XmlElement = pv_xmlDocument.SelectSingleNode("ObjectMessage")

                        xmlMsg.SetAttribute(gc_AtributeCLAUSE, v_strFLDNAME + " = '" + v_strNewValue + "'")

                    ElseIf v_strFLDNAME = "ACCTNO" Then
                        v_strNewValue = GetAcctNo(v_strSystemProcessMsg)
                        Dim xmlMsg As Xml.XmlElement = pv_xmlDocument.SelectSingleNode("ObjectMessage")

                        xmlMsg.SetAttribute(gc_AtributeCLAUSE, v_strFLDNAME + " = '" + v_strNewValue + "'")

                    ElseIf v_strFLDNAME = "MAPID" Then
                        v_strNewValue = GetMapID(v_strSystemProcessMsg)
                        Dim xmlMsg As Xml.XmlElement = pv_xmlDocument.SelectSingleNode("ObjectMessage")

                        xmlMsg.SetAttribute(gc_AtributeCLAUSE, v_strFLDNAME + " = '" + v_strNewValue + "'")

                    Else
                        v_strNewValue = .InnerText.ToString
                    End If

                    If Len(v_strNewValue) > 0 Then
                        If Len(v_strListOfFields) = 0 Then
                            v_strListOfFields = "(" & v_strFLDNAME
                            Select Case v_strFLDTYPE
                                Case "System.String"
                                    v_strListOfValues = "('" & v_strNewValue.Replace("'", "''") & "'"
                                Case "System.Date"
                                    v_strListOfValues = "('" & v_strNewValue & "'"
                                Case Else
                                    v_strListOfValues = "(" & v_strNewValue
                            End Select
                        Else
                            v_strListOfFields = v_strListOfFields & "," & v_strFLDNAME
                            Select Case v_strFLDTYPE
                                Case "System.String"
                                    v_strListOfValues = v_strListOfValues & ",'" & v_strNewValue.Replace("'", "''") & "'"
                                Case "System.DateTime"
                                    v_strListOfValues = v_strListOfValues & ",TO_DATE('" & v_strNewValue & "', '" & gc_FORMAT_DATE & "')"
                                Case GetType(Double).Name
                                    v_strListOfValues = v_strListOfValues & "," & Replace(v_strNewValue, ",", "")
                                Case Else
                                    v_strListOfValues = v_strListOfValues & "," & v_strNewValue
                            End Select
                        End If
                    End If
                End With
            Next
            If Len(v_strListOfFields) <> 0 Then
                v_strListOfFields = v_strListOfFields & ")"
                v_strListOfValues = v_strListOfValues & ")"
                v_strSQL = v_strSQL & " " & v_strListOfFields & " VALUES " & v_strListOfValues
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            End If

            'AnhVT Added - Maintenance Approval Retro
            Dim result As Long
            result = Me.MaintainLog(pv_xmlDocument, gc_ActionAdd)
            If Not (result = ERR_APPROVE_REQUIRED Or result = ERR_SYSTEM_OK) Then
                Return result
            End If
            Complete() 'ContextUtil.SetComplete()
            Return ERR_SYSTEM_OK
        Catch ex As Exception
            LogError.WriteException(ex)
        Finally
        End Try
        'End core add
    End Function

    Private Function GetAcctNo(ByVal v_strMessage As String) As String
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_strLocal As String
        Dim v_strACCTNO As String
        Dim v_strMAPID As String

        Dim v_obj As New DataAccess
        Dim v_nodeList As Xml.XmlNodeList

        Dim v_strSQL As String
        Dim v_ds As DataSet

        Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String
        Dim v_strBRID, v_strCCYCD, v_strDEPGRCD, v_strGLBANK, v_strSUBCD, v_strSUBCD2 As String

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
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
                        Case "BRID"
                            v_strBRID = Trim(v_strVALUE)
                        Case "CCYCD"
                            v_strCCYCD = Trim(v_strVALUE)
                        Case "DEPGRCD"
                            v_strDEPGRCD = Trim(v_strVALUE)
                        Case "GLBANK"
                            v_strGLBANK = Trim(v_strVALUE)
                        Case "SUBCD"
                            v_strSUBCD = Trim(v_strVALUE)
                        Case "MAPID"
                            Dim v_strSystemProcessMsg As String = pv_xmlDocument.InnerXml
                            v_strMAPID = GetMapID(v_strSystemProcessMsg)
                        Case "SUBCD2"
                            v_strSUBCD2 = Trim(v_strVALUE)
                    End Select
                End With
            Next

            If v_strLocal = "N" Then
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            v_strACCTNO = v_strBRID & v_strCCYCD & v_strDEPGRCD & v_strGLBANK & v_strSUBCD & v_strMAPID & v_strSUBCD2

            Return v_strACCTNO

            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If
            'ContextUtil.SetComplete()

        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try

    End Function

    Private Function GetMapID(ByVal v_strMessage As String) As String
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_strLocal As String
        Dim v_strBRID, v_strMAPID As String

        Dim v_obj As New DataAccess
        Dim v_nodeList As Xml.XmlNodeList

        Dim v_strSQL As String
        Dim v_ds As DataSet

        Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
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
                        Case "BRID"
                            v_strBRID = Trim(v_strVALUE)

                    End Select
                End With
            Next

            If v_strLocal = "N" Then
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            v_strSQL = "SELECT MAPID FROM BRGRP WHERE BRID = '" & v_strBRID & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

            If v_ds.Tables(0).Rows.Count = 1 Then
                v_strMAPID = v_ds.Tables(0).Rows(0)(0)
            End If

            Return v_strMAPID

            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If
            'ContextUtil.SetComplete()

        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function


#End Region

End Class
