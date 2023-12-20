Imports System.Windows.Forms
Imports Xceed.SmartUI.Controls
Imports CommonLibrary
Imports System.Collections
Imports AppCore
Imports AppCore.modCoreLib


Public Class frmLogMR3009
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSendAll As System.Windows.Forms.Button
    Friend WithEvents pnODSendInfo As System.Windows.Forms.Panel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.pnODSendInfo = New System.Windows.Forms.Panel
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnSendAll = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'pnODSendInfo
        '
        Me.pnODSendInfo.BackColor = System.Drawing.SystemColors.Control
        Me.pnODSendInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnODSendInfo.Location = New System.Drawing.Point(6, 5)
        Me.pnODSendInfo.Name = "pnODSendInfo"
        Me.pnODSendInfo.Size = New System.Drawing.Size(776, 462)
        Me.pnODSendInfo.TabIndex = 2
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(703, 475)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 24)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "btnCancel"
        '
        'btnSendAll
        '
        Me.btnSendAll.Location = New System.Drawing.Point(615, 475)
        Me.btnSendAll.Name = "btnSendAll"
        Me.btnSendAll.Size = New System.Drawing.Size(80, 24)
        Me.btnSendAll.TabIndex = 4
        Me.btnSendAll.Text = "btnSendAll"
        '
        'frmLogMR3009
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(788, 504)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.pnODSendInfo)
        Me.Controls.Add(Me.btnSendAll)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Name = "frmLogMR3009"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmLogMR3009"
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Declare constant and variables "
    Const c_ResourceManager = "_DIRECT.frmLogMR3009-"
    Public ODSendGrid As GridEx
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
    Private mv_blnAdvancedSending As Boolean = True


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
        Dim v_intIndex As Int16
        Dim v_intODKIND As Int16


        v_strCmdInquiry = "SELECT rptdate, ftype, custodycd, afacctno, dfgroupid, fullname, marginrate, mrlrate, odamt, navaccount, rtnamtcl, rtnamtdf, ovd, refullname, TO_CHAR(txtime,'HH24:MM:SS') TXTIME  FROM mr3009_log "


        Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_OD_ODMAST, gc_ActionInquiry, v_strCmdInquiry)
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        v_ws.Message(v_strObjMsg)

        FillDataGrid(ODSendGrid, v_strObjMsg, "")

        If mv_intCurrentRow >= ODSendGrid.DataRows.Count Then mv_intCurrentRow = 0
        If ODSendGrid.DataRows.Count > 0 Then
            ODSendGrid.CurrentRow = ODSendGrid.DataRows(mv_intCurrentRow)
            ODSendGrid.SelectedRows.Clear()
            ODSendGrid.SelectedRows.Add(ODSendGrid.CurrentRow)
            btnSendAll.Focus()
        End If

    End Sub
    Private Sub InitializeGrid()
        'Khá»Ÿi táº¡o Grid contacts
        ODSendGrid = New GridEx
        Dim v_cmrContactsHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrContactsHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrContactsHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        ODSendGrid.FixedHeaderRows.Add(v_cmrContactsHeader)

        ODSendGrid.Columns.Add(New Xceed.Grid.Column("RPTDATE", GetType(System.String)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("TXTIME", GetType(System.String)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("FTYPE", GetType(System.String)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("CUSTODYCD", GetType(System.String)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("AFACCTNO", GetType(System.String)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("FULLNAME", GetType(System.String)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("DFGROUPID", GetType(System.String)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("MARGINRATE", GetType(System.Double)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("MRLRATE", GetType(System.Double)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("ODAMT", GetType(System.Double)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("NAVACCOUNT", GetType(System.Double)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("RTNAMTCL", GetType(System.Double)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("RTNAMTDF", GetType(System.Double)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("OVD", GetType(System.Double)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("REFULLNAME", GetType(System.String)))

        ODSendGrid.Columns("RPTDATE").Title = "Ngày"
        ODSendGrid.Columns("TXTIME").Title = "Giờ"
        ODSendGrid.Columns("FTYPE").Title = "Phân hệ"
        ODSendGrid.Columns("CUSTODYCD").Title = "Số lưu ký"
        ODSendGrid.Columns("AFACCTNO").Title = "Số tiểu khoản"
        ODSendGrid.Columns("FULLNAME").Title = "Họ tên"
        ODSendGrid.Columns("DFGROUPID").Title = "Số Deal tổng"
        ODSendGrid.Columns("MARGINRATE").Title = "Tỷ lệ thực tế"
        ODSendGrid.Columns("MRLRATE").Title = "Tỷ lệ xử lý"
        ODSendGrid.Columns("ODAMT").Title = "Dư nợ quy đổi"
        ODSendGrid.Columns("NAVACCOUNT").Title = "Tài sản quy đổi"
        ODSendGrid.Columns("RTNAMTCL").Title = "Số tiền cần nộp CL"
        ODSendGrid.Columns("RTNAMTDF").Title = "Số tiền cần nộp DF"
        ODSendGrid.Columns("OVD").Title = "Nợ bảo lãnh"
        ODSendGrid.Columns("REFULLNAME").Title = "Tên môi giới"


        ODSendGrid.Columns("RPTDATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODSendGrid.Columns("TXTIME").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODSendGrid.Columns("FTYPE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODSendGrid.Columns("CUSTODYCD").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODSendGrid.Columns("AFACCTNO").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODSendGrid.Columns("FULLNAME").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODSendGrid.Columns("DFGROUPID").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODSendGrid.Columns("MARGINRATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODSendGrid.Columns("MRLRATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODSendGrid.Columns("ODAMT").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODSendGrid.Columns("NAVACCOUNT").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODSendGrid.Columns("RTNAMTCL").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODSendGrid.Columns("RTNAMTDF").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODSendGrid.Columns("OVD").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODSendGrid.Columns("REFULLNAME").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left



        ODSendGrid.Columns("RPTDATE").CanBeSorted = False
        ODSendGrid.Columns("TXTIME").CanBeSorted = False
        ODSendGrid.Columns("FTYPE").CanBeSorted = False
        ODSendGrid.Columns("CUSTODYCD").CanBeSorted = False
        ODSendGrid.Columns("AFACCTNO").CanBeSorted = False

        ODSendGrid.Columns("FULLNAME").CanBeSorted = False
        ODSendGrid.Columns("DFGROUPID").CanBeSorted = False
        ODSendGrid.Columns("MARGINRATE").CanBeSorted = False
        ODSendGrid.Columns("MRLRATE").CanBeSorted = False
        ODSendGrid.Columns("ODAMT").CanBeSorted = False
        ODSendGrid.Columns("NAVACCOUNT").CanBeSorted = False
        ODSendGrid.Columns("RTNAMTCL").CanBeSorted = False
        ODSendGrid.Columns("RTNAMTDF").CanBeSorted = False
        ODSendGrid.Columns("OVD").CanBeSorted = False
        ODSendGrid.Columns("REFULLNAME").CanBeSorted = False

        Me.pnODSendInfo.Controls.Clear()
        Me.pnODSendInfo.Controls.Add(ODSendGrid)
        ODSendGrid.Dock = Windows.Forms.DockStyle.Fill
        'AddHandler ODSendGrid.SelectedRowsChanged, AddressOf ODSendCurrentCellChanged
        If Me.ODSendGrid.DataRowTemplate.Cells.Count >= 0 Then
            For i As Integer = 1 To Me.ODSendGrid.DataRowTemplate.Cells.Count - 1
                AddHandler ODSendGrid.DataRowTemplate.Cells(i).DoubleClick, AddressOf OnView
            Next
        End If

        'AddHandler ODSendGrid.DataRowTemplate.Cells("CHECKALL").Click, AddressOf ODSendSelectedRowChanged        

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

            v_strClause = Trim(CType(ODSendGrid.CurrentRow, Xceed.Grid.DataRow).Cells("ORDERID").Value)

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
            If Not ODSendGrid Is Nothing And Len(pv_strSQLCMD) > 0 Then
                'Remove cÃ¡c báº£n ghi cÅ©
                ODSendGrid.DataRows.Clear()
                Dim v_strSQL As String = pv_strSQLCMD
                Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_OD_ODMAST, gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                Dim v_strResourceManager As String

                FillDataGrid(ODSendGrid, v_strObjMsg, "")

                If Me.ODSendGrid.DataRows.Count > 0 Then
                    ODSendGrid.CurrentRow = Me.ODSendGrid.DataRows(0)
                    setGridRowValue(ODSendGrid.DataRows(0))
                End If

            End If
        Catch ex As Exception
            'MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub setGridRowValue(ByVal pv_GridRow As Xceed.Grid.DataRow)
        mv_strEXECTYPE_VAL = Trim(pv_GridRow.Cells("EXECTYPE_VAL").Value)
        mv_strEXECTYPE = Trim(pv_GridRow.Cells("EXECTYPE").Value)
        mv_strCUSTODYCD = Trim(pv_GridRow.Cells("CUSTODYCD").Value)
        mv_strSYMBOL = Trim(pv_GridRow.Cells("SYMBOL").Value)
        mv_strOODSTATUS = Trim(pv_GridRow.Cells("OODSTATUS").Value)
        mv_strPRICE = Trim(pv_GridRow.Cells("PRICE").Value)
        mv_strQTTY = Trim(pv_GridRow.Cells("QTTY").Value)
        mv_strORDERID = Trim(pv_GridRow.Cells("ORDERID").Value)
        mv_strORDERQTTY = Trim(pv_GridRow.Cells("ORDERQTTY").Value)
        mv_strDESC_PRICETYPE = Trim(pv_GridRow.Cells("DESC_PRICETYPE").Value)
        mv_strQUOTEPRICE = Trim(pv_GridRow.Cells("QUOTEPRICE").Value)
        mv_strLIMITPRICE = Trim(pv_GridRow.Cells("LIMITPRICE").Value)
        mv_strCURRPRICE = Trim(pv_GridRow.Cells("CURRPRICE").Value)
        mv_strMATCHTYPE = Trim(pv_GridRow.Cells("MATCHTYPE").Value)
        mv_strNORK = Trim(pv_GridRow.Cells("NORK").Value)
        mv_strCODEID = Trim(pv_GridRow.Cells("CODEID").Value)
        mv_strSECURERATIOTMIN = Trim(pv_GridRow.Cells("SECUREDRATIOMIN").Value)
        mv_strSECURERATIOMAX = Trim(pv_GridRow.Cells("SECUREDRATIOMAX").Value)
        'mv_strTYP_BRATIO = Trim(pv_GridRow.Cells("TYP_BRATIO").Value)
        'mv_strAF_BRATIO = Trim(pv_GridRow.Cells("AF_BRATIO").Value)
        mv_strCIACCTNO = Trim(pv_GridRow.Cells("CIACCTNO").Value)
        mv_strSEACCTNO = Trim(pv_GridRow.Cells("SEACCTNO").Value)
        mv_strAFACCTNO = Trim(pv_GridRow.Cells("AFACCTNO").Value)
        mv_strPARVALUE = Trim(pv_GridRow.Cells("PARVALUE").Value)
        mv_strNORK = Trim(pv_GridRow.Cells("NORK").Value)
        mv_strMATCHTYPE = Trim(pv_GridRow.Cells("MATCHTYPE").Value)
        mv_strPriceType = Trim(pv_GridRow.Cells("PRICETYPE").Value)

        mv_strOrderStatus = Trim(pv_GridRow.Cells("ORSTATUS").Value)

        'TÃ­nh toÃ¡n tá»· lá»‡ kÃ½ quá»¹ cá»§a lá»‡nh
        If IsNumeric(mv_strSECURERATIOTMIN) And IsNumeric(mv_strSECURERATIOMAX) _
             And IsNumeric(mv_strTYP_BRATIO) And IsNumeric(mv_strAF_BRATIO) Then
            'Láº¥y theo tham sá»‘ má»©c há»‡ thá»‘ng
            mv_dblSecureRatio = CDbl(mv_strSECURERATIOTMIN)
            'So sÃ¡nh vá»›i tham sá»‘ loáº¡i hÃ¬nh
            mv_dblSecureRatio = IIf(mv_dblSecureRatio > CDbl(mv_strTYP_BRATIO), mv_dblSecureRatio, CDbl(mv_strTYP_BRATIO))
            'So sÃ¡nh vá»›i tham sá»‘ há»£p Ä‘á»“ng
            mv_dblSecureRatio = IIf(mv_dblSecureRatio > CDbl(mv_strAF_BRATIO), mv_dblSecureRatio, CDbl(mv_strAF_BRATIO))
            'KhÃ´ng vÆ°á»£t qua Max cá»§a tham sá»‘ há»‡ thá»‘ng
            mv_dblSecureRatio = IIf(mv_dblSecureRatio > CDbl(mv_strSECURERATIOMAX), CDbl(mv_strSECURERATIOMAX), mv_dblSecureRatio)
        Else
            'Máº·c Ä‘á»‹nh lÃ  kÃ½ quá»¹ 100%
            mv_dblSecureRatio = 100
        End If

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

            'Láº¥y thÃ´ng tin chung vá»? giao dá»‹ch
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
                'Náº¿u khÃ´ng tá»“n táº¡i mÃ£ giao dá»‹ch
                MessageBox.Show(mv_ResourceManager.GetString("ERR_TLTXCD_NOTFOUND"))
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

            'Láº¥y thÃ´ng tin chi tiáº¿t cÃ¡c trÆ°á»?ng cá»§a giao dá»‹ch
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
                                v_strPrintInfo = v_strValue 'KhÃ´ng Ä‘Æ°á»£c trim vÃ¬ Ä‘á»™ dÃ i báº¯t buá»™c 10 kÃ½ tá»±
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
                        'Xá»­ lÃ½ cho trÆ°á»?ng Description
                        v_strDefVal = Me.Text
                    ElseIf v_strDefVal = "<$BUSDATE>" Then
                        'Láº¥y ngÃ y lÃ m viá»‡c hiá»‡n táº¡i
                        v_strDefVal = Me.BusDate
                    End If
                    If v_blnChain Then
                        'Náº¿u giao dá»‹ch Ä‘Æ°á»£c náº¡p qua giao dá»‹ch tra cá»©u
                        If Len(v_strChainName) > 0 Then
                            'Náº¿u trÆ°á»?ng nÃ y cÃ³ sá»­ dá»¥ng CHAINNAME Ä‘á»ƒ láº¥y giÃ¡ trá»‹ tá»« mÃ n hÃ¬nh tra cá»©u
                            v_nodetxData = v_xmlDocumentData.SelectSingleNode("TransactMessage/ObjData/entry[@fldname='" & v_strChainName & "']")
                            If Not v_nodetxData Is Nothing Then
                                v_strDefVal = Trim(v_nodetxData.InnerText)
                            End If
                        End If
                    ElseIf v_blnData Then
                        'Náº¿u giao dá»‹ch cÃ³ dá»¯ liá»‡u (xem chi tiáº¿t)
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

            'Láº¥y cÃ¡c luáº­t kiá»ƒm tra cá»§a cÃ¡c trÆ°á»?ng giao dá»‹ch
            v_strClause = "SELECT FLDNAME, VALTYPE, OPERATOR, VALEXP, VALEXP2, ERRMSG, EN_ERRMSG FROM FLDVAL " & _
                "WHERE upper(OBJNAME) = '" & strTLTXCD & "' ORDER BY VALTYPE, FLDNAME, ODRNUM" 'Thá»© tá»± order by lÃ  quan trá»?ng khÃ´ng sá»­a
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
                        'Ghi nháº­n thuáº­t toÃ¡n Ä‘á»ƒ kiá»ƒm tra vÃ  tÃ­nh toÃ¡n cho tá»«ng trÆ°á»?ng cá»§a giao dá»‹ch
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

                'XÃ¡c Ä‘á»‹nh index cá»§a máº£ng FldMaster
                For j = 0 To mv_arrObjFields.GetLength(0) - 1 Step 1
                    If Not mv_arrObjFields(j) Is Nothing Then
                        If Trim(mv_arrObjFields(j).FieldName) = Trim(v_strFieldVal_FldName) Then
                            v_intIndex = j
                        End If
                    End If
                Next

                'Ä?iá»?u kiá»‡n xá»­ lÃ½
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
    'Verify rules cá»§a giao dá»‹ch, tráº£ vá»? Ä‘iá»‡n giao dá»‹ch Ä‘Ã£ Ä‘Æ°á»£c táº¡o
    Private Function VerifyRules(ByRef v_strTxMsg As String) As Boolean
        Try
            Dim v_xmlDocument As New Xml.XmlDocument, v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
            Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode, v_intIndex As Long, i, v_intCount As Integer
            Dim v_strFLDNAME As String, v_strFLDDEFNAME As String, v_strDATATYPE As String, v_strFLDVALUE As String
            Dim v_strERRMSG, v_strENERRMSG, v_strOPERATOR, v_strVALEXP, v_strVALEXP2 As String, v_strACTYPE, v_strDESC As String
            Dim v_dtVALEXP, v_dtVALEXP2, v_dtFLDVALUE As Date, v_strCMDSQL As String
            Dim v_ctl As Control, v_attrFLDNAME As Xml.XmlAttribute, v_attrDATATYPE As Xml.XmlAttribute, v_objEval As New Evaluator
            Dim v_strTLTXCD As String

            'Táº¡o Ä‘iá»‡n giao dá»‹ch
            Select Case mv_strEXECTYPE_VAL 'cboExecType.SelectedValue
                Case "NB", "BC"
                    v_strTLTXCD = gc_OD_SENDBUYORDER
                Case "NS", "SS"
                    v_strTLTXCD = gc_OD_SENDSELLORDER
                Case Else
                    Return False
            End Select
            LoadScreen(v_strTLTXCD)
            v_strTxMsg = BuildXMLTxMsg(gc_MsgTypeTrans, gc_IsLocalMsg, v_strTLTXCD, Me.BranchId, Me.TellerId, Me.IpAddress, Me.WsName, , , , , , , , , , , , , , , , , Me.BusDate)
            v_xmlDocument.LoadXml(v_strTxMsg)
            v_dataElement = v_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "fields", "")
            If mv_arrObjFields.GetLength(0) > 0 Then
                For v_intIndex = 0 To mv_arrObjFields.GetLength(0) - 1 Step 1
                    If Not mv_arrObjFields(v_intIndex) Is Nothing Then
                        v_strFLDNAME = mv_arrObjFields(v_intIndex).FieldName
                        v_strDATATYPE = mv_arrObjFields(v_intIndex).DataType
                        Select Case Trim(v_strFLDNAME)
                            Case "03" 'ORGORDERID
                                v_strFLDVALUE = mv_strORDERID
                            Case "80" 'CODEID
                                v_strFLDVALUE = mv_strCODEID
                            Case "81" 'SYMBOL
                                v_strFLDVALUE = mv_strSYMBOL
                            Case "82" 'CUSTODYCD
                                v_strFLDVALUE = mv_strCUSTODYCD
                            Case "83" 'BORS
                                Select Case mv_strEXECTYPE_VAL
                                    Case "NB", "BC"
                                        v_strFLDVALUE = "B"
                                    Case "NS", "SS"
                                        v_strFLDVALUE = "S"
                                    Case Else
                                        Return False
                                End Select
                            Case "84" 'NORP
                                v_strFLDVALUE = mv_strMATCHTYPE
                            Case "85" 'AORN
                                v_strFLDVALUE = mv_strNORK
                            Case "05" 'CIACCTNO
                                v_strFLDVALUE = mv_strCIACCTNO
                            Case "06" 'SEACCTNO
                                v_strFLDVALUE = mv_strSEACCTNO
                            Case "07" 'AFACCTNO
                                v_strFLDVALUE = mv_strAFACCTNO
                            Case "10" 'PRICE                                       
                                v_strFLDVALUE = mv_strPRICE
                            Case "11" 'QTTY                                       
                                v_strFLDVALUE = mv_strQTTY
                            Case "12" 'PARVALUE                                       
                                v_strFLDVALUE = mv_strPARVALUE
                            Case "13" 'SRATIO                                         
                                v_strFLDVALUE = mv_dblSecureRatio / 100
                            Case "15" 'Secured amount
                                v_strFLDVALUE = mv_dblSecureRatio / 100 * mv_strQTTY * mv_strPRICE
                            Case "30" 'DESC                                              
                                v_strFLDVALUE = mv_strCUSTODYCD & "." & mv_strEXECTYPE_VAL & "." & mv_strSYMBOL & "." & mv_strQTTY & "." & mv_strPRICE
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
                        If UCase(v_strFLDNAME) = "03" Then
                            Clipboard.SetDataObject(v_strFLDVALUE)
                        End If
                        v_xmlDocument.DocumentElement.AppendChild(v_dataElement)
                    End If
                Next
            End If
            v_strTxMsg = v_xmlDocument.InnerXml
            Return True
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function

    'HÃ m nÃ y Ä‘Æ°á»£c dÃ¹ng Ä‘á»ƒ hiá»ƒn thá»‹ láº¡i Ä‘iá»‡n giao dá»‹ch tráº£ vá»? tá»« trÃªn HOST Ä‘á»‘i vá»›i giao dá»‹ch Submit 02 láº§n
    Private Function DisplayConfirm(ByVal v_xmlDocument As Xml.XmlDocument) As Boolean
        'Try
        '    Dim v_dataElement As Xml.XmlElement, v_nodetxData As Xml.XmlNode, v_ctl As Control, v_objAccount As CAccountEntry
        '    Dim v_strPRINTINFO, v_strPRINTNAME, v_strPRINTVALUE, v_strFLDNAME As String, i, j, v_intIndex As Integer
        '    'Hiá»ƒn thá»‹ láº¡i mÃ n hÃ¬nh
        '    Me.mskAFACCTNO.Enabled = False
        '    Me.pnRepo.Enabled = False
        '    Me.pnSpot.Enabled = False
        '    Me.pnForward.Enabled = False
        '    Me.lblRPACCTNO.Text = mv_strRPAccount
        '    Return True
        'Catch ex As Exception
        '    LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
        '    MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        'End Try
    End Function

    Protected Overridable Function InitDialog()
        'Khá»Ÿi táº¡o kÃ­ch thÆ°á»›c form vÃ  load resource
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        LoadResource(Me)
        DoResizeForm()
        ResetScreen(Me)

        setBlankGridRowValue()
    End Function

    Private Sub ResetScreen(ByRef pv_ctrl As Windows.Forms.Control)
        'ODSendGrid.DataRows.Clear()
        'LoadODSend(mv_strSQLCMD)
        Dim i, v_intNumSelected, v_intNum As Integer
        v_intNumSelected = 0
        v_intNum = ODSendGrid.DataRows.Count
        'If Me.ODSendGrid.DataRows.Count > 0 Then
        '    For i = 0 To Me.ODSendGrid.DataRows.Count - 1
        '        ODSendGrid.DataRows(i).Cells("CHECKALL").Value = ""
        '    Next
        'End If
        'If UserLanguage = "EN" Then
        '    Me.lblNumChecked.Text = v_intNumSelected.ToString & "/" & v_intNum.ToString & " items seleted!"
        'Else
        '    Me.lblNumChecked.Text = v_intNumSelected.ToString & "/" & v_intNum.ToString & " dÃ²ng Ä‘Æ°á»£c chá»?n!"
        'End If

        setBlankGridRowValue()
        If Me.ODSendGrid.DataRows.Count > 0 Then
            ODSendGrid.CurrentRow = Me.ODSendGrid.DataRows(0)
            setGridRowValue(ODSendGrid.DataRows(0))
        End If

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
            ElseIf TypeOf (v_ctrl) Is DateTimePicker Then
                CType(v_ctrl, DateTimePicker).Value = CDate(Me.BusDate)
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

    Private Sub ShowSearchFunction(ByVal pv_enable As Boolean)
        If pv_enable = False Then

        End If
    End Sub
    Private Sub OnView(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim v_strClause As String
        Dim v_strErrorSource, v_strErrorMessage As String
        Dim v_lngErrorCode As Long
        Dim v_xmlDocument As New Xml.XmlDocument

        Try
            Dim v_strODDStatus As String

            If mv_intCurrentRow > ODSendGrid.DataRows.Count Then
                mv_intCurrentRow = ODSendGrid.DataRows.Count
            Else
                If ODSendGrid.DataRows.IndexOf(ODSendGrid.CurrentRow) < 0 Then
                    mv_intCurrentRow = 0
                Else
                    mv_intCurrentRow = ODSendGrid.DataRows.IndexOf(ODSendGrid.CurrentRow)
                End If
            End If
            'Phuong add
            If ODSendGrid.CurrentRow Is Nothing Then
                Exit Sub
            End If



        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub
#End Region

#Region " Event "
    Private Sub ODSendCurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'Hiá»ƒn thá»‹ thÃ´ng tin lÃªn mÃ n hÃ¬nh
        If (ODSendGrid.CurrentRow Is Nothing) Then
            Exit Sub
        End If
        setGridRowValue(CType(ODSendGrid.CurrentRow, Xceed.Grid.DataRow))

    End Sub

    Private Sub ODSendSelectedRowChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'Hiá»ƒn thá»‹ thÃ´ng tin lÃªn mÃ n hÃ¬nh
        If (ODSendGrid.CurrentCell Is Nothing) Then
            Exit Sub
        End If
        If (ODSendGrid.CurrentRow Is ODSendGrid.HeaderRows) Then
            Exit Sub
        End If
        Dim i As Integer
        If Me.ODSendGrid.DataRows.Count > 0 Then
            For i = 0 To Me.ODSendGrid.DataRows.Count - 1
                If (ODSendGrid.CurrentCell Is ODSendGrid.DataRows(i).Cells("CHECKALL")) Then
                    'Chuyen trang thai select cho dong nay
                    If ODSendGrid.DataRows(i).Cells("CHECKALL").Value = Nothing Then
                        ODSendGrid.DataRows(i).Cells("CHECKALL").Value = "X"
                    Else
                        ODSendGrid.DataRows(i).Cells("CHECKALL").Value = Nothing
                    End If
                    Exit For
                End If
            Next
        End If
        Dim v_intNumSelected, v_intNum As Integer
        v_intNumSelected = 0
        v_intNum = Me.ODSendGrid.DataRows.Count
        If Me.ODSendGrid.DataRows.Count > 0 Then
            For i = 0 To Me.ODSendGrid.DataRows.Count - 1
                If ODSendGrid.DataRows(i).Cells("CHECKALL").Value = "X" Then
                    v_intNumSelected = v_intNumSelected + 1
                End If
            Next
        End If
        'If v_intNumSelected = v_intNum Then
        '    Me.cboCheckAll.Checked = True
        'End If
        'If v_intNumSelected = 0 Then
        '    Me.cboCheckAll.Checked = False
        'End If
        'If UserLanguage = "EN" Then
        '    Me.lblNumChecked.Text = v_intNumSelected.ToString & "/" & v_intNum.ToString & " items seleted!"
        'Else
        '    Me.lblNumChecked.Text = v_intNumSelected.ToString & "/" & v_intNum.ToString & " dÃ²ng Ä‘Æ°á»£c chá»?n!"
        'End If

    End Sub

    Private Sub btnSendAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendAll.Click
        'OnView(sender, e)
        Dim v_strCmdSQL, v_strClause As String
        v_strCmdSQL = "LOGMR3009"
        v_strClause = "V_OPT !" & "001" & "!varchar2!20"
        Dim v_strObjMsg As String ' = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_OD_ODMAST, gc_ActionInquiry, v_strCmdInquiry)
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strCmdSQL, v_strClause, , , , , , , gc_CommandProcedure)
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        v_ws.Message(v_strObjMsg)

        FillDataGrid(ODSendGrid, v_strObjMsg, "")

        If mv_intCurrentRow >= ODSendGrid.DataRows.Count Then mv_intCurrentRow = 0
        If ODSendGrid.DataRows.Count > 0 Then
            ODSendGrid.CurrentRow = ODSendGrid.DataRows(mv_intCurrentRow)
            ODSendGrid.SelectedRows.Clear()
            ODSendGrid.SelectedRows.Add(ODSendGrid.CurrentRow)
            btnSendAll.Focus()
        End If

        MsgBox("Lưu dữ liệu thành công!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)

    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub


    Private Sub frmLogMR3009_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Select Case e.KeyCode
            Case Keys.Escape
                OnClose()
            Case Keys.F5
                GetOrder()
        End Select
    End Sub
    Private Sub frmLogMR3009_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        GetOrder()

        ShowSearchFunction(mv_blnOrderSendingEx)
    End Sub
    Private Sub cboTradePlace_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        GetOrder()
    End Sub
    Private Sub cboODKIND_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GetOrder()
    End Sub
    Private Sub cboPRICETYPE_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        GetOrder()
    End Sub
#End Region

    Private Sub cboBranch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        GetOrder()
    End Sub
End Class
