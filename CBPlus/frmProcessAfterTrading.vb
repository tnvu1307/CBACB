Imports System.Windows.Forms
Imports Xceed.SmartUI.Controls
Imports CommonLibrary
Imports System.Collections
Imports AppCore
Imports AppCore.modCoreLib


Public Class frmProcessAfterTrading
    Inherits System.Windows.Forms.Form
    Dim v_Order_number As String
    Dim V_OldCuostodycd, v_OldBors, v_Symbol, v_CheckBorS As String

#Region " Declare constant and variables "
    Const c_ResourceManager = "_DIRECT.frmProcessAfterTrading-"
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
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents chkReleaseOrder As System.Windows.Forms.CheckBox
    Friend WithEvents chkFeeCalculate As System.Windows.Forms.CheckBox

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
    Friend WithEvents btnExit As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnOK = New System.Windows.Forms.Button
        Me.chkReleaseOrder = New System.Windows.Forms.CheckBox
        Me.btnExit = New System.Windows.Forms.Button
        Me.chkFeeCalculate = New System.Windows.Forms.CheckBox
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkFeeCalculate)
        Me.GroupBox1.Controls.Add(Me.btnOK)
        Me.GroupBox1.Controls.Add(Me.chkReleaseOrder)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(349, 110)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Xử lý sau giờ giao dịch"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(241, 41)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(97, 28)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Tag = "btnOK"
        Me.btnOK.Text = "Thực hiện"
        '
        'chkReleaseOrder
        '
        Me.chkReleaseOrder.AutoSize = True
        Me.chkReleaseOrder.Location = New System.Drawing.Point(16, 35)
        Me.chkReleaseOrder.Name = "chkReleaseOrder"
        Me.chkReleaseOrder.Size = New System.Drawing.Size(168, 17)
        Me.chkReleaseOrder.TabIndex = 0
        Me.chkReleaseOrder.Text = "Giải tỏa lệnh sau giờ giao dịch"
        Me.chkReleaseOrder.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(290, 137)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(72, 24)
        Me.btnExit.TabIndex = 2
        Me.btnExit.Tag = "btnExit"
        Me.btnExit.Text = "btnExit"
        '
        'chkFeeCalculate
        '
        Me.chkFeeCalculate.AutoSize = True
        Me.chkFeeCalculate.Location = New System.Drawing.Point(16, 69)
        Me.chkFeeCalculate.Name = "chkFeeCalculate"
        Me.chkFeeCalculate.Size = New System.Drawing.Size(174, 17)
        Me.chkFeeCalculate.TabIndex = 3
        Me.chkFeeCalculate.Tag = "chkFeeCalculate"
        Me.chkFeeCalculate.Text = "Tính phí lệnh sau giờ giao dịch"
        Me.chkFeeCalculate.UseVisualStyleBackColor = True
        '
        'frmProcessAfterTrading
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(381, 169)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.GroupBox1)
        Me.KeyPreview = True
        Me.Name = "frmProcessAfterTrading"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Process after Trading Session"
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
        Dim v_strFLDNAME, v_strValue As String
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strCmdSQL As String, v_strObjMsg As String
        Dim v_strStatus As String

        v_strCmdSQL = "SELECT fn_checkAfterTradingSession STATUS from dual;"
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
                        Case "STATUS"
                            v_strStatus = v_strValue.Trim()
                    End Select
                End With
            Next
        Next
        If v_strStatus = "0" Then
            Me.btnOK.Enabled = True
        Else
            Me.btnOK.Enabled = False
        End If
    End Function

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
            Dim v_strStatus As String


            If MsgBox(mv_ResourceManager.GetString("MSG_CONFIRM"), MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Me.Text) = MsgBoxResult.Yes Then
                If Me.chkReleaseOrder.Checked Then
                    v_strObjMsg = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "ProcessClearOrder", , , "GetDate")
                    v_lngErrorCode = v_ws.Message(v_strObjMsg)
                    v_xmlDocument.LoadXml(v_strObjMsg)
                    v_strStatus = v_lngErrorCode

                    If v_strStatus = "0" Then
                        MsgBox(mv_ResourceManager.GetString("ERR_STATUS_0"))
                        Exit Sub
                    ElseIf v_strStatus = "-2" Then
                        MsgBox(mv_ResourceManager.GetString("ERR_STATUS_1"))
                        Exit Sub
                    ElseIf v_strStatus = "-3" Then
                        MsgBox(mv_ResourceManager.GetString("ERR_STATUS_2"))
                        Exit Sub
                    ElseIf v_strStatus = "-3" Then
                        MsgBox(mv_ResourceManager.GetString("ERR_STATUS_3"))
                        Exit Sub
                    Else
                        MsgBox(mv_ResourceManager.GetString("ERR_SYS"))
                        Exit Sub
                    End If
                End If
            End If
            If Me.chkFeeCalculate.Checked Then
                v_strObjMsg = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "ProcessFeeCalculate", , , "GetDate")
                v_lngErrorCode = v_ws.Message(v_strObjMsg)
                v_xmlDocument.LoadXml(v_strObjMsg)
                v_strStatus = v_lngErrorCode

                If v_strStatus = "0" Then
                    MsgBox(mv_ResourceManager.GetString("ERR_FEE_STATUS0"))
                    Exit Sub
                ElseIf v_strStatus = "-2" Then
                    MsgBox(mv_ResourceManager.GetString("ERR_FEE_STATUS1"))
                    Exit Sub
                ElseIf v_strStatus = "-3" Then
                    MsgBox(mv_ResourceManager.GetString("ERR_STATUS_2"))
                    Exit Sub
                ElseIf v_strStatus = "-3" Then
                    MsgBox(mv_ResourceManager.GetString("ERR_STATUS_2"))
                    Exit Sub
                Else
                    MsgBox(mv_ResourceManager.GetString("ERR_SYS"))
                    Exit Sub
                End If
            End If
            OnClose()
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub


    Private Sub frmChangeOrderCustody_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Select Case e.KeyCode
            Case Keys.Escape
                OnClose()
        End Select
    End Sub


    Private Sub chkReleaseOrder_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkReleaseOrder.CheckedChanged
        If Me.chkReleaseOrder.Checked Then
            Me.chkFeeCalculate.Checked = False
        End If
    End Sub

    Private Sub chkFeeCalculate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFeeCalculate.CheckedChanged
        If Me.chkFeeCalculate.Checked Then
            Me.chkReleaseOrder.Checked = False
        End If
    End Sub
End Class
