Imports System.Windows.Forms
Imports Xceed.SmartUI.Controls
Imports CommonLibrary
Imports System.Collections
Imports AppCore
Imports AppCore.modCoreLib
Imports System.IO
Imports System.Globalization



Public Class frmViewAcc
    Inherits System.Windows.Forms.Form

    Friend WithEvents ResultGrid As New GridEx
    Private ResourceManager As Resources.ResourceManager

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal pv_strLanguage As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        mv_strLanguage = pv_strLanguage
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        InitializeGrid()
        InitDialog()
        'Add any initialization after the InitializeComponent() call
        mv_xmlDocumentInquiryData = New Xml.XmlDocument
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
    Friend WithEvents btnConnect As System.Windows.Forms.Button
    Friend WithEvents pnODSendInfo As System.Windows.Forms.Panel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.pnlTitle = New System.Windows.Forms.Panel
        Me.dtpTo = New System.Windows.Forms.DateTimePicker
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl
        Me.btnGetAll = New DevExpress.XtraEditors.SimpleButton
        Me.lblCustodycd = New DevExpress.XtraEditors.LabelControl
        Me.btnButton = New DevExpress.XtraEditors.SimpleButton
        Me.txtCustodycd = New DevExpress.XtraEditors.TextEdit
        Me.pnODSendInfo = New System.Windows.Forms.Panel
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnConnect = New System.Windows.Forms.Button
        Me.btnExport = New System.Windows.Forms.Button
        Me.pnlTitle.SuspendLayout()
        CType(Me.txtCustodycd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlTitle
        '
        Me.pnlTitle.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlTitle.Controls.Add(Me.dtpTo)
        Me.pnlTitle.Controls.Add(Me.dtpFrom)
        Me.pnlTitle.Controls.Add(Me.LabelControl3)
        Me.pnlTitle.Controls.Add(Me.LabelControl2)
        Me.pnlTitle.Controls.Add(Me.LabelControl1)
        Me.pnlTitle.Controls.Add(Me.btnGetAll)
        Me.pnlTitle.Controls.Add(Me.lblCustodycd)
        Me.pnlTitle.Controls.Add(Me.btnButton)
        Me.pnlTitle.Controls.Add(Me.txtCustodycd)
        Me.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTitle.Location = New System.Drawing.Point(0, 0)
        Me.pnlTitle.Name = "pnlTitle"
        Me.pnlTitle.Size = New System.Drawing.Size(794, 76)
        Me.pnlTitle.TabIndex = 0
        '
        'dtpTo
        '
        Me.dtpTo.CustomFormat = "dd/MM/yyyy"
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTo.Location = New System.Drawing.Point(373, 20)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(94, 20)
        Me.dtpTo.TabIndex = 13
        Me.dtpTo.Tag = "IDDATE"
        '
        'dtpFrom
        '
        Me.dtpFrom.CustomFormat = "dd/MM/yyyy"
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFrom.Location = New System.Drawing.Point(220, 19)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(94, 20)
        Me.dtpFrom.TabIndex = 12
        Me.dtpFrom.Tag = "IDDATE"
        'Me.dtpFrom.Value = New Date(2014, 1, 1, 0, 0, 0, 0)
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(320, 23)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(47, 13)
        Me.LabelControl3.TabIndex = 6
        Me.LabelControl3.Text = "Đến ngày"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(168, 22)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(40, 13)
        Me.LabelControl2.TabIndex = 5
        Me.LabelControl2.Text = "Từ ngày"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 48)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(126, 13)
        Me.LabelControl1.TabIndex = 4
        Me.LabelControl1.Text = "F5 để tìm kiếm khách hàng"
        '
        'btnGetAll
        '
        Me.btnGetAll.Location = New System.Drawing.Point(612, 18)
        Me.btnGetAll.Name = "btnGetAll"
        Me.btnGetAll.Size = New System.Drawing.Size(97, 23)
        Me.btnGetAll.TabIndex = 3
        Me.btnGetAll.Text = "Search By Edit"
        '
        'lblCustodycd
        '
        Me.lblCustodycd.Location = New System.Drawing.Point(12, 22)
        Me.lblCustodycd.Name = "lblCustodycd"
        Me.lblCustodycd.Size = New System.Drawing.Size(46, 13)
        Me.lblCustodycd.TabIndex = 2
        Me.lblCustodycd.Text = "Mã lưu ký"
        '
        'btnButton
        '
        Me.btnButton.Location = New System.Drawing.Point(484, 18)
        Me.btnButton.Name = "btnButton"
        Me.btnButton.Size = New System.Drawing.Size(96, 23)
        Me.btnButton.TabIndex = 1
        Me.btnButton.Text = "Search By Open"
        '
        'txtCustodycd
        '
        Me.txtCustodycd.EditValue = "SHVC"
        Me.txtCustodycd.Location = New System.Drawing.Point(64, 19)
        Me.txtCustodycd.Name = "txtCustodycd"
        Me.txtCustodycd.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCustodycd.Size = New System.Drawing.Size(100, 20)
        Me.txtCustodycd.TabIndex = 0
        '
        'pnODSendInfo
        '
        Me.pnODSendInfo.BackColor = System.Drawing.SystemColors.Control
        Me.pnODSendInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnODSendInfo.Location = New System.Drawing.Point(8, 82)
        Me.pnODSendInfo.Name = "pnODSendInfo"
        Me.pnODSendInfo.Size = New System.Drawing.Size(776, 454)
        Me.pnODSendInfo.TabIndex = 2
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(704, 544)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 24)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "btnCancel"
        '
        'btnConnect
        '
        Me.btnConnect.Location = New System.Drawing.Point(484, 545)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(133, 24)
        Me.btnConnect.TabIndex = 4
        Me.btnConnect.Text = "btnConnect"
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(623, 545)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(75, 23)
        Me.btnExport.TabIndex = 29
        Me.btnExport.Tag = "btnExport"
        Me.btnExport.Text = "btnExport"
        '
        'frmViewAcc
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(794, 575)
        Me.Controls.Add(Me.btnConnect)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.pnODSendInfo)
        Me.Controls.Add(Me.pnlTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Name = "frmViewAcc"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmViewAcc"
        Me.pnlTitle.ResumeLayout(False)
        Me.pnlTitle.PerformLayout()
        CType(Me.txtCustodycd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Declare constant and variables "
    Const c_ResourceManager = "_DIRECT.frmViewAcc-"

    Dim mv_strEXECTYPE, mv_strEXECTYPE_VAL, mv_strCUSTODYCD, mv_strSYMBOL, mv_strBANKNAME, mv_strFULLNAME, mv_strACCTNO, mv_strIDCODE, mv_strCOREBANK, mv_strBANKACCTNO As String
    Dim mv_strOODSTATUS, mv_strPRICE, mv_strQTTY, mv_strORDERID, mv_strORDERQTTY, mv_strDESC_PRICETYPE, mv_strQUOTEPRICE, mv_strLIMITPRICE As String
    Dim mv_strCURRPRICE, mv_strMATCHTYPE, mv_strNORK, mv_strCODEID, mv_strSECURERATIOTMIN, mv_strSECURERATIOMAX, mv_strTYP_BRATIO, mv_strAF_BRATIO As String


    Dim mv_strLastAFACCTNO As String = String.Empty
    Dim mv_dblFloorPrice As Double
    Dim mv_dblCeilingPrice As Double
    Dim mv_dblTradeLot As Double
    Dim mv_dblTradeUnit As Double
    Dim mv_dblSecureRatio As Double

    Private mv_blnIsPutthrough As Boolean = False
    Private mv_strAction As String = "N"
    Private mv_strSQLCMD As String = String.Empty
    Private mv_strObjectName As String
    Private mv_strTltxcd As String
    Private mv_strModuleCode As String

    Private mv_strLanguage As String
    Private mv_blnAcctEntry As Boolean = False
    Private mv_blnTranAdjust As Boolean = False
    Private mv_blnIsHistoryView As Boolean = False
    Private mv_blnAllowViewCF As Boolean = True
    Private mv_ResourceManager As Resources.ResourceManager
    Private mv_arrObjFields() As CFieldMaster
    Private mv_arrObjFldVals() As CFieldVal
    Private mv_arrObjAccounts() As CAccountEntry
    Private mv_xmlDocumentInquiryData As Xml.XmlDocument

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

    Private mv_blnOrderSendingEx As Boolean = True
    Private mv_intCurrentRow As Integer
    Private mv_blnAdvancedSending As Boolean = True
    Private mv_strIDDATEVSD As String

    Private Const CONTROL_PNL_CONTRACT_TOP = 200
    Private Const CONTROL_BUTTON_TOP = 400
    Private Const FRM_DEFAULT_HEIGHT = 260
    Private Const FRM_EXTEND_HEIGHT = 460

    Private mv_strOrderStatus As String
#End Region

#Region " Properties "
    Public Property IsPutthought() As Boolean
        Get
            Return mv_blnIsPutthrough
        End Get
        Set(ByVal Value As Boolean)
            mv_blnIsPutthrough = Value
        End Set
    End Property

    Public Property Action() As String
        Get
            Return mv_strAction
        End Get
        Set(ByVal Value As String)
            mv_strAction = Value
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

    Public Property ModuleCode() As String
        Get
            Return mv_strModuleCode
        End Get
        Set(ByVal Value As String)
            mv_strModuleCode = Value
        End Set
    End Property

    Public Property ObjectName() As String
        Get
            Return mv_strObjectName
        End Get
        Set(ByVal Value As String)
            mv_strObjectName = Value
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

    Public Property Tltxcd() As String
        Get
            Return mv_strTltxcd
        End Get
        Set(ByVal Value As String)
            mv_strTltxcd = Value
        End Set
    End Property
    Public Property IsHistoryView() As Boolean
        Get
            Return mv_blnIsHistoryView
        End Get
        Set(ByVal Value As Boolean)
            mv_blnIsHistoryView = Value
        End Set
    End Property
    Public Property AllowViewCF() As Boolean
        Get
            Return mv_blnAllowViewCF
        End Get
        Set(ByVal Value As Boolean)
            mv_blnAllowViewCF = Value
        End Set
    End Property
    Public Property OrderSendingEx() As Boolean
        Get
            Return mv_blnOrderSendingEx
        End Get
        Set(ByVal Value As Boolean)
            mv_blnOrderSendingEx = Value
        End Set
    End Property
    Public Property AdvancedSending() As Boolean
        Get
            Return mv_blnAdvancedSending
        End Get
        Set(ByVal Value As Boolean)
            mv_blnAdvancedSending = Value
        End Set
    End Property

#End Region

#Region " Other Methods "
    Public Sub GetOrder()
        Dim v_strCmdInquiry, v_strFilter As String
        Dim d2 As DateTime

        If Action = "A" Then
            v_strCmdInquiry = "SELECT CF.CUSTODYCD,AF.ACCTNO,CF.FULLNAME,AF.CUSTID,AF.BANKACCTNO,CI.COREBANK,AF.BANKNAME FROM CIMAST CI,AFMAST AF,CFMAST CF,CRBDEFBANK CRB WHERE CI.AFACCTNO = AF.ACCTNO AND AF.CUSTID=CF.CUSTID AND CRB.BANKCODE=AF.BANKNAME AND AF.COREBANK='Y'"
        Else
            v_strCmdInquiry = "SELECT CF.CUSTODYCD,AF.ACCTNO,CF.FULLNAME,AF.CUSTID,AF.BANKACCTNO,CI.COREBANK,AF.BANKNAME FROM CIMAST CI,AFMAST AF,CFMAST CF,CRBDEFBANK CRB WHERE CI.AFACCTNO = AF.ACCTNO AND AF.CUSTID=CF.CUSTID AND CRB.BANKCODE=AF.BANKNAME AND AF.COREBANK='Y'"



        End If
        Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_OD_ODMAST, gc_ActionInquiry, v_strCmdInquiry)
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        v_ws.Message(v_strObjMsg)

        FillDataGrid(ResultGrid, v_strObjMsg, "")


        If mv_intCurrentRow >= ResultGrid.DataRows.Count Then mv_intCurrentRow = 0
        If ResultGrid.DataRows.Count > 0 Then
            ResultGrid.CurrentRow = ResultGrid.DataRows(mv_intCurrentRow)
            ResultGrid.SelectedRows.Clear()
            ResultGrid.SelectedRows.Add(ResultGrid.CurrentRow)
            btnConnect.Focus()
        End If

    End Sub
    Public Sub GetBankSearch()
        Dim v_strCmdInquiry As String
        Dim v_dateFrom, v_dateTo As String
        Dim v_custodycd As String
        If (Len(txtCustodycd.Text) > 4) Then
            v_custodycd = txtCustodycd.Text
        Else
            v_custodycd = ""
        End If
        v_dateFrom = Me.dtpFrom.Text
        v_dateTo = Me.dtpTo.Text
        If (Len(txtCustodycd.Text) < 5) Then
            v_strCmdInquiry = "SELECT CF.CUSTODYCD,AF.ACCTNO,CF.FULLNAME,AF.CUSTID,AF.BANKACCTNO,CI.COREBANK,AF.BANKNAME FROM CIMAST CI,AFMAST AF,CFMAST CF,CRBDEFBANK CRB WHERE CI.AFACCTNO = AF.ACCTNO AND AF.CUSTID=CF.CUSTID AND CRB.BANKCODE=AF.BANKNAME AND (AF.COREBANK='Y' OR AF.ALTERNATEACCT ='Y') AND AF.OPNDATE >= TO_DATE('" & v_dateFrom & "','dd/MM/yyyy') AND AF.OPNDATE <= TO_DATE('" & v_dateTo & "','dd/MM/yyyy')"
        Else
            v_strCmdInquiry = "SELECT CF.CUSTODYCD,AF.ACCTNO,CF.FULLNAME,AF.CUSTID,AF.BANKACCTNO,CI.COREBANK,AF.BANKNAME FROM CIMAST CI,AFMAST AF,CFMAST CF,CRBDEFBANK CRB WHERE CI.AFACCTNO = AF.ACCTNO AND AF.CUSTID=CF.CUSTID AND CRB.BANKCODE=AF.BANKNAME AND (AF.COREBANK='Y' OR AF.ALTERNATEACCT ='Y') AND CF.CUSTODYCD LIKE '" & v_custodycd & "' "
        End If
        Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_OD_ODMAST, gc_ActionInquiry, v_strCmdInquiry)
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        v_ws.Message(v_strObjMsg)

        FillDataGrid(ResultGrid, v_strObjMsg, "")


        If mv_intCurrentRow >= ResultGrid.DataRows.Count Then mv_intCurrentRow = 0
        If ResultGrid.DataRows.Count > 0 Then
            ResultGrid.CurrentRow = ResultGrid.DataRows(mv_intCurrentRow)
            ResultGrid.SelectedRows.Clear()
            ResultGrid.SelectedRows.Add(ResultGrid.CurrentRow)
            btnConnect.Focus()
        End If

    End Sub

    Public Sub GetBankSearchByEdit()
        Dim v_strCmdInquiry As String
        Dim v_dateFrom, v_dateTo As String
        Dim v_custodycd As String
        If (Len(txtCustodycd.Text) > 4) Then
            v_custodycd = txtCustodycd.Text
        Else
            v_custodycd = ""
        End If
        v_dateFrom = Me.dtpFrom.Text
        v_dateTo = Me.dtpTo.Text
        If (Len(txtCustodycd.Text) < 5) Then
            v_strCmdInquiry = "SELECT CF.CUSTODYCD,AF.ACCTNO,CF.FULLNAME,AF.CUSTID,AF.BANKACCTNO,CI.COREBANK,AF.BANKNAME  " & vbCrLf & _
                                " FROM CIMAST CI,AFMAST AF,CFMAST CF,CRBDEFBANK CRB, " & vbCrLf & _
                                "     ( " & vbCrLf & _
                                "     select distinct substr(child_record_key,11,10) AFACCTNO  " & vbCrLf & _
                                "     from maintain_log ml  " & vbCrLf & _
                                "     where table_name='CFMAST' and child_table_name='AFMAST'  " & vbCrLf & _
                                "     and column_name='BANKACCTNO' and to_value is not null " & vbCrLf & _
                                "     AND ml.approve_dt >= TO_DATE('" & v_dateFrom & "','dd/MM/yyyy')  " & vbCrLf & _
                                "     AND ml.approve_dt <= TO_DATE('" & v_dateTo & "','dd/MM/yyyy') " & vbCrLf & _
                                "     ) mtl " & vbCrLf & _
                                " WHERE CI.AFACCTNO = AF.ACCTNO AND AF.CUSTID=CF.CUSTID AND CRB.BANKCODE=AF.BANKNAME  " & vbCrLf & _
                                " AND (AF.COREBANK='Y' OR AF.ALTERNATEACCT ='Y')  " & vbCrLf & _
                                " AND AF.ACCTNO = MTL.AFACCTNO"
        Else
            v_strCmdInquiry = "SELECT CF.CUSTODYCD,AF.ACCTNO,CF.FULLNAME,AF.CUSTID,AF.BANKACCTNO,CI.COREBANK,AF.BANKNAME FROM CIMAST CI,AFMAST AF,CFMAST CF,CRBDEFBANK CRB WHERE CI.AFACCTNO = AF.ACCTNO AND AF.CUSTID=CF.CUSTID AND CRB.BANKCODE=AF.BANKNAME AND (AF.COREBANK='Y' OR AF.ALTERNATEACCT ='Y') AND CF.CUSTODYCD LIKE '" & v_custodycd & "' "
        End If
        Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_OD_ODMAST, gc_ActionInquiry, v_strCmdInquiry)
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        v_ws.Message(v_strObjMsg)

        FillDataGrid(ResultGrid, v_strObjMsg, "")


        If mv_intCurrentRow >= ResultGrid.DataRows.Count Then mv_intCurrentRow = 0
        If ResultGrid.DataRows.Count > 0 Then
            ResultGrid.CurrentRow = ResultGrid.DataRows(mv_intCurrentRow)
            ResultGrid.SelectedRows.Clear()
            ResultGrid.SelectedRows.Add(ResultGrid.CurrentRow)
            btnConnect.Focus()
        End If

    End Sub

    Private Sub InitializeGrid()
        'Khá»Ÿi táº¡o Grid contacts
        ResultGrid = New GridEx
        Dim v_cmrContactsHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrContactsHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrContactsHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        ResultGrid.FixedHeaderRows.Add(v_cmrContactsHeader)

        ResultGrid.Columns.Add(New Xceed.Grid.Column("CUSTODYCD", GetType(System.String)))
        ResultGrid.Columns.Add(New Xceed.Grid.Column("ACCTNO", GetType(System.String)))
        ResultGrid.Columns.Add(New Xceed.Grid.Column("FULLNAME", GetType(System.String)))
        ResultGrid.Columns.Add(New Xceed.Grid.Column("CUSTID", GetType(System.String)))
        ResultGrid.Columns.Add(New Xceed.Grid.Column("BANKNAME", GetType(System.String)))
        ResultGrid.Columns.Add(New Xceed.Grid.Column("BANKACCTNO", GetType(System.String)))
        ResultGrid.Columns.Add(New Xceed.Grid.Column("STATUS", GetType(System.String)))



        'Khai bao Resource
        ResultGrid.Columns("ACCTNO").Title = mv_ResourceManager.GetString("ACCTNO")
        ResultGrid.Columns("STATUS").Title = mv_ResourceManager.GetString("STATUS")
        ResultGrid.Columns("CUSTODYCD").Title = mv_ResourceManager.GetString("CUSTODYCD")
        ResultGrid.Columns("FULLNAME").Title = mv_ResourceManager.GetString("FULLNAME")
        ResultGrid.Columns("BANKNAME").Title = mv_ResourceManager.GetString("BANKNAME")
        ResultGrid.Columns("CUSTID").Title = mv_ResourceManager.GetString("CUSTID")
        ResultGrid.Columns("STATUS").Title = mv_ResourceManager.GetString("STATUS")
        ResultGrid.Columns("BANKACCTNO").Title = mv_ResourceManager.GetString("BANKACCTNO")





        ResultGrid.Columns("STATUS").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left


        Me.pnODSendInfo.Controls.Clear()
        Me.pnODSendInfo.Controls.Add(ResultGrid)
        ResultGrid.Dock = Windows.Forms.DockStyle.Fill
        'AddHandler ResultGrid.SelectedRowsChanged, AddressOf ODSendCurrentCellChanged
        If Me.ResultGrid.DataRowTemplate.Cells.Count >= 0 Then
            For i As Integer = 1 To Me.ResultGrid.DataRowTemplate.Cells.Count - 1
                AddHandler ResultGrid.DataRowTemplate.Cells(i).DoubleClick, AddressOf OnView
            Next
        End If



    End Sub
    Private Function CheckOrderStatus() As String
        Dim v_strFilter As String
        Dim v_strFLDNAME, v_strValue As String
        Dim v_strFieldType, v_strDataType As String
        Dim v_ctrl As Windows.Forms.Control
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_strErrorSource, v_strErrorMessage As String
        Dim v_lngErrorCode As Long

        Try
            Dim v_strClause As String

            v_strClause = Trim(CType(ResultGrid.CurrentRow, Xceed.Grid.DataRow).Cells("ORDERID").Value)

            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_strClause, "CheckOrderStatus", , , , IpAddress)
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            v_lngErrorCode = v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)

            'Kiá»ƒm tra thÃ´ng tin vÃ  xá»­ lÃ½ lá»—i (náº¿u cÃ³) tá»« message tráº£ vá»?            
            If v_lngErrorCode <> ERR_SYSTEM_OK Then
                'ThÃ´ng bÃ¡o lá»—i
                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                Cursor.Current = Cursors.Default
                MsgBox(v_strErrorMessage, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, Me.Text)
                Exit Function
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function

    Private Sub LoadODSend(ByVal pv_strSQLCMD As String)
        Try
            If Not ResultGrid Is Nothing And Len(pv_strSQLCMD) > 0 Then
                'Remove cÃ¡c báº£n ghi cÅ©
                ResultGrid.DataRows.Clear()
                Dim v_strSQL As String = pv_strSQLCMD
                Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_OD_ODMAST, gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                Dim v_strResourceManager As String

                FillDataGrid(ResultGrid, v_strObjMsg, "")

                If Me.ResultGrid.DataRows.Count > 0 Then
                    ResultGrid.CurrentRow = Me.ResultGrid.DataRows(0)
                    'setGridRowValue(ResultGrid.DataRows(0))
                End If

            End If
        Catch ex As Exception
            'MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub setBlankGridRowValue()
        mv_strMATCHTYPE = String.Empty
    End Sub

#End Region

#Region " Other method "

    '---------------------------------------------------------------------------------------------------------
    'HÃ m nÃ y Ä‘Æ°á»£c sá»­ dá»¥ng Ä‘á»ƒ náº¡p mÃ n hÃ¬nh.
    'Biáº¿n vÃ o 
    '   strTLTXCD lÃ  mÃ£ giao dá»‹ch, dÃ¹ng Ä‘á»ƒ xÃ¡c Ä‘á»‹nh cÃ¡c trÆ°á»?ng trong giao dá»‹ch
    '   v_blnChain  XÃ¡c Ä‘á»‹nh xem cÃ³ pháº£i náº¡p mÃ n hÃ¬nh sau khi Ä‘Ã£ tra cá»©u khÃ´ng
    '   v_blnData   XÃ¡c Ä‘á»‹nh xem cÃ³ pháº£i náº¡p mÃ n hÃ¬nh xem chi tiáº¿t giao dá»‹ch khÃ´ng
    '   v_strXML    LÃ  ná»™i dung chuá»—i XML tÆ°Æ¡ng á»©ng vá»›i v_blnChain hoáº·c v_blnData
    '---------------------------------------------------------------------------------------------------------

    Protected Overridable Function InitDialog()
        'Khá»Ÿi táº¡o kÃ­ch thÆ°á»›c form vÃ  load resource
        mv_strIDDATEVSD = dtpFrom.Text
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        LoadResource(Me)
        DoResizeForm()


        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strCmdSQL As String, v_strObjMsg As String



        setBlankGridRowValue()
    End Function

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click

        Try
            Dim v_dlgSave As New SaveFileDialog
            v_dlgSave.Filter = "Text files (*.txt)|*.txt|Excel files (*.xls)|*.xls|All files (*.*)|*.*"
            v_dlgSave.RestoreDirectory = True
            Dim v_res As DialogResult = v_dlgSave.ShowDialog(Me)
            If v_res = DialogResult.OK Then
                Dim v_strFileName As String = v_dlgSave.FileName
                Dim v_strData As String
                Dim v_streamWriter As New StreamWriter(v_strFileName, False, System.Text.Encoding.Unicode)

                If (ResultGrid.DataRows.Count > 0) Then
                    'Write file's header
                    v_strData = String.Empty
                    For idx As Integer = 0 To ResultGrid.Columns.Count - 1
                        If ResultGrid.Columns(idx).Visible Then
                            v_strData &= ResultGrid.Columns(idx).Title & vbTab
                        End If
                    Next
                    v_streamWriter.WriteLine(v_strData)

                    'Write data
                    For i As Integer = 0 To ResultGrid.DataRows.Count - 1
                        v_strData = String.Empty

                        For j As Integer = 0 To ResultGrid.DataRows(i).Cells.Count - 1
                            If ResultGrid.Columns(j).Visible Then
                                v_strData &= ResultGrid.DataRows(i).Cells(j).Value & vbTab
                            End If
                        Next
                        'Write data to the file
                        v_streamWriter.WriteLine(v_strData)
                    Next
                Else
                    MsgBox(mv_ResourceManager.GetString("NothingToExport"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    Exit Sub
                End If
                'Close StreamWriter
                v_streamWriter.Close()
                MsgBox(mv_ResourceManager.GetString("ExportSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try

    End Sub


    Private Sub OnClose()
        Me.Dispose()
    End Sub

    Private Sub DoResizeForm()

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
            End If
        Next
        Me.Text = mv_ResourceManager.GetString(Me.Name)
    End Sub

    Private Function getTransBGColor(ByVal pv_intColor As Integer) As System.Drawing.Color
        Dim v_color As New System.Drawing.Color
        Select Case pv_intColor
            Case 0 'Default color
                v_color = System.Drawing.SystemColors.InactiveCaptionText
            Case 1 'Honeydew
                v_color = System.Drawing.Color.Honeydew
            Case 2 'LightGreen
                v_color = System.Drawing.Color.LightGreen
            Case 3 'DarkKhaki
                v_color = System.Drawing.Color.DarkKhaki
            Case 4 'Aquamarine
                v_color = System.Drawing.Color.Aquamarine
            Case 5 'Skyblue
                v_color = System.Drawing.Color.SkyBlue
            Case 6 'Violet
                v_color = System.Drawing.Color.Violet
            Case 7 'Lightpink
                v_color = System.Drawing.Color.LightPink
            Case 8 'LightSalomon
                v_color = System.Drawing.Color.LightSalmon
        End Select
        Return v_color
    End Function

    Private Sub OnView(ByVal sender As Object, ByVal e As System.EventArgs)
        'Chuyển trạng thái core bank

        Dim v_ws
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strSQL As String

        Dim i As Integer
        If Me.ResultGrid.DataRows.Count > 0 Then
            For i = 0 To Me.ResultGrid.DataRows.Count - 1
                If ResultGrid.DataRows(i).Cells("BANKACCTNO").Value <> ResultGrid.DataRows(i).Cells("BANKNAME").Value Then
                    Dim v_strObjMsg As String = BuildXMLObjMsg(Me.BusDate, BranchId, , TellerId, gc_IsNotLocalMsg, _
                                                            gc_MsgTypeObj, OBJNAME_CF_AFMAST, gc_ActionAdhoc, , _
                                                                       ResultGrid.DataRows(i).Cells("CUSTID").Value, "CheckBankAcctAuthorize", , , _
                                                                       ResultGrid.DataRows(i).Cells("CUSTODYCD").Value & "|" & _
                                                                       ResultGrid.DataRows(i).Cells("BANKACCTNO").Value & "|" & _
                                                                       ResultGrid.DataRows(i).Cells("BANKNAME").Value)
                    v_ws = New BDSDeliveryManagement
                    Dim v_strErrorSource, v_strErrorMessage As String
                    Dim v_lngError As Long = v_ws.Message(v_strObjMsg)
                    If v_lngError <> ERR_SYSTEM_OK Then
                        ResultGrid.DataRows(i).Cells("STATUS").Value = "Chưa kích hoạt"
                    Else
                        ResultGrid.DataRows(i).Cells("STATUS").Value = "Đã kích hoạt"
                    End If
                End If

            Next

        End If
    End Sub
#End Region


#Region " Event "
    Private Sub ODSendCurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'Hiá»ƒn thá»‹ thÃ´ng tin lÃªn mÃ n hÃ¬nh
        If (ResultGrid.CurrentRow Is Nothing) Then
            Exit Sub
        End If
        'setGridRowValue(CType(ResultGrid.CurrentRow, Xceed.Grid.DataRow))

    End Sub

    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click

        OnView(sender, e)


    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub


    Private Sub frmODSend_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        GetBankSearch()

    End Sub
    Private Sub cboTradePlace_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'GetBankSearch()
        GetOrder()
    End Sub
    Private Sub cboODKIND_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'GetBankSearch()
        GetOrder()
    End Sub
    Private Sub cboPRICETYPE_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'GetBankSearch()
        GetOrder()
    End Sub
#End Region

    Private Sub cboBranch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'GetOrder()
        GetOrder()
    End Sub
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents txtCustodycd As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnButton As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblCustodycd As DevExpress.XtraEditors.LabelControl

    Private Sub LabelControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCustodycd.Click

    End Sub

    Private Sub btnButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnButton.Click
        GetBankSearch()
    End Sub
    Private Sub txtCustodycd_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCustodycd.KeyUp
        Select Case e.KeyCode
            Case Keys.F5
                Dim frm As New frmSearch(Me.UserLanguage)
                frm.TableName = "CUSTODYCD_CF"
                frm.ModuleCode = "CF"
                frm.KeyFieldType = "C"
                frm.AuthCode = "NNNNYYNNNN" 'Không cho phép thực hiện chức năng nào 
                frm.IsLocalSearch = gc_IsNotLocalMsg
                frm.IsLookup = "Y"
                frm.SearchOnInit = False
                frm.BranchId = "9999"
                frm.TellerId = Me.TellerId
                frm.ShowDialog()
                Me.ActiveControl.Text = Trim(frm.ReturnValue)
        End Select

    End Sub

    Friend WithEvents btnGetAll As DevExpress.XtraEditors.SimpleButton

    Private Sub btnGetAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetAll.Click
        'GetOrder()
        GetBankSearchByEdit()

    End Sub
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl

    Private Sub LabelControl2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelControl2.Click

    End Sub
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl

    Private Sub dtpFrom_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker

    Private Sub dtpIDDATE_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFrom.ValueChanged

    End Sub
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpTo.ValueChanged

    End Sub
End Class

