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
Public Class frmSBACTIMST
    Inherits AppCore.frmXtraMaintenance
#Region "Declare constants and variables"
    Public WithEvents TAIPOGrid As GridEx
    Public WithEvents FUND_MEMBERGrid As GridEx
#End Region

#Region "private sub"
    Public Overrides Sub OnInit()
        ResourceManager = New Resources.ResourceManager(gc_RootNamespace & "." & Me.Name & "-" & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        LocalObject = gc_IsNotLocalMsg
        MyBase.OnInit()
        LoadUserInterface(Me)
        'FormInit()
        InitExternal()
        btnSBACTIDTL_EDIT.Visible = False
        If ExeFlag = ExecuteFlag.AddNew Then
            GetKeyForTable()
            lblNumber.Visible = False
            nNumber.Visible = False
        Else
            InitcboRepeat()
        End If
        
    End Sub
    Private Function OnDeleteSBACTIDTL(Optional ByVal pv_strIsLocal As String = "", Optional ByVal pv_strModule As String = "") As Int32
        Dim v_strKeyFieldName, v_strKeyFieldValue As String
        Dim v_strClause As String

        Try
            If MsgBox(ResourceManager.GetString("DelConfirm"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                'Update mouse pointer
                Cursor.Current = Cursors.WaitCursor

                If (pv_strIsLocal <> "") And (pv_strModule <> "") Then
                    If Not grvSBACTIDTL.GetFocusedDataRow() Is Nothing Then

                        v_strKeyFieldName = "AUTOID"
                        v_strKeyFieldValue = grvSBACTIDTL.GetFocusedDataRow()("AUTOID")

                        v_strClause = v_strKeyFieldName & " = " & v_strKeyFieldValue

                        Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, pv_strIsLocal, gc_MsgTypeObj, pv_strModule, gc_ActionDelete, , v_strClause, , , , , , , , "FA.SBACTIMST", "  AUTOID = '" & Me.txtAUTOID.Text & "'")
                        Dim v_ws As New BDSDeliveryManagement
                        v_ws.Message(v_strObjMsg)

                        Dim v_strErrorSource, v_strErrorMessage As String
                        Dim v_lngErrorCode As Long

                        GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage)
                        If v_lngErrorCode <> 0 Then
                            'Update mouse pointer
                            Cursor.Current = Cursors.Default
                            MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                            Exit Function
                        End If
                        'remove
                        'grvTAIPO.GetFocusedDataRow.Delete()

                    Else
                        Exit Function
                    End If
                End If
                Cursor.Current = Cursors.Default
                MsgBox(ResourceManager.GetString("DelSuccess"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)

            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function
    Overrides Sub LoadUserInterface(ByRef pv_ctrl As Windows.Forms.Control)
        MyBase.LoadUserInterface(pv_ctrl)
        'Load rieng cho form
        If ExeFlag <> ExecuteFlag.Edit Then
            btnSBACTIDTL_ADD.Enabled = False
            btnSBACTIDTL_EDIT.Enabled = False
            btnSBACTIDTL_DELETE.Enabled = False
            btnSBACTIDTL_CHANGESTATUS.Enabled = False
        End If
        If ExeFlag = ExecuteFlag.AddNew Then
            btnSBACTIDTL_VIEW.Enabled = False
            dtpRESOLVEDT.EditValue = Nothing
        Else
            cboASSIGNID.Enabled = False
            cboSBSTATUS.Enabled = False
            dtpRESOLVEDT.Enabled = False
        End If

        tpSBACTIDTL.Show()
    End Sub
    Public Sub ShowFormSBACTIDTL(ByVal pv_intExecFlag As Integer)
        Dim v_frm As New frmSBACTIDTL(Me)
        Try
            v_frm.ExeFlag = pv_intExecFlag
            v_frm.UserLanguage = UserLanguage
            v_frm.BranchId = BranchId
            v_frm.TellerId = TellerId
            v_frm.TellerRight = TellerRight
            v_frm.GroupCareBy = GroupCareBy
            v_frm.ModuleCode = ModuleCode
            v_frm.ObjectName = "FA.SBACTIDTL"
            v_frm.TableName = "SBACTIDTL"
            v_frm.LocalObject = "N"
            v_frm.BusDate = Me.BusDate
            v_frm.Text = String.Empty
            v_frm.mv_ASSIGN = " "
            v_frm.ParentObjName = Me.ObjectName
            v_frm.ParentClause = KeyFieldName & " = '" & Me.txtAUTOID.Text & "'"
            v_frm.KeyFieldName = "AUTOID"
            v_frm.KeyFieldType = "C"
            v_frm.mv_strAUTID = txtAUTOID.Text
            If Not (pv_intExecFlag = ExecuteFlag.AddNew) Then
                If Not grvSBACTIDTL.GetFocusedRow() Is Nothing Then
                    v_frm.KeyFieldValue = Trim(grvSBACTIDTL.GetFocusedDataRow()("AUTOID"))
                    v_frm.ShowDialog()
                End If
            Else
                v_frm.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_frm.Dispose()
        End Try
    End Sub

    Public Sub ASSIGNFormSBACTIDTL(ByVal pv_intExecFlag As Integer, pv_str As String)
        Dim v_frm As New frmSBACTIDTL(Me)
        Try
            v_frm.ExeFlag = pv_intExecFlag
            v_frm.UserLanguage = UserLanguage
            v_frm.BranchId = BranchId
            v_frm.TellerId = TellerId
            v_frm.TellerRight = TellerRight
            v_frm.GroupCareBy = GroupCareBy
            v_frm.ModuleCode = ModuleCode
            v_frm.ObjectName = "FA.SBACTIDTL"
            v_frm.TableName = "SBACTIDTL"
            v_frm.LocalObject = "N"
            v_frm.BusDate = Me.BusDate
            v_frm.Text = String.Empty
            v_frm.mv_ASSIGN = pv_str
            v_frm.ParentObjName = Me.ObjectName
            v_frm.ParentClause = KeyFieldName & " = '" & Me.txtAUTOID.Text & "'"
            v_frm.KeyFieldName = "AUTOID"
            v_frm.KeyFieldType = "C"
            v_frm.mv_strAUTID = txtAUTOID.Text
            If Not (pv_intExecFlag = ExecuteFlag.AddNew) Then
                If Not grvSBACTIDTL.GetFocusedRow() Is Nothing Then
                    v_frm.KeyFieldValue = Trim(grvSBACTIDTL.GetFocusedDataRow()("AUTOID"))
                    v_frm.mv_REFACTICODE = Trim(grvSBACTIDTL.GetFocusedDataRow()("REFACTICODE"))
                    v_frm.mv_actidtltyp = Trim(grvSBACTIDTL.GetFocusedDataRow()("ACTIDTLTYPVAL"))
                    v_frm.ShowDialog()
                End If
            Else
                v_frm.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_frm.Dispose()
        End Try
    End Sub

    Private Function VerifyRule(Optional ByVal pv_blnSaved As Boolean = False) As Boolean
        Try
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
                            'load lai button neu da bam nut ghi du lieu
                            btnSBACTIDTL_ADD.Enabled = True
                            btnSBACTIDTL_EDIT.Enabled = True
                            btnSBACTIDTL_DELETE.Enabled = True
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

    Private Sub GetKeyForTable()
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_int, v_intCount As Integer
        Dim v_ws As New BDSDeliveryManagement
        Dim v_strFLDNAME, v_strVALUE As String
        Dim v_strID As String

        'Dim strsqlIPO As String = "SELECT SUBSTR('000000',1,6 - LENGTH(NCODEID))||NCODEID CODEID FROM (SELECT (NVL(TO_NUMBER(MAX(FD.CODEID)),0) +1) NCODEID FROM FUND FD) A"
        Dim strsqlIPO As String = "SELECT SEQ_SBACTIMST.Nextval ID from dual "
        Dim v_strObjMsg As String = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, "SA.ALLCODE", gc_ActionInquiry, strsqlIPO)
        v_ws.Message(v_strObjMsg)
        v_xmlDocument.LoadXml(v_strObjMsg)
        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
        If v_nodeList.Count > 0 Then
            For v_intCount = 0 To v_nodeList.Count - 1
                For v_int = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                    With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                        v_strFLDNAME = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("fldname").Value.Trim()
                        v_strVALUE = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("oldval").Value.Trim()

                        Select Case v_strFLDNAME
                            Case "ID"
                                v_strID = v_strVALUE

                        End Select
                    End With
                Next
            Next
        End If
        txtAUTOID.Text = v_strID
    End Sub
    Private Sub InitExternal()
        'Khoi tao grid TAIPO
        InitGridFromSearchCode("SBACTIDTL", Me.gridSBACTIDTL, Me.grvSBACTIDTL, " AND refid = '" & txtAUTOID.Text & "'", "Y", "Y", UserLanguage)
    End Sub
#End Region
    Private Function OnDeleteTAIPO(Optional ByVal pv_strIsLocal As String = "", Optional ByVal pv_strModule As String = "") As Int32
        Dim v_strKeyFieldName, v_strKeyFieldValue As String
        Dim v_strClause As String

        Try
            If MsgBox(ResourceManager.GetString("DelConfirm"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                'Update mouse pointer
                Cursor.Current = Cursors.WaitCursor

                If (pv_strIsLocal <> "") And (pv_strModule <> "") Then
                    If Not grvSBACTIDTL.GetFocusedDataRow() Is Nothing Then

                        v_strKeyFieldName = "IPOID"
                        v_strKeyFieldValue = grvSBACTIDTL.GetFocusedDataRow()("IPOID")

                        v_strClause = v_strKeyFieldName & " = " & v_strKeyFieldValue

                        Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, pv_strIsLocal, gc_MsgTypeObj, pv_strModule, gc_ActionDelete, , v_strClause, , , , , , , , "SA.FUND", "  CODEID = '" & Me.txtAUTOID.Text & "'")
                        Dim v_ws As New BDSDeliveryManagement
                        v_ws.Message(v_strObjMsg)

                        Dim v_strErrorSource, v_strErrorMessage As String
                        Dim v_lngErrorCode As Long

                        GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage)
                        If v_lngErrorCode <> 0 Then
                            'Update mouse pointer
                            Cursor.Current = Cursors.Default
                            MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                            Exit Function
                        End If
                        'remove
                        'grvTAIPO.GetFocusedDataRow.Delete()

                    Else
                        Exit Function
                    End If
                End If
                Cursor.Current = Cursors.Default
                MsgBox(ResourceManager.GetString("DelSuccess"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)

            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function
    
    Private Sub btnSBACTIDTL_ADD_Click(sender As Object, e As EventArgs) Handles btnSBACTIDTL_ADD.Click
        ASSIGNFormSBACTIDTL(ExecuteFlag.AddNew, "C")
    End Sub

    Private Sub btnSBACTIDTL_VIEW_Click(sender As Object, e As EventArgs) Handles btnSBACTIDTL_VIEW.Click
        ASSIGNFormSBACTIDTL(ExecuteFlag.View, "W")
    End Sub

    Private Sub btnSBACTIDTL_EDIT_Click(sender As Object, e As EventArgs) Handles btnSBACTIDTL_EDIT.Click
        ASSIGNFormSBACTIDTL(ExecuteFlag.Edit, "E")
    End Sub

    Private Sub btnSBACTIDTL_ASSIGN_Click(sender As Object, e As EventArgs) Handles btnSBACTIDTL_DELETE.Click
        ASSIGNFormSBACTIDTL(ExecuteFlag.AddNew, "A")
    End Sub

    Private Sub btnSBACTIDTL_CHANGESTATUS_Click(sender As Object, e As EventArgs) Handles btnSBACTIDTL_CHANGESTATUS.Click
        ASSIGNFormSBACTIDTL(ExecuteFlag.AddNew, "M")
    End Sub


    Private Sub txTRADING_ACCOUNT_KeyUp(sender As Object, e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.F5
                Dim frm As New frmXtraSearchLookup(Me.UserLanguage)
                frm.TableName = "CUSTODYCD_CF"
                frm.ModuleCode = "CF"
                frm.KeyFieldType = "C"
                frm.AuthCode = "NNNNYYNNNN" 'Không cho phép thực hiện chức năng nào 
                frm.IsLocalSearch = gc_IsNotLocalMsg
                frm.IsLookup = "Y"
                frm.SearchOnInit = False
                frm.BranchId = "9999"
                frm.TellerId = Me.TellerId
                frm.ShowDialog()
                Me.ActiveControl.Text = Trim(frm.ReturnValue)
                frm.Dispose()

        End Select
    End Sub


    Private Sub cboFREQUENCY_EditValueChanged(sender As Object, e As EventArgs) Handles cboFREQUENCY.EditValueChanged

    End Sub

    Private Sub cboRepeat_EditValueChanged(sender As Object, e As EventArgs) Handles cboRepeat.EditValueChanged
        InitcboRepeat()
    End Sub

    Private Sub InitcboRepeat()
        If cboRepeat.EditValue = "4" Or cboRepeat.EditValue = "6" Then
            lblNumber.Visible = True
            lblNumber.ForeColor = Color.Red
            nNumber.Visible = True
        Else
            lblNumber.Visible = False
            nNumber.Visible = False
        End If
        lblRemindTime.ForeColor = Color.Blue
    End Sub
End Class