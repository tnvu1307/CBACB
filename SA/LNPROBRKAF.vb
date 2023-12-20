Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Public Class LNPROBRKAF
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "LNPROBRKAF"
    End Sub

    Overrides Function CheckBeforeAdd(ByVal v_strMessage As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_strObjMsg As String
        Dim v_ds, v_ds1 As DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strACCTNO, v_strAPPLID, v_strACTYPE, v_strCCYCD, v_strGLBANK, v_strGLGRP As String
            Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE, v_strTERMCD As String, v_dblALLOWLIMIT, v_dblAPRLIMIT, v_dblRATE As Double, v_lngTERM As Long
            Dim v_strSQL As String
            Dim v_strTRFACCTNO, v_strLNTYPE, v_strCUSTID, v_strSTATUS, v_strAPPLNTYPE, v_strRLSDATE, v_strENDDATE, v_strFIRSTDT, v_strEXPDT As String
            Dim v_blnPRINAFT, v_blnINTAFT As Boolean
            Dim v_strCURRDATE As String
            Dim v_autoid, v_refautoid, v_afacctno As String

            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If

            v_autoid = String.Empty
            v_refautoid = String.Empty
            v_afacctno = String.Empty


            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strVALUE = .InnerText.ToString()
                    Select Case Trim(v_strFLDNAME)
                        Case "AUTOID"
                            v_autoid = Trim(v_strVALUE)
                        Case "REFAUTOID"
                            v_refautoid = Trim(v_strVALUE)
                        Case "AFACCTNO"
                            v_afacctno = Trim(v_strVALUE)

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

            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "CURRDATE", v_strCURRDATE)

            'Kiểm tra ACCTNO không được trùng
            v_strSQL = "select applyrulecd from LNPROBRKMST where autoid ='" & v_refautoid & "'"
            v_ds1 = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds1.Tables(0).Rows.Count >= 1 Then
                'neu bang A thi check
                If v_ds1.Tables(0).Rows(0)(0) = "A" Then
                    If v_afacctno.Length > 0 Then
                        v_strSQL = "select COUNT(*) from LNPROBRKAF LF, LNPROBRKMST LT  where(LF.REFAUTOID = LT.AUTOID) and LT.APPLYRULECD = 'A' and LF.afacctno = '" & v_afacctno & "'"
                        v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                        If v_ds.Tables(0).Rows.Count = 1 Then
                            If v_ds.Tables(0).Rows(0)(0) > 0 Then
                                Return ERR_SA_ACCTNO_DUPLICATED
                            End If
                        End If
                    End If
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

    Overrides Function CheckBeforeEdit(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strACCTNO, v_strAPPLID, v_strACTYPE, v_strCCYCD, v_strGLBANK, v_strGLGRP As String
            Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE, v_strTERMCD As String, v_dblALLOWLIMIT, v_dblAPRLIMIT, v_dblRATE As Double, v_lngTERM As Long
            Dim v_strSQL As String
            Dim v_strTRFACCTNO, v_strLNTYPE, v_strCUSTID, v_strSTATUS, v_strAPPLNTYPE As String
            Dim v_blnPRINAFT, v_blnINTAFT As Boolean
            Dim v_autoid, v_refautoid, v_afacctno As String


            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If
            v_autoid = String.Empty
            v_refautoid = String.Empty
            v_afacctno = String.Empty

            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strVALUE = .InnerText.ToString()
                    Select Case Trim(v_strFLDNAME)
                        Case "AUTOID"
                            v_autoid = Trim(v_strVALUE)
                        Case "REFAUTOID"
                            v_refautoid = Trim(v_strVALUE)
                        Case "AFACCTNO"
                            v_afacctno = Trim(v_strVALUE)
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



            'Kiểm tra ACCTNO không được trùng
            If v_afacctno.Length > 0 Then
                v_strSQL = "select count(1) from LNPROBRKAF LF, LNPROBRKMST LT  where(LF.REFAUTOID = LT.AUTOID) and LT.APPLYRULECD = 'A' and LF.afacctno = '" & v_afacctno & "' AND LF.AUTOID <> " & v_autoid
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count = 1 Then
                    If v_ds.Tables(0).Rows(0)(0) > 0 Then
                        Return ERR_SA_ACCTNO_DUPLICATED
                    End If
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

  

End Class
