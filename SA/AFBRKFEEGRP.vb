Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Public Class AFMRLIMITGRP
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()
    Public Sub New()
        ATTR_TABLE = "AFMRLIMITGRP"
    End Sub

#Region " Overrides functions "
    Overrides Function CheckBeforeAdd(ByVal v_strMessage As String) As Long
        Dim v_strErrorSource, v_strErrorMessage As String
        v_strErrorSource = Me.ATTR_TABLE + ".CheckBeforeAdd"
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_ds As New DataSet
        Dim v_nodeList As Xml.XmlNodeList
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strAFACCTNO As String
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
                        Case "AFACCTNO"
                            v_strAFACCTNO = Trim(v_strVALUE)
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
            'Kiem tra so TK co ton tia hay khong 
            v_strSQL = "SELECT COUNT(*) FROM AFMAST WHERE ACCTNO='" & v_strAFACCTNO & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If gf_CorrectNumericField(v_ds.Tables(0).Rows(0)(0)) = 0 Then
                Return ERR_CF_AFMAST_NOTFOUND 'Tieu khoan khong ton tai
            End If

            'Kiem tra tieu khoan khong duoc thuoc mot nhom nao
            v_strSQL = "SELECT COUNT(*) FROM AFMRLIMITGRP WHERE AFACCTNO='" & v_strAFACCTNO & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If gf_CorrectNumericField(v_ds.Tables(0).Rows(0)(0)) > 0 Then
                Return ERR_SA_ACOUNT_IN_AFMRLIMIT_GROUP 'Tieu khoan da duoc gan vao mot nhom
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

    Public Overrides Function SystemProcessBeforeDelete(ByRef v_strMessage As String) As Long
        Dim v_strSQL As String = String.Empty
        Dim v_strCLAUSE, v_strLocal As String
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
        Dim v_strErrorSource As String = Me.ATTR_TABLE + ".SystemProcessBeforeDelete", v_strErrorMessage As String
        Try
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
            v_strSQL = "INSERT INTO AFMRLIMITGRPLOG select * from AFMRLIMITGRP where " & v_strCLAUSE
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            Complete()
            Return 0
        Catch ex As Exception
            LogError.WriteException(ex)
        End Try
    End Function
#End Region

End Class