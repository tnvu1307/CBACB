Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Public Class REREVIEWTERM
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "REREVIEWTERM"
    End Sub
#Region " Overrides functions "

#End Region
    Overrides Function CheckBeforeAdd(ByVal v_strMessage As String) As Long
        Dim v_strErrorSource, v_strErrorMessage As String
        v_strErrorSource = Me.ATTR_TABLE + ".CheckBeforeAdd"
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_ds As New DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strAUTOID, v_strREFAUTOID As String, v_dblEXTRATE, v_dblEXTVAL, v_dblFRVALUE, v_dblTOVALUE As Double
            Dim v_strSQL, v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String
            Dim v_dtFrdate, v_dtTodate, v_dtCurDate As Date

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
                        Case "AUTOID"
                            v_strAUTOID = v_strVALUE.Trim
                        Case "FRDATE"
                            v_dtFrdate = DDMMYYYY_SystemDate(v_strVALUE)
                        Case "TODATE"
                            v_dtTodate = DDMMYYYY_SystemDate(v_strVALUE)
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

            v_strSQL = "SELECT getcurrdate Crdate from dual"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            v_dtCurDate = v_ds.Tables(0).Rows(0)("CRDATE")
            If v_dtFrdate > v_dtTodate Then
                Return ERR_SA_REREVIEWTERM_CHECK_DATE
            End If

            If v_dtCurDate > v_dtFrdate Then
                Return ERR_SA_REREVIEWTERM_CHECK_DATE
            End If

            Return ERR_SYSTEM_OK
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        Finally
            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If
        End Try
    End Function

    Overrides Function CheckBeforeEdit(ByVal v_strMessage As String) As Long
        Dim v_strErrorSource, v_strErrorMessage As String
        v_strErrorSource = Me.ATTR_TABLE + ".CheckBeforeEdit"
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_ds As New DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strAUTOID, v_strREFAUTOID As String, v_dblEXTRATE, v_dblEXTVAL, v_dblFRVALUE, v_dblTOVALUE As Double
            Dim v_strSQL, v_strFLDNAME, v_strFLDTYPE, v_strVALUE, v_strCLAUSE As String
            Dim v_dtOldFrdate, v_dtOldTodate, v_dtNewFrdate, v_dtNewTodate, v_dtCurDate As Date
            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If
            If Not (v_attrColl.GetNamedItem(gc_AtributeCLAUSE) Is Nothing) Then
                v_strCLAUSE = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Else
                v_strCLAUSE = String.Empty
            End If

            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strVALUE = .InnerText.ToString()
                    Select Case Trim(v_strFLDNAME)
                        Case "AUTOID"
                            v_strAUTOID = v_strVALUE.Trim
                        Case "FRDATE"
                            v_dtNewFrdate = DDMMYYYY_SystemDate(v_strVALUE)
                        Case "TODATE"
                            v_dtNewTodate = DDMMYYYY_SystemDate(v_strVALUE)
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

            v_strSQL = "SELECT getcurrdate Crdate from dual"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            v_dtCurDate = v_ds.Tables(0).Rows(0)("CRDATE")

            v_strSQL = "SELECT *  from REREVIEWTERM where " & v_strCLAUSE
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            v_dtOldFrdate = v_ds.Tables(0).Rows(0)("FRDATE")
            v_dtOldTodate = v_ds.Tables(0).Rows(0)("TODATE")

            If v_dtCurDate > v_dtOldFrdate And v_dtOldFrdate <> v_dtNewFrdate Then
                Return ERR_SA_REREVIEWTERM_CHECK_FRDATE
            End If

            If v_dtCurDate > v_dtOldTodate And v_dtOldTodate <> v_dtNewTodate Then
                Return ERR_SA_REREVIEWTERM_CHECK_TODATE
            End If

            Return ERR_SYSTEM_OK
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        Finally
            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If
        End Try
    End Function
    Public Overrides Function CheckBeforeDelete(ByVal v_strMessage As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "SA.REREVIEWTERM.CheckBeforeDelete", v_strErrorMessage As String

        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_ds As New DataSet
        Dim v_nodeList As Xml.XmlNodeList

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strSQL, v_strCLAUSE, v_strLocal As String
            Dim v_dtOldFrdate, v_dtCurDate As Date
            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If
            If Not (v_attrColl.GetNamedItem(gc_AtributeCLAUSE) Is Nothing) Then
                v_strCLAUSE = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Else
                v_strCLAUSE = String.Empty
            End If

            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")


            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            v_strSQL = "SELECT getcurrdate Crdate from dual"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            v_dtCurDate = v_ds.Tables(0).Rows(0)("CRDATE")

            v_strSQL = "SELECT *  from REREVIEWTERM where " & v_strCLAUSE
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            v_dtOldFrdate = v_ds.Tables(0).Rows(0)("FRDATE")

            If v_dtCurDate > v_dtOldFrdate Then
                Return ERR_SA_REREVIEWTERM_CANT_DELETE
            End If




            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
End Class
