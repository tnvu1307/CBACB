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
Imports log4net
Public Class frmSBACTIDTL
    Inherits AppCore.frmXtraMaintenance
#Region "Declare constants and variables"
    Public mv_strAUTID As String
    Private mv_arrImageUpload() As ImageUpload
    Private mv_CurrImageUpload As ImageUpload
    Private mv_srcFileName As String
    Public mv_ASSIGN As String
    Public mv_REFACTICODE As String
    Public mv_actidtltyp As String

    Public frm_SBACTIMST As frmSBACTIMST

#End Region

#Region "private sub"
    Public Sub New(ByVal frm As frmSBACTIMST)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.frm_SBACTIMST = frm
    End Sub


    Public Overrides Sub OnInit()
        ResourceManager = New Resources.ResourceManager(gc_RootNamespace & "." & Me.Name & "-" & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        LocalObject = gc_IsNotLocalMsg
        MyBase.OnInit()
        LoadUserInterface(Me)
        FormInit()
        InitExternal()
    End Sub

    Overrides Sub LoadUserInterface(ByRef pv_ctrl As Windows.Forms.Control)
        MyBase.LoadUserInterface(pv_ctrl)
        'Load rieng cho form
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
    Private Sub load_assign()
        Dim v_strSQL As String
        Dim v_ds As New DataSet
        Dim v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement 'Dim v_ws As New BDSDelivery.BDSDelivery
        v_strSQL = "SELECT tlid  VALUECD, tlid VALUE, tlname DISPLAY,tlname EN_DISPLAY,tlname DESCRIPTION FROM tlprofiles UNION SELECT '---'  VALUECD, '---' VALUE, '---' DISPLAY, '---' EN_DISPLAY, '---' DESCRIPTION FROM tlprofiles"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQL)
        v_ws.Message(v_strObjMsg)
        FillXtraLookUpEdit(v_strObjMsg, cboASSIGNID)
    End Sub
    Private Sub load_status()
        Dim v_strSQL As String
        Dim v_ds As New DataSet
        Dim v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement 'Dim v_ws As New BDSDelivery.BDSDelivery
        v_strSQL = "SELECT cdval  VALUECD,cdval VALUE, cdcontent DISPLAY, en_cdcontent EN_DISPLAY, cdcontent DESCRIPTION FROM ALLCODE  WHERE CDNAME='SBSTATUS' AND CDTYPE='SB'"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQL)
        v_ws.Message(v_strObjMsg)
        FillXtraLookUpEdit(v_strObjMsg, cboASSIGNID)
    End Sub
    Private Sub FormInit()
        Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode
        Dim v_strValue, v_strFLDNAME As String

        lblRESOLVEDT.Visible = False
        dtpRESOLVEDT.Visible = False

        ' assign
        If mv_ASSIGN = "A" Then
            load_assign()
            cboACTIDTLTYP.Enabled = False
            cboACTIDTLTYP.EditValue = "A"
            lblASSIGNID.ForeColor = Color.Red
            lblASSIGNID.Text = "Assignee"
        End If
        ' comment
        If mv_ASSIGN = "C" Then
            cboACTIDTLTYP.Enabled = False
            cboACTIDTLTYP.EditValue = "C"
            lblASSIGNID.Visible = False
            cboASSIGNID.Visible = False
        End If
        ' change status
        If mv_ASSIGN = "M" Then
            load_status()
            cboACTIDTLTYP.Enabled = False
            cboACTIDTLTYP.EditValue = "M"
            lblASSIGNID.ForeColor = Color.Red
            lblASSIGNID.Text = "Change status"
            lblRESOLVEDT.Visible = True
            dtpRESOLVEDT.Visible = True
        End If
        ' sua
        If (mv_ASSIGN = "E" Or mv_ASSIGN = "W") Then
            If mv_actidtltyp = "A" Then ' assign
                load_assign()
                lblASSIGNID.ForeColor = Color.Red
                lblASSIGNID.Text = "Assignee"
                cboASSIGNID.EditValue = mv_REFACTICODE
                If mv_ASSIGN = "W" Then
                    cboASSIGNID.Enabled = False
                End If
            End If

            If mv_actidtltyp = "M" Then ' change status
                load_status()
                lblASSIGNID.ForeColor = Color.Red
                lblASSIGNID.Text = "Change status"
                cboASSIGNID.EditValue = mv_REFACTICODE
                lblRESOLVEDT.Visible = True
                dtpRESOLVEDT.Visible = True
                If mv_ASSIGN = "W" Then
                    cboASSIGNID.Enabled = False
                    dtpRESOLVEDT.Enabled = False
                    dtpRESOLVEDT.Enabled = False
                End If
            End If
            If mv_actidtltyp <> "A" And mv_actidtltyp <> "M" Then
                cboASSIGNID.Visible = False
                lblASSIGNID.Visible = False
            End If
        Else
            dtpRESOLVEDT.EditValue = Nothing
        End If
        txtREFID.Text = mv_strAUTID
        If ExeFlag = ExecuteFlag.AddNew Then
            GetAUTOID()
        End If
    End Sub

    Private Sub GetAUTOID()
        Dim v_ws As New BDSDeliveryManagement
        Dim v_strSQL As String = "SELECT SEQ_SBACTIDTL.NEXTVAL ID from DUAL"
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

    Public Sub InitExternal()
        InitGridFromSearchCode("SBACTIFILE", Me.gridSBACTIFILE, Me.grvSBACTIFILE, " AND refid = '" & txtAUTOID.Text & "'", "Y", "Y", UserLanguage)
    End Sub


    Public Overrides Sub OnSave()
        Dim v_strObjMsg As String
        txtREFACTICODE.Text = cboASSIGNID.EditValue
        Try
            'Update mouse pointer
            Cursor.Current = Cursors.WaitCursor
            'Verify Data
            If (VerifyRule() = False) Then
                Exit Sub
            End If

            MyBase.OnSave()
            If Not DoDataExchange(True) Then
                Exit Sub
            End If

            Select Case ExeFlag
                Case ExecuteFlag.AddNew
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionAdd, , " AUTOID = '" & Me.txtAUTOID.Text & "'", , gc_AutoIdUnused, , , , , , "FA.SBACTIMST", " AUTOID = '" & Me.txtREFID.Text & "'")
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
                            mv_dsOldInput = mv_dsInput
                        Case SaveButtonType.OKButton
                            Me.DialogResult = DialogResult.OK
                            'MyBase.OnClose()
                    End Select
                Case ExecuteFlag.Edit

                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionEdit, , " AUTOID = '" & Me.txtAUTOID.Text & "'", , , , , , , , "FA.SBACTIMST", " AUTOID = '" & Me.txtREFID.Text & "'")
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
            frm_SBACTIMST.OnInit()
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ResourceManager.GetString("SavingFailed"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub


#End Region

#Region "event"

#End Region
    Private Sub btnSBACTIFILE_ADD_Click(sender As Object, e As EventArgs) Handles btnSBACTIFILE_ADD.Click
        ShowFormSBACTIFILE(ExecuteFlag.AddNew)
        RefeshData()
    End Sub

    Public Sub ShowFormSBACTIFILE(ByVal pv_intExecFlag As Integer)
        Dim v_frm As New frmSBACTIFILE(Me)
        Try
            v_frm.ExeFlag = pv_intExecFlag
            v_frm.UserLanguage = UserLanguage
            v_frm.BranchId = BranchId
            v_frm.TellerId = TellerId
            v_frm.TellerRight = TellerRight
            v_frm.GroupCareBy = GroupCareBy
            v_frm.ModuleCode = ModuleCode
            v_frm.ObjectName = "FA.SBACTIFILE"
            v_frm.TableName = "SBACTIFILE"
            v_frm.LocalObject = "N"
            v_frm.BusDate = Me.BusDate
            v_frm.Text = String.Empty
            v_frm.ParentObjName = Me.ObjectName
            v_frm.ParentClause = KeyFieldName & " = '" & Me.txtAUTOID.Text & "'"
            v_frm.KeyFieldName = "AUTOID"
            v_frm.KeyFieldType = "C"
            v_frm.mv_strAUTID = txtAUTOID.Text
            v_frm.mv_strREFID = txtREFID.Text
            If Not (pv_intExecFlag = ExecuteFlag.AddNew) Then
                If Not grvSBACTIFILE.GetFocusedRow() Is Nothing Then
                    v_frm.KeyFieldValue = grvSBACTIFILE.GetFocusedDataRow()("AUTOID")
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
    Private Function OnDeletefile(Optional ByVal pv_strIsLocal As String = "", Optional ByVal pv_strModule As String = "") As Int32
        Dim v_strKeyFieldName, v_strKeyFieldValue As String
        Dim v_strClause As String

        Try
            If MsgBox(ResourceManager.GetString("DelConfirm"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                'Update mouse pointer
                Cursor.Current = Cursors.WaitCursor

                If (pv_strIsLocal <> "") And (pv_strModule <> "") Then
                    If Not grvSBACTIFILE.GetFocusedRow() Is Nothing Then

                        v_strKeyFieldName = "AUTOID"
                        v_strKeyFieldValue = grvSBACTIFILE.GetFocusedDataRow()("AUTOID")

                        v_strClause = v_strKeyFieldName & " = " & v_strKeyFieldValue

                        Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, pv_strIsLocal, gc_MsgTypeObj, pv_strModule, gc_ActionDelete, , v_strClause, , , , , , , , "FA.SBACTIFILE", "")
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
                        'grvFMEMBERS.GetFocusedDataRow.Delete()

                    Else
                        Exit Function
                    End If
                End If
                Cursor.Current = Cursors.Default
                MsgBox(ResourceManager.GetString("DelSuccess"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)

                Dim dt As DataTable = CType(gridSBACTIFILE.DataSource, DataTable)
                Dim currentRow As DataRow = CType(grvSBACTIFILE.GetFocusedDataRow(), DataRow)
                If dt IsNot Nothing Then
                    dt.Rows.Remove(currentRow)
                    gridSBACTIFILE.RefreshDataSource()
                End If
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function
    Private Sub btnSBACTIFILE_DELETE_Click(sender As Object, e As EventArgs) Handles btnSBACTIFILE_DELETE.Click
        OnDeletefile("N", "FA.SBACTIFILE")
        RefeshData()
    End Sub

    Private Sub btnSBACTIFILE_VIEW_Click(sender As Object, e As EventArgs) Handles btnSBACTIFILE_VIEW.Click
        ShowFormSBACTIFILE(ExecuteFlag.View)
    End Sub

  

    Private Sub gridSBACTIFILE_DoubleClick(sender As Object, e As EventArgs) Handles gridSBACTIFILE.DoubleClick
        ShowFormSBACTIFILE(ExecuteFlag.View)
    End Sub

    Public Function RefeshData()
        InitGridFromSearchCode("SBACTIFILE", Me.gridSBACTIFILE, Me.grvSBACTIFILE, " AND refid = '" & txtAUTOID.Text & "'", "Y", "Y", UserLanguage)
    End Function

    Private Sub btnSBACTIFILE_EDIT_Click(sender As Object, e As EventArgs) Handles btnSBACTIFILE_EDIT.Click
        ShowFormSBACTIFILE(ExecuteFlag.Edit)
        RefeshData()
    End Sub
End Class