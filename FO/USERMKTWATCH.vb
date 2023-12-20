Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data

Public Class USERMKTWATCH
    Inherits CoreBusiness.Maintain
    Public Sub New()
        ATTR_TABLE = "USERMKTWATCH"
    End Sub

    Overrides Function Adhoc(ByRef v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strFuncName As String
        Dim v_strObjMsg As String

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            v_strFuncName = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeFUNCNAME), Xml.XmlAttribute).Value)

            v_strObjMsg = pv_xmlDocument.InnerXml
            Select Case Trim(v_strFuncName)
                Case "MaintainUserMarketWatch"
                    v_lngErrCode = MaintainUserMarketWatch(v_strObjMsg)
            End Select
            v_strMessage = v_strObjMsg
            Return v_lngErrCode

        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Private Function MaintainUserMarketWatch(ByRef pv_strObjMsg As String) As Long
        Dim v_obj As DataAccess, v_ds As DataSet, v_strSQL As String
        Dim v_strErrorSource As String = ATTR_TABLE & ".MaintainUserMarketWatch"
        Dim XMLDocument As New XmlDocumentEx, XMLOrder As New XmlDocumentEx
        Dim v_nodeData, v_nodeOldData As Xml.XmlNode
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Try
            XMLDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
            Dim v_strClause As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value) 'Noi dung lenh dat vao
            XMLOrder.LoadXml(v_strClause)

            Dim v_strUSERNAME, v_strSYMBOL, v_strACTION, v_strRETURN As String
            v_nodeData = XMLOrder.SelectSingleNode("RootTrade/objBODY/MarketWatch")
            For i As Integer = 0 To v_nodeData.ChildNodes.Count - 1
                Select Case v_nodeData.ChildNodes(i).Name
                    Case "ACTION"
                        v_strACTION = v_nodeData.ChildNodes(i).InnerXml
                    Case "USERNAME"
                        v_strUSERNAME = v_nodeData.ChildNodes(i).InnerXml
                    Case "SYMBOL"
                        v_strSYMBOL = v_nodeData.ChildNodes(i).InnerXml
                End Select
            Next

            v_obj = New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)

            If v_strACTION = "ADDSYMBOL" Then
                'Kiem tra co MarketWatch profile chua
                v_strSQL = "SELECT SYMBOLS FROM USERMKTWATCH WHERE UPPER(USERNAME)='" & v_strUSERNAME.Trim.ToUpper & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count = 0 Then
                    v_strRETURN = v_strSYMBOL
                    v_strSQL = "INSERT INTO USERMKTWATCH (AUTOID, USERNAME, MKTWATCH, SYMBOLS) " + ControlChars.CrLf _
                        + " VALUES (SEQ_USERMKTWATCH.NEXTVAL, '" + v_strUSERNAME.Trim + "', 'USER DEFINED', '" + v_strRETURN.ToUpper + "')"
                Else
                    v_strRETURN = v_ds.Tables(0).Rows(0)("SYMBOLS") + v_strSYMBOL
                    v_strSQL = "UPDATE USERMKTWATCH SET SYMBOLS='" + v_strRETURN.ToUpper + "' WHERE USERNAME='" + v_strUSERNAME.Trim + "'"
                End If
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                'Return data
                pv_strObjMsg = v_strRETURN
            ElseIf v_strACTION = "REMOVESYMBOL" Then
                v_strSQL = "UPDATE USERMKTWATCH SET SYMBOLS=REPLACE(SYMBOLS,'" + v_strSYMBOL + "|','') WHERE UPPER(USERNAME)='" + v_strUSERNAME.Trim.ToUpper + "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End If
            Return ERR_SYSTEM_OK
        Catch ex As Exception
            Throw ex
        Finally
            XMLOrder = Nothing
            XMLDocument = Nothing
        End Try

    End Function
End Class
