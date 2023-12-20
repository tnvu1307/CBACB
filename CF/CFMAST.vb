Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data

Public Class CFMAST
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "CFMAST"
    End Sub

#Region " Overrides functions "
    Overrides Function Adhoc(ByRef v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strFuncName As String
        Dim v_strObjMsg As String

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            v_strFuncName = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeFUNCNAME), Xml.XmlAttribute).Value)

            v_strObjMsg = pv_xmlDocument.InnerXml
            Select Case Trim(v_strFuncName)

                Case "ExternalUpdateCFMAST"
                    v_lngErrCode = ExternalUpdateCFMAST(v_strObjMsg)
            End Select
            v_strMessage = v_strObjMsg
            Return v_lngErrCode

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Overrides Function CheckBeforeAdd(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        'Return ERR_SYSTEM_OK
        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strCUSTID, v_strCUSTODYCD, v_strCAREBY, v_strIDTYPE, v_strTRU, v_strGCB, v_strAMC, v_strIDCODE, v_strREFNAME, v_strTRUSTEEID, v_strMCUSTODYCD As String
            Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE, v_strDATEOFBIRTH, v_strIDEXPIRED, v_strIDDATE, v_strTRADEONLINE, v_strDATEOFOPENING, v_strCIFID As String
            Dim v_strSQL, v_strCUSTTYPE, v_strTAXCODE, v_strTLID, v_strEMAIL, v_strMOBILESMS, v_strCUSTATCOM, v_strTRADINGCODE As String
            Dim v_BRID As String
            v_BRID = CStr(CType(v_attrColl.GetNamedItem("BRID"), Xml.XmlAttribute).Value)
            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If
            If Not (v_attrColl.GetNamedItem(gc_AtributeTLID) Is Nothing) Then
                v_strTLID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Else
                v_strTLID = String.Empty
            End If

            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strVALUE = .InnerText.ToString()
                    v_strVALUE = v_strVALUE.Replace("'", "''")
                    Select Case Trim(v_strFLDNAME)
                        Case "CUSTID"
                            v_strCUSTID = Trim(v_strVALUE)
                        Case "CUSTODYCD"
                            v_strCUSTODYCD = Trim(v_strVALUE)
                        Case "CAREBY"
                            v_strCAREBY = Trim(v_strVALUE)
                        Case "IDTYPE"
                            v_strIDTYPE = Trim(v_strVALUE)
                        Case "TRU"
                            v_strTRU = Trim(v_strVALUE)
                        Case "GCB"
                            v_strGCB = Trim(v_strVALUE)
                        Case "AMC"
                            v_strAMC = Trim(v_strVALUE)
                        Case "IDCODE"
                            v_strIDCODE = Trim(v_strVALUE)
                        Case "DATEOFBIRTH"
                            v_strDATEOFBIRTH = Trim(v_strVALUE)
                        Case "IDDATE"
                            v_strIDDATE = Trim(v_strVALUE)
                        Case "IDEXPIRED"
                            v_strIDEXPIRED = Trim(v_strVALUE)
                        Case "CUSTTYPE"
                            v_strCUSTTYPE = Trim(v_strVALUE)
                        Case "TAXCODE"
                            v_strTAXCODE = Trim(v_strVALUE)
                        Case "REFNAME"
                            v_strREFNAME = Trim(Replace(v_strVALUE, ".", ""))
                        Case "TRADEONLINE"
                            v_strTRADEONLINE = Trim(v_strVALUE)
                        Case "EMAIL"
                            v_strEMAIL = Trim(v_strVALUE)
                        Case "MOBILESMS"
                            v_strMOBILESMS = Trim(v_strVALUE)
                        Case "CUSTATCOM"
                            v_strCUSTATCOM = Trim(v_strVALUE)
                        Case "CIFID"
                            v_strCIFID = Trim(v_strVALUE)
                        Case "TRADINGCODE"
                            v_strTRADINGCODE = Trim(v_strVALUE)
                        Case "TRUSTEEID"
                            v_strTRUSTEEID = Trim(v_strVALUE)
                            'Case "DATEOFOPENING"
                            'v_strDATEOFOPENING = Trim(v_strVALUE)
                        Case "MCUSTODYCD"
                            v_strMCUSTODYCD = Trim(v_strVALUE)
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

            'Kiem tra CustID cua Reference co ton tai hay ko
            If (v_strREFNAME.Length <> 0) Then
                v_strSQL = "SELECT COUNT(CUSTID) FROM CFMAST WHERE CUSTID = '" & v_strREFNAME & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count >= 1 Then
                    If v_ds.Tables(0).Rows(0)(0) = 0 Then
                        Return ERR_CF_CUSTID_NOT_LIKE_CUSTID
                    End If
                End If
            End If

            'CHECK CUSTODYCD
            Dim v_strPREFIXEDCODE As String
            Try
                v_strPREFIXEDCODE = v_strCUSTODYCD.Substring(0, 3)
            Catch ex As Exception
                v_strPREFIXEDCODE = ""
            End Try

            If v_strCUSTATCOM = "Y" Then
                If (v_strCUSTODYCD.Length = 10) Then
                    v_strSQL = "select varvalue from SYSVAR where varname='FIRM_VERIFY' AND GRNAME = 'SYSTEM'"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count >= 1 Then
                        If Not v_ds.Tables(0).Rows(0)(0).Contains(v_strPREFIXEDCODE) Then
                            Return CUSTODYCD_PREFIX_MUST_BE_COMPANY_STANDARD
                        End If
                    End If
                End If
            End If

            'Kiem tra CustID co hop le hay khong
            If ((v_strCUSTID.Length <> 10) Or (Not IsNumeric(v_strCUSTID))) Then
                Return ERR_CF_CUSTID_INVALID
            End If
            If Strings.Mid(v_strCUSTID, 1, 4) <> v_BRID Then
                Return ERR_CF_CUSTID_INVALID
            End If
            'Kiem tra ma khach hang khong duoc trung
            v_strSQL = "SELECT COUNT(CUSTID) FROM " & ATTR_TABLE & " WHERE CUSTID = '" & v_strCUSTID & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count >= 1 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_CF_CUSTID_DUPLICATED
                End If
            End If


            'thunt them kiểm tra KH MH
            'Kiem tra ma khach hang khong duoc trung
            v_strSQL = "SELECT COUNT(CIFID) FROM " & ATTR_TABLE & " WHERE CIFID = '" & v_strCIFID & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count >= 1 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_CF_INTERNATION_NOTEMPTY
                End If
            End If


            'Kiểm tra số tài khoản lưu kí được phép null,nhưng khác null thì phải duy nhất
            v_strSQL = "SELECT COUNT(CUSTODYCD) FROM " & ATTR_TABLE & " WHERE CUSTODYCD = '" & v_strCUSTODYCD & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count >= 1 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_CF_CUSTODYCD_DUPLICATED
                End If
            End If
            'TK sub được phep trung TRADINGCODE, IDCODE
            If v_strMCUSTODYCD = "" Then
                'tk me duoc trung TRADINGCODE, IDCODE voi tk sub
                v_strSQL = "SELECT COUNT(1) FROM CFMAST WHERE MCUSTODYCD = '" & v_strMCUSTODYCD & "' AND STATUS <> 'C'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count < 1 Then
                    'phuongHT add check CMT: CFMAST.STATUS='C' duoc trung
                    'Neu NDT NN==> check trading code, neu NDT trong nuoc check IDCODE
                    If v_strIDTYPE = "009" Then
                        v_strSQL = "SELECT COUNT(IDCODE) FROM " & ATTR_TABLE & " WHERE CUSTID <> '" & v_strCUSTID & "' AND IDTYPE='" & v_strIDTYPE & "' AND TRADINGCODE = '" _
                       & v_strTRADINGCODE & "'  And STATUS <> 'C' and substr(CUSTODYCD,1,4) = substr('" & v_strCUSTODYCD & "',1,4)"
                    Else
                        'TanPN 5/2/2020 edit: kiểm tra trusteeid trùng thì cho phép trùng idcode 
                        v_strSQL = "SELECT COUNT(IDCODE) FROM " & ATTR_TABLE & " WHERE CUSTID <> '" & v_strCUSTID & "' AND IDTYPE='" & v_strIDTYPE & "' AND IDCODE = '" _
                       & v_strIDCODE & "'  And STATUS <> 'C' and (TRUSTEEID = 0 OR TRUSTEEID <> " + v_strTRUSTEEID + ")  and substr(CUSTODYCD,1,4) = substr('" & v_strCUSTODYCD & "',1,4)"
                    End If

                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count >= 1 Then
                        If v_ds.Tables(0).Rows(0)(0) > 0 Then
                            Return ERR_CF_IDTYPE_DUPLICATED
                        End If
                    End If
                End If
            End If
            
            'Kiem tra .Date of birth < Ngày làm việc của hệ thống 
            v_strSQL = "SELECT VARVALUE  FROM SYSVAR WHERE VARNAME = 'CURRDATE'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

            ' Chi check dk ngay sinh,  tuoi voi KH la ca nhan
            If Not v_strCUSTTYPE Is Nothing Then
                If v_strCUSTTYPE = "I" Then
                    If Not v_strDATEOFBIRTH Is Nothing Then
                        If DDMMYYYY_SystemDate(v_ds.Tables(0).Rows(0)("VARVALUE")) < DDMMYYYY_SystemDate(v_strDATEOFBIRTH) Then
                            Return ERR_CF_CURRDATE_SMALLER_THAN_BIRTHDATE
                        End If
                    End If
                    '' kiem tra khach hang phai du 18 tuoi
                    'If (DDMMYYYY_SystemDate(v_ds.Tables(0).Rows(0)("VARVALUE")) < DDMMYYYY_SystemDate(v_strDATEOFBIRTH).AddYears(18)) Then
                    '    Return ERR_CF_CFMAST_NOT_ENOUGH_AGE
                    'End If

                End If
            End If

            v_strSQL = "UPDATE CFMAST SET LAST_MKID = '" & v_strTLID & "' WHERE CUSTID = '" & v_strCUSTID & "'"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

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
            Dim v_strLocal, v_strCUSTID, v_strCUSTODYCD, v_strCAREBY, v_strMARGINLIMIT, v_strDATEOFOPENING, v_strESTABLISHDATE, v_strTRUSTEEID, v_strMCUSTODYCD As String
            Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE, v_strIDTYPE, v_strIDCODE, v_strREFNAME As String
            Dim v_strTRADELIMIT, v_strADVANCELIMIT, v_strREPOLIMIT, v_strDEPOSITLIMIT As String
            Dim v_strSQL, v_strSQL1, v_strDATEOFBIRTH, v_strIDEXPIRED, v_strMARGINALLOW As String
            Dim v_BRID, v_strCUSTTYPE, v_strTAXCODE, v_strTLID, v_strTRADEONLINE, v_strTRADINGCODE As String
            v_BRID = CStr(CType(v_attrColl.GetNamedItem("BRID"), Xml.XmlAttribute).Value)

            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeTLID) Is Nothing) Then
                v_strTLID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Else
                v_strTLID = String.Empty
            End If

            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strVALUE = .InnerText.ToString()
                    v_strVALUE = v_strVALUE.Replace("'", "''")
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
                        Case "MARGINLIMIT"
                            v_strMARGINLIMIT = Trim(v_strVALUE)
                        Case "TRADELIMIT"
                            v_strTRADELIMIT = Trim(v_strVALUE)
                        Case "ADVANCELIMIT"
                            v_strADVANCELIMIT = Trim(v_strVALUE)
                        Case "REPOLIMIT"
                            v_strREPOLIMIT = Trim(v_strVALUE)
                        Case "DEPOSITLIMIT"
                            v_strDEPOSITLIMIT = Trim(v_strVALUE)
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
                        Case "MARGINALLOW"
                            v_strMARGINALLOW = Trim(v_strVALUE)
                        Case "TRADEONLINE"
                            v_strTRADEONLINE = Trim(v_strVALUE)
                        Case "TRADINGCODE"
                            v_strTRADINGCODE = Trim(v_strVALUE)
                        Case "TRUSTEEID"
                            v_strTRUSTEEID = Trim(v_strVALUE)
                            'Case "ESTABLISHDATE"
                            '   v_strESTABLISHDATE = Trim(v_strVALUE)
                            'Case "DATEOFOPENING"
                            '    v_strDATEOFOPENING = Trim(v_strVALUE)
                        Case "MCUSTODYCD"
                            v_strMCUSTODYCD = Trim(v_strVALUE)
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

            'Kiem tra CustID cua Reference co ton tai hay ko
            If (v_strREFNAME.Length <> 0) Then
                v_strSQL = "SELECT COUNT(CUSTID) FROM CFMAST WHERE CUSTID <> '" & v_strCUSTID & "' AND CUSTID = '" & v_strREFNAME & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count >= 1 Then
                    If v_ds.Tables(0).Rows(0)(0) = 0 Then
                        Return ERR_CF_CUSTID_NOT_LIKE_CUSTID
                    End If
                End If
            End If

            'Kiem tra trang thai cua khach hang
            'Khong cho sua thong tin khach hang dang phong toa, cho dong, dong
            v_strSQL = "SELECT COUNT(CUSTID) FROM CFMAST WHERE CUSTID = '" & v_strCUSTID & "' AND STATUS IN ('B','N','C')"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count >= 1 Then
                If v_ds.Tables(0).Rows(0)(0) >= 1 Then
                    Return ERR_CF_CFMAST_STATUS_INVALID
                End If
            End If

            v_strSQL = "SELECT COUNT(CUSTODYCD) FROM " & ATTR_TABLE & " WHERE CUSTID <> '" & v_strCUSTID & "' AND CUSTODYCD = '" & v_strCUSTODYCD & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count >= 1 Then
                If v_ds.Tables(0).Rows(0)(0) >= 1 Then
                    Return ERR_CF_CUSTODYCD_DUPLICATED
                End If
            End If

            'tk sub duoc phep trung TRADINGCODE, IDCODE
            If v_strMCUSTODYCD = "" Then
                'tk me duoc trung TRADINGCODE, IDCODE voi tk sub
                v_strSQL = "SELECT COUNT(1) FROM CFMAST WHERE MCUSTODYCD = '" & v_strMCUSTODYCD & "' AND STATUS <> 'C'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows(0)(0) < 1 Then
                    'phuongHT add check CMT: CFMAST.STATUS='C' duoc trung
                    'Neu NDT NN==> check trading code, neu NDT trong nuoc check IDCODE
                    If v_strIDTYPE = "009" Then
                        v_strSQL = "SELECT COUNT(IDCODE) FROM " & ATTR_TABLE & " WHERE CUSTID <> '" & v_strCUSTID & "' AND IDTYPE='" & v_strIDTYPE & "' AND TRADINGCODE = '" _
                       & v_strTRADINGCODE & "'  And STATUS <> 'C' and substr(CUSTODYCD,1,4) = substr('" & v_strCUSTODYCD & "',1,4)"
                    Else
                        'TanPN 5/2/2020 edit: kiểm tra trusteeid trùng thì cho phép trùng idcode 
                        v_strSQL = "SELECT COUNT(IDCODE) FROM " & ATTR_TABLE & " WHERE CUSTID <> '" & v_strCUSTID & "' AND IDTYPE='" & v_strIDTYPE & "' AND IDCODE = '" _
                       & v_strIDCODE & "'  And STATUS <> 'C' and (TRUSTEEID = 0 OR TRUSTEEID <> " + v_strTRUSTEEID + ")  and substr(CUSTODYCD,1,4) = substr('" & v_strCUSTODYCD & "',1,4)"
                    End If

                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count >= 1 Then
                        If v_ds.Tables(0).Rows(0)(0) > 0 Then
                            Return ERR_CF_IDTYPE_DUPLICATED
                        End If
                    End If
                End If
            End If

            'Kiem tra .Date of birth < Ngày làm việc của hệ thống 
            v_strSQL = "SELECT VARVALUE  FROM SYSVAR WHERE VARNAME = 'CURRDATE'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

            If Not v_strCUSTTYPE Is Nothing Then
                If v_strCUSTTYPE = "I" Then
                    If Not v_strDATEOFBIRTH Is Nothing Then
                        If DDMMYYYY_SystemDate(v_ds.Tables(0).Rows(0)("VARVALUE")) < DDMMYYYY_SystemDate(v_strDATEOFBIRTH) Then
                            Return ERR_CF_CURRDATE_SMALLER_THAN_BIRTHDATE
                        End If
                    End If
                End If
            End If
            ' kiem tra khach hang phai du 18 tuoi
            If (v_strCUSTTYPE = "I") Then
                'If (DDMMYYYY_SystemDate(v_ds.Tables(0).Rows(0)("VARVALUE")) < DDMMYYYY_SystemDate(v_strDATEOFBIRTH).AddYears(18)) Then
                '    Return ERR_CF_CFMAST_NOT_ENOUGH_AGE
                'End If

                If Not (v_ds Is Nothing) Then
                    v_ds.Dispose()
                End If
            End If


            v_strSQL = "UPDATE CFMAST SET LAST_MKID = '" & v_strTLID & "' WHERE CUSTID = '" & v_strCUSTID & "'"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            'If v_strTRADEONLINE = "N" Then
            '    Dim v_strSQL2 As String
            '    v_strSQL2 = " UPDATE OTRIGHT SET " & ControlChars.CrLf _
            '        & "     DELTD = 'Y', " & ControlChars.CrLf _
            '        & "     LASTCHANGE = getcurrdate " & ControlChars.CrLf _
            '        & "WHERE CFCUSTID = '" & v_strCUSTID & "' AND DELTD = 'N' "
            '    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL2)

            '    v_strSQL2 = " UPDATE OTRIGHT SET " & ControlChars.CrLf _
            '            & "     DELTD = 'Y', " & ControlChars.CrLf _
            '            & "     LASTCHANGE = getcurrdate " & ControlChars.CrLf _
            '            & "WHERE CFCUSTID = '" & v_strCUSTID & "' AND DELTD = 'N' "
            '    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL2)

            '    'Update rights detail
            '    v_strSQL2 = " UPDATE OTRIGHTDTL SET " & ControlChars.CrLf _
            '            & "     DELTD = 'Y' " & ControlChars.CrLf _
            '            & " WHERE CFCUSTID = '" & v_strCUSTID & "' "
            '    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL2)

            '    v_strSQL2 = " UPDATE OTRIGHTDTL SET " & ControlChars.CrLf _
            '            & "     DELTD = 'Y' " & ControlChars.CrLf _
            '            & " WHERE CFCUSTID = '" & v_strCUSTID & "'"
            '    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL2)

            '    'Update infor to Userlogin
            '    v_strSQL2 = " UPDATE USERLOGIN SET " & ControlChars.CrLf _
            '            & "     STATUS = 'E', " & ControlChars.CrLf _
            '            & "     LASTCHANGED = getcurrdate " & ControlChars.CrLf _
            '            & "WHERE USERNAME = (select custodycd from cfmast where custid = '" & v_strCUSTID & "') AND STATUS = 'A' "
            '    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL2)

            '    v_strSQL2 = " UPDATE USERLOGIN SET " & ControlChars.CrLf _
            '                        & "     STATUS = 'E', " & ControlChars.CrLf _
            '                        & "     LASTCHANGED = getcurrdate " & ControlChars.CrLf _
            '                        & "WHERE USERNAME = (select custodycd from cfmast where custid = '" & v_strCUSTID & "') AND STATUS = 'A' "
            '    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL2)
            'End If

            'ContextUtil.SetComplete()
            Return 0
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Overrides Function CheckBeforeDelete(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_strObjMsg As String
        Dim v_ds As DataSet

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strClause, v_strCUSTID, v_strTellerId As String
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
                v_strCUSTID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeBRID), Xml.XmlAttribute).Value)
            Else
                v_strCUSTID = String.Empty
            End If
            If Not (v_attrColl.GetNamedItem(gc_AtributeBRID) Is Nothing) Then
                v_strTellerId = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Else
                v_strTellerId = String.Empty
            End If

            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            'Check careby
            'Get group careby of current teller
            If v_strTellerId = ADMIN_ID Then
                v_strSQL = "SELECT GRPID VALUE, GRPNAME DISPLAY FROM TLGROUPS WHERE GRPTYPE = '2' AND ACTIVE = 'Y' ORDER BY GRPID "
            Else
                v_strSQL = "SELECT M.GRPID VALUE, N.GRPNAME DISPLAY FROM TLGRPUSERS M, TLGROUPS N WHERE M.TLID = '" & v_strTellerId & "' " _
                                                        & " AND M.GRPID IN (SELECT GRPID FROM TLGROUPS WHERE GRPTYPE = '2' AND ACTIVE = 'Y')" _
                                                        & " AND M.GRPID = N.GRPID ORDER BY M.GRPID "
            End If
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            Dim v_arrGrpCareby() As String
            Dim v_intGrpCareby As Integer
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_intGrpCareby = v_ds.Tables(0).Rows.Count
                ReDim v_arrGrpCareby(v_intGrpCareby)
                For i As Integer = 0 To v_ds.Tables(0).Rows.Count - 1
                    v_arrGrpCareby(i) = CStr(v_ds.Tables(0).Rows(i)("VALUE")).Trim
                Next
            End If
            'Get group careby of this customer
            Dim v_strCareby As String
            v_strSQL = "SELECT CAREBY CAREBY FROM CFMAST WHERE " & v_strClause
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_strCareby = CStr(v_ds.Tables(0).Rows(0)("CAREBY")).Trim
            End If
            'Compare Careby of customer and roll about careby of current teller
            Dim v_blnOK As Boolean
            For i As Integer = 0 To v_intGrpCareby - 1
                'if not v_arrGrpCareby(i) is 
                If v_strCareby = CStr(v_arrGrpCareby(i)).Trim Then
                    v_blnOK = True
                    Exit For
                Else
                    v_blnOK = False
                End If
            Next
            If v_blnOK = False Then
                Return ERR_CF_NOT_CAREBY
            End If


            'Không cho phép xoá 
            If v_strCUSTID <> String.Empty Then
                v_strSQL = "SELECT COUNT(*) COUNT FROM AFMAST WHERE STATUS <>'C' AND " & v_strClause
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows(0)("COUNT") > 0 Then
                    v_strSQL = "SELECT COUNT(*) COUNT FROM DDMAST WHERE " & v_strClause
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows(0)("COUNT") > 0 Then
                        Return ERR_AF_CANNOT_DELETE_ACTIVE_CUSTID
                    End If
                End If
            End If
            If v_strCUSTID <> String.Empty Then
                v_strSQL = "SELECT COUNT(CUSTID) FROM CFCONTACT WHERE 0=0 AND " & v_strClause

                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count >= 1 Then
                    If v_ds.Tables(0).Rows(0)(0) > 0 Then
                        Return ERR_CF_CUSTID_CONSTRAINTS
                    End If
                End If
            End If
            '2
            If v_strCUSTID <> String.Empty Then
                v_strSQL = "SELECT COUNT(CUSTID) FROM CFLINK WHERE 0=0 AND " & v_strClause
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count >= 1 Then
                    If v_ds.Tables(0).Rows(0)(0) > 0 Then
                        Return ERR_CF_CUSTID_CONSTRAINTS
                    End If
                End If
            End If
            '3
            'Comment lai ko check nua theo y/c moi thi: KHI XOA KHACH HANG SE XOA LUON CHU KY.
            'If v_strCUSTID <> String.Empty Then
            '    v_strSQL = "SELECT COUNT(CUSTID) FROM CFSIGN WHERE 0=0 AND " & v_strClause

            '    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            '    If v_ds.Tables(0).Rows.Count >= 1 Then
            '        If v_ds.Tables(0).Rows(0)(0) > 0 Then
            '            Return ERR_CF_CANNOT_DELETE_SIGN
            '        End If
            '    End If
            'End If
            '4


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

    Private Function getAFACCTNO(ByVal v_strMessage As String) As String

        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_strErrorSource As String = "CF.CFMAST.ProcessAfterApprove", v_strErrorMessage As String

        Dim v_strObjMsg As String
        Dim v_ds, v_dsFOR As DataSet
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        v_strObjMsg = pv_xmlDocument.InnerXml
        Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes

        Dim strACCTNO As String
        Dim v_strBRID As String
        Dim v_objRptParam As ReportParameters
        Dim v_arrRptPara() As ReportParameters
        Dim v_iRefLength As Integer
        Dim v_strREFERENCE As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)
        Dim v_DataAccess As New DataAccess, v_ds_1 As DataSet


        If Not (v_attrColl.GetNamedItem(gc_AtributeBRID) Is Nothing) Then
            v_strBRID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeBRID), Xml.XmlAttribute).Value)
        Else
            v_strBRID = String.Empty
        End If

        ReDim v_arrRptPara(4)

        v_objRptParam = New ReportParameters
        v_objRptParam.ParamName = "CLAUSE"
        v_objRptParam.ParamValue = "AFACCTNO"
        v_objRptParam.ParamSize = 8
        v_objRptParam.ParamType = "String"
        v_arrRptPara(0) = v_objRptParam

        v_objRptParam = New ReportParameters
        v_objRptParam.ParamName = "BRID"
        v_objRptParam.ParamValue = v_strBRID
        v_objRptParam.ParamSize = v_strBRID.Length
        v_objRptParam.ParamType = "String"
        v_arrRptPara(1) = v_objRptParam

        v_objRptParam = New ReportParameters
        v_objRptParam.ParamName = "SSYSVAR"
        v_objRptParam.ParamValue = "SHVF"
        v_objRptParam.ParamSize = 4
        v_objRptParam.ParamType = "String"
        v_arrRptPara(2) = v_objRptParam

        v_objRptParam = New ReportParameters
        v_objRptParam.ParamName = "RefLength"
        v_objRptParam.ParamValue = v_iRefLength
        v_objRptParam.ParamSize = 20
        v_objRptParam.ParamType = "NUMBER"
        v_arrRptPara(3) = v_objRptParam

        v_objRptParam = New ReportParameters
        v_objRptParam.ParamName = "REFERENCE"
        v_objRptParam.ParamValue = v_strREFERENCE
        v_objRptParam.ParamSize = v_strREFERENCE.Length
        v_objRptParam.ParamType = "String"
        v_arrRptPara(4) = v_objRptParam


        v_ds_1 = v_DataAccess.ExecuteStoredReturnDataset("SP_GetInventory", v_arrRptPara)
        strACCTNO = CStr(v_ds_1.Tables(0).Rows(0)("AUTOINV"))
        strACCTNO = v_strBRID & Strings.Right("000000" & CStr(strACCTNO), Len("000000"))
        Return strACCTNO
    End Function

    Overrides Function ProcessAfterApprove(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_strErrorSource As String = "CF.CFMAST.ProcessAfterApprove", v_strErrorMessage As String

        Dim v_strObjMsg As String
        Dim v_ds, v_dsFOR As DataSet
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strClause, v_strTellerId, v_strTXDATE, v_strBRID, v_CustID As String
            Dim v_strLocal As String
            Dim v_strSQL As String

            If Not (v_attrColl.GetNamedItem(gc_AtributeCLAUSE) Is Nothing) Then
                v_strClause = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
                v_CustID = v_strClause.Substring(10, 11)
            Else
                v_strClause = String.Empty
            End If
            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If
            If Not (v_attrColl.GetNamedItem(gc_AtributeBRID) Is Nothing) Then
                v_strBRID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeBRID), Xml.XmlAttribute).Value)
            Else
                v_strBRID = String.Empty
            End If
            If Not (v_attrColl.GetNamedItem(gc_AtributeBRID) Is Nothing) Then
                v_strTellerId = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Else
                v_strTellerId = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeTXDATE) Is Nothing) Then
                v_strTXDATE = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXDATE), Xml.XmlAttribute).Value)
            Else
                v_strTXDATE = String.Empty
            End If

            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            ''Sinh CIMAST. Neu duyet khach hang, tieu khoan chua co CIMAST.
            'v_strSQL = "select cit.actype, af.acctno || cit.CCYCD CIACCTNO, af.acctno, cf.custid, cit.CCYCD, cit.ICCFCD, cit.ICCFTIED, cit.MINBAL, af.COREBANK " & ControlChars.CrLf _
            '        & "from cfmast cf, afmast af, aftype aft, citype cit " & ControlChars.CrLf _
            '        & "where(CF.custid = af.custid And af.actype = aft.actype And aft.citype = cit.actype) " & ControlChars.CrLf _
            '        & "and not exists (select 1 from cimast where cimast.afacctno = af.acctno)  " & ControlChars.CrLf _
            '        & "and cf." & v_strClause
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

            'If v_ds.Tables(0).Rows.Count > 0 Then
            '    For i As Integer = 0 To v_ds.Tables(0).Rows.Count - 1
            '        v_strSQL = "INSERT INTO DDMAST (ACTYPE,CUSTID,ACCTNO,CCYCD,AFACCTNO,OPNDATE," & ControlChars.CrLf _
            '                                & "LASTDATE,STATUS,BALANCE,CRAMT,DRAMT," & ControlChars.CrLf _
            '                                & "CRINTACR,ODINTACR,AVRBAL,MDEBIT,MCREDIT," & ControlChars.CrLf _
            '                                & "AAMT,BAMT,EMKAMT,MMARGINBAL,MARGINBAL,CRINTDT," & ControlChars.CrLf _
            '                                & "ODINTDT,RAMT,ICCFCD,ICCFTIED,ODLIMIT,MINBAL,COREBANK,MCRINTDT,DEPOLASTDT)" & ControlChars.CrLf _
            '                & "VALUES ('" & v_ds.Tables(0).Rows(i)("ACTYPE") & "','" & v_ds.Tables(0).Rows(i)("CUSTID") & "','" & v_ds.Tables(0).Rows(i)("CIACCTNO") & "','" & v_ds.Tables(0).Rows(i)("CCYCD") & "','" & v_ds.Tables(0).Rows(i)("ACCTNO") & "',TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')," & ControlChars.CrLf _
            '                                & "TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'A',0,0,0," & ControlChars.CrLf _
            '                                & "0,0,0,0,0,0,0,0,0,0,TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),0,'" & v_ds.Tables(0).Rows(i)("ICCFCD") & "','" & v_ds.Tables(0).Rows(i)("ICCFTIED") & "',0," & v_ds.Tables(0).Rows(i)("MINBAL") & ",'" & v_ds.Tables(0).Rows(i)("COREBANK") & "', TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),( SELECT GET_DEPOPAYDATE FROM DUAL ))"
            '        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            '    Next
            'End If





            ' Cap nhap lai COREBANK trong CIMAST
            Dim v_strCIACTYPE, v_strSEACTYPE, v_strLNACTYPE, v_strNewCoreBank As String
            v_strSQL = "SELECT * FROM AFMAST AF WHERE AF." & v_strClause
            v_dsFOR = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)


            If v_dsFOR.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To v_dsFOR.Tables(0).Rows.Count - 1

                    'Lay CITYPE, SETYPE, LNTYPE trong aftype tuong ung voi v_strACTYPE (loai hinh tieu khoan moi)
                    v_strSQL = "SELECT CITYPE, SETYPE, LNTYPE, COREBANK FROM AFTYPE WHERE ACTYPE = '" & v_dsFOR.Tables(0).Rows(i)("ACTYPE") & "'"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count = 1 Then
                        v_strCIACTYPE = IIf(v_ds.Tables(0).Rows(0)(0) Is DBNull.Value, String.Empty, v_ds.Tables(0).Rows(0)(0))
                        v_strSEACTYPE = IIf(v_ds.Tables(0).Rows(0)(1) Is DBNull.Value, String.Empty, v_ds.Tables(0).Rows(0)(1))
                        v_strLNACTYPE = IIf(v_ds.Tables(0).Rows(0)(2) Is DBNull.Value, String.Empty, v_ds.Tables(0).Rows(0)(2))
                        v_strNewCoreBank = IIf(v_ds.Tables(0).Rows(0)(3) Is DBNull.Value, String.Empty, v_ds.Tables(0).Rows(0)(3))
                    End If

                    'UPDATE COREBANK CUA AFMAST
                    v_strSQL = "UPDATE AFMAST SET COREBANK ='" & v_strNewCoreBank & "', CHGACTYPE = 'N' WHERE ACCTNO = '" & v_dsFOR.Tables(0).Rows(i)("ACCTNO") & "'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                    'UPDATE ACTYPE, COREBANK CUA CIMAST
                    v_strSQL = "UPDATE DDMAST SET ACTYPE = '" & v_strCIACTYPE & "', COREBANK ='" & v_strNewCoreBank & "' WHERE AFACCTNO = '" & v_dsFOR.Tables(0).Rows(i)("ACCTNO") & "'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                    'UPDATE ACTYPE CUA SEMAST
                    v_strSQL = "UPDATE SEMAST SET ACTYPE = '" & v_strSEACTYPE & "' WHERE AFACCTNO = '" & v_dsFOR.Tables(0).Rows(i)("ACCTNO") & "'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                Next
            End If
            'longnh: PHS_P1_cf0005 - bo gd active VSD cho tai khoan, tai khoan tu active VSD sau khi duyet
            'v_strSQL = "UPDATE cfmast SET ACTIVESTS = 'Y' WHERE " & v_strClause
            'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            '27/05/2018 Update ngay Duyet cua cac dong log chua Duyet
            v_strSQL = "update aftemplateslog set approvedate = getcurrdate where approvedate is null and tlid <> '6868' and " & v_strClause
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If
            Return ERR_SYSTEM_OK
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try

    End Function

    Overrides Function CheckBeforeApprove(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_strErrorSource As String = "CF.CFMAST.CheckBeforeApprove", v_strErrorMessage As String

        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strClause, v_strTellerId, v_strTXDATE, v_strBRID As String
            Dim v_strLocal As String
            Dim v_strSQL, v_strCUSTODYCD, v_strEMAIL, v_strCUSTID, v_strMOBILESMS, v_strFULLNAME As String

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
                v_strBRID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeBRID), Xml.XmlAttribute).Value)
            Else
                v_strBRID = String.Empty
            End If
            If Not (v_attrColl.GetNamedItem(gc_AtributeBRID) Is Nothing) Then
                v_strTellerId = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Else
                v_strTellerId = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeTXDATE) Is Nothing) Then
                v_strTXDATE = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXDATE), Xml.XmlAttribute).Value)
            Else
                v_strTXDATE = String.Empty
            End If

            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            'Kiem tra ma khach hang co dang bi double hay khong?
            v_strSQL = "select count(1) AFCOUNT from (select acctno from afmast where " & v_strClause & " group by acctno having count(1) > 1)"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                If v_ds.Tables(0).Rows(0)("AFCOUNT") > 0 Then
                    v_lngErrCode = ERR_CF_ACCTNO_DUPLICATE
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If
            End If

            ''Sinh CIMAST. Neu duyet khach hang, tieu khoan chua co CIMAST.
            'v_strSQL = "select cit.actype, af.acctno, cf.custid, cit.CCYCD, cit.ICCFCD, cit.ICCFTIED, cit.MINBAL, af.COREBANK " & ControlChars.CrLf _
            '        & "from cfmast cf, afmast af, aftype aft, citype cit " & ControlChars.CrLf _
            '        & "where(CF.custid = af.custid And af.actype = aft.actype And aft.citype = cit.actype) " & ControlChars.CrLf _
            '        & "and not exists (select 1 from cimast where cimast.afacctno = af.acctno)  " & ControlChars.CrLf _
            '        & "and cf." & v_strClause
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

            'If v_ds.Tables(0).Rows.Count > 0 Then
            '    For i As Integer = 0 To v_ds.Tables(0).Rows.Count - 1
            '        v_strSQL = "INSERT INTO CIMAST (ACTYPE,CUSTID,ACCTNO,CCYCD,AFACCTNO,OPNDATE," & ControlChars.CrLf _
            '                                & "LASTDATE,STATUS,BALANCE,CRAMT,DRAMT," & ControlChars.CrLf _
            '                                & "CRINTACR,ODINTACR,AVRBAL,MDEBIT,MCREDIT," & ControlChars.CrLf _
            '                                & "AAMT,BAMT,EMKAMT,MMARGINBAL,MARGINBAL,CRINTDT," & ControlChars.CrLf _
            '                                & "ODINTDT,RAMT,ICCFCD,ICCFTIED,ODLIMIT,MINBAL,COREBANK,MCRINTDT,DEPOLASTDT)" & ControlChars.CrLf _
            '                & "VALUES ('" & v_ds.Tables(0).Rows(i)("ACTYPE") & "','" & v_ds.Tables(0).Rows(i)("CUSTID") & "','" & v_ds.Tables(0).Rows(i)("ACCTNO") & "','" & v_ds.Tables(0).Rows(i)("CCYCD") & "','" & v_ds.Tables(0).Rows(i)("ACCTNO") & "',TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')," & ControlChars.CrLf _
            '                                & "TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'A',0,0,0," & ControlChars.CrLf _
            '                                & "0,0,0,0,0,0,0,0,0,0,TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),0,'" & v_ds.Tables(0).Rows(i)("ICCFCD") & "','" & v_ds.Tables(0).Rows(i)("ICCFTIED") & "',0," & v_ds.Tables(0).Rows(i)("MINBAL") & ",'" & v_ds.Tables(0).Rows(i)("COREBANK") & "', TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),( select last_day(trunc(to_date('" & v_strTXDATE & "','DD/MM/RRRR'),'MM')-1)  from dual ))"
            '        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            '    Next
            'End If

            'Neu la duyet lan dau. Cap nhat tang gia tri han muc vay Margin. 
            v_strSQL = "select * from AFMAST where " & v_strClause & " and instr(PSTATUS,'A') <= 0 and STATUS = 'P'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'KHI THEM MOI TIEU KHOAN LAY HAN MUC TU USER ADMIN
            Dim v_ds2 As DataSet
            If v_ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To v_ds.Tables(0).Rows.Count - 1
                    'PROCESS FOR MR
                    v_strSQL = "SELECT count(1) CNT FROM USERAFLIMIT WHERE TYPERECEIVE='MR' AND ACCTNO= '" & v_ds.Tables(0).Rows(i)("ACCTNO") & "' AND TLIDUSER= '0001' and typeallocate = 'Flex'"
                    v_ds2 = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds2.Tables(0).Rows(0)("CNT") > 0 Then
                        v_strSQL = "update useraflimit set acclimit = " & v_ds.Tables(0).Rows(i)("MRCRLIMITMAX") & " " &
                                "where TYPERECEIVE='MR' AND ACCTNO= '" & v_ds.Tables(0).Rows(i)("ACCTNO") & "' AND TLIDUSER= '0001' and typeallocate = 'Flex'"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    Else
                        v_strSQL = "INSERT INTO USERAFLIMIT(ACCTNO,ACCLIMIT,TLIDUSER,TYPEALLOCATE,TYPERECEIVE) " _
                                & "VALUES('" & v_ds.Tables(0).Rows(i)("ACCTNO") & "'," & v_ds.Tables(0).Rows(i)("MRCRLIMITMAX") & ", " _
                                & " '0001','Flex','MR')"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    End If
                    v_strSQL = "update userlimit ul " _
                        & "SET ul.usedlimmit = usedlimmit + " & v_ds.Tables(0).Rows(i)("MRCRLIMITMAX") & " " _
                        & "where TLIDUSER= '0001' and ul.usertype = 'Flex'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    v_strSQL = "INSERT INTO USERAFLIMITLOG(TXDATE,TXNUM,ACCTNO,ACCLIMIT,TLIDUSER,TYPEALLOCATE,TYPERECEIVE) " _
                            & "VALUES(to_date('" & v_strTXDATE & "','DD/MM/RRRR'),'" & v_ds.Tables(0).Rows(i)("ACCTNO") & "','" & v_ds.Tables(0).Rows(i)("ACCTNO") & "'," & v_ds.Tables(0).Rows(i)("MRCRLIMITMAX") & ", " _
                            & "'0001','Flex','MR')"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)


                    'PROCESS FOR dp
                    v_strSQL = "SELECT count(1) CNT FROM USERAFLIMIT WHERE TYPERECEIVE='DP' AND ACCTNO= '" & v_ds.Tables(0).Rows(i)("ACCTNO") & "' AND TLIDUSER= '0001' and typeallocate = 'Flex'"
                    v_ds2 = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds2.Tables(0).Rows(0)("CNT") > 0 Then
                        v_strSQL = "update useraflimit set acclimit =  " & v_ds.Tables(0).Rows(i)("DPCRLIMITMAX") & " " &
                                "where TYPERECEIVE='DP' AND ACCTNO= '" & v_ds.Tables(0).Rows(i)("ACCTNO") & "' AND TLIDUSER= '0001' and typeallocate = 'Flex'"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    Else
                        v_strSQL = "INSERT INTO USERAFLIMIT(ACCTNO,ACCLIMIT,TLIDUSER,TYPEALLOCATE,TYPERECEIVE) " _
                                & "VALUES('" & v_ds.Tables(0).Rows(i)("ACCTNO") & "'," & v_ds.Tables(0).Rows(i)("DPCRLIMITMAX") & ", " _
                                & " '0001','Flex','DP')"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    End If


                    v_strSQL = "INSERT INTO USERAFLIMITLOG(TXDATE,TXNUM,ACCTNO,ACCLIMIT,TLIDUSER,TYPEALLOCATE,TYPERECEIVE) " _
                            & "VALUES(to_date('" & v_strTXDATE & "','DD/MM/RRRR'),'" & v_ds.Tables(0).Rows(i)("ACCTNO") & "','" & v_ds.Tables(0).Rows(i)("ACCTNO") & "'," & v_ds.Tables(0).Rows(i)("DPCRLIMITMAX") & ", " _
                            & "'0001','Flex','DP')"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)




                Next
            End If

            ' Cap nhat cac ngay tren thong tin khach hang khi duyet khach hang, cac ngay duoc cap nhat dang trang thai null
            v_strSQL = "update afmast set PSTATUS = PSTATUS || STATUS, status = 'A' " & ControlChars.CrLf _
                        & " where " & v_strClause & " and STATUS = 'P'"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            v_strSQL = "update reaflnk set PSTATUS = PSTATUS || STATUS, status = 'A' " & ControlChars.CrLf _
            & "where afacctno = (select custid from cfmast where " & v_strClause & ") and STATUS = 'P'"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            ' Cap nhat cac ngay tren thong tin khach hang khi duyet khach hang, cac ngay duoc cap nhat dang trang thai null
            v_strSQL = "update cfmast set OPNDATE = to_date('" & v_strTXDATE & "','DD/MM/RRRR') , " & ControlChars.CrLf _
                        & " lastdate = to_date('" & v_strTXDATE & "','DD/MM/RRRR') , " & ControlChars.CrLf _
                        & " activedate = to_date('" & v_strTXDATE & "','DD/MM/RRRR') " & ControlChars.CrLf _
                        & " where " & v_strClause & " and OPNDATE is null"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)


            v_strSQL = "UPDATE CFMAST SET LAST_OFID = '" & v_strTellerId & "' WHERE " & v_strClause
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            '17/07/2018 DieuNDA: Chuyen buoc gui email thong bao MK xuong buoc Duyet
            v_strSQL = "SELECT CUSTID,nvl(CUSTODYCD,' ') CUSTODYCD, nvl(EMAIL,' ') EMAIL,nvl(MOBILESMS,' ') MOBILESMS,FULLNAME FROM CFMAST WHERE " & v_strClause
            v_ds2 = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds2.Tables(0).Rows.Count >= 1 Then
                v_strCUSTODYCD = v_ds2.Tables(0).Rows(0)("CUSTODYCD")
                v_strEMAIL = v_ds2.Tables(0).Rows(0)("EMAIL")
                v_strCUSTID = v_ds2.Tables(0).Rows(0)("CUSTID")
                v_strMOBILESMS = v_ds2.Tables(0).Rows(0)("MOBILESMS")
                v_strFULLNAME = v_ds2.Tables(0).Rows(0)("FULLNAME")
            Else
                v_strCUSTODYCD = ""
                v_strEMAIL = ""
                v_strCUSTID = ""
                v_strMOBILESMS = ""
                v_strFULLNAME = ""
            End If

            'Kiem tra xem co phai KH dang ky GD online khong
            'DuyAnh.Hoang Comment --> khong s/d luong email nay
            'v_strSQL = " select count(*) " & ControlChars.CrLf _
            '        & " from maintain_log m1, " & ControlChars.CrLf _
            '        & "    ( " & ControlChars.CrLf _
            '        & "        select record_key, max(mod_num) mod_num, max(maker_dt) maker_dt   " & ControlChars.CrLf _
            '        & "        from maintain_log m " & ControlChars.CrLf _
            '        & "        where m.table_name = 'CFMAST' and m.child_table_name is null and m.approve_dt is null and m.column_name = 'TRADEONLINE' " & ControlChars.CrLf _
            '        & "            and m.record_key like '" & Replace(v_strClause, "'", "''") & "' " & ControlChars.CrLf _
            '        & "        group by record_key " & ControlChars.CrLf _
            '        & "    ) m2 " & ControlChars.CrLf _
            '        & " where m1.table_name = 'CFMAST' and m1.child_table_name is null and m1.approve_dt is null and m1.column_name = 'TRADEONLINE' " & ControlChars.CrLf _
            '        & "    and m1.record_key = m2.record_key " & ControlChars.CrLf _
            '        & "    and m1.mod_num = m2.mod_num " & ControlChars.CrLf _
            '        & "    and m1.maker_dt = m2.maker_dt " & ControlChars.CrLf _
            '        & "    and m1.record_key like '" & Replace(v_strClause, "'", "''") & "' " & ControlChars.CrLf _
            '        & "    and m1.to_value = 'Y' "
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'If v_ds.Tables(0).Rows.Count >= 1 Then
            '    If v_ds.Tables(0).Rows(0)(0) > 0 And (String.IsNullOrEmpty(v_strCUSTODYCD) = False And v_strCUSTODYCD <> " ") Then


            '        v_strSQL = "SELECT * FROM OTRIGHT WHERE DELTD = 'N' AND CFCUSTID = '" & v_strCUSTID & "'"
            '        v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

            '        If v_ds.Tables(0).Rows.Count = 0 Then
            '            Dim v_strtypetrade, v_strtypetradeSMS, v_strSQL2 As String
            '            Dim v_dtVALDATE, v_dtEXPDATE As Date


            '            v_strtypetrade = "Mật khẩu đặt lệnh của quý khách là:"
            '            v_strtypetradeSMS = "MK dat lenh:"

            '            v_dtVALDATE = Format(Date.Now(), "ddMMMyyyy")
            '            v_dtEXPDATE = DateAdd(DateInterval.Year, 100, v_dtVALDATE)



            '            'Insert infor to OTRIGHT
            '            v_strSQL2 = " INSERT INTO OTRIGHT (AUTOID, CFCUSTID, AUTHCUSTID, AUTHTYPE, VALDATE, EXPDATE, DELTD, LASTCHANGE ) " & ControlChars.CrLf _
            '                    & "SELECT SEQ_OTRIGHT.NEXTVAL, '" & v_strCUSTID & "', '" & v_strCUSTID & "', " & ControlChars.CrLf _
            '                & "     '1', getcurrdate, ADD_MONTHS(getcurrdate,1200), 'N', getcurrdate FROM DUAL"
            '            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL2)

            '            v_strSQL2 = " INSERT INTO OTRIGHTMEMO (AUTOID, CFCUSTID, AUTHCUSTID, AUTHTYPE, VALDATE, EXPDATE, DELTD, LASTCHANGE ) " & ControlChars.CrLf _
            '                    & "SELECT SEQ_OTRIGHT.NEXTVAL, '" & v_strCUSTID & "', '" & v_strCUSTID & "', " & ControlChars.CrLf _
            '                & "     '1', getcurrdate, ADD_MONTHS(getcurrdate,1200), 'N', getcurrdate FROM DUAL"

            '            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL2)

            '            'Insert rights detail
            '            'thay YYYYYNN=> YYYYYYN
            '            v_strSQL2 = "INSERT INTO OTRIGHTDTL (AUTOID, CFCUSTID, AUTHCUSTID, OTMNCODE, OTRIGHT, DELTD) " & ControlChars.CrLf _
            '                            & "select SEQ_OTRIGHTDTL.NEXTVAL, '" & v_strCUSTID & "', '" & v_strCUSTID & "', " & ControlChars.CrLf _
            '                            & "CDVAL, 'YYYYYNN', 'N' from allcode where cDtype ='SA' AND CDNAME = 'OTFUNC' AND cduser = 'Y'"
            '            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL2)

            '            v_strSQL2 = "INSERT INTO OTRIGHTDTLMEMO (AUTOID, CFCUSTID, AUTHCUSTID, OTMNCODE, OTRIGHT, DELTD) " & ControlChars.CrLf _
            '                            & "select SEQ_OTRIGHTDTL.NEXTVAL, '" & v_strCUSTID & "', '" & v_strCUSTID & "', " & ControlChars.CrLf _
            '                            & "CDVAL, 'YYYYYNN', 'N' from allcode where cDtype ='SA' AND CDNAME = 'OTFUNC' AND cduser = 'Y'"
            '            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL2)


            '            Dim v_strPass, v_strPass2, v_serial As String
            '            v_strSQL2 = "select substr(sys_guid(),0,10) pass from dual  "
            '            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL2)
            '            v_strPass = v_ds.Tables(0).Rows(0)("PASS")

            '            'v_strSQL2 = "select substr(sys_guid(),0,10) pass from dual  "
            '            v_strSQL2 = "select cspks_system.fn_passwordgenerator2(6) pass from dual"
            '            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL2)
            '            v_strPass2 = v_ds.Tables(0).Rows(0)("PASS")
            '            v_serial = ""


            '            v_strSQL2 = " INSERT INTO USERLOGIN (USERNAME, LOGINPWD, AUTHTYPE, TRADINGPWD, STATUS, " & ControlChars.CrLf _
            '                        & "LASTLOGIN, LOGINSTATUS, LASTCHANGED, NUMBEROFDAY, ISMASTER, ISRESET ) " & ControlChars.CrLf _
            '                        & "SELECT CUSTODYCD,GENENCRYPTPASSWORD('" & v_strPass & "'),'1',GENENCRYPTPASSWORD('" & v_strPass2 & "'), " & ControlChars.CrLf _
            '                        & "'A',SYSDATE,'O',SYSDATE,30,'N','Y' FROM CFMAST where  CUSTODYCD is not null and custid = '" & v_strCUSTID & "' "
            '            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL2)

            '            v_strSQL2 = " INSERT INTO USERLOGINMEMO (USERNAME, LOGINPWD, AUTHTYPE, TRADINGPWD, STATUS, " & ControlChars.CrLf _
            '                        & "LASTLOGIN, LOGINSTATUS, LASTCHANGED, NUMBEROFDAY, ISMASTER, ISRESET ) " & ControlChars.CrLf _
            '                        & "SELECT CUSTODYCD,GENENCRYPTPASSWORD('" & v_strPass & "'),'1',GENENCRYPTPASSWORD('" & v_strPass2 & "'), " & ControlChars.CrLf _
            '                        & "'A',SYSDATE,'O',SYSDATE,30,'N','Y' FROM CFMAST where CUSTODYCD is not null and custid = '" & v_strCUSTID & "' "
            '            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL2)

            '            v_strSQL2 = " update CFMAST set username = custodycd, TRADEONLINE = 'Y' where CUSTODYCD is not null and custid = '" & v_strCUSTID & "' "
            '            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL2)

            '            v_strSQL2 = " update CFMASTMEMO set username = custodycd, TRADEONLINE = 'Y' where CUSTODYCD is not null and custid = '" & v_strCUSTID & "' "
            '            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL2)


            '            Dim l_datasourcesql As String

            '            If String.IsNullOrEmpty(v_strCUSTODYCD) = False Then

            '                Dim l_language_type As String
            '                If Mid(v_strCUSTODYCD, 4, 1) = "F" Then
            '                    l_language_type = "EN"
            '                Else
            '                    l_language_type = ""
            '                End If
            '                l_datasourcesql = "select ''" & v_strCUSTODYCD & "'' username,''" & v_strCUSTODYCD.Substring(4) & "'' loginnum, ''" & v_strPass & "'' loginpwd ,''" & v_strPass2 & "'' tradingpwd, ''" & v_strFULLNAME & "'' fullname,''" & v_strtypetrade & "'' typetrade, ''" & v_strtypetradeSMS & "'' typetradesms, ''" & v_serial & "'' numberserial, ''" & v_strCUSTODYCD & "'' custodycode from dual"

            '                v_strSQL2 = " INSERT INTO emaillog (autoid, email, templateid, datasource, status,afacctno ,createtime,TXDATE,language_type)" & ControlChars.CrLf _
            '                           & "VALUES(seq_emaillog.nextval,'" & v_strEMAIL & "','100E','" & l_datasourcesql & "','A','" & v_strCUSTODYCD & "',SYSDATE,getcurrdate,'" & l_language_type & "')"
            '                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL2)

            '                'v_strSQL2 = " INSERT INTO emaillogmemo (autoid, email, templateid, datasource, status,afacctno ,createtime)" & ControlChars.CrLf _
            '                '           & "VALUES(seq_emaillog.nextval,'" & v_strEMAIL & "','100E','" & l_datasourcesql & "','A','" & v_strCUSTODYCD & "',SYSDATE)"
            '                'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL2)

            '                'CongDCT edit 2015/02/03
            '                'Reason: Edit template SMS

            '                If l_language_type = "EN" Then
            '                    l_datasourcesql = "PHS-NOTICE: Account " & v_strCUSTODYCD & ". Log-in password: " & v_strPass & ", ordering password: " & v_strPass2 & ". Please change password after first log-in."
            '                Else
            '                    l_datasourcesql = "PHS-TB: TK " & v_strCUSTODYCD & ". Mat khau dang nhap: " & v_strPass & ", mat khau giao dich: " & v_strPass2 & ". Quy khach vui long thay doi mat khau ngay sau khi dang nhap thanh cong."
            '                End If

            '                'l_datasourcesql = "PHS-TB: So TK " & v_strCUSTODYCD & ". Mat khau dang nhap: " & v_strPass & ", mat khau giao dich: " & v_strPass2 & ". Quy khach truy cap www.phs.vn de xem huong dan su dung."

            '                v_strSQL2 = " INSERT INTO emaillog (autoid, email, templateid, datasource, status,afacctno ,createtime,TXDATE)" & ControlChars.CrLf _
            '                           & "VALUES(seq_emaillog.nextval,'" & v_strMOBILESMS & "','101S','" & l_datasourcesql & "','A','" & v_strCUSTODYCD & "',SYSDATE,getcurrdate)"
            '                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL2)

            '                'v_strSQL2 = " INSERT INTO emaillogmemo (autoid, email, templateid, datasource, status,afacctno ,createtime)" & ControlChars.CrLf _
            '                '           & "VALUES(seq_emaillog.nextval,'" & v_strMOBILESMS & "','101S','" & l_datasourcesql & "','A','" & v_strCUSTODYCD & "',SYSDATE)"
            '                'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL2)
            '            End If
            '        End If

            '    End If

            'End If

            'End 17/07/2018 DieuNDA


            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If
            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Overrides Function Delete(ByRef v_strMessage As String) As Long

        Try
            Dim v_lngErrCode As Long = 0
            Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
            Dim v_strSYSVAR As String, v_DataAccess As New DataAccess
            'Check HOST Active
            v_DataAccess.NewDBInstance(gc_MODULE_HOST)
            v_lngErrCode = v_DataAccess.GetSysVar("SYSTEM", "HOSTATUS", v_strSYSVAR)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            End If
            If v_strSYSVAR <> OPERATION_ACTIVE Then
                Rollback() 'ContextUtil.SetAbort()
                Return ERR_SA_HOST_OPERATION_ISINACTIVE
            End If

            Dim v_strSystemProcessMsg As String = pv_xmlDocument.InnerXml
            v_lngErrCode = CheckBeforeDelete(v_strSystemProcessMsg)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
                Exit Function
            End If
            v_lngErrCode = SystemProcessBeforeDelete(v_strSystemProcessMsg)

            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Return v_lngErrCode
            End If

            pv_xmlDocument.LoadXml(v_strSystemProcessMsg)

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

            'Delete data
            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            'Xoa het chu ky truoc khi xoa thong tin khach hang
            Dim v_strSQLSIGN As String = "DELETE FROM CFSIGN WHERE 0=0 AND " & v_strClause
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQLSIGN)

            'Xoa cac thong tin GD online
            Dim v_strSQL As String
            'Khong s/d luong email cu
            'v_strSQL = " BEGIN " & ControlChars.CrLf _
            '        & " UPDATE OTRIGHT SET DELTD = 'Y', LASTCHANGE = GETCURRDATE WHERE CFCUSTID IN ( SELECT CUSTID FROM CFMAST WHERE 0 = 0 AND " & v_strClause & ") AND DELTD = 'N'; " & ControlChars.CrLf _
            '        & " UPDATE OTRIGHTDTL SET DELTD = 'Y' WHERE CFCUSTID IN ( SELECT CUSTID FROM CFMAST WHERE 0 = 0 AND " & v_strClause & ") AND DELTD = 'N'; " & ControlChars.CrLf _
            '        & " UPDATE USERLOGIN SET STATUS = 'E', LASTCHANGED = SYSDATE WHERE USERNAME IN ( SELECT CUSTODYCD FROM CFMAST WHERE 0 = 0 AND " & v_strClause & ") AND STATUS = 'A'; " & ControlChars.CrLf _
            '        & " END;"
            'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            '27/05/2018 Log lai xoa AFTEMPLATES
            v_strSQL = " BEGIN " & ControlChars.CrLf _
                    & " INSERT into aftemplateslog(autoid, custid, template_code, begindate, enddate, last_change, action,tlid,approvedate) " & ControlChars.CrLf _
                    & " select mst.autoid, mst.custid, mst.template_code, CREATEDATE, getcurrdate, sysdate, 'DELETE','0000', getcurrdate " & ControlChars.CrLf _
                    & " from aftemplates mst where " & v_strClause & ";  " & ControlChars.CrLf _
                    & " delete from aftemplates where " & v_strClause & " ; " & ControlChars.CrLf _
                    & " END;"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            v_strSQL = "DELETE FROM " & ATTR_TABLE & " WHERE 0=0 AND " & v_strClause
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
#End Region

#Region "Private Methoad"

    Private Function ExternalUpdateCFMAST(ByRef pv_strObjMsg As String) As Long
        Try
            Dim XMLDocument As New XmlDocumentEx
            Dim v_strSQL As String
            Dim v_ds As DataSet, v_strBankAcctNo, v_strBankCode As String
            Dim v_lngErrCode As Long = ERR_SYSTEM_OK

            XMLDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
            Dim v_strClause As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Dim v_strBusDate As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXDATE), Xml.XmlAttribute).Value)

            Dim v_strCUSTID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_objParam As New StoreParameter
            Dim v_arrPara(1) As StoreParameter
            v_objParam = New StoreParameter
            v_objParam.ParamName = "pv_err_code"
            v_objParam.ParamValue = "0"
            v_objParam.ParamDirection = ParameterDirection.Output
            v_objParam.ParamSize = 10
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(0) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "pv_custid"
            v_objParam.ParamValue = v_strCUSTID
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamSize = 10
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(1) = v_objParam

            v_strSQL = "select * from otright where deltd = 'N' and cfcustid = '" & v_strCUSTID
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                'v_strtypetrade = "Qúy khách sử dụng phương thức đặt lệnh bằng token:"
                'v_strtypetradeSMS = "Serial Token:"
            End If


            v_lngErrCode = v_obj.ExecuteOracleStored("pr_ExternalUpdateCFMAST", v_arrPara, 0)
            v_strSQL = String.Empty
            Return v_lngErrCode
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Overrides Function ProcessAfterAdd(ByVal v_strMessage As String) As Long
        Dim v_lngErrorCode As Long
        Dim v_strSYSVAR, v_strSQLTmp, v_strClause, v_CustID, v_strTXDATE As String, v_DataAccess As New DataAccess
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        'Return ERR_SYSTEM_OK
        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Try

            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strCUSTID, v_strCUSTODYCD, v_strCAREBY, v_strIDTYPE, v_strIDCODE, v_strREFNAME, v_strFULLNAME As String
            Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE, v_strDATEOFBIRTH, v_strIDEXPIRED, v_strIDDATE, v_strTRADEONLINE As String
            Dim v_strSQL, v_strCUSTTYPE, v_strTAXCODE, v_strTLID, v_strEMAIL, v_strMOBILESMS As String
            Dim v_BRID As String
            v_BRID = CStr(CType(v_attrColl.GetNamedItem("BRID"), Xml.XmlAttribute).Value)
            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If
            If Not (v_attrColl.GetNamedItem(gc_AtributeTLID) Is Nothing) Then
                v_strTLID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Else
                v_strTLID = String.Empty
            End If
            If Not (v_attrColl.GetNamedItem(gc_AtributeCLAUSE) Is Nothing) Then
                v_strClause = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
                v_CustID = v_strClause.Substring(10, 11)
            Else
                v_strClause = String.Empty
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
                    v_strVALUE = v_strVALUE.Replace("'", "''")
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
                        Case "IDDATE"
                            v_strIDDATE = Trim(v_strVALUE)
                        Case "IDEXPIRED"
                            v_strIDEXPIRED = Trim(v_strVALUE)
                        Case "CUSTTYPE"
                            v_strCUSTTYPE = Trim(v_strVALUE)
                        Case "TAXCODE"
                            v_strTAXCODE = Trim(v_strVALUE)
                        Case "REFNAME"
                            v_strREFNAME = Trim(Replace(v_strVALUE, ".", ""))
                        Case "TRADEONLINE"
                            v_strTRADEONLINE = Trim(v_strVALUE)
                        Case "EMAIL"
                            v_strEMAIL = Trim(v_strVALUE)
                        Case "MOBILESMS"
                            v_strMOBILESMS = Trim(v_strVALUE)
                        Case "FULLNAME"
                            v_strFULLNAME = Trim(v_strVALUE)
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

            'CongDCT add 2014-12-17: Insert cac mau SMS/Email bat buoc phai dang ky
            v_strSQL = "INSERT INTO AFTEMPLATES (AUTOID, CUSTID, TEMPLATE_CODE, CREATEDATE ) " & ControlChars.CrLf _
                            & "SELECT SEQ_AFTEMPLATES.NEXTVAL, CF.CUSTID, TL.CODE, getcurrdate" & ControlChars.CrLf _
                        & " FROM CFMAST CF, TEMPLATES TL WHERE TL.REQUIRE_REGISTER = 'N' AND TL.ISACTIVE = 'Y' AND CF.CUSTID = '" & v_strCUSTID & "'" & ControlChars.CrLf _
                        & " AND NOT EXISTS( select * from AFTEMPLATES T where T.CUSTID='" & v_strCUSTID & "' and T.TEMPLATE_CODE=TL.CODE)"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            '27/05/2018 Log lai dang ky SMS Email
            v_strSQL = "INSERT INTO aftemplateslog(autoid, custid, template_code, begindate, enddate, last_change, action,tlid,approvedate) " & ControlChars.CrLf _
                            & "SELECT TL.AUTOID, tl.CUSTID, TL.template_code, CREATEDATE, null, sysdate, 'ADD', '0000', getcurrdate" & ControlChars.CrLf _
                        & " FROM aftemplates TL WHERE  CUSTID = '" & v_strCUSTID & "'" & ControlChars.CrLf _
                        & " AND NOT EXISTS( select * from aftemplateslog log where log.CUSTID='" & v_strCUSTID & "' and log.TEMPLATE_CODE=TL.TEMPLATE_CODE)"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)


            v_strSQL = "SELECT * FROM AFMAST WHERE " & v_strClause
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)


            'Trung.luu tài khoản mới tạo,tự động sinh tiểu khoản
            If v_ds.Tables(0).Rows.Count = 0 Then
                'Tự gen số tiểu khoản
                Dim strACCTNO As String = getAFACCTNO(v_strMessage)

                'Lấy careby
                Dim strCAREBY As String
                v_strSQL = "select careby from cfmast where " & v_strClause
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                strCAREBY = IIf(v_ds.Tables(0).Rows(0)(0) Is DBNull.Value, String.Empty, v_ds.Tables(0).Rows(0)(0))

                v_strSQL = "INSERT INTO afmast (ACTYPE, CUSTID, ACCTNO, AFTYPE, BANKACCTNO, BANKNAME, SWIFTCODE, STATUS, PSTATUS, BRATIO, AUTOADV, ALTERNATEACCT, VIA, COREBANK," & ControlChars.CrLf _
                            & "GROUPLEADER, BRKFEETYPE, TLID, BRID, CAREBY, MRIRATE, MRSRATE, MRMRATE, MRLRATE, MBIRATE, MBSRATE, MBMRATE, MBLRATE, MCIRATE, MCSRATE, MCMRATE, MCLRATE, MRIRATIO," & ControlChars.CrLf _
                            & "MRSRATIO, MRMRATIO, MRLRATIO, ADDRATE, ADDDAY, BASECALLDAY, EXTCALLDAY, TERMOFUSE, DESCRIPTION, ISOTC, PISOTC, DEPOLASTDT, TRIGGERDATE, OPNDATE, CLSDATE, ADVANCELINE," & ControlChars.CrLf _
                            & "DEPOSITLINE, T0AMT, MRCRLIMIT, MRCRLIMITMAX, DPCRLIMITMAX, LIMITDAILY, ISFIXACCOUNT, " & ControlChars.CrLf _
                            & "AUTOTRF, CHGACTYPE, LASTDATE, LAST_CHANGE, TRADELINE, SMSTYPE, PSMSTYPE, BEGINCALLDATE, ENDCALLDATE, ENDTRIGGERDATE, CALLDAY, APPLYSCR, ISTRIGGER, ISODDLOT)" & ControlChars.CrLf _
                            & "VALUES ('0000','" & v_CustID & ",'" & v_CustID & ",'000','','','','A','P',100,'Y','N','F','N','','CF','0022','0001','" & strCAREBY & "',0,0,0,0,100,100,100,100,0,0,0,0,0,0,0,0,0,0,0,0,'001','','N','N','','',TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'',0,0,0,0,0,0,'2000000000000','N','N','N',TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),0,'','','','','','','N','','N' )"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End If

            '23/07/2018 DieuNDA: chuyen cum xu ly nay sang buoc Duyet
            ''longnh phs_p1 2014-11-03 : them thong tin vao tad gd truc tuyen khi khi Gd online = co
            'If v_strTRADEONLINE = "Y" And String.IsNullOrEmpty(v_strCUSTODYCD) = False Then

            '    v_strSQL = "SELECT * FROM OTRIGHT WHERE DELTD = 'N' AND CFCUSTID = '" & v_strCUSTID & "'"
            '    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

            '    If v_ds.Tables(0).Rows.Count = 0 Then
            '        Dim v_strtypetrade, v_strtypetradeSMS, v_strSQL2 As String
            '        Dim v_dtVALDATE, v_dtEXPDATE As Date


            '        v_strtypetrade = "Mật khẩu đặt lệnh của quý khách là:"
            '        v_strtypetradeSMS = "MK dat lenh:"

            '        v_dtVALDATE = Format(Date.Now(), "ddMMMyyyy")
            '        v_dtEXPDATE = DateAdd(DateInterval.Year, 100, v_dtVALDATE)



            '        'Insert infor to OTRIGHT
            '        v_strSQL2 = " INSERT INTO OTRIGHT (AUTOID, CFCUSTID, AUTHCUSTID, AUTHTYPE, VALDATE, EXPDATE, DELTD, LASTCHANGE ) " & ControlChars.CrLf _
            '                & "SELECT SEQ_OTRIGHT.NEXTVAL, '" & v_strCUSTID & "', '" & v_strCUSTID & "', " & ControlChars.CrLf _
            '            & "     '1', getcurrdate, ADD_MONTHS(getcurrdate,1200), 'N', getcurrdate FROM DUAL"
            '        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL2)

            '        v_strSQL2 = " INSERT INTO OTRIGHTMEMO (AUTOID, CFCUSTID, AUTHCUSTID, AUTHTYPE, VALDATE, EXPDATE, DELTD, LASTCHANGE ) " & ControlChars.CrLf _
            '                & "SELECT SEQ_OTRIGHT.NEXTVAL, '" & v_strCUSTID & "', '" & v_strCUSTID & "', " & ControlChars.CrLf _
            '            & "     '1', getcurrdate, ADD_MONTHS(getcurrdate,1200), 'N', getcurrdate FROM DUAL"

            '        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL2)

            '        'Insert rights detail

            '        v_strSQL2 = "INSERT INTO OTRIGHTDTL (AUTOID, CFCUSTID, AUTHCUSTID, OTMNCODE, OTRIGHT, DELTD) " & ControlChars.CrLf _
            '                        & "select SEQ_OTRIGHTDTL.NEXTVAL, '" & v_strCUSTID & "', '" & v_strCUSTID & "', " & ControlChars.CrLf _
            '                        & "CDVAL, 'YYYYYNN', 'N' from allcode where cDtype ='SA' AND CDNAME = 'OTFUNC' AND cduser = 'Y'"
            '        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL2)

            '        v_strSQL2 = "INSERT INTO OTRIGHTDTLMEMO (AUTOID, CFCUSTID, AUTHCUSTID, OTMNCODE, OTRIGHT, DELTD) " & ControlChars.CrLf _
            '                        & "select SEQ_OTRIGHTDTL.NEXTVAL, '" & v_strCUSTID & "', '" & v_strCUSTID & "', " & ControlChars.CrLf _
            '                        & "CDVAL, 'YYYYYNN', 'N' from allcode where cDtype ='SA' AND CDNAME = 'OTFUNC' AND cduser = 'Y'"
            '        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL2)


            '        Dim v_strPass, v_strPass2, v_serial As String
            '        v_strSQL2 = "select substr(sys_guid(),0,10) pass from dual  "
            '        v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL2)
            '        v_strPass = v_ds.Tables(0).Rows(0)("PASS")

            '        'v_strSQL2 = "select substr(sys_guid(),0,10) pass from dual  "
            '        v_strSQL2 = "select cspks_system.fn_passwordgenerator2(6) pass from dual"
            '        v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL2)
            '        v_strPass2 = v_ds.Tables(0).Rows(0)("PASS")
            '        v_serial = ""


            '        v_strSQL2 = " INSERT INTO USERLOGIN (USERNAME, LOGINPWD, AUTHTYPE, TRADINGPWD, STATUS, " & ControlChars.CrLf _
            '                    & "LASTLOGIN, LOGINSTATUS, LASTCHANGED, NUMBEROFDAY, ISMASTER, ISRESET ) " & ControlChars.CrLf _
            '                    & "SELECT CUSTODYCD,GENENCRYPTPASSWORD('" & v_strPass & "'),'1',GENENCRYPTPASSWORD('" & v_strPass2 & "'), " & ControlChars.CrLf _
            '                    & "'A',SYSDATE,'O',SYSDATE,30,'N','Y' FROM CFMAST where  CUSTODYCD is not null and custid = '" & v_strCUSTID & "' "
            '        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL2)

            '        v_strSQL2 = " INSERT INTO USERLOGINMEMO (USERNAME, LOGINPWD, AUTHTYPE, TRADINGPWD, STATUS, " & ControlChars.CrLf _
            '                    & "LASTLOGIN, LOGINSTATUS, LASTCHANGED, NUMBEROFDAY, ISMASTER, ISRESET ) " & ControlChars.CrLf _
            '                    & "SELECT CUSTODYCD,GENENCRYPTPASSWORD('" & v_strPass & "'),'1',GENENCRYPTPASSWORD('" & v_strPass2 & "'), " & ControlChars.CrLf _
            '                    & "'A',SYSDATE,'O',SYSDATE,30,'N','Y' FROM CFMAST where CUSTODYCD is not null and custid = '" & v_strCUSTID & "' "
            '        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL2)

            '        v_strSQL2 = " update CFMAST set username = custodycd, TRADEONLINE = 'Y' where CUSTODYCD is not null and custid = '" & v_strCUSTID & "' "
            '        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL2)

            '        v_strSQL2 = " update CFMASTMEMO set username = custodycd, TRADEONLINE = 'Y' where CUSTODYCD is not null and custid = '" & v_strCUSTID & "' "
            '        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL2)


            '        Dim l_datasourcesql As String

            '        If String.IsNullOrEmpty(v_strCUSTODYCD) = False Then

            '            Dim l_language_type As String
            '            If Mid(v_strCUSTODYCD, 4, 1) = "F" Then
            '                l_language_type = "EN"
            '            Else
            '                l_language_type = ""
            '            End If
            '            l_datasourcesql = "select ''" & v_strCUSTODYCD & "'' username,''" & v_strCUSTODYCD.Substring(4) & "'' loginnum, ''" & v_strPass & "'' loginpwd ,''" & v_strPass2 & "'' tradingpwd, ''" & v_strFULLNAME & "'' fullname,''" & v_strtypetrade & "'' typetrade, ''" & v_strtypetradeSMS & "'' typetradesms, ''" & v_serial & "'' numberserial, ''" & v_strCUSTODYCD & "'' custodycode from dual"

            '            v_strSQL2 = " INSERT INTO emaillog (autoid, email, templateid, datasource, status,afacctno ,createtime,TXDATE,language_type)" & ControlChars.CrLf _
            '                       & "VALUES(seq_emaillog.nextval,'" & v_strEMAIL & "','100E','" & l_datasourcesql & "','A','" & v_strCUSTODYCD & "',SYSDATE,getcurrdate,'" & l_language_type & "')"
            '            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL2)

            '            'v_strSQL2 = " INSERT INTO emaillogmemo (autoid, email, templateid, datasource, status,afacctno ,createtime)" & ControlChars.CrLf _
            '            '           & "VALUES(seq_emaillog.nextval,'" & v_strEMAIL & "','100E','" & l_datasourcesql & "','A','" & v_strCUSTODYCD & "',SYSDATE)"
            '            'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL2)

            '            'CongDCT edit 2015/02/03
            '            'Reason: Edit template SMS

            '            If l_language_type = "EN" Then
            '                l_datasourcesql = "PHS-NOTICE: Account " & v_strCUSTODYCD & ". Log-in password: " & v_strPass & ", ordering password: " & v_strPass2 & ". Please change password after first log-in."
            '            Else
            '                l_datasourcesql = "PHS-TB: TK " & v_strCUSTODYCD & ". Mat khau dang nhap: " & v_strPass & ", mat khau giao dich: " & v_strPass2 & ". Quy khach vui long thay doi mat khau ngay sau khi dang nhap thanh cong."
            '            End If

            '            'l_datasourcesql = "PHS-TB: So TK " & v_strCUSTODYCD & ". Mat khau dang nhap: " & v_strPass & ", mat khau giao dich: " & v_strPass2 & ". Quy khach truy cap www.phs.vn de xem huong dan su dung."

            '            v_strSQL2 = " INSERT INTO emaillog (autoid, email, templateid, datasource, status,afacctno ,createtime,TXDATE)" & ControlChars.CrLf _
            '                       & "VALUES(seq_emaillog.nextval,'" & v_strMOBILESMS & "','101S','" & l_datasourcesql & "','A','" & v_strCUSTODYCD & "',SYSDATE,getcurrdate)"
            '            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL2)

            '            'v_strSQL2 = " INSERT INTO emaillogmemo (autoid, email, templateid, datasource, status,afacctno ,createtime)" & ControlChars.CrLf _
            '            '           & "VALUES(seq_emaillog.nextval,'" & v_strMOBILESMS & "','101S','" & l_datasourcesql & "','A','" & v_strCUSTODYCD & "',SYSDATE)"
            '            'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL2)
            '        End If
            '        End If

            '    End If

        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Overrides Function ProcessAfterEdit(ByVal v_strMessage As String) As Long
        Dim v_lngErrorCode As Long
        Dim v_strSYSVAR, v_strSQLTmp As String, v_DataAccess As New DataAccess
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        'Return ERR_SYSTEM_OK
        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Try

            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strCUSTID, v_strCUSTODYCD, v_strCAREBY, v_strIDTYPE, v_strIDCODE, v_strREFNAME, v_strFULLNAME As String
            Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE, v_strDATEOFBIRTH, v_strIDEXPIRED, v_strIDDATE, v_strTRADEONLINE As String
            Dim v_strSQL, v_strSQLMEMO, v_strAUTHCUSTID, v_strSQLTEMP, v_strCUSTTYPE, v_strTAXCODE, v_strTLID, v_strEMAIL, v_strMOBILESMS As String
            Dim v_BRID As String
            v_BRID = CStr(CType(v_attrColl.GetNamedItem("BRID"), Xml.XmlAttribute).Value)
            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If
            If Not (v_attrColl.GetNamedItem(gc_AtributeTLID) Is Nothing) Then
                v_strTLID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Else
                v_strTLID = String.Empty
            End If

            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strVALUE = .InnerText.ToString()
                    v_strVALUE = v_strVALUE.Replace("'", "''")
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
                        Case "IDDATE"
                            v_strIDDATE = Trim(v_strVALUE)
                        Case "IDEXPIRED"
                            v_strIDEXPIRED = Trim(v_strVALUE)
                        Case "CUSTTYPE"
                            v_strCUSTTYPE = Trim(v_strVALUE)
                        Case "TAXCODE"
                            v_strTAXCODE = Trim(v_strVALUE)
                        Case "REFNAME"
                            v_strREFNAME = Trim(Replace(v_strVALUE, ".", ""))
                        Case "TRADEONLINE"
                            v_strTRADEONLINE = Trim(v_strVALUE)
                        Case "EMAIL"
                            v_strEMAIL = Trim(v_strVALUE)
                        Case "MOBILESMS"
                            v_strMOBILESMS = Trim(v_strVALUE)
                        Case "FULLNAME"
                            v_strFULLNAME = Trim(v_strVALUE)
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

            '23/07/2018 DieuNDA: chuyen cum xu ly nay sang buoc Duyet
            ''longnh phs_p1 2014-11-03 : sua thong tin vao tad gd truc tuyen  khi Gd online = co
            'If v_strTRADEONLINE = "Y" And String.IsNullOrEmpty(v_strCUSTODYCD) = False Then

            '    v_strSQL = "SELECT * FROM OTRIGHT WHERE DELTD = 'N' AND CFCUSTID = '" & v_strCUSTID & "'"
            '    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

            '    If v_ds.Tables(0).Rows.Count = 0 Then
            '        Dim v_strtypetrade, v_strtypetradeSMS, v_strSQL2 As String
            '        Dim v_dtVALDATE, v_dtEXPDATE As Date


            '        v_strtypetrade = "Mật khẩu đặt lệnh của quý khách là:"
            '        v_strtypetradeSMS = "MK dat lenh:"

            '        v_dtVALDATE = Format(Date.Now(), "ddMMMyyyy")
            '        v_dtEXPDATE = DateAdd(DateInterval.Year, 100, v_dtVALDATE)



            '        'Insert infor to OTRIGHT
            '        v_strSQL2 = " INSERT INTO OTRIGHT (AUTOID, CFCUSTID, AUTHCUSTID, AUTHTYPE, VALDATE, EXPDATE, DELTD, LASTCHANGE ) " & ControlChars.CrLf _
            '                & "SELECT SEQ_OTRIGHT.NEXTVAL, '" & v_strCUSTID & "', '" & v_strCUSTID & "', " & ControlChars.CrLf _
            '            & "     '1', getcurrdate, ADD_MONTHS(getcurrdate,1200), 'N', getcurrdate FROM DUAL"
            '        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL2)

            '        v_strSQL2 = " INSERT INTO OTRIGHTMEMO (AUTOID, CFCUSTID, AUTHCUSTID, AUTHTYPE, VALDATE, EXPDATE, DELTD, LASTCHANGE ) " & ControlChars.CrLf _
            '                & "SELECT SEQ_OTRIGHT.NEXTVAL, '" & v_strCUSTID & "', '" & v_strCUSTID & "', " & ControlChars.CrLf _
            '            & "     '1', getcurrdate, ADD_MONTHS(getcurrdate,1200), 'N', getcurrdate FROM DUAL"

            '        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL2)

            '        'Insert rights detail

            '        v_strSQL2 = "INSERT INTO OTRIGHTDTL (AUTOID, CFCUSTID, AUTHCUSTID, OTMNCODE, OTRIGHT, DELTD) " & ControlChars.CrLf _
            '                        & "select SEQ_OTRIGHTDTL.NEXTVAL, '" & v_strCUSTID & "', '" & v_strCUSTID & "', " & ControlChars.CrLf _
            '                        & "CDVAL, 'YYYYYNN', 'N' from allcode where cDtype ='SA' AND CDNAME = 'OTFUNC' AND cduser = 'Y'"
            '        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL2)

            '        v_strSQL2 = "INSERT INTO OTRIGHTDTLMEMO (AUTOID, CFCUSTID, AUTHCUSTID, OTMNCODE, OTRIGHT, DELTD) " & ControlChars.CrLf _
            '                        & "select SEQ_OTRIGHTDTL.NEXTVAL, '" & v_strCUSTID & "', '" & v_strCUSTID & "', " & ControlChars.CrLf _
            '                        & "CDVAL, 'YYYYYNN', 'N' from allcode where cDtype ='SA' AND CDNAME = 'OTFUNC' AND cduser = 'Y'"
            '        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL2)


            '        Dim v_strPass, v_strPass2, v_serial As String
            '        v_strSQL2 = "select substr(sys_guid(),0,10) pass from dual  "
            '        v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL2)
            '        v_strPass = v_ds.Tables(0).Rows(0)("PASS")

            '        v_strSQL2 = "select cspks_system.fn_passwordgenerator2(6) pass from dual  " 'SONLT 20150507: MK dat lenh ban dau la co dinh
            '        v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL2)
            '        v_strPass2 = v_ds.Tables(0).Rows(0)("PASS")
            '        v_serial = ""


            '        v_strSQL2 = " INSERT INTO USERLOGIN (USERNAME, LOGINPWD, AUTHTYPE, TRADINGPWD, STATUS, " & ControlChars.CrLf _
            '                    & "LASTLOGIN, LOGINSTATUS, LASTCHANGED, NUMBEROFDAY, ISMASTER, ISRESET ) " & ControlChars.CrLf _
            '                    & "SELECT CUSTODYCD,GENENCRYPTPASSWORD('" & v_strPass & "'),'1',GENENCRYPTPASSWORD('" & v_strPass2 & "'), " & ControlChars.CrLf _
            '                    & "'A',SYSDATE,'O',SYSDATE,30,'N','Y' FROM CFMAST where CUSTODYCD is not null and custid = '" & v_strCUSTID & "' "
            '        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL2)

            '        v_strSQL2 = " INSERT INTO USERLOGINMEMO (USERNAME, LOGINPWD, AUTHTYPE, TRADINGPWD, STATUS, " & ControlChars.CrLf _
            '                    & "LASTLOGIN, LOGINSTATUS, LASTCHANGED, NUMBEROFDAY, ISMASTER, ISRESET ) " & ControlChars.CrLf _
            '                    & "SELECT CUSTODYCD,GENENCRYPTPASSWORD('" & v_strPass & "'),'1',GENENCRYPTPASSWORD('" & v_strPass2 & "'), " & ControlChars.CrLf _
            '                    & "'A',SYSDATE,'O',SYSDATE,30,'N','Y' FROM CFMAST where CUSTODYCD is not null and custid = '" & v_strCUSTID & "' "
            '        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL2)

            '        v_strSQL2 = " update CFMAST set username = custodycd, TRADEONLINE = 'Y' where  CUSTODYCD is not null and custid = '" & v_strCUSTID & "' "
            '        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL2)

            '        v_strSQL2 = " update CFMASTMEMO set username = custodycd, TRADEONLINE = 'Y' where CUSTODYCD is not null and custid = '" & v_strCUSTID & "' "
            '        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL2)


            '        Dim l_datasourcesql As String


            '        l_datasourcesql = "select ''" & v_strCUSTODYCD & "'' username,''" & v_strCUSTODYCD.Substring(4) & "'' loginnum, ''" & v_strPass & "'' loginpwd ,''" & v_strPass2 & "'' tradingpwd, ''" & v_strFULLNAME & "'' fullname,''" & v_strtypetrade & "'' typetrade, ''" & v_strtypetradeSMS & "'' typetradesms, ''" & v_serial & "'' numberserial, ''" & v_strCUSTODYCD & "'' custodycode from dual"

            '        v_strSQL2 = " INSERT INTO emaillog (autoid, email, templateid, datasource, status,afacctno ,createtime,TXDATE)" & ControlChars.CrLf _
            '                   & "VALUES(seq_emaillog.nextval,'" & v_strEMAIL & "','100E','" & l_datasourcesql & "','A','" & v_strCUSTODYCD & "',SYSDATE,getcurrdate)"
            '        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL2)

            '        'v_strSQL2 = " INSERT INTO emaillogmemo (autoid, email, templateid, datasource, status,afacctno ,createtime)" & ControlChars.CrLf _
            '        '           & "VALUES(seq_emaillog.nextval,'" & v_strEMAIL & "','100E','" & l_datasourcesql & "','A','" & v_strCUSTODYCD & "',SYSDATE)"
            '        'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL2)


            '        If Mid(v_strCUSTODYCD, 4, 1) = "F" Then
            '            l_datasourcesql = "PHS-NOTICE: Account " & v_strCUSTODYCD & ". Log-in password: " & v_strPass & ", ordering password: " & v_strPass2 & ". Please change password after first log-in."
            '        Else
            '            l_datasourcesql = "PHS-TB: TK " & v_strCUSTODYCD & ". Mat khau dang nhap: " & v_strPass & ", mat khau giao dich: " & v_strPass2 & ". Quy khach vui long thay doi mat khau ngay sau khi dang nhap thanh cong."
            '        End If

            '        'l_datasourcesql = "PHS-TB: So TK " & v_strCUSTODYCD & ". Mat khau dang nhap: " & v_strPass & ", mat khau giao dich: " & v_strPass2 & ". Quy khach truy cap www.phs.vn de xem huong dan su dung."

            '        v_strSQL2 = " INSERT INTO emaillog (autoid, email, templateid, datasource, status,afacctno ,createtime,TXDATE)" & ControlChars.CrLf _
            '                   & "VALUES(seq_emaillog.nextval,'" & v_strMOBILESMS & "','101S','" & l_datasourcesql & "','A','" & v_strCUSTODYCD & "',SYSDATE,getcurrdate)"
            '        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL2)

            '        'v_strSQL2 = " INSERT INTO emaillogmemo (autoid, email, templateid, datasource, status,afacctno ,createtime)" & ControlChars.CrLf _
            '        '           & "VALUES(seq_emaillog.nextval,'" & v_strMOBILESMS & "','101S','" & l_datasourcesql & "','A','" & v_strCUSTODYCD & "',SYSDATE)"
            '        'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL2)

            '    End If
            'ElseIf v_strTRADEONLINE = "N" Then
            If v_strTRADEONLINE = "N" Then
                Dim v_arrTABLE(4) As String
                v_arrTABLE(0) = "OTRIGHT"
                v_arrTABLE(1) = "OTRIGHTDTL"
                v_arrTABLE(2) = "USERLOGIN"
                v_arrTABLE(3) = "EMAILLOG"
                v_arrTABLE(4) = "CFMAST"


                v_lngErrorCode = VerifyMemoTable(v_arrTABLE)
                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                    Rollback()
                    Return v_lngErrorCode
                End If

                'Insert infor to OTRIGHT
                v_strSQL = "BEGIN "
                v_strSQLMEMO = "BEGIN "


                v_strSQLTEMP = "select CFCUSTID,AUTHCUSTID from OTRIGHT where DELTD = 'N' AND CFCUSTID = '" & v_strCUSTID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQLTEMP)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_strCUSTID = v_ds.Tables(0).Rows(0)("CFCUSTID")
                    'v_strAUTHCUSTID = v_ds.Tables(0).Rows(0)("AUTHCUSTID")
                End If
                'Update infor to OTRIGHT
                v_strSQL = v_strSQL & " UPDATE OTRIGHT SET " & ControlChars.CrLf _
                        & "     DELTD = 'Y', " & ControlChars.CrLf _
                        & "     LASTCHANGE = getcurrdate " & ControlChars.CrLf _
                        & "WHERE CFCUSTID = '" & v_strCUSTID & "' AND DELTD = 'N'; "
                v_strSQLMEMO = v_strSQLMEMO & " UPDATE OTRIGHT SET " & ControlChars.CrLf _
                        & "     DELTD = 'Y', " & ControlChars.CrLf _
                        & "     LASTCHANGE = getcurrdate " & ControlChars.CrLf _
                        & "WHERE CFCUSTID = '" & v_strCUSTID & "' AND DELTD = 'N'; "
                'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                'Update rights detail
                v_strSQL = v_strSQL & " UPDATE OTRIGHTDTL SET " & ControlChars.CrLf _
                        & "     DELTD = 'Y' " & ControlChars.CrLf _
                        & " WHERE CFCUSTID = '" & v_strCUSTID & "';"

                v_strSQLMEMO = v_strSQLMEMO & " UPDATE OTRIGHTDTL SET " & ControlChars.CrLf _
                        & "     DELTD = 'Y' " & ControlChars.CrLf _
                        & " WHERE CFCUSTID = '" & v_strCUSTID & "' ;"
                'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                'Update infor to Userlogin
                'Khong s/d luong email nay
                'v_strSQL = v_strSQL & " UPDATE USERLOGIN SET " & ControlChars.CrLf _
                '        & "     STATUS = 'E', " & ControlChars.CrLf _
                '        & "     LASTCHANGED = getcurrdate " & ControlChars.CrLf _
                '        & "WHERE USERNAME = (select custodycd from cfmast where custid = '" & v_strCUSTID & "') AND STATUS = 'A'; "
                'v_strSQLMEMO = v_strSQLMEMO & " UPDATE USERLOGIN SET " & ControlChars.CrLf _
                '                    & "     STATUS = 'E', " & ControlChars.CrLf _
                '                    & "     LASTCHANGED = getcurrdate " & ControlChars.CrLf _
                '                    & "WHERE USERNAME = (select custodycd from cfmast where custid = '" & v_strCUSTID & "') AND STATUS = 'A'; "

                'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                v_strSQL = v_strSQL & " END;"
                v_strSQLMEMO = v_strSQLMEMO & " END;"

                v_lngErrorCode = RunApprExecSql(pv_xmlDocument, gc_ActionAdd, v_strSQL, CommandType.Text, v_strSQLMEMO)
                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                    Rollback() 'ContextUtil.SetAbort()
                    Return v_lngErrorCode
                    Exit Function
                End If

                Dim result As Long
                result = Me.MaintainLog(pv_xmlDocument, gc_ActionDelete)
                If Not (result = ERR_APPROVE_REQUIRED Or result = ERR_SYSTEM_OK) Then
                    Return result
                End If

            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Function
#End Region

End Class
