Imports CommonLibrary
Imports AppCore

Public Class frmRMRecChangeRequest
    Inherits AppCore.frmMaintenance

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents lblNOTES As System.Windows.Forms.Label
    Friend WithEvents grbRMChangeReq As System.Windows.Forms.GroupBox
    Friend WithEvents txtKEYACCT1 As System.Windows.Forms.TextBox
    Friend WithEvents txtKEYACCT2 As System.Windows.Forms.TextBox
    Friend WithEvents lblKEYACCT2 As System.Windows.Forms.Label
    Friend WithEvents lblKEYACCT1 As System.Windows.Forms.Label
    Friend WithEvents cboSTATUS As AppCore.ComboBoxEx
    Friend WithEvents lblSTATUS As System.Windows.Forms.Label
    Friend WithEvents txtNOTES As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRMRecChangeRequest))
        Me.grbRMChangeReq = New System.Windows.Forms.GroupBox
        Me.lblSTATUS = New System.Windows.Forms.Label
        Me.cboSTATUS = New AppCore.ComboBoxEx
        Me.txtNOTES = New System.Windows.Forms.TextBox
        Me.txtKEYACCT1 = New System.Windows.Forms.TextBox
        Me.txtKEYACCT2 = New System.Windows.Forms.TextBox
        Me.lblKEYACCT2 = New System.Windows.Forms.Label
        Me.lblKEYACCT1 = New System.Windows.Forms.Label
        Me.lblNOTES = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.grbRMChangeReq.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(270, 214)
        Me.btnOK.Size = New System.Drawing.Size(75, 24)
        Me.btnOK.TabIndex = 1
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(350, 214)
        Me.btnCancel.Size = New System.Drawing.Size(75, 24)
        Me.btnCancel.TabIndex = 2
        '
        'lblCaption
        '
        Me.lblCaption.Location = New System.Drawing.Point(7, 17)
        '
        'btnApply
        '
        Me.btnApply.Location = New System.Drawing.Point(430, 214)
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(515, 50)
        '
        'cboLink
        '
        Me.cboLink.Location = New System.Drawing.Point(37, 477)
        Me.cboLink.Size = New System.Drawing.Size(216, 21)
        '
        'grbRMChangeReq
        '
        Me.grbRMChangeReq.Controls.Add(Me.lblSTATUS)
        Me.grbRMChangeReq.Controls.Add(Me.cboSTATUS)
        Me.grbRMChangeReq.Controls.Add(Me.txtNOTES)
        Me.grbRMChangeReq.Controls.Add(Me.txtKEYACCT1)
        Me.grbRMChangeReq.Controls.Add(Me.txtKEYACCT2)
        Me.grbRMChangeReq.Controls.Add(Me.lblKEYACCT2)
        Me.grbRMChangeReq.Controls.Add(Me.lblKEYACCT1)
        Me.grbRMChangeReq.Controls.Add(Me.lblNOTES)
        Me.grbRMChangeReq.Location = New System.Drawing.Point(8, 60)
        Me.grbRMChangeReq.Name = "grbRMChangeReq"
        Me.grbRMChangeReq.Size = New System.Drawing.Size(497, 148)
        Me.grbRMChangeReq.TabIndex = 0
        Me.grbRMChangeReq.TabStop = False
        Me.grbRMChangeReq.Tag = "grbRMChangeReq"
        Me.grbRMChangeReq.Text = "grbRMChangeReq"
        '
        'lblSTATUS
        '
        Me.lblSTATUS.Location = New System.Drawing.Point(3, 83)
        Me.lblSTATUS.Name = "lblSTATUS"
        Me.lblSTATUS.Size = New System.Drawing.Size(108, 21)
        Me.lblSTATUS.TabIndex = 42
        Me.lblSTATUS.Tag = "STATUS"
        Me.lblSTATUS.Text = "lblSTATUS"
        '
        'cboSTATUS
        '
        Me.cboSTATUS.DisplayMember = "DISPLAY"
        Me.cboSTATUS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSTATUS.FormattingEnabled = True
        Me.cboSTATUS.Location = New System.Drawing.Point(113, 83)
        Me.cboSTATUS.Name = "cboSTATUS"
        Me.cboSTATUS.Size = New System.Drawing.Size(90, 21)
        Me.cboSTATUS.TabIndex = 41
        Me.cboSTATUS.Tag = "STATUS"
        Me.cboSTATUS.ValueMember = "VALUE"
        '
        'txtNOTES
        '
        Me.txtNOTES.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNOTES.Location = New System.Drawing.Point(113, 112)
        Me.txtNOTES.Name = "txtNOTES"
        Me.txtNOTES.Size = New System.Drawing.Size(370, 21)
        Me.txtNOTES.TabIndex = 40
        Me.txtNOTES.Tag = "TRANSACTIONDESCRIPTION"
        Me.txtNOTES.Text = "txtNOTES"
        '
        'txtKEYACCT1
        '
        Me.txtKEYACCT1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtKEYACCT1.Location = New System.Drawing.Point(113, 22)
        Me.txtKEYACCT1.Name = "txtKEYACCT1"
        Me.txtKEYACCT1.Size = New System.Drawing.Size(370, 21)
        Me.txtKEYACCT1.TabIndex = 8
        Me.txtKEYACCT1.Tag = "KEYACCT1"
        Me.txtKEYACCT1.Text = "txtKEYACCT1"
        '
        'txtKEYACCT2
        '
        Me.txtKEYACCT2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtKEYACCT2.Location = New System.Drawing.Point(113, 53)
        Me.txtKEYACCT2.Name = "txtKEYACCT2"
        Me.txtKEYACCT2.Size = New System.Drawing.Size(370, 21)
        Me.txtKEYACCT2.TabIndex = 9
        Me.txtKEYACCT2.Tag = "KEYACCT2"
        Me.txtKEYACCT2.Text = "txtKEYACCT2"
        '
        'lblKEYACCT2
        '
        Me.lblKEYACCT2.Location = New System.Drawing.Point(3, 53)
        Me.lblKEYACCT2.Name = "lblKEYACCT2"
        Me.lblKEYACCT2.Size = New System.Drawing.Size(108, 21)
        Me.lblKEYACCT2.TabIndex = 11
        Me.lblKEYACCT2.Tag = "KEYACCT2"
        Me.lblKEYACCT2.Text = "lblKEYACCT2"
        '
        'lblKEYACCT1
        '
        Me.lblKEYACCT1.Location = New System.Drawing.Point(3, 22)
        Me.lblKEYACCT1.Name = "lblKEYACCT1"
        Me.lblKEYACCT1.Size = New System.Drawing.Size(108, 21)
        Me.lblKEYACCT1.TabIndex = 10
        Me.lblKEYACCT1.Tag = "KEYACCT1"
        Me.lblKEYACCT1.Text = "lblKEYACCT1"
        '
        'lblNOTES
        '
        Me.lblNOTES.Location = New System.Drawing.Point(3, 114)
        Me.lblNOTES.Name = "lblNOTES"
        Me.lblNOTES.Size = New System.Drawing.Size(108, 21)
        Me.lblNOTES.TabIndex = 3
        Me.lblNOTES.Tag = "TRANSACTIONDESCRIPTION"
        Me.lblNOTES.Text = "lblNOTES"
        '
        'frmRMRecChangeRequest
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(515, 246)
        Me.Controls.Add(Me.grbRMChangeReq)
        Me.Name = "frmRMRecChangeRequest"
        Me.Tag = "frmRMRecChangeRequest"
        Me.Text = ""
        Me.Controls.SetChildIndex(Me.cboLink, 0)
        Me.Controls.SetChildIndex(Me.btnApprv, 0)
        Me.Controls.SetChildIndex(Me.btnApply, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.grbRMChangeReq, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.grbRMChangeReq.ResumeLayout(False)
        Me.grbRMChangeReq.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Declare constants and variables "
    Private mv_ReqID As String
    Private mv_EditInfo As Boolean
    Public mv_CustomerName As String
#End Region

#Region " Properties "
    Public Property ReqID() As String
        Get
            Return mv_ReqID
        End Get
        Set(ByVal Value As String)
            mv_ReqID = Value
        End Set
    End Property

    Public Property EditInfo() As Boolean
        Get
            Return mv_EditInfo
        End Get
        Set(ByVal Value As Boolean)
            mv_EditInfo = Value
        End Set
    End Property

#End Region

#Region "Private method"



#End Region

#Region " Overrides Methods "
    Public Overrides Sub OnInit()
        Dim v_ctrl As Windows.Forms.Control

        Try
            MyBase.OnInit()

            ResourceManager = New Resources.ResourceManager(gc_RootNamespace & "." & Me.Name & "-" & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
            LoadUserInterface(Me)
            LoadRequestInfo()

            'btnApply.Visible = True
            'btnApply.Enabled = True
            'btnOK.Visible = True
            'btnOK.Enabled = True

            If mv_EditInfo = False Then
                txtKEYACCT1.Enabled = False
                txtKEYACCT2.Enabled = False
                txtNOTES.Enabled = False
            Else
                cboSTATUS.Enabled = False
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ResourceManager.GetString("InitDialogFailed"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Public Overrides Sub OnSave()
        Dim v_strObjMsg As String

        Try
            'Update mouse pointer
            Cursor.Current = Cursors.WaitCursor

            MyBase.OnSave()
            If Not DoDataExchange(True) Then
                Exit Sub
            End If


            Dim v_strClause As String

            v_strClause = "AUTOID = " & mv_ReqID


            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionEdit, , v_strClause, , , , , , , , ParentObjName, ParentClause)
            BuildXMLObjData(mv_dsInput, v_strObjMsg, mv_dsOldInput, ExecuteFlag.Edit)


            Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
            Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)

            'Ki?m tra thông tin và x? lý l?i (n?u có) t? message tr? v?
            Dim v_strErrorSource, v_strErrorMessage As String

            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
            If v_lngErrorCode <> 0 Then
                'Update mouse pointer
                Cursor.Current = Cursors.Default
                MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                Exit Sub
            End If

            MsgBox(ResourceManager.GetString("EditSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            Me.DialogResult = DialogResult.OK
            MyBase.OnClose()

            'Update mouse pointer
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ResourceManager.GetString("SavingFailed"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Public Overrides Function DoDataExchange(Optional ByVal pv_blnSaved As Boolean = False) As Boolean
        Try
            If Not ControlValidation(pv_blnSaved) Then
                Return False
            End If

            Return MyBase.DoDataExchange(pv_blnSaved)
        Catch ex As Exception
            Throw ex
            Return False
        End Try
    End Function

    Overrides Sub LoadUserInterface(ByRef pv_ctrl As Windows.Forms.Control)
        MyBase.LoadUserInterface(pv_ctrl)

    End Sub
#End Region

#Region " Control validations "
    Private Function ControlValidation(Optional ByVal pv_blnSaved As Boolean = False) As Boolean

        Try
            If pv_blnSaved Then
                Return MyBase.VerifyRules

            End If

            Return True
        Catch ex As Exception
            Throw ex
            Return False
        End Try
    End Function
#End Region

    Public Sub LoadRequestInfo()
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_strObjMsg As String
        Dim v_strSQL As String
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_wa As New BDSDeliveryManagement
        Dim v_strFLDNAME, v_strVALUE As String
        Dim v_strCDCONTENT, v_strCCUSTID As String
        Dim v_int, v_intCount As Integer
        Dim v_lngError As Long = ERR_SYSTEM_OK

        v_strSQL = "SELECT * FROM CRBBANKREQUEST WHERE AUTOID = '" & Me.mv_ReqID & "'"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, "N", gc_MsgTypeObj, "CF.AUTOID", gc_ActionInquiry, v_strSQL)
        v_wa.Message(v_strObjMsg)
        v_xmlDocument.LoadXml(v_strObjMsg)
        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
        For v_intCount = 0 To v_nodeList.Count - 1
            For v_int = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                    v_strFLDNAME = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("fldname").Value.Trim()
                    v_strVALUE = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("oldval").Value.Trim()

                    Select Case v_strFLDNAME
                        Case "KEYACCT1"
                            txtKEYACCT1.Text = v_strVALUE
                        Case "KEYACCT2"
                            txtKEYACCT2.Text = v_strVALUE
                        Case "NOTES"
                            txtNOTES.Text = v_strVALUE
                        Case "STATUS"
                            cboSTATUS.SelectedValue = v_strVALUE
                    End Select
                End With
            Next
        Next



    End Sub


    Private Sub frmRMRecChangeRequest_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Dim v_intPos As Int16, ctl As Control, strFLDNAME As String, v_intIndex As Integer
        Select Case e.KeyCode
            Case Keys.Escape
                OnClose()
                'Case Keys.F5
                '    If Me.ActiveControl.Name = "mskBANKCODE" Then
                '        Dim frm As New frmSearch(Me.UserLanguage)
                '        frm.TableName = "CRBBANKTRFLIST"
                '        frm.ModuleCode = "CF"
                '        frm.AuthCode = "NNNNYYNNNN" 'Không cho phép thực hiện chức năng nào 
                '        frm.IsLocalSearch = gc_IsNotLocalMsg
                '        frm.IsLookup = "Y"
                '        frm.SearchOnInit = False
                '        frm.BranchId = Me.BranchId
                '        frm.TellerId = Me.TellerId
                '        frm.ShowDialog()
                '        If Trim(frm.ReturnValue).Length > 0 Then
                '            Me.ActiveControl.Text = Trim(frm.ReturnValue)
                '            getInfoByBankCode(frm.ReturnValue)
                '        End If
                '        frm.Dispose()

                '    End If
        End Select
    End Sub

    'Public Sub getInfoByBankCode(ByVal strBankCode As String)
    '    Dim v_xmlDocument As New Xml.XmlDocument
    '    Dim v_strObjMsg As String
    '    Dim v_strSQL As String
    '    Dim v_nodeList As Xml.XmlNodeList
    '    Dim v_wa As New BDSDeliveryManagement
    '    Dim v_strFLDNAME, v_strVALUE As String
    '    Dim v_strCDCONTENT, v_strCCUSTID As String
    '    Dim v_int, v_intCount As Integer
    '    Dim v_lngError As Long = ERR_SYSTEM_OK

    '    'Kiem tra dinh dang Email phai hop le
    '    v_strSQL = "SELECT * FROM CRBBANKTRFLIST " & _
    '               " WHERE BANKCODE = '" & strBankCode & "'"
    '    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId , "N", gc_MsgTypeObj, "CF.AUTOID", gc_ActionInquiry, v_strSQL)
    '    v_wa.Message(v_strObjMsg)
    '    v_xmlDocument.LoadXml(v_strObjMsg)
    '    v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
    '    For v_intCount = 0 To v_nodeList.Count - 1
    '        For v_int = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
    '            With v_nodeList.Item(v_intCount).ChildNodes(v_int)
    '                v_strFLDNAME = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("fldname").Value.Trim()
    '                v_strVALUE = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("oldval").Value.Trim()

    '                Select Case v_strFLDNAME
    '                    Case "BANKNAME"
    '                        txtBANKNAME.Text = v_strVALUE
    '                    Case "CITY"
    '                        txtBANKCITY.Text = v_strVALUE

    '                End Select
    '            End With
    '        Next
    '    Next



    'End Sub

End Class

