Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Public Class AFGRP
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "AFGRP"
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
            Dim v_strACCLEADER, _
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
                        Case "STATUS"
                            v_strSTATUS = Trim(v_strVALUE)
                        Case "ACCLEADER"
                            v_strACCLEADER = Trim(v_strVALUE)
                        Case "MNGGROUP"
                            v_strMNGGROUP = Trim(v_strVALUE)
                        
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
            v_strSQL = "SELECT * FROM AFGRP WHERE groupid = '" & v_strGROUPID & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count <> 0 Then
                Return ERR_SA_DUP_GROUPID
            End If

            
            'Kiem tra tieu khoan trung
            v_ds.Clear()
            v_strSQL = "SELECT * FROM AFGRP WHERE  ACCLEADER = '" & v_strACCLEADER & "'"
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

    Overrides Function CheckBeforeEdit(ByVal v_strMessage As String) As Long
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
            Dim v_strACCLEADER,
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
                        Case "STATUS"
                            v_strSTATUS = Trim(v_strVALUE)
                        Case "ACCLEADER"
                            v_strACCLEADER = Trim(v_strVALUE)
                        Case "MNGGROUP"
                            v_strMNGGROUP = Trim(v_strVALUE)

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




            'Kiem tra tieu khoan trung

            v_strSQL = "SELECT * FROM AFGRP WHERE groupid <> '" & v_strGROUPID & "' and ACCLEADER = '" & v_strACCLEADER & "'"
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

    Overrides Function ProcessAfterAdd(ByVal v_strMessage As String) As Long
        Dim v_lngErrorCode As Long
        Dim v_strSYSVAR, v_strSQLTmp As String, v_DataAccess As New DataAccess
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        'Return ERR_SYSTEM_OK

        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Try

            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strGROUPID, v_strSTATUS, v_strACCLEADER, v_strMNGGROUP As String
            Dim v_strFLDNAME, v_strVALUE, v_strSQL As String
            Dim v_strTLID As String
            Dim v_BRID As String
            v_BRID = CStr(CType(v_attrColl.GetNamedItem("BRID"), Xml.XmlAttribute).Value)
            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If
            If Not (v_attrColl.GetNamedItem(gc_AtributeTLID) Is Nothing) Then
                v_strTLID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Else
                v_strTLID = String.Empty
            End If

            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strVALUE = .InnerText.ToString()

                    Select Case Trim(v_strFLDNAME)
                        Case "GROUPID"
                            v_strGROUPID = Trim(v_strVALUE)
                        Case "STATUS"
                            v_strSTATUS = Trim(v_strVALUE)
                        Case "ACCLEADER"
                            v_strACCLEADER = Trim(v_strVALUE)
                        Case "MNGGROUP"
                            v_strMNGGROUP = Trim(v_strVALUE)

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

            v_strSQL = " INSERT INTO AFGRPLNK (AUTOID, GROUPID, ACCMEMBER ) " & ControlChars.CrLf _
                            & "SELECT SEQ_AFGRPLNK.NEXTVAL, '" & v_strGROUPID & "', '" & v_strACCLEADER & "' " & ControlChars.CrLf _
                        & "      FROM DUAL"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Overrides Function ProcessAfterEdit(ByVal v_strMessage As String) As Long
        Dim v_lngErrorCode As Long
        Dim v_strSYSVAR, v_strSQLTmp As String, v_DataAccess As New DataAccess
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        'Return ERR_SYSTEM_OK

        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Try

            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strGROUPID, v_strSTATUS, v_strACCLEADER, v_strMNGGROUP As String
            Dim v_strFLDNAME, v_strVALUE, v_strSQL As String
            Dim v_strTLID As String
            Dim v_BRID As String
            v_BRID = CStr(CType(v_attrColl.GetNamedItem("BRID"), Xml.XmlAttribute).Value)
            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If
            If Not (v_attrColl.GetNamedItem(gc_AtributeTLID) Is Nothing) Then
                v_strTLID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Else
                v_strTLID = String.Empty
            End If

            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strVALUE = .InnerText.ToString()

                    Select Case Trim(v_strFLDNAME)
                        Case "GROUPID"
                            v_strGROUPID = Trim(v_strVALUE)
                        Case "STATUS"
                            v_strSTATUS = Trim(v_strVALUE)
                        Case "ACCLEADER"
                            v_strACCLEADER = Trim(v_strVALUE)
                        Case "MNGGROUP"
                            v_strMNGGROUP = Trim(v_strVALUE)

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

            v_strSQL = " select * from AFGRPLNK  " & ControlChars.CrLf _
                           & "where GROUPID = '" & v_strGROUPID & "' and ACCMEMBER = '" & v_strACCLEADER & "' " & ControlChars.CrLf


            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 0 Then
                v_strSQL = " INSERT INTO AFGRPLNK (AUTOID, GROUPID, ACCMEMBER ) " & ControlChars.CrLf _
                            & "SELECT SEQ_AFGRPLNK.NEXTVAL, '" & v_strGROUPID & "', '" & v_strACCLEADER & "' " & ControlChars.CrLf _
                        & "      FROM DUAL"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End If


        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Overrides Function ProcessAfterDelete(ByVal v_strMessage As String) As Long
        Dim v_lngErrorCode As Long
        Dim v_strSYSVAR, v_strSQLTmp As String, v_DataAccess As New DataAccess
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        'Return ERR_SYSTEM_OK

        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Try

            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strGROUPID, v_strSTATUS, v_strACCLEADER, v_strMNGGROUP As String
            Dim v_strFLDNAME, v_strVALUE, v_strSQL As String
            Dim v_strTLID As String
            Dim v_BRID As String
            v_BRID = CStr(CType(v_attrColl.GetNamedItem("BRID"), Xml.XmlAttribute).Value)
            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If
            If Not (v_attrColl.GetNamedItem(gc_AtributeTLID) Is Nothing) Then
                v_strTLID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Else
                v_strTLID = String.Empty
            End If

            'v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            'For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
            '    With v_nodeList.Item(0).ChildNodes(i)
            '        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
            '        v_strVALUE = .InnerText.ToString()

            '        Select Case Trim(v_strFLDNAME)
            '            Case "GROUPID"
            '                v_strGROUPID = Trim(v_strVALUE)
            '            Case "STATUS"
            '                v_strSTATUS = Trim(v_strVALUE)
            '            Case "ACCLEADER"
            '                v_strACCLEADER = Trim(v_strVALUE)
            '            Case "MNGGROUP"
            '                v_strMNGGROUP = Trim(v_strVALUE)

            '        End Select
            '    End With
            'Next

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
            v_strSQL = " DELETE FROM AFGRPLNK  " & ControlChars.CrLf _
                            & "WHERE " & v_strClause & ""
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

        Catch ex As Exception
            Throw ex
        End Try

    End Function
End Class
