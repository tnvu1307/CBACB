Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Public Class ADJUSTMENU
    Inherits CoreBusiness.Maintain
    Public Sub New()
        ATTR_TABLE = "ADJUSTMENU"
    End Sub

#Region " Overrides functions "
    Public Overrides Function Adhoc(ByRef v_strMessage As String) As Long

        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strFuncName As String

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            v_strFuncName = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeFUNCNAME), Xml.XmlAttribute).Value)

            Select Case Trim(v_strFuncName)
                Case "ADDDIR"
                    v_lngErrCode = AddDir(pv_xmlDocument)
                    If v_lngErrCode <> ERR_SYSTEM_OK Then
                        Return v_lngErrCode
                    End If

                Case "EDITDIR"
                    v_lngErrCode = EditDir(pv_xmlDocument)
                    If v_lngErrCode <> ERR_SYSTEM_OK Then
                        Return v_lngErrCode
                    End If

                Case "REMOVEDIR"
                    v_lngErrCode = RemoveDir(pv_xmlDocument)
                    If v_lngErrCode <> ERR_SYSTEM_OK Then
                        Return v_lngErrCode
                    End If

                Case "ADDITEM"
                    v_lngErrCode = AddItem(pv_xmlDocument)
                    If v_lngErrCode <> ERR_SYSTEM_OK Then
                        Return v_lngErrCode
                    End If

                Case "REMOVEITEM"
                    v_lngErrCode = RemoveItem(pv_xmlDocument)
                    If v_lngErrCode <> ERR_SYSTEM_OK Then
                        Return v_lngErrCode
                    End If
            End Select

            v_strMessage = pv_xmlDocument.InnerXml
            Return v_lngErrCode

        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

    Private Function AddDir(ByRef pv_xmlDocument As XmlDocumentEx) As Long
        Dim v_strSQL, v_strReference, v_strCMDID As String
        Dim v_arrDir() As String
        Dim v_obj As New DataAccess
        Dim v_ds As DataSet
        Dim v_strLEV As String
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            If Not (v_attrColl.GetNamedItem(gc_AtributeREFERENCE) Is Nothing) Then
                v_strReference = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)
            Else
                v_strReference = ""
            End If
            If v_strReference.Length > 0 Then
                v_obj.NewDBInstance(gc_MODULE_HOST)

                v_arrDir = v_strReference.Split("|")

                v_strSQL = "select lpad(nvl(max(rn),0) + 1,6,'0') CMDID from (select rownum rn from (select * from adjustmenu order by cmdid) where rownum = cmdid)"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                v_strCMDID = v_ds.Tables(0).Rows(0)("CMDID").ToString

                v_strSQL = "select nvl(max(lev),0) + 1 LEV from adjustmenu where cmdid = '" & v_arrDir(0).ToString & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                v_strLEV = v_ds.Tables(0).Rows(0)("LEV").ToString

                v_strSQL = "INSERT INTO adjustmenu (CMDID,PRID,LEV,LAST,MENUTYPE,MENUCODE,CMDNAME,EN_CMDNAME) " & ControlChars.CrLf _
                        & "VALUES('" & v_strCMDID & "','" & v_arrDir(0).ToString & "'," & v_strLEV & ",'N','P',null,'" & v_arrDir(1).ToString & "','" & v_arrDir(2).ToString & "')"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                CType(v_attrColl.GetNamedItem(gc_AtributeRESERVER), Xml.XmlAttribute).Value = v_strCMDID
            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Private Function AddItem(ByRef pv_xmlDocument As XmlDocumentEx) As Long
        Dim v_strSQL, v_strReference, v_strCMDID As String
        Dim v_arrDir() As String
        Dim v_obj As New DataAccess
        Dim v_ds As DataSet
        Dim v_strLEV As String
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            If Not (v_attrColl.GetNamedItem(gc_AtributeREFERENCE) Is Nothing) Then
                v_strReference = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)
            Else
                v_strReference = ""
            End If
            If v_strReference.Length > 0 Then
                v_obj.NewDBInstance(gc_MODULE_HOST)

                v_arrDir = v_strReference.Split("|")

                v_strSQL = "select lpad(nvl(max(rn),0) + 1,6,'0') CMDID from (select rownum rn from (select * from adjustmenu order by cmdid) where rownum = cmdid)"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                v_strCMDID = v_ds.Tables(0).Rows(0)("CMDID").ToString

                v_strSQL = "select nvl(max(lev),0) + 1 LEV from adjustmenu where cmdid = '" & v_arrDir(0).ToString & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                v_strLEV = v_ds.Tables(0).Rows(0)("LEV").ToString

                v_strSQL = "INSERT INTO adjustmenu (CMDID,PRID,LEV,LAST,MENUTYPE,MENUCODE,CMDNAME,EN_CMDNAME) " & ControlChars.CrLf _
                        & "VALUES('" & v_strCMDID & "','" & v_arrDir(0).ToString & "'," & v_strLEV & ",'Y','" & v_arrDir(1).ToString & "','" & v_arrDir(2).ToString & "',null,null)"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                CType(v_attrColl.GetNamedItem(gc_AtributeRESERVER), Xml.XmlAttribute).Value = v_strCMDID
            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function EditDir(ByRef pv_xmlDocument As XmlDocumentEx) As Long
        Dim v_strSQL, v_strReference, v_strCMDID As String
        Dim v_arrDir() As String

        Dim v_obj As New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            If Not (v_attrColl.GetNamedItem(gc_AtributeREFERENCE) Is Nothing) Then
                v_strReference = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)
            Else
                v_strReference = ""
            End If
            If v_strReference.Length > 0 Then
                v_arrDir = v_strReference.Split("|")

                v_strSQL = "UPDATE ADJUSTMENU SET cmdname = '" & v_arrDir(1).ToString & "' " & ControlChars.CrLf _
                        & "WHERE CMDID = '" & v_arrDir(0).ToString & "'"

                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function RemoveDir(ByRef pv_xmlDocument As XmlDocumentEx) As Long
        Dim v_strSQL, v_strReference, v_strCMDID As String
        Dim v_arrDir() As String
        Dim v_ds As DataSet

        Dim v_obj As New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            If Not (v_attrColl.GetNamedItem(gc_AtributeREFERENCE) Is Nothing) Then
                v_strReference = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)
            Else
                v_strReference = ""
            End If
            If v_strReference.Length > 0 Then
                v_arrDir = v_strReference.Split("|")
                deleteItem(v_arrDir(0).ToString)
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Private Function RemoveItem(ByRef pv_xmlDocument As XmlDocumentEx) As Long
        Dim v_strSQL, v_strReference, v_strCMDID As String
        Dim v_arrDir() As String
        Dim v_ds As DataSet

        Dim v_obj As New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            If Not (v_attrColl.GetNamedItem(gc_AtributeREFERENCE) Is Nothing) Then
                v_strReference = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)
            Else
                v_strReference = ""
            End If
            If v_strReference.Length > 0 Then
                v_arrDir = v_strReference.Split("|")
                deleteItem(v_arrDir(0).ToString)
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub deleteItem(ByVal item As String)
        Dim v_ds As DataSet
        Dim v_obj As New DataAccess
        Dim v_strSQL As String
        v_obj.NewDBInstance(gc_MODULE_HOST)
        Try
            v_strSQL = "select CMDID from adjustmenu where prid = '" & item & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            For i As Integer = 0 To v_ds.Tables(0).Rows.Count - 1
                deleteItem(v_ds.Tables(0).Rows(i)("CMDID").ToString)
            Next
            v_strSQL = "delete from adjustmenu where cmdid = '" & item & "'"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
        Catch ex As Exception

        End Try
    End Sub

End Class
