Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Public Class Trans
    Inherits CoreBusiness.txMaster

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_MODULE = "CL"
    End Sub

#Region " Implement functions"
    Overrides Function txImpUpdate(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrorCode As Long = ERR_SYSTEM_OK
        Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
        Dim v_strTLTXCD As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLTXCD), Xml.XmlAttribute).Value)
        Select Case v_strTLTXCD
            Case gc_CL_MORTGAGE, gc_CL_UNMORTGAGE
                'The chap va giai chap
                v_lngErrorCode = CollateralLink2Limit(pv_xmlDocument)
            Case gc_CL_ADJUST_VALUEUSING
                v_lngErrorCode = AdjustCollateralUsingValue(pv_xmlDocument)
            Case gc_CL_VALUEASSET
                'Dinh gia lai tai san
                v_lngErrorCode = CollateralValue(pv_xmlDocument)
        End Select
        'Tra ve ma loi
        Return v_lngErrorCode
    End Function

    Overrides Function txImpCheck(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrorCode As Long = ERR_SYSTEM_OK
        Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
        Dim v_strTLTXCD As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLTXCD), Xml.XmlAttribute).Value)
        Select Case v_strTLTXCD
            Case gc_CL_UNMORTGAGE
                'Giai chap
                v_lngErrorCode = CheckUnmortageCollateral(pv_xmlDocument)
            Case gc_CL_MORTGAGE
                'Giai chap
                v_lngErrorCode = CheckMortageCollateral(pv_xmlDocument)
            Case gc_CL_VALUEASSET
                v_lngErrorCode = CheckCollateralValue(pv_xmlDocument)
        End Select
        'Tra ve ma loi
        Return v_lngErrorCode
    End Function

    Overrides Function txImpMisc(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrorCode As Long
        Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
        Dim v_strTLTXCD As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLTXCD), Xml.XmlAttribute).Value)
        Select Case v_strTLTXCD
            Case gc_CL_ACCOUNTINQUIRY
                v_lngErrorCode = BasedInquiryAccount(pv_xmlDocument)
            Case gc_CL_ACCOUNTHISTORY
                v_lngErrorCode = BasedHistoryAccount(pv_xmlDocument)
        End Select
        'Tra ve ma loi
        Return v_lngErrorCode
    End Function
#End Region

#Region " Private functions"
    Private Function CheckUnmortageCollateral(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = Me.ATTR_MODULE & ".Trans.CheckUnmortageCollateral", v_strErrorMessage As String
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strSQL, v_strFLDCD, v_strFLDTYPE, v_strVALUE As String, v_dblVALUE As Double, i As Integer
        Dim v_strCLACCTNO, v_strLMACCTNO, v_strAFACCTNO, v_strDORC As String, v_dblCLAMT, v_dblLMAMT, v_dblSECUREDRATIO As Double
        Dim v_ds As DataSet
        Try
            Dim v_strBRID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXTIME As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTIME).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strTLTXCD As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLTXCD), Xml.XmlAttribute).Value)


            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            'Doc noi dung giao dich
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If

                    Select Case v_strFLDCD
                        Case "03" 'CLACCTNO
                            v_strCLACCTNO = v_strVALUE
                        Case "05" 'AFACCTNO
                            v_strAFACCTNO = v_strVALUE
                        Case "10" 'Amount
                            v_dblCLAMT = v_dblVALUE

                    End Select
                End With
            Next

            v_strSQL = "SELECT SUM(CASE WHEN DORC='C' THEN CLAMT WHEN DORC='D' THEN -CLAMT ELSE 0 END) CLAMT " & _
                    "FROM CLLINK WHERE CLACCTNO='" & v_strCLACCTNO & "' AND LMACCTNO='" & v_strAFACCTNO & "' " & _
                    "GROUP BY CLACCTNO, LMACCTNO "
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_dblLMAMT = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("CLAMT"))
                If v_dblCLAMT > v_dblLMAMT Then
                    Return ERR_CL_OVER_MORTAGED_AMT
                End If
            Else
                Return ERR_CL_OVER_MORTAGED_AMT
            End If

            v_strSQL = "SELECT STATUS, MRCRLIMIT FROM AFMAST WHERE ACCTNO='" & v_strAFACCTNO & "' "
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                If gf_CorrectStringField(v_ds.Tables(0).Rows(0)("STATUS")) <> "A" Then
                    Return ERR_CF_AFMAST_STATUS_INVALID
                End If
                If v_dblCLAMT > gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("MRCRLIMIT")) Then
                    Return ERR_CF_AFMAST_MRCRLIMIT_NOT_ENOUGH
                End If
            Else
                Return ERR_CF_AFMAST_NOTFOUND
            End If

            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function CheckMortageCollateral(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = Me.ATTR_MODULE & ".Trans.CheckMortageCollateral", v_strErrorMessage As String
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strSQL, v_strFLDCD, v_strFLDTYPE, v_strVALUE As String, v_dblVALUE As Double, i As Integer
        Dim v_strCLACCTNO, v_strDORC As String, v_dblCLAMT, v_dblSECUREDAMT, v_dblAmt As Double
        Dim v_ds As DataSet
        Try
            Dim v_strBRID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXTIME As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTIME).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strTLTXCD As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLTXCD), Xml.XmlAttribute).Value)


            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            'Doc noi dung giao dich
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If

                    Select Case v_strFLDCD
                        Case "03" 'CLACCTNO
                            v_strCLACCTNO = v_strVALUE
                        Case "10" 'Amount
                            v_dblAmt = v_dblVALUE

                    End Select
                End With
            Next

            v_strSQL = "SELECT CLAMT - SECUREDAMT AVLAMT FROM CLMAST WHERE ACCTNO ='" & v_strCLACCTNO & "' "
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                If v_dblAmt > gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("AVLAMT")) Then
                    Return ERR_CL_NOT_ENOUGH_SECUREDAMT
                End If
            Else
                Return ERR_SA_ACCTNO_MASTER_NOTFOUND
            End If


            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function CollateralLink2Limit(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = Me.ATTR_MODULE & ".Trans.CollateralLink2Limit", v_strErrorMessage As String
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strSQL, v_strFLDCD, v_strFLDTYPE, v_strVALUE As String, v_dblVALUE As Double, i As Integer
        Dim v_strCLACCTNO, v_strLMACCTNO, v_strAFACCTNO, v_strDORC As String, v_dblCLAMT, v_dblLMAMT, v_dblSECUREDRATIO As Double
        Dim v_ds As DataSet
        Try
            Dim v_strBRID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXTIME As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTIME).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strTLTXCD As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLTXCD), Xml.XmlAttribute).Value)
            If String.Compare(v_strTLTXCD, gc_CL_MORTGAGE) = 0 Then
                v_strDORC = "C"
            ElseIf String.Compare(v_strTLTXCD, gc_CL_UNMORTGAGE) = 0 Then
                v_strDORC = "D"
            Else
                v_strDORC = "N"
            End If

            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            'Doc noi dung giao dich
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If

                    Select Case v_strFLDCD
                        Case "03" 'CLACCTNO
                            v_strCLACCTNO = v_strVALUE
                        Case "05" 'LMACCTNO
                            'v_strLMACCTNO = v_strVALUE
                            v_strAFACCTNO = v_strVALUE
                        Case "10" 'AMT
                            v_dblCLAMT = v_dblVALUE
                    End Select
                End With
            Next

            Dim v_dblDelta As Double
            If v_strDORC = "C" Then
                v_dblDelta = v_dblCLAMT
            ElseIf v_strDORC = "D" Then
                v_dblDelta = -v_dblCLAMT
            End If

            If Not v_blnReversal Then
                v_strSQL = "INSERT INTO CLLINK (AUTOID, TXDATE, TXNUM, CLACCTNO, LMACCTNO, DORC, CLAMT, LMAMT) " & ControlChars.CrLf _
                    & "VALUES (SEQ_CLLINK.NEXTVAL, TO_DATE('" & v_strTXDATE & "','" & gc_FORMAT_DATE & "'), '" & v_strTXNUM & "', '" _
                    & v_strCLACCTNO & "', '" & v_strAFACCTNO & "', '" & v_strDORC & "', " & v_dblCLAMT & ", " & v_dblCLAMT & ")"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                'v_strSQL = "UPDATE AFMAST SET MRCRLIMIT = MRCRLIMIT + " & v_dblDelta & ", MRCLAMT = MRCLAMT + " & FRound(v_dblDelta * 100 / v_dblSECUREDRATIO, 0) & " WHERE ACCTNO = '" & v_strAFACCTNO & "' "
                v_strSQL = "UPDATE AFMAST SET MRCRLIMIT = MRCRLIMIT + " & v_dblDelta & " WHERE ACCTNO = '" & v_strAFACCTNO & "' "
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            Else
                v_strSQL = "DELETE FROM CLLINK WHERE TXDATE=TO_DATE('" & v_strTXDATE & "','" & gc_FORMAT_DATE & "') AND TXNUM='" & v_strTXNUM & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                'v_strSQL = "UPDATE AFMAST SET MRCRLIMIT = MRCRLIMIT - " & v_dblDelta & ", MRCLAMT = MRCLAMT - " & FRound(v_dblDelta * 100 / v_dblSECUREDRATIO, 0) & " WHERE ACCTNO = '" & v_strAFACCTNO & "' "
                v_strSQL = "UPDATE AFMAST SET MRCRLIMIT = MRCRLIMIT - " & v_dblDelta & " WHERE ACCTNO = '" & v_strAFACCTNO & "' "
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End If

            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function CheckCollateralValue(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = Me.ATTR_MODULE & ".Trans.CheckCollateralValue", v_strErrorMessage As String
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strSQL, v_strFLDCD, v_strFLDTYPE, v_strVALUE As String, v_dblVALUE As Double, i As Integer
        Dim v_strCLACCTNO As String
        Dim v_dblCLVALUE, v_dblCLAMT, v_dblSECUREDAMT, v_dblSECUREDRATIO As Double

        Try
            Dim v_strBRID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXTIME As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTIME).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strTLTXCD As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLTXCD), Xml.XmlAttribute).Value)
            Dim v_obj As New DataAccess, v_ds As New DataSet
            v_obj.NewDBInstance(gc_MODULE_HOST)
            'Doc noi dung giao dich
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If

                    Select Case v_strFLDCD
                        Case "03" 'CLACCTNO
                            v_strCLACCTNO = v_strVALUE
                        Case "10" 'AMT
                            v_dblCLVALUE = v_dblVALUE
                    End Select
                End With
            Next

            v_strSQL = "SELECT SECUREDAMT, SECUREDRATIO FROM CLMAST WHERE ACCTNO='" & v_strCLACCTNO & "' "
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_dblSECUREDAMT = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("SECUREDAMT"))
                v_dblSECUREDRATIO = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("SECUREDRATIO"))
                v_dblCLAMT = v_dblCLVALUE * v_dblSECUREDRATIO / 100
                If v_dblCLAMT < v_dblSECUREDAMT Then
                    Return ERR_CL_SECUREDAMT_OVER_CLAMT
                End If
            Else
                Return ERR_SA_ACCTNO_MASTER_NOTFOUND
            End If

            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function CollateralValue(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = Me.ATTR_MODULE & ".Trans.CollateralLink2Limit", v_strErrorMessage As String
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strSQL, v_strFLDCD, v_strFLDTYPE, v_strVALUE As String, v_dblVALUE As Double, i As Integer
        Dim v_strCLACCTNO As String
        Dim v_dblNEWCLVALUE, v_dblOLDCLVALUE, v_dblCLAMT As Double
        Dim v_dblOLDSECUREDRATIO, v_dblSECUREDRATIO As Double

        Try
            Dim v_strBRID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXTIME As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTIME).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strTLTXCD As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLTXCD), Xml.XmlAttribute).Value)
            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            'Doc noi dung giao dich
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If

                    Select Case v_strFLDCD
                        Case "03" 'CLACCTNO
                            v_strCLACCTNO = v_strVALUE
                        Case "04"
                            v_dblOLDCLVALUE = v_dblVALUE
                        Case "05"
                            v_dblCLAMT = v_dblVALUE
                        Case "10" 'AMT
                            v_dblNEWCLVALUE = v_dblVALUE
                    End Select
                End With
            Next

            v_dblOLDSECUREDRATIO = FRound(v_dblCLAMT / v_dblOLDCLVALUE * 100, 0)
            v_dblSECUREDRATIO = FRound(v_dblCLAMT / v_dblNEWCLVALUE * 100, 0)

            If Not v_blnReversal Then
                v_strSQL = "UPDATE CLMAST SET SECUREDRATIO = " & v_dblSECUREDRATIO & " WHERE ACCTNO = '" & v_strCLACCTNO & "' "
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            Else
                v_strSQL = "UPDATE CLMAST SET SECUREDRATIO = " & v_dblOLDSECUREDRATIO & " WHERE ACCTNO = '" & v_strCLACCTNO & "' "
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End If
            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function AdjustCollateralUsingValue(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = Me.ATTR_MODULE & ".Trans.AdjustCollateralUsingValue", v_strErrorMessage As String
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strSQL, v_strFLDCD, v_strFLDTYPE, v_strVALUE As String, v_dblVALUE As Double, i As Integer
        Dim v_strCLACCTNO As String
        Dim v_dblCLVALUE, v_dblNEWCLAMT, v_dblOLDCLAMT, v_dblOLDSECUREDRATIO, v_dblNEWSECUREDRATIO As Double

        Try
            Dim v_strBRID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXTIME As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTIME).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strTLTXCD As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLTXCD), Xml.XmlAttribute).Value)
            Dim v_obj As New DataAccess, v_ds As DataSet
            v_obj.NewDBInstance(gc_MODULE_HOST)
            'Doc noi dung giao dich
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields/entry")
            For i = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDCD = Trim(.Attributes(gc_AtributeFLDNAME).Value.ToString)
                    v_strFLDTYPE = Trim(.Attributes(gc_AtributeFLDTYPE).Value.ToString)
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(IsNumeric(.InnerText), CDbl(.InnerText), 0)
                    Else
                        v_strVALUE = Trim(.InnerText)
                        v_dblVALUE = 0
                    End If

                    Select Case v_strFLDCD
                        Case "03" 'CLACCTNO
                            v_strCLACCTNO = v_strVALUE
                        Case "04" 'Value
                            v_dblCLVALUE = v_dblVALUE
                        Case "05"
                            v_dblOLDCLAMT = v_dblVALUE
                        Case "10" 'AMT
                            v_dblNEWCLAMT = v_dblVALUE
                    End Select
                End With
            Next

            v_dblOLDSECUREDRATIO = FRound(v_dblOLDCLAMT / v_dblCLVALUE * 100, 0)
            v_dblNEWSECUREDRATIO = FRound(v_dblNEWCLAMT / v_dblCLVALUE * 100, 0)

            If Not v_blnReversal Then
                v_strSQL = "UPDATE CLMAST SET SECUREDRATIO = " & v_dblNEWSECUREDRATIO & " WHERE ACCTNO = '" & v_strCLACCTNO & "' "
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                'v_strSQL = "SELECT LMACCTNO, SUM(CASE WHEN DORC='C' THEN CLAMT WHEN DORC='D' THEN -CLAMT END) CLAMT " & _
                '        "FROM CLLINK WHERE CLACCTNO = '" & v_strCLACCTNO & "' " & _
                '        "GROUP BY LMACCTNO "
                'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                'If v_ds.Tables(0).Rows.Count > 0 Then
                '    Dim v_strAFACCTNO As String
                '    Dim v_dblCLAMT As Double
                '    For i = 0 To v_ds.Tables(0).Rows.Count - 1
                '        v_strAFACCTNO = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("LMACCTNO"))
                '        v_dblCLAMT = gf_CorrectNumericField(v_ds.Tables(0).Rows(i)("CLAMT"))
                '        v_strSQL = "UPDATE AFMAST SET MRCLAMT = MRCLAMT+" & FRound(v_dblCLAMT / v_dblNEWSECUREDRATIO * 100, 0) - FRound(v_dblCLAMT / v_dblOLDSECUREDRATIO * 100, 0) & " WHERE ACCTNO = '" & v_strAFACCTNO & "' "
                '        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                '    Next
                'End If
            Else
                v_strSQL = "UPDATE CLMAST SET SECUREDRATIO = " & v_dblOLDSECUREDRATIO & " WHERE ACCTNO = '" & v_strCLACCTNO & "' "
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                'v_strSQL = "SELECT LMACCTNO, SUM(CASE WHEN DORC='C' THEN CLAMT WHEN DORC='D' THEN -CLAMT END) CLAMT " & _
                '        "FROM CLLINK WHERE CLACCTNO = '" & v_strCLACCTNO & "' " & _
                '        "GROUP BY LMACCTNO "
                'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                'If v_ds.Tables(0).Rows.Count > 0 Then
                '    Dim v_strAFACCTNO As String
                '    Dim v_dblCLAMT As Double
                '    For i = 0 To v_ds.Tables(0).Rows.Count - 1
                '        v_strAFACCTNO = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("LMACCTNO"))
                '        v_dblCLAMT = gf_CorrectNumericField(v_ds.Tables(0).Rows(i)("CLAMT"))
                '        v_strSQL = "UPDATE AFMAST SET MRCLAMT = MRCLAMT+" & FRound(v_dblCLAMT / v_dblOLDSECUREDRATIO * 100, 0) - FRound(v_dblCLAMT / v_dblNEWSECUREDRATIO * 100, 0) & " WHERE ACCTNO = '" & v_strAFACCTNO & "' "
                '        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                '    Next
                'End If
            End If

            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
#End Region

#Region " Overwrite functions "

#End Region

End Class
