Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Public Class Calendar
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "SBCLDR"
    End Sub

    Overrides Function Adhoc(ByRef v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strFuncName As String
        Dim v_strObjMsg As String
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            v_strFuncName = Convert.ToString(CType(v_attrColl.GetNamedItem(gc_AtributeFUNCNAME), Xml.XmlAttribute).Value)
            Select Case Trim(v_strFuncName)
                Case "ADDNEWYEAR"
                    v_lngErrCode = ADDNEWYEAR(pv_xmlDocument)
                Case "SETHOLIDAY"
                    v_lngErrCode = SETHOLIDAY(pv_xmlDocument)
                Case "SET_DOM_HOLIDAY"
                    v_lngErrCode = SET_DOM_HOLIDAY(pv_xmlDocument)
                Case "SET_DOY_HOLIDAY"
                    v_lngErrCode = SET_DOY_HOLIDAY(pv_xmlDocument)
                    'Case "SET_DOM_CLEARDAY"
                    '    v_lngErrCode = SET_DOM_CLEARDAY(pv_xmlDocument)
                    'Case "SET_CLEARDAY"
                    '    v_lngErrCode = SET_CLEARDAY(pv_xmlDocument)
                    'Case "SET_DOM_SCHEDULE"
                    '    v_lngErrCode = SET_DOM_SCHEDULE(pv_xmlDocument)
                    '    'STE0012
                    'Case "SET_LASTWORKINGDATE"
                    '    v_lngErrCode = SET_LASTWORKINGDATE(pv_xmlDocument)
                    '    'STE0012
            End Select
            v_strMessage = pv_xmlDocument.InnerXml
            'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            Throw ex
        End Try
    End Function

    Private Function ADDNEWYEAR(ByRef pv_xmlDocument As XmlDocumentEx) As Long

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strClause As String
            Dim v_strLocal As String
            Dim v_strTellerId As String
            Dim v_strCmdInsertSQL As String

            If Not (v_attrColl.GetNamedItem(gc_AtributeCLAUSE) Is Nothing) Then
                v_strClause = Convert.ToString(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Else
                v_strClause = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = Convert.ToString(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeTLID) Is Nothing) Then
                v_strTellerId = Convert.ToString(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Else
                v_strTellerId = String.Empty
            End If


            'Inquiry data
            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If


            Dim v_arrSBCLDR() As String
            ReDim v_arrSBCLDR(1)
            v_arrSBCLDR = v_strClause.Split("$")

            Dim v_objParam As StoreParameter
            Dim v_arrParam(1) As StoreParameter

            v_objParam = New StoreParameter
            v_objParam.ParamName = "pv_strNewYear"
            v_objParam.ParamValue = v_arrSBCLDR(0)
            v_objParam.ParamSize = CInt(4)
            v_objParam.ParamType = "VARCHAR2"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_arrParam(0) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "pv_strHoliday"
            v_objParam.ParamValue = v_arrSBCLDR(1)
            v_objParam.ParamSize = CInt(20)
            v_objParam.ParamType = "VARCHAR2"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_arrParam(1) = v_objParam

            v_obj.ExecuteStoredNonQuerry("ADD_YEAR", v_arrParam)

            'ContextUtil.SetComplete()
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function SETHOLIDAY(ByRef pv_xmlDocument As XmlDocumentEx) As Long

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strClause As String
            Dim v_strLocal As String
            Dim v_strTellerId As String
            Dim v_strCmdInsertSQL As String

            Dim v_BOW As String = "N"
            Dim v_BOM As String = "N"
            Dim v_BOQ As String = "N"
            Dim v_BOY As String = "N"
            Dim v_EOW As String = "N"
            Dim v_EOM As String = "N"
            Dim v_EOQ As String = "N"
            Dim v_EOY As String = "N"

            If Not (v_attrColl.GetNamedItem(gc_AtributeCLAUSE) Is Nothing) Then
                v_strClause = Convert.ToString(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Else
                v_strClause = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = Convert.ToString(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeTLID) Is Nothing) Then
                v_strTellerId = Convert.ToString(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Else
                v_strTellerId = String.Empty
            End If


            'Inquiry data
            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If


            Dim v_arrSBCLDR() As String
            ReDim v_arrSBCLDR(2)
            v_arrSBCLDR = v_strClause.Split("$")

            Dim v_objParam As StoreParameter
            Dim v_arrParam(2) As StoreParameter

            v_objParam = New StoreParameter
            v_objParam.ParamName = "pv_strDay"
            v_objParam.ParamValue = v_arrSBCLDR(0)
            v_objParam.ParamSize = CInt(10)
            v_objParam.ParamType = "VARCHAR2"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_arrParam(0) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "pv_strHoliday"
            v_objParam.ParamValue = v_arrSBCLDR(1)
            v_objParam.ParamSize = CInt(1)
            v_objParam.ParamType = "VARCHAR2"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_arrParam(1) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "pv_strCLDRTYPE"
            v_objParam.ParamValue = v_arrSBCLDR(2)
            v_objParam.ParamSize = CInt(3)
            v_objParam.ParamType = "VARCHAR2"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_arrParam(2) = v_objParam

            v_obj.ExecuteStoredNonQuerry("SET_HOLIDAY", v_arrParam)

            'ContextUtil.SetComplete()
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function SET_DOM_HOLIDAY(ByRef pv_xmlDocument As XmlDocumentEx) As Long

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strClause As String
            Dim v_strLocal As String
            Dim v_strTellerId As String
            Dim v_strCmdInsertSQL As String


            If Not (v_attrColl.GetNamedItem(gc_AtributeCLAUSE) Is Nothing) Then
                v_strClause = Convert.ToString(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Else
                v_strClause = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = Convert.ToString(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeTLID) Is Nothing) Then
                v_strTellerId = Convert.ToString(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Else
                v_strTellerId = String.Empty
            End If


            'Inquiry data
            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If


            Dim v_arrSBCLDR() As String
            ReDim v_arrSBCLDR(4)
            v_arrSBCLDR = v_strClause.Split("$")

            Dim v_objParam As StoreParameter
            Dim v_arrParam(4) As StoreParameter

            v_objParam = New StoreParameter
            v_objParam.ParamName = "pv_strDay"
            v_objParam.ParamValue = v_arrSBCLDR(0)
            v_objParam.ParamSize = CInt(1)
            v_objParam.ParamType = "VARCHAR2"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_arrParam(0) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "pv_strMonth"
            v_objParam.ParamValue = v_arrSBCLDR(1)
            v_objParam.ParamSize = CInt(2)
            v_objParam.ParamType = "VARCHAR2"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_arrParam(1) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "pv_strYear"
            v_objParam.ParamValue = v_arrSBCLDR(2)
            v_objParam.ParamSize = CInt(4)
            v_objParam.ParamType = "VARCHAR2"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_arrParam(2) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "pv_strHoliday"
            v_objParam.ParamValue = v_arrSBCLDR(3)
            v_objParam.ParamSize = CInt(1)
            v_objParam.ParamType = "VARCHAR2"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_arrParam(3) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "pv_strCLDRTYPE"
            v_objParam.ParamValue = v_arrSBCLDR(4)
            v_objParam.ParamSize = CInt(3)
            v_objParam.ParamType = "VARCHAR2"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_arrParam(4) = v_objParam

            v_obj.ExecuteStoredNonQuerry("SET_DOM_HOLIDAY", v_arrParam)

            'ContextUtil.SetComplete()
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function SET_DOY_HOLIDAY(ByRef pv_xmlDocument As XmlDocumentEx) As Long

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strClause As String
            Dim v_strLocal As String
            Dim v_strTellerId As String
            Dim v_strCmdInsertSQL As String


            If Not (v_attrColl.GetNamedItem(gc_AtributeCLAUSE) Is Nothing) Then
                v_strClause = Convert.ToString(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Else
                v_strClause = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = Convert.ToString(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeTLID) Is Nothing) Then
                v_strTellerId = Convert.ToString(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Else
                v_strTellerId = String.Empty
            End If


            'Inquiry data
            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If


            Dim v_arrSBCLDR() As String
            ReDim v_arrSBCLDR(3)
            v_arrSBCLDR = v_strClause.Split("$")

            Dim v_objParam As StoreParameter
            Dim v_arrParam(3) As StoreParameter

            v_objParam = New StoreParameter
            v_objParam.ParamName = "pv_strDay"
            v_objParam.ParamValue = v_arrSBCLDR(0)
            v_objParam.ParamSize = CInt(1)
            v_objParam.ParamType = "VARCHAR2"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_arrParam(0) = v_objParam


            v_objParam = New StoreParameter
            v_objParam.ParamName = "pv_strYear"
            v_objParam.ParamValue = v_arrSBCLDR(1)
            v_objParam.ParamSize = CInt(4)
            v_objParam.ParamType = "VARCHAR2"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_arrParam(1) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "pv_strHoliday"
            v_objParam.ParamValue = v_arrSBCLDR(2)
            v_objParam.ParamSize = CInt(1)
            v_objParam.ParamType = "VARCHAR2"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_arrParam(2) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "pv_strCLDRTYPE"
            v_objParam.ParamValue = v_arrSBCLDR(3)
            v_objParam.ParamSize = CInt(3)
            v_objParam.ParamType = "VARCHAR2"
            v_objParam.ParamDirection = ParameterDirection.Input
            v_arrParam(3) = v_objParam

            v_obj.ExecuteStoredNonQuerry("SET_DOY_HOLIDAY", v_arrParam)

            'ContextUtil.SetComplete()
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

End Class
