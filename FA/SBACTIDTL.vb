Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Xml
Imports System.Data
Public Class SBACTIDTL
    Inherits CoreBusiness.Maintain
    Public Sub New()
        ATTR_TABLE = "SBACTIDTL"
    End Sub

    'Key SBACTIDTL Value SBACTIMST in fldmaster
    Private Shared _dicMapper As Dictionary(Of String, String)
    Public Property dicMapper As Dictionary(Of String, String)
        Get
            _dicMapper = New Dictionary(Of String, String)
            _dicMapper("ASSIGNID") = "ASSIGNID"
            _dicMapper("REFACTICODE") = "SBSTATUS"
            _dicMapper("RESOLVEDT") = "RESOLVEDT"
            Return _dicMapper
        End Get
        Set(value As Dictionary(Of String, String))

        End Set
    End Property


    Public Overrides Function Add(ByRef v_strMessage As String) As Long
        Dim result = MyBase.Add(v_strMessage)
        If (result = 0) Then
            Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_obj As DataAccess
            Dim v_strLocal As String
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes

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

            Dim refId As String = Nothing
            Dim actionType As String = Nothing
            Dim dicCon As Dictionary(Of String, String) = New Dictionary(Of String, String)
            Dim sqlQuery = "UPDATE SBACTIMST SET {0} WHERE AUTOID = '{1}'"
            If v_nodeList IsNot Nothing And v_nodeList.Count = 1 Then
                Dim xmlNodeList As XmlNodeList = v_nodeList(0).ChildNodes
                If (xmlNodeList IsNot Nothing And xmlNodeList.Count > 0) Then
                    For Each node As XmlNode In xmlNodeList
                        If node.FirstChild IsNot Nothing Then
                            If (node.Attributes("fldname").Value = "REFID") Then 'flsmaster SBACTIDTL
                                refId = node.FirstChild.Value
                            ElseIf dicMapper.ContainsKey(node.Attributes("fldname").Value) Then
                                dicCon(dicMapper(node.Attributes("fldname").Value)) = node.FirstChild.Value
                            ElseIf node.Attributes("fldname").Value = "ACTIDTLTYP" Then
                                actionType = node.FirstChild.Value
                            End If
                        End If
                    Next
                End If
            End If
            If dicCon IsNot Nothing And dicCon.Count > 0 And Not String.IsNullOrEmpty(refId) And Not String.IsNullOrEmpty(actionType) Then
                Dim conStr As String = ""
                For Each con In dicCon
                    If con.Key = "ASSIGNID" And actionType = "A" Then
                        conStr += con.Key & " = '" & con.Value + "',"
                    End If

                    If con.Key = "SBSTATUS" And actionType = "M" Then
                        conStr += con.Key & " = '" & con.Value + "',"
                    End If

                    If con.Key = "RESOLVEDT" And actionType = "M" And con.Value <> gc_NULL_DATE Then
                        conStr += con.Key & " = TO_DATE('" & con.Value + "', '" & gc_FORMAT_DATE_DB & "'),"
                    End If

                Next
                If (Not String.IsNullOrEmpty(conStr)) Then
                    conStr = conStr.Substring(0, conStr.Length - 1)
                    sqlQuery = String.Format(sqlQuery, conStr, refId)
                    v_obj.ExecuteNonQuery(CommandType.Text, sqlQuery)
                End If
                
            End If

        End If
        Return result

    End Function
End Class
