Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Public Class ODMAST
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "ODMAST"
    End Sub

#Region " Implement functions"
    Overrides Function Adhoc(ByRef v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strFuncName As String

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            v_strFuncName = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeFUNCNAME), Xml.XmlAttribute).Value)

            Select Case Trim(v_strFuncName)
                Case "InsertData4GrpOrder"
                    v_lngErrCode = InsertData4GrpOrder(pv_xmlDocument)
                    If v_lngErrCode <> ERR_SYSTEM_OK Then
                        Return v_lngErrCode
                    End If

                Case "ExecuteOD9996"
                    v_lngErrCode = ExecuteOD9996(pv_xmlDocument)
                    If v_lngErrCode <> ERR_SYSTEM_OK Then
                        Return v_lngErrCode
                    End If
                Case "InsertData4LogODPT_REPO"
                    v_lngErrCode = InsertData4LogODPT_REPO(pv_xmlDocument)
                    If v_lngErrCode <> ERR_SYSTEM_OK Then
                        Return v_lngErrCode
                    End If
                Case "UpdateStatusLogODPT_REPO"
                    v_lngErrCode = UpdateStatusLogODPT_REPO(pv_xmlDocument)
                    If v_lngErrCode <> ERR_SYSTEM_OK Then
                        Return v_lngErrCode
                    End If

            End Select

            v_strMessage = pv_xmlDocument.InnerXml
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
#End Region

#Region " Private functions"
    Private Function UpdateStatusLogODPT_REPO(ByRef pv_xmlDocument As XmlDocumentEx) As Long
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strFileCode As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)
            Dim v_strRef, v_strORDERID, v_strTXDATE, v_strTXNUM, v_strORDERID2 As String
            Dim v_lngErrCode As Long = ERR_SYSTEM_OK
            Dim v_strErrorSource As String = "OD.Trans.UpdateStatusLogODPT_REPO", v_strErrorMessage As String
            Dim v_strFeedBackMsg As String
            Dim v_strREF_ORDERID2 As String = String.Empty
            Dim v_arrREF As String()

            If Not (v_attrColl.GetNamedItem(gc_AtributeREFERENCE) Is Nothing) Then
                v_strRef = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)
            Else
                v_strRef = String.Empty
            End If

            v_arrREF = v_strRef.Split("|")
            v_strORDERID = v_arrREF(0)
            v_strORDERID2 = v_arrREF(1)
            v_strREF_ORDERID2 = v_arrREF(2)


            Dim v_strSQL As String = String.Empty
            Dim v_ds As DataSet
            Dim v_obj As New DataAccess

            v_obj.NewDBInstance(gc_MODULE_HOST)
            v_strSQL = " UPDATE  TBL_ODREPO SET  STATUS ='A', ORDERID2 ='" & v_strORDERID2 & "', REF_ORDERID2 = '" & v_strREF_ORDERID2 & "'   WHERE ORDERID = '" & v_strORDERID & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            Return v_lngErrCode

        Catch ex As Exception
            LogError.WriteException(ex)
            Return ERR_SA_IMPORT_FILE_INVALID 'File du lieu dau vao khong hop le
            Throw ex
        End Try
    End Function
    Private Function InsertData4LogODPT_REPO(ByRef pv_xmlDocument As XmlDocumentEx) As Long
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strFileCode As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)
            Dim v_strRef, v_strORDERID, v_strTXDATE, v_strTXNUM, v_strREF_ORDERID As String
            Dim v_strAFACCTNO, v_strCODEID, v_strQUOTEPRICE, v_strORDERQTTY, v_strPRICE2, v_strEXECTYPE, v_strEXPTDATE, v_strREF_CUSTODYCD, v_strREF_AFACCTNO As String
            Dim v_lngErrCode As Long = ERR_SYSTEM_OK
            Dim v_strErrorSource As String = "OD.Trans.InsertData4LogODPT_REPO", v_strErrorMessage As String
            Dim v_strFeedBackMsg As String
            Dim v_arrREF As String()

            If Not (v_attrColl.GetNamedItem(gc_AtributeREFERENCE) Is Nothing) Then
                v_strRef = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)
            Else
                v_strRef = String.Empty
            End If

            v_arrREF = v_strRef.Split("|")
            ''TXDATE,TXNUM, AFACCTNO,ORDERID, CODEID, QUOTEPRICE, ORDERQTTY,PRICE2,EXPTDATE,EXECTYPE,REF_CUSTODYCD
            v_strTXDATE = v_arrREF(0)
            v_strTXNUM = v_arrREF(1)
            v_strAFACCTNO = v_arrREF(2)
            v_strORDERID = v_arrREF(3)
            v_strCODEID = v_arrREF(4)
            v_strQUOTEPRICE = v_arrREF(5)
            v_strORDERQTTY = v_arrREF(6)
            v_strORDERQTTY = CDbl(v_strORDERQTTY)
            v_strPRICE2 = v_arrREF(7)
            v_strEXPTDATE = v_arrREF(8)
            v_strEXECTYPE = v_arrREF(9)
            v_strREF_CUSTODYCD = v_arrREF(10)
            v_strREF_AFACCTNO = v_arrREF(11)
            v_strREF_ORDERID = v_arrREF(12)

            Dim v_strSQL As String = String.Empty
            Dim v_ds As DataSet
            Dim v_obj As New DataAccess

            v_obj.NewDBInstance(gc_MODULE_HOST)

            v_strSQL = " SELECT ORDERID FROM TBL_ODREPO WHERE ORDERID = '" & v_strORDERID & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_lngErrCode = ERR_SYSTEM_OK
                Return v_lngErrCode
            Else
                ''INSERT VAO BANG LOG
                v_strSQL = "INSERT INTO TBL_ODREPO(TXDATE,TXNUM,CUSTODYCD,ORDERID, CODEID, QUOTEPRICE, ORDERQTTY,PRICE2,EXPTDATE,EXECTYPE,DELTD,STATUS,ORDERID2,REF_CUSTODYCD,REF_AFACCTNO,REF_ORDERID) " &
                           " VALUES ( TO_DATE('" & v_strTXDATE & "','DD/MM/YYYY'),'" & v_strTXNUM & "','" & v_strAFACCTNO & "','" &
                           v_strORDERID & "','" & v_strCODEID & "'," & v_strQUOTEPRICE & "," & v_strORDERQTTY & "," &
                           v_strPRICE2 & ", TO_DATE('" & v_strEXPTDATE & "','DD/MM/YYYY'),'" & v_strEXECTYPE & "','N','N','','" & v_strREF_CUSTODYCD & "','" & v_strREF_AFACCTNO & "','" & v_strREF_ORDERID & "')"

                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            End If

            Return v_lngErrCode

        Catch ex As Exception
            LogError.WriteException(ex)
            Return ERR_SA_IMPORT_FILE_INVALID 'File du lieu dau vao khong hop le
            Throw ex
        End Try

    End Function
    Private Function InsertData4GrpOrder(ByRef pv_xmlDocument As XmlDocumentEx) As Long

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strFileCode As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)
            Dim v_strClause, strORDERID, v_strTMP As String
            Dim v_strLocal As String
            Dim v_strAutoId As String
            Dim v_intCount As Integer = 0
            Dim v_lngErrCode As Long = ERR_SYSTEM_OK
            Dim v_strErrorSource As String = "OD.Trans.InsertData4GrpOrder", v_strErrorMessage As String
            Dim v_strFeedBackMsg As String
            Dim v_strTellerID As String
            Dim mDelimiterRows As Char = "|"
            Dim mDelimiterItems As Char = "~"

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

            If Not (v_attrColl.GetNamedItem(gc_AtributeTLID) Is Nothing) Then
                v_strTellerID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Else
                v_strTellerID = String.Empty
            End If

            Dim XMLDocument As New XmlDocumentEx, XMLOrder As New XmlDocumentEx
            Dim v_nodeData As Xml.XmlNode
            Dim v_strORDERID, v_strREFID, v_strTYPE, v_Type, v_strORDERIDTmp As String
            Dim v_dblQTTY, v_dblORDNUM, v_dblQttyTmp, v_dblQttySAVE As Double

            'Xu ly neu la lenh thuong
            XMLDocument.LoadXml(pv_xmlDocument.InnerXml)
            'Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
            v_strClause = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value) 'Noi dung lenh dat vao
            XMLOrder.LoadXml(v_strClause)
            Dim v_blnOK As Boolean = False

            Dim v_nodeList As Xml.XmlNodeList
            v_nodeList = XMLOrder.SelectNodes("RootTrade/objBODY/Order")
            'v_nodeData = XMLOrder.SelectSingleNode("RootTrade/objBODY/Order")
            'ODMAPEXT (ORDERID,REFID,QTTY,ORDERNUM,TYPE)
            Dim v_strSQL As String = String.Empty
            Dim v_strDEBIT As String = String.Empty
            Dim v_strDEBITtmp As String
            Dim v_ds As DataSet
            Dim v_obj As New DataAccess

            v_obj.NewDBInstance(gc_MODULE_HOST)


            For k As Integer = 0 To v_nodeList.Count - 1
                v_strTYPE = ""
                v_strREFID = ""
                v_dblQTTY = 0

                For i As Integer = 0 To v_nodeList.Item(k).ChildNodes.Count - 1
                    Select Case v_nodeList.Item(k).ChildNodes(i).Name
                        Case "TYPE"
                            v_strTYPE = v_nodeList.Item(k).ChildNodes(i).InnerXml
                        Case "REFID"
                            v_strREFID = v_nodeList.Item(k).ChildNodes(i).InnerXml
                        Case "QTTY"
                            v_dblQttyTmp = v_nodeList.Item(k).ChildNodes(i).InnerXml
                            v_dblQTTY = v_nodeList.Item(k).ChildNodes(i).InnerXml
                    End Select
                Next

                If InStr("M", v_strTYPE) Then

                    v_strTMP = "SELECT * FROM ODMAPEXT WHERE ORDERID = '" & v_strREFID & "' ORDER BY QTTY DESC"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strTMP)
                    If Not v_ds.Tables(0).Rows.Count > 0 Then
                        v_lngErrCode = ERR_OD_ODTYPE_NOTFOUND
                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                     & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                     & "Error message: InsertData4GrpOrder", "EventLogEntryType.Error")
                        Return v_lngErrCode
                    End If


                    For j As Integer = 0 To v_ds.Tables(0).Rows.Count - 1
                        v_strDEBITtmp = ""
                        If v_dblQttyTmp <> 0 Then
                            v_strSQL = v_strSQL & " INSERT INTO ODMAPEXT (ORDERID,REFID,QTTY,ORDERNUM,TYPE) VALUES ( "
                            For i As Integer = 0 To v_nodeList.Item(k).ChildNodes.Count - 1

                                Select Case v_nodeList.Item(k).ChildNodes(i).Name
                                    Case "ORDERID"
                                        v_strSQL = v_strSQL & "'" & v_nodeList.Item(k).ChildNodes(i).InnerXml & "',"
                                    Case "REFID"
                                        v_strORDERIDTmp = v_nodeList.Item(k).ChildNodes(i).InnerXml
                                        v_strREFID = gf_CorrectStringField(v_ds.Tables(0).Rows(j)("REFID"))
                                        v_strSQL = v_strSQL & "'" & v_strREFID & "',"
                                    Case "QTTY"
                                        If IsNumeric(v_nodeList.Item(k).ChildNodes(i).InnerXml) Then

                                            If v_dblQttyTmp > gf_CorrectNumericField(v_ds.Tables(0).Rows(j)("QTTY")) - gf_CorrectNumericField(v_ds.Tables(0).Rows(j)("EXECQTTY")) Then
                                                v_strSQL = v_strSQL & gf_CorrectNumericField(v_ds.Tables(0).Rows(j)("QTTY")) - gf_CorrectNumericField(v_ds.Tables(0).Rows(j)("EXECQTTY")) & ","
                                                v_dblQttyTmp = v_dblQttyTmp - (gf_CorrectNumericField(v_ds.Tables(0).Rows(j)("QTTY")) - gf_CorrectNumericField(v_ds.Tables(0).Rows(j)("EXECQTTY")))
                                                v_dblQttySAVE = gf_CorrectNumericField(v_ds.Tables(0).Rows(j)("QTTY")) - gf_CorrectNumericField(v_ds.Tables(0).Rows(j)("EXECQTTY"))
                                            Else
                                                v_strSQL = v_strSQL & v_dblQttyTmp & ","
                                                v_dblQttySAVE = v_dblQttyTmp
                                                v_dblQttyTmp = 0
                                            End If
                                        Else
                                            v_strSQL = v_strSQL & "0" & ","
                                            v_dblQttySAVE = 0
                                        End If
                                    Case "ORDERNUM"
                                        If IsNumeric(v_nodeList.Item(k).ChildNodes(i).InnerXml) Then
                                            v_strSQL = v_strSQL & CDbl(v_nodeList.Item(k).ChildNodes(i).InnerXml) & ","
                                        Else
                                            v_dblORDNUM = 0
                                        End If
                                    Case "TYPE"
                                        v_strTYPE = v_nodeList.Item(k).ChildNodes(i).InnerXml
                                        v_strSQL = v_strSQL & "'" & v_nodeList.Item(k).ChildNodes(i).InnerXml & "',"
                                End Select

                            Next

                            v_strDEBITtmp = "UPDATE ODMAST SET REMAINQTTY = REMAINQTTY - REMAINQTTY, CANCELQTTY = CANCELQTTY + REMAINQTTY, ORSTATUS = 5 WHERE ORDERID= '" & v_strORDERIDTmp & "'; "

                            If InStr("O", v_strTYPE) > 0 Then
                                'v_strDEBIT = v_strDEBIT & " UPDATE SEMAST SET TRADE=TRADE-" & v_dblQTTY & ", GRPORDAMT=GRPORDAMT+" & v_dblQTTY & " WHERE ACCTNO in (SELECT SEACCTNO FROM ODMAST WHERE ORDERID='" & v_strREFID & "');"
                                v_strDEBITtmp = v_strDEBITtmp & " UPDATE SEMAST SET TRADE=TRADE-" & v_dblQttySAVE & ", GRPORDAMT=GRPORDAMT+" & v_dblQttySAVE & " WHERE ACCTNO ='" & v_strREFID & "';"
                            ElseIf InStr("M", v_strTYPE) > 0 Then
                                'v_strDEBIT = v_strDEBIT & " UPDATE DFMAST SET DFQTTY=DFQTTY-" & v_dblQTTY & ", GRPORDAMT=GRPORDAMT+" & v_dblQTTY & " WHERE ACCTNO IN (SELECT REFID FROM ODMAPEXT WHERE ORDERID='" & v_strREFID & "');"
                                v_strDEBITtmp = v_strDEBITtmp & " UPDATE DFMAST SET DFQTTY=DFQTTY-" & v_dblQttySAVE & ", GRPORDAMT=GRPORDAMT+" & v_dblQttySAVE & " WHERE ACCTNO = '" & v_strREFID & "';"
                                v_strDEBITtmp = v_strDEBITtmp & " UPDATE SEMAST SET MORTAGE = MORTAGE - " & v_dblQttySAVE & " WHERE ACCTNO in (SELECT AFACCTNO||CODEID FROM DFMAST WHERE ACCTNO='" & v_strREFID & "');"
                            End If

                            v_strSQL = Strings.Left(v_strSQL, v_strSQL.Length - 1) & "); " & v_strDEBITtmp
                        End If
                    Next

                Else
                    v_strSQL = v_strSQL & " INSERT INTO ODMAPEXT (ORDERID,REFID,QTTY,ORDERNUM,TYPE) VALUES ( "
                    For i As Integer = 0 To v_nodeList.Item(k).ChildNodes.Count - 1
                        Select Case v_nodeList.Item(k).ChildNodes(i).Name
                            Case "ORDERID"
                                v_strSQL = v_strSQL & "'" & v_nodeList.Item(k).ChildNodes(i).InnerXml & "',"
                            Case "REFID"
                                v_strREFID = v_nodeList.Item(k).ChildNodes(i).InnerXml
                                v_strSQL = v_strSQL & "'" & v_nodeList.Item(k).ChildNodes(i).InnerXml & "',"
                            Case "QTTY"
                                If IsNumeric(v_nodeList.Item(k).ChildNodes(i).InnerXml) Then
                                    v_dblQTTY = CDbl(v_nodeList.Item(k).ChildNodes(i).InnerXml)
                                    v_strSQL = v_strSQL & CDbl(v_nodeList.Item(k).ChildNodes(i).InnerXml) & ","
                                Else
                                    v_strSQL = v_strSQL & "0" & ","
                                End If
                            Case "ORDERNUM"
                                If IsNumeric(v_nodeList.Item(k).ChildNodes(i).InnerXml) Then
                                    v_strSQL = v_strSQL & CDbl(v_nodeList.Item(k).ChildNodes(i).InnerXml) & ","
                                Else
                                    v_dblORDNUM = 0
                                End If
                            Case "TYPE"
                                v_strTYPE = v_nodeList.Item(k).ChildNodes(i).InnerXml
                                v_strSQL = v_strSQL & "'" & v_nodeList.Item(k).ChildNodes(i).InnerXml & "',"
                        End Select
                    Next

                    If InStr("S", v_strTYPE) > 0 Then
                        v_strDEBIT = " UPDATE SEMAST SET TRADE=TRADE-" & v_dblQTTY & ", GRPORDAMT=GRPORDAMT+" & v_dblQTTY & " WHERE ACCTNO='" & v_strREFID & "';"
                    ElseIf InStr("O", v_strTYPE) > 0 Then
                        v_strDEBIT = " UPDATE SEMAST SET TRADE=TRADE-" & v_dblQTTY & ", GRPORDAMT=GRPORDAMT+" & v_dblQTTY & " WHERE ACCTNO in (SELECT SEACCTNO FROM ODMAST WHERE ORDERID='" & v_strREFID & "');"
                        v_strDEBIT = v_strDEBIT & " UPDATE ODMAST SET REMAINQTTY = REMAINQTTY - REMAINQTTY, CANCELQTTY = CANCELQTTY + REMAINQTTY, ORSTATUS = 5 WHERE ORDERID= '" & v_strREFID & "'; "
                    ElseIf InStr("D", v_strTYPE) > 0 Then
                        v_strDEBIT = " UPDATE DFMAST SET DFQTTY=DFQTTY-" & v_dblQTTY & ", GRPORDAMT=GRPORDAMT+" & v_dblQTTY & " WHERE ACCTNO='" & v_strREFID & "'; "
                        v_strDEBIT = v_strDEBIT & "UPDATE SEMAST SET MORTAGE = MORTAGE - " & v_dblQTTY & " WHERE ACCTNO IN (SELECT AFACCTNO||CODEID FROM DFMAST WHERE ACCTNO='" & v_strREFID & "'); "
                    End If

                    v_strSQL = Strings.Left(v_strSQL, v_strSQL.Length - 1) & "); " & v_strDEBIT

                End If



                ' S: Chung khoan giao dich
                ' D: Chung khoan cam co
                ' O: Chung khoan giao dich CHUA KHOP
                ' M: Chung khoan cam co CHUA KHOP

                'If InStr("S", v_strTYPE) > 0 Then
                '    v_strDEBIT = " UPDATE SEMAST SET TRADE=TRADE-" & v_dblQTTY & ", GRPORDAMT=GRPORDAMT+" & v_dblQTTY & " WHERE ACCTNO='" & v_strREFID & "';"
                'ElseIf InStr("D", v_strTYPE) > 0 Then
                '    v_strDEBIT = " UPDATE DFMAST SET DFQTTY=DFQTTY-" & v_dblQTTY & ", GRPORDAMT=GRPORDAMT+" & v_dblQTTY & " WHERE ACCTNO='" & v_strREFID & "'; "
                '    v_strDEBIT = v_strDEBIT & "UPDATE SEMAST SET MORTAGE = MORTAGE - " & v_dblQTTY & " WHERE ACCTNO IN (SELECT AFACCTNO||CODEID FROM DFMAST WHERE ACCTNO='" & v_strREFID & "'); "
                'ElseIf InStr("O/M", v_strTYPE) > 0 And Not v_ds.Tables(0).Rows.Count > 0 Then
                '    ' Cap nhap ODMAST tru di REMAIND va + CANCELQTTY khi su dung lenh ban chua khop
                '    v_strDEBIT = "UPDATE ODMAST SET REMAINQTTY = REMAINQTTY - REMAINQTTY, CANCELQTTY = CANCELQTTY + REMAINQTTY WHERE ORDERID= '" & v_strREFID & "'; "

                '    If InStr("O", v_strTYPE) > 0 Then
                '        v_strDEBIT = v_strDEBIT & " UPDATE SEMAST SET TRADE=TRADE-" & v_dblQTTY & ", GRPORDAMT=GRPORDAMT+" & v_dblQTTY & " WHERE ACCTNO in (SELECT SEACCTNO FROM ODMAST WHERE ORDERID='" & v_strREFID & "');"
                '    ElseIf InStr("M", v_strTYPE) > 0 Then
                '        v_strDEBIT = v_strDEBIT & " UPDATE DFMAST SET DFQTTY=DFQTTY-" & v_dblQTTY & ", GRPORDAMT=GRPORDAMT+" & v_dblQTTY & " WHERE ACCTNO IN (SELECT REFID FROM ODMAPEXT WHERE ORDERID='" & v_strREFID & "');"
                '        v_strDEBIT = v_strDEBIT & " UPDATE SEMAST SET MORTAGE = MORTAGE - " & v_dblQTTY & " WHERE ACCTNO in (SELECT SEACCTNO FROM ODMAST WHERE ORDERID='" & v_strREFID & "');"
                '    End If
                'End If


            Next

            If v_strSQL <> String.Empty Then
                v_strSQL = "BEGIN " & v_strSQL & " END; "
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                v_strSQL = String.Empty
            End If

            'Dim v_arrClause() As String
            'v_arrClause = v_strClause.Split(mDelimiterRows)
            'Dim v_TitleClause As String = v_arrClause(0)
            'Dim v_arrTitleClause() As String
            'Dim v_arrTypeClause() As String
            ''Dim v_arrSumAmount() As Double
            'v_arrTitleClause = v_TitleClause.Split(mDelimiterItems)
            'ReDim v_arrTypeClause(v_arrTitleClause.GetLength(0))
            ''ReDim v_arrSumAmount(v_arrTitleClause.GetLength(0))
            ''For ik As Integer = 0 To v_arrTitleClause.GetLength(0) - 1
            ''    v_arrSumAmount(ik) = 0
            ''Next
            ''Inquiry data
            'Dim v_obj As DataAccess
            'If v_strLocal = "Y" Then
            '    v_obj = New DataAccess
            'ElseIf v_strLocal = "N" Then
            '    v_obj = New DataAccess
            '    v_obj.NewDBInstance(gc_MODULE_HOST)
            'End If
            ''Insert vao db
            'Dim v_ds As New DataSet
            'Dim v_sql As String
            'Dim v_strBeginInsertClause As String
            'v_strBeginInsertClause = "INSERT INTO ODMAPEXT (ORDERID,REFID,QTTY,ORDERNUM,TYPE) "

            'v_arrTypeClause(0) = "C"
            'v_arrTypeClause(1) = "C"
            'v_arrTypeClause(2) = "N"
            'v_arrTypeClause(3) = "N"
            'v_arrTypeClause(4) = "C"


            'Dim v_strEndInsertClause, v_strInsertClause As String
            'Dim v_strSQL, v_strDebit As String
            'Dim v_blnDebit As Boolean = False
            'Dim v_strValueClause As String
            'Dim v_strArrValue() As String

            ' ''Clean old data
            ''v_sql = "TRUNCATE TABLE " & v_strTablename
            ''v_obj.ExecuteNonQuery(CommandType.Text, v_sql)

            'For i As Integer = 1 To v_arrClause.GetLength(0) - 2
            '    v_strEndInsertClause = " VALUES ("
            '    v_strValueClause = v_arrClause(i)
            '    v_strArrValue = v_strValueClause.Split(mDelimiterItems)

            '    For j As Integer = 0 To v_strArrValue.GetLength(0) - 2
            '        Select Case v_arrTypeClause(j)
            '            Case "C"
            '                v_strEndInsertClause = v_strEndInsertClause & "'" & gf_CorrectStringField(v_strArrValue(j)) & "',"
            '            Case "N"
            '                If (v_strArrValue(j).ToString = "") Then
            '                    v_strEndInsertClause = v_strEndInsertClause & "0" & ","
            '                Else
            '                    v_strEndInsertClause = v_strEndInsertClause & gf_CorrectNumericField(v_strArrValue(j)) & ","

            '                    ''Giam trong SEMAST va DFMAST doi voi chung khoan giao dich va cam co
            '                    'If v_blnDebit = False Then
            '                    '    If 
            '                    '        v_strDebit = "UPDATE "
            '                    '    End If

            '                    'End If
            '                End If

            '            Case "D"
            '                v_strEndInsertClause = v_strEndInsertClause & "TO_DATE('" & gf_CorrectStringField(v_strArrValue(j)) & "','" & gc_FORMAT_DATE & "')" & ","
            '        End Select
            '        v_blnDebit = True
            '    Next
            '    v_strEndInsertClause = Strings.Left(v_strEndInsertClause, v_strEndInsertClause.Length - 1) & "); "
            '    v_strInsertClause = v_strBeginInsertClause & v_strEndInsertClause & vbCrLf

            '    v_strSQL = v_strSQL & v_strInsertClause

            '    If i Mod gc_EXECUTE_ROWS = 0 Then
            '        v_strSQL = "BEGIN " & v_strSQL & " END; "
            '        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            '        v_strSQL = String.Empty
            '    End If

            'Next

            'If v_strSQL <> String.Empty Then
            '    v_strSQL = "BEGIN " & v_strSQL & " END; "
            '    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            '    v_strSQL = String.Empty
            'End If

            'v_strFeedBackMsg = "Tổng số bản ghi: " & v_arrClause.GetLength(0) - 2 & ControlChars.CrLf

            'pv_xmlDocument.DocumentElement.Attributes.GetNamedItem(gc_AtributeRESERVER).Value = v_strFeedBackMsg

            'If v_lngErrCode <> ERR_SYSTEM_OK Then
            '    'Tra ve ma loi xuat ra tu function
            '    pv_xmlDocument.DocumentElement.Attributes.GetNamedItem(gc_AtributeRESERVER).Value = v_strFeedBackMsg
            'End If

            Return v_lngErrCode

        Catch ex As Exception
            LogError.WriteException(ex)
            Return ERR_SA_IMPORT_FILE_INVALID 'File du lieu dau vao khong hop le
            Throw ex
        End Try


    End Function

    Private Function ExecuteOD9996(ByRef pv_xmlDocument As XmlDocumentEx) As Long

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strFileCode As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)
            Dim v_strClause, strORDERID As String
            Dim v_strLocal, v_strFeedBackMsg As String
            Dim v_intCount As Integer = 0
            Dim v_lngErrCode As Long = ERR_SYSTEM_OK
            Dim v_strErrorSource As String = "OD.Trans.ExecuteOD9996", v_strErrorMessage As String
            Dim v_strTellerID As String
            Dim mDelimiterRows As Char = "|"
            Dim mDelimiterItems As Char = "~"

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

            If Not (v_attrColl.GetNamedItem(gc_AtributeREFERENCE) Is Nothing) Then
                strORDERID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)
            Else
                strORDERID = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeTLID) Is Nothing) Then
                v_strTellerID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Else
                v_strTellerID = String.Empty
            End If

            Dim v_strSQL As String = String.Empty
            Dim v_strDEBIT As String = String.Empty
            Dim v_obj As New DataAccess

            v_obj.NewDBInstance(gc_MODULE_HOST)

            'Goi store procedure fillter neu co khai bao can fillter
            Dim v_objParam As New StoreParameter
            Dim v_arrPara(2) As StoreParameter
            v_objParam.ParamName = "p_orderid"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamValue = strORDERID
            v_objParam.ParamSize = 100
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(0) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_err_param"
            v_objParam.ParamDirection = ParameterDirection.Output
            v_objParam.ParamValue = ""
            v_objParam.ParamSize = 100
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(1) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_err_message"
            v_objParam.ParamDirection = ParameterDirection.Output
            v_objParam.ParamValue = ""
            v_objParam.ParamSize = 100
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(2) = v_objParam

            v_strFeedBackMsg = v_obj.ExecuteOracleStored("cspks_seproc.pr_ExecuteOD9996", v_arrPara, 2)

            If Not IsNumeric(v_arrPara(1).ParamValue) Then
                v_lngErrCode = 0
            Else
                v_lngErrCode = CDec(v_arrPara(1).ParamValue)
            End If


            Return v_lngErrCode

        Catch ex As Exception
            LogError.WriteException(ex)
            Return ERR_SA_IMPORT_FILE_INVALID 'File du lieu dau vao khong hop le
            Throw ex
        End Try


    End Function

#End Region
End Class
