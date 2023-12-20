Imports System.Windows.Forms
Imports Xceed.SmartUI.Controls
Imports CommonLibrary
Imports System.Collections
Imports AppCore
Imports AppCore.modCoreLib


Public Class frmChangeOrderCustody
    Inherits System.Windows.Forms.Form
    Dim v_Order_number As String
    Dim V_OldCuostodycd, v_OldBors, v_Symbol, v_CheckBorS As String

#Region " Declare constant and variables "
    Const c_ResourceManager = "_DIRECT.frmChangeOrderCustody-"
    Public PTMsgGrid, PTCancelMsgGrid, PTDealGrid, PTAdvGrid As GridEx
    Dim mv_strEXECTYPE, mv_strEXECTYPE_VAL, mv_strCUSTODYCD, mv_strSYMBOL As String
    Dim mv_strOODSTATUS, mv_strPRICE, mv_strQTTY, mv_strORDERID, mv_strORDERQTTY, mv_strDESC_PRICETYPE, mv_strQUOTEPRICE, mv_strLIMITPRICE As String
    Dim mv_strCURRPRICE, mv_strMATCHTYPE, mv_strNORK, mv_strCODEID, mv_strSECURERATIOTMIN, mv_strSECURERATIOMAX, mv_strTYP_BRATIO, mv_strAF_BRATIO As String
    Dim mv_strCIACCTNO, mv_strSEACCTNO, mv_strAFACCTNO, mv_strPARVALUE, mv_strTradePlace, mv_strPriceType As String

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

    Private Const CONTROL_PNL_CONTRACT_TOP = 200
    Private Const CONTROL_BUTTON_TOP = 400
    Private Const FRM_DEFAULT_HEIGHT = 260
    Private Const FRM_EXTEND_HEIGHT = 460
    Friend WithEvents cboCustodyCD As System.Windows.Forms.TextBox

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
#End Region

#Region "Private method"
    Private Sub OnClose()
        Me.Dispose()
    End Sub
#End Region
#Region " Windows Form Designer generated code "

    Public Sub New(ByVal pv_strLanguage As String)
        MyBase.New()
        InitializeComponent()
        mv_strLanguage = pv_strLanguage
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        'InitializeGrid()
        'This call is required by the Windows Form Designer.
        'Add any initialization after the InitializeComponent() call
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblOrderID As System.Windows.Forms.Label
    Friend WithEvents lblNewCustodyCD As System.Windows.Forms.Label
    Friend WithEvents lblInfoOldOrder As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents cboOrderID As AppCore.ComboBoxEx
    Friend WithEvents cboCustodyCD123 As AppCore.ComboBoxEx
    Friend WithEvents lblName As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmChangeOrderCustody))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cboCustodyCD = New System.Windows.Forms.TextBox
        Me.lblName = New System.Windows.Forms.Label
        Me.cboCustodyCD123 = New AppCore.ComboBoxEx
        Me.lblInfoOldOrder = New System.Windows.Forms.Label
        Me.lblNewCustodyCD = New System.Windows.Forms.Label
        Me.lblOrderID = New System.Windows.Forms.Label
        Me.cboOrderID = New AppCore.ComboBoxEx
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboCustodyCD)
        Me.GroupBox1.Controls.Add(Me.lblName)
        Me.GroupBox1.Controls.Add(Me.cboCustodyCD123)
        Me.GroupBox1.Controls.Add(Me.lblInfoOldOrder)
        Me.GroupBox1.Controls.Add(Me.lblNewCustodyCD)
        Me.GroupBox1.Controls.Add(Me.lblOrderID)
        Me.GroupBox1.Controls.Add(Me.cboOrderID)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(624, 120)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Create change order custodycd message"
        '
        'cboCustodyCD
        '
        Me.cboCustodyCD.Location = New System.Drawing.Point(104, 69)
        Me.cboCustodyCD.Name = "cboCustodyCD"
        Me.cboCustodyCD.Size = New System.Drawing.Size(136, 20)
        Me.cboCustodyCD.TabIndex = 21
        Me.cboCustodyCD.Tag = "cboCustodyCD"
        Me.cboCustodyCD.Text = "cboCustodyCD"
        '
        'lblName
        '
        Me.lblName.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.ForeColor = System.Drawing.Color.Green
        Me.lblName.Location = New System.Drawing.Point(256, 72)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(352, 23)
        Me.lblName.TabIndex = 7
        '
        'cboCustodyCD123
        '
        Me.cboCustodyCD123.DisplayMember = "DISPLAY"
        Me.cboCustodyCD123.Location = New System.Drawing.Point(358, 69)
        Me.cboCustodyCD123.Name = "cboCustodyCD123"
        Me.cboCustodyCD123.Size = New System.Drawing.Size(136, 21)
        Me.cboCustodyCD123.TabIndex = 6
        Me.cboCustodyCD123.Tag = "cboCustodyCD123"
        Me.cboCustodyCD123.ValueMember = "VALUE"
        Me.cboCustodyCD123.Visible = False
        '
        'lblInfoOldOrder
        '
        Me.lblInfoOldOrder.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfoOldOrder.ForeColor = System.Drawing.Color.Green
        Me.lblInfoOldOrder.Location = New System.Drawing.Point(256, 32)
        Me.lblInfoOldOrder.Name = "lblInfoOldOrder"
        Me.lblInfoOldOrder.Size = New System.Drawing.Size(352, 24)
        Me.lblInfoOldOrder.TabIndex = 4
        Me.lblInfoOldOrder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNewCustodyCD
        '
        Me.lblNewCustodyCD.Location = New System.Drawing.Point(8, 72)
        Me.lblNewCustodyCD.Name = "lblNewCustodyCD"
        Me.lblNewCustodyCD.Size = New System.Drawing.Size(96, 24)
        Me.lblNewCustodyCD.TabIndex = 2
        Me.lblNewCustodyCD.Text = "lblNewCustodyCD"
        '
        'lblOrderID
        '
        Me.lblOrderID.Location = New System.Drawing.Point(8, 32)
        Me.lblOrderID.Name = "lblOrderID"
        Me.lblOrderID.Size = New System.Drawing.Size(72, 24)
        Me.lblOrderID.TabIndex = 1
        Me.lblOrderID.Text = "lblOrderID"
        '
        'cboOrderID
        '
        Me.cboOrderID.DisplayMember = "DISPLAY"
        Me.cboOrderID.Location = New System.Drawing.Point(104, 32)
        Me.cboOrderID.Name = "cboOrderID"
        Me.cboOrderID.Size = New System.Drawing.Size(136, 21)
        Me.cboOrderID.TabIndex = 0
        Me.cboOrderID.Tag = "cboOrderID"
        Me.cboOrderID.ValueMember = "VALUE"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(472, 136)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(80, 24)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Tag = "btnOK"
        Me.btnOK.Text = "btnOK"
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(568, 136)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(72, 24)
        Me.btnExit.TabIndex = 2
        Me.btnExit.Tag = "btnExit"
        Me.btnExit.Text = "btnExit"
        '
        'frmChangeOrderCustody
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(656, 173)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.GroupBox1)
        Me.KeyPreview = True
        Me.Name = "frmChangeOrderCustody"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Change Order Custody"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private Sub LoadResource(ByRef pv_ctrl As Windows.Forms.Control)
        Dim v_ctrl As Windows.Forms.Control

        For Each v_ctrl In pv_ctrl.Controls
            If TypeOf (v_ctrl) Is Label Then
                CType(v_ctrl, Label).Text = mv_ResourceManager.GetString(v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is TextBox Then
                CType(v_ctrl, TextBox).Text = ""
            ElseIf TypeOf (v_ctrl) Is CheckBox Then
                CType(v_ctrl, CheckBox).Text = mv_ResourceManager.GetString(v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is GroupBox Then
                CType(v_ctrl, GroupBox).Text = mv_ResourceManager.GetString(v_ctrl.Name)
                LoadResource(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is Button Then
                CType(v_ctrl, Button).Text = mv_ResourceManager.GetString(v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is Panel Then
                LoadResource(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is TabControl Then
                LoadResource(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is TabPage Then
                LoadResource(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is GroupBox Then
                LoadResource(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is DateTimePicker Then
                CType(v_ctrl, DateTimePicker).Value = CDate(Me.BusDate)
            End If
        Next
        Me.Text = mv_ResourceManager.GetString(Me.Name)
    End Sub

    Protected Overridable Function InitDialog()
        'Khởi tạo kích thước form và load resource
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        LoadResource(Me)

        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strCmdSQL As String, v_strObjMsg As String

        'v_strCmdSQL = "SELECT custodycd VALUE, CUSTODYCD DISPLAY, CUSTODYCD EN_DISPLAY FROM cfmast WHERE custodycd IS NOT NULL ORDER BY value "
        'v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_OD_ODMAST, gc_ActionInquiry, v_strCmdSQL)
        'v_ws.Message(v_strObjMsg)
        'FillComboEx(v_strObjMsg, Me.cboCustodyCD123, "", Me.UserLanguage)


        v_strCmdSQL = "SELECT '0' VALUE,' ----------------------' DISPLAY, ' ----------------------' EN_DISPLAY FROM dual UNION all " _
            & " SELECT od.orderid VALUE, od.orderid DISPLAY, od.orderid EN_DISPLAY  " _
            & " FROM odmast od, ordermap om , ordersys os, ood o " _
            & " WHERE od.orderid =om.orgorderid and od.remainqtty>0 and NVL(od.hosesession,'X')<>'A' and od.EXECQTTY=0 " _
            & "  and od.via<>'O' and os.sysname='CONTROLCODE' and os.sysvalue<>'P' and od.matchtype<>'P' " _
            & "  and od.orderid=o.orgorderid and o.oodstatus='S' "
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_OD_ODMAST, gc_ActionInquiry, v_strCmdSQL)
        v_ws.Message(v_strObjMsg)
        FillComboEx(v_strObjMsg, cboOrderID, "", Me.UserLanguage)

        If Me.cboOrderID.Items.Count > 0 Then cboOrderID.SelectedIndex = 0
        'If Me.cboCustodyCD123.Items.Count > 0 Then cboCustodyCD123.SelectedIndex = 0
    End Function

    Sub Prc_Dislay_info_Order()
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strCmdSQL As String, v_strObjMsg As String
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strFLDNAME, v_strValue As String
        Dim v_arrValue(), v_arrDisplay() As String
        Dim v_int As Integer
        Dim v_Info As String

        v_strCmdSQL = "SELECT od.orderid ||' | '|| o.custodycd ||' | '|| od.exectype||' | '||o.symbol " _
                    & " ||' | '||o.qtty ||' | '|| o.price    INFO, om.ctci_order ORDER_NUMBER ," _
                    & " o.custodycd CUSTODYCD, O.BORS BORS, o.symbol SYMBOL " _
                    & " FROM ood o, odmast od, ordermap om WHERE(od.orderid = om.orgorderid) " _
                    & "  AND o.orgorderid =od.orderid And o.orgorderid = '" & Me.cboOrderID.Text & "'"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_OD_ODMAST, gc_ActionInquiry, v_strCmdSQL)
        v_ws.Message(v_strObjMsg)

        v_xmlDocument.LoadXml(v_strObjMsg)
        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

        For i As Integer = 0 To v_nodeList.Count - 1
            For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                With v_nodeList.Item(i).ChildNodes(j)
                    v_strValue = .InnerText.ToString
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    Select Case Trim(v_strFLDNAME)
                        Case "INFO"
                            v_Info = v_strValue.Trim()
                        Case "ORDER_NUMBER"
                            v_Order_number = v_strValue.Trim()
                        Case "CUSTODYCD"
                            V_OldCuostodycd = v_strValue.Trim()
                        Case "BORS"
                            v_OldBors = v_strValue.Trim()
                        Case "SYMBOL"
                            v_Symbol = v_strValue.Trim()
                    End Select
                End With
            Next
        Next
        If v_OldBors = "B" Then
            v_CheckBorS = "S"
        Else
            v_CheckBorS = "B"
        End If
        Me.lblInfoOldOrder.Text = v_Info


    End Sub

    Sub Prc_Dislay_info_Name()
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strCmdSQL As String, v_strObjMsg As String
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strFLDNAME, v_strValue As String
        Dim v_arrValue(), v_arrDisplay() As String
        Dim v_int As Integer
        Dim v_Info As String
        v_strCmdSQL = "SELECT FULLNAME FULLNAME FROM cfmast WHERE CUSTODYCD =  '" & Me.cboCustodyCD.Text & "'"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_OD_ODMAST, gc_ActionInquiry, v_strCmdSQL)
        v_ws.Message(v_strObjMsg)

        v_xmlDocument.LoadXml(v_strObjMsg)
        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

        For i As Integer = 0 To v_nodeList.Count - 1
            For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                With v_nodeList.Item(i).ChildNodes(j)
                    v_strValue = .InnerText.ToString
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    Select Case Trim(v_strFLDNAME)
                        Case "FULLNAME"
                            v_Info = v_strValue.Trim()
                    End Select
                End With
            Next
        Next
        Me.lblName.Text = v_Info
    End Sub
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        OnClose()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_strCmdSQL As String, v_strObjMsg As String
            Dim v_strClause As String
            Dim v_lngErrorCode As Long
            Dim v_strErrorSource, v_strErrorMessage As String
            Dim v_Custodycd As String
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strValue As String = "", v_strFLDNAME As String = ""

            v_Custodycd = Replace(Me.cboCustodyCD.Text.Trim, ".", "")
            If MsgBox(mv_ResourceManager.GetString("MSG_CONFIRM"), MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Me.Text) = MsgBoxResult.Yes Then

                'Check mua ban cung phien


                If v_Custodycd.Substring(3, 1) <> V_OldCuostodycd.Substring(3, 1) Then
                    MsgBox(mv_ResourceManager.GetString("MSG_ERR_CANT_CHANGE"))
                    Exit Sub
                Else
                    v_strCmdSQL = "SELECT custodycd FROM ood WHERE oodstatus='S' and deltd<>'Y' and CUSTODYCD =  '" & Me.cboCustodyCD.Text & "' and symbol = '" & v_Symbol & "' and bors= '" & v_CheckBorS & "'"
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_OD_ODMAST, gc_ActionInquiry, v_strCmdSQL)
                    v_ws.Message(v_strObjMsg)
                    v_xmlDocument.LoadXml(v_strObjMsg)
                    v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                    If v_nodeList.Count > 0 Then
                        MsgBox(mv_ResourceManager.GetString("ERR_TRADE_BUYSELL"))
                        Exit Sub
                    End If
                End If
                Dim v_strExecType As String = ""
                Dim v_dblOrderQtty As Double = 0, v_dblExecQtty As Double = 0, v_dblPrice As Double = 0
                'Check neu lanh mua thi phai du tien
                v_strCmdSQL = "SELECT * FROM ODMAST WHERE ORDERID='" & cboOrderID.SelectedValue.ToString().Trim().Replace(".", "") & "' AND MATCHTYPE='N'"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_OD_ODMAST, gc_ActionInquiry, v_strCmdSQL)
                v_ws.Message(v_strObjMsg)
                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

                For i As Integer = 0 To v_nodeList.Count - 1
                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            v_strValue = .InnerText.ToString
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME)
                                Case "EXECTYPE"
                                    v_strExecType = v_strValue.Trim()
                                Case "ORDERQTTY"
                                    v_dblOrderQtty = Convert.ToDouble(v_strValue)
                                Case "EXECQTTY"
                                    v_dblExecQtty = Convert.ToDouble(v_strValue)
                                Case "QUOTEPRICE"
                                    v_dblPrice = Convert.ToDouble(v_strValue)
                            End Select
                        End With
                    Next
                Next
                If v_dblExecQtty > 0 Then
                    Cursor.Current = Cursors.Default
                    MsgBox(mv_ResourceManager.GetString("ERR_MATCHED_ORDER"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                    Exit Sub
                End If

                If v_strExecType = "NB" Then
                    'Check neu lanh mua thi phai du tien
                    v_strCmdSQL = "SELECT PURCHASINGPOWER FROM OL_ACCOUNT_CI CI,AFMAST AF,CFMAST CF WHERE CI.AFACCTNO=AF.ACCTNO AND AF.CUSTID=CF.CUSTID AND CF.CUSTODYCD='" & v_Custodycd & "' AND CI.PURCHASINGPOWER>=" & Convert.ToString(v_dblPrice * v_dblOrderQtty)
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_OD_ODMAST, gc_ActionInquiry, v_strCmdSQL)
                    v_ws.Message(v_strObjMsg)
                    v_xmlDocument.LoadXml(v_strObjMsg)
                    v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                    If v_nodeList.Count = 0 Then
                        MsgBox(mv_ResourceManager.GetString("ERR_NENOUGHT_MONEY"))
                        Exit Sub
                    End If
                Else
                    'Lenh ban thi phai du ck
                    v_strCmdSQL = "SELECT TRADE_QTTY FROM V_OL_ACCOUNT_SE WHERE CUSTODYCD='" & v_Custodycd & "' AND SYMBOL='" & v_Symbol & "' AND TRADE_QTTY>=" & v_dblOrderQtty.ToString()
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_OD_ODMAST, gc_ActionInquiry, v_strCmdSQL)
                    v_ws.Message(v_strObjMsg)
                    v_xmlDocument.LoadXml(v_strObjMsg)
                    v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                    If v_nodeList.Count = 0 Then
                        MsgBox(mv_ResourceManager.GetString("ERR_NENOUGHT_STOCK"))
                        Exit Sub
                    End If
                End If

                v_strCmdSQL = " INSERT INTO ORDER_CHANGE(ID,DATE_CHANGE,ORDER_NUMBER,ORGORDERID,CUSTODYCD_CHANGE,STATUS,TIME_SEND)" _
                & " values(SEQ_ORDER_CHANGE.NEXTVAL,SYSDATE,'" & v_Order_number & "','" & Me.cboOrderID.Text & "','" & v_Custodycd & "','N','')"

                'v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_OD_ODMAST, gc_ActionInquiry, v_strCmdSQL)
                'v_ws.Message(v_strObjMsg)
                'v_strClause = v_Order_number & "|" & Me.cboOrderID.Text & "|" & Me.cboCustodyCD.Text.Trim
                v_strClause = v_strCmdSQL
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, v_strCmdSQL, v_strClause, "CreateOrderCustodyChange", , , , IpAddress)
                v_lngErrorCode = v_ws.Message(v_strObjMsg)

                'KIEM TRA THONG TIN LAY LOI TRA VE
                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                If v_lngErrorCode <> 0 Then
                    'Update mouse pointer
                    Cursor.Current = Cursors.Default
                    MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                    Exit Sub
                End If



            End If
            MsgBox(mv_ResourceManager.GetString("MSG_SS"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            OnClose()
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub cboOrderID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOrderID.SelectedIndexChanged
        Prc_Dislay_info_Order()
    End Sub

    'Private Sub cboCustodyCD_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustodyCD123.SelectedIndexChanged
    '    Prc_Dislay_info_Name()
    'End Sub


    Private Sub frmChangeOrderCustody_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Select Case e.KeyCode
            Case Keys.Escape
                OnClose()
        End Select
    End Sub

    Private Sub cboCustodyCD_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustodyCD.Leave
        cboCustodyCD.Text = UCase(cboCustodyCD.Text)
        Prc_Dislay_info_Name()
    End Sub
End Class
