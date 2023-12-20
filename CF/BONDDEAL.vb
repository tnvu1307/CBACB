Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data

Public Class BONDDEAL
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "BONDDEAL"
    End Sub

    Public Overrides Function CheckBeforeAdd(ByVal v_strMessage As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = ATTR_TABLE & ".CheckBeforeAdd"
        Dim pv_xmlDoccument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDoccument.DocumentElement.Attributes
            Dim v_strLocal As String
            Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String
            Dim v_strSQL As String
            'Khai báo các trường check ngày nghỉ, lễ
            Dim v_strTRANSDATE, v_strTXDATE, v_strPTXDATE, v_strCURRDATE, v_strHOLIDAY As String

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
                        'Ngày GD sơ cấp
                        Case "TRANSDATE"
                            v_strTRANSDATE = Trim(v_strVALUE)

                            'Ngày GD-bên bán
                        Case "TXDATE"
                            v_strTXDATE = Trim(v_strVALUE)

                            'Ngày GD-bên mua
                        Case "PTXDATE"
                            v_strPTXDATE = Trim(v_strVALUE)
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


            v_strSQL = "SELECT HOLIDAY FROM SBCLDR WHERE SBDATE = TO_DATE('" & v_strTRANSDATE & "', '" & gc_FORMAT_DATE & "') AND CLDRTYPE = '000'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_strHOLIDAY = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("HOLIDAY")))
                If v_strHOLIDAY = "Y" Then
                    Return ERR_GL_BKDATE_IN_HOLIDAY
                End If
            End If

            v_strSQL = "SELECT HOLIDAY FROM SBCLDR WHERE SBDATE = TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') AND CLDRTYPE = '000'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_strHOLIDAY = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("HOLIDAY")))
                If v_strHOLIDAY = "Y" Then
                    Return ERR_GL_BKDATE_IN_HOLIDAY
                End If
            End If

            v_strSQL = "SELECT HOLIDAY FROM SBCLDR WHERE SBDATE = TO_DATE('" & v_strPTXDATE & "', '" & gc_FORMAT_DATE & "') AND CLDRTYPE = '000'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_strHOLIDAY = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("HOLIDAY")))
                If v_strHOLIDAY = "Y" Then
                    Return ERR_GL_BKDATE_IN_HOLIDAY
                End If
            End If

            Return ERR_SYSTEM_OK

        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Overrides Function CheckBeforeEdit(ByVal v_strMessage As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = ATTR_TABLE & ".CheckBeforeEdit"
        Dim pv_xmlDoccument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDoccument.DocumentElement.Attributes
            Dim v_strLocal As String
            Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String
            Dim v_strSQL As String
            'Khai báo các trường check ngày nghỉ, lễ
            Dim v_strTRANSDATE, v_strTXDATE, v_strPTXDATE, v_strCURRDATE, v_strHOLIDAY As String

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
                        'Ngày GD sơ cấp
                        Case "TRANSDATE"
                            v_strTRANSDATE = Trim(v_strVALUE)

                            'Ngày GD-bên bán
                        Case "TXDATE"
                            v_strTXDATE = Trim(v_strVALUE)

                            'Ngày GD-bên mua
                        Case "PTXDATE"
                            v_strPTXDATE = Trim(v_strVALUE)
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


            v_strSQL = "SELECT HOLIDAY FROM SBCLDR WHERE SBDATE = TO_DATE('" & v_strTRANSDATE & "', '" & gc_FORMAT_DATE & "') AND CLDRTYPE = '000'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_strHOLIDAY = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("HOLIDAY")))
                If v_strHOLIDAY = "Y" Then
                    Return ERR_GL_BKDATE_IN_HOLIDAY
                End If
            End If

            v_strSQL = "SELECT HOLIDAY FROM SBCLDR WHERE SBDATE = TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') AND CLDRTYPE = '000'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_strHOLIDAY = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("HOLIDAY")))
                If v_strHOLIDAY = "Y" Then
                    Return ERR_GL_BKDATE_IN_HOLIDAY
                End If
            End If

            v_strSQL = "SELECT HOLIDAY FROM SBCLDR WHERE SBDATE = TO_DATE('" & v_strPTXDATE & "', '" & gc_FORMAT_DATE & "') AND CLDRTYPE = '000'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_strHOLIDAY = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("HOLIDAY")))
                If v_strHOLIDAY = "Y" Then
                    Return ERR_GL_BKDATE_IN_HOLIDAY
                End If
            End If

            Return ERR_SYSTEM_OK

        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

End Class