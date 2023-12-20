Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Public Class SECURITIES_TICKSIZE
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "SECURITIES_TICKSIZE"
    End Sub

#Region " Overrides functions "
    Overrides Function CheckBeforeAdd(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strCODEID, v_strSymbol As String
            Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String
            Dim v_dblFromPrice, v_dblToPrice, v_dblTickSize As Double
            Dim v_strSQL As String

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
                        Case "CODEID"
                            v_strCODEID = Trim(v_strVALUE)
                        Case "FROMPRICE"
                            v_dblFromPrice = CDbl(v_strVALUE.Trim())
                        Case "TOPRICE"
                            v_dblToPrice = CDbl(v_strVALUE.Trim())
                        Case "TICKSIZE"
                            v_dblTickSize = CDbl(v_strVALUE.Trim())
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

            'Kiểm tra trường CODEID có tồn tại hay không
            If v_strCODEID.Length > 0 Then
                v_strSQL = "SELECT COUNT(CODEID) FROM SBSECURITIES WHERE CODEID = '" & v_strCODEID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count = 1 Then
                    If v_ds.Tables(0).Rows(0)(0) = 0 Then
                        Return ERR_SE_CODEID_NOTFOUND
                    End If
                End If
            End If
            'Lấy MaxToprice, MinFromPrice, TickSizeMax, TickSizeMin  
            v_strSQL = "SELECT DAT.*,SEC.TICKSIZE TICKSIZEMAX,SECUR.TICKSIZE TICKSIZEMIN FROM(SELECT MAX(TOPRICE) MAXTOFRICE ,MIN(FROMPRICE) MINFROMFRICE  " & ControlChars.CrLf _
                   & "FROM SECURITIES_TICKSIZE WHERE TRIM(CODEID) ='" & v_strCODEID & "'AND STATUS = 'Y') DAT," & ControlChars.CrLf _
                   & "SECURITIES_TICKSIZE SEC,SECURITIES_TICKSIZE SECUR WHERE TRIM(SEC.CODEID) ='" & v_strCODEID & "'AND SEC.STATUS = 'Y' AND SEC.TOPRICE=DAT.MAXTOFRICE " & ControlChars.CrLf _
                   & "AND TRIM(SECUR.CODEID) ='" & v_strCODEID & "'AND SECUR.STATUS = 'Y' AND SECUR.FROMPRICE=DAT.MINFROMFRICE"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count >= 1 Then
                Dim v_dblTICKSIZEMAX As Double
                Dim v_dblTICKSIZEMIN As Double
                Dim v_dblMAXTOFRICE As Double
                Dim v_dblMINFROMFRICE As Double
                v_dblTICKSIZEMAX = CDbl(v_ds.Tables(0).Rows(0)("TICKSIZEMAX"))
                v_dblTICKSIZEMIN = CDbl(v_ds.Tables(0).Rows(0)("TICKSIZEMIN"))
                v_dblMAXTOFRICE = CDbl(v_ds.Tables(0).Rows(0)("MAXTOFRICE"))
                v_dblMINFROMFRICE = CDbl(v_ds.Tables(0).Rows(0)("MINFROMFRICE"))

                'Kiểm tra xem FromPrice và ToPrice có thỏa mãn hay không?
                If (v_dblFromPrice <> v_dblMAXTOFRICE + v_dblTICKSIZEMAX) And (v_dblToPrice <> v_dblMINFROMFRICE - v_dblTickSize) Then
                    Return ERR_SA_SECTICKSIZE_DUPLICATE
                End If
            End If
            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If
            'ContextUtil.SetComplete()
            Return 0
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try

    End Function

    Overrides Function CheckBeforeEdit(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strCODEID, v_strAUTOID, v_strSymbol As String
            Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String
            Dim v_dblTickSize, v_dblFromPrice, v_dblToPrice As Double
            Dim v_strSQL As String

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
                        Case "CODEID"
                            v_strCODEID = Trim(v_strVALUE)
                        Case "FROMPRICE"
                            v_dblFromPrice = CDbl(v_strVALUE.Trim())
                        Case "TOPRICE"
                            v_dblToPrice = CDbl(v_strVALUE.Trim())
                        Case "AUTOID"
                            v_strAUTOID = Trim(v_strVALUE.Trim())
                        Case "TICKSIZE"
                            v_dblTickSize = CDbl(v_strVALUE.Trim())

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

            'Kiểm tra xem TickSize này có phải là ở hai biên hay không?
            v_strSQL = "SELECT DAT.*,SEC.TOPRICE,SEC.FROMPRICE  FROM(SELECT MAX(TOPRICE) MAXTOFRICE ,MIN(FROMPRICE) MINFROMFRICE  " & ControlChars.CrLf _
                   & "FROM SECURITIES_TICKSIZE WHERE TRIM(CODEID) ='" & v_strCODEID & "') DAT,SECURITIES_TICKSIZE SEC WHERE TRIM(SEC.AUTOID)='" & v_strAUTOID & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count >= 1 Then
                Dim v_dblOldToPrice As Double
                Dim v_dblOldFromPrice As Double
                v_dblOldToPrice = CDbl(v_ds.Tables(0).Rows(0)("TOPRICE"))
                v_dblOldFromPrice = CDbl(v_ds.Tables(0).Rows(0)("FROMPRICE"))
                If (CDbl(v_ds.Tables(0).Rows(0)("MAXTOFRICE")) <> v_dblOldToPrice) And (CDbl(v_ds.Tables(0).Rows(0)("MINFROMFRICE")) <> v_dblOldFromPrice) Then
                    Return ERR_SA_SECTICKSIZE_DUPLICATE
                Else
                    'Lấy MaxToprice và MinFromPrice 
                    v_strSQL = "SELECT DAT.*,SEC.TICKSIZE TICKSIZEMAX,SECUR.TICKSIZE TICKSIZEMIN FROM(SELECT MAX(TOPRICE) MAXTOFRICE ,MIN(FROMPRICE) MINFROMFRICE  " & ControlChars.CrLf _
                           & "FROM SECURITIES_TICKSIZE WHERE TRIM(CODEID) ='" & v_strCODEID & "' AND TRIM(AUTOID)<> '" & v_strAUTOID & "' AND STATUS = 'Y') DAT," & ControlChars.CrLf _
                           & "SECURITIES_TICKSIZE SEC,SECURITIES_TICKSIZE SECUR WHERE TRIM(SEC.CODEID) ='" & v_strCODEID & "' AND TRIM(SEC.AUTOID)<> '" & v_strAUTOID & "' AND SEC.STATUS = 'Y' AND SEC.TOPRICE=DAT.MAXTOFRICE " & ControlChars.CrLf _
                           & "AND TRIM(SECUR.CODEID) ='" & v_strCODEID & "' AND TRIM(SECUR.AUTOID)<> '" & v_strAUTOID & "' AND SECUR.STATUS = 'Y' AND SECUR.FROMPRICE=DAT.MINFROMFRICE"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count >= 1 Then
                        Dim v_dblTICKSIZEMAX As Double
                        Dim v_dblTICKSIZEMIN As Double
                        Dim v_dblMAXTOFRICE As Double
                        Dim v_dblMINFROMFRICE As Double
                        v_dblTICKSIZEMAX = CDbl(v_ds.Tables(0).Rows(0)("TICKSIZEMAX"))
                        v_dblTICKSIZEMIN = CDbl(v_ds.Tables(0).Rows(0)("TICKSIZEMIN"))
                        v_dblMAXTOFRICE = CDbl(v_ds.Tables(0).Rows(0)("MAXTOFRICE"))
                        v_dblMINFROMFRICE = CDbl(v_ds.Tables(0).Rows(0)("MINFROMFRICE"))
                        'Kiểm tra xem FromPrice và ToPrice có thỏa mãn hay không?
                        If (v_dblFromPrice <> v_dblMAXTOFRICE + v_dblTICKSIZEMAX) And (v_dblToPrice <> v_dblMINFROMFRICE - v_dblTickSize) Then
                            Return ERR_SA_SECTICKSIZE_DUPLICATE
                        End If
                    End If
                End If
            End If
            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If
            'ContextUtil.SetComplete()
            Return 0
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try

    End Function

    Overrides Function CheckBeforeDelete(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strClause, v_strCCYCD, v_strCODEID, v_strSYMBOL As String
            Dim v_dblFromPrice, v_dblToPrice As Double
            Dim v_strLocal As String
            Dim v_strSQL As String
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
            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            'Tính các thông số
            v_strSQL = "SELECT CODEID,SYMBOL,FROMPRICE,TOPRICE FROM SECURITIES_TICKSIZE WHERE " & v_strClause
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count >= 1 Then
                v_strCODEID = v_ds.Tables(0).Rows(0)("CODEID")
                v_strSYMBOL = v_ds.Tables(0).Rows(0)("SYMBOL")
                v_dblFromPrice = CDbl(v_ds.Tables(0).Rows(0)("FROMPRICE"))
                v_dblToPrice = CDbl(v_ds.Tables(0).Rows(0)("TOPRICE"))
            End If

            v_strSQL = "SELECT MAX(TOPRICE) MAXTOPRICE,MIN(FROMPRICE) MINFROMPRICE FROM SECURITIES_TICKSIZE " _
                                                & "WHERE CODEID='" & v_strCODEID & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count >= 1 Then
                Dim v_dblMaxToPrice As Double
                Dim v_dblMinFromPrice As Double
                v_dblMaxToPrice = CDbl(v_ds.Tables(0).Rows(0)("MAXTOPRICE"))
                v_dblMinFromPrice = CDbl(v_ds.Tables(0).Rows(0)("MINFROMPRICE"))
                If (v_dblToPrice <> v_dblMaxToPrice) And (v_dblFromPrice <> v_dblMinFromPrice) Then
                    Return ERR_SA_SECTICKSIZE_CONSTRAINTS
                End If
            End If
            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If
            'ContextUtil.SetComplete()
            Return ERR_SYSTEM_OK
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try

    End Function
#End Region
End Class
