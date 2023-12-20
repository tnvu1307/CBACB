Imports CommonLibrary
Imports AppCore

Public Class frmRMManualMsg
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
    Friend WithEvents grbRMManualMsg As System.Windows.Forms.GroupBox
    Friend WithEvents txtKEYACCT1 As System.Windows.Forms.TextBox
    Friend WithEvents txtKEYACCT2 As System.Windows.Forms.TextBox
    Friend WithEvents lblKEYACCT2 As System.Windows.Forms.Label
    Friend WithEvents lblKEYACCT1 As System.Windows.Forms.Label
    Friend WithEvents cboSTATUS As AppCore.ComboBoxEx
    Friend WithEvents lblSTATUS As System.Windows.Forms.Label
    Friend WithEvents txtTRNREF As System.Windows.Forms.TextBox
    Friend WithEvents lblTRNREF As System.Windows.Forms.Label
    Friend WithEvents txtDESBANKACCOUNT As System.Windows.Forms.TextBox
    Friend WithEvents lblDESBANKACCOUNT As System.Windows.Forms.Label
    Friend WithEvents lblAMOUNT As System.Windows.Forms.Label
    Friend WithEvents txtBANKCODE As System.Windows.Forms.TextBox
    Friend WithEvents lblBANKCODE As System.Windows.Forms.Label
    Friend WithEvents txtBRANCH As System.Windows.Forms.TextBox
    Friend WithEvents lblBRANCH As System.Windows.Forms.Label
    Friend WithEvents txtACCNUM As System.Windows.Forms.TextBox
    Friend WithEvents lblACCNUM As System.Windows.Forms.Label
    Friend WithEvents txtLOCATION As System.Windows.Forms.TextBox
    Friend WithEvents lblLOCATION As System.Windows.Forms.Label
    Friend WithEvents txtACCNAME As System.Windows.Forms.TextBox
    Friend WithEvents lblACCNAME As System.Windows.Forms.Label
    Friend WithEvents txtAMOUNT As System.Windows.Forms.TextBox 'AppCore.FlexMaskEditBox
    Friend WithEvents txtNOTES As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRMManualMsg))
        Me.grbRMManualMsg = New System.Windows.Forms.GroupBox
        Me.txtAMOUNT = New System.Windows.Forms.TextBox
        Me.txtACCNAME = New System.Windows.Forms.TextBox
        Me.lblACCNAME = New System.Windows.Forms.Label
        Me.txtACCNUM = New System.Windows.Forms.TextBox
        Me.lblACCNUM = New System.Windows.Forms.Label
        Me.txtLOCATION = New System.Windows.Forms.TextBox
        Me.lblLOCATION = New System.Windows.Forms.Label
        Me.txtBRANCH = New System.Windows.Forms.TextBox
        Me.cboSTATUS = New AppCore.ComboBoxEx
        Me.lblSTATUS = New System.Windows.Forms.Label
        Me.lblBRANCH = New System.Windows.Forms.Label
        Me.txtBANKCODE = New System.Windows.Forms.TextBox
        Me.lblBANKCODE = New System.Windows.Forms.Label
        Me.lblAMOUNT = New System.Windows.Forms.Label
        Me.txtDESBANKACCOUNT = New System.Windows.Forms.TextBox
        Me.lblDESBANKACCOUNT = New System.Windows.Forms.Label
        Me.txtTRNREF = New System.Windows.Forms.TextBox
        Me.lblTRNREF = New System.Windows.Forms.Label
        Me.txtNOTES = New System.Windows.Forms.TextBox
        Me.txtKEYACCT1 = New System.Windows.Forms.TextBox
        Me.txtKEYACCT2 = New System.Windows.Forms.TextBox
        Me.lblKEYACCT2 = New System.Windows.Forms.Label
        Me.lblKEYACCT1 = New System.Windows.Forms.Label
        Me.lblNOTES = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.grbRMManualMsg.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(269, 424)
        Me.btnOK.Size = New System.Drawing.Size(75, 24)
        Me.btnOK.TabIndex = 13
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(349, 424)
        Me.btnCancel.Size = New System.Drawing.Size(75, 24)
        Me.btnCancel.TabIndex = 14
        '
        'lblCaption
        '
        Me.lblCaption.Location = New System.Drawing.Point(7, 17)
        '
        'btnApply
        '
        Me.btnApply.Location = New System.Drawing.Point(429, 424)
        Me.btnApply.TabIndex = 15
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(553, 50)
        '
        'btnApprv
        '
        Me.btnApprv.Location = New System.Drawing.Point(619, 240)
        '
        'cboLink
        '
        Me.cboLink.Location = New System.Drawing.Point(597, 148)
        Me.cboLink.Size = New System.Drawing.Size(216, 21)
        '
        'grbRMManualMsg
        '
        Me.grbRMManualMsg.Controls.Add(Me.txtAMOUNT)
        Me.grbRMManualMsg.Controls.Add(Me.txtACCNAME)
        Me.grbRMManualMsg.Controls.Add(Me.lblACCNAME)
        Me.grbRMManualMsg.Controls.Add(Me.txtACCNUM)
        Me.grbRMManualMsg.Controls.Add(Me.lblACCNUM)
        Me.grbRMManualMsg.Controls.Add(Me.txtLOCATION)
        Me.grbRMManualMsg.Controls.Add(Me.lblLOCATION)
        Me.grbRMManualMsg.Controls.Add(Me.txtBRANCH)
        Me.grbRMManualMsg.Controls.Add(Me.cboSTATUS)
        Me.grbRMManualMsg.Controls.Add(Me.lblSTATUS)
        Me.grbRMManualMsg.Controls.Add(Me.lblBRANCH)
        Me.grbRMManualMsg.Controls.Add(Me.txtBANKCODE)
        Me.grbRMManualMsg.Controls.Add(Me.lblBANKCODE)
        Me.grbRMManualMsg.Controls.Add(Me.lblAMOUNT)
        Me.grbRMManualMsg.Controls.Add(Me.txtDESBANKACCOUNT)
        Me.grbRMManualMsg.Controls.Add(Me.lblDESBANKACCOUNT)
        Me.grbRMManualMsg.Controls.Add(Me.txtTRNREF)
        Me.grbRMManualMsg.Controls.Add(Me.lblTRNREF)
        Me.grbRMManualMsg.Controls.Add(Me.txtNOTES)
        Me.grbRMManualMsg.Controls.Add(Me.txtKEYACCT1)
        Me.grbRMManualMsg.Controls.Add(Me.txtKEYACCT2)
        Me.grbRMManualMsg.Controls.Add(Me.lblKEYACCT2)
        Me.grbRMManualMsg.Controls.Add(Me.lblKEYACCT1)
        Me.grbRMManualMsg.Controls.Add(Me.lblNOTES)
        Me.grbRMManualMsg.Location = New System.Drawing.Point(8, 60)
        Me.grbRMManualMsg.Name = "grbRMManualMsg"
        Me.grbRMManualMsg.Size = New System.Drawing.Size(497, 360)
        Me.grbRMManualMsg.TabIndex = 0
        Me.grbRMManualMsg.TabStop = False
        Me.grbRMManualMsg.Tag = "grbRMChangeReq"
        Me.grbRMManualMsg.Text = "grbRMChangeReq"
        '
        'txtAMOUNT
        '
        Me.txtAMOUNT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAMOUNT.Location = New System.Drawing.Point(121, 72)
        Me.txtAMOUNT.Name = "txtAMOUNT"
        Me.txtAMOUNT.Size = New System.Drawing.Size(119, 21)
        Me.txtAMOUNT.TabIndex = 3
        Me.txtAMOUNT.Tag = "AMOUNT"
        Me.txtAMOUNT.Text = "txtAMOUNT"
        '
        'txtACCNAME
        '
        Me.txtACCNAME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtACCNAME.Location = New System.Drawing.Point(121, 241)
        Me.txtACCNAME.Name = "txtACCNAME"
        Me.txtACCNAME.Size = New System.Drawing.Size(368, 21)
        Me.txtACCNAME.TabIndex = 9
        Me.txtACCNAME.Tag = "ACCNAME"
        Me.txtACCNAME.Text = "txtACCNAME"
        '
        'lblACCNAME
        '
        Me.lblACCNAME.Location = New System.Drawing.Point(3, 241)
        Me.lblACCNAME.Name = "lblACCNAME"
        Me.lblACCNAME.Size = New System.Drawing.Size(112, 21)
        Me.lblACCNAME.TabIndex = 148
        Me.lblACCNAME.Tag = "ACCNAME"
        Me.lblACCNAME.Text = "lblACCNAME"
        '
        'txtACCNUM
        '
        Me.txtACCNUM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtACCNUM.Location = New System.Drawing.Point(121, 213)
        Me.txtACCNUM.Name = "txtACCNUM"
        Me.txtACCNUM.Size = New System.Drawing.Size(368, 21)
        Me.txtACCNUM.TabIndex = 8
        Me.txtACCNUM.Tag = "ACCNUM"
        Me.txtACCNUM.Text = "txtACCNUM"
        '
        'lblACCNUM
        '
        Me.lblACCNUM.Location = New System.Drawing.Point(3, 213)
        Me.lblACCNUM.Name = "lblACCNUM"
        Me.lblACCNUM.Size = New System.Drawing.Size(112, 21)
        Me.lblACCNUM.TabIndex = 146
        Me.lblACCNUM.Tag = "ACCNUM"
        Me.lblACCNUM.Text = "lblACCNUM"
        '
        'txtLOCATION
        '
        Me.txtLOCATION.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLOCATION.Location = New System.Drawing.Point(121, 185)
        Me.txtLOCATION.Name = "txtLOCATION"
        Me.txtLOCATION.Size = New System.Drawing.Size(368, 21)
        Me.txtLOCATION.TabIndex = 7
        Me.txtLOCATION.Tag = "LOCATION"
        Me.txtLOCATION.Text = "txtLOCATION"
        '
        'lblLOCATION
        '
        Me.lblLOCATION.Location = New System.Drawing.Point(3, 185)
        Me.lblLOCATION.Name = "lblLOCATION"
        Me.lblLOCATION.Size = New System.Drawing.Size(112, 21)
        Me.lblLOCATION.TabIndex = 144
        Me.lblLOCATION.Tag = "LOCATION"
        Me.lblLOCATION.Text = "lblLOCATION"
        '
        'txtBRANCH
        '
        Me.txtBRANCH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBRANCH.Location = New System.Drawing.Point(121, 157)
        Me.txtBRANCH.Name = "txtBRANCH"
        Me.txtBRANCH.Size = New System.Drawing.Size(368, 21)
        Me.txtBRANCH.TabIndex = 6
        Me.txtBRANCH.Tag = "BRANCH"
        Me.txtBRANCH.Text = "txtBRANCH"
        '
        'cboSTATUS
        '
        Me.cboSTATUS.DisplayMember = "DISPLAY"
        Me.cboSTATUS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSTATUS.FormattingEnabled = True
        Me.cboSTATUS.Location = New System.Drawing.Point(121, 100)
        Me.cboSTATUS.Name = "cboSTATUS"
        Me.cboSTATUS.Size = New System.Drawing.Size(90, 21)
        Me.cboSTATUS.TabIndex = 4
        Me.cboSTATUS.Tag = "STATUS"
        Me.cboSTATUS.ValueMember = "VALUE"
        '
        'lblSTATUS
        '
        Me.lblSTATUS.Location = New System.Drawing.Point(3, 100)
        Me.lblSTATUS.Name = "lblSTATUS"
        Me.lblSTATUS.Size = New System.Drawing.Size(108, 21)
        Me.lblSTATUS.TabIndex = 42
        Me.lblSTATUS.Tag = "STATUS"
        Me.lblSTATUS.Text = "lblSTATUS"
        '
        'lblBRANCH
        '
        Me.lblBRANCH.Location = New System.Drawing.Point(3, 157)
        Me.lblBRANCH.Name = "lblBRANCH"
        Me.lblBRANCH.Size = New System.Drawing.Size(112, 21)
        Me.lblBRANCH.TabIndex = 142
        Me.lblBRANCH.Tag = "BRANCH"
        Me.lblBRANCH.Text = "lblBRANCH"
        '
        'txtBANKCODE
        '
        Me.txtBANKCODE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBANKCODE.Location = New System.Drawing.Point(121, 130)
        Me.txtBANKCODE.Name = "txtBANKCODE"
        Me.txtBANKCODE.Size = New System.Drawing.Size(368, 21)
        Me.txtBANKCODE.TabIndex = 5
        Me.txtBANKCODE.Tag = "BANKCODE"
        Me.txtBANKCODE.Text = "txtBANKCODE"
        '
        'lblBANKCODE
        '
        Me.lblBANKCODE.Location = New System.Drawing.Point(3, 130)
        Me.lblBANKCODE.Name = "lblBANKCODE"
        Me.lblBANKCODE.Size = New System.Drawing.Size(112, 21)
        Me.lblBANKCODE.TabIndex = 140
        Me.lblBANKCODE.Tag = "BANKCODE"
        Me.lblBANKCODE.Text = "lblBANKCODE"
        '
        'lblAMOUNT
        '
        Me.lblAMOUNT.Location = New System.Drawing.Point(3, 73)
        Me.lblAMOUNT.Name = "lblAMOUNT"
        Me.lblAMOUNT.Size = New System.Drawing.Size(112, 21)
        Me.lblAMOUNT.TabIndex = 48
        Me.lblAMOUNT.Tag = "AMOUNT"
        Me.lblAMOUNT.Text = "lblAMOUNT"
        '
        'txtDESBANKACCOUNT
        '
        Me.txtDESBANKACCOUNT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDESBANKACCOUNT.Location = New System.Drawing.Point(121, 45)
        Me.txtDESBANKACCOUNT.Name = "txtDESBANKACCOUNT"
        Me.txtDESBANKACCOUNT.Size = New System.Drawing.Size(368, 21)
        Me.txtDESBANKACCOUNT.TabIndex = 2
        Me.txtDESBANKACCOUNT.Tag = "DESBANKACCOUNT"
        Me.txtDESBANKACCOUNT.Text = "txtDESBANKACCOUNT"
        '
        'lblDESBANKACCOUNT
        '
        Me.lblDESBANKACCOUNT.Location = New System.Drawing.Point(3, 45)
        Me.lblDESBANKACCOUNT.Name = "lblDESBANKACCOUNT"
        Me.lblDESBANKACCOUNT.Size = New System.Drawing.Size(112, 21)
        Me.lblDESBANKACCOUNT.TabIndex = 46
        Me.lblDESBANKACCOUNT.Tag = "DESBANKACCOUNT"
        Me.lblDESBANKACCOUNT.Text = "lblDESBANKACCOUNT"
        '
        'txtTRNREF
        '
        Me.txtTRNREF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTRNREF.Location = New System.Drawing.Point(121, 17)
        Me.txtTRNREF.Name = "txtTRNREF"
        Me.txtTRNREF.Size = New System.Drawing.Size(368, 21)
        Me.txtTRNREF.TabIndex = 1
        Me.txtTRNREF.Tag = "TRNREF"
        Me.txtTRNREF.Text = "txtTRNREF"
        '
        'lblTRNREF
        '
        Me.lblTRNREF.Location = New System.Drawing.Point(3, 17)
        Me.lblTRNREF.Name = "lblTRNREF"
        Me.lblTRNREF.Size = New System.Drawing.Size(112, 21)
        Me.lblTRNREF.TabIndex = 44
        Me.lblTRNREF.Tag = "TRNREF"
        Me.lblTRNREF.Text = "lblTRNREF"
        '
        'txtNOTES
        '
        Me.txtNOTES.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNOTES.Location = New System.Drawing.Point(121, 327)
        Me.txtNOTES.Name = "txtNOTES"
        Me.txtNOTES.Size = New System.Drawing.Size(368, 21)
        Me.txtNOTES.TabIndex = 12
        Me.txtNOTES.Tag = "TRANSACTIONDESCRIPTION"
        Me.txtNOTES.Text = "txtNOTES"
        '
        'txtKEYACCT1
        '
        Me.txtKEYACCT1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtKEYACCT1.Location = New System.Drawing.Point(121, 270)
        Me.txtKEYACCT1.Name = "txtKEYACCT1"
        Me.txtKEYACCT1.Size = New System.Drawing.Size(368, 21)
        Me.txtKEYACCT1.TabIndex = 10
        Me.txtKEYACCT1.Tag = "KEYACCT1"
        Me.txtKEYACCT1.Text = "txtKEYACCT1"
        '
        'txtKEYACCT2
        '
        Me.txtKEYACCT2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtKEYACCT2.Location = New System.Drawing.Point(121, 299)
        Me.txtKEYACCT2.Name = "txtKEYACCT2"
        Me.txtKEYACCT2.Size = New System.Drawing.Size(368, 21)
        Me.txtKEYACCT2.TabIndex = 11
        Me.txtKEYACCT2.Tag = "KEYACCT2"
        Me.txtKEYACCT2.Text = "txtKEYACCT2"
        '
        'lblKEYACCT2
        '
        Me.lblKEYACCT2.Location = New System.Drawing.Point(3, 299)
        Me.lblKEYACCT2.Name = "lblKEYACCT2"
        Me.lblKEYACCT2.Size = New System.Drawing.Size(112, 21)
        Me.lblKEYACCT2.TabIndex = 11
        Me.lblKEYACCT2.Tag = "KEYACCT2"
        Me.lblKEYACCT2.Text = "lblKEYACCT2"
        '
        'lblKEYACCT1
        '
        Me.lblKEYACCT1.Location = New System.Drawing.Point(3, 270)
        Me.lblKEYACCT1.Name = "lblKEYACCT1"
        Me.lblKEYACCT1.Size = New System.Drawing.Size(112, 21)
        Me.lblKEYACCT1.TabIndex = 10
        Me.lblKEYACCT1.Tag = "KEYACCT1"
        Me.lblKEYACCT1.Text = "lblKEYACCT1"
        '
        'lblNOTES
        '
        Me.lblNOTES.Location = New System.Drawing.Point(3, 329)
        Me.lblNOTES.Name = "lblNOTES"
        Me.lblNOTES.Size = New System.Drawing.Size(112, 21)
        Me.lblNOTES.TabIndex = 3
        Me.lblNOTES.Tag = "TRANSACTIONDESCRIPTION"
        Me.lblNOTES.Text = "lblNOTES"
        '
        'frmRMManualMsg
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(553, 455)
        Me.Controls.Add(Me.grbRMManualMsg)
        Me.Name = "frmRMManualMsg"
        Me.Tag = "frmRMManualMsg"
        Me.Text = ""
        Me.Controls.SetChildIndex(Me.cboLink, 0)
        Me.Controls.SetChildIndex(Me.btnApprv, 0)
        Me.Controls.SetChildIndex(Me.btnApply, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.grbRMManualMsg, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.grbRMManualMsg.ResumeLayout(False)
        Me.grbRMManualMsg.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Declare constants and variables "
    Private mv_ReqID As String
    Private mv_EditInfo As Boolean
    Public mv_CustomerName As String
    Private mv_strTellerId As String
    Private mv_strBranchId As String
    Private mv_IpAddress As String
    Private mv_WSName As String
    Private mv_TLID As String
    Private mv_arrObjFields() As CFieldMaster
    Private mv_arrObjFldVals() As CFieldVal
    Private mv_blnAcctEntry As Boolean = False

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

    Public Property BranchId() As String
        Get
            Return mv_strBranchId
        End Get
        Set(ByVal Value As String)
            mv_strBranchId = Value
        End Set
    End Property

    Public Property TellerId() As String
        Get
            Return mv_strTellerId
        End Get
        Set(ByVal Value As String)
            mv_strTellerId = Value
        End Set
    End Property


    Public Property IpAddress() As String
        Get
            Return mv_IpAddress
        End Get
        Set(ByVal Value As String)
            mv_IpAddress = Value
        End Set
    End Property

    Public Property WSName() As String
        Get
            Return mv_WSName
        End Get
        Set(ByVal Value As String)
            mv_WSName = Value
        End Set
    End Property
    Public Property TLID() As String
        Get
            Return mv_TLID
        End Get
        Set(ByVal Value As String)
            mv_TLID = Value
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
            'LoadRequestInfo()

            'btnApply.Visible = True
            'btnApply.Enabled = True
            'btnOK.Visible = True
            'btnOK.Enabled = True

            If mv_EditInfo = False Then
                txtTRNREF.Enabled = False
                txtDESBANKACCOUNT.Enabled = False
                txtAMOUNT.Enabled = False
                cboSTATUS.Enabled = True
                txtBANKCODE.Enabled = False
                txtBRANCH.Enabled = False
                txtLOCATION.Enabled = False
                txtACCNUM.Enabled = False
                txtACCNAME.Enabled = False
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
        Dim v_strTxMsg As String
        Dim v_xmlDocument As New Xml.XmlDocument, v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
        Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode, v_intIndex As Long, i, j, v_intCount As Integer
        Dim v_strFLDNAME As String, v_strFLDDEFNAME As String, v_strDATATYPE As String, v_strFLDVALUE As String
        Dim v_ctl As Control, v_attrFLDNAME As Xml.XmlAttribute, v_attrDATATYPE As Xml.XmlAttribute, v_objEval As New Evaluator
        Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery


        Try
            'Update mouse pointer
            Cursor.Current = Cursors.WaitCursor

            MyBase.OnSave()
            If Not DoDataExchange(True) Then
                Exit Sub
            End If

            


            Dim v_strClause As String

            v_strClause = "AUTOID = " & mv_ReqID

            Select Case ExeFlag
                Case ExecuteFlag.AddNew
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , Me.TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionAdhoc, v_strClause, , "AddManualMsg", , , , , , ParentObjName, ParentClause)
                    BuildXMLObjData(mv_dsInput, v_strObjMsg, mv_dsOldInput, ExecuteFlag.AddNew)                    
                    Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)

                    
                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                    If v_lngErrorCode <> 0 Then
                        'Update mouse pointer
                        Cursor.Current = Cursors.Default
                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Exit Sub
                    End If

                    MsgBox(ResourceManager.GetString("AddnewSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)



                Case ExecuteFlag.Edit

                    'v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionEdit, , v_strClause, , , , , , , , ParentObjName, ParentClause)
                    'BuildXMLObjData(mv_dsInput, v_strObjMsg, mv_dsOldInput, ExecuteFlag.Edit)
                    'Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                    'Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)

                    ''Ki?m tra thông tin và x? lý l?i (n?u có) t? message tr? v?
                    'Dim v_strErrorSource, v_strErrorMessage As String

                    'GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                    'If v_lngErrorCode <> 0 Then
                    '    'Update mouse pointer
                    '    Cursor.Current = Cursors.Default
                    '    MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                    '    Exit Sub
                    'End If

                    LoadScreen("6656")
                    v_strTxMsg = BuildXMLTxMsg(gc_MsgTypeTrans, gc_IsLocalMsg, "6656", Me.BranchId, Me.mv_TLID, mv_IpAddress, mv_WSName, , , , , , , , , , , , , , , , , Me.BusDate)


                    v_xmlDocument.LoadXml(v_strTxMsg)
                    v_dataElement = v_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "fields", "")
                    If mv_arrObjFields.GetLength(0) > 0 Then
                        For v_intIndex = 0 To mv_arrObjFields.GetLength(0) - 1 Step 1
                            If Not mv_arrObjFields(v_intIndex) Is Nothing Then
                                v_strFLDNAME = mv_arrObjFields(v_intIndex).FieldName
                                v_strDATATYPE = mv_arrObjFields(v_intIndex).DataType
                                Select Case Trim(v_strFLDNAME)

                                    Case "03" 'REQID
                                        v_strFLDVALUE = Trim(mv_ReqID)
                                    Case "30" 'NOTES                                
                                        v_strFLDVALUE = Trim(txtNOTES.Text)
                                    Case "40" 'STATUS
                                        v_strFLDVALUE = Trim(cboSTATUS.SelectedValue)
                                End Select

                                'Append entry to data node
                                v_entryNode = v_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "entry", "")

                                'Add field name
                                v_attrFLDNAME = v_xmlDocument.CreateAttribute(gc_AtributeFLDNAME)
                                v_attrFLDNAME.Value = v_strFLDNAME
                                v_entryNode.Attributes.Append(v_attrFLDNAME)

                                'Add field type
                                v_attrDATATYPE = v_xmlDocument.CreateAttribute(gc_AtributeFLDTYPE)
                                v_attrDATATYPE.Value = v_strDATATYPE
                                v_entryNode.Attributes.Append(v_attrDATATYPE)

                                'Set value
                                v_entryNode.InnerText = v_strFLDVALUE

                                v_dataElement.AppendChild(v_entryNode)

                                'Remember account field
                                'If UCase(v_strFLDNAME) = "03" Then
                                '    Clipboard.SetDataObject(v_strFLDVALUE)
                                'End If
                                v_xmlDocument.DocumentElement.AppendChild(v_dataElement)
                            End If
                        Next
                    End If

                    v_strTxMsg = v_xmlDocument.InnerXml
                    v_lngError = v_ws.Message(v_strTxMsg)
                    If v_lngError <> ERR_SYSTEM_OK Then
                        'Thông báo lỗi
                        GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                        Cursor.Current = Cursors.Default
                        MessageBox.Show(v_strErrorMessage, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If

                    MsgBox(ResourceManager.GetString("EditSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)

            End Select

            

          
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


    '---------------------------------------------------------------------------------------------------------
    'Hàm này được sử dụng để nạp màn hình.
    'Biến vào 
    '   strTLTXCD là mã giao dịch, dùng để xác định các trư?ng trong giao dịch
    '   v_blnChain  Xác định xem có phải nạp màn hình sau khi đã tra cứu không
    '   v_blnData   Xác định xem có phải nạp màn hình xem chi tiết giao dịch không
    '   v_strXML    Là nội dung chuỗi XML tương ứng với v_blnChain hoặc v_blnData
    '---------------------------------------------------------------------------------------------------------
    Public Sub LoadScreen(ByVal strTLTXCD As String, _
                Optional ByVal v_blnChain As Boolean = False, _
                Optional ByVal v_blnData As Boolean = False, _
                Optional ByVal v_strXML As String = vbNullString)
        Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode
        Dim v_strValue, v_strFLDNAME As String, i, j, m, n As Integer, v_objField As CFieldMaster, v_objFieldVal As CFieldVal
        Dim v_strFieldName, v_strDefName, v_strCaption, v_strFldType, v_strFldMask, v_strFldFormat, _
            v_strLList, v_strLChk, v_strDefVal, v_strAmtExp, v_strValidTag, v_strLookUp, v_strDataType, _
            v_strChainName, v_strLookupName, v_strPrintInfo, v_strInvName, v_strFldSource, v_strFldDesc, v_strSearchCode, v_strSrModCode As String
        Dim v_intOdrNum, v_intFldLen, v_intIndex As Integer
        Dim v_blnVisible, v_blnEnabled, v_blnMandatory As Boolean

        Try
            'Create message to inquiry object fields
            Dim v_strSQL, v_strClause, v_strObjMsg As String
            Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            If Len(v_strXML) > 0 Then
                v_xmlDocumentData.LoadXml(v_strXML)
            End If

            'Lấy thông tin chung v? giao d�ịch
            If Len(Me.ModuleCode) > 0 Then
                v_strSQL = "SELECT TX.* FROM TLTX TX, APPMODULES APP WHERE SUBSTR(TX.TLTXCD,1,2)=APP.TXCODE " _
                    & "AND UPPER(TX.TLTXCD) = '" & strTLTXCD & "' " _
                    & "AND UPPER(APP.MODCODE) = '" & Me.ModuleCode & "' "
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLTX, gc_ActionInquiry, v_strSQL)
            Else
                v_strClause = "upper(TLTXCD) = '" & strTLTXCD & "'"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLTX, gc_ActionInquiry, , v_strClause)
            End If
            v_ws.Message(v_strObjMsg)

            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            If v_nodeList.Count = 0 Then
                'Nếu không tồn tại mã giao dịch
                MessageBox.Show(ResourceManager.GetString("MSG_NULL"))
                ResetScreen(Me)
                Exit Sub
            End If

            For i = 0 To v_nodeList.Count - 1
                For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "TXDESC"
                                If UserLanguage <> "EN" Then
                                    Me.Text = Trim(v_strValue)
                                End If
                            Case "EN_TXDESC"
                                If UserLanguage = "EN" Then
                                    Me.Text = Trim(v_strValue)
                                End If
                            Case "ACCTENTRY"
                                If v_strValue = "Y" Then
                                    mv_blnAcctEntry = True
                                Else
                                    mv_blnAcctEntry = False
                                End If
                            Case "BGCOLOR"

                        End Select

                    End With
                Next
            Next

            'Lấy thông tin chi tiết các trư?ng c�ủa giao dịch
            v_strClause = "upper(OBJNAME) = '" & strTLTXCD & "' ORDER BY ODRNUM"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_FLDMASTER, gc_ActionInquiry, , v_strClause)
            v_ws.Message(v_strObjMsg)

            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            ReDim mv_arrObjFields(v_nodeList.Count)

            For i = 0 To v_nodeList.Count - 1
                For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)

                        Select Case Trim(v_strFLDNAME)
                            Case "FLDNAME"
                                v_strFieldName = Trim(v_strValue)
                            Case "DEFNAME"
                                v_strDefName = Trim(v_strValue)
                            Case "CAPTION"
                                If UserLanguage <> "EN" Then
                                    v_strCaption = Trim(v_strValue)
                                End If
                            Case "EN_CAPTION"
                                If UserLanguage = "EN" Then
                                    v_strCaption = Trim(v_strValue)
                                End If
                            Case "ODRNUM"
                                v_intOdrNum = CInt(Trim(v_strValue))
                            Case "FLDTYPE"
                                v_strFldType = Trim(v_strValue)
                            Case "FLDMASK"
                                v_strFldMask = Trim(v_strValue)
                            Case "FLDFORMAT"
                                v_strFldFormat = Trim(v_strValue)
                            Case "FLDLEN"
                                v_intFldLen = CInt(Trim(v_strValue))
                            Case "LLIST"
                                v_strLList = Trim(v_strValue)
                            Case "LCHK"
                                v_strLChk = Trim(v_strValue)
                            Case "DEFVAL"
                                v_strDefVal = Trim(v_strValue)
                            Case "VISIBLE"
                                v_blnVisible = (Trim(v_strValue) = "Y")
                            Case "DISABLE"
                                v_blnEnabled = (Trim(v_strValue) = "N")
                            Case "MANDATORY"
                                v_blnMandatory = (Trim(v_strValue) = "Y")
                            Case "AMTEXP"
                                v_strAmtExp = Trim(v_strValue)
                            Case "VALIDTAG"
                                v_strValidTag = Trim(v_strValue)
                            Case "LOOKUP"
                                v_strLookUp = Trim(v_strValue)
                            Case "DATATYPE"
                                v_strDataType = Trim(v_strValue)
                            Case "INVNAME"
                                v_strInvName = Trim(v_strValue)
                            Case "FLDSOURCE"
                                v_strFldSource = Trim(v_strValue)
                            Case "FLDDESC"
                                v_strFldDesc = Trim(v_strValue)
                            Case "CHAINNAME"
                                v_strChainName = Trim(v_strValue)
                            Case "LOOKUPNAME"
                                v_strLookupName = Trim(v_strValue)
                            Case "SEARCHCODE"
                                v_strSearchCode = Trim(v_strValue)
                            Case "SRMODCODE"
                                v_strSrModCode = Trim(v_strValue)
                            Case "PRINTINFO"
                                v_strPrintInfo = v_strValue 'Không được trim vì độ dài bắt buộc 10 ký tự
                        End Select
                    End With
                Next

                v_objField = New CFieldMaster
                With v_objField
                    .FieldName = v_strFieldName
                    .ColumnName = v_strDefName
                    .Caption = v_strCaption
                    .DisplayOrder = v_intOdrNum
                    .FieldType = v_strFldType
                    .InputMask = v_strFldMask
                    .FieldFormat = v_strFldFormat
                    .FieldLength = v_intFldLen
                    .LookupList = v_strLList
                    .LookupCheck = v_strLChk
                    .LookupName = v_strLookupName
                    If v_strDefName = "DESC" And Len(v_strDefVal) = 0 Then
                        'Xử lý cho trư?ng Description
                        v_strDefVal = Me.Text
                    ElseIf v_strDefVal = "<$BUSDATE>" Then
                        'L�ấy ngày làm việc hiện tại
                        v_strDefVal = Me.BusDate
                    End If
                    If v_blnChain Then
                        'Nếu giao dịch được nạp qua giao dịch tra cứu
                        If Len(v_strChainName) > 0 Then
                            'Nếu trư?ng n�ày có sử dụng CHAINNAME để lấy giá trị từ màn hình tra cứu
                            v_nodetxData = v_xmlDocumentData.SelectSingleNode("TransactMessage/ObjData/entry[@fldname='" & v_strChainName & "']")
                            If Not v_nodetxData Is Nothing Then
                                v_strDefVal = Trim(v_nodetxData.InnerText)
                            End If
                        End If
                    ElseIf v_blnData Then
                        'Nếu giao dịch có dữ liệu (xem chi tiết)
                    End If
                    .DefaultValue = v_strDefVal
                    .Visible = v_blnVisible
                    .Enabled = v_blnEnabled
                    .Mandatory = v_blnMandatory
                    .AmtExp = v_strAmtExp
                    .ValidTag = v_strValidTag
                    .LookUp = v_strLookUp
                    .DataType = v_strDataType
                    .InvName = v_strInvName
                    .FldSource = v_strFldSource
                    .FldDesc = v_strFldDesc
                    .PrintInfo = v_strPrintInfo
                    .SearchCode = v_strSearchCode
                    .SrModCode = v_strSrModCode
                    .FieldValue = String.Empty
                End With
                mv_arrObjFields(i) = v_objField
            Next
            ReDim Preserve mv_arrObjFields(v_nodeList.Count)

            'Lấy các luật kiểm tra của các trư?ng giao d�ịch
            v_strClause = "SELECT FLDNAME, VALTYPE, OPERATOR, VALEXP, VALEXP2, ERRMSG, EN_ERRMSG FROM FLDVAL " & _
                "WHERE upper(OBJNAME) = '" & strTLTXCD & "' ORDER BY VALTYPE, FLDNAME, ODRNUM" 'Thứ tự order by là quan tr?ng kh�ông sửa
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_FLDVAL, gc_ActionInquiry, v_strClause)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            ReDim mv_arrObjFldVals(v_nodeList.Count)
            Dim v_strFieldVal_ObjName, v_strFieldVal_FldName, v_strFieldVal_ValType, v_strFieldVal_Operator, _
                v_strFieldVal_ValExp, v_strFieldVal_ValExp2, v_strFieldVal_ErrMsg, v_strFieldVal_EnErrMsg As String

            For i = 0 To v_nodeList.Count - 1
                For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        'Ghi nhận thuật toán để kiểm tra và tính toán cho từng trư?ng c�ủa giao dịch
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "FLDNAME"
                                v_strFieldVal_FldName = Trim(v_strValue)
                            Case "VALTYPE"
                                v_strFieldVal_ValType = Trim(v_strValue)
                            Case "OPERATOR"
                                v_strFieldVal_Operator = Trim(v_strValue)
                            Case "VALEXP"
                                v_strFieldVal_ValExp = Trim(v_strValue)
                            Case "VALEXP2"
                                v_strFieldVal_ValExp2 = Trim(v_strValue)
                            Case "ERRMSG"
                                v_strFieldVal_ErrMsg = Trim(v_strValue)
                            Case "EN_ERRMSG"
                                v_strFieldVal_EnErrMsg = Trim(v_strValue)
                        End Select
                    End With
                Next

                'Xác định index của mảng FldMaster
                For j = 0 To mv_arrObjFields.GetLength(0) - 1 Step 1
                    If Not mv_arrObjFields(j) Is Nothing Then
                        If Trim(mv_arrObjFields(j).FieldName) = Trim(v_strFieldVal_FldName) Then
                            v_intIndex = j
                        End If
                    End If
                Next

                '?i�?u ki�ện xử lý
                v_objFieldVal = New CFieldVal
                With v_objFieldVal
                    .OBJNAME = strTLTXCD
                    .FLDNAME = v_strFieldVal_FldName
                    .VALTYPE = v_strFieldVal_ValType
                    .[OPERATOR] = v_strFieldVal_Operator
                    .VALEXP = v_strFieldVal_ValExp
                    .VALEXP2 = v_strFieldVal_ValExp2
                    .ERRMSG = v_strFieldVal_ErrMsg
                    .EN_ERRMSG = v_strFieldVal_EnErrMsg
                    .IDXFLD = v_intIndex
                End With
                mv_arrObjFldVals(i) = v_objFieldVal
            Next
            ReDim Preserve mv_arrObjFldVals(v_nodeList.Count)

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub ResetScreen(ByRef pv_ctrl As Windows.Forms.Control)
        Dim v_ctrl As Windows.Forms.Control
        For Each v_ctrl In pv_ctrl.Controls
            If TypeOf (v_ctrl) Is TextBox Then
                CType(v_ctrl, TextBox).Text = String.Empty
                'CType(v_ctrl, TextBox).Enabled = True
            ElseIf TypeOf (v_ctrl) Is ComboBox Then
                CType(v_ctrl, ComboBox).Text = String.Empty
            ElseIf TypeOf (v_ctrl) Is GroupBox Then
                ResetScreen(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is Button Then
            ElseIf TypeOf (v_ctrl) Is Panel Then
                v_ctrl.Enabled = True
                ResetScreen(v_ctrl)
            End If
        Next

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


    Private Sub frmRMManualMsg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

