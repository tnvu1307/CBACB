Imports System.Windows.Forms
Imports Xceed.SmartUI.Controls
Imports CommonLibrary
Imports System.Collections
Imports System.IO
Public Class frmHistory
    Inherits System.Windows.Forms.Form
    Public v_dtgHist As New GridEx

#Region " Declare constant and variables "
    Const c_ResourceManager = "AppCore.frmHistory-"

    Private mv_strObjectName As String
    Private mv_strModuleCode As String
    Private mv_strLanguage As String
    Private mv_ResourceManager As Resources.ResourceManager
    Private mv_arrObjFields() As CFieldMaster

    Private mv_strLocalObject As String
    Private mv_strBranchId As String
    Private mv_strTellerId As String
    Private mv_strIpAddress As String
    Private mv_strWsName As String
    Private mv_strBusDate As String
    Private mv_strXMLObjData As String
    Private mv_xmlDocument As New Xml.XmlDocument

    Private mv_strHistoryCommand As String
    Private mv_intCurrentPageNumber As Integer = 1
    Private mv_intTotalPage As Integer = 2
    Const NAVIGATE_FIRST = 1
    Const NAVIGATE_PREV = 2
    Const NAVIGATE_NEXT = 3
    Const NAVIGATE_LAST = 4

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
    Public Property HISTRORYCOMMAND() As String
        Get
            Return mv_strHistoryCommand
        End Get
        Set(ByVal Value As String)
            mv_strHistoryCommand = Value
        End Set
    End Property

    Public Property TOTALPAGE() As Integer
        Get
            Return mv_intTotalPage
        End Get
        Set(ByVal Value As Integer)
            mv_intTotalPage = Value
        End Set
    End Property

    Public Property CURRENTPAGE() As Integer
        Get
            Return mv_intCurrentPageNumber
        End Get
        Set(ByVal Value As Integer)
            mv_intCurrentPageNumber = Value
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

    Public Property BusDate() As String
        Get
            Return mv_strBusDate
        End Get
        Set(ByVal Value As String)
            mv_strBusDate = Value
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
    Friend WithEvents btnVIEW As System.Windows.Forms.Button
    Protected WithEvents lblCaption As System.Windows.Forms.Label
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents btnFirst As System.Windows.Forms.Button
    Friend WithEvents btnPrev As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnLast As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.pnlTitle = New System.Windows.Forms.Panel
        Me.lblCaption = New System.Windows.Forms.Label
        Me.btnCANCEL = New System.Windows.Forms.Button
        Me.pnTransDetail = New System.Windows.Forms.Panel
        Me.btnVIEW = New System.Windows.Forms.Button
        Me.btnExport = New System.Windows.Forms.Button
        Me.btnFirst = New System.Windows.Forms.Button
        Me.btnPrev = New System.Windows.Forms.Button
        Me.btnNext = New System.Windows.Forms.Button
        Me.btnLast = New System.Windows.Forms.Button
        Me.pnlTitle.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlTitle
        '
        Me.pnlTitle.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlTitle.Controls.Add(Me.lblCaption)
        Me.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTitle.Location = New System.Drawing.Point(0, 0)
        Me.pnlTitle.Name = "pnlTitle"
        Me.pnlTitle.Size = New System.Drawing.Size(714, 50)
        Me.pnlTitle.TabIndex = 11
        '
        'lblCaption
        '
        Me.lblCaption.AutoSize = True
        Me.lblCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaption.Location = New System.Drawing.Point(7, 16)
        Me.lblCaption.Name = "lblCaption"
        Me.lblCaption.Size = New System.Drawing.Size(63, 13)
        Me.lblCaption.TabIndex = 1
        Me.lblCaption.Tag = "lblCaption"
        Me.lblCaption.Text = "lblCaption"
        '
        'btnCANCEL
        '
        Me.btnCANCEL.Location = New System.Drawing.Point(632, 376)
        Me.btnCANCEL.Name = "btnCANCEL"
        Me.btnCANCEL.Size = New System.Drawing.Size(80, 24)
        Me.btnCANCEL.TabIndex = 14
        Me.btnCANCEL.Text = "btnCANCEL"
        '
        'pnTransDetail
        '
        Me.pnTransDetail.AutoScroll = True
        Me.pnTransDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnTransDetail.Location = New System.Drawing.Point(0, 54)
        Me.pnTransDetail.Name = "pnTransDetail"
        Me.pnTransDetail.Size = New System.Drawing.Size(712, 314)
        Me.pnTransDetail.TabIndex = 8
        '
        'btnVIEW
        '
        Me.btnVIEW.Location = New System.Drawing.Point(456, 376)
        Me.btnVIEW.Name = "btnVIEW"
        Me.btnVIEW.Size = New System.Drawing.Size(80, 24)
        Me.btnVIEW.TabIndex = 12
        Me.btnVIEW.Text = "btnVIEW"
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(544, 376)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(80, 24)
        Me.btnExport.TabIndex = 13
        Me.btnExport.Text = "btnExport"
        '
        'btnFirst
        '
        Me.btnFirst.Location = New System.Drawing.Point(5, 376)
        Me.btnFirst.Name = "btnFirst"
        Me.btnFirst.Size = New System.Drawing.Size(32, 24)
        Me.btnFirst.TabIndex = 15
        Me.btnFirst.Text = "<<"
        '
        'btnPrev
        '
        Me.btnPrev.Location = New System.Drawing.Point(40, 376)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(32, 24)
        Me.btnPrev.TabIndex = 15
        Me.btnPrev.Text = "<"
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(75, 376)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(32, 24)
        Me.btnNext.TabIndex = 15
        Me.btnNext.Text = ">"
        '
        'btnLast
        '
        Me.btnLast.Location = New System.Drawing.Point(110, 376)
        Me.btnLast.Name = "btnLast"
        Me.btnLast.Size = New System.Drawing.Size(32, 24)
        Me.btnLast.TabIndex = 15
        Me.btnLast.Text = ">>"
        '
        'frmHistory
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(714, 405)
        Me.Controls.Add(Me.btnFirst)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.btnVIEW)
        Me.Controls.Add(Me.pnlTitle)
        Me.Controls.Add(Me.btnCANCEL)
        Me.Controls.Add(Me.pnTransDetail)
        Me.Controls.Add(Me.btnPrev)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnLast)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmHistory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmHistory"
        Me.pnlTitle.ResumeLayout(False)
        Me.pnlTitle.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Other methods "
    Private Sub PageNavigate(ByVal v_intDirection As Integer)
        Dim v_xmlDocument As New XmlDocumentEx
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
        Try
            Select Case v_intDirection
                Case NAVIGATE_FIRST
                    CURRENTPAGE = 1
                Case NAVIGATE_PREV
                    If CURRENTPAGE > 1 Then CURRENTPAGE = CURRENTPAGE - 1
                Case NAVIGATE_NEXT
                    If CURRENTPAGE < TOTALPAGE Then CURRENTPAGE = CURRENTPAGE + 1
                    If Me.btnLast.Enabled = False Then TOTALPAGE = CURRENTPAGE + 1
                Case NAVIGATE_LAST
                    CURRENTPAGE = TOTALPAGE
            End Select
            v_xmlDocument.LoadXml(Me.HISTRORYCOMMAND)
            v_xmlDocument.DocumentElement.Attributes(gc_AtributePAGENO).Value = CURRENTPAGE
            Dim v_strTxMsg As String = v_xmlDocument.InnerXml
            v_lngError = v_ws.Message(v_strTxMsg)
            If v_lngError <> ERR_SYSTEM_OK Then
                'Thông báo lỗi
                GetErrorFromMessage(v_strTxMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                Cursor.Current = Cursors.Default
                If v_lngError <> ERR_SA_CHECKER1_OVR And v_lngError <> ERR_SA_CHECKER2_OVR Then
                    MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, Me.Text)
                    Exit Sub
                Else
                    'Lấy thêm nguyên nhân duyệt
                    GetReasonFromMessage(v_strTxMsg, v_strErrorMessage)
                    MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, Me.Text)
                End If
            End If
            XmlObjData = v_strTxMsg
            FillNormalHistory2grid()
        Catch ex As Exception
            Throw ex
        Finally
            v_xmlDocument = Nothing
            v_ws = Nothing
        End Try
    End Sub
    Protected Overridable Function InitDialog()
        'Khởi tạo kích thước form và load resource
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        LoadResource(Me)

        'Thiết lập các thuộc tính ban đầu cho form
        DoResizeForm()

        If String.Compare(ObjectName, gc_CI_GETINTTRANS) = 0 _
            Or String.Compare(ObjectName, gc_OD_IBT_SETTLEMENT) = 0 _
            Or String.Compare(ObjectName, gc_SE_COSTPRICE_HISTORY) = 0 Then
            Me.btnFirst.Visible = False
            Me.btnPrev.Visible = False
            Me.btnNext.Visible = False
            Me.btnLast.Visible = False
        Else
            Me.btnLast.Enabled = False
        End If

        If Len(XmlObjData) > 0 Then
            LoadScreen()
        Else

        End If
    End Function

    Private Sub LoadScreen()
        Select Case ObjectName
            Case gc_CI_GETINTTRANS
                LoadInterestHistoryScreen()
            Case gc_OD_IBT_SETTLEMENT
                LoadIBTSettlementScreen()
            Case gc_SE_COSTPRICE_HISTORY
                LoadCostPriceScreen()
            Case gc_CI_AVERAGE_BALANCE
                LoadAvrBalanceHistoryScreen()
            Case gc_SE_ACCOUNTHISTORY
                LoadSecuritiesHistoryScreen()
            Case Else
                LoadNormalHistoryScreen()
        End Select
    End Sub

    Private Sub LoadAvrBalanceHistoryScreen()
        v_dtgHist.Dock = DockStyle.Fill
        Dim v_cmrHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        v_dtgHist.FixedHeaderRows.Add(v_cmrHeader)
        v_dtgHist.Columns.Add(New Xceed.Grid.Column("AFACCTNO", GetType(System.String)))
        v_dtgHist.Columns.Add(New Xceed.Grid.Column("TXDATE", GetType(System.String)))
        v_dtgHist.Columns.Add(New Xceed.Grid.Column("CIBALANCE", GetType(System.String)))
        v_dtgHist.Columns.Add(New Xceed.Grid.Column("SEBALANCE", GetType(System.String)))
        v_dtgHist.Columns.Add(New Xceed.Grid.Column("AVRBAL", GetType(System.String)))


        v_dtgHist.Columns("AFACCTNO").Title = mv_ResourceManager.GetString(Me.Name & ".AFACCTNO")
        v_dtgHist.Columns("TXDATE").Title = mv_ResourceManager.GetString(Me.Name & ".TXDATE")
        v_dtgHist.Columns("CIBALANCE").Title = mv_ResourceManager.GetString(Me.Name & ".CIBALANCE")
        v_dtgHist.Columns("SEBALANCE").Title = mv_ResourceManager.GetString(Me.Name & ".SEBALANCE")
        v_dtgHist.Columns("AVRBAL").Title = mv_ResourceManager.GetString(Me.Name & ".AVRBAL")


        v_dtgHist.Columns("AFACCTNO").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        v_dtgHist.Columns("TXDATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        v_dtgHist.Columns("CIBALANCE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        v_dtgHist.Columns("SEBALANCE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        v_dtgHist.Columns("AVRBAL").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right

        Dim i As Integer
        Dim v_xmlDocument As New Xml.XmlDocument, v_nodeList As Xml.XmlNodeList
        Dim j As Integer, v_strFLDNAME, v_strValue As String
        Dim v_strTXDATE, v_strTXNUM, v_strTLTXCD, v_strTXDESC, v_strAMT As String
        v_xmlDocument.LoadXml(Me.XmlObjData)
        v_nodeList = v_xmlDocument.SelectNodes("/TransactMessage/ObjData")
        '�?i�?n thông tin hạch toán
        v_dtgHist.DataRows.Clear()
        v_dtgHist.BeginInit()
        For i = 0 To v_nodeList.Count - 1
            'Tạo row dữ liệu
            Dim v_xDataRow As Xceed.Grid.DataRow = v_dtgHist.DataRows.AddNew()
            For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                With v_nodeList.Item(i).ChildNodes(j)
                    v_strValue = Trim(.InnerText)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    Select Case Trim(v_strFLDNAME)
                        Case "AFACCTNO", "TXDATE"
                            v_xDataRow.Cells(v_strFLDNAME).Value = v_strValue
                        Case "AVRBAL", "CIBALANCE", "SEBALANCE"
                            v_xDataRow.Cells(v_strFLDNAME).Value = Format(CDbl(v_strValue), gc_FORMAT_NUMBER)
                    End Select
                End With
            Next
            v_xDataRow.EndEdit()
        Next
        v_dtgHist.EndInit()
        Me.pnTransDetail.Controls.Add(v_dtgHist)
    End Sub

    Private Sub LoadInterestHistoryScreen()
        v_dtgHist.Dock = DockStyle.Fill
        Dim v_cmrHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        v_dtgHist.FixedHeaderRows.Add(v_cmrHeader)
        v_dtgHist.Columns.Add(New Xceed.Grid.Column("FRDATE", GetType(System.String)))
        v_dtgHist.Columns.Add(New Xceed.Grid.Column("TODATE", GetType(System.String)))
        v_dtgHist.Columns.Add(New Xceed.Grid.Column("INTTYPE", GetType(System.String)))
        v_dtgHist.Columns.Add(New Xceed.Grid.Column("INTBAL", GetType(System.String)))
        v_dtgHist.Columns.Add(New Xceed.Grid.Column("IRRATE", GetType(System.String)))
        v_dtgHist.Columns.Add(New Xceed.Grid.Column("INTDAY", GetType(System.String)))
        v_dtgHist.Columns.Add(New Xceed.Grid.Column("INTAMT", GetType(System.String)))

        v_dtgHist.Columns("FRDATE").Title = mv_ResourceManager.GetString(Me.Name & ".FRDATE")
        v_dtgHist.Columns("TODATE").Title = mv_ResourceManager.GetString(Me.Name & ".TODATE")
        v_dtgHist.Columns("INTTYPE").Title = mv_ResourceManager.GetString(Me.Name & ".INTTYPE")
        v_dtgHist.Columns("INTBAL").Title = mv_ResourceManager.GetString(Me.Name & ".INTBAL")
        v_dtgHist.Columns("IRRATE").Title = mv_ResourceManager.GetString(Me.Name & ".IRRATE")
        v_dtgHist.Columns("INTDAY").Title = mv_ResourceManager.GetString(Me.Name & ".INTDAY")
        v_dtgHist.Columns("INTAMT").Title = mv_ResourceManager.GetString(Me.Name & ".INTAMT")

        v_dtgHist.Columns("FRDATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        v_dtgHist.Columns("TODATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        v_dtgHist.Columns("INTTYPE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        v_dtgHist.Columns("INTBAL").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        v_dtgHist.Columns("IRRATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        v_dtgHist.Columns("INTDAY").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        v_dtgHist.Columns("INTAMT").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
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
        '�?i�?n thông tin hạch toán
        v_dtgHist.DataRows.Clear()
        v_dtgHist.BeginInit()
        For i = 0 To v_nodeList.Count - 1
            'Tạo row dữ liệu
            Dim v_xDataRow As Xceed.Grid.DataRow = v_dtgHist.DataRows.AddNew()
            For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                With v_nodeList.Item(i).ChildNodes(j)
                    v_strValue = Trim(.InnerText)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    Select Case Trim(v_strFLDNAME)
                        Case "FRDATE", "TODATE", "INTDAY", "INTTYPE"
                            v_xDataRow.Cells(v_strFLDNAME).Value = v_strValue
                        Case "INTBAL", "IRRATE", "INTAMT"
                            v_xDataRow.Cells(v_strFLDNAME).Value = Format(CDbl(v_strValue), gc_FORMAT_NUMBER)
                    End Select
                End With
            Next
            v_xDataRow.EndEdit()
        Next
        v_dtgHist.EndInit()
        Me.pnTransDetail.Controls.Add(v_dtgHist)
        v_dtgHist.Columns("FRDATE").Width = 1.5 * v_dtgHist.Width / 10
        v_dtgHist.Columns("TODATE").Width = 1.5 * v_dtgHist.Width / 10
        v_dtgHist.Columns("INTTYPE").Width = v_dtgHist.Width / 10
        v_dtgHist.Columns("INTBAL").Width = 2 * v_dtgHist.Width / 10
        v_dtgHist.Columns("IRRATE").Width = v_dtgHist.Width / 10
        v_dtgHist.Columns("INTDAY").Width = v_dtgHist.Width / 10
        v_dtgHist.Columns("INTAMT").Width = 1.5 * v_dtgHist.Width / 10
    End Sub

    Private Sub LoadIBTSettlementScreen()
        v_dtgHist.Dock = DockStyle.Fill
        Dim v_cmrHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        v_dtgHist.FixedHeaderRows.Add(v_cmrHeader)
        v_dtgHist.Columns.Add(New Xceed.Grid.Column("FRDATE", GetType(System.String)))
        v_dtgHist.Columns.Add(New Xceed.Grid.Column("TODATE", GetType(System.String)))
        v_dtgHist.Columns.Add(New Xceed.Grid.Column("STSBR", GetType(System.String)))
        v_dtgHist.Columns.Add(New Xceed.Grid.Column("TXBR", GetType(System.String)))
        v_dtgHist.Columns.Add(New Xceed.Grid.Column("TRFAMT", GetType(System.String)))
        v_dtgHist.Columns.Add(New Xceed.Grid.Column("RCVAMT", GetType(System.String)))


        v_dtgHist.Columns("FRDATE").Title = mv_ResourceManager.GetString(Me.Name & ".FRDATE")
        v_dtgHist.Columns("TODATE").Title = mv_ResourceManager.GetString(Me.Name & ".TODATE")
        v_dtgHist.Columns("STSBR").Title = mv_ResourceManager.GetString(Me.Name & ".STSBR")
        v_dtgHist.Columns("TXBR").Title = mv_ResourceManager.GetString(Me.Name & ".TXBR")
        v_dtgHist.Columns("TRFAMT").Title = mv_ResourceManager.GetString(Me.Name & ".TRFAMT")
        v_dtgHist.Columns("RCVAMT").Title = mv_ResourceManager.GetString(Me.Name & ".RCVAMT")


        v_dtgHist.Columns("FRDATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        v_dtgHist.Columns("TODATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        v_dtgHist.Columns("STSBR").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        v_dtgHist.Columns("TXBR").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        v_dtgHist.Columns("TRFAMT").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        v_dtgHist.Columns("RCVAMT").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right


        Dim i As Integer
        Dim v_xmlDocument As New Xml.XmlDocument, v_nodeList As Xml.XmlNodeList
        Dim j As Integer, v_strFLDNAME, v_strValue As String
        Dim v_strTXDATE, v_strTXNUM, v_strTLTXCD, v_strTXDESC, v_strAMT As String
        v_xmlDocument.LoadXml(Me.XmlObjData)
        v_nodeList = v_xmlDocument.SelectNodes("/TransactMessage/ObjData")
        '�?i�?n thông tin hạch toán
        v_dtgHist.DataRows.Clear()
        v_dtgHist.BeginInit()
        For i = 0 To v_nodeList.Count - 1
            'Tạo row dữ liệu
            Dim v_xDataRow As Xceed.Grid.DataRow = v_dtgHist.DataRows.AddNew()
            For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                With v_nodeList.Item(i).ChildNodes(j)
                    v_strValue = Trim(.InnerText)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    Select Case Trim(v_strFLDNAME)
                        Case "FRDATE", "TODATE", "STSBR", "TXBR"
                            v_xDataRow.Cells(v_strFLDNAME).Value = v_strValue
                        Case "TRFAMT", "RCVAMT"
                            v_xDataRow.Cells(v_strFLDNAME).Value = Format(CDbl(v_strValue), gc_FORMAT_NUMBER)
                    End Select
                End With
            Next
            v_xDataRow.EndEdit()
        Next
        v_dtgHist.EndInit()
        Me.pnTransDetail.Controls.Add(v_dtgHist)
        v_dtgHist.Columns("FRDATE").Width = 1.5 * v_dtgHist.Width / 10
        v_dtgHist.Columns("TODATE").Width = 1.5 * v_dtgHist.Width / 10
        v_dtgHist.Columns("STSBR").Width = 1.5 * v_dtgHist.Width / 10
        v_dtgHist.Columns("TXBR").Width = 1.5 * v_dtgHist.Width / 10
        v_dtgHist.Columns("TRFAMT").Width = 2 * v_dtgHist.Width / 10
        v_dtgHist.Columns("RCVAMT").Width = 2 * v_dtgHist.Width / 10

        Me.btnVIEW.Visible = False
    End Sub

    Private Sub LoadCostPriceScreen()
        v_dtgHist.Dock = DockStyle.Fill
        Dim v_cmrHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        v_dtgHist.FixedHeaderRows.Add(v_cmrHeader)
        v_dtgHist.Columns.Add(New Xceed.Grid.Column("TXDATE", GetType(System.String)))
        v_dtgHist.Columns.Add(New Xceed.Grid.Column("AFACCTNO", GetType(System.String)))
        v_dtgHist.Columns.Add(New Xceed.Grid.Column("SYMBOL", GetType(System.String)))
        v_dtgHist.Columns.Add(New Xceed.Grid.Column("COSTPRICE", GetType(System.String)))

        v_dtgHist.Columns("TXDATE").Title = mv_ResourceManager.GetString(Me.Name & ".TXDATE")
        v_dtgHist.Columns("AFACCTNO").Title = mv_ResourceManager.GetString(Me.Name & ".AFACCTNO")
        v_dtgHist.Columns("SYMBOL").Title = mv_ResourceManager.GetString(Me.Name & ".SYMBOL")
        v_dtgHist.Columns("COSTPRICE").Title = mv_ResourceManager.GetString(Me.Name & ".COSTPRICE")

        v_dtgHist.Columns("TXDATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        v_dtgHist.Columns("AFACCTNO").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        v_dtgHist.Columns("SYMBOL").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        v_dtgHist.Columns("COSTPRICE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center

        Dim i As Integer
        Dim v_xmlDocument As New Xml.XmlDocument, v_nodeList As Xml.XmlNodeList
        Dim j As Integer, v_strFLDNAME, v_strValue As String
        Dim v_strTXDATE, v_strTXNUM, v_strTLTXCD, v_strTXDESC, v_strAMT As String
        v_xmlDocument.LoadXml(Me.XmlObjData)
        v_nodeList = v_xmlDocument.SelectNodes("/TransactMessage/ObjData")
        '�?i�?n thông tin hạch toán
        v_dtgHist.DataRows.Clear()
        v_dtgHist.BeginInit()
        For i = 0 To v_nodeList.Count - 1
            'Tạo row dữ liệu
            Dim v_xDataRow As Xceed.Grid.DataRow = v_dtgHist.DataRows.AddNew()
            For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                With v_nodeList.Item(i).ChildNodes(j)
                    v_strValue = Trim(.InnerText)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    Select Case Trim(v_strFLDNAME)
                        Case "TXDATE", "AFACCTNO", "SYMBOL"
                            v_xDataRow.Cells(v_strFLDNAME).Value = v_strValue
                        Case "COSTPRICE"
                            v_xDataRow.Cells(v_strFLDNAME).Value = Format(CDbl(v_strValue), gc_FORMAT_NUMBER)
                    End Select
                End With
            Next
            v_xDataRow.EndEdit()
        Next
        v_dtgHist.EndInit()
        Me.pnTransDetail.Controls.Add(v_dtgHist)
        v_dtgHist.Columns("TXDATE").Width = 2 * v_dtgHist.Width / 10
        v_dtgHist.Columns("AFACCTNO").Width = 2 * v_dtgHist.Width / 10
        v_dtgHist.Columns("SYMBOL").Width = 2 * v_dtgHist.Width / 10
        v_dtgHist.Columns("COSTPRICE").Width = 3 * v_dtgHist.Width / 10

        Me.btnVIEW.Visible = False
    End Sub

    Private Sub LoadNormalHistoryScreen()
        v_dtgHist.Dock = DockStyle.Fill

        Dim GroupByRow1 As New Xceed.Grid.GroupByRow

        GroupByRow1.NoGroupText = mv_ResourceManager.GetString("GridEx.GroupByRow")
        GroupByRow1.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(127, Byte), CType(123, Byte), CType(122, Byte))
        GroupByRow1.CellBackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        GroupByRow1.CellFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        v_dtgHist.FixedHeaderRows.Add(GroupByRow1)
        Dim v_cmrHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        v_dtgHist.FixedHeaderRows.Add(v_cmrHeader)
        'v_dtgHist.Columns.Add(New Xceed.Grid.Column("DELTD", GetType(System.String)))
        v_dtgHist.Columns.Add(New Xceed.Grid.Column("BUSDATE", GetType(System.String)))
        v_dtgHist.Columns.Add(New Xceed.Grid.Column("TXDATE", GetType(System.String)))
        v_dtgHist.Columns.Add(New Xceed.Grid.Column("TXNUM", GetType(System.String)))
        v_dtgHist.Columns.Add(New Xceed.Grid.Column("TLTXCD", GetType(System.String)))
        v_dtgHist.Columns.Add(New Xceed.Grid.Column("TLTXDESC", GetType(System.String)))
        v_dtgHist.Columns.Add(New Xceed.Grid.Column("AMT", GetType(System.String)))
        v_dtgHist.Columns.Add(New Xceed.Grid.Column("TXDESC", GetType(System.String)))
        v_dtgHist.Columns.Add(New Xceed.Grid.Column("DELTD", GetType(System.String)))
        v_dtgHist.Columns.Add(New Xceed.Grid.Column("MAKER", GetType(System.String)))
        v_dtgHist.Columns.Add(New Xceed.Grid.Column("CHECKER", GetType(System.String)))

        'v_dtgHist.Columns("DELTD").Title = mv_ResourceManager.GetString(Me.Name & ".DELTD")
        v_dtgHist.Columns("TXDATE").Title = mv_ResourceManager.GetString(Me.Name & ".TXDATE")
        v_dtgHist.Columns("TXNUM").Title = mv_ResourceManager.GetString(Me.Name & ".TXNUM")
        v_dtgHist.Columns("BUSDATE").Title = mv_ResourceManager.GetString(Me.Name & ".BUSDATE")
        v_dtgHist.Columns("TLTXCD").Title = mv_ResourceManager.GetString(Me.Name & ".TLTXCD")
        v_dtgHist.Columns("TLTXDESC").Title = mv_ResourceManager.GetString(Me.Name & ".TLTXDESC")
        v_dtgHist.Columns("AMT").Title = mv_ResourceManager.GetString(Me.Name & ".AMT")
        v_dtgHist.Columns("TXDESC").Title = mv_ResourceManager.GetString(Me.Name & ".TXDESC")
        v_dtgHist.Columns("DELTD").Title = mv_ResourceManager.GetString(Me.Name & ".DELTD")
        v_dtgHist.Columns("MAKER").Title = mv_ResourceManager.GetString(Me.Name & ".MAKER")
        v_dtgHist.Columns("CHECKER").Title = mv_ResourceManager.GetString(Me.Name & ".CHECKER")

        'v_dtgHist.Columns("DELTD").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        v_dtgHist.Columns("TXDATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        v_dtgHist.Columns("TXNUM").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        v_dtgHist.Columns("BUSDATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        v_dtgHist.Columns("TLTXCD").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        v_dtgHist.Columns("TLTXDESC").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        v_dtgHist.Columns("AMT").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        v_dtgHist.Columns("TXDESC").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        v_dtgHist.Columns("DELTD").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        v_dtgHist.Columns("MAKER").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        v_dtgHist.Columns("CHECKER").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center


        AddHandler v_dtgHist.DoubleClick, AddressOf Grid_DblClick
        Dim i As Integer
        If Me.v_dtgHist.DataRowTemplate.Cells.Count >= 0 Then
            For i = 0 To Me.v_dtgHist.DataRowTemplate.Cells.Count - 1
                AddHandler v_dtgHist.DataRowTemplate.Cells(i).DoubleClick, AddressOf Grid_DblClick
            Next
        End If

        FillNormalHistory2grid()

        'Dim v_xmlDocument As New Xml.XmlDocument, v_nodeList As Xml.XmlNodeList
        'Dim j As Integer, v_strFLDNAME, v_strValue As String
        'Dim v_strTXDATE, v_strTXNUM, v_strTLTXCD, v_strTXDESC, v_strAMT, v_str As String
        'v_xmlDocument.LoadXml(Me.XmlObjData)
        'v_nodeList = v_xmlDocument.SelectNodes("/TransactMessage/ObjData")
        ''�?i�?n thông tin hạch toán
        'v_dtgHist.DataRows.Clear()
        'v_dtgHist.BeginInit()

        ''Xac dinh da den cuoi trang chua
        'If v_nodeList.Count > 0 Then
        '    TOTALPAGE = CURRENTPAGE + 1
        'Else
        '    Me.btnLast.Enabled = True
        'End If

        'For i = 0 To v_nodeList.Count - 1
        '    'Lấy dữ liệu
        '    Dim v_xDataRow As Xceed.Grid.DataRow = v_dtgHist.DataRows.AddNew()
        '    For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
        '        With v_nodeList.Item(i).ChildNodes(j)
        '            v_strValue = Trim(.InnerText)
        '            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
        '            Select Case Trim(v_strFLDNAME)
        '                Case "TXDATE", "TXNUM", "TLTXCD", "TXDESC", "DELTD", "BUSDATE"
        '                    v_xDataRow.Cells(v_strFLDNAME).Value = v_strValue
        '                Case "TLTXDESC"
        '                    If mv_strLanguage = gc_LANG_VIETNAMESE Then
        '                        v_xDataRow.Cells("TLTXDESC").Value = v_strValue
        '                    End If
        '                Case "TLTXEN_DESC"
        '                    If mv_strLanguage = gc_LANG_ENGLISH Then
        '                        v_xDataRow.Cells("TLTXDESC").Value = v_strValue
        '                    End If
        '                Case "AMT"
        '                    If v_strValue Is Nothing Then
        '                        v_strValue = "0"
        '                    End If
        '                    If Not IsNumeric(v_strValue) Then
        '                        v_strValue = "0"
        '                    Else
        '                        v_xDataRow.Cells(v_strFLDNAME).Value = Format(CDbl(v_strValue), gc_FORMAT_NUMBER_2)
        '                    End If
        '            End Select
        '        End With
        '    Next
        '    v_xDataRow.EndEdit()
        'Next
        'v_dtgHist.EndInit()
        Me.pnTransDetail.Controls.Add(v_dtgHist)
        'v_dtgHist.Columns("DELTD").Width = 0.8 * v_dtgHist.Width / 10
        v_dtgHist.Columns("TXDATE").Width = 1 * v_dtgHist.Width / 10
        v_dtgHist.Columns("TXNUM").Width = 1 * v_dtgHist.Width / 10
        v_dtgHist.Columns("BUSDATE").Width = 1 * v_dtgHist.Width / 10
        v_dtgHist.Columns("TLTXCD").Width = 1 * v_dtgHist.Width / 10
        v_dtgHist.Columns("TLTXDESC").Width = 2.3 * v_dtgHist.Width / 10
        v_dtgHist.Columns("TXDESC").Width = 2.3 * v_dtgHist.Width / 10
        v_dtgHist.Columns("AMT").Width = 1.5 * v_dtgHist.Width / 10
        v_dtgHist.Columns("DELTD").Width = 0.8 * v_dtgHist.Width / 10
        v_dtgHist.Columns("MAKER").Width = 1.5 * v_dtgHist.Width / 10
        v_dtgHist.Columns("CHECKER").Width = 1.5 * v_dtgHist.Width / 10
    End Sub

    Private Sub LoadSecuritiesHistoryScreen()
        v_dtgHist.Dock = DockStyle.Fill

        Dim GroupByRow1 As New Xceed.Grid.GroupByRow

        GroupByRow1.NoGroupText = mv_ResourceManager.GetString("GridEx.GroupByRow")
        GroupByRow1.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(127, Byte), CType(123, Byte), CType(122, Byte))
        GroupByRow1.CellBackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        GroupByRow1.CellFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        v_dtgHist.FixedHeaderRows.Add(GroupByRow1)
        Dim v_cmrHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        v_dtgHist.FixedHeaderRows.Add(v_cmrHeader)
        v_dtgHist.Columns.Add(New Xceed.Grid.Column("DELTD", GetType(System.String)))
        v_dtgHist.Columns.Add(New Xceed.Grid.Column("BUSDATE", GetType(System.String)))
        v_dtgHist.Columns.Add(New Xceed.Grid.Column("TXDATE", GetType(System.String)))
        v_dtgHist.Columns.Add(New Xceed.Grid.Column("TXNUM", GetType(System.String)))
        v_dtgHist.Columns.Add(New Xceed.Grid.Column("TLTXCD", GetType(System.String)))
        v_dtgHist.Columns.Add(New Xceed.Grid.Column("SYMBOL", GetType(System.String)))
        v_dtgHist.Columns.Add(New Xceed.Grid.Column("TLTXDESC", GetType(System.String)))
        v_dtgHist.Columns.Add(New Xceed.Grid.Column("AMT", GetType(System.String)))
        v_dtgHist.Columns.Add(New Xceed.Grid.Column("TXDESC", GetType(System.String)))
        v_dtgHist.Columns.Add(New Xceed.Grid.Column("MAKER", GetType(System.String)))
        v_dtgHist.Columns.Add(New Xceed.Grid.Column("CHECKER", GetType(System.String)))

        v_dtgHist.Columns("DELTD").Title = mv_ResourceManager.GetString(Me.Name & ".DELTD")
        v_dtgHist.Columns("TXDATE").Title = mv_ResourceManager.GetString(Me.Name & ".TXDATE")
        v_dtgHist.Columns("TXNUM").Title = mv_ResourceManager.GetString(Me.Name & ".TXNUM")
        v_dtgHist.Columns("BUSDATE").Title = mv_ResourceManager.GetString(Me.Name & ".BUSDATE")
        v_dtgHist.Columns("SYMBOL").Title = mv_ResourceManager.GetString(Me.Name & ".SYMBOL")
        v_dtgHist.Columns("TLTXCD").Title = mv_ResourceManager.GetString(Me.Name & ".TLTXCD")
        v_dtgHist.Columns("TLTXDESC").Title = mv_ResourceManager.GetString(Me.Name & ".TLTXDESC")
        v_dtgHist.Columns("AMT").Title = mv_ResourceManager.GetString(Me.Name & ".AMT")
        v_dtgHist.Columns("TXDESC").Title = mv_ResourceManager.GetString(Me.Name & ".TXDESC")
        v_dtgHist.Columns("MAKER").Title = mv_ResourceManager.GetString(Me.Name & ".MAKER")
        v_dtgHist.Columns("CHECKER").Title = mv_ResourceManager.GetString(Me.Name & ".CHECKER")

        v_dtgHist.Columns("DELTD").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        v_dtgHist.Columns("TXDATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        v_dtgHist.Columns("TXNUM").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        v_dtgHist.Columns("BUSDATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        v_dtgHist.Columns("SYMBOL").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        v_dtgHist.Columns("TLTXCD").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        v_dtgHist.Columns("TLTXDESC").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        v_dtgHist.Columns("AMT").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        v_dtgHist.Columns("TXDESC").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        v_dtgHist.Columns("MAKER").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        v_dtgHist.Columns("CHECKER").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left

        AddHandler v_dtgHist.DoubleClick, AddressOf Grid_DblClick
        Dim i As Integer
        If Me.v_dtgHist.DataRowTemplate.Cells.Count >= 0 Then
            For i = 0 To Me.v_dtgHist.DataRowTemplate.Cells.Count - 1
                AddHandler v_dtgHist.DataRowTemplate.Cells(i).DoubleClick, AddressOf Grid_DblClick
            Next
        End If

        FillNormalHistory2grid()
        Me.pnTransDetail.Controls.Add(v_dtgHist)
        v_dtgHist.Columns("DELTD").Width = 0.8 * v_dtgHist.Width / 10
        v_dtgHist.Columns("TXDATE").Width = 1 * v_dtgHist.Width / 10
        v_dtgHist.Columns("TXNUM").Width = 1 * v_dtgHist.Width / 10
        v_dtgHist.Columns("SYMBOL").Width = 1 * v_dtgHist.Width / 10
        v_dtgHist.Columns("BUSDATE").Width = 1 * v_dtgHist.Width / 10
        v_dtgHist.Columns("TLTXCD").Width = 1 * v_dtgHist.Width / 10
        v_dtgHist.Columns("TLTXDESC").Width = 2.3 * v_dtgHist.Width / 10
        v_dtgHist.Columns("TXDESC").Width = 2.3 * v_dtgHist.Width / 10
        v_dtgHist.Columns("AMT").Width = 1.5 * v_dtgHist.Width / 10
        v_dtgHist.Columns("MAKER").Width = 1.5 * v_dtgHist.Width / 10
        v_dtgHist.Columns("CHECKER").Width = 1.5 * v_dtgHist.Width / 10
    End Sub

    Private Sub FillNormalHistory2grid()
        Dim v_xmlDocument As New Xml.XmlDocument, v_nodeList As Xml.XmlNodeList
        Dim i, j As Integer, v_strFLDNAME, v_strValue As String
        Dim v_strTXDATE, v_strTXNUM, v_strTLTXCD, v_strTXDESC, v_strAMT, v_str As String
        v_xmlDocument.LoadXml(Me.XmlObjData)
        v_nodeList = v_xmlDocument.SelectNodes("/TransactMessage/ObjData")

        'Xac dinh da den cuoi trang chua
        If v_nodeList.Count > 0 Then
            '�?i�?n thông tin hạch toán
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
                            Case "TXDATE", "TXNUM", "TLTXCD", "TXDESC", "DELTD", "BUSDATE", "SYMBOL", "MAKER", "CHECKER"
                                v_xDataRow.Cells(v_strFLDNAME).Value = v_strValue
                            Case "TLTXDESC"
                                If mv_strLanguage = gc_LANG_VIETNAMESE Then
                                    v_xDataRow.Cells("TLTXDESC").Value = v_strValue
                                End If
                            Case "TLTXEN_DESC"
                                If mv_strLanguage = gc_LANG_ENGLISH Then
                                    v_xDataRow.Cells("TLTXDESC").Value = v_strValue
                                End If
                            Case "AMT"
                                If v_strValue Is Nothing Then
                                    v_strValue = "0"
                                End If
                                If Not IsNumeric(v_strValue) Then
                                    v_strValue = "0"
                                Else
                                    v_xDataRow.Cells(v_strFLDNAME).Value = Format(CDbl(v_strValue), gc_FORMAT_NUMBER_2)
                                End If
                        End Select
                    End With
                Next
                v_xDataRow.EndEdit()
            Next
            Me.pnTransDetail.Text = "Page: " & CURRENTPAGE
            v_dtgHist.EndInit()
            If v_nodeList.Count < ROWS_PER_PAGE Then
                TOTALPAGE = CURRENTPAGE
                Me.btnLast.Enabled = True
            End If
        Else
            CURRENTPAGE = CURRENTPAGE - 1
            TOTALPAGE = TOTALPAGE - 1
            Me.btnLast.Enabled = True
        End If

    End Sub

    Private Sub DoResizeForm()

    End Sub

    Private Sub LoadResource(ByRef pv_ctrl As Windows.Forms.Control)
        Dim v_ctrl As Windows.Forms.Control

        For Each v_ctrl In pv_ctrl.Controls
            If TypeOf (v_ctrl) Is Label Then
                CType(v_ctrl, Label).Text = mv_ResourceManager.GetString("frmHistory." & v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is GroupBox Then
                CType(v_ctrl, GroupBox).Text = mv_ResourceManager.GetString("frmHistory." & v_ctrl.Name)
                LoadResource(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is Panel Then
                LoadResource(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is Button Then
                CType(v_ctrl, Button).Text = mv_ResourceManager.GetString("frmHistory." & v_ctrl.Name)
            End If
        Next

        Select Case ObjectName
            Case gc_CI_GETINTTRANS
                Me.Text = mv_ResourceManager.GetString(Me.Name & ".INTHIST")
                Me.btnVIEW.Visible = False
            Case Else
                Me.Text = mv_ResourceManager.GetString("frmHistory")
        End Select
    End Sub
#End Region

#Region " Overridable Function "
    Public Overridable Sub OnClose()
        Me.Close()
    End Sub
    Public Overridable Sub OnView()
        Try
            'Lấy TXDATE và TXNUM
            Dim v_strTXNUM, v_strTXDATE, v_strNextTXNUM, v_strTLTXCD, v_strNextTXDATE, v_strDeltd As String
            If Not (v_dtgHist Is Nothing) Then
                If Not (v_dtgHist.CurrentRow Is Nothing) Then
                    v_strTXNUM = Trim(CType(v_dtgHist.CurrentRow, Xceed.Grid.DataRow).Cells("TXNUM").Value)
                    v_strTXDATE = Trim(CType(v_dtgHist.CurrentRow, Xceed.Grid.DataRow).Cells("TXDATE").Value)
                    v_strTLTXCD = Trim(CType(v_dtgHist.CurrentRow, Xceed.Grid.DataRow).Cells("TLTXCD").Value)
                    'Hiển thị lên màn hình giao dịch
                    Dim frm As New frmTransact(UserLanguage)
                    frm.LocalObject = gc_IsNotLocalMsg
                    frm.ObjectName = ""
                    frm.TxDate = v_strTXDATE
                    frm.TxNum = v_strTXNUM
                    frm.BusDate = Me.BusDate
                    frm.BranchId = Me.BranchId
                    frm.TellerId = Me.TellerId
                    frm.IsHistoryView = True
                    frm.ShowDialog()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Protected Overridable Sub OnExport()
        Try
            Dim v_dlgSave As New SaveFileDialog
            v_dlgSave.Filter = "Text files (*.txt)|*.txt|Excel files (*.xls)|*.xls|All files (*.*)|*.*"
            v_dlgSave.RestoreDirectory = True
            Dim v_res As DialogResult = v_dlgSave.ShowDialog(Me)
            If v_res = DialogResult.OK Then
                Dim v_strFileName As String = v_dlgSave.FileName
                Dim v_strData As String
                Dim v_streamWriter As New StreamWriter(v_strFileName, False, System.Text.Encoding.Unicode)

                If (v_dtgHist.DataRows.Count > 0) Then
                    'Write file's header
                    v_strData = String.Empty
                    For idx As Integer = 0 To v_dtgHist.Columns.Count - 1
                        If v_dtgHist.Columns(idx).Visible Then
                            v_strData &= v_dtgHist.Columns(idx).Title & vbTab
                        End If
                    Next
                    v_streamWriter.WriteLine(v_strData)

                    'Write data
                    For i As Integer = 0 To v_dtgHist.DataRows.Count - 1
                        v_strData = String.Empty

                        For j As Integer = 0 To v_dtgHist.DataRows(i).Cells.Count - 1
                            If v_dtgHist.Columns(j).Visible Then
                                v_strData &= v_dtgHist.DataRows(i).Cells(j).Value & vbTab
                            End If
                        Next

                        'Write data to the file
                        v_streamWriter.WriteLine(v_strData)
                    Next
                Else
                    MsgBox(mv_ResourceManager.GetString("frmHistory.NothingToExport"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
                    Exit Sub
                End If

                'Close StreamWriter
                v_streamWriter.Close()

                MsgBox(mv_ResourceManager.GetString("frmHistory.ExportSuccess"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Sub
#End Region

#Region " Form events "
    Private Sub frmHistory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitDialog()
    End Sub

    Private Sub btnCANCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCANCEL.Click
        OnClose()
    End Sub

    Private Sub btnVIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVIEW.Click
        OnView()
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        OnExport()
    End Sub

    Private Sub Grid_DblClick(ByVal sender As Object, ByVal e As System.EventArgs)
        If ObjectName <> gc_CI_GETINTTRANS Then
            OnView()
        End If
    End Sub

    Private Sub btnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirst.Click
        PageNavigate(NAVIGATE_FIRST)
    End Sub

    Private Sub btnPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrev.Click
        PageNavigate(NAVIGATE_PREV)
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        PageNavigate(NAVIGATE_NEXT)
    End Sub

    Private Sub btnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLast.Click
        PageNavigate(NAVIGATE_LAST)
    End Sub

    Private Sub Grid_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            If ObjectName <> gc_CI_GETINTTRANS Then
                Select Case e.KeyCode
                    Case Keys.Enter, Keys.Space
                        OnView()
                End Select
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub frmHistory_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Select Case e.KeyCode
            Case Keys.Escape
                OnClose()
        End Select
    End Sub
#End Region

End Class
