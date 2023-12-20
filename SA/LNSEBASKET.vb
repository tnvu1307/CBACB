Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Public Class LNSEBASKET
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "LNSEBASKET"
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
            Dim v_strLocal, v_strBASKETID, v_strACTYPE, v_strEFFDATE, v_strTXDATE As String
            Dim v_strSQL, v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String

            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If
            If Not (v_attrColl.GetNamedItem(gc_AtributeTXDATE) Is Nothing) Then
                v_strTXDATE = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXDATE), Xml.XmlAttribute).Value)
            Else
                v_strTXDATE = String.Empty
            End If

            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strVALUE = .InnerText.ToString()
                    Select Case Trim(v_strFLDNAME)
                        Case "BASKETID"
                            v_strBASKETID = Trim(v_strVALUE)
                        Case "ACTYPE"
                            v_strACTYPE = Trim(v_strVALUE)
                        Case "EFFDATE"
                            v_strEFFDATE = Trim(v_strVALUE)
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
            v_obj.GetSysVar("SYSTEM", "CURRDATE", v_strTXDATE)

            'v_strSQL = "SELECT COUNT(1) FROM LNSEBASKET WHERE ACTYPE='" & v_strACTYPE & "' and EFFDATE <= to_date('" & v_strTXDATE & "','DD/MM/RRRR')" _
            '           & " And to_date('" & v_strEFFDATE & "','DD/MM/RRRR') >=  to_date('" & v_strTXDATE & "','DD/MM/RRRR')"
            '29/12/2014 TruongLD Add chan khong cho gan LN vao nhieu ro
            '1 LN chi duoc phep gan vao 1 ro duy nhat'
            v_strSQL = "SELECT COUNT(1) FROM LNSEBASKET WHERE ACTYPE='" & v_strACTYPE & "' and EFFDATE <= to_date('" & v_strTXDATE & "','DD/MM/RRRR')"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If gf_CorrectNumericField(v_ds.Tables(0).Rows(0)(0)) > 0 Then
                Return ERR_SA_DUPLICATE_LNTYPE_SECBASKET
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

    Overrides Function ProcessAfterAdd(ByVal v_strMessage As String) As Long
        Dim v_strErrorSource, v_strErrorMessage As String
        v_strErrorSource = Me.ATTR_TABLE + ".ProcessAfterAdd"
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_ds As New DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Try
            Dim v_obj As DataAccess
            v_obj = New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)

            Dim v_objParam As StoreParameter
            Dim v_arrPara(1) As StoreParameter
            v_objParam = New StoreParameter
            v_objParam.ParamName = "return"
            v_objParam.ParamDirection = ParameterDirection.ReturnValue
            v_objParam.ParamValue = 0
            v_objParam.ParamSize = 100
            v_objParam.ParamType = GetType(System.Double).Name
            v_arrPara(0) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_err_code"
            v_objParam.ParamValue = "0"
            v_objParam.ParamDirection = ParameterDirection.InputOutput
            v_objParam.ParamSize = 10
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(1) = v_objParam

            v_lngErrCode = v_obj.ExecuteOracleStored("cspks_saproc.fn_ApplySystemParam", v_arrPara, 0)

            Return v_lngErrCode
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
            Dim v_strLocal, v_strAUTOID, v_strBASKETID, v_strACTYPE, v_strEFFDATE, v_strTXDATE As String
            Dim v_strSQL, v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String

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
                        Case "BASKETID"
                            v_strBASKETID = Trim(v_strVALUE)
                        Case "ACTYPE"
                            v_strACTYPE = Trim(v_strVALUE)
                        Case "EFFDATE"
                            v_strEFFDATE = Trim(v_strVALUE)
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
            v_obj.GetSysVar("SYSTEM", "CURRDATE", v_strTXDATE)

            'v_strSQL = "SELECT COUNT(1) FROM LNSEBASKET WHERE ACTYPE='" & v_strACTYPE & "' and AUTOID <> " & v_strAUTOID & " and EFFDATE = to_date('" & v_strEFFDATE & "','DD/MM/RRRR') and to_date('" & v_strEFFDATE & "','DD/MM/RRRR') >  to_date('" & v_strTXDATE & "','DD/MM/RRRR')"
            '29/12/2014 TruongLD Add chan khong cho gan LN vao nhieu ro
            '1 LN chi duoc phep gan vao 1 ro duy nhat'
            v_strSQL = "SELECT COUNT(1) FROM LNSEBASKET WHERE ACTYPE='" & v_strACTYPE & "' and AUTOID <> " & v_strAUTOID & " and EFFDATE <= to_date('" & v_strEFFDATE & "','DD/MM/RRRR')"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If gf_CorrectNumericField(v_ds.Tables(0).Rows(0)(0)) > 0 Then
                Return ERR_SA_DUPLICATE_LNTYPE_SECBASKET
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

    Overrides Function ProcessAfterEdit(ByVal v_strMessage As String) As Long
        Dim v_strErrorSource, v_strErrorMessage As String
        v_strErrorSource = Me.ATTR_TABLE + ".ProcessAfterEdit"
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_ds As New DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Try
            Dim v_obj As DataAccess
            v_obj = New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)

            Dim v_objParam As StoreParameter
            Dim v_arrPara(1) As StoreParameter
            v_objParam = New StoreParameter
            v_objParam.ParamName = "return"
            v_objParam.ParamDirection = ParameterDirection.ReturnValue
            v_objParam.ParamValue = 0
            v_objParam.ParamSize = 100
            v_objParam.ParamType = GetType(System.Double).Name
            v_arrPara(0) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_err_code"
            v_objParam.ParamValue = "0"
            v_objParam.ParamDirection = ParameterDirection.InputOutput
            v_objParam.ParamSize = 10
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(1) = v_objParam

            v_lngErrCode = v_obj.ExecuteOracleStored("cspks_saproc.fn_ApplySystemParam", v_arrPara, 0)

            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        Finally
            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If
        End Try
    End Function
#End Region

End Class
