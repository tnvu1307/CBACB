Imports CommonLibrary
Imports AppCore
Imports System.Text.RegularExpressions

Public Class frmEMAILREPORT
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
    Friend WithEvents lblREGISTTYPE As System.Windows.Forms.Label
    Friend WithEvents cboREGISTTYPE As AppCore.ComboBoxEx
    Friend WithEvents gbINFORBANK As System.Windows.Forms.GroupBox
    Friend WithEvents DataTable9 As System.Data.DataTable
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents DataTable10 As System.Data.DataTable
    Friend WithEvents DataTable1 As System.Data.DataTable
    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents DataTable42 As System.Data.DataTable
    Friend WithEvents DataTable15 As System.Data.DataTable
    Friend WithEvents txtCustid As System.Windows.Forms.TextBox
    Friend WithEvents txtAUTOID As System.Windows.Forms.TextBox



    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEMAILREPORT))
        Me.lblREGISTTYPE = New System.Windows.Forms.Label()
        Me.cboREGISTTYPE = New AppCore.ComboBoxEx()
        Me.gbINFORBANK = New System.Windows.Forms.GroupBox()
        Me.txtAUTOID = New System.Windows.Forms.TextBox()
        Me.txtCustid = New System.Windows.Forms.TextBox()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.DataTable1 = New System.Data.DataTable()
        Me.DataTable42 = New System.Data.DataTable()
        Me.DataTable15 = New System.Data.DataTable()
        Me.Panel1.SuspendLayout()
        Me.gbINFORBANK.SuspendLayout()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable42, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable15, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(312, 192)
        Me.btnOK.TabIndex = 0
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(472, 192)
        Me.btnCancel.TabIndex = 2
        '
        'btnApply
        '
        Me.btnApply.Location = New System.Drawing.Point(392, 192)
        Me.btnApply.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(593, 50)
        '
        'cboLink
        '
        '
        'lblREGISTTYPE
        '
        Me.lblREGISTTYPE.AutoSize = True
        Me.lblREGISTTYPE.Location = New System.Drawing.Point(7, 17)
        Me.lblREGISTTYPE.Name = "lblREGISTTYPE"
        Me.lblREGISTTYPE.Size = New System.Drawing.Size(71, 13)
        Me.lblREGISTTYPE.TabIndex = 15
        Me.lblREGISTTYPE.Tag = "REGISTTYPE"
        Me.lblREGISTTYPE.Text = "Loại đăng ký:"
        '
        'cboREGISTTYPE
        '
        Me.cboREGISTTYPE.DisplayMember = "DISPLAY"
        Me.cboREGISTTYPE.FormattingEnabled = True
        Me.cboREGISTTYPE.Location = New System.Drawing.Point(90, 14)
        Me.cboREGISTTYPE.Name = "cboREGISTTYPE"
        Me.cboREGISTTYPE.Size = New System.Drawing.Size(116, 21)
        Me.cboREGISTTYPE.TabIndex = 1
        Me.cboREGISTTYPE.Tag = "REGISTTYPE"
        Me.cboREGISTTYPE.ValueMember = "VALUE"
        '
        'gbINFORBANK
        '
        Me.gbINFORBANK.Controls.Add(Me.txtAUTOID)
        Me.gbINFORBANK.Controls.Add(Me.txtCustid)
        Me.gbINFORBANK.Controls.Add(Me.lblEmail)
        Me.gbINFORBANK.Controls.Add(Me.txtEmail)
        Me.gbINFORBANK.Controls.Add(Me.lblREGISTTYPE)
        Me.gbINFORBANK.Controls.Add(Me.cboREGISTTYPE)
        Me.gbINFORBANK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbINFORBANK.Location = New System.Drawing.Point(0, 48)
        Me.gbINFORBANK.Name = "gbINFORBANK"
        Me.gbINFORBANK.Size = New System.Drawing.Size(581, 138)
        Me.gbINFORBANK.TabIndex = 201
        Me.gbINFORBANK.TabStop = False
        Me.gbINFORBANK.Tag = "gbINFORBANK"
        '
        'txtAUTOID
        '
        Me.txtAUTOID.Location = New System.Drawing.Point(264, 95)
        Me.txtAUTOID.Name = "txtAUTOID"
        Me.txtAUTOID.Size = New System.Drawing.Size(140, 21)
        Me.txtAUTOID.TabIndex = 211
        Me.txtAUTOID.Tag = "AUTOID"
        Me.txtAUTOID.Visible = False
        '
        'txtCustid
        '
        Me.txtCustid.Location = New System.Drawing.Point(264, 56)
        Me.txtCustid.Name = "txtCustid"
        Me.txtCustid.Size = New System.Drawing.Size(140, 21)
        Me.txtCustid.TabIndex = 210
        Me.txtCustid.Tag = "CUSTID"
        Me.txtCustid.Visible = False
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Location = New System.Drawing.Point(223, 17)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(35, 13)
        Me.lblEmail.TabIndex = 209
        Me.lblEmail.Tag = "EMAIL"
        Me.lblEmail.Text = "Email:"
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(264, 14)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(311, 21)
        Me.txtEmail.TabIndex = 201
        Me.txtEmail.Tag = "EMAIL"
        '
        'DataTable1
        '
        Me.DataTable1.Namespace = ""
        Me.DataTable1.TableName = "COMBOBOX"
        '
        'DataTable42
        '
        Me.DataTable42.Namespace = ""
        Me.DataTable42.TableName = "COMBOBOX"
        '
        'DataTable15
        '
        Me.DataTable15.Namespace = ""
        Me.DataTable15.TableName = "COMBOBOX"
        '
        'frmEMAILREPORT
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(593, 221)
        Me.Controls.Add(Me.gbINFORBANK)
        Me.Name = "frmEMAILREPORT"
        Me.Tag = "frmEMAILREPORT"
        Me.Text = ""
        Me.Controls.SetChildIndex(Me.gbINFORBANK, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.btnApply, 0)
        Me.Controls.SetChildIndex(Me.cboLink, 0)
        Me.Controls.SetChildIndex(Me.btnApprv, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.gbINFORBANK.ResumeLayout(False)
        Me.gbINFORBANK.PerformLayout()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable42, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable15, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private mv_CustomerId As String
    Private mv_Custodycd As String
    Private mv_Afacctno As String
    Private mv_acctno As String
    Private v_strRESULT As String
    Private v_strAUTOID As String
#Region " Overrides "
    Public Property CustomerId() As String
        Get
            Return mv_CustomerId
        End Get
        Set(ByVal Value As String)
            mv_CustomerId = Value
        End Set
    End Property
    Public Property Custodycd() As String
        Get
            Return mv_Custodycd
        End Get
        Set(ByVal Value As String)
            mv_Custodycd = Value
        End Set
    End Property
    Public Property acctno() As String
        Get
            Return mv_acctno
        End Get
        Set(ByVal Value As String)
            mv_acctno = Value
        End Set
    End Property
    Public Property Afacctno() As String
        Get
            Return mv_Afacctno
        End Get
        Set(ByVal Value As String)
            mv_Afacctno = Value
        End Set
    End Property
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
    Public Overrides Sub OnInit()
        Dim v_ctrl As Windows.Forms.Control

        Try
            MyBase.OnInit()
            'Load Resource Manager
            ResourceManager = New Resources.ResourceManager(gc_RootNamespace & "." & "frmEMAILREPORT" & "-" & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
            LoadUserInterface(Me)
            txtCustid.Visible = False
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ResourceManager.GetString("InitDialogFailed"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub
    Public Overrides Sub LoadUserInterface(ByRef pv_ctrl As System.Windows.Forms.Control)
        MyBase.LoadUserInterface(pv_ctrl)
        Dim v_strCmdSQL, v_strObjMsg, v_strFLDNAME, v_strVALUE, v_strMARGINTYPE, v_strCOREBANK, v_strACTYPE, v_strISTRFBUY As String
        Dim v_ws As New BDSDeliveryManagement
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Try

            If (ExeFlag = ExecuteFlag.AddNew) Then
                txtCustid.Text = CustomerId
                If cboREGISTTYPE.SelectedValue = "CUS" Then
                    v_strCmdSQL = "select EMAIL,SEQ_EMAILREPORT.nextval AUTOID from cfmast where CUSTID = '" & CustomerId & "' and status <> 'C'"
                ElseIf cboREGISTTYPE.SelectedValue = "GCB" Then
                    v_strCmdSQL = "SELECT FA.EMAIL,SEQ_EMAILREPORT.nextval AUTOID  FROM FAMEMBERS FA,CFMAST CF WHERE FA.AUTOID  = CF.gcbid  AND FA.roles = 'GCB' AND CF.CUSTID = '" & CustomerId & "' and status <> 'C'"
                Else
                    v_strCmdSQL = "SELECT FA.EMAIL,SEQ_EMAILREPORT.nextval AUTOID  FROM FAMEMBERS FA,CFMAST CF WHERE FA.AUTOID  = CF.amcid AND FA.roles = 'AMC'  AND CF.CUSTID = '" & CustomerId & "' and status <> 'C'"
                End If
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
                v_ws.Message(v_strObjMsg)
                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                For v_intCount As Integer = 0 To v_nodeList.Count - 1
                    For v_int As Integer = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                        With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                            v_strFLDNAME = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("fldname").Value.Trim()
                            v_strVALUE = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("oldval").Value.Trim()
                            If v_strFLDNAME = "EMAIL" Then
                                v_strRESULT = v_strVALUE
                            End If
                            If v_strFLDNAME = "AUTOID" Then
                                v_strAUTOID = v_strVALUE

                            End If
                        End With
                    Next
                Next
                txtAUTOID.Text = v_strAUTOID
            End If
        Catch ex As Exception
            Throw ex
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

    'Public Overrides Sub FillData()
    '    Dim v_strFilter As String
    '    Dim v_strFLDNAME, v_strValue As String
    '    Dim v_strFieldType, v_strDataType As String
    '    Dim v_blnRiskFld As Boolean
    '    Dim v_ctrl As Windows.Forms.Control

    '    Try
    '        v_strFilter = "REFCASAACCT = '" & acctno & "' AND AFACCTNO = '" & Afacctno & "'"

    '        Dim v_strCmdInquiry As String = "SELECT * FROM " & TableName & " WHERE " & v_strFilter

    '        Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionInquiry, v_strCmdInquiry)
    '        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
    '        v_ws.Message(v_strObjMsg)

    '        Dim v_xmlDocument As New Xml.XmlDocument
    '        Dim v_nodeList As Xml.XmlNodeList

    '        v_xmlDocument.LoadXml(v_strObjMsg)
    '        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

    '        If v_nodeList.Count = 1 Then
    '            For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
    '                With v_nodeList.Item(0).ChildNodes(i)
    '                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
    '                    v_strValue = .InnerText.ToString
    '                End With

    '                For j As Integer = 0 To UBound(mv_arrObjFields) - 1
    '                    If mv_arrObjFields(j).FieldName = Trim(v_strFLDNAME) Then
    '                        v_strFieldType = mv_arrObjFields(j).FieldType
    '                        v_strDataType = mv_arrObjFields(j).DataType
    '                        v_blnRiskFld = mv_arrObjFields(j).RiskField
    '                        Exit For
    '                    End If
    '                Next

    '                SetControlValue(Me, v_strFLDNAME, v_strFieldType, v_strValue, v_strDataType)
    '                If Me.ExeFlag = ExecuteFlag.Edit Then
    '                    If Me.IsRiskManagement Then
    '                        SetRiskField(Me, v_strFLDNAME, v_strFieldType, v_blnRiskFld)
    '                    End If
    '                End If
    '            Next
    '        End If
    '    Catch ex As Exception
    '        LogError.Write("Error source: " & ex.Source & vbNewLine _
    '                     & "Error code: System error!" & vbNewLine _
    '                     & "Error message: " & ex.Message, EventLogEntryType.Error)
    '        MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
    '    End Try
    'End Sub
    Public Overrides Sub OnSave()
        Dim v_strFilter As String
        Dim v_strFLDNAME, v_strValue As String
        Dim v_strFieldType, v_strDataType As String
        Dim v_ctrl As Windows.Forms.Control
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
                    Dim v_strClause As String
                    Select Case KeyFieldType
                        Case "C"
                            v_strClause = KeyFieldName & " = '" & KeyFieldValue & "'"
                        Case "D"
                            v_strClause = KeyFieldName & " = TO_DATE('" & KeyFieldValue & "', '" & gc_FORMAT_DATE & "')"
                        Case "N"
                            v_strClause = KeyFieldName & " = " & KeyFieldValue.ToString()
                    End Select
                    'v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionAdhoc, , v_strClause, "ADD", gc_AutoIdUsed, , , , , , ParentObjName, ParentClause)
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

                    'Kiểm tra thông tin và xử lý lỗi (nếu có) từ message trả về
                    Dim v_strErrorSource, v_strErrorMessage As String
                    Select Case KeyFieldType
                        Case "C"
                            v_strClause = KeyFieldName & " = '" & KeyFieldValue & "'"
                        Case "D"
                            v_strClause = KeyFieldName & " = TO_DATE('" & KeyFieldValue & "', '" & gc_FORMAT_DATE & "')"
                        Case "N"
                            v_strClause = KeyFieldName & " = " & KeyFieldValue.ToString()
                    End Select
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionEdit, , v_strClause, , , , , , , , ParentObjName, ParentClause)

                    'v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionAdhoc, , v_strClause, "EDIT", gc_AutoIdUsed, , , , , , ParentObjName, ParentClause)
                    BuildXMLObjData(mv_dsInput, v_strObjMsg, mv_dsOldInput, ExecuteFlag.Edit)

                    Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                    Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)
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
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub




#End Region

    Public Sub Load_Email()
        Dim v_strCmdSQL, v_strObjMsg, v_strFLDNAME, v_strVALUE, v_strMARGINTYPE, v_strCOREBANK, v_strACTYPE, v_strISTRFBUY As String
        Dim v_ws As New BDSDeliveryManagement
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Try

            If (ExeFlag = ExecuteFlag.AddNew) Then
                txtCustid.Text = CustomerId
                If cboREGISTTYPE.SelectedValue = "CUS" Then
                    v_strCmdSQL = "select EMAIL,SEQ_EMAILREPORT.nextval AUTOID from cfmast where CUSTID = '" & CustomerId & "' and status <> 'C'"
                ElseIf cboREGISTTYPE.SelectedValue = "GCB" Then
                    v_strCmdSQL = "SELECT FA.EMAIL,SEQ_EMAILREPORT.nextval AUTOID  FROM FAMEMBERS FA,CFMAST CF WHERE FA.AUTOID  = CF.gcbid  AND FA.roles = 'GCB' AND CF.CUSTID = '" & CustomerId & "' and cf.status <> 'C'"
                Else
                    v_strCmdSQL = "SELECT FA.EMAIL,SEQ_EMAILREPORT.nextval AUTOID  FROM FAMEMBERS FA,CFMAST CF WHERE FA.AUTOID  = CF.amcid AND FA.roles = 'AMC'  AND CF.CUSTID = '" & CustomerId & "' and cf.status <> 'C'"
                End If
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
                v_ws.Message(v_strObjMsg)
                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                For v_intCount As Integer = 0 To v_nodeList.Count - 1
                    For v_int As Integer = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                        With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                            v_strFLDNAME = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("fldname").Value.Trim()
                            v_strVALUE = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("oldval").Value.Trim()
                            If v_strFLDNAME = "EMAIL" Then
                                v_strRESULT = v_strVALUE
                            End If
                            If v_strFLDNAME = "AUTOID" Then
                                v_strAUTOID = v_strVALUE

                            End If
                        End With
                    Next
                Next
                txtAUTOID.Text = v_strAUTOID
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub cboREGISTTYPE_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboREGISTTYPE.SelectedValueChanged
        If cboREGISTTYPE.SelectedValue Is DBNull.Value = False Then
            If (ExeFlag = ExecuteFlag.AddNew) Then
                'If cboREGISTTYPE.SelectedValue = "CUS" Then
                '    txtEmail.Enabled = True
                '    txtEmail.Text = v_strRESULT
                'Else
                '    txtEmail.Enabled = False
                '    txtEmail.Text = ""
                'End If
                'trung.luu: 16-11-2020 SHBVNEX-174 
                Load_Email()
                txtEmail.Enabled = True
                txtEmail.Text = v_strRESULT
            End If
        End If
    End Sub

    Private Sub txtEmail_Leave(sender As Object, e As EventArgs) Handles txtEmail.Leave
        'Dim regex As Regex = New Regex("^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
        'Dim isValid As Boolean = regex.IsMatch(txtEmail.Text.Trim)
        'If Not isValid Then
        '    MessageBox.Show("Invalid Email.")
        'End If
        If Trim(Me.txtEmail.Text).Length > 0 Then
            If InStr(Trim(Me.txtEmail.Text), " ") > 0 Or InStr(Trim(Me.txtEmail.Text), "@") <= 0 Or InStr(Mid(Trim(Me.txtEmail.Text), InStr(Trim(Me.txtEmail.Text), "@") + 1), ".") <= 0 Then
                MsgBox(ResourceManager.GetString("msgINVALIDEMAILFORMAT"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                Me.txtEmail.Focus()
                Exit Sub
            End If
        End If
    End Sub
End Class
