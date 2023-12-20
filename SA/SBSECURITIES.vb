Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Public Class SBSECURITIES
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "SBSECURITIES"
    End Sub

#Region " Overrides functions "
    Overrides Function CheckBeforeAdd(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strCODEID, v_strISSUERID, v_strSYMBOL, v_strTRADEPLACE, v_strMANAGEMENTTYPE As String
            Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE, v_strSECTYPE As String
            Dim v_strSQL As String
            Dim v_strSTATUS, v_strCAREBY, v_strEXPDATE, v_strDEPOSITORY As String
            v_strCAREBY = ""
            Dim v_strISSUEDATE As String
            Dim v_dblVALUE, v_DBLPARVALUE, v_dblINTRATE, v_dblCHKRATE, v_dblFOREIGNRATE, v_dblINTPERIOD As Double
            

            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If

            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strFLDTYPE = CStr(CType(.Attributes.GetNamedItem("fldtype"), Xml.XmlAttribute).Value)
                    v_strVALUE = .InnerText.ToString()
                    If v_strFLDTYPE = "System.Double" Then
                        'v_strVALUE = vbNullString
                        'v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                        'Ngay 02/03/2017 NamTv dieu chinh khi gia tri chuoi bang rong gan ve 0
                        v_strVALUE = IIf(v_strVALUE = vbNullString, 0, v_strVALUE)
                        'v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                        v_dblVALUE = IIf(IsNumeric(v_strVALUE), CDbl(v_strVALUE), 0)

                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If
                    Select Case Trim(v_strFLDNAME)
                        Case "CODEID"
                            v_strCODEID = Trim(v_strVALUE)
                        Case "ISSUERID"
                            v_strISSUERID = Trim(v_strVALUE)
                        Case "SYMBOL"
                            v_strSYMBOL = Trim(v_strVALUE)
                        Case "SECTYPE"
                            v_strSECTYPE = Trim(v_strVALUE)
                        Case "TRADEPLACE"
                            v_strTRADEPLACE = Trim(v_strVALUE)
                        Case "PARVALUE"
                            v_DBLPARVALUE = v_dblVALUE

                        Case "INTRATE"
                            v_dblINTRATE = v_dblVALUE
                        Case "STATUS"
                            v_strSTATUS = Trim(v_strVALUE)
                        Case "CAREBY"
                            v_strCAREBY = Trim(v_strVALUE)
                        Case "EXPDATE"
                            v_strEXPDATE = Trim(v_strVALUE)
                        Case "DEPOSITORY"
                            v_strDEPOSITORY = Trim(v_strVALUE)
                        Case "CHKRATE"
                            v_dblCHKRATE = v_dblVALUE

                        Case "INTPERIOD"
                            v_dblINTPERIOD = v_dblVALUE
                        Case "ISSUEDATE"
                            v_strISSUEDATE = Trim(v_strVALUE)
                        Case "FOREIGNRATE"
                            v_dblFOREIGNRATE = v_dblVALUE
                        Case "MANAGEMENTTYPE"
                            v_strMANAGEMENTTYPE = Trim(v_strVALUE)

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
            'Nha phat hanh chi phat hang duy nhat mot loai co phieu
            If v_strSECTYPE = "001" Then
                v_strSQL = "SELECT COUNT(ISSUERID) FROM  " & ATTR_TABLE & " WHERE SECTYPE = '001' AND ISSUERID='" & v_strISSUERID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count = 1 Then
                    If v_ds.Tables(0).Rows(0)(0) > 0 Then
                        Return ERR_SA_ISSUER_HAS_ONE_NORMALSHARE
                    End If
                End If
            End If
            'Kiểm tra CODEID không được trùng
            If v_strCODEID.Length > 0 Then
                v_strSQL = "SELECT COUNT(CODEID) FROM " & ATTR_TABLE & " WHERE CODEID = '" & v_strCODEID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count = 1 Then
                    If v_ds.Tables(0).Rows(0)(0) > 0 Then
                        Return ERR_SA_INTERNAL_CODE_ISDUPLICATED
                    End If
                End If
            End If
            'Ki?m tra ISSUERID ph?i t?n t?i
            If v_strISSUERID.Length > 0 Then
                v_strSQL = "SELECT COUNT(ISSUERID) FROM ISSUERS WHERE ISSUERID = '" & v_strISSUERID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count >= 1 Then
                    If v_ds.Tables(0).Rows(0)(0) = 0 Then
                        Return ERR_SA_ISSUERID_NOTFOUND
                    End If
                End If
            End If
            'Kiem tra SYMBOL khong duoc trung
            If v_strISSUERID.Length > 0 Then
                v_strSQL = "SELECT COUNT(SYMBOL) FROM SBSECURITIES WHERE SYMBOL = '" & v_strSYMBOL & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count >= 1 Then
                    If v_ds.Tables(0).Rows(0)(0) > 0 Then
                        Return ERR_SA_SYMBOL_DUPLICATED
                    End If
                End If
            End If

            'tu dong them du lieu 2 bang SECURITIES_TICKSIZE va SECURITIES_INFO
            Dim v_objRptParam As ReportParameters
            Dim v_arrRptPara() As ReportParameters

            ReDim v_arrRptPara(15)

            '0. Condition value
            v_objRptParam = New ReportParameters
            v_objRptParam.ParamName = "CODEID"
            v_objRptParam.ParamValue = v_strCODEID
            v_objRptParam.ParamSize = CStr(v_strCODEID.Length)
            v_objRptParam.ParamType = GetType(System.String).Name
            v_arrRptPara(0) = v_objRptParam

            v_objRptParam = New ReportParameters
            v_objRptParam.ParamName = "SYMBOL"
            v_objRptParam.ParamValue = v_strSYMBOL
            v_objRptParam.ParamSize = CStr(v_strSYMBOL.Length)
            v_objRptParam.ParamType = GetType(System.String).Name
            v_arrRptPara(1) = v_objRptParam

            v_objRptParam = New ReportParameters
            v_objRptParam.ParamName = "TRADEPLACE"
            v_objRptParam.ParamValue = v_strTRADEPLACE
            v_objRptParam.ParamSize = CStr(v_strTRADEPLACE.Length)
            v_objRptParam.ParamType = GetType(System.String).Name
            v_arrRptPara(2) = v_objRptParam

            'SECTYPE
            v_objRptParam = New ReportParameters
            v_objRptParam.ParamName = "SECTYPE"
            v_objRptParam.ParamValue = v_strSECTYPE
            v_objRptParam.ParamSize = CStr(v_strSECTYPE.Length)
            v_objRptParam.ParamType = GetType(System.String).Name
            v_arrRptPara(3) = v_objRptParam

            '
            v_objRptParam = New ReportParameters
            v_objRptParam.ParamName = "PARVALUE"
            v_objRptParam.ParamValue = v_DBLPARVALUE
            v_objRptParam.ParamSize = 100
            v_objRptParam.ParamType = "Double"
            v_arrRptPara(4) = v_objRptParam

            'INTRATE
            v_objRptParam = New ReportParameters
            v_objRptParam.ParamName = "INTRATE"
            v_objRptParam.ParamValue = v_dblINTRATE
            v_objRptParam.ParamSize = 100
            v_objRptParam.ParamType = "Double"
            v_arrRptPara(5) = v_objRptParam

            'STATUS
            v_objRptParam = New ReportParameters
            v_objRptParam.ParamName = "STATUS"
            v_objRptParam.ParamValue = v_strSTATUS
            v_objRptParam.ParamSize = CStr(v_strSTATUS.Length)
            v_objRptParam.ParamType = GetType(System.String).Name
            v_arrRptPara(6) = v_objRptParam

            'CAREBY
            v_objRptParam = New ReportParameters
            v_objRptParam.ParamName = "CAREBY"
            v_objRptParam.ParamValue = v_strCAREBY
            v_objRptParam.ParamSize = CStr(v_strCAREBY.Length)
            v_objRptParam.ParamType = GetType(System.String).Name
            v_arrRptPara(7) = v_objRptParam

            v_objRptParam = New ReportParameters
            v_objRptParam.ParamName = "EXPDATE"
            v_objRptParam.ParamValue = v_strEXPDATE
            v_objRptParam.ParamSize = CStr(v_strEXPDATE.Length)
            v_objRptParam.ParamType = GetType(System.String).Name
            v_arrRptPara(8) = v_objRptParam

            v_objRptParam = New ReportParameters
            v_objRptParam.ParamName = "DEPOSITORY"
            v_objRptParam.ParamValue = v_strDEPOSITORY
            v_objRptParam.ParamSize = CStr(v_strDEPOSITORY.Length)
            v_objRptParam.ParamType = GetType(System.String).Name
            v_arrRptPara(9) = v_objRptParam

            'SECTYPE
            v_objRptParam = New ReportParameters
            v_objRptParam.ParamName = "CHKRATE"
            v_objRptParam.ParamValue = v_dblCHKRATE
            v_objRptParam.ParamSize = 100
            v_objRptParam.ParamType = "Double"
            v_arrRptPara(10) = v_objRptParam

            'INTPERIOD
            v_objRptParam = New ReportParameters
            v_objRptParam.ParamName = "INTPERIOD"
            v_objRptParam.ParamValue = v_dblINTPERIOD
            v_objRptParam.ParamSize = 100
            v_objRptParam.ParamType = "Double"
            v_arrRptPara(11) = v_objRptParam

            'ISSUEDATE
            v_objRptParam = New ReportParameters
            v_objRptParam.ParamName = "ISSUEDATE"
            v_objRptParam.ParamValue = v_strISSUEDATE
            v_objRptParam.ParamSize = CStr(v_strISSUEDATE.Length)
            v_objRptParam.ParamType = GetType(System.String).Name
            v_arrRptPara(12) = v_objRptParam

            'ISSUERID
            v_objRptParam = New ReportParameters
            v_objRptParam.ParamName = "ISSUERID"
            v_objRptParam.ParamValue = v_strISSUERID
            v_objRptParam.ParamSize = CStr(v_strISSUERID.Length)
            v_objRptParam.ParamType = GetType(System.String).Name
            v_arrRptPara(13) = v_objRptParam

            'FOREIGNRATE
            v_objRptParam = New ReportParameters
            v_objRptParam.ParamName = "FOREIGNRATE"
            v_objRptParam.ParamValue = v_dblFOREIGNRATE
            v_objRptParam.ParamSize = 100
            v_objRptParam.ParamType = "Double"
            v_arrRptPara(14) = v_objRptParam

            'MANAGEMENTTYPE
            v_objRptParam = New ReportParameters
            v_objRptParam.ParamName = "MANAGEMENTTYPE"
            v_objRptParam.ParamValue = v_strMANAGEMENTTYPE
            v_objRptParam.ParamSize = CStr(v_strMANAGEMENTTYPE.Length)
            v_objRptParam.ParamType = GetType(System.String).Name
            v_arrRptPara(15) = v_objRptParam


            v_obj.ExecuteStoredNonQuerry("PRC_UPDATE_TICKSIZE", v_arrRptPara)
            'Buld XML data

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
            Dim v_strLocal, v_strISSUERID, v_strCODEID As String
            Dim v_strFLDNAME, v_strSECTYPE, v_strFLDTYPE, v_strVALUE, v_strSYMBOL, v_strTRADEPLACE, v_strOldTradeplace As String
            Dim v_strSQL As String
            Dim v_dblVALUE, v_DBLPARVALUE, v_dblINTRATE, v_dblCHKRATE, v_dblFOREIGNRATE, v_dblINTPERIOD As Double
            Dim v_strSTATUS, v_strCAREBY, v_strEXPDATE, v_strDEPOSITORY As String
            Dim v_strISSUEDATE, v_strISSEDEPOFEE As String
            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If

            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            Dim v_strTLID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTLID).Value
            For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strVALUE = .InnerText.ToString()

                    Select Case Trim(v_strFLDNAME)
                        Case "CODEID"
                            v_strCODEID = Trim(v_strVALUE)
                        Case "ISSUERID"
                            v_strISSUERID = Trim(v_strVALUE)
                        Case "SYMBOL"
                            v_strSYMBOL = Trim(v_strVALUE)
                        Case "SECTYPE"
                            v_strSECTYPE = Trim(v_strVALUE)
                        Case "TRADEPLACE"
                            v_strTRADEPLACE = Trim(v_strVALUE)
                        Case "PARVALUE"
                            v_DBLPARVALUE = v_dblVALUE

                        Case "INTRATE"
                            v_dblINTRATE = v_dblVALUE
                        Case "STATUS"
                            v_strSTATUS = Trim(v_strVALUE)
                        Case "CAREBY"
                            v_strCAREBY = Trim(v_strVALUE)
                        Case "EXPDATE"
                            v_strEXPDATE = Trim(v_strVALUE)
                        Case "DEPOSITORY"
                            v_strDEPOSITORY = Trim(v_strVALUE)
                        Case "CHKRATE"
                            v_dblCHKRATE = v_dblVALUE

                        Case "INTPERIOD"
                            v_dblINTPERIOD = v_dblVALUE
                        Case "ISSUEDATE"
                            v_strISSUEDATE = Trim(v_strVALUE)
                        Case "FOREIGNRATE"
                            v_dblFOREIGNRATE = v_dblVALUE
                        Case "ISSEDEPOFEE"
                            v_strISSEDEPOFEE = v_strVALUE

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
            If v_strSECTYPE = "001" Then
                v_strSQL = "SELECT COUNT(ISSUERID) FROM  " & ATTR_TABLE & " WHERE CODEID <> '" & v_strCODEID & "' AND SECTYPE = '001' AND ISSUERID='" & v_strISSUERID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count = 1 Then
                    If v_ds.Tables(0).Rows(0)(0) > 1 Then
                        Return ERR_SA_INTERNAL_CODE_ISDUPLICATED
                    End If
                End If
            End If

            'Ki?m tra ISSUERID ph?i t?n t?i
            If v_strISSUERID.Length > 0 Then
                v_strSQL = "SELECT COUNT(ISSUERID) FROM ISSUERS WHERE ISSUERID = '" & v_strISSUERID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count >= 1 Then
                    If v_ds.Tables(0).Rows(0)(0) = 0 Then
                        Return ERR_SA_ISSUERID_NOTFOUND
                    End If
                End If
            End If
            'Kiem tra SYMBOL khong duoc trung
            If v_strISSUERID.Length > 0 Then
                v_strSQL = "SELECT COUNT(SYMBOL) FROM SBSECURITIES WHERE CODEID <> '" & v_strCODEID & "' AND SYMBOL = '" & v_strSYMBOL & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count >= 1 Then
                    If v_ds.Tables(0).Rows(0)(0) > 0 Then
                        Return ERR_SA_SYMBOL_DUPLICATED
                    End If
                End If
            End If
            ' PhuongHT add
            ' neu la thay doi thong tin san thi pai thay doi tradelot va securitites_ticksize
            v_strSQL = "SELECT TRADEPLACE FROM SBSECURITIES WHERE CODEID='" & v_strCODEID & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_strOldTradeplace = v_ds.Tables(0).Rows(0)("TRADEPLACE").ToString()
                If (v_strOldTradeplace <> v_strTRADEPLACE) Then
                    'tu dong them du lieu 2 bang SECURITIES_TICKSIZE va SECURITIES_INFO
                    Dim v_objRptParam As ReportParameters
                    Dim v_arrRptPara() As ReportParameters

                    ReDim v_arrRptPara(16)

                    '0. Condition value
                    v_objRptParam = New ReportParameters
                    v_objRptParam.ParamName = "CODEID"
                    v_objRptParam.ParamValue = v_strCODEID
                    v_objRptParam.ParamSize = CStr(v_strCODEID.Length)
                    v_objRptParam.ParamType = GetType(System.String).Name
                    v_arrRptPara(0) = v_objRptParam

                    v_objRptParam = New ReportParameters
                    v_objRptParam.ParamName = "SYMBOL"
                    v_objRptParam.ParamValue = v_strSYMBOL
                    v_objRptParam.ParamSize = CStr(v_strSYMBOL.Length)
                    v_objRptParam.ParamType = GetType(System.String).Name
                    v_arrRptPara(1) = v_objRptParam

                    v_objRptParam = New ReportParameters
                    v_objRptParam.ParamName = "TRADEPLACE"
                    v_objRptParam.ParamValue = v_strTRADEPLACE
                    v_objRptParam.ParamSize = CStr(v_strTRADEPLACE.Length)
                    v_objRptParam.ParamType = GetType(System.String).Name
                    v_arrRptPara(2) = v_objRptParam

                    'SECTYPE
                    v_objRptParam = New ReportParameters
                    v_objRptParam.ParamName = "SECTYPE"
                    v_objRptParam.ParamValue = v_strSECTYPE
                    v_objRptParam.ParamSize = CStr(v_strSECTYPE.Length)
                    v_objRptParam.ParamType = GetType(System.String).Name
                    v_arrRptPara(3) = v_objRptParam

                    '
                    v_objRptParam = New ReportParameters
                    v_objRptParam.ParamName = "PARVALUE"
                    v_objRptParam.ParamValue = v_DBLPARVALUE
                    v_objRptParam.ParamSize = 100
                    v_objRptParam.ParamType = "Double"
                    v_arrRptPara(4) = v_objRptParam

                    'INTRATE
                    v_objRptParam = New ReportParameters
                    v_objRptParam.ParamName = "INTRATE"
                    v_objRptParam.ParamValue = v_dblINTRATE
                    v_objRptParam.ParamSize = 100
                    v_objRptParam.ParamType = "Double"
                    v_arrRptPara(5) = v_objRptParam

                    'STATUS
                    v_objRptParam = New ReportParameters
                    v_objRptParam.ParamName = "STATUS"
                    v_objRptParam.ParamValue = v_strSTATUS
                    v_objRptParam.ParamSize = CStr(v_strSTATUS.Length)
                    v_objRptParam.ParamType = GetType(System.String).Name
                    v_arrRptPara(6) = v_objRptParam

                    'CAREBY
                    v_objRptParam = New ReportParameters
                    v_objRptParam.ParamName = "CAREBY"
                    v_objRptParam.ParamValue = v_strCAREBY
                    v_objRptParam.ParamSize = 100
                    v_objRptParam.ParamType = GetType(System.String).Name
                    v_arrRptPara(7) = v_objRptParam

                    v_objRptParam = New ReportParameters
                    v_objRptParam.ParamName = "EXPDATE"
                    v_objRptParam.ParamValue = v_strEXPDATE
                    v_objRptParam.ParamSize = CStr(v_strEXPDATE.Length)
                    v_objRptParam.ParamType = GetType(System.String).Name
                    v_arrRptPara(8) = v_objRptParam

                    v_objRptParam = New ReportParameters
                    v_objRptParam.ParamName = "DEPOSITORY"
                    v_objRptParam.ParamValue = v_strDEPOSITORY
                    v_objRptParam.ParamSize = CStr(v_strDEPOSITORY.Length)
                    v_objRptParam.ParamType = GetType(System.String).Name
                    v_arrRptPara(9) = v_objRptParam

                    'SECTYPE
                    v_objRptParam = New ReportParameters
                    v_objRptParam.ParamName = "CHKRATE"
                    v_objRptParam.ParamValue = v_dblCHKRATE
                    v_objRptParam.ParamSize = 100
                    v_objRptParam.ParamType = "Double"
                    v_arrRptPara(10) = v_objRptParam

                    'INTPERIOD
                    v_objRptParam = New ReportParameters
                    v_objRptParam.ParamName = "INTPERIOD"
                    v_objRptParam.ParamValue = v_dblINTPERIOD
                    v_objRptParam.ParamSize = 100
                    v_objRptParam.ParamType = "Double"
                    v_arrRptPara(11) = v_objRptParam

                    'ISSUEDATE
                    v_objRptParam = New ReportParameters
                    v_objRptParam.ParamName = "ISSUEDATE"
                    v_objRptParam.ParamValue = v_strISSUEDATE
                    v_objRptParam.ParamSize = CStr(v_strISSUEDATE.Length)
                    v_objRptParam.ParamType = GetType(System.String).Name
                    v_arrRptPara(12) = v_objRptParam

                    'ISSUERID
                    v_objRptParam = New ReportParameters
                    v_objRptParam.ParamName = "ISSUERID"
                    v_objRptParam.ParamValue = v_strISSUERID
                    v_objRptParam.ParamSize = CStr(v_strISSUERID.Length)
                    v_objRptParam.ParamType = GetType(System.String).Name
                    v_arrRptPara(13) = v_objRptParam

                    'FOREIGNRATE
                    v_objRptParam = New ReportParameters
                    v_objRptParam.ParamName = "FOREIGNRATE"
                    v_objRptParam.ParamValue = v_dblFOREIGNRATE
                    v_objRptParam.ParamSize = 100
                    v_objRptParam.ParamType = "Double"
                    v_arrRptPara(14) = v_objRptParam

                    'ISSEDEPOFEE
                    v_objRptParam = New ReportParameters
                    v_objRptParam.ParamName = "ISSEDEPOFEE"
                    v_objRptParam.ParamValue = v_strISSEDEPOFEE
                    v_objRptParam.ParamSize = CStr(v_strISSEDEPOFEE.Length)
                    v_objRptParam.ParamType = GetType(System.String).Name
                    v_arrRptPara(15) = v_objRptParam
                    'TLID
                    v_objRptParam = New ReportParameters
                    v_objRptParam.ParamName = "TLID"
                    v_objRptParam.ParamValue = v_strTLID
                    v_objRptParam.ParamSize = CStr(v_strTLID.Length)
                    v_objRptParam.ParamType = GetType(System.String).Name
                    v_arrRptPara(16) = v_objRptParam

                    v_obj.ExecuteStoredNonQuerry("PRC_UPDATE_SEC_EDIT_TRAPLACE", v_arrRptPara)
                    'Buld XML data
                End If

            End If
            ' end of PhuongHT add

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

    Overrides Function CheckBeforeDelete(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        'Return 0
        Dim v_strObjMsg As String
        Dim v_ds As DataSet

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strClause, v_strCurrentBdsid As String
            Dim v_strLocal As String
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
            If Not (v_attrColl.GetNamedItem(gc_AtributeBRID) Is Nothing) Then
                v_strCurrentBdsid = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeBRID), Xml.XmlAttribute).Value)
            Else
                v_strCurrentBdsid = String.Empty
            End If

            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            If v_strCurrentBdsid <> String.Empty Then

                'Kiem tra co con du lieu trong bang SEMAST khong
                v_strSQL = "SELECT COUNT(CODEID) FROM SEMAST WHERE 0=0 AND " & v_strClause
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count = 1 Then
                    If v_ds.Tables(0).Rows(0)(0) > 0 Then
                        Return ERR_SA_CODEID_HAS_CONSTRAINT
                    End If
                End If
            End If


            ''Kiem tra co con du lieu trong bang CLMAST khong
            'v_strSQL = "SELECT COUNT(CODEID) FROM CLMAST WHERE 0=0 AND " & v_strClause
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'If v_ds.Tables(0).Rows.Count = 1 Then
            '    If v_ds.Tables(0).Rows(0)(0) > 0 Then
            '        Return ERR_SA_CODEID_HAS_CONSTRAINT
            '    End If
            'End If

            '    'Kiem tra co con du lieu trong bang SECURITIES_INFO khong
            '    v_strSQL = "SELECT COUNT(CODEID) FROM SECURITIES_INFO WHERE 0=0 AND " & v_strClause
            '    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            '    If v_ds.Tables(0).Rows.Count = 1 Then
            '        If v_ds.Tables(0).Rows(0)(0) > 0 Then
            '            Return ERR_SA_CODEID_HAS_CONSTRAINT
            '        End If
            '    End If

            '    'Kiem tra co con du lieu trong bang SECURITIES_INFO_DETAIL khong
            '    v_strSQL = "SELECT COUNT(CODEID) FROM SECURITIES_INFO_DETAIL WHERE 0=0 AND " & v_strClause
            '    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            '    If v_ds.Tables(0).Rows.Count = 1 Then
            '        If v_ds.Tables(0).Rows(0)(0) > 0 Then
            '            Return ERR_SA_CODEID_HAS_CONSTRAINT
            '        End If
            '    End If

            '    'Kiem tra co con du lieu trong bang SECURITIES_TICKSIZE khong
            '    v_strSQL = "SELECT COUNT(CODEID) FROM SECURITIES_TICKSIZE WHERE 0=0 AND " & v_strClause
            '    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            '    If v_ds.Tables(0).Rows.Count = 1 Then
            '        If v_ds.Tables(0).Rows(0)(0) > 0 Then
            '            Return ERR_SA_CODEID_HAS_CONSTRAINT
            '        End If
            '    End If

            'Kiem tra co con du lieu trong bang ODMAST khong
            v_strSQL = "SELECT COUNT(CODEID) FROM ODMAST WHERE 0=0 AND " & v_strClause
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 1 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_SA_CODEID_HAS_CONSTRAINT
                End If
            End If

            '    'Kiem tra co con du lieu trong bang  IOD khong
            '    v_strSQL = "SELECT COUNT(CODEID) FROM  IOD WHERE 0=0 AND " & v_strClause
            '    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            '    If v_ds.Tables(0).Rows.Count = 1 Then
            '        If v_ds.Tables(0).Rows(0)(0) > 0 Then
            '            Return ERR_SA_CODEID_HAS_CONSTRAINT
            '        End If
            '    End If
            '    'Kiem tra co con du lieu trong bang  OOD khong
            '    v_strSQL = "SELECT COUNT(CODEID) FROM  OOD WHERE 0=0 AND " & v_strClause
            '    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            '    If v_ds.Tables(0).Rows.Count = 1 Then
            '        If v_ds.Tables(0).Rows(0)(0) > 0 Then
            '            Return ERR_SA_CODEID_HAS_CONSTRAINT
            '        End If
            '    End If
            '    'Kiem tra co con du lieu trong bang  STSCHD khong
            '    'v_strSQL = "SELECT COUNT(CODEID) FROM  STSCHD WHERE 0=0 AND " & v_strClause
            '    'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            '    'If v_ds.Tables(0).Rows.Count = 1 Then
            '    '    If v_ds.Tables(0).Rows(0)(0) > 0 Then
            '    '        Return ERR_SA_CODEID_HAS_CONSTRAINT
            '    '    End If
            '    'End If
            'Kiem tra co con du lieu trong bang  CAMAST khong
            v_strSQL = "SELECT COUNT(CODEID) FROM  CAMAST WHERE 0=0 AND " & v_strClause
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 1 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_SA_CODEID_HAS_CONSTRAINT
                End If
            End If
            'Kiem tra co con du lieu trong bang  TLAUTH khong
            v_strSQL = "SELECT COUNT(CODEID) FROM  TLAUTH WHERE 0=0 AND " & v_strClause
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 1 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_SA_CODEID_HAS_CONSTRAINT
                End If
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

    Overrides Function ProcessAfterAdd(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_ds As DataSet
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal As String
            Dim v_strSQL As String

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

            Dim v_strFLDNAME, v_strVALUE, v_strCODEID, v_strSECTYPE, v_strSYMBOL As String
            Dim v_nodeList As Xml.XmlNodeList
            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strVALUE = .InnerText.ToString()

                    Select Case Trim(v_strFLDNAME)
                        Case "CODEID"
                            v_strCODEID = Trim(v_strVALUE)
                        Case "SYMBOL"
                            v_strSYMBOL = Trim(v_strVALUE)
                        Case "SECTYPE"
                            v_strSECTYPE = Trim(v_strVALUE)

                    End Select
                End With
            Next


            'Neu chung khoan la trai phieu thi luu Thong tin trai phieu
            If v_strSECTYPE = "003" Or v_strSECTYPE = "006" Or v_strSECTYPE = "222" Then
                v_strSQL = "insert into BONDSINFO select CODEID, 0 lstdprice, 0 intmbl, 'W' typeterm, 0 periodicprice, 0 pvrrrate, 0 intcoupon, 0 intrepo, 'N' deltd, 0 yield " & vbNewLine _
                        & " from sbsecurities where sectype in ('003','006','222') and CODEID not in (select CODEID from BONDSINFO)"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            End If

            'If Not (v_ds Is Nothing) Then
            'v_ds.Dispose()
            'End If
            Return ERR_SYSTEM_OK
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Overrides Function ProcessAfterEdit(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_ds As DataSet
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal As String
            Dim v_strSQL As String

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

            Dim v_strFLDNAME, v_strVALUE, v_strCODEID, v_strSECTYPE, v_strSYMBOL As String
            Dim v_nodeList As Xml.XmlNodeList
            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strVALUE = .InnerText.ToString()

                    Select Case Trim(v_strFLDNAME)
                        Case "CODEID"
                            v_strCODEID = Trim(v_strVALUE)
                        Case "SYMBOL"
                            v_strSYMBOL = Trim(v_strVALUE)
                        Case "SECTYPE"
                            v_strSECTYPE = Trim(v_strVALUE)

                    End Select
                End With
            Next


            'Neu chung khoan la trai phieu thi luu Thong tin trai phieu
            If v_strSECTYPE <> "003" And v_strSECTYPE <> "006" And v_strSECTYPE <> "222" Then
                v_strSQL = "update BONDSINFO set DELTD='Y' where CODEID = '" & v_strCODEID & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            Else
                v_strSQL = "update BONDSINFO set DELTD='N' where CODEID = '" & v_strCODEID & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End If

            'If Not (v_ds Is Nothing) Then
            'v_ds.Dispose()
            'End If
            Return ERR_SYSTEM_OK
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Overrides Function SystemProcessBeforeDelete(ByRef v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_ds As DataSet
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strClause, v_strAUTOID, v_strPRCODE, v_strSYMBOL, v_strROOMLIMIT As String
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



            'Xoa thong tin trai phieu
            v_strSQL = "delete from BONDSINFO WHERE " & v_strClause
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

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

End Class
