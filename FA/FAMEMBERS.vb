Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Public Class FAMEMBERS
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "FAMEMBERS"
    End Sub 

    Public Const ERRCODE_TAI_KHOAN_TON_TAI = -3
    Public Const ERRCODE_THANH_VIEN_TON_TAI_TREN_HE_THONG = -100308

    Overrides Function CheckBeforeAdd(ByVal v_strMessage As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK

        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_nodeList As Xml.XmlNodeList

        Dim v_ds As DataSet
        Dim v_obj As DataAccess
        Dim v_strSQL As String
        Dim v_strLocal, v_strSHORTNAME, v_strROLES As String
        Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE, v_strUsername, v_strEmail As String
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
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
                        Case "USERNAME"
                            v_strUsername = Trim(v_strVALUE)
                        Case "SHORTNAME"
                            v_strSHORTNAME = Trim(v_strVALUE)
                        Case "ROLES"
                            v_strROLES = Trim(v_strVALUE)
                    End Select
                End With
            Next

            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If
            If Not String.IsNullOrEmpty(v_strUsername) Then
                v_strSQL = "SELECT COUNT(USERNAME) FROM " & ATTR_TABLE & " WHERE USERNAME = '" & v_strUsername & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count = 1 Then
                    If v_ds.Tables(0).Rows(0)(0) > 0 Then
                        Return ERRCODE_TAI_KHOAN_TON_TAI
                    End If
                End If
            End If
            'thunt:-30/12/2019-thêm điều kiện vai trò cho phép 1 member có nhiều vai trò
            If Not String.IsNullOrEmpty(v_strSHORTNAME) Then
                v_strSQL = "SELECT COUNT(SHORTNAME) FROM " & ATTR_TABLE & " WHERE SHORTNAME = '" & v_strSHORTNAME & "' AND ROLES='" & v_strROLES & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count = 1 Then
                    If v_ds.Tables(0).Rows(0)(0) > 0 Then
                        Return ERRCODE_THANH_VIEN_TON_TAI_TREN_HE_THONG
                    End If
                End If
            End If

        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
        Return v_lngErrCode

    End Function

    Overrides Function CheckBeforeEdit(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strFLDNAME, v_strVALUE, v_BRKID, v_strSQL, v_AUTOID, v_strUsername As String
        Dim v_ds As DataSet
        Try
            Dim v_obj As DataAccess
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal As String
            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If
            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strVALUE = .InnerText.ToString()
                    Select Case Trim(v_strFLDNAME)
                        Case "AUTOID"
                            v_AUTOID = v_strVALUE
                        Case "USERNAME"
                            v_strUsername = Trim(v_strVALUE)
                    End Select
                End With
            Next
            If Not String.IsNullOrEmpty(v_strUsername) And Not String.IsNullOrEmpty(v_AUTOID) Then
                v_strSQL = "SELECT COUNT(USERNAME) FROM " & ATTR_TABLE & " WHERE USERNAME <> '" & v_strUsername & "' AND AUTOID = '" + v_AUTOID + "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count >= 1 Then
                    If v_ds.Tables(0).Rows(0)(0) > 0 Then
                        Return ERRCODE_TAI_KHOAN_TON_TAI
                    End If
                End If
            End If
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
        Return ERR_SYSTEM_OK
    End Function
End Class
