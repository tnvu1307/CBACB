Imports AppCore
Imports CommonLibrary

Public Class frmCFCONTACT
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
    Friend WithEvents lblPERSON As System.Windows.Forms.Label
    Friend WithEvents lblTYPE As System.Windows.Forms.Label
    Friend WithEvents lblPHONE As System.Windows.Forms.Label
    Friend WithEvents lblADDRESS As System.Windows.Forms.Label
    Friend WithEvents lblFAX As System.Windows.Forms.Label
    Friend WithEvents lblEMAIL As System.Windows.Forms.Label
    Friend WithEvents lblDESCRIPTION As System.Windows.Forms.Label
    Friend WithEvents cboTYPE As ComboBoxEx
    Friend WithEvents txtPERSON As System.Windows.Forms.TextBox
    Friend WithEvents txtADDRESS As System.Windows.Forms.TextBox
    Friend WithEvents txtPHONE As System.Windows.Forms.TextBox
    Friend WithEvents txtDESCRIPTION As System.Windows.Forms.TextBox
    Friend WithEvents txtFAX As System.Windows.Forms.TextBox
    Friend WithEvents txtEMAIL As System.Windows.Forms.TextBox
    Friend WithEvents txtAUTOID As System.Windows.Forms.TextBox
    Friend WithEvents txtCUSTID As AppCore.FlexMaskEditBox
    Friend WithEvents lblCUSTID As System.Windows.Forms.Label
    Friend WithEvents lblTITLECONTACT As System.Windows.Forms.Label
    Friend WithEvents txtTITLECONTACT As System.Windows.Forms.TextBox
    Friend WithEvents grbCONTACTINFO As System.Windows.Forms.GroupBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCFCONTACT))
        Me.txtCUSTID = New AppCore.FlexMaskEditBox()
        Me.lblCUSTID = New System.Windows.Forms.Label()
        Me.cboTYPE = New AppCore.ComboBoxEx()
        Me.lblPERSON = New System.Windows.Forms.Label()
        Me.lblTYPE = New System.Windows.Forms.Label()
        Me.lblFAX = New System.Windows.Forms.Label()
        Me.lblDESCRIPTION = New System.Windows.Forms.Label()
        Me.lblEMAIL = New System.Windows.Forms.Label()
        Me.lblPHONE = New System.Windows.Forms.Label()
        Me.lblADDRESS = New System.Windows.Forms.Label()
        Me.txtPERSON = New System.Windows.Forms.TextBox()
        Me.txtADDRESS = New System.Windows.Forms.TextBox()
        Me.txtPHONE = New System.Windows.Forms.TextBox()
        Me.txtDESCRIPTION = New System.Windows.Forms.TextBox()
        Me.txtFAX = New System.Windows.Forms.TextBox()
        Me.txtEMAIL = New System.Windows.Forms.TextBox()
        Me.txtAUTOID = New System.Windows.Forms.TextBox()
        Me.grbCONTACTINFO = New System.Windows.Forms.GroupBox()
        Me.lblTITLECONTACT = New System.Windows.Forms.Label()
        Me.txtTITLECONTACT = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.grbCONTACTINFO.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(170, 235)
        Me.btnOK.TabIndex = 1
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(250, 235)
        Me.btnCancel.TabIndex = 2
        '
        'btnApply
        '
        Me.btnApply.Location = New System.Drawing.Point(330, 235)
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(409, 50)
        '
        'cboLink
        '
        '
        'txtCUSTID
        '
        Me.txtCUSTID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCUSTID.Location = New System.Drawing.Point(100, 20)
        Me.txtCUSTID.Name = "txtCUSTID"
        Me.txtCUSTID.Size = New System.Drawing.Size(100, 21)
        Me.txtCUSTID.TabIndex = 0
        Me.txtCUSTID.Tag = "CUSTID"
        Me.txtCUSTID.Text = "txtCUSTID"
        '
        'lblCUSTID
        '
        Me.lblCUSTID.AutoSize = True
        Me.lblCUSTID.Location = New System.Drawing.Point(10, 22)
        Me.lblCUSTID.Name = "lblCUSTID"
        Me.lblCUSTID.Size = New System.Drawing.Size(54, 13)
        Me.lblCUSTID.TabIndex = 13
        Me.lblCUSTID.Tag = "CUSTID"
        Me.lblCUSTID.Text = "lblCUSTID"
        Me.lblCUSTID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboTYPE
        '
        Me.cboTYPE.DisplayMember = "DISPLAY"
        Me.cboTYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTYPE.Location = New System.Drawing.Point(290, 20)
        Me.cboTYPE.Name = "cboTYPE"
        Me.cboTYPE.Size = New System.Drawing.Size(100, 21)
        Me.cboTYPE.TabIndex = 1
        Me.cboTYPE.Tag = "TYPE"
        Me.cboTYPE.ValueMember = "VALUE"
        '
        'lblPERSON
        '
        Me.lblPERSON.AutoSize = True
        Me.lblPERSON.Location = New System.Drawing.Point(10, 47)
        Me.lblPERSON.Name = "lblPERSON"
        Me.lblPERSON.Size = New System.Drawing.Size(57, 13)
        Me.lblPERSON.TabIndex = 15
        Me.lblPERSON.Tag = "PERSON"
        Me.lblPERSON.Text = "lblPERSON"
        Me.lblPERSON.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTYPE
        '
        Me.lblTYPE.AutoSize = True
        Me.lblTYPE.Location = New System.Drawing.Point(210, 22)
        Me.lblTYPE.Name = "lblTYPE"
        Me.lblTYPE.Size = New System.Drawing.Size(41, 13)
        Me.lblTYPE.TabIndex = 16
        Me.lblTYPE.Tag = "TYPE"
        Me.lblTYPE.Text = "lblTYPE"
        Me.lblTYPE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFAX
        '
        Me.lblFAX.AutoSize = True
        Me.lblFAX.Location = New System.Drawing.Point(210, 97)
        Me.lblFAX.Name = "lblFAX"
        Me.lblFAX.Size = New System.Drawing.Size(36, 13)
        Me.lblFAX.TabIndex = 17
        Me.lblFAX.Tag = "FAX"
        Me.lblFAX.Text = "lblFAX"
        Me.lblFAX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDESCRIPTION
        '
        Me.lblDESCRIPTION.AutoSize = True
        Me.lblDESCRIPTION.Location = New System.Drawing.Point(10, 147)
        Me.lblDESCRIPTION.Name = "lblDESCRIPTION"
        Me.lblDESCRIPTION.Size = New System.Drawing.Size(85, 13)
        Me.lblDESCRIPTION.TabIndex = 18
        Me.lblDESCRIPTION.Tag = "DESCRIPTION"
        Me.lblDESCRIPTION.Text = "lblDESCRIPTION"
        Me.lblDESCRIPTION.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEMAIL
        '
        Me.lblEMAIL.AutoSize = True
        Me.lblEMAIL.Location = New System.Drawing.Point(10, 122)
        Me.lblEMAIL.Name = "lblEMAIL"
        Me.lblEMAIL.Size = New System.Drawing.Size(47, 13)
        Me.lblEMAIL.TabIndex = 19
        Me.lblEMAIL.Tag = "EMAIL"
        Me.lblEMAIL.Text = "lblEMAIL"
        Me.lblEMAIL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPHONE
        '
        Me.lblPHONE.AutoSize = True
        Me.lblPHONE.Location = New System.Drawing.Point(10, 97)
        Me.lblPHONE.Name = "lblPHONE"
        Me.lblPHONE.Size = New System.Drawing.Size(51, 13)
        Me.lblPHONE.TabIndex = 20
        Me.lblPHONE.Tag = "PHONE"
        Me.lblPHONE.Text = "lblPHONE"
        Me.lblPHONE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblADDRESS
        '
        Me.lblADDRESS.AutoSize = True
        Me.lblADDRESS.Location = New System.Drawing.Point(10, 72)
        Me.lblADDRESS.Name = "lblADDRESS"
        Me.lblADDRESS.Size = New System.Drawing.Size(63, 13)
        Me.lblADDRESS.TabIndex = 21
        Me.lblADDRESS.Tag = "ADDRESS"
        Me.lblADDRESS.Text = "lblADDRESS"
        Me.lblADDRESS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPERSON
        '
        Me.txtPERSON.Location = New System.Drawing.Point(100, 45)
        Me.txtPERSON.Name = "txtPERSON"
        Me.txtPERSON.Size = New System.Drawing.Size(100, 21)
        Me.txtPERSON.TabIndex = 2
        Me.txtPERSON.Tag = "PERSON"
        Me.txtPERSON.Text = "txtPERSON"
        '
        'txtADDRESS
        '
        Me.txtADDRESS.Location = New System.Drawing.Point(100, 70)
        Me.txtADDRESS.Name = "txtADDRESS"
        Me.txtADDRESS.Size = New System.Drawing.Size(290, 21)
        Me.txtADDRESS.TabIndex = 3
        Me.txtADDRESS.Tag = "ADDRESS"
        Me.txtADDRESS.Text = "txtADDRESS"
        '
        'txtPHONE
        '
        Me.txtPHONE.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPHONE.Location = New System.Drawing.Point(100, 95)
        Me.txtPHONE.Name = "txtPHONE"
        Me.txtPHONE.Size = New System.Drawing.Size(100, 21)
        Me.txtPHONE.TabIndex = 4
        Me.txtPHONE.Tag = "PHONE"
        Me.txtPHONE.Text = "txtPHONE"
        '
        'txtDESCRIPTION
        '
        Me.txtDESCRIPTION.Location = New System.Drawing.Point(100, 145)
        Me.txtDESCRIPTION.Name = "txtDESCRIPTION"
        Me.txtDESCRIPTION.Size = New System.Drawing.Size(290, 21)
        Me.txtDESCRIPTION.TabIndex = 7
        Me.txtDESCRIPTION.Tag = "DESCRIPTION"
        Me.txtDESCRIPTION.Text = "txtDESCRIPTION"
        '
        'txtFAX
        '
        Me.txtFAX.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFAX.Location = New System.Drawing.Point(290, 95)
        Me.txtFAX.Name = "txtFAX"
        Me.txtFAX.Size = New System.Drawing.Size(100, 21)
        Me.txtFAX.TabIndex = 5
        Me.txtFAX.Tag = "FAX"
        Me.txtFAX.Text = "txtFAX"
        '
        'txtEMAIL
        '
        Me.txtEMAIL.Location = New System.Drawing.Point(100, 120)
        Me.txtEMAIL.Name = "txtEMAIL"
        Me.txtEMAIL.Size = New System.Drawing.Size(290, 21)
        Me.txtEMAIL.TabIndex = 6
        Me.txtEMAIL.Tag = "EMAIL"
        Me.txtEMAIL.Text = "txtEMAIL"
        '
        'txtAUTOID
        '
        Me.txtAUTOID.Location = New System.Drawing.Point(20, 235)
        Me.txtAUTOID.Name = "txtAUTOID"
        Me.txtAUTOID.Size = New System.Drawing.Size(100, 21)
        Me.txtAUTOID.TabIndex = 28
        Me.txtAUTOID.Tag = "AUTOID"
        Me.txtAUTOID.Text = "txtAUTOID"
        '
        'grbCONTACTINFO
        '
        Me.grbCONTACTINFO.Controls.Add(Me.txtTITLECONTACT)
        Me.grbCONTACTINFO.Controls.Add(Me.lblTITLECONTACT)
        Me.grbCONTACTINFO.Controls.Add(Me.cboTYPE)
        Me.grbCONTACTINFO.Controls.Add(Me.lblTYPE)
        Me.grbCONTACTINFO.Controls.Add(Me.txtFAX)
        Me.grbCONTACTINFO.Controls.Add(Me.lblFAX)
        Me.grbCONTACTINFO.Controls.Add(Me.txtCUSTID)
        Me.grbCONTACTINFO.Controls.Add(Me.lblCUSTID)
        Me.grbCONTACTINFO.Controls.Add(Me.txtDESCRIPTION)
        Me.grbCONTACTINFO.Controls.Add(Me.lblDESCRIPTION)
        Me.grbCONTACTINFO.Controls.Add(Me.txtEMAIL)
        Me.grbCONTACTINFO.Controls.Add(Me.lblEMAIL)
        Me.grbCONTACTINFO.Controls.Add(Me.lblPHONE)
        Me.grbCONTACTINFO.Controls.Add(Me.lblADDRESS)
        Me.grbCONTACTINFO.Controls.Add(Me.txtPERSON)
        Me.grbCONTACTINFO.Controls.Add(Me.txtADDRESS)
        Me.grbCONTACTINFO.Controls.Add(Me.lblPERSON)
        Me.grbCONTACTINFO.Controls.Add(Me.txtPHONE)
        Me.grbCONTACTINFO.Location = New System.Drawing.Point(5, 55)
        Me.grbCONTACTINFO.Name = "grbCONTACTINFO"
        Me.grbCONTACTINFO.Size = New System.Drawing.Size(400, 175)
        Me.grbCONTACTINFO.TabIndex = 0
        Me.grbCONTACTINFO.TabStop = False
        Me.grbCONTACTINFO.Tag = "CONTACTINFO"
        Me.grbCONTACTINFO.Text = "grbCONTACTINFO"
        '
        'lblTITLECONTACT
        '
        Me.lblTITLECONTACT.AutoSize = True
        Me.lblTITLECONTACT.Location = New System.Drawing.Point(210, 47)
        Me.lblTITLECONTACT.Name = "lblTITLECONTACT"
        Me.lblTITLECONTACT.Size = New System.Drawing.Size(38, 13)
        Me.lblTITLECONTACT.TabIndex = 22
        Me.lblTITLECONTACT.Tag = "TITLECONTACT"
        Me.lblTITLECONTACT.Text = "Label1"
        Me.lblTITLECONTACT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTITLECONTACT
        '
        Me.txtTITLECONTACT.Location = New System.Drawing.Point(254, 45)
        Me.txtTITLECONTACT.Name = "txtTITLECONTACT"
        Me.txtTITLECONTACT.Size = New System.Drawing.Size(136, 21)
        Me.txtTITLECONTACT.TabIndex = 23
        Me.txtTITLECONTACT.Tag = "TITLECONTACT"
        Me.txtTITLECONTACT.Text = "TextBox1"
        '
        'frmCFCONTACT
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(409, 260)
        Me.Controls.Add(Me.grbCONTACTINFO)
        Me.Controls.Add(Me.txtAUTOID)
        Me.Name = "frmCFCONTACT"
        Me.Text = ""
        Me.Controls.SetChildIndex(Me.cboLink, 0)
        Me.Controls.SetChildIndex(Me.btnApprv, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.btnApply, 0)
        Me.Controls.SetChildIndex(Me.txtAUTOID, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.grbCONTACTINFO, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.grbCONTACTINFO.ResumeLayout(False)
        Me.grbCONTACTINFO.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region " Declare constants and variables "
    Private mv_CustomerId As String

#End Region

#Region " Properties "
    Public Property CustomerId() As String
        Get
            Return mv_CustomerId
        End Get
        Set(ByVal Value As String)
            mv_CustomerId = Value
        End Set
    End Property

#End Region

#Region " Overrides Methods "
    Public Overrides Sub OnInit()
        Dim v_ctrl As Windows.Forms.Control

        Try
            MyBase.OnInit()

            'Load Resource Manager
            ResourceManager = New Resources.ResourceManager(gc_RootNamespace & "." & Me.Name & "-" & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
            LoadUserInterface(Me)
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ResourceManager.GetString("InitDialogFailed"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
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

            Select Case ExeFlag
                Case ExecuteFlag.AddNew
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionAdd, , , , gc_AutoIdUsed, , , , , , ParentObjName, ParentClause)
                    BuildXMLObjData(mv_dsInput, v_strObjMsg)

                    Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                    Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)

                    'Kiểm tra thông tin và xử lý lỗi (nếu có) từ message trả về
                    Dim v_strErrorSource, v_strErrorMessage As String                    

                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                    If v_lngErrorCode <> 0 Then
                        'Update mouse pointer
                        Cursor.Current = Cursors.Default
                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Exit Sub
                    End If

                    MsgBox(ResourceManager.GetString("AddnewSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    Me.DialogResult = DialogResult.OK
                    MyBase.OnClose()
                Case ExecuteFlag.Edit
                    Dim v_strClause As String

                    Select Case KeyFieldType
                        Case "C"
                            v_strClause = KeyFieldName & " = '" & KeyFieldValue & "'"
                        Case "D"
                            v_strClause = KeyFieldName & " = TO_DATE('" & KeyFieldValue & "', '" & gc_FORMAT_DATE & "')"
                        Case "N"
                            v_strClause = KeyFieldName & " = " & KeyFieldValue.ToString()
                    End Select

                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionEdit, , v_strClause, , , , , , , , ParentObjName, ParentClause)
                    BuildXMLObjData(mv_dsInput, v_strObjMsg, mv_dsOldInput, ExecuteFlag.Edit)

                    Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                    Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)

                    'Kiểm tra thông tin và xử lý lỗi (nếu có) từ message trả về
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
            End Select

            'Update mouse pointer
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ResourceManager.GetString("SavingFailed"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
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

        'Sửa chỗ này cho từng form maintenance khác nhau
        If (ExeFlag = ExecuteFlag.AddNew) Then
            txtCUSTID.Text = CustomerId
            txtCUSTID.Enabled = False
        ElseIf (ExeFlag = ExecuteFlag.Edit) Then
            txtCUSTID.Text = CustomerId
            txtCUSTID.Enabled = False
        End If
    End Sub

    
#End Region

#Region " Control validations "
    Private Function ControlValidation(Optional ByVal pv_blnSaved As Boolean = False) As Boolean
        Try
            If pv_blnSaved Then
                Return MyBase.VerifyRules()
            End If

            Return True
        Catch ex As Exception
            Throw ex
            Return False
        End Try
    End Function
#End Region


End Class
