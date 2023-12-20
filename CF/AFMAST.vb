Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data

Public Class AFMAST
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "AFMAST"
    End Sub

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
                Case "AFMAST_Delete"
                    v_lngErrCode = AFMAST_Delete(v_strObjMsg)
                Case "GetAFtypes"
                    v_lngErrCode = GetAFtypes(v_strObjMsg)
                Case "GetPortfolio"
                    v_lngErrCode = GetPortfolio(v_strObjMsg)
                Case "GetCTCIOrder"
                    v_lngErrCode = GetCTCIOrder(v_strObjMsg)
                Case "GetIOD"
                    v_lngErrCode = GetIOD(v_strObjMsg)
                Case "InquiryAccount"
                    v_lngErrCode = InquiryAccount(v_strObjMsg)
                Case "ExternalUpdateAFMAST"
                    v_lngErrCode = ExternalUpdateAFMAST(v_strObjMsg)
                Case "CheckBankAcctAuthorize"
                    v_lngErrCode = CheckBankAcctAuthorize(v_strObjMsg)
                Case "GetOD4Group"
                    v_lngErrCode = GetOD4Group(v_strObjMsg)
                Case "GetAvailableMarginQuantity"
                    v_lngErrCode = GetAvailableMarginQuantity(v_strObjMsg)
            End Select
            v_strMessage = v_strObjMsg
            Return v_lngErrCode

        Catch ex As Exception
            Throw ex
        End Try
    End Function

#Region " Overrides functions "
    Public Overrides Function CheckBeforeEdit(ByVal v_strMessage As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CF.Trans.ApproveContract", v_strErrorMessage As String

        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_strSQL As String = String.Empty
        Dim v_strObjMsg, v_strACTYPE, v_strSQL1 As String
        Dim v_strCIACTYPE, v_strSEACTYPE, v_strLNACTYPE, v_strLNFTYPE, v_strLNACCTNO, v_strOLDMARGINTYPE, v_strNEWMARGINTYPE, v_strNEW_IS_MARGIN, v_strOLD_IS_MARGIN As String
        Dim v_strCoreBank As String, v_strBankName, v_strOldBankName As String, v_strOldCoreBank As String
        Dim v_strNewCoreBank As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strACCTNO, v_strCUSTODYCD, v_strCUSTID, v_strETS, v_strAUTOADV, v_strBankAcctNo As String
            Dim v_strISMARGINACC, v_strMARGINALLOW, v_strMRGTYPENEW, v_strMRGTYPEOLD, v_strCHKSYSCTRLNEW, v_strCHKSYSCTRLOLD As String
            Dim v_strMRTYPE_Old, v_strMRTYPE_New As String
            Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String
            Dim v_strCHKSYSCTRL As String

            Dim v_strBRID, v_strTXDATE As String
            v_strBRID = CStr(CType(v_attrColl.GetNamedItem("BRID"), Xml.XmlAttribute).Value)

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
                        Case "ACCTNO"
                            v_strACCTNO = Trim(v_strVALUE)
                        Case "ETS"
                            v_strETS = Trim(v_strVALUE)
                        Case "CUSTID"
                            v_strCUSTID = Trim(v_strVALUE)
                        Case "CUSTODYCD"
                            v_strCUSTODYCD = Trim(v_strVALUE)
                        Case "ACTYPE"
                            v_strACTYPE = Trim(v_strVALUE)
                        Case "AUTOADV"
                            v_strAUTOADV = Trim(v_strVALUE)
                        Case "BANKNAME"
                            v_strBankName = Trim(v_strVALUE).ToUpper()
                        Case "BANKACCTNO"
                            v_strBankAcctNo = Trim(v_strVALUE).ToUpper()
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

            v_strSQL = "SELECT * FROM AFMAST WHERE ACCTNO = '" & v_strACCTNO & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            Try
                v_strCoreBank = v_ds.Tables(0).Rows(0)("COREBANK")
                v_strOldBankName = v_ds.Tables(0).Rows(0)("BANKNAME")
                v_strOldCoreBank = v_ds.Tables(0).Rows(0)("COREBANK")

            Catch ex As Exception
            End Try

            'TungNT added
            'Neu thay doi ten ngan hang
            'Can kiem tra xem cimast balane,holdbalane,pendinghold,pendingunhold phai khong con tien
            If v_strOldBankName <> v_strBankName AndAlso v_strOldCoreBank = "Y" Then
                'Kiem tra trong CIMAST da co chua? Tranh truong hop chua sinh CIMAST ma da kiem tra
                v_strSQL = "SELECT COUNT(1) FROM DDMAST WHERE AFACCTNO='" & v_strACCTNO & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    v_strSQL = "SELECT ACCTNO FROM DDMAST WHERE AFACCTNO='" & v_strACCTNO &
                               "' AND BALANCE=0 AND HOLDBALANCE=0 AND PENDINGHOLD=0 AND PENDINGUNHOLD=0"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count <= 0 Then
                        Return ERR_SA_CANNOT_CHANGE_BANKNAME
                    End If
                End If
            End If
            'End

            'Kiem tra trang thai cua khach hang
            'Khong cho sua thong tin khach hang dang phong toa, cho dong, dong
            v_strSQL = "SELECT COUNT(1) FROM " & ATTR_TABLE & " WHERE ACCTNO = '" & v_strACCTNO & "' AND STATUS IN ('B','N','C')"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count >= 1 Then
                If v_ds.Tables(0).Rows(0)(0) >= 1 Then
                    Return ERR_CF_AFMAST_STATUS_INVALID
                End If
            End If

            'Thay doi loai hinh tieu khoan
            'v_strSQL = "SELECT COUNT(1) FROM AFMAST WHERE ACCTNO = '" & v_strACCTNO & "' AND ACTYPE = '" & v_strACTYPE & "'"
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'If v_ds.Tables(0).Rows(0)(0) = 0 Then

            '    'Kiem tra loai hinh tieu khoan - không được khác MRTYPE cũ
            '    '1.1 Lay loai hinh MARGINTYPE cu.
            '    v_strSQL = "SELECT MR.MRTYPE FROM AFMAST AF, AFTYPE AC, MRTYPE MR WHERE AF.ACTYPE = AC.ACTYPE AND AC.MRTYPE = MR.ACTYPE AND AF.ACCTNO = '" & v_strACCTNO & "'"
            '    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            '    If (v_ds.Tables(0).Rows.Count = 1) Then
            '        v_strMRTYPE_Old = v_ds.Tables(0).Rows(0)(0)
            '    End If
            '    '1.2 Lay loai hinh MARGINTYPE moi.
            '    v_strSQL = "SELECT B.MRTYPE FROM AFTYPE A, MRTYPE B WHERE A.MRTYPE = B.ACTYPE AND A.ACTYPE = '" & v_strACTYPE & "'"
            '    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            '    If (v_ds.Tables(0).Rows.Count = 1) Then
            '        v_strMRTYPE_New = v_ds.Tables(0).Rows(0)(0)
            '    End If


            '    'Lay CITYPE, SETYPE, LNTYPE trong aftype tuong ung voi v_strACTYPE (loai hinh tieu khoan moi)
            '    v_strSQL = "SELECT CITYPE, SETYPE, LNTYPE, COREBANK FROM AFTYPE WHERE ACTYPE = '" & v_strACTYPE & "'"
            '    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            '    If v_ds.Tables(0).Rows.Count = 1 Then
            '        v_strCIACTYPE = IIf(v_ds.Tables(0).Rows(0)(0) Is DBNull.Value, String.Empty, v_ds.Tables(0).Rows(0)(0))
            '        v_strSEACTYPE = IIf(v_ds.Tables(0).Rows(0)(1) Is DBNull.Value, String.Empty, v_ds.Tables(0).Rows(0)(1))
            '        v_strLNACTYPE = IIf(v_ds.Tables(0).Rows(0)(2) Is DBNull.Value, String.Empty, v_ds.Tables(0).Rows(0)(2))
            '        v_strNewCoreBank = IIf(v_ds.Tables(0).Rows(0)(3) Is DBNull.Value, String.Empty, v_ds.Tables(0).Rows(0)(3))
            '    End If


            '    'Khong thay doi loai hinh tieu khoan.
            '    If v_strCIACTYPE = String.Empty OrElse v_strSEACTYPE = String.Empty Then
            '        Return ERR_CF_AFTYPE_MISS_OTHERSTYPE
            '    End If

            '    ''UPDATE ACTYPE CUA CIMAST
            '    'v_strSQL = "UPDATE CIMAST SET ACTYPE = '" & v_strCIACTYPE & "', COREBANK ='" & v_strNewCoreBank & "' WHERE AFACCTNO = '" & v_strACCTNO & "'"
            '    'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            '    ''UPDATE ACTYPE CUA SEMAST
            '    'v_strSQL = "UPDATE SEMAST SET ACTYPE = '" & v_strSEACTYPE & "' WHERE AFACCTNO = '" & v_strACCTNO & "'"
            '    'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)


            'End If

            'v_strSQL = "select count(1) EXISTSVAL from aftype, mrtype mrt  " & ControlChars.CrLf _
            '        & "where aftype.actype = '" & v_strACTYPE & "' and aftype.mrtype = mrt.actype and mrt.mrtype in ('S','T') " & ControlChars.CrLf _
            '        & "and (exists (select 1 from afidtype a, lntype l where aftype.actype = a.aftype and a.objname = 'LN.LNTYPE' and a.actype = l.actype and l.chksysctrl = 'Y') " & ControlChars.CrLf _
            '        & "    or exists (select 1 from lntype lnt where lnt.actype = aftype.lntype and lnt.chksysctrl = 'Y')) "
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'If v_ds.Tables(0).Rows(0)("EXISTSVAL") > 0 Then ' Day la loai hinh Margin TT74
            '    ''Kiem tra khach hang co duoc tao tk Margin khong
            '    v_strSQL = "SELECT MARGINALLOW FROM CFMAST CF  WHERE CF.CUSTID ='" & v_strCUSTID & "'"
            '    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            '    If v_ds.Tables(0).Rows.Count > 0 Then
            '        If CStr(v_ds.Tables(0).Rows(0)("MARGINALLOW")).Equals("N") Then
            '            Return ERR_CF_MARGIN_NOT_ALLOW
            '        End If
            '    End If

            'End If

            'If v_strAUTOADV = "N" AndAlso (v_strMRTYPE_New = "T" Or v_strMRTYPE_New = "S") Then
            '    Return ERR_CF_MARGIN_CL_AUTOADV_EQUAL_Y
            'End If

            'Kiem tra: Neu tieu khoan la Margin Creditline -> Bat buoc la tu dong ung truoc AUTOADV = Y.
            'v_strSQL = "SELECT B.MRTYPE FROM AFTYPE A, MRTYPE B WHERE A.MRTYPE = B.ACTYPE AND A.ACTYPE = '" & v_strACTYPE & "'"
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'If (v_ds.Tables(0).Rows.Count = 1) Then
            '    If (v_ds.Tables(0).Rows(0)("MRTYPE") = "T" Or v_ds.Tables(0).Rows(0)("MRTYPE") = "S") And v_strAUTOADV = "N" Then
            '        Return ERR_CF_MARGIN_CL_AUTOADV_EQUAL_Y
            '    End If
            'End If

            ''Kiem tra: Neu tieu khoan la Margin Creditline -> Bat buoc la tu dong ung truoc AUTOADV = Y.
            'v_strSQL = "select count(1) EXISTSVAL from aftype aft0  " & ControlChars.CrLf _
            '     & "where actype = '" & v_strACTYPE & "' " & ControlChars.CrLf _
            '     & "and (exists (select 1 from lntype lnt1 where aft0.lntype = lnt1.actype and lnt1.chksysctrl = 'Y') " & ControlChars.CrLf _
            '     & "or exists (select 1 from lntype lnt2, afidtype afi where afi.objname = 'LN.LNTYPE' and afi.actype = lnt2.actype  " & ControlChars.CrLf _
            '     & "                        and afi.aftype = aft0.actype and lnt2.chksysctrl = 'Y')) "

            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'If v_ds.Tables(0).Rows(0)("EXISTSVAL") > 0 Then
            '    v_strNEW_IS_MARGIN = "Y"
            'Else
            '    v_strNEW_IS_MARGIN = "N"
            'End If

            '--TK cu co phai la Margin hay khong?
            'v_strSQL = "select count(1) EXISTSVAL from afmast af " & ControlChars.CrLf _
            '    & "where af.acctno = '" & v_strACCTNO & "' and af.status in ('A','B','P') " & ControlChars.CrLf _
            '    & "and (exists (select 1 from afidtype a, lntype l where to_char(af.actype) = to_char(a.aftype) and a.objname = 'LN.LNTYPE' and a.actype = l.actype and l.chksysctrl = 'Y') " & ControlChars.CrLf _
            '    & "     or exists (select 1 from lnmast ln, lntype lnt where ln.trfacctno = af.acctno and ln.actype = lnt.actype and lnt.chksysctrl = 'Y' and prinnml + prinovd > 0) " & ControlChars.CrLf _
            '    & "     or exists (select 1 from aftype aft, lntype lnt where aft.lntype = lnt.actype and af.actype = aft.actype and lnt.chksysctrl = 'Y')) "
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'If v_ds.Tables(0).Rows(0)(0) > 0 Then
            '    v_strOLD_IS_MARGIN = "Y"
            'Else
            '    v_strOLD_IS_MARGIN = "N"
            'End If

            'Kiem tra khi chuyen doi tu MRTYPE = N sang MRTYPE = T. Kiem tra het du no. Chuyen LNMAST ve backup. Hoac nguoc lai tu Margin sang thuong kiem tra het du no
            'If v_strMRTYPE_New <> v_strMRTYPE_Old AndAlso v_strMRTYPE_New = "N" Then
            'If v_strMRTYPE_New <> v_strMRTYPE_Old Then
            '    v_strSQL = "select count(1) EXISTSVAL from cimast ci where afacctno = '" & v_strACCTNO & "' and trunc(ODAMT,0) > 0 "
            '    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            '    If v_ds.Tables(0).Rows(0)("EXISTSVAL") > 0 Then 'Co Du no.
            '        Return ERR_CF_AFTYPE_CANNOT_CHANGE
            '    End If

            '    v_strSQL = "select count(1) EXISTSVAL from lnmast ln where trfacctno = '" & v_strACCTNO & "' " & ControlChars.CrLf _
            '            & " and ftype = 'AF' and (trunc(prinnml+prinovd+intnmlacr+intdue+intovdacr+intnmlovd+feeintnmlacr+feeintdue+feeintovdacr+feeintnmlovd,0) > 0 " & ControlChars.CrLf _
            '            & "                         or trunc(oprinnml + oprinovd + ointnmlacr + ointdue + ointovdacr + ointnmlovd,0) > 0) "
            '    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            '    If v_ds.Tables(0).Rows(0)("EXISTSVAL") > 0 Then 'Co Du no.
            '        Return ERR_CF_AFTYPE_CANNOT_CHANGE
            '    End If

            '    'Backup mon vay da tat toan
            '    v_strSQL = "insert into lnschdhist select * from lnschd where acctno in (select acctno from lnmast where trfacctno = '" & v_strACCTNO & "' and ftype = 'AF')"
            '    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            '    v_strSQL = "delete lnschd where acctno in (select acctno from lnmast where trfacctno = '" & v_strACCTNO & "' and ftype = 'AF')"
            '    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            '    v_strSQL = "insert into lnmasthist select * from lnmast where trfacctno = '" & v_strACCTNO & "' and ftype = 'AF' and not exists (select 1 from lnschd where lnschd.acctno = lnmast.acctno)"
            '    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            '    v_strSQL = "delete lnmast where trfacctno = '" & v_strACCTNO & "' and ftype = 'AF' and not exists (select 1 from lnschd where lnschd.acctno = lnmast.acctno)"
            '    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            'End If

            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If

            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Overrides Function CheckBeforeDelete(ByVal v_strMessage As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CF.AFMAST.CheckBeforeDelete", v_strErrorMessage As String

        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_strSQL As String = String.Empty
        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strACCTNO, v_strCUSTODYCD, v_strCUSTID, v_strCLAUSE As String
            Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String

            Dim v_strBRID, v_strTXDATE As String
            v_strBRID = CStr(CType(v_attrColl.GetNamedItem("BRID"), Xml.XmlAttribute).Value)

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

            If Not (v_attrColl.GetNamedItem(gc_AtributeCLAUSE) Is Nothing) Then
                v_strCLAUSE = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Else
                v_strCLAUSE = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeRESERVER) Is Nothing) Then
                v_strACCTNO = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeRESERVER), Xml.XmlAttribute).Value)
            Else
                v_strACCTNO = String.Empty
            End If

            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            'Kiem tra trang thai cua khach hang
            'Khong cho xoa tk khach hang co trang thai khac Cho Duyet             
            v_strSQL = "select af.status from afmast af where af.acctno = '" & v_strACCTNO & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows(0)("STATUS") <> "P" Then
                Return ERR_CF_AFMAST_STATUS_INVALID
            End If

            'Khong cho xoa tk khach hang co trang thai Cho Duyet ma chua duyet lan nao (nghia la chua sinh CIMAST)
            'v_strSQL = "SELECT COUNT(1) FROM " & ATTR_TABLE & " WHERE " & v_strCLAUSE & " AND status = 'P' AND instr(pstatus,'A') <= 0"
            v_strSQL = "select count(1) from afmast af, ddmast ci where af.acctno = ci.afacctno and ci." & v_strCLAUSE & " AND af.status = 'P'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows(0)(0) > 0 Then
                Return ERR_CF_AFMAST_STATUS_INVALID
            End If

            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Overrides Function CheckBeforeApprove(ByVal v_strMessage As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CF.Trans.ApproveContract", v_strErrorMessage As String
        Dim v_strSQL As String = String.Empty
        Dim pv_xmlDocument As New XmlDocumentEx
        Dim v_strClause, v_strTXDATE As String

        pv_xmlDocument.LoadXml(v_strMessage)

        Try
            v_strClause = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCLAUSE).Value
            v_strTXDATE = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value

            Dim v_strCUSTID, v_strACTYPE, v_strAPPLID As String
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_ds As DataSet

            v_strSQL = "SELECT ACCTNO, CUSTID, ACTYPE FROM AFMAST WHERE " + v_strClause
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 1 Then
                v_strAPPLID = v_ds.Tables(0).Rows(0)("ACCTNO")
                v_strCUSTID = v_ds.Tables(0).Rows(0)("CUSTID")
                v_strACTYPE = v_ds.Tables(0).Rows(0)("ACTYPE")
            Else
                v_lngErrCode = ERR_CF_ACCTNO_DUPLICATE
                Return v_lngErrCode
            End If

            Dim v_strAFTYPE, v_strCITYPE, v_strSETYPE, v_strMarginType, v_strcorebank As String
            v_strSQL = "SELECT AF.* MARGINTYPE FROM AFTYPE AF MR WHERE AF.STATUS='Y' AND AF.ACTYPE='" & v_strACTYPE & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_strAFTYPE = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("AFTYPE")), vbNullString, v_ds.Tables(0).Rows(0)("AFTYPE"))
                v_strCITYPE = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("CITYPE")), vbNullString, v_ds.Tables(0).Rows(0)("CITYPE"))
                v_strSETYPE = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("SETYPE")), vbNullString, v_ds.Tables(0).Rows(0)("SETYPE"))
                v_strMarginType = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("MARGINTYPE")), vbNullString, v_ds.Tables(0).Rows(0)("MARGINTYPE"))
                v_strcorebank = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("COREBANK")), vbNullString, v_ds.Tables(0).Rows(0)("COREBANK"))
            Else
                v_lngErrCode = ERR_CF_AFTYPE_NOTFOUND
                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                             & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                             & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                Return v_lngErrCode
            End If

            v_strSQL = "SELECT * FROM AFMAST WHERE ACCTNO='" & v_strAPPLID & "' AND STATUS ='A'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_lngErrCode = ERR_CF_ACCTNO_DUPLICATE
                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                             & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                             & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                Return v_lngErrCode
            End If

            Dim v_strSTATUS As String
            v_strSQL = "SELECT * FROM CFMAST WHERE CUSTID='" & v_strCUSTID & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_strSTATUS = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("STATUS")), vbNullString, v_ds.Tables(0).Rows(0)("STATUS"))
                If v_strSTATUS <> "A" Then
                    v_lngErrCode = ERR_INVALID_CFMAST_STATUS
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If
            Else
                v_lngErrCode = ERR_CF_CUSTOMER_NOTFOUND
                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                             & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                             & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                Return v_lngErrCode
            End If

            Dim v_strCIACCTNO, v_strCCYCD, v_strICCFCD, v_strICCFTIED As String
            Dim v_dblMINBAL As Long

            v_strSQL = "SELECT custodycd FROM cfmast cf, afmast af WHERE cf.opndate is null and af.custid = cf.custid AND cf.custodycd IS NOT NULL AND cf.custid = '" & v_strCUSTID & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_strSQL = "update cfmast set OPNDATE = to_date('" & v_strTXDATE & "','DD/MM/RRRR') , " & ControlChars.CrLf _
                            & " lastdate = to_date('" & v_strTXDATE & "','DD/MM/RRRR') , " & ControlChars.CrLf _
                            & " activedate = to_date('" & v_strTXDATE & "','DD/MM/RRRR') " & ControlChars.CrLf _
                            & " where custid = '" & v_strCUSTID & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End If


            'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Overrides Function CheckBeforeAdd(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strACCTNO, v_strCUSTID, v_strAUTOADV As String
            Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String
            Dim v_strSQL As String
            Dim v_strBRID, v_strTXDATE, v_strTLID As String
            Dim v_strACTYPE, v_strISMARGINACC, v_strMARGINALLOW, v_strMRGTYPENEW, v_strMRGTYPEOLD,
            v_strCOREBANK, v_strBankName, v_strBankAcct, v_strMRCRLIMITMAX, v_strDPCRLIMITMAX As String
            Dim v_strCHKSYSCTRL As String


            v_strBRID = CStr(CType(v_attrColl.GetNamedItem("BRID"), Xml.XmlAttribute).Value)

            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strTLID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Else
                v_strTLID = String.Empty
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
                        Case "ACCTNO"
                            v_strACCTNO = Trim(v_strVALUE)
                        Case "CUSTID"
                            v_strCUSTID = Trim(v_strVALUE)
                        Case "ACTYPE"
                            v_strACTYPE = Trim(v_strVALUE)
                        Case "AUTOADV"
                            v_strAUTOADV = Trim(v_strVALUE)
                        Case "BANKACCTNO"
                            v_strBankAcct = Trim(v_strVALUE)
                        Case "BANKNAME"
                            v_strBankName = Trim(v_strVALUE)
                        Case "MRCRLIMITMAX"
                            v_strMRCRLIMITMAX = Trim(v_strVALUE)
                        Case "DPCRLIMITMAX"
                            v_strDPCRLIMITMAX = Trim(v_strVALUE)
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

            'Kiem tra loai hinh tieu khoan
            'v_strSQL = "SELECT * FROM AFTYPE WHERE ACTYPE = '" & v_strACTYPE & "' AND APPRV_STS = 'A'"
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'If v_ds.Tables(0).Rows.Count <> 1 Then
            '    Return ERR_ACTYPE_NOT_APPROVED
            'Else
            '    v_strCOREBANK = v_ds.Tables(0).Rows(0)("COREBANK").ToString().Trim()
            'End If

            'Kiem tra xem ma hop dong co hop le khong
            If ((v_strACCTNO.Length <> 10) Or (Not IsNumeric(v_strACCTNO))) Then
                Return ERR_AF_ACCTNO_ISNUMBERIC
            End If
            'Kiem tra ma chi nhanh co dung khong
            If Strings.Mid(v_strACCTNO, 1, 4) <> v_strBRID Then
                Return ERR_AF_ACCTNO_NOTBELONGBRANCH
            End If
            'Kiểm tra ACCTNO không được trùng
            v_strSQL = "SELECT COUNT(ACCTNO) FROM AFMAST WHERE ACCTNO ='" & v_strACCTNO & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 1 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_CF_ACCTNO_DUPLICATE
                End If
            End If
            'check date
            v_strSQL = "SELECT VARVALUE  FROM SYSVAR WHERE VARNAME = 'CURRDATE'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

            If Not v_strTXDATE Is Nothing Then
                If DDMMYYYY_SystemDate(v_ds.Tables(0).Rows(0)("VARVALUE")) <> DDMMYYYY_SystemDate(v_strTXDATE) Then
                    Return ERR_SA_BUSDATE_BRANCHDATE_PLZLOGIN_OUT
                End If
            End If

            v_strSQL = "select count(1) EXISTSVAL from aftype " & ControlChars.CrLf _
                    & "where aftype.actype = '" & v_strACTYPE & "' and aftype.mrtype in ('S','T') " & ControlChars.CrLf _
                    & "and (exists (select 1 from afidtype a where aftype.actype = a.aftype and a.objname = 'LN.LNTYPE' )) "
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows(0)("EXISTSVAL") > 0 Then ' Day la loai hinh Margin TT74
                ''Kiem tra khach hang co duoc tao tk Margin khong
                'v_strSQL = "SELECT MARGINALLOW FROM CFMAST CF  WHERE CF.CUSTID ='" & v_strCUSTID & "'"
                'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                'If v_ds.Tables(0).Rows.Count > 0 Then
                '    If CStr(v_ds.Tables(0).Rows(0)("MARGINALLOW")).Equals("N") Then
                '        Return ERR_CF_MARGIN_NOT_ALLOW
                '    End If
                'End If

            End If


            'Kiem tra: Neu tieu khoan la Margin Creditline -> Bat buoc la tu dong ung truoc AUTOADV = Y.
            'v_strSQL = "SELECT B.MRTYPE FROM AFTYPE A, MRTYPE B WHERE A.MRTYPE = B.ACTYPE AND A.ACTYPE = '" & v_strACTYPE & "'"
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'If (v_ds.Tables(0).Rows.Count = 1) Then
            '    If (v_ds.Tables(0).Rows(0)("MRTYPE") = "T" Or v_ds.Tables(0).Rows(0)("MRTYPE") = "S") And v_strAUTOADV = "N" Then
            '        Return ERR_CF_MARGIN_CL_AUTOADV_EQUAL_Y
            '    End If
            'End If


            'If CDbl(v_strMRCRLIMITMAX) + CDbl(v_strDPCRLIMITMAX) > 0 Then


            '    'LONGNH 2014-11-06
            '    Dim v_strDPLIMIT, v_strDPLIMITMAX, v_strDPremainlimit, v_strDPusedlimit, v_strDPremainaflimit, v_strDPusedaflimit As Double
            '    Dim v_strMRLIMIT, v_strMRLIMITMAX, v_strMRremainlimit, v_strMRusedlimit, v_strMRremainaflimit, v_strMRusedaflimit As Double
            '    'KHI THEM MOI TIEU KHOAN LAY HAN MUC TU USER ADMIN
            '    v_strSQL = "SELECT * FROM USERLIMIT WHERE TLIDUSER = '" & v_strTLID & "'"

            '    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            '    v_strDPLIMIT = CDbl(v_ds.Tables(0).Rows(0)("DPLIMIT"))          'HAN MUC TRA CHAM DA CAP CHO USER
            '    v_strDPLIMITMAX = CDbl(v_ds.Tables(0).Rows(0)("DPLIMITMAX"))    'HAN MUC TRA CHAM TOI DA USER DC CAP CHO 1 TIEU KHOAN
            '    v_strMRLIMIT = CDbl(v_ds.Tables(0).Rows(0)("ALLOCATELIMMIT"))       'HAN MUC VAY MR DA CAP CHO USER
            '    v_strMRLIMITMAX = CDbl(v_ds.Tables(0).Rows(0)("ACCTLIMIT"))     'HAN MUC VAY MR TOI DA USER DC CAP CHO 1 TIEU KHOAN

            '    v_strSQL = "SELECT nvl(sum(decode(typereceive,'DP',acclimit, 0)),0)  useddplimit, nvl(sum(decode(typereceive,'MR',acclimit, 0)),0) usedmrlimit FROM USERAFLIMIT  WHERE TLIDUSER = '" & v_strTLID & "' "
            '    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            '    v_strDPusedlimit = CDbl(v_ds.Tables(0).Rows(0)("USEDDPLIMIT"))  'HAN MUC DP USER DA CAP 
            '    v_strDPremainlimit = v_strDPLIMIT - v_strDPusedlimit            'HAN MUC DP CON LAI CUA USER DA 
            '    v_strMRusedlimit = CDbl(v_ds.Tables(0).Rows(0)("USEDMRLIMIT"))  'HAN MUC MR USER DA CAP 
            '    v_strMRremainlimit = v_strMRLIMIT - v_strMRusedlimit            'HAN MUC MR CON LAI CUA USER DA 

            '    v_strSQL = "SELECT nvl(sum(decode(ual.typereceive,'DP',acclimit, 0)),0) usedDPaflimit, nvl(sum(decode(ual.typereceive,'MR',acclimit, 0)),0) usedMRaflimit " _
            '               & " FROM USERAFLIMIT ual, afmast af " _
            '               & " WHERE AF.custid = '" & v_strCUSTID & "' AND af.acctno = ual.acctno "
            '    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            '    v_strDPusedaflimit = CDbl(v_ds.Tables(0).Rows(0)("USEDDPAFLIMIT"))
            '    v_strDPremainaflimit = v_strDPLIMITMAX - v_strDPusedaflimit

            '    v_strMRusedaflimit = CDbl(v_ds.Tables(0).Rows(0)("USEDMRAFLIMIT"))
            '    v_strMRremainaflimit = v_strMRLIMITMAX - v_strMRusedaflimit

            '    If v_strMRCRLIMITMAX > v_strMRremainlimit Then
            '        Return ERR_SA_OVER_AVAILABLE_USER_LIMIT
            '    End If

            '    If v_strMRCRLIMITMAX > v_strMRLIMITMAX Then
            '        Return ERR_SA_OVER_AVAILABLE_USER_AFLIMIT
            '    End If

            '    If v_strDPCRLIMITMAX > v_strDPremainlimit Then
            '        Return ERR_SA_OVER_AVAILABLE_USER_LIMIT
            '    End If

            '    If v_strDPCRLIMITMAX > v_strDPLIMITMAX Then
            '        Return ERR_SA_OVER_AVAILABLE_USER_AFLIMIT
            '    End If

            '    Dim V_STRMRLOANLIMIT As Double
            '    v_strSQL = "SELECT MRLOANLIMIT FROM CFMAST WHERE CUSTID = '" & v_strCUSTID & "'"
            '    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            '    V_STRMRLOANLIMIT = CDbl(v_ds.Tables(0).Rows(0)("MRLOANLIMIT")) 'MAN MUC VAY TOI DA CUA TAI KHOAN

            '    If v_strDPusedaflimit + v_strMRusedaflimit + v_strMRCRLIMITMAX + v_strDPCRLIMITMAX > V_STRMRLOANLIMIT Then
            '        Return ERR_SA_OVER_AVAILABLE_CUSTLIMIT
            '    End If
            'End If

            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If

            Return 0
        Catch ex As Exception
            ''ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
        'Return 0
    End Function


#End Region

#Region " Private methods "
    Private Function GetOD4Group(ByRef pv_strObjMsg As String) As Long
        Dim v_obj As DataAccess, v_ds As DataSet, v_strSQL As String
        Dim XMLDocument As New XmlDocumentEx, XMLOrder As New XmlDocumentEx
        Dim v_nodeData As Xml.XmlNode
        Try
            XMLDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
            Dim v_strTellerId As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Dim v_strTxdate As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXDATE), Xml.XmlAttribute).Value)
            Dim v_groupid As Int64
            Dim v_price, v_quantity, v_tradeunit As Double
            Dim v_bors, v_symbol, v_round, v_rate As String

            'CustomerID
            Dim v_strClause As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            XMLOrder.LoadXml(v_strClause)
            v_nodeData = XMLOrder.SelectSingleNode("RootTrade/objPARA")
            For i As Integer = 0 To v_nodeData.ChildNodes.Count - 1
                Select Case v_nodeData.ChildNodes(i).Name
                    Case "GROUPID"
                        If IsNumeric(v_nodeData.ChildNodes(i).InnerText) Then
                            v_groupid = gf_CorrectNumericField(v_nodeData.ChildNodes(i).InnerText)
                        Else
                            v_groupid = 0
                        End If
                    Case "BORS"
                        v_bors = v_nodeData.ChildNodes(i).InnerText
                    Case "SYMBOL"
                        v_symbol = v_nodeData.ChildNodes(i).InnerText
                    Case "PRICE"
                        If IsNumeric(v_nodeData.ChildNodes(i).InnerText) Then
                            v_price = CDbl(v_nodeData.ChildNodes(i).InnerText)
                        Else
                            v_price = 0
                        End If
                    Case "RATE"
                        v_rate = CDbl(v_nodeData.ChildNodes(i).InnerText)
                    Case "ROUND"
                        v_round = v_nodeData.ChildNodes(i).InnerText
                    Case "TRADEUNIT"
                        v_tradeunit = gf_CorrectNumericField(v_nodeData.ChildNodes(i).InnerText)
                End Select
            Next
            Dim v_objRptParam As ReportParameters
            Dim v_arrRptPara() As ReportParameters
            v_obj = New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            ReDim v_arrRptPara(6)
            '0. Condition value
            v_objRptParam = New ReportParameters
            v_objRptParam.ParamName = "pv_GROUPID"
            v_objRptParam.ParamValue = v_groupid
            v_objRptParam.ParamSize = CInt(10)
            v_objRptParam.ParamType = "NUMBER"
            v_arrRptPara(0) = v_objRptParam

            v_objRptParam = New ReportParameters
            v_objRptParam.ParamName = "pv_BORS"
            v_objRptParam.ParamValue = v_bors
            v_objRptParam.ParamSize = CStr(v_bors.Length)
            v_objRptParam.ParamType = "VARCHAR2"
            v_arrRptPara(1) = v_objRptParam

            v_objRptParam = New ReportParameters
            v_objRptParam.ParamName = "pv_SYMBOL"
            v_objRptParam.ParamValue = v_symbol
            v_objRptParam.ParamSize = CStr(v_symbol.Length)
            v_objRptParam.ParamType = "VARCHAR2"
            v_arrRptPara(2) = v_objRptParam

            v_objRptParam = New ReportParameters
            v_objRptParam.ParamName = "pv_PRICE"
            v_objRptParam.ParamValue = v_price
            v_objRptParam.ParamSize = CInt(10)
            v_objRptParam.ParamType = "NUMBER"
            v_arrRptPara(3) = v_objRptParam

            v_objRptParam = New ReportParameters
            v_objRptParam.ParamName = "pv_RATE"
            v_objRptParam.ParamValue = v_rate
            v_objRptParam.ParamSize = CInt(10)
            v_objRptParam.ParamType = "NUMBER"
            v_arrRptPara(4) = v_objRptParam

            v_objRptParam = New ReportParameters
            v_objRptParam.ParamName = "pv_ROUND"
            v_objRptParam.ParamValue = v_round
            v_objRptParam.ParamSize = CStr(v_round.Length)
            v_objRptParam.ParamType = "VARCHAR2"
            v_arrRptPara(5) = v_objRptParam

            v_objRptParam = New ReportParameters
            v_objRptParam.ParamName = "pv_TRADEUNIT"
            v_objRptParam.ParamValue = v_tradeunit
            v_objRptParam.ParamSize = CInt(10)
            v_objRptParam.ParamType = "NUMBER"
            v_arrRptPara(6) = v_objRptParam

            v_ds = v_obj.ExecuteStoredReturnDataset("GetOD4Group", v_arrRptPara)
            'Buld XML data
            BuildXMLObjData(v_ds, pv_strObjMsg)
            Return ERR_SYSTEM_OK
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function GetPortfolio(ByRef pv_strObjMsg As String) As Long
        Dim v_obj As DataAccess, v_ds As DataSet, v_strSQL As String
        Dim XMLDocument As New XmlDocumentEx
        Try
            XMLDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
            Dim v_strTellerId As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Dim v_strTxdate As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXDATE), Xml.XmlAttribute).Value)
            v_strTellerId = Trim(v_strTellerId)
            'CustomerID
            Dim v_strCUSTID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            'v_strSQL = "SELECT CUSTID, AFACCTNO, SYMTYPE, SYMBOL, AVLBAL,MORTAGE, COSTPRICE,nvl(AVLLIMIT,0) AVLLIMIT,nvl(AVLWITHDRAW,0) AVLWITHDRAW " & ControlChars.CrLf & _
            '        "FROM (SELECT MST.CUSTID, DTL.AFACCTNO, 'CI' SYMTYPE, INSTRUMENT.SHORTCD SYMBOL, DTL.BALANCE AVLBAL,0 MORTAGE, 1 COSTPRICE, " & ControlChars.CrLf & _
            '        "MST.ADVANCELINE-AL.OVERAMT-DTL.ODAMT+DTL.BALANCE AVLLIMIT,DTL.BALANCE-DTL.ODAMT-NVL(AL.ADVAMT,0) AVLWITHDRAW " & ControlChars.CrLf & _
            '        "FROM AFMAST MST, CIMAST DTL, SBCURRENCY INSTRUMENT, " & ControlChars.CrLf & _
            '        "(SELECT SUM(QUOTEPRICE*REMAINQTTY*(1+TYP.DEFFEERATE/100)+EXECAMT+RLSSECURED-SECUREDAMT) OVERAMT ,(CASE WHEN SUM(QUOTEPRICE*REMAINQTTY*(1+TYP.DEFFEERATE/100)+EXECAMT+RLSSECURED-SECUREDAMT)-MAX(AF.ADVANCELINE)>0 then SUM(QUOTEPRICE*REMAINQTTY*(1+TYP.DEFFEERATE/100)+EXECAMT+RLSSECURED-SECUREDAMT)-MAX(AF.ADVANCELINE) ELSE 0 END) ADVAMT, MAX(OD.AFACCTNO) AFACCTNO FROM ODMAST OD ,AFMAST AF, ODTYPE TYP WHERE OD.ACTYPE=TYP.ACTYPE AND AF.ACCTNO=OD.AFACCTNO AND AF.ACCTNO=:CUSTID AND OD.TXDATE= TO_DATE((SELECT VARVALUE FROM SYSVAR WHERE GRNAME='SYSTEM' AND VARNAME='CURRDATE'), '" & gc_FORMAT_DATE & "') AND DELTD <>'Y' AND OD.EXECTYPE IN ('NB','BC') GROUP BY AF.CUSTID, AF.ACCTNO ) AL" & ControlChars.CrLf & _
            '        "WHERE MST.ACCTNO=AL.AFACCTNO(+) AND MST.ACCTNO=DTL.AFACCTNO AND DTL.CCYCD=INSTRUMENT.CCYCD AND MST.ACCTNO=:CUSTID " & ControlChars.CrLf & _
            '        "UNION ALL " & ControlChars.CrLf & _
            '        "SELECT MST.CUSTID, DTL.AFACCTNO, 'SE' SYMTYPE, INSTRUMENT.SYMBOL SYMBOL,  " & ControlChars.CrLf & _
            '        "DTL.TRADE AVLBAL,DTL.MORTAGE, DTL.COSTPRICE,0 AVLLIMIT, DTL.TRADE AVLWITHDRAW " & ControlChars.CrLf & _
            '        "FROM AFMAST MST, SEMAST DTL, SBSECURITIES INSTRUMENT " & ControlChars.CrLf & _
            '        "WHERE MST.ACCTNO=DTL.AFACCTNO AND DTL.CODEID=INSTRUMENT.CODEID AND MST.ACCTNO=:CUSTID " & ControlChars.CrLf & _
            '        "AND DTL.TRADE+DTL.MORTAGE <> 0) " & ControlChars.CrLf & _
            '        "ORDER BY CUSTID, AFACCTNO, SYMTYPE, SYMBOL"
            'Dim v_arrInquiryPara() As ReportParameters
            'Dim v_objInquiryParam As ReportParameters

            ''Doc du liệu tìm kiếm
            'v_obj = New DataAccess
            'v_obj.NewDBInstance(gc_MODULE_HOST)
            'ReDim v_arrInquiryPara(0)
            'v_objInquiryParam = New ReportParameters
            'v_objInquiryParam.ParamName = "CUSTID"
            'v_objInquiryParam.ParamValue = v_strCUSTID
            'v_objInquiryParam.ParamSize = v_strCUSTID.Length
            'v_objInquiryParam.ParamType = "String"
            'v_arrInquiryPara(0) = v_objInquiryParam
            'v_ds = v_obj.ExecuteSQLParametersReturnDataset(v_strSQL, v_arrInquiryPara)
            Dim v_objRptParam As ReportParameters
            Dim v_arrRptPara() As ReportParameters
            v_obj = New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            ReDim v_arrRptPara(0)
            '0. Condition value
            v_objRptParam = New ReportParameters
            v_objRptParam.ParamName = "pv_CONDVALUE"
            v_objRptParam.ParamValue = v_strCUSTID
            v_objRptParam.ParamSize = CStr(20)
            v_objRptParam.ParamType = "VARCHAR2"
            v_arrRptPara(0) = v_objRptParam
            v_ds = v_obj.ExecuteStoredReturnDataset("GETPORTFOLIO", v_arrRptPara)
            'Buld XML data
            BuildXMLObjData(v_ds, pv_strObjMsg)
            Return ERR_SYSTEM_OK
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function GetAvailableMarginQuantity(ByRef pv_strObjMsg As String) As Long
        Dim v_obj As DataAccess, v_ds As DataSet, v_strSQL As String
        Dim XMLDocument As New XmlDocumentEx

        Try
            XMLDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
            Dim v_strSymbol As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Dim v_dblMrqtty As Double
            Dim v_objRptParam As ReportParameters
            Dim v_arrRptPara() As ReportParameters
            v_obj = New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            ReDim v_arrRptPara(0)
            '0. Condition value
            v_objRptParam = New ReportParameters
            v_objRptParam.ParamName = "f_symbol"
            v_objRptParam.ParamValue = v_strSymbol
            v_objRptParam.ParamSize = CStr(20)
            v_objRptParam.ParamType = "VARCHAR2"
            v_arrRptPara(0) = v_objRptParam
            v_ds = v_obj.ExecuteStoredReturnDataset("GETMARGINQUANTITYBYSYMBOL", v_arrRptPara)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_dblMrqtty = CDbl(v_ds.Tables(0).Rows(0)("SEQTTY"))
            Else
                v_dblMrqtty = 0
            End If
            v_strSQL = "SELECT INF.*, NVL(RSK.MRMAXQTTY,0) MRMAXQTTY FROM SECURITIES_INFO INF, SECURITIES_RISK RSK WHERE INF.SYMBOL='" & v_strSymbol & "' AND INF.CODEID=RSK.CODEID(+) "
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_dblMrqtty = CDbl(v_ds.Tables(0).Rows(0)("MRMAXQTTY")) - v_dblMrqtty
            Else
                v_dblMrqtty = 0 - v_dblMrqtty
            End If
            XMLDocument.DocumentElement.Attributes.GetNamedItem(gc_AtributeRESERVER).Value = CStr(FRound(v_dblMrqtty, 0))
            pv_strObjMsg = XMLDocument.InnerXml
            Return ERR_SYSTEM_OK
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function GetCTCIOrder(ByRef pv_strObjMsg As String) As Long
        Dim v_obj As DataAccess, v_ds As DataSet, v_strSQL As String
        Dim XMLDocument As New XmlDocumentEx
        Try
            XMLDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
            Dim v_strTellerId As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            v_strTellerId = Trim(v_strTellerId)
            'CustomerID
            Dim v_strCUSTID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            v_strSQL = "SELECT * FROM (SELECT CF.CUSTID,CF.FULLNAME,(CASE WHEN FLOOR_CODE='02'  THEN 'HASTC'  WHEN FLOOR_CODE='10'  THEN 'HOSTC' ELSE 'OTC' END) TRADEPLACE , " & ControlChars.CrLf &
                    "'B' BORS,SEC_CODE,QUANTITY,PRICE,QUANTITY*PRICE AMOUNT,B_ACCOUNT_NO CUSTODYCD ,SUBSTR(REPLACE(MATCH_TIME,':','') || '000000',1,6) MATCHTIME,B_ORDER_NO ORDERID  " & ControlChars.CrLf &
                    "FROM curr_trading_result RS ,CFMAST CF  " & ControlChars.CrLf &
                    "WHERE  RS.B_ACCOUNT_NO=CF.CUSTODYCD AND CF.CUSTID=:CUSTID " & ControlChars.CrLf &
                    "UNION ALL " & ControlChars.CrLf &
                    "SELECT CF.CUSTID,CF.FULLNAME,(CASE WHEN FLOOR_CODE='02'  THEN 'HASTC'  WHEN FLOOR_CODE='10'  THEN 'HOSTC' ELSE 'OTC' END) TRADEPLACE , " & ControlChars.CrLf &
                    "'S' BORS,SEC_CODE,QUANTITY,PRICE,QUANTITY*PRICE AMOUNT,S_ACCOUNT_NO CUSTODYCD ,SUBSTR(REPLACE(MATCH_TIME,':','') || '000000',1,6) MATCHTIME ,S_ORDER_NO ORDERID " & ControlChars.CrLf &
                    " FROM curr_trading_result RS ,CFMAST CF  " & ControlChars.CrLf &
                    "WHERE  RS.S_ACCOUNT_NO=CF.CUSTODYCD AND CF.CUSTID=:CUSTID) ORDER BY MATCHTIME DESC " & ControlChars.CrLf
            Dim v_arrInquiryPara() As ReportParameters
            Dim v_objInquiryParam As ReportParameters

            'Doc du liệu tìm kiếm
            v_obj = New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            ReDim v_arrInquiryPara(0)
            v_objInquiryParam = New ReportParameters
            v_objInquiryParam.ParamName = "CUSTID"
            v_objInquiryParam.ParamValue = v_strCUSTID
            v_objInquiryParam.ParamSize = v_strCUSTID.Length
            v_objInquiryParam.ParamType = "String"
            v_arrInquiryPara(0) = v_objInquiryParam
            v_ds = v_obj.ExecuteSQLParametersReturnDataset(v_strSQL, v_arrInquiryPara)
            'Buld XML data
            BuildXMLObjData(v_ds, pv_strObjMsg)
            Return ERR_SYSTEM_OK
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function GetIOD(ByRef pv_strObjMsg As String) As Long
        Dim v_obj As DataAccess, v_ds As DataSet, v_strSQL As String
        Dim XMLDocument As New XmlDocumentEx
        Try
            XMLDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
            Dim v_strTellerId As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            'CustomerID
            Dim v_strCUSTID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            v_strSQL = "select a.ORGORDERID,a.TXTIME,a.MATCHQTTY QTTY,A.MATCHPRICE PRICE,A.MATCHPRICE*A.MATCHQTTY AMOUNT,nvl(A.CONFIRM_NO,'--------') CONFIRM_NO " & ControlChars.CrLf &
                    "from iod a,odmast b" & ControlChars.CrLf &
                    "where a.deltd <> 'Y' and b.deltd <> 'Y' and a.orgorderid= b.orderid and b.afacctno=:CUSTID" & ControlChars.CrLf
            Dim v_arrInquiryPara() As ReportParameters
            Dim v_objInquiryParam As ReportParameters

            'Doc du liệu tìm kiếm
            v_obj = New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            ReDim v_arrInquiryPara(0)
            v_objInquiryParam = New ReportParameters
            v_objInquiryParam.ParamName = "CUSTID"
            v_objInquiryParam.ParamValue = v_strCUSTID
            v_objInquiryParam.ParamSize = v_strCUSTID.Length
            v_objInquiryParam.ParamType = "String"
            v_arrInquiryPara(0) = v_objInquiryParam
            v_ds = v_obj.ExecuteSQLParametersReturnDataset(v_strSQL, v_arrInquiryPara)
            'Buld XML data
            BuildXMLObjData(v_ds, pv_strObjMsg)
            Return ERR_SYSTEM_OK
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function InquiryAccount(ByRef pv_strObjMsg As String) As Long
        Dim v_obj As DataAccess, v_ds As DataSet, v_strSQL As String
        Dim XMLDocument As New XmlDocumentEx
        Dim v_strClause As String
        Dim v_strInfo() As String
        Dim v_strAFACCTNO, v_strACCTTYPE As String
        Try
            XMLDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
            Dim v_strTellerId As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            v_strTellerId = Trim(v_strTellerId)
            'CustomerID
            v_strClause = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            v_strInfo = v_strClause.Split("|")
            v_strAFACCTNO = v_strInfo(0)
            v_strACCTTYPE = v_strInfo(1)



            Dim v_arrInquiryPara() As ReportParameters
            Dim v_objInquiryParam As ReportParameters

            'Doc du liệu tìm kiếm
            v_obj = New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_objRptParam As ReportParameters
            Dim v_arrRptPara() As ReportParameters
            ReDim v_arrRptPara(1)
            '0. table
            v_objRptParam = New ReportParameters
            v_objRptParam.ParamName = "AFACCTNO"
            v_objRptParam.ParamValue = v_strAFACCTNO
            v_objRptParam.ParamSize = 20
            v_objRptParam.ParamType = "NUMBER"
            v_arrRptPara(0) = v_objRptParam
            '1. In Date
            v_objRptParam = New ReportParameters
            v_objRptParam.ParamName = "INDATE"
            v_objRptParam.ParamValue = "01/01/2000"
            v_objRptParam.ParamSize = 100
            v_objRptParam.ParamType = "VARCHAR2"
            v_arrRptPara(1) = v_objRptParam
            v_ds = v_obj.ExecuteStoredReturnDataset("GETACCOUNTINFO", v_arrRptPara)
            'Buld XML data
            BuildXMLObjData(v_ds, pv_strObjMsg)
            Return ERR_SYSTEM_OK
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function GetAFtypes(ByRef pv_strObjMsg As String) As Long
        Try
            Dim XMLDocument As New XmlDocumentEx
            Dim v_strSQL As String
            Dim v_strValue, v_strDisplay, v_strHashValue As String
            Dim h_arrGrpAFtypes() As Hashtable
            Dim v_intNumGrp, v_intNumAftype As Integer

            XMLDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
            Dim v_strTellerId As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Dim v_strClause As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)

            v_strTellerId = Trim(v_strTellerId)
            Dim v_arrGroupCareby(), v_arrGroup(), v_strGroupId As String
            If Trim(v_strClause) <> String.Empty Then
                v_arrGroupCareby = v_strClause.Split("#")
            End If

            If v_arrGroupCareby.Length > 1 Then
                v_intNumGrp = v_arrGroupCareby.Length - 1
                For i As Integer = 0 To v_arrGroupCareby.Length - 2
                    v_arrGroup = v_arrGroupCareby(i).Split("|")
                    v_strGroupId = v_arrGroup(0)
                    v_strSQL = "SELECT M.ACTYPE VALUE, M.TYPENAME DISPLAY FROM AFTYPE M, TLGRPAFTYPE N " _
                            & "WHERE N.GRPID = '" & v_strGroupId & "' AND M.ACTYPE = N.AFTYPE AND M.APPROVECD = 'A' AND M.STATUS = 'Y' ORDER BY M.ACTYPE "
                    Dim v_dsGrpAftype As DataSet
                    Dim v_objGrpAftype As New DataAccess
                    v_objGrpAftype.NewDBInstance(gc_MODULE_HOST)
                    v_dsGrpAftype = v_objGrpAftype.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

                    ReDim Preserve h_arrGrpAFtypes(v_arrGroupCareby.Length - 2)
                    Dim h_GrpAFtype As New Hashtable

                    If v_dsGrpAftype.Tables(0).Rows.Count > 0 Then
                        For j As Integer = 0 To v_dsGrpAftype.Tables(0).Rows.Count - 1
                            v_strValue = IIf(v_dsGrpAftype.Tables(0).Rows(j)("VALUE") Is DBNull.Value, "", v_dsGrpAftype.Tables(0).Rows(j)("VALUE"))
                            v_strDisplay = IIf(v_dsGrpAftype.Tables(0).Rows(j)("DISPLAY") Is DBNull.Value, "", v_dsGrpAftype.Tables(0).Rows(j)("DISPLAY"))
                            'Add to hash table
                            v_strHashValue = v_strValue & "|" & v_strValue & "|" & v_strValue & "|" & v_strDisplay
                            h_GrpAFtype.Add(v_strValue, v_strHashValue)
                        Next
                    End If
                    h_arrGrpAFtypes(i) = h_GrpAFtype
                Next
            End If

            'Get all AFtypes
            v_strSQL = "SELECT ACTYPE VALUE, TYPENAME DISPLAY FROM AFTYPE WHERE STATUS = 'Y' AND APPROVECD = 'A' "
            Dim v_dsAFtypes As DataSet
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            v_dsAFtypes = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            Dim v_arrAFtypes() As String
            Dim h_AFtypes As New Hashtable
            If v_dsAFtypes.Tables(0).Rows.Count > 0 Then
                v_intNumAftype = v_dsAFtypes.Tables(0).Rows.Count
                ReDim v_arrAFtypes(v_intNumAftype - 1)
                For i As Integer = 0 To v_intNumAftype - 1
                    v_arrAFtypes(i) = IIf(v_dsAFtypes.Tables(0).Rows(i)("VALUE") Is DBNull.Value, "", v_dsAFtypes.Tables(0).Rows(i)("VALUE"))
                    v_strValue = IIf(v_dsAFtypes.Tables(0).Rows(i)("VALUE") Is DBNull.Value, "", v_dsAFtypes.Tables(0).Rows(i)("VALUE"))
                    v_strDisplay = IIf(v_dsAFtypes.Tables(0).Rows(i)("DISPLAY") Is DBNull.Value, "", v_dsAFtypes.Tables(0).Rows(i)("DISPLAY"))
                    'Add to hash table
                    v_strHashValue = v_strValue & "|" & v_strValue & "|" & v_strValue & "|" & v_strDisplay
                    h_AFtypes.Add(v_strValue, v_strHashValue)
                Next
            End If

            'Create dataset that contain aftypes
            Dim v_dsAFs As New DataSet
            Dim v_boolean As Boolean
            v_dsAFs.Tables.Add()
            v_dsAFs.Tables(0).Columns.Add("VALUE")
            v_dsAFs.Tables(0).Columns.Add("DISPLAY")
            v_dsAFs.Tables(0).Columns.Add("EN_DISPLAY")
            v_dsAFs.Tables(0).Columns.Add("DESCRIPTION")

            'Get the last aftypes
            Dim v_arrAFs() As String
            For i As Integer = 0 To v_intNumAftype - 1
                If v_strTellerId <> ADMIN_ID Then
                    If v_intNumGrp > 0 Then
                        For j As Integer = 0 To v_intNumGrp - 1
                            If Not h_arrGrpAFtypes(j)(v_arrAFtypes(i)) Is Nothing Then
                                v_arrAFs = CStr(h_arrGrpAFtypes(j)(v_arrAFtypes(i))).Split("|")
                                v_boolean = True
                                For k As Integer = 0 To v_dsAFs.Tables(0).Rows.Count - 1
                                    If v_arrAFs(0) = CStr(v_dsAFs.Tables(0).Rows(k)(0)) Then
                                        v_boolean = False
                                        Exit For
                                    End If
                                Next
                                If v_boolean = True Then
                                    v_dsAFs.Tables(0).Rows.Add(v_arrAFs)
                                End If

                            End If
                        Next
                    End If
                Else
                    If Not h_AFtypes(v_arrAFtypes(i)) Is Nothing Then
                        v_arrAFs = CStr(h_AFtypes(v_arrAFtypes(i))).Split("|")
                        v_dsAFs.Tables(0).Rows.Add(v_arrAFs)
                    End If
                End If
            Next

            'Buld XML data
            BuildXMLObjData(v_dsAFs, pv_strObjMsg)

            Return ERR_SYSTEM_OK
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Function ExternalUpdateAFMAST(ByRef pv_strObjMsg As String) As Long
        Try
            Dim XMLDocument As New XmlDocumentEx
            Dim v_strSQL As String
            Dim v_ds As DataSet, v_strBankAcctNo, v_strBankCode As String
            Dim v_lngErrCode As Long = ERR_SYSTEM_OK

            XMLDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
            Dim v_strClause As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Dim v_strBusDate As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXDATE), Xml.XmlAttribute).Value)

            Dim v_strACCTNO As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Dim v_strAPPLYACCTNO As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_objParam As New StoreParameter
            Dim v_arrPara(2) As StoreParameter
            v_objParam = New StoreParameter
            v_objParam.ParamName = "pv_err_code"
            v_objParam.ParamValue = "0"
            v_objParam.ParamDirection = ParameterDirection.Output
            v_objParam.ParamSize = 10
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(0) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "pv_acctno"
            v_objParam.ParamValue = v_strACCTNO
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamSize = 10
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(1) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "pv_applyacctno"
            v_objParam.ParamValue = v_strAPPLYACCTNO
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamSize = 10
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(2) = v_objParam

            v_lngErrCode = v_obj.ExecuteOracleStored("pr_ExternalUpdateAFMAST", v_arrPara, 0)
            v_strSQL = String.Empty
            Return v_lngErrCode
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function CheckBankAcctAuthorize(ByRef pv_strObjMsg As String) As Long
        Try
            Dim XMLDocument As New XmlDocumentEx
            Dim v_strSQL, v_strRef As String, v_arrRef() As String
            Dim v_ds As DataSet, v_strCUSTID, v_strBankAcctNo, v_strBankCode, v_strCUSTODYCD, v_strIDCODE, v_strStatus As String
            Dim v_lngErrCode As Long = ERR_SYSTEM_OK

            XMLDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
            Dim v_strClause As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Dim v_strBusDate As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXDATE), Xml.XmlAttribute).Value)



            'Sửa cập nhật số tài khoản lưu ký
            v_strCUSTID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            v_strRef = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)
            If v_strRef.Length > 0 Then
                v_arrRef = v_strRef.Split("|".ToCharArray())
                v_strCUSTODYCD = v_arrRef(0).Trim().ToUpper()
                v_strBankAcctNo = v_arrRef(1).Trim().ToUpper()
                v_strBankCode = v_arrRef(2).Trim().ToUpper()
            End If
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)

            Dim v_strValidateBankAcct As String
            v_obj.GetSysVar("CF", "BANKACCTVALIDATE", v_strValidateBankAcct)
            If v_strValidateBankAcct = "Y" Then
                v_strSQL = "SELECT IDCODE FROM CFMAST WHERE CUSTID='" & v_strCUSTID.Trim & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                v_strIDCODE = v_ds.Tables(0).Rows(0)("IDCODE").ToString()

                Dim v_objRM As New RM.Trans()
                v_lngErrCode = v_objRM.CorebankCheckAcct(v_strBankCode, v_strBankAcctNo, v_strCUSTODYCD, v_strIDCODE)

                '------------------------------------------------------------
                Dim v_strCFStatus As String = "N"
                If v_lngErrCode <> ERR_SYSTEM_OK Then
                    v_strCFStatus = "N"
                Else
                    v_strCFStatus = "Y"
                End If

                '1. Check xem so tai khoan nay da co trong bang CFBANKSTATUS chưa 

                v_strSQL = "Select count(*) custodycd from CFBANKSTATUS where custodycd ='" & v_strCUSTODYCD & "'"
                v_ds.Tables.Clear()
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

                If v_ds.Tables(0).Rows(0)("custodycd") > 0 Then
                    v_strSQL = "update CFBANKSTATUS set BANKSTS ='" + v_strCFStatus + "' , QDATE =(Select sysdate from dual ) where custodycd ='" + v_strCUSTODYCD + "'"
                Else
                    v_strSQL = "INSERT INTO CFBANKSTATUS (CUSTODYCD,BANKCODE,BANKACCTNO,BANKSTS,QDATE) " _
                    & " VALUES('" + v_strCUSTODYCD + "','" + v_strBankCode + "','" + v_strBankAcctNo + "','" + v_strCFStatus + "',(Select sysdate from dual ))"
                End If

                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                v_ds.Tables.Clear()
                '------------------------------------------------------------

                If v_lngErrCode <> ERR_SYSTEM_OK Then
                    Return v_lngErrCode
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function AFMAST_Delete(ByVal v_strMessage As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CF.AFMAST.CheckBeforeDelete", v_strErrorMessage As String
        Dim v_lngErrorCode As Long = ERR_SYSTEM_OK
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_strSQL, v_strSQLMEMO As String
        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strACCTNO, v_strCUSTODYCD, v_strCUSTID, v_strCLAUSE As String
            Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String

            Dim v_strBRID, v_strTXDATE As String
            v_strBRID = CStr(CType(v_attrColl.GetNamedItem("BRID"), Xml.XmlAttribute).Value)

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

            If Not (v_attrColl.GetNamedItem(gc_AtributeCLAUSE) Is Nothing) Then
                v_strCLAUSE = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Else
                v_strCLAUSE = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeRESERVER) Is Nothing) Then
                v_strACCTNO = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeRESERVER), Xml.XmlAttribute).Value)
            Else
                v_strACCTNO = String.Empty
            End If

            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If
            'longnh 2014-11-06 lay han muc vay
            Dim v_strSQL1 As String
            Dim v_ds1 As DataSet
            v_strSQL1 = "select * from AFMAST where acctno = '" & v_strACCTNO & "'"
            v_ds1 = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL1)
            'Kiem tra trang thai cua khach hang
            'Khong cho xoa tk khach hang co trang thai khac Cho Duyet             
            v_strSQL = "select af.status from afmast af where af.acctno = '" & v_strACCTNO & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows(0)("STATUS") <> "P" Then
                Return ERR_CF_AFMAST_STATUS_INVALID
            End If


            'Khong cho xoa tk khach hang co trang thai Cho Duyet ma chua duyet lan nao (nghia la chua sinh CIMAST)
            'v_strSQL = "SELECT COUNT(1) FROM " & ATTR_TABLE & " WHERE " & v_strCLAUSE & " AND status = 'P' AND instr(pstatus,'A') <= 0"
            v_strSQL = "select count(1) from afmast af, ddmast ci where af.acctno = ci.afacctno and ci." & v_strCLAUSE & " AND af.status = 'P'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows(0)(0) > 0 Then
                Return ERR_CF_AFMAST_STATUS_INVALID
            End If


            v_strSQL = "DELETE FROM AFMAST WHERE 0 = 0 AND " & v_strCLAUSE
            v_strSQLMEMO = "DELETE FROM AFMASTMEMO WHERE 0 = 0 AND " & v_strCLAUSE

            v_lngErrorCode = RunApprExecSql(pv_xmlDocument, gc_ActionDeletE, v_strSQL, CommandType.Text, v_strSQLMEMO)
            If v_lngErrorCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrorCode
                Exit Function
            End If

            Dim result As Long
            result = Me.MaintainLog(pv_xmlDocument, gc_ActionDeletE)
            If Not (result = ERR_APPROVE_REQUIRED Or result = ERR_SYSTEM_OK) Then
                Return result
            End If

            'longnh 2014-11-07 THU HOI HAN MUC KHI XOA TIEU KHOAN
            Dim v_strTellerId As String
            If Not (v_attrColl.GetNamedItem(gc_AtributeAUTOID) Is Nothing) Then
                v_strTellerId = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Else
                v_strTellerId = String.Empty
            End If

            ''cap nhat lai han muc MR,DP cho user
            'v_strSQL = "DELETE FROM USERAFLIMIT WHERE 0=0 AND ACCTNO = '" & v_strACCTNO & "' AND TLIDUSER = '" & v_strTellerId & "' and TYPEALLOCATE = 'Flex' "
            'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)



            'v_strSQL = "INSERT INTO USERAFLIMITLOG(TXDATE,TXNUM,ACCTNO,ACCLIMIT,TLIDUSER,TYPEALLOCATE,TYPERECEIVE) " _
            '        & "VALUES(to_date('" & v_strTXDATE & "','DD/MM/RRRR'),'" & v_ds1.Tables(0).Rows(0)("ACCTNO") & "','" & v_ds.Tables(0).Rows(0)("ACCTNO") & "'," & -1 * v_ds.Tables(0).Rows(0)("MRCRLIMITMAX") & ", " _
            '        & "'" & v_strTellerId & "','Flex','DP')"
            'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            'v_strSQL = "INSERT INTO USERAFLIMITLOG(TXDATE,TXNUM,ACCTNO,ACCLIMIT,TLIDUSER,TYPEALLOCATE,TYPERECEIVE) " _
            '        & "VALUES(to_date('" & v_strTXDATE & "','DD/MM/RRRR'),'" & v_ds1.Tables(0).Rows(0)("ACCTNO") & "','" & v_ds.Tables(0).Rows(0)("ACCTNO") & "'," & -1 * v_ds.Tables(0).Rows(0)("DPCRLIMITMAX") & ", " _
            '        & "'" & v_strTellerId & "','Flex','DP')"
            'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
    'Overrides Function ProcessAfterAdd(ByVal v_strMessage As String) As Long
    '    'LONGNH
    '    Dim v_lngErrorCode As Long
    '    Dim v_strSYSVAR, v_strSQLTmp As String, v_DataAccess As New DataAccess
    '    Try

    '        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
    '        'Check HOST Active
    '        v_DataAccess.NewDBInstance(gc_MODULE_HOST)
    '        v_lngErrorCode = v_DataAccess.GetSysVar("SYSTEM", "HOSTATUS", v_strSYSVAR)
    '        If v_lngErrorCode <> ERR_SYSTEM_OK Then
    '            Rollback() 'ContextUtil.SetAbort()
    '            Return v_lngErrorCode
    '        End If
    '        If v_strSYSVAR <> OPERATION_ACTIVE Then
    '            Rollback() 'ContextUtil.SetAbort()
    '            Return ERR_SA_HOST_OPERATION_ISINACTIVE
    '        End If

    '        'Verify memo table
    '        v_lngErrorCode = VerifyMemoTable()
    '        If v_lngErrorCode <> ERR_SYSTEM_OK Then
    '            Rollback()
    '            Return v_lngErrorCode
    '        End If

    '        Dim v_strSystemProcessMsg As String = pv_xmlDocument.InnerXml
    '        v_lngErrorCode = CheckBeforeEdit(v_strSystemProcessMsg)
    '        If v_lngErrorCode <> ERR_SYSTEM_OK Then
    '            Rollback() 'ContextUtil.SetAbort()
    '            Return v_lngErrorCode
    '            Exit Function
    '        End If
    '        v_lngErrorCode = SystemProcessBeforeEdit(v_strSystemProcessMsg)

    '        If v_lngErrorCode <> ERR_SYSTEM_OK Then
    '            Return v_lngErrorCode
    '        End If

    '        pv_xmlDocument.LoadXml(v_strSystemProcessMsg)

    '        Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
    '        Dim v_strClause As String
    '        Dim v_strLocal, v_strSQL As String
    '        Dim v_ds As DataSet


    '        'longnh 

    '        If Not (v_attrColl.GetNamedItem(gc_AtributeCLAUSE) Is Nothing) Then
    '            v_strClause = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
    '        Else
    '            v_strClause = String.Empty
    '        End If

    '        Dim v_strTellerId As String
    '        If Not (v_attrColl.GetNamedItem(gc_AtributeAUTOID) Is Nothing) Then
    '            v_strTellerId = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
    '        Else
    '            v_strTellerId = String.Empty
    '        End If

    '        Dim v_strTXDATE, a, b As String
    '        If Not (v_attrColl.GetNamedItem(gc_AtributeTXDATE) Is Nothing) Then
    '            v_strTXDATE = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXDATE), Xml.XmlAttribute).Value)
    '        Else
    '            v_strTXDATE = String.Empty
    '        End If

    '        If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
    '            v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
    '        Else
    '            v_strLocal = String.Empty
    '        End If
    '        Dim v_obj As DataAccess
    '        If v_strLocal = "Y" Then
    '            v_obj = New DataAccess
    '        ElseIf v_strLocal = "N" Then
    '            v_obj = New DataAccess
    '            v_obj.NewDBInstance(gc_MODULE_HOST)
    '        End If

    '        'khi add moi tieu khoan da tu add vao USERAFLIMIT
    '        'cap nhat han muc MR
    '        v_strSQL = "select * from AFMAST where " & v_strClause & ""
    '        v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
    '        Dim v_ds2 As DataSet


    '        v_strSQL = "INSERT INTO USERAFLIMIT(ACCTNO,ACCLIMIT,TLIDUSER,TYPEALLOCATE,TYPERECEIVE) " _
    '                        & "VALUES('" & v_ds.Tables(0).Rows(0)("ACCTNO") & "'," & v_ds.Tables(0).Rows(0)("MRCRLIMITMAX") & ", " _
    '                        & " '0001','Flex','MR')"
    '        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)




    '        'cap nhat han muc DP



    '        v_strSQL = "INSERT INTO USERAFLIMIT(ACCTNO,ACCLIMIT,TLIDUSER,TYPEALLOCATE,TYPERECEIVE) " _
    '                & "VALUES('" & v_ds.Tables(0).Rows(0)("ACCTNO") & "'," & v_ds.Tables(0).Rows(0)("DPCRLIMITMAX") & ", " _
    '                & " '0001','Flex','DP')"
    '        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)






    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    'End Function

#End Region

End Class
