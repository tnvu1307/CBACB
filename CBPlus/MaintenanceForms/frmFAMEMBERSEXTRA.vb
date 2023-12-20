Imports CommonLibrary
Imports AppCore

Public Class frmFAMEMBERSEXTRA
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
    Friend WithEvents DataTable1 As System.Data.DataTable
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents btnFAMEMBEREXTRA_DELETE As System.Windows.Forms.Button
    Friend WithEvents btnFAMEMBEREXTRA_ADD As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents DataTable3 As System.Data.DataTable
    Friend WithEvents DataTable51 As System.Data.DataTable
    Friend WithEvents DataTable2 As System.Data.DataTable

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFAMEMBERSEXTRA))
        Me.DataTable1 = New System.Data.DataTable()
        Me.DataTable2 = New System.Data.DataTable()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.btnFAMEMBEREXTRA_DELETE = New System.Windows.Forms.Button()
        Me.btnFAMEMBEREXTRA_ADD = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.DataTable3 = New System.Data.DataTable()
        Me.DataTable51 = New System.Data.DataTable()
        Me.Panel1.SuspendLayout()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable51, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(297, 325)
        Me.btnOK.Size = New System.Drawing.Size(75, 24)
        Me.btnOK.TabIndex = 208
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(377, 325)
        Me.btnCancel.Size = New System.Drawing.Size(75, 24)
        Me.btnCancel.TabIndex = 209
        '
        'lblCaption
        '
        Me.lblCaption.Location = New System.Drawing.Point(7, 17)
        '
        'btnApply
        '
        Me.btnApply.Location = New System.Drawing.Point(457, 325)
        Me.btnApply.TabIndex = 210
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(3, 0)
        Me.Panel1.Size = New System.Drawing.Size(541, 50)
        '
        'cboLink
        '
        '
        'DataTable1
        '
        Me.DataTable1.Namespace = ""
        Me.DataTable1.TableName = "COMBOBOX"
        '
        'DataTable2
        '
        Me.DataTable2.Namespace = ""
        Me.DataTable2.TableName = "COMBOBOX"
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(0, 0)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(3, 356)
        Me.Splitter1.TabIndex = 212
        Me.Splitter1.TabStop = False
        '
        'btnFAMEMBEREXTRA_DELETE
        '
        Me.btnFAMEMBEREXTRA_DELETE.Location = New System.Drawing.Point(104, 56)
        Me.btnFAMEMBEREXTRA_DELETE.Name = "btnFAMEMBEREXTRA_DELETE"
        Me.btnFAMEMBEREXTRA_DELETE.Size = New System.Drawing.Size(75, 23)
        Me.btnFAMEMBEREXTRA_DELETE.TabIndex = 7
        Me.btnFAMEMBEREXTRA_DELETE.Tag = "btnFAMEMBEREXTRA_DELETE"
        Me.btnFAMEMBEREXTRA_DELETE.Text = "Xóa"
        Me.btnFAMEMBEREXTRA_DELETE.UseVisualStyleBackColor = True
        '
        'btnFAMEMBEREXTRA_ADD
        '
        Me.btnFAMEMBEREXTRA_ADD.Location = New System.Drawing.Point(10, 56)
        Me.btnFAMEMBEREXTRA_ADD.Name = "btnFAMEMBEREXTRA_ADD"
        Me.btnFAMEMBEREXTRA_ADD.Size = New System.Drawing.Size(75, 23)
        Me.btnFAMEMBEREXTRA_ADD.TabIndex = 4
        Me.btnFAMEMBEREXTRA_ADD.Tag = "btnFAMEMBEREXTRA_ADD"
        Me.btnFAMEMBEREXTRA_ADD.Text = "Thêm mới"
        Me.btnFAMEMBEREXTRA_ADD.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Location = New System.Drawing.Point(13, 94)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(510, 198)
        Me.Panel2.TabIndex = 213
        '
        'DataTable3
        '
        Me.DataTable3.Namespace = ""
        Me.DataTable3.TableName = "COMBOBOX"
        '
        'DataTable51
        '
        Me.DataTable51.Namespace = ""
        Me.DataTable51.TableName = "COMBOBOX"
        '
        'frmFAMEMBERSEXTRA
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(544, 356)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.btnFAMEMBEREXTRA_DELETE)
        Me.Controls.Add(Me.btnFAMEMBEREXTRA_ADD)
        Me.Controls.Add(Me.Splitter1)
        Me.Name = "frmFAMEMBERSEXTRA"
        Me.Tag = "frmFAMEMBERSEXTRA"
        Me.Text = "frmFAMEMBERSEXTRA"
        Me.Controls.SetChildIndex(Me.Splitter1, 0)
        Me.Controls.SetChildIndex(Me.btnFAMEMBEREXTRA_ADD, 0)
        Me.Controls.SetChildIndex(Me.btnFAMEMBEREXTRA_DELETE, 0)
        Me.Controls.SetChildIndex(Me.cboLink, 0)
        Me.Controls.SetChildIndex(Me.btnApply, 0)
        Me.Controls.SetChildIndex(Me.btnApprv, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.Panel2, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable51, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Declare constants and variables "
    Private mv_ISSUERID As String
    Private mv_CUSTID As String
    Private mv_memberid As String
    Private mv_custodycd As String
    Public WithEvents FAMEMBERSEXTRAGrid As GridEx
    Public WithEvents FAMEMBERSEXTRAGrid2 As GridEx


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

    Public Property MEMBERID() As String
        Get
            Return mv_memberid
        End Get
        Set(ByVal Value As String)
            mv_memberid = Value
        End Set
    End Property

    Public Property CUSTODYCD() As String
        Get
            Return mv_custodycd
        End Get
        Set(ByVal Value As String)
            mv_custodycd = Value
        End Set
    End Property

#End Region


#Region " Overrides Methods "
    Public Overrides Sub OnInit()
        Dim v_ctrl As Windows.Forms.Control

        Try
            'MyBase.OnInit()
            'If (Me.ExeFlag = ExecuteFlag.AddNew Or Me.ExeFlag = ExecuteFlag.Edit) And ParentObjName = "FA.FAMEMBERSEXTRA" Then
            '    If Me.ExeFlag = ExecuteFlag.AddNew Then
            '        'Me.txtISSUERID.Text = ""
            '    End If
            '    'Me.txtISSUERID.Enabled = True
            'End If
            'Thangpv 07/07/2022 khoi tao Grid AP
            OnLoadGrid()
            'Load Resource Manager
            ResourceManager = New Resources.ResourceManager(gc_RootNamespace & "." & Me.Name & "-" & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
            LoadUserInterface(Me)

            'txtAUTOID.Visible = False
            'SGN160
            loadIssuerName()
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ResourceManager.GetString("InitDialogFailed"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub OnLoadGrid()
        'Thangpv 11/07/2022 khoi tao Grid AP
        FAMEMBERSEXTRAGrid = New GridEx
        Dim v_cmrFAMEMBERSEXTRAHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrFAMEMBERSEXTRAHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrFAMEMBERSEXTRAHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        v_cmrFAMEMBERSEXTRAHeader.Height = 32
        FAMEMBERSEXTRAGrid.Columns.Add(New Xceed.Grid.Column("BROKERNAME", GetType(System.String)))
        FAMEMBERSEXTRAGrid.Columns.Add(New Xceed.Grid.Column("EMAIL", GetType(System.String)))
        FAMEMBERSEXTRAGrid.Columns.Add(New Xceed.Grid.Column("PHONE", GetType(System.String)))
        FAMEMBERSEXTRAGrid.Columns.Add(New Xceed.Grid.Column("AUTOID", GetType(System.String)))

        FAMEMBERSEXTRAGrid.Columns("BROKERNAME").Title = "Tên môi giới"
        FAMEMBERSEXTRAGrid.Columns("EMAIL").Title = "Email"
        FAMEMBERSEXTRAGrid.Columns("PHONE").Title = "Số điện thoại"
        FAMEMBERSEXTRAGrid.Columns("AUTOID").Title = "Autoid"
        'FAMEMBERSEXTRAGrid.Columns("PHONE").Title = ResourceManager.GetString("FAMEMBERSEXTRAGrid.PHONE")

        FAMEMBERSEXTRAGrid.Columns("BROKERNAME").Width = 150
        FAMEMBERSEXTRAGrid.Columns("EMAIL").Width = 200
        FAMEMBERSEXTRAGrid.Columns("PHONE").Width = 150
        FAMEMBERSEXTRAGrid.Columns("AUTOID").Width = 0

        FAMEMBERSEXTRAGrid.Columns("BROKERNAME").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        FAMEMBERSEXTRAGrid.Columns("EMAIL").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        FAMEMBERSEXTRAGrid.Columns("PHONE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        FAMEMBERSEXTRAGrid.Columns("AUTOID").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left

        FAMEMBERSEXTRAGrid.FixedHeaderRows.Add(v_cmrFAMEMBERSEXTRAHeader)
        'Me.spcFAMEMBERSEXTRA.Panel2.Controls.Clear()
        'Me.spcFAMEMBERSEXTRA.Panel2.Controls.Add(FAMEMBERSEXTRAGrid)
        Me.Panel2.Controls.Clear()
        Me.Panel2.Controls.Add(FAMEMBERSEXTRAGrid)
        FAMEMBERSEXTRAGrid.Dock = Windows.Forms.DockStyle.Fill
        LoadFAMEMBERSEXTRA(MEMBERID)
        If ExeFlag = 0 Then
            btnFAMEMBEREXTRA_ADD.Enabled = False
            btnFAMEMBEREXTRA_DELETE.Enabled = False
        End If

       
    End Sub

    Private Sub LoadFAMEMBERSEXTRA(ByVal pv_strMEMBERID As String)
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            'If Not FAMEMBERSEXTRAGrid Is Nothing And Len(pv_strCUSTODYCD) > 0 Then
            'Clear data
            FAMEMBERSEXTRAGrid.DataRows.Clear()
            Dim v_strSQL As String = "SELECT FAM.EXTRAVAL  BROKERNAME, EMAIL, PHONE, FAM.AUTOID FROM FAMEMBERSEXTRA FAM, fabrokeragextra FAB where FAM.autoid = FAB.BRKID AND FAB.memberid = '" & pv_strMEMBERID & "' and FAB.CUSTID = '" & CUSTID & "'"
            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, MyBase.LocalObject, gc_MsgTypeObj, "FA.FAMEMBERSEXTRA", gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)
            FillDataGrid(FAMEMBERSEXTRAGrid, v_strObjMsg, "")
            'End If
        Catch ex As Exception
            Throw ex
        Finally
            v_ws = Nothing
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
        '.Enabled = False
        'txtLICENSENO.Enabled = False
        'txtIDPLACE.Enabled = False
        'S?a ch? này cho t?ng form maintenance khác nhau
        If (ExeFlag = ExecuteFlag.AddNew) Then
            If ISSUERID <> "" Then
                '.Text = ISSUERID
                'Me.txtISSUERID.Enabled = False
            End If
            If CUSTID <> "" Then
                '.Text = CUSTID
                'Me.txtCUSTID.Enabled = False
                'If txtCUSTID.Text <> "" Then
                '    Dim v_xmlDocument As New Xml.XmlDocument
                '    Dim v_nodeList As Xml.XmlNodeList
                '    Dim v_int, v_intCount As Integer
                '    Dim v_strFULLNAME, v_strIDDATE, v_strIDPLACE, v_strIDEXPIRED As String
                '    Dim v_strFLDNAME, v_strVALUE, v_strIDCODE As String
                '    Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery

                '    Dim v_strCmdInquiry As String = "Select FULLNAME,IDCODE,IDPLACE,IDEXPIRED,IDDATE from CFMAST WHERE CUSTID ='" & txtCUSTID.Text & "' "
                '    Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, "SA.ALLCODE", gc_ActionInquiry, v_strCmdInquiry)
                '    v_ws.Message(v_strObjMsg)
                '    v_xmlDocument.LoadXml(v_strObjMsg)
                '    v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                '    For v_intCount = 0 To v_nodeList.Count - 1
                '        For v_int = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                '            With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                '                v_strFLDNAME = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("fldname").Value.Trim()
                '                v_strVALUE = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("oldval").Value.Trim()

                '                Select Case v_strFLDNAME
                '                    Case "FULLNAME"
                '                        v_strFULLNAME = v_strVALUE
                '                    Case "IDCODE"
                '                        v_strIDCODE = v_strVALUE
                '                    Case "IDDATE"
                '                        v_strIDDATE = v_strVALUE
                '                    Case "IDPLACE"
                '                        v_strIDPLACE = v_strVALUE
                '                    Case "IDEXPIRED"
                '                        v_strIDEXPIRED = v_strVALUE

                '                End Select
                '            End With
                '        Next
                '    Next
                'txtFULLNAME.Text = v_strFULLNAME
                'txtLICENSENO.Text = v_strIDCODE
                'txtIDPLACE.Text = v_strIDPLACE
                'dtpIDEXPIRED.Value = DDMMYYYY_SystemDate(v_strIDEXPIRED)
                'dtpIDDATE.Value = DDMMYYYY_SystemDate(v_strIDDATE)
                'dtpIDEXPIRED.Enabled = False
                'dtpIDDATE.Enabled = False
            End If

        End If
        'ElseIf (ExeFlag = ExecuteFlag.Edit) Then
        'txtAUTOID.Enabled = False

        'If ISSUERID <> "" Then
        '    Me.txtISSUERID.Text = ISSUERID
        '    Me.txtISSUERID.Enabled = False
        'End If
        'If CUSTID <> "" Then
        '    Me.txtCUSTID.Enabled = False
        'End If
        'dtpIDEXPIRED.Enabled = False
        'dtpIDDATE.Enabled = False
        '' txtACTYPE.Enabled = False
        'End If





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


    Private Sub txtISSUERID_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        'SGN160
        loadIssuerName()
    End Sub

    Private Sub loadIssuerName()

        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_int, v_intCount As Integer
        Dim v_strFULLNAME As String
        Dim v_strFLDNAME, v_strVALUE, v_strIDCODE As String
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery

        'Dim v_strCmdInquiry As String = "SELECT FULLNAME FROM ISSUERS WHERE ISSUERID = '" & Me.txtISSUERID.Text.Trim & "' "
        'Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, "SA.ALLCODE", gc_ActionInquiry, v_strCmdInquiry)
        'v_ws.Message(v_strObjMsg)
        'v_xmlDocument.LoadXml(v_strObjMsg)
        'v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
        'For v_intCount = 0 To v_nodeList.Count - 1
        '    For v_int = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
        '        With v_nodeList.Item(v_intCount).ChildNodes(v_int)
        '            v_strFLDNAME = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("fldname").Value.Trim()
        '            v_strVALUE = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("oldval").Value.Trim()

        '            Select Case v_strFLDNAME
        '                Case "FULLNAME"
        '                    Me.txtISSUENAME.Text = v_strVALUE
        '            End Select
        '        End With
        '    Next
        'Next

    End Sub





    'Public Sub GetDataForGrid(ByVal vTab As Integer)
    '    Dim v_strCmdInquiry, v_strFilter, v_strObjMsg, v_strCmdSQL, v_strClause As String
    '    Dim v_ws As New BDSDeliveryManagement


    '    Select Case vTab
    '        Case 0

    '            v_strCmdInquiry = "select BROKERNAME, EMAIL, PHONE, AUTOID from FAMEMBERSEXTRA where memberid = '" & MEMBERID & "'"

    '            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, "N", gc_MsgTypeObj, OBJNAME_OD_ODMAST, gc_ActionInquiry, v_strCmdInquiry)
    '            v_ws.Message(v_strObjMsg)

    '            FillDataGrid(FAMEMBERSEXTRAGrid, v_strObjMsg, "")
    '            'If SendReq.DataRows.Count > 0 Then
    '            '    SendReq.CurrentRow = SendReq.DataRows(0)
    '            '    SendReq.SelectedRows.Clear()
    '            '    SendReq.SelectedRows.Add(SendReq.CurrentRow)
    '            'End If
    '        Case 1
    '            v_strCmdInquiry = "select extraval BROKERNAME, EMAIL, PHONE, fam.AUTOID from FAMEMBERSEXTRA fam, fabrokeragextra fab where fam.autoid = fab.autoid and fab.custodycd = '" & CUSTODYCD & "'"

    '            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, "N", gc_MsgTypeObj, OBJNAME_OD_ODMAST, gc_ActionInquiry, v_strCmdInquiry)
    '            v_ws.Message(v_strObjMsg)

    '            FillDataGrid(FAMEMBERSEXTRAGrid2, v_strObjMsg, "")
    '            'If RecReq.DataRows.Count > 0 Then
    '            '    RecReq.CurrentRow = RecReq.DataRows(0)
    '            '    RecReq.SelectedRows.Clear()
    '            '    RecReq.SelectedRows.Add(RecReq.CurrentRow)
    '            'End If

    '    End Select

    'End Sub

    Private Sub btnFAMEMBEREXTRA_ADD_Click(sender As Object, e As EventArgs) Handles btnFAMEMBEREXTRA_ADD.Click
        Dim v_strCmdSQL, v_strClause, v_strObjMsg, v_strMemberid, v_strBrokerName, v_strEmail, v_strPhone, v_strCustodycd, v_strAutoid As String
        Dim v_lngErrorCode As Long
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery

        'v_strMemberid = MEMBERID
        'v_strCustodycd = CUSTODYCD
        'v_strAutoid = Trim(CType(FAMEMBERSEXTRAGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value)
        'v_strBrokerName = Trim(CType(FAMEMBERSEXTRAGrid.CurrentRow, Xceed.Grid.DataRow).Cells("BROKERNAME").Value)
        'v_strEmail = Trim(CType(FAMEMBERSEXTRAGrid.CurrentRow, Xceed.Grid.DataRow).Cells("EMAIL").Value)
        'v_strPhone = Trim(CType(FAMEMBERSEXTRAGrid.CurrentRow, Xceed.Grid.DataRow).Cells("PHONE").Value)

        ''For Each item In Trim(CType(FAMEMBERSEXTRAGrid.DataRows, Xceed.Grid.DataRow)

        ''Next

        'v_strCmdSQL = "INSERT INTO fabrokeragextra(AUTOID, MEMBERID, CUSTODYCD) VALUES('" & v_strAutoid & "', '" & v_strMemberid & "', '" & CUSTODYCD & "')"
        'v_strClause = v_strCmdSQL
        'v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, v_strCmdSQL, v_strClause, "CreateOrderCustodyChange", , , , )
        'v_lngErrorCode = v_ws.Message(v_strObjMsg)

        'If v_lngErrorCode = 0 Then
        '    MessageBox.Show("THÀNH CÔNG")
        'Else
        '    MessageBox.Show("THẤT BẠI")
        'End If



       Dim v_frm As New frmSearch(UserLanguage)
        Dim v_dtrCustodycdname As String = "CUSTODYCD"
        Try

            v_frm.BusDate = Me.BusDate
            v_frm.TableName = "FABROKERAGEXTRA"
            v_frm.ModuleCode = "CF"
            v_frm.AuthCode = "NYNNYYYNNN" 'NYNNYYYNNN 
            v_frm.CMDTYPE = "V"
            v_frm.IsLocalSearch = gc_IsNotLocalMsg
            v_frm.SearchOnInit = False
            v_frm.BranchId = Me.BranchId
            v_frm.TellerId = Me.TellerId
            v_frm.LinkValue = MEMBERID
            v_frm.CUSTID = CUSTID
            v_frm.CUSTODYCD = CUSTODYCD
            v_frm.ParentObjName = Me.ObjectName
            v_frm.ParentClause = "CUSTID " & "= '" & CUSTID & "'"
            v_frm.ShowDialog()
            'If (pv_intExecFlag <> ExecuteFlag.View) Then
            '    LoadFABROKERAGE(Me.txtCUSTODYCD.Text)
            'End If
            LoadFAMEMBERSEXTRA(MEMBERID)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_frm.Dispose()
        End Try
    End Sub

    Private Sub btnFAMEMBEREXTRA_DELETE_Click(sender As Object, e As EventArgs) Handles btnFAMEMBEREXTRA_DELETE.Click
        Dim v_strObjMsg, v_strErrorSource, v_strErrorMessage, v_strClause, v_strParentClause, v_strSQL As String
        Dim v_ws As New BDSDeliveryManagement
        Dim v_lngErrorCode As Long = ERR_SYSTEM_OK
        Dim v_frm As New frmSearch(UserLanguage)
        Dim v_dtrCustodycdname As String = "CUSTODYCD"
        Try

            If CType(FAMEMBERSEXTRAGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value = -1 Then
                'MsgBox(ResourceManager.GetString("TEMPLATE_AUTOID_INVALID"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            Else

                v_strClause = "CUSTODYCD='" & CUSTODYCD & "' and BRKID = " & Trim(CType(FAMEMBERSEXTRAGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value)
                'v_strSQL = "UPDATE FABROKERAGE SET STATUS='C' WHERE " & v_strClause & ""
                'v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, "FA.FABROKERAGE", gc_ActionInquiry, v_strSQL)
                v_strParentClause = "CUSTID " & "= '" & CUSTID & "'"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, "FA.FABROKERAGEXTRA", gc_ActionDelete, , v_strClause, , , , , , , , Me.ObjectName, v_strParentClause)
                v_ws.Message(v_strObjMsg)
                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)

                If v_lngErrorCode <> 0 Then
                    'Update mouse pointer
                    Cursor.Current = Cursors.Default
                    MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                    Exit Sub
                Else
                    Cursor.Current = Cursors.Default
                    MsgBox(ResourceManager.GetString("DelSuccess"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                    'LoadTemplates(Me.txtCUSTID.Text)
                End If
            End If
            LoadFAMEMBERSEXTRA(MEMBERID)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class
