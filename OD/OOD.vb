Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Public Class OOD
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "OOD"
    End Sub

    Overrides Function Adhoc(ByRef v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
        Dim v_strSQL, v_strClause, v_strLocal, v_strFuncName, v_strAutoId, v_strTellerID, v_strOrderID As String
        Dim v_intCount As Integer = 0
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK


        If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
            v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
        Else
            v_strLocal = String.Empty
        End If
        If Not (v_attrColl.GetNamedItem(gc_AtributeCMDINQUIRY) Is Nothing) Then
            v_strClause = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCMDINQUIRY), Xml.XmlAttribute).Value)
        Else
            v_strClause = String.Empty
        End If
        If Not (v_attrColl.GetNamedItem(gc_AtributeFUNCNAME) Is Nothing) Then
            v_strFuncName = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeFUNCNAME), Xml.XmlAttribute).Value)
        Else
            v_strFuncName = String.Empty
        End If
        If Not (v_attrColl.GetNamedItem(gc_AtributeTLID) Is Nothing) Then
            v_strTellerID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
        Else
            v_strTellerID = String.Empty
        End If
        v_strOrderID = v_strClause.Trim

        Dim v_obj As DataAccess
        If v_strLocal = "Y" Then
            v_obj = New DataAccess
        ElseIf v_strLocal = "N" Then
            v_obj = New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
        End If


        Try
            'Sửa vì lý do an ninh không được phép gửi lệnh ghi dữ liệu từ Client
            Select Case Trim(v_strFuncName)
                Case "OnLock"
                    If v_strOrderID.Length > 0 Then
                        v_strSQL = "UPDATE OOD SET OODSTATUS = 'B', TLIDSENT='" & v_strTellerID & "' WHERE ORGORDERID = '" & v_strOrderID & "'"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    End If
                Case "OnUnLock"
                    If v_strOrderID.Length > 0 Then
                        v_strSQL = "UPDATE OOD SET OODSTATUS = 'N', TLIDSENT='' WHERE ORGORDERID = '" & v_strOrderID & "'"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    End If
                Case "OnInsertODQUEUE"
                    If v_strOrderID.Length > 0 Then
                        v_strSQL = "INSERT INTO ODQUEUE SELECT * FROM OOD WHERE TRIM(ORGORDERID) = '" & v_strOrderID & "'"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    End If
                Case "OnDeleteODQUEUE"
                    If v_strOrderID.Length > 0 Then
                        v_strSQL = "DELETE FROM ODQUEUE WHERE TRIM(ORGORDERID) = '" & v_strOrderID & "'"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    End If
            End Select

        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
End Class
