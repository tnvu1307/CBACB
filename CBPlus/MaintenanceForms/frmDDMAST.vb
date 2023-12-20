Imports CommonLibrary
Imports AppCore

Public Class frmDDMAST
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
    Friend WithEvents lblAccountype As System.Windows.Forms.Label
    Friend WithEvents lblAccountbank As System.Windows.Forms.Label
    Friend WithEvents lblACCSETTLEMENT As System.Windows.Forms.Label
    Friend WithEvents lblCCYBANK As System.Windows.Forms.Label
    Friend WithEvents lblOPNDATE As System.Windows.Forms.Label
    Friend WithEvents cboACCOUNTTYPE As AppCore.ComboBoxEx
    Friend WithEvents cboCCYBANK As AppCore.ComboBoxEx
    Friend WithEvents cboACCSETTLEMENT As AppCore.ComboBoxEx
    Friend WithEvents txtACCOUNTBANK As System.Windows.Forms.TextBox
    Friend WithEvents gbINFORBANK As System.Windows.Forms.GroupBox
    Friend WithEvents DataTable9 As System.Data.DataTable
    Friend WithEvents lblCUSTID As System.Windows.Forms.Label
    Friend WithEvents txtCUSTID As System.Windows.Forms.TextBox
    Friend WithEvents DataTable10 As System.Data.DataTable
    Friend WithEvents lblAFACCTNO As System.Windows.Forms.Label
    Friend WithEvents txtCUSTODYCD As System.Windows.Forms.TextBox
    Friend WithEvents lblCUSTODYCD As System.Windows.Forms.Label
    Friend WithEvents txtAFACCTNO As System.Windows.Forms.TextBox
    Friend WithEvents cboSTATUS As AppCore.ComboBoxEx
    Friend WithEvents lblSTATUS As System.Windows.Forms.Label
    Friend WithEvents DataTable1 As System.Data.DataTable
    Friend WithEvents txtOPNDATE As AppCore.FlexMaskEditBox
    Friend WithEvents cboAutoTransfer As AppCore.ComboBoxEx
    Friend WithEvents lblAutoTransfer As System.Windows.Forms.Label
    Friend WithEvents DataTable42 As System.Data.DataTable
    Friend WithEvents DataTable2 As System.Data.DataTable
    Friend WithEvents lblPAYMENTFEE As System.Windows.Forms.Label
    Friend WithEvents cboPAYMENTFEE As AppCore.ComboBoxEx



    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDDMAST))
        Me.lblAccountype = New System.Windows.Forms.Label()
        Me.lblAccountbank = New System.Windows.Forms.Label()
        Me.lblACCSETTLEMENT = New System.Windows.Forms.Label()
        Me.lblCCYBANK = New System.Windows.Forms.Label()
        Me.lblOPNDATE = New System.Windows.Forms.Label()
        Me.cboACCOUNTTYPE = New AppCore.ComboBoxEx()
        Me.cboCCYBANK = New AppCore.ComboBoxEx()
        Me.cboACCSETTLEMENT = New AppCore.ComboBoxEx()
        Me.txtACCOUNTBANK = New System.Windows.Forms.TextBox()
        Me.gbINFORBANK = New System.Windows.Forms.GroupBox()
        Me.cboAutoTransfer = New AppCore.ComboBoxEx()
        Me.lblAutoTransfer = New System.Windows.Forms.Label()
        Me.txtOPNDATE = New AppCore.FlexMaskEditBox()
        Me.txtAFACCTNO = New System.Windows.Forms.TextBox()
        Me.lblAFACCTNO = New System.Windows.Forms.Label()
        Me.txtCUSTODYCD = New System.Windows.Forms.TextBox()
        Me.lblCUSTODYCD = New System.Windows.Forms.Label()
        Me.lblCUSTID = New System.Windows.Forms.Label()
        Me.txtCUSTID = New System.Windows.Forms.TextBox()
        Me.cboSTATUS = New AppCore.ComboBoxEx()
        Me.lblSTATUS = New System.Windows.Forms.Label()
        Me.DataTable1 = New System.Data.DataTable()
        Me.DataTable42 = New System.Data.DataTable()
        Me.DataTable2 = New System.Data.DataTable()
        Me.cboPAYMENTFEE = New AppCore.ComboBoxEx()
        Me.lblPAYMENTFEE = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.gbINFORBANK.SuspendLayout()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable42, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(310, 223)
        Me.btnOK.TabIndex = 0
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(472, 223)
        Me.btnCancel.TabIndex = 2
        '
        'btnApply
        '
        Me.btnApply.Location = New System.Drawing.Point(391, 223)
        Me.btnApply.TabIndex = 1
        '
        'cboLink
        '
        '
        'lblAccountype
        '
        Me.lblAccountype.AutoSize = True
        Me.lblAccountype.Location = New System.Drawing.Point(12, 44)
        Me.lblAccountype.Name = "lblAccountype"
        Me.lblAccountype.Size = New System.Drawing.Size(77, 13)
        Me.lblAccountype.TabIndex = 15
        Me.lblAccountype.Tag = "ACCOUNTTYPE"
        Me.lblAccountype.Text = "Loại tài khoản:"
        '
        'lblAccountbank
        '
        Me.lblAccountbank.AutoSize = True
        Me.lblAccountbank.Location = New System.Drawing.Point(12, 72)
        Me.lblAccountbank.Name = "lblAccountbank"
        Me.lblAccountbank.Size = New System.Drawing.Size(55, 13)
        Me.lblAccountbank.TabIndex = 16
        Me.lblAccountbank.Tag = "REFCASAACCT"
        Me.lblAccountbank.Text = "Số TK NH:"
        '
        'lblACCSETTLEMENT
        '
        Me.lblACCSETTLEMENT.AutoSize = True
        Me.lblACCSETTLEMENT.Location = New System.Drawing.Point(329, 17)
        Me.lblACCSETTLEMENT.Name = "lblACCSETTLEMENT"
        Me.lblACCSETTLEMENT.Size = New System.Drawing.Size(83, 13)
        Me.lblACCSETTLEMENT.TabIndex = 17
        Me.lblACCSETTLEMENT.Tag = "ISDEFAULT"
        Me.lblACCSETTLEMENT.Text = "TK mặc định TT:"
        '
        'lblCCYBANK
        '
        Me.lblCCYBANK.AutoSize = True
        Me.lblCCYBANK.Location = New System.Drawing.Point(329, 44)
        Me.lblCCYBANK.Name = "lblCCYBANK"
        Me.lblCCYBANK.Size = New System.Drawing.Size(64, 13)
        Me.lblCCYBANK.TabIndex = 18
        Me.lblCCYBANK.Tag = "CCYCD"
        Me.lblCCYBANK.Text = "Loại tiền tệ:"
        '
        'lblOPNDATE
        '
        Me.lblOPNDATE.AutoSize = True
        Me.lblOPNDATE.Location = New System.Drawing.Point(329, 72)
        Me.lblOPNDATE.Name = "lblOPNDATE"
        Me.lblOPNDATE.Size = New System.Drawing.Size(53, 13)
        Me.lblOPNDATE.TabIndex = 19
        Me.lblOPNDATE.Tag = "OPNDATE"
        Me.lblOPNDATE.Text = "Ngày mở:"
        '
        'cboACCOUNTTYPE
        '
        Me.cboACCOUNTTYPE.DisplayMember = "DISPLAY"
        Me.cboACCOUNTTYPE.FormattingEnabled = True
        Me.cboACCOUNTTYPE.Location = New System.Drawing.Point(102, 41)
        Me.cboACCOUNTTYPE.Name = "cboACCOUNTTYPE"
        Me.cboACCOUNTTYPE.Size = New System.Drawing.Size(204, 21)
        Me.cboACCOUNTTYPE.TabIndex = 1
        Me.cboACCOUNTTYPE.Tag = "ACCOUNTTYPE"
        Me.cboACCOUNTTYPE.ValueMember = "VALUE"
        '
        'cboCCYBANK
        '
        Me.cboCCYBANK.DisplayMember = "DISPLAY"
        Me.cboCCYBANK.FormattingEnabled = True
        Me.cboCCYBANK.Location = New System.Drawing.Point(433, 41)
        Me.cboCCYBANK.Name = "cboCCYBANK"
        Me.cboCCYBANK.Size = New System.Drawing.Size(142, 21)
        Me.cboCCYBANK.TabIndex = 2
        Me.cboCCYBANK.Tag = "CCYCD"
        Me.cboCCYBANK.ValueMember = "VALUE"
        '
        'cboACCSETTLEMENT
        '
        Me.cboACCSETTLEMENT.DisplayMember = "DISPLAY"
        Me.cboACCSETTLEMENT.FormattingEnabled = True
        Me.cboACCSETTLEMENT.Location = New System.Drawing.Point(433, 14)
        Me.cboACCSETTLEMENT.Name = "cboACCSETTLEMENT"
        Me.cboACCSETTLEMENT.Size = New System.Drawing.Size(142, 21)
        Me.cboACCSETTLEMENT.TabIndex = 0
        Me.cboACCSETTLEMENT.Tag = "ISDEFAULT"
        Me.cboACCSETTLEMENT.ValueMember = "VALUE"
        '
        'txtACCOUNTBANK
        '
        Me.txtACCOUNTBANK.Location = New System.Drawing.Point(102, 69)
        Me.txtACCOUNTBANK.Name = "txtACCOUNTBANK"
        Me.txtACCOUNTBANK.Size = New System.Drawing.Size(204, 21)
        Me.txtACCOUNTBANK.TabIndex = 3
        Me.txtACCOUNTBANK.Tag = "REFCASAACCT"
        '
        'gbINFORBANK
        '
        Me.gbINFORBANK.Controls.Add(Me.lblPAYMENTFEE)
        Me.gbINFORBANK.Controls.Add(Me.cboPAYMENTFEE)
        Me.gbINFORBANK.Controls.Add(Me.cboAutoTransfer)
        Me.gbINFORBANK.Controls.Add(Me.lblAutoTransfer)
        Me.gbINFORBANK.Controls.Add(Me.txtOPNDATE)
        Me.gbINFORBANK.Controls.Add(Me.txtAFACCTNO)
        Me.gbINFORBANK.Controls.Add(Me.lblAFACCTNO)
        Me.gbINFORBANK.Controls.Add(Me.txtCUSTODYCD)
        Me.gbINFORBANK.Controls.Add(Me.lblCUSTODYCD)
        Me.gbINFORBANK.Controls.Add(Me.lblCUSTID)
        Me.gbINFORBANK.Controls.Add(Me.txtCUSTID)
        Me.gbINFORBANK.Controls.Add(Me.lblAccountype)
        Me.gbINFORBANK.Controls.Add(Me.cboACCOUNTTYPE)
        Me.gbINFORBANK.Controls.Add(Me.cboSTATUS)
        Me.gbINFORBANK.Controls.Add(Me.cboCCYBANK)
        Me.gbINFORBANK.Controls.Add(Me.lblSTATUS)
        Me.gbINFORBANK.Controls.Add(Me.lblCCYBANK)
        Me.gbINFORBANK.Controls.Add(Me.lblAccountbank)
        Me.gbINFORBANK.Controls.Add(Me.lblOPNDATE)
        Me.gbINFORBANK.Controls.Add(Me.cboACCSETTLEMENT)
        Me.gbINFORBANK.Controls.Add(Me.lblACCSETTLEMENT)
        Me.gbINFORBANK.Controls.Add(Me.txtACCOUNTBANK)
        Me.gbINFORBANK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbINFORBANK.Location = New System.Drawing.Point(0, 48)
        Me.gbINFORBANK.Name = "gbINFORBANK"
        Me.gbINFORBANK.Size = New System.Drawing.Size(581, 163)
        Me.gbINFORBANK.TabIndex = 201
        Me.gbINFORBANK.TabStop = False
        Me.gbINFORBANK.Tag = "gbINFORBANK"
        '
        'cboAutoTransfer
        '
        Me.cboAutoTransfer.DisplayMember = "DISPLAY"
        Me.cboAutoTransfer.FormattingEnabled = True
        Me.cboAutoTransfer.Location = New System.Drawing.Point(102, 98)
        Me.cboAutoTransfer.Name = "cboAutoTransfer"
        Me.cboAutoTransfer.Size = New System.Drawing.Size(203, 21)
        Me.cboAutoTransfer.TabIndex = 208
        Me.cboAutoTransfer.Tag = "AUTOTRANSFER"
        Me.cboAutoTransfer.ValueMember = "VALUE"
        '
        'lblAutoTransfer
        '
        Me.lblAutoTransfer.AutoSize = True
        Me.lblAutoTransfer.Location = New System.Drawing.Point(12, 101)
        Me.lblAutoTransfer.Name = "lblAutoTransfer"
        Me.lblAutoTransfer.Size = New System.Drawing.Size(89, 13)
        Me.lblAutoTransfer.TabIndex = 209
        Me.lblAutoTransfer.Tag = "AUTOTRANSFER"
        Me.lblAutoTransfer.Text = "Chuyển tự động:"
        '
        'txtOPNDATE
        '
        Me.txtOPNDATE.FieldType = AppCore.FlexMaskEditBox._FieldType.DATE_
        Me.txtOPNDATE.Location = New System.Drawing.Point(433, 69)
        Me.txtOPNDATE.Mask = "99/99/9999"
        Me.txtOPNDATE.Name = "txtOPNDATE"
        Me.txtOPNDATE.PromptChar = "_"
        Me.txtOPNDATE.Size = New System.Drawing.Size(142, 21)
        Me.txtOPNDATE.TabIndex = 207
        Me.txtOPNDATE.Tag = "OPNDATE"
        '
        'txtAFACCTNO
        '
        Me.txtAFACCTNO.Location = New System.Drawing.Point(433, 165)
        Me.txtAFACCTNO.Name = "txtAFACCTNO"
        Me.txtAFACCTNO.Size = New System.Drawing.Size(142, 21)
        Me.txtAFACCTNO.TabIndex = 206
        Me.txtAFACCTNO.Tag = "AFACCTNO"
        '
        'lblAFACCTNO
        '
        Me.lblAFACCTNO.AutoSize = True
        Me.lblAFACCTNO.Location = New System.Drawing.Point(329, 168)
        Me.lblAFACCTNO.Name = "lblAFACCTNO"
        Me.lblAFACCTNO.Size = New System.Drawing.Size(76, 13)
        Me.lblAFACCTNO.TabIndex = 205
        Me.lblAFACCTNO.Tag = "AFACCTNO"
        Me.lblAFACCTNO.Text = "Số tiểu khoản:"
        '
        'txtCUSTODYCD
        '
        Me.txtCUSTODYCD.Location = New System.Drawing.Point(101, 165)
        Me.txtCUSTODYCD.Name = "txtCUSTODYCD"
        Me.txtCUSTODYCD.Size = New System.Drawing.Size(205, 21)
        Me.txtCUSTODYCD.TabIndex = 204
        Me.txtCUSTODYCD.Tag = "CUSTODYCD"
        '
        'lblCUSTODYCD
        '
        Me.lblCUSTODYCD.AutoSize = True
        Me.lblCUSTODYCD.Location = New System.Drawing.Point(13, 168)
        Me.lblCUSTODYCD.Name = "lblCUSTODYCD"
        Me.lblCUSTODYCD.Size = New System.Drawing.Size(54, 13)
        Me.lblCUSTODYCD.TabIndex = 203
        Me.lblCUSTODYCD.Tag = "CUSTODYCD"
        Me.lblCUSTODYCD.Text = "Số TK KH:"
        '
        'lblCUSTID
        '
        Me.lblCUSTID.AutoSize = True
        Me.lblCUSTID.Location = New System.Drawing.Point(12, 17)
        Me.lblCUSTID.Name = "lblCUSTID"
        Me.lblCUSTID.Size = New System.Drawing.Size(83, 13)
        Me.lblCUSTID.TabIndex = 202
        Me.lblCUSTID.Tag = "CUSTID"
        Me.lblCUSTID.Text = "Mã khách hàng:"
        '
        'txtCUSTID
        '
        Me.txtCUSTID.Location = New System.Drawing.Point(102, 14)
        Me.txtCUSTID.Name = "txtCUSTID"
        Me.txtCUSTID.Size = New System.Drawing.Size(203, 21)
        Me.txtCUSTID.TabIndex = 201
        Me.txtCUSTID.Tag = "CUSTID"
        '
        'cboSTATUS
        '
        Me.cboSTATUS.DisplayMember = "DISPLAY"
        Me.cboSTATUS.FormattingEnabled = True
        Me.cboSTATUS.Location = New System.Drawing.Point(433, 98)
        Me.cboSTATUS.Name = "cboSTATUS"
        Me.cboSTATUS.Size = New System.Drawing.Size(142, 21)
        Me.cboSTATUS.TabIndex = 2
        Me.cboSTATUS.Tag = "STATUS"
        Me.cboSTATUS.ValueMember = "VALUE"
        '
        'lblSTATUS
        '
        Me.lblSTATUS.AutoSize = True
        Me.lblSTATUS.Location = New System.Drawing.Point(329, 101)
        Me.lblSTATUS.Name = "lblSTATUS"
        Me.lblSTATUS.Size = New System.Drawing.Size(56, 13)
        Me.lblSTATUS.TabIndex = 18
        Me.lblSTATUS.Tag = "STATUS"
        Me.lblSTATUS.Text = "Trạng thái"
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
        'DataTable2
        '
        Me.DataTable2.Namespace = ""
        Me.DataTable2.TableName = "COMBOBOX"
        '
        'cboPAYMENTFEE
        '
        Me.cboPAYMENTFEE.DisplayMember = "DISPLAY"
        Me.cboPAYMENTFEE.FormattingEnabled = True
        Me.cboPAYMENTFEE.Location = New System.Drawing.Point(102, 129)
        Me.cboPAYMENTFEE.Name = "cboPAYMENTFEE"
        Me.cboPAYMENTFEE.Size = New System.Drawing.Size(203, 21)
        Me.cboPAYMENTFEE.TabIndex = 210
        Me.cboPAYMENTFEE.Tag = "PAYMENTFEE"
        Me.cboPAYMENTFEE.ValueMember = "VALUE"
        '
        'lblPAYMENTFEE
        '
        Me.lblPAYMENTFEE.AutoSize = True
        Me.lblPAYMENTFEE.Location = New System.Drawing.Point(13, 132)
        Me.lblPAYMENTFEE.Name = "lblPAYMENTFEE"
        Me.lblPAYMENTFEE.Size = New System.Drawing.Size(83, 13)
        Me.lblPAYMENTFEE.TabIndex = 211
        Me.lblPAYMENTFEE.Tag = "PAYMENTFEE"
        Me.lblPAYMENTFEE.Text = "Thanh toán phí:"
        '
        'frmDDMAST
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(594, 258)
        Me.Controls.Add(Me.gbINFORBANK)
        Me.Name = "frmDDMAST"
        Me.Tag = "frmDDMAST"
        Me.Text = "Information bank"
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
        CType(Me.DataTable2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private mv_CustomerId As String
    Private mv_Custodycd As String
    Private mv_Afacctno As String
    Private mv_acctno As String
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
                If Len(txtOPNDATE.Text) = 0 OrElse txtOPNDATE.Text.Replace("/", "").Trim.Length = 0 OrElse Not IsDateValue(txtOPNDATE.Text) Then
                    MsgBox(ResourceManager.GetString("invalidOPNDATE"), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, gc_ApplicationTitle)
                    txtOPNDATE.Focus()
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
            MsgBox(ResourceManager.GetString("InitDialogFailed"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub
    Public Overrides Sub LoadUserInterface(ByRef pv_ctrl As System.Windows.Forms.Control)
        MyBase.LoadUserInterface(pv_ctrl)
        Dim v_strCmdSQL, v_strObjMsg, v_strFLDNAME, v_strVALUE, v_strMARGINTYPE, v_strCOREBANK, v_strACTYPE, v_strISTRFBUY, v_strRESULT As String
        Dim v_ws As New BDSDeliveryManagement
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Try
            lblAFACCTNO.Visible = False
            lblCUSTODYCD.Visible = False
            cboCCYBANK.Enabled = False

            If (ExeFlag = ExecuteFlag.AddNew) Then
                txtCUSTID.Text = CustomerId
                txtAFACCTNO.Text = Afacctno
                txtCUSTODYCD.Text = Custodycd
                txtCUSTID.Enabled = False
                v_strCmdSQL = "Select COUNT(*) RESULT from DDMAST where CUSTID = '" & CustomerId & "' and isdefault = 'Y' and status <> 'C'"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
                v_ws.Message(v_strObjMsg)
                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                For v_intCount As Integer = 0 To v_nodeList.Count - 1
                    For v_int As Integer = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                        With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                            v_strFLDNAME = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("fldname").Value.Trim()
                            v_strVALUE = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("oldval").Value.Trim()
                            If v_strFLDNAME = "RESULT" Then
                                v_strRESULT = v_strVALUE
                            End If
                        End With
                    Next
                Next
                If v_strRESULT > 0 Then
                    cboACCSETTLEMENT.SelectedValue = "N"
                    cboACCSETTLEMENT.Enabled = False
                End If
                'ElseIf (ExeFlag = ExecuteFlag.Edit Or ExeFlag = ExecuteFlag.View) Then
                '    txtCUSTID.Text = CustomerId
                '    txtAFACCTNO.Text = Afacctno
                '    txtCUSTODYCD.Text = Custodycd
                '    txtCUSTID.Enabled = False
                '    v_strCmdSQL = "Select AL.CDCONTENT CCYCD from DDMAST DD, ALLCODE AL where AL.CDVAL=DD.CCYCD and AL.CDTYPE='FA' AND AL.CDNAME='CCYCD' and DD.CUSTID = '" & CustomerId & "' and DD.REFCASAACCT='" & acctno & "' and DD.status = 'A'"
                '    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
                '    v_ws.Message(v_strObjMsg)
                '    v_xmlDocument.LoadXml(v_strObjMsg)
                '    v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                '    For v_intCount As Integer = 0 To v_nodeList.Count - 1
                '        For v_int As Integer = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                '            With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                '                v_strFLDNAME = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("fldname").Value.Trim()
                '                v_strVALUE = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("oldval").Value.Trim()
                '                If v_strFLDNAME = "CCYCD" Then
                '                    v_strRESULT = v_strVALUE
                '                End If
                '            End With
                '        Next
                '    Next
                'Me.cboCCYBANK.Text = v_strRESULT
            End If
            ''Load caption của form, label caption
            'If (Me.Text.Trim() = String.Empty) Then
            '    Me.Text = ResourceManager.GetString(Me.Name)
            'End If
            'lblCaption.Text = ResourceManager.GetString(lblCaption.Tag & ExeFlag.ToString())

            'btnApply.Focus()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Public Overrides Function DoDataExchange(Optional ByVal pv_blnSaved As Boolean = False) As Boolean
        Try
            If Not ControlValidation(pv_blnSaved) Then
                Return False
            End If
            If (InStr(1, Me.txtACCOUNTBANK.Text, " ") <> 0) Then
                MsgBox(ResourceManager.GetString("checking_mistake"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
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
                    'Case ExecuteFlag.Delete
                    '    Dim v_strClause As String
                    '    Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                    '    Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)
                    '    'Kiểm tra thông tin và xử lý lỗi (nếu có) từ message trả về
                    '    Dim v_strErrorSource, v_strErrorMessage As String
                    '    Select Case KeyFieldType
                    '        Case "C"
                    '            v_strClause = KeyFieldName & " = '" & KeyFieldValue & "'"
                    '        Case "D"
                    '            v_strClause = KeyFieldName & " = TO_DATE('" & KeyFieldValue & "', '" & gc_FORMAT_DATE & "')"
                    '        Case "N"
                    '            v_strClause = KeyFieldName & " = " & KeyFieldValue.ToString()
                    '    End Select
                    '    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionAdhoc, , , "DELETE", gc_AutoIdUsed, , , , , , ParentObjName, ParentClause)
                    '    BuildXMLObjData(mv_dsInput, v_strObjMsg)
                    '    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                    '    If v_lngErrorCode <> 0 Then
                    '        'Update mouse pointer
                    '        Cursor.Current = Cursors.Default
                    '        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                    '        Exit Sub
                    '    End If

                    '    MsgBox(ResourceManager.GetString("DelSuccess"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    '    Me.DialogResult = DialogResult.OK
                    '    MyBase.OnClose()
            End Select
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub




#End Region

    Private Sub cboACCOUNTTYPE_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboACCOUNTTYPE.SelectedIndexChanged
        If Not Me.cboACCOUNTTYPE.SelectedValue Is DBNull.Value Then
            If cboACCOUNTTYPE.SelectedValue = "IICA" Or cboACCOUNTTYPE.SelectedValue = "SSTA" Then
                Me.cboCCYBANK.SelectedValue = "VND"
                Me.cboCCYBANK.Enabled = False
            Else
                'Me.cboCCYBANK.SelectedValue = "VND"
                Me.cboCCYBANK.Enabled = True
            End If
        End If
    End Sub

    Private Sub txtACCOUNTBANK_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtACCOUNTBANK.Validating
        txtACCOUNTBANK.Text = RemoveCharacter(txtACCOUNTBANK.Text)
    End Sub
    Private Function RemoveCharacter(ByVal orgStr As String) As String
        Dim newStr As String = String.Empty
        Try
            For Each c As Char In orgStr.ToCharArray
                If IsNumeric(c) Then
                    newStr &= c
                End If
            Next
            Return newStr
        Catch ex As Exception
            LogError.Write("frmDDMAST.RemoveCharacter()." & ex.Message, EventLogEntryType.Error)
        End Try
        Return orgStr
    End Function

    Private Sub cboACCSETTLEMENT_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboACCSETTLEMENT.SelectedValueChanged

        If cboACCSETTLEMENT.SelectedValue Is DBNull.Value = False Then
            If cboACCSETTLEMENT.SelectedValue = "Y" Then
                cboAutoTransfer.SelectedValue = "N"
                cboAutoTransfer.Enabled = False
            Else
                cboAutoTransfer.Enabled = True
            End If
        End If
    End Sub
End Class
