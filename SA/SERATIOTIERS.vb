Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Public Class SERATIOTIERS
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "SERATIOTIERS"
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
                        Case "EXTRATE"
                            v_dblEXTRATE = CDbl(v_strVALUE)
                        Case "EXTVAL"
                            v_dblEXTVAL = CDbl(v_strVALUE)
                        Case "REFAUTOID"
                            v_strREFAUTOID = v_strVALUE.Trim
                        Case "FRVALUE"
                            v_dblFRVALUE = CDbl(v_strVALUE)
                        Case "TOVALUE"
                            v_dblTOVALUE = CDbl(v_strVALUE)
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


            If v_dblFRVALUE >= v_dblTOVALUE Then
                Return ERR_SA_SERATIOTIERS_WRONG_DATA
            End If




            v_strSQL = "SELECT *  FROM SERATIOTIERS WHERE REFAUTOID = '" & v_strREFAUTOID & "' and tovalue > '" & v_dblFRVALUE & "' "
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

            If v_ds.Tables(0).Rows.Count <> 0 Then
                Return ERR_SA_SERATIOTIERS_WRONG_DATA
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
            Dim v_strSQL, v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String

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
                        Case "EXTRATE"
                            v_dblEXTRATE = CDbl(v_strVALUE)
                        Case "EXTVAL"
                            v_dblEXTVAL = CDbl(v_strVALUE)
                        Case "REFAUTOID"
                            v_strREFAUTOID = v_strVALUE.Trim
                        Case "FRVALUE"
                            v_dblFRVALUE = CDbl(v_strVALUE)
                        Case "TOVALUE"
                            v_dblTOVALUE = CDbl(v_strVALUE)
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


            If v_dblFRVALUE >= v_dblTOVALUE Then
                Return ERR_SA_SERATIOTIERS_WRONG_DATA
            End If




            v_strSQL = "SELECT *  FROM SERATIOTIERS WHERE REFAUTOID = '" & v_strREFAUTOID & "' and AUTOID <> '" & v_strAUTOID & "' and '" & v_dblFRVALUE & "' < frvalue and '" & v_dblTOVALUE & "' > tovalue"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

            If v_ds.Tables(0).Rows.Count <> 0 Then
                Return ERR_SA_SERATIOTIERS_WRONG_DATA
            End If

            v_strSQL = "SELECT *  FROM SERATIOTIERS WHERE REFAUTOID = '" & v_strREFAUTOID & "' and AUTOID <> '" & v_strAUTOID & "' and '" & v_dblFRVALUE & "' < frvalue and rownum =1 order by frvalue"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            Dim v_strAutoidnext As String
            v_strAutoidnext = v_ds.Tables(0).Rows(0)("AUTOID").ToString
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_strSQL = "update SERATIOTIERS set frvalue = '" & v_dblTOVALUE & "' WHERE AUTOID = '" & v_strAutoidnext & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
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
        Dim v_strErrorSource As String = "SA.SERATIOTIERS.CheckBeforeDelete", v_strErrorMessage As String

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

            v_strSQL = "SELECT *  FROM SERATIOTIERS A, SERATIOTIERS B WHERE A." & v_strCLAUSE & " and A.REFAUTOID = B.REFAUTOID AND A.frvalue < B.frvalue "
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

            If v_ds.Tables(0).Rows.Count <> 0 Then
                Return ERR_SA_SERATIOTIERS_CANT_DELETE
            End If

            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
End Class
