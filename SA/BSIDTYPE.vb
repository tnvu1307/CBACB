Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data

Public Class BSIDTYPE
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "AFIDTYPE"
    End Sub

#Region " Overrides functions "
    Overrides Function CheckBeforeAdd(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim lngReturn As Long
        Dim v_nodeList As Xml.XmlNodeList
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strAFTYPE, v_strACTYPE, v_strBRID, v_strOBJNAME, v_strActionFlag As String
            Dim v_strSQL, v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String
            Dim v_dblODRNUM As Double

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
                        Case "AFTYPE"
                            v_strAFTYPE = Trim(v_strVALUE)
                        Case "OBJNAME"
                            v_strOBJNAME = Trim(v_strVALUE)
                        Case "ACTYPE"
                            v_strACTYPE = Trim(v_strVALUE)
                        Case "ODRNUM"
                            v_dblODRNUM = CDbl(Trim(v_strVALUE))
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

            If v_strOBJNAME = "OD.ODTYPE" Then
                If Not CheckODTYPE(v_strAFTYPE, v_strACTYPE) Then
                    Return ERR_SA_ODTYPE_DUPLICATE
                End If
            ElseIf v_strOBJNAME = "AD.ADTYPE" Then
                lngReturn = CheckADTYPE(v_strAFTYPE, v_strACTYPE, v_strActionFlag)
                If lngReturn <> ERR_SYSTEM_OK Then
                    Return lngReturn
                End If
            End If

            v_strSQL = "SELECT COUNT(*) FROM AFIDTYPE WHERE AFTYPE='" & v_strAFTYPE & "' AND OBJNAME='" & v_strOBJNAME & "' AND ACTYPE='" & v_strACTYPE & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If gf_CorrectNumericField(v_ds.Tables(0).Rows(0)(0)) > 0 Then
                Return ERR_SA_USINGSERVICE_DUPLICATED
            End If

            v_strSQL = "SELECT COUNT(*) FROM AFIDTYPE WHERE AFTYPE='" & v_strAFTYPE & "' AND OBJNAME='" & v_strOBJNAME & "' AND ODRNUM =" & v_dblODRNUM & ""
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If gf_CorrectNumericField(v_ds.Tables(0).Rows(0)(0)) > 0 Then
                Return ERR_SA_SERVICE_ORDERNUM_DUPLICATED
            End If

            '</PHS yeu cau cho phep chon nhieu LN cung nguon --> bo chan
            'If v_strOBJNAME = "LN.LNTYPE" Then

            '    v_strSQL = "select count(1) EXISTSVAL from lntype lnt0 " & ControlChars.CrLf _
            '            & "where lnt0.actype = '" & v_strACTYPE & "' " & ControlChars.CrLf _
            '            & "     and exists (select 1 from afidtype afi, lntype lnt1  " & ControlChars.CrLf _
            '            & "     where afi.actype = lnt1.actype " & ControlChars.CrLf _
            '            & "         and afi.objname = 'LN.LNTYPE' " & ControlChars.CrLf _
            '            & "     and afi.aftype = '" & v_strAFTYPE & "' " & ControlChars.CrLf _
            '            & "     and lnt1.rrtype = lnt0.rrtype and ((lnt0.rrtype = 'C') " & ControlChars.CrLf _
            '            & "         or (lnt0.rrtype = 'B' and lnt0.custbank = lnt1.custbank)) " & ControlChars.CrLf _
            '            & "         )"
            '    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            '    If v_ds.Tables(0).Rows(0)("EXISTSVAL") > 0 Then
            '        Return ERR_SA_DUPLICATE_LOAN_SOURCE
            '    End If

            '    v_strSQL = "select count(1) EXISTSVAL from lntype lnt0 " & ControlChars.CrLf _
            '             & "where lnt0.actype = '" & v_strACTYPE & "' " & ControlChars.CrLf _
            '             & "    and exists (select 1 from aftype aft, lntype lnt1  " & ControlChars.CrLf _
            '             & "    where aft.lntype = lnt1.actype and aft.actype = '" & v_strAFTYPE & "' " & ControlChars.CrLf _
            '             & "        and lnt0.rrtype = lnt1.rrtype and ((lnt0.rrtype = 'C') " & ControlChars.CrLf _
            '             & "        or (lnt0.rrtype = 'B' and lnt0.custbank = lnt1.custbank)) " & ControlChars.CrLf _
            '             & "        )"
            '    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            '    If v_ds.Tables(0).Rows(0)("EXISTSVAL") > 0 Then
            '        Return ERR_SA_DUPLICATE_LOAN_SOURCE
            '    End If
            'End If
            '/>
            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If
            Return ERR_SYSTEM_OK
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Overrides Function CheckBeforeEdit(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim lngReturn As Long
        Dim v_nodeList As Xml.XmlNodeList
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strAutoID, v_strAFTYPE, v_strACTYPE, v_strBRID, v_strOBJNAME, v_strActionFlag As String
            Dim v_strSQL, v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String
            Dim v_dblODRNUM As Double

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
                            v_strAutoID = Trim(v_strVALUE)
                        Case "AFTYPE"
                            v_strAFTYPE = Trim(v_strVALUE)
                        Case "OBJNAME"
                            v_strOBJNAME = Trim(v_strVALUE)
                        Case "ACTYPE"
                            v_strACTYPE = Trim(v_strVALUE)
                        Case "ODRNUM"
                            v_dblODRNUM = CDbl(Trim(v_strVALUE))
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

            If v_strOBJNAME = "OD.ODTYPE" Then
                If Not CheckODTYPE(v_strAFTYPE, v_strACTYPE) Then
                    Return ERR_SA_ODTYPE_DUPLICATE

                End If
            ElseIf v_strOBJNAME = "AD.ADTYPE" Then
                lngReturn = CheckADTYPE(v_strAFTYPE, v_strACTYPE, v_strActionFlag)
                If lngReturn <> ERR_SYSTEM_OK Then
                    Return lngReturn
                End If
            End If

            v_strSQL = "SELECT COUNT(*) FROM AFIDTYPE WHERE AFTYPE='" & v_strAFTYPE & "' AND OBJNAME='" & v_strOBJNAME & "' AND ACTYPE='" & v_strACTYPE & "' AND AUTOID <> " & v_strAutoID
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If gf_CorrectNumericField(v_ds.Tables(0).Rows(0)(0)) > 0 Then
                Return ERR_SA_USINGSERVICE_DUPLICATED
            End If

            v_strSQL = "SELECT COUNT(*) FROM AFIDTYPE WHERE AFTYPE='" & v_strAFTYPE & "' AND OBJNAME='" & v_strOBJNAME & "' AND ODRNUM =" & v_dblODRNUM & " and autoid <> '" & v_strAutoID & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If gf_CorrectNumericField(v_ds.Tables(0).Rows(0)(0)) = 1 Then
                Return ERR_SA_SERVICE_ORDERNUM_DUPLICATED
            End If

            '</PHS yeu cau cho phep chon nhieu LN cung nguon --> bo chan
            'If v_strOBJNAME = "LN.LNTYPE" Then

            '    v_strSQL = "select count(1) EXISTSVAL from lntype lnt0 " & ControlChars.CrLf _
            '            & "where lnt0.actype = '" & v_strACTYPE & "' " & ControlChars.CrLf _
            '            & "and exists (select 1 from afidtype afi, lntype lnt1  " & ControlChars.CrLf _
            '            & "where afi.actype = lnt1.actype " & ControlChars.CrLf _
            '            & " and afi.objname = 'LN.LNTYPE' " & ControlChars.CrLf _
            '            & " and afi.aftype = '" & v_strAFTYPE & "' " & ControlChars.CrLf _
            '            & " and afi.AUTOID <> " & v_strAutoID & " " & ControlChars.CrLf _
            '            & " and lnt1.rrtype = lnt0.rrtype and ((lnt0.rrtype = 'C') " & ControlChars.CrLf _
            '            & "     or (lnt0.rrtype = 'B' and lnt0.custbank = lnt1.custbank)) " & ControlChars.CrLf _
            '            & "     )"
            '    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            '    If v_ds.Tables(0).Rows(0)("EXISTSVAL") > 0 Then
            '        Return ERR_SA_DUPLICATE_LOAN_SOURCE
            '    End If

            '    v_strSQL = "select count(1) EXISTSVAL from lntype lnt0 " & ControlChars.CrLf _
            '             & "where lnt0.actype = '" & v_strACTYPE & "' " & ControlChars.CrLf _
            '             & "    and exists (select 1 from aftype aft, lntype lnt1  " & ControlChars.CrLf _
            '             & "    where aft.lntype = lnt1.actype and aft.actype = '" & v_strAFTYPE & "' " & ControlChars.CrLf _
            '             & "        and lnt0.rrtype = lnt1.rrtype and ((lnt0.rrtype = 'C') " & ControlChars.CrLf _
            '             & "        or (lnt0.rrtype = 'B' and lnt0.custbank = lnt1.custbank)) " & ControlChars.CrLf _
            '             & "        )"
            '    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            '    If v_ds.Tables(0).Rows(0)("EXISTSVAL") > 0 Then
            '        Return ERR_SA_DUPLICATE_LOAN_SOURCE
            '    End If
            'End If
            '/>
            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If
            Return ERR_SYSTEM_OK
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

#End Region

    Function CheckADTYPE(ByVal pv_strAFTYPE As String, ByVal pv_strADTYPE As String, ByVal pv_strActionFlag As String) As Long
        Dim v_strSQL As String = String.Empty
        Dim v_obj As New DataAccess
        Dim v_ds As DataSet
        Dim v_dblReturn As Double = 0
        Try
            v_obj.NewDBInstance(gc_MODULE_HOST)

            Dim v_objParam As New StoreParameter
            Dim v_arrPara(5) As StoreParameter

            v_objParam.ParamName = "return"
            v_objParam.ParamDirection = ParameterDirection.ReturnValue
            v_objParam.ParamValue = 0
            v_objParam.ParamSize = 1000
            v_objParam.ParamType = GetType(System.Double).Name
            v_arrPara(0) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_aftype"
            v_objParam.ParamValue = pv_strAFTYPE
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamSize = 10
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(1) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_objname"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamValue = "AD.ADTYPE"
            v_objParam.ParamSize = 10
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(2) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_adtype"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamValue = pv_strADTYPE
            v_objParam.ParamSize = 10
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(3) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_Flag"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamValue = pv_strActionFlag
            v_objParam.ParamSize = 10
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(4) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_err_code"
            v_objParam.ParamDirection = ParameterDirection.Output
            v_objParam.ParamValue = ""
            v_objParam.ParamSize = 10
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(5) = v_objParam

            v_dblReturn = v_obj.ExecuteOracleStored("sapks_system.fn_CheckADTYPE", v_arrPara, 0)

            If v_dblReturn <> ERR_SYSTEM_OK Then
                v_dblReturn = CDec(v_arrPara(5).ParamValue)
                Return v_dblReturn
            Else
                Return ERR_SYSTEM_OK
            End If

        Catch ex As Exception
            Return ERR_SYSTEM_START
        End Try
    End Function

    Function CheckODTYPE(ByVal pv_strAFTYPE As String, ByVal pv_strODTYPE As String) As Boolean
        Dim v_strSQL As String = String.Empty
        Dim v_obj As New DataAccess
        Dim v_ds As DataSet
        Dim v_dblReturn As Double = 0
        Try
            v_obj.NewDBInstance(gc_MODULE_HOST)

            Dim v_objParam As New StoreParameter
            Dim v_arrPara(3) As StoreParameter

            v_objParam.ParamName = "return"
            v_objParam.ParamDirection = ParameterDirection.ReturnValue
            v_objParam.ParamValue = 0
            v_objParam.ParamSize = 1000
            v_objParam.ParamType = GetType(System.Double).Name
            v_arrPara(0) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_aftype"
            v_objParam.ParamValue = pv_strAFTYPE
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamSize = 10
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(1) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_objname"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamValue = "OD.ODTYPE"
            v_objParam.ParamSize = 10
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(2) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_odtype"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamValue = pv_strODTYPE
            v_objParam.ParamSize = 10
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(3) = v_objParam

            v_dblReturn = v_obj.ExecuteOracleStored("sapks_system.fn_CheckODTYPE", v_arrPara, 0)
            If v_dblReturn <> ERR_SYSTEM_OK Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

End Class
