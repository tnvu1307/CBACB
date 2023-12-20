Imports AppCore
Imports CommonLibrary
Imports System.IO

Public Class frmCFSIGN
    Inherits AppCore.frmMaintenance

    Private mv_strCustID As String
    Private mv_strAutoID As String
    Friend WithEvents dtpVALDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpEXPDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblVALDATE As System.Windows.Forms.Label
    Friend WithEvents lblEXPDATE As System.Windows.Forms.Label
    Friend WithEvents lblDESC As System.Windows.Forms.Label
    Friend WithEvents txtDESC As System.Windows.Forms.TextBox
    Friend WithEvents grpCFSIGN As System.Windows.Forms.GroupBox
    Private mv_lngFileSize As Long
    Private mv_intSignCount As Integer

    Public Property SignCount() As Integer
        Get
            Return mv_intSignCount
        End Get
        Set(ByVal Value As Integer)
            mv_intSignCount = Value
        End Set
    End Property

    Public Property CustID() As String
        Get
            Return mv_strCustID
        End Get
        Set(ByVal Value As String)
            mv_strCustID = Value
        End Set
    End Property

    Public Property AUTOID() As String
        Get
            Return mv_strAutoID
        End Get
        Set(ByVal Value As String)
            mv_strAutoID = Value
        End Set
    End Property

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()


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
    Friend WithEvents pbxSIGNATURE As System.Windows.Forms.PictureBox
    Friend WithEvents txtAUTOID As System.Windows.Forms.TextBox
    Friend WithEvents btnBROWSER As System.Windows.Forms.Button
    Friend WithEvents txtBROWSER As System.Windows.Forms.TextBox
    Friend WithEvents txtCUSTID As System.Windows.Forms.TextBox
    'Friend WithEvents txtIMAGESIZE As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCFSIGN))
        Me.pbxSIGNATURE = New System.Windows.Forms.PictureBox
        Me.txtAUTOID = New System.Windows.Forms.TextBox
        Me.btnBROWSER = New System.Windows.Forms.Button
        Me.txtBROWSER = New System.Windows.Forms.TextBox
        Me.txtCUSTID = New System.Windows.Forms.TextBox
        Me.dtpVALDATE = New System.Windows.Forms.DateTimePicker
        Me.dtpEXPDATE = New System.Windows.Forms.DateTimePicker
        Me.lblVALDATE = New System.Windows.Forms.Label
        Me.lblEXPDATE = New System.Windows.Forms.Label
        Me.lblDESC = New System.Windows.Forms.Label
        Me.txtDESC = New System.Windows.Forms.TextBox
        Me.grpCFSIGN = New System.Windows.Forms.GroupBox
        Me.Panel1.SuspendLayout()
        CType(Me.pbxSIGNATURE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpCFSIGN.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(328, 238)
        Me.btnOK.TabIndex = 4
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(408, 238)
        Me.btnCancel.TabIndex = 5
        '
        'btnApply
        '
        Me.btnApply.Location = New System.Drawing.Point(488, 238)
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(572, 50)
        '
        'cboLink
        '
        '
        'pbxSIGNATURE
        '
        Me.pbxSIGNATURE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pbxSIGNATURE.Location = New System.Drawing.Point(16, 64)
        Me.pbxSIGNATURE.Name = "pbxSIGNATURE"
        Me.pbxSIGNATURE.Size = New System.Drawing.Size(216, 136)
        Me.pbxSIGNATURE.TabIndex = 15
        Me.pbxSIGNATURE.TabStop = False
        Me.pbxSIGNATURE.Tag = "SIGNATURE"
        '
        'txtAUTOID
        '
        Me.txtAUTOID.Location = New System.Drawing.Point(16, 240)
        Me.txtAUTOID.Name = "txtAUTOID"
        Me.txtAUTOID.Size = New System.Drawing.Size(100, 21)
        Me.txtAUTOID.TabIndex = 1
        Me.txtAUTOID.Tag = "AUTOID"
        Me.txtAUTOID.Text = "txtAUTOID"
        Me.txtAUTOID.Visible = False
        '
        'btnBROWSER
        '
        Me.btnBROWSER.Location = New System.Drawing.Point(16, 208)
        Me.btnBROWSER.Name = "btnBROWSER"
        Me.btnBROWSER.Size = New System.Drawing.Size(75, 23)
        Me.btnBROWSER.TabIndex = 17
        Me.btnBROWSER.Tag = "btnBROWSER"
        Me.btnBROWSER.Text = "btnBROWSER"
        '
        'txtBROWSER
        '
        Me.txtBROWSER.Location = New System.Drawing.Point(96, 208)
        Me.txtBROWSER.Name = "txtBROWSER"
        Me.txtBROWSER.Size = New System.Drawing.Size(464, 21)
        Me.txtBROWSER.TabIndex = 0
        Me.txtBROWSER.Tag = ""
        Me.txtBROWSER.Text = "txtBROWSER"
        '
        'txtCUSTID
        '
        Me.txtCUSTID.Location = New System.Drawing.Point(120, 240)
        Me.txtCUSTID.Name = "txtCUSTID"
        Me.txtCUSTID.Size = New System.Drawing.Size(100, 21)
        Me.txtCUSTID.TabIndex = 2
        Me.txtCUSTID.Tag = "CUSTID"
        Me.txtCUSTID.Text = "txtCUSTID"
        Me.txtCUSTID.Visible = False
        '
        'dtpVALDATE
        '
        Me.dtpVALDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpVALDATE.Location = New System.Drawing.Point(180, 20)
        Me.dtpVALDATE.Name = "dtpVALDATE"
        Me.dtpVALDATE.Size = New System.Drawing.Size(136, 21)
        Me.dtpVALDATE.TabIndex = 18
        Me.dtpVALDATE.Tag = "VALDATE"
        Me.dtpVALDATE.Value = New Date(2006, 8, 28, 13, 36, 3, 671)
        '
        'dtpEXPDATE
        '
        Me.dtpEXPDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEXPDATE.Location = New System.Drawing.Point(180, 47)
        Me.dtpEXPDATE.Name = "dtpEXPDATE"
        Me.dtpEXPDATE.Size = New System.Drawing.Size(136, 21)
        Me.dtpEXPDATE.TabIndex = 19
        Me.dtpEXPDATE.Tag = "EXPDATE"
        Me.dtpEXPDATE.Value = New Date(2006, 8, 28, 13, 36, 3, 671)
        '
        'lblVALDATE
        '
        Me.lblVALDATE.AutoSize = True
        Me.lblVALDATE.Location = New System.Drawing.Point(20, 26)
        Me.lblVALDATE.Name = "lblVALDATE"
        Me.lblVALDATE.Size = New System.Drawing.Size(61, 13)
        Me.lblVALDATE.TabIndex = 20
        Me.lblVALDATE.Tag = "VALDATE"
        Me.lblVALDATE.Text = "lblVALDATE"
        '
        'lblEXPDATE
        '
        Me.lblEXPDATE.AutoSize = True
        Me.lblEXPDATE.Location = New System.Drawing.Point(20, 53)
        Me.lblEXPDATE.Name = "lblEXPDATE"
        Me.lblEXPDATE.Size = New System.Drawing.Size(61, 13)
        Me.lblEXPDATE.TabIndex = 21
        Me.lblEXPDATE.Tag = "EXPDATE"
        Me.lblEXPDATE.Text = "lblEXPDATE"
        '
        'lblDESC
        '
        Me.lblDESC.AutoSize = True
        Me.lblDESC.Location = New System.Drawing.Point(20, 101)
        Me.lblDESC.Name = "lblDESC"
        Me.lblDESC.Size = New System.Drawing.Size(41, 13)
        Me.lblDESC.TabIndex = 22
        Me.lblDESC.Tag = "DESC"
        Me.lblDESC.Text = "lbDESC"
        '
        'txtDESC
        '
        Me.txtDESC.Location = New System.Drawing.Point(23, 117)
        Me.txtDESC.Name = "txtDESC"
        Me.txtDESC.Size = New System.Drawing.Size(293, 21)
        Me.txtDESC.TabIndex = 23
        Me.txtDESC.Tag = "DESCRIPTION"
        Me.txtDESC.Text = "txtDESC"
        '
        'grpCFSIGN
        '
        Me.grpCFSIGN.Controls.Add(Me.dtpVALDATE)
        Me.grpCFSIGN.Controls.Add(Me.txtDESC)
        Me.grpCFSIGN.Controls.Add(Me.lblDESC)
        Me.grpCFSIGN.Controls.Add(Me.dtpEXPDATE)
        Me.grpCFSIGN.Controls.Add(Me.lblVALDATE)
        Me.grpCFSIGN.Controls.Add(Me.lblEXPDATE)
        Me.grpCFSIGN.Location = New System.Drawing.Point(238, 56)
        Me.grpCFSIGN.Name = "grpCFSIGN"
        Me.grpCFSIGN.Size = New System.Drawing.Size(322, 144)
        Me.grpCFSIGN.TabIndex = 24
        Me.grpCFSIGN.TabStop = False
        Me.grpCFSIGN.Tag = "grpCFSIGN"
        Me.grpCFSIGN.Text = "Thông tin chữ ký"
        '
        'frmCFSIGN
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(572, 269)
        Me.Controls.Add(Me.grpCFSIGN)
        Me.Controls.Add(Me.txtCUSTID)
        Me.Controls.Add(Me.txtBROWSER)
        Me.Controls.Add(Me.btnBROWSER)
        Me.Controls.Add(Me.txtAUTOID)
        Me.Controls.Add(Me.pbxSIGNATURE)
        Me.Name = "frmCFSIGN"
        Me.Tag = "CFSIGN"
        Me.Text = "Customer signature"
        Me.Controls.SetChildIndex(Me.pbxSIGNATURE, 0)
        Me.Controls.SetChildIndex(Me.txtAUTOID, 0)
        Me.Controls.SetChildIndex(Me.btnBROWSER, 0)
        Me.Controls.SetChildIndex(Me.txtBROWSER, 0)
        Me.Controls.SetChildIndex(Me.txtCUSTID, 0)
        Me.Controls.SetChildIndex(Me.cboLink, 0)
        Me.Controls.SetChildIndex(Me.btnApprv, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.btnApply, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.grpCFSIGN, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pbxSIGNATURE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpCFSIGN.ResumeLayout(False)
        Me.grpCFSIGN.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region " Overrides Methods "
    Public Overrides Sub OnInit()
        Dim v_ctrl As Windows.Forms.Control
        dtpVALDATE.Value = CDate(Me.BusDate)
        Try
            MyBase.OnInit()

            'Load Resource Manager
            ResourceManager = New Resources.ResourceManager(gc_RootNamespace & "." & Me.Name & "-" & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
            LoadUserInterface(Me)
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




            If CInt(mv_lngFileSize / 1024) > 22 Then
                MsgBox(ResourceManager.GetString("INVALIDFILESIZE"), MsgBoxStyle.Critical, gc_ApplicationTitle)
                Exit Sub
            End If

            'Dim img = Image.FromFile(txtBROWSER.Text)
            'If img.Size.Width > 250 OrElse img.Size.Height > 250 Then
            '    MsgBox(ResourceManager.GetString("INVALIDFILEDIMENSION"), MsgBoxStyle.Critical, gc_ApplicationTitle)
            '    Exit Sub
            'End If

            MyBase.OnSave()
            If Not DoDataExchange(True) Then
                Exit Sub
            End If

            Select Case ExeFlag
                Case ExecuteFlag.AddNew
                    'Chu y neu bang co autoid thi dat la gc_AutoIdUsed
                    'AnhVT Edit - Maintenance Retored
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionAdd, , , , gc_AutoIdUsed, , , , , , ParentObjName, ParentClause)
                    BuildXMLObjData(mv_dsInput, v_strObjMsg)


                    'PhuongHT add to warning when add a backdate sign
                    Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                    Dim v_xmlDocument As New Xml.XmlDocument, v_nodeList As Xml.XmlNodeList
                    Dim v_strSQL, v_strVALUE, v_strFLDNAME, v_strCurrDate, v_strValDate, v_strExpdate As String

                    If v_strObjMsg.Length > 0 Then
                        v_xmlDocument.LoadXml(v_strObjMsg)
                        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                        For i As Integer = 0 To v_nodeList.Count - 1
                            For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                                With v_nodeList.Item(i).ChildNodes(j)
                                    v_strVALUE = .InnerText.ToString
                                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                    Select Case Trim(v_strFLDNAME)
                                        Case "VALDATE"
                                            v_strValDate = v_strVALUE
                                        Case "EXPDATE"
                                            v_strExpdate = v_strVALUE
                                    End Select
                                End With
                            Next
                        Next
                    End If


                    v_strSQL = "SELECT VARVALUE  FROM SYSVAR WHERE VARNAME = 'CURRDATE'"
                    Dim v_strObjMsg_2 As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFSIGN, gc_ActionInquiry, v_strSQL)
                    v_ws.Message(v_strObjMsg_2)
                    If v_strObjMsg_2.Length > 0 Then
                        v_xmlDocument.LoadXml(v_strObjMsg_2)
                        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                        For i As Integer = 0 To v_nodeList.Count - 1
                            For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                                With v_nodeList.Item(i).ChildNodes(j)
                                    v_strVALUE = .InnerText.ToString
                                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                    Select Case Trim(v_strFLDNAME)
                                        Case "VARVALUE"
                                            v_strCurrDate = v_strVALUE
                                    End Select
                                End With
                            Next
                        Next
                    End If

                    If (DDMMYYYY_SystemDate(v_strCurrDate) > DDMMYYYY_SystemDate(v_strValDate) Or DDMMYYYY_SystemDate(v_strCurrDate) > DDMMYYYY_SystemDate(v_strExpdate)) Then
                        If MsgBox(ResourceManager.GetString("AddBackDateSign"), MsgBoxStyle.OkCancel, gc_ApplicationTitle) = MsgBoxResult.Cancel Then
                            Exit Sub
                        End If
                    End If
                    'end of PhuongHT add

                    'Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
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

                    'AnhVT Edit - Maintenance Retored
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionEdit, , v_strClause, , KeyFieldValue, , , , , , ParentObjName, ParentClause)
                    BuildXMLObjData(mv_dsInput, v_strObjMsg, mv_dsOldInput, ExecuteFlag.Edit)

                    'PhuongHT add to warning when add a backdate sign
                    Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                    Dim v_xmlDocument As New Xml.XmlDocument, v_nodeList As Xml.XmlNodeList
                    Dim v_strSQL, v_strVALUE, v_strFLDNAME, v_strCurrDate, v_strValDate, v_strExpdate As String

                    If v_strObjMsg.Length > 0 Then
                        v_xmlDocument.LoadXml(v_strObjMsg)
                        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                        For i As Integer = 0 To v_nodeList.Count - 1
                            For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                                With v_nodeList.Item(i).ChildNodes(j)
                                    v_strVALUE = .InnerText.ToString
                                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                    Select Case Trim(v_strFLDNAME)
                                        Case "VALDATE"
                                            v_strValDate = v_strVALUE
                                        Case "EXPDATE"
                                            v_strExpdate = v_strVALUE
                                    End Select
                                End With
                            Next
                        Next
                    End If


                    v_strSQL = "SELECT VARVALUE  FROM SYSVAR WHERE VARNAME = 'CURRDATE'"
                    Dim v_strObjMsg_2 As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFSIGN, gc_ActionInquiry, v_strSQL)
                    v_ws.Message(v_strObjMsg_2)
                    If v_strObjMsg_2.Length > 0 Then
                        v_xmlDocument.LoadXml(v_strObjMsg_2)
                        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                        For i As Integer = 0 To v_nodeList.Count - 1
                            For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                                With v_nodeList.Item(i).ChildNodes(j)
                                    v_strVALUE = .InnerText.ToString
                                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                    Select Case Trim(v_strFLDNAME)
                                        Case "VARVALUE"
                                            v_strCurrDate = v_strVALUE
                                    End Select
                                End With
                            Next
                        Next
                    End If

                    'If (DDMMYYYY_SystemDate(v_strCurrDate) > DDMMYYYY_SystemDate(v_strValDate) Or DDMMYYYY_SystemDate(v_strCurrDate) > DDMMYYYY_SystemDate(v_strExpdate)) Then
                    '    If MsgBox(ResourceManager.GetString("AddBackDateSign"), MsgBoxStyle.OkCancel, gc_ApplicationTitle) = MsgBoxResult.Cancel Then
                    '        Exit Sub
                    '    End If
                    'End If
                    'end of PhuongHT add
                    ' Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
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

            'Me.txtCUSTID.Text = mv_strCustID
            'Me.txtAUTOID.Text = mv_strAutoID

            Return MyBase.DoDataExchange(pv_blnSaved)
        Catch ex As Exception
            Throw ex
            Return False
        End Try
    End Function

    Overrides Sub LoadUserInterface(ByRef pv_ctrl As Windows.Forms.Control)
        MyBase.LoadUserInterface(pv_ctrl)
        Me.Text = ResourceManager.GetString("frmCFSIGN")

        'Sửa chỗ này cho từng form maintenance khác nhau
        If (ExeFlag = ExecuteFlag.AddNew) Then
            Me.dtpVALDATE.Enabled = True

            Me.dtpEXPDATE.Visible = False
            Me.lblEXPDATE.Visible = False

            Me.dtpEXPDATE.Value = Me.dtpVALDATE.Value.AddYears(100)
        ElseIf (ExeFlag = ExecuteFlag.Edit) Then
            Me.dtpVALDATE.Enabled = False
            Me.dtpEXPDATE.Visible = True
            Me.lblEXPDATE.Visible = True
        Else
            Me.dtpVALDATE.Enabled = False
            Me.dtpEXPDATE.Enabled = False
        End If

    End Sub
#End Region

#Region " Control validations "
    Private Function ControlValidation(Optional ByVal pv_blnSaved As Boolean = False) As Boolean

        Try
            If pv_blnSaved Then
                If Me.ExeFlag = ExecuteFlag.AddNew And Me.txtBROWSER.Text.Trim().Length = 0 Then
                    MsgBox(ResourceManager.GetString("BrowserEmpty"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    Return False
                End If
                Return MyBase.VerifyRules()
            End If

            Return True
        Catch ex As Exception
            Throw ex
            Return False
        End Try
    End Function
#End Region

    Private Sub frmCFSIGN_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtCUSTID.Visible = False
        Me.txtBROWSER.Text = ""
        If Me.ExeFlag = ExecuteFlag.View Then
            Me.txtBROWSER.Enabled = False
            Me.btnBROWSER.Enabled = False
        ElseIf Me.ExeFlag = ExecuteFlag.Edit Then
            Me.txtBROWSER.Enabled = True
            Me.btnBROWSER.Enabled = True
        End If
    End Sub

    Private Sub btnBROWSER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBROWSER.Click
        Try
            Dim v_oFileDlg As New OpenFileDialog
            With v_oFileDlg
                .InitialDirectory = "C:\"
                .Filter = "Bitmaps|*.bmp|GIFs|*.gif|JPEGs|*.jpg"
                .FilterIndex = 2
                .RestoreDirectory = True
            End With
            If v_oFileDlg.ShowDialog() = DialogResult.OK Then
                With pbxSIGNATURE
                    .Image = Image.FromFile(v_oFileDlg.FileName)
                    .SizeMode = PictureBoxSizeMode.CenterImage
                    .BorderStyle = BorderStyle.Fixed3D
                End With
                txtBROWSER.Text = v_oFileDlg.FileName
                Me.txtCUSTID.Text = mv_strCustID
                Me.txtAUTOID.Text = mv_strAutoID
                mv_lngFileSize = FileLen(v_oFileDlg.FileName)
                

                'If (mv_lngFileSize > 0) Then
                '    Me.txtIMAGESIZE.Text = CInt(mv_lngFileSize / 1024)
                'End If

            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
               & "Error code: System error!" & vbNewLine _
               & "Error message: " & ex.Message, EventLogEntryType.Error)
            'MessageBox.Show(mv_ResourceManager.GetString("frmReceiverData.CannotOpenFile"), Me.FormCaption, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub dtpVALDATE_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpVALDATE.ValueChanged
        If ExeFlag = ExecuteFlag.AddNew Then
            Me.dtpEXPDATE.Value = Me.dtpVALDATE.Value.AddYears(100)
        End If
    End Sub

    Private Sub pbxSIGNATURE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxSIGNATURE.Click

    End Sub
End Class
