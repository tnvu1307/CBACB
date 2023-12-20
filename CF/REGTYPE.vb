Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data

Public Class REGTYPE
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "REGTYPE"
    End Sub

#Region " Overrides functions "
    Overrides Function CheckBeforeAdd(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strAFTYPE, v_strMODCODE, v_strACTYPE As String
            Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String
            Dim v_strEXECTYPE, v_strPRICETYPE, v_strVIA, v_strTIMETYPE, v_strMATCHTYPE, v_strTRADEPLACE, v_strNORK, v_strCLEARCD, v_strSECTYPE
            Dim v_strSQL As String
            Dim v_strBRID As String

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
                        Case "AFTYPE"
                            v_strAFTYPE = Trim(v_strVALUE)
                        Case "MODCODE"
                            v_strMODCODE = Trim(v_strVALUE)
                        Case "ACTYPE"
                            v_strACTYPE = Trim(v_strVALUE)
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

            v_strSQL = "SELECT COUNT(1) FROM REGTYPE WHERE AFTYPE='" & v_strAFTYPE & "' AND MODCODE='" & v_strMODCODE & "' AND ACTYPE='" & v_strACTYPE & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 1 Then
                If gf_CorrectNumericField(v_ds.Tables(0).Rows(0)(0)) > 0 Then
                    Return ERR_CF_REGTYPE_DUPLICATE
                End If
            End If



            Select Case v_strMODCODE
                Case "OD"
                    v_strSQL = " SELECT * FROM ODTYPE WHERE ACTYPE = '" & v_strACTYPE & "' and STATUS ='Y' "
                Case "FO"
                    v_strSQL = " SELECT * FROM FOTYPE WHERE ACTYPE = '" & v_strACTYPE & "' and STATUS ='Y' "
                Case "RP"
                    v_strSQL = " SELECT * FROM RPTYPE WHERE ACTYPE = '" & v_strACTYPE & "' and STATUS ='Y' "
            End Select
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_strEXECTYPE = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("EXECTYPE")), vbNullString, v_ds.Tables(0).Rows(0)("EXECTYPE"))
                v_strVIA = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("VIA")), vbNullString, v_ds.Tables(0).Rows(0)("VIA"))
                v_strTIMETYPE = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("TIMETYPE")), vbNullString, v_ds.Tables(0).Rows(0)("TIMETYPE"))
                v_strMATCHTYPE = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("MATCHTYPE")), vbNullString, v_ds.Tables(0).Rows(0)("MATCHTYPE"))
                v_strTRADEPLACE = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("TRADEPLACE")), 0, v_ds.Tables(0).Rows(0)("TRADEPLACE"))
                v_strPRICETYPE = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("PRICETYPE")), vbNullString, v_ds.Tables(0).Rows(0)("PRICETYPE"))
                v_strCLEARCD = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("CLEARCD")), vbNullString, v_ds.Tables(0).Rows(0)("CLEARCD"))
                v_strSECTYPE = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("SECTYPE")), vbNullString, v_ds.Tables(0).Rows(0)("SECTYPE"))
                v_strNORK = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("NORK")), vbNullString, v_ds.Tables(0).Rows(0)("NORK"))



                v_strSQL = " select * from regtype where MODCODE='" & v_strMODCODE & "' AND  actype in (SELECT actype from " & v_strMODCODE & "type " _
                 & " WHERE STATUS='Y' AND ( VIA='" & v_strVIA & "'OR DECODE( '" & v_strVIA & "','A', 'A', VIA )= 'A') " & ControlChars.CrLf _
                 & " AND CLEARCD='" & IIf(v_strCLEARCD = "", "B", v_strCLEARCD) & "' " & ControlChars.CrLf _
                 & " AND (EXECTYPE='" & v_strEXECTYPE & "' OR DECODE( '" & v_strEXECTYPE & "' ,'AA','AA',EXECTYPE) ='AA') " & ControlChars.CrLf _
                 & " AND (TIMETYPE='" & v_strTIMETYPE & "' OR DECODE( '" & v_strTIMETYPE & "' ,'A','A',TIMETYPE) ='A'  )" & ControlChars.CrLf _
                 & " AND (PRICETYPE='" & v_strPRICETYPE & "' OR DECODE( '" & v_strPRICETYPE & "' ,'AA','AA',PRICETYPE ) ='AA') " & ControlChars.CrLf _
                 & " AND (MATCHTYPE='" & v_strMATCHTYPE & "' OR DECODE( '" & v_strMATCHTYPE & "' ,'A','A',MATCHTYPE)='A')" & ControlChars.CrLf _
                 & " AND (TRADEPLACE='" & v_strTRADEPLACE & "' OR DECODE( '" & v_strTRADEPLACE & "' ,'000','000',TRADEPLACE)='000')" & ControlChars.CrLf _
                 & " AND ( SECTYPE='" & v_strSECTYPE & "' OR DECODE( '" & v_strSECTYPE & "' ,'000','000',SECTYPE)='000')   " & ControlChars.CrLf _
                 & " AND (NORK='" & v_strNORK & "' OR  DECODE( '" & v_strNORK & "' ,'A','A',NORK)= 'A')) and aftype ='" & v_strAFTYPE & "'"




                ' v_strSQL = "SELECT * FROM REGTYPE WHERE  ACTYPE IN (SELECT ACTYPE FROM  ODTYPE WHERE DECODE (EXECTYPE,'AA','" & v_strEXECTYPE & "')= '" & v_strEXECTYPE & "' " _
                '& " AND  DECODE (VIA,'A', '" & v_strVIA & "')= '" & v_strVIA & "' AND  DECODE (TIMETYPE,'A', '" & v_strTIMETYPE & "')=  '" & v_strTIMETYPE & "' " _
                '& " AND  DECODE (MATCHTYPE,'A','" & v_strMATCHTYPE & "')= '" & v_strMATCHTYPE & "' AND  DECODE (TRADEPLACE,'000','" & v_strTRADEPLACE & "')= '" & v_strTRADEPLACE & "' " _
                '& " AND  DECODE (PRICETYPE,'AA', '" & v_strPRICETYPE & "')=  '" & v_strPRICETYPE & "'AND  DECODE (NORK,'AA', '" & v_strNORK & "')=  '" & v_strNORK & "'" _
                '& " AND  CLEARCD = '" & v_strCLEARCD & "' and  SECTYPE = '" & v_strSECTYPE & "' AND STATUS ='Y')"


                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    Return ERR_CF_REGTYPE_DUPLICATE
                End If
            End If
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
