Imports CommonLibrary
Imports System.Xml.XmlNode
Imports System.Xml
Imports TestBase64
Imports ZetaCompressionLibrary
Imports System.IO
Imports AppCore
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO.File
Imports System.IO.Path
Imports System.Windows.Forms.Application
Imports System.Text
Imports System.Globalization
Imports System.Configuration
Imports System.Threading
Imports DevExpress.XtraEditors

Public Class frmRPTGENCFG
    Inherits AppCore.frmXtraMaintenance
#Region "Declare constants and variables"
    Public WithEvents TAIPOGrid As GridEx
    Public WithEvents FUND_MEMBERGrid As GridEx

    Private Const c_type_PDF As String = "PDF"
    Private Const c_type_EXCEL As String = "EXCEL"
    Private Const c_type_CSV As String = "CSV"
    Private Const c_type_XML As String = "XML"
    Private Const c_type_SPLIT As String = ";"
#End Region

#Region "Control Hinden"
    Friend WithEvents txtAUTOID As TextEdit
    Friend WithEvents teFileType As TextEdit
#End Region

#Region "private sub"
    Public Overrides Sub OnInit()
        ResourceManager = New Resources.ResourceManager(gc_RootNamespace & "." & Me.Name & "-" & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        LocalObject = gc_IsNotLocalMsg
        InitControlHinden()
        MyBase.OnInit()
        LoadUserInterface(Me)
        If ExeFlag = ExecuteFlag.AddNew Then
            GetAUTOID()
        Else
            GenerateExportFileType()
            txtRPTID.Enabled = False
        End If
        If ExeFlag = ExecuteFlag.View OrElse ExeFlag = ExecuteFlag.Approve Then
            cePDF.Enabled = False
            ceEXCEL.Enabled = False
            ceCSV.Enabled = False
            ceXML.Enabled = False
        End If

    End Sub

    Private Sub GenerateExportFileType(Optional ByVal isSave = False)
        Dim v_fileType As String
        If isSave Then
            v_fileType = String.Empty
            If cePDF.Checked Then v_fileType &= c_type_PDF & c_type_SPLIT
            If ceEXCEL.Checked Then v_fileType &= c_type_EXCEL & c_type_SPLIT
            If ceCSV.Checked Then v_fileType &= c_type_CSV & c_type_SPLIT
            If ceXML.Checked Then v_fileType &= c_type_XML & c_type_SPLIT
            teFileType.EditValue = v_fileType
        Else
            v_fileType = teFileType.EditValue
            cePDF.Checked = v_fileType.Contains(c_type_PDF)
            ceEXCEL.Checked = v_fileType.Contains(c_type_EXCEL)
            ceCSV.Checked = v_fileType.Contains(c_type_CSV)
            ceXML.Checked = v_fileType.Contains(c_type_XML)
        End If
    End Sub

    Private Sub GetAUTOID()
        Dim v_ws As New BDSDeliveryManagement
        Dim v_strSQL As String = "SELECT SEQ_RPTGENCFG.NEXTVAL ID from DUAL"
        Dim v_strObjMsg As String = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_SEARCHFLD, _
            gc_ActionInquiry, v_strSQL, , )
        v_ws.Message(v_strObjMsg)
        Dim v_nodeList As Xml.XmlNodeList
        Dim XmlDocument As New Xml.XmlDocument
        Dim v_strFLDNAME, v_strValue, v_strID, v_strFUNDNAME As String
        v_strID = String.Empty
        XmlDocument.LoadXml(v_strObjMsg)
        v_nodeList = XmlDocument.SelectNodes("/ObjectMessage/ObjData")

        For i As Integer = 0 To v_nodeList.Count - 1
            For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                With v_nodeList.Item(i).ChildNodes(j)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strValue = .InnerText.ToString

                    Select Case Trim(v_strFLDNAME)
                        Case "ID"
                            v_strID = CStr(v_strValue).Trim
                            txtAUTOID.Text = v_strID
                    End Select
                End With
            Next
        Next
    End Sub

    Private Sub InitControlHinden()
        txtAUTOID = New TextEdit()
        txtAUTOID.Tag = "AUTOID"

        teFileType = New TextEdit()
        teFileType.Tag = "FILETYPE"

        CType(Me.txtAUTOID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.teFileType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

        Me.Controls.Add(txtAUTOID)
        Me.Controls.Add(teFileType)
    End Sub

    Overrides Sub LoadUserInterface(ByRef pv_ctrl As Windows.Forms.Control)
        MyBase.LoadUserInterface(pv_ctrl)

    End Sub

    Private Function VerifyRule(Optional ByVal pv_blnSaved As Boolean = False) As Boolean
        Try
            If Not (ceCSV.Checked Or cePDF.Checked Or ceXML.Checked Or ceCSV.Checked) Then
                MsgBox(ResourceManager.GetString("SELECT_EXPORT_TYPE"), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, gc_ApplicationTitle)
                Return False
            End If
            'Check valid
            Return MyBase.VerifyRules
        Catch ex As Exception
            Throw ex
            Return False
        End Try
    End Function
    Public Overrides Sub OnSave()
        Dim v_strObjMsg As String

        Try
            'Update mouse pointer
            Cursor.Current = Cursors.WaitCursor
            'Verify data 
            If (VerifyRule() = False) Then
                Exit Sub
            End If
            GenerateExportFileType(True)

            MyBase.OnSave()
            If Not DoDataExchange(True) Then
                Exit Sub
            End If

            Select Case ExeFlag
                Case ExecuteFlag.AddNew
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionAdd, , "AUTOID = '" & Me.txtAUTOID.Text & "'", , gc_AutoIdUnused)
                    BuildXMLObjData(mv_dsInput, v_strObjMsg)

                    Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                    Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)

                    'Kiểm tra thông tin và xử lý lỗi (nếu có) từ message trả v?
                    Dim v_strErrorSource, v_strErrorMessage As String

                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage)
                    If v_lngErrorCode <> 0 Then
                        'Update mouse pointer
                        Cursor.Current = Cursors.Default
                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Exit Sub
                    End If

                    MsgBox(ResourceManager.GetString("AddnewSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)

                    Select Case MyBase.SaveButtonType
                        Case SaveButtonType.ApplyButton
                            KeyFieldValue = GetControlValueByName(KeyFieldName, Me)
                            ExeFlag = ExecuteFlag.Edit
                            mv_dsOldInput = mv_dsInput
                        Case SaveButtonType.OKButton
                            Me.DialogResult = DialogResult.OK
                            'MyBase.OnClose()
                    End Select
                Case ExecuteFlag.Edit

                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionEdit, , " AUTOID = '" & Me.txtAUTOID.Text & "'")
                    BuildXMLObjData(mv_dsInput, v_strObjMsg, mv_dsOldInput, ExecuteFlag.Edit)

                    Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                    Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)

                    'Ki�ểm tra thông tin và xử lý lỗi (nếu có) từ message trả v?
                    Dim v_strErrorSource, v_strErrorMessage As String

                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage)
                    If v_lngErrorCode <> 0 Then
                        'Update mouse pointer
                        Cursor.Current = Cursors.Default
                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Exit Sub
                    End If

                    MsgBox(ResourceManager.GetString("EditSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)

                    Select Case MyBase.SaveButtonType
                        Case SaveButtonType.ApplyButton
                            KeyFieldValue = GetControlValueByName(KeyFieldName, Me)
                            ExeFlag = ExecuteFlag.Edit
                        Case SaveButtonType.OKButton
                            Me.DialogResult = DialogResult.OK
                            'MyBase.OnClose()
                    End Select
            End Select

            'Update mouse pointer
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ResourceManager.GetString("SavingFailed"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

#End Region
    Private Sub txtRPTID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRPTID.KeyDown
        Select Case e.KeyCode
            Case Keys.F5
                Dim frm As New frmSearch(Me.UserLanguage)
                frm.TableName = "RPTMASTER_FA"
                frm.ModuleCode = "FA"
                frm.KeyFieldType = "C"
                frm.AuthCode = "NNNNYYNNNN" 'Không cho phép thực hiện chức năng nào 
                frm.IsLocalSearch = gc_IsNotLocalMsg
                frm.IsLookup = "Y"
                frm.SearchOnInit = False
                frm.BranchId = Me.BranchId
                frm.TellerId = Me.TellerId
                frm.KeyColumn = "RPTID"
                frm.ShowDialog()
                If (frm.CurrentRow IsNot Nothing) Then
                    Me.ActiveControl.Text = Trim(frm.ReturnValue)
                    txtRPTNAME.Text = frm.CurrentRow.Cells("DESCRIPTION").Value
                End If

        End Select
    End Sub
    Private Sub cboCYCLE_CRET_EditValueChanged(sender As Object, e As EventArgs) Handles cboCYCLE_CRET.EditValueChanged
        Try
            Dim v_oldCREATETIME As String = String.Empty
            If mv_dsOldInput.Tables.Count > 0 AndAlso mv_dsOldInput.Tables(0).Rows.Count > 0 Then
                v_oldCREATETIME = mv_dsOldInput.Tables(0).Rows(0)("CREATETIME").ToString
            End If
            If cboCYCLE_CRET.EditValue IsNot Nothing Then
                If (cboCYCLE_CRET.EditValue.ToString() = "D") Then
                    txtCREATETIME.Enabled = True
                    If Not v_oldCREATETIME = String.Empty Then
                        txtCREATETIME.EditValue = v_oldCREATETIME
                    End If
                Else
                    txtCREATETIME.Enabled = False
                    txtCREATETIME.Text = ""
                End If

            End If

        Catch ex As Exception

        End Try
    End Sub

   
End Class