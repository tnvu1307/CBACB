Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Public Class CRBTRFLOG
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "CRBTRFLOG"
    End Sub

    Overrides Function Adhoc(ByRef v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strFuncName As String
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            v_strFuncName = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeFUNCNAME), Xml.XmlAttribute).Value)

            Select Case Trim(v_strFuncName)
                Case "CreateListOfVoucher"
                    v_lngErrCode = CreateListOfVoucher(pv_xmlDocument)
                Case "DeleteTxReq"
                    v_lngErrCode = DeleteTxReq(pv_xmlDocument)
            End Select
            v_strMessage = pv_xmlDocument.InnerXml

            Return v_lngErrCode
        Catch ex As Exception
        End Try
    End Function

#Region " Private function "

    Public Overrides Function CheckBeforeApprove(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strClause As String
            Dim v_strSQL, v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String

            If Not (v_attrColl.GetNamedItem(gc_AtributeCLAUSE) Is Nothing) Then
                v_strClause = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Else
                v_strClause = String.Empty
            End If

            Dim v_obj As New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)

            'Chỉ cho sửa nếu trạng thái là P
            v_strSQL = "SELECT MST.AUTOID FROM CRBTRFLOG MST WHERE MST.STATUS='P' " _
                & "AND " & v_strClause
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 0 Then
                'Trạng thái không hợp lệ
                Return ERR_CRBTRFLOG_INVALID_STATUS
            End If

            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If
            Return ERR_SYSTEM_OK
        Catch ex As Exception
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
            Dim v_strLocal, v_strAutoID, v_strVERSION As String
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
                            v_strAutoID = Trim(v_strVALUE)
                        Case "VERSION"
                            v_strVERSION = Trim(v_strVALUE)
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

            'Không được sửa trùng phiên bản 
            v_strSQL = "SELECT RF.AUTOID FROM CRBTRFLOG RF, CRBTRFLOG MST WHERE MST.AUTOID<>RF.AUTOID AND MST.TRFCODE=RF.TRFCODE AND MST.TXDATE=RF.TXDATE " _
                & "AND RF.VERSION='" & v_strVERSION & "' AND MST.AUTOID=" & v_strAutoID
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                'Trùng số hiệu
                Return ERR_CRBTRFLOG_VERSION_DUPLICATE
            End If

            'Chỉ cho sửa nếu trạng thái là P
            v_strSQL = "SELECT MST.AUTOID FROM CRBTRFLOG MST WHERE MST.STATUS='P' " _
                & "AND MST.AUTOID=" & v_strAutoID
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 0 Then
                'Trạng thái không hợp lệ
                Return ERR_CRBTRFLOG_INVALID_STATUS
            End If

            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If
            Return ERR_SYSTEM_OK
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function CreateListOfVoucher(ByRef pv_xmlDocument As XmlDocumentEx) As Long
        Dim v_obj As New DataAccess, v_ds As DataSet, v_strSQL, v_strSYSVAR As String
        Dim v_strErrorSource As String = ATTR_TABLE & ".CreateListOfVoucher"
        Dim v_objParam As New StoreParameter
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        v_obj.NewDBInstance(gc_MODULE_HOST)
        Dim v_dblNumREQ As Long
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strBRID, v_strTLID, v_strTXDATE, v_strTRFCODE, v_strListOfREQID As String

            'Lấy các thông tin header của tham số
            If Not (v_attrColl.GetNamedItem(gc_AtributeBRID) Is Nothing) Then
                v_strBRID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeBRID), Xml.XmlAttribute).Value)
            Else
                v_strBRID = String.Empty
            End If
            If Not (v_attrColl.GetNamedItem(gc_AtributeTLID) Is Nothing) Then
                v_strTLID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Else
                v_strTLID = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeTXDATE) Is Nothing) Then
                v_strTXDATE = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXDATE), Xml.XmlAttribute).Value)
            Else
                v_strTXDATE = String.Empty
            End If
            If Not (v_attrColl.GetNamedItem(gc_AtributeCLAUSE) Is Nothing) Then
                v_strTRFCODE = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Else
                v_strTRFCODE = String.Empty
            End If
            If Not (v_attrColl.GetNamedItem(gc_AtributeREFERENCE) Is Nothing) Then
                v_strListOfREQID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)
            Else
                v_strListOfREQID = String.Empty
            End If

            'Tạo object dữ liệu
            'G?i Stored �để tạo bảng kê
            'TungNT modified - bo param TRFCODE
            Dim v_arrPara(5) As StoreParameter
            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_err_code"
            v_objParam.ParamValue = "0"
            v_objParam.ParamDirection = ParameterDirection.Output
            v_objParam.ParamSize = 10
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(0) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_txdate"
            v_objParam.ParamValue = v_strTXDATE
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamSize = 10
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(1) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_tlid"
            v_objParam.ParamValue = v_strTLID
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamSize = 4
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(2) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_brid"
            v_objParam.ParamValue = v_strBRID
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamSize = 4
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(3) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_trfcode"
            v_objParam.ParamValue = v_strTRFCODE
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamSize = 50
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(4) = v_objParam

            Dim v_strTemp As String = ""

            v_strSQL = "select varvalue from sysvar where grname ='SYSTEM' and varname ='CRB_MAX_REQ'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            v_dblNumREQ = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)(0))
            While v_strListOfREQID.Length > 0
                Dim v_strT() As String = v_strListOfREQID.Split(",")
                v_strTemp = ""
                If v_strT.Count - 1 > v_dblNumREQ Then
                    For i As Integer = 0 To v_dblNumREQ - 1
                        v_strTemp = v_strTemp & v_strT(i) & ","
                    Next
                    v_strTemp = v_strTemp.Substring(0, v_strTemp.Length - 1)
                    v_strListOfREQID = v_strListOfREQID.Substring(v_strTemp.Length + 1)
                Else
                    v_strTemp = v_strListOfREQID
                    v_strListOfREQID = ""
                End If

                'If v_strListOfREQID.Length > 50 Then
                '    v_strTemp = v_strListOfREQID.Substring(0, 50)
                '    v_strTemp = v_strTemp.Substring(0, v_strTemp.LastIndexOf(","))
                '    v_strListOfREQID = v_strListOfREQID.Substring(v_strTemp.Length + 1) ', v_strListOfREQID.Length - v_strTemp.Length - 1)
                'Else
                '    v_strTemp = v_strListOfREQID
                '    v_strListOfREQID = ""
                'End If

                v_objParam = New StoreParameter
                v_objParam.ParamName = "p_lreqid"
                v_objParam.ParamValue = v_strTemp
                v_objParam.ParamDirection = ParameterDirection.Input
                v_objParam.ParamSize = 32000
                v_objParam.ParamType = GetType(System.String).Name
                v_arrPara(5) = v_objParam

                v_lngErrCode = v_obj.ExecuteOracleStored("cspks_rmproc.SP_EXEC_CREATE_CRBTRFLOG", v_arrPara, 0)
                If v_lngErrCode <> ERR_SYSTEM_OK Then
                    Exit While
                End If
            End While
            'End
            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        Finally
            v_obj = Nothing
        End Try
    End Function

    Private Function DeleteTxReq(ByRef pv_xmlDocument As XmlDocumentEx) As Long
        Dim v_obj As New DataAccess, v_ds As DataSet, v_strSQL, v_strTxDesc As String
        Dim v_strErrorSource As String = ATTR_TABLE & ".DeleteTxReq"
        Dim v_objParam As New StoreParameter
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        v_obj.NewDBInstance(gc_MODULE_HOST)
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strBRID, v_strTLID, v_strTXDATE, v_strReqIDList As String

            'Lấy các thông tin header của tham số
            If Not (v_attrColl.GetNamedItem(gc_AtributeBRID) Is Nothing) Then
                v_strBRID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeBRID), Xml.XmlAttribute).Value)
            Else
                v_strBRID = String.Empty
            End If
            If Not (v_attrColl.GetNamedItem(gc_AtributeTLID) Is Nothing) Then
                v_strTLID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Else
                v_strTLID = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeTXDATE) Is Nothing) Then
                v_strTXDATE = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXDATE), Xml.XmlAttribute).Value)
            Else
                v_strTXDATE = String.Empty
            End If
            If Not (v_attrColl.GetNamedItem(gc_AtributeCLAUSE) Is Nothing) Then
                v_strReqIDList = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Else
                v_strReqIDList = String.Empty
            End If
            If Not (v_attrColl.GetNamedItem(gc_AtributeREFERENCE) Is Nothing) Then
                v_strTxDesc = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)
            Else
                v_strTxDesc = String.Empty
            End If

            Dim v_arrPara(5) As StoreParameter
            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_err_code"
            v_objParam.ParamValue = "0"
            v_objParam.ParamDirection = ParameterDirection.Output
            v_objParam.ParamSize = 10
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(0) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_txdate"
            v_objParam.ParamValue = v_strTXDATE
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamSize = 10
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(1) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_tlid"
            v_objParam.ParamValue = v_strTLID
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamSize = 4
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(2) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_brid"
            v_objParam.ParamValue = v_strBRID
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamSize = 4
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(3) = v_objParam

            Dim v_strTemp As String = ""
            While v_strReqIDList.Length > 0
                If v_strReqIDList.Length > 50 Then
                    v_strTemp = v_strReqIDList.Substring(0, 50)
                    v_strTemp = v_strTemp.Substring(0, v_strTemp.LastIndexOf(","))
                    v_strReqIDList = v_strReqIDList.Substring(v_strTemp.Length + 1) ', v_strListOfREQID.Length - v_strTemp.Length - 1)
                Else
                    v_strTemp = v_strReqIDList
                    v_strReqIDList = ""
                End If

                v_objParam = New StoreParameter
                v_objParam.ParamName = "p_lreqid"
                v_objParam.ParamValue = v_strTemp
                v_objParam.ParamDirection = ParameterDirection.Input
                v_objParam.ParamSize = 32000
                v_objParam.ParamType = GetType(System.String).Name
                v_arrPara(4) = v_objParam

                v_objParam = New StoreParameter
                v_objParam.ParamName = "p_ltxdesc"
                v_objParam.ParamValue = v_strTxDesc
                v_objParam.ParamDirection = ParameterDirection.Input
                v_objParam.ParamSize = 32000
                v_objParam.ParamType = GetType(System.String).Name
                v_arrPara(5) = v_objParam

                v_lngErrCode = v_obj.ExecuteOracleStored("cspks_rmproc.SP_DELETETXREQ", v_arrPara, 0)
                If v_lngErrCode <> ERR_SYSTEM_OK Then
                    Exit While
                End If
            End While
            'End
            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            v_lngErrCode = ERR_SYSTEM_START
            Throw ex
        Finally
            v_obj = Nothing
        End Try
    End Function

#End Region

End Class
