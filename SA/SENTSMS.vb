Imports HostCommonLibrary
Imports System.IO
Imports DataAccessLayer
Imports System.Text
Imports System.Data
Public Class SENTSMS
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Private mDelimiterItems As Char = ";"
    Public Sub New()
        ATTR_TABLE = "SENTSMS"
    End Sub
    Overrides Function Adhoc(ByRef v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strFuncName As String

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            v_strFuncName = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeFUNCNAME), Xml.XmlAttribute).Value)

            Select Case Trim(v_strFuncName)
                Case "SENTSMS"
                    v_lngErrCode = SENTSMS(pv_xmlDocument)
                    If v_lngErrCode <> ERR_SYSTEM_OK Then
                        Return v_lngErrCode
                    End If
                Case "SMSSYSTEM"
                    v_lngErrCode = SMSSYSTEM(pv_xmlDocument)
                    If v_lngErrCode <> ERR_SYSTEM_OK Then
                        Return v_lngErrCode
                    End If

            End Select

            'ContextUtil.SetComplete()S
            v_strMessage = pv_xmlDocument.InnerXml
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
    Private Function SMSSYSTEM(ByRef pv_xmlDocument As XmlDocumentEx) As Long
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strFileCode As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)
            Dim v_strClause As String
            Dim v_strLocal As String
            Dim v_strAutoId As String
            Dim v_intCount As Integer = 0
            Dim v_lngErrCode As Long = ERR_SYSTEM_OK
            Dim v_strErrorSource As String = "SA.SENTSMS.SMSSYSTEM", v_strErrorMessage As String
            Dim v_strFeedBackMsg As String
            Dim v_strIsApprove As String
            Dim v_strOVRRQD As String
            Dim v_strTellerID As String

            Dim v_FRMDATE, v_TODATE, v_RETURNTRADING, v_TYPESMS, v_SMSCUSTOM, v_strTYPESMS As String

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

            If Not (v_attrColl.GetNamedItem(gc_AtributeRESERVER) Is Nothing) Then
                v_strIsApprove = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeRESERVER), Xml.XmlAttribute).Value)
            Else
                v_strIsApprove = "N"
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeAUTOID) Is Nothing) Then
                v_FRMDATE = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeAUTOID), Xml.XmlAttribute).Value)
            Else
                v_FRMDATE = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeTLID) Is Nothing) Then
                v_strTellerID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Else
                v_strTellerID = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeREFERENCE) Is Nothing) Then
                v_RETURNTRADING = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)
            Else
                v_RETURNTRADING = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeTXNUM) Is Nothing) Then
                v_TODATE = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXNUM), Xml.XmlAttribute).Value)
            Else
                v_TODATE = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeRESERVER) Is Nothing) Then
                v_TYPESMS = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeRESERVER), Xml.XmlAttribute).Value)
            Else
                v_TYPESMS = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeIPADDRESS) Is Nothing) Then
                v_SMSCUSTOM = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeIPADDRESS), Xml.XmlAttribute).Value)
            Else
                v_SMSCUSTOM = String.Empty
            End If

            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            Select Case v_TYPESMS
                Case "001"
                    v_strTYPESMS = "336A"
                Case "002"
                    v_strTYPESMS = "336B"
                Case "003"
                    v_strTYPESMS = "336C"
                Case "004"
                    v_strTYPESMS = "336D"
                Case "005"
                    v_strTYPESMS = "336E"
                Case "006"
                    v_strTYPESMS = "336F"
            End Select

            Dim v_objParam As New StoreParameter
            Dim v_arrPara(5) As StoreParameter
            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_err_code"
            v_objParam.ParamValue = "0"
            v_objParam.ParamDirection = ParameterDirection.Output
            v_objParam.ParamSize = 10
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(0) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "FRMDATE"
            v_objParam.ParamValue = v_FRMDATE
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamSize = 10
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(1) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "TODATE"
            v_objParam.ParamValue = v_TODATE
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamSize = 10
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(2) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "RETURNTRADE"
            v_objParam.ParamValue = v_RETURNTRADING
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamSize = 10
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(3) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "SMSCUSTOM"
            v_objParam.ParamValue = v_SMSCUSTOM
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamSize = 1000
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(4) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "TYPESMS"
            v_objParam.ParamValue = v_strTYPESMS
            v_objParam.ParamDirection = ParameterDirection.Input
            v_objParam.ParamSize = 10
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(5) = v_objParam

            v_lngErrCode = v_obj.ExecuteOracleStored("SENDSMS_FROMSYSTEM", v_arrPara, 0)

            If v_lngErrCode <> ERR_SYSTEM_OK Then
                'Tra ve ma loi xuat ra tu function
                pv_xmlDocument.DocumentElement.Attributes.GetNamedItem(gc_AtributeRESERVER).Value = v_strFeedBackMsg
            End If
            Return v_lngErrCode

        Catch ex As Exception

        End Try
    End Function

    Private Function SENTSMS(ByRef pv_xmlDocument As XmlDocumentEx) As Long

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strFileCode As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)
            Dim v_strClause As String
            Dim v_strLocal As String
            Dim v_strAutoId As String
            Dim v_intCount As Integer = 0
            Dim v_lngErrCode As Long = ERR_SYSTEM_OK
            Dim v_strErrorSource As String = "SA.SENTSMS.SENTSMS", v_strErrorMessage As String
            Dim v_strFeedBackMsg As String
            Dim v_strIsApprove As String
            Dim v_strOVRRQD As String
            Dim v_strTellerID As String

            Dim v_FRMDATE, v_TODATE, v_RETURNTRADING, v_TYPESMS, v_SMSCUSTOM As String

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

            If Not (v_attrColl.GetNamedItem(gc_AtributeRESERVER) Is Nothing) Then
                v_strIsApprove = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeRESERVER), Xml.XmlAttribute).Value)
            Else
                v_strIsApprove = "N"
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeAUTOID) Is Nothing) Then
                v_FRMDATE = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeAUTOID), Xml.XmlAttribute).Value)
            Else
                v_FRMDATE = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeTLID) Is Nothing) Then
                v_strTellerID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Else
                v_strTellerID = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeREFERENCE) Is Nothing) Then
                v_RETURNTRADING = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)
            Else
                v_RETURNTRADING = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeTXNUM) Is Nothing) Then
                v_TODATE = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXNUM), Xml.XmlAttribute).Value)
            Else
                v_TODATE = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeRESERVER) Is Nothing) Then
                v_TYPESMS = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeRESERVER), Xml.XmlAttribute).Value)
            Else
                v_TYPESMS = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeIPADDRESS) Is Nothing) Then
                v_SMSCUSTOM = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeIPADDRESS), Xml.XmlAttribute).Value)
            Else
                v_SMSCUSTOM = String.Empty
            End If


            'Inquiry data
            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If
            'Insert vao db
            Dim v_ds As New DataSet
            Dim v_sql As String

            v_sql = "INSERT INTO SMSLISTLOG(AUTOID,FRMDATE,TODATE,RETURNTRADE,PHONELIST,CREATEDATE,TYPESMS) VALUES(smslistlog_seq.NEXTVAL,'" & v_FRMDATE & "','" & v_TODATE & "','" & v_RETURNTRADING & "',utl_raw.cast_to_raw('" & v_strClause & "'),SYSTIMESTAMP,'" & v_TYPESMS & "')"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_sql)

            Dim v_arrClause() As String
            v_arrClause = v_strClause.Split(";")
            Dim v_strInsert As String
            Dim v_strTYPESMS As String
            Dim v_strDATASOURCE As String
            Select Case v_TYPESMS
                Case "001"
                    v_strTYPESMS = "336A"
                Case "002"
                    v_strTYPESMS = "336B"
                Case "003"
                    v_strTYPESMS = "336C"
                Case "004"
                    v_strTYPESMS = "336D"
                Case "005"
                    v_strTYPESMS = "336E"
                Case "006"
                    v_strTYPESMS = "336F"
            End Select

            v_strInsert = ""

            Dim j As Integer = 0

            'If v_strTYPESMS = "336F" Then
            'v_strDATASOURCE = "SELECT ''" & v_SMSCUSTOM & "'' detail FROM DUAL"
            'Else

            'v_strDATASOURCE = "Select ''" & v_FRMDATE & "'' fromdate, ''" & v_TODATE & "'' todate, ''" & v_RETURNTRADING & "'' RETURNTRADING " & " from dual"
            'End If


            If v_strTYPESMS = "336A" Then
                v_strDATASOURCE = "PHS-TB: Ngay le Giai Phong Mien Nam va Quoc Te Lao Dong, PHS nghi G.dich tu " & v_FRMDATE & " den " & v_TODATE & " va GD tro lai vao ngay " & v_RETURNTRADING & ". Chuc Quy nha dau tu nghi le vui ve."
            ElseIf v_strTYPESMS = "336B" Then
                v_strDATASOURCE = "PHS-TB: PHS nghi tet Am lich tu " & v_FRMDATE & " den " & v_TODATE & " va GD tro lai vao ngay " & v_RETURNTRADING & ". Chuc Quy nha dau tu Nam moi nhieu May man va Thanh cong."
            ElseIf v_strTYPESMS = "336C" Then
                v_strDATASOURCE = "PHS-TB: PHS nghi G.dich Tet Duong Lich tu " & v_FRMDATE & " den " & v_TODATE & " va GD tro lai vao ngay " & v_RETURNTRADING & ". Chuc Quy nha dau tu Nam moi nhieu May man va Thanh cong."
            ElseIf v_strTYPESMS = "336D" Then
                v_strDATASOURCE = "PHS-TB: Ngay Quoc Khanh 2/9, PHS nghi giao dich tu " & v_FRMDATE & " den " & v_TODATE & " va GD tro lai vao ngay " & v_RETURNTRADING & ". Chuc Quy nha dau tu nghi le vui ve."
            ElseIf v_strTYPESMS = "336E" Then
                v_strDATASOURCE = "PHS-TB: Nhan ngay Gio To Hung Vuong, PHS nghi giao dich tu " & v_FRMDATE & " den " & v_TODATE & " va GD tro lai vao ngay " & v_RETURNTRADING & ". Chuc Quy nha dau tu nghi le vui ve."
            Else
                v_strDATASOURCE = v_SMSCUSTOM
            End If




            For i As Integer = 0 To v_arrClause.Length - 1
                v_strInsert = v_strInsert & " INSERT INTO EMAILLOG(autoid,email,templateid,datasource,status,createtime,txdate) VALUES(seq_emaillog.nextval,'" & v_arrClause(i) & "','" & v_strTYPESMS & "','" & v_strDATASOURCE & "','A',sysdate,getcurrdate) ;"

                j = j + 1
                If j = 50 Or j = v_arrClause.Length - 1 Then
                    Dim v_strSQL = "BEGIN " & v_strInsert & " END; "
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    v_strSQL = String.Empty
                    v_strInsert = String.Empty
                    j = 0
                End If

            Next


            If v_lngErrCode <> ERR_SYSTEM_OK Then
                'Tra ve ma loi xuat ra tu function
                pv_xmlDocument.DocumentElement.Attributes.GetNamedItem(gc_AtributeRESERVER).Value = v_strFeedBackMsg
            End If
            Return v_lngErrCode

        Catch ex As Exception
            LogError.WriteException(ex)
            Return ERR_SA_IMPORT_FILE_INVALID 'File du lieu dau vao khong hop le
            Throw ex
        End Try


    End Function
End Class
