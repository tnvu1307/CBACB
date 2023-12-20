Imports System.Windows.Forms
Imports Xceed.SmartUI.Controls
Imports CommonLibrary
Imports System.Collections
Imports AppCore
Imports AppCore.modCoreLib


Public Class frmTransferInq
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal pv_strLanguage As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        mv_strLanguage = pv_strLanguage
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())

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
    Friend WithEvents pnlTitle As System.Windows.Forms.Panel
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblCaption As System.Windows.Forms.Label
    Friend WithEvents lblTimer As System.Windows.Forms.Label
    Friend WithEvents tmrOrder As System.Windows.Forms.Timer
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents pnCIACCTNO As System.Windows.Forms.Panel
    Friend WithEvents lblCIInfo As System.Windows.Forms.Label
    Friend WithEvents pnBnkAccount As System.Windows.Forms.Panel
    Friend WithEvents lblBnkInfo As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.pnlTitle = New System.Windows.Forms.Panel
        Me.lblTimer = New System.Windows.Forms.Label
        Me.lblCaption = New System.Windows.Forms.Label
        Me.pnCIACCTNO = New System.Windows.Forms.Panel
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnSubmit = New System.Windows.Forms.Button
        Me.tmrOrder = New System.Windows.Forms.Timer(Me.components)
        Me.pnBnkAccount = New System.Windows.Forms.Panel
        Me.lblCIInfo = New System.Windows.Forms.Label
        Me.lblBnkInfo = New System.Windows.Forms.Label
        Me.pnlTitle.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlTitle
        '
        Me.pnlTitle.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlTitle.Controls.Add(Me.lblTimer)
        Me.pnlTitle.Controls.Add(Me.lblCaption)
        Me.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTitle.Location = New System.Drawing.Point(0, 0)
        Me.pnlTitle.Name = "pnlTitle"
        Me.pnlTitle.Size = New System.Drawing.Size(754, 50)
        Me.pnlTitle.TabIndex = 0
        '
        'lblTimer
        '
        Me.lblTimer.Location = New System.Drawing.Point(616, 16)
        Me.lblTimer.Name = "lblTimer"
        Me.lblTimer.Size = New System.Drawing.Size(128, 24)
        Me.lblTimer.TabIndex = 1
        Me.lblTimer.Tag = "lblTimer"
        Me.lblTimer.Text = "lblTimer"
        Me.lblTimer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCaption
        '
        Me.lblCaption.Location = New System.Drawing.Point(16, 17)
        Me.lblCaption.Name = "lblCaption"
        Me.lblCaption.Size = New System.Drawing.Size(464, 23)
        Me.lblCaption.TabIndex = 0
        Me.lblCaption.Tag = "lblCaption"
        Me.lblCaption.Text = "lblCaption"
        '
        'pnCIACCTNO
        '
        Me.pnCIACCTNO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnCIACCTNO.Location = New System.Drawing.Point(8, 80)
        Me.pnCIACCTNO.Name = "pnCIACCTNO"
        Me.pnCIACCTNO.Size = New System.Drawing.Size(240, 272)
        Me.pnCIACCTNO.TabIndex = 2
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(664, 360)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 24)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "btnCancel"
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(568, 360)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(88, 24)
        Me.btnSubmit.TabIndex = 4
        Me.btnSubmit.Tag = "btnSubmit"
        Me.btnSubmit.Text = "btnSubmit"
        '
        'tmrOrder
        '
        '
        'pnBnkAccount
        '
        Me.pnBnkAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnBnkAccount.Location = New System.Drawing.Point(272, 80)
        Me.pnBnkAccount.Name = "pnBnkAccount"
        Me.pnBnkAccount.Size = New System.Drawing.Size(472, 272)
        Me.pnBnkAccount.TabIndex = 6
        '
        'lblCIInfo
        '
        Me.lblCIInfo.Location = New System.Drawing.Point(8, 56)
        Me.lblCIInfo.Name = "lblCIInfo"
        Me.lblCIInfo.Size = New System.Drawing.Size(240, 23)
        Me.lblCIInfo.TabIndex = 7
        Me.lblCIInfo.Tag = "lblCIInfo"
        Me.lblCIInfo.Text = "lblCIInfo"
        '
        'lblBnkInfo
        '
        Me.lblBnkInfo.Location = New System.Drawing.Point(280, 56)
        Me.lblBnkInfo.Name = "lblBnkInfo"
        Me.lblBnkInfo.Size = New System.Drawing.Size(456, 23)
        Me.lblBnkInfo.TabIndex = 8
        Me.lblBnkInfo.Tag = "lblBnkInfo"
        Me.lblBnkInfo.Text = "lblBnkInfo"
        '
        'frmTransferInq
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(754, 392)
        Me.Controls.Add(Me.lblBnkInfo)
        Me.Controls.Add(Me.lblCIInfo)
        Me.Controls.Add(Me.pnBnkAccount)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.pnCIACCTNO)
        Me.Controls.Add(Me.pnlTitle)
        Me.Controls.Add(Me.btnSubmit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTransferInq"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmTransferInq"
        Me.pnlTitle.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Declare constant and variables "
    Const c_ResourceManager = "_DIRECT.frmTransferInq-"
    Friend WithEvents ExtCIGrid As GridEx
    Friend WithEvents ExtBankAccGrid As GridEx

    
    Dim mv_strTellerName As String
    Dim tickCount As Double
    Private mv_strCurrentTime As String = String.Empty
    Private mv_strLanguage As String
    Private mv_ResourceManager As Resources.ResourceManager
    Private mv_arrObjFields() As CFieldMaster
    Private mv_arrObjFldVals() As CFieldVal
    Private mv_arrObjAccounts() As CAccountEntry
    Private mv_xmlDocumentInquiryData As Xml.XmlDocument
    Private m_blnGridCI As Boolean = False
    Private m_blnGridBnk As Boolean = False
    Private mv_strXmlMessageData As String
    Private mv_strLocalObject As String
    Private mv_strBranchId As String
    Private mv_strTellerId As String
    Private mv_strTellerType As String
    Private mv_strIpAddress As String
    Private mv_strWsName As String
    Private mv_strBusDate As String = String.Empty
    Private mv_strTxDate As String = String.Empty
    Private mv_strTxNum As String = String.Empty

    
    Private mv_intCurrentRow As Integer

    Private Const CONTROL_PNL_CONTRACT_TOP = 200
    Private Const CONTROL_BUTTON_TOP = 400
    Private Const FRM_DEFAULT_HEIGHT = 260
    Private Const FRM_EXTEND_HEIGHT = 460

    Private mv_strOrderStatus As String
    Private mv_strAccountInq As String
#End Region

#Region " Properties "
    Public Property AccountInquiry() As String
        Get
            Return mv_strAccountInq
        End Get
        Set(ByVal Value As String)
            mv_strAccountInq = Value
        End Set
    End Property

    Public Property CurrentTime() As String
        Get
            Return mv_strCurrentTime
        End Get
        Set(ByVal Value As String)
            mv_strCurrentTime = Value
        End Set
    End Property
    Public Property TellerName() As String
        Get
            Return mv_strTellerName
        End Get
        Set(ByVal Value As String)
            mv_strTellerName = Value
        End Set
    End Property

    Public Property TellerType() As String
        Get
            Return mv_strTellerType
        End Get
        Set(ByVal Value As String)
            mv_strTellerType = Value
        End Set
    End Property
    Public Property BusDate() As String
        Get
            Return mv_strBusDate
        End Get
        Set(ByVal Value As String)
            mv_strBusDate = Value
        End Set
    End Property

    Public Property TxDate() As String
        Get
            Return mv_strTxDate
        End Get
        Set(ByVal Value As String)
            mv_strTxDate = Value
        End Set
    End Property

    Public Property TxNum() As String
        Get
            Return mv_strTxNum
        End Get
        Set(ByVal Value As String)
            mv_strTxNum = Value
        End Set
    End Property

    Public Property MessageData() As String
        Get
            Return mv_strXmlMessageData
        End Get
        Set(ByVal Value As String)
            mv_strXmlMessageData = Value
        End Set
    End Property

    Public Property IpAddress() As String
        Get
            Return mv_strIpAddress
        End Get
        Set(ByVal Value As String)
            mv_strIpAddress = Value
        End Set
    End Property

    Public Property WsName() As String
        Get
            Return mv_strWsName
        End Get
        Set(ByVal Value As String)
            mv_strWsName = Value
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

    Public Property LocalObject() As String
        Get
            Return mv_strLocalObject
        End Get
        Set(ByVal Value As String)
            mv_strLocalObject = Value
        End Set
    End Property

    Public Property UserLanguage() As String
        Get
            Return mv_strLanguage
        End Get
        Set(ByVal Value As String)
            mv_strLanguage = Value
        End Set
    End Property


#End Region

#Region " Other Methods "
    Public Sub GetAccount(Optional ByVal pv_strACCTNO As String = "")
        Dim v_strCmdInquiry, v_strFilter As String
        Dim v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        'v_strCmdInquiry = "SELECT CFO.*,getbaldefovd('" & Me.AccountInquiry & "') AVLCASH, CF.CUSTODYCD FROM CFOTHERACC CFO, AFMAST AF,CFMAST CF WHERE CFO.CFCUSTID = AF.CUSTID AND AF.CUSTID= CF.CUSTID AND AF.ACCTNO = '" & pv_strACCTNO & "' AND CFO.TYPE='0' "
        v_strCmdInquiry = "SELECT * from vw_GetAccountInternalTransfer where ACCTNO = '" & pv_strACCTNO & "' "
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_OD_ODMAST, gc_ActionInquiry, v_strCmdInquiry)
        v_ws.Message(v_strObjMsg)
        FillDataGrid(ExtCIGrid, v_strObjMsg, "")
        v_strCmdInquiry = "SELECT * from vw_GetAccountExternalTransfer where ACCTNO = '" & pv_strACCTNO & "'"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_OD_ODMAST, gc_ActionInquiry, v_strCmdInquiry)
        v_ws.Message(v_strObjMsg)
        FillDataGrid(ExtBankAccGrid, v_strObjMsg, "")
    End Sub
    Private Sub InitializeGrid()
        'Khởi tạo Grid contacts
        ' Khoi tao ExtCIGrid
        ExtCIGrid = New GridEx
        Dim v_cmrExtReferHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrExtReferHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrExtReferHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        ExtCIGrid.FixedHeaderRows.Add(v_cmrExtReferHeader)


        ExtCIGrid.Columns.Add(New Xceed.Grid.Column("AUTOID", GetType(Integer)))
        ExtCIGrid.Columns("AUTOID").Width = 0
        ExtCIGrid.Columns.Add(New Xceed.Grid.Column("CIACCOUNT", GetType(System.String)))
        ExtCIGrid.Columns("CIACCOUNT").Title = mv_ResourceManager.GetString("grid.CIACCOUNT")

        ExtCIGrid.Columns.Add(New Xceed.Grid.Column("CINAME", GetType(System.String)))
        ExtCIGrid.Columns("CINAME").Title = mv_ResourceManager.GetString("grid.CINAME")
        ExtCIGrid.Columns.Add(New Xceed.Grid.Column("CUSTODYCD", GetType(System.String)))
        ExtCIGrid.Columns("CUSTODYCD").Title = mv_ResourceManager.GetString("grid.CUSTODYCD")
        ExtCIGrid.Columns.Add(New Xceed.Grid.Column("FULLNAME", GetType(System.String)))
        ExtCIGrid.Columns("FULLNAME").Title = mv_ResourceManager.GetString("grid.FULLNAME")
        ExtCIGrid.Columns.Add(New Xceed.Grid.Column("CUSTODYCDR", GetType(System.String)))
      
        ExtCIGrid.Columns("CUSTODYCDR").Title = mv_ResourceManager.GetString("grid.CUSTODYCDR")
        ExtCIGrid.Columns.Add(New Xceed.Grid.Column("ADDRESS", GetType(System.String)))
        ExtCIGrid.Columns("ADDRESS").Title = mv_ResourceManager.GetString("grid.ADDRESS")
        ExtCIGrid.Columns.Add(New Xceed.Grid.Column("IDCODE", GetType(System.String)))
        ExtCIGrid.Columns("IDCODE").Title = mv_ResourceManager.GetString("grid.IDCODE")

        ExtCIGrid.Columns.Add(New Xceed.Grid.Column("AVLCASH", GetType(System.String)))
        ExtCIGrid.Columns("AVLCASH").Title = "AVLCASH"
        ExtCIGrid.Columns("AVLCASH").Visible = False

        ExtCIGrid.Columns.Add(New Xceed.Grid.Column("BANKBALANCE", GetType(System.String)))
        ExtCIGrid.Columns("BANKBALANCE").Title = "BANKBALANCE"
        ExtCIGrid.Columns("BANKBALANCE").Visible = False

        ExtCIGrid.Columns.Add(New Xceed.Grid.Column("BANKAVLBAL", GetType(System.String)))
        ExtCIGrid.Columns("BANKAVLBAL").Title = "BANKAVLBAL"
        ExtCIGrid.Columns("BANKAVLBAL").Visible = False

        pnCIACCTNO.Controls.Clear()
        pnCIACCTNO.Controls.Add(ExtCIGrid)
        ExtCIGrid.Dock = DockStyle.Fill

        AddHandler ExtCIGrid.Click, AddressOf ExtCIGrid_Click
        If Me.ExtCIGrid.DataRowTemplate.Cells.Count >= 0 Then
            For i As Integer = 0 To Me.ExtCIGrid.DataRowTemplate.Cells.Count - 1
                AddHandler ExtCIGrid.DataRowTemplate.Cells(i).Click, AddressOf ExtCIGrid_Click
                AddHandler ExtCIGrid.DataRowTemplate.Cells(i).DoubleClick, AddressOf ExtCIGrid_DoubleClick
            Next
        End If

        ' Khoi tao ExtBankAccGrid
        ExtBankAccGrid = New GridEx
        Dim v_cmrExtBankHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrExtBankHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrExtBankHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        ExtBankAccGrid.FixedHeaderRows.Add(v_cmrExtBankHeader)

        ExtBankAccGrid.Columns.Add(New Xceed.Grid.Column("AUTOID", GetType(Integer)))
        ExtBankAccGrid.Columns("AUTOID").Width = 0
        ExtBankAccGrid.Columns.Add(New Xceed.Grid.Column("CUSTODYCD", GetType(System.String)))
        ExtBankAccGrid.Columns.Add(New Xceed.Grid.Column("CUSTID", GetType(System.String)))
        ExtBankAccGrid.Columns.Add(New Xceed.Grid.Column("BANKACC", GetType(System.String)))
        ExtBankAccGrid.Columns.Add(New Xceed.Grid.Column("BANKCODE", GetType(System.String)))
        ExtBankAccGrid.Columns.Add(New Xceed.Grid.Column("BANKACNAME", GetType(System.String)))
        ExtBankAccGrid.Columns.Add(New Xceed.Grid.Column("BANKNAME", GetType(System.String)))
        ExtBankAccGrid.Columns.Add(New Xceed.Grid.Column("ACNIDCODE", GetType(System.String)))
        ExtBankAccGrid.Columns.Add(New Xceed.Grid.Column("ACNIDDATE", GetType(System.String)))
        ExtBankAccGrid.Columns.Add(New Xceed.Grid.Column("ACNIDPLACE", GetType(System.String)))
        ExtBankAccGrid.Columns.Add(New Xceed.Grid.Column("CITYEF", GetType(System.String)))
        ExtBankAccGrid.Columns.Add(New Xceed.Grid.Column("CITYBANK", GetType(System.String)))
        ExtBankAccGrid.Columns.Add(New Xceed.Grid.Column("FEECD", GetType(System.String)))

        ExtBankAccGrid.Columns("CUSTODYCD").Title = mv_ResourceManager.GetString("grid.CUSTODYCD")
        ExtBankAccGrid.Columns("CUSTID").Title = mv_ResourceManager.GetString("grid.CUSTID")
        ExtBankAccGrid.Columns("BANKACC").Title = mv_ResourceManager.GetString("grid.BANKACC")
        ExtBankAccGrid.Columns("BANKCODE").Title = mv_ResourceManager.GetString("grid.BANKCODE")
        ExtBankAccGrid.Columns("BANKACNAME").Title = mv_ResourceManager.GetString("grid.BANKACNAME")
        ExtBankAccGrid.Columns("BANKNAME").Title = mv_ResourceManager.GetString("grid.BANKNAME")

        ExtBankAccGrid.Columns("ACNIDCODE").Title = mv_ResourceManager.GetString("grid.ACNIDCODE")
        ExtBankAccGrid.Columns("ACNIDDATE").Title = mv_ResourceManager.GetString("grid.ACNIDDATE")
        ExtBankAccGrid.Columns("ACNIDPLACE").Title = mv_ResourceManager.GetString("grid.ACNIDPLACE")
        ExtBankAccGrid.Columns("CITYEF").Title = mv_ResourceManager.GetString("grid.CITYEF")
        ExtBankAccGrid.Columns("CITYBANK").Title = mv_ResourceManager.GetString("grid.CITYBANK")
        ExtBankAccGrid.Columns("FEECD").Title = mv_ResourceManager.GetString("grid.FEECD")

        ExtBankAccGrid.Columns.Add(New Xceed.Grid.Column("AVLCASH", GetType(System.String)))
        ExtBankAccGrid.Columns("AVLCASH").Title = "AVLCASH"
        ExtBankAccGrid.Columns("AVLCASH").Visible = False

        pnBnkAccount.Controls.Clear()
        pnBnkAccount.Controls.Add(ExtBankAccGrid)
        ExtBankAccGrid.Dock = DockStyle.Fill
        AddHandler ExtBankAccGrid.Click, AddressOf ExtBankAccGrid_Click
        If Me.ExtBankAccGrid.DataRowTemplate.Cells.Count >= 0 Then
            For i As Integer = 0 To Me.ExtBankAccGrid.DataRowTemplate.Cells.Count - 1
                AddHandler ExtBankAccGrid.DataRowTemplate.Cells(i).Click, AddressOf ExtBankAccGrid_Click
                AddHandler ExtBankAccGrid.DataRowTemplate.Cells(i).DoubleClick, AddressOf ExtBankAccGrid_DoubleClick
            Next
        End If
        AddHandler ExtBankAccGrid.KeyUp, AddressOf ExtBankAccGrid_KeyUp
    End Sub

    Private Sub ShowTransferForm(ByVal v_strTLTXCD As String, ByVal v_xceedRow As Xceed.Grid.DataRow)
        'Nạp và thực hiện giao dịch
        Dim v_strMODCODE As String = "CI"
        Dim mv_frmTransactScreen As frmTransact
        Dim v_strValue, v_strFLDNAME, v_strFLDCD, v_strFLDCODE, v_strFLDDEFVAL, v_strFIELDTYPE As String, i, j, v_intRow As Integer
        If v_strTLTXCD = "1130" Then
            v_strFLDDEFVAL = ""
            v_strFLDDEFVAL = v_strFLDDEFVAL & "[" & "03" & "." & Me.AccountInquiry & "]"
            v_strFLDDEFVAL = v_strFLDDEFVAL & "[" & "05" & "." & Trim(v_xceedRow.Cells("CIACCOUNT").Value) & "]"
            v_strFLDDEFVAL = v_strFLDDEFVAL & "[" & "93" & "." & Trim(v_xceedRow.Cells("CINAME").Value) & "]"
            v_strFLDDEFVAL = v_strFLDDEFVAL & "[" & "87" & "." & Trim(v_xceedRow.Cells("AVLCASH").Value) & "]"
            v_strFLDDEFVAL = v_strFLDDEFVAL & "[" & "14" & "." & Trim(v_xceedRow.Cells("BANKBALANCE").Value) & "]"
            v_strFLDDEFVAL = v_strFLDDEFVAL & "[" & "15" & "." & Trim(v_xceedRow.Cells("BANKAVLBAL").Value) & "]"
            v_strFLDDEFVAL = v_strFLDDEFVAL & "[" & "88" & "." & Trim(v_xceedRow.Cells("CUSTODYCD").Value) & "]"
            v_strFLDDEFVAL = v_strFLDDEFVAL & "[" & "89" & "." & Trim(v_xceedRow.Cells("CUSTODYCDR").Value) & "]"
            v_strFLDDEFVAL = v_strFLDDEFVAL & "[" & "90" & "." & Trim(v_xceedRow.Cells("FULLNAME").Value) & "]"
            v_strFLDDEFVAL = v_strFLDDEFVAL & "[" & "91" & "." & Trim(v_xceedRow.Cells("ADDRESS").Value) & "]"
            v_strFLDDEFVAL = v_strFLDDEFVAL & "[" & "92" & "." & Trim(v_xceedRow.Cells("IDCODE").Value) & "]"

        End If
        If v_strTLTXCD = "1111" Then
            v_strFLDDEFVAL = ""
            'v_strFLDDEFVAL = v_strFLDDEFVAL & "[" & "03" & "." & Me.AccountInquiry & "]"
            'v_strFLDDEFVAL = v_strFLDDEFVAL & "[" & "05" & "." & "0001004795" & "]"
            'v_strFLDDEFVAL = v_strFLDDEFVAL & "[" & "09" & "." & "1" & "]"
            'v_strFLDDEFVAL = v_strFLDDEFVAL & "[" & "81" & "." & Trim(v_xceedRow.Cells("BANKACC").Value) & "]"
            'v_strFLDDEFVAL = v_strFLDDEFVAL & "[" & "82" & "." & Trim(v_xceedRow.Cells("BANKACNAME").Value) & "]"
            'v_strFLDDEFVAL = v_strFLDDEFVAL & "[" & "83" & "." & Trim(v_xceedRow.Cells("BANKNAME").Value) & "]"
            'TruongLD Fix lại như sau
            v_strFLDDEFVAL = v_strFLDDEFVAL & "[" & "88" & "." & Trim(v_xceedRow.Cells("CUSTODYCD").Value) & "]"
            v_strFLDDEFVAL = v_strFLDDEFVAL & "[" & "03" & "." & Me.AccountInquiry & "]"
            v_strFLDDEFVAL = v_strFLDDEFVAL & "[" & "05" & "." & Trim(v_xceedRow.Cells("BANKCODE").Value) & "]"
            'v_strFLDDEFVAL = v_strFLDDEFVAL & "[" & "09" & "." & "1" & "]"
            v_strFLDDEFVAL = v_strFLDDEFVAL & "[" & "66" & "." & Trim(v_xceedRow.Cells("FEECD").Value) & "]"
            v_strFLDDEFVAL = v_strFLDDEFVAL & "[" & "80" & "." & Trim(v_xceedRow.Cells("BANKNAME").Value) & "]"
            v_strFLDDEFVAL = v_strFLDDEFVAL & "[" & "81" & "." & Trim(v_xceedRow.Cells("BANKACC").Value) & "]"
            v_strFLDDEFVAL = v_strFLDDEFVAL & "[" & "82" & "." & Trim(v_xceedRow.Cells("BANKACNAME").Value) & "]"
            v_strFLDDEFVAL = v_strFLDDEFVAL & "[" & "83" & "." & Trim(v_xceedRow.Cells("ACNIDCODE").Value) & "]"
            v_strFLDDEFVAL = v_strFLDDEFVAL & "[" & "95" & "." & Trim(v_xceedRow.Cells("ACNIDDATE").Value) & "]"
            v_strFLDDEFVAL = v_strFLDDEFVAL & "[" & "96" & "." & Trim(v_xceedRow.Cells("ACNIDPLACE").Value) & "]"
            v_strFLDDEFVAL = v_strFLDDEFVAL & "[" & "89" & "." & Trim(v_xceedRow.Cells("AVLCASH").Value) & "]"
            v_strFLDDEFVAL = v_strFLDDEFVAL & "[" & "85" & "." & Trim(v_xceedRow.Cells("CITYEF").Value) & "]"
            v_strFLDDEFVAL = v_strFLDDEFVAL & "[" & "84" & "." & Trim(v_xceedRow.Cells("CITYBANK").Value) & "]"

        End If
        mv_frmTransactScreen = New frmTransactMaster(mv_strLanguage)
        If v_strMODCODE <> "" And v_strTLTXCD <> "" Then
            mv_frmTransactScreen.ObjectName = v_strTLTXCD
            mv_frmTransactScreen.ModuleCode = v_strMODCODE
            mv_frmTransactScreen.LocalObject = gc_IsNotLocalMsg
            mv_frmTransactScreen.BranchId = Me.BranchId
            mv_frmTransactScreen.TellerId = Me.TellerId
            mv_frmTransactScreen.IpAddress = Me.IpAddress
            mv_frmTransactScreen.WsName = Me.WsName
            mv_frmTransactScreen.DefaultValue = v_strFLDDEFVAL
            mv_frmTransactScreen.BusDate = Me.BusDate
            mv_frmTransactScreen.AutoClosedWhenOK = True
            mv_frmTransactScreen.ShowDialog()
            mv_frmTransactScreen.Dispose()
            'Reset lại giá trị
            v_strFLDDEFVAL = String.Empty
        End If
    End Sub

    Private Sub ComputeUpTime()
        Dim nTicks As Double
        Dim nDays As Integer
        Dim nHours As Integer
        Dim nMin As Integer
        Dim nSec As Integer
        Dim TimeUp As String
        nTicks = tickCount
        nTicks = nTicks / 1000
        nTicks = nTicks - (Int(nTicks / (3600 * 24)) * (3600 * 24))
        nHours = Int(nTicks / 3600)
        nTicks = nTicks - (Int(nTicks / 3600) * 3600)
        nMin = Int(nTicks / 60)
        nTicks = nTicks - (Int(nTicks / 60) * 60)
        nSec = nTicks
        lblTimer.Text = Format$(nHours, "00") & ":" & Format$(nMin, "00") & ":" & Format$(nSec, "00")
        tickCount += 1000
    End Sub

#End Region

#Region " Other method "
    Protected Overridable Function InitDialog()
        Me.tmrOrder.Interval = 1000
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        LoadResource(Me)
        tickCount = CDec(Strings.Left(mv_strCurrentTime, 2)) * 3600
        tickCount += CDec(Strings.Mid(mv_strCurrentTime, 4, 2)) * 60
        tickCount += CDec(Strings.Right(mv_strCurrentTime, 2))
        tickCount *= 1000
        tmrOrder.Start()
        tmrOrder.Enabled = True
    End Function
    Private Sub OnClose()
        Me.Dispose()
    End Sub
    Private Sub LoadResource(ByRef pv_ctrl As Windows.Forms.Control)
        Dim v_ctrl As Windows.Forms.Control

        For Each v_ctrl In pv_ctrl.Controls
            If TypeOf (v_ctrl) Is Label Then
                CType(v_ctrl, Label).Text = mv_ResourceManager.GetString(v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is CheckBox Then
                CType(v_ctrl, CheckBox).Text = mv_ResourceManager.GetString(v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is GroupBox Then
                CType(v_ctrl, GroupBox).Text = mv_ResourceManager.GetString(v_ctrl.Name)
                LoadResource(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is Button Then
                CType(v_ctrl, Button).Text = mv_ResourceManager.GetString(v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is Panel Then
                LoadResource(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is DateTimePicker Then
                CType(v_ctrl, DateTimePicker).Value = CDate(Me.BusDate)
            End If
        Next
        Me.Text = mv_ResourceManager.GetString(Me.Name)
    End Sub
#End Region



#Region " Event "
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub


    Private Sub frmTeleInq_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Select Case e.KeyCode
            Case Keys.Escape
                OnClose()
            Case Keys.F5
                GetAccount(Me.AccountInquiry)
            Case Keys.Enter
                GetAccount(Me.AccountInquiry)
            Case Keys.End
        End Select
    End Sub
#End Region

    Private Sub tmrOrder_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrOrder.Tick
        ComputeUpTime()
    End Sub

    Private Sub frmTransferInq_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitializeGrid()
        InitDialog()
        GetAccount(Me.AccountInquiry)
        'Add any initialization after the InitializeComponent() call
        mv_xmlDocumentInquiryData = New Xml.XmlDocument
    End Sub

    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        'Giao dich Transfer in. Goi den giao dich 1120
        If Me.m_blnGridCI Then
            If Me.ExtCIGrid.DataRows.Count > 0 Then
                If Not ExtCIGrid.CurrentRow Is Nothing Then
                    Dim v_strCreditAcctno = Trim(CType(ExtCIGrid.CurrentRow, Xceed.Grid.DataRow).Cells("CIACCOUNT").Value)
                    ShowTransferForm("1130", ExtCIGrid.CurrentRow)
                End If
            End If
            Exit Sub
        End If
        'Giao dich Transfer out. Goi den giao dich 1101
        If Me.m_blnGridBnk Then
            If Me.ExtBankAccGrid.DataRows.Count > 0 Then
                If Not ExtBankAccGrid.CurrentRow Is Nothing Then
                    ShowTransferForm("1111", ExtBankAccGrid.CurrentRow)
                End If
            End If
            Exit Sub
        End If
    End Sub

    Private Sub ExtCIGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ExtCIGrid.Click
        Cursor.Current = Cursors.WaitCursor
        Cursor.Show()
        If Not (ExtCIGrid.CurrentRow Is Nothing) Then
            m_blnGridCI = True
            m_blnGridBnk = False
        End If
    End Sub


    Private Sub ExtBankAccGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ExtBankAccGrid.Click
        Cursor.Current = Cursors.WaitCursor
        Cursor.Show()
        If Not (ExtBankAccGrid.CurrentRow Is Nothing) Then
            m_blnGridCI = False
            m_blnGridBnk = True
        End If
    End Sub

    Private Sub ExtCIGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ExtCIGrid.DoubleClick
        Cursor.Current = Cursors.WaitCursor
        Cursor.Show()
        If Not (ExtCIGrid.CurrentRow Is Nothing) Then
            m_blnGridCI = True
            m_blnGridBnk = False
        End If
        btnSubmit_Click(sender, e)
    End Sub

    Private Sub ExtBankAccGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ExtBankAccGrid.DoubleClick
        Cursor.Current = Cursors.WaitCursor
        Cursor.Show()
        If Not (ExtBankAccGrid.CurrentRow Is Nothing) Then
            m_blnGridCI = False
            m_blnGridBnk = True
        End If
        btnSubmit_Click(sender, e)
    End Sub

    Private Sub ExtBankAccGrid_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ExtBankAccGrid.KeyUp
        If e.KeyCode = Keys.Enter Then
            If Me.ExtBankAccGrid.DataRows.Count > 0 Then
                If Not ExtBankAccGrid.CurrentRow Is Nothing Then
                    ShowTransferForm("1111", ExtBankAccGrid.CurrentRow)
                End If
            End If
        End If
    End Sub

    Private Sub ExtCIGrid_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ExtCIGrid.KeyUp
        If e.KeyCode = Keys.Enter Then
            If Not ExtCIGrid.CurrentRow Is Nothing Then
                Dim v_strCreditAcctno = Trim(CType(ExtCIGrid.CurrentRow, Xceed.Grid.DataRow).Cells("CIACCOUNT").Value)
                ShowTransferForm("1130", ExtCIGrid.CurrentRow)
            End If
        End If
    End Sub

End Class
