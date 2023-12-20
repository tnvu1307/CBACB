Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Public Class CRBBANKREQUEST
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "CRBBANKREQUEST"
    End Sub

#Region "Override functions"

    Overrides Function Adhoc(ByRef v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strFuncName As String
        Dim v_strObjMsg As String
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            v_strFuncName = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeFUNCNAME), Xml.XmlAttribute).Value)
            Select Case Trim(v_strFuncName)
                Case "AddManualMsg"
                    v_lngErrCode = AddManualMsg(pv_xmlDocument)

            End Select
            v_strMessage = pv_xmlDocument.InnerXml
            'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            Throw ex
        End Try
    End Function

    Overrides Function Edit(ByRef v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_lngErrCode As Long
        Try
            v_lngErrCode = ChangeReqInfor(pv_xmlDocument)
            If v_lngErrCode <> 0 Then
                Dim v_strErrorSource, v_strErrorMessage As String

                v_strErrorSource = "CFAUTH.Edit"
                v_strErrorMessage = String.Empty

                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                             & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                             & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                BuildXMLErrorException(pv_xmlDocument, v_strErrorSource, v_lngErrCode, v_strErrorMessage)
            End If
            'ContextUtil.SetComplete()
            v_strMessage = pv_xmlDocument.InnerXml
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function ChangeReqInfor(ByRef pv_xmlDocument As XmlDocumentEx) As Long

        Dim v_lngErrorCode As Long

        v_lngErrorCode = CheckBeforeEdit(pv_xmlDocument.InnerXml)
        If v_lngErrorCode <> 0 Then
            Return v_lngErrorCode
            Exit Function
        End If

        Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
        Dim v_strClause As String
        Dim v_strLocal As String

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

        'Update data
        Dim v_obj As DataAccess
        If v_strLocal = "Y" Then
            v_obj = New DataAccess
        ElseIf v_strLocal = "N" Then
            v_obj = New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
        End If

        Dim v_ds As DataSet
        Dim v_strSQL As String = "UPDATE " & ATTR_TABLE & " SET ", v_strUPD As String = vbNullString, v_strUPDTMP As String = vbNullString

        Dim v_nodeList As Xml.XmlNodeList, i As Integer
        Dim v_strNewValue As String, v_strOldValue As String, v_strFLDNAME As String, v_strFLDTYPE As String
        Dim v_strAutoID, v_strSignature As String
        v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

        For i = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
            With v_nodeList.Item(0).ChildNodes(i)
                v_strOldValue = CStr(CType(v_nodeList.Item(0).ChildNodes(i).Attributes.GetNamedItem("oldval"), Xml.XmlAttribute).Value)
                v_strNewValue = .InnerText.ToString
                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                v_strFLDTYPE = CStr(CType(.Attributes.GetNamedItem("fldtype"), Xml.XmlAttribute).Value)

                If v_strFLDNAME = "AUTOID" Then
                    v_strAutoID = v_strNewValue
                End If
                'If Trim(v_strOldValue) <> Trim(v_strNewValue) Then
                v_strFLDNAME = CStr(CType(v_nodeList.Item(0).ChildNodes(i).Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                v_strFLDTYPE = CStr(CType(v_nodeList.Item(0).ChildNodes(i).Attributes.GetNamedItem("fldtype"), Xml.XmlAttribute).Value)

                Select Case v_strFLDTYPE
                    Case "System.String"
                        v_strUPDTMP = v_strFLDNAME & " = '" & v_strNewValue & "'"
                    Case "System.DateTime"
                        v_strUPDTMP = v_strFLDNAME & " = TO_DATE('" & v_strNewValue & "', '" & gc_FORMAT_DATE & "')"
                    Case GetType(Double).Name
                        v_strUPDTMP = v_strFLDNAME & "=" & Replace(v_strNewValue, ",", "")
                    Case Else
                        v_strUPDTMP = v_strFLDNAME & "=" & v_strNewValue
                End Select

                If Len(v_strUPD) = 0 Then
                    v_strUPD = v_strUPDTMP
                Else
                    v_strUPD = v_strUPD & ", " & v_strUPDTMP
                End If
                'Else
                'v_strFLDNAME = CStr(CType(v_nodeList.Item(0).ChildNodes(i).Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                'v_strFLDTYPE = CStr(CType(v_nodeList.Item(0).ChildNodes(i).Attributes.GetNamedItem("fldtype"), Xml.XmlAttribute).Value)
                'End If

            End With
        Next

        If Len(v_strUPD) <> 0 Then
            v_strSQL = v_strSQL & v_strUPD & " WHERE 0=0 AND " & v_strClause
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
        End If

        'Insert log


        'Dim result As Long
        'result = Me.MaintainLog(pv_xmlDocument, gc_ActionEdit)
        'If Not (result = ERR_APPROVE_REQUIRED Or result = ERR_SYSTEM_OK) Then
        '    Return result
        'End If

        Return 0
    End Function


    Private Function AddManualMsg(ByRef pv_xmlDocument As XmlDocumentEx) As Long

        Dim v_lngErrorCode As Long
        Try
            v_lngErrorCode = CheckBeforeAdd(pv_xmlDocument.InnerXml)
            If v_lngErrorCode <> 0 Then
                Return v_lngErrorCode
                Exit Function
            End If

            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strClause As String
            Dim v_strLocal As String

            If Not (v_attrColl.GetNamedItem(gc_AtributeTLID) Is Nothing) Then
                v_strClause = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Else
                v_strClause = String.Empty
            End If
            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If

            'Update data
            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            Dim v_ds As DataSet
            Dim v_nodeList As Xml.XmlNodeList, i As Integer
            Dim v_strSQL As String
            Dim v_strNewValue As String, v_strOldValue As String, v_strFLDNAME As String, v_strFLDTYPE As String
            Dim v_strTRNREF, v_strDESBANKACCOUNT, v_strBANKCODE, v_strBRANCH, v_strLOCATION, v_strACCNUM, v_strACCNAME, v_strKEYACCT1, v_strKEYACCT2, v_strTRANSACTIONDESCRIPTION, v_strSTATUS As String
            Dim v_dblAMOUNT As Double
            Dim v_strAutoID, v_strSignature As String
            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            For i = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(i)
                    v_strOldValue = CStr(CType(v_nodeList.Item(0).ChildNodes(i).Attributes.GetNamedItem("oldval"), Xml.XmlAttribute).Value)
                    v_strNewValue = .InnerText.ToString
                    'v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    'v_strFLDTYPE = CStr(CType(.Attributes.GetNamedItem("fldtype"), Xml.XmlAttribute).Value)

                    v_strFLDNAME = CStr(CType(v_nodeList.Item(0).ChildNodes(i).Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strFLDTYPE = CStr(CType(v_nodeList.Item(0).ChildNodes(i).Attributes.GetNamedItem("fldtype"), Xml.XmlAttribute).Value)
                    Select Case v_strFLDNAME
                        Case "TRNREF"
                            v_strTRNREF = CStr(v_strNewValue)
                        Case "DESBANKACCOUNT"
                            v_strDESBANKACCOUNT = CStr(v_strNewValue)
                        Case "AMOUNT"
                            v_dblAMOUNT = CDbl(v_strNewValue)
                        Case "BANKCODE"
                            v_strBANKCODE = CStr(v_strNewValue)
                        Case "BRANCH"
                            v_strBRANCH = CStr(v_strNewValue)
                        Case "LOCATION"
                            v_strLOCATION = CStr(v_strNewValue)
                        Case "ACCNUM"
                            v_strACCNUM = CStr(v_strNewValue)
                        Case "ACCNAME"
                            v_strACCNAME = CStr(v_strNewValue)
                        Case "KEYACCT1"
                            v_strKEYACCT1 = CStr(v_strNewValue)
                        Case "KEYACCT2"
                            v_strKEYACCT2 = CStr(v_strNewValue)
                        Case "TRANSACTIONDESCRIPTION"
                            v_strTRANSACTIONDESCRIPTION = CStr(v_strNewValue)
                        Case "STATUS"
                            v_strSTATUS = CStr(v_strNewValue)
                    End Select

                End With
            Next

            v_strSQL = "insert into crbbankrequest (autoid,TXDATE, CREATEDT, status, trnref," &
                       " trn_dt, desbankaccount, accname, accnum, bankcode, " &
                       " branch, location, amount, keyacct1, keyacct2, " &
                       " transactiondescription,ISMANUAL, usercreated) " &
                       " values(seq_CRBBANKREQUEST.nextval,getcurrdate,getcurrdate, '" & v_strSTATUS & "', '" & v_strTRNREF & "', getcurrdate, '" & v_strDESBANKACCOUNT & "', " &
                       " '" & v_strACCNAME & "', '" & v_strACCNUM & "', '" & v_strBANKCODE & "', '" & v_strBRANCH & "', '" & v_strLOCATION & "', " & v_dblAMOUNT & ", '" & v_strKEYACCT1 & "'," &
                       " '" & v_strKEYACCT2 & "', '" & v_strTRANSACTIONDESCRIPTION & "','Y', '" & v_strClause & "')"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            Return 0

        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

#End Region

End Class
