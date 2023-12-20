Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Imports System.Diagnostics

Public Class AFTYPE
    Inherits CoreBusiness.basedTYPE

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "AFTYPE"
    End Sub

#Region " Overrides functions "

    Public Overrides Function TYPECheckBeforeAdd(ByVal v_strMessage As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = ATTR_TABLE & ".SystemProcessBeforeAdd"
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strACTYPE, v_strCCYCD, v_strGLBANK, v_strGLGRP, v_strCHKSYSCTRL, v_strAUTOADV As String
            Dim v_strSQL, v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String
            Dim v_strCITYPE, v_strSETYPE, v_strDFTYPE, v_strMRTYPE, v_strLNTYPE, v_strADTYPE, v_strT0LNTYPE, v_strCOREBANK, v_strISTRFBUY As String
            Dim v_dblTRFBUYEXT As Double
            v_strMRTYPE = String.Empty
            v_strLNTYPE = String.Empty
            v_strDFTYPE = String.Empty
            v_strADTYPE = String.Empty

            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If
            v_strACTYPE = String.Empty
            v_strCCYCD = String.Empty
            v_strGLBANK = String.Empty
            v_strGLGRP = String.Empty

            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strVALUE = .InnerText.ToString().Trim
                    Select Case Trim(v_strFLDNAME)
                        Case "ACTYPE"
                            v_strACTYPE = Trim(v_strVALUE)
                        Case "CCYCD"
                            v_strCCYCD = Trim(v_strVALUE)
                        Case "GLGRP"
                            v_strGLGRP = Trim(v_strVALUE)
                        Case "GLBANK"
                            v_strGLBANK = Trim(v_strVALUE)
                        Case "CITYPE"
                            v_strCITYPE = Trim(v_strVALUE)
                        Case "SETYPE"
                            v_strSETYPE = Trim(v_strVALUE)
                        Case "LNTYPE"
                            v_strLNTYPE = Trim(v_strVALUE)
                        Case "T0LNTYPE"
                            v_strT0LNTYPE = Trim(v_strVALUE)
                        Case "DFTYPE"
                            v_strDFTYPE = Trim(v_strVALUE)
                        Case "MRTYPE"
                            v_strMRTYPE = Trim(v_strVALUE)
                        Case "ADTYPE"
                            v_strADTYPE = Trim(v_strVALUE)
                        Case "COREBANK"
                            v_strCOREBANK = Trim(v_strVALUE)
                        Case "TRFBUYEXT"
                            v_dblTRFBUYEXT = CDbl(Trim(v_strVALUE))
                        Case "ISTRFBUY"
                            v_strISTRFBUY = Trim(v_strVALUE)
                        Case "AUTOADV"
                            v_strAUTOADV = Trim(v_strVALUE)
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

            'Kiểm tra ACTYPE không được trùng
            If v_strACTYPE.Length > 0 Then
                v_strSQL = "SELECT COUNT(ACTYPE) FROM " & ATTR_TABLE & " WHERE ACTYPE = '" & v_strACTYPE & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count = 1 Then
                    If v_ds.Tables(0).Rows(0)(0) > 0 Then
                        Return ERR_SA_PRODUCT_ACTYPE_DUPLICATED
                    End If
                End If
            End If

            'Kiểm tra SETYPE phai ton tai
            v_strSQL = "SELECT COUNT(ACTYPE) FROM SETYPE WHERE STATUS = 'Y' AND ACTYPE = '" & v_strSETYPE & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 1 Then
                If v_ds.Tables(0).Rows(0)(0) = 0 Then
                    Return ERR_CF_SE_NOT_EXIT
                End If
            End If

            'Kiểm tra SETYPE phai duyet
            If v_strSETYPE <> "" Then
                v_strSQL = "SELECT * FROM SETYPE WHERE STATUS = 'Y' AND APPRV_STS = 'A' AND ACTYPE = '" & v_strSETYPE & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count <> 1 Then
                    Return ERR_CF_SE_NOT_APPROVE
                End If
            End If

            ''Kiểm tra CI có tồn tại
            'v_strSQL = "SELECT COUNT(ACTYPE) FROM CITYPE WHERE STATUS='Y' AND ACTYPE = '" & v_strCITYPE & "'"
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'If v_ds.Tables(0).Rows.Count = 1 Then
            '    If v_ds.Tables(0).Rows(0)(0) = 0 Then
            '        Return ERR_CF_CI_NOT_EXIT
            '    End If
            'End If

            ''Kiểm tra CI phai duyet
            'If v_strCITYPE <> "" Then
            '    v_strSQL = "SELECT * FROM CITYPE WHERE STATUS = 'Y' AND APPRV_STS = 'A' AND ACTYPE = '" & v_strCITYPE & "'"
            '    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            '    If v_ds.Tables(0).Rows.Count <> 1 Then
            '        Return ERR_CF_CI_NOT_APPROVE
            '    End If
            'End If

            ''Kiểm tra MR có tồn tại
            'If v_strMRTYPE.Trim.Length > 0 Then
            '    v_strSQL = "SELECT COUNT(ACTYPE) FROM MRTYPE WHERE STATUS='Y' AND ACTYPE = '" & v_strMRTYPE & "'"
            '    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            '    If v_ds.Tables(0).Rows.Count = 1 Then
            '        If v_ds.Tables(0).Rows(0)(0) = 0 Then
            '            Return ERR_SA_PRODUCT_ACTYPE_NOTFOUND
            '        End If
            '    End If
            'End If

            ''Kiểm tra MR phai duyet
            'If v_strMRTYPE <> "" Then
            '    v_strSQL = "SELECT * FROM MRTYPE WHERE STATUS = 'Y' AND APPRV_STS = 'A' AND ACTYPE = '" & v_strMRTYPE & "'"
            '    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            '    If v_ds.Tables(0).Rows.Count <> 1 Then
            '        Return ERR_CF_MR_NOT_APPROVE
            '    End If
            'End If

            'If v_strLNTYPE.Trim.Length > 0 Then
            '    v_strSQL = "SELECT COUNT(ACTYPE) FROM LNTYPE WHERE STATUS='Y' AND ACTYPE = '" & v_strLNTYPE & "'"
            '    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            '    If v_ds.Tables(0).Rows.Count = 1 Then
            '        If v_ds.Tables(0).Rows(0)(0) = 0 Then
            '            Return ERR_SA_PRODUCT_ACTYPE_NOTFOUND
            '        End If
            '    End If
            'End If

            ''Kiểm tra LN phai duyet
            'If v_strLNTYPE <> "" Then
            '    v_strSQL = "SELECT * FROM LNTYPE WHERE STATUS = 'Y' AND APPRV_STS = 'A' AND ACTYPE = '" & v_strLNTYPE & "'"
            '    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            '    If v_ds.Tables(0).Rows.Count <> 1 Then
            '        Return ERR_CF_LN_NOT_APPROVE
            '    End If
            'End If

            'If v_strDFTYPE.Trim.Length > 0 Then
            '    v_strSQL = "SELECT COUNT(ACTYPE) FROM DFTYPE WHERE STATUS='Y' AND ACTYPE = '" & v_strDFTYPE & "'"
            '    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            '    If v_ds.Tables(0).Rows.Count = 1 Then
            '        If v_ds.Tables(0).Rows(0)(0) = 0 Then
            '            Return ERR_SA_PRODUCT_ACTYPE_NOTFOUND
            '        End If
            '    End If
            'End If

            ''Kiểm tra DF phai duyet
            'If v_strDFTYPE <> "" Then
            '    v_strSQL = "SELECT * FROM DFTYPE WHERE STATUS = 'Y' AND APPRV_STS = 'A' AND ACTYPE = '" & v_strDFTYPE & "'"
            '    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            '    If v_ds.Tables(0).Rows.Count <> 1 Then
            '        Return ERR_CF_DF_NOT_APPROVE
            '    End If
            'End If

            'Kiểm tra AD phai duyet
            If v_strADTYPE <> "" Then
                v_strSQL = "SELECT * FROM ADTYPE WHERE APPRV_STS = 'A' AND ACTYPE = '" & v_strADTYPE & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count <> 1 Then
                    Return ERR_CF_AD_NOT_APPROVE
                End If

                'Kiem tra trung ADTYPE
                v_strSQL = "SELECT Count(1) FROM AFIDTYPE WHERE ACTYPE = '" & v_strADTYPE & "' AND AFTYPE='" & v_strACTYPE & "' AND OBJNAME ='AD.ADTYPE'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If gf_CorrectNumericField(v_ds.Tables(0).Rows(0)(0)) > 0 Then
                    Return ERR_SA_ADTYPE_DUPLICATED
                End If
            End If

            'v_strSQL = "select count(1) EXISTSVAL from lntype where actype = '" & v_strT0LNTYPE & "' and chksysctrl = 'N' and rrtype = 'C'"
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'If Not v_ds.Tables(0).Rows(0)(0) > 0 Then
            '    Return ERR_MR_AFTYPE_T0LNTYPE_NOT_CHKSYSCTRL
            'End If

            'v_strSQL = "select count(1) EXISTSVAL from MRTYPE where actype = '" & v_strMRTYPE & "' and mrtype = 'T'"
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'If v_ds.Tables(0).Rows(0)(0) > 0 And v_strLNTYPE.Trim.Length = 0 Then
            '    Return ERR_MR_AFTYPE_LNTYPE_CANNOT_NULL
            'End If


            'v_strSQL = "select count(1) EXISTSVAL from MRTYPE where actype = '" & v_strMRTYPE & "' and mrtype <> 'N'"
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'If v_ds.Tables(0).Rows(0)(0) > 0 And v_strCOREBANK = "Y" Then
            '    Return ERR_MR_AFTYPE_COREBANK_VALUE_YES
            'End If

            'If v_strMRTYPE.Trim.Length > 0 Then
            '    v_strSQL = "SELECT MRTYPE FROM MRTYPE WHERE STATUS='Y' AND ACTYPE = '" & v_strMRTYPE & "'"
            '    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            '    If v_ds.Tables(0).Rows.Count = 1 Then
            '        If v_ds.Tables(0).Rows(0)("MRTYPE") = "T" Then
            '            'PHS khong dung cham thanh toan tien mua --> PHS phat vay truc tiep luon 
            '            ' --> TruongLD Comment
            '            'If v_strISTRFBUY = "Y" AndAlso v_dblTRFBUYEXT = 0 Then
            '            '    Return ERR_CF_AFTYPE_ISTRFBUY_EXT_MUST_GREATERTHAN_ZERO
            '            'End If
            '            'End TruongLD

            '            'Kiem tra loai hinh tieu khoan Margin phai link den LNTYPE.CHKSYSCTRL = Y
            '            v_strSQL = "SELECT CHKSYSCTRL, PRINPERIOD, PRINTFRQ1, PRINTFRQ2, PRINTFRQ3,PRINFRQ FROM LNTYPE WHERE ACTYPE =  '" & v_strLNTYPE & "'"
            '            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            '            v_strCHKSYSCTRL = v_ds.Tables(0).Rows(0)("CHKSYSCTRL")
            '            If Not v_strCHKSYSCTRL Is Nothing Then
            '                If v_strCHKSYSCTRL.Equals("Y") Then
            '                    '   Return ERR_AF_CHECK_CHKSYSCTRL
            '                    'Else
            '                    'Kiem tra cac tham so doi voi loai hinh margin.
            '                    '1. Kiem tra so ngay cho vay toi da.
            '                    Dim v_strMAXDEBTDAYS As String
            '                    v_obj.GetSysVar("MARGIN", "MAXDEBTDAYS", v_strMAXDEBTDAYS)
            '                    If CDbl(v_strMAXDEBTDAYS) < CDbl(v_ds.Tables(0).Rows(0)("PRINPERIOD")) _
            '                        Or CDbl(v_strMAXDEBTDAYS) < CDbl(v_ds.Tables(0).Rows(0)("PRINFRQ")) _
            '                        Or CDbl(v_strMAXDEBTDAYS) < CDbl(v_ds.Tables(0).Rows(0)("PRINTFRQ1")) _
            '                        Or CDbl(v_strMAXDEBTDAYS) < CDbl(v_ds.Tables(0).Rows(0)("PRINTFRQ1")) _
            '                        Or CDbl(v_strMAXDEBTDAYS) < CDbl(v_ds.Tables(0).Rows(0)("PRINTFRQ3")) Then
            '                        Return ERR_LN_PRINFRQ_OVER_LIMIT
            '                    End If
            '                End If
            '            End If
            '        Else
            '            If v_strISTRFBUY = "Y" Then
            '                Return ERR_CF_AFTYPE_ISTRFBUY_NOT_ALLOW
            '            End If
            '        End If
            '    Else
            '        Return ERR_SA_PRODUCT_ACTYPE_NOTFOUND
            '    End If

            'End If


            'Kiem tra: Neu tieu khoan la Margin Creditline -> Bat buoc la tu dong ung truoc AUTOADV = Y.
            v_strSQL = "SELECT A.MRTYPE FROM AFTYPE A WHERE A.ACTYPE = '" & v_strACTYPE & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If (v_ds.Tables(0).Rows.Count = 1) Then
                If (v_ds.Tables(0).Rows(0)("MRTYPE") = "T" Or v_ds.Tables(0).Rows(0)("MRTYPE") = "S") And v_strAUTOADV = "N" Then
                    Return ERR_CF_MARGIN_CL_AUTOADV_EQUAL_Y
                End If
            End If

            v_strSQL = "SELECT count(1) " & ControlChars.CrLf _
                    & "FROM ICCFTYPEDEF TYP, APPEVENTS " & ControlChars.CrLf _
                    & "            WHERE(TYP.EVENTCODE = APPEVENTS.EVENTCODE And TYP.MODCODE = APPEVENTS.MODCODE) " & ControlChars.CrLf _
                    & "AND TYP.MODCODE='CI' AND TYP.ACTYPE='" & v_strCITYPE & "' and TYP.EVENTCODE = 'CRINTACR' "
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count >= 1 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 AndAlso v_strCOREBANK = "Y" Then
                    Return ERR_MR_AFTYPE_COREBANK_VALUE_NO_WITH_CITYPE
                End If
            End If

            ''kiem tra loai hinh MR thuong thi k cho gan loai hinh LN,cho phep tra cham
            'v_strSQL = "select * from mrtype where actype='" & v_strMRTYPE & "' and mrtype='N'"
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'If v_ds.Tables(0).Rows.Count >= 1 Then
            '    If v_strLNTYPE <> "" Then
            '        Return ERR_MR_AFTYPE_NORMAL2
            '    End If
            '    If v_strISTRFBUY = "Y" Then
            '        Return ERR_MR_AFTYPE_NORMAL1
            '    End If
            'End If
            'v_strISTRFBUY="Y"
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        Finally
            If Not (v_ds Is Nothing) Then v_ds.Dispose()
        End Try
    End Function

    Overrides Function Add(ByRef v_strMessage As String) As Long
        Dim v_lngErrCode As Long

        Try
            v_lngErrCode = _CoreAdd(v_strMessage)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Dim v_strErrorSource, v_strErrorMessage As String
                v_strErrorSource = Me.ATTR_TABLE + ".Add"
                v_strErrorMessage = String.Empty

                LogError.Write("Error source: " + v_strErrorSource + vbNewLine _
                             + "Error code: " + v_lngErrCode.ToString() + vbNewLine _
                             + "Error message: " + v_strErrorMessage, "EventLogEntryType.Error")
                Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
                BuildXMLErrorException(pv_xmlDocument, v_strErrorSource, v_lngErrCode, v_strErrorMessage)
                v_strMessage = pv_xmlDocument.InnerXml
                Return v_lngErrCode
            End If
            ' Goi Ham dong bo AFSERISK


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

            'v_lngErrCode = v_obj.ExecuteOracleStored("cspks_saproc.fn_ApplySystemParam", v_arrPara, 0)

            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Overrides Function TYPECheckBeforeEdit(ByVal v_strMessage As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = ATTR_TABLE & ".SystemProcessBeforeEdit"
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strACTYPE, v_strCCYCD, v_strGLBANK, v_strGLGRP As String
            Dim v_strSQL, v_strFLDNAME, v_strFLDTYPE, v_strVALUE, v_strCHKSYSCTRL, v_strAUTOADV As String
            Dim v_strCITYPE, v_strSETYPE, v_strDFTYPE, v_strMRTYPE, v_strLNTYPE, v_strADTYPE, v_strMARGINTYPE, v_strT0LNTYPE, v_strCOREBANK, v_strISTRFBUY As String
            Dim v_dblTRFBUYEXT As Double
            v_strMRTYPE = String.Empty
            v_strLNTYPE = String.Empty
            v_strDFTYPE = String.Empty

            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If
            v_strACTYPE = String.Empty
            v_strCCYCD = String.Empty
            v_strGLBANK = String.Empty
            v_strGLGRP = String.Empty

            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strVALUE = .InnerText.ToString().Trim
                    Select Case Trim(v_strFLDNAME)
                        Case "ACTYPE"
                            v_strACTYPE = Trim(v_strVALUE)
                        Case "CCYCD"
                            v_strCCYCD = Trim(v_strVALUE)
                        Case "GLGRP"
                            v_strGLGRP = Trim(v_strVALUE)
                        Case "GLBANK"
                            v_strGLBANK = Trim(v_strVALUE)
                        Case "CITYPE"
                            v_strCITYPE = Trim(v_strVALUE)
                        Case "SETYPE"
                            v_strSETYPE = Trim(v_strVALUE)
                        Case "LNTYPE"
                            v_strLNTYPE = Trim(v_strVALUE)
                        Case "T0LNTYPE"
                            v_strT0LNTYPE = Trim(v_strVALUE)
                        Case "DFTYPE"
                            v_strDFTYPE = Trim(v_strVALUE)
                        Case "MRTYPE"
                            v_strMRTYPE = Trim(v_strVALUE)
                        Case "ADTYPE"
                            v_strADTYPE = Trim(v_strVALUE)
                        Case "COREBANK"
                            v_strCOREBANK = Trim(v_strVALUE)
                        Case "TRFBUYEXT"
                            v_dblTRFBUYEXT = CDbl(Trim(v_strVALUE))
                        Case "ISTRFBUY"
                            v_strISTRFBUY = Trim(v_strVALUE)
                        Case "AUTOADV"
                            v_strAUTOADV = Trim(v_strVALUE)
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


            'Kiểm tra CCYCD phải tồn tại
            If v_strCCYCD.Length > 0 Then
                v_strSQL = "SELECT COUNT(CCYCD) FROM SBCURRENCY WHERE CCYCD = '" & v_strCCYCD & "'AND ACTIVE='Y' "
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count >= 1 Then
                    If v_ds.Tables(0).Rows(0)(0) = 0 Then
                        Return ERR_SA_PRODUCT_CCYCD_NOTFOUND
                    End If
                End If
            End If

            'Kiểm tra SETYPE phai duyet
            If v_strSETYPE <> "" Then
                v_strSQL = "SELECT * FROM SETYPE WHERE STATUS = 'Y' AND APPRV_STS = 'A' AND ACTYPE = '" & v_strSETYPE & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count <> 1 Then
                    Return ERR_CF_SE_NOT_APPROVE
                End If
            End If

            ''Kiểm tra CI phai duyet
            'If v_strCITYPE <> "" Then
            '    v_strSQL = "SELECT * FROM CITYPE WHERE STATUS = 'Y' AND APPRV_STS = 'A' AND ACTYPE = '" & v_strCITYPE & "'"
            '    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            '    If v_ds.Tables(0).Rows.Count <> 1 Then
            '        Return ERR_CF_CI_NOT_APPROVE
            '    End If
            'End If


            v_strSQL = "SELECT count(1) " & ControlChars.CrLf _
                    & "FROM ICCFTYPEDEF TYP, APPEVENTS " & ControlChars.CrLf _
                    & "            WHERE(TYP.EVENTCODE = APPEVENTS.EVENTCODE And TYP.MODCODE = APPEVENTS.MODCODE) " & ControlChars.CrLf _
                    & "AND TYP.MODCODE='CI' AND TYP.ACTYPE='" & v_strCITYPE & "' and TYP.EVENTCODE = 'CRINTACR' "
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count >= 1 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 AndAlso v_strCOREBANK = "Y" Then
                    Return ERR_MR_AFTYPE_COREBANK_VALUE_NO_WITH_CITYPE
                End If
            End If


            ''Kiểm tra MR phai duyet
            'If v_strMRTYPE <> "" Then
            '    v_strSQL = "SELECT * FROM MRTYPE WHERE STATUS = 'Y' AND APPRV_STS = 'A' AND ACTYPE = '" & v_strMRTYPE & "'"
            '    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            '    If v_ds.Tables(0).Rows.Count <> 1 Then
            '        Return ERR_CF_MR_NOT_APPROVE
            '    End If
            'End If

            ''Kiểm tra LN phai duyet
            'If v_strLNTYPE <> "" Then
            '    v_strSQL = "SELECT * FROM LNTYPE WHERE STATUS = 'Y' AND APPRV_STS = 'A' AND ACTYPE = '" & v_strLNTYPE & "'"
            '    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            '    If v_ds.Tables(0).Rows.Count <> 1 Then
            '        Return ERR_CF_LN_NOT_APPROVE
            '    End If
            'End If

            ''Kiểm tra DF phai duyet
            'If v_strDFTYPE <> "" Then
            '    v_strSQL = "SELECT * FROM DFTYPE WHERE STATUS = 'Y' AND APPRV_STS = 'A' AND ACTYPE = '" & v_strDFTYPE & "'"
            '    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            '    If v_ds.Tables(0).Rows.Count <> 1 Then
            '        Return ERR_CF_DF_NOT_APPROVE
            '    End If
            'End If

            'Kiểm tra AD phai duyet
            If v_strADTYPE <> "" Then
                v_strSQL = "SELECT * FROM ADTYPE WHERE APPRV_STS = 'A' AND ACTYPE = '" & v_strADTYPE & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count <> 1 Then
                    Return ERR_CF_AD_NOT_APPROVE
                End If

                'Kiem tra trung ADTYPE
                v_strSQL = "SELECT Count(1) FROM AFIDTYPE WHERE ACTYPE = '" & v_strADTYPE & "' AND AFTYPE='" & v_strACTYPE & "' AND OBJNAME ='AD.ADTYPE'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If gf_CorrectNumericField(v_ds.Tables(0).Rows(0)(0)) > 0 Then
                    Return ERR_SA_ADTYPE_DUPLICATED
                End If
            End If

            'v_strSQL = "select count(1) EXISTSVAL from lnmast where actype = '" & v_strLNTYPE & "' and prinnml + prinovd > 0"
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'If v_ds.Tables(0).Rows(0)("EXISTSVAL") > 0 Then
            '    v_strSQL = "SELECT MRTYPE FROM MRTYPE WHERE ACTYPE = '" & v_strMRTYPE & "'"
            '    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            '    If v_ds.Tables(0).Rows.Count > 0 Then
            '        v_strMARGINTYPE = CStr(v_ds.Tables(0).Rows(0)("MRTYPE"))
            '    End If

            '    v_strSQL = "select MRTYPE from mrtype where exists (select 1 from aftype where aftype.mrtype = mrtype.actype and aftype.actype = '" & v_strACTYPE & "')"
            '    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            '    If v_ds.Tables(0).Rows.Count > 0 Then
            '        If v_strMARGINTYPE = "N" And CStr(v_ds.Tables(0).Rows(0)("MRTYPE")) <> "N" Then
            '            Return ERR_MR_AFTYPE_HAS_BEEN_USED
            '        ElseIf (v_strMARGINTYPE = "S" Or v_strMARGINTYPE = "T") And (CStr(v_ds.Tables(0).Rows(0)("MRTYPE")) <> "S" And CStr(v_ds.Tables(0).Rows(0)("MRTYPE")) <> "T") Then
            '            Return ERR_MR_AFTYPE_HAS_BEEN_USED
            '        End If
            '    End If
            'End If

            v_strSQL = "select count(1) EXISTSVAL from afmast where actype = '" & v_strACTYPE & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'If v_ds.Tables(0).Rows(0)(0) > 0 Then
            '    v_strSQL = "select count(1) from mrtype mr where actype = '" & v_strMRTYPE & "' " & ControlChars.CrLf _
            '            & "and exists (select 1 from aftype aft, mrtype mrt where aft.actype = '" & v_strACTYPE & "' and aft.mrtype = mrt.actype and mr.mrtype = mrt.mrtype)"
            '    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            '    If Not v_ds.Tables(0).Rows(0)(0) > 0 Then
            '        Return ERR_MR_AFTYPE_HAS_BEEN_USED
            '    End If
            'End If

            'v_strSQL = "select count(1) EXISTSVAL from lntype where actype = '" & v_strT0LNTYPE & "' and chksysctrl = 'N' and rrtype = 'C'"
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'If Not v_ds.Tables(0).Rows(0)(0) > 0 Then
            '    Return ERR_MR_AFTYPE_T0LNTYPE_NOT_CHKSYSCTRL
            'End If

            'v_strSQL = "select count(1) EXISTSVAL from MRTYPE where actype = '" & v_strMRTYPE & "' and mrtype = 'T'"
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'If v_ds.Tables(0).Rows(0)(0) > 0 And v_strLNTYPE.Trim.Length = 0 Then
            '    Return ERR_MR_AFTYPE_LNTYPE_CANNOT_NULL
            'End If


            'v_strSQL = "select count(1) EXISTSVAL from MRTYPE where actype = '" & v_strMRTYPE & "' and mrtype <> 'N'"
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'If v_ds.Tables(0).Rows(0)(0) > 0 And v_strCOREBANK = "Y" Then
            '    Return ERR_MR_AFTYPE_COREBANK_VALUE_YES
            'End If

            'If v_strMRTYPE.Trim.Length > 0 Then
            '    v_strSQL = "SELECT MRTYPE FROM MRTYPE WHERE STATUS='Y' AND ACTYPE = '" & v_strMRTYPE & "'"
            '    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            '    If v_ds.Tables(0).Rows.Count = 1 Then
            '        If v_ds.Tables(0).Rows(0)("MRTYPE") = "T" Then
            '            'If v_strISTRFBUY = "Y" AndAlso v_dblTRFBUYEXT = 0 Then
            '            '    Return ERR_CF_AFTYPE_ISTRFBUY_EXT_MUST_GREATERTHAN_ZERO
            '            'End If

            '            'Kiem tra loai hinh tieu khoan Margin phai link den LNTYPE.CHKSYSCTRL = Y
            '            v_strSQL = "SELECT CHKSYSCTRL, PRINPERIOD, PRINTFRQ1, PRINTFRQ2, PRINTFRQ3,PRINFRQ FROM LNTYPE WHERE ACTYPE =  '" & v_strLNTYPE & "'"
            '            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            '            v_strCHKSYSCTRL = v_ds.Tables(0).Rows(0)("CHKSYSCTRL")
            '            If Not v_strCHKSYSCTRL Is Nothing Then
            '                If v_strCHKSYSCTRL.Equals("Y") Then
            '                    '   Return ERR_AF_CHECK_CHKSYSCTRL
            '                    'Else
            '                    'Kiem tra cac tham so doi voi loai hinh margin.
            '                    '1. Kiem tra so ngay cho vay toi da.
            '                    Dim v_strMAXDEBTDAYS As String
            '                    v_obj.GetSysVar("MARGIN", "MAXDEBTDAYS", v_strMAXDEBTDAYS)
            '                    If CDbl(v_strMAXDEBTDAYS) < CDbl(v_ds.Tables(0).Rows(0)("PRINPERIOD")) _
            '                        Or CDbl(v_strMAXDEBTDAYS) < CDbl(v_ds.Tables(0).Rows(0)("PRINFRQ")) _
            '                        Or CDbl(v_strMAXDEBTDAYS) < CDbl(v_ds.Tables(0).Rows(0)("PRINTFRQ1")) _
            '                        Or CDbl(v_strMAXDEBTDAYS) < CDbl(v_ds.Tables(0).Rows(0)("PRINTFRQ1")) _
            '                        Or CDbl(v_strMAXDEBTDAYS) < CDbl(v_ds.Tables(0).Rows(0)("PRINTFRQ3")) Then
            '                        Return ERR_LN_PRINFRQ_OVER_LIMIT
            '                    End If
            '                End If
            '            End If
            '        Else
            '            If v_strISTRFBUY = "Y" Then
            '                Return ERR_CF_AFTYPE_ISTRFBUY_NOT_ALLOW
            '            End If
            '        End If
            '    Else
            '        Return ERR_SA_PRODUCT_ACTYPE_NOTFOUND
            '    End If
            'End If

            '</ PHS co' san pham 1 af dung chung nhieu LN chung Pool Cty --> bo chan, chi chan doi voi Pool ngan hang
            'v_strSQL = "select count(1) EXISTSVAL from lntype lnt0 " & ControlChars.CrLf _
            '        & "where lnt0.actype = '" & v_strLNTYPE & "' " & ControlChars.CrLf _
            '        & "and exists (select 1 from afidtype afi, lntype lnt1  " & ControlChars.CrLf _
            '        & "where afi.actype = lnt1.actype " & ControlChars.CrLf _
            '        & " and afi.objname = 'LN.LNTYPE' " & ControlChars.CrLf _
            '        & " and afi.aftype = '" & v_strACTYPE & "' " & ControlChars.CrLf _
            '        & " and lnt1.rrtype = lnt0.rrtype " & ControlChars.CrLf _
            '        & " and (lnt0.rrtype = 'B' and lnt0.custbank = lnt1.custbank) " & ControlChars.CrLf _
            '        & "     )"
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'If v_ds.Tables(0).Rows(0)("EXISTSVAL") > 0 Then
            '    Return ERR_SA_DUPLICATE_LOAN_SOURCE
            'End If
            '/>

            'Kiem tra: Neu tieu khoan la Margin Creditline -> Bat buoc la tu dong ung truoc AUTOADV = Y.
            v_strSQL = "SELECT A.MRTYPE FROM AFTYPE A WHERE A.ACTYPE = '" & v_strACTYPE & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If (v_ds.Tables(0).Rows.Count = 1) Then
                If (v_ds.Tables(0).Rows(0)("MRTYPE") = "T" Or v_ds.Tables(0).Rows(0)("MRTYPE") = "S") And v_strAUTOADV = "N" Then
                    Return ERR_CF_MARGIN_CL_AUTOADV_EQUAL_Y
                End If
            End If
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        Finally
            If Not (v_ds Is Nothing) Then v_ds.Dispose()
        End Try
    End Function

    Overridable Function Edit(ByRef v_strMessage As String) As Long
        Dim v_lngErrCode As Long
        Try
            v_lngErrCode = _CoreEdit(v_strMessage)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Dim v_strErrorSource, v_strErrorMessage As String
                v_strErrorSource = Me.ATTR_TABLE + ".Edit"
                v_strErrorMessage = String.Empty

                LogError.Write("Error source: " + v_strErrorSource + vbNewLine _
                             + "Error code: " + v_lngErrCode.ToString() + vbNewLine _
                             + "Error message: " + v_strErrorMessage, "EventLogEntryType.Error")
                Dim pv_xmlDocumentErr As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
                BuildXMLErrorException(pv_xmlDocumentErr, v_strErrorSource, v_lngErrCode, v_strErrorMessage)
                v_strMessage = pv_xmlDocumentErr.InnerXml
                Return v_lngErrCode
            End If

            Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

            Dim v_nodeList As Xml.XmlNodeList
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strSQL, v_strFLDNAME, v_strFLDTYPE, v_strVALUE, v_strOLDVAL As String
            Dim v_strLNTYPE, v_strOLDLNTYPE As String

            v_strLNTYPE = String.Empty


            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strOLDVAL = CStr(CType(.Attributes.GetNamedItem("oldval"), Xml.XmlAttribute).Value)
                    v_strVALUE = .InnerText.ToString().Trim
                    Select Case Trim(v_strFLDNAME)
                        Case "LNTYPE"
                            v_strLNTYPE = Trim(v_strVALUE)
                            v_strOLDLNTYPE = Trim(v_strOLDVAL)
                    End Select
                End With
            Next
            If v_strLNTYPE <> v_strOLDLNTYPE Then
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
            End If

            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Overrides Function TYPECheckBeforeDelete(ByVal v_strMessage As String) As Long
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

            'Kiểm tra xem Mã dữ liệu bị xoá có nằm trong bảng __MAST khác hay không
            v_strSQL = "SELECT COUNT(ACTYPE) FROM " & ATTR_TABLE.Substring(0, 2) & "MAST WHERE 0=0 AND " & v_strClause
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 1 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_SA_PRODUCT_HAS_CONSTRAINT
                End If
            End If

            'Kiem tra ACTYPE co con du lieu lien quan trong bang ICCFTYPEDEF hay khong?
            v_strSQL = "SELECT COUNT(ACTYPE) FROM ICCFTYPEDEF WHERE MODCODE = '" & ATTR_TABLE.Substring(0, 2) & "' AND " & v_strClause
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 1 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_SA_PRODUCT_HAS_CONSTRAINT
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
