Imports AppCore
Imports CommonLibrary

Public Class frmSBFXRT
    Inherits AppCore.frmMaintenance
    Private mv_strCCYCD As String

#Region " Windows Form Designer generated code "
    Public Property CCYCD() As String
        Get
            Return mv_strCCYCD
        End Get
        Set(ByVal Value As String)
            mv_strCCYCD = Value
        End Set
    End Property
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
    Friend WithEvents lblCCYCD As System.Windows.Forms.Label
    Friend WithEvents lblEDATE As System.Windows.Forms.Label
    Friend WithEvents txtRATENUM As FlexMaskEditBox
    Friend WithEvents lblRATENUM As System.Windows.Forms.Label
    Friend WithEvents txtRATEBCY As System.Windows.Forms.TextBox
    'Friend WithEvents txtRATEBCY As FlexMaskEditBox
    Friend WithEvents lblRATEBCY As System.Windows.Forms.Label
    Friend WithEvents txtRATEUSD As System.Windows.Forms.TextBox
    'Friend WithEvents txtRATEUSD As FlexMaskEditBox
    Friend WithEvents lblRATEUSD As System.Windows.Forms.Label
    Friend WithEvents txtRATELCY As System.Windows.Forms.TextBox
    'Friend WithEvents txtRATELCY As FlexMaskEditBox
    Friend WithEvents lblRATELCY As System.Windows.Forms.Label
    Friend WithEvents dtpEDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtAUTOID As System.Windows.Forms.TextBox
    Friend WithEvents grbInfo As System.Windows.Forms.GroupBox
    Friend WithEvents cboCCYCD As AppCore.ComboBoxEx
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblCCYCD = New System.Windows.Forms.Label
        Me.lblEDATE = New System.Windows.Forms.Label
        Me.txtRATENUM = New AppCore.FlexMaskEditBox
        Me.lblRATENUM = New System.Windows.Forms.Label
        Me.txtRATEBCY = New System.Windows.Forms.TextBox
        Me.lblRATEBCY = New System.Windows.Forms.Label
        Me.txtRATEUSD = New System.Windows.Forms.TextBox
        Me.lblRATEUSD = New System.Windows.Forms.Label
        Me.txtRATELCY = New System.Windows.Forms.TextBox
        Me.lblRATELCY = New System.Windows.Forms.Label
        Me.dtpEDATE = New System.Windows.Forms.DateTimePicker
        Me.txtAUTOID = New System.Windows.Forms.TextBox
        Me.grbInfo = New System.Windows.Forms.GroupBox
        Me.cboCCYCD = New AppCore.ComboBoxEx
        Me.grbInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnApply
        '
        Me.btnApply.Location = New System.Drawing.Point(369, 164)
        Me.btnApply.Name = "btnApply"
        '
        'lblCaption
        '
        Me.lblCaption.Name = "lblCaption"
        '
        'Panel1
        '
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(450, 50)
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(205, 164)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.TabIndex = 1
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(287, 164)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.TabIndex = 2
        '
        'lblCCYCD
        '
        Me.lblCCYCD.Location = New System.Drawing.Point(8, 19)
        Me.lblCCYCD.Name = "lblCCYCD"
        Me.lblCCYCD.Size = New System.Drawing.Size(88, 21)
        Me.lblCCYCD.TabIndex = 0
        Me.lblCCYCD.Tag = "CCYCD"
        Me.lblCCYCD.Text = "lblCCYCD"
        Me.lblCCYCD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEDATE
        '
        Me.lblEDATE.Location = New System.Drawing.Point(216, 19)
        Me.lblEDATE.Name = "lblEDATE"
        Me.lblEDATE.Size = New System.Drawing.Size(112, 21)
        Me.lblEDATE.TabIndex = 0
        Me.lblEDATE.Tag = "EDATE"
        Me.lblEDATE.Text = "lblEDATE"
        Me.lblEDATE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRATENUM
        '
        Me.txtRATENUM.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtRATENUM.Location = New System.Drawing.Point(103, 47)
        Me.txtRATENUM.Name = "txtRATENUM"
        Me.txtRATENUM.Size = New System.Drawing.Size(104, 21)
        Me.txtRATENUM.TabIndex = 2
        Me.txtRATENUM.Tag = "RATENUM"
        Me.txtRATENUM.Text = "txtRATENUM"
        '
        'lblRATENUM
        '
        Me.lblRATENUM.Location = New System.Drawing.Point(8, 47)
        Me.lblRATENUM.Name = "lblRATENUM"
        Me.lblRATENUM.Size = New System.Drawing.Size(88, 21)
        Me.lblRATENUM.TabIndex = 0
        Me.lblRATENUM.Tag = "RATENUM"
        Me.lblRATENUM.Text = "lblRATENUM"
        Me.lblRATENUM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRATEBCY
        '
        Me.txtRATEBCY.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtRATEBCY.Location = New System.Drawing.Point(332, 47)
        Me.txtRATEBCY.Name = "txtRATEBCY"
        Me.txtRATEBCY.Size = New System.Drawing.Size(104, 21)
        Me.txtRATEBCY.TabIndex = 3
        Me.txtRATEBCY.Tag = "RATEBCY"
        Me.txtRATEBCY.Text = "txtRATEBCY"
        '
        'lblRATEBCY
        '
        Me.lblRATEBCY.Location = New System.Drawing.Point(216, 47)
        Me.lblRATEBCY.Name = "lblRATEBCY"
        Me.lblRATEBCY.Size = New System.Drawing.Size(112, 21)
        Me.lblRATEBCY.TabIndex = 0
        Me.lblRATEBCY.Tag = "RATEBCY"
        Me.lblRATEBCY.Text = "lblRATEBCY"
        Me.lblRATEBCY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRATEUSD
        '
        Me.txtRATEUSD.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtRATEUSD.Location = New System.Drawing.Point(103, 75)
        Me.txtRATEUSD.Name = "txtRATEUSD"
        Me.txtRATEUSD.Size = New System.Drawing.Size(104, 21)
        Me.txtRATEUSD.TabIndex = 4
        Me.txtRATEUSD.Tag = "RATEUSD"
        Me.txtRATEUSD.Text = "txtRATEUSD"
        '
        'lblRATEUSD
        '
        Me.lblRATEUSD.Location = New System.Drawing.Point(8, 75)
        Me.lblRATEUSD.Name = "lblRATEUSD"
        Me.lblRATEUSD.Size = New System.Drawing.Size(88, 21)
        Me.lblRATEUSD.TabIndex = 0
        Me.lblRATEUSD.Tag = "RATEUSD"
        Me.lblRATEUSD.Text = "lblRATEUSD"
        Me.lblRATEUSD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRATELCY
        '
        Me.txtRATELCY.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtRATELCY.Location = New System.Drawing.Point(332, 75)
        Me.txtRATELCY.Name = "txtRATELCY"
        Me.txtRATELCY.Size = New System.Drawing.Size(104, 21)
        Me.txtRATELCY.TabIndex = 5
        Me.txtRATELCY.Tag = "RATELCY"
        Me.txtRATELCY.Text = "txtRATELCY"
        '
        'lblRATELCY
        '
        Me.lblRATELCY.Location = New System.Drawing.Point(216, 75)
        Me.lblRATELCY.Name = "lblRATELCY"
        Me.lblRATELCY.Size = New System.Drawing.Size(112, 21)
        Me.lblRATELCY.TabIndex = 0
        Me.lblRATELCY.Tag = "RATELCY"
        Me.lblRATELCY.Text = "lblRATELCY"
        Me.lblRATELCY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpEDATE
        '
        Me.dtpEDATE.CustomFormat = ""
        Me.dtpEDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEDATE.Location = New System.Drawing.Point(332, 19)
        Me.dtpEDATE.Name = "dtpEDATE"
        Me.dtpEDATE.ShowCheckBox = True
        Me.dtpEDATE.Size = New System.Drawing.Size(104, 21)
        Me.dtpEDATE.TabIndex = 1
        Me.dtpEDATE.Tag = "EDATE"
        '
        'txtAUTOID
        '
        Me.txtAUTOID.Location = New System.Drawing.Point(16, 165)
        Me.txtAUTOID.Name = "txtAUTOID"
        Me.txtAUTOID.Size = New System.Drawing.Size(128, 21)
        Me.txtAUTOID.TabIndex = 8
        Me.txtAUTOID.Tag = "AUTOID"
        Me.txtAUTOID.Text = "txtAUTOID"
        '
        'grbInfo
        '
        Me.grbInfo.Controls.Add(Me.cboCCYCD)
        Me.grbInfo.Controls.Add(Me.txtRATEUSD)
        Me.grbInfo.Controls.Add(Me.lblRATEUSD)
        Me.grbInfo.Controls.Add(Me.txtRATELCY)
        Me.grbInfo.Controls.Add(Me.lblRATELCY)
        Me.grbInfo.Controls.Add(Me.dtpEDATE)
        Me.grbInfo.Controls.Add(Me.lblEDATE)
        Me.grbInfo.Controls.Add(Me.txtRATENUM)
        Me.grbInfo.Controls.Add(Me.lblCCYCD)
        Me.grbInfo.Controls.Add(Me.lblRATENUM)
        Me.grbInfo.Controls.Add(Me.txtRATEBCY)
        Me.grbInfo.Controls.Add(Me.lblRATEBCY)
        Me.grbInfo.Location = New System.Drawing.Point(5, 56)
        Me.grbInfo.Name = "grbInfo"
        Me.grbInfo.Size = New System.Drawing.Size(443, 104)
        Me.grbInfo.TabIndex = 0
        Me.grbInfo.TabStop = False
        Me.grbInfo.Tag = "grbInfo"
        Me.grbInfo.Text = "grbInfo"
        '
        'cboCCYCD
        '
        Me.cboCCYCD.DisplayMember = "DISPLAY"
        Me.cboCCYCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCCYCD.Location = New System.Drawing.Point(103, 22)
        Me.cboCCYCD.Name = "cboCCYCD"
        Me.cboCCYCD.Size = New System.Drawing.Size(104, 21)
        Me.cboCCYCD.TabIndex = 0
        Me.cboCCYCD.Tag = "CCYCD"
        Me.cboCCYCD.ValueMember = "VALUE"
        '
        'frmSBFXRT
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(450, 191)
        Me.Controls.Add(Me.grbInfo)
        Me.Controls.Add(Me.txtAUTOID)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Name = "frmSBFXRT"
        Me.Tag = "SBFXRT"
        Me.Text = "frmSBFXRT"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.btnApply, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.txtAUTOID, 0)
        Me.Controls.SetChildIndex(Me.grbInfo, 0)
        Me.grbInfo.ResumeLayout(False)
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
        Dim v_strObjMsg, v_strClause As String
        Try
            'Update mouse pointer
            Cursor.Current = Cursors.WaitCursor

            MyBase.OnSave()
            If Not DoDataExchange(True) Then
                Exit Sub
            End If

            Select Case ExeFlag
                Case ExecuteFlag.AddNew
                            'Chu y neu bang co autoid thi dat la gc_AutoIdUsed
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionAdd, , , , gc_AutoIdUsed)
                    BuildXMLObjData(mv_dsInput, v_strObjMsg)

                    Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                    Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)

                    'Kiểm tra thông tin và xử lý lỗi (nếu có) từ message trả về
                    Dim v_strErrorSource, v_strErrorMessage As String                    

                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                    If v_lngErrorCode <> 0 Then
                        'Update mouse pointer
                        Cursor.Current = Cursors.Default
                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, Me.Text)
                        Exit Sub
                    End If

                    MsgBox(ResourceManager.GetString("AddnewSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
                    Me.DialogResult = DialogResult.OK
                    MyBase.OnClose()
                Case ExecuteFlag.Edit

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

                    'Kiểm tra thông tin và xử lý lỗi (nếu có) từ message trả về
                    Dim v_strErrorSource, v_strErrorMessage As String

                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                    If v_lngErrorCode <> 0 Then
                        'Update mouse pointer
                        Cursor.Current = Cursors.Default
                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, Me.Text)
                        Exit Sub
                    End If

                    MsgBox(ResourceManager.GetString("EditSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
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

        Select Case ExeFlag
            Case ExecuteFlag.AddNew

                Dim v_strClause As String
                Me.cboCCYCD.SelectedValue = Me.CCYCD
                Me.cboCCYCD.Enabled = False
            Case ExecuteFlag.Edit

        End Select
        'Sửa chỗ này cho từng form maintenance khác nhau
     
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
