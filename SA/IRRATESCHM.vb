Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data

Public Class IRRATESCHM
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "IRRATESCHM"
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
            Dim v_strLocal, v_strActionFlag, v_strAUTOID, v_strRATEID As String, v_dblFRAMT, v_dblTOAMT, v_dblFRTERM, v_dblTOTERM As Double
            Dim v_strSQL, v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String

            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeACTFLAG) Is Nothing) Then
                v_strActionFlag = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeACTFLAG), Xml.XmlAttribute).Value)
            Else
                v_strActionFlag = String.Empty
            End If

            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strVALUE = .InnerText.ToString()
                    Select Case Trim(v_strFLDNAME)
                        Case "AUTOID"
                            v_strAUTOID = v_strVALUE.Trim
                        Case "RATEID"
                            v_strRATEID = v_strVALUE.Trim
                        Case "FRAMT"
                            v_dblFRAMT = CDbl(v_strVALUE)
                        Case "TOAMT"
                            v_dblTOAMT = CDbl(v_strVALUE)
                        Case "FRTERM"
                            v_dblFRTERM = CDbl(v_strVALUE)
                        Case "TOTERM"
                            v_dblTOTERM = CDbl(v_strVALUE)
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

            'v_strSQL = "SELECT COUNT(*) FROM " & ATTR_TABLE & " WHERE RATEID='" & v_strRATEID & "' " _
            '    & " AND ((FRAMT<=" & v_dblFRAMT & " AND TOAMT>" & v_dblFRAMT & ") OR (FRAMT<" & v_dblTOAMT & " AND TOAMT>=" & v_dblTOAMT & ")) " _
            '    & " AND ((FRTERM<=" & v_dblFRTERM & " AND TOTERM>" & v_dblFRTERM & ") OR (FRTERM<" & v_dblTOTERM & " AND TOTERM>=" & v_dblTOTERM & ")) "
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'If gf_CorrectNumericField(v_ds.Tables(0).Rows(0)(0)) > 0 Then
            '    Return ERR_TD_SCHEMA_DUPLICATED
            'End If

            'v_strSQL = "SELECT AUTOID, RATEID, DELTA, FRAMT, TOAMT, FRTERM, TOTERM  FROM IRRATESCHM WHERE RATEID='" & v_strRATEID & "' AND FRTERM=" & v_dblFRTERM & " AND TOTERM =" & v_dblTOTERM & " ORDER BY FRAMT"
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'v_lnResult = chkAddTier(v_ds, v_dblFRAMT, v_dblTOAMT)

            Dim lngReturn As Long
            lngReturn = CheckIRRATESCHM(v_strRATEID, v_strAUTOID, v_dblFRAMT, v_dblTOAMT, v_dblFRTERM, v_dblTOTERM, v_strActionFlag)
            If lngReturn <> ERR_SYSTEM_OK Then
                Return lngReturn
            End If



            Return ERR_SYSTEM_OK
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        Finally
            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If
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
            Dim v_strLocal, v_strActionFlag, v_strAUTOID, v_strRATEID As String, v_dblFRAMT, v_dblTOAMT, v_dblFRTERM, v_dblTOTERM As Double
            Dim v_strSQL, v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String

            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeACTFLAG) Is Nothing) Then
                v_strActionFlag = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeACTFLAG), Xml.XmlAttribute).Value)
            Else
                v_strActionFlag = String.Empty
            End If

            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strVALUE = .InnerText.ToString()
                    Select Case Trim(v_strFLDNAME)
                        Case "AUTOID"
                            v_strAUTOID = v_strVALUE.Trim
                        Case "RATEID"
                            v_strRATEID = v_strVALUE.Trim
                        Case "FRAMT"
                            v_dblFRAMT = CDbl(v_strVALUE)
                        Case "TOAMT"
                            v_dblTOAMT = CDbl(v_strVALUE)
                        Case "FRTERM"
                            v_dblFRTERM = CDbl(v_strVALUE)
                        Case "TOTERM"
                            v_dblTOTERM = CDbl(v_strVALUE)
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

            ''Luat kiem tra ko cho phep trung dong thoi khoang thoi gian va ky han
            'v_strSQL = "SELECT COUNT(*) FROM " & ATTR_TABLE & " WHERE RATEID='" & v_strRATEID & "' AND AUTOID<> " & v_strAUTOID & " " _
            '    & " AND ((FRAMT<=" & v_dblFRAMT & " AND TOAMT>=" & v_dblFRAMT & ") OR (FRAMT<=" & v_dblTOAMT & " AND TOAMT>=" & v_dblTOAMT & ")) " _
            '    & " AND ((FRTERM<=" & v_dblFRTERM & " AND TOTERM>" & v_dblFRTERM & ") OR (FRTERM<=" & v_dblTOTERM & " AND TOTERM>" & v_dblTOTERM & ")) "
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'If gf_CorrectNumericField(v_ds.Tables(0).Rows(0)(0)) > 0 Then
            '    Return ERR_TD_SCHEMA_DUPLICATED
            'End If


            'Dim v_lnResult As Long
            'v_strSQL = "SELECT AUTOID, RATEID, DELTA, FRAMT, TOAMT, FRTERM, TOTERM  FROM IRRATESCHM WHERE RATEID='" & v_strRATEID & "' AND FRTERM=" & v_dblFRTERM & " AND TOTERM =" & v_dblTOTERM & " ORDER BY FRAMT"
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'v_lnResult = chkEditTier(v_ds, v_dblFRAMT, v_dblTOAMT)
            'If v_lnResult <> 0 Then
            '    Return v_lnResult
            'End If

            Dim lngReturn As Long
            lngReturn = CheckIRRATESCHM(v_strRATEID, v_strAUTOID, v_dblFRAMT, v_dblTOAMT, v_dblFRTERM, v_dblTOTERM, v_strActionFlag)
            If lngReturn <> ERR_SYSTEM_OK Then
                Return lngReturn
            End If

            Return ERR_SYSTEM_OK
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        Finally
            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If
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
            Dim v_strLocal, v_strActionFlag, v_strRATEID, v_strAUTOID As String
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

            If Not (v_attrColl.GetNamedItem(gc_AtributeACTFLAG) Is Nothing) Then
                v_strActionFlag = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeACTFLAG), Xml.XmlAttribute).Value)
            Else
                v_strActionFlag = String.Empty
            End If

            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            v_strSQL = "SELECT AUTOID, RATEID, DELTA, FRAMT, TOAMT, FRTERM, TOTERM  FROM IRRATESCHM WHERE  " & v_strClause
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count >= 1 Then
                v_strRATEID = v_ds.Tables(0).Rows(0)("RATEID")
                v_strAUTOID = v_ds.Tables(0).Rows(0)("AUTOID")
            Else
                v_strRATEID = String.Empty
                v_strAUTOID = String.Empty
            End If

            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If

            Dim lngReturn As Long
            lngReturn = CheckIRRATESCHM(v_strRATEID, v_strAUTOID, 0, 0, 0, 0, v_strActionFlag)
            If lngReturn <> ERR_SYSTEM_OK Then
                Return lngReturn
            End If

            Return ERR_SYSTEM_OK
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try

    End Function

    Function CheckIRRATESCHM(ByVal pv_strRATEID As String, ByVal pv_strAUTOID As String, _
                             ByVal pv_dblFRAMT As Double, ByVal pv_dblTOAMT As Double, _
                             ByVal pv_dblFRTERM As Double, ByVal pv_dblTOTERM As Double, ByVal pv_strActionFlag As String) As Long
        Dim v_strSQL As String = String.Empty
        Dim v_obj As New DataAccess
        Dim v_ds As DataSet
        Dim v_dblReturn As Double = 0
        Try
            v_obj.NewDBInstance(gc_MODULE_HOST)

            Dim v_objParam As New StoreParameter
            Dim v_arrPara(8) As StoreParameter

            v_objParam.ParamName = "return"
            v_objParam.ParamDirection = ParameterDirection.ReturnValue
            v_objParam.ParamValue = 0
            v_objParam.ParamSize = 1000
            v_objParam.ParamType = GetType(System.Double).Name
            v_arrPara(0) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "RATEID"
            v_objParam.ParamValue = pv_strRATEID
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamSize = 10
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(1) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "AUTOID"
            v_objParam.ParamValue = pv_strAUTOID
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamSize = 10
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(2) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "FRAMT"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamValue = pv_dblFRAMT
            v_objParam.ParamSize = 20
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(3) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "TOAMT"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamValue = pv_dblTOAMT
            v_objParam.ParamSize = 10
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(4) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "FRTERM"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamValue = pv_dblFRTERM
            v_objParam.ParamSize = 20
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(5) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "TOTERM"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamValue = pv_dblTOTERM
            v_objParam.ParamSize = 10
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(6) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_Flag"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamValue = pv_strActionFlag
            v_objParam.ParamSize = 10
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(7) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_err_code"
            v_objParam.ParamDirection = ParameterDirection.Output
            v_objParam.ParamValue = ""
            v_objParam.ParamSize = 10
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(8) = v_objParam

            v_dblReturn = v_obj.ExecuteOracleStored("sapks_system.fn_CheckIRRATESCHM", v_arrPara, 0)

            If v_dblReturn <> ERR_SYSTEM_OK Then
                v_dblReturn = CDec(v_arrPara(8).ParamValue)
                Return v_dblReturn
            Else
                Return ERR_SYSTEM_OK
            End If

        Catch ex As Exception
            Return ERR_SYSTEM_START
        End Try
    End Function

#End Region

End Class
