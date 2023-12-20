Imports HostCommonLibrary
Imports System.IO
Imports DataAccessLayer
Imports System.Text
Imports System.Xml
Imports System.Data
Public Class CRBFILEEXPORT
    Inherits CoreBusiness.Maintain

    Public Sub New()
        ATTR_TABLE = "CRBFILEEXPORT"
    End Sub
#Region "Override functions"

    Overrides Function SystemProcessBeforeEdit(ByRef v_strMessage As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_strObjMsg, v_strSQL As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strFILEID, v_strBANKCODE, v_strSTATUS As String
            Dim v_strFLDNAME, v_strVALUE As String

            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If

            v_strFILEID = String.Empty

            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strVALUE = .InnerText.ToString()
                    Select Case Trim(v_strFLDNAME)
                        Case "FILEID"
                            v_strFILEID = Trim(v_strVALUE)
                        Case "BANKCODE"
                            v_strBANKCODE = Trim(v_strVALUE)
                        Case "STATUS"
                            v_strSTATUS = Trim(v_strVALUE)
                    End Select
                End With
            Next
            Dim v_obj As DataAccess
            Dim v_strFeedBackMsg As String
            v_obj = New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_arrPara(4) As StoreParameter
            Dim v_objParam As New StoreParameter
            v_objParam.ParamName = "p_FileID"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamValue = v_strFILEID
            v_objParam.ParamSize = 100
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(0) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_BankCode"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamValue = v_strBANKCODE
            v_objParam.ParamSize = 100
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(1) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_Status"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamValue = v_strSTATUS
            v_objParam.ParamSize = 100
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(2) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_err_code"
            v_objParam.ParamDirection = ParameterDirection.Output
            v_objParam.ParamValue = ""
            v_objParam.ParamSize = 100
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(3) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_msg_err"
            v_objParam.ParamDirection = ParameterDirection.Output
            v_objParam.ParamValue = ""
            v_objParam.ParamSize = 100
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(4) = v_objParam

            v_lngErrCode = v_obj.ExecuteOracleStored("cspks_rmproc.pr_UpdateInfoResult", v_arrPara, 3)

            If Not IsNumeric(v_arrPara(3).ParamValue) Then
                v_lngErrCode = 0
            Else
                v_lngErrCode = CDec(v_arrPara(3).ParamValue)
            End If

            v_strFeedBackMsg = CStr(v_arrPara(4).ParamValue)
            pv_xmlDocument.DocumentElement.Attributes.GetNamedItem(gc_AtributeRESERVER).Value = v_strFeedBackMsg

            Return v_lngErrCode

        Catch ex As Exception
            Throw ex
        End Try
        Return ERR_SYSTEM_OK
    End Function

#End Region
End Class
