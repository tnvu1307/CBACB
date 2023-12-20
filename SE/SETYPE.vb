Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Imports System.Diagnostics
Public Class SETYPE
    Inherits CoreBusiness.basedTYPE

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "SETYPE"
    End Sub

    Public Overrides Function TYPECheckBeforeAdd(ByVal v_strMessage As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = ATTR_TABLE & ".SystemProcessBeforeEdit"
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strACTYPE, v_strCCYCD, v_strGLBANK, v_strGLGRP As String
            Dim v_strSQL, v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String
            Dim v_strPRINFRQCD, v_strINTFRQCD, v_strLNTYPE As String
            Dim v_intPRINFRQ, v_intINTFRQ As Integer

            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If
            v_strACTYPE = String.Empty
            v_strCCYCD = String.Empty
            v_strGLBANK = String.Empty
            v_strGLGRP = String.Empty

            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strVALUE = .InnerText.ToString().Trim
                    Select Case Trim(v_strFLDNAME)
                        Case "ACTYPE"
                            v_strACTYPE = Trim(v_strVALUE)
                        Case "GLGRP"
                            v_strGLGRP = Trim(v_strVALUE)
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

            'Kiểm tra ACTYPE không được trùng
            If v_strACTYPE.Length > 0 Then
                v_strSQL = "SELECT COUNT(ACTYPE) FROM " & ATTR_TABLE & " WHERE ACTYPE = '" & v_strACTYPE & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count = 1 Then
                    If v_ds.Tables(0).Rows(0)(0) > 0 Then
                        Return ERR_SA_PRODUCT_ACTYPE_DUPLICATED
                    End If
                End If
            End If

        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        Finally
            If Not (v_ds Is Nothing) Then v_ds.Dispose()
        End Try
    End Function

    Public Overrides Function TYPECheckBeforeEdit(ByVal v_strMessage As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = ATTR_TABLE & ".SystemProcessBeforeEdit"
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strACTYPE, v_strCCYCD, v_strGLBANK, v_strGLGRP As String
            Dim v_strSQL, v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String
            Dim v_strPRINFRQCD, v_strINTFRQCD, v_strLNTYPE As String
            Dim v_intPRINFRQ, v_intINTFRQ As Integer

            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If
            v_strACTYPE = String.Empty
            v_strCCYCD = String.Empty
            v_strGLBANK = String.Empty
            v_strGLGRP = String.Empty

            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strVALUE = .InnerText.ToString().Trim
                    Select Case Trim(v_strFLDNAME)
                        Case "ACTYPE"
                            v_strACTYPE = Trim(v_strVALUE)
                        Case "GLGRP"
                            v_strGLGRP = Trim(v_strVALUE)
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


        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        Finally
            If Not (v_ds Is Nothing) Then v_ds.Dispose()
        End Try
    End Function

    Public Overrides Function TYPECheckBeforeDelete(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strClause, v_strACCTNO, v_strAPPLID, v_strACTYPE, v_strCCYCD, v_strGLBANK, v_strGLGRP As String
            Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String, v_dblAPRLIMIT As Double
            Dim v_strSQL As String

            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If
            If Not (v_attrColl.GetNamedItem(gc_AtributeCLAUSE) Is Nothing) Then
                v_strClause = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Else
                v_strClause = String.Empty
            End If

            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            'Chi duoc phep xoa neu chua co loai hinh AF nao su dung
            v_strSQL = "SELECT SETYPE FROM AFTYPE WHERE SETYPE = " & v_strClause.Substring(v_strClause.IndexOf("=") + 1)
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                Return ERR_SA_PRODUCT_HAS_CONSTRAINT
            End If

            'Kiểm tra xem Mã dữ liệu bị xoá có nằm trong bảng __MAST khác hay không
            v_strSQL = "SELECT COUNT(ACTYPE) FROM " & ATTR_TABLE.Substring(0, 2) & "MAST WHERE 0=0 AND " & v_strClause
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 1 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_SA_PRODUCT_HAS_CONSTRAINT
                End If
            End If

            'Kiem tra ACTYPE co con du lieu lien quan trong bang ICCFTYPEDEF hay khong?
            v_strSQL = "SELECT COUNT(ACTYPE) FROM ICCFTYPEDEF WHERE MODCODE = '" & ATTR_TABLE.Substring(0, 2) & "' AND " & v_strClause
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 1 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_SA_PRODUCT_HAS_CONSTRAINT
                End If
            End If

            Return ERR_SYSTEM_OK
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        Finally
            If Not (v_ds Is Nothing) Then v_ds.Dispose()
        End Try
    End Function
End Class
