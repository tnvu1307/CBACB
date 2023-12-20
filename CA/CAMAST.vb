Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Public Class CAMAST
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "CAMAST"
    End Sub

    Overrides Function Adhoc(ByRef v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        '?�ược sử dụng để tạo CASCHD cho các lần thực hiện quy?n
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource, v_strErrorMessage As String
        v_strErrorSource = "CAMAST.Adhoc"
        v_strErrorMessage = String.Empty
        Try
            Dim v_strSQL As String, v_ds As DataSet, v_dscf As DataSet, v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)

            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strCAMASTID, v_strCODEID, v_strEXCODEID, v_strCATYPE, v_strREPORTDATE, v_strACTIONDATE, v_strDUEDATE, v_strSTATUS As String
            'Reference l�à mã của đợt thực hiện quy?n
            If Not (v_attrColl.GetNamedItem(gc_AtributeOBJNAME) Is Nothing) Then
                v_strCAMASTID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)
            Else
                v_strCAMASTID = String.Empty
            End If

            'Tr�ả v? data �để hiển thị lên Grid dưới Client
            v_strSQL = "SELECT CAMAST.AUTOID,CF.FULLNAME,CAMAST.CAMASTID,A0.SYMBOL CODEID,SUBSTR(AFACCTNO,1,4) || '.' || SUBSTR(AFACCTNO,5,6) AFACCTNO,(case  when CAMAST.CATYPE ='014' THEN  PBALANCE ELSE  BALANCE END ) BALANCE," & ControlChars.CrLf _
          & " (case  when CAMAST.CATYPE ='014' THEN  PQTTY ELSE  QTTY END ) QTTY   ,AMT,AQTTY,(case  when CAMAST.CATYPE ='014' THEN  PAAMT ELSE  AAMT END ) AAMT,A1.CDCONTENT STATUS, CF.CUSTODYCD FROM CASCHD, CAMAST ,SBSECURITIES A0,ALLCODE A1, AFMAST AF, CFMAST CF  " & ControlChars.CrLf _
          & "WHERE CAMAST.CAMASTID='" & Trim(v_strCAMASTID) & "' AND  CAMAST.CAMASTID = CASCHD.CAMASTID  " & ControlChars.CrLf _
          & "AND A0.CODEID=CASCHD.CODEID AND CASCHD.AFACCTNO = AF.ACCTNO AND AF.CUSTID = CF.CUSTID " & ControlChars.CrLf _
          & "AND A1.CDTYPE='CA' AND A1.CDNAME='CASTATUS' AND A1.CDVAL = CASCHD.STATUS AND CASCHD.DELTD<>'Y'" & ControlChars.CrLf _
          & "UNION ALL" & ControlChars.CrLf _
          & " SELECT max(0) AUTOID,max(to_nchar(' ')) FULLNAME,max(CASCHD.CAMASTID),A0.SYMBOL CODEID,max(to_char(' ')) AFACCTNO,SUM(case  when CAMAST.CATYPE ='014' THEN  PBALANCE ELSE  BALANCE END)BALANCE,SUM(case  when CAMAST.CATYPE ='014' THEN  PQTTY ELSE  QTTY END ) QTTY ,SUM(AMT),SUM(AQTTY),SUM(case  when CAMAST.CATYPE ='014' THEN  PAAMT ELSE  AAMT END ) AAMT,max(to_nchar(' ')) STATUS, max(to_char(' ')) CUSTODYCD FROM CASCHD, CAMAST,AFMAST AF ,CFMAST CF ,SBSECURITIES A0,ALLCODE A1 " & ControlChars.CrLf _
          & "WHERE CASCHD.CAMASTID='" & Trim(v_strCAMASTID) & "' " & ControlChars.CrLf _
          & "AND A0.CODEID=CASCHD.CODEID AND CASCHD.AFACCTNO = AF.ACCTNO AND AF.CUSTID = CF.CUSTID  " & ControlChars.CrLf _
          & "AND CAMAST.CAMASTID=CASCHD.CAMASTID " & ControlChars.CrLf _
          & "AND A1.CDTYPE='CA' AND A1.CDNAME='CASTATUS' AND A1.CDVAL = CASCHD.STATUS AND CASCHD.DELTD<>'Y'" & ControlChars.CrLf _
          & "GROUP BY A0.SYMBOL"

            Dim v_strObjMsg As String = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CA_CAMAST, gc_ActionInquiry, v_strSQL, )
            v_strMessage = v_strObjMsg
            v_lngErrCode = Inquiry(v_strMessage)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                'Thông báo lỗi không có đợt thực hiện quy?n
                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                             & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                             & "Error message: CAMASTID." & v_strCAMASTID, "EventLogEntryType.Error")
                Return v_lngErrCode
            End If
            'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

#Region " Overrides functions "

    Overrides Function CheckBeforeAdd(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_strObjMsg, v_strCurrentBdsid As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList
        'Nga them vao bien v_strACTIONDATERETAIL de kiem tra ACTIONDATERETAIL
        Dim v_strACTIONDATERETAIL As String
        Dim v_strFRTRADEPLACE As String
        Dim v_dblDEVIDENTRATE, v_dblDEVIDENTVALUE As Double
        Dim v_dblSPLITRATE As Double
        Dim v_strOptSymbol, v_strOptIsincode As String
        Dim v_strTODATETRANSFER, v_strDueDate As String

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strCODEID, v_strCATYPE, v_strREPORTDATE As String
            Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String
            Dim v_strSQL As String
            Dim v_strDATE As Date
            Dim v_strACTIONDATE, v_strTRADEDATE, v_strISWFT As String
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
            v_dblDEVIDENTRATE = 0
            v_dblDEVIDENTVALUE = 0
            'L��ấy thông tin v? CODEID 
            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strVALUE = .InnerText.ToString()
                    Select Case Trim(v_strFLDNAME)
                        Case "CODEID"
                            v_strCODEID = Trim(v_strVALUE)
                        Case "CATYPE"
                            v_strCATYPE = Trim(v_strVALUE)
                        Case "REPORTDATE"
                            v_strREPORTDATE = Trim(v_strVALUE)
                        Case "ACTIONDATE"
                            v_strACTIONDATE = Trim(v_strVALUE)
                            'Nga moi them vao de kiem tra truong hop ACTIONDATERETAIL
                        Case "ACTIONDATERETAIL"
                            v_strACTIONDATERETAIL = Trim(v_strVALUE)
                        Case "FRTRADEPLACE"
                            v_strFRTRADEPLACE = Trim(v_strVALUE)
                        Case "TRADEDATE"
                            v_strTRADEDATE = Trim(v_strVALUE)
                        Case "ISWFT"
                            v_strISWFT = Trim(v_strVALUE)
                        Case "DEVIDENTRATE"
                            If Trim(v_strVALUE <> "") Then
                                v_dblDEVIDENTRATE = Double.Parse(v_strVALUE)
                            End If
                        Case "DEVIDENTVALUE"
                            If Trim(v_strVALUE <> "") Then
                                v_dblDEVIDENTVALUE = Double.Parse(v_strVALUE)

                            End If
                        Case "SPLITRATE"
                            If InStr(1, Trim(v_strVALUE), "/") <> 0 And Trim(v_strVALUE <> "") Then
                                v_dblSPLITRATE = Double.Parse(v_strVALUE.Substring(0, v_strVALUE.IndexOf("/"))) / Double.Parse(v_strVALUE.Substring(v_strVALUE.IndexOf("/")) + 1)
                            Else
                                If Trim(v_strVALUE <> "") Then
                                    v_dblSPLITRATE = Double.Parse(v_strVALUE)
                                End If
                            End If
                        Case "OPTSYMBOL"
                            v_strOptSymbol = Trim(v_strVALUE)
                        Case "OPTISINCODE"
                            v_strOptIsincode = Trim(v_strVALUE)
                        Case "TODATETRANSFER"
                            v_strTODATETRANSFER = Trim(v_strVALUE)
                        Case "DUEDATE"
                            v_strDueDate = Trim(v_strVALUE)
                    End Select
                End With
            Next
            'Ki�ểm tra xem có được thêm mới đợt thực hiện quy?n hay kh�ông
            If v_strCurrentBdsid <> String.Empty Then
                'v_strSQL = "SELECT COUNT(CAMASTID) FROM CAMAST WHERE CODEID ='" & v_strCODEID & "' " & ControlChars.CrLf _
                '& "AND STATUS IN ('N','A','S','P','I','C') AND DELTD ='N' AND CATYPE ='" & v_strCATYPE & "' AND " & " REPORTDATE =TO_DATE('" & v_strREPORTDATE & "','" & gc_FORMAT_DATE & "')"
                'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                'If v_ds.Tables(0).Rows.Count = 1 Then
                '    If v_ds.Tables(0).Rows(0)(0) > 0 Then
                '        Return ERR_CA_CAMASTID_DUPLICATE
                '    End If
                'End If
                'Kiem tra voi gc_CA_CATYPE_PRINCIPLE_BOND chi cho phep lam voi trai phieu
                Dim v_strSECTYPE As String
                If gc_CA_CATYPE_PRINCIPLE_BONd = v_strCATYPE Then
                    v_strSQL = "SELECT sectype FROM sbsecurities WHERE codeid = '" & v_strCODEID & "'"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count > 0 Then
                        v_strSECTYPE = v_ds.Tables(0).Rows(0)(0)
                        If v_strSECTYPE <> gc_SECURITIES_SECTYPE_BONd And v_strSECTYPE <> gc_SECURITIES_SECTYPE_CONVERTIBLEBONd Then
                            Return ERR_CA_CODEID_CANNOT_EXECUTE
                        End If
                    Else
                        Return ERR_SE_CODEID_NOTFOUND
                    End If
                End If
            End If
            'Check xem isincode cua chung khoan quyen co ton tai hay chua?
            If v_strCurrentBdsid <> String.Empty Then
                Dim v_strIsin As String
                If v_strCATYPE = "014" Then
                    v_strSQL = "select count(*) CHK_ISIN from sbsecurities where isincode like '" & v_strOptIsincode & "'"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count > 0 Then
                        v_strIsin = v_ds.Tables(0).Rows(0)(0)
                        If Convert.ToInt32(Trim(v_strIsin)) <> 0 Then
                            Return ERR_CA_ISINCODE_INVALID
                        End If
                    End If
                End If
            End If
            'Kiem tra ngay Action date phai la ngay lam viec cua he thong
            If v_strCurrentBdsid <> String.Empty Then
                'Nga moi them vao de kiem tra ngay Action date retail co phai la ngay lam viec cua he thong hay ko?
                If (v_strACTIONDATERETAIL <> String.Empty) Then
                    v_strSQL = "SELECT COUNT(HOLIDAY) FROM SBCLDR WHERE SBDATE = TO_DATE('" & v_strACTIONDATERETAIL & "','" & gc_FORMAT_DATE & "') AND HOLIDAY ='Y' "
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count >= 1 Then
                        If v_ds.Tables(0).Rows(0)(0) > 0 Then
                            Return ERR_ACTIONDATERETAIL_IS_BUSDATE
                        End If
                    End If
                End If
                'Ket thuc phan Nga them
                'v_strSQL = "SELECT COUNT(HOLIDAY) FROM SBCLDR WHERE SBDATE = TO_DATE('" & v_strACTIONDATE & "','" & gc_FORMAT_DATE & "') AND HOLIDAY ='Y' "
                'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                'If v_ds.Tables(0).Rows.Count >= 1 Then
                '    If v_ds.Tables(0).Rows(0)(0) > 0 Then
                '        Return ERR_ACTIONDATE_IS_BUSDATE
                '    End If
                'End If

            End If

            '' neu nhap ngay actiondate thi pai check no voi cac ngay khac
            'If (v_strACTIONDATE.Length > 0) Then
            '    ' check reportdate va action date
            '    If (DDMMYYYY_SystemDate(v_strACTIONDATE) <= DDMMYYYY_SystemDate(v_strREPORTDATE)) Then
            '        Return ERR_CA_REPORTDATE_MUSTBE_SMALLER_THAN_ACTIONDATE
            '    End If

            '    ' neu la quyen mua: check voi TODATETRANSFER va DUEDATE
            '    If (v_strCATYPE = "014") Then
            '        If (DDMMYYYY_SystemDate(v_strACTIONDATE) < DDMMYYYY_SystemDate(v_strTODATETRANSFER)) Then
            '            Return ERR_CA_TODATETRANSFER_CANT_GREATER_THAN_ACTIONDATE
            '        End If

            '        If (DDMMYYYY_SystemDate(v_strACTIONDATE) < DDMMYYYY_SystemDate(v_strDueDate)) Then
            '            Return ERR_CA_DUEDATE_CANT_GREATER_THAN_ACTIONDATE
            '        End If
            '    End If


            'End If

            If v_strISWFT = "Y" And ((gc_CA_CATYPE_STOCK_DIVIDENd = v_strCATYPE) Or (gc_CA_WAITING_FOR_TRADE = v_strCATYPE) Or (gc_CA_CATYPE_STOCK_RIGHTOFF = v_strCATYPE) Or (gc_CA_CATYPE_KIND_STOCK = v_strCATYPE)) Then

                ' ngay giao dich tro lai khong duoc la ngay nghi 
                v_strSQL = "SELECT COUNT(HOLIDAY) FROM SBCLDR WHERE SBDATE = TO_DATE('" & v_strTRADEDATE & "','" & gc_FORMAT_DATE & "') AND HOLIDAY ='Y' "
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count >= 1 Then
                    If v_ds.Tables(0).Rows(0)(0) > 0 Then
                        Return ERR_TRADEDATE_IS_BUSDATE
                    End If
                End If
                'ngay giao dich tro lai phai lon hon ngay hien tai
                'khong check vi ngay giao dich tro lai duoc khai bao trong giao dich 3390
                'v_strSQL = "select count(*)  from  sysvar where varname ='CURRDATE' and to_date ( varvalue,'DD/MM/YYYY') >= TO_DATE('" & v_strTRADEDATE & "','" & gc_FORMAT_DATE & "')"
                'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                'If v_ds.Tables(0).Rows.Count >= 1 Then
                '    If v_ds.Tables(0).Rows(0)(0) > 0 Then
                '        Return ERR_TRADEDATE_CURRDATE
                '    End If
                'End If

            End If

            'co tuc bang tien: check chi chọn mot cach khai bao ty le
            If (v_dblDEVIDENTRATE * v_dblDEVIDENTVALUE <> 0) Then
                Return ERR_CA_CHOOSE_DOUBLE_DEVIDENT_TYPE

            End If

            If (v_strCATYPE = "010") Then
                If v_dblDEVIDENTRATE + v_dblDEVIDENTVALUE = 0 Then
                    Return ERR_CA_MUST_CHOOSE_ONE_DEVIDENT_TYPE
                End If
            End If
            ' tach gop co phieu check ti le tach <1, gop >1
            If (v_strCATYPE = "012" And v_dblSPLITRATE > 1) Then
                Return ERR_CA_INVALID_SPLITRATE
            End If
            If (v_strCATYPE = "013" And v_dblSPLITRATE < 1) Then
                Return ERR_CA_INVALID_SPLITRATE_2
            End If
            ' chia co tuc bang quyen mua: check option symbol khong duoc trung 
            If (v_strCATYPE = "014" Or v_strCATYPE = "023") Then
                v_strSQL = "SELECT * FROM SBSECURITIES WHERE SYMBOL = '" & v_strOptSymbol & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count >= 1 Then
                    Return ERR_SA_OPT_SYMBOL_DUPLICATED
                End If
            End If
            'Chuyen doi trai phieu thanh co phieu: chung khoan pai co sectype='003'
            'If (v_strCATYPE = "017") Then
            '    v_strSQL = "SELECT * FROM SBSECURITIES WHERE SECTYPE<>'003' AND SYMBOL = '" & v_strOptSymbol & "'"
            '    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            '    If v_ds.Tables(0).Rows.Count >= 1 Then
            '        Return ERR_CA_CODEID_INVALID
            '    End If

            'End If
            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If
            Return 0
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Overrides Function CheckBeforeEdit(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_strObjMsg, v_strCurrentBdsid As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strOptSymbol As String
        Dim v_strTODATETRANSFER, v_strDueDate As String
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strCODEID, v_strSTATUS, v_strCATYPE, v_strDELTD, v_strCAMASTID As String
            Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String
            Dim v_strSQL, v_strClause As String
            Dim v_strACTIONDATE, v_strREPORTDATE, v_strTRADEDATE, v_strISWFT As String
            Dim v_dblDEVIDENTRATE, v_dblDEVIDENTVALUE As Double
            Dim v_dblSPLITRATE As Double
            'Nga them vao bien v_strACTIONDATERETAIL de kiem tra ACTIONDATERETAIL
            Dim v_strACTIONDATERETAIL
            If Not (v_attrColl.GetNamedItem(gc_AtributeCLAUSE) Is Nothing) Then
                v_strClause = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Else
                v_strClause = String.Empty
            End If
            If Not (v_attrColl.GetNamedItem(gc_AtributeBRID) Is Nothing) Then
                v_strCurrentBdsid = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeBRID), Xml.XmlAttribute).Value)
            Else
                v_strCurrentBdsid = String.Empty
            End If
            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If

            'Kiểm tra xem trạng thái của đợt thực hiện thực hiện quy?n c�ó th?a m�ãn không?
            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If
            v_strSQL = "SELECT CAMASTID,STATUS  FROM " & ATTR_TABLE & " " _
                     & "WHERE 0=0 AND " & v_strClause
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count >= 1 Then
                v_strCAMASTID = v_ds.Tables(0).Rows(0)("CAMASTID")
                v_strSTATUS = v_ds.Tables(0).Rows(0)("STATUS")
            End If
            If v_strSTATUS <> "N" And v_strSTATUS <> "P" And v_strSTATUS <> "E" Then  'Chỉ được edit nếu có trạng thái là New
                Return ERR_CA_CAMASTID_ALREADY_SEND_OR_COMPLETE
            Else
                v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                    With v_nodeList.Item(0).ChildNodes(i)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strVALUE = .InnerText.ToString()
                        Select Case Trim(v_strFLDNAME)
                            Case "CODEID"
                                v_strCODEID = Trim(v_strVALUE)
                            Case "CATYPE"
                                v_strCATYPE = Trim(v_strVALUE)
                            Case "REPORTDATE"
                                v_strREPORTDATE = Trim(v_strVALUE)
                            Case "ACTIONDATE"
                                v_strACTIONDATE = Trim(v_strVALUE)
                                'Nga moi them vao de kiem tra truong hop ACTIONDATERETAIL
                            Case "ACTIONDATERETAIL"
                                v_strACTIONDATERETAIL = Trim(v_strVALUE)
                            Case "DEVIDENTRATE"
                                If Trim(v_strVALUE <> "") Then
                                    v_dblDEVIDENTRATE = Double.Parse(v_strVALUE)
                                End If
                            Case "DEVIDENTVALUE"
                                If Trim(v_strVALUE <> "") Then
                                    v_dblDEVIDENTVALUE = Double.Parse(v_strVALUE)

                                End If

                            Case "SPLITRATE"
                                If InStr(1, Trim(v_strVALUE), "/") <> 0 And Trim(v_strVALUE <> "") Then
                                    v_dblSPLITRATE = Double.Parse(v_strVALUE.Substring(0, v_strVALUE.IndexOf("/"))) / Double.Parse(v_strVALUE.Substring(v_strVALUE.IndexOf("/")) + 1)
                                Else
                                    If Trim(v_strVALUE <> "") Then
                                        v_dblSPLITRATE = Double.Parse(v_strVALUE)
                                    End If
                                End If
                            Case "OPTSYMBOL"
                                v_strOptSymbol = Trim(v_strVALUE)
                            Case "TODATETRANSFER"
                                v_strTODATETRANSFER = Trim(v_strVALUE)
                            Case "DUEDATE"
                                v_strDueDate = Trim(v_strVALUE)
                        End Select
                    End With
                Next
                'If v_strCurrentBdsid <> String.Empty Then 'Không edit được vì đã có đợt thực hiện quy?n n�ày 
                '    v_strSQL = "SELECT COUNT(CAMASTID) FROM CAMAST WHERE CODEID ='" & v_strCODEID & "' " & ControlChars.CrLf _
                '    & "AND STATUS IN ('A','S') AND DELTD ='N' AND CATYPE ='" & v_strCATYPE & "' AND " & " REPORTDATE =TO_DATE('" & v_strREPORTDATE & "','" & gc_FORMAT_DATE & "')"
                '    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                '    If v_ds.Tables(0).Rows.Count = 1 Then
                '        If v_ds.Tables(0).Rows(0)(0) > 0 Then
                '            Return ERR_CA_CAMASTID_DUPLICATE
                '        End If
                '    End If
                'End If
                'Kiem tra ngay Action date phai la ngay lam viec cua he thong
                If v_strCurrentBdsid <> String.Empty Then
                    'Nga moi them vao de kiem tra ngay Action date retail co phai la ngay lam viec cua he thong hay ko?
                    If (v_strACTIONDATERETAIL <> String.Empty) Then
                        v_strSQL = "SELECT COUNT(HOLIDAY) FROM SBCLDR WHERE SBDATE = TO_DATE('" & v_strACTIONDATERETAIL & "','" & gc_FORMAT_DATE & "') AND HOLIDAY ='Y' "
                        v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                        If v_ds.Tables(0).Rows.Count >= 1 Then
                            If v_ds.Tables(0).Rows(0)(0) > 0 Then
                                Return ERR_ACTIONDATERETAIL_IS_BUSDATE
                            End If
                        End If
                    End If
                    'Ket thuc phan Nga them
                    'v_strSQL = "SELECT COUNT(HOLIDAY) FROM SBCLDR WHERE SBDATE = TO_DATE('" & v_strACTIONDATE & "','" & gc_FORMAT_DATE & "') AND HOLIDAY ='Y' "
                    'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    'If v_ds.Tables(0).Rows.Count >= 1 Then
                    '    If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    '        Return ERR_ACTIONDATE_IS_BUSDATE
                    '    End If
                    'End If
                    'If (v_strACTIONDATE.Length > 0) Then
                    '    ' check reportdate va action date
                    '    If (DDMMYYYY_SystemDate(v_strACTIONDATE) <= DDMMYYYY_SystemDate(v_strREPORTDATE)) Then
                    '        Return ERR_CA_REPORTDATE_MUSTBE_SMALLER_THAN_ACTIONDATE
                    '    End If

                    '    ' neu la quyen mua: check voi TODATETRANSFER va DUEDATE
                    '    If (v_strCATYPE = "014") Then
                    '        If (DDMMYYYY_SystemDate(v_strACTIONDATE) < DDMMYYYY_SystemDate(v_strTODATETRANSFER)) Then
                    '            Return ERR_CA_TODATETRANSFER_CANT_GREATER_THAN_ACTIONDATE
                    '        End If

                    '        If (DDMMYYYY_SystemDate(v_strACTIONDATE) < DDMMYYYY_SystemDate(v_strDueDate)) Then
                    '            Return ERR_CA_DUEDATE_CANT_GREATER_THAN_ACTIONDATE
                    '        End If
                    '    End If


                    'End If

                    If v_strISWFT = "Y" And ((gc_CA_WAITING_FOR_TRADE = v_strCATYPE) Or (gc_CA_CATYPE_STOCK_DIVIDENd = v_strCATYPE) Or (gc_CA_CATYPE_STOCK_RIGHTOFF = v_strCATYPE) Or (gc_CA_CATYPE_KIND_STOCK = v_strCATYPE)) Then

                        ' ngay giao dich tro lai khong duoc la ngay nghi 
                        v_strSQL = "SELECT COUNT(HOLIDAY) FROM SBCLDR WHERE SBDATE = TO_DATE('" & v_strTRADEDATE & "','" & gc_FORMAT_DATE & "') AND HOLIDAY ='Y' "
                        v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                        If v_ds.Tables(0).Rows.Count >= 1 Then
                            If v_ds.Tables(0).Rows(0)(0) > 0 Then
                                Return ERR_TRADEDATE_IS_BUSDATE
                            End If
                        End If
                        'ngay giao dich tro lai phai lon hon ngay hien tai
                        'bo check vi ngay giao dich tro lai thuc hien trong giao dich 3390
                        'v_strSQL = "select count(*)  from  sysvar where varname ='CURRDATE' and to_date ( varvalue,'DD/MM/YYYY') >= TO_DATE('" & v_strTRADEDATE & "','" & gc_FORMAT_DATE & "')"
                        'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                        'If v_ds.Tables(0).Rows.Count >= 1 Then
                        '    If v_ds.Tables(0).Rows(0)(0) > 0 Then
                        '        Return ERR_TRADEDATE_CURRDATE
                        '    End If
                        'End If

                    End If

                End If

                'co tuc bang tien: check chi chọn mot cach khai bao ty le
                If (v_dblDEVIDENTRATE * v_dblDEVIDENTVALUE <> 0) Then
                    Return ERR_CA_CHOOSE_DOUBLE_DEVIDENT_TYPE

                End If

                If (v_strCATYPE = "010") Then
                    If v_dblDEVIDENTRATE + v_dblDEVIDENTVALUE = 0 Then
                        Return ERR_CA_MUST_CHOOSE_ONE_DEVIDENT_TYPE
                    End If
                End If
                ' tach gop co phieu check ti le tach <1, gop >1
                If (v_strCATYPE = "012" And v_dblSPLITRATE > 1) Then
                    Return ERR_CA_INVALID_SPLITRATE
                End If
                If (v_strCATYPE = "013" And v_dblSPLITRATE < 1) Then
                    Return ERR_CA_INVALID_SPLITRATE_2
                End If
                ' chia co tuc bang quyen mua: check option symbol khong duoc trung 
                If (v_strCATYPE = "014" Or v_strCATYPE = "023") Then
                    v_strSQL = "SELECT * FROM SBSECURITIES SB, CAMAST CA WHERE SB.SYMBOL=CA.OPTSYMBOL AND SB.SYMBOL = '" & v_strOptSymbol & "' AND CA.CAMASTID <> '" & v_strCAMASTID & "'"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count >= 1 Then
                        Return ERR_SA_SYMBOL_DUPLICATED
                    End If
                End If

            End If
            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If
            Return 0
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
    Overrides Function CheckBeforeDelete(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strClause, v_strCurrentBdsid, v_strTLID As String
            Dim v_strLocal, v_strFLDNAME, v_strVALUE As String
            Dim v_strSQL, v_strCAMASTID, v_strSTATUS, v_strApprvid As String

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

            If Not (v_attrColl.GetNamedItem(gc_AtributeTLID) Is Nothing) Then
                v_strTLID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Else
                v_strTLID = String.Empty
            End If

            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            v_strSQL = "SELECT STATUS,nvl(apprvid,'-0000') apprvid FROM " & ATTR_TABLE & " " _
                     & "WHERE 0=0 AND " & v_strClause
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count >= 1 Then
                v_strSTATUS = v_ds.Tables(0).Rows(0)("STATUS")
                v_strApprvid = v_ds.Tables(0).Rows(0)("APPRVID")
            End If
            If v_strCurrentBdsid <> String.Empty Then
                'Không cho phép xoá đợt thực hiện quy?n �đã lưu trong lịch thực hiện
                If v_strSTATUS <> "N" And v_strSTATUS <> "P" And v_strSTATUS <> "E" And v_strSTATUS <> "R" Then
                    Return ERR_CA_CAMASTID_INVALIDSTATUS
                End If
            End If
            ' su kien da duyet thi chi cho nguoi duyet xoa
            If (v_strSTATUS = "N" And v_strApprvid <> v_strTLID And v_strApprvid <> "-0000") Then
                Return ERR_CA_ONLY_APPRVID_CAN_DEL
            End If
            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If
            Return 0
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

#End Region

End Class
