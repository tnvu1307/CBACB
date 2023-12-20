Imports System.Windows.Forms
Imports Xceed.SmartUI.Controls
Imports CommonLibrary
Imports System.Collections

Public Class frmInquiry
    Inherits System.Windows.Forms.Form

#Region " Declare constant and variables "
    Const c_ResourceManager = "AppCore.frmInquiry-"

    Private mv_strObjectName As String
    Private mv_strModuleCode As String
    Private mv_strLanguage As String
    Private mv_ResourceManager As Resources.ResourceManager
    Private mv_arrObjFields() As CFieldMaster
    Private mv_strTLTXCD As String

    Private mv_strLocalObject As String
    Private mv_strBranchId As String
    Private mv_strTellerId As String
    Private mv_strIpAddress As String
    Private mv_strWsName As String
    Private mv_strXMLObjData As String
    Private mv_xmlDocument As New Xml.XmlDocument

    'Thong tin ngan hang
    Private mv_dblBankTotalBalance As Double
    Private mv_dblBankAvailBalance As Double
    Private mv_dblBankMinBalance As Double

    Const CONTROL_TOP = 10
    Const CONTROL_LEFT = 10
    Const CONTROL_GAP = 2
    Const CONTROL_HEIGHT = 23
    Const LBLCAPTION_WIDTH = 200
    Const ALL_WIDTH = 550
    Const WIDTH_PERCHAR = 20
    Const PREFIXED_MSKDATA = "mskData"
    Const PREFIXED_LBLDESC = "lblDesc"
    Const PREFIXED_LBLCAP = "lblCaption"

    Const POS_FLDNAME = 1
    Const POS_FLDTYPE = POS_FLDNAME + 2
    Const POS_LOOKUP = POS_FLDTYPE + 1
    Const POS_SQLLIST = POS_LOOKUP + 1
#End Region

#Region " Properties "
    Public Property XmlObjData() As String
        Get
            Return mv_strXMLObjData
        End Get
        Set(ByVal Value As String)
            mv_strXMLObjData = Value
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

    Public Property TLTXCD() As String
        Get
            Return mv_strTLTXCD
        End Get
        Set(ByVal Value As String)
            mv_strTLTXCD = Value
        End Set
    End Property

    Public Property BankTotalBalance() As Double
        Get
            Return mv_dblBankTotalBalance
        End Get
        Set(ByVal Value As Double)
            mv_dblBankTotalBalance = Value
        End Set
    End Property
    Public Property BankMinBalance() As Double
        Get
            Return mv_dblBankMinBalance
        End Get
        Set(ByVal Value As Double)
            mv_dblBankMinBalance = Value
        End Set
    End Property
    Public Property BankAvailBalance() As Double
        Get
            Return mv_dblBankAvailBalance
        End Get
        Set(ByVal Value As Double)
            mv_dblBankAvailBalance = Value
        End Set
    End Property
    
#End Region

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal pv_strLanguage As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        mv_strLanguage = pv_strLanguage
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
    Friend WithEvents pnTransDetail As System.Windows.Forms.Panel
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCANCEL As System.Windows.Forms.Button
    Friend WithEvents pnlTitle As System.Windows.Forms.Panel
    Friend WithEvents lblNextTrans As System.Windows.Forms.Label
    Friend WithEvents txtTLTXCD As FlexMaskEditBox
    Protected WithEvents lblCaption As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.pnTransDetail = New System.Windows.Forms.Panel
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCANCEL = New System.Windows.Forms.Button
        Me.pnlTitle = New System.Windows.Forms.Panel
        Me.lblCaption = New System.Windows.Forms.Label
        Me.lblNextTrans = New System.Windows.Forms.Label
        Me.txtTLTXCD = New AppCore.FlexMaskEditBox
        Me.pnlTitle.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnTransDetail
        '
        Me.pnTransDetail.AutoScroll = True
        Me.pnTransDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnTransDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnTransDetail.Location = New System.Drawing.Point(0, 56)
        Me.pnTransDetail.Name = "pnTransDetail"
        Me.pnTransDetail.Size = New System.Drawing.Size(630, 342)
        Me.pnTransDetail.TabIndex = 0
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(456, 406)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(80, 24)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "btnOK"
        '
        'btnCANCEL
        '
        Me.btnCANCEL.Location = New System.Drawing.Point(544, 406)
        Me.btnCANCEL.Name = "btnCANCEL"
        Me.btnCANCEL.Size = New System.Drawing.Size(80, 24)
        Me.btnCANCEL.TabIndex = 4
        Me.btnCANCEL.Text = "btnCANCEL"
        '
        'pnlTitle
        '
        Me.pnlTitle.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlTitle.Controls.Add(Me.lblCaption)
        Me.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTitle.Location = New System.Drawing.Point(0, 0)
        Me.pnlTitle.Name = "pnlTitle"
        Me.pnlTitle.Size = New System.Drawing.Size(630, 50)
        Me.pnlTitle.TabIndex = 7
        '
        'lblCaption
        '
        Me.lblCaption.AutoSize = True
        Me.lblCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaption.Location = New System.Drawing.Point(8, 16)
        Me.lblCaption.Name = "lblCaption"
        Me.lblCaption.Size = New System.Drawing.Size(63, 13)
        Me.lblCaption.TabIndex = 2
        Me.lblCaption.Tag = "lblCaption"
        Me.lblCaption.Text = "lblCaption"
        '
        'lblNextTrans
        '
        Me.lblNextTrans.Location = New System.Drawing.Point(6, 406)
        Me.lblNextTrans.Name = "lblNextTrans"
        Me.lblNextTrans.Size = New System.Drawing.Size(100, 21)
        Me.lblNextTrans.TabIndex = 1
        Me.lblNextTrans.Text = "Next transaction:"
        Me.lblNextTrans.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTLTXCD
        '
        Me.txtTLTXCD.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtTLTXCD.Location = New System.Drawing.Point(112, 406)
        Me.txtTLTXCD.Mask = "9999"
        Me.txtTLTXCD.Name = "txtTLTXCD"
        Me.txtTLTXCD.Size = New System.Drawing.Size(100, 21)
        Me.txtTLTXCD.TabIndex = 2
        '
        'frmInquiry
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(630, 435)
        Me.Controls.Add(Me.txtTLTXCD)
        Me.Controls.Add(Me.lblNextTrans)
        Me.Controls.Add(Me.pnlTitle)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCANCEL)
        Me.Controls.Add(Me.pnTransDetail)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInquiry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmInquiry"
        Me.pnlTitle.ResumeLayout(False)
        Me.pnlTitle.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region " Other methods "
    Protected Overridable Function InitDialog()
        'Khởi tạo kích thước form và load resource
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        LoadResource(Me)

        'Thiết lập các thuộc tính ban đầu cho form
        DoResizeForm()

        If Me.ObjectName.Length > 0 Then
            LoadScreen(Me.ObjectName.ToString)
        Else

        End If
    End Function

    Private Sub LoadObjectFields(ByVal strTLTXCD As String)
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strMNEM, v_strValue, v_strFLDNAME As String
        Dim v_strFieldName, v_strDefName, v_strCaption, v_strFldType, v_strFldMask, v_strFldFormat, _
            v_strLList, v_strLChk, v_strDefVal, v_strAmtExp, v_strValidTag, v_strLookUp, v_strDataType As String
        Dim v_intOdrNum, v_intFldLen As Integer
        Dim v_blnVisible, v_blnEnabled, v_blnMandatory As Boolean

        Try
            'Nạp dữ liệu tra cứu
            mv_xmlDocument.LoadXml(Me.XmlObjData)

            'Lay thong tin so du co ban cua ngan hang
            If ObjectName = "1171" Then
                Dim v_arr() As String = GetBankBalance(GetFieldData("ACCTNO")).Split("|")
                BankTotalBalance = v_arr(1)
                BankMinBalance = v_arr(2)
                BankAvailBalance = v_arr(0)
            End If

            'Create message to inquiry object fields
            Dim v_strClause, v_strObjMsg As String
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
            'Lấy thông tin chung về giao dịch
            v_strClause = "upper(TLTXCD) = '" & strTLTXCD & "'"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLTX, gc_ActionInquiry, , v_strClause)
            v_ws.Message(v_strObjMsg)

            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Count - 1
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = Trim(.InnerText.ToString)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "MNEM"
                                v_strMNEM = v_strValue
                                Exit For
                        End Select
                    End With
                Next
            Next

            'Lấy thông tin chi tiết các trường của giao dịch. 
            'Đối với giao dịch tra cứu sẽ sử dụng giá trị MNEM được định nghĩa trong TLTX để làm OBJNAME xác định các trường trên màn hình
            v_strClause = "upper(OBJNAME) = '" & v_strMNEM & "' ORDER BY ODRNUM"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_FLDMASTER, gc_ActionInquiry, , v_strClause)
            v_ws.Message(v_strObjMsg)

            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            ReDim mv_arrObjFields(v_nodeList.Count)

            For i As Integer = 0 To v_nodeList.Count - 1
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
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
                        End Select
                    End With
                Next

                Dim v_objField As New CFieldMaster
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
                    .DefaultValue = GetFieldData(v_strFieldName)
                    .Visible = v_blnVisible
                    .Enabled = v_blnEnabled
                    .Mandatory = v_blnMandatory
                    .AmtExp = v_strAmtExp
                    .ValidTag = v_strValidTag
                    .LookUp = v_strLookUp
                    .DataType = v_strDataType
                End With
                mv_arrObjFields(i) = v_objField
            Next

            ReDim Preserve mv_arrObjFields(v_nodeList.Count)
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub DisplayScreen()
        Dim v_intIndex, v_intCount, v_intPosition, v_intTop, v_intLeft, v_intWidth As Int16
        Dim v_lblCaption As Label, v_ctlData As Control

        Try
            'Xoá màn hình cũ
            Me.pnTransDetail.Controls.Clear()
            'Tạo màn hình mới
            v_intCount = mv_arrObjFields.GetLength(0)
            If v_intCount > 0 Then
                v_intPosition = 0
                For v_intIndex = 0 To v_intCount - 1 Step 1
                    If Not mv_arrObjFields(v_intIndex) Is Nothing Then
                        v_lblCaption = New Label
                        If Len(mv_arrObjFields(v_intIndex).FieldFormat) > 0 And (mv_arrObjFields(v_intIndex).DataType <> "N") Then
                            v_ctlData = New FlexMaskEditBox
                        Else
                            v_ctlData = New TextBox
                        End If
                        v_lblCaption.Visible = mv_arrObjFields(v_intIndex).Visible
                        v_ctlData.Visible = mv_arrObjFields(v_intIndex).Visible
                        v_intTop = CONTROL_TOP + v_intPosition * (CONTROL_HEIGHT + CONTROL_GAP)
                        v_lblCaption.Top = v_intTop
                        v_lblCaption.Left = CONTROL_LEFT
                        v_lblCaption.Width = LBLCAPTION_WIDTH
                        v_lblCaption.ForeColor = System.Drawing.Color.Blue
                        v_lblCaption.Tag = mv_arrObjFields(v_intIndex).ValidTag
                        v_lblCaption.Text = mv_arrObjFields(v_intIndex).Caption
                        v_lblCaption.Name = PREFIXED_LBLCAP & Trim(mv_arrObjFields(v_intIndex).FieldName)
                        v_ctlData.Top = v_intTop
                        v_intLeft = CONTROL_LEFT + LBLCAPTION_WIDTH + CONTROL_GAP
                        v_ctlData.Left = v_intLeft
                        v_intWidth = mv_arrObjFields(v_intIndex).FieldLength * WIDTH_PERCHAR
                        If ALL_WIDTH < v_intLeft + v_intWidth Then
                            v_intWidth = ALL_WIDTH - v_intLeft
                        End If
                        v_ctlData.Width = v_intWidth
                        v_ctlData.Tag = mv_arrObjFields(v_intIndex).FieldName & mv_arrObjFields(v_intIndex).DataType _
                                        & mv_arrObjFields(v_intIndex).LookUp & mv_arrObjFields(v_intIndex).LookupList
                        v_ctlData.Text = Trim(mv_arrObjFields(v_intIndex).DefaultValue)
                        v_ctlData.BackColor = System.Drawing.Color.LightGray
                        'If Trim(mv_arrObjFields(v_intIndex).DataType) = "N" Then
                        '    v_ctlData.MaskCharInclude = False
                        '    v_ctlData.FieldType = FlexMaskEditBox._FieldType.NUMERIC
                        'ElseIf Trim(mv_arrObjFields(v_intIndex).DataType) = "C" Then
                        '    v_ctlData.MaskCharInclude = False
                        '    v_ctlData.FieldType = FlexMaskEditBox._FieldType.ALFA
                        'Else
                        '    v_ctlData.MaskCharInclude = True
                        '    v_ctlData.FieldType = FlexMaskEditBox._FieldType.DATE_
                        'End If
                        If Len(mv_arrObjFields(v_intIndex).FieldFormat) > 0 And (mv_arrObjFields(v_intIndex).DataType <> "N") Then
                            CType(v_ctlData, FlexMaskEditBox).BorderStyle = BorderStyle.Fixed3D
                            CType(v_ctlData, FlexMaskEditBox).Mask = mv_arrObjFields(v_intIndex).InputMask
                            CType(v_ctlData, FlexMaskEditBox).MaxLength = mv_arrObjFields(v_intIndex).FieldLength
                            CType(v_ctlData, FlexMaskEditBox).ReadOnly = True
                        Else
                            CType(v_ctlData, TextBox).BorderStyle = BorderStyle.Fixed3D
                            CType(v_ctlData, TextBox).MaxLength = mv_arrObjFields(v_intIndex).FieldLength
                            CType(v_ctlData, TextBox).ReadOnly = True
                            If (mv_arrObjFields(v_intIndex).DataType = "N") Then
                                FormatNumericTextbox(CType(v_ctlData, TextBox), mv_arrObjFields(v_intIndex).FieldFormat)
                            End If
                        End If
                        Me.pnTransDetail.Controls.Add(v_lblCaption)
                        Me.pnTransDetail.Controls.Add(v_ctlData)
                        'Tính toán vị trí hiển thị nếu control là visible
                        If mv_arrObjFields(v_intIndex).Visible Then
                            v_intPosition = v_intPosition + 1
                        End If

                    End If
                Next
            End If
            txtTLTXCD.BackColor = System.Drawing.Color.Khaki
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Function GetFieldData(ByVal v_strFieldName As String) As String
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strValue, v_strFLDNAME As String

        Select Case v_strFieldName
            Case "BANKBALANCE"
                Return BankTotalBalance
            Case "BANKAVLBAL"
                Return BankAvailBalance - BankMinBalance
            Case "BANKMINBAL"
                Return BankMinBalance
        End Select
        'Lay thong tin Tu FLEX
        v_nodeList = mv_xmlDocument.SelectNodes("/TransactMessage/ObjData")
        For i As Integer = 0 To v_nodeList.Count - 1
            For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                With v_nodeList.Item(i).ChildNodes(j)
                    v_strValue = Trim(.InnerText.ToString)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    If Trim(v_strFLDNAME) = v_strFieldName Then
                        Return v_strValue
                    End If
                End With
            Next
        Next
        Return vbNullString
    End Function

    Private Sub LoadScreen(ByVal pv_strTLTXCD As String)
        

        'Lấy tham số về giao dịch
        LoadObjectFields(pv_strTLTXCD)

        

        'Hiển thị thông tin giao dịch lên màn hình
        DisplayScreen()
    End Sub

    Private Sub DoResizeForm()

    End Sub

    Private Sub LoadResource(ByRef pv_ctrl As Windows.Forms.Control)
        Dim v_ctrl As Windows.Forms.Control

        For Each v_ctrl In pv_ctrl.Controls
            If TypeOf (v_ctrl) Is Label Then
                CType(v_ctrl, Label).Text = mv_ResourceManager.GetString("frmInquiry." & v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is GroupBox Then
                CType(v_ctrl, GroupBox).Text = mv_ResourceManager.GetString("frmInquiry." & v_ctrl.Name)
                LoadResource(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is Panel Then
                LoadResource(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is Button Then
                CType(v_ctrl, Button).Text = mv_ResourceManager.GetString("frmInquiry." & v_ctrl.Name)
            End If
        Next

        Me.Text = mv_ResourceManager.GetString("frmInquiry")
    End Sub
    Private Sub FormatNumericTextbox(ByVal pv_ctrl As TextBox, ByVal v_strFormat As String)
        Try
            Dim v_intDecimal As String
            Dim v_intIndex As Integer
            If (v_strFormat.Length > 0) Then
                If (v_strFormat.IndexOf(".") <> -1) Then
                    v_intDecimal = Mid(v_strFormat, v_strFormat.IndexOf(".") + 2).Length()
                Else
                    v_intDecimal = 0
                End If
            Else
                v_intDecimal = 0
            End If

            If IsNumeric(pv_ctrl.Text) Then
                pv_ctrl.Text = FormatNumber(pv_ctrl.Text, v_intDecimal)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region " Overridable Function "
    Public Overridable Sub OnSubmit()
        If Len(Me.txtTLTXCD.Text) = 4 Then
            Me.TLTXCD = Me.txtTLTXCD.Text
            Me.Close()
        End If
    End Sub

    Public Overridable Sub OnClose()
        Me.Close()
    End Sub

    Public Overridable Sub mskData_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim v_ctrl As Windows.Forms.Control
        Dim v_strLBLNAME As String
        Try
            'Chọn toàn bộ phần dữ liệu đang có
            If (TypeOf (sender) Is FlexMaskEditBox) Then
                CType(sender, FlexMaskEditBox).SelectionStart = 0
                CType(sender, FlexMaskEditBox).SelectionLength = Len(CType(sender, FlexMaskEditBox).Text)
            End If
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Public Overridable Sub mskData_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Try
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Sub
#End Region

#Region "Form events"
    Private Sub frmInquiry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitDialog()
    End Sub

    Private Sub frmInquiry_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        DoResizeForm()
    End Sub

    Private Sub frmInquiry_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Select Case e.KeyCode
            Case Keys.Escape
                OnClose()
            Case Keys.F5
                If CType(Me.ActiveControl, Control).Name = "txtTLTXCD" Then
                    Dim frm As New frmLookUp(UserLanguage)
                    If Len(ModuleCode) > 0 Then
                        frm.SQLCMD = "SELECT DISTINCT TLTX.TLTXCD VALUECD,TLTX.TLTXCD VALUE, TLTX.TXDESC DISPLAY, TLTX.EN_TXDESC EN_DISPLAY,TLTX.TXDESC DESCRIPTION FROM TLTX, FLDMASTER " _
                            & " WHERE TLTX.CHAIN || TLTX.DIRECT<> 'NN' AND TRIM(TLTX.TLTXCD) = TRIM(FLDMASTER.OBJNAME) AND TRIM(FLDMASTER.MODCODE)='" & ModuleCode & "' ORDER BY TLTXCD"
                    Else
                        frm.SQLCMD = "SELECT DISTINCT TLTX.TLTXCD VALUECD,TLTX.TLTXCD VALUE, TLTX.TXDESC DISPLAY, TLTX.EN_TXDESC EN_DISPLAY,TLTX.TXDESC DESCRIPTION FROM TLTX, FLDMASTER " _
                            & " WHERE TLTX.CHAIN || TLTX.DIRECT<> 'NN' AND TRIM(TLTX.TLTXCD) = TRIM(FLDMASTER.OBJNAME) AND TRIM(FLDMASTER.MODCODE) LIKE '%' ORDER BY TLTXCD"
                    End If

                    frm.ShowDialog()
                    Dim v_intPos As Integer = InStr(frm.RETURNDATA, vbTab)
                    If v_intPos > 0 Then
                        Me.ActiveControl.Text = Mid(frm.RETURNDATA, 1, v_intPos - 1)
                        'Chuyển đến control kế tiếp
                        SendKeys.Send("{Enter}")
                        e.Handled = True
                    End If
                    frm.Dispose()
                End If
            Case Keys.Enter
                If (CType(Me.ActiveControl, Control).Name = "txtTLTXCD") Then
                    'Nếu là trường nhập giao dịch thì chuyển gọi giao dịch đó
                    OnSubmit()
                    e.Handled = True
                End If
        End Select
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        OnSubmit()
    End Sub

    Private Sub btnCANCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCANCEL.Click
        OnClose()
    End Sub
#End Region

End Class
