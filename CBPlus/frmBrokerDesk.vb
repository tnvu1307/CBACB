Imports CommonLibrary
Imports Xceed.SmartUI.Controls
Imports System.Collections
Imports System.IO
Imports AppCore
Imports System.Text
Imports ZetaCompressionLibrary
Imports System.Reflection
Imports DataGridViewAutoFilter
Imports System.Configuration.ConfigurationSettings
Imports System.Configuration

'Imports Microsoft.Office.Interop

Public Class frmBrokerDesk

#Region " Declare constant and variables "
    Const c_ResourceManager As String = "_DIRECT.frmBrokerDesk-"
    Const c_GridSelectedColumn As String = "SELECT"
    Const c_GridSelectedValue As String = "X"
    Const c_DelimiterChar As String = "|"
    Const c_MaxCancelOrders As Long = 20

    'Khai báo các object bắt sự kiện xử lý sự kiện
    Dim WithEvents mv_objMKTBOD As New objNotify("MKTBOD")
    Dim WithEvents mv_objMKTLOG As New objNotify("MKTLOG")
    Dim WithEvents mv_objSYMBOD As New objNotify("SYMBOD")
    Dim WithEvents mv_objSYMDEEP As New objNotify("SYMDEEP")
    Dim WithEvents mv_objSYMLOG As New objNotify("SYMLOG")
    Dim WithEvents mv_objACCUSER As New objNotify("ACCUSER")
    Dim WithEvents mv_objACCINFO As New objNotify("ACCINFO")
    Dim WithEvents mv_objACCCI As New objNotify("ACCCI")
    Dim WithEvents mv_objACCSE As New objNotify("ACCSE")
    Dim WithEvents mv_objACCOD As New objNotify("ACCOD")


    Const c_CacheMarketInforFile As String = "mktcacheinfor.db3"
    Private mv_cacheDataSQLite As CacheOnSQLite
    Private mv_cacheMaster As New Hashtable 'Tham chiếu những object nào đã được Cache: Key=ObjName.Key, Object là một Hastable

    Private mv_blnShortSale As Boolean = False
    Private mv_strObjectName As String
    Private mv_strModuleCode As String
    Private mv_strLanguage As String
    Private mv_ResourceManager As Resources.ResourceManager
    Private mv_arrObjFields() As CFieldMaster
    Private mv_arrObjFldVals() As CFieldVal

    Private mv_strLocalObject As String
    Private mv_strBranchId As String
    Private mv_strTellerId As String
    Private mv_strTellerName As String
    Private mv_strIpAddress As String
    Private mv_strWsName As String
    Private mv_strBusDate As String
    Private mv_strXMLObjData As String
    Private mv_strDealMovingMessage As String
    Private mv_strOrderConfirmationMessage As String
    Private mv_strGroupCancelOrderConfirmationMessage As String
    Private mb_blnIsEnterOnPriceField As Boolean = False
    Private mb_blnIsFirstRun As Boolean = True
    Private mv_blnAcctEntry As Boolean = False
    Private mv_blnHandleKeyboard As Boolean = False
    Private mv_blnFlagSplitOption As Boolean = False
    Private mv_blnNotAllowHotKey As Boolean = False
    Private mv_blnCustomerFound As Boolean = False

    Private mv_dblAdvancedIntRate As Double = 0
    Private mv_dblAdvancedMinFeeAmt As Double = 0
    Private mv_lngHoSEMaxQtty As Double = 0
    Private mv_lngHoSEMaxOrders As Double = 0
    Private mv_lngHNXMaxQtty As Double = 0
    Private mv_lngHNXMaxOrders As Double = 0

    Private mv_strViaChannel As String = "F"
    Dim v_strPrefixCustodyCD As String = AppSettings.Get("PrefixedCustodyCode")
    Private mv_strDefaultCustodyCD As String = v_strPrefixCustodyCD & "C"

    'Thong tin chung khoan
    'CL
    Dim mv_strMarginType As String = "N"
    Dim mv_dblMarginRatioRate As Double = 0
    Dim mv_dblSecMarginPrice As Double = 0
    Dim mv_dblAdvanceLine As Double = 0
    Dim mv_dblTrfT0Amt As Double = 0
    Dim mv_dblT0SecureAmt As Double = 0
    Dim mv_dblIsPPUsed As Double = 1
    'ML
    Dim mv_dblDFRate As Double = 0
    Dim mv_dblDFPrice As Double = 0

    Private mv_dblTradeUnit As Double = 0
    Private mv_dblTradeLot As Double = 0
    Private mv_dblFloorPrice As Double = 0
    Private mv_dblMarginPrice As Double = 0
    Private mv_dblMarginRefPrice As Double = 0
    Private mv_dblCeilingPrice As Double = 0
    Private mv_dblRefPrice As Double = 0
    Private mv_dblCurrentMoveQtty As Double = 0
    Private mv_dblCurrentMoveAmount As Double = 0
    Private mv_lngIdxTradeLog As Long = 0
    Private mv_arrHasTableCurrentStockInfor As New Hashtable

    'NamLP: UPCOM
    Private mv_dblMinQtty As Double = 0
    Private mv_dblMaxQtty As Double = 0
    'NamLP: UPCOM End
    Private mv_strExchangeCode As String
    Private mv_strSecuritiesType As String
    Private mv_strOldSearchBy As String = ""
    Private mv_strOldSearchValue As String = ""


    'Thong tin lien quan den khach hang dat lenh
    Private mv_strCUSTID As String
    Private mv_arrAccountName() As String
    Private mv_arrAccountNumber() As String
    Private mv_arrAccountCoreBank() As String
    Private mv_arrBorrowAccountNumber() As String
    Private mv_arrAccountRole() As String
    Private mv_arrAccountAuth() As String
    Private mv_arrActype() As String
    Private mv_arrCustodyCode() As String
    Private mv_arrCareByCustomer() As String
    Private mv_arrAcctMarginClass() As String
    Private mv_arrAcctPurchasingPowerType() As String
    Private mv_dblPURCHASINGPOWER As Double
    Private mv_dblAVLLIMIT As Double
    Private mv_dblPPSE As Double
    Private mv_dblMaxBuyQtty As Double  'QuangVD: sua tu Integer thanh Double
    Private mv_dgDataGrid As DataGridView

    Private mv_xmlSPLITOPTION As XmlDocumentEx
    Private mv_xmlSYMBOLSLIST As XmlDocumentEx
    Private mv_xmlSYMBOLTICKSIZE As XmlDocumentEx
    Private mv_xmlCUSTOMER As XmlDocumentEx

    Public mv_frmCFMAST As New frmCFMAST_bk
    Public mv_frmCFAUTH As New frmCFAUTH


    Dim mv_strChkSysCtrl As String = "N"
    Dim mv_strIsMarginAllow As String = "N"
    Dim mv_dblDefFeeRate As Double = 0
    Dim mv_dblPRAvlLimit As Double = 0


    'Private mv_blnFlag As Boolean
#End Region

#Region " Properties "

    Public Property IsShortSale() As Boolean
        Get
            Return mv_blnShortSale
        End Get
        Set(ByVal Value As Boolean)
            mv_blnShortSale = Value
        End Set
    End Property

    Public Property DefaultCustodyCD() As String
        Get
            Return mv_strDefaultCustodyCD
        End Get
        Set(ByVal Value As String)
            mv_strDefaultCustodyCD = Value
        End Set
    End Property

    Public Property ViaChannel() As String
        Get
            Return mv_strViaChannel
        End Get
        Set(ByVal Value As String)
            mv_strViaChannel = Value
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

    Public Property TellerName() As String
        Get
            Return mv_strTellerName
        End Get
        Set(ByVal Value As String)
            mv_strTellerName = Value
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

    Public Property ResourceManager() As Resources.ResourceManager
        Get
            Return mv_ResourceManager
        End Get
        Set(ByVal Value As Resources.ResourceManager)
            mv_ResourceManager = Value
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
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        LoadResource(Me)

        'Load Auto filter column
        With showAllLabeldgRemainOrders
            .Visible = False
            .IsLink = True
            .LinkBehavior = LinkBehavior.HoverUnderline
            .ForeColor = Color.White
            .BackColor = Color.Black
        End With

        With statusStripdgRemainOrders
            .Cursor = Cursors.Default
            .Items.AddRange(New ToolStripItem() { _
                filterStatusLabeldgRemainOrders, showAllLabeldgRemainOrders})
        End With

        With Me
            .Controls.AddRange(New Control() {statusStripdgRemainOrders})
        End With

        'Load Auto filter column
        With showAllLabeldgOrderBook
            .Visible = False
            .IsLink = True
            .LinkBehavior = LinkBehavior.HoverUnderline
            .ForeColor = Color.White
            .BackColor = Color.Black
        End With

        With statusStripdgOrderBook
            .Cursor = Cursors.Default
            .Items.AddRange(New ToolStripItem() { _
                filterStatusLabeldgOrderBook, showAllLabeldgOrderBook})
        End With

        With Me
            .Controls.AddRange(New Control() {statusStripdgOrderBook})
        End With

    End Sub
#End Region

#Region " Object Event Processing "
    'Các hàm xử lý sự kiện sẽ tự động cập nhật màn hình trên cơ sở object truyền về
    Private Sub onChange_MKTBOD() Handles mv_objMKTBOD.onChange
        'Cập nhật thông tin đầu ngày
        'Không làm gì
    End Sub

    Private Sub onChange_MKTLOG() Handles mv_objMKTLOG.onChange
        'Cập nhật lại thông tin giao dịch tổng hợp của từng sàn:
        Dim v_strREFITEM, v_strOBJITEM, v_strREFKEY As String, v_dgData As DataGridView, v_color As Color
        Dim v_arrCache As Hashtable, v_objRef As BasedEvent, v_objRaise As objNotify, v_intRow, v_intIdx As Integer
        Dim v_dblMKTIDX, v_dblREFMKTIDX As Double
        v_objRaise = mv_objMKTLOG

        v_strREFITEM = lblExchangeName.Tag
        If v_strREFITEM.Length > 0 And Not mv_cacheMaster("MKTBOD") Is Nothing Then
            'Xác định thị trường
            v_strOBJITEM = v_objRaise.mv_objEvent.GetAttrValueByName("EXCHANGENAME")
            If String.Compare(v_strREFITEM, v_strOBJITEM) = 0 Then
                v_strREFKEY = FOFormatEventKey(v_objRaise.mv_objEvent)
                v_arrCache = mv_cacheMaster("MKTBOD")
                v_objRef = CType(v_arrCache(v_strREFKEY), BasedEvent)
                v_dblREFMKTIDX = v_objRef.GetAttrValueByName("MKTIDX")
                v_dblMKTIDX = v_objRaise.mv_objEvent.GetAttrValueByName("MKTIDX")

                'Hiển thị Index của thị trường
                With v_objRaise.mv_objEvent
                    If v_dblMKTIDX > v_dblREFMKTIDX Then
                        lblExchangeName.ForeColor = FormatGetColorBasedOnTheme("FG_UP_COLOR")
                        lblExchangeName.Text = .GetAttrValueByName("EXCHANGENAME") & " +" & (v_dblMKTIDX - v_dblREFMKTIDX) & " (+" & (v_dblMKTIDX - v_dblREFMKTIDX) / v_dblREFMKTIDX & ") " & v_dblMKTIDX
                    ElseIf v_dblMKTIDX < v_dblREFMKTIDX Then
                        lblExchangeName.ForeColor = FormatGetColorBasedOnTheme("FG_DOWN_COLOR")
                        lblExchangeName.Text = .GetAttrValueByName("EXCHANGENAME") & " -" & (v_dblREFMKTIDX - v_dblMKTIDX) & " (-" & (v_dblREFMKTIDX - v_dblMKTIDX) / v_dblREFMKTIDX & ") " & v_dblMKTIDX
                    Else
                        lblExchangeName.ForeColor = FormatGetColorBasedOnTheme("FG_EQUAL_COLOR")
                        lblExchangeName.Text = .GetAttrValueByName("EXCHANGENAME") & " +0 (+0%) " & v_dblMKTIDX
                    End If
                End With
            End If
        End If
    End Sub

    Private Sub onChange_SYMBOD() Handles mv_objSYMBOD.onChange
        'Cập nhật thông tin đầu ngày
        'Không làm gì
    End Sub

    Private Sub onChange_SYMDEEP() Handles mv_objSYMDEEP.onChange
        'Cập nhật thông tin khớp lệnh của chứng khoán
        Dim v_strREFITEM, v_strOBJITEM, v_strREFKEY As String, v_dgData As DataGridView, v_color As Color
        Dim v_arrCache As Hashtable, v_objRef As BasedEvent, v_objRaise As objNotify, v_intRow, v_intIdx As Integer
        v_dgData = dgSYMMKTDEEP
        v_objRaise = mv_objSYMDEEP

        v_strOBJITEM = mv_objSYMLOG.mv_objEvent.GetAttrValueByName("SYMBOL")
        v_strREFITEM = lblSYM.Text
        If String.Compare(v_strREFITEM, v_strOBJITEM) = 0 Then
            'Lấy giá tham chiếu của chứng khoán
            Dim v_dblRFPRICE, v_dblPRICE, v_dblBESTBID, v_dblBESTOFFER As Double
            If mv_cacheMaster("SYMBOD") Is Nothing Then
                'Lấy thông tin SYMBOD trên HOST
            End If
            v_arrCache = mv_cacheMaster("SYMBOD")
            v_strREFKEY = FOFormatEventKey(CType(mv_cacheMaster("SYMBOD"), BasedEvent))
            If v_arrCache(v_strREFKEY) Is Nothing Then
                v_objRef = CType(v_arrCache(v_strREFKEY), BasedEvent)
                v_dblRFPRICE = v_objRef.GetAttrValueByName("RFPRICE")
            End If

            'SYMMKTDEEP sẽ cập nhật lại các mức giá
            v_strREFKEY = FOFormatEventKey(v_objRaise.mv_objEvent)
            With v_objRaise.mv_objEvent
                'Cập nhật lại các mức chờ mua, chờ bán
                For v_intIdx = 0 To 2 Step 1
                    v_dblPRICE = .GetAttrValueByName("BIDPRICE" & (v_intIdx + 1))
                    If v_intIdx = 0 Then v_dblBESTBID = v_dblPRICE
                    If v_dblPRICE > 0 Then
                        v_color = FormatGetForeColorSymbol(v_dblPRICE, v_objRef)
                        v_dgData.Rows(v_intIdx).Cells("SYMBIDOFFER_BIDVOL").Style.ForeColor = v_color
                        v_dgData.Rows(v_intIdx).Cells("SYMBIDOFFER_BIDPRICE").Style.ForeColor = v_color
                        v_dgData.Rows(v_intIdx).Cells("SYMBIDOFFER_BIDVOL").Value = .GetAttrValueByName("BIDVOL1")
                        v_dgData.Rows(v_intIdx).Cells("SYMBIDOFFER_BIDPRICE").Value = v_dblPRICE
                    Else
                        v_dgData.Rows(v_intIdx).Cells("SYMBIDOFFER_BIDVOL").Value = String.Empty
                        v_dgData.Rows(v_intIdx).Cells("SYMBIDOFFER_BIDPRICE").Value = String.Empty
                    End If

                    v_dblPRICE = .GetAttrValueByName("ASKPRICE" & (v_intIdx + 1))
                    If v_intIdx = 0 Then v_dblBESTOFFER = v_dblPRICE
                    If v_dblPRICE > 0 Then
                        v_color = FormatGetForeColorSymbol(v_dblPRICE, v_objRef)
                        v_dgData.Rows(v_intIdx).Cells("SYMBIDOFFER_OFFERVOL").Style.ForeColor = v_color
                        v_dgData.Rows(v_intIdx).Cells("SYMBIDOFFER_OFFERPRICE").Style.ForeColor = v_color
                        v_dgData.Rows(v_intIdx).Cells("SYMBIDOFFER_OFFERVOL").Value = .GetAttrValueByName("BIDVOL1")
                        v_dgData.Rows(v_intIdx).Cells("SYMBIDOFFER_OFFERPRICE").Value = v_dblPRICE
                    Else
                        v_dgData.Rows(v_intIdx).Cells("SYMBIDOFFER_OFFERVOL").Value = String.Empty
                        v_dgData.Rows(v_intIdx).Cells("SYMBIDOFFER_OFFERPRICE").Value = String.Empty
                    End If
                Next
            End With

            'Cập nhật lại
            If v_dblBESTBID > 0 Then
                dgSYMBIDOFFER.Rows(0).Cells("SYMBIDOFFER_BID").Style.ForeColor = FormatGetForeColorSymbol(v_dblBESTBID, v_objRef)
                dgSYMBIDOFFER.Rows(0).Cells("SYMBIDOFFER_BID").Value = v_dblBESTBID
            Else
                dgSYMBIDOFFER.Rows(0).Cells("SYMBIDOFFER_BID").Value = String.Empty
            End If

            If v_dblBESTOFFER > 0 Then
                dgSYMBIDOFFER.Rows(0).Cells("SYMBIDOFFER_OFFER").Style.ForeColor = FormatGetForeColorSymbol(v_dblBESTOFFER, v_objRef)
                dgSYMBIDOFFER.Rows(0).Cells("SYMBIDOFFER_OFFER").Value = v_dblBESTOFFER
            Else
                dgSYMBIDOFFER.Rows(0).Cells("SYMBIDOFFER_OFFER").Value = String.Empty
            End If
        End If
    End Sub

    Private Sub onChange_SYMLOG() Handles mv_objSYMLOG.onChange
        'Cập nhật thông tin khớp lệnh của chứng khoán
        Dim v_strREFITEM, v_strOBJITEM, v_strREFKEY As String, v_dgData As DataGridView
        Dim v_arrCache As Hashtable, v_objRef As BasedEvent, v_objRaise As objNotify, v_intRow As Integer
        v_dgData = dgSYMTRADELOG
        v_objRaise = mv_objSYMLOG

        v_strOBJITEM = v_objRaise.mv_objEvent.GetAttrValueByName("SYMBOL")
        v_strREFITEM = lblSYM.Text
        If String.Compare(v_strREFITEM, v_strOBJITEM) = 0 Then
            'Lấy giá tham chiếu của chứng khoán
            Dim v_dblRFPRICE, v_dblPRICE As Double
            If mv_cacheMaster("SYMBOD") Is Nothing Then
                'Lấy thông tin SYMBOD trên HOST
            End If
            v_arrCache = mv_cacheMaster("SYMBOD")
            v_strREFKEY = FOFormatEventKey(CType(mv_cacheMaster("SYMBOD"), BasedEvent))
            If v_arrCache(v_strREFKEY) Is Nothing Then
                v_objRef = CType(v_arrCache(v_strREFKEY), BasedEvent)
                v_dblRFPRICE = v_objRef.GetAttrValueByName("RFPRICE")
            End If

            'TradeLog chỉ Add thêm bản ghi: LOGTIME|LOGVOL|LOGPRICE|LOGCHG
            v_strREFKEY = FOFormatEventKey(v_objRaise.mv_objEvent)
            With v_objRaise.mv_objEvent
                'Mỗi row đều giữ Tag là KEY của object để dễ định vị trên màn hình
                v_intRow = v_dgData.Rows.Add()
                v_dgData.Rows(v_intRow).Tag = v_strREFKEY
                'Định dạng màu sắc
                If String.Compare(.GetAttrValueByName("BORS"), "B") = 0 Then
                    v_dgData.Rows(v_intRow).DefaultCellStyle.BackColor = FormatGetColorBasedOnTheme("BG_BUYPOWER_COLOR")
                Else
                    v_dgData.Rows(v_intRow).DefaultCellStyle.BackColor = FormatGetColorBasedOnTheme("BG_SELLPOWER_COLOR")
                End If
                'Cập nhật màn hình
                v_dblPRICE = .GetAttrValueByName("PRICE")
                v_dgData.Rows(v_intRow).Cells("LOGTIME").Value = .GetAttrValueByName("TXTIME")
                v_dgData.Rows(v_intRow).Cells("LOGVOL").Value = .GetAttrValueByName("VOLUME")
                v_dgData.Rows(v_intRow).Cells("LOGPRICE").Value = .GetAttrValueByName("PRICE")
                v_dgData.Rows(v_intRow).Cells("LOGCHG").Value = (v_dblPRICE - v_dblRFPRICE).ToString
            End With

        End If
    End Sub

    Private Sub onChange_ACCUSER() Handles mv_objACCUSER.onChange
        'Cập nhật thông tin người sử dụng 

    End Sub

    Private Sub onChange_ACCINFO() Handles mv_objACCINFO.onChange
        'Cập nhật thông tin thay đổi của tiểu khoản

    End Sub

    Private Sub onChange_ACCCI() Handles mv_objACCCI.onChange
        'Cập nhật thông tin thay đổi số dư tiền

    End Sub

    Private Sub onChange_ACCSE() Handles mv_objACCSE.onChange
        'Cập nhật thông tin thay đổi số dư chứng khoán

    End Sub

    Private Sub onChange_ACCOD() Handles mv_objACCOD.onChange
        'Cập nhật số lệnh

    End Sub

#End Region

#Region " New FO Improve"
    'Hàm khởi tạo kết nối đến máy chủ
    Private Sub FOInitPublicSharing()
        Try
            'Kết nối tới máy chủ và khởi tạo bộ Cache Share

            'Thiết lập các object xử lý Event
        Catch ex As Exception

        Finally

        End Try
    End Sub

    Private Sub FOPushEvent2SQLite(ByVal v_objEvent As BasedEvent, ByVal v_strNewOrChange As String)
        'v_strNewOrChange=N. Tạo mới, v_strNewOrChange=C. Cập nhật
    End Sub

    Private Function FOGetReturnMarketNumericValue(ByVal v_objValue As Object, Optional ByVal v_Decimal As Integer = 0) As String
        If v_objValue Is Nothing Then
            Return String.Empty
        Else
            If Not IsNumeric(v_objValue) Then
                Return String.Empty
            Else
                If v_Decimal = 2 Then
                    Return Format(CDbl(v_objValue), gc_FORMAT_NUMBER_2)
                Else
                    Return Format(CDbl(v_objValue), gc_FORMAT_NUMBER_0)
                End If
            End If
        End If
    End Function

    Private Function FOFormatEventKey(ByVal v_objEvent As BasedEvent) As String
        Dim v_strReturn As String = String.Empty
        With v_objEvent
            Select Case .OBJNAME
                Case "MKTBOD"
                    v_strReturn = .GetAttrValueByName("CURRDATE") & c_DelimiterChar & .GetAttrValueByName("EXCHANGENAME")
                Case "MKTLOG"
                    v_strReturn = .GetAttrValueByName("CURRDATE") & c_DelimiterChar & .GetAttrValueByName("EXCHANGENAME") & c_DelimiterChar & .GetAttrValueByName("TXTIME")
                Case "SYMBOD"
                    v_strReturn = .GetAttrValueByName("CURRDATE") & c_DelimiterChar & .GetAttrValueByName("SYMBOL")
                Case "SYMDEEP"
                    v_strReturn = .GetAttrValueByName("CURRDATE") & c_DelimiterChar & .GetAttrValueByName("SYMBOL") & c_DelimiterChar & .GetAttrValueByName("TXTIME")
                Case "SYMLOG"
                    v_strReturn = .GetAttrValueByName("CURRDATE") & c_DelimiterChar & .GetAttrValueByName("SYMBOL") & c_DelimiterChar & .GetAttrValueByName("TXTIME")
                Case "ACCUSER"
                    v_strReturn = .GetAttrValueByName("USRTYP") & c_DelimiterChar & .GetAttrValueByName("USRID")
                Case "ACCINFO"
                    v_strReturn = .GetAttrValueByName("AFACCTNO")
                Case "ACCCI"
                    v_strReturn = .GetAttrValueByName("AFACCTNO")
                Case "ACCSE"
                    v_strReturn = .GetAttrValueByName("AFACCTNO") & c_DelimiterChar & .GetAttrValueByName("SYMBOL")
                Case "ACCOD"
                    v_strReturn = .GetAttrValueByName("AFACCTNO") & c_DelimiterChar & .GetAttrValueByName("ORGORDERID")
            End Select
        End With
        Return v_strReturn
    End Function

    Private Sub FOProcessNotifyEvent(ByRef v_objEvent As BasedEvent)
        'Nhận Object thay đổi thông tin cập nhật lại cho các Control. Object này được Parse từ FIXMessage
        Dim v_strCUSTODYCD, v_strAFACCTNO, v_strSYMBOL, v_strOBJKEY As String, v_blnFlag As Boolean, v_arrData As Hashtable

        v_strOBJKEY = FOFormatEventKey(v_objEvent)
        v_strSYMBOL = Me.lblSYM.Text            'Mã chứng khoán hiện tại
        If cboAFAcctno.Items.Count > 0 Then     'Số tiểu khoản & số lưu ký hiện tại
            v_strAFACCTNO = mv_arrAccountNumber(cboAFAcctno.SelectedIndex)
            v_strCUSTODYCD = mv_arrCustodyCode(cboAFAcctno.SelectedIndex)
        End If

        'Kiểm tra Object đã được Cache chưa
        v_blnFlag = False
        If mv_cacheMaster Is Nothing Then
            If Not mv_cacheMaster(v_objEvent.OBJNAME) Is Nothing Then
                v_blnFlag = True
            End If
        End If

        If Not v_blnFlag Then
            v_objEvent.NewOrChange = "N"
            'Đưa object event vào cache
            v_arrData = New Hashtable
            v_arrData.Add(v_strOBJKEY, v_objEvent)
            mv_cacheMaster.Add(v_objEvent.OBJNAME, v_arrData)

        Else
            'Tìm xem object event đã có trong Cache chưa
            v_arrData = CType(mv_cacheMaster(v_objEvent.OBJNAME), Hashtable)
            If Not v_arrData(v_strOBJKEY) Is Nothing Then
                v_objEvent.NewOrChange = "C"
                'Cập nhật lại Cache
                v_arrData(v_strOBJKEY) = v_objEvent
            Else
                v_objEvent.NewOrChange = "N"
                'Khởi tạo Cache mới
                v_arrData.Add(v_strOBJKEY, v_objEvent)
            End If
        End If
        'Đưa ra SQLite để sử dụng lại
        FOPushEvent2SQLite(v_objEvent, v_objEvent.NewOrChange)

        'Notify đến các control tương thông qua sự kiện onChange của object
        Select Case v_objEvent.OBJNAME
            Case "MKTBOD"   'Thông tin thị trường đầu ngày
                mv_objMKTBOD.SetData(v_objEvent)
            Case "MKTLOG"   'Thông tin biến động thị trường trong ngày
                mv_objMKTLOG.SetData(v_objEvent)
            Case "SYMBOD"   'Thông tin về chứng khoán đầu ngày
                mv_objSYMBOD.SetData(v_objEvent)
            Case "SYMDEEP"  'Thông tin về chứng khoán tại thời điểm hiện tại
                mv_objSYMDEEP.SetData(v_objEvent)
            Case "SYMLOG"   'Thông tin về tradelog của chứng khoán
                mv_objSYMLOG.SetData(v_objEvent)
            Case "ACCUSER"  'Thông tin về người dùng đang sử dụng
                mv_objACCUSER.SetData(v_objEvent)
            Case "ACCINFO"  'Thông tin chung về tài khoản
                mv_objACCINFO.SetData(v_objEvent)
            Case "ACCCI"    'Thông tin về Cash
                mv_objACCCI.SetData(v_objEvent)
            Case "ACCSE"    'Thông tin về SE
                mv_objACCSE.SetData(v_objEvent)
            Case "ACCOD"    'Thông tin về sổ lệnh
                mv_objACCOD.SetData(v_objEvent)
        End Select
    End Sub

    Private Function GetRowColIndex(ByVal v_dgData As DataGridView, ByVal v_strFIELDNAME As String, ByVal v_strRowOrCol As String) As Integer
        Dim v_intIdx, v_intReturn As Integer
        'Trả về vị trí hàng cột chứa 
        v_intReturn = -1    'Mặc định là ko tìm được
        If String.Compare(v_strRowOrCol, "COL") = 0 Then
            'ColumnIndex
            If v_dgData.Columns.Contains(v_strFIELDNAME) = True Then
                v_intReturn = v_dgData.Columns(v_strFIELDNAME).Index
            End If
        ElseIf String.Compare(v_strRowOrCol, "ROW") = 0 Then
            'RowIndex: Column đầu tiên chứa tên trường
            If v_dgData.Rows.Count > 0 Then
                For v_intIdx = 0 To v_dgData.Rows.Count - 1 Step 1
                    If Not v_dgData.Rows(v_intIdx).Tag Is Nothing Then
                        If String.Compare(v_strFIELDNAME, v_dgData.Rows(v_intIdx).Tag.ToString) = 0 Then
                            v_intReturn = v_intIdx
                        End If
                    End If
                Next
            End If
        End If
        Return v_intReturn
    End Function

    Private Sub FormatDataGridView()
        'Thiết lập các Grid
        BindData2DataGridView("PURCHASINGPOWER|AVLLIMIT|CASH_ON_HAND|ORDERAMT|OUTSTANDING|ADVANCEDLINE|AVLADVANCED|PAIDAMT|MRCRLIMITMAX|CASH_RECEIVING_T0|CASH_RECEIVING_T1|CASH_RECEIVING_T2|CASH_RECEIVING_TN|CASH_SENDING_T0|CASH_SENDING_T1|CASH_SENDING_T2|CASH_SENDING_T3|CASH_SENDING_TN|TOTALDEB|ADVANCED_BALANCE|BALDEFOVD|DEALPAIDAMT", Me.dgCash, "H")
        dgCash.ColumnHeadersVisible = False
        BindData2DataGridView("SYMBOL|TRADE_QTTY|MORTGAGE_QTTY", Me.dgStocks, "H")
        AddHandler dgStocks.CellDoubleClick, AddressOf dgPosition_CellDoubleClick
        'Sổ lệnh hiện tại
        'Cho lệnh ShortSale và BuyToCover
        'BindData2DataGridView("SSAFACCTNO|PRICETYPE|DESC_EXECTYPE|SYMBOL|ORSTATUS|QUOTEPRICE|ORDERQTTY|REMAINQTTY|EXECQTTY|EXECAMT|CANCELQTTY|ADJUSTQTTY|AFACCTNO|CUSTODYCD|FEEDBACKMSG|EXECTYPE|CODEID|BRATIO|ORDERID|REFORDERID|TXDATE|TXTIME|SDTIME", Me.dgOrderBook, "H")
        'Lệnh thường
        'BindData2DataGridView("PRICETYPE|DESC_EXECTYPE|SYMBOL|ORSTATUS|QUOTEPRICE|ORDERQTTY|REMAINQTTY|EXECQTTY|EXECAMT|CANCELQTTY|ADJUSTQTTY|AFACCTNO|CUSTODYCD|FEEDBACKMSG|EXECTYPE|CODEID|BRATIO|ORDERID|REFORDERID|TXDATE|TXTIME|SDTIME", Me.dgOrderBook, "H")
        BindData2DataGridViewUsingDataTable("PRICETYPE|DESC_EXECTYPE|SYMBOL|ORSTATUS|QUOTEPRICE|ORDERQTTY|REMAINQTTY|EXECQTTY|EXECAMT|CANCELQTTY|ADJUSTQTTY|AFACCTNO|CUSTODYCD|FEEDBACKMSG|EXECTYPE|CODEID|BRATIO|ORDERID|REFORDERID|TXDATE|TXTIME|SDTIME|TLNAME|CTCI_ORDER", Me.dgOrderBook, "H")
        dgOrderBook.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        AddHandler dgOrderBook.KeyUp, AddressOf dgData_KeyUp
        'AddHandler dgRemainOrder.SelectionChanged, AddressOf dgData_MultiSelectChanged
        AddHandler dgOrderBook.CellMouseClick, AddressOf dgData_CellClick
        'Lệnh chờ khớp
        BindData2DataGridViewUsingDataTable("PRICETYPE|DESC_EXECTYPE|SYMBOL|ORSTATUS|CANCELSTATUS|QUOTEPRICE|ORDERQTTY|REMAINQTTY|EXECQTTY|EXECAMT|CANCELQTTY|ADJUSTQTTY|AFACCTNO|CUSTODYCD|FEEDBACKMSG|EXECTYPE|CODEID|BRATIO|ORDERID|REFORDERID|TXDATE|TXTIME", Me.dgRemainOrder, "H")
        dgRemainOrder.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgRemainOrder.DefaultCellStyle.SelectionBackColor = Color.Azure
        AddHandler dgRemainOrder.KeyUp, AddressOf dgData_KeyUp
        'AddHandler dgRemainOrder.SelectionChanged, AddressOf dgData_MultiSelectChanged
        AddHandler dgRemainOrder.CellMouseClick, AddressOf dgData_CellClick

        'Số dư chứng khoán đầy đủ
        BindData2DataGridView("SUBACCTNO|SYMBOL|TOTAL_QTTY|TRADE_QTTY|DEALFINANCING_QTTY|ORDERQTTY_NORMAL|ORDERQTTY_BLOCKED|ORDERQTTY_BUY|MORTGAGE_QTTY|NETTING_QTTY|BLOCKED_QTTY|SECURITIES_RECEIVING_T0|SECURITIES_RECEIVING_T1|SECURITIES_RECEIVING_T2|SECURITIES_RECEIVING_T3|SECURITIES_RECEIVING_TN|SECURITIES_SENDING_T0|SECURITIES_SENDING_T1|SECURITIES_SENDING_T2|SECURITIES_SENDING_T3|SECURITIES_SENDING_TN", Me.dgSecurities, "H")
        AddHandler dgSecurities.CellDoubleClick, AddressOf dgPosition_CellDoubleClick
        'Thông tin khớp lệnh trong ngày
        'BindData2DataGridView("ORDERID|SYMBOL|PRICE|QTTY|MATCHAMT|CONFIRM_NO|BORS_DESC|BORS|AFACCTNO", Me.dgTrades, "H")
        BindData2DataGridViewUsingDataTable("ORDERID|SYMBOL|PRICE|QTTY|MATCHAMT|CONFIRM_NO|BORS_DESC|BORS|AFACCTNO", Me.dgTrades, "H")
        'Thông tin dư nợ
        BindData2DataGridView("SYMBOL|DFTYP|FEEAMT|INDUEAMT|OVERDUEAMT|DFQTTY|DFTRADE|RLSDATE|DUEDATE|DFPRICE|TRIGGERPRICE|DESCRIPTION|DFACCTNO", Me.dgLoan, "H")
        AddHandler dgLoan.CellDoubleClick, AddressOf dgDealFinancing_CellDoubleClick
        'Tổng tài sản
        BindData2DataGridView("ITEM|SUBACCTNO|SUBACNAME|COSTPRICE|VAL|AMT|PROFITANDLOSS", Me.dgAssets, "H")

        'Thông tin tổng hợp chứng khoán
        BindData2DataGridView("CURRPRICE|CHGBYVALUE|CHGBYRATIO|CEPRICE|FLPRICE|RFPRICE|HIPRICE|LOPRICE|AVGPRICE|CASHMAP|TOTALVOL|TOTALAMT|TOTALTRADES|FROOM|FBUYVOL|FSELLVOL|FBUYAMT|FSELLAMT", Me.dgSYMINFO, "H")
        'MarketDeep của chứng khoán
        BindData2DataGridView("SYMBIDOFFER_BID|SYMBIDOFFER_OFFER", Me.dgSYMBIDOFFER, "H")
        BindData2DataGridView("SYMBIDOFFER_BIDVOL|SYMBIDOFFER_BIDPRICE|SYMBIDOFFER_OFFERPRICE|SYMBIDOFFER_OFFERVOL", Me.dgSYMMKTDEEP, "H")
        'TradeLog của chứng khoán
        BindData2DataGridView("LOGTIME|LOGVOL|LOGPRICE|LOGCHG", Me.dgSYMTRADELOG, "H")
    End Sub

    'Trả về màu hiện thị theo giá và đối tượng truyền vào
    Private Function FormatGetForeColorSymbol(ByVal v_dblPrice As Double, ByVal v_objSYMBOD As BasedEvent) As Color
        If v_dblPrice = CDbl(v_objSYMBOD.GetAttrValueByName("CEPRICE")) Then
            Return FormatGetColorBasedOnTheme("FG_CE_COLOR")
        ElseIf v_dblPrice = CDbl(v_objSYMBOD.GetAttrValueByName("FLPRICE")) Then
            Return FormatGetColorBasedOnTheme("FG_FL_COLOR")
        ElseIf v_dblPrice = CDbl(v_objSYMBOD.GetAttrValueByName("RFPRICE")) Then
            Return FormatGetColorBasedOnTheme("FG_RF_COLOR")
        ElseIf v_dblPrice > CDbl(v_objSYMBOD.GetAttrValueByName("RFPRICE")) And v_dblPrice < CDbl(v_objSYMBOD.GetAttrValueByName("CEPRICE")) Then
            Return FormatGetColorBasedOnTheme("FG_UP_COLOR")
        ElseIf v_dblPrice < CDbl(v_objSYMBOD.GetAttrValueByName("RFPRICE")) And v_dblPrice > CDbl(v_objSYMBOD.GetAttrValueByName("FLPRICE")) Then
            Return FormatGetColorBasedOnTheme("FG_DOWN_COLOR")
        Else
            Return FormatGetColorBasedOnTheme("FG_NML_COLOR")
        End If
    End Function

    Private Function FormatGetForeColorSymbol(ByVal v_dblValue As Double) As Color
        Dim v_ForeColor As Color
        If v_dblValue = CDbl(mv_arrHasTableCurrentStockInfor("CEPRICE")) Then
            v_ForeColor = FormatGetColorBasedOnTheme("FG_CE_COLOR")
        ElseIf v_dblValue = CDbl(mv_arrHasTableCurrentStockInfor("FLPRICE")) Then
            v_ForeColor = FormatGetColorBasedOnTheme("FG_FL_COLOR")
        ElseIf v_dblValue = CDbl(mv_arrHasTableCurrentStockInfor("RFPRICE")) Then
            v_ForeColor = FormatGetColorBasedOnTheme("FG_RF_COLOR")
        ElseIf v_dblValue > CDbl(mv_arrHasTableCurrentStockInfor("RFPRICE")) And v_dblValue < CDbl(mv_arrHasTableCurrentStockInfor("CEPRICE")) Then
            v_ForeColor = FormatGetColorBasedOnTheme("FG_UP_COLOR")
        ElseIf v_dblValue < CDbl(mv_arrHasTableCurrentStockInfor("RFPRICE")) And v_dblValue > CDbl(mv_arrHasTableCurrentStockInfor("FLPRICE")) Then
            v_ForeColor = FormatGetColorBasedOnTheme("FG_DOWN_COLOR")
        Else
            v_ForeColor = FormatGetColorBasedOnTheme("FG_NML_COLOR")
        End If
        Return v_ForeColor
    End Function

    'Trả về fontstyle hiển thị
    Private Function FormatGetColorBasedOnTheme(ByVal v_strStyleColorName As String, Optional ByVal v_strThemeName As String = "DEFAULT") As Color
        Dim v_retColor As Color
        If String.Compare(v_strThemeName, "DEFAULT") = 0 Then
            Select Case v_strStyleColorName
                Case "BG_NML_COLOR"
                    v_retColor = Color.Black
                Case "BG_CHG_COLOR"
                    v_retColor = Color.Gray
                Case "BG_BID_COLOR"
                    v_retColor = Color.LightBlue
                Case "BG_OFFER_COLOR"
                    v_retColor = Color.LightCoral
                Case "BG_BUY_COLOR"
                    v_retColor = Color.Lime
                Case "BG_SELL_COLOR"
                    v_retColor = Color.Red
                Case "BG_NB_COLOR"
                    v_retColor = Color.LightBlue
                Case "BG_NS_COLOR"
                    v_retColor = Color.LightCoral
                Case "BG_MS_COLOR"
                    v_retColor = Color.Lime
                Case "BG_BUYPOWER_COLOR"
                    v_retColor = Color.Lime
                Case "BG_SELLPOWER_COLOR"
                    v_retColor = Color.Red
                Case "FG_NML_COLOR"
                    v_retColor = Color.White
                Case "FG_CE_COLOR"
                    v_retColor = Color.Violet
                Case "FG_FL_COLOR"
                    v_retColor = Color.LightSteelBlue
                Case "FG_RF_COLOR"
                    v_retColor = Color.Yellow
                Case "FG_UP_COLOR"
                    v_retColor = Color.Lime
                Case "FG_DOWN_COLOR"
                    v_retColor = Color.Red
                Case "FG_EQUAL_COLOR"
                    v_retColor = Color.Red
                Case "FG_GRANTTOTAL_COLOR"
                    v_retColor = Color.Red
                Case "FG_SUBTOTAL_COLOR"
                    v_retColor = Color.Yellow
            End Select
        End If
        Return v_retColor
    End Function

    Private Sub FormatStyleForDataGridView(ByRef v_dgData As DataGridView)
        With v_dgData.ColumnHeadersDefaultCellStyle
            .Alignment = DataGridViewContentAlignment.MiddleCenter
            .BackColor = FormatGetColorBasedOnTheme("BG_NML_COLOR")
            .ForeColor = FormatGetColorBasedOnTheme("FG_NML_COLOR")
            .Font = New Font(.Font.FontFamily, .Font.Size, .Font.Style Or FontStyle.Bold, GraphicsUnit.Point)
        End With

        With v_dgData
            If String.Compare(v_dgData.Name, "dgCash") = 0 _
                Or String.Compare(v_dgData.Name, "dgSYMINFO") = 0 Then
                .ColumnHeadersVisible = False
                .ScrollBars = ScrollBars.Both
            ElseIf String.Compare(v_dgData.Name, "dgSYMBIDOFFER") = 0 _
                            Or String.Compare(v_dgData.Name, "dgSYMMKTDEEP") = 0 Then
            Else
                .ScrollBars = ScrollBars.Both
                .ColumnHeadersVisible = True
            End If

            .EditMode = DataGridViewEditMode.EditProgrammatically
            .RowHeadersVisible = False
            .Dock = DockStyle.Fill
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .RowsDefaultCellStyle.BackColor = FormatGetColorBasedOnTheme("BG_NML_COLOR")
            .RowsDefaultCellStyle.SelectionBackColor = FormatGetColorBasedOnTheme("BG_NML_COLOR")
            .BackgroundColor = FormatGetColorBasedOnTheme("BG_NML_COLOR")
            .BackColor = FormatGetColorBasedOnTheme("BG_NML_COLOR")
            .ForeColor = FormatGetColorBasedOnTheme("FG_NML_COLOR")
            .AllowUserToDeleteRows = False
            .AllowUserToResizeRows = False
            .MultiSelect = False
        End With

        AddHandler v_dgData.MouseUp, AddressOf dgData_MouseUp
    End Sub

    Private Sub FormatColumnForDataGridView(ByVal v_strGridName As String, ByRef v_dgvCol As DataGridViewColumn)
        Dim v_strFieldName As String = v_dgvCol.Name

        If String.Compare(v_strGridName, "dgCash") = 0 _
            Or String.Compare(v_strGridName, "dgSYMINFO") = 0 Then
            'If String.Compare(v_strFieldName, "FieldName") = 0 Then
            '    v_dgvCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            'Else
            '    v_dgvCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'End If

        ElseIf String.Compare(v_strGridName, "dgStocks") = 0 Then
            If String.Compare(v_strFieldName, "SYMBOL") = 0 Then
                v_dgvCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                v_dgvCol.Frozen = True
            Else
                v_dgvCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If

        ElseIf String.Compare(v_strGridName, "dgSecurities") = 0 Then
            If String.Compare(v_strFieldName, "SYMBOL") = 0 Or String.Compare(v_strFieldName, "SUBACCTNO") = 0 Then
                v_dgvCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                v_dgvCol.Frozen = True
            Else
                v_dgvCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If

        ElseIf String.Compare(v_strGridName, "dgOrderBook") = 0 Then
            If String.Compare(v_strFieldName, "SYMBOL") = 0 _
                Or String.Compare(v_strFieldName, "ORSTATUS") = 0 _
                Or String.Compare(v_strFieldName, "DESC_EXECTYPE") = 0 Then
                v_dgvCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                v_dgvCol.Frozen = True
            ElseIf String.Compare(v_strFieldName, "PRICETYPE") = 0 _
                Or String.Compare(v_strFieldName, "ORDERID") = 0 _
                Or String.Compare(v_strFieldName, "TRADEPLACE") = 0 _
                Or String.Compare(v_strFieldName, "AFACCTNO") = 0 _
                Or String.Compare(v_strFieldName, "FEEDBACKMSG") = 0 _
                Or String.Compare(v_strFieldName, "CANCELSTATUS") = 0 _
                Or String.Compare(v_strFieldName, "TXTIME") = 0 _
                Or String.Compare(v_strFieldName, "SDTIME") = 0 _
                Or String.Compare(v_strFieldName, "TLNAME") = 0 _
                Or String.Compare(v_strFieldName, "CTCI_ORDER") = 0 _
                Or String.Compare(v_strFieldName, "SSAFACCTNO") = 0 _
                Or String.Compare(v_strFieldName, "CUSTODYCD") = 0 Then
                v_dgvCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            ElseIf String.Compare(v_strFieldName, "EXECTYPE") = 0 _
                Or String.Compare(v_strFieldName, "BRATIO") = 0 _
                Or String.Compare(v_strFieldName, "REFORDERID") = 0 _
                Or String.Compare(v_strFieldName, "TXDATE") = 0 _
                Or String.Compare(v_strFieldName, "CODEID") = 0 Then
                v_dgvCol.Visible = False
            Else
                v_dgvCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If

        ElseIf String.Compare(v_strGridName, "dgTrades") = 0 Then
            If String.Compare(v_strFieldName, "SYMBOL") = 0 _
                Or String.Compare(v_strFieldName, "ORDERID") = 0 _
                Or String.Compare(v_strFieldName, "CONFIRM_NO") = 0 _
                Or String.Compare(v_strFieldName, "BORS_DESC") = 0 Then
                v_dgvCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            ElseIf String.Compare(v_strFieldName, "AFACCTNO") = 0 _
                Or String.Compare(v_strFieldName, "BORS") = 0 Then
                v_dgvCol.Visible = False
            Else
                v_dgvCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If

        ElseIf String.Compare(v_strGridName, "dgLoan") = 0 Then
            If String.Compare(v_strFieldName, "SYMBOL") = 0 Then
                v_dgvCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                v_dgvCol.Frozen = True
            ElseIf String.Compare(v_strFieldName, "AFACCTNO") = 0 Then
                v_dgvCol.Visible = False
            ElseIf String.Compare(v_strFieldName, "DESCRIPTION") = 0 _
                Or String.Compare(v_strFieldName, "DFACCTNO") = 0 _
                Or String.Compare(v_strFieldName, "DFTYP") = 0 Then
                v_dgvCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            ElseIf String.Compare(v_strFieldName, "RLSDATE") = 0 _
                Or String.Compare(v_strFieldName, "DUEDATE") = 0 Then
                v_dgvCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Else
                v_dgvCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If

        ElseIf String.Compare(v_strGridName, "dgAssets") = 0 Then
            If String.Compare(v_strFieldName, "ITEM") = 0 _
                Or String.Compare(v_strFieldName, "SUBACCTNO") = 0 _
                Or String.Compare(v_strFieldName, "SUBACNAME") = 0 Then
                v_dgvCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            Else
                v_dgvCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If

        ElseIf String.Compare(v_strGridName, "dgRemainOrder") = 0 Then
            If String.Compare(v_strFieldName, "SYMBOL") = 0 _
                Or String.Compare(v_strFieldName, "ORSTATUS") = 0 _
                Or String.Compare(v_strFieldName, "DESC_EXECTYPE") = 0 Then
                v_dgvCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                v_dgvCol.Frozen = True
            ElseIf String.Compare(v_strFieldName, "PRICETYPE") = 0 _
                Or String.Compare(v_strFieldName, "ORDERID") = 0 _
                Or String.Compare(v_strFieldName, "TRADEPLACE") = 0 _
                Or String.Compare(v_strFieldName, "AFACCTNO") = 0 _
                Or String.Compare(v_strFieldName, "FEEDBACKMSG") = 0 _
                Or String.Compare(v_strFieldName, "CANCELSTATUS") = 0 _
                Or String.Compare(v_strFieldName, "CUSTODYCD") = 0 Then
                v_dgvCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            ElseIf String.Compare(v_strFieldName, "EXECTYPE") = 0 _
                Or String.Compare(v_strFieldName, "BRATIO") = 0 _
                Or String.Compare(v_strFieldName, "REFORDERID") = 0 _
                Or String.Compare(v_strFieldName, "TXDATE") = 0 _
                Or String.Compare(v_strFieldName, "TXTIME") = 0 _
                Or String.Compare(v_strFieldName, "CODEID") = 0 Then
                v_dgvCol.Visible = False
            Else
                v_dgvCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If

        ElseIf String.Compare(v_strGridName, "dgSYMBIDOFFER") = 0 Then
            v_dgvCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            v_dgvCol.DefaultCellStyle.Font = New Font(Me.Font.FontFamily, 12, Me.Font.Style, GraphicsUnit.Point)
            If v_dgvCol.Index = 0 Then
                v_dgvCol.HeaderCell.Style.BackColor = FormatGetColorBasedOnTheme("BG_BUY_COLOR")
            ElseIf v_dgvCol.Index = 1 Then
                v_dgvCol.HeaderCell.Style.BackColor = FormatGetColorBasedOnTheme("BG_SELL_COLOR")
            End If
            v_dgvCol.HeaderCell.Style.Font = New Font(Me.Font.FontFamily, 12, Me.Font.Style Or FontStyle.Bold, GraphicsUnit.Point)

        ElseIf String.Compare(v_strGridName, "dgSYMMKTDEEP") = 0 Then
            v_dgvCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            v_dgvCol.DefaultCellStyle.Font = New Font(Me.Font.FontFamily, Me.Font.Size, Me.Font.Style, GraphicsUnit.Point)
            If v_dgvCol.Index = 0 Or v_dgvCol.Index = 1 Then
                v_dgvCol.HeaderCell.Style.BackColor = FormatGetColorBasedOnTheme("BG_BUY_COLOR")
            ElseIf v_dgvCol.Index = 2 Or v_dgvCol.Index = 3 Then
                v_dgvCol.HeaderCell.Style.BackColor = FormatGetColorBasedOnTheme("BG_SELL_COLOR")
            End If
            v_dgvCol.HeaderCell.Style.Font = New Font(Me.Font.FontFamily, Me.Font.Size, Me.Font.Style Or FontStyle.Bold, GraphicsUnit.Point)
        End If

    End Sub

    Private Function FormatFieldValueForDataGridView(ByVal v_strGridName As String, ByVal v_strFieldName As String, ByVal v_strFieldValue As String) As String
        Dim v_strReturn As String = v_strFieldValue

        'Định dạng các dữ liệu của Grid
        If String.Compare(v_strGridName, "dgCash") = 0 Then

        ElseIf String.Compare(v_strGridName, "dgStocks") = 0 Then
            If String.Compare(v_strFieldName, "SYMBOL") = 0 Then
                v_strReturn = v_strFieldValue
            Else
                If IsNumeric(v_strFieldValue) Then
                    v_strReturn = FormatNumber(CDbl(v_strFieldValue), 0)
                Else
                    v_strReturn = "0"
                End If
            End If

        ElseIf String.Compare(v_strGridName, "dgSecurities") = 0 Then
            If String.Compare(v_strFieldName, "SYMBOL") = 0 Or String.Compare(v_strFieldName, "SUBACCTNO") = 0 Then
                v_strReturn = v_strFieldValue
            Else
                If IsNumeric(v_strFieldValue) Then
                    v_strReturn = FormatNumber(CDbl(v_strFieldValue), 0)
                Else
                    v_strReturn = "0"
                End If
            End If

        ElseIf String.Compare(v_strGridName, "dgOrderBook") = 0 Then
            If String.Compare(v_strFieldName, "SYMBOL") = 0 _
                Or String.Compare(v_strFieldName, "ORDERID") = 0 _
                Or String.Compare(v_strFieldName, "PRICETYPE") = 0 _
                Or String.Compare(v_strFieldName, "DESC_EXECTYPE") = 0 _
                Or String.Compare(v_strFieldName, "EXECTYPE") = 0 _
                Or String.Compare(v_strFieldName, "CODEID") = 0 _
                Or String.Compare(v_strFieldName, "ORSTATUS") = 0 _
                Or String.Compare(v_strFieldName, "CANCELSTATUS") = 0 _
                Or String.Compare(v_strFieldName, "TRADEPLACE") = 0 _
                Or String.Compare(v_strFieldName, "AFACCTNO") = 0 _
                Or String.Compare(v_strFieldName, "FEEDBACKMSG") = 0 _
                Or String.Compare(v_strFieldName, "TXTIME") = 0 _
                Or String.Compare(v_strFieldName, "SDTIME") = 0 _
                Or String.Compare(v_strFieldName, "TLNAME") = 0 _
                Or String.Compare(v_strFieldName, "CTCI_ORDER") = 0 _
                Or String.Compare(v_strFieldName, "SSAFACCTNO") = 0 _
                Or String.Compare(v_strFieldName, "CUSTODYCD") = 0 Then
                v_strReturn = v_strFieldValue
            ElseIf String.Compare(v_strFieldName, "QUOTEPRICE") = 0 Then
                If IsNumeric(v_strFieldValue) Then
                    v_strReturn = FormatNumber(CDbl(v_strFieldValue), 2)
                Else
                    v_strReturn = "0"
                End If
            Else
                If IsNumeric(v_strFieldValue) Then
                    v_strReturn = FormatNumber(CDbl(v_strFieldValue), 0)
                Else
                    v_strReturn = "0"
                End If
            End If

        ElseIf String.Compare(v_strGridName, "dgTrades") = 0 Then
            If String.Compare(v_strFieldName, "SYMBOL") = 0 _
                Or String.Compare(v_strFieldName, "ORDERID") = 0 _
                Or String.Compare(v_strFieldName, "CONFIRM_NO") = 0 _
                Or String.Compare(v_strFieldName, "BORS") = 0 _
                Or String.Compare(v_strFieldName, "AFACCTNO") = 0 _
                Or String.Compare(v_strFieldName, "BORS_DESC") = 0 Then
                v_strReturn = v_strFieldValue
            Else
                v_strReturn = FormatNumber(CDbl(v_strFieldValue), 0)
            End If

        ElseIf String.Compare(v_strGridName, "dgLoan") = 0 Then
            If String.Compare(v_strFieldName, "SYMBOL") = 0 _
                Or String.Compare(v_strFieldName, "DFTYP") = 0 _
                Or String.Compare(v_strFieldName, "DFACCTNO") = 0 _
                Or String.Compare(v_strFieldName, "RLSDATE") = 0 _
                Or String.Compare(v_strFieldName, "DUEDATE") = 0 _
                Or String.Compare(v_strFieldName, "DESCRIPTION") = 0 Then
                v_strReturn = v_strFieldValue
            Else
                If IsNumeric(v_strFieldValue) Then
                    v_strReturn = FormatNumber(CDbl(v_strFieldValue), 0)
                Else
                    v_strReturn = "0"
                End If
            End If

        ElseIf String.Compare(v_strGridName, "dgAssets") = 0 Then
            If String.Compare(v_strFieldName, "ITEM") = 0 _
                Or String.Compare(v_strFieldName, "SUBACCTNO") = 0 _
                Or String.Compare(v_strFieldName, "SUBACNAME") = 0 Then
                v_strReturn = v_strFieldValue
            Else
                If IsNumeric(v_strFieldValue) Then
                    v_strReturn = FormatNumber(CDbl(v_strFieldValue), 0)
                Else
                    v_strReturn = "0"
                End If
            End If

        ElseIf String.Compare(v_strGridName, "dgRemainOrder") = 0 Then
            If String.Compare(v_strFieldName, "SYMBOL") = 0 _
                Or String.Compare(v_strFieldName, "ORDERID") = 0 _
                Or String.Compare(v_strFieldName, "PRICETYPE") = 0 _
                Or String.Compare(v_strFieldName, "DESC_EXECTYPE") = 0 _
                Or String.Compare(v_strFieldName, "EXECTYPE") = 0 _
                Or String.Compare(v_strFieldName, "CODEID") = 0 _
                Or String.Compare(v_strFieldName, "ORSTATUS") = 0 _
                Or String.Compare(v_strFieldName, "TRADEPLACE") = 0 _
                Or String.Compare(v_strFieldName, "AFACCTNO") = 0 _
                Or String.Compare(v_strFieldName, "FEEDBACKMSG") = 0 _
                Or String.Compare(v_strFieldName, "CANCELSTATUS") = 0 _
                Or String.Compare(v_strFieldName, "CUSTODYCD") = 0 Then
                v_strReturn = v_strFieldValue
            ElseIf String.Compare(v_strFieldName, "QUOTEPRICE") = 0 Then
                If IsNumeric(v_strFieldValue) Then
                    v_strReturn = FormatNumber(CDbl(v_strFieldValue), 2)
                Else
                    v_strReturn = "0"
                End If
            Else
                If IsNumeric(v_strFieldValue) Then
                    v_strReturn = FormatNumber(CDbl(v_strFieldValue), 0)
                Else
                    v_strReturn = "0"
                End If
            End If

        End If
        Return v_strReturn
    End Function

    Private Delegate Sub OnBindData2DataGridViewHelper(ByVal v_taskinfo As BindGridTaskInfo)
    Private Sub BindData2DataGridViewHelper(ByVal v_taskinfo As BindGridTaskInfo)
        If v_taskinfo.dgv.InvokeRequired Then
            Dim v_invoker As New OnBindData2DataGridViewHelper(AddressOf BindData2DataGridViewHelper)
            v_taskinfo.dgv.Invoke(v_invoker, v_taskinfo)
        Else
            BindData2DataGridViewUsingDataTable(v_taskinfo.xml, v_taskinfo.dgv, v_taskinfo.dtype)
        End If
    End Sub
    Private Delegate Sub OnBindData2DataGridView(ByVal v_strRefDATA As String, ByRef v_dgData As DataGridView, ByVal v_strDataOrHeader As String)

    Private Sub BindData2DataGridView(ByVal v_strRefDATA As String, ByRef v_dgData As DataGridView, ByVal v_strDataOrHeader As String)
        Dim v_xmlTemporary As New XmlDocumentEx
        Dim v_nodeData As Xml.XmlNode, v_nodeList As Xml.XmlNodeList
        Dim v_strSQLString, v_strClause As String, i, j, v_intRow, v_intColWidth As Integer
        Dim v_strFIELDNAME, v_strFIELDVALUE, v_strFIELDCAPTION, v_strGridName As String
        Dim dgvRow As DataGridViewRow, dgvCol As DataGridViewColumn, dgvCell As DataGridViewCell
        'Dim v_dtSource As New DataTable
        'Dim v_dtHeaderName As New Hashtable
        Try
            v_strGridName = v_dgData.Name
            'v_dgData.Enabled = False
            'v_dgData.ReadOnly = False
            v_dgData.SuspendLayout()
            v_dgData.EnableHeadersVisualStyles = True
            'Me.Cursor = Cursors.WaitCursor
            If String.Compare(v_strDataOrHeader, "H") = 0 Then
                'Nếu là tạo Header thì truyền vào danh sách các trường thông tin của Grid phân cách nhau bằng dấu |
                If v_strRefDATA.Trim.Length > 0 Then
                    'Cài đặt tham số mặc định
                    FormatStyleForDataGridView(v_dgData)

                    Dim attrColumns As String() = v_strRefDATA.Split(New Char() {"|"c})

                    'Tạo Header: Truyền vào cấu trúc của Recordset
                    If String.Compare(v_strGridName, "dgRemainOrder") = 0 Or String.Compare(v_strGridName, "dgOrderBook") = 0 Then
                        'Thêm trường đánh dấu
                        v_dgData.Columns.Clear()
                        v_dgData.Columns.Add(c_GridSelectedColumn, String.Empty)
                    ElseIf String.Compare(v_strGridName, "dgCash") = 0 _
                        Or String.Compare(v_strGridName, "dgSYMINFO") = 0 _
                        Or String.Compare(v_strGridName, "dgSYMBIDOFFER") = 0 _
                        Or String.Compare(v_strGridName, "dgSYMMKTDEEP") = 0 Then
                        'Quay dọc nên chỉ có 02 cột: Tên trường và giá trị
                        v_dgData.Rows.Clear()
                    End If

                    For i = 0 To attrColumns.Length - 1 Step 1
                        v_strFIELDNAME = attrColumns(i)
                        v_strFIELDCAPTION = ResourceManager.GetString(v_strFIELDNAME)
                        If v_strFIELDCAPTION Is Nothing Then
                            v_strFIELDCAPTION = v_strFIELDNAME
                        End If
                        If String.Compare(v_strGridName, "dgCash") = 0 Then
                            'Quay dọc
                            v_intRow = v_dgData.Rows.Add()
                            v_dgData.Rows(v_intRow).Tag = v_strFIELDNAME
                            v_dgData.Rows(v_intRow).Cells("CashFldName").Value = v_strFIELDCAPTION
                            v_dgData.Rows(v_intRow).Cells("CashFldValue").Value = String.Empty
                        ElseIf String.Compare(v_strGridName, "dgSYMINFO") = 0 Then
                            'Quay dọc
                            v_intRow = v_dgData.Rows.Add()
                            v_dgData.Rows(v_intRow).Tag = v_strFIELDNAME
                            v_dgData.Rows(v_intRow).Cells("SymFldName").Value = v_strFIELDCAPTION
                            v_dgData.Rows(v_intRow).Cells("SymFldValue").Value = String.Empty
                        Else
                            v_dgData.Columns.Add(v_strFIELDNAME, v_strFIELDCAPTION)
                        End If
                    Next

                    'Định dạng dữ liêu hiển thị của Grid
                    For i = 0 To v_dgData.Columns.Count - 1 Step 1
                        FormatColumnForDataGridView(v_strGridName, v_dgData.Columns(i))
                        If String.Compare(v_strGridName, "dgSYMBIDOFFER") = 0 Then
                            v_dgData.Columns(i).Width = v_dgData.Width / 2
                        ElseIf String.Compare(v_strGridName, "dgSYMMKTDEEP") = 0 Then
                            v_dgData.Columns(i).Width = v_dgData.Width / 4
                        Else
                            v_dgData.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        End If
                    Next

                    If String.Compare(v_strGridName, "dgSYMBIDOFFER") = 0 Then
                        'Add 01 row
                        v_intRow = v_dgData.Rows.Add()
                        v_dgData.Rows(v_intRow).Cells("SYMBIDOFFER_BID").Value = String.Empty
                        v_dgData.Rows(v_intRow).Cells("SYMBIDOFFER_OFFER").Value = String.Empty
                    ElseIf String.Compare(v_strGridName, "dgSYMMKTDEEP") = 0 Then
                        'Add 03 row
                        v_intRow = v_dgData.Rows.Add()
                        v_dgData.Rows(v_intRow).Tag = "BEST1"
                        v_dgData.Rows(v_intRow).Cells("SYMBIDOFFER_BIDVOL").Value = String.Empty
                        v_dgData.Rows(v_intRow).Cells("SYMBIDOFFER_BIDPRICE").Value = String.Empty
                        v_dgData.Rows(v_intRow).Cells("SYMBIDOFFER_OFFERPRICE").Value = String.Empty
                        v_dgData.Rows(v_intRow).Cells("SYMBIDOFFER_OFFERVOL").Value = String.Empty

                        v_intRow = v_dgData.Rows.Add()
                        v_dgData.Rows(v_intRow).Tag = "BEST2"
                        v_dgData.Rows(v_intRow).Cells("SYMBIDOFFER_BIDVOL").Value = String.Empty
                        v_dgData.Rows(v_intRow).Cells("SYMBIDOFFER_BIDPRICE").Value = String.Empty
                        v_dgData.Rows(v_intRow).Cells("SYMBIDOFFER_OFFERPRICE").Value = String.Empty
                        v_dgData.Rows(v_intRow).Cells("SYMBIDOFFER_OFFERVOL").Value = String.Empty

                        v_intRow = v_dgData.Rows.Add()
                        v_dgData.Rows(v_intRow).Tag = "BEST3"
                        v_dgData.Rows(v_intRow).Cells("SYMBIDOFFER_BIDVOL").Value = String.Empty
                        v_dgData.Rows(v_intRow).Cells("SYMBIDOFFER_BIDPRICE").Value = String.Empty
                        v_dgData.Rows(v_intRow).Cells("SYMBIDOFFER_OFFERPRICE").Value = String.Empty
                        v_dgData.Rows(v_intRow).Cells("SYMBIDOFFER_OFFERVOL").Value = String.Empty
                    End If

                End If
            Else
                'Setup DataTable
                'For Each dr As DataGridViewColumn In v_dgData.Columns
                '    v_dtSource.Columns.Add(dr.Name)
                '    v_dtHeaderName.Add(dr.Name, dr.HeaderText)
                'Next
                v_xmlTemporary.LoadXml(v_strRefDATA)
                v_nodeList = v_xmlTemporary.SelectNodes("/ObjectMessage/ObjData")
                If Not v_xmlTemporary Is Nothing Then
                    v_nodeList = v_xmlTemporary.SelectNodes("/ObjectMessage/ObjData")
                    'Reset dữ liệu
                    If String.Compare(v_strGridName, "dgCash") = 0 Then
                        'Reset lại giá trị của GridCash
                        If v_dgData.Rows.Count > 0 And v_dgData.Columns.Count > 1 Then
                            For v_intRow = 0 To v_dgData.Rows.Count - 1 Step 1
                                For i = 1 To v_dgData.Columns.Count - 1 Step 1
                                    v_dgData.Rows(v_intRow).Cells(v_dgData.Columns(i).Name).Value = String.Empty
                                Next
                            Next
                        End If
                    ElseIf String.Compare(v_strGridName, "dgSYMBIDOFFER") = 0 _
                        Or String.Compare(v_strGridName, "dgMKTDEEP") = 0 Then
                        'Không xử lý fill dữ liệu cho các Grid đặc biệt
                        Exit Sub
                    Else
                        v_dgData.Rows.Clear()
                    End If
                    'Hiển thị dữ liệu
                    If v_nodeList.Count > 0 Then
                        For i = 0 To v_nodeList.Count - 1
                            'Thêm dữ liệu
                            If String.Compare(v_strGridName, "dgCash") = 0 Then
                                'Xử lý đặc biệt cho GridCash: quay dọc
                                For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                                    v_strFIELDNAME = CStr(CType(v_nodeList.Item(i).ChildNodes(j).Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                    v_strFIELDVALUE = v_nodeList.Item(i).ChildNodes(j).InnerText

                                    'PhuongHT comment: ko lay du lieu tu grid do suc mua pai tinh tren tieu khoan, grid co the view theo custodycode
                                    'If v_strFIELDNAME = "PURCHASINGPOWER" Then
                                    '    mv_dblPURCHASINGPOWER = CDbl(v_strFIELDVALUE)
                                    '    mv_dblPPSE = CDbl(v_strFIELDVALUE)
                                    'ElseIf v_strFIELDNAME = "AVLLIMIT" Then
                                    '    mv_dblAVLLIMIT = CDbl(v_strFIELDVALUE)
                                    'End If

                                    'Xác định dòng chứa dữ liệu
                                    v_intRow = GetRowColIndex(v_dgData, v_strFIELDNAME, "ROW")
                                    If v_intRow >= 0 Then
                                        If IsNumeric(v_strFIELDVALUE) Then
                                            v_dgData.Rows(v_intRow).Cells("CashFldValue").Value = FormatNumber(CDbl(v_strFIELDVALUE), 0)
                                        Else
                                            v_dgData.Rows(v_intRow).Cells("CashFldValue").Value = v_strFIELDVALUE
                                        End If
                                    End If
                                Next
                            Else
                                v_intRow = v_dgData.Rows.Add()
                                'Dim v_Row As DataRow = v_dtSource.NewRow
                                For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                                    v_strFIELDNAME = CStr(CType(v_nodeList.Item(i).ChildNodes(j).Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                    v_strFIELDVALUE = v_nodeList.Item(i).ChildNodes(j).InnerText
                                    If v_dgData.Columns.Contains(v_strFIELDNAME) = True Then
                                        v_dgData.Rows(v_intRow).Cells(v_strFIELDNAME).Value = FormatFieldValueForDataGridView(v_strGridName, v_strFIELDNAME, v_strFIELDVALUE)
                                        'v_Row(v_strFIELDNAME) = FormatFieldValueForDataGridView(v_strGridName, v_strFIELDNAME, v_strFIELDVALUE)
                                    End If
                                Next
                                'v_dtSource.Rows.Add(v_Row)
                            End If

                            'Định dạng đặc biệt
                            If String.Compare(v_strGridName, "dgLoan") = 0 Then
                                'Đặt lại format nếu là dòng Sub-Total và Grand-Total
                                If v_dgData.Rows(v_intRow).Cells("SYMBOL").Value.ToString.Trim.Length = 0 Then
                                    'Grant total: Chi hien thi cac truong AMT
                                    v_dgData.Rows(v_intRow).Cells("DFTYP").Value = ""
                                    v_dgData.Rows(v_intRow).Cells("DESCRIPTION").Value = ""
                                    v_dgData.Rows(v_intRow).Cells("DFTRADE").Value = ""
                                    v_dgData.Rows(v_intRow).Cells("DFQTTY").Value = ""
                                    v_dgData.Rows(v_intRow).Cells("DFPRICE").Value = ""
                                    v_dgData.Rows(v_intRow).Cells("TRIGGERPRICE").Value = ""
                                    v_dgData.Rows(v_intRow).Cells("RLSDATE").Value = ""
                                    v_dgData.Rows(v_intRow).Cells("DUEDATE").Value = ""
                                    v_dgData.Rows(v_intRow).Cells("FEEAMT").Style.ForeColor = FormatGetColorBasedOnTheme("FG_GRANTTOTAL_COLOR")
                                    v_dgData.Rows(v_intRow).Cells("INDUEAMT").Style.ForeColor = FormatGetColorBasedOnTheme("FG_GRANTTOTAL_COLOR")
                                    v_dgData.Rows(v_intRow).Cells("OVERDUEAMT").Style.ForeColor = FormatGetColorBasedOnTheme("FG_GRANTTOTAL_COLOR")
                                ElseIf v_dgData.Rows(v_intRow).Cells("DFACCTNO").Value.ToString.Trim.Length = 0 Then
                                    'Sub total: Hien thi cac truong AMT, QTTY va SYMBOL
                                    v_dgData.Rows(v_intRow).Cells("DFTYP").Value = ""
                                    v_dgData.Rows(v_intRow).Cells("DESCRIPTION").Value = ""
                                    v_dgData.Rows(v_intRow).Cells("DFTRADE").Value = ""
                                    v_dgData.Rows(v_intRow).Cells("RLSDATE").Value = ""
                                    v_dgData.Rows(v_intRow).Cells("DUEDATE").Value = ""
                                    v_dgData.Rows(v_intRow).Cells("DFPRICE").Value = ""
                                    v_dgData.Rows(v_intRow).Cells("TRIGGERPRICE").Value = ""
                                    v_dgData.Rows(v_intRow).Cells("SYMBOL").Style.ForeColor = FormatGetColorBasedOnTheme("FG_SUBTOTAL_COLOR")
                                    v_dgData.Rows(v_intRow).Cells("FEEAMT").Style.ForeColor = FormatGetColorBasedOnTheme("FG_SUBTOTAL_COLOR")
                                    v_dgData.Rows(v_intRow).Cells("INDUEAMT").Style.ForeColor = FormatGetColorBasedOnTheme("FG_SUBTOTAL_COLOR")
                                    v_dgData.Rows(v_intRow).Cells("OVERDUEAMT").Style.ForeColor = FormatGetColorBasedOnTheme("FG_SUBTOTAL_COLOR")
                                    v_dgData.Rows(v_intRow).Cells("DFQTTY").Style.ForeColor = FormatGetColorBasedOnTheme("FG_SUBTOTAL_COLOR")
                                End If
                            ElseIf String.Compare(v_strGridName, "dgAssets") = 0 Then
                                If v_dgData.Rows(v_intRow).Cells("ITEM").Value.ToString.Trim.Length = 0 Then
                                    v_dgData.Rows(v_intRow).Cells("ITEM").Value = ResourceManager.GetString("NETASSETS")
                                    v_dgData.Rows(v_intRow).Cells("VAL").Value = ""
                                    v_dgData.Rows(v_intRow).Cells("SUBACNAME").Value = ""
                                    v_dgData.Rows(v_intRow).Cells("COSTPRICE").Value = ""
                                    v_dgData.Rows(v_intRow).Cells("PROFITANDLOSS").Value = ""
                                ElseIf v_dgData.Rows(v_intRow).Cells("SUBACCTNO").Value.ToString.Trim.Length = 0 Then
                                    v_dgData.Rows(v_intRow).Cells("SUBACNAME").Value = ""
                                    v_dgData.Rows(v_intRow).Cells("ITEM").Style.ForeColor = FormatGetColorBasedOnTheme("FG_SUBTOTAL_COLOR")
                                    v_dgData.Rows(v_intRow).Cells("VAL").Style.ForeColor = FormatGetColorBasedOnTheme("FG_SUBTOTAL_COLOR")
                                    v_dgData.Rows(v_intRow).Cells("AMT").Style.ForeColor = FormatGetColorBasedOnTheme("FG_SUBTOTAL_COLOR")
                                    v_dgData.Rows(v_intRow).Cells("PROFITANDLOSS").Style.ForeColor = FormatGetColorBasedOnTheme("FG_SUBTOTAL_COLOR")
                                    v_dgData.Rows(v_intRow).Cells("COSTPRICE").Style.ForeColor = FormatGetColorBasedOnTheme("FG_SUBTOTAL_COLOR")
                                End If
                                'Resource
                                If String.Compare(v_dgData.Rows(v_intRow).Cells("ITEM").Value.ToString.Trim, "PURCHASINGPOWER") = 0 Then
                                    v_dgData.Rows(v_intRow).Cells("ITEM").Value = ResourceManager.GetString("PURCHASINGPOWER")
                                ElseIf String.Compare(v_dgData.Rows(v_intRow).Cells("ITEM").Value.ToString.Trim, "CASHONHAND") = 0 Then
                                    v_dgData.Rows(v_intRow).Cells("ITEM").Value = ResourceManager.GetString("CASHONHAND")
                                ElseIf String.Compare(v_dgData.Rows(v_intRow).Cells("ITEM").Value.ToString.Trim, "DEBIT") = 0 Then
                                    v_dgData.Rows(v_intRow).Cells("ITEM").Value = ResourceManager.GetString("DEBIT")
                                End If
                            ElseIf String.Compare(v_strGridName, "dgSecurities") = 0 Then
                                If v_dgData.Rows(v_intRow).Cells("SUBACCTNO").Value.ToString.Trim.Length = 0 Then

                                    v_dgData.Rows(v_intRow).Cells("SUBACCTNO").Value = ""
                                    v_dgData.Rows(v_intRow).Cells("SYMBOL").Style.ForeColor = FormatGetColorBasedOnTheme("FG_SUBTOTAL_COLOR")
                                    v_dgData.Rows(v_intRow).Cells("TOTAL_QTTY").Style.ForeColor = FormatGetColorBasedOnTheme("FG_SUBTOTAL_COLOR")
                                    v_dgData.Rows(v_intRow).Cells("TRADE_QTTY").Style.ForeColor = FormatGetColorBasedOnTheme("FG_SUBTOTAL_COLOR")
                                    v_dgData.Rows(v_intRow).Cells("DEALFINANCING_QTTY").Style.ForeColor = FormatGetColorBasedOnTheme("FG_SUBTOTAL_COLOR")
                                    v_dgData.Rows(v_intRow).Cells("ORDERQTTY_NORMAL").Style.ForeColor = FormatGetColorBasedOnTheme("FG_SUBTOTAL_COLOR")
                                    v_dgData.Rows(v_intRow).Cells("ORDERQTTY_BLOCKED").Style.ForeColor = FormatGetColorBasedOnTheme("FG_SUBTOTAL_COLOR")
                                    v_dgData.Rows(v_intRow).Cells("ORDERQTTY_BUY").Style.ForeColor = FormatGetColorBasedOnTheme("FG_SUBTOTAL_COLOR")
                                    v_dgData.Rows(v_intRow).Cells("MORTGAGE_QTTY").Style.ForeColor = FormatGetColorBasedOnTheme("FG_SUBTOTAL_COLOR")
                                    v_dgData.Rows(v_intRow).Cells("NETTING_QTTY").Style.ForeColor = FormatGetColorBasedOnTheme("FG_SUBTOTAL_COLOR")
                                    v_dgData.Rows(v_intRow).Cells("BLOCKED_QTTY").Style.ForeColor = FormatGetColorBasedOnTheme("FG_SUBTOTAL_COLOR")
                                    v_dgData.Rows(v_intRow).Cells("SECURITIES_RECEIVING_T0").Style.ForeColor = FormatGetColorBasedOnTheme("FG_SUBTOTAL_COLOR")
                                    v_dgData.Rows(v_intRow).Cells("SECURITIES_RECEIVING_T1").Style.ForeColor = FormatGetColorBasedOnTheme("FG_SUBTOTAL_COLOR")
                                    v_dgData.Rows(v_intRow).Cells("SECURITIES_RECEIVING_T2").Style.ForeColor = FormatGetColorBasedOnTheme("FG_SUBTOTAL_COLOR")
                                    v_dgData.Rows(v_intRow).Cells("SECURITIES_RECEIVING_T3").Style.ForeColor = FormatGetColorBasedOnTheme("FG_SUBTOTAL_COLOR")
                                    v_dgData.Rows(v_intRow).Cells("SECURITIES_RECEIVING_TN").Style.ForeColor = FormatGetColorBasedOnTheme("FG_SUBTOTAL_COLOR")
                                    v_dgData.Rows(v_intRow).Cells("SECURITIES_SENDING_T0").Style.ForeColor = FormatGetColorBasedOnTheme("FG_SUBTOTAL_COLOR")
                                    v_dgData.Rows(v_intRow).Cells("SECURITIES_SENDING_T1").Style.ForeColor = FormatGetColorBasedOnTheme("FG_SUBTOTAL_COLOR")
                                    v_dgData.Rows(v_intRow).Cells("SECURITIES_SENDING_T2").Style.ForeColor = FormatGetColorBasedOnTheme("FG_SUBTOTAL_COLOR")
                                    v_dgData.Rows(v_intRow).Cells("SECURITIES_SENDING_T3").Style.ForeColor = FormatGetColorBasedOnTheme("FG_SUBTOTAL_COLOR")
                                    v_dgData.Rows(v_intRow).Cells("SECURITIES_SENDING_TN").Style.ForeColor = FormatGetColorBasedOnTheme("FG_SUBTOTAL_COLOR")
                                End If
                                

                            End If
                        Next
                        v_dgData.AutoResizeColumns()
                    End If
                End If
            End If
            'v_dgData.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message)
            'Throw ex
        Finally
            'v_dgData.ReadOnly = True
            v_dgData.AllowUserToAddRows = False
            Me.Cursor = Cursors.Default
            v_dgData.Enabled = True
            v_dgData.ResumeLayout()
            v_xmlTemporary = Nothing
        End Try
    End Sub

    Private Sub BindData2DataGridViewUsingDataTable(ByVal v_strRefDATA As String, ByRef v_dgData As DataGridView, ByVal v_strDataOrHeader As String)
        Dim v_xmlTemporary As New XmlDocumentEx
        Dim v_nodeData As Xml.XmlNode, v_nodeList As Xml.XmlNodeList
        Dim v_strSQLString, v_strClause As String, i, j, v_intRow, v_intColWidth As Integer
        Dim v_strFIELDNAME, v_strFIELDVALUE, v_strFIELDCAPTION, v_strGridName As String
        Dim dgvRow As DataGridViewRow, dgvCol As DataGridViewColumn, dgvCell As DataGridViewCell
        Dim v_dtSource As New DataTable
        Dim v_dtHeaderName As New Hashtable
        Try
            v_dgData.SuspendLayout()
            v_strGridName = v_dgData.Name

            'v_dgData.Enabled = False
            'v_dgData.ReadOnly = False
            v_dgData.EnableHeadersVisualStyles = True
            'Me.Cursor = Cursors.WaitCursor
            If String.Compare(v_strDataOrHeader, "H") = 0 Then
                'Nếu là tạo Header thì truyền vào danh sách các trường thông tin của Grid phân cách nhau bằng dấu |
                If v_strRefDATA.Trim.Length > 0 Then
                    'Cài đặt tham số mặc định
                    FormatStyleForDataGridView(v_dgData)

                    Dim attrColumns As String() = v_strRefDATA.Split(New Char() {"|"c})

                    'Tạo Header: Truyền vào cấu trúc của Recordset
                    If String.Compare(v_strGridName, "dgRemainOrder") = 0 Or String.Compare(v_strGridName, "dgOrderBook") = 0 Then
                        'Thêm trường đánh dấu
                        v_dgData.Columns.Clear()
                        v_dgData.Columns.Add(c_GridSelectedColumn, String.Empty)
                    ElseIf String.Compare(v_strGridName, "dgCash") = 0 _
                        Or String.Compare(v_strGridName, "dgSYMINFO") = 0 _
                        Or String.Compare(v_strGridName, "dgSYMBIDOFFER") = 0 _
                        Or String.Compare(v_strGridName, "dgSYMMKTDEEP") = 0 Then
                        'Quay dọc nên chỉ có 02 cột: Tên trường và giá trị
                        v_dgData.Rows.Clear()
                    End If

                    For i = 0 To attrColumns.Length - 1 Step 1
                        v_strFIELDNAME = attrColumns(i)
                        v_strFIELDCAPTION = ResourceManager.GetString(v_strFIELDNAME)
                        If v_strFIELDCAPTION Is Nothing Then
                            v_strFIELDCAPTION = v_strFIELDNAME
                        End If
                        If String.Compare(v_strGridName, "dgCash") = 0 Then
                            'Quay dọc
                            v_intRow = v_dgData.Rows.Add()
                            v_dgData.Rows(v_intRow).Tag = v_strFIELDNAME
                            v_dgData.Rows(v_intRow).Cells("CashFldName").Value = v_strFIELDCAPTION
                            v_dgData.Rows(v_intRow).Cells("CashFldValue").Value = String.Empty
                        ElseIf String.Compare(v_strGridName, "dgSYMINFO") = 0 Then
                            'Quay dọc
                            v_intRow = v_dgData.Rows.Add()
                            v_dgData.Rows(v_intRow).Tag = v_strFIELDNAME
                            v_dgData.Rows(v_intRow).Cells("SymFldName").Value = v_strFIELDCAPTION
                            v_dgData.Rows(v_intRow).Cells("SymFldValue").Value = String.Empty
                        Else
                            v_dgData.Columns.Add(v_strFIELDNAME, v_strFIELDCAPTION)
                        End If
                    Next

                    'Định dạng dữ liêu hiển thị của Grid
                    For i = 0 To v_dgData.Columns.Count - 1 Step 1
                        FormatColumnForDataGridView(v_strGridName, v_dgData.Columns(i))
                        If String.Compare(v_strGridName, "dgSYMBIDOFFER") = 0 Then
                            v_dgData.Columns(i).Width = v_dgData.Width / 2
                        ElseIf String.Compare(v_strGridName, "dgSYMMKTDEEP") = 0 Then
                            v_dgData.Columns(i).Width = v_dgData.Width / 4
                        Else
                            v_dgData.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        End If
                    Next

                    If String.Compare(v_strGridName, "dgSYMBIDOFFER") = 0 Then
                        'Add 01 row
                        v_intRow = v_dgData.Rows.Add()
                        v_dgData.Rows(v_intRow).Cells("SYMBIDOFFER_BID").Value = String.Empty
                        v_dgData.Rows(v_intRow).Cells("SYMBIDOFFER_OFFER").Value = String.Empty
                    ElseIf String.Compare(v_strGridName, "dgSYMMKTDEEP") = 0 Then
                        'Add 03 row
                        v_intRow = v_dgData.Rows.Add()
                        v_dgData.Rows(v_intRow).Tag = "BEST1"
                        v_dgData.Rows(v_intRow).Cells("SYMBIDOFFER_BIDVOL").Value = String.Empty
                        v_dgData.Rows(v_intRow).Cells("SYMBIDOFFER_BIDPRICE").Value = String.Empty
                        v_dgData.Rows(v_intRow).Cells("SYMBIDOFFER_OFFERPRICE").Value = String.Empty
                        v_dgData.Rows(v_intRow).Cells("SYMBIDOFFER_OFFERVOL").Value = String.Empty

                        v_intRow = v_dgData.Rows.Add()
                        v_dgData.Rows(v_intRow).Tag = "BEST2"
                        v_dgData.Rows(v_intRow).Cells("SYMBIDOFFER_BIDVOL").Value = String.Empty
                        v_dgData.Rows(v_intRow).Cells("SYMBIDOFFER_BIDPRICE").Value = String.Empty
                        v_dgData.Rows(v_intRow).Cells("SYMBIDOFFER_OFFERPRICE").Value = String.Empty
                        v_dgData.Rows(v_intRow).Cells("SYMBIDOFFER_OFFERVOL").Value = String.Empty

                        v_intRow = v_dgData.Rows.Add()
                        v_dgData.Rows(v_intRow).Tag = "BEST3"
                        v_dgData.Rows(v_intRow).Cells("SYMBIDOFFER_BIDVOL").Value = String.Empty
                        v_dgData.Rows(v_intRow).Cells("SYMBIDOFFER_BIDPRICE").Value = String.Empty
                        v_dgData.Rows(v_intRow).Cells("SYMBIDOFFER_OFFERPRICE").Value = String.Empty
                        v_dgData.Rows(v_intRow).Cells("SYMBIDOFFER_OFFERVOL").Value = String.Empty
                    End If

                    'Setup DataTable
                    For Each dr As DataGridViewColumn In v_dgData.Columns
                        v_dtSource.Columns.Add(dr.Name)
                        v_dtHeaderName.Add(dr.Name, dr.HeaderText)
                    Next

                End If
            Else
                'Setup DataTable
                For Each dr As DataGridViewColumn In v_dgData.Columns
                    'Remove the mark of Filtered Column
                    v_dtSource.Columns.Add(dr.Name.Replace("(*)", String.Empty))
                    v_dtHeaderName.Add(dr.Name, dr.HeaderText.Replace("(*)", String.Empty))
                Next
                v_xmlTemporary.LoadXml(v_strRefDATA)
                v_nodeList = v_xmlTemporary.SelectNodes("/ObjectMessage/ObjData")
                If Not v_xmlTemporary Is Nothing Then
                    v_nodeList = v_xmlTemporary.SelectNodes("/ObjectMessage/ObjData")
                    'Reset dữ liệu
                    If String.Compare(v_strGridName, "dgCash") = 0 Then
                        'Reset lại giá trị của GridCash
                        If v_dgData.Rows.Count > 0 And v_dgData.Columns.Count > 1 Then
                            For v_intRow = 0 To v_dgData.Rows.Count - 1 Step 1
                                For i = 1 To v_dgData.Columns.Count - 1 Step 1
                                    v_dgData.Rows(v_intRow).Cells(v_dgData.Columns(i).Name).Value = String.Empty
                                Next
                            Next
                        End If
                    ElseIf String.Compare(v_strGridName, "dgSYMBIDOFFER") = 0 _
                        Or String.Compare(v_strGridName, "dgMKTDEEP") = 0 Then
                        'Không xử lý fill dữ liệu cho các Grid đặc biệt
                        Exit Sub
                    Else
                        Try
                            v_dgData.Rows.Clear()
                        Catch ex As Exception
                            LogError.Write("BindData2DataGridViewUsingDataTable.:" & ex.ToString, EventLogEntryType.Error)
                        End Try
                    End If
                    'Hiển thị dữ liệu
                    If v_nodeList.Count > 0 Then
                        For i = 0 To v_nodeList.Count - 1
                            'Thêm dữ liệu
                            If String.Compare(v_strGridName, "dgCash") = 0 Then
                                'Xử lý đặc biệt cho GridCash: quay dọc
                                For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                                    v_strFIELDNAME = CStr(CType(v_nodeList.Item(i).ChildNodes(j).Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                    v_strFIELDVALUE = v_nodeList.Item(i).ChildNodes(j).InnerText
                                    'If v_strFIELDNAME = "PURCHASINGPOWER" Then
                                    '    mv_dblPURCHASINGPOWER = CDbl(v_strFIELDVALUE)
                                    '    mv_dblPPSE = CDbl(v_strFIELDVALUE)
                                    'ElseIf v_strFIELDNAME = "AVLLIMIT" Then
                                    '    mv_dblAVLLIMIT = CDbl(v_strFIELDVALUE)
                                    'End If
                                    'Xác định dòng chứa dữ liệu
                                    v_intRow = GetRowColIndex(v_dgData, v_strFIELDNAME, "ROW")
                                    If v_intRow >= 0 Then
                                        If IsNumeric(v_strFIELDVALUE) Then
                                            v_dgData.Rows(v_intRow).Cells("CashFldValue").Value = FormatNumber(CDbl(v_strFIELDVALUE), 0)
                                        Else
                                            v_dgData.Rows(v_intRow).Cells("CashFldValue").Value = v_strFIELDVALUE
                                        End If
                                    End If
                                Next
                            Else
                                'v_intRow = v_dgData.Rows.Add()
                                Dim v_Row As DataRow = v_dtSource.NewRow
                                For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                                    v_strFIELDNAME = CStr(CType(v_nodeList.Item(i).ChildNodes(j).Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                    v_strFIELDVALUE = v_nodeList.Item(i).ChildNodes(j).InnerText
                                    If v_dgData.Columns.Contains(v_strFIELDNAME) = True Then
                                        'v_dgData.Rows(v_intRow).Cells(v_strFIELDNAME).Value = FormatFieldValueForDataGridView(v_strGridName, v_strFIELDNAME, v_strFIELDVALUE)
                                        v_Row(v_strFIELDNAME) = FormatFieldValueForDataGridView(v_strGridName, v_strFIELDNAME, v_strFIELDVALUE)
                                    End If
                                Next
                                v_dtSource.Rows.Add(v_Row)
                            End If

                            'Định dạng đặc biệt
                            If String.Compare(v_strGridName, "dgLoan") = 0 Then
                                'Đặt lại format nếu là dòng Sub-Total và Grand-Total
                                If v_dgData.Rows(v_intRow).Cells("SYMBOL").Value.ToString.Trim.Length = 0 Then
                                    'Grant total: Chi hien thi cac truong AMT
                                    v_dgData.Rows(v_intRow).Cells("DFTYP").Value = ""
                                    v_dgData.Rows(v_intRow).Cells("DESCRIPTION").Value = ""
                                    v_dgData.Rows(v_intRow).Cells("DFTRADE").Value = ""
                                    v_dgData.Rows(v_intRow).Cells("DFQTTY").Value = ""
                                    v_dgData.Rows(v_intRow).Cells("DFPRICE").Value = ""
                                    v_dgData.Rows(v_intRow).Cells("TRIGGERPRICE").Value = ""
                                    v_dgData.Rows(v_intRow).Cells("RLSDATE").Value = ""
                                    v_dgData.Rows(v_intRow).Cells("DUEDATE").Value = ""
                                    v_dgData.Rows(v_intRow).Cells("FEEAMT").Style.ForeColor = FormatGetColorBasedOnTheme("FG_GRANTTOTAL_COLOR")
                                    v_dgData.Rows(v_intRow).Cells("INDUEAMT").Style.ForeColor = FormatGetColorBasedOnTheme("FG_GRANTTOTAL_COLOR")
                                    v_dgData.Rows(v_intRow).Cells("OVERDUEAMT").Style.ForeColor = FormatGetColorBasedOnTheme("FG_GRANTTOTAL_COLOR")
                                ElseIf v_dgData.Rows(v_intRow).Cells("DFACCTNO").Value.ToString.Trim.Length = 0 Then
                                    'Sub total: Hien thi cac truong AMT, QTTY va SYMBOL
                                    v_dgData.Rows(v_intRow).Cells("DFTYP").Value = ""
                                    v_dgData.Rows(v_intRow).Cells("DESCRIPTION").Value = ""
                                    v_dgData.Rows(v_intRow).Cells("DFTRADE").Value = ""
                                    v_dgData.Rows(v_intRow).Cells("RLSDATE").Value = ""
                                    v_dgData.Rows(v_intRow).Cells("DUEDATE").Value = ""
                                    v_dgData.Rows(v_intRow).Cells("DFPRICE").Value = ""
                                    v_dgData.Rows(v_intRow).Cells("TRIGGERPRICE").Value = ""
                                    v_dgData.Rows(v_intRow).Cells("SYMBOL").Style.ForeColor = FormatGetColorBasedOnTheme("FG_SUBTOTAL_COLOR")
                                    v_dgData.Rows(v_intRow).Cells("FEEAMT").Style.ForeColor = FormatGetColorBasedOnTheme("FG_SUBTOTAL_COLOR")
                                    v_dgData.Rows(v_intRow).Cells("INDUEAMT").Style.ForeColor = FormatGetColorBasedOnTheme("FG_SUBTOTAL_COLOR")
                                    v_dgData.Rows(v_intRow).Cells("OVERDUEAMT").Style.ForeColor = FormatGetColorBasedOnTheme("FG_SUBTOTAL_COLOR")
                                    v_dgData.Rows(v_intRow).Cells("DFQTTY").Style.ForeColor = FormatGetColorBasedOnTheme("FG_SUBTOTAL_COLOR")
                                End If
                            ElseIf String.Compare(v_strGridName, "dgAssets") = 0 Then
                                If v_dgData.Rows(v_intRow).Cells("ITEM").Value.ToString.Trim.Length = 0 Then
                                    v_dgData.Rows(v_intRow).Cells("VAL").Value = ""
                                    v_dgData.Rows(v_intRow).Cells("SUBACNAME").Value = ""
                                ElseIf v_dgData.Rows(v_intRow).Cells("SUBACCTNO").Value.ToString.Trim.Length = 0 Then
                                    v_dgData.Rows(v_intRow).Cells("SUBACNAME").Value = ""
                                    v_dgData.Rows(v_intRow).Cells("ITEM").Style.ForeColor = FormatGetColorBasedOnTheme("FG_SUBTOTAL_COLOR")
                                    v_dgData.Rows(v_intRow).Cells("VAL").Style.ForeColor = FormatGetColorBasedOnTheme("FG_SUBTOTAL_COLOR")
                                End If
                                'Resource
                                If String.Compare(v_dgData.Rows(v_intRow).Cells("ITEM").Value.ToString.Trim, "PURCHASINGPOWER") = 0 Then
                                    v_dgData.Rows(v_intRow).Cells("ITEM").Value = ResourceManager.GetString("PURCHASINGPOWER")
                                ElseIf String.Compare(v_dgData.Rows(v_intRow).Cells("ITEM").Value.ToString.Trim, "CASHONHAND") = 0 Then
                                    v_dgData.Rows(v_intRow).Cells("ITEM").Value = ResourceManager.GetString("CASHONHAND")

                                End If
                            End If
                        Next
                        'v_dgData.AutoResizeColumns()
                    End If
                End If
            End If
            'v_dgData.Enabled = True
            If (v_dtSource.Columns.Count > 0) Then
                'Set the template
                'v_dgData.DefaultCellStyle.ForeColor = Color.White
                'v_dgData.DefaultCellStyle.BackColor = Color.Black
                v_dgData.MultiSelect = True
                Try
                    'Mean that this table only init Header
                    If v_dgData.DataSource Is Nothing Then
                        v_dgData.Columns.Clear()
                    End If
                Catch ex As Exception
                    'Accept exception
                End Try
                Try
                    v_dgData.Rows.Clear()
                Catch ex As Exception
                    'Accept exception
                End Try
                Dim dataSource As New BindingSource(v_dtSource, Nothing)
                v_dgData.DataSource = dataSource
                'Set the hearder text
                For Each headername As String In v_dtHeaderName.Keys
                    v_dgData.Columns(headername).HeaderText = v_dtHeaderName(headername)
                Next
                If v_dtSource.Rows.Count > 0 Then
                    v_dgData.RowsDefaultCellStyle.SelectionBackColor = FormatGetColorBasedOnTheme("BG_CHG_COLOR")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            LogError.Write("BindData2GridViewUsingDataTable.:" & ex.ToString, EventLogEntryType.Error)
            'Throw ex
        Finally
            'v_dgData.ReadOnly = True
            v_dgData.AllowUserToAddRows = False
            v_dgData.AutoResizeColumns()
            v_dgData.ResumeLayout()
            Me.Cursor = Cursors.Default
            'v_dgData.Enabled = True
            v_xmlTemporary = Nothing
        End Try
    End Sub

    Public Overridable Sub GetTabPageSecurities(ByVal v_strACCTNO As String)
        Dim v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_xmlTemporary As New XmlDocumentEx
        Dim v_strCustodycd As String
        v_strCustodycd = mv_arrCustodyCode(cboAFAcctno.SelectedIndex)
        Try
            'Neu la lan dau chay thi thoat luon
            If mb_blnIsFirstRun Then Exit Sub

            Dim v_strSQLString, v_strClause As String, i, j As Integer
            'get semast information
            If (Me.RadioSubAcctno.Checked = True) Then
                v_strSQLString = "SP_BD_GETSEMASTPOSITION"
                v_strClause = "AFACCTNO!" & v_strACCTNO & "!varchar2!20"
            Else
                v_strSQLString = "SP_BD_GETSEMASTPOSITION_SUM"
                v_strClause = "CUSTODYCD!" & v_strCustodycd & "!varchar2!20"
            End If

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_SA_ALLCODE, gc_ActionInquiry, v_strSQLString, v_strClause, , , , , , , gc_CommandProcedure)
            v_ws.Message(v_strObjMsg)
            BindData2DataGridView(v_strObjMsg, dgSecurities, "D")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            v_xmlTemporary = Nothing
            v_ws = Nothing
        End Try
    End Sub

    Public Overridable Sub GetTabPageDeal(ByVal v_strACCTNO As String)
        Dim v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_xmlTemporary As New XmlDocumentEx
        Dim v_strCustodycd As String
        v_strCustodycd = mv_arrCustodyCode(cboAFAcctno.SelectedIndex)
        Try
            'Neu la lan dau chay thi thoat luon
            If mb_blnIsFirstRun Then Exit Sub

            Dim v_strSQLString, v_strClause As String, i, j As Integer
            'get trades
            If (Me.RadioSubAcctno.Checked = True) Then
                v_strSQLString = "SP_BD_GETDEALS"
                v_strClause = "AFACCTNO!" & v_strACCTNO & "!varchar2!20"
            Else
                v_strSQLString = "SP_BD_GETDEALS_SUM"
                v_strClause = "CUSTODYCD!" & v_strCustodycd & "!varchar2!20"
            End If

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_SA_ALLCODE, gc_ActionInquiry, v_strSQLString, v_strClause, , , , , , , gc_CommandProcedure)
            v_ws.Message(v_strObjMsg)

            Dim v_taskinfo As New BindGridTaskInfo
            v_taskinfo.xml = v_strObjMsg
            v_taskinfo.dtype = "D"
            v_taskinfo.dgv = dgTrades

            BindData2DataGridViewHelper(v_taskinfo)
            'BindData2DataGridView(v_strObjMsg, dgTrades, "D")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            v_xmlTemporary = Nothing
            v_ws = Nothing
        End Try
    End Sub

    Public Overridable Sub GetTabPageLoan(ByVal v_strACCTNO As String)
        Dim v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_xmlTemporary As New XmlDocumentEx
        Dim v_strCustodycd As String
        v_strCustodycd = mv_arrCustodyCode(cboAFAcctno.SelectedIndex)
        Try
            'Neu la lan dau chay thi thoat luon
            If mb_blnIsFirstRun Then Exit Sub

            Dim v_strSQLString, v_strClause As String, i, j As Integer
            'get dfmast information
            If (Me.RadioSubAcctno.Checked = True) Then
                v_strSQLString = "SP_BD_GETACCOUNTLOANINFO"
                v_strClause = "AFACCTNO!" & v_strACCTNO & "!varchar2!20"
            Else
                v_strSQLString = "SP_BD_GETACCOUNTLOANINFO_SUM"
                v_strClause = "CUSTODYCD!" & v_strCustodycd & "!varchar2!20"
            End If

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_SA_ALLCODE, gc_ActionInquiry, v_strSQLString, v_strClause, , , , , , , gc_CommandProcedure)
            v_ws.Message(v_strObjMsg)
            BindData2DataGridView(v_strObjMsg, dgLoan, "D")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            v_xmlTemporary = Nothing
            v_ws = Nothing
        End Try
    End Sub

    Public Overridable Sub GetTabPageOrders(ByVal v_strACCTNO As String)
        Dim v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_xmlTemporary As New XmlDocumentEx
        Dim v_strCustodycd As String
        v_strCustodycd = mv_arrCustodyCode(cboAFAcctno.SelectedIndex)

        Try
            'Neu la lan dau chay thi thoat luon
            If mb_blnIsFirstRun Then Exit Sub

            Dim v_strSQLString, v_strClause As String, i, j As Integer
            'get cash information
            If (Me.RadioSubAcctno.Checked = True) Then
                v_strSQLString = "SP_BD_GETORDERFORCANCEL"
                v_strClause = "AFACCTNO!" & v_strACCTNO & "!varchar2!20"
            Else
                v_strSQLString = "SP_BD_GETORDERFORCANCEL_SUM"
                v_strClause = "CUSTODYCD!" & v_strCustodycd & "!varchar2!20"
            End If


            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_SA_ALLCODE, gc_ActionInquiry, v_strSQLString, v_strClause, , , , , , , gc_CommandProcedure)
            v_ws.Message(v_strObjMsg)

            Dim v_taskinfo As New BindGridTaskInfo()
            v_taskinfo.xml = v_strObjMsg
            v_taskinfo.dgv = dgRemainOrder
            v_taskinfo.dtype = "D"

            Threading.ThreadPool.QueueUserWorkItem(AddressOf BindData2DataGridViewHelper, v_taskinfo)

            'BindData2DataGridView(v_strObjMsg, dgRemainOrder, "D")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            v_xmlTemporary = Nothing
            v_ws = Nothing
        End Try
    End Sub

    Public Overridable Sub GetTabPageCustomer(ByVal v_strCUSTODYCD As String)
        Dim v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_xmlTemporary As New XmlDocumentEx
        Dim v_strACCTNO As String
        Try
            'Neu la lan dau chay thi thoat luon
            If mb_blnIsFirstRun Then Exit Sub

            Dim v_strSQLString, v_strClause As String, i, j As Integer
            If (Me.RadioCustodyCd.Checked = True) Then
                v_strSQLString = "SP_BD_GETCUSTOMERPOSITION"
                v_strClause = "CUSTODYCD!" & v_strCUSTODYCD & "!varchar2!20"
            Else
                v_strSQLString = "SP_BD_GETCUSTOMERPOSITION_SUB"
                v_strACCTNO = mv_arrAccountNumber(cboAFAcctno.SelectedIndex)
                v_strClause = "AFACCTNO!" & v_strACCTNO & "!varchar2!20"

            End If

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_SA_ALLCODE, gc_ActionInquiry, v_strSQLString, v_strClause, , , , , , , gc_CommandProcedure)
            v_ws.Message(v_strObjMsg)
            BindData2DataGridView(v_strObjMsg, dgAssets, "D")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            v_xmlTemporary = Nothing
            v_ws = Nothing
        End Try
    End Sub

    Public Overridable Sub GetAccountPosition(ByVal v_strACCTNO As String)
        Dim v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_xmlTemporary As New XmlDocumentEx
        Dim v_ds As New DataSet
        Dim v_tableCI As DataTable = New DataTable("AccountCash")
        Dim v_tableSE As DataTable = New DataTable("AccountSecurities")
        Dim v_column As DataColumn
        Dim v_row As DataRow

        Try
            'Neu la lan dau chay thi thoat luon
            If mb_blnIsFirstRun Then Exit Sub
            mv_dblPURCHASINGPOWER = 0
            mv_dblPPSE = 0
            Dim v_nodeData As Xml.XmlNode, v_nodeList As Xml.XmlNodeList
            'Cache thong tin ve chung khoan
            Dim v_strSQLString, v_strClause As String, i, j As Integer
            Dim v_strFIELDNAME, v_strFIELDVALUE, v_strFIELDCAPTION As String

            'get cash information
            v_strSQLString = "SP_BD_GETACCOUNTPOSITION"
            v_strClause = "AFACCTNO!" & v_strACCTNO & "!varchar2!20"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_SA_ALLCODE, gc_ActionInquiry, v_strSQLString, v_strClause, , , , , , , gc_CommandProcedure)
            v_ws.Message(v_strObjMsg)
            BindData2DataGridView(v_strObjMsg, dgCash, "D")

            'Get securities available for trade
            v_strSQLString = "SP_BD_GETSEMASTAVLTRADE"
            v_strClause = "AFACCTNO!" & v_strACCTNO & "!varchar2!20"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_SA_ALLCODE, gc_ActionInquiry, v_strSQLString, v_strClause, , , , , , , gc_CommandProcedure)
            v_ws.Message(v_strObjMsg)
            BindData2DataGridView(v_strObjMsg, dgStocks, "D")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            v_tableSE.Dispose()
            v_tableCI.Dispose()
            v_ds.Dispose()
            v_xmlTemporary = Nothing
            v_ws = Nothing
        End Try
    End Sub

    Public Overridable Sub GetTabPageAccount(ByVal v_strACCTNO As String)
        Dim v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_xmlTemporary As New XmlDocumentEx
        Dim v_strCustodyCD As String
        v_strCustodyCD = Me.mskCriteriaValue.Text.ToUpper
        Dim v_strSQLString, v_strClause As String, i, j As Integer
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Try
            'Neu la lan dau chay thi thoat luon
            If mb_blnIsFirstRun Then Exit Sub
            mv_dblPURCHASINGPOWER = 0
            mv_dblPPSE = 0

            
            'PhuongHT
            ' lay ra mv_dblPURCHASINGPOWER,mv_dblPPSE
            v_strSQLString = "SP_BD_GETACCOUNTPOSITION"
            v_strClause = "AFACCTNO!" & v_strACCTNO & "!varchar2!20"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_SA_ALLCODE, gc_ActionInquiry, v_strSQLString, v_strClause, , , , , , , gc_CommandProcedure)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            'v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData/Entry[@oldval='" & v_strSYMBOL & "']")
            Dim v_strValue, v_strFLDNAME As String
            For i = 0 To v_nodeList.Count - 1
                For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        If CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "PURCHASINGPOWER" Then
                            v_strValue = .InnerText.ToString.Trim
                            mv_dblPURCHASINGPOWER = CDbl(v_strValue)
                            mv_dblPPSE = CDbl(v_strValue)
                            

                        ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "AVLLIMIT" Then
                            v_strValue = .InnerText.ToString.Trim
                            mv_dblAVLLIMIT = CDbl(v_strValue)

                        End If
                    End With
                Next


            Next

            ' Neu dk filter la theo so tieu khoan 
            If (Me.RadioSubAcctno.Checked = True) Then
                'get cash information
                v_strSQLString = "SP_BD_GETACCOUNTPOSITION"
                v_strClause = "AFACCTNO!" & v_strACCTNO & "!varchar2!20"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_SA_ALLCODE, gc_ActionInquiry, v_strSQLString, v_strClause, , , , , , , gc_CommandProcedure)
                v_ws.Message(v_strObjMsg)
                BindData2DataGridView(v_strObjMsg, dgCash, "D")

                'Get securities available for trade
                v_strSQLString = "SP_BD_GETSEMASTAVLTRADE"
                v_strClause = "AFACCTNO!" & v_strACCTNO & "!varchar2!20"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_SA_ALLCODE, gc_ActionInquiry, v_strSQLString, v_strClause, , , , , , , gc_CommandProcedure)
                v_ws.Message(v_strObjMsg)
                BindData2DataGridView(v_strObjMsg, dgStocks, "D")

                'Get orderbook
                v_strSQLString = "SP_BD_GETORDERBOOK"
                v_strClause = "AFACCTNO!" & v_strACCTNO & "!varchar2!20"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_SA_ALLCODE, gc_ActionInquiry, v_strSQLString, v_strClause, , , , , , , gc_CommandProcedure)
                v_ws.Message(v_strObjMsg)


            Else
                'get cash information
                v_strSQLString = "SP_BD_GETACCOUNT_CUSTODYCD"
                v_strClause = "CUSTODYCD!" & v_strCustodyCD & "!varchar2!20"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_SA_ALLCODE, gc_ActionInquiry, v_strSQLString, v_strClause, , , , , , , gc_CommandProcedure)
                v_ws.Message(v_strObjMsg)
                BindData2DataGridView(v_strObjMsg, dgCash, "D")

                'Get securities available for trade
                v_strSQLString = "SP_BD_GETSEMASTAVLTRADE_CUSTCD"
                v_strClause = "CUSTODYCD!" & v_strCustodyCD & "!varchar2!20"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_SA_ALLCODE, gc_ActionInquiry, v_strSQLString, v_strClause, , , , , , , gc_CommandProcedure)
                v_ws.Message(v_strObjMsg)
                BindData2DataGridView(v_strObjMsg, dgStocks, "D")

                'Get orderbook
                v_strSQLString = "SP_BD_GETORDERBOOK_CUSTODYCD"
                v_strClause = "CUSTODYCD!" & v_strCustodyCD & "!varchar2!20"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_SA_ALLCODE, gc_ActionInquiry, v_strSQLString, v_strClause, , , , , , , gc_CommandProcedure)
                v_ws.Message(v_strObjMsg)


            End If
            ' neu check by user : orderbook theo user
            If (Me.ChkByUser.Checked = True) Then
                ' Get orderbook
                v_strSQLString = "SP_BD_GETORDERBOOK_BYUSER"
                v_strClause = "TELLERID!" & mv_strTellerId & "!varchar2!20"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_SA_ALLCODE, gc_ActionInquiry, v_strSQLString, v_strClause, , , , , , , gc_CommandProcedure)
                v_ws.Message(v_strObjMsg)

            End If
            Dim v_taskinfo As New BindGridTaskInfo()
            v_taskinfo.xml = v_strObjMsg
            v_taskinfo.dgv = dgOrderBook
            v_taskinfo.dtype = "D"

            Threading.ThreadPool.QueueUserWorkItem(AddressOf BindData2DataGridViewHelper, v_taskinfo)
            'BindData2DataGridView(v_strObjMsg, dgOrderBook, "D")

            Dim v_lngNumberOfOrder As Long
            v_lngNumberOfOrder = dgOrderBook.RowCount
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            v_xmlTemporary = Nothing
            v_ws = Nothing
        End Try
    End Sub
    Public Overridable Sub ReloadOrderBook()
        Dim v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_xmlTemporary As New XmlDocumentEx
        Dim v_strSQLString, v_strClause As String, i, j As Integer
        mv_strTellerId = Me.TellerId

        Try
            ' neu check by user : orderbook theo user
            If (Me.ChkByUser.Checked = True) Then
                ' Get orderbook
                v_strSQLString = "SP_BD_GETORDERBOOK_BYUSER"
                v_strClause = "TELLERID!" & mv_strTellerId & "!varchar2!20"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_SA_ALLCODE, gc_ActionInquiry, v_strSQLString, v_strClause, , , , , , , gc_CommandProcedure)
                v_ws.Message(v_strObjMsg)

            End If
            Dim v_taskinfo As New BindGridTaskInfo()
            v_taskinfo.xml = v_strObjMsg
            v_taskinfo.dgv = dgOrderBook
            v_taskinfo.dtype = "D"

            Threading.ThreadPool.QueueUserWorkItem(AddressOf BindData2DataGridViewHelper, v_taskinfo)
            'BindData2DataGridView(v_strObjMsg, dgOrderBook, "D")

            Dim v_lngNumberOfOrder As Long
            v_lngNumberOfOrder = dgOrderBook.RowCount
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            v_xmlTemporary = Nothing
            v_ws = Nothing
        End Try
    End Sub

    Public Overridable Sub GetSymbolInfor(ByVal v_strSYMBOL As String)

    End Sub

    Private Function OnGroupCancelOrder() As Boolean
        Dim v_ws As New BDSPalaceOrderManagement
        Dim v_strXMLBuilder As New StringBuilder
        Dim v_strErrorMessage As String
        Dim v_strErrorSource As String = "Main.frmBrokerDesk.OnGroupCancelOrder"
        Try
            'SUBMIT: CANCEL ORDER
            Dim v_strMsgConfirm, v_strEXECTYPE, v_strSYMBOL, v_strCUSTODYCD, v_strAFACCTNO, v_strPriceValue, v_strPriceType, v_strQTTY As String
            Dim v_strORDERID, v_strMessage, v_strFIELDNAME, v_strFIELDVALUE As String
            Dim v_lngReturn, i, v_Count As Long
            v_strORDERID = String.Empty
            v_Count = 0

            'Lấy danh sách các lệnh  được chọn hủy
            If Me.tabPageOrders.Controls.Count > 0 And cboAFAcctno.SelectedIndex <> -1 Then
                v_strCUSTODYCD = mv_arrCustodyCode(cboAFAcctno.SelectedIndex)
                v_strAFACCTNO = mv_arrAccountNumber(cboAFAcctno.SelectedIndex)
                Dim v_IntCount_checked As Integer = 0
                ' neu chi chon mot lenh
                Dim v_dgData As DataGridView
                v_dgData = CType(tabPageOrders.Controls(0), DataGridView)
                For i = 0 To v_dgData.Rows.Count - 1 Step 1
                    If Not v_dgData.Rows(i).IsNewRow Then
                        v_strFIELDVALUE = v_dgData.Rows(i).Cells(c_GridSelectedColumn).Value.ToString.Trim
                        If v_strFIELDVALUE.Length > 0 Then
                            v_strEXECTYPE = v_dgData.Rows(i).Cells("EXECTYPE").Value
                            v_strPriceType = v_dgData.Rows(i).Cells("PRICETYPE").Value
                            If v_strEXECTYPE = "NB" Then
                                v_strEXECTYPE = "CB"
                            ElseIf v_strEXECTYPE = "NS" Or v_strEXECTYPE = "MS" Then
                                v_strEXECTYPE = "CS"
                            End If
                            v_strSYMBOL = v_dgData.Rows(i).Cells("SYMBOL").Value
                            v_strQTTY = v_dgData.Rows(i).Cells("REMAINQTTY").Value
                            If v_strPriceType = "LO" Then
                                v_strPriceValue = v_dgData.Rows(i).Cells("QUOTEPRICE").Value
                            Else
                                v_strPriceValue = v_strPriceType
                            End If
                            v_IntCount_checked += 1
                            ' neu count dc hai lenh: exit for
                            If (v_IntCount_checked = 2) Then
                                Exit For
                            End If

                        End If
                    End If
                Next
                If (v_IntCount_checked = 1) Then
                    v_strMsgConfirm = Me.mv_strOrderConfirmationMessage

                    v_strMsgConfirm = v_strMsgConfirm.Replace("$CUSTODYCD", v_strCUSTODYCD)
                    v_strMsgConfirm = v_strMsgConfirm.Replace("$AFACCTNO", v_strAFACCTNO)
                    v_strMsgConfirm = v_strMsgConfirm.Replace("$EXECTYPE", mv_ResourceManager.GetString(v_strEXECTYPE))
                    v_strMsgConfirm = v_strMsgConfirm.Replace("$SYMBOL", v_strSYMBOL)
                    v_strMsgConfirm = v_strMsgConfirm.Replace("$PRICE", v_strPriceValue)
                    v_strMsgConfirm = v_strMsgConfirm.Replace("$QTTY", FormatNumber(CLng(v_strQTTY), 0))
                Else
                    'Confirm hủy lệnh theo nhóm
                    v_strMsgConfirm = Me.mv_strGroupCancelOrderConfirmationMessage

                    ' neu dang chon view theo tieu khoan 
                    If (Me.RadioSubAcctno.Checked = True) Then
                        v_strMsgConfirm = v_strMsgConfirm.Replace("$CUSTODYCD", v_strCUSTODYCD)
                        v_strMsgConfirm = v_strMsgConfirm.Replace("$AFACCTNO", v_strAFACCTNO)
                    Else
                        v_strMsgConfirm = mv_ResourceManager.GetString("GROUP_CANCEL_ORDER_BYCUSTODYCD")
                        v_strMsgConfirm = v_strMsgConfirm.Replace("$CUSTODYCD", v_strCUSTODYCD)

                    End If
                End If


                Dim v_frmConfirm As New frmBrokerDeskConfirm
                v_frmConfirm.lblAccountInfor.Text = Me.lblCustomerInfo.Text
                v_frmConfirm.lblConfirmation.Text = v_strMsgConfirm
                v_frmConfirm.pnHeader.BackColor = pnODWorkingArea.BackColor
                v_frmConfirm.pnDetail.BackColor = Color.Black
                v_frmConfirm.lblConfirmation.ForeColor = Color.Yellow
                Dim frmResult As DialogResult = v_frmConfirm.ShowDialog()

                If frmResult = Windows.Forms.DialogResult.OK Then
                    Application.DoEvents()

                    'Optimized string process
                    v_strXMLBuilder.Append("<RootTrade FUNCNAME='PLACEORDER'><objPARA></objPARA><objBODY>")
                    'Old
                    v_strXMLBuilder.Append("<Order CLASS='CANCELORDER'>" + ControlChars.CrLf)
                    v_strXMLBuilder.Append("<TXDATE>" + Me.BusDate + "</TXDATE>" + ControlChars.CrLf)
                    v_strXMLBuilder.Append("<USERNAME>" + Me.TellerId + "</USERNAME>" + ControlChars.CrLf)
                    v_strXMLBuilder.Append("<ACCTNO>DATA_ORDERID</ACCTNO>" + ControlChars.CrLf)
                    v_strXMLBuilder.Append("<DIRECT>Y</DIRECT>" + ControlChars.CrLf)
                    v_strXMLBuilder.Append("<BOOK>A</BOOK>" + ControlChars.CrLf)
                    v_strXMLBuilder.Append("</Order>")

                    v_strXMLBuilder.Append("</objBODY></RootTrade>")

                    Dim v_strSampleXml As String = v_strXMLBuilder.ToString()
                    'Dim v_dgData As DataGridView
                    'v_dgData = CType(tabPageOrders.Controls(0), DataGridView)
                    'Hiện tại sẽ thực hiện hủy từng lệnh
                    'sau này nên tunning gửi cả bó để hủy trên HOST: có qui định số lệnh tối đa
                    v_dgData.SuspendLayout()
                    Dim v_starttime As DateTime = DateTime.Now
                    Dim v_countcancelorder As Integer = 0
                    For i = 0 To v_dgData.Rows.Count - 1 Step 1
                        If Not v_dgData.Rows(i).IsNewRow Then
                            v_strFIELDVALUE = v_dgData.Rows(i).Cells(c_GridSelectedColumn).Value.ToString.Trim
                            If v_strFIELDVALUE.Length > 0 Then
                                v_strORDERID = v_dgData.Rows(i).Cells("ORDERID").Value
                                'v_strMessage = "<RootTrade FUNCNAME='PLACEORDER'><objPARA></objPARA><objBODY>" + _
                                '    v_strXMLBuilder.ToString.Replace("DATA_ORDERID", v_strORDERID) + _
                                '    "</objBODY></RootTrade>"
                                v_strMessage = v_strSampleXml.Replace("DATA_ORDERID", v_strORDERID)
                                v_lngReturn = v_ws.PlaceOrder(v_strMessage)
                                v_countcancelorder += 1
                                v_strORDERID = String.Empty
                                If v_lngReturn <> ERR_SYSTEM_OK Then
                                    'Thông báo lỗi: và thoát khỏi hàm hủy theo nhóm luôn
                                    GetErrorFromMessage(v_strMessage, v_strErrorSource, v_lngReturn, v_strErrorMessage, Me.UserLanguage)
                                    Cursor.Current = Cursors.Default
                                    Me.txtFeedback.Text = v_strErrorMessage
                                    Return False
                                End If
                            End If
                        End If
                    Next
                    v_dgData.ResumeLayout()
                    'Thông báo hủy thành công cho nhóm
                    Dim v_endtime As DateTime = DateTime.Now
                    MessageBox.Show("Canceled: " & v_countcancelorder & " in " & (v_endtime - v_starttime).TotalSeconds)
                End If
            End If
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        Finally
            v_strXMLBuilder = Nothing
            v_ws = Nothing
        End Try
    End Function
    Private Function OnGroupCancelOrderTabAccount() As Boolean
        Dim v_ws As New BDSPalaceOrderManagement
        Dim v_strXMLBuilder As New StringBuilder
        Dim v_strErrorMessage As String

        Dim v_strErrorSource As String = "Main.frmBrokerDesk.OnGroupCancelOrder"
        Try
            'SUBMIT: CANCEL ORDER
            Dim v_strMsgConfirm, v_strEXECTYPE, v_strSYMBOL, v_strCUSTODYCD, v_strAFACCTNO, v_strPriceValue, v_strPriceType, v_strQTTY As String
            Dim v_strORDERID, v_strMessage, v_strFIELDNAME, v_strFIELDVALUE As String
            Dim v_lngReturn, i, v_Count As Long
            v_strORDERID = String.Empty
            v_Count = 0
            Dim v_IntCount_checked As Integer = 0
            'Lấy danh sách các lệnh  được chọn hủy
            If Me.pnOrders.Controls.Count > 0 And cboAFAcctno.SelectedIndex <> -1 Then
                v_strCUSTODYCD = mv_arrCustodyCode(cboAFAcctno.SelectedIndex)
                v_strAFACCTNO = mv_arrAccountNumber(cboAFAcctno.SelectedIndex)

                'Confirm hủy lệnh theo nhóm

                ' neu chi chon mot lenh
                Dim v_dgData As DataGridView
                v_dgData = CType(Me.pnOrders.Controls(0), DataGridView)
                For i = 0 To v_dgData.Rows.Count - 1 Step 1
                    If Not v_dgData.Rows(i).IsNewRow Then
                        v_strFIELDVALUE = v_dgData.Rows(i).Cells(c_GridSelectedColumn).Value.ToString.Trim
                        If v_strFIELDVALUE.Length > 0 Then
                            v_strCUSTODYCD = v_dgData.Rows(i).Cells("CUSTODYCD").Value
                            v_strAFACCTNO = v_dgData.Rows(i).Cells("AFACCTNO").Value
                            v_strEXECTYPE = v_dgData.Rows(i).Cells("EXECTYPE").Value
                            v_strPriceType = v_dgData.Rows(i).Cells("PRICETYPE").Value
                            If v_strEXECTYPE = "NB" Then
                                v_strEXECTYPE = "CB"
                            ElseIf v_strEXECTYPE = "NS" Or v_strEXECTYPE = "MS" Then
                                v_strEXECTYPE = "CS"
                            End If
                            v_strSYMBOL = v_dgData.Rows(i).Cells("SYMBOL").Value
                            v_strQTTY = v_dgData.Rows(i).Cells("REMAINQTTY").Value
                            If v_strPriceType = "LO" Then
                                v_strPriceValue = v_dgData.Rows(i).Cells("QUOTEPRICE").Value
                            Else
                                v_strPriceValue = v_strPriceType
                            End If
                            v_IntCount_checked += 1
                            ' neu count dc hai lenh: exit for
                            If (v_IntCount_checked = 2) Then
                                Exit For
                            End If

                        End If
                    End If
                Next
                If (v_IntCount_checked = 1) Then
                    v_strMsgConfirm = Me.mv_strOrderConfirmationMessage
                    
                    v_strMsgConfirm = v_strMsgConfirm.Replace("$CUSTODYCD", v_strCUSTODYCD)
                    v_strMsgConfirm = v_strMsgConfirm.Replace("$AFACCTNO", v_strAFACCTNO)
                    v_strMsgConfirm = v_strMsgConfirm.Replace("$EXECTYPE", mv_ResourceManager.GetString(v_strEXECTYPE))
                    v_strMsgConfirm = v_strMsgConfirm.Replace("$SYMBOL", v_strSYMBOL)
                    v_strMsgConfirm = v_strMsgConfirm.Replace("$PRICE", v_strPriceValue)
                    v_strMsgConfirm = v_strMsgConfirm.Replace("$QTTY", FormatNumber(CLng(v_strQTTY), 0))
                Else
                    v_strMsgConfirm = Me.mv_strGroupCancelOrderConfirmationMessage
                    ' neu khong chon view theo user
                    If (Me.ChkByUser.Checked = False) Then

                        If (Me.RadioSubAcctno.Checked = True) Then
                            v_strMsgConfirm = v_strMsgConfirm.Replace("$CUSTODYCD", v_strCUSTODYCD)
                            v_strMsgConfirm = v_strMsgConfirm.Replace("$AFACCTNO", v_strAFACCTNO)
                        Else
                            v_strMsgConfirm = mv_ResourceManager.GetString("GROUP_CANCEL_ORDER_BYCUSTODYCD")
                            v_strMsgConfirm = v_strMsgConfirm.Replace("$CUSTODYCD", v_strCUSTODYCD)

                        End If
                    Else
                        v_strMsgConfirm = mv_ResourceManager.GetString("GROUP_CANCEL_ORDER_BYUSER")
                        v_strMsgConfirm = v_strMsgConfirm.Replace("$TELLERID", Me.TellerId)
                    End If
                End If

               
                Dim v_frmConfirm As New frmBrokerDeskConfirm
                If (Me.ChkByUser.Checked = False) Then
                    v_frmConfirm.lblAccountInfor.Text = Me.lblCustomerInfo.Text
                Else
                    v_frmConfirm.lblAccountInfor.Text = ""
                End If
                v_frmConfirm.lblConfirmation.Text = v_strMsgConfirm
                v_frmConfirm.pnHeader.BackColor = pnODWorkingArea.BackColor
                v_frmConfirm.pnDetail.BackColor = Color.Black
                v_frmConfirm.lblConfirmation.ForeColor = Color.Yellow
                Dim frmResult As DialogResult = v_frmConfirm.ShowDialog()

                If frmResult = Windows.Forms.DialogResult.OK Then
                    Application.DoEvents()

                    'Optimized string process
                    v_strXMLBuilder.Append("<RootTrade FUNCNAME='PLACEORDER'><objPARA></objPARA><objBODY>")
                    'Old
                    v_strXMLBuilder.Append("<Order CLASS='CANCELORDER'>" + ControlChars.CrLf)
                    v_strXMLBuilder.Append("<TXDATE>" + Me.BusDate + "</TXDATE>" + ControlChars.CrLf)
                    v_strXMLBuilder.Append("<USERNAME>" + Me.TellerId + "</USERNAME>" + ControlChars.CrLf)
                    v_strXMLBuilder.Append("<ACCTNO>DATA_ORDERID</ACCTNO>" + ControlChars.CrLf)
                    v_strXMLBuilder.Append("<DIRECT>Y</DIRECT>" + ControlChars.CrLf)
                    v_strXMLBuilder.Append("<BOOK>A</BOOK>" + ControlChars.CrLf)
                    v_strXMLBuilder.Append("</Order>")

                    v_strXMLBuilder.Append("</objBODY></RootTrade>")

                    Dim v_strSampleXml As String = v_strXMLBuilder.ToString()
                    'Dim v_dgData As DataGridView
                    'v_dgData = CType(Me.pnOrders.Controls(0), DataGridView)
                    'Hiện tại sẽ thực hiện hủy từng lệnh
                    'sau này nên tunning gửi cả bó để hủy trên HOST: có qui định số lệnh tối đa
                    v_dgData.SuspendLayout()
                    Dim v_starttime As DateTime = DateTime.Now
                    Dim v_countcancelorder As Integer = 0
                    Dim v_strStatus As String = String.Empty
                    Dim v_intCountRejectCancel As Integer = 0
                    For i = 0 To v_dgData.Rows.Count - 1 Step 1
                        If Not v_dgData.Rows(i).IsNewRow Then
                            v_strFIELDVALUE = v_dgData.Rows(i).Cells(c_GridSelectedColumn).Value.ToString.Trim
                            If v_strFIELDVALUE.Length > 0 Then
                                v_strORDERID = v_dgData.Rows(i).Cells("ORDERID").Value
                                v_strStatus = v_dgData.Rows(i).Cells("ORSTATUS").Value


                                'v_strMessage = "<RootTrade FUNCNAME='PLACEORDER'><objPARA></objPARA><objBODY>" + _
                                '    v_strXMLBuilder.ToString.Replace("DATA_ORDERID", v_strORDERID) + _
                                '    "</objBODY></RootTrade>"
                                v_strMessage = v_strSampleXml.Replace("DATA_ORDERID", v_strORDERID)
                                v_lngReturn = v_ws.PlaceOrder(v_strMessage)

                                v_strORDERID = String.Empty
                                If v_lngReturn <> ERR_SYSTEM_OK Then
                                    If (v_IntCount_checked = 1) Then
                                        'Thông báo lỗi: và thoát khỏi hàm hủy theo nhóm luôn
                                        GetErrorFromMessage(v_strMessage, v_strErrorSource, v_lngReturn, v_strErrorMessage, Me.UserLanguage)
                                        Cursor.Current = Cursors.Default
                                        Me.txtFeedback.Text = v_strErrorMessage
                                        Return False
                                    Else
                                        ' cong vao so lenh ko the cancel
                                        v_intCountRejectCancel += 1

                                    End If

                                Else
                                    v_countcancelorder += 1

                                End If


                            End If
                        End If
                    Next
                    v_dgData.ResumeLayout()
                    'Thông báo hủy thành công cho nhóm
                    Dim v_endtime As DateTime = DateTime.Now
                    MessageBox.Show("Can't Canceled: " & v_intCountRejectCancel & ",Canceled: " & v_countcancelorder & " in " & (v_endtime - v_starttime).TotalSeconds)
                End If
            End If
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        Finally
            v_strXMLBuilder = Nothing
            v_ws = Nothing
        End Try
    End Function

    Private Function OnCancelOrder() As Boolean
        Dim v_ws As New BDSPalaceOrderManagement
        Dim v_strXMLBuilder As New StringBuilder
        Dim v_strErrorMessage As String
        Dim v_strErrorSource As String = "Main.frmBrokerDesk.OnCancelOrder"
        Try
            'SUBMIT: CANCEL ORDER
            Dim v_strMsgConfirm, v_strEXECTYPE, v_strSYMBOL, v_strCUSTODYCD, v_strAFACCTNO, v_strPriceValue, v_strPriceType, v_strQTTY As String
            Dim v_strORDERID, v_strMessage As String
            Dim v_lngReturn As Long
            v_strORDERID = String.Empty
            If Me.pnOrders.Controls.Count > 0 Then
                Dim v_dgData As DataGridView
                v_dgData = CType(pnOrders.Controls(0), DataGridView)
                v_strCUSTODYCD = v_dgData.SelectedRows.Item(0).Cells("CUSTODYCD").Value
                v_strORDERID = v_dgData.SelectedRows.Item(0).Cells("ORDERID").Value
                v_strAFACCTNO = v_dgData.SelectedRows.Item(0).Cells("AFACCTNO").Value
                v_strEXECTYPE = v_dgData.SelectedRows.Item(0).Cells("EXECTYPE").Value
                v_strPriceType = v_dgData.SelectedRows.Item(0).Cells("PRICETYPE").Value
                If v_strEXECTYPE = "NB" Then
                    v_strEXECTYPE = "CB"
                ElseIf v_strEXECTYPE = "NS" Or v_strEXECTYPE = "MS" Then
                    v_strEXECTYPE = "CS"
                End If
                v_strSYMBOL = v_dgData.SelectedRows.Item(0).Cells("SYMBOL").Value
                v_strQTTY = v_dgData.SelectedRows.Item(0).Cells("REMAINQTTY").Value
                If v_strPriceType = "LO" Then
                    v_strPriceValue = v_dgData.SelectedRows.Item(0).Cells("QUOTEPRICE").Value
                Else
                    v_strPriceValue = v_strPriceType
                End If
            End If

            If v_strORDERID.Length > 0 Then
                v_strMsgConfirm = Me.mv_strOrderConfirmationMessage
                v_strMsgConfirm = v_strMsgConfirm.Replace("$CUSTODYCD", v_strCUSTODYCD)
                v_strMsgConfirm = v_strMsgConfirm.Replace("$AFACCTNO", v_strAFACCTNO)
                v_strMsgConfirm = v_strMsgConfirm.Replace("$EXECTYPE", mv_ResourceManager.GetString(v_strEXECTYPE))
                v_strMsgConfirm = v_strMsgConfirm.Replace("$SYMBOL", v_strSYMBOL)
                v_strMsgConfirm = v_strMsgConfirm.Replace("$PRICE", v_strPriceValue)
                v_strMsgConfirm = v_strMsgConfirm.Replace("$QTTY", FormatNumber(CLng(v_strQTTY), 0))

                Dim v_frmConfirm As New frmBrokerDeskConfirm
                v_frmConfirm.lblAccountInfor.Text = Me.lblCustomerInfo.Text
                v_frmConfirm.lblConfirmation.Text = v_strMsgConfirm
                v_frmConfirm.pnHeader.BackColor = pnODWorkingArea.BackColor
                v_frmConfirm.pnDetail.BackColor = Color.Black
                v_frmConfirm.lblConfirmation.ForeColor = Color.Yellow
                Dim frmResult As DialogResult = v_frmConfirm.ShowDialog()

                If frmResult = Windows.Forms.DialogResult.OK Then
                    Application.DoEvents()
                    v_strXMLBuilder.Append("<Order CLASS='CANCELORDER'>" + ControlChars.CrLf)
                    v_strXMLBuilder.Append("<TXDATE>" + Me.BusDate + "</TXDATE>" + ControlChars.CrLf)
                    v_strXMLBuilder.Append("<USERNAME>" + Me.TellerId + "</USERNAME>" + ControlChars.CrLf)
                    v_strXMLBuilder.Append("<ACCTNO>" + v_strORDERID.Trim + "</ACCTNO>" + ControlChars.CrLf)
                    v_strXMLBuilder.Append("<DIRECT>Y</DIRECT>" + ControlChars.CrLf)
                    v_strXMLBuilder.Append("<BOOK>A</BOOK>" + ControlChars.CrLf)
                    v_strXMLBuilder.Append("</Order>")

                    v_strMessage = "<RootTrade FUNCNAME='PLACEORDER'><objPARA></objPARA><objBODY>" + v_strXMLBuilder.ToString + "</objBODY></RootTrade>"
                    v_lngReturn = v_ws.PlaceOrder(v_strMessage)
                    If v_lngReturn = ERR_SYSTEM_OK Then
                        v_strErrorMessage = mv_ResourceManager.GetString(v_strMessage)
                        If v_strErrorMessage.Trim.Length > 0 Then
                            v_strMessage = v_strErrorMessage
                        End If
                        txtFeedback.Text = v_strMessage
                        Return True
                    Else
                        'Thông báo lỗi
                        GetErrorFromMessage(v_strMessage, v_strErrorSource, v_lngReturn, v_strErrorMessage, Me.UserLanguage)
                        Cursor.Current = Cursors.Default
                        Me.txtFeedback.Text = v_strErrorMessage
                        Return False
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        Finally
            v_strXMLBuilder = Nothing
            v_ws = Nothing
        End Try
    End Function

    Private Function OnPlaceOrder() As Boolean
        Dim i, j As Integer
        Dim v_ws As New BDSPalaceOrderManagement
        Dim v_strXMLBuilder As New StringBuilder
        Dim v_strErrorMessage As String
        Dim v_strErrorSource As String = "Main.frmBrokerDesk.OnPlaceOrder"
        Try
            Dim v_dblRefPrice, v_dblFlPrice, v_dblCePrice, v_dblCurrPrice, v_dblOrderPrice As Double, v_strReturn As String, v_blnCancel As Boolean
            'Validate ma chung khoan
            Dim v_strSYMBOL As String = mskSymbol.Text.Trim.ToUpper
            Dim v_strCUSTODYCD, v_strTradePlace, v_strExectype, v_strPriceType, v_strPriceValue, v_strQTTY As String
            Dim v_strSSAFACCTNO As String
            v_strQTTY = Me.mskQtty.Text

            If v_strSYMBOL.Length > 0 Then
                If Me.cboExecType.SelectedIndex = 2 And Me.mskDFNo.Text.Trim.Length <= 0 Then
                    'MessageBox.Show(ResourceManager.GetString("msgMSINVALIDDEALNO"))
                    'mskPrice.Focus()
                    v_strReturn = mv_ResourceManager.GetString("msgMSINVALIDDEALNO")
                    Me.txtFeedback.Text = v_strReturn
                    Me.mskDFNo.Text = ""
                    Me.btnGetDeal.Focus()
                    Return False
                End If
                'Kiem tra xem So HD cua lenh dat la so hop dong tren deal da chon.
                If cboExecType.SelectedIndex = 2 AndAlso Not ValidOnDeal() Then
                    Return False
                End If
                If Me.mskPrice.Text.Trim.Length <= 0 Then
                    v_strReturn = mv_ResourceManager.GetString("INVALID_NUMBER")
                    Me.txtFeedback.Text = v_strReturn
                    Me.mskPrice.Focus()
                    Return False
                End If
                If Me.mskQtty.Text.Trim.Length <= 0 Then
                    v_strReturn = mv_ResourceManager.GetString("INVALID_NUMBER")
                    Me.txtFeedback.Text = v_strReturn
                    Me.mskQtty.Focus()
                    Return False
                End If
                v_blnCancel = GetInstrumentInformation(v_strTradePlace, v_strSYMBOL, v_dblRefPrice, v_dblFlPrice, v_dblCePrice, v_dblCurrPrice, v_strReturn)
                Me.txtFeedback.Text = String.Empty
                If v_blnCancel Then
                    mskSymbol.Text = v_strSYMBOL.ToUpper
                    lblSymbolInfo.Text = v_strReturn
                    SymbolInfoColor()
                    Me.txtFeedback.Text = String.Empty

                    'Mac dinh gia
                    If String.Compare(mv_strExchangeCode, "001") = 0 Then   'HoSE
                        If cboPriceType.SelectedIndex <> 0 Then
                            'Dat mac dinh neu la lenh thi truong
                            SetDefaultPrice()
                        End If
                        cboPriceType.Enabled = True
                    ElseIf String.Compare(mv_strExchangeCode, "002") = 0 Then   'HNX
                        If cboPriceType.SelectedIndex <> 0 Then
                            MessageBox.Show(ResourceManager.GetString("msgHNXINVALIDPRICE"))
                            mskPrice.Focus()
                            Return False
                        End If
                        cboPriceType.SelectedIndex = 0
                        cboPriceType.Enabled = False
                    End If

                    'Kiem tra khoi luong phai tron lo
                    If Not IsNumeric(v_strQTTY) Then
                        v_strReturn = mv_ResourceManager.GetString("INVALID_NUMBER")
                        Me.txtFeedback.Text = v_strReturn
                        Me.mskQtty.Focus()
                        Return False
                    Else
                        If CDbl(v_strQTTY) Mod Me.mv_dblTradeLot <> 0 Then
                            v_strReturn = mv_ResourceManager.GetString("INVALID_TRADELOT")
                            Me.txtFeedback.Text = v_strReturn
                            Me.mskQtty.Focus()
                            Return False
                        ElseIf CDbl(v_strQTTY) <= 0 Then
                            v_strReturn = mv_ResourceManager.GetString("QTTY_GREATER_THAN_0")
                            Me.txtFeedback.Text = v_strReturn
                            Me.mskQtty.Focus()
                            Return False
                        End If

                        'NamLP: UPCOM
                        If mv_strExchangeCode = "005" AndAlso CDbl(v_strQTTY) < mv_dblMinQtty Then
                            v_strReturn = mv_ResourceManager.GetString("QTTY_GREATER_THAN_MIN")
                            Me.txtFeedback.Text = v_strReturn
                            Me.mskQtty.Focus()
                            Return False
                        End If
                        If mv_strExchangeCode = "005" AndAlso CDbl(v_strQTTY) > mv_dblMaxQtty Then
                            v_strReturn = mv_ResourceManager.GetString("QTTY_LESS_THAN_MAX")
                            Me.txtFeedback.Text = v_strReturn
                            Me.mskQtty.Focus()
                            Return False
                        End If
                        'NamLP: UPCOM End

                    End If
                Else
                    v_strReturn = mv_ResourceManager.GetString("INVALID_SYMBOL")
                    Me.txtFeedback.Text = v_strReturn
                    Me.mskSymbol.Focus()
                    Return False
                End If
            Else
                v_strReturn = ResourceManager.GetString("msgINVALIDSYMBOL")
                Me.txtFeedback.Text = v_strReturn
                mskSymbol.Focus()
                Return False
            End If

            If IsShortSale Then
                Try
                    If Not mv_arrBorrowAccountNumber Is Nothing Then
                        If mv_arrBorrowAccountNumber(cboBorrowAFAcctno.SelectedIndex).Length <> 10 Then
                            v_strReturn = ResourceManager.GetString("msgCFBORROWERNOTFOUND")
                            Me.txtFeedback.Text = v_strReturn
                            mskBorrowCustodycd.Focus()
                            v_strSSAFACCTNO = ""
                            Return False
                        Else
                            v_strSSAFACCTNO = mv_arrBorrowAccountNumber(cboBorrowAFAcctno.SelectedIndex)
                        End If
                    Else
                        v_strReturn = ResourceManager.GetString("msgCFBORROWERNOTFOUND")
                        Me.txtFeedback.Text = v_strReturn
                        mskBorrowCustodycd.Focus()
                        v_strSSAFACCTNO = ""
                        Return False
                    End If
                Catch ex As Exception
                    v_strReturn = ResourceManager.GetString("msgCFBORROWERNOTFOUND")
                    Me.txtFeedback.Text = v_strReturn
                    mskBorrowCustodycd.Focus()
                    v_strSSAFACCTNO = ""
                    Return False
                End Try
            End If

            'CHECK SPECIAL ORDER: Lenh cua san HNX va HSX thi tham so tach lenh phai nam trong bien
            Dim v_nodeData As Xml.XmlNode, v_nodeList As Xml.XmlNodeList
            Dim v_strExchangeCode, v_strDIRECT, v_strSPLITOPTION As String
            Dim v_lngSplitValue, v_lngMIN_QTTY, v_lngMAX_QTTY, v_lngMIN_CNT, v_lngMAX_CNT As Long

            v_strSPLITOPTION = "N"
            v_lngSplitValue = 0
            If Not mv_xmlSPLITOPTION Is Nothing Then
                v_nodeList = mv_xmlSPLITOPTION.SelectNodes("/ObjectMessage/ObjData")
                For i = 0 To v_nodeList.Count - 1
                    'Xac dinh bien ve khoi luong theo tung exchange
                    For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            If CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "TRADEPLACE" Then
                                v_strExchangeCode = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "MIN_QTTY" Then
                                v_lngMIN_QTTY = CLng(.InnerText.ToString)
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "MAX_QTTY" Then
                                v_lngMAX_QTTY = CLng(.InnerText.ToString)
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "MIN_CNT" Then
                                v_lngMIN_CNT = CLng(.InnerText.ToString)
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "MAX_CNT" Then
                                v_lngMAX_CNT = CLng(.InnerText.ToString)
                            End If
                        End With
                    Next

                    If Me.cboOption.SelectedIndex <> 0 Then
                        'Lenh dac biet
                        If String.Compare(v_strExchangeCode, Me.mv_strExchangeCode) = 0 Then
                            If Me.mskSplitValue.Text.Trim.Length = 0 Or Me.mskSplitValue.Text.Trim = "0" Then
                                'Tu dong xe lenh theo khoi luong
                                v_strSPLITOPTION = "Q"
                                v_lngSplitValue = v_lngMAX_QTTY
                            Else
                                v_lngSplitValue = CLng(Me.mskSplitValue.Text)
                                If v_lngSplitValue = 0 Then
                                    v_strSPLITOPTION = "Q"
                                    v_lngSplitValue = v_lngMAX_QTTY
                                Else
                                    If Me.cboSplitOption.SelectedIndex = 0 Then
                                        v_strSPLITOPTION = "O"
                                        'SPLIT_COUNT
                                        If v_lngSplitValue < v_lngMIN_CNT Then
                                            v_strReturn = mv_ResourceManager.GetString("msgINVALIDMIN_CNT") _
                                                & ": " & FormatNumber(v_lngMIN_CNT.ToString, 0)
                                            Me.txtFeedback.Text = v_strReturn
                                            If mskSplitValue.Enabled Then
                                                mskSplitValue.Focus()
                                            End If
                                            Return False
                                        ElseIf v_lngSplitValue > v_lngMAX_CNT Then
                                            v_strReturn = mv_ResourceManager.GetString("msgINVALIDMAX_CNT") _
                                                & ": " & FormatNumber(v_lngMAX_CNT.ToString, 0)
                                            Me.txtFeedback.Text = v_strReturn
                                            If mskSplitValue.Enabled Then
                                                mskSplitValue.Focus()
                                            End If
                                            Return False
                                        Else
                                            'Sau khi tach theo so lenh thi khoi luong moi lenh phai nho hon MAX_VALUE
                                            If CDbl(v_strQTTY) \ v_lngSplitValue + _
                                                IIf(CDbl(v_strQTTY) Mod v_lngSplitValue > 0, 1, 0) > v_lngMAX_QTTY Then
                                                v_strReturn = mv_ResourceManager.GetString("msgINVALIDMAX_QTTY") _
                                                    & ": " & FormatNumber(v_lngMAX_QTTY.ToString, 0)
                                                Me.txtFeedback.Text = v_strReturn
                                                If mskSplitValue.Enabled Then
                                                    mskSplitValue.Focus()
                                                End If
                                                Return False
                                            End If
                                        End If
                                    Else
                                        v_strSPLITOPTION = "Q"
                                        'SPLIT_QTTY
                                        If v_lngSplitValue < v_lngMIN_QTTY Then
                                            v_strReturn = mv_ResourceManager.GetString("msgINVALIDMIN_QTTY") _
                                                    & ": " & FormatNumber(v_lngMIN_QTTY.ToString, 0)
                                            Me.txtFeedback.Text = v_strReturn
                                            If mskSplitValue.Enabled Then
                                                mskSplitValue.Focus()
                                            End If
                                            Return False
                                        ElseIf v_lngSplitValue > v_lngMAX_QTTY Then
                                            v_strReturn = mv_ResourceManager.GetString("msgINVALIDMAX_QTTY") _
                                                    & ": " & FormatNumber(v_lngMAX_QTTY.ToString, 0)
                                            Me.txtFeedback.Text = v_strReturn
                                            If mskSplitValue.Enabled Then
                                                mskSplitValue.Focus()
                                            End If
                                            Return False
                                        Else
                                            'Sau khi tach theo khoi luong thi so lenh phai nho hon so lenh tach toi da
                                            If CDbl(v_strQTTY) \ v_lngSplitValue + _
                                                IIf(CDbl(v_strQTTY) Mod v_lngSplitValue > 0, 1, 0) > v_lngMAX_CNT Then
                                                v_strReturn = mv_ResourceManager.GetString("msgINVALIDMAX_CNT") _
                                                    & ": " & FormatNumber(v_lngMAX_CNT.ToString, 0)
                                                Me.txtFeedback.Text = v_strReturn
                                                If mskSplitValue.Enabled Then
                                                    mskSplitValue.Focus()
                                                End If
                                                Return False
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                            'Valid OK
                            Exit For
                        End If
                        v_strDIRECT = "N"
                    Else
                        'Lenh thuong: tu dong xe lenh theo khoi luong
                        If String.Compare(v_strExchangeCode, Me.mv_strExchangeCode) = 0 Then
                            'Kiem tra khoi luong toi da
                            If CDbl(v_strQTTY) > v_lngMAX_QTTY Then
                                v_strReturn = mv_ResourceManager.GetString("msgINVALIDMAX_QTTY") _
                                        & ": " & FormatNumber(v_lngMAX_QTTY.ToString, 0)
                                Me.txtFeedback.Text = v_strReturn
                                If mskQtty.Enabled Then
                                    mskQtty.Focus()
                                End If
                                Return False
                            Else
                                v_strDIRECT = "Y" 'Verify tra ve message loi luon
                            End If
                        End If
                    End If
                Next
            End If
            'v_strDIRECT = "Y"
            v_strDIRECT = ConfigurationManager.AppSettings("Broker.IsDirect")

            'Cac tham so lenh
            Select Case Me.cboExecType.SelectedIndex
                Case 0
                    v_strExectype = "NB"
                Case 1
                    v_strExectype = "NS"
                Case 2
                    v_strExectype = "MS"
            End Select

            Select Case Me.cboPriceType.SelectedIndex
                Case 0
                    v_strPriceType = "LO"
                    v_strPriceValue = Me.mskPrice.Text.Trim
                    v_dblOrderPrice = CDbl(Me.mskPrice.Text.Trim)
                Case 1
                    v_strPriceType = "ATO"
                    v_strPriceValue = "ATO"
                    If String.Compare(v_strExectype, "NB") Then
                        v_dblOrderPrice = v_dblCePrice
                    Else
                        v_dblOrderPrice = v_dblFlPrice
                    End If
                    v_dblOrderPrice = v_dblOrderPrice / mv_dblTradeUnit
                Case 2
                    v_strPriceType = "ATC"
                    v_strPriceValue = "ATC"
                    If String.Compare(v_strExectype, "NB") Then
                        v_dblOrderPrice = v_dblCePrice
                    Else
                        v_dblOrderPrice = v_dblFlPrice
                    End If
                    v_dblOrderPrice = v_dblOrderPrice / mv_dblTradeUnit
                Case 3
                    v_strPriceType = "MP"
                    v_strPriceValue = "MP"
                    If String.Compare(v_strExectype, "NB") Then
                        v_dblOrderPrice = v_dblCePrice
                    Else
                        v_dblOrderPrice = v_dblFlPrice
                    End If
                    v_dblOrderPrice = v_dblOrderPrice / mv_dblTradeUnit
            End Select


            'Lay suc mua va suc ban hien tai
            'Dim v_dblBuyPower, v_dblTradeQtty As Double, v_lngRow, v_lngColumn As Long
            Dim v_dblTradeQtty As Double, v_lngRow, v_lngColumn As Long
            Dim v_strTradeQtty As String
            'v_dblBuyPower = 0
            v_dblTradeQtty = 0
            ' PhuongHT comment: doi cach lookup trade_qtty do them chuc nang view theo so luu ky

            'Dim v_dgData As DataGridView
            'If Me.pnSecuritiesInfo.Controls.Count > 0 Then
            '    v_dgData = CType(pnSecuritiesInfo.Controls(0), DataGridView)
            '    For v_lngRow = 0 To v_dgData.Rows.Count - 1 Step 1
            '        If v_dgData.Rows(v_lngRow).IsNewRow Then Exit For
            '        v_strReturn = v_dgData.Rows(v_lngRow).Cells("SYMBOL").Value.ToString.Trim
            '        If v_strReturn.Length = 0 Then Exit For
            '        If String.Compare(v_strReturn, v_strSYMBOL) = 0 Then
            '            v_strReturn = v_dgData.Rows(v_lngRow).Cells("TRADE_QTTY").Value.ToString
            '            If IsNumeric(v_strReturn) Then
            '                v_dblTradeQtty = CDbl(v_strReturn)
            '            End If
            '            Exit For
            '        End If
            '    Next
            'End If
            ' end of PhuongHT comment

            'Get securities available for trade

            Dim v_strSQLString, v_strClause, v_strObjMsg As String
            Dim v_ws_2 As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_xmlDocument As New Xml.XmlDocument


            v_strSQLString = "SP_BD_GETSEMASTAVLTRADE"
            v_strClause = "AFACCTNO!" & mv_arrAccountNumber(cboAFAcctno.SelectedIndex) & "!varchar2!20"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_SA_ALLCODE, gc_ActionInquiry, v_strSQLString, v_strClause, , , , , , , gc_CommandProcedure)
            v_ws_2.Message(v_strObjMsg)

            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            'v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData/Entry[@oldval='" & v_strSYMBOL & "']")
            Dim v_strValue, v_strFLDNAME As String
            For i = 0 To v_nodeList.Count - 1
                For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        If CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "SYMBOL" Then
                            v_strValue = .InnerText.ToString.ToUpper.Trim

                        ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "TRADE_QTTY" Then
                            v_strTradeQtty = .InnerText.ToString
                        End If
                    End With
                Next

                If String.Compare(v_strValue, v_strSYMBOL) = 0 Then
                    v_dblTradeQtty = CDbl(v_strTradeQtty)
                End If
            Next
            If Strings.Left(mv_arrCustodyCode(cboAFAcctno.SelectedIndex), 3) = AppSettings.Get("PrefixedCustodyCode") Then
                'Kiem tra so bo tren man hinh
                Select Case v_strExectype
                    Case "NB"
                        'TungNT added - Neu la kh corebank thi khong phai check suc mua dat lenh, se hold sau
                        If mv_arrAccountCoreBank(cboAFAcctno.SelectedIndex) <> "Y" Then
                            If v_dblOrderPrice * mv_dblTradeUnit * CDbl(Me.mskQtty.Text) > mv_dblPPSE Then
                                'Thong bao khong du so du tien
                                v_strReturn = mv_ResourceManager.GetString("NOT_ENOUGHT_BUYPOWER")
                                Me.txtFeedback.Text = v_strReturn
                                mskQtty.Focus()
                                Return False
                            End If
                        End If
                        'End
                    Case "NS"
                        If CDbl(Me.mskQtty.Text) > v_dblTradeQtty Then
                            'Thong bao khong du so du chung khoan
                            v_strReturn = mv_ResourceManager.GetString("NOT_ENOUGHT_TRADEQTTY")
                            Me.txtFeedback.Text = v_strReturn
                            mskQtty.Focus()
                            Return False
                        End If
                End Select
            End If

            'Kiem tra neu la tai khoan luu ky ben ngoai thi phai du so du
            'Neu khong du so du muon dat lenh tiep thi goi den giao dich luu ky them chung khoan hoăc tien
            If Strings.Left(mv_arrCustodyCode(cboAFAcctno.SelectedIndex), 3) <> AppSettings.Get("PrefixedCustodyCode") Then
                Dim v_LngAvlAmount As Long
                Dim v_dblFeeRate As Double
                v_dblFeeRate = OnGetDefFeerate(mv_arrAccountNumber(cboAFAcctno.SelectedIndex), v_strExectype, "N", "B", v_strPriceType, CStr(Me.mskSymbol.Tag))
                If v_strExectype = "NB" Then
                    v_LngAvlAmount = OnGetAVLAmount(mv_arrAccountNumber(cboAFAcctno.SelectedIndex), "NB")
                    If v_LngAvlAmount < Math.Round(v_dblOrderPrice * mv_dblTradeUnit * CDbl(Me.mskQtty.Text) * (100 + v_dblFeeRate) / 100, 0) Then
                        If MsgBox("Tài khoản lưu ký bên ngoài thiếu " & CStr(Math.Round(v_dblOrderPrice * mv_dblTradeUnit * CDbl(Me.mskQtty.Text) * (100 + v_dblFeeRate) / 100 - v_LngAvlAmount, 0)) & " tiền" & ControlChars.CrLf & "Bạn có muốn bổ sung thêm số tiền trên không?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Me.Text) = MsgBoxResult.Yes Then
                            Dim mv_frmTransactScreen As New frmTransact(mv_strLanguage)
                            Dim v_strFLDDEFVAL As String
                            'Truyen tham so giao dich
                            v_strFLDDEFVAL = "[88." & mv_arrCustodyCode(cboAFAcctno.SelectedIndex) & "][03." & mv_arrAccountNumber(cboAFAcctno.SelectedIndex) & "]" & _
                                            "[09." & v_LngAvlAmount & "][10." & Math.Round(v_dblOrderPrice * mv_dblTradeUnit * CDbl(Me.mskQtty.Text) * (100 + v_dblFeeRate) / 100 - v_LngAvlAmount, 0) & "]" & _
                                            "[11." & Math.Round(v_dblOrderPrice * mv_dblTradeUnit * CDbl(Me.mskQtty.Text) * (100 + v_dblFeeRate) / 100, 0) & "]"

                            mv_frmTransactScreen.ObjectName = gc_CI_DEPOSIT_OTHERACCOUNT
                            mv_frmTransactScreen.ModuleCode = "CI"
                            mv_frmTransactScreen.LocalObject = gc_IsNotLocalMsg
                            mv_frmTransactScreen.BranchId = Me.BranchId
                            mv_frmTransactScreen.TellerId = Me.TellerId
                            mv_frmTransactScreen.IpAddress = Me.IpAddress
                            mv_frmTransactScreen.WsName = Me.WsName
                            mv_frmTransactScreen.BusDate = Me.BusDate


                            mv_frmTransactScreen.DefaultValue = v_strFLDDEFVAL
                            mv_frmTransactScreen.AutoClosedWhenOK = True
                            mv_frmTransactScreen.ShowDialog()
                            If mv_frmTransactScreen.CancelClick Then
                                Exit Function
                            End If
                            mv_frmTransactScreen.Dispose()
                        End If
                    End If
                ElseIf v_strExectype = "NS" Then
                    v_LngAvlAmount = OnGetAVLAmount(mv_arrAccountNumber(cboAFAcctno.SelectedIndex) & CStr(Me.mskSymbol.Tag), "NS")
                    If v_LngAvlAmount < CDbl(Me.mskQtty.Text) Then
                        If MsgBox("Tài khoản lưu ký bên ngoài thiếu " & CStr(CDbl(Me.mskQtty.Text) - v_LngAvlAmount) & " chứng khoán" & ControlChars.CrLf & "Bạn có muốn bổ sung thêm số chứng khoán trên không?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Me.Text) = MsgBoxResult.Yes Then
                            Dim mv_frmTransactScreen As New frmTransact(mv_strLanguage)
                            Dim v_strFLDDEFVAL As String
                            'Truyen tham so giao dich
                            v_strFLDDEFVAL = "[88." & mv_arrCustodyCode(cboAFAcctno.SelectedIndex) & "][02." & mv_arrAccountNumber(cboAFAcctno.SelectedIndex) & "]" & _
                                            "[01." & CStr(Me.mskSymbol.Tag) & "][03." & mv_arrAccountNumber(cboAFAcctno.SelectedIndex) & CStr(Me.mskSymbol.Tag) & "]" & _
                                            "[09." & v_LngAvlAmount & "]" & _
                                            "[10." & CDbl(Me.mskQtty.Text) - v_LngAvlAmount & "]" & _
                                            "[11." & CDbl(Me.mskQtty.Text) & "]"
                            mv_frmTransactScreen.ObjectName = gc_SE_DEPOSIT_OTHERACCOUNT
                            mv_frmTransactScreen.ModuleCode = "SE"
                            mv_frmTransactScreen.LocalObject = gc_IsNotLocalMsg
                            mv_frmTransactScreen.BranchId = Me.BranchId
                            mv_frmTransactScreen.TellerId = Me.TellerId
                            mv_frmTransactScreen.IpAddress = Me.IpAddress
                            mv_frmTransactScreen.WsName = Me.WsName
                            mv_frmTransactScreen.BusDate = Me.BusDate


                            mv_frmTransactScreen.DefaultValue = v_strFLDDEFVAL
                            mv_frmTransactScreen.AutoClosedWhenOK = True
                            mv_frmTransactScreen.ShowDialog()
                            If mv_frmTransactScreen.CancelClick Then
                                Exit Function
                            End If
                            mv_frmTransactScreen.Dispose()
                        End If
                    End If
                End If
            End If

            Dim v_strMsgConfirm As String
            v_strMsgConfirm = Me.mv_strOrderConfirmationMessage
            v_strMsgConfirm = v_strMsgConfirm.Replace("$CUSTODYCD", mv_arrCustodyCode(cboAFAcctno.SelectedIndex))
            v_strMsgConfirm = v_strMsgConfirm.Replace("$AFACCTNO", mv_arrAccountNumber(cboAFAcctno.SelectedIndex))
            v_strMsgConfirm = v_strMsgConfirm.Replace("$EXECTYPE", mv_ResourceManager.GetString(v_strExectype))
            v_strMsgConfirm = v_strMsgConfirm.Replace("$SYMBOL", v_strSYMBOL)
            v_strMsgConfirm = v_strMsgConfirm.Replace("$PRICE", v_strPriceValue)
            v_strMsgConfirm = v_strMsgConfirm.Replace("$QTTY", FormatNumber(CLng(Me.mskQtty.Text), 0))

            Dim v_frmConfirm As New frmBrokerDeskConfirm
            v_frmConfirm.lblAccountInfor.Text = Me.lblCustomerInfo.Text
            v_frmConfirm.lblConfirmation.Text = v_strMsgConfirm
            v_frmConfirm.pnHeader.BackColor = pnODWorkingArea.BackColor
            v_frmConfirm.pnDetail.BackColor = Color.Black
            v_frmConfirm.lblConfirmation.ForeColor = pnODWorkingArea.BackColor
            Dim frmResult As DialogResult = v_frmConfirm.ShowDialog()

            Dim v_strMessage, v_lngReturn As String
            If frmResult = Windows.Forms.DialogResult.OK Then
                Application.DoEvents()
                'BUILD TRANSACTION
                v_strXMLBuilder.Append("<Order CLASS='PLACEORDER'>" + ControlChars.CrLf)
                v_strXMLBuilder.Append("<TXDATE>" + Me.BusDate + "</TXDATE>" + ControlChars.CrLf)
                v_strXMLBuilder.Append("<USERNAME>" + Me.TellerId + "</USERNAME>" + ControlChars.CrLf)
                v_strXMLBuilder.Append("<AFACCTNO>" + mv_arrAccountNumber(cboAFAcctno.SelectedIndex) + "</AFACCTNO>" + ControlChars.CrLf)
                v_strXMLBuilder.Append("<EXECTYPE>" + v_strExectype + "</EXECTYPE>" + ControlChars.CrLf)
                v_strXMLBuilder.Append("<TRADINGPWD>" + "" + "</TRADINGPWD>" + ControlChars.CrLf)
                v_strXMLBuilder.Append("<SYMBOL>" + Me.mskSymbol.Text + "</SYMBOL>" + ControlChars.CrLf)
                v_strXMLBuilder.Append("<CODEID>" + CStr(Me.mskSymbol.Tag) + "</CODEID>" + ControlChars.CrLf)
                v_strXMLBuilder.Append("<QUANTITY>" + Me.mskQtty.Text + "</QUANTITY>" + ControlChars.CrLf)
                v_strXMLBuilder.Append("<QUOTEPRICE>" + CStr(v_dblOrderPrice) + "</QUOTEPRICE>" + ControlChars.CrLf)
                v_strXMLBuilder.Append("<PRICE>" + CStr(v_dblOrderPrice) + "</PRICE>" + ControlChars.CrLf)
                v_strXMLBuilder.Append("<PRICETYPE>" + v_strPriceType + "</PRICETYPE>" + ControlChars.CrLf)
                v_strXMLBuilder.Append("<TIMETYPE>" + "T" + "</TIMETYPE>" + ControlChars.CrLf)
                v_strXMLBuilder.Append("<BOOK>" + "A" + "</BOOK>" + ControlChars.CrLf)
                v_strXMLBuilder.Append("<VIA>" + IIf(ViaChannel = "T", "T", "B") + "</VIA>" + ControlChars.CrLf)
                v_strXMLBuilder.Append("<DEALID>" + Trim(Me.mskDFNo.Text) + "</DEALID>" + ControlChars.CrLf)
                v_strXMLBuilder.Append("<DIRECT>" + v_strDIRECT + "</DIRECT>" + ControlChars.CrLf)
                v_strXMLBuilder.Append("<SPLITOPTION>" + v_strSPLITOPTION + "</SPLITOPTION>" + ControlChars.CrLf)
                v_strXMLBuilder.Append("<SPLITVALUE>" + v_lngSplitValue.ToString + "</SPLITVALUE>" + ControlChars.CrLf)
                v_strXMLBuilder.Append("<SSAFACCTNO>" + v_strSSAFACCTNO + "</SSAFACCTNO>" + ControlChars.CrLf)
                v_strXMLBuilder.Append("</Order>")
                v_strMessage = "<RootTrade FUNCNAME='PLACEORDER'><objPARA></objPARA><objBODY>" + v_strXMLBuilder.ToString + "</objBODY></RootTrade>"

                'Gọi hàm đặt lệnh theo chế độ Synchronous
                v_lngReturn = v_ws.PlaceOrder(v_strMessage)
                If v_lngReturn = ERR_SYSTEM_OK Then
                    'Lay dien giai tu file resource
                    v_strErrorMessage = mv_ResourceManager.GetString(v_strMessage)
                    If v_strErrorMessage.Trim.Length > 0 Then
                        v_strMessage = v_strErrorMessage
                    End If
                    txtFeedback.Text = v_strMessage
                    Me.mskQtty.Text = "0"
                    Me.mskSymbol.Focus()    'mặc định về mã chứng khoán
                    Return True
                Else
                    'Thông báo lỗi
                    GetErrorFromMessage(v_strMessage, v_strErrorSource, v_lngReturn, v_strErrorMessage, Me.UserLanguage)
                    Cursor.Current = Cursors.Default
                    Me.txtFeedback.Text = v_strErrorMessage
                    Return False
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        Finally
            v_strXMLBuilder = Nothing
            v_ws = Nothing
        End Try
    End Function

    Private Function OnGetAVLAmount(ByVal pv_ACCTNO As String, ByVal pv_ExecType As String) As Long
        Dim v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Try
            'Neu la lan dau chay thi thoat luon
            If mb_blnIsFirstRun Then Exit Function

            Dim v_strSQLString, v_strClause, v_strValue, v_strFLDNAME As String, i, j As Integer

            'get trades
            v_strSQLString = "SP_BD_GETAVLAMOUNT"
            v_strClause = "pv_ACCTNO!" & pv_ACCTNO & "!varchar2!20^pv_EXECTYPE!" & pv_ExecType & "!varchar2!20"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_SA_ALLCODE, gc_ActionInquiry, v_strSQLString, v_strClause, , , , , , , gc_CommandProcedure)
            v_ws.Message(v_strObjMsg)

            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i = 0 To v_nodeList.Count - 1
                For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = Trim(.InnerText.ToString)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "AVLAMOUNT"
                                Return CDbl(IIf(v_strValue Is Nothing Or v_strValue.Length = 0, "0", v_strValue))
                        End Select
                    End With
                Next
            Next
            Return 0
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            v_xmlDocument = Nothing
            v_ws = Nothing
        End Try
    End Function

    Private Function OnGetDefFeerate(ByVal pv_ACCTNO As String, ByVal pv_ExecType As String, ByVal pv_MatchType As String, ByVal pv_via As String, ByVal pv_PriceType As String, ByVal pv_Codeid As String) As Double
        Dim v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Try
            'Neu la lan dau chay thi thoat luon
            If mb_blnIsFirstRun Then Exit Function

            Dim v_strSQLString, v_strClause, v_strValue, v_strFLDNAME As String, i, j As Integer

            'get trades
            v_strSQLString = "sp_bd_getdefFeerate"
            v_strClause = "pv_ACCTNO!" & pv_ACCTNO & "!varchar2!20" & _
                          "^pv_EXECTYPE!" & pv_ExecType & "!varchar2!20" & _
                          "^pv_MatchType!" & pv_MatchType & "!varchar2!20" & _
                          "^pv_via!" & pv_via & "!varchar2!20" & _
                          "^pv_PriceType!" & pv_PriceType & "!varchar2!20" & _
                          "^pv_Codeid!" & pv_Codeid & "!varchar2!20"

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_SA_ALLCODE, gc_ActionInquiry, v_strSQLString, v_strClause, , , , , , , gc_CommandProcedure)
            v_ws.Message(v_strObjMsg)

            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i = 0 To v_nodeList.Count - 1
                For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = Trim(.InnerText.ToString)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "DEFFEERATE"
                                Return CDbl(v_strValue)
                        End Select
                    End With
                Next
            Next
            Return 0
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            v_xmlDocument = Nothing
            v_ws = Nothing
        End Try
    End Function
#End Region

#Region " Private function "
    Private Sub checkInfomation_Customer() ' kiểm tra xem customer có phải cán bộ của tổ chức phát hành
        Dim v_strSYMBOL As String = mskSymbol.Text.Trim.ToUpper
        Dim v_ws As New BDSDeliveryManagement
        Dim v_strSQL As String = ""
        Dim v_strObjMsg As String = ""

        Try
            If Not cboAFAcctno.Items.Count > 0 Then Exit Sub 'Nếu chưa có khách hàng thì thoát luôn

            'mv_blnFlag = False
            Dim mv_xmlCUSTOMER As XmlDocumentEx
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_lngCount As Long
            Dim v_strCUSTID, v_strFULLNAME, v_COMPANYNAME, v_strCDCONTENT As String

            v_strSQL = "SELECT im.CUSTID, im.FULLNAME, im.COMPANYNAME,im.CDCONTENT FROM vw_ISSUER_MEMBER im WHERE im.CUSTID='" & Me.mv_strCUSTID & "'AND im.SYMBOL='" & v_strSYMBOL & "'"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)

            mv_xmlCUSTOMER = New XmlDocumentEx
            mv_xmlCUSTOMER.LoadXml(v_strObjMsg)
            If Not mv_xmlCUSTOMER Is Nothing Then
                v_nodeList = mv_xmlCUSTOMER.SelectNodes("/ObjectMessage/ObjData")
                v_lngCount = v_nodeList.Count
                If v_lngCount > 0 Then
                    For i As Integer = 0 To v_lngCount - 1
                        For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                            With v_nodeList.Item(i).ChildNodes(j)
                                If CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "CUSTID" Then
                                    v_strCUSTID = .InnerText.ToString
                                ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "FULLNAME" Then
                                    v_strFULLNAME = .InnerText.ToString
                                ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "COMPANYNAME" Then
                                    v_COMPANYNAME = .InnerText.ToString
                                ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "CDCONTENT" Then
                                    v_strCDCONTENT = .InnerText.ToString
                                End If
                            End With
                        Next
                    Next

                    Dim v_strISSUER_MEMBER As String = String.Empty
                    'Dim Dialog As DialogResult
                    v_strISSUER_MEMBER = mv_ResourceManager.GetString("ISSUER_MEMBER")
                    v_strISSUER_MEMBER = v_strISSUER_MEMBER.Replace("<<FULLNAME>>", v_strFULLNAME)
                    'v_strISSUER_MEMBER = v_strISSUER_MEMBER.Replace("<<CUSTID>>", v_strCUSTID)
                    v_strISSUER_MEMBER = v_strISSUER_MEMBER.Replace("<<COMPANYNAME>>", v_COMPANYNAME)
                    v_strISSUER_MEMBER = v_strISSUER_MEMBER.Replace("<<CDCONTENT>>", v_strCDCONTENT)

                    'lbl.Text = v_strISSUER_MEMBER
                    Dim DialogResult As DialogResult = MessageBox.Show(v_strISSUER_MEMBER, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                    If DialogResult = Windows.Forms.DialogResult.No Then
                        'mskCriteriaValue.Text = Mid(mskCriteriaValue.Text, 1, 4)
                        mskSymbol.Clear()
                        Me.mskCriteriaValue.Focus()
                        Exit Sub
                    Else
                        Me.mskQtty.Focus()
                    End If
                    'mv_blnFlag = True
                Else
                    'lblInfo.Text = ""
                    Exit Sub
                End If

            Else
                MessageBox.Show(mv_ResourceManager.GetString("INVALIDCUSTODYCD"), Me.Text, MessageBoxButtons.OK)
            End If
        Catch ex As Exception
            '..........
            MessageBox.Show(ex.Message)
        Finally
            '..........
            v_ws = Nothing
        End Try

    End Sub

    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Function OnExport(ByVal v_dgDataGrid As DataGridView) As Boolean
        Dim v_strFileName, v_strData As String, iX, iY, iColumn, intFreeFile As Integer
        Try
            Dim v_dlgSave As New SaveFileDialog
            v_dlgSave.Filter = "Text files (*.txt)|*.txt|Excel files (*.xls)|*.xls|All files (*.*)|*.*"
            v_dlgSave.RestoreDirectory = True
            Dim v_res As DialogResult = v_dlgSave.ShowDialog(Me)
            If v_res = DialogResult.OK Then
                v_strFileName = v_dlgSave.FileName
                Dim v_streamWriter As New StreamWriter(v_strFileName, False, System.Text.Encoding.Unicode)

                If (v_dgDataGrid.RowCount > 0) Then
                    'Column header
                    iColumn = 1
                    For iY = 0 To v_dgDataGrid.ColumnCount - 1
                        If v_dgDataGrid.Columns(iY).Visible Then
                            v_strData &= v_dgDataGrid.Columns(iY).HeaderText & vbTab
                            iColumn = iColumn + 1
                        End If
                    Next
                    v_streamWriter.WriteLine(v_strData)

                    'Data
                    For iX = 0 To v_dgDataGrid.RowCount - 1
                        v_strData = String.Empty
                        iColumn = 1
                        If Not v_dgDataGrid.Rows(iX).IsNewRow Then
                            For iY = 0 To v_dgDataGrid.ColumnCount - 1
                                If v_dgDataGrid.Columns(iY).Visible Then
                                    v_strData &= v_dgDataGrid(iY, iX).Value.ToString & vbTab
                                    iColumn = iColumn + 1
                                End If
                            Next
                            v_streamWriter.WriteLine(v_strData)
                        End If
                    Next
                Else
                    MsgBox(mv_ResourceManager.GetString("NothingToExport"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    Exit Function
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
    End Function

    Private Function ExportDataGrid2Excel(ByVal v_dgDataGrid As DataGridView) As Boolean
        Dim v_strFile, v_strData As String, iX, iY, iColumn, intFreeFile As Integer
        Try
            Dim dlg As New SaveFileDialog
            dlg.FileName = "Excel" ' Default file name
            dlg.DefaultExt = ".xlsx" ' Default file extension
            dlg.Filter = "Excel documents (.xlsx)|*.xlsx" ' Filter files by extension
            dlg.RestoreDirectory = True
            ' Show save file dialog box
            Dim ret As Boolean = dlg.ShowDialog()
            ' Process save file dialog box results
            If ret Then
                ' Save document
                v_strFile = dlg.FileName
            Else
                Return False



            End If

            Dim excel As New Excel.Application
            Dim wBook As Excel.Workbook
            Dim wSheet As Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()

            'Column header
            iColumn = 1
            For iY = 0 To v_dgDataGrid.ColumnCount - 1
                If v_dgDataGrid.Columns(iY).Visible Then
                    excel.Cells(1, iColumn) = v_dgDataGrid.Columns(iY).HeaderText
                    iColumn = iColumn + 1
                End If
            Next
            'Data
            For iX = 0 To v_dgDataGrid.RowCount - 1
                v_strData = String.Empty
                iColumn = 1
                If Not v_dgDataGrid.Rows(iX).IsNewRow Then
                    For iY = 0 To v_dgDataGrid.ColumnCount - 1
                        If v_dgDataGrid.Columns(iY).Visible Then
                            CType(excel.Cells(iX + 2, iColumn), Excel.Range).NumberFormat = Nothing
                            excel.Cells(iX + 2, iColumn) = v_dgDataGrid(iY, iX).Value.ToString
                            iColumn = iColumn + 1
                        End If
                    Next
                End If
            Next

            wBook.SaveAs(v_strFile)
            excel.Workbooks.Open(v_strFile)
            excel.Visible = True

        Catch ex As Exception
            Me.txtFeedback.Text = ex.Message
        Finally

        End Try
    End Function

    Private Sub SearchByCriteria()
        Dim v_strSEARCHBY, v_strSEARCHVALUE, v_strRETURN As String
        Select Case Me.cboCFSrchCriteria.SelectedIndex
            Case 0  'CUSTODYCD
                v_strSEARCHBY = "CFCUSTODYCD"
            Case 1  'AFACCTNO
                v_strSEARCHBY = "ACCTNO"
            Case 2  'IDCODE
                v_strSEARCHBY = "IDCODE"
            Case 3  'CUSTID
                v_strSEARCHBY = "CFCUSTID"
            Case Else
                v_strSEARCHBY = String.Empty
        End Select
        v_strSEARCHVALUE = mskCriteriaValue.Text.ToUpper
        If Me.mv_strOldSearchBy <> v_strSEARCHBY Or Me.mv_strOldSearchValue <> v_strSEARCHVALUE Then
            mv_strOldSearchBy = v_strSEARCHBY
            mv_strOldSearchValue = v_strSEARCHVALUE
            If v_strSEARCHBY.Length > 0 Then GetCustomerSubAccount(v_strSEARCHBY, v_strSEARCHVALUE, v_strRETURN)
            If cboAFAcctno.Items.Count > 0 Then cboAFAcctno.SelectedIndex = 0
            lblCustomerInfo.Text = v_strRETURN
            mskCriteriaValue.Text = v_strSEARCHVALUE
            If v_strRETURN.Length = 0 Then
                v_strRETURN = mv_ResourceManager.GetString("CF_NOT_FOUND")
                'e.Cancel = True
                Me.txtFeedback.Text = v_strRETURN
                mv_blnCustomerFound = False
            Else
                Me.txtFeedback.Text = String.Empty
                'refresh màn hình
                onRefresh()
                mv_blnCustomerFound = True
            End If
        Else
            Me.txtFeedback.Text = String.Empty
            mv_blnCustomerFound = True
        End If
    End Sub

    Private Sub SearchBorrowerAccount()
        Dim v_strSEARCHBY, v_strSEARCHVALUE, v_strRETURN As String
        v_strSEARCHBY = "CFCUSTODYCD"
        v_strSEARCHVALUE = mskBorrowCustodycd.Text.ToUpper
        GetBorrowerCustomerSubAccount(v_strSEARCHBY, v_strSEARCHVALUE, v_strRETURN)
        If cboBorrowAFAcctno.Items.Count > 0 Then cboBorrowAFAcctno.SelectedIndex = 0
        If v_strRETURN.Length = 0 Then
            v_strRETURN = mv_ResourceManager.GetString("msgCFBORROWERNOTFOUND")
            'e.Cancel = True
            Me.txtFeedback.Text = v_strRETURN
        Else
            Me.txtFeedback.Text = String.Empty
        End If
    End Sub

    'Private Sub GetMarginInfo(ByVal v_strAFACCTNO As String, ByVal v_strSYMBOL As String, ByRef v_strRETURN As String)
    '    Try
    '        Dim v_nodeList As Xml.XmlNodeList
    '        Dim v_xmlDocument As New Xml.XmlDocument
    '        Dim v_strValue, v_strFLDNAME, v_strTEXT, v_strMINBRATIO, v_strMAXBRATIO As String, i, j As Integer
    '        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
    '        Dim v_strCmdSQL As String, v_strObjMsg As String
    '        Dim v_dblQP As Double
    '        v_strCmdSQL = " SELECT MR.MRTYPE,MR.ISPPUSED, NVL(RSK.MRRATIOLOAN,0) MRRATIOLOAN, NVL(MRPRICELOAN,0) MRPRICELOAN FROM AFMAST MST, AFTYPE AF, MRTYPE MR, (SELECT * FROM AFSERISK R,SBSECURITIES SB WHERE R.CODEID=SB.CODEID AND SB.SYMBOL = '" & v_strSYMBOL & "' ) RSK WHERE MST.ACCTNO ='" & v_strAFACCTNO & "' AND MST.ACTYPE=AF.ACTYPE AND AF.MRTYPE =MR.ACTYPE AND AF.ACTYPE =RSK.ACTYPE(+) "
    '        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_AFMAST, gc_ActionInquiry, v_strCmdSQL)
    '        v_ws.Message(v_strObjMsg)
    '        v_xmlDocument.LoadXml(v_strObjMsg)
    '        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

    '        For i = 0 To v_nodeList.Count - 1
    '            For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
    '                With v_nodeList.Item(i).ChildNodes(j)
    '                    'Ghi nhận thuật toán để kiểm tra và tính toán cho từng trư?ng c�ủa giao dịch
    '                    v_strValue = .InnerText.ToString
    '                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
    '                    Select Case Trim(v_strFLDNAME)
    '                        Case "MRTYPE"
    '                            mv_strMarginType = Trim(v_strValue)
    '                        Case "MRRATIOLOAN"
    '                            mv_dblMarginRatioRate = CDec(Trim(v_strValue))
    '                        Case "MRPRICELOAN"
    '                            mv_dblSecMarginPrice = CDec(Trim(v_strValue))
    '                        Case "ISPPUSED" '1: PPSE   0: PP0
    '                            mv_dblIsPPUsed = CDec(Trim(v_strValue))
    '                    End Select
    '                End With
    '            Next
    '        Next
    '        If mv_dblMarginRatioRate >= 100 Or mv_dblMarginRatioRate < 0 Then mv_dblMarginRatioRate = 0
    '        mv_dblSecMarginPrice = IIf(mv_dblMarginPrice > mv_dblSecMarginPrice, mv_dblSecMarginPrice, mv_dblMarginPrice)

    '        If IsNumeric(Me.mskPrice.Text.Trim) Then
    '            v_dblQP = CDbl(Me.mskPrice.Text.Trim) * mv_dblTradeUnit
    '            If v_dblQP < mv_dblFloorPrice Then
    '                v_dblQP = mv_dblFloorPrice
    '            End If
    '        Else
    '            v_dblQP = mv_dblFloorPrice
    '        End If

    '        mv_dblPPSE = FRound(CDbl(Me.mv_dblPURCHASINGPOWER) / (1 - mv_dblMarginRatioRate / 100 * mv_dblSecMarginPrice / v_dblQP), 0)
    '        mv_dblPPSE = IIf(mv_dblPPSE > mv_dblAVLLIMIT, mv_dblAVLLIMIT, mv_dblPPSE)
    '        If (mv_dblFloorPrice <> 0) Then
    '            mv_dblMaxBuyQtty = FRound(mv_dblPPSE / mv_dblFloorPrice, 0)
    '        Else
    '            mv_dblMaxBuyQtty = 1000000
    '        End If
    '        v_strRETURN = ResourceManager.GetString("msgCREDITLINEDESCRIPTION")
    '        v_strRETURN = v_strRETURN.Replace("$PPSE", FormatNumber(mv_dblPPSE, 0))
    '        v_strRETURN = v_strRETURN.Replace("$LOANRATE", FormatNumber(mv_dblMarginRatioRate, 1))
    '        v_strRETURN = v_strRETURN.Replace("$LOANPRICE", FormatNumber(mv_dblSecMarginPrice, 0))
    '        v_strRETURN = v_strRETURN.Replace("$MAXBUYQTTY", FormatNumber(mv_dblMaxBuyQtty, 0))
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Private Sub GetMarginInfo(ByVal v_strAFACCTNO As String, ByVal v_strSYMBOL As String, ByRef v_strRETURN As String)
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_strValue, v_strFLDNAME, v_strTEXT, v_strMINBRATIO, v_strMAXBRATIO As String, i, j As Integer
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_strCmdSQL As String, v_strObjMsg As String
            Dim v_dblQP, v_dblISLATETRANSFER As Double
            v_strCmdSQL = " SELECT MST.ADVANCELINE, nvl(LNT.CHKSYSCTRL,'N') CHKSYSCTRL, NVL(RSK.ISMARGINALLOW,'N') ISMARGINALLOW, " & ControlChars.CrLf _
                        & " fn_getmaxdeffeerate('" & v_strAFACCTNO & "') DEFFEERATE, MRT.MRTYPE,MRT.ISPPUSED, NVL(RSK.MRRATIOLOAN,0) MRRATIOLOAN, " & ControlChars.CrLf _
                        & " NVL(MRPRICELOAN,0) MRPRICELOAN, fn_getppavlroom(RSK.CODEID,MST.ACCTNO) PRAVLLIMIT, nvl(b.TRFT0AMT,0) TRFT0AMT, nvl(b.buyamt,0) * (mst.trfbuyrate/100)  + (case when mst.trfbuyrate > 0 then nvl(b.buyfeeacr,0) else 0 end) T0SECUREAMT, (MST.TRFBUYRATE * MST.TRFBUYEXT) ISLATETRANSFER " & ControlChars.CrLf _
                        & " FROM AFMAST MST, AFTYPE AFT, LNTYPE LNT, MRTYPE MRT,  " & ControlChars.CrLf _
                        & "     (SELECT R.* FROM AFSERISK R,SBSECURITIES SB WHERE R.CODEID=SB.CODEID AND SB.SYMBOL = '" & v_strSYMBOL & "' ) RSK,  " & ControlChars.CrLf _
                        & "     v_getbuyorderinfo b  " & ControlChars.CrLf _
                        & " WHERE MST.ACCTNO ='" & v_strAFACCTNO & "' AND MST.ACTYPE=AFT.ACTYPE AND AFT.MRTYPE =MRT.ACTYPE AND AFT.ACTYPE =RSK.ACTYPE(+) AND AFT.LNTYPE = LNT.ACTYPE(+) AND MST.ACCTNO = b.AFACCTNO(+) "
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_AFMAST, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            For i = 0 To v_nodeList.Count - 1
                For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        'Ghi nhận thuật toán để kiểm tra và tính toán cho từng trư?ng c�ủa giao dịch
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "MRTYPE"
                                mv_strMarginType = Trim(v_strValue)
                            Case "CHKSYSCTRL"
                                mv_strChkSysCtrl = Trim(v_strValue)
                            Case "ISMARGINALLOW"
                                mv_strIsMarginAllow = Trim(v_strValue)
                            Case "MRRATIOLOAN"
                                mv_dblMarginRatioRate = CDec(Trim(v_strValue))
                            Case "MRPRICELOAN"
                                mv_dblSecMarginPrice = CDec(Trim(v_strValue))
                            Case "ISPPUSED" '1: PPSE   0: PP0
                                mv_dblIsPPUsed = CDec(Trim(v_strValue))
                            Case "DEFFEERATE"
                                mv_dblDefFeeRate = CDec(Trim(v_strValue))
                            Case "PRAVLLIMIT"
                                mv_dblPRAvlLimit = CDec(Trim(v_strValue))
                            Case "ADVANCELINE"
                                mv_dblAdvanceLine = CDec(Trim(v_strValue))
                            Case "TRFT0AMT"
                                mv_dblTrfT0Amt = CDec(Trim(v_strValue))
                            Case "T0SECUREAMT"
                                mv_dblT0SecureAmt = CDec(Trim(v_strValue))
                            Case "ISLATETRANSFER"
                                v_dblISLATETRANSFER = CDec(Trim(v_strValue))
                        End Select
                    End With
                Next
            Next
            If mv_dblMarginRatioRate >= 100 Or mv_dblMarginRatioRate < 0 Then mv_dblMarginRatioRate = 0

            If IsNumeric(Me.mskPrice.Text.Trim) Then
                v_dblQP = CDbl(Me.mskPrice.Text.Trim) * mv_dblTradeUnit
                If v_dblQP < mv_dblFloorPrice Then
                    v_dblQP = mv_dblFloorPrice
                End If
            Else
                v_dblQP = mv_dblFloorPrice
            End If

            If mv_strChkSysCtrl = "Y" Then
                If mv_strIsMarginAllow = "N" Then
                    mv_dblMarginRatioRate = 0
                Else
                    mv_dblSecMarginPrice = Math.Min(mv_dblMarginRefPrice, mv_dblSecMarginPrice) ' IIf(mv_dblMarginRefPrice > mv_dblSecMarginPrice, mv_dblSecMarginPrice, mv_dblMarginRefPrice)
                End If
            Else
                mv_dblSecMarginPrice = Math.Min(mv_dblMarginPrice, mv_dblSecMarginPrice) 'IIf(mv_dblMarginPrice > mv_dblSecMarginPrice, mv_dblSecMarginPrice, mv_dblMarginPrice)
            End If

            If CDbl(Me.mv_dblPURCHASINGPOWER) > 0 AndAlso (1 - (mv_dblMarginRatioRate / 100) * mv_dblSecMarginPrice / v_dblQP * (1 - mv_dblDefFeeRate)) <> 0 AndAlso v_dblISLATETRANSFER = 0 Then
                mv_dblPPSE = FRound(CDbl(Me.mv_dblPURCHASINGPOWER) / (1 - (mv_dblMarginRatioRate / 100) * mv_dblSecMarginPrice / v_dblQP * (1 - mv_dblDefFeeRate)) - mv_dblT0SecureAmt + Math.Max(mv_dblAdvanceLine - mv_dblTrfT0Amt, 0), 0)
            Else
                mv_dblPPSE = CDbl(Me.mv_dblPURCHASINGPOWER) - mv_dblT0SecureAmt + Math.Max(mv_dblAdvanceLine - mv_dblTrfT0Amt, 0)
            End If

            'PPse vs han muc Room.
            mv_dblPPSE = Math.Min(mv_dblPPSE, CDbl(Me.mv_dblPURCHASINGPOWER) - mv_dblT0SecureAmt + Math.Max(mv_dblAdvanceLine - mv_dblTrfT0Amt, 0) + mv_dblPRAvlLimit)

            mv_dblPPSE = IIf(mv_dblPPSE > mv_dblAVLLIMIT, mv_dblAVLLIMIT, mv_dblPPSE)
            If (v_dblQP <> 0) Then
                mv_dblMaxBuyQtty = FRound(mv_dblAVLLIMIT / v_dblQP, 0)
            Else
                mv_dblMaxBuyQtty = 1000000
            End If
            v_strRETURN = ResourceManager.GetString("msgCREDITLINEDESCRIPTION")
            v_strRETURN = v_strRETURN.Replace("$PPSE", FormatNumber(mv_dblPPSE, 0))
            v_strRETURN = v_strRETURN.Replace("$LOANRATE", FormatNumber(mv_dblMarginRatioRate, 1))
            v_strRETURN = v_strRETURN.Replace("$LOANPRICE", FormatNumber(mv_dblSecMarginPrice, 0))
            v_strRETURN = v_strRETURN.Replace("$MAXBUYQTTY", FormatNumber(mv_dblMaxBuyQtty, 0))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub InquiryDeal()
        Dim frm As New frmSearch(Me.UserLanguage)
        frm.TableName = "DFSELLDEAL"
        frm.ModuleCode = "DF"
        frm.AuthCode = "NNNNYYNNNN" 'Không cho phép thực hiện chức năng nào 
        frm.IsLocalSearch = gc_IsNotLocalMsg
        frm.IsLookup = "Y"
        frm.SearchOnInit = False
        frm.BranchId = Me.BranchId
        frm.TellerId = Me.TellerId
        frm.AFACCTNO = Trim(mv_arrAccountNumber(cboAFAcctno.SelectedIndex))
        'frm.mv_strSearchFilter = " AND DFTRADING>0 "
        frm.ShowDialog()
        Me.mskDFNo.Text = Trim(frm.ReturnValue)
        GetDealInfo(frm.ReturnValue)
        frm.Dispose()
    End Sub

    Private Sub OnQueryUserOrder()
        Dim frm As New frmSearchMaster(Me.UserLanguage)
        frm.TableName = "USERORDER"
        frm.ModuleCode = "OD"
        frm.AuthCode = "NYNNYYYYYYN"
        frm.AuthString = "YYYY"
        frm.IsLocalSearch = gc_IsNotLocalMsg
        frm.SearchOnInit = True
        frm.BranchId = Me.BranchId
        frm.TellerId = Me.TellerId

        frm.ShowDialog()
    End Sub

    Private Sub GetDealInfo(ByVal v_strDealID As String)
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_strReturn, v_strValue, v_strFLDNAME, v_strTEXT, v_strMINBRATIO, v_strMAXBRATIO As String, i, j As Integer
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_strCmdSQL As String, v_strObjMsg As String
            v_strCmdSQL = " SELECT * FROM v_getDealInfo A WHERE A.ACCTNO ='" & v_strDealID & "' AND A.DFTRADING>0 AND A.STATUS ='A'"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_AFMAST, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            If v_nodeList.Count > 0 Then
                For i = 0 To v_nodeList.Count - 1
                    For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            'Ghi nhận thuật toán để kiểm tra và tính toán cho từng trư?ng c�ủa giao dịch
                            v_strValue = .InnerText.ToString
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME)
                                Case "DFTRADING"
                                    Me.mskQtty.Text = Trim(v_strValue)
                                Case "SYMBOL"
                                    'Me.mskSymbol.Text = Trim(v_strValue)
                                    If v_strValue.Length > 0 Then
                                        Dim v_dblRefPrice, v_dblFlPrice, v_dblCePrice, v_dblCurrPrice As Double, v_strTradePlace As String, v_blnCancel As Boolean
                                        v_blnCancel = GetInstrumentInformation(v_strTradePlace, v_strValue, v_dblRefPrice, v_dblFlPrice, v_dblCePrice, v_dblCurrPrice, v_strReturn)
                                        Me.txtFeedback.Text = String.Empty
                                        If v_blnCancel Then
                                            mskSymbol.Text = v_strValue.ToUpper
                                            lblSymbolInfo.Text = v_strReturn
                                            SymbolInfoColor()
                                            Me.txtFeedback.Text = String.Empty
                                        Else
                                            v_strReturn = mv_ResourceManager.GetString("INVALID_SYMBOL")
                                            Me.txtFeedback.Text = v_strReturn
                                        End If
                                    End If
                            End Select
                        End With
                    Next
                Next
            Else
                'MsgBox(mv_ResourceManager.GetString("msgMSINVALIDDEALNO"), MsgBoxStyle.Information, Me.Text)
                'Me.ActiveControl = Me.btnGetDeal
                v_strReturn = mv_ResourceManager.GetString("msgMSINVALIDDEALNO")
                Me.txtFeedback.Text = v_strReturn
                Me.mskDFNo.Text = ""
                Me.btnGetDeal.Focus()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub dgPosition_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        Dim v_dgData As DataGridView
        v_dgData = CType(sender, DataGridView)
        Dim v_strValue, v_strReturn, v_strSYMBOL As String, v_dblQTTY, v_dblPRICE As Double
        If e.RowIndex < 0 Then Return
        If v_dgData.Rows(e.RowIndex).IsNewRow Then Return
        v_strValue = v_dgData.CurrentRow.Cells("TRADE_QTTY").Value
        If IsNumeric(v_strValue) Then
            If CDbl(v_strValue) > 0 Then
                v_strSYMBOL = v_dgData.CurrentRow.Cells("SYMBOL").Value
                GetSymbolInfor(v_strSYMBOL)
                Me.mskSymbol.Text = v_strSYMBOL
                Me.mskQtty.Text = v_strValue
                Me.cboExecType.SelectedIndex = 1
                If v_strSYMBOL.Length > 0 Then
                    Dim v_dblRefPrice, v_dblFlPrice, v_dblCePrice, v_dblCurrPrice As Double, v_strTradePlace As String, v_blnCancel As Boolean
                    v_blnCancel = GetInstrumentInformation(v_strTradePlace, v_strSYMBOL, v_dblRefPrice, v_dblFlPrice, v_dblCePrice, v_dblCurrPrice, v_strReturn)
                    Me.txtFeedback.Text = String.Empty
                    If v_blnCancel Then
                        mskSymbol.Text = v_strSYMBOL.ToUpper
                        lblSymbolInfo.Text = v_strReturn
                        SymbolInfoColor()
                        Me.txtFeedback.Text = String.Empty
                        Me.mskQtty.Focus()
                    Else
                        v_strReturn = mv_ResourceManager.GetString("INVALID_SYMBOL")
                        Me.txtFeedback.Text = v_strReturn
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub dgData_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.Space
                'Chỉ sử dụng cho tab lệnh chờ khớp 
                Dim i, iRow As Integer, v_strFIELDNAME, v_strFIELDVALUE As String
                mv_dgDataGrid = CType(sender, DataGridView)
                iRow = mv_dgDataGrid.CurrentRow.Index
                If iRow < 0 Then Return
                If mv_dgDataGrid.Rows(iRow).IsNewRow Then Return

                For i = 0 To mv_dgDataGrid.Columns.Count - 1 Step 1
                    v_strFIELDNAME = mv_dgDataGrid.Columns(i).Name
                    If String.Compare(v_strFIELDNAME, c_GridSelectedColumn) = 0 Then
                        v_strFIELDVALUE = mv_dgDataGrid.CurrentRow.Cells(c_GridSelectedColumn).Value.ToString.Trim
                        If v_strFIELDVALUE.Length = 0 Then
                            mv_dgDataGrid.CurrentRow.Cells(c_GridSelectedColumn).Value = c_GridSelectedValue
                        Else
                            mv_dgDataGrid.CurrentRow.Cells(c_GridSelectedColumn).Value = String.Empty
                        End If
                    End If
                Next
        End Select
    End Sub

    'Private Sub dgData_MultiSelectChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If Me.tabCtrlAccount.SelectedTab Is Me.tabPageOrders Then
    '        'Chỉ sử dụng cho tab lệnh chờ khớp 
    '        'Dim i, iRow As Integer
    '        Dim v_strFIELDNAME, v_strFIELDVALUE As String
    '        mv_dgDataGrid = CType(sender, DataGridView)

    '        'If select header, should return
    '        If mv_dgDataGrid.CurrentRow Is Nothing Then
    '            Return
    '        ElseIf mv_dgDataGrid.CurrentRow.Index < 0 Then
    '            Return
    '        End If
    '        'Dim hti As DataGridView.HitTestInfo = Grid.HitTest(e.X, e.Y)
    '        'mv_dgDataGrid.SuspendLayout()
    '        For i As Integer = 0 To mv_dgDataGrid.Rows.Count - 1 Step 1
    '            If Not mv_dgDataGrid.Rows(i).IsNewRow Then
    '                If mv_dgDataGrid.Rows(i).Selected Then
    '                    mv_dgDataGrid.Rows(i).Cells(c_GridSelectedColumn).Value = c_GridSelectedValue
    '                Else
    '                    mv_dgDataGrid.Rows(i).Cells(c_GridSelectedColumn).Value = String.Empty
    '                End If
    '            End If
    '        Next
    '        'mv_dgDataGrid.ResumeLayout()

    '    End If
    'End Sub

    Private Sub dgData_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs)
        If (Me.tabCtrlAccount.SelectedTab Is Me.tabPageOrders Or Me.tabCtrlAccount.SelectedTab Is Me.tabPageAccount) Then
            'Chỉ sử dụng cho tab lệnh chờ khớp , tab so du tieu khoan
            'Dim i, iRow As Integer
            Dim v_strFIELDNAME, v_strFIELDVALUE As String
            mv_dgDataGrid = CType(sender, DataGridView)

            If e.Button = Windows.Forms.MouseButtons.Left Then
                'If select header, should return
                If e.RowIndex < 0 Then
                    Return
                Else
                    'Only process if is first column
                    If (mv_dgDataGrid.Columns(e.ColumnIndex).Name = c_GridSelectedColumn) Then
                        If c_GridSelectedValue.Equals(mv_dgDataGrid.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then
                            mv_dgDataGrid.Rows(e.RowIndex).Cells(c_GridSelectedColumn).Value = String.Empty
                        Else
                            mv_dgDataGrid.Rows(e.RowIndex).Cells(c_GridSelectedColumn).Value = c_GridSelectedValue
                        End If
                    End If
                End If
            End If
            'Dim hti As DataGridView.HitTestInfo = Grid.HitTest(e.X, e.Y)
            'mv_dgDataGrid.SuspendLayout()
            'For i As Integer = 0 To mv_dgDataGrid.Rows.Count - 1 Step 1
            '    If Not mv_dgDataGrid.Rows(i).IsNewRow Then
            '        If mv_dgDataGrid.Rows(i).Selected Then
            '            mv_dgDataGrid.Rows(i).Cells(c_GridSelectedColumn).Value = c_GridSelectedValue
            '        Else
            '            mv_dgDataGrid.Rows(i).Cells(c_GridSelectedColumn).Value = String.Empty
            '        End If
            '    End If
            'Next
            'mv_dgDataGrid.ResumeLayout()

        End If
    End Sub
    'Private Sub dgData_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    '    'Chỉ sử dụng cho tab lệnh chờ khớp 
    '    Dim i, iRow As Integer, v_strFIELDNAME, v_strFIELDVALUE As String
    '    mv_dgDataGrid = CType(sender, DataGridView)
    '    iRow = mv_dgDataGrid.CurrentRow.Index
    '    If iRow < 0 Then Return
    '    If mv_dgDataGrid.Rows(iRow).IsNewRow Then Return

    '    For i = 0 To mv_dgDataGrid.Columns.Count - 1 Step 1
    '        v_strFIELDNAME = mv_dgDataGrid.Columns(i).Name
    '        If String.Compare(v_strFIELDNAME, c_GridSelectedColumn) = 0 Then
    '            v_strFIELDVALUE = mv_dgDataGrid.CurrentRow.Cells(c_GridSelectedColumn).Value.ToString.Trim
    '            If v_strFIELDVALUE.Length = 0 Then
    '                mv_dgDataGrid.CurrentRow.Cells(c_GridSelectedColumn).Value = c_GridSelectedValue
    '            Else
    '                mv_dgDataGrid.CurrentRow.Cells(c_GridSelectedColumn).Value = String.Empty
    '            End If
    '        End If
    '    Next
    'End Sub

    'Private Sub dgData_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)

    'End Sub

    Private Sub dgData_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        mv_dgDataGrid = CType(sender, DataGridView)
        'ToolStripManager.RevertMerge(ctxDataGrid, ctxSelectAll)
        'ToolStripManager.RevertMerge(ctxDataGrid, ctxMoveOrder)
        Try
            If e.Button = MouseButtons.Right Then
                If Not mv_dgDataGrid.Columns(c_GridSelectedColumn) Is Nothing Then
                    'ToolStripManager.Merge(ctxSelectAll, ctxDataGrid)
                    If mv_dgDataGrid.Equals(dgRemainOrder) Then
                        Dim v_hittestinfo As DataGridView.HitTestInfo = mv_dgDataGrid.HitTest(e.X, e.Y)
                        If v_hittestinfo.RowIndex >= 0 Then
                            Me.ctxDataGrid.Show(mv_dgDataGrid, New Point(e.X, e.Y))
                        End If
                    End If
                Else
                    If mv_dgDataGrid.DataMember = "OrderBook" Then
                        'ToolStripManager.Merge(ctxMoveOrder, ctxDataGrid)
                        Me.ctxDataGrid.Show(mv_dgDataGrid, New Point(e.X, e.Y))
                    Else
                        Me.ctxDataGrid.Show(mv_dgDataGrid, New Point(e.X, e.Y))
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Sub

    Private Sub dgDealFinancing_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        Dim v_dgData As DataGridView
        If IsShortSale Then
            Exit Sub
        End If
        v_dgData = CType(sender, DataGridView)
        Dim v_strValue, v_strReturn, v_strSYMBOL As String, v_dblQTTY, v_dblPRICE As Double
        If e.RowIndex < 0 Then Return
        If v_dgData.Rows(e.RowIndex).IsNewRow Then Return
        v_strValue = v_dgData.CurrentRow.Cells("DFTRADE").Value
        If IsNumeric(v_strValue) Then
            If CDbl(v_strValue) > 0 Then
                v_strSYMBOL = v_dgData.CurrentRow.Cells("SYMBOL").Value
                GetSymbolInfor(v_strSYMBOL)
                Me.mskSymbol.Text = v_strSYMBOL
                Me.mskQtty.Text = v_strValue
                Me.cboExecType.SelectedIndex = 2 'Lenh ban cam co
                Me.mskDFNo.Text = v_dgData.CurrentRow.Cells("DFACCTNO").Value
                If v_strSYMBOL.Length > 0 Then
                    Dim v_dblRefPrice, v_dblFlPrice, v_dblCePrice, v_dblCurrPrice As Double, v_strTradePlace As String, v_blnCancel As Boolean
                    v_blnCancel = GetInstrumentInformation(v_strTradePlace, v_strSYMBOL, v_dblRefPrice, v_dblFlPrice, v_dblCePrice, v_dblCurrPrice, v_strReturn)
                    Me.txtFeedback.Text = String.Empty
                    If v_blnCancel Then
                        mskSymbol.Text = v_strSYMBOL.ToUpper
                        lblSymbolInfo.Text = v_strReturn
                        SymbolInfoColor()
                        Me.txtFeedback.Text = String.Empty
                        Me.mskPrice.Focus()
                    Else
                        v_strReturn = mv_ResourceManager.GetString("INVALID_SYMBOL")
                        Me.txtFeedback.Text = v_strReturn
                        Me.mskDFNo.Text = ""
                        Me.btnGetDeal.Focus()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub dgPosition_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        Dim v_dgData As DataGridView
        v_dgData = CType(sender, DataGridView)
        Dim v_strValue, v_strReturn, v_strSYMBOL As String, v_dblQTTY, v_dblPRICE As Double
        If e.RowIndex < 0 Then Return
        If v_dgData.Rows(e.RowIndex).IsNewRow Then Return
        v_strValue = v_dgData.CurrentRow.Cells("TRADE_QTTY").Value
        If IsNumeric(v_strValue) Then
            If CDbl(v_strValue) > 0 Then
                v_strSYMBOL = v_dgData.CurrentRow.Cells("SYMBOL").Value
                GetSymbolInfor(v_strSYMBOL)
                Me.mskSymbol.Text = v_strSYMBOL
                Me.mskQtty.Text = v_strValue
                Me.cboExecType.SelectedIndex = 1
            End If
        End If
    End Sub

    Private Sub dgData_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs)
        Dim v_dgData As DataGridView
        v_dgData = CType(sender, DataGridView)
        Dim v_strValue, v_strReturn, v_strColName As String, v_dblQTTY, v_dblPRICE As Double
        If e.RowIndex < 0 Then Return
        If v_dgData.Rows(e.RowIndex).IsNewRow Then Return
        v_strColName = v_dgData.Columns(v_dgData.CurrentCell.ColumnIndex).Name
        If String.Compare(v_strColName, "MOVE_QTTY") = 0 Then
            v_strValue = e.FormattedValue.ToString
            If Not IsNumeric(v_strValue) Then
                Me.txtFeedback.Text = mv_ResourceManager.GetString("INVALID_NUMBER")
                e.Cancel = True
            Else
                v_dblQTTY = CDbl(v_dgData.CurrentRow.Cells("QTTY").Value)
                If v_dblQTTY < CDbl(v_strValue) Then
                    Me.txtFeedback.Text = mv_ResourceManager.GetString("INVALID_MOVE_QTTY")
                    e.Cancel = True
                Else
                    mv_dblCurrentMoveQtty = mv_dblCurrentMoveQtty + CDbl(v_strValue) - CDbl(v_dgData.CurrentRow.Cells("MOVE_QTTY").Value)
                    v_dblPRICE = CDbl(v_dgData.CurrentRow.Cells("PRICE").Value)
                    mv_dblCurrentMoveAmount = mv_dblCurrentMoveAmount + v_dblPRICE * (CDbl(v_strValue) - CDbl(v_dgData.CurrentRow.Cells("MOVE_QTTY").Value))
                    v_strReturn = mv_strDealMovingMessage.Replace("$BORS", Me.cboDealType.SelectedValue)
                    v_strReturn = v_strReturn.Replace("$SYMBOL", Me.mskDealSymbol.Text)
                    v_strReturn = v_strReturn.Replace("$QTTY", FormatNumber(mv_dblCurrentMoveQtty, 0))
                    v_strReturn = v_strReturn.Replace("$AMT", FormatNumber(mv_dblCurrentMoveAmount, 0))
                    Me.lblTotalDealMoving.Text = v_strReturn
                End If
            End If
        End If
    End Sub

    Private Sub SetDefaultPrice()
        'Dim v_strSYMBOL As String = mskSymbol.Text.Trim.ToUpper
        'If v_strSYMBOL.Length > 0 Then
        '    Dim v_strTradePlace As String
        '    Dim v_dblRefPrice, v_dblFlPrice, v_dblCePrice, v_dblCurrPrice As Double, v_strReturn As String, v_blnCancel As Boolean
        '    v_blnCancel = GetInstrumentInformation(v_strTradePlace, v_strSYMBOL, v_dblRefPrice, v_dblFlPrice, v_dblCePrice, v_dblCurrPrice, v_strReturn)
        '    If v_blnCancel Then
        '        'Da chon ma chung khoan
        '        If cboExecType.SelectedIndex = 0 Then
        '            'BUY
        '            Me.mskPrice.Text = FormatNumber(mv_dblCeilingPrice / mv_dblTradeUnit, -1)
        '        Else
        '            'SELL
        '            Me.mskPrice.Text = FormatNumber(mv_dblFloorPrice / mv_dblTradeUnit, -1)
        '        End If
        '    End If
        '    Me.mskPrice.Enabled = False
        'End If
    End Sub

    Private Sub AutoRefreshTabPage()
        If Not mb_blnIsFirstRun Then
            'Tự động Refresh màn hìnhD:\Working\BVSC\FlexBaseline\Source\FlexCustodian\@DIRECT\frmBrokerDesk-VN.resx
            If cboAFAcctno.Items.Count > 0 And Me.chkAutoRefresh.Checked Then
                onRefresh()
            End If
        End If
    End Sub

    Private Sub LoadResource(ByRef pv_ctrl As Windows.Forms.Control)
        Dim v_ctrl As Windows.Forms.Control

        For Each v_ctrl In pv_ctrl.Controls
            If TypeOf (v_ctrl) Is Label Then
                CType(v_ctrl, Label).Text = mv_ResourceManager.GetString(v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is RichTextBox Then
                CType(v_ctrl, RichTextBox).Text = mv_ResourceManager.GetString(v_ctrl.Name)
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

        'Nap du lieu ban dau
        Me.cboCFSrchCriteria.Items.Clear()
        Me.cboCFSrchCriteria.Items.Add(mv_ResourceManager.GetString("CFSRCH_CUSTODYCD"))
        Me.cboCFSrchCriteria.Items.Add(mv_ResourceManager.GetString("CFSRCH_ACCTNO"))
        Me.cboCFSrchCriteria.Items.Add(mv_ResourceManager.GetString("CFSRCH_IDCODE"))
        Me.cboCFSrchCriteria.Items.Add(mv_ResourceManager.GetString("CFSRCH_CUSTID"))
        cboCFSrchCriteria.SelectedIndex = 0

        Me.cboPriceType.Items.Clear()
        Me.cboPriceType.Items.Add(mv_ResourceManager.GetString("PRICE_LO"))
        Me.cboPriceType.Items.Add(mv_ResourceManager.GetString("PRICE_ATO"))
        Me.cboPriceType.Items.Add(mv_ResourceManager.GetString("PRICE_ATC"))
        Me.cboPriceType.Items.Add(mv_ResourceManager.GetString("PRICE_MP"))
        cboPriceType.SelectedIndex = 0

        Me.cboExecType.Items.Clear()
        Me.cboExecType.Items.Add(mv_ResourceManager.GetString("EXECTYPE_NB"))
        Me.cboExecType.Items.Add(mv_ResourceManager.GetString("EXECTYPE_NS"))
        Me.cboExecType.Items.Add(mv_ResourceManager.GetString("EXECTYPE_MS"))
        cboExecType.SelectedIndex = 0

        Me.cboDealType.Items.Clear()
        Me.cboDealType.Items.Add(mv_ResourceManager.GetString("EXECTYPE_NB"))
        Me.cboDealType.Items.Add(mv_ResourceManager.GetString("EXECTYPE_NS"))
        cboDealType.SelectedIndex = 0

        Me.cboOption.Items.Clear()
        Me.cboOption.Items.Add(mv_ResourceManager.GetString("OPTION_NORMAL"))
        Me.cboOption.Items.Add(mv_ResourceManager.GetString("OPTION_SPECIAL"))
        cboOption.SelectedIndex = 0

        Me.cboSplitOption.Items.Clear()
        Me.cboSplitOption.Items.Add(mv_ResourceManager.GetString("SPLIT_COUNT"))
        Me.cboSplitOption.Items.Add(mv_ResourceManager.GetString("SPLIT_QTTY"))
        cboSplitOption.SelectedIndex = 0

        Me.tabPageAccount.Text = mv_ResourceManager.GetString("tabPageAccount")
        Me.tabPageLoan.Text = mv_ResourceManager.GetString("tabPageLoan")
        Me.tabPageDeal.Text = mv_ResourceManager.GetString("tabPageDeal")
        Me.tabPageMoveDeal.Text = mv_ResourceManager.GetString("tabPageMoveDeal")
        Me.tabPageCustomer.Text = mv_ResourceManager.GetString("tabPageCustomer")
        Me.tabPageOrders.Text = mv_ResourceManager.GetString("tabPageOrders")
        Me.tabPageSecurities.Text = mv_ResourceManager.GetString("tabPageSecurities")
        'Me.lblCashInfo.Text = mv_ResourceManager.GetString("lblCashInfo")
        'Me.lblSecuritiesInfo.Text = mv_ResourceManager.GetString("lblSecuritiesInfo")
        Me.chkAutoRefresh.Text = mv_ResourceManager.GetString("chkAutoRefresh")
        Me.RadioCustodyCd.Text = mv_ResourceManager.GetString("RadioCustodyCD")
        Me.RadioSubAcctno.Text = mv_ResourceManager.GetString("RadioSubAcctno")
        Me.ChkByUser.Text = mv_ResourceManager.GetString("ChkByUser")
        mv_strGroupCancelOrderConfirmationMessage = mv_ResourceManager.GetString("GROUP_CANCEL_ORDER")
        mv_strOrderConfirmationMessage = mv_ResourceManager.GetString("ORDER_CONFIRM_MSG")
        mv_strDealMovingMessage = mv_ResourceManager.GetString("MOVE_DEAL_MSG")

        Export2ExcelToolStripMenuItem.Text = mv_ResourceManager.GetString("Export2ExcelToolStripMenuItem")
        SelectedAllToolStripMenuItem.Text = mv_ResourceManager.GetString("SelectedAllToolStripMenuItem")
        NoSelectedAllToolStripMenuItem.Text = mv_ResourceManager.GetString("NoSelectedAllToolStripMenuItem")
    End Sub

    Private Function GetInstrumentTickSize(ByVal v_strSYMBOL As String, ByVal v_dblQuotePrice As Double) As Double
        Dim v_nodeData As Xml.XmlNode, v_nodeList As Xml.XmlNodeList
        Dim v_strACTYPE, v_strValue, v_strFROMPRICE, v_strTOPRICE, v_strTICKSIZE As String
        Dim v_blnOK As Boolean = False
        Try
            v_strSYMBOL = v_strSYMBOL.Trim.ToUpper
            If Not mv_xmlSYMBOLTICKSIZE Is Nothing Then
                v_nodeList = mv_xmlSYMBOLTICKSIZE.SelectNodes("/ObjectMessage/ObjData")
                'v_nodeList = mv_xmlSYMBOLTICKSIZE.SelectNodes("/ObjectMessage/ObjData/Entry[@SYMBOL='" & v_strSYMBOL & "']")
                For i As Integer = 0 To v_nodeList.Count - 1
                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            If CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "SYMBOL" Then
                                v_strValue = .InnerText.ToString.ToUpper.Trim
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "TICKSIZE" Then
                                v_strTICKSIZE = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "FROMPRICE" Then
                                v_strFROMPRICE = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "TOPRICE" Then
                                v_strTOPRICE = .InnerText.ToString
                            End If
                        End With
                    Next

                    If String.Compare(v_strValue, v_strSYMBOL) = 0 Then
                        If v_dblQuotePrice >= CDbl(v_strFROMPRICE) And v_dblQuotePrice <= CDbl(v_strTOPRICE) Then
                            Return CDbl(v_strTICKSIZE)
                            v_blnOK = True
                            Exit For
                        End If
                    End If
                Next
            End If
            If v_blnOK = False Then
                Return 0
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
        End Try
    End Function


    'Private Function SetInstrumentInformation(ByVal v_strSYMBOL As String, ByVal v_dblReferencePrice As Double, _
    '    ByVal v_dblFloorPrice As Double, ByVal v_dblCeilingPrice As Double) As Boolean
    '    Dim v_nodeData As Xml.XmlNode, v_nodeList As Xml.XmlNodeList
    '    Dim v_strValue As String, v_idxRF, v_idxCE, v_idxFL As Integer
    '    Dim v_strXMLBuilder As New StringBuilder, v_strMessage As String, v_lngReturn As Long
    '    Dim v_ws As New BDSPalaceOrderManagement
    '    Try
    '        If (mv_dblRefPrice <> v_dblReferencePrice Or mv_dblFloorPrice <> v_dblFloorPrice Or mv_dblCeilingPrice <> v_dblCeilingPrice) _
    '            And Not mv_xmlSYMBOLSLIST Is Nothing Then
    '            'Tim den node co ma chung khoan
    '            v_nodeList = mv_xmlSYMBOLSLIST.SelectNodes("/ObjectMessage/ObjData")
    '            For i As Integer = 0 To v_nodeList.Count - 1
    '                v_idxRF = 0
    '                v_idxFL = 0
    '                v_idxCE = 0
    '                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
    '                    With v_nodeList.Item(i).ChildNodes(j)
    '                        If CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "SYMBOL" Then
    '                            v_strValue = .InnerText.ToString
    '                        ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "BASICPRICE" Then
    '                            v_idxRF = j
    '                        ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "FLOORPRICE" Then
    '                            v_idxFL = j
    '                        ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "CEILINGPRICE" Then
    '                            v_idxCE = j
    '                        End If
    '                    End With
    '                Next

    '                If v_strSYMBOL = v_strValue.Trim.ToUpper Then
    '                    v_nodeList.Item(i).ChildNodes(v_idxRF).InnerText = v_dblReferencePrice.ToString
    '                    v_nodeList.Item(i).ChildNodes(v_idxFL).InnerText = v_dblFloorPrice.ToString
    '                    v_nodeList.Item(i).ChildNodes(v_idxCE).InnerText = v_dblCeilingPrice.ToString

    '                    v_strXMLBuilder.Append("<Order CLASS='UPDATESECURITIESINFO'>" + ControlChars.CrLf)
    '                    v_strXMLBuilder.Append("<SYMBOL>" + v_strSYMBOL + "</SYMBOL>" + ControlChars.CrLf)
    '                    v_strXMLBuilder.Append("<RFPRICE>" + v_dblReferencePrice.ToString + "</RFPRICE>" + ControlChars.CrLf)
    '                    v_strXMLBuilder.Append("<FLPRICE>" + v_dblFloorPrice.ToString + "</FLPRICE>" + ControlChars.CrLf)
    '                    v_strXMLBuilder.Append("<CEPRICE>" + v_dblCeilingPrice.ToString + "</CEPRICE>" + ControlChars.CrLf)
    '                    v_strXMLBuilder.Append("</Order>")
    '                    v_strMessage = "<RootTrade FUNCNAME='PLACEORDER'><objPARA></objPARA><objBODY>" + v_strXMLBuilder.ToString + "</objBODY></RootTrade>"

    '                    'Gọi hàm đặt lệnh theo chế độ Synchronous
    '                    v_lngReturn = v_ws.PlaceOrder(v_strMessage)

    '                    'Cap nhat lai cac muc gia
    '                    mv_dblRefPrice = v_dblReferencePrice
    '                    mv_dblFloorPrice = v_dblFloorPrice
    '                    mv_dblCeilingPrice = v_dblCeilingPrice
    '                    Return True
    '                End If
    '            Next
    '        End If
    '        Return False
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    Finally
    '        v_strXMLBuilder = Nothing
    '        v_ws = Nothing
    '    End Try
    'End Function

    Private Function GetInstrumentInformation(ByRef v_strTradePlace As String, ByVal v_strSYMBOL As String, ByRef v_dblReferencePrice As Double, _
        ByRef v_dblFloorPrice As Double, ByRef v_dblCeilingPrice As Double, ByRef v_dblCurrentPrice As Double, _
        ByRef v_strRETURN As String, Optional ByVal v_blnUpdateScreen As Boolean = True) As Boolean
        Dim v_nodeData As Xml.XmlNode, v_nodeList As Xml.XmlNodeList
        Dim v_strRefName, v_strCODEID, v_strValue, v_strTradingPlace, v_strExchangeCode, v_strSECTYPE, v_strREPRICE, v_strFLPRICE, _
            v_strCEPRICE, v_strCURRRICE, v_strMARGINPRICE, v_strMARGINREFPRICE, v_strTRADELOT, v_strTRADEUNIT, v_strMINQTTY, v_strMAXQTTY As String
        v_dblReferencePrice = 0
        v_dblFloorPrice = 0
        v_dblCeilingPrice = 0
        v_dblCurrentPrice = 0
        Try
            If Not mv_xmlSYMBOLSLIST Is Nothing Then
                v_nodeList = mv_xmlSYMBOLSLIST.SelectNodes("/ObjectMessage/ObjData")
                For i As Integer = 0 To v_nodeList.Count - 1
                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            If CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "SYMBOL" Then
                                v_strValue = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "INSTRUMENTNAME" Then
                                v_strRefName = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "CODEID" Then
                                v_strCODEID = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "TRADEPLACE" Then
                                v_strTradingPlace = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "EXCHANGECODE" Then
                                v_strExchangeCode = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "SECTYPE" Then
                                v_strSECTYPE = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "BASICPRICE" Then
                                v_strREPRICE = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "FLOORPRICE" Then
                                v_strFLPRICE = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "CEILINGPRICE" Then
                                v_strCEPRICE = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "CURRPRICE" Then
                                v_strCURRRICE = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "MARGINPRICE" Then
                                v_strMARGINPRICE = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "MARGINREFPRICE" Then
                                v_strMARGINREFPRICE = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "TRADEUNIT" Then
                                v_strTRADEUNIT = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "TRADELOT" Then
                                v_strTRADELOT = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "ADVANCEDLIMITMIN" Then
                                v_strMINQTTY = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "ADVANCEDLIMITMAX" Then
                                v_strMAXQTTY = .InnerText.ToString
                            End If
                        End With
                    Next
                    If v_strSYMBOL = v_strValue.Trim.ToUpper Then
                        If v_blnUpdateScreen Then
                            mskSymbol.Tag = v_strCODEID
                            mskSymbol.Text = v_strSYMBOL
                        End If
                        v_dblReferencePrice = CDbl(v_strREPRICE)
                        mv_dblRefPrice = CDbl(v_strREPRICE)
                        v_dblFloorPrice = CDbl(v_strFLPRICE)
                        mv_dblFloorPrice = CDbl(v_strFLPRICE)
                        mv_dblMarginPrice = CDbl(v_strMARGINPRICE)
                        mv_dblMarginRefPrice = CDbl(v_strMARGINREFPRICE)
                        v_dblCeilingPrice = CDbl(v_strCEPRICE)
                        mv_dblCeilingPrice = CDbl(v_strCEPRICE)
                        v_dblCurrentPrice = CDbl(v_strCURRRICE)
                        mv_dblTradeUnit = CDbl(v_strTRADEUNIT)
                        mv_dblTradeLot = CDbl(v_strTRADELOT)
                        'NamLP: UPCOM
                        mv_dblMinQtty = CDbl(v_strMINQTTY)
                        mv_dblMaxQtty = CDbl(v_strMAXQTTY)
                        'NamLP: UPCOM End
                        If mv_dblTradeUnit = 0 Then mv_dblTradeUnit = 1 'MAC DINH DON VI LA 1
                        If mv_dblTradeLot = 0 Then mv_dblTradeLot = 1 'MAC DINH DON VI LA 1
                        v_strTradePlace = v_strTradingPlace
                        mv_strExchangeCode = v_strExchangeCode
                        mv_strSecuritiesType = v_strSECTYPE

                        v_strRETURN = ResourceManager.GetString("msgSYMBOLDESCRIPTION")
                        v_strRETURN = v_strRETURN.Replace("$TRADEPLACE", v_strTradingPlace)
                        v_strRETURN = v_strRETURN.Replace("$REFNAME", v_strRefName)
                        v_strRETURN = v_strRETURN.Replace("$REFPRICE", FormatNumber(mv_dblRefPrice / mv_dblTradeUnit, -1))
                        v_strRETURN = v_strRETURN.Replace("$FLPRICE", FormatNumber(mv_dblFloorPrice / mv_dblTradeUnit, -1))
                        v_strRETURN = v_strRETURN.Replace("$CEPRICE", FormatNumber(mv_dblCeilingPrice / mv_dblTradeUnit, -1))
                        Return True
                    End If
                Next
                If v_blnUpdateScreen Then mskSymbol.Tag = String.Empty
                v_strRETURN = ResourceManager.GetString("msgINVALIDSYMBOL")
            Else
                v_strRETURN = ResourceManager.GetString("msgEMPTYLIST")
            End If
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
        End Try
    End Function

    Public Overridable Sub GetOrderExecutionBySymbol(ByVal v_strACCTNO As String)
        Dim v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_xmlTemporary As New XmlDocumentEx
        Dim v_ds As New DataSet
        Dim v_table As DataTable = New DataTable("OrderExecutionBySymbol")
        Dim v_column As DataColumn
        Dim v_row As DataRow

        Try
            'Neu la lan dau chay thi thoat luon
            If mb_blnIsFirstRun Then Exit Sub

            Dim v_strSYMBOL, v_strBORS As String
            v_strSYMBOL = Me.mskDealSymbol.Text.ToUpper
            If Not ValidSymbol(v_strSYMBOL) Then
                Me.pnCurrentDeal.Controls.Clear()
            Else
                If Me.cboDealType.SelectedIndex = 0 Then
                    v_strBORS = "B"
                Else
                    v_strBORS = "S"
                End If
            End If

            Dim v_nodeData As Xml.XmlNode, v_nodeList As Xml.XmlNodeList
            'Cache thong tin ve chung khoan
            Dim v_strSQLString As String, i, j As Integer
            Dim v_strFIELDNAME, v_strFIELDVALUE, v_strFIELDCAPTION As String

            'get cash information
            v_strSQLString = "SELECT REFID, TO_CHAR(TXDATE,'DD/MM/RRRR') TXDATE, TXNUM, ORDERID, " & ControlChars.CrLf _
                & " SYMBOL, PRICE, QTTY, CONFIRM_NO, BORS_DESC, BORS, AFACCTNO, 0 MOVE_QTTY" & ControlChars.CrLf _
                & " FROM VW_BD_DEALS WHERE AFACCTNO='" & v_strACCTNO & "' AND SYMBOL='" & v_strSYMBOL & "' AND BORS='" & v_strBORS & "' " & ControlChars.CrLf _
                & " ORDER BY ORDERID " 'Luu y: Khong duoc sua order by 
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_SA_ALLCODE, gc_ActionInquiry, v_strSQLString)
            v_ws.Message(v_strObjMsg)
            v_xmlTemporary.LoadXml(v_strObjMsg)
            'show on screen               
            Me.pnCurrentDeal.Controls.Clear()
            If Not v_xmlTemporary Is Nothing Then
                v_nodeList = v_xmlTemporary.SelectNodes("/ObjectMessage/ObjData")
                If v_nodeList.Count > 0 Then
                    Dim v_dgData As New DataGridView
                    Dim v_intRow As Integer
                    Me.pnCurrentDeal.Controls.Add(v_dgData)
                    'Get column of the table
                    i = 0
                    For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                        v_strFIELDNAME = CStr(CType(v_nodeList.Item(i).ChildNodes(j).Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        'Add new column
                        v_dgData.Columns.Add(v_strFIELDNAME, ResourceManager.GetString(v_strFIELDNAME))
                    Next

                    'Get data
                    v_nodeList = v_xmlTemporary.SelectNodes("/ObjectMessage/ObjData")
                    For i = 0 To v_nodeList.Count - 1
                        v_intRow = v_dgData.Rows.Add()
                        For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                            v_strFIELDNAME = CStr(CType(v_nodeList.Item(i).ChildNodes(j).Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            v_strFIELDVALUE = v_nodeList.Item(i).ChildNodes(j).InnerText
                            If String.Compare(v_strFIELDNAME, "SYMBOL") = 0 _
                                Or String.Compare(v_strFIELDNAME, "REFID") = 0 _
                                Or String.Compare(v_strFIELDNAME, "ORDERID") = 0 _
                                Or String.Compare(v_strFIELDNAME, "CONFIRM_NO") = 0 _
                                Or String.Compare(v_strFIELDNAME, "BORS") = 0 _
                                Or String.Compare(v_strFIELDNAME, "AFACCTNO") = 0 _
                                Or String.Compare(v_strFIELDNAME, "TXDATE") = 0 _
                                Or String.Compare(v_strFIELDNAME, "TXNUM") = 0 _
                                Or String.Compare(v_strFIELDNAME, "BORS_DESC") = 0 Then
                                v_dgData.Rows(v_intRow).Cells(v_strFIELDNAME).Value = v_strFIELDVALUE
                            Else
                                v_dgData.Rows(v_intRow).Cells(v_strFIELDNAME).Value = FormatNumber(CDbl(v_strFIELDVALUE), 0)
                            End If
                        Next
                    Next

                    v_dgData.EditMode = DataGridViewEditMode.EditOnEnter
                    AddHandler v_dgData.CellValidating, AddressOf dgData_CellValidating
                    For i = 0 To v_dgData.Columns.Count - 1 Step 1
                        v_strFIELDNAME = v_dgData.Columns(i).Name
                        'v_dgData.Columns(i).HeaderText = ResourceManager.GetString(v_strFIELDNAME)
                        v_dgData.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        If String.Compare(v_strFIELDNAME, "SYMBOL") = 0 _
                            Or String.Compare(v_strFIELDNAME, "REFID") = 0 _
                            Or String.Compare(v_strFIELDNAME, "BORS_DESC") = 0 Then
                            v_dgData.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                            v_dgData.Columns(i).Frozen = True
                            v_dgData.Columns(i).ReadOnly = True
                        ElseIf String.Compare(v_strFIELDNAME, "AFACCTNO") = 0 _
                            Or String.Compare(v_strFIELDNAME, "ORDERID") = 0 _
                            Or String.Compare(v_strFIELDNAME, "CONFIRM_NO") = 0 _
                            Or String.Compare(v_strFIELDNAME, "TXDATE") = 0 _
                            Or String.Compare(v_strFIELDNAME, "TXNUM") = 0 _
                            Or String.Compare(v_strFIELDNAME, "BORS") = 0 Then
                            v_dgData.Columns(i).Visible = False
                            v_dgData.Columns(i).ReadOnly = True
                        ElseIf String.Compare(v_strFIELDNAME, "MOVE_QTTY") = 0 Then
                            v_dgData.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        Else
                            v_dgData.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            v_dgData.Columns(i).Frozen = True
                            v_dgData.Columns(i).ReadOnly = True
                        End If
                    Next
                    FormatStyleForDataGridView(v_dgData)
                    mv_dblCurrentMoveQtty = 0
                    mv_dblCurrentMoveAmount = 0
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            v_table.Dispose()
            v_ds.Dispose()
            v_xmlTemporary = Nothing
            v_ws = Nothing
        End Try
    End Sub

    Public Overridable Sub GetOrderBook(ByVal v_strACCTNO As String)
        Dim v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_xmlTemporary As New XmlDocumentEx
        Try
            'Neu la lan dau chay thi thoat luon
            If mb_blnIsFirstRun Then Exit Sub

            'Cache thong tin ve chung khoan
            Dim v_strSQLString, v_strClause As String, i, j As Integer

            'get cash information
            v_strSQLString = "SP_BD_GETORDERBOOK"
            v_strClause = "AFACCTNO!" & v_strACCTNO & "!varchar2!20"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_SA_ALLCODE, gc_ActionInquiry, v_strSQLString, v_strClause, , , , , , , gc_CommandProcedure)
            v_ws.Message(v_strObjMsg)

            Dim v_taskinfo As New BindGridTaskInfo()
            v_taskinfo.xml = v_strObjMsg
            v_taskinfo.dgv = dgOrderBook
            v_taskinfo.dtype = "D"

            Threading.ThreadPool.QueueUserWorkItem(AddressOf BindData2DataGridViewHelper, v_taskinfo)
            'BindData2DataGridView(v_strObjMsg, dgOrderBook, "D")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            v_xmlTemporary = Nothing
            v_ws = Nothing
        End Try
    End Sub

    Public Overridable Sub OnInit()
        Dim v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_xmlTemporary As New XmlDocumentEx
        Try
            Dim v_strSQLString, v_strValue As String, i, j As Integer
            Dim v_nodeData As Xml.XmlNode, v_nodeList As Xml.XmlNodeList
            Dim v_lngSplitValue, v_lngMIN_QTTY, v_lngMAX_QTTY, v_lngMIN_CNT, v_lngMAX_CNT As Long

            'Set view condition of controls
            If IsShortSale Then
                Me.mskDFNo.Visible = False
                Me.lblLinkType.Visible = False
                Me.lblDeal.Visible = False
                Me.mskBorrowCustodycd.Visible = True
                Me.cboBorrowAFAcctno.Visible = True
                Me.lblBorrowCustodycd.Visible = True
                Me.pnODWorkingArea.TabIndex = 2
                Me.pnODFixedArea.TabIndex = 1

                Me.cboExecType.Items.Clear()
                Me.cboExecType.Items.Add(mv_ResourceManager.GetString("EXECTYPE_NB"))
                Me.cboExecType.Items.Add(mv_ResourceManager.GetString("EXECTYPE_NS"))
                cboExecType.SelectedIndex = 1
            Else
                Me.mskDFNo.Visible = True
                Me.lblLinkType.Visible = True
                Me.lblDeal.Visible = True
                Me.mskBorrowCustodycd.Visible = False
                Me.cboBorrowAFAcctno.Visible = False
                Me.lblBorrowCustodycd.Visible = False
                Me.pnODWorkingArea.TabIndex = 1
                Me.pnODFixedArea.TabIndex = 2
            End If
            'TICKSIZE CHUNG KHOAN
            v_strSQLString = "SELECT CODEID, SYMBOL, TICKSIZE, FROMPRICE, TOPRICE FROM SECURITIES_TICKSIZE WHERE STATUS='Y'"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_SA_ALLCODE, gc_ActionInquiry, v_strSQLString)
            v_ws.Message(v_strObjMsg)
            mv_xmlSYMBOLTICKSIZE = New XmlDocumentEx
            mv_xmlSYMBOLTICKSIZE.LoadXml(v_strObjMsg)

            'DANH SACH CHUNG KHOAN
            v_strSQLString = "SELECT MST.SYMBOL, ISS.FULLNAME INSTRUMENTNAME, MST.TRADEPLACE EXCHANGECODE, " _
                & ControlChars.CrLf & " A0.CDCONTENT SYMTYPE, A1.CDCONTENT TRADEPLACE," _
                & ControlChars.CrLf & " MST.SECTYPE, MST.CODEID, DTL.TRADELOT, DTL.TRADEUNIT, DTL.BASICPRICE, DTL.FLOORPRICE, DTL.CEILINGPRICE, DTL.MARGINPRICE,DTL.MARGINREFPRICE, DTL.ADVANCEDLIMITMIN, DTL.ADVANCEDLIMITMAX" _
                & ControlChars.CrLf & " FROM ISSUERS ISS, SBSECURITIES MST, SECURITIES_INFO DTL, ALLCODE A0, ALLCODE A1" _
                & ControlChars.CrLf & " WHERE ISS.ISSUERID = MST.ISSUERID AND MST.CODEID = DTL.CODEID  AND MST.TRADEPLACE<> '006' and MST.SECTYPE<>'004'" _
                & ControlChars.CrLf & " AND A0.CDTYPE='SA' AND A0.CDNAME='SECTYPE' AND A0.CDVAL=MST.SECTYPE" _
                & ControlChars.CrLf & " AND A1.CDTYPE='SA' AND A1.CDNAME='TRADEPLACE' AND A1.CDVAL=MST.TRADEPLACE" _
                & ControlChars.CrLf & " ORDER BY SYMBOL"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_SA_ALLCODE, gc_ActionInquiry, v_strSQLString)
            v_ws.Message(v_strObjMsg)
            mv_xmlSYMBOLSLIST = New XmlDocumentEx
            mv_xmlSYMBOLSLIST.LoadXml(v_strObjMsg)

            'BIEN DO TACH LENH CUA TUNG SAN
            v_strSQLString = "SELECT * FROM VW_SPLIT_ORDER_PARAMETERS"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_SA_ALLCODE, gc_ActionInquiry, v_strSQLString)
            v_ws.Message(v_strObjMsg)
            mv_xmlSPLITOPTION = New XmlDocumentEx
            mv_xmlSPLITOPTION.LoadXml(v_strObjMsg)
            If Not v_xmlTemporary Is Nothing Then
                v_nodeList = mv_xmlSPLITOPTION.SelectNodes("/ObjectMessage/ObjData")
                For i = 0 To v_nodeList.Count - 1
                    For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            If CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "EXCHANGENAME" Then
                                v_strValue = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "MIN_QTTY" Then
                                v_lngMIN_QTTY = CLng(.InnerText.ToString)
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "MAX_QTTY" Then
                                v_lngMAX_QTTY = CLng(.InnerText.ToString)
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "MIN_CNT" Then
                                v_lngMIN_CNT = CLng(.InnerText.ToString)
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "MAX_CNT" Then
                                v_lngMAX_CNT = CLng(.InnerText.ToString)
                            End If
                        End With
                    Next
                    If String.Compare(v_strValue, "HSX") = 0 Then
                        mv_lngHoSEMaxOrders = v_lngMAX_CNT
                    ElseIf String.Compare(v_strValue, "HNX") = 0 Then
                        mv_lngHNXMaxOrders = v_lngMAX_CNT
                    End If
                Next
            End If

            'Thong tin ve phi ung truoc tien ban
            v_strSQLString = "SELECT INTRATE, MINVAL FROM VW_STRADE_FEE_ADV_PAYMENT"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_SA_ALLCODE, gc_ActionInquiry, v_strSQLString)
            v_ws.Message(v_strObjMsg)
            v_xmlTemporary.LoadXml(v_strObjMsg)
            If Not v_xmlTemporary Is Nothing Then
                v_nodeList = v_xmlTemporary.SelectNodes("/ObjectMessage/ObjData")
                For i = 0 To v_nodeList.Count - 1
                    For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            If CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "INTRATE" Then
                                v_strValue = .InnerText.ToString
                                If IsNumeric(v_strValue) Then
                                    mv_dblAdvancedIntRate = CDbl(v_strValue)
                                Else
                                    mv_dblAdvancedIntRate = 0
                                End If
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "MINVAL" Then
                                v_strValue = .InnerText.ToString
                                If IsNumeric(v_strValue) Then
                                    mv_dblAdvancedMinFeeAmt = CDbl(v_strValue)
                                Else
                                    mv_dblAdvancedMinFeeAmt = 0
                                End If
                            End If
                        End With
                    Next

                Next
            End If

            v_strValue = mv_ResourceManager.GetString("lblSystemParameters")
            v_strValue = v_strValue.Replace("$HSX_CNT", FormatNumber(mv_lngHoSEMaxOrders, 0))
            v_strValue = v_strValue.Replace("$HNX_CNT", FormatNumber(mv_lngHNXMaxOrders, 0))
            v_strValue = v_strValue.Replace("$ADVINT", FormatNumber(mv_dblAdvancedIntRate, 0))
            v_strValue = v_strValue.Replace("$ADVMIN", FormatNumber(mv_dblAdvancedMinFeeAmt, 0))
            Me.lblSystemParameters.Text = v_strValue
            'Khong cho phep move tung lenh
            Me.tabPageMoveDeal.Dispose()
            mb_blnIsFirstRun = False
            txtFeedback.Text = String.Empty
            If ViaChannel = "F" Then
                Me.mskCriteriaValue.Focus()
            Else
                Me.mskCriteriaValue.ReadOnly = True
                Me.mskCriteriaValue.Text = DefaultCustodyCD
                SearchByCriteria()
                Me.mskSymbol.Focus()
            End If

            'Thiết lập các DataGidView hiển thị dữ liệu
            FormatDataGridView()
            'Khởi tạo Cache
            FOInitPublicSharing()

            'Mở file dữ liệu Cache
            'mv_CacheData = New CacheOnSQLite(c_CacheMarketInforFile)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            v_ws = Nothing
            v_xmlTemporary = Nothing
        End Try
    End Sub

    Private Sub SymbolInfoColor()
        If lblSymbolInfo.TextLength <> 0 Then
            'format color
            lblSymbolInfo.Select(lblSymbolInfo.Find("CE:") + 3, lblSymbolInfo.Find(", FL:") - lblSymbolInfo.Find("CE:") - 3)
            lblSymbolInfo.SelectionFont = New Font("Arial", 10, FontStyle.Bold)
            lblSymbolInfo.SelectionColor = Color.DeepPink
            lblSymbolInfo.Select(lblSymbolInfo.Find("FL:") + 3, lblSymbolInfo.Find(", RF:") - lblSymbolInfo.Find("FL:") - 3)
            lblSymbolInfo.SelectionFont = New Font("Arial", 10, FontStyle.Bold)
            lblSymbolInfo.SelectionColor = Color.LightBlue
            If lblSymbolInfo.Find("PPSE:") > 0 Then
                lblSymbolInfo.Select(lblSymbolInfo.Find("RF:") + 3, lblSymbolInfo.Find("PPSE:") - lblSymbolInfo.Find("RF:") - 3)
                lblSymbolInfo.SelectionFont = New Font("Arial", 10, FontStyle.Bold)
                lblSymbolInfo.SelectionColor = Color.Yellow
                lblSymbolInfo.Select(lblSymbolInfo.Find("PPSE:"), lblSymbolInfo.TextLength - lblSymbolInfo.Find("PPSE:"))
                lblSymbolInfo.SelectionFont = New Font("Arial", 10, FontStyle.Bold)
                lblSymbolInfo.SelectionColor = Color.Red
            Else
                lblSymbolInfo.Select(lblSymbolInfo.Find("RF:") + 3, lblSymbolInfo.TextLength - lblSymbolInfo.Find("RF:") - 3)
                lblSymbolInfo.SelectionFont = New Font("Arial", 10, FontStyle.Bold)
                lblSymbolInfo.SelectionColor = Color.Yellow
            End If

            'end format color
        End If
    End Sub

    Private Sub onRefresh()
        If cboAFAcctno.Items.Count > 0 Then
            Dim v_strACCTNO, v_strTabPageName As String
            'Lay so hop dong hien tai
            v_strACCTNO = mv_arrAccountNumber(cboAFAcctno.SelectedIndex)
            v_strTabPageName = tabCtrlAccount.TabPages(tabCtrlAccount.SelectedIndex).Name
            If String.Compare(v_strTabPageName, "tabPageDeal") = 0 Then
                GetTabPageDeal(v_strACCTNO)
            ElseIf String.Compare(v_strTabPageName, "tabPageLoan") = 0 Then
                GetTabPageLoan(v_strACCTNO)
            ElseIf String.Compare(v_strTabPageName, "tabPageAccount") = 0 Then
                GetTabPageAccount(v_strACCTNO)
            ElseIf String.Compare(v_strTabPageName, "tabPageSecurities") = 0 Then
                GetTabPageSecurities(v_strACCTNO)
            ElseIf String.Compare(v_strTabPageName, "tabPageCustomer") = 0 Then
                v_strACCTNO = mv_arrCustodyCode(cboAFAcctno.SelectedIndex)
                GetTabPageCustomer(v_strACCTNO)
            ElseIf String.Compare(v_strTabPageName, "tabPageOrders") = 0 Then
                GetTabPageOrders(v_strACCTNO)
            End If
        End If
    End Sub

    Private Sub onResetForm()
        Me.mskPrice.Text = ""
        Me.mskQtty.Text = ""
        Me.mskSymbol.Text = ""
        Me.lblSymbolInfo.Text = ""
        Me.mskDFNo.Text = ""
        If IsShortSale Then
            Me.mskBorrowCustodycd.Focus()
            Me.mskBorrowCustodycd.SelectAll()
            'Else
            '    Me.mskCriteriaValue.Focus()
            '    Me.mskCriteriaValue.SelectAll()
        End If

    End Sub

    Private Sub MenuMoveOrderClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim v_ws As New BDSDeliveryManagement
        Dim v_strXMLBuilder As New StringBuilder
        Dim v_strErrorMessage As String
        Dim v_strErrorSource As String = "Main.frmBrokerDesk.OnMoveOrder"
        Try
            'SUBMIT: MOVE DEAL
            Dim v_strMsgConfirm, v_strMsgDesc, v_strMessage As String, v_lngReturn, v_row_idx, v_col_idx As Long
            Dim v_strFR_AFACCTNO, v_strTO_AFACCTNO, v_strTO_CUSTODYCD, v_strEXECTYPE, v_strSYMBOL, v_strQTTY, v_strAMOUNT As String
            Dim v_strTxMsg, v_strORDERID, v_strTXDATE, v_strTXNUM, v_strTLTXCD, v_strDEALQTTY, v_strDEALAMT As String

            Dim v_strFLDNAME, v_strDATATYPE, v_strFLDVALUE As String, v_intIndex As Long, i, v_intCount As Integer
            Dim v_dgData As DataGridView
            Dim v_xmlDocument As New Xml.XmlDocument, v_dataElement As Xml.XmlElement
            Dim v_ctl As Control, v_attrFLDNAME As Xml.XmlAttribute, v_attrDATATYPE As Xml.XmlAttribute, v_objEval As New Evaluator
            Dim v_nodeList As Xml.XmlNodeList, v_entryNode, v_nodetxData As Xml.XmlNode
            Dim v_dblSecuredRatio, v_dblFeeamount, v_dblTopup As Double

            Dim attrDestination As String() = CType(sender, ToolStripMenuItem).Tag.Split(New Char() {"|"c})
            v_strTO_CUSTODYCD = attrDestination(0)
            v_strTO_AFACCTNO = attrDestination(1)
            v_strFR_AFACCTNO = mv_arrAccountNumber(Me.cboAFAcctno.SelectedIndex)
            'v_strTO_AFACCTNO = mv_arrAccountNumber(Me.cboMove.SelectedIndex)
            'v_strTO_CUSTODYCD = mv_arrCustodyCode(Me.cboMove.SelectedIndex)
            v_lngReturn = ERR_SYSTEM_OK

            If Me.pnOrders.Controls.Count > 0 Then
                v_dgData = CType(pnOrders.Controls(0), DataGridView)
                If v_dgData.Rows.Count > 0 Then
                    v_strEXECTYPE = v_dgData.CurrentRow.Cells("EXECTYPE").Value
                    If String.Compare(v_strEXECTYPE, "NB") = 0 Then
                        v_strTLTXCD = gc_OD_MOVE_BUY_DEAL
                    ElseIf String.Compare(v_strEXECTYPE, "NS") = 0 Then
                        v_strTLTXCD = gc_OD_MOVE_SELL_DEAL
                    Else
                        v_strTLTXCD = String.Empty
                    End If

                    'Nap so lieu ve lenh
                    If v_strTLTXCD.Length > 0 Then
                        LoadTXScreen(v_strTLTXCD)
                        If mv_arrObjFields.GetLength(0) > 0 Then
                            v_strSYMBOL = v_dgData.CurrentRow.Cells("SYMBOL").Value
                            v_strDEALQTTY = CDbl(v_dgData.CurrentRow.Cells("ORDERQTTY").Value)
                            v_strDEALAMT = CDbl(v_dgData.CurrentRow.Cells("ORDERQTTY").Value) _
                                    * 1000 * CDbl(v_dgData.CurrentRow.Cells("QUOTEPRICE").Value) _
                                    * CDbl(v_dgData.CurrentRow.Cells("BRATIO").Value) / 100

                            v_strMsgConfirm = mv_strDealMovingMessage.Replace("$BORS", v_dgData.CurrentRow.Cells("DESC_EXECTYPE").Value)
                            v_strMsgConfirm = v_strMsgConfirm.Replace("$SYMBOL", v_strSYMBOL)
                            v_strMsgConfirm = v_strMsgConfirm.Replace("$QTTY", FormatNumber(CLng(v_strDEALQTTY), 0))
                            v_strMsgConfirm = v_strMsgConfirm.Replace("$AMT", FormatNumber(CDbl(v_strDEALAMT), 0))
                            'v_strMsgConfirm = v_strMsgConfirm & " => " & Me.cboMove.Text

                            v_strMsgDesc = mv_strDealMovingMessage.Replace("$BORS", v_dgData.CurrentRow.Cells("DESC_EXECTYPE").Value)
                            v_strMsgDesc = v_strMsgDesc.Replace("$SYMBOL", v_strSYMBOL)
                            v_strMsgDesc = v_strMsgDesc.Replace("$QTTY", FormatNumber(CLng(v_strDEALQTTY), 0))
                            v_strMsgDesc = v_strMsgDesc.Replace("$AMT", FormatNumber(CDbl(v_strDEALAMT), 0))

                            v_dblSecuredRatio = GetSecureRatio(v_dgData.CurrentRow.Cells("ORDERID").Value, _
                                   CDbl(v_dgData.CurrentRow.Cells("QUOTEPRICE").Value) * 1000, _
                                   CDbl(v_dgData.CurrentRow.Cells("REMAINQTTY").Value) + CDbl(v_dgData.CurrentRow.Cells("EXECQTTY").Value), _
                                   v_dgData.CurrentRow.Cells("CODEID").Value, v_strTO_AFACCTNO, v_dblFeeamount)
                            v_dblTopup = getTopupRatio(v_strTO_AFACCTNO, v_strSYMBOL, CDbl(v_dgData.CurrentRow.Cells("QUOTEPRICE").Value) * 1000 + (v_dblFeeamount / (CDbl(v_dgData.CurrentRow.Cells("REMAINQTTY").Value) + CDbl(v_dgData.CurrentRow.Cells("EXECQTTY").Value))))


                            'Tao message giao dich
                            v_strTxMsg = BuildXMLTxMsg(gc_MsgTypeTrans, gc_IsLocalMsg, v_strTLTXCD, Me.BranchId, Me.TellerId, Me.IpAddress, Me.WsName, , , , , , , , , , , , , , , , , Me.BusDate)
                            v_xmlDocument.LoadXml(v_strTxMsg)
                            v_dataElement = v_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "fields", "")
                            For v_intIndex = 0 To mv_arrObjFields.GetLength(0) - 1 Step 1
                                If Not mv_arrObjFields(v_intIndex) Is Nothing Then
                                    v_strFLDNAME = mv_arrObjFields(v_intIndex).FieldName
                                    v_strDATATYPE = mv_arrObjFields(v_intIndex).DataType
                                    Select Case Trim(v_strFLDNAME)
                                        Case "03" 'ORGORDERID
                                            v_strFLDVALUE = v_dgData.CurrentRow.Cells("ORDERID").Value
                                        Case "80" 'CODEID
                                            v_strFLDVALUE = v_dgData.CurrentRow.Cells("CODEID").Value
                                        Case "81" 'SYMBOL
                                            v_strFLDVALUE = v_strSYMBOL
                                        Case "82" 'CUSTODYCD
                                            v_strFLDVALUE = v_dgData.CurrentRow.Cells("CUSTODYCD").Value
                                        Case "05" 'SEACCTNO
                                            v_strFLDVALUE = v_strFR_AFACCTNO & v_dgData.CurrentRow.Cells("CODEID").Value
                                        Case "07" 'AFACCTNO
                                            v_strFLDVALUE = v_strFR_AFACCTNO
                                        Case "09" 'CUSTODYCD
                                            v_strFLDVALUE = v_strTO_CUSTODYCD
                                        Case "08" 'TOAFACCTNO
                                            v_strFLDVALUE = v_strTO_AFACCTNO
                                        Case "06" 'SEACCTNO
                                            v_strFLDVALUE = v_strTO_AFACCTNO & v_dgData.CurrentRow.Cells("CODEID").Value
                                        Case "10" 'ORDERPRICE
                                            v_strFLDVALUE = CDbl(v_dgData.CurrentRow.Cells("QUOTEPRICE").Value)
                                        Case "11" 'ORDERQTTY
                                            v_strFLDVALUE = v_strDEALQTTY
                                        Case "13" 'BRATIO
                                            'v_strFLDVALUE = CDbl(v_dgData.CurrentRow.Cells("BRATIO").Value)
                                            If String.Compare(v_strEXECTYPE, "NB") = 0 Then
                                                v_strFLDVALUE = v_dblSecuredRatio
                                            Else
                                                v_strFLDVALUE = 100
                                            End If
                                        Case "14" 'REMAINQTTY, 
                                            v_strFLDVALUE = CDbl(v_dgData.CurrentRow.Cells("REMAINQTTY").Value)
                                        Case "15" 'EXECQTTY, 
                                            v_strFLDVALUE = CDbl(v_dgData.CurrentRow.Cells("EXECQTTY").Value)
                                        Case "16" 'EXECAMT
                                            v_strFLDVALUE = CDbl(v_dgData.CurrentRow.Cells("EXECAMT").Value) / 1000
                                        Case "40" 'Fee amount
                                            v_strFLDVALUE = v_dblFeeamount
                                        Case "98" 'Tradeunit
                                            v_strFLDVALUE = 1000
                                        Case "99" 'Topup
                                            v_strFLDVALUE = v_dblTopup
                                        Case "12" 'AMT
                                            If String.Compare(v_strEXECTYPE, "NB") = 0 Then
                                                v_strFLDVALUE = CDbl(v_strDEALAMT)
                                            Else
                                                v_strFLDVALUE = CDbl(v_dgData.CurrentRow.Cells("ORDERQTTY").Value)
                                            End If
                                        Case "30" 'DESC
                                            v_strFLDVALUE = v_strMsgDesc
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


                        Dim v_frmConfirm As New frmBrokerDeskConfirm
                        v_frmConfirm.lblAccountInfor.Text = cboAFAcctno.Text
                        v_frmConfirm.lblConfirmation.Text = v_strMsgConfirm
                        v_frmConfirm.pnHeader.BackColor = Color.White
                        v_frmConfirm.pnDetail.BackColor = Color.Black
                        Dim frmResult As DialogResult = v_frmConfirm.ShowDialog()
                        Application.DoEvents()
                        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
                        If frmResult = Windows.Forms.DialogResult.OK Then
                            'Tao giao dich chuyen lenh
                            v_strTxMsg = v_xmlDocument.InnerXml
                            v_lngReturn = v_ws.Message(v_strTxMsg)
                            If v_lngReturn <> ERR_SYSTEM_OK Then
                                'Thông báo lỗi
                                GetErrorFromMessage(v_strTxMsg, v_strErrorSource, v_lngReturn, v_strErrorMessage, Me.UserLanguage)
                                Cursor.Current = Cursors.Default
                                If v_lngReturn <> ERR_SA_CHECKER1_OVR And v_lngReturn <> ERR_SA_CHECKER2_OVR Then
                                    'Reset lai Description
                                    Me.txtFeedback.Text = v_strErrorMessage
                                    Exit Sub
                                Else
                                    'Lấy thêm nguyên nhân duyệt
                                    GetReasonFromMessage(v_strTxMsg, v_strErrorMessage, Me.UserLanguage)
                                    Me.txtFeedback.Text = v_strErrorMessage
                                End If
                            End If

                        End If
                        Me.Cursor = System.Windows.Forms.Cursors.Default
                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            v_strXMLBuilder = Nothing
            v_ws = Nothing
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub GetCustomerSubAccount(ByVal v_strSEARCHBY As String, ByVal v_strSEARCHVALUE As String, _
                                      ByRef v_strRETURN As String)
        Dim v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            Dim v_nodeData As Xml.XmlNode, v_nodeList As Xml.XmlNodeList
            Dim v_strEXTCustomer, v_strCUSTID, v_strACTYPE, v_strACCTNO, v_strCOREBANK, v_strOWNERNAME, _
                v_strLINKAUTH, v_strLNKTYPE, v_strCFFULLNAME, v_strCFCUSTODYCD, v_strCFEMAIL, _
                v_strUSERNAME, v_strIDCODE, v_strCFEXT, v_strCAREBY, v_strMRTYPE, v_strMRPPTYPE As String
            Dim v_lngCount As Long
            'Cache thong tin ve cac tieu khoan giao dich cua khach hang
            Dim v_strSQLString As String
            Dim v_xmlTemporary As XmlDocumentEx
            v_strSQLString = "SELECT MST.ACTYPE, MST.COREBANK, MST.CAREBY, MST.MRTYPE, MST.ISPPUSED, MST.CFCUSTID, MST.ACCTNO, " & ControlChars.CrLf _
                & "MST.OWNERNAME, LINKAUTH, LNKTYPE, CFFULLNAME, CFCUSTODYCD, CFEMAIL, USERNAME, IDCODE, " & ControlChars.CrLf _
                & "CFEXT FROM VW_BD_GETSUBACCT_BYCF MST, tlgrpusers TL WHERE " & ControlChars.CrLf _
                & v_strSEARCHBY.Trim & "='" & v_strSEARCHVALUE.Trim & "' AND MST.CAREBY=TL.GRPID " & ControlChars.CrLf _
                & "AND TL.BRID='" & Me.BranchId & "' AND TL.TLID='" & Me.TellerId & "'"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_SA_ALLCODE, gc_ActionInquiry, v_strSQLString)
            v_ws.Message(v_strObjMsg)

            mv_xmlCUSTOMER = New XmlDocumentEx
            mv_xmlCUSTOMER.LoadXml(v_strObjMsg)
            Me.ctxMoveOrder.Items.Clear()

            Me.cboAFAcctno.Items.Clear()
            'cboMove.Items.Clear()
            cboDealAFAcctno.Items.Clear()
            mv_strCUSTID = String.Empty
            v_strRETURN = String.Empty
            If Not mv_xmlCUSTOMER Is Nothing Then
                v_nodeList = mv_xmlCUSTOMER.SelectNodes("/ObjectMessage/ObjData")
                v_lngCount = v_nodeList.Count
                ReDim mv_arrAccountRole(v_lngCount)
                ReDim mv_arrAccountAuth(v_lngCount)
                ReDim mv_arrAccountNumber(v_lngCount)
                ReDim mv_arrAccountCoreBank(v_lngCount)
                ReDim mv_arrAccountName(v_lngCount)
                ReDim mv_arrActype(v_lngCount)
                ReDim mv_arrCustodyCode(v_lngCount)
                ReDim mv_arrCareByCustomer(v_lngCount)
                ReDim mv_arrAcctMarginClass(v_lngCount)
                ReDim mv_arrAcctPurchasingPowerType(v_lngCount)
                For i As Integer = 0 To v_lngCount - 1
                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            If CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "CFCUSTID" Then
                                v_strCUSTID = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "ACCTNO" Then
                                v_strACCTNO = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "COREBANK" Then
                                v_strCOREBANK = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "OWNERNAME" Then
                                v_strOWNERNAME = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "LINKAUTH" Then
                                v_strLINKAUTH = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "LNKTYPE" Then
                                v_strLNKTYPE = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "CFFULLNAME" Then
                                v_strCFFULLNAME = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "CFCUSTODYCD" Then
                                v_strCFCUSTODYCD = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "CFEMAIL" Then
                                v_strCFEMAIL = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "USERNAME" Then
                                v_strUSERNAME = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "IDCODE" Then
                                v_strIDCODE = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "CFEXT" Then
                                v_strCFEXT = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "ACTYPE" Then
                                v_strACTYPE = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "CAREBY" Then
                                v_strCAREBY = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "MRTYPE" Then
                                v_strMRTYPE = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "ISPPUSED" Then
                                v_strMRPPTYPE = .InnerText.ToString
                            End If
                        End With
                    Next
                    mb_blnIsFirstRun = True
                    If v_strOWNERNAME.Length > 0 Then
                        Me.cboAFAcctno.Items.Add(v_strOWNERNAME)
                        'Me.cboMove.Items.Add(v_strOWNERNAME)
                        Me.cboDealAFAcctno.Items.Add(v_strOWNERNAME)
                        'Thêm menuItem
                        Dim mnuItem As New ToolStripMenuItem
                        mnuItem.Text = "=> " & v_strACCTNO
                        mnuItem.Tag = v_strCFCUSTODYCD & "|" & v_strACCTNO
                        AddHandler mnuItem.Click, AddressOf MenuMoveOrderClick

                        ctxMoveOrder.Items.Add(mnuItem)
                    End If
                    mv_strCUSTID = v_strCUSTID
                    v_strRETURN = v_strCFFULLNAME & ", " & v_strCFEXT
                    mv_arrAccountName(i) = v_strOWNERNAME
                    mv_arrAccountRole(i) = v_strLNKTYPE
                    mv_arrAccountAuth(i) = v_strLINKAUTH
                    mv_arrAccountNumber(i) = v_strACCTNO
                    mv_arrAccountCoreBank(i) = v_strCOREBANK
                    mv_arrCustodyCode(i) = v_strCFCUSTODYCD
                    mv_arrCareByCustomer(i) = v_strCAREBY
                    mv_arrAcctMarginClass(i) = v_strMRTYPE
                    mv_arrAcctPurchasingPowerType(i) = v_strMRPPTYPE
                    mv_arrActype(i) = v_strACTYPE
                Next
                If cboAFAcctno.Items.Count > 0 Then cboAFAcctno.SelectedIndex = 0
                'If cboMove.Items.Count > 0 Then cboMove.SelectedIndex = 0
                If cboDealAFAcctno.Items.Count > 0 Then cboDealAFAcctno.SelectedIndex = 0
                mb_blnIsFirstRun = False
                'Me.pnCashInfo.Controls.Clear()
                'Me.pnSecuritiesInfo.Controls.Clear()
                'Me.tabPageDeal.Controls.Clear()
                'Me.tabPageLoan.Controls.Clear()
            Else
                v_strRETURN = ResourceManager.GetString("msgCFNOTFOUND")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            v_ws = Nothing
        End Try
    End Sub

    Private Sub GetBorrowerCustomerSubAccount(ByVal v_strSEARCHBY As String, ByVal v_strSEARCHVALUE As String, _
                                      ByRef v_strRETURN As String)
        Dim v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_xmlCUSTOMER
        Try
            Dim v_nodeData As Xml.XmlNode, v_nodeList As Xml.XmlNodeList
            Dim v_strEXTCustomer, v_strCUSTID, v_strACTYPE, v_strACCTNO, v_strOWNERNAME, _
                v_strLINKAUTH, v_strLNKTYPE, v_strCFFULLNAME, v_strCFCUSTODYCD, v_strCFEMAIL, _
                v_strUSERNAME, v_strIDCODE, v_strCFEXT, v_strCAREBY, v_strMRTYPE, v_strMRPPTYPE As String
            Dim v_lngCount As Long
            'Cache thong tin ve cac tieu khoan giao dich cua khach hang
            Dim v_strSQLString As String
            Dim v_xmlTemporary As XmlDocumentEx
            v_strSQLString = "SELECT MST.ACTYPE, MST.CAREBY, MST.MRTYPE, MST.ISPPUSED, MST.CFCUSTID, MST.ACCTNO, " & ControlChars.CrLf _
                & "MST.OWNERNAME, LINKAUTH, LNKTYPE, CFFULLNAME, CFCUSTODYCD, CFEMAIL, USERNAME, IDCODE, " & ControlChars.CrLf _
                & "CFEXT FROM VW_BD_GETSUBACCT_BYCF MST, tlgrpusers TL WHERE " & ControlChars.CrLf _
                & v_strSEARCHBY.Trim & "='" & v_strSEARCHVALUE.Trim & "' AND MST.CAREBY=TL.GRPID " & ControlChars.CrLf _
                & "AND TL.BRID='" & Me.BranchId & "' AND TL.TLID='" & Me.TellerId & "'"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_SA_ALLCODE, gc_ActionInquiry, v_strSQLString)
            v_ws.Message(v_strObjMsg)

            v_xmlCUSTOMER = New XmlDocumentEx
            v_xmlCUSTOMER.LoadXml(v_strObjMsg)
            Me.cboBorrowAFAcctno.Items.Clear()
            'cboMove.Items.Clear()
            cboBorrowAFAcctno.Items.Clear()
            v_strRETURN = String.Empty
            If Not v_xmlCUSTOMER Is Nothing Then
                v_nodeList = v_xmlCUSTOMER.SelectNodes("/ObjectMessage/ObjData")
                v_lngCount = v_nodeList.Count
                ReDim mv_arrBorrowAccountNumber(v_lngCount)

                For i As Integer = 0 To v_lngCount - 1
                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            If CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "CFCUSTID" Then
                                v_strCUSTID = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "ACCTNO" Then
                                v_strACCTNO = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "OWNERNAME" Then
                                v_strOWNERNAME = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "LINKAUTH" Then
                                v_strLINKAUTH = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "LNKTYPE" Then
                                v_strLNKTYPE = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "CFFULLNAME" Then
                                v_strCFFULLNAME = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "CFCUSTODYCD" Then
                                v_strCFCUSTODYCD = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "CFEMAIL" Then
                                v_strCFEMAIL = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "USERNAME" Then
                                v_strUSERNAME = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "IDCODE" Then
                                v_strIDCODE = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "CFEXT" Then
                                v_strCFEXT = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "ACTYPE" Then
                                v_strACTYPE = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "CAREBY" Then
                                v_strCAREBY = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "MRTYPE" Then
                                v_strMRTYPE = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "ISPPUSED" Then
                                v_strMRPPTYPE = .InnerText.ToString
                            End If
                        End With
                        mv_arrBorrowAccountNumber(i) = v_strACCTNO
                    Next

                    If v_strOWNERNAME.Length > 0 Then
                        Me.cboBorrowAFAcctno.Items.Add(v_strOWNERNAME)
                    End If
                    v_strRETURN = v_strCFFULLNAME & ", " & v_strCFEXT
                Next
                If cboBorrowAFAcctno.Items.Count > 0 Then cboBorrowAFAcctno.SelectedIndex = 0
            Else
                v_strRETURN = ResourceManager.GetString("msgCFBORROWERNOTFOUND")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            v_ws = Nothing
        End Try
    End Sub

    Private Sub OnClose()
        Me.Dispose()
    End Sub

    Private Sub OnMoveDeal()
        Dim v_ws As New BDSPalaceOrderManagement
        Dim v_strXMLBuilder As New StringBuilder
        Dim v_strErrorMessage As String
        Dim v_strErrorSource As String = "Main.frmBrokerDesk.OnMoveDeal"
        Try
            'SUBMIT: MOVE DEAL
            Dim v_strMsgConfirm, v_strMessage As String, v_lngReturn, v_row_idx, v_col_idx As Long
            Dim v_strFR_AFACCTNO, v_strTO_AFACCTNO, v_strEXECTYPE, v_strSYMBOL, v_strQTTY, v_strAMOUNT As String
            Dim v_strORDERID, v_strTXDATE, v_strTXNUM, v_strDEALQTTY As String
            v_strFR_AFACCTNO = mv_arrAccountNumber(Me.cboAFAcctno.SelectedIndex)
            v_strTO_AFACCTNO = mv_arrAccountNumber(Me.cboDealAFAcctno.SelectedIndex)
            v_lngReturn = ERR_SYSTEM_OK
            If Me.pnCurrentDeal.Controls.Count > 0 Then
                v_strMsgConfirm = mv_strDealMovingMessage.Replace("$BORS", Me.cboDealType.SelectedValue)
                v_strMsgConfirm = v_strMsgConfirm.Replace("$SYMBOL", Me.mskDealSymbol.Text)
                v_strMsgConfirm = v_strMsgConfirm.Replace("$QTTY", FormatNumber(mv_dblCurrentMoveQtty, 0))
                v_strMsgConfirm = v_strMsgConfirm.Replace("$AMT", FormatNumber(mv_dblCurrentMoveAmount, 0))
                v_strMsgConfirm = v_strMsgConfirm & " => " & cboDealAFAcctno.Text

                Dim v_frmConfirm As New frmBrokerDeskConfirm
                v_frmConfirm.lblAccountInfor.Text = cboAFAcctno.Text
                v_frmConfirm.lblConfirmation.Text = v_strMsgConfirm
                v_frmConfirm.pnHeader.BackColor = Color.White
                v_frmConfirm.pnDetail.BackColor = Color.Black
                Dim frmResult As DialogResult = v_frmConfirm.ShowDialog()
                If frmResult = Windows.Forms.DialogResult.OK Then
                    'Header
                    v_strXMLBuilder.Append("<Order CLASS='PLACEORDER'>" + ControlChars.CrLf)
                    v_strXMLBuilder.Append("<TXDATE>" + Me.BusDate + "</TXDATE>" + ControlChars.CrLf)
                    v_strXMLBuilder.Append("<FRAFACCTNO>" + v_strFR_AFACCTNO + "</FRAFACCTNO>" + ControlChars.CrLf)
                    v_strXMLBuilder.Append("<TOAFACCTNO>" + v_strTO_AFACCTNO + "</TOAFACCTNO>" + ControlChars.CrLf)
                    v_strXMLBuilder.Append("<BORS>" + Me.cboDealType.SelectedValue.ToString + "</BORS>" + ControlChars.CrLf)
                    v_strXMLBuilder.Append("<SYMBOL>" + mskDealSymbol.Text + "</SYMBOL>" + ControlChars.CrLf)
                    v_strXMLBuilder.Append("<QTTY>" + mv_dblCurrentMoveQtty.ToString + "</QTTY>" + ControlChars.CrLf)
                    v_strXMLBuilder.Append("<AMT>" + mv_dblCurrentMoveAmount.ToString + "</AMT>" + ControlChars.CrLf)

                    'Deal detail
                    Dim v_dgData As DataGridView
                    v_dgData = CType(pnCurrentDeal.Controls(0), DataGridView)
                    If v_dgData.RowCount > 0 Then
                        v_strXMLBuilder.Append("<DEALS>" + ControlChars.CrLf)
                        For v_row_idx = 0 To v_dgData.RowCount - 1 Step 1
                            v_strORDERID = v_dgData.Rows(v_row_idx).Cells("ORDERID").Value
                            v_strTXDATE = v_dgData.Rows(v_row_idx).Cells("TXDATE").Value
                            v_strTXNUM = v_dgData.Rows(v_row_idx).Cells("TXNUM").Value
                            v_strDEALQTTY = v_dgData.Rows(v_row_idx).Cells("DEALQTTY").Value
                            'Build detail
                            v_strXMLBuilder.Append("<entry ")
                            v_strXMLBuilder.Append(" ORDERID='" + v_strORDERID + "'")
                            v_strXMLBuilder.Append(" TXDATE='" + v_strTXDATE + "'")
                            v_strXMLBuilder.Append(" TXNUM='" + v_strTXNUM + "'>")
                            v_strXMLBuilder.Append(v_strDEALQTTY + "</entry>" + ControlChars.CrLf)
                        Next
                        v_strXMLBuilder.Append("</DEALS>")
                    End If
                    v_strXMLBuilder.Append("</Order>")

                    v_strMessage = "<RootTrade FUNCNAME='MOVEDEAL'><objPARA></objPARA><objBODY>" + v_strXMLBuilder.ToString + "</objBODY></RootTrade>"
                    v_lngReturn = v_ws.PlaceOrder(v_strMessage)
                    If v_lngReturn = ERR_SYSTEM_OK Then
                        txtFeedback.Text = v_strMessage
                    Else
                        'Thông báo lỗi
                        GetErrorFromMessage(v_strMessage, v_strErrorSource, v_lngReturn, v_strErrorMessage, Me.UserLanguage)
                        Cursor.Current = Cursors.Default
                        Me.txtFeedback.Text = v_strErrorMessage
                        Exit Sub
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            v_strXMLBuilder = Nothing
            v_ws = Nothing
        End Try
    End Sub

    Private Sub getMarginLoaninfo(ByVal f_afacctno As String, ByVal f_symbol As String, ByRef v_strRETURN As String)
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_strValue, v_strFLDNAME, v_strTEXT As String, i, j As Integer
            Dim v_dblDFRate, v_dblQP, v_dbcv As Double
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_strCmdSQL As String, v_strObjMsg As String
            v_dblDFRate = 0
            v_strCmdSQL = " select nvl(dfrate,0) dfrate,nvl(dfprice,0) dfprice from (select * from dfbasket where symbol ='" & f_symbol & "') bk, aftype aft, dftype dft, afmast af where af.actype = aft.actype and aft.dftype = dft.actype and dft.basketid = bk.basketid (+) and af.acctno ='" & f_afacctno & "' "
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_AFMAST, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            For i = 0 To v_nodeList.Count - 1
                For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        'Ghi nhận thuật toán để kiểm tra và tính toán cho từng trư?ng c�ủa giao dịch
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "DFRATE"
                                mv_dblDFRate = CDbl(Trim(v_strValue))
                            Case "DFPRICE"
                                mv_dblDFPrice = CDbl(Trim(v_strValue))
                        End Select
                    End With
                Next
            Next

            If IsNumeric(Me.mskPrice.Text.Trim) Then
                v_dblQP = CDbl(Me.mskPrice.Text.Trim) * mv_dblTradeUnit
                v_dbcv = CDbl(Me.mskPrice.Text.Trim) * mv_dblTradeUnit
                If v_dblQP < mv_dblCeilingPrice Then
                    v_dblQP = mv_dblCeilingPrice
                End If
            Else
                v_dblQP = mv_dblCeilingPrice
                v_dbcv = mv_dblFloorPrice
            End If
            If mv_dblDFPrice > 0 Then
                'Neu ty le giai ngan lon hon gia chan/ gia dat thi lay theo gia chan/ gia dat
                v_dblDFRate = IIf(mv_dblDFRate > mv_dblDFPrice / v_dblQP * 100, FRound(mv_dblDFPrice / v_dblQP * 100, 4), mv_dblDFRate)
            End If
            If v_dblDFRate >= 100 Then
                mv_dblPPSE = mv_dblPURCHASINGPOWER
            Else
                mv_dblPPSE = FRound(CDbl(Me.mv_dblPURCHASINGPOWER) / (1 - v_dblDFRate / 100), 0)
            End If
            mv_dblPPSE = IIf(mv_dblPPSE > mv_dblAVLLIMIT, mv_dblAVLLIMIT, mv_dblPPSE)
            If (mv_dblFloorPrice <> 0) Then
                mv_dblMaxBuyQtty = FRound(mv_dblPPSE / v_dbcv, 0)
            Else
                mv_dblMaxBuyQtty = 1000000
            End If
            'mv_dblMaxBuyQtty = FRound(mv_dblPPSE / mv_dblCeilingPrice, 0)
            v_strRETURN = ResourceManager.GetString("msgCREDITLINEDESCRIPTION")
            v_strRETURN = v_strRETURN.Replace("$PPSE", FormatNumber(mv_dblPPSE, 0))
            v_strRETURN = v_strRETURN.Replace("$LOANRATE", FormatNumber(mv_dblDFRate, 1))
            v_strRETURN = v_strRETURN.Replace("$LOANPRICE", FormatNumber(mv_dblDFPrice, 0))
            v_strRETURN = v_strRETURN.Replace("$MAXBUYQTTY", FormatNumber(mv_dblMaxBuyQtty, 0))
        Catch ex As Exception

            Throw ex
        End Try
    End Sub

    Private Function getMarginLoanSecureRatio(ByVal f_price As Double, ByVal f_codeid As String, ByVal f_afacctno As String)
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_strValue, v_strFLDNAME, v_strTEXT As String, i, j As Integer
            Dim v_dblDFRate, v_dblDFPRICE As Double
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_strCmdSQL As String, v_strObjMsg As String
            v_dblDFRate = 0
            v_strCmdSQL = " select nvl(dfrate,0) dfrate from (select df.* from dfbasket df, sbsecurities sb where df.symbol = sb.symbol and sb.codeid ='" & f_codeid & "') bk, aftype aft, dftype dft, afmast af where af.actype = aft.actype and aft.dftype = dft.actype and dft.basketid = bk.basketid (+) and af.acctno ='" & f_afacctno & "' "
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_AFMAST, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            For i = 0 To v_nodeList.Count - 1
                For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        'Ghi nhận thuật toán để kiểm tra và tính toán cho từng trư?ng c�ủa giao dịch
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "DFRATE"
                                v_dblDFRate = CDbl(Trim(v_strValue))
                            Case "DFPRICE"
                                v_dblDFPRICE = CDbl(Trim(v_strValue))
                        End Select
                    End With
                Next
            Next
            If v_dblDFPRICE > 0 Then
                'Neu ty le giai ngan lon hon gia chan/ gia dat thi lay theo gia chan/ gia dat
                v_dblDFRate = IIf(v_dblDFRate > v_dblDFPRICE / f_price * 100, FRound(v_dblDFPRICE / f_price * 100, 2), v_dblDFRate)
            End If
            Return v_dblDFRate
        Catch ex As Exception
            Return 0
            Throw ex
        End Try
    End Function

    Private Function getFeeSecureRatio(ByVal f_orderid As String, ByVal f_price As Double, ByRef f_deffeerate As Double, ByRef f_minfee As Double)
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_strValue, v_strFLDNAME, v_strTEXT As String, i, j As Integer
            Dim v_dblDFRate, v_dblDFPRICE As Double
            Dim v_dblDEFFEERATE, v_dblMINFEEAMT As Double

            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_strCmdSQL As String, v_strObjMsg As String
            v_dblDFRate = 0
            v_strCmdSQL = " select deffeerate,minfeeamt from odtype odt, odmast od where od.actype = odt.actype and od.orderid ='" & f_orderid & "'"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_AFMAST, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            f_minfee = 0
            f_deffeerate = 0
            For i = 0 To v_nodeList.Count - 1
                For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        'Ghi nhận thuật toán để kiểm tra và tính toán cho từng trư?ng c�ủa giao dịch
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "DEFFEERATE"
                                f_deffeerate = CDbl(Trim(v_strValue))
                            Case "MINFEEAMT"
                                f_minfee = CDbl(Trim(v_strValue))
                        End Select
                    End With
                Next
            Next
            If v_dblDFPRICE > 0 Then
                'Neu ty le giai ngan lon hon gia chan/ gia dat thi lay theo gia chan/ gia dat
                v_dblDFRate = IIf(v_dblDFRate > v_dblDFPRICE / f_price * 100, FRound(v_dblDFPRICE / f_price * 100, 2), v_dblDFRate)
            End If
            Return v_dblDFRate
        Catch ex As Exception
            Return 0
            Throw ex
        End Try
    End Function

    Private Function getTopupRatio(ByVal f_afacctno As String, ByVal f_symbol As String, ByVal f_price As Double) As Double
        Dim v_strRETURN As String
        GetMarginInfo(f_afacctno, f_symbol, v_strRETURN)
        If Me.mv_strMarginType = "S" Or Me.mv_strMarginType = "T" Then 'Margin credit line
            If mv_dblIsPPUsed = 1 Then
                Return CStr(100 / (1 - Me.mv_dblMarginRatioRate / 100 * mv_dblSecMarginPrice / f_price))
            Else
                Return 100
            End If

        Else
            Return 100
        End If
    End Function

    Private Function GetSecureRatio(ByVal f_orderid As String, ByVal f_price As Double, ByVal f_qtty As Double, ByVal f_codeid As String, ByVal f_afacctno As String, ByRef f_feeamount As Double) As Decimal
        Dim v_dblSecureRatio, v_dblFeeSecureRatioMin As Double
        Dim v_dbldeffeerate, v_dblfeemin
        If Me.mv_strMarginType = "S" Or Me.mv_strMarginType = "T" Or Me.mv_strMarginType = "N" Then
            'Neu la tai khoan Margin thi ky quy 100%, tai khoan binh thuong ky quy 100%
            v_dblSecureRatio = 100
        ElseIf Me.mv_strMarginType = "L" Then
            v_dblSecureRatio = Math.Max(100 - getMarginLoanSecureRatio(f_price, f_codeid, f_afacctno), 0)
        Else
            'Cac lenh cua loai hinh binh thuong hoac CL la 100%
            v_dblSecureRatio = 100
        End If

        'Cộng thêm ký quỹ cho phí giao dịch theo loại hình lệnh
        '1.Phí tối thiểu. Nếu phí tối thiểu
        '2. Giá trị giao dịch
        getFeeSecureRatio(f_orderid, f_price, v_dbldeffeerate, v_dblfeemin)
        v_dblFeeSecureRatioMin = v_dblfeemin * 100 / (f_qtty * f_price)
        If v_dblFeeSecureRatioMin > v_dbldeffeerate Then
            v_dblSecureRatio += v_dblFeeSecureRatioMin
            f_feeamount = v_dblfeemin
        Else
            v_dblSecureRatio += v_dbldeffeerate
            f_feeamount = v_dbldeffeerate * (f_qtty * f_price) / 100
        End If

        'GetSecureRatio = Math.Min(mv_dblSecureBratioSYSMax, Math.Max(mv_dblSecureBratioSYSMin, v_dblSecureRatio))
        GetSecureRatio = v_dblSecureRatio
    End Function

    Private Sub ShowAccountForm()
        Dim frmContractInfoScreen As New frmAFMAST_bk
        frmContractInfoScreen.UserLanguage = Me.UserLanguage
        frmContractInfoScreen.KeyFieldName = "ACCTNO"
        frmContractInfoScreen.KeyFieldValue = mv_arrAccountNumber(cboAFAcctno.SelectedIndex)
        frmContractInfoScreen.KeyFieldType = "C"
        frmContractInfoScreen.ObjectName = "CF.AFMAST"
        frmContractInfoScreen.LocalObject = "N"
        frmContractInfoScreen.TableName = "AFMAST"
        frmContractInfoScreen.ModuleCode = "CF"
        frmContractInfoScreen.Text = Me.cboAFAcctno.SelectedText
        frmContractInfoScreen.BranchId = Me.BranchId
        'frmContractInfoScreen.TellerId = Me.TellerId
        frmContractInfoScreen.TellerId = ADMIN_ID
        frmContractInfoScreen.BusDate = Me.BusDate
        frmContractInfoScreen.ExeFlag = ExecuteFlag.View
        frmContractInfoScreen.AuthString = "YYYY"
        frmContractInfoScreen.ShowDialog()
    End Sub

    Private Sub ShowAccountInfomation()
        Dim frmContractInfoScreen As New frmContractInfo(UserLanguage)
        frmContractInfoScreen.AFACCTNO = mv_arrAccountNumber(cboAFAcctno.SelectedIndex)
        frmContractInfoScreen.BranchId = Me.BranchId
        frmContractInfoScreen.TellerId = Me.TellerId
        frmContractInfoScreen.mv_blnBUYSELL = True
        frmContractInfoScreen.v_frmCFAUTH = Me.mv_frmCFAUTH
        frmContractInfoScreen.v_frmCFMAST = Me.mv_frmCFMAST
        frmContractInfoScreen.BusDate = Me.BusDate
        frmContractInfoScreen.ShowDialog()
    End Sub

    Private Function ValidSymbol(ByVal v_strSYMBOL As String) As Boolean
        Dim v_nodeData As Xml.XmlNode, v_nodeList As Xml.XmlNodeList
        Dim v_strValue As String
        Try
            v_strValue = String.Empty
            If Not mv_xmlSYMBOLSLIST Is Nothing Then
                v_nodeList = mv_xmlSYMBOLSLIST.SelectNodes("/ObjectMessage/ObjData")
                For i As Integer = 0 To v_nodeList.Count - 1
                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            If CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "SYMBOL" Then
                                v_strValue = .InnerText.ToString.ToUpper
                                If String.Compare(v_strSYMBOL, v_strValue) = 0 Then
                                    Return True
                                End If
                            End If
                        End With
                    Next

                Next
            End If
            Return False
        Catch ex As Exception
        Finally
        End Try
    End Function

    Private Function ValidOnDeal() As Boolean
        Dim v_xmlDocument As New XmlDocumentEx
        Dim v_nodeData As Xml.XmlNode, v_nodeList As Xml.XmlNodeList
        Dim v_strObjMsg, v_strSQL, v_strValue, v_strFLDNAME, v_strAFACCTNO, v_strCODEID As String
        Dim v_ws As New BDSDeliveryManagement
        Try
            If cboExecType.SelectedIndex = 2 Then
                v_strSQL = "SELECT afacctno, codeid FROM dfmast WHERE acctno = '" & mskDFNo.Text.Trim & "'"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLTX, gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

                For i As Integer = 0 To v_nodeList.Count - 1
                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            v_strValue = .InnerText.ToString
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME)
                                Case "AFACCTNO"
                                    v_strAFACCTNO = v_strValue
                                Case "CODEID"
                                    v_strCODEID = v_strValue
                            End Select

                        End With
                    Next
                Next
                If v_strAFACCTNO <> mv_arrAccountNumber(cboAFAcctno.SelectedIndex) OrElse v_strAFACCTNO <> mv_arrAccountNumber(cboDealAFAcctno.SelectedIndex) Then
                    MessageBox.Show(mv_ResourceManager.GetString("ERR_AFACCTNO_DFACCTNO_NOTMATCH"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    cboAFAcctno.SelectedIndex = cboDealAFAcctno.SelectedIndex
                    Return False
                ElseIf Me.mskSymbol.Tag <> v_strCODEID Then
                    MessageBox.Show(mv_ResourceManager.GetString("ERR_SYMBOL_NOT_MATCH"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    cboAFAcctno.SelectedIndex = cboDealAFAcctno.SelectedIndex
                    Return False
                Else
                    Return True
                End If
                Return False
            End If
        Catch ex As Exception
            Return False
        Finally
        End Try
    End Function

    Public Sub LoadTXScreen(ByVal strTLTXCD As String, _
                Optional ByVal v_blnChain As Boolean = False, _
                Optional ByVal v_blnData As Boolean = False, _
                Optional ByVal v_strXML As String = vbNullString)
        Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode
        Dim v_strValue, v_strFLDNAME As String, i, j, m, n As Integer, v_objField As CFieldMaster, v_objFieldVal As CFieldVal
        Dim v_strFieldName, v_strDefName, v_strCaption, v_strFldType, v_strFldMask, v_strFldFormat, _
            v_strLList, v_strLChk, v_strDefVal, v_strAmtExp, v_strValidTag, v_strLookUp, v_strDataType, _
            v_strChainName, v_strLookupName, v_strPrintInfo, v_strInvName, v_strFldSource, v_strFldDesc, v_strSearchCode, v_strSrModCode As String
        Dim v_intOdrNum, v_intFldLen, v_intIndex As Integer
        Dim v_blnVisible, v_blnEnabled, v_blnMandatory, mv_blnAcctEntry As Boolean
        Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery

        Try
            'Create message to inquiry object fields
            Dim v_strSQL, v_strClause, v_strObjMsg As String
            If Len(v_strXML) > 0 Then
                v_xmlDocumentData.LoadXml(v_strXML)
            End If

            'Lấy thông tin chung ve giao dich
            v_strClause = "upper(TLTXCD) = '" & strTLTXCD & "'"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLTX, gc_ActionInquiry, , v_strClause)
            v_ws.Message(v_strObjMsg)

            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            If v_nodeList.Count = 0 Then
                'Nếu không tồn tại mã giao dịch
                MessageBox.Show(mv_ResourceManager.GetString("ERR_TLTXCD_NOTFOUND"))
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

            'Lấy thông tin chi tiết các truong cua giao dịch
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
                        'Xử lý cho truong Description
                        v_strDefVal = Me.Text
                    ElseIf v_strDefVal = "<$BUSDATE>" Then
                        'Lay ngay lam viec hien tai
                        v_strDefVal = Me.BusDate
                    End If
                    If v_blnChain Then
                        'Nếu giao dịch được nạp qua giao dịch tra cứu
                        If Len(v_strChainName) > 0 Then
                            'Nếu truong nay có sử dụng CHAINNAME để lấy giá trị từ màn hình tra cứu
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

            'Lấy các luật kiểm tra của các truong giao dich
            v_strClause = "SELECT FLDNAME, VALTYPE, OPERATOR, VALEXP, VALEXP2, ERRMSG, EN_ERRMSG FROM FLDVAL " & _
                "WHERE upper(OBJNAME) = '" & strTLTXCD & "' ORDER BY VALTYPE, FLDNAME, ODRNUM" 'Thứ tự order by là quan tr?ng kh�ông sửa
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
                        'Ghi nhận thuật toán để kiểm tra và tính toán cho từng truong cua giao dịch
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

                'Dieu kien xu ly
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
        Finally
            v_xmlDocument = Nothing
            v_xmlDocumentData = Nothing
            v_ws = Nothing
        End Try
    End Sub

#End Region

#Region " Form events "
    Private Sub frmBrokerDesk_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        mv_blnHandleKeyboard = False
        Select Case e.KeyCode
            Case Keys.NumLock, Keys.Subtract, Keys.Divide
                mv_blnHandleKeyboard = True
            Case Keys.Delete
                If Me.tabCtrlAccount.SelectedTab Is Me.tabPageOrders Then
                    If e.Shift Then
                        Dim v_dgData As DataGridView
                        v_dgData = CType(tabPageOrders.Controls(0), DataGridView)
                        For i As Integer = 0 To v_dgData.RowCount - 1 Step 1
                            If mv_dgDataGrid.Rows(i).IsNewRow Then
                                v_dgData.Rows(i).Cells(c_GridSelectedColumn).Value = String.Empty
                            Else
                                v_dgData.Rows(i).Cells(c_GridSelectedColumn).Value = c_GridSelectedValue
                            End If
                        Next
                    End If
                End If
        End Select
    End Sub

    Private Sub frmBrokerDesk_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If mv_blnHandleKeyboard Then
            'The key not allow
            e.Handled = True
        End If
    End Sub

    Private Sub frmBrokerDesk_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        OnInit()
    End Sub

    Private Sub frmBrokerDesk_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Dim v_lngPos, v_lngLength As Long
        If mv_blnNotAllowHotKey Then Exit Sub

        Select Case e.KeyCode
            Case Keys.Z
                'mv_strOldSearchValue
                If e.Control Then
                    If String.Compare(Me.ActiveControl.Name, "mskCriteriaValue") = 0 Then
                        Me.ActiveControl.Text = mv_strOldSearchValue
                    End If
                End If
            Case Keys.E
                If e.Control Then
                    'Ctrl+E: Tab tài khoản
                    Me.tabCtrlAccount.SelectTab(Me.tabPageAccount)
                End If
            Case Keys.L
                If e.Control Then
                    'Ctrl+L: Tab dư nợ
                    Me.tabCtrlAccount.SelectTab(Me.tabPageLoan)
                End If
            Case Keys.D
                If e.Control Then
                    'Ctrl+D: Chi tiết kết quả khớp lệnh
                    Me.tabCtrlAccount.SelectTab(Me.tabPageDeal)
                End If
            Case Keys.Delete
                If String.Compare(Me.tabCtrlAccount.SelectedTab.Name, "tabPageAccount") = 0 Then
                    If Me.pnOrders.Controls.Count > 0 Then
                        If pnOrders.Controls(0).Focused Then
                            If OnGroupCancelOrderTabAccount() Then
                                If chkAutoRefresh.Checked Then
                                    AutoRefreshTabPage()
                                End If
                            Else
                                mv_blnNotAllowHotKey = False
                            End If
                            mv_blnCustomerFound = True
                        End If
                    End If
                ElseIf Me.tabCtrlAccount.SelectedTab Is Me.tabPageOrders Then
                    'Xóa theo nhóm
                    If OnGroupCancelOrder() Then
                        If chkAutoRefresh.Checked Then
                            AutoRefreshTabPage()
                        End If
                    Else
                        mv_blnNotAllowHotKey = False
                    End If
                    mv_blnCustomerFound = True
                End If
            Case Keys.Insert
                'Turn on: Split order
                mv_blnFlagSplitOption = Not mv_blnFlagSplitOption
                If mv_blnFlagSplitOption Then
                    Me.cboOption.SelectedIndex = 1
                Else
                    Me.cboOption.SelectedIndex = 0
                End If
            Case Keys.Escape
                OnClose()
            Case Keys.Enter
                If TypeOf (Me.ActiveControl) Is TextBox _
                Or TypeOf (Me.ActiveControl) Is MaskedTextBox _
                Or TypeOf (Me.ActiveControl) Is ComboBox Then
                    If String.Compare(Me.ActiveControl.Name, "mskPrice") = 0 Then
                        mb_blnIsEnterOnPriceField = True
                        SendKeys.Send("{TAB}")
                    ElseIf String.Compare(Me.ActiveControl.Name, "mskQtty") = 0 _
                        And mskPrice.Enabled = False Then
                        mb_blnIsEnterOnPriceField = True
                        SendKeys.Send("{TAB}")
                    ElseIf String.Compare(Me.ActiveControl.Name, "cboAFAcctno") = 0 Then
                        Me.mskSymbol.Focus()
                    Else
                        'If (String.Compare(Me.ActiveControl.Name, "mskQtty") = 0 And mv_blnFlag = True) Then
                        '    'không làm gì cả                             
                        'Else
                        '    SendKeys.Send("{TAB}")
                        'End If
                                SendKeys.Send("{TAB}")
                    End If
                    e.Handled = True
                End If
            Case Keys.Divide
                SendKeys.Send("{PGUP}")
            Case Keys.Subtract
                SendKeys.Send("{PGDN}")
            Case Keys.PageUp     'MUA
                cboExecType.SelectedIndex = 0
                onResetForm()
            Case Keys.PageDown  'BAN
                cboExecType.SelectedIndex = 1
                onResetForm()
            Case Keys.F1
                Me.cboAFAcctno.Select() 'SET FOCUS
            Case Keys.F5
                If String.Compare(Me.ActiveControl.Name, "mskDFNo") = 0 Then
                    'InquiryDeal()
                Else
                    onRefresh()
                    Me.txtFeedback.Text = String.Empty
                End If
            Case Keys.F9
                'Goi man hinh hien thi thong tin hop dong
                If cboAFAcctno.SelectedIndex <> -1 Then
                    ShowAccountForm()
                End If
            Case Keys.F3
                'Goi man hinh hien thi thong tin chu ky va uy quyen
                If cboAFAcctno.SelectedIndex <> -1 Then
                    ShowAccountInfomation()
                End If
            Case Keys.F11
                Me.mskSymbol.Select()
            Case Keys.Left
                If String.Compare(Me.ActiveControl.Name, "mskCriteriaValue") = 0 Or _
                    String.Compare(Me.ActiveControl.Name, "mskQtty") = 0 Or _
                    String.Compare(Me.ActiveControl.Name, "mskPrice") = 0 Or _
                    String.Compare(Me.ActiveControl.Name, "mskSplitValue") = 0 Or _
                    String.Compare(Me.ActiveControl.Name, "mskSymbol") = 0 Then
                    v_lngPos = CType(Me.ActiveControl, MaskedTextBox).SelectionStart
                    If v_lngPos <= 0 Then
                        SendKeys.Send("+{TAB}") '+ for shift, ^ for Ctrl and % for Alt
                    End If
                End If
            Case Keys.Right
                If String.Compare(Me.ActiveControl.Name, "mskCriteriaValue") = 0 Or _
                    String.Compare(Me.ActiveControl.Name, "mskQtty") = 0 Or _
                    String.Compare(Me.ActiveControl.Name, "mskPrice") = 0 Or _
                    String.Compare(Me.ActiveControl.Name, "mskSplitValue") = 0 Or _
                    String.Compare(Me.ActiveControl.Name, "mskSymbol") = 0 Then
                    v_lngPos = CType(Me.ActiveControl, MaskedTextBox).SelectionStart
                    v_lngLength = CType(Me.ActiveControl, MaskedTextBox).Text.Trim.Length
                    If v_lngPos >= v_lngLength Then
                        SendKeys.Send("{TAB}")
                    End If
                End If
        End Select
    End Sub

    Private Sub cboExecType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboExecType.SelectedIndexChanged
        Select Case cboExecType.SelectedIndex
            Case 0  'NB
                pnODFixedArea.BackColor = FormatGetColorBasedOnTheme("BG_NB_COLOR")
                Me.mskDFNo.Text = String.Empty
                Me.mskDFNo.Enabled = False
                Me.btnGetDeal.Enabled = False
            Case 1  'NS
                pnODFixedArea.BackColor = FormatGetColorBasedOnTheme("BG_NS_COLOR")
                Me.mskDFNo.Text = String.Empty
                Me.mskDFNo.Enabled = False
                Me.btnGetDeal.Enabled = False
            Case 2  'MS
                pnODFixedArea.BackColor = FormatGetColorBasedOnTheme("BG_MS_COLOR")
                Me.mskDFNo.Text = String.Empty
                Me.mskDFNo.Enabled = True
                Me.btnGetDeal.Enabled = True
        End Select
        pnODWorkingArea.BackColor = pnODFixedArea.BackColor
        pnOption.BackColor = pnODFixedArea.BackColor
        Me.lblLinkType.BackColor = pnODFixedArea.BackColor

        'Mac dinh cho truong gia
        Select Case cboPriceType.SelectedIndex
            Case 0  'LO
                Me.mskPrice.Enabled = True
            Case Else   'Other is market order
                SetDefaultPrice()
        End Select
    End Sub

    Private Sub cboOption_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOption.SelectedIndexChanged
        'Mac dinh cho truong gia
        Select Case cboOption.SelectedIndex
            Case 0  'Normal
                Me.cboSplitOption.Enabled = False
                Me.mskSplitValue.Enabled = False
            Case 1   'Special
                Me.cboSplitOption.Enabled = True
                Me.mskSplitValue.Enabled = True
        End Select
    End Sub

    Private Sub mskSymbol_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mskSymbol.Validating
        Dim v_strSYMBOL As String = mskSymbol.Text.Trim.ToUpper
        Dim v_strTradePlace As String
        If v_strSYMBOL.Length > 0 Then
            Dim v_dblRefPrice, v_dblFlPrice, v_dblCePrice, v_dblCurrPrice As Double, v_strReturn As String, v_blnCancel As Boolean
            Dim v_strCLInfo As String
            v_blnCancel = GetInstrumentInformation(v_strTradePlace, v_strSYMBOL, v_dblRefPrice, v_dblFlPrice, v_dblCePrice, v_dblCurrPrice, v_strReturn)
            Me.txtFeedback.Text = String.Empty
            If v_blnCancel Then
                'Lấy thông tin chứng khoán
                GetSymbolInfor(v_strSYMBOL)
                v_blnCancel = GetInstrumentInformation(v_strTradePlace, v_strSYMBOL, v_dblRefPrice, v_dblFlPrice, v_dblCePrice, v_dblCurrPrice, v_strReturn)

                'Nếu chưa xác định khách hàng thì bỏ qua bước này
                If mv_blnCustomerFound And cboAFAcctno.SelectedIndex <> -1 Then
                    If cboExecType.SelectedIndex = 0 And (mv_arrAcctMarginClass(cboAFAcctno.SelectedIndex) = "T" Or mv_arrAcctMarginClass(cboAFAcctno.SelectedIndex) = "S") Then
                        GetMarginInfo(Trim(mv_arrAccountNumber(cboAFAcctno.SelectedIndex)), v_strSYMBOL, v_strCLInfo)
                        v_strReturn = v_strReturn & "    [" & v_strCLInfo & "] "
                    ElseIf cboExecType.SelectedIndex = 0 And mv_arrAcctMarginClass(cboAFAcctno.SelectedIndex) = "L" Then
                        getMarginLoaninfo(Trim(mv_arrAccountNumber(cboAFAcctno.SelectedIndex)), v_strSYMBOL, v_strCLInfo)
                        v_strReturn = v_strReturn & "    [" & v_strCLInfo & "] "
                    End If
                    'Kiểm tra tổ chức phát hành
                    checkInfomation_Customer()
                End If

                mskSymbol.Text = v_strSYMBOL.ToUpper
                lblSYM.Text = v_strSYMBOL.ToUpper
                lblSymbolInfo.Text = v_strReturn
                SymbolInfoColor()
                Me.txtFeedback.Text = String.Empty
                If String.Compare(mv_strExchangeCode, "001") = 0 Then
                    If cboPriceType.SelectedIndex <> 0 Then
                        'Dat mac dinh neu la lenh thi truong
                        SetDefaultPrice()
                    End If
                    cboPriceType.Enabled = True
                ElseIf String.Compare(mv_strExchangeCode, "002") = 0 Then
                    cboPriceType.SelectedIndex = 0
                    cboPriceType.Enabled = False
                End If
            Else
                If Not v_blnCancel Then
                    v_strReturn = mv_ResourceManager.GetString("INVALID_SYMBOL")
                    Me.txtFeedback.Text = v_strReturn
                Else
                    Me.txtFeedback.Text = String.Empty
                End If
            End If
        End If

    End Sub

    Private Sub mskDealSymbol_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskDealSymbol.GotFocus
        mskDealSymbol.SelectAll()
    End Sub

    Private Sub mskDealSymbol_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mskDealSymbol.Validating
        Dim v_strSYMBOL As String
        v_strSYMBOL = Me.mskDealSymbol.Text.ToUpper
        If v_strSYMBOL.Length > 0 Then
            If ValidSymbol(v_strSYMBOL) Then
                Me.mskDealSymbol.Text = v_strSYMBOL
                Me.lblTotalDealMoving.Text = String.Empty
            Else
                Me.lblTotalDealMoving.Text = mv_ResourceManager.GetString("INVALID_SYMBOL")
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub mskDealSymbol_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskDealSymbol.Validated
        'Refresh lai man hinh
        AutoRefreshTabPage()
    End Sub

    Private Sub mskPrice_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskPrice.Validated
        btnOrder.Focus()
    End Sub

    Private Sub mskPrice_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mskPrice.Validating
        Dim v_strSYMBOL As String = mskSymbol.Text.Trim.ToUpper
        Dim v_strTradePlace As String, v_strQUOTEPRICE As String, v_dblTickSize As Double
        Dim v_dblQuotePrice, v_dblRefPrice, v_dblFlPrice, v_dblCePrice, v_dblCurrPrice As Double, v_strReturn As String, v_blnCancel As Boolean
        Dim v_strCLInfo As String
        If Me.mskPrice.Text.Trim.Length = 0 Then
            'Neu khong nhap gia thi khong bat validate
            mb_blnIsEnterOnPriceField = False
            Exit Sub
        End If
        v_blnCancel = GetInstrumentInformation(v_strTradePlace, v_strSYMBOL, v_dblRefPrice, v_dblFlPrice, v_dblCePrice, v_dblCurrPrice, v_strReturn)
        Me.txtFeedback.Text = String.Empty
        If v_blnCancel Then
            v_strQUOTEPRICE = mskPrice.Text.ToUpper.Trim
            If String.Compare(v_strQUOTEPRICE, "ATO") = 0 Then
                mskPrice.Text = v_strQUOTEPRICE.ToUpper
                cboPriceType.SelectedIndex = 1
                If mv_strExchangeCode = "002" Then
                    MessageBox.Show(ResourceManager.GetString("msgHNXINVALIDPRICE"))
                    mskPrice.Focus()
                End If
            ElseIf String.Compare(v_strQUOTEPRICE, "ATC") = 0 Then
                mskPrice.Text = v_strQUOTEPRICE.ToUpper
                cboPriceType.SelectedIndex = 2
                If mv_strExchangeCode = "002" Then
                    MessageBox.Show(ResourceManager.GetString("msgHNXINVALIDPRICE"))
                    mskPrice.Focus()
                End If
            Else
                cboPriceType.SelectedIndex = 0
                If Not IsNumeric(v_strQUOTEPRICE) Then
                    v_strReturn = mv_ResourceManager.GetString("INVALID_NUMBER")
                    e.Cancel = True
                    Me.txtFeedback.Text = v_strReturn
                Else
                    'Tránh lỗi 32.3*1000 thành số lẻ
                    v_dblQuotePrice = CDbl(FormatNumber(CDbl(v_strQUOTEPRICE) * mv_dblTradeUnit, 0))
                    If v_dblQuotePrice < v_dblFlPrice Then
                        v_strReturn = mv_ResourceManager.GetString("LESS_THAN_FLPRICE")
                        e.Cancel = True
                        Me.txtFeedback.Text = v_strReturn
                    ElseIf v_dblQuotePrice > v_dblCePrice Then
                        v_strReturn = mv_ResourceManager.GetString("GREATER_THAN_CEPRICE")
                        e.Cancel = True
                        Me.txtFeedback.Text = v_strReturn
                    Else
                        v_dblTickSize = GetInstrumentTickSize(v_strSYMBOL, v_dblQuotePrice)
                        If v_dblTickSize = 0 Then
                            v_strReturn = mv_ResourceManager.GetString("TICKSIZE_IS_NOT_DEFINED")
                            e.Cancel = True
                            Me.txtFeedback.Text = v_strReturn
                        Else
                            If v_dblQuotePrice Mod v_dblTickSize <> 0 Then
                                v_strReturn = mv_ResourceManager.GetString("INVALID_TICKSIZE")
                                e.Cancel = True
                                Me.txtFeedback.Text = v_strReturn
                            End If
                        End If
                    End If
                End If
            End If
            If e.Cancel = False And cboAFAcctno.SelectedIndex <> -1 Then
                If cboExecType.SelectedIndex = 0 And (mv_arrAcctMarginClass(cboAFAcctno.SelectedIndex) = "T" Or mv_arrAcctMarginClass(cboAFAcctno.SelectedIndex) = "S") Then
                    GetMarginInfo(Trim(mv_arrAccountNumber(cboAFAcctno.SelectedIndex)), v_strSYMBOL, v_strCLInfo)
                    v_strReturn = v_strReturn & "   [" & v_strCLInfo & "] "' & ControlChars.CrLf
                    'Me.lblSecuritiesInfo.Text = v_strReturn
                    lblSymbolInfo.Text = v_strReturn
                    SymbolInfoColor()
                ElseIf cboExecType.SelectedIndex = 0 And mv_arrAcctMarginClass(cboAFAcctno.SelectedIndex) = "L" Then
                    getMarginLoaninfo(Trim(mv_arrAccountNumber(cboAFAcctno.SelectedIndex)), v_strSYMBOL, v_strCLInfo)
                    v_strReturn = v_strReturn & "    [" & v_strCLInfo & "] " '& ControlChars.CrLf 
                    'Me.lblSecuritiesInfo.Text = v_strReturn
                    lblSymbolInfo.Text = v_strReturn
                    SymbolInfoColor()
                End If
            End If
        End If
    End Sub

    Private Sub mskQtty_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskQtty.Validated
        If IsNumeric(mskQtty.Text) Then
            mskQtty.Text = FormatNumber(mskQtty.Text, 0)
        End If
        If mb_blnIsEnterOnPriceField And mskPrice.Enabled = False Then
            'Đặt lệnh
            OnPlaceOrder()
            mb_blnIsEnterOnPriceField = False
            'Refresh lai man hinh
            AutoRefreshTabPage()
        End If
    End Sub

    Private Sub mskQtty_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mskQtty.Validating
        Dim v_strSYMBOL As String = mskSymbol.Text.Trim.ToUpper
        Dim v_strTradePlace As String, v_strORDERQTTY As String
        Dim v_dblQuotePrice, v_dblRefPrice, v_dblFlPrice, v_dblCePrice, v_dblCurrPrice As Double, v_strReturn As String, v_blnCancel As Boolean
        Me.txtFeedback.Text = String.Empty
        v_blnCancel = GetInstrumentInformation(v_strTradePlace, v_strSYMBOL, v_dblRefPrice, v_dblFlPrice, v_dblCePrice, v_dblCurrPrice, v_strReturn)
        If v_blnCancel Then
            If mskQtty.Text.Trim <> String.Empty Then
                v_strORDERQTTY = mskQtty.Text
                If Not IsNumeric(v_strORDERQTTY) Then
                    v_strReturn = mv_ResourceManager.GetString("INVALID_NUMBER")
                    'e.Cancel = True
                    Me.txtFeedback.Text = v_strReturn
                Else
                    If CDbl(v_strORDERQTTY) Mod mv_dblTradeLot <> 0 Then
                        v_strReturn = mv_ResourceManager.GetString("INVALID_TRADELOT")
                        'e.Cancel = True
                        Me.txtFeedback.Text = v_strReturn
                    ElseIf CDbl(v_strORDERQTTY) <= 0 Then
                        v_strReturn = mv_ResourceManager.GetString("QTTY_GREATER_THAN_0")
                        'e.Cancel = True
                        Me.txtFeedback.Text = v_strReturn
                    End If
                    'NamLP: UPCOM
                    If mv_strExchangeCode = "005" AndAlso CDbl(v_strORDERQTTY) < mv_dblMinQtty Then
                        v_strReturn = mv_ResourceManager.GetString("QTTY_GREATER_THAN_MIN")
                        'e.Cancel = True
                        Me.txtFeedback.Text = v_strReturn
                    End If
                    If mv_strExchangeCode = "005" AndAlso CDbl(v_strORDERQTTY) > mv_dblMaxQtty Then
                        v_strReturn = mv_ResourceManager.GetString("QTTY_LESS_THAN_MAX")
                        'e.Cancel = True
                        Me.txtFeedback.Text = v_strReturn
                    End If
                    'NamLP: UPCOM End

                End If
            End If
        End If
    End Sub

    Private Sub cboAFAcctno_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAFAcctno.SelectedIndexChanged
        If mv_strCUSTID.Length > 0 Then
            lblLinkType.Text = mv_arrAccountRole(cboAFAcctno.SelectedIndex)
            Me.txtFeedback.Text = String.Empty
            If cboDealAFAcctno.Items.Count = cboAFAcctno.Items.Count Then
                cboDealAFAcctno.SelectedIndex = cboAFAcctno.SelectedIndex
            End If
            'refresh man hinh
            AutoRefreshTabPage()
        End If
    End Sub

    Private Sub mskCriteriaValue_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles mskCriteriaValue.KeyUp
        If (Me.ActiveControl Is Me.mskCriteriaValue AndAlso Me.mskCriteriaValue.Text.Trim.Length = 10) AndAlso (Not (e.KeyCode = Keys.Tab And Control.ModifierKeys = Keys.Shift) AndAlso Not e.KeyCode = Keys.ShiftKey) AndAlso Not e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub mskCriteriaValue_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mskCriteriaValue.Validating
        SearchByCriteria()
    End Sub

    Private Sub mskCriteriaValue_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskCriteriaValue.GotFocus
        mskCriteriaValue.SelectionStart = mskCriteriaValue.Text.Trim.Length
    End Sub

    Private Sub mskSymbol_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskSymbol.GotFocus
        mskSymbol.SelectAll()
    End Sub

    Private Sub mskPrice_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskPrice.GotFocus
        mskPrice.SelectAll()
    End Sub

    Private Sub mskQtty_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskQtty.GotFocus
        mskQtty.SelectAll()
    End Sub

    Private Sub tabCtrlAccount_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabCtrlAccount.SelectedIndexChanged
        AutoRefreshTabPage()
    End Sub

    Private Sub cboPriceType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPriceType.SelectedIndexChanged
        'Select Case cboPriceType.SelectedIndex
        '    Case 0  'LO
        '        Me.mskPrice.Enabled = True
        '    Case Else   'Other is market order
        '        SetDefaultPrice()
        'End Select
    End Sub

    Private Sub cboDealType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDealType.SelectedIndexChanged
        'Refresh lai man hinh
        AutoRefreshTabPage()
    End Sub

    Private Sub btnMoveDeal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveDeal.Click
        Dim v_intFrom, v_intTo As Long
        If Me.cboDealAFAcctno.SelectedIndex <> -1 Then
            v_intFrom = Me.cboAFAcctno.SelectedIndex
            v_intTo = Me.cboDealAFAcctno.SelectedIndex
            If v_intFrom = v_intTo Then
                Me.txtFeedback.Text = mv_ResourceManager.GetString("CANNOT_MOVE_SAME_AFACCTNO")
            Else
                OnMoveDeal()
            End If
        End If
    End Sub

    'Private Sub btnMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim v_intFrom, v_intTo As Long
    '    If Me.cboMove.SelectedIndex <> -1 Then
    '        v_intFrom = Me.cboAFAcctno.SelectedIndex
    '        v_intTo = Me.cboMove.SelectedIndex
    '        If v_intFrom = v_intTo Then
    '            Me.txtFeedback.Text = mv_ResourceManager.GetString("CANNOT_MOVE_SAME_AFACCTNO")
    '        Else
    '            OnMoveOrder()
    '        End If
    '    End If
    'End Sub

    Private Sub mskSplitValue_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskSplitValue.GotFocus
        mskSplitValue.SelectAll()
    End Sub

    Private Sub mskSplitValue_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mskSplitValue.Validating
        Dim v_strReturn As String
        If mskSplitValue.Text.Trim.Length > 0 Then
            If Not IsNumeric(mskSplitValue.Text) Then
                v_strReturn = mv_ResourceManager.GetString("INVALID_NUMBER")
                e.Cancel = True
                Me.txtFeedback.Text = v_strReturn
            End If
        End If
    End Sub

    Private Sub txtFeedback_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFeedback.GotFocus
        SendKeys.Send("{TAB}")
    End Sub

    Private Sub btnGetDeal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetDeal.Click
        Dim frm As New frmSearch(Me.UserLanguage)
        frm.TableName = "DFSELLDEAL"
        frm.ModuleCode = "DF"
        frm.AuthCode = "NNNNYYNNNN" 'Không cho phép thực hiện chức năng nào 
        frm.IsLocalSearch = gc_IsNotLocalMsg
        frm.IsLookup = "Y"
        frm.SearchOnInit = False
        frm.BranchId = Me.BranchId
        frm.TellerId = Me.TellerId
        frm.AFACCTNO = Trim(mv_arrAccountNumber(cboAFAcctno.SelectedIndex))
        'frm.mv_strSearchFilter = " AND DFTRADING>0 "
        frm.ShowDialog()
        Me.mskDFNo.Text = Trim(frm.ReturnValue)
        GetDealInfo(frm.ReturnValue)
        frm.Dispose()
    End Sub

    Private Sub mskDFNo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles mskDFNo.KeyUp
        Select Case e.KeyCode
            Case Keys.F5
                InquiryDeal()
            Case Keys.Enter
                If Me.mskDFNo.Text.Length = 0 Then
                    InquiryDeal()
                Else
                    SendKeys.Send("{TAB}")
                End If
        End Select

    End Sub

    Private Sub mskDFNo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mskDFNo.Validating
        GetDealInfo(Me.mskDFNo.Text)
    End Sub

    Private Sub Export2ExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Export2ExcelToolStripMenuItem.Click
        'ExportDataGrid2Excel(mv_dgDataGrid)
        Me.OnExport(mv_dgDataGrid)
    End Sub


    Private Sub NoSelectedAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NoSelectedAllToolStripMenuItem.Click
        'Assign to dgRemainOrder
        If mv_dgDataGrid IsNot dgRemainOrder Then
            mv_dgDataGrid = dgRemainOrder
        End If
        mv_dgDataGrid.SuspendLayout()
        For i As Integer = 0 To mv_dgDataGrid.RowCount - 1 Step 1
            mv_dgDataGrid.Rows(i).Cells(c_GridSelectedColumn).Value = String.Empty
        Next
        mv_dgDataGrid.ResumeLayout()
    End Sub

    Private Sub SelectedAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SelectedAllToolStripMenuItem.Click
        'Assign to dgRemainOrder
        If mv_dgDataGrid IsNot dgRemainOrder Then
            mv_dgDataGrid = dgRemainOrder
        End If
        mv_dgDataGrid.SuspendLayout()
        For i As Integer = 0 To mv_dgDataGrid.RowCount - 1 Step 1
            mv_dgDataGrid.Rows(i).Cells(c_GridSelectedColumn).Value = c_GridSelectedValue
        Next
        mv_dgDataGrid.ResumeLayout()
    End Sub

    Private Sub mskBorrowCustodycd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskBorrowCustodycd.GotFocus
        mskBorrowCustodycd.SelectionStart = mskBorrowCustodycd.Text.Trim.Length
    End Sub

    Private Sub mskBorrowCustodycd_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles mskBorrowCustodycd.KeyUp
        If (Me.ActiveControl Is Me.mskBorrowCustodycd AndAlso Me.mskBorrowCustodycd.Text.Trim.Length = 10) AndAlso (Not (e.KeyCode = Keys.Tab And Control.ModifierKeys = Keys.Shift) AndAlso Not e.KeyCode = Keys.ShiftKey) AndAlso Not e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub mskBorrowCustodycd_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mskBorrowCustodycd.Validating
        SearchBorrowerAccount()
    End Sub

    Private Sub btnUserOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUserOrder.Click
        OnQueryUserOrder()
    End Sub

    Private Sub lblHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
#End Region

#Region "Binding for order remains, orders, matched orders"
    'Remain Orders
    Dim statusStripdgRemainOrders As New StatusStrip()
    Dim filterStatusLabeldgRemainOrders As New ToolStripStatusLabel()
    Dim WithEvents showAllLabeldgRemainOrders As New ToolStripStatusLabel("Show &All")
    ' Configures the autogenerated columns, replacing their header
    ' cells with AutoFilter header cells. 
    Private Sub dgRemainOrders_BindingContextChanged(ByVal sender As Object, _
        ByVal e As EventArgs) Handles dgRemainOrder.BindingContextChanged

        ' Continue only if the data source has been set.
        If dgRemainOrder.DataSource Is Nothing Then
            Return
        End If

        ' Add the AutoFilter header cell to each column.
        For Each col As DataGridViewColumn In dgRemainOrder.Columns
            col.HeaderCell = New  _
                DataGridViewAutoFilterColumnHeaderCell(col.HeaderCell)
        Next

        ' Format the OrderTotal column as currency. 
        'dgRemainOrder.Columns("OrderTotal").DefaultCellStyle.Format = "c"

        ' Resize the columns to fit their contents.
        dgRemainOrder.AutoResizeColumns()

    End Sub

    ' Displays the drop-down list when the user presses 
    ' ALT+DOWN ARROW or ALT+UP ARROW.
    Private Sub dgRemainOrder_KeyDown(ByVal sender As Object, _
        ByVal e As KeyEventArgs) Handles dgRemainOrder.KeyDown

        If e.Alt AndAlso (e.KeyCode = Keys.Down OrElse e.KeyCode = Keys.Up) Then

            Dim filterCell As DataGridViewAutoFilterColumnHeaderCell = _
                TryCast(dgRemainOrder.CurrentCell.OwningColumn.HeaderCell,  _
                DataGridViewAutoFilterColumnHeaderCell)
            If filterCell IsNot Nothing Then
                filterCell.ShowDropDownList()
                e.Handled = True
            End If

        End If

    End Sub

    ' Updates the filter status label. 
    Private Sub dgRemainOrder_DataBindingComplete(ByVal sender As Object, _
        ByVal e As DataGridViewBindingCompleteEventArgs) _
        Handles dgRemainOrder.DataBindingComplete

        Dim filterStatus As String = DataGridViewAutoFilterColumnHeaderCell _
            .GetFilterStatus(dgRemainOrder)
        If String.IsNullOrEmpty(filterStatus) Then
            showAllLabeldgRemainOrders.Visible = False
            filterStatusLabeldgRemainOrders.Visible = False
        Else
            showAllLabeldgRemainOrders.Visible = True
            filterStatusLabeldgRemainOrders.Visible = True
            filterStatusLabeldgRemainOrders.Text = filterStatus
        End If
    End Sub

    ' Clears the filter when the user clicks the "Show All" link
    ' or presses ALT+A. 
    Private Sub showAllLabeldgRemainOrders_Click(ByVal sender As Object, _
        ByVal e As EventArgs) Handles showAllLabeldgRemainOrders.Click

        DataGridViewAutoFilterColumnHeaderCell.RemoveFilter(dgRemainOrder)

    End Sub

    Dim statusStripdgOrderBook As New StatusStrip()
    Dim filterStatusLabeldgOrderBook As New ToolStripStatusLabel()
    Dim WithEvents showAllLabeldgOrderBook As New ToolStripStatusLabel("Show &All")
    ' Configures the autogenerated columns, replacing their header
    ' cells with AutoFilter header cells. 
    Private Sub dgOrderBook_BindingContextChanged(ByVal sender As Object, _
        ByVal e As EventArgs) Handles dgOrderBook.BindingContextChanged

        ' Continue only if the data source has been set.
        If dgOrderBook.DataSource Is Nothing Then
            Return
        End If

        ' Add the AutoFilter header cell to each column.
        For Each col As DataGridViewColumn In dgOrderBook.Columns
            col.HeaderCell = New  _
                DataGridViewAutoFilterColumnHeaderCell(col.HeaderCell)
        Next

        ' Format the OrderTotal column as currency. 
        'dgRemainOrder.Columns("OrderTotal").DefaultCellStyle.Format = "c"

        ' Resize the columns to fit their contents.
        dgOrderBook.AutoResizeColumns()

    End Sub

    ' Displays the drop-down list when the user presses 
    ' ALT+DOWN ARROW or ALT+UP ARROW.
    Private Sub dgOrderBook_KeyDown(ByVal sender As Object, _
        ByVal e As KeyEventArgs) Handles dgOrderBook.KeyDown

        If e.Alt AndAlso (e.KeyCode = Keys.Down OrElse e.KeyCode = Keys.Up) Then

            Dim filterCell As DataGridViewAutoFilterColumnHeaderCell = _
                TryCast(dgOrderBook.CurrentCell.OwningColumn.HeaderCell,  _
                DataGridViewAutoFilterColumnHeaderCell)
            If filterCell IsNot Nothing Then
                filterCell.ShowDropDownList()
                e.Handled = True
            End If

        End If

    End Sub

    ' Updates the filter status label. 
    Private Sub dgOrderBook_DataBindingComplete(ByVal sender As Object, _
        ByVal e As DataGridViewBindingCompleteEventArgs) _
        Handles dgOrderBook.DataBindingComplete

        Dim filterStatus As String = DataGridViewAutoFilterColumnHeaderCell _
            .GetFilterStatus(dgOrderBook)
        If String.IsNullOrEmpty(filterStatus) Then
            showAllLabeldgOrderBook.Visible = False
            filterStatusLabeldgOrderBook.Visible = False
        Else
            showAllLabeldgOrderBook.Visible = True
            filterStatusLabeldgOrderBook.Visible = True
            filterStatusLabeldgOrderBook.Text = filterStatus
        End If
    End Sub

    ' Clears the filter when the user clicks the "Show All" link
    ' or presses ALT+A. 
    Private Sub showAllLabeldgOrderBook_Click(ByVal sender As Object, _
        ByVal e As EventArgs) Handles showAllLabeldgOrderBook.Click

        DataGridViewAutoFilterColumnHeaderCell.RemoveFilter(dgOrderBook)

    End Sub
#End Region



    Private Sub RadioCustodyCd_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioCustodyCd.CheckedChanged
        If Me.mskCriteriaValue.Text.Length > 0 Then
            'lblLinkType.Text = mv_arrAccountRole(cboAFAcctno.SelectedIndex)
            'Me.txtFeedback.Text = String.Empty

            'refresh man hinh
            AutoRefreshTabPage()
        End If
    End Sub

    Private Sub ChkByUser_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkByUser.CheckedChanged
        AutoRefreshTabPage()
    End Sub

    Private Sub btnOrder_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOrder.Click
        'If mb_blnIsEnterOnPriceField Then
        'Đặt lệnh
        If OnPlaceOrder() Then
            mb_blnIsEnterOnPriceField = False
            'Refresh lai man hinh
            If chkAutoRefresh.Checked Then
                AutoRefreshTabPage()
            End If
            onResetForm()
            mv_blnFlagSplitOption = False
            Me.mskSplitValue.Enabled = mv_blnFlagSplitOption
            If mv_blnFlagSplitOption Then
                Me.cboOption.SelectedIndex = 1
            Else
                Me.cboOption.SelectedIndex = 0
            End If
            mv_blnCustomerFound = True
        Else
            'mv_blnNotAllowHotKey = True
            'If MsgBox(Me.txtFeedback.Text, MsgBoxStyle.OkOnly, Me.Text) = MsgBoxResult.Ok Then
            '    mv_blnNotAllowHotKey = False
            'End If
            mv_blnNotAllowHotKey = False
        End If
        'End If
    End Sub
End Class

Public Class BindGridTaskInfo
    Public xml As String
    Public dgv As DataGridView
    Public dtype As String

    Public Sub New()

    End Sub
End Class