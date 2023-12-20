Imports CommonLibrary
Imports AppCore

Public Class frmISSUER_MEMBER
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
    Friend WithEvents GpMEMBER As System.Windows.Forms.GroupBox
    Friend WithEvents lblISSUERID As System.Windows.Forms.Label
    Friend WithEvents lblROLECD As System.Windows.Forms.Label
    Friend WithEvents lblDESCRIPTION As System.Windows.Forms.Label
    Friend WithEvents lblFULLNAME As System.Windows.Forms.Label
    Friend WithEvents lblLICENSENO As System.Windows.Forms.Label
    Friend WithEvents lblCUSTID As System.Windows.Forms.Label
    Friend WithEvents txtFULLNAME As System.Windows.Forms.TextBox
    Friend WithEvents txtCUSTID As FlexMaskEditBox
    Friend WithEvents txtLICENSENO As System.Windows.Forms.TextBox
    Friend WithEvents txtDESCRIPTION As System.Windows.Forms.TextBox
    Friend WithEvents cboROLECD As ComboBoxEx
    Friend WithEvents txtISSUERID As FlexMaskEditBox
    Friend WithEvents txtAUTOID As System.Windows.Forms.TextBox
    Friend WithEvents lblIDEXPIRED As System.Windows.Forms.Label
    Friend WithEvents lblIDDATE As System.Windows.Forms.Label
    Friend WithEvents txtIDPLACE As System.Windows.Forms.TextBox
    Friend WithEvents lblIDPLACE As System.Windows.Forms.Label
    Friend WithEvents dtpIDEXPIRED As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtISSUENAME As System.Windows.Forms.TextBox
    Friend WithEvents lblISSUENAME As System.Windows.Forms.Label
    Friend WithEvents dtpIDDATE As System.Windows.Forms.DateTimePicker
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmISSUER_MEMBER))
        Me.GpMEMBER = New System.Windows.Forms.GroupBox()
        Me.txtISSUENAME = New System.Windows.Forms.TextBox()
        Me.lblISSUENAME = New System.Windows.Forms.Label()
        Me.dtpIDDATE = New System.Windows.Forms.DateTimePicker()
        Me.dtpIDEXPIRED = New System.Windows.Forms.DateTimePicker()
        Me.lblIDDATE = New System.Windows.Forms.Label()
        Me.lblIDEXPIRED = New System.Windows.Forms.Label()
        Me.cboROLECD = New AppCore.ComboBoxEx()
        Me.txtDESCRIPTION = New System.Windows.Forms.TextBox()
        Me.txtLICENSENO = New System.Windows.Forms.TextBox()
        Me.txtCUSTID = New AppCore.FlexMaskEditBox()
        Me.txtFULLNAME = New System.Windows.Forms.TextBox()
        Me.txtISSUERID = New AppCore.FlexMaskEditBox()
        Me.lblCUSTID = New System.Windows.Forms.Label()
        Me.lblLICENSENO = New System.Windows.Forms.Label()
        Me.lblFULLNAME = New System.Windows.Forms.Label()
        Me.lblDESCRIPTION = New System.Windows.Forms.Label()
        Me.lblROLECD = New System.Windows.Forms.Label()
        Me.lblISSUERID = New System.Windows.Forms.Label()
        Me.txtIDPLACE = New System.Windows.Forms.TextBox()
        Me.lblIDPLACE = New System.Windows.Forms.Label()
        Me.txtAUTOID = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.GpMEMBER.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(217, 281)
        Me.btnOK.Size = New System.Drawing.Size(75, 24)
        Me.btnOK.TabIndex = 20
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(297, 281)
        Me.btnCancel.Size = New System.Drawing.Size(75, 24)
        Me.btnCancel.TabIndex = 21
        '
        'lblCaption
        '
        Me.lblCaption.Location = New System.Drawing.Point(7, 17)
        '
        'btnApply
        '
        Me.btnApply.Location = New System.Drawing.Point(377, 281)
        Me.btnApply.TabIndex = 22
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(466, 50)
        '
        'cboLink
        '
        '
        'GpMEMBER
        '
        Me.GpMEMBER.Controls.Add(Me.txtISSUENAME)
        Me.GpMEMBER.Controls.Add(Me.lblISSUENAME)
        Me.GpMEMBER.Controls.Add(Me.dtpIDDATE)
        Me.GpMEMBER.Controls.Add(Me.dtpIDEXPIRED)
        Me.GpMEMBER.Controls.Add(Me.lblIDDATE)
        Me.GpMEMBER.Controls.Add(Me.lblIDEXPIRED)
        Me.GpMEMBER.Controls.Add(Me.cboROLECD)
        Me.GpMEMBER.Controls.Add(Me.txtDESCRIPTION)
        Me.GpMEMBER.Controls.Add(Me.txtLICENSENO)
        Me.GpMEMBER.Controls.Add(Me.txtCUSTID)
        Me.GpMEMBER.Controls.Add(Me.txtFULLNAME)
        Me.GpMEMBER.Controls.Add(Me.txtISSUERID)
        Me.GpMEMBER.Controls.Add(Me.lblCUSTID)
        Me.GpMEMBER.Controls.Add(Me.lblLICENSENO)
        Me.GpMEMBER.Controls.Add(Me.lblFULLNAME)
        Me.GpMEMBER.Controls.Add(Me.lblDESCRIPTION)
        Me.GpMEMBER.Controls.Add(Me.lblROLECD)
        Me.GpMEMBER.Controls.Add(Me.lblISSUERID)
        Me.GpMEMBER.Controls.Add(Me.txtIDPLACE)
        Me.GpMEMBER.Controls.Add(Me.lblIDPLACE)
        Me.GpMEMBER.Location = New System.Drawing.Point(4, 56)
        Me.GpMEMBER.Name = "GpMEMBER"
        Me.GpMEMBER.Size = New System.Drawing.Size(456, 219)
        Me.GpMEMBER.TabIndex = 1
        Me.GpMEMBER.TabStop = False
        Me.GpMEMBER.Tag = "GpMEMBER"
        Me.GpMEMBER.Text = "GpMEMBER"
        '
        'txtISSUENAME
        '
        Me.txtISSUENAME.Location = New System.Drawing.Point(104, 43)
        Me.txtISSUENAME.Name = "txtISSUENAME"
        Me.txtISSUENAME.ReadOnly = True
        Me.txtISSUENAME.Size = New System.Drawing.Size(344, 21)
        Me.txtISSUENAME.TabIndex = 1
        Me.txtISSUENAME.Tag = "ISSUENAME"
        '
        'lblISSUENAME
        '
        Me.lblISSUENAME.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblISSUENAME.Location = New System.Drawing.Point(8, 43)
        Me.lblISSUENAME.Name = "lblISSUENAME"
        Me.lblISSUENAME.Size = New System.Drawing.Size(92, 21)
        Me.lblISSUENAME.TabIndex = 12
        Me.lblISSUENAME.Tag = "ISSUENAME"
        Me.lblISSUENAME.Text = "lblISSUENAME"
        '
        'dtpIDDATE
        '
        Me.dtpIDDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpIDDATE.Location = New System.Drawing.Point(104, 161)
        Me.dtpIDDATE.Name = "dtpIDDATE"
        Me.dtpIDDATE.Size = New System.Drawing.Size(120, 21)
        Me.dtpIDDATE.TabIndex = 14
        Me.dtpIDDATE.Tag = "IDDATE"
        Me.dtpIDDATE.Value = New Date(2006, 8, 28, 13, 36, 3, 671)
        '
        'dtpIDEXPIRED
        '
        Me.dtpIDEXPIRED.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpIDEXPIRED.Location = New System.Drawing.Point(328, 161)
        Me.dtpIDEXPIRED.Name = "dtpIDEXPIRED"
        Me.dtpIDEXPIRED.Size = New System.Drawing.Size(120, 21)
        Me.dtpIDEXPIRED.TabIndex = 15
        Me.dtpIDEXPIRED.Tag = "IDEXPIRED"
        Me.dtpIDEXPIRED.Value = New Date(2006, 8, 28, 13, 36, 3, 671)
        '
        'lblIDDATE
        '
        Me.lblIDDATE.Location = New System.Drawing.Point(8, 161)
        Me.lblIDDATE.Name = "lblIDDATE"
        Me.lblIDDATE.Size = New System.Drawing.Size(92, 21)
        Me.lblIDDATE.TabIndex = 8
        Me.lblIDDATE.Tag = "IDDATE"
        Me.lblIDDATE.Text = "lblIDDATE"
        Me.lblIDDATE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIDEXPIRED
        '
        Me.lblIDEXPIRED.Location = New System.Drawing.Point(227, 161)
        Me.lblIDEXPIRED.Name = "lblIDEXPIRED"
        Me.lblIDEXPIRED.Size = New System.Drawing.Size(92, 21)
        Me.lblIDEXPIRED.TabIndex = 9
        Me.lblIDEXPIRED.Tag = "IDEXPIRED"
        Me.lblIDEXPIRED.Text = "lblIDEXPIRED"
        Me.lblIDEXPIRED.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboROLECD
        '
        Me.cboROLECD.DisplayMember = "DISPLAY"
        Me.cboROLECD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboROLECD.Location = New System.Drawing.Point(328, 70)
        Me.cboROLECD.Name = "cboROLECD"
        Me.cboROLECD.Size = New System.Drawing.Size(120, 21)
        Me.cboROLECD.TabIndex = 4
        Me.cboROLECD.Tag = "ROLECD"
        Me.cboROLECD.ValueMember = "VALUE"
        '
        'txtDESCRIPTION
        '
        Me.txtDESCRIPTION.Location = New System.Drawing.Point(104, 189)
        Me.txtDESCRIPTION.Name = "txtDESCRIPTION"
        Me.txtDESCRIPTION.Size = New System.Drawing.Size(344, 21)
        Me.txtDESCRIPTION.TabIndex = 16
        Me.txtDESCRIPTION.Tag = "DESCRIPTION"
        Me.txtDESCRIPTION.Text = "txtDESCRIPTION"
        '
        'txtLICENSENO
        '
        Me.txtLICENSENO.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLICENSENO.Location = New System.Drawing.Point(104, 132)
        Me.txtLICENSENO.Name = "txtLICENSENO"
        Me.txtLICENSENO.Size = New System.Drawing.Size(120, 21)
        Me.txtLICENSENO.TabIndex = 6
        Me.txtLICENSENO.Tag = "LICENSENO"
        Me.txtLICENSENO.Text = "txtLICENSENO"
        '
        'txtCUSTID
        '
        Me.txtCUSTID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCUSTID.Location = New System.Drawing.Point(104, 70)
        Me.txtCUSTID.Name = "txtCUSTID"
        Me.txtCUSTID.Size = New System.Drawing.Size(120, 21)
        Me.txtCUSTID.TabIndex = 3
        Me.txtCUSTID.Tag = "CUSTID"
        Me.txtCUSTID.Text = "txtCUSTID"
        '
        'txtFULLNAME
        '
        Me.txtFULLNAME.Location = New System.Drawing.Point(104, 100)
        Me.txtFULLNAME.Name = "txtFULLNAME"
        Me.txtFULLNAME.Size = New System.Drawing.Size(344, 21)
        Me.txtFULLNAME.TabIndex = 5
        Me.txtFULLNAME.Tag = "FULLNAME"
        Me.txtFULLNAME.Text = "txtFULLNAME"
        '
        'txtISSUERID
        '
        Me.txtISSUERID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtISSUERID.Location = New System.Drawing.Point(104, 16)
        Me.txtISSUERID.Name = "txtISSUERID"
        Me.txtISSUERID.Size = New System.Drawing.Size(120, 21)
        Me.txtISSUERID.TabIndex = 0
        Me.txtISSUERID.Tag = "ISSUERID"
        Me.txtISSUERID.Text = "txtlblISSUERID"
        '
        'lblCUSTID
        '
        Me.lblCUSTID.Location = New System.Drawing.Point(8, 70)
        Me.lblCUSTID.Name = "lblCUSTID"
        Me.lblCUSTID.Size = New System.Drawing.Size(92, 21)
        Me.lblCUSTID.TabIndex = 3
        Me.lblCUSTID.Tag = "CUSTID"
        Me.lblCUSTID.Text = "lblCUSTID"
        '
        'lblLICENSENO
        '
        Me.lblLICENSENO.Location = New System.Drawing.Point(8, 132)
        Me.lblLICENSENO.Name = "lblLICENSENO"
        Me.lblLICENSENO.Size = New System.Drawing.Size(92, 21)
        Me.lblLICENSENO.TabIndex = 6
        Me.lblLICENSENO.Tag = "LICENSENO"
        Me.lblLICENSENO.Text = "lblLICENSENO"
        '
        'lblFULLNAME
        '
        Me.lblFULLNAME.Location = New System.Drawing.Point(8, 100)
        Me.lblFULLNAME.Name = "lblFULLNAME"
        Me.lblFULLNAME.Size = New System.Drawing.Size(92, 21)
        Me.lblFULLNAME.TabIndex = 5
        Me.lblFULLNAME.Tag = "FULLNAME"
        Me.lblFULLNAME.Text = "lblFULLNAME"
        '
        'lblDESCRIPTION
        '
        Me.lblDESCRIPTION.Location = New System.Drawing.Point(8, 189)
        Me.lblDESCRIPTION.Name = "lblDESCRIPTION"
        Me.lblDESCRIPTION.Size = New System.Drawing.Size(92, 21)
        Me.lblDESCRIPTION.TabIndex = 10
        Me.lblDESCRIPTION.Tag = "DESCRIPTION"
        Me.lblDESCRIPTION.Text = "lblDESCRIPTION"
        '
        'lblROLECD
        '
        Me.lblROLECD.Location = New System.Drawing.Point(230, 70)
        Me.lblROLECD.Name = "lblROLECD"
        Me.lblROLECD.Size = New System.Drawing.Size(95, 21)
        Me.lblROLECD.TabIndex = 4
        Me.lblROLECD.Tag = "ROLECD"
        Me.lblROLECD.Text = "lblROLECD"
        '
        'lblISSUERID
        '
        Me.lblISSUERID.Location = New System.Drawing.Point(8, 16)
        Me.lblISSUERID.Name = "lblISSUERID"
        Me.lblISSUERID.Size = New System.Drawing.Size(92, 21)
        Me.lblISSUERID.TabIndex = 2
        Me.lblISSUERID.Tag = "ISSUERID"
        Me.lblISSUERID.Text = "lblISSUERID"
        '
        'txtIDPLACE
        '
        Me.txtIDPLACE.Location = New System.Drawing.Point(328, 132)
        Me.txtIDPLACE.MaxLength = 100
        Me.txtIDPLACE.Name = "txtIDPLACE"
        Me.txtIDPLACE.Size = New System.Drawing.Size(120, 21)
        Me.txtIDPLACE.TabIndex = 13
        Me.txtIDPLACE.Tag = "IDPLACE"
        Me.txtIDPLACE.Text = "txtIDPLACE"
        '
        'lblIDPLACE
        '
        Me.lblIDPLACE.Location = New System.Drawing.Point(227, 132)
        Me.lblIDPLACE.Name = "lblIDPLACE"
        Me.lblIDPLACE.Size = New System.Drawing.Size(95, 21)
        Me.lblIDPLACE.TabIndex = 7
        Me.lblIDPLACE.Tag = "IDPLACE"
        Me.lblIDPLACE.Text = "lblIDPLACE"
        Me.lblIDPLACE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAUTOID
        '
        Me.txtAUTOID.Location = New System.Drawing.Point(16, 281)
        Me.txtAUTOID.Name = "txtAUTOID"
        Me.txtAUTOID.Size = New System.Drawing.Size(108, 21)
        Me.txtAUTOID.TabIndex = 7
        Me.txtAUTOID.Tag = "AUTOID"
        Me.txtAUTOID.Text = "txtAUTOID"
        '
        'frmISSUER_MEMBER
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(466, 310)
        Me.Controls.Add(Me.GpMEMBER)
        Me.Controls.Add(Me.txtAUTOID)
        Me.Name = "frmISSUER_MEMBER"
        Me.Text = "frmISSUER_MEMBER"
        Me.Controls.SetChildIndex(Me.cboLink, 0)
        Me.Controls.SetChildIndex(Me.btnApply, 0)
        Me.Controls.SetChildIndex(Me.txtAUTOID, 0)
        Me.Controls.SetChildIndex(Me.btnApprv, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.GpMEMBER, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GpMEMBER.ResumeLayout(False)
        Me.GpMEMBER.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region " Declare constants and variables "
    Private mv_ISSUERID As String
    Private mv_CUSTID As String
#End Region

#Region " Properties "
    Public Property ISSUERID() As String
        Get
            Return mv_ISSUERID
        End Get
        Set(ByVal Value As String)
            mv_ISSUERID = Value
        End Set
    End Property
    Public Property CUSTID() As String
        Get
            Return mv_CUSTID
        End Get
        Set(ByVal Value As String)
            mv_CUSTID = Value
        End Set
    End Property

#End Region


#Region " Overrides Methods "
    Public Overrides Sub OnInit()
        Dim v_ctrl As Windows.Forms.Control

        Try
            MyBase.OnInit()
            If (Me.ExeFlag = ExecuteFlag.AddNew Or Me.ExeFlag = ExecuteFlag.Edit) And ParentObjName = "CF.CFMAST" Then
                If Me.ExeFlag = ExecuteFlag.AddNew Then
                    Me.txtISSUERID.Text = ""
                End If
                Me.txtISSUERID.Enabled = True
            End If
            'Load Resource Manager
            ResourceManager = New Resources.ResourceManager(gc_RootNamespace & "." & Me.Name & "-" & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
            LoadUserInterface(Me)

            txtAUTOID.Visible = False
            'SGN160
            loadIssuerName()
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

            Select Case ExeFlag
                Case ExecuteFlag.AddNew
                    'AnhVT Edit - Maintenance Retored
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionAdd, , , , gc_AutoIdUsed, , , , , , ParentObjName, ParentClause)
                    BuildXMLObjData(mv_dsInput, v_strObjMsg)

                    Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
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
                    'AnhVT Edit - Maintenance Retroed
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionEdit, , v_strClause, , , , , , , , ParentObjName, ParentClause)
                    BuildXMLObjData(mv_dsInput, v_strObjMsg, mv_dsOldInput, ExecuteFlag.Edit)

                    Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
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

        'MyBase.LoadUserInterface(pv_ctrl)
        txtFULLNAME.Enabled = False
        txtLICENSENO.Enabled = False
        txtIDPLACE.Enabled = False
        'S?a ch? này cho t?ng form maintenance khác nhau
        If (ExeFlag = ExecuteFlag.AddNew) Then
            If ISSUERID <> "" Then
                Me.txtISSUERID.Text = ISSUERID
                Me.txtISSUERID.Enabled = False
            End If
            If CUSTID <> "" Then
                Me.txtCUSTID.Text = CUSTID
                Me.txtCUSTID.Enabled = False
                If txtCUSTID.Text <> "" Then
                    Dim v_xmlDocument As New Xml.XmlDocument
                    Dim v_nodeList As Xml.XmlNodeList
                    Dim v_int, v_intCount As Integer
                    Dim v_strFULLNAME, v_strIDDATE, v_strIDPLACE, v_strIDEXPIRED As String
                    Dim v_strFLDNAME, v_strVALUE, v_strIDCODE As String
                    Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery

                    Dim v_strCmdInquiry As String = "Select FULLNAME,IDCODE,IDPLACE,IDEXPIRED,IDDATE from CFMAST WHERE CUSTID ='" & txtCUSTID.Text & "' "
                    Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, "SA.ALLCODE", gc_ActionInquiry, v_strCmdInquiry)
                    v_ws.Message(v_strObjMsg)
                    v_xmlDocument.LoadXml(v_strObjMsg)
                    v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                    For v_intCount = 0 To v_nodeList.Count - 1
                        For v_int = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                            With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                                v_strFLDNAME = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("fldname").Value.Trim()
                                v_strVALUE = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("oldval").Value.Trim()

                                Select Case v_strFLDNAME
                                    Case "FULLNAME"
                                        v_strFULLNAME = v_strVALUE
                                    Case "IDCODE"
                                        v_strIDCODE = v_strVALUE
                                    Case "IDDATE"
                                        v_strIDDATE = v_strVALUE
                                    Case "IDPLACE"
                                        v_strIDPLACE = v_strVALUE
                                    Case "IDEXPIRED"
                                        v_strIDEXPIRED = v_strVALUE

                                End Select
                            End With
                        Next
                    Next
                    txtFULLNAME.Text = v_strFULLNAME
                    txtLICENSENO.Text = v_strIDCODE
                    txtIDPLACE.Text = v_strIDPLACE
                    dtpIDEXPIRED.Value = DDMMYYYY_SystemDate(v_strIDEXPIRED)
                    dtpIDDATE.Value = DDMMYYYY_SystemDate(v_strIDDATE)
                    dtpIDEXPIRED.Enabled = False
                    dtpIDDATE.Enabled = False
                End If

            End If
        ElseIf (ExeFlag = ExecuteFlag.Edit) Then
            txtAUTOID.Enabled = False

            If ISSUERID <> "" Then
                Me.txtISSUERID.Text = ISSUERID
                Me.txtISSUERID.Enabled = False
            End If
            If CUSTID <> "" Then
                Me.txtCUSTID.Enabled = False
            End If
            dtpIDEXPIRED.Enabled = False
            dtpIDDATE.Enabled = False
            ' txtACTYPE.Enabled = False
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
    Private Sub txtCUSTID_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCUSTID.Validating
        If txtCUSTID.Text <> "" Then
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_int, v_intCount As Integer
            Dim v_strFULLNAME, v_strIDDATE, v_strIDPLACE, v_strIDEXPIRED As String
            Dim v_strFLDNAME, v_strVALUE, v_strIDCODE As String
            Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery

            Dim v_strCmdInquiry As String = "Select FULLNAME,IDCODE,IDPLACE,IDEXPIRED,IDDATE from CFMAST WHERE CUSTID ='" & txtCUSTID.Text & "' "
            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, "SA.ALLCODE", gc_ActionInquiry, v_strCmdInquiry)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For v_intCount = 0 To v_nodeList.Count - 1
                For v_int = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                    With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                        v_strFLDNAME = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("fldname").Value.Trim()
                        v_strVALUE = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("oldval").Value.Trim()

                        Select Case v_strFLDNAME
                            Case "FULLNAME"
                                v_strFULLNAME = v_strVALUE
                            Case "IDCODE"
                                v_strIDCODE = v_strVALUE
                            Case "IDDATE"
                                v_strIDDATE = v_strVALUE
                            Case "IDPLACE"
                                v_strIDPLACE = v_strVALUE
                            Case "IDEXPIRED"
                                v_strIDEXPIRED = v_strVALUE
                            Case "IDDATE"
                                v_strIDDATE = v_strVALUE
                            Case "IDEXPIRED"
                                v_strIDEXPIRED = v_strVALUE

                        End Select
                    End With
                Next
            Next
            txtFULLNAME.Text = v_strFULLNAME
            If v_strFULLNAME <> "" Then
                txtFULLNAME.Enabled = False
            End If
            txtLICENSENO.Text = v_strIDCODE
            If v_strIDPLACE <> "" Then
                txtLICENSENO.Enabled = False
            End If
            txtIDPLACE.Text = v_strIDPLACE
            If v_strIDPLACE <> "" Then
                txtIDPLACE.Enabled = False
            End If
            dtpIDEXPIRED.Value = DDMMYYYY_SystemDate(v_strIDEXPIRED)
            If v_strIDEXPIRED <> "" Then
                dtpIDEXPIRED.Enabled = False
            End If
            dtpIDDATE.Value = DDMMYYYY_SystemDate(v_strIDDATE)
            If v_strIDDATE <> "" Then
                dtpIDDATE.Enabled = False
            End If
        End If

    End Sub

    Private Sub txtISSUERID_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtISSUERID.KeyUp
        Me.txtISSUENAME.Text = ""
    End Sub

    Private Sub txtISSUERID_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtISSUERID.Validating
        'SGN160
        loadIssuerName()
    End Sub

    Private Sub loadIssuerName()
        If Me.txtISSUERID.Text <> "" Then
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_int, v_intCount As Integer
            Dim v_strFULLNAME As String
            Dim v_strFLDNAME, v_strVALUE, v_strIDCODE As String
            Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery

            Dim v_strCmdInquiry As String = "SELECT FULLNAME FROM ISSUERS WHERE ISSUERID = '" & Me.txtISSUERID.Text.Trim & "' "
            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, "SA.ALLCODE", gc_ActionInquiry, v_strCmdInquiry)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For v_intCount = 0 To v_nodeList.Count - 1
                For v_int = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                    With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                        v_strFLDNAME = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("fldname").Value.Trim()
                        v_strVALUE = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("oldval").Value.Trim()

                        Select Case v_strFLDNAME
                            Case "FULLNAME"
                                Me.txtISSUENAME.Text = v_strVALUE
                        End Select
                    End With
                Next
            Next
        End If
    End Sub

End Class
