Imports System.Windows.Forms
Imports Xceed.SmartUI.Controls
Imports CommonLibrary
Imports System.Collections
Imports AppCore
Imports AppCore.modCoreLib


Public Class frmHoldUnhold
    Inherits System.Windows.Forms.Form
    Dim v_Order_number As String
    Dim V_OldCuostodycd, v_OldBors, v_Symbol, v_CheckBorS As String

#Region " Declare constant and variables "
    Const c_ResourceManager = "_DIRECT.frmHoldUnhold-"
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkFeeCalculate = New System.Windows.Forms.CheckBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.chkReleaseOrder = New System.Windows.Forms.CheckBox()
        Me.btnExit = New System.Windows.Forms.Button()
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
        Me.GroupBox1.Tag = "GroupBox1"
        '
        'chkFeeCalculate
        '
        Me.chkFeeCalculate.AutoSize = True
        Me.chkFeeCalculate.Location = New System.Drawing.Point(16, 69)
        Me.chkFeeCalculate.Name = "chkFeeCalculate"
        Me.chkFeeCalculate.Size = New System.Drawing.Size(15, 14)
        Me.chkFeeCalculate.TabIndex = 3
        Me.chkFeeCalculate.Tag = "chkFeeCalculate"
        Me.chkFeeCalculate.UseVisualStyleBackColor = True
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
        Me.chkReleaseOrder.Size = New System.Drawing.Size(15, 14)
        Me.chkReleaseOrder.TabIndex = 0
        Me.chkReleaseOrder.Tag = "chkReleaseOrder"
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
        'frmHoldUnhold
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(381, 169)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.GroupBox1)
        Me.KeyPreview = True
        Me.Name = "frmHoldUnhold"
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
        'If v_strStatus = "0" Then
        '    Me.btnOK.Enabled = True
        'Else
        '    Me.btnOK.Enabled = False
        'End If
    End Function

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        OnClose()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_strCmdSQL As String, v_strObjMsg As String
            Dim v_strClause, v_strDATATYPE, v_strFLDVALUE As String
            Dim v_lngErrorCode As Long
            Dim v_strErrorSource, v_strErrorMessage As String
            Dim v_Custodycd As String
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strValue As String = "", v_strFLDNAME As String = ""
            Dim v_strStatus As String
            Dim v_dataElement As Xml.XmlElement
            Dim v_entryNode As Xml.XmlNode
            Dim v_attrDATATYPE, v_attrFLDNAME As Xml.XmlAttribute


            If MsgBox(mv_ResourceManager.GetString("MSG_CONFIRM"), MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Me.Text) = MsgBoxResult.Yes Then
                'Unhold/1
                If Me.chkReleaseOrder.Checked Then
                    
                    'v_strCmdSQL = "begin HoldUnhold(1); end;"

                    'v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeRpt, , gc_ActionInquiry, v_strCmdSQL)
                    'v_lngErrorCode = v_ws.Message(v_strObjMsg)

                    LoadScreen("6695")
                    v_strObjMsg = BuildXMLTxMsg(gc_MsgTypeTrans, gc_IsLocalMsg, "6695", Me.BranchId, Me.TellerId, Me.IpAddress, Me.WsName, , , , , , , , , , , , , , , , , Me.BusDate)

                    v_xmlDocument.LoadXml(v_strObjMsg)
                    v_dataElement = v_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "fields", "")
                    If mv_arrObjFields.GetLength(0) > 0 Then
                        For v_intIndex = 0 To mv_arrObjFields.GetLength(0) - 1 Step 1
                            If Not mv_arrObjFields(v_intIndex) Is Nothing Then
                                v_strFLDNAME = mv_arrObjFields(v_intIndex).FieldName
                                v_strDATATYPE = mv_arrObjFields(v_intIndex).DataType
                                Select Case Trim(v_strFLDNAME)
                                    Case "22"
                                        v_strFLDVALUE = "1"
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


                                v_xmlDocument.DocumentElement.AppendChild(v_dataElement)
                            End If
                        Next
                    End If
                    v_strObjMsg = v_xmlDocument.InnerXml
                    v_lngErrorCode = v_ws.Message(v_strObjMsg)

                    If v_lngErrorCode <> ERR_SYSTEM_OK Then
                        'Thông báo lỗi
                        GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                        Cursor.Current = Cursors.Default
                        If v_lngErrorCode <> ERR_SA_CHECKER1_OVR And v_lngErrorCode <> ERR_SA_CHECKER2_OVR Then
                            MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, mv_ResourceManager.GetString("GroupBox1"))
                            Exit Sub
                        End If
                    End If

                    
                End If

                'Hold/0
                If Me.chkFeeCalculate.Checked Then
                    LoadScreen("6695")
                    v_strObjMsg = BuildXMLTxMsg(gc_MsgTypeTrans, gc_IsLocalMsg, "6695", Me.BranchId, Me.TellerId, Me.IpAddress, Me.WsName, , , , , , , , , , , , , , , , , Me.BusDate)

                    v_xmlDocument.LoadXml(v_strObjMsg)
                    v_dataElement = v_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "fields", "")
                    If mv_arrObjFields.GetLength(0) > 0 Then
                        For v_intIndex = 0 To mv_arrObjFields.GetLength(0) - 1 Step 1
                            If Not mv_arrObjFields(v_intIndex) Is Nothing Then
                                v_strFLDNAME = mv_arrObjFields(v_intIndex).FieldName
                                v_strDATATYPE = mv_arrObjFields(v_intIndex).DataType
                                Select Case Trim(v_strFLDNAME)
                                    Case "22"
                                        v_strFLDVALUE = "0"
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


                                v_xmlDocument.DocumentElement.AppendChild(v_dataElement)
                            End If
                        Next
                    End If
                    v_strObjMsg = v_xmlDocument.InnerXml
                    'v_strCmdSQL = "begin HoldUnhold(0); end;"

                    'v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeRpt, , gc_ActionInquiry, v_strCmdSQL)
                    v_lngErrorCode = v_ws.Message(v_strObjMsg)


                    If v_lngErrorCode <> ERR_SYSTEM_OK Then
                        'Thông báo lỗi
                        GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                        Cursor.Current = Cursors.Default
                        If v_lngErrorCode <> ERR_SA_CHECKER1_OVR And v_lngErrorCode <> ERR_SA_CHECKER2_OVR Then
                            MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, mv_ResourceManager.GetString("GroupBox1"))
                            Exit Sub
                        End If
                    End If


                End If
                MsgBox(mv_ResourceManager.GetString("TRANSSUCCESS"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, mv_ResourceManager.GetString("GroupBox1"))
            End If
            Me.Close()
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
            v_strClause = "upper(TLTXCD) = '" & strTLTXCD & "'"
            v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLTX, gc_ActionInquiry, , v_strClause)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            For i = 0 To v_nodeList.Count - 1
                For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "TXDESC"
                                'Me.Text = Trim(v_strValue)
                                Me.Text = mv_ResourceManager.GetString(Me.Name)
                        End Select
                    End With
                Next
            Next

            'Lấy thông tin chi tiết các trư?ng c�ủa giao dịch
            v_strClause = "upper(OBJNAME) = '" & strTLTXCD & "' ORDER BY ODRNUM"
            v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_FLDMASTER, gc_ActionInquiry, , v_strClause)
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
                                v_strCaption = Trim(v_strValue)
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
                        'v_strDefVal = Me.mv_strBusdate
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
            v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_FLDVAL, gc_ActionInquiry, v_strClause)
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
End Class
