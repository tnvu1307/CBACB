Imports HostCommonLibrary
Imports CoreBusiness
Imports DataAccessLayer
'Imports System.EnterpriseServices
Imports System.Configuration
Imports System.Text
Imports System.IO
Imports System.Data

'TruongLD comment when convert
'<JustInTimeActivation(False), _
'Transaction(TransactionOption.RequiresNew), _
'ObjectPooling(Enabled:=True, MinPoolSize:=30)> _
Public Class txRouter
    'TruongLD comment when convert
    'Inherits ServicedComponent
    Inherits TxScope

    Dim LogError As LogError = New LogError()

#Region " Caching function "
    Private Const DEF_ACCTFLDCD = "ACCTFLDCD"
    Private Const DEF_IBT = "IBT"
    Private Const DEF_TXTYPE = "TXTYPE"
    Private Const DEF_POSTMAP = "POSTMAP"
    Private Const DEF_FLDMASTER = "XML_FLDMASTER"
    Private Const DEF_APPTYPE = "XML_APPTYPE"
    Private Const DEF_APPMAP = "XML_APPMAP"
    Private Const DEF_APPCHK = "XML_APPCHK"
    Private Const DEF_SECURITIES_INFO = "XML_SECURITIES_INFO"
    Private Const DEF_SBCURRENCY = "XML_SBCURRENCY"
    Private Const DEF_GLREF = "XML_GLREF"
    Private Const DEF_GLREFCOM = "XML_GLREFCOM"
    Private Const DEF_EMPTY_DATAXML = "<NewDataSet>  <Table> </Table>  </NewDataSet>"

    Dim mv_strCACHETLTX As String
    Dim mv_XMLBuffer As New Xml.XmlDocument
    Public Property ATTR_CACHEDATA() As String
        Get
            Return mv_strCACHETLTX
        End Get
        Set(ByVal Value As String)
            mv_strCACHETLTX = Value
        End Set
    End Property

    Private Function GetCacheData(ByVal v_strTYPEOFINFORMATION As String, Optional ByRef v_strREFVALUE As String = "") As DataSet
        Dim v_ds As DataSet, v_XMLREADER, v_XSDREADER As System.IO.StringReader, v_XMLNODE As Xml.XmlNode, v_XMLDOCUMENT As Xml.XmlDocument
        Try
            Dim v_strRETURN, v_strSCHEMA As String
            If ATTR_CACHEDATA.Length > 0 Then
                Select Case v_strTYPEOFINFORMATION
                    Case DEF_ACCTFLDCD
                        v_strRETURN = mv_XMLBuffer.SelectSingleNode("/ObjectBuffer/ACCTFLDCD").InnerText
                        v_strREFVALUE = v_strRETURN

                    Case DEF_IBT
                        v_strRETURN = mv_XMLBuffer.SelectSingleNode("/ObjectBuffer/IBT").InnerText
                        v_strREFVALUE = v_strRETURN

                    Case DEF_TXTYPE
                        v_strRETURN = mv_XMLBuffer.SelectSingleNode("/ObjectBuffer/TXTYPE").InnerText
                        v_strREFVALUE = v_strRETURN

                    Case DEF_POSTMAP
                        v_strSCHEMA = mv_XMLBuffer.SelectSingleNode("/ObjectBuffer/POSTMAP_IBT_XSD").InnerText
                        Select Case v_strREFVALUE
                            Case "0"
                                v_strRETURN = mv_XMLBuffer.SelectSingleNode("/ObjectBuffer/POSTMAP_IBT_0").InnerText
                            Case "1"
                                v_strRETURN = mv_XMLBuffer.SelectSingleNode("/ObjectBuffer/POSTMAP_IBT_1").InnerText
                            Case "2"
                                v_strRETURN = mv_XMLBuffer.SelectSingleNode("/ObjectBuffer/POSTMAP_IBT_2").InnerText
                            Case "3"
                                v_strRETURN = mv_XMLBuffer.SelectSingleNode("/ObjectBuffer/POSTMAP_IBT_3").InnerText
                        End Select
                        If v_strRETURN Is Nothing Or v_strRETURN.Length = 0 Then
                            v_strRETURN = DEF_EMPTY_DATAXML
                        End If
                        v_XMLREADER = New System.IO.StringReader(v_strRETURN)
                        v_XSDREADER = New System.IO.StringReader(v_strSCHEMA)
                        If v_ds Is Nothing Then v_ds = New DataSet
                        v_ds.Tables.Clear()
                        v_ds.ReadXmlSchema(v_XSDREADER)
                        v_ds.ReadXml(v_XMLREADER)
                        If v_strRETURN = DEF_EMPTY_DATAXML Then
                            v_ds.Tables(0).Clear()
                        End If

                    Case DEF_FLDMASTER
                        v_strSCHEMA = mv_XMLBuffer.SelectSingleNode("/ObjectBuffer/FLDMASTER_XSD").InnerText
                        v_strRETURN = mv_XMLBuffer.SelectSingleNode("/ObjectBuffer/FLDMASTER").InnerText
                        If v_strRETURN Is Nothing Or v_strRETURN.Length = 0 Then
                            v_strRETURN = DEF_EMPTY_DATAXML
                        End If
                        v_XMLREADER = New System.IO.StringReader(v_strRETURN)
                        v_XSDREADER = New System.IO.StringReader(v_strSCHEMA)
                        If v_ds Is Nothing Then v_ds = New DataSet
                        v_ds.Tables.Clear()
                        v_ds.ReadXml(v_XMLREADER)
                        If v_strRETURN = DEF_EMPTY_DATAXML Then
                            v_ds.Tables(0).Clear()
                        End If
                    Case DEF_APPMAP
                        v_strSCHEMA = mv_XMLBuffer.SelectSingleNode("/ObjectBuffer/APPMAP_XSD").InnerText
                        v_strRETURN = mv_XMLBuffer.SelectSingleNode("/ObjectBuffer/APPMAP").InnerText
                        If v_strRETURN Is Nothing Or v_strRETURN.Length = 0 Then
                            v_strRETURN = DEF_EMPTY_DATAXML
                        End If
                        v_XMLREADER = New System.IO.StringReader(v_strRETURN)
                        v_XSDREADER = New System.IO.StringReader(v_strSCHEMA)
                        If v_ds Is Nothing Then v_ds = New DataSet
                        v_ds.Tables.Clear()
                        v_ds.ReadXmlSchema(v_XSDREADER)
                        v_ds.ReadXml(v_XMLREADER)
                        If v_strRETURN = DEF_EMPTY_DATAXML Then
                            v_ds.Tables(0).Clear()
                        End If
                    Case DEF_APPCHK
                        v_strSCHEMA = mv_XMLBuffer.SelectSingleNode("/ObjectBuffer/APPCHK_XSD").InnerText
                        v_strRETURN = mv_XMLBuffer.SelectSingleNode("/ObjectBuffer/APPCHK").InnerText
                        If v_strRETURN Is Nothing Or v_strRETURN.Length = 0 Then
                            v_strRETURN = DEF_EMPTY_DATAXML
                        End If
                        v_XMLREADER = New System.IO.StringReader(v_strRETURN)
                        v_XSDREADER = New System.IO.StringReader(v_strSCHEMA)
                        If v_ds Is Nothing Then v_ds = New DataSet
                        v_ds.Tables.Clear()
                        v_ds.ReadXmlSchema(v_XSDREADER)
                        v_ds.ReadXml(v_XMLREADER)
                        If v_strRETURN = DEF_EMPTY_DATAXML Then
                            v_ds.Tables(0).Clear()
                        End If
                    Case DEF_APPTYPE
                        v_strSCHEMA = mv_XMLBuffer.SelectSingleNode("/ObjectBuffer/APPTYPE_XSD").InnerText
                        v_strRETURN = mv_XMLBuffer.SelectSingleNode("/ObjectBuffer/APPTYPE").InnerText
                        If v_strRETURN Is Nothing Or v_strRETURN.Length = 0 Then
                            v_strRETURN = DEF_EMPTY_DATAXML
                        End If
                        v_XMLREADER = New System.IO.StringReader(v_strRETURN)
                        v_XSDREADER = New System.IO.StringReader(v_strSCHEMA)
                        If v_ds Is Nothing Then v_ds = New DataSet
                        v_ds.Tables.Clear()
                        v_ds.ReadXmlSchema(v_XSDREADER)
                        v_ds.ReadXml(v_XMLREADER)
                        If v_strRETURN = DEF_EMPTY_DATAXML Then
                            v_ds.Tables(0).Clear()
                        End If
                    Case DEF_SECURITIES_INFO
                        'v_strREFVALUE is CODEID
                        v_strRETURN = mv_XMLBuffer.SelectSingleNode("/ObjectBuffer/SECURITIES_INFO").InnerText
                        v_XMLREADER = New System.IO.StringReader(v_strRETURN)

                    Case DEF_SBCURRENCY
                        'v_strREFVALUE is CCYCD
                        v_strRETURN = mv_XMLBuffer.SelectSingleNode("/ObjectBuffer/SBCURRENCY").InnerText
                        v_XMLDOCUMENT = New Xml.XmlDocument
                        v_XMLDOCUMENT.LoadXml(v_strRETURN)
                        v_strRETURN = String.Empty
                        For Each v_XMLNODE In v_XMLDOCUMENT.SelectNodes("/NewDataSet/Table")
                            If v_XMLNODE.SelectSingleNode("CCYCD").InnerText = v_strREFVALUE Then
                                v_strRETURN = v_XMLNODE.SelectSingleNode("CCYDECIMAL").InnerText
                                Exit For
                            End If
                        Next
                        v_strREFVALUE = v_strRETURN

                    Case DEF_GLREF
                        'v_strREFVALUE is GLGRP
                        v_strRETURN = mv_XMLBuffer.SelectSingleNode("/ObjectBuffer/GLREF").InnerText
                        v_XMLDOCUMENT = New Xml.XmlDocument
                        v_XMLDOCUMENT.LoadXml(v_strRETURN)
                        v_strRETURN = String.Empty
                        For Each v_XMLNODE In v_XMLDOCUMENT.SelectNodes("/NewDataSet/Table")
                            If v_XMLNODE.SelectSingleNode("REFKEY").InnerText = v_strREFVALUE Then
                                If v_XMLNODE.SelectSingleNode("ACCTNO") Is Nothing Then
                                    v_strRETURN = ""
                                Else
                                    v_strRETURN = v_XMLNODE.SelectSingleNode("ACCTNO").InnerText
                                End If
                                Exit For
                            End If
                        Next
                        v_strREFVALUE = v_strRETURN

                    Case DEF_GLREFCOM
                        'v_strREFVALUE is ACNAME
                        v_strRETURN = mv_XMLBuffer.SelectSingleNode("/ObjectBuffer/GLREFCOM").InnerText
                        v_XMLDOCUMENT = New Xml.XmlDocument
                        v_XMLDOCUMENT.LoadXml(v_strRETURN)
                        v_strRETURN = String.Empty
                        For Each v_XMLNODE In v_XMLDOCUMENT.SelectNodes("/NewDataSet/Table")
                            If v_XMLNODE.SelectSingleNode("ACNAME").InnerText = v_strREFVALUE Then
                                v_strRETURN = v_XMLNODE.SelectSingleNode("ACCTNO").InnerText
                                Exit For
                            End If
                        Next
                        v_strREFVALUE = v_strRETURN

                End Select

                Return v_ds
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        Finally
            If Not v_ds Is Nothing Then
                v_ds.Dispose()
            End If
        End Try
    End Function
#End Region

#Region " Processing function "
    Private Function GetReferenceValueForAMTEXP(ByRef pv_xmlDocument As Xml.XmlDocument, ByVal pv_strREFVAL As String) As String
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.txRouter.GetReferenceValueForAMTEXP", v_strErrorMessage As String
        Dim v_DataAccess As New DataAccess, v_ds, v_dsACTYPE As DataSet
        Dim v_strVALUE As String, v_nodetxData As Xml.XmlNode, v_objEval As New Evaluator
        Try
            v_DataAccess.NewDBInstance(gc_MODULE_HOST)
            If Len(pv_strREFVAL) > 0 Then
                If Left(pv_strREFVAL, 1) = "@" Then
                    v_strVALUE = Mid(pv_strREFVAL, 2)
                ElseIf Left(pv_strREFVAL, 1) = "$" Or Left(pv_strREFVAL, 1) = "#" Then
                    'Get field code
                    v_strVALUE = Mid(pv_strREFVAL, 2)
                    'Get field value
                    v_nodetxData = pv_xmlDocument.SelectSingleNode("TransactMessage/fields/entry[@fldname='" & v_strVALUE & "']")
                    v_strVALUE = v_nodetxData.InnerText
                ElseIf pv_strREFVAL = "<$BUSDATE>" Then
                    'Get business date
                    v_lngErrCode = v_DataAccess.GetSysVar("SYSTEM", "CURRDATE", v_strVALUE)
                ElseIf pv_strREFVAL = "<$TXDATE>" Then
                    'Get business date
                    v_lngErrCode = v_DataAccess.GetSysVar("SYSTEM", "CURRDATE", v_strVALUE)
                ElseIf pv_strREFVAL = "<$COMPANYNAME>" Then
                    'Get business date
                    v_lngErrCode = v_DataAccess.GetSysVar("SYSTEM", "COMPANYNAME", v_strVALUE)
                Else
                    'Armethic expression
                    v_strVALUE = v_objEval.Eval(BuildAMTEXP(pv_xmlDocument, pv_strREFVAL)).ToString
                End If
            End If
            Return v_strVALUE
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        Finally
            v_objEval = Nothing
            v_DataAccess = Nothing
        End Try

    End Function

    Private Function CheckSend2Bank(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_DataAccess As New DataAccess, v_ds, v_dsTMP, v_dsREF As DataSet
        v_DataAccess.NewDBInstance(gc_MODULE_HOST)
        Dim v_strSQL As String
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.txRouter.CheckProcess2Bank", v_strErrorMessage As String
        Dim v_xmlMessage As New Xml.XmlDocument, v_nodetxData As Xml.XmlNode
        Dim v_objEval As New Evaluator
        Dim i, v_nRow As Integer, v_strTLTXCD, v_strTLID, v_strBRID, v_strDELTD, v_strSTATUS, v_strTXDATE, v_strTXNUM, v_strREFAUTOID, v_strREFVAL As String
        Dim v_strOBJTYPE, v_strTRFCODE, v_strTRFCODEORG, v_strFLDBANK, v_strFLDACCTNO, v_strFLDBANKACCT, v_strFLDREFCODE, v_strFLDNOTES, v_strAMTEXP,
            v_strBANK, v_strAFACCTNO, v_strBANKACCT, v_strREFCODE, v_strFLDAFFECTDATE, v_strAFFECTDATE, v_strNOTES, v_strVALUE As String
        Dim v_strFLDNAME, v_strFLDTYPE As String
        Try
            v_strTLTXCD = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value.ToString
            v_strTLID = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTLID).Value.ToString
            v_strBRID = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value.ToString
            v_strTXDATE = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value.ToString
            v_strTXNUM = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value.ToString
            v_strDELTD = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value.ToString
            v_strSTATUS = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeSTATUS).Value.ToString
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False
            If v_strSTATUS = TransactStatus.Deleting Then
                v_blnReversal = True
            End If

            v_strSQL = "SELECT OBJTYPE, OBJNAME, TRFCODE, FLDBANK, FLDACCTNO, FLDBANKACCT, FLDREFCODE,AFFECTDATE, FLDNOTES, AMTEXP " &
                "FROM CRBTXMAP MST WHERE MST.OBJTYPE = 'T' AND MST.OBJNAME = '" & v_strTLTXCD & "'"
            v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                If Not v_blnReversal Then
                    'Một giao dịch cho phép khai báo tạo ra nhiều hơn một bảng kê
                    For v_nRow = 0 To v_ds.Tables(0).Rows.Count - 1 Step 1
                        'Ghi nhận vào bảng CRBTXREQ
                        v_strOBJTYPE = gf_CorrectStringField(v_ds.Tables(0).Rows(v_nRow)("OBJTYPE")).Trim
                        v_strTRFCODE = gf_CorrectStringField(v_ds.Tables(0).Rows(v_nRow)("TRFCODE")).Trim
                        v_strFLDBANK = gf_CorrectStringField(v_ds.Tables(0).Rows(v_nRow)("FLDBANK")).Trim
                        v_strFLDACCTNO = gf_CorrectStringField(v_ds.Tables(0).Rows(v_nRow)("FLDACCTNO")).Trim
                        v_strFLDBANKACCT = gf_CorrectStringField(v_ds.Tables(0).Rows(v_nRow)("FLDBANKACCT")).Trim
                        v_strFLDREFCODE = gf_CorrectStringField(v_ds.Tables(0).Rows(v_nRow)("FLDREFCODE")).Trim
                        v_strFLDAFFECTDATE = gf_CorrectStringField(v_ds.Tables(0).Rows(v_nRow)("AFFECTDATE")).Trim
                        v_strFLDNOTES = gf_CorrectStringField(v_ds.Tables(0).Rows(v_nRow)("FLDNOTES")).Trim
                        v_strAMTEXP = gf_CorrectStringField(v_ds.Tables(0).Rows(v_nRow)("AMTEXP")).Trim
                        v_strTRFCODEORG = v_strTRFCODE

                        If v_strFLDREFCODE.Length = 0 Then
                            v_strREFCODE = v_strTXDATE & v_strTXNUM
                        Else
                            v_strREFCODE = GetReferenceValueForAMTEXP(pv_xmlDocument, v_strFLDREFCODE)
                        End If

                        If String.IsNullOrEmpty(v_strFLDAFFECTDATE) OrElse v_strFLDAFFECTDATE = "<$TXDATE>" Then
                            v_strAFFECTDATE = v_strTXDATE
                        Else
                            v_strAFFECTDATE = GetReferenceValueForAMTEXP(pv_xmlDocument, v_strFLDAFFECTDATE)
                        End If

                        'Trong truong hop mot giao dich co nhieu ma trfcode thi phai lay lai trfcode do
                        If Left(v_strTRFCODE, 1) = "$" Then
                            'Lấy trfcode theo giá trị lựa chọn trên màn hình giao dịch
                            v_strTRFCODE = GetReferenceValueForAMTEXP(pv_xmlDocument, v_strTRFCODE)
                        End If

                        v_strBANK = GetReferenceValueForAMTEXP(pv_xmlDocument, v_strFLDBANK)
                        If Left(v_strFLDBANK, 1) = "#" Then
                            'Phải gọi hàm để xác định bổ xung: Dùng cho bảng kê lưu ký
                            v_strSQL = "SELECT FN_CRB_GETBANKCODEBYTRFCODE('" & v_strTRFCODE & "','" & v_strBANK & "') BANKCODE FROM DUAL"
                            v_dsTMP = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                            If v_dsTMP.Tables(0).Rows.Count > 0 Then
                                v_strBANK = gf_CorrectStringField(v_dsTMP.Tables(0).Rows(0)("BANKCODE")).Trim
                            End If
                        End If

                        v_strBANKACCT = GetReferenceValueForAMTEXP(pv_xmlDocument, v_strFLDBANKACCT)
                        v_strAFACCTNO = GetReferenceValueForAMTEXP(pv_xmlDocument, v_strFLDACCTNO)
                        v_strNOTES = GetReferenceValueForAMTEXP(pv_xmlDocument, v_strFLDNOTES)
                        v_strVALUE = GetReferenceValueForAMTEXP(pv_xmlDocument, v_strAMTEXP)

                        'TungNT modified - skip when bankcode or bank account is null or empty
                        If Not String.IsNullOrEmpty(v_strBANK) AndAlso Not String.IsNullOrEmpty(v_strBANKACCT) Then
                            'Ghi nhận yêu cầu
                            v_strREFAUTOID = v_DataAccess.GetIDValue("CRBTXREQ")
                            v_strSQL = "INSERT INTO CRBTXREQ (REQID, OBJTYPE, OBJNAME, OBJKEY, TRFCODE, REFCODE, TXDATE, AFFECTDATE, AFACCTNO, TXAMT, BANKCODE, BANKACCT, STATUS, REFVAL, NOTES) " & ControlChars.CrLf _
                                & "VALUES (" & v_strREFAUTOID & ", 'T', '" & v_strTLTXCD & "', '" & v_strTXNUM & "', '" & v_strTRFCODE & "', '" & v_strREFCODE & "', TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'), TO_DATE('" & v_strAFFECTDATE & "', '" & gc_FORMAT_DATE & "')," _
                                & "'" & v_strAFACCTNO & "', " & v_strVALUE & ", '" & v_strBANK & "', '" & v_strBANKACCT & "', 'P', NULL, '" & v_strNOTES & "')"
                            v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)

                            'Ghi nhận vào bảng CRBTXREQDTL
                            v_strSQL = "SELECT OBJTYPE, OBJNAME, TRFCODE, FLDNAME, FLDTYPE, AMTEXP, CMDSQL " &
                                "FROM CRBTXMAPEXT MST WHERE MST.OBJTYPE ='T' AND MST.OBJNAME = '" & v_strTLTXCD & "' AND TRFCODE='" & v_strTRFCODEORG & "'"
                            v_dsTMP = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                            If v_dsTMP.Tables(0).Rows.Count > 0 Then
                                For i = 0 To v_dsTMP.Tables(0).Rows.Count - 1 Step 1
                                    v_strFLDNAME = gf_CorrectStringField(v_dsTMP.Tables(0).Rows(i)("FLDNAME")).Trim
                                    v_strFLDTYPE = gf_CorrectStringField(v_dsTMP.Tables(0).Rows(i)("FLDTYPE")).Trim
                                    v_strAMTEXP = gf_CorrectStringField(v_dsTMP.Tables(0).Rows(i)("AMTEXP")).Trim
                                    v_strSQL = gf_CorrectStringField(v_dsTMP.Tables(0).Rows(i)("CMDSQL")).Trim
                                    If Len(v_strAMTEXP) > 0 Then
                                        If Left(v_strAMTEXP, 1) = "@" Then
                                            'Lấy trực tiếp giá trị
                                            v_strVALUE = Mid(v_strAMTEXP, 2)
                                        ElseIf Left(v_strAMTEXP, 1) = "$" Then
                                            'Get field code
                                            v_strVALUE = Mid(v_strAMTEXP, 2)
                                            'Get field value
                                            v_nodetxData = pv_xmlDocument.SelectSingleNode("TransactMessage/fields/entry[@fldname='" & v_strVALUE & "']")
                                            v_strVALUE = v_nodetxData.InnerText
                                        ElseIf v_strAMTEXP = "<$BUSDATE>" Then
                                            'Get business date
                                            v_strVALUE = v_strTXDATE
                                        Else
                                            'Math expression
                                            If v_strFLDTYPE = "N" Then
                                                v_strAMTEXP = BuildAMTEXP(pv_xmlDocument, v_strAMTEXP)
                                                v_strVALUE = v_objEval.Eval(v_strAMTEXP).ToString
                                            End If
                                        End If
                                    End If

                                    'Lấy theo tham chiếu dữ liệu
                                    If v_strSQL.Length > 0 Then
                                        v_strSQL = v_strSQL.Replace("<$FILTERID>", v_strVALUE)
                                        v_dsREF = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                                        If v_dsREF.Tables(0).Rows.Count > 0 Then
                                            v_strVALUE = gf_CorrectStringField(v_dsREF.Tables(0).Rows(0)(0)).Trim
                                        End If
                                    End If

                                    'Ghi nhận dữ liệu
                                    v_strSQL = "INSERT INTO CRBTXREQDTL (AUTOID, REQID, FLDNAME, CVAL, NVAL) " & ControlChars.CrLf _
                                        & "SELECT SEQ_CRBTXREQDTL.NEXTVAL, " & v_strREFAUTOID & ", '" & v_strFLDNAME & "', '" & IIf(v_strFLDTYPE = "N", "", v_strVALUE) & "', " _
                                        & IIf(v_strFLDTYPE = "N", v_strVALUE, 0) & " FROM DUAL"
                                    v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)
                                Next
                            End If
                        End If
                    Next
                Else
                    'Không cho xóa nếu yêu cầu đã được đưa vào bảng kê ở trạng thái chờ duyệt/duyệt/gửi/xử lý mà không bị lỗi
                    v_strSQL = "SELECT MST.REQID FROM CRBTXREQ MST, CRBTRFLOGDTL DTL WHERE MST.REQID=DTL.REFREQID AND DTL.STATUS IN ('P', 'A', 'C') " _
                        & "AND MST.OBJNAME='" & v_strTLTXCD & "' AND MST.OBJKEY='" & v_strTXNUM & "' AND MST.TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')"
                    v_dsTMP = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_dsTMP.Tables(0).Rows.Count > 0 Then
                        Rollback()
                        'Không cho phép xóa nếu yêu cầu bảng kê đã 
                        Return ERR_CRBTRFLOG_CONTAINT_CRBTXREQ
                    Else
                        'Xóa yêu cầu chi tiết
                        If v_strDELTD = "Y" Then
                            v_strSQL = "DELETE FROM CRBTXREQDTL WHERE REQID IN " _
                                & "(SELECT REQID FROM CRBTXREQ MST WHERE MST.OBJNAME='" & v_strTLTXCD & "' AND MST.OBJKEY='" & v_strTXNUM & "' AND MST.TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'))"
                            v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)
                            v_strSQL = "DELETE FROM CRBTXREQ WHERE OBJNAME='" & v_strTLTXCD & "' AND OBJKEY='" & v_strTXNUM & "' AND TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')"
                            v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)
                        End If
                    End If
                End If
            End If

            Complete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback()
            LogError.WriteException(ex)
            Throw ex
        Finally
            v_objEval = Nothing
        End Try
    End Function

    Private Function CheckACTYPEMap(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_DataAccess As New DataAccess, v_ds, v_dsACTYPE As DataSet
        v_DataAccess.NewDBInstance(gc_MODULE_HOST)
        Dim v_strSQL As String
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.txRouter.CheckACTYPEMap", v_strErrorMessage As String
        Dim v_strxmlMessage As String, v_xmlMessage As New Xml.XmlDocument, v_nodetxData As Xml.XmlNode
        Dim v_strTLTXCD, v_strCHKTYPE, v_strMODCODE, v_strFLDACTYPE, v_strREFMODFLDCD, v_strREFFLDCD, v_strTBLPRODUCT, v_strREFFIELD, v_strACTYPE, v_strAFTYPE As String
        Try
            v_strTLTXCD = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value.ToString
            v_strSQL = "SELECT TLTXCD, CHKTYPE, MODCODE, FLDACTYPE, REFMODFLDCD, REFFLDCD FROM ACTYPEMAP WHERE TLTXCD ='" & v_strTLTXCD & "'"
            v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To v_ds.Tables(0).Rows.Count - 1 Step 1
                    'Lấy tham số cài đặt
                    v_strCHKTYPE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("CHKTYPE"))).Trim
                    v_strMODCODE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("MODCODE"))).Trim
                    v_strFLDACTYPE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("FLDACTYPE"))).Trim
                    v_strREFMODFLDCD = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("REFMODFLDCD"))).Trim
                    v_strREFFLDCD = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("REFFLDCD"))).Trim

                    'Lấy tên bảng loại hình nghiệp vụ
                    v_strTBLPRODUCT = v_strMODCODE.Trim & "TYPE"
                    'Mã loại hình nghiệp vụ
                    v_strACTYPE = pv_xmlDocument.SelectSingleNode("TransactMessage/fields/entry[@fldname='" & v_strFLDACTYPE & "']").InnerText
                    'xác định thông tin cẩn kiểm tra (user, chi nhánh or tiểu khoản giao dịch
                    v_strREFFIELD = ""
                    Select Case v_strREFFLDCD
                        Case "<$BRID>"
                            v_strREFFIELD = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value.ToString
                        Case "<$TLID>"
                            v_strREFFIELD = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTLID).Value.ToString
                        Case Else
                            'Lấy trực tiếp từ điện giao dịch (chỉ dùng cho v_strCHKTYPE=A)
                            v_strREFFIELD = pv_xmlDocument.SelectSingleNode("TransactMessage/fields/entry[@fldname='" & v_strREFFLDCD & "']").InnerText
                    End Select

                    'Thực hiện kiểm tra
                    Select Case v_strCHKTYPE
                        Case "B"    'Branch (sub-branch included)
                            'Kiểm tra bảng BRIDTYPE xem có được phân quyền sử dụng không: sub-branch và cấp trên
                            v_strSQL = "SELECT COUNT(*) FROM BRIDTYPE " & ControlChars.CrLf _
                                & "WHERE ACTYPE ='" & v_strACTYPE & "' AND OBJNAME='" & v_strMODCODE & "." & v_strTBLPRODUCT & "' " & ControlChars.CrLf _
                                & "AND (BRID='" & v_strREFFIELD & "' OR BRID='" & v_strREFFIELD.Substring(0, 2) & "01')"
                            v_dsACTYPE = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                            If v_dsACTYPE.Tables(0).Rows(0)(0) = 0 Then
                                'Lỗi không được phân quyền sử dụng theo chi nhánh
                                v_lngErrCode = ERR_SA_PRODUCT_INVALID_BRANCH
                                Return v_lngErrCode
                            End If
                        Case "S"    'Sub-branch
                            'Kiểm tra bảng BRIDTYPE xem có được phân quyền sử dụng không: sub-branch only
                            v_strSQL = "SELECT COUNT(*) FROM BRIDTYPE " & ControlChars.CrLf _
                                & "WHERE ACTYPE ='" & v_strACTYPE & "' AND OBJNAME='" & v_strMODCODE & "." & v_strTBLPRODUCT & "' " & ControlChars.CrLf _
                                & "AND (BRID='" & v_strREFFIELD & "')"
                            v_dsACTYPE = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                            If v_dsACTYPE.Tables(0).Rows(0)(0) = 0 Then
                                'Lỗi không được phân quyền sử dụng theo chi nhánh
                                v_lngErrCode = ERR_SA_PRODUCT_INVALID_SUB_BRANCH
                                Return v_lngErrCode
                            End If
                        Case "A"    'Sub-account (AFTYPE)
                            'Kiểm tra bảng AFIDTYPE xem có được phân quyền sử dụng không
                            v_strAFTYPE = ""
                            'Xác định loại hình sub-account của khách hàng
                            If String.Compare(v_strREFMODFLDCD, "AF") = 0 Then
                                'Nếu là AFMAST
                                v_strSQL = "SELECT ACTYPE FROM AFMAST WHERE ACCTNO='" & v_strREFFIELD & "'"
                                v_dsACTYPE = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                                If v_dsACTYPE.Tables(0).Rows.Count > 0 Then
                                    v_strAFTYPE = Trim(gf_CorrectStringField(v_dsACTYPE.Tables(0).Rows(0)("ACTYPE"))).Trim
                                Else
                                    v_lngErrCode = ERR_SA_PRODUCT_INVALID_AFTYPE
                                    Return v_lngErrCode
                                End If
                            Else
                                'Nếu là phân hệ nghiệp vụ
                                v_strSQL = "SELECT MST.ACTYPE FROM AFMAST MST, " & v_strREFMODFLDCD & "MAST REFDTL WHERE REFDTL.AFACCTNO=MST.ACCTNO AND REFDTL.ACCTNO='" & v_strREFFIELD & "'"
                                v_dsACTYPE = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                                If v_dsACTYPE.Tables(0).Rows.Count > 0 Then
                                    v_strAFTYPE = Trim(gf_CorrectStringField(v_dsACTYPE.Tables(0).Rows(0)("ACTYPE"))).Trim
                                Else
                                    v_lngErrCode = ERR_SA_PRODUCT_INVALID_AFTYPE
                                    Return v_lngErrCode
                                End If
                            End If
                            'Xác định phân quyền theo loại hình sub-account của khách hàng
                            If v_lngErrCode = ERR_SYSTEM_OK And v_strAFTYPE.Length > 0 Then
                                v_strSQL = "SELECT COUNT(*) FROM AFIDTYPE " & ControlChars.CrLf _
                                    & "WHERE ACTYPE ='" & v_strACTYPE & "' AND OBJNAME='" & v_strMODCODE & "." & v_strTBLPRODUCT & "' " & ControlChars.CrLf _
                                    & "AND AFTYPE='" & v_strAFTYPE & "'"
                                v_dsACTYPE = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                                If v_dsACTYPE.Tables(0).Rows(0)(0) = 0 Then
                                    'Lỗi không được phân quyền sử dụng theo loại hình
                                    v_lngErrCode = ERR_SA_PRODUCT_INVALID_AFTYPE
                                    Return v_lngErrCode
                                End If
                            End If
                        Case "T"    'User & Group
                            v_strSQL = "SELECT COUNT(*) FROM TLIDTYPE " & ControlChars.CrLf _
                                & "WHERE ACTYPE ='" & v_strACTYPE & "' AND OBJNAME='" & v_strMODCODE & "." & v_strTBLPRODUCT & "' " & ControlChars.CrLf _
                                & "AND ((TLTYPE='U' AND TLCODE='" & v_strREFFIELD & "') " & ControlChars.CrLf _
                                & " OR (TLTYPE='G' AND TLCODE IN (SELECT GRPID FROM TLGRPUSERS WHERE TLID='" & v_strREFFIELD & "')))"
                            v_dsACTYPE = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                            If v_dsACTYPE.Tables(0).Rows(0)(0) = 0 Then
                                'Lỗi không được phân quyền sử dụng theo người sử dụng
                                v_lngErrCode = ERR_SA_PRODUCT_INVALID_USER
                                Return v_lngErrCode
                            End If
                    End Select

                Next
            End If
            Return v_lngErrCode
            Complete()
        Catch ex As Exception
            Rollback()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function OLOrderTransact(ByRef pv_strMessage As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.txRouter.Transact" ', v_strErrorMessage As String
        Dim v_strStoredName As String
        Try

            Dim v_DataAccess As New DataAccess, v_ds As DataSet
            v_DataAccess.NewDBInstance(gc_MODULE_HOST)

            v_strStoredName = "TXPKS_OLORDER.fn_onlineorder"
            Dim v_objParam As New StoreParameter
            Dim v_arrPara(3) As StoreParameter

            v_objParam.ParamName = "return"
            v_objParam.ParamDirection = ParameterDirection.ReturnValue
            v_objParam.ParamValue = 0
            v_objParam.ParamSize = 100
            v_objParam.ParamType = GetType(Double).Name
            v_arrPara(0) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_xmlmsg"
            v_objParam.ParamValue = pv_strMessage
            v_objParam.ParamDirection = ParameterDirection.InputOutput
            v_objParam.ParamSize = 32000
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(1) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_err_code"
            v_objParam.ParamDirection = ParameterDirection.Output
            v_objParam.ParamValue = ""
            v_objParam.ParamSize = 100
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(2) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_err_param"
            v_objParam.ParamDirection = ParameterDirection.Output
            v_objParam.ParamValue = ""
            v_objParam.ParamSize = 300
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(3) = v_objParam

            pv_strMessage = v_DataAccess.ExecuteOracleStored(v_strStoredName, v_arrPara, 1)

            If Not IsNumeric(v_arrPara(2).ParamValue) Then
                v_lngErrCode = 0
            Else
                v_lngErrCode = CDec(v_arrPara(2).ParamValue)
            End If
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            End If
            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function Transact(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_DataAccess As New DataAccess, v_ds As DataSet
        v_DataAccess.NewDBInstance(gc_MODULE_HOST)
        Dim v_strSQL As String
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.txRouter.Transact", v_strErrorMessage As String
        Dim v_strxmlMessage As String, v_xmlMessage As New Xml.XmlDocument
        Dim v_strRUNMOD, v_strCHKBKDATE As String
        Try
            'Xu ly kiem tra BackDate
            Dim v_strMAXDAYS, v_strCURRDATE As String
            v_DataAccess.NewDBInstance(gc_MODULE_HOST)

            v_lngErrCode = v_DataAccess.GetSysVar("SYSTEM", "MAX_BACKDATE_DAYS", v_strMAXDAYS)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            End If

            'Get message header
            Dim v_intSTATUS As Integer = CInt(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeSTATUS).Value.ToString)
            Dim v_strDELTD As String = Trim(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value.ToString)

            Dim v_strBUSDATE As String = Trim(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBUSDATE).Value.ToString)
            Dim v_strTXDATE As String = Trim(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value.ToString)
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            If v_strBUSDATE.Length = 0 Then v_strBUSDATE = v_strTXDATE
            If DateDiff(DateInterval.Day, DDMMYYYY_SystemDate(v_strBUSDATE), DDMMYYYY_SystemDate(v_strTXDATE)) > v_strMAXDAYS Then
                Rollback() 'ContextUtil.SetAbort()
                Return ERR_SA_INVALID_BACKDATE
            End If

            Dim v_strTLTXCD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value.ToString
            Try
                v_strSQL = "SELECT RUNMOD,CHKBKDATE FROM TLTX WHERE TLTXCD ='" & v_strTLTXCD & "'"
                v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                v_strRUNMOD = v_ds.Tables(0).Rows(0)("RUNMOD")
                v_strCHKBKDATE = v_ds.Tables(0).Rows(0)("CHKBKDATE")

            Catch ex As Exception
                v_strRUNMOD = "NET"
                v_strCHKBKDATE = "N"
            End Try

            'Kiểm tra giao dịch có cài đặt tham số phân quyền loại hình không
            v_lngErrCode = CheckACTYPEMap(pv_xmlDocument)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback()
                Return v_lngErrCode
            End If

            'Kiểm tra giao dịch có cài đặt tham số phân quyền loại hình không
            v_lngErrCode = CheckTLTXBRMap(pv_xmlDocument)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback()
                Return v_lngErrCode
            End If

            'Kiem tra neu giao dich phai duyet rui ro backdate thi canh bao Duyet rui ro
            If v_strCHKBKDATE = "Y" And v_strBUSDATE <> v_strTXDATE Then
                v_strOVRRQD = v_strOVRRQD & OVRRQS_TRAN_BACKDATE
                pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value = v_strOVRRQD
            End If
            'Xoa giao dich bao gio cung phai yeu cau Duyet
            If v_strDELTD <> MSGTRANS_DELETED And v_intSTATUS = TransactStatus.Deleting Then
                If v_strOVRRQD Is Nothing Or Len(v_strOVRRQD) = 0 Then
                    pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value = gc_OFFID_OVRRQS
                End If
            End If
            If v_strRUNMOD = "DB" Then
                v_lngErrCode = DBTransact(pv_xmlDocument)
            Else
                v_lngErrCode = NETTransact(pv_xmlDocument)
            End If


            If v_lngErrCode <> ERR_SYSTEM_OK And v_lngErrCode <> ERR_SA_CHECKER1_OVR And v_lngErrCode <> ERR_SA_CHECKER2_OVR Then
                Rollback()
                'Else
                '    If v_strRUNMOD <> "DB" Then
                '        'Xử lý ghi nhận yêu cầu tạo bảng kê với luống NET. Luồng DB đã tự GEN.
                '        If pv_xmlDocument.DocumentElement.Attributes(gc_AtributeSTATUS).InnerXml = TransactStatus.Completed Or _
                '            pv_xmlDocument.DocumentElement.Attributes(gc_AtributeSTATUS).InnerXml = TransactStatus.Deleting Then
                '            v_lngErrCode = CheckSend2Bank(pv_xmlDocument)
                '            If v_lngErrCode <> ERR_SYSTEM_OK Then
                '                Rollback()
                '            Else
                '                Complete() 'ContextUtil.SetComplete()
                '            End If
                '        Else
                '            Complete() 'ContextUtil.SetComplete()
                '        End If
                '    End If
            End If
            Return v_lngErrCode

        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function DBTransact(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.txRouter.Transact" ', v_strErrorMessage As String
        Dim v_strStoredName As String
        Dim v_xmlMessage As New Xml.XmlDocument
        Dim v_strMessage As String
        Try
            v_strMessage = pv_xmlDocument.InnerXml

            Dim v_DataAccess As New DataAccess, v_ds As DataSet
            v_DataAccess.NewDBInstance(gc_MODULE_HOST)
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            v_strStoredName = Convert.ToString(CType(v_attrColl.GetNamedItem(gc_AtributeTLTXCD), Xml.XmlAttribute).Value)
            v_strStoredName = "txpks_#" + v_strStoredName + ".fn_txprocess"
            Dim v_objParam As New StoreParameter
            Dim v_arrPara(3) As StoreParameter

            v_objParam.ParamName = "return"
            v_objParam.ParamDirection = ParameterDirection.ReturnValue
            v_objParam.ParamValue = 0
            v_objParam.ParamSize = 100
            v_objParam.ParamType = GetType(Double).Name
            v_arrPara(0) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "l_xmlmsg"
            v_objParam.ParamValue = v_strMessage
            v_objParam.ParamDirection = ParameterDirection.InputOutput
            v_objParam.ParamSize = 32000
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(1) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_err_code"
            v_objParam.ParamDirection = ParameterDirection.Output
            v_objParam.ParamValue = ""
            v_objParam.ParamSize = 100
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(2) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_err_param"
            v_objParam.ParamDirection = ParameterDirection.Output
            v_objParam.ParamValue = ""
            v_objParam.ParamSize = 500
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(3) = v_objParam

            v_strMessage = v_DataAccess.ExecuteOracleStored(v_strStoredName, v_arrPara, 1)
            'If v_arrPara(2).ParamValue Is Nothing Or Len(Trim(v_arrPara(2).ParamValue)) = 0 Then
            '    v_lngErrCode = 0
            'Else
            '    v_lngErrCode = CDbl(v_arrPara(2).ParamValue)
            'End If
            'v_lngErrCode = IIf(Len(v_arrPara(2).ParamValue) = 0, 0, CDbl(v_arrPara(2).ParamValue))
            If Not IsNumeric(v_arrPara(2).ParamValue) Then
                v_lngErrCode = 0
            Else
                v_lngErrCode = CDec(v_arrPara(2).ParamValue)
            End If
            v_xmlMessage.LoadXml(v_strMessage)
            pv_xmlDocument = v_xmlMessage
            'TruongLD add when fix none BDS
            'If v_lngErrCode <> ERR_SYSTEM_OK Then
            'End TruongLD
            If v_lngErrCode <> ERR_SYSTEM_OK And v_lngErrCode <> ERR_SA_CHECKER1_OVR And v_lngErrCode <> ERR_SA_CHECKER2_OVR Then

                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            End If
            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function NETTransact(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.txRouter.Transact", v_strErrorMessage As String
        Dim v_strxmlMessage As String, v_xmlMessage As New Xml.XmlDocument

        Try

            'Chi cho phep chay neu Host dang active
            Dim v_strSYSVAR As String, v_DataAccess As New DataAccess, v_ds As DataSet
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

            'Get HostTime for transact
            Dim v_strSQL As String = "SELECT TO_CHAR(SYSDATE,'HH24:MI:SS') TXTIME,TO_CHAR(SYSDATE,'dd/mm/yyyy') txdate FROM DUAL"
            Dim v_strHostTime As String
            v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_strHostTime = v_ds.Tables(0).Rows(0)("TXTIME")

            Else
                v_strHostTime = "00:00:00"
            End If

            'Get message header
            Dim v_strBUSDATE As String = Trim(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBUSDATE).Value.ToString)
            Dim v_strTXDATE As String = Trim(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value.ToString)
            Dim v_strTXTYPE As String = Trim(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTYPE).Value.ToString)
            Dim v_byteNOSUBMIT As Byte = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeNOSUBMIT).Value.ToString
            Dim v_strTLTXCD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value.ToString
            Dim v_intSTATUS As Integer = CInt(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeSTATUS).Value.ToString)
            Dim v_strDELTD As String = Trim(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value.ToString)
            Dim v_strOVRRQS As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value.ToString
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value.ToString
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value.ToString
            Dim v_strUpdateMode As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeUPDATEMODE).Value.ToString
            Dim v_strLOCAL As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeLOCAL).Value.ToString
            Dim v_strPRETRAN As String = Trim(pv_xmlDocument.DocumentElement.Attributes(gc_AtributePRETRAN).Value.ToString)
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False

            If v_strOFFID.Length > 0 Then
                pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFTIME).InnerXml = v_strHostTime
            Else
                If v_strCHKID.Length > 0 Then
                    pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKTIME).InnerXml = v_strHostTime
                Else
                    pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTIME).InnerXml = v_strHostTime
                End If
            End If

            'Náº¿u ngÃ y trong branch khÃ¡c vá»›i ngÃ y há»‡ thá»‘ng thÃ¬ bÃ¡o lá»—i yÃªu cáº§u thoÃ¡t ra vÃ o láº¡i há»‡ thá»‘ng
            Dim v_strCURRDATE As String
            v_lngErrCode = v_DataAccess.GetSysVar("SYSTEM", "CURRDATE", v_strCURRDATE)
            If DDMMYYYY_SystemDate(v_strTXDATE) <> DDMMYYYY_SystemDate(v_strCURRDATE) Then
                Rollback() 'ContextUtil.SetAbort()
                Return ERR_SA_BUSDATE_BRANCHDATE_PLZLOGIN_OUT
            End If

            'LÆ°u giá»¯ Ä‘iá»‡n giao dá»‹ch ban Ä‘áº§u
            v_xmlMessage = pv_xmlDocument

            'Neu la Deleting giao dich thi thuc hien cap nhat lai trang thai giao dich va xac dinh nguyen nhan duyet
            If v_strDELTD <> MSGTRANS_DELETED And v_intSTATUS = TransactStatus.Deleting Then
                'Xac dinh nguyen nhan duyet

                v_lngErrCode = ERR_SA_CHECKER1_OVR

                Dim v_objMsgLog As New MessageLog
                v_objMsgLog.NewDBInstance(gc_MODULE_HOST)

                'LocalDB TruongLD Add
                'v_lngErrCode = v_objMsgLog.TransUpdateStatus(pv_xmlDocument)
                v_strSQL = "SELECT * FROM TLLOG WHERE TXNUM='" & Trim(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value.ToString) & "' AND TXDATE =TO_DATE('" & v_strTXDATE & "','DD/MM/RRRR')"
                v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_lngErrCode = v_objMsgLog.TransUpdateStatus(pv_xmlDocument)
                Else
                    v_lngErrCode = v_objMsgLog.TransLog(pv_xmlDocument)
                End If
                'End TruongLD
                If v_lngErrCode <> ERR_SYSTEM_OK And v_lngErrCode <> ERR_SA_CHECKER1_OVR And v_lngErrCode <> ERR_SA_CHECKER2_OVR Then
                    Rollback() 'ContextUtil.SetAbort()
                    'Loi tra ve
                    Return v_lngErrCode
                Else
                    'Lay nguyen nhan duyet tra ve
                    If Len(v_xmlMessage.DocumentElement.Attributes(gc_AtributeOVRRQS).Value.ToString) > 0 Then
                        If v_xmlMessage.DocumentElement.Attributes(gc_AtributeOVRRQS).Value.ToString <> OVRRQS_CHECKER_CONTROL Then
                            v_lngErrCode = ERR_SA_CHECKER1_OVR
                        Else
                            v_lngErrCode = ERR_SA_CHECKER2_OVR
                        End If
                        v_strOVRRQS = v_xmlMessage.DocumentElement.Attributes(gc_AtributeOVRRQS).Value.ToString
                        pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value = v_strOVRRQS
                    End If
                End If
                Complete() 'ContextUtil.SetComplete()
                Return v_lngErrCode
            End If


            'Neu la Refuse cho giao dich deleting thi thuc hien cap nhat nguoc lai trang thai giao dich
            If v_strDELTD = MSGTRANS_DELETED And v_intSTATUS = TransactStatus.Completed Then
                'Xac dinh nguyen nhan duyet

                'Cap nhat trang thai giao dich
                Dim v_objMsgLog As New MessageLog
                v_objMsgLog.NewDBInstance(gc_MODULE_HOST)
                v_lngErrCode = v_objMsgLog.TransUpdateStatus(pv_xmlDocument)

                If v_lngErrCode <> ERR_SYSTEM_OK Then
                    Rollback() 'ContextUtil.SetAbort()
                    'Loi tra ve
                    Return v_lngErrCode
                End If
                Complete() 'ContextUtil.SetComplete()
                Return v_lngErrCode
            End If

            'Neu khong phai la giao dich Deleting thi thuc hien
            'Kiá»ƒm tra theo qui Ä‘á»‹nh APPCHK (bao gá»“m cáº£ xÃ¡c Ä‘á»‹nh nguyÃªn nhÃ¢n duyá»‡t. 
            'Náº¿u giao dá»‹ch cáº§n duyá»‡t sáº½ raise mÃ£ lá»—i duyá»‡t: ERR_SA_CHECKER1_OVR & ERR_SA_CHECKER2_OVR 
            'CÃ¡c mÃ£ lá»—i nÃ y Ä‘Æ°á»£c tráº£ vá»? tá»« cÃ¡c phÃ¢n há»‡ nghiá»‡p vá»¥
            If v_strDELTD <> MSGTRANS_DELETED Then
                If v_strPRETRAN = "Y" Then
                    'Ä?á»‘i vá»›i giao dá»‹ch cÃ³ PRETRAN="Y", láº§n nÃ y chá»‰ query thÃ´ng tin phá»¥
                    If v_strTXTYPE <> "M" Then
                        'Táº¡o bÃºt toÃ¡n káº¿ toÃ¡n cho giao dá»‹ch Ä‘á»‹nh nghÄ©a Ä‘á»‹nh khoáº£n á»Ÿ láº§n Ä‘áº§u tiá»?n
                        v_lngErrCode = GenPOSTMAP(pv_xmlDocument)
                        If v_lngErrCode <> ERR_SYSTEM_OK Then
                            Rollback() 'ContextUtil.SetAbort()
                            Return v_lngErrCode
                        End If
                    End If
                    'Giao dich cua phan he GL se khong tao PrinInfo
                    If v_strTLTXCD.Substring(0, 2) <> "99" Then
                        v_lngErrCode = GenPRINTINFO(pv_xmlDocument)
                        If v_lngErrCode <> ERR_SYSTEM_OK Then
                            Rollback() 'ContextUtil.SetAbort()
                            Return v_lngErrCode
                        End If
                    End If
                ElseIf v_strPRETRAN = "N" And v_byteNOSUBMIT = 1 Then
                    'Náº¿u giao dá»‹ch chá»‰ submit 01 láº§n thÃ¬ cÅ©ng táº¡p POSTMAP luÃ´n
                    If v_strTXTYPE <> "M" Then
                        'Táº¡o bÃºt toÃ¡n káº¿ toÃ¡n cho giao dá»‹ch Ä‘á»‹nh nghÄ©a Ä‘á»‹nh khoáº£n á»Ÿ láº§n Ä‘áº§u tiá»?n
                        v_lngErrCode = GenPOSTMAP(pv_xmlDocument)
                        If v_lngErrCode <> ERR_SYSTEM_OK Then
                            Rollback() 'ContextUtil.SetAbort()
                            Return v_lngErrCode
                        End If
                    End If
                End If

                'Kiá»ƒm tra phÃ¢n há»‡ nghiá»‡p vá»¥
                v_lngErrCode = GenAPPCHK(v_xmlMessage)
                If v_lngErrCode <> ERR_SYSTEM_OK Then
                    Rollback() 'ContextUtil.SetAbort()
                    Return v_lngErrCode
                End If

                'Táº¡o thÃ´ng tin trÃªn HOST Ä‘á»ƒ tráº£ vá»?
                If v_strPRETRAN = "Y" Or (v_strPRETRAN = "N" And v_byteNOSUBMIT = "1") Then
                    'Láº¥y lá»—i cá»§a phÃ¢n há»‡ nghiá»‡p vá»¥ tráº£ vá»?
                    v_lngErrCode = HostAppCheck(v_xmlMessage)
                    If v_lngErrCode <> ERR_SYSTEM_OK And v_lngErrCode <> ERR_SA_CHECKER1_OVR And v_lngErrCode <> ERR_SA_CHECKER2_OVR Then
                        Rollback() 'ContextUtil.SetAbort()
                        'Lá»—i tráº£ vá»?
                        Return v_lngErrCode
                    Else
                        'Láº¥y nguyÃªn nháº­n duyá»‡t náº¿u cÃ³
                        If Len(v_xmlMessage.DocumentElement.Attributes(gc_AtributeOVRRQS).Value.ToString) > 0 Then
                            If v_xmlMessage.DocumentElement.Attributes(gc_AtributeOVRRQS).Value.ToString <> OVRRQS_CHECKER_CONTROL Then
                                v_lngErrCode = ERR_SA_CHECKER1_OVR
                            Else
                                v_lngErrCode = ERR_SA_CHECKER2_OVR
                            End If
                            v_strOVRRQS = v_xmlMessage.DocumentElement.Attributes(gc_AtributeOVRRQS).Value.ToString
                            pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value = v_strOVRRQS
                        End If
                    End If

                    'Xá»­ lÃ½ tráº£ vá»? nguyÃªn nhÃ¢n duyá»‡t
                    If Len(Trim(Replace(v_strOVRRQS, OVRRQS_CHECKER_CONTROL, vbNullString))) > 0 And Len(v_strCHKID) = 0 Then
                        v_lngErrCode = ERR_SA_CHECKER1_OVR
                    Else
                        If InStr(v_strOVRRQS, OVRRQS_CHECKER_CONTROL) > 0 And Len(v_strOFFID) = 0 Then
                            v_lngErrCode = ERR_SA_CHECKER2_OVR
                        Else
                            v_lngErrCode = ERR_SYSTEM_OK
                        End If
                    End If
                End If

                'Xá»­ lÃ½ cáº­p nháº­t dá»¯ liá»‡u
                If v_strPRETRAN = "N" And v_lngErrCode = ERR_SYSTEM_OK Then
                    'Giao dá»‹ch khÃ´ng cÃ³ yÃªu cáº§u duyá»‡t
                    If Len(v_strOVRRQS) = 0 Then v_blnApproval = True
                    'Giao dá»‹ch yÃªu cáº§u checker 2 duyá»‡t
                    If InStr(v_strOVRRQS, gc_OFFID_OVRRQS) > 0 And Len(v_strOFFID) > 0 Then v_blnApproval = True
                    'Giao dá»‹ch yÃªu cáº§u checker 1 duyá»‡t
                    If Len(Replace(v_strOVRRQS, gc_OFFID_OVRRQS, vbNullString)) > 0 And Len(v_strCHKID) > 0 Then v_blnApproval = True

                    'Giao dá»‹ch Ä‘Ã£ Ä‘á»§ Ä‘iá»?u kiá»‡n vá»? duyá»‡t hoáº·c lÃ  giao dá»‹ch rÃºt tiá»?n (W) hoáº·c chuyá»ƒn tiá»?n (R) hoáº·c Ä‘áº·t lá»‡nh (O)
                    If v_blnApproval Or (v_strTXTYPE = "W" Or v_strTXTYPE = "R" Or v_strTXTYPE = "O") Then
                        If (v_strTXTYPE = "M" And (v_intSTATUS = TransactStatus.Logged Or v_intSTATUS = TransactStatus.Pending)) _
                            Or (v_strTXTYPE = "D" And v_intSTATUS = TransactStatus.Cashier) _
                            Or (v_strTXTYPE = "W" And v_intSTATUS = TransactStatus.Logged And v_blnApproval) _
                            Or (v_strTXTYPE = "W" And v_intSTATUS = TransactStatus.Pending And Not v_blnApproval) _
                            Or (v_strTXTYPE = "R" And v_intSTATUS = TransactStatus.Logged And v_blnApproval) _
                            Or (v_strTXTYPE = "R" And v_intSTATUS = TransactStatus.Pending And Not v_blnApproval) _
                            Or (v_strTXTYPE = "O" And v_intSTATUS = TransactStatus.Logged And v_blnApproval) _
                            Or (v_strTXTYPE = "O" And v_intSTATUS = TransactStatus.Pending And Not v_blnApproval) _
                            Or (v_strTXTYPE = "T" And (v_intSTATUS = TransactStatus.Logged Or v_intSTATUS = TransactStatus.Pending)) Then

                            v_lngErrCode = HostAppCheck(v_xmlMessage)
                            If v_lngErrCode <> ERR_SYSTEM_OK And v_lngErrCode <> ERR_SA_CHECKER1_OVR And v_lngErrCode <> ERR_SA_CHECKER2_OVR Then
                                Rollback() 'ContextUtil.SetAbort()
                                Return v_lngErrCode
                            Else
                                If Len(v_xmlMessage.DocumentElement.Attributes(gc_AtributeOVRRQS).Value.ToString) > 0 Then
                                    If v_xmlMessage.DocumentElement.Attributes(gc_AtributeOVRRQS).Value.ToString <> OVRRQS_CHECKER_CONTROL Then
                                        v_lngErrCode = ERR_SA_CHECKER1_OVR
                                    Else
                                        v_lngErrCode = ERR_SA_CHECKER2_OVR
                                    End If
                                    v_strOVRRQS = v_xmlMessage.DocumentElement.Attributes(gc_AtributeOVRRQS).Value.ToString
                                    pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value = v_strOVRRQS
                                End If
                            End If

                            'Ä?á»•i tráº¡ng thÃ¡i cá»§a giao dá»‹ch
                            If Not (v_strTXTYPE = "W" Or v_strTXTYPE = "R" Or v_strTXTYPE = "O") Then
                                pv_xmlDocument.DocumentElement.Attributes(gc_AtributeSTATUS).InnerXml = TransactStatus.Completed
                            End If
                            'Táº¡o bá»™ háº¡ch toÃ¡n káº¿ toÃ¡n
                            v_lngErrCode = GenPOSTMAP(v_xmlMessage)
                            If v_lngErrCode <> ERR_SYSTEM_OK Then
                                Rollback() 'ContextUtil.SetAbort()
                                Return v_lngErrCode
                            End If
                            'Táº¡o bá»™ phÃ©p toÃ¡n cáº­p nháº­t phÃ¢n há»‡ nghiá»‡p vá»¥
                            v_lngErrCode = GenAPPMAP(v_xmlMessage)
                            If v_lngErrCode <> ERR_SYSTEM_OK Then
                                Rollback() 'ContextUtil.SetAbort()
                                Return v_lngErrCode
                            End If

                            'Chuyen HostTransUpdate xuong duoi HostAppUpdate de tranh deadlock ve GL
                            'Cáº­p nháº­t phÃ¢n há»‡ nghiá»‡p vá»¥
                            v_lngErrCode = HostAppUpdate(v_xmlMessage)
                            If v_lngErrCode <> ERR_SYSTEM_OK Then
                                Rollback() 'ContextUtil.SetAbort()
                                Return v_lngErrCode
                            End If

                            'Cáº­p nháº­t GL vÃ  TLLOG
                            v_lngErrCode = HostTransUpdate(pv_xmlDocument)
                            If v_lngErrCode <> ERR_SYSTEM_OK Then
                                Rollback() 'ContextUtil.SetAbort()
                                Return v_lngErrCode
                            End If
                            'Neu la giao dich 0033 ' remap token thi goi sang entrust service
                            If v_strTLTXCD = gc_CF_REMAP_TOKEN Then
                                v_lngErrCode = RemapToken(pv_xmlDocument)
                                If v_lngErrCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                    Return v_lngErrCode
                                End If
                            End If
                            'Neu la giao dich 0034 ' unlock token thi goi sang entrust service
                            If v_strTLTXCD = gc_CF_UNLOCK_TOKEN Then
                                v_lngErrCode = UnlockToken(pv_xmlDocument)
                                If v_lngErrCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                    Return v_lngErrCode
                                End If
                            End If

                        ElseIf (v_strTXTYPE = "W" And v_intSTATUS = TransactStatus.Pending And v_blnApproval) Then
                            'Cáº­p nháº­t láº¡i tráº¡ng thÃ¡i giao dá»‹ch: Chá»? thanh toÃ¡n
                            Dim v_objMessageLog As New MessageLog
                            v_objMessageLog.NewDBInstance(gc_MODULE_HOST)
                            pv_xmlDocument.DocumentElement.Attributes(gc_AtributeSTATUS).InnerXml = TransactStatus.Cashier
                            'v_lngErrCode = v_objMessageLog.TransUpdateStatus(pv_xmlDocument)
                            'LocalDB TruongLD Add
                            'v_lngErrCode = v_objMessageLog.TransUpdateStatus(pv_xmlDocument)
                            v_strSQL = "SELECT * FROM TLLOG WHERE TXNUM='" & Trim(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value.ToString) & "' AND TXDATE =TO_DATE('" & v_strTXDATE & "','DD/MM/RRRR')"
                            v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                            If v_ds.Tables(0).Rows.Count > 0 Then
                                v_lngErrCode = v_objMessageLog.TransUpdateStatus(pv_xmlDocument)
                            Else
                                v_lngErrCode = v_objMessageLog.TransLog(pv_xmlDocument)
                            End If
                            'End TruongLD
                            If v_lngErrCode <> ERR_SYSTEM_OK Then
                                Rollback() 'ContextUtil.SetAbort()
                                Return v_lngErrCode
                            End If
                        ElseIf (v_strTXTYPE = "R" And v_intSTATUS = TransactStatus.Pending And v_blnApproval) Then
                            'Cáº­p nháº­t láº¡i tráº¡ng thÃ¡i giao dá»‹ch: Chá»? chuyá»ƒn
                            Dim v_objMessageLog As New MessageLog
                            v_objMessageLog.NewDBInstance(gc_MODULE_HOST)
                            pv_xmlDocument.DocumentElement.Attributes(gc_AtributeSTATUS).InnerXml = TransactStatus.Remittance
                            'v_lngErrCode = v_objMessageLog.TransUpdateStatus(pv_xmlDocument)
                            'LocalDB TruongLD Add
                            'v_lngErrCode = v_objMessageLog.TransUpdateStatus(pv_xmlDocument)
                            v_strSQL = "SELECT * FROM TLLOG WHERE TXNUM='" & Trim(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value.ToString) & "' AND TXDATE =TO_DATE('" & v_strTXDATE & "','DD/MM/RRRR')"
                            v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                            If v_ds.Tables(0).Rows.Count > 0 Then
                                v_lngErrCode = v_objMessageLog.TransUpdateStatus(pv_xmlDocument)
                            Else
                                v_lngErrCode = v_objMessageLog.TransLog(pv_xmlDocument)
                            End If
                            'End TruongLD
                            If v_lngErrCode <> ERR_SYSTEM_OK Then
                                Rollback() 'ContextUtil.SetAbort()
                                Return v_lngErrCode
                            End If
                        ElseIf (v_strTXTYPE = "O" And v_intSTATUS = TransactStatus.Pending And v_blnApproval) Then
                            Dim v_objMessageLog As New MessageLog
                            v_objMessageLog.NewDBInstance(gc_MODULE_HOST)
                            pv_xmlDocument.DocumentElement.Attributes(gc_AtributeSTATUS).InnerXml = TransactStatus.Completed
                            'v_lngErrCode = v_objMessageLog.TransUpdateStatus(pv_xmlDocument)
                            'LocalDB TruongLD Add
                            'v_lngErrCode = v_objMessageLog.TransUpdateStatus(pv_xmlDocument)
                            v_strSQL = "SELECT * FROM TLLOG WHERE TXNUM='" & Trim(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value.ToString) & "' AND TXDATE =TO_DATE('" & v_strTXDATE & "','DD/MM/RRRR')"
                            v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                            If v_ds.Tables(0).Rows.Count > 0 Then
                                v_lngErrCode = v_objMessageLog.TransUpdateStatus(pv_xmlDocument)
                            Else
                                v_lngErrCode = v_objMessageLog.TransLog(pv_xmlDocument)
                            End If
                            'End TruongLD
                            If v_lngErrCode <> ERR_SYSTEM_OK Then
                                Rollback() 'ContextUtil.SetAbort()
                                Return v_lngErrCode
                            End If

                        ElseIf (v_strTXTYPE = "W" And v_intSTATUS = TransactStatus.Cashier) _
                            Or (v_strTXTYPE = "R" And v_intSTATUS = TransactStatus.Remittance) Then
                            'Cáº­p nháº­t láº¡i tráº¡ng thÃ¡i giao dá»‹ch
                            Dim v_objMessageLog As New MessageLog
                            v_objMessageLog.NewDBInstance(gc_MODULE_HOST)
                            pv_xmlDocument.DocumentElement.Attributes(gc_AtributeSTATUS).InnerXml = TransactStatus.Completed
                            'v_lngErrCode = v_objMessageLog.TransUpdateStatus(pv_xmlDocument)
                            'LocalDB TruongLD Add
                            'v_lngErrCode = v_objMessageLog.TransUpdateStatus(pv_xmlDocument)
                            v_strSQL = "SELECT * FROM TLLOG WHERE TXNUM='" & Trim(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value.ToString) & "' AND TXDATE =TO_DATE('" & v_strTXDATE & "','DD/MM/RRRR')"
                            v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                            If v_ds.Tables(0).Rows.Count > 0 Then
                                v_lngErrCode = v_objMessageLog.TransUpdateStatus(pv_xmlDocument)
                            Else
                                v_lngErrCode = v_objMessageLog.TransLog(pv_xmlDocument)
                            End If
                            'End TruongLD
                            If v_lngErrCode <> ERR_SYSTEM_OK Then
                                Rollback() 'ContextUtil.SetAbort()
                                Return v_lngErrCode
                            End If
                        End If
                    End If
                End If
            Else
                'Kiem tra lai xem giao dich da bi xoa tren host hay chua
                v_strSQL = "SELECT DELTD FROM TLLOG WHERE TXNUM='" & Trim(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value.ToString) & "' AND TXDATE =TO_DATE('" & v_strTXDATE & "','DD/MM/RRRR')"
                v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    If v_ds.Tables(0).Rows(0)("DELTD") <> "N" Then
                        Rollback() 'ContextUtil.SetAbort()
                        Return ERR_SA_CANNOT_DELETETRANSACTION
                    End If

                Else
                    Rollback() 'ContextUtil.SetAbort()
                    Return ERR_SA_TRANSACTION_NOTFOUND
                End If

                'Chuyen HostTransUpdate xuong duoi HostAppUpdate de tranh deadlock ve GL
                v_lngErrCode = GenAPPMAP(v_xmlMessage)
                If v_lngErrCode <> ERR_SYSTEM_OK Then
                    Rollback() 'ContextUtil.SetAbort()
                    Return v_lngErrCode
                End If

                v_lngErrCode = HostAppUpdate(v_xmlMessage)
                If v_lngErrCode <> ERR_SYSTEM_OK Then
                    Rollback() 'ContextUtil.SetAbort()
                    Return v_lngErrCode
                End If

                v_lngErrCode = HostTransUpdate(pv_xmlDocument)
                If v_lngErrCode <> ERR_SYSTEM_OK Then
                    Rollback() 'ContextUtil.SetAbort()
                    Return v_lngErrCode
                End If

            End If
            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function DistributeMessageBus(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "TxRouter.DistributeMessageBus", v_strSQL, v_strErrorMessage As String
        Dim v_objHost As New DataAccess, v_ds, v_dsHost As DataSet
        v_objHost.NewDBInstance(gc_MODULE_HOST)

        Try
            'Dim v_arrInquiryPara(), v_arrDistributePara() As ReportParameters
            'Dim v_objInquiryParam, v_objDistributeParam As ReportParameters
            'Dim v_arrLogPara() As StoreParameter, v_objLogParam As StoreParameter
            'Dim v_strTXDATE, v_strTXNUM, v_strTLTXCD, v_strREFTYPE, v_strREFKEY, v_strTBLNAME, v_strQUEUENAME, v_strSQLCMD, v_strFLDFILTER, v_strMSGBODY As String, i As Integer
            'Dim v_xmlDocument As New Xml.XmlDocument, v_dataElement As Xml.XmlElement, v_entryNode, v_nodetxData As Xml.XmlNode
            'Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            'v_strTLTXCD = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value.ToString
            'v_strTXDATE = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value.ToString
            'v_strTXNUM = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value.ToString
            ''Prepare parameters
            'ReDim v_arrLogPara(2)
            'v_objLogParam = New StoreParameter
            'v_objLogParam.ParamName = "TLTXCD"
            'v_objLogParam.ParamValue = v_strTLTXCD
            'v_objLogParam.ParamSize = v_strTLTXCD.Length
            'v_objLogParam.ParamType = "String"
            'v_arrLogPara(0) = v_objLogParam

            'v_objLogParam = New StoreParameter
            'v_objLogParam.ParamName = "TXDATE"
            'v_objLogParam.ParamValue = v_strTXDATE
            'v_objLogParam.ParamSize = v_strTXDATE.Length
            'v_objLogParam.ParamType = "String"
            'v_arrLogPara(1) = v_objLogParam

            'v_objLogParam = New StoreParameter
            'v_objLogParam.ParamName = "TXNUM"
            'v_objLogParam.ParamValue = v_strTXNUM
            'v_objLogParam.ParamSize = v_strTXNUM.Length
            'v_objLogParam.ParamType = "String"
            'v_arrLogPara(2) = v_objLogParam
            'v_objHost.ExecuteStoredNonQuerry("GENBUSMAPTX", v_arrLogPara)
            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        Finally
            If Not v_ds Is Nothing Then v_ds.Dispose()
            If Not v_dsHost Is Nothing Then v_dsHost.Dispose()
            v_objHost = Nothing
        End Try
    End Function

    Public Function Batch(ByVal v_strAPPTYPE As String, ByVal v_strBCHMDL As String, Optional ByVal v_strBCHFillter As String = "", Optional ByRef v_intMaxRow As Integer = 0) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.txRouter.Batch", v_strErrorMessage As String
        Dim v_objBatch As CoreBusiness.Batch, v_objTxRouter As New Host.txRouter, v_strSQL As String
        Try

            'Cho phép chạy Batch nếu HOSTATUS là  INACTIVE
            Dim v_strSYSVAR As String, v_DataAccess As New DataAccess
            v_DataAccess.NewDBInstance(gc_MODULE_HOST)
            v_lngErrCode = v_DataAccess.GetSysVar("SYSTEM", "HOSTATUS", v_strSYSVAR)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            End If

            Dim oAssembly As System.Reflection.Assembly = System.Reflection.Assembly.Load(v_strAPPTYPE)
            Dim aType As System.Type = oAssembly.GetType(v_strAPPTYPE & ".Batch")
            If Not aType Is Nothing Then
                Dim obj, retval As Object
                obj = Activator.CreateInstance(aType)
                'Create batch transaction
                Dim args() As Object = {v_strBCHMDL, v_strBCHFillter, v_intMaxRow}
                retval = aType.InvokeMember("ExecuteRouter", Reflection.BindingFlags.InvokeMethod, Nothing, obj, args)
                v_lngErrCode = CType(retval, Long)
                v_intMaxRow = CType(args(2), Integer)
                If v_lngErrCode <> ERR_SYSTEM_OK Then
                    Rollback() 'ContextUtil.SetAbort()
                    Return v_lngErrCode
                End If
                'Execute Batch TLLOG transaction
                v_lngErrCode = v_objTxRouter.ExecuteBatchName(v_strBCHMDL)
                If v_lngErrCode <> ERR_SYSTEM_OK Then
                    Rollback() 'ContextUtil.SetAbort()
                    Return v_lngErrCode
                End If
            Else
                LogError.Write("Log source: " & "End off txRouter.Batch" & vbNewLine _
                         & "Object: " & v_strAPPTYPE & ".Batch" & vbNewLine _
                         & "Message: Batch running can not invoke to object", "EventLogEntryType.Error")
            End If

            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function DBBatch(ByVal v_strAPPTYPE As String, ByVal v_strBCHMDL As String, ByRef v_strLastRun As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.txRouter.DBBatch", v_strErrorMessage As String
        Dim v_strSQL As String
        Dim v_strStoredName, v_strMessage As String
        Try
            Dim v_DataAccess As New DataAccess, v_ds As DataSet
            v_DataAccess.NewDBInstance(gc_MODULE_HOST)
            v_strStoredName = "TXPKS_BATCH.PR_BATCH"
            Dim v_objParam As New StoreParameter
            Dim v_arrPara(3) As StoreParameter

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_apptype"
            v_objParam.ParamValue = v_strAPPTYPE
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamSize = 30
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(0) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_bchmdl"
            v_objParam.ParamValue = v_strBCHMDL
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamSize = 100
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(1) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_err_code"
            v_objParam.ParamDirection = ParameterDirection.Output
            v_objParam.ParamValue = ""
            v_objParam.ParamSize = 100
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(2) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_lastRun"
            v_objParam.ParamDirection = ParameterDirection.Output
            v_objParam.ParamValue = ""
            v_objParam.ParamSize = 100
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(3) = v_objParam

            v_strLastRun = v_DataAccess.ExecuteOracleStored(v_strStoredName, v_arrPara, 3)
            If Not IsNumeric(v_arrPara(2).ParamValue) Then
                v_lngErrCode = 0
            Else
                v_lngErrCode = CDec(v_arrPara(2).ParamValue)
            End If
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            End If
            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function CoreBank(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.txRouter.CoreBank", v_strErrorMessage As String
        Dim v_objBatch As RM.Remittance, v_objTxRouter As New Host.txRouter, v_strSQL As String
        Dim v_xmlTxMessage As New Xml.XmlDocument
        Dim v_strTxdate, v_strTxnum As String
        Try

            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_QUEUE)
            Dim v_strSQLBANK As String, v_ds, v_dsBank As DataSet

            v_strSQL = "SELECT COUNT(*) CN FROM AQ$" & ConfigurationSettings.AppSettings(gc_MODULE_QUEUE & ".INBOX").ToString().Trim() & "_TABLE WHERE MSG_STATE = 'READY'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows(0)("CN") > 0 Then
                For J As Integer = 0 To v_ds.Tables(0).Rows(0)("CN") - 1
                    '1. Create standart message
                    Dim v_strQueueMessage As String = ""
                    Dim v_strTxMessage As String = ""
                    v_strQueueMessage = SecuritiesDequeue(ConfigurationSettings.AppSettings(gc_MODULE_QUEUE & ".INBOX").ToString().Trim(), ConfigurationSettings.AppSettings(gc_MODULE_QUEUE & ".CONSUMER").ToString().Trim())
                    If v_strQueueMessage.Length > 0 Then
                        Dim v_QueuexmlDocument As New Xml.XmlDocument
                        Dim v_TxXmlDocument As New Xml.XmlDocument
                        v_QueuexmlDocument.LoadXml(v_strQueueMessage)
                        Dim v_nodeTxMessage As Xml.XmlNode
                        v_nodeTxMessage = v_QueuexmlDocument.DocumentElement.FirstChild
                        v_strTxMessage = v_nodeTxMessage.InnerXml
                        v_TxXmlDocument.LoadXml(v_strTxMessage)
                        v_TxXmlDocument.DocumentElement.Attributes(gc_AtributeMSGTYPE).Value = gc_MsgTypeObj
                        v_TxXmlDocument.DocumentElement.Attributes(gc_AtributeBATCHNAME).Value = "BANK"

                        Dim v_attrOBJNAME As Xml.XmlAttribute
                        v_attrOBJNAME = v_TxXmlDocument.CreateAttribute(gc_AtributeOBJNAME)
                        v_attrOBJNAME.Value = OBJNAME_SY_AUTHENTICATION
                        v_TxXmlDocument.DocumentElement.Attributes.Append(v_attrOBJNAME)

                        Dim v_attrActionFlag As Xml.XmlAttribute
                        v_attrActionFlag = v_TxXmlDocument.CreateAttribute(gc_AtributeACTFLAG)
                        v_attrActionFlag.Value = gc_ActionInquiry
                        v_TxXmlDocument.DocumentElement.Attributes.Append(v_attrActionFlag)

                        Dim v_attrFUNCNAME As Xml.XmlAttribute
                        v_attrFUNCNAME = v_TxXmlDocument.CreateAttribute(gc_AtributeFUNCNAME)
                        v_attrFUNCNAME.Value = "CoreBankExecute"
                        v_TxXmlDocument.DocumentElement.Attributes.Append(v_attrFUNCNAME)

                        Select Case v_QueuexmlDocument.DocumentElement.Attributes(gc_AtributeTXCODE).Value
                            Case TXCODE_HOLD
                                v_TxXmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value = gc_RM_RCV_HOLd
                            Case TXCODE_UNHOLD
                                v_TxXmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value = gc_RM_RCV_UNHOLd
                            Case TXCODE_TRANSFER
                                v_TxXmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value = gc_RM_RCV_TRANSFER
                        End Select
                        v_strTxMessage = v_TxXmlDocument.InnerXml
                        'Dim v_ws As New HostDelivery.HOSTDelivery
                        'v_lngErrCode = v_ws.Message(v_strTxMessage)
                        pv_strObjMsg = v_strTxMessage
                        'Dim v_strReturnMsg = v_strTxMessage
                    Else
                        Return ERR_SYSTEM_OK
                    End If

                    '2. Execute
                    Dim v_strSYSVAR As String, v_DataAccess As New DataAccess
                    v_DataAccess.NewDBInstance(gc_MODULE_HOST)
                    v_lngErrCode = v_DataAccess.GetSysVar("SYSTEM", "HOSTATUS", v_strSYSVAR)
                    If v_lngErrCode <> ERR_SYSTEM_OK Then
                        Rollback() 'ContextUtil.SetAbort()
                        Return v_lngErrCode
                    End If
                    v_objBatch = New RM.Remittance
                    If Not v_objBatch Is Nothing Then
                        'Sinh ra Transaction Log
                        v_lngErrCode = v_objBatch.ExecuteRouter(pv_strObjMsg)
                        If v_lngErrCode <> ERR_SYSTEM_OK Then
                            Rollback() 'ContextUtil.SetAbort()
                            Return v_lngErrCode
                        End If
                        'Doc tu TLLOG len de thuc hien
                        v_xmlTxMessage.LoadXml(pv_strObjMsg)
                        v_strTxnum = v_xmlTxMessage.DocumentElement.Attributes(gc_AtributeTXNUM).Value.ToString
                        v_strTxdate = v_xmlTxMessage.DocumentElement.Attributes(gc_AtributeTXDATE).Value.ToString
                        v_lngErrCode = ExecuteTxMessage(v_strTxdate, v_strTxnum)
                        If v_lngErrCode <> ERR_SYSTEM_OK Then
                            Rollback() 'ContextUtil.SetAbort()
                            Return v_lngErrCode
                        End If
                    End If
                Next
            End If

            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

#End Region

#Region " Private methods "
    Private Function SecuritiesDequeue(ByRef pv_strQueueName As String, ByRef pv_strConsumer As String) As String
        Dim v_objRptParam As StoreParameter
        Dim v_arrRptPara() As StoreParameter
        Dim v_obj As New DataAccess
        Dim v_strQueueMessage As String
        v_obj.NewDBInstance(gc_MODULE_QUEUE)
        Try
            v_objRptParam = New StoreParameter
            ReDim v_arrRptPara(2)
            v_objRptParam.ParamName = "queue"
            v_objRptParam.ParamValue = pv_strQueueName
            v_objRptParam.ParamSize = CInt(100)
            v_objRptParam.ParamType = "VARCHAR2"
            v_objRptParam.ParamDirection = ParameterDirection.Input
            v_arrRptPara(0) = v_objRptParam
            'Consumer parameter
            v_objRptParam = New StoreParameter
            v_objRptParam.ParamName = "consumer"
            v_objRptParam.ParamValue = pv_strConsumer
            v_objRptParam.ParamSize = CInt(100)
            v_objRptParam.ParamType = "VARCHAR2"
            v_objRptParam.ParamDirection = ParameterDirection.Input
            v_arrRptPara(1) = v_objRptParam
            'Out message parameter
            v_objRptParam = New StoreParameter
            v_objRptParam.ParamName = "messages"
            v_objRptParam.ParamValue = ""
            v_objRptParam.ParamSize = CInt(4000)
            v_objRptParam.ParamType = "VARCHAR2"
            v_objRptParam.ParamDirection = ParameterDirection.Output
            v_arrRptPara(2) = v_objRptParam
            v_strQueueMessage = v_obj.ExecuteStoredReturnString("SECRCV_DEQ", v_arrRptPara, 2)
            Return v_strQueueMessage
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'HÃ m nÃ y thá»±c hiá»‡n má»™t bÆ°á»›c Batch
    'v_strBatchName lÃ  tÃªn bÆ°á»›c cháº¡y Batch
    Public Function ExecuteBatchName(ByVal v_strBatchName As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "CoreBusiness.Batch.ExecuteBatchName." & v_strBatchName, v_strErrorMessage As String
        Dim v_strSQL As String, v_ds As DataSet, v_obj As New DataAccess
        Dim v_strTxMsg, v_strTxNum, v_strTxDate, v_strPrevDate, v_strNextDate As String
        Try
            v_obj.NewDBInstance(gc_MODULE_HOST)
            'Láº¥y danh sÃ¡ch cÃ¡c giao dá»‹ch trong Batch theo BatchName cÃ³ tráº¡ng thÃ¡i lÃ  Logged Ä‘á»ƒ thá»±c hiá»‡n
            v_strSQL = "SELECT TXDATE, TXNUM FROM TLLOG WHERE DELTD<>'Y' AND TXSTATUS='" & CStr(TransactStatus.Logged) & "' AND BATCHNAME='" & v_strBatchName & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To v_ds.Tables(0).Rows.Count - 1 Step 1
                    'Láº¥y TxDate vÃ  TxNum
                    v_strTxDate = Format(gf_CorrectDateField(v_ds.Tables(0).Rows(i)("TXDATE")), gc_FORMAT_DATE)
                    v_strTxNum = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("TXNUM")))
                    'Thá»±c hiá»‡n giao dá»‹ch
                    v_lngErrCode = ExecuteTxMessage(v_strTxDate, v_strTxNum)
                    If v_lngErrCode <> ERR_SYSTEM_OK Then
                        Rollback() 'ContextUtil.SetAbort()
                        Return v_lngErrCode
                    End If
                Next
            End If
            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode

        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function ExecuteFOMessage(ByVal v_strTxDate As String, ByVal v_strTxNum As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.TxRouter.ExecuteFOMessage." & v_strTxDate & "." & v_strTxNum, v_strErrorMessage As String
        Dim v_strSQL As String, v_ds As DataSet, v_obj As New DataAccess
        Dim v_strTxMsg As String, v_xmlDocument As New Xml.XmlDocument, v_objMessageLog As New MessageLog
        v_objMessageLog.NewDBInstance(gc_MODULE_HOST)
        Try
            v_obj.NewDBInstance(gc_MODULE_HOST)
            'Lay noi dung giao dich
            v_strTxMsg = BuildXMLObjMsg(v_strTxDate, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "GetMessage", , v_strTxNum)
            v_xmlDocument.LoadXml(v_strTxMsg)
            v_lngErrCode = v_objMessageLog.TransDetail(v_xmlDocument)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            End If

            'Thuc hien giao dich. 
            Dim v_strTXTYPE As String = Trim(v_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTYPE).Value.ToString)
            Dim v_intSTATUS As Integer = CInt(v_xmlDocument.DocumentElement.Attributes(gc_AtributeSTATUS).Value.ToString)
            Dim v_strDELTD As String = Trim(v_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value.ToString)
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False

            'Kiem tra phan he nghiep vu
            v_lngErrCode = GenAPPCHK(v_xmlDocument)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                v_strErrorMessage = v_strErrorSource & ".Step: GenAPPCHK"
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            End If
            'Láº¥y lá»—i cá»§a phÃ¢n há»‡ nghiá»‡p vá»¥ tráº£ vá»?
            v_lngErrCode = HostAppCheck(v_xmlDocument)

            If v_lngErrCode <> ERR_SYSTEM_OK And v_lngErrCode <> ERR_SA_CHECKER1_OVR And v_lngErrCode <> ERR_SA_CHECKER2_OVR Then
                'Lá»—i tráº£ vá»?
                v_strErrorMessage = v_strErrorSource & ".Step: HostAppCheck"
                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                             & "Error code: System error!" & vbNewLine _
                             & "Error message: " & v_strTxDate & "." & v_strTxNum, "EventLogEntryType.Error")
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            Else
                'Khong can yeu cau huyet
                v_xmlDocument.DocumentElement.Attributes(gc_AtributeSTATUS).InnerXml = TransactStatus.Completed
                'Tao postmap va appmap
                If v_strTXTYPE <> "M" Then
                    'Tao but otan dinh khoan
                    v_lngErrCode = GenPOSTMAP(v_xmlDocument)
                    If v_lngErrCode <> ERR_SYSTEM_OK Then
                        v_strErrorMessage = v_strErrorSource & ".Step: GenPOSTMAP"
                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                     & "Error code: System error!" & vbNewLine _
                                     & "Error message: " & v_strTxDate & "." & v_strTxNum, "EventLogEntryType.Error")
                        Rollback() 'ContextUtil.SetAbort()
                        Return v_lngErrCode
                    End If
                End If
                'Tao phep toan phan he nghiep vu
                v_lngErrCode = GenAPPMAP(v_xmlDocument)
                If v_lngErrCode <> ERR_SYSTEM_OK Then
                    v_strErrorMessage = v_strErrorSource & ".Step: GenAPPMAP"
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: System error!" & vbNewLine _
                                 & "Error message: " & v_strTxDate & "." & v_strTxNum, "EventLogEntryType.Error")
                    Rollback() 'ContextUtil.SetAbort()
                    Return v_lngErrCode
                End If
                v_lngErrCode = HostAppUpdate(v_xmlDocument)
                If v_lngErrCode <> ERR_SYSTEM_OK Then
                    v_strErrorMessage = v_strErrorSource & ".Step: HostAppUpdate"
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: System error!" & vbNewLine _
                                 & "Error message: " & v_strTxDate & "." & v_strTxNum, "EventLogEntryType.Error")
                    Rollback() 'ContextUtil.SetAbort()
                    Return v_lngErrCode
                End If
                v_lngErrCode = HostTransUpdate(v_xmlDocument)
                If v_lngErrCode <> ERR_SYSTEM_OK Then
                    v_strErrorMessage = v_strErrorSource & ".Step: HostTransUpdate"
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: System error!" & vbNewLine _
                                 & "Error message: " & v_strTxDate & "." & v_strTxNum, "EventLogEntryType.Error")
                    Rollback() 'ContextUtil.SetAbort()
                    Return v_lngErrCode
                End If

            End If
            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode

        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
    Public Function DeleteAutoGV(ByVal v_strTxDate As String, ByVal v_strTxNum As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.TxRouter.DeleteAutoGV." & v_strTxDate & "." & v_strTxNum, v_strErrorMessage As String
        Try
            Return ExecuteDeleteAutoGV(v_strTxDate, v_strTxNum)
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
    Public Function ExecuteGVTxMessage(ByVal v_strTxDate As String, ByVal v_strTxNum As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.TxRouter.ExecuteGVTxMessage." & v_strTxDate & "." & v_strTxNum, v_strErrorMessage As String
        Try
            Return ExecuteTxMessageGV(v_strTxDate, v_strTxNum)
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function ExecuteTxMessageGV(ByVal v_strTxDate As String, ByVal v_strTxNum As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.TxRouter.ExecuteTxMessage." & v_strTxDate & "." & v_strTxNum, v_strErrorMessage As String
        Dim v_strSQL As String, v_ds As DataSet, v_obj As New DataAccess
        Dim v_strTxMsg As String, v_xmlDocument As New Xml.XmlDocument, v_objMessageLog As New MessageLog
        v_objMessageLog.NewDBInstance(gc_MODULE_HOST)
        Try
            v_obj.NewDBInstance(gc_MODULE_HOST)
            'Láº¥y ná»™i dung chi tiáº¿t cá»§a giao dá»‹ch
            v_strTxMsg = BuildXMLObjMsg(v_strTxDate, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "GetMessage", , v_strTxNum)
            v_xmlDocument.LoadXml(v_strTxMsg)
            v_lngErrCode = v_objMessageLog.TransDetail(v_xmlDocument)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            End If

            'Thá»±c hiá»‡n giao dá»‹ch. Ä?á»‘i vá»›i giao dá»‹ch Batch thÃ¬ thá»±c hiá»‡n luÃ´n khÃ´ng cáº§n quan tÃ¢m Ä‘áº¿n sá»‘ láº§n Submit
            Dim v_strTXTYPE As String = Trim(v_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTYPE).Value.ToString)
            Dim v_intSTATUS As Integer = CInt(v_xmlDocument.DocumentElement.Attributes(gc_AtributeSTATUS).Value.ToString)
            Dim v_strDELTD As String = Trim(v_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value.ToString)
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False

            ''Kiá»ƒm tra phÃ¢n há»‡ nghiá»‡p vá»¥: Giao dich Batch khong thuc hien TXCHECK
            v_lngErrCode = GenAPPCHK(v_xmlDocument)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                v_strErrorMessage = v_strErrorSource & ".Step: GenAPPCHK"
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            End If
            'Láº¥y lá»—i cá»§a phÃ¢n há»‡ nghiá»‡p vá»¥ tráº£ vá»?
            v_lngErrCode = HostAppCheck(v_xmlDocument)

            If v_lngErrCode <> ERR_SYSTEM_OK And v_lngErrCode <> ERR_SA_CHECKER1_OVR And v_lngErrCode <> ERR_SA_CHECKER2_OVR Then
                'Lá»—i tráº£ vá»?
                v_strErrorMessage = v_strErrorSource & ".Step: HostAppCheck"
                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                             & "Error code: System error!" & vbNewLine _
                             & "Error message: " & v_strTxDate & "." & v_strTxNum, "EventLogEntryType.Error")
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            Else
                'Giao dá»‹ch trong Batch khÃ´ng quan tÃ¢m Ä‘áº¿n duyá»‡t giao dá»‹ch
                v_xmlDocument.DocumentElement.Attributes(gc_AtributeSTATUS).InnerXml = TransactStatus.Completed
                'Táº¡o POSTMAP vÃ  APPMAP
                If v_strTXTYPE <> "M" Then
                    'Táº¡o bÃºt toÃ¡n káº¿ toÃ¡n cho giao dá»‹ch Ä‘á»‹nh nghÄ©a Ä‘á»‹nh khoáº£n á»Ÿ láº§n Ä‘áº§u tiá»?n
                    v_lngErrCode = GenPOSTMAP(v_xmlDocument)
                    If v_lngErrCode <> ERR_SYSTEM_OK Then
                        v_strErrorMessage = v_strErrorSource & ".Step: GenPOSTMAP"
                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                     & "Error code: System error!" & vbNewLine _
                                     & "Error message: " & v_strTxDate & "." & v_strTxNum, "EventLogEntryType.Error")
                        Rollback() 'ContextUtil.SetAbort()
                        Return v_lngErrCode
                    End If
                End If
                'Táº¡o bá»™ phÃ©p toÃ¡n cáº­p nháº­t phÃ¢n há»‡ nghiá»‡p vá»¥
                v_lngErrCode = GenAPPMAP(v_xmlDocument)
                If v_lngErrCode <> ERR_SYSTEM_OK Then
                    v_strErrorMessage = v_strErrorSource & ".Step: GenAPPMAP"
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: System error!" & vbNewLine _
                                 & "Error message: " & v_strTxDate & "." & v_strTxNum, "EventLogEntryType.Error")
                    Rollback() 'ContextUtil.SetAbort()
                    Return v_lngErrCode
                End If

                'Chuyen HostTransUpdate xuong duoi HostAppUpdate de tranh deadlock ve GL
                'Cáº­p nháº­t phÃ¢n há»‡ nghiá»‡p vá»¥
                v_lngErrCode = HostAppUpdate(v_xmlDocument)
                If v_lngErrCode <> ERR_SYSTEM_OK Then
                    v_strErrorMessage = v_strErrorSource & ".Step: HostAppUpdate"
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: System error!" & vbNewLine _
                                 & "Error message: " & v_strTxDate & "." & v_strTxNum, "EventLogEntryType.Error")
                    Rollback() 'ContextUtil.SetAbort()
                    Return v_lngErrCode
                End If
                v_lngErrCode = HostTransUpdate(v_xmlDocument)
                If v_lngErrCode <> ERR_SYSTEM_OK Then
                    v_strErrorMessage = v_strErrorSource & ".Step: HostTransUpdate"
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: System error!" & vbNewLine _
                                 & "Error message: " & v_strTxDate & "." & v_strTxNum, "EventLogEntryType.Error")
                    Rollback() 'ContextUtil.SetAbort()
                    Return v_lngErrCode
                End If

            End If
            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode

        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
    'HÃ m nÃ y thá»±c hiá»‡n cháº¡y láº¡i má»™t giao dá»‹ch
    'v_strTxDate lÃ  ngÃ y giao dá»‹ch, v_strTxNum lÃ  sá»‘ giao dá»‹ch
    Public Function ExecuteTxMessage(ByVal v_strTxDate As String, ByVal v_strTxNum As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.TxRouter.ExecuteTxMessage." & v_strTxDate & "." & v_strTxNum, v_strErrorMessage As String
        Dim v_strSQL As String, v_ds As DataSet, v_obj As New DataAccess
        Dim v_strTxMsg As String, v_xmlDocument As New Xml.XmlDocument, v_objMessageLog As New MessageLog
        v_objMessageLog.NewDBInstance(gc_MODULE_HOST)
        Dim v_arrLogPara() As StoreParameter, v_objLogParam As StoreParameter
        Try
            v_obj.NewDBInstance(gc_MODULE_HOST)
            'Láº¥y ná»™i dung chi tiáº¿t cá»§a giao dá»‹ch
            v_strTxMsg = BuildXMLObjMsg(v_strTxDate, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "GetMessage", , v_strTxNum)
            v_xmlDocument.LoadXml(v_strTxMsg)
            v_lngErrCode = v_objMessageLog.TransDetail(v_xmlDocument)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            End If

            'Thá»±c hiá»‡n giao dá»‹ch. Ä?á»‘i vá»›i giao dá»‹ch Batch thÃ¬ thá»±c hiá»‡n luÃ´n khÃ´ng cáº§n quan tÃ¢m Ä‘áº¿n sá»‘ láº§n Submit
            Dim v_strTXTYPE As String = Trim(v_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTYPE).Value.ToString)
            Dim v_intSTATUS As Integer = CInt(v_xmlDocument.DocumentElement.Attributes(gc_AtributeSTATUS).Value.ToString)
            Dim v_strDELTD As String = Trim(v_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value.ToString)
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False

            ''Kiá»ƒm tra phÃ¢n há»‡ nghiá»‡p vá»¥: Giao dich Batch khong thuc hien TXCHECK
            'v_lngErrCode = GenAPPCHK(v_xmlDocument)
            'If v_lngErrCode <> ERR_SYSTEM_OK Then
            '    v_strErrorMessage = v_strErrorSource & ".Step: GenAPPCHK"
            '    Rollback() 'ContextUtil.SetAbort()
            '    Return v_lngErrCode
            'End If
            ''Láº¥y lá»—i cá»§a phÃ¢n há»‡ nghiá»‡p vá»¥ tráº£ vá»?
            'v_lngErrCode = HostAppCheck(v_xmlDocument)

            If v_lngErrCode <> ERR_SYSTEM_OK And v_lngErrCode <> ERR_SA_CHECKER1_OVR And v_lngErrCode <> ERR_SA_CHECKER2_OVR Then
                'Lá»—i tráº£ vá»?
                v_strErrorMessage = v_strErrorSource & ".Step: HostAppCheck"
                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                             & "Error code: System error!" & vbNewLine _
                             & "Error message: " & v_strTxDate & "." & v_strTxNum, "EventLogEntryType.Error")
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            Else
                'Giao dá»‹ch trong Batch khÃ´ng quan tÃ¢m Ä‘áº¿n duyá»‡t giao dá»‹ch
                v_xmlDocument.DocumentElement.Attributes(gc_AtributeSTATUS).InnerXml = TransactStatus.Completed

                'Táº¡o bá»™ phÃ©p toÃ¡n cáº­p nháº­t phÃ¢n há»‡ nghiá»‡p vá»¥
                v_lngErrCode = GenAPPMAP(v_xmlDocument)
                If v_lngErrCode <> ERR_SYSTEM_OK Then
                    v_strErrorMessage = v_strErrorSource & ".Step: GenAPPMAP"
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: System error!" & vbNewLine _
                                 & "Error message: " & v_strTxDate & "." & v_strTxNum, "EventLogEntryType.Error")
                    Rollback() 'ContextUtil.SetAbort()
                    Return v_lngErrCode
                End If

                'Chuyen HostTransUpdate xuong duoi HostAppUpdate de tranh deadlock ve GL
                'Cáº­p nháº­t phÃ¢n há»‡ nghiá»‡p vá»¥
                v_lngErrCode = HostAppUpdate(v_xmlDocument)
                If v_lngErrCode <> ERR_SYSTEM_OK Then
                    v_strErrorMessage = v_strErrorSource & ".Step: HostAppUpdate"
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: System error!" & vbNewLine _
                                 & "Error message: " & v_strTxDate & "." & v_strTxNum, "EventLogEntryType.Error")
                    Rollback() 'ContextUtil.SetAbort()
                    Return v_lngErrCode
                End If
                v_lngErrCode = HostTransUpdate(v_xmlDocument)
                If v_lngErrCode <> ERR_SYSTEM_OK Then
                    v_strErrorMessage = v_strErrorSource & ".Step: HostTransUpdate"
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: System error!" & vbNewLine _
                                 & "Error message: " & v_strTxDate & "." & v_strTxNum, "EventLogEntryType.Error")
                    Rollback() 'ContextUtil.SetAbort()
                    Return v_lngErrCode
                End If

                ''Them vao de sinh phan xu ly ngan hang
                'If v_xmlDocument.DocumentElement.Attributes(gc_AtributeSTATUS).InnerXml = TransactStatus.Completed Then
                '    v_lngErrCode = CheckSend2Bank(v_xmlDocument)
                'End If

                'ReDim v_arrLogPara(1)
                'v_objLogParam = New StoreParameter
                'v_objLogParam.ParamName = "v_txdate"
                'v_objLogParam.ParamValue = v_strTxDate
                'v_objLogParam.ParamSize = v_strTxDate.Length
                'v_objLogParam.ParamType = "String"
                'v_arrLogPara(0) = v_objLogParam

                'v_objLogParam = New StoreParameter
                'v_objLogParam.ParamName = "v_txnum"
                'v_objLogParam.ParamValue = v_strTxNum
                'v_objLogParam.ParamSize = v_strTxNum.Length
                'v_objLogParam.ParamType = "String"
                'v_arrLogPara(1) = v_objLogParam
                'v_obj.ExecuteStoredNonQuerry("AUTOGENPOSTMAP", v_arrLogPara)

            End If
            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode

        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
    Private Function ExecuteDeleteAutoGV(ByVal v_strTxDate As String, ByVal v_strTxNum As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.TxRouter.ExecuteTxMessage." & v_strTxDate & "." & v_strTxNum, v_strErrorMessage As String
        Dim v_strSQL As String, v_ds As DataSet, v_obj As New DataAccess
        Dim v_strTxMsg As String, v_xmlDocument As New Xml.XmlDocument, v_objMessageLog As New MessageLog
        v_objMessageLog.NewDBInstance(gc_MODULE_HOST)
        Try
            v_obj.NewDBInstance(gc_MODULE_HOST)
            'Láº¥y ná»™i dung chi tiáº¿t cá»§a giao dá»‹ch
            v_strTxMsg = BuildXMLObjMsg(v_strTxDate, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "GetMessage", , v_strTxNum)
            v_xmlDocument.LoadXml(v_strTxMsg)
            v_lngErrCode = v_objMessageLog.TransDetail(v_xmlDocument)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            End If

            v_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value = "Y"
            v_xmlDocument.DocumentElement.Attributes(gc_AtributeSTATUS).Value = "7"


            'Thá»±c hiá»‡n giao dá»‹ch. Ä?á»‘i vá»›i giao dá»‹ch Batch thÃ¬ thá»±c hiá»‡n luÃ´n khÃ´ng cáº§n quan tÃ¢m Ä‘áº¿n sá»‘ láº§n Submit
            Dim v_strTXTYPE As String = Trim(v_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTYPE).Value.ToString)
            Dim v_intSTATUS As Integer = CInt(v_xmlDocument.DocumentElement.Attributes(gc_AtributeSTATUS).Value.ToString)
            Dim v_strDELTD As String = Trim(v_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value.ToString)
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False

            ''Kiá»ƒm tra phÃ¢n há»‡ nghiá»‡p vá»¥: Giao dich Batch khong thuc hien TXCHECK
            'v_lngErrCode = GenAPPCHK(v_xmlDocument)
            'If v_lngErrCode <> ERR_SYSTEM_OK Then
            '    v_strErrorMessage = v_strErrorSource & ".Step: GenAPPCHK"
            '    Rollback() 'ContextUtil.SetAbort()
            '    Return v_lngErrCode
            'End If
            ''Láº¥y lá»—i cá»§a phÃ¢n há»‡ nghiá»‡p vá»¥ tráº£ vá»?
            'v_lngErrCode = HostAppCheck(v_xmlDocument)

            If v_lngErrCode <> ERR_SYSTEM_OK And v_lngErrCode <> ERR_SA_CHECKER1_OVR And v_lngErrCode <> ERR_SA_CHECKER2_OVR Then
                'Lá»—i tráº£ vá»?
                v_strErrorMessage = v_strErrorSource & ".Step: HostAppCheck"
                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                             & "Error code: System error!" & vbNewLine _
                             & "Error message: " & v_strTxDate & "." & v_strTxNum, "EventLogEntryType.Error")
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            Else
                'Giao dá»‹ch trong Batch khÃ´ng quan tÃ¢m Ä‘áº¿n duyá»‡t giao dá»‹ch
                v_xmlDocument.DocumentElement.Attributes(gc_AtributeSTATUS).InnerXml = TransactStatus.Completed
                'Táº¡o POSTMAP vÃ  APPMAP
                If v_strTXTYPE <> "M" Then
                    'Táº¡o bÃºt toÃ¡n káº¿ toÃ¡n cho giao dá»‹ch Ä‘á»‹nh nghÄ©a Ä‘á»‹nh khoáº£n á»Ÿ láº§n Ä‘áº§u tiá»?n
                    v_lngErrCode = GenPOSTMAP(v_xmlDocument)
                    If v_lngErrCode <> ERR_SYSTEM_OK Then
                        v_strErrorMessage = v_strErrorSource & ".Step: GenPOSTMAP"
                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                     & "Error code: System error!" & vbNewLine _
                                     & "Error message: " & v_strTxDate & "." & v_strTxNum, "EventLogEntryType.Error")
                        Rollback() 'ContextUtil.SetAbort()
                        Return v_lngErrCode
                    End If
                End If

                v_lngErrCode = GenAPPMAP(v_xmlDocument)
                If v_lngErrCode <> ERR_SYSTEM_OK Then
                    Rollback() 'ContextUtil.SetAbort()
                    Return v_lngErrCode
                End If
                v_lngErrCode = HostAppUpdate(v_xmlDocument)
                If v_lngErrCode <> ERR_SYSTEM_OK Then
                    Rollback() 'ContextUtil.SetAbort()
                    Return v_lngErrCode
                End If

                v_lngErrCode = HostTransUpdate(v_xmlDocument)
                If v_lngErrCode <> ERR_SYSTEM_OK Then
                    Rollback() 'ContextUtil.SetAbort()
                    Return v_lngErrCode
                End If

            End If
            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode

        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function GenPRINTINFO(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.txRouter.GenPRINTINFO", v_strErrorMessage As String
        Dim v_strTLTXCD, v_strTXDATE, v_strLOCAL As String, i As Integer
        Dim v_strSQL As String, v_ds, v_ds1, v_dsTLTXCD, v_dsBANK As DataSet, v_dscf, v_dsSE As DataSet, v_obj As New DataAccess
        Dim v_strACFLD, v_strACCTNO, v_strTBLNAME, v_strFLDKEY, v_strAPPTYPE, v_strSECTYPE, v_strCUSTID As String
        Dim v_strAMTEXP, v_strVALUE, v_strISRUN As String
        Dim v_objEval As New Evaluator
        Try
            Dim v_printinfoElement As Xml.XmlElement
            Dim v_entryNode, v_nodetxData As Xml.XmlNode
            v_obj.NewDBInstance(gc_MODULE_HOST)
            v_strTLTXCD = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value.ToString
            v_strTXDATE = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value.ToString
            v_strLOCAL = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeLOCAL).Value.ToString

            'Láº¥y thÃ´ng tin Ä‘á»‹nh nghÄ©a
            'v_strSQL = "SELECT DISTINCT APPTYPE, TBLNAME, FLDKEY, ACFLD " _
            '    & "FROM V_APPCHK_BY_TLTXCD V WHERE V.TLTXCD = '" & v_strTLTXCD & "'"
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'If v_ds Is Nothing Then  'TruongLD
            v_strSQL = "SELECT DISTINCT APPTYPE, TBLNAME, FLDKEY, ACFLD, ISRUN " _
                    & "FROM V_APPCHK_BY_TLTXCD V WHERE V.TLTXCD = '" & v_strTLTXCD & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

            If v_ds.Tables(0).Rows.Count > 0 Then
                v_printinfoElement = pv_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "printinfo", "")
                For i = 0 To v_ds.Tables(0).Rows.Count - 1 Step 1
                    'Co thuc hien check hay khong
                    'Neu bang 0 thi khong thuc hien
                    v_strAMTEXP = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("ISRUN")))
                    If Len(v_strAMTEXP) > 0 Then
                        If Left(v_strAMTEXP, 1) = "@" Then
                            v_strVALUE = Mid(v_strAMTEXP, 2)
                        ElseIf Left(v_strAMTEXP, 1) = "$" Then
                            'Get field code
                            v_strVALUE = Mid(v_strAMTEXP, 2)
                            'Get field value
                            v_nodetxData = pv_xmlDocument.SelectSingleNode("TransactMessage/fields/entry[@fldname='" & v_strVALUE & "']")
                            v_strVALUE = v_nodetxData.InnerText
                        Else
                            'Armethic expression
                            v_strAMTEXP = BuildAMTEXP(pv_xmlDocument, v_strAMTEXP)
                            v_strVALUE = v_objEval.Eval(v_strAMTEXP).ToString
                        End If
                    End If
                    v_strISRUN = v_strVALUE
                    If v_strISRUN <> "0" Then
                        v_strAPPTYPE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("APPTYPE")))
                        v_strTBLNAME = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("TBLNAME")))
                        v_strFLDKEY = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("FLDKEY")))
                        v_strACFLD = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("ACFLD")))
                        v_nodetxData = pv_xmlDocument.SelectSingleNode("TransactMessage/fields/entry[@fldname='" & v_strACFLD & "']")
                        v_strACCTNO = v_nodetxData.InnerText

                        'Kiá»ƒm tra cÃ³ tá»“n táº¡i tÃ i khoáº£n khÃ´ng
                        If Len(v_strACCTNO) <> 0 And Len(v_strFLDKEY) <> 0 And v_strTBLNAME <> "SBSECURITIES" And v_strTBLNAME <> "DFMAST" And v_strTBLNAME <> "SEWITHDRAW" And v_strTBLNAME <> "SEREVERT" Then
                            'Kienvt sua ham trim
                            'v_strSQL = "SELECT * FROM " & v_strTBLNAME & " MST " _
                            '   & "WHERE TRIM(MST." & v_strFLDKEY & ") ='" & v_strACCTNO & "'"
                            v_strSQL = "SELECT * FROM " & v_strTBLNAME & " MST " _
                                & "WHERE MST." & v_strFLDKEY & " ='" & v_strACCTNO & "'"
                            v_dscf = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                            If v_dscf.Tables(0).Rows.Count = 0 Then
                                'Náº¿u tÃ i khoáº£n SE khÃ´ng cÃ³ thÃ¬ tá»± Ä‘á»™ng má»Ÿ. Náº¿u khÃ´ng thÃ¬ thÃ´ng bÃ¡o lá»—i
                                If v_strTBLNAME = "SEMAST" Then
                                    Dim v_strAFACCTNO, v_strCODEID As String
                                    v_strAFACCTNO = Left(v_strACCTNO, 10)
                                    v_strCODEID = Right(v_strACCTNO, 6)
                                    'ThanhNV: Sua thay cau lenh Insert Select = Insert Values

                                    v_strSQL = "SELECT TYP.SETYPE SETYPE, AF.CUSTID CUSTID FROM AFMAST AF, AFTYPE TYP WHERE AF.ACTYPE=TYP.ACTYPE AND AF.ACCTNO='" & v_strAFACCTNO & "'"
                                    v_ds1 = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                                    If v_ds1.Tables(0).Rows.Count > 0 Then
                                        v_strSECTYPE = v_ds1.Tables(0).Rows(0)("SETYPE")
                                        v_strCUSTID = v_ds1.Tables(0).Rows(0)("CUSTID")
                                        v_strSQL = "INSERT INTO SEMAST (ACTYPE,CUSTID,ACCTNO,CODEID,AFACCTNO," & ControlChars.CrLf _
                                                                               & "OPNDATE,LASTDATE,STATUS,IRTIED,IRCD," & ControlChars.CrLf _
                                                                               & "COSTPRICE,TRADE,MORTAGE,MARGIN,NETTING," & ControlChars.CrLf _
                                                                               & "STANDING,WITHDRAW,DEPOSIT,LOAN) " & ControlChars.CrLf _
                                                                   & " VALUES ('" & v_strSECTYPE & "', '" & v_strCUSTID & "', '" & v_strACCTNO & "', '" & v_strCODEID & "','" & v_strAFACCTNO & "'," & ControlChars.CrLf _
                                                                   & "TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'A','Y','001'," & ControlChars.CrLf _
                                                                   & "0,0,0,0,0,0,0,0,0) "
                                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                                    End If
                                ElseIf v_strTBLNAME = "REMAST" Then
                                    Dim v_strRECUSTID, v_strREACTYPE As String
                                    'Mot MG-mot loai hinh chi co mot account
                                    v_strRECUSTID = Left(v_strACCTNO, 10)
                                    v_strREACTYPE = Right(v_strACCTNO, 4)
                                    'Kiem tra moi gioi co duoc phep dung loai hinh nay khong
                                    v_strSQL = "SELECT COUNT(AUTOID) FROM (SELECT RECFDEF.AUTOID AUTOID FROM RECFDEF, RECFLNK WHERE RECFDEF.REFRECFLNKID=RECFLNK.AUTOID " & ControlChars.CrLf _
                                        & "AND RECFLNK.CUSTID= '" & v_strRECUSTID & "' AND RECFDEF.REACTYPE='" & v_strREACTYPE & "' UNION ALL " & ControlChars.CrLf _
                                        & "SELECT AUTOID FROM REGRP WHERE CUSTID= '" & v_strRECUSTID & "' AND ACTYPE='" & v_strREACTYPE & "')"
                                    v_ds1 = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                                    If v_ds1.Tables(0).Rows.Count = 1 Then
                                        If v_ds1.Tables(0).Rows(0)(0) = 0 Then
                                            LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                                         & "Error code: System error!" & vbNewLine _
                                                         & "Error message: " & ControlChars.CrLf & v_strSQL & ControlChars.CrLf & ERR_REMISER_ACCOUNT_INVALID_ACTYPE, "EventLogEntryType.Error")
                                            Rollback() 'ContextUtil.SetAbort()
                                            Return ERR_REMISER_ACCOUNT_INVALID_ACTYPE
                                        Else
                                            'Tu dong mo REMAST
                                            v_strSQL = "INSERT INTO REMAST (ACCTNO,CUSTID,ACTYPE,STATUS,LAST_CHANGE,RATECOMM,BALANCE, " _
                                                & "DAMTACR,DAMTLASTDT,IAMTACR,IAMTLASTDT,DIRECTACR,INDIRECTACR,ODFEETYPE,ODFEERATE,COMMTYPE,LASTCOMMDATE)" & ControlChars.CrLf _
                                                & "SELECT '" & v_strACCTNO & "', '" & v_strRECUSTID & "', '" & v_strREACTYPE & "', 'A', SYSTIMESTAMP, RATECOMM, 0, 0,TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'), " & ControlChars.CrLf _
                                                & "0, TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),0,0,ODFEETYPE,ODFEERATE,COMMTYPE, TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') " & ControlChars.CrLf _
                                                & "FROM RETYPE WHERE ACTYPE='" & v_strREACTYPE & "'"
                                            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                                        End If
                                    End If

                                Else
                                    'Lá»—i
                                    If Not (v_dscf Is Nothing) Then
                                        v_dscf.Dispose()
                                    End If
                                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                                 & "Error code: System error!" & vbNewLine _
                                                 & "Error message: " & ControlChars.CrLf & v_strSQL & ControlChars.CrLf & ERR_SA_PRINTINFO_ACCTNOTFOUND, "EventLogEntryType.Error")
                                    Rollback() 'ContextUtil.SetAbort()
                                    Return ERR_SA_PRINTINFO_ACCTNOTFOUND
                                End If
                            End If
                        End If

                        If Len(v_strACCTNO) <> 0 And Len(v_strFLDKEY) <> 0 And v_strTBLNAME <> "SBSECURITIES" And v_strTBLNAME <> "SEWITHDRAW" _
                            And (Not v_strTBLNAME = "CAMAST") And (Not v_strTBLNAME = "DFTYPE") And (Not v_strTBLNAME = "SEREVERT") Then 'Thá»±c hiá»‡n quyá»?n khÃ´ng cÃ³ thÃ´ng tin khÃ¡ch hÃ ng 
                            'Láº¥y thÃ´ng tin khÃ¡ch hÃ ng
                            If v_strTBLNAME = "AFMAST" Then
                                'Náº¿u lÃ  há»£p Ä‘á»“ng
                                v_strSQL = "SELECT CFMAST.FULLNAME CUSTNAME, CFMAST.ADDRESS, CFMAST.IDCODE LICENSE, TO_CHAR(CFMAST.IDDATE,'" & gc_FORMAT_DATE_Db & "') IDDATE, CFMAST.IDPLACE, CFMAST.CUSTODYCD,MST.BANKACCTNO,MST.BANKNAME " _
                                    & "FROM CFMAST, " & v_strTBLNAME & " MST " _
                                    & "WHERE CFMAST.CUSTID = MST.CUSTID AND " _
                                    & "MST." & v_strFLDKEY & " ='" & v_strACCTNO & "'"
                            ElseIf v_strTBLNAME = "LNMAST" Then
                                v_strSQL = "SELECT CFMAST.FULLNAME CUSTNAME, CFMAST.ADDRESS, CFMAST.IDCODE LICENSE, TO_CHAR(CFMAST.IDDATE,'" & gc_FORMAT_DATE_Db & "') IDDATE, CFMAST.IDPLACE, CFMAST.CUSTODYCD  " _
                                    & "FROM CFMAST, CIMAST, " & v_strTBLNAME & " MST " _
                                    & "WHERE CFMAST.CUSTID = CIMAST.CUSTID AND CIMAST.ACCTNO=MST.TRFACCTNO AND " _
                                    & "MST." & v_strFLDKEY & " ='" & v_strACCTNO & "'"
                            ElseIf v_strTBLNAME = "REMAST" Then
                                v_strSQL = "SELECT CFMAST.FULLNAME CUSTNAME, CFMAST.ADDRESS, CFMAST.IDCODE LICENSE, TO_CHAR(CFMAST.IDDATE,'" & gc_FORMAT_DATE_Db & "') IDDATE, CFMAST.IDPLACE, CFMAST.CUSTODYCD  " _
                                    & "FROM CFMAST, " & v_strTBLNAME & " MST " _
                                    & "WHERE CFMAST.CUSTID = MST.CUSTID AND " _
                                    & "MST." & v_strFLDKEY & " ='" & v_strACCTNO & "'"
                            ElseIf v_strTBLNAME = "LNAPPL" Then
                                v_strSQL = "SELECT CFMAST.FULLNAME CUSTNAME, CFMAST.ADDRESS, CFMAST.IDCODE LICENSE, TO_CHAR(CFMAST.IDDATE,'" & gc_FORMAT_DATE_Db & "') IDDATE, CFMAST.IDPLACE, CFMAST.CUSTODYCD " _
                                    & "FROM CFMAST, " & v_strTBLNAME & " MST " _
                                    & "WHERE CFMAST.CUSTID = MST.CUSTID AND MST." & v_strFLDKEY & " = '" & v_strACCTNO & "' "
                            ElseIf v_strTBLNAME = "LMMAST" Or v_strTBLNAME = "CLMAST" Or v_strTBLNAME = "GRMAST" Then
                                v_strSQL = "SELECT CFMAST.FULLNAME CUSTNAME, CFMAST.CUSTID, CFMAST.ADDRESS, CFMAST.IDCODE LICENSE, TO_CHAR(CFMAST.IDDATE,'" & gc_FORMAT_DATE_Db & "') IDDATE, CFMAST.IDPLACE, CFMAST.CUSTODYCD " _
                                    & "FROM CFMAST, " & v_strTBLNAME & " MST " _
                                    & "WHERE CFMAST.CUSTID = MST.CUSTID AND " _
                                    & "MST." & v_strFLDKEY & " ='" & v_strACCTNO & "'"
                            Else

                                If v_strTBLNAME = "CFMAST" Then
                                    'Kienvt sua ham trim
                                    'v_strSQL = "SELECT FULLNAME CUSTNAME, CFMAST.ADDRESS, CFMAST.IDCODE LICENSE, CFMAST.CUSTODYCD " _
                                    '         & "FROM CFMAST  " _
                                    '         & "WHERE  " _
                                    '         & "TRIM(CFMAST." & v_strFLDKEY & ") ='" & v_strACCTNO & "'"

                                    v_strSQL = "SELECT CFMAST.FULLNAME CUSTNAME, CFMAST.ADDRESS, CFMAST.IDCODE LICENSE, TO_CHAR(CFMAST.IDDATE,'" & gc_FORMAT_DATE_Db & "') IDDATE, CFMAST.IDPLACE, CFMAST.CUSTODYCD " _
                                             & "FROM CFMAST  " _
                                             & "WHERE  " _
                                             & "CFMAST." & v_strFLDKEY & " ='" & v_strACCTNO & "'"
                                    'ElseIf v_strTBLNAME = "SBSECURITIES" Then
                                    'Them doan nay de tranh check dieu kien CareBy 
                                Else
                                    'Náº¿u lÃ  báº£ng cá»§a phÃ¢n há»‡ nghiá»‡p vá»¥ sáº½ pháº£i Link qua AFMAST
                                    v_strSQL = "SELECT CFMAST.FULLNAME CUSTNAME, CFMAST.ADDRESS, CFMAST.IDCODE LICENSE, TO_CHAR(CFMAST.IDDATE,'" & gc_FORMAT_DATE_Db & "') IDDATE, CFMAST.IDPLACE, CFMAST.CUSTODYCD ,AFMAST.BANKACCTNO,AFMAST.BANKNAME " _
                                        & "FROM CFMAST, AFMAST, " & v_strTBLNAME & " MST " _
                                        & "WHERE CFMAST.CUSTID = AFMAST.CUSTID AND AFMAST.ACCTNO=MST.AFACCTNO AND " _
                                        & "MST." & v_strFLDKEY & " ='" & v_strACCTNO & "'"
                                End If
                            End If
                            v_dscf = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                            If v_dscf.Tables(0).Rows.Count = 0 Then
                                If Not (v_dscf Is Nothing) Then
                                    v_dscf.Dispose()
                                End If
                                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                             & "Error code: System error!" & vbNewLine _
                                             & "Error message: " & ControlChars.CrLf & v_strSQL & ControlChars.CrLf & ERR_CF_CUSTOM_NOTFOUND, "EventLogEntryType.Error")
                                Rollback() 'ContextUtil.SetAbort()
                                Return ERR_CF_CUSTOM_NOTFOUND
                            End If
                            Dim v_strCUSTNAME As String = Trim(gf_CorrectStringField(v_dscf.Tables(0).Rows(0)("CUSTNAME")))
                            Dim v_strADDRESS As String = Trim(gf_CorrectStringField(v_dscf.Tables(0).Rows(0)("ADDRESS")))
                            Dim v_strLICENSE As String = Trim(gf_CorrectStringField(v_dscf.Tables(0).Rows(0)("LICENSE")))
                            Dim v_strCUSTODYCD As String = Trim(gf_CorrectStringField(v_dscf.Tables(0).Rows(0)("CUSTODYCD")))
                            'Dim v_strIDDATE As String = Format(gf_CorrectDateField(v_dscf.Tables(0).Rows(0)("IDDATE")), gc_FORMAT_DATE)  'DDMMYYYY_SystemDate(gf_CorrectDateField(v_dscf.Tables(0).Rows(0)("IDDATE"))).ToString(gc_FORMAT_DATE)
                            Dim v_strIDDATE As String = gf_CorrectStringField(v_dscf.Tables(0).Rows(0)("IDDATE"))
                            Dim v_strIDPLACE As String = Trim(gf_CorrectStringField(v_dscf.Tables(0).Rows(0)("IDPLACE")))


                            'Táº¡o cáº¥u trÃºc thÃ´ng tin khÃ¡ch hÃ ng
                            v_entryNode = pv_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "entry", "")

                            If v_strTBLNAME = "CIMAST" Then
                                'v_strSQL = "SELECT MSQRQR FROM TLTX WHERE TLTXCD='" & v_strTLTXCD & "'"
                                'v_dsTLTXCD = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                                'If v_dsTLTXCD.Tables(0).Rows.Count > 0 Then
                                '    Dim v_strMSGRQR As String = Trim(gf_CorrectStringField(v_dsTLTXCD.Tables(0).Rows(0)("MSQRQR")))
                                '    If v_strMSGRQR = "Y" Then

                                '    End If
                                'End If
                                'Giao dich ket noi toi corebank
                                'Lay ra thong tin BANKACCTNO,BANKNAME,HOLD AMOUNT, OUTBOX QUEUE
                                v_strSQL = "SELECT AF.ACCTNO,CI.HOLDBALANCE HOLDAMT,CI.PENDINGHOLD,CI.PENDINGUNHOLD," & vbCrLf &
                                            "AF.BANKACCTNO BANKACCT,(CRB.BANKCODE || ':' || CRB.BANKNAME) BANKNAME,CRB.BANKCODE BANKQUE" & vbCrLf &
                                            "FROM CIMAST CI, AFMAST AF, CRBDEFBANK CRB" & vbCrLf &
                                            "WHERE CI.AFACCTNO = AF.ACCTNO AND AF.BANKNAME = CRB.BANKCODE" & vbCrLf &
                                            "AND CI.ACCTNO='" & v_strACCTNO & "'"
                                v_dsBANK = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                                If v_dsBANK.Tables(0).Rows.Count > 0 Then
                                    Dim v_strHOLDEDAMT As String = Trim(gf_CorrectStringField(v_dsBANK.Tables(0).Rows(0)("HOLDAMT")))
                                    Dim v_strPENDINGHOLD As String = Trim(gf_CorrectStringField(v_dsBANK.Tables(0).Rows(0)("PENDINGHOLD")))
                                    Dim v_strPENDINGUNHOLD As String = Trim(gf_CorrectStringField(v_dsBANK.Tables(0).Rows(0)("PENDINGUNHOLD")))
                                    Dim v_strBANKACCT As String = Trim(gf_CorrectStringField(v_dsBANK.Tables(0).Rows(0)("BANKACCT")))
                                    Dim v_strBANKNAME As String = Trim(gf_CorrectStringField(v_dsBANK.Tables(0).Rows(0)("BANKNAME")))
                                    Dim v_strBANKQUE As String = Trim(gf_CorrectStringField(v_dsBANK.Tables(0).Rows(0)("BANKQUE")))


                                    Dim v_attrHOLDAMT As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("holdamt")
                                    v_attrHOLDAMT.Value = v_strHOLDEDAMT
                                    v_entryNode.Attributes.Append(v_attrHOLDAMT)

                                    Dim v_attrPENDINGHOLD As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("pendingholdamt")
                                    v_attrPENDINGHOLD.Value = v_strPENDINGHOLD
                                    v_entryNode.Attributes.Append(v_attrPENDINGHOLD)

                                    Dim v_attrPENDINGUNHOLD As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("pendingunholdamt")
                                    v_attrPENDINGUNHOLD.Value = v_strPENDINGUNHOLD
                                    v_entryNode.Attributes.Append(v_attrPENDINGUNHOLD)

                                    Dim v_attrBANKACCT As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("bankacct")
                                    v_attrBANKACCT.Value = v_strBANKACCT
                                    v_entryNode.Attributes.Append(v_attrBANKACCT)

                                    Dim v_attrBANKNAME As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("bankname")
                                    v_attrBANKNAME.Value = v_strBANKNAME
                                    v_entryNode.Attributes.Append(v_attrBANKNAME)

                                    Dim v_attrBANKQUE As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("bankque")
                                    v_attrBANKQUE.Value = v_strBANKQUE
                                    v_entryNode.Attributes.Append(v_attrBANKQUE)
                                End If
                            End If


                            Dim v_attrACFLD As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("fldname")
                            v_attrACFLD.Value = v_strACFLD
                            v_entryNode.Attributes.Append(v_attrACFLD)

                            Dim v_attrCUSTNAME As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("custname")
                            v_attrCUSTNAME.Value = v_strCUSTNAME
                            v_entryNode.Attributes.Append(v_attrCUSTNAME)

                            Dim v_attrADDRESS As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("address")
                            v_attrADDRESS.Value = v_strADDRESS
                            v_entryNode.Attributes.Append(v_attrADDRESS)

                            Dim v_attrLICENSE As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("license")
                            v_attrLICENSE.Value = v_strLICENSE
                            v_entryNode.Attributes.Append(v_attrLICENSE)

                            Dim v_attrIDDATE As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("iddate")
                            v_attrIDDATE.Value = v_strIDDATE
                            v_entryNode.Attributes.Append(v_attrIDDATE)

                            Dim v_attrIDPLACE As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("idplace")
                            v_attrIDPLACE.Value = v_strIDPLACE
                            v_entryNode.Attributes.Append(v_attrIDPLACE)

                            Dim v_attrCUSTODY As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("custody")
                            v_attrCUSTODY.Value = v_strCUSTODYCD
                            v_entryNode.Attributes.Append(v_attrCUSTODY)

                            v_entryNode.InnerText = v_strACCTNO
                            v_printinfoElement.AppendChild(v_entryNode)
                        End If
                    End If

                Next

                pv_xmlDocument.DocumentElement.AppendChild(v_printinfoElement)
            End If

            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If
            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function GenPOSTMAP(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.txRouter.GenPOSTMAP", v_strErrorMessage As String

        Try
            Dim v_strSQL As String, v_ds As DataSet, v_dsapp, v_dsCA, v_dsse, v_dsCustody As DataSet, v_dsCURRENCY As DataSet, v_obj As New DataAccess
            Dim i As Integer
            v_obj.NewDBInstance(gc_MODULE_HOST)

            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value.ToString
            Dim v_strTLTXCD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value.ToString
            Dim v_strCCYUSAGE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCCYUSAGE).Value.ToString
            Dim v_strIBT As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeIBT).Value.ToString
            Dim v_strBRID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value.ToString
            Dim v_strBRID2 As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID2).Value.ToString
            Dim EntryBRID As String
            Dim v_strVALUE As String
            Dim v_strACC_BRID, v_strSETYPE, v_strCUSTID As String

            ''Kiem tran neu offpostmap thi khong sinh GL nua
            'v_strSQL = "SELECT OFFPOSTMAP FROM TLTX WHERE  TLTXCD = '" & v_strTLTXCD & "'"
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'If v_ds.Tables(0).Rows.Count > 0 Then
            '    If v_ds.Tables(0).Rows(0)("OFFPOSTMAP") = "Y" Then
            '        Return ERR_SYSTEM_OK
            '    End If
            'End If

            'Dim EntrySUBTXNO, EntryDORC, EntryACCTNO, EntryCCYCD, EntryDEC As String
            Dim v_objEval As New Evaluator
            Dim EntrySUBTXNO, EntryDORC, EntryACCTNO, EntryCCYCD, EntryDEC, EntryFEECD, EntryGLGRP As String
            Dim EntryCUSTID, EntryCUSTNAME, EntryTASKCD, EntryDEPTCD, EntryMICD As String
            Dim EntryAMOUNT As Double
            Dim v_strACCTNO, v_strACNAME, v_strFLDTYPE, v_strFLDCCY, v_strACFLD, v_strREFFLD, v_strAMTEXP, v_strNEGATIVECD As String
            Dim v_strISRUN As String
            Dim v_nodeGenChecking As Xml.XmlNode
            v_nodeGenChecking = pv_xmlDocument.SelectSingleNode("/TransactMessage/postmap")
            'KhÃ´ng táº¡o POSTMAP náº¿u Ä‘Ã£ cÃ³
            If Not v_nodeGenChecking Is Nothing Then Return ERR_SYSTEM_OK

            'Create Posting Node
            Dim v_mitranElement As Xml.XmlElement
            Dim v_postingElement As Xml.XmlElement
            Dim v_entryNode As Xml.XmlNode
            Dim v_nodetxData As Xml.XmlNode

            'Ä?á»?c thÃ´ng tin vá»? Ä‘iá»‡n giao dá»‹ch

            'Kiem tra tai khoan khach hang da ton tai chua
            Dim v_strTXDATE, v_strLOCAL As String
            Dim v_dscf As DataSet
            Dim v_strTBLNAME, v_strFLDKEY, v_strAPPTYPE As String
            'v_strSQL = "SELECT DISTINCT APPTYPE, TBLNAME, FLDKEY, ACFLD " _
            '    & "FROM V_APPCHK_BY_TLTXCD V WHERE V.TLTXCD = '" & v_strTLTXCD & "'"
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'Get caching information
            'If v_ds Is Nothing Then 'TruongLD
            v_strSQL = "SELECT DISTINCT APPTYPE, TBLNAME, FLDKEY, ACFLD " _
                    & "FROM V_APPCHK_BY_TLTXCD V WHERE V.TLTXCD = '" & v_strTLTXCD & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

            If v_ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To v_ds.Tables(0).Rows.Count - 1 Step 1
                    v_strAPPTYPE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("APPTYPE")))
                    v_strTBLNAME = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("TBLNAME")))
                    v_strFLDKEY = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("FLDKEY")))
                    v_strACFLD = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("ACFLD")))
                    v_nodetxData = pv_xmlDocument.SelectSingleNode("TransactMessage/fields/entry[@fldname='" & v_strACFLD & "']")
                    v_strACCTNO = v_nodetxData.InnerText
                    If Len(v_strACCTNO) <> 0 And Len(v_strFLDKEY) <> 0 And v_strTBLNAME <> "SEWITHDRAW" Then
                        'Kienvt sua ham trim
                        'v_strSQL = "SELECT * FROM " & v_strTBLNAME & " MST " _
                        '    & "WHERE TRIM(MST." & v_strFLDKEY & ") ='" & v_strACCTNO & "'"
                        v_strSQL = "SELECT * FROM " & v_strTBLNAME & " MST " _
                            & "WHERE MST." & v_strFLDKEY & " ='" & v_strACCTNO & "'"
                        v_dscf = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                        If v_dscf.Tables(0).Rows.Count = 0 Then
                            'If SE account does not exist, then open!
                            If v_strTBLNAME = "SEMAST" Then
                                Dim v_strAFACCTNO, v_strCODEID As String
                                v_strAFACCTNO = Left(v_strACCTNO, 10)
                                v_strCODEID = Right(v_strACCTNO, 6)
                                'Open new SE Account
                                'v_strSQL = " insert into semast " & ControlChars.CrLf _
                                '        & " (ACTYPE,CUSTID,ACCTNO,CODEID,AFACCTNO, " & ControlChars.CrLf _
                                '        & " OPNDATE,LASTDATE,COSTDT,TBALDT,STATUS,IRTIED,IRCD, " & ControlChars.CrLf _
                                '        & " COSTPRICE,TRADE,MORTAGE,MARGIN,NETTING, " & ControlChars.CrLf _
                                '        & " STANDING,WITHDRAW,DEPOSIT,LOAN) " & ControlChars.CrLf _
                                '        & " select AFT.setype, AF.custid, '" & v_strACCTNO & "','" & v_strCODEID & "','" & v_strAFACCTNO & "', " & ControlChars.CrLf _
                                '        & " TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'), " & ControlChars.CrLf _
                                '        & " 'A','Y','000', " & ControlChars.CrLf _
                                '        & " 0,0,0,0,0,0,0,0,0  " & ControlChars.CrLf _
                                '        & " from afmast AF, aftype AFT " & ControlChars.CrLf _
                                '        & " where AF.actype=AFT.actype and AF.acctno='" & v_strAFACCTNO & "'"
                                'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)


                                'ThanhNV: Sua thay cau lenh Insert Select = Insert Values

                                v_strSQL = "SELECT TYP.SETYPE SETYPE, AF.CUSTID CUSTID FROM AFMAST AF, AFTYPE TYP WHERE AF.ACTYPE=TYP.ACTYPE AND AF.ACCTNO='" & v_strAFACCTNO & "'"
                                v_dsse = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                                If v_dsse.Tables(0).Rows.Count > 0 Then
                                    v_strSETYPE = v_dsse.Tables(0).Rows(0)("SETYPE")
                                    v_strCUSTID = v_dsse.Tables(0).Rows(0)("CUSTID")
                                    v_strSQL = "INSERT INTO SEMAST (ACTYPE,CUSTID,ACCTNO,CODEID,AFACCTNO," & ControlChars.CrLf _
                                                                           & "OPNDATE,LASTDATE,STATUS,IRTIED,IRCD," & ControlChars.CrLf _
                                                                           & "COSTPRICE,TRADE,MORTAGE,MARGIN,NETTING," & ControlChars.CrLf _
                                                                           & "STANDING,WITHDRAW,DEPOSIT,LOAN) " & ControlChars.CrLf _
                                                               & " VALUES ('" & v_strSETYPE & "', '" & v_strCUSTID & "', '" & v_strACCTNO & "', '" & v_strCODEID & "','" & v_strAFACCTNO & "'," & ControlChars.CrLf _
                                                               & "TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'A','Y','001'," & ControlChars.CrLf _
                                                               & "0,0,0,0,0,0,0,0,0) "
                                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                                End If
                            Else
                                'On errors
                                If Not (v_dscf Is Nothing) Then
                                    v_dscf.Dispose()
                                End If
                                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                             & "Error code: System error!" & vbNewLine _
                                             & "Error message: " & ControlChars.CrLf & v_strSQL & ControlChars.CrLf & ERR_SA_PRINTINFO_ACCTNOTFOUND, "EventLogEntryType.Error")
                                Rollback() 'ContextUtil.SetAbort()
                                Return ERR_SA_PRINTINFO_ACCTNOTFOUND
                            End If
                        End If
                    End If
                Next
            End If


            'Xác định loại IBT của giao dịch
            Dim v_strHOBRID As String   'Lấy mã chi nhánh của HOBRID
            i = 0
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "HOBRID", v_strHOBRID)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Return v_lngErrCode
            End If

            'Căn cứ vào MSGACCT & BRID để kiểm tra giao dịch có phải là IBT không
            Dim v_strACCTFLDCD, v_strBRIDCD, v_strACCTVALUE, v_isIBT As String
            v_strIBT = "0"
            v_strSQL = "SELECT MSG_ACCT ACCTFLDCD, IBT FROM TLTX WHERE TLTXCD = '" & v_strTLTXCD & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_strACCTFLDCD = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("ACCTFLDCD")))
            End If

            'Neu co dinh nghia BRID trong POSTMAP thi dung BRID nay
            v_strSQL = "SELECT BRID FROM POSTMAP WHERE TLTXCD = '" & v_strTLTXCD & "' AND BRID <> '----'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_strBRIDCD = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("BRID")))
                If v_strBRIDCD > 4 Then
                    v_nodetxData = pv_xmlDocument.SelectSingleNode("TransactMessage/fields/entry[@fldname='" & v_strBRIDCD & "']")
                    v_strBRID = v_nodetxData.InnerText.Trim
                    If v_strBRID.Length > 4 Then v_strBRID = v_strBRID.Substring(0, 4)
                End If
            End If

            'Xác định IBT
            If v_strACCTFLDCD.Length > 0 Then
                v_strBRID = v_strBRID.Trim
                v_nodetxData = pv_xmlDocument.SelectSingleNode("TransactMessage/fields/entry[@fldname='" & v_strACCTFLDCD & "']")
                v_strACCTVALUE = v_nodetxData.InnerText.Trim
                If v_strACCTVALUE.Length >= 4 Then
                    If String.Compare(v_strACCTVALUE.Substring(0, 2), v_strBRID.Substring(0, 2)) = 0 Then
                        'Tài khoản của chính chi nhánh
                        v_strIBT = "0"
                    Else
                        'Tài khoản giao dịch tại chi nhánh khác
                        If String.Compare(v_strBRID.Substring(0, 2), v_strHOBRID.Substring(0, 2)) = 0 Then
                            'Chi nhánh tạo giao dịch là hội sở
                            v_strIBT = "2"
                        Else
                            'Chi nhánh tạo giao dịch không phải là hội sở
                            If String.Compare(v_strACCTVALUE.Substring(0, 2), v_strHOBRID.Substring(0, 2)) = 0 Then
                                'Tài khoản là của hội sở
                                v_strIBT = "1"
                            Else
                                'Tài khoản là của chi nhánh khác
                                v_strIBT = "3"
                            End If
                        End If
                    End If
                Else
                    v_strIBT = "0"
                End If
            End If

            'If v_strBRID = "0000" Then
            '    'Giao dịch Batch: không có IBT
            '    v_strIBT = "0"
            'Else
            'End If

            v_strSQL = "SELECT * FROM " _
                         & "(SELECT POSTMAP.*, REF.GLACCTNO ACCTNO, REF.FEECD FROM POSTMAP, FEEMASTER REF, FEEMAP WHERE POSTMAP.ACNAME='FEEMAST' " _
                         & " AND POSTMAP.TLTXCD=FEEMAP.TLTXCD AND FEEMAP.FEECD=REF.FEECD " _
                         & " AND POSTMAP.TLTXCD = '" & v_strTLTXCD & "' AND POSTMAP.IBT = '" & v_strIBT & "' AND POSTMAP.FLDTYPE = 'F' " _
                         & " UNION ALL " _
                         & " SELECT POSTMAP.*, REF.ACCTNO, NULL FEECD FROM POSTMAP, GLREFCOM REF WHERE POSTMAP.ACNAME = REF.ACNAME AND POSTMAP.ACNAME<>'FEEMAST' " _
                         & " AND POSTMAP.TLTXCD = '" & v_strTLTXCD & "' AND POSTMAP.IBT = '" & v_strIBT & "' AND POSTMAP.FLDTYPE = 'F' " _
                         & " UNION ALL " _
                         & " SELECT POSTMAP.*, NULL ACCTNO, NULL FEECD FROM POSTMAP WHERE 0=0 " _
                         & " AND POSTMAP.TLTXCD = '" & v_strTLTXCD & "' AND POSTMAP.IBT = '" & v_strIBT & "' AND POSTMAP.FLDTYPE = 'V') MAP " _
                         & " ORDER BY SUBTXNO, DORC DESC"                         'Th? t? ORDER BY l quan tr?ng khng du?c thay d?i
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

            If v_ds.Tables(0).Rows.Count > 0 Then
                Dim arrPOSTMAP(4, v_ds.Tables(0).Rows.Count), arrENTRY(4, v_ds.Tables(0).Rows.Count) As String
                Dim j, intCountPostmap, intCountEntry As Integer, blnFound As Boolean = False
                intCountPostmap = 0
                intCountEntry = 0
                v_postingElement = pv_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "postmap", "")
                v_mitranElement = pv_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "mitran", "")
                For i = 0 To v_ds.Tables(0).Rows.Count - 1
                    v_strAMTEXP = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("ISRUN")))
                    If Len(v_strAMTEXP) > 0 Then
                        If Left(v_strAMTEXP, 1) = "@" Then
                            v_strVALUE = Mid(v_strAMTEXP, 2)
                        ElseIf Left(v_strAMTEXP, 1) = "$" Then
                            'Get field code
                            v_strVALUE = Mid(v_strAMTEXP, 2)
                            'Get field value
                            v_nodetxData = pv_xmlDocument.SelectSingleNode("TransactMessage/fields/entry[@fldname='" & v_strVALUE & "']")
                            v_strVALUE = v_nodetxData.InnerText
                        ElseIf v_strAMTEXP = "<$BUSDATE>" Then
                            'Get business date
                            v_strVALUE = v_strTXDATE
                        Else
                            'Armethic expression
                            v_strAMTEXP = BuildAMTEXP(pv_xmlDocument, v_strAMTEXP)
                            v_strVALUE = v_objEval.Eval(v_strAMTEXP).ToString
                        End If
                    End If
                    v_strISRUN = v_strVALUE
                    If v_strISRUN <> "0" Then
                        v_strACNAME = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("ACNAME")))
                        v_strNEGATIVECD = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("NEGATIVECD")))
                        v_strFLDCCY = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("FLDCCY")))
                        v_strACFLD = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("ACFLD")))
                        v_strREFFLD = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("REFFLD")))
                        v_strFLDTYPE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("FLDTYPE")))
                        v_strAMTEXP = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("AMTEXP")))
                        EntryFEECD = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("FEECD")))
                        EntrySUBTXNO = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("SUBTXNO")))
                        EntryDORC = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("DORC")))

                        v_nodetxData = pv_xmlDocument.SelectSingleNode("TransactMessage/fields/entry[@fldname='" & v_strACFLD & "']")
                        EntryBRID = v_nodetxData.InnerText
                        If EntryBRID.Length > 4 Then EntryBRID = EntryBRID.Substring(0, 4)

                        'CÃ¡c tham sá»‘ Ä‘á»ƒ ghi nháº­n cho GLMIS
                        EntryCUSTID = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("FLDCUSTID")))
                        If Len(EntryCUSTID) > 0 Then
                            v_nodetxData = pv_xmlDocument.SelectSingleNode("TransactMessage/fields/entry[@fldname='" & EntryCUSTID & "']")
                            EntryCUSTID = Replace(v_nodetxData.InnerText, ".", "")
                        End If
                        EntryCUSTNAME = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("FLDCUSTNAME")))
                        If Len(EntryCUSTNAME) > 0 Then
                            v_nodetxData = pv_xmlDocument.SelectSingleNode("TransactMessage/fields/entry[@fldname='" & EntryCUSTNAME & "']")
                            EntryCUSTNAME = Replace(v_nodetxData.InnerText, ".", "")
                        End If
                        EntryTASKCD = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("FLDTASKCD")))
                        If Len(EntryTASKCD) > 0 Then
                            v_nodetxData = pv_xmlDocument.SelectSingleNode("TransactMessage/fields/entry[@fldname='" & EntryTASKCD & "']")
                            EntryTASKCD = Replace(v_nodetxData.InnerText, ".", "")
                        End If
                        EntryDEPTCD = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("FLDDEPTCD")))
                        If Len(EntryDEPTCD) > 0 Then
                            v_nodetxData = pv_xmlDocument.SelectSingleNode("TransactMessage/fields/entry[@fldname='" & EntryDEPTCD & "']")
                            EntryDEPTCD = Replace(v_nodetxData.InnerText, ".", "")
                        End If
                        EntryMICD = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("FLDMICD")))
                        If Len(EntryMICD) > 0 Then
                            v_nodetxData = pv_xmlDocument.SelectSingleNode("TransactMessage/fields/entry[@fldname='" & EntryMICD & "']")
                            EntryMICD = Replace(v_nodetxData.InnerText, ".", "")
                        End If

                        'Xac dinh loai tien
                        v_nodetxData = pv_xmlDocument.SelectSingleNode("TransactMessage/fields/entry[@fldname='" & Right(v_strFLDCCY, 2) & "']")
                        If Len(v_strFLDCCY) <> 0 Then
                            If Left(v_strFLDCCY, 2) = "@@" Then
                                'Lay truc tiep
                                EntryCCYCD = v_nodetxData.InnerText
                            Else
                                'Láº¥y báº±ng vá»‹ trÃ­ POS_CCY
                                EntryCCYCD = Mid(v_nodetxData.InnerText, POS_CCYCD, 2)
                            End If
                        Else
                            'Loáº¡i tiá»?n máº·c Ä‘á»‹nh
                            EntryCCYCD = BASED_CCYCD
                        End If


                        EntryDEC = EntryCCYCD
                        v_strSQL = "SELECT CCYDECIMAL FROM SBCURRENCY WHERE CCYCD = '" & EntryCCYCD & "'"
                        v_dsCURRENCY = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                        If v_dsCURRENCY.Tables(0).Rows.Count > 0 Then
                            EntryDEC = Trim(gf_CorrectStringField(v_dsCURRENCY.Tables(0).Rows(0)("CCYDECIMAL")))
                        Else
                            EntryDEC = BASED_CCYCD_DECIMAL
                        End If

                        'Specifies amount
                        If EntryFEECD.Trim.Length > 0 Then
                            'N?u có FEECD thì s? ti?n du?c tính toán l?y trong b?ng FEEMAP g?i lên
                            v_nodetxData = pv_xmlDocument.SelectSingleNode("TransactMessage/feemap/entry[@feecd='" & EntryFEECD & "']")
                            EntryAMOUNT = v_nodetxData.InnerText
                        Else
                            'X? lý thông thu?ng
                            v_strAMTEXP = BuildAMTEXP(pv_xmlDocument, v_strAMTEXP)
                            EntryAMOUNT = CDbl(v_objEval.Eval(v_strAMTEXP).ToString)
                        End If


                        'Specifies account number
                        Dim v_strGLGRP As String = String.Empty
                        Dim v_strTRADEPLACE As String = String.Empty
                        Dim v_strSECTYPE As String = String.Empty
                        EntryACCTNO = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("ACCTNO")))
                        If Len(Trim(EntryACCTNO)) = 0 Then
                            'Get customer account
                            Dim v_strAPP As String = Left(v_strACNAME, 2)
                            Dim v_strAPPREF As String = Right(v_strACNAME, 2)
                            'Lay catype
                            Dim v_strCATYPE As String = String.Empty
                            If v_strAPPREF = SUB_SYSTEM_CA Then
                                'Dim v_strcamastid As String = pv_xmlDocument.DocumentElement.Attributes("CAMASTID").Value.ToString

                                v_nodetxData = pv_xmlDocument.SelectSingleNode("TransactMessage/fields/entry[@defname='CAMASTID']")
                                Dim v_strcamastid As String = v_nodetxData.InnerText
                                v_strSQL = "SELECT CATYPE from camast where camastid = '" & v_strcamastid & "' "
                                v_dsCA = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                                If v_dsCA.Tables(0).Rows.Count > 0 Then
                                    v_strCATYPE = gf_CorrectStringField(v_dsCA.Tables(0).Rows(0)("CATYPE"))
                                End If
                            End If


                            v_nodetxData = pv_xmlDocument.SelectSingleNode("TransactMessage/fields/entry[@fldname='" & v_strACFLD & "']")
                            v_strACCTNO = v_nodetxData.InnerText

                            If Trim(v_strACNAME) = "CINETMARKET" Or Trim(v_strACNAME) = "CINETMARKETRM" Or Trim(v_strACNAME) = "CINETCLR" Or Trim(v_strACNAME) = "CINETCLRRM" Or Trim(v_strACNAME) = "CIINVEST" Or Trim(v_strACNAME) = "CIINVESTRM" Or Trim(v_strACNAME) = "CIINVESTRE" Or Trim(v_strACNAME) = "SEINVEBOCA" Then
                                'Xá»­ lÃ½ riÃªng cho tÃ i khoáº£n thanh toÃ¡n bÃ¹ trá»« vá»›i NHCÄ?TT. v_strACFLD sáº½ chá»‰ ra lÃ  tÃ i khoáº£n SE liÃªn quan
                                'Kienvt sua ham trim
                                v_strSQL = "SELECT SBSECURITIES.SECTYPE, SBSECURITIES.TRADEPLACE, TYP.GLGRP FROM SBSECURITIES, SETYPE TYP, SEMAST MST " _
                                        & " WHERE MST.CODEID=SBSECURITIES.CODEID AND TYP.ACTYPE = MST.ACTYPE AND MST.ACCTNO = '" & v_strACCTNO & "' "
                                v_dsapp = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

                                If v_dsapp.Tables(0).Rows.Count > 0 Then
                                    v_strGLGRP = gf_CorrectStringField(v_dsapp.Tables(0).Rows(0)("GLGRP"))
                                    v_strTRADEPLACE = CInt(gf_CorrectStringField(v_dsapp.Tables(0).Rows(0)("TRADEPLACE"))).ToString
                                    v_strTRADEPLACE = IIf(CInt(v_strTRADEPLACE) >= 3, 3, CInt(v_strTRADEPLACE))
                                    v_strSECTYPE = gf_CorrectStringField(v_dsapp.Tables(0).Rows(0)("SECTYPE")).Trim
                                    Select Case v_strSECTYPE
                                        Case "001", "002"   'NORMAL SHARE, SPECIAL SHARE
                                            v_strSECTYPE = "1"
                                        Case "003", "006"   'BOND, CONVERTABLE BOND
                                            v_strSECTYPE = "2"
                                        Case Else   'OTHER
                                            v_strSECTYPE = "3"
                                    End Select
                                End If

                            Else
                                'Láº¥y mÃ£ nhÃ³m káº¿ toÃ¡n cá»§a tÃ i khoáº£n khÃ¡ch hÃ ng GLGRP vÃ  cÃ¡c trÆ°á»?ng liÃªn quan
                                If Trim(v_strAPP) = SUB_SYSTEM_SE Then
                                    'PhÃ¢n há»‡ SE pháº£i láº¥y thÃªm thÃ´ng tin vá»? nÆ¡i giao dá»‹ch vÃ  loáº¡i chá»©ng khoÃ¡n
                                    'Kienvt sua ham trim
                                    'v_strSQL = "SELECT SBSECURITIES.SECTYPE, SBSECURITIES.TRADEPLACE, TYP.GLGRP FROM SBSECURITIES, " & v_strAPP & "TYPE TYP, " & v_strAPP & "MAST MST " _
                                    '        & " WHERE MST.CODEID=SBSECURITIES.CODEID AND TRIM(TYP.ACTYPE) = TRIM(MST.ACTYPE) AND TRIM(MST.ACCTNO) = '" & v_strACCTNO & "' "

                                    v_strSQL = "SELECT SBSECURITIES.SECTYPE, SBSECURITIES.TRADEPLACE, TYP.GLGRP FROM SBSECURITIES, " & v_strAPP & "TYPE TYP, " & v_strAPP & "MAST MST " _
                                            & " WHERE MST.CODEID=SBSECURITIES.CODEID AND TYP.ACTYPE = MST.ACTYPE AND MST.ACCTNO = '" & v_strACCTNO & "' "

                                    v_dsapp = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

                                    If v_dsapp.Tables(0).Rows.Count > 0 Then
                                        v_strGLGRP = gf_CorrectStringField(v_dsapp.Tables(0).Rows(0)("GLGRP"))
                                        v_strTRADEPLACE = CInt(gf_CorrectStringField(v_dsapp.Tables(0).Rows(0)("TRADEPLACE"))).ToString
                                        v_strTRADEPLACE = IIf(CInt(v_strTRADEPLACE) >= 3, 3, CInt(v_strTRADEPLACE))
                                        v_strSECTYPE = gf_CorrectStringField(v_dsapp.Tables(0).Rows(0)("SECTYPE")).Trim
                                        Select Case v_strSECTYPE
                                            Case "001", "002"   'NORMAL SHARE, SPECIAL SHARE
                                                v_strSECTYPE = "1"
                                            Case "003", "006"   'BOND, CONVERTABLE BOND
                                                v_strSECTYPE = "2"
                                            Case Else   'OTHER
                                                v_strSECTYPE = "3"
                                        End Select
                                    End If
                                Else

                                    'Máº·c Ä‘á»‹nh
                                    'Kienvt sua ham trim
                                    'v_strSQL = "SELECT TYP.GLGRP FROM " & v_strAPP & "TYPE TYP, " & v_strAPP & "MAST MST " _
                                    '     & " WHERE TRIM(TYP.ACTYPE) = TRIM(MST.ACTYPE) AND TRIM(MST.ACCTNO) = '" & v_strACCTNO & "' "

                                    v_strSQL = "SELECT TYP.GLGRP FROM " & v_strAPP & "TYPE TYP, " & v_strAPP & "MAST MST " _
                                            & " WHERE TYP.ACTYPE = MST.ACTYPE AND MST.ACCTNO = '" & v_strACCTNO & "' "
                                    v_dsapp = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

                                    If v_dsapp.Tables(0).Rows.Count > 0 Then
                                        v_strGLGRP = gf_CorrectStringField(v_dsapp.Tables(0).Rows(0)("GLGRP"))
                                    Else
                                        If Trim(v_strAPP) = "DF" Then
                                            v_strSQL = "SELECT TYP.GLGRP FROM " & v_strAPP & "TYPE TYP WHERE TYP.ACTYPE  = '" & v_strACCTNO & "' "
                                            v_dsapp = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

                                            If v_dsapp.Tables(0).Rows.Count > 0 Then
                                                v_strGLGRP = gf_CorrectStringField(v_dsapp.Tables(0).Rows(0)("GLGRP"))
                                            End If
                                        End If
                                    End If
                                End If
                            End If

                            EntryGLGRP = v_strGLGRP
                            'Get GL Master account
                            'Kienvt sua ham trim
                            'v_strSQL = "SELECT ACCTNO FROM GLREF WHERE TRIM(APPTYPE)='" & v_strAPP & "' AND TRIM(GLGRP)='" & v_strGLGRP & "' AND TRIM(ACNAME)='" & v_strACNAME & "'"
                            'v_strSQL = "SELECT ACCTNO FROM GLREF WHERE APPTYPE='" & v_strAPP & "' AND GLGRP='" & v_strGLGRP & "' AND ACNAME='" & v_strACNAME & "'"
                            'v_dsapp = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                            'If v_dsapp.Tables(0).Rows.Count > 0 Then
                            '    EntryACCTNO = gf_CorrectStringField(v_dsapp.Tables(0).Rows(0)(0))
                            'End If

                            EntryACCTNO = v_strAPP.Trim & v_strGLGRP.Trim & v_strACNAME

                            'v_strSQL = "SELECT ACCTNO FROM GLREF WHERE APPTYPE='" & v_strAPP & "' AND GLGRP='" & v_strGLGRP & "' AND ACNAME='" & v_strACNAME & "'"

                            If v_strAPPREF = SUB_SYSTEM_CA Then
                                v_strSQL = "SELECT ACCTNO FROM GLREF WHERE APPTYPE='" & v_strAPP & "' AND GLGRP='" & v_strGLGRP & "' AND SUBSTR(ACNAME,4) = '" & v_strACNAME & "' AND SUBSTR(ACNAME ,1,3) = '" & v_strCATYPE & "'"
                            Else
                                v_strSQL = "SELECT ACCTNO FROM GLREF WHERE APPTYPE='" & v_strAPP & "' AND GLGRP='" & v_strGLGRP & "' AND ACNAME='" & v_strACNAME & "'"
                            End If

                            v_dsapp = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                            If v_dsapp.Tables(0).Rows.Count > 0 Then
                                EntryACCTNO = gf_CorrectStringField(v_dsapp.Tables(0).Rows(0)(0))
                            End If

                        End If

                        'COA chỉ mở đến CN chứ ko mở đến PGD
                        If v_strBRID <> "0000" Then
                            EntryACCTNO = Replace(EntryACCTNO, "____", v_strBRID.Substring(0, 2) & "01")   'BRID Lay theo chi nhanh
                            EntryACCTNO = Replace(EntryACCTNO, "AAAA", v_strBRID)
                        Else
                            'Neu chay batch thi lay theo tai khoan
                            EntryACCTNO = Replace(EntryACCTNO, "____", EntryBRID.Substring(0, 2) & "01")   'BRID Lay theo tai khoan
                            EntryACCTNO = Replace(EntryACCTNO, "AAAA", EntryBRID)
                        End If
                        EntryACCTNO = Replace(EntryACCTNO, "####", EntryBRID.Substring(0, 2) & "01")   'BRID Lay theo tai khoan

                        'Neu la tai khoan thanh toan bu tru thi phai lay thong tin refacct la CI

                        'If v_strBRID <> "0000" Then
                        '    EntryACCTNO = Replace(EntryACCTNO, "____", v_strBRID)   'BRID Lay theo chi nhanh
                        'Else
                        '    'Neu chay batch thi lay theo tai khoan
                        '    EntryACCTNO = Replace(EntryACCTNO, "____", EntryBRID)   'BRID Lay theo tai khoan
                        'End If
                        'EntryACCTNO = Replace(EntryACCTNO, "####", EntryBRID)   'BRID Lay theo tai khoan

                        EntryACCTNO = Replace(EntryACCTNO, "**", EntryCCYCD)
                        EntryACCTNO = Replace(EntryACCTNO, "^^", EntryCCYCD)
                        EntryACCTNO = Replace(EntryACCTNO, "@", v_strTRADEPLACE)
                        EntryACCTNO = Replace(EntryACCTNO, "$", v_strSECTYPE)

                        If v_strACNAME = "GLMAST" Then
                            'Get direct GL Account No
                            v_nodetxData = pv_xmlDocument.SelectSingleNode("TransactMessage/fields/entry[@fldname='" & v_strACFLD & "']")
                            EntryACCTNO = v_nodetxData.InnerText
                        ElseIf EntryACCTNO = "GLMAST" Then
                            v_nodetxData = pv_xmlDocument.SelectSingleNode("TransactMessage/fields/entry[@fldname='" & v_strREFFLD & "']")
                            EntryACCTNO = v_nodetxData.InnerText
                        ElseIf v_strACNAME = "CICLRTRFSELL" Or v_strACNAME = "CICLRTRFBUY" Then
                            Dim v_strREFACCTNO_CUSTODYCD As String
                            'Get direct GL Account No
                            v_nodetxData = pv_xmlDocument.SelectSingleNode("TransactMessage/fields/entry[@fldname='" & v_strACFLD & "']")
                            v_strREFACCTNO_CUSTODYCD = v_nodetxData.InnerText
                            'Lay so luu ky
                            v_strSQL = "SELECT CUSTODYCD from afmast af, cfmast cf where cf.custid=af.custid and af.acctno= '" & v_strREFACCTNO_CUSTODYCD & "'"
                            v_dsCustody = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                            If v_dsCustody.Tables(0).Rows.Count > 0 Then
                                v_strREFACCTNO_CUSTODYCD = gf_CorrectStringField(v_dsCustody.Tables(0).Rows(0)("CUSTODYCD"))
                                If v_strREFACCTNO_CUSTODYCD.Substring(3, 1) = "C" Then
                                    EntryACCTNO = Replace(EntryACCTNO, "CCCC", "2610")
                                ElseIf v_strREFACCTNO_CUSTODYCD.Substring(3, 1) = "F" Then
                                    EntryACCTNO = Replace(EntryACCTNO, "CCCC", "3010")
                                End If
                            End If
                        End If

                        If v_strACNAME = "CASH" Then
                            'Special for Cash account
                            If EntryCCYCD = "00" Then
                                'Based currency
                                EntryACCTNO = Replace(EntryACCTNO, "$", "1")
                            Else
                                'Foreign currency
                                EntryACCTNO = Replace(EntryACCTNO, "$", "3")
                            End If

                            If Left(EntryACCTNO, 4) = "0000" Then
                                'For HeadOffice
                                EntryACCTNO = Replace(EntryACCTNO, "~", "1")
                            Else
                                'For branch
                                EntryACCTNO = Replace(EntryACCTNO, "~", "2")
                            End If
                        End If
                        EntryACCTNO = Trim(EntryACCTNO)

                        'Neu gia tri hach toan la am, xac lap lai but toan
                        If CDbl(EntryAMOUNT) < 0 Then
                            Select Case v_strNEGATIVECD
                                Case "Z"    'Reset ve 0
                                    EntryAMOUNT = "0"
                                Case "R"    'Revert
                                    If EntryDORC = "D" Then EntryDORC = "C"
                                    If EntryDORC = "C" Then EntryDORC = "D"
                                    EntryAMOUNT = -CDbl(EntryAMOUNT).ToString
                                Case "A"    'GIU NGUYEN
                            End Select
                        End If


                        'Lay cac thong tin but toan: Chi thuc hien neu co so du va co so tai khoan
                        If EntryAMOUNT <> 0 And EntryACCTNO.Trim.Length > 0 And
                            Len(EntryCUSTID) > 0 Or Len(EntryCUSTNAME) > 0 Or Len(EntryTASKCD) > 0 Or Len(EntryDEPTCD) > 0 Or Len(EntryMICD) > 0 Then
                            v_entryNode = pv_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "entry", "")

                            Dim v_attrSUBTXNO As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("subtxno")
                            v_attrSUBTXNO.Value = EntrySUBTXNO
                            v_entryNode.Attributes.Append(v_attrSUBTXNO)

                            Dim v_attrDORC As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("dorc")
                            v_attrDORC.Value = EntryDORC
                            v_entryNode.Attributes.Append(v_attrDORC)

                            Dim v_attrACCTNO As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("acctno")
                            v_attrACCTNO.Value = EntryACCTNO
                            v_entryNode.Attributes.Append(v_attrACCTNO)

                            Dim v_attrCUSTID As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("custid")
                            v_attrCUSTID.Value = EntryCUSTID
                            v_entryNode.Attributes.Append(v_attrCUSTID)

                            Dim v_attrCUSTNAME As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("custname")
                            v_attrCUSTNAME.Value = EntryCUSTNAME
                            v_entryNode.Attributes.Append(v_attrCUSTNAME)

                            Dim v_attrTASKCD As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("taskcd")
                            v_attrTASKCD.Value = EntryTASKCD
                            v_entryNode.Attributes.Append(v_attrTASKCD)

                            Dim v_attrDEPTCD As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("deptcd")
                            v_attrDEPTCD.Value = EntryDEPTCD
                            v_entryNode.Attributes.Append(v_attrDEPTCD)

                            Dim v_attrMICD As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("micd")
                            v_attrMICD.Value = EntryMICD
                            v_entryNode.Attributes.Append(v_attrMICD)

                            Dim v_attrDESC As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("description")
                            v_attrDESC.Value = v_strTXDESC
                            v_entryNode.Attributes.Append(v_attrDESC)

                            v_entryNode.InnerText = EntryAMOUNT
                            v_mitranElement.AppendChild(v_entryNode)
                        End If

                        'Tao but toan ke toan
                        If EntryAMOUNT <> 0 And EntryACCTNO.Trim.Length > 0 Then
                            intCountPostmap = intCountPostmap + 1
                            arrPOSTMAP(0, intCountPostmap) = EntrySUBTXNO
                            arrPOSTMAP(1, intCountPostmap) = EntryDORC
                            arrPOSTMAP(2, intCountPostmap) = EntryCCYCD
                            arrPOSTMAP(3, intCountPostmap) = EntryACCTNO
                            arrPOSTMAP(4, intCountPostmap) = EntryAMOUNT
                        End If
                    End If

                Next
                pv_xmlDocument.DocumentElement.AppendChild(v_mitranElement)
                pv_xmlDocument.DocumentElement.AppendChild(v_postingElement)
                If intCountPostmap > 0 Then
                    'Xu ly hach toan cho cho cac tai khoan ke toan xuat hien trong cung but toan
                    intCountEntry = 0
                    For i = 1 To intCountPostmap Step 1
                        If intCountEntry = 0 Then
                            'Phan tu dau tien
                            intCountEntry = 1
                            arrENTRY(0, intCountEntry) = arrPOSTMAP(0, i)   'SUBTXNO
                            arrENTRY(1, intCountEntry) = arrPOSTMAP(1, i)   'DORC
                            arrENTRY(2, intCountEntry) = arrPOSTMAP(2, i)   'CCYCD
                            arrENTRY(3, intCountEntry) = arrPOSTMAP(3, i)   'ACCTNO
                            arrENTRY(4, intCountEntry) = arrPOSTMAP(4, i)   'AMOUNT
                        Else
                            'Tu phan tu thu 2 tro di phai duyet
                            blnFound = False
                            For j = 1 To intCountEntry Step 1
                                If arrPOSTMAP(0, i).Equals(arrENTRY(0, j)) And arrPOSTMAP(3, i).Equals(arrENTRY(3, j)) Then
                                    If arrPOSTMAP(1, i) <> arrENTRY(1, j) Then
                                        If arrPOSTMAP(4, i) < arrENTRY(4, j) Then
                                            arrENTRY(4, j) = arrENTRY(4, j) - arrPOSTMAP(4, i)
                                        Else
                                            arrENTRY(4, j) = -arrENTRY(4, j) + arrPOSTMAP(4, i)
                                            If arrENTRY(1, j) = "C" Then
                                                arrENTRY(1, j) = "D"
                                            Else
                                                arrENTRY(1, j) = "C"
                                            End If
                                        End If
                                    Else
                                        arrENTRY(4, j) = arrENTRY(4, j) + arrPOSTMAP(4, i)
                                    End If

                                    blnFound = True
                                    Exit For
                                End If
                            Next
                            'Neu khong tim thay thi ghi nhan moi
                            If Not blnFound Then
                                intCountEntry = intCountEntry + 1
                                arrENTRY(0, intCountEntry) = arrPOSTMAP(0, i)   'SUBTXNO
                                arrENTRY(1, intCountEntry) = arrPOSTMAP(1, i)   'DORC
                                arrENTRY(2, intCountEntry) = arrPOSTMAP(2, i)   'CCYCD
                                arrENTRY(3, intCountEntry) = arrPOSTMAP(3, i)   'ACCTNO
                                arrENTRY(4, intCountEntry) = arrPOSTMAP(4, i)   'AMOUNT
                            End If
                        End If
                    Next

                    'Tao bo dinh khoan tren co so da gop but toan
                    For i = 1 To intCountEntry Step 1
                        EntrySUBTXNO = arrENTRY(0, i)
                        EntryDORC = arrENTRY(1, i)
                        EntryCCYCD = arrENTRY(2, i)
                        EntryACCTNO = arrENTRY(3, i)
                        EntryAMOUNT = arrENTRY(4, i)

                        v_entryNode = pv_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "entry", "")

                        Dim v_attrSUBTXNO As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("subtxno")
                        v_attrSUBTXNO.Value = EntrySUBTXNO
                        v_entryNode.Attributes.Append(v_attrSUBTXNO)

                        Dim v_attrDORC As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("dorc")
                        v_attrDORC.Value = EntryDORC
                        v_entryNode.Attributes.Append(v_attrDORC)

                        Dim v_attrCCYCD As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("ccycd")
                        v_attrCCYCD.Value = EntryCCYCD
                        v_entryNode.Attributes.Append(v_attrCCYCD)

                        Dim v_attrACCTNO As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("acctno")
                        v_attrACCTNO.Value = EntryACCTNO
                        v_entryNode.Attributes.Append(v_attrACCTNO)


                        Dim v_attrGLGRP As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("glgrp")
                        v_attrGLGRP.Value = EntryGLGRP
                        v_entryNode.Attributes.Append(v_attrGLGRP)

                        v_entryNode.InnerText = EntryAMOUNT
                        v_postingElement.AppendChild(v_entryNode)
                    Next
                    pv_xmlDocument.DocumentElement.AppendChild(v_postingElement)
                End If
            End If

            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If
            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function BuildAMTEXP(ByVal pv_xmlDocument As Xml.XmlDocument, ByVal strAMTEXP As String) As String
        Try
            Dim v_strEvaluator, v_strElemenent As String
            Dim v_lngIndex As Long
            Dim v_nodetxData As Xml.XmlNode
            Dim v_strFEEAMT As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeFEEAMT).Value.ToString
            Dim v_strVATAMT As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeVATAMT).Value.ToString

            v_strFEEAMT = IIf(v_strFEEAMT.Length = 0, "0", v_strFEEAMT)
            v_strVATAMT = IIf(v_strVATAMT.Length = 0, "0", v_strVATAMT)

            v_strEvaluator = vbNullString
            v_lngIndex = 1

            While v_lngIndex < Len(strAMTEXP)
                'Get 02 charatacters in AMTEXP
                v_strElemenent = Mid$(strAMTEXP, v_lngIndex, 2)
                Select Case v_strElemenent
                    Case "FF"
                        'Fee amount
                        v_strEvaluator = v_strEvaluator & v_strFEEAMT
                    Case "VV"
                        'VAT amount
                        v_strEvaluator = v_strEvaluator & v_strVATAMT
                    Case "++", "--", "**", "//", "((", "))"
                        'Operand
                        v_strEvaluator = v_strEvaluator & Left$(v_strElemenent, 1)
                    Case "@1"
                        'Operand
                        v_strEvaluator = v_strEvaluator & "1"
                    Case Else
                        'Operator
                        v_nodetxData = pv_xmlDocument.SelectSingleNode("TransactMessage/fields/entry[@fldname='" & v_strElemenent & "']")
                        v_strEvaluator = v_strEvaluator & v_nodetxData.InnerText
                End Select
                v_lngIndex = v_lngIndex + 2
            End While
            Complete() 'ContextUtil.SetComplete()
            Return v_strEvaluator
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function CheckTranAllow(ByVal pv_acctno As String, ByVal pv_tblname As String, ByVal pv_acfld As String, ByVal pv_tltxcd As String) As Boolean
        Dim v_obj As New DataAccess
        Dim v_objParam As New StoreParameter
        Dim v_arrPara(4) As StoreParameter
        Dim v_blnAllow As Boolean
        Dim v_strResult As String
        Try
            v_obj.NewDBInstance(gc_MODULE_HOST)

            v_objParam.ParamName = "return"
            v_objParam.ParamDirection = ParameterDirection.ReturnValue
            v_objParam.ParamValue = True
            v_objParam.ParamSize = 100
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(0) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "pv_acctno"
            v_objParam.ParamValue = pv_acctno
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamSize = 100
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(1) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "pv_tblname"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamValue = pv_tblname
            v_objParam.ParamSize = 100
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(2) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "pv_acfld"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamValue = pv_acfld
            v_objParam.ParamSize = 100
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(3) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "pv_tltxcd"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamValue = pv_tltxcd
            v_objParam.ParamSize = 100
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(4) = v_objParam

            v_strResult = v_obj.ExecuteOracleStored("txpks_check.fn_aftxmapcheck", v_arrPara, 0)
            v_blnAllow = IIf(v_strResult = "TRUE", True, False)
            Return v_blnAllow
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try

    End Function

    Private Function GenAPPCHK(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.txRouter.GenAPPCHK", v_strErrorMessage As String
        Dim v_strSQL As String, v_ds As DataSet, v_obj As New DataAccess
        Try
            v_obj.NewDBInstance(gc_MODULE_HOST)

            Dim v_objEval As New Evaluator, v_nodetxData As Xml.XmlNode
            Dim i As Integer, v_strACFLD, v_strAMTEXP, v_strVALUE, v_strACCTNO, v_strISRUN, v_strFLDRND As String
            Dim EntrySUBTXNO, EntryDORC, EntryACCTNO, EntryCCYCD As String
            Dim v_oldAccfld, v_oldTableName, v_oldDorc As String
            Dim EntryAMOUNT As Double

            Dim v_nodeGenChecking As Xml.XmlNode
            v_nodeGenChecking = pv_xmlDocument.SelectSingleNode("/TransactMessage/appchk")
            'KhÃ´ng táº¡o APPCHK náº¿u Ä‘Ã£ cÃ³
            If Not v_nodeGenChecking Is Nothing Then
                'Return ERR_SYSTEM_OK
                pv_xmlDocument.DocumentElement.RemoveChild(v_nodeGenChecking)
            End If


            'Create Appchk Node
            Dim v_appchkElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
            v_appchkElement = pv_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "appchk", "")


            Dim v_strTLTXCD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value.ToString
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value.ToString

            'Kiem tra xem tai khoan co bi chan voi giao dich khong
            v_strSQL = "select distinct acfld, tblname from v_appchk_by_tltxcd where tltxcd ='" & v_strTLTXCD & "' " _
                    & " and tblname in ('CIMAST','SEMAST','LNMAST','DFMAST','ODMAST') "
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To v_ds.Tables(0).Rows.Count - 1 Step 1
                    If Not CheckTranAllow(pv_xmlDocument.SelectSingleNode("TransactMessage/fields/entry[@fldname='" & Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("ACFLD"))) & "']").InnerText,
                                  Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("TBLNAME"))),
                                  Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("ACFLD"))),
                                  v_strTLTXCD) Then

                        Rollback() 'ContextUtil.SetAbort()
                        Return ERR_SA_TLTX_NOT_ALLOW_BY_ACCTNO
                    End If
                Next

            End If
            'Get check rules
            'v_strSQL = "SELECT TLTXCD, APPTYPE, RULECD, ACFLD, AMTEXP, FIELD, OPERAND, ERRNUM, ERRMSG, TBLNAME, FLDKEY " _
            '    & "FROM V_APPCHK_BY_TLTXCD APP WHERE APP.TLTXCD = '" & v_strTLTXCD & "' " _
            '    & "ORDER BY APPTYPE, TBLNAME, FLDKEY, FIELD, RULECD" 'Please do not change ORDER BY
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'If v_ds Is Nothing Then 'TruongLD comment
            'If v_ds.Tables(0).Rows.Count = 0 Then
            '    v_strSQL = "SELECT TLTXCD, APPTYPE, RULECD, ACFLD, AMTEXP, FIELD, OPERAND, ERRNUM, ERRMSG, TBLNAME, FLDKEY, REFID, ISRUN, FLDRND " _
            '        & "FROM V_APPCHK_BY_TLTXCD APP WHERE APP.TLTXCD = '" & v_strTLTXCD & "' " _
            '        & "ORDER BY APPTYPE, TBLNAME, FLDKEY, FIELD, RULECD" 'Please do not change ORDER BY
            '    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'End If
            'WARNING-ERROR
            v_strSQL = "SELECT TLTXCD, APPTYPE, RULECD, ACFLD, AMTEXP, FIELD, OPERAND, ERRNUM, ERRMSG, TBLNAME, FLDKEY, REFID, ISRUN, FLDRND, CHKLEV " _
                    & "FROM V_APPCHK_BY_TLTXCD APP WHERE APP.TLTXCD = '" & v_strTLTXCD & "' " _
                    & "ORDER BY CHKLEV DESC, APPTYPE, TBLNAME, FLDKEY, FIELD, RULECD" 'Please do not change ORDER BY
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

            If v_ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To v_ds.Tables(0).Rows.Count - 1 Step 1
                    'Co thuc hien check hay khong
                    'Neu bang 0 thi khong thuc hien
                    v_strAMTEXP = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("ISRUN")))
                    v_strFLDRND = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("FLDRND")))
                    If Len(v_strAMTEXP) > 0 Then
                        If Left(v_strAMTEXP, 1) = "@" Then
                            v_strVALUE = Mid(v_strAMTEXP, 2)
                        ElseIf Left(v_strAMTEXP, 1) = "$" Then
                            'Get field code
                            v_strVALUE = Mid(v_strAMTEXP, 2)
                            'Get field value
                            v_nodetxData = pv_xmlDocument.SelectSingleNode("TransactMessage/fields/entry[@fldname='" & v_strVALUE & "']")
                            v_strVALUE = v_nodetxData.InnerText
                        Else
                            'Armethic expression
                            v_strAMTEXP = BuildAMTEXP(pv_xmlDocument, v_strAMTEXP)
                            v_strVALUE = v_objEval.Eval(v_strAMTEXP).ToString
                        End If
                    End If
                    v_strISRUN = v_strVALUE
                    If v_strISRUN <> "0" Then
                        'Lấy trường số tài khoản
                        v_strACFLD = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("ACFLD")))
                        v_nodetxData = pv_xmlDocument.SelectSingleNode("TransactMessage/fields/entry[@fldname='" & v_strACFLD & "']")
                        v_strACCTNO = v_nodetxData.InnerText

                        'Xác định biểu thức số học điều kiện kiểm tra
                        v_strAMTEXP = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("AMTEXP")))
                        If Len(v_strAMTEXP) > 0 Then
                            If Left(v_strAMTEXP, 1) = "@" Then
                                v_strVALUE = Mid(v_strAMTEXP, 2)
                            ElseIf Left(v_strAMTEXP, 1) = "$" Then
                                'Get field code: Sá»­ dá»¥ng trong trÆ°á»?ng há»£p trÆ°á»?ng cÃ³ giÃ¡ trá»‹ kÃ½ tá»± sáº½ khÃ´ng Ã¡p dá»¥ng phÃ©p toÃ¡n Ä‘Æ°á»£c
                                v_strVALUE = Mid(v_strAMTEXP, 2)
                                'Get field value
                                v_nodetxData = pv_xmlDocument.SelectSingleNode("TransactMessage/fields/entry[@fldname='" & v_strVALUE & "']")
                                v_strVALUE = v_nodetxData.InnerText
                            ElseIf v_strAMTEXP = "<$BUSDATE>" Then
                                'Get business date
                                v_strVALUE = v_strTXDATE
                            Else
                                'Armethic expression
                                v_strAMTEXP = BuildAMTEXP(pv_xmlDocument, v_strAMTEXP)
                                v_strVALUE = v_objEval.Eval(v_strAMTEXP).ToString
                                'Làm tròn nếu có
                                If v_strFLDRND.Trim.Length > 0 Then
                                    'Làm tròn theo qui định trong APPTX
                                    v_strVALUE = gf_RoundNumber(v_strVALUE, v_strFLDRND.Trim)
                                End If
                            End If
                        End If

                        'Create appchk entry
                        v_entryNode = pv_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "entry", "")

                        Dim v_attrAPPTYPE As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("apptype")
                        v_attrAPPTYPE.Value = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("APPTYPE")))
                        v_entryNode.Attributes.Append(v_attrAPPTYPE)

                        Dim v_attrRULECD As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("rulecd")
                        v_attrRULECD.Value = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("RULECD")))
                        v_entryNode.Attributes.Append(v_attrRULECD)

                        Dim v_attrACFLD As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("acfld")
                        v_attrACFLD.Value = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("ACFLD")))
                        v_entryNode.Attributes.Append(v_attrACFLD)

                        Dim v_attrAMTEXP As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("amtexp")
                        v_attrAMTEXP.Value = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("AMTEXP")))
                        v_entryNode.Attributes.Append(v_attrAMTEXP)

                        Dim v_attrFIELD As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("field")
                        v_attrFIELD.Value = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("FIELD")))
                        v_entryNode.Attributes.Append(v_attrFIELD)

                        Dim v_attrOPERAND As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("operand")
                        v_attrOPERAND.Value = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("OPERAND")))
                        v_entryNode.Attributes.Append(v_attrOPERAND)

                        Dim v_attrERRNUM As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("errnum")
                        v_attrERRNUM.Value = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("ERRNUM")))
                        v_entryNode.Attributes.Append(v_attrERRNUM)

                        Dim v_attrERRMSG As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("errmsg")
                        v_attrERRMSG.Value = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("ERRMSG")))
                        v_entryNode.Attributes.Append(v_attrERRMSG)

                        Dim v_attrTBLNAME As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("tblname")
                        v_attrTBLNAME.Value = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("TBLNAME")))
                        v_entryNode.Attributes.Append(v_attrTBLNAME)

                        Dim v_attrFLDKEY As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("fldkey")
                        v_attrFLDKEY.Value = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("FLDKEY")))
                        v_entryNode.Attributes.Append(v_attrFLDKEY)

                        Dim v_attrREFID As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("refid")
                        v_attrREFID.Value = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("REFID")))
                        v_entryNode.Attributes.Append(v_attrREFID)

                        'WARNING-ERROR
                        Dim v_attrWARNING As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("chklev")
                        v_attrWARNING.Value = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("CHKLEV")))
                        v_entryNode.Attributes.Append(v_attrWARNING)


                        Dim v_attrACCTNO As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("acctno")
                        v_attrACCTNO.Value = v_strACCTNO
                        v_entryNode.Attributes.Append(v_attrACCTNO)

                        v_entryNode.InnerText = v_strVALUE
                        v_appchkElement.AppendChild(v_entryNode)
                    End If

                Next
            Else
                'CÃ³ nhá»¯ng giao dá»‹ch khÃ´ng cáº§n kiá»ƒm tra nÃªn khÃ´ng báº¯t lá»—i nÃ y

                ''Lá»—i thiáº¿u tham sá»‘ kiá»ƒm tra giao dá»‹ch
                'v_lngErrCode = ERR_SA_APPCHK_MISSING
                'LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                '             & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                '             & "Error message: " & v_strErrorMessage, EventLogEntryType.Information)
                'BuildXMLErrorException(pv_xmlDocument, v_strErrorSource, v_lngErrCode, v_strErrorMessage)
                'Return v_lngErrCode
            End If

            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If

            pv_xmlDocument.DocumentElement.AppendChild(v_appchkElement)
            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function GenAPPMAP(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.txRouter.GenAPPMAP", v_strErrorMessage As String
        Dim v_strSQL As String, v_ds As DataSet, v_obj As New DataAccess

        Try
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_objEval As New Evaluator, v_nodetxData As Xml.XmlNode
            Dim i, id As Integer, v_strACFLD, v_strACFLDREF, v_strAMTEXP, v_strVALUE, v_strACCTNO, v_strFLDRND, v_strISRUN, v_strTRDESC As String
            Dim v_fldcd, v_strNewTRDESC As String
            Dim EntrySUBTXNO, EntryDORC, EntryACCTNO, EntryCCYCD As String, EntryAMOUNT As Double

            Dim v_nodeGenChecking As Xml.XmlNode
            v_nodeGenChecking = pv_xmlDocument.SelectSingleNode("/TransactMessage/appmap")
            'KhÃ´ng táº¡o APPMAP náº¿u Ä‘Ã£ cÃ³
            If Not v_nodeGenChecking Is Nothing Then Return ERR_SYSTEM_OK

            'Get message information
            Dim v_strTLTXCD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value.ToString
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value.ToString

            'Create Appmap Node
            Dim v_appmapElement As Xml.XmlElement, v_entryNode As Xml.XmlNode

            'v_strSQL = "SELECT TLTXCD, APPTYPE, TBLNAME, APPTXCD, ACFLD, AMTEXP, FLDKEY, COND, ACFLDREF, TXTYPE, FIELD, FLDTYPE, TRANF, OFILE, OFILEACT " _
            '    & "FROM V_APPMAP_BY_TLTXCD APP WHERE APP.TLTXCD = '" & v_strTLTXCD & "' " _
            '    & " ORDER BY APPTYPE, ACFLD, TBLNAME, FIELD, FLDKEY, APPTXCD" 'Please do not change ORDER BY
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'If v_ds Is Nothing Then
            v_strSQL = "SELECT TLTXCD, APPTYPE, TBLNAME, APPTXCD, ACFLD, AMTEXP, FLDKEY, COND, ACFLDREF, TXTYPE, FIELD, FLDTYPE, TRANF, OFILE, OFILEACT, ISRUN, FLDRND,TRDESC " _
                    & "FROM V_APPMAP_BY_TLTXCD APP WHERE APP.TLTXCD = '" & v_strTLTXCD & "' " _
                    & " ORDER BY APPTYPE, ACFLD, TBLNAME, FIELD, FLDKEY, APPTXCD" 'Please do not change ORDER BY
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

            If v_ds.Tables(0).Rows.Count > 0 Then
                v_appmapElement = pv_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "appmap", "")
                For i = 0 To v_ds.Tables(0).Rows.Count - 1 Step 1
                    'v_strISRUN quy dinh Co thuc hien hach toan hay khong
                    'Bang 0 thi khong thuc hien hach toan.
                    v_strAMTEXP = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("ISRUN")))
                    v_strFLDRND = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("FLDRND")))
                    If Len(v_strAMTEXP) > 0 Then
                        If Left(v_strAMTEXP, 1) = "@" Then
                            v_strVALUE = Mid(v_strAMTEXP, 2)
                        ElseIf Left(v_strAMTEXP, 1) = "$" Then
                            'Get field code
                            v_strVALUE = Mid(v_strAMTEXP, 2)
                            'Get field value
                            v_nodetxData = pv_xmlDocument.SelectSingleNode("TransactMessage/fields/entry[@fldname='" & v_strVALUE & "']")
                            v_strVALUE = v_nodetxData.InnerText
                        Else
                            v_strAMTEXP = BuildAMTEXP(pv_xmlDocument, v_strAMTEXP)
                            v_strVALUE = v_objEval.Eval(v_strAMTEXP).ToString
                        End If
                    End If
                    v_strISRUN = v_strVALUE
                    If v_strISRUN <> "0" Then
                        'Lấy trường số tài khoản
                        v_strACFLD = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("ACFLD")))
                        v_nodetxData = pv_xmlDocument.SelectSingleNode("TransactMessage/fields/entry[@fldname='" & v_strACFLD & "']")
                        v_strACCTNO = v_nodetxData.InnerText

                        'Xác định trường tài khoản đối ứng
                        v_strACFLDREF = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("ACFLDREF")))
                        If Len(v_strACFLDREF) <> 0 Then
                            v_nodetxData = pv_xmlDocument.SelectSingleNode("TransactMessage/fields/entry[@fldname='" & v_strACFLDREF & "']")
                            v_strACFLDREF = v_nodetxData.InnerText
                        End If

                        'Xác định biểu thức hạch toán kiểm tra
                        v_strAMTEXP = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("AMTEXP")))
                        If Len(v_strAMTEXP) > 0 Then
                            If Left(v_strAMTEXP, 1) = "@" Then
                                v_strVALUE = Mid(v_strAMTEXP, 2)
                            ElseIf Left(v_strAMTEXP, 1) = "$" Then
                                'Get field code
                                v_strVALUE = Mid(v_strAMTEXP, 2)
                                'Get field value
                                v_nodetxData = pv_xmlDocument.SelectSingleNode("TransactMessage/fields/entry[@fldname='" & v_strVALUE & "']")
                                v_strVALUE = v_nodetxData.InnerText
                            ElseIf v_strAMTEXP = "<$BUSDATE>" Then
                                'Get business date
                                v_strVALUE = v_strTXDATE
                            Else
                                If Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("TXTYPE"))) = "U" Then
                                    'Neu la update thi lay gia tri 
                                    v_strAMTEXP = BuildAMTEXP(pv_xmlDocument, v_strAMTEXP)
                                    v_strVALUE = v_strAMTEXP
                                Else
                                    'Credit or Debit Armethic expression
                                    v_strAMTEXP = BuildAMTEXP(pv_xmlDocument, v_strAMTEXP)
                                    v_strVALUE = v_objEval.Eval(v_strAMTEXP).ToString
                                    'Thực hiện làm tròn số
                                    If v_strFLDRND.Trim.Length > 0 Then
                                        'Làm tròn theo qui định trong APPTX
                                        v_strVALUE = gf_RoundNumber(v_strVALUE, v_strFLDRND.Trim)
                                    End If
                                End If

                            End If
                        End If
                        'Xác định dien giai cho phep toan
                        v_strTRDESC = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("TRDESC")))
                        v_strNewTRDESC = ""
                        If Not v_strTRDESC Is Nothing And Len(v_strTRDESC) > 0 Then
                            If v_strTRDESC = "##" Then
                                v_strTRDESC = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value.ToString
                            ElseIf v_strTRDESC = "EX" Then
                                Dim v_objParam As New StoreParameter
                                Dim v_arrPara(4) As StoreParameter

                                v_objParam.ParamName = "return"
                                v_objParam.ParamDirection = ParameterDirection.ReturnValue
                                v_objParam.ParamValue = 0
                                v_objParam.ParamSize = 1000
                                v_objParam.ParamType = GetType(System.String).Name
                                v_arrPara(0) = v_objParam

                                v_objParam = New StoreParameter
                                v_objParam.ParamName = "p_xmlmsg"
                                v_objParam.ParamValue = pv_xmlDocument.InnerXml
                                v_objParam.ParamDirection = ParameterDirection.Input
                                v_objParam.ParamSize = 32000
                                v_objParam.ParamType = GetType(System.String).Name
                                v_arrPara(1) = v_objParam

                                v_objParam = New StoreParameter
                                v_objParam.ParamName = "p_tltxcd"
                                v_objParam.ParamDirection = ParameterDirection.Input
                                v_objParam.ParamValue = v_strTLTXCD
                                v_objParam.ParamSize = 4
                                v_objParam.ParamType = GetType(System.String).Name
                                v_arrPara(2) = v_objParam

                                v_objParam = New StoreParameter
                                v_objParam.ParamName = "p_apptype"
                                v_objParam.ParamDirection = ParameterDirection.Input
                                v_objParam.ParamValue = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("APPTYPE")))
                                v_objParam.ParamSize = 2
                                v_objParam.ParamType = GetType(System.String).Name
                                v_arrPara(3) = v_objParam

                                v_objParam = New StoreParameter
                                v_objParam.ParamName = "p_apptxcd"
                                v_objParam.ParamDirection = ParameterDirection.Input
                                v_objParam.ParamValue = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("APPTXCD")))
                                v_objParam.ParamSize = 4
                                v_objParam.ParamType = GetType(System.String).Name
                                v_arrPara(4) = v_objParam

                                v_strTRDESC = v_obj.ExecuteOracleStored("cspks_system.fn_NETgen_trandesc", v_arrPara, 0)

                            Else
                                For id = 0 To Len(v_strTRDESC) - 1
                                    If v_strTRDESC.Substring(id, 1) = "#" Then
                                        v_fldcd = v_strTRDESC.Substring(id + 1, 2)
                                        v_strNewTRDESC = v_strNewTRDESC & pv_xmlDocument.SelectSingleNode("TransactMessage/fields/entry[@fldname='" & v_fldcd & "']").InnerText
                                        id = id + 2
                                    Else
                                        v_strNewTRDESC = v_strNewTRDESC & v_strTRDESC.Substring(id, 1)
                                    End If
                                Next
                                v_strTRDESC = v_strNewTRDESC
                            End If
                        End If

                        'Create appmap entry
                        v_entryNode = pv_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "entry", "")

                        Dim v_attrAPPTYPE As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("apptype")
                        v_attrAPPTYPE.Value = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("APPTYPE")))
                        v_entryNode.Attributes.Append(v_attrAPPTYPE)

                        Dim v_attrTBLNAME As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("tblname")
                        v_attrTBLNAME.Value = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("TBLNAME")))
                        v_entryNode.Attributes.Append(v_attrTBLNAME)

                        Dim v_attrAPPTXCD As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("apptxcd")
                        v_attrAPPTXCD.Value = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("APPTXCD")))
                        v_entryNode.Attributes.Append(v_attrAPPTXCD)

                        Dim v_attrAMTEXP As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("amtexp")
                        v_attrAMTEXP.Value = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("AMTEXP")))
                        v_entryNode.Attributes.Append(v_attrAMTEXP)

                        Dim v_attrACFLD As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("acfld")
                        v_attrACFLD.Value = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("ACFLD")))
                        v_entryNode.Attributes.Append(v_attrACFLD)

                        Dim v_attrFLDKEY As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("fldkey")
                        v_attrFLDKEY.Value = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("FLDKEY")))
                        v_entryNode.Attributes.Append(v_attrFLDKEY)

                        Dim v_attrACFLDREF As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("acfldref")
                        v_attrACFLDREF.Value = v_strACFLDREF
                        v_entryNode.Attributes.Append(v_attrACFLDREF)

                        Dim v_attrCOND As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("cond")
                        v_attrCOND.Value = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("COND")))
                        v_entryNode.Attributes.Append(v_attrCOND)

                        Dim v_attrTXTYPE As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("txtype")
                        v_attrTXTYPE.Value = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("TXTYPE")))
                        v_entryNode.Attributes.Append(v_attrTXTYPE)

                        Dim v_attrFIELD As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("field")
                        v_attrFIELD.Value = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("FIELD")))
                        v_entryNode.Attributes.Append(v_attrFIELD)

                        Dim v_attrFLDTYPE As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("fldtype")
                        v_attrFLDTYPE.Value = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("FLDTYPE")))
                        v_entryNode.Attributes.Append(v_attrFLDTYPE)

                        Dim v_attrTRANF As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("tranf")
                        v_attrTRANF.Value = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("TRANF")))
                        v_entryNode.Attributes.Append(v_attrTRANF)

                        Dim v_attrOFILE As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("ofile")
                        v_attrOFILE.Value = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("OFILE")))
                        v_entryNode.Attributes.Append(v_attrOFILE)

                        Dim v_attrOFILEACT As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("ofileact")
                        v_attrOFILEACT.Value = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("OFILEACT")))
                        v_entryNode.Attributes.Append(v_attrOFILEACT)

                        Dim v_attrTRDESC As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("trdesc")
                        v_attrTRDESC.Value = v_strTRDESC
                        v_entryNode.Attributes.Append(v_attrTRDESC)

                        Dim v_attrACCTNO As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("acctno")
                        v_attrACCTNO.Value = v_strACCTNO
                        v_entryNode.Attributes.Append(v_attrACCTNO)

                        v_entryNode.InnerText = v_strVALUE
                        v_appmapElement.AppendChild(v_entryNode)
                    End If

                Next

                pv_xmlDocument.DocumentElement.AppendChild(v_appmapElement)
            End If

            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If
            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function


    'HÃ m nÃ y Ä‘Æ°á»£c gá»?i Ä‘á»ƒ thá»±c hiá»‡n kiá»ƒm tra cÃ¡c phÃ¢n há»‡ nghiá»‡p vá»¥
    'Biáº¿n vÃ o:  pv_xmlDocument lÃ  xmlDocument Ä‘Ã£ Ä‘Æ°á»£c GenAPPCHK
    Private Function HostAppCheck(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.txRouter.HostAppCheck", v_strErrorMessage As String
        Try
            Dim v_DataAccess As New DataAccess, v_ds As DataSet, v_strSQL As String
            Dim i As Integer, v_strMODULE As String, v_appMODULE As CoreBusiness.txMaster
            Dim v_strTLTXCD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value.ToString
            v_DataAccess.NewDBInstance(gc_MODULE_HOST)


            'XÃ¡c Ä‘á»‹nh cÃ¡c phÃ¢n há»‡ nghiá»‡p vá»¥ Ä‘á»ƒ kiá»ƒm tra
            v_strSQL = "SELECT DISTINCT APPTYPE FROM APPMAP WHERE TLTXCD ='" & v_strTLTXCD & "'"
            v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

            If v_ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To v_ds.Tables(0).Rows.Count - 1
                    'XÃ¡c Ä‘á»‹nh tÃªn phÃ¢n há»‡ nghiá»‡p vá»¥
                    v_strMODULE = Trim(v_ds.Tables(0).Rows(i)(0))
                    'Select Case v_strMODULE
                    '    Case SUB_SYSTEM_CF
                    '        v_appMODULE = New CF.Trans
                    '    Case SUB_SYSTEM_CI
                    '        v_appMODULE = New CI.Trans
                    '    Case SUB_SYSTEM_SE
                    '        v_appMODULE = New SE.Trans
                    '    Case SUB_SYSTEM_CA
                    '        v_appMODULE = New CA.Trans
                    '    Case SUB_SYSTEM_GL

                    '    Case SUB_SYSTEM_OD
                    '        v_appMODULE = New OD.Trans
                    '    Case SUB_SYSTEM_RP
                    '        v_appMODULE = New RP.Trans
                    '    Case SUB_SYSTEM_RM
                    '        v_appMODULE = New RM.Trans
                    'End Select
                    ''Kiá»ƒm tra luÃ´n
                    'If Not v_appMODULE Is Nothing Then
                    '    v_lngErrCode = v_appMODULE.txCheck(pv_xmlDocument)
                    '    If v_lngErrCode <> ERR_SYSTEM_OK And v_lngErrCode <> ERR_SA_CHECKER1_OVR And v_lngErrCode <> ERR_SA_CHECKER2_OVR Then
                    '        v_strErrorMessage = v_strErrorSource & ".Step: " & v_strMODULE & ".txCheck"
                    '        'Tráº£ vá»? mÃ£ lá»—i
                    '        Rollback() 'ContextUtil.SetAbort()
                    '        Return v_lngErrCode
                    '    End If
                    'End If
                    If String.Compare(v_strMODULE, SUB_SYSTEM_GL) <> 0 Then
                        Dim oAssembly As System.Reflection.Assembly = System.Reflection.Assembly.Load(v_strMODULE)
                        Dim aType As System.Type = oAssembly.GetType(v_strMODULE & ".Trans")
                        If Not aType Is Nothing Then
                            Dim obj, retval As Object
                            obj = Activator.CreateInstance(aType)
                            Dim args() As Object = {pv_xmlDocument}
                            retval = aType.InvokeMember("txCheck", Reflection.BindingFlags.InvokeMethod, Nothing, obj, args)
                            v_lngErrCode = CType(retval, Long)
                            'Dim pv_strDataMessage As String = CType(args(0), Xml.XmlDocument).InnerXml
                            'pv_xmlDocument.LoadXml(pv_strDataMessage)
                            pv_xmlDocument = CType(args(0), Xml.XmlDocument)
                            If v_lngErrCode <> ERR_SYSTEM_OK And v_lngErrCode <> ERR_SA_CHECKER1_OVR And v_lngErrCode <> ERR_SA_CHECKER2_OVR Then
                                v_strErrorMessage = v_strErrorSource & ".Step: " & v_strMODULE & ".txCheck"
                                'Tráº£ vá»? mÃ£ lá»—i
                                Rollback() 'ContextUtil.SetAbort()
                                Return v_lngErrCode
                            End If
                        End If
                    End If
                Next
            End If
            'Check pool / room
            v_lngErrCode = HostPoolRoomCheck(pv_xmlDocument)

            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    'HÃ m nÃ y Ä‘Æ°á»£c gá»?i Ä‘á»ƒ thá»±c hiá»‡n cáº­p nháº­t cÃ¡c phÃ¢n há»‡ nghiá»‡p vá»¥
    'Biáº¿n vÃ o:  pv_xmlDocument lÃ  xmlDocument Ä‘Ã£ Ä‘Æ°á»£c GenAPPMAP
    Private Function HostAppUpdate(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.txRouter.HostAppUpdate", v_strErrorMessage As String
        Dim v_objEval As New Evaluator
        Dim v_ds As DataSet, v_strSQL As String
        Dim i As Integer, v_strMODULE As String, v_appMODULE As CoreBusiness.txMaster
        Dim v_obj As New DataAccess
        Try
            Dim v_strTXDATE, v_strTXNUM, v_strTLTXCD, v_strDELTD As String
            v_strTXDATE = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value.ToString
            v_strTXNUM = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value.ToString
            v_strTLTXCD = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value.ToString
            v_strDELTD = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value.ToString
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False)
            v_obj.NewDBInstance(gc_MODULE_HOST)

            'Xác định các phân hệ nghiệp vụ cần kiểm tra, xử lý
            v_strSQL = "SELECT DISTINCT APPTYPE FROM APPMAP WHERE TLTXCD ='" & v_strTLTXCD & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To v_ds.Tables(0).Rows.Count - 1
                    'Xác định các phân hệ nghiệp vụ
                    v_strMODULE = Trim(v_ds.Tables(0).Rows(i)(0))
                    If String.Compare(v_strMODULE, SUB_SYSTEM_GL) <> 0 Then
                        Dim oAssembly As System.Reflection.Assembly = System.Reflection.Assembly.Load(v_strMODULE)
                        Dim aType As System.Type = oAssembly.GetType(v_strMODULE & ".Trans")
                        If Not aType Is Nothing Then
                            Dim obj, retval As Object
                            obj = Activator.CreateInstance(aType)
                            Dim args() As Object = {pv_xmlDocument}
                            retval = aType.InvokeMember("txUpdate", Reflection.BindingFlags.InvokeMethod, Nothing, obj, args)
                            v_lngErrCode = CType(retval, Long)
                            Dim pv_strDataMessage As String = CType(args(0), Xml.XmlDocument).InnerXml
                            pv_xmlDocument.LoadXml(pv_strDataMessage)
                            If v_lngErrCode <> ERR_SYSTEM_OK Then
                                v_strErrorMessage = v_strErrorSource & ".Step: " & v_strMODULE & ".HostAppUpdate"
                                'Trả vể mã lỗi
                                Rollback() 'ContextUtil.SetAbort()
                                Return v_lngErrCode
                            End If
                        Else
                            LogError.Write("Log source: " & "txRouter.Batch.Atype is nothing" & vbNewLine _
                                 & "Object: " & v_strMODULE & ".Trans" & vbNewLine _
                                 & "Message: " & pv_xmlDocument.InnerXml, "EventLogEntryType.Error")
                        End If
                    End If
                Next
            End If
            'Update pool / room
            v_lngErrCode = HostPoolRoomUpdate(pv_xmlDocument)

            v_lngErrCode = CheckSend2Bank(pv_xmlDocument)

            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        Finally
            v_obj = Nothing
        End Try
    End Function

    'HÃ m nÃ y Ä‘Æ°á»£c gá»?i Ä‘á»ƒ thá»±c hiá»‡n cáº­p nháº­t GL vÃ  TLLOG
    'Biáº¿n vÃ o:  pv_xmlDocument lÃ  xmlDocument Ä‘Ã£ cÃ³ POSTMAP
    Private Function HostTransUpdate(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.txRouter.HostTransUpdate", v_strErrorMessage As String
        Dim v_DataAccess As New DataAccess, v_ds As DataSet, v_strSQL As String
        Dim i As Integer, v_strMODULE As String, v_appMODULE As CoreBusiness.txMaster
        Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value.ToString
        Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value.ToString
        Dim v_strTLTXCD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value.ToString
        Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value.ToString
        Dim v_strBATCHNAME As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBATCHNAME).Value.ToString
        Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False)
        Try
            'Cập nhật TLLOG
            Dim v_objMsgLog As New MessageLog
            v_objMsgLog.NewDBInstance(gc_MODULE_HOST)
            v_DataAccess.NewDBInstance(gc_MODULE_HOST)
            If Not v_blnReversal Then
                'Kiá»ƒm tra náº¿u lÃ  giao dá»‹ch cháº¡y batch thÃ¬ chá»‰ cáº­p nháº­t láº¡i tráº¡ng thÃ¡i
                If v_strBATCHNAME.Trim <> DAILY_TRANSACTION Then
                    v_lngErrCode = v_objMsgLog.TransUpdateStatus(pv_xmlDocument)
                    v_lngErrCode = v_objMsgLog.MitranLog(pv_xmlDocument)
                Else
                    'v_lngErrCode = v_objMsgLog.TransLog(pv_xmlDocument)
                    'LocalDB TruongLD add
                    'v_lngErrCode = v_objMsgLog.TransLog(pv_xmlDocument)
                    v_strSQL = "SELECT * FROM TLLOG WHERE TXNUM='" & v_strTXNUM & "'"
                    v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows(0)(0) > 0 Then
                        v_lngErrCode = v_objMsgLog.TransUpdateStatus(pv_xmlDocument)
                    Else
                        v_lngErrCode = v_objMsgLog.TransLog(pv_xmlDocument)
                    End If
                    'End TruongLD
                End If
                If v_lngErrCode <> ERR_SYSTEM_OK Then
                    Rollback() 'ContextUtil.SetAbort()
                    Return v_lngErrCode
                End If
            Else
                v_lngErrCode = v_objMsgLog.TransDelete(pv_xmlDocument)
                If v_lngErrCode <> ERR_SYSTEM_OK Then
                    Rollback() 'ContextUtil.SetAbort()
                    Return v_lngErrCode
                End If
            End If

            'Cập nhật GL
            Dim v_nodeData As Xml.XmlNode
            v_nodeData = pv_xmlDocument.SelectSingleNode("/TransactMessage/postmap")
            If Not v_nodeData Is Nothing Then
                'Cập nhật tài khoản GL nếu có POSTMAP
                v_appMODULE = New GL.Trans
                If Not v_blnReversal Then
                    'Checking
                    v_lngErrCode = v_appMODULE.txCheck(pv_xmlDocument)
                    If v_lngErrCode = ERR_SYSTEM_OK Then
                        'Update
                        v_lngErrCode = v_appMODULE.txUpdate(pv_xmlDocument)
                        If v_lngErrCode <> ERR_SYSTEM_OK Then
                            LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                         & "Error code: System error!" & vbNewLine _
                                         & "Error message: " & v_strTLTXCD & "." & v_strTXDATE & "." & v_strTXNUM, "EventLogEntryType.Error")
                            Rollback() 'ContextUtil.SetAbort()
                            Return v_lngErrCode
                        End If
                    Else
                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                     & "Error code: System error!" & vbNewLine _
                                     & "Error message: " & v_strTLTXCD & "." & v_strTXDATE & "." & v_strTXNUM, "EventLogEntryType.Error")
                        Rollback() 'ContextUtil.SetAbort()
                        Return v_lngErrCode
                    End If
                Else
                    v_lngErrCode = v_appMODULE.txUpdate(pv_xmlDocument)
                    If v_lngErrCode <> ERR_SYSTEM_OK Then
                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                     & "Error code: System error!" & vbNewLine _
                                     & "Error message: " & v_strTLTXCD & "." & v_strTXDATE & "." & v_strTXNUM, "EventLogEntryType.Error")
                        Rollback() 'ContextUtil.SetAbort()
                        Return v_lngErrCode
                    End If
                End If
                v_appMODULE = Nothing
            End If

            'Xử lý nếu là giao dịch chuyển quỹ
            If v_strTLTXCD = gc_GL_CASHTRF Then
                v_lngErrCode = CashTransfer(pv_xmlDocument)
                If v_lngErrCode <> ERR_SYSTEM_OK Then
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: System error!" & vbNewLine _
                                 & "Error message: " & v_strTLTXCD & "." & v_strTXDATE & "." & v_strTXNUM, "EventLogEntryType.Error")
                    Rollback() 'ContextUtil.SetAbort()
                    Return v_lngErrCode
                End If
            End If

            'Corebank transaction --> enqueue
            v_strSQL = "SELECT MSQRQR FROM TLTX WHERE TLTXCD='" & v_strTLTXCD & "' AND MSQRQR='Y' AND MNEM <> 'INQ'"
            v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_lngErrCode = MessageEnqueue(pv_xmlDocument)
            End If
            ''Distribute message via message bus layer channel           
            'v_strSQL = "SELECT count(*) FROM BUSMAPTX WHERE TLTXCD='" & v_strTLTXCD & "'"
            'v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'If v_ds.Tables(0).Rows(0)(0) > 0 Then
            '    v_lngErrCode = DistributeMessageBus(pv_xmlDocument)
            'End If

            'If Not (v_ds Is Nothing) Then
            '    v_ds.Dispose()
            'End If

            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function


    Private Function HostPoolRoomCheck(ByVal pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.txRouter.HostPoolRoomCheck"
        Dim v_strStoredName As String
        Dim v_xmlMessage As New Xml.XmlDocument
        Dim v_strMessage As String
        Try
            'Remove appchk note
            If Not pv_xmlDocument.SelectSingleNode("/TransactMessage/appchk") Is Nothing Then
                pv_xmlDocument.SelectSingleNode("/TransactMessage/appchk").RemoveAll()
            End If

            v_strMessage = pv_xmlDocument.InnerXml

            Dim v_DataAccess As New DataAccess, v_ds As DataSet
            v_DataAccess.NewDBInstance(gc_MODULE_HOST)
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            v_strStoredName = Convert.ToString(CType(v_attrColl.GetNamedItem(gc_AtributeTLTXCD), Xml.XmlAttribute).Value)
            v_strStoredName = "txpks_prchk.fn_prAutoCheck"
            Dim v_objParam As New StoreParameter
            Dim v_arrPara(3) As StoreParameter

            v_objParam.ParamName = "return"
            v_objParam.ParamDirection = ParameterDirection.ReturnValue
            v_objParam.ParamValue = 0
            v_objParam.ParamSize = 100
            v_objParam.ParamType = GetType(Double).Name
            v_arrPara(0) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_xmlmsg"
            v_objParam.ParamValue = v_strMessage
            v_objParam.ParamDirection = ParameterDirection.InputOutput
            v_objParam.ParamSize = 32000
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(1) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_err_code"
            v_objParam.ParamDirection = ParameterDirection.Output
            v_objParam.ParamValue = ""
            v_objParam.ParamSize = 100
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(2) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_err_param"
            v_objParam.ParamDirection = ParameterDirection.Output
            v_objParam.ParamValue = ""
            v_objParam.ParamSize = 300
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(3) = v_objParam

            v_strMessage = v_DataAccess.ExecuteOracleStored(v_strStoredName, v_arrPara, 1)

            If Not IsNumeric(v_arrPara(2).ParamValue) Then
                v_lngErrCode = 0
            Else
                v_lngErrCode = CDec(v_arrPara(2).ParamValue)
            End If
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback()
                Return v_lngErrCode
            End If
            Complete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function HostPoolRoomUpdate(ByVal pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.txRouter.HostPoolRoomUpdate"
        Dim v_strStoredName As String
        Dim v_xmlMessage As New Xml.XmlDocument
        Dim v_strMessage As String
        Try
            'Remove appmap note
            If Not pv_xmlDocument.SelectSingleNode("/TransactMessage/appmap") Is Nothing Then
                pv_xmlDocument.SelectSingleNode("/TransactMessage/appmap").RemoveAll()
            End If
            'Remove appchk note
            If Not pv_xmlDocument.SelectSingleNode("/TransactMessage/appchk") Is Nothing Then
                pv_xmlDocument.SelectSingleNode("/TransactMessage/appchk").RemoveAll()
            End If

            v_strMessage = pv_xmlDocument.InnerXml

            Dim v_DataAccess As New DataAccess, v_ds As DataSet
            v_DataAccess.NewDBInstance(gc_MODULE_HOST)
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            v_strStoredName = Convert.ToString(CType(v_attrColl.GetNamedItem(gc_AtributeTLTXCD), Xml.XmlAttribute).Value)
            v_strStoredName = "txpks_prchk.fn_prAutoUpdate"
            Dim v_objParam As New StoreParameter
            Dim v_arrPara(3) As StoreParameter

            v_objParam.ParamName = "return"
            v_objParam.ParamDirection = ParameterDirection.ReturnValue
            v_objParam.ParamValue = 0
            v_objParam.ParamSize = 100
            v_objParam.ParamType = GetType(Double).Name
            v_arrPara(0) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_xmlmsg"
            v_objParam.ParamValue = v_strMessage
            v_objParam.ParamDirection = ParameterDirection.InputOutput
            v_objParam.ParamSize = 32000
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(1) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_err_code"
            v_objParam.ParamDirection = ParameterDirection.Output
            v_objParam.ParamValue = ""
            v_objParam.ParamSize = 100
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(2) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_err_param"
            v_objParam.ParamDirection = ParameterDirection.Output
            v_objParam.ParamValue = ""
            v_objParam.ParamSize = 300
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(3) = v_objParam

            v_strMessage = v_DataAccess.ExecuteOracleStored(v_strStoredName, v_arrPara, 1)

            If Not IsNumeric(v_arrPara(2).ParamValue) Then
                v_lngErrCode = 0
            Else
                v_lngErrCode = CDec(v_arrPara(2).ParamValue)
            End If
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback()
                Return v_lngErrCode
            End If
            Complete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function


    Private Function CashTransfer(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "GL.Trans.AdjustMITRAN", v_strErrorMessage As String
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strSQL, v_strFLDCD, v_strFLDTYPE, v_strVALUE As String, v_dblVALUE, v_dblAMT As Double, i As Integer
        Dim v_strTOTLID, v_strCCYCD, v_strDORC, v_strDESCRIPTION As String

        Try
            Dim v_strBRID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value
            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value
            Dim v_strTXTIME As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTIME).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            Dim v_strTLID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTLID).Value
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strTLTXCD As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLTXCD), Xml.XmlAttribute).Value)

            Dim v_obj As New DataAccess, v_ds As DataSet
            v_obj.NewDBInstance(gc_MODULE_HOST)
            'Ä?á»?c ná»™i dung giao dá»‹ch tÃ­nh lÃ£i cá»™ng dá»“n: 1160
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
                        Case "03" 'TOTLID: NgÆ°á»?i nháº­n
                            v_strTOTLID = v_strVALUE
                        Case "05" 'CCYCD
                            v_strCCYCD = v_strVALUE
                        Case "10" 'AMT
                            v_dblAMT = v_dblVALUE
                        Case "30" 'DESCRIPTION
                            v_strDESCRIPTION = v_strVALUE
                    End Select
                End With
            Next

            Dim v_strFROMACCTNO As String = v_strBRID & v_strCCYCD & v_strTLID
            Dim v_strTOACCTNO As String = v_strBRID & v_strCCYCD & v_strTOTLID
            If v_blnReversal Then 'Náº¿u lÃ  xoÃ¡ giao dá»‹ch
                v_strSQL = "UPDATE CHTRAN SET DELTD='" & v_strDELTD & "' " _
                    & "WHERE TXDATE = TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') AND TXNUM = '" & v_strTXNUM & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                v_strSQL = "UPDATE CHMAST SET BALANCE=BALANCE-(" & v_dblAMT & ") WHERE ACCTNO = '" & v_strTOACCTNO & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                v_strSQL = "UPDATE CHMAST SET BALANCE=BALANCE+(" & v_dblAMT & ") WHERE ACCTNO = '" & v_strFROMACCTNO & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            Else 'Náº¿u khÃ´ng pháº£i xoÃ¡ giao dá»‹ch
                'Kiá»ƒm tra náº¿u chÆ°a cÃ³ báº£n ghi trong CHMAST thÃ¬ táº¡o má»›i
                'BÃªn chuyá»ƒn
                v_strSQL = "SELECT * FROM CHMAST WHERE ACCTNO='" & v_strFROMACCTNO & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    'Cáº­p nháº­t sá»‘ dÆ°: Giáº£m bÃªn chuyá»ƒn
                    v_strSQL = "UPDATE CHMAST SET BALANCE=NVL(BALANCE,0)-(" & v_dblAMT.ToString & ") WHERE ACCTNO='" & v_strFROMACCTNO & "'"
                Else
                    'Táº¡o báº£n ghi má»›i
                    v_strSQL = "INSERT INTO CHMAST (ACCTNO, BRID, CCYCD, TLID, BALANCE) VALUES ('" & v_strFROMACCTNO & "','" & v_strBRID & "','" & v_strCCYCD & "','" & v_strTLID & "'," & (-v_dblAMT).ToString & ")"
                End If
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                'BÃªn nháº­n
                v_strSQL = "SELECT * FROM CHMAST WHERE ACCTNO='" & v_strTOACCTNO & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    'Cáº­p nháº­t sá»‘ dÆ°: Giáº£m tÄƒng nháº­n
                    v_strSQL = "UPDATE CHMAST SET BALANCE=NVL(BALANCE,0)+(" & v_dblAMT.ToString & ") WHERE ACCTNO='" & v_strTOACCTNO & "'"
                Else
                    'Táº¡o báº£n ghi má»›i
                    v_strSQL = "INSERT INTO CHMAST (ACCTNO, BRID, CCYCD, TLID, BALANCE) VALUES ('" & v_strTOACCTNO & "','" & v_strBRID & "','" & v_strCCYCD & "','" & v_strTOTLID & "'," & (v_dblAMT).ToString & ")"
                End If
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                v_ds.Dispose()

                'Ghi nháº­n phÃ¡t sinh
                v_strSQL = " INSERT INTO CHTRAN " _
                            & " (TXDATE,TXNUM,SUBTXNO,DORC,ACCTNO,AMT,REF,DELTD) " _
                            & " VALUES " _
                            & " (TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'" & v_strTXNUM & "'," _
                            & "1,'D','" & v_strFROMACCTNO & "'," _
                            & v_dblAMT & ",'" & v_strTOACCTNO & "','N') "
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                v_strSQL = " INSERT INTO CHTRAN " _
                            & " (TXDATE,TXNUM,SUBTXNO,DORC,ACCTNO,AMT,REF,DELTD) " _
                            & " VALUES " _
                            & " (TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'" & v_strTXNUM & "'," _
                            & "1,'C','" & v_strTOACCTNO & "'," _
                            & v_dblAMT & ",'" & v_strFROMACCTNO & "','N') "
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End If

            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function MessageEnqueue(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "TxRouter.MessageEnqueue", v_strErrorMessage As String
        Dim v_strMsg As String
        Dim v_strSQL As String
        Dim v_objHost As New DataAccess, v_dsHost As DataSet
        v_objHost.NewDBInstance(gc_MODULE_HOST)

        Try
            Dim v_strMSGID, v_strQUEUENAME, v_strRECEIVEDATE, v_strRECEIVETIME, v_strSENDTIME, v_strSENDDATE,
                            v_strTXNUM, v_strTXDATE, v_strTXTIME, v_strBRID, v_strTLID, v_strOFFID, v_strCHID, v_strCHKID As String
            Dim v_strTLTXCD, v_strBRDATE, v_strBUSDATE, v_strTXCODE, v_strACCTNO, v_strACCTNO2, v_strBANKCODE, v_strBANKERRDESC, v_strBANKREF, v_strERRNUM As String
            Dim v_strBANKERRNUM As String
            Dim v_xmlDocument As New Xml.XmlDocument, v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_nodetxData As Xml.XmlNode
            Dim v_strFLDNAME As String

            v_strTLTXCD = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value.ToString
            v_strSQL = "SELECT * FROM TLTX WHERE TLTXCD='" & v_strTLTXCD & "'"
            v_dsHost = v_objHost.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_dsHost.Tables(0).Rows.Count > 0 Then
                v_strTXCODE = v_dsHost.Tables(0).Rows(0)("MNEM")
            End If


            v_nodetxData = pv_xmlDocument.SelectSingleNode("TransactMessage/fields/entry[@defname='BANKACCT']")
            If Not v_nodetxData Is Nothing Then
                v_strACCTNO = v_nodetxData.InnerText
            Else
                v_strACCTNO = ""
            End If
            v_nodetxData = pv_xmlDocument.SelectSingleNode("TransactMessage/fields/entry[@defname='DESACCOUNT']")
            If Not v_nodetxData Is Nothing Then
                v_strACCTNO2 = v_nodetxData.InnerText
            Else
                v_strACCTNO2 = ""
            End If
            v_nodetxData = pv_xmlDocument.SelectSingleNode("TransactMessage/fields/entry[@defname='BANKNAME']")
            If Not v_nodetxData Is Nothing Then
                v_strBANKCODE = Mid(v_nodetxData.InnerText, 1, 3)
            Else
                v_strBANKCODE = ""
            End If
            v_nodetxData = pv_xmlDocument.SelectSingleNode("TransactMessage/fields/entry[@defname='BANKQUE']")
            If Not v_nodetxData Is Nothing Then
                v_strQUEUENAME = v_nodetxData.InnerText
            Else
                v_strQUEUENAME = ""
            End If

            v_strTXDATE = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value.ToString
            v_strTXNUM = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value.ToString
            v_strTXTIME = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTIME).Value.ToString
            v_strBRID = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value.ToString
            v_strTLID = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTLID).Value.ToString
            v_strOFFID = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value.ToString
            v_strCHID = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHID).Value.ToString
            v_strCHKID = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value.ToString
            v_strBRDATE = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRDATE).Value.ToString
            v_strBUSDATE = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBUSDATE).Value.ToString
            v_strBANKERRNUM = 0
            v_strBANKERRDESC = ""
            v_strBANKREF = ""
            v_strERRNUM = ""

            v_strMsg = BuildXMLEAIMsg(v_strMSGID, v_strQUEUENAME, v_strRECEIVEDATE, v_strRECEIVETIME, v_strSENDTIME, v_strSENDDATE, v_strTXNUM, v_strTXDATE, v_strTXTIME, v_strBRID, v_strTLID, v_strOFFID, v_strCHID, v_strCHKID, v_strTLTXCD, v_strBRDATE, v_strBUSDATE, v_strTXCODE, v_strACCTNO, v_strACCTNO2, v_strBANKCODE, v_strBANKERRNUM, v_strBANKERRDESC, v_strBANKREF, v_strERRNUM)
            v_xmlDocument.LoadXml(v_strMsg)
            v_entryNode = v_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "TxMessage", "")
            v_entryNode.InnerXml = pv_xmlDocument.InnerXml
            v_xmlDocument.DocumentElement.AppendChild(v_entryNode)
            v_strMsg = v_xmlDocument.InnerXml
            If Not Mid(v_strTLTXCD, 3, 2) = "71" Then
                'Day message vao queue
                v_lngErrCode = SecuritiesEnqueue(v_strMsg)

            Else
                'La giao dich tra cuu day thang sang CoreBank Webservice

            End If
            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try

    End Function
    Private Function CheckTLTXBRMap(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_DataAccess As New DataAccess, v_ds, v_dsACTYPE As DataSet
        v_DataAccess.NewDBInstance(gc_MODULE_HOST)
        Dim v_strSQL As String
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.txRouter.CheckTLTXBRMap", v_strErrorMessage As String
        Dim v_strxmlMessage As String, v_xmlMessage As New Xml.XmlDocument, v_nodetxData As Xml.XmlNode
        Dim v_strTLTXCD, v_strTLID, v_strDELTD, v_strREFACCT, v_strBRID, v_strPRBRID, v_strSTATUS As String
        Dim v_strREFBANKID, v_strCUSTID, v_strREFTYPE, v_strSUBTYPE, v_strAMTEXP, v_strAMT As String
        Try

            v_strTLTXCD = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value.ToString
            v_strTLID = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTLID).Value.ToString
            v_strREFACCT = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeMSGACCT).Value.ToString
            v_strDELTD = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value.ToString
            v_strSTATUS = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeSTATUS).Value.ToString
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False
            If v_strSTATUS = TransactStatus.Deleting Then
                v_blnReversal = True
            End If


            'Kiểm tra phân quyền theo Branch
            If v_strREFACCT.Trim.Length >= 4 Then
                v_strBRID = v_strREFACCT.Substring(4)
                v_strPRBRID = v_strREFACCT.Substring(2) & "01"
                v_strSQL = "SELECT AUTOID FROM TLTXEXTBR MST " &
                    "WHERE MST.TLTXCD ='" & v_strTLTXCD & "' AND MST.BRID IN ('" & v_strBRID & "','" & v_strPRBRID & "') " &
                    "AND ((MST.TLTYPE='U' AND MST.TLCODE='" & v_strTLID & "') OR (MST.TLTYPE='G' AND MST.TLCODE IN (SELECT GRPID FROM TLGRPUSERS WHERE TLID='" & v_strTLID & "'))) "
                v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_lngErrCode = ERR_SA_TLTX_TL_GRP_INVALID_BRANCH
                    Return v_lngErrCode
                End If
            End If

            'Kiểm tra phân quyền hạn mức: Chỉ kiểm tra lúc thực hiện giao dịch không cần kiểm tra lúc xóa
            If Not v_blnReversal Then
                v_strSQL = "SELECT TLTXCD, LMSUBTYPE, FLDREFBANK, FLDREFTYP, FLDACCTNO, AMTEXP FROM CFLIMITMAP MST " &
                    "WHERE MST.TLTXCD ='" & v_strTLTXCD & "'"
                v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_strCUSTID = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("FLDACCTNO")).Trim   'Trường AFMAST.ACCTNO

                    v_strREFTYPE = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("FLDREFTYP")).Trim
                    v_strREFBANKID = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("FLDREFBANK")).Trim

                    v_strSUBTYPE = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("LMSUBTYPE")).Trim
                    v_strAMTEXP = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("AMTEXP")).Trim

                    v_strCUSTID = GetReferenceValueForAMTEXP(pv_xmlDocument, v_strCUSTID)
                    v_strREFBANKID = GetReferenceValueForAMTEXP(pv_xmlDocument, v_strREFBANKID)
                    v_strAMT = GetReferenceValueForAMTEXP(pv_xmlDocument, v_strAMTEXP)

                    v_strSQL = "SELECT CUSTID RET FROM AFMAST WHERE ACCTNO='" & v_strCUSTID & "'"
                    v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count > 0 Then
                        v_strCUSTID = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("RET")).Trim
                    End If

                    If v_strREFTYPE = "AF" Then
                        'Lấy qua AFMAST.ACCTNO
                        v_strSQL = "SELECT CUSTID RET FROM AFMAST WHERE ACCTNO='" & v_strREFBANKID & "'"
                    ElseIf v_strREFTYPE = "AD" Then
                        'Lấy qua ADTYPE
                        v_strSQL = "SELECT CUSTBANK RET FROM ADTYPE WHERE ACTYPE='" & v_strREFBANKID & "'"
                    ElseIf v_strREFTYPE = "LN" Then
                        'Lấy qua LNTYPE
                        v_strSQL = "SELECT CUSTBANK RET FROM LNTYPE WHERE ACTYPE='" & v_strREFBANKID & "'"
                    ElseIf v_strREFTYPE = "DF" Then
                        ''Lấy qua DFTYPE
                        v_strSQL = "SELECT LN.CUSTBANK RET FROM LNTYPE LN, DFTYPE DF WHERE LN.ACTYPE=DF.LNTYPE AND DF.ACTYPE='" & v_strREFBANKID & "'"
                    Else
                        'Mặc định là đã chỉ ra luôn
                        v_strSQL = String.Empty
                    End If
                    If v_strSQL.Length > 0 Then
                        v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                        If v_ds.Tables(0).Rows.Count > 0 Then
                            v_strREFBANKID = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("RET")).Trim
                        End If
                    End If

                    'Có check hạn mức sẽ gọi hàm check. Hàm này trả về giá trị là mã lỗi luôn
                    v_strSQL = "SELECT cspks_cfproc.fn_func_getcflimit('" & v_strREFBANKID & "','" & v_strCUSTID & "','" & v_strSUBTYPE & "'," & v_strAMT & ") RET FROM DUAL "
                    v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    v_lngErrCode = v_ds.Tables(0).Rows(0)(0)
                    Return v_lngErrCode
                End If
            End If

            Return v_lngErrCode
            Complete()
        Catch ex As Exception
            Rollback()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function SecuritiesEnqueue(ByRef pv_strMessageQueue As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "TxRouter.SecuritiesEnqueue", v_strErrorMessage As String
        Dim v_objRptParam As StoreParameter
        Dim v_arrRptPara() As StoreParameter
        Dim v_objQueue As New DataAccess, v_dsQueue As DataSet
        v_objQueue.NewDBInstance(gc_MODULE_QUEUE)
        'QueueName parameter
        Try
            v_objRptParam = New StoreParameter
            ReDim v_arrRptPara(2)
            v_objRptParam.ParamName = "queue"
            v_objRptParam.ParamValue = ConfigurationSettings.AppSettings(gc_MODULE_QUEUE & ".OUTBOX").ToString().Trim()
            v_objRptParam.ParamSize = CInt(100)
            v_objRptParam.ParamType = "VARCHAR2"
            v_arrRptPara(0) = v_objRptParam
            'Consumer parameter
            v_objRptParam = New StoreParameter
            v_objRptParam.ParamName = "consumer"
            v_objRptParam.ParamValue = "VNDS"
            v_objRptParam.ParamSize = CInt(100)
            v_objRptParam.ParamType = "VARCHAR2"
            v_arrRptPara(1) = v_objRptParam

            'Consumer parameter
            v_objRptParam = New StoreParameter
            v_objRptParam.ParamName = "messages"
            v_objRptParam.ParamValue = pv_strMessageQueue
            v_objRptParam.ParamSize = CInt(4000)
            v_objRptParam.ParamType = "VARCHAR2"
            v_arrRptPara(2) = v_objRptParam
            v_objQueue.ExecuteStoredNonQuerry("SEC_ENQ", v_arrRptPara)
            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try

    End Function
    Private Function RemapToken(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.txRouter.RemapToken", v_strErrorMessage As String
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE, v_strCONFIRMPIN, v_strPIN As String, v_dblVALUE As Double
            Dim v_strCustodyCD, v_strCurrType, v_strCurrTokenId, v_strNewType, v_strNewTokenId As String
            Dim v_DataAccess As New DataAccess, v_ds As DataSet
            Dim v_strObjMsg As String


            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False

            'Ä?á»?c ná»™i dung giao dá»‹ch
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
                        Case "88" 'Custodycd
                            v_strCustodyCD = v_strVALUE
                        Case "09" 'CurrAuthType
                            v_strCurrType = v_strVALUE
                        Case "11" 'CurrTokenId
                            v_strCurrTokenId = v_strVALUE
                        Case "12" 'NewAuthType
                            v_strNewType = v_strVALUE
                        Case "15" 'NewTokenId
                            v_strNewTokenId = v_strVALUE
                    End Select
                End With
            Next
            If v_strCurrTokenId = v_strNewTokenId Then
                Return -180066
            End If
            If v_strCurrType <> gc_TokenType And v_strCurrType <> gc_MatrixType Then
                ' Neu dang khong su dung loai xac thuc token va matrix thi la add moi
                'Xoa user truoc khi add moi
                v_strObjMsg = CallIDService("DELETEUSER", v_strCustodyCD, v_strCurrTokenId, v_lngErrCode, v_strErrorMessage, 1)
                v_strObjMsg = CallIDService("DELETEUSER", v_strCustodyCD, v_strCurrTokenId, v_lngErrCode, v_strErrorMessage, 2)

                If v_strNewType = gc_TokenType Then
                    '3.Create User
                    v_strObjMsg = CallIDService("CREATEUSER", v_strCustodyCD, v_strCurrTokenId, v_lngErrCode, v_strErrorMessage, 1)
                    'Assign Token
                    v_strObjMsg = CallIDService("ADDTOKEN", v_strCustodyCD, v_strNewTokenId, v_lngErrCode, v_strErrorMessage)

                ElseIf v_strNewType = gc_MatrixType Then
                    '3.Create User
                    v_strObjMsg = CallIDService("CREATEUSER", v_strCustodyCD, v_strNewTokenId, v_lngErrCode, v_strErrorMessage, 2)
                    'Assign Matrix
                    v_strObjMsg = CallIDService("ADDMATRIX", v_strCustodyCD, v_strNewTokenId, v_lngErrCode, v_strErrorMessage)
                End If
            Else
                ' Thay doi
                If v_strCurrType = gc_TokenType Then
                    If v_strNewType = gc_PinType Then
                        If v_strCurrTokenId <> v_strNewTokenId Then
                            'Token -> Pin
                            '1.UnAssign Token
                            v_strObjMsg = CallIDService("REMOVETOKEN", v_strCustodyCD, v_strCurrTokenId, v_lngErrCode, v_strErrorMessage)
                            '2.Drop User 
                            v_strObjMsg = CallIDService("DELETEUSER", v_strCustodyCD, v_strCurrTokenId, v_lngErrCode, v_strErrorMessage, 1)
                        End If
                    End If
                    If v_strNewType = gc_TokenType Then
                        If v_strCurrTokenId <> v_strNewTokenId Then
                            'Token -> Token
                            '1.UnAssign Token
                            v_strObjMsg = CallIDService("REMOVETOKEN", v_strCustodyCD, v_strCurrTokenId, v_lngErrCode, v_strErrorMessage)

                            'Assign Token
                            v_strObjMsg = CallIDService("ADDTOKEN", v_strCustodyCD, v_strNewTokenId, v_lngErrCode, v_strErrorMessage)

                        End If
                    End If
                    If v_strNewType = gc_MatrixType Then
                        'Token -> matrix
                        '1.UnAssign Token
                        v_strObjMsg = CallIDService("REMOVETOKEN", v_strCustodyCD, v_strCurrTokenId, v_lngErrCode, v_strErrorMessage)
                        '2.Drop User
                        v_strObjMsg = CallIDService("DELETEUSER", v_strCustodyCD, v_strCurrTokenId, v_lngErrCode, v_strErrorMessage, 1)
                        '3.Create User
                        v_strObjMsg = CallIDService("CREATEUSER", v_strCustodyCD, v_strCurrTokenId, v_lngErrCode, v_strErrorMessage, 2)
                        '4.Assign Matrix
                        v_strObjMsg = CallIDService("ADDMATRIX", v_strCustodyCD, v_strNewTokenId, v_lngErrCode, v_strErrorMessage)
                    End If
                End If
                If v_strCurrType = gc_MatrixType Then
                    If v_strNewType = gc_PinType Then
                        If v_strCurrTokenId <> v_strNewTokenId Then
                            'Matrix -> Pin
                            '1.UnAssign Matrix
                            v_strObjMsg = CallIDService("REMOVEMATRIX", v_strCustodyCD, v_strCurrTokenId, v_lngErrCode, v_strErrorMessage)
                            '2.Drop User 
                            v_strObjMsg = CallIDService("DELETEUSER", v_strCustodyCD, v_strCurrTokenId, v_lngErrCode, v_strErrorMessage, 2)
                        End If
                    End If
                    If v_strNewType = gc_TokenType Then
                        'Matrix -> Token
                        ''2.Drop User
                        v_strObjMsg = CallIDService("DELETEUSER", v_strCustodyCD, v_strCurrTokenId, v_lngErrCode, v_strErrorMessage, 2)
                        '3.Create User
                        v_strObjMsg = CallIDService("CREATEUSER", v_strCustodyCD, v_strCurrTokenId, v_lngErrCode, v_strErrorMessage, 1)

                        'Assign Token
                        v_strObjMsg = CallIDService("ADDTOKEN", v_strCustodyCD, v_strNewTokenId, v_lngErrCode, v_strErrorMessage)

                    End If
                    If v_strNewType = gc_MatrixType Then
                        If v_strCurrTokenId <> v_strNewTokenId Then
                            'Matrix -> matrix
                            '1.UnAssign Matrix
                            v_strObjMsg = CallIDService("REMOVEMATRIX", v_strCustodyCD, v_strCurrTokenId, v_lngErrCode, v_strErrorMessage)
                            '4.Assign Matrix
                            v_strObjMsg = CallIDService("ADDMATRIX", v_strCustodyCD, v_strNewTokenId, v_lngErrCode, v_strErrorMessage)
                        End If
                    End If
                End If
            End If

            If v_lngErrCode <> ERR_SYSTEM_OK Then
                pv_xmlDocument.LoadXml(v_strObjMsg)
            End If
            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function UnlockToken(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.txRouter.UnlockToken", v_strErrorMessage As String
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLTmp As String = String.Empty, i As Integer
            Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE, v_strCONFIRMPIN, v_strPIN As String, v_dblVALUE As Double
            Dim v_strCustodyCD, v_strCurrType, v_strCurrTokenId, v_strNewType, v_strNewTokenId As String
            Dim v_DataAccess As New DataAccess, v_ds As DataSet
            Dim v_strObjMsg As String


            Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value
            Dim v_strTXDESC As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDESC).Value
            Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False), v_blnApproval As Boolean = False

            'Ä?á»?c ná»™i dung giao dá»‹ch
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
                        Case "88" 'Custodycd
                            v_strCustodyCD = v_strVALUE
                        Case "09" 'CurrAuthType
                            v_strCurrType = v_strVALUE
                        Case "11" 'CurrTokenId
                            v_strCurrTokenId = v_strVALUE
                    End Select
                End With
            Next
            If v_strCurrType = gc_TokenType Then
                v_strObjMsg = CallIDService("UNLOCKUSER", v_strCustodyCD, v_strCurrTokenId, v_lngErrCode, v_strErrorMessage, 1)
            End If
            If v_strCurrType = gc_MatrixType Then
                v_strObjMsg = CallIDService("UNLOCKUSER", v_strCustodyCD, v_strCurrTokenId, v_lngErrCode, v_strErrorMessage, 2)
            End If

            If v_lngErrCode <> ERR_SYSTEM_OK Then
                pv_xmlDocument.LoadXml(v_strObjMsg)
            End If
            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function CallIDService(ByVal pv_strFunctionName As String, _
                                   ByVal pv_strCustomerID As String, _
                                   ByVal pv_strSerialNumber As String, _
                                   ByRef out_lngErrorCode As Long, _
                                   ByRef out_strErrorMessage As String, _
                                   Optional ByVal pv_intFlag As Integer = 1 _
                                   ) As String
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Try
            Dim v_strObjMsg, v_strErrorCode As String
            Dim objEntryFunction = New ObjectMessageObjDataEntry
            Dim objEntryModule = New ObjectMessageObjDataEntry
            Dim objEntryCustID = New ObjectMessageObjDataEntry
            Dim objErrorCode = New ObjectMessageObjDataEntry
            Dim objErrorMessage = New ObjectMessageObjDataEntry
            Dim objEntryTokenSerial = New ObjectMessageObjDataEntry
            Dim objEntryAuthType = New ObjectMessageObjDataEntry
            Dim objEntryGroupUser = New ObjectMessageObjDataEntry
            Dim objEntries As ObjectMessageObjDataEntry()
            If pv_strFunctionName = "CREATEUSER" Or pv_strFunctionName = "DELETEUSER" Then
                objEntryGroupUser.fldname = "AUTHGROUP"
                objEntryGroupUser.fldtype = "P"
                If pv_intFlag = 1 Then ' Token 
                    objEntryGroupUser.Value = AUTH_GROUP_TOKEN
                Else
                    objEntryGroupUser.Value = AUTH_GROUP_MATRIX
                End If

                objEntries = New ObjectMessageObjDataEntry() {objEntryFunction, _
                                                             objEntryModule, _
                                                             objEntryCustID, _
                                                             objErrorCode, _
                                                             objErrorMessage, _
                                                             objEntryGroupUser, _
                                                             objEntryTokenSerial}
            Else
                objEntries = New ObjectMessageObjDataEntry() {objEntryFunction, _
                                                             objEntryModule, _
                                                             objEntryCustID, _
                                                             objEntryTokenSerial, _
                                                             objEntryAuthType, _
                                                             objErrorCode, _
                                                             objErrorMessage}
            End If

            Dim obj As ObjectMessage = New ObjectMessage()
            Dim v_xmlDocument As New Xml.XmlDocument

            'MODULE
            objEntryModule.fldname = "MODULE"
            objEntryModule.fldtype = "String"
            objEntryModule.Value = "ENTRUST"
            'FUNCTION
            objEntryFunction.fldname = "FUNCTION"
            objEntryFunction.fldtype = "String"
            objEntryFunction.Value = pv_strFunctionName
            'CUSTOMERID
            objEntryCustID.fldname = "customerId"
            objEntryCustID.fldtype = "P"
            objEntryCustID.Value = pv_strCustomerID
            'SERIALNUMBER
            objEntryTokenSerial.fldname = "serialNumer"
            objEntryTokenSerial.fldtype = "P"
            objEntryTokenSerial.Value = pv_strSerialNumber
            'ErrorCode
            objErrorCode.fldname = "p_err_code"
            objErrorCode.fldtype = "String"
            objErrorCode.Value = ERR_SYSTEM_OK
            'p_err_message
            objErrorMessage.fldname = "p_err_message"
            objErrorMessage.fldtype = "String"
            objErrorMessage.Value = String.Empty
            'AuthType
            If pv_strFunctionName = "UNLOCKUSER" Then
                objEntryAuthType.fldname = "authType"
                objEntryAuthType.fldtype = "P"

                If pv_intFlag = 1 Then ' Token 
                    objEntryTokenSerial.Value = AUTH_GROUP_TOKEN
                Else
                    objEntryTokenSerial.Value = AUTH_GROUP_MATRIX
                End If
            End If        

            'Challenge
            'ObjMessage
            obj.OBJNAME = "BD.Router"
            obj.LOCAL = gc_IsNotLocalMsg
            obj.MSGTYPE = gc_MsgTypeObj
            obj.ACTIONFLAG = gc_ActionAdhoc
            obj.FUNCTIONNAME = "executeBOFunction"
            obj.ObjData = objEntries
            v_strObjMsg = SerializeObject(obj)

            v_xmlDocument.LoadXml(v_strObjMsg)
            Dim oAssembly As System.Reflection.Assembly = System.Reflection.Assembly.Load("BD")
            Dim aType As System.Type = oAssembly.GetType("BD.Router")
            Dim objrouter, retval As Object
            objrouter = Activator.CreateInstance(aType)
            Dim args() As Object = {v_xmlDocument.InnerXml}
            retval = aType.InvokeMember("Adhoc", Reflection.BindingFlags.InvokeMethod, Nothing, objrouter, args)
            out_lngErrorCode = CType(retval, Long)
            v_strObjMsg = CType(args(0), String)
            Return v_strObjMsg
        Catch ex As Exception
            'v_strErrorMessage = ex.Message
            Throw ex
            Return False
        End Try
    End Function
#End Region

End Class
