Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Public Class BRKFEEGRP
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "BRKFEEGRP"
    End Sub

#Region " Overrides functions "
    Overrides Function CheckBeforeAdd(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList

        Try
            'ContextUtil.SetComplete()
            Return 0
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
    Public Overrides Function CheckBeforeDelete(ByVal v_strMessage As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "SA.BRKFEEGRP.CheckBeforeDelete", v_strErrorMessage As String

        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_strSQL As String = String.Empty
        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strACCTNO, v_strCUSTODYCD, v_strCUSTID, v_strCLAUSE As String
            Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String

            Dim v_strBRID, v_strTXDATE As String
            v_strBRID = CStr(CType(v_attrColl.GetNamedItem("BRID"), Xml.XmlAttribute).Value)

            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeTXDATE) Is Nothing) Then
                v_strTXDATE = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXDATE), Xml.XmlAttribute).Value)
            Else
                v_strTXDATE = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeCLAUSE) Is Nothing) Then
                v_strCLAUSE = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Else
                v_strCLAUSE = String.Empty
            End If


            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            'Kiem tra xem con tieu khoan su dung loai hinh khong
            v_strSQL = "SELECT count (1) a from AFBRKFEEGRP where REF" & v_strCLAUSE
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

            If v_ds.Tables(0).Rows(0)(0) >= 1 Then
                Return ERR_SA_STILL_HAS_AF
            End If
            Return v_lngErrCode

        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Overrides Function SystemProcessBeforeDelete(ByRef v_strMessage As String) As Long
        Dim v_strSQL As String = String.Empty
        Dim v_strCLAUSE, v_strLocal As String
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
        Dim v_strErrorSource As String = "SA.BRKFEEGRP.SystemProcessBeforeDelete", v_strErrorMessage As String
        Try
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

            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If
            v_strSQL = "INSERT INTO BRKFEEGRPLOG select * from BRKFEEGRP where " & v_strCLAUSE
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            Complete()
            Return 0
        Catch ex As Exception
            LogError.WriteException(ex)
        End Try
    End Function
#End Region

End Class