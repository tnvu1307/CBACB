Imports System.Windows.Forms
Imports Xceed.SmartUI.Controls
Imports CommonLibrary
Imports System.Collections
Imports AppCore
Imports AppCore.modCoreLib


Public Class frmODDetail
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
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents pnBnkAccount As System.Windows.Forms.Panel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnCancel = New System.Windows.Forms.Button
        Me.pnBnkAccount = New System.Windows.Forms.Panel
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(603, 226)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 24)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "btnCancel"
        '
        'pnBnkAccount
        '
        Me.pnBnkAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnBnkAccount.Location = New System.Drawing.Point(12, 12)
        Me.pnBnkAccount.Name = "pnBnkAccount"
        Me.pnBnkAccount.Size = New System.Drawing.Size(671, 208)
        Me.pnBnkAccount.TabIndex = 6
        '
        'frmODDetail
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(695, 259)
        Me.Controls.Add(Me.pnBnkAccount)
        Me.Controls.Add(Me.btnCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmODDetail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmODDetail"
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Declare constant and variables "
    Const c_ResourceManager = "_DIRECT.frmODDetail-"

    Friend WithEvents OrderDetailGrid As GridEx


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
    Private mv_strOrderDate As String
    Private mv_strSettlementDate As String
    Private mv_strVSD As String


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

    Public Property OrderDate() As String
        Get
            Return mv_strOrderDate
        End Get
        Set(ByVal Value As String)
            mv_strOrderDate = Value
        End Set
    End Property

    Public Property SettlementDate() As String
        Get
            Return mv_strSettlementDate
        End Get
        Set(ByVal Value As String)
            mv_strSettlementDate = Value
        End Set
    End Property
    Public Property VSD() As String
        Get
            Return mv_strVSD
        End Get
        Set(ByVal Value As String)
            mv_strVSD = Value
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
    Public Sub GetOrder(Optional ByVal pv_strACCTNO As String = "")
        Dim v_strCmdInquiry, v_strFilter As String
        Dim v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        v_strCmdInquiry = "SELECT od.ORDERID,sb.symbol, od.txdate ORDERDATE, od.execqtty, od.execamt, " & ControlChars.CrLf _
                        & " case when od.feeacr=0 then odt.deffeerate/100*od.execamt else od.feeacr end feeamt," & ControlChars.CrLf _
                        & " (CASE WHEN cf.VAT = 'Y' THEN" & ControlChars.CrLf _
                        & "            ROUND(od.execamt * (SELECT VARVALUE FROM SYSVAR WHERE VARNAME = 'ADVSELLDUTY' AND GRNAME = 'SYSTEM')/100,0)" & ControlChars.CrLf _
                        & "       ELSE 0 END) taxamt, cleardate TRFDATE " & ControlChars.CrLf _
                        & " FROM ODMAST OD, SBSECURITIES sb, odtype odt, afmast af, cfmast cf, stschd sts," & ControlChars.CrLf _
                        & " (SELECT ORDERID,ODM.ISVSD, sum(ODM.EXECQTTY) EXECQTTY, sum(ODM.AAMT) AAMT, sum(ODM.FAMT) FAMT" & ControlChars.CrLf _
                        & "     FROM ODMAPEXT ODM WHERE DELTD <> 'Y' GROUP BY ORDERID,ODM.ISVSD) DF" & ControlChars.CrLf _
                        & " where od.codeid = sb.codeid " & ControlChars.CrLf _
                        & "     and od.orderid= sts.orgorderid and sts.duetype ='RM'" & ControlChars.CrLf _
                        & "     and od.actype = odt.actype " & ControlChars.CrLf _
                        & "     and od.execqtty>0" & ControlChars.CrLf _
                        & "     and od.ORDERID = df.ORDERID (+)" & ControlChars.CrLf _
                        & "     and  od.EXECTYPE IN('NS','SS','MS')" & ControlChars.CrLf _
                        & "     and od.afacctno = af.acctno and af.custid = cf.custid " & ControlChars.CrLf _
                        & "     and od.afacctno ='" & Me.AccountInquiry & "'" & ControlChars.CrLf _
                        & "     and sts.cleardate =to_date('" & Me.SettlementDate & "','DD/MM/RRRR')" & ControlChars.CrLf _
                        & "     and nvl(df.isvsd,'N') = '" & Me.VSD & "'" & ControlChars.CrLf _
                        & "     and od.txdate =to_date('" & Me.OrderDate & "','DD/MM/RRRR')"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_OD_ODMAST, gc_ActionInquiry, v_strCmdInquiry)
        v_ws.Message(v_strObjMsg)
        FillDataGrid(OrderDetailGrid, v_strObjMsg, "")
    End Sub
    Private Sub InitializeGrid()
        'Khởi tạo Grid contacts

        ' Khoi tao OrderDetailGrid
        OrderDetailGrid = New GridEx
        Dim v_cmrExtBankHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrExtBankHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrExtBankHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        OrderDetailGrid.FixedHeaderRows.Add(v_cmrExtBankHeader)


        OrderDetailGrid.Columns.Add(New Xceed.Grid.Column("ORDERID", GetType(System.String)))
        OrderDetailGrid.Columns.Add(New Xceed.Grid.Column("SYMBOL", GetType(System.String)))
        OrderDetailGrid.Columns.Add(New Xceed.Grid.Column("ORDERDATE", GetType(System.String)))
        OrderDetailGrid.Columns.Add(New Xceed.Grid.Column("EXECQTTY", GetType(System.Decimal)))
        OrderDetailGrid.Columns.Add(New Xceed.Grid.Column("EXECAMT", GetType(System.Decimal)))
        OrderDetailGrid.Columns.Add(New Xceed.Grid.Column("FEEAMT", GetType(System.Decimal)))
        OrderDetailGrid.Columns.Add(New Xceed.Grid.Column("TAXAMT", GetType(System.Decimal)))
        OrderDetailGrid.Columns.Add(New Xceed.Grid.Column("TRFDATE", GetType(System.String)))

        OrderDetailGrid.Columns("ORDERID").Title = mv_ResourceManager.GetString("grid.ORDERID")
        OrderDetailGrid.Columns("SYMBOL").Title = mv_ResourceManager.GetString("grid.SYMBOL")
        OrderDetailGrid.Columns("ORDERDATE").Title = mv_ResourceManager.GetString("grid.ORDERDATE")
        OrderDetailGrid.Columns("TRFDATE").Title = mv_ResourceManager.GetString("grid.TRFDATE")
        OrderDetailGrid.Columns("EXECQTTY").Title = mv_ResourceManager.GetString("grid.EXECQTTY")
        OrderDetailGrid.Columns("EXECAMT").Title = mv_ResourceManager.GetString("grid.EXECAMT")
        OrderDetailGrid.Columns("FEEAMT").Title = mv_ResourceManager.GetString("grid.FEEAMT")
        OrderDetailGrid.Columns("TAXAMT").Title = mv_ResourceManager.GetString("grid.TAXAMT")

        OrderDetailGrid.Columns("ORDERID").Width = 100
        OrderDetailGrid.Columns("SYMBOL").Width = 60
        OrderDetailGrid.Columns("ORDERDATE").Width = 70
        OrderDetailGrid.Columns("TRFDATE").Width = 80
        OrderDetailGrid.Columns("EXECQTTY").Width = 80
        OrderDetailGrid.Columns("EXECAMT").Width = 80
        OrderDetailGrid.Columns("FEEAMT").Width = 80
        OrderDetailGrid.Columns("TAXAMT").Width = 80

        OrderDetailGrid.Columns("EXECQTTY").FormatSpecifier = "#,##0"
        OrderDetailGrid.Columns("EXECAMT").FormatSpecifier = "#,##0"
        OrderDetailGrid.Columns("FEEAMT").FormatSpecifier = "#,##0"
        OrderDetailGrid.Columns("TAXAMT").FormatSpecifier = "#,##0"

        pnBnkAccount.Controls.Clear()
        pnBnkAccount.Controls.Add(OrderDetailGrid)
        OrderDetailGrid.Dock = DockStyle.Fill

    End Sub


#End Region

#Region " Other method "
    Protected Overridable Function InitDialog()
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        LoadResource(Me)

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



#End Region


    Private Sub frmTransferInq_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitializeGrid()
        InitDialog()
        GetOrder(Me.AccountInquiry)
        'Add any initialization after the InitializeComponent() call
        mv_xmlDocumentInquiryData = New Xml.XmlDocument
    End Sub
End Class
