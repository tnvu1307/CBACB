Imports CommonLibrary
Imports AppCore
Public Class frmAFTXMAP
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
    Friend WithEvents txtAUTOID As System.Windows.Forms.TextBox
    Friend WithEvents lblEXPDATE As System.Windows.Forms.Label
    Friend WithEvents lblTLTXCD As System.Windows.Forms.Label
    Friend WithEvents txtTLTXCD As AppCore.FlexMaskEditBox
    Friend WithEvents dtpEXPDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblAFACCTNO As System.Windows.Forms.Label
    Friend WithEvents txtAFACCTNO As AppCore.FlexMaskEditBox
    Friend WithEvents dtpEFFDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEFFDATE As System.Windows.Forms.Label
    Friend WithEvents txtTLID As System.Windows.Forms.TextBox
    Friend WithEvents lblTLID As System.Windows.Forms.Label
    Friend WithEvents lblACTYPE As System.Windows.Forms.Label
    Friend WithEvents txtACTYPE As AppCore.FlexMaskEditBox
    Friend WithEvents grbTXMAP As System.Windows.Forms.GroupBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAFTXMAP))
        Me.grbTXMAP = New System.Windows.Forms.GroupBox
        Me.lblACTYPE = New System.Windows.Forms.Label
        Me.txtACTYPE = New AppCore.FlexMaskEditBox
        Me.txtTLID = New System.Windows.Forms.TextBox
        Me.lblTLID = New System.Windows.Forms.Label
        Me.dtpEFFDATE = New System.Windows.Forms.DateTimePicker
        Me.lblEFFDATE = New System.Windows.Forms.Label
        Me.lblAFACCTNO = New System.Windows.Forms.Label
        Me.txtAFACCTNO = New AppCore.FlexMaskEditBox
        Me.dtpEXPDATE = New System.Windows.Forms.DateTimePicker
        Me.lblEXPDATE = New System.Windows.Forms.Label
        Me.lblTLTXCD = New System.Windows.Forms.Label
        Me.txtTLTXCD = New AppCore.FlexMaskEditBox
        Me.txtAUTOID = New System.Windows.Forms.TextBox
        Me.Panel1.SuspendLayout()
        Me.grbTXMAP.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(203, 185)
        Me.btnOK.Size = New System.Drawing.Size(75, 24)
        Me.btnOK.TabIndex = 1
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(283, 185)
        Me.btnCancel.Size = New System.Drawing.Size(75, 24)
        Me.btnCancel.TabIndex = 2
        '
        'lblCaption
        '
        Me.lblCaption.Location = New System.Drawing.Point(7, 17)
        '
        'btnApply
        '
        Me.btnApply.Location = New System.Drawing.Point(363, 185)
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(450, 50)
        '
        'cboLink
        '
        '
        'grbTXMAP
        '
        Me.grbTXMAP.Controls.Add(Me.lblACTYPE)
        Me.grbTXMAP.Controls.Add(Me.txtACTYPE)
        Me.grbTXMAP.Controls.Add(Me.txtTLID)
        Me.grbTXMAP.Controls.Add(Me.lblTLID)
        Me.grbTXMAP.Controls.Add(Me.dtpEFFDATE)
        Me.grbTXMAP.Controls.Add(Me.lblEFFDATE)
        Me.grbTXMAP.Controls.Add(Me.lblAFACCTNO)
        Me.grbTXMAP.Controls.Add(Me.txtAFACCTNO)
        Me.grbTXMAP.Controls.Add(Me.dtpEXPDATE)
        Me.grbTXMAP.Controls.Add(Me.lblEXPDATE)
        Me.grbTXMAP.Controls.Add(Me.lblTLTXCD)
        Me.grbTXMAP.Controls.Add(Me.txtTLTXCD)
        Me.grbTXMAP.Location = New System.Drawing.Point(0, 56)
        Me.grbTXMAP.Name = "grbTXMAP"
        Me.grbTXMAP.Size = New System.Drawing.Size(450, 123)
        Me.grbTXMAP.TabIndex = 0
        Me.grbTXMAP.TabStop = False
        Me.grbTXMAP.Tag = "TXMAP"
        Me.grbTXMAP.Text = "grbTXMAP"
        '
        'lblACTYPE
        '
        Me.lblACTYPE.Location = New System.Drawing.Point(230, 90)
        Me.lblACTYPE.Name = "lblACTYPE"
        Me.lblACTYPE.Size = New System.Drawing.Size(80, 24)
        Me.lblACTYPE.TabIndex = 27
        Me.lblACTYPE.Tag = "ACTYPE"
        Me.lblACTYPE.Text = "lblACTYPE"
        '
        'txtACTYPE
        '
        Me.txtACTYPE.Location = New System.Drawing.Point(314, 91)
        Me.txtACTYPE.Name = "txtACTYPE"
        Me.txtACTYPE.Size = New System.Drawing.Size(112, 21)
        Me.txtACTYPE.TabIndex = 5
        Me.txtACTYPE.Tag = "ACTYPE"
        Me.txtACTYPE.Text = "txtACTYPE"
        '
        'txtTLID
        '
        Me.txtTLID.Location = New System.Drawing.Point(92, 91)
        Me.txtTLID.Name = "txtTLID"
        Me.txtTLID.Size = New System.Drawing.Size(112, 21)
        Me.txtTLID.TabIndex = 4
        Me.txtTLID.Tag = "TLID"
        Me.txtTLID.Text = "txtTLID"
        '
        'lblTLID
        '
        Me.lblTLID.Location = New System.Drawing.Point(6, 90)
        Me.lblTLID.Name = "lblTLID"
        Me.lblTLID.Size = New System.Drawing.Size(80, 24)
        Me.lblTLID.TabIndex = 24
        Me.lblTLID.Tag = "TLID"
        Me.lblTLID.Text = "lblTLID"
        '
        'dtpEFFDATE
        '
        Me.dtpEFFDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEFFDATE.Location = New System.Drawing.Point(92, 56)
        Me.dtpEFFDATE.Name = "dtpEFFDATE"
        Me.dtpEFFDATE.ShowCheckBox = True
        Me.dtpEFFDATE.Size = New System.Drawing.Size(112, 21)
        Me.dtpEFFDATE.TabIndex = 2
        Me.dtpEFFDATE.Tag = "EFFDATE"
        '
        'lblEFFDATE
        '
        Me.lblEFFDATE.Location = New System.Drawing.Point(8, 55)
        Me.lblEFFDATE.Name = "lblEFFDATE"
        Me.lblEFFDATE.Size = New System.Drawing.Size(88, 23)
        Me.lblEFFDATE.TabIndex = 22
        Me.lblEFFDATE.Tag = "EFFDATE"
        Me.lblEFFDATE.Text = "lblEFFDATE"
        '
        'lblAFACCTNO
        '
        Me.lblAFACCTNO.Location = New System.Drawing.Point(8, 20)
        Me.lblAFACCTNO.Name = "lblAFACCTNO"
        Me.lblAFACCTNO.Size = New System.Drawing.Size(80, 24)
        Me.lblAFACCTNO.TabIndex = 19
        Me.lblAFACCTNO.Tag = "AFACCTNO"
        Me.lblAFACCTNO.Text = "lblAFACCTNO"
        '
        'txtAFACCTNO
        '
        Me.txtAFACCTNO.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtAFACCTNO.Location = New System.Drawing.Point(92, 22)
        Me.txtAFACCTNO.Name = "txtAFACCTNO"
        Me.txtAFACCTNO.Size = New System.Drawing.Size(112, 21)
        Me.txtAFACCTNO.TabIndex = 0
        Me.txtAFACCTNO.Tag = "AFACCTNO"
        Me.txtAFACCTNO.Text = "txtAFACCTNO"
        '
        'dtpEXPDATE
        '
        Me.dtpEXPDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEXPDATE.Location = New System.Drawing.Point(314, 56)
        Me.dtpEXPDATE.Name = "dtpEXPDATE"
        Me.dtpEXPDATE.ShowCheckBox = True
        Me.dtpEXPDATE.Size = New System.Drawing.Size(112, 21)
        Me.dtpEXPDATE.TabIndex = 3
        Me.dtpEXPDATE.Tag = "EXPDATE"
        '
        'lblEXPDATE
        '
        Me.lblEXPDATE.Location = New System.Drawing.Point(230, 55)
        Me.lblEXPDATE.Name = "lblEXPDATE"
        Me.lblEXPDATE.Size = New System.Drawing.Size(88, 23)
        Me.lblEXPDATE.TabIndex = 1
        Me.lblEXPDATE.Tag = "EXPDATE"
        Me.lblEXPDATE.Text = "lblEXPDATE"
        '
        'lblTLTXCD
        '
        Me.lblTLTXCD.Location = New System.Drawing.Point(230, 21)
        Me.lblTLTXCD.Name = "lblTLTXCD"
        Me.lblTLTXCD.Size = New System.Drawing.Size(68, 23)
        Me.lblTLTXCD.TabIndex = 0
        Me.lblTLTXCD.Tag = "TLTXCD"
        Me.lblTLTXCD.Text = "lblTLTXCD"
        '
        'txtTLTXCD
        '
        Me.txtTLTXCD.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtTLTXCD.Location = New System.Drawing.Point(314, 22)
        Me.txtTLTXCD.Name = "txtTLTXCD"
        Me.txtTLTXCD.Size = New System.Drawing.Size(112, 21)
        Me.txtTLTXCD.TabIndex = 1
        Me.txtTLTXCD.Tag = "TLTXCD"
        Me.txtTLTXCD.Text = "txtTLTXCD"
        '
        'txtAUTOID
        '
        Me.txtAUTOID.Location = New System.Drawing.Point(4, 185)
        Me.txtAUTOID.Name = "txtAUTOID"
        Me.txtAUTOID.Size = New System.Drawing.Size(100, 21)
        Me.txtAUTOID.TabIndex = 7
        Me.txtAUTOID.Tag = "AUTOID"
        Me.txtAUTOID.Text = "txtAUTOID"
        '
        'frmAFTXMAP
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(450, 220)
        Me.Controls.Add(Me.grbTXMAP)
        Me.Controls.Add(Me.txtAUTOID)
        Me.Name = "frmAFTXMAP"
        Me.Text = "frmAFTXMAP"
        Me.Controls.SetChildIndex(Me.cboLink, 0)
        Me.Controls.SetChildIndex(Me.btnApply, 0)
        Me.Controls.SetChildIndex(Me.btnApprv, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.txtAUTOID, 0)
        Me.Controls.SetChildIndex(Me.grbTXMAP, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.grbTXMAP.ResumeLayout(False)
        Me.grbTXMAP.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region " Declare constants and variables "
    Private mv_Acctno As String
    Private mv_Actype As String
    Private mv_Custodycd As String
#End Region

#Region " Properties "
    Public Property acctno() As String
        Get
            Return mv_Acctno
        End Get
        Set(ByVal Value As String)
            mv_Acctno = Value
        End Set
    End Property

    Public Property Actype() As String
        Get
            Return mv_Actype
        End Get
        Set(ByVal Value As String)
            mv_Actype = Value
        End Set
    End Property

    Public Property custodycd() As String
        Get
            Return mv_Custodycd
        End Get
        Set(ByVal Value As String)
            mv_Custodycd = Value
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

            If ExeFlag = ExecuteFlag.AddNew Then
                Me.dtpEXPDATE.Value = DateAdd(DateInterval.Year, 10, CDate(Me.BusDate))
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ResourceManager.GetString("InitDialogFailed"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
        Me.txtAUTOID.Visible = False


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

        'S?a ch? này cho t?ng form maintenance khác nhau
        If (ExeFlag = ExecuteFlag.AddNew) Then
            Me.txtAFACCTNO.Text = acctno
            Me.txtAFACCTNO.Enabled = False
            Me.txtTLID.Text = Me.TellerId
            Me.txtTLID.Enabled = False
            Me.txtACTYPE.Text = Actype
            Me.txtACTYPE.Enabled = False
        ElseIf (ExeFlag = ExecuteFlag.Edit) Then
            Me.txtAFACCTNO.Enabled = False
            Me.txtTLID.Enabled = False
            Me.txtTLTXCD.Enabled = False
            Me.txtACTYPE.Enabled = False
        End If

        Me.txtAFACCTNO.Visible = True
        Me.txtTLID.Visible = True
        If Me.ExeFlag <> ExecuteFlag.View Then
            Me.txtACTYPE.Text = String.Empty
        End If


    End Sub
#End Region

#Region " Control validations "
    Private Function ControlValidation(Optional ByVal pv_blnSaved As Boolean = False) As Boolean

        Try
            If (ExeFlag = ExecuteFlag.AddNew Or ExeFlag = ExecuteFlag.Edit) And Me.dtpEXPDATE.Value < Me.dtpEFFDATE.Value Then
                MessageBox.Show(ResourceManager.GetString("EXPDATE_GREATER_EFFDATE"))
                Return False
            End If
            If ExeFlag = ExecuteFlag.AddNew And Me.dtpEFFDATE.Value < CDate(Me.BusDate) Then
                MessageBox.Show(ResourceManager.GetString("EFFDATE_GREATER_BUSDATE"))
                Return False
            End If

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
