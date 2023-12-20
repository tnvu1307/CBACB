Imports HostCommonLibrary
Imports System.IO
Imports DataAccessLayer
Imports System.Data

Public Class SEC_DAT
    Inherits CoreBusiness.Maintain
    Public Sub New()
        ATTR_TABLE = "SEC_DAT"
    End Sub

    Overrides Function Adhoc(ByRef v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strFuncName As String

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            v_strFuncName = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeFUNCNAME), Xml.XmlAttribute).Value)

            Select Case Trim(v_strFuncName)
                Case "ImportSecDatToDB"
                    v_lngErrCode = ImportSec_DatToDB(pv_xmlDocument)
            End Select

            'ContextUtil.SetComplete()
            v_strMessage = pv_xmlDocument.InnerXml
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            Throw ex
        End Try
    End Function

    Private Function ImportSec_DatToDB(ByRef pv_xmlDocument As XmlDocumentEx) As Long
        Dim v_arrFldType() As String = {"Integer", "String", "String", "Long", "Long", "Double", "String", "String", "String", "String", "String", "String", "String", "String", "String", "String", "String", "Integer", "String", "String", "Long", "Integer", "String", "Long", "String", "Long", "Long", "Long", "Long", "Double", "Long", "Long", "Double", "Double", "Integer", "Integer", "Long", "Double", "Integer", "Long", "Double", "Long", "Long", "Long", "Long", "Long", "Long", "Long", "Long", "Long", "Long", "Long", "Long", "Integer"}
        Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
        Dim v_strClause As String
        Dim v_strLocal As String
        Dim v_strAutoId As String

        If Not (v_attrColl.GetNamedItem(gc_AtributeCLAUSE) Is Nothing) Then
            v_strClause = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
        Else
            v_strClause = String.Empty
        End If

        If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
            v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
        Else
            v_strLocal = String.Empty
        End If
        v_strClause = v_strClause.Replace("#(", "<")
        v_strClause = v_strClause.Replace(")#", ">")

        Dim v_obj As DataAccess
        If v_strLocal = "Y" Then
            v_obj = New DataAccess
        ElseIf v_strLocal = "N" Then
            v_obj = New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
        End If

        Dim v_strCmdInsertSQL As String
        Dim v_XmlDocument As New XmlDocumentEx 'DataSet
        Dim v_nodeList As Xml.XmlNodeList 'Table
        Dim entryNode As Xml.XmlNode 'Fld
        v_XmlDocument.LoadXml(v_strClause)
        v_nodeList = v_XmlDocument.SelectNodes("/NewDataSet/NewDataTable")
        Dim v_strFldVal As String
        Dim v_strFldType As String
        Try
            Dim v_intRowCnt As Integer = 0
            For Each entryNode In v_nodeList
                Dim v_intFldCnt As Integer = 0
                v_strCmdInsertSQL = "INSERT INTO " & ATTR_TABLE & " VALUES ("
                For Each subNode As Xml.XmlNode In entryNode.ChildNodes
                    v_strFldVal = subNode.InnerText
                    v_strFldType = v_arrFldType(v_intFldCnt)
                    Select Case v_strFldType
                        Case "String"
                            If Not v_strFldVal.Equals("") Then
                                v_strCmdInsertSQL &= "'" & v_strFldVal & "',"
                            Else
                                v_strCmdInsertSQL &= "'',"
                            End If

                        Case "Double", "Integer", "Long"
                            If v_strFldVal <> "" Then
                                v_strCmdInsertSQL &= "" & v_strFldVal & ","
                            Else
                                v_strCmdInsertSQL &= "'',"
                            End If
                        Case "Date"
                            If v_strFldVal <> "" Then
                                v_strCmdInsertSQL &= "TO_DATE('" & v_strFldVal & "','dd/mm/yyyy')" & ","
                            Else
                                v_strCmdInsertSQL &= "'',"
                            End If
                    End Select
                    v_intFldCnt += 1
                Next
                v_strCmdInsertSQL = v_strCmdInsertSQL.Substring(0, v_strCmdInsertSQL.Length - 1)
                v_strCmdInsertSQL &= ")"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdInsertSQL)
                v_intRowCnt += 1
            Next
            'ContextUtil.SetComplete()
        Catch ex As Exception
            'ContextUtil.SetAbort()
            Throw ex
        End Try
    End Function

    Private Function ImportToSec_Info(ByRef pv_xmlDocument As XmlDocumentEx) As Long
        Dim v_arrFldType() As String = {"Integer", "String", "String", "Long", "Long", "Double", "String", "String", "String", "String", "String", "String", "String", "String", "String", "String", "String", "Integer", "String", "String", "Long", "Integer", "String", "Long", "String", "Long", "Long", "Long", "Long", "Double", "Long", "Long", "Double", "Double", "Integer", "Integer", "Long", "Double", "Integer", "Long", "Double", "Long", "Long", "Long", "Long", "Long", "Long", "Long", "Long", "Long", "Long", "Long", "Long", "Integer"}
        Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
        Dim v_strClause As String
        Dim v_strLocal As String
        Dim v_strAutoId As String

        If Not (v_attrColl.GetNamedItem(gc_AtributeCLAUSE) Is Nothing) Then
            v_strClause = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
        Else
            v_strClause = String.Empty
        End If

        If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
            v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
        Else
            v_strLocal = String.Empty
        End If
        v_strClause = v_strClause.Replace("#(", "<")
        v_strClause = v_strClause.Replace(")#", ">")

        Dim v_obj As DataAccess
        If v_strLocal = "Y" Then
            v_obj = New DataAccess
        ElseIf v_strLocal = "N" Then
            v_obj = New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
        End If

        Dim v_strCmdInsertSQL As String
        Dim v_XmlDocument As New XmlDocumentEx 'DataSet
        Dim v_nodeList As Xml.XmlNodeList 'Table
        Dim entryNode As Xml.XmlNode 'Fld
        v_XmlDocument.LoadXml(v_strClause)
        v_nodeList = v_XmlDocument.SelectNodes("/NewDataSet/NewDataTable")
        Dim v_strFldVal As String
        Dim v_strFldType As String

        For i As Integer = 0 To v_nodeList.Count - 1 'tung dong
            For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                With v_nodeList.Item(i).ChildNodes(j)
                    Dim v_colName As String = .Name = ""
                    Select Case v_colName
                        Case "Stockno"
                        Case ""
                        Case ""
                    End Select
                End With
                'tung cot 
            Next
        Next
        Try
            Dim v_intRowCnt As Integer = 0
            For Each entryNode In v_nodeList
                Dim v_intFldCnt As Integer = 0

                v_strCmdInsertSQL = "INSERT INTO " & ATTR_TABLE & " VALUES ("
                For Each subNode As Xml.XmlNode In entryNode.ChildNodes
                    v_strFldVal = subNode.InnerText
                    v_strFldType = v_arrFldType(v_intFldCnt)
                    Select Case v_strFldType
                        Case "String"
                            If Not v_strFldVal.Equals("") Then
                                v_strCmdInsertSQL &= "'" & v_strFldVal & "',"
                            Else
                                v_strCmdInsertSQL &= "'',"
                            End If

                        Case "Double", "Integer", "Long"
                            If v_strFldVal <> "" Then
                                v_strCmdInsertSQL &= "" & v_strFldVal & ","
                            Else
                                v_strCmdInsertSQL &= "'',"
                            End If
                        Case "Date"
                            If v_strFldVal <> "" Then
                                v_strCmdInsertSQL &= "TO_DATE('" & v_strFldVal & "','dd/mm/yyyy')" & ","
                            Else
                                v_strCmdInsertSQL &= "'',"
                            End If
                    End Select
                    v_intFldCnt += 1
                Next
                v_strCmdInsertSQL = v_strCmdInsertSQL.Substring(0, v_strCmdInsertSQL.Length - 1)
                v_strCmdInsertSQL &= ")"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdInsertSQL)
                v_intRowCnt += 1
            Next
            'ContextUtil.SetComplete()
        Catch ex As Exception
            'ContextUtil.SetAbort()
            Throw ex
        End Try
    End Function

    Private Function ImportToSec_Info_Details(ByRef pv_xmlDocument As XmlDocumentEx) As Long

    End Function
End Class