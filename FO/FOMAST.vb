Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Text
Imports System.IO
Imports System.Data

Public Class FOMAST
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
    ATTR_TABLE = "FOMAST"
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
        Case "PlaceOrder"
          v_lngErrCode = PlaceOrder(v_strObjMsg)
        Case "AccountInquiry"
          v_lngErrCode = AccountInquiry(v_strObjMsg)
        Case "SystemParamInquiry"
          v_lngErrCode = SystemParamInquiry(v_strObjMsg)
        Case "GetOrderBookonHand"
          Dim strAFAccno As String
          strAFAccno = Convert.ToString(CType(v_attrColl.GetNamedItem(gc_AtributeAUTOID), Xml.XmlAttribute).Value)
          v_lngErrCode = GetOrderBookonHand(v_strObjMsg, strAFAccno)

      End Select
      v_strMessage = v_strObjMsg
      Return v_lngErrCode

    Catch ex As Exception
      Throw ex
    End Try
  End Function


  Private Function MoveDeal(ByRef pv_strObjMsg As String) As Long
    Dim v_obj As DataAccess, v_ds As DataSet, v_strSQL As String
    Dim v_strErrorSource As String = ATTR_TABLE & ".MoveDeal"
    Dim XMLDocument As New XmlDocumentEx, XMLOrder As New XmlDocumentEx
    Dim v_nodeData As Xml.XmlNode
    Dim v_lngErrCode As Long = ERR_SYSTEM_OK
    v_obj = New DataAccess
    v_obj.NewDBInstance(gc_MODULE_HOST)
    Dim v_strMSGBODY As String = String.Empty
    Try

      Return ERR_SYSTEM_OK
    Catch ex As Exception
      Throw ex
    Finally
      v_obj = Nothing
      XMLOrder = Nothing
      XMLDocument = Nothing
    End Try
  End Function

    Private Function PlaceOrder(ByRef pv_strObjMsg As String) As Long
        Dim v_obj As DataAccess, v_ds As DataSet, v_strSQL, v_strSYSVAR As String
        Dim v_strOrcReturn, v_strVIA, v_strCURRDATE, v_strTXDATE, v_strCOREBANK As String
        Dim v_strErrorSource As String = ATTR_TABLE & ".PlaceOrder"
        Dim XMLDocument As New XmlDocumentEx, XMLOrder As New XmlDocumentEx
        Dim v_objParam As New StoreParameter
        Dim v_nodeData, v_nodeOldData As Xml.XmlNode
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        v_obj = New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)
        Try
            v_strSYSVAR = String.Empty
            'Nếu hội sở đóng cửa thì không được đặt lệnh
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "HOSTATUS", v_strSYSVAR)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            End If
            If v_strSYSVAR <> OPERATION_ACTIVE Then
                Rollback() 'ContextUtil.SetAbort()
                Return ERR_SA_HOST_OPERATION_ISINACTIVE
            End If


            'Xu ly neu la lenh thuong
            XMLDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
            Dim v_strClause As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value) 'Noi dung lenh dat vao
            XMLOrder.LoadXml(v_strClause)
            Dim v_blnOK As Boolean = False
            Dim v_strTRADINGPWD, v_strUSERNAME, v_strORDERID, v_strACTYPE, v_strAFACCTNO, v_strSSAFACCTNO, v_strACCTNO, v_strSTATUS, v_strEXECTYPE, _
                v_strDIRECT, v_strSPLITOPTION, v_strSPLITVALUE, v_strPRICETYPE, v_strTIMETYPE, v_strMATCHTYPE, _
                v_strNORK, v_strCLEARCD, v_strDEALID, v_strCODEID, v_strSYMBOL, v_strCONFIRMEDVIA, v_strFEEDBACKMSG, v_strBOOK, v_strBUSDATE, v_strTradePlace As String
            Dim v_dblQUANTITY, v_dblPRICE, v_dblQUOTEPRICE, v_dblTRIGGERPRICE, v_dblEXECQTTY, v_dblEXECAMT, v_dblREMAINQTTY, v_dblCLEARDAY As Double
            v_strUSERNAME = ""

            If v_strUSERNAME.Trim.Length > 0 Then
                v_strVIA = "T" 'Kenh Online
            Else
                'v_strVIA = "O" 'Kenh ATD Online
                v_strVIA = "B" 'Ducnv tach thanh kenh BrokerDesk
            End If
            v_strACTYPE = String.Empty
            v_strACCTNO = String.Empty
            v_strCLEARCD = "B"
            v_strMATCHTYPE = "N"
            v_strSTATUS = "P"
            v_strCONFIRMEDVIA = "N"
            v_strNORK = "N"
            v_strNORK = "N"
            v_dblQUANTITY = 0
            v_dblPRICE = 0
            v_dblQUOTEPRICE = 0
            v_dblTRIGGERPRICE = 0
            v_dblEXECQTTY = 0
            v_dblEXECAMT = 0
            v_dblREMAINQTTY = 0
            v_dblCLEARDAY = 3
            v_strDIRECT = "N"
            v_strSPLITOPTION = "N"
            v_strSPLITVALUE = "0"

            v_nodeData = XMLOrder.SelectSingleNode("RootTrade/objBODY/Order")
            Dim v_strFUNCNAME As String = CStr(v_nodeData.Attributes("CLASS").Value)
            If v_strFUNCNAME = "MOVEDEAL" Then
                'Chuyen tiep den MOVEDEAL function
                Return MoveDeal(pv_strObjMsg)
                Exit Function
            ElseIf v_strFUNCNAME = "UPDATESECURITIESINFO" Then
                'Chuyen tiep den MOVEDEAL function
                Return UpdateSecuritiesInfor(pv_strObjMsg)
                Exit Function
            End If

            'Lay ngay hien tai
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "CURRDATE", v_strCURRDATE)
            For i As Integer = 0 To v_nodeData.ChildNodes.Count - 1
                Select Case v_nodeData.ChildNodes(i).Name
                    Case "TXDATE"
                        v_strTXDATE = v_nodeData.ChildNodes(i).InnerXml
                    Case "DIRECT"
                        v_strDIRECT = v_nodeData.ChildNodes(i).InnerXml
                    Case "SPLITOPTION"
                        v_strSPLITOPTION = v_nodeData.ChildNodes(i).InnerXml
                    Case "SPLITVALUE"
                        v_strSPLITVALUE = v_nodeData.ChildNodes(i).InnerXml
                    Case "USERNAME"
                        v_strUSERNAME = v_nodeData.ChildNodes(i).InnerXml
                    Case "TRADINGPWD"
                        v_strTRADINGPWD = v_nodeData.ChildNodes(i).InnerXml
                    Case "ACCTNO"
                        v_strACCTNO = v_nodeData.ChildNodes(i).InnerXml
                    Case "AFACCTNO"
                        v_strAFACCTNO = v_nodeData.ChildNodes(i).InnerXml
                    Case "BOOK"
                        v_strBOOK = v_nodeData.ChildNodes(i).InnerXml
                    Case "VIA"
                        v_strVIA = v_nodeData.ChildNodes(i).InnerXml
                    Case "EXECTYPE"
                        v_strEXECTYPE = v_nodeData.ChildNodes(i).InnerXml
                    Case "PRICETYPE"
                        v_strPRICETYPE = v_nodeData.ChildNodes(i).InnerXml
                    Case "TIMETYPE"
                        v_strTIMETYPE = v_nodeData.ChildNodes(i).InnerXml
                    Case "MATCHTYPE"
                        v_strMATCHTYPE = v_nodeData.ChildNodes(i).InnerXml
                    Case "CLEARCD"
                        v_strCLEARCD = v_nodeData.ChildNodes(i).InnerXml
                    Case "NORK"
                        v_strNORK = v_nodeData.ChildNodes(i).InnerXml
                    Case "CODEID"
                        v_strCODEID = v_nodeData.ChildNodes(i).InnerXml
                    Case "SYMBOL"
                        v_strSYMBOL = v_nodeData.ChildNodes(i).InnerXml
                    Case "CONFIRMEDVIA"
                        v_strCONFIRMEDVIA = v_nodeData.ChildNodes(i).InnerXml
                    Case "FEEDBACKMSG"
                        v_strFEEDBACKMSG = v_nodeData.ChildNodes(i).InnerXml
                    Case "CLEARDAY"
                        If IsNumeric(v_nodeData.ChildNodes(i).InnerXml) Then
                            v_dblCLEARDAY = CDbl(v_nodeData.ChildNodes(i).InnerXml)
                        End If
                    Case "QUANTITY"
                        If IsNumeric(v_nodeData.ChildNodes(i).InnerXml) Then
                            v_dblQUANTITY = CDbl(v_nodeData.ChildNodes(i).InnerXml)
                        Else
                            v_dblQUANTITY = 0
                        End If
                    Case "PRICE"
                        If IsNumeric(v_nodeData.ChildNodes(i).InnerXml) Then
                            v_dblPRICE = CDbl(v_nodeData.ChildNodes(i).InnerXml)
                        Else
                            v_dblPRICE = 0
                        End If
                    Case "QUOTEPRICE"
                        If IsNumeric(v_nodeData.ChildNodes(i).InnerXml) Then
                            v_dblQUOTEPRICE = CDbl(v_nodeData.ChildNodes(i).InnerXml)
                        Else
                            v_dblQUOTEPRICE = 0
                        End If
                    Case "TRIGGERPRICE"
                        If IsNumeric(v_nodeData.ChildNodes(i).InnerXml) Then
                            v_dblTRIGGERPRICE = CDbl(v_nodeData.ChildNodes(i).InnerXml)
                        Else
                            v_dblTRIGGERPRICE = 0
                        End If
                    Case "DEALID"
                        v_strDEALID = v_nodeData.ChildNodes(i).InnerXml
                    Case "SSAFACCTNO"
                        v_strSSAFACCTNO = v_nodeData.ChildNodes(i).InnerXml
                End Select
            Next
            v_dblREMAINQTTY = v_dblQUANTITY

            'Kiem tra ngay he thong
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "CURRDATE", v_strCURRDATE)
            If DDMMYYYY_SystemDate(v_strTXDATE) <> DDMMYYYY_SystemDate(v_strCURRDATE) Then
                Rollback() 'ContextUtil.SetAbort()
                Return ERR_SA_BUSDATE_BRANCHDATE_PLZLOGIN_OUT
            End If

            'Lay ra codeid theo Symbol
            v_strSQL = "SELECT CODEID, TRADEPLACE FROM SBSECURITIES WHERE SYMBOL='" & v_strSYMBOL & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_strCODEID = v_ds.Tables(0).Rows(0)("CODEID")
                v_strTradePlace = v_ds.Tables(0).Rows(0)("TRADEPLACE")
            End If

            Dim v_dsMST As DataSet
            '-------------------------------
            'Lay lai gio he thong
            v_strSQL = "SELECT TO_CHAR(SYSDATE,'HH24MISS') SYSTEMTIME FROM DUAL"
            v_dsMST = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            Dim v_strSystemTime As String = v_dsMST.Tables(0).Rows(0)("SYSTEMTIME")
            'Lay gio cho phep bat dau phien ATC
            v_strSQL = "SELECT VARVALUE ATCSTARTTIME FROM SYSVAR WHERE GRNAME='SYSTEM' AND VARNAME='ATCSTARTTIME'"
            v_dsMST = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            Dim v_strATCStartTime As String = v_dsMST.Tables(0).Rows(0)("ATCSTARTTIME")
            'Xac dinh trang thai thi truong xem la phien 1,2 or 3
            v_strSQL = "SELECT SYSVALUE  FROM ORDERSYS WHERE SYSNAME='CONTROLCODE'"
            v_dsMST = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            Dim v_strMarketStatus As String
            v_strMarketStatus = v_dsMST.Tables(0).Rows(0)("SYSVALUE")
            'v_strMarketStatus=P: 8h30-->9h00 phien 1 ATO
            'v_strMarketStatus=O: 9h00-->10h15 phien 2 MP
            'v_strMarketStatus=A: 10h15-->10h30 phien 3 ATC
            If v_strPRICETYPE <> "LO" And v_strFUNCNAME = "PLACEORDER" And v_strBOOK = "A" Then
                If v_strPRICETYPE = "ATO" Then
                    If v_strMarketStatus = "O" Or v_strMarketStatus = "A" Then
                        v_lngErrCode = ERR_SA_INVALID_SECSSION
                        Return v_lngErrCode
                    End If
                End If
                If v_strPRICETYPE = "ATC" Then
                    If v_strMarketStatus = "A" Then
                    ElseIf v_strMarketStatus = "O" And v_strSystemTime >= v_strATCStartTime Then
                    Else
                        v_lngErrCode = ERR_SA_INVALID_SECSSION
                        Return v_lngErrCode
                    End If
                End If

                If v_strPRICETYPE = "MO" Then
                    If v_strMarketStatus <> "O" Then
                        v_lngErrCode = ERR_SA_INVALID_SECSSION
                        Return v_lngErrCode
                    End If
                End If
            End If
            ' DUCNV check lenh HUY
            If v_strFUNCNAME = "CANCELORDER" And v_strTradePlace = "001" Then

                If v_strMarketStatus = "P" Then
                    v_lngErrCode = ERR_SA_INVALID_SECSSION
                    Return v_lngErrCode
                End If
                If v_strMarketStatus = "A" Then
                    v_strSQL = "SELECT orderid FROM odmast WHERE orderid = '" & v_strACCTNO & "' AND hosesession = 'A'"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count > 0 Then
                        v_lngErrCode = ERR_SA_INVALID_SECSSION
                        Return v_lngErrCode
                    End If

                End If
            End If
            ' end of ducnv check lenh huy

            '-------------------------------------
            If v_strFUNCNAME = "PLACEORDER" Then
                'v_strSQL = "SELECT AF.ACCTNO FROM AFMAST AF WHERE AF.STATUS<>'C' AND AF.ACCTNO='" & v_strAFACCTNO.Trim & "'"
                v_strSQL = "SELECT AF.ACCTNO,CI.COREBANK, AF.STATUS FROM AFMAST AF,CIMAST CI WHERE CI.AFACCTNO=AF.ACCTNO AND AF.ACCTNO='" & v_strAFACCTNO.Trim & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count = 0 Then
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: System error!" & vbNewLine _
                                 & "Error message: " & v_strSQL & "." & ControlChars.CrLf & ATTR_TABLE & "." & v_strAFACCTNO, "EventLogEntryType.Error")
                    Return ERR_SA_APPCHK_ACCTNO_NOTFOUND
                ElseIf v_ds.Tables(0).Rows(0)("STATUS").ToString.Trim <> "A" Then
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: System error!" & vbNewLine _
                                 & "Error message: " & v_strSQL & "." & ControlChars.CrLf & ATTR_TABLE & "." & v_strAFACCTNO, "EventLogEntryType.Error")
                    Return ERR_CF_AFMAST_STATUS_INVALIDE
                Else
                    v_strCOREBANK = v_ds.Tables(0).Rows(0)("COREBANK").ToString()
                End If

                'Generate OrderID
                v_lngErrCode = v_obj.GetSysVar("SYSTEM", "CURRDATE", v_strBUSDATE)
                v_strORDERID = v_strBUSDATE & Right(gc_FORMAT_BATCHTXNUM & CStr(v_obj.GetIDValue("FOMAST")), Len(gc_FORMAT_BATCHTXNUM))
                v_strFEEDBACKMSG = "MSG_CONFIRMED_ORDER_RECEIVED"
                'TungNT added , truong hop dat lenh mua hoac lenh sua mua
                If v_strCOREBANK = "Y" AndAlso "NB/BC/AB".IndexOf(v_strEXECTYPE) >= 0 Then
                    v_strSTATUS = "W"
                    v_strCOREBANK = "N"
                End If

                v_strSQL = "INSERT INTO FOMAST (ACCTNO, ORGACCTNO, ACTYPE, AFACCTNO, STATUS, EXECTYPE, PRICETYPE, TIMETYPE, MATCHTYPE, NORK, CLEARCD, CODEID, SYMBOL, " & ControlChars.CrLf _
                    & "CONFIRMEDVIA, BOOK, FEEDBACKMSG, ACTIVATEDT, CREATEDDT, CLEARDAY, QUANTITY, PRICE, QUOTEPRICE, TRIGGERPRICE, EXECQTTY, EXECAMT, REMAINQTTY, " & ControlChars.CrLf _
                    & "VIA, DIRECT, SPLOPT, SPLVAL, EFFDATE, EXPDATE, USERNAME, DFACCTNO,SSAFACCTNO)" & ControlChars.CrLf _
                    & "VALUES ('" & v_strORDERID & "','" & v_strORDERID.Trim & "','" & v_strACTYPE.Trim & "','" & v_strAFACCTNO.Trim & "','" & v_strSTATUS.Trim & "'," & ControlChars.CrLf _
                    & "'" & v_strEXECTYPE.Trim & "','" & v_strPRICETYPE.Trim & "','" & v_strTIMETYPE.Trim & "','" & v_strMATCHTYPE.Trim & "'," & ControlChars.CrLf _
                    & "'" & v_strNORK.Trim & "','" & v_strCLEARCD.Trim & "','" & v_strCODEID.Trim & "','" & v_strSYMBOL.Trim & "'," & ControlChars.CrLf _
                    & "'" & v_strCONFIRMEDVIA.Trim & "','" & v_strBOOK.Trim & "','" & v_strFEEDBACKMSG.Trim & "',TO_CHAR(SYSDATE,'DD/MM/RRRR HH24:MI:SS'),TO_CHAR(SYSDATE,'DD/MM/RRRR HH24:MI:SS')," & ControlChars.CrLf _
                    & v_dblCLEARDAY & "," & v_dblQUANTITY & "," & v_dblPRICE & "," & v_dblQUOTEPRICE & "," & v_dblTRIGGERPRICE & "," & v_dblEXECQTTY & "," & v_dblEXECAMT & "," & v_dblREMAINQTTY & "," & ControlChars.CrLf _
                    & "'" & v_strVIA & "','" & v_strDIRECT & "','" & v_strSPLITOPTION & "'," & v_strSPLITVALUE & ", TO_DATE('" & v_strCURRDATE & "','" & gc_FORMAT_DATE & "'),TO_DATE('" & v_strCURRDATE & "','" & gc_FORMAT_DATE & "'),'" & v_strUSERNAME & "','" & v_strDEALID & "','" & v_strSSAFACCTNO & "')"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                'Day lenh vao ODMAST luon
                If String.Compare(v_strDIRECT, "Y") = 0 Then
                    'Goi thu tuc day ca lenh vao ODMAST
                    Dim v_arrPara(1) As StoreParameter
                    v_objParam = New StoreParameter
                    v_objParam.ParamName = "p_orderid"
                    v_objParam.ParamValue = v_strORDERID
                    v_objParam.ParamDirection = ParameterDirection.InputOutput
                    v_objParam.ParamSize = 32000
                    v_objParam.ParamType = GetType(System.String).Name
                    v_arrPara(0) = v_objParam

                    v_objParam = New StoreParameter
                    v_objParam.ParamName = "p_err_code"
                    v_objParam.ParamDirection = ParameterDirection.Output
                    v_objParam.ParamValue = ""
                    v_objParam.ParamSize = 100
                    v_objParam.ParamType = GetType(System.String).Name
                    v_arrPara(1) = v_objParam
                    v_strOrcReturn = v_obj.ExecuteOracleStored("TXPKS_AUTO.pr_fo2odsyn", v_arrPara, 1)
                    If v_strOrcReturn.Length = 0 Then
                        v_strOrcReturn = "0"
                    ElseIf Not IsNumeric(v_strOrcReturn) Then
                        v_strOrcReturn = "0"
                    End If
                    v_lngErrCode = CLng(v_strOrcReturn)
                    If v_lngErrCode <> ERR_SYSTEM_OK Then
                        'Xoa luon lenh o FOMAST neu o mode direct
                        v_strSQL = "UPDATE FOMAST SET DELTD='Y' WHERE ACCTNO='" + v_strORDERID + "'"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                        Return v_lngErrCode
                    End If
                End If

            ElseIf v_strFUNCNAME = "ACTIVATEORDER" Then
                v_strSQL = "UPDATE FOMAST SET BOOK='A',ACTIVATEDT=TO_CHAR(SYSDATE,'DD/MM/RRRR HH24:MI:SS') WHERE BOOK='I' AND ACCTNO='" + v_strACCTNO + "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                'v_strFEEDBACKMSG = "Order is activated and pending to process: " + v_strACCTNO.ToString
                v_strFEEDBACKMSG = "MSG_CONFIRMED_ORDER_ACTIVATED"

                'Day lenh vao ODMAST luon
                If String.Compare(v_strDIRECT, "Y") = 0 Then
                    'Goi thu tuc day ca lenh vao ODMAST
                    Dim v_arrPara(1) As StoreParameter
                    v_objParam = New StoreParameter
                    v_objParam.ParamName = "p_orderid"
                    v_objParam.ParamValue = v_strACCTNO
                    v_objParam.ParamDirection = ParameterDirection.InputOutput
                    v_objParam.ParamSize = 32000
                    v_objParam.ParamType = GetType(System.String).Name
                    v_arrPara(0) = v_objParam

                    v_objParam = New StoreParameter
                    v_objParam.ParamName = "p_err_code"
                    v_objParam.ParamDirection = ParameterDirection.Output
                    v_objParam.ParamValue = ""
                    v_objParam.ParamSize = 100
                    v_objParam.ParamType = GetType(System.String).Name
                    v_arrPara(1) = v_objParam
                    v_lngErrCode = v_obj.ExecuteOracleStored("TXPKS_AUTO.pr_fo2odsyn", v_arrPara, 1)
                    If v_lngErrCode <> ERR_SYSTEM_OK Then
                        'Cap nhat trang thai tu choi
                        v_strSQL = "UPDATE FOMAST SET STATUS='R' WHERE ACCTNO='" + v_strACCTNO + "'"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                        Return v_lngErrCode
                    End If
                End If

            ElseIf v_strFUNCNAME = "CANCELORDER" Then
                If v_strBOOK = "A" Then

                    'Kiem tra da ton tai lenh huy hay chua - return message loi.
                    '-- Lenh da duoc huy. truoc khi xu ly.?
                    ' DucNV rao vi  check the nay : neu co 1 lenh huy bi tu choi thi ko bao gio huy lai dc nua
                    'v_strSQL = "SELECT count(1) FROM fomast WHERE orgacctno = '" & v_strACCTNO & "' AND status = 'R'"
                    'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    'If v_ds.Tables(0).Rows(0)(0) = 0 Then
                    '    '-- Lenh da thuc hien huy tren FO?
                    v_strSQL = "SELECT count(1) FROM fomast WHERE refacctno = '" & v_strACCTNO & "' AND substr(exectype,1,1) = 'C' and status <> 'R'"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows(0)(0) = 0 Then
                        '-- Lenh da thuc hien huy tren OD?
                        v_strSQL = "SELECT count(1) FROM odmast WHERE reforderid = '" & v_strACCTNO & "' AND substr(exectype,1,1) = 'C'"
                        v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                        If v_ds.Tables(0).Rows(0)(0) = 0 Then
                            '-- Kiem tra xem con khoi luong chua khop hay khong.?
                            v_strSQL = "SELECT count(1) FROM odmast WHERE orderid = '" & v_strACCTNO & "' AND remainqtty > 0"
                            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                            If v_ds.Tables(0).Rows(0)(0) = 0 Then
                                Return gc_ERRCODE_FO_INVALID_STATUS
                            End If
                        Else
                            Return gc_ERRCODE_FO_INVALID_STATUS
                        End If
                    Else
                        Return gc_ERRCODE_FO_INVALID_STATUS
                    End If
                    'Else
                    '    Return gc_ERRCODE_FO_INVALID_STATUS
                    'End If

                    'Kiem tra trang thai cua lenh
                    v_strSQL = "SELECT STATUS FROM FOMAST WHERE ORGACCTNO='" & v_strACCTNO & "' AND EXECTYPE IN ('NB','NS')"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count > 0 Then
                        'Lenh chua duoc huy lan nao
                        'Kiem tra trang thai cua lenh, Neu la P thi xoa luon
                        If v_ds.Tables(0).Rows(0)("STATUS") = "P" Then
                            v_strFEEDBACKMSG = "Order is cancelled when processing"
                            v_strSQL = "UPDATE FOMAST SET STATUS='R',FEEDBACKMSG='" & v_strFEEDBACKMSG & "' WHERE BOOK='A' AND ACCTNO='" + v_strACCTNO + "' AND STATUS='P'"
                            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                        ElseIf v_ds.Tables(0).Rows(0)("STATUS") = "A" Then
                            'Neu la A tuc la lenh da day vao he thong thi sinh lenh huy
                            v_blnOK = True
                        Else
                            v_strFEEDBACKMSG = "Order can't be cancelled"
                            v_strFEEDBACKMSG = "MSG_REJECT_CANCEL_ORDER"
                        End If
                    Else
                        'LENH o trong he thong
                        v_blnOK = True
                    End If

                    If v_blnOK Then
                        'Generate OrderID
                        v_lngErrCode = v_obj.GetSysVar("SYSTEM", "CURRDATE", v_strBUSDATE)
                        v_strORDERID = v_strBUSDATE & Right(gc_FORMAT_BATCHTXNUM & CStr(v_obj.GetIDValue("ODMAST")), Len(gc_FORMAT_BATCHTXNUM))
                        v_strFEEDBACKMSG = "MSG_CANCEL_ORDER_IS_RECEIVED"

                        v_strSQL = "INSERT INTO FOMAST (ACCTNO, ORGACCTNO, ACTYPE, AFACCTNO, STATUS, EXECTYPE, PRICETYPE, TIMETYPE, MATCHTYPE, NORK, CLEARCD, CODEID, SYMBOL, " & ControlChars.CrLf _
                            & "CONFIRMEDVIA, DIRECT, BOOK, FEEDBACKMSG, ACTIVATEDT, CREATEDDT, CLEARDAY, QUANTITY, PRICE, QUOTEPRICE, TRIGGERPRICE, EXECQTTY, EXECAMT, REMAINQTTY, " & ControlChars.CrLf _
                            & "REFACCTNO, REFQUANTITY, REFPRICE, REFQUOTEPRICE,VIA,EFFDATE,EXPDATE,USERNAME)" & ControlChars.CrLf

                        v_strSQL = v_strSQL & " SELECT '" & v_strORDERID.Trim & "', od.orderid ORGACCTNO, od.ACTYPE, od.AFACCTNO, 'P', " _
                           & "(CASE WHEN od.EXECTYPE='NB' OR od.EXECTYPE='CB' OR od.EXECTYPE='AB' THEN 'CB' ELSE 'CS' END) CANCEL_EXECTYPE, " _
                           & "od.PRICETYPE, od.TIMETYPE, od.MATCHTYPE, od.NORK, od.CLEARCD, od.CODEID, sb.SYMBOL, " _
                           & "'O' CONFIRMEDVIA,'" & v_strDIRECT & "','A' BOOK, '" & v_strFEEDBACKMSG & "', " _
                           & "TO_CHAR(SYSDATE,'DD/MM/RRRR HH24:MI:SS'), TO_CHAR(SYSDATE,'DD/MM/RRRR HH24:MI:SS'), " _
                           & "od.CLEARDAY,od.exqtty QUANTITY,(od.exprice/1000) PRICE, (od.QUOTEPRICE/1000) QUOTEPRICE, 0 TRIGGERPRICE, od.EXECQTTY, od.EXECAMT, " _
                           & "od.REMAINQTTY, od.orderid REFACCTNO, 0 REFQUANTITY, 0 REFPRICE, (od.QUOTEPRICE/1000) REFQUOTEPRICE,'" & v_strVIA & "' VIA,TO_DATE('" & v_strCURRDATE & "','" & gc_FORMAT_DATE & "') EFFDATE,TO_DATE('" & v_strCURRDATE & "','" & gc_FORMAT_DATE & "') EXPDATE,'" & v_strUSERNAME & "' USERNAME " _
                           & "FROM ODMAST od, sbsecurities sb " _
                           & "WHERE orstatus IN ('1','2','4','8') AND orderid='" + v_strACCTNO + "' and sb.codeid = od.codeid and orderid not in (select REFACCTNO from fomast WHERE EXECTYPE IN ('CB','CS') AND STATUS <>'R')"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                        'Day lenh vao ODMAST luon
                        If String.Compare(v_strDIRECT, "Y") = 0 Then
                            'Goi thu tuc day ca lenh vao ODMAST
                            Dim v_arrPara(1) As StoreParameter
                            v_objParam = New StoreParameter
                            v_objParam.ParamName = "p_orderid"
                            v_objParam.ParamValue = v_strORDERID
                            v_objParam.ParamDirection = ParameterDirection.InputOutput
                            v_objParam.ParamSize = 32000
                            v_objParam.ParamType = GetType(System.String).Name
                            v_arrPara(0) = v_objParam

                            v_objParam = New StoreParameter
                            v_objParam.ParamName = "p_err_code"
                            v_objParam.ParamDirection = ParameterDirection.Output
                            v_objParam.ParamValue = ""
                            v_objParam.ParamSize = 100
                            v_objParam.ParamType = GetType(System.String).Name
                            v_arrPara(1) = v_objParam
                            v_strOrcReturn = v_obj.ExecuteOracleStored("TXPKS_AUTO.pr_fo2odsyn", v_arrPara, 1)
                            If v_strOrcReturn.Length = 0 Then
                                v_strOrcReturn = "0"
                            ElseIf Not IsNumeric(v_strOrcReturn) Then
                                v_strOrcReturn = "0"
                            End If
                            v_lngErrCode = CLng(v_strOrcReturn)
                            If v_lngErrCode <> ERR_SYSTEM_OK Then
                                'Xoa luon lenh o FOMAST neu o mode direct
                                v_strSQL = "UPDATE FOMAST SET DELTD='Y' WHERE ACCTNO='" + v_strORDERID + "'"
                                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                                Return v_lngErrCode
                            End If
                        End If
                    End If
                Else
                    v_strSQL = "DELETE FROM FOMAST WHERE BOOK='I' AND ACCTNO='" + v_strACCTNO + "'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    v_strFEEDBACKMSG = "Inactive order was deleted"
                    v_strFEEDBACKMSG = "MSG_CONFIRMED_ORDER_CANCALLED"
                End If

            ElseIf v_strFUNCNAME = "AMENDMENTORDER" Then
                If v_strBOOK = "A" Then
                    v_strSQL = "SELECT STATUS FROM FOMAST WHERE ORGACCTNO='" & v_strACCTNO & "' AND EXECTYPE IN ('NB','NS')"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count > 0 Then
                        'Lenh chua duoc sua lan nao
                        'Kiem tra trang thai cua lenh, Neu la P thi xoa luon
                        If v_ds.Tables(0).Rows(0)("STATUS") = "P" Then
                            v_strFEEDBACKMSG = "Order is cancelled when processing"
                            v_strSQL = "UPDATE FOMAST SET STATUS='R',FEEDBACKMSG='" & v_strFEEDBACKMSG & "' WHERE BOOK='A' AND ACCTNO='" + v_strACCTNO + "' AND STATUS='P'"
                            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                            v_blnOK = True
                        ElseIf v_ds.Tables(0).Rows(0)("STATUS") = "A" Then
                            'Neu la A tuc la lenh da day vao he thong thi sinh lenh huy
                            v_blnOK = True
                        Else
                            v_strFEEDBACKMSG = "Order can't be cancelled"
                            v_strFEEDBACKMSG = "MSG_REJECT_CANCEL_ORDER"
                        End If
                    Else
                        'LENH o trong he thong
                        v_blnOK = True
                    End If

                    'Generate OrderID
                    v_lngErrCode = v_obj.GetSysVar("SYSTEM", "CURRDATE", v_strBUSDATE)
                    v_strORDERID = v_strBUSDATE & Right(gc_FORMAT_BATCHTXNUM & CStr(v_obj.GetIDValue("ODMAST")), Len(gc_FORMAT_BATCHTXNUM))
                    v_strFEEDBACKMSG = "Admendment order is received and pending to process"
                    v_strFEEDBACKMSG = "MSG_ADMENT_ORDER_RECEIVED"

                    v_strSQL = "INSERT INTO FOMAST (ACCTNO, ORGACCTNO, ACTYPE, AFACCTNO, STATUS, EXECTYPE, PRICETYPE, TIMETYPE, MATCHTYPE, NORK, CLEARCD, CODEID, SYMBOL, " & ControlChars.CrLf _
                        & "CONFIRMEDVIA, BOOK, FEEDBACKMSG, ACTIVATEDT, CREATEDDT, CLEARDAY, QUANTITY, PRICE, QUOTEPRICE, TRIGGERPRICE, EXECQTTY, EXECAMT, REMAINQTTY, " & ControlChars.CrLf _
                        & "REFACCTNO, REFQUANTITY, REFPRICE, REFQUOTEPRICE,VIA,EFFDATE,EXPDATE,USERNAME)" & ControlChars.CrLf _
                        & "SELECT '" & v_strORDERID.Trim & "', od.orderid ORGACCTNO, od.ACTYPE, od.AFACCTNO, 'P', " & ControlChars.CrLf _
                        & "(CASE WHEN od.EXECTYPE='NB' OR od.EXECTYPE='CB' OR EXECTYPE='AB' THEN 'AB' ELSE 'AS' END) CANCEL_EXECTYPE, " & ControlChars.CrLf _
                        & "od.PRICETYPE, od.TIMETYPE, od.MATCHTYPE, od.NORK, od.CLEARCD, od.CODEID, sb.SYMBOL, " & ControlChars.CrLf _
                        & "'O' CONFIRMEDVIA, 'A' BOOK, '" & v_strFEEDBACKMSG & "' FEEDBACKMSG,TO_CHAR(SYSDATE,'DD/MM/RRRR HH24:MI:SS') ACTIVATEDT,TO_CHAR(SYSDATE,'DD/MM/RRRR HH24:MI:SS') CREATEDDT, od.CLEARDAY, " & ControlChars.CrLf _
                        & v_dblQUANTITY & ", " & v_dblPRICE & "/1000, " & v_dblQUOTEPRICE & "/1000,0 TRIGGERPRICE, 0 EXECQTTY, 0 EXECAMT," & v_dblQUANTITY & " REMAINQTTY, " & ControlChars.CrLf _
                        & "od.orderid REFACCTNO, ORDERQTTY REFQUANTITY, QUOTEPRICE REFPRICE, QUOTEPRICE REFQUOTEPRICE,'" & v_strVIA & "' VIA ,TO_DATE('" & v_strCURRDATE & "','" & gc_FORMAT_DATE & "') EFFDATE,TO_DATE('" & v_strCURRDATE & "','" & gc_FORMAT_DATE & "') EXPDATE,'" & v_strUSERNAME & "' USERNAME " & ControlChars.CrLf _
                        & "FROM ODMAST od, sbsecurities sb " _
                        & "WHERE orstatus IN ('1','2','4','8') AND orderid='" + v_strACCTNO + "' and sb.codeid = od.codeid and orderid not in (select REFACCTNO from fomast WHERE EXECTYPE IN ('CB','CS','AB','AS') AND STATUS <>'R' )"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                Else
                    v_strSQL = "UPDATE FOMAST SET QUANTITY=" & v_dblQUANTITY & ", PRICE=" & v_dblPRICE & "/1000, QUOTEPRICE=" & v_dblQUOTEPRICE & "/1000 " & ControlChars.CrLf _
                        & " WHERE BOOK='I' AND ACCTNO='" + v_strACCTNO + "'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    v_strFEEDBACKMSG = "The inactive order was modified"
                    v_strFEEDBACKMSG = "MSG_CONFIRMED_ORDER_ADMANMENT"
                End If
            End If

            'Return data
            pv_strObjMsg = v_strFEEDBACKMSG
            Return ERR_SYSTEM_OK
        Catch ex As Exception
            Throw ex
        Finally
            XMLOrder = Nothing
            XMLDocument = Nothing
            v_objParam = Nothing
        End Try
    End Function

  Private Function UpdateSecuritiesInfor(ByRef pv_strObjMsg As String) As Long
    Dim v_obj As DataAccess, v_ds As DataSet, v_strSQL, v_strSYSVAR As String
    Dim v_strErrorSource As String = ATTR_TABLE & ".UpdateSymbolCE_FL_RF"
    Dim XMLDocument As New XmlDocumentEx, XMLOrder As New XmlDocumentEx
    Dim v_objParam As New StoreParameter
    Dim v_nodeData, v_nodeOldData As Xml.XmlNode
    Dim v_lngErrCode As Long = ERR_SYSTEM_OK
    v_obj = New DataAccess
    v_obj.NewDBInstance(gc_MODULE_HOST)
    Try
      XMLDocument.LoadXml(pv_strObjMsg)
      Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
      Dim v_strClause As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value) 'Noi dung lenh dat vao
      XMLOrder.LoadXml(v_strClause)
      Dim v_strSYMBOL, v_strRFPRICE, v_strFLPRICE, v_strCEPRICE As String


      v_nodeData = XMLOrder.SelectSingleNode("RootTrade/objBODY/Order")
      'Lay ngay hien tai
      For i As Integer = 0 To v_nodeData.ChildNodes.Count - 1
        Select Case v_nodeData.ChildNodes(i).Name
          Case "SYMBOL"
            v_strSYMBOL = v_nodeData.ChildNodes(i).InnerXml
          Case "RFPRICE"
            v_strRFPRICE = v_nodeData.ChildNodes(i).InnerXml
          Case "FLPRICE"
            v_strFLPRICE = v_nodeData.ChildNodes(i).InnerXml
          Case "CEPRICE"
            v_strCEPRICE = v_nodeData.ChildNodes(i).InnerXml
        End Select
      Next

      v_strSQL = "UPDATE SECURITIES_INFO SET BASICPRICE=" & v_strRFPRICE & ", FLOORPRICE=" & v_strFLPRICE & ", CEILINGPRICE=" & v_strCEPRICE & " WHERE SYMBOL='" & v_strSYMBOL & "'"
      v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
      Return ERR_SYSTEM_OK
    Catch ex As Exception
      Throw ex
    Finally
      XMLOrder = Nothing
      XMLDocument = Nothing
      v_objParam = Nothing
    End Try
  End Function

  Private Function AccountInquiry(ByRef pv_strObjMsg As String) As Long
    Dim v_obj As DataAccess, v_ds As DataSet, v_strSQL As String
    Dim v_strErrorSource As String = ATTR_TABLE & ".AccountInquiry"
    Dim XMLDocument As New XmlDocumentEx, XMLOrder As New XmlDocumentEx
    Dim v_nodeData, v_nodeOldData As Xml.XmlNode
    Dim v_lngErrCode As Long = ERR_SYSTEM_OK
    v_obj = New DataAccess
    v_obj.NewDBInstance(gc_MODULE_HOST)
    Dim v_strMSGBODY As String = ""
    Dim v_strTableName As String
    Dim v_stringWriter As New StringWriter
    Try
      XMLDocument.LoadXml(pv_strObjMsg)
      Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
      Dim v_strClause As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value) 'Noi dung lenh dat vao
      XMLOrder.LoadXml(v_strClause)
      Dim v_strKEYNAME, v_strKEYVALUE As String
      v_nodeData = XMLOrder.SelectSingleNode("RootTrade/objBODY/Inquiry")
      Dim v_strFUNCNAME As String = CStr(v_nodeData.Attributes("CLASS").Value)
      For i As Integer = 0 To v_nodeData.ChildNodes.Count - 1
        Select Case v_nodeData.ChildNodes(i).Name
          Case "KEYNAME"
            v_strKEYNAME = v_nodeData.ChildNodes(i).InnerXml
          Case "KEYVALUE"
            v_strKEYVALUE = v_nodeData.ChildNodes(i).InnerXml
        End Select
      Next
      Select Case v_strFUNCNAME
        Case "ACCOUNT"
          v_strSQL = "SELECT * FROM (V_BUSACCOUNTSTATUS) CIMAST  WHERE " & v_strKEYNAME & "='" & v_strKEYVALUE & "'"
          v_strTableName = "CIMAST"
        Case "IOD"
          v_strSQL = "SELECT * FROM (V_BUSIODSTATUS) IOD  WHERE " & v_strKEYNAME & "='" & v_strKEYVALUE & "'"
          v_strTableName = "IOD"
        Case "ORDER"
          v_strSQL = "SELECT * FROM (V_BUSORDERSTATUS) ODMAST  WHERE " & v_strKEYNAME & "='" & v_strKEYVALUE & "'"
          v_strTableName = "ODMAST"
        Case "SEC"
          v_strSQL = "SELECT * FROM (V_BUSSECSTATUS) SEMAST  WHERE " & v_strKEYNAME & "='" & v_strKEYVALUE & "'"
          v_strTableName = "SEMAST"
        Case "TRADING_RESULT"
          v_strSQL = "SELECT * FROM (V_BUSTRADINGRESULT) TRADING_RESULT  WHERE " & v_strKEYNAME & "='" & v_strKEYVALUE & "'"
          v_strTableName = "TRADING_RESULT"
      End Select
      v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
      If v_ds.Tables(0).Rows.Count > 0 Then
        v_ds.Tables(0).TableName = v_strTableName
        v_ds.WriteXml(v_stringWriter, XmlWriteMode.WriteSchema)
        v_strMSGBODY = v_stringWriter.ToString
      End If
      'Return data
      pv_strObjMsg = v_strMSGBODY
      Return ERR_SYSTEM_OK
    Catch ex As Exception
      Throw ex
    Finally
      XMLOrder = Nothing
      XMLDocument = Nothing
    End Try
  End Function

  Private Function SystemParamInquiry(ByRef pv_strObjMsg As String) As Long
    Dim v_obj As DataAccess, v_ds As DataSet, v_strSQL As String
    Dim v_strErrorSource As String = ATTR_TABLE & ".AccountInquiry"
    Dim XMLDocument As New XmlDocumentEx, XMLOrder As New XmlDocumentEx
    Dim v_nodeData, v_nodeOldData As Xml.XmlNode
    Dim v_lngErrCode As Long = ERR_SYSTEM_OK
    v_obj = New DataAccess
    v_obj.NewDBInstance(gc_MODULE_HOST)
    Dim v_strMSGBODY As String = ""
    Dim v_strTableName As String
    Dim v_stringWriter As New StringWriter
    Try
      XMLDocument.LoadXml(pv_strObjMsg)
      Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
      Dim v_strClause As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value) 'Noi dung lenh dat vao
      XMLOrder.LoadXml(v_strClause)
      Dim v_strCOMMAND As String
      v_nodeData = XMLOrder.SelectSingleNode("RootTrade/objBODY/Inquiry")
      Dim v_strFUNCNAME As String = CStr(v_nodeData.Attributes("CLASS").Value)
      For i As Integer = 0 To v_nodeData.ChildNodes.Count - 1
        Select Case v_nodeData.ChildNodes(i).Name
          Case "COMMAND"
            v_strCOMMAND = v_nodeData.ChildNodes(i).InnerXml
          Case "TABLENAME"
            v_strTableName = v_nodeData.ChildNodes(i).InnerXml
        End Select
      Next
      Select Case v_strFUNCNAME
        Case "SYSTIME"
          v_strSQL = "SELECT TO_CHAR(SYSDATE,'HH:MI:SS') SYSTEMTIME FROM DUAL"
          v_strTableName = IIf(v_strTableName Is Nothing Or v_strTableName = "", "SYSTIME", v_strTableName)
        Case "SYSDATE"
          v_strSQL = "SELECT TO_CHAR(SYSDATE,'DD/MM/YYYY') SYSTEMDATE FROM DUAL"
          v_strTableName = IIf(v_strTableName Is Nothing Or v_strTableName = "", "SYSDATE", v_strTableName)
        Case ""
          v_strSQL = v_strCOMMAND
          v_strTableName = IIf(v_strTableName Is Nothing Or v_strTableName = "", "SYSTEM", v_strTableName)
      End Select

      'Chỉ cho phép query lấy dữ liệu không cho phép UPDATE
      If isQueryCommand(v_strSQL) Then
        v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
        If v_ds.Tables(0).Rows.Count > 0 Then
          v_ds.Tables(0).TableName = v_strTableName
          v_ds.WriteXml(v_stringWriter, XmlWriteMode.WriteSchema)
          v_strMSGBODY = v_stringWriter.ToString
        End If
        'Return data
        pv_strObjMsg = v_strMSGBODY
      End If
      Return ERR_SYSTEM_OK
    Catch ex As Exception
      Throw ex
    Finally
      XMLOrder = Nothing
      XMLDocument = Nothing
    End Try
  End Function

  Public Function GetOrderBookonHand(ByRef pv_strObjMsg As String, ByVal strAFAcctno As String) As Long

    Dim v_obj As DataAccess, v_ds As DataSet, strSQL As String
    Dim v_strErrorSource As String = ATTR_TABLE & ".Getorderbookonhankonline"
    Dim XMLDocument As New XmlDocumentEx, XMLOrder As New XmlDocumentEx
    Dim v_nodeData, v_nodeOldData As Xml.XmlNode
    Dim v_lngErrCode As Long = ERR_SYSTEM_OK
    v_obj = New DataAccess
    v_obj.NewDBInstance(gc_MODULE_HOST)
    Try

      Dim v_objRptParam As ReportParameters
      Dim v_arrRptPara() As ReportParameters
      ReDim v_arrRptPara(0)
      '0. So hop dong
      v_objRptParam = New ReportParameters
      v_objRptParam.ParamName = "pv_AFACCTNO"
      v_objRptParam.ParamValue = strAFAcctno
      v_objRptParam.ParamSize = Convert.ToString(100)
      v_objRptParam.ParamType = "VARCHAR2"
      v_arrRptPara(0) = v_objRptParam

      v_ds = v_obj.ExecuteStoredReturnDataset("GetOrderBookonHand", v_arrRptPara)
      BuildXMLObjData(v_ds, pv_strObjMsg)

      Return ERR_SYSTEM_OK
    Catch ex As Exception
      Throw ex
    Finally
      XMLOrder = Nothing
      XMLDocument = Nothing
    End Try
  End Function

End Class