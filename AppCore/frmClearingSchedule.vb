Imports System.Windows.Forms
Imports Xceed.SmartUI.Controls
Imports CommonLibrary
Imports System.Collections
Public Class frmClearingSchedule
    Inherits System.Windows.Forms.Form

#Region " Declare constant and variables "
    Const c_ResourceManager = "AppCore.frmClearingSchedule-"

    Private mv_strObjectName As String
    Private mv_strModuleCode As String
    Private mv_strLanguage As String
    Private mv_ResourceManager As Resources.ResourceManager
    Private mv_arrObjFields() As CFieldMaster
    Private mv_strReturnValue As String
    Private mv_strRefValue As String

    Private mv_strLocalObject As String
    Private mv_strBranchId As String
    Private mv_strTellerId As String
    Private mv_strIpAddress As String
    Private mv_strWsName As String
    Private mv_strXMLObjData As String
    Private mv_xmlDocument As New Xml.XmlDocument
    Private v_dtgHist As GridEx

    Const CONTROL_TOP = 10
    Const CONTROL_LEFT = 10
    Const CONTROL_GAP = 2
    Const CONTROL_HEIGHT = 23
    Const LBLCAPTION_WIDTH = 120
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

    Public Property ReturnValue() As String
        Get
            Return mv_strReturnValue
        End Get
        Set(ByVal Value As String)
            mv_strReturnValue = Value
        End Set
    End Property

    Public Property RefValue() As String
        Get
            Return mv_strRefValue
        End Get
        Set(ByVal Value As String)
            mv_strRefValue = Value
        End Set
    End Property

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
    Friend WithEvents pnlTitle As System.Windows.Forms.Panel
    Friend WithEvents btnCANCEL As System.Windows.Forms.Button
    Friend WithEvents pnTransDetail As System.Windows.Forms.Panel
    Friend WithEvents btnSETTLE As System.Windows.Forms.Button

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.pnlTitle = New System.Windows.Forms.Panel
        Me.btnCANCEL = New System.Windows.Forms.Button
        Me.pnTransDetail = New System.Windows.Forms.Panel
        Me.btnSETTLE = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'pnlTitle
        '
        Me.pnlTitle.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTitle.Location = New System.Drawing.Point(0, 0)
        Me.pnlTitle.Name = "pnlTitle"
        Me.pnlTitle.Size = New System.Drawing.Size(592, 50)
        Me.pnlTitle.TabIndex = 11
        '
        'btnCANCEL
        '
        Me.btnCANCEL.Location = New System.Drawing.Point(504, 344)
        Me.btnCANCEL.Name = "btnCANCEL"
        Me.btnCANCEL.Size = New System.Drawing.Size(80, 24)
        Me.btnCANCEL.TabIndex = 9
        Me.btnCANCEL.Text = "btnCANCEL"
        '
        'pnTransDetail
        '
        Me.pnTransDetail.AutoScroll = True
        Me.pnTransDetail.Location = New System.Drawing.Point(0, 48)
        Me.pnTransDetail.Name = "pnTransDetail"
        Me.pnTransDetail.Size = New System.Drawing.Size(592, 288)
        Me.pnTransDetail.TabIndex = 8
        '
        'btnSETTLE
        '
        Me.btnSETTLE.Location = New System.Drawing.Point(424, 344)
        Me.btnSETTLE.Name = "btnSETTLE"
        Me.btnSETTLE.TabIndex = 12
        Me.btnSETTLE.Text = "btnSETTLE"
        '
        'frmClearingSchedule
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.ClientSize = New System.Drawing.Size(592, 373)
        Me.Controls.Add(Me.btnSETTLE)
        Me.Controls.Add(Me.pnlTitle)
        Me.Controls.Add(Me.btnCANCEL)
        Me.Controls.Add(Me.pnTransDetail)
        Me.KeyPreview = True
        Me.Name = "frmClearingSchedule"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmClearingSchedule"
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Other methods "
    Protected Overridable Function InitDialog()
        'Khởi tạo kích thước form và load resource
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        LoadResource(Me)

        'Thiết lập các thuộc tính ban đầu cho form
        DoResizeForm()

        If Len(XmlObjData) > 0 Then
            LoadScreen()
        Else

        End If
    End Function

    Private Sub LoadScreen()
        v_dtgHist = New GridEx
        v_dtgHist.Dock = DockStyle.Fill
        Dim v_cmrHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        v_dtgHist.FixedHeaderRows.Add(v_cmrHeader)
        v_dtgHist.Columns.Add(New Xceed.Grid.Column("AUTOID", GetType(System.String)))
        v_dtgHist.Columns.Add(New Xceed.Grid.Column("DESC_DUETYPE", GetType(System.String)))
        v_dtgHist.Columns.Add(New Xceed.Grid.Column("MODCODE", GetType(System.String)))
        v_dtgHist.Columns.Add(New Xceed.Grid.Column("AFACCTNO", GetType(System.String)))
        v_dtgHist.Columns.Add(New Xceed.Grid.Column("ACCTNO", GetType(System.String)))
        v_dtgHist.Columns.Add(New Xceed.Grid.Column("TXDATE", GetType(System.String)))
        v_dtgHist.Columns.Add(New Xceed.Grid.Column("CLEARDAY", GetType(System.String)))
        v_dtgHist.Columns.Add(New Xceed.Grid.Column("DESC_CLEARCD", GetType(System.String)))
        v_dtgHist.Columns.Add(New Xceed.Grid.Column("AMT", GetType(System.String)))
        v_dtgHist.Columns.Add(New Xceed.Grid.Column("AAMT", GetType(System.String)))
        v_dtgHist.Columns.Add(New Xceed.Grid.Column("FAMT", GetType(System.String)))
        v_dtgHist.Columns.Add(New Xceed.Grid.Column("QTTY", GetType(System.String)))
        v_dtgHist.Columns.Add(New Xceed.Grid.Column("AQTTY", GetType(System.String)))
        v_dtgHist.Columns.Add(New Xceed.Grid.Column("ORDERID", GetType(System.String)))
        v_dtgHist.Columns.Add(New Xceed.Grid.Column("AVLSECUREDAMT", GetType(System.String)))
        v_dtgHist.Columns.Add(New Xceed.Grid.Column("AVLFEEAMT", GetType(System.String)))
        v_dtgHist.Columns.Add(New Xceed.Grid.Column("DESC_STATUS", GetType(System.String)))

        v_dtgHist.Columns("AUTOID").Title = mv_ResourceManager.GetString(Me.Name & ".AUTOID")
        v_dtgHist.Columns("DESC_DUETYPE").Title = mv_ResourceManager.GetString(Me.Name & ".DUETYPE")
        v_dtgHist.Columns("MODCODE").Title = mv_ResourceManager.GetString(Me.Name & ".MODCODE")
        v_dtgHist.Columns("AFACCTNO").Title = mv_ResourceManager.GetString(Me.Name & ".AFACCTNO")
        v_dtgHist.Columns("ACCTNO").Title = mv_ResourceManager.GetString(Me.Name & ".ACCTNO")
        v_dtgHist.Columns("TXDATE").Title = mv_ResourceManager.GetString(Me.Name & ".TXDATE")
        v_dtgHist.Columns("CLEARDAY").Title = mv_ResourceManager.GetString(Me.Name & ".CLEARDAY")
        v_dtgHist.Columns("DESC_CLEARCD").Title = mv_ResourceManager.GetString(Me.Name & ".CLEARCD")
        v_dtgHist.Columns("AMT").Title = mv_ResourceManager.GetString(Me.Name & ".AMT")
        v_dtgHist.Columns("AAMT").Title = mv_ResourceManager.GetString(Me.Name & ".AAMT")
        v_dtgHist.Columns("FAMT").Title = mv_ResourceManager.GetString(Me.Name & ".FAMT")
        v_dtgHist.Columns("QTTY").Title = mv_ResourceManager.GetString(Me.Name & ".QTTY")
        v_dtgHist.Columns("AQTTY").Title = mv_ResourceManager.GetString(Me.Name & ".AQTTY")
        v_dtgHist.Columns("ORDERID").Title = mv_ResourceManager.GetString(Me.Name & ".ORDERID")
        v_dtgHist.Columns("AVLSECUREDAMT").Title = mv_ResourceManager.GetString(Me.Name & ".AVLSECUREDAMT")
        v_dtgHist.Columns("AVLFEEAMT").Title = mv_ResourceManager.GetString(Me.Name & ".AVLFEEAMT")
        v_dtgHist.Columns("DESC_STATUS").Title = mv_ResourceManager.GetString(Me.Name & ".STATUS")
        v_dtgHist.Columns("AUTOID").Width = 40
        AddHandler v_dtgHist.DoubleClick, AddressOf Grid_DblClick
        Dim i As Integer
        If Me.v_dtgHist.DataRowTemplate.Cells.Count >= 0 Then
            For i = 0 To Me.v_dtgHist.DataRowTemplate.Cells.Count - 1
                AddHandler v_dtgHist.DataRowTemplate.Cells(i).DoubleClick, AddressOf Grid_DblClick
            Next
        End If
        AddHandler v_dtgHist.DataRowTemplate.KeyUp, AddressOf Grid_KeyUp
        Dim v_xmlDocument As New Xml.XmlDocument, v_nodeList As Xml.XmlNodeList
        Dim j As Integer, v_strFLDNAME, v_strValue As String
        Dim v_strTXDATE, v_strTXNUM, v_strTLTXCD, v_strTXDESC, v_strAMT As String
        v_xmlDocument.LoadXml(Me.XmlObjData)
        v_nodeList = v_xmlDocument.SelectNodes("/TransactMessage/ObjData")
        'Điền thông tin hạch toán
        v_dtgHist.DataRows.Clear()
        v_dtgHist.BeginInit()
        For i = 0 To v_nodeList.Count - 1
            'Lấy dữ liệu
            Dim v_xDataRow As Xceed.Grid.DataRow = v_dtgHist.DataRows.AddNew()
            For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                With v_nodeList.Item(i).ChildNodes(j)
                    v_strValue = Trim(.InnerText)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    Select Case Trim(v_strFLDNAME)
                        Case "AUTOID", "DESC_DUETYPE", "MODCODE", "AFACCTNO", "ACCTNO", "TXDATE", "CLEARDAY", "DESC_CLEARCD", _
                            "AMT", "AAMT", "FAMT", "QTTY", "AQTTY", "ORDERID", "AVLSECUREDAMT", "AVLFEEAMT", "DESC_STATUS"
                            v_xDataRow.Cells(v_strFLDNAME).Value = v_strValue
                    End Select
                End With
            Next
            v_xDataRow.EndEdit()
        Next
        v_dtgHist.EndInit()
        Me.pnTransDetail.Controls.Add(v_dtgHist)
    End Sub

    Private Sub DoResizeForm()

    End Sub

    Private Sub LoadResource(ByRef pv_ctrl As Windows.Forms.Control)
        Dim v_ctrl As Windows.Forms.Control

        For Each v_ctrl In pv_ctrl.Controls
            If TypeOf (v_ctrl) Is Label Then
                CType(v_ctrl, Label).Text = mv_ResourceManager.GetString("frmClearingSchedule." & v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is GroupBox Then
                CType(v_ctrl, GroupBox).Text = mv_ResourceManager.GetString("frmClearingSchedule." & v_ctrl.Name)
                LoadResource(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is Button Then
                CType(v_ctrl, Button).Text = mv_ResourceManager.GetString("frmClearingSchedule." & v_ctrl.Name)
            End If
        Next

        Me.Text = mv_ResourceManager.GetString("frmClearingSchedule")
    End Sub
#End Region

#Region " Overridable Function "
    Public Overridable Sub OnClose()
        Me.Close()
    End Sub
#End Region

#Region " Form events "
    Private Sub frmClearingSchedule_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Select Case e.KeyCode
            Case Keys.Escape
                OnClose()
        End Select

    End Sub

    Private Sub frmClearingSchedule_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitDialog()
    End Sub

    Private Sub btnCANCEL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCANCEL.Click
        OnClose()
    End Sub

    Private Sub btnSETTLE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSETTLE.Click
        If Not v_dtgHist Is Nothing Then
            'Nếu là form search dùng để lookup thì trả về giá trị tìm kiếm
            If v_dtgHist.DataRows.Count > 0 Then
                If Not v_dtgHist.CurrentRow Is Nothing Then
                    ReturnValue = CType(v_dtgHist.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value
                    If Len(ReturnValue) > 0 Then
                        'Tạo ObjInquiry trả về
                        RefValue = CType(v_dtgHist.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value
                    Else
                        RefValue = String.Empty
                    End If
                End If
            End If
            Me.Close()
        End If
    End Sub
    Private Sub Grid_DblClick(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not v_dtgHist Is Nothing Then
            'Nếu là form search dùng để lookup thì trả về giá trị tìm kiếm
            If v_dtgHist.DataRows.Count > 0 Then
                If Not v_dtgHist.CurrentRow Is Nothing Then
                    ReturnValue = CType(v_dtgHist.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value
                    If Len(ReturnValue) > 0 Then
                        'Tạo ObjInquiry trả về
                        RefValue = CType(v_dtgHist.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value
                    Else
                        RefValue = String.Empty
                    End If
                End If
            End If
            Me.Close()
        End If
    End Sub

    Private Sub Grid_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            Select Case e.KeyCode
                Case Keys.Space
                    If Not v_dtgHist Is Nothing Then
                        'Nếu là form search dùng để lookup thì trả về giá trị tìm kiếm
                        If v_dtgHist.DataRows.Count > 0 Then
                            If Not v_dtgHist.CurrentRow Is Nothing Then
                                ReturnValue = CType(v_dtgHist.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value
                                If Len(ReturnValue) > 0 Then
                                    'Tạo ObjInquiry trả về
                                    RefValue = CType(v_dtgHist.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value
                                Else
                                    RefValue = String.Empty
                                End If
                            End If
                        End If
                        Me.Close()
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
#End Region

End Class
