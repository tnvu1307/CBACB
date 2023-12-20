Imports CommonLibrary
Imports AppCore
    Public Class frmDEPOSIT_MEMBER
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
    Friend WithEvents txtSHORTNAME As System.Windows.Forms.TextBox
    Friend WithEvents lblSHORTNAME As System.Windows.Forms.Label
    Friend WithEvents txtFULLNAME As System.Windows.Forms.TextBox
    Friend WithEvents lblFULLNAME As System.Windows.Forms.Label
    Friend WithEvents lblOFFICENAME As System.Windows.Forms.Label
    Friend WithEvents txtOFFICENAME As System.Windows.Forms.TextBox
    Friend WithEvents lblADDRESS As System.Windows.Forms.Label
    Friend WithEvents txtADDRESS As System.Windows.Forms.TextBox
    Friend WithEvents lblPHONE As System.Windows.Forms.Label
    Friend WithEvents txtPHONE As System.Windows.Forms.TextBox
    Friend WithEvents lblDESCRIPTION As System.Windows.Forms.Label
    Friend WithEvents txtDESCRIPTION As System.Windows.Forms.TextBox
    Friend WithEvents txtFAX As System.Windows.Forms.TextBox
    Friend WithEvents lblFAX As System.Windows.Forms.Label
    Friend WithEvents txtDEPOSITID As FlexMaskEditBox
    Friend WithEvents lblDEPOSITID As System.Windows.Forms.Label
    Friend WithEvents grbDepositMember As System.Windows.Forms.GroupBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grbDepositMember = New System.Windows.Forms.GroupBox
        Me.txtDEPOSITID = New AppCore.FlexMaskEditBox
        Me.lblDEPOSITID = New System.Windows.Forms.Label
        Me.lblDESCRIPTION = New System.Windows.Forms.Label
        Me.txtDESCRIPTION = New System.Windows.Forms.TextBox
        Me.txtSHORTNAME = New System.Windows.Forms.TextBox
        Me.lblSHORTNAME = New System.Windows.Forms.Label
        Me.txtFULLNAME = New System.Windows.Forms.TextBox
        Me.lblFULLNAME = New System.Windows.Forms.Label
        Me.lblOFFICENAME = New System.Windows.Forms.Label
        Me.txtOFFICENAME = New System.Windows.Forms.TextBox
        Me.lblADDRESS = New System.Windows.Forms.Label
        Me.txtADDRESS = New System.Windows.Forms.TextBox
        Me.lblPHONE = New System.Windows.Forms.Label
        Me.txtPHONE = New System.Windows.Forms.TextBox
        Me.lblFAX = New System.Windows.Forms.Label
        Me.txtFAX = New System.Windows.Forms.TextBox
        Me.grbDepositMember.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnApply
        '
        Me.btnApply.Location = New System.Drawing.Point(432, 288)
        Me.btnApply.Name = "btnApply"
        '
        'lblCaption
        '
        Me.lblCaption.Name = "lblCaption"
        '
        'Panel1
        '
        Me.Panel1.Name = "Panel1"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(352, 288)
        Me.btnOK.Name = "btnOK"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(512, 288)
        Me.btnCancel.Name = "btnCancel"
        '
        'grbDepositMember
        '
        Me.grbDepositMember.Controls.Add(Me.txtDEPOSITID)
        Me.grbDepositMember.Controls.Add(Me.lblDEPOSITID)
        Me.grbDepositMember.Controls.Add(Me.lblDESCRIPTION)
        Me.grbDepositMember.Controls.Add(Me.txtDESCRIPTION)
        Me.grbDepositMember.Controls.Add(Me.txtSHORTNAME)
        Me.grbDepositMember.Controls.Add(Me.lblSHORTNAME)
        Me.grbDepositMember.Controls.Add(Me.txtFULLNAME)
        Me.grbDepositMember.Controls.Add(Me.lblFULLNAME)
        Me.grbDepositMember.Controls.Add(Me.lblOFFICENAME)
        Me.grbDepositMember.Controls.Add(Me.txtOFFICENAME)
        Me.grbDepositMember.Controls.Add(Me.lblADDRESS)
        Me.grbDepositMember.Controls.Add(Me.txtADDRESS)
        Me.grbDepositMember.Controls.Add(Me.lblPHONE)
        Me.grbDepositMember.Controls.Add(Me.txtPHONE)
        Me.grbDepositMember.Controls.Add(Me.lblFAX)
        Me.grbDepositMember.Controls.Add(Me.txtFAX)
        Me.grbDepositMember.Location = New System.Drawing.Point(8, 64)
        Me.grbDepositMember.Name = "grbDepositMember"
        Me.grbDepositMember.Size = New System.Drawing.Size(576, 212)
        Me.grbDepositMember.TabIndex = 0
        Me.grbDepositMember.TabStop = False
        Me.grbDepositMember.Tag = "grbDepositMember"
        Me.grbDepositMember.Text = "grbDepositMember"
        '
        'txtDEPOSITID
        '
        Me.txtDEPOSITID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDEPOSITID.Location = New System.Drawing.Point(112, 32)
        Me.txtDEPOSITID.Name = "txtDEPOSITID"
        Me.txtDEPOSITID.Size = New System.Drawing.Size(110, 21)
        Me.txtDEPOSITID.TabIndex = 1
        Me.txtDEPOSITID.Tag = "DEPOSITID"
        Me.txtDEPOSITID.Text = "txtDEPOSITID"
        '
        'lblDEPOSITID
        '
        Me.lblDEPOSITID.Location = New System.Drawing.Point(8, 30)
        Me.lblDEPOSITID.Name = "lblDEPOSITID"
        Me.lblDEPOSITID.TabIndex = 38
        Me.lblDEPOSITID.Tag = "DEPOSITID"
        Me.lblDEPOSITID.Text = "lblDEPOSITID"
        '
        'lblDESCRIPTION
        '
        Me.lblDESCRIPTION.Location = New System.Drawing.Point(8, 172)
        Me.lblDESCRIPTION.Name = "lblDESCRIPTION"
        Me.lblDESCRIPTION.Size = New System.Drawing.Size(100, 21)
        Me.lblDESCRIPTION.TabIndex = 37
        Me.lblDESCRIPTION.Tag = "DESCRIPTION"
        Me.lblDESCRIPTION.Text = "lblDESCRIPTION"
        Me.lblDESCRIPTION.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDESCRIPTION
        '
        Me.txtDESCRIPTION.Location = New System.Drawing.Point(112, 172)
        Me.txtDESCRIPTION.Name = "txtDESCRIPTION"
        Me.txtDESCRIPTION.Size = New System.Drawing.Size(448, 21)
        Me.txtDESCRIPTION.TabIndex = 8
        Me.txtDESCRIPTION.Tag = "DESCRIPTION"
        Me.txtDESCRIPTION.Text = "txtDESCRIPTION"
        '
        'txtSHORTNAME
        '
        Me.txtSHORTNAME.Location = New System.Drawing.Point(336, 32)
        Me.txtSHORTNAME.Name = "txtSHORTNAME"
        Me.txtSHORTNAME.Size = New System.Drawing.Size(224, 21)
        Me.txtSHORTNAME.TabIndex = 2
        Me.txtSHORTNAME.Tag = "SHORTNAME"
        Me.txtSHORTNAME.Text = "txtSHORTNAME"
        '
        'lblSHORTNAME
        '
        Me.lblSHORTNAME.Location = New System.Drawing.Point(232, 32)
        Me.lblSHORTNAME.Name = "lblSHORTNAME"
        Me.lblSHORTNAME.Size = New System.Drawing.Size(100, 21)
        Me.lblSHORTNAME.TabIndex = 28
        Me.lblSHORTNAME.Tag = "SHORTNAME"
        Me.lblSHORTNAME.Text = "lblSHORTNAME"
        Me.lblSHORTNAME.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFULLNAME
        '
        Me.txtFULLNAME.Location = New System.Drawing.Point(112, 60)
        Me.txtFULLNAME.Name = "txtFULLNAME"
        Me.txtFULLNAME.Size = New System.Drawing.Size(448, 21)
        Me.txtFULLNAME.TabIndex = 3
        Me.txtFULLNAME.Tag = "FULLNAME"
        Me.txtFULLNAME.Text = "txtFULLNAME"
        '
        'lblFULLNAME
        '
        Me.lblFULLNAME.Location = New System.Drawing.Point(8, 60)
        Me.lblFULLNAME.Name = "lblFULLNAME"
        Me.lblFULLNAME.Size = New System.Drawing.Size(100, 21)
        Me.lblFULLNAME.TabIndex = 29
        Me.lblFULLNAME.Tag = "FULLNAME"
        Me.lblFULLNAME.Text = "lblFULLNAME"
        Me.lblFULLNAME.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblOFFICENAME
        '
        Me.lblOFFICENAME.Location = New System.Drawing.Point(8, 88)
        Me.lblOFFICENAME.Name = "lblOFFICENAME"
        Me.lblOFFICENAME.Size = New System.Drawing.Size(100, 21)
        Me.lblOFFICENAME.TabIndex = 30
        Me.lblOFFICENAME.Tag = "OFFICENAME"
        Me.lblOFFICENAME.Text = "lblOFFICENAME"
        Me.lblOFFICENAME.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtOFFICENAME
        '
        Me.txtOFFICENAME.Location = New System.Drawing.Point(112, 88)
        Me.txtOFFICENAME.Name = "txtOFFICENAME"
        Me.txtOFFICENAME.Size = New System.Drawing.Size(232, 21)
        Me.txtOFFICENAME.TabIndex = 4
        Me.txtOFFICENAME.Tag = "OFFICENAME"
        Me.txtOFFICENAME.Text = "txtOFFICENAME"
        '
        'lblADDRESS
        '
        Me.lblADDRESS.Location = New System.Drawing.Point(8, 116)
        Me.lblADDRESS.Name = "lblADDRESS"
        Me.lblADDRESS.Size = New System.Drawing.Size(100, 21)
        Me.lblADDRESS.TabIndex = 31
        Me.lblADDRESS.Tag = "ADDRESS"
        Me.lblADDRESS.Text = "lblADDRESS"
        Me.lblADDRESS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtADDRESS
        '
        Me.txtADDRESS.Location = New System.Drawing.Point(112, 116)
        Me.txtADDRESS.Name = "txtADDRESS"
        Me.txtADDRESS.Size = New System.Drawing.Size(448, 21)
        Me.txtADDRESS.TabIndex = 5
        Me.txtADDRESS.Tag = "ADDRESS"
        Me.txtADDRESS.Text = "txtADDRESS"
        '
        'lblPHONE
        '
        Me.lblPHONE.Location = New System.Drawing.Point(8, 144)
        Me.lblPHONE.Name = "lblPHONE"
        Me.lblPHONE.Size = New System.Drawing.Size(100, 21)
        Me.lblPHONE.TabIndex = 32
        Me.lblPHONE.Tag = "PHONE"
        Me.lblPHONE.Text = "lblPHONE"
        Me.lblPHONE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPHONE
        '
        Me.txtPHONE.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPHONE.Location = New System.Drawing.Point(112, 144)
        Me.txtPHONE.Name = "txtPHONE"
        Me.txtPHONE.Size = New System.Drawing.Size(110, 21)
        Me.txtPHONE.TabIndex = 6
        Me.txtPHONE.Tag = "PHONE"
        Me.txtPHONE.Text = "txtPHONE"
        '
        'lblFAX
        '
        Me.lblFAX.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.lblFAX.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFAX.Location = New System.Drawing.Point(232, 144)
        Me.lblFAX.Name = "lblFAX"
        Me.lblFAX.Size = New System.Drawing.Size(100, 21)
        Me.lblFAX.TabIndex = 33
        Me.lblFAX.Tag = "FAX"
        Me.lblFAX.Text = "lblFAX"
        Me.lblFAX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFAX
        '
        Me.txtFAX.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFAX.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFAX.Location = New System.Drawing.Point(336, 144)
        Me.txtFAX.Name = "txtFAX"
        Me.txtFAX.Size = New System.Drawing.Size(110, 21)
        Me.txtFAX.TabIndex = 7
        Me.txtFAX.Tag = "FAX"
        Me.txtFAX.Text = "txtFAX"
        '
        'frmDEPOSIT_MEMBER
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(594, 320)
        Me.Controls.Add(Me.grbDepositMember)
        Me.Name = "frmDEPOSIT_MEMBER"
        Me.Text = "frmDEPOSIT_MEMBER"
        Me.Controls.SetChildIndex(Me.grbDepositMember, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.btnApply, 0)
        Me.grbDepositMember.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

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

                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionAdd, , , , gc_AutoIdUsed, , )
                    BuildXMLObjData(mv_dsInput, v_strObjMsg)

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

                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionEdit, , v_strClause)
                    BuildXMLObjData(mv_dsInput, v_strObjMsg, mv_dsOldInput, ExecuteFlag.Edit)

                    Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                    Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)

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
        If (ExeFlag = ExecuteFlag.Edit) Then
            txtDEPOSITID.Enabled = False
        End If
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

   
End Class
