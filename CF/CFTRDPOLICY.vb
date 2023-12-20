Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data

Public Class CFTRDPOLICY
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "CFTRDPOLICY"
    End Sub

    Public Overrides Function CheckBeforeAdd(ByVal v_strMessage As String) As Long
        Dim v_lngErrorCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = ATTR_TABLE & ".CheckBeforeAdd"
        Dim pv_xmlDoccument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_strLEVELCD As String
        Dim v_strObjMsg As String
        Dim v_ds, v_grpuser, v_security As DataSet

        Dim v_nodeList As Xml.XmlNodeList

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDoccument.DocumentElement.Attributes
            Dim v_strLocal As String
            Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String
            Dim v_strSQL As String
            Dim v_strGRPUSER, v_strGRPUSERTYPE, v_strSECURITY, v_strSECTYPE As String
            'Khai bao cac truong trung khoang thoi gian hieu luc
            Dim v_strREFID, v_strTRADERID, v_strFRDATE, v_strTODATE, v_strCURRDATE As String
            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If

            v_nodeList = pv_xmlDoccument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strVALUE = .InnerText.ToString()
                    Select Case Trim(v_strFLDNAME)
                        'LEVELCD
                        Case "LEVELCD"
                            v_strLEVELCD = Trim(v_strVALUE)
                            'REFID
                        Case "REFID"
                            v_strREFID = Trim(v_strVALUE)
                            'TRADERID
                        Case "TRADERID"
                            v_strTRADERID = Trim(v_strVALUE)
                            'Tu ngay
                        Case "FRDATE"
                            v_strFRDATE = Trim(v_strVALUE)
                            'Den ngay
                        Case "TODATE"
                            v_strTODATE = Trim(v_strVALUE)

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

            v_lngErrorCode = v_obj.GetSysVar("SYSTEM", "CURRDATE", v_strCURRDATE)

            v_strSQL = "SELECT LEVELCD FROM CFTRDPOLICY WHERE LEVELCD = '" & v_strLEVELCD & "' AND TO_DATE('" & v_strFRDATE & "','DD/MM/RRRR') <= TO_DATE(TODATE,'DD/MM/RRRR')"

            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_strLEVELCD = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("LEVELCD")))
                If v_strLEVELCD = "S" Then      'Tang He thong khong co REFID
                    Return ERR_SA_DUPLICATE_TIME_VALIDITY

                ElseIf v_strLEVELCD = "G" Or v_strLEVELCD = "U" Then    'Truong hop chon Tang Nhom dau tu hoac Can bo dau tu  -> Co them REFID
                    v_strGRPUSER = "SELECT LEVELCD FROM CFTRDPOLICY WHERE LEVELCD = '" & v_strLEVELCD & "' AND REFID = '" & v_strREFID & "' AND TO_DATE('" & v_strFRDATE & "','DD/MM/RRRR') <= TO_DATE(TODATE,'DD/MM/RRRR')"
                    v_grpuser = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strGRPUSER)
                    If v_grpuser.Tables(0).Rows.Count > 0 Then
                        v_strGRPUSERTYPE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("LEVELCD")))
                        If v_strGRPUSERTYPE = "G" Or v_strGRPUSERTYPE = "U" Then
                            Return ERR_SA_DUPLICATE_TIME_VALIDITY
                        End If
                    End If

                ElseIf v_strLEVELCD = "I" Then      'Truong hop chon Tang Ma chung khoan  -> Co them TRADERID
                    v_strSECURITY = "SELECT LEVELCD FROM CFTRDPOLICY WHERE LEVELCD = '" & v_strLEVELCD & "' AND REFID = '" & v_strREFID & "' AND TRADERID = '" & v_strTRADERID & "' AND TO_DATE('" & v_strFRDATE & "','DD/MM/RRRR') <= TO_DATE(TODATE,'DD/MM/RRRR')"
                    v_security = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSECURITY)
                    If v_security.Tables(0).Rows.Count > 0 Then
                        v_strSECTYPE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("LEVELCD")))
                        If v_strSECTYPE = "I" Then
                            Return ERR_SA_DUPLICATE_TIME_VALIDITY
                        End If
                    End If
                End If
            End If

            Return ERR_SYSTEM_OK
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Overrides Function CheckBeforeEdit(ByVal v_strMessage As String) As Long
        Dim v_lngErrorCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = ATTR_TABLE & ".CheckBeforeEdit"
        Dim pv_xmlDoccument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_strLEVELCD As String
        Dim v_strObjMsg As String
        Dim v_ds, v_grpuser, v_security As DataSet
        Dim v_nodeList As Xml.XmlNodeList

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDoccument.DocumentElement.Attributes
            Dim v_strLocal As String
            Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String
            Dim v_strSQL As String
            Dim v_strGRPUSER, v_strGRPUSERTYPE, v_strSECURITY, v_strSECTYPE As String
            'Khai bao cac truong trung khoang thoi gian hieu luc
            Dim v_strAUTOID, v_strREFID, v_strTRADERID, v_strFRDATE, v_strTODATE, v_strCURRDATE As String
            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If

            v_nodeList = pv_xmlDoccument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strVALUE = .InnerText.ToString()
                    Select Case Trim(v_strFLDNAME)
                        'LEVELCD
                        Case "LEVELCD"
                            v_strLEVELCD = Trim(v_strVALUE)
                            'AUTOID
                        Case "AUTOID"
                            v_strAUTOID = Trim(v_strVALUE)      'Lay them truong AUTOID de khong so sanh ban ghi dang Edit voi chinh no
                            'REFID
                        Case "REFID"
                            v_strREFID = Trim(v_strVALUE)
                            'TRADERID
                        Case "TRADERID"
                            v_strTRADERID = Trim(v_strVALUE)
                            'Tu ngay
                        Case "FRDATE"
                            v_strFRDATE = Trim(v_strVALUE)
                            'Den ngay
                        Case "TODATE"
                            v_strTODATE = Trim(v_strVALUE)

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

            v_lngErrorCode = v_obj.GetSysVar("SYSTEM", "CURRDATE", v_strCURRDATE)

            v_strSQL = "SELECT LEVELCD FROM CFTRDPOLICY WHERE LEVELCD = '" & v_strLEVELCD & "' AND AUTOID <> '" & v_strAUTOID & "' AND TO_DATE('" & v_strFRDATE & "','DD/MM/RRRR') <= TO_DATE(TODATE,'DD/MM/RRRR')"

            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_strLEVELCD = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("LEVELCD")))

                If v_strLEVELCD = "S" Then      'Tang He thong khong co REFID
                    Return ERR_SA_DUPLICATE_TIME_VALIDITY

                ElseIf v_strLEVELCD = "G" Or v_strLEVELCD = "U" Then    'Truong hop chon Tang Nhom dau tu hoac Can bo dau tu -> Co them REFID
                    v_strGRPUSER = "SELECT LEVELCD FROM CFTRDPOLICY WHERE LEVELCD = '" & v_strLEVELCD & "' AND AUTOID <> '" & v_strAUTOID & "' AND REFID = '" & v_strREFID & "' AND TO_DATE('" & v_strFRDATE & "','DD/MM/RRRR') <= TO_DATE(TODATE,'DD/MM/RRRR')"
                    v_grpuser = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strGRPUSER)
                    If v_grpuser.Tables(0).Rows.Count > 0 Then
                        v_strGRPUSERTYPE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("LEVELCD")))
                        If v_strGRPUSERTYPE = "G" Or v_strGRPUSERTYPE = "U" Then
                            Return ERR_SA_DUPLICATE_TIME_VALIDITY
                        End If
                    End If

                ElseIf v_strLEVELCD = "I" Then      'Truong hop chon Tang Ma chung khoan  -> Co them TRADERID
                    v_strSECURITY = "SELECT LEVELCD FROM CFTRDPOLICY WHERE LEVELCD = '" & v_strLEVELCD & "' AND AUTOID <> '" & v_strAUTOID & "' AND REFID = '" & v_strREFID & "' AND TRADERID = '" & v_strTRADERID & "' AND TO_DATE('" & v_strFRDATE & "','DD/MM/RRRR') <= TO_DATE(TODATE,'DD/MM/RRRR')"
                    v_security = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSECURITY)

                    If v_security.Tables(0).Rows.Count > 0 Then
                        v_strSECTYPE = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("LEVELCD")))
                        If v_strSECTYPE = "I" Then
                            Return ERR_SA_DUPLICATE_TIME_VALIDITY
                        End If
                    End If
                End If
            End If

            Return ERR_SYSTEM_OK
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
End Class
