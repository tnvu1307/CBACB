Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Public Class AFGRPLNK
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "AFGRPLNK"
    End Sub
    Overrides Function CheckBeforeAdd(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strGROUPID, v_strSTATUS, v_strMNGGROUP As String
            Dim v_strFLDNAME, v_strVALUE As String
            Dim v_strSQL As String
            Dim v_strBRID, v_strTXDATE, v_strTLID As String
            Dim v_strACCMEMBER, _
            v_strCOREBANK As String



            v_strBRID = CStr(CType(v_attrColl.GetNamedItem("BRID"), Xml.XmlAttribute).Value)

            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strTLID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Else
                v_strTLID = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeTXDATE) Is Nothing) Then
                v_strTXDATE = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXDATE), Xml.XmlAttribute).Value)
            Else
                v_strTXDATE = String.Empty
            End If

            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strVALUE = .InnerText.ToString()

                    Select Case Trim(v_strFLDNAME)
                        Case "GROUPID"
                            v_strGROUPID = Trim(v_strVALUE)

                        Case "ACCMEMBER"
                            v_strACCMEMBER = Trim(v_strVALUE)


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

            'Kiem tra loai hinh tieu khoan
            v_strSQL = "SELECT * FROM AFGRPLNK WHERE  ACCMEMBER = '" & v_strACCMEMBER & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count <> 0 Then
                Return ERR_SA_DUP_ACCMEMBER
            End If




            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If

            Return 0
        Catch ex As Exception
            ''ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
        'Return 0
    End Function
    Overrides Function CheckBeforeDelete(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strGROUPID, v_strSTATUS, v_strMNGGROUP As String
            Dim v_strFLDNAME, v_strVALUE As String
            Dim v_strSQL As String
            Dim v_strBRID, v_strTXDATE, v_strTLID As String
            Dim v_strACCMEMBER,
            v_strCOREBANK As String



            v_strBRID = CStr(CType(v_attrColl.GetNamedItem("BRID"), Xml.XmlAttribute).Value)

            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strTLID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Else
                v_strTLID = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeTXDATE) Is Nothing) Then
                v_strTXDATE = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXDATE), Xml.XmlAttribute).Value)
            Else
                v_strTXDATE = String.Empty
            End If


            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            Dim v_strClause As String
            If Not (v_attrColl.GetNamedItem(gc_AtributeCLAUSE) Is Nothing) Then
                v_strClause = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Else
                v_strClause = String.Empty
            End If


            v_strSQL = "SELECT * FROM AFGRPLNK WHERE " & v_strClause & ""
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            v_strGROUPID = v_ds.Tables(0).Rows(0)("GROUPID")
            v_strACCMEMBER = v_ds.Tables(0).Rows(0)("ACCMEMBER")

            v_strSQL = "SELECT * FROM AFGRP WHERE GROUPID = '" & v_strGROUPID & "' AND ACCLEADER = '" & v_strACCMEMBER & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

            If v_ds.Tables(0).Rows.Count <> 0 Then
                Return ERR_SA_NOT_ALLOW_DELETE_ACCLEADER
            End If




            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If

            Return 0
        Catch ex As Exception
            ''ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
        'Return 0
    End Function
 
End Class
